using System;

namespace BelgeUtil
{
    public class CacheData
    {
        public CacheData()
        {
        }

        public CacheData(string key, object data, DataType dataType)
        {
            this._key = key;
            this._data = data;
            this._DatasType = dataType;
        }

        public CacheData(string key, object data)
        {
            this._key = key;
            this._data = data;
            this._DatasType = DataType.Diger;
        }

        private object _data;

        private DataType _DatasType;

        private string _key;

        private int index;

        public object Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public DataType DatasType
        {
            get { return _DatasType; }
            set { _DatasType = value; }
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
    }

}