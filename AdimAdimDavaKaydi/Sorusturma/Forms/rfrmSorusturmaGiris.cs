using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using AdimAdimDavaKaydi.IcraTakipForms;

namespace AdimAdimDavaKaydi.Sorusturma.Forms
{
    public partial class rfrmSorusturmaGiris : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        #region Fields

        //Klasörden soruþturma kaydý yapýlýrken þikayet eden-þikayet edilen seçimine göre taraflarýn gelebilmesi için eklendi.
        public bool ProjeSikayetEden;

        private readonly TDI_KOD_TARAF tmpTaraf = new TDI_KOD_TARAF();
        private List<string> _myList = new List<string>();
        private TD_KOD_DAVA_TALEP DTalep = new TD_KOD_DAVA_TALEP();
        private int i;
        private int j;
        private AV001_TD_BIL_HAZIRLIK mySikayet;
        private TList<AV001_TD_BIL_HAZIRLIK_TARAF> sikayetEdilen;
        private TList<AV001_TD_BIL_HAZIRLIK> sikayetList = new TList<AV001_TD_BIL_HAZIRLIK>();
        private TList<AV001_TD_BIL_HAZIRLIK_SORUMLU> sorumluAvk;
        private string tempHazirlikNo = string.Empty;

        #endregion Fields

        #region Constructors

        public rfrmSorusturmaGiris()
        {
            InitializeComponent();
            InitializeEvents();
            gvSAvukat.ValidateRow += gvSAvukat_ValidateRow;
            gridView2.ValidateRow += gvSikayetEdilen_ValidateRow;
            grdSikayetEden.ValidateRow += grdSikayetEden_ValidateRow;
            grdSikayetEden.CustomRowCellEdit += grdSikayetEden_CustomRowCellEdit;

            grdSikayetEden.CellValueChanged += grdSikayetEden_CellValueChanged;
            gridView2.CellValueChanged += gridView2_CellValueChanged;

            this.FormClosing += rfrmSorusturmaGiris_FormClosing;

            if (AvukatProLib.Kimlik.SirketBilgisi.LisansBilgisi.SorusturmaKayitSayisi.HasValue)
            {
                int total = BelgeUtil.Inits.HazirlikDosyalariGetir().Count;
                if (total >= AvukatProLib.Kimlik.SirketBilgisi.LisansBilgisi.SorusturmaKayitSayisi.Value)
                {
                    MessageBox.Show("Toplam Soruþturma Kayýt Limitiniz Dolduðundan Yeni Soruþturma Kaydý Yapamazsýnýz.");
                    this.Close();
                }
            }
        }

        #endregion Constructors

        #region Events

        public event EventHandler<SorusturmaFoyKaydedildiEventArgs> SorusturmaKaydedildi;

        #endregion Events

        #region Properties

        public bool Icradanmi
        {
            get;
            set;
        }

        /// <summary>
        /// Klasör nesnesi
        /// </summary>
        public AV001_TDIE_BIL_PROJE MyProje
        {
            get;
            set;
        }

        public AV001_TD_BIL_HAZIRLIK MySikayet
        {
            get { return mySikayet; }
            set
            {
                mySikayet = value;
                try
                {
                    setHazirlik(value);
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        public bool OtomatikKayit
        {
            get;
            set;
        }

        public AV001_TI_BIL_FOY RelatedIcraFoy
        {
            get;
            set;
        }

        public TList<AV001_TD_BIL_HAZIRLIK_TARAF> SikayetEden
        {
            get;
            set;
        }

        public TList<AV001_TD_BIL_HAZIRLIK_TARAF> SikayetEdilen
        {
            get { return sikayetEdilen; }
            set { sikayetEdilen = value; }
        }

        public TList<AV001_TD_BIL_HAZIRLIK_SORUMLU> SorumluAvk
        {
            get { return sorumluAvk; }
            set { sorumluAvk = value; }
        }

        public TList<AV001_TD_BIL_HAZIRLIK_TARAF> TumTaraflar
        {
            get
            {
                TList<AV001_TD_BIL_HAZIRLIK_TARAF> result = new TList<AV001_TD_BIL_HAZIRLIK_TARAF>();
                result.AddRange(SikayetEden);
                result.AddRange(SikayetEdilen);
                return result;
            }
            set
            {
                SikayetEdilen.Clear();
                SikayetEden.Clear();
                DataRepository.AV001_TD_BIL_HAZIRLIK_TARAFProvider.DeepLoad(value, true, DeepLoadType.IncludeChildren,
                                                                            typeof(TDIE_KOD_TARAF_SIFAT),
                                                                            typeof(
                                                                                TList<AV001_TD_BIL_HAZIRLIK_TARAF_VEKIL>
                                                                                ));
                foreach (AV001_TD_BIL_HAZIRLIK_TARAF trf in value)
                {
                    if (trf.TARAF_SIFAT_IDSource.HANGI_TARAFI == "YAKINAN")
                    {
                        SikayetEden.Add(trf);
                    }
                    else if (trf.TARAF_SIFAT_IDSource.HANGI_TARAFI == "ÞÜPHELÝ")
                    {
                        sikayetEdilen.Add(trf);
                    }
                }
            }
        }

        #endregion Properties

        #region Methods

        public string HazirlikNoGetir()
        {
            string foyNo = String.Empty;

            AV001_TD_BIL_HAZIRLIKQuery que = new AV001_TD_BIL_HAZIRLIKQuery();
            int k = 0;
            TList<AV001_TD_BIL_HAZIRLIK> foyler = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.Find(que, "ID DESC", 0, 1,
                                                                                                    out k);
            if (foyler.Count > 0)
            {
                int foyNoSayi = foyler[0].HAZIRLIK_NO_Sayi;
                var foy_No = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text,
                                                                   "select top(1)HAZIRLIK_NO from AV001_TD_BIL_HAZIRLIK order by KAYIT_TARIHI desc");

                foyNo = String.Format("H-{0}~{1}", DateTime.Today.Year, foyNoSayi + 1);
            }
            else
            {
                foyNo = String.Format("H-{0}~{1}", DateTime.Today.Year, 10001);
            }
            return foyNo;
        }

        public bool SorusturmaKaydet(AV001_TD_BIL_HAZIRLIK hzrlk)
        {
            bool b = false;
            try
            {
                foreach (AV001_TD_BIL_HAZIRLIK_SORUMLU SorumluAvk in hzrlk.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection)
                {
                    #region <CC-20090627>

                    // cari IDnin atanmasý için != deðil kýsmý == yapýlmýþtýr

                    #endregion <CC-20090627>

                    if (SorumluAvk.CARI_ID == null)
                        SorumluAvk.CARI_ID = SorumluAvk.CARI_IDSource.ID;
                }

                if (hzrlk.IsNew)
                {
                    hzrlk.KAYIT_TARIHI = DateTime.Now;
                    hzrlk.KONTROL_NE_ZAMAN = DateTime.Now;
                    hzrlk.KONTROL_KIM = "AVUKATPRO";
                    hzrlk.KONTROL_VERSIYON = 0;
                    hzrlk.KLASOR_KODU = "GENEL";
                    hzrlk.ADLI_BIRIM_GOREV_ID = 43;
                    hzrlk.SUBE_KOD_ID = frmKlasorYeni.KullaniciSubeIDGetir(hzrlk.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.Find(vi => !vi.YETKILI_MI).CARI_ID.Value);
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(typeof(rfrmSorusturmaGiris), ex);
            }
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                trans.BeginTransaction();

                #region <MB-20100621>

                //Dosya kaydý sýrasýnda HAZIRLIK_NO bilgisinin unique olmasýný saðlamak için tekrardan kontrol eklendi.
                if (
                    DataRepository.AV001_TD_BIL_HAZIRLIKProvider.Find(string.Format("HAZIRLIK_NO = {0}",
                                                                                    hzrlk.HAZIRLIK_NO)).Count > 0)
                    hzrlk.HAZIRLIK_NO = HazirlikNoGetir();

                #endregion <MB-20100621>

                DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepSave(trans, hzrlk);
                DataRepository.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENProvider.DeepSave(trans,
                                                                                    hzrlk.
                                                                                        AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection);

                DataRepository.AV001_TD_BIL_HAZIRLIK_TARAFProvider.DeepSave(trans,
                                                                            hzrlk.AV001_TD_BIL_HAZIRLIK_TARAFCollection);

                foreach (var item in SikayetEden)
                {
                    #region Þikayet eden

                    foreach (var trfVekil in item.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection)
                    {
                        if (trfVekil.HAZIRLIK_TARAF_ID == null && trfVekil.HAZIRLIK_TARAF_ID == 0
                            || trfVekil.HAZIRLIK_TARAF_IDSource == null)
                        {
                            trfVekil.HAZIRLIK_TARAF_CARI_ID = item.CARI_ID;
                            trfVekil.HAZIRLIK_TARAF_ID = item.ID;
                        }
                    }

                    #endregion Þikayet eden

                    DataRepository.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILProvider.Save(trans,
                                                                                  item.
                                                                                      AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection);
                }
                foreach (var item in SikayetEdilen)
                {
                    #region Sikayet Edilen

                    foreach (var trfVekil in item.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection)
                    {
                        if (trfVekil.HAZIRLIK_TARAF_ID == null && trfVekil.HAZIRLIK_TARAF_ID == 0
                            || trfVekil.HAZIRLIK_TARAF_IDSource == null)
                        {
                            trfVekil.HAZIRLIK_TARAF_CARI_ID = item.CARI_ID;
                            trfVekil.HAZIRLIK_TARAF_ID = item.ID;
                        }
                    }

                    #endregion Sikayet Edilen

                    DataRepository.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILProvider.Save(trans,
                                                                                  item.
                                                                                      AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection);
                }

                foreach (
                    AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN neden in hzrlk.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection)
                {
                    DataRepository.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFProvider.DeepSave(trans,
                                                                                              neden.
                                                                                                  AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection);
                    DataRepository.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENProvider.DeepSave(trans,
                                                                                        hzrlk.
                                                                                            AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection);

                    #region Soruþturma Police ,Gayrimenkul,Sozlesme,KýymetliEvrak,ARAC  Kayýt NN

                    foreach (
                        AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN hSNeden in
                            hzrlk.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection)
                    {
                        foreach (
                            AV001_TDI_BIL_KIYMETLI_EVRAK dNKEvrak in
                                hSNeden.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_SIKAYET_NEDEN_KIYMETLI_EVRAK)
                        {
                            NN_SORUSTURMA_KIYMETLI_EVRAK kEvrak = hzrlk.NN_SORUSTURMA_KIYMETLI_EVRAKCollection.AddNew();
                            kEvrak.KIYMETLI_EVRAK_IDSource = dNKEvrak;
                            kEvrak.SORUSTURMA_ID = hzrlk.ID;

                            if (
                                neden.NN_SIKAYET_NEDEN_KIYMETLI_EVRAKCollection.Exists(
                                    delegate(NN_SIKAYET_NEDEN_KIYMETLI_EVRAK pol) { return pol.KIYMETLI_EVRAK_ID == dNKEvrak.ID; })) continue;
                            NN_SIKAYET_NEDEN_KIYMETLI_EVRAK poli =
                                neden.NN_SIKAYET_NEDEN_KIYMETLI_EVRAKCollection.AddNew();
                            poli.KIYMETLI_EVRAK_IDSource = dNKEvrak;
                            poli.HAZIRLIK_SIKAYET_NEDEN_ID = neden.ID;
                            DataRepository.NN_SIKAYET_NEDEN_KIYMETLI_EVRAKProvider.DeepSave(trans, poli);
                        }
                        foreach (
                            AV001_TDI_BIL_GEMI_UCAK_ARAC gua in
                                hSNeden.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SIKAYET_NEDEN_GEMI_UCAK_ARAC)
                        {
                            NN_SORUSTURMA_GEMI_UCAK_ARAC Igua = hzrlk.NN_SORUSTURMA_GEMI_UCAK_ARACCollection.AddNew();
                            Igua.GEMI_UCAK_ARAC_IDSource = gua;
                            Igua.SORUSTURMA_ID = hzrlk.ID;

                            if (
                                neden.NN_SIKAYET_NEDEN_GEMI_UCAK_ARACCollection.Exists(
                                    delegate(NN_SIKAYET_NEDEN_GEMI_UCAK_ARAC pol) { return pol.GEMI_UCAK_ARAC_ID == gua.ID; })) continue;
                            NN_SIKAYET_NEDEN_GEMI_UCAK_ARAC poli =
                                neden.NN_SIKAYET_NEDEN_GEMI_UCAK_ARACCollection.AddNew();
                            poli.GEMI_UCAK_ARAC_IDSource = gua;
                            poli.HAZIRLIK_SIKAYET_NEDEN_ID = neden.ID;
                            DataRepository.NN_SIKAYET_NEDEN_GEMI_UCAK_ARACProvider.DeepSave(trans, poli);
                        }
                        foreach (
                            AV001_TI_BIL_GAYRIMENKUL gayrimenkul in
                                hSNeden.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SIKAYET_NEDEN_GAYRIMENKUL)
                        {
                            NN_SORUSTURMA_GAYRIMENKUL Igayrimenkul = hzrlk.NN_SORUSTURMA_GAYRIMENKULCollection.AddNew();
                            Igayrimenkul.GAYRIMENKUL_IDSource = gayrimenkul;
                            Igayrimenkul.SORUSTURMA_ID = hzrlk.ID;

                            if (
                                neden.NN_SIKAYET_NEDEN_GAYRIMENKULCollection.Exists(
                                    delegate(NN_SIKAYET_NEDEN_GAYRIMENKUL pol) { return pol.GAYRIMENKUL_ID == gayrimenkul.ID; })) continue;
                            NN_SIKAYET_NEDEN_GAYRIMENKUL poli = neden.NN_SIKAYET_NEDEN_GAYRIMENKULCollection.AddNew();
                            poli.GAYRIMENKUL_IDSource = gayrimenkul;
                            poli.HAZIRLIK_SIKAYET_NEDEN_ID = neden.ID;
                            DataRepository.NN_SIKAYET_NEDEN_GAYRIMENKULProvider.DeepSave(trans, poli);
                        }

                        // todo : poliçede eklenince yukardýkilere benzer þekilde oluþturulacak
                        DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepSave(trans, hzrlk, DeepSaveType.IncludeChildren,
                                                                              typeof(TList<NN_SORUSTURMA_GAYRIMENKUL>),
                                                                              typeof(
                                                                                  TList<NN_SORUSTURMA_GEMI_UCAK_ARAC>),
                                                                              typeof(
                                                                                  TList<NN_SORUSTURMA_KIYMETLI_EVRAK>),
                                                                              typeof(TList<NN_SORUSTURMA_POLICE>));
                    }

                    #endregion Soruþturma Police ,Gayrimenkul,Sozlesme,KýymetliEvrak,ARAC  Kayýt NN

                    #region Otomatik Kayýt

                    if (OtomatikKayit && RelatedIcraFoy != null)
                    {
                        AV001_TDI_BIL_KAYIT_ILISKI iliski =
                            DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByILISKI_TUR_IDKAYNAK_KAYIT_ID(
                                (int)AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.ÝCRA_DOSYASI,
                                RelatedIcraFoy.ID);

                        if (iliski == null)
                        {
                            iliski = MySikayet.AV001_TDI_BIL_KAYIT_ILISKICollection.AddNew();

                            iliski.ILISKI_TUR_ID =
                                (int)AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.ÝCRA_DOSYASI;
                            iliski.KAYIT_TARIHI = DateTime.Today;
                            iliski.KAYNAK_HAZIRLIK_ID = hzrlk.ID;
                            iliski.KAYNAK_RUCU_ID = null;
                            iliski.KAYNAK_KAYIT_ID = RelatedIcraFoy.ID;
                            iliski.KAYNAK_ICRA_FOY_ID = RelatedIcraFoy.ID;
                            iliski.KAYNAK_TIP = 1;
                            iliski.AKTIF_MI = true;
                            iliski.KAYIT_TARIHI = DateTime.Today;
                            iliski.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                            iliski.KONTROL_KIM = "AVUKATPRO";
                            iliski.KONTROL_NE_ZAMAN = DateTime.Today;
                            iliski.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                            iliski.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                            iliski.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                        }

                        AV001_TDI_BIL_KAYIT_ILISKI_DETAY detay =
                            iliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection.AddNew();

                        detay.HEDEF_ADLI_BIRIM_ADLIYE_ID = MySikayet.ADLI_BIRIM_ADLIYE_ID;
                        detay.HEDEF_ADLI_BIRIM_GOREV_ID = MySikayet.ADLI_BIRIM_GOREV_ID;
                        detay.HEDEF_ADLI_BIRIM_NO_ID = MySikayet.ADLI_BIRIM_NO_ID;
                        detay.HEDEF_HAZIRLIK_ID = MySikayet.ID;
                        detay.HEDEF_DOSYA_TARIHI = MySikayet.SIKAYET_TARIHI;
                        detay.HEDEF_ESAS_NO = MySikayet.HAZIRLIK_ESAS_NO;
                        detay.HEDEF_FOY_NO = MySikayet.HAZIRLIK_NO;

                        //detay.HEDEF_HAZIRLIK_ID = null;
                        detay.HEDEF_ICRA_FOY_ID = null; //RelatedIcraFoy.ID;
                        detay.HEDEF_KAYIT_ID = MySikayet.ID;
                        detay.HEDEF_RUCU_ID = null;
                        detay.HEDEF_TIP = 3;
                        detay.ILISKI_TUR_ID =
                            (int)AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.HAZIRLIK_DOSYASI;
                        detay.ADMIN_KAYIT_MI = 0;
                        detay.KAYIT_TARIHI = DateTime.Today;

                        detay.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                        detay.KONTROL_KIM = "AVUKATPRO";
                        detay.KONTROL_NE_ZAMAN = DateTime.Today;
                        detay.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                        detay.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                        detay.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                        DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.DeepSave(trans, iliski, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>));

                        #region <MB-20101105>

                        //Herhangi bir dosya altýna iliþkili dosya kaydý yapýldýðýnda bu dosyayý iliþkilendirildiði dosyanýn baðlý olduðu klasöre iliþkilendirmek için eklendi.
                        frmKayitIliski kayitIliski = new frmKayitIliski();
                        kayitIliski.TransactionKapat = true;
                        kayitIliski.KlasorIliskisiniOlustur(trans, iliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection);

                        #endregion <MB-20101105>
                    }

                    #endregion Otomatik Kayýt
                    //tebligatlarýn esas no düzenlemeleri

                    var tebligats = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByHAZIRLIK_ID(hzrlk.ID);

                    foreach (var item in tebligats)
                    {
                        item.ADLI_BIRIM_ADLIYE_ID = hzrlk.ADLI_BIRIM_ADLIYE_ID;
                        item.ADLI_BIRIM_GOREV_ID = hzrlk.ADLI_BIRIM_GOREV_ID;
                        item.ADLI_BIRIM_NO_ID = hzrlk.ADLI_BIRIM_NO_ID;
                        item.TEBLIGAT_ESAS_NO = hzrlk.HAZIRLIK_NO;
                    }
                    //Tebligat
                    DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(trans, tebligats);

                    //---------------------------------//
                    trans.Commit();

                    if (SorusturmaKaydedildi != null)
                    {
                        SorusturmaKaydedildi(this, new SorusturmaFoyKaydedildiEventArgs(hzrlk));
                    }

                    b = true;
                }
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                BelgeUtil.ErrorHandler.Catch(typeof(rfrmSorusturmaGiris), ex, true);

                b = false;
            }
            return b;
        }

        private void AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF newadd = new AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF();
            newadd.KAYIT_TARIHI = DateTime.Now;
            newadd.KONTROL_NE_ZAMAN = DateTime.Today;
            newadd.KONTROL_KIM = "AVUKATPRO";
            newadd.KONTROL_VERSIYON = 0;
            newadd.STAMP = 1;
            newadd.KLASOR_KODU = "GENEL";
            e.NewObject = newadd;
        }

        private void AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN ndn = new AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN();

            ndn.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection =
                new TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF>();
            foreach (AV001_TD_BIL_HAZIRLIK_TARAF taraf in TumTaraflar)
            {
                AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF trf = new AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF();
                trf.TARAF_CARI_ID = taraf.CARI_ID;
                trf.TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
                ndn.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection.Add(trf);
            }
            ndn.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_SIKAYET_NEDEN_KIYMETLI_EVRAK =
                new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
            ndn.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SIKAYET_NEDEN_GAYRIMENKUL =
                new TList<AV001_TI_BIL_GAYRIMENKUL>();
            ndn.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SIKAYET_NEDEN_GEMI_UCAK_ARAC =
                new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>();
            ndn.AV001_TDI_BIL_POLICECollection_From_NN_SIKAYET_NEDEN_POLICE = new TList<AV001_TDI_BIL_POLICE>();
            ucSorusturmaNedenTaraf1.MyDataSource = ndn.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection;
            ucGayriMenkul1.MyDataSource = ndn.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SIKAYET_NEDEN_GAYRIMENKUL;
            ucPoliceBilgileri1.MyDataSource = ndn.AV001_TDI_BIL_POLICECollection_From_NN_SIKAYET_NEDEN_POLICE;
            ucKiymetliEvrak1.MyDataSource =
                ndn.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_SIKAYET_NEDEN_KIYMETLI_EVRAK;

            ndn.KAYIT_TARIHI = DateTime.Now;
            ndn.KONTROL_NE_ZAMAN = DateTime.Now;
            ndn.KONTROL_KIM = "AVUKATPRO";
            ndn.KONTROL_VERSIYON = 0;
            ndn.STAMP = 1;
            ndn.KLASOR_KODU = "GENEL";
            e.NewObject = ndn;
        }

        private void AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_HAZIRLIK_TARAF_VEKIL trfvekil = new AV001_TD_BIL_HAZIRLIK_TARAF_VEKIL();
            trfvekil.KAYIT_TARIHI = DateTime.Now;
            trfvekil.KONTROL_NE_ZAMAN = DateTime.Now;
            trfvekil.KONTROL_VERSIYON = 0;
            trfvekil.STAMP = 1;
            trfvekil.KONTROL_KIM = "AVUKATPRO";
            trfvekil.KLASOR_KODU = "GENEL";
            e.NewObject = trfvekil;
        }

        private void BindOzelKod()
        {
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rLueOzelKod1, 1, Modul.Sorusturma);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rLueOzelKod2, 2, Modul.Sorusturma);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rLueOzelKod3, 3, Modul.Sorusturma);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rLueOzelKod4, 4, Modul.Sorusturma);
        }

        private void exgrdSikayetEden_DataSourceChanged(object sender, EventArgs e)
        {
            foreach (var item in SikayetEden)
            {
                item.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection.AddRange(
                    DataRepository.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILProvider.GetByHAZIRLIK_TARAF_CARI_ID(item.CARI_ID));
            }
        }

        private void exgrdSikayetEdilen_DataSourceChanged(object sender, EventArgs e)
        {
            foreach (var item in SikayetEdilen)
            {
                item.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection.AddRange(
                    DataRepository.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILProvider.GetByHAZIRLIK_TARAF_CARI_ID(item.CARI_ID));
            }
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BindOzelKod();
        }

        private void grdSikayetEden_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Caption != "T.K") return;

            BelgeUtil.Inits.TarafKodunaGoreCariGetir(rLueSikayetEdenCari, Convert.ToByte(e.Value));
        }

        private void grdSikayetEden_CustomRowCellEdit(object sender,
            DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.RepositoryItem is RepositoryItemLookUpEdit && SikayetEden != null)
            {
                int TARAF_ID = -1;
                RepositoryItemLookUpEdit rlue = null;
                if (e.RowHandle < 0)
                    return;
                GridView grd = sender as GridView;
                if (grd != null)
                {
                    TARAF_ID = Convert.ToInt32(grd.GetRowCellValue(e.RowHandle, grd.Columns["TARAF_KODU"]));
                }
                if (e.RepositoryItem != null)
                {
                    if (e.RepositoryItem.Name == "rLueSikayetEdenCari")
                    {
                        if (TARAF_ID != tmpTaraf.ID)
                        {
                            TarafKodu trf = new TarafKodu();
                            trf = (TarafKodu)TARAF_ID;
                            rlue = (RepositoryItemLookUpEdit)e.RepositoryItem.Clone();
                            rlue.DataSource = null;
                            BelgeUtil.Inits.CariGetirByTarafKodu(rlue, trf);
                            tmpTaraf.ID = TARAF_ID;
                            e.RepositoryItem = rlue;
                        }
                    }
                }
            }
        }

        private void grdSikayetEden_MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
            AV001_TD_BIL_HAZIRLIK_TARAF seciliTaraf = grdSikayetEden.GetRow(e.RowHandle) as AV001_TD_BIL_HAZIRLIK_TARAF;
            if (seciliTaraf != null && seciliTaraf.CARI_ID.HasValue)
            {
                grdSikayetEdenTaraf.ViewCaption = String.Format("Taraf Vekil Bilgileri");

                TList<AV001_TDI_BIL_CARI> cariler = rLueTarafVAvukat.DataSource as TList<AV001_TDI_BIL_CARI>;
                if (cariler != null)
                {
                    AV001_TDI_BIL_CARI seciliCari = cariler.Find(AV001_TDI_BIL_CARIColumn.ID, seciliTaraf.CARI_ID.Value);
                    if (seciliCari != null)
                    {
                        grdSikayetEdenTaraf.ViewCaption = String.Format("{0}{1} -  Tarafýn Vekil Bilgileri",
                                                                        seciliCari.AD.Substring(0,
                                                                                                seciliCari.AD.Length >
                                                                                                17
                                                                                                    ? 17
                                                                                                    : seciliCari.AD.
                                                                                                          Length),
                                                                        seciliCari.AD.Length > 17 ? "..." : string.Empty);
                    }
                }
            }
            else
            {
                e.Allow = false;
                MessageBox.Show("Lütfen Vekil baðlamak için bir þahýs seçiniz", "Hata", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void grdSikayetEden_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TD_BIL_HAZIRLIK_TARAF hazirliktrf = (AV001_TD_BIL_HAZIRLIK_TARAF)e.Row;

            if (!hazirliktrf.CARI_ID.HasValue)
            {
                e.ErrorText = "Bir Sikayet Eden Seçilmelidir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (!hazirliktrf.TARAF_SIFAT_ID.HasValue)
            {
                e.ErrorText = "Bir Taraf Sýfatý Seçilmelidir" + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (hazirliktrf.TARAF_KODU == 0)
            {
                e.ErrorText = "Bir Taraf Kodu Seçilmelidir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (SikayetEden != null)
            {
                if (SikayetEden.FindAll("CARI_ID", hazirliktrf.CARI_ID).Count > 1)
                {
                    e.ErrorText = "Bu Sikayet Eden Kiþi Zaten Eklenmiþ" + Environment.NewLine;
                    e.Valid = false;
                    return;
                }
                if (SikayetEdilen.FindAll("CARI_ID", hazirliktrf.CARI_ID).Count > 0)
                {
                    e.ErrorText = "Bu Sahýþ Sikayet Edilen Taraf Olarak Zaten Eklenmiþ." + Environment.NewLine;
                    e.Valid = false;
                    return;
                }
            }
            TDI_KOD_TARAF trfkod = ((TList<TDI_KOD_TARAF>)rLueSikayetEdenTaraf.DataSource).Find("ID",
                                                                                                 (int)
                                                                                                 hazirliktrf.TARAF_KODU);

            #region <MB-20101901> Þikayet Eden Vekil Bilgileri

            foreach (var item in SikayetEden)
            {
                if (
                    item.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection.Exists(
                        delegate(AV001_TD_BIL_HAZIRLIK_TARAF_VEKIL sorusturmaVekil) { return sorusturmaVekil.HAZIRLIK_TARAF_CARI_ID == item.CARI_ID; })) continue;

                item.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection.AddRange(
                    DataRepository.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILProvider.GetByHAZIRLIK_TARAF_CARI_ID(item.CARI_ID));
            }

            #endregion <MB-20101901> Þikayet Eden Vekil Bilgileri
        }

        private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Caption != "T.K") return;

            BelgeUtil.Inits.TarafKodunaGoreCariGetir(rLueSikayetEdilenCari, Convert.ToByte(e.Value));
        }

        private void gridView2_MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
            AV001_TD_BIL_HAZIRLIK_TARAF seciliTaraf = gridView2.GetRow(e.RowHandle) as AV001_TD_BIL_HAZIRLIK_TARAF;
            if (seciliTaraf != null && seciliTaraf.CARI_ID.HasValue)
            {
                gridView1.ViewCaption = String.Format("Taraf Vekil Bilgileri");

                TList<AV001_TDI_BIL_CARI> cariler = rLueKarsiTarafVAvukat.DataSource as TList<AV001_TDI_BIL_CARI>;
                if (cariler != null)
                {
                    AV001_TDI_BIL_CARI seciliCari = cariler.Find(AV001_TDI_BIL_CARIColumn.ID, seciliTaraf.CARI_ID.Value);
                    if (seciliCari != null)
                    {
                        gridView1.ViewCaption = String.Format("{0}{1} -  Tarafýn Vekil Bilgileri",
                                                              seciliCari.AD.Substring(0,
                                                                                      seciliCari.AD.Length > 17
                                                                                          ? 17
                                                                                          : seciliCari.AD.Length),
                                                              seciliCari.AD.Length > 17 ? "..." : string.Empty);
                    }
                }
            }
            else
            {
                e.Allow = false;
                MessageBox.Show("Lütfen Vekil baðlamak için bir þahýs seçiniz", "Hata", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void gvSAvukat_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TD_BIL_HAZIRLIK_SORUMLU rowAvukat = (AV001_TD_BIL_HAZIRLIK_SORUMLU)e.Row;
            if (!rowAvukat.CARI_ID.HasValue)
            {
                e.ErrorText = "Lütfen Bir Sorumlu Seçiniz." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (SorumluAvk.FindAll("CARI_ID", rowAvukat.CARI_ID).Count > 1)
            {
                e.ErrorText = "Bu Sorumlu Zaten Eklenmiþ." + Environment.NewLine;
                e.Valid = false;
                return;
            }
        }

        private void gvSikayetEdilen_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TD_BIL_HAZIRLIK_TARAF hazirliktrf = (AV001_TD_BIL_HAZIRLIK_TARAF)e.Row;
            if (!hazirliktrf.CARI_ID.HasValue)
            {
                e.ErrorText = "Bir Sikayet Edilen Seçilmelidir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (!hazirliktrf.TARAF_SIFAT_ID.HasValue)
            {
                e.ErrorText = "Bir Taraf Sýfatý Seçilmelidir" + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (hazirliktrf.TARAF_KODU == 0)
            {
                e.ErrorText = "Bir Taraf Kodu Seçilmelidir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (SikayetEdilen != null)
            {
                if (SikayetEdilen.FindAll("CARI_ID", hazirliktrf.CARI_ID).Count > 1)
                {
                    e.ErrorText = "Bu Sikayet Edilen Kiþi Zaten Eklenmiþ" + Environment.NewLine;
                    e.Valid = false;
                    return;
                }
                if (SikayetEden.FindAll("CARI_ID", hazirliktrf.CARI_ID).Count > 0)
                {
                    e.ErrorText = "Bu Sahýþ Sikayet Eden Taraf Olarak Zaten Eklenmiþ." + Environment.NewLine;
                    e.Valid = false;
                    return;
                }
            }
            TDI_KOD_TARAF trfkod = ((TList<TDI_KOD_TARAF>)rLueSikayetEdilenTaraf.DataSource).Find("ID",
                                                                                                   (int)
                                                                                                   hazirliktrf.
                                                                                                       TARAF_KODU);
            ucKiymetliEvrak1.TARAF_ID = hazirliktrf.CARI_ID.Value;

            #region <MB-20101901> Þikayet Edilen Vekil Bilgileri

            foreach (var item in SikayetEdilen)
            {
                if (
                    item.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection.Exists(
                        delegate(AV001_TD_BIL_HAZIRLIK_TARAF_VEKIL sorusturmaVekil) { return sorusturmaVekil.HAZIRLIK_TARAF_CARI_ID == item.CARI_ID; })) continue;

                item.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection.AddRange(
                    DataRepository.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILProvider.GetByHAZIRLIK_TARAF_CARI_ID(item.CARI_ID));
            }

            #endregion <MB-20101901> Þikayet Edilen Vekil Bilgileri
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.c_titemIliskiliDosyalar.Enabled = false;
            this.Button_IliskiliDosyalar_Click += rfrmSorusturmaGiris_Button_IliskiliDosyalar_Click;
            this.Button_Kaydet_Click += rfrmSorusturmaGiris_Button_Kaydet_Click;
            this.Button_Editor_Click += rfrmSorusturmaGiris_Button_Editor_Click;
            this.Button_Word_Click += rfrmSorusturmaGiris_Button_Word_Click;
            this.Button_Outlook_Click += rfrmSorusturmaGiris_Button_Outlook_Click;
            this.Button_XML_Click += rfrmSorusturmaGiris_Button_XML_Click;
            this.Button_PDF_Click += rfrmSorusturmaGiris_Button_PDF_Click;
        }

        private void lookUpExtender1_OnClickOrProcessNewValue(object sender, LookUpExtenderEventArgs e)
        {
            frmCariGenelGiris cari = new frmCariGenelGiris();
            if (e.SenderLookUp != null)
                if (e.SenderLookUp.Properties.Name.Contains("OzelKod") && e.IsTypedValue)
                {
                    try
                    {
                        AV001_TDI_KOD_FOY_OZEL ozel = new AV001_TDI_KOD_FOY_OZEL();

                        //ozel.SUBE_KODU = "GENEL";
                        ozel.KONTROL_NE_ZAMAN = DateTime.Now;
                        ozel.KONTROL_KIM = AvukatProLib.Kimlik.Bilgi.KULLANICI_ADI;
                        ozel.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                        ozel.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                        ozel.KOD = e.TypedValue;
                        DataRepository.AV001_TDI_KOD_FOY_OZELProvider.Save(ozel);
                        ((TList<AV001_TDI_KOD_FOY_OZEL>)e.SenderLookUp.Properties.DataSource).Add(ozel);
                        XtraMessageBox.Show("Özel kod baþarýyla eklenmiþtir.");
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            if (e.SenderLookUp != null)
            {
                if (e.SenderLookUp.Properties.Name.Contains("rLueSikayetEdenCari"))
                {
                    try
                    {
                        if (i != 1)
                        {
                            if (e.IsTypedValue)
                                cari.tmpCariAd = e.TypedValue;

                            i = 1;
                            cari.Statuler.Add(AvukatProLib.Extras.CariStatu.Müvekkil);

                            //cari.MdiParent = null;
                            cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            cari.Show();
                            cari.FormClosed += delegate
                                                   {
                                                       DialogResult dr = cari.KayitBasarili;
                                                       if (dr == System.Windows.Forms.DialogResult.OK)
                                                       {
                                                           BelgeUtil.Inits.perCariGetirRefresh(e.SenderLookUp.Properties);
                                                       }
                                                   };
                        }
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
                if (e.SenderLookUp.Properties.Name.Contains("rLueSorumluSavci"))
                {
                    try
                    {
                        if (j != 1)
                        {
                            if (e.IsTypedValue)
                                cari.tmpCariAd = e.TypedValue;

                            j = 1;
                            cari.Statuler.Add(AvukatProLib.Extras.CariStatu.Adli_Personel);

                            //cari.MdiParent = null;
                            cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            cari.Show();
                            cari.FormClosed += delegate
                                                   {
                                                       DialogResult dr = cari.KayitBasarili;
                                                       if (dr == System.Windows.Forms.DialogResult.OK)
                                                       {
                                                           //Inits.perCariGetirRefresh();
                                                           BelgeUtil.Inits.perCariGetirRefresh(e.SenderLookUp.Properties);
                                                       }
                                                   };
                        }
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }

                if (e.SenderLookUp.Properties.Name.Contains("rLueSikayetKonu"))
                {
                    if (DTalep.DAVA_TALEP != e.SenderLookUp.Text)
                    {
                        DTalep.ADLI_BIRIM_BOLUM_ID = 1;
                        DTalep.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                        DTalep.KONTROL_NE_ZAMAN = DateTime.Now;
                        DTalep.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                        DTalep.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                        DTalep.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                        if (e.IsTypedValue)
                            DTalep.DAVA_TALEP = e.SenderLookUp.Text;
                        TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                        trans.BeginTransaction();
                        DataRepository.TD_KOD_DAVA_TALEPProvider.DeepSave(trans, DTalep);
                        trans.Commit();

                        ((TList<TD_KOD_DAVA_TALEP>)e.SenderLookUp.Properties.DataSource).Add(DTalep);
                        XtraMessageBox.Show("Þikayet Konusu baþarýyla eklenmiþtir.");
                    }
                }
            }
        }

        private void lueOzelKod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == "ekle")
            {
                AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle frm = new AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle();
                frm.Show();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            }
        }

        private void rbtnTemsilEkle_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            frmTemsilKayit frm = new frmTemsilKayit();
            AV001_TD_BIL_HAZIRLIK_TARAF trf =
                grdSikayetEden.GetRow(grdSikayetEden.FocusedRowHandle) as AV001_TD_BIL_HAZIRLIK_TARAF;
            DialogResult dr = frm.ShowDialog(trf, mySikayet);
        }

        private void rbtnTemsilEkleSEdilen_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            frmTemsilKayit frm = new frmTemsilKayit();
            AV001_TD_BIL_HAZIRLIK_TARAF trf =
                gridView2.GetRow(gridView2.FocusedRowHandle) as AV001_TD_BIL_HAZIRLIK_TARAF;
            DialogResult dr = frm.ShowDialog(trf, mySikayet);
        }

        private void rfrmSorusturmaGiris_Button_Editor_Click(object sender, EventArgs e)
        {
            frmEditor frmEdit = new frmEditor();
            frmEdit.MdiParent = mdiAvukatPro.MainForm;
            frmEdit.Show();
        }

        private void rfrmSorusturmaGiris_Button_IliskiliDosyalar_Click(object sender, EventArgs e)
        {
            frmKayitIliski iliski = new frmKayitIliski();
            iliski.MyHazirlik = MySikayet;

            // .MdiParent = null;
            iliski.StartPosition = FormStartPosition.WindowsDefaultLocation;
            iliski.Show();
        }

        private void rfrmSorusturmaGiris_Button_Kaydet_Click(object sender, EventArgs e)
        {
            MySikayet.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection = sorumluAvk;
            MySikayet.AV001_TD_BIL_HAZIRLIK_TARAFCollection = TumTaraflar;
            foreach (
                AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN neden in MySikayet.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection)
            {
                foreach (AV001_TD_BIL_HAZIRLIK_TARAF trf in SikayetEden)
                {
                    AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF antrf =
                        neden.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection.Find(
                            AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFColumn.TARAF_CARI_ID, trf.CARI_ID.Value);
                    if (antrf != null)
                    {
                        antrf.TARAF_SIFAT_ID = trf.TARAF_SIFAT_ID;
                        antrf.TARAF_CARI_ID = trf.CARI_ID;
                    }
                }
            }

            if (SorusturmaKaydet(mySikayet))
            {
                sikayetList.Add(mySikayet);
                if (SorusturmaKaydedildi == null)
                    XtraMessageBox.Show("Kaydedildi", "Kayit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.c_titemIliskiliDosyalar.Enabled = true;
            }
            else
            {
                XtraMessageBox.Show("Kayýt Esnasýnda Hata Oluþtu." + Environment.NewLine + "Dosya Kaydedilemedi.",
                                    "Kayit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rfrmSorusturmaGiris_Button_Outlook_Click(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pst);
        }

        private void rfrmSorusturmaGiris_Button_PDF_Click(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pdf);
        }

        private void rfrmSorusturmaGiris_Button_Word_Click(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.doc);
        }

        private void rfrmSorusturmaGiris_Button_XML_Click(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.xls);
        }

        private void rfrmSorusturmaGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MySikayet == null) return;
            if (MySikayet.ID > 0)
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        MySikayet.HAZIRLIK_NO + " " + "numaralý dosyayý takip ekranýna göndermek istiyor musunuz ? ",
                        "Soruþturma Takip", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    rFrmSorusturmaTakip frm = new rFrmSorusturmaTakip();
                    sikayetList.Add(MySikayet);
                    frm.Show(sikayetList);
                    frm.BringToFront();
                }
            }
        }

        private void rfrmSorusturmaGiris_Load(object sender, EventArgs e)
        {
            MySikayet = new AV001_TD_BIL_HAZIRLIK();

            ucSorusturmaNedenTaraf1.MyDataSource = MySikayet.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection;

            MySikayet.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection.AddingNew +=
                AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection_AddingNew;

            //Týklayýp gelecekler için
            rLueAdliye.NullText = "Seç";
            rLueSorumluSavci.NullText = "Seç";
            rLueSikayetEdilenTaraf.NullText = "Seç";
            rLueSikayetEdenCari.NullText = "Seç";
            rLueSikayetEdilenCari.NullText = "Seç";
            rLueSikayetKonu.NullText = "Seç";
            //Dolu gelecekler için
            rLueAdliBirimNo.NullText = "Seç";
            rLueAdliBirimGorev.NullText = "Seç";
            rLueSikayetEdenTaraf.NullText = "Seç";
            rLueSikayetEdilenSifat.NullText = "Seç";
            rLueSikayetEdenSifat.NullText = "Seç";
            rLueTemsilSekli.NullText = "Seç";
            rLueHazirlikDurum.NullText = "Seç";
            rlueSorusturmaDurum.NullText = "Seç";
            rLueSikayetNeden.NullText = "Seç";
            rlueDosyaDurum.NullText = "Seç";
            rLueTarafVAvukat.NullText = "Seç";
            rLueKarsiTarafVAvukat.NullText = "Seç";

            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            rLueSorumluSavci.Enter += delegate { BelgeUtil.Inits.CariAdliPersonelGetir(rLueSorumluSavci); };
            BelgeUtil.Inits.TarafKoduGetir(rLueSikayetEdenTaraf);
            BelgeUtil.Inits.TarafKoduGetir(rLueSikayetEdilenTaraf);
            BelgeUtil.Inits.TarafSifatGetirSikayetEdilen(rLueSikayetEdilenSifat);
            BelgeUtil.Inits.TarafSifatGetirSikayetEden(rLueSikayetEdenSifat);
            BelgeUtil.Inits.TemsilSekliGetir(rLueTemsilSekli);
            BelgeUtil.Inits.HazirlikDurumGetir(rLueHazirlikDurum);
            BelgeUtil.Inits.HazirlikDurumGetir(rlueSorusturmaDurum);
            BelgeUtil.Inits.SikayetNEdenGetir(rLueSikayetNeden);
            rLueSikayetKonu.Enter += delegate { BelgeUtil.Inits.SikayetKonuDavaTalepCezaGetir(rLueSikayetKonu, "C"); };
            BelgeUtil.Inits.DosyaDurumGetir(rlueDosyaDurum);
            BelgeUtil.Inits.FoyDurumGetir(rlueDosyaDurum);

            #region <MB-20100526>

            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueSikayetEdenCari);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueSikayetEdilenCari);

            //Sorumlu Avukat, personel mi, avukat mý bilgisine göre süzülüyordu. Bu koþullara carinin aktif kullanýcý olup olmadýðý kontrolü de eklendi.
            if (MyProje != null || OtomatikKayit)
            {
                //BelgeUtil.Inits.perCariGetir(rLueSikayetEdenCari);
                //BelgeUtil.Inits.perCariGetir(rLueSikayetEdilenCari);

                

                BelgeUtil.Inits.AktifAvukatlariGetir(grLueSorumluAvk);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliye);
            }
            else
            {
                //rLueSikayetEdenCari.Enter += delegate { AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueSikayetEdenCari); };
                //rLueSikayetEdilenCari.Enter += delegate { AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueSikayetEdilenCari); };
                grLueSorumluAvk.Enter += delegate { BelgeUtil.Inits.AktifAvukatlariGetir(grLueSorumluAvk); };
                rLueAdliye.Enter += delegate { BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliye); };
            }

            #endregion <MB-20100526>

            BindOzelKod();
            rLueOzelKod1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            rLueOzelKod2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            rLueOzelKod3.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            rLueOzelKod4.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);

            BelgeUtil.Inits.perCariGetir(rLueTarafVAvukat);
            BelgeUtil.Inits.perCariGetir(rLueKarsiTarafVAvukat);

            #region <YY-20090626> KLASOR DEN SORUSTURMA OLUSTURMA

            //Klasör den soruþturma oluþturma
            if (MyProje != null)
            {
                if (MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection.Count == 0)
                {
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TDIE_BIL_PROJE_TARAF>));
                }
                DataRepository.AV001_TDIE_BIL_PROJE_TARAFProvider.DeepLoad(
                    MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection, false, DeepLoadType.IncludeChildren,
                    typeof(AV001_TDI_BIL_CARI));

                if (MyProje.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Count == 0)
                {
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TDIE_BIL_PROJE_SORUMLU>));
                }
                foreach (AV001_TDIE_BIL_PROJE_TARAF trf in MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection)
                {
                    if (trf.CARI_IDSource != null)
                    {
                        #region <MB-20100525>

                        //Klasör üzerinden davacý, davalý durumuna göre taraflarýn gelmesi saðlandý.

                        if (ProjeSikayetEden)
                        {
                            if (trf.CARI_IDSource.MUVEKKIL_MI)
                            {
                                AV001_TD_BIL_HAZIRLIK_TARAF hazirlikTaraf = SikayetEden.AddNew();
                                hazirlikTaraf.CARI_ID = trf.CARI_ID;

                                //hazirlikTaraf.TARAF_SIFAT_ID = (int)TarafSifat.DAVACI;
                                hazirlikTaraf.TARAF_KODU = (byte)TarafKodu.Muvekkil;
                            }
                            else
                            {
                                AV001_TD_BIL_HAZIRLIK_TARAF hazirlikTaraf = SikayetEdilen.AddNew();
                                hazirlikTaraf.CARI_ID = trf.CARI_ID;

                                //hazirlikTaraf.TARAF_SIFAT_ID = (int)TarafSifat.DAVALI;
                                hazirlikTaraf.TARAF_KODU = (byte)TarafKodu.KarsiTaraf;
                            }
                        }
                        else
                        {
                            if (!trf.CARI_IDSource.MUVEKKIL_MI)
                            {
                                AV001_TD_BIL_HAZIRLIK_TARAF hazirlikTaraf = SikayetEden.AddNew();
                                hazirlikTaraf.CARI_ID = trf.CARI_ID;

                                //hazirlikTaraf.TARAF_SIFAT_ID = (int)TarafSifat.DAVACI;
                                hazirlikTaraf.TARAF_KODU = (byte)TarafKodu.KarsiTaraf;
                            }
                            else
                            {
                                AV001_TD_BIL_HAZIRLIK_TARAF hazirlikTaraf = SikayetEdilen.AddNew();
                                hazirlikTaraf.CARI_ID = trf.CARI_ID;

                                //hazirlikTaraf.TARAF_SIFAT_ID = (int)TarafSifat.DAVALI;
                                hazirlikTaraf.TARAF_KODU = (byte)TarafKodu.Muvekkil;
                            }
                        }

                        #endregion <MB-20100525>
                    }
                }
                foreach (AV001_TDIE_BIL_PROJE_SORUMLU sorumlu in MyProje.AV001_TDIE_BIL_PROJE_SORUMLUCollection)
                {
                    AV001_TD_BIL_HAZIRLIK_SORUMLU icSorumlu = sorumluAvk.AddNew();
                    if (sorumlu.YETKILI_MI == true)
                        icSorumlu.YETKILI_MI = true;
                    icSorumlu.CARI_ID = sorumlu.CARI_ID;
                    if (!icSorumlu.CARI_ID.HasValue)
                    {
                        sorumluAvk.Remove(icSorumlu);
                    }
                }
            }

            #endregion <YY-20090626> KLASOR DEN SORUSTURMA OLUSTURMA

            //TARIH         :  29 Eylül 2009 Salý
            //KODU YAZAN    :  Mehmet Emin AYDOÐDU
            //NEDENI        :   Baþlýklarýn Veri Tabnýndan Alýnmasý
            //Mehmet Begin

            #region Ozellestirme

            if (OzelKod1_2.PropertiesCollection["OZEL_KOD_1_ID"] != null)
                OzelKod1_2.PropertiesCollection["OZEL_KOD_1_ID"].Caption = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod1;
            if (OzelKod1_2.PropertiesCollection["OZEL_KOD_2_ID"] != null)
                OzelKod1_2.PropertiesCollection["OZEL_KOD_2_ID"].Caption = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod2;
            if (OzelKod3_4.PropertiesCollection["OZEL_KOD_3_ID"] != null)
                OzelKod3_4.PropertiesCollection["OZEL_KOD_3_ID"].Caption = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod3;
            if (OzelKod3_4.PropertiesCollection["OZEL_KOD_4_ID"] != null)
                OzelKod3_4.PropertiesCollection["OZEL_KOD_4_ID"].Caption = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod4;
            if (Refarans1_2_3.PropertiesCollection["REFERANS_NO"] != null)
                Refarans1_2_3.PropertiesCollection["REFERANS_NO"].Caption = Kimlikci.Kimlik.SorusturmaReferans.Referans1;
            if (Refarans1_2_3.PropertiesCollection["REFERANS_NO2"] != null)
                Refarans1_2_3.PropertiesCollection["REFERANS_NO2"].Caption =
                    Kimlikci.Kimlik.SorusturmaReferans.Referans2;
            if (Refarans1_2_3.PropertiesCollection["REFERANS_NO3"] != null)
                Refarans1_2_3.PropertiesCollection["REFERANS_NO3"].Caption =
                    Kimlikci.Kimlik.SorusturmaReferans.Referans3;

            #endregion Ozellestirme

            //Mehmet End
            if (OtomatikKayit)
            {
                ucSorusturmaNedenleri1.Refresh();
            }

            EditorButton btn = new EditorButton ();
            btn.Kind = ButtonPredefines.Plus;
            btn.Tag = "mEkle";
            rLueSikayetKonu.Buttons.Add(btn);
        }

        //private void rLueOzelKod2_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    LookUpEdit lue = sender as LookUpEdit;

        //    if (e.Button.Tag != null && e.Button.Tag == "OKEkle")
        //    {
        //        frmFoyOzelKodEkle foyOKod = new frmFoyOzelKodEkle();
        //        foyOKod.Sorusturmadan = true;
        //        DialogResult dr = foyOKod.ShowDialog(2, lue.Text);
        //        if (dr == DialogResult.OK)
        //        {
        //            List<Av001TdiKodFoyOzelEntity> dtOzelKod = rLueOzelKod2.DataSource as List<Av001TdiKodFoyOzelEntity>;
        //            if (dtOzelKod != null && foyOKod.MyOzelKod != null)
        //            {
        //                dtOzelKod.Add(foyOKod.MyOzelKod);
        //            }
        //        }
        //    }
        //}

        //private void rLueOzelKod2_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        //{
        //    LookUpEdit lue = sender as LookUpEdit;
        //    if (!string.IsNullOrEmpty(lue.Text))
        //    {
        //        frmFoyOzelKodEkle foyOKod = new frmFoyOzelKodEkle();
        //        foyOKod.Sorusturmadan = true;
        //        DialogResult dr = foyOKod.ShowDialog(2, e.DisplayValue.ToString());
        //        if (dr == DialogResult.OK)
        //        {
        //            List<Av001TdiKodFoyOzelEntity> dtOzelKod = rLueOzelKod2.DataSource as List<Av001TdiKodFoyOzelEntity>;
        //            if (dtOzelKod != null && foyOKod.MyOzelKod != null)
        //            {
        //                dtOzelKod.Add(foyOKod.MyOzelKod);
        //            }
        //        }
        //    }
        //}

        //private void rLueOzelKod3_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    LookUpEdit lue = sender as LookUpEdit;

        //    if (e.Button.Tag != null && e.Button.Tag == "OKEkle")
        //    {
        //        frmFoyOzelKodEkle foyOKod = new frmFoyOzelKodEkle();
        //        foyOKod.Sorusturmadan = true;
        //        DialogResult dr = foyOKod.ShowDialog(3, lue.Text);
        //        if (dr == DialogResult.OK)
        //        {
        //            List<Av001TdiKodFoyOzelEntity> dtOzelKod = rLueOzelKod3.DataSource as List<Av001TdiKodFoyOzelEntity>;
        //            if (dtOzelKod != null && foyOKod.MyOzelKod != null)
        //            {
        //                dtOzelKod.Add(foyOKod.MyOzelKod);
        //            }
        //        }
        //    }
        //}

        //private void rLueOzelKod3_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        //{
        //    LookUpEdit lue = sender as LookUpEdit;
        //    if (!string.IsNullOrEmpty(lue.Text))
        //    {
        //        frmFoyOzelKodEkle foyOKod = new frmFoyOzelKodEkle();
        //        foyOKod.Sorusturmadan = true;
        //        DialogResult dr = foyOKod.ShowDialog(3, e.DisplayValue.ToString());
        //        if (dr == DialogResult.OK)
        //        {
        //            List<Av001TdiKodFoyOzelEntity> dtOzelKod = rLueOzelKod3.DataSource as List<Av001TdiKodFoyOzelEntity>;
        //            if (dtOzelKod != null && foyOKod.MyOzelKod != null)
        //            {
        //                dtOzelKod.Add(foyOKod.MyOzelKod);
        //            }
        //        }
        //    }
        //}

        //private void rLueOzelKod4_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    LookUpEdit lue = sender as LookUpEdit;

        //    if (e.Button.Tag != null && e.Button.Tag == "OKEkle")
        //    {
        //        frmFoyOzelKodEkle foyOKod = new frmFoyOzelKodEkle();
        //        foyOKod.Sorusturmadan = true;
        //        DialogResult dr = foyOKod.ShowDialog(4, lue.Text);
        //        if (dr == DialogResult.OK)
        //        {
        //            List<Av001TdiKodFoyOzelEntity> dtOzelKod = rLueOzelKod4.DataSource as List<Av001TdiKodFoyOzelEntity>;
        //            if (dtOzelKod != null && foyOKod.MyOzelKod != null)
        //            {
        //                dtOzelKod.Add(foyOKod.MyOzelKod);
        //            }
        //        }
        //    }
        //}

        //private void rLueOzelKod4_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        //{
        //    LookUpEdit lue = sender as LookUpEdit;
        //    if (!string.IsNullOrEmpty(lue.Text))
        //    {
        //        frmFoyOzelKodEkle foyOKod = new frmFoyOzelKodEkle();
        //        foyOKod.Sorusturmadan = true;
        //        DialogResult dr = foyOKod.ShowDialog(4, e.DisplayValue.ToString());
        //        if (dr == DialogResult.OK)
        //        {
        //            List<Av001TdiKodFoyOzelEntity> dtOzelKod = rLueOzelKod4.DataSource as List<Av001TdiKodFoyOzelEntity>;
        //            if (dtOzelKod != null && foyOKod.MyOzelKod != null)
        //            {
        //                dtOzelKod.Add(foyOKod.MyOzelKod);
        //            }
        //        }
        //    }
        //}

        //private void rLueOzelKod_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    LookUpEdit lue = sender as LookUpEdit;

        //    if (e.Button.Tag != null && e.Button.Tag == "OKEkle")
        //    {
        //        frmFoyOzelKodEkle foyOKod = new frmFoyOzelKodEkle();
        //        foyOKod.Sorusturmadan = true;
        //        DialogResult dr = foyOKod.ShowDialog(1, lue.Text);
        //        if (dr == DialogResult.OK)
        //        {
        //            List<Av001TdiKodFoyOzelEntity> dtOzelKod = rLueOzelKod1.DataSource as List<Av001TdiKodFoyOzelEntity>;
        //            if (dtOzelKod != null && foyOKod.MyOzelKod != null)
        //            {
        //                dtOzelKod.Add(foyOKod.MyOzelKod);
        //            }
        //        }
        //    }
        //}

        //private void rLueOzelKod_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        //{
        //    LookUpEdit lue = sender as LookUpEdit;
        //    if (!string.IsNullOrEmpty(lue.Text))
        //    {
        //        frmFoyOzelKodEkle foyOKod = new frmFoyOzelKodEkle();
        //        foyOKod.Sorusturmadan = true;
        //        DialogResult dr = foyOKod.ShowDialog(1, e.DisplayValue.ToString());
        //        if (dr == DialogResult.OK)
        //        {
        //            List<Av001TdiKodFoyOzelEntity> dtOzelKod = rLueOzelKod1.DataSource as List<Av001TdiKodFoyOzelEntity>;
        //            if (dtOzelKod != null && foyOKod.MyOzelKod != null)
        //            {
        //                dtOzelKod.Add(foyOKod.MyOzelKod);
        //            }
        //        }
        //    }
        //}

        private void rLueSikayetEdenCari_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;

            if (e.Button.Tag != null && e.Button.Tag.ToString() == "mEkle")
            {
                frmCariGenelGiris cari = new frmCariGenelGiris();

                cari.tmpCariAd = lue.Text;
                cari.Statuler.Add(AvukatProLib.Extras.CariStatu.Müvekkil);

                //cari.MdiParent = null;
                cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cari.Show();
                cari.FormClosed += delegate
                                       {
                                           DialogResult dr = cari.KayitBasarili;
                                           if (dr == System.Windows.Forms.DialogResult.OK)
                                           {
                                               //Inits.perCariGetirRefresh();
                                               //BelgeUtil.Inits.perCariGetirRefresh(rLueSikayetEdenCari);
                                               AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueSikayetEdenCari);
                                           }
                                       };
            }
        }

        private void rLueSikayetEdenCari_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;

            frmCariGenelGiris cari = new frmCariGenelGiris();
            if (!string.IsNullOrEmpty(lue.Text))
            {
                cari.tmpCariAd = lue.Text;
                cari.Statuler.Add(AvukatProLib.Extras.CariStatu.Müvekkil);

                //cari.MdiParent = null;
                cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cari.Show();
                cari.FormClosed += delegate
                                       {
                                           DialogResult dr = cari.KayitBasarili;
                                           if (dr == System.Windows.Forms.DialogResult.OK)
                                           {
                                               //Inits.perCariGetirRefresh();
                                               BelgeUtil.Inits.perCariGetir(rLueSikayetEdenCari);
                                           }
                                       };
            }
        }

        private void rLueSikayetEdilenCari_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;

            if (e.Button.Tag != null && e.Button.Tag.ToString() == "mEkle")
            {
                frmCariGenelGiris cari = new frmCariGenelGiris();

                cari.tmpCariAd = lue.Text;
                cari.Statuler.Add(AvukatProLib.Extras.CariStatu.Karþý_Taraf);

                //cari.MdiParent = null;
                cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cari.Show();
                cari.FormClosed += delegate
                                       {
                                           DialogResult dr = cari.KayitBasarili;
                                           if (dr == System.Windows.Forms.DialogResult.OK)
                                           {
                                               //Inits.perCariGetirRefresh();
                                               //BelgeUtil.Inits.perCariGetir(rLueSikayetEdilenCari);
                                               AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueSikayetEdilenCari);
                                           }
                                       };
            }
        }

        private void rLueSikayetEdilenCari_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;

            frmCariGenelGiris cari = new frmCariGenelGiris();
            if (!string.IsNullOrEmpty(lue.Text))
            {
                cari.tmpCariAd = lue.Text;
                cari.Statuler.Add(AvukatProLib.Extras.CariStatu.Karþý_Taraf);

                //cari.MdiParent = null;
                cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cari.Show();
                cari.FormClosed += delegate
                                       {
                                           DialogResult dr = cari.KayitBasarili;
                                           if (dr == System.Windows.Forms.DialogResult.OK)
                                           {
                                               //Inits.perCariGetirRefresh();
                                               BelgeUtil.Inits.perCariGetir(rLueSikayetEdilenCari);
                                           }
                                       };
            }
        }

        private void rLueSikayetKonu_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Tag == null)
                    return;
                 
                if (e.Button.Tag == "mEkle")
                {
                    if (DTalep.DAVA_TALEP != (sender as LookUpEdit).Text || DTalep.DAVA_TALEP != string.Empty)
                    {
                        frmAltKategoriEkle frmalt = new frmAltKategoriEkle(frmAltKategoriEkle.Tipler.DavaKonusu, 1);
                        frmalt.ShowDialog();

                        ABSqlConnection cn = new ABSqlConnection();
                        cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

                        rLueSikayetKonu.DataSource = cn.GetDataTable("SELECT ID, DAVA_TALEP FROM dbo.per_TD_KOD_DAVA_TALEP(nolock) where ADLI_BIRIM_BOLUM_ID=" + 1);
                        rLueSikayetKonu.DisplayMember = "DAVA_TALEP";
                        rLueSikayetKonu.ValueMember = "ID";
                        rLueSikayetKonu.Columns.Clear();
                        rLueSikayetKonu.Columns.Add(new LookUpColumnInfo("DAVA_TALEP", "Talep", 40));

                        //DTalep.ADLI_BIRIM_BOLUM_ID = 1;

                        //DTalep.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                        //DTalep.KONTROL_NE_ZAMAN = DateTime.Now;
                        //DTalep.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                        //DTalep.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                        //DTalep.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                        //if (!string.IsNullOrEmpty((sender as LookUpEdit).Text))
                        //{
                        //    DTalep.DAVA_TALEP = (sender as LookUpEdit).Text;
                        //}
                        //TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                        //trans.BeginTransaction();
                        //DataRepository.TD_KOD_DAVA_TALEPProvider.DeepSave(trans, DTalep);
                        //trans.Commit();

                        //BelgeUtil.Inits.SikayetKonuDavaTalepCezaRefresh();
                        //BelgeUtil.Inits.SikayetKonuDavaTalepCezaGetir(rLueSikayetKonu, "C");
                        //XtraMessageBox.Show("Þikayet Konusu baþarýyla eklenmiþtir.");
                    }
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void rLueSikayetKonu_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            //LookUpEdit lue = sender as LookUpEdit;
            //if (DTalep.DAVA_TALEP != (sender as LookUpEdit).Text)
            //{
            //    try
            //    {
            //        if (DTalep.DAVA_TALEP != (sender as LookUpEdit).Text)
            //        {
            //            DTalep.ADLI_BIRIM_BOLUM_ID = 1;

            //            DTalep.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            //            DTalep.KONTROL_NE_ZAMAN = DateTime.Now;
            //            DTalep.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            //            DTalep.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            //            DTalep.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            //            if (!string.IsNullOrEmpty((sender as LookUpEdit).Text))
            //            {
            //                DTalep.DAVA_TALEP = (sender as LookUpEdit).Text;
            //            }
            //            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            //            trans.BeginTransaction();
            //            DataRepository.TD_KOD_DAVA_TALEPProvider.DeepSave(trans, DTalep);
            //            trans.Commit();

            //            if (BelgeUtil.Inits._SikayetKonuDavaTalepGetir == null)
            //                BelgeUtil.Inits._SikayetKonuDavaTalepGetir = DataRepository.per_TD_KOD_DAVA_TALEPProvider.GetAll();
            //            foreach (per_TD_KOD_DAVA_TALEP item in BelgeUtil.Inits._SikayetKonuDavaTalepGetir)
            //            {
            //                if (item.ID == DTalep.ID)
            //                    ((VList<per_TD_KOD_DAVA_TALEP>)((sender as LookUpEdit).Properties.DataSource)).Add(item);
            //            }

            //            XtraMessageBox.Show("Þikayet Konusu baþarýyla eklenmiþtir.");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        BelgeUtil.ErrorHandler.Catch(this, ex);
            //    }
            //}
        }

        private void rLueSorumluSavci_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;

            if (e.Button.Tag != null && e.Button.Tag.ToString() == "mEkle")
            {
                frmCariGenelGiris cari = new frmCariGenelGiris();

                cari.tmpCariAd = lue.Text;
                cari.Statuler.Add(AvukatProLib.Extras.CariStatu.Adli_Personel);

                //cari.MdiParent = null;
                cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cari.Show();
                cari.FormClosed += delegate
                                       {
                                           DialogResult dr = cari.KayitBasarili;
                                           if (dr == System.Windows.Forms.DialogResult.OK)
                                           {
                                               //Inits.perCariGetirRefresh();
                                               BelgeUtil.Inits.perCariGetir(rLueSorumluSavci);
                                           }
                                       };
            }
        }

        private void rLueSorumluSavci_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;

            frmCariGenelGiris cari = new frmCariGenelGiris();

            cari.tmpCariAd = lue.Text;
            cari.Statuler.Add(AvukatProLib.Extras.CariStatu.Adli_Personel);

            //cari.MdiParent = null;
            cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
            cari.Show();
            cari.FormClosed += delegate
                                   {
                                       DialogResult dr = cari.KayitBasarili;
                                       if (dr == System.Windows.Forms.DialogResult.OK)
                                       {
                                           //Inits.perCariGetirRefresh();
                                           BelgeUtil.Inits.perCariGetir(rLueSorumluSavci);
                                       }
                                   };
        }

        private void setHazirlik(AV001_TD_BIL_HAZIRLIK hazirlik)
        {
            SikayetEden = new TList<AV001_TD_BIL_HAZIRLIK_TARAF>();
            SikayetEdilen = new TList<AV001_TD_BIL_HAZIRLIK_TARAF>();
            SorumluAvk = new TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>();
            if (OtomatikKayit)
            {
                foreach (AV001_TD_BIL_HAZIRLIK_TARAF taraf in hazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection)
                {
                    if (taraf.TARAF_KODU == (short)TarafKodlari.M)
                    {
                        SikayetEden.Add(taraf);
                    }
                    else
                    {
                        SikayetEdilen.Add(taraf);
                    }
                }
                foreach (AV001_TD_BIL_HAZIRLIK_SORUMLU sorumlu in hazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection)
                {
                    SorumluAvk.Add(sorumlu);
                    sorumlu.CARI_ID = sorumlu.CARI_ID.Value;
                }
            }
            if (hazirlik.IsNew && !hazirlik.IsSelected)
            {
                foreach (string s in hazirlik.TableColumns)
                {
                    if (s.EndsWith("DOVIZ_ID"))
                        hazirlik.GetType().GetProperty(s).SetValue(hazirlik, 1, null);
                }
                hazirlik.SIKAYET_TARIHI = DateTime.Now;

                //  hazirlik.HAZIRLIK_DURUM_ID = 2;
                hazirlik.HAZIRLIK_NO = HazirlikNoGetir();

                hazirlik.HAZIRLIK_TARIH = DateTime.Today;
                hazirlik.HAZIRLIK_ESAS_NO = DateTime.Now.Year + "/";
                hazirlik.DOSYA_DURUM_ID = 2;
                hazirlik.DURUM_ID = 1;
                hazirlik.HAZIRLIK_DURUM_ID = 1;
                if (!OtomatikKayit)
                {
                    hazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection = new TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>();
                    hazirlik.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection =
                        new TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN>();
                }
            }
            else
            {
                DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(hazirlik, true, DeepLoadType.IncludeChildren,
                                                                      typeof(TList<AV001_TD_BIL_HAZIRLIK_TARAF>),
                                                                      typeof(TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>),
                                                                      typeof(TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN>
                                                                          ),
                                                                      typeof(TDI_KOD_TARAF),
                                                                      typeof(TDIE_KOD_TARAF_SIFAT),
                                                                      typeof(TList<AV001_TDIE_BIL_ASAMA>));

                DataRepository.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENProvider.DeepLoad(
                    hazirlik.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection, true, DeepLoadType.IncludeChildren,
                    typeof(TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF>),
                    typeof(TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>),
                    typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>),
                    typeof(TList<AV001_TDI_BIL_POLICE>),
                    typeof(TList<NN_SIKAYET_NEDEN_GAYRIMENKUL>),
                    typeof(TList<NN_SIKAYET_NEDEN_GEMI_UCAK_ARAC>),
                    typeof(TList<NN_SIKAYET_NEDEN_KIYMETLI_EVRAK>),
                    typeof(TList<AV001_TDIE_BIL_ASAMA>));

                TumTaraflar = hazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection;
                SorumluAvk = hazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection;
            }
            hazirlik.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection.AddingNew +=
                AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection_AddingNew;
            hazirlik.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection.AddingNew +=
                AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection_AddingNew;
            if (!OtomatikKayit)
            {
                hazirlik.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection.AddNew();
            }

            hazirlik.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection.AddNew();

            ucSorusturmaNedenleri1.MyDataSource = hazirlik.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection;

            foreach (AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN var in hazirlik.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection)
            {
                ucKiymetliEvrak1.MyDataSource =
                    var.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_SIKAYET_NEDEN_KIYMETLI_EVRAK;

                ucGayriMenkul1.MyDataSource = var.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SIKAYET_NEDEN_GAYRIMENKUL;

                ucPoliceBilgileri1.MyDataSource = var.AV001_TDI_BIL_POLICECollection_From_NN_SIKAYET_NEDEN_POLICE;

                ucUcakGemiArac1.MyDataSource = BelgeUtil.Inits.GemiUcakAracGetirBySikayetNedenId(var.ID).FindAll(vi => vi.GEMI_UCAK_ARAC_TIP == (byte)1);
                ugaGemi.MyDataSource = BelgeUtil.Inits.GemiUcakAracGetirBySikayetNedenId(var.ID).FindAll(vi => vi.GEMI_UCAK_ARAC_TIP == (byte)2);
                ugaArac.MyDataSource = BelgeUtil.Inits.GemiUcakAracGetirBySikayetNedenId(var.ID).FindAll(vi => vi.GEMI_UCAK_ARAC_TIP == (byte)3);
            }
            exgrdSikayetEden.DataSource = SikayetEden;
            exgrdSikayetEdilen.DataSource = SikayetEdilen;
            exgrdSorumluAvukat.DataSource = SorumluAvk;

            SikayetEden.AddingNew += SikayetEden_AddingNew;

            SikayetEdilen.AddingNew += SikayetEdilen_AddingNew;
            SorumluAvk.AddingNew += SorumluAvk_AddingNew;
            TList<AV001_TD_BIL_HAZIRLIK> sikayetlist = new TList<AV001_TD_BIL_HAZIRLIK>();
            sikayetlist.Add(hazirlik);
            AV001_TD_BIL_HAZIRLIKBindingSource.DataSource = sikayetlist;
            vgSorusturmaGenelBilgiler.DataSource = sikayetlist;
        }

        private void SikayetEden_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_HAZIRLIK_TARAF addnew = new AV001_TD_BIL_HAZIRLIK_TARAF();
            addnew.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection = new TList<AV001_TD_BIL_HAZIRLIK_TARAF_VEKIL>();
            addnew.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection.AddingNew +=
                AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection_AddingNew;

            //addnew.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection.AddNew();
            if (String.IsNullOrEmpty(((TList<TDI_KOD_TARAF>)rLueSikayetEdenTaraf.DataSource).Filter))
                addnew.TARAF_KODU = (int)TarafKodu.Muvekkil;
            else
            {
                string[] boll = ((TList<TDI_KOD_TARAF>)rLueSikayetEdenTaraf.DataSource).Filter.Split(' ');
                if (Convert.ToBoolean(boll[2]))
                {
                    addnew.TARAF_KODU = (int)TarafKodu.KarsiTaraf;
                }
                else
                {
                    addnew.TARAF_KODU = (int)TarafKodu.Muvekkil;
                }
            }
            addnew.TARAF_SIFAT_ID = (int)TarafSifat.YAKINAN;
            addnew.SIKAYET_EDEN_MI = true;
            addnew.KAYIT_TARIHI = DateTime.Now;
            addnew.KONTROL_NE_ZAMAN = DateTime.Now;
            addnew.KONTROL_KIM = "AvukatPro";
            addnew.KONTROL_VERSIYON = 0;
            addnew.STAMP = 1;
            addnew.KLASOR_KODU = "GENEL";
            e.NewObject = addnew;
        }

        private void SikayetEdilen_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_HAZIRLIK_TARAF addnew = new AV001_TD_BIL_HAZIRLIK_TARAF();
            addnew.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection = new TList<AV001_TD_BIL_HAZIRLIK_TARAF_VEKIL>();
            addnew.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection.AddingNew +=
                AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection_AddingNew;

            //addnew.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection.AddNew();
            if (String.IsNullOrEmpty(((TList<TDI_KOD_TARAF>)rLueSikayetEdilenTaraf.DataSource).Filter))
                addnew.TARAF_KODU = (int)TarafKodu.KarsiTaraf;

            else
            {
                string[] bol = ((TList<TDI_KOD_TARAF>)rLueSikayetEdilenTaraf.DataSource).Filter.Split(' ');
                if (Convert.ToBoolean(bol[2]))
                {
                    addnew.TARAF_KODU = (int)TarafKodu.Muvekkil;
                }
                else
                {
                    addnew.TARAF_KODU = (int)TarafKodu.KarsiTaraf;
                }
            }
            addnew.TARAF_SIFAT_ID = (int)TarafSifat.SANIK;
            addnew.SIKAYET_EDEN_MI = false;
            addnew.KAYIT_TARIHI = DateTime.Now;
            addnew.KONTROL_NE_ZAMAN = DateTime.Now;
            addnew.KONTROL_KIM = "AvukatPro";
            addnew.KONTROL_VERSIYON = 0;
            addnew.STAMP = 1;
            addnew.KLASOR_KODU = "GENEL";
            e.NewObject = addnew;
        }

        private void SorumluAvk_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_HAZIRLIK_SORUMLU addnew = new AV001_TD_BIL_HAZIRLIK_SORUMLU();
            addnew.KAYIT_TARIHI = DateTime.Now;
            addnew.KONTROL_NE_ZAMAN = DateTime.Now;
            addnew.KONTROL_KIM = "AVUKATPRO";
            addnew.KONTROL_VERSIYON = 0;
            addnew.STAMP = 1;
            addnew.KLASOR_KODU = "GENEL";
            e.NewObject = addnew;
        }

        private void Tabs_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (SikayetEdilen.Count > 0)
                ucKiymetliEvrak1.TARAF_ID = SikayetEdilen[0].CARI_ID.Value;
            switch (e.Page.Name)
            {
                case "tabpSorusturmaNedenleri":

                    foreach (Control c in this.pnTemp.Controls)
                    {
                        if (c.Name == "grpSikayetNedenleri")
                        {
                            pnlSorusturma.Controls.Clear();
                            pnlSorusturma.Controls.Add(c);
                            c.Dock = DockStyle.Fill;
                        }
                    }

                    break;

                case "tbpGenel":

                    foreach (Control c in this.pnlSorusturma.Controls)
                    {
                        if (c.Name == "grpSikayetNedenleri")
                        {
                            pnTemp.Controls.Add(c);
                            c.Dock = DockStyle.Bottom;
                        }
                    }

                    break;
            }
        }

        #endregion Methods
    }
}