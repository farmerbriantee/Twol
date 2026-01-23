using System.Windows.Forms;

namespace Twol
{
    public partial class FormYesNo : Form
    {
        public FormYesNo(string messageStr)
        {
            InitializeComponent();

            lblMessage2.Text = messageStr;
        }
    }
}