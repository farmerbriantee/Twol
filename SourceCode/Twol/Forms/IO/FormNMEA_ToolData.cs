//Please, if you use this give me some credit
//Copyright BrianTee, copy right out of it.

using System;
using System.Windows.Forms;

namespace Twol
{
    public partial class FormNMEA_ToolData : Form
    {
        private readonly FormGPS mf = null;

        public FormNMEA_ToolData(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblLatitude.Text = mf.pnTool.latitude.ToString("N7");
            lblLongitude.Text = mf.pnTool.longitude.ToString("N7");

            lblEastingField.Text = Math.Round(mf.toolPivotPos.easting, 2).ToString();
            lblNorthingField.Text = Math.Round(mf.toolPivotPos.northing, 2).ToString();

            lblHz.Text = mf.gpsHz.ToString("N1");
            lblIMUHeading.Text = mf.GyroInDegrees;
            lblFix2FixHeading.Text = mf.GPSHeading;

            //////other sat and GPS info
            lblFixQuality.Text = mf.pnTool.FixQuality;
            lblSatsTracked.Text = mf.pnTool.satellitesTracked.ToString();
            lblHDOP.Text = mf.pnTool.hdop.ToString();
            lblSpeed.Text = mf.pnTool.vtgSpeed.ToString("N1");

            lblAge.Text = mf.pnTool.age.ToString("N1");

            lblElevation.Text = mf.pnTool.elevation.ToString("N1");

            tboxVTG.Text = mf.pnTool.vtgSentence;
            tboxGGA.Text = mf.pnTool.ggaSentence;
            tboxPTWOLI.Text = mf.pnTool.paogiSentence;
            tboxAVR.Text = mf.pnTool.avrSentence;
            tboxHDT.Text = mf.pnTool.hdtSentence;
            tboxHPD.Text = mf.pnTool.hpdSentence;
            tboxPANDA.Text = mf.pnTool.pandaSentence;
            tboxKSXT.Text = mf.pnTool.ksxtSentence;
            tboxRMC.Text = mf.pnTool.rmcSentence;
        }

        private void FormNMEA_ToolData_Load(object sender, EventArgs e)
        {
            mf.pn.isGPSSentencesOn = true;
            tboxGGA.Text = "";
            tboxVTG.Text = "";
            tboxHDT.Text = "";
            tboxAVR.Text = "";
            tboxPTWOLI.Text = "";
            tboxHPD.Text = "";
            tboxPANDA.Text = "";
            tboxKSXT.Text = "";
        }

        private void FormNMEA_ToolData_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.pnTool.isGPSSentencesOn = false;
        }
    }
}