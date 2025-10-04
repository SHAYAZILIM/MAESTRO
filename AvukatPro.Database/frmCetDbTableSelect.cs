using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AvukatPro.Database
{
    public partial class frmCetDbTableSelect : Form
    {
        public frmCetDbTableSelect()
        {
            InitializeComponent();
        }

        private Microsoft.SqlServer.Management.Smo.Database myDataBase;

        private Server myServer;

        private Scripter scripter;

        public List<CetKodTable> SelectedTables { get; set; }

        public static List<CetKodTable> Tables { get; set; }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            scripter = new Scripter(myServer);
            myDataBase = myServer.Databases[Helper.VT];
            Tables = new List<CetKodTable>();

            var tables = myDataBase.Tables.Cast<Table>().Where(table =>
                table.Name.Contains("_KOD")
                || table.Name.Contains("_CET")
                || table.Name == "AV001_TDIE_BIL_DEGISKEN_ALAN_AYAR"
                || table.Name == "AV001_TDIE_BIL_EDITOR_DEGISKEN_SONUC"
                || table.Name == "AV001_TDIE_BIL_SABLON_RAPOR"
                || table.Name == "AV001_TDIE_BIL_SABLON_DEGISKEN_AYAR"
                || table.Name == "AV001_TDIE_BIL_SABLON_DEGISKEN_DEGER"
                || table.Name == "AV001_TDIE_BIL_SABLON_DEGISKEN_VERI"
                || table.Name == "AV001_TDIE_BIL_SABLON_DEGISKEN_YUKLEME"
                || table.Name == "AV001_TDIE_BIL_SABLON_DEGISKENLER"
                || table.Name == "AV001_TDIE_BIL_SABLON_RAPOR_DEGISKEN"
                || table.Name == "TA_BIL_SPC_MODUL_DEGISKEN"
                || table.Name == "TI_BIL_STANDART_ORNEK_FORM_DEGISKEN"
                || table.Name == "TI_BIL_STANDART_ORNEK_FORM")
                .ToList();

            prgStatus.Maximum = tables.Count();

            foreach (Table table in tables)
            {
                lblInfo.Text = prgStatus.Value.ToString() + "/" + prgStatus.Maximum.ToString() + " " + table.Name;
                backgroundWorker1.ReportProgress(1);
                CetKodTable t = new CetKodTable();
                t.Name = table.Name;
                var selectedTable = SelectedTables.Where(q => q.Name == table.Name).FirstOrDefault();
                t.IsSelected = selectedTable != null;
                foreach (Column item in table.Columns)
                {
                    CetKodTableColumn c = new CetKodTableColumn();
                    c.Name = item.Name;
                    c.DataType = item.DataType.Name;

                    if (selectedTable != null)
                    {
                        var clm = selectedTable.Columns.Where(q => q.Name == c.Name).FirstOrDefault();
                        if (clm != null)
                        {
                            c.IsCondition = clm.IsCondition;
                            c.IsIdentity = clm.IsIdentity;
                            c.IsUpdate = clm.IsUpdate;
                        }
                    }

                    t.Columns.Add(c);
                }
                Tables.Add(t);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prgStatus.Value++;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cetKodTableBindingSource.DataSource = Tables;
            panel1.Enabled = true;
            panel2.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            SelectedTables = Tables.Where(q => q.IsSelected).ToList();
        }

        private void frmCetDbTableSelect_Load(object sender, EventArgs e)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            panel1.Enabled = false;
            panel2.Enabled = false;
            myServer = new Server("denem");
            myServer.ConnectionContext.ConnectionString = Helper.ConnectionStr;

            myServer.ConnectionContext.Connect();
            if (myServer.ConnectionContext.IsOpen)
                myServer.ConnectionContext.Disconnect();

            lblInfo.Text = "Yükleniyor...";
            if (Tables == null)
                backgroundWorker1.RunWorkerAsync();
        }
    }
}