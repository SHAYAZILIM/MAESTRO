namespace  AnaForm
{
    partial class frmTakipYoluKodlari
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
            this.panelTakipYoluKodlari = new DevExpress.XtraEditors.PanelControl();
            this.gridTakipYoluKodlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TAKIP_YOLU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit9 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelTakipYoluKodlari)).BeginInit();
            this.panelTakipYoluKodlari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTakipYoluKodlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTakipYoluKodlari
            // 
            this.panelTakipYoluKodlari.Controls.Add(this.gridTakipYoluKodlari);
            this.panelTakipYoluKodlari.Controls.Add(this.panelControl1);
            this.panelTakipYoluKodlari.Controls.Add(this.panelControl2);
            this.panelTakipYoluKodlari.Location = new System.Drawing.Point(12, 12);
            this.panelTakipYoluKodlari.Name = "panelTakipYoluKodlari";
            this.panelTakipYoluKodlari.Size = new System.Drawing.Size(750, 360);
            this.panelTakipYoluKodlari.TabIndex = 16;
            // 
            // gridTakipYoluKodlari
            // 
            this.gridTakipYoluKodlari.CustomButtonlarGorunmesin = false;
            this.gridTakipYoluKodlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTakipYoluKodlari.DoNotExtendEmbedNavigator = false;
            this.gridTakipYoluKodlari.FilterText = null;
            this.gridTakipYoluKodlari.FilterValue = null;
            this.gridTakipYoluKodlari.GridlerDuzenlenebilir = true;
            this.gridTakipYoluKodlari.GridsFilterControl = null;
            this.gridTakipYoluKodlari.Location = new System.Drawing.Point(2, 72);
            this.gridTakipYoluKodlari.MainView = this.gridView1;
            this.gridTakipYoluKodlari.MyGridStyle = null;
            this.gridTakipYoluKodlari.Name = "gridTakipYoluKodlari";
            this.gridTakipYoluKodlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit9});
            this.gridTakipYoluKodlari.ShowRowNumbers = false;
            this.gridTakipYoluKodlari.Size = new System.Drawing.Size(746, 286);
            this.gridTakipYoluKodlari.TabIndex = 5;
            this.gridTakipYoluKodlari.TemizleKaldirGorunsunmu = false;
            this.gridTakipYoluKodlari.UniqueId = "290bb0af-5f7d-48e3-ac6a-49af15d402dd";
            this.gridTakipYoluKodlari.UseEmbeddedNavigator = true;
            this.gridTakipYoluKodlari.UseHyperDragDrop = false;
            this.gridTakipYoluKodlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TAKIP_YOLU});
            this.gridView1.GridControl = this.gridTakipYoluKodlari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Takip Yolu Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // TAKIP_YOLU
            // 
            this.TAKIP_YOLU.Caption = "Takip Yolu";
            this.TAKIP_YOLU.ColumnEdit = this.repositoryItemTextEdit9;
            this.TAKIP_YOLU.FieldName = "TAKIP_YOLU";
            this.TAKIP_YOLU.Name = "TAKIP_YOLU";
            this.TAKIP_YOLU.Visible = true;
            this.TAKIP_YOLU.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit9
            // 
            this.repositoryItemTextEdit9.AutoHeight = false;
            this.repositoryItemTextEdit9.Name = "repositoryItemTextEdit9";
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
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Takip Yolu Kodlarý";
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
            this.sBtnKaydet.Location = new System.Drawing.Point(34, 10);
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
            this.gridControlExtender1.GridControl = this.gridTakipYoluKodlari;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(421, 393);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 17;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmTakipYoluKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 439);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelTakipYoluKodlari);
            this.Name = "frmTakipYoluKodlari";
            this.Text = "Takip Yolu Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelTakipYoluKodlari)).EndInit();
            this.panelTakipYoluKodlari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTakipYoluKodlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTakipYoluKodlari;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTakipYoluKodlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn TAKIP_YOLU;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit9;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}