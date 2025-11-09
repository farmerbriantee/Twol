//Please, if you use this, share the improvements

using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Twol
{
    public partial class FormNozConfig : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        private string unitsSet = "10";
        private string unitsActual = "0";

        //Nozzz constructor
        public FormNozConfig(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            //Language keys
            this.Text = "Controller Configuration";
        }

        private void FormDisplaySettings_Load(object sender, EventArgs e)
        {
            nudCalNumber.Value = Settings.Tool.setNozz.calNumber;
            nudSprayPressureCal.Value = Settings.Tool.setNozz.pressureCal;

            nudManualPWM.Value = Settings.Tool.setNozz.Kp;
            //nudSprayKi.Value = Settings.Tool.setNozz.Ki;

            nudFastPWM.Value = Settings.Tool.setNozz.fastPWM;
            nudSlowPWM.Value = Settings.Tool.setNozz.slowPWM;
            nudDeadbandError.Value = Settings.Tool.setNozz.deadbandError;
            nudSwitchAtFlowError.Value = Settings.Tool.setNozz.switchAtRateError;

            nudKp.Value = Settings.Tool.setNozz.Kp;
            //nudKi.Value = Settings.Tool.setNozz.Ki;

            cboxBypass.Checked = Settings.Tool.setNozz.isBypass;
            if (cboxBypass.Checked)
            {
                cboxBypass.Text = "Bypass";
            }
            else
            {
                cboxBypass.Text = "Closed";
            }

            cboxMeteringOrFlow.Checked = Settings.Tool.setNozz.isMeter;
            if (cboxMeteringOrFlow.Checked)
            {
                cboxMeteringOrFlow.Text = "Metering";
            }
            else
            {
                cboxMeteringOrFlow.Text = "Flow";
            }

            cboxSectionValve3Wire.Checked = Settings.Tool.setNozz.isSectionValve3Wire;
            if (cboxSectionValve3Wire.Checked)
            {
                cboxSectionValve3Wire.Text = "3 Wire";
            }
            else
            {
                cboxSectionValve3Wire.Text = "Reverse";
            }

            if (Settings.Tool.setNozz.isMeter)
            {
                nudFastPWM.Enabled = false;
                nudSlowPWM.Enabled = false;
                nudSwitchAtFlowError.Enabled = false;
                nudKp.Enabled = true;
            }
            else
            {
                nudFastPWM.Enabled = true;
                nudSlowPWM.Enabled = true;
                nudSwitchAtFlowError.Enabled = true;
                nudKp.Enabled = false;
            }

            comboUnits.Items.Clear();
            if (Settings.User.isMetric)
            {
                comboUnits.Items.Add("Liters");
                comboUnits.Items.Add("Kgs");
                if (Settings.Tool.setNozz.unitsIdx > 1) Settings.Tool.setNozz.unitsIdx = 0;
                comboUnits.SelectedIndex = Settings.Tool.setNozz.unitsIdx;
            }
            else
            {
                comboUnits.Items.Add("Gallons");
                comboUnits.Items.Add("Pounds");
                if (Settings.Tool.setNozz.unitsIdx > 3 || Settings.Tool.setNozz.unitsIdx < 2) Settings.Tool.setNozz.unitsIdx = 2;
                comboUnits.SelectedIndex = Settings.Tool.setNozz.unitsIdx - 2;
            }
        }

        private void nudCalNumber_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setNozz.calNumber = (int)nudCalNumber.Value;

            PGN_226.pgn[PGN_226.calNumHi] = unchecked((byte)(Settings.Tool.setNozz.calNumber >> 8));
            PGN_226.pgn[PGN_226.calNumLo] = unchecked((byte)(Settings.Tool.setNozz.calNumber));

            mf.SendUDPMessage(PGN_226.pgn, mf.epModule);
        }

        private void nudSprayPressureCal_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setNozz.pressureCal = (int)nudSprayPressureCal.Value;

            PGN_226.pgn[PGN_226.pressureCalHi] = unchecked((byte)(Settings.Tool.setNozz.pressureCal >> 8)); ;
            PGN_226.pgn[PGN_226.pressureCalLo] = unchecked((byte)(Settings.Tool.setNozz.pressureCal));

            mf.SendUDPMessage(PGN_226.pgn, mf.epModule);
        }

        private void nudFastPWM_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setNozz.fastPWM = (byte)nudFastPWM.Value;

            PGN_226.pgn[PGN_226.fastPWM] = unchecked((byte)(Settings.Tool.setNozz.fastPWM));

            mf.SendUDPMessage(PGN_226.pgn, mf.epModule);
        }

        private void nudSlowPWM_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setNozz.slowPWM = (byte)nudSlowPWM.Value;

            PGN_226.pgn[PGN_226.slowPWM] = unchecked((byte)(Settings.Tool.setNozz.slowPWM));

            mf.SendUDPMessage(PGN_226.pgn, mf.epModule);
        }

        private void nudDeadbandError_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setNozz.deadbandError = (byte)(nudDeadbandError.Value);

            PGN_226.pgn[PGN_226.deadbandError] = unchecked((byte)(Settings.Tool.setNozz.deadbandError));

            mf.SendUDPMessage(PGN_226.pgn, mf.epModule);
        }

        private void nudSwitchAtFlowError_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setNozz.switchAtRateError = (byte)(nudSwitchAtFlowError.Value);

            PGN_226.pgn[PGN_226.switchAtFlowError] = unchecked((byte)(Settings.Tool.setNozz.switchAtRateError));

            mf.SendUDPMessage(PGN_226.pgn, mf.epModule);
        }

        private void nudManualPWM_ValueChanged(object sender, EventArgs e)
        {
            //Manual PWM up and down value
            Settings.Tool.setNozz.manualRate = (byte)nudManualPWM.Value;

            PGN_225.pgn[PGN_225.rate] = unchecked((byte)(Settings.Tool.setNozz.manualRate));

            mf.SendUDPMessage(PGN_225.pgn, mf.epModule);
        }
        private void nudKp_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setNozz.Kp = (byte)(nudKp.Value);

            PGN_226.pgn[PGN_226.Kp] = unchecked((byte)(Settings.Tool.setNozz.Kp));

            mf.SendUDPMessage(PGN_226.pgn, mf.epModule);
        }

        ////private void nudKi_ValueChanged(object sender, EventArgs e)
        ////{
        ////    Settings.Tool.setNozz.Ki = (byte)(nudKi.Value);

        ////    PGN_226.pgn[PGN_226.Ki] = unchecked((byte)(Settings.Tool.setNozz.Ki));

        ////    mf.SendUDPMessage(PGN_226.pgn);
        ////}

        private void cboxSectionValve3Wire_Click(object sender, EventArgs e)
        {
            if (cboxSectionValve3Wire.Checked)
            {
                cboxSectionValve3Wire.Text = "3 Wire";
                Settings.Tool.setNozz.isSectionValve3Wire = true;
                PGN_226.pgn[PGN_226.isSectionValve3Wire] = 1;
            }
            else
            {
                cboxSectionValve3Wire.Text = "Reverse";
                Settings.Tool.setNozz.isSectionValve3Wire = false;
                PGN_226.pgn[PGN_226.isSectionValve3Wire] = 0;
            }

            Settings.Tool.setNozz.isSectionValve3Wire = Settings.Tool.setNozz.isSectionValve3Wire;

            mf.SendUDPMessage(PGN_226.pgn, mf.epModule);
        }

        private void cboxBypass_Click(object sender, EventArgs e)
        {
            if (cboxBypass.Checked)
            {
                cboxBypass.Text = "Bypass";
                Settings.Tool.setNozz.isBypass = true;

                if (Settings.Tool.setNozz.isBypass)
                    PGN_226.pgn[PGN_226.isBypass] = 1;
                else
                    PGN_226.pgn[PGN_226.isBypass] = 0;

                if (Settings.Tool.setNozz.isMeter)
                    PGN_226.pgn[PGN_226.isBypass] += 2;
            }
            else
            {
                cboxBypass.Text = "Closed";
                Settings.Tool.setNozz.isBypass = false;
            }

            if (Settings.Tool.setNozz.isBypass)
                PGN_226.pgn[PGN_226.isBypass] = 1;
            else
                PGN_226.pgn[PGN_226.isBypass] = 0;

            if (Settings.Tool.setNozz.isMeter)
                PGN_226.pgn[PGN_226.isBypass] += 2;

            mf.SendUDPMessage(PGN_226.pgn, mf.epModule);
        }

        private void cboxMeteringOrFlow_Click(object sender, EventArgs e)
        {
            if (cboxMeteringOrFlow.Checked)
            {
                cboxMeteringOrFlow.Text = "Metering";
                Settings.Tool.setNozz.isMeter = true;

                if (Settings.Tool.setNozz.isBypass)
                    PGN_226.pgn[PGN_226.isBypass] = 1;
                else
                    PGN_226.pgn[PGN_226.isBypass] = 0;

                if (Settings.Tool.setNozz.isMeter)
                    PGN_226.pgn[PGN_226.isBypass] += 2;
            }
            else
            {
                cboxMeteringOrFlow.Text = "Flow";
                Settings.Tool.setNozz.isMeter = false;
            }

            if (Settings.Tool.setNozz.isBypass)
                PGN_226.pgn[PGN_226.isBypass] = 1;
            else
                PGN_226.pgn[PGN_226.isBypass] = 0;

            if (Settings.Tool.setNozz.isMeter)
                PGN_226.pgn[PGN_226.isBypass] += 2;

            mf.SendUDPMessage(PGN_226.pgn, mf.epModule);

            if (Settings.Tool.setNozz.isMeter)
            {
                nudFastPWM.Enabled = false;
                nudSlowPWM.Enabled = false;
                nudSwitchAtFlowError.Enabled = false;
                nudKp.Enabled = true;
            }
            else
            {
                nudFastPWM.Enabled = true;
                nudSlowPWM.Enabled = true;
                nudSwitchAtFlowError.Enabled = true;
                nudKp.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnPWM.Text = mf.nozz.pwmDriveActual.ToString();
            btnFreq.Text = mf.nozz.frequency.ToString();
            DrawChart();
        }

        private void DrawChart()
        {
            unitsSet = lblUnitsSet.Text = mf.nozz.rateSet.ToString();
            unitsActual = lblUnitsActual.Text = mf.nozz.rateActual.ToString();

            double errorText = (((double)(mf.nozz.rateSet - mf.nozz.rateActual) / (double)mf.nozz.rateSet) * -100);
            if (mf.nozz.rateSet > 0.05)
                lblFlowError.Text = errorText.ToString("N1") + "%";
            else
                lblFlowError.Text = "Off";

            //chart data
            Series s = unoChart.Series["S"];
            Series w = unoChart.Series["PWM"];

            double nextX = 1;
            double nextX5 = 1;

            if (s.Points.Count > 0) nextX = s.Points[s.Points.Count - 1].XValue + 1;
            if (w.Points.Count > 0) nextX5 = w.Points[w.Points.Count - 1].XValue + 1;

            unoChart.Series["S"].Points.AddXY(nextX, unitsSet);
            unoChart.Series["PWM"].Points.AddXY(nextX5, unitsActual);

            while (s.Points.Count > 50)
            {
                s.Points.RemoveAt(0);
            }
            while (w.Points.Count > 50)
            {
                w.Points.RemoveAt(0);
            }
            unoChart.ChartAreas[0].RecalculateAxesScale();
        }

        private void FormNozConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Settings.Tool.setNozz.isAppliedUnitsNotTankDisplayed)
                mf.lbl_Volume.Text = "Tank " + (mf.nozz.unitsTextArr[Settings.Tool.setNozz.unitsIdx]);
            else
                mf.lbl_Volume.Text = "App " + (mf.nozz.unitsTextArr[Settings.Tool.setNozz.unitsIdx]);
        }

        private void comboUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Tool.setNozz.unitsIdx = comboUnits.SelectedIndex;
            if (!Settings.User.isMetric)
            {
                Settings.Tool.setNozz.unitsIdx += 2;
            }
        }
    }
}