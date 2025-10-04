using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Util
{
    public partial class frmInputBox : DevExpress.XtraEditors.XtraForm
    {
        public frmInputBox()
        {
            InitializeComponent();
        }

        public string DosyaYolu
        {
            get { return txtDosyaYolu.Text; }
            set { txtDosyaYolu.Text = value; }
        }

        private FolderBrowserDialog fd;

        private void btnSec_Click(object sender, EventArgs e)
        {
            fd = new FolderBrowserDialog();
            fd.ShowNewFolderButton = true;
            fd.Description = "Dosya yolu seçiniz.";
            fd.ShowDialog();

            txtDosyaYolu.Text = fd.SelectedPath;
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DosyaYolu = string.Empty;
            this.Close();
        }
    }
}