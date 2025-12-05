//Please, if you use this, share the improvements

using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using Twol.Properties;

namespace Twol.Mapping
{
    public class WorldMap
    {
        private readonly FormGPS mf;

        Tile tile;
        public bool isSet = false;
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

        public WorldMap(FormGPS _f)
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

            if (originToXinTiles != lastOriginToXinTiles || originToYinTiles != lastOriginToYinTiles)
            {
                isSet = false;
                lastOriginToXinTiles = originToXinTiles;
                lastOriginToYinTiles = originToYinTiles;
            }

            if (secondCounter > 1)
            {
                secondCounter = 0;
                if (!isSet)
                {
                    PointF originTileXY = mf.map.WSG84ToTilePos(CNMEA.lonStart, CNMEA.latStart, mf.map.ZoomLevel);
                    int tileX = (int)Math.Floor(originTileXY.X);
                    int tileY = (int)Math.Floor(originTileXY.Y);

                    offsetX = (0.5 - (originTileXY.X - (int)originTileXY.X)) * mPerTile;
                    offsetY = ((originTileXY.Y - (int)originTileXY.Y) - 0.5) * mPerTile;

                    //set to top-left tile
                    tileX = tileX - 2 - lastOriginToXinTiles;
                    tileY = tileY - 2 - lastOriginToYinTiles;

                    int tex = 0;

                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            tile = mf.map.GetTile(tileX + i, tileY + j, mf.map.ZoomLevel);

                            if (tile != null)
                            {
                                GL.BindTexture(TextureTarget.Texture2D, mapTexture[tex]);
                                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
                                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

                                if (tile.Image is Bitmap bitmap)
                                {
                                    var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                                    // Keep memory in place, fill with new image 
                                    GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, bitmapData.Width, bitmapData.Height, PixelFormat.Rgba, PixelType.UnsignedByte, bitmapData.Scan0);
                                    bitmap.UnlockBits(bitmapData);
                                }
                                tex++;
                            }

                            else
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
                                tex++;
                            }
                        }
                    }

                    isSet = true;
                }
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

            //grid lines based on tiles
            for (int i = -3; i < 3; i++)
            {
                for (int j = 2; j > -4; j--)
                {
                    double ii = (i + lastOriginToXinTiles) * mPerTile;
                    double jj = (j + lastOriginToYinTiles) * mPerTile;
                    double bitt = mPerTile / 2;

                    GL.Disable(EnableCap.Texture2D);

                    GL.LineWidth(1);
                    GL.Begin(PrimitiveType.Lines);

                    GL.Vertex3(ii + offsetX + bitt, 3 * mpp * 256, 0.1);
                    GL.Vertex3(ii + offsetX + bitt, -3 * mpp * 256, 0.1);

                    GL.Vertex3(3 * mpp * 256, jj + offsetY + bitt, 0.1);
                    GL.Vertex3(-3 * mpp * 256, jj + offsetY + bitt, 0.1);
                    //}
                    GL.End();
                }
            }

            //GL.Vertex3(eastingMin, northingMax, -0.10);
            //GL.TexCoord2(Count, 0.0);
            //GL.Vertex3(eastingMax, northingMax, -0.10);
            //GL.TexCoord2(0.0, Count);
            //GL.Vertex3(eastingMin, northingMin, -0.10);
            //GL.TexCoord2(Count, Count);
            //GL.Vertex3(eastingMax, northingMin, -0.10);

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

                        mapTextureStatus[tex] = 1;
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
                        isSet = false;
                        lastZoom = camToZoomMapping[i];
                        if (Settings.User.setDisplay_camPitch == 0) mf.map.ZoomLevel = (camToZoomMapping[i + 1] + 1);
                        else mf.map.ZoomLevel = camToZoomMapping[i + 1];

                        lastOriginToXinTiles = 0;
                        lastOriginToYinTiles = 0;
                    }
                    break; // first (highest) matching threshold wins
                }
            }
        }

        public void checkZoomWorldGrid(double northing, double easting)
        {
        }
    }
}