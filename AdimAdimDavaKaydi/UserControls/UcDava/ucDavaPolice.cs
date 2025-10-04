using System;
using System.ComponentModel;
using AdimAdimDavaKaydi.Forms.Dava;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucDavaPolice : AvpXUserControl
    {
        public ucDavaPolice()
        {
            if (DesignMode)
            {
                InitializeComponent();
            }
            this.Load += ucDavaPolice_Load;
        }

        private void gridDavaPolice_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            if (e.Button.Tag == "FormAc")
            {
                rfrmDavaPolice frm = new rfrmDavaPolice();
                frm.Show(MyFoy);
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                DataRepository.AV001_TDI_BIL_POLICEProvider.DeepLoad(MyDataSource[gwDavaPolice.FocusedRowHandle], false,
                                                                     DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TDI_BIL_POLICE>));
                TList<AV001_TDI_BIL_POLICE> DvList = new TList<AV001_TDI_BIL_POLICE>();
                DvList.Add(MyDataSource[gwDavaPolice.FocusedRowHandle]);
                rfrmDavaPolice frm = new rfrmDavaPolice();
                frm.AddNewList = DvList;
                frm.Show(MyFoy);
            }
        }

        private TList<AV001_TDI_BIL_POLICE> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TDI_BIL_POLICE> MyDataSource
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
                                                                 typeof(TList<AV001_TDI_BIL_POLICE>));
                _MyDataSource = MyFoy.AV001_TDI_BIL_POLICECollection_From_NN_DAVA_POLICE;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                gridDavaPolice.DataSource = MyDataSource;
                vGridControl1.DataSource = MyDataSource;
            }
        }

        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                    MyDataSource = value.AV001_TDI_BIL_POLICECollection_From_NN_DAVA_POLICE;
            }
        }

        private void ucDavaPolice_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (!IsLoaded)
            {
                InitializeComponent();
                this.gridDavaPolice.ButtonClick
                    += gridDavaPolice_ButtonClick;

                if (MyType == ViewType.GridView)
                {
                    panelControl1.Visible = false;
                    gridDavaPolice.Visible = true;
                    gridDavaPolice.BringToFront();
                }
                if (MyType == ViewType.LayoutView)
                {
                    panelControl1.Visible = false;
                    gridDavaPolice.Visible = false;
                }
                if (MyType == ViewType.VGrid)
                {
                    panelControl1.Visible = true;
                    gridDavaPolice.Visible = false;
                    panelControl1.BringToFront();
                }
                gridDavaPolice.ShowOnlyPredefinedDetails = true;

                BelgeUtil.Inits.perCariGetir(rlueCari);
                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.PoliceBransGetir(rluePolBrans);
                BelgeUtil.Inits.TeminatAltTipGetir(rlueTeminatAltTipi);
                BelgeUtil.Inits.ParaBicimiAyarla(tutar);
                BindData();
                IsLoaded = true;
            }
        }

        [Description("Görünümü Deðiþtirir.")]
        [Browsable(true)]
        public ViewType MyType { get; set; }
    }
}