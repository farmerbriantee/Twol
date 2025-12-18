using System;
using System.Drawing;

namespace Twol.Mapping
{
    /// <summary>
    /// Interface for tile providers that supply map imagery.
    /// Implementations can provide tiles from online sources (Google, ESRI) or local files (GeoTIFF).
    /// </summary>
    public interface ITileProvider : IDisposable
    {
        /// <summary>
        /// Gets the display name of this tile provider.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets whether this provider is currently available and ready to serve tiles.
        /// </summary>
        bool IsAvailable { get; }

        /// <summary>
        /// Gets whether this provider requires internet connectivity.
        /// </summary>
        bool RequiresInternet { get; }

        /// <summary>
        /// Gets a tile image by its coordinates and zoom level.
        /// </summary>
        /// <param name="x">X-coordinate of the tile in the tile grid.</param>
        /// <param name="y">Y-coordinate of the tile in the tile grid.</param>
        /// <param name="z">Zoom level.</param>
        /// <returns>The tile image, or null if the tile is not available.</returns>
        Image GetTile(int x, int y, int z);
    }
}
