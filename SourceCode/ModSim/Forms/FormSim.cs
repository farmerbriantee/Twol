using ModSim.Properties;
using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Timers;

namespace ModSim
{
    public partial class FormSim : Form
    {
        private static System.Timers.Timer timer;
        public FormSim()
        {
            InitializeComponent();
        }

        //First run
        private void FormSim_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer(94); 
            timer.Elapsed += simTimer_Tick;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.SynchronizingObject = this;

            cboxGGA.Checked = Settings.Default.isGGA;
            cboxVTG.Checked = Settings.Default.isVTG;
            cboxAVR.Checked = Settings.Default.isAVR;
            cboxHDT.Checked = Settings.Default.isHDT;
            cboxRMC.Checked = Settings.Default.isRMC;
            cboxOGI.Checked = Settings.Default.isOGI;
            cboxNDA.Checked = Settings.Default.isNDA;
            cboxKSXT.Checked = Settings.Default.isKSXT;

            latitude = Settings.Default.setGPS_SimLatitude;
            nudLat.Value = (decimal)Settings.Default.setGPS_SimLatitude;
            longitude = Settings.Default.setGPS_SimLongitude;
            nudLon.Value = (decimal)Settings.Default.setGPS_SimLongitude;

            lblIPSet1.Text = Properties.Settings.Default.etIP_SubnetOne.ToString();
            lblIPSet2.Text = Properties.Settings.Default.etIP_SubnetTwo.ToString();
            lblIPSet3.Text = Properties.Settings.Default.etIP_SubnetThree.ToString();

            lblScanReply.Text = "No";

            LoadUDPNetwork();
            timer.Start();
        }

        private void FormSim_FormClosing(object sender, FormClosingEventArgs e)
        {
            //save settings before exit
            Settings.Default.isGGA = cboxGGA.Checked;
            Settings.Default.isVTG = cboxVTG.Checked;
            Settings.Default.isAVR = cboxAVR.Checked;
            Settings.Default.isHDT = cboxHDT.Checked;
            Settings.Default.isRMC = cboxRMC.Checked;
            Settings.Default.isOGI = cboxOGI.Checked;
            Settings.Default.isNDA = cboxNDA.Checked;
            Settings.Default.isKSXT = cboxKSXT.Checked;

            Settings.Default.Save();

            if (UDPSocket != null)
            {
                try
                {
                    UDPSocket.Shutdown(SocketShutdown.Both);
                }
                finally { UDPSocket.Close(); }
            }
        }

        private void btnRelayTest_Click(object sender, EventArgs e)
        {
                helloFromAgIO[7] = 1;
        }

        private void lblIP_Click(object sender, EventArgs e)
        {
            lblIP.Text = "";
            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily == AddressFamily.InterNetwork)
                {
                    _ = IPA.ToString();
                    lblIP.Text += IPA.ToString() + "\r\n";
                }
            }
        }

        private void btn10Hz_Click(object sender, EventArgs e)
        {
            if (timer.Interval == 45)
            {
                timer.Interval = 92;
                btn10Hz.Text = "10 Hz";
            }
            else
            {
                timer.Interval = 45;
                btn10Hz.Text = "20 Hz";
            }

        }
    }
}

