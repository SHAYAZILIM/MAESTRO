namespace  AnaForm
{
    partial class frmRucuBelgeTurKodlari
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
            this.panelRucuBelgeTur = new DevExpress.XtraEditors.PanelControl();
            this.gridRucuBelgeTurKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BELGE_TUR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit15 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelRucuBelgeTur)).BeginInit();
            this.panelRucuBelgeTur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRucuBelgeTurKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRucuBelgeTur
            // 
            this.panelRucuBelgeTur.Controls.Add(this.gridRucuBelgeTurKodlar);
            this.panelRucuBelgeTur.Controls.Add(this.panelControl1);
            this.panelRucuBelgeTur.Controls.Add(this.panelControl2);
            this.panelRucuBelgeTur.Location = new System.Drawing.Point(7, 12);
            this.panelRucuBelgeTur.Name = "panelRucuBelgeTur";
            this.panelRucuBelgeTur.Size = new System.Drawing.Size(750, 360);
            this.panelRucuBelgeTur.TabIndex = 14;
            // 
            // gridRucuBelgeTurKodlar
            // 
            this.gridRucuBelgeTurKodlar.CustomButtonlarGorunmesin = false;
            this.gridRucuBelgeTurKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRucuBelgeTurKodlar.DoNotExtendEmbedNavigator = false;
            this.gridRucuBelgeTurKodlar.FilterText = null;
            this.gridRucuBelgeTurKodlar.FilterValue = null;
            this.gridRucuBelgeTurKodlar.GridlerDuzenlenebilir = true;
            this.gridRucuBelgeTurKodlar.GridsFilterControl = null;
            this.gridRucuBelgeTurKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridRucuBelgeTurKodlar.MainView = this.gridView1;
            this.gridRucuBelgeTurKodlar.MyGridStyle = null;
            this.gridRucuBelgeTurKodlar.Name = "gridRucuBelgeTurKodlar";
            this.gridRucuBelgeTurKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit15});
            this.gridRucuBelgeTurKodlar.ShowRowNumbers = false;
            this.gridRucuBelgeTurKodlar.Size = new System.Drawing.Size(746, 286);
            this.gridRucuBelgeTurKodlar.TabIndex = 5;
            this.gridRucuBelgeTurKodlar.TemizleKaldirGorunsunmu = false;
            this.gridRucuBelgeTurKodlar.UniqueId = "5dd424f8-f38a-4dd5-9ff5-c91d788b38c6";
            this.gridRucuBelgeTurKodlar.UseEmbeddedNavigator = true;
            this.gridRucuBelgeTurKodlar.UseHyperDragDrop = false;
            this.gridRucuBelgeTurKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BELGE_TUR});
            this.gridView1.GridControl = this.gridRucuBelgeTurKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Rücu Belge Türleri Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // BELGE_TUR
            // 
            this.BELGE_TUR.Caption = "Rücu Belge Türleri";
            this.BELGE_TUR.ColumnEdit = this.repositoryItemTextEdit15;
            this.BELGE_TUR.FieldName = "BELGE_TUR";
            this.BELGE_TUR.Name = "BELGE_TUR";
            this.BELGE_TUR.Visible = true;
            this.BELGE_TUR.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit15
            // 
            this.repositoryItemTextEdit15.AutoHeight = false;
            this.repositoryItemTextEdit15.Name = "repositoryItemTextEdit15";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(746, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Rücu Belge Tür Kodlarý";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.sBtnKaydet);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(746, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(60, 10);
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
            this.gridControlExtender1.GridControl = this.gridRucuBelgeTurKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(503, 386);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 15;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmRucuBelgeTurKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 421);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelRucuBelgeTur);
            this.Name = "frmRucuBelgeTurKodlari";
            this.Text = "Rücu Belge Tür Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelRucuBelgeTur)).EndInit();
            this.panelRucuBelgeTur.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRucuBelgeTurKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelRucuBelgeTur;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridRucuBelgeTurKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn BELGE_TUR;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit15;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}