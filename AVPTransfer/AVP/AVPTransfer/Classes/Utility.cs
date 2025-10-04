using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace AVPTransfer
{
    public static class Utility
    {
        #region Fields

        /// <summary>
        /// Key değeri tablo adını, value daki key değeri constraint adını, value daki value ise kolon listesini tutuyor
        /// </summary>
        public static List<KeyValuePair<string, ColumnCollection>> DublicateUniqueList = new List<KeyValuePair<string, ColumnCollection>>();

        public static List<Table> tblDestination = new List<Table>();
        public static List<Table> tblSource = new List<Table>();
        public static List<Column> updateList = new List<Column>();

        #endregion Fields

        #region Methods

        public static void AppendLogMessage(RichTextBox LogMessageControl, string Message, Nullable<System.Drawing.Color> tColor, bool EnableLog)
        {
            AppendLogMessage(LogMessageControl, Message, tColor, null, EnableLog);
        }

        public static void AppendLogMessage(RichTextBox LogMessageControl, string Message, Nullable<System.Drawing.Color> tColor, string filename, bool EnableLog)
        {
            if (LogMessageControl == null) return;

            if (!EnableLog)
            {
                if (!tColor.HasValue || (tColor.HasValue && tColor.Value != System.Drawing.Color.Red)) return;
            }
            Message = string.Format("{0:HH:mm:ss} - {1}", DateTime.Now, Message);
            int ind = LogMessageControl.TextLength;
            LogMessageControl.AppendText(String.Format("{0}\n", Message));

            if (tColor.HasValue)
            {
                LogMessageControl.SelectionStart = ind;
                LogMessageControl.SelectionLength = LogMessageControl.TextLength - ind;
                LogMessageControl.SelectionColor = tColor.Value;
                LogMessageControl.SelectionProtected = true;
            }
            LogMessageControl.SelectionStart = LogMessageControl.TextLength;
            LogMessageControl.SelectionLength = 0;
            LogMessageControl.ScrollToCaret();

            if (!string.IsNullOrEmpty(filename))
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(String.Format("{0}\r\n", Message));
                    fs.Write(info, 0, info.Length);
                    fs.Close();
                }
            }
        }

        public static void ApplyPredefinedExportInfo(List<Table> tblList)
        {
            string file = Path.Combine(Path.Combine(Application.StartupPath, "Scripts"), "PredefinedExport.xml");
            if (File.Exists(file))
            {
                using (XmlTextReader xtr = new XmlTextReader(file))
                {
                    ExportType eType = ExportType.Tumu;
                    int tIndex;
                    while (xtr.Read())
                    {
                        if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "Export")
                            eType = (ExportType)int.Parse(xtr.GetAttribute("type"));

                        if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "Table")
                        {
                            tIndex = tblList.IndexOf(new Table(xtr.GetAttribute("name")));
                            if (tIndex > -1)
                                tblList[tIndex].Exporttype = eType;
                        }
                    }
                }
            }
        }

        public static bool CheckConnectionString(string Source, string Destination)
        {
            using (SqlConnection conn = new SqlConnection(Source))
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                    MessageBox.Show(String.Format("Bağlantı Cümleciği hatalı. Lütfen Kotrol edip tekrar deneyin\n{0}", Source), "AVP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            using (SqlConnection conn = new SqlConnection(Destination))
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                    MessageBox.Show(String.Format("Bağlantı Cümleciği hatalı. Lütfen Kotrol edip tekrar deneyin\n{0}", Destination), "AVP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        public static void ExecutePostScript(SqlConnection destination, RichTextBox rtb)
        {
            string file = Path.Combine(Path.Combine(Application.StartupPath, "Scripts"), "PostScript.xml");
            if (File.Exists(file))
            {
                int cIndex = 1; int result;
                using (XmlTextReader xtr = new XmlTextReader(file))
                {
                    Utility.AppendLogMessage(rtb, "Image Alanlar aktarıldı. Post Script ler çalıştırılıyor", null, true);

                    SqlCommand cmd = destination.CreateCommand();
                    cmd.CommandTimeout = 3600;
                    while (xtr.Read())
                    {
                        if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "Script")
                        {
                            cmd.CommandText = xtr.GetAttribute("commandText");
                            result = cmd.ExecuteNonQuery();
                            Utility.AppendLogMessage(rtb, string.Format("{0} - Sorgudan etkilenen kayıt sayısı: {1}.", cIndex, result), null, true);
                            cIndex += 1;
                        }
                    }
                }
            }
        }

        public static List<Table> GenerateTableStructure(string ConnectionString, bool VirtualMapping)
        {
            try
            {
                List<Table> result = new List<Table>();
                Table tbl;
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    //dt table'ı veri tabanındaki tüm tabloların listesini barındırıyor.
                    DataTable dt = GetData(conn, "select name,object_id id,(select count(parent_object_id) Priority from sys.foreign_keys where parent_object_id=sys.objects.object_id) Priority from sys.objects where type='U' and name not in ('dtproperties','sysdiagrams') order by Priority,name");
                    frmAutoExport.ProgressValue = 10;
                    SqlCommand cmd = conn.CreateCommand(); SqlDataReader sdr;
                    SqlCommand cmdPk = conn.CreateCommand();
                    cmdPk.CommandText = "sp_pkeys";
                    cmdPk.CommandType = CommandType.StoredProcedure;

                    Column colPK;
                    int tIndex = -1; int cIndex = -1; int rIndex = -1;
                    int tempIndex = 1;
                    //Veri tabanında bulunan her bir tablo için ...
                    foreach (DataRow dr in dt.Rows)
                    {
                        frmAutoExport.ProgressValue = 10 + (tempIndex * 40 / dt.Rows.Count);
                        tempIndex++;
                        tbl = new Table(int.Parse(dr["id"].ToString()), dr["name"].ToString(), (int)dr["Priority"]);
                        //Kolon listesi çekilerek kolonlar oluşturuluyor.
                        cmd.CommandText = string.Format("select typ.name type,col.name name,col.isnullable,object_name(frg.rkeyid) RTable,col_name(frg.rkeyid,frg.rkey) RColumn,definition DefaultValue,col.length,col.colstat isidentity  from syscolumns col inner join systypes typ on col.xusertype = typ.xusertype left join sysforeignkeys frg on frg.fkeyid=col.id and frg.fkey = col.colid left join sys.default_constraints  def on def.parent_object_id=col.id and def.parent_column_id=col.colid where col.id={0} order by col.id", tbl.ID);
                        sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            tbl.ColumnList.Add(new Column(sdr["name"].ToString(), sdr["type"].ToString(), (int.Parse(sdr["isnullable"].ToString()) == 0 ? false : true), tbl, sdr["DefaultValue"].ToString(), int.Parse(sdr["length"].ToString())));

                            if (int.Parse(sdr["isidentity"].ToString()) == 1)
                                tbl.IdentityExist = true;
                        }
                        sdr.Close();
                        //Tablonun primary key alanları belirleniyor.
                        cmdPk.Parameters.Add("@table_name", SqlDbType.NVarChar).Value = dr["name"].ToString();
                        sdr = cmdPk.ExecuteReader();
                        if (sdr.HasRows)
                        {
                            tbl.Pks = new ColumnCollection();
                            while (sdr.Read())
                            {
                                colPK = tbl.ColumnList[tbl.ColumnList.IndexOf(new Column(sdr["COLUMN_NAME"].ToString()))];
                                colPK.PrimaryKey = true;
                                tbl.Pks.Add(colPK);
                            }
                        }
                        cmdPk.Parameters.Clear();
                        sdr.Close();

                        //Tablonun unique index listesi oluşturuluyor.
                        cmd.CommandText = string.Format("select name,col_name(object_id,colid) columnname from sys.indexes inner join sys.sysindexkeys on id = object_id and index_id=indid and is_unique = 1 and is_primary_key = 0 where object_id={0}", tbl.ID);
                        sdr = cmd.ExecuteReader();
                        if (sdr.HasRows)
                        {
                            tbl.UniqueList = new Dictionary<string, ColumnCollection>();
                            ColumnCollection colList;
                            while (sdr.Read())
                            {
                                if (tbl.UniqueList.TryGetValue(sdr["name"].ToString(), out colList))
                                    colList.Add(tbl.ColumnList[tbl.ColumnList.IndexOf(new Column(sdr["columnname"].ToString()))]);
                                else
                                {
                                    colList = new ColumnCollection();
                                    colList.Add(tbl.ColumnList[tbl.ColumnList.IndexOf(new Column(sdr["columnname"].ToString()))]);
                                    tbl.UniqueList.Add(sdr["name"].ToString(), colList);
                                }
                            }
                        }
                        sdr.Close();

                        //Tablonun kendine olan ilişkilerinin listesi oluşturuluyor.
                        cmd.CommandText = string.Format("select name from sys.foreign_keys where parent_object_id={0} and parent_object_id=referenced_object_id", tbl.ID);
                        sdr = cmd.ExecuteReader();
                        if (sdr.HasRows)
                        {
                            tbl.DisabledRelationList = new List<string>();
                            while (sdr.Read())
                            {
                                tbl.DisabledRelationList.Add(sdr["name"].ToString());
                            }
                        }
                        sdr.Close();

                        result.Add(tbl);
                    }

                    /*
                     VirtualMapping, Eski veri tabanında olmadığı halde varmış gibi aktarılacak tablolar için kullanılacak.
                     */
                    string file = Path.Combine(Path.Combine(Application.StartupPath, "Scripts"), "VirtualTableMapping.xml");
                    if (VirtualMapping)
                    {
                        if (File.Exists(file))
                        {
                            Column vCol;
                            using (XmlTextReader xtr = new XmlTextReader(file))
                            {
                                while (xtr.Read())
                                {
                                    if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "Table")
                                    {
                                        tIndex = result.IndexOf(new Table(xtr.GetAttribute("name")));
                                        if (tIndex == -1)
                                        {
                                            tbl = new Table(xtr.GetAttribute("name"));
                                            tbl.Virtual = true;
                                            tbl.CommandText = xtr.GetAttribute("commandText");
                                            while (xtr.Read())
                                            {
                                                if (xtr.Name == "Column")
                                                {
                                                    vCol = new Column(xtr.GetAttribute("name"));
                                                    if (xtr.GetAttribute("allownull") != null && xtr.GetAttribute("allownull") == "0")
                                                        vCol.AllowNull = false;
                                                    else
                                                        vCol.AllowNull = true;

                                                    tbl.ColumnList.Add(vCol);

                                                    if (xtr.GetAttribute("primarykey") != null && xtr.GetAttribute("primarykey") == "1")
                                                    {
                                                        vCol.PrimaryKey = true;
                                                        if (tbl.Pks == null)
                                                            tbl.Pks = new ColumnCollection();
                                                        tbl.Pks.Add(vCol);
                                                    }

                                                    if (xtr.GetAttribute("identity") != null && xtr.GetAttribute("identity") == "1")
                                                        tbl.IdentityExist = true;
                                                }
                                                else if (xtr.Name == "Table")
                                                    break;
                                            }
                                            result.Add(tbl);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    frmAutoExport.ProgressValue = 60;
                    /*
                     Tablolar için veri tabanında tanımlı olan parent tablolarının listesi oluşturuluyor.
                     */
                    tempIndex = 1;
                    foreach (Table rTbl in result)
                    {
                        dt = GetData(conn, string.Format("select distinct object_name(referenced_object_id) Parent from sys.foreign_keys where parent_object_id=object_id('{0}') and parent_object_id <> referenced_object_id", rTbl.Name));
                        frmAutoExport.ProgressValue = 60 + (tempIndex * 20 / result.Count);
                        tempIndex++;
                        if (dt.Rows.Count > 0)
                        {
                            rTbl.ParentTables = new List<Table>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                tIndex = result.IndexOf(new Table(dr["Parent"].ToString()));
                                if (tIndex > -1) rTbl.ParentTables.Add(result[tIndex]);
                            }
                        }
                    }

                    /*
                    Tablolar için xml'de tanımlı olan parent tablolarının listesi oluşturuluyor.
                    */
                    file = Path.Combine(Path.Combine(Application.StartupPath, "Scripts"), "PredefinedRelation.xml");
                    if (File.Exists(file))
                    {
                        using (XmlTextReader xtr = new XmlTextReader(file))
                        {
                            int rType = 1;
                            while (xtr.Read())
                            {
                                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "Relation")
                                    rType = int.Parse(xtr.GetAttribute("type"));

                                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "Table")
                                {
                                    tIndex = result.IndexOf(new Table(xtr.GetAttribute("name")));
                                    rIndex = result.IndexOf(new Table(xtr.GetAttribute("relation")));
                                    if (tIndex > -1 && rIndex > -1)
                                    {
                                        if (result[tIndex].ParentTables == null)
                                            result[tIndex].ParentTables = new List<Table>();

                                        result[tIndex].ParentTables.Add(result[rIndex]);
                                    }
                                }
                            }
                        }
                    }
                    frmAutoExport.ProgressValue = 85;
                    /*
                   Tablolar için xml'de tanımlı olan fieldlara ait mapping ler okunuyor
                   */
                    file = Path.Combine(Path.Combine(Application.StartupPath, "Scripts"), "ColumnMapping.xml");
                    if (File.Exists(file))
                    {
                        using (XmlTextReader xtr = new XmlTextReader(file))
                        {
                            while (xtr.Read())
                            {
                                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "Table")
                                    tIndex = result.IndexOf(new Table(xtr.GetAttribute("name")));

                                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "Column")
                                {
                                    if (tIndex == -1) continue;

                                    cIndex = result[tIndex].ColumnList.IndexOf(new Column(xtr.GetAttribute("name")));

                                    if (cIndex == -1) continue;

                                    if (!string.IsNullOrEmpty(xtr.GetAttribute("convert")))
                                        result[tIndex].ColumnList[cIndex].Convert = xtr.GetAttribute("convert");
                                    if (!string.IsNullOrEmpty(xtr.GetAttribute("coalesce")))
                                        result[tIndex].ColumnList[cIndex].Coalesce = xtr.GetAttribute("coalesce");
                                }
                            }
                        }
                    }
                    frmAutoExport.ProgressValue = 90;
                    /*
                  Tablolar için xml'de tanımlı olan append edilecek data sorguları okunuyor
                  */
                    file = Path.Combine(Path.Combine(Application.StartupPath, "Scripts"), "AppendData.xml");
                    if (File.Exists(file))
                    {
                        using (XmlTextReader xtr = new XmlTextReader(file))
                        {
                            while (xtr.Read())
                            {
                                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "Table")
                                {
                                    tIndex = result.IndexOf(new Table(xtr.GetAttribute("name")));

                                    if (tIndex == -1) continue;
                                    result[tIndex].AppendCommandText = xtr.GetAttribute("commandText");
                                }
                            }
                        }
                    }
                    frmAutoExport.ProgressValue = 95;
                    /*
                     * Tablolarda gerçekte olmayan aktarım esnasında varmış gibi aktarılacak kolon ekleniyor.
                     */
                    file = Path.Combine(Path.Combine(Application.StartupPath, "Scripts"), "VirtualColumnMapping.xml");
                    if (File.Exists(file))
                    {
                        Column vCol;
                        using (XmlTextReader xtr = new XmlTextReader(file))
                        {
                            while (xtr.Read())
                            {
                                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "Table")
                                    tIndex = result.IndexOf(new Table(xtr.GetAttribute("name")));

                                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "Column")
                                {
                                    if (tIndex == -1) continue;

                                    cIndex = result[tIndex].ColumnList.IndexOf(new Column(xtr.GetAttribute("name")));

                                    if (cIndex > -1) continue;

                                    vCol = new Column(xtr.GetAttribute("name"));

                                    if (!string.IsNullOrEmpty(xtr.GetAttribute("convert")))
                                        vCol.Convert = xtr.GetAttribute("convert");
                                    if (!string.IsNullOrEmpty(xtr.GetAttribute("coalesce")))
                                        vCol.Coalesce = xtr.GetAttribute("coalesce");

                                    result[tIndex].ColumnList.Add(vCol);
                                }
                            }
                        }
                    }
                }
                frmAutoExport.ProgressValue = 100;
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public static DataTable GetData(SqlConnection conn, String Command)
        {
            using (SqlDataAdapter da = new SqlDataAdapter(Command, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        #endregion Methods
    }
}