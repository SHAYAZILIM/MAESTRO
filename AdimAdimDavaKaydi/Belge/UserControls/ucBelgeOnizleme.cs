using BelgeUtil;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using TXTextControl;

namespace AdimAdimDavaKaydi.Belge.UserControls
{
    public partial class ucBelgeOnizleme : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBelgeOnizleme()
        {
            InitializeComponent();
        }

        private int _seletedRecordID;

        private List<Docs> lstDocs = new List<Docs>();

        private int selectedRecordVersion;

        [Browsable(false)]
        public int SelectedRecordID
        {
            get { return _seletedRecordID; }
            set
            {
                if (!DesignMode)
                {
                    _seletedRecordID = value;
                }
            }
        }

        [Browsable(false)]
        public int SelectedRecordVersion
        {
            get { return selectedRecordVersion; }
            set
            {
                if (!DesignMode)
                {
                    selectedRecordVersion = value;
                }
            }
        }

        /// <summary>
        /// Bir dataTable i TextControle yukler
        /// </summary>
        /// <param name="dt">Yuklenecek Datalar</param>
        /// <param name="tc">Yazýlacak kontrol</param>
        public void LoadDataTable(DataTable dt, TextControl tc)
        {
            if (dt.Rows.Count > 500)
            {
                tc.Tables.Add(500 + 1, dt.Columns.Count, 11);
                Table tbl = tc.Tables.GetItem(11);
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    tbl.Cells.GetItem(1, i).Text = dt.Columns[i].Caption;
                }
                for (int i = 2; i < dt.Rows.Count; i++)
                {
                    for (int y = 1; y < dt.Columns.Count; y++)
                    {
                        if (i > 500)
                        {
                            break;
                        }
                        tbl.Cells.GetItem(i, y).Text = dt.Rows[i - 2][y - 1].ToString();
                    }
                }
            }
            else
            {
                tc.Tables.Add(dt.Rows.Count + 1, dt.Columns.Count, 11);
                Table tbl = tc.Tables.GetItem(11);
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    tbl.Cells.GetItem(1, i).Text = dt.Columns[i].Caption;
                }
                for (int i = 2; i < dt.Rows.Count; i++)
                {
                    for (int y = 1; y < dt.Columns.Count; y++)
                    {
                        tbl.Cells.GetItem(i, y).Text = dt.Rows[i - 2][y - 1].ToString();
                    }
                }
            }

            #region Caching

            byte[] data = new byte[1];
            tc.Save(out data, BinaryStreamType.InternalFormat);
            Docs dcs = new Docs();
            dcs.Veri = data;
            dcs.Version = this.selectedRecordVersion;
            dcs.Id = this._seletedRecordID;
            lstDocs.Add(dcs);

            #endregion Caching
        }

        /// <summary>
        /// Dosyayý Goster
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public bool ViewFile(string FileName, string extension)
        {
            #region<CC-20090627>

            // belgeleri açamadýðý için  hata düþüp  patlýyordu  try catch bolðuna alýndý

            #endregion</CC-20090627>

            try
            {
                FileTypes filetype = Tool.GetFileTypeByExtension(extension);
                switch (filetype)
                {
                    case FileTypes.VideoFile:
                        ShowControl(c_Video);
                        PlayVideo(FileName);
                        break;

                    case FileTypes.TextControlFile:
                        if (c_TextCnt.Tables != null)
                            c_TextCnt.Tables.Clear();
                        c_TextCnt.Clear();
                        ShowControl(c_TextCnt);
                        ShowInTxControl(FileName);
                        break;

                    case FileTypes.WebFile:
                        ShowControl(c_WebCnt);
                        ShowInWebBrowser(FileName);
                        break;

                    case FileTypes.TifFile:
                        ShowControl(c_PicBox);
                        ShowInImageEditor(FileName);
                        break;

                    case FileTypes.CrystalReportFile:
                        break;

                    case FileTypes.TextFile:
                        if (c_TextCnt.Tables != null)
                            c_TextCnt.Tables.Clear();
                        c_TextCnt.Clear();
                        ShowControl(c_TextCnt);
                        ShowInTxControl(FileName);
                        break;

                    case FileTypes.Other:
                        if (c_TextCnt.Tables != null)
                            c_TextCnt.Tables.Clear();
                        c_TextCnt.Clear();
                        ShowControl(c_TextCnt);
                        c_TextCnt.Text = "Bilinmeyen Dosya Formatý";
                        ShowInTxControl(FileName);
                        break;

                    case FileTypes.Excel07File:
                        if (c_tbGrids.TabPages != null)
                            c_tbGrids.TabPages.Clear();
                        ShowControl(c_tbGrids);
                        ShowExcelFile(FileName);
                        break;

                    case FileTypes.ExcelFile:
                        if (c_tbGrids.TabPages != null)
                            c_tbGrids.TabPages.Clear();
                        ShowControl(c_tbGrids);
                        ShowExcelFile(FileName);
                        break;

                    default:
                        if (c_TextCnt.Tables != null)
                            c_TextCnt.Tables.Clear();
                        c_TextCnt.Clear();
                        ShowControl(c_TextCnt);
                        ShowInTxControl(FileName);
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
                return false;
            }
        }

        /// <summary>
        /// Dosyayý Göster
        /// </summary>
        /// <param name="FileBytes"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public bool ViewFile(byte[] FileBytes, string extension)
        {
            try
            {
                string file = Tool.WriteBytesToTemp(FileBytes, extension);

                return ViewFile(file, extension);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Belge önizlemesinde sorunlar oluþtu!");
            }

            return false;
        }

        /// <summary>
        /// Dosyayý Göster
        /// </summary>
        /// <param name="FileBytes"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public bool ViewFile(byte[] FileBytes, int RecordId, int RecordVersion, string ext)
        {
            try
            {
                this.selectedRecordVersion = RecordVersion;
                this._seletedRecordID = RecordId;

                Docs dcs = FindInCache();
                if (dcs != null)
                {
                    return this.ViewFileFromCache(dcs, ext);
                }
                else
                {
                    return ViewFile(FileBytes, ext);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Belge Önizlemede bazý sorunlar oluþtu!!!");
            }
            return false;
        }

        /// <summary>
        /// Dosya Adýna Gore Dosyayý Onizler
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool ViewFile(string FileName)
        {
            try
            {
                string extension = Tool.GetExtensionFromFileName(FileName);
                return ViewFile(FileName, extension);
            }
            catch
            {
                ShowControl(c_TextCnt);
                c_TextCnt.Text = "Bilinmeyen Dosya Formatý";
                return false;
            }
        }

        /// <summary>
        /// Dosya Adýna Gore Dosyayý Onizler
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool ViewFile(string FileName, int RecordId, int RecordVersion)
        {
            try
            {
                this.selectedRecordVersion = RecordVersion;
                this._seletedRecordID = RecordId;

                Docs dcs = FindInCache();
                if (dcs != null)
                {
                    string extension = Tool.GetExtensionFromFileName(FileName);
                    return this.ViewFileFromCache(dcs, extension);
                }
                else
                {
                    string extension = Tool.GetExtensionFromFileName(FileName);
                    return ViewFile(FileName, extension);
                }
            }
            catch
            {
                XtraMessageBox.Show("Belge Önizlemede sorunlar var !!");
            }

            return false;
        }

        /// <summary>
        /// Dosyayý Goster
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public bool ViewFileFromCache(Docs cache, string extension)
        {
            FileTypes filetype = Tool.GetFileTypeByExtension(extension);

            switch (filetype)
            {
                case FileTypes.VideoFile:
                    break;

                case FileTypes.TextControlFile:
                    break;

                case FileTypes.WebFile:
                    break;

                case FileTypes.CrystalReportFile:
                    break;

                case FileTypes.TextFile:
                    ShowControl(c_TextCnt);
                    this.c_TextCnt.Load(cache.Veri, BinaryStreamType.InternalFormat);
                    break;

                case FileTypes.Other:
                    ShowControl(c_TextCnt);
                    this.c_TextCnt.Load(cache.Veri, BinaryStreamType.InternalFormat);
                    break;

                case FileTypes.Excel07File:
                    ShowControl(c_TextCnt);
                    this.c_TextCnt.Load(cache.Veri, BinaryStreamType.InternalFormat);
                    break;

                case FileTypes.ExcelFile:
                    ShowControl(c_TextCnt);
                    this.c_TextCnt.Load(cache.Veri, BinaryStreamType.InternalFormat);
                    break;

                default:

                    ShowControl(c_TextCnt);
                    this.c_TextCnt.Load(cache.Veri, BinaryStreamType.InternalFormat);

                    break;
            }

            return true;
        }

        private Docs FindInCache()
        {
            for (int i = 0; i < lstDocs.Count; i++)
            {
                if (lstDocs[i].Id == this._seletedRecordID && lstDocs[i].Version == this.selectedRecordVersion)
                {
                    return lstDocs[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Bir Video Dosyaý ný Calar
        /// </summary>
        /// <param name="file"></param>
        private void PlayVideo(string file)
        {
            //c_Video.URL = file;
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = file;
            p.Start();
        }

        /// <summary>
        /// Belirlenen kontrolu visible eder...
        /// </summary>
        /// <param name="cnt"></param>
        private void ShowControl(Control cnt)
        {
            c_PicBox.Visible = false;
            c_tbGrids.Visible = false;
            c_TextCnt.Visible = false;
            c_Video.Visible = false;
            c_WebCnt.Visible = false;

            cnt.Visible = true;
            cnt.BringToFront();
            //for (int i = 0; i < this.Controls.Count; i++)
            //{
            //    if (this.Controls[i] != cnt)
            //    {
            //        this.Controls[i].Visible = false;
            //    }
            //    else
            //    {
            //        this.Controls[i].Visible = true;
            //    }
            //}
        }

        /// <summary>
        /// Bir excel dosyasýný textControlde acar
        /// </summary>
        /// <param name="file">Dosya</param>
        private void ShowExcelFile(string file)
        {
            DataSet ds = ImportFromExcel(file);
            if (ds == null)
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = file;
                p.Start();
                //MessageBox.Show("Windows Dosya Formatýný Desteklemiyor", "Desteklenmeyen Biçim", MessageBoxButtons.OK,
                //                MessageBoxIcon.Information);
                return;
            }

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                XtraTabPage tp = new XtraTabPage();
                tp.Text = ds.Tables[i].TableName;
                GridControl gcExcelPage = new GridControl();
                tp.Controls.Add(gcExcelPage);
                gcExcelPage.DataSource = ds.Tables[i];
                gcExcelPage.Dock = DockStyle.Fill;
                this.c_tbGrids.TabPages.Add(tp);
            }
        }


        public static DataSet ImportFromExcel(string file)
        {
            try
            {
                string conn07 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";

                string conn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";

                #region<CC-20090627>

                // excel dosyalarý önizlemede gösterirken  dosyaýda açýyordu düzeltildi
                //     ApplicationClass app = new ApplicationClass();
                //     Microsoft.Office.Interop.Excel.Workbook wb;
                //     Microsoft.Office.Interop.Excel.Worksheet ws;
                //     wb = app.Workbooks.Open(file,
                //Missing.Value, Missing.Value, Missing.Value,
                //Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                //Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                //Missing.Value, Missing.Value, Missing.Value);
                //     ws = (Worksheet)wb.Worksheets[1];

                #endregion </CC20090627>

                DataSet ds = new DataSet();
                OleDbConnection con;
                if (System.IO.Path.GetExtension(file) == ".xlsx")
                {
                    con = new OleDbConnection(conn07);
                }
                else
                {
                    // con = new OleDbConnection(conn);

                    con = new OleDbConnection(conn);
                }

                //try
                //{
                //    con = new OleDbConnection(conn);
                //}
                //catch (Exception ex)
                //{
                //    con = new OleDbConnection(conn07);
                //}
                con.Open();
                System.Data.DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + dt.Rows[0]["TABLE_NAME"] + "]", con);
                da.Fill(ds);
                con.Close();
                return ds;
            }
            catch
            {
                return null;
            }
        }

        private void ShowInImageEditor(string FileName)
        {
            this.c_PicBox.PictureFile = FileName;
        }

        /// <summary>
        /// Bir yazý dosyasýný TxControlde Gosteriri
        /// </summary>
        /// <param name="file"></param>
        private void ShowInTxControl(string file)
        {
            try
            {
                StreamType stype =
                    Tool.GetStreamTypeByFileType(
                        (TxFileTypes)Enum.Parse(typeof(TxFileTypes), Tool.GetExtensionFromFileName(file)));

                this.c_TextCnt.Load(file, stype, new TXTextControl.LoadSettings());
            }
            catch
            {
                c_TextCnt.Text = string.Empty;
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = file;
                p.Start();
                //XtraMessageBox.Show("Dosya Açýlamadý");
            }
        }

        /// <summary>
        /// Bir Belgeyi Web Browserda Acar
        /// </summary>
        /// <param name="file"></param>
        private void ShowInWebBrowser(string file)
        {
            if (Path.GetExtension(file).Contains("pdf"))
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = file;
                p.Start();
            }
            else
            {
                c_WebCnt.Navigate(file);
            }
        }

        public class Docs
        {
            private byte[] _veri;

            private int id;

            [Browsable(false)]
            public int Id
            {
                get { return id; }
                set
                {
                    if (value != null)
                    {
                        id = value;
                    }
                }
            }

            [Browsable(false)]
            public byte[] Veri
            {
                get { return _veri; }
                set
                {
                    if (value != null)
                    {
                        _veri = value;
                    }
                }
            }

            [Browsable(false)]
            public int Version { get; set; }
        }
    }
}