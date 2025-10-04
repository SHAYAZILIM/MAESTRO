using System;
using System.ComponentModel;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucDavaGorusme : AvpXUserControl
    {
        public ucDavaGorusme()
        {
            this.Load += ucDavaGorusme_Load;
        }

        private TList<AV001_TDI_BIL_GORUSME> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TDI_BIL_GORUSME> MyDataSource
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
                                                                 typeof(TList<AV001_TDI_BIL_GORUSME>));
                MyDataSource = MyFoy.AV001_TDI_BIL_GORUSMECollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                gridDavaGorusme.DataSource = MyDataSource;
                //gridControl1.DataSource = gridDavaGorusme.DataSource;
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
                    MyDataSource = value.AV001_TDI_BIL_GORUSMECollection;
            }
        }

        private void ucDavaGorusme_Load(object sender, EventArgs e)
        {
            //LOAD
            InitializeComponent();
            IsLoaded = true;
            if (!this.DesignMode)
            {
                try
                {
                    gridDavaGorusme.ShowOnlyPredefinedDetails = true;

                    BelgeUtil.Inits.perCariGetir(rlueCari);
                    BelgeUtil.Inits.CariPersonelGetir(rluePersonelCari);
                    BelgeUtil.Inits.MuhasebeHareketAltKategoriForGorusme(rlueKategori);
                    BelgeUtil.Inits.GorusmeYonuGetir(rluegorusmeYonu);
                    BindData();
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void gridDavaGorusme_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                if (e.Button.Tag.ToString() == "FormdanEkle")
                {
                    Forms.rFrmGorusmeKayit frmGorusmeKaydet = new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();
                    frmGorusmeKaydet.Show(MyFoy);
                }

                if (e.Button.Tag.ToString() == "KaydýDuzenle")
                {
                    DataRepository.AV001_TDI_BIL_GORUSMEProvider.DeepLoad(MyDataSource[gwDavaGorusme.FocusedRowHandle],
                                                                          false, DeepLoadType.IncludeChildren,
                                                                          typeof(TList<AV001_TDI_BIL_GORUSME>));
                    TList<AV001_TDI_BIL_GORUSME> DvList = new TList<AV001_TDI_BIL_GORUSME>();
                    DvList.Add(MyDataSource[gwDavaGorusme.FocusedRowHandle]);
                    Forms.rFrmGorusmeKayit frm = new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();
                    frm.AddNewList = DvList;
                    frm.Show(MyFoy);
                }
            }
        }
    }
}