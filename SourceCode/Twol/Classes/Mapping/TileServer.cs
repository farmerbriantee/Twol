using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace Twol.Mapping
{
    /// <summary>
    /// Represents a tile server that provides map tiles from a Google Maps tile server.
    /// </summary>
    /// <remarks>The <see cref="TileServer"/> class is designed to retrieve map tiles based on their x and y
    /// coordinates and zoom level. It includes functionality for generating tile URIs, downloading tile images, and
    /// configuring connection settings. This class is intended for use in applications that require map data, such as
    /// GIS (Geographic Information Systems) or mapping tools.</remarks>
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

        /// <summary>
        /// Generates a URI for retrieving a map tile from a Google Maps tile server.
        /// </summary>
        /// <remarks>The method selects one of four possible tile servers (mt0, mt1, mt2, mt3) at random
        /// to distribute requests.</remarks>
        /// <param name="x">The x-coordinate of the tile in the tile grid.</param>
        /// <param name="y">The y-coordinate of the tile in the tile grid.</param>
        /// <param name="z">The zoom level of the tile, where higher values represent more detailed zoom levels.</param>
        /// <returns>A <see cref="Uri"/> representing the location of the requested map tile.</returns>
        private Uri GetTileUri(int x, int y, int z)
        {
            int ind = Random.Next(0, 4);
            return new Uri($"https://mt{ind}.google.com/vt/lyrs=s&hl=en&x={x}&y={y}&z={z}");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TileServer"/> class.
        /// </summary>
        /// <remarks>This constructor configures the default connection settings for the application,
        /// including the maximum number of concurrent connections and supported security protocols.</remarks>
        public TileServer()
        {
            ServicePointManager.DefaultConnectionLimit = 10;
            // Use system defaults for security protocols; .NET Framework 4.8.1 enables modern TLS by default.
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;
        }
    }
}
