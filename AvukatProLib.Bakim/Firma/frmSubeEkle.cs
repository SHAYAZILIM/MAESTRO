using AvukatProLib.Bakim.Resources;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Windows.Forms;

namespace AvukatProLib.Bakim.Firma
{
    public partial class frmSubeEkle : DevExpress.XtraEditors.XtraForm
    {
        public frmSubeEkle()
        {
            InitializeComponent();
        }

        private string Buro;

        private TDIE_BIL_KULLANICI_SUBELERI sube = new TDIE_BIL_KULLANICI_SUBELERI();

        public DialogResult ShowDialog(string SubeAdi)
        {
            Buro = SubeAdi;

            this.MdiParent = null;
            return this.ShowDialog();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TransactionManager trans = new TransactionManager(Kimlikci.Kimlik.SirketBilgisi.ConStr);

            try
            {
                if (!string.IsNullOrEmpty(txtBuroAdi.Text))
                {
                    sube.KONTROL_KIM_ID = 1;
                    sube.KONTROL_KIM = "AVUKATPRO";

                    trans.BeginTransaction();
                    DataRepository.TDIE_BIL_KULLANICI_SUBELERIProvider.DeepSave(trans, sube);
                    trans.Commit();
                    MessageBox.Show("Büro Baþarýyla Eklenmiþtir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Büro Alanýný Boþ Geçmeyiniz");
                }
            }
            catch 
            {
                MessageBox.Show("Kayýt esnasýnda bir hata ile karþýlaþýldý");
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            txtBuroAdi.Text = "";
        }

        private void DataBindings(TDIE_BIL_KULLANICI_SUBELERI bndBuro)
        {
            txtBuroAdi.DataBindings.Clear();
            txtBuroAdi.DataBindings.Add("TEXT", bndBuro, "SUBE_ADI", true);
            rLueBagliBuro.DataBindings.Clear();
            rLueBagliBuro.DataBindings.Add("EditValue", bndBuro, "SUBE_KOD_ID", true);
            bndBuro.SUBE_KODU = "1";
            bndBuro.KAYIT_TARIHI = DateTime.Now;
            bndBuro.KONTROL_KIM = "AVUKATPRO";
            bndBuro.KONTROL_KIM_ID = Kimlikci.Kimlik.Bilgi.ID;
            bndBuro.CARI_SAYAC = 1;
        }

        private void frmSubeEkle_Load(object sender, EventArgs e)
        {
            //bndBuro.DataSource = DataRepository.TDIE_BIL_KULLANICI_SUBELERIProvider.GetAll();
            Inits.SubeGetir(rLueBagliBuro.Properties);
            DataBindings(sube);
            txtBuroAdi.Text = Buro;
        }
    }
}