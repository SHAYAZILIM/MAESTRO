namespace  AnaForm
{
    partial class frmOtomatikMuhasebeKalemleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOtomatikMuhasebeKalemleri));
            this.panelOtomatikMuhasebe = new DevExpress.XtraEditors.PanelControl();
            this.gridMuhasebeKalem = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.FORM_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rCb_FormAd = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ANA_KATEGORI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rCb_AnaKategori = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ALT_KATEGORI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rCb_AltKategori = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.CETVEL_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rCb_CetvelFormAd = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.CETVEL_ALANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit11 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelOtomatikMuhasebe)).BeginInit();
            this.panelOtomatikMuhasebe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMuhasebeKalem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_FormAd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_AnaKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_AltKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_CetvelFormAd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOtomatikMuhasebe
            // 
            this.panelOtomatikMuhasebe.Controls.Add(this.gridMuhasebeKalem);
            this.panelOtomatikMuhasebe.Controls.Add(this.panelControl1);
            this.panelOtomatikMuhasebe.Controls.Add(this.panelControl2);
            this.panelOtomatikMuhasebe.Location = new System.Drawing.Point(12, 12);
            this.panelOtomatikMuhasebe.Name = "panelOtomatikMuhasebe";
            this.panelOtomatikMuhasebe.Size = new System.Drawing.Size(750, 360);
            this.panelOtomatikMuhasebe.TabIndex = 11;
            // 
            // gridMuhasebeKalem
            // 
            this.gridMuhasebeKalem.CustomButtonlarGorunmesin = false;
            this.gridMuhasebeKalem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMuhasebeKalem.DoNotExtendEmbedNavigator = false;
            this.gridMuhasebeKalem.FilterText = null;
            this.gridMuhasebeKalem.FilterValue = null;
            this.gridMuhasebeKalem.GridlerDuzenlenebilir = true;
            this.gridMuhasebeKalem.GridsFilterControl = null;
            this.gridMuhasebeKalem.Location = new System.Drawing.Point(2, 72);
            this.gridMuhasebeKalem.MainView = this.gridView1;
            this.gridMuhasebeKalem.MyGridStyle = null;
            this.gridMuhasebeKalem.Name = "gridMuhasebeKalem";
            this.gridMuhasebeKalem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rCb_AnaKategori,
            this.rCb_AltKategori,
            this.repositoryItemTextEdit11,
            this.rCb_FormAd,
            this.rCb_CetvelFormAd});
            this.gridMuhasebeKalem.ShowRowNumbers = false;
            this.gridMuhasebeKalem.Size = new System.Drawing.Size(746, 286);
            this.gridMuhasebeKalem.TabIndex = 5;
            this.gridMuhasebeKalem.TemizleKaldirGorunsunmu = false;
            this.gridMuhasebeKalem.UniqueId = "ee598f8a-d56f-4555-bcfd-bd227111646e";
            this.gridMuhasebeKalem.UseEmbeddedNavigator = true;
            this.gridMuhasebeKalem.UseHyperDragDrop = false;
            this.gridMuhasebeKalem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.FORM_ADI,
            this.ANA_KATEGORI,
            this.ALT_KATEGORI,
            this.CETVEL_ADI,
            this.CETVEL_ALANI});
            this.gridView1.GridControl = this.gridMuhasebeKalem;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Muhasebe Kalemleri Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // FORM_ADI
            // 
            this.FORM_ADI.Caption = "FORM ADI";
            this.FORM_ADI.ColumnEdit = this.rCb_FormAd;
            this.FORM_ADI.FieldName = "FORM_ADI";
            this.FORM_ADI.Name = "FORM_ADI";
            this.FORM_ADI.Visible = true;
            this.FORM_ADI.VisibleIndex = 0;
            // 
            // rCb_FormAd
            // 
            this.rCb_FormAd.AutoHeight = false;
            this.rCb_FormAd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_FormAd.Name = "rCb_FormAd";
            // 
            // ANA_KATEGORI
            // 
            this.ANA_KATEGORI.Caption = "Ana Kategori";
            this.ANA_KATEGORI.ColumnEdit = this.rCb_AnaKategori;
            this.ANA_KATEGORI.FieldName = "ANA_KATEGORI";
            this.ANA_KATEGORI.Name = "ANA_KATEGORI";
            this.ANA_KATEGORI.Visible = true;
            this.ANA_KATEGORI.VisibleIndex = 1;
            // 
            // rCb_AnaKategori
            // 
            this.rCb_AnaKategori.AutoHeight = false;
            this.rCb_AnaKategori.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_AnaKategori.Name = "rCb_AnaKategori";
            // 
            // ALT_KATEGORI
            // 
            this.ALT_KATEGORI.Caption = "ALT KATEGORI ";
            this.ALT_KATEGORI.ColumnEdit = this.rCb_AltKategori;
            this.ALT_KATEGORI.FieldName = "ALT_KATEGORI";
            this.ALT_KATEGORI.Name = "ALT_KATEGORI";
            this.ALT_KATEGORI.Visible = true;
            this.ALT_KATEGORI.VisibleIndex = 2;
            // 
            // rCb_AltKategori
            // 
            this.rCb_AltKategori.AutoHeight = false;
            this.rCb_AltKategori.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_AltKategori.Name = "rCb_AltKategori";
            // 
            // CETVEL_ADI
            // 
            this.CETVEL_ADI.Caption = "CETVEL ADI";
            this.CETVEL_ADI.ColumnEdit = this.rCb_CetvelFormAd;
            this.CETVEL_ADI.FieldName = "CETVEL_ADI";
            this.CETVEL_ADI.Name = "CETVEL_ADI";
            this.CETVEL_ADI.Visible = true;
            this.CETVEL_ADI.VisibleIndex = 3;
            // 
            // rCb_CetvelFormAd
            // 
            this.rCb_CetvelFormAd.AutoHeight = false;
            this.rCb_CetvelFormAd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_CetvelFormAd.Name = "rCb_CetvelFormAd";
            // 
            // CETVEL_ALANI
            // 
            this.CETVEL_ALANI.Caption = "CETVEL ALANI";
            this.CETVEL_ALANI.ColumnEdit = this.repositoryItemTextEdit11;
            this.CETVEL_ALANI.FieldName = "CETVEL_ALANI";
            this.CETVEL_ALANI.Name = "CETVEL_ALANI";
            this.CETVEL_ALANI.Visible = true;
            this.CETVEL_ALANI.VisibleIndex = 4;
            // 
            // repositoryItemTextEdit11
            // 
            this.repositoryItemTextEdit11.AutoHeight = false;
            this.repositoryItemTextEdit11.Name = "repositoryItemTextEdit11";
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
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Otomatik Muhasebe Kalem Cetveli";
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
            this.sBtnKaydet.Location = new System.Drawing.Point(35, 5);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 3;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridMuhasebeKalem;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(494, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 12;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmOtomatikMuhasebeKalemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 423);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelOtomatikMuhasebe);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOtomatikMuhasebeKalemleri";
            this.Text = "Otomatik Muhasebe Kalem Cetveli";
            ((System.ComponentModel.ISupportInitialize)(this.panelOtomatikMuhasebe)).EndInit();
            this.panelOtomatikMuhasebe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMuhasebeKalem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_FormAd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_AnaKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_AltKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_CetvelFormAd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelOtomatikMuhasebe;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridMuhasebeKalem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn FORM_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn ANA_KATEGORI;
        private DevExpress.XtraGrid.Columns.GridColumn ALT_KATEGORI;
        private DevExpress.XtraGrid.Columns.GridColumn CETVEL_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn CETVEL_ALANI;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_AnaKategori;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_AltKategori;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit11;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_FormAd;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_CetvelFormAd;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}