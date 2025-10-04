using System;
using System.Collections.Generic;
using AdimAdimDavaKaydi.Util.BaseClasses.AvpFormClass.AvpFormUtil;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Util.BaseClasses.AvpFormData
{
    [Serializable]
    public class AvpFormAvpDataSourceEventArgs : AvpFormEventArgs
    {
        private AvpDataSource _dataSource;

        public AvpDataSource DataSource
        {
            get { return _dataSource; }
            set { _dataSource = value; }
        }
    }

    public class ColumnsDefaultValurs
    {
        public string ColumnName { get; set; }

        public object Data { get; set; }

        public string TableName { get; set; }
    }

    [Serializable]
    public class AvpFormAddNewEventArgs : AvpFormEventArgs
    {
        private IEntity newData;

        public IEntity NewData
        {
            get { return newData; }
            set { newData = value; }
        }

        private AvpDataSource _dataSource;

        public AvpDataSource DataSource
        {
            get { return _dataSource; }
            set { _dataSource = value; }
        }

        private List<ColumnsDefaultValurs> _defaultValues;

        public List<ColumnsDefaultValurs> DefaultValues
        {
            get { return _defaultValues; }
            set { _defaultValues = value; }
        }
    }
}