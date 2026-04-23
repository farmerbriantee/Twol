//Please, if you use this give me some credit
//Copyright BrianTee, copy right out of it.

using System;
using System.Windows.Forms;

namespace Twol
{
    public partial class FormNMEA_Data : Form
    {
        private readonly FormGPS mf = null;

        public FormNMEA_Data(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblLatitude.Text = mf.pn.latitude.ToString("N7");
            lblLongitude.Text = mf.pn.longitude.ToString("N7");

            lblEastingField.Text = Math.Round(mf.pivotAxlePos.easting, 2).ToString()+","
                + Math.Round(mf.pivotAxlePos.northing, 2).ToString();

            //lblHz.Text = mf.gpsHz.ToString("N1");
            lblIMUHeading.Text = mf.GyroInDegrees;
            lblFix2FixHeading.Text = mf.GPSHeading;

            //////other sat and GPS info
            lblFixQuality.Text = mf.pn.FixQuality;
            lblSatsTracked.Text = mf.pn.satellitesTracked.ToString();
            lblHDOP.Text = mf.pn.hdop.ToString();
            lblSpeed.Text = mf.pn.vtgSpeed.ToString("N1");

            lblAge.Text = mf.pn.age.ToString("N1");

            lblElevation.Text = mf.pn.elevation.ToString("N1");

            tboxVTG.Text = mf.pn.vtgSentence;
            tboxGGA.Text = mf.pn.ggaSentence;
            tboxPAOGI.Text = mf.pn.paogiSentence;
            tboxAVR.Text = mf.pn.avrSentence;
            tboxHDT.Text = mf.pn.hdtSentence;
            tboxHPD.Text = mf.pn.hpdSentence;
            tboxPANDA.Text = mf.pn.pandaSentence;
            tboxKSXT.Text = mf.pn.ksxtSentence;
            tboxRMC.Text = mf.pn.rmcSentence;
        }

        private void FormNMEA_Data_Load(object sender, EventArgs e)
        {
            mf.pn.isGPSSentencesOn = true;
            tboxGGA.Text = "";
            tboxVTG.Text = "";
            tboxHDT.Text = "";
            tboxAVR.Text = "";
            tboxPAOGI.Text = "";
            tboxHPD.Text = "";
            tboxPANDA.Text = "";
            tboxKSXT.Text = "";
        }

        private void FormNMEA_Data_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.pn.isGPSSentencesOn = false;
        }
    }
}