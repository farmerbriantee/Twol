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

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.AliceBlue, e.ClipRectangle);
        }

        public FormGPSData(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblTram.Text = mf.tram.controlByte.ToString();

            //lblFrameTime.Text = mf.frameTime.ToString("N1");
            //lblTimeSlice.Text = (1 / mf.timeSliceOfLastFix).ToString("N1");
            lblHz.Text = mf.gpsHz.ToString("N1");

            lblEastingField.Text = Math.Round(mf.pivotAxlePos.easting, 2).ToString();
            lblNorthingField.Text = Math.Round(mf.pivotAxlePos.northing, 2).ToString();

            lblLatitude.Text = mf.Latitude;
            lblLongitude.Text = mf.Longitude;

            //other sat and GPS info
            //lblSatsTracked.Text = mf.SatsTracked;
            lblHDOP.Text = mf.HDOP;
            //lblSpeed.Text = mf.avgSpeed.ToString("N2");

            //lblUturnByte.Text = Convert.ToString(mf.mc.machineData[mf.mc.mdUTurn], 2).PadLeft(6, '0');

            //lblRoll.Text = mf.RollInDegrees;
            lblIMUHeading.Text = mf.GyroInDegrees;
            lblFix2FixHeading.Text = mf.GPSHeading;
            //lblFuzeHeading.Text = glm.toDegrees(mf.fixHeading).ToString("N1");

            //lblAngularVelocity.Text = mf.ahrs.imuYawRate.ToString("N2");

            //lbludpWatchCounts.Text = mf.missedSentenceCount.ToString();

            lblElevation.Text = mf.ElevationInMeters;

            //PointF tileXY = mf.map.WSG84ToTilePos(mf.pn.longitude, mf.pn.latitude, mf.map.ZoomLevel);

            //lblZ.Text = mf.map.ZoomLevel.ToString();

            //lblX.Text = tileXY.X.ToString("N2");
            //lblY.Text = tileXY.Y.ToString("N2");
            //lblCam.Text = Settings.User.setDisplay_camZoom.ToString("N0");

            //double mpp = (Math.Cos(mf.pn.latitude * Math.PI / 180) * 2 * Math.PI * 6378137) / (256 * Math.Pow(2, mf.map.ZoomLevel));
            //lblMPerTile.Text = (mpp *256).ToString("N3");

            //lblOriX.Text = (mf.pn.fix.easting / (mpp*256)).ToString("N2");
            //lblOriY.Text = (mf.pn.fix.northing / (mpp*256)).ToString("N2");
        }

        private void FormGPSData_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.AliceBlue;
            this.TransparencyKey = Color.AliceBlue;
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