using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmKlasorGenelNotlar : AvpXtraForm
    {
        #region <MB-20102601> LOAD

        public frmKlasorGenelNotlar()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public bool Duzenle;

        public int projeID;

        private AvukatProLib.Arama.AV001_TDIE_BIL_PROJE_GENEL_NOT _MyDataSource;

        private AvukatProLib.Arama.AvpDataContext db =
            new AvukatProLib.Arama.AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

        private AV001_TDI_BIL_CARI kullanici;

        [Browsable(false)]
        public AvukatProLib.Arama.AV001_TDIE_BIL_PROJE_GENEL_NOT MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (value != null)
                {
                    txtNotAlan.Text = MyDataSource.KONTROL_KIM;
                    txtNotTarihi.Text = MyDataSource.KAYIT_TARIHI.ToString();
                    memProjeNotlar.Text = MyDataSource.NOTLAR;
                }
            }
        }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmKlasorGenelNotlar_Button_Kaydet_Click;
        }

        private void frmKlasorGenelNotlar_Load(object sender, EventArgs e)
        {
            NotAlanNotTarihiYukle();
        }

        #endregion <MB-20102601> LOAD

        #region <MB-20102601> METHODS

        private void NotAlanNotTarihiYukle()
        {
            if (AvukatProLib.Kimlik.Bilgi.CARI_ID.HasValue)
            {
                kullanici = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(AvukatProLib.Kimlik.Bilgi.CARI_ID.Value);
                //db.AV001_TDI_BIL_CARIs.Where(vi => vi.ID == AvukatProLib.Kimlik.Bilgi.CARI_ID.Value).FirstOrDefault();

                txtNotAlan.Text = kullanici.AD;
                txtNotTarihi.Text = DateTime.Now.ToString();
            }
        }

        #endregion <MB-20102601> METHODS

        #region <MB-20102601> EVENTS

        private void frmKlasorGenelNotlar_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (!Duzenle)
            {
                AvukatProLib.Arama.AV001_TDIE_BIL_PROJE_GENEL_NOT genelNot = new AvukatProLib.Arama.AV001_TDIE_BIL_PROJE_GENEL_NOT();

                if (kullanici != null)
                {
                    genelNot.KONTROL_KIM_ID = DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.GetByCARI_ID(kullanici.ID)[0].ID;
                    genelNot.KONTROL_KIM = kullanici.AD;
                }
                genelNot.KAYIT_TARIHI = Convert.ToDateTime(txtNotTarihi.Text);
                genelNot.NOTLAR = memProjeNotlar.Text;
                genelNot.KONTROL_NE_ZAMAN = DateTime.Now;
                genelNot.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                genelNot.PROJE_ID = projeID;

                try
                {
                    db.AV001_TDIE_BIL_PROJE_GENEL_NOTs.InsertOnSubmit(genelNot);
                    db.SubmitChanges();
                    XtraMessageBox.Show("Kayıt işlemi başarı ile gerçekleştirildi.", "BİLGİ", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
            else
            {
                var sonuc = db.AV001_TDIE_BIL_PROJE_GENEL_NOTs.Where(vi => vi.ID == MyDataSource.ID).FirstOrDefault();
                if (sonuc != null)
                {
                    sonuc.NOTLAR = memProjeNotlar.Text;
                    sonuc.KAYIT_TARIHI = Convert.ToDateTime(txtNotTarihi.Text);
                    db.SubmitChanges();

                    XtraMessageBox.Show("Düzenleme işlemi başarı ile gerçekleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    XtraMessageBox.Show("Uygun kayıt bulunamadı", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        #endregion <MB-20102601> EVENTS
    }
}