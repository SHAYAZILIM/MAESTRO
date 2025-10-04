namespace  AvukatProLib.Bakim
{
    partial class frmKullaniciGruplari
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
            this.grpKullaniciGruplari = new DevExpress.XtraEditors.GroupControl();
            this.tlistKullaniciGrup = new DevExpress.XtraTreeList.TreeList();
            this.colID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colKISA_ADI = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colADI = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMIN_LEVEL = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMAX_LEVEL = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdKullaniciList = new DevExpress.XtraGrid.GridControl();
            this.conMSag = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemSil = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKul_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGRUP_KISA_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKULLANICI_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROGRAM_MODUL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKULLANICI_YETKI_SEVIYESI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKULLANICI_AKTIF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSUBE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lueKullanici = new DevExpress.XtraEditors.LookUpEdit();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpKullaniciGruplari)).BeginInit();
            this.grpKullaniciGruplari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlistKullaniciGrup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKullaniciList)).BeginInit();
            this.conMSag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueKullanici.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpKullaniciGruplari
            // 
            this.grpKullaniciGruplari.Controls.Add(this.tlistKullaniciGrup);
            this.grpKullaniciGruplari.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpKullaniciGruplari.Location = new System.Drawing.Point(0, 0);
            this.grpKullaniciGruplari.Name = "grpKullaniciGruplari";
            this.grpKullaniciGruplari.Size = new System.Drawing.Size(346, 340);
            this.grpKullaniciGruplari.TabIndex = 0;
            this.grpKullaniciGruplari.Text = "Kullanýcý Grup Listesi";
            // 
            // tlistKullaniciGrup
            // 
            this.tlistKullaniciGrup.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colID,
            this.colKISA_ADI,
            this.colADI,
            this.colMIN_LEVEL,
            this.colMAX_LEVEL});
            this.tlistKullaniciGrup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlistKullaniciGrup.Location = new System.Drawing.Point(2, 20);
            this.tlistKullaniciGrup.Name = "tlistKullaniciGrup";
            this.tlistKullaniciGrup.OptionsBehavior.Editable = false;
            this.tlistKullaniciGrup.OptionsBehavior.PopulateServiceColumns = true;
            this.tlistKullaniciGrup.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.tlistKullaniciGrup.OptionsSelection.UseIndicatorForSelection = true;
            this.tlistKullaniciGrup.Size = new System.Drawing.Size(342, 318);
            this.tlistKullaniciGrup.TabIndex = 2;
            this.tlistKullaniciGrup.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlistKullaniciGrup_FocusedNodeChanged);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.OptionsColumn.AllowMove = false;
            this.colID.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colID.OptionsColumn.AllowSize = false;
            this.colID.OptionsColumn.AllowSort = false;
            // 
            // colKISA_ADI
            // 
            this.colKISA_ADI.Caption = "KISA_ADI";
            this.colKISA_ADI.FieldName = "KISA_ADI";
            this.colKISA_ADI.Name = "colKISA_ADI";
            this.colKISA_ADI.OptionsColumn.ReadOnly = true;
            this.colKISA_ADI.Visible = true;
            this.colKISA_ADI.VisibleIndex = 0;
            this.colKISA_ADI.Width = 59;
            // 
            // colADI
            // 
            this.colADI.Caption = "ADI";
            this.colADI.FieldName = "ADI";
            this.colADI.Name = "colADI";
            this.colADI.OptionsColumn.ReadOnly = true;
            this.colADI.Visible = true;
            this.colADI.VisibleIndex = 1;
            this.colADI.Width = 52;
            // 
            // colMIN_LEVEL
            // 
            this.colMIN_LEVEL.Caption = "MIN_LEVEL";
            this.colMIN_LEVEL.FieldName = "MIN_LEVEL";
            this.colMIN_LEVEL.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMIN_LEVEL.Name = "colMIN_LEVEL";
            this.colMIN_LEVEL.OptionsColumn.AllowEdit = false;
            this.colMIN_LEVEL.OptionsColumn.AllowMove = false;
            this.colMIN_LEVEL.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colMIN_LEVEL.OptionsColumn.AllowSize = false;
            this.colMIN_LEVEL.OptionsColumn.AllowSort = false;
            this.colMIN_LEVEL.OptionsColumn.ReadOnly = true;
            this.colMIN_LEVEL.Visible = true;
            this.colMIN_LEVEL.VisibleIndex = 2;
            this.colMIN_LEVEL.Width = 79;
            // 
            // colMAX_LEVEL
            // 
            this.colMAX_LEVEL.Caption = "MAX_LEVEL";
            this.colMAX_LEVEL.FieldName = "MAX_LEVEL";
            this.colMAX_LEVEL.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMAX_LEVEL.Name = "colMAX_LEVEL";
            this.colMAX_LEVEL.OptionsColumn.AllowEdit = false;
            this.colMAX_LEVEL.OptionsColumn.FixedWidth = true;
            this.colMAX_LEVEL.OptionsColumn.ReadOnly = true;
            this.colMAX_LEVEL.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.colMAX_LEVEL.Visible = true;
            this.colMAX_LEVEL.VisibleIndex = 3;
            this.colMAX_LEVEL.Width = 131;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.grdKullaniciList);
            this.groupControl1.Controls.Add(this.btnSil);
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(346, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(339, 340);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Kullanýcý Listesi";
            // 
            // grdKullaniciList
            // 
            this.grdKullaniciList.ContextMenuStrip = this.conMSag;
            this.grdKullaniciList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdKullaniciList.Location = new System.Drawing.Point(2, 87);
            this.grdKullaniciList.MainView = this.gridView1;
            this.grdKullaniciList.Name = "grdKullaniciList";
            this.grdKullaniciList.Size = new System.Drawing.Size(335, 228);
            this.grdKullaniciList.TabIndex = 5;
            this.grdKullaniciList.UseEmbeddedNavigator = true;
            this.grdKullaniciList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // conMSag
            // 
            this.conMSag.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemSil});
            this.conMSag.Name = "conMSag";
            this.conMSag.Size = new System.Drawing.Size(96, 26);
            // 
            // mItemSil
            // 
            this.mItemSil.Name = "mItemSil";
            this.mItemSil.Size = new System.Drawing.Size(95, 22);
            this.mItemSil.Text = "Sil";
            this.mItemSil.Click += new System.EventHandler(this.mItemSil_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKul_ID,
            this.colGRUP_KISA_ADI,
            this.colKULLANICI_ADI,
            this.colPROGRAM_MODUL,
            this.colKULLANICI_YETKI_SEVIYESI,
            this.colKULLANICI_AKTIF,
            this.colSUBE_ID});
            this.gridView1.GridControl = this.grdKullaniciList;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView1.OptionsLayout.Columns.RemoveOldColumns = false;
            this.gridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colKul_ID
            // 
            this.colKul_ID.Caption = "ID";
            this.colKul_ID.FieldName = "ID";
            this.colKul_ID.Name = "colKul_ID";
            // 
            // colGRUP_KISA_ADI
            // 
            this.colGRUP_KISA_ADI.Caption = "GRUP_KISA_ADI";
            this.colGRUP_KISA_ADI.FieldName = "GRUP_KISA_ADI";
            this.colGRUP_KISA_ADI.Name = "colGRUP_KISA_ADI";
            this.colGRUP_KISA_ADI.Visible = true;
            this.colGRUP_KISA_ADI.VisibleIndex = 1;
            // 
            // colKULLANICI_ADI
            // 
            this.colKULLANICI_ADI.Caption = "KULLANICI_ADI";
            this.colKULLANICI_ADI.FieldName = "KULLANICI_ADI";
            this.colKULLANICI_ADI.Name = "colKULLANICI_ADI";
            this.colKULLANICI_ADI.Visible = true;
            this.colKULLANICI_ADI.VisibleIndex = 0;
            // 
            // colPROGRAM_MODUL
            // 
            this.colPROGRAM_MODUL.Caption = "PROGRAM_MODUL";
            this.colPROGRAM_MODUL.FieldName = "PROGRAM_MODUL";
            this.colPROGRAM_MODUL.Name = "colPROGRAM_MODUL";
            this.colPROGRAM_MODUL.Visible = true;
            this.colPROGRAM_MODUL.VisibleIndex = 2;
            // 
            // colKULLANICI_YETKI_SEVIYESI
            // 
            this.colKULLANICI_YETKI_SEVIYESI.Caption = "KULLANICI_YETKI_SEVIYESI";
            this.colKULLANICI_YETKI_SEVIYESI.FieldName = "KULLANICI_YETKI_SEVIYESI";
            this.colKULLANICI_YETKI_SEVIYESI.Name = "colKULLANICI_YETKI_SEVIYESI";
            this.colKULLANICI_YETKI_SEVIYESI.Visible = true;
            this.colKULLANICI_YETKI_SEVIYESI.VisibleIndex = 3;
            // 
            // colKULLANICI_AKTIF
            // 
            this.colKULLANICI_AKTIF.Caption = "KULLANICI_AKTIF";
            this.colKULLANICI_AKTIF.FieldName = "KULLANICI_AKTIF";
            this.colKULLANICI_AKTIF.Name = "colKULLANICI_AKTIF";
            this.colKULLANICI_AKTIF.Visible = true;
            this.colKULLANICI_AKTIF.VisibleIndex = 4;
            // 
            // colSUBE_ID
            // 
            this.colSUBE_ID.Caption = "SUBE_ID";
            this.colSUBE_ID.FieldName = "SUBE_ID";
            this.colSUBE_ID.Name = "colSUBE_ID";
            this.colSUBE_ID.Visible = true;
            this.colSUBE_ID.VisibleIndex = 5;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdKullaniciList;
            this.gridView2.Name = "gridView2";
            // 
            // btnSil
            // 
            this.btnSil.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSil.Location = new System.Drawing.Point(2, 315);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(335, 23);
            this.btnSil.TabIndex = 6;
            this.btnSil.Text = "Gruptan Kullanýcý Çýkar ";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lueKullanici);
            this.panelControl1.Controls.Add(this.btnEkle);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 20);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(335, 67);
            this.panelControl1.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(5, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 30);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Kullanýcý Adý :";
            // 
            // lueKullanici
            // 
            this.lueKullanici.Location = new System.Drawing.Point(77, 21);
            this.lueKullanici.Name = "lueKullanici";
            this.lueKullanici.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueKullanici.Size = new System.Drawing.Size(181, 20);
            this.lueKullanici.TabIndex = 0;
            this.lueKullanici.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.lueKullanici_EditValueChanging);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(266, 18);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(63, 23);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // frmKullaniciGruplari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 340);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.grpKullaniciGruplari);
            this.Name = "frmKullaniciGruplari";
            this.Text = "Gruba Kullanýcý Ekleme";
            this.Load += new System.EventHandler(this.frmKullaniciGruplari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpKullaniciGruplari)).EndInit();
            this.grpKullaniciGruplari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlistKullaniciGrup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKullaniciList)).EndInit();
            this.conMSag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueKullanici.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpKullaniciGruplari;
        private DevExpress.XtraTreeList.TreeList tlistKullaniciGrup;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colKISA_ADI;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colADI;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMIN_LEVEL;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMAX_LEVEL;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lueKullanici;
        private DevExpress.XtraEditors.SimpleButton btnEkle;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colID;
        private DevExpress.XtraGrid.GridControl grdKullaniciList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colKULLANICI_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn colGRUP_KISA_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn colPROGRAM_MODUL;
        private DevExpress.XtraGrid.Columns.GridColumn colKULLANICI_YETKI_SEVIYESI;
        private DevExpress.XtraGrid.Columns.GridColumn colKULLANICI_AKTIF;
        private DevExpress.XtraGrid.Columns.GridColumn colSUBE_ID;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private System.Windows.Forms.ContextMenuStrip conMSag;
        private System.Windows.Forms.ToolStripMenuItem mItemSil;
        private DevExpress.XtraGrid.Columns.GridColumn colKul_ID;
    }
}