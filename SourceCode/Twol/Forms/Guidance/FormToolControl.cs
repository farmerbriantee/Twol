using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Twol.Classes;

namespace Twol
{
    public partial class FormToolControl : Form
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

        public FormToolControl(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();

            btnRecStartStop.BackColor = mf.gydTool.isGuidanceModeRecordNewTracks ? Color.LightGreen : Color.Transparent;

            if (mf.gydTool.isboundaryLine)
            {
                btnOuterInner.Image = Properties.Resources.TramOuter;
            }
            else
            {
                btnOuterInner.Image = Properties.Resources.TramLines;
            }
        }

        private void FormToolPathRec_Load(object sender, EventArgs e)
        {
            Location = Settings.User.setWindow_recordToolTracksLocation;
            Size = Settings.User.setWindow_formRecordToolTracksSize;

            if (!mf.IsOnScreen(Location, Size, 1))
            {
                Top = 0;
                Left = 0;
            }
        }

        private void FormToolPathRec_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.User.setWindow_recordToolTracksLocation = Location;
            Settings.User.setWindow_formRecordToolTracksSize = Size;

            //save entire list
            mf.FileSaveTracks();
        }

        private void btnRecStartStop_Click(object sender, EventArgs e)
        {
            mf.gydTool.isGuidanceModeRecordNewTracks = !mf.gydTool.isGuidanceModeRecordNewTracks;

            if (mf.gydTool.isGuidanceModeRecordNewTracks)
            {
                btnRecStartStop.BackColor = Color.LightGreen;
            }
            else
            {
                btnRecStartStop.BackColor = Color.Transparent;
            }
            mf.Activate();
        }

        private void bntOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mf.gydTool.isRecordingToolLine)
            {
                if (btnRecStartStop.BackColor == Color.Green)
                {
                    btnRecStartStop.BackColor = Color.LightGreen;
                }
                else
                {
                    btnRecStartStop.BackColor = Color.Green;
                }
            }
            else
            {
                if (mf.gydTool.isGuidanceModeRecordNewTracks) btnRecStartStop.BackColor = Color.LightGreen;
                else btnRecStartStop.BackColor = Color.Transparent;
            }
        }

        private void btnOuterInner_Click(object sender, EventArgs e)
        {
            mf.gydTool.isboundaryLine = !mf.gydTool.isboundaryLine;

            if (mf.gydTool.isboundaryLine)
            {
                btnOuterInner.Image = Properties.Resources.TramOuter;
            }
            else
            {
                btnOuterInner.Image = Properties.Resources.TramLines;
            }
            mf.Activate();
        }
    }
}