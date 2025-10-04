using AdimAdimDavaKaydi.Forms.Dava;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;

namespace AdimAdimDavaKaydi.DavaTakip
{
    public partial class ucTutuklanmaVeGozAlt : AvpXUserControl
    {
        public ucTutuklanmaVeGozAlt()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucTutuklanmaVeGozAlt_Load;
        }

        private TList<AV001_TD_BIL_TUTUKLANMA> _MyDataSource;

        private BackgroundWorker bckWorker = new BackgroundWorker();

        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public TList<AV001_TD_BIL_TUTUKLANMA> MyDataSource
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
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                    MyDataSource = value.AV001_TD_BIL_TUTUKLANMACollection;
            }
        }

        [Description("Görünümü Deðiþtirir.")]
        [Browsable(true)]
        public ViewType MyType { get; set; }

        public void BindData()
        {
            if (!bckWorker.IsBusy)
            {
                bckWorker.DoWork += bckWorker_DoWork;
                bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
                bckWorker.RunWorkerAsync();
            }
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyDataSource == null) return;
            if (MyDataSource.Count == 0)
            {
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy
                                                                 , false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TD_BIL_TUTUKLANMA>));
                MyDataSource = MyFoy.AV001_TD_BIL_TUTUKLANMACollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                extgrdTutuklanma.DataSource = MyDataSource;
                dataNavigatorExtended1.DataSource = MyDataSource;
                vGridControl1.DataSource = extgrdTutuklanma.DataSource;
            }
        }

        private void extgrdTutuklanma_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            if (e.Button.Tag.ToString() == "FormAc")
            {
                rfrmTutuklanma frm = new rfrmTutuklanma();
                frm.Show(MyFoy);
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                DataRepository.AV001_TD_BIL_TUTUKLANMAProvider.DeepLoad(MyDataSource[vGridControl1.FocusedRecord], false,
                                                                        DeepLoadType.IncludeChildren,
                                                                        typeof(TList<AV001_TD_BIL_TUTUKLANMA>));
                TList<AV001_TD_BIL_TUTUKLANMA> DvList = new TList<AV001_TD_BIL_TUTUKLANMA>();
                DvList.Add(MyDataSource[vGridControl1.FocusedRecord]);
                rfrmTutuklanma frm = new rfrmTutuklanma();
                frm.AddNewList = DvList;
                frm.Show(MyFoy);
            }
        }

        private void ucTutuklanmaVeGozAlt_Load(object sender, EventArgs e)
        {
            //LOAD

            if (this.DesignMode) return;
            if (!IsLoaded)
            {
                InitializeComponent();
                IsLoaded = true;

                this.extgrdTutuklanma.ButtonClick
                    += extgrdTutuklanma_ButtonClick;

                if (MyType == ViewType.GridView)
                {
                    panelControl1.Visible = false;
                    extgrdTutuklanma.Visible = true;
                }
                if (MyType == ViewType.LayoutView)
                {
                    //panelControl1.Visible = false;
                    //gridDavaAraKarar.Visible = false;
                    //lyAraKarar.Visible = true;
                }
                if (MyType == ViewType.VGrid)
                {
                    panelControl1.Visible = true;
                    extgrdTutuklanma.Visible = false;
                }

                try
                {
                    extgrdTutuklanma.ShowOnlyPredefinedDetails = true;

                    BelgeUtil.Inits.MasrafAvansHedefTipGetir(rlueHedefTip);
                    BelgeUtil.Inits.SerbestBirakilmaNedenGetir(rlueBirakilmaNeden);
                    if (MyFoy != null)
                        BelgeUtil.Inits.DavaEdilenTarafGetir(MyFoy, new[] { rlueTutuklananCari });
                    BelgeUtil.Inits.TutuklanmaTipGetir(rlueTutuklanmaTipi);
                    BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
                    BelgeUtil.Inits.AdliBirimNoGetir(rlueBirimNo);
                    BelgeUtil.Inits.AdliBirimGorevGetir(rlueGorev);
                    BelgeUtil.Inits.perCariGetir(rlueTutuklananCari);
                    BelgeUtil.Inits.KararSonucuGetir(rlueKararSonucu);
                    BindData();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }
    }
}