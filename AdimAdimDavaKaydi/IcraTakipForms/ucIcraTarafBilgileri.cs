using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using AvukatProLib;
using System.Data;
using DevExpress.XtraBars;
using AdimAdimDavaKaydi.UserControls;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class ucIcraTarafBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {
        public ucIcraTarafBilgileri()
        {
            if (DesignMode)
            {
                InitializeComponent();
                //gcBorclu.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
                //gcBorclu.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            }
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            this.Load += this.ucIcraTarafBilgileri_Load;
            
        }

        #region enums

        public enum Direction
        {
            Previous = 0,
            Next = 1
        }

        public enum TakipModulu
        {
            Haciz,
            Rehin
        }

        #endregion enums

        #region Veriables

        private static int _currBorcluId;
        private static int _currSorumluAvkId;
        private static int _currTarafId;
        private static LookUpEdit tarafControl;
        private TList<AV001_TI_BIL_FOY_TARAF> _alacakliTaraflar = new TList<AV001_TI_BIL_FOY_TARAF>();
        private TList<AV001_TI_BIL_FOY_TARAF> _borcluTaraflar = new TList<AV001_TI_BIL_FOY_TARAF>();
        private AV001_TI_BIL_FOY _myFoy;

        #endregion Veriables

        #region Properties

        private TList<AV001_TI_BIL_FOY_TARAF> _BorcluTaraflar;

        private TList<AV001_TDI_BIL_CARI> cariEntityList = new TList<AV001_TDI_BIL_CARI>();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static int CurrBorcluId
        {
            get { return ucIcraTarafBilgileri._currBorcluId; }
            set { ucIcraTarafBilgileri._currBorcluId = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static int CurrTarafId
        {
            get { return ucIcraTarafBilgileri._currTarafId; }
            set { ucIcraTarafBilgileri._currTarafId = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static LookUpEdit TarafControl
        {
            get { return ucIcraTarafBilgileri.tarafControl; }
            set { ucIcraTarafBilgileri.tarafControl = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<RepositoryItemLookUpEdit> AlacakliTarafControls { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_FOY_TARAF> AlacakliTaraflar
        {
            get
            {
                if (gcAlacak != null && gcAlacak.DataSource is TList<AV001_TI_BIL_FOY_TARAF>)
                    return (TList<AV001_TI_BIL_FOY_TARAF>)gcAlacak.DataSource;
                return null;
            }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren,
                                                                           typeof(TList<AV001_TI_BIL_FOY_TARAF_VEKIL>));
                    gcAlacak.DataSource = value;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<RepositoryItemLookUpEdit> BorcluTarafControls { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_FOY_TARAF> BorcluTaraflar
        {
            get { return _BorcluTaraflar; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren,
                                                                           typeof(TList<AV001_TI_BIL_FOY_TARAF_VEKIL>));
                    _BorcluTaraflar = value;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrSorumluAvkId
        {
            get { return _currSorumluAvkId; }
            set { _currSorumluAvkId = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Direction Dir { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TakipModulu IcraTakipModulu { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return _myFoy; }
            set
            {
                _myFoy = value;

                if (_myFoy != null && this.DesignMode == false)
                {
                    if (!IsLoaded)
                    {
                        InitializeComponent();
                        IsLoaded = true;
                    }
                    SetFoy();
                }
            }
        }

        #endregion Properties

        #region Private Methods

        AV001_TI_BIL_FOY_TARAF trfSecili = new AV001_TI_BIL_FOY_TARAF();
                
        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            trfSecili = (AV001_TI_BIL_FOY_TARAF)e.Rows;

            BarButtonItem barBtn = new BarButtonItem(e.Manager, "Taraf Sorumluluk Bilgisi Güncelle");
            barBtn.ItemClick += new ItemClickEventHandler(barBtn_ItemClick);
            e.MyPopupMenu.ItemLinks.Insert(0, barBtn);
        }

        void barBtn_ItemClick(object sender, ItemClickEventArgs e)
        {            
            if (trfSecili.CARI_ID.HasValue)
            {
                AdimAdimDavaKaydi.Forms.frmAlacakNedenTarafEkleme frm = new AdimAdimDavaKaydi.Forms.frmAlacakNedenTarafEkleme();
                frm.Show(MyFoy, trfSecili.CARI_ID.Value, trfSecili.TARAF_SIFAT_ID);
            }
        }

        public static TList<AV001_TI_BIL_FOY_TARAF> AlacakliTaraflariGetir(AV001_TI_BIL_FOY MyFoy)
        {
            TList<AV001_TI_BIL_FOY_TARAF> result = new TList<AV001_TI_BIL_FOY_TARAF>();
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));
            foreach (AV001_TI_BIL_FOY_TARAF taraf in MyFoy.AV001_TI_BIL_FOY_TARAFCollection)
            {
                if (taraf.CARI_IDSource == null)
                    DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(taraf, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>), typeof(TList<AV001_TI_BIL_FOY_TARAF_GELISME>));

                if (taraf.TARAF_SIFAT_IDSource != null && taraf.TARAF_SIFAT_IDSource.HANGI_TARAF_NO == (int)AvukatProLib.Extras.IcraTarafKodu.TakipEden)
                    result.Add(taraf);
            }

            return result;
        }

        //public static DataTable AlacakliTaraflariGetir(AV001_TI_BIL_FOY MyFoy)
        //{
        //    TList<AV001_TI_BIL_FOY_TARAF> result = new TList<AV001_TI_BIL_FOY_TARAF>();
        //    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));

        //    foreach (AV001_TI_BIL_FOY_TARAF taraf in MyFoy.AV001_TI_BIL_FOY_TARAFCollection)
        //    {
        //        if (taraf.CARI_IDSource == null)
        //            DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(taraf, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>), typeof(TList<AV001_TI_BIL_FOY_TARAF_GELISME>));

        //        if (taraf.TARAF_SIFAT_IDSource != null && taraf.TARAF_SIFAT_IDSource.HANGI_TARAF_NO == (int)AvukatProLib.Extras.IcraTarafKodu.TakipEden)
        //            result.Add(taraf);
        //    }


        //    ABSqlConnection cn = new ABSqlConnection();
        //    cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
        //    DataTable dt = new DataTable();
        //    dt = cn.GetDataTable("SELECT ID AS Id, SIFAT AS Sifat FROM dbo.TDIE_KOD_TARAF_SIFAT(nolock) WHERE HANGI_TARAF_NO=" + (byte)tarafKodu + " ORDER BY SIFAT");
        //    return dt;
        //}

        public static TList<AV001_TI_BIL_FOY_TARAF> BorcluTaraflariGetir(AV001_TI_BIL_FOY MyFoy)
        {
            TList<AV001_TI_BIL_FOY_TARAF> result = null;
            if (MyFoy != null)
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));
                result = new TList<AV001_TI_BIL_FOY_TARAF>();
                if (MyFoy == null)
                    return result;
                foreach (AV001_TI_BIL_FOY_TARAF taraf in MyFoy.AV001_TI_BIL_FOY_TARAFCollection)
                {
                    if (taraf.CARI_IDSource == null)
                        DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(taraf, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>), typeof(TList<AV001_TI_BIL_FOY_TARAF_GELISME>));

                    if (taraf.TARAF_SIFAT_IDSource == null)
                        taraf.TARAF_SIFAT_IDSource = DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID(taraf.TARAF_SIFAT_ID);

                    if (taraf.TARAF_SIFAT_IDSource.HANGI_TARAF_NO == (int)AvukatProLib.Extras.IcraTarafKodu.TakipEdilen)
                        result.Add(taraf);
                }
            }
            return result;
        }

        public static TList<AV001_TD_BIL_FOY_TARAF> BorcluTaraflariGetir(AV001_TD_BIL_FOY MyFoy)
        {
            TList<AV001_TD_BIL_FOY_TARAF> result = null;
            if (MyFoy != null)
            {
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_TARAF>));
                result = new TList<AV001_TD_BIL_FOY_TARAF>();
                if (MyFoy == null)
                    return result;
                foreach (AV001_TD_BIL_FOY_TARAF taraf in MyFoy.AV001_TD_BIL_FOY_TARAFCollection)
                {
                    if (taraf.CARI_IDSource == null)
                        DataRepository.AV001_TD_BIL_FOY_TARAFProvider.DeepLoad(taraf, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));

                    if (taraf.TARAF_SIFAT_IDSource == null)
                        taraf.TARAF_SIFAT_IDSource = DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID(taraf.TARAF_SIFAT_ID.Value);

                    if (taraf.TARAF_SIFAT_IDSource.HANGI_TARAF_NO == (int)AvukatProLib.Extras.DavaTarafKodu.Davalý)
                        result.Add(taraf);
                }
            }
            return result;
        }

        public static TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT> SorumluTaraflariGetir(AV001_TI_BIL_FOY MyFoy)
        {
            TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT> result = new TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>();
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
            foreach (AV001_TI_BIL_FOY_SORUMLU_AVUKAT taraf in MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
            {
                if (taraf.SORUMLU_AVUKAT_CARI_IDSource == null)
                    DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.DeepLoad(taraf, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
                result.Add(taraf);
            }

            return result;
        }

        private void AddNewTaraf(AV001_TI_BIL_FOY_TARAF trf)
        {
            trf.CARI_IDSource = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(trf.CARI_ID.Value);

            MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Add(trf);
        }

        private void LoadData()
        {
            //BelgeUtil.Inits.perCariGetir(lueRefCari.Properties);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueTarafCari);
            AvukatPro.Services.Implementations.DevExpressService.AvukatDoldur(rLueBorcluVekil, false);
            AvukatPro.Services.Implementations.DevExpressService.AvukatDoldur(rLueAlacakliAvukat, false);
            AvukatPro.Services.Implementations.DevExpressService.TemsilSekliDoldur(rLueTemsilSekli);
            AvukatPro.Services.Implementations.DevExpressService.TemsilSekliDoldur(rLueAlacakliTemsilSekli);
            AvukatPro.Services.Implementations.DevExpressService.AvukatDoldur(rLueSorumluTaraf, true);

            //BelgeUtil.Inits.perCariAvukatGetir(rLueBorcluVekil);
            //BelgeUtil.Inits.TemsilSekliGetir(rLueTemsilSekli);
            //BelgeUtil.Inits.TemsilSekliGetir(rLueAlacakliTemsilSekli);
            //BelgeUtil.Inits.perCariAvukatGetir(rLueAlacakliAvukat);
            //BelgeUtil.Inits.AktifAvukatlariGetir(rLueSorumluTaraf);

            #region TarafKoduHazirla

            AvukatPro.Services.Implementations.DevExpressService.TarafKoduDoldur(rLueAlacakliTarafKodu);
            AvukatPro.Services.Implementations.DevExpressService.TarafKoduDoldur(rLueBorcluTarafKodu);

            //BelgeUtil.Inits.TarafKoduGetir(rLueAlacakliTarafKodu);
            //BelgeUtil.Inits.TarafKoduGetir(rLueBorcluTarafKodu);

            #endregion TarafKoduHazirla

            #region TarafSifatHazirla

            AvukatPro.Services.Implementations.DevExpressService.TarafSifatDoldur(rLueAlacakliSifat, AvukatProLib.Extras.IcraTarafKodu.TakipEden);
            AvukatPro.Services.Implementations.DevExpressService.TarafSifatDoldur(rLueBorcluSifat, AvukatProLib.Extras.IcraTarafKodu.TakipEdilen);

            //BelgeUtil.Inits.TarafSifatGetir(rLueAlacakliSifat, "TAKÝP EDEN");
            //BelgeUtil.Inits.TarafSifatGetir(rLueBorcluSifat, "TAKÝP EDÝLEN");

            #endregion TarafSifatHazirla
        }

        private void SetFoy()
        {
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>), typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));

            TarafBind();

            //TarafGorusme = MyFoy.AV001_TDI_BIL_GORUSMECollection;
            MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.AddingNew
                += AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection_AddingNew;
            BorcluTaraflar.AddingNew += borcluTaraflar_AddingNew;
            AlacakliTaraflar.AddingNew += alacakliTaraflar_AddingNew;

            rLueTarafCari.EditValueChanging += rLueTarafCari_EditValueChanging;
        }

        private void TarafBind()
        {
            if (AlacakliTaraflar == null)
                AlacakliTaraflar = new TList<AV001_TI_BIL_FOY_TARAF>();

            if (BorcluTaraflar == null)
                BorcluTaraflar = new TList<AV001_TI_BIL_FOY_TARAF>();

            BorcluTaraflar.Clear();
            AlacakliTaraflar.Clear();
            cariEntityList.Clear();

            #region <CC-20090622>

            // TarafKaydýna engel olþturduðu için taraf FaizCollectionu çekilmiþ
            foreach (AV001_TI_BIL_FOY_TARAF taraf in MyFoy.AV001_TI_BIL_FOY_TARAFCollection)
            {
                //CurrTarafId = 0;

                //if (taraf.CARI_IDSource == null)
                DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(taraf, false, DeepLoadType.IncludeChildren,
                                                                       typeof(AV001_TDI_BIL_CARI),
                                                                       typeof(TDIE_KOD_TARAF_SIFAT), typeof(TList<AV001_TI_BIL_FOY_TARAF_VEKIL>));

                //typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>),

                //typeof(AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ));

                if (taraf.CARI_IDSource != null)
                {
                    taraf.CARI_IDSource.ColumnChanged += CARI_IDSource_ColumnChanged;

                    if (taraf.TARAF_SIFAT_IDSource.HANGI_TARAF_NO == (int)AvukatProLib.Extras.IcraTarafKodu.TakipEden)
                    {
                        //DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(taraf, false,
                        //                                                       DeepLoadType.IncludeChildren,
                        //                                                       typeof(
                        //                                                           TList<AV001_TI_BIL_FOY_TARAF_VEKIL>));
                        AlacakliTaraflar.Add(taraf);
                    }
                    if (taraf.TARAF_SIFAT_IDSource.HANGI_TARAF_NO == (int)AvukatProLib.Extras.IcraTarafKodu.TakipEdilen)
                    {
                        //DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(taraf, false,
                        //                                                       DeepLoadType.IncludeChildren,
                        //                                                       typeof(
                        //                                                           TList<AV001_TI_BIL_FOY_TARAF_VEKIL>));
                        BorcluTaraflar.Add(taraf);

                        //CurrTarafId = taraf.ID;
                    }

                    cariEntityList.Add(taraf.CARI_IDSource);
                }
            }

            //BorcluTaraflar = BorcluTaraflariGetir(MyFoy);
            //AlacakliTaraflar = AlacakliTaraflariGetir(MyFoy);

            #endregion <CC-20090622>

            //Alacaklilar Doluyor.
            gcAlacak.BeginUpdate();
            gcAlacak.DataSource = AlacakliTaraflar;
            gcAlacak.EndUpdate();

            //SorumluAvukatlar Doluyor.
            gcSorumlu.BeginUpdate();
            gcSorumlu.DataSource = MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection;
            gcSorumlu.EndUpdate();

            //Borclular Doluyor.
            gcBorclu.DataSource = BorcluTaraflar;

            if (BorcluTaraflar.Count > 0)
            {
                AV001_TI_BIL_FOY_TARAF seciliTaraf = (AV001_TI_BIL_FOY_TARAF)BorcluTaraflar[0];

                if (seciliTaraf.CARI_ID.HasValue)
                {
                    //VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                    //adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
                    ABSqlConnection cn = new ABSqlConnection();
                    cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                    gcIletisimBilgileri.DataSource = cn.GetDataTable("SELECT ADRES, ILCE, IL, TEL_1, TEL_2, CEP_TEL, EMAIL_1, VERGI_DAIRESI, VERGI_NO, TC_KIMLIK_NO, BABA_ADI, DOGUM_TARIHI, ANNE_KIZLIK_SOYADI, MUSTERI_NO FROM dbo.per_CariKimlikIletisimBilgileri(nolock) WHERE ID=" + seciliTaraf.CARI_ID);
                }
            }
        }
        #endregion Private Methods

        #region ValidateRowEventArgs

        private void gwAlacak_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TI_BIL_FOY_TARAF trf = (AV001_TI_BIL_FOY_TARAF)e.Row;

            //if (trf.IsNew)
            //{
            //    //Yeni eklenen tarafýn alacak tarafýna da eklenmesi iþlemi yapýlýyor. MB
            //    if (trf.CARI_ID.HasValue)
            //    {
            //        AdimAdimDavaKaydi.Forms.frmAlacakNedenTarafEkleme frm = new AdimAdimDavaKaydi.Forms.frmAlacakNedenTarafEkleme();
            //        frm.Show(MyFoy, trf.CARI_ID.Value, trf.TARAF_SIFAT_ID);
            //    }
            //}

            if (!trf.CARI_ID.HasValue)
            {
                e.ErrorText = "Bir Takip Eden seçilmelidir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (trf.TARAF_SIFAT_ID == null)
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
            if (AlacakliTaraflar.FindAll("CARI_ID", trf.CARI_ID).Count > 1)
            {
                e.ErrorText = "Bu Takip Eden zaten eklenmiþtir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (BorcluTaraflar.FindAll("CARI_ID", trf.CARI_ID).Count > 0)
            {
                e.ErrorText = "Bu þahýs Takip Edilen taraf olarak zaten eklenmiþ." + Environment.NewLine;
                e.Valid = false;
                return;
            }

            AV001_TI_BIL_FOY_TARAF temp =
                MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(AV001_TI_BIL_FOY_TARAFColumn.CARI_ID, trf.CARI_ID.Value);

            if (temp == null && e.Valid)
            {
                AddNewTaraf(trf);

                //List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> refList = AlacakliTarafRefresh(true);

                //TarafControllerRefresh(AlacakliTarafControls, refList);
            }
            else
            {
                MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Clear();
                MyFoy.AV001_TI_BIL_FOY_TARAFCollection.AddRange(BorcluTaraflar);
                MyFoy.AV001_TI_BIL_FOY_TARAFCollection.AddRange(AlacakliTaraflar);

                //AlacakliTarafRefresh(true);
            }
        }

        private void gwBorclu_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TI_BIL_FOY_TARAF trf = (AV001_TI_BIL_FOY_TARAF)e.Row;

            if (trf.IsNew)
            {
                //Yeni eklenen tarafýn alacak tarafýna da eklenmesi iþlemi yapýlýyor. MB
                if (trf.CARI_ID.HasValue)
                {
                    AdimAdimDavaKaydi.Forms.frmAlacakNedenTarafEkleme frm = new AdimAdimDavaKaydi.Forms.frmAlacakNedenTarafEkleme();
                    frm.Show(MyFoy, trf.CARI_ID.Value, trf.TARAF_SIFAT_ID);
                }
            }

            if (!trf.CARI_ID.HasValue)
            {
                e.ErrorText = "Bir Takip Edilen seçilmelidir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (trf.TARAF_SIFAT_ID == null)
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
            if (BorcluTaraflar.FindAll("CARI_ID", trf.CARI_ID).Count > 1)
            {
                e.ErrorText = "Bu Takip Edilen zaten eklenmiþtir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (AlacakliTaraflar.FindAll("CARI_ID", trf.CARI_ID).Count > 0)
            {
                e.ErrorText = "Bu þahýs Takip Eden taraf olarak zaten eklenmiþ." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (e.Valid)
            {
                try
                {
                    AddNewTaraf(trf);

                    //List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> refList = BorcluTarafRefresh(true);

                    //TarafControllerRefresh(BorcluTarafControls, refList);

                    #region Dosyaya yeni taraf eklediðinde,alacak neden taraflara yeni eklenen borçlu ekleniyor.

                    for (int i = 0; i < MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++)
                    {
                        for (int j = 0;
                             j <
                             MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.
                                 Count;
                             j++)
                        {
                            if (MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].
                                    AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Find(
                                        AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn.TARAF_CARI_ID, trf.CARI_ID.Value) == null)
                            {
                                AV001_TI_BIL_ALACAK_NEDEN_TARAF t =
                                    MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].
                                        AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.AddNew();
                                t.TARAF_CARI_ID = trf.CARI_ID.Value;
                                t.TARAF_CARI_IDSource = trf.CARI_IDSource;
                                t.TARAF_SIFAT_ID = trf.TARAF_SIFAT_ID;
                                t.TARAF_SIFAT_IDSource = trf.TARAF_SIFAT_IDSource;
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
                MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Clear();
                MyFoy.AV001_TI_BIL_FOY_TARAFCollection.AddRange(BorcluTaraflar);
                MyFoy.AV001_TI_BIL_FOY_TARAFCollection.AddRange(AlacakliTaraflar);

                //BorcluTarafRefresh(false);
            }
        }

        private void gwSorumluAvk_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TI_BIL_FOY_SORUMLU_AVUKAT row = (AV001_TI_BIL_FOY_SORUMLU_AVUKAT)e.Row;
            if (!row.SORUMLU_AVUKAT_CARI_ID.HasValue && row.SORUMLU_AVUKAT_CARI_IDSource == null)
            {
                e.ErrorText = "Lütfen bir sorumlu seçiniz." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (
                MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.FindAll("SORUMLU_AVUKAT_CARI_ID",
                                                                        row.SORUMLU_AVUKAT_CARI_ID.Value).Count > 1)
            {
                e.ErrorText = "Bu Sorumlu zaten eklenmiþ." + Environment.NewLine;
                e.Valid = false;
                return;
            }
        }

        #endregion ValidateRowEventArgs

        #region EditValue_EventArgs

        //private void lueTaraf_EditValueChanging(object sender, ChangingEventArgs e)
        //{
        //    if (e.NewValue != null)
        //    {
        //        CurrTarafId = Convert.ToInt32(e.NewValue);

        //        AV001_TI_BIL_FOY_TARAF taraf = MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(vi => vi.CARI_ID == CurrTarafId);
        //        if (taraf == null)
        //            return;

        //        if (taraf.TarafOzet.Contains("ALACAKLI"))
        //        {
        //            if (tabControl.TabPages.ItemCount > 0)
        //            {
        //                tabControl.TabPages[0].Visibility = LayoutVisibility.Never;
        //            }
        //        }
        //        else
        //        {
        //            tabControl.TabPages[0].Visibility = LayoutVisibility.Always;
        //            ucIcraTarafGelismeleri.GelismeleriGuncelle(MyFoy, ucIcraTarafGelismeleri.myGelisme);
        //        }
        //        TarafCariBilgileriBind(CurrTarafId);

        //        if (BorcluTaraflar.Count > 0)
        //        {
        //            CurrBorcluId = BorcluTaraflar[0].CARI_ID.Value;
        //            //lueTaraf.EditValue = CurrBorcluId;
        //        }
        //        if (AlacakliTaraflar.Count > 0)
        //        {
        //            CurrTarafId = AlacakliTaraflar[0].CARI_ID.Value;
        //        }
        //    }
        //}

        //private void lue_Il_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        //{
        //    if (e.NewValue != null)
        //    {
        //        lue_Ilce.Enabled = true;
        //        if (lue_Ilce.Properties.DataSource != null)
        //        {
        //            ((TList<TDI_KOD_ILCE>)lue_Ilce.Properties.DataSource).Filter = string.Empty;

        //            ((TList<TDI_KOD_ILCE>)lue_Ilce.Properties.DataSource).Filter = "IL_ID = " + (int)e.NewValue;
        //        }
        //    }
        //}

        #endregion EditValue_EventArgs

        #region AddingNew

        private void alacakliTaraflar_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_FOY_TARAF addNew = MyFoy.AV001_TI_BIL_FOY_TARAFCollection.AddNew();
            if (addNew == null)
                addNew = new AV001_TI_BIL_FOY_TARAF();

            addNew.TAKIP_EDEN_MI = true;
            addNew.TARAF_KODU = 1;
            addNew.TARAF_SIFAT_ID = 1;
            e.NewObject = addNew;
        }

        private void AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_FOY_SORUMLU_AVUKAT addNew = e.NewObject as AV001_TI_BIL_FOY_SORUMLU_AVUKAT;
            if (addNew == null)
                addNew = new AV001_TI_BIL_FOY_SORUMLU_AVUKAT();

            e.NewObject = addNew;
        }

        private void borcluTaraflar_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_FOY_TARAF addNew = MyFoy.AV001_TI_BIL_FOY_TARAFCollection.AddNew();
            if (addNew == null)
                addNew = new AV001_TI_BIL_FOY_TARAF();

            addNew.TARAF_KODU = 3;
            addNew.TAKIP_EDEN_MI = false;
            addNew.TARAF_SIFAT_ID = 2;
            e.NewObject = addNew;

            //MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Add(addNew);
            //int i= MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count;
            //int j = BorcluTaraflar.Count;
        }

        #endregion AddingNew

        #region ColumnChanged_EventArgs

        private void CARI_IDSource_ColumnChanged(object sender, AV001_TDI_BIL_CARIEventArgs e)
        {
            AV001_TDI_BIL_CARI gonderen = sender as AV001_TDI_BIL_CARI;

            if (e.Column == AV001_TDI_BIL_CARIColumn.AKTIF_ADRES)
            {
                if (gonderen.AKTIF_ADRES)
                {
                    gonderen.AKTIF_ADRES_2 = false;
                    gonderen.AKTIF_ADRES_3 = false;
                }
            }
            else if (e.Column == AV001_TDI_BIL_CARIColumn.AKTIF_ADRES_2)
            {
                if (gonderen.AKTIF_ADRES_2)
                {
                    gonderen.AKTIF_ADRES = false;
                    gonderen.AKTIF_ADRES_3 = false;
                }
            }
            else if (e.Column == AV001_TDI_BIL_CARIColumn.AKTIF_ADRES_3)
            {
                if (gonderen.AKTIF_ADRES_3)
                {
                    gonderen.AKTIF_ADRES_2 = false;
                    gonderen.AKTIF_ADRES = false;
                }
            }
        }

        #endregion ColumnChanged_EventArgs

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (gcIletisimBilgileri.DataSource != null)
            {
                VList<per_CariKimlikIletisimBilgileri> guncellenecekCari = (VList<per_CariKimlikIletisimBilgileri>)gcIletisimBilgileri.DataSource;

                AV001_TDI_BIL_CARI cari = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(guncellenecekCari[0].ID);
                frmCariGenelGiris cariForms = new frmCariGenelGiris();
                cariForms.YeniKayitMi = false;
                cariForms.MyCari = cari;
                cariForms.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cariForms.Show();
            }
            else
                XtraMessageBox.Show("Güncellenecek þahýs seçiniz!");
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((sender as frmTemsilKayit).DialogResult == DialogResult.OK)
            {
                AvukatPro.Services.Implementations.DevExpressService.AvukatDoldur(rLueBorcluVekil, false);
                AvukatPro.Services.Implementations.DevExpressService.AvukatDoldur(rLueAlacakliAvukat, false);

                //AdimAdimDavaKaydi.frmCariGenelGiris frm = new frmCariGenelGiris();
                //(rLueBorcluVekil.DataSource as System.Collections.Generic.List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>).Add(BelgeUtil.Inits._perCariAvukatGetir.Last());
                //(rLueAlacakliAvukat.DataSource as System.Collections.Generic.List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>).Add(BelgeUtil.Inits._perCariAvukatGetir.Last());
            }
        }

        private void gwAlacak_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle == gwAlacak.FocusedRowHandle)
            {
                AV001_TI_BIL_FOY_TARAF seciliTaraf = (AV001_TI_BIL_FOY_TARAF)gwAlacak.GetRow(e.RowHandle);
                if (seciliTaraf.CARI_ID.HasValue)
                {
                    VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                    adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
                    gcIletisimBilgileri.DataSource = adres;
                }
            }
        }

        private void gwBorclu_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle == gwBorclu.FocusedRowHandle)
            {
                AV001_TI_BIL_FOY_TARAF seciliTaraf = (AV001_TI_BIL_FOY_TARAF)gwBorclu.GetRow(e.RowHandle);

                if (seciliTaraf.CARI_ID.HasValue)
                {
                    VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                    adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
                    gcIletisimBilgileri.DataSource = adres;
                }
            }
        }

        private void gwBorclu_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                int cariID = (int)gwBorclu.GetRowCellValue(e.RowHandle, "CARI_ID");

                int icraTarafID = BorcluTaraflar.Find(b => b.CARI_ID == cariID).ID;

                AV001_TI_BIL_FOY_TARAF_GELISME gelisme = DataRepository.AV001_TI_BIL_FOY_TARAF_GELISMEProvider.GetByICRA_FOY_ID(MyFoy.ID).Find(g => g.ICRA_FOY_TARAF_ID == icraTarafID);

                if (gelisme == null)
                    return;

                if ((gelisme.BILA_TARIHI.HasValue || gelisme.ZABITA_ARASTIRMA_OLUMSUZ_TARIHI.HasValue || gelisme.ZABITACA_YENI_ADRES_BULUNDUGU_TARIHI.HasValue) && !gelisme.ILK_TEBLIGAT_TARIHI.HasValue)
                {
                    e.Appearance.BackColor = System.Drawing.Color.Purple;
                    e.Appearance.ForeColor = System.Drawing.Color.White;
                }
                else if (gelisme.ILK_TEBLIGAT_TARIHI_DURUMU == "Bekleniyor.")
                {
                    e.Appearance.BackColor = System.Drawing.Color.Gold;
                    e.Appearance.ForeColor = System.Drawing.Color.Black;
                }
                else if (gelisme.KESINLESME_TARIHI_DURUMU == "Kesinleþti")
                {
                    e.Appearance.BackColor = System.Drawing.Color.DarkGreen;
                    e.Appearance.ForeColor = System.Drawing.Color.White;
                }
                else if (gelisme.ITIRAZ_TARIHI_DURUMU == "Tümüne Ýtiraz" || gelisme.ITIRAZ_TARIHI_DURUMU == "Kabul Edildi")
                {
                    e.Appearance.BackColor = System.Drawing.Color.Red;
                    e.Appearance.ForeColor = System.Drawing.Color.White;
                }
                else if (gelisme.ITIRAZ_TARIHI_DURUMU == "Kýsmi Ýtiraz")
                {
                    e.Appearance.BackColor = System.Drawing.Color.Red;
                    e.Appearance.BackColor2 = System.Drawing.Color.Green;
                    e.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
                    e.Appearance.ForeColor = System.Drawing.Color.White;
                }
                else if (gelisme.ILK_TEBLIGAT_TARIHI.HasValue && !gelisme.KESINLESME_TARIHI.HasValue && !gelisme.ITIRAZ_TARIHI.HasValue)
                {
                    e.Appearance.BackColor = System.Drawing.Color.Orange;
                    e.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
                }
                if (gelisme.KESINLESME_TARIHI_DURUMU == "Mehil Öncesi")
                {
                    e.Appearance.BackColor = System.Drawing.Color.DarkBlue;
                    e.Appearance.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        private void gwSorumluAvk_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle == gwSorumluAvk.FocusedRowHandle)
            {
                AV001_TI_BIL_FOY_SORUMLU_AVUKAT seciliAvukat = (AV001_TI_BIL_FOY_SORUMLU_AVUKAT)gwSorumluAvk.GetRow(e.RowHandle);

                if (seciliAvukat.SORUMLU_AVUKAT_CARI_ID.HasValue)
                {
                    VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                    adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliAvukat.SORUMLU_AVUKAT_CARI_ID.ToString(), "ID");
                    gcIletisimBilgileri.DataSource = adres;
                }
            }
        }

        private void rbtnBorcluTemsilEkle_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            frmTemsilKayit frm = new frmTemsilKayit();
            AV001_TI_BIL_FOY_TARAF trf = gwBorclu.GetRow(gwBorclu.FocusedRowHandle) as AV001_TI_BIL_FOY_TARAF;
            frm.FormClosed += frm_FormClosed;
            if (trf != null && MyFoy != null)
                frm.Show(trf, MyFoy);
        }

        private void rbtnTemsilEkle_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            frmTemsilKayit frm = new frmTemsilKayit();
            AV001_TI_BIL_FOY_TARAF trf = gwAlacak.GetRow(gwAlacak.FocusedRowHandle) as AV001_TI_BIL_FOY_TARAF;
            frm.FormClosed += frm_FormClosed;
            if (trf != null && MyFoy != null)
                frm.Show(trf, MyFoy);
        }

        private void rLueSorumluTaraf_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue != null && e.OldValue != null)
            {
                int i = 0;

                try
                {
                    for (i = 0; i < MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count; i++)
                    {
                        if (MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[i].SORUMLU_AVUKAT_CARI_ID ==
                            (int)e.OldValue)
                        {
                            MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[i].SORUMLU_AVUKAT_CARI_IDSource =
                                DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)e.NewValue);
                        }
                    }
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void rLueTarafCari_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;

            if ((e.Button.Tag as string) == "Yeni")
            {
                frmCariGenelGiris frm = new frmCariGenelGiris();
                frm.tmpCariAd = lue.Text;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
                frm.FormClosed += delegate
                {
                    DialogResult dr = frm.KayitBasarili;
                    if (dr == System.Windows.Forms.DialogResult.OK)
                        AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueTarafCari);
                };
            }
        }

        private void rLueTarafCari_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue != null && e.OldValue != null)
            {
                int i = 0;

                try
                {
                    for (i = 0; i < MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count; i++)
                    {
                        if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_ID == (int)e.OldValue)
                        {
                            MyFoy.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource =
                                DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)e.NewValue);
                        }
                    }
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
                finally
                {
                    //           BorcluTarafRefresh(false);
                }
            }
            int hash = MyFoy.GetHashCode();
        }

        private void ucIcraTarafBilgileri_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            if (!IsLoaded)
            {
                InitializeComponent();
                LoadData();
                IsLoaded = true;
            }

            this.rLueSorumluTaraf.EditValueChanging += rLueSorumluTaraf_EditValueChanging;

            gvBorcluTarafVekil.OptionsDetail.AllowExpandEmptyDetails = true;

            CheckForIllegalCrossThreadCalls = false;

            //         TarafControl = this.lueTaraf;

            #region Events

            //lueTaraf.EditValueChanging += lueTaraf_EditValueChanging;

            //lueTaraf.ButtonClick += lueTaraf_ButtonClick;

            gwAlacak.ValidateRow += gwAlacak_ValidateRow;

            gwBorclu.ValidateRow += gwBorclu_ValidateRow;

            gwSorumluAvk.ValidateRow += gwSorumluAvk_ValidateRow;

            if (BelgeUtil.Inits.PaketAdi == 0)
            {
                gridColumn1.OptionsColumn.ReadOnly =
                gridColumn2.OptionsColumn.ReadOnly =
                gridColumn3.OptionsColumn.ReadOnly =
                gridColumn4.OptionsColumn.ReadOnly =
                gridColumn5.OptionsColumn.ReadOnly =
                colBorcluAdi.OptionsColumn.ReadOnly = false;

                gridColumn1.OptionsColumn.AllowEdit =
                gridColumn2.OptionsColumn.AllowEdit =
                gridColumn3.OptionsColumn.AllowEdit =
                gridColumn4.OptionsColumn.AllowEdit =
                gridColumn5.OptionsColumn.AllowEdit =
                colBorcluAdi.OptionsColumn.AllowEdit = true;
            }

            #endregion Events

            //LoadData();

            gcBorclu.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
        }

        #region <MB-20100201> Alacaklý, Borçlu, Sorumlu Avukat Silme

        private void gcAlacak_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            else if (e.Button.Tag.ToString() == "KaydiSil")
            {
                if (gwAlacak.GetFocusedRow() != null)
                {
                    AdimAdimDavaKaydi.Util.frmKayitSil kayitSil =
                        new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TI_BIL_FOY_TARAF",
                                                               "ID = " +
                                                               (gwAlacak.GetFocusedRow() as AV001_TI_BIL_FOY_TARAF).ID);

                    if (kayitSil.ShowDialog() == DialogResult.OK)
                    {
                        if (gcAlacak.DataSource is TList<AV001_TI_BIL_FOY_TARAF>)
                        {
                            (gcAlacak.DataSource as TList<AV001_TI_BIL_FOY_TARAF>).Remove(
                                gwAlacak.GetFocusedRow() as AV001_TI_BIL_FOY_TARAF);
                            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TI_BIL_FOY_TARAF>));
                        }
                    }
                }
            }
        }

        private void gcBorclu_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            else if (e.Button.Tag.ToString() == "KaydiSil")
            {
                if (gwBorclu.GetFocusedRow() != null)
                {
                    AdimAdimDavaKaydi.Util.frmKayitSil kayitSil =
                        new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TI_BIL_FOY_TARAF",
                                                               "ID = " +
                                                               (gwBorclu.GetFocusedRow() as AV001_TI_BIL_FOY_TARAF).ID);

                    if (kayitSil.ShowDialog() == DialogResult.OK)
                    {
                        if (gcBorclu.DataSource is TList<AV001_TI_BIL_FOY_TARAF>)
                        {
                            (gcBorclu.DataSource as TList<AV001_TI_BIL_FOY_TARAF>).Remove(
                                gwBorclu.GetFocusedRow() as AV001_TI_BIL_FOY_TARAF);
                            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TI_BIL_FOY_TARAF>));
                        }
                    }
                }
            }
        }

        private void gcSorumlu_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            else if (e.Button.Tag.ToString() == "KaydiSil")
            {
                if (gwSorumluAvk.GetFocusedRow() != null)
                {
                    AdimAdimDavaKaydi.Util.frmKayitSil kayitSil =
                        new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TI_BIL_FOY_TARAF",
                                                               "ID = " +
                                                               (gwSorumluAvk.GetFocusedRow() as
                                                                AV001_TI_BIL_FOY_SORUMLU_AVUKAT).ID);

                    if (kayitSil.ShowDialog() == DialogResult.OK)
                    {
                        if (gcSorumlu.DataSource is TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>)
                        {
                            (gcSorumlu.DataSource as TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>).Remove(
                                gwSorumluAvk.GetFocusedRow() as AV001_TI_BIL_FOY_SORUMLU_AVUKAT);
                        }
                    }
                }
            }
        }

        #endregion <MB-20100201> Alacaklý, Borçlu, Sorumlu Avukat Silme

        private void gwAlacak_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (e.FocusedRowHandle == gwAlacak.FocusedRowHandle)
            //{
            AV001_TI_BIL_FOY_TARAF seciliTaraf = (AV001_TI_BIL_FOY_TARAF)gwAlacak.GetRow(e.FocusedRowHandle);
            if (seciliTaraf.CARI_ID.HasValue)
            {
                VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
                gcIletisimBilgileri.DataSource = adres;
            }
            //}
        }

        private void gwBorclu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (e.RowHandle == gwBorclu.FocusedRowHandle)
            //{
            AV001_TI_BIL_FOY_TARAF seciliTaraf = (AV001_TI_BIL_FOY_TARAF)gwBorclu.GetRow(e.FocusedRowHandle);

            if (seciliTaraf.CARI_ID.HasValue)
            {
                VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
                gcIletisimBilgileri.DataSource = adres;
            }
            //}
        }

        private void gwSorumluAvk_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (e.RowHandle == gwSorumluAvk.FocusedRowHandle)
            //{
            AV001_TI_BIL_FOY_SORUMLU_AVUKAT seciliAvukat = (AV001_TI_BIL_FOY_SORUMLU_AVUKAT)gwSorumluAvk.GetRow(e.FocusedRowHandle);

            if (seciliAvukat.SORUMLU_AVUKAT_CARI_ID.HasValue)
            {
                VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliAvukat.SORUMLU_AVUKAT_CARI_ID.ToString(), "ID");
                gcIletisimBilgileri.DataSource = adres;
            }
            //}
        }

        //private void gwAlacak_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    if (e.FocusedRowHandle < 0)
        //        return;

        //    AV001_TI_BIL_FOY_TARAF seciliTaraf = (AV001_TI_BIL_FOY_TARAF)gwAlacak.GetRow(e.FocusedRowHandle);
        //    if (seciliTaraf.CARI_ID.HasValue)
        //    {
        //        VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
        //        adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
        //        gcIletisimBilgileri.DataSource = adres;
        //    }
        //}

        //private void gwSorumluAvk_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    if (e.FocusedRowHandle < 0)
        //        return;

        //    AV001_TI_BIL_FOY_SORUMLU_AVUKAT seciliAvukat = (AV001_TI_BIL_FOY_SORUMLU_AVUKAT)gwSorumluAvk.GetRow(e.FocusedRowHandle);

        //    if (seciliAvukat.SORUMLU_AVUKAT_CARI_ID.HasValue)
        //    {
        //        VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
        //        adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliAvukat.SORUMLU_AVUKAT_CARI_ID.ToString(), "ID");
        //        gcIletisimBilgileri.DataSource = adres;
        //    }
        //}

        //private void gwBorclu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    if (e.FocusedRowHandle < 0)
        //        return;

        //    AV001_TI_BIL_FOY_TARAF seciliTaraf = (AV001_TI_BIL_FOY_TARAF)gwBorclu.GetRow(e.FocusedRowHandle);
    }
}