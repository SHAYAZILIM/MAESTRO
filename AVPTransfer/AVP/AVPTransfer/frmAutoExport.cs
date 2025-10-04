using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AVPTransfer
{
    public partial class frmAutoExport : DevExpress.XtraEditors.XtraForm
    {
        #region Fields

        public string logFile = "";

        private static BackgroundWorker bgWorkerTemp;
        private static int progressValue;

        private bool Connected = false;
        private string destConStr = "";
        private string sourceConStr = "";

        #endregion Fields

        #region Constructors

        public frmAutoExport(string conStr)
        {
            destConStr = conStr;

            using (frmConnect frmCon = new frmConnect())
            {
                if (frmCon.ShowDialog() == DialogResult.OK)
                {
                    sourceConStr = frmCon.SourceConStr;
                    SourceConnection = new SqlConnection(frmCon.SourceConStr);
                    DestinationConnection = new SqlConnection(destConStr);
                    CompanyID = frmCon.Company;
                    Connected = true;
                }
                else this.Close();
            }
            InitializeComponent();
            bgWorkerTemp = bgWorkerCompare;
        }

        #endregion Constructors

        #region Properties

        public static int ProgressValue
        {
            get
            {
                return progressValue;
            }
            set
            {
                progressValue = value;
                bgWorkerTemp.ReportProgress(value);
            }
        }

        public int CompanyID
        {
            get;
            set;
        }

        public bool Completed
        {
            get;
            set;
        }

        public SqlConnection DestinationConnection
        {
            get;
            set;
        }

        public string ExportOnlyOneTable
        {
            get;
            set;
        }

        public bool NotExportImage
        {
            get;
            set;
        }

        public SqlConnection SourceConnection
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        private void bgWorkerCompare_DoWork(object sender, DoWorkEventArgs e)
        {
            Compare();
        }

        private void bgWorkerCompare_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            if (e.UserState != null) labelControl1.Text = e.UserState.ToString();
        }

        private void bgWorkerCompare_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!Connected) this.Close();
            labelControl1.Text = "Data transfer ediliyor...";
            frmExport1 formExport = new frmExport1() { SourceConnection = new SqlConnection(sourceConStr), DestinationConnection = new System.Data.SqlClient.SqlConnection(destConStr), CompanyID = this.CompanyID };
            formExport.Show();
        }

        private void Compare()
        {
            if (!AVPTransfer.Utility.CheckConnectionString(sourceConStr, destConStr))
                return;

            //Tablo listeleri çekliyor.
            bgWorkerCompare.ReportProgress(0, "Kaynak veritabanı için tablo listeleri çekliyor.");
            AVPTransfer.Utility.tblSource = AVPTransfer.Utility.GenerateTableStructure(sourceConStr, true);
            bgWorkerCompare.ReportProgress(0, "Hedef veritabanı için tablo listeleri çekliyor.");
            AVPTransfer.Utility.tblDestination = AVPTransfer.Utility.GenerateTableStructure(destConStr, false);

            //Predefined xml de export edilmesi istenmeyen yada sadece farkların export edilmesi istenen tabloların listesi mevcut
            AVPTransfer.Utility.ApplyPredefinedExportInfo(AVPTransfer.Utility.tblSource);

            Table tNew; Table tOld; Table tChild; int iTbl; int iCol;
            Column cNew; Column cOld;
            //Kaynak veri tabanında bulunan tüm tablolar için dolaşılmaya başlanıyor
            for (int i = 0; i < AVPTransfer.Utility.tblSource.Count; i++)
            {
                tOld = AVPTransfer.Utility.tblSource[i];
                //Eğer kaynak veri tabanında bulunan bir tablo hedef veri tabanında bulunmuyorsa otomatik olarak çıkılacak
                iTbl = AVPTransfer.Utility.tblDestination.IndexOf(tOld);
                if (iTbl == -1)
                    continue;

                tNew = AVPTransfer.Utility.tblDestination[iTbl];

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
                    tChild = AVPTransfer.Utility.tblDestination[AVPTransfer.Utility.tblDestination.IndexOf(new Table(String.Format("{0}_CHILD", tOld.Name)))];
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
                int progress = (i + 1) * 100 / AVPTransfer.Utility.tblSource.Count;
                bgWorkerCompare.ReportProgress(progress, String.Format("Tablolar karşılaştırılıyor... Tablo: {0}", AVPTransfer.Utility.tblSource[i].Name));
            }

            //{
            //    dtResult.Columns.Add(new DataColumn("Eski_Tablo", typeof(string)));
            //    dtResult.Columns.Add(new DataColumn("Export_Turu", typeof(string)));
            //    dtResult.Columns.Add(new DataColumn("Operator", typeof(string)));
            //    dtResult.Columns.Add(new DataColumn("Yeni_Tablo", typeof(string)));
            //    DataRow drResult;
            //    for (int i = 0; i < AVPTransfer.Utility.tblDestination.Count; i++)
            //    {
            //        drResult = dtResult.NewRow();
            //        tNew = AVPTransfer.Utility.tblDestination[i];
            //        drResult["Yeni_Tablo"] = tNew.Name;

            //        switch (tNew.Relationtype)
            //        {
            //            case RelationType.Bulunmuyor:
            //                drResult["Operator"] = "<<--";
            //                break;
            //            case RelationType.Esit:
            //                drResult["Operator"] = "=";
            //                break;
            //            case RelationType.Farkli:
            //                drResult["Operator"] = "!=";
            //                break;
            //        }

            //        if (tNew.Relationtype != RelationType.Bulunmuyor)
            //        {
            //            if (tNew.MasterDetail)
            //                tOld = AVPTransfer.Utility.tblSource[AVPTransfer.Utility.tblSource.IndexOf(new Table(tNew.Name.Substring(0, tNew.Name.LastIndexOf('_'))))];
            //            else
            //                tOld = AVPTransfer.Utility.tblSource[AVPTransfer.Utility.tblSource.IndexOf(new Table(tNew.Name))];

            //            drResult["Eski_Tablo"] = tOld.Name;
            //            drResult["Export_Turu"] = tOld.Exporttype;
            //        }

            //        dtResult.Rows.Add(drResult);

            //    }

            //    for (int i = 0; i < AVPTransfer.Utility.tblSource.Count; i++)
            //    {
            //        tOld = AVPTransfer.Utility.tblSource[i];
            //        if (tOld.Relationtype == RelationType.Bulunmuyor)
            //        {
            //            drResult = dtResult.NewRow();
            //            drResult["Eski_Tablo"] = tOld.Name;
            //            drResult["Operator"] = "-->>";
            //            drResult["Export_Turu"] = tOld.Exporttype;
            //            dtResult.Rows.Add(drResult);
            //        }
            //    }
            //    dvResult = dtResult.DefaultView;
            //grdMain.DataSource = dvResult;
            //btnCheckNull.Enabled = btnColumnList.Enabled = btnDataTypeCheck.Enabled = btnExport.Enabled = btnNewField.Enabled = btnOperator1.Enabled = btnOperator2.Enabled = btnOperator3.Enabled = btnOperator4.Enabled = true;
            //}
        }

        private void frmAutoExport_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("Aktarım işlemi biraz uzun sürebilir.\r\nLütfen bu işlem esnasında Avukatpro Yeni Nesil uygulaması üzerinde işlem yapmayınız.\r\nAksi halde yapılan işlemler data kaybına neden olabilir.");
            bgWorkerCompare.RunWorkerAsync();
        }

        #endregion Methods
    }
}