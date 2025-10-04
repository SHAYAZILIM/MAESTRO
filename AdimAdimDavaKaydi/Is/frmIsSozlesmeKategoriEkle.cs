using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Is
{
    public partial class frmIsSozlesmeKategoriEkle : Form
    {
        public string KategoriName = string.Empty;

        private TDI_KOD_SOZLESME_KATEGORILERI _MyKategori;

        public frmIsSozlesmeKategoriEkle()
        {
            InitializeComponent();
        }

        public TDI_KOD_SOZLESME_KATEGORILERI MyKategori
        {
            get { return _MyKategori; }
            set
            {
                _MyKategori = value;
                if (_MyKategori == null)
                    _MyKategori = new TDI_KOD_SOZLESME_KATEGORILERI();
                _MyKategori.ADMIN_KAYIT_MI = false;
                _MyKategori.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                _MyKategori.KONTROL_NE_ZAMAN = DateTime.Now;
                if (!string.IsNullOrEmpty(KategoriName))
                    txtIsKategori.Text = KategoriName.ToUpper();

                _MyKategori.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                _MyKategori.SUBE_KOD_ID = AvukatProLib.Kimlik.SubeKodu;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            var Ad = DataRepository.TDI_KOD_SOZLESME_KATEGORILERIProvider.GetByAD(txtIsKategori.Text);
            if (Ad == null)
            {
                MyKategori.ACIKLAMA = memAciklama.Text;
                MyKategori.AD = txtIsKategori.Text;
                TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    trans.BeginTransaction();
                    DataRepository.TDI_KOD_SOZLESME_KATEGORILERIProvider.DeepSave(trans, MyKategori);
                    trans.Commit();
                }
                catch
                {
                    if (trans.IsOpen)
                        trans.Commit();
                }
            }
            else
                XtraMessageBox.Show("Girdiğiniz Kategori Sistemde Mevcuttur. Kayıt İşlemi Gerçekleşemez");
        }
    }
}