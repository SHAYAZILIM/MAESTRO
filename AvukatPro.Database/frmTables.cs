using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AvukatPro.Database
{
    public partial class frmTables : Form
    {
        public frmTables()
        {
            InitializeComponent();
        }

        private DataSet _tableDs;
        private string addColumn = "ALTER TABLE [dbo].[{0}]  ADD [{1}] [{2}] {3}";
        private string columns = "select TABLE_NAME,COLUMN_NAME,ORDINAL_POSITION,DATA_TYPE,IS_NULLABLE,CHARACTER_MAXIMUM_LENGTH,columnproperty(object_id(table_name), column_name,'IsIdentity') AS IsId from INFORMATION_SCHEMA.COLUMNS order by TABLE_NAME,ORDINAL_POSITION";
        private string createTable = "CREATE TABLE [dbo].[{0}] ({1}); ";

        private string tables = "exec sp_tables '%','dbo','" + Helper.VT + "',\"'TABLE'\"";

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

        public string TableXml
        {
            get
            {
                return Path.Combine(Application.StartupPath, "tables.xml");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(delegate
            {
                this.Enabled = false;
                Helper.Connection.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(tables, Helper.Connection);
                    SqlCommand cmd2 = new SqlCommand(columns, Helper.Connection);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    SqlDataAdapter adp2 = new SqlDataAdapter(cmd2);

                    adp.Fill(TableDs);
                    var columnTable = TableDs.Tables.Add("COLUMNS");
                    adp2.Fill(columnTable);

                    dataGridView1.DataSource = TableDs.Tables[0];
                    dataGridView2.DataSource = TableDs.Tables[1];
                }
                catch (Exception ex)
                {
                    Helper.Logger.ErrorException("Get Table List", ex);
                }
                finally
                {
                    Helper.Connection.Close();
                }
                this.Enabled = true;
            }));
            th.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(TableXml))
            {
                TableDs.ReadXml(TableXml);
                dataGridView1.DataSource = TableDs.Tables[0];
                dataGridView2.DataSource = TableDs.Tables[1];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TableDs.WriteXml(TableXml);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(delegate
            {
                DataSet CurrentDs = new DataSet();
                this.Enabled = false;
                Helper.Connection.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(tables, Helper.Connection);
                    SqlCommand cmd2 = new SqlCommand(columns, Helper.Connection);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    SqlDataAdapter adp2 = new SqlDataAdapter(cmd2);

                    adp.Fill(CurrentDs);
                    var columnTable = CurrentDs.Tables.Add("COLUMNS");
                    adp2.Fill(columnTable);

                    int c = 0;
                    int err = 0;
                    int t = TableDs.Tables[0].Rows.Count;

                    foreach (DataRow item in TableDs.Tables[0].Rows)
                    {
                        c++;
                        toolStripStatusLabel1.Text = string.Format("Process : {0}/{1}, Error: {2}", c, t, err);
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
                    Helper.Logger.ErrorException("Check Table List", ex);
                }
                finally
                {
                    Helper.Connection.Close();
                }
                this.Enabled = true;
            }));
            th.Start();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (var item in TableDs.Tables[0].AsEnumerable().Skip(100).ToList())
            {
                TableDs.Tables[0].Rows.Remove(item);
            }

            TableDs.WriteXml(TableXml);            
        }
    }
}