namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    partial class frmOtomatikDuzelt
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelOtomatikDuzelt = new DevExpress.XtraEditors.PanelControl();
            this.gridOtomatikDuzelt = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DEGISTIRILECEK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxteDEGISECEK = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.YERINE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.rtxteYERINE = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelOtomatikDuzelt)).BeginInit();
            this.panelOtomatikDuzelt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOtomatikDuzelt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteDEGISECEK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteYERINE)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(19, 10);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(117, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // panelOtomatikDuzelt
            // 
            this.panelOtomatikDuzelt.Controls.Add(this.gridOtomatikDuzelt);
            this.panelOtomatikDuzelt.Controls.Add(this.panelControl1);
            this.panelOtomatikDuzelt.Controls.Add(this.panelControl2);
            this.panelOtomatikDuzelt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOtomatikDuzelt.Location = new System.Drawing.Point(0, 0);
            this.panelOtomatikDuzelt.Name = "panelOtomatikDuzelt";
            this.panelOtomatikDuzelt.Size = new System.Drawing.Size(499, 303);
            this.panelOtomatikDuzelt.TabIndex = 19;
            // 
            // gridOtomatikDuzelt
            // 
            this.gridOtomatikDuzelt.CustomButtonlarGorunmesin = false;
            this.gridOtomatikDuzelt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOtomatikDuzelt.DoNotExtendEmbedNavigator = false;
            this.gridOtomatikDuzelt.FilterText = null;
            this.gridOtomatikDuzelt.FilterValue = null;
            this.gridOtomatikDuzelt.GridlerDuzenlenebilir = true;
            this.gridOtomatikDuzelt.GridsFilterControl = null;
            this.gridOtomatikDuzelt.Location = new System.Drawing.Point(2, 72);
            this.gridOtomatikDuzelt.MainView = this.gridView1;
            this.gridOtomatikDuzelt.MyGridStyle = null;
            this.gridOtomatikDuzelt.Name = "gridOtomatikDuzelt";
            this.gridOtomatikDuzelt.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rtxteDEGISECEK});
            this.gridOtomatikDuzelt.ShowRowNumbers = false;
            this.gridOtomatikDuzelt.SilmeKaldirilsin = false;
            this.gridOtomatikDuzelt.Size = new System.Drawing.Size(495, 229);
            this.gridOtomatikDuzelt.TabIndex = 5;
            this.gridOtomatikDuzelt.TemizleKaldirGorunsunmu = false;
            this.gridOtomatikDuzelt.UniqueId = "c71eac66-8a7b-4237-9d65-b6f0a13c102b";
            this.gridOtomatikDuzelt.UseEmbeddedNavigator = true;
            this.gridOtomatikDuzelt.UseHyperDragDrop = false;
            this.gridOtomatikDuzelt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DEGISTIRILECEK,
            this.YERINE});
            this.gridView1.GridControl = this.gridOtomatikDuzelt;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Başlıkları Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Otomati Düzelt Adı Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // DEGISTIRILECEK
            // 
            this.DEGISTIRILECEK.Caption = "Değiştirilecek";
            this.DEGISTIRILECEK.ColumnEdit = this.rtxteDEGISECEK;
            this.DEGISTIRILECEK.FieldName = "DEGISTIRILECEK";
            this.DEGISTIRILECEK.Name = "DEGISTIRILECEK";
            this.DEGISTIRILECEK.Visible = true;
            this.DEGISTIRILECEK.VisibleIndex = 0;
            // 
            // rtxteDEGISECEK
            // 
            this.rtxteDEGISECEK.AutoHeight = false;
            this.rtxteDEGISECEK.Name = "rtxteDEGISECEK";
            // 
            // YERINE
            // 
            this.YERINE.Caption = "Yerine";
            this.YERINE.FieldName = "YERINE";
            this.YERINE.Name = "YERINE";
            this.YERINE.Visible = true;
            this.YERINE.VisibleIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(495, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Otomatik Düzelt";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(495, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // rtxteYERINE
            // 
            this.rtxteYERINE.AutoHeight = false;
            this.rtxteYERINE.Name = "rtxteYERINE";
            // 
            // frmOtomatikDuzelt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 303);
            this.Controls.Add(this.panelOtomatikDuzelt);
            this.Name = "frmOtomatikDuzelt";
            this.Text = "frmOtomatikDuzelt";
            ((System.ComponentModel.ISupportInitialize)(this.panelOtomatikDuzelt)).EndInit();
            this.panelOtomatikDuzelt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridOtomatikDuzelt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteDEGISECEK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rtxteYERINE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl panelOtomatikDuzelt;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridOtomatikDuzelt;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn DEGISTIRILECEK;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxteDEGISECEK;
        private DevExpress.XtraGrid.Columns.GridColumn YERINE;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxteYERINE;
    }
}