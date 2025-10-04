using System;
using System.Linq;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using AvukatProLib;
using System.Drawing;

namespace AdimAdimDavaKaydi.Sorusturma.Forms
{
    public partial class rFrmSorusturmaTakip : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public rFrmSorusturmaTakip()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public event EventHandler<FrmSorusturmaDosyaKayit> SorusturmaKaydedildi;

        public void Show(TList<AV001_TD_BIL_HAZIRLIK> foys)
        {
            this.HazirlikList = foys;

            #region <MB-20100525>

            //Dosyanýn Klasör Bilgilerinin gelmesi saðlandý.

            if (HazirlikList.Count > 0)
            {
                TList<AV001_TDIE_BIL_PROJE> proje =
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByHAZIRLIK_IDFromAV001_TDIE_BIL_PROJE_HAZIRLIK(
                        foys[0].ID);
                if (proje.Count > 0)
                    MyProje = proje[0];
            }

            if (MyProje == null) lcGroupKlasor.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            else if (MyProje.AV001_TDIE_BIL_PROJE_SORUMLUCollection != null)
            {
                if (MyProje.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TDIE_BIL_PROJE_SORUMLU>));
                bndProje.DataSource = MyProje;
            }

            #endregion <MB-20100525>

            ucSablonEditoreGonder1.Foys = new TList<AV001_TD_BIL_HAZIRLIK>();
            ucSablonEditoreGonder1.Foys.Add(foys[0]);
            ucSablonEditoreGonder1.ModuleGoreDoldur(3);
            this.Show();
        }

        public void Show(int id)
        {
            myHazirlik = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(id);
            if (myHazirlik == null)
            {
                MessageBox.Show("Açýlmak istenilen Soruþturma dosyasý bulunamadý.");
                Application.Exit();
                return;
            }
            if (HazirlikList == null)
                HazirlikList = new TList<AV001_TD_BIL_HAZIRLIK>();
            HazirlikList.Add(myHazirlik);
            this.Show(HazirlikList);
        }

        #region frmLoadAndProperties

        private TList<AV001_TD_BIL_HAZIRLIK> HazirlikList;
        private AV001_TD_BIL_HAZIRLIK myHazirlik;

        public AV001_TD_BIL_HAZIRLIK MyHazirlik
        {
            get { return myHazirlik; }
            set { myHazirlik = value; }
        }

        #region <MB-20100525>

        //Dosyanýn Klasör Bilgilerinin gelmesi saðlandý.

        public AV001_TDIE_BIL_PROJE MyProje { get; set; }

        #endregion <MB-20100525>

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            LoadHazirlikData();

            bndHazirlikFoy.DataSource = HazirlikList;

            //this.compRibbonExtender1.SikKullanilanButtonClickEvent += new EventHandler<AdimAdimDavaKaydi.ExtendTool.SikKullanilanaEkleBtnClickEventArgs>(compRibbonExtender1_SikKullanilanButtonClickEvent);
            //if (this.ucSorusturmaTarafBilgileri1.SikayetEdenTarafControls == null)
            //{
            //    ucSorusturmaTarafBilgileri1.SikayetEdenTarafControls = new List<DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit>();
            //}
            //if (this.ucSorusturmaTarafBilgileri1.SikayetEdilenTarafControls == null)
            //{
            //    ucSorusturmaTarafBilgileri1.SikayetEdilenTarafControls = new List<DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit>();
            //}

            Ref1.Text = Kimlikci.Kimlik.SorusturmaReferans.Referans1;
            Ref2.Text = Kimlikci.Kimlik.SorusturmaReferans.Referans2;
            Ref3.Text = Kimlikci.Kimlik.SorusturmaReferans.Referans3;
            lciOzelKod1.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod1;
            lciOzelKod2.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod2;
            lciOzelKod3.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod3;
            lciOzelKod4.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod4;
        }

        private void BindOzelKod()
        {
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod1, 1, AvukatProLib.Extras.Modul.Sorusturma);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod2, 2, AvukatProLib.Extras.Modul.Sorusturma);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod3, 3, AvukatProLib.Extras.Modul.Sorusturma);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod4, 4, AvukatProLib.Extras.Modul.Sorusturma);
        }

        private void frmOzelKod_FormClosed(object sender, FormClosedEventArgs e)
        {
            BindOzelKod();
        }

        private void LoadHazirlikData()
        {
            //this.compRibbonExtender1.LoadMainMenu = true;
            //this.compRibbonExtender1.RibbonForExtend = null;
            //this.compRibbonExtender1.RibbonFormForExtend = this;

            //YazdirmaSablonlariniDoldur();
            AvukatPro.Services.Implementations.DevExpressService.FoyDurumDoldur(lueDosyaDurum);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeDoldur(lueSavcilik);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeGorevDoldur(lueAdliBirimGorev);
            AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(lueSegment);
            BindOzelKod();
            lueOzelKod1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod1_ButtonClick);
            lueOzelKod2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod1_ButtonClick);
            lueOzelKod3.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod1_ButtonClick);
            lueOzelKod4.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod1_ButtonClick);
            BelgeUtil.Inits.SikayetKonuDavaTalepCezaGetir(lueSikayetKonusu.Properties, "c");
            BelgeUtil.Inits.HazirlikDurumGetir(lueHazirlikDurum.Properties);
            BelgeUtil.Inits.SikayetAsamaGetir(lueHazirlikAsamasi);

            //Inits.IlGetir(lueIl.Properties);
            //Inits.IlceGetirTumu(lueIlce.Properties);
            //HazirlikList = ucSorusturmaBindngControl1.MyDataSource;
            bndHazirlikFoy.DataSource = HazirlikList;
            ucSorusturmaBindngControl1.MyDataSource = HazirlikList;

            //ucSorusturmaCore1.MyHazirlik = HazirlikList[0];
            //  ucSorusturmaBindngControl1.dataNavigator1.PositionChanged += new EventHandler(dataNavigator1_PositionChanged);

            bndHazirlikFoy_CurrentChanged(0, new EventArgs());

            #region <MB-20100525>

            //Klasör Grubunda Doldurulan Lookup'lar
            if (MyProje != null)
            {
                AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rlueKlasorSorumlu);
                BelgeUtil.Inits.ProjeOzelKodGetir(lueSube.Properties);
            }

            #endregion <MB-20100525>
        }

        private void lueOzelKod1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == "ekle")
            {
                AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle frm = new AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle();
                frm.Show();
                frm.FormClosed += new FormClosedEventHandler(frmOzelKod_FormClosed);
            }
        }

        private void rFrmSorusturmaTakip_Load(object sender, EventArgs e)
        {
            //dockManager1.RestoreLayoutFromRegistry("DockManager\\Layouts\\SorusturmaLayout");
            dpTarafbilgileri.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            //dpTarafbilgileri.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            dpTarafbilgileri.Hide();
            //Takip herhangi bir klasöre baðlý deðil ise takibin istenilen klasöre baðlanmasý saðlanýyor. MB
            if (DataRepository.AV001_TDIE_BIL_PROJE_HAZIRLIKProvider.GetByHAZIRLIK_ID(HazirlikList[0].ID).Count == 0)
            {
                btnKlasoreBagla.Tag = "BAÐLA";
                btnKlasoreBagla.Text = "SORUÞTURMA DOSYASINI KLASÖRE BAÐLA";
                BelgeUtil.Inits.ProjeAdGetirYenile(lueKlasor);
            }
            else
            {
                btnKlasoreBagla.Tag = "ÇIKAR";
                btnKlasoreBagla.Text = "SORUÞTURMA DOSYASINI KLASÖRDEN ÇIKAR";
                BelgeUtil.Inits.ProjeAdGetirYenile(lueKlasor);
            }
        }
        private bool tarafVisible = false;
        void dpTarafbilgileri_VisibilityChanged(object sender, DevExpress.XtraBars.Docking.VisibilityChangedEventArgs e)
        {
            if (dpTarafbilgileri.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Visible && !tarafVisible)
            {
                TarafCreate();
                ucSorusturmaTarafBilgileri1.MyHazirlik = this.MyHazirlik;
                tarafVisible = true;
            }
        }

        //void compRibbonExtender1_SikKullanilanButtonClickEvent(object sender, AdimAdimDavaKaydi.ExtendTool.SikKullanilanaEkleBtnClickEventArgs e)
        //{
        //    DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(MyHazirlik, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_ADLI_BIRIM_ADLIYE), typeof(TDI_KOD_ADLI_BIRIM_NO), typeof(TDI_KOD_ADLI_BIRIM_GOREV));
        //    e.KayitID = MyHazirlik.ID;
        //    e.Modul = AvukatProLib.Extras.ModulTip.Sorusturma;
        //    string adliye = string.Empty; string gorev = string.Empty; string no = string.Empty;
        //    if (MyHazirlik.ADLI_BIRIM_ADLIYE_IDSource != null)
        //        adliye = MyHazirlik.ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;
        //    if (MyHazirlik.ADLI_BIRIM_GOREV_IDSource != null)
        //        gorev = MyHazirlik.ADLI_BIRIM_GOREV_IDSource.GOREV;
        //    if (MyHazirlik.ADLI_BIRIM_NO_IDSource != null)
        //        no = MyHazirlik.ADLI_BIRIM_NO_IDSource.NO;
        //    e.KayitAdi = string.Format("{0} {1} {2} {3}E. nolu Dosyasý", adliye, gorev, no, MyHazirlik.HAZIRLIK_ESAS_NO);
        //}

        #endregion frmLoadAndProperties

        ///// <summary>
        ///// Yazdýrma Sablonlari Dolduran Metod
        ///// </summary>
        //private void YazdirmaSablonlariniDoldur()
        //{
        //    BackgroundWorker bWorker = new BackgroundWorker();
        //    TList<TDI_KOD_TEBLIGAT_SABLON> sablon = new TList<TDI_KOD_TEBLIGAT_SABLON>();
        //    bWorker.DoWork += delegate { sablon = DataRepository.TDI_KOD_TEBLIGAT_SABLONProvider.GetAll(); };
        //    bWorker.RunWorkerCompleted += delegate
        //                                      {
        //                                          foreach (TDI_KOD_TEBLIGAT_SABLON sbl in sablon)
        //                                          {
        //                                              cbSablonlar.Properties.BeginUpdate();
        //                                              cbSablonlar.Properties.Items.Add(sbl.SABLON_ADI, true);
        //                                              cbSablonlar.Properties.EndUpdate();
        //                                          }
        //                                      };
        //    bWorker.RunWorkerAsync();
        //}

        private void DataDegisti()
        {
            //this.Enabled = false;
            System.ComponentModel.BackgroundWorker bWorker = new System.ComponentModel.BackgroundWorker();
            bWorker.DoWork += delegate
                                  {
                                      if (MyHazirlik == null)
                                          return;
                                      if (MyHazirlik.Tag == null)
                                      {
                                          DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(MyHazirlik, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_MUVEKKILE_ODEME>), typeof(TList<AV001_TD_BIL_TUTUKLANMA>), typeof(TList<AV001_TD_BIL_HAZIRLIK_TARAF>), typeof(TList<AV001_TDIE_BIL_ASAMA>), typeof(TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>), typeof(TList<TD_BIL_HAZIRLIK_OZEL_KOD>), typeof(TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF>), typeof(TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN>), typeof(TList<AV001_TD_BIL_HAZIRLIK_HIKAYE>), typeof(TList<AV001_TDI_BIL_IS>), typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>), typeof(TList<AV001_TDI_BIL_FOY_MUHASEBE>), typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI>), typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>), typeof(TList<AV001_TD_BIL_HAZIRLIK_SUREC>), typeof(TList<TDIE_KOD_ASAMA>), typeof(TList<AV001_TDI_BIL_FATURA>));
                                      }
                                      MyHazirlik.Tag = 1;

                                      foreach (
                                          AV001_TD_BIL_HAZIRLIK_SORUMLU avukat in
                                              MyHazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection)
                                      {
                                          if (avukat.CARI_IDSource == null)
                                              DataRepository.AV001_TD_BIL_HAZIRLIK_SORUMLUProvider.DeepLoad(avukat, true, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                                      }
                                  };
            bWorker.RunWorkerCompleted += delegate
                                              {
                                                  bndHazirlikFoy.DataSource = this.MyHazirlik;

                                                  //aykut deneme
                                                  //ucSorusturmaTarafBilgileri1.MyHazirlik = this.MyHazirlik;

                                                  ucSorusturmaCore1.MyHazirlik = this.MyHazirlik;

                                                  #region Sorumlu Avukat

                                                  //gLueSorumluAvukat.Properties.BeginUpdate();
                                                  //gLueSorumluAvukat.Properties.DataSource = MyHazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection;
                                                  //gLueSorumluAvukat.Properties.ValueMember = "ID";
                                                  //gLueSorumluAvukat.Properties.DisplayMember = "CARI_IDSource";
                                                  //if (MyHazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.Count > 0)
                                                  //    gLueSorumluAvukat.EditValue = MyHazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection[0].ID;

                                                  //gLueSorumluAvukat.Properties.EndUpdate();

                                                  #endregion Sorumlu Avukat

                                                  this.Enabled = true;
                                                  //dpTarafbilgileri.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
                                                  //dpTarafbilgileri.Hide();
                                              };
            bWorker.RunWorkerAsync();

            if (MyHazirlik != null)
            {
                DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(MyHazirlik, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI>), typeof(TList<AV001_TD_BIL_HAZIRLIK_TARAF>));
                var detay = DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_HAZIRLIK_ID(MyHazirlik.ID);

                if (MyHazirlik.AV001_TDI_BIL_KAYIT_ILISKICollection.Count > 0 || detay.Count > 0)
                    c_titemIliskiliDosyalar.Image =
                        global::AdimAdimDavaKaydi.Properties.Resources.iliskili_dosyalar_red_16x16;
                else
                    c_titemIliskiliDosyalar.Image =
                        global::AdimAdimDavaKaydi.Properties.Resources.iliskili_dosyalar_mavi_16x16;

                #region <MB-20101103> Formun Text'inin Belirlenmesi

                if (MyHazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection.Count == 0) return;

                var taraflar = MyHazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection;

                AV001_TD_BIL_HAZIRLIK_TARAF davaci = taraflar.Where(vi => vi.SIKAYET_EDEN_MI).FirstOrDefault();
                AV001_TD_BIL_HAZIRLIK_TARAF davali = taraflar.Where(vi => vi.SIKAYET_EDEN_MI == false).FirstOrDefault();

                string takipEdenSifat = string.Empty;
                string takipEdilenSifat = string.Empty;

                if (davaci != null)
                    DataRepository.AV001_TD_BIL_HAZIRLIK_TARAFProvider.DeepLoad(davaci, false,
                                                                                DeepLoadType.IncludeChildren,
                                                                                typeof(TDIE_KOD_TARAF_SIFAT),
                                                                                typeof(AV001_TDI_BIL_CARI));
                if (davali != null)
                    DataRepository.AV001_TD_BIL_HAZIRLIK_TARAFProvider.DeepLoad(davali, false,
                                                                                DeepLoadType.IncludeChildren,
                                                                                typeof(TDIE_KOD_TARAF_SIFAT),
                                                                                typeof(AV001_TDI_BIL_CARI));
                string takipEden = "";
                if (davaci != null)
                {
                    if (davaci.TARAF_SIFAT_IDSource != null)
                        takipEdenSifat = davaci.TARAF_SIFAT_IDSource.SIFAT;
                    takipEden = davaci.CARI_IDSource.AD;
                }

                string takipEdilen = "";
                if (davali != null)
                {
                    if (davali.TARAF_SIFAT_IDSource != null)
                        takipEdilenSifat = davali.TARAF_SIFAT_IDSource.SIFAT;
                    takipEdilen = davali.CARI_IDSource.AD;
                }
                this.Text = string.Format("{0} - {1} - {2} - {3}", takipEdenSifat, takipEden, takipEdilenSifat,
                                          takipEdilen);

                #endregion <MB-20101103> Formun Text'inin Belirlenmesi
            }
        }

        #region FormClosing

        private void rFrmSorusturmaTakip_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (
                XtraMessageBox.Show(this, "Çýkmak Ýstediðinizden Eminmisiniz ", "Soruþturma Takip",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }

            //dockManager1.SaveLayoutToRegistry("DockManager\\Layouts\\SorusturmaLayout");
        }

        #endregion FormClosing

        #region Changed_EventArgs

        private void bndHazirlikFoy_CurrentChanged(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(int))
                return;
            int deger;
            if ((int)sender < 0)
                deger = 0;
            else
                deger = (int)sender;
            MyHazirlik = HazirlikList[deger];
            DataDegisti();
        }

        #endregion Changed_EventArgs

        #region click

        #region <CC-20090622>

        // kaydet metodu kaydetme iþlemi yapýldý
        public bool SorusturmaKaydet(AV001_TD_BIL_HAZIRLIK hzrlk)
        {
            bool b = false;
            try
            {
                //foreach (AV001_TD_BIL_HAZIRLIK_SORUMLU SorumluAvk in hzrlk.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection)
                //{
                //    //if (SorumluAvk.CARI_ID != null)
                //    // SorumluAvk.CARI_ID = SorumluAvk.CARI_IDSource.ID;
                //}

                if (hzrlk.IsNew)
                {
                    hzrlk.KAYIT_TARIHI = DateTime.Now;
                    hzrlk.KONTROL_NE_ZAMAN = DateTime.Now;
                    hzrlk.KONTROL_KIM = "AVUKATPRO";
                    hzrlk.KONTROL_VERSIYON = 0;
                    hzrlk.KLASOR_KODU = "GENEL";
                    hzrlk.ADLI_BIRIM_GOREV_ID = 43;
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

                DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepSave(trans, hzrlk, DeepSaveType.IncludeChildren, typeof(TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>));

                DataRepository.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENProvider.DeepSave(trans,
                                                                                    hzrlk.
                                                                                        AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection);

                DataRepository.AV001_TD_BIL_HAZIRLIK_TARAFProvider.DeepSave(trans,
                                                                            hzrlk.AV001_TD_BIL_HAZIRLIK_TARAFCollection);
                if (hzrlk.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection.Count > 0)
                {
                    foreach (
                        AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN neden in hzrlk.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection
                        )
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
                                NN_SORUSTURMA_KIYMETLI_EVRAK kEvrak =
                                    hzrlk.NN_SORUSTURMA_KIYMETLI_EVRAKCollection.AddNew();
                                kEvrak.KIYMETLI_EVRAK_IDSource = dNKEvrak;
                                kEvrak.SORUSTURMA_ID = hzrlk.ID;
                            }
                            foreach (
                                AV001_TDI_BIL_GEMI_UCAK_ARAC gua in
                                    hSNeden.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SIKAYET_NEDEN_GEMI_UCAK_ARAC)
                            {
                                NN_SORUSTURMA_GEMI_UCAK_ARAC Igua =
                                    hzrlk.NN_SORUSTURMA_GEMI_UCAK_ARACCollection.AddNew();
                                Igua.GEMI_UCAK_ARAC_IDSource = gua;
                                Igua.SORUSTURMA_ID = hzrlk.ID;
                            }
                            foreach (
                                AV001_TI_BIL_GAYRIMENKUL gayrimenkul in
                                    hSNeden.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SIKAYET_NEDEN_GAYRIMENKUL)
                            {
                                NN_SORUSTURMA_GAYRIMENKUL Igayrimenkul =
                                    hzrlk.NN_SORUSTURMA_GAYRIMENKULCollection.AddNew();
                                Igayrimenkul.GAYRIMENKUL_IDSource = gayrimenkul;
                                Igayrimenkul.SORUSTURMA_ID = hzrlk.ID;
                            }

                            /////////Foreign Key Hatasý için
                            foreach (TD_BIL_HAZIRLIK_OZEL_KOD ozelKod in MyHazirlik.TD_BIL_HAZIRLIK_OZEL_KODCollection)
                            {
                                if (
                                    MyHazirlik.TD_BIL_HAZIRLIK_OZEL_KODCollection.Exists(
                                        delegate(TD_BIL_HAZIRLIK_OZEL_KOD o) { return ozelKod.ID == o.ID; })) continue;
                            }
                            /////////

                            // todo : poliçede eklenince yukardýkilere benzer þekilde oluþturulacak
                            DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepSave(trans, hzrlk,
                                                                                  DeepSaveType.IncludeChildren,
                                                                                  typeof(
                                                                                      TList<NN_SORUSTURMA_GAYRIMENKUL>),
                                                                                  typeof(
                                                                                      TList
                                                                                      <NN_SORUSTURMA_GEMI_UCAK_ARAC>),
                                                                                  typeof(
                                                                                      TList
                                                                                      <NN_SORUSTURMA_KIYMETLI_EVRAK>),
                                                                                  typeof(TList<NN_SORUSTURMA_POLICE>),
                                                                                  typeof(
                                                                                      TList<TD_BIL_HAZIRLIK_OZEL_KOD>),
                                                                                  typeof(TList<AV001_TDI_BIL_CARI>));

                            //foreach (AV001_TD_BIL_HAZIRLIK_TARAF trf in MyHazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection)
                            //{
                            //
                            //    DataRepository.AV001_TDI_BIL_CARIProvider.DeepSave(trans, trf.CARI_IDSource, DeepSaveType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                            //}

                            foreach (
                                AV001_TD_BIL_HAZIRLIK_TARAF item in MyHazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection)
                            {
                                DataRepository.AV001_TD_BIL_HAZIRLIK_TARAFProvider.DeepSave(trans, item);
                                if (item.CARI_IDSource != null)
                                {
                                    DataRepository.AV001_TDI_BIL_CARIProvider.DeepSave(trans, item.CARI_IDSource,
                                                                                       DeepSaveType.IncludeChildren,
                                                                                       typeof(
                                                                                           TList
                                                                                           <AV001_TDI_BIL_CARI_KIMLIK>));
                                }
                                DataRepository.AV001_TDI_BIL_CARIProvider.DeepSave(trans, item.CARI_IDSource,
                                                                                   DeepSaveType.IncludeChildren,
                                                                                   typeof(AV001_TDI_BIL_CARI));
                            }

                            foreach (
                                AV001_TD_BIL_HAZIRLIK_SORUMLU sorm in MyHazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection
                                )
                            {
                                if (sorm.CARI_IDSource != null)
                                    DataRepository.AV001_TDI_BIL_CARIProvider.DeepSave(trans, sorm.CARI_IDSource,
                                                                                       DeepSaveType.IncludeChildren,
                                                                                       typeof(
                                                                                           TList
                                                                                           <AV001_TDI_BIL_CARI_KIMLIK>));
                            }
                        }

                        #endregion Soruþturma Police ,Gayrimenkul,Sozlesme,KýymetliEvrak,ARAC  Kayýt NN
                    }
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

        private void bBtnKaydet_ItemClick(object sender, EventArgs e)
        {
            if (SorusturmaKaydet(MyHazirlik))
            {
                XtraMessageBox.Show("Kaydedildi", "Kayit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Kayýt Esnasýnda Hata Oluþtu." + Environment.NewLine + "Dosya Kaydedilemedi.",
                                    "Kayit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bBtnYeni_ItemClick(object sender, EventArgs e)
        {
            rfrmSorusturmaGiris sorusturmakayit = new rfrmSorusturmaGiris();
            if (SorusturmaKaydedildi != null)
            {
                SorusturmaKaydedildi(this, new FrmSorusturmaDosyaKayit(sorusturmakayit));
            }

            //sorusturmakayit.MdiParent = null;
            sorusturmakayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
            sorusturmakayit.Show();
        }

        #endregion <CC-20090622>

        //private void bBtnYazdir_ItemClick(object sender, EventArgs e)
        //{
        //    ArrayList yazidrmalist = new ArrayList();
        //    foreach (CheckedListBoxItem cItem in cbSablonlar.Properties.Items)
        //    {
        //        if (cItem.CheckState == CheckState.Checked)
        //        {
        //            yazidrmalist.Add(cItem.ToString());
        //        }
        //    }
        //    StringBuilder sBuild = new StringBuilder();
        //    foreach (string s in yazidrmalist)
        //    {
        //        sBuild.Append("* " + s);
        //        sBuild.Append(Environment.NewLine);
        //    }
        //    MessageBox.Show("Seçili Yazdýrma Ýþlemleri" + Environment.NewLine + sBuild);
        //}

        private void bBtnAc_ItemClick(object sender, EventArgs e)
        {
            rFrmSorusturmaTakip sorusturmatakip = new rFrmSorusturmaTakip();
            //sorusturmatakip.MdiParent = null;
            sorusturmatakip.StartPosition = FormStartPosition.WindowsDefaultLocation;
            sorusturmatakip.Show();
        }

        private void bBtnTakipAjandasi_ItemClick(object sender, EventArgs e)
        {
            #region <MB-20100428> Dosya Ajandasý Yeniden Düzenlendi.

            //Kullanýcýnýn o dosyada sorumlu avukat olup olmadýðý kontrolü yapýlýyor.
            TList<AV001_TD_BIL_HAZIRLIK_SORUMLU> dosyaSorumluAvukatlari =
                DataRepository.AV001_TD_BIL_HAZIRLIK_SORUMLUProvider.GetByHAZIRLIK_ID(MyHazirlik.ID);
            bool kullaniciDosyadaSorumluAvukat = false;

            foreach (var item in dosyaSorumluAvukatlari)
            {
                if (item.CARI_ID == AvukatProLib.Kimlik.Bilgi.CARI_ID.Value)
                {
                    kullaniciDosyadaSorumluAvukat = true;
                    break;
                }
                else
                    kullaniciDosyadaSorumluAvukat = false;
            }

            if (!kullaniciDosyadaSorumluAvukat)
            {
                XtraMessageBox.Show(
                    "Dosyada Sorumlu Avukat olmadýðýnýz için" + Environment.NewLine + "gösterilecek iþleriniz yok.",
                    "BÝLGÝ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Kullanýcýnýn Dosyadaki iþlerini buluyor.
            var isler = BelgeUtil.Inits.context.per_AV001_TDI_BIL_IS_Asistans.Where(item => BelgeUtil.Inits.context.NN_IS_HAZIRLIKs.Where(hazirlik => hazirlik.HAZIRLIK_ID == MyHazirlik.ID).Select(t => t.IS_ID).Contains(item.ID) && item.AJANDADA_GORUNSUN_MU && BelgeUtil.Inits.context.AV001_TDI_BIL_IS_TARAFs.Where(c => c.CARI_ID == AvukatProLib.Kimlik.Bilgi.CARI_ID && c.IS_TARAF_ID == 2).Select(vi => vi.IS_ID).Contains(item.ID)).ToList();

            //Dosyanýn iliþkili olduðu dosyalarýn iþlerini buluyor.
            AV001_TDI_BIL_KAYIT_ILISKI iliski =
                DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByILISKI_TUR_IDKAYNAK_KAYIT_ID(
                    (int?)AvukatProLib.Extras.KayitIliskiTur.HAZIRLIK_DOSYASI, MyHazirlik.ID);
            if (iliski != null)
            {
                TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> iliskiDetaylari =
                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByKAYIT_ILISKI_ID(iliski.ID);
                IcraTakipForms._frmIcraTakip.KayitIliskiDetayIsleriGetir(iliskiDetaylari, isler);
            }
            else
            {
                TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> iliskiDetaylari =
                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_KAYIT_ID(MyHazirlik.ID);
                IcraTakipForms._frmIcraTakip.DetaydanIliskiliIsleriGetir(iliskiDetaylari, isler);
            }

            //aykut önemli 27.02.2013
            //global::AdimAdimDavaKaydi.Ajanda.Forms.MainForms.frmAjanda ajanda =
            //    new global::AdimAdimDavaKaydi.Ajanda.Forms.MainForms.frmAjanda(isler, MyHazirlik, true);
            //ajanda.Show();

            #endregion <MB-20100428> Dosya Ajandasý Yeniden Düzenlendi.
        }

        private void bBtnTakipYazismalari_ItemClick(object sender, EventArgs e)
        {
            //frmEditor editor = new frmEditor();
            //editor.SelectedFoys = (AV001_TD_BIL_HAZIRLIK)this.bndHazirlikFoy.DataSource;
            //editor.Show();
        }

        #region Editor,Word,Outlook,Excell,Pdf button click

        private void bBtnEditor_ItemClick(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor editor = new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor();
            editor.MdiParent = AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm;
            editor.Show();
        }

        private void bBtnPDF_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pdf);
        }

        private string BelgeNoGetir()
        {
            string yeniBelgeNo = string.Empty;
            var enSonBelgeNo = DataRepository.Provider.ExecuteScalar(
                System.Data.CommandType.Text, "select top(1)BELGE_NO from AV001_TDIE_BIL_BELGE order by ID desc");
            if (enSonBelgeNo != null && enSonBelgeNo.ToString().Contains("B-20"))
            {
                string[] dizi = enSonBelgeNo.ToString().Split('~');
                int yeniBelgeNoSayi = Convert.ToInt32(dizi[1]) + 1;
                yeniBelgeNo = String.Format("B-{0}~{1}", DateTime.Today.Year, yeniBelgeNoSayi);
                return yeniBelgeNo;
            }
            else
            {
                yeniBelgeNo = String.Format("B-{0}~{1}", DateTime.Today.Year, "10000");
                return yeniBelgeNo;
            }
        }

        #region Word

        private Microsoft.Office.Interop.Word.Document adoc;

        private Microsoft.Office.Interop.Word.ApplicationClass WordApp;

        protected void WordApp_DocumentBeforeClose(Microsoft.Office.Interop.Word.Document doc, ref bool I)
        {
            if (!doc.Saved)
                if (XtraMessageBox.Show("Döküman kaydedilmedi. Kaydetmek istiyormusunuz?", "Uyarý", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    doc.Save();

            if (doc.Saved)
            {
                string fileName = doc.FullName;

                object saveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdPromptToSaveChanges;
                object originalFormat = Microsoft.Office.Interop.Word.WdOriginalFormat.wdWordDocument;
                object routeDocument = true;

                doc.Close(ref saveChanges, ref originalFormat, ref routeDocument);

                if (XtraMessageBox.Show("Ýletiyi dosyayla iliþkilendirmek ister misiniz?", "AvukatPro", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                {
                    AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak belge = new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak();
                    TList<AV001_TDIE_BIL_BELGE> lstbelge = new TList<AV001_TDIE_BIL_BELGE>();
                    AV001_TDIE_BIL_BELGE blg = new AV001_TDIE_BIL_BELGE();
                    blg.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();
                    blg.BELGEYI_YAZAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
                    blg.BELGE_TUR_ID = 7;
                    blg.SUC_OLAY_VADE_TARIHI = DateTime.Now;
                    blg.YAZILMA_TARIHI = DateTime.Now;
                    blg.BELGE_NO = BelgeNoGetir();
                    blg.BELGE_ADI = System.IO.Path.GetFileName(fileName);
                    blg.DOSYA_ADI = fileName;
                    blg.DOKUMAN_UZANTI = new System.IO.FileInfo(fileName).Extension.Substring(1);
                    blg.STAMP = 0;

                    if (System.IO.File.Exists(fileName))
                    {
                        System.IO.FileStream fss = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
                        byte[] veri = new byte[fss.Length];
                        fss.Read(veri, 0, veri.Length);
                        blg.ICERIK = veri;
                        fss.Close();

                        //System.IO.File.Delete(fileName);
                    }

                    blg.ESAS_NO = MyHazirlik.HAZIRLIK_ESAS_NO;
                    blg.ADLI_BIRIM_ADLIYE_ID = MyHazirlik.ADLI_BIRIM_ADLIYE_ID;
                    blg.ADLI_BIRIM_GOREV_ID = MyHazirlik.ADLI_BIRIM_GOREV_ID;
                    blg.ADLI_BIRIM_NO_ID = MyHazirlik.ADLI_BIRIM_NO_ID;
                    lstbelge.Add(blg);

                    switch (MyHazirlik.TableName)
                    {
                        case "AV001_TI_BIL_FOY":
                            belge.ucBelgeKayitUfak1.ModulID = 1;
                            break;

                        case "AV001_TD_BIL_FOY":
                            belge.ucBelgeKayitUfak1.ModulID = 2;
                            break;

                        case "AV001_TD_BIL_HAZIRLIK":
                            belge.ucBelgeKayitUfak1.ModulID = 3;
                            break;

                        case "AV001_TDI_BIL_SOZLESME":
                            belge.ucBelgeKayitUfak1.ModulID = 5;
                            break;

                        case "AV001_TDIE_BIL_PROJE":
                            belge.ucBelgeKayitUfak1.ModulID = 11;
                            break;
                        default:
                            break;
                    }

                    belge.MyDataSource = lstbelge;
                    belge.OpenedRecord = MyHazirlik;
                    belge.Record = lstbelge[0];

                    //       belge.ucBelgeKayitUfak1.Saved += ucBelgeKayitUfak1_Saved;
                    belge.ucBelgeKayitUfak1.Duzenle = true;
                    belge.ucBelgeKayitUfak1.KayitIlistir(null, null);
                    belge.ucBelgeKayitUfak1.c_lueModul.Enabled = false;
                    belge.ucBelgeKayitUfak1.c_lueDosya.Enabled = false;
                    belge.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    belge.MdiParent = null;
                    belge.ShowDialog();
                }
            }
        }

        private void bBtnWord_ItemClick(object sender, EventArgs e)
        {
            WordAc();
        }

        private void WordAc()
        {
            object missing = System.Reflection.Missing.Value;

            //object Visible = true;
            object start1 = 0;

            //object end1 = 0;
            WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
            adoc = WordApp.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            Microsoft.Office.Interop.Word.Range rng = adoc.Range(ref start1, ref missing);

            //WordApp.DocumentBeforeSave += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeSaveEventHandler(WordApp_DocumentBeforeSave);
            WordApp.DocumentBeforeClose += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeCloseEventHandler(WordApp_DocumentBeforeClose);
            adoc.Save();
            WordApp.Visible = true;
        }

        #endregion Word

        #region Outlook

        public bool Mode { get; set; }

        public string Subject { get; set; }

        private void bBtnOutlook_ItemClick(object sender, EventArgs e)
        {
            OutlookAc();
        }

        private void objOutlook_ItemSend(object item, ref bool cancel)
        {
            Subject = ((Microsoft.Office.Interop.Outlook.MailItem)item).Subject;
            ((Microsoft.Office.Interop.Outlook.MailItem)item).SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\temporary.msg", Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
            Mode = true;
        }

        private void OutlookAc()
        {
            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\temporary.msg";
            Microsoft.Office.Interop.Outlook.Application objOutlook = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem mic = (Microsoft.Office.Interop.Outlook.MailItem)(objOutlook.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem));

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (MyHazirlik.SIKAYET_KONU_ID.HasValue)
                sb.Append(AvukatPro.Services.Implementations.DosyaService.GetTakipTalepById((int)MyHazirlik.SIKAYET_KONU_ID));
            if (MyHazirlik.ADLI_BIRIM_ADLIYE_ID.HasValue)
                sb.Append(" - " + AvukatPro.Services.Implementations.DosyaService.GetAdliBirimAdliyeById((int)MyHazirlik.ADLI_BIRIM_ADLIYE_ID));
            if (MyHazirlik.ADLI_BIRIM_NO_ID.HasValue)
                sb.Append(" / " + AvukatPro.Services.Implementations.DosyaService.GetAdliBirimNoById((int)MyHazirlik.ADLI_BIRIM_NO_ID));
            if (MyHazirlik.ADLI_BIRIM_GOREV_ID.HasValue)
                sb.Append(" / " + AvukatPro.Services.Implementations.DosyaService.GetAdliBirimGorevById((int)MyHazirlik.ADLI_BIRIM_GOREV_ID));

            sb.Append(" - " + MyHazirlik.HAZIRLIK_ESAS_NO);

            mic.Subject = sb.ToString();

            DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(MyHazirlik, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_HAZIRLIK>));
            var u = MyHazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection;
            string emails = "";
            AV001_TDI_BIL_CARI ins = new AV001_TDI_BIL_CARI();
            for (int run = 0; run < u.Count; run++)
            {
                ins = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(u[run].CARI_ID.Value);
                if (!String.IsNullOrEmpty(ins.EMAIL_1))
                    emails += ins.EMAIL_1 + "; ";
                if (!String.IsNullOrEmpty(ins.EMAIL_2))
                    emails += ins.EMAIL_2 + "; ";
            }
            if (emails.Length > 2)
                mic.To = emails.Substring(0, emails.Length - 2);

            objOutlook.ItemSend += new Microsoft.Office.Interop.Outlook.ApplicationEvents_11_ItemSendEventHandler(objOutlook_ItemSend);

            mic.Display(true);

            bool control = false;
            try
            { bool g = mic.Saved; control = g; }
            catch { control = false; }

            if (Mode || control)
            {
                if (!Mode && control)
                    try
                    {
                        mic.SaveAs(fileName, Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                Mode = control = false;
                if (XtraMessageBox.Show("Ýletiyi dosyayla iliþkilendirmek ister misiniz?", "AvukatPro", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                {
                    using (AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak belge = new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak())
                    {
                        TList<AV001_TDIE_BIL_BELGE> lstbelge = new TList<AV001_TDIE_BIL_BELGE>();
                        AV001_TDIE_BIL_BELGE blg = new AV001_TDIE_BIL_BELGE();
                        blg.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();
                        blg.BELGEYI_YAZAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
                        blg.BELGE_TUR_ID = 20;
                        blg.SUC_OLAY_VADE_TARIHI = DateTime.Now;
                        blg.YAZILMA_TARIHI = DateTime.Now;
                        blg.BELGE_NO = BelgeNoGetir();
                        blg.BELGE_ADI = Subject;
                        Subject = "";
                        blg.DOSYA_ADI = fileName;
                        blg.DOKUMAN_UZANTI = new System.IO.FileInfo(fileName).Extension.Substring(1);
                        blg.STAMP = 0;

                        if (System.IO.File.Exists(fileName))
                        {
                            System.IO.FileStream fss = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
                            byte[] veri = new byte[fss.Length];
                            fss.Read(veri, 0, veri.Length);
                            blg.ICERIK = veri;
                            fss.Close();
                            System.IO.File.Delete(fileName);
                        }

                        blg.ESAS_NO = MyHazirlik.HAZIRLIK_ESAS_NO;
                        blg.ADLI_BIRIM_ADLIYE_ID = MyHazirlik.ADLI_BIRIM_ADLIYE_ID;
                        blg.ADLI_BIRIM_GOREV_ID = MyHazirlik.ADLI_BIRIM_GOREV_ID;
                        blg.ADLI_BIRIM_NO_ID = MyHazirlik.ADLI_BIRIM_NO_ID;
                        lstbelge.Add(blg);

                        switch (MyHazirlik.TableName)
                        {
                            case "AV001_TI_BIL_FOY":
                                belge.ucBelgeKayitUfak1.ModulID = 1;
                                break;

                            case "AV001_TD_BIL_FOY":
                                belge.ucBelgeKayitUfak1.ModulID = 2;
                                break;

                            case "AV001_TD_BIL_HAZIRLIK":
                                belge.ucBelgeKayitUfak1.ModulID = 3;
                                break;

                            case "AV001_TDI_BIL_SOZLESME":
                                belge.ucBelgeKayitUfak1.ModulID = 5;
                                break;

                            case "AV001_TDIE_BIL_PROJE":
                                belge.ucBelgeKayitUfak1.ModulID = 11;
                                break;
                            default:
                                break;
                        }

                        belge.MyDataSource = lstbelge;
                        belge.OpenedRecord = MyHazirlik;
                        belge.Record = lstbelge[0];

                        //       belge.ucBelgeKayitUfak1.Saved += ucBelgeKayitUfak1_Saved;
                        belge.ucBelgeKayitUfak1.Duzenle = true;
                        belge.ucBelgeKayitUfak1.KayitIlistir(null, null);
                        belge.ucBelgeKayitUfak1.c_lueModul.Enabled = false;
                        belge.ucBelgeKayitUfak1.c_lueDosya.Enabled = false;
                        belge.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        belge.MdiParent = null;
                        belge.ShowDialog();
                    }
                }
            }
        }

        #endregion Outlook

        #region Excel

        private Microsoft.Office.Interop.Excel.Application app = null;

        //private Microsoft.Office.Interop.Excel.Range workSheet_range = null;
        private bool controller = false;

        private Microsoft.Office.Interop.Excel.Workbook workbook = null;

        private Microsoft.Office.Interop.Excel.Worksheet worksheet = null;

        protected void app_WorkbookBeforeClose(Microsoft.Office.Interop.Excel.Workbook wb, ref bool I)
        {
            if (controller)
            {
                controller = false;
                return;
            }

            controller = true;

            if (!wb.Saved)
                if (XtraMessageBox.Show("Döküman kaydedilmedi. Kaydetmek istiyormusunuz?", "Uyarý", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    wb.SaveAs();

            string filename = wb.FullName;
            if (wb.Saved && !string.IsNullOrEmpty(wb.FullName.Trim()))
            {
                wb.Close(false, "ddddd", false);

                if (XtraMessageBox.Show("Ýletiyi dosyayla iliþkilendirmek ister misiniz?", "AvukatPro", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                {
                    AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak belge = new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak();
                    TList<AV001_TDIE_BIL_BELGE> lstbelge = new TList<AV001_TDIE_BIL_BELGE>();
                    AV001_TDIE_BIL_BELGE blg = new AV001_TDIE_BIL_BELGE();
                    blg.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();
                    blg.BELGEYI_YAZAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
                    blg.BELGE_TUR_ID = 7;
                    blg.SUC_OLAY_VADE_TARIHI = DateTime.Now;
                    blg.YAZILMA_TARIHI = DateTime.Now;
                    blg.BELGE_NO = BelgeNoGetir();
                    blg.BELGE_ADI = System.IO.Path.GetFileName(filename);
                    blg.DOSYA_ADI = filename;
                    blg.DOKUMAN_UZANTI = new System.IO.FileInfo(filename).Extension.Substring(1);
                    blg.STAMP = 0;

                    if (System.IO.File.Exists(filename))
                    {
                        try
                        {
                            System.IO.FileStream fss = new System.IO.FileStream(filename, System.IO.FileMode.Open);
                            byte[] veri = new byte[fss.Length];
                            fss.Read(veri, 0, veri.Length);
                            blg.ICERIK = veri;
                            fss.Close();

                            //System.IO.File.Delete(fileName);
                        }
                        catch { }
                    }

                    blg.ESAS_NO = MyHazirlik.HAZIRLIK_ESAS_NO;
                    blg.ADLI_BIRIM_ADLIYE_ID = MyHazirlik.ADLI_BIRIM_ADLIYE_ID;
                    blg.ADLI_BIRIM_GOREV_ID = MyHazirlik.ADLI_BIRIM_GOREV_ID;
                    blg.ADLI_BIRIM_NO_ID = MyHazirlik.ADLI_BIRIM_NO_ID;
                    lstbelge.Add(blg);

                    switch (MyHazirlik.TableName)
                    {
                        case "AV001_TI_BIL_FOY":
                            belge.ucBelgeKayitUfak1.ModulID = 1;
                            break;

                        case "AV001_TD_BIL_FOY":
                            belge.ucBelgeKayitUfak1.ModulID = 2;
                            break;

                        case "AV001_TD_BIL_HAZIRLIK":
                            belge.ucBelgeKayitUfak1.ModulID = 3;
                            break;

                        case "AV001_TDI_BIL_SOZLESME":
                            belge.ucBelgeKayitUfak1.ModulID = 5;
                            break;

                        case "AV001_TDIE_BIL_PROJE":
                            belge.ucBelgeKayitUfak1.ModulID = 11; //Klasör
                            break;
                        default:
                            break;
                    }

                    belge.MyDataSource = lstbelge;
                    belge.OpenedRecord = MyHazirlik;
                    belge.Record = lstbelge[0];

                    //belge.ucBelgeKayitUfak1.Saved += ucBelgeKayitUfak1_Saved;
                    belge.ucBelgeKayitUfak1.Duzenle = true;
                    belge.ucBelgeKayitUfak1.KayitIlistir(null, null);
                    belge.ucBelgeKayitUfak1.c_lueModul.Enabled = false;
                    belge.ucBelgeKayitUfak1.c_lueDosya.Enabled = false;
                    belge.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    belge.MdiParent = null;
                    belge.ShowDialog();
                }
            }
            else app.Quit();
        }

        private void bBtnExcel_ItemClick(object sender, EventArgs e)
        {
            ExcelAc();
        }

        private void ExcelAc()
        {
            try
            {
                object missing = System.Reflection.Missing.Value;
                app = new Microsoft.Office.Interop.Excel.Application();
                app.WorkbookBeforeClose += new Microsoft.Office.Interop.Excel.AppEvents_WorkbookBeforeCloseEventHandler(app_WorkbookBeforeClose);
                app.Visible = true;
                workbook = app.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                workbook.Save();
            }
            catch { }
        }

        #endregion Excel

        #endregion Editor,Word,Outlook,Excell,Pdf button click

        #endregion click

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ucSorusturmaCore1.ucSorusturmaGridler1.ucIliskiDetay4.GetList(MyHazirlik.ID, AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.HAZIRLIK_DOSYASI);

            if (MyHazirlik != null)
            {
                DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(MyHazirlik, false, DeepLoadType.IncludeChildren,
                                                                      typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI>));
                var detay = DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_HAZIRLIK_ID(MyHazirlik.ID);

                if (MyHazirlik.AV001_TDI_BIL_KAYIT_ILISKICollection.Count > 0 || detay.Count > 0)
                    c_titemIliskiliDosyalar.Image =
                        global::AdimAdimDavaKaydi.Properties.Resources.iliskili_dosyalar_red_16x16;
                else
                    c_titemIliskiliDosyalar.Image =
                        global::AdimAdimDavaKaydi.Properties.Resources.iliskili_dosyalar_mavi_16x16;
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += bBtnKaydet_ItemClick;
            this.Button_Yeni_Click += bBtnYeni_ItemClick;

            //this.Button_Yazdir_Click += bBtnYazdir_ItemClick;
            this.Button_Ajanda_Click += bBtnTakipAjandasi_ItemClick;
            this.Button_TakipYazismalari_Click += bBtnTakipYazismalari_ItemClick;
            this.Button_Editor_Click += bBtnEditor_ItemClick;
            this.Button_PDF_Click += bBtnPDF_ItemClick;
            this.Button_Excel_Click += bBtnExcel_ItemClick;
            this.Button_Outlook_Click += bBtnOutlook_ItemClick;
            this.Button_Word_Click += bBtnWord_ItemClick;
            this.Button_Ac_Click += bBtnAc_ItemClick;
            this.Button_IliskiliDosyalar_Click += rFrmSorusturmaTakip_Button_IliskiliDosyalar_Click;
        }

        private void rFrmSorusturmaTakip_Button_IliskiliDosyalar_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.frmKayitIliski frm = new AdimAdimDavaKaydi.Forms.frmKayitIliski();
            frm.MyHazirlik = MyHazirlik;
            frm.FormClosed += frm_FormClosed;
            frm.Show();
        }

        void tabDavaBilg_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabDavaBilg.SelectedTabPageIndex == 1)
            {
                if (ucSorusturmaCore1.ucSorusturmaGridler1.MyHazirlikFoy == null)
                    ucSorusturmaCore1.ucSorusturmaGridler1.MyHazirlikFoy = this.MyHazirlik;
            }
        }

        void btnDavaDosyasiAc_Click(object sender, System.EventArgs e)
        {
            AdimAdimDavaKaydi.Util.DavaCreated DC = new AdimAdimDavaKaydi.Util.DavaCreated();

            //if (AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme == null)
            //    AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme = AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.GelismeBul(MyFoy);

            //DC.MalBeyaniDavasýAc(AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme, MyFoy);

            DC.SorusturmaDavaDosyasiOlustur(MyHazirlik);
        }

        private void btnKlasoreBagla_Click(object sender, EventArgs e)
        {
            if (btnKlasoreBagla.Tag.ToString() == "BAÐLA")
            {
                popupKlasoreBagla.Visible = !popupKlasoreBagla.Visible;
                popupKlasoreBagla.BringToFront();
            }
            else
            {
                if (MessageBox.Show("Ýþleme devam etmek istiyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataRepository.AV001_TDIE_BIL_PROJE_HAZIRLIKProvider.Delete(DataRepository.AV001_TDIE_BIL_PROJE_HAZIRLIKProvider.GetByHAZIRLIK_ID(HazirlikList[0].ID));
                    MessageBox.Show("Ýþlem Tamamlandý.", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnKlasoreBagla.Tag = "BAÐLA";
                    btnKlasoreBagla.Text = "SORUÞTURMA DOSYASINI KLASÖRE BAÐLA";
                }
            }
        }

        private void btnBagla_Click(object sender, EventArgs e)
        {
            //Bu butona dosya herhangi bir proje baðlý olduðunda ulaþýlamadýðýndan proje icra tablosunda bu takip var mý diye kontrol yapmaya gerek kalmadý. MB

            if (lueKlasor.EditValue == null)
            {
                MessageBox.Show("Takibi baðlamak istediðiniz klasörü seçmelisiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            AV001_TDIE_BIL_PROJE_HAZIRLIK nnProjeIcra = new AV001_TDIE_BIL_PROJE_HAZIRLIK();
            nnProjeIcra.PROJE_ID = (int)lueKlasor.EditValue;
            nnProjeIcra.HAZIRLIK_ID = HazirlikList[0].ID;

            try
            {
                DataRepository.AV001_TDIE_BIL_PROJE_HAZIRLIKProvider.Save(nnProjeIcra);
                MessageBox.Show("Ýþlem Tamamlandý.", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnKlasoreBagla.Tag = "ÇIKAR";
                btnKlasoreBagla.Text = "SORUÞTURMA DOSYASINI KLASÖRDEN ÇIKAR";

                MyProje = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID((int)lueKlasor.EditValue);
                if (MyProje.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_SORUMLU>));

                bndProje.DataSource = MyProje;

                //BelgeUtil.Inits.perCariGetir(rlueYetkiliCari);
                //BelgeUtil.Inits.ProjeOzelKodGetir(lueSube.Properties);
            }
            catch
            {
                MessageBox.Show("Ýþlem Tamamlanamadý.", "ÝPTAL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            popupKlasoreBagla.Visible = false;
        }

        #region <MB-20100524>

        //Takip Ekraný üzerinden (varsa)klasör ekranýna gitmesi saðlandý.

        private void sbtnKlasoreGonder_Click(object sender, EventArgs e)
        {
            if (MyProje == null)
            {
                XtraMessageBox.Show("Dosyada Klasör Bulunmamaktadýr.", "BÝLGÝ", MessageBoxButtons.OK,
                                    MessageBoxIcon.Stop);
                return;
            }
            AdimAdimDavaKaydi.Forms.frmKlasorYeni klasor = new AdimAdimDavaKaydi.Forms.frmKlasorYeni();
            TList<AV001_TDIE_BIL_PROJE> projeler = new TList<AV001_TDIE_BIL_PROJE>();
            projeler.Add(MyProje);
            klasor.Show(projeler);
        }

        #endregion <MB-20100524>

        #region Soruþturma Hýzlý Eriþim Menüsü Button Click

        private void btnBelge_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak frm = new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.OpenedRecord = MyHazirlik;
            frm.Show();
        }

        private void btnDosyaIliskilendirme_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.frmKayitIliski frm = new AdimAdimDavaKaydi.Forms.frmKayitIliski();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.MyHazirlik = MyHazirlik;
            frm.Show();
        }

        private void btnEditorAc_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor editor = new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor();
            editor.MdiParent = AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm;
            editor.Show();
        }

        private void btnEvrakTebligat_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit frm = new AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyHazirlik);
        }

        private void btnExcelAc_Click(object sender, EventArgs e)
        {
            ExcelAc();
        }

        private void btnGelisme_Click(object sender, EventArgs e)
        {
            frmSorusturmaHikaye hikaye = new frmSorusturmaHikaye();
            hikaye.StartPosition = FormStartPosition.CenterParent;
            hikaye.MyFoy = MyHazirlik;
            hikaye.Show();
        }

        private void btnGorusme_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit frm = new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyHazirlik);
        }

        private void btnIsEmri_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frm = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ucIsKayitUfak1.OpenedRecord = MyHazirlik;
            frm.ucIsKayitUfak1.ModulID = 3;
            frm.Show();
        }

        private void btnKarakolSureci_Click(object sender, EventArgs e)
        {
            //frmSorusturmaKarakol frm = new frmSorusturmaKarakol();
            //frm.MySorusturma = MyHazirlik;
            //frm.Text = "Soruþturma Karakol Bilgileri";
            //frm.Show(MyHazirlik.AV001_TD_BIL_HAZIRLIK_SURECCollection, 1);
            frmSorusturmaKarakol Ssurec = new frmSorusturmaKarakol();
            Ssurec.Tip = 1;
            Ssurec.MySorusturma = MyHazirlik;
            Ssurec.Text = "Soruþturma Karakol Bilgileri";
            Ssurec.Show();
        }

        private void btnKesif_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Dava.rFrmCelseKayit frm = new AdimAdimDavaKaydi.Forms.Dava.rFrmCelseKayit();
            frm.StartPosition = FormStartPosition.CenterParent;

            //frm.Show(MyHazirlik);
        }

        private void btnMasrafAvans_Click(object sender, EventArgs e)
        {
            IcraTakipForms.frmMasrafAvansKayitHizli frm = new AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli();
            frm.AcilisYeri = AdimAdimDavaKaydi.IcraTakipForms.MasrafFormuAcilisiYeri.TakipEkrani;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyHazirlik);
        }

        private void btnMuvekkilTalimati_Click(object sender, EventArgs e)
        {
        }

        private void btnNot_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Dava.rFrmDavaGenelNotlar frm = new AdimAdimDavaKaydi.Forms.Dava.rFrmDavaGenelNotlar();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyHazirlik);
        }

        private void btnOutlookAc_Click(object sender, EventArgs e)
        {
            OutlookAc();
        }

        private void btnSavcilikSureci_Click(object sender, EventArgs e)
        {
            //frmSorusturmaKarakol frm = new frmSorusturmaKarakol();
            //frm.MySorusturma = MyHazirlik;
            //frm.Text = "Soruþturma Savcýlýk Bilgileri";
            //frm.Show(MyHazirlik.AV001_TD_BIL_HAZIRLIK_SURECCollection, 2);
            frmSorusturmaKarakol Ssurec = new frmSorusturmaKarakol();
            Ssurec.MySorusturma = MyHazirlik;
            Ssurec.Text = "Soruþturma Savcýlýk Bilgileri";
            Ssurec.Show(MyHazirlik.AV001_TD_BIL_HAZIRLIK_SURECCollection, 2);
        }

        private void btnSikayetNeden_Click(object sender, EventArgs e)
        {
            frmSikayetNeden frm = new frmSikayetNeden();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.MySorusturma = MyHazirlik;
            frm.Show();
        }

        private void btnSorguMahkemesi_Click(object sender, EventArgs e)
        {
            frmSorusturmaKarakol frm = new frmSorusturmaKarakol();
            frm.MySorusturma = MyHazirlik;
            frm.Text = "Soruþturma Sorgu Mahkemesi Bilgileri";
            frm.Show(MyHazirlik.AV001_TD_BIL_HAZIRLIK_SURECCollection, 3);
        }

        private void btnTutuklamaGozalti_Click(object sender, EventArgs e)
        {
            frmSorusturmaTutuklanma frm = new frmSorusturmaTutuklanma();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.MySorusturma = MyHazirlik;
            frm.Show();
        }

        private void btnWordAc_Click(object sender, EventArgs e)
        {
            WordAc();
        }

        private void btnxxx_Click(object sender, EventArgs e)
        {
            //
        }

        #endregion Soruþturma Hýzlý Eriþim Menüsü Button Click
        
        private void dpTarafbilgileri_DockChanged(object sender, EventArgs e)
        {

        }

    }

    public class FrmSorusturmaDosyaKayit : EventArgs
    {
        public FrmSorusturmaDosyaKayit(rfrmSorusturmaGiris form)
        {
            MyForm = form;
        }

        public rfrmSorusturmaGiris MyForm { get; set; }
    }

}