using AVPSchemaGenerator.Base;
using AVPSchemaGenerator.Collections;
using AVPSchemaGenerator.Common;
using AVPSchemaGenerator.Interfaces;
using System;
using System.Xml.Serialization;

namespace AVPSchemaGenerator.Types
{
    public class StoredProcedure : DBObject, IDBCompare, IDisposable
    {
        #region Fields

        protected string _fullDefinition;

        #endregion Fields

        #region Constructors

        public StoredProcedure(string name, ComparedEnum compare)
            : base(name, compare)
        {
            this.Compare = true;
            this.Parameters = new ParameterCollection();
            this.Definition = string.Empty;
            this.ParamList = string.Empty;
            this.Schema = "dbo";
            this._fullDefinition = string.Empty;
        }

        ~StoredProcedure()
        {
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
        public string Definition
        {
            get;
            set;
        }

        [XmlIgnore]
        public string FullDefinition
        {
            set { FullDefinition = value; }
            get
            {
                string str = this.Definition;
                if (this.ParamList != string.Empty)
                {
                    str = String.Format("CREATE PROCEDURE {0}({1}) {2}", base.Name, this.ParamList, this.Definition);
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
            return (String.Format("{0}\r\n{1}\r\nGO\r\n", this.SQLDropMSSQL2MSSQL(), this.SQLCreateMSSQL2MSSQL()));
        }

        public string SQLCreateMSSQL2MSSQL()
        {
            return this.Definition;
        }

        public string SQLDropMSSQL2MSSQL()
        {
            return (String.Format("DROP PROCEDURE [{0}].[{1}];\r\nGO\r\n\r\n", this.Schema, base.Name));
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

        #endregion Methods
    }
}