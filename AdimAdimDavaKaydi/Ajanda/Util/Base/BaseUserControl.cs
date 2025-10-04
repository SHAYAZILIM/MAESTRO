using System;

namespace AdimAdimDavaKaydi.Ajanda.Util.Base
{
    public partial class BaseUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public BaseUserControl()
        {
            InitializeComponent();
        }

        private AvpDataSourceCollection _dataSource;

        public AvpDataSourceCollection DataSource
        {
            get { return _dataSource; }
            set { _dataSource = value; }
        }

        public virtual void LoadUserControls()
        {
        }

        public virtual void ParentFormShown()
        {
        }

        public virtual void Save(string DataKey)
        {
            _dataSource.FindByKey(DataKey).Save();
        }

        public virtual void SaveAll()
        {
            for (int i = 0; i < _dataSource.Count; i++)
            {
                _dataSource[i].Save();
            }
        }

        public virtual void SetDataSource(AvpDataSourceCollection datas)
        {
            _dataSource = datas;
        }

        private void BaseUserControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                this.FindForm().Shown += BaseUserControl_Shown;
        }

        private void BaseUserControl_Shown(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                CheckForIllegalCrossThreadCalls = false;

                //   Thread thrd = new Thread(new ThreadStart(LoadUserControls));
                // thrd.Start();
                LoadUserControls();
            }
            ParentFormShown();
        }
    }
}