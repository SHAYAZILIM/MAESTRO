using AdimAdimDavaKaydi.Editor.Forms;
using AdimAdimDavaKaydi.Editor.General;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AdimAdimDavaKaydi.Forms.Icra;
using AdimAdimDavaKaydi.GirisEkran;
using AdimAdimDavaKaydi.Util;
using AvukatProDegiskenler.Icra;
using AvukatProDegiskenler.Util;
using AvukatProEditorDegisken;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraTab;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using TXTextControl;

namespace AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge
{
    public class Criteria
    {
        public string Kriter { get; set; }

        public object Record { get; set; }
    }

    public partial class uctxEditor : DevExpress.XtraEditors.XtraUserControl, IRecordable
    {
        #region properties

        private AV001_TDIE_BIL_SABLON_RAPOR _openedRapor;
        private object _tag;
        private string _waterMark = string.Empty;
        private Point _waterMarkLocation;
        private ucDegiskenBicimlendirme bicim;
        private string fileFolder;
        private Point p;

        /// <summary>
        /// Seçili  Foy kaydý
        /// </summary>
        private IList selectedFoy;

        private AV001_TDI_BIL_TEBLIGAT_MUHATAP tebligatMuhatab;
        private int varCounter;

        /// <summary>
        /// true ise mouse frame ekleme moduna gecer
        /// </summary>
        public bool AddFrameWithMouse { get; set; }

        public bool AlanlarDolduruldumu { get; set; }

        public AV001_TD_BIL_FOY Dava { get; set; }

        public AV001_TD_BIL_FOY_TARAF Dava_Taraf { get; set; }

        public bool FieldFilled { get; set; }

        public string FileFolder
        {
            get { return fileFolder; }
            set { fileFolder = value; }
        }

        public AV001_TI_BIL_FOY Icra { get; set; }

        public AV001_TI_BIL_FOY_TARAF Icra_Taraf { get; set; }

        public int Id { get; set; }

        public AV001_TDIE_BIL_SABLON_RAPOR OpenedRapor
        {
            get { return _openedRapor; }
            set
            {
                _openedRapor = value;
                if (value != null)
                {
                    this.ucSeciliBelgeler2.SeciliSablon = value;
                }
            }
        }

        public XtraTabPage Page { get; set; }

        public frmEditor Parentform { get; set; }

        public RecordInfos Record { get; set; }

        public List<uctxEditor> RelationalEditors { get; set; }

        public RibbonControl Ribbon { get; set; }

        public IList SelectedFoys
        {
            get { return selectedFoy; }
            set
            {
                selectedFoy = value;
                if (value == null)
                {
                    return;
                }
                for (int i = 0; i < selectedFoy.Count; i++)
                {
                    SetModul(selectedFoy[i]);
                }
            }
        }

        public AV001_TDI_BIL_SOZLESME Sozlesme { get; set; }

        public AV001_TDI_BIL_SOZLESME_TARAF SozlesmeTaraf { get; set; }

        public object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        public AV001_TDI_BIL_TEBLIGAT Tebligat { get; set; }

        public AV001_TDI_BIL_TEBLIGAT_MUHATAP TebligatMuhatab
        {
            get { return tebligatMuhatab; }
            set
            {
                tebligatMuhatab = value;
                if (value != null)
                {
                    Degiskenler.Muhataplar.Add(value);
                }
            }
        }

        public string WaterMark
        {
            get { return _waterMark; }
            set { _waterMark = value; }
        }

        public System.Drawing.Image WaterMarkImage { get; set; }

        public Point WaterMarkLocation
        {
            get { return _waterMarkLocation; }
            set { _waterMarkLocation = value; }
        }

        public Font YaziTipi { get; set; }

        #region props and Fields

        private bool _IsVarVisible = true;

        private OpenedFilesTypes openedFile;

        /// <summary>
        /// Açýlmýþ Dosya
        /// </summary>
        private string openedFileName;

        public bool IsVarsVisible
        {
            get { return _IsVarVisible; }
            set
            {
                _IsVarVisible = value;
                if (value)
                {
                    dockPanel1.Show();
                }
                else
                {
                    dockPanel1.Close();
                }
            }
        }

        public OpenedFilesTypes OpenedFile
        {
            get { return openedFile; }
            set { openedFile = value; }
        }

        public string OpenedFileName
        {
            get { return openedFileName; }
            set { openedFileName = value; }
        }

        #endregion props and Fields

        #endregion properties

        public uctxEditor()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool GetCaretPos(ref System.Drawing.Point pn);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SetCaretPos(int x, int y);

        public void DrawWaterMark(System.Drawing.Image img, Point pnt)
        {
            if (img != null)
            {
                Graphics g = this.textControl1.CreateGraphics();
                g.DrawImage(img, pnt);
            }
        }

        public void ImportFromExcel(string filename, string sayfaAdi)
        {
            LoadDataSet(AvProExportImport.Import.Excel.ImportFromExcel(filename));
        }

        public void ImportFromFile()
        {
            this.textControl1.Selection.Load();
        }

        public void LoadDataSet(DataSet ds)
        {
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                LoadDataTable(ds.Tables[i]);
            }
        }

        public void LoadDataTable(DataTable dt)
        {
            this.textControl1.Tables.Add(dt.Rows.Count + 1, dt.Columns.Count, 11);
            Table tbl = this.textControl1.Tables.GetItem(11);
            for (int i = 0; i < dt.Columns.Count; i++)
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

        public void SendToExcel()
        {
            AvProExportImport.Util.ExcelTable ExcelDataTable = new AvProExportImport.Util.ExcelTable();
            ExcelDataTable.Columns.Add("yazi");
            ExcelDataTable.Rows.Add(this.textControl1.Text);
            if (Record != null)
            {
                AvProExportImport.Export.Excel.ToNewDocument(Tools.TempFilesPath + Record.Name, "AvukatproEditor",
                                                             ExcelDataTable);
            }
            else
            {
                AvProExportImport.Export.Excel.ToNewDocument(Tools.TempFilesPath + "unnamed1", "AvukatproEditor",
                                                             ExcelDataTable);
            }
        }

        public void SozcukDenetimi()
        {
            this.compIntellisense1.SozcukDenetle = !compIntellisense1.SozcukDenetle;
        }

        public void YazimYardimcisi()
        {
            this.compIntellisense1.Activate = !compIntellisense1.Activate;
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            FoyUygula();
        }

        private void textControl1_DragOver(object sender, DragEventArgs e)
        {
            this.textControl1.InsertionMode = InsertionMode.Overwrite;
            Point p = textControl1.PointToClient(new Point(e.X, e.Y));
            SetCaretPos(p.X, p.Y);
            SetCaretPos(Control.MousePosition.X, Control.MousePosition.Y);
        }

        private void textControl1_MouseMove(object sender, MouseEventArgs e)
        {
            p = e.Location;
        }

        private void textControl1_TextFieldDoubleClicked(object sender, TextFieldEventArgs e)
        {
            if (e.TextField.Name.StartsWith("<Aciklama>"))
            {
                string[] aciklamas = e.TextField.Name.Split(';');
                frmAciklama ackl = new frmAciklama();

                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.GetByFOY_NO(aciklamas[1]);
            }
        }

        private void uctxEditor_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            this.textControl1.DragOver += textControl1_DragOver;
            textControl1.MouseMove += textControl1_MouseMove;
            this.textControl1.MouseDown += textControl1_MouseDown;
            this.textControl1.MouseUp += textControl1_MouseUp;

            fileFolder = Application.StartupPath + "\\Sablon\\";
            if (!Directory.Exists(fileFolder))
            {
                Directory.CreateDirectory(fileFolder);
            }
            textControl1.StatusBar = statusBar1;
            textControl1.ButtonBar = buttonBar1;
            textControl1.VerticalRulerBar = rulerBar1;
            textControl1.RulerBar = rulerBar2;

            //TODO Tum dehgiskenleri Lookup içn hazýrla ...

            textControl1.TextFieldClicked += textControl1_TextFieldClicked;

            this.ucSeciliBelgeler2.SeciliSablon = this.OpenedRapor;
            this.ucSeciliBelgeler2.Document = this;
            if (this.ParentForm is frmEditor)
            {
                this.ucSeciliBelgeler2.ParentForm = (frmEditor)this.ParentForm;
            }
        }

        #region xmlÝþlemleri

        private List<DataField> DataFields = new List<DataField>();

        public void ReadDataFieldsFromXml(string file)
        {
            FileStream fs = new FileStream(file + ".Data.Xml", FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(List<DataField>));
            DataFields = (List<DataField>)xs.Deserialize(fs);
            fs.Close();
        }

        public void WriteDataFieldsToXml(string file)
        {
            WriteVarsToDataXmlCollection();
            FileStream fs = new FileStream(fileFolder + file + ".Data.Xml", FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(List<DataField>));
            xs.Serialize(fs, DataFields);
            fs.Close();
        }

        private void WriteVarsToDataXmlCollection()
        {
            TXTextControl.TextFieldCollection.TextFieldEnumerator tenm = textControl1.TextFields.GetEnumerator();
            while (tenm.MoveNext())
            {
                TextField tfcur = (TextField)tenm.Current;
                if (!string.IsNullOrEmpty(tfcur.Text.Trim()))
                {
                    DataField dfield = new DataField();
                    dfield.DataSourceTable = "";

                    dfield.IdColumn = "ID";

                    dfield.Length = tfcur.Text.Length;
                    dfield.Name = tfcur.Name;

                    dfield.StartIndex = tfcur.Start;
                    dfield.Text = tfcur.Text;

                    DataFields.Add(dfield);
                }
            }
        }

        #endregion xmlÝþlemleri

        #region TextField Biçimleme

        private void bicim_Deleted(object sender, TextField deletedItem)
        {
            this.textControl1.TextFields.Remove(deletedItem);
            ((Control)sender).Visible = false;
        }

        private void bicim_LostFocus(object sender, EventArgs e)
        {
            bicim.Visible = false;
        }

        private void textControl1_TextFieldClicked(object sender, TextFieldEventArgs e)
        {
            if (e.TextField.Name.StartsWith("<Aciklama>"))
            {
                string[] aciklamas = e.TextField.Name.Split(';');
                frmAciklama acklama = new frmAciklama();
                AV001_TI_BIL_FOY mf =
                    AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.GetByFOY_NO(aciklamas[1]);

                //acklama.Show(mf);
                frmDegiskenler degiskenler = new AvukatProEditorDegisken.frmDegiskenler();
                degiskenler.Foy = mf;
                degiskenler.Show();
            }
            if (e.TextField.Text.Contains("Araç Bilgisi Girilmemiþ.") ||
                e.TextField.Text.Contains("Sözleþme Bilgisi Girilmemiþ."))
            {
                frmIcraDosyaKayit icraKayit = new frmIcraDosyaKayit();
                icraKayit.Show();
                AvukatProDegiskenler.Util.DegiskenHelper.SeciliKayit kayit = DegiskenHelper.GetSelectedKayitByModul(2);
                if (kayit.Kayit is AV001_TI_BIL_FOY)
                {
                    icraKayit.Ac((AV001_TI_BIL_FOY)kayit.Kayit, this.Parentform);
                }
            }
            if (bicim == null)
            {
                bicim = new ucDegiskenBicimlendirme();
                this.textControl1.Controls.Add(bicim);
                bicim.LostFocus += bicim_LostFocus;
            }
            bicim.Focus();
            bicim.SelectField(e.TextField, p);
            bicim.Deleted += bicim_Deleted;
        }

        #endregion TextField Biçimleme

        #region gridSurukle

        public void insertfield(string name, string caption)
        {
            TextField newField = new TextField(caption);
            this.textControl1.TextFields.Add(newField);
            newField.Name = name + "__" + varCounter;
            newField.ShowActivated = true;
            newField.DoubledInputPosition = true;
            varCounter++;
        }

        private void textControl1_DragDrop(object sender, DragEventArgs e)
        {
            AV001_TDIE_BIL_SABLON_DEGISKENLER var =
                (AV001_TDIE_BIL_SABLON_DEGISKENLER)e.Data.GetData(typeof(AV001_TDIE_BIL_SABLON_DEGISKENLER));
            insertfield(var.AD, var.GORUNEN_AD);
        }

        private void textControl1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        //void ucAjanda_MouseDown(object sender, MouseEventArgs e)
        //{
        //    GridView view = sender as GridView;
        //    downHitInfo = null;

        //    GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
        //    if (Control.ModifierKeys != Keys.None)
        //        return;
        //    if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.HitTest != GridHitTest.RowIndicator)
        //        downHitInfo = hitInfo;
        //}

        //void ucAjanda_MouseMove(object sender, MouseEventArgs e)
        //{
        //    GridView view = sender as GridView;
        //    if (e.Button == MouseButtons.Left && downHitInfo != null)
        //    {
        //        Size dragSize = SystemInformation.DragSize;
        //        Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,
        //            downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

        //        if (!dragRect.Contains(new Point(e.X, e.Y)))
        //        {
        //            string deger = "";
        //            deger = ((GridView)gridControl1.MainView).GetFocusedRow().ToString();

        //            view.GridControl.DoDragDrop(deger, DragDropEffects.All);
        //            downHitInfo = null;
        //        }
        //    }
        //}

        #endregion gridSurukle

        #region Degisken Ýþlemnleri

        private List<string> strings = new List<string>();

        private List<TextField> tfields = new List<TextField>();

        public void SetFieldsValues(bool useNewRecord)
        {
            if (useNewRecord)
            {
                DegiskenHelper.SelectedRecords = new List<DegiskenHelper.SeciliKayit>();
            }

            if (this.RelationalEditors == null)
            {
                this.RelationalEditors = new List<uctxEditor>();
                this.RelationalEditors.Add(this);
            }

            TXTextControl.TextFieldCollectionBase.TextFieldEnumerator enms = textControl1.TextFields.GetEnumerator();

            while (enms.MoveNext())
            {
                if (!string.IsNullOrEmpty(((TextField)enms.Current).Name))
                {
                    AV001_TDIE_BIL_SABLON_DEGISKENLER mevcutDegisken = new AV001_TDIE_BIL_SABLON_DEGISKENLER();
                    try
                    {
                        mevcutDegisken =
                            DegiskenHelper.GetDegiskenByAd(
                                ((TextField)enms.Current).Name.Split(new[] { "__" },
                                                                      StringSplitOptions.RemoveEmptyEntries)[0]);
                    }
                    catch
                    {
                    }

                    if (useNewRecord)
                    {
                        AvukatProDegiskenler.Util.DegiskenHelper.SeciliKayit kayit =
                            DegiskenHelper.GetSelectedKayitByModul(mevcutDegisken.MODUL_ID);
                        kayit = null;
                    }

                    DegiskenHelper.SetRecords(mevcutDegisken);
                    Degiskenler.GetCopyCount(this, this.Icra);
                    Degiskenler.GetCopiesByTebligatMuhatab(this, this.Icra);
                }
            }
            FillFields();
        }

        private void FillFields()
        {
            TXTextControl.TextFieldCollectionBase.TextFieldEnumerator enms;
            for (int ed = 0; ed < this.RelationalEditors.Count; ed++)
            {
                if (RelationalEditors[ed].FieldFilled)
                {
                    // return;
                }
                else
                {
                    this.RelationalEditors[ed].FieldFilled = true;
                }

                enms = this.RelationalEditors[ed].textControl1.TextFields.GetEnumerator();
                while (enms.MoveNext())
                {
                    this.AlanlarDolduruldumu = true;

                    if (!string.IsNullOrEmpty(((TextField)enms.Current).Name))
                    {
                        bool ks = Karsilastir(((TextField)enms.Current).Name);
                        tfields.Add(((TextField)enms.Current));
                        AV001_TDIE_BIL_SABLON_DEGISKENLER mevcutDegisken = new AV001_TDIE_BIL_SABLON_DEGISKENLER();
                        try
                        {
                            mevcutDegisken =
                                DegiskenHelper.GetDegiskenByAd(
                                    ((TextField)enms.Current).Name.Split(new[] { "__" },
                                                                          StringSplitOptions.RemoveEmptyEntries)[0]);
                        }
                        catch
                        {
                        }

                        this.RelationalEditors[ed].textControl1.Selection.Start = ((TextField)enms.Current).Start;

                        int sind = 0;
                        Table tbl = this.RelationalEditors[ed].textControl1.Tables.GetItem();
                        if (tbl != null)
                        {
                            TableCell tblCl = tbl.Cells.GetItem();
                            if (tblCl != null)
                            {
                                sind = tblCl.Start;
                            }
                        }

                        this.RelationalEditors[ed].textControl1.Selection.Start = ((TextField)enms.Current).Start - 1;
                        this.RelationalEditors[ed].textControl1.InputPosition =
                            new InputPosition(((TextField)enms.Current).Start - 1);
                        this.RelationalEditors[ed].textControl1.Selection.Text = " ";
                        int endSind = 0;
                        Table tbl2 = this.RelationalEditors[ed].textControl1.Tables.GetItem();
                        if (tbl2 != null)
                        {
                            TableCell tblCl = tbl2.Cells.GetItem();
                            if (tblCl != null)
                            {
                                endSind = tblCl.Start;
                            }
                        }

                        if (sind != 0 && sind != endSind)
                        {
                            this.RelationalEditors[ed].textControl1.Selection.Start = sind;
                        }

                        string selectedtf = ((TextField)enms.Current).Text;
                        int sindex = ((TextField)enms.Current).Start;

                        object value = DegiskenHelper.GetValue(mevcutDegisken, this, this.Parentform);

                        if (value is string)
                        {
                            TextField tf = ((TextField)enms.Current);

                            tf.Text = " ";

                            if (!string.IsNullOrEmpty(value.ToString()))
                            {
                                tf.Text = value.ToString();
                            }
                        }
                        else if (value is DegiskenDegeri)
                        {
                            DegiskenDegeri deger = (DegiskenDegeri)value;
                            TextField tf = ((TextField)enms.Current);

                            tf.Text = " ";

                            if (!string.IsNullOrEmpty(deger.Icerik))
                            {
                                switch (deger.DonusTipi)
                                {
                                    case DegiskenResulTType.HTML:
                                        this.RelationalEditors[ed].textControl1.Selection.Load(deger.Icerik,
                                                                                               StringStreamType.
                                                                                                   HTMLFormat);
                                        break;

                                    case DegiskenResulTType.String:
                                        tf.Text = deger.Icerik;
                                        break;

                                    case DegiskenResulTType.HicBiri:
                                        tf.Text = deger.Icerik;
                                        break;

                                    case DegiskenResulTType.TextField:
                                        List<TextField> lstfields = (List<TextField>)value;
                                        ((TextField)enms.Current).Text = " ";
                                        for (int j = 0; j < lstfields.Count; j++)
                                        {
                                            if (!string.IsNullOrEmpty(lstfields[j].Text))
                                            {
                                                TextField df = new TextField();
                                                ((TextField)enms.Current).Text += lstfields[j].Text + " ";
                                                df.ShowActivated = true;
                                                df.DoubledInputPosition = true;
                                                df.Deleteable = true;
                                                df.Editable = true;
                                                df.DoubleClickEvent = true;
                                            }
                                        }
                                        break;

                                    default:
                                        break;
                                }
                            }
                        }
                        else if (value is List<TextField>)
                        {
                            List<TextField> lstfields = (List<TextField>)value;
                            ((TextField)enms.Current).Text = " ";
                            for (int j = 0; j < lstfields.Count; j++)
                            {
                                if (!string.IsNullOrEmpty(lstfields[j].Text))
                                {
                                    TextField df = new TextField();
                                    ((TextField)enms.Current).Text += lstfields[j].Text + " ";
                                    df.ShowActivated = true;
                                    df.DoubledInputPosition = true;
                                    df.Deleteable = true;
                                    df.Editable = true;
                                    df.DoubleClickEvent = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool Karsilastir(string degisken)
        {
            for (int i = 0; i < strings.Count; i++)
            {
                if (strings[i] == degisken)
                {
                    return true;
                }
            }
            strings.Add(degisken);
            return false;
        }

        private void SetModul(object record)
        {
            if (record is AvukatProLib2.Entities.AV001_TD_BIL_FOY)
            {
                ucSeciliBelgeler2.Modul = AvukatProLib2.Data.DataRepository.TDIE_KOD_MODULProvider.Find("AD=Dava")[0].ID;
            }
            if (record is AvukatProLib2.Entities.AV001_TI_BIL_FOY)
            {
                ucSeciliBelgeler2.Modul = AvukatProLib2.Data.DataRepository.TDIE_KOD_MODULProvider.Find("AD=Icra")[0].ID;
            }

            if (record is AvukatProLib2.Entities.AV001_TD_BIL_HAZIRLIK)
            {
                ucSeciliBelgeler2.Modul =
                    AvukatProLib2.Data.DataRepository.TDIE_KOD_MODULProvider.Find("AD=Soruþturma")[0].ID;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SetFieldsValues(false);
        }

        #endregion Degisken Ýþlemnleri

        #region ruler

        public enum RulerTypes
        {
            left,
            Top,
            All
        }

        public void RulersEnablePagesMargin(bool value, RulerTypes rtype)
        {
            switch (rtype)
            {
                case RulerTypes.left:
                    rulerBar1.EnablePageMargins = value;
                    break;

                case RulerTypes.Top:
                    rulerBar2.EnablePageMargins = value;
                    break;

                case RulerTypes.All:
                    rulerBar1.EnablePageMargins = value;
                    rulerBar2.EnablePageMargins = value;
                    break;

                default:
                    break;
            }
        }

        public void RulersScaleUnit(RulerBarScaleUnit scale, RulerTypes rtype)
        {
            switch (rtype)
            {
                case RulerTypes.left:
                    rulerBar1.ScaleUnit = scale;
                    break;

                case RulerTypes.Top:
                    rulerBar2.ScaleUnit = scale;
                    break;

                case RulerTypes.All:
                    rulerBar1.ScaleUnit = scale;
                    rulerBar2.ScaleUnit = scale;
                    break;

                default:
                    break;
            }
        }

        public void RulerstBorderStyle(RulerBarBorderStyle value, RulerTypes rtype)
        {
            switch (rtype)
            {
                case RulerTypes.left:
                    rulerBar1.BorderStyle = value;
                    break;

                case RulerTypes.Top:
                    rulerBar2.BorderStyle = value;
                    break;

                case RulerTypes.All:
                    rulerBar1.BorderStyle = value;
                    rulerBar2.BorderStyle = value;
                    break;

                default:
                    break;
            }
        }

        #endregion ruler

        #region Gorunum

        /// <summary>
        /// Sayfa Boþluklarýný Ayarlar ...
        /// </summary>
        /// <param name="margins">Sayfa Boþlukjlarý </param>
        public void PageMargins(PageMargins margins)
        {
            textControl1.PageMargins = margins;
        }

        public void TextControlSetPageMargins(int left, int rigth, int top, int bottom)
        {
            textControl1.PageMargins.Top = top;
            textControl1.PageMargins.Left = left;
            textControl1.PageMargins.Right = rigth;
            textControl1.PageMargins.Bottom = bottom;
        }

        public void TextControlSetPageSize(int width, int heigth)
        {
            textControl1.PageSize = new Size(width, heigth);
        }

        public void TxtControlBackGroundStyle(BackgroundStyle backStyle)
        {
            this.textControl1.BackgroundStyle = backStyle;
        }

        public void TxtControlSetEditMode(EditMode value)
        {
            textControl1.EditMode = value;
        }

        public void TxtControlSetViewMode(ViewMode mode)
        {
            textControl1.ViewMode = mode;
        }

        public void TxtControlSetZoom(int zoom)
        {
            textControl1.ZoomFactor = zoom;
        }

        #endregion Gorunum

        #region Biþiler Ekle

        /// <summary>
        /// Frame Ekleme Formunu Aç
        /// </summary>
        public void AddFrame()
        {
            frmAlanEkle alanEkle = new frmAlanEkle();
            alanEkle.ShowMe(this.textControl1);
        }

        /// <summary>
        /// Resim Ekle
        /// </summary>
        public void AddImage()
        {
            AvukatProImageEditor.AvproImageEditor editor = new AvukatProImageEditor.AvproImageEditor();

            //editor.MdiParent = null;
            editor.StartPosition = FormStartPosition.WindowsDefaultLocation;
            editor.Show();
            this.AddImageFromMemory(editor.OpenedImage, true);
        }

        public void AddImageFromMemory(System.Drawing.Image myImage, bool asFixedImage)
        {
            //System.IO.MemoryStream stream = new MemoryStream();
            //byte[] veri;
            //string rtfString = string.Empty;

            //System.Text.StringBuilder imageString = new StringBuilder();
            //myImage.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            //veri = stream.ToArray();
            //for (int i = 0; i < veri.Length; i++)
            //{
            //    imageString.Append(veri[i].ToString("x2"));
            //}

            //rtfString = @"{\rtf1" + Environment.NewLine;

            //if (asFixedImage)
            //    rtfString += @"{\shp{\*\shpinst\shpfhdr0\ shpbxcolumn\shpbypara\shpwr2\shpwrk0\shpfblwtxt0\shplid1025{\sp {\sn shapeType}{\sv 75}}{\sp{\sn dxWrapDistLeft}{\sv 0}}{\sp {\sn dxWrapDistRight}{\sv 0}}{\sp{\sn pib}{\sv ";

            //rtfString += @"{\pict\jpegblip\picscalex100\picscaley100" + Environment.NewLine;

            //rtfString += imageString.ToString();

            //rtfString += "}}";

            //if (asFixedImage)
            //    rtfString += @"\par}";

            //this.textControl1.Selection.Load(rtfString, TXTextControl.StringStreamType.RichTextFormat);
            if (myImage == null) return;

            System.IO.MemoryStream stream = new MemoryStream();
            myImage.Save(stream, ImageFormat.Jpeg);
            AddImageFromMemory(stream.GetBuffer(), true);
        }

        public void AddImageFromMemory(byte[] myImage, bool asFixedImage)
        {
            System.IO.MemoryStream stream = new MemoryStream(myImage);
            byte[] veri;
            string rtfString = string.Empty;

            System.Text.StringBuilder imageString = new StringBuilder();
            veri = stream.ToArray();

            for (int i = 0; i < veri.Length; i++)
            {
                imageString.Append(veri[i].ToString("x2"));
            }

            rtfString = @"{\rtf1" + Environment.NewLine;

            if (asFixedImage)
                rtfString +=
                    @"{\shp{\*\shpinst\shpfhdr0\ shpbxcolumn\shpbypara\shpwr2\shpwrk0\shpfblwtxt0\shplid1025{\sp {\sn shapeType}{\sv 75}}{\sp{\sn dxWrapDistLeft}{\sv 0}}{\sp {\sn dxWrapDistRight}{\sv 0}}{\sp{\sn pib}{\sv ";
            rtfString += @"{\pict\jpegblip\picscalex100\picscaley100" + Environment.NewLine;
            rtfString += imageString.ToString();
            rtfString += "}}";

            if (asFixedImage)
                rtfString += @"\par}";

            this.textControl1.Selection.Load(rtfString, TXTextControl.StringStreamType.RichTextFormat);
        }

        /// <summary>
        /// Tablo Ekleme Formunu Aç ...
        /// </summary>
        public void AddTable()
        {
            frmSablonTabloEkle tbleEkle = new frmSablonTabloEkle();
            tbleEkle.ShowTableAddDialog(this.textControl1);
        }

        /// <summary>
        /// Resim ekle
        /// </summary>
        /// <param name="image">Resim </param>
        /// <param name="pageNumber">Hangi Sayfaya +</param>
        /// <param name="location">resimin Yeri x,y</param>
        /// <param name="insertmode">Resmi Ekle Þekli </param>
        public void InsertImage(TXTextControl.Image image, int pageNumber, Point location, ImageInsertionMode insertmode)
        {
            textControl1.Images.Add(image, pageNumber, location, insertmode);
        }

        private void textControl1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void textControl1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        #endregion Biþiler Ekle

        #region Ýçeriði tazele

        /// <summary>
        /// içerið-i Tazeleyen Thread
        /// </summary>
        private Thread thr;

        /// <summary>
        /// Ýçeriði Tazeleyen Metod
        /// </summary>
        private void foyUygula()
        {
            while (true)
            {
                this.SetFieldsValues(false);
            }
        }

        /// <summary>
        /// Foy uygulama Bir Tjhread içerisinde devamlý olarak belirlenen foye gore içerik tazelenir...
        /// </summary>
        private void FoyUygula()
        {
            Form frm = new Form();
            frm.Controls.Add(this);
            this.Dock = DockStyle.Fill;
            frm.TopMost = true;
            frm.BringToFront();
            CheckForIllegalCrossThreadCalls = false;
            thr = new Thread(foyUygula);
            thr.Start();
            frm.Show();
        }

        #endregion Ýçeriði tazele

        #region Yazdýr Kes Kopyala Yapýþtýr Önizleme

        /// <summary>
        /// Kopyala
        /// </summary>
        public void Copy()
        {
            this.textControl1.Copy();
        }

        /// <summary>
        /// Kes
        /// </summary>
        public void Cut()
        {
            this.textControl1.Cut();
        }

        public AV001_TDIE_BIL_BELGE GetBelge()
        {
            AV001_TDIE_BIL_BELGE Belge = new AV001_TDIE_BIL_BELGE();
            IEntity record = null;
            if (this.Icra != null)
            {
                Belge = RecordGenerator.Generate.GenerateAV001_TDIE_BIL_BELGEByRecord(this.Icra);
            }
            else if (this.Dava != null)
            {
                Belge = RecordGenerator.Generate.GenerateAV001_TDIE_BIL_BELGEByRecord(this.Dava);
            }
            else if (this.Tebligat != null)
            {
                Belge = RecordGenerator.Generate.GenerateAV001_TDIE_BIL_BELGEByRecord(this.Tebligat);

                //Belge.AV001_TDI_BIL_TEBLIGATCollection_From_NN_BELGE_TEBLIGAT.Add(this.Tebligat);
                record = this.Tebligat;
                Belge.BELGE_ADI = this.Tebligat.TEBLIGAT_ESAS_NO + " esas numaralý " + this.OpenedRapor.AD;

                //  NNProcess.SaveBelge(Belge,this.Tebligat);
            }
            else if (this.TebligatMuhatab != null)
            {
                Belge = RecordGenerator.Generate.GenerateAV001_TDIE_BIL_BELGEByRecord(this.TebligatMuhatab);

                //Belge.AV001_TDI_BIL_TEBLIGATCollection_From_NN_BELGE_TEBLIGAT.Add(this.TebligatMuhatab.TEBLIGAT_IDSource);
                //Belge.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_From_NN_BELGE_TEBLIGAT_MUHATAB.Add(this.TebligatMuhatab);

                Belge.BELGE_ADI = this.TebligatMuhatab.CARI_ALT_IDSource.AD + " üçüncü þahýs için " +
                                  this.OpenedRapor.AD;
                record = this.TebligatMuhatab;
                //  NNProcess.SaveBelge(Belge, this.TebligatMuhatab);
            }
            else if (this.Sozlesme != null)
            {
                Belge = RecordGenerator.Generate.GenerateAV001_TDIE_BIL_BELGEByRecord(this.Sozlesme);

                //   Belge.AV001_TDI_BIL_SOZLESMECollection_From_NN_BELGE_SOZLESME.Add(this.Sozlesme);
                record = this.Sozlesme;
                Belge.BELGE_ADI = this.Sozlesme.SOZLESME_NO + " numaralý " + this.OpenedRapor.AD;
            }
            else if (this.SozlesmeTaraf != null)
            {
                Belge = RecordGenerator.Generate.GenerateAV001_TDIE_BIL_BELGEByRecord(this.SozlesmeTaraf);
                record = this.SozlesmeTaraf;
                Belge.BELGE_ADI = this.SozlesmeTaraf.CARI_IDSource.AD + "  adlý kiþi için  " + this.OpenedRapor.AD;

                //   Belge.AV001_TDI_BIL_SOZLESMECollection_From_NN_BELGE_SOZLESME.Add(this.SozlesmeTaraf.SOZLESME_IDSource);
                //     Belge.AV001_TDI_BIL_SOZLESME_TARAFCollection_From_NN_BELGE_SOZLESME_TARAF.Add(this.SozlesmeTaraf);
            }

            Belge.BELGE_ADI = "";
            Belge.BELGE_NO = "123";
            string yol = Tools.TempFilesPath + DateTime.Now.Ticks + ".tx";
            Belge.DOSYA_ADI = yol;
            Belge.ICERIK = this.SaveToPath(yol);
            Belge.BELGE_TUR_ID = 2;
            Belge.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();
            Belge.YAZILMA_TARIHI = DateTime.Now;
            Belge.STAMP = 0;

            NNProcess.SaveBelge(Belge, record);

            return Belge;
        }

        /// <summary>
        /// Yapýþtýr
        /// </summary>
        public void Paste()
        {
            this.textControl1.Paste();
        }

        /// <summary>
        /// Önizleme
        /// </summary>
        public void Preview()
        {
            PrintDocument doc = new PrintDocument();

            #region <CC-200906009>

            // sihirbazdan önizlemeye gönder dediðinde hata alýnýyordu  try catch bulaðuna alýnýp messaje box patlatýldý.

            #endregion <CC-200906009>

            doc.PrintPage += doc_PrintPage;
            try
            {
                this.textControl1.PrintPreview(doc);
            }
            catch
            {
                XtraMessageBox.Show("Bilgisayarýnýza Baðlý Bir Yazýcý Bulunamamýþtýr..", "Uyarý", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Yazdýr
        /// </summary>
        public void Print()
        {
            try
            {
                Form frmPrinterSec = new Form();
                LookUpEdit leditPrinters = new LookUpEdit();
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Yazicilar"));
                if (PrinterSettings.InstalledPrinters.Count <= 0)
                {
                    DialogResult dr = XtraMessageBox.Show("Tanýmlý yazýcý bulunamadý! Lütfen bir yazýcý tanýmlayýnýz...");
                    return;
                }
                for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
                {
                    dt.Rows.Add(PrinterSettings.InstalledPrinters[i]);
                }
                leditPrinters.Properties.DataSource = dt;
                leditPrinters.Properties.DisplayMember = "Yazicilar";
                leditPrinters.Properties.ValueMember = "Yazicilar";
                leditPrinters.Width = 100;
                leditPrinters.Top = 20;
                leditPrinters.Left = 20;
                frmPrinterSec.Width = 140;
                SimpleButton btnOk = new SimpleButton();
                btnOk.Text = "Tamam";
                btnOk.Click += delegate { frmPrinterSec.Close(); };
                btnOk.Top = 50;
                btnOk.Left = 80;
                btnOk.Width = 50;
                frmPrinterSec.Height = 90;
                frmPrinterSec.Controls.Add(btnOk);
                frmPrinterSec.Controls.Add(leditPrinters);
                frmPrinterSec.ShowDialog();
                PrintDocument doc = new PrintDocument();
                doc.PrinterSettings.PrinterName = leditPrinters.EditValue.ToString();
                doc.DocumentName = openedFileName;
                textControl1.Print(doc);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("yazdýrma sýrasýnda bir hata oluþtu!");
            }
        }

        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (WaterMarkImage != null)
            {
                Graphics g = e.Graphics;

                //g.TranslateTransform(200, 200);
                //g.RotateTransform(e.PageSettings.Landscape ? 30 : 60);
                g.DrawImage(WaterMarkImage, _waterMarkLocation);
                g.DrawString(this.WaterMark, new Font("Arial", 75, FontStyle.Bold),
                             new SolidBrush(Color.FromArgb(64, Color.Black)), 0, 0);
            }
        }

        #endregion Yazdýr Kes Kopyala Yapýþtýr Önizleme

        #region Diger Ýþlemler

        /// <summary>
        /// Bul -- Bir kelimeyi arar ve bulur
        /// </summary>
        /// <param name="searchText">aranacak Kelime</param>
        public void Find(string searchText)
        {
            this.textControl1.Find(searchText);
        }

        /// <summary>
        /// Tablxo biçimlendirme formu
        /// </summary>
        public void TableShowDialog()
        {
            textControl1.TableFormatDialog();
        }

        #endregion Diger Ýþlemler

        #region Dosya Ýþlemleri

        /// <summary>
        /// Kaydet
        /// </summary>
        ///
        public frmRaporKAydet kaydet;

        public AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE selBel;

        private BinaryStreamType acilanTipi = BinaryStreamType.InternalFormat;

        private rFrmBelgeAramaEkran belge = new rFrmBelgeAramaEkran();

        /// <summary>
        /// Editörü Temizle
        /// </summary>
        public void ClearEditor()
        {
            this.textControl1.Clear();
        }

        public void LoadFromGridControl(GridControl gc)
        {
            string filename = Application.StartupPath + @"\" + "editore" + ".rtf";
            gc.ExportToRtf(filename);
            this.textControl1.Load(filename, StreamType.RichTextFormat);
        }

        /// <summary>
        /// Yeni Dosya
        /// </summary>
        public void NewFile()
        {
            this.textControl1.Clear();
        }

        /// <summary>
        /// Aç
        /// </summary>
        public void Open()
        {
            frmDosyaAc ac = new frmDosyaAc();
            ac.Open(this);
        }

        public void OpenBelge()
        {
            belge = new rFrmBelgeAramaEkran();
            belge.editorden = true;
            belge.Show();
            belge.FormClosed += delegate
                                    {
                                        if (belge.belgem != null)
                                        {
                                            List<R_BIRLESIK_TAKIPLER_TUMU_BELGE> belgee = new List<R_BIRLESIK_TAKIPLER_TUMU_BELGE>();
                                            foreach (DataRow item in belge.belgem.Rows)
                                            {
                                                if ((bool)item["IsSelected"])
                                                {
                                                    VList<R_BIRLESIK_TAKIPLER_TUMU_BELGE> list = DataRepository.R_BIRLESIK_TAKIPLER_TUMU_BELGEProvider.Get("Id=" + item["Id"], "Id");
                                                    belgee.Add(list[0]);
                                                }
                                                //if (item.IsSelected)
                                                //    belgee.Add(item);
                                            }
                                            string uzanti = string.Empty;
                                            if (belgee.Count > 0)
                                            {
                                                R_BIRLESIK_TAKIPLER_TUMU_BELGE blg = (belgee[0]);
                                                if (blg != null && blg.ID != 0)
                                                {
                                                    selBel =
                                                        AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID(blg.ID);

                                                    if (selBel.ICERIK != null)
                                                    {
                                                        OpenFileDialog(selBel.ICERIK, null);
                                                    }
                                                    else
                                                        OpenFileDialog(selBel.ICERIK, selBel.DOKUMAN_UZANTI);
                                                }
                                            }
                                        }
                                    };
        }

        public void OpenFile(string file)
        {
            FileInfo fi = new FileInfo(file);
            if (fi.Exists)
            {
                switch (fi.Extension)
                {
                    case "dgs":
                        openedFile = OpenedFilesTypes.Degisken;
                        break;

                    case "apro":
                        openedFile = OpenedFilesTypes.Dosya;
                        break;

                    case "rpr":
                        openedFile = OpenedFilesTypes.Rapor;
                        break;

                    case "sbl":
                        openedFile = OpenedFilesTypes.Sablon;
                        break;

                    default:
                        openedFile = OpenedFilesTypes.Dosya;
                        break;
                }

                this.textControl1.Load(file, StreamType.InternalFormat);
            }
        }

        public void OpenFile()
        {
            this.textControl1.Load();
        }

        public void OpenFile(string fileName, StreamType stype)
        {
            this.textControl1.Load(fileName, stype);
        }

        public void Save(string FileName)
        {
            SaveSettings ss = new SaveSettings();
            this.textControl1.Save(FileName, StreamType.InternalFormat);
        }

        public void Save()
        {
            SavePreview();
            byte[] data;
            this.textControl1.Save(out data, BinaryStreamType.InternalFormat, new SaveSettings());
            AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR rpr =
                new AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR();
            if (OpenedRapor != null)
            {
                rpr = OpenedRapor;
            }

            rpr.DOSYA = data;
            TList<AV001_TDIE_BIL_SABLON_RAPOR> lstRaporlar = new TList<AV001_TDIE_BIL_SABLON_RAPOR>();
            lstRaporlar.Add(rpr);

            //         List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> lstRaporlar = new List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>();
            //         lstRaporlar.Add(BelgeUtil.Inits.GetRaporViewItem(rpr));
            kaydet = new frmRaporKAydet();
            AV001_TDIE_BIL_BELGE blg = new AV001_TDIE_BIL_BELGE();
            TList<AV001_TDIE_BIL_BELGE> lstBelgeler = new TList<AV001_TDIE_BIL_BELGE>();

            if (this.SelectedFoys != null)
            {
                blg = RecordGenerator.Generate.GenerateAV001_TDIE_BIL_BELGEByRecord((IEntity)this.SelectedFoys[0]);
                blg.STAMP = 0;
                lstBelgeler.Add(blg);
            }

            kaydet.Child.MyDataSource = lstRaporlar;
            kaydet.Child.MyBelgeDataSource = lstBelgeler;
            kaydet.Child.Sender = this.textControl1;
            kaydet.FormClosed += kaydet_FormClosed;

            //kaydet.MdiParent = null;
            kaydet.StartPosition = FormStartPosition.WindowsDefaultLocation;
            kaydet.Show();
        }

        public void Save(string filename, StreamType stype)
        {
            SavePreview();
            this.textControl1.Save(filename, stype);
            byte[] data;
            this.textControl1.Save(out data, BinaryStreamType.InternalFormat, new SaveSettings());
            AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR rpr =
                new AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR();
            rpr.DOSYA = data;
            ucSablonRaporKaydet usrk = new ucSablonRaporKaydet();
            usrk.Dock = DockStyle.Fill;
            ShowDialog.ExtraInfoControl = usrk;

            ShowDialog.SaveFile(this, "AV001_TDIE_BIL_SABLON_RAPOR", "AD", "KAYIT_TARIHI", "KONTROL_KIM", rpr);
        }

        /// <summary>
        /// Farklý Kaydet....
        /// </summary>
        public void SaveAs()
        {
            ///TODO : FArklý Kaydet..
            //saveFileDialog1.ShowDialog();
            textControl1.Save(StreamType.CascadingStylesheet);
        }

        /// <summary>
        /// Veri Tabanýna Kaydetme Penceresini Açar
        /// </summary>
        public void SaveToDb()
        {
            frmSablonRaporKaydet kaydet = new frmSablonRaporKaydet();
            kaydet.ShowMe(textControl1);
        }

        /// <summary>
        /// Bir klasore dosyayý kaydeder ve geriye dosyanýn byte[] tipinde verilerini döndürür
        /// </summary>
        /// <param name="Path">kaydedilecek klasor</param>
        /// <returns>dosyaya ait byte[] tipinden veriler</returns>
        public byte[] SaveToPath(string Path)
        {
            FileStream fs = new FileStream(Path, FileMode.Create);
            textControl1.Save(fs, StreamType.InternalFormat);
            byte[] veri = new byte[fs.Length];
            fs.Read(veri, 0, veri.Length);
            fs.Close();
            return veri;
        }

        /// <summary>
        /// Kontrolu temizler ... .
        /// </summary>
        public void YeniKayit()
        {
        }

        //Þablon kaydýndan yeni sablonun ilgili yere gelmesini saðlamak için eklendi. MB
        private void kaydet_FormClosed(object sender, FormClosedEventArgs e)
        {
            (this.ParentForm as frmEditor).Refresh = true;
        }

        private void OpenFileDialog(byte[] datas, string adres)
        {
            if (adres == null)
            {
                try
                {
                    textControl1.Load(datas, BinaryStreamType.InternalFormat);
                    acilanTipi = BinaryStreamType.InternalFormat;
                }
                catch (Exception)
                {
                    try
                    {
                        textControl1.Load(datas, BinaryStreamType.MSWord);
                        acilanTipi = BinaryStreamType.MSWord;
                    }
                    catch (Exception)
                    {
                        try
                        {
                            textControl1.Load(datas, BinaryStreamType.WordprocessingML);
                            acilanTipi = BinaryStreamType.WordprocessingML;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Bu Dosyayý Açamýyoruz!... Dosya Bozulmuþ olabilir...");
                        }
                    }
                }
            }
            else
            {
                try
                {
                    textControl1.Load(datas, GetByfilename(adres));
                    acilanTipi = GetByfilename(adres);
                }
                catch (Exception)
                {
                    MessageBox.Show("Bu Dosyayý Açamýyoruz!... Dosya Bozulmuþ olabilir...");
                }
            }
        }

        private void SavePreview()
        {
            Graphics graphic;
            Bitmap screenshot;
            screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height,
                                    PixelFormat.Format32bppPArgb);
            graphic = Graphics.FromImage(screenshot);
            graphic.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0,
                                   Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
        }

        #endregion Dosya Ýþlemleri

        #region IRecordable Members

        private StreamType selectedStreamType;

        public StreamType SelectedStreamType
        {
            get { return selectedStreamType; }
            set { selectedStreamType = value; }
        }

        public bool DeleteRecord(RecordInfos Record)
        {
            AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR rcd =
                ((AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR)Record.Data);
            rcd.STAMP = 3;
            AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.Save(rcd);
            return true;
        }

        public void FillExtraInfoOnSelectionChanged(RecordInfos SelectedRecord, Control ExtraInfoControl)
        {
            if (SelectedRecord.SelectedFrom == LoadFromType.FromTable)
            {
                ExtraInfoControl.Visible = true;
                TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR> lstrapors =
                    new TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR>();
                lstrapors.Add(((AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR)SelectedRecord.Data));
                ((ucSablonRaporKaydet)ExtraInfoControl).Datas = lstrapors;
            }
            else
            {
                ExtraInfoControl.Visible = false;
            }
        }

        public bool OpenRecord(RecordInfos Record)
        {
            try
            {
                if (this.Parent != null)
                    this.Parent.Text = Record.Name;
                textControl1.CreateControl();
                textControl1.Show();

                if (Record.SelectedFrom == LoadFromType.FromTable)
                {
                    AV001_TDIE_BIL_SABLON_RAPOR rpr = new AV001_TDIE_BIL_SABLON_RAPOR();
                    if (Record.Data is AV001_TDIE_BIL_SABLON_RAPOR)
                        rpr = Record.Data as AV001_TDIE_BIL_SABLON_RAPOR;
                    else if (Record.Data is AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)
                        rpr = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.GetByID(((AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)Record.Data).ID);

                    byte[] datas = rpr.DOSYA;
                    string adres = rpr.DOSYA_ADRES;
                    if (adres == null || adres.Trim().Length == 0)
                    {
                        try
                        {
                            textControl1.Load(datas, BinaryStreamType.InternalFormat);
                        }
                        catch (Exception)
                        {
                            try
                            {
                                textControl1.Load(datas, BinaryStreamType.MSWord);
                            }
                            catch (Exception)
                            {
                                try
                                {
                                    textControl1.Load(datas, BinaryStreamType.WordprocessingML);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Bu Dosyayý Açamýyoruz!... Dosya Bozulmuþ olabilir...");
                                }
                            }
                        }
                    }
                    else
                    {
                        textControl1.Load(datas, GetByfilename(adres));
                    }

                    this.OpenedRapor = rpr;
                    AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.DeepLoad(rpr, false,
                                                                                                   AvukatProLib2.Data.
                                                                                                       DeepLoadType.
                                                                                                       IncludeChildren,
                                                                                                   typeof(
                                                                                                       TList
                                                                                                       <
                                                                                                       AV001_TDIE_BIL_SABLON_SECILI_BELGE
                                                                                                       >));
                    List<int> lstFomrs = new List<int>();
                    for (int i = 0; i < rpr.AV001_TDIE_BIL_SABLON_SECILI_BELGECollection.Count; i++)
                    {
                        lstFomrs.Add(rpr.AV001_TDIE_BIL_SABLON_SECILI_BELGECollection[i].ID);
                    }
                }
                else
                {
                    textControl1.Load(Record.Name, selectedStreamType);
                }
                return true;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
            return false;
        }

        public int SaveRecord(RecordInfos Record)
        {
            try
            {
                AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR rpr =
                    ((AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR)Record.Data);
                this.OpenedRapor = rpr;
                if (rpr == null)
                {
                    return 0;
                }

                ucSablonRaporKaydet srk = (ucSablonRaporKaydet)ShowDialog.ExtraInfoControl;
                rpr = srk.Datas[0];
                byte[] veri = new byte[1];
                rpr.DOSYA_ADRES = rpr.AD + "." + Record.Extension;
                textControl1.Save(out veri, GetByfilename(rpr.DOSYA_ADRES));
                rpr.DOSYA = veri;

                //rpr.AD = Record.NameValue;
                //rpr.ACIKLAMA = Record.Description;

                AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.Save(rpr);
                textControl1.Save(SelectedStreamType);

                WriteDataFieldsToXml(rpr.AD);

                ///TODO : Dosya Adý Alýnacak Db ye Yazýlac ak ...
                if (Record.IdValue is int)
                {
                    return Convert.ToInt32(Record.IdValue);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
            return 0;
        }

        private BinaryStreamType GetByfilename(string filename)
        {
            string ext = "";
            if (string.IsNullOrEmpty(filename))
            {
                ext = "doc";
            }
            else
            {
                string[] strl = filename.Split('.');
                ext = strl[strl.Length - 1];
            }
            switch (ext)
            {
                case "doc":
                    return BinaryStreamType.MSWord;

                case "tx":
                    return BinaryStreamType.InternalFormat;

                case "docx":
                    return BinaryStreamType.MSWord;

                case "pdf":
                    return BinaryStreamType.AdobePDF;

                default:
                    break;
            }
            return BinaryStreamType.InternalFormat;
        }

        #endregion IRecordable Members
    }
}