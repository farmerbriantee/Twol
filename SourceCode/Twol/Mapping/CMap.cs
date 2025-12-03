using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
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
        public int _ZoomLevel = 15;

        /// <summary>
        /// Map zoom level.
        /// </summary>
        [Description("Map zoom level"), Category("Behavior")]
        public int ZoomLevel
        {
            get => _ZoomLevel;
            set
            {
                if (value < 0 || value > 19)
                    throw new ArgumentException($"{value} is an incorrect value for {nameof(ZoomLevel)} property. Value should be in range from 0 to 19.");

                _ZoomLevel = value;
                //SetZoomLevel(value, new Point(Width / 2, Height / 2));
                //CenterChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Backing field for <see cref="CacheFolder"/> property.
        /// </summary>
        public string CacheFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TWOL", "GoogleMapsSatelliteTileServer");

        /// <summary>
        /// Gets or sets minimal zoom level.
        /// </summary>
        public int MinZoomLevel = 12;

        /// <summary>
        /// Backing field for <see cref="MaxZoomLevel"/> property.
        /// </summary>
        public int MaxZoomLevel = 19;


        /// <summary>
        /// Sets zoom level with specifying central point to zoom in/out.
        /// </summary>
        /// <param name="z">Zoom level to be set.</param>
        /// <param name="p">Central point to zoom in/out.</param>
        
        private void SetZoomLevel(int z, Point p)
        {
            //int max = Layers.Any() ? Math.Min(MaxZoomLevel, Layers.Min(lay => lay.TileServer.MaxZoomLevel)) : MaxZoomLevel;
            //int min = Layers.Any() ? Math.Max(MinZoomLevel, Layers.Max(lay => lay.TileServer.MinZoomLevel)) : MinZoomLevel;

            //if (z < min) z = min;
            //if (z > max) z = max;

            //if (z != _ZoomLevel)
            //{
            //    double factor = Math.Pow(2, z - _ZoomLevel);
            //    _ZoomLevel = z;

            //    foreach (var layer in Layers)
            //    {
            //        layer.Offset.X = (int)((layer.Offset.X - p.X) * factor) + p.X;
            //        layer.Offset.Y = (int)((layer.Offset.Y - p.Y) * factor) + p.Y;
            //        layer.Offset.X = (int)(layer.Offset.X % FullMapSizeInPixels);
            //    }

            //    UpdateOffsets();

            //    //ZoomLevelChaged?.Invoke(this, EventArgs.Empty);
            //}
        }

        /// <summary>
        /// Gets tile image by X and Y indices and zoom level.
        /// </summary>
        /// <param name="x">X-index of the tile.</param>
        /// <param name="y">Y-index of the tile.</param>
        /// <param name="z">Zoom level.</param>
        /// <param name="fromCacheOnly">Flag indicating the tile can be fetched from cache only (server request is not allowed).</param>
        /// <returns><see cref="Tile"/> instance.</returns>
        /// 

        
        TileServer tileServer = new TileServer();

        public Tile GetTile(int x, int y, int z, bool fromCacheOnly = true)
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

                // request tile from the server 
                //if (!fromCacheOnly)
                //{
                //    //RequestTile(layer, x, y, z);
                //}

                tile = new Tile(tileServer.GetTile(x, y, z), x, y, z);
                tile.Used = true;

                localPath = Path.Combine(CacheFolder, $"{z}", $"{x}", $"{y}.tile");
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

                // add tile to the memory cache
                if (tile.Image != null || tile.ErrorMessage != null)
                {
                    _Cache.Add(tile);
                    return tile;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Does a tile request to the tile server
        /// </summary>
        /// <param name="x">X-index of the tile to be requested.</param>
        /// <param name="y">Y-index of the tile to be requested.</param>
        /// <param name="z">Zoom level</param>
        //private void RequestTile(Layer layer, int x, int y, int z)
        //{
        //    // Check the tile is already requested
        //    string tileServer = layer.TileServer.GetType().Name;
        //    if (!_RequestPool.Any(t => t.TileServer == tileServer && t.Z == z && t.X == x && t.Y == y))
        //    {
        //        _RequestPool.Add(new Tile(x, y, z, tileServer));
        //        _WorkerWaitHandle.Set();
        //    }
        //}

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
        }

        private ITileServer _webTileServer;
    }

    public class Layer
    {
        public ITileServer TileServer { get; set; }

        public uint ZIndex { get; set; }

        internal Point Offset = new Point();

        public float Opacity { get; set; } = 1;
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

    public class Tile
    {
        /// <summary>
        /// X-index of the tile image
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Y-index of the tile image
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Zoom level of the tile image
        /// </summary>
        public int Z { get; }

        /// <summary>
        /// Tile server name
        /// </summary>
        public string TileServer { get; }

        /// <summary>
        /// Tile image
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// Error message that should be displayed if tile does not exist by some reason (incorrect X/Y indices, zoom level, server unavailable etc.).
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Flag indicating image recently used (requested to be drawn on the map).
        /// </summary>
        public bool Used { get; set; }

        /// <summary>
        /// Creates new tile with X/Y indices, zoom level, and tileServer name.
        /// </summary>
        /// <param name="x">X-index of the tile.</param>
        /// <param name="y">Y-index of the tile.</param>
        /// <param name="z">Zoom level.</param>
        /// <param name="tileServer">Tile server name.</param>
        public Tile(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Creates new tile with image, X/Y indices, zoom level, and tileServer name.
        /// </summary>
        /// <param name="image">Tile image</param>
        /// <param name="x">X-index of the tile.</param>
        /// <param name="y">Y-index of the tile.</param>
        /// <param name="z">Zoom level.</param>
        /// <param name="tileServer">Tile server name.</param>
        public Tile(Image image, int x, int y, int z)
        {
            Image = image;
            X = x;
            Y = y;
            Z = z;
        }



    }
}
