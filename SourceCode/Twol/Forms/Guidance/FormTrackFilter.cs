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

        private readonly int[] modes = { -2, -1, 2, 4, 99 };
        private int modeSet = 4;

        private void FormToolControl_Load(object sender, EventArgs e)
        {
            Location = Settings.User.setWindow_formToolControlLocation;

            if (!mf.IsOnScreen(Location, Size, 1))
            {
                Top = 0;
                Left = 0;
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

        private void btnOuterInner_Click(object sender, EventArgs e)
        {
            modeSet++;
            if (modeSet > 3) modeSet = 0;

            switch (modeSet)
            {
                case 0:
                    btnOuterInner.BackgroundImage = Properties.Resources.FilterInnerToolLines;
                    for (int i = 0; i < mf.trks.gArr.Count; i++)
                    {
                        if (mf.trks.gArr[i].mode == TrackMode.toolLineInner) mf.trks.gArr[i].isVisible = true;
                        else mf.trks.gArr[i].isVisible = false;
                    }
                    break;

                case 1:
                    btnOuterInner.BackgroundImage = Properties.Resources.FilterOuterToolLines;
                    for (int i = 0; i < mf.trks.gArr.Count; i++)
                    {
                        if (mf.trks.gArr[i].mode == TrackMode.toolLineOuter) mf.trks.gArr[i].isVisible = true;
                        else mf.trks.gArr[i].isVisible = false;
                    }
                    break;

                case 2:
                    btnOuterInner.BackgroundImage = Properties.Resources.FilterNoToolLines;
                    for (int i = 0; i < mf.trks.gArr.Count; i++)
                    {
                        if (mf.trks.gArr[i].mode > TrackMode.None) mf.trks.gArr[i].isVisible = true;
                        else mf.trks.gArr[i].isVisible = false;
                    }
                    break;

                case 3:
                    btnOuterInner.BackgroundImage = Properties.Resources.FilterAllToolLines;
                    for (int i = 0; i < mf.trks.gArr.Count; i++)
                    {
                        mf.trks.gArr[i].isVisible = true;
                    }
                    break;

                default:
                    break;
            }

            mf.trks.isTrackValid = false;
            this.Focus();
            mf.Activate();
        }
    }
}