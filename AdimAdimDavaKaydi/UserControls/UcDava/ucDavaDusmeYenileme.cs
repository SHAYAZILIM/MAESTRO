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
    public partial class ucDavaDusmeYenileme : AvpXUserControl
    {
        public ucDavaDusmeYenileme()
        {
            this.Load += ucDavaDusmeYenileme_Load;
        }

        private void gridDavaDusmeYenileme_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "FormAc")
            {
                //rfrmDusmeYenilemeKayit frm = new rfrmDusmeYenilemeKayit();
                //frm.Show(MyFoy);

                AdimAdimDavaKaydi.Forms.frmDosyaKimlikBilgileri frm = new AdimAdimDavaKaydi.Forms.frmDosyaKimlikBilgileri();
                frm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frm_FormClosed);
                frm.Show(MyFoy);
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                DataRepository.AV001_TD_BIL_DUSME_YENILEMEProvider.DeepLoad(gwDavaDusmeYenileme.GetFocusedRow() as AV001_TD_BIL_DUSME_YENILEME, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_DUSME_YENILEME>));
                TList<AV001_TD_BIL_DUSME_YENILEME> DvList = new TList<AV001_TD_BIL_DUSME_YENILEME>();
                DvList.Add(MyDataSource[gwDavaDusmeYenileme.FocusedRowHandle]);
                rfrmDusmeYenilemeKayit frm = new rfrmDusmeYenilemeKayit();
                frm.AddNewList = DvList;
                frm.Show(MyFoy);
            }
        }

        private void frm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_DUSME_YENILEME>));
            gridDavaDusmeYenileme.DataSource = MyFoy.AV001_TD_BIL_DUSME_YENILEMECollection;
        }

        private TList<AV001_TD_BIL_DUSME_YENILEME> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TD_BIL_DUSME_YENILEME> MyDataSource
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
                                                                 typeof(TList<AV001_TD_BIL_DUSME_YENILEME>));
                MyDataSource = MyFoy.AV001_TD_BIL_DUSME_YENILEMECollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                dataNavigatorExtended1.DataSource = MyDataSource;
                vGridControl1.DataSource = MyDataSource;
                gridDavaDusmeYenileme.DataSource = MyDataSource;
            }
        }

        public bool FormDanmi;
        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    if (!FormDanmi)
                        MyDataSource = value.AV001_TD_BIL_DUSME_YENILEMECollection;
                }
            }
        }

        private void ucDavaDusmeYenileme_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            IsLoaded = true;
            this.gridDavaDusmeYenileme.ButtonClick += gridDavaDusmeYenileme_ButtonClick;
            if (MyType == ViewType.GridView)
            {
                panelControl1.Visible = false;
                gridDavaDusmeYenileme.Visible = true;
                //extendedGridControl1.Visible = false;
            }
            if (MyType == ViewType.LayoutView)
            {
                panelControl1.Visible = false;
                gridDavaDusmeYenileme.Visible = false;
                // extendedGridControl1.Visible = true;
            }
            if (MyType == ViewType.VGrid)
            {
                panelControl1.Visible = true;
                gridDavaDusmeYenileme.Visible = false;
                //extendedGridControl1.Visible = false;
            }
            if (!this.DesignMode)
            {
                gridDavaDusmeYenileme.ButtonCevirClick +=
                    gridDavaDusmeYenileme_ButtonCevirClick;
                //extendedGridControl1.ButtonCevirClick +=
                //    new EventHandler<NavigatorButtonClickEventArgs>(gridDavaDusmeYenileme_ButtonCevirClick);
                BindData();

                //Bind LookUps
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
                BelgeUtil.Inits.AdliBirimNoGetir(rlueNo);
                BelgeUtil.Inits.AdliBirimGorevGetir(rlueGorev);
                BelgeUtil.Inits.DusmeYenilemeNedeniGetir(rlueNedeni);
            }
        }

        private void gridDavaDusmeYenileme_ButtonCevirClick(object sender,
                                                            DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            //if (gridDavaDusmeYenileme.Visible)
            //{
            //    extendedGridControl1.Visible = true;
            //    gridDavaDusmeYenileme.Visible = false;

            //}
            //else
            //{
            //    extendedGridControl1.Visible = false;
            //    gridDavaDusmeYenileme.Visible = true;
            //}
        }

        [Description("Görünümü Deðiþtirir.")]
        [Browsable(true)]
        public ViewType MyType { get; set; }
    }
}