//Please, if you use this give me some credit
//Copyright BrianTee, copy right out of it.

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Twol
{
    public partial class FormGPSData : Form
    {
        private readonly FormGPS mf = null;

        Tile tile;

        public FormGPSData(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblTram.Text = mf.tram.controlByte.ToString();

            lblFrameTime.Text = mf.frameTime.ToString("N1");
            lblTimeSlice.Text = (1 / mf.timeSliceOfLastFix).ToString("N3");
            lblHz.Text = mf.gpsHz.ToString("N1");

            lblEastingField.Text = Math.Round(mf.pivotAxlePos.easting, 1).ToString();
            lblNorthingField.Text = Math.Round(mf.pivotAxlePos.northing, 1).ToString();

            lblLatitude.Text = mf.Latitude;
            lblLongitude.Text = mf.Longitude;

            //other sat and GPS info
            lblSatsTracked.Text = mf.SatsTracked;
            lblHDOP.Text = mf.HDOP;
            //lblSpeed.Text = mf.avgSpeed.ToString("N2");

            //lblUturnByte.Text = Convert.ToString(mf.mc.machineData[mf.mc.mdUTurn], 2).PadLeft(6, '0');

            //lblRoll.Text = mf.RollInDegrees;
            lblIMUHeading.Text = mf.GyroInDegrees;
            lblFix2FixHeading.Text = mf.GPSHeading;
            lblFuzeHeading.Text = glm.toDegrees(mf.fixHeading).ToString("N1");

            lblAngularVelocity.Text = mf.ahrs.imuYawRate.ToString("N2");

            //lbludpWatchCounts.Text = mf.missedSentenceCount.ToString();

            lblAltitude.Text = mf.Altitude;

            PointF tileXY = mf.map.ToTilePos(mf.pn.longitude, mf.pn.latitude, mf.map.ZoomLevel);

            lblZ.Text = mf.map.ZoomLevel.ToString();

            lblX.Text = tileXY.X.ToString();
            lblY.Text = tileXY.Y.ToString();

            if (tile == null)
            {
                tile = mf.map.GetTile((int)tileXY.X, (int)tileXY.Y, mf.map.ZoomLevel);

                mf.mapTexture = new uint[1];

                {
                    //GL.GenTextures(1, out mf.mapTexture[0]);
                    //GL.BindTexture(TextureTarget.Texture2D, mf.mapTexture[0]);
                    //BitmapData bitmapData = tile.Image.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    //GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                    //bitmap.UnlockBits(bitmapData);
                    //GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
                    //GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, 9729);
                }

            }
        }

        private void FormGPSData_Load(object sender, EventArgs e)
        {
            this.Width = 120;
            this.Height = 330;
        }

        private void FormGPSData_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.isGPSSentencesOn = false;
        }
    }
}

//lblAreaAppliedMinusOverlap.Text = ((fd.actualAreaCovered * glm.m2ac).ToString("N2"));
//lblAreaMinusActualApplied.Text = (((mf.fd.areaBoundaryOuterLessInner - mf.fd.actualAreaCovered) * glm.m2ac).ToString("N2"));
//lblOverlapPercent.Text = (fd.overlapPercent.ToString("N2")) + "%";
//lblAreaOverlapped.Text = (((fd.workedAreaTotal - fd.actualAreaCovered) * glm.m2ac).ToString("N3"));

//lblAreaAppliedMinusOverlap.Text = ((fd.actualAreaCovered * glm.m2ha).ToString("N2"));
//lblAreaMinusActualApplied.Text = (((mf.fd.areaBoundaryOuterLessInner - mf.fd.actualAreaCovered) * glm.m2ha).ToString("N2"));
//lblOverlapPercent.Text = (fd.overlapPercent.ToString("N2")) + "%";
//lblAreaOverlapped.Text = (((fd.workedAreaTotal - fd.actualAreaCovered) * glm.m2ha).ToString("N3"));

//lblLookOnLeft.Text = mf.tool.lookAheadDistanceOnPixelsLeft.ToString("N0");
//lblLookOnRight.Text = mf.tool.lookAheadDistanceOnPixelsRight.ToString("N0");
//lblLookOffLeft.Text = mf.tool.lookAheadDistanceOffPixelsLeft.ToString("N0");
//lblLookOffRight.Text = mf.tool.lookAheadDistanceOffPixelsRight.ToString("N0");

//lblLeftToolSpd.Text = (mf.tool.toolFarLeftSpeed*3.6).ToString("N1");
//lblRightToolSpd.Text = (mf.tool.toolFarRightSpeed*3.6).ToString("N1");

//lblSectSpdLeft.Text = (mf.section[0].speedPixels*0.36).ToString("N1");
//lblSectSpdRight.Text = (mf.section[mf.tool.numOfSections-1].speedPixels*0.36).ToString("N1");