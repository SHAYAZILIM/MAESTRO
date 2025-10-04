namespace  AnaForm
{
    partial class frmTebligatKonulari
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
            this.panelTebligatKonulari = new DevExpress.XtraEditors.PanelControl();
            this.gridTebligatKonulari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ANA_TUR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rCb_TebligatAnaTur = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ALT_TUR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rCb_TabligatAltTur = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.KONU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit29 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ADLI_BIRIM_BOLUM_KOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rCb_AdliBirimBolumKod = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.SABLON_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rCb_SAblonAd = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTebligatKonulari)).BeginInit();
            this.panelTebligatKonulari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTebligatKonulari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_TebligatAnaTur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_TabligatAltTur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_AdliBirimBolumKod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_SAblonAd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTebligatKonulari
            // 
            this.panelTebligatKonulari.Controls.Add(this.gridTebligatKonulari);
            this.panelTebligatKonulari.Controls.Add(this.panelControl1);
            this.panelTebligatKonulari.Controls.Add(this.panelControl2);
            this.panelTebligatKonulari.Location = new System.Drawing.Point(9, 49);
            this.panelTebligatKonulari.Name = "panelTebligatKonulari";
            this.panelTebligatKonulari.Size = new System.Drawing.Size(750, 360);
            this.panelTebligatKonulari.TabIndex = 21;
            // 
            // gridTebligatKonulari
            // 
            this.gridTebligatKonulari.CustomButtonlarGorunmesin = false;
            this.gridTebligatKonulari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTebligatKonulari.DoNotExtendEmbedNavigator = false;
            this.gridTebligatKonulari.FilterText = null;
            this.gridTebligatKonulari.FilterValue = null;
            this.gridTebligatKonulari.GridlerDuzenlenebilir = true;
            this.gridTebligatKonulari.GridsFilterControl = null;
            this.gridTebligatKonulari.Location = new System.Drawing.Point(2, 72);
            this.gridTebligatKonulari.MainView = this.gridView1;
            this.gridTebligatKonulari.MyGridStyle = null;
            this.gridTebligatKonulari.Name = "gridTebligatKonulari";
            this.gridTebligatKonulari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rCb_TebligatAnaTur,
            this.rCb_TabligatAltTur,
            this.repositoryItemTextEdit29,
            this.rCb_AdliBirimBolumKod,
            this.rCb_SAblonAd});
            this.gridTebligatKonulari.ShowRowNumbers = false;
            this.gridTebligatKonulari.Size = new System.Drawing.Size(746, 286);
            this.gridTebligatKonulari.TabIndex = 5;
            this.gridTebligatKonulari.TemizleKaldirGorunsunmu = false;
            this.gridTebligatKonulari.UniqueId = "eac49b32-672c-48c7-b056-b389f63cf915";
            this.gridTebligatKonulari.UseEmbeddedNavigator = true;
            this.gridTebligatKonulari.UseHyperDragDrop = false;
            this.gridTebligatKonulari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ANA_TUR,
            this.ALT_TUR,
            this.KONU,
            this.ADLI_BIRIM_BOLUM_KOD,
            this.SABLON_ID});
            this.gridView1.GridControl = this.gridTebligatKonulari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Tebligat Konularý Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // ANA_TUR
            // 
            this.ANA_TUR.Caption = "Tebligat Ana Tür";
            this.ANA_TUR.ColumnEdit = this.rCb_TebligatAnaTur;
            this.ANA_TUR.FieldName = "ANA_TUR";
            this.ANA_TUR.Name = "ANA_TUR";
            this.ANA_TUR.Visible = true;
            this.ANA_TUR.VisibleIndex = 0;
            // 
            // rCb_TebligatAnaTur
            // 
            this.rCb_TebligatAnaTur.AutoHeight = false;
            this.rCb_TebligatAnaTur.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_TebligatAnaTur.Name = "rCb_TebligatAnaTur";
            // 
            // ALT_TUR
            // 
            this.ALT_TUR.Caption = "Tebligat Alt Tür";
            this.ALT_TUR.ColumnEdit = this.rCb_TabligatAltTur;
            this.ALT_TUR.FieldName = "ALT_TUR";
            this.ALT_TUR.Name = "ALT_TUR";
            this.ALT_TUR.Visible = true;
            this.ALT_TUR.VisibleIndex = 1;
            // 
            // rCb_TabligatAltTur
            // 
            this.rCb_TabligatAltTur.AutoHeight = false;
            this.rCb_TabligatAltTur.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_TabligatAltTur.Name = "rCb_TabligatAltTur";
            // 
            // KONU
            // 
            this.KONU.Caption = "Tebligat Konu";
            this.KONU.ColumnEdit = this.repositoryItemTextEdit29;
            this.KONU.FieldName = "KONU";
            this.KONU.Name = "KONU";
            this.KONU.Visible = true;
            this.KONU.VisibleIndex = 2;
            // 
            // repositoryItemTextEdit29
            // 
            this.repositoryItemTextEdit29.AutoHeight = false;
            this.repositoryItemTextEdit29.Name = "repositoryItemTextEdit29";
            // 
            // ADLI_BIRIM_BOLUM_KOD
            // 
            this.ADLI_BIRIM_BOLUM_KOD.Caption = "Adli Birim Bölüm Kodu";
            this.ADLI_BIRIM_BOLUM_KOD.ColumnEdit = this.rCb_AdliBirimBolumKod;
            this.ADLI_BIRIM_BOLUM_KOD.FieldName = "ADLI_BIRIM_BOLUM_KOD";
            this.ADLI_BIRIM_BOLUM_KOD.Name = "ADLI_BIRIM_BOLUM_KOD";
            this.ADLI_BIRIM_BOLUM_KOD.Visible = true;
            this.ADLI_BIRIM_BOLUM_KOD.VisibleIndex = 3;
            // 
            // rCb_AdliBirimBolumKod
            // 
            this.rCb_AdliBirimBolumKod.AutoHeight = false;
            this.rCb_AdliBirimBolumKod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_AdliBirimBolumKod.Name = "rCb_AdliBirimBolumKod";
            // 
            // SABLON_ID
            // 
            this.SABLON_ID.Caption = "Þablonlar";
            this.SABLON_ID.ColumnEdit = this.rCb_SAblonAd;
            this.SABLON_ID.FieldName = "Sablon_Id";
            this.SABLON_ID.Name = "SABLON_ID";
            this.SABLON_ID.Visible = true;
            this.SABLON_ID.VisibleIndex = 4;
            // 
            // rCb_SAblonAd
            // 
            this.rCb_SAblonAd.AutoHeight = false;
            this.rCb_SAblonAd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_SAblonAd.Name = "rCb_SAblonAd";
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
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tebligat Konularý";
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
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridTebligatKonulari;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(460, 416);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 22;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(29, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 7;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // frmTebligatKonulari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 458);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelTebligatKonulari);
            this.Name = "frmTebligatKonulari";
            this.Text = "Tebligat Konularý";
            ((System.ComponentModel.ISupportInitialize)(this.panelTebligatKonulari)).EndInit();
            this.panelTebligatKonulari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTebligatKonulari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_TebligatAnaTur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_TabligatAltTur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_AdliBirimBolumKod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_SAblonAd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTebligatKonulari;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTebligatKonulari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn ANA_TUR;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_TebligatAnaTur;
        private DevExpress.XtraGrid.Columns.GridColumn ALT_TUR;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_TabligatAltTur;
        private DevExpress.XtraGrid.Columns.GridColumn KONU;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit29;
        private DevExpress.XtraGrid.Columns.GridColumn ADLI_BIRIM_BOLUM_KOD;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_AdliBirimBolumKod;
        private DevExpress.XtraGrid.Columns.GridColumn SABLON_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_SAblonAd;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}