using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.Uyap;
using AvukatPro.Services.Implementations;
using AvukatPro.Services.Interfaces;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace AdimAdimDavaKaydi.Sozlesme.Forms
{
    public partial class frmSozlesmeKayitLayout : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        #region Fields

        public bool EditMode = false;
        private readonly TDI_KOD_TARAF tmpTaraf = new TDI_KOD_TARAF();
        private DateTime BasTarih;
        private DateTime BitTarih;
        private TList<AV001_TDI_BIL_SOZLESME> mySozlesme;
        private UyapGeriBildirim _uyapBildirim;

        #endregion Fields

        #region Constructors

        public frmSozlesmeKayitLayout()
        {
            InitializeComponent();
            InitializeEvents();
            this.FormClosed += frmSozlesmeKayitLayout_FormClosed;
            this.FormClosing += new FormClosingEventHandler(frmSozlesmeKayitLayout_FormClosing);
            this.gwSozlesmeMuvekkilT.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gwSozlesmeMuvekkilT_CellValueChanged);
            this.gwSozlesmeKarsiTarafi.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gwSozlesmeKarsiTarafi_CellValueChanged);
            this.bndAracBilgileri.CurrentChanged += new EventHandler(bndAracBilgileri_CurrentChanged);
        }

        #endregion Constructors

        #region Events

        public event EventHandler<SozlesmeFoyKaydedildiEventArgs> SozlesmeKaydedildi;

        #endregion Events

        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static int MalikID
        {
            get;
            set;
        }

        //Gayrimenkul bilgilerine listeden getirme işlemi eklendi.
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static TList<AV001_TI_BIL_GAYRIMENKUL> SelectedGayrimenkulList
        {
            get;
            set;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TDI_BIL_SOZLESME_TARAF> Muvekkil
        {
            get;
            set;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TDI_BIL_SOZLESME_TARAF> MuvekkilKarsi
        {
            get;
            set;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int MyNNKayitSozlesme
        {
            get;
            set;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TDIE_BIL_PROJE MyProje
        {
            get;
            set;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TDI_BIL_SOZLESME> MySozlesme
        {
            get { return mySozlesme; }
            set
            {
                mySozlesme = value;
                try
                {
                    setSozlesme(value);
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TDI_BIL_SOZLESME_SORUMLU> SorumluAvk
        {
            get;
            set;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TDI_BIL_SOZLESME_TARAF> TumTaraflar
        {
            get
            {
                TList<AV001_TDI_BIL_SOZLESME_TARAF> result = new TList<AV001_TDI_BIL_SOZLESME_TARAF>();
                result.AddRange(Muvekkil);
                result.AddRange(MuvekkilKarsi);
                return result;
            }
            set
            {
                MuvekkilKarsi.Clear();
                Muvekkil.Clear();
                DataRepository.AV001_TDI_BIL_SOZLESME_TARAFProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren,
                                                                             typeof(TDIE_KOD_TARAF_SIFAT),
                                                                             typeof(
                                                                                 TList
                                                                                 <AV001_TDI_BIL_SOZLESME_TARAF_VEKIL>));
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UyapGeriBildirim UyapBildirim
        {
            get { return _uyapBildirim; }
            set { _uyapBildirim = value; }
        }

        #endregion Properties

        #region Methods

        public void Show(int sozlesmeTip)
        {
            MySozlesme = new TList<AV001_TDI_BIL_SOZLESME>();
            //MySozlesme.AddNew();

            MySozlesme[0].TIP_ID = sozlesmeTip;
            lueSozlesmeTipi.Enabled = false;

            this.Show();
        }

        public void Show(TList<AV001_TDI_BIL_SOZLESME> sozlesmeList)
        {
            MySozlesme = sozlesmeList;
            //MySozlesme[0].TIP_ID = sozlesmeList[0].TIP_ID;
            //MySozlesme[0].ALT_TIP_ID = sozlesmeList[0].ALT_TIP_ID;
            lueSozlesmeTipi.Enabled = false;
            lueSozlesmeAltTip.Enabled = false;
            this.Show();
        }

        internal void Show(int p, int p_2)
        {
            MySozlesme = new TList<AV001_TDI_BIL_SOZLESME>();
            //MySozlesme.AddNew();
            MySozlesme[0].TIP_ID = p;
            MySozlesme[0].ALT_TIP_ID = p_2;
            lueSozlesmeTipi.Enabled = false;
            lueSozlesmeAltTip.Enabled = false;
            this.Show();
        }

        private void AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SOZLESME_GEMI_UCAK_ARAC_AddingNew(object sender,
            AddingNewEventArgs
            e)
        {
            AV001_TDI_BIL_GEMI_UCAK_ARAC gua = new AV001_TDI_BIL_GEMI_UCAK_ARAC();
            gua.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            gua.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            gua.KAYIT_TARIHI = DateTime.Now;
            gua.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            //var obj = gua.AV001_TDI_BIL_SOZLESME_DERECECollection;

            //Derece-Sıra
            //if (gua.AV001_TDI_BIL_SOZLESME_DERECECollection == null)
            //    gua.AV001_TDI_BIL_SOZLESME_DERECECollection = new TList<AV001_TDI_BIL_SOZLESME_DERECE>();
            //ucSozlesmeDerece2.MyDerece = gua.AV001_TDI_BIL_SOZLESME_DERECECollection;
            //ucSozlesmeDerece2.MyDerece.AddingNew += MyDerece_AddingNew;

            //bndExpertiz.DataSource = gua.AV001_TI_BIL_KIYMET_TAKDIRICollection;
            //dnExpertizArac.DataSource = gua.AV001_TI_BIL_KIYMET_TAKDIRICollection;
            //ucSozlesmeTakdiyatArac.MyDataSource = gua.AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDATCollection;

            gua.KONTROL_NE_ZAMAN = DateTime.Now;
            gua.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

            if (MySozlesme[0].SICIL_TIP_ID == 5) //Uçak Sicil
                gua.TIPI = 7; //UÇAK
            else if (MySozlesme[0].SICIL_TIP_ID == 4) //Gemi Normal
                gua.TIPI = 8; //GEMİ
            else
                gua.TIPI = 9; //ARAÇ

            e.NewObject = gua;
        }

        private void AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL_AddingNew(object sender,
            AddingNewEventArgs e)
        {
            panelControl22.Enabled = true;//+ ya basınca gayrimenkul bilgilerinin enable edilmesi için eklendi. MB

            AV001_TI_BIL_GAYRIMENKUL gayrimenkul = new AV001_TI_BIL_GAYRIMENKUL();
            gayrimenkul.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            gayrimenkul.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            gayrimenkul.KAYIT_TARIHI = DateTime.Now;
            gayrimenkul.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            gayrimenkul.KONTROL_NE_ZAMAN = DateTime.Now;
            gayrimenkul.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

            e.NewObject = gayrimenkul;
        }

        void bndAracBilgileri_CurrentChanged(object sender, EventArgs e)
        {
            var arac = bndAracBilgileri.Current as AV001_TDI_BIL_GEMI_UCAK_ARAC;

            if (EditMode)
            {
                DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.DeepLoad(arac, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_DERECE>), typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>), typeof(TList<AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDAT>));

            }
            bndExpertiz.DataSource = arac.AV001_TI_BIL_KIYMET_TAKDIRICollection;
            ucSozlesmeDerece2.MyDerece = arac.AV001_TDI_BIL_SOZLESME_DERECECollection;
            ucSozlesmeDerece2.MyDerece.AddingNew += MyDerece_AddingNew;
            ucSozlesmeTakdiyatArac.MyDataSource = arac.AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDATCollection;
        }

        private void bndDigerMal_CurrentChanged(object sender, EventArgs e)
        {
            var digerMal = bndDigerMal.Current as TDI_BIL_BORCLU_MAL;

            if (EditMode)
            {
                DataRepository.TDI_BIL_BORCLU_MALProvider.DeepLoad(digerMal, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>));
            }
            bndExpertiz.DataSource = digerMal.AV001_TI_BIL_KIYMET_TAKDIRICollection;
        }

        private void bndGayrimenkul_CurrentChanged(object sender, EventArgs e)
        {
            var gayrimenkul = bndGayrimenkul.Current as AV001_TI_BIL_GAYRIMENKUL;
            if (EditMode)
            {
                DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(gayrimenkul, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>), typeof(TList<AV001_TI_BIL_GAYRIMENKUL_TARAF>), typeof(TList<AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDAT>), typeof(TList<AV001_TDI_BIL_SOZLESME_DERECE>));

            }
            bndExpertiz.DataSource = gayrimenkul.AV001_TI_BIL_KIYMET_TAKDIRICollection;
            ucTakyidatGayrimenkul.MyDataSource = gayrimenkul.AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDATCollection;
            ucSozlesmeDerece1.MyDerece = gayrimenkul.AV001_TDI_BIL_SOZLESME_DERECECollection;
            ucSozlesmeDerece1.MyDerece.AddingNew += MyDerece_AddingNew;
        }

        private void dnGayrimenkulBilgileri_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            if (e.Button.Tag.ToString() == "Getir")
            {
                AdimAdimDavaKaydi.Forms.frmListedenGayrimenkulGetir frm = new AdimAdimDavaKaydi.Forms.frmListedenGayrimenkulGetir();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                frm.Show();
            }
        }

        private void frmSozlesmeKayitLayout_Button_Kaydet_Click(object sender, EventArgs e)
        {
            MySozlesme[0].AV001_TDI_BIL_SOZLESME_SORUMLUCollection = SorumluAvk;
            MySozlesme[0].AV001_TDI_BIL_SOZLESME_TARAFCollection = TumTaraflar;
            if (Kaydet(MySozlesme[0]))
            {
                XtraMessageBox.Show("Kaydedildi", "Kayit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Kayıt Esnasında Hata Oluştu." + Environment.NewLine + "Dosya Kaydedilemedi.",
                                    "Kayit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSozlesmeKayitLayout_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MySozlesme == null || EditMode) return;
            if (MyProje == null)
            {
                if (MySozlesme[0].ID > 0)
                {
                    DialogResult ds =
                        XtraMessageBox.Show(
                            MySozlesme[0].SOZLESME_NO + " " + "no'lu dosya takip ekranına gönderilsin mi?", "Kayıt",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (ds == DialogResult.Yes)
                    {
                        frmSozlesmeTakip frm = new frmSozlesmeTakip();

                        frm.ShowDialog(MySozlesme);
                    }
                }
            }
        }

        void frmSozlesmeKayitLayout_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UyapBildirim != null)
                UyapBildirim.CagiranUyap.UyapGozdenGecir(UyapBildirim.IcraDosyalari, UyapBildirim.XmlDosyaYolu, UyapBildirim.geriBildirimYapilsin);
        }

        void lueOzelKod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == "ekle")
            {
                AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle frm = new AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle();
                frm.Show();
                frm.FormClosed += new FormClosedEventHandler(frmOzelKod_FormClosed);
            }
        }

        void frmOzelKod_FormClosed(object sender, FormClosedEventArgs e)
        {
            BindOzelKod();
        }

        private void BindOzelKod()
        {
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod1, 1, AvukatProLib.Extras.Modul.Sozlesme);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod2, 2, AvukatProLib.Extras.Modul.Sozlesme);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod3, 3, AvukatProLib.Extras.Modul.Sozlesme);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod4, 4, AvukatProLib.Extras.Modul.Sozlesme);
        }

        private void frmSozlesmeKayitLayout_Load(object sender, EventArgs e)
        {
            if (MySozlesme == null)
                MySozlesme = new TList<AV001_TDI_BIL_SOZLESME>();

            #region BilirKişi

            BelgeUtil.Inits.CariBilirKisiKoduGetir(lueABilirKisi1);
            BelgeUtil.Inits.CariBilirKisiKoduGetir(lueABilirKisi2);
            BelgeUtil.Inits.CariBilirKisiKoduGetir(lueABilirKisi3);
            BelgeUtil.Inits.CariBilirKisiKoduGetir(lueABilirKisi4);
            BelgeUtil.Inits.CariBilirKisiKoduGetir(lueDBilirKisi1);
            BelgeUtil.Inits.CariBilirKisiKoduGetir(lueDBilirKisi2);
            BelgeUtil.Inits.CariBilirKisiKoduGetir(lueDBilirKisi3);
            BelgeUtil.Inits.CariBilirKisiKoduGetir(lueDBilirKisi4);
            BelgeUtil.Inits.CariBilirKisiKoduGetir(lueBilirkisi1);
            BelgeUtil.Inits.CariBilirKisiKoduGetir(lueBilirkisi2);
            BelgeUtil.Inits.CariBilirKisiKoduGetir(lueBilirkisi3);
            BelgeUtil.Inits.CariBilirKisiKoduGetir(lueBilirkisi4);

            #endregion

            #region Döviz

            BelgeUtil.Inits.DovizTipGetir(lueAHacizliMalBirimDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueAHacizliMalToplamDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueAKıyTakDegerDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueBedeliBrm);
            BelgeUtil.Inits.DovizTipGetir(lueBirimDegerDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueDHacizliMalBirimDegerDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueDHacizliMalToplamDegerDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueDKıyTakDegerDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueDPdegeriDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueExpertizDegerDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueHacizliMalBirimDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueKiyTakDegerDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueNomDegerBrm);
            BelgeUtil.Inits.DovizTipGetir(lueSatirToplamDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueSermayeBrm);
            BelgeUtil.Inits.DovizTipGetir(lueToplamDegerDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueToplamHisseBrm);
            BelgeUtil.Inits.DovizTipGetir(lueYeddiEminUcBrm);
            BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
            BelgeUtil.Inits.DovizTipGetir(lookUpEdit1);
            BelgeUtil.Inits.DovizTipGetir(lookUpEdit2);

            #endregion

            #region geneller
            //Tıklayıp gelecekler için
            lueAdliBirimAdliye.Properties.NullText = "Seç";
            lueAdliBirimGorev.Properties.NullText = "Seç";
            lueAdliBirimNo.Properties.NullText = "Seç";
            lueAItirazSonucu.Properties.NullText = "Seç";
            lueRehinDurum.Properties.NullText = "Seç";
            lueSahibi.Properties.NullText = "Seç";
            lueMudurluk.Properties.NullText = "Seç";
            lueSicilIlce.Properties.NullText = "Seç";
            lueDigerMaBilglAdliBirimNo.Properties.NullText = "Seç";
            lueDSikayetSonucu.Properties.NullText = "Seç";
            lueItirazSonuc.Properties.NullText = "Seç";
            lueHacizliMalAdetBirim.Properties.NullText = "Seç";
            lueAdetBirim.Properties.NullText = "Seç";
            lueDAdetBirim.Properties.NullText = "Seç";
            lueHarcIstisna.Properties.NullText = "Seç";
            lueIl.Properties.NullText = "Seç";
            lueSicilTip.Properties.NullText = "Seç";
            lueSozlesmeAltTip.Properties.NullText = "Seç";
            lueSozlesmeTipi.Properties.NullText = "Seç";
            rLueMuvekkilCari.NullText = "Seç";
            rLueMuvekkilCariKarsi.NullText = "Seç";
            rLueGayrimenkulTaraf.NullText = "Seç";
            grdlueSorumluAvukat.NullText = "Seç";
            //Dolu gelecekler için
            lueAracTip.Properties.NullText = "Seç";
            lueBorclu.Properties.NullText = "Seç";
            lueKartTipi.Properties.NullText = "Seç";
            lueKategori.Properties.NullText = "Seç";
            rLueCari.NullText = "Seç";
            rlueMuvekkilKarsiTarafAvukat.NullText = "Seç";
            rLueMuvekkilSifatK.NullText = "Seç";
            rLueMuvekkilSifat.NullText = "Seç";
            rLueMuvekkilTK.NullText = "Seç";
            rLueMuvekkilTKKarsi.NullText = "Seç";
            rLueSifat.NullText = "Seç";

            lueAdliBirimAdliye.Enter += BelgeUtil.Inits.AdliBirimAdliyeGetir_Enter;
            lueAdliBirimGorev.Enter += BelgeUtil.Inits.AdliBirimGorevGetir_Enter;
            lueAdliBirimNo.Enter += BelgeUtil.Inits.AdliBirimNoGetir_Enter;

            BindOzelKod();
            lueOzelKod1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            lueOzelKod2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            lueOzelKod3.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            lueOzelKod4.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);

            lueAItirazSonucu.Enter += BelgeUtil.Inits.ItirazSonucuGetir_Enter;
            lueRehinDurum.Enter += BelgeUtil.Inits.RehinDurumGetir_Enter;
            BelgeUtil.Inits.AracTipGetir(lueAracTip.Properties);
            lueSahibi.Enter += BelgeUtil.Inits.perCariGetir_Enter;
            //Inits.BelediyeGetirTumu(lueBelediye.Properties);
            lueMudurluk.Enter += BelgeUtil.Inits.AdliBirimAdliyeGetir_Enter;
            lueSicilIlce.Properties.Enter += delegate { BelgeUtil.Inits.llceGetirIlle(lueSicilIlce.Properties); };
            BelgeUtil.Inits.perCariGetir(lueBorclu.Properties);
            //Inits.MalcinsGetir(lueCins);
            lueDigerMaBilglAdliBirimNo.Enter += BelgeUtil.Inits.AdliBirimNoGetir_Enter;
            lueDSikayetSonucu.Enter += BelgeUtil.Inits.ItirazSonucuGetir_Enter;
            lueItirazSonuc.Enter += BelgeUtil.Inits.ItirazSonucuGetir_Enter;
            //Inits.TapuMudurlukGetir(lueGayrimenkulMudurluk.Properties);
            BelgeUtil.Inits.BirimKodGetir(lookUpEdit3);
            BelgeUtil.Inits.BirimKodGetir(lueHacizliMalAdetBirim);
            BelgeUtil.Inits.BirimKodGetir(lueAdetBirim);
            BelgeUtil.Inits.BirimKodGetir(lueDAdetBirim);
            BelgeUtil.Inits.BankaKartTipiGetir(lueKartTipi);
            BelgeUtil.Inits.MalKategoriGetir(lueKategori.Properties);
            lueHarcIstisna.Enter += BelgeUtil.Inits.HarcIstisnaGetir_Enter;
            lueIl.Enter += BelgeUtil.Inits.IlGetir_Enter;
            //Inits.IlceGetirTumu(lueIlcesi);
            BelgeUtil.Inits.SicilTipGetir(lueSicilTip);//MB-Klasörden gelmediğinde enter'la açılmalı
            lueSozlesmeAltTip.Enter += BelgeUtil.Inits.SozlesmeAltTipiHepsiGetir_Enter;
            BelgeUtil.Inits.SozlesmeTipiGetir(lueSozlesmeTipi);//MB
            //Inits.MalTurGetir(lueTur);
            BelgeUtil.Inits.perCariGetir(rLueCari);
            BelgeUtil.Inits.perCariGetir(rLueMuvekkilCari);//MB
            BelgeUtil.Inits.perCariGetir(rLueMuvekkilCariKarsi); //MB
            BelgeUtil.Inits.perCariGetir(rLueGayrimenkulTaraf);
            //rLueGayrimenkulTaraf.Enter += delegate { BelgeUtil.Inits.perCariGetir(rLueGayrimenkulTaraf); };
            BelgeUtil.Inits.perSorumluAvukatGetir(rlueMuvekkilKarsiTarafAvukat);
            BelgeUtil.Inits.SozlesmeTarafSifatGetir(rLueMuvekkilSifat);
            BelgeUtil.Inits.SozlesmeTarafSifatGetir(rLueMuvekkilSifatK);
            BelgeUtil.Inits.TarafKoduGetir(rLueMuvekkilTK);
            BelgeUtil.Inits.TarafKoduGetir(rLueMuvekkilTKKarsi);
            BelgeUtil.Inits.GayriMenkulTarafSifatGetir(rLueSifat);

            #endregion

            #region <MB-20100506> Para Biçimi Ayarla
            //Dolu Gelenler için
            spBedel.Properties.NullText = "Seç";
            rspMiktar.NullText = "Seç";
            spAHacizliMalBirim.Properties.NullText = "Seç";
            spAHacizliMalToplam.Properties.NullText = "Seç";
            spAKıyTakDeger.Properties.NullText = "Seç";
            spAracBirimDeger.Properties.NullText = "Seç";
            spAracKiyTakDeger.Properties.NullText = "Seç";
            spAracToplamDeger.Properties.NullText = "Seç";
            spBirimDeger.Properties.NullText = "Seç";
            spDHacizliMalBirimDeger.Properties.NullText = "Seç";
            spDHacizliMalToplamDeger.Properties.NullText = "Seç";
            spDKiyTakDegeri.Properties.NullText = "Seç";
            spDPDeger.Properties.NullText = "Seç";
            spExpertizDeger.Properties.NullText = "Seç";
            spHacizliMalBirim.Properties.NullText = "Seç";
            spNominalDeger.Properties.NullText = "Seç";
            spSermaye.Properties.NullText = "Seç";
            spToplam.Properties.NullText = "Seç";
            spToplamDeger.Properties.NullText = "Seç";
            spYedEmUcrt.Properties.NullText = "Seç";
            spToplamHisse.Properties.NullText = "Seç";
            BelgeUtil.Inits.ParaBicimiAyarla(spBedel);
            BelgeUtil.Inits.ParaBicimiAyarla(rspMiktar);
            BelgeUtil.Inits.ParaBicimiAyarla(spAHacizliMalBirim);
            BelgeUtil.Inits.ParaBicimiAyarla(spAHacizliMalToplam);
            BelgeUtil.Inits.ParaBicimiAyarla(spAKıyTakDeger);
            BelgeUtil.Inits.ParaBicimiAyarla(spAracBirimDeger);
            BelgeUtil.Inits.ParaBicimiAyarla(spAracKiyTakDeger);
            BelgeUtil.Inits.ParaBicimiAyarla(spAracToplamDeger);
            BelgeUtil.Inits.ParaBicimiAyarla(spBirimDeger);
            BelgeUtil.Inits.ParaBicimiAyarla(spDHacizliMalBirimDeger);
            BelgeUtil.Inits.ParaBicimiAyarla(spDHacizliMalToplamDeger);
            BelgeUtil.Inits.ParaBicimiAyarla(spDKiyTakDegeri);
            BelgeUtil.Inits.ParaBicimiAyarla(spDPDeger);
            BelgeUtil.Inits.ParaBicimiAyarla(spExpertizDeger);
            BelgeUtil.Inits.ParaBicimiAyarla(spHacizliMalBirim);
            BelgeUtil.Inits.ParaBicimiAyarla(spKiyTakDeger);
            BelgeUtil.Inits.ParaBicimiAyarla(spNominalDeger);
            BelgeUtil.Inits.ParaBicimiAyarla(spSermaye);
            BelgeUtil.Inits.ParaBicimiAyarla(spToplam);
            BelgeUtil.Inits.ParaBicimiAyarla(spToplamDeger);
            BelgeUtil.Inits.ParaBicimiAyarla(spYedEmUcrt);
            BelgeUtil.Inits.ParaBicimiAyarla(spToplamHisse);

            #endregion

            BelgeUtil.Inits.AktifAvukatlariGetir(grdlueSorumluAvukat); //MB

            #region Klasörden Yeni Sözleşme Dosyası

            if (MyProje != null)
            {
                //Eğer projenin tarafları henüz yüklenmediyse yükleyelim.
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

                #region <MB-20101228>
                //Sözleşme taraflarına sadece borçluların gelmesini sağlamak için eklendi.
                //Proje taraflarında Taraf Sıfat ayrımı olmadığından bu şekilde yapıldı.

                if (MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                if (MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN[0], false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
                var projeBorcluList = MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.FindAll(vi => vi.TARAF_SIFAT_ID == (int)TarafSifat.BORCLU);

                #endregion

                foreach (AV001_TDIE_BIL_PROJE_TARAF trf in MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection)
                {
                    if (trf.CARI_IDSource != null)
                    {
                        if (trf.CARI_IDSource.MUVEKKIL_MI)
                        {
                            AV001_TDI_BIL_SOZLESME_TARAF sozlesmeTaraf = Muvekkil.AddNew();
                            sozlesmeTaraf.CARI_ID = trf.CARI_ID;
                            sozlesmeTaraf.TARAF_SIFAT_ID = (int)SozlesmeTarafTip.SozlesmeYapan;
                            sozlesmeTaraf.TARAF_KODU = (short)TarafKodu.Muvekkil;
                        }
                        else
                        {
                            if (projeBorcluList.Find(vi => vi.TARAF_CARI_ID == trf.CARI_ID) == null) continue;//Sözleşme taraflarına sadece borçluların gelmesini sağlamak için eklendi.
                            AV001_TDI_BIL_SOZLESME_TARAF sozlesmeTaraf = MuvekkilKarsi.AddNew();
                            sozlesmeTaraf.CARI_ID = trf.CARI_ID;
                            sozlesmeTaraf.TARAF_SIFAT_ID = (int)SozlesmeTarafTip.SOZLESME_TARAFI;
                            sozlesmeTaraf.TARAF_KODU = (short)TarafKodu.KarsiTaraf;
                        }
                    }
                }
                foreach (AV001_TDIE_BIL_PROJE_SORUMLU sorumlu in MyProje.AV001_TDIE_BIL_PROJE_SORUMLUCollection)
                {
                    AV001_TDI_BIL_SOZLESME_SORUMLU szSorumlu = SorumluAvk.AddNew();
                    szSorumlu.SORUMLU_CARI_ID = sorumlu.CARI_ID;
                    if (sorumlu.YETKILI_MI == true)
                        szSorumlu.YETKILI_MI = true;
                    if (szSorumlu.SORUMLU_CARI_ID == 0)
                    {
                        SorumluAvk.Remove(szSorumlu);
                    }
                }
            }

            #endregion

            #region Görünüm Ayarları

            if (MySozlesme[0].TIP_ID == 1)
            {
                layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\Kira\\sozlesmeGenelAyar.xml");
                layoutControl2.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\Kira\\sozlesmeKiraGenelBilgiler.xml");
                layoutControl3.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\Kira\\sözlesmeTarafBilgileri.xml");
            }
            if (MySozlesme[0].TIP_ID == 2)
            {
                if (MySozlesme[0].ALT_TIP_ID != 4 && MySozlesme[0].ALT_TIP_ID != 115 && MySozlesme[0].ALT_TIP_ID != 116)
                {
                    layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\Kredi\\sozlesmeGenelAyar.xml");
                    layoutControl2.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\Kredi\\sozlesmegenelBilgiler.xml");
                    layoutControl3.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\Kredi\\sözlesmeTarafBilgileri.xml");
                }
                else
                {
                    layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\KrediKartı\\sozlesmeGenelAyar.xml");
                    layoutControl2.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\KrediKartı\\sozlesmeGenelBilgiler.xml");
                    layoutControl3.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\KrediKartı\\sözlesmeTarafBilgileri.xml");
                }
            }
            if (MySozlesme[0].TIP_ID == 6)
            {
                layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\MarkaPatent\\sozlesmeGenelAyar.xml");
                layoutControl2.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\MarkaPatent\\sozlesmegenelBilgiler.xml");
                layoutControl3.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\MarkaPatent\\sözlesmeTarafBilgileri.xml");
            }
            if (MySozlesme[0].TIP_ID == 5)
            {
                layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\Hakem\\sozlesmeGenelAyar.xml");
                layoutControl2.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\Hakem\\sozlesmegenelBilgiler.xml");
                //layoutControl3.RestoreLayoutFromXml(Application.StartupPath +"SozlesmeXmler\\Hakem\\sözlesmeTarafBilgileri.xml");
            }
            if (MySozlesme[0].TIP_ID == 3)
            {
                if (MySozlesme[0].ALT_TIP_ID == 5)
                {
                    var custombutton = dnGayrimenkulBilgileri.Buttons.CustomButtons.Add();
                    custombutton.Tag = "Getir";
                    custombutton.ImageIndex = 0;

                    layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\GayrimenkulIpotegi\\sozlesmeGenelAyar.xml");
                    layoutControl2.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\GayrimenkulIpotegi\\resmisenetgenelbilgiler.xml");
                    layoutControl3.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\GayrimenkulIpotegi\\sözlesmeTarafBilgileri.xml");
                    layoutControl6.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\GayrimenkulIpotegi\\sozlesmeDetayGayrimenkul.xml");

                    MySozlesme[0].SICIL_TIP_ID = 2;
                }
            }
            if (MySozlesme[0].TIP_ID == 3)
            {
                if (MySozlesme[0].ALT_TIP_ID == 8 || MySozlesme[0].ALT_TIP_ID == (int)SozlesmeAltTip.Hava_Araci_Ipotegi ||
                    MySozlesme[0].ALT_TIP_ID == (int)SozlesmeAltTip.Gemi_Ipotegi)
                //|| MySozlesme[0].ALT_TIP_ID == 7 || MySozlesme[0].ALT_TIP_ID == 8)
                {
                    layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\AracRehni\\sozlesmeGenelAyar.xml");
                    layoutControl2.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\AracRehni\\resmisenetgenelbilgiler.xml");
                    layoutControl3.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\AracRehni\\sözlesmeTarafBilgileri.xml");
                    layoutControl6.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\AracRehni\\sozlesmeDetayArac.xml");

                    if (MySozlesme[0].ALT_TIP_ID == (int)SozlesmeAltTip.Hava_Araci_Ipotegi)
                        MySozlesme[0].SICIL_TIP_ID = 5; //Uçak Sicil
                    else if (MySozlesme[0].ALT_TIP_ID == (int)SozlesmeAltTip.Gemi_Ipotegi)
                        MySozlesme[0].SICIL_TIP_ID = 4; //Gemi Normal
                    else if (MySozlesme[0].ALT_TIP_ID == 8)
                        MySozlesme[0].SICIL_TIP_ID = 6; //Trafik Sicil
                }
            }
            //if (MySozlesme[0].TIP_ID == 3)
            //{
            //    if (MySozlesme[0].ALT_TIP_ID == 7 || MySozlesme[0].ALT_TIP_ID == 6)
            //    {
            //        layoutControl1.RestoreLayoutFromXml(Application.StartupPath +"SozlesmeXmler\GemiIpotegi\sozlesmeGenelAyar.xml");
            //        layoutControl2.RestoreLayoutFromXml(Application.StartupPath +"SozlesmeXmler\GemiIpotegi\resmisenetgenelbilgiler.xml");
            //        layoutControl3.RestoreLayoutFromXml(Application.StartupPath +"SozlesmeXmler\GemiIpotegi\sözlesmeTarafBilgileri.xml");
            //        layoutControl6.RestoreLayoutFromXml(Application.StartupPath +"SozlesmeXmler\GemiIpotegi\sozlesmeDetayAracBilgileri.xml");
            //    }
            //}
            if (MySozlesme[0].TIP_ID == 3)
            {
                if (MySozlesme[0].ALT_TIP_ID == 9)
                {
                    layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\TicariIsletmeRehni\\sozlesmeGenelAyar.xml");
                    layoutControl2.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\TicariIsletmeRehni\\resmisenetgenelbilgiler.xml");
                    layoutControl3.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\TicariIsletmeRehni\\sözlesmeTarafBilgileri.xml");
                    layoutControl6.RestoreLayoutFromXml(
                        @"SozlesmeXmler\\TicariIsletmeRehni\\sozlesmeDetayMalBilgileri.xml");
                    MySozlesme[0].SICIL_TIP_ID = 1; //Ticaret Sicil
                }
            }
            if (MySozlesme[0].TIP_ID == 3)
            {
                if (MySozlesme[0].ALT_TIP_ID == 10)
                {
                    layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\MenkulMalRehni\\sozlesmeGenelAyar.xml");
                    layoutControl2.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\MenkulMalRehni\\resmisenetgenelbilgiler.xml");
                    layoutControl3.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\MenkulMalRehni\\sözlesmeTarafBilgileri.xml");
                    layoutControl6.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\MenkulMalRehni\\sozlesmeDetayMalBilgileri.xml");
                }
            }
            if (MySozlesme[0].TIP_ID == 3)
            {
                if (MySozlesme[0].ALT_TIP_ID == 11)
                {
                    layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\MenkulKıymetRehni\\sozlesmeGenelAyar.xml");
                    layoutControl2.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\MenkulKıymetRehni\\resmisenetgenelbilgiler.xml");
                    layoutControl3.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\MenkulKıymetRehni\\sözlesmeTarafBilgileri.xml");
                    layoutControl6.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\MenkulKıymetRehni\\sozlesmeDetayMalBilgileri.xml");
                }
            }
            if (MySozlesme[0].TIP_ID == 3)
            {
                if (MySozlesme[0].ALT_TIP_ID == 12)
                {
                    layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\MevduatRehni\\sozlesmeGenelAyar.xml");
                    layoutControl2.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\MevduatRehni\\resmisenetgenelbilgiler.xml");
                    layoutControl3.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\MevduatRehni\\sözlesmeTarafBilgileri.xml");
                }
            }
            if (MySozlesme[0].TIP_ID == 3)
            {
                if (MySozlesme[0].ALT_TIP_ID == 13)
                {
                    layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\TicariSenetRehni\\sozlesmeGenelAyar.xml");
                    layoutControl2.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\TicariSenetRehni\\resmisenetgenelbilgiler.xml");
                    layoutControl3.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\TicariSenetRehni\\sözlesmeTarafBilgileri.xml");
                    layoutControl6.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\TicariSenetRehni\\sozlesmeDetayMalBilgileri.xml");
                }
            }
            if (MySozlesme[0].TIP_ID == 3)
            {
                if (MySozlesme[0].ALT_TIP_ID == 172)
                {
                    layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\HatRehni\\sozlesmeGenelAyar.xml");
                    layoutControl2.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\HatRehni\\resmisenetgenelbilgiler.xml");
                    layoutControl3.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\HatRehni\\sözlesmeTarafBilgileri.xml");
                }
            }
            if (MySozlesme[0].TIP_ID == 3)
            {
                if (MySozlesme[0].ALT_TIP_ID == 173)
                {
                    layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\MarkaRehni\\sozlesmeGenelAyar.xml");
                    layoutControl2.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\MarkaRehni\\resmisenetgenelbilgiler.xml");
                    layoutControl3.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\MarkaRehni\\sözlesmeTarafBilgileri.xml");
                }
            }
            if (MySozlesme[0].TIP_ID == 3)
            {
                if (MySozlesme[0].ALT_TIP_ID == 174)
                {
                    layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\TicariPlakaRehni\\sozlesmeGenelAyar.xml");
                    layoutControl2.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\TicariPlakaRehni\\resmisenetgenelbilgiler.xml");
                    layoutControl3.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\TicariPlakaRehni\\sözlesmeTarafBilgileri.xml");
                    layoutControl6.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\TicariPlakaRehni\\sozlesmeDetayAracBilgileri.xml");
                    MySozlesme[0].SICIL_TIP_ID = 6; //Trafik Sicil
                }
            }
            if (MySozlesme[0].TIP_ID == 3)
            {
                if (MySozlesme[0].ALT_TIP_ID == 175)
                {
                    layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\HisseSenediRehni\\sozlesmeGenelAyar.xml");
                    layoutControl2.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\HisseSenediRehni\\resmisenetgenelbilgiler.xml");
                    layoutControl3.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\HisseSenediRehni\\sözlesmeTarafBilgileri.xml");
                    layoutControl6.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\HisseSenediRehni\\sozlesmeDetayMalBilgileri.xml");
                }
            }
            if (MySozlesme[0].TIP_ID == 3)
            {
                if (MySozlesme[0].ALT_TIP_ID == 176)
                {
                    layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\KanbiyoSenediRehni\\sozlesmeGenelAyar.xml");
                    layoutControl2.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\KanbiyoSenediRehni\\resmisenetgenelbilgiler.xml");
                    layoutControl3.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\KanbiyoSenediRehni\\sözlesmeTarafBilgileri.xml");
                    layoutControl6.RestoreLayoutFromXml(Application.StartupPath +
                        "\\SozlesmeXmler\\KanbiyoSenediRehni\\sozlesmeDetayMalBilgileri.xml");
                }
            }
            if (MySozlesme[0].TIP_ID == 4)
            {
                if (MySozlesme[0].ALT_TIP_ID == 86)
                {
                    layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\Hisse_Rehni_Sozlesmesi\\sozlesmeGenelAyar.xml");
                    layoutControl2.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\Hisse_Rehni_Sozlesmesi\\resmisenetgenelbilgiler.xml");
                    layoutControl3.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\Hisse_Rehni_Sozlesmesi\\sözlesmeTarafBilgileri.xml");
                }
            }

            #endregion

            if (!EditMode)
            {
                panelControl22.Enabled = false;//İlk Açılışta + butonuna basmadan gayrimenkul detaylarının disable gelmesi için eklendi. MB
                panelControl15.Enabled = false;
                layoutControlGroup68.Enabled = false;
                layoutControlGroup13.Enabled = false;
                panelControl17.Enabled = false;
                panelControl19.Enabled = false;
            }
            layoutControlGroup27.Text = "Maliki";//Gayrimenkul tarafları page'i texti XML'den yapılamadığından bu şekilde değiştirildi. MB
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SelectedGayrimenkulList != null)
            {
                bndGayrimenkul.DataSource = SelectedGayrimenkulList;
                dnGayrimenkulBilgileri.DataSource = bndGayrimenkul;

                panelControl22.Enabled = true;//İlk Açılışta + butonuna basmadan gayrimenkul detaylarının disable gelmesi için eklendi. MB
                layoutControlGroup68.Enabled = true;
                layoutControlGroup13.Enabled = true;
                panelControl15.Enabled = true;
                panelControl17.Enabled = true;
                panelControl19.Enabled = true;
                layoutControlGroup27.Text = "Maliki";//Gayrimenkul tarafları page'i texti XML'den yapılamadığından bu şekilde değiştirildi. MB
                BelgeUtil.Inits.perCariGetir(rLueGayrimenkulTaraf);
                BelgeUtil.Inits.IlGetir(lueIl);

                DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(SelectedGayrimenkulList, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_GAYRIMENKUL_TARAF>));

                SelectedGayrimenkulList.ForEach(gayrimenkul =>
                    {
                        if (MySozlesme != null && MySozlesme.Count > 0)
                            MySozlesme[0].AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.Add(gayrimenkul);

                        gayrimenkul.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                        gayrimenkul.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                        gayrimenkul.KAYIT_TARIHI = DateTime.Now;
                        gayrimenkul.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                        gayrimenkul.KONTROL_NE_ZAMAN = DateTime.Now;
                        gayrimenkul.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                        gcGayrimenkulTaraflar.DataSource = gayrimenkul.AV001_TI_BIL_GAYRIMENKUL_TARAFCollection;
                        ucTakyidatGayrimenkul.MyDataSource = gayrimenkul.AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDATCollection;
                        if (gayrimenkul.AV001_TDI_BIL_SOZLESME_DERECECollection == null)
                            gayrimenkul.AV001_TDI_BIL_SOZLESME_DERECECollection = new TList<AV001_TDI_BIL_SOZLESME_DERECE>();
                        ucSozlesmeDerece1.MyDerece = gayrimenkul.AV001_TDI_BIL_SOZLESME_DERECECollection;
                        ucSozlesmeDerece1.MyDerece.AddingNew += MyDerece_AddingNew;
                        bndExpertiz.DataSource = gayrimenkul.AV001_TI_BIL_KIYMET_TAKDIRICollection;
                        dnGayrimenkulExpertiz.DataSource = gayrimenkul.AV001_TI_BIL_KIYMET_TAKDIRICollection;
                    });
            }
        }

        void gwSozlesmeKarsiTarafi_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            #region <MB-20101012>
            //Taraf koduna göre cari bilgisinin dolmasını sağlamak için eklendi.
            if (e.Column.Caption != "Taraf Kodu") return;

            BelgeUtil.Inits.TarafKodunaGoreCariGetir(rLueMuvekkilCariKarsi, Convert.ToByte(e.Value));
            #endregion
        }

        private void gwSozlesmeKarsiTarafi_ValidateRow(object sender,
            DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TDI_BIL_SOZLESME_TARAF sozlemeT = (AV001_TDI_BIL_SOZLESME_TARAF)e.Row;
            if (!sozlemeT.CARI_ID.HasValue)
            {
                e.ErrorText = "Bir Müvekkil Karşı  Taraf Seçilmelidir" + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (!sozlemeT.TARAF_SIFAT_ID.HasValue)
            {
                e.ErrorText = "Bir Müvekkil Karşı Taraf Sıfat Seçilmelidir" + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (sozlemeT.TARAF_KODU == 0)
            {
                e.ErrorText = "Bir Müvekkil Karşı Taraf Kodu Seçilmelidir" + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (MuvekkilKarsi != null)
            {
                if (MuvekkilKarsi.FindAll("CARI_ID", sozlemeT.CARI_ID).Count > 1)
                {
                    e.ErrorText = "Bu Muvekkil Karşı Taraf Zaten Eklenmiş" + Environment.NewLine;
                    e.Valid = false;
                    return;
                }
                if (Muvekkil.FindAll("CARI_ID", sozlemeT.CARI_ID).Count > 0)
                {
                    e.ErrorText = "Bu Şahış Muvekkil Olarak Zaten Eklenmiş" + Environment.NewLine;
                    e.Valid = false;
                    return;
                }
            }
            TDI_KOD_TARAF trfkod = ((TList<TDI_KOD_TARAF>)rLueMuvekkilTKKarsi.DataSource).Find("ID",
                                                                                                (int)
                                                                                                sozlemeT.TARAF_KODU);

            #region <MB-20101901> Muvekkil Karsi vekil bilgileri

            foreach (var item in MuvekkilKarsi)
            {
                if (
                    item.AV001_TDI_BIL_SOZLESME_TARAF_VEKILCollection.Exists(
                        delegate(AV001_TDI_BIL_SOZLESME_TARAF_VEKIL sozlesmeVekil) { return sozlesmeVekil.SOZLESME_TARAF_CARI_ID == item.CARI_ID; })) continue;

                item.AV001_TDI_BIL_SOZLESME_TARAF_VEKILCollection.AddRange(
                    DataRepository.AV001_TDI_BIL_SOZLESME_TARAF_VEKILProvider.GetBySOZLESME_TARAF_CARI_ID(item.CARI_ID));
            }

            #endregion
        }

        void gwSozlesmeMuvekkilT_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            #region <MB-20101012>
            //Taraf koduna göre cari bilgisinin dolmasını sağlamak için eklendi.
            if (e.Column.Caption != "Taraf Kodu") return;

            BelgeUtil.Inits.TarafKodunaGoreCariGetir(rLueMuvekkilCari, Convert.ToByte(e.Value));
            #endregion
        }

        private void gwSozlesmeMuvekkilT_CustomRowCellEdit(object sender,
            DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.RepositoryItem is RepositoryItemLookUpEdit && Muvekkil != null)
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
                    if (e.RepositoryItem.Name == "rLueMuvekkilCari")
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

        private void gwSozlesmeMuvekkilT_ValidateRow(object sender,
            DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TDI_BIL_SOZLESME_TARAF sozlemeT = (AV001_TDI_BIL_SOZLESME_TARAF)e.Row;
            if (!sozlemeT.CARI_ID.HasValue)
            {
                e.ErrorText = "Bir Müvekkil Tarafı Seçilmelidir" + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (!sozlemeT.TARAF_SIFAT_ID.HasValue)
            {
                e.ErrorText = "Bir Müvekkil Taraf Sıfat Seçilmelidir" + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (sozlemeT.TARAF_KODU == 0)
            {
                e.ErrorText = "Bir Müvekkil Taraf kodu Seçilmelidir" + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (Muvekkil != null)
            {
                if (Muvekkil.FindAll("CARI_ID", sozlemeT.CARI_ID).Count > 1)
                {
                    e.ErrorText = "Bu Muvekkil Zaten Eklenmiş" + Environment.NewLine;
                    e.Valid = false;
                    return;
                }
                if (MuvekkilKarsi.FindAll("CARI_ID", sozlemeT.CARI_ID).Count > 0)
                {
                    e.ErrorText = "Bu Sahış Muvekkil Karşı Taraf Olarak Zaten Eklenmiş." + Environment.NewLine;
                    e.Valid = false;
                    return;
                }
            }
            TDI_KOD_TARAF trfkod = ((TList<TDI_KOD_TARAF>)rLueMuvekkilTK.DataSource).Find("ID",
                                                                                           (int)sozlemeT.TARAF_KODU);

            #region <MB-20101901> Muvekkil vekil bilgileri

            foreach (var item in Muvekkil)
            {
                if (
                    item.AV001_TDI_BIL_SOZLESME_TARAF_VEKILCollection.Exists(
                        delegate(AV001_TDI_BIL_SOZLESME_TARAF_VEKIL sozlesmeVekil) { return sozlesmeVekil.SOZLESME_TARAF_CARI_ID == item.CARI_ID; })) continue;

                item.AV001_TDI_BIL_SOZLESME_TARAF_VEKILCollection.AddRange(
                    DataRepository.AV001_TDI_BIL_SOZLESME_TARAF_VEKILProvider.GetBySOZLESME_TARAF_CARI_ID(item.CARI_ID));
            }

            #endregion
        }

        private void gwSozlesmeSorumlusu_ValidateRow(object sender,
            DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TDI_BIL_SOZLESME_SORUMLU rowAvukat = (AV001_TDI_BIL_SOZLESME_SORUMLU)e.Row;
            if (!rowAvukat.SORUMLU_CARI_ID.HasValue && rowAvukat.SORUMLU_CARI_IDSource == null)
            {
                e.ErrorText = "Lütfen Bir Sorumlu Seçiniz." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (SorumluAvk.FindAll("SORUMLU_CARI_IDSource", rowAvukat.SORUMLU_CARI_IDSource).Count > 1)
            {
                e.ErrorText = "Bu Sorumlu Zaten Eklenmiş." + Environment.NewLine;
                e.Valid = false;
                return;
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmSozlesmeKayitLayout_Button_Kaydet_Click;
        }

        private bool Kaydet(AV001_TDI_BIL_SOZLESME sozlesme)
        {
            //CARI_ID alanı seçilmeyince 0 geldiğinde 0 ID'li cari olmayan datalarda sorun yarattığından bu kontrol eklendi. MB
            foreach (var item in sozlesme.TDI_BIL_BORCLU_MALCollection)
            {
                if (item.CARI_ID == null || item.CARI_ID == 0)
                {
                    XtraMessageBox.Show("Diğer Mal Bilgilerinde 'Borçlu' \r\nbilgisi girilmeden kayıt işlemi yapılamaz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }

            bool b = false;
            try
            {
                if (sozlesme.IsNew)
                {
                    sozlesme.KAYIT_TARIHI = DateTime.Now;
                    sozlesme.KONTROL_NE_ZAMAN = DateTime.Now;
                    sozlesme.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    sozlesme.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    sozlesme.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;

                    //Dosyada en az bir tane sorumlu olması gerektiğinden, tek avukat olan dosyalarda kullanıcı izleyen mi alanını işaretlediğinde bu alanın false olması sağlanıyor. MB
                    if (sozlesme.AV001_TDI_BIL_SOZLESME_SORUMLUCollection.Count == 1 && sozlesme.AV001_TDI_BIL_SOZLESME_SORUMLUCollection.FindAll(vi => !vi.YETKILI_MI).Count == 0)
                        sozlesme.AV001_TDI_BIL_SOZLESME_SORUMLUCollection[0].YETKILI_MI = false;

                    sozlesme.SUBE_KOD_ID = AdimAdimDavaKaydi.Forms.frmKlasorYeni.KullaniciSubeIDGetir(sozlesme.AV001_TDI_BIL_SOZLESME_SORUMLUCollection.Find(vi => !vi.YETKILI_MI).SORUMLU_CARI_ID.Value);
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(typeof(frmSozlesmeKayit), ex);
            }
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                trans.BeginTransaction();

                #region <MB-20100621>

                //Dosya kaydı sırasında SOZLESME_NO bilgisinin unique olmasını sağlamak için tekrardan kontrol eklendi.
                if (
                    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.Find(string.Format("SOZLESME_NO = {0}",
                                                                                     sozlesme.SOZLESME_NO)).Count > 0)
                    sozlesme.SOZLESME_NO = SozlesmeNoGetir();

                #endregion

                //Düzenleme kaydında, ilk kaydette yapılan değişiklikler algılanmayıp ilk hali kaydedildiğinden kayıt işleminden önce object temp bir objecte atıldı. Kayıttan sonra temp object asıl objecte verilip tekrar kayıt yaptırıldı. Sözleşme kaydı ilk açılıp düzenleme dediğimizde yapılan değişikliklerin algılanması için bu şekilde yapıldı. (Taraf, takyidat, derece vb. alanlar için. MB
                if (EditMode)
                {
                    AV001_TDI_BIL_SOZLESME tempSozlesme = sozlesme.Copy();
                    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepSave(trans, sozlesme, DeepSaveType.ExcludeChildren, typeof(TList<TDI_BIL_BORCLU_MAL>));
                    sozlesme = tempSozlesme;
                    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepSave(trans, sozlesme, DeepSaveType.ExcludeChildren, typeof(TList<TDI_BIL_BORCLU_MAL>));
                }
                else
                    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepSave(trans, sozlesme, DeepSaveType.ExcludeChildren, typeof(TList<TDI_BIL_BORCLU_MAL>)); //Sözleşme kaydında TDI_BIL_BORCLU_MALCollection sözleşme ID den sorun çıkardığından exclude edilip aşağıdaki gibi sonradan kaydedildi. MB
                foreach (var item in sozlesme.TDI_BIL_BORCLU_MALCollection)
                {
                    item.SOZLESME_ID = sozlesme.ID;
                }
                DataRepository.TDI_BIL_BORCLU_MALProvider.DeepSave(trans, sozlesme.TDI_BIL_BORCLU_MALCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>)); //MB

                DataRepository.AV001_TDI_BIL_SOZLESME_TARAFProvider.DeepSave(trans,
                                                                             sozlesme.
                                                                                 AV001_TDI_BIL_SOZLESME_TARAFCollection);
                foreach (var item in Muvekkil)
                {
                    #region Müvekkil

                    foreach (var trfVekil in item.AV001_TDI_BIL_SOZLESME_TARAF_VEKILCollection)
                    {
                        if (trfVekil.SOZLESME_TARAF_ID == null && trfVekil.SOZLESME_TARAF_ID == 0
                            || trfVekil.SOZLESME_TARAF_IDSource == null)
                        {
                            trfVekil.SOZLESME_TARAF_CARI_ID = item.CARI_ID;
                            trfVekil.SOZLESME_TARAF_ID = item.ID;
                        }
                    }

                    #endregion

                    DataRepository.AV001_TDI_BIL_SOZLESME_TARAF_VEKILProvider.Save(trans,
                                                                                   item.
                                                                                       AV001_TDI_BIL_SOZLESME_TARAF_VEKILCollection);
                }

                foreach (var item in MuvekkilKarsi)
                {
                    #region Muvekkil Karsi

                    foreach (var trfVekil in item.AV001_TDI_BIL_SOZLESME_TARAF_VEKILCollection)
                    {
                        if (trfVekil.SOZLESME_TARAF_ID == null && trfVekil.SOZLESME_TARAF_ID == 0
                            || trfVekil.SOZLESME_TARAF_IDSource == null)
                        {
                            trfVekil.SOZLESME_TARAF_CARI_ID = item.CARI_ID;
                            trfVekil.SOZLESME_TARAF_ID = item.ID;
                        }
                    }

                    #endregion

                    DataRepository.AV001_TDI_BIL_SOZLESME_TARAF_VEKILProvider.Save(trans,
                                                                                   item.
                                                                                       AV001_TDI_BIL_SOZLESME_TARAF_VEKILCollection);
                }

                DataRepository.AV001_TDI_BIL_SOZLESME_SORUMLUProvider.DeepSave(trans,
                                                                               sozlesme.
                                                                                   AV001_TDI_BIL_SOZLESME_SORUMLUCollection);
                DataRepository.AV001_TDI_BIL_SOZLESME_HAKEMLERIProvider.DeepSave(trans,
                                                                                 sozlesme.
                                                                                     AV001_TDI_BIL_SOZLESME_HAKEMLERICollection);
                //ARAÇ
                sozlesme.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SOZLESME_GEMI_UCAK_ARAC.ForEach(
                    delegate(AV001_TDI_BIL_GEMI_UCAK_ARAC obj)
                    {
                        if (sozlesme.NN_SOZLESME_GEMI_UCAK_ARACCollection.Count == 0)
                            DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(sozlesme, false, DeepLoadType.IncludeChildren, typeof(TList<NN_SOZLESME_GEMI_UCAK_ARAC>));
                        if (
                            sozlesme.NN_SOZLESME_GEMI_UCAK_ARACCollection.FindAll(
                                NN_SOZLESME_GEMI_UCAK_ARACColumn.GEMI_UCAK_ARAC_ID, obj.ID).Count == 0)
                        {
                            NN_SOZLESME_GEMI_UCAK_ARAC gua = sozlesme.NN_SOZLESME_GEMI_UCAK_ARACCollection.AddNew();

                            gua.GEMI_UCAK_ARAC_IDSource = obj;
                        }
                    });
                if (MyNNKayitSozlesme > 0)
                {
                    sozlesme.
                        AV001_TDI_BIL_SOZLESMECollection_From_NN_SOZLESME_SOZLESMESOZLESME_IDFromNN_SOZLESME_SOZLESME.
                        Exists(delegate(AV001_TDI_BIL_SOZLESME obj) { return sozlesme.ID == obj.ID; });

                    NN_SOZLESME_SOZLESME Ssozlesme = new NN_SOZLESME_SOZLESME();
                    Ssozlesme.SOZLESME_ALT_ID = sozlesme.ID;
                    Ssozlesme.SOZLESME_ID = MyNNKayitSozlesme;
                    DataRepository.NN_SOZLESME_SOZLESMEProvider.DeepSave(trans, Ssozlesme);
                }
                ////gayrimenkul
                sozlesme.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.ForEach(
                    delegate(AV001_TI_BIL_GAYRIMENKUL obj)
                    {
                        if (sozlesme.NN_SOZLESME_GAYRIMENKULCollection.Count == 0)
                            DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(sozlesme, false, DeepLoadType.IncludeChildren, typeof(TList<NN_SOZLESME_GAYRIMENKUL>));
                        if (
                            sozlesme.NN_SOZLESME_GAYRIMENKULCollection.FindAll(
                                NN_SOZLESME_GAYRIMENKULColumn.GAYRIMENKUL_ID, obj.ID).Count == 0)
                        {
                            NN_SOZLESME_GAYRIMENKUL gayrimenkul =
                                sozlesme.NN_SOZLESME_GAYRIMENKULCollection.AddNew();
                            gayrimenkul.GAYRIMENKUL_IDSource = obj;
                        }
                    });

                DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepSave(trans, sozlesme, DeepSaveType.IncludeChildren,
                                                                       typeof(TList<NN_SOZLESME_GAYRIMENKUL>),
                                                                       typeof(TList<NN_SOZLESME_KIYMETLI_EVRAK>),
                                                                       typeof(TList<NN_SOZLESME_GEMI_UCAK_ARAC>));

                trans.Commit();
                if (SozlesmeKaydedildi != null)
                    SozlesmeKaydedildi(this, new SozlesmeFoyKaydedildiEventArgs(sozlesme));

                b = true;
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                BelgeUtil.ErrorHandler.Catch(typeof(frmSozlesmeKayit), ex, true);

                b = false;
            }
            return b;
        }

        private void lueAracTip_EditValueChanged(object sender, EventArgs e)
        {
            int aracTip = 0;
            if (lueAracTip.EditValue != null)
                aracTip = (int)lueAracTip.EditValue;

            if (aracTip == 7) //UÇAK
            {
                layoutControl25.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\AracTipleri\\ucak.xml");
            }
            else if (aracTip == 8) //GEMİ
            {
                layoutControl25.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\AracTipleri\\gemi.xml");
            }
            else //ARAÇ ve diğer bütün tipler
                layoutControl25.RestoreLayoutFromXml(Application.StartupPath + "\\SozlesmeXmler\\AracTipleri\\arac.xml");
        }

        private void lueIlcesi_EditValueChanged(object sender, EventArgs e)
        {
            BelgeUtil.Inits.BelediyeGetirIlceyeGor(lueBelediye, (int)lueIlcesi.EditValue);
            BelgeUtil.Inits.TapuMudurlukGetirIlceyeGore(lueGayrimenkulMudurluk.Properties, (int)lueIlcesi.EditValue);
        }

        private void lueIl_EditValueChanged(object sender, EventArgs e)
        {
            BelgeUtil.Inits.IlceGetirIleGore(lueIlcesi.Properties, (int)lueIl.EditValue);
        }

        private void lueKategori_EditValueChanged(object sender, EventArgs e)
        {
            BelgeUtil.Inits.MalTurGetirKategoriyeGore(lueTur, (int)lueKategori.EditValue);
        }

        private void lueTur_EditValueChanged(object sender, EventArgs e)
        {
            BelgeUtil.Inits.MalcinsGetirTureGore(lueCins.Properties, (int)lueTur.EditValue);
        }

        private void MuvekkilKarsi_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_SOZLESME_TARAF addnew = new AV001_TDI_BIL_SOZLESME_TARAF();
            addnew.TARAF_KODU = 3;
            addnew.TARAF_SIFAT_ID = (int)SozlesmeTarafTip.SOZLESME_TARAFI; // 10006;
            addnew.KAYIT_TARIHI = DateTime.Now;
            addnew.KONTROL_NE_ZAMAN = DateTime.Now;
            addnew.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            addnew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addnew.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            addnew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            e.NewObject = addnew;
        }

        private void Muvekkil_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_SOZLESME_TARAF addnew = new AV001_TDI_BIL_SOZLESME_TARAF();
            addnew.TARAF_KODU = 1;
            addnew.TARAF_SIFAT_ID = (int)SozlesmeTarafTip.ITIRAZ_EDEN; // 10003;
            addnew.KAYIT_TARIHI = DateTime.Now;
            addnew.KONTROL_NE_ZAMAN = DateTime.Now;
            addnew.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            addnew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addnew.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            addnew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            e.NewObject = addnew;
        }

        private void MyDerece_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_SOZLESME_DERECE addNew = e.NewObject as AV001_TDI_BIL_SOZLESME_DERECE;
            if (addNew == null)
                addNew = new AV001_TDI_BIL_SOZLESME_DERECE();

            addNew.ADMIN_KAYIT_MI = false;
            addNew.KAYIT_TARIHI = DateTime.Now;
            addNew.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            addNew.SUBE_ID = AvukatProLib.Kimlik.SubeKodu;

            e.NewObject = addNew;
        }

        private void rLueGayrimenkulTaraf_ButtonClick(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != string.Empty && e.Button.Tag == "mEkle")
            {
                try
                {
                    frmCariGenelGiris cari = new frmCariGenelGiris();
                    LookUpEdit lue = sender as LookUpEdit;
                    cari.tmpCariAd = lue.Text;
                    cari.Statuler.Add(AvukatProLib.Extras.CariStatu.Karşı_Taraf);
                    // cari.MdiParent = null;
                    cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    cari.Show();
                    cari.FormClosed += delegate
                                           {
                                               DialogResult dr = cari.KayitBasarili;
                                               if (dr == System.Windows.Forms.DialogResult.OK)
                                               {
                                                   //Inits.perCariGetirRefresh();
                                                   BelgeUtil.Inits.perCariGetirRefresh(rLueGayrimenkulTaraf);
                                               }
                                           };
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void setSozlesme(TList<AV001_TDI_BIL_SOZLESME> sozlesme)
        {
            if (sozlesme != null)
            {
                AV001_TDI_BIL_SOZLESME soz;
                if (!EditMode)
                {
                    soz = sozlesme.AddNew();
                    Muvekkil = new TList<AV001_TDI_BIL_SOZLESME_TARAF>();
                    MuvekkilKarsi = new TList<AV001_TDI_BIL_SOZLESME_TARAF>();
                    SorumluAvk = new TList<AV001_TDI_BIL_SOZLESME_SORUMLU>();
                    string strSozlesmeNo = SozlesmeNoGetir();
                    soz.BAGIMSIZ_MI = true;
                    soz.TASLAK_TARIHI = DateTime.Now;
                    soz.SOZLESME_DURUM_ID = (int)SozlesmeDurum.Faal; //10001;
                    soz.TUR = Convert.ToInt16(SozlesmeTur.Yazılı);
                    soz.AV001_TDI_BIL_SOZLESME_HAKEMLERICollection = new TList<AV001_TDI_BIL_SOZLESME_HAKEMLERI>();
                    soz.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SOZLESME_GEMI_UCAK_ARAC =
                        new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>();
                    soz.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL =
                        new TList<AV001_TI_BIL_GAYRIMENKUL>();
                    soz.AV001_TDI_BIL_SOZLESME_TARAFCollection = new TList<AV001_TDI_BIL_SOZLESME_TARAF>();
                    soz.TDI_BIL_BORCLU_MALCollection = new TList<TDI_BIL_BORCLU_MAL>();

                    soz.SOZLESME_NO = strSozlesmeNo;
                    bndExpertiz.AddingNew += bndExpertiz_AddingNew;
                    bndDigerMal.AddingNew += bndDigerMal_AddingNew;
                    bndAracBilgileri.AddingNew += bndAracBilgileri_AddingNew;
                }
                else
                {
                    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(MySozlesme[0], false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_TARAF>), typeof(TList<AV001_TDI_BIL_SOZLESME_SORUMLU>), typeof(TList<AV001_TI_BIL_GAYRIMENKUL>), typeof(TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>), typeof(TList<TDI_BIL_BORCLU_MAL>), typeof(TList<AV001_TDI_BIL_SOZLESME_HAKEMLERI>));
                    soz = MySozlesme[0];

                    Muvekkil = MySozlesme[0].AV001_TDI_BIL_SOZLESME_TARAFCollection.FindAll(vi => vi.TARAF_KODU == 1);
                    MuvekkilKarsi = MySozlesme[0].AV001_TDI_BIL_SOZLESME_TARAFCollection.FindAll(vi => vi.TARAF_KODU == 3);
                    SorumluAvk = MySozlesme[0].AV001_TDI_BIL_SOZLESME_SORUMLUCollection;
                }

                bndSozlesmeBilgileri.DataSource = sozlesme;

                soz.ColumnChanged += soz_ColumnChanged;

                soz.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.AddingNew +=
                        AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL_AddingNew;
                soz.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SOZLESME_GEMI_UCAK_ARAC.AddingNew +=
                    AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SOZLESME_GEMI_UCAK_ARAC_AddingNew;
                soz.TDI_BIL_BORCLU_MALCollection.AddingNew += TDI_BIL_BORCLU_MALCollection_AddingNew;

                gcSozlesmeTarafi.DataSource = Muvekkil;
                gcSozlesmeKarsiT.DataSource = MuvekkilKarsi;
                gcSozlesmeSorumlusu.DataSource = SorumluAvk;
                Muvekkil.AddingNew += Muvekkil_AddingNew;
                MuvekkilKarsi.AddingNew += MuvekkilKarsi_AddingNew;
                SorumluAvk.AddingNew += SorumluAvk_AddingNew;
                bndAracBilgileri.DataSource = soz.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SOZLESME_GEMI_UCAK_ARAC;
                bndDigerMal.DataSource = soz.TDI_BIL_BORCLU_MALCollection;
                //dnDigerMalBilgileri.DataSource = soz.TDI_BIL_BORCLU_MALCollection;
                //dnAracBilgileri.DataSource = soz.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SOZLESME_GEMI_UCAK_ARAC;
                bndGayrimenkul.DataSource = soz.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL;
                //dnGayrimenkulBilgileri.DataSource = soz.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL;
                ucSozlesmeHakemleri1.MyDataSource = soz.AV001_TDI_BIL_SOZLESME_HAKEMLERICollection;
            }

        }

        void bndAracBilgileri_AddingNew(object sender, AddingNewEventArgs e)
        {
            layoutControlGroup68.Enabled = true;
        }

        void bndDigerMal_AddingNew(object sender, AddingNewEventArgs e)
        {
            panelControl17.Enabled = true;
        }

        void bndExpertiz_AddingNew(object sender, AddingNewEventArgs e)
        {
            layoutControlGroup13.Enabled = true;
            panelControl15.Enabled = true;
            panelControl19.Enabled = true;
        }

        private void SorumluAvk_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_SOZLESME_SORUMLU addnew = new AV001_TDI_BIL_SOZLESME_SORUMLU();
            addnew.KAYIT_TARIHI = DateTime.Now;
            addnew.KONTROL_NE_ZAMAN = DateTime.Now;
            addnew.KONTROL_KIM = "AVUKATPRO";
            addnew.KONTROL_VERSIYON = 0;
            addnew.STAMP = 1;
            addnew.KLASOR_KODU = "GENEL";
            e.NewObject = addnew;
        }

        private string SozlesmeNoGetir()
        {
            string foyNo = String.Empty;

            AV001_TDI_BIL_SOZLESMEQuery que = new AV001_TDI_BIL_SOZLESMEQuery();
            int k = 0;
            TList<AV001_TDI_BIL_SOZLESME> foyler = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.Find(que, "ID DESC", 0,
                                                                                                      1, out k);
            if (foyler.Count > 0)
            {
                int foyNoSayi = foyler[0].SOZLESME_NO_Sayi;
                var foy_No = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text,
                                                                   "select top(1)SOZLESME_NO from AV001_TDI_BIL_SOZLESME order by KAYIT_TARIHI desc");

                foyNo = String.Format("S-{0}~{1}", DateTime.Today.Year, foyNoSayi + 1);
            }
            else
            {
                foyNo = String.Format("S-{0}~{1}", DateTime.Today.Year, 10001);
            }
            return foyNo;
        }

        private void soz_ColumnChanged(object sender, AV001_TDI_BIL_SOZLESMEEventArgs e)
        {
            AV001_TDI_BIL_SOZLESME soz = sender as AV001_TDI_BIL_SOZLESME;
            if (e.Column == AV001_TDI_BIL_SOZLESMEColumn.TIP_ID)
            {
                BelgeUtil.Inits.SozlesmeAltTipiTipineGoreGetir(lueSozlesmeAltTip, (int)e.Value);
            }
            if (e.Column == AV001_TDI_BIL_SOZLESMEColumn.BITIS_TARIHI)
            {
                if (e.Value != null)
                {
                    BitTarih = (DateTime)e.Value;
                    int gun = 0;
                    int ay = 0;
                    int yil = 0;
                    if (BasTarih == DateTime.MinValue)
                        BasTarih = DateTime.Now;
                    gun = BitTarih.Day - BasTarih.Day;
                    soz.SURE_GUN = (short)gun;
                    ay = BitTarih.Month - BasTarih.Month;
                    soz.SURE_AY = (short)ay;
                    yil = BitTarih.Year - BasTarih.Year;
                    soz.SURE_YIL = (short)yil;
                }
                else
                {
                    soz.SURE_GUN = 0;
                    soz.SURE_AY = 0;
                    soz.SURE_YIL = 0;
                }
            }
            if (e.Column == AV001_TDI_BIL_SOZLESMEColumn.BASLANGIC_TARIHI)
            {
                BasTarih = (DateTime)e.Value;
            }
            if (e.Column == AV001_TDI_BIL_SOZLESMEColumn.IMZA_TARIHI)
            {
                soz.SICIL_TARIHI = BelgeUtil.Inits.ToDateTime(e.Value);
            }

            if (e.Column == AV001_TDI_BIL_SOZLESMEColumn.BEDELI || e.Column == AV001_TDI_BIL_SOZLESMEColumn.BEDELI_DOVIZ_ID)
            {
                foreach (var item in MuvekkilKarsi)
                {
                    item.SORUMLULUK_MIKTAR = Convert.ToDouble(soz.BEDELI);
                    item.SORUMLULUK_MIKTAR_DOVIZ_ID = (int)soz.BEDELI_DOVIZ_ID.Value;
                }
            }
            //if (e.Column == AV001_TDI_BIL_SOZLESMEColumn.REHIN_CINS_ANA_TURU)
            //{
            //    if (rbtnLimit.Checked == true)
            //    {
            //        //ucSozlesmeBilgileri1.Bedeli_Kur.Enabled = false;
            //        soz.REHIN_CINS_ANA_TURU = 0;
            //    }
            //    if (rbtnAnaPara.Checked == true)
            //    {
            //        // ucSozlesmeBilgileri1.Bedeli_Kur.Enabled = true;
            //        soz.REHIN_CINS_ANA_TURU = 1;
            //    }
            //}
            //if (e.Column == AV001_TDI_BIL_SOZLESMEColumn.MUSTEREKMI_MUSTAKILMI)
            //{
            //    if (rbtnMustakil.Checked == true)
            //    {
            //        //ucSozlesmeBilgileri1.Bedeli_Kur.Enabled = false;
            //        soz.MUSTEREKMI_MUSTAKILMI = false;
            //    }
            //    if (rbtnMusterek.Checked == true)
            //    {
            //        // ucSozlesmeBilgileri1.Bedeli_Kur.Enabled = true;
            //        soz.MUSTEREKMI_MUSTAKILMI = true;
            //    }
            //}
            if (e.Column == AV001_TDI_BIL_SOZLESMEColumn.IMZA_TARIHI)
            {
                soz.SICIL_TARIHI = (DateTime)e.Value;
            }
        }

        private void TDI_BIL_BORCLU_MALCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            TDI_BIL_BORCLU_MAL mal = new TDI_BIL_BORCLU_MAL();
            mal.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            mal.KAYIT_TARIHI = DateTime.Now;
            mal.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            mal.KONTROL_NE_ZAMAN = DateTime.Now;
            mal.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            bndExpertiz.DataSource = mal.AV001_TI_BIL_KIYMET_TAKDIRICollection;
            //dnDigermallar.DataSource = mal.AV001_TI_BIL_KIYMET_TAKDIRICollection;
            //ucSozlesmeDetayTakyidatDigerMal.MyDataSource = mal.av;
            e.NewObject = mal;
        }

        #endregion Methods
    }
}