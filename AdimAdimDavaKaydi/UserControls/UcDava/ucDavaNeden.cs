using System;
using System.ComponentModel;
using AdimAdimDavaKaydi.Forms.Dava;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucDavaNeden : AvpXUserControl
    {
        public ucDavaNeden()
        {
            this.Load += ucDavaNeden_Load;
        }

        private TList<AV001_TD_BIL_DAVA_NEDEN> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TD_BIL_DAVA_NEDEN> MyDataSource
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
                                                                 typeof(TList<AV001_TD_BIL_DAVA_NEDEN>));
                MyDataSource = MyFoy.AV001_TD_BIL_DAVA_NEDENCollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                if (gcDavaNeden == null) return;
                gcDavaNeden.DataSource = MyDataSource;
                gcDavaNeden.ShowOnlyPredefinedDetails = true;
                gcDavaNeden.ButtonClick += gcDavaNeden_ButtonClick;
            }
        }

        private void gcDavaNeden_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "FormAc")
            {
                frmDavaNedenGirisi frm = new frmDavaNedenGirisi();
                frm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frm_FormClosed);
                frm.Show(this.MyFoy);
            }
            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                TList<AV001_TD_BIL_DAVA_NEDEN> DvList = new TList<AV001_TD_BIL_DAVA_NEDEN>();
                DvList.Add(MyDataSource[gwDavaNeden.FocusedRowHandle]);
                frmDavaNedenGirisi frm = new frmDavaNedenGirisi();
                frm.Duzenleme = true;
                frm.AddNewList = DvList;
                frm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frm_FormClosed);
                frm.Show(MyFoy);
            }
        }

        void frm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            MyFoy.AV001_TD_BIL_DAVA_NEDENCollection = DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.GetByDAVA_FOY_ID(MyFoy.ID);
            gcDavaNeden.DataSource = MyFoy.AV001_TD_BIL_DAVA_NEDENCollection;
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
                    MyDataSource = value.AV001_TD_BIL_DAVA_NEDENCollection;
            }
        }

        private void ucDavaNeden_Load(object sender, EventArgs e)
        {
            InitializeComponent();

            if (!this.DesignMode)
            {
                IsLoaded = true;
                try
                {
                    BelgeUtil.Inits.TazminatHesapTipiGetir(rlueTazminatHesapTip);
                    BelgeUtil.Inits.DavaNedenTipGetir(rlueDavaNedenTip);
                    BelgeUtil.Inits.TarafStatuGetir(rlueDavaEdenTarafStatu);
                    BelgeUtil.Inits.DavaAdNedenKodGetir(Talep);
                    BelgeUtil.Inits.YuzdeBicimiAyarla(oran);
                    BelgeUtil.Inits.AdliBirimAdliyeGetir(Adliye);
                    BelgeUtil.Inits.perCariGetir(Taraf);
                    BelgeUtil.Inits.ParaBicimiAyarla(Tutar);
                    BelgeUtil.Inits.FaizTipiGetir(FaizTip);
                    BelgeUtil.Inits.FaizKalemGetir(FaizKalem);
                    BelgeUtil.Inits.DovizTipGetir(DovizTip);

                    #region Ozellestirme

                    if (gwDavaNeden.Columns.ColumnByFieldName("REFERANS_NO1") != null)
                        gwDavaNeden.Columns.ColumnByFieldName("REFERANS_NO1").Caption =
                            Kimlikci.Kimlik.DavaDnReferans.Referans1;
                    if (gwDavaNeden.Columns.ColumnByFieldName("REFERANS_NO2") != null)
                        gwDavaNeden.Columns.ColumnByFieldName("REFERANS_NO2").Caption =
                            Kimlikci.Kimlik.DavaReferans.Referans2;

                    #endregion

                    if (MyFoy != null)
                        BelgeUtil.Inits.DavaAdNedenKodGetir(Talep);

                    BindData();
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        public delegate void OnFocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e);

        public event OnFocusedRowChanged FocusedRowChanged;

        private void gwDavaNeden_FocusedRowChanged(object sender,
                                                   DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (FocusedRowChanged != null)
                FocusedRowChanged(sender, e);
        }
    }
}