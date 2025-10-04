namespace AVPTransfer
{
    partial class frmMain
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
            this.grdMain = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.numCompany = new System.Windows.Forms.NumericUpDown();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.chkNotExportImage = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtExportSingleTable = new DevExpress.XtraEditors.TextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.txtNewDB = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnNewDB = new DevExpress.XtraEditors.SimpleButton();
            this.pnlOld = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnOldDB = new DevExpress.XtraEditors.SimpleButton();
            this.txtOldDB = new DevExpress.XtraEditors.TextEdit();
            this.btnOperator4 = new DevExpress.XtraEditors.CheckButton();
            this.btnOperator3 = new DevExpress.XtraEditors.CheckButton();
            this.btnOperator2 = new DevExpress.XtraEditors.CheckButton();
            this.btnOperator1 = new DevExpress.XtraEditors.CheckButton();
            this.btnCheckNull = new DevExpress.XtraEditors.SimpleButton();
            this.btnDataTypeCheck = new DevExpress.XtraEditors.SimpleButton();
            this.btnNewField = new DevExpress.XtraEditors.SimpleButton();
            this.btnColumnList = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnCompareAndExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnCompare = new DevExpress.XtraEditors.SimpleButton();
            this.bgWorkerCompare = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotExportImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExportSingleTable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewDB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOld)).BeginInit();
            this.pnlOld.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldDB.Properties)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdMain
            // 
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMain.Location = new System.Drawing.Point(0, 86);
            this.grdMain.LookAndFeel.SkinName = "iMaginary";
            this.grdMain.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdMain.MainView = this.gridView1;
            this.grdMain.Name = "grdMain";
            this.grdMain.Size = new System.Drawing.Size(1231, 395);
            this.grdMain.TabIndex = 8;
            this.grdMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            this.grdMain.DoubleClick += new System.EventHandler(this.grdMain_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdMain;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdMain;
            this.gridView2.Name = "gridView2";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.numCompany);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.chkNotExportImage);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtExportSingleTable);
            this.groupControl1.Controls.Add(this.panelControl2);
            this.groupControl1.Controls.Add(this.btnOperator4);
            this.groupControl1.Controls.Add(this.btnOperator3);
            this.groupControl1.Controls.Add(this.btnOperator2);
            this.groupControl1.Controls.Add(this.btnOperator1);
            this.groupControl1.Controls.Add(this.btnCheckNull);
            this.groupControl1.Controls.Add(this.btnDataTypeCheck);
            this.groupControl1.Controls.Add(this.btnNewField);
            this.groupControl1.Controls.Add(this.btnColumnList);
            this.groupControl1.Controls.Add(this.btnExport);
            this.groupControl1.Controls.Add(this.btnCompareAndExport);
            this.groupControl1.Controls.Add(this.btnCompare);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.LookAndFeel.SkinName = "iMaginary";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1231, 86);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Veritabanı Bilgileri";
            // 
            // numCompany
            // 
            this.numCompany.Location = new System.Drawing.Point(41, 59);
            this.numCompany.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCompany.Name = "numCompany";
            this.numCompany.Size = new System.Drawing.Size(59, 21);
            this.numCompany.TabIndex = 10;
            this.numCompany.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl4.Location = new System.Drawing.Point(9, 63);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(26, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Firma";
            // 
            // chkNotExportImage
            // 
            this.chkNotExportImage.Location = new System.Drawing.Point(792, 60);
            this.chkNotExportImage.Name = "chkNotExportImage";
            this.chkNotExportImage.Properties.Caption = "Image\'ları aktarma";
            this.chkNotExportImage.Size = new System.Drawing.Size(107, 19);
            this.chkNotExportImage.TabIndex = 9;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(973, 62);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Tek Tablo Aktar";
            this.labelControl3.Visible = false;
            // 
            // txtExportSingleTable
            // 
            this.txtExportSingleTable.EditValue = "";
            this.txtExportSingleTable.Location = new System.Drawing.Point(1054, 59);
            this.txtExportSingleTable.Name = "txtExportSingleTable";
            this.txtExportSingleTable.Size = new System.Drawing.Size(107, 20);
            this.txtExportSingleTable.TabIndex = 4;
            this.txtExportSingleTable.Visible = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Controls.Add(this.pnlOld);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 21);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1227, 30);
            this.panelControl2.TabIndex = 8;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.txtNewDB);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Controls.Add(this.btnNewDB);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(554, 2);
            this.panelControl3.LookAndFeel.SkinName = "iMaginary";
            this.panelControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(671, 26);
            this.panelControl3.TabIndex = 8;
            // 
            // txtNewDB
            // 
            this.txtNewDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewDB.EditValue = "Server=.;Database=AVP_Yeni;User ID=sa;Password=12345678";
            this.txtNewDB.Location = new System.Drawing.Point(96, 3);
            this.txtNewDB.Name = "txtNewDB";
            this.txtNewDB.Size = new System.Drawing.Size(529, 20);
            this.txtNewDB.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(85, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Hedef Veri Tabanı";
            // 
            // btnNewDB
            // 
            this.btnNewDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewDB.Location = new System.Drawing.Point(630, 3);
            this.btnNewDB.LookAndFeel.SkinName = "iMaginary";
            this.btnNewDB.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNewDB.Name = "btnNewDB";
            this.btnNewDB.Size = new System.Drawing.Size(36, 20);
            this.btnNewDB.TabIndex = 5;
            this.btnNewDB.Text = "...";
            // 
            // pnlOld
            // 
            this.pnlOld.Controls.Add(this.labelControl1);
            this.pnlOld.Controls.Add(this.btnOldDB);
            this.pnlOld.Controls.Add(this.txtOldDB);
            this.pnlOld.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlOld.Location = new System.Drawing.Point(2, 2);
            this.pnlOld.LookAndFeel.SkinName = "iMaginary";
            this.pnlOld.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlOld.Name = "pnlOld";
            this.pnlOld.Size = new System.Drawing.Size(552, 26);
            this.pnlOld.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Location = new System.Drawing.Point(5, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(91, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Kaynak Veri Tabanı";
            // 
            // btnOldDB
            // 
            this.btnOldDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOldDB.Location = new System.Drawing.Point(511, 3);
            this.btnOldDB.LookAndFeel.SkinName = "iMaginary";
            this.btnOldDB.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOldDB.Name = "btnOldDB";
            this.btnOldDB.Size = new System.Drawing.Size(36, 20);
            this.btnOldDB.TabIndex = 5;
            this.btnOldDB.Text = "...";
            // 
            // txtOldDB
            // 
            this.txtOldDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOldDB.EditValue = "Server=.;Database=AVP_Eski;User ID=sa;Password=12345678";
            this.txtOldDB.Location = new System.Drawing.Point(98, 3);
            this.txtOldDB.Name = "txtOldDB";
            this.txtOldDB.Size = new System.Drawing.Size(408, 20);
            this.txtOldDB.TabIndex = 4;
            // 
            // btnOperator4
            // 
            this.btnOperator4.Enabled = false;
            this.btnOperator4.Location = new System.Drawing.Point(423, 56);
            this.btnOperator4.LookAndFeel.SkinName = "iMaginary";
            this.btnOperator4.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOperator4.Name = "btnOperator4";
            this.btnOperator4.Size = new System.Drawing.Size(32, 25);
            this.btnOperator4.TabIndex = 5;
            this.btnOperator4.Text = "<<--";
            this.btnOperator4.CheckedChanged += new System.EventHandler(this.btnOperator_CheckedChanged);
            // 
            // btnOperator3
            // 
            this.btnOperator3.Enabled = false;
            this.btnOperator3.Location = new System.Drawing.Point(389, 56);
            this.btnOperator3.LookAndFeel.SkinName = "iMaginary";
            this.btnOperator3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOperator3.Name = "btnOperator3";
            this.btnOperator3.Size = new System.Drawing.Size(32, 25);
            this.btnOperator3.TabIndex = 5;
            this.btnOperator3.Text = "-->>";
            this.btnOperator3.CheckedChanged += new System.EventHandler(this.btnOperator_CheckedChanged);
            // 
            // btnOperator2
            // 
            this.btnOperator2.Enabled = false;
            this.btnOperator2.Location = new System.Drawing.Point(355, 56);
            this.btnOperator2.LookAndFeel.SkinName = "iMaginary";
            this.btnOperator2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOperator2.Name = "btnOperator2";
            this.btnOperator2.Size = new System.Drawing.Size(32, 25);
            this.btnOperator2.TabIndex = 5;
            this.btnOperator2.Text = "!=";
            this.btnOperator2.CheckedChanged += new System.EventHandler(this.btnOperator_CheckedChanged);
            // 
            // btnOperator1
            // 
            this.btnOperator1.Enabled = false;
            this.btnOperator1.Location = new System.Drawing.Point(321, 56);
            this.btnOperator1.LookAndFeel.SkinName = "iMaginary";
            this.btnOperator1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOperator1.Name = "btnOperator1";
            this.btnOperator1.Size = new System.Drawing.Size(32, 25);
            this.btnOperator1.TabIndex = 5;
            this.btnOperator1.Text = "=";
            this.btnOperator1.CheckedChanged += new System.EventHandler(this.btnOperator_CheckedChanged);
            // 
            // btnCheckNull
            // 
            this.btnCheckNull.Enabled = false;
            this.btnCheckNull.Location = new System.Drawing.Point(457, 56);
            this.btnCheckNull.LookAndFeel.SkinName = "iMaginary";
            this.btnCheckNull.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCheckNull.Name = "btnCheckNull";
            this.btnCheckNull.Size = new System.Drawing.Size(66, 24);
            this.btnCheckNull.TabIndex = 6;
            this.btnCheckNull.Text = "Null kontrol";
            this.btnCheckNull.Click += new System.EventHandler(this.btnCheckNull_Click);
            // 
            // btnDataTypeCheck
            // 
            this.btnDataTypeCheck.Enabled = false;
            this.btnDataTypeCheck.Location = new System.Drawing.Point(673, 56);
            this.btnDataTypeCheck.LookAndFeel.SkinName = "iMaginary";
            this.btnDataTypeCheck.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDataTypeCheck.Name = "btnDataTypeCheck";
            this.btnDataTypeCheck.Size = new System.Drawing.Size(117, 24);
            this.btnDataTypeCheck.TabIndex = 6;
            this.btnDataTypeCheck.Text = "Veri Tipi Uyuşmazlıkları";
            this.btnDataTypeCheck.Click += new System.EventHandler(this.btnDataTypeCheck_Click);
            // 
            // btnNewField
            // 
            this.btnNewField.Enabled = false;
            this.btnNewField.Location = new System.Drawing.Point(525, 56);
            this.btnNewField.LookAndFeel.SkinName = "iMaginary";
            this.btnNewField.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNewField.Name = "btnNewField";
            this.btnNewField.Size = new System.Drawing.Size(146, 24);
            this.btnNewField.TabIndex = 6;
            this.btnNewField.Text = "Eski Tablolardaki Yeni Alanlar";
            this.btnNewField.Click += new System.EventHandler(this.btnNewField_Click);
            // 
            // btnColumnList
            // 
            this.btnColumnList.Location = new System.Drawing.Point(902, 56);
            this.btnColumnList.LookAndFeel.SkinName = "iMaginary";
            this.btnColumnList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnColumnList.Name = "btnColumnList";
            this.btnColumnList.Size = new System.Drawing.Size(69, 24);
            this.btnColumnList.TabIndex = 6;
            this.btnColumnList.Text = "Kolon Listesi";
            this.btnColumnList.Visible = false;
            this.btnColumnList.Click += new System.EventHandler(this.btnColumnList_Click);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(278, 56);
            this.btnExport.LookAndFeel.SkinName = "iMaginary";
            this.btnExport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(42, 24);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Aktar";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCompareAndExport
            // 
            this.btnCompareAndExport.Location = new System.Drawing.Point(103, 57);
            this.btnCompareAndExport.LookAndFeel.SkinName = "iMaginary";
            this.btnCompareAndExport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCompareAndExport.Name = "btnCompareAndExport";
            this.btnCompareAndExport.Size = new System.Drawing.Size(108, 24);
            this.btnCompareAndExport.TabIndex = 6;
            this.btnCompareAndExport.Text = "Karşılaştır ve Aktar";
            this.btnCompareAndExport.Click += new System.EventHandler(this.btnCompareAndExport_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(212, 57);
            this.btnCompare.LookAndFeel.SkinName = "iMaginary";
            this.btnCompare.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(65, 24);
            this.btnCompare.TabIndex = 6;
            this.btnCompare.Text = "Karşılaştır";
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // bgWorkerCompare
            // 
            this.bgWorkerCompare.WorkerReportsProgress = true;
            this.bgWorkerCompare.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerCompare_DoWork);
            this.bgWorkerCompare.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerCompare_ProgressChanged);
            this.bgWorkerCompare.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerCompare_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 455);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1231, 26);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 20);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // frmMain
            // 
            this.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 481);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grdMain);
            this.Controls.Add(this.groupControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmMain";
            this.Text = "AVP - Ana Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotExportImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExportSingleTable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewDB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOld)).EndInit();
            this.pnlOld.ResumeLayout(false);
            this.pnlOld.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldDB.Properties)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtNewDB;
        private DevExpress.XtraEditors.TextEdit txtOldDB;
        private DevExpress.XtraEditors.SimpleButton btnNewDB;
        private DevExpress.XtraEditors.SimpleButton btnOldDB;
        private DevExpress.XtraEditors.SimpleButton btnCompare;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl grdMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl pnlOld;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.CheckButton btnOperator4;
        private DevExpress.XtraEditors.CheckButton btnOperator3;
        private DevExpress.XtraEditors.CheckButton btnOperator2;
        private DevExpress.XtraEditors.CheckButton btnOperator1;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnCheckNull;
        private DevExpress.XtraEditors.SimpleButton btnNewField;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnDataTypeCheck;
        private DevExpress.XtraEditors.SimpleButton btnCompareAndExport;
        private DevExpress.XtraEditors.SimpleButton btnColumnList;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtExportSingleTable;
        private DevExpress.XtraEditors.CheckEdit chkNotExportImage;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.NumericUpDown numCompany;
        private System.ComponentModel.BackgroundWorker bgWorkerCompare;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
    }
}

