namespace  AnaForm
{
    partial class frmOzelCariKodlari
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
            this.panelCariOzelKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridCariOzelKodlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.KOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit30 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelCariOzelKodlar)).BeginInit();
            this.panelCariOzelKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCariOzelKodlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCariOzelKodlar
            // 
            this.panelCariOzelKodlar.Controls.Add(this.gridCariOzelKodlari);
            this.panelCariOzelKodlar.Controls.Add(this.panelControl1);
            this.panelCariOzelKodlar.Controls.Add(this.panelControl2);
            this.panelCariOzelKodlar.Location = new System.Drawing.Point(12, 12);
            this.panelCariOzelKodlar.Name = "panelCariOzelKodlar";
            this.panelCariOzelKodlar.Size = new System.Drawing.Size(740, 368);
            this.panelCariOzelKodlar.TabIndex = 27;
            // 
            // gridCariOzelKodlari
            // 
            this.gridCariOzelKodlari.CustomButtonlarGorunmesin = false;
            this.gridCariOzelKodlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCariOzelKodlari.DoNotExtendEmbedNavigator = false;
            this.gridCariOzelKodlari.FilterText = null;
            this.gridCariOzelKodlari.FilterValue = null;
            this.gridCariOzelKodlari.GridlerDuzenlenebilir = true;
            this.gridCariOzelKodlari.GridsFilterControl = null;
            this.gridCariOzelKodlari.Location = new System.Drawing.Point(2, 72);
            this.gridCariOzelKodlari.MainView = this.gridView1;
            this.gridCariOzelKodlari.MyGridStyle = null;
            this.gridCariOzelKodlari.Name = "gridCariOzelKodlari";
            this.gridCariOzelKodlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit30});
            this.gridCariOzelKodlari.ShowRowNumbers = false;
            this.gridCariOzelKodlari.Size = new System.Drawing.Size(736, 294);
            this.gridCariOzelKodlari.TabIndex = 5;
            this.gridCariOzelKodlari.TemizleKaldirGorunsunmu = false;
            this.gridCariOzelKodlari.UniqueId = "60dfc389-39d0-44ae-aad3-e229efb85382";
            this.gridCariOzelKodlari.UseEmbeddedNavigator = true;
            this.gridCariOzelKodlari.UseHyperDragDrop = false;
            this.gridCariOzelKodlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.KOD});
            this.gridView1.GridControl = this.gridCariOzelKodlari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Cari Özel Kodu Ekleyin";
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
            this.KOD.Caption = "Özel Cari Kodu";
            this.KOD.ColumnEdit = this.repositoryItemTextEdit30;
            this.KOD.FieldName = "KOD";
            this.KOD.Name = "KOD";
            this.KOD.Visible = true;
            this.KOD.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit30
            // 
            this.repositoryItemTextEdit30.AutoHeight = false;
            this.repositoryItemTextEdit30.Name = "repositoryItemTextEdit30";
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
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Özel Cari Kodlarý";
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
            this.sBtnKaydet.Location = new System.Drawing.Point(25, 5);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 4;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridCariOzelKodlari;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(736, 294);
            this.gridControlExtender1.Location = new System.Drawing.Point(526, 387);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 28;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmOzelCariKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 460);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelCariOzelKodlar);
            this.Name = "frmOzelCariKodlari";
            this.Text = "Özel Cari Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelCariOzelKodlar)).EndInit();
            this.panelCariOzelKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCariOzelKodlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelCariOzelKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridCariOzelKodlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn KOD;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit30;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}