using System;

namespace AdimAdimDavaKaydi.Editor.General
{
    [Serializable]
    public class DataField
    {
        private string datasourceTable;
        private int id;

        private string idColumn;

        private int idValue;

        private int length;

        private string name;

        private int positionFrom;

        private int positionTo;

        private int startInd;

        private string text;

        private string value;

        public string DataSourceTable
        {
            get { return datasourceTable; }
            set { datasourceTable = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string IdColumn
        {
            get { return idColumn; }
            set { idColumn = value; }
        }

        public int IdValue
        {
            get { return idValue; }
            set { idValue = value; }
        }

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int PositionFrom
        {
            get { return positionFrom; }
            set { positionFrom = value; }
        }

        public int PositionTo
        {
            get { return positionTo; }
            set { positionTo = value; }
        }

        public int StartIndex
        {
            get { return startInd; }
            set { startInd = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string Value
        {
            get { return value; }
            set { value = value; }
        }
    }
}