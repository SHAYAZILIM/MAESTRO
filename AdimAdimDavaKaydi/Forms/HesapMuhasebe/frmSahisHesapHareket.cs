using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;

namespace AdimAdimDavaKaydi.Forms.HesapMuhasebe
{
    public partial class frmSahisHesapHareket : AvpXtraForm
    {
        public frmSahisHesapHareket()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public AV001_TD_BIL_HAZIRLIK _myHazirlikFoy;

        public bool Personelmi;

        private AV001_TDI_BIL_CARI_HESAP _MyDataSource;

        private int HareketAltKategori, HareketAnaKat;

        private bool isModul;

        public bool IsModul
        {
            get { return isModul; }
            set
            {
                isModul = value;
                pnlModul.Visible = value;
            }
        }

        public AV001_TDI_BIL_CARI_HESAP MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (_MyDataSource != null)
                {
                    bndCariHesapDetay.DataSource = _MyDataSource;

                    //DataRepository.AV001_TDI_BIL_CARI_HESAPProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_HESAP_DETAY>));
                    value.AV001_TDI_BIL_CARI_HESAP_DETAYCollection.AddingNew +=
                        AV001_TDI_BIL_CARI_HESAP_DETAYCollection_AddingNew;
                    grdCariHesapDetay.DataSource = value.AV001_TDI_BIL_CARI_HESAP_DETAYCollection;
                }
            }
        }

        public AV001_TD_BIL_FOY MyDavaFoy { get; set; }

        public AV001_TD_BIL_HAZIRLIK MyHazirlikFoy
        {
            get { return _myHazirlikFoy; }
            set { _myHazirlikFoy = value; }
        }

        public AV001_TI_BIL_FOY MyIcraFoy { get; set; }

        public void Show(int AltKat, int Anakat)
        {
            this.HareketAltKategori = AltKat;
            this.HareketAnaKat = Anakat;

            this.Show();
        }

        private void AV001_TDI_BIL_CARI_HESAP_DETAYCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_CARI_HESAP_DETAY detay = new AV001_TDI_BIL_CARI_HESAP_DETAY();
            detay.KAYIT_TARIHI = DateTime.Now;
            detay.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            detay.KONTROL_NE_ZAMAN = DateTime.Now;
            detay.SUBE_KOD_ID = AvukatProLib.Kimlik.SubeKodu;
            detay.ColumnChanged += detay_ColumnChanged;
            if (HareketAltKategori > 0 && HareketAnaKat > 0)
            {
                detay.HAREKET_ALT_KAREGORI_ID = HareketAltKategori;
                detay.HAREKET_ANA_KATEGORI_ID = HareketAnaKat;
            }
            switch (lueModul.Text)
            {
                case "Icra":
                    MyIcraFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)lueDosya.EditValue);
                    detay.ICRA_FOY_ID = MyIcraFoy.ID;
                    break;

                case "Dava":
                    MyDavaFoy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)lueDosya.EditValue);
                    detay.DAVA_FOY_ID = MyDavaFoy.ID;
                    break;

                case "Sorusturma":
                    MyHazirlikFoy = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID((int)lueDosya.EditValue);
                    detay.HAZIRLIK_ID = MyHazirlikFoy.ID;
                    break;

                default:
                    break;
            }
            e.NewObject = detay;
        }

        private void detay_ColumnChanged(object sender, AV001_TDI_BIL_CARI_HESAP_DETAYEventArgs e)
        {
            AV001_TDI_BIL_CARI_HESAP_DETAY DETAY = sender as AV001_TDI_BIL_CARI_HESAP_DETAY;
            if (e.Column == AV001_TDI_BIL_CARI_HESAP_DETAYColumn.BIRIM_FIYAT)
            {
                DETAY.GENEL_TOPLAM = Convert.ToDecimal(e.Value) * Convert.ToDecimal(DETAY.ADET);
            }
        }

        private void frmSahisHesapHareket_Button_Kaydet_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void frmSahisHesapHareket_Load(object sender, EventArgs e)
        {
            InitsDoldur();
            if (IsModul)
            {
                pnlCariHesapHareket.Enabled = false;
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmSahisHesapHareket_Button_Kaydet_Click;
        }

        private void InitsDoldur()
        {
            if (!Personelmi)
                BelgeUtil.Inits.perCariGetir(lueCari);
            else
                BelgeUtil.Inits.CariPersonelGetir(lueCari);

            BelgeUtil.Inits.ModulKodGetir(lueModul);
            BelgeUtil.Inits.BorcAlacakGetir(rLueBarcAlacak);
            BelgeUtil.Inits.DovizTipGetir(rLueBirimDoviz);
            BelgeUtil.Inits.MuhasebeHareketAltKategori(rLueHareketAltTur);
            BelgeUtil.Inits.HareketAnaKategoriGetir(rLueHareketAnaKat);
            BelgeUtil.Inits.OdemeTipiGetir(rLueOdemeTipi);
            BelgeUtil.Inits.ParaBicimiAyarla(spPara);
        }

        private void lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            pnlCariHesapHareket.Enabled = true;
            if (IsModul)
                MyDataSource.AV001_TDI_BIL_CARI_HESAP_DETAYCollection.AddNew();
        }

        private void lueModul_EditValueChanged(object sender, EventArgs e)
        {
            lueDosya.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur(lueModul.Text);
            lueDosya.Properties.DisplayMember = "FOY_NO";
            lueDosya.Properties.ValueMember = "ID";
        }

        private void rLueHareketAnaKat_EditValueChanging(object sender,
                                                         DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            (rLueHareketAltTur.DataSource as VList<per_TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI>).Filter =
                "ANA_KATEGORI_ID=" + e.NewValue;
        }

        private void Save()
        {
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                trans.BeginTransaction();
                DataRepository.AV001_TDI_BIL_CARI_HESAPProvider.DeepSave(trans, MyDataSource);
                trans.Commit();
                XtraMessageBox.Show("Kayıt İşleminiz Başarıyla Tamamlanmıştır");
                this.Close();
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }
    }
}