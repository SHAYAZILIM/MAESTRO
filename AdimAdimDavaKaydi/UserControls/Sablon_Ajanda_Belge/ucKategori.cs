using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge
{
    public partial class ucKategori : DevExpress.XtraEditors.XtraUserControl
    {
        private VList<per_TDIE_KOD_SABLON_ALT_KATEGORI> KategoriDataDource = new VList<per_TDIE_KOD_SABLON_ALT_KATEGORI>();

        public ucKategori()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //KAYDET
            DialogResult res = MessageBox.Show("De�i�iklikler kaydedilsin mi?", "Kaydet", MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                try
                {
                    //Kapat�ld�. Grid �zerinde alanlar yok ve kay�t i�lemleri grid �zerinden yap�lm�yor. Eksik i�lemler var. (Kay�t formu, grid alanlar� gibi. Merve
                    //DataRepository.TDIE_KOD_SABLON_ALT_KATEGORIProvider.DeepSave(KategoriDataDource);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //S�L
            DialogResult res = MessageBox.Show("De�i�iklikler silinsin mi?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                try
                {
                    KategoriDataDource.ForEach(item => DataRepository.TDIE_KOD_SABLON_ALT_KATEGORIProvider.Delete(item.ID));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ucKategori_Load(object sender, EventArgs e)
        {
            //LOAD
            if (!this.DesignMode)
            {
                if (BelgeUtil.Inits._SablonAltKategoriGetir == null) BelgeUtil.Inits._SablonAltKategoriGetir = DataRepository.per_TDIE_KOD_SABLON_ALT_KATEGORIProvider.GetAll();
                KategoriDataDource = BelgeUtil.Inits._SablonAltKategoriGetir;
                gridSablonKategori.DataSource = KategoriDataDource;
            }
        }
    }
}