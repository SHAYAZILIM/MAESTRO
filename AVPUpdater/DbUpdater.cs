using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace AVPUpdater
{
    public class DbUpdater
    {
        private DataSet _tableDs;
        private string addColumn = "ALTER TABLE [dbo].[{0}]  ADD [{1}] [{2}] {3}";
        private string columns = "select TABLE_NAME,COLUMN_NAME,ORDINAL_POSITION,DATA_TYPE,IS_NULLABLE,CHARACTER_MAXIMUM_LENGTH,columnproperty(object_id(table_name), column_name,'IsIdentity') AS IsId from INFORMATION_SCHEMA.COLUMNS order by TABLE_NAME,ORDINAL_POSITION";
        private string createTable = "CREATE TABLE [dbo].[{0}] ({1}); ";

        private string dropProcedure = @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[{0}]";

        private string dropView = @"IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[{0}]'))
DROP VIEW [dbo].[{0}]";

        private DataSet procedureDs;
        private string tables = "exec sp_tables '%','dbo','" + Helper.VT + "',\"'TABLE'\"";
        private DataSet viewDs;

        private string views = "exec sp_tables '%','dbo','" + Helper.VT + "',\"'VIEW'\"";

        public DataSet ProcedureDs
        {
            get
            {
                if (procedureDs == null)
                {
                    procedureDs = new DataSet();
                }
                return procedureDs;
            }
            set { procedureDs = value; }
        }

        public string ProceduresXml
        {
            get
            {
                return Path.Combine(Application.StartupPath, "procedures.xml");
            }
        }

        public DataSet TableDs
        {
            get
            {
                if (_tableDs == null)
                {
                    _tableDs = new DataSet();
                }
                return _tableDs;
            }
            set { _tableDs = value; }
        }

        public string TableXml
        {
            get
            {
                return Path.Combine(Application.StartupPath, "tables.xml");
            }
        }

        public DataSet ViewDs
        {
            get
            {
                if (viewDs == null)
                {
                    viewDs = new DataSet();
                }
                return viewDs;
            }
            set { viewDs = value; }
        }

        public string ViewsXml
        {
            get
            {
                return Path.Combine(Application.StartupPath, "views.xml");
            }
        }

        public void UpdateDb(DevExpress.XtraEditors.ProgressBarControl progressBarControl2, DevExpress.XtraEditors.ProgressBarControl progressBarControl1, DevExpress.XtraEditors.LabelControl lblInfo, DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1)
        {
            if (File.Exists(TableXml))
            {
                TableDs.ReadXml(TableXml);
            }
            if (File.Exists(ViewsXml))
            {
                ViewDs.ReadXml(ViewsXml);
            }
            if (File.Exists(ProceduresXml))
            {
                ProcedureDs.ReadXml(ProceduresXml);
            }

            //if (TableDs.Tables.Count == 0 && ViewDs.Tables.Count == 0 && ProcedureDs.Tables.Count == 0)
            //    return;

            DataSet CurrentDs = new DataSet();
            Helper.Connection.Open();
            int c = 0;
            int err = 0;
            int t = 0;
            try
            {
                #region Şema Okuma

                lblInfo.Text = "Şema dosyaları yükleniyor...";
                SqlCommand cmd = new SqlCommand(tables, Helper.Connection);
                cmd.CommandTimeout = 1000;
                SqlCommand cmd2 = new SqlCommand(columns, Helper.Connection);
                cmd2.CommandTimeout = 1000;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                SqlDataAdapter adp2 = new SqlDataAdapter(cmd2);

                adp.Fill(CurrentDs);
                var columnTable = CurrentDs.Tables.Add("COLUMNS");
                adp2.Fill(columnTable);

                if (TableDs.Tables.Count > 0)
                    t = TableDs.Tables[0].Rows.Count;
                if (progressBarControl2.InvokeRequired)
                {
                    progressBarControl2.Invoke((MethodInvoker)delegate
                    {
                        progressBarControl2.Position = 0;
                    });
                }
                else
                {
                    progressBarControl2.Position = 0;
                }
                try
                {
                    try
                    {
                        string fSplitscript = @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fSplit]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fSplit]";
                        SqlCommand cmdfSplit = new SqlCommand(fSplitscript, Helper.Connection);
                        cmdfSplit.CommandTimeout = 1000;
                        cmdfSplit.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Helper.Logger.ErrorException("Collate : ", ex);
                    }


                    try
                    {
                        string UTILfnscript = @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UTILfn_Split]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[UTILfn_Split]";
                        SqlCommand cmdUTILfn = new SqlCommand(UTILfnscript, Helper.Connection);
                        cmdUTILfn.CommandTimeout = 1000;
                        cmdUTILfn.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Helper.Logger.ErrorException("Collate : ", ex);
                    }


                    try
                    {
                        string collatescript = @"ALTER DATABASE " + Helper.VT + @" SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
ALTER DATABASE " + Helper.VT + @" COLLATE TURKISH_CI_AS;
ALTER DATABASE " + Helper.VT + @" SET MULTI_USER";
                        SqlCommand cmdcollate = new SqlCommand(collatescript, Helper.Connection);
                        cmdcollate.CommandTimeout = 1000;
                        cmdcollate.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Helper.Logger.ErrorException("Collate : ", ex);
                    }
                    finally
                    {
                        string collatescriptmulti = @"ALTER DATABASE " + Helper.VT + @" SET MULTI_USER";
                        SqlCommand cmdcollatemulti = new SqlCommand(collatescriptmulti, Helper.Connection);
                        cmdcollatemulti.CommandTimeout = 1000;
                        cmdcollatemulti.ExecuteNonQuery();
                    }

                    string collate2 = @"DECLARE @collate nvarchar(100);
DECLARE @table nvarchar(255);
DECLARE @column_name nvarchar(255);
DECLARE @column_id int;
DECLARE @data_type nvarchar(255);
DECLARE @max_length int;
DECLARE @row_id int;
DECLARE @sql nvarchar(max);
DECLARE @sql_column nvarchar(max);

SET @collate = 'TURKISH_CI_AS';

DECLARE local_table_cursor CURSOR FOR

SELECT [name]
FROM sysobjects
WHERE OBJECTPROPERTY(id, N'IsUserTable') = 1

OPEN local_table_cursor
FETCH NEXT FROM local_table_cursor
INTO @table

IF OBJECT_ID('tempdb..#LocalTempTable') IS NOT NULL DROP TABLE #LocalTempTable


CREATE TABLE #LocalTempTable(
scrpt nvarchar(max))
WHILE @@FETCH_STATUS = 0
BEGIN

    DECLARE local_change_cursor CURSOR FOR

select ORDINAL_POSITION as row_id
,COLUMN_NAME as column_name
,DATA_TYPE as data_type
,CHARACTER_MAXIMUM_LENGTH as max_length
from INFORMATION_SCHEMA.COLUMNS 
where TABLE_NAME = @table
order by ORDINAL_POSITION

    OPEN local_change_cursor
    FETCH NEXT FROM local_change_cursor
    INTO @row_id, @column_name, @data_type, @max_length

    WHILE @@FETCH_STATUS = 0
    BEGIN

        IF (@max_length = -1) SET @max_length = 4000;

        IF (@data_type LIKE '%char%')
        BEGIN TRY
            SET @sql = 'ALTER TABLE ' + @table + ' ALTER COLUMN ' + @column_name + ' ' + @data_type + '(' + CAST(@max_length AS nvarchar(100)) + ') COLLATE ' + @collate
            PRINT @sql
            insert into #LocalTempTable(scrpt) values(@sql)
            --EXEC sp_executesql @sql
        END TRY
        BEGIN CATCH
          PRINT 'ERROR: Some index or contraint rely on the column' + @column_name + '. No conversion possible.'
          PRINT @sql
        END CATCH

        FETCH NEXT FROM local_change_cursor
        INTO @row_id, @column_name, @data_type, @max_length

    END

    CLOSE local_change_cursor
    DEALLOCATE local_change_cursor

    FETCH NEXT FROM local_table_cursor
    INTO @table

END

CLOSE local_table_cursor
DEALLOCATE local_table_cursor
select * from #LocalTempTable

";
                    SqlCommand cmdcollate2 = new SqlCommand(collate2, Helper.Connection);
                    //cmdcollate2.ExecuteNonQuery();
                    var kullanicikontrolreader = cmdcollate2.ExecuteReader();
                    List<string> scrpt = new List<string>();
                    while (kullanicikontrolreader.Read())
                    {
                        try
                        {
                            scrpt.Add(kullanicikontrolreader.GetString(0));

                        }
                        catch (Exception ex)
                        {
                            Helper.Logger.ErrorException("Collate table columns: ", ex);
                        }
                    }
                    kullanicikontrolreader.Close();
                    SqlCommand cmdcollate3;
                    foreach (var item in scrpt)
                    {
                        try
                        {
                            cmdcollate3 = new SqlCommand(item, Helper.Connection);
                            cmdcollate3.CommandTimeout = 1000;
                            cmdcollate3.ExecuteNonQuery();
                        }
                        catch { }
                    }
                }
                catch (Exception ex)
                {
                    Helper.Logger.ErrorException("Collate : ", ex);
                }
                if (progressBarControl2.InvokeRequired)
                {
                    progressBarControl2.Invoke((MethodInvoker)delegate
                    {
                        progressBarControl2.Properties.Maximum = t;
                        progressBarControl2.Position = 0;
                    });
                }
                else
                {
                    progressBarControl2.Properties.Maximum = t;
                    progressBarControl2.Position = 0;
                }

                #endregion Şema Okuma

                #region Tablo

                if (TableDs.Tables.Count > 0)
                    foreach (DataRow item in TableDs.Tables[0].Rows)
                    {
                        c++;
                        lblInfo.Text = string.Format("Table Process : {0}/{1}", c, t);
                        if (progressBarControl2.InvokeRequired)
                        {
                            progressBarControl2.Invoke((MethodInvoker)delegate
                            {
                                progressBarControl2.Position++;
                            });
                        }
                        else
                        {
                            progressBarControl2.Position++;
                        }
                        var tname = item["TABLE_NAME"].ToString().Trim();
                        try
                        {
                            var sTable = CurrentDs.Tables[0].Rows.Cast<DataRow>().Where(q => q["TABLE_NAME"].ToString().Trim() == item["TABLE_NAME"].ToString().Trim()).FirstOrDefault();
                            var pcreatecolumns = TableDs.Tables[1].Rows.Cast<DataRow>().Where(q => q["TABLE_NAME"].ToString().Trim() == item["TABLE_NAME"].ToString().Trim()).ToList();
                            if (sTable == null)
                            {
                                SqlCommand cmdaddTable = new SqlCommand(string.Format(createTable, item["TABLE_NAME"].ToString().Trim(), string.Join(",", pcreatecolumns.Select(clm => string.Format("[{0}] {1}{3} {4} {2}", clm["COLUMN_NAME"].ToString().Trim(), clm["DATA_TYPE"].ToString().Trim(), clm["IS_NULLABLE"].ToString().Trim() == "YES" ? "NULL" : "NOT NULL", clm["DATA_TYPE"].ToString().Trim().ToLower().Contains("char") ? "(" + (clm["CHARACTER_MAXIMUM_LENGTH"].ToString().Trim() == "-1" ? "MAX" : clm["CHARACTER_MAXIMUM_LENGTH"].ToString().Trim()) + ")" : "", clm["IsId"].ToString().Trim() == "1" ? "IDENTITY(1,1)" : "")).ToArray())), Helper.Connection);
                                cmdaddTable.CommandTimeout = 1000;
                                cmdaddTable.ExecuteNonQuery();
                                //err++;
                                //Helper.Logger.Info(string.Format("'{0}' tablosu sistemde bulunamadı.", item["TABLE_NAME"]));
                            }
                            else
                            {
                                var pcolumns = TableDs.Tables[1].Rows.Cast<DataRow>().Where(q => q["TABLE_NAME"].ToString().Trim() == item["TABLE_NAME"].ToString().Trim()).ToList();
                                var scolumns = CurrentDs.Tables[1].Rows.Cast<DataRow>().Where(q => q["TABLE_NAME"].ToString().Trim() == item["TABLE_NAME"].ToString().Trim()).ToList();

                                foreach (var clm in pcolumns)
                                {
                                    if (!scolumns.Any(q => q["COLUMN_NAME"].ToString().Trim() == clm["COLUMN_NAME"].ToString().Trim()))
                                    {
                                        SqlCommand cmdcolumn = new SqlCommand(string.Format(addColumn, item["TABLE_NAME"].ToString().Trim(), clm["COLUMN_NAME"].ToString().Trim(), clm["DATA_TYPE"].ToString().Trim(), clm["IS_NULLABLE"].ToString().Trim() == "YES" ? "NULL" : "NOT NULL"), Helper.Connection);
                                        cmdcolumn.CommandTimeout = 1000;
                                        cmdcolumn.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            err++;
                            Helper.Logger.ErrorException("Check Table List : " + tname, ex);
                        }
                    }
            }
            catch (Exception ex)
            {
                err++;
                Helper.Logger.ErrorException("Check Table List", ex);
            }
            finally
            {
                Helper.Connection.Close();
            }
            checkedListBoxControl1.Items[4].CheckState = CheckState.Checked;
            try
            {
                if (File.Exists(TableXml))
                    File.Delete(TableXml);
            }
            catch (Exception ex)
            {
                Helper.Logger.ErrorException("TableXml File Delete", ex);
            }
                #endregion Tablo

            #region View

            Helper.Connection.Open();
            c = 0;

            if (ViewDs.Tables.Count > 0)
                t = ViewDs.Tables[0].Rows.Count;
            if (progressBarControl2.InvokeRequired)
            {
                progressBarControl2.Invoke((MethodInvoker)delegate
                {
                    progressBarControl2.Properties.Maximum = t;
                    progressBarControl2.Position = 0;
                });
            }
            else
            {
                progressBarControl2.Properties.Maximum = t;
                progressBarControl2.Position = 0;
            }
            if (ViewDs.Tables.Count > 0)
                foreach (DataRow item in ViewDs.Tables[0].Rows)
                {
                    c++;
                    lblInfo.Text = string.Format("View Process : {0}/{1}", c, t);
                    if (progressBarControl2.InvokeRequired)
                    {
                        progressBarControl2.Invoke((MethodInvoker)delegate
                        {
                            progressBarControl2.Position++;
                        });
                    }
                    else
                    {
                        progressBarControl2.Position++;
                    }
                    SqlTransaction tran = Helper.Connection.BeginTransaction();
                    try
                    {
                        SqlCommand cmd = new SqlCommand(string.Format(dropView, item["TABLE_NAME"]), Helper.Connection, tran);
                        cmd.CommandTimeout = 1000;
                        cmd.ExecuteNonQuery();

                        SqlCommand cmd2 = new SqlCommand(item["CreateText"].ToString(), Helper.Connection, tran);
                        cmd2.CommandTimeout = 1000;
                        cmd2.ExecuteNonQuery();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        err++;
                        tran.Rollback();
                        Helper.Logger.ErrorException("View : " + item["TABLE_NAME"].ToString(), ex);
                    }
                }

            Helper.Connection.Close();
            checkedListBoxControl1.Items[5].CheckState = CheckState.Checked;
            try
            {
                if (File.Exists(ViewsXml))
                    File.Delete(ViewsXml);
            }
            catch (Exception ex)
            {
                Helper.Logger.ErrorException("ViewsXml File Delete", ex);
            }
            #endregion View

            #region Procedure

            Helper.Connection.Open();
            c = 0;
            if (ProcedureDs.Tables.Count > 0)
                t = ProcedureDs.Tables[0].Rows.Count;
            if (progressBarControl2.InvokeRequired)
            {
                progressBarControl2.Invoke((MethodInvoker)delegate
                {
                    progressBarControl2.Properties.Maximum = t;
                    progressBarControl2.Position = 0;
                });
            }
            else
            {
                progressBarControl2.Properties.Maximum = t;
                progressBarControl2.Position = 0;
            }
            if (ProcedureDs.Tables.Count > 0)
                foreach (DataRow item in ProcedureDs.Tables[0].Rows)
                {
                    c++;
                    lblInfo.Text = string.Format("Procedure Process : {0}/{1}", c, t);
                    if (progressBarControl2.InvokeRequired)
                    {
                        progressBarControl2.Invoke((MethodInvoker)delegate
                        {
                            progressBarControl2.Position++;
                        });
                    }
                    else
                    {
                        progressBarControl2.Position++;
                    }
                    SqlTransaction tran = Helper.Connection.BeginTransaction();
                    try
                    {
                        SqlCommand cmd = new SqlCommand(string.Format(dropProcedure, item["PROCEDURE_NAME"]), Helper.Connection, tran);
                        cmd.CommandTimeout = 1000;
                        cmd.ExecuteNonQuery();

                        SqlCommand cmd2 = new SqlCommand(item["CreateText"].ToString(), Helper.Connection, tran);
                        cmd2.CommandTimeout = 1000;
                        cmd2.ExecuteNonQuery();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        //err++;
                        tran.Rollback();
                        Helper.Logger.ErrorException("Procedure : " + item["PROCEDURE_NAME"].ToString(), ex);
                    }
                }
            checkedListBoxControl1.Items[6].CheckState = CheckState.Checked;
            try
            {
                if (File.Exists(ProceduresXml))
                    File.Delete(ProceduresXml);
            }
            catch (Exception ex)
            {
                Helper.Logger.ErrorException("ProceduresXml File Delete", ex);
            }
            #endregion Procedure

            #region Data
            lblInfo.Text = string.Format("Data Aktarımı Başlamakta....");
            if (progressBarControl2.InvokeRequired)
            {
                progressBarControl2.Invoke((MethodInvoker)delegate
                {
                    progressBarControl2.Position = 0;
                });
            }
            else
            {
                progressBarControl2.Position = 0;
            }
            List<CetKodTable> Tables = new List<CetKodTable>();
            DataSet TableDatas = new DataSet();
            Tables = CetKodTable.GetTables(Application.StartupPath + @"\tableList.xml");
            TableDatas = new DataSet();
            if (File.Exists(Application.StartupPath + @"\tableListData.xml"))
                try
                {
                    TableDatas.ReadXml(Application.StartupPath + @"\tableListData.xml");
                }
                catch { }
            if (progressBarControl2.InvokeRequired)
            {
                progressBarControl2.Invoke((MethodInvoker)delegate
                {
                    progressBarControl2.Properties.Maximum = Tables.Count;
                    progressBarControl2.Position = 0;
                });
            }
            else
            {
                progressBarControl2.Properties.Maximum = Tables.Count;
                progressBarControl2.Position = 0;
            }

            var sqltypes = SqlDbType.BigInt.GetList();

            foreach (var item in Tables)
            {
                lblInfo.Text = string.Format("Data Aktarılıyor : {0}", item.Name);
                if (progressBarControl2.InvokeRequired)
                {
                    progressBarControl2.Invoke((MethodInvoker)delegate
                    {
                        progressBarControl2.Position++;
                    });
                }
                else
                {
                    progressBarControl2.Position++;
                }

                string insertcolumns = "";
                string insertParameterNames = "";

                string updatecolumns = "";
                string sqlupdatescript = "";
                bool isidentity = item.Columns.Any(q => q.IsIdentity && q.IsCondition);
                CetKodTableColumn identityColumn = item.Columns.Where(q => q.IsIdentity && q.IsCondition).FirstOrDefault();
                updatecolumns = string.Join(",", item.Columns.Where(q => q.IsUpdate).Select(q => q.Name + " = @" + q.Name).ToArray());

                if (isidentity)
                {
                    insertcolumns = string.Join(",", item.Columns.Select(q => q.Name).ToArray());
                    insertParameterNames = string.Join(",", item.Columns.Select(q => "@" + q.Name).ToArray());
                    sqlupdatescript = string.Format("Update {0} set {1} where {2} = @{2}", item.Name, updatecolumns, identityColumn.Name);

                }
                else
                {
                    insertcolumns = string.Join(",", item.Columns.Where(q => !q.IsIdentity).Select(q => q.Name).ToArray());
                    insertParameterNames = string.Join(",", item.Columns.Where(q => !q.IsIdentity).Select(q => "@" + q.Name).ToArray());
                    sqlupdatescript = string.Format("Update {0} set {1} where {2}", item.Name, updatecolumns, string.Join(" And ", item.Columns.Where(q => q.IsCondition).Select(q => q.Name + " = @" + q.Name).ToArray()));

                }

                string sqlinsertscript = string.Format("{0}insert into {1} ({2}) Values ({3}) ; {4}", isidentity ? "SET IDENTITY_INSERT " + item.Name + " ON;" : "", item.Name, insertcolumns, insertParameterNames, isidentity ? "SET IDENTITY_INSERT " + item.Name + " OFF;" : "");

                if (TableDatas.Tables.Contains(item.Name))
                    foreach (DataRow datarow in TableDatas.Tables[item.Name].Rows)
                    {
                        try
                        {
                            if (datarow["KONTROL_KIM_ID"] != null)
                                datarow["KONTROL_KIM_ID"] = 1;
                        }
                        catch
                        {

                        }
                        try
                        {
                            if (isidentity)
                            {
                                SqlCommand cmdcolumn = new SqlCommand(string.Format("Select * from {0} Where {1} = {2}", item.Name, identityColumn.Name, datarow[identityColumn.Name]), Helper.Connection);
                                cmdcolumn.CommandTimeout = 1000;
                                SqlDataAdapter adp = new SqlDataAdapter(cmdcolumn);
                                DataTable rowData = new DataTable();
                                adp.Fill(rowData);
                                if (rowData.Rows.Count == 0)
                                {
                                    SqlCommand cmdinsert = new SqlCommand(sqlinsertscript, Helper.Connection);
                                    cmdinsert.CommandTimeout = 1000;
                                    foreach (var dataColumn in item.Columns)
                                    {
                                        if (cmdinsert.Parameters.Contains("@" + dataColumn.Name))
                                            continue;
                                        var type = sqltypes.Where(q => q.Name.ToLowerInvariant() == dataColumn.DataType.ToLowerInvariant()).FirstOrDefault();
                                        try
                                        {
                                            if (type != null)
                                            {
                                                var prm = cmdinsert.Parameters.Add("@" + dataColumn.Name, (SqlDbType)type.Id);
                                                if ((SqlDbType)type.Id == SqlDbType.Image)
                                                    prm.Value = EnumHelper.GetPhoto(datarow[dataColumn.Name].ToString());
                                                else if ((SqlDbType)type.Id == SqlDbType.UniqueIdentifier)
                                                    prm.Value = new Guid(datarow[dataColumn.Name].ToString());
                                                else if ((SqlDbType)type.Id == SqlDbType.Decimal || (SqlDbType)type.Id == SqlDbType.Float || (SqlDbType)type.Id == SqlDbType.Money || (SqlDbType)type.Id == SqlDbType.SmallMoney)
                                                    prm.Value = decimal.Parse(datarow[dataColumn.Name].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                                else
                                                    prm.Value = datarow[dataColumn.Name];
                                            }
                                            else
                                            {
                                                cmdinsert.Parameters.AddWithValue("@" + dataColumn.Name, datarow[dataColumn.Name]);
                                            }
                                        }
                                        catch
                                        {
                                            if (cmdinsert.Parameters.Contains("@" + dataColumn.Name))
                                                cmdinsert.Parameters["@" + dataColumn.Name].Value = DBNull.Value;
                                            else
                                                cmdinsert.Parameters.AddWithValue("@" + dataColumn.Name, DBNull.Value);
                                        }
                                    }
                                    cmdinsert.ExecuteNonQuery();
                                }
                                else
                                {
                                    SqlCommand cmdupdate = new SqlCommand(sqlupdatescript, Helper.Connection);
                                    cmdupdate.CommandTimeout = 1000;
                                    foreach (var dataColumn in item.Columns.Where(q => q.IsUpdate || q.IsCondition))
                                    {
                                        if (cmdupdate.Parameters.Contains("@" + dataColumn.Name))
                                            continue;
                                        var type = sqltypes.Where(q => q.Name.ToLowerInvariant() == dataColumn.DataType.ToLowerInvariant()).FirstOrDefault();
                                        try
                                        {
                                            if (type != null)
                                            {
                                                var prm = cmdupdate.Parameters.Add("@" + dataColumn.Name, (SqlDbType)type.Id);
                                                if ((SqlDbType)type.Id == SqlDbType.Image)
                                                    prm.Value = EnumHelper.GetPhoto(datarow[dataColumn.Name].ToString());
                                                else if ((SqlDbType)type.Id == SqlDbType.UniqueIdentifier)
                                                    prm.Value = new Guid(datarow[dataColumn.Name].ToString());
                                                else if ((SqlDbType)type.Id == SqlDbType.Decimal || (SqlDbType)type.Id == SqlDbType.Float || (SqlDbType)type.Id == SqlDbType.Money || (SqlDbType)type.Id == SqlDbType.SmallMoney)
                                                    prm.Value = decimal.Parse(datarow[dataColumn.Name].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                                else
                                                    prm.Value = datarow[dataColumn.Name];
                                            }
                                            else
                                            {
                                                cmdupdate.Parameters.AddWithValue("@" + dataColumn.Name, datarow[dataColumn.Name]);
                                            }
                                        }
                                        catch
                                        {
                                            if (cmdupdate.Parameters.Contains("@" + dataColumn.Name))
                                                cmdupdate.Parameters["@" + dataColumn.Name].Value = DBNull.Value;
                                            else
                                                cmdupdate.Parameters.AddWithValue("@" + dataColumn.Name, DBNull.Value);
                                        }
                                    }
                                    cmdupdate.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                var conditionColumns = item.Columns.Where(q => q.IsCondition).ToList();
                                SqlCommand cmdcolumn = new SqlCommand(string.Format("Select * from {0} Where {1}", item.Name, string.Join(" And ", conditionColumns.Select(q => q.Name + " = @" + q.Name).ToArray())), Helper.Connection);
                                cmdcolumn.CommandTimeout = 1000;

                                foreach (var condition in conditionColumns)
                                {
                                    var type = sqltypes.Where(q => q.Name.ToLowerInvariant() == condition.DataType.ToLowerInvariant()).FirstOrDefault();
                                    try
                                    {
                                        if (type != null)
                                        {
                                            var prm = cmdcolumn.Parameters.Add("@" + condition.Name, (SqlDbType)type.Id);
                                            if ((SqlDbType)type.Id == SqlDbType.Image)
                                                prm.Value = EnumHelper.GetPhoto(datarow[condition.Name].ToString());
                                            else if ((SqlDbType)type.Id == SqlDbType.UniqueIdentifier)
                                                prm.Value = new Guid(datarow[condition.Name].ToString());
                                            else if ((SqlDbType)type.Id == SqlDbType.Decimal || (SqlDbType)type.Id == SqlDbType.Float || (SqlDbType)type.Id == SqlDbType.Money || (SqlDbType)type.Id == SqlDbType.SmallMoney)
                                                prm.Value = decimal.Parse(datarow[condition.Name].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                            else
                                                prm.Value = datarow[condition.Name];
                                        }
                                        else
                                        {
                                            cmdcolumn.Parameters.AddWithValue("@" + condition.Name, datarow[condition.Name]);
                                        }
                                    }
                                    catch
                                    {
                                        if (cmdcolumn.Parameters.Contains("@" + condition.Name))
                                            cmdcolumn.Parameters["@" + condition.Name].Value = DBNull.Value;
                                        else
                                            cmdcolumn.Parameters.AddWithValue("@" + condition.Name, DBNull.Value);
                                    }
                                }

                                SqlDataAdapter adp = new SqlDataAdapter(cmdcolumn);
                                DataTable rowData = new DataTable();
                                adp.Fill(rowData);
                                if (rowData.Rows.Count == 0)
                                {
                                    SqlCommand cmdinsert = new SqlCommand(sqlinsertscript, Helper.Connection);
                                    cmdinsert.CommandTimeout = 1000;
                                    foreach (var dataColumn in item.Columns)
                                    {
                                        if (cmdinsert.Parameters.Contains("@" + dataColumn.Name))
                                            continue;
                                        var type = sqltypes.Where(q => q.Name.ToLowerInvariant() == dataColumn.DataType.ToLowerInvariant()).FirstOrDefault();
                                        try
                                        {
                                            if (type != null)
                                            {
                                                var prm = cmdinsert.Parameters.Add("@" + dataColumn.Name, (SqlDbType)type.Id);
                                                if ((SqlDbType)type.Id == SqlDbType.Image)
                                                    prm.Value = EnumHelper.GetPhoto(datarow[dataColumn.Name].ToString());
                                                else if ((SqlDbType)type.Id == SqlDbType.UniqueIdentifier)
                                                    prm.Value = new Guid(datarow[dataColumn.Name].ToString());
                                                else if ((SqlDbType)type.Id == SqlDbType.Decimal || (SqlDbType)type.Id == SqlDbType.Float || (SqlDbType)type.Id == SqlDbType.Money || (SqlDbType)type.Id == SqlDbType.SmallMoney)
                                                    prm.Value = decimal.Parse(datarow[dataColumn.Name].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                                else
                                                    prm.Value = datarow[dataColumn.Name];
                                            }
                                            else
                                            {
                                                cmdinsert.Parameters.AddWithValue("@" + dataColumn.Name, datarow[dataColumn.Name]);
                                            }
                                        }
                                        catch
                                        {
                                            if (cmdinsert.Parameters.Contains("@" + dataColumn.Name))
                                                cmdinsert.Parameters["@" + dataColumn.Name].Value = DBNull.Value;
                                            else
                                                cmdinsert.Parameters.AddWithValue("@" + dataColumn.Name, DBNull.Value);
                                        }
                                    }
                                    cmdinsert.ExecuteNonQuery();
                                }
                                else
                                {
                                    SqlCommand cmdupdate = new SqlCommand(sqlupdatescript, Helper.Connection);
                                    cmdupdate.CommandTimeout = 1000;
                                    foreach (var dataColumn in item.Columns.Where(q => q.IsUpdate || q.IsCondition))
                                    {
                                        if (cmdupdate.Parameters.Contains("@" + dataColumn.Name))
                                            continue;
                                        var type = sqltypes.Where(q => q.Name.ToLowerInvariant() == dataColumn.DataType.ToLowerInvariant()).FirstOrDefault();
                                        try
                                        {
                                            if (type != null)
                                            {
                                                var prm = cmdupdate.Parameters.Add("@" + dataColumn.Name, (SqlDbType)type.Id);
                                                if ((SqlDbType)type.Id == SqlDbType.Image)
                                                    prm.Value = EnumHelper.GetPhoto(datarow[dataColumn.Name].ToString());
                                                else if ((SqlDbType)type.Id == SqlDbType.UniqueIdentifier)
                                                    prm.Value = new Guid(datarow[dataColumn.Name].ToString());
                                                else if ((SqlDbType)type.Id == SqlDbType.Decimal || (SqlDbType)type.Id == SqlDbType.Float || (SqlDbType)type.Id == SqlDbType.Money || (SqlDbType)type.Id == SqlDbType.SmallMoney)
                                                    prm.Value = decimal.Parse(datarow[dataColumn.Name].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                                else
                                                    prm.Value = datarow[dataColumn.Name];

                                            }
                                            else
                                            {
                                                cmdupdate.Parameters.AddWithValue("@" + dataColumn.Name, datarow[dataColumn.Name]);
                                            }
                                        }
                                        catch
                                        {
                                            if (cmdupdate.Parameters.Contains("@" + dataColumn.Name))
                                                cmdupdate.Parameters["@" + dataColumn.Name].Value = DBNull.Value;
                                            else
                                                cmdupdate.Parameters.AddWithValue("@" + dataColumn.Name, DBNull.Value);
                                        }
                                    }
                                    cmdupdate.ExecuteNonQuery();
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            Helper.Logger.ErrorException(item.Name, ex);
                        }
                    }
            }
            try
            {
                if (File.Exists(Application.StartupPath + @"\tableList.xml"))
                    File.Delete(Application.StartupPath + @"\tableList.xml");
            }
            catch (Exception ex)
            {
                Helper.Logger.ErrorException("tableList File Delete", ex);
            }
            try
            {
                if (File.Exists(Application.StartupPath + @"\tableListData.xml"))
                    File.Delete(Application.StartupPath + @"\tableListData.xml");
            }
            catch (Exception ex)
            {
                Helper.Logger.ErrorException("tableListData File Delete", ex);
            }
            #endregion


            progressBarControl1.Position += 10;
            Helper.Connection.Close();
        }
    }
    public static class EnumHelper
    {
        public static byte[] GetPhoto(string s)
        {
            Stream stream = GenerateStreamFromString(s);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }

        static Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static List<EnumModel> GetList(this Enum source)
        {
            var returnValue = new List<EnumModel>();
            foreach (var item in Enum.GetValues(source.GetType()))
            {
                var enummodel = new EnumModel();
                enummodel.Id = (int)item;
                enummodel.Name = ((Enum)item).GetName();
                returnValue.Add(enummodel);
            }
            return returnValue;
        }

        public static string GetName(this Enum source)
        {
            FieldInfo field = source.GetType().GetField(source.ToString());

            DescriptionAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                        as DescriptionAttribute;

            return attribute == null ? source.ToString() : attribute.Description;
        }
    }

    public class EnumModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}