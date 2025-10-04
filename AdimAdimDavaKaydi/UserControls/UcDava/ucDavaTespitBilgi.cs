using System;
using System.ComponentModel;
using System.Text;
using AdimAdimDavaKaydi.Forms.Dava;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucDavaTespitBilgi : AvpXUserControl
    {
        public ucDavaTespitBilgi()
        {
            this.Load += ucDavaTespitBilgi_Load;
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
                    MyDataSource = value.AV001_TD_BIL_FOY_TESPITCollection;
            }
        }

        private TList<AV001_TD_BIL_FOY_TESPIT> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TD_BIL_FOY_TESPIT> MyDataSource
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
                                                                 typeof(TList<AV001_TD_BIL_FOY_TESPIT>));
                MyDataSource = MyFoy.AV001_TD_BIL_FOY_TESPITCollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                dnTespit.DataSource = MyDataSource;
                vgTespit.DataSource = MyDataSource;
                if (vgTespit.FocusedRecord < 0)
                    vgTespit.FocusedRecord = 0;

                if (MyDataSource != null && MyDataSource.Count > 0)
                {
                    dnTespitDetay.DataSource =
                        MyDataSource[vgTespit.FocusedRecord].AV001_TD_BIL_FOY_TESPIT_DETAYCollection;
                    vgTespitDetay.DataSource = dnTespitDetay.DataSource;
                }
                gridDavaTespitBilgileri.DataSource = MyDataSource;
                extendedGridControl1.DataSource = MyDataSource;
            }
        }

        private void ucDavaTespitBilgi_Load(object sender, EventArgs e)
        {
            //LOAD
            InitializeComponent();
            IsLoaded = true;
            if (MyType == ViewType.GridView)
            {
                splitContainerControl1.Visible = false;
                gridDavaTespitBilgileri.Visible = true;
                extendedGridControl1.Visible = false;
            }
            if (MyType == ViewType.LayoutView)
            {
                splitContainerControl1.Visible = false;
                gridDavaTespitBilgileri.Visible = false;
                extendedGridControl1.Visible = true;
            }
            if (MyType == ViewType.VGrid)
            {
                splitContainerControl1.Visible = true;
                gridDavaTespitBilgileri.Visible = false;
                extendedGridControl1.Visible = false;
            }
            if (!this.DesignMode)
            {
                gridDavaTespitBilgileri.ButtonCevirClick
                    += gridDavaTespitBilgileri_ButtonCevirClick;
                extendedGridControl1.ButtonCevirClick
                    += gridDavaTespitBilgileri_ButtonCevirClick;

                gridDavaTespitBilgileri.ShowOnlyPredefinedDetails = false;

                BelgeUtil.Inits.MalKategoriGetir(rlueMalKategorisi);
                BelgeUtil.Inits.MalTurGetir(rlueMalTuru);
                BelgeUtil.Inits.MalcinsGetir(rlueMalCins);
                AV001_TD_BIL_FOY_TESPIT_DETAY tesp = new AV001_TD_BIL_FOY_TESPIT_DETAY();
                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.CariPersonelGetir(rlueSorumluPersonel);
                BelgeUtil.Inits.BirimKodGetir(rlueAdetBirim);
                BelgeUtil.Inits.TespitOzelKodGetir(rlueOzelKod);
                BelgeUtil.Inits.CariGetirBilirkisi(rlueCari);
                BelgeUtil.Inits.CariGetirBilirkisi(rlueBilirKisi);
                BindData();
            }
        }

        [Description("Görünümü Deðiþtirir.")]
        [Browsable(true)]
        public ViewType MyType { get; set; }

        public static string Validate(AV001_TD_BIL_FOY_TESPIT_DETAY row)
        {
            StringBuilder sb = new StringBuilder();

            if (row.MAL_KATEGORI_ID == 0)
                sb.AppendLine("* Kategorisi boþ olamaz.");

            if (row.MAL_TUR_ID == 0)
                sb.AppendLine("* Mal Türü boþ olamaz");

            if (row.MAL_CINS_ID == 0)
                sb.AppendLine("* Mal Cinsi boþ olamaz");

            return sb.ToString();
        }

        public static string Validate(AV001_TD_BIL_FOY_TESPIT row)
        {
            return " ";
        }

        private void gridDavaTespitBilgileri_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "FormAc")
            {
                rFrmDavaTespitBilgi frm = new rFrmDavaTespitBilgi();
                frm.Show(MyFoy);
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                DataRepository.AV001_TD_BIL_FOY_TESPITProvider.DeepLoad(
                    MyDataSource[gwDavaTespitBilgileri.FocusedRowHandle], false, DeepLoadType.IncludeChildren,
                    typeof(TList<AV001_TD_BIL_FOY_TESPIT>));
                TList<AV001_TD_BIL_FOY_TESPIT> DvList = new TList<AV001_TD_BIL_FOY_TESPIT>();
                DvList.Add(MyDataSource[gwDavaTespitBilgileri.FocusedRowHandle]);
                rFrmDavaTespitBilgi frm = new rFrmDavaTespitBilgi();
                frm.AddNewList = DvList;
                frm.Show(MyFoy);
            }
        }

        private void gridDavaTespitBilgileri_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gridDavaTespitBilgileri.Visible)
            {
                gridDavaTespitBilgileri.Visible = false;
                extendedGridControl1.Visible = true;
                splitContainerControl1.Visible = false;
                extendedGridControl1.BringToFront();
            }
        }

        private void dnTespitDetay_OnCevirClick(object sender, EventArgs e)
        {
            if (splitContainerControl1.Visible)
            {
                gridDavaTespitBilgileri.Visible = true;
                extendedGridControl1.Visible = false;
                splitContainerControl1.Visible = false;
                gridDavaTespitBilgileri.BringToFront();
            }
        }

        private void extendedGridControl1_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (extendedGridControl1.Visible)
            {
                gridDavaTespitBilgileri.Visible = false;
                extendedGridControl1.Visible = false;
                splitContainerControl1.Visible = true;
                splitContainerControl1.BringToFront();
            }
        }
    }
}