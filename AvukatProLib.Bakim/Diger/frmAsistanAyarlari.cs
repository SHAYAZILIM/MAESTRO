using AvukatProLib.Util;
using System;

namespace AvukatProLib.Bakim
{
    public partial class frmAsistanAyarlari : DevExpress.XtraEditors.XtraForm
    {
        public frmAsistanAyarlari()
        {
            InitializeComponent();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            Metot metot = new Metot();
            metot.AcilisKontrolu(cbKontrol.Checked, Stringler.ProgramIsmi);
        }

        private void frmAsistanAyarlari_Load(object sender, EventArgs e)
        {
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            cbKontrol.Enabled = true;
        }
    }
}