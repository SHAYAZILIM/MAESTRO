using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AVPTransfer
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        #region Fields

        private DataView dvResult;
        private frmExport1 frm = null;

        #endregion Fields

        #region Constructors

        public frmMain()
        {
            InitializeComponent();
            progressBar.Visible = false;
        }

        #endregion Constructors

        #region Methods

        private void bgWorkerCompare_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Compare();
        }

        private void bgWorkerCompare_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
        }

        private void bgWorkerCompare_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            grdMain.DataSource = dvResult;
            btnCheckNull.Enabled = btnColumnList.Enabled = btnDataTypeCheck.Enabled = btnExport.Enabled = btnNewField.Enabled = btnOperator1.Enabled = btnOperator2.Enabled = btnOperator3.Enabled = btnOperator4.Enabled = true;
            progressBar.Visible = false;
        }

        private void btnCheckNull_Click(object sender, EventArgs e)
        {
            frmCheck frm = new frmCheck { SourceConnection = new SqlConnection(txtOldDB.Text), DestinationConnection = new SqlConnection(txtNewDB.Text) };
            frm.ShowDialog();
            frm.Dispose();
        }

        private void btnColumnList_Click(object sender, EventArgs e)
        {
            GenerateColumnList frm = new GenerateColumnList();
            frm.SourceConnection = new SqlConnection(txtOldDB.Text);
            frm.ShowDialog();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;
            bgWorkerCompare.RunWorkerAsync();
        }

        private void btnCompareAndExport_Click(object sender, EventArgs e)
        {
            btnCompare.PerformClick();
            btnExport.PerformClick();
        }

        private void btnDataTypeCheck_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.csv|*.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string FileName = sfd.FileName;
                using (System.IO.StreamWriter sr = new System.IO.StreamWriter(FileName, true, System.Text.Encoding.UTF8))
                {
                    foreach (Table tbl in Utility.tblSource)
                    {
                        if (tbl.Relationtype == RelationType.Bulunmuyor || tbl.Exporttype == ExportType.Aktarılmayacak) continue;

                        foreach (Column col in tbl.ColumnList)
                        {
                            if (col.RelationWith == null)
                                continue;

                            if (col.DataType != col.RelationWith.DataType || col.Length != col.RelationWith.Length)
                                if (!((col.DataType == "tinyint" && col.RelationWith.DataType == "bit") || (col.DataType == "smalldatetime" && col.RelationWith.DataType == "datetime")))
                                    sr.WriteLine(string.Format("{0};{1};{2};{3};-;{4};{5};{6};{7}", tbl.Name, col.Name, col.DataType, col.Length, col.RelationWith.Parent.Name, col.RelationWith.Name, col.RelationWith.DataType, col.RelationWith.Length));
                        }
                    }
                }
                MessageBox.Show("Tamamlandı");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (frm = new frmExport1 { SourceConnection = new SqlConnection(txtOldDB.Text), DestinationConnection = new SqlConnection(txtNewDB.Text), NotExportImage = chkNotExportImage.Checked, CompanyID = (int)numCompany.Value })
            {
                if (!string.IsNullOrEmpty(txtExportSingleTable.Text.Trim()))
                    frm.ExportOnlyOneTable = txtExportSingleTable.Text.Trim();

                frm.ShowDialog();
            }
        }

        private void btnNewField_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.csv|*.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string FileName = sfd.FileName;
                using (System.IO.StreamWriter sr = new System.IO.StreamWriter(FileName, true, System.Text.Encoding.UTF8))
                {
                    foreach (Table tbl in Utility.tblDestination)
                    {
                        if (tbl.Relationtype == RelationType.Bulunmuyor || tbl.Exporttype == ExportType.Aktarılmayacak) continue;

                        foreach (Column col in tbl.ColumnList)
                        {
                            if (col.RelationWith == null)
                                sr.WriteLine(string.Format("{0};{1};{2}", tbl.Name, col.Name, col.DBDefault));
                        }
                    }
                }
                MessageBox.Show("Tamamlandı");
            }
        }

        private void btnOperator_CheckedChanged(object sender, EventArgs e)
        {
            if (dvResult == null)
                return;

            List<string> sb = new List<string>();
            if (btnOperator1.Checked)
                sb.Add(String.Format("Operator = '{0}'", btnOperator1.Text));
            if (btnOperator2.Checked)
                sb.Add(String.Format("Operator = '{0}'", btnOperator2.Text));
            if (btnOperator3.Checked)
                sb.Add(String.Format("Operator = '{0}'", btnOperator3.Text));
            if (btnOperator4.Checked)
                sb.Add(String.Format("Operator = '{0}'", btnOperator4.Text));

            if (sb.Count > 0)
                dvResult.RowFilter = string.Join(" or ", sb.ToArray());
            else
                dvResult.RowFilter = "";
        }

        private void Compare()
        {
            if (!Utility.CheckConnectionString(txtOldDB.Text, txtNewDB.Text))
                return;

            //Tablo listeleri çekliyor.
            Utility.tblSource = Utility.GenerateTableStructure(txtOldDB.Text, true);
            Utility.tblDestination = Utility.GenerateTableStructure(txtNewDB.Text, false);

            //Predefined xml de export edilmesi istenmeyen yada sadece farkların export edilmesi istenen tabloların listesi mevcut
            Utility.ApplyPredefinedExportInfo(Utility.tblSource);

            Table tNew; Table tOld; Table tChild; int iTbl; int iCol;
            Column cNew; Column cOld;
            //Kaynak veri tabanında bulunan tüm tablolar için dolaşılmaya başlanıyor
            for (int i = 0; i < Utility.tblSource.Count; i++)
            {
                tOld = Utility.tblSource[i];
                //Eğer kaynak veri tabanında bulunan bir tablo hedef veri tabanında bulunmuyorsa otomatik olarak çıkılacak
                iTbl = Utility.tblDestination.IndexOf(tOld);
                if (iTbl == -1)
                    continue;

                tNew = Utility.tblDestination[iTbl];

                tOld.Relationtype = RelationType.Esit;
                tNew.Relationtype = RelationType.Esit;

                if (tOld.Exporttype == ExportType.Belirtilmemis)
                    tOld.Exporttype = ExportType.Tumu;

                tNew.Exporttype = tOld.Exporttype;

                for (int j = 0; j < tOld.ColumnList.Count; j++)
                {
                    cOld = tOld.ColumnList[j];
                    iCol = tNew.ColumnList.IndexOf(cOld);
                    if (iCol > -1)
                    {
                        cNew = tNew.ColumnList[iCol];
                        cOld.RelationWith = cNew;
                        cNew.RelationWith = cOld;
                    }
                    else
                    {
                        tOld.Relationtype = RelationType.Farkli;
                        tNew.Relationtype = RelationType.Farkli;
                    }
                }

                if (tNew.MasterDetail)
                {
                    tChild = Utility.tblDestination[Utility.tblDestination.IndexOf(new Table(String.Format("{0}_CHILD", tOld.Name)))];
                    tChild.MasterDetail = true;

                    for (int j = 0; j < tOld.ColumnList.Count; j++)
                    {
                        cOld = tOld.ColumnList[j];
                        iCol = tChild.ColumnList.IndexOf(cOld);
                        if (iCol > -1)
                        {
                            cNew = tChild.ColumnList[iCol];
                            cOld.RelationWith = cNew;
                            cNew.RelationWith = cOld;
                        }
                        else
                        {
                            tOld.Relationtype = RelationType.Farkli;
                            tChild.Relationtype = RelationType.Farkli;
                        }
                    }
                    if (tChild.Relationtype != RelationType.Farkli)
                    {
                        for (int j = 0; j < tChild.ColumnList.Count; j++)
                        {
                            if (tChild.ColumnList[j].RelationWith == null)
                            {
                                tChild.Relationtype = RelationType.Farkli;
                                break;
                            }
                        }
                    }
                }

                if (tNew.Relationtype != RelationType.Farkli)
                {
                    for (int j = 0; j < tNew.ColumnList.Count; j++)
                    {
                        if (tNew.ColumnList[j].RelationWith == null)
                        {
                            tNew.Relationtype = RelationType.Farkli;
                            break;
                        }
                    }
                }
            }

            using (DataTable dtResult = new DataTable())
            {
                dtResult.Columns.Add(new DataColumn("Eski_Tablo", typeof(string)));
                dtResult.Columns.Add(new DataColumn("Export_Turu", typeof(string)));
                dtResult.Columns.Add(new DataColumn("Operator", typeof(string)));
                dtResult.Columns.Add(new DataColumn("Yeni_Tablo", typeof(string)));
                DataRow drResult;
                for (int i = 0; i < Utility.tblDestination.Count; i++)
                {
                    drResult = dtResult.NewRow();
                    tNew = Utility.tblDestination[i];
                    drResult["Yeni_Tablo"] = tNew.Name;

                    switch (tNew.Relationtype)
                    {
                        case RelationType.Bulunmuyor:
                            drResult["Operator"] = "<<--";
                            break;

                        case RelationType.Esit:
                            drResult["Operator"] = "=";
                            break;

                        case RelationType.Farkli:
                            drResult["Operator"] = "!=";
                            break;
                    }

                    if (tNew.Relationtype != RelationType.Bulunmuyor)
                    {
                        if (tNew.MasterDetail)
                            tOld = Utility.tblSource[Utility.tblSource.IndexOf(new Table(tNew.Name.Substring(0, tNew.Name.LastIndexOf('_'))))];
                        else
                            tOld = Utility.tblSource[Utility.tblSource.IndexOf(new Table(tNew.Name))];

                        drResult["Eski_Tablo"] = tOld.Name;
                        drResult["Export_Turu"] = tOld.Exporttype;
                    }

                    dtResult.Rows.Add(drResult);
                }

                for (int i = 0; i < Utility.tblSource.Count; i++)
                {
                    tOld = Utility.tblSource[i];
                    if (tOld.Relationtype == RelationType.Bulunmuyor)
                    {
                        drResult = dtResult.NewRow();
                        drResult["Eski_Tablo"] = tOld.Name;
                        drResult["Operator"] = "-->>";
                        drResult["Export_Turu"] = tOld.Exporttype;
                        dtResult.Rows.Add(drResult);
                    }
                }
                dvResult = dtResult.DefaultView;
                //grdMain.DataSource = dvResult;
                //btnCheckNull.Enabled = btnColumnList.Enabled = btnDataTypeCheck.Enabled = btnExport.Enabled = btnNewField.Enabled = btnOperator1.Enabled = btnOperator2.Enabled = btnOperator3.Enabled = btnOperator4.Enabled = true;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pnlOld.Width = (this.Width - 16) / 2;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Eğer transfer tamamlanmadan form kapanacak olursa log dosyası kaydedilecek
            if (frm != null && !frm.Completed && frm.rtbLog.Text.Length > 0 && frm.logFile.Length > 0)
                frm.rtbLog.SaveFile(frm.logFile);
        }

        private void grdMain_DoubleClick(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)((DevExpress.XtraGrid.Views.Grid.GridView)(grdMain.MainView)).GetFocusedRow();
            bool IsSource = !(drv.Row.ItemArray[0] is DBNull);
            Table SelectedTable = null;
            if (IsSource)
                SelectedTable = Utility.tblSource[Utility.tblSource.IndexOf(new Table(drv.Row["Eski_Tablo"].ToString()))];
            else
                SelectedTable = Utility.tblDestination[Utility.tblDestination.IndexOf(new Table(drv.Row["Yeni_Tablo"].ToString()))];

            frmChild frm = new frmChild { IsSource = IsSource, SelectedTable = SelectedTable };
            frm.ShowDialog();
            frm.Dispose();
        }

        #endregion Methods
    }
}