using System;
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

        public FormToolPathRec(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();

            if (mf.gydTool.isboundaryLine)
            {
                btnOuterInner.BackgroundImage = Properties.Resources.FilterOuterToolLines;
            }
            else
            {
                btnOuterInner.BackgroundImage = Properties.Resources.FilterInnerToolLines;
            }
        }

        private void FormToolPathRec_Load(object sender, EventArgs e)
        {
            Location = Settings.User.setWindow_recordToolTracksLocation;

            if (!mf.IsOnScreen(Location, Size, 1))
            {
                Top = 0;
                Left = 0;
            }
        }

        private void FormToolPathRec_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.User.setWindow_recordToolTracksLocation = Location;

            //save entire list
            mf.FileSaveTracks();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void btnOuterInner_Click(object sender, EventArgs e)
        {
            mf.gydTool.isboundaryLine = !mf.gydTool.isboundaryLine;

            if (mf.gydTool.isboundaryLine)
            {
                btnOuterInner.BackgroundImage = Properties.Resources.FilterOuterToolLines;
            }
            else
            {
                btnOuterInner.BackgroundImage = Properties.Resources.FilterInnerToolLines;
            }

            mf.trks.isTrackValid = false;
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