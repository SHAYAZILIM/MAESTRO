using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AvukatPro.Database
{
    public partial class frpCetData : Form
    {
        public frpCetData()
        {
            InitializeComponent();
        }
        public List<CetKodTable> Tables { get; set; }
        public DataSet TableDatas { get; set; }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            Tables = CetKodTable.GetTables(Application.StartupPath + @"\tableList.xml");
            cetKodTableBindingSource.DataSource = Tables;
            TableDatas = new DataSet();
            //if (File.Exists(Application.StartupPath + @"\tableListData.xml"))
            //    try
            //    {
            //        System.IO.StreamReader sr = new System.IO.StreamReader(Application.StartupPath + @"\tableListData.xml", Encoding.GetEncoding("ISO-8859-9"));
            //        TableDatas.ReadXml(sr);
            //        sr.Close();
            //    }
            //    catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CetKodTable.SaveTables(Application.StartupPath + @"\tableList.xml", Tables);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cetKodTableBindingSource.Current != null)
            {
                cetKodTableBindingSource.Remove(cetKodTableBindingSource.Current);
                //Tables.Remove(cetKodTableBindingSource.Current as CetKodTable);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableDatas = new DataSet();
            Helper.Connection.Open();
            foreach (var item in Tables)
            {
                var sqlscript = string.Format("Select * from {0}", item.Name);

                CetKodTableColumn identityColumn = item.Columns.Where(q => q.IsIdentity).FirstOrDefault();
                if (identityColumn != null)
                {
                    sqlscript += string.Format(" {0} {1} < 10000", "WHERE", identityColumn.Name);
                }
                try
                {

                    SqlCommand cmdcreate = new SqlCommand(sqlscript, Helper.Connection);

                    SqlDataAdapter adpcreate = new SqlDataAdapter(cmdcreate);
                    DataTable dsvc = new DataTable(item.Name);
                    adpcreate.Fill(dsvc);
                    TableDatas.Tables.Add(dsvc);
                }
                catch { }
                finally
                {
                }
            }
            Helper.Connection.Close();
            string filename = Application.StartupPath + @"\tableListData.xml";
            if (File.Exists(filename))
                File.Delete(filename);
            TableDatas.WriteXml(filename);
        }

        private void btnDataGrid_Click(object sender, EventArgs e)
        {
            if (cetKodTableBindingSource.Current != null)
            {
                CetKodTable item = cetKodTableBindingSource.Current as CetKodTable;
                frmCetDataGrid frmGrid = new frmCetDataGrid();
                frmGrid.DataTable = TableDatas.Tables[item.Name];
                frmGrid.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cetKodTableBindingSource.DataSource != null)
            {
                frmCetDbTableSelect frmGrid = new frmCetDbTableSelect();
                frmGrid.SelectedTables = (List<CetKodTable>)cetKodTableBindingSource.DataSource;
                var dr = frmGrid.ShowDialog();
                if (dr == DialogResult.OK)
                    Tables = frmGrid.SelectedTables;
                cetKodTableBindingSource.DataSource = Tables;
            }
            else
            {
                MessageBox.Show("Lütfen Datayý Load ediniz..");
            }
        }
    }
}
