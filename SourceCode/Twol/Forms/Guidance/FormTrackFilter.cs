using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Twol
{
    public partial class FormTrackFilter : Form
    {
        private readonly FormGPS mf = null;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        //DLL functions to allow form dragging
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void FormToolControl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public FormTrackFilter(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();
        }

        private void FormToolControl_Load(object sender, EventArgs e)
        {
            Location = Settings.User.setWindow_formToolControlLocation;

            if (!mf.IsOnScreen(Location, Size, 1))
            {
                Top = 0;
                Left = 0;
            }

            bool isToolTrksPresent = false;

            foreach (CTrk item in mf.trks.gArr)
            {
                if (item.mode == TrackMode.toolLineInner || item.mode == TrackMode.toolLineOuter)
                {
                    isToolTrksPresent = true;
                    break;

                }
            }

            if (isToolTrksPresent)
            {
                Size = new System.Drawing.Size(50, 360);
            }
            else
            {
                Size = new System.Drawing.Size(56, 260);
            }

        }

        private void FormToolControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.User.setWindow_formToolControlLocation = Location;
        }

        private void bntOk_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool isOn;
        private void btnHideShow_Click(object sender, EventArgs e)
        {
            isOn = !isOn;

            for (int i = 0; i < mf.trks.gArr.Count; i++)
            {
                mf.trks.gArr[i].isVisible = isOn;
            }
            mf.trks.GetNextTrack();
            mf.PanelUpdateRightAndBottom();
        }

        private void btnField_Click(object sender, EventArgs e)
        {
            foreach (CTrk item in mf.trks.gArr)
            {
                item.isVisible = item.name.Contains("A_Fld");
            }
            mf.trks.GetNextTrack();
            mf.PanelUpdateRightAndBottom();
        }

        private void btnBnd_Click(object sender, EventArgs e)
        {
            foreach (CTrk item in mf.trks.gArr)
            {
                item.isVisible = item.name.Contains("A_Bnd");
            }
            mf.trks.GetNextTrack();
            mf.PanelUpdateRightAndBottom();
        }

        private void btnToolInner_Click(object sender, EventArgs e)
        {
            foreach (CTrk item in mf.trks.gArr)
            {
                item.isVisible = (item.mode == TrackMode.toolLineInner);
            }
            mf.trks.GetNextTrack();
            mf.PanelUpdateRightAndBottom();
        }

        private void btnToolOuter_Click(object sender, EventArgs e)
        {
            foreach (CTrk item in mf.trks.gArr)
            {
                item.isVisible = (item.mode == TrackMode.toolLineOuter);
            }
            mf.trks.GetNextTrack();
            mf.PanelUpdateRightAndBottom();
        }
    }
}