namespace  AdimAdimDavaKaydi.UserControls.UcDava
{
    partial class ucDavaDusmeYenileme
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridDavaDusmeYenileme = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.MyHavuz = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rlueTarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.rlueAciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gwDavaDusmeYenileme = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colADLI_BIRIM_ADLIYE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueAdliye = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colADLI_BIRIM_NO_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colADLI_BIRIM_GOREV_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueGorev = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colESKI_DAVA_DOSYA_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDUSME_DEGISME_KODU_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueNedeni = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rowDUSME_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowYENILEME_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowESKI_DAVA_DOSYA_NO = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowACIKLAMA = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.dataNavigatorExtended1 = new AdimAdimDavaKaydi.Util.DataNavigatorExtended();
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaDusmeYenileme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTarih.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwDavaDusmeYenileme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAdliye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueGorev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueNedeni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDavaDusmeYenileme
            // 
            this.gridDavaDusmeYenileme.CustomButtonlarGorunmesin = false;
            this.gridDavaDusmeYenileme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDavaDusmeYenileme.DoNotExtendEmbedNavigator = false;
            this.gridDavaDusmeYenileme.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridDavaDusmeYenileme.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni Kayýt", "FormAc"),
            new DevExpress.XtraEditors.NavigatorCustomButton(20, 20, true, false, "Düzenle", "KaydýDuzenle")});
            this.gridDavaDusmeYenileme.ExternalRepository = this.MyHavuz;
            this.gridDavaDusmeYenileme.FilterText = null;
            this.gridDavaDusmeYenileme.FilterValue = null;
            this.gridDavaDusmeYenileme.GridlerDuzenlenebilir = true;
            this.gridDavaDusmeYenileme.GridsFilterControl = null;
            this.gridDavaDusmeYenileme.Location = new System.Drawing.Point(0, 0);
            this.gridDavaDusmeYenileme.MainView = this.gwDavaDusmeYenileme;
            this.gridDavaDusmeYenileme.MyGridStyle = null;
            this.gridDavaDusmeYenileme.Name = "gridDavaDusmeYenileme";
            this.gridDavaDusmeYenileme.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueAdliye,
            this.rlueNo,
            this.rlueGorev,
            this.rlueNedeni});
            this.gridDavaDusmeYenileme.ShowRowNumbers = false;
            this.gridDavaDusmeYenileme.SilmeKaldirilsin = false;
            this.gridDavaDusmeYenileme.Size = new System.Drawing.Size(693, 388);
            this.gridDavaDusmeYenileme.TabIndex = 1;
            this.gridDavaDusmeYenileme.TemizleKaldirGorunsunmu = false;
            this.gridDavaDusmeYenileme.UniqueId = "c5391cad-9da0-4082-b18a-b7edd8eaf8fa";
            this.gridDavaDusmeYenileme.UseEmbeddedNavigator = true;
            this.gridDavaDusmeYenileme.UseHyperDragDrop = false;
            this.gridDavaDusmeYenileme.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwDavaDusmeYenileme});
            // 
            // MyHavuz
            // 
            this.MyHavuz.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueTarih,
            this.rlueAciklama,
            this.repositoryItemMemoEdit1});
            // 
            // rlueTarih
            // 
            this.rlueTarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueTarih.Name = "rlueTarih";
            this.rlueTarih.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // rlueAciklama
            // 
            this.rlueAciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueAciklama.Name = "rlueAciklama";
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            this.repositoryItemMemoEdit1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.repositoryItemMemoEdit1.ValidateOnEnterKey = true;
            // 
            // gwDavaDusmeYenileme
            // 
            this.gwDavaDusmeYenileme.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colADLI_BIRIM_ADLIYE_ID,
            this.colADLI_BIRIM_NO_ID,
            this.colADLI_BIRIM_GOREV_ID,
            this.colESKI_DAVA_DOSYA_NO,
            this.colDUSME_DEGISME_KODU_ID});
            this.gwDavaDusmeYenileme.GridControl = this.gridDavaDusmeYenileme;
            this.gwDavaDusmeYenileme.GroupPanelText = "Verileri Gruplamak Ýçin Baþlýklarý Buraya Sürükleyin..";
            this.gwDavaDusmeYenileme.IndicatorWidth = 20;
            this.gwDavaDusmeYenileme.Name = "gwDavaDusmeYenileme";
            this.gwDavaDusmeYenileme.NewItemRowText = "Yeni Kayýt Eklemek Ýçin Týklayýn..";
            this.gwDavaDusmeYenileme.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gwDavaDusmeYenileme.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gwDavaDusmeYenileme.OptionsNavigation.AutoFocusNewRow = true;
            this.gwDavaDusmeYenileme.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwDavaDusmeYenileme.OptionsView.AutoCalcPreviewLineCount = true;
            this.gwDavaDusmeYenileme.OptionsView.ColumnAutoWidth = false;
            this.gwDavaDusmeYenileme.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gwDavaDusmeYenileme.OptionsView.ShowAutoFilterRow = true;
            this.gwDavaDusmeYenileme.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwDavaDusmeYenileme.PaintStyleName = "Skin";
            // 
            // colADLI_BIRIM_ADLIYE_ID
            // 
            this.colADLI_BIRIM_ADLIYE_ID.Caption = "Adli Birim";
            this.colADLI_BIRIM_ADLIYE_ID.ColumnEdit = this.rlueAdliye;
            this.colADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.colADLI_BIRIM_ADLIYE_ID.Name = "colADLI_BIRIM_ADLIYE_ID";
            this.colADLI_BIRIM_ADLIYE_ID.Visible = true;
            this.colADLI_BIRIM_ADLIYE_ID.VisibleIndex = 0;
            this.colADLI_BIRIM_ADLIYE_ID.Width = 105;
            // 
            // rlueAdliye
            // 
            this.rlueAdliye.AutoHeight = false;
            this.rlueAdliye.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueAdliye.Name = "rlueAdliye";
            // 
            // colADLI_BIRIM_NO_ID
            // 
            this.colADLI_BIRIM_NO_ID.Caption = "Mahkeme Þubesi";
            this.colADLI_BIRIM_NO_ID.ColumnEdit = this.rlueNo;
            this.colADLI_BIRIM_NO_ID.FieldName = "ADLI_BIRIM_NO_ID";
            this.colADLI_BIRIM_NO_ID.Name = "colADLI_BIRIM_NO_ID";
            this.colADLI_BIRIM_NO_ID.Visible = true;
            this.colADLI_BIRIM_NO_ID.VisibleIndex = 1;
            this.colADLI_BIRIM_NO_ID.Width = 93;
            // 
            // rlueNo
            // 
            this.rlueNo.AutoHeight = false;
            this.rlueNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueNo.Name = "rlueNo";
            // 
            // colADLI_BIRIM_GOREV_ID
            // 
            this.colADLI_BIRIM_GOREV_ID.Caption = "Mahkeme Adý";
            this.colADLI_BIRIM_GOREV_ID.ColumnEdit = this.rlueGorev;
            this.colADLI_BIRIM_GOREV_ID.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.colADLI_BIRIM_GOREV_ID.Name = "colADLI_BIRIM_GOREV_ID";
            this.colADLI_BIRIM_GOREV_ID.Visible = true;
            this.colADLI_BIRIM_GOREV_ID.VisibleIndex = 2;
            // 
            // rlueGorev
            // 
            this.rlueGorev.AutoHeight = false;
            this.rlueGorev.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueGorev.Name = "rlueGorev";
            // 
            // colESKI_DAVA_DOSYA_NO
            // 
            this.colESKI_DAVA_DOSYA_NO.Caption = "Esas No";
            this.colESKI_DAVA_DOSYA_NO.FieldName = "ESKI_DAVA_DOSYA_NO";
            this.colESKI_DAVA_DOSYA_NO.Name = "colESKI_DAVA_DOSYA_NO";
            this.colESKI_DAVA_DOSYA_NO.OptionsColumn.AllowEdit = false;
            this.colESKI_DAVA_DOSYA_NO.OptionsColumn.ReadOnly = true;
            this.colESKI_DAVA_DOSYA_NO.Visible = true;
            this.colESKI_DAVA_DOSYA_NO.VisibleIndex = 3;
            this.colESKI_DAVA_DOSYA_NO.Width = 105;
            // 
            // colDUSME_DEGISME_KODU_ID
            // 
            this.colDUSME_DEGISME_KODU_ID.Caption = "Nedeni";
            this.colDUSME_DEGISME_KODU_ID.ColumnEdit = this.rlueNedeni;
            this.colDUSME_DEGISME_KODU_ID.FieldName = "DUSME_DEGISME_KODU_ID";
            this.colDUSME_DEGISME_KODU_ID.Name = "colDUSME_DEGISME_KODU_ID";
            this.colDUSME_DEGISME_KODU_ID.Visible = true;
            this.colDUSME_DEGISME_KODU_ID.VisibleIndex = 4;
            this.colDUSME_DEGISME_KODU_ID.Width = 284;
            // 
            // rlueNedeni
            // 
            this.rlueNedeni.AutoHeight = false;
            this.rlueNedeni.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueNedeni.Name = "rlueNedeni";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.vGridControl1);
            this.panelControl1.Controls.Add(this.dataNavigatorExtended1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(693, 388);
            this.panelControl1.TabIndex = 3;
            // 
            // vGridControl1
            // 
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.ExternalRepository = this.MyHavuz;
            this.vGridControl1.Location = new System.Drawing.Point(2, 2);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.RecordWidth = 177;
            this.vGridControl1.RowHeaderWidth = 149;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowDUSME_TARIHI,
            this.rowYENILEME_TARIHI,
            this.rowESKI_DAVA_DOSYA_NO,
            this.rowACIKLAMA});
            this.vGridControl1.Size = new System.Drawing.Size(689, 365);
            this.vGridControl1.TabIndex = 14;
            // 
            // rowDUSME_TARIHI
            // 
            this.rowDUSME_TARIHI.Name = "rowDUSME_TARIHI";
            this.rowDUSME_TARIHI.Properties.Caption = "Düþme T";
            this.rowDUSME_TARIHI.Properties.FieldName = "DUSME_TARIHI";
            this.rowDUSME_TARIHI.Properties.RowEdit = this.rlueTarih;
            // 
            // rowYENILEME_TARIHI
            // 
            this.rowYENILEME_TARIHI.Name = "rowYENILEME_TARIHI";
            this.rowYENILEME_TARIHI.Properties.Caption = "Yenileme T";
            this.rowYENILEME_TARIHI.Properties.FieldName = "YENILEME_TARIHI";
            this.rowYENILEME_TARIHI.Properties.RowEdit = this.rlueTarih;
            // 
            // rowESKI_DAVA_DOSYA_NO
            // 
            this.rowESKI_DAVA_DOSYA_NO.Name = "rowESKI_DAVA_DOSYA_NO";
            this.rowESKI_DAVA_DOSYA_NO.Properties.Caption = "Eski Dava Dosya No";
            this.rowESKI_DAVA_DOSYA_NO.Properties.FieldName = "ESKI_DAVA_DOSYA_NO";
            // 
            // rowACIKLAMA
            // 
            this.rowACIKLAMA.Height = 62;
            this.rowACIKLAMA.Name = "rowACIKLAMA";
            this.rowACIKLAMA.Properties.Caption = "Açýklama";
            this.rowACIKLAMA.Properties.FieldName = "ACIKLAMA";
            this.rowACIKLAMA.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // dataNavigatorExtended1
            // 
            this.dataNavigatorExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigatorExtended1.Location = new System.Drawing.Point(2, 367);
            this.dataNavigatorExtended1.MyChartControl = null;
            this.dataNavigatorExtended1.MyGridControl = null;
            this.dataNavigatorExtended1.MyPivotGridControl = null;
            this.dataNavigatorExtended1.MyVGridControl = null;
            this.dataNavigatorExtended1.Name = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.SelectButtonVisible = false;
            this.dataNavigatorExtended1.Size = new System.Drawing.Size(689, 19);
            this.dataNavigatorExtended1.TabIndex = 13;
            this.dataNavigatorExtended1.Text = "dataNavigatorExtended1";
            // 
            // ucDavaDusmeYenileme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridDavaDusmeYenileme);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucDavaDusmeYenileme";
            this.Size = new System.Drawing.Size(693, 388);
            this.Load += new System.EventHandler(this.ucDavaDusmeYenileme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaDusmeYenileme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTarih.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwDavaDusmeYenileme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAdliye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueGorev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueNedeni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDavaDusmeYenileme;
        private DevExpress.XtraGrid.Views.Grid.GridView gwDavaDusmeYenileme;
        private DevExpress.XtraGrid.Columns.GridColumn colESKI_DAVA_DOSYA_NO;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyHavuz;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rlueTarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit rlueAciklama;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDUSME_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowYENILEME_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowESKI_DAVA_DOSYA_NO;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowACIKLAMA;
        private AdimAdimDavaKaydi.Util.DataNavigatorExtended dataNavigatorExtended1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_ADLIYE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_NO_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_GOREV_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colDUSME_DEGISME_KODU_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueAdliye;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueGorev;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueNedeni;

    }
}
