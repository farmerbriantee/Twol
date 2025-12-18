using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using MaxRev.Gdal.Core;
using OSGeo.GDAL;

namespace Twol.Mapping
{
    /// <summary>
    /// Provides map tiles from a local GeoTIFF file using GDAL.
    /// </summary>
    public class GeoTiffProvider : ITileProvider
    {
        private const int TILE_SIZE = 256;

        private readonly string _geoTiffPath;
        private Dataset _dataset;
        private double[] _geoTransform;
        private double[] _inverseGeoTransform;
        private int _rasterWidth;
        private int _rasterHeight;
        private bool _disposed;

        /// <summary>
        /// Gets the display name of this tile provider.
        /// </summary>
        public string Name => "Local GeoTIFF";

        /// <summary>
        /// Gets whether this provider is currently available.
        /// </summary>
        public bool IsAvailable => _dataset != null;

        /// <summary>
        /// Gets whether this provider requires internet connectivity.
        /// </summary>
        public bool RequiresInternet => false;

        /// <summary>
        /// Gets the path to the GeoTIFF file.
        /// </summary>
        public string FilePath => _geoTiffPath;

        /// <summary>
        /// Gets the bounding box of the GeoTIFF in WGS84 coordinates.
        /// </summary>
        public (double MinLon, double MinLat, double MaxLon, double MaxLat) Bounds { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoTiffProvider"/> class.
        /// </summary>
        /// <param name="geoTiffPath">Path to the GeoTIFF file.</param>
        public GeoTiffProvider(string geoTiffPath)
        {
            _geoTiffPath = geoTiffPath;

            if (!File.Exists(geoTiffPath))
            {
                throw new FileNotFoundException("GeoTIFF file not found.", geoTiffPath);
            }

            InitializeGdal();
            LoadGeoTiff();
        }

        private void InitializeGdal()
        {
            ESRIDownloader.InitializeGdal();
        }

        private void LoadGeoTiff()
        {
            _dataset = Gdal.Open(_geoTiffPath, Access.GA_ReadOnly);
            if (_dataset == null)
            {
                throw new Exception($"Failed to open GeoTIFF: {_geoTiffPath}");
            }

            _rasterWidth = _dataset.RasterXSize;
            _rasterHeight = _dataset.RasterYSize;

            _geoTransform = new double[6];
            _dataset.GetGeoTransform(_geoTransform);

            // Calculate inverse geotransform for coordinate conversion
            _inverseGeoTransform = new double[6];
            Gdal.InvGeoTransform(_geoTransform, _inverseGeoTransform);

            // Calculate bounds
            double minLon = _geoTransform[0];
            double maxLon = _geoTransform[0] + _rasterWidth * _geoTransform[1];
            double maxLat = _geoTransform[3];
            double minLat = _geoTransform[3] + _rasterHeight * _geoTransform[5];

            Bounds = (minLon, minLat, maxLon, maxLat);
        }

        /// <summary>
        /// Gets a tile image by its coordinates and zoom level.
        /// </summary>
        /// <param name="x">X-coordinate of the tile in the tile grid.</param>
        /// <param name="y">Y-coordinate of the tile in the tile grid.</param>
        /// <param name="z">Zoom level.</param>
        /// <returns>The tile image, or null if the tile is outside the GeoTIFF bounds.</returns>
        public Image GetTile(int x, int y, int z)
        {
            if (_dataset == null)
                return null;

            try
            {
                // Calculate the geographic bounds of this tile
                double tileWest = ESRIDownloader.TileXToLon(x, z);
                double tileEast = ESRIDownloader.TileXToLon(x + 1, z);
                double tileNorth = ESRIDownloader.TileYToLat(y, z);
                double tileSouth = ESRIDownloader.TileYToLat(y + 1, z);

                // Check if tile intersects with GeoTIFF bounds
                if (tileEast < Bounds.MinLon || tileWest > Bounds.MaxLon ||
                    tileSouth > Bounds.MaxLat || tileNorth < Bounds.MinLat)
                {
                    return null;
                }

                // Calculate the intersection between tile bounds and GeoTIFF bounds
                double intersectWest = Math.Max(tileWest, Bounds.MinLon);
                double intersectEast = Math.Min(tileEast, Bounds.MaxLon);
                double intersectNorth = Math.Min(tileNorth, Bounds.MaxLat);
                double intersectSouth = Math.Max(tileSouth, Bounds.MinLat);

                // Convert intersection to pixel coordinates in the GeoTIFF
                GeoToPixel(intersectWest, intersectNorth, out double srcXMin, out double srcYMin);
                GeoToPixel(intersectEast, intersectSouth, out double srcXMax, out double srcYMax);

                // Ensure proper ordering
                if (srcXMin > srcXMax) { var t = srcXMin; srcXMin = srcXMax; srcXMax = t; }
                if (srcYMin > srcYMax) { var t = srcYMin; srcYMin = srcYMax; srcYMax = t; }

                // Clamp to raster bounds
                int readX = Math.Max(0, (int)Math.Floor(srcXMin));
                int readY = Math.Max(0, (int)Math.Floor(srcYMin));
                int readWidth = Math.Min(_rasterWidth - readX, (int)Math.Ceiling(srcXMax) - readX);
                int readHeight = Math.Min(_rasterHeight - readY, (int)Math.Ceiling(srcYMax) - readY);

                if (readWidth <= 0 || readHeight <= 0)
                    return null;

                // Calculate where in the 256x256 tile the GeoTIFF data should be placed
                double tileWidthGeo = tileEast - tileWest;
                double tileHeightGeo = tileNorth - tileSouth;

                int destX = (int)Math.Round((intersectWest - tileWest) / tileWidthGeo * TILE_SIZE);
                int destY = (int)Math.Round((tileNorth - intersectNorth) / tileHeightGeo * TILE_SIZE);
                int destWidth = (int)Math.Round((intersectEast - intersectWest) / tileWidthGeo * TILE_SIZE);
                int destHeight = (int)Math.Round((intersectNorth - intersectSouth) / tileHeightGeo * TILE_SIZE);

                // Clamp destination to tile bounds
                destX = Math.Max(0, Math.Min(TILE_SIZE - 1, destX));
                destY = Math.Max(0, Math.Min(TILE_SIZE - 1, destY));
                destWidth = Math.Max(1, Math.Min(TILE_SIZE - destX, destWidth));
                destHeight = Math.Max(1, Math.Min(TILE_SIZE - destY, destHeight));

                // Read the data from the GeoTIFF and place it correctly in the tile
                return ReadRegionAsTile(readX, readY, readWidth, readHeight,
                    destX, destY, destWidth, destHeight);
            }
            catch
            {
                return null;
            }
        }

        private Image ReadRegionAsTile(int srcX, int srcY, int srcWidth, int srcHeight,
            int destX, int destY, int destWidth, int destHeight)
        {
            // Create a bitmap with transparency support for partial tiles
            var bitmap = new Bitmap(TILE_SIZE, TILE_SIZE, PixelFormat.Format32bppArgb);

            try
            {
                int bandCount = Math.Min(_dataset.RasterCount, 3);
                if (bandCount == 0)
                {
                    bitmap.Dispose();
                    return null;
                }

                // Read each band into the destination size
                byte[][] bandData = new byte[3][];
                for (int b = 0; b < 3; b++)
                {
                    bandData[b] = new byte[destWidth * destHeight];

                    int bandIndex = b < bandCount ? b + 1 : 1; // Use first band if not enough bands
                    var band = _dataset.GetRasterBand(bandIndex);

                    // Read from source region and resample to destination size
                    band.ReadRaster(srcX, srcY, srcWidth, srcHeight,
                        bandData[b], destWidth, destHeight, 0, 0);
                }

                // Lock the bitmap for writing
                var bmpData = bitmap.LockBits(
                    new Rectangle(0, 0, TILE_SIZE, TILE_SIZE),
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format32bppArgb);

                try
                {
                    int stride = bmpData.Stride;
                    byte[] pixels = new byte[stride * TILE_SIZE];

                    // Initialize with transparent black (areas outside GeoTIFF)
                    // Alpha = 0 means transparent
                    for (int i = 0; i < pixels.Length; i += 4)
                    {
                        pixels[i] = 0;     // Blue
                        pixels[i + 1] = 0; // Green
                        pixels[i + 2] = 0; // Red
                        pixels[i + 3] = 0; // Alpha (transparent)
                    }

                    // Copy the GeoTIFF data to the correct position in the tile
                    for (int row = 0; row < destHeight; row++)
                    {
                        for (int col = 0; col < destWidth; col++)
                        {
                            int srcIdx = row * destWidth + col;
                            int tileRow = destY + row;
                            int tileCol = destX + col;

                            if (tileRow >= 0 && tileRow < TILE_SIZE && tileCol >= 0 && tileCol < TILE_SIZE)
                            {
                                int dstIdx = tileRow * stride + tileCol * 4;

                                // BGRA format for 32bpp Bitmap
                                pixels[dstIdx] = bandData[2][srcIdx];     // Blue
                                pixels[dstIdx + 1] = bandData[1][srcIdx]; // Green
                                pixels[dstIdx + 2] = bandData[0][srcIdx]; // Red
                                pixels[dstIdx + 3] = 255;                  // Alpha (opaque)
                            }
                        }
                    }

                    Marshal.Copy(pixels, 0, bmpData.Scan0, pixels.Length);
                }
                finally
                {
                    bitmap.UnlockBits(bmpData);
                }

                return bitmap;
            }
            catch
            {
                bitmap.Dispose();
                return null;
            }
        }

        /// <summary>
        /// Converts geographic coordinates (longitude, latitude) to pixel coordinates.
        /// </summary>
        private void GeoToPixel(double lon, double lat, out double pixelX, out double pixelY)
        {
            pixelX = _inverseGeoTransform[0] + _inverseGeoTransform[1] * lon + _inverseGeoTransform[2] * lat;
            pixelY = _inverseGeoTransform[3] + _inverseGeoTransform[4] * lon + _inverseGeoTransform[5] * lat;
        }

        /// <summary>
        /// Converts pixel coordinates to geographic coordinates (longitude, latitude).
        /// </summary>
        private void PixelToGeo(double pixelX, double pixelY, out double lon, out double lat)
        {
            lon = _geoTransform[0] + _geoTransform[1] * pixelX + _geoTransform[2] * pixelY;
            lat = _geoTransform[3] + _geoTransform[4] * pixelX + _geoTransform[5] * pixelY;
        }

        /// <summary>
        /// Checks if the given geographic coordinates are within the GeoTIFF bounds.
        /// </summary>
        public bool ContainsPoint(double lon, double lat)
        {
            return lon >= Bounds.MinLon && lon <= Bounds.MaxLon &&
                   lat >= Bounds.MinLat && lat <= Bounds.MaxLat;
        }

        /// <summary>
        /// Releases resources used by this tile provider.
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                _dataset?.Dispose();
                _dataset = null;
                _disposed = true;
            }
        }
    }
}
