using System;
using System.Collections.Generic;

namespace AVPTransfer
{
    #region Enumerations

    public enum ExportType
    {
        Aktarılmayacak = -1, Belirtilmemis = 0, Tumu = 1, Farklar = 2
    }

    public enum RelationType
    {
        Bulunmuyor = 0, Esit = 1, Farkli = 2
    }

    #endregion Enumerations

    public class LogInfo
    {
        #region Fields

        public Dictionary<string, int> ExList;
        public Dictionary<int, Item> SqlExList;

        #endregion Fields

        #region Constructors

        public LogInfo()
        {
            SqlExList = new Dictionary<int, Item>();
            ExList = new Dictionary<string, int>();
        }

        #endregion Constructors

        #region Properties

        public int ExCount
        {
            get;
            set;
        }

        public int RowCount
        {
            get;
            set;
        }

        #endregion Properties
    }

    public class Table
    {
        #region Constructors
        
        public Table(string name)
        {
            Name = name;
            ColumnList = new ColumnCollection();
            Relationtype = RelationType.Bulunmuyor;
            Exporttype = ExportType.Belirtilmemis;
        }

        public Table(int id, string name, int Priority)
        {
            ID = id;
            Name = name;
            ExportPriority = Priority;
            ColumnList = new ColumnCollection();
            Relationtype = RelationType.Bulunmuyor;
            Exporttype = ExportType.Belirtilmemis;
        }

        #endregion Constructors

        #region Properties

        public string AppendCommandText
        {
            get;
            set;
        }

        public ColumnCollection ColumnList
        {
            get;
            set;
        }

        public string CommandText
        {
            get;
            set;
        }

        public List<String> DisabledRelationList
        {
            get;
            set;
        }

        public bool Exported
        {
            get;
            set;
        }

        public int ExportPriority
        {
            get;
            set;
        }

        public ExportType Exporttype
        {
            get;
            set;
        }

        public string Filter
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }

        public bool IdentityExist
        {
            get;
            set;
        }

        public LogInfo Log
        {
            get;
            set;
        }

        public bool MasterDetail
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public List<Table> ParentTables
        {
            get;
            set;
        }

        public ColumnCollection Pks
        {
            get;
            set;
        }

        public RelationType Relationtype
        {
            get;
            set;
        }

        public Dictionary<string, ColumnCollection> UniqueList
        {
            get;
            set;
        }

        public bool Virtual
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public override bool Equals(object obj)
        {
            Table tbl = (Table)obj;
            if (tbl.Name == this.Name)
                return true;
            //else if (tbl.Name + "_MASTER" == this.Name)
            //{
            //    this.MasterDetail = true;
            //    return true;
            //}
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return this.Name;
        }

        #endregion Methods
    }
}

public class Item
{
    #region Constructors
    
    public Item(string text, int count)
    {
        Text = text; Count = count;
    }

    public Item(string text, int count, string PK)
    {
        Text = text; Count = count; PKs += String.Format("{0},", PK);
    }

    #endregion Constructors

    #region Properties

    public int Count
    {
        get;
        set;
    }

    public string PKs
    {
        get;
        set;
    }

    public string Text
    {
        get;
        set;
    }

    #endregion Properties
}