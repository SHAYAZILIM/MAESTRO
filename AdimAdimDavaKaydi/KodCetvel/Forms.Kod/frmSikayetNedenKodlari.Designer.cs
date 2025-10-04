namespace  AnaForm
{
    partial class frmSikayetNedenKodlari
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
            this.panelSikayetNEdenKodlarý = new DevExpress.XtraEditors.PanelControl();
            this.gridSikayetNedenKodlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SIKAYET_NEDEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelSikayetNEdenKodlarý)).BeginInit();
            this.panelSikayetNEdenKodlarý.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSikayetNedenKodlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSikayetNEdenKodlarý
            // 
            this.panelSikayetNEdenKodlarý.Controls.Add(this.gridSikayetNedenKodlari);
            this.panelSikayetNEdenKodlarý.Controls.Add(this.panelControl1);
            this.panelSikayetNEdenKodlarý.Controls.Add(this.panelControl2);
            this.panelSikayetNEdenKodlarý.Location = new System.Drawing.Point(12, 12);
            this.panelSikayetNEdenKodlarý.Name = "panelSikayetNEdenKodlarý";
            this.panelSikayetNEdenKodlarý.Size = new System.Drawing.Size(750, 360);
            this.panelSikayetNEdenKodlarý.TabIndex = 15;
            // 
            // gridSikayetNedenKodlari
            // 
            this.gridSikayetNedenKodlari.CustomButtonlarGorunmesin = false;
            this.gridSikayetNedenKodlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSikayetNedenKodlari.DoNotExtendEmbedNavigator = false;
            this.gridSikayetNedenKodlari.FilterText = null;
            this.gridSikayetNedenKodlari.FilterValue = null;
            this.gridSikayetNedenKodlari.GridlerDuzenlenebilir = true;
            this.gridSikayetNedenKodlari.GridsFilterControl = null;
            this.gridSikayetNedenKodlari.Location = new System.Drawing.Point(2, 72);
            this.gridSikayetNedenKodlari.MainView = this.gridView1;
            this.gridSikayetNedenKodlari.MyGridStyle = null;
            this.gridSikayetNedenKodlari.Name = "gridSikayetNedenKodlari";
            this.gridSikayetNedenKodlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit8});
            this.gridSikayetNedenKodlari.ShowRowNumbers = false;
            this.gridSikayetNedenKodlari.Size = new System.Drawing.Size(746, 286);
            this.gridSikayetNedenKodlari.TabIndex = 5;
            this.gridSikayetNedenKodlari.TemizleKaldirGorunsunmu = false;
            this.gridSikayetNedenKodlari.UniqueId = "f42e6880-b65e-402d-8038-b279cc710a2c";
            this.gridSikayetNedenKodlari.UseEmbeddedNavigator = true;
            this.gridSikayetNedenKodlari.UseHyperDragDrop = false;
            this.gridSikayetNedenKodlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SIKAYET_NEDEN});
            this.gridView1.GridControl = this.gridSikayetNedenKodlari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Þikayet NEdeni Ekleyin ";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // SIKAYET_NEDEN
            // 
            this.SIKAYET_NEDEN.Caption = "Sikayet Nedeni";
            this.SIKAYET_NEDEN.ColumnEdit = this.repositoryItemTextEdit8;
            this.SIKAYET_NEDEN.FieldName = "SIKAYET_NEDEN";
            this.SIKAYET_NEDEN.Name = "SIKAYET_NEDEN";
            this.SIKAYET_NEDEN.Visible = true;
            this.SIKAYET_NEDEN.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit8
            // 
            this.repositoryItemTextEdit8.AutoHeight = false;
            this.repositoryItemTextEdit8.Name = "repositoryItemTextEdit8";
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
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Þikayet Neden Kodlarý";
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
            this.sBtnKaydet.Location = new System.Drawing.Point(57, 10);
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
            this.gridControlExtender1.GridControl = this.gridSikayetNedenKodlari;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(510, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 16;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmSikayetNedenKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 423);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelSikayetNEdenKodlarý);
            this.Name = "frmSikayetNedenKodlari";
            this.Text = "Þikayet Neden Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelSikayetNEdenKodlarý)).EndInit();
            this.panelSikayetNEdenKodlarý.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSikayetNedenKodlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelSikayetNEdenKodlarý;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridSikayetNedenKodlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn SIKAYET_NEDEN;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit8;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}