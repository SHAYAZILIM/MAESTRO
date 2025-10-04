using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AvukatPro.Database
{
    public partial class frmProcedures : Form
    {
        public frmProcedures()
        {
            InitializeComponent();
        }

        private string createProcedure = "exec sp_helptext '{0}'";

        private string dropProcedure = @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[{0}]";

        private DataSet procedureDs;
        private string procedures = "exec sp_stored_procedures '%','dbo'";

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

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(delegate
            {
                this.Enabled = false;
                Helper.Connection.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(procedures, Helper.Connection);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);

                    adp.Fill(ProcedureDs);

                    ProcedureDs.Tables[0].Columns.Add("CreateText");
                    int c = 0;
                    int t = ProcedureDs.Tables[0].Rows.Count;
                    foreach (DataRow item in ProcedureDs.Tables[0].Rows)
                    {
                        c++;
                        toolStripStatusLabel1.Text = string.Format("{0}/{1}", c, t);
                        item["PROCEDURE_NAME"] = item["PROCEDURE_NAME"].ToString().Split(';')[0].Trim();
                        SqlCommand cmdcreate = new SqlCommand(string.Format(createProcedure, item["PROCEDURE_NAME"]), Helper.Connection);
                        SqlDataAdapter adpcreate = new SqlDataAdapter(cmdcreate);
                        DataSet dsvc = new DataSet();
                        adpcreate.Fill(dsvc);
                        item["CreateText"] = string.Join("", dsvc.Tables[0].Rows.Cast<DataRow>().Select(x => x["Text"].ToString()).ToArray());
                    }

                    dataGridView1.DataSource = ProcedureDs.Tables[0];
                }
                catch (Exception ex)
                {
                    Helper.Logger.ErrorException("Get Procedure List", ex);
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
            if (File.Exists(ProceduresXml))
            {
                ProcedureDs.ReadXml(ProceduresXml);
                dataGridView1.DataSource = ProcedureDs.Tables[0];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProcedureDs.WriteXml(ProceduresXml);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bütün Procedureler yeniden oluşturulacak. eminmisiniz?", "Warning", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            this.Enabled = false;
            Thread th = new Thread(new ThreadStart(delegate
            {
                Helper.Connection.Open();
                int c = 0;
                int err = 0;
                int t = ProcedureDs.Tables[0].Rows.Count;
                foreach (DataRow item in ProcedureDs.Tables[0].Rows)
                {
                    c++;
                    SqlTransaction tran = Helper.Connection.BeginTransaction();
                    toolStripStatusLabel1.Text = string.Format("Process : {0}/{1}, Error: {2}", c, t, err);
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
                        err++;
                        tran.Rollback();
                        Helper.Logger.ErrorException("Procedure : " + item["PROCEDURE_NAME"].ToString(), ex);
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
            foreach (var item in ProcedureDs.Tables[0].AsEnumerable().Skip(100).ToList())
            {
                ProcedureDs.Tables[0].Rows.Remove(item);
            }

            ProcedureDs.WriteXml(ProceduresXml);   
            
        }
    }
}