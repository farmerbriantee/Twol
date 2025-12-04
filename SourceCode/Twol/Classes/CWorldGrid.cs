//Please, if you use this, share the improvements

using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using Twol.Mapping;
namespace Twol
{
    public class CWorldGrid
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
        public bool isSet = false;
        public double lastZoom = 0;

        private double offsetX = 0, offsetY = 0;


        public CWorldGrid(FormGPS _f)
        {
            mf = _f;
        }

        public void DrawFieldSurface()
        {
            Color field = Settings.User.setDisplay_isDayMode ? Settings.User.colorFieldDay : Settings.User.colorFieldNight;

            //adjust bitmap zoom based on cam zoom
            double result = Math.Log(Settings.User.setDisplay_camZoom, 2);

            //if (Settings.User.setDisplay_camZoom > 128)
            //{
            //    if (lastZoom != 128)
            //    {
            //        isSet = false;
            //        lastZoom = 128;
            //        mf.map.ZoomLevel = 11;
            //    }
            //    Count = 8;
            //    Count = 4;
            //}
            if (Settings.User.setDisplay_camZoom > 64)
            {
                if (lastZoom != 64)
                {
                    isSet = false;
                    lastZoom = 64;
                    mf.map.ZoomLevel = 13;
                }
                Count = 8;
            }
            else if (Settings.User.setDisplay_camZoom > 32)
            {
                if (lastZoom != 32)
                {
                    isSet = false;
                    lastZoom = 32;
                    mf.map.ZoomLevel = 15;
                }

                Count = 16;
            }
            else if (Settings.User.setDisplay_camZoom > 16)
            {
                if (lastZoom != 16)
                {
                    isSet = false;
                    lastZoom = 16;
                    mf.map.ZoomLevel = 17;
                }
                Count = 32;
            }
            else
            {
                Count = 80;
            }

            //meters per pixel
            double mpp = (Math.Cos(mf.pn.latitude * Math.PI / 180) * 2 * Math.PI * 6378137) / (256 * Math.Pow(2, mf.map.ZoomLevel));
            double bit = (mpp * 256);

            double travelX = mf.pn.fix.easting / bit;
            double travelY = mf.pn.fix.northing / bit;

            if (!isSet)
            {
                mf.mapTexture = new uint[9];
                PointF tileXY = mf.map.WSG84ToTilePos(CNMEA.lonStart, CNMEA.latStart, mf.map.ZoomLevel);
                int tileX = (int)Math.Floor(tileXY.X);
                int tileY = (int)Math.Floor(tileXY.Y);

                offsetX = (0.5 - (tileXY.X - (int)tileXY.X)) * mpp * 256;
                offsetY = ((tileXY.Y - (int)tileXY.Y) - 0.5) * mpp * 256;

                //set to top-left tile
                tileX = tileX - 1 - (int)travelX;
                tileY = tileY - 1 - (int)travelY;

                int tex = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        //if (tile == null)
                        {
                            int tx = tileX + i;
                            int ty = tileY + j;
                            tile = mf.map.GetTile(tileX + i, tileY + j, mf.map.ZoomLevel);

                            if (tile != null)
                            {
                                GL.GenTextures(1, out mf.mapTexture[tex]);
                                GL.BindTexture(TextureTarget.Texture2D, mf.mapTexture[tex]);

                                // Set texture filtering parameters
                                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

                                if (tile.Image is Bitmap bitmap)
                                {
                                    var bitmapData = bitmap.LockBits(
                                        new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                        System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                        System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                                    GL.TexImage2D(
                                        TextureTarget.Texture2D,
                                        0,
                                        PixelInternalFormat.Rgb,
                                        bitmapData.Width,
                                        bitmapData.Height,
                                        0,
                                        OpenTK.Graphics.OpenGL.PixelFormat.Rgb,
                                        PixelType.UnsignedByte,
                                        bitmapData.Scan0);

                                    bitmap.UnlockBits(bitmapData);
                                }
                                tex++;
                            }
                        }
                    }
                }

                isSet = true;
            }

            GL.Color3(0.542, 0.542, 0.542);
            if (Settings.User.setDisplay_isTextureOn && mf.mapTexture != null)
            {
                GL.Enable(EnableCap.Texture2D);

                int t = 0;
                for (double i = -1; i < 2; i += 1)
                {
                    for (double j = 1; j > -2; j -= 1)
                    {
                        if (mf.mapTexture[t] != 0)
                            GL.BindTexture(TextureTarget.Texture2D, mf.mapTexture[t]);
                        else
                        {
                            GL.BindTexture(TextureTarget.Texture2D, mf.texture[(int)FormGPS.textures.Floor]);
                        }

                        double ii = i * bit;  //x
                        double jj = j * bit;   //y
                        double bitt = bit / 2;
                        GL.Begin(PrimitiveType.TriangleStrip);
                        GL.TexCoord2(0, 0);
                        GL.Vertex3(ii - bitt + offsetX, jj + bitt + offsetY, -0.10);
                        GL.TexCoord2(1, 0.0);
                        GL.Vertex3(ii + bitt + offsetX, jj + bitt + offsetY, -0.10);
                        GL.TexCoord2(0.0, 1);
                        GL.Vertex3(ii - bitt + offsetX, jj - bitt + offsetY, -0.10);
                        GL.TexCoord2(1, 1);
                        GL.Vertex3(ii + bitt + offsetX, jj - bitt + offsetY, -0.10);
                        GL.End();
                        t++;
                    }
                }
            }
            GL.Disable(EnableCap.Texture2D);

            //GL.Vertex3(eastingMin, northingMax, -0.10);
            //GL.TexCoord2(Count, 0.0);
            //GL.Vertex3(eastingMax, northingMax, -0.10);
            //GL.TexCoord2(0.0, Count);
            //GL.Vertex3(eastingMin, northingMin, -0.10);
            //GL.TexCoord2(Count, Count);
            //GL.Vertex3(eastingMax, northingMin, -0.10);

            for (int i = -2; i < 2; i++)
            {
                for (int j = 1; j > -3; j--)
                {
                    double ii = i * bit;
                    double jj = j * bit;
                    double bitt = bit / 2;

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

        public void DrawWorldGrid(double _gridZoom)
        {
            //_gridZoom *= 0.5;

            GL.Rotate(-gridRotation, 0, 0, 1.0);

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

            GL.Rotate(gridRotation, 0, 0, 1.0);
        }

        public void checkZoomWorldGrid(double northing, double easting)
        {
            double n = Math.Round(northing / (GridSize / Count * 2), MidpointRounding.AwayFromZero) * (GridSize / Count * 2);
            double e = Math.Round(easting / (GridSize / Count * 2), MidpointRounding.AwayFromZero) * (GridSize / Count * 2);

            northingMax = n + GridSize;
            northingMin = n - GridSize;
            eastingMax = e + GridSize;
            eastingMin = e - GridSize;
        }
    }
}