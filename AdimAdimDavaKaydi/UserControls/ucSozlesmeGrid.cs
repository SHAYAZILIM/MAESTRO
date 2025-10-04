using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Sozlesme.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucSozlesmeGrid : AvpXUserControl
    {
        public ucSozlesmeGrid()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucSozlesmeGrid_Load;
        }

        private AV001_TD_BIL_FOY myDavaFoy;

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyDavaFoy
        {
            get { return myDavaFoy; }
            set
            {
                myDavaFoy = value;
                if (value != null)
                    MyDataSource = value.AV001_TDI_BIL_SOZLESMECollection;
            }
        }

        private AV001_TI_BIL_FOY _foy;

        [Browsable(false)]
        public AV001_TI_BIL_FOY Foy
        {
            get { return _foy; }
            set
            {
                _foy = value;
                if (value != null)
                    MyDataSource = value.AV001_TDI_BIL_SOZLESMECollection;
            }
        }

        public int AnaSozlesmeID;

        private TList<AV001_TDI_BIL_SOZLESME> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TDI_BIL_SOZLESME> MyDataSource
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
            if (MyDataSource == null) 
                return;
            MyDataSource.ListChanged += MyDataSource_ListChanged;
            MyDataSource.AddingNew += MyDataSource_AddingNew;
            if (!bckWorker.IsBusy)
            {
                bckWorker.DoWork += bckWorker_DoWork;
                bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
                bckWorker.RunWorkerAsync();
            }
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            InitsDoldur();
        }

        private void MyDataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            InitsDoldur();
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyDataSource.Count == 0)
            {
                if (MyDavaFoy != null)
                {
                    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyDavaFoy
                                                                     , false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TDI_BIL_SOZLESME>));
                    MyDataSource = MyDavaFoy.AV001_TDI_BIL_SOZLESMECollection;
                }
                else if (Foy != null)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(Foy
                                                                     , false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TDI_BIL_SOZLESME>));
                    MyDataSource = Foy.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME;
                }
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                InitsDoldur();
                exGridSozlesme.DataSource = MyDataSource;
            }
        }

        private void ucSozlesmeGrid_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            //LOAD
            if (!IsLoaded) InitializeComponent();
            IsLoaded = true;
            BindData();

            if (FocusRecord != null)
                FocusRecord(this, new EventArgs());

            #region Ozellestirme

            if (gridView1.Columns["OZEL_KOD1_ID"] != null)
                gridView1.Columns["OZEL_KOD1_ID"].Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod1;
            if (gridView1.Columns["OZEL_KOD2_ID"] != null)
                gridView1.Columns["OZEL_KOD2_ID"].Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod2;
            if (gridView1.Columns["OZEL_KOD3_ID"] != null)
                gridView1.Columns["OZEL_KOD3_ID"].Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod3;
            if (gridView1.Columns["OZEL_KOD4_ID"] != null)
                gridView1.Columns["OZEL_KOD4_ID"].Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod4;

            #endregion
        }

        private bool initsLoaded;

        private void InitsDoldur()
        {
            if (!initsLoaded && MyDataSource.Count > 0) // Okan ARDIÇ // 06.01.2010 // Performans Çalýþmasý
            {
                BelgeUtil.Inits.SozlesmeAltTipiHepsiGetir(rLueSozlesmeAltTip);
                BelgeUtil.Inits.SozlesmeTipiGetir(rLueSozlesmeTip);
                BelgeUtil.Inits.SozlesmeDurumGetir(rLueSozlesmeDurum);
                BelgeUtil.Inits.SozlesmeOzelKod(rLueSozlesmeOzelKodlar);
                BelgeUtil.Inits.RehinCinsGetir(rLueRehinCins);
                BelgeUtil.Inits.perCariGetir(rLueCari);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
                BelgeUtil.Inits.RehinDurumGetir(rLueRehinDurum);
                BelgeUtil.Inits.IlceGetirOzetli(rLueSizilIlce);
                BelgeUtil.Inits.IlGetir(rLueSicilIl);
                BelgeUtil.Inits.SicilTipGetir(rLueSicilTip);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
                BelgeUtil.Inits.HarcIstisnaGetir(rLueHarcIstisna);
                BelgeUtil.Inits.BankaKartTipiGetir(rLueKartTipi);
                initsLoaded = true;
            }
        }

        public event EventHandler<EventArgs> FocusRecord;

        private void exGridSozlesme_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) 
                return;
            if (Foy != null)
            {
                if (e.Button.Tag.ToString() == "FormAc")
                {
                    frmSozlesmeKayit frm = new frmSozlesmeKayit();
                    frm.MyNNKayitSozlesme = AnaSozlesmeID;
                    frm.Show();
                    frm.FormClosed += frm_FormClosed;
                }
                if (e.Button.Tag.ToString() == "KaydýDuzenle")
                {
                    frmSozlesmeTakip frm = new frmSozlesmeTakip();
                    TList<AV001_TDI_BIL_SOZLESME> DvList = new TList<AV001_TDI_BIL_SOZLESME>();
                    DvList.Add(MyDataSource[gridView1.FocusedRowHandle]);
                    frm.ShowDialog(DvList);
                }
            }
            else if (AnaSozlesmeID != null)
            {
                if (e.Button.Tag.ToString() == "FormAc")
                {
                    frmSozlesmeKayit frm = new frmSozlesmeKayit();
                    frm.MyNNKayitSozlesme = AnaSozlesmeID;
                    frm.Show();
                    frm.FormClosed += frm_FormClosed;
                }

                if (e.Button.Tag.ToString() == "KaydýDuzenle")
                {
                    frmSozlesmeTakip frm = new frmSozlesmeTakip();
                    TList<AV001_TDI_BIL_SOZLESME> DvList = new TList<AV001_TDI_BIL_SOZLESME>();
                    DvList.Add(MyDataSource[gridView1.FocusedRowHandle]);
                    frm.ShowDialog(DvList);
                }
            }
            if (myDavaFoy != null)
            {
                if (e.Button.Tag.ToString() == "FormAc")
                {
                    frmSozlesmeEkle frm = new frmSozlesmeEkle();

                    frm.Show(Foy);
                    frm.FormClosed += frm_FormClosed;
                }
            }
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BindData();
        }
    }
}