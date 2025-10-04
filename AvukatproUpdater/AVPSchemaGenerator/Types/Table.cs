using AVPSchemaGenerator.Base;
using AVPSchemaGenerator.Common;
using AVPSchemaGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace AVPSchemaGenerator.Types
{
    public class Table : DBObject, IDBCompare, ISQLScriptable, IDisposable
    {
        #region Fields

        private readonly List<string> NumericDataTypes = new List<string>(new string[] { "BIGINT", "BIT", "DECIMAL", "FLOAT", "INT", "MONEY", "NUMERIC", "SMALLINT", "SMALLMONEY", "TINYINT" });

        private bool isDisposed = false;

        #endregion Fields

        #region Constructors

        public Table(string name, ComparedEnum compared)
            : base(name, compared)
        {
            this.Compare = true;
            this.Columns = new List<Column>();
            this.Constraints = new List<Constraint>();
            this.Indexes = new List<Index>();
            this.Schema = "dbo";
            this.SQLForeignKeysScript = string.Empty;
            this.SQLDropChangedConstraints = string.Empty;
            this.SQLDropChangedForeignKeyConstraints = string.Empty;
        }

        ~Table()
        {
            Dispose(false);
        }

        #endregion Constructors

        #region Properties

        public List<Column> Columns
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

        public List<Constraint> Constraints
        {
            get;
            set;
        }

        [XmlIgnore]
        public bool ContainsComputedColumns
        {
            get;
            set;
        }

        [XmlIgnore]
        public bool ContainsIdentityColumns
        {
            get;
            set;
        }

        public DBSchema DbSchema
        {
            get;
            set;
        }

        public List<Index> Indexes
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

        [XmlIgnore]
        public string SQLDropChangedConstraints
        {
            get;
            private set;
        }

        [XmlIgnore]
        public string SQLDropChangedForeignKeyConstraints
        {
            get;
            private set;
        }

        public string SQLForeignKeysScript
        {
            get;
            private set;
        }

        #endregion Properties

        #region Methods
        
        public string SQLAlterMSSQL2MSSQL()
        {
            bool flag = false;
            //      string str = String.Format("ALTER INDEX ALL ON [{0}].[{1}] DISABLE\r\nGO\r\n", this.Schema, base.Name);
            string str = String.Format("ALTER TABLE [{0}].[{1}] ", this.Schema, base.Name);
            string str2 = string.Empty;
            string str3 = string.Empty;
            string str4 = string.Empty;
            string constraintFirstSql = string.Empty;
            string constraintLastSql = string.Empty;
            string indexFirstSql = string.Empty;
            string indexLastSql = string.Empty;
            List<string> constraintList = new List<string>();
            List<string> indexList = new List<string>();

            foreach (Column column in this.Columns)
            {
                bool flag2 = false;
                if (column.Compared == ComparedEnum.New)
                {
                    string str5 = str2;
                    str2 = String.Format("{0}{1} ADD {2};\r\nGO\r\n", str5, str, column.SQLScriptMSSQL2MSSQL(false));

                    IEnumerable<Constraint> constraint = (from constr in this.Constraints where constr.ToString().Split(',').Contains(column.Name) && constr.Compared == ComparedEnum.New && constr.Type == ConstraintType.DEFAULT select constr);
                    if (constraint != null && column.IsNullable.ToUpper().Trim() == "NO" && constraint.Count() > 0)
                    {
                        string tmpConstrStr = constraint.ElementAt(0).SQLScriptMSSQL2MSSQL().Trim(",\t\r\n".ToCharArray());
                        str2 = String.Format("{0} {1} NOT NULL\r\n", str2.Remove(str2.LastIndexOf("NOT NULL")), tmpConstrStr.Remove(tmpConstrStr.LastIndexOf("FOR", StringComparison.OrdinalIgnoreCase)));
                        constraint.ElementAt(0).Check = false;
                    }
                    str2 = String.Format("{0}\r\nGO\r\n", str2);
                    flag2 = true;
                }
                else if (column.Compared == ComparedEnum.Modified)
                {
                    string str6 = str2;
                    str2 = String.Format("{0}{1} ALTER COLUMN {2};\r\nGO\r\n", str6, str, column.SQLScriptMSSQL2MSSQL(true));
                    System.Data.DataRow[] tmprows = this.DbSchema.DSColumns.Table.Select(String.Format("TABLE_NAME = '{0}' and TABLE_SCHEMA = '{1}' and COLUMN_NAME = '{2}'", this.Name, this.Schema, column.Name));

                    if (tmprows.Count() > 0 && column.IsNullable.ToUpper().Trim() == "NO")
                    {
                        //if (NumericDataTypes.Contains(column.DataType.ToUpper().Trim()))
                        //    defaultValue = column.ColumnDefault ?? "";
                        //else defaultValue = String.Format("'{0}'", column.ColumnDefault ?? "''");
                        if (column != null && column.ColumnDefault != null/* && (column.ColumnDefault.Trim().ToLower() != "null" || column.ColumnDefault.Trim().ToUpper() != "(NULL)")*/)
                            str2 = String.Format("{0}\r\n{1}", String.Format("UPDATE [{0}].[{1}] SET [{2}] = {3} WHERE [{2}] IS NULL\r\nGO\r\n", this.Schema, this.Name, column.Name, column.ColumnDefault ?? ""), str2);
                    }

                    IEnumerable<Constraint> constraints = (from constr in this.Constraints where constr.ToString().Split(',').Contains(column.Name) /*&& constr.Type == ConstraintType.FOREIGN_KEY || constr.Type == ConstraintType.PRIMARY_KEY*/ select constr);
                    if (constraints != null && constraints.Count() > 0) // Column'a bağlı olan constraintler varsa
                    {
                        foreach (Constraint constraint in constraints)
                        {
                            if (!constraintList.Contains(constraint.Name)) // To be able to alter columns first we need to drop the constraints depending on those columns and then recreate them
                            {
                                constraintList.Add(constraint.Name);

                                if (constraint.Type == ConstraintType.PRIMARY_KEY || constraint.Type == ConstraintType.UNIQUE)
                                {
                                    //                                    System.Data.DataRow[] rows = this.DbSchema.ConstraintTable.Select(string.Format("PK='{0}' and PKTABLE='{1}'", constraint.Name, this.Name));
                                    System.Data.DataRow[] rows = this.DbSchema.DataSet.Tables[DBObjectType.CONSTRAINT_COLUMNS.ToString()].Select(string.Format("CONSTRAINT_TYPE = 'FOREIGN KEY' and PK='{0}' and PK_TABLE='{1}' and PK IS NOT NULL", constraint.Name, this.Name));
                                    foreach (System.Data.DataRow row in rows)
                                    {
                                        Table tempTable = this.DbSchema.Tables.Single(table => table.Name == row["FK_TABLE"].ToString());
                                        IEnumerable<Constraint> tmpConstraints = (from tmpConstraint in tempTable.Constraints where tmpConstraint.Name == row["CONSTRAINT_NAME"].ToString() select tmpConstraint);
                                        foreach (Constraint tmpConstraint in tmpConstraints)
                                        {
                                            constraintFirstSql = String.Format("{0} if exists (select * from sys.objects where object_id = object_id('{3}')) ALTER TABLE [{1}].[{2}] DROP CONSTRAINT {3} ;\r\nGO\r\n", constraintFirstSql, this.Schema, row["FK_TABLE"].ToString(), tmpConstraint.Name);
                                            constraintLastSql = String.Format("{0} ALTER TABLE [{1}].[{2}] WITH NOCHECK ADD\r\n {3};\r\nGO\r\n", constraintLastSql, this.Schema, row["FK_TABLE"].ToString(), tmpConstraint.SQLScriptMSSQL2MSSQL().Trim(",\t\r\n".ToCharArray()));
                                        }
                                        tmpConstraints = null;
                                        tempTable = null;
                                    }
                                    rows = null;
                                }
                                else
                                {
                                    if (constraint.Compared == ComparedEnum.Equal)
                                    {
                                        constraintFirstSql = String.Format("{0} if exists (select * from sys.objects where object_id = object_id('{3}')) ALTER TABLE [{1}].[{2}] DROP CONSTRAINT {3} ;\r\nGO\r\n", constraintFirstSql, this.Schema, base.Name, constraint.Name);
                                        constraintLastSql = String.Format("ALTER TABLE [{1}].[{2}] WITH NOCHECK ADD\r\n {3};\r\nGO\r\n{0}", constraintLastSql, this.Schema, base.Name, constraint.SQLScriptMSSQL2MSSQL().Trim(",\t\r\n".ToCharArray()));
                                    }
                                    //if (constraint.Type != ConstraintType.DEFAULT) //24.10.2009
                                    //{
                                    //if (constraint.Compared = ComparedEnum.New)
                                    //{
                                    //    constraintLastSql = String.Format("ALTER TABLE [{1}].[{2}] ADD\r\n {3};\r\nGO\r\n{0}", constraintLastSql, this.Schema, base.Name, constraint.SQLScriptMSSQL2MSSQL().Trim(",\t\r\n".ToCharArray()));
                                    //    //}
                                    //}
                                }
                            }
                        }
                    }

                    IEnumerable<Index> indexes = (from indx in this.Indexes where !indx.IsPrimaryKey && !indx.IsUniqueConstraint && indx.ToString().Split(',').Contains(column.Name) select indx);
                    foreach (Index indx in indexes)
                    {
                        if (!indexList.Contains(indx.Name) && !constraintList.Contains(indx.Name))
                        {
                            indexList.Add(indx.Name);
                            indexFirstSql = String.Format("{0}\r\n{1}", indexFirstSql, indx.SQLDropMSSQL2MSSQL());
                            indexLastSql = String.Format("{0}\r\n{1}", indexLastSql, indx.SQLCreateMSSQL2MSSQL());
                        }
                    }

                    flag2 = true;
                }
                if (flag2)
                {
                    flag = true;
                }
            }
            if (!flag)
            {
                str2 = string.Empty;
            }

            foreach (Constraint constraint in this.Constraints)
            {
                if (constraint.Type == ConstraintType.FOREIGN_KEY)
                {
                    if (constraint.Compared == ComparedEnum.New)
                    {
                        string str7 = this.SQLForeignKeysScript;
                        this.SQLForeignKeysScript = String.Format("{0} ALTER TABLE [{1}].[{2}] WITH NOCHECK ADD\r\n {3};\r\nGO\r\n", str7, this.Schema, base.Name, constraint.SQLScriptMSSQL2MSSQL().Trim(",\t\r\n".ToCharArray()));
                    }
                    else if (constraint.Compared == ComparedEnum.Modified)
                    {
                        string str8 = this.SQLForeignKeysScript;
                        this.SQLForeignKeysScript = String.Format("{0} ALTER TABLE [{1}].[{2}] WITH NOCHECK ADD\r\n {3};\r\nGO\r\n", str8, this.Schema, base.Name, constraint.SQLScriptMSSQL2MSSQL().Trim(",\t\r\n".ToCharArray()));
                        string str9 = str4;
                        str4 = String.Format("{0} ALTER TABLE [{1}].[{2}] DROP CONSTRAINT {3} ;\r\nGO\r\n", str9, this.Schema, base.Name, constraint.Name);
                    }
                    continue;
                }
                if (constraint.Compared == ComparedEnum.New && constraint.Check)
                {
                    string str10 = str2;
                    str2 = String.Format("{0} ALTER TABLE [{1}].[{2}] WITH NOCHECK ADD\r\n {3} ;\r\nGO\r\n", str10, this.Schema, base.Name, constraint.SQLScriptMSSQL2MSSQL().Trim(",\t\r\n".ToCharArray()));
                }
                else if (constraint.Compared == ComparedEnum.Modified)
                {
                    string str11 = str3;
                    str3 = String.Format("{0} ALTER TABLE [{1}].[{2}] DROP CONSTRAINT {3} ;\r\nGO\r\n", str11, this.Schema, base.Name, constraint.Name);
                    string str12 = str2;
                    str2 = String.Format("{0} ALTER TABLE [{1}].[{2}] WITH NOCHECK ADD\r\n {3} ;\r\nGO\r\n", str12, this.Schema, base.Name, constraint.SQLScriptMSSQL2MSSQL().Trim(",\t\r\n".ToCharArray()));
                }
            }
            //  this.SQLForeignKeysScript = String.Format("{0}\r\nALTER TABLE [{1}].[{2}] CHECK CONSTRAINT ALL\r\n", this.SQLForeignKeysScript, this.Schema, base.Name); // 27.10.2009
            //   str2 = String.Format("{0}\r\n GO\r\n", str2);
            this.Indexes.ForEach(index =>
            {
                if (((index.Compared == ComparedEnum.New) || (index.Compared == ComparedEnum.Modified)) || (index.Compared == ComparedEnum.Deleted))
                    str2 = String.Format("{0}\r\n{1}", str2, index.SQLScript(false));
            });
            this.SQLDropChangedConstraints = this.SQLDropChangedConstraints + str3;
            this.SQLDropChangedForeignKeyConstraints = this.SQLDropChangedForeignKeyConstraints + str4;
            //  return String.Format("{0} ALTER INDEX ALL ON [{1}].[{2}] REBUILD\r\nGO\r\n", str2, this.Schema, base.Name);
            return string.Format("{0}{1}{2}{3}{4}", constraintFirstSql, indexFirstSql, str2, indexLastSql, constraintLastSql);

            //   return str2;
        }

        public string SQLCreateMSSQL2MSSQL()
        {
            string str = String.Format(" CREATE TABLE [{0}].[{1}] (\r\n", this.Schema, base.Name);
            string str2 = string.Empty;
            this.Columns.ForEach(column => str = String.Format("{0}{1},\r\n \t", str, column.SQLScriptMSSQL2MSSQL()));
            str = String.Format("{0}\r\n", str.TrimEnd(",\r\n \t".ToCharArray()));
            if (this.Constraints.Count > 0) str = String.Format("{0},\r\n", str.TrimEnd("\r\n".ToCharArray()));
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            this.Constraints.ForEach(constraint =>
            {
                if ((constraint.Type == ConstraintType.FOREIGN_KEY) || (constraint.Type == ConstraintType.DEFAULT))
                    num2++;
            });
            num4 = num2;
            num3 = this.Constraints.Count - num2;

            for (int i = 0; i < this.Constraints.Count; i++)
            {
                switch (this.Constraints[i].Type)
                {
                    case ConstraintType.PRIMARY_KEY:
                    case ConstraintType.UNIQUE:
                    case ConstraintType.CHECK:
                        {
                            str = str + (this.Constraints[i]).SQLScriptMSSQL2MSSQL();
                            if (num3 > 1 && i < this.Constraints.Count - 1)
                            {
                                str += "\r\n \t, ";
                                num3--;
                            }
                            continue;
                        }
                    case ConstraintType.FOREIGN_KEY:
                    case ConstraintType.DEFAULT:
                        str2 = str2 + (this.Constraints[i]).SQLScriptMSSQL2MSSQL();
                        if (num4 > 1 && i < this.Constraints.Count - 1)
                        {
                            str2 += "\r\n \t, ";
                            num4--;
                        }
                        if (num != (num2 - 1))
                            break;
                        str2 = String.Format("{0};\r\nGO\r\n", str2);
                        num++;
                        break;

                    default:

                        continue;
                }
            }
            if (str2 != string.Empty)
            {
                string str3 = this.SQLForeignKeysScript;
                this.SQLForeignKeysScript = String.Format("{0}\r\nALTER TABLE [{1}].[{2}] ADD \r\n{3}", str3 + "\r\nGO\r\n", this.Schema, base.Name, str2);
            }
            str = String.Format("{0});\r\n\r\nGO\r\n", str);
            this.Indexes.ForEach(index =>
            {
                if (!this.Constraints.Exists(cnst => cnst.Name == index.Name))
                    str = String.Format("{0}\r\n{1}", str, index.SQLScript(false));
            });
            return str;
        }

        public string SQLDropColumnsMSSQL2MSSQL()
        {
            string str = string.Empty;
            this.Columns.ForEach(column =>
            {
                if (column.Compared == ComparedEnum.New)
                {
                    string str2 = str;
                    str = String.Format("{0} ALTER TABLE [{1}].[{2}] DROP COLUMN [{3}];\r\nGO\r\n", str2, this.Schema, base.Name, column.Name);
                }
            });
            return str;
        }

        public string SQLDropConstraintsMSSQL2MSSQL()
        {
            this.SQLForeignKeysScript = string.Empty;
            string str = string.Empty;
            foreach (Constraint constraint in this.Constraints)
            {
                if (constraint.Compared == ComparedEnum.Modified)
                {
                    bool flag = true;
                    foreach (ConstraintColumn column in constraint.Columns)
                    {
                        if (column.Compared == ComparedEnum.Modified)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (constraint.Type == ConstraintType.FOREIGN_KEY)
                    {
                        foreach (ConstraintColumn column2 in constraint.ReferencedColumns)
                        {
                            if (column2.Compared == ComparedEnum.Modified)
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                    if (flag)
                    {
                        if (constraint.Columns.Count > 0 && constraint.Columns[0].Compared == ComparedEnum.Equal)
                        {
                            if (constraint.Type == ConstraintType.FOREIGN_KEY)
                            {
                                string str2 = this.SQLForeignKeysScript;
                                this.SQLForeignKeysScript = String.Format("{0}\r\n ALTER TABLE [{1}].[{2}] DROP CONSTRAINT {3};\r\nGO\r\n", str2, this.Schema, base.Name, constraint.Name);
                                string str3 = str;
                                str = String.Format("{0} ALTER TABLE [{1}].[{2}] WITH NOCHECK ADD CONSTRAINT [{3}] FOREIGN KEY (", str3, this.Schema, base.Name, constraint.Name);
                                for (int i = 0; i < constraint.Columns.Count; i++)
                                {
                                    //if (constraint.Columns[i].Compared == ComparedEnum.Equal)
                                    //{
                                    object obj2 = str;
                                    str = String.Format("{0}[{1}]", obj2, constraint.Columns[i]);
                                    //}
                                    if (i != (constraint.Columns.Count - 1))
                                    {
                                        str = String.Format("{0},", str);
                                    }
                                }
                                str = str.TrimEnd(",".ToCharArray());
                                str = String.Format("{0}) ", str);
                                str = String.Format("{0} REFERENCES {1} (", str, constraint.ReferencedTableName);
                                for (int j = 0; j < constraint.ReferencedColumns.Count; j++)
                                {
                                    //if (constraint.ReferencedColumns[j].Compared == ComparedEnum.Equal)
                                    //{
                                    object obj3 = str;
                                    str = String.Format("{0}[{1}]", obj3, constraint.ReferencedColumns[j]);
                                    //}
                                    if (j != (constraint.ReferencedColumns.Count - 1))
                                    {
                                        str = String.Format("{0},", str);
                                    }
                                }
                                str = str.TrimEnd(",".ToCharArray());
                                str = String.Format("{0});\r\nGO\r\n", str);
                            }
                        }
                    }
                    else if (constraint.Compared == ComparedEnum.New)
                    {
                        if (constraint.Type == ConstraintType.FOREIGN_KEY)
                        {
                            string str4 = this.SQLForeignKeysScript;
                            this.SQLForeignKeysScript = String.Format("{0}\r\n ALTER TABLE [{1}].[{2}] DROP FOREIGN KEY [{3}];\r\nGO\r\n", str4, this.Schema, base.Name, constraint.Name);
                        }
                        else if (constraint.Type == ConstraintType.PRIMARY_KEY)
                        {
                            string str5 = this.SQLForeignKeysScript;
                            this.SQLForeignKeysScript = String.Format("{0}\r\n ALTER TABLE [{1}].[{2}] DROP PRIMARY KEY;\r\nGO\r\n", str5, this.Schema, base.Name);
                        }
                        else if (constraint.Type == ConstraintType.DEFAULT)
                        {
                            string str6 = this.SQLForeignKeysScript;
                            this.SQLForeignKeysScript = String.Format("{0}\r\n ALTER TABLE [{1}].[{2}] DROP CONSTRAINT [{3}];\r\nGO\r\n", str6, this.Schema, base.Name, constraint.Name);
                        }
                    }
                    continue;
                }
                if (constraint.Compared == ComparedEnum.New)
                {
                    string str7 = this.SQLForeignKeysScript;
                    this.SQLForeignKeysScript = String.Format("{0}\r\n ALTER TABLE [{1}].[{2}] DROP CONSTRAINT [{3}];\r\nGO\r\n", str7, this.Schema, base.Name, constraint.Name);
                }
            }
            if (str != string.Empty)
            {
                str = String.Format("{0}\r\nGO\r\n", str);
            }
            return str;
        }

        public string SQLDropMSSQL2MSSQL()
        {
            this.SQLForeignKeysScript = string.Empty;
            this.Constraints.ForEach(constraint =>
            {
                if (constraint.Type == ConstraintType.FOREIGN_KEY)
                    this.SQLForeignKeysScript = String.Format("{0}{1},", this.SQLForeignKeysScript, constraint.Name);
            });
            this.SQLForeignKeysScript = this.SQLForeignKeysScript.Trim(",".ToCharArray());
            if (this.SQLForeignKeysScript != string.Empty)
            {
                this.SQLForeignKeysScript = String.Format(" ALTER TABLE [{0}].[{1}] DROP CONSTRAINT {2};\r\nGO\r\n", this.Schema, base.Name, this.SQLForeignKeysScript.TrimEnd(",".ToCharArray()));
            }
            return (String.Format(" DROP TABLE  [{0}].[{1}];\r\n\r\nGO\r\n", this.Schema, base.Name));
        }

        public string SQLScript(bool bNotExistInMaster)
        {
            string str = string.Empty;
            this.SQLForeignKeysScript = string.Empty;
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
                    Schema = SQLDropChangedConstraints = SQLDropChangedForeignKeyConstraints = SQLForeignKeysScript = null;
                    Columns = null;
                    Constraints = null;
                    Indexes = null;
                    Dispose();
                }
                isDisposed = true;
            }
        }

        #endregion Methods
    }
}