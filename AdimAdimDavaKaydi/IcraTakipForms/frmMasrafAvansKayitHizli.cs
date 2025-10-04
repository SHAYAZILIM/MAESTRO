using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatPro.Services.Messaging;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using AdimAdimDavaKaydi.Belge.Forms;
using System.Data.SqlClient;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    #region Enumerations

    public enum MasrafFormuAcilisiYeri
    {
        TakipEkrani,
        TakipEkraniDisinda,
        PersonelMuhasebeAvans,
        PersonelMuhasebeMasraf
    }

    #endregion Enumerations

    public partial class frmMasrafAvansKayitHizli : AvpXtraForm
    {
        #region Fields

        public AV001_TDI_BIL_MASRAF_AVANS_DETAY Detay;
        public TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> DetayList; //Klasörden Masraf Avans tablosu üzerinde düzenle dendiği için bir tane detay yok.
        public bool Duzenleme;

        private string _modul;
        private AV001_TDI_BIL_MASRAF_AVANS _MyDataSource;
        private bool lookUpsFill;
        private AV001_TD_BIL_FOY myDavaFoy;
        private AV001_TD_BIL_HAZIRLIK myHazirlikFoy;
        private AV001_TI_BIL_FOY myIcraFoy;
        private AV001_TDIE_BIL_PROJE myProje;
        private AV001_TDI_BIL_SOZLESME mySozlesmeFoy;

        #endregion Fields

        #region Constructors

        public frmMasrafAvansKayitHizli()
        {
            InitializeComponent();
            InitializeEvents();
        }

        #endregion Constructors

        #region Events

        public event EventHandler<EventArgs> Kaydedildi;

        #endregion Events

        #region Properties

        [Browsable(false)]
        public MasrafFormuAcilisiYeri AcilisYeri
        {
            get;
            set;
        }

        public System.Collections.Hashtable AllMuvekkiller
        {
            get;
            set;
        }

        public AV001_TDI_BIL_MASRAF_AVANS_DETAY DefaultDetail
        {
            get;
            set;
        }

        public int DefaultMuvekkil
        {
            get;
            set;
        }

        public int Module
        {
            get;
            set;
        }

        public TList<AV001_TDI_BIL_CARI> Muvekkiller
        {
            get;
            set;
        }

        [Browsable(false)]
        public AV001_TDI_BIL_MASRAF_AVANS MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;

                if (value != null)
                {
                    if (Duzenleme)
                    {
                        bndMasrafAvans.DataSource = value;
                        if (Detay != null)
                        {
                            bndMasrafAvansDetay.DataSource = Detay;
                            Detay.ColumnChanged += masrafDetay_ColumnChanged;
                        }
                        else if (DetayList != null && DetayList.Count > 0)
                        {
                            bndMasrafAvansDetay.DataSource = DetayList;
                            DetayList.ForEach(item =>
                            {
                                item.ColumnChanged += masrafDetay_ColumnChanged;
                            });
                        }
                        BorcluMuvekkilDoldur();
                    }
                }
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyDavaFoy
        {
            get { return myDavaFoy; }
            set
            {
                myDavaFoy = value;
                if (!Duzenleme)
                {
                    bndMasrafAvans.AddNew();
                    bndMasrafAvansDetay.AddNew();

                    if (value != null)
                    {
                        if (value.AV001_TDI_BIL_MASRAF_AVANSCollection.Count == 0 ||
                            value.AV001_TDI_BIL_MASRAF_AVANSCollection == null)
                            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));
                    }
                    MyDataSource = bndMasrafAvans.Current as AV001_TDI_BIL_MASRAF_AVANS;
                }
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_HAZIRLIK MyHazirlikFoy
        {
            get { return myHazirlikFoy; }
            set
            {
                myHazirlikFoy = value;
                if (!Duzenleme)
                {
                    bndMasrafAvans.AddNew();
                    bndMasrafAvansDetay.AddNew();

                    if (value != null)
                    {
                        if (value.AV001_TDI_BIL_MASRAF_AVANSCollection.Count == 0 ||
                            value.AV001_TDI_BIL_MASRAF_AVANSCollection == null)
                            DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(value, false,
                                                                                  DeepLoadType.IncludeChildren,
                                                                                  typeof(
                                                                                      TList<AV001_TDI_BIL_MASRAF_AVANS>));
                    }
                    MyDataSource = bndMasrafAvans.Current as AV001_TDI_BIL_MASRAF_AVANS;
                }
            }
        }

        [Browsable(false)]
        public AV001_TI_BIL_FOY MyIcraFoy
        {
            get { return myIcraFoy; }
            set
            {
                myIcraFoy = value;
                //if (value == null)
                //    return;

                if (!Duzenleme)
                {
                    bndMasrafAvans.AddNew();
                    bndMasrafAvansDetay.AddNew();

                    if (value != null)
                    {
                        if (value.AV001_TDI_BIL_MASRAF_AVANSCollection.Count == 0 ||
                            value.AV001_TDI_BIL_MASRAF_AVANSCollection == null)
                            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));
                    }
                    MyDataSource = bndMasrafAvans.Current as AV001_TDI_BIL_MASRAF_AVANS;
                }
            }
        }

        [Browsable(false)]
        public AV001_TDIE_BIL_PROJE MyProje
        {
            get { return myProje; }
            set
            {
                myProje = value;
                if (!Duzenleme)
                {
                    bndMasrafAvans.AddNew();
                    bndMasrafAvansDetay.AddNew();

                    if (value.AV001_TDI_BIL_MASRAF_AVANSCollection.Count == 0 ||
                        value.AV001_TDI_BIL_MASRAF_AVANSCollection == null)
                        DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));
                    MyDataSource = bndMasrafAvans.Current as AV001_TDI_BIL_MASRAF_AVANS;
                }
            }
        }

        [Browsable(false)]
        public AV001_TDI_BIL_SOZLESME MySozlesmeFoy
        {
            get { return mySozlesmeFoy; }
            set
            {
                mySozlesmeFoy = value;
                if (!Duzenleme)
                {
                    bndMasrafAvans.AddNew();
                    bndMasrafAvansDetay.AddNew();

                    if (value != null)
                    {
                        if (value.AV001_TDI_BIL_MASRAF_AVANSCollection.Count == 0 ||
                            value.AV001_TDI_BIL_MASRAF_AVANSCollection == null)
                            DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));
                    }
                    MyDataSource = bndMasrafAvans.Current as AV001_TDI_BIL_MASRAF_AVANS;
                }
            }
        }

        public int SelectedDosya
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public void BindLookUps()
        {
            AvukatPro.Services.Implementations.DevExpressService.CariPersonelKodGetir(luePersonel);
            AvukatPro.Services.Implementations.DevExpressService.AnaKategoriDoldur(rlueAnaKategori);
            AvukatPro.Services.Implementations.DevExpressService.AnaKategoriDoldur(lueAnaKategori);
            AvukatPro.Services.Implementations.DevExpressService.DovizDoldur(lueBirimFiyatDoviz);
            AvukatPro.Services.Implementations.DevExpressService.DovizDoldur(lueTutarDoviz);
            AvukatPro.Services.Implementations.DevExpressService.DovizDoldur(rlueDovizID);
            BelgeUtil.Inits.MasrafAvansTipGetir(lueMasrafAvansTip.Properties);
            BelgeUtil.Inits.ParaBicimiAyarla(spBirimFiyat);
            BelgeUtil.Inits.ParaBicimiAyarla(spTutar);

            AvukatPro.Services.Implementations.DevExpressService.OdemeTipiGetir(lueOdemeTip);
            AvukatPro.Services.Implementations.DevExpressService.OdemeTipiGetir(rlueOdemeTip);
            AvukatPro.Services.Implementations.DevExpressService.BorcAlacakGetir(rlueBorcAlacak);
            AvukatPro.Services.Implementations.DevExpressService.BorcAlacakGetir(lueBorcAlacak);


            if (lueModul.Properties.DataSource == null)
                AvukatPro.Services.Implementations.DevExpressService.ModulDoldur(lueModul, null);

            if (lueSegment.Properties.DataSource == null)
                AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(lueSegment);

            AvukatPro.Services.Implementations.DevExpressService.KasaHesapBilgileriDoldur(lueKasa);
            AvukatPro.Services.Implementations.DevExpressService.MuhatapHesapBilgilerirDoldur(lueMuhatap);
            //AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(lueBelge);
        }

        public void BorcluMuvekkilDoldur()
        {
            if (MyIcraFoy != null)
            {
                BelgeUtil.Inits.BorcluTarafByFoy(MyIcraFoy, new[] { lueKarsiTaraf.Properties });
                BelgeUtil.Inits.MuvekkilByFoy(MyIcraFoy, new[] { lueMuvekkil.Properties });
            }
            else if (MyDavaFoy != null)
            {
                BelgeUtil.Inits.BorcluTarafByFoy(MyDavaFoy, new[] { lueKarsiTaraf.Properties });
                BelgeUtil.Inits.MuvekkilByFoy(MyDavaFoy, new[] { lueMuvekkil.Properties });
            }
            else if (MyHazirlikFoy != null)
            {
                BelgeUtil.Inits.BorcluTarafByFoy(MyHazirlikFoy, new[] { lueKarsiTaraf.Properties });
                BelgeUtil.Inits.MuvekkilByFoy(MyHazirlikFoy, new[] { lueMuvekkil.Properties });
            }
            else if (MySozlesmeFoy != null)
            {
                BelgeUtil.Inits.BorcluTarafByFoy(MySozlesmeFoy, new[] { lueKarsiTaraf.Properties });
                BelgeUtil.Inits.MuvekkilByFoy(MySozlesmeFoy, new[] { lueMuvekkil.Properties });
            }
            else if (MyProje != null)
            {
                BelgeUtil.Inits.BorcluTarafByFoy(MyProje, new[] { lueKarsiTaraf.Properties });
                BelgeUtil.Inits.MuvekkilByFoy(MyProje, new[] { lueMuvekkil.Properties });
            }
        }

        public void CreateMuvekkils(object TheObject)
        {
            #region ARCH

            TList<AV001_TDI_BIL_CARI> cariler = null;
            if (TheObject is AV001_TD_BIL_FOY)
            {
                AV001_TD_BIL_FOY kaynak = (AV001_TD_BIL_FOY)TheObject;
                List<AvukatProLib.Arama.per_AV001_TD_BIL_FOY_TARAF> _TD_FoyTarafGetir = BelgeUtil.Inits.context.per_AV001_TD_BIL_FOY_TARAFs.ToList();
                List<AvukatProLib.Arama.per_AV001_TD_BIL_FOY_TARAF> _TarafGetirByFoy = _TD_FoyTarafGetir.Where(item => item.DAVA_FOY_ID == kaynak.ID && item.TARAF_KODU == (int)AvukatProLib.Extras.TarafKodu.Muvekkil).ToList();
                cariler = new TList<AV001_TDI_BIL_CARI>();
                foreach (AvukatProLib.Arama.per_AV001_TD_BIL_FOY_TARAF item in _TarafGetirByFoy)
                    cariler.Add(DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(item.CARI_ID.Value));
            }
            else if (TheObject is AV001_TI_BIL_FOY)
            {
                AV001_TI_BIL_FOY kaynak = (AV001_TI_BIL_FOY)TheObject;
                List<AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF> _TD_FoyTarafGetir = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAFs.ToList();
                List<AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF> _TarafGetirByFoy = _TD_FoyTarafGetir.Where(item => item.ICRA_FOY_ID == kaynak.ID && item.TARAF_KODU == (int)AvukatProLib.Extras.TarafKodu.Muvekkil).ToList();
                cariler = new TList<AV001_TDI_BIL_CARI>();
                foreach (AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF item in _TarafGetirByFoy)
                    cariler.Add(DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(item.CARI_ID.Value));
            }

            if (TheObject is AV001_TD_BIL_HAZIRLIK)
            {
                AV001_TD_BIL_HAZIRLIK kaynak = (AV001_TD_BIL_HAZIRLIK)TheObject;
                List<AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_TARAF> _TD_FoyTarafGetir = BelgeUtil.Inits.context.per_AV001_TD_BIL_HAZIRLIK_TARAFs.ToList();
                List<AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_TARAF> _TarafGetirByFoy = _TD_FoyTarafGetir.Where(item => item.HAZIRLIK_ID == kaynak.ID && item.TARAF_KODU == (int)AvukatProLib.Extras.TarafKodu.Muvekkil).ToList();
                cariler = new TList<AV001_TDI_BIL_CARI>();
                foreach (AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_TARAF item in _TarafGetirByFoy)
                    cariler.Add(DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(item.CARI_ID.Value));
            }

            else if (TheObject is AV001_TDI_BIL_SOZLESME)
            {
                AV001_TDI_BIL_SOZLESME kaynak = (AV001_TDI_BIL_SOZLESME)TheObject;
                List<AvukatProLib.Arama.per_AV001_TDI_BIL_SOZLESME_TARAF> _TD_FoyTarafGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_SOZLESME_TARAFs.ToList();
                List<AvukatProLib.Arama.per_AV001_TDI_BIL_SOZLESME_TARAF> _TarafGetirByFoy = _TD_FoyTarafGetir.Where(item => item.SOZLESME_ID == kaynak.ID && item.TARAF_KODU == (int)AvukatProLib.Extras.TarafKodu.Muvekkil).ToList();
                cariler = new TList<AV001_TDI_BIL_CARI>();
                foreach (AvukatProLib.Arama.per_AV001_TDI_BIL_SOZLESME_TARAF item in _TarafGetirByFoy)
                    cariler.Add(DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(item.CARI_ID.Value));
            }

            else if (TheObject == null)
            {
                cariler = new TList<AV001_TDI_BIL_CARI>();
                cariler = DataRepository.AV001_TDI_BIL_CARIProvider.GetAll().FindAll(c => c.MUVEKKIL_MI == true);
            }

            if (_modul == "Genel")
            {
                //foreach (AV001_TDI_BIL_CARI cari in cariler)
                //{
                //    cari.IsSelected = false;
                //}
            }

            else
            {
                if (Duzenleme) foreach (AV001_TDI_BIL_CARI item in cariler)
                        if (item.ID == DefaultMuvekkil) item.IsSelected = true;
                        else item.IsSelected = false;
                else foreach (AV001_TDI_BIL_CARI item in cariler) item.IsSelected = true;
            }

            //DevExpress.XtraGrid.Columns.GridColumn gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            //gridColumn1.Caption = "Seç";
            //gridColumn1.FieldName = "IsSelected";
            //gridColumn1.Name = "colIsSelected";
            //gridColumn1.Visible = true;
            //gridColumn1.VisibleIndex = 0;
            //gridColumn1.Width = 50;

            //DevExpress.XtraGrid.Columns.GridColumn gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            //gridColumn2.Caption = "Kod";
            //gridColumn2.FieldName = "KOD";
            //gridColumn2.Name = "colKOD";
            //gridColumn2.Visible = true;
            //gridColumn2.VisibleIndex = 1;
            //gridColumn2.Width = 60;

            //DevExpress.XtraGrid.Columns.GridColumn gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            //gridColumn3.Caption = "Müşteri No";
            //gridColumn3.FieldName = "MUSTERI_NO";
            //gridColumn3.Name = "colMUSTERI_NO";
            //gridColumn3.Visible = true;
            //gridColumn3.VisibleIndex = 2;
            //gridColumn3.Width = 100;

            //DevExpress.XtraGrid.Columns.GridColumn gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            //gridColumn4.Caption = "Adı";
            //gridColumn4.FieldName = "AD";
            //gridColumn4.Name = "colAD";
            //gridColumn4.Visible = true;
            //gridColumn4.VisibleIndex = 3;
            //gridColumn4.Width = 300;

            //gvMuvekkiller.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gvMuvekkiller_CellValueChanged);
            //gvMuvekkiller.Columns.Add(gridColumn1);
            //gvMuvekkiller.Columns.Add(gridColumn2);
            //gvMuvekkiller.Columns.Add(gridColumn3);
            //gvMuvekkiller.Columns.Add(gridColumn4);
            //gcMuvekkiller.DataSourceChanged += new EventHandler(gcMuvekkiller_DataSourceChanged);
            gcMuvekkiller.DataSource = cariler;
            #endregion ARCH
        }

        public void DavaDetayAlanlari(AV001_TDI_BIL_MASRAF_AVANS masraf, AV001_TDI_BIL_MASRAF_AVANS_DETAY detay)
        {
            masraf.MASRAF_AVANS_TIP = (int)AvukatProLib.Extras.MasrafAvansTip.Masraf;
            detay.BORC_ALACAK_ID = (int)AvukatProLib.Extras.BorcAlacak.Borc;
            detay.HAREKET_ANA_KATEGORI_ID = 1; //MAHKEME MASRAFLARI
            BelgeUtil.Inits.MuhasebeHareketAltKategoriByAnakategoriIdAlti(lueAltKategori.Properties, detay.HAREKET_ANA_KATEGORI_ID);
        }

        public void DavaDosyalari(AV001_TD_BIL_FOY kaynak)
        {
            MyDavaFoy = kaynak;
            AV001_TDI_BIL_MASRAF_AVANS avans = bndMasrafAvans.Current as AV001_TDI_BIL_MASRAF_AVANS;
            DefaultAlanlariDoldur(avans);
        }

        public void DefaultAlanlariDoldur(AV001_TDI_BIL_MASRAF_AVANS masraf)
        {
            AV001_TDI_BIL_MASRAF_AVANS_DETAY detay = bndMasrafAvansDetay.Current as AV001_TDI_BIL_MASRAF_AVANS_DETAY;

            if (masraf == null || detay == null) return;

            ModuleGoreLookUpDoldur(lookUpsFill);

            if (MyIcraFoy != null)
            {
                this.Text = string.Format(@"{0}-{1} Nolu İcra Dosyası", "Masraf Avans (Hızlı)", MyIcraFoy.FOY_NO);
                masraf.ICRA_FOY_ID = MyIcraFoy.ID;
                masraf.CARI_HESAP_HEDEF_TIP = (int)AvukatProLib.Extras.Modul.Icra; // 1 cari

                IcraDetayAlanlari(masraf, detay);
            }
            else if (MyDavaFoy != null)
            {
                this.Text = string.Format(@"{0}-{1} Nolu Dava Dosyası", "Masraf Avans (Hızlı)", MyDavaFoy.FOY_NO);
                masraf.DAVA_FOY_ID = MyDavaFoy.ID;
                masraf.CARI_HESAP_HEDEF_TIP = (int)AvukatProLib.Extras.Modul.Dava;

                DavaDetayAlanlari(masraf, detay);
            }
            else if (MyHazirlikFoy != null)
            {
                this.Text = string.Format(@"{0}-{1} Nolu Dava Dosyası", "Masraf Avans (Hızlı)",
                                          MyHazirlikFoy.HAZIRLIK_NO);
                masraf.HAZIRLIK_ID = MyHazirlikFoy.ID;
                masraf.CARI_HESAP_HEDEF_TIP = (int)AvukatProLib.Extras.Modul.Sorusturma;

                DavaDetayAlanlari(masraf, detay);
            }
            else if (MySozlesmeFoy != null)
            {
                this.Text = string.Format(@"{0}-{1} Nolu Sözleşme Dosyası", "Masraf Avans (Hızlı)",
                                          MySozlesmeFoy.SOZLESME_NO);
                masraf.SOZLESME_ID = MySozlesmeFoy.ID;
                masraf.CARI_HESAP_HEDEF_TIP = (int)AvukatProLib.Extras.Modul.Sozlesme;
            }
            else if (MyProje != null)
            {
                this.Text = string.Format(@"{0}-{1} Nolu Servis Dosyası", "Masraf Avans (Hızlı)", MyProje.KOD);
                masraf.PROJE_ID = MyProje.ID;
                masraf.CARI_HESAP_HEDEF_TIP = (int)AvukatProLib.Extras.Modul.Icra;
            }

            masraf.KAYIT_TARIHI = DateTime.Now;
            masraf.REFERANS_NO = string.Format(@"{0}\{1}\{2}", DateTime.Today.Year, DateTime.Today.Month,
                                               Guid.NewGuid().ToString().Split('-')[0].ToUpper());

            if (AcilisYeri != null)
            {
                if (AcilisYeri == MasrafFormuAcilisiYeri.PersonelMuhasebeAvans)
                {
                    masraf.MASRAF_AVANS_TIP = (int)AvukatProLib.Extras.MasrafAvansTip.Avans;
                    detay.HAREKET_ANA_KATEGORI_ID = 10; //AVANS HESABI
                    BelgeUtil.Inits.MuhasebeHareketAltKategoriByAnakategoriIdAlti(lueAltKategori.Properties,
                                                                                  detay.HAREKET_ANA_KATEGORI_ID);
                }
                else if (AcilisYeri == MasrafFormuAcilisiYeri.PersonelMuhasebeMasraf)
                    masraf.MASRAF_AVANS_TIP = (int)AvukatProLib.Extras.MasrafAvansTip.Masraf;
                else
                    masraf.MASRAF_AVANS_TIP = 1;
            }
            else
                masraf.MASRAF_AVANS_TIP = 1;

            masraf.CARI_ID = AvukatProLib.Kimlik.CurrentCariId;
            masraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            masraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            masraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            masraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            masraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            masraf.MANUEL_KAYIT_MI = true;
        }

        public void IcraDetayAlanlari(AV001_TDI_BIL_MASRAF_AVANS masraf, AV001_TDI_BIL_MASRAF_AVANS_DETAY detay)
        {
            masraf.MASRAF_AVANS_TIP = (int)AvukatProLib.Extras.MasrafAvansTip.Masraf;
            detay.BORC_ALACAK_ID = (int)AvukatProLib.Extras.BorcAlacak.Borc;
            detay.HAREKET_ANA_KATEGORI_ID = 16; //ICRA TAKİP MASRAFLARI
            AvukatPro.Services.Implementations.DevExpressService.AltKategoriDoldur(lueAltKategori, detay.HAREKET_ANA_KATEGORI_ID);
        }

        public void IcraDosyalari(AV001_TI_BIL_FOY kaynak)
        {
            MyIcraFoy = kaynak;
            AV001_TDI_BIL_MASRAF_AVANS avans = bndMasrafAvans.Current as AV001_TDI_BIL_MASRAF_AVANS;
            DefaultAlanlariDoldur(avans);
        }

        public void lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            int secilenModul = -1;

            if (lueModul.EditValue != null)
                secilenModul = (int)lueModul.EditValue;

            if (MyIcraFoy != null)
            {
                MyIcraFoy = null;
                lueModul.EditValue = secilenModul;
            }
            if (MyDavaFoy != null)
            {
                MyDavaFoy = null;
                lueModul.EditValue = secilenModul;
            }
            if (MyHazirlikFoy != null)
            {
                MyHazirlikFoy = null;
                lueModul.EditValue = secilenModul;
            }
            if (MySozlesmeFoy != null)
            {
                MySozlesmeFoy = null;
                lueModul.EditValue = secilenModul;
            }

            switch (lueModul.Text)
            {
                case "Icra":
                    MyIcraFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)lueDosya.EditValue);
                    BelgeUtil.Inits.BorcluTarafByFoy(MyIcraFoy, new[] { lueKarsiTaraf.Properties });
                    BelgeUtil.Inits.MuvekkilByFoy(MyIcraFoy, new[] { lueMuvekkil.Properties });
                    CreateMuvekkils(MyIcraFoy);
                    IcraDosyalari(MyIcraFoy);
                    break;

                case "Dava":
                    MyDavaFoy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)lueDosya.EditValue);
                    BelgeUtil.Inits.BorcluTarafByFoy(MyDavaFoy, new[] { lueKarsiTaraf.Properties });
                    BelgeUtil.Inits.MuvekkilByFoy(MyDavaFoy, new[] { lueMuvekkil.Properties });
                    CreateMuvekkils(MyDavaFoy);
                    DavaDosyalari(MyDavaFoy);
                    break;

                case "Soruşturma":
                    MyHazirlikFoy = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID((int)lueDosya.EditValue);
                    BelgeUtil.Inits.BorcluTarafByFoy(MyHazirlikFoy, new[] { lueKarsiTaraf.Properties });
                    BelgeUtil.Inits.MuvekkilByFoy(MyHazirlikFoy, new[] { lueMuvekkil.Properties });
                    CreateMuvekkils(MyHazirlikFoy);
                    SorusturmaDosyalari(MyHazirlikFoy);
                    break;

                case "Sözleşme":
                    MySozlesmeFoy = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID((int)lueDosya.EditValue);
                    BelgeUtil.Inits.BorcluTarafByFoy(MySozlesmeFoy, new[] { lueKarsiTaraf.Properties });
                    BelgeUtil.Inits.MuvekkilByFoy(MySozlesmeFoy, new[] { lueMuvekkil.Properties });
                    CreateMuvekkils(MySozlesmeFoy);
                    SozlesmeDosyalari(MySozlesmeFoy);
                    break;
                default:
                    break;
            }
            lueModul.ClosePopup();


            for (int i = 0; i < lueAltKategori.Properties.Buttons.Count; i++)
            {
                if (lueAltKategori.Properties.Buttons[i].Tag.ToString() == "0" || lueAltKategori.Properties.Buttons[i].Tag.ToString() == "1")
                {

                }
                else
                {
                    lueAltKategori.Properties.Buttons.RemoveAt(i);
                    i = 0;
                }
            }


        }

        public void lueModul_EditValueChanged(object sender, EventArgs e)
        {
            _modul = lueModul.Text;
            lueDosya.Enabled = true;
            if (lueModul.Text == "Icra")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Icra, false);

            else if (lueModul.Text == "Dava")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Dava, false);

            else if (lueModul.Text == "Soruşturma")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sorusturma, false);

            else if (lueModul.Text == "Sözleşme")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sozlesme, false);

            else if (lueModul.Text == "Genel")
            {
                lueDosya.Enabled = false;
                if (!Duzenleme)
                {
                    //lueModul.EditValueChanged -= lueModul_EditValueChanged;
                    bndMasrafAvans.AddNew();
                    bndMasrafAvansDetay.AddNew();
                    MyDataSource = bndMasrafAvans.Current as AV001_TDI_BIL_MASRAF_AVANS;
                    //lueModul.EditValueChanged += lueModul_EditValueChanged;
                    //lueModul.Text = _modul;
                }
                AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueKarsiTaraf);
                AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueMuvekkil);

                luePersonel.EditValue = AvukatProLib.Kimlikci.Kimlik.Cari_ID;

                AV001_TDI_BIL_MASRAF_AVANS masraf = bndMasrafAvans.Current as AV001_TDI_BIL_MASRAF_AVANS;
                DefaultAlanlariDoldur(masraf);
                (bndMasrafAvans.Current as AV001_TDI_BIL_MASRAF_AVANS).CARI_HESAP_HEDEF_TIP = 7;
            }

            for (int i = 0; i < lueAltKategori.Properties.Buttons.Count; i++)
            {
                if (lueAltKategori.Properties.Buttons[i].Tag.ToString() == "0" || lueAltKategori.Properties.Buttons[i].Tag.ToString() == "1")
                {

                }
                else
                {
                    lueAltKategori.Properties.Buttons.RemoveAt(i);
                    i = 0;
                }
            }
        }

        public void ModuleGoreLookUpDoldur(bool durum)
        {
            if (!durum)
            {
                AvukatPro.Services.Implementations.DevExpressService.AnaKategoriDoldur(lueAnaKategori);
                BelgeUtil.Inits.MasrafAvansTipGetir(lueMasrafAvansTip.Properties);
                BelgeUtil.Inits.BorcAlacakGetir(lueBorcAlacak.Properties);
            }
        }

        public void Show(AV001_TI_BIL_FOY kaynak)
        {
            if (kaynak != null)
                IcraDosyalari(kaynak);

            BelgeUtil.Inits.BorcluTarafByFoy(kaynak, new[] { lueKarsiTaraf.Properties });

            #region ARCH

            CreateMuvekkils(kaynak);

            #endregion ARCH

            BelgeUtil.Inits.MuvekkilByFoy(kaynak, new[] { lueMuvekkil.Properties });

            BindLookUps();
            lookUpsFill = true;

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.Show();
        }

        public void Show(AV001_TD_BIL_FOY kaynak)
        {
            if (kaynak != null)
                DavaDosyalari(kaynak);

            BelgeUtil.Inits.BorcluTarafByFoy(kaynak, new[] { lueKarsiTaraf.Properties });

            #region ARCH

            CreateMuvekkils(kaynak);

            #endregion ARCH

            BelgeUtil.Inits.MuvekkilByFoy(kaynak, new[] { lueMuvekkil.Properties });
            BindLookUps();
            lookUpsFill = true;

            // this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.Show();
        }

        public void Show(AV001_TD_BIL_HAZIRLIK kaynak)
        {
            if (kaynak != null)
                SorusturmaDosyalari(kaynak);

            BelgeUtil.Inits.BorcluTarafByFoy(kaynak, new[] { lueKarsiTaraf.Properties });
            BelgeUtil.Inits.MuvekkilByFoy(kaynak, new[] { lueMuvekkil.Properties });

            BindLookUps();
            lookUpsFill = true;

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.Show();
        }

        public void Show(AV001_TDI_BIL_SOZLESME kaynak)
        {
            if (kaynak != null)
                SozlesmeDosyalari(kaynak);

            BelgeUtil.Inits.BorcluTarafByFoy(kaynak, new[] { lueKarsiTaraf.Properties });
            BelgeUtil.Inits.MuvekkilByFoy(kaynak, new[] { lueMuvekkil.Properties });

            BindLookUps();
            lookUpsFill = true;

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.Show();
        }

        public void ShowDialog(AV001_TDIE_BIL_PROJE kaynak)
        {
            MyProje = kaynak;
            AV001_TDI_BIL_MASRAF_AVANS avans = bndMasrafAvans.Current as AV001_TDI_BIL_MASRAF_AVANS;
            DefaultAlanlariDoldur(avans);

            AV001_TDIE_BIL_PROJE_MASRAF_AVANS mAvansProje = avans.AV001_TDIE_BIL_PROJE_MASRAF_AVANSCollection.AddNew();
            mAvansProje.PROJE_ID = MyProje.ID;

            //MyDataSource = avans;

            BelgeUtil.Inits.BorcluTarafByFoy(kaynak, lueKarsiTaraf.Properties);
            BelgeUtil.Inits.MuvekkilByFoy(kaynak, lueMuvekkil.Properties);
            BindLookUps();
            lookUpsFill = true;

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.Show();
        }

        public void SorusturmaDosyalari(AV001_TD_BIL_HAZIRLIK kaynak)
        {
            MyHazirlikFoy = kaynak;
            AV001_TDI_BIL_MASRAF_AVANS avans = bndMasrafAvans.Current as AV001_TDI_BIL_MASRAF_AVANS;
            DefaultAlanlariDoldur(avans);
        }

        public void SozlesmeDosyalari(AV001_TDI_BIL_SOZLESME kaynak)
        {
            MySozlesmeFoy = kaynak;
            AV001_TDI_BIL_MASRAF_AVANS avans = bndMasrafAvans.Current as AV001_TDI_BIL_MASRAF_AVANS;
            DefaultAlanlariDoldur(avans);
        }

        private void bndMasrafAvans_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_MASRAF_AVANS masraf = new AV001_TDI_BIL_MASRAF_AVANS();
            masraf.KAYIT_TARIHI = DateTime.Now;
            masraf.KONTROL_NE_ZAMAN = DateTime.Now;
            masraf.KONTROL_KIM = "AVUKATPRO";
            masraf.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            masraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            masraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            masraf.KLASOR_KODU = "GENEL";

            if (lueModul.Properties.DataSource == null)
                BelgeUtil.Inits.ModulKodGetir(lueModul);

            if (MyIcraFoy != null)
            {
                int icraID = MyIcraFoy.ID;
                lueSegment.SelectedText = "İcra";
                masraf.CARI_HESAP_HEDEF_TIP = 1;
                lueModul.EditValue = 1;
                masraf.ICRA_FOY_ID = MyIcraFoy.ID;
                //lueDosya.EditValue = MyIcraFoy.ID;
                //MyIcraFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(icraID);
                if (BelgeUtil.Inits._FoyTarafGetir == null)
                    BelgeUtil.Inits._FoyTarafGetir = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAFs.ToList();
                var taraf = BelgeUtil.Inits._FoyTarafGetir.Find(vi => vi.ICRA_FOY_ID == MyIcraFoy.ID && vi.TARAF_SIFAT_ID == 2);
                if (taraf != null)
                    masraf.BORCLU_CARI_ID = taraf.CARI_ID;

                //groupControl3.Visible = false;
                //groupControl4.Top = 3;
                //xtraTabControl1.Top = 172;

                //if (Duzenleme)
                //{
                    groupControl3.Visible = false;
                    groupControl4.Top = 3;
                    xtraTabControl1.Top = 172;
                    //AV001_TDI_BIL_MASRAF_AVANS masraf = bndMasrafAvans.Current as AV001_TDI_BIL_MASRAF_AVANS;
                    luePersonel.EditValue = masraf.CARI_ID;
                //}
                //else
                //{
                //    groupControl3.Visible = true;
                //    luePersonel.EditValue = AvukatProLib.Kimlikci.Kimlik.Cari_ID;
                //}
            }
            else if (MyDavaFoy != null)
            {
                masraf.CARI_HESAP_HEDEF_TIP = 2;
                lueModul.EditValue = 2;
            }
            else if (MyHazirlikFoy != null)
            {
                masraf.CARI_HESAP_HEDEF_TIP = 3;
                lueModul.EditValue = 3;
            }
            else if (MySozlesmeFoy != null)
            {
                masraf.CARI_HESAP_HEDEF_TIP = 5;
                lueModul.EditValue = 5;
            }
            else
            {
                masraf.CARI_HESAP_HEDEF_TIP = 7;
                lueModul.EditValue = 7;
            }

            e.NewObject = masraf;
        }

        private void bndMasrafAvansDetay_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_MASRAF_AVANS_DETAY detay = new AV001_TDI_BIL_MASRAF_AVANS_DETAY();

            detay.KAYIT_TARIHI = DateTime.Now;
            detay.KONTROL_NE_ZAMAN = DateTime.Now;
            detay.KONTROL_KIM = "AVUKATPRO";
            detay.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            detay.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            detay.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            detay.KLASOR_KODU = "GENEL";
            detay.ODEME_TIP_ID = (int)AvukatProLib.Extras.OdemeTip.NAKİT;
            detay.ONAY_DURUM = 0;

            AV001_TDI_BIL_MASRAF_AVANS masraf = bndMasrafAvans.Current as AV001_TDI_BIL_MASRAF_AVANS;
            if (masraf == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Modül ve Dosya Seçmelisiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (masraf.MASRAF_AVANS_TIP != (int)AvukatProLib.Extras.MasrafAvansTip.Avans)
            {
                if (MyIcraFoy != null)
                    IcraDetayAlanlari(masraf, detay);
                else if (MyDavaFoy != null || MyHazirlikFoy != null)
                    DavaDetayAlanlari(masraf, detay);
            }
            else
            {
                detay.HAREKET_ANA_KATEGORI_ID = 10;
                BelgeUtil.Inits.MuhasebeHareketAltKategoriByAnakategoriIdAlti(lueAltKategori.Properties, detay.HAREKET_ANA_KATEGORI_ID);
            }

            if (MyIcraFoy != null)
            {
                detay.SEGMENT_ID = MyIcraFoy.SEGMENT_ID;

                if (BelgeUtil.Inits._FoyTarafGetir == null)
                    BelgeUtil.Inits._FoyTarafGetir = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAFs.ToList();
                var taraf = BelgeUtil.Inits._FoyTarafGetir.Find(vi => vi.ICRA_FOY_ID == MyIcraFoy.ID && vi.TARAF_SIFAT_ID == 1);
                if (taraf != null)
                    detay.MUVEKKIL_CARI_ID = taraf.CARI_ID;
            }

            if (MyDavaFoy != null)
            { detay.SEGMENT_ID = MyDavaFoy.SEGMENT_ID; }
            if (MyHazirlikFoy != null)
            { detay.SEGMENT_ID = MyHazirlikFoy.SEGMENT_ID; }
            if (MySozlesmeFoy != null)
            { detay.SEGMENT_ID = MySozlesmeFoy.SEGMENT_ID; }

            e.NewObject = masraf;
            detay.ColumnChanged += masrafDetay_ColumnChanged;

            e.NewObject = detay;

            if (gcMuvekkiller.DataSource == null)
                if (MyDavaFoy != null)
                    CreateMuvekkils(MyDavaFoy);
                else if (MyIcraFoy != null)
                    CreateMuvekkils(MyIcraFoy);
                else if (MySozlesmeFoy != null)
                    CreateMuvekkils(MySozlesmeFoy);
                else if (MyHazirlikFoy != null)
                    CreateMuvekkils(MyHazirlikFoy);
                else
                {
                    object obj = null;
                    CreateMuvekkils(obj);
                }

            if (_modul == "Genel")
            {
            }
            else
            {
                if (DefaultMuvekkil > 0)
                    foreach (var item2 in gcMuvekkiller.DataSource as TList<AV001_TDI_BIL_CARI>)
                        if (item2.ID == DefaultMuvekkil)
                            item2.IsSelected = true;
                        else item2.IsSelected = false;

                if (DefaultMuvekkil < 1)
                    foreach (var item2 in gcMuvekkiller.DataSource as TList<AV001_TDI_BIL_CARI>)
                        item2.IsSelected = true;               
            }

            if (AllMuvekkiller == null)
                AllMuvekkiller = new System.Collections.Hashtable();
            TList<AV001_TDI_BIL_CARI> liste = new TList<AV001_TDI_BIL_CARI>();
            if ((int)lueModul.EditValue != 7)
            {
                foreach (var item in gcMuvekkiller.DataSource as TList<AV001_TDI_BIL_CARI>)
                    if (item.IsSelected)
                        liste.Add(item); 
            }

            if (!AllMuvekkiller.ContainsKey(detay.KAYIT_TARIHI))
                AllMuvekkiller.Add(detay.KAYIT_TARIHI, liste);
            else AllMuvekkiller[detay.KAYIT_TARIHI] = liste;

            if (Muvekkiller == null)
                Muvekkiller = new TList<AV001_TDI_BIL_CARI>();
            else Muvekkiller.Clear();
            foreach (var item in liste)
                Muvekkiller.Add(item);

            pceMuvekkiller.Text = string.Empty;
            foreach (var item in Muvekkiller)
                pceMuvekkiller.Text += item.AD + ", ";
            if (pceMuvekkiller.Text.Length > 1)
                pceMuvekkiller.Text = pceMuvekkiller.Text.Substring(0, pceMuvekkiller.Text.Length - 2);
            else pceMuvekkiller.Text = "[müvekkil seçilmedi]";
        }

        private void bndMasrafAvansDetay_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if ((int)lueModul.EditValue != 7)
                {
                    Muvekkiller.Clear();
                    try
                    {
                        foreach (var item2 in gcMuvekkiller.DataSource as TList<AV001_TDI_BIL_CARI>)
                            item2.IsSelected = false;
                        foreach (var item1 in ((TList<AV001_TDI_BIL_CARI>)AllMuvekkiller[((AV001_TDI_BIL_MASRAF_AVANS_DETAY)bndMasrafAvansDetay.Current).KAYIT_TARIHI]))
                            foreach (var item2 in gcMuvekkiller.DataSource as TList<AV001_TDI_BIL_CARI>)
                                if (item1.ID == item2.ID)
                                {
                                    item2.IsSelected = true;
                                    if (!Muvekkiller.Contains(item2))
                                        Muvekkiller.Add(item2);
                                }
                    }
                    catch
                    {
                    }
                    pceMuvekkiller.Text = string.Empty;
                    foreach (var item in Muvekkiller)
                        pceMuvekkiller.Text += item.AD + ", ";
                    if (pceMuvekkiller.Text.Length > 1)
                        pceMuvekkiller.Text = pceMuvekkiller.Text.Substring(0, pceMuvekkiller.Text.Length - 2);
                    else pceMuvekkiller.Text = "[müvekkil seçilmedi]"; 
                }
            }
            catch { ;}
        }

        private void chPaylastir_CheckedChanged(object sender, EventArgs e)
        {
            gcMuvekkiller.MainView.CloseEditor();
        }

        private void frmMasrafAvansKayitHizli_Button_Kaydet_Click(object sender, EventArgs e)
        {
            gcMuvekkiller.MainView.CloseEditor();
            if (!dxProviderMasraf.Validate())
                return;

            AV001_TDI_BIL_MASRAF_AVANS masraf = bndMasrafAvans.Current as AV001_TDI_BIL_MASRAF_AVANS;
            TList<AV001_TDI_BIL_FOY_MUHASEBE> muhasebe = new TList<AV001_TDI_BIL_FOY_MUHASEBE>();

            if (masraf == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Modül seçilmeden kayıt yapılamaz! Lüften modül seçiniz", "AvukatPro");
                return;
            }

            bool recorded = false;
            bool isFirstSave = true;

            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> detay = masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection;

            if (AllMuvekkiller == null)
                return;

            foreach (var item in detay)
            {
                if (((TList<AV001_TDI_BIL_CARI>)AllMuvekkiller[item.KAYIT_TARIHI]).Count < 1)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("En az bir müvekkil seçilmelidir.", "AvukatPro");
                    return;
                }
            }

            List<int> alMasrafIDs = new List<int>();
            List<decimal> birimfiyatlar = new List<decimal>();

            for (int run = 0; run < masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Count; run++)
            {
                if (chPaylastir.Checked)
                    birimfiyatlar.Add(masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[run].BIRIM_FIYAT
                                / ((TList<AV001_TDI_BIL_CARI>)AllMuvekkiller[detay[run].KAYIT_TARIHI]).Count);

                else
                    birimfiyatlar.Add(masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[run].BIRIM_FIYAT);
            }

            foreach (var detail in detay)
            {
                if (!string.IsNullOrEmpty(lueSegment.EditValue.ToString()))
                    detail.SEGMENT_ID = (int?)lueSegment.EditValue;
                detail.EFT_REFERANS_NO = txtEftReferansNo.Text;
                detail.BANKA_DEKONT_NO = txtBankaDekontNo.Text;
                if (detail.TOPLAM_TUTAR == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Değeri 0 olan masraf kaydı yapılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> detay2 = masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection;

            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            trans.BeginTransaction();
            try
            {
                foreach (AV001_TDI_BIL_CARI itemCari in gcMuvekkiller.DataSource as TList<AV001_TDI_BIL_CARI>)
                {
                    if (itemCari.IsSelected == true)
                    {
                        try
                        {
                            if (myIcraFoy != null) // Okan 18.08.2010
                            {
                                DataRepository.AV001_TI_BIL_FOYProvider.Save(trans, myIcraFoy);
                                masraf.ICRA_FOY_ID = MyIcraFoy.ID;
                            }
                            else if (MyDavaFoy != null)
                            {
                                DataRepository.AV001_TD_BIL_FOYProvider.Save(trans, MyDavaFoy);
                                masraf.DAVA_FOY_ID = MyDavaFoy.ID;
                            }
                            else if (MyHazirlikFoy != null)
                            {
                                DataRepository.AV001_TD_BIL_HAZIRLIKProvider.Save(trans, MyHazirlikFoy);
                                masraf.HAZIRLIK_ID = MyHazirlikFoy.ID;
                            }
                            else if (MySozlesmeFoy != null)
                            {
                                DataRepository.AV001_TDI_BIL_SOZLESMEProvider.Save(trans, MySozlesmeFoy);
                                masraf.SOZLESME_ID = MySozlesmeFoy.ID;
                            }
                        }
                        catch
                        {
                        }

                        if (Duzenleme && isFirstSave)
                            masraf.IsNew = false;

                        else
                            masraf.IsNew = true;

                        //DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.Save(masraf);

                        if (Duzenleme && isFirstSave)
                        {
                            if (masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection != null)
                            {
                                int run = -1;
                                foreach (var item in masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                                {
                                    bool contained = false;
                                    foreach (var item9 in ((TList<AV001_TDI_BIL_CARI>)AllMuvekkiller[item.KAYIT_TARIHI]))
                                    {
                                        if (item9.ID == itemCari.ID)
                                            contained = true;
                                    }

                                    if (contained)
                                    {
                                        item.MASRAF_AVANS_ID = masraf.ID;
                                        item.MUVEKKIL_CARI_ID = itemCari.ID;
                                        item.BIRIM_FIYAT = birimfiyatlar[++run];
                                        item.TOPLAM_TUTAR = item.BIRIM_FIYAT * item.ADET;
                                        item.GENEL_TOPLAM = item.TOPLAM_TUTAR;
                                        item.GENEL_TOPLAM_DOVIZ_ID = item.TOPLAM_TUTAR_DOVIZ_ID;
                                        item.BORC_ALACAK_ID = (int)lueBorcAlacak.GetColumnValue("ID");

                                        if (item.BORC_ALACAK_ID == 2)
                                        {
                                            item.BIRIM_FIYAT = -item.BIRIM_FIYAT;
                                            item.TOPLAM_TUTAR = item.BIRIM_FIYAT * item.ADET;
                                            item.GENEL_TOPLAM = item.TOPLAM_TUTAR;
                                        }
                                        //masraf eksi kayıt
                                        //if (item.HAREKET_ALT_KATEGORI_ID == 4 || item.HAREKET_ALT_KATEGORI_ID == 316)
                                        //{
                                        //    item.BORC_ALACAK_ID = (int)AvukatProLib.Extras.BorcAlacak.Alacak;
                                        //}
                                        //else
                                        //{
                                        //    item.BORC_ALACAK_ID = (int)AvukatProLib.Extras.BorcAlacak.Borc;
                                        //    item.BIRIM_FIYAT = -item.BIRIM_FIYAT;
                                        //}
                                    }

                                    else
                                    {
                                        item.MUVEKKIL_CARI_ID = null;
                                        run++;
                                    }
                                }
                            }

                            //DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepSave(masraf);
                            DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.Save(masraf);//afterSt
                        }

                        else//
                        {
                            DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.Save(masraf);
                            CreateFoyMuhasebeByMasrafAvansRequest request = new CreateFoyMuhasebeByMasrafAvansRequest();
                            request.MasrafAvansId = masraf.ID;
                            request.ModulId = masraf.CARI_HESAP_HEDEF_TIP;
                            AvukatPro.Services.Implementations.MuhasebeService.CreateFoyMuhasebeByMasrafAvans(request);

                            muhasebe = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetByMASRAF_AVANS_ID(masraf.ID);
                        }

                        //if (!Duzenleme)
                        if (detay != null)
                        {
                            int run = -1;
                            foreach (var item in detay)
                            {
                                bool contained = false;
                                foreach (var item9 in ((TList<AV001_TDI_BIL_CARI>)AllMuvekkiller[item.KAYIT_TARIHI]))
                                {
                                    if (item9.ID == itemCari.ID)
                                        contained = true;
                                }

                                if (contained)
                                {
                                    item.MASRAF_AVANS_ID = masraf.ID;
                                    item.MUVEKKIL_CARI_ID = itemCari.ID;
                                    item.BIRIM_FIYAT = birimfiyatlar[++run];
                                    item.TOPLAM_TUTAR = item.BIRIM_FIYAT * item.ADET;
                                    item.GENEL_TOPLAM = item.TOPLAM_TUTAR;
                                    item.GENEL_TOPLAM_DOVIZ_ID = item.TOPLAM_TUTAR_DOVIZ_ID;

                                    if ((int)lueBorcAlacak.GetColumnValue("ID") == 2)
                                    {
                                        item.BIRIM_FIYAT = -item.BIRIM_FIYAT;
                                        if (item.TOPLAM_TUTAR > 0)
                                            item.TOPLAM_TUTAR = -item.TOPLAM_TUTAR;
                                        if (item.GENEL_TOPLAM > 0)
                                            item.GENEL_TOPLAM = -item.GENEL_TOPLAM;
                                    }
                                }
                                else
                                {
                                    item.MUVEKKIL_CARI_ID = null;
                                    run++;
                                }
                            }
                        }

                        foreach (var item in detay)
                        {
                            if (Duzenleme && isFirstSave)
                                item.IsNew = false;
                            else
                                item.IsNew = true;
                        }

                        if (Duzenleme && isFirstSave)
                        {
                            foreach (var eleman in detay)
                            {
                                eleman.BORC_ALACAK_ID = (int)lueBorcAlacak.GetColumnValue("ID");

                                if (eleman.BORC_ALACAK_ID == 2)
                                {
                                    if (eleman.BIRIM_FIYAT > 0)
                                        eleman.BIRIM_FIYAT = -eleman.BIRIM_FIYAT;

                                    if (eleman.TOPLAM_TUTAR > 0)
                                        eleman.TOPLAM_TUTAR = -eleman.TOPLAM_TUTAR;

                                    if (eleman.GENEL_TOPLAM > 0)
                                        eleman.GENEL_TOPLAM = -eleman.GENEL_TOPLAM;
                                }
                                //if (eleman.HAREKET_ALT_KATEGORI_ID == 4 || eleman.HAREKET_ALT_KATEGORI_ID == 316)
                                //{
                                //    eleman.BORC_ALACAK_ID = (int)AvukatProLib.Extras.BorcAlacak.Alacak;
                                //}
                                //else
                                //{
                                //    eleman.BORC_ALACAK_ID = (int)AvukatProLib.Extras.BorcAlacak.Borc; 
                                //    eleman.BIRIM_FIYAT = -eleman.BIRIM_FIYAT;
                                //}

                                if (eleman.MUVEKKIL_CARI_ID != null)
                                    DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.Update(eleman);

                                //if (Duzenleme)
                                //{
                                SqlConnection cn = new SqlConnection(AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr);
                                SqlCommand cmd = new SqlCommand("AV001_TDI_BIL_FOY_MUHASEBE_DETAY_UpdateByMasrafAvans", cn);
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@MASRAF_AVANS_DETAY_ID", eleman.ID);
                                if (cn.State == System.Data.ConnectionState.Closed)
                                    cn.Open();
                                cmd.ExecuteNonQuery();
                                cn.Close();
                                cn.Dispose();
                                //}
                            }
                        }

                        else
                        {
                            foreach (var eleman in detay)
                            {
                                if (eleman.MUVEKKIL_CARI_ID != null)
                                {
                                    eleman.BORC_ALACAK_ID = (int)lueBorcAlacak.GetColumnValue("ID");

                                    if (eleman.BORC_ALACAK_ID == 2)
                                    {
                                        if (eleman.BIRIM_FIYAT > 0)
                                            eleman.BIRIM_FIYAT = -eleman.BIRIM_FIYAT;

                                        if (eleman.TOPLAM_TUTAR > 0)
                                            eleman.TOPLAM_TUTAR = -eleman.TOPLAM_TUTAR;

                                        if (eleman.GENEL_TOPLAM > 0)
                                            eleman.GENEL_TOPLAM = -eleman.GENEL_TOPLAM;
                                    }
                                    //if (eleman.HAREKET_ALT_KATEGORI_ID == 4 || eleman.HAREKET_ALT_KATEGORI_ID == 316)
                                    //{
                                    //    eleman.BORC_ALACAK_ID = (int)AvukatProLib.Extras.BorcAlacak.Alacak;
                                    //}
                                    //else
                                    //{
                                    //    eleman.BORC_ALACAK_ID = (int)AvukatProLib.Extras.BorcAlacak.Borc; 
                                    //    eleman.BIRIM_FIYAT = -eleman.BIRIM_FIYAT;
                                    //}

                                    //DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.Save(eleman);
                                    DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.DeepSave(eleman, DeepSaveType.IncludeChildren, typeof(TList<NN_BELGE_MASRAF_AVANS_DETAY>));

                                    CreateFoyMuhasebeDetayByMasrafAvansDetayRequest request = new CreateFoyMuhasebeDetayByMasrafAvansDetayRequest();
                                    request.MasrafAvansDetayId = eleman.ID;
                                    request.MuhasebeId = muhasebe.FirstOrDefault().ID;
                                    request.YenidenHesaplanabilir = !eleman.MA_MANUAL_KAYIT_MI;
                                    AvukatPro.Services.Implementations.MuhasebeService.CreateFoyMuhasebeDetayByMasrafAvansDetay(request);

                                    //if (Duzenleme)
                                    //{
                                        SqlConnection cn = new SqlConnection(AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr);
                                        SqlCommand cmd = new SqlCommand("AV001_TDI_BIL_FOY_MUHASEBE_DETAY_UpdateByMasrafAvans", cn);
                                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                        cmd.Parameters.AddWithValue("@MASRAF_AVANS_DETAY_ID", eleman.ID);
                                        if (cn.State == System.Data.ConnectionState.Closed)
                                            cn.Open();
                                        cmd.ExecuteNonQuery();
                                        cn.Close();
                                        cn.Dispose();
                                    //}
                                }
                            }
                        }

                        if (MyProje != null)
                        {
                            if (masraf.AV001_TDIE_BIL_PROJE_MASRAF_AVANSCollection != null)
                            {
                                foreach (var item in masraf.AV001_TDIE_BIL_PROJE_MASRAF_AVANSCollection)
                                {
                                    item.MASRAF_AVANS_ID = masraf.ID;
                                    DataRepository.AV001_TDIE_BIL_PROJE_MASRAF_AVANSProvider.Save(trans, item);
                                }
                            }
                        }

                        if (!alMasrafIDs.Contains(masraf.ID))
                            alMasrafIDs.Add(masraf.ID);

                        isFirstSave = false;
                    }
                }
                trans.Commit();
                recorded = true;
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                {
                    trans.Rollback();
                }
                recorded = false;
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }

            

            if (recorded)
            {
                foreach (int item in alMasrafIDs)
                    AvukatPro.Services.Implementations.CariService.CreateCariHesapByMasrafAvans(item);

                Forms.frmKlasorYeni.MasraflarYuklendi = false;//Masraf kaydın yapıldığında klasördeki masrafların refresh olması için eklendi. MB
                DevExpress.XtraEditors.XtraMessageBox.Show("Kayıt İşlemi Tamamlandı.", "AvukatPro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (Kaydedildi != null)
                    Kaydedildi(this, null);
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Kayıt İşlemi Yapılmadı.", "AvukatPro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        private void frmMasrafAvansKayitHizli_Load(object sender, EventArgs e)
        {
            if (!lookUpsFill)
            {
                BindLookUps();
                lookUpsFill = true;
            }

            if (Duzenleme)
                lueMasrafAvansTip.Properties.ReadOnly = true;
            lueMasrafAvansTip.Properties.ReadOnly = false;//arch
            lueMuvekkil.Visible = false;
            chPaylastir.CheckedChanged += new EventHandler(chPaylastir_CheckedChanged);

            if (Duzenleme)
                if (MyDavaFoy != null)
                    CreateMuvekkils(MyDavaFoy);
                else if (MyIcraFoy != null)
                    CreateMuvekkils(MyIcraFoy);
                else if (MySozlesmeFoy != null)
                    CreateMuvekkils(MySozlesmeFoy);
                else if (MyHazirlikFoy != null)
                    CreateMuvekkils(MyHazirlikFoy);

            bndMasrafAvansDetay.CurrentChanged += new EventHandler(bndMasrafAvansDetay_CurrentChanged);            
            if (Duzenleme)
            {
                if (DefaultDetail != null)
                {
                    TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> temp = new TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>();
                    temp.Add(DefaultDetail);
                    foreach (var item in MyDataSource.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                        if (!temp.Contains(item))
                            temp.Add(item);
                    bndMasrafAvansDetay.DataSource = temp;
                }

                if (DefaultMuvekkil > 0)
                    foreach (var item2 in gcMuvekkiller.DataSource as TList<AV001_TDI_BIL_CARI>)
                        if (DefaultMuvekkil == item2.ID)
                            item2.IsSelected = true;
                        else item2.IsSelected = false;

                if (AllMuvekkiller == null)
                    AllMuvekkiller = new System.Collections.Hashtable();
                TList<AV001_TDI_BIL_CARI> liste = new TList<AV001_TDI_BIL_CARI>();
                foreach (var item in gcMuvekkiller.DataSource as TList<AV001_TDI_BIL_CARI>)
                    if (item.IsSelected)
                        liste.Add(item);

                foreach (var detay in (TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>)bndMasrafAvansDetay.DataSource)
                    if (!AllMuvekkiller.ContainsKey(detay.KAYIT_TARIHI))
                        AllMuvekkiller.Add(detay.KAYIT_TARIHI, liste);
                    else AllMuvekkiller[detay.KAYIT_TARIHI] = liste;

                if (Muvekkiller == null)
                    Muvekkiller = new TList<AV001_TDI_BIL_CARI>();
                else Muvekkiller.Clear();
                foreach (var item in liste)
                    Muvekkiller.Add(item);

                pceMuvekkiller.Text = string.Empty;
                foreach (var item in Muvekkiller)
                    pceMuvekkiller.Text += item.AD + ", ";
                if (pceMuvekkiller.Text.Length > 1)
                    pceMuvekkiller.Text = pceMuvekkiller.Text.Substring(0, pceMuvekkiller.Text.Length - 2);
                else pceMuvekkiller.Text = "[müvekkil seçilmedi]";

                //MyIcraFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection = DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.GetByICRA_FOY_ID(MyIcraFoy.ID);
            }
            else if (SelectedDosya > 1)


                if (lueDosya.Properties.DataSource == null)
                {
                    BelgeUtil.Inits.DosyaDoldur(lueModul.Text);
                    lueDosya.EditValue = SelectedDosya;
                }

            if (Duzenleme)
            {
                groupControl3.Visible = false;
                groupControl4.Top = 3;
                xtraTabControl1.Top = 172;
                AV001_TDI_BIL_MASRAF_AVANS masraf = bndMasrafAvans.Current as AV001_TDI_BIL_MASRAF_AVANS;
                luePersonel.EditValue = masraf.CARI_ID;
            }
            else
            {
                groupControl3.Visible = true;
                luePersonel.EditValue = AvukatProLib.Kimlikci.Kimlik.Cari_ID;
            }
        }

        private void gcMuvekkiller_DataSourceChanged(object sender, EventArgs e)
        {
            gcMuvekkiller.MainView.CloseEditor();
            if (Muvekkiller == null) Muvekkiller = new TList<AV001_TDI_BIL_CARI>();
            foreach (var item in ((TList<AV001_TDI_BIL_CARI>)gcMuvekkiller.DataSource))
                if (item.IsSelected && !Muvekkiller.Contains(item)) Muvekkiller.Add(item);
                else if (!item.IsSelected && Muvekkiller.Contains(item)) Muvekkiller.Remove(item);
            if (Muvekkiller.Count < 2) chPaylastir.Checked = false;
            else chPaylastir.Checked = true;
            pceMuvekkiller.Text = string.Empty;
            foreach (var item in Muvekkiller) pceMuvekkiller.Text += item.AD + ", ";
            if (pceMuvekkiller.Text.Length > 1) pceMuvekkiller.Text = pceMuvekkiller.Text.Substring(0, pceMuvekkiller.Text.Length - 2);
            else pceMuvekkiller.Text = "[müvekkil seçilmedi]";
        }

        private void gvMuvekkiller_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gcMuvekkiller.MainView.CloseEditor();
            if (!e.Column.FieldName.Equals("IsSelected"))
                return;
            if (Muvekkiller == null)
                Muvekkiller = new TList<AV001_TDI_BIL_CARI>();
            AV001_TDI_BIL_CARI currentCari = new AV001_TDI_BIL_CARI();
            if (gvMuvekkiller.GetFocusedRow() != null && gvMuvekkiller.GetFocusedRow() is AV001_TDI_BIL_CARI)
                currentCari = gvMuvekkiller.GetFocusedRow() as AV001_TDI_BIL_CARI;
            if (currentCari.IsSelected && !Muvekkiller.Contains(currentCari))
                Muvekkiller.Add(gvMuvekkiller.GetFocusedRow() as AV001_TDI_BIL_CARI);
            else if (!currentCari.IsSelected && Muvekkiller.Contains(currentCari))
                Muvekkiller.Remove(currentCari);
            if (Muvekkiller.Count < 2)
                chPaylastir.Checked = false;
            else chPaylastir.Checked = true;
            gcMuvekkiller.MainView.CloseEditor();
            pceMuvekkiller.Text = string.Empty;
            foreach (var item in Muvekkiller)
                pceMuvekkiller.Text += item.AD + ", ";
            if (pceMuvekkiller.Text.Length > 1)
                pceMuvekkiller.Text = pceMuvekkiller.Text.Substring(0, pceMuvekkiller.Text.Length - 2);
            else pceMuvekkiller.Text = "[müvekkil seçilmedi]";

            if (AllMuvekkiller == null)
                AllMuvekkiller = new System.Collections.Hashtable();
            TList<AV001_TDI_BIL_CARI> liste = new TList<AV001_TDI_BIL_CARI>();
            foreach (var item in Muvekkiller)
                liste.Add(item);
            if (!AllMuvekkiller.ContainsKey(((AV001_TDI_BIL_MASRAF_AVANS_DETAY)bndMasrafAvansDetay.Current).KAYIT_TARIHI))
                AllMuvekkiller.Add(((AV001_TDI_BIL_MASRAF_AVANS_DETAY)bndMasrafAvansDetay.Current).KAYIT_TARIHI, liste);
            else AllMuvekkiller[((AV001_TDI_BIL_MASRAF_AVANS_DETAY)bndMasrafAvansDetay.Current).KAYIT_TARIHI] = liste;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmMasrafAvansKayitHizli_Button_Kaydet_Click;
        }

        private void lueAnaKategori_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAnaKategori.EditValue == null || lueAnaKategori.EditValue == "")
                return;
            int anaKategoriID = (int)lueAnaKategori.EditValue;

                BelgeUtil.Inits.MuhasebeHareketAltKategoriByAnakategoriIdAlti(lueAltKategori.Properties, anaKategoriID);
        }

        private void lueBelge_EditValueChanged(object sender, EventArgs e)
        {
            if (Duzenleme) return;

            NN_BELGE_MASRAF_AVANS_DETAY belge = new NN_BELGE_MASRAF_AVANS_DETAY();
            belge.BELGE_ID = (int)lueBelge.EditValue;

            if (belge != null)
            {
                AV001_TDI_BIL_MASRAF_AVANS_DETAY detay = bndMasrafAvansDetay.Current as AV001_TDI_BIL_MASRAF_AVANS_DETAY;

                if (detay != null)
                {
                    belge.MASRAF_AVANS_DETAY_ID = detay.MASRAF_AVANS_ID;
                    detay.NN_BELGE_MASRAF_AVANS_DETAYCollection.Add(belge);
                }
            }
        }

        private void lueCekSenet_EditValueChanged(object sender, EventArgs e)
        {
            //if (Duzenleme) return;

            //int cekSenetId = Convert.ToInt32(lueCekSenet.EditValue);

            //if (cekSenetId != null)
            //{
            //    AV001_TDI_BIL_MASRAF_AVANS_DETAY detay = bndMasrafAvansDetay.Current as AV001_TDI_BIL_MASRAF_AVANS_DETAY;

            //    if (detay != null)
            //    {
            //        detay.KIYMETLI_EVRAK_ID = cekSenetId;
            //    }
            //}
        }

        private void lueKasa_EditValueChanged(object sender, EventArgs e)
        {
            //if (Duzenleme) return;

            //int hesapId = Convert.ToInt32(lueKasa.EditValue);

            //if (hesapId != null)
            //{
            //    AV001_TDI_BIL_MASRAF_AVANS_DETAY detay = bndMasrafAvansDetay.Current as AV001_TDI_BIL_MASRAF_AVANS_DETAY;

            //    if (detay != null)
            //    {
            //        detay.BURO_HESAP_SAHIBI_CARI_ID = (int?)lueKasa.Properties.View.GetRowCellValue(lueKasa.Properties.View.GetSelectedRows()[0], "CariId");
            //        detay.BURO_HESAP_SAHIBI_CARI_BANKA_ID = Convert.ToInt32(lueKasa.EditValue);
            //    }
            //}
        }

        private void lueMasrafAvansTip_EditValueChanged(object sender, EventArgs e)
        {
            if (Duzenleme) return;

            int masrafAvansTip = Convert.ToInt32(lueMasrafAvansTip.EditValue);

                AV001_TDI_BIL_MASRAF_AVANS masraf = bndMasrafAvans.Current as AV001_TDI_BIL_MASRAF_AVANS;
                AV001_TDI_BIL_MASRAF_AVANS_DETAY detay = bndMasrafAvansDetay.Current as AV001_TDI_BIL_MASRAF_AVANS_DETAY;

                if (masraf != null)
                {
                    if (masrafAvansTip == (int)AvukatProLib.Extras.MasrafAvansTip.Masraf)
                    {
                        masraf.MASRAF_AVANS_TIP = (int)AvukatProLib.Extras.MasrafAvansTip.Masraf;
                        detay.BORC_ALACAK_ID = (int)AvukatProLib.Extras.BorcAlacak.Borc;

                        if (MyDavaFoy != null || MyHazirlikFoy != null)
                            detay.HAREKET_ANA_KATEGORI_ID = 1; //MAHKEME MASRAFLARI
                        else
                            detay.HAREKET_ANA_KATEGORI_ID = 16; //ICRA TAKİP MASRAFLARI

                        BelgeUtil.Inits.MuhasebeHareketAltKategoriByAnakategoriIdAlti(lueAltKategori.Properties,
                                                                                      detay.HAREKET_ANA_KATEGORI_ID);
                    }
                    else
                    {
                        masraf.MASRAF_AVANS_TIP = (int)AvukatProLib.Extras.MasrafAvansTip.Avans;
                        detay.BORC_ALACAK_ID = (int)AvukatProLib.Extras.BorcAlacak.Alacak;
                        detay.HAREKET_ANA_KATEGORI_ID = 10; //AVANS HESABI
                        BelgeUtil.Inits.MuhasebeHareketAltKategoriByAnakategoriIdAlti(lueAltKategori.Properties,
                                                                                      detay.HAREKET_ANA_KATEGORI_ID);
                    }
                }
        }

        private void lueMuhatap_EditValueChanged(object sender, EventArgs e)
        {
            //if (Duzenleme) return;

            //int hesapId = Convert.ToInt32(lueMuhatap.EditValue);

            //if (hesapId != null)
            //{
            //    AV001_TDI_BIL_MASRAF_AVANS_DETAY detay = bndMasrafAvansDetay.Current as AV001_TDI_BIL_MASRAF_AVANS_DETAY;

            //    if (detay != null)
            //    {
            //        detay.MUHATAP_HESAP_SAHIBI_CARI_ID = (int?)lueKasa.Properties.View.GetRowCellValue(lueKasa.Properties.View.GetSelectedRows()[0], "CariId");
            //        detay.MUHATAP_HESAP_SAHIBI_CARI_BANKA_ID = Convert.ToInt32(lueMuhatap.EditValue);
            //    }
            //}
        }

        private void lueOdemeTip_EditValueChanged(object sender, EventArgs e)
        {
            if (lueOdemeTip.Text == EvrakTurleri.ÇEK.ToString())
            {
                lueCekSenet.Enabled = true;
                //lcCekSenet.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                AvukatPro.Services.Implementations.DevExpressService.KiymetliEvrakDoldur(lueCekSenet);
            }

            else if (lueOdemeTip.Text == EvrakTurleri.BONO.ToString())
            {
                lueCekSenet.Enabled = true;
                //lcCekSenet.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                AvukatPro.Services.Implementations.DevExpressService.KiymetliEvrakDoldur(lueCekSenet);
            }

            else
            {
                //lcCekSenet.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lueCekSenet.Enabled = false;
            }
        }

        private void masrafDetay_ColumnChanged(object sender, AV001_TDI_BIL_MASRAF_AVANS_DETAYEventArgs e)
        {
            AV001_TDI_BIL_MASRAF_AVANS_DETAY detay = sender as AV001_TDI_BIL_MASRAF_AVANS_DETAY;
            AV001_TDI_BIL_MASRAF_AVANS masraf = bndMasrafAvans.Current as AV001_TDI_BIL_MASRAF_AVANS;

            if (detay == null || masraf == null)
                return;

            switch (e.Column)
            {
                #region HAREKET_ALT_KATEGORI_ID

                //case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.HAREKET_ALT_KATEGORI_ID:
                //if (detay.HAREKET_ALT_KATEGORI_ID == 381 || detay.HAREKET_ALT_KATEGORI_ID == 41)
                ////Müvekkile Ödeme || Avans İadesi
                //{
                //    if (masraf.MASRAF_AVANS_TIP == 1)
                //    {
                //        detay.BORC_ALACAK_ID = 2;
                //    }
                //    else if (masraf.MASRAF_AVANS_TIP == 2)
                //    {
                //        detay.BORC_ALACAK_ID = 1;
                //    }
                //}
                //if (masraf.MASRAF_AVANS_TIP == (int)AvukatProLib.Extras.MasrafAvansTip.Avans)
                //{
                //    if (AcilisYeri != MasrafFormuAcilisiYeri.PersonelMuhasebeAvans)
                //    {
                //        if (detay.HAREKET_ALT_KATEGORI_ID == 4 || detay.HAREKET_ALT_KATEGORI_ID == 316 ||
                //            detay.HAREKET_ALT_KATEGORI_ID == 40)
                //            //MASRAF AVANSI, TEMİNAT AVANSI, VEKALET ÜCRETİ AVANSI
                //            detay.BORC_ALACAK_ID = (int)AvukatProLib.Extras.BorcAlacak.Alacak;

                //        if (detay.HAREKET_ALT_KATEGORI_ID == 41) //AVANS İADESİ
                //            detay.BORC_ALACAK_ID = (int)AvukatProLib.Extras.BorcAlacak.Borc;
                //    }
                //    else
                //    {
                //        if (detay.HAREKET_ALT_KATEGORI_ID == 4 || detay.HAREKET_ALT_KATEGORI_ID == 316 ||
                //            detay.HAREKET_ALT_KATEGORI_ID == 945) //MASRAF AVANSI, TEMİNAT AVANSI, MAAŞ AVANSI
                //            detay.BORC_ALACAK_ID = (int)AvukatProLib.Extras.BorcAlacak.Borc;

                //        if (detay.HAREKET_ALT_KATEGORI_ID == 41) //AVANS İADESİ
                //            detay.BORC_ALACAK_ID = (int)AvukatProLib.Extras.BorcAlacak.Alacak;
                //    }
                //}

                //if (detay.HAREKET_ALT_KATEGORI_ID == 41 || detay.HAREKET_ALT_KATEGORI_ID == 943 || detay.HAREKET_ALT_KATEGORI_ID == 10006)
                //{
                //    detay.BORC_ALACAK_ID = (int)AvukatProLib.Extras.BorcAlacak.Borc;
                //    detay.BIRIM_FIYAT = detay.BIRIM_FIYAT * -1;
                //}
                //else if (detay.HAREKET_ALT_KATEGORI_ID == 4 || detay.HAREKET_ALT_KATEGORI_ID == 316)
                //{
                //    detay.BORC_ALACAK_ID = (int)AvukatProLib.Extras.BorcAlacak.Alacak;
                //}

                //TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI altKategori =
                //    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByID(
                //        detay.HAREKET_ALT_KATEGORI_ID);
                //detay.HAREKET_ANA_KATEGORI_ID = altKategori.ANA_KATEGORI_ID;
                //break;

                #endregion HAREKET_ALT_KATEGORI_ID

                #region TOPLAM_TUTAR

                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.TOPLAM_TUTAR:
                    if (detay != null)
                    {
                        if (detay.ADET == 0)
                            detay.ADET = 1;

                        detay.BIRIM_FIYAT = detay.TOPLAM_TUTAR / detay.ADET;
                    }
                    break;

                #endregion TOPLAM_TUTAR

                #region BIRIM_FIYAT, ADET

                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.BIRIM_FIYAT:
                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.ADET:

                    if (detay != null)
                    {
                        detay.TOPLAM_TUTAR = detay.ADET * detay.BIRIM_FIYAT;
                    }
                    break;

                #endregion BIRIM_FIYAT, ADET

                #region TUM_MUVEKKILLERE_PAYLASTIR

                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.TUM_MUVEKKILLERE_PAYLASTIR:

                    bool islem = (bool)e.Value;

                    //colMUVEKKIL_CARI_ID.Visible = !islem;

                    if (islem)
                    {
                        detay.MUVEKKIL_CARI_ID = null;
                    }
                    else
                    {
                        if (lueMuvekkil.Properties.DataSource != null)
                        {
                            TList<AV001_TDI_BIL_CARI> carliListesi =
                                lueMuvekkil.Properties.DataSource as TList<AV001_TDI_BIL_CARI>;
                            if (carliListesi != null)
                            {
                                if (carliListesi.Count == 1)
                                    detay.MUVEKKIL_CARI_ID = carliListesi[0].ID;
                            }
                        }
                    }

                    break;

                #endregion TUM_MUVEKKILLERE_PAYLASTIR

                #region MUVEKKIL_CARI_ID

                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.MUVEKKIL_CARI_ID:
                    if (detay.MUVEKKIL_CARI_ID != null)
                        detay.TUM_MUVEKKILLERE_PAYLASTIR = false;
                    break;

                #endregion MUVEKKIL_CARI_ID
            }

            #region Föyün tekrar hesaplanmasını önlemek için yapıldı. Okan 18.08.2010

            if (myIcraFoy == null || myIcraFoy.EXTRA_LONG1 == 1) return;
            switch (e.Column)
            {
                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.BIRIM_FIYAT:
                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.BIRIM_FIYAT_DOVIZ:
                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.BIRIM_FIYAT_DOVIZ_ID:
                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.BIRIM_FIYAT_DOVIZ_KUR:
                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.GENEL_TOPLAM:
                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.GENEL_TOPLAM_DOVIZ_ID:
                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.KDV_ORAN:
                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.KDV_TUTAR:
                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.STOPAJ_ORAN:
                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.STOPAJ_SSDF_DAHIL:
                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.STOPAJ_SSDF_TUTAR:
                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.TOPLAM_TUTAR:
                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.TOPLAM_TUTAR_DOVIZ_ID:
                    myIcraFoy.EXTRA_LONG1 = 1;
                    break;
            }

            #endregion Föyün tekrar hesaplanmasını önlemek için yapıldı. Okan 18.08.2010
        }

        #endregion Methods

        private void spAdet_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                spTutar.EditValue = spAdet.Value * spBirimFiyat.Value;
            }
            catch { ;}
        }

        private void spBirimFiyat_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                spTutar.EditValue = spAdet.Value * spBirimFiyat.Value;
            }
            catch { ;}
        }

        private void lueAltKategori_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag.ToString() == "1")
            {
                if (lueAnaKategori.EditValue == null || lueAnaKategori.EditValue == "")
                    return;
                int anaKategoriID = (int)lueAnaKategori.EditValue;

                frmAltKategoriEkle frmalt = new frmAltKategoriEkle(frmAltKategoriEkle.Tipler.AltKategori, anaKategoriID);
                frmalt.ShowDialog();

                    BelgeUtil.Inits.MuhasebeHareketAltKategoriByAnakategoriIdAlti(lueAltKategori.Properties, anaKategoriID);
            }
        }

        private void lueBelge_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag.ToString() == "ekle")
            {
                frmBelgeKayitUfak frmblg = new frmBelgeKayitUfak();
                frmblg.ShowDialog();
                AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(lueBelge);
            }
        }

        private void lueBelge_Enter(object sender, EventArgs e)
        {
            if (lueBelge.Properties.DataSource == null)
                AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(lueBelge);
        }
    }
}