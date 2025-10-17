using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twol
{
    public partial class FormEthernet : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        public FormEthernet(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            nudFirstIP.Controls[0].Enabled = false;
            nudSecndIP.Controls[0].Enabled = false;
            nudThirdIP.Controls[0].Enabled = false;
        }

        private void FormUDp_Load(object sender, EventArgs e)
        {
            cboxIsUDPOn.Checked = Settings.IO.setUDP_isOn;
            cboxIsUDPOn.Text = cboxIsUDPOn.Checked ? "UDP On" : "UDP Off";

            //cboxIsSendNMEAToUDP.Checked = Settings.IO.setUDP_isSendNMEAToUDP;

            //nudSub1.Value = Settings.IO.etIP_SubnetOne;
            //nudSub2.Value = Settings.IO.etIP_SubnetTwo;
            //nudSub3.Value = Settings.IO.etIP_SubnetThree;

            nudFirstIP.Value = Settings.IO.eth_loopOne;
            nudSecndIP.Value = Settings.IO.eth_loopTwo;
            nudThirdIP.Value = Settings.IO.eth_loopThree;
            nudFourthIP.Value = Settings.IO.eth_loopFour;

            if (!cboxIsUDPOn.Checked) cboxIsUDPOn.BackColor = System.Drawing.Color.Salmon;
        }

        private void nudFirstIP_Click(object sender, EventArgs e)
        {
            //mf.KeypadToNUD((NumericUpDown)sender, this);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Settings.IO.etIP_SubnetOne = (byte)nudSub1.Value;
            //Settings.IO.etIP_SubnetTwo = (byte)nudSub2.Value;
            //Settings.IO.etIP_SubnetThree = (byte)nudSub3.Value;

            Settings.IO.eth_loopOne = (byte)nudFirstIP.Value;
            Settings.IO.eth_loopTwo = (byte)nudSecndIP.Value;
            Settings.IO.eth_loopThree = (byte)nudThirdIP.Value;
            Settings.IO.eth_loopFour = (byte)nudFourthIP.Value;

            Settings.IO.setUDP_isOn = cboxIsUDPOn.Checked;
            //Settings.IO.setUDP_isSendNMEAToUDP = cboxIsSendNMEAToUDP.Checked;

            Log.EventWriter("Program Reset: Start Ethernet Selected");

            Settings.IO.Save();
            Close();
            mf.YesMessageBox("Restart to Enable UDP Networking Features");
            mf.ExitShutdown();
        }

        private void cboxIsUDPOn_Click(object sender, EventArgs e)
        {
            cboxIsUDPOn.Text = cboxIsUDPOn.Checked ? "UDP Is On" : "UDP Is Off";
            Log.EventWriter("UDP Turned on, Etherent Form");
        }
    }
}