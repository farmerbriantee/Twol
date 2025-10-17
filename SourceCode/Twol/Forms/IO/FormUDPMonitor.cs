using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Twol
{
    public partial class FormUDPMonitor : Form
    {
        //class variables
        private readonly FormGPS mf = null;
        private bool logOn = false;

        public FormUDPMonitor(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void FormUDp_Load(object sender, EventArgs e)
        {
            mf.isUDPMonitorOn = true;
            timer1.Enabled = true;
            logOn = true;
        }

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            mf.isUDPMonitorOn = false;
            Close();
        }

        private void FormUDPMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            mf.isUDPMonitorOn = false;
            mf.isGPSLogOn = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxRcv.Text = "";
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            try
            {
                // Toggle local logging flag
                logOn = !logOn;

                // Only enable monitoring if we have a valid main form reference
                bool enable = logOn && mf != null;

                // Update main form state if available
                if (mf != null)
                {
                    mf.isUDPMonitorOn = enable;
                }

                // Enable/disable timer responsible for appending UDP data
                timer1.Enabled = enable;

                Action updateButton = () =>
                {
                    btnLog.BackColor = enable ? Color.LightGreen : Color.Salmon;
                };

                if (btnLog.InvokeRequired)
                {
                    btnLog.Invoke(updateButton);
                }
                else
                {
                    updateButton();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error toggling UDP monitor: {ex.Message}", "UDP Monitor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBoxRcv.AppendText(mf.logUDPSentence.ToString());
            mf.logUDPSentence.Clear();
        }

        private void btnLogNMEA_Click(object sender, EventArgs e)
        {
            mf.isGPSLogOn = !mf.isGPSLogOn;

            if (mf.isGPSLogOn) btnLogNMEA.BackColor = Color.LightGreen;
            else btnLogNMEA.BackColor = Color.Salmon;
        }
    }
}