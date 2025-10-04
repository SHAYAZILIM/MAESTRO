using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class ucMehilBilgileri : AvpXUserControl
    {
        private TList<AV001_TI_BIL_MEHIL> _MyDataSource;

        private BackgroundWorker bckWorker = new BackgroundWorker();

        private bool initsFilled;

        private AV001_TI_BIL_FOY myFoy;

        public ucMehilBilgileri()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucMehilBilgileri_Load;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_MEHIL> MyDataSource
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                    MyDataSource = value.AV001_TI_BIL_MEHILCollection;
            }
        }

        public void BindData()
        {
            if (MyDataSource == null) return;
            MyDataSource.ListChanged += MyDataSource_ListChanged;
            MyDataSource.AddingNew += MyDataSource_AddingNew;

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
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy
                                                                 , false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_MEHIL>));
                MyDataSource = MyFoy.AV001_TI_BIL_MEHILCollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && IsLoaded)
            {
                InitsDoldur();
                extMehilBilgileri.DataSource = MyDataSource;
            }
        }

        private void extMehilBilgileri_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (extMehilBilgileri.Visible)
            {
                extMehilBilgileri.Visible = false;
            }
            else
            {
                extMehilBilgileri.Visible = true;
            }
        }

        private void extMehilBilgileri_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                if (e.Button.Tag.ToString() == "FormdanEkle")
                {
                    rFrmMehil frm = new rFrmMehil();
                    frm.MyDataSource = new TList<AV001_TI_BIL_MEHIL>();

                    //frm.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.Show(MyFoy);
                }
                else if (e.Button.Tag.ToString() == "KaydiDuzenle")
                {
                    rFrmMehil frm = new rFrmMehil();
                    TList<AV001_TI_BIL_MEHIL> mList = new TList<AV001_TI_BIL_MEHIL>();
                    mList.Add(gridView1.GetFocusedRow() as AV001_TI_BIL_MEHIL);
                    frm.MyDataSource = mList;

                    //frm.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.Show(MyFoy);
                }
            }
        }

        private void InitsDoldur()
        {
            if (!initsFilled && MyDataSource.Count > 0)
            {
                BelgeUtil.Inits.perCariGetir(rLueMehilIsteyenCari);
                BelgeUtil.Inits.IlamKararGetir(rLueIlamBilgi);
                BelgeUtil.Inits.IcraItirazSonucGetir(rLueMehilKararSonuc);
                BelgeUtil.Inits.IcraErtelenmeNedenGetir(rLueIcraErtelemeNeden);
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

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            extMehilBilgileri_ButtonClick(sender, new NavigatorButtonClickEventArgs(e.Item.Tag as NavigatorCustomButton));
        }

        private void ucMehilBilgileri_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            //LOAD
            if (!IsLoaded) InitializeComponent();
            IsLoaded = true;

            //InitsDoldur();
            extMehilBilgileri.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            extMehilBilgileri.ButtonCevirClick += extMehilBilgileri_ButtonCevirClick;
            if (MyFoy != null)
                extMehilBilgileri.DataSource = MyFoy.AV001_TI_BIL_MEHILCollection;

            //extendedGridControl1.ButtonCevirClick +=
            //new EventHandler<NavigatorButtonClickEventArgs>(extMehilBilgileri_ButtonCevirClick);
            BindData();
        }
    }
}