using System.Collections.ObjectModel;

namespace AVPTransfer
{
    public class Column
    {
        #region Constructors

        public Column(string name)
        {
            Name = name;
        }

        public Column(string name, string datatype, bool allownull, Table parent, string dbDefault, int length)
        {
            Name = name; DataType = datatype; AllowNull = allownull; Parent = parent; DBDefault = dbDefault; Length = length;
        }

        #endregion Constructors

        #region Properties

        public bool AllowNull
        {
            get;
            set;
        }

        public string Coalesce
        {
            get;
            set;
        }

        public string Convert
        {
            get;
            set;
        }

        public string DataType
        {
            get;
            set;
        }

        public string DBDefault
        {
            get;
            set;
        }

        public Column DBRelation
        {
            get;
            set;
        }

        public int Length
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Table Parent
        {
            get;
            set;
        }

        public bool PrimaryKey
        {
            get;
            set;
        }

        public Column RelationWith
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public override bool Equals(object obj)
        {
            Column col = (Column)obj;
            if (col.Name == this.Name)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override string ToString()
        {
            return this.Name;
        }

        #endregion Methods
    }

    public class ColumnCollection : Collection<Column>
    {
        #region Methods

        public string[] ToArray()
        {
            string[] res = new string[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                res[i] = this[i].Name;
            }
            return res;
        }

        #endregion Methods
    }
}