using AVPSchemaGenerator.Base;
using AVPSchemaGenerator.Common;
using AVPSchemaGenerator.Interfaces;
using System;
using System.Xml.Serialization;

namespace AVPSchemaGenerator.Types
{
    public class Column : DBObject, IDBCompare, IDisposable
    {
        #region Fields

        private bool isDisposed = false;

        #endregion Fields

        #region Constructors

        public Column(string name, ComparedEnum compared)
            : base(name, compared)
        {
            this.Compare = true;
            this.IsRowguidcol = this.IsComputed = this.IsIdentity = this.IsNotForReplication = false;
        }

        ~Column()
        {
            this.Dispose(false);
        }

        #endregion Constructors

        #region Properties

        [XmlIgnore]
        public string CharacterMaximumLength
        {
            get;
            set;
        }

        [XmlIgnore]
        public string CollationCatalog
        {
            get;
            set;
        }

        [XmlIgnore]
        public string CollationName
        {
            get;
            set;
        }

        [XmlIgnore]
        public string CollationSchema
        {
            get;
            set;
        }

        [XmlIgnore]
        public string ColumnDefault
        {
            get;
            set;
        }

        [XmlIgnore]
        public string ColumnType
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
        public string DataType
        {
            get;
            set;
        }

        [XmlIgnore]
        public string DateTimePrecision
        {
            get;
            set;
        }

        [XmlIgnore]
        public string DisplayDescription
        {
            set { DisplayDescription = value; }
            get
            {
                string name = base.Name;
                if (this.UserDefinedTypeName != null)
                {
                    if (this.UserDefinedTypeNameSchema != null)
                        name = String.Format("{0}[{1}].", name + " ( ", this.UserDefinedTypeNameSchema);
                    else
                        name = String.Format("{0} ( ", name);
                    name = String.Format("{0}[{1}]", name, this.UserDefinedTypeName);
                }
                else
                {
                    name = String.Format("{0} ( {1}", name, this.DataType);
                    switch (this.DataType.ToLower())
                    {
                        case "nvarchar":
                        case "varchar":
                        case "char":
                        case "text":
                        case "nchar":
                        case "ntext":
                            name = String.Format("{0}({1})", name, CharacterMaximumLength);
                            goto other;

                        case "money":
                        case "float":
                        case "decimal":
                            if (this.NumericScale != null)
                                name = String.Format("{0}({1}, {2}", name, this.NumericPrecision, this.NumericScale);
                            else
                                name = String.Format("{0}({1}", name, this.NumericPrecision);
                            name = String.Format("{0})", name);
                            goto other;
                        case "varbinary":
                            if (this.CharacterMaximumLength == "-1" || this.CharacterMaximumLength == "-1") name = String.Format("{0}(1)", name);
                            break;
                    }
                }
            other:
                name = String.Format("{0}, {1}", name, ((this.IsNullable.ToLower() == "yes") ? "Null" : "Not Null"));
                if (this.ColumnDefault != null)
                {
                    name = String.Format("{0}, Default: {1}", name, this.ColumnDefault);
                }
                if (this.IsIdentity)
                {
                    string str3 = name;
                    name = String.Format("{0}, Identity({1}, {2})", str3, this.SeedValue, this.IncrementValue);
                }
                return (String.Format("{0} )", name));
            }
        }

        [XmlIgnore]
        public string Extra
        {
            get;
            set;
        }

        [XmlIgnore]
        public string IncrementValue
        {
            get;
            set;
        }

        [XmlIgnore]
        public bool IsComputed
        {
            get;
            set;
        }

        [XmlIgnore]
        public bool IsIdentity
        {
            get;
            set;
        }

        [XmlIgnore]
        public bool IsNotForReplication
        {
            get;
            set;
        }

        [XmlIgnore]
        public string IsNullable
        {
            get;
            set;
        }

        [XmlIgnore]
        public bool IsRowguidcol
        {
            get;
            set;
        }

        [XmlIgnore]
        public string NumericPrecision
        {
            get;
            set;
        }

        [XmlIgnore]
        public string NumericScale
        {
            get;
            set;
        }

        [XmlIgnore]
        public string SeedValue
        {
            get;
            set;
        }

        [XmlIgnore]
        public string UserDefinedTypeName
        {
            get;
            set;
        }

        [XmlIgnore]
        public string UserDefinedTypeNameSchema
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods
        
        public string SQLScriptMSSQL2MSSQL()
        {
            return this.SQLScriptMSSQL2MSSQL(false);
        }

        public string SQLScriptMSSQL2MSSQL(bool bAlter)
        {
            string str = String.Format("[{0}] ", base.Name);
            if (this.UserDefinedTypeName != null)
            {
                if (this.UserDefinedTypeNameSchema != null)
                {
                    str = String.Format("{0}[{1}].", str, this.UserDefinedTypeNameSchema);
                }
                str = String.Format("{0}[{1}]", str, this.UserDefinedTypeName);
            }
            else
            {
                str = String.Format("{0}[{1}]", str, this.DataType);
                string str2 = this.DataType.ToLower();
                if (str2 != null)
                {
                    if ((str2 != "nvarchar") && (str2 != "varchar") && (str2 != "char") && (str2 != "nchar") && (str2 != "varbinary"))
                    {
                        if ((str2 == "float") || (str2 == "decimal"))
                        {
                            if (this.NumericScale != null)
                                str = String.Format("{0}({1}, {2}", str, this.NumericPrecision, this.NumericScale);
                            else
                                str = String.Format("{0}({1}", str, this.NumericPrecision);
                            str = String.Format("{0})", str);
                        }
                    }
                    else
                    {
                        str = String.Format("{0}({1})", str, this.CharacterMaximumLength == "-1" ? "max" : this.CharacterMaximumLength);
                    }
                }
            }
            if (this.IsRowguidcol)
            {
                str = String.Format(@"{0} ROWGUIDCOL ", str);
            }
            if ((this.CollationName != null) && (this.UserDefinedTypeName == null))
            {
                str = String.Format(@"{0} COLLATE {1}", str, this.CollationName);
            }
            if (this.IsNullable.ToUpper().Trim() == "NO")
            {
                str = String.Format(@"{0} NOT NULL ", str);

                //if ((this.ColumnDefault != null && this.ColumnDefault.Trim().ToUpper() != "(NULL)") && bAlter) //08.10.2009
                //{
                //    str = String.Format("{0} DEFAULT {1}", str, this.ColumnDefault);
                //}
            }
            else
            {
                str = String.Format(@"{0} NULL ", str);
            }

            if (!bAlter && this.IsIdentity)
            {
                string str3 = str;
                str = String.Format(@"{0} IDENTITY ({1},{2})", str3, this.SeedValue, this.IncrementValue);
                if (this.IsNotForReplication)
                {
                    str = String.Format(@"{0} NOT FOR REPLICATION ", str);
                }
            }
            return str;
        }

        private void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    CharacterMaximumLength = CollationCatalog = CollationName = CollationSchema = ColumnDefault = ColumnType = DataType = DateTimePrecision = DisplayDescription = Extra = IncrementValue = IsNullable = NumericPrecision = NumericScale = SeedValue = UserDefinedTypeName = UserDefinedTypeNameSchema = null;
                    Dispose();
                }
                isDisposed = true;
            }
        }

        #endregion Methods
    }
}