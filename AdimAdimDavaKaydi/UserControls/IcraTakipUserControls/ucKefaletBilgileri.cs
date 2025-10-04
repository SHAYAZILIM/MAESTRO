using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using AvukatProLib;
using System.Data;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucKefaletBilgileri : AvpXUserControl
    {
        private BackgroundWorker bckWorker = new BackgroundWorker();

        private bool initsFilled;

        private AV001_TI_BIL_FOY myFoy;

        public ucKefaletBilgileri()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucKefaletBilgileri_Load;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTable MyDataSource { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_KEFALET_BILGILERI> MyDataSourceYeniKayit { get; set; }
        

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    DatayiDoldur();
                    MyDataSourceYeniKayit = value.AV001_TI_BIL_KEFALET_BILGILERICollection;
                }
            }
        }

        [Description("Görünümü deðiþtirir.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ViewType MyView { get; set; }

        public void BindData()
        {
            if (MyDataSource == null) return;
            MyDataSourceYeniKayit.ListChanged += MyDataSource_ListChanged;
            MyDataSourceYeniKayit.AddingNew += MyDataSource_AddingNew;
            if (!bckWorker.IsBusy)
            {
                bckWorker.DoWork += bckWorker_DoWork;
                bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
                bckWorker.RunWorkerAsync();
            }
        }

        public void DatayiDoldur()
        {
            if (gridKefaletBilgileri == null)
                InitializeComponent();

            if (MyFoy != null)
            {
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                cn.AddParams("@ICRA_FOY_ID", MyFoy.ID);
                gridKefaletBilgileri.Tag = "AV001_TI_BIL_KEFALET_BILGILERI";
                MyDataSource = cn.GetDataTable("SELECT * FROM dbo.AV001_TI_BIL_KEFALET_BILGILERI(nolock) where ICRA_FOY_ID=@ICRA_FOY_ID"); 
            }
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyDataSource.Rows.Count == 0 && MyFoy != null)
            {
                DatayiDoldur();
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy
                                                                 , false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_KEFALET_BILGILERI>));
                MyDataSourceYeniKayit = MyFoy.AV001_TI_BIL_KEFALET_BILGILERICollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && IsLoaded)
            {
                try
                {
                    InitsDoldur();
                    gridKefaletBilgileri.DataSource = MyDataSource;
                    dnKefalet.DataSource = MyDataSourceYeniKayit;
                    vGKafalet.DataSource = MyDataSourceYeniKayit;
                }
                catch
                {
                }
            }
        }

        private void gridKefaletBilgileri_ButtonClick(object sender,
                                                      DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                if (e.Button.Tag.ToString() == "FormdanEkle")
                {
                    frmKefaletBilgileri frm = new frmKefaletBilgileri();
                    frm.MyFoy = MyFoy;

                    //frm.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                    frm.Show(MyFoy);
                }
                if (e.Button.Tag.ToString() == "KayitDuzenle")
                {
                    frmKefaletBilgileri frm = new frmKefaletBilgileri();
                    frm.AddNewList = new TList<AV001_TI_BIL_KEFALET_BILGILERI>();
                    frm.AddNewList.Add(DataRepository.AV001_TI_BIL_KEFALET_BILGILERIProvider.GetByID((int)gwKefaletBilgileri.GetFocusedRowCellValue("ID")));
                    frm.MyFoy = MyFoy;

                    //frm.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.Show(MyFoy);
                }
            }
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //DatayiDoldur();
        }

        private void InitsDoldur()
        {
            if (!initsFilled && MyDataSource.Rows.Count > 0)
            {
                BelgeUtil.Inits.perCariGetir(rLueCariID);
                BelgeUtil.Inits.KefaletKapsamGetir(rLueKefaletKapsamID);
                BelgeUtil.Inits.ParaBicimiAyarla(tutar);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizID);
                initsFilled = true;
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

        private void rLueCariID_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null) return;
            if (e.Button.Tag.ToString() == "YeniKayit")
            {
                DevExpress.XtraEditors.LookUpEdit lue = (DevExpress.XtraEditors.LookUpEdit)sender;

                frmCariGenelGiris frm = new frmCariGenelGiris();
                frm.tmpCariAd = lue.Text;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
            }
        }

        private void ucKefaletBilgileri_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            try
            {
                IsLoaded = true;

                BindData();
                if (MyView == ViewType.GridView)
                {
                    panelControl1.Visible = false;
                    gridKefaletBilgileri.Visible = true;
                    gridKefaletBilgileri.BringToFront();
                    DatayiDoldur();
                }
                else if (MyView == ViewType.VGrid)
                {
                    panelControl1.Visible = true;
                    gridKefaletBilgileri.Visible = false;
                    panelControl1.BringToFront();

                    BelgeUtil.Inits.perCariGetir(rLueCariID);
                    BelgeUtil.Inits.KefaletKapsamGetir(rLueKefaletKapsamID);
                    BelgeUtil.Inits.ParaBicimiAyarla(tutar);
                    BelgeUtil.Inits.DovizTipGetir(rLueDovizID);
                    initsFilled = true;
                    //MyDataSourceYeniKayit.Add(new AV001_TI_BIL_KEFALET_BILGILERI());
                    vGKafalet.DataSource = MyDataSourceYeniKayit;
                }

                
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }
    }
}