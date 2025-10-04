using AvukatProLib2.Entities;
namespace  ImportExportWithSelection.Import
{
    partial class frmImportFromExcel<T> where T: IEntity , new()
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMask = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueMask = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMaskType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueMaskeTipi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTablo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKolon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdColumns = new DevExpress.XtraGrid.GridControl();
            this.columnsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCaption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecord = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsNull = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolMaskeEkle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rbtnMaskeEkle = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.grdSonuc = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdSecim = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcolCaption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExcelCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueExcelAlan = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.pnlIlk = new DevExpress.XtraEditors.PanelControl();
            this.grdSheets = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtDosya = new DevExpress.XtraEditors.TextEdit();
            this.btnDevam1 = new DevExpress.XtraEditors.SimpleButton();
            this.pnlSecim = new DevExpress.XtraEditors.PanelControl();
            this.btnSonuc = new DevExpress.XtraEditors.SimpleButton();
            this.btnTamam = new DevExpress.XtraEditors.SimpleButton();
            this.opfDosyaSec = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueMask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueMaskeTipi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnMaskeEkle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSonuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSecim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueExcelAlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlIlk)).BeginInit();
            this.pnlIlk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSheets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosya.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSecim)).BeginInit();
            this.pnlSecim.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView5
            // 
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colValue,
            this.colMask,
            this.colMaskType,
            this.colTablo,
            this.colKolon});
            this.gridView5.GridControl = this.grdColumns;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            // 
            // colValue
            // 
            this.colValue.Caption = "Deðer";
            this.colValue.FieldName = "Value";
            this.colValue.Name = "colValue";
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 0;
            // 
            // colMask
            // 
            this.colMask.Caption = "Maske";
            this.colMask.ColumnEdit = this.rlueMask;
            this.colMask.FieldName = "Mask";
            this.colMask.Name = "colMask";
            this.colMask.Visible = true;
            this.colMask.VisibleIndex = 1;
            // 
            // rlueMask
            // 
            this.rlueMask.AutoHeight = false;
            this.rlueMask.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueMask.Name = "rlueMask";
            // 
            // colMaskType
            // 
            this.colMaskType.Caption = "Maske Tipi";
            this.colMaskType.ColumnEdit = this.rlueMaskeTipi;
            this.colMaskType.FieldName = "MaskType";
            this.colMaskType.Name = "colMaskType";
            this.colMaskType.Visible = true;
            this.colMaskType.VisibleIndex = 2;
            // 
            // rlueMaskeTipi
            // 
            this.rlueMaskeTipi.AutoHeight = false;
            this.rlueMaskeTipi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueMaskeTipi.Name = "rlueMaskeTipi";
            // 
            // colTablo
            // 
            this.colTablo.Caption = "Tablo";
            this.colTablo.FieldName = "Tablo";
            this.colTablo.Name = "colTablo";
            this.colTablo.Visible = true;
            this.colTablo.VisibleIndex = 3;
            // 
            // colKolon
            // 
            this.colKolon.Caption = "Kolon";
            this.colKolon.FieldName = "Kolon";
            this.colKolon.Name = "colKolon";
            this.colKolon.Visible = true;
            this.colKolon.VisibleIndex = 4;
            // 
            // grdColumns
            // 
            this.grdColumns.DataSource = this.columnsBindingSource;
            gridLevelNode2.LevelTemplate = this.gridView5;
            gridLevelNode2.RelationName = "Maskeler";
            this.grdColumns.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.grdColumns.Location = new System.Drawing.Point(15, 132);
            this.grdColumns.MainView = this.gridView4;
            this.grdColumns.Name = "grdColumns";
            this.grdColumns.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueMaskeTipi,
            this.rlueMask,
            this.rbtnMaskeEkle});
            this.grdColumns.Size = new System.Drawing.Size(406, 323);
            this.grdColumns.TabIndex = 1;
            this.grdColumns.UseEmbeddedNavigator = true;
            this.grdColumns.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4,
            this.gridView5});
            // 
            // columnsBindingSource
            // 
            this.columnsBindingSource.DataSource = typeof(ImportExportWithSelection.Import.Columns);
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colColumn,
            this.colCaption,
            this.colRecord,
            this.colIsNull,
            this.colDataType,
            this.gcolMaskeEkle});
            this.gridView4.GridControl = this.grdColumns;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView4.OptionsDetail.AutoZoomDetail = true;
            this.gridView4.OptionsDetail.SmartDetailHeight = true;
            this.gridView4.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            // 
            // colColumn
            // 
            this.colColumn.Caption = "Column";
            this.colColumn.FieldName = "Column";
            this.colColumn.Name = "colColumn";
            this.colColumn.Visible = true;
            this.colColumn.VisibleIndex = 0;
            // 
            // colCaption
            // 
            this.colCaption.Caption = "Caption";
            this.colCaption.FieldName = "Caption";
            this.colCaption.Name = "colCaption";
            this.colCaption.Visible = true;
            this.colCaption.VisibleIndex = 1;
            // 
            // colRecord
            // 
            this.colRecord.Caption = "Record";
            this.colRecord.FieldName = "Record";
            this.colRecord.Name = "colRecord";
            this.colRecord.Visible = true;
            this.colRecord.VisibleIndex = 2;
            // 
            // colIsNull
            // 
            this.colIsNull.Caption = "IsNull";
            this.colIsNull.FieldName = "IsNull";
            this.colIsNull.Name = "colIsNull";
            this.colIsNull.Visible = true;
            this.colIsNull.VisibleIndex = 3;
            // 
            // colDataType
            // 
            this.colDataType.Caption = "DataType";
            this.colDataType.FieldName = "DataType";
            this.colDataType.Name = "colDataType";
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 4;
            // 
            // gcolMaskeEkle
            // 
            this.gcolMaskeEkle.Caption = "Maske";
            this.gcolMaskeEkle.ColumnEdit = this.rbtnMaskeEkle;
            this.gcolMaskeEkle.Name = "gcolMaskeEkle";
            this.gcolMaskeEkle.Visible = true;
            this.gcolMaskeEkle.VisibleIndex = 5;
            // 
            // rbtnMaskeEkle
            // 
            this.rbtnMaskeEkle.AutoHeight = false;
            this.rbtnMaskeEkle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rbtnMaskeEkle.Name = "rbtnMaskeEkle";
            this.rbtnMaskeEkle.NullText = "Ekle";
            // 
            // grdSonuc
            // 
            this.grdSonuc.Enabled = false;
            this.grdSonuc.Location = new System.Drawing.Point(217, 519);
            this.grdSonuc.MainView = this.gridView1;
            this.grdSonuc.Name = "grdSonuc";
            this.grdSonuc.Size = new System.Drawing.Size(813, 83);
            this.grdSonuc.TabIndex = 0;
            this.grdSonuc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdSonuc;
            this.gridView1.Name = "gridView1";
            // 
            // grdSecim
            // 
            this.grdSecim.Location = new System.Drawing.Point(5, 11);
            this.grdSecim.MainView = this.gridView2;
            this.grdSecim.Name = "grdSecim";
            this.grdSecim.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueExcelAlan});
            this.grdSecim.Size = new System.Drawing.Size(403, 421);
            this.grdSecim.TabIndex = 1;
            this.grdSecim.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcolCaption,
            this.colExcelCol});
            this.gridView2.GridControl = this.grdSecim;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            // 
            // colcolCaption
            // 
            this.colcolCaption.Caption = "Alan";
            this.colcolCaption.FieldName = "Column";
            this.colcolCaption.Name = "colcolCaption";
            this.colcolCaption.Visible = true;
            this.colcolCaption.VisibleIndex = 0;
            // 
            // colExcelCol
            // 
            this.colExcelCol.Caption = "Exceldeki Alan";
            this.colExcelCol.ColumnEdit = this.rlueExcelAlan;
            this.colExcelCol.FieldName = "SelectedColumn";
            this.colExcelCol.Name = "colExcelCol";
            this.colExcelCol.Visible = true;
            this.colExcelCol.VisibleIndex = 1;
            // 
            // rlueExcelAlan
            // 
            this.rlueExcelAlan.AutoHeight = false;
            this.rlueExcelAlan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueExcelAlan.Name = "rlueExcelAlan";
            // 
            // pnlIlk
            // 
            this.pnlIlk.Controls.Add(this.grdColumns);
            this.pnlIlk.Controls.Add(this.grdSheets);
            this.pnlIlk.Controls.Add(this.txtDosya);
            this.pnlIlk.Location = new System.Drawing.Point(12, 12);
            this.pnlIlk.Name = "pnlIlk";
            this.pnlIlk.Size = new System.Drawing.Size(426, 460);
            this.pnlIlk.TabIndex = 2;
            // 
            // grdSheets
            // 
            this.grdSheets.Location = new System.Drawing.Point(15, 41);
            this.grdSheets.MainView = this.gridView3;
            this.grdSheets.Name = "grdSheets";
            this.grdSheets.Size = new System.Drawing.Size(406, 85);
            this.grdSheets.TabIndex = 1;
            this.grdSheets.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.grdSheets;
            this.gridView3.Name = "gridView3";
            // 
            // txtDosya
            // 
            this.txtDosya.Location = new System.Drawing.Point(15, 15);
            this.txtDosya.Name = "txtDosya";
            this.txtDosya.Size = new System.Drawing.Size(406, 20);
            this.txtDosya.TabIndex = 1;
            this.txtDosya.EditValueChanged += new System.EventHandler(this.txtDosya_EditValueChanged);
            this.txtDosya.Click += new System.EventHandler(this.txtDosya_Click);
            // 
            // btnDevam1
            // 
            this.btnDevam1.Location = new System.Drawing.Point(154, 478);
            this.btnDevam1.Name = "btnDevam1";
            this.btnDevam1.Size = new System.Drawing.Size(153, 17);
            this.btnDevam1.TabIndex = 2;
            this.btnDevam1.Text = ">>>>>>>>>>>";
            this.btnDevam1.Click += new System.EventHandler(this.btnDevam1_Click);
            // 
            // pnlSecim
            // 
            this.pnlSecim.Controls.Add(this.grdSecim);
            this.pnlSecim.Enabled = false;
            this.pnlSecim.Location = new System.Drawing.Point(613, 12);
            this.pnlSecim.Name = "pnlSecim";
            this.pnlSecim.Size = new System.Drawing.Size(417, 437);
            this.pnlSecim.TabIndex = 3;
            // 
            // btnSonuc
            // 
            this.btnSonuc.Location = new System.Drawing.Point(626, 478);
            this.btnSonuc.Name = "btnSonuc";
            this.btnSonuc.Size = new System.Drawing.Size(404, 17);
            this.btnSonuc.TabIndex = 2;
            this.btnSonuc.Text = "===========================";
            this.btnSonuc.Click += new System.EventHandler(this.btnSonuc_Click);
            // 
            // btnTamam
            // 
            this.btnTamam.Location = new System.Drawing.Point(877, 608);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(153, 23);
            this.btnTamam.TabIndex = 2;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // opfDosyaSec
            // 
            this.opfDosyaSec.FileName = "openFileDialog1";
            this.opfDosyaSec.FileOk += new System.ComponentModel.CancelEventHandler(this.opfDosyaSec_FileOk);
            // 
            // frmImportFromExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 643);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.btnDevam1);
            this.Controls.Add(this.btnSonuc);
            this.Controls.Add(this.pnlSecim);
            this.Controls.Add(this.pnlIlk);
            this.Controls.Add(this.grdSonuc);
            this.Name = "frmImportFromExcel";
            this.Text = "ExceldenVerileriAl";
            this.Load += new System.EventHandler(this.frmImportFromExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueMask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueMaskeTipi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnMaskeEkle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSonuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSecim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueExcelAlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlIlk)).EndInit();
            this.pnlIlk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSheets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosya.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSecim)).EndInit();
            this.pnlSecim.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdSonuc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl grdSecim;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.PanelControl pnlIlk;
        private DevExpress.XtraGrid.GridControl grdColumns;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.GridControl grdSheets;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.TextEdit txtDosya;
        private DevExpress.XtraEditors.SimpleButton btnDevam1;
        private DevExpress.XtraEditors.PanelControl pnlSecim;
        private DevExpress.XtraEditors.SimpleButton btnSonuc;
        private DevExpress.XtraGrid.Columns.GridColumn colcolCaption;
        private DevExpress.XtraGrid.Columns.GridColumn colExcelCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueExcelAlan;
        private DevExpress.XtraEditors.SimpleButton btnTamam;
        private System.Windows.Forms.OpenFileDialog opfDosyaSec;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
        private DevExpress.XtraGrid.Columns.GridColumn colMask;
        private DevExpress.XtraGrid.Columns.GridColumn colMaskType;
        private DevExpress.XtraGrid.Columns.GridColumn colTablo;
        private DevExpress.XtraGrid.Columns.GridColumn colKolon;
        private System.Windows.Forms.BindingSource columnsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colColumn;
        private DevExpress.XtraGrid.Columns.GridColumn colCaption;
        private DevExpress.XtraGrid.Columns.GridColumn colRecord;
        private DevExpress.XtraGrid.Columns.GridColumn colIsNull;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueMaskeTipi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueMask;
        private DevExpress.XtraGrid.Columns.GridColumn gcolMaskeEkle;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rbtnMaskeEkle;
    }
}