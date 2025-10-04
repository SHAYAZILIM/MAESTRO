using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatPro.Model.EntityClasses;
using AvukatPro.Services.Implementations;
using AvukatPro.Services.Interfaces;
using AvukatPro.Services.Messaging;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using AvukatProLib2.Data;
using AdimAdimDavaKaydi.Belge.Forms;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class frmMuvekkilOdemeleriLayout : AvpXtraForm
    {
        private int? _focusedRowHandle;
        private AvukatProLib.Extras.Modul _modul;
        private int _foyId;

        #region <MB-20102101> LOAD

        public frmMuvekkilOdemeleriLayout()
        {
            InitializeComponent();
            InitializeEvents();
            _focusedRowHandle = null;
        }

        public frmMuvekkilOdemeleriLayout(AvukatProLib.Extras.Modul modul, int foyId)
        {
            _modul = modul;
            _foyId = foyId;
            InitializeComponent();
            InitializeEvents();
            BindLookUps();

            lcItemDosya.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmMuvekkilOdemeleriLayout_Button_Kaydet_Click;
        }

        public bool TakipEkraniDisinda;

        //private AV001_TI_BIL_FOY _MyIcraFoy;

        //[Browsable(false)]
        //public AV001_TI_BIL_FOY MyIcraFoy
        //{
        //    get { return _MyIcraFoy; }
        //    set
        //    {
        //        _MyIcraFoy = value;

        //        if (value != null)
        //        {
        //            if (!TakipEkraniDisinda && MyDataSource == null || MyDataSource.Count == 0)
        //                bndMuvekkilOdemeleri.AddNew();
        //        }
        //    }
        //}

        private TList<AV001_TI_BIL_MUVEKKILE_ODEME> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TI_BIL_MUVEKKILE_ODEME> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;

                if (value != null)
                    bndMuvekkilOdemeleri.DataSource = value;
            }
        }

        private void frmMuvekkilOdemeleriLayout_Load(object sender, EventArgs e)
        {
            BindLookUps();
            lueModul.EditValue = (int)_modul;
            lueDosya.EditValue = _foyId;
            dtOdemeTarihi.EditValue = DateTime.Now.Date;
        }

        private void BindLookUps()
        {
            BelgeUtil.Inits.OdemeTipiGetir(lueOdemeTipi);
            lueOdemeTipi.EditValue = 1;
            BelgeUtil.Inits.DovizTipGetir(lueMiktarDoviz);
            lueMiktarDoviz.EditValue = 1;
            BelgeUtil.Inits.ParaBicimiAyarla(spMiktar);
            BelgeUtil.Inits.ModulKodGetir(lueModul);

            AvukatPro.Services.Implementations.DevExpressService.KasaHesapBilgileriDoldur(lueKasaHesabi);
            AvukatPro.Services.Implementations.DevExpressService.MuhatapHesapBilgilerirDoldur(lueMuhatapHesabi);
            AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(lueBelge);
        }

        #endregion <MB-20102101> LOAD

        #region <MB-20102101> KAYIT

        private void bndMuvekkilOdemeleri_AddingNew(object sender, AddingNewEventArgs e)
        {
            var muvekkileOdeme = new AV001_TI_BIL_MUVEKKILE_ODEME();

            if (lueModul.Text == "Icra")
                muvekkileOdeme.ICRA_FOY_ID = (int?)lueDosya.EditValue;
            if (lueModul.Text == "Dava")
                muvekkileOdeme.DAVA_FOY_ID = (int?)lueDosya.EditValue;
            if (lueModul.Text == "Soruşturma")
                muvekkileOdeme.HAZIRLIK_FOY_ID = (int?)lueDosya.EditValue;

            muvekkileOdeme.ODEYEN_CARI_ID = (int?)lueOdeyen.EditValue;
            muvekkileOdeme.ODENEN_CARI_ID = (int?)lueOdenen.EditValue;
            muvekkileOdeme.MIKTAR = spMiktar.Value;
            muvekkileOdeme.MIKTAR_DOVIZ_ID = (int?)lueMiktarDoviz.EditValue;
            muvekkileOdeme.KAYIT_TARIHI = DateTime.Now;
            muvekkileOdeme.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            muvekkileOdeme.KONTROL_NE_ZAMAN = DateTime.Now;
            muvekkileOdeme.SUBE_KOD_ID = AvukatProLib.Kimlik.SubeKodu;
            muvekkileOdeme.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            muvekkileOdeme.ODEME_TIP_ID = (int?)lueOdemeTipi.EditValue;
            muvekkileOdeme.ODEME_TARIHI = (DateTime)dtOdemeTarihi.EditValue;
            muvekkileOdeme.KIYMETLI_EVRAK_BILGILERI_ID = (int?)lueKiymetliEvrak.EditValue;
            muvekkileOdeme.BURO_HESAP_SAHIBI_CARI_BANKA_ID = (int?)lueKasaHesabi.EditValue;
            muvekkileOdeme.MUHATAP_HESAP_SAHIBI_CARI_BANKA_ID = (int?)lueMuhatapHesabi.EditValue;
            muvekkileOdeme.EFT_REFERANS_NO = txtEftReferansNo.Text;
            muvekkileOdeme.BANKA_DEKONT_NO = txtBankaDekontNo.Text;
            if (lueBelge.EditValue != null)
                muvekkileOdeme.BELGE_ID = (int)lueBelge.EditValue;
            else if (lueBelge.EditValue == null)
                muvekkileOdeme.BELGE_ID = null;

            if (_focusedRowHandle != null)
            {
                RCariHesapDetayliEntity row = (RCariHesapDetayliEntity)gvMuvekkilHesap.GetRow((int)_focusedRowHandle);
                muvekkileOdeme.VIRMAN_MODUL_ID = row.CariHesapHedefTip;
                if (muvekkileOdeme.VIRMAN_MODUL_ID == 1)
                    muvekkileOdeme.VIRMAN_ICRA_FOY_ID = row.FoyId;
                else if (muvekkileOdeme.VIRMAN_MODUL_ID == 2)
                    muvekkileOdeme.VIRMAN_DAVA_FOY_ID = row.FoyId;
                else if (muvekkileOdeme.VIRMAN_MODUL_ID == 3)
                    muvekkileOdeme.VIRMAN_HAZIRLIK_FOY_ID = row.FoyId;
                else if (muvekkileOdeme.VIRMAN_MODUL_ID == 5)
                    muvekkileOdeme.VIRMAN_SOZLESME_ID = row.FoyId;
            }
            muvekkileOdeme.ACIKLAMA = memMuvekkilOdemeleriAciklama.Text;

            e.NewObject = muvekkileOdeme;
        }

        private void frmMuvekkilOdemeleriLayout_Button_Kaydet_Click(object sender, EventArgs e)
        {
            bndMuvekkilOdemeleri.AddNew();
            AvukatProLib2.Data.TransactionManager tran = new AvukatProLib2.Data.TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            TList<AV001_TI_BIL_MUVEKKILE_ODEME> listE = new TList<AV001_TI_BIL_MUVEKKILE_ODEME>();
            try
            {
                foreach (AV001_TI_BIL_MUVEKKILE_ODEME muvOdeme in bndMuvekkilOdemeleri.List)
                    listE.Add(muvOdeme);

                tran.BeginTransaction();

                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_MUVEKKILE_ODEMEProvider.DeepSave(tran, listE);

                tran.Commit();

                #region Cari hesap üretimi açıldı

                foreach (AV001_TI_BIL_MUVEKKILE_ODEME item in bndMuvekkilOdemeleri.List)
                    AvukatProLib.Hesap.MuhasebeAraclari.SetCariHesapByMuvekkileOdeme(item.ID);

                #endregion

                #region Foy muhasebe üretimi kapatıldı

                //if (listE.Count > 0)
                //{
                //    foreach (var muvekkileOdeme in listE)
                //        AvukatProLib.Hesap.MuhasebeAraclari.SetMuhasebeVeDetayByMuvekkileOdeme(muvekkileOdeme.ID, 1);
                //}

                #endregion

                
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }

            #region Masraf Avans üretimi virman için
            
            TList<AV001_TDI_BIL_MASRAF_AVANS> masrafAvansListesi = new TList<AV001_TDI_BIL_MASRAF_AVANS>();
            TList<AV001_TDI_BIL_FOY_MUHASEBE> masrafAvansFoyListesi = new TList<AV001_TDI_BIL_FOY_MUHASEBE>();

            foreach (var odeme in listE)
            {
                if (odeme.ODEME_TIP_ID == (int?)AvukatProLib.Extras.OdemeTip.VİRMAN)
                {
                    AV001_TDI_BIL_MASRAF_AVANS ma = new AV001_TDI_BIL_MASRAF_AVANS();
                    ma.CARI_HESAP_HEDEF_TIP = (int)lueModul.EditValue;
                    ma.MASRAF_AVANS_TIP = (int)AvukatProLib.Extras.MasrafAvansTip.Avans;                    

                    RCariHesapDetayliEntity rowsecili = (RCariHesapDetayliEntity)gvMuvekkilHesap.GetRow((int)_focusedRowHandle);

                    ma.CARI_ID = (int)lueOdeyen.EditValue;                    
                    //ma.BORCLU_CARI_ID = (int)rowsecili.CariId;

                    if (odeme.ICRA_FOY_ID.HasValue)
                        ma.ICRA_FOY_ID = rowsecili.FoyId;
                    if (odeme.DAVA_FOY_ID.HasValue)
                        ma.DAVA_FOY_ID = rowsecili.FoyId;
                    if (odeme.HAZIRLIK_FOY_ID.HasValue)
                        ma.HAZIRLIK_ID = rowsecili.FoyId;

                    ma.MANUEL_KAYIT_MI = false;

                    object row = searchLookUpEdit1View.GetRow(searchLookUpEdit1View.GetSelectedRows()[0]);

                    ma.ACIKLAMA = String.Format("{0} {1} {2} {3} esas nolu {4} dosyasından {5} adlı müvekkile {6} tarihinde yapılan müvekkkil ödemesinden bu dosyaya yapılan virman hareketidir.", searchLookUpEdit1View.GetRowCellDisplayText(searchLookUpEdit1View.GetSelectedRows()[0], colADLIYE), searchLookUpEdit1View.GetRowCellDisplayText(searchLookUpEdit1View.GetSelectedRows()[0], colNO), searchLookUpEdit1View.GetRowCellDisplayText(searchLookUpEdit1View.GetSelectedRows()[0], colGorev), searchLookUpEdit1View.GetRowCellDisplayText(searchLookUpEdit1View.GetSelectedRows()[0], colESAS_NO), lueModul.Text, lueOdenen.Text, dtOdemeTarihi.EditValue);

                    //masraf avans detay
                    var maDetay = ma.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.AddNew();
                    maDetay.ACIKLAMA = ma.ACIKLAMA;
                    maDetay.ADET = 1;
                    maDetay.BIRIM_FIYAT = odeme.MIKTAR;
                    maDetay.BIRIM_FIYAT_DOVIZ_ID = odeme.MIKTAR_DOVIZ_ID;
                    maDetay.TOPLAM_TUTAR = odeme.MIKTAR;
                    maDetay.TOPLAM_TUTAR_DOVIZ_ID = odeme.MIKTAR_DOVIZ_ID ?? 1;
                    maDetay.GENEL_TOPLAM = odeme.MIKTAR;
                    maDetay.GENEL_TOPLAM_DOVIZ_ID = odeme.MIKTAR_DOVIZ_ID ?? 1;
                    maDetay.BORC_ALACAK_ID = (int)AvukatProLib.Extras.BorcAlacak.Alacak;
                    maDetay.HAREKET_ANA_KATEGORI_ID = (int)AvukatProLib.Extras.HareketAnaKategori.AvansHesabı;
                    maDetay.HAREKET_ALT_KATEGORI_ID = (int)lueVirmanTipi.GetColumnValue("Id");
                    //maDetay.HAREKET_ANA_KATEGORI_ID = (int)AvukatProLib.Extras.MuhasebeAnaKategori.AVANS_HESABI;
                    //maDetay.HAREKET_ALT_KATEGORI_ID = (int)AvukatProLib.Extras.;
                    maDetay.ODEME_TIP_ID = odeme.ODEME_TIP_ID;
                    maDetay.ONAY_DURUM = 0;
                    maDetay.ONAY_NO = "";
                    //maDetay.ONAY_TARIHI = DBNull.Value;
                    maDetay.Onaylandi = false;
                    maDetay.MuhasebelestirilecekMi = true;
                    maDetay.TARIH = DateTime.Now;
                    maDetay.TUM_MUVEKKILLERE_PAYLASTIR = true;
                    maDetay.INCELENDI = false;
                    maDetay.BURO_HESAP_SAHIBI_CARI_BANKA_ID = odeme.BURO_HESAP_SAHIBI_CARI_BANKA_ID;
                    maDetay.MUHATAP_HESAP_SAHIBI_CARI_BANKA_ID = odeme.MUHATAP_HESAP_SAHIBI_CARI_BANKA_ID;
                    maDetay.EFT_REFERANS_NO = odeme.EFT_REFERANS_NO;
                    maDetay.BANKA_DEKONT_NO = odeme.BANKA_DEKONT_NO;
                    maDetay.KIYMETLI_EVRAK_ID = odeme.KIYMETLI_EVRAK_BILGILERI_ID;
                    maDetay.MUVEKKILE_ODEME_ID = odeme.ID;
                    maDetay.MUVEKKIL_CARI_ID = (int)rowsecili.CariId;
                    masrafAvansListesi.Add(ma);

                    
                    AV001_TDI_BIL_FOY_MUHASEBE mm = new AV001_TDI_BIL_FOY_MUHASEBE();
                    mm.MUHASEBE_HEDEF_TIP = (int)lueModul.EditValue;
                    //mm.MASRAF_AVANS_ID = ma.ID;
                    mm.REFERANS_NO = ma.REFERANS_NO;
                    mm.OTOMATIK_HESAPLANDI = false;
                    mm.ACIKLAMA = ma.ACIKLAMA;
                    mm.KAYIT_TARIHI = ma.KAYIT_TARIHI;
                    mm.KLASOR_KODU = ma.KLASOR_KODU;
                    mm.SUBE_KODU = ma.SUBE_KODU;
                    mm.KONTROL_NE_ZAMAN = ma.KONTROL_NE_ZAMAN;
                    mm.KONTROL_KIM = ma.KONTROL_KIM;
                    mm.KONTROL_VERSIYON = ma.KONTROL_VERSIYON;
                    mm.STAMP = ma.STAMP;
                    mm.KONTROL_KIM_ID = ma.KONTROL_KIM_ID;
                    mm.SUBE_KOD_ID = ma.SUBE_KOD_ID;
                    mm.ILAM_ID = ma.ILAM_ID;
                    mm.MASRAF_AVANS_TIP_ID = 2;

                    if (odeme.ICRA_FOY_ID.HasValue)
                    {
                        mm.ICRA_FOY_ID = rowsecili.FoyId;
                    }
                    if (odeme.DAVA_FOY_ID.HasValue)
                    {
                        mm.ICRA_FOY_ID = rowsecili.FoyId;
                    }
                    if (odeme.HAZIRLIK_FOY_ID.HasValue)
                    {
                        mm.HAZIRLIK_ID = rowsecili.FoyId;
                    }


                   var mmDetay = mm.AV001_TDI_BIL_FOY_MUHASEBE_DETAYCollection.AddNew();
                   //mmDetay.FOY_MUHASEBE_ID = mm.ID;
                   mmDetay.YENIDEN_HESAPLANABILIR = false;
                   mmDetay.TARIH = maDetay.TARIH;
                   mmDetay.HAREKET_ANA_KATEGORI_ID = maDetay.HAREKET_ANA_KATEGORI_ID;
                   mmDetay.HAREKET_ANA_KATEGORI = maDetay.HAREKET_ANA_KATEGORI;
                   mmDetay.HAREKET_ALT_KATEGORI_ID = maDetay.HAREKET_ALT_KATEGORI_ID;
                   mmDetay.HAREKET_ALT_KATEGORI = maDetay.HAREKET_ALT_KATEGORI;
                   mmDetay.ADET = maDetay.ADET;
                   mmDetay.BIRIM_FIYAT_DOVIZ_ID = maDetay.BIRIM_FIYAT_DOVIZ_ID;
                   mmDetay.BIRIM_FIYAT_DOVIZ = maDetay.BIRIM_FIYAT_DOVIZ;
                   mmDetay.BIRIM_FIYAT_DOVIZ_KUR = maDetay.BIRIM_FIYAT_DOVIZ_KUR;;
                   mmDetay.BIRIM_FIYAT = maDetay.BIRIM_FIYAT;
                   mmDetay.KDV_DAHIL = maDetay.KDV_DAHIL;
                   mmDetay.KDV_ORAN = maDetay.KDV_ORAN;
                   mmDetay.KDV_TUTAR = maDetay.KDV_TUTAR;
                   mmDetay.STOPAJ_SSDF_DAHIL = maDetay.STOPAJ_SSDF_DAHIL;
                   mmDetay.STOPAJ_ORAN = maDetay.STOPAJ_ORAN;
                   mmDetay.SSDF_ORAN = maDetay.SSDF_ORAN;
                   mmDetay.STOPAJ_SSDF_TUTAR = maDetay.STOPAJ_SSDF_TUTAR;
                   mmDetay.TOPLAM_TUTAR = maDetay.TOPLAM_TUTAR;
                   mmDetay.GENEL_TOPLAM = maDetay.GENEL_TOPLAM;
                   mmDetay.ACIKLAMA = maDetay.ACIKLAMA;
                   mmDetay.KAYIT_TARIHI = maDetay.KAYIT_TARIHI;
                   mmDetay.KLASOR_KODU = maDetay.KLASOR_KODU;
                   mmDetay.SUBE_KODU = maDetay.SUBE_KODU;
                   mmDetay.KONTROL_NE_ZAMAN = maDetay.KONTROL_NE_ZAMAN;
                   mmDetay.KONTROL_KIM = maDetay.KONTROL_KIM;
                   mmDetay.KONTROL_VERSIYON = maDetay.KONTROL_VERSIYON;
                   mmDetay.STAMP = maDetay.STAMP;
                   mmDetay.KONTROL_KIM_ID = maDetay.KONTROL_KIM_ID;
                   mmDetay.SUBE_KOD_ID = maDetay.SUBE_KOD_ID;
                   mmDetay.KIYMETLI_EVRAK_ID = maDetay.KIYMETLI_EVRAK_ID;
                   mmDetay.SEGMENT_ID = maDetay.SEGMENT_ID;
                   mmDetay.ICRA_ODEME_ID = maDetay.ICRA_ODEME_ID;
                   mmDetay.DAVA_ODEME_ID = maDetay.DAVA_ODEME_ID;
                   mmDetay.MUVEKKILE_ODEME_ID = maDetay.MUVEKKILE_ODEME_ID;
                   mmDetay.MASRAF_AVANS_DETAY_ID = maDetay.ID;
                   mmDetay.MUHATAP_HESAP_SAHIBI_CARI_ID = maDetay.MUHATAP_HESAP_SAHIBI_CARI_ID;
                   mmDetay.MUHATAP_HESAP_SAHIBI_CARI_BANKA_ID = maDetay.MUHATAP_HESAP_SAHIBI_CARI_BANKA_ID;
                   mmDetay.BURO_HESAP_SAHIBI_CARI_ID = maDetay.BURO_HESAP_SAHIBI_CARI_ID;
                   mmDetay.BURO_HESAP_SAHIBI_CARI_BANKA_ID = maDetay.BURO_HESAP_SAHIBI_CARI_BANKA_ID;
                   mmDetay.MUHASEBELESTIRILMEMIS_MIKTAR = maDetay.GENEL_TOPLAM;
                   mmDetay.MUHASEBELESTIRILMEMIS_MIKTAR_DOVIZ_ID = maDetay.GENEL_TOPLAM_DOVIZ_ID;
                   mmDetay.BANKA_DEKONT_NO = maDetay.BANKA_DEKONT_NO;
                   mmDetay.EFT_REFERANS_NO = maDetay.EFT_REFERANS_NO;
                   mmDetay.ODEME_TIP_ID = maDetay.ODEME_TIP_ID;
                   mmDetay.BORC_ALACAK_ID = maDetay.BORC_ALACAK_ID;
                   mmDetay.MUVEKKIL_CARI_ID = maDetay.MUVEKKIL_CARI_ID;
                   masrafAvansFoyListesi.Add(mm);
                }
            }
            if (masrafAvansListesi.Count > 0)
            {
                tran.BeginTransaction();
                try
                {
                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepSave(tran, masrafAvansListesi);

                    //foreach (AV001_TDI_BIL_MASRAF_AVANS item in masrafAvansListesi)
                    //{
                    //    masrafAvansFoyListesi[0].MASRAF_AVANS_ID = item.ID;
                    //}

                    for (int i = 0; i < masrafAvansListesi.Count; i++)
                    {
                        masrafAvansFoyListesi[i].MASRAF_AVANS_ID = masrafAvansListesi[i].ID;

                        masrafAvansFoyListesi[i].AV001_TDI_BIL_FOY_MUHASEBE_DETAYCollection[0].MASRAF_AVANS_DETAY_ID = masrafAvansListesi[i].AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[0].ID;
                    }

                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.DeepSave(tran, masrafAvansFoyListesi);

                    tran.Commit();
                    XtraMessageBox.Show("Kayıt işlemi başarı ile gerçekleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen)
                        tran.Rollback();

                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
                //foreach (var ma in masrafAvansListesi)
                //{
                //    MuhasebeHelper.MasrafAvansToKasa(ma);
                //}
            }

            #endregion Masraf Avans üretimi

            this.Close();
        }

        #endregion <MB-20102101> KAYIT

        #region <MB-20100202> TAKİP EKRANI DIŞINDA DOSYA BİLGİSİ

        private void lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDosya.EditValue != null)
            {
                BelgeUtil.Inits.CariPersonelGetir(lueOdeyen);

                GetDosyaTaraflariRequest request = new GetDosyaTaraflariRequest
                {
                    ModulId = (int)lueModul.EditValue,
                    FoyId = (int)lueDosya.EditValue,
                    TarafKodu = AvukatProLib.Extras.TarafKodu.Muvekkil
                };

                AvukatPro.Services.Implementations.DevExpressService.DosyaTaraflariniDoldur(lueOdenen, request);

                lcItemOdenen.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lcItemOdeyen.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                //bndMuvekkilOdemeleri.AddNew();
            }
            else
                XtraMessageBox.Show("Önce bir İcra Dosyası seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        #endregion <MB-20100202> TAKİP EKRANI DIŞINDA DOSYA BİLGİSİ
        
        private void lueOdemeTipi_EditValueChanged(object sender, EventArgs e)
        {

            if (lueOdemeTipi.Text == "VİRMAN")
            {
                if (string.IsNullOrEmpty(lueOdenen.EditValue.ToString()))
                    return;
                if (lueOdenen.EditValue == null)
                    XtraMessageBox.Show("Virman yapacağınız müvekkili seçiniz!");
                else
                    gcMuvekkilHesap.DataSource = AvukatPro.Services.Implementations.CariService.GetAllCariHesapDetayByCariId((int)lueOdenen.EditValue);

                AvukatPro.Services.Implementations.DevExpressService.VirmanTipiDoldur(lueVirmanTipi);
                lcVirmanTipi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lcCekSenet.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                AvukatPro.Services.Implementations.DevExpressService.KiymetliEvrakDoldur(lueKiymetliEvrak);
                lciVirmanUyari.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }

            else if (lueOdemeTipi.Text == "ÇEK")
            {
                lcVirmanTipi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lcCekSenet.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                AvukatPro.Services.Implementations.DevExpressService.KiymetliEvrakDoldur(lueKiymetliEvrak);
                lueKiymetliEvrak.Properties.DataSource = AvukatPro.Services.Implementations.DosyaService.GetAllCek();
                lciVirmanUyari.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            }

            else if (lueOdemeTipi.Text == "SENET")
            {
                lcVirmanTipi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                lcCekSenet.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                AvukatPro.Services.Implementations.DevExpressService.KiymetliEvrakDoldur(lueKiymetliEvrak);
                lciVirmanUyari.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lueKiymetliEvrak.Properties.DataSource = AvukatPro.Services.Implementations.DosyaService.GetAllSenet();
            }
            else
            {
                lcVirmanTipi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciVirmanUyari.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lcCekSenet.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void bindRepositoryItems()
        {
            BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliBirimNo);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
            AvukatPro.Services.Implementations.DevExpressService.AltKategoriDoldur(rlueAltKategori);
            BelgeUtil.Inits.BorcAlacakGetir(rlueBorcAlacak);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlueGorev);
            BelgeUtil.Inits.OdemeTipiGetir(rlueDovizId);
            BelgeUtil.Inits.DovizTipGetir(rlueOdemeTipi);
        }

        private void lueOdenen_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lueOdenen.EditValue.ToString()))
                return;
            if (gcMuvekkilHesap.DataSource == null)
            {
                bindRepositoryItems();
                gcMuvekkilHesap.DataSource = AvukatPro.Services.Implementations.CariService.GetAllCariHesapDetayByCariId((int)lueOdenen.EditValue);
            }
        }

        private void lueModul_EditValueChanged(object sender, EventArgs e)
        {
            if (lueModul.EditValue == null)
                return;

            //if (TakipEkraniDisinda)
            //{
            if (lueModul.Text == "Icra")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Icra, false);

            else if (lueModul.Text == "Dava")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Dava, false);

            else if (lueModul.Text == "Soruşturma")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sorusturma, false);

            else if (lueModul.Text == "Sözleşme")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sozlesme, false);

            lcItemDosya.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //}
        }

        private void lueKiymetliEvrak_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lueKiymetliEvrak.EditValue.ToString()))
                return;
            decimal miktar = (decimal)lueKiymetliEvrak.Properties.View.GetRowCellValue(lueKiymetliEvrak.Properties.View.GetSelectedRows()[0], "Tutar");
            int dovizId = (int)lueKiymetliEvrak.Properties.View.GetRowCellValue(lueKiymetliEvrak.Properties.View.GetSelectedRows()[0], "TutarDovizId");

            if (miktar > 0)
                spMiktar.Value = miktar;

            if (dovizId > 0)
                lueMiktarDoviz.EditValue = dovizId;
        }

        private void gvMuvekkilHesap_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        { _focusedRowHandle = e.FocusedRowHandle; }

        private void lueBelge_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "ekle")
            {
                frmBelgeKayitUfak frmblg = new frmBelgeKayitUfak();
                frmblg.ShowDialog();
                AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(lueBelge);
            }
        }
    }
}