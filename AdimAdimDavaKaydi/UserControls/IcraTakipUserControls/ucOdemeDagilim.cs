using System;
using System.ComponentModel;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucOdemeDagilim : AvpXUserControl
    {
        //AV001_TI_BIL_ODEME_DAGILIM
        private TList<AV001_TI_BIL_ODEME_DAGILIM> _MyDataSource;

        private BackgroundWorker bckWorker = new BackgroundWorker();

        private bool initsFilled;

        private AV001_TI_BIL_FOY myFoy;

        public ucOdemeDagilim()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucOdemeDagilim_Load;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_ODEME_DAGILIM> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                    MyDataSource = value.AV001_TI_BIL_ODEME_DAGILIMCollection;
            }
        }

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

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyDataSource.Count == 0)
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy
                                                                 , false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));
                MyDataSource = MyFoy.AV001_TI_BIL_ODEME_DAGILIMCollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && IsLoaded)
            {
                LoadInitsData();
                gridOdemeDagilim.DataSource = MyDataSource;
            }
        }

        private void gridOdemeDagilim_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gridOdemeDagilim.Visible)
            {
                //gridControl1.Visible = true ;
                //gridOdemeDagilim.Visible = false;
            }
            else
            {
                //gridControl1.Visible = false;
                //gridOdemeDagilim.Visible = true;
            }
        }

        private void LoadInitsData()
        {
            if (!initsFilled && MyDataSource.Count > 0)
            {
                //Inits.AlacakNEdenGetir(rLueAlacakNedenID);

                BelgeUtil.Inits.DovizTipGetir(rLueDovizID);
                BelgeUtil.Inits.AlacakNedenTarafGetir(rLueAlacakNedenTarafID);

                BelgeUtil.Inits.MahsupAltKategoriGetir(rLueMahsupAltKategoriID);
                BelgeUtil.Inits.MahsupKategoriGetir(rLueMahsupKategoriID);

                #region <CC-20090612>

                // ödeme daðýlýmlarýnda daðýlým tipi ve foy taraf ýd gelmiyordu getirldi

                #endregion <CC-20090612>

                if (MyFoy != null)
                    BelgeUtil.Inits.FoyTarafGetir(new[] { rLueFoyTarafID }, MyFoy);
                BelgeUtil.Inits.AlacakNEdenGetir(rLueAlacakNedenID);
                BelgeUtil.Inits.OdemeDagilimGetir(rLueDagilimTipID);
                BelgeUtil.Inits.IlamKararGetir(rLueIlamID);

                //Inits.ParaBicimiAyarla(rudTutar2);
                BelgeUtil.Inits.ParaBicimiAyarla(rudTutar);
                BelgeUtil.Inits.IlamTipiGetir(rLueIlamID);
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

        private void ucOdemeDagilim_Load(object sender, EventArgs e)
        {
            //LOAD
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            IsLoaded = true;
            gridOdemeDagilim.ButtonCevirClick += gridOdemeDagilim_ButtonCevirClick;

            //gridControl1.ButtonCevirClick += new EventHandler<NavigatorButtonClickEventArgs>(gridOdemeDagilim_ButtonCevirClick);

            //Tread e taþýndý
            //LoadInitsData();
            if (MyFoy != null)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false,
                                                                 DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_FOY_TARAF>));

            //LoadInitsData();
            BindData();
        }
    }
}