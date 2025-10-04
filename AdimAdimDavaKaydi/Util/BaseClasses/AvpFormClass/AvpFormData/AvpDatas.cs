using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Util.BaseClasses.AvpFormData
{
    [Serializable]
    public class AvpDatas
    {
        private IBindingList _datas;

        public IBindingList Datas
        {
            get { return _datas; }
            set { _datas = value; }
        }

        private string _table;

        public string Table
        {
            get { return _table; }
            set { _table = value; }
        }

        private Control _dataSourceOwner;

        public Control DataSourceOwner
        {
            get { return _dataSourceOwner; }
            set { _dataSourceOwner = value; }
        }

        private IBindingList _selectedDatas;

        public IBindingList SelectedDatas
        {
            get { return _selectedDatas; }
            set { _selectedDatas = value; }
        }
    }
}