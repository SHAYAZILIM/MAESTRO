namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    partial class frmMarkaTipKodlari
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
            this.panelMarkaTip = new DevExpress.XtraEditors.PanelControl();
            this.gridMarkaTip = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MARKATIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxteMarkaTip = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMarkaTip)).BeginInit();
            this.panelMarkaTip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMarkaTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteMarkaTip)).BeginInit();
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
            this.panelControl1.Size = new System.Drawing.Size(623, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "AdresDurum";
            // 
            // panelMarkaTip
            // 
            this.panelMarkaTip.Controls.Add(this.gridMarkaTip);
            this.panelMarkaTip.Controls.Add(this.panelControl1);
            this.panelMarkaTip.Controls.Add(this.panelControl2);
            this.panelMarkaTip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMarkaTip.Location = new System.Drawing.Point(0, 0);
            this.panelMarkaTip.Name = "panelMarkaTip";
            this.panelMarkaTip.Size = new System.Drawing.Size(627, 463);
            this.panelMarkaTip.TabIndex = 19;
            // 
            // gridMarkaTip
            // 
            this.gridMarkaTip.CustomButtonlarGorunmesin = false;
            this.gridMarkaTip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMarkaTip.DoNotExtendEmbedNavigator = false;
            this.gridMarkaTip.FilterText = null;
            this.gridMarkaTip.FilterValue = null;
            this.gridMarkaTip.GridlerDuzenlenebilir = true;
            this.gridMarkaTip.GridsFilterControl = null;
            this.gridMarkaTip.Location = new System.Drawing.Point(2, 72);
            this.gridMarkaTip.MainView = this.gridView1;
            this.gridMarkaTip.MyGridStyle = null;
            this.gridMarkaTip.Name = "gridMarkaTip";
            this.gridMarkaTip.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rtxteMarkaTip});
            this.gridMarkaTip.ShowRowNumbers = false;
            this.gridMarkaTip.SilmeKaldirilsin = false;
            this.gridMarkaTip.Size = new System.Drawing.Size(623, 389);
            this.gridMarkaTip.TabIndex = 5;
            this.gridMarkaTip.TemizleKaldirGorunsunmu = false;
            this.gridMarkaTip.UniqueId = "fa96c36c-a8dc-43bd-872a-5c154afdfb08";
            this.gridMarkaTip.UseEmbeddedNavigator = true;
            this.gridMarkaTip.UseHyperDragDrop = false;
            this.gridMarkaTip.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MARKATIP});
            this.gridView1.GridControl = this.gridMarkaTip;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Başlıkları Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Marka Adı Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // MARKATIP
            // 
            this.MARKATIP.Caption = "Marka Adı";
            this.MARKATIP.ColumnEdit = this.rtxteMarkaTip;
            this.MARKATIP.FieldName = "MARKA_TIP_AD";
            this.MARKATIP.Name = "MARKATIP";
            this.MARKATIP.Visible = true;
            this.MARKATIP.VisibleIndex = 0;
            // 
            // rtxteMarkaTip
            // 
            this.rtxteMarkaTip.AutoHeight = false;
            this.rtxteMarkaTip.Name = "rtxteMarkaTip";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(623, 43);
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
            // frmMarkaTipKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 463);
            this.Controls.Add(this.panelMarkaTip);
            this.Name = "frmMarkaTipKodlari";
            this.Text = "frmMarkaTipKodlari";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMarkaTip)).EndInit();
            this.panelMarkaTip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMarkaTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteMarkaTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelMarkaTip;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridMarkaTip;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn MARKATIP;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxteMarkaTip;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}