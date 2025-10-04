using AVPSchemaGenerator.Base;
using AVPSchemaGenerator.Collections;
using AVPSchemaGenerator.Common;
using AVPSchemaGenerator.Interfaces;
using System;
using System.Xml.Serialization;

namespace AVPSchemaGenerator.Types
{
    public class Index : DBObject, IDBCompare, IDisposable
    {
        #region Fields

        private bool isDisposed = false;

        #endregion Fields

        #region Constructors

        public Index(string name, ComparedEnum compared)
            : base(name, compared)
        {
            this.IndexKeys = new IndexKeyCollection();
        }

        ~Index()
        {
            Dispose(false);
        }

        #endregion Constructors

        #region Properties

        [XmlAttribute]
        public bool Compare
        {
            get;
            set;
        }

        [XmlIgnore]
        public string Description
        {
            get;
            set;
        }

        [XmlIgnore]
        public string DisplayDescription
        {
            set { DisplayDescription = value; }
            get { return (String.Format("{0} ({1})", base.Name, this.IndexType.ToLower())); }
        }

        [XmlIgnore]
        public decimal FillFactor
        {
            get;
            set;
        }

        [XmlIgnore]
        public bool IgnoreDuplicateKeys
        {
            get;
            set;
        }

        [XmlIgnore]
        public int IndexId
        {
            get;
            set;
        }

        [XmlIgnore]
        public IndexKeyCollection IndexKeys
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
        public bool IsPrimaryKey
        {
            get;
            set;
        }

        [XmlIgnore]
        public bool IsUnique
        {
            get;
            set;
        }

        [XmlIgnore]
        public bool IsUniqueConstraint
        {
            get;
            set;
        }

        [XmlIgnore]
        public string TableName
        {
            get;
            set;
        }

        [XmlIgnore]
        public string TableSchema
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods
        
        public string SQLAlterMSSQL2MSSQL()
        {
            if (this.IsPrimaryKey)
            {
                return string.Empty;
            }
            string tmpStr = this.IsUniqueConstraint || this.IsUnique ? "UNIQUE" : "";
            string str = String.Format("CREATE {0} {1} INDEX [{2}] ON [{3}].[{4}](", tmpStr, this.IndexType, base.Name, this.TableSchema, this.TableName);
            int num = 0;
            foreach (IndexKey key in this.IndexKeys)
            {
                num++;
                if (num < this.IndexKeys.Count)
                    str = String.Format("{0}{1}, ", str, key.Name);
                else
                    str = str + key.Name;
            }
            return (String.Format("{0}) WITH ( DROP_EXISTING = ON )\r\nGO\r\n", str));
        }

        public string SQLCreateMSSQL2MSSQL()
        {
            if (this.IsPrimaryKey)
            {
                return string.Empty;
            }

            string tmpStr = this.IsUniqueConstraint || this.IsUnique ? "UNIQUE" : "";
            string str = String.Format("CREATE {0} {1} INDEX [{2}] ON [{3}].[{4}](", tmpStr, this.IndexType, base.Name, this.TableSchema, this.TableName);

            //            string str = String.Format(@"\cf3 if not exists (select * from sysindexes
            //  where id=object_id('{3}') and name='{1}') CREATE {0} INDEX \cf0 [{1}] \cf3 ON \cf0 [{2}].[{3}](", this.IndexType, base.Name, this.TableSchema, this.TableName);

            int num = 0;
            foreach (IndexKey key in this.IndexKeys)
            {
                num++;
                if (num < this.IndexKeys.Count)
                    str = String.Format("{0}[{1}], ", str, key.Name);
                else
                    str = String.Format("{0}[{1}]", str, key.Name);
            }
            return (String.Format("{0})\r\nGO\r\n", str));
        }

        public string SQLDropMSSQL2MSSQL()
        {
            if (this.IsPrimaryKey)
            {
                return null;
            }
            return (String.Format("DROP INDEX [{0}] ON [{1}].[{2}]\r\nGO\r\n", base.Name, this.TableSchema, this.TableName));
        }

        public string SQLScript(bool bNotExistInMaster)
        {
            string str = string.Empty;
            if (bNotExistInMaster)
            {
                return this.SQLDropMSSQL2MSSQL();
            }
            switch (base.Compared)
            {
                case ComparedEnum.Modified:
                    return this.SQLAlterMSSQL2MSSQL();

                case ComparedEnum.NotCompared:
                    return str;

                case ComparedEnum.New:
                    return this.SQLCreateMSSQL2MSSQL();
            }
            return str;
        }

        public override string ToString()
        {
            string nameList = "";
            foreach (IndexKey column in this.IndexKeys) nameList += String.Format("{0},", column.Name);
            return nameList;
        }

        private void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    Description = DisplayDescription = IndexType = TableName = TableSchema = null;
                    IndexKeys = null;
                    Dispose();
                }
                isDisposed = true;
            }
        }

        #endregion Methods
    }
}