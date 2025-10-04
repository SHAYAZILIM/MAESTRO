using System;
using System.Windows.Forms;

namespace AVPUpdater
{
    public partial class frmFTPBilgileri : Form
    {
        public frmFTPBilgileri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAyarlar.Degiskenler.ftpUid = textBox1.Text;
            frmAyarlar.Degiskenler.ftpPwd = textBox2.Text;
            frmAyarlar.Degiskenler.Kaydet();
            this.Close();
        }

        private void frmFTPBilgileri_Load(object sender, EventArgs e)
        {
            textBox1.Text = frmAyarlar.Degiskenler.ftpUid;
            textBox2.Text = frmAyarlar.Degiskenler.ftpPwd;
        }
    }
}