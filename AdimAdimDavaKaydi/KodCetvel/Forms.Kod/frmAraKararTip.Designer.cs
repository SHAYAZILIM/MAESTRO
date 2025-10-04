namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    partial class frmAraKararTip
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
            this.panelAraKarar = new DevExpress.XtraEditors.PanelControl();
            this.gridAraKarar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ARAKARAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxteAraKarar = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelAraKarar)).BeginInit();
            this.panelAraKarar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAraKarar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteAraKarar)).BeginInit();
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
            this.panelControl1.Size = new System.Drawing.Size(574, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ara Karar";
            // 
            // panelAraKarar
            // 
            this.panelAraKarar.Controls.Add(this.gridAraKarar);
            this.panelAraKarar.Controls.Add(this.panelControl1);
            this.panelAraKarar.Controls.Add(this.panelControl2);
            this.panelAraKarar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAraKarar.Location = new System.Drawing.Point(0, 0);
            this.panelAraKarar.Name = "panelAraKarar";
            this.panelAraKarar.Size = new System.Drawing.Size(578, 394);
            this.panelAraKarar.TabIndex = 19;
            // 
            // gridAraKarar
            // 
            this.gridAraKarar.CustomButtonlarGorunmesin = false;
            this.gridAraKarar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAraKarar.DoNotExtendEmbedNavigator = false;
            this.gridAraKarar.FilterText = null;
            this.gridAraKarar.FilterValue = null;
            this.gridAraKarar.GridlerDuzenlenebilir = true;
            this.gridAraKarar.GridsFilterControl = null;
            this.gridAraKarar.Location = new System.Drawing.Point(2, 72);
            this.gridAraKarar.MainView = this.gridView1;
            this.gridAraKarar.MyGridStyle = null;
            this.gridAraKarar.Name = "gridAraKarar";
            this.gridAraKarar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rtxteAraKarar});
            this.gridAraKarar.ShowRowNumbers = false;
            this.gridAraKarar.SilmeKaldirilsin = false;
            this.gridAraKarar.Size = new System.Drawing.Size(574, 320);
            this.gridAraKarar.TabIndex = 5;
            this.gridAraKarar.TemizleKaldirGorunsunmu = false;
            this.gridAraKarar.UniqueId = "3be55b07-8cdf-46f9-be66-bef630b79d73";
            this.gridAraKarar.UseEmbeddedNavigator = true;
            this.gridAraKarar.UseHyperDragDrop = false;
            this.gridAraKarar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ARAKARAR});
            this.gridView1.GridControl = this.gridAraKarar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Başlıkları Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Adres Durum Adı Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // ARAKARAR
            // 
            this.ARAKARAR.Caption = "Ara Karar";
            this.ARAKARAR.ColumnEdit = this.rtxteAraKarar;
            this.ARAKARAR.FieldName = "ARA_KARAR_TIP";
            this.ARAKARAR.Name = "ARAKARAR";
            this.ARAKARAR.Visible = true;
            this.ARAKARAR.VisibleIndex = 0;
            // 
            // rtxteAraKarar
            // 
            this.rtxteAraKarar.AutoHeight = false;
            this.rtxteAraKarar.Name = "rtxteAraKarar";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(574, 43);
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
            // frmAraKararTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 394);
            this.Controls.Add(this.panelAraKarar);
            this.Name = "frmAraKararTip";
            this.Text = "Ara Karar Tip Kodları";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelAraKarar)).EndInit();
            this.panelAraKarar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAraKarar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteAraKarar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelAraKarar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridAraKarar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ARAKARAR;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxteAraKarar;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}