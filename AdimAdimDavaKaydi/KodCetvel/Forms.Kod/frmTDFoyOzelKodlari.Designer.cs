namespace  AnaForm
{
    partial class frmTDFoyOzelKodlari
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
            this.panelDosyaOzelKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridDosyaOzelKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.KOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelDosyaOzelKodlar)).BeginInit();
            this.panelDosyaOzelKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDosyaOzelKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDosyaOzelKodlar
            // 
            this.panelDosyaOzelKodlar.Controls.Add(this.gridDosyaOzelKodlar);
            this.panelDosyaOzelKodlar.Controls.Add(this.panelControl1);
            this.panelDosyaOzelKodlar.Controls.Add(this.panelControl2);
            this.panelDosyaOzelKodlar.Location = new System.Drawing.Point(5, 12);
            this.panelDosyaOzelKodlar.Name = "panelDosyaOzelKodlar";
            this.panelDosyaOzelKodlar.Size = new System.Drawing.Size(750, 360);
            this.panelDosyaOzelKodlar.TabIndex = 11;
            // 
            // gridDosyaOzelKodlar
            // 
            this.gridDosyaOzelKodlar.CustomButtonlarGorunmesin = false;
            this.gridDosyaOzelKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDosyaOzelKodlar.DoNotExtendEmbedNavigator = false;
            this.gridDosyaOzelKodlar.FilterText = null;
            this.gridDosyaOzelKodlar.FilterValue = null;
            this.gridDosyaOzelKodlar.GridlerDuzenlenebilir = true;
            this.gridDosyaOzelKodlar.GridsFilterControl = null;
            this.gridDosyaOzelKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridDosyaOzelKodlar.MainView = this.gridView1;
            this.gridDosyaOzelKodlar.MyGridStyle = null;
            this.gridDosyaOzelKodlar.Name = "gridDosyaOzelKodlar";
            this.gridDosyaOzelKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit6});
            this.gridDosyaOzelKodlar.ShowRowNumbers = false;
            this.gridDosyaOzelKodlar.Size = new System.Drawing.Size(746, 286);
            this.gridDosyaOzelKodlar.TabIndex = 5;
            this.gridDosyaOzelKodlar.TemizleKaldirGorunsunmu = false;
            this.gridDosyaOzelKodlar.UniqueId = "cba41bc6-f97c-49ae-bafb-96e8b240cbdd";
            this.gridDosyaOzelKodlar.UseHyperDragDrop = false;
            this.gridDosyaOzelKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.KOD});
            this.gridView1.GridControl = this.gridDosyaOzelKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Dosya Özel Kodlarý Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // KOD
            // 
            this.KOD.Caption = "Dosya Özel Kod";
            this.KOD.ColumnEdit = this.repositoryItemTextEdit6;
            this.KOD.FieldName = "KOD";
            this.KOD.Name = "KOD";
            this.KOD.Visible = true;
            this.KOD.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit6
            // 
            this.repositoryItemTextEdit6.AutoHeight = false;
            this.repositoryItemTextEdit6.Name = "repositoryItemTextEdit6";
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
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dosya Özel Kodlar";
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
            this.sBtnKaydet.Location = new System.Drawing.Point(35, 10);
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
            this.gridControlExtender1.GridControl = this.gridDosyaOzelKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(426, 378);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 12;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmTDFoyOzelKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 450);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelDosyaOzelKodlar);
            this.Name = "frmTDFoyOzelKodlari";
            this.Text = "Dosya Özel Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelDosyaOzelKodlar)).EndInit();
            this.panelDosyaOzelKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDosyaOzelKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelDosyaOzelKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDosyaOzelKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn KOD;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit6;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}