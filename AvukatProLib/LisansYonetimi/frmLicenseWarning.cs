using System;
using System.Windows.Forms;

namespace AvukatProLib.LisansYonetimi
{
    public partial class frmLicenseWarning : DevExpress.XtraEditors.XtraForm
    {
        public frmLicenseWarning(string message)
        {
            InitializeComponent();
            lblMessage.Text = message;
        }

        public frmLicenseWarning(string message, string licenseKey)
        {
            InitializeComponent();
            this.licenseKey = licenseKey;
            lblMessage.Text = message;
        }

        public frmLicenseWarning(string message, string licenseKey, bool validationRequired)
        {
            InitializeComponent();
            lblMessage.Text = message;
            this.licenseKey = licenseKey;
            this.validationRequired = validationRequired;
        }

        public bool validationRequired = true;
        private string licenseKey = string.Empty;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (validationRequired) Environment.Exit(1);
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            using (frmLicenseActivation frmLicense = new frmLicenseActivation(this.licenseKey))
            {
                this.Hide();
                if (frmLicense.ShowDialog() == DialogResult.OK) validationRequired = false;
            }
            this.Close();
        }

        private void btnAskLater_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void frmLicenseWarning_Load(object sender, EventArgs e)
        {
            if (validationRequired) btnAskLater.Visible = false;
        }
    }
}