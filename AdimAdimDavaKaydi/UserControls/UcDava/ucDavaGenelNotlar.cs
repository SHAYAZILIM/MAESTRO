using System;
using System.ComponentModel;
using System.Text;
using AdimAdimDavaKaydi.Forms.Dava;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucDavaGenelNotlar : AvpXUserControl
    {
        public ucDavaGenelNotlar()
        {
            InitializeComponent();
            this.Load += ucDavaGenelNotlar_Load;
        }

        private void ucDavaGenelNotlar_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            IsLoaded = true;

            if (MyType == ViewType.GridView)
            {
                panelControl1.Visible = false;
                extendedGridControl1.Visible = true;
            }
            if (MyType == ViewType.LayoutView)
            {
                panelControl1.Visible = false;
                extendedGridControl1.Visible = false;
            }
            if (MyType == ViewType.VGrid)
            {
                panelControl1.Visible = true;
                extendedGridControl1.Visible = false;
            }
            if (!this.DesignMode)
            {
                extendedGridControl1.ButtonCevirClick += gridControl1_ButtonCevirClick;
                BindData();
            }

            BelgeUtil.Inits.KontrolKimGetir(lueKontrolKim);
            BelgeUtil.Inits.KontrolKimGetir(rlueKontrolKim);
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
                    MyDataSource = value.AV001_TD_BIL_FOY_GENEL_NOTCollection;
            }
        }

        private AV001_TI_BIL_FOY myIcraFoy;

        [Browsable(false)]
        public AV001_TI_BIL_FOY MyIcraFoy
        {
            get { return myIcraFoy; }
            set
            {
                myIcraFoy = value;
                if (value != null)
                {
                    MyDataSourceIcra = value.AV001_TI_BIL_FOY_GENEL_NOTCollection;
                }
            }
        }

        private AV001_TD_BIL_HAZIRLIK myHazirlikFoy;

        [Browsable(false)]
        public AV001_TD_BIL_HAZIRLIK MyHazirlikFoy
        {
            get { return myHazirlikFoy; }
            set
            {
                myHazirlikFoy = value;
                if (value != null)
                    MyDataSource = value.AV001_TD_BIL_FOY_GENEL_NOTCollection;
            }
        }

        private TList<AV001_TD_BIL_FOY_GENEL_NOT> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TD_BIL_FOY_GENEL_NOT> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (value != null)
                {
                    if (IsLoaded)
                        BindData();
                }
            }
        }

        private TList<AV001_TI_BIL_FOY_GENEL_NOT> _MyDataSourceIcra;

        [Browsable(false)]
        public TList<AV001_TI_BIL_FOY_GENEL_NOT> MyDataSourceIcra
        {
            get { return _MyDataSourceIcra; }
            set
            {
                _MyDataSourceIcra = value;
                if (value != null)
                {
                    if (IsLoaded)
                        BindData();
                }
            }
        }

        private BackgroundWorker bckWorker = new BackgroundWorker();

        public void BindData()
        {
            if (MyDataSource != null)
            {
                if (!bckWorker.IsBusy)
                {
                    bckWorker.DoWork += bckWorker_DoWork;
                    bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
                    bckWorker.RunWorkerAsync();
                }
            }
            if (MyDataSourceIcra != null)
            {
                if (!bckWorker.IsBusy)
                {
                    bckWorker.DoWork += bckWorker_DoWork;
                    bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
                    bckWorker.RunWorkerAsync();
                }
            }
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyDataSource != null)
            {
                if (MyDataSource.Count == 0)
                {
                    if (MyFoy != null)
                    {
                        DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy
                                                                         , false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TD_BIL_FOY_GENEL_NOT>));
                        MyDataSource = MyFoy.AV001_TD_BIL_FOY_GENEL_NOTCollection;
                    }
                    else if (MyHazirlikFoy != null)
                    {
                        DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(MyHazirlikFoy
                                                                              , false, DeepLoadType.IncludeChildren,
                                                                              typeof(TList<AV001_TD_BIL_FOY_GENEL_NOT>));
                        MyDataSource = MyHazirlikFoy.AV001_TD_BIL_FOY_GENEL_NOTCollection;
                    }
                }
            }

            if (MyDataSourceIcra != null)
            {
                if (MyDataSourceIcra.Count == 0)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyIcraFoy
                                                                     , false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_GENEL_NOT>));
                    MyDataSourceIcra = MyIcraFoy.AV001_TI_BIL_FOY_GENEL_NOTCollection;
                }
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                try
                {
                    extendedGridControl1.DataSource = MyDataSource;

                    dnDavaGenelNotlar.DataSource = MyDataSource;
                    vgDvaNedenNotlar.DataSource = MyDataSource;
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }
            }

            else if (MyDataSourceIcra != null && !this.DesignMode && IsLoaded)
            {
                try
                {
                    extendedGridControl1.DataSource = MyDataSourceIcra;

                    dnDavaGenelNotlar.DataSource = MyDataSourceIcra;
                    vgDvaNedenNotlar.DataSource = MyDataSourceIcra;
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }
            }
        }

        public static string Validate(AV001_TD_BIL_FOY_GENEL_NOT row)
        {
            StringBuilder sb = new StringBuilder();

            if (row.NOTLAR == null)
                sb.AppendLine("* Notlar boþ olamaz.");

            return sb.ToString();
        }

        public static string Validate(AV001_TI_BIL_FOY_GENEL_NOT row)
        {
            StringBuilder sb = new StringBuilder();

            if (row.NOTLAR == null)
                sb.AppendLine("* Notlar boþ olamaz.");

            return sb.ToString();
        }

        private void gridControl1_ButtonCevirClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (extendedGridControl1.Visible)
            {
                extendedGridControl1.Visible = false;
                vgDvaNedenNotlar.Visible = true;
            }
            else
            {
                extendedGridControl1.Visible = true;
                vgDvaNedenNotlar.Visible = false;
            }
        }

        [Description("Görünümü Deðiþtirir.")]
        [Browsable(true)]
        public ViewType MyType { get; set; }

        private void extendedGridControl1_ButtonClick(object sender,
                                                      DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "FormAc")
            {
                if (MyFoy != null)
                {
                    rFrmDavaGenelNotlar frm = new rFrmDavaGenelNotlar();
                    frm.Show(MyFoy);
                }

                else if (MyHazirlikFoy != null)
                {
                    rFrmDavaGenelNotlar frm = new rFrmDavaGenelNotlar();
                    frm.Show(MyHazirlikFoy);
                }
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                DataRepository.AV001_TD_BIL_FOY_GENEL_NOTProvider.DeepLoad(
                    MyDataSource[vgDvaNedenNotlar.FocusedRecord], false, DeepLoadType.IncludeChildren,
                    typeof(TList<AV001_TD_BIL_FOY_GENEL_NOT>));
                TList<AV001_TD_BIL_FOY_GENEL_NOT> DvList = new TList<AV001_TD_BIL_FOY_GENEL_NOT>();
                DvList.Add(MyDataSource[vgDvaNedenNotlar.FocusedRecord]);
                rFrmDavaGenelNotlar frm = new rFrmDavaGenelNotlar();
                frm.AddNewList = DvList;

                if (MyFoy != null)
                {
                    frm.Show(MyFoy);
                }

                else if (MyHazirlikFoy != null)
                {
                    frm.Show(MyHazirlikFoy);
                }
            }
        }
    }
}