using AVPSchemaGenerator.Base;
using AVPSchemaGenerator.Common;
using AVPSchemaGenerator.Interfaces;
using System;
using System.Xml.Serialization;

namespace AVPSchemaGenerator.Types
{
    public class View : DBObject, IDBCompare
    {
        #region Fields

        protected string _bodyDefinition;

        private System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
        private bool isDisposed = false;

        #endregion Fields

        #region Constructors
        
        public View(string name, ComparedEnum compared)
            : base(name, compared)
        {
            this.Compare = true;
            this.Schema = "dbo";
            this.Definition = string.Empty;
        }

        ~View()
        {
            Dispose(false);
        }

        #endregion Constructors

        #region Properties

        [XmlIgnore]
        public string BodyDefinition
        {
            get
            {
                if (String.IsNullOrEmpty(this._bodyDefinition) && !String.IsNullOrEmpty(Definition))
                {
                    this.GetBodyDefinition();
                }
                return this._bodyDefinition;
            }
            set
            {
                //     string str = this.Definition.ToUpper(culture);
                string str = this.Definition;
                str = str.Remove(0, str.IndexOf(this.Name) + this.Name.Length);
                str = str.TrimStart('\r', '\n', ' ');
                str = str.Remove(0, str.IndexOf("AS", StringComparison.OrdinalIgnoreCase) + 2);
                str = str.TrimStart('\r', '\n', ' ');
                this._bodyDefinition = str;
                //int increment = 0;
                //int index = str.IndexOf("CREATE");
                //if (index > -1)
                //{
                //    index = str.IndexOf("VIEW");
                //    if (index > -1)
                //    {
                //        index = str.IndexOf("\r\nAS\r\n");
                //        increment = 4;
                //    }
                //    if (index == -1)
                //    {
                //        index = str.IndexOf(" AS\r\n");
                //        increment = 3;
                //    }
                //    if (index == -1)
                //    {
                //        index = str.IndexOf(" AS ");
                //        increment = 4;
                //    }
                //    if (index == -1)
                //    {
                //        index = str.IndexOf("\r\nAS ");
                //        increment = 2;
                //    }
                //    if (index > -1)
                //    {
                //        index += increment;
                //    }
                //}
                //if (index > -1)
                //{
                //    this._bodyDefinition = this.Definition.Remove(0, index);
                //}
                //else
                //{
                //    this._bodyDefinition = this.Definition;
                //}
            }
        }

        [XmlIgnore]
        public string CheckOption
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
        public string Definition
        {
            get;
            set;
        }

        [XmlIgnore]
        public string IsUpdatable
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

        public void Dispose()
        {
            if (!isDisposed)
                Dispose(true);
            GC.SuppressFinalize(this);
        }

        public string SQLAlterMSSQL2MSSQL()
        {
            return (String.Format("\r\nALTER VIEW [{0}].[{1}] AS {2}", this.Schema, base.Name, this.BodyDefinition));
        }

        public string SQLCreateMSSQL2MSSQL()
        {
            return this.Definition;
        }

        public string SQLDropMSSQL2MSSQL()
        {
            return (String.Format("DROP VIEW [{0}].[{1}];\r\nGO\r\n", this.Schema, base.Name));
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
                    BodyDefinition = CheckOption = Definition = IsUpdatable = Schema = null;
                    Dispose();
                }
                isDisposed = true;
            }
        }

        private void GetBodyDefinition()
        {
            //string str = this.Definition.ToUpper(culture);
            string str = this.Definition;
            str = str.Remove(0, str.IndexOf(this.Name) + this.Name.Length);
            str = str.TrimStart('\r', '\n', ' ');
            str = str.Remove(0, str.IndexOf("AS", StringComparison.OrdinalIgnoreCase) + 2);
            str = str.TrimStart('\r', '\n', ' ');
            this.BodyDefinition = str;
            //int increment = 0;
            //int index = str.IndexOf("CREATE");
            //if (index > -1)
            //{
            //    str = str.Remove(index, index + 6);
            //    index = str.IndexOf("VIEW");
            //    if (index > -1)
            //    {
            //        str = str.Remove(index, index + 4);
            //        index = str.IndexOf("\r\nAS\r\n");
            //        increment = 6;
            //    }
            //    if (index == -1)
            //    {
            //        index = str.IndexOf(" AS\r\n");
            //        increment = 5;
            //    }
            //    if (index == -1)
            //    {
            //        index = str.IndexOf(" AS ");
            //        increment = 4;
            //    }
            //    if (index == -1)
            //    {
            //        index = str.IndexOf("\r\nAS ");
            //        increment = 5;
            //    }
            //    if (index > -1)
            //    {
            //        index += increment;
            //        str = str.Remove(index, index + increment);
            //    }
            //}
            //if (index > -1)
            //{
            //    this._bodyDefinition = this.Definition.Remove(0, index);
            //}
            //else
            //{
            //    this._bodyDefinition = this.Definition;
            //}
        }

        #endregion Methods
    }
}