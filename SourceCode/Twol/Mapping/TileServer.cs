using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace Twol.Mapping
{
    /// <summary>
    /// Request tiles from Google Maps tile server
    /// </summary>
    public class TileServer
    {
        // Add a static Random instance to fix CS0120
        private static readonly Random Random = new Random();

        /// <summary>
        /// Gets tile image by X and Y coordinates of the tile and zoom level Z.
        /// </summary>
        /// <param name="x">X-coordinate of the tile.</param>
        /// <param name="y">Y-coordinate of the tile.</param>
        /// <param name="z">Zoom level</param>
        /// <returns></returns>
        public Image GetImageFromTileOnServer(int x, int y, int z)
        {
            try
            {
                Uri uri = GetTileUri(x, y, z);
                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.UserAgent = "Demo App v1.0 example@example.com";
                // TODO: make customizable
                //request.Timeout = 5 * 1000;
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

        private Uri GetTileUri(int x, int y, int z)
        {
            int ind = Random.Next(0, 4);
            return new Uri($"http://mt{ind}.google.com/vt/lyrs=s&hl=en&x={x}&y={y}&z={z}");
        }

        /// <summary>
        /// Base constructor for initializing <see cref="WebTileServer"/>.
        /// </summary>
        public TileServer()
        {
            ServicePointManager.DefaultConnectionLimit = 10;
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertificates);
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)12288 | SecurityProtocolType.Tls12;
        }

        /// <summary>
        /// Function to handle accepting HTTPs certificates 
        /// </summary>
        private bool AcceptAllCertificates(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
