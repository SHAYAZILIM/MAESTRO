using AVPSchemaGenerator.Base;
using AVPSchemaGenerator.Collections;
using AVPSchemaGenerator.Common;
using AVPSchemaGenerator.Interfaces;
using System;
using System.Xml.Serialization;

namespace AVPSchemaGenerator.Types
{
    public class Constraint : DBObject, IDBCompare, IDisposable
    {
        #region Fields

        private bool isDisposed = false;

        #endregion Fields

        #region Constructors

        public Constraint(string name, ComparedEnum compared)
            : base(name, compared)
        {
            this.Check = true;
            this.Compare = true;
            this.Columns = new ConstraintColumnCollection();
            this.ReferencedColumns = new ConstraintColumnCollection();
            this.ReferencedTableName = null;
        }

        ~Constraint()
        {
            Dispose(false);
        }

        #endregion Constructors

        #region Properties

        public bool Check
        {
            get;
            set;
        }

        [XmlIgnore]
        public ConstraintColumnCollection Columns
        {
            get;
            set;
        }

        [XmlAttribute]
        public bool Compare
        {
            get;
            set;
        }

        [XmlIgnore]
        public string IndexType
        {
            get;
            set;
        }

        [XmlIgnore]
        public ConstraintColumnCollection ReferencedColumns
        {
            get;
            set;
        }

        [XmlIgnore]
        public string ReferencedTableName
        {
            get;
            set;
        }

        [XmlIgnore]
        public ConstraintType Type
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods
        
        public void SetType(string sType)
        {
            switch (sType)
            {
                case "CHECK": this.Type = ConstraintType.CHECK; break;
                case "FOREIGN KEY": this.Type = ConstraintType.FOREIGN_KEY; break;
                case "UNIQUE": this.Type = ConstraintType.UNIQUE; break;
                case "PRIMARY KEY": this.Type = ConstraintType.PRIMARY_KEY; break;
                case "DEFAULT": this.Type = ConstraintType.DEFAULT; break;
                default: this.Type = ConstraintType.FOREIGN_KEY; break;
            }
        }

        public string SQLScriptMSSQL2MSSQL()
        {
            string str = string.Empty;
            switch (this.Type)
            {
                case ConstraintType.PRIMARY_KEY:
                    str = String.Format("{0} \t CONSTRAINT [{1}] PRIMARY KEY  {2} (", str, base.Name, this.IndexType);
                    for (int i = 0; i < this.Columns.Count; i++)
                    {
                        object obj2 = str;
                        str = String.Format("{0}[{1}]", obj2, this.Columns[this.Columns[i].OrdinalPosition - 1]);
                        if (i != (this.Columns.Count - 1))
                        {
                            str = String.Format("{0},", str);
                        }
                    }
                    return (String.Format("{0})", str));

                case ConstraintType.UNIQUE:
                    str = String.Format("{0} \t CONSTRAINT [{1}] UNIQUE {2} (", str, base.Name, this.IndexType);
                    for (int j = 0; j < this.Columns.Count; j++)
                    {
                        object obj3 = str;
                        str = String.Format("{0}[{1}]", obj3, this.Columns[this.Columns[j].OrdinalPosition - 1]);
                        if (j != (this.Columns.Count - 1))
                        {
                            str = String.Format("{0},", str);
                        }
                    }
                    return (String.Format("{0})", str));

                case ConstraintType.FOREIGN_KEY:
                    str = String.Format("{0} \t CONSTRAINT [{1}] FOREIGN KEY (", str, base.Name);
                    for (int k = 0; k < this.Columns.Count; k++)
                    {
                        object obj4 = str;
                        str = String.Format("{0}[{1}]", obj4, this.Columns[k]);
                        if (k != (this.Columns.Count - 1))
                        {
                            str = String.Format("{0},", str);
                        }
                    }
                    str = String.Format(@"{0} REFERENCES {1} (", (str + ") "), this.ReferencedTableName);
                    for (int m = 0; m < this.ReferencedColumns.Count; m++)
                    {
                        object obj5 = str;
                        str = String.Format("{0}[{1}]", obj5, this.ReferencedColumns[m]);
                        if (m != (this.ReferencedColumns.Count - 1))
                        {
                            str = String.Format("{0},", str);
                        }
                    }
                    return (String.Format("{0})", str));

                case ConstraintType.CHECK:
                    {
                        string str2 = str;
                        return (String.Format("{0} \t CONSTRAINT [{1}] CHECK {2}", str2, base.Name, this.Columns[0].CheckClause));
                    }
                case ConstraintType.DEFAULT:
                    {
                        string str3 = str;
                        return (String.Format("{0} \t CONSTRAINT [{1}] DEFAULT {2} FOR {3}", str3, base.Name, this.Columns[0].CheckClause, this.Columns[0].Name));
                    }
            }
            return str;
        }

        public override string ToString()
        {
            string nameList = "";
            foreach (ConstraintColumn column in this.Columns) nameList += String.Format("{0},", column.Name);
            return nameList;
        }

        private void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    ReferencedTableName = IndexType = null;
                    Columns = ReferencedColumns = null;
                    Dispose();
                }
                isDisposed = true;
            }
        }

        #endregion Methods
    }
}