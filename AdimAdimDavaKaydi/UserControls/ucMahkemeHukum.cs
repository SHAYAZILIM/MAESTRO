using System;
using System.ComponentModel;
using AdimAdimDavaKaydi.Forms.Dava;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucMahkemeHukum : AvpXUserControl
    {
        public ucMahkemeHukum()
        {
            this.Load += ucMahkemeHukum_Load;
        }

        private TList<AV001_TD_BIL_MAHKEME_HUKUM> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TD_BIL_MAHKEME_HUKUM> MyDataSource
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
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_MAHKEME_HUKUM>));
                MyDataSource = MyFoy.AV001_TD_BIL_MAHKEME_HUKUMCollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                gridMahkemeHukum.DataSource = MyDataSource;
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
                    MyDataSource = value.AV001_TD_BIL_MAHKEME_HUKUMCollection;
            }
        }

        private void ucMahkemeHukum_Load(object sender, EventArgs e)
        {
            //LOAD
            InitializeComponent();
            IsLoaded = true;
            if (!this.DesignMode)
            {
                try
                {
                    gridMahkemeHukum.ButtonClick += gridMahkemeHukum_ButtonClick;
                    gridMahkemeHukum.ShowOnlyPredefinedDetails = true;

                    BelgeUtil.Inits.perCariGetir(rlueTarafCari);
                    BelgeUtil.Inits.DovizTipGetir(rlueDovizTip);
                    BelgeUtil.Inits.HukumGetir(rlueHukum);

                    BindData();
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void gridMahkemeHukum_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "FormAc")
            {
                Forms.Dava.frmHukumGirisi frm = new frmHukumGirisi();
                frm.Show(MyFoy);
                frm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frm_FormClosed);
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                TList<AV001_TD_BIL_MAHKEME_HUKUM> hukumler=new TList<AV001_TD_BIL_MAHKEME_HUKUM> ();
                var selectedHukum = gwMahkemeHukum.GetFocusedRow() as AV001_TD_BIL_MAHKEME_HUKUM;
                hukumler.Add(selectedHukum);
                Forms.Dava.frmHukumGirisi frm = new frmHukumGirisi();
                frm.AddNewList = hukumler;
                //frm.Duzenlemi = true;
                frm.Show(MyFoy);
                frm.MyFoy = MyFoy;
                //frm.Show(selectedHukum);
                frm.FormClosed += frm_FormClosed;
            }
        }

        private void frm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_MAHKEME_HUKUM>));
            gridMahkemeHukum.DataSource = MyFoy.AV001_TD_BIL_MAHKEME_HUKUMCollection;
        }
    }
}