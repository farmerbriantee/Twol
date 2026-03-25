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
            //this.BackColor = Color.Black;
            //this.TransparencyKey = Color.Black;

            Location = Settings.User.setWindow_formToolControlLocation;

            if (!mf.IsOnScreen(Location, Size, 1))
            {
                Top = 0;
                Left = 0;
            }

            SetButtons();
        }

        private void SetButtons()
        {
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
                Size = new System.Drawing.Size(60, 353);
            }
            else
            {
                Size = new System.Drawing.Size(60, 229);
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
            int vizzy = 0;

            for (int i = 0; i < mf.trks.gArr.Count; i++)
            {
                if (mf.trks.gArr[i].isVisible)
                {
                    vizzy++;
                    break;
                }
            }

            isOn = vizzy == 0;

            for (int i = 0; i < mf.trks.gArr.Count; i++)
            {
                mf.trks.gArr[i].isVisible = isOn;
            }
            mf.trks.GetNextTrack();
            mf.NotifyTrackChange();
            mf.PanelUpdateRightAndBottom();
            SetButtons();
            mf.Activate();
        }

        private void btnField_Click(object sender, EventArgs e)
        {
            foreach (CTrk item in mf.trks.gArr)
            {
                item.isVisible = !item.isOuter;
            }

            mf.trks.GetNextTrack();
            mf.NotifyTrackChange();
            mf.PanelUpdateRightAndBottom();
            SetButtons();
            mf.Activate();
        }

        private void btnBnd_Click(object sender, EventArgs e)
        {
            foreach (CTrk item in mf.trks.gArr)
            {
                item.isVisible = item.isOuter || item.mode == TrackMode.Polygon;
            }
            mf.trks.GetNextTrack();
            mf.NotifyTrackChange();
            mf.PanelUpdateRightAndBottom();
            SetButtons();
            mf.Activate();
        }

        private void btnToolInner_Click(object sender, EventArgs e)
        {
            foreach (CTrk item in mf.trks.gArr)
            {
                item.isVisible = (item.mode == TrackMode.toolLineInner);
            }
            mf.trks.GetNextTrack();
            mf.NotifyTrackChange();
            mf.PanelUpdateRightAndBottom();
            SetButtons();
            mf.Activate();
        }

        private void btnToolOuter_Click(object sender, EventArgs e)
        {
            foreach (CTrk item in mf.trks.gArr)
            {
                item.isVisible = (item.mode == TrackMode.toolLineOuter);
            }
            mf.trks.GetNextTrack();
            mf.NotifyTrackChange();
            mf.PanelUpdateRightAndBottom();
            SetButtons();
            mf.Activate();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}