using System;
using System.ComponentModel;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucEPosta : AvpXUserControl
    {
        public ucEPosta()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucEPosta_Load;
        }

        private TList<AV001_TDIE_BIL_MESAJ> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TDIE_BIL_MESAJ> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        private BackgroundWorker bckWorker = new BackgroundWorker();

        public void BindData()
        {
            if (MyDataSource == null) return;
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
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy
                                                                 , false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TDIE_BIL_MESAJ>));
                MyDataSource = MyFoy.AV001_TDIE_BIL_MESAJCollection_From_NN_MESAJ_DAVA_FOY;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                exEPosta.DataSource = MyDataSource;
            }
        }

        private AV001_TD_BIL_FOY myFoy;

        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                    MyDataSource = value.AV001_TDIE_BIL_MESAJCollection_From_NN_MESAJ_DAVA_FOY;
            }
        }

        private void ucEPosta_Load(object sender, EventArgs e)
        {
            //LOAD
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            IsLoaded = true;

            BelgeUtil.Inits.perCariGetir(rlueCari);
            BindData();
        }
    }
}