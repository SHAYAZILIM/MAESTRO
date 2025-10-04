using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Threading;

namespace AvukatPro.Database
{
    public partial class UpdateDb : Form
    {
        public UpdateDb()
        {
            InitializeComponent();
        }

        string tables = "exec sp_tables '%','dbo','" + Helper.VT + "',\"'TABLE'\"";
        string columns = "select TABLE_NAME,COLUMN_NAME,ORDINAL_POSITION,DATA_TYPE,IS_NULLABLE,CHARACTER_MAXIMUM_LENGTH,columnproperty(object_id(table_name), column_name,'IsIdentity') AS IsId from INFORMATION_SCHEMA.COLUMNS order by TABLE_NAME,ORDINAL_POSITION";

        string addColumn = "ALTER TABLE [dbo].[{0}]  ADD [{1}] [{2}] {3}";
        string createTable = "CREATE TABLE [dbo].[{0}] ({1}); ";
        DataSet _tableDs;

        public DataSet TableDs
        {
            get
            {
                if (_tableDs == null)
                    _tableDs = new DataSet();
                return _tableDs;
            }
            set { _tableDs = value; }
        }

        string dropProcedure = @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[{0}]";
        DataSet procedureDs;

        public DataSet ProcedureDs
        {
            get
            {
                if (procedureDs == null)
                    procedureDs = new DataSet();
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

        public string TableXml
        {
            get
            {
                return Path.Combine(Application.StartupPath, "tables.xml");
            }
        }

        string views = "exec sp_tables '%','dbo','" + Helper.VT + "',\"'VIEW'\"";
        string dropView = @"IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[{0}]'))
DROP VIEW [dbo].[{0}]";
        DataSet viewDs;

        public DataSet ViewDs
        {
            get
            {
                if (viewDs == null)
                    viewDs = new DataSet();
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

        private void UpdateDb_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Thread th = new Thread(new ThreadStart(delegate
            {

                lblInfo.Text = "Şema dosyaları yükleniyor...";

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
                DataSet CurrentDs = new DataSet();
                this.Enabled = false;
                Helper.Connection.Open();
                int c = 0;
                int err = 0;
                int t = 0;
                try
                {
                    SqlCommand cmd = new SqlCommand(tables, Helper.Connection);
                    SqlCommand cmd2 = new SqlCommand(columns, Helper.Connection);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    SqlDataAdapter adp2 = new SqlDataAdapter(cmd2);

                    adp.Fill(CurrentDs);
                    var columnTable = CurrentDs.Tables.Add("COLUMNS");
                    adp2.Fill(columnTable);


                    t = TableDs.Tables[0].Rows.Count;

                    try
                    {
                        string fSplitscript = @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fSplit]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fSplit]";
                        SqlCommand cmdfSplit = new SqlCommand(fSplitscript, Helper.Connection);
                        cmdfSplit.ExecuteNonQuery();

                        string UTILfnscript = @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UTILfn_Split]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[UTILfn_Split]";
                        SqlCommand cmdUTILfn = new SqlCommand(UTILfnscript, Helper.Connection);
                        cmdUTILfn.ExecuteNonQuery();

                        string collatescript = @"ALTER DATABASE " + Helper.VT + @" SET SINGLE_USER WITH ROLLBACK IMMEDIATE
ALTER DATABASE " + Helper.VT + @" COLLATE TURKISH_CI_AS
ALTER DATABASE " + Helper.VT + @" SET MULTI_USER";
                        SqlCommand cmdcollate = new SqlCommand(collatescript, Helper.Connection);
                        cmdcollate.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Helper.Logger.ErrorException("Collate : ", ex);

                    }
                    foreach (DataRow item in TableDs.Tables[0].Rows)
                    {
                        c++;
                        lblInfo.Text = string.Format("Table Process : {0}/{1}, Error: {2}", c, t, err);
                        var tname = item["TABLE_NAME"].ToString().Trim();
                        try
                        {
                            var sTable = CurrentDs.Tables[0].Rows.Cast<DataRow>().Where(q => q["TABLE_NAME"].ToString().Trim() == item["TABLE_NAME"].ToString().Trim()).FirstOrDefault();
                            var pcreatecolumns = TableDs.Tables[1].Rows.Cast<DataRow>().Where(q => q["TABLE_NAME"].ToString().Trim() == item["TABLE_NAME"].ToString().Trim()).ToList();
                            if (sTable == null)
                            {
                                SqlCommand cmdaddTable = new SqlCommand(string.Format(createTable, item["TABLE_NAME"].ToString().Trim(), string.Join(",", pcreatecolumns.Select(clm => string.Format("[{0}] {1}{3} {4} {2}", clm["COLUMN_NAME"].ToString().Trim(), clm["DATA_TYPE"].ToString().Trim(), clm["IS_NULLABLE"].ToString().Trim() == "YES" ? "NULL" : "NOT NULL", clm["DATA_TYPE"].ToString().Trim().ToLower().Contains("char") ? "(" + (clm["CHARACTER_MAXIMUM_LENGTH"].ToString().Trim() == "-1" ? "MAX" : clm["CHARACTER_MAXIMUM_LENGTH"].ToString().Trim()) + ")" : "", clm["IsId"].ToString().Trim() == "1" ? "IDENTITY(1,1)" : "")).ToArray())), Helper.Connection);
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
                Helper.Connection.Open();
                c = 0;

                t = ViewDs.Tables[0].Rows.Count;
                foreach (DataRow item in ViewDs.Tables[0].Rows)
                {
                    c++;
                    SqlTransaction tran = Helper.Connection.BeginTransaction();
                    lblInfo.Text = string.Format("View Process : {0}/{1}, Error: {2}", c, t, err);
                    try
                    {
                        SqlCommand cmd = new SqlCommand(string.Format(dropView, item["TABLE_NAME"]), Helper.Connection, tran);
                        cmd.ExecuteNonQuery();

                        SqlCommand cmd2 = new SqlCommand(item["CreateText"].ToString(), Helper.Connection, tran);
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
                Helper.Connection.Open();
                c = 0;
                t = ProcedureDs.Tables[0].Rows.Count;
                foreach (DataRow item in ProcedureDs.Tables[0].Rows)
                {
                    c++;
                    SqlTransaction tran = Helper.Connection.BeginTransaction();
                    lblInfo.Text = string.Format("Procedure Process : {0}/{1}, Error: {2}", c, t, err);
                    try
                    {
                        SqlCommand cmd = new SqlCommand(string.Format(dropProcedure, item["PROCEDURE_NAME"]), Helper.Connection, tran);
                        cmd.ExecuteNonQuery();

                        SqlCommand cmd2 = new SqlCommand(item["CreateText"].ToString(), Helper.Connection, tran);
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

                Helper.Connection.Close();
                if (err > 0)
                    MessageBox.Show("Veritabanı güncelleme sırasında hatalar oluşmuştur. Ayrıntılar için lütfen log klasörü içerisindeki log dosyasını bakınız.");
                else
                    MessageBox.Show("Veritabanı başarıyla güncellenmiştir.");
                this.Enabled = true;
            }));
            th.Start();
        }
    }
}
