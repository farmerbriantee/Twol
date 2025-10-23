using System;
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
        }

        private void FormUDp_Load(object sender, EventArgs e)
        {
            cboxIsUDPOn.Checked = Settings.IO.setUDP_isOn;
            cboxIsUDPOn.Text = "Tap To Enable Ethernet";

            if (!cboxIsUDPOn.Checked) cboxIsUDPOn.BackColor = System.Drawing.Color.Salmon;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cboxIsUDPOn.Checked)
            {
                Settings.IO.setUDP_isOn = true;

                Log.EventWriter("Program Reset: Start Ethernet Selected");

                Settings.IO.Save();
                Close();
                mf.YesMessageBox("Restart Twol to Enable UDP Networking Features");
                mf.ExitShutdown();
            }
            else
            {
                Close();
            }
        }

        private void cboxIsUDPOn_Click(object sender, EventArgs e)
        {
            cboxIsUDPOn.Text = cboxIsUDPOn.Checked ? "Ethernet On - Tap Ok" : "Ethernet Remains Off";
            Log.EventWriter("UDP Turned on, Etherent Form");
        }
    }
}