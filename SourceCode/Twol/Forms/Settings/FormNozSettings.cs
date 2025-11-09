//Please, if you use this, share the improvements

using System;
using System.Windows.Forms;

namespace Twol
{
    public partial class FormNozSettings : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        //Nozzz constructor
        public FormNozSettings(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            //Language keys
            this.Text = "Sprayer Settings";
        }

        private void FormDisplaySettings_Load(object sender, EventArgs e)
        {

            if (Settings.User.isMetric)
            {
                nudRateSet1.DecimalPlaces = 0;
                nudRateSet2.DecimalPlaces = 0;
            }
            else
            {
                nudRateSet1.DecimalPlaces = 1;
                nudRateSet2.Maximum = 99.9;
            }

            nudRateSet1.Maximum = 999;
            nudRateSet1.Minimum = 1;
            nudRateSet2.Maximum = 999;
            nudRateSet2.Minimum = 1;
            nudRateSet1.Value = Settings.Tool.setNozz.rateSet1;
            nudRateSet2.Value = Settings.Tool.setNozz.rateSet2;
            nudSprayMinPressure.Value = Settings.Tool.setNozz.pressureMin;

            lblRateSet1.Text = (mf.nozz.rateTextArr[Settings.Tool.setNozz.unitsIdx]);
            lblRateSet2.Text = (mf.nozz.rateTextArr[Settings.Tool.setNozz.unitsIdx]);
            lblAppliedVolume.Text = (mf.nozz.unitsTextArr[Settings.Tool.setNozz.unitsIdx]) + " Applied";

            nudTankVolume.Value = Settings.Tool.setNozz.unitsTankStart;
            nudZeroVolume.Value = Settings.Tool.setNozz.unitsApplied;

            nudNudge.Value = Settings.Tool.setNozz.rateNudge;
            nudRateAlarmPercent.Value = Settings.Tool.setNozz.rateAlarmPercent * 100;
        }

        private void nudSprayRateSet1_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setNozz.rateSet1 = nudRateSet1.Value;
        }

        private void nudSprayRateSet2_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setNozz.rateSet2 = nudRateSet2.Value;
        }

        private void nudSprayMinPressure_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setNozz.pressureMin = (int)nudSprayMinPressure.Value;

            PGN_226.pgn[PGN_226.minPressure] = unchecked((byte)(Settings.Tool.setNozz.pressureMin));

            mf.SendUDPMessage(PGN_226.pgn, mf.epModule);
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            PGN_225.pgn[PGN_225.zeroTankVolumeLo] = 0;
            PGN_225.pgn[PGN_225.zeroTankVolumeHi] = 0;

            Close();
        }

        private void nudTankVolume_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setNozz.unitsTankStart = (int)nudTankVolume.Value;
        }

        private void nudZeroVolume_ValueChanged(object sender, EventArgs e)
        {
            if (nudZeroVolume.Value < 2)
            {
                Settings.Tool.setNozz.unitsApplied = 0;

                PGN_225.pgn[PGN_225.zeroTankVolumeLo] = 1;
                PGN_225.pgn[PGN_225.zeroTankVolumeHi] = 0;

                mf.SendUDPMessage(PGN_225.pgn, mf.epModule);

                PGN_225.pgn[PGN_225.zeroTankVolumeLo] = 0;
                PGN_225.pgn[PGN_225.zeroTankVolumeHi] = 0;
            }
            else
            {
                Settings.Tool.setNozz.unitsApplied = (double)nudZeroVolume.Value;

                int vol = (int)nudZeroVolume.Value;

                PGN_225.pgn[PGN_225.zeroTankVolumeHi] = unchecked((byte)(vol >> 8));
                PGN_225.pgn[PGN_225.zeroTankVolumeLo] = unchecked((byte)(vol));

                mf.SendUDPMessage(PGN_225.pgn, mf.epModule);

                PGN_225.pgn[PGN_225.zeroTankVolumeLo] = 0;
                PGN_225.pgn[PGN_225.zeroTankVolumeHi] = 0;
            }
        }

        private void btnZeroVolume_Click(object sender, EventArgs e)
        {
            Settings.Tool.setNozz.unitsApplied = 0;
            nudZeroVolume.Value = 0;

            PGN_225.pgn[PGN_225.zeroTankVolumeLo] = 1;
            PGN_225.pgn[PGN_225.zeroTankVolumeHi] = 0;

            mf.SendUDPMessage(PGN_225.pgn, mf.epModule);

            PGN_225.pgn[PGN_225.zeroTankVolumeLo] = 0;
            PGN_225.pgn[PGN_225.zeroTankVolumeHi] = 0;
        }

        private void nudNudge_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setNozz.rateNudge = nudNudge.Value;
        }

        private void nudRateAlarmPercent_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.setNozz.rateAlarmPercent = nudRateAlarmPercent.Value * 0.01;
        }
    }
}