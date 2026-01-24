//Please, if you use this, share the improvements

using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;

namespace Twol.Mapping
{
    public class WorldFloor
    {
        private readonly FormGPS mf;

        //Y
        public double northingMax = GridSize;

        public double northingMin = -GridSize;

        //X
        public double eastingMax = GridSize;

        public double eastingMin = -GridSize;

        public const double GridSize = 6000;
        public double Count = 40;

        public double gridRotation = 0.0;

        //Y
        public double northingMaxGeo;

        public double northingMinGeo;

        //X
        public double eastingMaxGeo;

        public double eastingMinGeo;

        //Y
        public double northingMaxRate;

        public double northingMinRate;

        //X
        public double eastingMaxRate;

        public double eastingMinRate;


        public WorldFloor(FormGPS _f)
        {
            mf = _f;

            northingMaxGeo = 300;
            northingMinGeo = -300;
            eastingMaxGeo = 300;
            eastingMinGeo = -300;
            northingMaxRate = 300;
            northingMinRate = -300;
            eastingMaxRate = 300;
            eastingMinRate = -300;
        }

        public void DrawFieldSurface()
        {
            Color field = Settings.User.setDisplay_isDayMode ? Settings.User.colorFieldDay : Settings.User.colorFieldNight;

            //adjust bitmap zoom based on cam zoom
            if (Settings.User.setDisplay_camZoom > 100) Count = 4;
            else if (Settings.User.setDisplay_camZoom > 80) Count = 8;
            else if (Settings.User.setDisplay_camZoom > 50) Count = 16;
            else if (Settings.User.setDisplay_camZoom > 20) Count = 32;
            else if (Settings.User.setDisplay_camZoom > 10) Count = 64;
            else Count = 80;

            GL.Color3(field.R, field.G, field.B);
            if (Settings.User.setDisplay_isTextureOn)
            {
                GL.Enable(EnableCap.Texture2D);
                GL.BindTexture(TextureTarget.Texture2D, mf.texture[(int)FormGPS.textures.Floor]);
            }

            GL.Begin(PrimitiveType.TriangleStrip);
            GL.TexCoord2(0, 0);
            GL.Vertex2(eastingMin, northingMax);
            GL.TexCoord2(Count, 0.0);
            GL.Vertex2(eastingMax, northingMax);
            GL.TexCoord2(0.0, Count);
            GL.Vertex2(eastingMin, northingMin);
            GL.TexCoord2(Count, Count);
            GL.Vertex2(eastingMax, northingMin);
            GL.End();

            GL.Disable(EnableCap.Texture2D);
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

                GL.Vertex2(num, northingMax);
                GL.Vertex2(num, northingMin);
            }
            for (double num2 = Math.Round(northingMin / _gridZoom, MidpointRounding.AwayFromZero) * _gridZoom; num2 < northingMax; num2 += _gridZoom)
            {
                if (num2 < northingMin) continue;

                GL.Vertex2(eastingMax, num2);
                GL.Vertex2(eastingMin, num2);
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