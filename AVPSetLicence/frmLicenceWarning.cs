using System.Windows.Forms;

namespace AVPSetLicence
{
    public partial class frmLicenceWarning : Form
    {
        public frmLicenceWarning()
        {
            InitializeComponent();
        }

        private void frmLicenceWarning_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}