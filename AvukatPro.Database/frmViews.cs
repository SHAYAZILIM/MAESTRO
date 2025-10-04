using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AvukatPro.Database
{
    public partial class frmViews : Form
    {
        public frmViews()
        {
            InitializeComponent();
        }

        private string createView = "exec sp_helptext '{0}'";

        private string dropView = @"IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[{0}]'))
DROP VIEW [dbo].[{0}]";

        private DataSet viewDs;
        private string views = "exec sp_tables '%','dbo','" + Helper.VT + "',\"'VIEW'\"";

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

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(delegate
            {
                this.Enabled = false;
                Helper.Connection.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(views, Helper.Connection);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);

                    adp.Fill(ViewDs);

                    ViewDs.Tables[0].Columns.Add("CreateText");

                    foreach (DataRow item in ViewDs.Tables[0].Rows)
                    {
                        SqlCommand cmdcreate = new SqlCommand(string.Format(createView, item["TABLE_NAME"]), Helper.Connection);
                        SqlDataAdapter adpcreate = new SqlDataAdapter(cmdcreate);
                        DataSet dsvc = new DataSet();
                        adpcreate.Fill(dsvc);
                        item["CreateText"] = string.Join("", dsvc.Tables[0].Rows.Cast<DataRow>().Select(x => x["Text"].ToString()).ToArray());
                    }

                    dataGridView1.DataSource = ViewDs.Tables[0];
                }
                catch (Exception ex)
                {
                    Helper.Logger.ErrorException("Get View List", ex);
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
            if (File.Exists(ViewsXml))
            {
                ViewDs.ReadXml(ViewsXml);
                dataGridView1.DataSource = ViewDs.Tables[0];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewDs.WriteXml(ViewsXml);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bütün Viewlar yeniden oluşturulacak. eminmisiniz?", "Warning", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            this.Enabled = false;
            Thread th = new Thread(new ThreadStart(delegate
            {
                Helper.Connection.Open();
                int c = 0;
                int err = 0;
                int t = ViewDs.Tables[0].Rows.Count;
                foreach (DataRow item in ViewDs.Tables[0].Rows)
                {
                    c++;
                    SqlTransaction tran = Helper.Connection.BeginTransaction();
                    toolStripStatusLabel1.Text = string.Format("Process : {0}/{1}, Error: {2}", c, t, err);
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
                this.Enabled = true;

                Helper.Connection.Close();
            }));
            th.Start();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (var item in ViewDs.Tables[0].AsEnumerable().Skip(100).ToList())
            {
                ViewDs.Tables[0].Rows.Remove(item);
            }

            ViewDs.WriteXml(ViewsXml);
        }
    }
}