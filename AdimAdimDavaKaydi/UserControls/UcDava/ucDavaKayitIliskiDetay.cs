using System;
using System.ComponentModel;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucDavaKayitIliskiDetay : AvpXUserControl
    {
        public ucDavaKayitIliskiDetay()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucDavaKayitIliskiDetay_Load;
        }

        private AV001_TD_BIL_FOY myFoy;
        private AV001_TI_BIL_FOY myIcraFoy;
        private AV001_TD_BIL_HAZIRLIK myHazirlik;

        [Browsable(false)]
        public AV001_TD_BIL_HAZIRLIK MyHazirlik
        {
            get { return myHazirlik; }
            set
            {
                myHazirlik = value;
                if (value != null)
                {
                    //DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>));
                    MyDataSource = value.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection;
                    //BindData();
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
                if (value != null)
                {
                    //DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>));
                    MyDataSource = value.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection;
                    //BindData();
                }
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    // DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>));
                    MyDataSource = value.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection;
                    // BindData();
                }
            }
        }

        private TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                //if (IsLoaded)
                //    BindData();
            }
        }

        private BackgroundWorker bckWorker = new BackgroundWorker();

        public void BindData()
        {
            if (MyDataSource == null) return;
            MyDataSource.ListChanged += MyDataSource_ListChanged;
            MyDataSource.AddingNew += MyDataSource_AddingNew;
            if (!bckWorker.IsBusy)
            {
                bckWorker.DoWork += bckWorker_DoWork;
                bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
                bckWorker.RunWorkerAsync();
            }
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            LoadInitsData();
        }

        private void MyDataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            LoadInitsData();
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyDataSource.Count == 0)
            {
                if (MyFoy != null)
                {
                    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy
                                                                     , false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>));
                    _MyDataSource = MyFoy.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection;
                }
                else if (MyIcraFoy != null)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyIcraFoy
                                                                     , false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>));
                    _MyDataSource = MyIcraFoy.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection;
                }
                else if (MyHazirlik != null)
                {
                    DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(MyHazirlik
                                                                          , false, DeepLoadType.IncludeChildren,
                                                                          typeof(
                                                                              TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>));
                    _MyDataSource = MyHazirlik.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection;
                }
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                if (gridKayitIliskiDetay != null)
                {
                    LoadInitsData();
                    gridKayitIliskiDetay.DataSource = MyDataSource;
                }
            }
        }

        private void ucDavaKayitIliskiDetay_Load(object sender, EventArgs e)
        {
            //LOAD
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();

            IsLoaded = true;
            gridKayitIliskiDetay.ButtonCevirClick += gridKayitIliskiDetay_ButtonCevirClick;
            gridKayitIliskiDetay.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            //LoadInitsData();
            BindData();
            //rLueKayitIliskiHEdefKayit
        }

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridKayitIliskiDetay_ButtonClick(sender,
                                             new NavigatorButtonClickEventArgs(e.Item.Tag as NavigatorCustomButton));
        }

        private bool initsFilled;

        private void LoadInitsData()
        {
            if (!initsFilled && MyDataSource.Count > 0)
            {
                //Inits.KayitIliskiNedenGetir(repositoryItemLookUpEdit2);
                BelgeUtil.Inits.KayitIliskiNedenGetir(rLueKayitIliskiNeden);
                BelgeUtil.Inits.KayitIliskiTurGetir(rLueKayitIliskiTur);
                //Inits.KayitIliskiTurGetir(repositoryItemLookUpEdit1);
                //Inits.AdliBirimAdliyeGetir(repositoryItemLookUpEdit4);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliye);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorev);
                //Inits.AdliBirimGorevGetir(repositoryItemLookUpEdit6);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueBirimNo);
                //Inits.AdliBirimNoGetir(repositoryItemLookUpEdit5);
                BelgeUtil.Inits.ModulKodGetirForKayitIliski(rlueHedefTip);

                initsFilled = true;
            }
        }

        private void gridKayitIliskiDetay_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            //if (gridKayitIliskiDetay.Visible)
            //{
            //    gridControl1.Visible = true;
            //    gridKayitIliskiDetay.Visible = false;
            //}
            //else
            //{
            //     .Visible = false;
            //    gridKayitIliskiDetay.Visible = true;
            //}
        }

        private void gridKayitIliskiDetay_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "FormdanEkle")
            {
                frmKayitIliski frm = new frmKayitIliski();
                if (MyFoy != null)
                    frm.MyDavaFoy = MyFoy;
                else if (MyIcraFoy != null)
                    frm.MyIcraFoy = MyIcraFoy;
                else if (MyHazirlik != null)
                    frm.MyHazirlik = MyHazirlik;
                frm.Show();
            }
        }
    }
}