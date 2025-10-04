namespace  AnaForm
{
    partial class frmTahsilDurumKodlari
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
            this.panelTahsilDurumKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridTahsilDurumKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TAHSIL_DURUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit33 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelTahsilDurumKodlar)).BeginInit();
            this.panelTahsilDurumKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTahsilDurumKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTahsilDurumKodlar
            // 
            this.panelTahsilDurumKodlar.Controls.Add(this.gridTahsilDurumKodlar);
            this.panelTahsilDurumKodlar.Controls.Add(this.panelControl1);
            this.panelTahsilDurumKodlar.Controls.Add(this.panelControl2);
            this.panelTahsilDurumKodlar.Location = new System.Drawing.Point(13, 39);
            this.panelTahsilDurumKodlar.Name = "panelTahsilDurumKodlar";
            this.panelTahsilDurumKodlar.Size = new System.Drawing.Size(740, 368);
            this.panelTahsilDurumKodlar.TabIndex = 32;
            // 
            // gridTahsilDurumKodlar
            // 
            this.gridTahsilDurumKodlar.CustomButtonlarGorunmesin = false;
            this.gridTahsilDurumKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTahsilDurumKodlar.DoNotExtendEmbedNavigator = false;
            this.gridTahsilDurumKodlar.FilterText = null;
            this.gridTahsilDurumKodlar.FilterValue = null;
            this.gridTahsilDurumKodlar.GridlerDuzenlenebilir = true;
            this.gridTahsilDurumKodlar.GridsFilterControl = null;
            this.gridTahsilDurumKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridTahsilDurumKodlar.MainView = this.gridView1;
            this.gridTahsilDurumKodlar.MyGridStyle = null;
            this.gridTahsilDurumKodlar.Name = "gridTahsilDurumKodlar";
            this.gridTahsilDurumKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit33});
            this.gridTahsilDurumKodlar.ShowRowNumbers = false;
            this.gridTahsilDurumKodlar.Size = new System.Drawing.Size(736, 294);
            this.gridTahsilDurumKodlar.TabIndex = 5;
            this.gridTahsilDurumKodlar.TemizleKaldirGorunsunmu = false;
            this.gridTahsilDurumKodlar.UniqueId = "57dbc86e-2edb-48cf-a334-cdd7f66bea74";
            this.gridTahsilDurumKodlar.UseEmbeddedNavigator = true;
            this.gridTahsilDurumKodlar.UseHyperDragDrop = false;
            this.gridTahsilDurumKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TAHSIL_DURUM});
            this.gridView1.GridControl = this.gridTahsilDurumKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Tahsil Durumu Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // TAHSIL_DURUM
            // 
            this.TAHSIL_DURUM.Caption = "Tahsil Durum Kodlar";
            this.TAHSIL_DURUM.ColumnEdit = this.repositoryItemTextEdit33;
            this.TAHSIL_DURUM.FieldName = "TAHSIL_DURUM";
            this.TAHSIL_DURUM.Name = "TAHSIL_DURUM";
            this.TAHSIL_DURUM.Visible = true;
            this.TAHSIL_DURUM.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit33
            // 
            this.repositoryItemTextEdit33.AutoHeight = false;
            this.repositoryItemTextEdit33.Name = "repositoryItemTextEdit33";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(736, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tahsil Durum Kodlarý";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.sBtnKaydet);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(736, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(50, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 6;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridTahsilDurumKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(736, 294);
            this.gridControlExtender1.Location = new System.Drawing.Point(429, 412);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 33;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmTahsilDurumKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 447);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelTahsilDurumKodlar);
            this.Name = "frmTahsilDurumKodlari";
            this.Text = "Tahsil Durum Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelTahsilDurumKodlar)).EndInit();
            this.panelTahsilDurumKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTahsilDurumKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTahsilDurumKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTahsilDurumKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn TAHSIL_DURUM;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit33;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}