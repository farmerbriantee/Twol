using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace Twol.Mapping
{
    /// <summary>
    /// Provides map tiles from the ESRI World Imagery tile server.
    /// </summary>
    /// <remarks>
    /// This class retrieves satellite imagery tiles based on their x and y coordinates and zoom level.
    /// Uses the official ESRI ArcGIS Online World Imagery service which provides high-resolution
    /// satellite and aerial imagery. Configures SSL/TLS settings for secure HTTPS connections.
    /// </remarks>
    public class TileServer : ITileProvider
    {
        private bool _disposed;

        /// <summary>
        /// Gets the display name of this tile provider.
        /// </summary>
        public string Name => "ESRI World Imagery";

        /// <summary>
        /// Gets whether this provider is currently available.
        /// </summary>
        public bool IsAvailable => true;

        /// <summary>
        /// Gets whether this provider requires internet connectivity.
        /// </summary>
        public bool RequiresInternet => true;

        /// <summary>
        /// Initializes a new instance of the <see cref="TileServer"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor configures the default connection settings for the application,
        /// including the maximum number of concurrent connections, certificate validation behavior,
        /// and supported security protocols.
        /// </remarks>
        public TileServer()
        {
            ServicePointManager.DefaultConnectionLimit = 10;
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertificates);
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)12288 | SecurityProtocolType.Tls12;
        }

        /// <summary>
        /// Gets a tile image by its coordinates and zoom level.
        /// </summary>
        /// <param name="x">X-coordinate of the tile in the tile grid.</param>
        /// <param name="y">Y-coordinate of the tile in the tile grid.</param>
        /// <param name="z">Zoom level.</param>
        /// <returns>The tile image, or null if the tile is not available.</returns>
        public Image GetTile(int x, int y, int z)
        {
            return GetImageFromTileOnServer(x, y, z);
        }

        /// <summary>
        /// Gets tile image by X and Y coordinates of the tile and zoom level Z.
        /// </summary>
        /// <param name="x">X-coordinate of the tile.</param>
        /// <param name="y">Y-coordinate of the tile.</param>
        /// <param name="z">Zoom level.</param>
        /// <returns>The downloaded tile image.</returns>
        public Image GetImageFromTileOnServer(int x, int y, int z)
        {
            try
            {
                Uri uri = GetTileUri(x, y, z);
                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.UserAgent = "Demo App v1.0 example@example.com";
                using (var response = request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                {
                    return Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to download tile.\n{ex.Message}");
            }
        }

        /// <summary>
        /// Generates a URI for retrieving a map tile from ESRI World Imagery.
        /// </summary>
        /// <remarks>
        /// Uses the official ESRI ArcGIS Online World Imagery MapServer endpoint.
        /// URL format: tile/{z}/{y}/{x} (note: y before x, different from Google).
        /// </remarks>
        /// <param name="x">The x-coordinate of the tile in the tile grid.</param>
        /// <param name="y">The y-coordinate of the tile in the tile grid.</param>
        /// <param name="z">The zoom level of the tile.</param>
        /// <returns>A <see cref="Uri"/> representing the location of the requested map tile.</returns>
        private Uri GetTileUri(int x, int y, int z)
        {
            return new Uri($"https://server.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{z}/{y}/{x}");
        }

        /// <summary>
        /// Accepts all SSL/TLS certificates regardless of validation results.
        /// </summary>
        private bool AcceptAllCertificates(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        /// <summary>
        /// Releases resources used by this tile provider.
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }
    }
}
