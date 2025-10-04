namespace Datas.TablesColumn
{
    public class EntityColumns
    {
        private int _index;
        private string _name;

        private string _table;

        private string _type;

        private object _value;

        private int _visibleStatus;

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public string Table
        {
            get { return _table; }
            set { _table = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public int VisibleStatus
        {
            get { return _visibleStatus; }
            set { _visibleStatus = value; }
        }
    }
}