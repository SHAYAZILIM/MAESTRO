using System;
using System.Collections.Generic;
using System.ComponentModel;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using AdimAdimDavaKaydi.Util.BaseClasses;
using System.Linq;

namespace AdimAdimDavaKaydi.Sorusturma.UserControls
{
    public partial class ucSorusturmaTarafBilgileri : AvpXUserControl
    {
        public ucSorusturmaTarafBilgileri()
        {
            InitializeComponent();
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
        }

        #region Fields

        private static int _currTarafId;
        private AV001_TD_BIL_HAZIRLIK _myHazirlik;
        private TList<AV001_TD_BIL_HAZIRLIK_TARAF> _sikayetEden = new TList<AV001_TD_BIL_HAZIRLIK_TARAF>();
        private TList<AV001_TD_BIL_HAZIRLIK_TARAF> _sikayetEdilen = new TList<AV001_TD_BIL_HAZIRLIK_TARAF>();
        private TList<AV001_TD_BIL_HAZIRLIK_SORUMLU> _sorumluAvukat = new TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>();

        private TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN> SikayetNedenleri =
            new TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN>();

        #endregion Fields

        #region Properties

        public static int CurrTarafID
        {
            get { return ucSorusturmaTarafBilgileri._currTarafId; }
            set { ucSorusturmaTarafBilgileri._currTarafId = value; }
        }

        public AV001_TD_BIL_HAZIRLIK MyHazirlik
        {
            get { return _myHazirlik; }
            set
            {
                _myHazirlik = value;
                if (_myHazirlik != null)
                {
                    DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(MyHazirlik, true, DeepLoadType.IncludeChildren
                                                                          , typeof(TList<AV001_TDI_BIL_GORUSME>)
                        );

                    TarafGorusmeleriBinding();
                    SetHazirlik();
                }
            }
        }

        public TList<AV001_TD_BIL_HAZIRLIK_TARAF> SikayetEden
        {
            get { return _sikayetEden; }
            set { _sikayetEden = value; }
        }

        [Browsable(false)]
        public List<RepositoryItemLookUpEdit> SikayetEdenTarafControls { get; set; }

        public TList<AV001_TD_BIL_HAZIRLIK_TARAF> SikayetEdilen
        {
            get { return _sikayetEdilen; }
            set { _sikayetEdilen = value; }
        }

        [Browsable(false)]
        public List<RepositoryItemLookUpEdit> SikayetEdilenTarafControls { get; set; }

        public TList<AV001_TD_BIL_HAZIRLIK_SORUMLU> SorumluAvk
        {
            get { return _sorumluAvukat; }
            set { _sorumluAvukat = value; }
        }

        #endregion Properties

        #region Enums

        public enum LookUpCustomButtons
        {
            Previous = 0,
            Next = 1
        }

        public enum SikayetTarafKodu
        {
            SikayetEden = 1,
            SikayetEdilen = 3,
            Diger = 2
        }

        #endregion Enums

        #region Events


        #endregion Events

        #region Private Methods

        private void AddSorumlu(AV001_TD_BIL_HAZIRLIK_SORUMLU trf)
        {
            AV001_TD_BIL_HAZIRLIK_SORUMLU temp =
                MyHazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.Find(AV001_TD_BIL_HAZIRLIK_SORUMLUColumn.CARI_ID,
                                                                        trf.CARI_ID.Value);
            if (temp == null)
            {
                trf.CARI_IDSource = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(trf.CARI_ID.Value);
                MyHazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.Add(trf);
            }
        }

        private void AddTaraf(AV001_TD_BIL_HAZIRLIK_TARAF trf)
        {
            AV001_TD_BIL_HAZIRLIK_TARAF temp =
                MyHazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection.Find(AV001_TD_BIL_HAZIRLIK_TARAFColumn.CARI_ID,
                                                                      trf.CARI_ID.Value);
            if (temp == null)
            {
                trf.CARI_IDSource = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(trf.CARI_ID.Value);
                MyHazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection.Add(trf);
                TarafRefresh(true);
            }
        }

        private void AV001_TDI_BIL_GORUSMECollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_GORUSME addNew = new AV001_TDI_BIL_GORUSME();
            addNew.TARIH = DateTime.Now;
            e.NewObject = addNew;
        }

        private void LoadData()
        {
            BelgeUtil.Inits.perCariGetir(rLueCariler);
            BelgeUtil.Inits.TarafSifatGetirSikayetEden(rLueSikayetEdenSifat);
            BelgeUtil.Inits.TarafSifatGetirSikayetEdilen(rLueSikayetEdilenSifat);
            BelgeUtil.Inits.TarafKoduGetir(rLueSikayetEdenTK);
            BelgeUtil.Inits.TarafKoduGetir(rLueSikayetEdilenTK);
            BelgeUtil.Inits.AktifAvukatlariGetir(grSorumluAvukat);
        }

        private void SetHazirlik()
        {
            DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(MyHazirlik, true, DeepLoadType.IncludeChildren
                                                                  , typeof(TList<AV001_TD_BIL_HAZIRLIK_TARAF>)
                                                                  , typeof(TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>));

            TarafBind();

            //MyHazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.AddingNew += new AddingNewEventHandler(AV001_TD_BIL_HAZIRLIK_SORUMLUCollection_AddingNew);

            foreach (AV001_TD_BIL_HAZIRLIK_TARAF trf in MyHazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection)
            {
                if (trf.CARI_IDSource == null)
                    DataRepository.AV001_TD_BIL_HAZIRLIK_TARAFProvider.DeepLoad(trf, false, DeepLoadType.IncludeChildren,
                                                                                typeof(AV001_TDI_BIL_CARI),
                                                                                typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>
                                                                                    ));

                trf.CARI_IDSource.ColumnChanged += CARI_IDSource_ColumnChanged;
            }
        }

        private void TarafBind()
        {
            BackgroundWorker bWorker = new BackgroundWorker();
            TList<AV001_TDI_BIL_CARI> carilist = new TList<AV001_TDI_BIL_CARI>();
            bWorker.DoWork += delegate
                                  {
                                      if (SikayetEden == null)
                                          SikayetEden = new TList<AV001_TD_BIL_HAZIRLIK_TARAF>();
                                      if (SikayetEdilen == null)
                                          SikayetEdilen = new TList<AV001_TD_BIL_HAZIRLIK_TARAF>();
                                      if (SorumluAvk == null)
                                          SorumluAvk = new TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>();

                                      SikayetEden.AddingNew += SikayetEden_AddingNew;
                                      SikayetEdilen.AddingNew += SikayetEdilen_AddingNew;

                                      //SorumluAvk.AddingNew += SorumluAvk_AddingNew;

                                      SikayetEden.Clear();
                                      SikayetEdilen.Clear();
                                      SorumluAvk.Clear();

                                      foreach (
                                          AV001_TD_BIL_HAZIRLIK_TARAF trf in
                                              MyHazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection)
                                      {
                                          if (trf.CARI_IDSource == null && trf.CARI_ID != null || trf.CARI_ID > 0)
                                          {
                                              DataRepository.AV001_TD_BIL_HAZIRLIK_TARAFProvider.DeepLoad(trf, false,
                                                                                                          DeepLoadType.
                                                                                                              IncludeChildren,
                                                                                                          typeof(
                                                                                                              AV001_TDI_BIL_CARI
                                                                                                              ));
                                              carilist.Add(trf.CARI_IDSource);
                                          }
                                          if (trf.TARAF_SIFAT_IDSource == null)
                                              DataRepository.AV001_TD_BIL_HAZIRLIK_TARAFProvider.DeepLoad(trf, false,
                                                                                                          DeepLoadType.
                                                                                                              IncludeChildren,
                                                                                                          typeof(
                                                                                                              TDIE_KOD_TARAF_SIFAT
                                                                                                              ));
                                          if (trf.TARAF_SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN")
                                          {
                                              if (trf.TARAF_SIFAT_ID != null)
                                                  trf.TARAF_SIFAT_ID = trf.TARAF_SIFAT_ID;
                                              else
                                                  trf.TARAF_SIFAT_ID = 7;
                                              SikayetEden.Add(trf);
                                          }
                                          if (trf.TARAF_SIFAT_IDSource.HANGI_TARAFI == "DAVA EDÝLEN")
                                          {
                                              if (trf.TARAF_SIFAT_ID != null)
                                                  trf.TARAF_SIFAT_ID = trf.TARAF_SIFAT_ID;
                                              else
                                                  trf.TARAF_SIFAT_ID = 8;
                                              if (!SikayetEden.Contains(trf))
                                              {
                                                  SikayetEdilen.Add(trf);
                                              }
                                          }
                                      }

                                      foreach (
                                          AV001_TD_BIL_HAZIRLIK_SORUMLU srm in
                                              MyHazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection)
                                      {
                                          if (srm.CARI_IDSource == null)
                                          {
                                              DataRepository.AV001_TD_BIL_HAZIRLIK_SORUMLUProvider.DeepLoad(srm, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                                              carilist.Add(srm.CARI_IDSource);
                                              SorumluAvk.Add(srm);
                                          }
                                          else
                                          {
                                              carilist.Add(srm.CARI_IDSource);
                                              SorumluAvk.Add(srm);
                                          }
                                      }
                                  };

            bWorker.RunWorkerCompleted += delegate
                                              {
                                                  //SikayetEdenler
                                                  gcSikayetEdenler.BeginUpdate();
                                                  gcSikayetEdenler.DataSource = SikayetEden;
                                                  gcSikayetEdenler.EndUpdate();

                                                  //Avukatlar
                                                  gcSorumlular.BeginUpdate();
                                                  gcSorumlular.DataSource = SorumluAvk;
                                                  gcSorumlular.EndUpdate();

                                                  //SikayetEdilenler
                                                  gcSikayetEdilenler.BeginUpdate();
                                                  gcSikayetEdilenler.DataSource = SikayetEdilen;
                                                  gcSikayetEdilenler.EndUpdate();

                                                  AV001_TD_BIL_HAZIRLIK_TARAF seciliTaraf = (AV001_TD_BIL_HAZIRLIK_TARAF)SikayetEdilen[0];
                                                  if (seciliTaraf.CARI_ID.HasValue)
                                                  {
                                                      VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                                                      adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
                                                      gcIletisimBilgileri.DataSource = adres;
                                                  }
                                              };
            bWorker.RunWorkerAsync();
        }

        /// <summary>
        /// AV001_TDI_BIL_GORUSME
        /// </summary>
        ///
        private void TarafGorusmeleriBinding()
        {
            MyHazirlik.AV001_TDI_BIL_GORUSMECollection.AddingNew += AV001_TDI_BIL_GORUSMECollection_AddingNew;

            if (MyHazirlik.AV001_TDI_BIL_GORUSMECollection.Count == 0)
                return;
            //MyHazirlik.AV001_TDI_BIL_GORUSMECollection.AddNew();
        }

        private void TarafRefresh(bool IsNew)
        {
            TList<AV001_TDI_BIL_CARI> carilist = new TList<AV001_TDI_BIL_CARI>();
            foreach (AV001_TD_BIL_HAZIRLIK_TARAF trf in MyHazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection)
            {
                if (trf.CARI_IDSource == null)
                    DataRepository.AV001_TD_BIL_HAZIRLIK_TARAFProvider.DeepLoad(trf, true, DeepLoadType.IncludeChildren,
                                                                                typeof(AV001_TDI_BIL_CARI));
                carilist.Add(trf.CARI_IDSource);
            }

            if (IsNew)
            {
                int i = MyHazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection.Count;
            }
        }

        #endregion Private Methods

        #region InitsMetotlar

        #endregion InitsMetotlar
        
        public static TList<AV001_TD_BIL_FOY> IliskiliDavaKayitlari(AV001_TD_BIL_HAZIRLIK MyFoy, List<DavaAdi> davaAdlari)
        {
            TList<AV001_TD_BIL_FOY> result = new TList<AV001_TD_BIL_FOY>();
            TList<AV001_TDI_BIL_KAYIT_ILISKI> kayitlar = KayitIliskiGetir(MyFoy.ID);

            if (kayitlar != null)
            {
                foreach (AV001_TDI_BIL_KAYIT_ILISKI master in kayitlar)
                {
                    List<int?> davaFoyIdList = (from item in master.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection where item.HEDEF_DAVA_FOY_ID.HasValue select item.HEDEF_DAVA_FOY_ID).ToList();
                    foreach (var id in davaFoyIdList)
                    {
                        var foy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)id);
                        if (foy != null && IsValid(foy.ID, davaAdlari))
                            result.Add(foy);
                    }
                }
            }

            return result;
        }

        public static TList<AV001_TDI_BIL_KAYIT_ILISKI> KayitIliskiGetir(int FoyId)
        {
            TList<AV001_TDI_BIL_KAYIT_ILISKI> result = new TList<AV001_TDI_BIL_KAYIT_ILISKI>();

            result = DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.Find(string.Format("KAYNAK_KAYIT_ID = {0}", FoyId));

            DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.DeepLoad(result, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>));

            return result;
        }

        

        public static bool IsValid(int davaFoyId, List<DavaAdi> davaAdlari) // Okan 20.08.2010
        {
            List<int> list = new List<int>();
            davaAdlari.ForEach(item => list.Add((int)item));
            return BelgeUtil.Inits.context.AV001_TD_BIL_FOYs.Count(item => item.ID == davaFoyId && item.AV001_TD_BIL_DAVA_NEDENs.Count(dn => dn.DAVA_NEDEN_KOD_ID.HasValue && list.Contains(dn.DAVA_NEDEN_KOD_ID.Value)) > 0 && item.AV001_TD_BIL_FOY_TARAFs.Count(t => t.CARI_ID == ucSorusturmaTarafBilgileri.CurrTarafID) > 0) > 0;
        }

        private void btnIletisimBilgileriDuzenle_Click(object sender, EventArgs e)
        {
            if (gcIletisimBilgileri.DataSource != null)
            {
                VList<per_CariKimlikIletisimBilgileri> guncellenecekCari = (VList<per_CariKimlikIletisimBilgileri>)gcIletisimBilgileri.DataSource;

                AV001_TDI_BIL_CARI cari = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(guncellenecekCari[0].ID);
                frmCariGenelGiris cariForms = new frmCariGenelGiris();
                cariForms.YeniKayitMi = false;
                cariForms.MyCari = cari;
                cariForms.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
                cariForms.Show();
            }
            else
                XtraMessageBox.Show("Güncellenecek þahýs seçiniz!");
        }

        private void gwSikayetEdenler_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle == gwSikayetEdenler.FocusedRowHandle)
            {
                AV001_TD_BIL_HAZIRLIK_TARAF seciliTaraf = (AV001_TD_BIL_HAZIRLIK_TARAF)gwSikayetEdenler.GetRow(e.RowHandle);
                if (seciliTaraf.CARI_ID.HasValue)
                {
                    VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                    adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
                    gcIletisimBilgileri.DataSource = adres;
                }
            }
        }

        private void gwSikayetEdilenler_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle == gwSikayetEdilenler.FocusedRowHandle)
            {
                AV001_TD_BIL_HAZIRLIK_TARAF seciliTaraf = (AV001_TD_BIL_HAZIRLIK_TARAF)gwSikayetEdilenler.GetRow(e.RowHandle);

                if (seciliTaraf.CARI_ID.HasValue)
                {
                    VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                    adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
                    gcIletisimBilgileri.DataSource = adres;
                }
            }
        }

        //    if (seciliTaraf.CARI_ID.HasValue)
        //    {
        //        VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
        //        adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
        //        gcIletisimBilgileri.DataSource = adres;
        //    }
        //}
        private void gwSorumluAvukat_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle == gwSorumluAvukat.FocusedRowHandle)
            {
                AV001_TD_BIL_HAZIRLIK_SORUMLU seciliAvukat = (AV001_TD_BIL_HAZIRLIK_SORUMLU)gwSorumluAvukat.GetRow(e.RowHandle);

                if (seciliAvukat.CARI_ID.HasValue)
                {
                    VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                    adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliAvukat.CARI_ID.ToString(), "ID");
                    gcIletisimBilgileri.DataSource = adres;
                }
            }
        }

        private void ucSorusturmaTarafBilgileri_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            LoadData();

            if (MyHazirlik == null)
                MyHazirlik = new AV001_TD_BIL_HAZIRLIK();

            MyHazirlik.AV001_TDI_BIL_GORUSMECollection.Sort("TARIH DESC");
            gwSikayetEdenler.ValidateRow += gwSikayetEdenler_ValidateRow;
            gwSikayetEdilenler.ValidateRow += gwSikayetEdilenler_ValidateRow;
            gwSorumluAvukat.ValidateRow += gwSorumluAvukat_ValidateRow;

            SikayetEden = new TList<AV001_TD_BIL_HAZIRLIK_TARAF>();
            SikayetEdilen = new TList<AV001_TD_BIL_HAZIRLIK_TARAF>();
            SorumluAvk = new TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>();
        }



        #region Columns_Changed

        private void CARI_IDSource_ColumnChanged(object sender, AV001_TDI_BIL_CARIEventArgs e)
        {
            #region Kimlik Bilgileri

            ////Kayýtlý Olan Son Kimlik Bilgilerini Alýnýyor.
            //if (carilist.AV001_TDI_BIL_CARI_KIMLIKCollection.Count > 0)
            //    carilist.AV001_TDI_BIL_CARI_KIMLIKCollection.Sort("KAYIT_TARIHI DESC");

            //lueKimlikTur.DataBindings.Clear();
            //lueKimlikTur.DataBindings.Add("EditValue", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "KIMLIK_ID", true);

            //txtTcNo.DataBindings.Clear();
            //txtTcNo.DataBindings.Add("Text", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "TC_KIMLIK_NO", true);

            //lueKimlikIl.DataBindings.Clear();
            //lueKimlikIl.DataBindings.Add("EditValue", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "NKO_IL_ID", true);

            //lueKimlikIlce.DataBindings.Clear();
            //lueKimlikIlce.DataBindings.Add("EditValue", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "NKO_ILCE_ID", true);

            //txtDYeri.DataBindings.Clear();
            //txtDYeri.DataBindings.Add("Text", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "DOGUM_YERI", true);

            //deDTarihi.DataBindings.Clear();
            //deDTarihi.DataBindings.Add("EditValue", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "DOGUM_TARIHI", true);

            //txtAnaAdi.DataBindings.Clear();
            //txtAnaAdi.DataBindings.Add("Text", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "ANA_ADI", true);

            //txtBabaAdi.DataBindings.Clear();
            //txtBabaAdi.DataBindings.Add("Text", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "BABA_ADI", true);

            //txtMah.DataBindings.Clear();
            //txtMah.DataBindings.Add("Text", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "NKO_MAHALLE_KOY", true);

            //txtCiltNo.DataBindings.Clear();
            //txtCiltNo.DataBindings.Add("Text", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "NKO_CILT_NO", true);

            //txtSeriNo.DataBindings.Clear();
            //txtSeriNo.DataBindings.Add("Text", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "BELGE_SERI_NO", true);

            //txtAileSira.DataBindings.Clear();
            //txtAileSira.DataBindings.Add("Text", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "NKO_AILE_SIRA_NO", true);

            //txtSira.DataBindings.Clear();
            //txtSira.DataBindings.Add("Text", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "NKO_SIRA_NO", true);

            //lueCinsiyet.DataBindings.Clear();
            //lueCinsiyet.DataBindings.Add("EditValue", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "CINSIYET_ID", true);

            //txtVerYeri.DataBindings.Clear();
            //txtVerYeri.DataBindings.Add("Text", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "CUZDANIN_VERILDIGI_YER", true);

            //lueMedeniHal.DataBindings.Clear();
            //lueMedeniHal.DataBindings.Add("EditValue", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "MEDENI_HAL_ID", true);

            //lueVerNedeni.DataBindings.Clear();
            //lueVerNedeni.DataBindings.Add("EditValue", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "CUZDANIN_VERILME_NEDENI_ID", true);

            //lueKanGrb.DataBindings.Clear();
            //lueKanGrb.DataBindings.Add("EditValue", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "KAN_GRUP_ID", true);

            //deVerT.DataBindings.Clear();
            //deVerT.DataBindings.Add("EditValue", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "CUZDANIN_VERILIS_TARIHI", true);

            //txtKayitNo.DataBindings.Clear();
            //txtKayitNo.DataBindings.Add("Text", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "CUZDANIN_KAYIT_NO", true);

            //txtOSoyadi.DataBindings.Clear();
            //txtOSoyadi.DataBindings.Add("Text", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "ONCEKI_SOYADI", true);

            //txtKizSoy.DataBindings.Clear();
            //txtKizSoy.DataBindings.Add("Text", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "ANNE_KIZLIK_SOYADI", true);

            //lueUyruk.DataBindings.Clear();
            //lueUyruk.DataBindings.Add("EditValue", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "UYRUK_ID", true);

            //txtBelgeNo.DataBindings.Clear();
            //txtBelgeNo.DataBindings.Add("Text", carilist.AV001_TDI_BIL_CARI_KIMLIKCollection, "BELGE_NO", true);

            #endregion Kimlik Bilgileri
        }

        #endregion Columns_Changed

        #region LookUpEdit_EventArgs

        private void gwSikayetEdenler_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
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
            if (e.Valid)
            {
                try
                {
                    AddTaraf(hazirliktrf);

                    #region Dosyaya yeni taraf eklediðinde,alacak neden taraflara yeni eklenen borçlu ekleniyor.

                    for (int i = 0; i < MyHazirlik.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection.Count; i++)
                    {
                        for (int j = 0;
                             j <
                             MyHazirlik.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection[i].
                                 AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection.Count;
                             j++)
                        {
                            if (MyHazirlik.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection[i].
                                    AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection.Find(
                                        AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFColumn.TARAF_CARI_ID,
                                        hazirliktrf.CARI_ID.Value) == null)
                            {
                                AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF t =
                                    MyHazirlik.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection[i].
                                        AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection.AddNew();
                                t.TARAF_CARI_ID = hazirliktrf.CARI_ID;
                                t.TARAF_CARI_IDSource = hazirliktrf.CARI_IDSource;
                            }
                        }
                    }

                    #endregion Dosyaya yeni taraf eklediðinde,alacak neden taraflara yeni eklenen borçlu ekleniyor.
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
            MyHazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection.Clear();
            MyHazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection.AddRange(SikayetEdilen);
            MyHazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection.AddRange(SikayetEden);
        }

        private void gwSikayetEdilenler_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
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
            if (e.Valid)
            {
                try
                {
                    AddTaraf(hazirliktrf);

                    #region Dosyaya yeni taraf eklediðinde,alacak neden taraflara yeni eklenen borçlu ekleniyor.

                    for (int i = 0; i < MyHazirlik.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection.Count; i++)
                    {
                        for (int j = 0;
                             j <
                             MyHazirlik.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection[i].
                                 AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection.Count;
                             j++)
                        {
                            if (MyHazirlik.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection[i].
                                    AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection.Find(
                                        AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFColumn.TARAF_CARI_ID,
                                        hazirliktrf.CARI_ID.Value) == null)
                            {
                                AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF t =
                                    MyHazirlik.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection[i].
                                        AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection.AddNew();
                                t.TARAF_CARI_ID = hazirliktrf.CARI_ID;
                                t.TARAF_CARI_IDSource = hazirliktrf.CARI_IDSource;
                            }
                        }
                    }

                    #endregion Dosyaya yeni taraf eklediðinde,alacak neden taraflara yeni eklenen borçlu ekleniyor.
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
            else
            {
                MyHazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection.Clear();
                MyHazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection.AddRange(SikayetEdilen);
                MyHazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection.AddRange(SikayetEden);
            }
        }

        private void gwSorumluAvukat_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TD_BIL_HAZIRLIK_SORUMLU rowAvukat = (AV001_TD_BIL_HAZIRLIK_SORUMLU)e.Row;
            if (!rowAvukat.CARI_ID.HasValue && rowAvukat.CARI_IDSource == null)
            {
                e.ErrorText = "Lütfen Bir Sorumlu Seçiniz." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (MyHazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.FindAll("CARI_ID", rowAvukat.CARI_ID.Value).Count > 0)
            {
                e.ErrorText = "Bu Sorumlu Zaten Eklenmiþ." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (e.Valid)
            {
                try
                {
                    AddSorumlu(rowAvukat);
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
            else
            {
                MyHazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.Clear();
                MyHazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.AddRange(SorumluAvk);
            }
        }

        #region AddNew

        private void SikayetEden_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_HAZIRLIK_TARAF addnew = e.NewObject as AV001_TD_BIL_HAZIRLIK_TARAF;

            if (e.NewObject == null)
                addnew = new AV001_TD_BIL_HAZIRLIK_TARAF();
            if (String.IsNullOrEmpty(((TList<TDI_KOD_TARAF>)rLueSikayetEdenTK.DataSource).Filter))
                addnew.TARAF_KODU = (int)TarafKodu.KarsiTaraf;
            else
            {
                string[] boll = ((TList<TDI_KOD_TARAF>)rLueSikayetEdenTK.DataSource).Filter.Split(' ');
                if (Convert.ToBoolean(boll[2]))
                {
                    addnew.TARAF_KODU = (int)TarafKodu.Muvekkil;
                }
                else
                {
                    addnew.TARAF_KODU = (int)TarafKodu.KarsiTaraf;
                }
            }
            e.NewObject = addnew;
        }

        private void SikayetEdilen_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_HAZIRLIK_TARAF addnew = e.NewObject as AV001_TD_BIL_HAZIRLIK_TARAF;
            if (e.NewObject == null)
                addnew = new AV001_TD_BIL_HAZIRLIK_TARAF();
            if (String.IsNullOrEmpty(((TList<TDI_KOD_TARAF>)rLueSikayetEdilenTK.DataSource).Filter))
                addnew.TARAF_KODU = (int)TarafKodu.KarsiTaraf;
            else
            {
                string[] boll = ((TList<TDI_KOD_TARAF>)rLueSikayetEdilenTK.DataSource).Filter.Split(' ');
                if (Convert.ToBoolean(boll[2]))
                {
                    addnew.TARAF_KODU = (int)TarafKodu.Muvekkil;
                }
                else
                {
                    addnew.TARAF_KODU = (int)TarafKodu.KarsiTaraf;
                }
            }
            e.NewObject = addnew;
        }

        #endregion AddNew

        #endregion LookUpEdit_EventArgs

        //private void gwSikayetEdenler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    if (e.FocusedRowHandle < 0)
        //        return;

        //    AV001_TD_BIL_HAZIRLIK_TARAF seciliTaraf = (AV001_TD_BIL_HAZIRLIK_TARAF)gwSikayetEdenler.GetRow(e.FocusedRowHandle);
        //    if (seciliTaraf.CARI_ID.HasValue)
        //    {
        //        VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
        //        adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
        //        gcIletisimBilgileri.DataSource = adres;
        //    }
        //}

        //private void gwSorumluAvukat_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    if (e.FocusedRowHandle < 0)
        //        return;

        //    AV001_TD_BIL_HAZIRLIK_SORUMLU seciliAvukat = (AV001_TD_BIL_HAZIRLIK_SORUMLU)gwSorumluAvukat.GetRow(e.FocusedRowHandle);

        //    if (seciliAvukat.CARI_ID.HasValue)
        //    {
        //        VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
        //        adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliAvukat.CARI_ID.ToString(), "ID");
        //        gcIletisimBilgileri.DataSource = adres;
        //    }
        //}

        //private void gwSikayetEdilenler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    if (e.FocusedRowHandle < 0)
        //        return;

        //    AV001_TD_BIL_HAZIRLIK_TARAF seciliTaraf = (AV001_TD_BIL_HAZIRLIK_TARAF)gwSikayetEdilenler.GetRow(e.FocusedRowHandle);
    }
}