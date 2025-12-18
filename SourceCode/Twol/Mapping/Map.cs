using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using Twol.Mapping;
using File = System.IO.File;

namespace Twol
{
    public class Map
    {
        //copy of the mainform address
        private readonly FormGPS mf;

        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class and starts worker threads to process requests.
        /// </summary>
        /// <remarks>This constructor initializes the worker threads used for processing requests and
        /// starts them immediately. It also checks the current internet connection status and sets the
        /// <c>isInternetConnected</c> field accordingly.</remarks>
        /// <param name="_f">The <see cref="FormGPS"/> instance associated with this map.</param>
        public Map(FormGPS _f)
        {
            mf = _f;

            // Intialize worker, if not yet initialized
            for (int w = 0; w < _Workers.Length; w++)
            {
                _Workers[w] = new Thread(new ThreadStart(ProcessRequests))
                {
                    Name = $"Request worker #{w + 1}",
                    IsBackground = true,
                    Priority = ThreadPriority.Highest
                };
                _Workers[w].Start();
            }

            mf.isInternetConnected = mf.CheckInternetConnection();
        }

        #region Cache And Folder

        /// <summary>
        /// Backing field for <see cref="_CacheFolder"/> property.
        /// </summary>
        private readonly string _CacheFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TWOL", "TexCache");

        /// <summary>
        /// Cache used to store tile images in memory.
        /// </summary>
        public ConcurrentBag<Tile> tileCache = new ConcurrentBag<Tile>();

        #endregion

        #region Zoom

        /// <summary>
        /// Backing field for <see cref="ZoomLevel"/> property.
        /// </summary>
        private int _ZoomLevel = 15;

        /// <summary>
        /// Map zoom level.
        /// </summary>
        public int ZoomLevel
        {
            get => _ZoomLevel;
            set
            {
                if (value < 11 ) _ZoomLevel = 11;
                else if (value > 18) _ZoomLevel = 18;
                else _ZoomLevel = value;
            }
        }

        #endregion

        #region Tile Provider

        /// <summary>
        /// The default online tile server (Google Maps).
        /// </summary>
        private readonly TileServer _TileServer = new TileServer();

        /// <summary>
        /// The active tile provider. Can be switched between online and GeoTIFF.
        /// </summary>
        private ITileProvider _activeProvider;

        /// <summary>
        /// The local GeoTIFF provider, if loaded.
        /// </summary>
        private GeoTiffProvider _geoTiffProvider;

        /// <summary>
        /// Gets the current instance of the tile server.
        /// </summary>
        public TileServer tileServerInstance => _TileServer;

        /// <summary>
        /// Gets the active tile provider.
        /// </summary>
        public ITileProvider ActiveProvider => _activeProvider ?? _TileServer;

        /// <summary>
        /// Gets whether a local GeoTIFF is currently active (loaded AND being used).
        /// </summary>
        public bool IsGeoTiffLoaded => _activeProvider is GeoTiffProvider && _geoTiffProvider != null && _geoTiffProvider.IsAvailable;

        /// <summary>
        /// Gets the path to the currently loaded GeoTIFF file.
        /// </summary>
        public string GeoTiffPath => _geoTiffProvider?.FilePath;

        /// <summary>
        /// Gets the name of the currently active tile provider.
        /// </summary>
        public string ActiveProviderName => ActiveProvider?.Name ?? "Unknown";

        /// <summary>
        /// Loads a GeoTIFF file and sets it as the active tile provider.
        /// </summary>
        /// <param name="geoTiffPath">Path to the GeoTIFF file.</param>
        /// <returns>True if the GeoTIFF was loaded successfully.</returns>
        public bool LoadGeoTiff(string geoTiffPath)
        {
            try
            {
                // Dispose previous GeoTIFF provider if any
                _geoTiffProvider?.Dispose();
                _geoTiffProvider = null;

                if (!File.Exists(geoTiffPath))
                    return false;

                _geoTiffProvider = new GeoTiffProvider(geoTiffPath);
                _activeProvider = _geoTiffProvider;

                // Clear tile cache when switching providers
                tileCache = new ConcurrentBag<Tile>();

                Debug.WriteLine($"Loaded GeoTIFF: {geoTiffPath}");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to load GeoTIFF: {ex.Message}");
                _geoTiffProvider = null;
                _activeProvider = null;
                return false;
            }
        }

        /// <summary>
        /// Unloads the current GeoTIFF and switches back to online tiles.
        /// </summary>
        public void UnloadGeoTiff()
        {
            _geoTiffProvider?.Dispose();
            _geoTiffProvider = null;
            _activeProvider = null;

            // Clear tile cache when switching providers
            tileCache = new ConcurrentBag<Tile>();

            Debug.WriteLine("Switched to online tile server");
        }

        /// <summary>
        /// Switches to using online tiles (Google Maps).
        /// </summary>
        public void UseOnlineTiles()
        {
            _activeProvider = null; // Will fall back to _TileServer
            tileCache = new ConcurrentBag<Tile>();
            Debug.WriteLine("Using online tiles");
        }

        /// <summary>
        /// Switches to using the loaded GeoTIFF if available.
        /// </summary>
        /// <returns>True if switched to GeoTIFF, false if no GeoTIFF is loaded.</returns>
        public bool UseGeoTiff()
        {
            if (_geoTiffProvider != null && _geoTiffProvider.IsAvailable)
            {
                _activeProvider = _geoTiffProvider;
                tileCache = new ConcurrentBag<Tile>();
                Debug.WriteLine("Using GeoTIFF tiles");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Pool of tiles to be requested from the server.
        /// </summary>
        private readonly ConcurrentBag<Tile> _RequestPool = new ConcurrentBag<Tile>();

        /// <summary>
        /// Represents a thread-safe collection of in-flight operations, identified by a unique string key.
        /// </summary>
        /// <remarks>This dictionary is used to track operations that are currently in progress. The keys
        /// represent unique identifiers for the operations, and the values are placeholders (of type <see
        /// cref="byte"/>) that are not used for any specific purpose.</remarks>
        private readonly ConcurrentDictionary<string, byte> _InFlight = new ConcurrentDictionary<string, byte>();

        /// <summary>
        /// Worker threads for processing tile requests to the server.
        /// </summary>
        private readonly Thread[] _Workers = new Thread[5];

        /// <summary>
        /// Event handle to stop/resume requests processing.
        /// </summary>
        private readonly EventWaitHandle _WorkerWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);

        /// <summary>
        /// Indicates whether the system is in a shutdown state.
        /// </summary>
        /// <remarks>This field is read-only and is intended to track the shutdown status of the system.
        /// It is not exposed publicly and should only be used internally within the class.</remarks>
        public bool isShuttingDown = false;

        /// <summary>
        /// Does a tile request to threaded worker pool.
        /// </summary>
        /// <param name="x">X-index of the tile to be requested.</param>
        /// <param name="y">Y-index of the tile to be requested.</param>
        /// <param name="z">Zoom level</param>
        public void RequestTileFromTileServer(int x, int y, int z)
        {
            var key = $"{z}:{x}:{y}";
            // Ensure only one request per tile at a time
            if (_InFlight.TryAdd(key, 0))
            {
                _RequestPool.Add(new Tile(x, y, z));
                _WorkerWaitHandle.Set();
            }
        }

        /// <summary>
        /// Background worker function.
        /// Processes tiles requests if requests pool is not empty,
        /// than stops execution until the pool gets a new image request.
        /// Breaks execution on disposing.
        /// </summary>
        private void ProcessRequests()
        {
            while (!isShuttingDown && !(mf?.IsDisposed ?? true))
            {
                bool processedAny = false;

                // Drain the request pool
                while (_RequestPool.TryTake(out Tile tile))
                {
                    processedAny = true;
                    var key = $"{tile.Z}:{tile.X}:{tile.Y}";
                    try
                    {
                        // Use active provider or fall back to TileServer
                        var provider = ActiveProvider;
                        tile.Image = provider.GetTile(tile.X, tile.Y, tile.Z);
                        tile.Used = tile.Image != null;
                    }
                    catch (Exception ex)
                    {
                        tile.ErrorMessage = ex.Message;
                    }
                    finally
                    {
                        try
                        {
                            if (tile.Image != null)
                            {
                                Debug.WriteLine($"Thread {Thread.CurrentThread.Name} Found tile Z:{tile.Z} X:{tile.X} Y:{tile.Y}");

                                // Only cache to disk for online tiles
                                if (ActiveProvider.RequiresInternet)
                                {
                                    string localPath = Path.Combine(_CacheFolder, $"{tile.Z}", $"{tile.X}", $"{tile.Y}.tile");
                                    var dir = Path.GetDirectoryName(localPath);
                                    if (!string.IsNullOrEmpty(dir))
                                    {
                                        Directory.CreateDirectory(dir);
                                    }

                                    // Save image safely
                                    tile.Image.Save(localPath);
                                    Debug.WriteLine($"saved {localPath}");
                                    Thread.Sleep(20); // Give some time for file system
                                }

                                // Add to the memory cache
                                tileCache.Add(tile);
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Unable to save tile image. Reason: {ex.Message}");
                        }
                        finally
                        {
                            // Clear in-flight marker
                            byte _;
                            _InFlight.TryRemove(key, out _);
                        }
                    }
                }

                // If nothing processed, wait for new requests
                if (!processedAny)
                {
                    _WorkerWaitHandle.WaitOne();
                }
            }
        }

        #endregion

        #region Tile Location Functions

        /// <summary>
        /// Retrieves a tile at the specified coordinates and zoom level.
        /// </summary>
        /// <remarks>This method attempts to retrieve the tile from multiple sources in the following
        /// order: memory cache, local file system, and, if online, a remote tile server. If the tile is found  in the
        /// memory cache or local file system, it is returned immediately. If the tile is retrieved  from the remote
        /// server, it may be cached for future use.</remarks>
        /// <param name="x">The X coordinate of the tile.</param>
        /// <param name="y">The Y coordinate of the tile.</param>
        /// <param name="z">The zoom level of the tile.</param>
        /// <returns>A <see cref="Tile"/> object representing the tile at the specified coordinates and zoom level,  or <see
        /// langword="null"/> if the tile is not found or an error occurs.</returns>
        public Tile GetTile(int x, int y, int z)
        {
            try
            {
                Tile tile;

                // Try memory cache
                tile = tileCache.FirstOrDefault(t => t.Z == z && t.X == x && t.Y == y);
                if (tile != null) return tile;

                // For GeoTIFF provider, create hybrid tile (online background + GeoTIFF overlay)
                if (_activeProvider is GeoTiffProvider geoProvider)
                {
                    var geoTiffImage = geoProvider.GetTile(x, y, z);

                    // Check if tile is completely within GeoTIFF bounds (no transparency needed)
                    bool isFullyCovered = IsTileFullyCoveredByGeoTiff(x, y, z, geoProvider);

                    if (geoTiffImage != null && isFullyCovered)
                    {
                        // Tile is fully covered by GeoTIFF - use as-is
                        tile = new Tile(geoTiffImage, x, y, z);
                        tileCache.Add(tile);
                        return tile;
                    }
                    else if (geoTiffImage != null)
                    {
                        // Tile is partially covered - use GeoTIFF alone with transparent background
                        // (no online requests when GeoTIFF is active)
                        tile = new Tile(geoTiffImage, x, y, z);
                        tileCache.Add(tile);
                        return tile;
                    }
                    else
                    {
                        // Tile completely outside GeoTIFF bounds - return null (transparent)
                        // (no online requests when GeoTIFF is active)
                        return null;
                    }
                }

                // Try file system without locking the file (for online tiles)
                string localPath = Path.Combine(_CacheFolder, $"{z}", $"{x}", $"{y}.tile");
                if (File.Exists(localPath))
                {
                    var fileInfo = new FileInfo(localPath);
                    if (fileInfo.Length > 0)
                    {
                        using (var fs = new FileStream(localPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                        using (var img = Image.FromStream(fs))
                        {
                            // Clone to detach from stream and avoid file lock
                            var cloned = new Bitmap(img);
                            tile = new Tile(cloned, x, y, z);
                            tileCache.Add(tile);
                            return tile;
                        }
                    }
                }

                // Request from server if online
                if (mf.isInternetConnected)
                {
                    RequestTileFromTileServer(x, y, z);
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Checks if a tile is completely covered by the GeoTIFF bounds.
        /// </summary>
        private bool IsTileFullyCoveredByGeoTiff(int x, int y, int z, GeoTiffProvider geoProvider)
        {
            double tileWest = ESRIDownloader.TileXToLon(x, z);
            double tileEast = ESRIDownloader.TileXToLon(x + 1, z);
            double tileNorth = ESRIDownloader.TileYToLat(y, z);
            double tileSouth = ESRIDownloader.TileYToLat(y + 1, z);

            var bounds = geoProvider.Bounds;

            // Tile is fully covered if all corners are within GeoTIFF bounds
            return tileWest >= bounds.MinLon && tileEast <= bounds.MaxLon &&
                   tileSouth >= bounds.MinLat && tileNorth <= bounds.MaxLat;
        }

        /// <summary>
        /// Gets an online tile image from cache or file system (without requesting from server).
        /// </summary>
        private Image GetOnlineTileImage(int x, int y, int z)
        {
            try
            {
                string localPath = Path.Combine(_CacheFolder, $"{z}", $"{x}", $"{y}.tile");
                if (File.Exists(localPath))
                {
                    var fileInfo = new FileInfo(localPath);
                    if (fileInfo.Length > 0)
                    {
                        using (var fs = new FileStream(localPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                        using (var img = Image.FromStream(fs))
                        {
                            return new Bitmap(img);
                        }
                    }
                }

                // If no cached tile and we're online, try to get it from server synchronously
                if (mf.isInternetConnected)
                {
                    var image = _TileServer.GetTile(x, y, z);
                    if (image != null)
                    {
                        // Cache it for future use
                        try
                        {
                            var dir = Path.GetDirectoryName(localPath);
                            if (!string.IsNullOrEmpty(dir))
                            {
                                Directory.CreateDirectory(dir);
                            }
                            image.Save(localPath);
                        }
                        catch { }

                        return new Bitmap(image);
                    }
                }
            }
            catch { }

            return null;
        }

        public bool PrefetchTile(int x, int y, int z)
        {
            try
            {
                // Try memory cache
                var tile = tileCache.FirstOrDefault(t => t.Z == z && t.X == x && t.Y == y);
                if (tile != null) return true;

                // For GeoTIFF, always available if within bounds
                if (_activeProvider is GeoTiffProvider geoProvider)
                {
                    // Check if tile is within GeoTIFF bounds
                    double tileWest = ESRIDownloader.TileXToLon(x, z);
                    double tileEast = ESRIDownloader.TileXToLon(x + 1, z);
                    double tileNorth = ESRIDownloader.TileYToLat(y, z);
                    double tileSouth = ESRIDownloader.TileYToLat(y + 1, z);

                    var bounds = geoProvider.Bounds;
                    return !(tileEast < bounds.MinLon || tileWest > bounds.MaxLon ||
                             tileSouth > bounds.MaxLat || tileNorth < bounds.MinLat);
                }

                // Try file system without locking the file
                string localPath = Path.Combine(_CacheFolder, $"{z}", $"{x}", $"{y}.tile");
                if (File.Exists(localPath))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Converts tile coordinates at a specific zoom level to a geographic position in the WGS84 coordinate system.
        /// </summary>
        /// <remarks>The method calculates the geographic position by interpreting the tile coordinates as
        /// part of a global map grid. The latitude and longitude values are computed based on the Mercator projection
        /// commonly used in web mapping.</remarks>
        /// <param name="x">The x-coordinate of the tile.</param>
        /// <param name="y">The y-coordinate of the tile.</param>
        /// <param name="z">The zoom level of the tile. Must be a non-negative integer.</param>
        /// <returns>A <see cref="GeoPnt"/> representing the geographic position, with latitude and longitude in the WGS84
        /// coordinate system.</returns>
        public GeoPnt TileToWSG84Pos(double x, double y, int z)
        {
            GeoPnt g = new GeoPnt();
            double z1 = 1 << z;
            double n = Math.PI - (2 * Math.PI * y / z1);
            g.Longitude = (float)((x / z1 * 360.0) - 180.0);
            g.Latitude = (float)(180.0 / Math.PI * Math.Atan(Math.Sinh(n)));
            return g;
        }

        /// <summary>
        /// Converts geographic coordinates (longitude and latitude) to a tile position at a specified zoom level.
        /// </summary>
        /// <remarks>This method uses the Web Mercator projection (EPSG:3857) to map geographic
        /// coordinates to a 2D tile grid. The resulting tile position is fractional, meaning the X and Y values may
        /// include decimal points, which can be used for sub-tile precision.</remarks>
        /// <param name="Longitude">The longitude of the geographic coordinate, in degrees. Valid values range from -180 to 180.</param>
        /// <param name="Latitude">The latitude of the geographic coordinate, in degrees. Valid values range from -85.05112878 to 85.05112878.</param>
        /// <param name="z">The zoom level, which determines the resolution of the tile grid. Must be a non-negative integer.</param>
        /// <returns>A <see cref="PointF"/> representing the tile position. The X and Y values correspond to the fractional tile
        /// coordinates at the specified zoom level.</returns>
        public PointF WSG84ToTilePos(double Longitude, double Latitude, int z)
        {
            var p = new PointF();
            double z1 = 1 << z;
            p.X = (float)((Longitude + 180.0) / 360.0 * z1);
            p.Y = (float)((1.0 - Math.Log(Math.Tan(Latitude * Math.PI / 180.0) + 1.0 / Math.Cos(Latitude * Math.PI / 180.0)) / Math.PI) / 2.0 * z1);
            return p;
        }

        #endregion
    }
}
