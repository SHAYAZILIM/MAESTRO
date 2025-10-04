using AVPSchemaGenerator.Base;
using AVPSchemaGenerator.Collections;
using AVPSchemaGenerator.Common;
using AVPSchemaGenerator.Interfaces;
using System;
using System.Xml.Serialization;

namespace AVPSchemaGenerator.Types
{
    public class Function : DBObject, IDBCompare, IDisposable
    {
        #region Fields

        protected string _fullDefinition;

        private bool isDisposed = false;

        #endregion Fields

        #region Constructors

        public Function(string name, ComparedEnum compare)
            : base(name, compare)
        {
            this.Compare = true;
            this.Parameters = new ParameterCollection();
            this.Definition = string.Empty;
            this.ParamList = string.Empty;
            this.DataType = string.Empty;
            this._fullDefinition = string.Empty;
            this.Schema = "dbo";
        }

        ~Function()
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
        public string DataType
        {
            get;
            set;
        }

        [XmlIgnore]
        public string Definition
        {
            get;
            set;
        }

        [XmlIgnore]
        public string FullDefinition
        {
            set
            { FullDefinition = value; }
            get
            {
                string str = this.Definition;
                if (this.ParamList != string.Empty)
                {
                    str = String.Format("CREATE FUNCTION {0}({1}) RETURNS {2} {3}", base.Name, this.ParamList, this.DataType, this.Definition);
                }
                return str;
            }
        }

        [XmlIgnore]
        public ParameterCollection Parameters
        {
            get;
            set;
        }

        [XmlIgnore]
        public string ParamList
        {
            get;
            set;
        }

        [XmlAttribute]
        public string Schema
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods
        
        public string SQLAlterMSSQL2MSSQL()
        {
            return (this.SQLDropMSSQL2MSSQL() + this.SQLCreateMSSQL2MSSQL());
        }

        public string SQLCreateMSSQL2MSSQL()
        {
            return this.Definition;
        }

        public string SQLDropMSSQL2MSSQL()
        {
            return (String.Format("DROP FUNCTION [{0}].[{1}];\r\nGO\r\n", this.Schema, base.Name));
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

        private void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    DataType = Definition = FullDefinition = ParamList = Schema = null;
                    Dispose();
                }
                isDisposed = true;
            }
        }

        #endregion Methods
    }
}