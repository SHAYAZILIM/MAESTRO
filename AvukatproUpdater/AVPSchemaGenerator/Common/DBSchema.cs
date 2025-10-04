using AVPSchemaGenerator.Interfaces;
using AVPSchemaGenerator.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AVPSchemaGenerator.Common
{
    [Serializable]
    public abstract class DBSchema : IComparable, IConnectionInfo//, IDisposable
    {
        #region Fields

        public DBConnectionInfo dbConnectionInfo;

        protected bool _compareColumns;
        protected bool _compareConstraints;
        protected bool _compareFunctions;
        protected bool _compareParameters;
        protected bool _compareProcedures;
        protected bool _compareTables;

        private StringBuilder _sql;
        private bool isDisposed = false;

        #endregion Fields

        #region Constructors
        
        ~DBSchema()
        {
            //Dispose(false);
        }

        #endregion Constructors

        #region Delegates

        public delegate void ComparedDelegate(object sender, MessageEventArgs e);

        public delegate void ComparingDelegate(object sender, MessageEventArgs e);

        public delegate void ReadingDelegate(object sender, MessageEventArgs e);

        #endregion Delegates

        #region Events

        //    public DataTable ConstraintTable { get; private set; }
        //    private readonly string ConstraintsQuery = "SELECT tc.TABLE_NAME AS PKTABLE, tc.CONSTRAINT_NAME AS PK, rc1.CONSTRAINT_NAME as FK, tc2.TABLE_NAME as FKTABLE FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc LEFT JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc1 ON tc.CONSTRAINT_NAME =rc1.UNIQUE_CONSTRAINT_NAME LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc2 ON tc2.CONSTRAINT_NAME =rc1.CONSTRAINT_NAME WHERE TC.CONSTRAINT_TYPE ='PRIMARY KEY' and rc1.CONSTRAINT_NAME != ''";
        public event ComparedDelegate Compared;

        public event ComparingDelegate Comparing;

        public event ReadingDelegate Reading;

        #endregion Events

        #region Properties

        public bool CompareIndexes
        {
            get;
            set;
        }

        
        public bool CompareViews
        {
            get;
            set;
        }

        public DBConnectionInfo ConnectionInfo
        {
            get;
            set;
        }

        public DataSet DataSet
        {
            get;
            set;
        }

        public DataView DSColumns
        {
            get
            {
                DataView view = new DataView(DataSet.Tables[DBObjectType.COLUMNS.ToString()]);
                view.AllowEdit = true;
                return view;
            }
        }

        public DataView DSConstraints
        {
            get
            {
                DataView view = new DataView(DataSet.Tables[DBObjectType.CONSTRAINTS.ToString()]);
                view.AllowEdit = true;
                return view;
            }
        }

        public DataView DSFunctions
        {
            get
            {
                DataView view = new DataView(DataSet.Tables[DBObjectType.ROUTINES.ToString()]);
                view.RowFilter = "ROUTINE_TYPE = 'FUNCTION'";
                view.AllowEdit = true;
                return view;
            }
        }

        public DataView DSIndexes
        {
            get
            {
                DataView view = new DataView(DataSet.Tables[DBObjectType.INDEXES.ToString()]);
                view.AllowEdit = true;
                return view;
            }
        }

        public DataView DSParameters
        {
            get
            {
                DataView view = new DataView(DataSet.Tables[DBObjectType.PARAMETERS.ToString()]);
                view.AllowEdit = true;
                return view;
            }
        }

        public DataView DSStoredProcedures
        {
            get
            {
                DataView view = new DataView(DataSet.Tables[DBObjectType.ROUTINES.ToString()]);
                view.RowFilter = "ROUTINE_TYPE = 'PROCEDURE'";
                view.AllowEdit = true;
                return view;
            }
        }

        public DataView DSTables
        {
            get
            {
                DataView view = new DataView(DataSet.Tables[DBObjectType.TABLES.ToString()]);
                view.RowFilter = "TABLE_TYPE = 'BASE TABLE'";
                view.AllowEdit = true;
                return view;
            }
        }

        public DataView DSViews
        {
            get { return DataSet.Tables[DBObjectType.VIEWS.ToString()].DefaultView; }
        }

        public List<Function> Functions
        {
            get;
            private set;
        }

        public bool Initialized
        {
            get;
            set;
        }

        public string SQL
        {
            get
            {
                GetSQLDiffScript();
                if (_sql != null)
                {
                    return _sql.ToString();
                }
                return string.Empty;
            }
        }

        public string SQLDiff
        {
            get
            {
                if (_sql != null)
                {
                    return _sql.ToString();
                }
                return string.Empty;
            }
        }

        public List<StoredProcedure> StoredProcedures
        {
            get;
            private set;
        }

        public List<string> SyncCmd
        {
            get;
            private set;
        }

        public List<Table> Tables
        {
            get;
            private set;
        }

        public List<View> Views
        {
            get;
            private set;
        }

        #endregion Properties

        #region Methods

        public int CompareTo(object obj)
        {
            if (!Initialized)
            {
                return -1;
            }
            DBSchema schema = obj as DBSchema;
            if (schema == null)
            {
                return -1;
            }
            if (!schema.Initialized)
            {
                return -1;
            }
            _sql = new StringBuilder();

            if (CompareViews) // Target veritabanındaki View'lar rebuild ediliyor.
            {
                //foreach (DataRow dr in schema.DataSet.Tables[DBObjectType.VIEWS.ToString()].Rows)
                //{
                //    try
                //    {
                //        string definition = Regex.Replace(dr["VIEW_DEFINITION"].ToString(), @"CREATE\s+VIEW", "ALTER VIEW", RegexOptions.IgnoreCase);
                //        ExecuteSQL(definition, schema.ConnectionInfo);
                //        if (Comparing != null)
                //        {
                //            Comparing(null, new MessageEventArgs(String.Format("View'lar rebuild ediliyor... View Adı: {0}\n\n", dr["TABLE_NAME"].ToString()), true));
                //        }
                //    }
                //    catch (SqlException ex)
                //    {
                //        if (Comparing != null)
                //        {
                //            Comparing(null, new MessageEventArgs(String.Format("View'lar rebuild edilirken hata olştu.\nView Adı: {0}\nHata: {1}\n\n", dr["TABLE_NAME"].ToString(), ex.Message), true));
                //        }
                //    }
                //}

                foreach (View view in schema.Views)
                {
                    try
                    {
                        string definition = String.Format("ALTER VIEW {0}\r\nAS {1}", view.Name, view.BodyDefinition);
                        ExecuteSQL(definition, schema.ConnectionInfo);
                        if (Comparing != null)
                        {
                            Comparing(null, new MessageEventArgs(String.Format("View'lar rebuild ediliyor... View Adı: {0}\n\n", view.Name), true));
                        }
                    }
                    catch (SqlException ex)
                    {
                        if (Comparing != null)
                        {
                            Comparing(null, new MessageEventArgs(String.Format("View'lar rebuild edilirken hata olştu.\nView Adı: {0}\nHata: {1}\n\n", view.Name, ex.Message), true));
                        }
                    }
                }
            }
            for (int i = 0; i < DataSet.Tables.Count; i++)
            {
                string tableName = DataSet.Tables[i].TableName;
                if (Comparing != null)
                {
                    Comparing(this, new MessageEventArgs(String.Format("Karşılaştırılıyor {0}...", tableName.ToLower())));
                }
                if ((((_compareTables && (tableName == DBObjectType.TABLES.ToString())) || (_compareConstraints && (tableName == DBObjectType.CONSTRAINTS.ToString()))) || ((_compareConstraints && (tableName == DBObjectType.CONSTRAINT_COLUMNS.ToString())) || (CompareViews && (tableName == DBObjectType.VIEWS.ToString())))) || ((((_compareColumns && (tableName == DBObjectType.COLUMNS.ToString())) || (_compareProcedures && (tableName == DBObjectType.ROUTINES.ToString()))) || ((_compareFunctions && (tableName == DBObjectType.FUNCTIONS.ToString())) || (CompareIndexes && (tableName == DBObjectType.INDEXES.ToString())))) || ((CompareIndexes && (tableName == DBObjectType.INDEX_COLUMNS.ToString())) || (_compareParameters && (tableName == DBObjectType.PARAMETERS.ToString())))))
                {
                    int length = DataSet.Tables[i].PrimaryKey.Length;
                    DataColumn[] primaryKey = DataSet.Tables[i].PrimaryKey;
                    object[] keys = new object[length];
                    for (int k = 0; k < DataSet.Tables[i].Rows.Count; k++)
                    {
                        DataRow drSource = DataSet.Tables[i].Rows[k];
                        for (int m = 0; m < length; m++)
                        {
                            keys[m] = drSource[primaryKey[m].ColumnName];
                        }
                        if (schema.DataSet.Tables[tableName] != null)
                        {
                            DataRow drTarget = schema.DataSet.Tables[tableName].Rows.Find(keys);
                            if (drTarget != null)
                            {
                                if ((drSource["COMPARED"].ToString() == ComparedEnum.DoNotCompare.ToString("D")) || (drTarget["COMPARED"].ToString() == ComparedEnum.DoNotCompare.ToString("D")))
                                {
                                    drSource["COMPARED"] = drTarget["COMPARED"] = ComparedEnum.DoNotCompare.ToString("D");
                                }
                                else
                                {
                                    CompareRows(ref drSource, ref drTarget);
                                }
                            }
                            else if (drSource["COMPARED"].ToString() == ComparedEnum.DoNotCompare.ToString("D"))
                            {
                                drSource["COMPARED"] = ComparedEnum.DoNotCompare.ToString("D");
                            }
                            else
                            {
                                drSource["COMPARED"] = ComparedEnum.New.ToString("D");
                                schema.UpdateDeletedRows(drSource);
                            }
                        }
                        else if (drSource["COMPARED"].ToString() == ComparedEnum.DoNotCompare.ToString("D"))
                        {
                            drSource["COMPARED"] = ComparedEnum.DoNotCompare.ToString("D");
                        }
                        else
                        {
                            drSource["COMPARED"] = ComparedEnum.New.ToString("D");
                            schema.UpdateDeletedRows(drSource);
                        }
                    }
                }
            }
            if (Comparing != null)
            {
                Comparing(this, new MessageEventArgs("Tanımlamalar güncelleniyor..."));
            }
            for (int j = 0; j < schema.DataSet.Tables.Count; j++)
            {
                string str2 = schema.DataSet.Tables[j].TableName;
                if ((((_compareTables && (str2 == DBObjectType.TABLES.ToString())) || (_compareConstraints && (str2 == DBObjectType.CONSTRAINTS.ToString()))) || ((_compareConstraints && (str2 == DBObjectType.CONSTRAINT_COLUMNS.ToString())) || (CompareViews && (str2 == DBObjectType.VIEWS.ToString())))) || ((((_compareColumns && (str2 == DBObjectType.COLUMNS.ToString())) || (_compareProcedures && (str2 == DBObjectType.ROUTINES.ToString()))) || ((_compareFunctions && (str2 == DBObjectType.FUNCTIONS.ToString())) || (CompareIndexes && (str2 == DBObjectType.INDEXES.ToString())))) || ((CompareIndexes && (str2 == DBObjectType.INDEX_COLUMNS.ToString())) || (_compareParameters && (str2 == DBObjectType.PARAMETERS.ToString())))))
                {
                    for (int n = 0; n < schema.DataSet.Tables[j].Rows.Count; n++)
                    {
                        try
                        {
                            if (((ComparedEnum)Enum.Parse(typeof(ComparedEnum), schema.DataSet.Tables[j].Rows[n]["COMPARED"].ToString())) == ComparedEnum.NotCompared)
                            {
                                schema.DataSet.Tables[j].Rows[n]["COMPARED"] = ComparedEnum.New.ToString("D");
                                if (((schema.DataSet.Tables[j].TableName == DBObjectType.COLUMNS.ToString()) || (schema.DataSet.Tables[j].TableName == DBObjectType.CONSTRAINTS.ToString())) || (schema.DataSet.Tables[j].TableName == DBObjectType.CONSTRAINT_COLUMNS.ToString()))
                                {
                                    UpdateDeletedRows(schema.DataSet.Tables[j].Rows[n]);
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
            CreateCollection();
            schema.CreateCollection();
            if (Comparing != null)
            {
                Comparing(this, new MessageEventArgs("Scriptler oluşturuluyor..."));
            }

            DependencyLookup lookup = new DependencyLookup(this);
            lookup.GetViewDependencyList();
            List<View> tmpList = new List<View>();
            lookup.DependencyList.ForEach(name =>
            {
                tmpList.Add(Views.Find(view => view.Name == name));
            });
            Views = tmpList;

            GetSQLDiffScript(schema);
            schema.GetSQLDiffScript(this);
            AddSQLDiffScriptHeaderAndFooter();
            schema.AddSQLDiffScriptHeaderAndFooter();
            if (Compared != null)
            {
                Compared(this, new MessageEventArgs("Karşılaştırma işlemi başarıyla tamamlandı."));
            }
            return 0;
        }

        public void Dispose()
        {
            if (!isDisposed)
                Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void AddSQLDiffScriptHeaderAndFooter()
        {
            //   _sql.Insert(0, "EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'\nGO\n\n");
            //   _sql.Insert(0, "EXEC sp_MSForEachTable 'ALTER INDEX ALL ON ? DISABLE'\nGO\n\n");
            _sql.Insert(0, "BEGIN TRANSACTION\nGO\n\n");
            _sql.Insert(0, "SET XACT_ABORT ON\n\n");
            //     _sql.Append("EXEC sp_MSForEachTable 'ALTER INDEX ALL ON ? REBUILD'\nGO\n");
            //     _sql.Append("EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'\nGO\n");
            _sql.Append("\nCOMMIT\n");
        }

        protected void CompareRows(ref DataRow drSource, ref DataRow drTarget)
        {
            bool flag = false;
            for (int i = 0; i < drSource.Table.Columns.Count; i++)
            {
                if (drSource.Table.TableName == DBObjectType.VIEWS.ToString())
                {
                    ////Bazı View'larda scriptler aynı olmasına rağmen column yapılarında değişiklik olduğu için tüm viewlar rebuild ediliyor.
                    //drSource["COMPARED"] = drTarget["COMPARED"] = ComparedEnum.Modified.ToString("D");
                    //flag = true;

                    if (i == 2)// VIEW_DEFINITION
                    {
                        if (drSource[i].ToString().Split(new string[] { "\r\nAS\r\n", " AS\r\n", "\r\nAS ", " AS " }, 2, StringSplitOptions.None)[1].Trim().ToLower().GetHashCode() != drTarget[drSource.Table.Columns[i].ColumnName].ToString().Split(new string[] { "\r\nAS\r\n", " AS\r\n", "\r\nAS ", " AS " }, 2, StringSplitOptions.None)[1].Trim().ToLower().GetHashCode())
                        {
                            drSource["COMPARED"] = drTarget["COMPARED"] = ComparedEnum.Modified.ToString("D");
                            flag = true;
                            break;
                        }
                    }
                    else if (drSource[i].ToString().Trim().ToLower().GetHashCode() != drTarget[drSource.Table.Columns[i].ColumnName].ToString().Trim().ToLower().GetHashCode())
                    {
                        drSource["COMPARED"] = drTarget["COMPARED"] = ComparedEnum.Modified.ToString("D");
                        flag = true;
                        break;
                    }
                }
                else if (drSource.Table.TableName == DBObjectType.ROUTINES.ToString())
                {
                    if (i == 9) // ROUTINE_DEFINITION
                    {
                        // string str = Regex.Replace(drSource[i].ToString(), @"(/\*.*?.*?\*/)", "\r\n");
                        if (Regex.Replace(drSource[i].ToString(), @"//.*\n|/\*(.|\n)*?\*/", "\r\n").Trim().ToLower().GetHashCode() != Regex.Replace(drTarget[drSource.Table.Columns[i].ColumnName].ToString(), @"//.*\n|/\*(.|\n)*?\*/", "\r\n").Trim().ToLower().GetHashCode())
                        {
                            drSource["COMPARED"] = drTarget["COMPARED"] = ComparedEnum.Modified.ToString("D");
                            flag = true;
                            break;
                        }
                    }
                    else if (drSource[i].ToString().Trim().ToLower().GetHashCode() != drTarget[drSource.Table.Columns[i].ColumnName].ToString().Trim().ToLower().GetHashCode())
                    {
                        drSource["COMPARED"] = drTarget["COMPARED"] = ComparedEnum.Modified.ToString("D");
                        flag = true;
                        break;
                    }
                }
                else if (drSource[i].ToString().Trim().ToLower().GetHashCode() != drTarget[drSource.Table.Columns[i].ColumnName].ToString().Trim().ToLower().GetHashCode())
                {
                    drSource["COMPARED"] = drTarget["COMPARED"] = ComparedEnum.Modified.ToString("D");
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                drSource["COMPARED"] = drTarget["COMPARED"] = ComparedEnum.Equal.ToString("D");
                drSource.EndEdit();
            }
        }

        protected ComparedEnum ConvertToComparedEnum(string sValue)
        {
            return (ComparedEnum)Enum.Parse(typeof(ComparedEnum), sValue, true);
        }

        protected void CreateCollection()
        {
            Tables = new List<Table>();
            StoredProcedures = new List<StoredProcedure>();
            Functions = new List<Function>();
            Views = new List<View>();
            string schema = "";
            if (_compareTables)
            {
                foreach (DataRowView view in DSTables)
                {
                    Table item = new Table(view["TABLE_NAME"].ToString(), ConvertToComparedEnum(view["COMPARED"].ToString())) { Schema = view["TABLE_SCHEMA"].ToString() };
                    DataRow[] childRows = view.Row.GetChildRows("FKTablesXColumns");
                    view.Row.GetChildRows("FKTablesXConstraints");
                    if (item.Compared != ComparedEnum.DoNotCompare)
                    {
                        foreach (DataRow row in childRows)
                        {
                            ComparedEnum compared = ConvertToComparedEnum(row["COMPARED"].ToString());
                            if (item.Compared != ComparedEnum.Deleted)
                            {
                                Column column = new Column(row["COLUMN_NAME"].ToString(), compared);
                                switch (compared)
                                {
                                    case ComparedEnum.New:
                                    case ComparedEnum.Modified:
                                        item.Compared = (item.Compared == ComparedEnum.New) ? item.Compared : ComparedEnum.Modified;
                                        break;

                                    default:
                                        if (compared == ComparedEnum.Deleted)
                                        {
                                            item.Compared = (item.Compared == ComparedEnum.Deleted) ? ComparedEnum.Deleted : ComparedEnum.Modified;
                                        }
                                        break;
                                }
                                if (row["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value)
                                {
                                    column.CharacterMaximumLength = row["CHARACTER_MAXIMUM_LENGTH"].ToString();
                                }
                                if (row["COLLATION_CATALOG"] != DBNull.Value)
                                {
                                    column.CollationCatalog = row["COLLATION_CATALOG"].ToString();
                                }
                                if (row["COLLATION_NAME"] != DBNull.Value)
                                {
                                    column.CollationName = row["COLLATION_NAME"].ToString();
                                }
                                if (row["COLLATION_SCHEMA"] != DBNull.Value)
                                {
                                    column.CollationSchema = row["COLLATION_SCHEMA"].ToString();
                                }
                                if (row["COLUMN_DEFAULT"] != DBNull.Value)
                                {
                                    column.ColumnDefault = row["COLUMN_DEFAULT"].ToString();
                                }
                                column.DataType = row["DATA_TYPE"].ToString();
                                if (row["DATETIME_PRECISION"] != DBNull.Value)
                                {
                                    column.DateTimePrecision = row["DATETIME_PRECISION"].ToString();
                                }
                                if (row["IS_NULLABLE"] != DBNull.Value)
                                {
                                    column.IsNullable = row["IS_NULLABLE"].ToString();
                                }
                                if (row["NUMERIC_PRECISION"] != DBNull.Value)
                                {
                                    column.NumericPrecision = row["NUMERIC_PRECISION"].ToString();
                                }
                                if (row["NUMERIC_SCALE"] != DBNull.Value)
                                {
                                    column.NumericScale = row["NUMERIC_SCALE"].ToString();
                                }
                                if (row["COLUMN_TYPE"] != DBNull.Value)
                                {
                                    column.ColumnType = row["COLUMN_TYPE"].ToString();
                                }
                                if (row["EXTRA"] != DBNull.Value)
                                {
                                    column.Extra = row["EXTRA"].ToString();
                                }
                                if (row["USER_DATA_TYPE"] != DBNull.Value)
                                {
                                    column.UserDefinedTypeName = row["USER_DATA_TYPE"].ToString();
                                }
                                if (row["USER_DATA_TYPE_SCHEMA"] != DBNull.Value)
                                {
                                    column.UserDefinedTypeNameSchema = row["USER_DATA_TYPE_SCHEMA"].ToString();
                                }
                                if (row["IS_ROWGUIDCOL"] != DBNull.Value)
                                {
                                    int num;
                                    if (int.TryParse(row["IS_ROWGUIDCOL"].ToString(), out num))
                                    {
                                        column.IsRowguidcol = Convert.ToBoolean(num);
                                    }
                                    else
                                    {
                                        column.IsRowguidcol = Convert.ToBoolean(row["IS_ROWGUIDCOL"].ToString());
                                    }
                                }
                                if (row["IS_COMPUTED"] != DBNull.Value)
                                {
                                    int num2;
                                    if (int.TryParse(row["IS_COMPUTED"].ToString(), out num2))
                                    {
                                        column.IsComputed = Convert.ToBoolean(num2);
                                    }
                                    else
                                    {
                                        column.IsComputed = Convert.ToBoolean(row["IS_COMPUTED"].ToString());
                                    }
                                }
                                if (row["IS_IDENTITY"] != DBNull.Value)
                                {
                                    int num3;
                                    if (int.TryParse(row["IS_IDENTITY"].ToString(), out num3))
                                    {
                                        column.IsIdentity = Convert.ToBoolean(num3);
                                    }
                                    else
                                    {
                                        column.IsIdentity = Convert.ToBoolean(row["IS_IDENTITY"].ToString());
                                    }
                                }
                                if (row["IS_NOT_FOR_REPLICATION"] != DBNull.Value)
                                {
                                    int num4;
                                    if (int.TryParse(row["IS_NOT_FOR_REPLICATION"].ToString(), out num4))
                                    {
                                        column.IsNotForReplication = Convert.ToBoolean(num4);
                                    }
                                    else
                                    {
                                        column.IsNotForReplication = Convert.ToBoolean(row["IS_NOT_FOR_REPLICATION"].ToString());
                                    }
                                }
                                if (row["SEED_VALUE"] != DBNull.Value)
                                {
                                    column.SeedValue = row["SEED_VALUE"].ToString();
                                }
                                if (row["INCREMENT_VALUE"] != DBNull.Value)
                                {
                                    column.IncrementValue = row["INCREMENT_VALUE"].ToString();
                                }
                                item.Columns.Add(column);
                            }
                        }
                    }
                    DataView view2 = new DataView(DSConstraints.Table, String.Format("TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{1}'", item.Schema, item.Name), "", DataViewRowState.CurrentRows);
                    if (item.Compared != ComparedEnum.DoNotCompare)
                    {
                        foreach (DataRowView view3 in view2)
                        {
                            DataRow[] rowArray2 = view3.Row.GetChildRows("FKConstraintsXConstraintColumns");
                            ComparedEnum enum3 = ConvertToComparedEnum(view3["COMPARED"].ToString());
                            AVPSchemaGenerator.Types.Constraint constraint = new AVPSchemaGenerator.Types.Constraint(view3["CONSTRAINT_NAME"].ToString(), ConvertToComparedEnum(view3["COMPARED"].ToString()));
                            switch (enum3)
                            {
                                case ComparedEnum.New:
                                case ComparedEnum.Modified:
                                    if (item.Compared != ComparedEnum.Deleted)
                                    {
                                        item.Compared = (item.Compared == ComparedEnum.New) ? item.Compared : ComparedEnum.Modified;
                                    }
                                    constraint.Compared = (constraint.Compared == ComparedEnum.New) ? constraint.Compared : ComparedEnum.Modified;
                                    break;

                                case ComparedEnum.Deleted:
                                    {
                                        item.Compared = (item.Compared == ComparedEnum.Deleted) ? ComparedEnum.Deleted : ComparedEnum.Modified;
                                        continue;
                                    }
                                case ComparedEnum.DoNotCompare:
                                    {
                                        continue;
                                    }
                            }
                            constraint.SetType(view3["CONSTRAINT_TYPE"].ToString());
                            constraint.IndexType = view3["INDEX_TYPE"] == DBNull.Value ? "" : view3["INDEX_TYPE"].ToString();

                            foreach (DataRow row2 in rowArray2)
                            {
                                ComparedEnum enum4 = ConvertToComparedEnum(row2["COMPARED"].ToString());
                                ConstraintColumn column2 = new ConstraintColumn(row2["COLUMN_NAME"].ToString(), enum4);
                                switch (enum4)
                                {
                                    case ComparedEnum.New:
                                    case ComparedEnum.Modified:
                                        if (item.Compared != ComparedEnum.Deleted)
                                        {
                                            item.Compared = (item.Compared == ComparedEnum.New) ? item.Compared : ComparedEnum.Modified;
                                        }
                                        if (constraint.Compared != ComparedEnum.Deleted)
                                        {
                                            constraint.Compared = (constraint.Compared == ComparedEnum.New) ? constraint.Compared : ComparedEnum.Modified;
                                        }
                                        break;

                                    case ComparedEnum.Deleted:
                                        if (item.Compared != ComparedEnum.Deleted)
                                        {
                                            item.Compared = ComparedEnum.Modified;
                                        }
                                        if (constraint.Compared != ComparedEnum.Deleted)
                                        {
                                            constraint.Compared = ComparedEnum.Modified;
                                        }
                                        goto next;
                                }
                                if (row2["CHECK_CLAUSE"] != DBNull.Value)
                                {
                                    column2.CheckClause = row2["CHECK_CLAUSE"].ToString();
                                }
                                if (row2["ORDINAL_POSITION"] != DBNull.Value)
                                {
                                    column2.OrdinalPosition = Convert.ToInt32(row2["ORDINAL_POSITION"]);
                                }
                                if (row2["COLUMN_TYPE"] != DBNull.Value)
                                {
                                    column2.ColumnType = row2["COLUMN_TYPE"].ToString();
                                }
                                if (constraint.Type == ConstraintType.FOREIGN_KEY)
                                {
                                    schema = row2["PK_SCHEMA"] == DBNull.Value ? "dbo" : row2["PK_SCHEMA"].ToString();
                                    constraint.ReferencedTableName = String.Format("[{0}].[{1}]", schema, row2["PK_TABLE"]);
                                    ConstraintColumn column3 = new ConstraintColumn(row2["PK_COLUMN"].ToString(), ConvertToComparedEnum(row2["COMPARED"].ToString()));
                                    constraint.ReferencedColumns.Add(column3);
                                }
                                constraint.Columns.Add(column2);
                            next: ;
                            }
                            item.Constraints.Add(constraint);
                        }
                    }
                    if (CompareIndexes)
                    {
                        using (DataView view4 = new DataView(DSIndexes.Table, String.Format("TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{1}'", item.Schema, item.Name), "", DataViewRowState.CurrentRows))
                        {
                            if (item.Compared != ComparedEnum.DoNotCompare)
                                foreach (DataRowView view5 in view4)
                                {
                                    DataRow[] rowArray3 = view5.Row.GetChildRows("FKIndexesXIndexColumns");
                                    ComparedEnum enum5 = ConvertToComparedEnum(view5["COMPARED"].ToString());
                                    Index index = new Index(view5["INDEX_NAME"].ToString(), ConvertToComparedEnum(view5["COMPARED"].ToString()));
                                    index.IndexType = view5["INDEX_TYPE"].ToString();
                                    index.IsPrimaryKey = view5["IS_PRIMARY_KEY"].ToString().ToUpper() == "TRUE";
                                    index.IsUniqueConstraint = view5["IS_UNIQUE_CONSTRAINT"].ToString().ToUpper() == "TRUE";
                                    index.IsUnique = view5["IS_UNIQUE"].ToString().ToUpper() == "TRUE";
                                    switch (enum5)
                                    {
                                        case ComparedEnum.New:
                                        case ComparedEnum.Modified:
                                            if (item.Compared != ComparedEnum.Deleted)
                                                item.Compared = (item.Compared == ComparedEnum.New) ? item.Compared : ComparedEnum.Modified;
                                            index.Compared = (index.Compared == ComparedEnum.New) ? index.Compared : ComparedEnum.Modified;
                                            break;

                                        case ComparedEnum.Deleted:
                                            {
                                                item.Compared = (item.Compared == ComparedEnum.Deleted) ? ComparedEnum.Deleted : ComparedEnum.Modified;
                                                continue;
                                            }
                                        case ComparedEnum.DoNotCompare:

                                            continue;
                                    }
                                    index.TableName = item.Name;
                                    index.TableSchema = item.Schema;
                                    foreach (DataRow row3 in rowArray3)
                                    {
                                        ComparedEnum enum6 = ConvertToComparedEnum(row3["COMPARED"].ToString());
                                        IndexKey key = new IndexKey(row3["COLUMN_NAME"].ToString(), enum6);
                                        switch (enum6)
                                        {
                                            case ComparedEnum.New:
                                            case ComparedEnum.Modified:
                                                if (item.Compared != ComparedEnum.Deleted)
                                                    item.Compared = (item.Compared == ComparedEnum.New) ? item.Compared : ComparedEnum.Modified;
                                                if (index.Compared != ComparedEnum.Deleted)
                                                    index.Compared = (index.Compared == ComparedEnum.New) ? index.Compared : ComparedEnum.Modified;
                                                break;

                                            case ComparedEnum.Deleted:
                                                if (item.Compared != ComparedEnum.Deleted)
                                                    item.Compared = ComparedEnum.Modified;
                                                if (index.Compared != ComparedEnum.Deleted)
                                                    index.Compared = ComparedEnum.Modified;
                                                goto next;
                                        }
                                        index.IndexKeys.Add(key);
                                    next:
                                        ; ;
                                    }
                                    item.Indexes.Add(index);
                                }
                        }
                    }
                    item.DbSchema = this;
                    Tables.Add(item);
                }
            }
            if (CompareViews)
            {
                foreach (DataRowView view6 in DSViews)
                {
                    View view7 = new View(view6["TABLE_NAME"].ToString(), ConvertToComparedEnum(view6["COMPARED"].ToString()));
                    view7.Schema = view6["TABLE_SCHEMA"].ToString();
                    view7.Definition = view6["VIEW_DEFINITION"].ToString();
                    view7.IsUpdatable = view6["IS_UPDATABLE"].ToString();
                    view7.CheckOption = view6["CHECK_OPTION"].ToString();
                    Views.Add(view7);
                }
            }
            if (_compareProcedures)
            {
                foreach (DataRowView view8 in DSStoredProcedures)
                {
                    StoredProcedure procedure = new StoredProcedure(view8["ROUTINE_NAME"].ToString(), ConvertToComparedEnum(view8["COMPARED"].ToString()));
                    procedure.Schema = view8["ROUTINE_SCHEMA"].ToString();
                    procedure.Definition = view8["ROUTINE_DEFINITION"].ToString();
                    if (view8["PARAM_LIST"] != DBNull.Value)
                    {
                        procedure.ParamList = view8["PARAM_LIST"].ToString();
                    }
                    Array.ForEach(view8.Row.GetChildRows("FKRoutinesXParameters"), row4 =>
                    {
                        Parameter parameter = new Parameter(row4["PARAMETER_NAME"].ToString(), ConvertToComparedEnum(row4["COMPARED"].ToString()));
                        if (row4["AS_LOCATOR"] != DBNull.Value)
                            parameter.AsLocator = row4["AS_LOCATOR"].ToString();
                        if (row4["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value)
                            parameter.CharacterMaximumLength = row4["CHARACTER_MAXIMUM_LENGTH"].ToString();
                        if (row4["DATA_TYPE"] != DBNull.Value)
                            parameter.DataType = row4["DATA_TYPE"].ToString();
                        if (row4["DATETIME_PRECISION"] != DBNull.Value)
                            parameter.DateTimePrecision = row4["DATETIME_PRECISION"].ToString();
                        if (row4["IS_RESULT"] != DBNull.Value)
                            parameter.IsResult = row4["IS_RESULT"].ToString();
                        if (row4["NUMERIC_PRECISION"] != DBNull.Value)
                            parameter.NumericPrecision = row4["NUMERIC_PRECISION"].ToString();
                        if (row4["NUMERIC_SCALE"] != DBNull.Value)
                            parameter.NumericScale = row4["NUMERIC_SCALE"].ToString();
                        if (row4["PARAMETER_MODE"] != DBNull.Value)
                            parameter.ParameterMode = row4["PARAMETER_MODE"].ToString();
                        if (row4["USER_DEFINED_TYPE_NAME"] != DBNull.Value)
                            parameter.UserDefinedTypeName = row4["USER_DEFINED_TYPE_NAME"].ToString();
                        procedure.Parameters.Add(parameter);
                    });
                    StoredProcedures.Add(procedure);
                }
                foreach (DataRowView view9 in DSFunctions)
                {
                    Function function = new Function(view9["ROUTINE_NAME"].ToString(), ConvertToComparedEnum(view9["COMPARED"].ToString()));
                    function.Schema = view9["ROUTINE_SCHEMA"].ToString();
                    function.Definition = view9["ROUTINE_DEFINITION"].ToString();
                    if (view9["PARAM_LIST"] != DBNull.Value)
                    {
                        function.ParamList = view9["PARAM_LIST"].ToString();
                    }
                    if (view9["DATA_TYPE"] != DBNull.Value)
                    {
                        function.DataType = view9["DATA_TYPE"].ToString();
                    }
                    Array.ForEach(view9.Row.GetChildRows("FKRoutinesXParameters"), row5 =>
                    {
                        Parameter parameter2 = new Parameter(row5["PARAMETER_NAME"].ToString(), ConvertToComparedEnum(row5["COMPARED"].ToString()));
                        parameter2.AsLocator = row5["AS_LOCATOR"].ToString();
                        parameter2.CharacterMaximumLength = row5["CHARACTER_MAXIMUM_LENGTH"].ToString();
                        parameter2.DataType = row5["DATA_TYPE"].ToString();
                        parameter2.DateTimePrecision = row5["DATETIME_PRECISION"].ToString();
                        parameter2.IsResult = row5["IS_RESULT"].ToString();
                        parameter2.NumericPrecision = row5["NUMERIC_PRECISION"].ToString();
                        parameter2.NumericScale = row5["NUMERIC_SCALE"].ToString();
                        parameter2.ParameterMode = row5["PARAMETER_MODE"].ToString();
                        parameter2.UserDefinedTypeName = row5["USER_DEFINED_TYPE_NAME"].ToString();
                        function.Parameters.Add(parameter2);
                    });
                    Functions.Add(function);
                }
            }
        }

        protected void GetSQLDiffScript()
        {
            if (_sql == null)
            {
                _sql = new StringBuilder();
            }
            StringBuilder builder = new StringBuilder();
            List<string> collection = new List<string>();
            StringBuilder builder2 = new StringBuilder();
            List<string> list2 = new List<string>();
            StringBuilder builder3 = new StringBuilder();
            List<string> list3 = new List<string>();
            if (SyncCmd == null)
            {
                SyncCmd = new List<string>();
            }
            string str = string.Empty;
            Tables.ForEach(table =>
            {
                str = table.SQLScript(false);
                if (table.SQLForeignKeysScript != string.Empty)
                {
                    builder.Append(table.SQLForeignKeysScript);
                    collection.Add(table.SQLForeignKeysScript);
                }
                if (table.SQLDropChangedConstraints != string.Empty)
                {
                    builder2.Append(table.SQLDropChangedConstraints);
                    list2.Add(table.SQLDropChangedConstraints);
                }
                if (table.SQLDropChangedForeignKeyConstraints != string.Empty)
                {
                    builder3.Append(table.SQLDropChangedForeignKeyConstraints);
                    list3.Add(table.SQLDropChangedForeignKeyConstraints);
                }
                if (str != string.Empty)
                {
                    _sql.Append(str);
                    SyncCmd.Add(str);
                }
            });
            _sql.Append("\n");
            Functions.ForEach(function =>
            {
                str = function.SQLScript(false);
                if ((str != null) && (str != string.Empty))
                {
                    SyncCmd.Add(str);
                    string str4 = str;
                    str4 = String.Format("\n{0}", str4);
                    str4 = String.Format("{0}\nGO", str4);
                    _sql.Append(str4);
                }
            });
            _sql.Append("\n");
            Views.ForEach(view =>
            {
                str = view.SQLScript(false);
                if ((str != null) && (str != string.Empty))
                {
                    SyncCmd.Add(str);
                    string str2 = str;
                    //        str2 = str2.Replace(Environment.NewLine, @"\par ");
                    str2 = String.Format("\n{0}", str2);
                    str2 = String.Format("{0}\nGO", str2);
                    _sql.Append(str2);
                }
            });
            _sql.Append("\n");
            StoredProcedures.ForEach(procedure =>
            {
                str = procedure.SQLScript(false);
                if ((str != null) && (str != string.Empty))
                {
                    SyncCmd.Add(str);
                    string str3 = str;
                    //            str3 = str3.Replace(Environment.NewLine, @"\par ");
                    str3 = String.Format("\n{0}", str3);
                    str3 = String.Format("{0}\nGO", str3);
                    _sql.Append(str3);
                }
            });
            _sql.Append("\n");
            SyncCmd.InsertRange(0, list2);
            _sql.Insert(0, builder2);
            SyncCmd.InsertRange(0, list3);
            _sql.Insert(0, builder3);
            SyncCmd.AddRange(collection);
            _sql.Append(builder);
            _sql.Append("\r\nEXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'\r\n"); // Enables constraints
        }

        protected void GetSQLDiffScript(DBSchema dbCompared2)
        {
            string str = string.Empty;
            StringBuilder builder = new StringBuilder();
            if (_sql == null)
            {
                _sql = new StringBuilder();
            }
            if (SyncCmd == null)
            {
                SyncCmd = new List<string>();
            }
            foreach (Table table in dbCompared2.Tables)
            {
                if (table.Compared == ComparedEnum.New)
                {
                    str = table.SQLScript(true);
                    if (table.SQLForeignKeysScript != string.Empty)
                    {
                        builder.Append(table.SQLForeignKeysScript);
                        SyncCmd.Insert(0, table.SQLForeignKeysScript);
                    }
                    if (str != string.Empty)
                    {
                        _sql.Append(str);
                        SyncCmd.Add(str);
                    }
                    continue;
                }
                if (table.Compared == ComparedEnum.Modified)
                {
                    str = table.SQLDropConstraintsMSSQL2MSSQL() + table.SQLDropColumnsMSSQL2MSSQL();
                    table.Indexes.ForEach(index =>
                    {
                        if (index.Compared == ComparedEnum.New)
                            str = str + index.SQLScript(true);
                    });
                    if (table.SQLForeignKeysScript != string.Empty)
                    {
                        builder.Append(table.SQLForeignKeysScript);
                        SyncCmd.Insert(0, table.SQLForeignKeysScript);
                    }
                    if (str != string.Empty)
                    {
                        _sql.Append(str);
                        SyncCmd.Add(str);
                    }
                }
            }
            if (builder != null)
            {
                _sql.Insert(0, builder.ToString());
            }
            _sql.Append("\n");
            dbCompared2.Functions.ForEach(function =>
            {
                if (function.Compared == ComparedEnum.New)
                {
                    str = function.SQLScript(true);
                    if (str != string.Empty)
                    {
                        _sql.Append(str);
                        SyncCmd.Add(str);
                    }
                }
            });
            _sql.Append("\n");
            dbCompared2.Views.ForEach(view =>
            {
                if (view.Compared == ComparedEnum.New)
                {
                    str = view.SQLScript(true);
                    if (str != string.Empty)
                    {
                        _sql.Append(str);
                        SyncCmd.Add(str);
                    }
                }
            });
            _sql.Append("\n");
            dbCompared2.StoredProcedures.ForEach(procedure =>
            {
                if (procedure.Compared == ComparedEnum.New)
                {
                    str = procedure.SQLScript(true);
                    if (str != string.Empty)
                    {
                        _sql.Append(str);
                        SyncCmd.Add(str);
                    }
                }
            });
            _sql.Append("\n");
            GetSQLDiffScript();
        }
        
        protected void UpdateDeletedRows(DataRow dr)
        {
            if (DataSet.Tables[dr.Table.TableName] == null)
            {
                using (DataTable table = new DataTable(dr.Table.TableName))
                {
                    for (int i = 0; i < dr.Table.Columns.Count; i++)
                    {
                        DataColumn column = dr.Table.Columns[i];
                        table.Columns.Add(column.ColumnName, column.GetType());
                    }
                    DataSet.Tables.Add(table);
                }
            }
            DataSet.Tables[dr.Table.TableName].BeginLoadData();
            object[] array = new object[dr.Table.Columns.Count];
            dr.ItemArray.CopyTo(array, 0);
            DataRow row = DataSet.Tables[dr.Table.TableName].NewRow();
            row.ItemArray = array;
            row["COMPARED"] = ComparedEnum.Deleted.ToString("D");
            try
            {
                DataSet.Tables[dr.Table.TableName].Rows.Add(row);
            }
            catch (Exception)
            {
            }
        }

        private void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    _sql = null;
                    Compared = null;
                    Comparing = null;
                    Reading = null;
                    dbConnectionInfo = null;
                    Dispose();
                }
                isDisposed = true;
            }
        }

        private void ExecuteSQL(string script, DBConnectionInfo cnInfo)
        {
            using (SqlConnection connection = new SqlConnection(cnInfo.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand { Connection = connection })
                {
                    if (script.Trim() != "GO")
                    {
                        string[] strArr = script.Split(new string[] { "\r\nGO\r\n", "\r\nGO ", "GO\r\n", " GO " }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string str in strArr)
                        {
                            if (str != string.Empty)
                            {
                                command.CommandText = str;
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }

        #endregion Methods
    }
}