using System;
using System.ComponentModel;
using System.Text;
using AdimAdimDavaKaydi.Forms.Dava;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucGenelNotlar : AvpXUserControl
    {
        private TList<AV001_TI_BIL_FOY_GENEL_NOT> _MyDataSource;

        private BackgroundWorker bckWorker = new BackgroundWorker();

        private bool initsLoaded;

        private AV001_TI_BIL_FOY myFoy;

        public ucGenelNotlar()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucDavaGenelNotlar_Load;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_FOY_GENEL_NOT> MyDataSource
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
                    MyDataSource = value.AV001_TI_BIL_FOY_GENEL_NOTCollection;
            }
        }

        [Description("Görünümü Deðiþtirir.")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ViewType MyType { get; set; }

        public static string Validate(AV001_TD_BIL_FOY_GENEL_NOT row)
        {
            StringBuilder sb = new StringBuilder();
            if (row.NOTLAR == null)
                sb.AppendLine("* Notlar boþ olamaz.");
            return sb.ToString();
        }

        public void BindData()
        {
            if (MyFoy == null)
                return;

            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy
                                                             , false, DeepLoadType.IncludeChildren,
                                                             typeof(TList<AV001_TI_BIL_FOY_GENEL_NOT>));
            _MyDataSource = MyFoy.AV001_TI_BIL_FOY_GENEL_NOTCollection;

            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                try
                {
                    MyDataSource.AddingNew += MyDataSource_AddingNew;
                    MyDataSource.ListChanged += MyDataSource_ListChanged;
                    InitsDoldur(false);
                    bindingSource1.DataSource = MyDataSource;
                }
                catch
                {
                }
            }
        }

        private void bindingSource1_AddingNew(object sender, AddingNewEventArgs e)
        {
            InitsDoldur(false);

            //throw new NotImplementedException();
        }

        private void gridControl1_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            else if (e.Button.Tag.ToString() == "FormAc")
            {
                rFrmDavaGenelNotlar frmGenelNot = new rFrmDavaGenelNotlar();
                InitsDoldur(true);
                frmGenelNot.Show(MyFoy);
            }

            else if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                DataRepository.AV001_TI_BIL_FOY_GENEL_NOTProvider.DeepLoad(
                    MyDataSource[gridView4.FocusedRowHandle], false, DeepLoadType.IncludeChildren,
                    typeof(TList<AV001_TI_BIL_FOY_GENEL_NOT>));
                TList<AV001_TI_BIL_FOY_GENEL_NOT> DvList = new TList<AV001_TI_BIL_FOY_GENEL_NOT>();
                DvList.Add(MyDataSource[gridView4.FocusedRowHandle]);
                rFrmDavaGenelNotlar frmGenelNot = new rFrmDavaGenelNotlar();
                frmGenelNot.AddNewListIcra = DvList;
                frmGenelNot.Show(MyFoy);
            }
        }

        private void InitsDoldur(bool newItem)
        {
            if ((!initsLoaded && MyDataSource != null && MyDataSource.Count > 0) || newItem)
            {
                BelgeUtil.Inits.KontrolKimGetir(rlueKontrolKim);

                initsLoaded = true;
            }
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            InitsDoldur(false);
        }

        private void MyDataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            InitsDoldur(false);
        }

        private void ucDavaGenelNotlar_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            IsLoaded = true;
            bindingSource1.AddingNew += bindingSource1_AddingNew;
            dnDavaGenelNotlar.DataSource = bindingSource1;
            gridControl1.DataSource = bindingSource1;
            if (MyType == ViewType.GridView)
            {
                panelControl1.Visible = false;
                gridControl1.Visible = true;
            }
            if (MyType == ViewType.LayoutView)
            {
                panelControl1.Visible = false;
                gridControl1.Visible = false;
            }

            BindData();
        }
    }
}