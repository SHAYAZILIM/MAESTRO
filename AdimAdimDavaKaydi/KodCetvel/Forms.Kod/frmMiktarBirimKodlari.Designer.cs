namespace  AnaForm
{
    partial class frmMiktarBirimKodlari
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
            this.panelMiktarBirimKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridMiktarBirimKodlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.KOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.BIRIM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelMiktarBirimKodlar)).BeginInit();
            this.panelMiktarBirimKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMiktarBirimKodlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMiktarBirimKodlar
            // 
            this.panelMiktarBirimKodlar.Controls.Add(this.gridMiktarBirimKodlari);
            this.panelMiktarBirimKodlar.Controls.Add(this.panelControl1);
            this.panelMiktarBirimKodlar.Controls.Add(this.panelControl2);
            this.panelMiktarBirimKodlar.Location = new System.Drawing.Point(7, 33);
            this.panelMiktarBirimKodlar.Name = "panelMiktarBirimKodlar";
            this.panelMiktarBirimKodlar.Size = new System.Drawing.Size(750, 360);
            this.panelMiktarBirimKodlar.TabIndex = 19;
            // 
            // gridMiktarBirimKodlari
            // 
            this.gridMiktarBirimKodlari.CustomButtonlarGorunmesin = false;
            this.gridMiktarBirimKodlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMiktarBirimKodlari.DoNotExtendEmbedNavigator = false;
            this.gridMiktarBirimKodlari.FilterText = null;
            this.gridMiktarBirimKodlari.FilterValue = null;
            this.gridMiktarBirimKodlari.GridlerDuzenlenebilir = true;
            this.gridMiktarBirimKodlari.GridsFilterControl = null;
            this.gridMiktarBirimKodlari.Location = new System.Drawing.Point(2, 72);
            this.gridMiktarBirimKodlari.MainView = this.gridView1;
            this.gridMiktarBirimKodlari.MyGridStyle = null;
            this.gridMiktarBirimKodlari.Name = "gridMiktarBirimKodlari";
            this.gridMiktarBirimKodlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2});
            this.gridMiktarBirimKodlari.ShowRowNumbers = false;
            this.gridMiktarBirimKodlari.Size = new System.Drawing.Size(746, 286);
            this.gridMiktarBirimKodlari.TabIndex = 5;
            this.gridMiktarBirimKodlari.TemizleKaldirGorunsunmu = false;
            this.gridMiktarBirimKodlari.UniqueId = "aa438d3f-71ea-45ac-9abe-b5b144bf5040";
            this.gridMiktarBirimKodlari.UseEmbeddedNavigator = true;
            this.gridMiktarBirimKodlari.UseHyperDragDrop = false;
            this.gridMiktarBirimKodlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.KOD,
            this.BIRIM});
            this.gridView1.GridControl = this.gridMiktarBirimKodlari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Miktar Birimi Ekleyim";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // KOD
            // 
            this.KOD.Caption = "Miktar Birim Kodu";
            this.KOD.ColumnEdit = this.repositoryItemTextEdit1;
            this.KOD.FieldName = "KOD";
            this.KOD.Name = "KOD";
            this.KOD.Visible = true;
            this.KOD.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // BIRIM
            // 
            this.BIRIM.Caption = "Miktar Birimi";
            this.BIRIM.ColumnEdit = this.repositoryItemTextEdit2;
            this.BIRIM.FieldName = "BIRIM";
            this.BIRIM.Name = "BIRIM";
            this.BIRIM.Visible = true;
            this.BIRIM.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
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
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Miktar Birim Kodlarý";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(746, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(30, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridMiktarBirimKodlari;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(482, 399);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 20;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmMiktarBirimKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 427);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelMiktarBirimKodlar);
            this.Name = "frmMiktarBirimKodlari";
            this.Text = "Miktar Birim Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelMiktarBirimKodlar)).EndInit();
            this.panelMiktarBirimKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMiktarBirimKodlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelMiktarBirimKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridMiktarBirimKodlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn KOD;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn BIRIM;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}