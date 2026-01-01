using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Twol
{
    public partial class FormToolPathRec : Form
    {
        private readonly FormGPS mf = null;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        //DLL functions to allow form dragging
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void FormToolPathRec_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public FormToolPathRec(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();

            btnRecStartStop.BackColor = mf.gydTool.isGuidanceModeRecordNewTracks ? Color.LightGreen : Color.Transparent;
            lblRec.Text = mf.gydTool.isGuidanceModeRecordNewTracks ? "Recording" : "Paused";

            if (mf.gydTool.isboundaryLine)
            {
                btnOuterInner.Image = Properties.Resources.TramOuter;
                lblOuterInner.Text = "Outer";
            }
            else
            {
                btnOuterInner.Image = Properties.Resources.TramLines;
                lblOuterInner.Text = "Inner";
            }
        }

        private void FormToolPathRec_Load(object sender, EventArgs e)
        {
            Location = Settings.User.setWindow_formNudgeLocation;
            Size = Settings.User.setWindow_formNudgeSize;
            UpdateMoveLabel();

            if (!mf.IsOnScreen(Location, Size, 1))
            {
                Top = 0;
                Left = 0;
            }
        }

        private void FormToolPathRec_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.User.setWindow_formNudgeLocation = Location;
            Settings.User.setWindow_formNudgeSize = Size;

            //save entire list
            mf.FileSaveTracks();
        }

        private void UpdateMoveLabel()
        {
            mf.Activate();
        }

        private void btnRecStartStop_Click(object sender, EventArgs e)
        {
            mf.gydTool.isGuidanceModeRecordNewTracks = !mf.gydTool.isGuidanceModeRecordNewTracks;

            if (mf.gydTool.isGuidanceModeRecordNewTracks)
            {
                btnRecStartStop.BackColor = Color.LightGreen;
                lblRec.Text = "Recording";
            }
            else
            {
                btnRecStartStop.BackColor = Color.Transparent;
                lblRec.Text = "Pause";
            }

        }

        private void bntOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblRec.Visible = !lblRec.Visible;

            lblPointsRec.Text = mf.trkTool.designPtsList.Count.ToString("N0");
        }

        private void btnOuterInner_Click(object sender, EventArgs e)
        {
            mf.gydTool.isboundaryLine = !mf.gydTool.isboundaryLine;

            if (mf.gydTool.isboundaryLine)
            {
                btnOuterInner.Image = Properties.Resources.TramOuter;
                lblOuterInner.Text = "Outer";
            }
            else
            {
                btnOuterInner.Image = Properties.Resources.TramLines;
                lblOuterInner.Text = "Inner";
            }
        }
    }
}