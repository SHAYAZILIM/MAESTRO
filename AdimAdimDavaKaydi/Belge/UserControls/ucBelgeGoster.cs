using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraNavBar;
using DevExpress.XtraVerticalGrid.Rows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using TXTextControl;

namespace AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge
{
    public enum FileOpenTypes
    {
        Save,
        Open,
        Delete,
        SaveAs,
        Other
    }

    public enum FileTypes
    {
        doc,
        docx,
        rtf,
        txt,
        tx,
        pdf,
        html,
        xml,
        htm
    }

    public enum LoadFromType
    {
        FromFolder,
        FromTable,
    }

    public interface IDataRecordable
    {
        bool OpenRecord(RecordInfos Record);

        int SaveRecord(RecordInfos Record);
    }

    public interface IRecordable : IDataRecordable
    {
        StreamType SelectedStreamType { get; set; }

        bool DeleteRecord(RecordInfos Record);

        void FillExtraInfoOnSelectionChanged(RecordInfos SelectedRecord, Control ExtraInfoControl);
    }

    public class DosyaIslemleri
    {
        public static void FillFileTypeCombo(ComboBoxEdit cmb)
        {
            cmb.Properties.Items.AddRange(Enum.GetNames(typeof(FileTypes)));
        }

        public static void FillFileTypeLookUp(RepositoryItemLookUpEdit rlue)
        {
            rlue.DataSource = Enum.GetNames(typeof(FileTypes));
            //rlue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Dosya_tipi", 150, "Dosya Tipi"));
        }

        public static void FillFileTypeLookUp(LookUpEdit rlue)
        {
            rlue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Dosya_Tipi", 150,
                                                                                             "Dosya Tipi"));
            rlue.Properties.DataSource = Enum.GetNames(typeof(FileTypes));
        }

        public static StreamType GetStreamType(FileTypes ft)
        {
            StreamType returnValue = StreamType.InternalFormat;
            switch (ft)
            {
                case FileTypes.doc:
                    returnValue = StreamType.MSWord;
                    break;

                case FileTypes.docx:
                    returnValue = StreamType.MSWord;
                    break;

                case FileTypes.rtf:
                    returnValue = StreamType.RichTextFormat;
                    break;

                case FileTypes.txt:
                    returnValue = StreamType.PlainText;
                    break;

                case FileTypes.tx:
                    returnValue = StreamType.InternalFormat;
                    break;

                case FileTypes.pdf:
                    returnValue = StreamType.AdobePDF;
                    break;

                case FileTypes.html:
                    returnValue = StreamType.HTMLFormat;
                    break;

                case FileTypes.htm:
                    returnValue = StreamType.HTMLFormat;
                    break;

                case FileTypes.xml:
                    returnValue = StreamType.XMLFormat;
                    break;

                default:
                    returnValue = StreamType.InternalFormat;
                    break;
            }
            return returnValue;
        }
    }

    public class ExtraInfo
    {
        public string Name { get; set; }

        public object Value { get; set; }
    }

    public class RecordInfos
    {
        public DateTime AccesDate { get; set; }

        public string Container { get; set; }

        public object Data { get; set; }

        public string Description { get; set; }

        public string Extension { get; set; }

        public List<ExtraInfo> ExtraInfos { get; set; }

        public string IdColumn { get; set; }

        public object IdValue { get; set; }

        public DateTime LastchangeDate { get; set; }

        public string Name { get; set; }

        public string NameValue { get; set; }

        public FileTypes SelectedFilesType { get; set; }

        public LoadFromType SelectedFrom { get; set; }

        public object Sources { get; set; }

        public string WriteDate { get; set; }
    }

    public class ShowDialog
    {
        public static bool DescriptionVisible = true;
        public static bool LocationVisible = true;
        public static bool NameVisible = true;
        private static Control extraInfoControl;

        public static Control ExtraInfoControl
        {
            get { return extraInfoControl; }
            set { extraInfoControl = value; }
        }

        #region OpenFile()

        public static DialogResult OpenFile(IRecordable _parent, string Table, string folder, string textColumn,
                                            string nameColumn, string imagekeycolumn, string writeDateColumn,
                                            string creatorColumn, string program, List<string> extensions)
        {
            ucBelgeGoster bg = new ucBelgeGoster(_parent, folder, Table, nameColumn, textColumn, imagekeycolumn,
                                                 writeDateColumn, creatorColumn, program, extensions);
            SetBelgeGoster(bg);
            Form frm = new Form();
            frm.Controls.Add(bg);
            bg.Dock = DockStyle.Fill;
            frm.ControlBox = false;
            frm.Text = "Dosya Aç";
            bg.FileOpentype = FileOpenTypes.Open;
            frm.Width = 800;
            frm.Height = 600;
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;

            //frm.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            return frm.ShowDialog();
        }

        public static DialogResult OpenFile(IRecordable _parent, string Table, string textColumn, string nameColumn,
                                            string imagekeycolumn, string writeDateColumn, string creatorColumn,
                                            string program)
        {
            return OpenFile(_parent, Table, "", textColumn, nameColumn, imagekeycolumn, writeDateColumn, creatorColumn,
                            program, new List<string>());
        }

        public static DialogResult OpenFile(IRecordable _parent, string Table, string textColumn, string nameColumn,
                                            string imagekeycolumn, string writeDateColumn, string creatorColumn)
        {
            return OpenFile(_parent, Table, "", textColumn, nameColumn, imagekeycolumn, writeDateColumn, creatorColumn,
                            "", new List<string>());
        }

        public static DialogResult OpenFile(IRecordable _parent, string Table, string textColumn, string imagekeycolumn,
                                            string writeDateColumn, string creatorColumn)
        {
            return OpenFile(_parent, Table, "", textColumn, "", imagekeycolumn, writeDateColumn, creatorColumn, "",
                            new List<string>());
        }

        public static DialogResult OpenFile(IRecordable _parent, string Table, string nameColumn, string writeDateColumn,
                                            string creatorColumn)
        {
            return OpenFile(_parent, Table, "", "", nameColumn, "", writeDateColumn, creatorColumn, "",
                            new List<string>());
        }

        public static DialogResult OpenFile(IRecordable _parent, string Table, string nameColumn)
        {
            return OpenFile(_parent, Table, "", "", nameColumn, "", "", "", "", new List<string>());
        }

        #endregion OpenFile()

        #region saveFile()

        public static DialogResult SaveFile(IRecordable _parent, string Table, string folder, string textColumn,
                                            string nameColumn, string imagekeycolumn, string writeDateColumn,
                                            string creatorColumn, string program, List<string> extensions, object data)
        {
            ucBelgeGoster bgSave = new ucBelgeGoster(_parent, folder, Table, nameColumn, textColumn, imagekeycolumn,
                                                     writeDateColumn, creatorColumn, program, extensions, data);
            SetBelgeGoster(bgSave);
            Form frm = new Form();
            frm.Controls.Add(bgSave);
            bgSave.FileOpentype = FileOpenTypes.Save;
            bgSave.Dock = DockStyle.Fill;
            frm.ControlBox = false;
            frm.Text = "Dosya Kaydet";
            frm.Width = 800;
            frm.Height = 600;
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;

            //frm.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            return frm.ShowDialog();
        }

        public static DialogResult SaveFile(IRecordable _parent, string Table, string textColumn, string nameColumn,
                                            string imagekeycolumn, string writeDateColumn, string creatorColumn,
                                            string program, object data)
        {
            return SaveFile(_parent, Table, "", textColumn, nameColumn, imagekeycolumn, writeDateColumn, creatorColumn,
                            program, new List<string>(), data);
        }

        public static DialogResult SaveFile(IRecordable _parent, string Table, string textColumn, string nameColumn,
                                            string imagekeycolumn, string writeDateColumn, string creatorColumn,
                                            object data)
        {
            return SaveFile(_parent, Table, "", textColumn, nameColumn, imagekeycolumn, writeDateColumn, creatorColumn,
                            "", new List<string>(), data);
        }

        public static DialogResult SaveFile(IRecordable _parent, string Table, string textColumn, string imagekeycolumn,
                                            string writeDateColumn, string creatorColumn, object data)
        {
            return SaveFile(_parent, Table, "", textColumn, "", imagekeycolumn, writeDateColumn, creatorColumn, "",
                            new List<string>(), data);
        }

        public static DialogResult SaveFile(IRecordable _parent, string Table, string nameColumn, string writeDateColumn,
                                            string creatorColumn, object data)
        {
            return SaveFile(_parent, Table, "", "", nameColumn, "", writeDateColumn, creatorColumn, "",
                            new List<string>(), data);
        }

        public static DialogResult SaveFile(IRecordable _parent, string Table, string nameColumn)
        {
            return SaveFile(_parent, Table, "", "", nameColumn, "", "", "", "", new List<string>(), new object());
        }

        private static ucBelgeGoster SetBelgeGoster(ucBelgeGoster bg)
        {
            // bg = new ucBelgeGoster(parent, folder, Table, nameColumn, textColumn, imagekeycolumn, writeDateColumn, creatorColumn, program, extensions);
            bg.ExtraInfoControl = extraInfoControl;

            bg.NameVisible = NameVisible;
            bg.DescriptionVisible = DescriptionVisible;
            bg.LocationViewerVisible = LocationVisible;

            return bg;
        }

        #endregion saveFile()

        #region DeleteFile()

        public static DialogResult DeleteFile(IRecordable _parent, string Table, string folder, string textColumn,
                                              string nameColumn, string imagekeycolumn, string writeDateColumn,
                                              string creatorColumn, string program, List<string> extensions)
        {
            ucBelgeGoster bg = new ucBelgeGoster(_parent, folder, Table, nameColumn, textColumn, imagekeycolumn,
                                                 writeDateColumn, creatorColumn, program, extensions);
            SetBelgeGoster(bg);
            Form frm = new Form();
            frm.Controls.Add(bg);
            bg.Dock = DockStyle.Fill;
            frm.ControlBox = false;
            frm.Text = "Dosya Sil";
            bg.FileOpentype = FileOpenTypes.Delete;
            frm.Width = 800;
            frm.Height = 600;
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;

            //frm.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            return frm.ShowDialog();
        }

        public static DialogResult DeleteFile(IRecordable _parent, string Table, string textColumn, string nameColumn,
                                              string imagekeycolumn, string writeDateColumn, string creatorColumn,
                                              string program)
        {
            return DeleteFile(_parent, Table, "", textColumn, nameColumn, imagekeycolumn, writeDateColumn, creatorColumn,
                              program, new List<string>());
        }

        public static DialogResult DeleteFile(IRecordable _parent, string Table, string textColumn, string nameColumn,
                                              string imagekeycolumn, string writeDateColumn, string creatorColumn)
        {
            return DeleteFile(_parent, Table, "", textColumn, nameColumn, imagekeycolumn, writeDateColumn, creatorColumn,
                              "", new List<string>());
        }

        public static DialogResult DeleteFile(IRecordable _parent, string Table, string textColumn,
                                              string imagekeycolumn, string writeDateColumn, string creatorColumn)
        {
            return DeleteFile(_parent, Table, "", textColumn, "", imagekeycolumn, writeDateColumn, creatorColumn, "",
                              new List<string>());
        }

        public static DialogResult DeleteFile(IRecordable _parent, string Table, string nameColumn,
                                              string writeDateColumn, string creatorColumn)
        {
            return DeleteFile(_parent, Table, "", "", nameColumn, "", writeDateColumn, creatorColumn, "",
                              new List<string>());
        }

        public static DialogResult DeleteFile(IRecordable _parent, string Table, string nameColumn)
        {
            return DeleteFile(_parent, Table, "", "", nameColumn, "", "", "", "", new List<string>());
        }

        #endregion DeleteFile()

        #region belgeGosterEvents


        #endregion belgeGosterEvents

        #region EventDelegates

        public delegate void OnCancelButton(
            object sender, List<RecordInfos> selectedFiles, string selectedrecordContainer);

        public delegate void OnClosed(object sender, object parent, object selectedrecordContainer, int itemsCount);

        public delegate void OnOkButton(
            object sender, List<RecordInfos> selectedFiles, string selectedrecordContainer,
            StreamType SelectedStreamType);

        public delegate void OnOpened(object sender, object parent, object selectedrecordContainer, int itemsCount);

        public delegate void OnOpening(object sender, object parent, object selectedrecordContainer, int itemsCount);

        public delegate void OnSelected(object sender, List<RecordInfos> selectedFiles, string selectedrecordContainer);

        public delegate void OnSelectedChanged(
            object sender, List<RecordInfos> selectedFiles, string selectedrecordContainer);

        #endregion EventDelegates
    }

    public partial class ucBelgeGoster : DevExpress.XtraEditors.XtraUserControl
    {
        #region Properties

        private FileOpenTypes fileOpenType;

        public string CreatorColumn { get; set; }

        public object Data { get; set; }

        public bool DescriptionVisible
        {
            get { return panelControl3.Visible; }
            set { panelControl3.Visible = value; }
        }

        public string[] Extensions { get; set; }

        public NavBarControl ExtraInfoContainer { get; set; }

        public Control ExtraInfoControl { get; set; }

        public FileOpenTypes FileOpentype
        {
            get { return fileOpenType; }
            set { fileOpenType = value; }
        }

        public string Folder { get; set; }

        public string ImageKeyColumn { get; set; }

        public bool IsGetFromFileCheckEditVisible
        {
            get { return this.checkEdit1.Visible; }
            set { this.checkEdit1.Visible = value; }
        }

        public bool IsGetFromFolderButtonVisible
        {
            get { return this.simpleButton5.Visible; }
            set { this.simpleButton5.Visible = value; }
        }

        public LoadFromType LoadType { get; set; }

        public bool LocationViewerVisible
        {
            get { return labelControl1.Visible; }
            set
            {
                labelControl1.Visible = value;
                lookUpEdit2.Visible = value;
                if (value)
                {
                    panelControl6.Height = 55;
                }
                else
                {
                    panelControl6.Height = 27;
                }
            }
        }

        public string NameColumn { get; set; }

        public bool NameVisible
        {
            get { return panelControl2.Visible; }
            set { panelControl2.Visible = value; }
        }

        public IRecordable ParentControl { get; set; }

        public string Programs { get; set; }

        public string Table { get; set; }

        public string TextColumn { get; set; }

        public string WriteDateColumn { get; set; }

        #endregion Properties

        #region vars

        private bool getFromFolder;
        private bool getFromTable;

        #endregion vars

        #region Constr

        public ucBelgeGoster(IRecordable _ParentControl, string folder, string table,
                             string nameColumn, string textColumn, string imageKeycolumn, string writeDateColumn,
                             string CreatorColumn, string program, List<string> extensions, object data)
        {
            ParentControl = _ParentControl;
            Folder = folder;
            Table = table;
            NameColumn = nameColumn;
            TextColumn = textColumn;
            ImageKeyColumn = imageKeycolumn;
            WriteDateColumn = writeDateColumn;
            this.CreatorColumn = CreatorColumn;
            Programs = program;
            Extensions = extensions.ToArray();
            Data = data;
            this.ParentControl = _ParentControl;

            InitializeComponent();

            if (string.IsNullOrEmpty(folder))
            {
                LoadType = LoadFromType.FromTable;

                //    this.GetFilesFromTable(table, imageKeycolumn, textColumn, nameColumn, writeDateColumn, CreatorColumn, program, extensions);
            }
            else
            {
                LoadType = LoadFromType.FromFolder;
                this.GetFilesFromFolder(folder, "", "");
            }
            DosyaIslemleri.FillFileTypeCombo(comboBoxEdit1);
            Data = data;
        }

        public ucBelgeGoster(IRecordable _ParentControl, string folder, string table, string nameColumn,
                             string textColumn, string imageKeycolumn, string writeDateColumn, string CreatorColumn,
                             string program, List<string> extension)
            :
                this(_ParentControl, folder, table, nameColumn,
                     textColumn, imageKeycolumn, writeDateColumn, CreatorColumn,
                     program, extension, new object())
        {
        }

        #endregion Constr

        #region EventDelegates

        public delegate void OnCancelButton(
            object sender, List<RecordInfos> selectedFiles, string selectedrecordContainer);

        public delegate void OnClosed(object sender, object parent, object selectedrecordContainer, int itemsCount);

        public delegate void OnOkButton(
            object sender, List<RecordInfos> selectedFiles, string selectedrecordContainer,
            StreamType SelectedStreamType);

        public delegate void OnOpened(object sender, object parent, object selectedrecordContainer, int itemsCount);

        public delegate void OnOpening(object sender, object parent, object selectedrecordContainer, int itemsCount);

        public delegate void OnSelected(object sender, List<RecordInfos> selectedFiles, string selectedrecordContainer);

        public delegate void OnSelectedChanged(
            object sender, List<RecordInfos> selectedFiles, string selectedrecordContainer);

        #endregion EventDelegates

        #region EventMothods

        #endregion EventMothods

        //ListView lvRemove = new ListView();
        private ListView lv = new ListView();

        private System.Windows.Forms.ListView.ListViewItemCollection removedItems;

        public void FillFiles()
        {
            this.listView1.Items.Clear();
            if (getFromTable)
            {
            }
            if (getFromFolder)
            {
                GetFilesFromFolder();
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            getFromFolder = checkEdit1.Checked;
            FillFiles();
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            getFromTable = checkEdit2.Checked;
            FillFiles();
        }

        /// <summary>
        /// SEÇÝLEN kayýt deðiþtiðinde...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                List<RecordInfos> selectedItems = GetRecordInfosFromSelectedItems();
                ParentControl.FillExtraInfoOnSelectionChanged(selectedItems[0], ExtraInfoControl);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            RecordInfos rinfs = new RecordInfos();
            string[] uzantiIcinParcalar = openFileDialog1.FileName.Split('.');
            string uzanti = uzantiIcinParcalar[uzantiIcinParcalar.Length - 1];
            ParentControl.SelectedStreamType =
                DosyaIslemleri.GetStreamType((FileTypes)Enum.Parse(typeof(FileTypes), uzanti.ToLower()));

            LoadType = LoadFromType.FromFolder;
            rinfs.Name = openFileDialog1.FileName;

            rinfs.SelectedFrom = LoadType;

            this.ParentControl.OpenRecord(rinfs);
            this.FindForm().Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            switch (fileOpenType)
            {
                case FileOpenTypes.Save:
                    if (comboBoxEdit1.EditValue == null)
                    {
                        XtraMessageBox.Show("Lütfen Bir Dosya Tipi Seçiniz ... ", "Eksik Alan", MessageBoxButtons.OK);
                        return;
                    }
                    ParentControl.SelectedStreamType =
                        DosyaIslemleri.GetStreamType(
                            (FileTypes)Enum.Parse(typeof(FileTypes), comboBoxEdit1.EditValue.ToString()));

                    RecordInfos rinf = new RecordInfos();
                    rinf.SelectedFrom = LoadType;
                    rinf.Data = Data;
                    rinf.NameValue = textEdit1.Text;
                    rinf.Description = memoEdit1.Text;
                    rinf.Extension = comboBoxEdit1.EditValue.ToString();
                    this.ParentControl.SaveRecord(rinf);

                    break;

                case FileOpenTypes.Open:
                    this.ParentControl.OpenRecord(GetRecordInfosFromSelectedItems()[0]);
                    break;

                case FileOpenTypes.Delete:
                    break;

                case FileOpenTypes.SaveAs:
                    break;

                case FileOpenTypes.Other:
                    break;

                default:
                    break;
            }

            this.FindForm().Close();
        }

        /// <summary>
        /// Formu bul / Formu Kapat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                bool IsFiltered = false;
                for (int y = 0; y < c_vgrdFiltre.Rows.Count; y++)
                {
                    System.Reflection.PropertyInfo pinf =
                        listView1.Items[i].Tag.GetType().GetProperty(c_vgrdFiltre.Rows[y].Properties.FieldName);
                    if (pinf != null)
                    {
                        object val = pinf.GetValue(listView1.Items[i].Tag, null);
                        if (val != null)
                        {
                            object grdVal = c_vgrdFiltre.GetCellValue(c_vgrdFiltre.Rows[y], 0);
                            if (grdVal != null)
                            {
                                if (val.ToString() != grdVal.ToString())
                                {
                                    IsFiltered = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (IsFiltered)
                {
                    if (removedItems == null)
                    {
                        removedItems = new ListView.ListViewItemCollection(lv);
                    }
                    ListViewItem lwi = new ListViewItem();
                    lwi.Name = listView1.Items[i].Name;
                    lwi.Text = listView1.Items[i].Text;
                    lwi.ToolTipText = listView1.Items[i].ToolTipText;
                    lwi.Tag = listView1.Items[i].Tag;
                    removedItems.Add(lwi);
                    //lvRemove.Items.Add(lwi);
                }
            }
            listView1 = lv;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void ucBelgeGoster_Load(object sender, EventArgs e)
        {
            this.ExtraInfosPanel.Controls.Add(ExtraInfoControl);
        }

        #region GetFilesFromFolder

        private void GetFilesFromFolder()
        {
            GetFilesFromFolder(this.Folder, ImageKeyColumn, TextColumn);
        }

        private void GetFilesFromFolder(string folder, string imageKeyColumn, string textColumn)
        {
            string[] files = Directory.GetFiles(folder);
            for (int i = 0; i < files.Length; i++)
            {
                string[] uzantiIcinParcalar = files[i].Split('.');
                string uzanti = uzantiIcinParcalar[uzantiIcinParcalar.Length - 1];
                string[] fileFolderSplit;
                if (files[i].Contains("/"))
                {
                    fileFolderSplit = files[i].Split('/');
                }
                else
                {
                    fileFolderSplit = files[i].Split('\\');
                }

                string dosyaAdi = fileFolderSplit[fileFolderSplit.Length - 1];
                ListViewItem lwi = new ListViewItem(dosyaAdi, uzanti);
                lwi.Name = files[i];
                listView1.Items.Add(lwi);
                FilesInListView finLw = new FilesInListView();
                finLw.Extension = uzanti;
                finLw.Name = dosyaAdi;
                lwi.Tag = finLw;
            }

            EditorRow er = new EditorRow();
            er.Properties.Caption = "Dosya : ";
            er.Properties.FieldName = "Name";
            EditorRow er2 = new EditorRow();
            er2.Properties.Caption = "Uzantýsý : ";
            er2.Properties.FieldName = "Extension";

            this.c_vgrdFiltre.Rows.Add(er);
            this.c_vgrdFiltre.Rows.Add(er2);
        }

        public class FilesInListView
        {
            public string Extension { get; set; }

            public int Id { get; set; }

            public string Name { get; set; }
        }

        #endregion GetFilesFromFolder

        #region Get Record Info

        /// <summary>
        /// ListView Nesnesinni Record infoya donusturur...
        /// </summary>
        /// <param name="lwitem"></param>
        /// <returns></returns>
        private RecordInfos GetrecordInfoFromItem(ListViewItem lwitem)
        {
            RecordInfos rinfs = new RecordInfos();

            if (lwitem.Name.StartsWith("_"))
            {
                LoadType = LoadFromType.FromTable;
            }
            else
            {
                string[] uzantiIcinParcalar = lwitem.Name.Split('.');
                string uzanti = uzantiIcinParcalar[uzantiIcinParcalar.Length - 1];
                ParentControl.SelectedStreamType =
                    DosyaIslemleri.GetStreamType((FileTypes)Enum.Parse(typeof(FileTypes), uzanti.ToLower()));

                LoadType = LoadFromType.FromFolder;
                rinfs.Name = lwitem.Name;
            }
            rinfs.SelectedFrom = LoadType;

            rinfs.Data = lwitem.Tag;

            return rinfs;
            //listView1.SelectedItems[i].Text;
        }

        /// <summary>
        /// ListView1 de secili olan itemlari record info dizisi halinde verir...
        /// </summary>
        /// <returns></returns>
        private List<RecordInfos> GetRecordInfosFromSelectedItems()
        {
            List<RecordInfos> lstRecords = new List<RecordInfos>();
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                lstRecords.Add(GetrecordInfoFromItem(listView1.SelectedItems[i]));
            }
            return lstRecords;
        }

        #endregion Get Record Info
    }
}