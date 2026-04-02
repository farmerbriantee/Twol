using System;
using System.Drawing;
using System.Windows.Forms;

namespace Twol
{
    public partial class OverlayForm : Form
    {
        public OverlayForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.BackColor = Color.FromArgb(26,26,26);  // Semi-transparent black
            this.TransparencyKey = Color.Black;  // Makes only the black background transparent
        }

        public const int WS_EX_NOACTIVATE = 0x08000000;
        public const int size = 9;

        protected override CreateParams CreateParams
        {
            get
            {
                var parameters = base.CreateParams;
                parameters.ExStyle |= WS_EX_NOACTIVATE;
                return parameters;
            }
        }

        public new void SetDesktopBounds(int x, int y, int width, int height)
        {
            base.SetDesktopBounds(x + size, y + size, width - size * 2, height - size * 2);
        }

        private void OverlayForm_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 1;  // Adjust the border thickness as needed
            Color borderColor = Color.FromArgb(98,98,98);  // Choose your preferred color

            using (Pen borderPen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawRectangle(borderPen, new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1));
            }
        }

        private void OverlayForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
