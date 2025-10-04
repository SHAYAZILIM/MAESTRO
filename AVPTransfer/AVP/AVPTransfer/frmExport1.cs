using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using Word = Microsoft.Office.Interop.Word;

namespace AVPTransfer
{
    public partial class frmExport1 : DevExpress.XtraEditors.XtraForm
    {
        #region Fields

        public string logFile = "";

        private int export;
        private string logXml;
        private int notexist;

        #endregion Fields

        #region Constructors

        public frmExport1()
        {
            InitializeComponent();
            panel1.Enabled = false;
        }

        #endregion Constructors

        #region Properties

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

        private string Company
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        private void AppendToXmlFile(Table tbl)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(logXml);
            XmlElement root = doc.DocumentElement;
            XmlElement log = doc.CreateElement("Log");
            log.SetAttribute("table", tbl.Name);
            if (tbl.Log.SqlExList != null && tbl.Log.SqlExList.Count > 0)
            {
                XmlElement det = doc.CreateElement("Detail");
                det.SetAttribute("type", "sql");
                foreach (KeyValuePair<int, Item> itm in tbl.Log.SqlExList)
                {
                    XmlElement lst = doc.CreateElement("List");
                    lst.SetAttribute("Code", itm.Key.ToString());
                    lst.SetAttribute("Count", itm.Value.Count.ToString());
                    if (!string.IsNullOrEmpty(itm.Value.PKs)) lst.SetAttribute("Pks", itm.Value.PKs.ToString());
                    XmlCDataSection msgCdata = doc.CreateCDataSection(itm.Value.Text);
                    lst.AppendChild(msgCdata);
                    det.AppendChild(lst);
                }
                log.AppendChild(det);
            }

            if (tbl.Log.ExList != null && tbl.Log.ExList.Count > 0)
            {
                XmlElement det = doc.CreateElement("Detail");
                det.SetAttribute("type", "ex");
                foreach (KeyValuePair<string, int> itm in tbl.Log.ExList)
                {
                    XmlElement lst = doc.CreateElement("List");
                    lst.SetAttribute("Count", itm.Value.ToString());
                    XmlCDataSection msgCdata = doc.CreateCDataSection(itm.Key);
                    lst.AppendChild(msgCdata);
                    det.AppendChild(lst);
                }
                log.AppendChild(det);
            }

            root.InsertAfter(log, root.LastChild);
            doc.Save(logXml);

            root = null;
            doc = null;
        }

        private void AppendToXmlFile(string TableName, Exception Message, string CommandText)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(logXml);
            XmlElement root = doc.DocumentElement;
            XmlElement log = doc.CreateElement("Log");
            log.SetAttribute("table", TableName);

            XmlElement det = doc.CreateElement("Detail");
            det.SetAttribute("type", "sql");

            XmlElement lst = doc.CreateElement("List");
            lst.SetAttribute("Count", "1");
            XmlCDataSection msgCdata;
            if (string.IsNullOrEmpty(CommandText))
                msgCdata = doc.CreateCDataSection(Message.Message);
            else
                msgCdata = doc.CreateCDataSection(string.Format("{0}<br/>{1}", Message.Message, CommandText));

            lst.AppendChild(msgCdata);
            det.AppendChild(lst);

            log.AppendChild(det);

            root.InsertAfter(log, root.LastChild);
            doc.Save(logXml);

            root = null;
            doc = null;
        }

        private void bgWorkerTransfer_DoWork(object sender, DoWorkEventArgs e)
        {
            ExportData();
        }

        private void bgWorkerTransfer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is Log)
            {
                Log log = e.UserState as Log;
                if (String.IsNullOrEmpty(log.FileName)) Utility.AppendLogMessage(log.richTb, log.Message, log.Color, log.EnableLog);
                else Utility.AppendLogMessage(log.richTb, log.Message, log.Color, log.FileName, log.EnableLog);
            }
        }

        private void bgWorkerTransfer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panel1.Enabled = true;
            MessageBox.Show("Aktarım işlemi başarıyla tamamlandı.\r\nİşlem esnasında oluşan logları istediğiniz formatta kaydedebilirsiniz.");
            try
            {
                SaveWord(String.Format("{0}docx", logXml.Remove(logXml.Length - 3)));
            }
            catch (Exception)
            {
            }
        }

        private void btnSaveCsv_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.csv|*.csv";

            FileInfo fInf = new FileInfo(logXml);
            sfd.InitialDirectory = fInf.Directory.FullName;
            sfd.FileName = fInf.Name.Remove(fInf.Name.Length - 3) + "csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                rtbLog.SaveFile(sfd.FileName);
                MessageBox.Show("Belge başarıyla kaydedildi");
            }
        }

        private void btnSaveText_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.txt|*.txt";

            FileInfo fInf = new FileInfo(logXml);
            sfd.InitialDirectory = fInf.Directory.FullName;
            sfd.FileName = fInf.Name.Remove(fInf.Name.Length - 3) + "txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                rtbLog.SaveFile(sfd.FileName);
                MessageBox.Show("Belge başarıyla kaydedildi");
            }
        }

        private void btnSaveWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.docx|*.docx";

            FileInfo fInf = new FileInfo(logXml);
            sfd.InitialDirectory = fInf.Directory.FullName;
            sfd.FileName = fInf.Name.Remove(fInf.Name.Length - 3) + "docx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveWord(sfd.FileName);
            }
        }

        private void btnShowLog_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(logXml);
        }

        private void ClearDublicate(SqlConnection destination, KeyValuePair<string, ColumnCollection> unique)
        {
            string TableName = unique.Value[0].Parent.Name;
            string PKName = unique.Value[0].Parent.Pks[0].Name;

            if (destination.State == ConnectionState.Closed)
                destination.Open();

            SqlCommand cmdGeneral = destination.CreateCommand();
            cmdGeneral.CommandTimeout = 3600;
            cmdGeneral.CommandText = string.Format("Select {0},{1} from {2} order by {1},{0}", PKName, string.Join(",", unique.Value.ToArray()), TableName);

            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmdGeneral))
                {
                    da.Fill(dt);
                }
                //Birden fazla alanında primary key olan bir tablo başka bir tabloya parent olamaz.
                //Dolayısıyla direk olarak sıfırıncı pk'i ayabiliriz.
                cmdGeneral.CommandText = string.Format("Delete {0} where {1}=@{1}", TableName, PKName);
                List<SqlCommand> UpdateCommands = new List<SqlCommand>();
                using (SqlDataAdapter da = new SqlDataAdapter(string.Format("select object_name(fkeyid) TableName,col_name(fkeyid,fkey) ColName from sysforeignkeys where rkeyid={0}", unique.Value[0].Parent.ID), destination))
                {
                    using (DataTable dtRel = new DataTable())
                    {
                        da.Fill(dtRel);
                        SqlCommand cmd;
                        foreach (DataRow rel in dtRel.Rows)
                        {
                            cmd = destination.CreateCommand();
                            cmd.CommandText = string.Format("Update {0} set {1}=@New where {1}=@Old", rel["TableName"], rel["ColName"]);
                            UpdateCommands.Add(cmd);
                        }
                    }
                }
                int cDublicate = 0;
                int cDeleted = 0;
                string Pks = "";
                for (int i = dt.Rows.Count - 1; i > 0; i--)
                {
                    bool equal = true;
                    cmdGeneral.Parameters.Clear();
                    foreach (Column uCol in unique.Value)
                        if (dt.Rows[i][uCol.Name].ToString().Trim() != dt.Rows[i - 1][uCol.Name].ToString().Trim())
                        {
                            equal = false;
                            continue;
                        }
                    if (equal)
                    {
                        SqlCommand cmd = null;
                        try
                        {
                            for (int j = 0; j < UpdateCommands.Count; j++)
                            {
                                cmd = UpdateCommands[j];
                                cmd.Parameters.AddWithValue("@New", dt.Rows[i - 1][PKName]);
                                cmd.Parameters.AddWithValue("@Old", dt.Rows[i][PKName]);
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }
                        }
                        catch (SqlException ex)
                        {
                            bgWorkerTransfer.ReportProgress(0, new Log(rtbLog, string.Format("Command : {0} Hata : {1}", cmd.CommandText, ex.Message), Color.Red, logFile, true));
                        }

                        cDublicate++;
                        cmdGeneral.Parameters.AddWithValue(PKName, dt.Rows[i][PKName]);
                        Pks += String.Format("{0},", dt.Rows[i][PKName]);
                        try
                        {
                            if (cmdGeneral.ExecuteNonQuery() == 1)
                            {
                                dt.Rows.RemoveAt(i);
                                cDeleted++;
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                cmdGeneral.Parameters.Clear();
                cmdGeneral.CommandText = string.Format("ALTER INDEX {0} ON {1} REBUILD", unique.Key, TableName);
                ExecuteCommand(null, cmdGeneral);
                bgWorkerTransfer.ReportProgress(0, new Log(rtbLog, string.Format("{0} - {1};  Silinecek tekrar sayısı : {2} ; Silinen satır sayısı : {3} ; \nPK Listesi:{4}", TableName, string.Join(",", unique.Value.ToArray()), cDublicate, cDeleted, Pks), (cDublicate > cDeleted ? Color.Red : Color.Green), logFile, true));
            }
        }

        private void DataTableFillException(Table tbl, DataTable Export, DataTable Except, Exception ex, string CommandText)
        {
            bgWorkerTransfer.ReportProgress(0, new Log(rtbLog, string.Format("{0} - {1}; Hata:{2}", export, tbl.Name, ex.Message), Color.Red, logFile, true));
            AppendToXmlFile(tbl.Name, ex, CommandText);
            FinishExport(tbl, Export, Except, false);
        }

        private int ExecuteCommand(Table tSource, SqlCommand cmd)
        {
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sEx)
            {
                if (tSource != null)
                {
                    if (tSource.Log == null) tSource.Log = new LogInfo();
                    Item item = null;
                    if (tSource.Log.SqlExList.TryGetValue(sEx.Number, out item))
                        item.Count += 1;
                    else
                        tSource.Log.SqlExList.Add(sEx.Number, new Item(sEx.Message, 1));
                }
            }
            return 0;
        }

        private int ExecuteConstraintEnableCommand(Table tSource, Table tDest, SqlCommand cmdGeneral, KeyValuePair<string, ColumnCollection> dRel)
        {
            Item item = null;
            try
            {
                cmdGeneral.CommandText = string.Format("ALTER INDEX {0} ON {1} REBUILD", dRel.Key, tDest.Name);
                return cmdGeneral.ExecuteNonQuery();
            }
            catch (SqlException sEx)
            {
                if (sEx.Number == 1505)
                    Utility.DublicateUniqueList.Add(dRel);
                else
                {
                    if (tSource.Log.SqlExList.TryGetValue(sEx.Number, out item))
                        item.Count += 1;
                    else
                        tSource.Log.SqlExList.Add(sEx.Number, new Item(sEx.Message, 1));
                }
            }
            return 0;
        }

        private void ExportData()
        {
            Completed = false;
            int count = 0;
            FileInfo logFile = new FileInfo(Path.Combine(Application.StartupPath, String.Format(@"Log\{0:yyyyMMdd_HHmmss}.txt", DateTime.Now)));
            logXml = Path.Combine(Application.StartupPath, String.Format(@"Log\{0:yyyyMMdd_HHmmss}.xml", DateTime.Now));

            if (!Directory.Exists(logFile.Directory.FullName))
                Directory.CreateDirectory(logFile.Directory.FullName);

            if (!File.Exists(logXml))
            {
                using (XmlTextWriter xtr = new XmlTextWriter(logXml, Encoding.UTF8))
                {
                    xtr.WriteStartDocument();
                    //xtr.WriteProcessingInstruction("xml-stylesheet", "type='text/xsl' href='" + @"debuglog.xsl" + "'");
                    xtr.WriteStartElement("Logs");
                    if (SourceConnection != null && DestinationConnection != null)
                    {
                        xtr.WriteAttributeString("SourceServer", SourceConnection.DataSource);
                        xtr.WriteAttributeString("SourceDB", SourceConnection.Database);
                        xtr.WriteAttributeString("DestinationServer", DestinationConnection.DataSource);
                        xtr.WriteAttributeString("DestinationDB", DestinationConnection.Database);
                    }
                    xtr.WriteEndElement();
                }
            }

            lblLogXml.Text = logXml;
            if (SourceConnection == null || DestinationConnection == null) return;

            using (SourceConnection)
            {
                SourceConnection.Open();
                SqlCommand cmd = SourceConnection.CreateCommand();
                cmd.CommandText = string.Format("SELECT 'AV' + TABLO_KODU FROM TA_BIL_FIRMA WHERE ID = {0}", CompanyID);
                Company = cmd.ExecuteScalar().ToString();
                if (string.IsNullOrEmpty(Company))
                    return;

                using (DestinationConnection)
                {
                    DestinationConnection.Open();
                    bgWorkerTransfer.ReportProgress(0, new Log(rtbLog, "Başlangıç", null, null, true));
                    //bgWorkerTransfer.ReportProgress(0, new Log(rtbLog, "Başlangıç", null, true);
                    //bgWorkerTransfer.ReportProgress(0, new Log(rtbLog, string.Format("Kaynak Server : {0} ; Kaynak DB : {1} ; Hedef Server : {2} ; Hedef DB : {3}", SourceConnection.DataSource, SourceConnection.Database, DestinationConnection.DataSource, DestinationConnection.Database), null, true);
                    if (!string.IsNullOrEmpty(ExportOnlyOneTable))
                    {
                        int tIndex = Utility.tblSource.IndexOf(new Table(ExportOnlyOneTable));
                        if (tIndex > -1)
                            InsertTableData(SourceConnection, DestinationConnection, Utility.tblSource[tIndex], false);
                        return;
                    }
                    foreach (Table tbl in Utility.tblSource)
                    {
                        ExportTable(SourceConnection, DestinationConnection, tbl);
                        count++;
                    }
                    bgWorkerTransfer.ReportProgress(0, new Log(rtbLog, "Data aktarımı tamamlandı. Unique tekleştirme başladı", null, null, true));

                    foreach (KeyValuePair<string, ColumnCollection> unique in Utility.DublicateUniqueList)
                    {
                        ClearDublicate(DestinationConnection, unique);
                    }

                    if (NotExportImage)
                        bgWorkerTransfer.ReportProgress(0, new Log(rtbLog, "Unique tekleştirme tamamlandı", null, null, true));
                    else
                    {
                        bgWorkerTransfer.ReportProgress(0, new Log(rtbLog, "Unique tekleştirme tamamlandı. Image alanların aktarımına başlandı", null, null, true));
                        foreach (Column col in Utility.updateList)
                        {
                            UpdateImageField(SourceConnection, DestinationConnection, col);
                        }
                    }
                    Utility.ExecutePostScript(DestinationConnection, rtbLog);

                    bgWorkerTransfer.ReportProgress(0, new Log(rtbLog, "Bitiş", null, null, true));
                }
            }
            Completed = true;
        }

        private void ExportTable(SqlConnection source, SqlConnection destination, Table tSource)
        {
            try
            {
                if (tSource.Relationtype == RelationType.Bulunmuyor || tSource.Exporttype == ExportType.Aktarılmayacak)
                {
                    notexist++;
                    return;
                }

                if (tSource.ParentTables != null)
                {
                    foreach (Table cTbl in tSource.ParentTables)
                    {
                        if (!cTbl.Exported || cTbl.Exporttype != ExportType.Aktarılmayacak)
                            ExportTable(source, destination, cTbl);
                    }
                }

                if (!tSource.Exported) InsertTableData(source, destination, tSource, false);
            }
            catch (Exception ex)
            {
                bgWorkerTransfer.ReportProgress(0, new Log(rtbLog, ex.Message, Color.Red, null, true));
                throw;
            }
        }

        private void FilterExistingPks(Table tbl, DataTable Expect, DataTable Export)
        {
            bool Exist;
            foreach (DataRow dr in Expect.Rows)
            {
                for (int i = 0; i < Export.Rows.Count; i++)
                {
                    Exist = true;
                    foreach (Column pk in tbl.Pks)
                    {
                        if (dr[pk.Name].ToString() != Export.Rows[i][pk.Name].ToString())
                        {
                            Exist = false;
                            break;
                        }
                    }
                    if (Exist)
                    {
                        Export.Rows.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private void FinishExport(Table tbl, DataTable Export, DataTable Except, bool WriteExportLog)
        {
            if (WriteExportLog)
                bgWorkerTransfer.ReportProgress(0, new Log(rtbLog, string.Format("{0} - {1};  Aktarılacak satır sayısı : {2} ; Aktarılan satır sayısı : {3}; Aktarım Türü : {4}", export, tbl.Name, Export.Rows.Count, Export.Rows.Count - tbl.Log.ExCount, tbl.Exporttype), (tbl.Log.ExCount > 0 ? Color.Red : Color.Green), logFile, true));

            if (tbl.Log != null && (tbl.Log.ExCount > 0 || tbl.Log.SqlExList.Count > 0 || tbl.Log.ExList.Count > 0))
            {
                AppendToXmlFile(tbl);
                tbl.Log = null;
            }

            tbl.Exported = true;

            if (Export != null)
            {
                Export.Rows.Clear();
                Export.Dispose();
            }
            if (Except != null)
            {
                Except.Rows.Clear();
                Except.Dispose();
            }
        }

        private void frmExport_Load(object sender, EventArgs e)
        {
            this.Show();
            bgWorkerTransfer.RunWorkerAsync();
        }

        private void InsertTableData(SqlConnection connSource, SqlConnection connDest, Table tSource, bool RunAppendCommand)
        {
            export++;
            List<string> sColumns = new List<string>(); List<string> dColumns;
            Dictionary<string, List<string>> relation = new Dictionary<string, List<string>>();
            SqlCommand cmdGeneral = connDest.CreateCommand(); ;
            cmdGeneral.CommandTimeout = 3600;

            //Eðer aktarýlacak tablo tek tablo ile iliþkili ise bu durumda karþý taraftaki tablonun primary key alanlarý bilinmeli.
            //Bu nedenle hedef tablo bir deðiþkende tutuluyor.
            Table tDest = null;

            /* Bir tablo insert edilirken veri birden fazla tabloya aktarýlýyor olabilir.
             * Bu durumda her satýr için birden fazla insert cümleciði çalýþtýrmak gerekir.
             * Satýr için çalýþtýrýlacak sql command parametreleriyle birlikte önceden hazýrlanýyor. */
            foreach (Column col in tSource.ColumnList)
            {
                if (col.RelationWith != null)
                {
                    //Xml de ön tanımlı olan parametrelere göre select cümleciği oluşturuluyor
                    if (!string.IsNullOrEmpty(col.Convert))
                        sColumns.Add(string.Format("{0} as {1}", ReplaceCompanyName(col.Convert), col.Name));
                    else if (!string.IsNullOrEmpty(col.Coalesce))
                        sColumns.Add(string.Format("COALESCE({0}) {1}", ReplaceCompanyName(col.Coalesce), col.Name));
                    else if (!string.IsNullOrEmpty(col.DataType) && col.DataType == "image")
                    {//Eğer alanın veri tipi image ise bu durumda insert den çıkarılarak update edilecek
                        Utility.updateList.Add(col);
                        continue;
                    }
                    else
                        sColumns.Add(col.Name);

                    if (relation.TryGetValue(col.RelationWith.Parent.Name, out dColumns))
                        dColumns.Add(col.RelationWith.Name);
                    else
                    {
                        dColumns = new List<string>();
                        dColumns.Add(col.RelationWith.Name);
                        relation.Add(col.RelationWith.Parent.Name, dColumns);
                        tDest = col.RelationWith.Parent;
                    }
                }
            }

            DataTable dtExport = new DataTable(); DataTable dtExcept = null;

            //Eğer data append edilecekse
            SqlCommand cmd;
            if (RunAppendCommand)
            {
                cmd = connSource.CreateCommand();
                cmd.CommandText = ReplaceCompanyName(tSource.AppendCommandText);
                cmd.CommandTimeout = 3600;
                try
                {
                    using (SqlDataAdapter daExport = new SqlDataAdapter(cmd))
                    {
                        daExport.Fill(dtExport);
                    }
                }
                catch (Exception ex)
                {
                    DataTableFillException(tSource, dtExport, dtExcept, ex, cmd.CommandText);
                    return;
                }
            }
            else if (tSource.Exporttype == ExportType.Farklar)
            {
                if (tDest.Pks.Count > 1)
                {
                    dtExcept = new DataTable();
                    //Export edilecek data veri tabanýndan çekiliyor.
                    cmd = connSource.CreateCommand();
                    cmd.CommandText = string.Format("Select {0} from {1} order by {2}", string.Join(",", sColumns.ToArray()), ReplaceCompanyName(tSource.Name), string.Join(",", tSource.Pks.ToArray()));
                    cmd.CommandTimeout = 3600;
                    try
                    {
                        using (SqlDataAdapter daExport = new SqlDataAdapter(cmd))
                        {
                            daExport.Fill(dtExport);
                        }
                    }
                    catch (Exception ex)
                    {
                        DataTableFillException(tSource, dtExport, dtExcept, ex, cmd.CommandText);
                        return;
                    }
                    if (tSource.Exporttype == ExportType.Farklar)
                    {
                        //Hedef tabloda bulunan deðerler yeniden transfer edilmesin diye primary key deðerleri çekiliyor.
                        cmd = connDest.CreateCommand();
                        cmd.CommandText = string.Format("Select {0} from {1}", string.Join(",", tDest.Pks.ToArray()), tDest.Name);
                        cmd.CommandTimeout = 3600;
                        try
                        {
                            using (SqlDataAdapter daExcept = new SqlDataAdapter(cmd))
                            {
                                daExcept.Fill(dtExcept);
                            }
                        }
                        catch (Exception ex)
                        {
                            DataTableFillException(tSource, dtExport, dtExcept, ex, cmd.CommandText);
                            return;
                        }
                        //Eðer sadece farklar export edilecek ise FilterExistingPks metodu ile karþý tarafta var olan kayýtlar çýkarýlýyor
                        FilterExistingPks(tSource, dtExcept, dtExport);
                    }
                }
                else
                {
                    //Export edilecek data veri tabanýndan çekiliyor.
                    cmd = connSource.CreateCommand();
                    cmd.CommandText = string.Format("Select {0} from {1} where {2} not in (Select {3} from  {4}..{5}) order by {2}", string.Join(",", sColumns.ToArray()), ReplaceCompanyName(tSource.Name), tSource.Pks[0].Name, tDest.Pks[0], connDest.Database, tDest.Name);
                    cmd.CommandTimeout = 3600;
                    try
                    {
                        using (SqlDataAdapter daExport = new SqlDataAdapter(cmd))
                        {
                            daExport.Fill(dtExport);
                        }
                    }
                    catch (Exception ex)
                    {
                        DataTableFillException(tSource, dtExport, dtExcept, ex, cmd.CommandText);
                        return;
                    }
                }
            }
            else if (tSource.Virtual) //Aslında eski veri tabanında olmayan bizim xml de tanımladığımız tablolar
            {
                cmd = connSource.CreateCommand();
                cmd.CommandText = ReplaceCompanyName(tSource.CommandText);
                cmd.CommandTimeout = 3600;
                try
                {
                    using (SqlDataAdapter daExport = new SqlDataAdapter(cmd))
                    {
                        daExport.Fill(dtExport);
                    }
                }
                catch (Exception ex)
                {
                    DataTableFillException(tSource, dtExport, dtExcept, ex, cmd.CommandText);
                    return;
                }
            }
            else //Datanın tamamı aktarılacak
            {
                //Export edilecek data veri tabanýndan çekiliyor.
                cmd = connSource.CreateCommand();
                cmd.CommandText = string.Format("Select {0} from {1} order by {2}", string.Join(",", sColumns.ToArray()), ReplaceCompanyName(tSource.Name), string.Join(",", tSource.Pks.ToArray()));
                cmd.CommandTimeout = 3600;
                try
                {
                    using (SqlDataAdapter daExport = new SqlDataAdapter(cmd))
                    {
                        daExport.Fill(dtExport);
                    }
                }
                catch (Exception ex)
                {
                    DataTableFillException(tSource, dtExport, dtExcept, ex, cmd.CommandText);
                    return;
                }
            }
            tSource.Log = new LogInfo();

            //Eðer export edilecek data bulunmuyor sa bu durumda bir sonra ki tabloya geçilebilir.
            if (dtExport.Rows.Count == 0)
            {
                FinishExport(tSource, dtExport, dtExcept, true);
                //Eğer append command'ı dolu ise ve append command'ı çalıştıırlmamış ise
                if (!string.IsNullOrEmpty(tSource.AppendCommandText) && !RunAppendCommand)
                    InsertTableData(connSource, connDest, tSource, true);

                return;
            }

            foreach (Column col in tDest.ColumnList)
            {
                //Eğer kaynak kolon boş geçilebiliyor ancak hedef geçilemiyorsa bu durumda alan boş geçişe müsade edecek şekilde değiştirilecek
                if ((col.RelationWith == null && !col.AllowNull) || (!col.AllowNull && col.RelationWith.AllowNull) || (!col.AllowNull && col.DataType == "image"))
                {
                    if (col.DataType.ToLower().IndexOf("char") > 0)
                        cmdGeneral.CommandText = string.Format("ALTER TABLE {0} ALTER COLUMN {1} {2} ({3}) NULL", col.Parent.Name, col.Name, col.DataType, col.Length);
                    else
                        cmdGeneral.CommandText = string.Format("ALTER TABLE {0} ALTER COLUMN {1} {2} NULL", col.Parent.Name, col.Name, col.DataType);

                    ExecuteCommand(tSource, cmdGeneral);
                }
            }

            Dictionary<string, SqlCommand> CommandList = new Dictionary<string, SqlCommand>();
            //Eğer aktarılacak tabloda unique un disable edilmesi isteniyorsa bu durumda önce bu yapılacak
            if (tDest.UniqueList != null)
            {
                foreach (KeyValuePair<string, ColumnCollection> dRel in tDest.UniqueList)
                {
                    cmdGeneral.CommandText = string.Format("ALTER INDEX {0} ON {1} DISABLE ", dRel.Key, tDest.Name);
                    cmdGeneral.ExecuteNonQuery();
                }
            }

            if (tDest.DisabledRelationList != null)
            {
                foreach (string dRel in tDest.DisabledRelationList)
                {
                    cmdGeneral.CommandText = string.Format("ALTER TABLE {1} with check nocheck constraint {0}", dRel, tDest.Name);
                    cmdGeneral.ExecuteNonQuery();
                }
            }

            string CommandText = "";
            //Eðer tek bir tabloya aktarým yapýlacak ise bu durumda identity insert ilk anda açýlýp tüm transferden sonra
            //kapatýlabilir. Aksi halde her row için yeniden açýlýp kapanmasý gerekecek.
            if (relation.Count == 1 || !tDest.IdentityExist)
                CommandText = "Insert Into {0} ({1}) values (@{2})";
            else
                CommandText = "SET IDENTITY_INSERT {0} ON Insert Into {0} ({1}) values (@{2}) SET IDENTITY_INSERT {0} OFF";

            foreach (KeyValuePair<string, List<string>> itm in relation)
            {
                CommandList.Add(itm.Key, new SqlCommand(string.Format(CommandText, itm.Key, string.Join(",", itm.Value.ToArray()), string.Join(",@", itm.Value.ToArray())), connDest));
            }

            SqlCommand cmdIdentity = connDest.CreateCommand();
            cmdIdentity.CommandTimeout = 3600;

            //Relation deðerinin 1 olmasý mevcut tablonun karþýda tek tabloya gideceði anlamýna gelir.
            //Dolayýsýyla Identity_Insert Insert iþlemine baþlamadan çalýþtýrýlacak
            if (relation.Count == 1 && tDest.IdentityExist)
            {
                cmdIdentity.CommandText = string.Format("SET IDENTITY_INSERT {0} ON", tDest.Name);
                cmdIdentity.ExecuteNonQuery();
            }

            Item item = null;
            foreach (DataRow dr in dtExport.Rows)
            {
                foreach (KeyValuePair<string, SqlCommand> command in CommandList)
                {
                    command.Value.Parameters.Clear();
                }
                foreach (Column col in tSource.ColumnList)
                {
                    try
                    {
                        if (col.RelationWith == null)
                            continue;
                        if (col.DataType != "image")
                            CommandList[col.RelationWith.Parent.Name].Parameters.AddWithValue(col.RelationWith.Name, dr[col.Name]);
                    }
                    catch (SqlException sEx)
                    {
                        if (tSource.Log.SqlExList.TryGetValue(sEx.Number, out item))
                        {
                            item.Count += 1;
                        }
                        else
                        {
                            if (tSource.Pks == null || tSource.Pks.Count == 0)
                            {
                                item = new Item(sEx.Message, 1, "[");
                                tSource.Log.SqlExList.Add(sEx.Number, item);
                            }
                            else
                                tSource.Log.SqlExList.Add(sEx.Number, new Item(sEx.Message, 1, dr[tSource.Pks[0].Name].ToString()));
                        }

                        tSource.Log.ExCount++;
                    }
                    catch (Exception ex)
                    {
                        if (tSource.Log.ExList.ContainsKey(ex.Message))
                            tSource.Log.ExList[ex.Message] += 1;
                        else
                            tSource.Log.ExList.Add(ex.Message, 1);
                        tSource.Log.ExCount++;
                    }
                }

                foreach (KeyValuePair<string, SqlCommand> command in CommandList)
                {
                ReRun:
                    try
                    {
                        command.Value.ExecuteNonQuery();
                    }
                    catch (SqlException sEx)
                    {
                        if (connDest.State != ConnectionState.Open)
                        {
                            connDest.Open();
                            goto ReRun;
                        }

                        if (tSource.Log.SqlExList.TryGetValue(sEx.Number, out item))
                        {
                            item.Count += 1;
                            if (tSource.Pks == null || tSource.Pks.Count == 0)
                            {
                                item.PKs += "[";
                                for (int i = 0; i < dr.ItemArray.Length; i++)
                                {
                                    item.PKs += string.Format("{0}, ", dr[i]);
                                }
                                item.PKs = string.Format("{0}], ", item.PKs.Remove(item.PKs.Length - 1));
                            }
                            else
                                item.PKs += string.Format("{0}, ", dr[tSource.Pks[0].Name]);
                        }
                        else
                        {
                            if (tSource.Pks == null || tSource.Pks.Count == 0)
                            {
                                item = new Item(sEx.Message, 1, "[");
                                for (int i = 0; i < dr.ItemArray.Length; i++)
                                {
                                    item.PKs += string.Format("{0}, ", dr[i]);
                                }
                                item.PKs = string.Format("{0}], ", item.PKs.Remove(item.PKs.Length - 1));
                                tSource.Log.SqlExList.Add(sEx.Number, item);
                            }
                            else
                                tSource.Log.SqlExList.Add(sEx.Number, new Item(sEx.Message, 1, dr[tSource.Pks[0].Name].ToString()));
                        }

                        tSource.Log.ExCount++;
                    }
                    catch (Exception ex)
                    {
                        if (tSource.Log.ExList.ContainsKey(ex.Message))
                            tSource.Log.ExList[ex.Message] += 1;
                        else
                            tSource.Log.ExList.Add(ex.Message, 1);
                        tSource.Log.ExCount++;
                    }
                }
            }

            if (relation.Count == 1 && tDest.IdentityExist)
            {
                cmdIdentity.CommandText = string.Format("SET IDENTITY_INSERT {0} OFF", tDest.Name);
                cmdIdentity.ExecuteNonQuery();
            }
            //Unique constraint ler enable ediliyor.
            if (tDest.UniqueList != null)
            {
                foreach (KeyValuePair<string, ColumnCollection> dRel in tDest.UniqueList)
                {
                    ExecuteConstraintEnableCommand(tSource, tDest, cmdGeneral, dRel);
                }
            }

            if (tDest.DisabledRelationList != null)
            {
                foreach (string dRel in tDest.DisabledRelationList)
                {
                    cmdGeneral.CommandText = string.Format("ALTER TABLE {1} with check check constraint {0}", dRel, tDest.Name);
                    ExecuteCommand(tSource, cmdGeneral);
                }
            }

            foreach (Column col in tDest.ColumnList)
            {
                //Eğer kaynak kolon boş geçilebiliyor ancak hedef geçilemiyorsa bu durumda alan boş geçişe müsade edecek şekilde değiştirilecek
                if (((col.RelationWith == null && !col.AllowNull) || !col.AllowNull && col.RelationWith.AllowNull))
                {
                    if (col.DataType.ToLower().IndexOf("char") > 0)
                        cmdGeneral.CommandText = string.Format("ALTER TABLE {0} ALTER COLUMN {1} {2} ({3}) NOT NULL", col.Parent.Name, col.Name, col.DataType, col.Length);
                    else
                        cmdGeneral.CommandText = string.Format("ALTER TABLE {0} ALTER COLUMN {1} {2} NOT NULL", col.Parent.Name, col.Name, col.DataType);

                    ExecuteCommand(tSource, cmdGeneral);
                }
            }

            FinishExport(tSource, dtExport, dtExcept, true);
            //Eğer append command'ı dolu ise ve append command'ı çalıştıırlmamış ise
            if (!string.IsNullOrEmpty(tSource.AppendCommandText) && !RunAppendCommand)
                InsertTableData(connSource, connDest, tSource, true);
        }

        private string ReplaceCompanyName(string CommandText)
        {
            if (Company == "AV001") return CommandText;
            return CommandText.Replace("AV001", Company);
        }

        private void SaveWord(string FileName)
        {
            try
            {
                object oMissing = System.Reflection.Missing.Value;
                object oFalse = false;
                //Start Word and create a new document.
                Word._Application oWord;
                Word._Document oDoc;
                oWord = new Word.Application();
                oWord.Visible = false;
                oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;
                oDoc.PageSetup.TopMargin = 40;
                oDoc.PageSetup.BottomMargin = 40;
                oDoc.PageSetup.LeftMargin = 40;
                oDoc.PageSetup.RightMargin = 40;
                oDoc.PageSetup.PageWidth = oWord.CentimetersToPoints(21);
                oDoc.PageSetup.PageHeight = oWord.CentimetersToPoints((float)29.7);

                rtbLog.SelectAll();
                rtbLog.Copy();

                //Insert a paragraph at the beginning of the document.
                Word.Paragraph oPara1;
                oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara1.Range.Paste();
                oPara1.Range.InsertParagraphAfter();
                Object oSaveAsFile = (Object)FileName;
                oDoc.SaveAs(ref oSaveAsFile, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                oDoc.Close(ref oFalse, ref oMissing, ref oMissing);
                oWord.Quit(ref oMissing, ref oMissing, ref oMissing);
                oWord = null;
                oDoc = null;
                MessageBox.Show("Belge başarıyla word formatında kaydedildi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateImageField(SqlConnection source, SqlConnection destination, Column col)
        {
            if (source.State == ConnectionState.Closed)
                source.Open();
            if (destination.State == ConnectionState.Closed)
                destination.Open();

            SqlCommand cmdUpdate = destination.CreateCommand();
            cmdUpdate.CommandTimeout = 3600;
            cmdUpdate.CommandText = string.Format("Update {0} set {1}=@{1} where {2}=@{2}", col.RelationWith.Parent.Name, col.RelationWith.Name, col.RelationWith.Parent.Pks[0]);

            SqlCommand cmdSelect = source.CreateCommand();
            cmdSelect.CommandText = string.Format("Select {0},{1} from {2}", col.Parent.Pks[0].Name, col.Name, ReplaceCompanyName(col.Parent.Name));

            SqlDataReader dr = cmdSelect.ExecuteReader();
            SqlParameter param;
            int UpdatedRowCount = 0; int TotalRowCount = 0;
            while (dr.Read())
            {
                TotalRowCount++;
                param = new SqlParameter(col.RelationWith.Name, SqlDbType.Image);
                param.Value = dr[col.Name];
                cmdUpdate.Parameters.Add(param);

                cmdUpdate.Parameters.Add(new SqlParameter(col.Parent.Pks[0].Name, dr[col.Parent.Pks[0].Name]));

                UpdatedRowCount += ExecuteCommand(col.Parent, cmdUpdate);
                cmdUpdate.Parameters.Clear();
            }
            dr.Close();
            bgWorkerTransfer.ReportProgress(0, new Log(rtbLog, string.Format("{0} - {1};  Güncellenecek satır sayısı : {2} ; Güncellenen satır sayısı : {3}", col.Parent.Name, col.Name, TotalRowCount, UpdatedRowCount), (TotalRowCount > UpdatedRowCount ? Color.Red : Color.Green), logFile, true));
            if (col.Parent.Log != null && (col.Parent.Log.ExCount > 0 || col.Parent.Log.SqlExList.Count > 0 || col.Parent.Log.ExList.Count > 0))
            {
                AppendToXmlFile(col.Parent);
                col.Parent.Log = null;
            }
        }

        #endregion Methods

        #region Nested Types

        public class Log
        {
            #region Fields

            public Nullable<System.Drawing.Color> Color;
            public bool EnableLog;
            public string FileName;
            public string Message;
            public RichTextBox richTb;

            #endregion Fields

            #region Constructors

            public Log(RichTextBox rtb, string message, Nullable<System.Drawing.Color> color, string fileName, bool enableLog)
            {
                richTb = rtb;
                Color = color;
                Message = message;
                EnableLog = enableLog;
                FileName = fileName;
            }

            #endregion Constructors
        }

        #endregion Nested Types
    }
}