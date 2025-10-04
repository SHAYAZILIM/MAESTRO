using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucDusmeYenileme : AvpXUserControl
    {
        public bool Kayitmi;

        private TList<AV001_TI_BIL_DUSME_YENILEME> _MyDataSource;

        private BackgroundWorker bckWorker = new BackgroundWorker();

        private AV001_TI_BIL_FOY myFoy;

        public ucDusmeYenileme()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucDusmeYenileme_Load;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_DUSME_YENILEME> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;

                BindData();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (!Kayitmi && value != null)
                    MyDataSource = value.AV001_TI_BIL_DUSME_YENILEMECollection;
            }
        }

        [Description("Görünümü deðiþtirir.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ViewType MyView { get; set; }

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
            if (MyDataSource.Count == 0 && !Kayitmi)
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy
                                                                 , false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_DUSME_YENILEME>));
                MyDataSource = MyFoy.AV001_TI_BIL_DUSME_YENILEMECollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && IsLoaded)
            {
                gridDusmeYenileme.DataSource = MyDataSource;
                dnDusmeYenileme.DataSource = MyDataSource;
                vGDusmeYenileme.DataSource = MyDataSource;

                //extendedGridControl1.DataSource = gridDusmeYenileme.DataSource;
            }
        }

        private void gridDusmeYenileme_ButtonCevirClick(object sender,
                                                        DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            //if (gridDusmeYenileme.Visible)
            //{
            //    extendedGridControl1.Visible = true;
            //    gridDusmeYenileme.Visible = false;
            //}
            //else
            //{
            //    extendedGridControl1.Visible = false;
            //    gridDusmeYenileme.Visible = true;
            //}
        }

        private void gridDusmeYenileme_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                if (e.Button.Tag.ToString() == "FormdanEkle")
                {
                    frmDusmeYenileme frm = new frmDusmeYenileme();

                    // frm.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;

                    //frm.MyFoy = MyFoy;
                    frm.Show(MyFoy);
                }
                if (e.Button.Tag.ToString() == "KayitDuzenle")
                {
                    frmDusmeYenileme frm = new frmDusmeYenileme();

                    //frm.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.AddNewList = new TList<AV001_TI_BIL_DUSME_YENILEME>();
                    frm.AddNewList.Add(gridView10.GetFocusedRow() as AV001_TI_BIL_DUSME_YENILEME);
                    frm.Show(MyFoy);
                }
            }
        }

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // gridDusmeYenileme_ButtonClick(sender, new NavigatorButtonClickEventArgs(e.Item.Tag as NavigatorCustomButton));
        }

        private void ucDusmeYenileme_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            IsLoaded = true;
            gridDusmeYenileme.ButtonCevirClick += gridDusmeYenileme_ButtonCevirClick;
            gridDusmeYenileme.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;

            //extendedGridControl1.ButtonCevirClick += new EventHandler<DevExpress.XtraEditors.NavigatorButtonClickEventArgs>(gridDusmeYenileme_ButtonCevirClick);

            if (MyView == ViewType.GridView)
            {
                panelControl1.Visible = false;
                gridDusmeYenileme.Visible = true;
                gridDusmeYenileme.BringToFront();
            }
            else if (MyView == ViewType.VGrid)
            {
                panelControl1.Visible = true;
                gridDusmeYenileme.Visible = false;
                panelControl1.BringToFront();
            }
        }
    }
}