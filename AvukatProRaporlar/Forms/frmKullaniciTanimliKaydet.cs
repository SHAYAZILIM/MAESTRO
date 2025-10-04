using AvukatProRaporlar.Lib;
using ReportPro;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AvukatProRaporlar.Forms
{
    public partial class frmKullaniciTanimliKaydet : DevExpress.XtraEditors.XtraForm
    {
        public frmKullaniciTanimliKaydet()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmKullaniciTanimliKaydet_Load);
        }

        public string GrupAdi
        {
            get
            {
                return cBoxGrup.EditValue.ToString();
            }
        }

        public string KayitAdi
        {
            get
            {
                return tBoxRaporAdi.Text;
            }
            set
            {
                tBoxRaporAdi.Text = value;
            }
        }

        public SaveReport.KayitGizlilik KayitTipi
        {
            get
            {
                bool sonuc = (bool)rGKayitTipi.Properties.Items[rGKayitTipi.SelectedIndex].Value;

                if (sonuc) return SaveReport.KayitGizlilik.Genel;
                else return SaveReport.KayitGizlilik.Ozel;
            }
        }

        protected bool GenelMi
        {
            get
            {
                bool sonuc = (bool)rGKayitTipi.Properties.Items[rGKayitTipi.SelectedIndex].Value;
                return sonuc;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (tBoxRaporAdi.Text.Length > 0 && cBoxGrup.EditValue != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                string hataMesaji = "";
                if (tBoxRaporAdi.Text.Length == 0)
                {
                    hataMesaji = "Rapor Adı Giriniz. \n";
                }
                if (cBoxGrup.EditValue == null)
                {
                    hataMesaji += "Rapor Gurubu Seçiniz.";
                }

                MessageBox.Show(hataMesaji, "Hata");
            }
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmKullaniciTanimliKaydet_Load(object sender, EventArgs e)
        {
            SaveList sv = new SaveList();

            var sonuc = sv.GroupBy(vi => vi.Grubu).Select(vi => vi.Key);
            if (sonuc != null)
            {
                if (sonuc.Dolumu())
                {
                    cBoxGrup.Properties.Items.AddRange(sonuc.ToList());
                }
            }
        }
    }
}