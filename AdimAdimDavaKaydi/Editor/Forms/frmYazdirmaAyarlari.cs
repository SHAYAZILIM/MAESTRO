using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;

namespace AdimAdimDavaKaydi.Editor.Forms
{
    public partial class frmYazdirmaAyarlari : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmYazdirmaAyarlari()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ucSablonYazdirmaSecim1.Save())
            {
                XtraMessageBox.Show("Kaytdetme iþleminde Hata ! ");
            }
        }
    }
}