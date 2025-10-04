using AdimAdimDavaKaydi.PaketKontrol;
using AdimAdimDavaKaydi.IcraTakipForms;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi
{
    public partial class frmDavaDosyaKayitForm : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        #region Fields

        public bool DavaDosyasiKayitIceriden;
        public bool ProjeDavaci;
        private readonly TDI_KOD_TARAF tmpTaraf = new TDI_KOD_TARAF();
        private List<string> _myList = new List<string>();
        private byte CariEkleniyor = 0;
        private TList<AvukatProLib2.Entities.AV001_TDI_BIL_CARI> clone;
        private CariStatu csDavaEden;
        private CariStatu csDavaEdilen;
        private TList<AV001_TD_BIL_FOY_TARAF> davaEden;
        private TD_BIL_DAVA_KULLANICI_AYAR davaGenelAyarim = new TD_BIL_DAVA_KULLANICI_AYAR();
        private TList<TD_BIL_DAVA_KULLANICI_AYAR> davaGenelAyarlar = new TList<TD_BIL_DAVA_KULLANICI_AYAR>();

        private TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYAR davaNedenSecenekAyarim =
            new TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYAR();

        private TList<TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYAR> davaNedenSecenekAyarlar =
            new TList<TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYAR>();

        private int? davaTipi;
        private bool davaTipiDegisti;

        //Üst menülerde dosya kaydýndan önce iþlem yapýlmamasýný saðlamak için eklendi.MB
        private bool dosyaKaydedildi = false;

        private TD_KOD_DAVA_TALEP DTalep = new TD_KOD_DAVA_TALEP();
        private TList<AV001_TD_BIL_FOY> foyList = new TList<AV001_TD_BIL_FOY>();

        //Taraf koduna göre cari bilgisinin dolmasýný saðlamak için eklendi. Taraf kodu M ise Müvekkil mi True olanlar, deðil ise tüm cariler doluyor.


        private AV001_TD_BIL_FOY myFoy;

        private TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT> sorumluAvk;
        private TList<AV001_TDI_BIL_CARI> sorumluAvkCari;

        #endregion Fields

        #region Constructors

        public frmDavaDosyaKayitForm()
        {
            //this.Enabled = false;
            InitializeComponent();
            ucOzelKodBankaSubeBilgileri1.isFoyNew = ucDavaNedenleri1.isFoyNew = !OtomatikKayit;
            gvDavaEden.CellValueChanged += gvDavaEden_CellValueChanged;
            gvDavaEdilen.CellValueChanged += gvDavaEdilen_CellValueChanged;

            this.vgDavaGenelBilgiler.CellValueChanging +=
                vgDavaGenelBilgiler_CellValueChanging;

            gvSorumluAvukat.ValidateRow += gvSorumluAvukat_ValidateRow;
            gvDavaEdilen.ValidateRow += gvDavaEdilen_ValidateRow;
            gvDavaEden.ValidateRow += gvDavaEden_ValidateRow;
            gvDavaEden.CustomRowCellEdit += gvDavaEden_CustomRowCellEdit;
            InitializeEvents();
            this.FormClosing += frmDavaDosyaKayitForm_FormClosing;
            this.Enabled = true;
            this.Load += frmDavaDosyaKayitForm_Load;

            if (AvukatProLib.Kimlik.SirketBilgisi.LisansBilgisi.DavaKayitSayisi.HasValue)
            {
                int total = BelgeUtil.Inits.context.GetDosyaCount((int)AvukatProLib.Extras.Modul.Dava).FirstOrDefault().DosyaSayisi.Value;
                if (total >= AvukatProLib.Kimlik.SirketBilgisi.LisansBilgisi.DavaKayitSayisi.Value)
                {
                    MessageBox.Show("Toplam Dava Kayýt Limitiniz Dolduðundan Yeni Dava Kaydý Yapamazsýnýz.");
                    this.Close();
                }
            }
        }

        #endregion Constructors

        #region Events

        public event EventHandler<DavaFoyKaydedildiEventArgs> DavaFoyKaydedildi;

        #endregion Events

        #region Properties

        public TList<AV001_TD_BIL_FOY_TARAF> DavaEden
        {
            get { return davaEden; }
            set { davaEden = value; }
        }

        public TList<AV001_TD_BIL_FOY_TARAF> DavaEdilen
        {
            get;
            set;
        }

        public int GayrimenkulID
        {
            get;
            set;
        }

        public int GUAID
        {
            get;
            set;
        }

        public bool IsAutoCreatedDava
        {
            get;
            set;
        }

        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                try
                {
                    setFoy(value);
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        public AV001_TD_BIL_FOY MyFoyAyar
        {
            get;
            set;
        }

        [Browsable(false)]
        public AV001_TI_BIL_FOY_TARAF_GELISME MyGelisme
        {
            get;
            set;
        }

        public AV001_TDIE_BIL_PROJE MyProje
        {
            get;
            set;
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

        public AV001_TD_BIL_HAZIRLIK RelatedSorusturma
        {
            get;
            set;
        }

        public TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT> SorumluAvk
        {
            get { return sorumluAvk; }
            set { sorumluAvk = value; }
        }

        public TList<AV001_TDI_BIL_CARI> SorumluAvkCari
        {
            get
            {
                if (grLueSorumluAvk.DataSource != null && grLueSorumluAvk.DataSource is TList<AV001_TDI_BIL_CARI>)
                {
                    return (TList<AV001_TDI_BIL_CARI>)grLueSorumluAvk.DataSource;
                }
                return new TList<AV001_TDI_BIL_CARI>();
            }
            set { sorumluAvkCari = value; }
        }

        public TList<AV001_TD_BIL_FOY_TARAF> TumTaraflar
        {
            get
            {
                TList<AV001_TD_BIL_FOY_TARAF> result = new TList<AV001_TD_BIL_FOY_TARAF>();
                result.AddRange(DavaEden);
                result.AddRange(DavaEdilen);
                return result;
            }
            set
            {
                DavaEden.Clear();
                DavaEdilen.Clear();
                DataRepository.AV001_TD_BIL_FOY_TARAFProvider.DeepLoad(value, true, DeepLoadType.IncludeChildren,
                                                                       typeof(TDIE_KOD_TARAF_SIFAT),
                                                                       typeof(TList<AV001_TD_BIL_FOY_TARAF_VEKIL>));
                foreach (AV001_TD_BIL_FOY_TARAF taraf in value)
                {
                    if (taraf.TARAF_SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN")
                    {
                        davaEden.Add(taraf);
                    }
                    else if (taraf.TARAF_SIFAT_IDSource.HANGI_TARAFI == "DAVA EDÝLEN")
                    {
                        DavaEden.Add(taraf);
                    }
                }
            }
        }

        #endregion Properties

        #region Methods

        public static string FoyNoGetir()
        {
            string foyNo = String.Empty;
            var foyNoList = (from item in BelgeUtil.Inits.context.AV001_TD_BIL_FOYs.Where(f => f.FOY_NO != "NULL") orderby item.ID descending select item.FOY_NO);

            if (foyNoList.Count() > 0)
            {
                int foyNoSayi = int.Parse(foyNoList.First().Split('~')[1]);
                var foy_No = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, "select top(1)FOY_NO from AV001_TD_BIL_FOY order by KAYIT_TARIHI desc");
                foyNo = String.Format("D-{0}~{1}", DateTime.Today.Year, foyNoSayi + 1);
            }
            else
            {
                foyNo = String.Format("D-{0}~{1}", DateTime.Today.Year, 10001);
            }
            return foyNo;
        }

        public bool FoyuKaydet(AV001_TD_BIL_FOY foy)
        {
            try
            {
                foreach (AV001_TD_BIL_FOY_SORUMLU_AVUKAT sorumluAv in foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection)
                {
                    if (sorumluAv.SORUMLU_AVUKAT_CARI_IDSource != null)
                        sorumluAv.SORUMLU_AVUKAT_CARI_ID = sorumluAv.SORUMLU_AVUKAT_CARI_IDSource.ID;
                }
                if (foy.IsNew)
                {
                    foy.KAYIT_TARIHI = DateTime.Now;
                    foy.KONTROL_NE_ZAMAN = DateTime.Now;
                    foy.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    foy.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    foy.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    foy.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;

                    //Dosyada en az bir tane sorumlu olmasý gerektiðinden, tek avukat olan dosyalarda kullanýcý izleyen mi alanýný iþaretlediðinde bu alanýn false olmasý saðlanýyor. MB
                    if (foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Count == 1 && foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.FindAll(vi => !vi.YETKILI_MI).Count == 0)
                        foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection[0].YETKILI_MI = false;

                    foy.SUBE_KOD_ID = AdimAdimDavaKaydi.Forms.frmKlasorYeni.KullaniciSubeIDGetir(foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Find(vi => !vi.YETKILI_MI).SORUMLU_AVUKAT_CARI_ID.Value);
                }
                foreach (AV001_TDI_BIL_MASRAF_AVANS avans in foy.AV001_TDI_BIL_MASRAF_AVANSCollection)
                {
                    if (avans.IsNew)
                    {
                        avans.KAYIT_TARIHI = DateTime.Now;
                        avans.KONTROL_NE_ZAMAN = DateTime.Now;
                        avans.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                        avans.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                        avans.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                        avans.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    }
                }

                //Okan Performans
                var result = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, "select top(1) ID from AV001_TD_BIL_VEKALET_SOZLESME where DEFAULT_SOZLESME_MI = 'True'");
                if (result != null)
                {
                    foy.VEKALET_SOZLESME_ID = (int)result;
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(typeof(frmDavaDosyaKayitForm), ex);
            }

            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                trans.BeginTransaction();

                AdimAdimDavaKaydi.Util.AsamaHelper.IlkTebligatAsamaHallet(MyFoy);

                #region <MB-20100621>

                //Dosya kaydý sýrasýnda FOY_NO bilgisinin unique olmasýný saðlamak için tekrardan kontrol eklendi.
                if (foy.IsNew && !BelgeUtil.Inits.Telekomunukasyonmu)
                {
                    if (foy.FOY_NO == "NULL")
                        foy.FOY_NO = FoyNoGetir();
                    if (DataRepository.AV001_TD_BIL_FOYProvider.Find(string.Format("FOY_NO = {0}", foy.FOY_NO)).Count > 0)
                        foy.FOY_NO = FoyNoGetir();
                }
                else if (BelgeUtil.Inits.Telekomunukasyonmu)
                {
                    if (foy.FOY_NO.Length < 5)
                    {
                        string sabit = string.Empty;

                        for (int i = 0; i < 5 - foy.FOY_NO.Length; i++)
                        {
                            sabit += "0";
                        }
                        foy.FOY_NO = sabit + foy.FOY_NO;
                    }
                }

                #endregion <MB-20100621>

                foreach (var item in DavaEden)
                {
                    #region DavaEden

                    foreach (var trfVekil in item.AV001_TD_BIL_FOY_TARAF_VEKILCollection)
                    {
                        if (trfVekil.FOY_TARAF_ID == null && trfVekil.FOY_TARAF_ID == 0) //|| trfVekil.FOY_TARAF_IDSource == null)
                        {
                            trfVekil.FOY_TARAF_CARI_ID = item.CARI_ID;
                            trfVekil.FOY_TARAF_ID = item.ID;
                        }
                    }

                    #endregion DavaEden
                }

                //foreach (var item in DavaEdilen)
                //{
                //    #region DavaEdilen

                //    foreach (var trfVekil in item.AV001_TD_BIL_FOY_TARAF_VEKILCollection)
                //    {
                //        if (trfVekil.FOY_TARAF_ID == null && trfVekil.FOY_TARAF_ID == 0) // || trfVekil.FOY_TARAF_IDSource == null)
                //        {
                //            trfVekil.FOY_TARAF_CARI_ID = item.CARI_ID;
                //            trfVekil.FOY_TARAF_ID = item.ID;
                //        }
                //    }

                //    #endregion DavaEdilen
                //}

                // AsamaHelper.AsamalariHallet(MyFoy);

                //DataRepository.AV001_TD_BIL_FOYProvider.DeepSave(trans, foy);
                DataRepository.AV001_TD_BIL_FOYProvider.Save(trans, foy);

                foreach (AV001_TD_BIL_DAVA_NEDEN neden in foy.AV001_TD_BIL_DAVA_NEDENCollection)
                {
                    neden.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC.ForEach(
                        delegate(AV001_TDI_BIL_GEMI_UCAK_ARAC obj)
                        {
                            if (neden.AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARACCollection.Count(item => item.GEMI_UCAK_ARAC_ID == obj.ID) == 0)
                            {
                                AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC gua =
                                    neden.AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARACCollection.AddNew();
                                gua.GEMI_UCAK_ARAC_IDSource = obj;
                            }
                        });

                    neden.AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL.ForEach(
                        delegate(AV001_TI_BIL_GAYRIMENKUL obj)
                        {
                            if (neden.AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKULCollection.Count(item => item.GAYRIMENKUL_ID == obj.ID) == 0)
                            {
                                AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL gm =
                                    neden.AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKULCollection.AddNew();

                                gm.GAYRIMENKUL_IDSource = obj;
                            }
                        });
                    neden.AV001_TDI_BIL_POLICECollection_From_NN_DAVA_NEDEN_POLICE.ForEach(
                        delegate(AV001_TDI_BIL_POLICE obj)
                        {
                            if (neden.NN_DAVA_NEDEN_POLICECollection.Count(item => item.POLICE_ID == obj.ID) == 0)
                            {
                                NN_DAVA_NEDEN_POLICE pol = neden.NN_DAVA_NEDEN_POLICECollection.AddNew();
                                pol.POLICE_IDSource = obj;
                            }
                        });
                    neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW.ForEach(
                        delegate(AV001_TDI_BIL_SOZLESME obj)
                        {
                            if (neden.AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEWCollection.Count(item => item.SOZLESME_ID == obj.ID) == 0)
                            {
                                AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW sn =
                                    neden.AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEWCollection.AddNew();
                                sn.SOZLESME_IDSource = obj;
                            }
                        }
                        );
                    neden.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK.
                        ForEach(
                            delegate(AV001_TDI_BIL_KIYMETLI_EVRAK obj)
                            {
                                if (neden.AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAKCollection.Count(item => item.KIYMETLI_EVRAK_ID == obj.ID) == 0)
                                {
                                    AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK ke =
                                        neden.AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAKCollection.AddNew();

                                    ke.KIYMETLI_EVRAK_IDSource = obj;
                                }
                            }
                        );
                    foreach (AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK dNKEvrak in neden.AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAKCollection)
                    {
                        if (foy.NN_DAVA_KIYMETLI_EVRAKCollection.Exists(
                                delegate(NN_DAVA_KIYMETLI_EVRAK kiymetli) { return kiymetli.KIYMETLI_EVRAK_ID == dNKEvrak.KIYMETLI_EVRAK_ID; })) continue;
                        NN_DAVA_KIYMETLI_EVRAK kEvrak = foy.NN_DAVA_KIYMETLI_EVRAKCollection.AddNew();
                        kEvrak.KIYMETLI_EVRAK_IDSource = dNKEvrak.KIYMETLI_EVRAK_IDSource;
                        kEvrak.DAVA_FOY_ID = foy.ID;
                    }
                    foreach (
                        AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC gua in
                            neden.AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARACCollection)
                    {
                        if (
                            foy.NN_DAVA_GEMI_UCAK_ARACCollection.Exists(
                                delegate(NN_DAVA_GEMI_UCAK_ARAC arac) { return arac.GEMI_UCAK_ARAC_ID == gua.GEMI_UCAK_ARAC_ID; })) continue;
                        NN_DAVA_GEMI_UCAK_ARAC Igua = foy.NN_DAVA_GEMI_UCAK_ARACCollection.AddNew();
                        Igua.GEMI_UCAK_ARAC_IDSource = gua.GEMI_UCAK_ARAC_IDSource;
                        Igua.DAVA_FOY_ID = foy.ID;
                    }
                    foreach (
                        AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL gayrimenkul in
                            neden.AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKULCollection)
                    {
                        if (
                            foy.NN_DAVA_GAYRIMENKULCollection.Exists(
                                delegate(NN_DAVA_GAYRIMENKUL gayrimen) { return gayrimen.GAYRIMENKUL_ID == gayrimenkul.GAYRIMENKUL_ID; })) continue;
                        NN_DAVA_GAYRIMENKUL Igayrimenkul = foy.NN_DAVA_GAYRIMENKULCollection.AddNew();
                        Igayrimenkul.GAYRIMENKUL_IDSource = gayrimenkul.GAYRIMENKUL_IDSource;
                        Igayrimenkul.DAVA_FOY_ID = foy.ID;
                    }
                    foreach (AV001_TDI_BIL_SOZLESME sozlesme in neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW)
                    {
                        if (foy.NN_DAVA_SOZLESMECollection.Exists(delegate(NN_DAVA_SOZLESME sozles) { return sozles.SOZLESME_ID == sozlesme.ID; }))
                            continue;
                        NN_DAVA_SOZLESME soz = foy.NN_DAVA_SOZLESMECollection.AddNew();
                        soz.SOZLESME_IDSource = sozlesme;
                        soz.DAVA_FOY_ID = foy.ID;
                    }
                    foreach (NN_DAVA_NEDEN_POLICE police in neden.NN_DAVA_NEDEN_POLICECollection)
                    {
                        if (
                            foy.NN_DAVA_POLICECollection.Exists(
                                delegate(NN_DAVA_POLICE pol) { return pol.POLICE_ID == police.POLICE_ID; })) continue;
                        NN_DAVA_POLICE poli = foy.NN_DAVA_POLICECollection.AddNew();
                        poli.POLICE_IDSource = police.POLICE_IDSource;
                        poli.DAVA_FOY_ID = foy.ID;
                    }
                }

                if (GayrimenkulID != 0)
                {
                    if (foy.NN_DAVA_GAYRIMENKULCollection.Find(vi => vi.DAVA_FOY_ID == foy.ID && vi.GAYRIMENKUL_ID == GayrimenkulID) == null)
                    {
                        NN_DAVA_GAYRIMENKUL davaGayrimenkul = foy.NN_DAVA_GAYRIMENKULCollection.AddNew();
                        davaGayrimenkul.DAVA_FOY_ID = foy.ID;
                        davaGayrimenkul.GAYRIMENKUL_ID = GayrimenkulID;
                    }
                }
                else if (GUAID != 0)
                {
                    if (foy.NN_DAVA_GEMI_UCAK_ARACCollection.Find(vi => vi.DAVA_FOY_ID == foy.ID && vi.GEMI_UCAK_ARAC_ID == GUAID) == null)
                    {
                        NN_DAVA_GEMI_UCAK_ARAC davaGUA = foy.NN_DAVA_GEMI_UCAK_ARACCollection.AddNew();
                        davaGUA.DAVA_FOY_ID = foy.ID;
                        davaGUA.GEMI_UCAK_ARAC_ID = GUAID;
                    }
                }

                #region Kayýt

                DataRepository.AV001_TD_BIL_FOYProvider.DeepSave(trans, foy, DeepSaveType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_TARAF>), typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>), typeof(TList<AV001_TDI_BIL_TEBLIGAT>), typeof(TList<AV001_TD_BIL_DAVA_NEDEN>), typeof(TList<NN_DAVA_GAYRIMENKUL>), typeof(TList<NN_DAVA_GEMI_UCAK_ARAC>), typeof(TList<NN_DAVA_KIYMETLI_EVRAK>), typeof(TList<NN_DAVA_POLICE>), typeof(TList<NN_DAVA_SOZLESME>), typeof(TList<AV001_TDIE_BIL_ASAMA>), typeof(TList<NN_DAVA_NEDEN_POLICE>));

                if (foy.AV001_TDI_BIL_TEBLIGATCollection.Count > 0)
                {
                    foreach (var tebligat in foy.AV001_TDI_BIL_TEBLIGATCollection)
                    {
                        if (tebligat.NN_TEBLIGAT_DAVACollection.Count < 1)
                            tebligat.NN_TEBLIGAT_DAVACollection.Add(new NN_TEBLIGAT_DAVA() { DAVA_FOY_ID = tebligat.DAVA_FOY_ID.Value });
                        if (tebligat.ID == 0)
                            tebligat.STAMP = 0;
                    }
                    DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(trans, foy.AV001_TDI_BIL_TEBLIGATCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>), typeof(TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>), typeof(TList<NN_TEBLIGAT_DAVA>));
                }

                DataRepository.AV001_TD_BIL_FOY_TARAFProvider.Save(trans, foy.AV001_TD_BIL_FOY_TARAFCollection);

                // aykut taraf vekil tablosuna kayýt atmasý için eklendi. (20.05.2013)
                if (((AV001_TD_BIL_FOY_TARAF)gvDavaEden.GetRow(0)).AV001_TD_BIL_FOY_TARAF_VEKILCollection.Count > 0 & ((AV001_TD_BIL_FOY_TARAF)gvDavaEden.GetRow(0)).AV001_TD_BIL_FOY_TARAF_VEKILCollection.Count < 10)
                {
                    foreach (var xx in ((AV001_TD_BIL_FOY_TARAF)gvDavaEden.GetRow(0)).AV001_TD_BIL_FOY_TARAF_VEKILCollection)
                    {
                        xx.DAVA_FOY_ID = foy.ID;
                        xx.FOY_TARAF_ID = foy.AV001_TD_BIL_FOY_TARAFCollection[0].ID;
                        xx.FOY_TARAF_CARI_ID = foy.AV001_TD_BIL_FOY_TARAFCollection[0].CARI_ID;
                    }
                    DataRepository.AV001_TD_BIL_FOY_TARAF_VEKILProvider.Save(trans, ((AV001_TD_BIL_FOY_TARAF)gvDavaEden.GetRow(0)).AV001_TD_BIL_FOY_TARAF_VEKILCollection);
                }
                if (((AV001_TD_BIL_FOY_TARAF)gvDavaEdilen.GetRow(0)).AV001_TD_BIL_FOY_TARAF_VEKILCollection.Count > 0 & ((AV001_TD_BIL_FOY_TARAF)gvDavaEdilen.GetRow(0)).AV001_TD_BIL_FOY_TARAF_VEKILCollection.Count < 10)
                {
                    foreach (var xx in ((AV001_TD_BIL_FOY_TARAF)gvDavaEdilen.GetRow(0)).AV001_TD_BIL_FOY_TARAF_VEKILCollection)
                    {
                        xx.DAVA_FOY_ID = foy.ID;
                        xx.FOY_TARAF_ID = foy.AV001_TD_BIL_FOY_TARAFCollection[1].ID;
                        xx.FOY_TARAF_CARI_ID = foy.AV001_TD_BIL_FOY_TARAFCollection[1].CARI_ID;
                    }
                    DataRepository.AV001_TD_BIL_FOY_TARAF_VEKILProvider.Save(trans, ((AV001_TD_BIL_FOY_TARAF)gvDavaEdilen.GetRow(0)).AV001_TD_BIL_FOY_TARAF_VEKILCollection);
                }
                // aykut taraf vekil tablosuna kayýt atmasý için eklendi. son (20.05.2013)

                //DataRepository.AV001_TD_BIL_FOY_TARAFProvider.DeepSave(trans, foy.AV001_TD_BIL_FOY_TARAFCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_TARAF_VEKIL>));
                DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.DeepSave(trans, foy.AV001_TD_BIL_DAVA_NEDENCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK>), typeof(TList<AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW>), typeof(TList<NN_DAVA_NEDEN_POLICE>), typeof(TList<AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL>), typeof(TList<AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC>), typeof(TList<AV001_TDIE_BIL_ASAMA>), typeof(TList<AV001_TD_BIL_DAVA_NEDEN_TARAF>));
                foreach (var neden in foy.AV001_TD_BIL_DAVA_NEDENCollection)
                {
                    DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepSave(trans, neden.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>));
                }

                #endregion Kayýt

                #region Otomatik Kayýt

                if (OtomatikKayit && RelatedIcraFoy != null)
                {
                    #region icradan geldiyse

                    AV001_TDI_BIL_KAYIT_ILISKI iliski =
                                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByILISKI_TUR_IDKAYNAK_KAYIT_ID(
                                        (int)AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.ÝCRA_DOSYASI, RelatedIcraFoy.ID);

                    if (iliski == null)
                    {
                        iliski = MyFoy.AV001_TDI_BIL_KAYIT_ILISKICollection.AddNew();

                        iliski.ILISKI_TUR_ID = (int)AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.ÝCRA_DOSYASI;
                        iliski.KAYIT_TARIHI = DateTime.Today;
                        iliski.KAYNAK_DAVA_FOY_ID = MyFoy.ID;
                        iliski.KAYNAK_HAZIRLIK_ID = null;
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

                    AV001_TDI_BIL_KAYIT_ILISKI_DETAY detay = iliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection.AddNew();

                    detay.HEDEF_ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
                    detay.HEDEF_ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
                    detay.HEDEF_ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
                    detay.HEDEF_DAVA_FOY_ID = MyFoy.ID;
                    detay.HEDEF_DOSYA_TARIHI = MyFoy.DAVA_TARIHI;
                    detay.HEDEF_ESAS_NO = MyFoy.ESAS_NO;
                    detay.HEDEF_FOY_NO = MyFoy.FOY_NO;
                    detay.HEDEF_HAZIRLIK_ID = null;
                    detay.HEDEF_ICRA_FOY_ID = null; //RelatedIcraFoy.ID;
                    detay.HEDEF_KAYIT_ID = MyFoy.ID;
                    detay.HEDEF_RUCU_ID = null;
                    detay.HEDEF_TIP = 2;
                    detay.ILISKI_TUR_ID = (int)AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.DAVA_DOSYASI;
                    detay.ADMIN_KAYIT_MI = 0;
                    detay.KAYIT_TARIHI = DateTime.Today;
                    detay.ILISKI_NEDEN_ID = 1;

                    detay.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    detay.KONTROL_KIM = "AVUKATPRO";
                    detay.KONTROL_NE_ZAMAN = DateTime.Today;
                    detay.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    detay.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    detay.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.DeepSave(trans, iliski, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>));

                    #region <MB-20100627>

                    //Herhangi bir dosya altýna iliþkili dosya kaydý yapýldýðýnda bu dosyayý iliþkilendirildiði dosyanýn baðlý olduðu klasöre iliþkilendirmek için eklendi.
                    AdimAdimDavaKaydi.Forms.frmKayitIliski kayitIliski = new AdimAdimDavaKaydi.Forms.frmKayitIliski();
                    kayitIliski.TransactionKapat = true;
                    kayitIliski.KlasorIliskisiniOlustur(trans, iliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection);

                    #endregion <MB-20100627>

                    try
                    {
                        if (MyFoy.DAVA_TALEP_ID == 8)
                        {
                            ABSqlConnection cn = new ABSqlConnection();
                            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                            cn.AddParams("@DAVA_FOY_ID", MyFoy.ID);
                            cn.AddParams("@ICRA_FOY_ID", RelatedIcraFoy.ID);
                            cn.ExcuteQuery("update dbo.AV001_TI_BIL_BORCLU_TAAHHUT_MASTER set DAVASI_VAR_MI=1, DAVA_FOY_ID=@DAVA_FOY_ID WHERE GECERLI_MI=1 and ICRA_FOY_ID=@ICRA_FOY_ID");
                        }
                    }
                    catch { ;}

                    #endregion icradan geldiyse
                }
                else if (OtomatikKayit && RelatedSorusturma != null)
                {
                    #region soruþturmadan geldiyse

                    AV001_TDI_BIL_KAYIT_ILISKI iliski =
                                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByILISKI_TUR_IDKAYNAK_KAYIT_ID(
                                        (int)AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.HAZIRLIK_DOSYASI, RelatedSorusturma.ID);

                    if (iliski == null)
                    {
                        iliski = MyFoy.AV001_TDI_BIL_KAYIT_ILISKICollection.AddNew();

                        iliski.ILISKI_TUR_ID = (int)AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.HAZIRLIK_DOSYASI;
                        iliski.KAYIT_TARIHI = DateTime.Today;
                        iliski.KAYNAK_DAVA_FOY_ID = null;
                        iliski.KAYNAK_HAZIRLIK_ID = RelatedSorusturma.ID;
                        iliski.KAYNAK_RUCU_ID = null;
                        iliski.KAYNAK_KAYIT_ID = RelatedSorusturma.ID;
                        iliski.KAYNAK_ICRA_FOY_ID = null;
                        iliski.KAYNAK_TIP = 3;
                        iliski.AKTIF_MI = true;
                        iliski.KAYIT_TARIHI = DateTime.Today;
                        iliski.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                        iliski.KONTROL_KIM = "AVUKATPRO";
                        iliski.KONTROL_NE_ZAMAN = DateTime.Today;
                        iliski.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                        iliski.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                        iliski.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                    }

                    AV001_TDI_BIL_KAYIT_ILISKI_DETAY detay = iliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection.AddNew();

                    detay.HEDEF_ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
                    detay.HEDEF_ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
                    detay.HEDEF_ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
                    detay.HEDEF_DAVA_FOY_ID = MyFoy.ID;
                    detay.HEDEF_DOSYA_TARIHI = MyFoy.DAVA_TARIHI;
                    detay.HEDEF_ESAS_NO = MyFoy.ESAS_NO;
                    detay.HEDEF_FOY_NO = MyFoy.FOY_NO;
                    detay.HEDEF_HAZIRLIK_ID = null;
                    detay.HEDEF_ICRA_FOY_ID = null; //RelatedIcraFoy.ID;
                    detay.HEDEF_KAYIT_ID = MyFoy.ID;
                    detay.HEDEF_RUCU_ID = null;
                    detay.HEDEF_TIP = 2;
                    detay.ILISKI_NEDEN_ID = 1;
                    detay.ILISKI_TUR_ID = (int)AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.DAVA_DOSYASI;
                    detay.ADMIN_KAYIT_MI = 0;
                    detay.KAYIT_TARIHI = DateTime.Today;

                    detay.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    detay.KONTROL_KIM = "AVUKATPRO";
                    detay.KONTROL_NE_ZAMAN = DateTime.Today;
                    detay.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    detay.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    detay.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.DeepSave(trans, iliski, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>));

                    #region <MB-20100627>

                    //Herhangi bir dosya altýna iliþkili dosya kaydý yapýldýðýnda bu dosyayý iliþkilendirildiði dosyanýn baðlý olduðu klasöre iliþkilendirmek için eklendi.
                    AdimAdimDavaKaydi.Forms.frmKayitIliski kayitIliski = new AdimAdimDavaKaydi.Forms.frmKayitIliski();
                    kayitIliski.TransactionKapat = true;
                    kayitIliski.KlasorIliskisiniOlustur(trans, iliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection);

                    #endregion <MB-20100627>

                    //try
                    //{
                    //    if (MyFoy.DAVA_TALEP_ID == 8)
                    //    {
                    //        ABSqlConnection cn = new ABSqlConnection();
                    //        cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                    //        cn.AddParams("@DAVA_FOY_ID", MyFoy.ID);
                    //        cn.AddParams("@ICRA_FOY_ID", RelatedIcraFoy.ID);
                    //        cn.ExcuteQuery("update dbo.AV001_TI_BIL_BORCLU_TAAHHUT_MASTER set DAVASI_VAR_MI=1, DAVA_FOY_ID=@DAVA_FOY_ID WHERE GECERLI_MI=1 and ICRA_FOY_ID=@ICRA_FOY_ID");
                    //    }
                    //}
                    //catch { ;}

                    #endregion soruþturmadan geldiyse
                }

                #endregion Otomatik Kayýt

                trans.Commit();

                dosyaKaydedildi = true;

                if (BelgeUtil.Inits._TD_FoyTarafGetir != null)
                    BelgeUtil.Inits._TD_FoyTarafGetir.AddRange(BelgeUtil.Inits.GetDavaFoyTarafViewItem(foy.AV001_TD_BIL_FOY_TARAFCollection));

                if (BelgeUtil.Inits._DavaDosyalar == null)
                    BelgeUtil.Inits._DavaDosyalar = BelgeUtil.Inits.context.VTD_DAVA_DOSYALARs.ToList();
                else
                    BelgeUtil.Inits._DavaDosyalar.Add(BelgeUtil.Inits.GetDavaViewItem(foy));

                if (DavaFoyKaydedildi != null)
                {
                    DavaFoyKaydedildi(this, new DavaFoyKaydedildiEventArgs(foy));
                }

                return true;
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();

                if (ex.Message.Contains("uFOY_NO"))
                {
                    if (!BelgeUtil.Inits.Telekomunukasyonmu)
                        FoyuKaydet(foy);
                    else
                        MessageBox.Show("Kaydedilmek istenen RAF NO sistemde kayýtlý olduðundan \r\nkayýt iþlemi gerçekleþtirilemiyor.\r\nRAF NO deðiþtirip yeniden deneyiniz.", "BÝLGÝ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (ex.Message.Contains("uTEBLIGAT_REFERANS_NO"))
                {
                    foreach (var item in foy.AV001_TDI_BIL_TEBLIGATCollection)
                    {
                        if (item.ID == 0)
                            item.STAMP = 0;
                        item.TEBLIGAT_REFERANS_NO = Forms.LayForm.frmLayTabligatKayit.TebligatReferansNoOlustur();
                        FoyuKaydet(foy);
                    }
                }
                if (!dosyaKaydedildi)
                {
                    BelgeUtil.ErrorHandler.Catch(typeof(frmDavaDosyaKayitForm), ex, true); //False Olucak..
                    return false;
                }
                else
                    return true;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ucDavaNedenleri1.vgDavaNedeni.FocusedRowChanged += vgDavaNedeni_FocusedRowChanged;
        }

        private void AV001_TD_BIL_DAVA_NEDEN_TARAFCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_DAVA_NEDEN addNew = new AV001_TD_BIL_DAVA_NEDEN();
            addNew.KAYIT_TARIHI = DateTime.Now;
            addNew.KONTROL_NE_ZAMAN = DateTime.Today;
            addNew.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            addNew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addNew.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            addNew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            e.NewObject = addNew;
        }

        private void AV001_TD_BIL_DAVA_NEDENCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_DAVA_NEDEN dn = new AV001_TD_BIL_DAVA_NEDEN();
            dn.ColumnChanged += DavaNedenColumnChanged;

            dn.FAIZ_TALEP_TARIHI = MyFoy.DAVA_TARIHI.Value;
            dn.DAVA_EDILEN_TUTAR_DOVIZ_ID = 1;
            dn.DIGER_GIDER_DOVIZ_ID = 1;
            dn.PROTESTO_GIDERI_DOVIZ_ID = 1;
            dn.IHTAR_GIDERI_DOVIZ_ID = 1;
            dn.TUTAR_DOVIZ_ID = 1;
            dn.TAZMINAT_DOVIZ_ID = 1;
            dn.ISLAH_EDILEN_TUTAR_DOVIZ_ID = 1;
            dn.DIGER_GIDER_DOVIZ_ID = 1;
            dn.DOVIZ_ISLEM_TIPI = (byte)AvukatProLib.Extras.DavaDovizIslemTipi.Dava_Tarihinde_TL;
            dn.TAZMINAT_HESAP_TIP = (byte)DavaTazminatHesapTipi.Nispi;
            dn.DO_FAIZ_TIP_ID = 1;
            dn.FAIZ_TIP_ID = 1;
            dn.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection = new TList<AV001_TD_BIL_DAVA_NEDEN_TARAF>();

            dn.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK =
                new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
            dn.AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL =
                new TList<AV001_TI_BIL_GAYRIMENKUL>();

            dn.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC =
                new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>();
            dn.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW =
                new TList<AV001_TDI_BIL_SOZLESME>();

            ucSozlesmeBilgileri1.MyDataSource =
                dn.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW;

            dn.KAYIT_TARIHI = DateTime.Now;
            dn.KONTROL_NE_ZAMAN = DateTime.Now;
            dn.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            dn.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            dn.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            dn.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;

            e.NewObject = dn;
        }

        private void AV001_TD_BIL_FOY_TARAF_VEKILCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_FOY_TARAF_VEKIL vk = new AV001_TD_BIL_FOY_TARAF_VEKIL();
            vk.KAYIT_TARIHI = DateTime.Now;
            vk.KONTROL_NE_ZAMAN = DateTime.Now;
            vk.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            vk.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            vk.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            vk.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            e.NewObject = vk;
        }

        private void AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_IHTIYATI_TEDBIR tdbr = new AV001_TDI_BIL_IHTIYATI_TEDBIR();
            tdbr.ADLI_BIRIM_GOREV_ID = DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.Find("GOREV = 'AHM'")[0].ID;
            tdbr.TALEP_TARIHI = MyFoy.DAVA_TARIHI.Value;
            tdbr.KARAR_TARIHI = tdbr.TALEP_TARIHI;
            tdbr.TEMINAT_TUR_ID = 1;
            tdbr.TEMINAT_TUTARI_DOVIZ_ID = 1;

            //tdbr.TEMINAT_TUTARI = myFoy[0].A * (decimal)0.10; // TODO:Kullanýcý seçenekleri.. Oransal
            tdbr.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF>();
            foreach (AV001_TD_BIL_FOY_TARAF taraf in DavaEdilen)
            {
                AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF trf = tdbr.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection.AddNew();
                trf.ICRA_CARI_TARAF_ID = taraf.CARI_ID;
                trf.ICRA_TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
            }
            tdbr.KAYIT_TARIHI = DateTime.Now;
            tdbr.KONTROL_NE_ZAMAN = DateTime.Now;
            tdbr.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            tdbr.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            tdbr.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            tdbr.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            e.NewObject = tdbr;
        }

        private void AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK_AddingNew(
            object sender, AddingNewEventArgs e)
        {
            //TODO Kiymetli Evrak AddingNew
        }

        private void AV001_TDI_BIL_SOZLESMECollection_From_AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW_AddingNew(object sender,
            AddingNewEventArgs
            e)
        {
            //TODO:SozlesmeAddingNew
            //throw new Exception("The method or operation is not implemented.");
        }

        private void AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL_AddingNew(
            object sender, AddingNewEventArgs e)
        {
            //TODO:GayriMenkulAddingNew
            //throw new Exception("The method or operation is not implemented.");
        }

        private void BindOzelKod()
        {
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rLueOzelKod_1, 1, Modul.Dava);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rLueOzelKod2, 2, Modul.Dava);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rLueOzelKod3, 3, Modul.Dava);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rLueOzelKod4, 4, Modul.Dava);
        }

        private void DavaEden_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_FOY_TARAF addNew = new AV001_TD_BIL_FOY_TARAF();
            addNew.AV001_TD_BIL_FOY_TARAF_VEKILCollection = new TList<AV001_TD_BIL_FOY_TARAF_VEKIL>();
            addNew.AV001_TD_BIL_FOY_TARAF_VEKILCollection.AddingNew += AV001_TD_BIL_FOY_TARAF_VEKILCollection_AddingNew;

            BelgeUtil.Inits.TarafKoduGetir(rLueDavaEdenTK);
            if (String.IsNullOrEmpty(((TList<TDI_KOD_TARAF>)rLueDavaEdenTK.DataSource).Filter))
            {
                addNew.TARAF_KODU = (int)TarafKodu.Muvekkil;
                if (csDavaEden == 0)
                    csDavaEden = CariStatu.Müvekkil;
            }
            BelgeUtil.Inits.DavaTarafSifatGetir(rLueDavaEdenSifat);
            if (MyFoy.DAVA_TIP_ID == (int)DavaTipi.ICRA_CEZA || MyFoy.DAVA_TIP_ID == (int)DavaTipi.CEZA)
                addNew.TARAF_SIFAT_ID = (int)TarafSifat.YAKINAN;
            else
                addNew.TARAF_SIFAT_ID = (int)TarafSifat.DAVACI;
            addNew.KAYIT_TARIHI = DateTime.Now;
            addNew.DAVA_EDEN_MI = true;
            addNew.KONTROL_NE_ZAMAN = DateTime.Now;
            addNew.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            addNew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addNew.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            addNew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            e.NewObject = addNew;
        }

        private void DavaEdilen_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_FOY_TARAF addNew = new AV001_TD_BIL_FOY_TARAF();
            addNew.AV001_TD_BIL_FOY_TARAF_VEKILCollection = new TList<AV001_TD_BIL_FOY_TARAF_VEKIL>();
            addNew.AV001_TD_BIL_FOY_TARAF_VEKILCollection.AddingNew += AV001_TD_BIL_FOY_TARAF_VEKILCollection_AddingNew;

            BelgeUtil.Inits.TarafKoduGetir(rLueDavaEdilenTK);
            BelgeUtil.Inits.DavaTarafSifatGetir(rLueDavaEdilenSifat);
            if (String.IsNullOrEmpty(((TList<TDI_KOD_TARAF>)rLueDavaEdilenTK.DataSource).Filter))
            {
                addNew.TARAF_KODU = (int)TarafKodu.KarsiTaraf;
                if (csDavaEdilen == 0)
                    csDavaEdilen = CariStatu.Karþý_Taraf;
            }
            else
            {
                string[] bol = ((TList<TDI_KOD_TARAF>)rLueDavaEdilenTK.DataSource).Filter.Split(' ');
                if (Convert.ToBoolean(bol[2]))
                {
                    addNew.TARAF_KODU = (int)TarafKodu.KarsiTaraf;
                    csDavaEdilen = CariStatu.Karþý_Taraf;
                }
                else
                {
                    addNew.TARAF_KODU = (int)TarafKodu.Muvekkil;
                    csDavaEdilen = CariStatu.Müvekkil;
                }
            }
            if (MyFoy.DAVA_TIP_ID == (int)DavaTipi.ICRA_CEZA || MyFoy.DAVA_TIP_ID == (int)DavaTipi.CEZA)
                addNew.TARAF_SIFAT_ID = (int)TarafSifat.SANIK;
            else
                addNew.TARAF_SIFAT_ID = (int)TarafSifat.DAVALI;
            addNew.KAYIT_TARIHI = DateTime.Now;
            addNew.DAVA_EDEN_MI = false;
            addNew.KONTROL_NE_ZAMAN = DateTime.Now;
            addNew.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            addNew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addNew.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            addNew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            e.NewObject = addNew;
        }

        private void DavaNedenColumnChanged(object sender, AV001_TD_BIL_DAVA_NEDENEventArgs e)
        {
            AV001_TD_BIL_DAVA_NEDEN gonderen = sender as AV001_TD_BIL_DAVA_NEDEN;
            if (gonderen != null)
                switch (e.Column)
                {
                    case AV001_TD_BIL_DAVA_NEDENColumn.OLAY_SUC_TARIHI:
                        gonderen.FAIZ_TALEP_TARIHI = gonderen.OLAY_SUC_TARIHI;
                        gonderen.FAIZ_KARAR_TARIHI = gonderen.OLAY_SUC_TARIHI;
                        break;

                    case AV001_TD_BIL_DAVA_NEDENColumn.TUTAR:
                        gonderen.DAVA_EDILEN_TUTAR = gonderen.TUTAR;
                        break;

                    case AV001_TD_BIL_DAVA_NEDENColumn.TUTAR_DOVIZ_ID:
                        gonderen.DAVA_EDILEN_TUTAR_DOVIZ_ID = gonderen.TUTAR_DOVIZ_ID;
                        break;

                    case AV001_TD_BIL_DAVA_NEDENColumn.VERGI_DONEMI:
                        break;

                    case AV001_TD_BIL_DAVA_NEDENColumn.DO_FAIZ_TIP_ID:
                        gonderen.FAIZ_TIP_ID = gonderen.DO_FAIZ_TIP_ID;
                        break;

                    case AV001_TD_BIL_DAVA_NEDENColumn.DO_FAIZ_ORANI:
                        gonderen.FAIZ_ORANI = gonderen.DO_FAIZ_ORANI;
                        break;

                    case AV001_TD_BIL_DAVA_NEDENColumn.DAVA_NEDEN_KOD_ID:
                        if (e.Value != null)
                        {
                            List<int> davaNedenIDs = DataRepository.per_TDI_KOD_DAVA_ADIProvider.Get("DAVA_ADI LIKE 'DÝÐER%'", "ID").Select(n => n.ID).ToList();
                            ucDavaNedenleri1.rowDigerDavaNeden.Visible = davaNedenIDs.Contains((int)e.Value);
                        }
                        break;

                    default:
                        break;
                }
            if (e.Column == AV001_TD_BIL_DAVA_NEDENColumn.TAZMINAT_HESAP_TIP)
            {
                DavaTazminatHesapTipi dt = (DavaTazminatHesapTipi)gonderen.TAZMINAT_HESAP_TIP;
                if (e.Value != null)
                    ucDavaNedenleri1.TazminatYapilandir(dt);
            }

            #region Faiz Oranlarý Getir

            if (e.Column == AV001_TD_BIL_DAVA_NEDENColumn.DO_FAIZ_TIP_ID)
            {
                gonderen.DO_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)e.Value, gonderen.ISLAH_EDILEN_TUTAR_DOVIZ_ID, myFoy.HESAPLAMA_TARIHI);
            }
            if (e.Column == AV001_TD_BIL_DAVA_NEDENColumn.FAIZ_TIP_ID)
            {
                gonderen.FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)e.Value, gonderen.ISLAH_EDILEN_TUTAR_DOVIZ_ID, myFoy.HESAPLAMA_TARIHI);
            }

            #endregion Faiz Oranlarý Getir
        }

        private void deInitNeden(AV001_TD_BIL_DAVA_NEDEN dn)
        {
            TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> gua = new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>();

            //gua.AddRange(ucUcakGemiArac1.MyDataSource);
            //gua.AddRange(ugaGemi.MyDataSource);
            gua.AddRange(ugaArac.MyDataSource);
            ugaArac.MyDataSource = null;
            dn.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC = gua;
            dn.AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAKCollection = ucKiymetliEvraklar.MyExtendedDataSource;
        }

        private void foy_ColumnChanged(object sender, AV001_TD_BIL_FOYEventArgs e)
        {
            if (e.Column == AV001_TD_BIL_FOYColumn.DAVA_TIP_ID)
            {
                if (e.Value is int)
                {
                    AdliBirimBolumKod kod = (AdliBirimBolumKod)e.Value;
                    BelgeUtil.Inits.TarafSifatGetirSikayetEden(rLueDavaEdenSifat);
                    BelgeUtil.Inits.TarafSifatGetirSikayetEdilen(rLueDavaEdilenSifat);
                    AvukatPro.Services.Implementations.DevExpressService.DavaNedeniDoldur(ucDavaNedenleri1.rLueDavaNeden, (int)e.Value, false);
                    ucDavaNedenTaraf1.GridSekillendir(kod);
                }
            }
            this.GetPaketForm();
        }

        private void FoyIhtiyatiTedbir()
        {
            if (MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection == null)
                MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>();
            MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.AddingNew += AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_AddingNew;

            frmDavaIcraIhtiyatiTedbir frm = new frmDavaIcraIhtiyatiTedbir();
            frm.MyDataSource = MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;
            frm.Show();
        }

        private void FoyKaydet()
        {
            //Kaydet Click
            if (TumTaraflar.Count < 1 || sorumluAvk.Count < 1)
            {
                XtraMessageBox.Show(
                    "Kaydetme Ýþlemi Yapabilmeniz için taraflarýn ve sorumlu avukatlarýn eklenmiþ olmasý gerekmektedir",
                    "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (myFoy.IsNew && (myFoy.ADLI_BIRIM_ADLIYE_ID.HasValue && myFoy.ADLI_BIRIM_NO_ID.HasValue &&
                      (myFoy.ADLI_BIRIM_GOREV_ID.HasValue && !string.IsNullOrEmpty(myFoy.ESAS_NO))))
                if (
                    DataRepository.AV001_TD_BIL_FOYProvider.Find(
                        string.Format(
                            "ADLI_BIRIM_ADLIYE_ID = {0} AND ADLI_BIRIM_NO_ID = {1} AND ADLI_BIRIM_GOREV_ID = {2} AND ESAS_NO = {3}",
                            myFoy.ADLI_BIRIM_ADLIYE_ID.Value, myFoy.ADLI_BIRIM_NO_ID.Value,
                            myFoy.ADLI_BIRIM_GOREV_ID.Value, myFoy.ESAS_NO)).Count > 0)
                {
                    XtraMessageBox.Show(
                        "Ayný Mahkeme ve Esas Numarasýna sahip dosya bulunmaktadýr. Kayýt iþlemi gerçekleþtirilemez.",
                        "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

            myFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection = sorumluAvk;
            myFoy.AV001_TD_BIL_FOY_TARAFCollection = TumTaraflar;
            try
            {
                myFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.ForEach(delegate(AV001_TDI_BIL_MASRAF_AVANS obj)
                                                                       {
                                                                           obj.CARI_ID =
                                                                               myFoy.
                                                                                   AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection
                                                                                   [0].SORUMLU_AVUKAT_CARI_ID.Value;
                                                                           obj.CARI_HESAP_HEDEF_TIP = 1;

                                                                           //ICRA OLDUÐUNU SANIYORUZ
                                                                       });
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
            foreach (AV001_TD_BIL_DAVA_NEDEN neden in myFoy.AV001_TD_BIL_DAVA_NEDENCollection)
            {
                foreach (AV001_TD_BIL_FOY_TARAF trf in DavaEden)
                {
                    AV001_TD_BIL_DAVA_NEDEN_TARAF anTrf =
                        neden.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection.Find(
                            AV001_TD_BIL_DAVA_NEDEN_TARAFColumn.TARAF_CARI_ID, trf.CARI_ID.Value);
                    if (anTrf != null)
                    {
                        anTrf.TARAF_SIFAT_ID = trf.TARAF_SIFAT_ID;
                        anTrf.TARAF_CARI_ID = trf.CARI_ID.Value;
                    }
                }
            }

            myFoy = AvukatProLib.Hesap.FaizHelper.DavaDegeriniHesapla(myFoy);
            if (FoyValidate(myFoy))
            {
                if (FoyuKaydet(myFoy) && AdimAdimDavaKaydi.Is.Util.IsHelper.IsleriKaydet(myFoy))
                {
                    if (!foyList.Contains(MyFoy))
                        foyList.Add(MyFoy);

                    foyList.Sort("KAYIT_TARIHI DESC");
                    this.c_titemIliskiliDosyalar.Enabled = true;
                    if (DavaFoyKaydedildi == null)
                        XtraMessageBox.Show("Kayýt Baþarýlý" + Environment.NewLine + "Dosya Kaydedildi.", "Kayýt",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #region <cc-20090709>

                    //formclosinge taþýnmýþtýr
                    //DialogResult ds =
                    //    XtraMessageBox.Show("Dosya Kaydedildi." + System.Environment.NewLine + MyFoy.FOY_NO + " " + "numaralý dava dosyasýný takip ekranýnda açmak istiyor musunuz ?", "Kaydet", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    //if (ds == DialogResult.Yes)
                    //{
                    //    frmDavaTakip frm = new frmDavaTakip();

                    //    DialogResult drb = XtraMessageBox.Show("Dava Kayýt Formu Kapatýlacaktýr..", "Onaylýyor musunuz ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    //     if (drb == DialogResult.Yes)
                    //     {
                    //         frm.Show(foyList[0].ID);
                    //         frm.BringToFront();
                    //         this.Close();
                    //     }
                    //     else
                    //     {
                    //         frm.Show(foyList[0].ID);
                    //         frm.BringToFront();
                    //     }

                    //    //this.Dispose(true);
                    //    //frm.WindowState = FormWindowState.Maximized;
                    //    //MessageBox.Show(GC.GetTotalMemory(true).ToString());
                    //}

                    #endregion <cc-20090709>

                    if (OtomatikKayit && RelatedIcraFoy != null)
                    {
                        AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.GelismeIslemleri(RelatedIcraFoy);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Kayýt Esnasýnda Hata Oluþtu." + Environment.NewLine + "Dosya Kaydedilemedi.",
                                        "Kayýt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FoyuAc()
        {
            AdimAdimDavaKaydi.GirisEkran.rFrmDavaGirisEkran frm = new AdimAdimDavaKaydi.GirisEkran.rFrmDavaGirisEkran();
            frm.Show();
        }

        private bool FoyValidate(AV001_TD_BIL_FOY foy)
        {
            if (!myFoy.DAVA_TIP_ID.HasValue)
            {
                DialogResult dr = XtraMessageBox.Show("Dava Tipi Seçmeden Kayýt Yapýlamaz Lütfen Dava Tipi Seçiniz",
                                                      "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    return false;
                }
            }
            if (!foy.DAVA_TALEP_ID.HasValue)
            {
                DialogResult dr = XtraMessageBox.Show(
                    "Dava Konusu Seçmeden Kayýt Yapýlamaz Lütfen Dava Konusu Seçiniz", "Bilgilendirme",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    return false;
                }
            }
            foreach (AV001_TD_BIL_FOY_TARAF var in foy.AV001_TD_BIL_FOY_TARAFCollection)
            {
                if (!var.CARI_ID.HasValue)
                {
                    DialogResult dr = XtraMessageBox.Show("Taraf Seçmeden Kayýt Yapýlamaz Lütfen Taraflarý Seçiniz",
                                                          "Bilgilendirme", MessageBoxButtons.OK,
                                                          MessageBoxIcon.Information);
                    return false;
                }
            }
            foreach (AV001_TD_BIL_FOY_SORUMLU_AVUKAT var in foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection)
            {
                if (!var.SORUMLU_AVUKAT_CARI_ID.HasValue && var.SORUMLU_AVUKAT_CARI_IDSource == null)
                {
                    DialogResult dr = XtraMessageBox.Show("Sorumlu Seçmeden Kayýt Yapýlamaz Lütfen Sorumlu Seçiniz",
                                                          "Bilgilendirme", MessageBoxButtons.OK,
                                                          MessageBoxIcon.Information);
                    return false;
                }
            }
            if (foy.AV001_TD_BIL_DAVA_NEDENCollection.Count == 0)
            {
                MessageBox.Show("Ekranýn altýndaki (+) butonuna basarak \r\n en az bir dava nedeni eklemeniz gerekir.", "ÝPTAL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            foreach (AV001_TD_BIL_DAVA_NEDEN var in foy.AV001_TD_BIL_DAVA_NEDENCollection)
            {
                if (!var.DAVA_NEDEN_KOD_ID.HasValue)
                {
                    DialogResult dr =
                        XtraMessageBox.Show("Dava Neden Seçmeden Kayýt Yapýlamaz Lütfen Dava Neden Seçiniz",
                                            "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            return true;
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BindOzelKod();
        }

        private void frmDavaDosyaKayitForm_Button_Ac_Click(object sender, EventArgs e)
        {
            FoyuAc();
        }

        private void frmDavaDosyaKayitForm_Button_IhtiyatiTedbir_Click(object sender, EventArgs e)
        {
            if (!dosyaKaydedildi)
            {
                XtraMessageBox.Show("Dosyayý kaydetmeden iþlem gerçekleþtirilemez.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            FoyIhtiyatiTedbir();
        }

        private void frmDavaDosyaKayitForm_Button_IliskiliDosyalar_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.frmKayitIliski iliski = new AdimAdimDavaKaydi.Forms.frmKayitIliski();
            iliski.MyDavaFoy = MyFoy;

            //iliski.MdiParent = null;
            iliski.StartPosition = FormStartPosition.WindowsDefaultLocation;
            iliski.Show();
        }

        private void frmDavaDosyaKayitForm_Button_Kaydet_Click(object sender, EventArgs e)
        {
            FoyKaydet();
        }

        private void frmDavaDosyaKayitForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MyGelisme == null || RelatedIcraFoy == null) return;
            AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.IhlalDavaTarihiHesapla(MyGelisme, RelatedIcraFoy);
            AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.MalBeyaniDavasýTarihiHesapla(MyGelisme, RelatedIcraFoy);
            AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.ItirazDavasýTarihiHesapla(MyGelisme, RelatedIcraFoy);
        }

        private void frmDavaDosyaKayitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MyFoy == null) return;
            if (MyFoy.ID > 0)
            {
                DialogResult ds =
                    XtraMessageBox.Show(
                        "Dosya Kaydedildi." + System.Environment.NewLine + MyFoy.FOY_NO + " " +
                        "numaralý dava dosyasýný takip ekranýnda açmak istiyor musunuz ?", "Kaydet",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (ds == DialogResult.Yes)
                {
                    AdimAdimDavaKaydi.DavaTakip.frmDavaTakip frm = new AdimAdimDavaKaydi.DavaTakip.frmDavaTakip();
                    foyList.Add(MyFoy);
                    frm.Show(MyFoy.ID);

                    //frm.BringToFront();
                }
            }
        }

        private void frmDavaDosyaKayitForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            MyFoy = new AV001_TD_BIL_FOY();
            if (!BelgeUtil.Inits.Telekomunukasyonmu)
                MyFoy.FOY_NO = FoyNoGetir();
            MyFoy.SON_HESAP_TARIHI = DateTime.Today;

            #region <MB-20100614>

            //Kayýt sýrasýnda mahkeme ve esas no alanlarýnda mükerrer kayýt kontrolü yapýldýðý için esas nonun otomatik deðer almasý kapatýldý.
            //MyFoy.ESAS_NO = DateTime.Today.Year.ToString() + "/";

            #endregion <MB-20100614>

            ucDavaNedenTaraf1.MyDataSource = MyFoy.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection;

            InitsGetir();

            #region Ozellestirme

            if (ref1_2_3.PropertiesCollection["REFERANS_NO"] != null)
                ref1_2_3.PropertiesCollection["REFERANS_NO"].Caption = AvukatProLib.Kimlikci.Kimlik.DavaReferans.Referans1;
            if (ref1_2_3.PropertiesCollection["REFERANS_NO2"] != null)
                ref1_2_3.PropertiesCollection["REFERANS_NO2"].Caption = AvukatProLib.Kimlikci.Kimlik.DavaReferans.Referans2;
            if (ref1_2_3.PropertiesCollection["REFERANS_NO3"] != null)
                ref1_2_3.PropertiesCollection["REFERANS_NO3"].Caption = AvukatProLib.Kimlikci.Kimlik.DavaReferans.Referans3;
            if (OzelKod_1_2.PropertiesCollection["DAVA_OZEL_KOD1_ID"] != null)
                OzelKod_1_2.PropertiesCollection["DAVA_OZEL_KOD1_ID"].Caption = AvukatProLib.Kimlikci.Kimlik.DavaOzelKod.OzelKod1;
            if (OzelKod_1_2.PropertiesCollection["DAVA_OZEL_KOD2_ID"] != null)
                OzelKod_1_2.PropertiesCollection["DAVA_OZEL_KOD2_ID"].Caption = AvukatProLib.Kimlikci.Kimlik.DavaOzelKod.OzelKod2;
            if (OzelKod_3_4.PropertiesCollection["DAVA_OZEL_KOD3_ID"] != null)
                OzelKod_3_4.PropertiesCollection["DAVA_OZEL_KOD3_ID"].Caption = AvukatProLib.Kimlikci.Kimlik.DavaOzelKod.OzelKod3;
            if (OzelKod_3_4.PropertiesCollection["DAVA_OZEL_KOD4_ID"] != null)
                OzelKod_3_4.PropertiesCollection["DAVA_OZEL_KOD4_ID"].Caption = AvukatProLib.Kimlikci.Kimlik.DavaOzelKod.OzelKod4;

            #endregion Ozellestirme

            if (OtomatikKayit)
            {
                ucDavaNedenleri1.Refresh();
            }

            this.FormClosed += frmDavaDosyaKayitForm_FormClosed;

            //  compRibbonExtender1.MENU.CariDosyaKayitTiklandi += new EventHandler<AdimAdimDavaKaydi.CustomControls.FrmCariDosyaKayitEventArgs>(MENU_CariDosyaKayitTiklandi);

            #region Klasörden Yeni Dava Dosyasý

            if (MyProje != null)
            {
                MyFoy.SEGMENT_ID = MyProje.PROJE_TIP_ID;

                if (MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection.Count == 0)
                {
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TDIE_BIL_PROJE_TARAF>),
                                                                         typeof(TList<AV001_TDIE_BIL_PROJE_SORUMLU>));
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

                        if (ProjeDavaci)
                        {
                            if (trf.CARI_IDSource.MUVEKKIL_MI)
                            {
                                AV001_TD_BIL_FOY_TARAF davaTaraf = DavaEden.AddNew();
                                davaTaraf.CARI_ID = trf.CARI_ID;

                                davaTaraf.TARAF_KODU = (short)TarafKodu.Muvekkil;
                            }
                            else
                            {
                                AV001_TD_BIL_FOY_TARAF davaTaraf = DavaEdilen.AddNew();
                                davaTaraf.CARI_ID = trf.CARI_ID;

                                davaTaraf.TARAF_KODU = (short)TarafKodu.KarsiTaraf;
                            }
                        }
                        else
                        {
                            if (!trf.CARI_IDSource.MUVEKKIL_MI)
                            {
                                AV001_TD_BIL_FOY_TARAF davaTaraf = DavaEden.AddNew();
                                davaTaraf.CARI_ID = trf.CARI_ID;

                                davaTaraf.TARAF_KODU = (short)TarafKodu.KarsiTaraf;
                            }
                            else
                            {
                                AV001_TD_BIL_FOY_TARAF davaTaraf = DavaEdilen.AddNew();
                                davaTaraf.CARI_ID = trf.CARI_ID;

                                davaTaraf.TARAF_KODU = (short)TarafKodu.Muvekkil;
                            }
                        }

                        #endregion <MB-20100525>
                    }
                }
                foreach (AV001_TDIE_BIL_PROJE_SORUMLU sorumlu in MyProje.AV001_TDIE_BIL_PROJE_SORUMLUCollection)
                {
                    AV001_TD_BIL_FOY_SORUMLU_AVUKAT dvSorumlu = SorumluAvk.AddNew();
                    dvSorumlu.SORUMLU_AVUKAT_CARI_IDSource =
                        DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(sorumlu.CARI_ID);
                    if (sorumlu.YETKILI_MI == true)
                        dvSorumlu.YETKILI_MI = true;
                    dvSorumlu.SORUMLU_AVUKAT_CARI_ID = sorumlu.CARI_ID;
                }
            }

            #endregion Klasörden Yeni Dava Dosyasý

            #region Paket kontrolu

            //TODO: Dava Taraf Bilgiliri Geliþme Bilgileri
            //AuthHelper.ApplyAuthorization("AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit", tabDavaNedenleri.Name, 0, "Dava Dosya Kayýt Geliþme Bilgileri");

            #endregion Paket kontrolu
        }

        private void gcDavaEden_DataSourceChanged(object sender, EventArgs e)
        {
            foreach (var item in DavaEden)
            {
                item.AV001_TD_BIL_FOY_TARAF_VEKILCollection.AddRange(
                    DataRepository.AV001_TD_BIL_FOY_TARAF_VEKILProvider.GetByFOY_TARAF_CARI_ID(item.CARI_ID));
            }
        }

        private void gcDavaEdilen_DataSourceChanged(object sender, EventArgs e)
        {
            foreach (var item in DavaEdilen)
            {
                item.AV001_TD_BIL_FOY_TARAF_VEKILCollection.AddRange(
                    DataRepository.AV001_TD_BIL_FOY_TARAF_VEKILProvider.GetByFOY_TARAF_CARI_ID(item.CARI_ID));
            }
        }

        private void gridView2_ShownEditor(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view != null)
                if (view.FocusedColumn.FieldName == "CARI_ID" && view.ActiveEditor is LookUpEdit)
                {
                    DevExpress.XtraEditors.LookUpEdit edit;
                    edit = (LookUpEdit)view.ActiveEditor;
                    TList<AvukatProLib2.Entities.AV001_TDI_BIL_CARI> table =
                        edit.Properties.DataSource as TList<AvukatProLib2.Entities.AV001_TDI_BIL_CARI>;
                    clone = new TList<AvukatProLib2.Entities.AV001_TDI_BIL_CARI>(table);
                    AV001_TD_BIL_FOY_TARAF row = (AV001_TD_BIL_FOY_TARAF)view.GetRow(view.FocusedRowHandle);
                }
        }

        private void gvDavaEden_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            #region <MB-20100614>

            //Taraf koduna göre cari bilgisinin dolmasýný saðlamak için eklendi.
            if (e.Column.Caption != "T.K") return;

            //BelgeUtil.Inits.TarafKodunaGoreCariGetir(rLueDavaEdenCari, Convert.ToByte(e.Value));
            if (Convert.ToInt32(e.Value) == 1)
                AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueDavaEdenCari, CariStatu.Müvekkil);
            else if (Convert.ToInt32(e.Value) == 3)
                AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueDavaEdenCari, CariStatu.Karþý_Taraf);
            else if (Convert.ToInt32(e.Value) == 4)
                AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueDavaEdenCari, CariStatu.Avukat);
            else
                AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueDavaEdenCari, CariStatu.Kurum_Avukatý);

            #endregion <MB-20100614>
        }

        private void gvDavaEden_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.RepositoryItem is DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit && DavaEden != null)
            {
                int TARAF_ID = -1;
                DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue = null;
                if (e.RowHandle < 0)
                    return;

                GridView gv = sender as GridView;
                if (gv != null)
                {
                    TARAF_ID = Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["TARAF_KODU"]));
                }

                if (e.RepositoryItem != null)
                {
                    if (e.RepositoryItem.Name == "rLueCari")
                    {
                        if (TARAF_ID != tmpTaraf.ID)
                        {
                            TarafKodu t = new TarafKodu();

                            t = (TarafKodu)TARAF_ID;

                            rlue = (DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)e.RepositoryItem.Clone();
                            rlue.DataSource = null;
                            BelgeUtil.Inits.CariGetirByTarafKodu(rlue, t);
                            tmpTaraf.ID = TARAF_ID;
                            e.RepositoryItem = rlue;
                        }
                    }
                }
            }
        }

        private void gvDavaEden_MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
            AV001_TD_BIL_FOY_TARAF seciliTaraf = gvDavaEden.GetRow(e.RowHandle) as AV001_TD_BIL_FOY_TARAF;
            if (seciliTaraf != null && seciliTaraf.CARI_ID.HasValue)
            {
                gvDavaEdenTaraf.ViewCaption = String.Format("Taraf Vekil Bilgileri");

                List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariler = rLueDavaEdilenCari.DataSource as List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>;
                if (cariler != null)
                {
                    var seciliCari = cariler.Find(item => item.ID == seciliTaraf.CARI_ID.Value);
                    if (seciliCari != null)
                    {
                        gvDavaEdenTaraf.ViewCaption = String.Format("{0}{1} -  Tarafýn Vekil Bilgileri",
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

        private void gvDavaEden_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            if (this.CariEkleniyor == 1) return;

            AV001_TD_BIL_FOY_TARAF trf = (AV001_TD_BIL_FOY_TARAF)e.Row;

            if (!trf.CARI_ID.HasValue)
            {
                e.ErrorText = "Bir Dava Eden seçilmelidir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (!trf.TARAF_SIFAT_ID.HasValue)
            {
                e.ErrorText = "Bir Taraf Sýfatý seçilmelidir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (trf.TARAF_KODU == 0)
            {
                e.ErrorText = "Bir Taraf Kodu seçilmelidir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (DavaEden.FindAll("CARI_ID", trf.CARI_ID).Count > 1)
            {
                e.ErrorText = "Bu Dava Eden zaten eklenmiþtir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (DavaEdilen.FindAll("CARI_ID", trf.CARI_ID).Count > 0 && trf.TARAF_SIFAT_ID != 102)//KARÞI DAVACI
            {
                e.ErrorText = "Bu þahýs Dava Edilen taraf olarak zaten eklenmiþ." + Environment.NewLine;
                e.Valid = false;
                return;
            }

            TDI_KOD_TARAF trfkod = ((TList<TDI_KOD_TARAF>)rLueDavaEdenTK.DataSource).Find("ID", trf.TARAF_KODU);

            #region <MB-20101901> Dava Eden Vekil Bilgileri

            foreach (var item in DavaEden)
            {
                if (
                    item.AV001_TD_BIL_FOY_TARAF_VEKILCollection.Exists(
                        delegate(AV001_TD_BIL_FOY_TARAF_VEKIL davaVekil) { return davaVekil.FOY_TARAF_CARI_ID == item.CARI_ID; })) continue;

                item.AV001_TD_BIL_FOY_TARAF_VEKILCollection.AddRange(
                    DataRepository.AV001_TD_BIL_FOY_TARAF_VEKILProvider.GetByFOY_TARAF_CARI_ID(item.CARI_ID));
            }

            #endregion <MB-20101901> Dava Eden Vekil Bilgileri

            //((TList<TDI_KOD_TARAF>)rLueDavaEdenTK.DataSource).Filter = "IsSelected = " + trfkod.IsSelected;
            //((TList<TDI_KOD_TARAF>)rLueDavaEdilenTK.DataSource).Filter = "IsSelected = " +
            //                                                              (!trfkod.IsSelected);
        }

        private void gvDavaEdilen_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            #region <MB-20100614>

            //Taraf koduna göre cari bilgisinin dolmasýný saðlamak için eklendi.
            if (e.Column.Caption != "T.K.") return;

            //BelgeUtil.Inits.TarafKodunaGoreCariGetir(rLueDavaEdilenCari, Convert.ToByte(e.Value));
            if (Convert.ToInt32(e.Value) == 1)
                AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueDavaEdilenCari, CariStatu.Müvekkil);
            else if (Convert.ToInt32(e.Value) == 3)
                AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueDavaEdilenCari, CariStatu.Karþý_Taraf);
            else if (Convert.ToInt32(e.Value) == 4)
                AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueDavaEdilenCari, CariStatu.Avukat);
            else
                AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueDavaEdilenCari, CariStatu.Kurum_Avukatý);

            #endregion <MB-20100614>
        }

        private void gvDavaEdilen_MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
            AV001_TD_BIL_FOY_TARAF seciliTaraf = gvDavaEdilen.GetRow(e.RowHandle) as AV001_TD_BIL_FOY_TARAF;
            if (seciliTaraf != null && seciliTaraf.CARI_ID.HasValue)
            {
                gvDavaEdilenTaraf.ViewCaption = String.Format("Taraf Vekil Bilgileri");

                List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariler = rLueDavaEdenCari.DataSource as List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>;
                if (cariler != null)
                {
                    var seciliCari = cariler.Find(item => item.ID == seciliTaraf.CARI_ID.Value);
                    if (seciliCari != null)
                    {
                        gvDavaEdilenTaraf.ViewCaption = String.Format("{0}{1} -  Tarafýn Vekil Bilgileri",
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

        private void gvDavaEdilen_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            if (this.CariEkleniyor == 1) return;

            AV001_TD_BIL_FOY_TARAF trf = (AV001_TD_BIL_FOY_TARAF)e.Row;

            if (!trf.CARI_ID.HasValue)
            {
                e.ErrorText = "Bir Dava Edilen seçilmelidir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (!trf.TARAF_SIFAT_ID.HasValue)
            {
                e.ErrorText = "Bir Taraf Sýfatý seçilmelidir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (trf.TARAF_KODU == 0)
            {
                e.ErrorText = "Bir Taraf Kodu seçilmelidir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (DavaEdilen.Count(item => item.CARI_ID == trf.CARI_ID) > 1)
            {
                e.ErrorText = "Bu Dava Edilen zaten eklenmiþtir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (DavaEden.Count(item => item.CARI_ID == trf.CARI_ID) > 0 && trf.TARAF_SIFAT_ID != 103)//KARÞI DAVALI
            {
                e.ErrorText = "Bu þahýs Dava Eden taraf olarak zaten eklenmiþ." + Environment.NewLine;
                e.Valid = false;
                return;
            }

            #region <MB-20101901> Dava Edilen Vekil Bilgileri

            foreach (var item in DavaEdilen)
            {
                if (
                    item.AV001_TD_BIL_FOY_TARAF_VEKILCollection.Exists(
                        delegate(AV001_TD_BIL_FOY_TARAF_VEKIL davaVekil) { return davaVekil.FOY_TARAF_CARI_ID == item.CARI_ID; })) continue;
                item.AV001_TD_BIL_FOY_TARAF_VEKILCollection.AddRange(
                    DataRepository.AV001_TD_BIL_FOY_TARAF_VEKILProvider.GetByFOY_TARAF_CARI_ID(item.CARI_ID));
            }

            #endregion <MB-20101901> Dava Edilen Vekil Bilgileri

            if (trf.CARI_ID.HasValue)
                ucKiymetliEvraklar.TARAF_ID = trf.CARI_ID.Value;
        }

        private void gvSorumluAvukat_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            AV001_TD_BIL_FOY_SORUMLU_AVUKAT row = (AV001_TD_BIL_FOY_SORUMLU_AVUKAT)e.Row;
            if (!row.SORUMLU_AVUKAT_CARI_ID.HasValue && row.SORUMLU_AVUKAT_CARI_IDSource == null)
            {
                e.ErrorText = "Lütfen bir sorumlu seçiniz." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (SorumluAvk.FindAll("SORUMLU_AVUKAT_CARI_ID", row.SORUMLU_AVUKAT_CARI_ID).Count > 1)
            {
                e.ErrorText = "Bu Sorumlu zaten eklenmiþ." + Environment.NewLine;
                e.Valid = false;
                return;
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.c_titemIliskiliDosyalar.Enabled = false;
            this.Button_IliskiliDosyalar_Click += frmDavaDosyaKayitForm_Button_IliskiliDosyalar_Click;
            this.Button_Ac_Click += frmDavaDosyaKayitForm_Button_Ac_Click;

            this.Button_Yeni_Click += frmIcraDosyaKayit_Button_Yeni_Click;
            this.Button_Kaydet_Click += frmDavaDosyaKayitForm_Button_Kaydet_Click;
            this.Button_IhtiyatiTedbir_Click += frmDavaDosyaKayitForm_Button_IhtiyatiTedbir_Click;
        }
        private void frmIcraDosyaKayit_Button_Yeni_Click(object sender, EventArgs e)
        {
            YeniFoy();
        }

        private void YeniFoy()
        {
            myFoy = new AV001_TD_BIL_FOY();
            myFoy.AVUKATA_INTIKAL_TARIHI = DateTime.Today;
            myFoy.DAVA_TARIHI = DateTime.Today;
            myFoy.FOY_NO = FoyNoGetir();
            setFoy(myFoy);
        }
        private void InitsGetir()
        {
            AvukatPro.Services.Implementations.DevExpressService.FoyDurumDoldur(rLueDosyaDurum);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeDoldur(rLueMahkeme);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeGorevDoldur(rLueGorev);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeNoDoldur(rLueAdliBirimAdliyeNo);
            BelgeUtil.Inits.DavaTipleriResimliGetir(rLueDavaTipResimli);
            BelgeUtil.Inits.DavaTalepGetir(rLueDavaKonusu);

            BindOzelKod();

            rLueOzelKod_1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            rLueOzelKod2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            rLueOzelKod3.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            rLueOzelKod4.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);

            BelgeUtil.Inits.AdliBirimBolumGetirIDKontrollu(perRDavaGenelBilg1.Items[1] as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit);
            BelgeUtil.Inits.TarafKoduGetir(rLueDavaEdenTK);
            BelgeUtil.Inits.TarafKoduGetir(rLueDavaEdilenTK);
            BelgeUtil.Inits.DavaTarafSifatGetir(rLueDavaEdenSifat);
            BelgeUtil.Inits.DavaTarafSifatGetir(rLueDavaEdilenSifat);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueDavaEdenCari, null);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueDavaEdilenCari, null);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueCariAvukat);
            AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(rLueSegment);
            BelgeUtil.Inits.TemsilSekliGetir(rLueTemsilSekil);
            BelgeUtil.Inits.AktifAvukatlariGetir(grLueSorumluAvk);
        }

        private void initNeden(AV001_TD_BIL_DAVA_NEDEN dn)
        {
            //Burada kontrol yapýlmalýdýr mutlaka.
            ucDavaNedenTaraf1.MyDataSource = dn.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection;
            if (dn.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection.Count > 0)
                ucDavaNedenTarafFaiz1.MyDataSource =
                    dn.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection[1].AV001_TD_BIL_DAVA_NEDEN_TARAF_FAIZCollection;

            // dn.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK.AddNew();
            ucKiymetliEvraklar.MyDataSource =
                dn.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK;

            ucGayriMenkul1.MyDataSource = dn.AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL;

            ugaArac.MyDataSource = BelgeUtil.Inits.GemiUcakAracGetirByDavaNedenId(dn.ID);
            ucSozlesmeBilgileri1.MyDataSource =
                dn.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW;

            //ucSozlesmeBilgileri1.MyDataSource = dn.AV001_TD_BIL_DAVA_NEDEN_SOZLESMECollection[0].
        }

        private void lookUpExtender1_OnClickOrProcessNewValue(object sender, LookUpExtenderEventArgs e)
        {
            if (e.SenderLookUp != null && e.SenderLookUp.Properties.Tag != null)
            {
                if ((e.SenderLookUp.Properties.Tag as string) == "OzelKod" && e.IsTypedValue)
                {
                    try
                    {
                        AV001_TDI_KOD_FOY_OZEL ozel = new AV001_TDI_KOD_FOY_OZEL();
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

                int i = 0;
                frmCariGenelGiris frm = new frmCariGenelGiris();
                if ((e.SenderLookUp.Properties.Buttons[1].Tag as string) == "mEkleCariD" && e.IsTypedValue)
                {
                    if (i != 1)
                    {
                        if (e.IsTypedValue)
                            frm.tmpCariAd = e.TypedValue;

                        i = 1;
                        if (csDavaEden != CariStatu.Personel)
                            frm.Statuler.Add(csDavaEden);

                        //frm.MdiParent = null;
                        frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frm.Show();
                        frm.FormClosed += delegate
                                              {
                                                  DialogResult dr = frm.KayitBasarili;
                                                  if (dr == System.Windows.Forms.DialogResult.OK)
                                                  {
                                                      ((TList<AV001_TDI_BIL_CARI>)
                                                       (e.SenderLookUp.Properties.DataSource)).Add(frm.MyCari);
                                                  }
                                              };
                    }
                }
                if ((e.SenderLookUp.Properties.Buttons[1].Tag as string) == "mEkleCari" && e.IsTypedValue)
                {
                    i = 0;
                    if (i != 1)
                    {
                        if (e.IsTypedValue)
                            frm.tmpCariAd = e.TypedValue;

                        i = 1;
                        if (csDavaEdilen != CariStatu.Personel)
                            frm.Statuler.Add(csDavaEdilen);

                        //frm.MdiParent = null;
                        frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frm.Show();
                        DialogResult dr = frm.KayitBasarili;
                        if (dr == System.Windows.Forms.DialogResult.OK)
                        {
                            ((TList<AV001_TDI_BIL_CARI>)(e.SenderLookUp.Properties.DataSource)).Add(frm.MyCari);
                        }
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
            AV001_TD_BIL_FOY_TARAF trf = gvDavaEden.GetRow(gvDavaEden.FocusedRowHandle) as AV001_TD_BIL_FOY_TARAF;

            // .MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show(trf, myFoy);
        }

        private void rbtnTemsilEkleDavaEdilen_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            frmTemsilKayit frm = new frmTemsilKayit();
            AV001_TD_BIL_FOY_TARAF trf = gvDavaEdilen.GetRow(gvDavaEdilen.FocusedRowHandle) as AV001_TD_BIL_FOY_TARAF;

            // frm.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show(trf, myFoy);
        }

        private void rLueDavaEdenCari_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            GridLookUpEdit lue = (GridLookUpEdit)sender;
            frmCariGenelGiris frm = new frmCariGenelGiris();
            if ((e.Button.Tag as string) == "ekle")
            {
                frm.tmpCariAd = lue.Text;
                if (csDavaEden != CariStatu.Personel)
                    frm.Statuler.Add(csDavaEden);
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                this.CariEkleniyor = 1;
                frm.Show();
                frm.FormClosed += delegate
                {
                    DialogResult dr = frm.KayitBasarili;
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueDavaEdenCari, CariStatu.Kurum_Avukatý);
                        this.CariEkleniyor = 0;
                        lue.EditValue = frm.MyCariId;
                        gvDavaEden.SetFocusedValue(frm.MyCariId);
                    }
                };
            }
        }

        private void rLueDavaEdenTK_EditValueChanging(object sender, ChangingEventArgs e)
        {
            csDavaEden = (AvukatProLib.Extras.CariStatu)e.NewValue;
        }

        private void rLueDavaEdilenCari_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            GridLookUpEdit lue = (GridLookUpEdit)sender;
            frmCariGenelGiris frm = new frmCariGenelGiris();
            if ((e.Button.Tag as string) == "ekle")
            {
                frm.tmpCariAd = lue.Text;
                if (csDavaEdilen != CariStatu.Personel)
                    frm.Statuler.Add(csDavaEdilen);
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                this.CariEkleniyor = 1;
                frm.Show();
                frm.FormClosed += delegate
                {
                    DialogResult dr = frm.KayitBasarili;
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        //if ((rLueDavaEdilenCari.Properties.DataSource as List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>).Find(vi => vi.ID == frm.MyCari.ID) != null)
                        //    AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueDavaEdilenCari);
                        //else
                        //    (rLueDavaEdilenCari.DataSource as List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>).Add(BelgeUtil.Inits.GetCariViewItem(frm.MyCari));
                        AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueDavaEdilenCari, CariStatu.Kurum_Avukatý);
                        this.CariEkleniyor = 0;
                        lue.EditValue = frm.MyCariId;
                        gvDavaEdilen.SetFocusedValue(frm.MyCariId);
                    }
                };
            }
        }

        private void rLueDavaEdilenTK_EditValueChanging(object sender, ChangingEventArgs e)
        {
            csDavaEdilen = (AvukatProLib.Extras.CariStatu)e.NewValue;
        }

        private void rLueDavaKonusu_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Tag == "mEkle")
                {
                    if (MyFoy.DAVA_TIP_ID != null)
                    {
                        if (MyFoy.ADLI_BIRIM_GOREV_ID != null)
                        {
                            TDI_KOD_ADLI_BIRIM_GOREV noget = DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.GetByID(MyFoy.ADLI_BIRIM_GOREV_ID.Value);
                            frmAltKategoriEkle frmalt = new frmAltKategoriEkle(frmAltKategoriEkle.Tipler.DavaKonusu, MyFoy.DAVA_TIP_ID.Value);
                            frmalt.ADLI_BIRIM_BOLUM_KOD = noget.ADLI_BIRIM_BOLUM_KOD;
                            frmalt.ShowDialog();

                            ABSqlConnection cn = new ABSqlConnection();
                            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

                            //if (lue.Properties.DataSource == null)
                            //{
                            rLueDavaKonusu.DataSource = cn.GetDataTable("SELECT ID, DAVA_TALEP FROM dbo.per_TD_KOD_DAVA_TALEP(nolock) where ADLI_BIRIM_BOLUM_ID=" + davaTipi.Value);
                            rLueDavaKonusu.DisplayMember = "DAVA_TALEP";
                            rLueDavaKonusu.ValueMember = "ID";
                            rLueDavaKonusu.Columns.Clear();
                            rLueDavaKonusu.Columns.Add(new LookUpColumnInfo("DAVA_TALEP", "Talep", 40));

                            //if (DTalep.DAVA_TALEP != (sender as LookUpEdit).Text || DTalep.DAVA_TALEP != string.Empty)
                            //{
                            //ABSqlConnection cn = new ABSqlConnection();
                            //cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                            //cn.AddParams("@DAVA_TALEP", (sender as LookUpEdit).Text);
                            //cn.AddParams("@ADLI_BIRIM_BOLUM_ID", MyFoy.DAVA_TIP_ID);
                            //if (cn.GetDataTable("SELECT ID FROM dbo.TD_KOD_DAVA_TALEP WHERE ADLI_BIRIM_BOLUM_ID=@ADLI_BIRIM_BOLUM_ID AND DAVA_TALEP=@DAVA_TALEP").Rows.Count == 0)
                            //{
                            //    TDI_KOD_ADLI_BIRIM_GOREV noget = DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.GetByID(MyFoy.ADLI_BIRIM_GOREV_ID.Value);
                            //    DTalep.ADLI_BIRIM_BOLUM_ID = noget.ADLI_BIRIM_BOLUM_ID;
                            //    DTalep.ADLI_BIRIM_BOLUM_KOD = noget.ADLI_BIRIM_BOLUM_KOD;
                            //    DTalep.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                            //    DTalep.KONTROL_NE_ZAMAN = DateTime.Now;
                            //    DTalep.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                            //    DTalep.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                            //    DTalep.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                            //    if (!string.IsNullOrEmpty((sender as LookUpEdit).Text))
                            //    {
                            //        DTalep.DAVA_TALEP = (sender as LookUpEdit).Text;
                            //    }
                            //    TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                            //    trans.BeginTransaction();
                            //    DataRepository.TD_KOD_DAVA_TALEPProvider.DeepSave(trans, DTalep);
                            //    trans.Commit();

                            //    var tempKayit = DataRepository.TD_KOD_DAVA_TALEPProvider.Find(string.Format("DAVA_TALEP = {0}", DTalep.DAVA_TALEP));
                            //    if (tempKayit != null && tempKayit.Count > 0)
                            //        DTalep.ID = tempKayit[0].ID;

                            //    if (BelgeUtil.Inits._DavaTalepGetir == null)
                            //        BelgeUtil.Inits._DavaTalepGetir = DataRepository.per_TD_KOD_DAVA_TALEPProvider.GetAll();
                            //    else
                            //        BelgeUtil.Inits._DavaTalepGetir.Add(BelgeUtil.Inits.GetDavaTalepViewItem(DTalep));

                            //    (rLueDavaKonusu.DataSource as VList<per_TD_KOD_DAVA_TALEP>).Add(BelgeUtil.Inits.GetDavaTalepViewItem(DTalep));

                            //    XtraMessageBox.Show("Dava Konusu eklenmiþtir.", "BÝLGÝ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                            //else
                            //    MessageBox.Show("Dava konusu zaten kayýtlý...");
                            //}
                        }
                        else
                            MessageBox.Show("Mahkemenin Görevini Seçiniz...");
                    }
                    else
                        MessageBox.Show("Dava Tipi Seçiniz...");
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void rLueDavaKonusu_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (MyFoy.ADLI_BIRIM_GOREV_ID != null)
            {
                if (DTalep.DAVA_TALEP != (sender as LookUpEdit).Text)
                {
                    try
                    {
                        if (DTalep.DAVA_TALEP != (sender as LookUpEdit).Text)
                        {
                            //TDI_KOD_ADLI_BIRIM_GOREV noget = DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.GetByID(MyFoy.ADLI_BIRIM_GOREV_ID.Value);
                            //DTalep.ADLI_BIRIM_BOLUM_ID = noget.ADLI_BIRIM_BOLUM_ID;
                            //DTalep.ADLI_BIRIM_BOLUM_KOD = noget.ADLI_BIRIM_BOLUM_KOD;
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

                            //if (BelgeUtil.Inits._DavaTalepGetir == null)
                            //    BelgeUtil.Inits._DavaTalepGetir = DataRepository.per_TD_KOD_DAVA_TALEPProvider.GetAll();
                            //else
                            //    BelgeUtil.Inits._DavaTalepGetir.Add(BelgeUtil.Inits.GetDavaTalepViewItem(DTalep));

                            //(rLueDavaKonusu.DataSource as VList<per_TD_KOD_DAVA_TALEP>).Add(BelgeUtil.Inits.GetDavaTalepViewItem(DTalep));

                            //XtraMessageBox.Show("Dava Konusu eklenmiþtir.", "BÝLGÝ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }

            //else
            //{
            //    XtraMessageBox.Show("Lütfen Önce Görev Seçiniz");
            //}
        }

        private void rLueDavaTipResimli_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                davaTipi = Convert.ToInt32(e.NewValue);

                davaNedenSecenekAyarim =
                    DataRepository.TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYARProvider.GetByDAVA_TIP_ID(davaTipi).
                        FirstOrDefault();
                if (davaNedenSecenekAyarim != null &&
                    davaNedenSecenekAyarim.KULLANICI_ID == AvukatProLib.Kimlik.Bilgi.ID)
                {
                    davaTipiDegisti = true;
                }
                else
                {
                    davaTipiDegisti = true;
                }
            }
        }

        private void setFoy(AV001_TD_BIL_FOY foy)
        {
            foy.ColumnChanged += foy_ColumnChanged;

            //if (DavaEden == null)
            DavaEden = new TList<AV001_TD_BIL_FOY_TARAF>();
            //if (DavaEdilen == null)
            DavaEdilen = new TList<AV001_TD_BIL_FOY_TARAF>();
            //if (SorumluAvk == null)
            SorumluAvk = new TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>();

            if (OtomatikKayit)
            {
                foreach (AV001_TD_BIL_FOY_TARAF taraf in foy.AV001_TD_BIL_FOY_TARAFCollection)
                {
                    if (taraf.DAVA_EDEN_MI)
                    {
                        DavaEden.Add(taraf);
                    }
                    else
                    {
                        DavaEdilen.Add(taraf);
                    }
                }
                foreach (AV001_TD_BIL_FOY_SORUMLU_AVUKAT sorumlu in foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection)
                {
                    if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                    {
                        SorumluAvk.Add(sorumlu);
                        sorumlu.SORUMLU_AVUKAT_CARI_IDSource = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(sorumlu.SORUMLU_AVUKAT_CARI_ID.Value);
                    }
                }
            }
            if (foy.IsNew && !foy.IsSelected)
            {
                foreach (string s in foy.TableColumns)
                {
                    if (s.EndsWith("DOVIZ_ID"))
                        foy[s] = 1;
                }

                #region <TIO - 20092307 > Dava Genel Ayarlar DB den okutuluyor .

                davaGenelAyarlar =
                    DataRepository.TD_BIL_DAVA_KULLANICI_AYARProvider.GetByKULLANICI_ID(AvukatProLib.Kimlik.Bilgi.ID);
                davaNedenSecenekAyarlar =
                    DataRepository.TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYARProvider.GetByKULLANICI_ID(
                        AvukatProLib.Kimlik.Bilgi.ID);

                //davaNedenSecenekAyarlar = DataRepository.TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYARProvider.GetByKULLANICI_ID(AvukatProLib.Kimlik.Bilgi.ID);
                //davaNedenSecenekAyarim = davaNedenSecenekAyarlar[0];

                #endregion <TIO - 20092307 > Dava Genel Ayarlar DB den okutuluyor .

                #region <TIO 20092307>  Eski Yapý Dava Foy Ayar Okutma XML DeSerilize

                if (!DavaDosyasiKayitIceriden && davaGenelAyarlar != null && davaGenelAyarlar.Count != 0)
                {
                    davaGenelAyarim = davaGenelAyarlar[0];

                    //if (MyFoyAyar != null)
                    //{
                    //DAVA AYAR OKU

                    #region THSN  eski yapý deðpiþtirildi yenisi aþaðýda

                    //foy.ADLI_BIRIM_ADLIYE_ID = MyFoyAyar.ADLI_BIRIM_ADLIYE_ID;
                    //foy.ADLI_BIRIM_GOREV_ID = MyFoyAyar.ADLI_BIRIM_GOREV_ID;
                    //foy.ADLI_BIRIM_NO_ID = MyFoyAyar.ADLI_BIRIM_NO_ID;

                    #endregion THSN  eski yapý deðpiþtirildi yenisi aþaðýda

                    foy.ADLI_BIRIM_ADLIYE_ID = davaGenelAyarim.ADLIYE_ID;
                    foy.ADLI_BIRIM_GOREV_ID = davaGenelAyarim.ADLI_BIRIM_GOREV_ID;
                    foy.ADLI_BIRIM_NO_ID = davaGenelAyarim.ADLI_BIRIM_NO_ID;
                    if (davaNedenSecenekAyarim != null)
                        foy.DAVA_TALEP_ID = davaNedenSecenekAyarim.DAVA_KONU_ID;

                    //foy.DAVA_OZEL_KOD1_ID = davaGenelAyarim.OZEL_KOD_1_ID;
                    //foy.DAVA_OZEL_KOD2_ID = davaGenelAyarim.OZEL_KOD_2_ID;
                    //foy.DAVA_OZEL_KOD3_ID = davaGenelAyarim.OZEL_KOD_3_ID;
                    //foy.DAVA_OZEL_KOD4_ID = davaGenelAyarim.OZEL_KOD_4_ID;
                    //foy.FOY_DURUM_ID = davaGenelAyarim.DOSYA_DURUM_ID;
                    //foy.SEGMENT_ID = davaGenelAyarim.BOLUM_SEGMENT_ID;

                    //foreach (AV001_TD_BIL_FOY_OZEL_KOD ozelKod in MyFoyAyar.AV001_TD_BIL_FOY_OZEL_KODCollection)
                    //{
                    AV001_TD_BIL_FOY_OZEL_KOD foyOzelKod = new AV001_TD_BIL_FOY_OZEL_KOD();

                    #region THSN   DEÐÝÞTÝ  yenisi aþaðýda

                    //foyOzelKod.BANKA_ID = ozelKod.BANKA_ID;
                    //foyOzelKod.FOY_BIRIM_ID = ozelKod.FOY_BIRIM_ID;
                    //foyOzelKod.FOY_OZEL_DURUM_ID = ozelKod.FOY_OZEL_DURUM_ID;
                    //foyOzelKod.FOY_YERI_ID = ozelKod.FOY_YERI_ID;
                    //foyOzelKod.KLASOR_1 = ozelKod.KLASOR_1;
                    //foyOzelKod.KLASOR_2 = ozelKod.KLASOR_2;
                    //foyOzelKod.KREDI_GRUP_ID = ozelKod.KREDI_GRUP_ID;
                    //foyOzelKod.KREDI_TIP_ID = ozelKod.KREDI_TIP_ID;
                    //foyOzelKod.SUBE_ID = ozelKod.SUBE_ID;
                    //foyOzelKod.TAHSILAT_DURUM_ID = ozelKod.TAHSILAT_DURUM_ID;

                    #endregion THSN   DEÐÝÞTÝ  yenisi aþaðýda

                    foyOzelKod.BANKA_ID = davaGenelAyarim.BANKA_ID;
                    foyOzelKod.FOY_BIRIM_ID = davaGenelAyarim.FOY_BIRIM_ID;
                    foyOzelKod.FOY_OZEL_DURUM_ID = davaGenelAyarim.OZEL_DURUM_ID;
                    foyOzelKod.FOY_YERI_ID = davaGenelAyarim.DOSYA_YERI_ID;
                    foyOzelKod.KLASOR_1 = davaGenelAyarim.KLASOR_KODU_1;
                    foyOzelKod.KLASOR_2 = davaGenelAyarim.KLASOR_KODU_2;
                    foyOzelKod.KREDI_GRUP_ID = davaGenelAyarim.KREDI_GRUP_ID;
                    foyOzelKod.KREDI_TIP_ID = davaGenelAyarim.KREDI_TIP_ID;
                    foyOzelKod.SUBE_ID = davaGenelAyarim.BANKA_SUBE_ID;
                    foyOzelKod.TAHSILAT_DURUM_ID = davaGenelAyarim.TAHSILAT_DURUM_ID;
                    foy.AV001_TD_BIL_FOY_OZEL_KODCollection.Add(foyOzelKod);

                    // }

                    #region THSN Eski yapý Deðiþti yenisi aþaðýda

                    //foreach (AV001_TD_BIL_FOY_TARAF foyTaraf in MyFoyAyar.AV001_TD_BIL_FOY_TARAFCollection)
                    //{
                    //    AV001_TD_BIL_FOY_TARAF taraf = new AV001_TD_BIL_FOY_TARAF();

                    //    taraf.DAVA_EDEN_MI = foyTaraf.DAVA_EDEN_MI;
                    //    taraf.TARAF_SIFAT_ID = foyTaraf.TARAF_SIFAT_ID;
                    //    taraf.TARAF_KODU = foyTaraf.TARAF_KODU;
                    //    taraf.CARI_ID = foyTaraf.CARI_ID;
                    //    foy.AV001_TD_BIL_FOY_TARAFCollection.Add(taraf);
                    //}

                    #endregion THSN Eski yapý Deðiþti yenisi aþaðýda

                    if (davaGenelAyarim.SECILI_MUVEKKIL_CARI_ID != null)
                    {
                        AV001_TD_BIL_FOY_TARAF taraf = new AV001_TD_BIL_FOY_TARAF();
                        taraf.DAVA_EDEN_MI = true;
                        taraf.TARAF_SIFAT_ID = davaGenelAyarim.SECILI_MUVEKKIL_SIFAT_ID;
                        if (davaGenelAyarim.SECILI_MUVEKKIL_TARAF_KODU.HasValue)
                            taraf.TARAF_KODU = davaGenelAyarim.SECILI_MUVEKKIL_TARAF_KODU.Value;
                        taraf.CARI_ID = davaGenelAyarim.SECILI_MUVEKKIL_CARI_ID;
                        DavaEden.Add(taraf);

                        //foy.AV001_TD_BIL_FOY_TARAFCollection.Add(taraf);
                    }

                    if (davaGenelAyarim.KARSI_TARAF_CARI_ID != null)
                    {
                        AV001_TD_BIL_FOY_TARAF taraf2 = new AV001_TD_BIL_FOY_TARAF();
                        taraf2.DAVA_EDEN_MI = false;
                        taraf2.TARAF_SIFAT_ID = davaGenelAyarim.KARSI_TARAF_SIFAT_ID;
                        if (davaGenelAyarim.KARSI_TARAF_TARAF_KODU.HasValue)
                            taraf2.TARAF_KODU = davaGenelAyarim.KARSI_TARAF_TARAF_KODU.Value;
                        taraf2.CARI_ID = davaGenelAyarim.KARSI_TARAF_CARI_ID;
                        DavaEdilen.Add(taraf2);

                        //foy.AV001_TD_BIL_FOY_TARAFCollection.Add(taraf2);
                    }

                    #region THSN - Eski Yapý Deðiþtirildi Yenisi aþaðýda

                    //foreach (AV001_TD_BIL_FOY_SORUMLU_AVUKAT sorumluAv in MyFoyAyar.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection)
                    //{
                    //AV001_TD_BIL_FOY_SORUMLU_AVUKAT srmAv = new AV001_TD_BIL_FOY_SORUMLU_AVUKAT();
                    //srmAv.SORUMLU_AVUKAT_CARI_ID = sorumluAv.SORUMLU_AVUKAT_CARI_ID;
                    //srmAv.SORUMLU_TIP = sorumluAv.SORUMLU_TIP;
                    //srmAv.YETKILI_MI = sorumluAv.YETKILI_MI;
                    //foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Add(srmAv);
                    //}

                    #endregion THSN - Eski Yapý Deðiþtirildi Yenisi aþaðýda

                    if (davaGenelAyarim.SORUMLU_1_AVUKAT_CARI_ID != null)
                    {
                        AV001_TD_BIL_FOY_SORUMLU_AVUKAT srmAv = new AV001_TD_BIL_FOY_SORUMLU_AVUKAT();
                        srmAv.SORUMLU_AVUKAT_CARI_ID = davaGenelAyarim.SORUMLU_1_AVUKAT_CARI_ID;
                        srmAv.SORUMLU_AVUKAT_CARI_IDSource =
                            DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(
                                davaGenelAyarim.SORUMLU_1_AVUKAT_CARI_ID.Value);

                        srmAv.SORUMLU_TIP = Convert.ToByte(SorumluTip.Sorumlu);
                        srmAv.YETKILI_MI = false;
                        SorumluAvk.Add(srmAv);

                        //foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Add(srmAv);

                        if (davaGenelAyarim.SORUMLU_2_AVUKAT_CARI_ID.HasValue)
                        {
                            AV001_TD_BIL_FOY_SORUMLU_AVUKAT srmAv2 = new AV001_TD_BIL_FOY_SORUMLU_AVUKAT();

                            srmAv2.SORUMLU_AVUKAT_CARI_ID = davaGenelAyarim.SORUMLU_2_AVUKAT_CARI_ID;

                            srmAv2.SORUMLU_AVUKAT_CARI_IDSource =
                                DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(
                                    davaGenelAyarim.SORUMLU_2_AVUKAT_CARI_ID.Value);

                            srmAv2.SORUMLU_TIP = Convert.ToByte(SorumluTip.Avukat);
                            srmAv2.YETKILI_MI = false;
                            SorumluAvk.Add(srmAv2);
                        }
                        //foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Add(srmAv2);
                    }

                    #region --THSN-- DEÐÝÞTÝ  yenisi aþaðýda

                    //foy.FOY_NO = MyFoyAyar.FOY_NO;
                    //foy.DAVA_OZEL_KOD1_ID = MyFoyAyar.DAVA_OZEL_KOD1_ID;
                    //foy.DAVA_OZEL_KOD2_ID = MyFoyAyar.DAVA_OZEL_KOD2_ID;
                    //foy.DAVA_OZEL_KOD3_ID = MyFoyAyar.DAVA_OZEL_KOD3_ID;
                    //foy.DAVA_OZEL_KOD4_ID = MyFoyAyar.DAVA_OZEL_KOD4_ID;
                    //foy.FOY_DURUM_ID = MyFoyAyar.FOY_DURUM_ID;
                    //foy.DAVA_TARIHI = DateTime.Now;

                    #endregion --THSN-- DEÐÝÞTÝ  yenisi aþaðýda

                    foy.FOY_NO = davaGenelAyarim.DOSYA_BASLANGIC_SERI_NO;
                    foy.DAVA_OZEL_KOD1_ID = davaGenelAyarim.OZEL_KOD_1_ID;
                    foy.DAVA_OZEL_KOD2_ID = davaGenelAyarim.OZEL_KOD_2_ID;
                    foy.DAVA_OZEL_KOD3_ID = davaGenelAyarim.OZEL_KOD_3_ID;
                    foy.DAVA_OZEL_KOD4_ID = davaGenelAyarim.OZEL_KOD_4_ID;
                    foy.FOY_DURUM_ID = davaGenelAyarim.DOSYA_DURUM_ID;
                    foy.SEGMENT_ID = davaGenelAyarim.BOLUM_SEGMENT_ID;

                    foy.DAVA_TARIHI = DateTime.Now;

                    //}
                }
                if (!DavaDosyasiKayitIceriden && davaNedenSecenekAyarlar != null && davaNedenSecenekAyarlar.Count != 0)
                {
                    OtomatikKayit = true;

                    if (!davaTipiDegisti)
                        davaNedenSecenekAyarim = davaNedenSecenekAyarlar[0];

                    foy.AV001_TD_BIL_DAVA_NEDENCollection = new TList<AV001_TD_BIL_DAVA_NEDEN>();
                    AV001_TD_BIL_DAVA_NEDEN davaNeden = foy.AV001_TD_BIL_DAVA_NEDENCollection.AddNew();

                    //
                    if (davaNedenSecenekAyarim != null)
                    {
                        foy.DAVA_TIP_ID = davaNedenSecenekAyarim.DAVA_TIP_ID;
                        foy.DAVA_TALEP_ID = davaNedenSecenekAyarim.DAVA_KONU_ID;
                    }

                    foy.AV001_TD_BIL_DAVA_NEDENCollection.AddingNew += AV001_TD_BIL_DAVA_NEDENCollection_AddingNew;

                    if (davaNedenSecenekAyarim != null)
                    {
                        davaNeden.ANA_DAVA_NEDEN_ID = davaNedenSecenekAyarim.DAVA_NEDEN_ID;

                        //davaNeden.DAVA_FOY_ID = foy.ID;
                        davaNeden.DAVA_NEDEN_KOD_ID = davaNedenSecenekAyarim.DAVA_NEDEN_ID;
                        davaNeden.DAVA_NEDEN_TIP_ID = davaNedenSecenekAyarim.DAVA_TIP_ID;
                        davaNeden.OLAY_ADLI_BIRIM_ADLIYE_ID = davaNedenSecenekAyarim.OLAY_YERI_ID;
                        if (davaNedenSecenekAyarim.DO_FAIZ_ORANI.HasValue)
                            davaNeden.DO_FAIZ_ORANI = davaNedenSecenekAyarim.DO_FAIZ_ORANI.Value;
                        davaNeden.DO_FAIZ_TIP_ID = davaNedenSecenekAyarim.DO_FAIZ_TIP_ID;
                        davaNeden.FAIZ_TIP_ID = davaNedenSecenekAyarim.DS_FAIZ_TIP_ID;
                        if (davaNedenSecenekAyarim.DS_FAIZ_ORANI.HasValue)
                            davaNeden.FAIZ_ORANI = (double)davaNedenSecenekAyarim.DS_FAIZ_ORANI;
                    }
                }

                #endregion <TIO 20092307>  Eski Yapý Dava Foy Ayar Okutma XML DeSerilize

                else
                {
                    foy.DAVA_TARIHI = DateTime.Now;
                    foy.FOY_DURUM_ID = 2;
                }
                if (foy.FOY_DURUM_ID == null)
                    foy.FOY_DURUM_ID = 2;
                if (foy.DAVA_TARIHI == null)
                    foy.DAVA_TARIHI = DateTime.Now;

                if (!OtomatikKayit)
                {
                    foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection = new TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>();

                    foy.AV001_TD_BIL_DAVA_NEDENCollection = new TList<AV001_TD_BIL_DAVA_NEDEN>();
                }
            }
            else
            {
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(foy, true, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TD_BIL_FOY_TARAF>),
                                                                 typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>),
                                                                 typeof(TList<AV001_TD_BIL_DAVA_NEDEN>),
                                                                 typeof(TDI_KOD_ADLI_BIRIM_BOLUM),
                                                                 typeof(TDI_KOD_TARAF),
                                                                 typeof(TDIE_KOD_TARAF_SIFAT),
                                                                 typeof(TList<AV001_TDIE_BIL_ASAMA>));

                DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.DeepLoad(foy.AV001_TD_BIL_DAVA_NEDENCollection, true,
                                                                        DeepLoadType.IncludeChildren,
                                                                        typeof(TList<AV001_TD_BIL_DAVA_NEDEN_TARAF>),
                                                                        typeof(TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>),
                                                                        typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>),
                                                                        typeof(TList<AV001_TDI_BIL_SOZLESME>),
                                                                        typeof(
                                                                            TList<AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL>),
                                                                        typeof(
                                                                            TList
                                                                            <AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC>),
                                                                        typeof(
                                                                            TList
                                                                            <AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK>),
                                                                        typeof(TList<AV001_TDIE_BIL_ASAMA>));

                foreach (AV001_TD_BIL_DAVA_NEDEN neden in foy.AV001_TD_BIL_DAVA_NEDENCollection)
                {
                    foreach (AV001_TD_BIL_DAVA_NEDEN_TARAF trf in neden.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection)
                    {
                        DataRepository.AV001_TD_BIL_DAVA_NEDEN_TARAFProvider.DeepLoad(trf, true,
                                                                                      DeepLoadType.IncludeChildren,
                                                                                      typeof(
                                                                                          TList
                                                                                          <
                                                                                          AV001_TD_BIL_DAVA_NEDEN_TARAF_FAIZ
                                                                                          >));
                    }
                }

                foreach (AV001_TD_BIL_FOY_SORUMLU_AVUKAT avukat in foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection)
                {
                    avukat.SORUMLU_AVUKAT_CARI_IDSource = SorumluAvkCari.Find("ID", avukat.SORUMLU_AVUKAT_CARI_ID);
                    avukat.SORUMLU_AVUKAT_CARI_ID = avukat.SORUMLU_AVUKAT_CARI_ID;
                }

                TumTaraflar = foy.AV001_TD_BIL_FOY_TARAFCollection;

                SorumluAvk = foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection;
            }
            foy_ColumnChanged(foy, new AV001_TD_BIL_FOYEventArgs
                                       (AV001_TD_BIL_FOYColumn.DAVA_TIP_ID, foy.DAVA_TIP_ID));
            foy.AV001_TD_BIL_DAVA_NEDENCollection.AddingNew
                += AV001_TD_BIL_DAVA_NEDENCollection_AddingNew;

            foy.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection.AddingNew
                += AV001_TD_BIL_DAVA_NEDEN_TARAFCollection_AddingNew;

            #region <MB-20100514>

            //Ýlk Açýlýþta bir tane kayýt gelmesi için eklendi.

            if (foy.AV001_TD_BIL_FOY_OZEL_KODCollection.Count == 0)
                foy.AV001_TD_BIL_FOY_OZEL_KODCollection.AddNew();

            #endregion <MB-20100514>

            ucOzelKodBankaSubeBilgileri1.MyDavaOzelKod = foy.AV001_TD_BIL_FOY_OZEL_KODCollection;

            //foy.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_DAVA_KIYMETLI_EVRAK.AddNew();
            //foy.AV001_TDI_BIL_POLICECollection_From_NN_DAVA_POLICE.AddNew();
            //foy.AV001_TDI_BIL_SOZLESMECollection_From_NN_DAVA_SOZLESME.AddNew();
            //foy.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_DAVA_GAYRIMENKUL.AddNew();
            //foy.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_DAVA_GEMI_UCAK_ARAC.AddNew();

            //foy.AV001_TD_BIL_DAVA_NEDENCollection.Add(new AV001_TD_BIL_DAVA_NEDEN()); //[YY] iki tane var idi biri gereksiz ve yanlýþ idi artýk deðil
            foreach (var davaNeden in foy.AV001_TD_BIL_DAVA_NEDENCollection)
            {
                davaNeden.ColumnChanged += DavaNedenColumnChanged;
            }
            ucDavaNedenleri1.MyDataSource = foy.AV001_TD_BIL_DAVA_NEDENCollection;

            foreach (AV001_TD_BIL_DAVA_NEDEN var in foy.AV001_TD_BIL_DAVA_NEDENCollection)
            {
                var.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK.AddingNew
                    += AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK_AddingNew;

                // var.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK.AddNew();
                ucKiymetliEvraklar.MyDataSource =
                    var.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK;

                #region <MB-20100524>

                //Seçili Kiymetli Evrak taraflarýnýn gelmesi için eklendi.

                ucKiymetliEvraklar.OnListedenKiymetliEvrakGetirildi +=
                    ucKiymetliEvraklar_OnListedenKiymetliEvrakGetirildi;
                ucKiymetliEvraklar.FocusedRecordChanged += ucKiymetliEvraklar_FocusedRecordChanged;

                #endregion <MB-20100524>

                //if (ucKiymetliEvraklar.MyDataSource != null && ucKiymetliEvraklar.MyDataSource.Count > 0)
                //    ucKiymetliEvrakTaraf.MyDataSource = ucKiymetliEvraklar.MyDataSource[0].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection;

                ucPoliceKayitvGrid1.MyDataSource = var.AV001_TDI_BIL_POLICECollection_From_NN_DAVA_NEDEN_POLICE;

                var.AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL.AddingNew +=
                    AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL_AddingNew;

                //var.AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL.AddNew();
                ucGayriMenkul1.MyDataSource =
                    var.AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL;

                var.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW.AddingNew +=
                    AV001_TDI_BIL_SOZLESMECollection_From_AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW_AddingNew;

                //var.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW.AddNew();
                ucSozlesmeBilgileri1.MyDataSource =
                    var.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW;
                ugaArac.MyDataSource = var.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC;
            }

            gcDavaEden.DataSource = DavaEden;
            gcDavaEdilen.DataSource = DavaEdilen;
            gcSorumluAvukat.DataSource = SorumluAvk;

            DavaEden.AddingNew += DavaEden_AddingNew;

            DavaEdilen.AddingNew += DavaEdilen_AddingNew;

            SorumluAvk.AddingNew += SorumluAvk_AddingNew;

            TList<AV001_TD_BIL_FOY> foyList = new TList<AV001_TD_BIL_FOY>();

            foyList.Add(foy);

            bndFoy.DataSource = foyList;

            vgDavaGenelBilgiler.DataSource = foyList;
        }

        private void SorumluAvk_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_FOY_SORUMLU_AVUKAT addNew = new AV001_TD_BIL_FOY_SORUMLU_AVUKAT();
            addNew.KAYIT_TARIHI = DateTime.Now;
            addNew.KONTROL_NE_ZAMAN = DateTime.Now;
            addNew.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            addNew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addNew.SORUMLU_TIP = 1;
            addNew.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            addNew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            e.NewObject = addNew;
        }

        private void Tabs_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            switch (e.Page.Name)
            {
                case "tabGenel":

                    foreach (Control c in this.pnTemp.Controls)
                    {
                        if (c.Name == "grDavaNedenleri")
                        {
                            pnDavaNedenleri.Controls.Clear();
                            pnDavaNedenleri.Controls.Add(c);
                            c.Dock = DockStyle.Fill;
                        }
                    }

                    break;

                case "tabDavaNedenleri":
                    if (MyFoy.AV001_TD_BIL_DAVA_NEDENCollection.Count == 0)
                    {
                        XtraMessageBox.Show("Lütfen Dava Nedeni Giriniz.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    foreach (Control c in this.pnDavaNedenleri.Controls)
                    {
                        if (c.Name == "grDavaNedenleri")
                        {
                            pnTemp.Controls.Clear();
                            pnTemp.Controls.Add(c);
                            c.Dock = DockStyle.Fill;
                        }
                    }

                    #region Ýliþkili kayýtlar

                    AV001_TD_BIL_DAVA_NEDEN var = MyFoy.AV001_TD_BIL_DAVA_NEDENCollection[0];
                    var.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK.AddingNew
                        += AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK_AddingNew;

                    ucKiymetliEvraklar.MyDataSource =
                        var.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK;

                    //if (ucKiymetliEvraklar.MyDataSource != null && ucKiymetliEvraklar.MyDataSource.Count > 0)
                    //    ucKiymetliEvrakTaraf.MyDataSource = ucKiymetliEvraklar.MyDataSource[0].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection;

                    ucPoliceKayitvGrid1.MyDataSource = var.AV001_TDI_BIL_POLICECollection_From_NN_DAVA_NEDEN_POLICE;

                    var.AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL.AddingNew +=
                        AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL_AddingNew;

                    ucGayriMenkul1.MyDataSource =
                        var.AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL;

                    var.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW.AddingNew +=
                        AV001_TDI_BIL_SOZLESMECollection_From_AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW_AddingNew;

                    ucSozlesmeBilgileri1.MyDataSource =
                        var.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW;

                    //ucUcakGemiArac1.MyDataSource =
                    //var.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC.FindAll(
                    //    "GEMI_UCAK_ARAC_TIP", (byte)2);
                    //ugaGemi.MyDataSource = var.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC.FindAll("GEMI_UCAK_ARAC_TIP", (byte)1);
                    ugaArac.MyDataSource = var.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC;

                    #endregion Ýliþkili kayýtlar

                    break;
            }
        }

        private void ucDavaNedenleri1_ValidateNeden(object sender,
            DevExpress.XtraVerticalGrid.Events.ValidateRecordEventArgs e)
        {
            AV001_TD_BIL_DAVA_NEDEN neden = ucDavaNedenleri1.CurrentNeden;

            //if (!neden.ANA_DAVA_NEDEN_ID.HasValue)
            //{
            //    e.Valid = false;
            //    e.ErrorText="Lütfen bir Dava Nedeni giriniz." + Environment.NewLine;
            //    return;
            //}

            if (neden != null && e.Valid)
            {
                //if ((DavaEdilen.Count > 0 && DavaEdilen.Count != neden.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection.Count) || (neden.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection.Count == 0 && DavaEdilen.Count > 0))
                //{
                neden.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection.Clear();
                foreach (AV001_TD_BIL_FOY_TARAF taraf in TumTaraflar)
                {
                    AV001_TD_BIL_DAVA_NEDEN_TARAF dnTaraf = neden.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection.AddNew();
                    dnTaraf.TARAF_CARI_ID = taraf.CARI_ID.Value;
                    dnTaraf.TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
                    dnTaraf.SORUMLU_OLUNAN_MIKTAR = neden.DAVA_EDILEN_TUTAR;
                    dnTaraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = neden.DAVA_EDILEN_TUTAR_DOVIZ_ID;
                    if (taraf.TARAF_KODU == (int)DavaTarafKodu.Davalý &&
                        MyFoy.DAVA_TARIHI.HasValue && neden.FAIZ_KARAR_TARIHI.HasValue)
                    {
                        AV001_TD_BIL_DAVA_NEDEN_TARAF_FAIZ faiz =
                            dnTaraf.AV001_TD_BIL_DAVA_NEDEN_TARAF_FAIZCollection.AddNew();
                        faiz.FAIZ_BASLANGIC_TARIHI = neden.FAIZ_KARAR_TARIHI.Value;
                        faiz.FAIZ_BITIS_TARIHI = MyFoy.DAVA_TARIHI.Value;
                        faiz.SABIT_FAIZ = neden.SABIT_FAIZ_UYGULA;
                        faiz.FAIZ_TIP_ID = neden.DO_FAIZ_TIP_ID;
                        faiz.FAIZ_ORANI = neden.DO_FAIZ_ORANI;
                        if (neden.DO_FAIZ_TIP_ID == neden.FAIZ_TIP_ID ||
                            (neden.SABIT_FAIZ_UYGULA && neden.FAIZ_ORANI == neden.DO_FAIZ_ORANI))
                        {
                            faiz.FAIZ_BITIS_TARIHI = MyFoy.SON_HESAP_TARIHI;
                        }
                        else
                        {
                            AV001_TD_BIL_DAVA_NEDEN_TARAF_FAIZ faiz2 =
                                dnTaraf.AV001_TD_BIL_DAVA_NEDEN_TARAF_FAIZCollection.AddNew();
                            faiz2.FAIZ_BASLANGIC_TARIHI = MyFoy.DAVA_TARIHI.Value;
                            faiz2.FAIZ_BITIS_TARIHI = MyFoy.SON_HESAP_TARIHI;
                            faiz2.SABIT_FAIZ = neden.SABIT_FAIZ_UYGULA;
                            faiz2.FAIZ_TIP_ID = neden.FAIZ_TIP_ID;
                            faiz2.FAIZ_ORANI = neden.FAIZ_ORANI;
                        }
                    }
                }
                initNeden(neden);

                //}
            }
        }

        private void ucDavaNedenTaraf1_DavaNedenTarafChanged(object sender,
            DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (ucDavaNedenTaraf1.CurrentNedenTaraf != null)
                ucDavaNedenTarafFaiz1.MyDataSource =
                    ucDavaNedenTaraf1.CurrentNedenTaraf.AV001_TD_BIL_DAVA_NEDEN_TARAF_FAIZCollection;
        }

        //Seçili Kiymetli Evrak taraflarýnýn gelmesi için eklendi.
        private void ucKiymetliEvraklar_FocusedRecordChanged(object sender,
            DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (e.NewIndex < 0) return;
            if (ucKiymetliEvraklar.MyDataSource.Count > 0)
            {
                TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF> evrakTaraflari =
                    DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFProvider.GetByKIYMETLI_EVRAK_ID(
                        ucKiymetliEvraklar.MyDataSource[e.NewIndex].ID);
                ucKiymetliEvrakTaraf.MyDataSource = evrakTaraflari;
            }
        }

        private void ucKiymetliEvraklar_OnListedenKiymetliEvrakGetirildi(object sender,
            ListedenKiymetliEvrakGetirEventArgs e)
        {
            ucKiymetliEvrakTaraf.MyDataSource = e.KiymetliEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection;
        }

        /// <summary>
        /// Dava Tipine Göre Dava Konusu Getir.
        /// DavaGenelBilgileri Yapilandir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vgDavaGenelBilgiler_CellValueChanging(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            if (e.Row is DevExpress.XtraVerticalGrid.Rows.MultiEditorRow)
            {
                for (int i = 0; i < e.Row.RowPropertiesCount; i++)
                {
                    string str = ((DevExpress.XtraVerticalGrid.Rows.MultiEditorRow)e.Row.Properties.Row).PropertiesCollection[i].FieldName;

                    if (str == "DAVA_TIP_ID")
                    {
                        try
                        {
                            VList<per_TD_KOD_DAVA_TALEP> obj = DataRepository.per_TD_KOD_DAVA_TALEPProvider.Get(string.Format("ADLI_BIRIM_BOLUM_ID = {0}", ((int)e.Value)), "DAVA_TALEP");

                            ((DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)perRDavaGenelBilg1.Items[2]).DataSource = obj;
                            ((DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)perRDavaGenelBilg1.Items[2]).DisplayMember = "DAVA_TALEP";
                            ((DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)perRDavaGenelBilg1.Items[2]).ValueMember = "ID";
                            ((DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)perRDavaGenelBilg1.Items[2]).NullText = "Seç";
                            ((DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)perRDavaGenelBilg1.Items[2]).Columns.Clear();
                            ((DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)perRDavaGenelBilg1.Items[2]).Columns.Add(new LookUpColumnInfo("DAVA_TALEP", "Talep", 40));

                            ((TList<AV001_TD_BIL_FOY>)vgDavaGenelBilgiler.DataSource)[e.RecordIndex].DAVA_TIP_ID =
                                (int)e.Value;

                            #region DavaGenelBilgileri Yapilandir

                            try
                            {
                                string kd =
                                    AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_BOLUMProvider.GetByID(
                                        (int)e.Value).KOD;

                                ucDavaNedenleri1.Yapilandir(kd, false);
                            }

                            catch (Exception ex)
                            {
                                BelgeUtil.ErrorHandler.Catch(this, ex);
                            }

                            #endregion DavaGenelBilgileri Yapilandir
                            break;
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        private void vgDavaNedeni_FocusedRecordChanged(object sender,
            DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (MyFoy != null && MyFoy.AV001_TD_BIL_DAVA_NEDENCollection.Count > 0)
            {
                if (e.OldIndex > -1 && MyFoy.AV001_TD_BIL_DAVA_NEDENCollection.Count > e.OldIndex)
                    deInitNeden(MyFoy.AV001_TD_BIL_DAVA_NEDENCollection[e.OldIndex]);
                if (e.NewIndex > -1)
                    initNeden(MyFoy.AV001_TD_BIL_DAVA_NEDENCollection[e.NewIndex]);
            }
        }

        private void vgDavaNedeni_FocusedRowChanged(object sender,
            DevExpress.XtraVerticalGrid.Events.FocusedRowChangedEventArgs e)
        {
            try
            {
                AV001_TD_BIL_DAVA_NEDEN var =
                    (ucDavaNedenleri1.vgDavaNedeni.DataSource as TList<AV001_TD_BIL_DAVA_NEDEN>)[
                        ucDavaNedenleri1.vgDavaNedeni.FocusedRecord];

                ucKiymetliEvraklar.MyDataSource =
                    var.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK;

                ucPoliceKayitvGrid1.MyDataSource = var.AV001_TDI_BIL_POLICECollection_From_NN_DAVA_NEDEN_POLICE;
                ucGayriMenkul1.MyDataSource =
                    var.AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL;
                ucSozlesmeBilgileri1.MyDataSource =
                    var.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW;
                ugaArac.MyDataSource = var.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC;
            }
            catch { }
        }

        #endregion Methods

        #region Nested Types

        public class YeniKayitEklendiEventArgs : EventArgs
        {
            #region Properties

            public AV001_TDI_BIL_KAYIT_ILISKI Entity
            {
                get;
                set;
            }

            #endregion Properties
        }

        #endregion Nested Types
    }
}