//Please, if you use this, share the improvements

using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using Twol.Properties;

namespace Twol.Mapping
{
    /// <summary>
    /// Represents a point in a three-dimensional map with an associated status value.
    /// </summary>
    /// <remarks>The <c>mapPoint</c> class encapsulates X, Y, and Z coordinates along with a status indicator,
    /// which can be used to represent additional information about the point, such as its state or type within the map
    /// context.</remarks>
    public class mapPoint
    {
        // Fields (variables within the struct)
        public int X;
        public int Y;
        public int Z;
        public int Status;

        // Optional: A constructor to initialize the values easily
        public mapPoint(int x, int y, int z, int status = 0)
        {
            X = x;
            Y = y;
            Z = z;
            Status = status;
        }
    }

    /// <summary>
    /// Represents a world map that provides functionality for rendering, zooming, and managing map textures.
    /// </summary>
    /// <remarks>The <see cref="WorldTileMap"/> class is designed to handle the rendering of a 5x5 grid of map
    /// tiles using OpenGL. It supports dynamic zoom level adjustments based on camera settings and manages texture
    /// memory for efficient rendering. This class interacts with a GPS form (<see cref="FormGPS"/>) to retrieve
    /// positional and zoom data.</remarks>
    public class WorldTileMap
    {
        private readonly FormGPS mf;

        //cam z height to map zoom level mapping 2D
        private readonly (int threshold, int zoom)[] camToZoomMapping = new (int threshold, int zoom)[]
        {(530, 9), (400, 10), (320, 11), (225, 12), (150, 13), (100, 14), (68, 15), (46, 16), (28, 17), (16, 18)};

        //cam z height to map zoom level mapping 3D
        private readonly (int threshold, int zoom)[] camToZoomMapping3D = new (int threshold, int zoom)[]
        {(480, 9), (360, 10), (260, 11), (180, 12), (120, 13), (81, 14), (54, 15), (36, 16), (24, 17), (16, 18)};

        /// Represents a mapping of movement offsets corresponding to directional headings.
        private readonly (int dx, int dy)[] headingMapMoveOffsets = new (int dx, int dy)[]
        {
            (0, 1),  // sector 0: north
            (1, 1),  // sector 1: northeast
            (1, 0),  // sector 2: east
            (1, -1), // sector 3: southeast
            (0, -1), // sector 4: south
            (-1, -1),// sector 5: southwest
            (-1, 0), // sector 6: west
            (-1, 1)  // sector 7: northwest
        };

        /// Represents a mapping of movement offsets corresponding to directional headings.
        private readonly (int dx, int dy)[] headingMapMoveOffsets3D = new (int dx, int dy)[]
        {
            (0, 2),  // sector 0: north
            (2, 2),  // sector 1: northeast
            (2, 0),  // sector 2: east
            (2, -2), // sector 3: southeast
            (0, -2), // sector 4: south
            (-2, -2),// sector 5: southwest
            (-2, 0), // sector 6: west
            (-2, 2)  // sector 7: northwest
        };

        public double northingMax, eastingMax = GridSize;
        public double northingMin, eastingMin = -GridSize;

        public const double GridSize = 20000, gridRotation = 0.0;
        public int Count = 40;

        Tile tile;

        public double lastZoom = 0;

        private double offsetX = 0, offsetY = 0;

        //tile textures array for openGL
        public uint[] mapTexture;

        private int originToPivotInTilesX = 0, originToPivotInTilesY = 0;
        private int lastOriginToPivotInTilesX = 0, lastOriginToPivotInTilesY = 0;

        //time counter for updating tiles
        private double secondCounter = 0;

        public mapPoint[] tileSetArr = new mapPoint[49];
        public mapPoint[] tileGridArr = new mapPoint[49];

        PointF originTileXY_F = new PointF();

        int originTileX = 0;
        int originTileY = 0;
        bool isTileCoordsReset = true;

        double metersPerTile = 100;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldTileMap"/> class using the specified GPS form.
        /// </summary>
        /// <remarks>This constructor initializes the tile grid and tile set arrays to their default
        /// values. The provided <paramref name="_f"/> parameter is used to associate the tile map with a specific GPS
        /// form, which may be required for map operations.</remarks>
        /// <param name="_f">The <see cref="FormGPS"/> instance that provides GPS data and context for the tile map.</param>
        public WorldTileMap(FormGPS _f)
        {
            mf = _f;
            for (int i = 0; i < 49; i++)
            {
                //initial setting to default texture
                tileGridArr[i] = new mapPoint(-1, 0, 15);
                tileSetArr[i] = new mapPoint(-1, 0, 15);
            }
        }

        /// <summary>
        /// Updates the coordinates and status of all tiles in the 7x7 tile grid based on the current origin and pivot
        /// offsets.
        /// </summary>
        /// <remarks>This method recalculates the positions of each tile in the tile set and resets their
        /// status, ensuring the tile grid reflects the latest origin and pivot values. It is intended to be called
        /// whenever the origin or pivot changes to keep the tile grid in sync.</remarks>
        private void TileSetCoords()
        {
            int upperLeftTileX = originTileX - 3 + lastOriginToPivotInTilesX;
            int upperLeftTileY = originTileY - 3 - lastOriginToPivotInTilesY;
            {
                //7x7 tilemap
                for (int tx = 0; tx < 7; tx++)
                {
                    for (int ty = 0; ty < 7; ty++)
                    {
                        //reset the set and grid coords
                        tileSetArr[tx * 7 + ty] = new mapPoint(upperLeftTileX + tx, upperLeftTileY + ty, mf.map.ZoomLevel, 0);
                        tileGridArr[tx * 7 + ty].Status = 0;
                    }
                }
            }
            isTileCoordsReset = true;
        }

        /// <summary>
        /// Updates the map's zoom level and tile display to reflect the current camera zoom and pitch settings.
        /// </summary>
        /// <remarks>This method synchronizes the map's zoom level with the camera's zoom and pitch,
        /// recalculates tile origins and offsets as needed, and updates the visible map tiles accordingly. It also
        /// adjusts grid spacing based on the camera zoom level. The method is typically called when camera zoom or
        /// pitch changes, or when the map needs to respond to vehicle movement.</remarks>
        public void UpdateMapZoomFromCamZoom()
        {
            bool isUpdateTilesRequired = false;

            if (Settings.User.setDisplay_camPitch == 0)
            {
                foreach (var pair in camToZoomMapping)
                {
                    int threshold = pair.threshold;
                    int zoom = pair.zoom;

                    //based on  cam zoom set map zoom level
                    if ((int)Settings.User.setDisplay_camZoom > threshold)
                    {
                        if (lastZoom != threshold)
                        {
                            isUpdateTilesRequired = true;
                            lastZoom = threshold;

                            mf.map.ZoomLevel = zoom;

                            //mf.map.ZoomLevel = 18;
                            lastOriginToPivotInTilesX = 0;
                            lastOriginToPivotInTilesY = 0;
                        }
                        break; // first (highest) matching threshold wins
                    }
                }
            }
            else
            {
                foreach (var pair in camToZoomMapping3D)
                {
                    int threshold = pair.threshold;
                    int zoom = pair.zoom;

                    //based on  cam zoom set map zoom level
                    if ((int)Settings.User.setDisplay_camZoom > threshold)
                    {
                        if (lastZoom != threshold)
                        {
                            isUpdateTilesRequired = true;
                            lastZoom = threshold;

                            mf.map.ZoomLevel = zoom;

                            //mf.map.ZoomLevel = 18;
                            lastOriginToPivotInTilesX = 0;
                            lastOriginToPivotInTilesY = 0;
                        }
                        break; // first (highest) matching threshold wins
                    }
                }
            }

            //zoom level changed so update origin and offset
            if (isUpdateTilesRequired)
            {
                CalculateOriginAndOffset();
            }

            //based on position
            originToPivotInTilesX = (int)(mf.pivotAxlePos.easting / metersPerTile);
            originToPivotInTilesY = (int)(mf.pivotAxlePos.northing / metersPerTile);

            //only move map ahead if in 3D and not spinning
            if (Settings.User.setDisplay_camPitch != 0 && Math.Abs(mf.ahrs.angularVehicleVelocity) < 1)
                ApplyHeadingToTileOffset(ref originToPivotInTilesX, ref originToPivotInTilesY, glm.toDegrees(mf.fixHeading));

            //we have moved not zoomed so update tiles
            if (originToPivotInTilesX != lastOriginToPivotInTilesX || originToPivotInTilesY != lastOriginToPivotInTilesY)
            {
                isUpdateTilesRequired = true;
                lastOriginToPivotInTilesX = originToPivotInTilesX;
                lastOriginToPivotInTilesY = originToPivotInTilesY;
            }

            if (isUpdateTilesRequired)
            {
                TileSetCoords();
            }

            //check grid spacing based on cam zoom
            if (Settings.User.setDisplay_camZoom > 100) Count = 5;
            else if (Settings.User.setDisplay_camZoom > 80) Count = 10;
            else if (Settings.User.setDisplay_camZoom > 50) Count = 15;
            else if (Settings.User.setDisplay_camZoom > 20) Count = 30;
            else if (Settings.User.setDisplay_camZoom > 10) Count = 60;
            else Count = 120;
        }

        /// <summary>
        /// Updates the world map tile textures to reflect the current map state.
        /// </summary>
        /// <remarks>This method refreshes the 7x7 grid of world map tiles, updating their textures if the
        /// underlying map data has changed or if a refresh is triggered. It manages tile loading attempts and skips
        /// tiles that have failed to load repeatedly. This method should be called regularly to ensure the displayed
        /// map remains in sync with the latest data.</remarks>
        public void UpdateWorldMapTiles()
        {
            secondCounter += 1 / mf.gpsHz;
            //7x7 tilemap

            if (secondCounter > 0.35 || isTileCoordsReset)
            {
                // 7 x 7 tile map
                isTileCoordsReset = false;
                secondCounter = 0;
                for (int texNum = 0; texNum < 49; texNum++)
                {
                    //too many attempts to load tile so skip if status > 10
                    if ((tileGridArr[texNum].Status < 11) && (tileGridArr[texNum].X != tileSetArr[texNum].X || tileGridArr[texNum].Y != tileSetArr[texNum].Y || tileGridArr[texNum].Z != tileSetArr[texNum].Z))
                    {
                        tile = mf.map.GetTile(tileSetArr[texNum].X, tileSetArr[texNum].Y, tileSetArr[texNum].Z);

                        if (tile != null)
                        {
                            GL.BindTexture(TextureTarget.Texture2D, mapTexture[texNum]);
                            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

                            if (tile.Image is Bitmap bitmap)
                            {
                                var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                                // Keep memory in place, fill with new image 
                                GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, bitmapData.Width, bitmapData.Height, PixelFormat.Rgba, PixelType.UnsignedByte, bitmapData.Scan0);
                                bitmap.UnlockBits(bitmapData);

                                //loaded
                                tileGridArr[texNum].X = tileSetArr[texNum].X;
                                tileGridArr[texNum].Y = tileSetArr[texNum].Y;
                                tileGridArr[texNum].Z = tileSetArr[texNum].Z;
                                tileGridArr[texNum].Status = 0;
                            }
                        }
                        else
                        {
                            tileGridArr[texNum].Status++;
                            if (!mf.isInternetConnected) tileGridArr[texNum].Status = 11; //stop trying if no internet
                        }
                    }
                }

                checkZoomWorldGrid();
            }
        }

        /// <summary>
        /// Renders the world tiles map to the current OpenGL context using the appropriate textures and color scheme.
        /// </summary>
        /// <remarks>This method draws a grid of world tiles, applying either day or night color settings
        /// based on user preferences. It uses OpenGL to render textured tiles, selecting the texture for each tile
        /// according to its status. The method should be called within a valid OpenGL rendering context. After drawing
        /// the tiles, the map zoom is updated to reflect the current camera zoom level.</remarks>
        public void DrawWorldTilesMap()
        {
            Color field = Settings.User.setDisplay_isDayMode ? Settings.User.colorFieldDay : Settings.User.colorFieldNight;

            GL.Color3(field.R, field.G, field.B);
            if (mapTexture != null)
            {
                GL.Enable(EnableCap.Texture2D);

                int tex = 0;
                for (double i = -3; i < 4; i += 1)
                {
                    for (double j = 3; j > -4; j -= 1)
                    {
                        if (tileGridArr[tex].Status < 10)
                            GL.BindTexture(TextureTarget.Texture2D, mapTexture[tex]);
                        else
                        {
                            GL.BindTexture(TextureTarget.Texture2D, mf.texture[(int)FormGPS.textures.Floor2]);
                        }

                        double ii = (i + lastOriginToPivotInTilesX) * metersPerTile + offsetX;  //x
                        double jj = (j + lastOriginToPivotInTilesY) * metersPerTile + offsetY;   //y
                        double bitt = metersPerTile / 2;
                        GL.Begin(PrimitiveType.TriangleStrip);
                        GL.TexCoord2(0.0, 0.0);
                        GL.Vertex3(ii - bitt, jj + bitt, -0.10);
                        GL.TexCoord2(1.0, 0.0);
                        GL.Vertex3(ii + bitt, jj + bitt, -0.10);
                        GL.TexCoord2(0.0, 1.0);
                        GL.Vertex3(ii - bitt, jj - bitt, -0.10);
                        GL.TexCoord2(1.0, 1.0);
                        GL.Vertex3(ii + bitt, jj - bitt, -0.10);
                        GL.End();
                        tex++;
                    }
                }
            }
            GL.Disable(EnableCap.Texture2D);

            UpdateMapZoomFromCamZoom();
        }

        /// <summary>
        /// Calculates the origin tile coordinates and corresponding meter offsets based on the current map position and
        /// zoom level.
        /// </summary>
        /// <remarks>This method updates the origin tile indices and offset values used for map
        /// positioning. It should be called whenever the map's starting longitude, latitude, or zoom level changes to
        /// ensure that the origin and offsets remain accurate.</remarks>
        public void CalculateOriginAndOffset()
        {
            originTileXY_F = mf.map.WSG84ToTilePos(CNMEA.lonStart, CNMEA.latStart, mf.map.ZoomLevel);

            originTileX = (int)Math.Floor(originTileXY_F.X);
            originTileY = (int)Math.Floor(originTileXY_F.Y);

            //meters per pixel * 256 = meters per tile
            metersPerTile = (Math.Cos(mf.pn.latitude * Math.PI / 180) * 2 * Math.PI * 6378137) / (256 * Math.Pow(2, mf.map.ZoomLevel)) * 256;

            offsetX = (0.5 - (originTileXY_F.X - (int)originTileXY_F.X)) * metersPerTile;
            offsetY = ((originTileXY_F.Y - (int)originTileXY_F.Y) - 0.5) * metersPerTile;
        }

        /// <summary>
        /// Generates and initializes texture memory for a 5x5 grid of textures.
        /// </summary>
        /// <remarks>This method creates and binds OpenGL textures, sets texture parameters for filtering,
        /// and loads texture data from a predefined bitmap resource. The textures are stored in  the <c>mapTexture</c>
        /// array. </remarks>
        public void GenerateTextureMemory()
        {
            mapTexture = new uint[49];

            int tex = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    {
                        GL.GenTextures(1, out mapTexture[tex]);
                        GL.BindTexture(TextureTarget.Texture2D, mapTexture[tex]);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

                        Bitmap bitmap = Resources.z_Floor2;
                        var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                        bitmap.UnlockBits(bitmapData);

                        tileSetArr[tex].X = -1;
                        tex++;
                    }
                }
            }
        }

        /// <summary>
        /// Adjusts the tile offset based on the specified heading direction while in 3D only
        /// </summary>
        /// <remarks>The method calculates the adjustment to the tile offsets by determining the sector of
        /// the heading. Each sector represents a 45° range, and the adjustments are applied using predefined lookup
        /// tables (now tuples).</remarks>
        /// <param name="originToXinTiles">A reference to the X-coordinate offset in tiles. This value will be modified based on the heading.</param>
        /// <param name="originToYinTiles">A reference to the Y-coordinate offset in tiles. This value will be modified based on the heading.</param>
        /// <param name="heading">The heading direction in degrees, where 0° represents north, 90° represents east, 180° represents south, and
        /// 270° represents west. The heading is used to determine the adjustment to the tile offsets.</param>
        private void ApplyHeadingToTileOffset(ref int originToXinTiles, ref int originToYinTiles, double heading)
        {
            // Determine sector: 0..7 where each sector is 45°, centered on multiples of 45°.
            int sector = (int)Math.Floor((heading + 22.5) / 45.0);

            // Normalize to 0..7 to handle negative headings correctly.
            sector = ((sector % 8) + 8) % 8;

            // Retrieve tuple offsets and apply.
            if (Settings.User.setDisplay_camPitch == 0)
            {
                var (dx, dy) = headingMapMoveOffsets[sector];
                originToXinTiles += dx;
                originToYinTiles += dy;
            }
            else
            {
                var (dx, dy) = headingMapMoveOffsets3D[sector];
                originToXinTiles += dx;
                originToYinTiles += dy;
            }
        }

        /// <summary>
        /// Prefetches map tiles in a ring surrounding the specified tile coordinates to improve map loading
        /// performance.
        /// </summary>
        /// <remarks>This method requests map tiles that form the outer border of a 7x7 tile region,
        /// centered on the specified coordinates. Prefetching these tiles can reduce loading delays 
        /// when the user moves to adjacent areas.</remarks>
        /// <param name="scanTileX">The X-coordinate of the top-left tile of the area to prefetch.</param>
        /// <param name="scanTileY">The Y-coordinate of the top-left tile of the area to prefetch.</param>
        private void PrefetchRingTiles(int scanTileX, int scanTileY)
        {
            //prefetch tiles around outside
            for (int i = 0; i < 7; i++)
            {
                //make sure tile is not in cache or file already.
                if (mf.map.PrefetchTile(scanTileX, scanTileY + i, mf.map.ZoomLevel) == false)
                    mf.map.RequestTileFromTileServer(scanTileX, scanTileY + i, mf.map.ZoomLevel);
                if (mf.map.PrefetchTile(scanTileX + 6, scanTileY + i, mf.map.ZoomLevel) == false)
                    mf.map.RequestTileFromTileServer(scanTileX + 6, scanTileY + i, mf.map.ZoomLevel);
            }

            for (int j = 1; j < 6; j++)
            {
                if (mf.map.PrefetchTile(scanTileX + j, scanTileY, mf.map.ZoomLevel) == false)
                    mf.map.RequestTileFromTileServer(scanTileX + j, scanTileY, mf.map.ZoomLevel);

                if (mf.map.PrefetchTile(scanTileX + j, scanTileY + 6, mf.map.ZoomLevel) == false)
                    mf.map.RequestTileFromTileServer(scanTileX + j, scanTileY + 6, mf.map.ZoomLevel);
            }
        }

        #region Grid

        /// <summary>
        /// Renders a grid overlay on the world view at the specified zoom level.
        /// </summary>
        /// <remarks>The grid is drawn using the current OpenGL context and adapts its color based on the
        /// application's day or night mode settings.</remarks>
        /// <param name="_gridZoom">The spacing between grid lines, in world units. Must be a positive, non-zero value. Smaller values result in
        /// a denser grid.</param>
        public void DrawWorldGrid(double _gridZoom)
        {
            //_gridZoom *= 0.5;

            //GL.Rotate(-gridRotation, 0, 0, 1.0);

            if (Settings.User.setDisplay_isDayMode)
            {
                GL.Color3(0.25, 0.25, 0.25);
            }
            else
            {
                GL.Color3(0.12, 0.12, 0.12);
            }
            GL.LineWidth(1);
            GL.Begin(PrimitiveType.Lines);
            for (double num = Math.Round(eastingMin / _gridZoom, MidpointRounding.AwayFromZero) * _gridZoom; num < eastingMax; num += _gridZoom)
            {
                if (num < eastingMin) continue;

                GL.Vertex3(num, northingMax, 0.1);
                GL.Vertex3(num, northingMin, 0.1);
            }
            for (double num2 = Math.Round(northingMin / _gridZoom, MidpointRounding.AwayFromZero) * _gridZoom; num2 < northingMax; num2 += _gridZoom)
            {
                if (num2 < northingMin) continue;

                GL.Vertex3(eastingMax, num2, 0.1);
                GL.Vertex3(eastingMin, num2, 0.1);
            }
            GL.End();

            //GL.Rotate(gridRotation, 0, 0, 1.0);
        }

        /// <summary>
        /// Updates the world grid boundaries based on the current pivot axle position and grid size.
        /// </summary>
        /// <remarks>This method recalculates the minimum and maximum northing and easting values for the
        /// world grid, centering the grid around the current pivot axle position. The updated boundaries are determined
        /// by rounding the pivot position to the nearest grid interval and expanding the grid by the configured grid
        /// size. Call this method after changing the pivot position or grid size to ensure the grid boundaries remain
        /// accurate.</remarks>
        public void checkZoomWorldGrid()
        {
            double n = Math.Round(mf.pivotAxlePos.northing / (GridSize / Count), MidpointRounding.AwayFromZero) * (GridSize / Count);
            double e = Math.Round(mf.pivotAxlePos.easting / (GridSize / Count), MidpointRounding.AwayFromZero) * (GridSize / Count);

            northingMax = n + GridSize;
            northingMin = n - GridSize;
            eastingMax = e + GridSize;
            eastingMin = e - GridSize;
        }

        #endregion

    }
}
