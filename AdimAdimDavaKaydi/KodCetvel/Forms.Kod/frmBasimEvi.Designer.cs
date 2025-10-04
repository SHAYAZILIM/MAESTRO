namespace AdimAdimDavaKaydi.KodCetvel
{
    partial class frmBasimEvi
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBasimEvi = new DevExpress.XtraEditors.PanelControl();
            this.gridBasimEvi = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BASIMEVI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxteBasimEvi = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBasimEvi)).BeginInit();
            this.panelBasimEvi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBasimEvi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteBasimEvi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(569, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Basım Evi";
            // 
            // panelBasimEvi
            // 
            this.panelBasimEvi.Controls.Add(this.gridBasimEvi);
            this.panelBasimEvi.Controls.Add(this.panelControl1);
            this.panelBasimEvi.Controls.Add(this.panelControl2);
            this.panelBasimEvi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBasimEvi.Location = new System.Drawing.Point(0, 0);
            this.panelBasimEvi.Name = "panelBasimEvi";
            this.panelBasimEvi.Size = new System.Drawing.Size(573, 397);
            this.panelBasimEvi.TabIndex = 19;
            // 
            // gridBasimEvi
            // 
            this.gridBasimEvi.CustomButtonlarGorunmesin = false;
            this.gridBasimEvi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBasimEvi.DoNotExtendEmbedNavigator = false;
            this.gridBasimEvi.FilterText = null;
            this.gridBasimEvi.FilterValue = null;
            this.gridBasimEvi.GridlerDuzenlenebilir = true;
            this.gridBasimEvi.GridsFilterControl = null;
            this.gridBasimEvi.Location = new System.Drawing.Point(2, 72);
            this.gridBasimEvi.MainView = this.gridView1;
            this.gridBasimEvi.MyGridStyle = null;
            this.gridBasimEvi.Name = "gridBasimEvi";
            this.gridBasimEvi.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rtxteBasimEvi});
            this.gridBasimEvi.ShowRowNumbers = false;
            this.gridBasimEvi.SilmeKaldirilsin = false;
            this.gridBasimEvi.Size = new System.Drawing.Size(569, 323);
            this.gridBasimEvi.TabIndex = 5;
            this.gridBasimEvi.TemizleKaldirGorunsunmu = false;
            this.gridBasimEvi.UniqueId = "ea7f287e-d94e-4553-9136-180636f7c37d";
            this.gridBasimEvi.UseEmbeddedNavigator = true;
            this.gridBasimEvi.UseHyperDragDrop = false;
            this.gridBasimEvi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BASIMEVI});
            this.gridView1.GridControl = this.gridBasimEvi;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Başlıkları Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Basım Evi Adı Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // BASIMEVI
            // 
            this.BASIMEVI.Caption = "Basım Evi";
            this.BASIMEVI.ColumnEdit = this.rtxteBasimEvi;
            this.BASIMEVI.FieldName = "BASIM_EVI";
            this.BASIMEVI.Name = "BASIMEVI";
            this.BASIMEVI.Visible = true;
            this.BASIMEVI.VisibleIndex = 0;
            // 
            // rtxteBasimEvi
            // 
            this.rtxteBasimEvi.AutoHeight = false;
            this.rtxteBasimEvi.Name = "rtxteBasimEvi";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(569, 43);
            this.panelControl2.TabIndex = 2;
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
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // frmBasimEvi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 397);
            this.Controls.Add(this.panelBasimEvi);
            this.Name = "frmBasimEvi";
            this.Text = "frmBasimEvi";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBasimEvi)).EndInit();
            this.panelBasimEvi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBasimEvi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteBasimEvi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelBasimEvi;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridBasimEvi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn BASIMEVI;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxteBasimEvi;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}