using System;
using System.Windows.Forms;
using Twol.Classes;

namespace Twol
{
    public partial class FormToolSteer : Form
    {
        private readonly FormGPS mf = null;

        private bool toolSend = false, toolSend2 = false;
        private int toolCounterSettings = 0, toolCounterConfig = 0;
        private int windowSizeState = 0;

        //Form stuff
        public FormToolSteer(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();

            this.Text = gStr.Get(gs.gsToolSteerConfiguration);
            this.Width = 392;
            this.Height = 550;

            label19.Text = gStr.Get(gs.gsSpeedFactor);
            label82.Text = gStr.Get(gs.gsAquireFactor);
            label51.Text = gStr.Get(gs.gsDeadzone);
            label49.Text = gStr.Get(gs.gsHeading);
            label54.Text = gStr.Get(gs.gsOnDelay);
        }

        private void FormToolSteer_Load(object sender, EventArgs e)
        {
            Location = Settings.User.setWindow_steerSettingsLocation;

            if (!mf.IsOnScreen(Location, Size, 1))
            {
                Top = 0;
                Left = 0;
            }

            //settings
            hsbarPGain_Tool.Value = Settings.Tool.setToolSteer.gainP;
            hsbarIntegral_Tool.Value = Settings.Tool.setToolSteer.integral;
            hsbarMinPWM_Tool.Value = Settings.Tool.setToolSteer.minPWM;
            hsbarHighPWM_Tool.Value = Settings.Tool.setToolSteer.highPWM;
            hsbarAckermann_Tool.Value = Settings.Tool.setToolSteer.ackermann;
            hsbarCPD_Tool.Value = Settings.Tool.setToolSteer.countsPerDegree;
            hsbarZeroWAS_Tool.Value = Settings.Tool.setToolSteer.wasOffset;

            //config
            hsbarMaxSteerAngle_Tool.Value = Settings.Tool.setToolSteer.maxSteerAngle;
            cboxInvertSteer_Tool.Checked = (Settings.Tool.setToolSteer.isInvertSteer == 1);
            cboxInvertWAS_Tool.Checked = (Settings.Tool.setToolSteer.isInvertWAS == 1);
            cboxIsSteerNotSlide_Tool.Checked = (Settings.Tool.setToolSteer.isSteerNotSlide == 1);

            //settings
            lblPGain_Tool.Text = (hsbarPGain_Tool.Value * 100 / 254).ToString();
            lblIntegral_Tool.Text = (hsbarIntegral_Tool.Value * 100 / 254).ToString();
            lblMinPWM_Tool.Text = (hsbarMinPWM_Tool.Value * 100 / 200).ToString();
            lblHighPWM_Tool.Text = (hsbarHighPWM_Tool.Value * 100 / 254).ToString();
            //lblAckermann_Tool.Text = (hsbarAckermann_Tool.Value * 100 / 250).ToString();
            lblZeroWAS_Tool.Text = (hsbarZeroWAS_Tool.Value / (double)(hsbarCPD_Tool.Value)).ToString("N2");
            lblCPD_Tool.Text = hsbarCPD_Tool.Value.ToString();

            //config
            lblMaxSteerAngle_Tool.Text = hsbarMaxSteerAngle_Tool.Value.ToString();

            //antenna
            nudAntennaHeight_Tool.Value = Settings.Tool.setToolSteer.antennaHeight;
            nudAntennaOffset_Tool.Value = Settings.Tool.setToolSteer.antennaOffset;
            nudNudge.Value = Settings.Tool.setToolSteer.nudgeGlobal;

            cboxIsFollowCurrent.Checked = Settings.Tool.setToolSteer.isFollowCurrent;
            cboxIsPassiveSteering.Checked = Settings.Tool.setToolSteer.isPassiveSteering;
            cboxIsFollowPivot.Checked = Settings.Tool.setToolSteer.isFollowPivot;
            cboxIsRecordToolLine.Checked = Settings.Tool.setToolSteer.isRecordToolLine;

            //active Tool
            hsbarManualPWM_Percent.Value = (int)(Settings.Tool.setToolSteer.manualSteerPWM * 0.4);
            hsbarManualSecondsOn.Value = Settings.Tool.setToolSteer.manualSteerSeconds;
            lblManualPWM_Percent.Text = hsbarManualPWM_Percent.Value.ToString();
            lblManualSecondsOn.Text = hsbarManualSecondsOn.Value.ToString();

            cboxRecordSourceTool.Checked = Settings.Tool.setToolSteer.isRecordSourceTool;
            cboxRecordSourceTool.Text = Settings.Tool.setToolSteer.isRecordSourceTool? "Tool GPS" : " Vehicle GPS";
            nudToolGuidanceSpacing.Value = (Settings.Tool.setToolSteer.toolGuidanceSpacing * 2);

            cboxPassesPerReference.SelectedIndexChanged -= cboxPassesPerReference_SelectedIndexChanged;
            cboxPassesPerReference.Text = Settings.Tool.setToolSteer.passesPerReference.ToString();
            cboxPassesPerReference.SelectedIndexChanged += cboxPassesPerReference_SelectedIndexChanged;

            nudToolGuidanceSpacing.Value = (Settings.Tool.setToolSteer.toolGuidanceSpacing);

            if (Settings.Tool.setToolSteer.passesPerReference == 0)
            {
                Settings.Tool.setToolSteer.toolGuidanceSpacing = nudToolGuidanceSpacing.Value = 0;
            }
            else
            {
                if (Settings.Tool.setToolSteer.passesPerReference % 2 == 0) nudToolGuidanceSpacing.Value = Settings.Tool.setToolSteer.toolGuidanceSpacing * 2.0;
            }

            lblRollZeroOffset.Text = Settings.Tool.setToolSteer.rollZero.ToString("N2");
            cboxDataInvertRoll.Checked = Settings.Tool.setToolSteer.invertRoll;

            nudDeadzoneWidth.Value = Settings.Tool.setToolSteer.deadzoneWidth;
            nudDeadZoneDelay.Value = Settings.Tool.setToolSteer.deadzoneDelay;

            hsbarPassiveCurvature.Value = (int)(Settings.Tool.setToolSteer.curvatureGain * 10);
            lblCurvatureGain.Text = (Settings.Tool.setToolSteer.curvatureGain * 2).ToString("N1");

            hsbarPassiveIntegralGain.Value = (int)(Settings.Tool.setToolSteer.passiveIntegralGain * 1000);
            lblPassiveIntegralGain.Text = (Settings.Tool.setToolSteer.passiveIntegralGain * 1000 * 5).ToString("N0");

            nudPivotToAntenna.Value = Settings.Tool.setToolSteer.pivotToAntennaDistance;
            nudPivotToTool.Value = Settings.Tool.setToolSteer.PivotToToolDistance;


            //WAS Zero, CPD

            //hsbarIntegral_Tool.Value = (int)(Settings.Tool.stanleyIntegralGainAB * 100);
            //lblIntegral_Tool.Text = ((int)(mf.vehicle.stanleyIntegralGainAB * 100)).ToString();
        }

        private void FormToolSteer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //settings
            Settings.Tool.setToolSteer.gainP = (byte)hsbarPGain_Tool.Value;
            Settings.Tool.setToolSteer.integral = (byte)hsbarIntegral_Tool.Value;
            Settings.Tool.setToolSteer.minPWM = (byte)hsbarMinPWM_Tool.Value;
            Settings.Tool.setToolSteer.highPWM = (byte)hsbarHighPWM_Tool.Value;
            Settings.Tool.setToolSteer.countsPerDegree = (byte)hsbarCPD_Tool.Value;
            Settings.Tool.setToolSteer.ackermann = (byte)hsbarAckermann_Tool.Value;
            Settings.Tool.setToolSteer.wasOffset = hsbarZeroWAS_Tool.Value;

            //config
            Settings.Tool.setToolSteer.maxSteerAngle = (byte)hsbarMaxSteerAngle_Tool.Value;

            if (cboxInvertSteer_Tool.Checked) Settings.Tool.setToolSteer.isInvertWAS = 1;
            else Settings.Tool.setToolSteer.isInvertWAS = 0;

            if (cboxInvertWAS_Tool.Checked) Settings.Tool.setToolSteer.isInvertSteer = 1;
            else Settings.Tool.setToolSteer.isInvertSteer = 0;

            if (cboxIsSteerNotSlide_Tool.Checked) Settings.Tool.setToolSteer.isSteerNotSlide = 1;
            else Settings.Tool.setToolSteer.isSteerNotSlide = 0;

            PGN_232.pgn[PGN_232.gainP] = Settings.Tool.setToolSteer.gainP;
            PGN_232.pgn[PGN_232.integral] = Settings.Tool.setToolSteer.integral;
            PGN_232.pgn[PGN_232.minPWM] = Settings.Tool.setToolSteer.minPWM;
            PGN_232.pgn[PGN_232.highPWM] = Settings.Tool.setToolSteer.highPWM;
            PGN_232.pgn[PGN_232.countsPerDegree] = Settings.Tool.setToolSteer.countsPerDegree;
            PGN_232.pgn[PGN_232.ackerman] = Settings.Tool.setToolSteer.ackermann;

            PGN_232.pgn[PGN_232.wasOffsetHi] = unchecked((byte)(Settings.Tool.setToolSteer.wasOffset >> 8));
            PGN_232.pgn[PGN_232.wasOffsetLo] = unchecked((byte)(Settings.Tool.setToolSteer.wasOffset));

            //config
            PGN_231.pgn[PGN_231.maxSteerAngle] = Settings.Tool.setToolSteer.maxSteerAngle;
            PGN_231.pgn[PGN_231.invertWAS] = Settings.Tool.setToolSteer.isInvertWAS;
            PGN_231.pgn[PGN_231.invertSteer] = Settings.Tool.setToolSteer.isInvertSteer;
            PGN_231.pgn[PGN_231.isSteer] = Settings.Tool.setToolSteer.isSteerNotSlide;

            //save current vehicle
            Settings.Tool.Save();
        }

        #region Main Tab
        private void Timer1_Tick(object sender, EventArgs e)
        {
            //limit how many pgns are set when doing the settings
            toolCounterSettings++;
            toolCounterConfig++;

            lblPWMDisplay.Text = mf.mc.pwmToolDisplay.ToString();

            //tool settings
            if (toolSend && toolCounterSettings > 4)
            {
                PGN_232.pgn[PGN_232.gainP] = (byte)hsbarPGain_Tool.Value;
                PGN_232.pgn[PGN_232.integral] = (byte)hsbarIntegral_Tool.Value;
                PGN_232.pgn[PGN_232.minPWM] = (byte)hsbarMinPWM_Tool.Value;
                PGN_232.pgn[PGN_232.highPWM] = (byte)hsbarHighPWM_Tool.Value;
                PGN_232.pgn[PGN_232.countsPerDegree] = (byte)hsbarCPD_Tool.Value;
                PGN_232.pgn[PGN_232.ackerman] = (byte)hsbarAckermann_Tool.Value;

                PGN_232.pgn[PGN_232.wasOffsetHi] = unchecked((byte)(hsbarZeroWAS_Tool.Value >> 8));
                PGN_232.pgn[PGN_232.wasOffsetLo] = unchecked((byte)(hsbarZeroWAS_Tool.Value));

                mf.SendUDPMessageTool(PGN_232.pgn, mf.epModuleTool);
                toolCounterSettings = 0;
                toolSend = false;
            }

            //tool config
            if (toolSend2 && toolCounterConfig > 4)
            {
                PGN_231.pgn[PGN_231.maxSteerAngle] = unchecked((byte)hsbarMaxSteerAngle_Tool.Value);

                if (cboxInvertSteer_Tool.Checked) PGN_231.pgn[PGN_231.invertSteer] = 1;
                else PGN_231.pgn[PGN_231.invertSteer] = 0;

                if (cboxInvertWAS_Tool.Checked) PGN_231.pgn[PGN_231.invertWAS] = 1;
                else PGN_231.pgn[PGN_231.invertWAS] = 0;

                if (cboxIsSteerNotSlide_Tool.Checked) PGN_231.pgn[PGN_231.isSteer] = 1;
                else PGN_231.pgn[PGN_231.isSteer] = 0;

                mf.SendUDPMessageTool(PGN_231.pgn, mf.epModuleTool);

                toolCounterConfig = 0;
                toolSend2 = false;
            }
        }

        private void expandWindow_Click(object sender, EventArgs e)
        {
            if (windowSizeState++ > 0) windowSizeState = 0;
            if (windowSizeState == 1)
            {
                this.Size = new System.Drawing.Size(970, 550);
                btnExpand.Image = Properties.Resources.ArrowLeft;
            }
            else if (windowSizeState == 0)
            {
                this.Size = new System.Drawing.Size(390, 550);
                btnExpand.Image = Properties.Resources.ArrowRight;
            }
        }

        // Gain
        private void hsbarPGain_Tool_Scroll(object sender, ScrollEventArgs e)
        {
            lblPGain_Tool.Text = (e.NewValue * 100 / 254).ToString();
            toolSend = true;
            toolCounterSettings = 0;
        }
        private void hsbarHighPWM_Tool_Scroll(object sender, ScrollEventArgs e)
        {
            lblHighPWM_Tool.Text = (e.NewValue * 100 / 254).ToString();
            toolSend = true;
            toolCounterSettings = 0;
        }
        private void hsbarMinPWM_Tool_Scroll(object sender, ScrollEventArgs e)
        {
            lblMinPWM_Tool.Text = (e.NewValue * 100 / 200).ToString();
            toolSend = true;
            toolCounterSettings = 0;
        }

        private void hsbarIntegral_Tool_Scroll(object sender, ScrollEventArgs e)
        {
            lblIntegral_Tool.Text = (e.NewValue * 100 / 254).ToString();
            toolSend = true;
            toolCounterSettings = 0;
        }

        // WAS_CPD
        private void btnZeroWAS_Tool_Click(object sender, EventArgs e)
        {
            hsbarZeroWAS_Tool.Value += (int)(hsbarCPD_Tool.Value * -mf.mc.actualToolAngleDegrees);
            lblZeroWAS_Tool.Text = (hsbarZeroWAS_Tool.Value / (double)(hsbarCPD_Tool.Value)).ToString("N2");
            toolSend = true;
            toolCounterSettings = 0;
        }
        private void hsbarZeroWAS_Tool_Scroll(object sender, ScrollEventArgs e)
        {
            lblZeroWAS_Tool.Text = (e.NewValue / (double)(hsbarCPD_Tool.Value)).ToString("N2");
            toolSend = true;
            toolCounterSettings = 0;
        }
        private void hsbarCPD_Tool_Scroll(object sender, ScrollEventArgs e)
        {
            lblCPD_Tool.Text = e.NewValue.ToString();

            lblCPD_Tool.Text = hsbarCPD_Tool.Value.ToString();

            lblZeroWAS_Tool.Text = (hsbarZeroWAS_Tool.Value / (double)(hsbarCPD_Tool.Value)).ToString("N2");
            toolSend = true;
            toolCounterSettings = 0;
        }
        private void hsbarAckermann_Tool_Scroll(object sender, ScrollEventArgs e)
        {
            lblAckermann_Tool.Text = e.NewValue.ToString();
            toolSend = true;
            toolCounterSettings = 0;
        }
        private void hsbarMaxSteerAngle_Tool_Scroll(object sender, ScrollEventArgs e)
        {
            lblMaxSteerAngle_Tool.Text = e.NewValue.ToString();
            toolSend2 = true;
            toolCounterConfig = 0;
        }

        private void hsbarAcquireFactor_ValueChanged(object sender, EventArgs e)
        {
            mf.vehicle.goalPointAcquireFactor = hsbarAcquireFactor.Value * 0.01;
            lblAcquireFactor.Text = mf.vehicle.goalPointAcquireFactor.ToString();
        }

        #endregion

        #region Passive

        // DeadZone
        private void nudDeadzoneWidth_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setToolSteer.deadzoneWidth = (double)(nudDeadzoneWidth.Value);
        }

        private void nudDeadZoneDelay_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setToolSteer.deadzoneDelay = (int)(nudDeadZoneDelay.Value);
        }

        private void hsbarPassiveCurvature_Scroll(object sender, ScrollEventArgs e)
        {
            Settings.Tool.setToolSteer.curvatureGain = ((double)(e.NewValue) * 0.1);

            lblCurvatureGain.Text = (Settings.Tool.setToolSteer.curvatureGain * 2).ToString("N1");
        }

        private void hsbarPassiveIntegralGain_Scroll(object sender, ScrollEventArgs e)
        {
            Settings.Tool.setToolSteer.passiveIntegralGain = ((double)(e.NewValue) * 0.001);

            lblPassiveIntegralGain.Text = (Settings.Tool.setToolSteer.passiveIntegralGain * 1000 * 4).ToString("N0");
        }

        #endregion

        #region Modes

        private void ResetMode()
        {
            //default all off
            Settings.Tool.setToolSteer.isGPSToolActive = (cboxIsFollowCurrent.Checked || cboxIsPassiveSteering.Checked || cboxIsFollowPivot.Checked);
        }

        private void cboxIsRecordToolLine_Click(object sender, EventArgs e)
        {
            if (mf.sectionOnCounter > 0)
            {
                mf.TimedMessageBox(2000, "Sections On", "Turn off Sections First");
                return;
            }
            Settings.Tool.setToolSteer.isRecordToolLine = cboxIsRecordToolLine.Checked;
            ResetMode();
        }

        private void cboxIsFollowCurrent_Click(object sender, EventArgs e)
        {
            cboxIsPassiveSteering.Checked = Settings.Tool.setToolSteer.isPassiveSteering = false;
            Settings.Tool.setToolSteer.isFollowPivot = cboxIsFollowPivot.Checked = false;

            Settings.Tool.setToolSteer.isFollowCurrent = cboxIsFollowCurrent.Checked;
            ResetMode();
        }

        private void cboxIsFollowPivot_Click(object sender, EventArgs e)
        {
            cboxIsFollowCurrent.Checked = Settings.Tool.setToolSteer.isFollowCurrent = false;
            cboxIsPassiveSteering.Checked = Settings.Tool.setToolSteer.isPassiveSteering = false;

            Settings.Tool.setToolSteer.isFollowPivot = cboxIsFollowPivot.Checked;
            ResetMode();
        }

        private void cboxIsPassiveSteering_Click(object sender, EventArgs e)
        {
            cboxIsFollowCurrent.Checked = Settings.Tool.setToolSteer.isFollowCurrent = false;
            Settings.Tool.setToolSteer.isFollowPivot = cboxIsFollowPivot.Checked = false;

            Settings.Tool.setToolSteer.isPassiveSteering = cboxIsPassiveSteering.Checked;
            ResetMode();
        }

        // Record Source For Tool
        private void cboxRecordSourceTool_Click(object sender, EventArgs e)
        {
            Settings.Tool.setToolSteer.isRecordSourceTool = cboxRecordSourceTool.Checked;
            cboxRecordSourceTool.Text = Settings.Tool.setToolSteer.isRecordSourceTool ? "Tool GPS" : " Vehicle GPS";
        }

        #endregion

        #region Tab Active

        private void nudNudge_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setToolSteer.nudgeGlobal = (double)(nudNudge.Value);
        }

        // Tool Guidance Spacing instead of using toolWidth
        private void nudToolGuidanceSpacing_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setToolSteer.toolGuidanceSpacing = (double)nudToolGuidanceSpacing.Value;

            if (Settings.Tool.setToolSteer.passesPerReference == 0)
            {
                Settings.Tool.setToolSteer.toolGuidanceSpacing = nudToolGuidanceSpacing.Value = 0;
            }
            else
            {
                //fix the tool width
                Settings.Tool.setToolSteer.toolGuidanceSpacing = (double)nudToolGuidanceSpacing.Value;
                if (Settings.Tool.setToolSteer.passesPerReference % 2 == 0) Settings.Tool.setToolSteer.toolGuidanceSpacing = (double)nudToolGuidanceSpacing.Value * 0.5;
            }
        }

        private void cboxPassesPerReference_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Tool.setToolSteer.passesPerReference = cboxPassesPerReference.SelectedIndex;

            if (Settings.Tool.setToolSteer.passesPerReference == 0)
            {
                Settings.Tool.setToolSteer.toolGuidanceSpacing = nudToolGuidanceSpacing.Value = 0;
            }
            else
            {
                //fix the tool width
                Settings.Tool.setToolSteer.toolGuidanceSpacing = (double)nudToolGuidanceSpacing.Value;
                if (Settings.Tool.setToolSteer.passesPerReference % 2 == 0) Settings.Tool.setToolSteer.toolGuidanceSpacing = (double)nudToolGuidanceSpacing.Value * 0.5;
            }
        }

        #endregion

        #region Tab Config
        private void cboxIsSteerNotSlide_Click(object sender, EventArgs e)
        {
            toolSend2 = true;
            toolCounterConfig = 0;
        }

        private void hsbarManualPWM_Percent_Scroll(object sender, ScrollEventArgs e)
        {
            Settings.Tool.setToolSteer.manualSteerPWM = (byte)((double)(hsbarManualPWM_Percent.Value) * 2.5);
            lblManualPWM_Percent.Text = hsbarManualPWM_Percent.Value.ToString();
        }

        private void hsbarManualSecondsOn_Scroll(object sender, ScrollEventArgs e)
        {
            Settings.Tool.setToolSteer.manualSteerSeconds = (int)hsbarManualSecondsOn.Value;
            lblManualSecondsOn.Text = hsbarManualSecondsOn.Value.ToString();
        }

        private void cboxInvertSteer_Tool_Click(object sender, EventArgs e)
        {
            toolSend2 = true;
            toolCounterConfig = 0;
        }

        private void cboxInvertWAS_Tool_Click(object sender, EventArgs e)
        {
            toolSend2 = true;
            toolCounterConfig = 0;
        }

        #endregion

        #region Tab Antenna
        private void nudPivotToAntenna_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setToolSteer.pivotToAntennaDistance = nudPivotToAntenna.Value;
        }

        private void nudPivotToTool_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setToolSteer.PivotToToolDistance = nudPivotToTool.Value;
        }

        private void nudAntennaHeight_Tool_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setToolSteer.antennaHeight = nudAntennaHeight_Tool.Value;
        }

        private void nudAntennaOffset_Tool_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setToolSteer.antennaOffset = nudAntennaOffset_Tool.Value;
        }

        private void nudDualHeadingOffset_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setToolSteer.dualHeadingOffset = nudDualHeadingOffset.Value;

        }
        private void btnRemoveZeroOffset_Click(object sender, EventArgs e)
        {
            Settings.Tool.setToolSteer.rollZero = 0;
            lblRollZeroOffset.Text = "0.00";
            Log.EventWriter("Tool Roll Zero Offset Removed");

        }

        private void btnZeroRoll_Click(object sender, EventArgs e)
        {
            mf.ahrsTool.imuRoll += Settings.Tool.setToolSteer.rollZero;
            Settings.Tool.setToolSteer.rollZero = mf.ahrsTool.imuRoll;
            lblRollZeroOffset.Text = Settings.Tool.setToolSteer.rollZero.ToString("N2");
            Log.EventWriter("Roll Zeroed with " + Settings.Tool.setToolSteer.rollZero.ToString());
        }

        private void btnRollOffsetDown_Click(object sender, EventArgs e)
        {
            Settings.Tool.setToolSteer.rollZero -= 0.1;
            lblRollZeroOffset.Text = Settings.Tool.setToolSteer.rollZero.ToString("N2");
        }

        private void btnRollOffsetUp_Click(object sender, EventArgs e)
        {
            Settings.Tool.setToolSteer.rollZero += 0.1;
            lblRollZeroOffset.Text = Settings.Tool.setToolSteer.rollZero.ToString("N2");
        }
        #endregion
    }
}
