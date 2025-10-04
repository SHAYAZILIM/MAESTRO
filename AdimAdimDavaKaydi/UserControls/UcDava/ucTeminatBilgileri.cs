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
    public partial class ucTeminatBilgileri : AvpXUserControl
    {
        public ucTeminatBilgileri()
        {
            this.Load += ucTeminatBilgileri_Load;
        }

        private TList<AV001_TDI_BIL_TEMINAT_MEKTUP> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TDI_BIL_TEMINAT_MEKTUP> MyDataSource
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
                //DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy
                //                                                 , false, DeepLoadType.IncludeChildren,
                //                                                 typeof (TList<AV001_TD_BIL_TEMINAT_KEFALET>));
                MyDataSource = DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.Find("DAVA_FOY_ID = " + MyFoy.ID);
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                gridTeminatBilgileri.DataSource = MyDataSource;
                dataNavigatorExtended1.DataSource = MyDataSource;
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
                    MyDataSource = DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.Find("DAVA_FOY_ID = " + value.ID);// value.AV001_TD_BIL_TEMINAT_KEFALETCollection;
            }
        }

        private void ucTeminatBilgileri_Load(object sender, EventArgs e)
        {
            //LOAD

            InitializeComponent();
            IsLoaded = true;
            if (MView == ViewType.GridView)
            {
                panelControl1.Visible = false;
                gridTeminatBilgileri.Visible = true;
            }
            else if (MView == ViewType.VGrid)
            {
                panelControl1.Visible = true;
                gridTeminatBilgileri.Visible = false;
            }
            else if (MView == ViewType.LayoutView)
            {
                panelControl1.Visible = false;
                gridTeminatBilgileri.Visible = false;
            }

            if (!this.DesignMode)
            {
                try
                {
                    gridTeminatBilgileri.ButtonCevirClick
                        += gridTeminatBilgileri_ButtonCevirClick;

                    BelgeUtil.Inits.perCariGetir(rlueCari);
                    BelgeUtil.Inits.TeminatTuruGetir(rluTeminatTur);
                    BelgeUtil.Inits.DovizTipGetir(rlueDovizTip);
                    BelgeUtil.Inits.BankaGetir(rlueBanka);
                    BelgeUtil.Inits.BankaSubeGetir(rlueSube);

                    //if (MyFoy != null)
                    //{
                    //    BelgeUtil.Inits.DavaNedenGetir(gwTeminatBilgileri, MyFoy);
                    //    BelgeUtil.Inits.DavaNedenGetir(vGridControl1, MyFoy);
                    //}
                    BindData();
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void gridTeminatBilgileri_ButtonCevirClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (gridTeminatBilgileri.Visible)
            {
                gridTeminatBilgileri.Visible = false;
            }
            else
            {
                gridTeminatBilgileri.Visible = true;
            }
        }

        [Description("Görünümü deðiþtirir.")]
        public ViewType MView { get; set; }

        private void gridTeminatBilgileri_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null) return;

            if (e.Button.Tag.ToString() == "FormAc")
            {
                rFrmTeminatBilgileriKaydet frmTeminatKefalet = new rFrmTeminatBilgileriKaydet();
                frmTeminatKefalet.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmTeminatKefalet_FormClosed);
                frmTeminatKefalet.Show(MyFoy);
            }
            else if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                TList<AV001_TDI_BIL_TEMINAT_MEKTUP> DvList = new TList<AV001_TDI_BIL_TEMINAT_MEKTUP>();
                DvList.Add(MyDataSource[gwTeminatBilgileri.FocusedRowHandle]);
                rFrmTeminatBilgileriKaydet frm = new rFrmTeminatBilgileriKaydet();
                frm.AddNewList = DvList;
                frm.FormClosed += frmTeminatKefalet_FormClosed;
                frm.Show(MyFoy);
            }
        }

        private void frmTeminatKefalet_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            MyDataSource = DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.Find("DAVA_FOY_ID = " + MyFoy.ID);
            gridTeminatBilgileri.DataSource = MyDataSource;
        }
    }
}