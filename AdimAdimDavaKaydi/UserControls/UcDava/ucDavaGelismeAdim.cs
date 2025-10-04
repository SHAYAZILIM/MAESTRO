using System;
using System.ComponentModel;
using AdimAdimDavaKaydi.Forms.Dava;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AnaForm;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucDavaGelismeAdim : AvpXUserControl
    {
        public ucDavaGelismeAdim()
        {
            this.Load += ucDavaGelismeAdim_Load;
        }

        private void gridDavaGelismeAdim_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            if (e.Button.Tag.ToString() == "FormAc")
            {
                rfrmDavaGelismeAdim frm = new rfrmDavaGelismeAdim();
                frm.Show(MyFoy);
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                DataRepository.AV001_TD_BIL_FOY_GELISMEProvider.DeepLoad(MyDataSource[vGridControl1.FocusedRecord],
                                                                         false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TD_BIL_FOY_GELISME>));
                TList<AV001_TD_BIL_FOY_GELISME> DvList = new TList<AV001_TD_BIL_FOY_GELISME>();
                DvList.Add(MyDataSource[vGridControl1.FocusedRecord]);
                rfrmDavaGelismeAdim frm = new rfrmDavaGelismeAdim();
                frm.AddNewList = DvList;
                frm.Show(MyFoy);
            }
        }

        private TList<AV001_TD_BIL_FOY_GELISME> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TD_BIL_FOY_GELISME> MyDataSource
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
                                                                 typeof(TList<AV001_TD_BIL_FOY_GELISME>));
                MyDataSource = MyFoy.AV001_TD_BIL_FOY_GELISMECollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                try
                {
                    vGridControl1.DataSource = MyDataSource;
                    gridDavaGelismeAdim.DataSource = MyDataSource;
                    dataNavigatorExtended1.DataSource = MyDataSource;
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex, true, BelgeUtil.Bilesen.Dava, BelgeUtil.Bilesen.Kayit);
                }
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
                    MyDataSource = value.AV001_TD_BIL_FOY_GELISMECollection;
            }
        }

        private void ucDavaGelismeAdim_Load(object sender, EventArgs e)
        {
            //LOAD
            InitializeComponent();
            IsLoaded = true;
            this.gridDavaGelismeAdim.ButtonClick += gridDavaGelismeAdim_ButtonClick;
            if (MView == ViewType.GridView)
            {
                panelControl1.Visible = false;
                gridDavaGelismeAdim.Visible = true;
            }
            else if (MView == ViewType.VGrid)
            {
                panelControl1.Visible = true;
                gridDavaGelismeAdim.Visible = false;
            }
            if (!this.DesignMode)
            {
                try
                {
                    BelgeUtil.Inits.GelismeKaynakTipGetirForDava(rlueKaynakTip);
                    BelgeUtil.Inits.GelismeAdimGetir(rlueGelismeAdimi);
                    BelgeUtil.Inits.perCariGetir(rlueTarafCari);
                    BindData();
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void rlueGelismeAdimi_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {

        }
        private void rlueGelismeAdimi_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Tag == "mEkle")
                {
                    //TDI_KOD_ADLI_BIRIM_GOREV noget = DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.GetByID(MyFoy.ADLI_BIRIM_GOREV_ID.Value);
                    //frmAltKategoriEkle frmalt = new frmAltKategoriEkle(frmAltKategoriEkle.Tipler.DavaKonusu, MyFoy.DAVA_TIP_ID.Value);
                    //frmalt.ADLI_BIRIM_BOLUM_KOD = noget.ADLI_BIRIM_BOLUM_KOD;
                    //frmalt.ShowDialog();

                    //ABSqlConnection cn = new ABSqlConnection();
                    //cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                    frmDavaGelismeKodlari kodedle = new frmDavaGelismeKodlari();
                    kodedle.gelismeAdimGetir();
                    kodedle.ShowDialog();
                    BelgeUtil.Inits.GelismeAdimGetir(rlueGelismeAdimi);                   
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        [Description("Görünümü deðiþtirir.")]
        public ViewType MView { get; set; }
    }
}