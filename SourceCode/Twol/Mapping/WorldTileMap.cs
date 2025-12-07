//Please, if you use this, share the improvements

using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using Twol.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Twol.Mapping
{
    /// <summary>
    /// Status enum for map texture slots.
    /// </summary>
    public enum TexStatus
    {
        MemoryIntialized = 1,
        DefaultLoaded = 2,
        TileCorrect = 3,
        Unchanged = 4
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

        //Y
        public double northingMax = GridSize;

        public double northingMin = -GridSize;

        //X
        public double eastingMax = GridSize;

        public double eastingMin = -GridSize;

        public const double GridSize = 20000;
        public double Count = 40;

        public double gridRotation = 0.0;

        Tile tile;
        public bool isUpdateTiles = true;
        public double lastZoom = 0;

        private double offsetX = 0, offsetY = 0;

        //tile textures array for openGL
        public uint[] mapTexture;
        public int[] mapTextureStatus = new int[25];

        private int originToXinTiles = 0, originToYinTiles = 0;
        private int lastOriginToXinTiles = 0, lastOriginToYinTiles = 0;

        private double secondCounter = 0;

        //public PointF originTileXY = new PointF(0, 0);

        //cam z height to map zoom level mapping
        private readonly int[] camToZoomMapping = new int[]
        {
             128, 11, 96, 12, 64, 13, 48, 14, 32, 15, 24, 16, 16, 17, 8, 18
        };

        int[] headingMapMoveDistanceX = { 0, 1, 1, 1, 0, -1, -1, -1 };
        int[] headingMapMoveDistanceY = { 1, 1, 0, -1, -1, -1, 0, 1 };

        public WorldTileMap(FormGPS _f)
        {
            mf = _f;
        }

        public void DrawWorldMap()
        {
            secondCounter += 1.0 / mf.gpsHz;

            UpdateMapZoomFromCamZoom();

            // adjust bitmap zoom based on cam zoom
            double result = Math.Log(Settings.User.setDisplay_camZoom, 2);

            //meters per pixel
            double mpp = (Math.Cos(mf.pn.latitude * Math.PI / 180) * 2 * Math.PI * 6378137) / (256 * Math.Pow(2, mf.map.ZoomLevel));
            double mPerTile = (mpp * 256);

            originToXinTiles = (int)(mf.pn.fix.easting / mPerTile);
            originToYinTiles = (int)(mf.pn.fix.northing / mPerTile);

            //only move map ahead if in 3D
            if (Settings.User.setDisplay_camPitch != 0)
                ApplyHeadingToTileOffset(ref originToXinTiles, ref originToYinTiles, glm.toDegrees(mf.fixHeading));

            if (originToXinTiles != lastOriginToXinTiles || originToYinTiles != lastOriginToYinTiles)
            {
                isUpdateTiles = true;
                lastOriginToXinTiles = originToXinTiles;
                lastOriginToYinTiles = originToYinTiles;
            }

            if (secondCounter > 1 || isUpdateTiles)
            {
                PointF originTileXY = mf.map.WSG84ToTilePos(CNMEA.lonStart, CNMEA.latStart, mf.map.ZoomLevel);
                int tileX = (int)Math.Floor(originTileXY.X);
                int tileY = (int)Math.Floor(originTileXY.Y);

                offsetX = (0.5 - (originTileXY.X - (int)originTileXY.X)) * mPerTile;
                offsetY = ((originTileXY.Y - (int)originTileXY.Y) - 0.5) * mPerTile;

                //set to top-left tile
                tileX = tileX - 2 + lastOriginToXinTiles;
                tileY = tileY - 2 - lastOriginToYinTiles;

                secondCounter = 0;

                if (isUpdateTiles)
                {
                    int tex = 0;

                    //5 x 5 tilemap
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            tile = mf.map.GetTile(tileX + i, tileY + j, mf.map.ZoomLevel);

                            if (tile != null)
                            {
                                GL.BindTexture(TextureTarget.Texture2D, mapTexture[tex]);
                                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

                                if (tile.Image is Bitmap bitmap)
                                {
                                    var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                                    // Keep memory in place, fill with new image 
                                    GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, bitmapData.Width, bitmapData.Height, PixelFormat.Rgba, PixelType.UnsignedByte, bitmapData.Scan0);
                                    bitmap.UnlockBits(bitmapData);

                                    //loaded
                                    mapTextureStatus[tex] = (int)TexStatus.TileCorrect;
                                }
                                else
                                {
                                    //default status
                                    mapTextureStatus[tex] = (int)TexStatus.DefaultLoaded;

                                    //load default texture
                                    LoadDefaultTexture(tex);
                                }
                            }
                            else
                            {
                                //load default texture and wait till downloaded.
                                LoadDefaultTexture(tex);
                            }

                            //will never retrieve tiles if no internet
                            if (mf.map.isInternetConnected == false)
                            {
                                mapTextureStatus[tex] = (int)TexStatus.TileCorrect;
                            }
                            tex++;
                        }
                    }

                    isUpdateTiles = false;
                }
                else
                {
                    for (int m = 0; m < mapTextureStatus.Length; m++)
                    {
                        if (mapTextureStatus[m] == (int)TexStatus.DefaultLoaded)
                        {
                            isUpdateTiles = true;
                            break;
                        }
                    }
                }

                checkZoomWorldGrid();
            }

            Color field = Settings.User.setDisplay_isDayMode ? Settings.User.colorFieldDay : Settings.User.colorFieldNight;

            GL.Color3(field.R, field.G, field.B);
            if (Settings.User.setDisplay_isTextureOn && mapTexture != null)
            {
                GL.Enable(EnableCap.Texture2D);

                int t = 0;
                for (double i = -2; i < 3; i += 1)
                {
                    for (double j = 2; j > -3; j -= 1)
                    {
                        if (mapTexture[t] != 0)
                            GL.BindTexture(TextureTarget.Texture2D, mapTexture[t]);
                        else
                        {
                            GL.BindTexture(TextureTarget.Texture2D, mf.texture[(int)FormGPS.textures.Floor]);
                        }

                        double ii = (i + lastOriginToXinTiles) * mPerTile;  //x
                        double jj = (j + lastOriginToYinTiles) * mPerTile;   //y
                        double bitt = mPerTile / 2;
                        GL.Begin(PrimitiveType.TriangleStrip);
                        GL.TexCoord2(0.0, 0.0);
                        GL.Vertex3(ii - bitt + offsetX, jj + bitt + offsetY, -0.10);
                        GL.TexCoord2(1.0, 0.0);
                        GL.Vertex3(ii + bitt + offsetX, jj + bitt + offsetY, -0.10);
                        GL.TexCoord2(0.0, 1.0);
                        GL.Vertex3(ii - bitt + offsetX, jj - bitt + offsetY, -0.10);
                        GL.TexCoord2(1.0, 1.0);
                        GL.Vertex3(ii + bitt + offsetX, jj - bitt + offsetY, -0.10);
                        GL.End();
                        t++;
                    }
                }
            }
            GL.Disable(EnableCap.Texture2D);
        }

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

        public void checkZoomWorldGrid()
        {
            double n = Math.Round(mf.pivotAxlePos.northing / (GridSize / Count), MidpointRounding.AwayFromZero) * (GridSize / Count);
            double e = Math.Round(mf.pivotAxlePos.easting / (GridSize / Count), MidpointRounding.AwayFromZero) * (GridSize / Count);

            northingMax = n + GridSize;
            northingMin = n - GridSize;
            eastingMax = e + GridSize;
            eastingMin = e - GridSize;
        }


        /// <summary>
        /// Loads the default texture for the specified texture index and applies it to the texture map.
        /// </summary>
        /// <remarks>This method binds the specified texture, sets texture parameters for filtering, and
        /// loads a default bitmap image into the texture. The texture is then marked as loaded with the default
        /// status.</remarks>
        /// <param name="tex">The index of the texture in the texture map to be loaded with the default texture.</param>
        private void LoadDefaultTexture(int tex)
        {
            GL.BindTexture(TextureTarget.Texture2D, mapTexture[tex]);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

            Bitmap bitmap = Resources.z_Floor2;
            {
                var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                // Keep memory in place, fill with new image 
                GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, bitmapData.Width, bitmapData.Height, PixelFormat.Rgba, PixelType.UnsignedByte, bitmapData.Scan0);
                bitmap.UnlockBits(bitmapData);
            }
            //not loaded
            mapTextureStatus[tex] = (int)TexStatus.DefaultLoaded;
        }

        /// <summary>
        /// Generates and initializes texture memory for a 5x5 grid of textures.
        /// </summary>
        /// <remarks>This method creates and binds OpenGL textures, sets texture parameters for filtering,
        /// and loads texture data from a predefined bitmap resource. The textures are stored in  the <c>mapTexture</c>
        /// array. </remarks>
        public void GenerateTextureMemory()
        {
            mapTexture = new uint[25];

            int tex = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
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

                        mapTextureStatus[tex] = (int)TexStatus.MemoryIntialized;
                        tex++;
                    }
                }
            }
        }

        /// <summary>
        /// Updates the map's zoom level based on the current camera zoom level.
        /// </summary>
        /// <remarks>This method maps the camera zoom level to a corresponding map zoom level using
        /// predefined thresholds. The first matching threshold is applied, and the map zoom level is updated only if it
        /// differs from the last applied zoom level.</remarks>
        private void UpdateMapZoomFromCamZoom()
        {
            // adjust bitmap zoom based on cam zoom
            //double result = Math.Log(Settings.User.setDisplay_camZoom, 2);

            for (int i = 0; i < camToZoomMapping.Length; i += 2)
            {
                if ((int)Settings.User.setDisplay_camZoom > camToZoomMapping[i])
                {
                    if (lastZoom != camToZoomMapping[i])
                    {
                        isUpdateTiles = true;
                        lastZoom = camToZoomMapping[i];
                        if (Settings.User.setDisplay_camPitch == 0) mf.map.ZoomLevel = (camToZoomMapping[i + 1] + 1);
                        else mf.map.ZoomLevel = camToZoomMapping[i + 1];
                        //mf.map.ZoomLevel = 18;
                        lastOriginToXinTiles = 0;
                        lastOriginToYinTiles = 0;
                    }
                    break; // first (highest) matching threshold wins
                }
            }

            if (Settings.User.setDisplay_camZoom > 100) Count = 5;
            else if (Settings.User.setDisplay_camZoom > 80) Count = 10;
            else if (Settings.User.setDisplay_camZoom > 50) Count = 15;
            else if (Settings.User.setDisplay_camZoom > 20) Count = 30;
            else if (Settings.User.setDisplay_camZoom > 10) Count = 60;
            else Count = 120;
        }

        /// <summary>
        /// Adjusts the tile offset based on the specified heading direction while in 3D only
        /// </summary>
        /// <remarks>The method calculates the adjustment to the tile offsets by determining the sector of
        /// the heading. Each sector represents a 45° range, and the adjustments are applied using predefined lookup
        /// tables.</remarks>
        /// <param name="originToXinTiles">A reference to the X-coordinate offset in tiles. This value will be modified based on the heading.</param>
        /// <param name="originToYinTiles">A reference to the Y-coordinate offset in tiles. This value will be modified based on the heading.</param>
        /// <param name="heading">The heading direction in degrees, where 0° represents north, 90° represents east, 180° represents south, and
        /// 270° represents west. The heading is used to determine the adjustment to the tile offsets.</param>
        private void ApplyHeadingToTileOffset(ref int originToXinTiles, ref int originToYinTiles, double heading)
        {
            // Determine sector: 0..7 where each sector is 45°, centered on multiples of 45°.
            int sector = (int)Math.Floor((heading + 22.5) / 45.0) % 8;

            // Lookup tables for x and y adjustments per sector.

            originToXinTiles += headingMapMoveDistanceX[sector];
            originToYinTiles += headingMapMoveDistanceY[sector];
        }
    }
}