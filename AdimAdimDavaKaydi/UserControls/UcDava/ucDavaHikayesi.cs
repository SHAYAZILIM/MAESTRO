using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms.Dava;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucDavaHikayesi : AvpXUserControl
    {
        public ucDavaHikayesi()
        {
            this.Load += ucDavaHikayesi_Load;
        }

        private void gridDavaninIzahi_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            if (e.Button.Tag.ToString() == "FormAc")
            {
                rFrmDavaIzah frm = new rFrmDavaIzah();
                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(MyFoy);
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                DataRepository.AV001_TD_BIL_FOY_HIKAYEProvider.DeepLoad(MyDataSource[gwDananinIzahi.FocusedRowHandle],
                                                                        false, DeepLoadType.IncludeChildren,
                                                                        typeof(TList<AV001_TD_BIL_FOY_HIKAYE>));
                TList<AV001_TD_BIL_FOY_HIKAYE> DvList = new TList<AV001_TD_BIL_FOY_HIKAYE>();
                DvList.Add(MyDataSource[gwDananinIzahi.FocusedRowHandle]);
                rFrmDavaIzah frm = new rFrmDavaIzah();
                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.AddNewList = DvList;
                frm.Show(MyFoy);
            }
        }

        private TList<AV001_TD_BIL_FOY_HIKAYE> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TD_BIL_FOY_HIKAYE> MyDataSource
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
            if (MyFoy != null)
            {
                if (MyDataSource.Count == 0)
                {
                    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy
                                                                     , false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TD_BIL_FOY_HIKAYE>));
                    MyDataSource = MyFoy.AV001_TD_BIL_FOY_HIKAYECollection;
                }
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                dataNavigatorExtended1.DataSource = MyDataSource;
                vGridControl1.DataSource = MyDataSource;
                gridDavaninIzahi.DataSource = MyDataSource;
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
                {
                    if (value.AV001_TD_BIL_FOY_HIKAYECollection.Count == 0)
                        DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TD_BIL_FOY_HIKAYE>));
                    MyDataSource = value.AV001_TD_BIL_FOY_HIKAYECollection;
                }
            }
        }

        private void ucDavaHikayesi_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            IsLoaded = true;
            this.gridDavaninIzahi.ButtonClick += gridDavaninIzahi_ButtonClick;
            this.rlueHikayeSureci.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(rlueHikayeSureci_ButtonClick);
            if (MyType == ViewType.GridView)
            {
                panelControl1.Visible = false;
                gridDavaninIzahi.Visible = true;
                gridDavaninIzahi.BringToFront();
            }
            if (MyType == ViewType.LayoutView)
            {
                //panelControl1.Visible = false;
                //gridTemyizBilgileri.Visible = false;
                //extendedGridControl1.Visible = true;
            }
            if (MyType == ViewType.VGrid)
            {
                panelControl1.Visible = true;
                gridDavaninIzahi.Visible = false;
                panelControl1.BringToFront();
            }
            if (!this.DesignMode)
            {
                gridDavaninIzahi.ButtonCevirClick
                    += gridDavaninIzahi_ButtonCevirClick;

                BelgeUtil.Inits.HikayeSurecGetir(rlueHikayeSureci);
                BindData();
            }
        }

        private void rlueHikayeSureci_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null) return;
            if (e.Button.Tag.ToString() == "Yeni")
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    TD_KOD_FOY_HIKAYE_SUREC surec = new TD_KOD_FOY_HIKAYE_SUREC();
                    surec.HIKAYE_SUREC = (sender as LookUpEdit).Text;
                    surec.KONTROL_NE_ZAMAN = DateTime.Now;
                    surec.KONTROL_KIM = "AVUKATPRO";
                    surec.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                    surec.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    surec.STAMP = AvukatProLib.Kimlik.DefaultStamp;

                    tran.BeginTransaction();
                    DataRepository.TD_KOD_FOY_HIKAYE_SURECProvider.Save(tran, surec);
                    tran.Commit();

                    MessageBox.Show("Kaydedildi.", "BÝLGÝ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BelgeUtil.Inits._HikayeSurecGetir.Add(surec);
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen) tran.Rollback();
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                    MessageBox.Show("Kayýt Yapýlamadý.", "BÝLGÝ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void gridDavaninIzahi_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            //if (gridDavaninIzahi.Visible)
            //{
            //    //gridControl1.Visible = true;
            //    gridDavaninIzahi.Visible = false;
            //    gridControl1.BringToFront();
            //}
            //else
            //{
            //    gridControl1.Visible = false;
            //    gridDavaninIzahi.Visible = true;
            //    gridDavaninIzahi.BringToFront();
            //}
        }

        [Description("Görünümü Deðiþtirir.")]
        [Browsable(true)]
        public ViewType MyType { get; set; }

        public static string Validate(AV001_TD_BIL_FOY_HIKAYE row)
        {
            StringBuilder sb = new StringBuilder();

            if (row.HIKAYE_SUREC_ID == 0)
                sb.AppendLine("* Süreç seçmelisiniz");

            return sb.ToString();
        }
    }
}