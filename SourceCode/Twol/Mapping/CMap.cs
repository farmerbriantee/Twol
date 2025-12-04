using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Threading;
using System.Windows.Forms;
using Twol.Mapping;

namespace Twol
{
    public class CMap
    {
        //copy of the mainform address
        private readonly FormGPS mf;

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
            // Check the tile is already requested
            if (!_RequestPool.Any(t => t.Z == z && t.X == x && t.Y == y))
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
            while (!mf.IsDisposed)
            {
                // try to process all tile requests till pool is not empty
                while (_RequestPool.TryTake(out Tile tile))
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} processing...");
                    try
                    {
                        tile.Image = (TileServerInstance.GetTile(tile.X, tile.Y, tile.Z));
                        tile.Used = true;
                    }
                    catch (Exception ex)
                    {
                        // keep error text to be displayed instead of the tile
                        tile.ErrorMessage = ex.Message;
                    }
                    finally
                    {
                        // if we have obtained image from the server, save it in file system (if server supports file system cache)
                        if (tile.Image != null)
                        {
                            string localPath = Path.Combine(CacheFolder, $"{tile.Z}", $"{tile.X}", $"{tile.Y}.tile");
                            try
                            {
                                Directory.CreateDirectory(Path.GetDirectoryName(localPath));
                                tile.Image.Save(localPath);
                                Debug.WriteLine($"saved {localPath}");
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"Unable to save tile image {localPath}. Reason: {ex.Message}");
                            }
                        }

                        // add tile to the memory cache
                        if (tile.Image != null)
                        {
                            _Cache.Add(tile);
                        }
                    }
                }
                _WorkerWaitHandle.WaitOne();
            }
        }

        public Tile GetTile(int x, int y, int z, bool fromCacheOnly = false)
        {
            try
            {
                Tile tile;

                // try to get tile from memory cache
                tile = _Cache.FirstOrDefault(t => t.Z == z && t.X == x && t.Y == y);
                if (tile != null)
                {
                    return tile;
                }

                // try to get tile from file system
                string localPath = Path.Combine(CacheFolder, $"{z}", $"{x}", $"{y}.tile");
                if (File.Exists(localPath))
                {
                    var fileInfo = new FileInfo(localPath);
                    if (fileInfo.Length > 0)
                    {
                        Image image = Image.FromFile(localPath);
                        tile = new Tile(image, x, y, z);
                        _Cache.Add(tile);
                        return tile;
                    }
                }

                //request tile from the server
                if (!fromCacheOnly)
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

        public GeoPnt TileToWorldPos(double x, double y, int z)
        {
            GeoPnt g = new GeoPnt();
            double z1 = 1 << z;
            double n = Math.PI - (2 * Math.PI * y / z1);
            g.Longitude = (float)((x / z1 * 360.0) - 180.0);
            g.Latitude = (float)(180.0 / Math.PI * Math.Atan(Math.Sinh(n)));
            return g;
        }

        /// <inheritdoc />
        public PointF WorldToTilePos(GeoPnt g, int z)
        {
            var p = new PointF();
            double z1 = 1 << z;
            p.X = (float)((g.Longitude + 180.0) / 360.0 * z1);
            p.Y = (float)((1.0 - Math.Log(Math.Tan(g.Latitude * Math.PI / 180.0) + 1.0 / Math.Cos(g.Latitude * Math.PI / 180.0)) / Math.PI) / 2.0 * z1);
            return p;
        }

        public PointF ToTilePos(double Longitude, double Latitude, int z)
        {
            var p = new PointF();
            double z1 = 1 << z;
            p.X = (float)((Longitude + 180.0) / 360.0 * z1);
            p.Y = (float)((1.0 - Math.Log(Math.Tan(Latitude * Math.PI / 180.0) + 1.0 / Math.Cos(Latitude * Math.PI / 180.0)) / Math.PI) / 2.0 * z1);
            return p;
        }

        public PointF LatLongToTileXY(double latitude, double longitude, int zoom)
        {
            // Clip latitude to the valid range for Mercator projection
            //latitude = Math.Max(Math.Min(latitude, MaxLatitude), MinLatitude);
            var p = new PointF();

            // Convert to pixel coordinates (global)
            double sinLatitude = Math.Sin(latitude * Math.PI / 180.0);
            double pixelX = ((longitude + 180.0) / 360.0) * 256 * Math.Pow(2, zoom);
            double pixelY = (0.5 - Math.Log((1 + sinLatitude) / (1 - sinLatitude)) / (4 * Math.PI)) * 256 * Math.Pow(2, zoom);

            // Convert pixel coordinates to tile coordinates by integer division
            p.X = (float)(pixelX / 256);
            p.Y = (float)(pixelY / 256);
            return p;
        }

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

        }
    }

    public struct GeoPnt
    {
        public static GeoPnt Empty = new GeoPnt();

        /// <summary>
        /// Longitude of the point, in degrees, from 0 to ±180, positive East, negative West. 0 is a point on prime meridian.
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        /// Latitude of the point, in degrees, from +90 (North pole) to -90 (South Pole). 0 is a point on equator.
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// Creates new instance of <see cref="GeoPnt"/> and initializes it with longitude and latitude values.
        /// </summary>
        /// <param name="longitude">Longitude of the point, in degrees, from 0 to ±180, positive East, negative West. 0 is a point on prime meridian.</param>
        /// <param name="latitude">Latitude of the point, in degrees, from +90 (North pole) to -90 (South Pole). 0 is a point on equator.</param>
        public GeoPnt(float longitude, float latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
