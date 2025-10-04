using System;
using System.ComponentModel;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucMuvekkilTalimatlari : AvpXUserControl
    {
        public ucMuvekkilTalimatlari()
        {
            if (DesignMode) InitializeComponent();
        }

        private AV001_TI_BIL_FOY _myFoy;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TDIE_BIL_MUVEKKIL_TALIMAT> MyDataSource { get; set; }

        private BackgroundWorker bckWorker = new BackgroundWorker();

        public void BindData()
        {
            if (MyDataSource == null) return;
            MyDataSource.ListChanged += MyDataSource_ListChanged; //Okan ARDIÇ // Performans Çalışması // 06.01.2010
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
            LoadInitsData();
        }

        private void MyDataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            LoadInitsData();
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyDataSource.Count == 0)
            {
                if (MyDavaFoy != null)
                {
                    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyDavaFoy
                                                                     , false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TDIE_BIL_MUVEKKIL_TALIMAT>));
                    MyDataSource = MyDavaFoy.AV001_TDIE_BIL_MUVEKKIL_TALIMATCollection;
                }
                else if (MyFoy != null)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy
                                                                     , false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TDIE_BIL_MUVEKKIL_TALIMAT>));
                    MyDataSource = MyFoy.AV001_TDIE_BIL_MUVEKKIL_TALIMATCollection;
                }
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                LoadInitsData();
                exMuvekkilTlimat.DataSource = MyDataSource;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return _myFoy; }
            set
            {
                _myFoy = value;
                if (value != null)
                    MyDataSource = value.AV001_TDIE_BIL_MUVEKKIL_TALIMATCollection;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private AV001_TD_BIL_FOY _MyDavaFoy;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TD_BIL_FOY MyDavaFoy
        {
            get { return _MyDavaFoy; }
            set
            {
                _MyDavaFoy = value;
                if (value != null)
                    MyDataSource = value.AV001_TDIE_BIL_MUVEKKIL_TALIMATCollection;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            base.OnLoad(e);
            IsLoaded = true;
            BindData();
        }

        private bool initsLoaded;

        private void LoadInitsData()
        {
            if (DesignMode)
            {
                return;
            }
            if (!initsLoaded && MyDataSource.Count > 0) // Okan ARDIÇ // 06.01.2010 // Performans Çalışması
            {
                BelgeUtil.Inits.perCariGetir(rLueCari);
                if (MyDavaFoy != null && !this.DesignMode)
                {
                    BelgeUtil.Inits.MuvekkilByFoy(MyDavaFoy, new[] { rLueMuvekkil });
                }
                else if (MyFoy != null && !this.DesignMode)
                {
                    BelgeUtil.Inits.AlacakliTarafByFoy(MyFoy, new[] { rLueMuvekkil });
                }
                initsLoaded = true;
            }
        }

        private void exMuvekkilTlimat_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null)
                return;

            if (e.Button.Tag.ToString() == "FormAc")
            {
            }

            if (e.Button.Tag.ToString() == "KaydıDuzenle")
            {
            }
        }
    }
}