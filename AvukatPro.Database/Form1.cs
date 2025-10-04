using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AvukatPro.Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Helper.Connection.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(txtScript.Text, Helper.Connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Finish Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Helper.Connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Helper.Connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(txtScript.Text, Helper.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                Form2 frm = new Form2(ds);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Helper.Connection.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Helper.ConnectionStr = textBox1.Text;
            Helper.VT = txtVt.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form.CheckForIllegalCrossThreadCalls = false;

            textBox1.Text = Helper.ConnectionStr;
            txtVt.Text = Helper.VT;
        }

        private void foyDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDeleteFoy frm = new FrmDeleteFoy();
            frm.ShowDialog();
        }

        private void proceduresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProcedures frm = new frmProcedures();
            frm.ShowDialog();
        }

        private void tablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTables frm = new frmTables();
            frm.ShowDialog();
        }

        private void updateDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDb frm = new UpdateDb();
            frm.ShowDialog();
        }

        private void viewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViews frm = new frmViews();
            frm.ShowDialog();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control)
        && e.KeyChar == 1)
            {
                databaseToolStripMenuItem.Visible = true;
            }

        }

        private void cetDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frpCetData frm = new frpCetData();
            frm.ShowDialog();
        }
    }
}