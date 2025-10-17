using Twol.Classes;

using Twol.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Twol
{
    public partial class FormIO : Form
    {
        private readonly FormGPS mf = null;

        private bool toolSend = false, toolSend2 = false;
        private int counter = 0, toolCounterSettings = 0, toolCounterConfig = 0;
        private int windowSizeState = 0;

        //Form stuff
        public FormIO(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();

            this.Text = gStr.Get(gs.gsToolSteerConfiguration);
            this.Width = 390;
            this.Height = 550;

            label51.Text = gStr.Get(gs.gsDeadzone);
            label49.Text = gStr.Get(gs.gsHeading);

            lblGain.Text = gStr.Get(gs.gsProportionalGain);
        }

        private void FormIO_Load(object sender, EventArgs e)
        {
            Location = Settings.User.setWindow_steerSettingsLocation;
            nudDeadZoneHeading.Value = Settings.Vehicle.setAS_deadZoneHeading * 0.01;

            if (!mf.IsOnScreen(Location, Size, 1))
            {
                Top = 0;
                Left = 0;
            }

            cboxGPSTool.Checked = mf.isGPSToolActive;

            //settings
            hsbarMinPWM_Tool.Value = Settings.Tool.setToolSteer.minPWM;

            //config

            //settings
            lblMinPWM_Tool.Text = hsbarMinPWM_Tool.Value.ToString();

            //antenna
            nudAntennaHeight_Tool.Value = Settings.Tool.setToolSteer.antennaHeight;

        }

        private void FormSteer_FormClosing(object sender, FormClosingEventArgs e)
        {

            //settings
            Settings.Tool.setToolSteer.minPWM = (byte)hsbarMinPWM_Tool.Value;

            //save current vehicle
            Settings.IO.Save();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //limit how many pgns are set when doing the settings
            counter++;
            toolCounterSettings++;
            toolCounterConfig++;


            //tool settings
            if (toolSend && toolCounterSettings > 4)
            {
                PGN_232.pgn[PGN_232.minPWM] = (byte)hsbarMinPWM_Tool.Value;

                toolCounterSettings = 0;
                toolSend = false;
            }

            //tool config
            if (toolSend2 && toolCounterConfig > 4)
            {
                mf.SendUDPMessageTool(PGN_231.pgn, mf.epModuleTool);

                toolCounterConfig = 0;
                toolSend2 = false;
            }
        }




        #region Tab Tool Steer

        private void cboxGPSTool_Click(object sender, EventArgs e)
        {
            mf.isGPSToolActive = cboxGPSTool.Checked;
            mf.YesMessageBox("You must restart TWOL to make changes to the networking");
            Log.EventWriter("GPS Tool set to: " + cboxGPSTool.Checked.ToString());
            Settings.Tool.setToolSteer.isGPSToolActive = mf.isGPSToolActive;
        }

        //config tool 
        private void nudAntennaHeight_Tool_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setToolSteer.antennaHeight = nudAntennaHeight_Tool.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void hsbarMinPWM_Tool_Scroll(object sender, ScrollEventArgs e)
        {
            lblMinPWM_Tool.Text = e.NewValue.ToString();
            toolSend = true;
            toolCounterSettings = 0;
        }

        private void nudDeadZoneHeading_ValueChanged(object sender, EventArgs e)
        {
            mf.vehicle.deadZoneHeading = nudDeadZoneHeading.Value;
        }

        private void expandWindow_Click(object sender, EventArgs e)
        {
            if (windowSizeState++ > 0) windowSizeState = 0;
            if (windowSizeState == 1)
            {
                this.Size = new System.Drawing.Size(910,550);
                btnExpand.Image = Properties.Resources.ArrowLeft;
            }
            else if (windowSizeState == 0)
            {
                this.Size = new System.Drawing.Size(390, 550);
                btnExpand.Image = Properties.Resources.ArrowRight;
            }
        }

        #endregion
    }
}
