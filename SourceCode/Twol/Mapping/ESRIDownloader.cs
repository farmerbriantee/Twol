using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MaxRev.Gdal.Core;
using OSGeo.GDAL;

namespace Twol.Mapping
{
    /// <summary>
    /// Downloads ESRI World Imagery tiles and assembles them into a GeoTIFF file.
    /// </summary>
    public class ESRIDownloader
    {
        private const string ESRI_URL_TEMPLATE = "https://server.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{0}/{1}/{2}";
        private const int TILE_SIZE = 256;
        private const int MAX_RETRIES = 3;
        private const int RETRY_DELAY_MS = 1000;

        private static bool _gdalInitialized;
        private static readonly object _initLock = new object();

        /// <summary>
        /// Event raised to report download progress.
        /// </summary>
        public event EventHandler<DownloadProgressEventArgs> ProgressChanged;

        /// <summary>
        /// Initializes GDAL library. Must be called once before using GDAL functions.
        /// </summary>
        public static void InitializeGdal()
        {
            lock (_initLock)
            {
                if (!_gdalInitialized)
                {
                    GdalBase.ConfigureAll();
                    Gdal.AllRegister();
                    _gdalInitialized = true;
                }
            }
        }

        /// <summary>
        /// Downloads ESRI imagery for a specified bounding box and saves it as a GeoTIFF.
        /// </summary>
        /// <param name="minLon">Minimum longitude (west).</param>
        /// <param name="minLat">Minimum latitude (south).</param>
        /// <param name="maxLon">Maximum longitude (east).</param>
        /// <param name="maxLat">Maximum latitude (north).</param>
        /// <param name="outputPath">Path for the output GeoTIFF file.</param>
        /// <param name="zoomLevel">Zoom level (typically 17-19 for field imagery).</param>
        /// <param name="cancellationToken">Cancellation token to abort the operation.</param>
        /// <returns>True if successful, false otherwise.</returns>
        public async Task<bool> DownloadFieldImageryAsync(
            double minLon, double minLat,
            double maxLon, double maxLat,
            string outputPath,
            int zoomLevel = 18,
            CancellationToken cancellationToken = default)
        {
            InitializeGdal();

            // Calculate tile coordinates
            int minTileX = LonToTileX(minLon, zoomLevel);
            int maxTileX = LonToTileX(maxLon, zoomLevel);
            int minTileY = LatToTileY(maxLat, zoomLevel); // Note: Y is inverted
            int maxTileY = LatToTileY(minLat, zoomLevel);

            int tilesX = maxTileX - minTileX + 1;
            int tilesY = maxTileY - minTileY + 1;
            int totalTiles = tilesX * tilesY;

            int imageWidth = tilesX * TILE_SIZE;
            int imageHeight = tilesY * TILE_SIZE;

            // Create the assembled image
            using (var assembledImage = new Bitmap(imageWidth, imageHeight, PixelFormat.Format24bppRgb))
            using (var graphics = Graphics.FromImage(assembledImage))
            {
                graphics.Clear(Color.Black);

                int tilesDownloaded = 0;

                for (int ty = minTileY; ty <= maxTileY; ty++)
                {
                    for (int tx = minTileX; tx <= maxTileX; tx++)
                    {
                        if (cancellationToken.IsCancellationRequested)
                            return false;

                        int pixelX = (tx - minTileX) * TILE_SIZE;
                        int pixelY = (ty - minTileY) * TILE_SIZE;

                        var tileImage = await DownloadTileWithRetryAsync(tx, ty, zoomLevel, cancellationToken);
                        if (tileImage != null)
                        {
                            graphics.DrawImage(tileImage, pixelX, pixelY, TILE_SIZE, TILE_SIZE);
                            tileImage.Dispose();
                        }

                        tilesDownloaded++;
                        OnProgressChanged(tilesDownloaded, totalTiles, $"Downloading tile {tilesDownloaded}/{totalTiles}");
                    }
                }

                // Calculate georeferencing bounds
                double westLon = TileXToLon(minTileX, zoomLevel);
                double eastLon = TileXToLon(maxTileX + 1, zoomLevel);
                double northLat = TileYToLat(minTileY, zoomLevel);
                double southLat = TileYToLat(maxTileY + 1, zoomLevel);

                OnProgressChanged(totalTiles, totalTiles, "Creating GeoTIFF...");

                // Save as GeoTIFF
                return SaveAsGeoTiff(assembledImage, outputPath, westLon, northLat, eastLon, southLat);
            }
        }

        /// <summary>
        /// Downloads a single tile with retry logic.
        /// </summary>
        private async Task<Image> DownloadTileWithRetryAsync(int x, int y, int z, CancellationToken cancellationToken)
        {
            for (int attempt = 0; attempt < MAX_RETRIES; attempt++)
            {
                try
                {
                    if (cancellationToken.IsCancellationRequested)
                        return null;

                    string url = string.Format(ESRI_URL_TEMPLATE, z, y, x);
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.UserAgent = "Twol/1.0 (GPS Guidance System)";
                    request.Timeout = 30000;

                    using (var response = await Task.Factory.FromAsync(
                        request.BeginGetResponse,
                        request.EndGetResponse,
                        null))
                    using (var stream = response.GetResponseStream())
                    using (var memoryStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memoryStream);
                        memoryStream.Position = 0;
                        return Image.FromStream(memoryStream);
                    }
                }
                catch (Exception)
                {
                    if (attempt < MAX_RETRIES - 1)
                    {
                        await Task.Delay(RETRY_DELAY_MS * (attempt + 1), cancellationToken);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Saves the assembled image as a georeferenced GeoTIFF.
        /// </summary>
        private bool SaveAsGeoTiff(Bitmap image, string outputPath, double westLon, double northLat, double eastLon, double southLat)
        {
            try
            {
                // Ensure output directory exists
                string directory = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Save as temporary PNG first
                string tempPath = Path.ChangeExtension(outputPath, ".tmp.png");
                image.Save(tempPath, ImageFormat.Png);

                // Open the PNG with GDAL
                using (var srcDataset = Gdal.Open(tempPath, Access.GA_ReadOnly))
                {
                    if (srcDataset == null)
                    {
                        File.Delete(tempPath);
                        return false;
                    }

                    // Create the GeoTIFF driver
                    var driver = Gdal.GetDriverByName("GTiff");
                    if (driver == null)
                    {
                        File.Delete(tempPath);
                        return false;
                    }

                    // Create output GeoTIFF with compression
                    string[] createOptions = new string[]
                    {
                        "COMPRESS=JPEG",
                        "JPEG_QUALITY=85",
                        "TILED=YES",
                        "BLOCKXSIZE=256",
                        "BLOCKYSIZE=256"
                    };

                    using (var dstDataset = driver.CreateCopy(outputPath, srcDataset, 0, createOptions, null, null))
                    {
                        if (dstDataset == null)
                        {
                            File.Delete(tempPath);
                            return false;
                        }

                        // Set the geotransform (georeferencing)
                        double pixelWidth = (eastLon - westLon) / image.Width;
                        double pixelHeight = (southLat - northLat) / image.Height; // Negative because Y increases downward

                        double[] geoTransform = new double[6]
                        {
                            westLon,      // Top-left X (longitude)
                            pixelWidth,   // Pixel width (in degrees)
                            0,            // Rotation (0 for north-up)
                            northLat,     // Top-left Y (latitude)
                            0,            // Rotation (0 for north-up)
                            pixelHeight   // Pixel height (negative for north-up)
                        };
                        dstDataset.SetGeoTransform(geoTransform);

                        // Set the spatial reference (WGS84)
                        var srs = new OSGeo.OSR.SpatialReference("");
                        srs.SetWellKnownGeogCS("WGS84");
                        string wkt;
                        srs.ExportToWkt(out wkt, null);
                        dstDataset.SetProjection(wkt);

                        dstDataset.FlushCache();
                    }
                }

                // Clean up temporary file
                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Estimates the download size in bytes for the given bounds and zoom level.
        /// </summary>
        public long EstimateDownloadSize(double minLon, double minLat, double maxLon, double maxLat, int zoomLevel)
        {
            int minTileX = LonToTileX(minLon, zoomLevel);
            int maxTileX = LonToTileX(maxLon, zoomLevel);
            int minTileY = LatToTileY(maxLat, zoomLevel);
            int maxTileY = LatToTileY(minLat, zoomLevel);

            int tilesX = maxTileX - minTileX + 1;
            int tilesY = maxTileY - minTileY + 1;
            int totalTiles = tilesX * tilesY;

            // Estimate ~30KB per JPEG tile on average
            return totalTiles * 30 * 1024;
        }

        /// <summary>
        /// Gets the number of tiles that will be downloaded for the given bounds.
        /// </summary>
        public int GetTileCount(double minLon, double minLat, double maxLon, double maxLat, int zoomLevel)
        {
            int minTileX = LonToTileX(minLon, zoomLevel);
            int maxTileX = LonToTileX(maxLon, zoomLevel);
            int minTileY = LatToTileY(maxLat, zoomLevel);
            int maxTileY = LatToTileY(minLat, zoomLevel);

            return (maxTileX - minTileX + 1) * (maxTileY - minTileY + 1);
        }

        private void OnProgressChanged(int current, int total, string message)
        {
            ProgressChanged?.Invoke(this, new DownloadProgressEventArgs(current, total, message));
        }

        #region Tile Coordinate Conversion

        /// <summary>
        /// Converts longitude to tile X coordinate.
        /// </summary>
        public static int LonToTileX(double lon, int zoom)
        {
            return (int)Math.Floor((lon + 180.0) / 360.0 * (1 << zoom));
        }

        /// <summary>
        /// Converts latitude to tile Y coordinate.
        /// </summary>
        public static int LatToTileY(double lat, int zoom)
        {
            double latRad = lat * Math.PI / 180.0;
            return (int)Math.Floor((1.0 - Math.Log(Math.Tan(latRad) + 1.0 / Math.Cos(latRad)) / Math.PI) / 2.0 * (1 << zoom));
        }

        /// <summary>
        /// Converts tile X coordinate to longitude (west edge of tile).
        /// </summary>
        public static double TileXToLon(int x, int zoom)
        {
            return x / (double)(1 << zoom) * 360.0 - 180.0;
        }

        /// <summary>
        /// Converts tile Y coordinate to latitude (north edge of tile).
        /// </summary>
        public static double TileYToLat(int y, int zoom)
        {
            double n = Math.PI - 2.0 * Math.PI * y / (1 << zoom);
            return 180.0 / Math.PI * Math.Atan(0.5 * (Math.Exp(n) - Math.Exp(-n)));
        }

        #endregion
    }

    /// <summary>
    /// Event arguments for download progress updates.
    /// </summary>
    public class DownloadProgressEventArgs : EventArgs
    {
        public int CurrentTile { get; }
        public int TotalTiles { get; }
        public string Message { get; }
        public int ProgressPercent => TotalTiles > 0 ? (CurrentTile * 100) / TotalTiles : 0;

        public DownloadProgressEventArgs(int currentTile, int totalTiles, string message)
        {
            CurrentTile = currentTile;
            TotalTiles = totalTiles;
            Message = message;
        }
    }
}
