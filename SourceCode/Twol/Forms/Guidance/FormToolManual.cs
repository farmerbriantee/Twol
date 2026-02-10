using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Twol
{
    public partial class FormToolManual : Form
    {
        private readonly FormGPS mf = null;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        //DLL functions to allow form dragging
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public FormToolManual(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();
        }

        private void FormToolManual_Load(object sender, EventArgs e)
        {
            Location = Settings.User.setWindow_FormToolManualLocation;

            if (!mf.IsOnScreen(Location, Size, 1))
            {
                Top = 0;
                Left = 0;
            }
        }

        private void FormToolManual_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.User.setWindow_FormToolManualLocation = Location;
        }

        private void btnToolRight_Click(object sender, EventArgs e)
        {
            mf.gydTool.manualSteerTimer += Settings.Tool.setToolSteer.manualSteerSeconds;
            mf.gydTool.isManualSteerRight = true;
        }

        private void btnToolLeft_Click(object sender, EventArgs e)
        {
            mf.gydTool.manualSteerTimer += Settings.Tool.setToolSteer.manualSteerSeconds;
            mf.gydTool.isManualSteerRight = false;
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            mf.gydTool.isZeroToolSteer = !mf.gydTool.isZeroToolSteer;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
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


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            lblManualPWM_Percent.Text = hsbarManualPWM_Percent.Value.ToString();
            lblManualSecondsOn.Text = hsbarManualSecondsOn.Value.ToString();

            if (this.Height < 60)
            {
                this.Height = 240;
            }
            else
            {
                //this.Height = 57;
            }

            mf.Activate();
        }
    }
}