using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using Twol.Mapping;
using File = System.IO.File;

namespace Twol
{
    public class CMap
    {
        //copy of the mainform address
        private readonly FormGPS mf;

        /// <summary>
        /// /checks if internet is connected
        /// If not connected, tiles won't be requested from server
        /// </summary>
        bool isInternetConnected = false;

        public CMap(FormGPS _f)
        {
            mf = _f;

            // Intialize worker, if not yet initialized
            for (int w = 0; w < _Workers.Length; w++)
            {
                _Workers[w] = new Thread(new ThreadStart(ProcessRequests));
                _Workers[w].Name = $"Request worker #{w + 1}";
                _Workers[w].IsBackground = true;
                _Workers[w].Priority = ThreadPriority.Highest;
                _Workers[w].Start();
            }

            isInternetConnected = IsConnectedToInternet();
        }

        /// <summary>
        /// Tile size, in pixels.
        /// </summary>
        private const int TILE_SIZE = 256;

        /// <summary>
        /// Cache used to store tile images in memory.
        /// </summary>
        public ConcurrentBag<Tile> _Cache = new ConcurrentBag<Tile>();

        /// <summary>
        /// Pool of tiles to be requested from the server.
        /// </summary>
        private ConcurrentBag<Tile> _RequestPool = new ConcurrentBag<Tile>();

        /// <summary>
        /// Worker threads for processing tile requests to the server.
        /// </summary>
        private Thread[] _Workers = new Thread[3];

        /// <summary>
        /// Event handle to stop/resume requests processing.
        /// </summary>
        private EventWaitHandle _WorkerWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);

        /// <summary>
        /// Gets size of map in tiles.
        /// </summary>
        private int FullMapSizeInTiles => 1 << ZoomLevel;

        /// <summary>
        /// Gets maps size in pixels.
        /// </summary>
        private int FullMapSizeInPixels => FullMapSizeInTiles * TILE_SIZE;

        /// <summary>
        /// Backing field for <see cref="ZoomLevel"/> property.
        /// </summary>
        private int _ZoomLevel = 15;

        /// <summary>
        /// Map zoom level.
        /// </summary>
        [Description("Map zoom level"), Category("Behavior")]
        public int ZoomLevel
        {
            get => _ZoomLevel;
            set
            {
                if (value < 13 || value > 17) _ZoomLevel = 15;
                else _ZoomLevel = value;

            }
        }

        /// <summary>
        /// Backing field for <see cref="CacheFolder"/> property.
        /// </summary>
        public string CacheFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TWOL", "GoogleMapsSatelliteTileServer");

        //private tileServer instance
        readonly TileServer tileServer = new TileServer();
        public TileServer TileServerInstance => tileServer;

        /// <summary>
        /// Does a tile request to the tile server
        /// </summary>
        /// <param name="x">X-index of the tile to be requested.</param>
        /// <param name="y">Y-index of the tile to be requested.</param>
        /// <param name="z">Zoom level</param>
        private void RequestTile(int x, int y, int z)
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
            while (!_Shutdown && !(mf?.IsDisposed ?? true))
            {
                bool processedAny = false;

                // Drain the request pool
                while (_RequestPool.TryTake(out Tile tile))
                {
                    processedAny = true;
                    var key = $"{tile.Z}:{tile.X}:{tile.Y}";
                    try
                    {
                        tile.Image = TileServerInstance.GetTile(tile.X, tile.Y, tile.Z);
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
                                string localPath = Path.Combine(CacheFolder, $"{tile.Z}", $"{tile.X}", $"{tile.Y}.tile");
                                var dir = Path.GetDirectoryName(localPath);
                                if (!string.IsNullOrEmpty(dir))
                                {
                                    Directory.CreateDirectory(dir);
                                }

                                // Save image safely
                                tile.Image.Save(localPath);
                                Debug.WriteLine($"saved {localPath}");

                                // Add to the memory cache
                                _Cache.Add(tile);
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

        public Tile GetTile(int x, int y, int z)
        {
            try
            {
                Tile tile;

                // Try memory cache
                tile = _Cache.FirstOrDefault(t => t.Z == z && t.X == x && t.Y == y);
                if (tile != null) return tile;

                // Try file system without locking the file
                string localPath = Path.Combine(CacheFolder, $"{z}", $"{x}", $"{y}.tile");
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
                            _Cache.Add(tile);
                            return tile;
                        }
                    }
                }

                // Request from server if online
                if (isInternetConnected)
                {
                    RequestTile(x, y, z);
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public GeoPnt TileToWSG84Pos(double x, double y, int z)
        {
            GeoPnt g = new GeoPnt();
            double z1 = 1 << z;
            double n = Math.PI - (2 * Math.PI * y / z1);
            g.Longitude = (float)((x / z1 * 360.0) - 180.0);
            g.Latitude = (float)(180.0 / Math.PI * Math.Atan(Math.Sinh(n)));
            return g;
        }

        public PointF WSG84ToTilePos(double Longitude, double Latitude, int z)
        {
            var p = new PointF();
            double z1 = 1 << z;
            p.X = (float)((Longitude + 180.0) / 360.0 * z1);
            p.Y = (float)((1.0 - Math.Log(Math.Tan(Latitude * Math.PI / 180.0) + 1.0 / Math.Cos(Latitude * Math.PI / 180.0)) / Math.PI) / 2.0 * z1);
            return p;
        }

        // Replaces the old IsConnectedToInternet() implementation.
        public bool IsConnectedToInternet()
        {
            const string testUrl = "http://clients3.google.com/generate_204";
            try
            {
                // Create a simple request to a known endpoint that returns 204 when online.
                var request = (HttpWebRequest)WebRequest.Create(testUrl);
                request.Method = "GET";
                request.Timeout = 3000; // milliseconds
                request.AllowAutoRedirect = false; // avoid captive portal redirects being followed
                                                   // Some environments may require TLS settings; keep default for http endpoint.

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    // 204 (NoContent) is the expected response for connectivity check.
                    if (response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK)
                        return true;
                }
            }
            catch (WebException wex)
            {
                // If the server returned a response (e.g., captive portal), check its status code.
                if (wex.Response is HttpWebResponse webResponse)
                {
                    if (webResponse.StatusCode == HttpStatusCode.NoContent || webResponse.StatusCode == HttpStatusCode.OK)
                        return true;
                }
                // Otherwise fall through and return false.
            }
            catch
            {
                // Ignore other exceptions and report disconnected.
            }

            return false;
        }

        //safer concurrency
        private readonly ConcurrentDictionary<string, byte> _InFlight = new ConcurrentDictionary<string, byte>();

        private volatile bool _Shutdown;
    }
}
