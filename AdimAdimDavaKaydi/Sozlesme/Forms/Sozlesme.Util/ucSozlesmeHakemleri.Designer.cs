namespace  AdimAdimDavaKaydi.Sozlesme.Forms.Sozlesme.Util
{
    partial class ucSozlesmeHakemleri
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
            this.dataNavigator1 = new AdimAdimDavaKaydi.Util.DataNavigatorExtended();
            this.gridControl1 = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.aV001TDIBILSOZLESMEHAKEMLERIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.persistentRepository1 = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rLueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueCariHakem = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueDoviz = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueOdemeTipi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridView1 = new AdimAdimDavaKaydi.Util.ExtendedGridView();
            this.colHAKEM_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHAKEMI_SECEN_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHAKEMLIK_TEKLIF_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHAKEMLIK_AZIL_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHAKEMLIGI_KABUL_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHAKEMLIKTEN_ISTIFA_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHAKEMLIKTEN_CEKINME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUCRETIN_ODENME_SEKLI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHAKEMLIK_UCRETI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHAKEMLIK_UCRETI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rowHAKEM_CARI_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowHAKEMI_SECEN_CARI_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowHAKEMLIK_TEKLIF_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowHAKEMLIK_AZIL_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowHAKEMLIGI_KABUL_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowHAKEMLIKTEN_ISTIFA_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowHAKEMLIKTEN_CEKINME_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowUCRETIN_ODENME_SEKLI_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowHAKEMLIK_UCRETI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowHAKEMLIK_UCRETI_DOVIZ_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TDIBILSOZLESMEHAKEMLERIBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCariHakem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDoviz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOdemeTipi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Buttons.CancelEdit.Visible = false;
            this.dataNavigator1.Buttons.NextPage.Visible = false;
            this.dataNavigator1.Buttons.PrevPage.Visible = false;
            this.dataNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigator1.Location = new System.Drawing.Point(0, 248);
            this.dataNavigator1.MyChartControl = null;
            this.dataNavigator1.MyGridControl = this.gridControl1;
            this.dataNavigator1.MyPivotGridControl = null;
            this.dataNavigator1.MyVGridControl = this.vGridControl1;
            this.dataNavigator1.Name = "dataNavigator1";
            this.dataNavigator1.SelectButtonVisible = false;
            this.dataNavigator1.Size = new System.Drawing.Size(772, 24);
            this.dataNavigator1.TabIndex = 3;
            this.dataNavigator1.Text = "dataNavigatorExtended1";
            this.dataNavigator1.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.dataNavigator1.TextStringFormat = "Kayýt {0} / {1}";
            // 
            // gridControl1
            // 
            this.gridControl1.CustomButtonlarGorunmesin = false;
            this.gridControl1.DataSource = this.aV001TDIBILSOZLESMEHAKEMLERIBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.DoNotExtendEmbedNavigator = false;
            this.gridControl1.ExternalRepository = this.persistentRepository1;
            this.gridControl1.FilterText = null;
            this.gridControl1.FilterValue = null;
            this.gridControl1.GridsFilterControl = null;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MyGridStyle = null;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ShowRowNumbers = false;
            this.gridControl1.Size = new System.Drawing.Size(772, 272);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.TemizleKaldirGorunsunmu = false;
            this.gridControl1.UniqueId = "89f17e68-d1b1-4040-8633-bd5dc20018a8";
            this.gridControl1.UseHyperDragDrop = false;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // aV001TDIBILSOZLESMEHAKEMLERIBindingSource
            // 
            this.aV001TDIBILSOZLESMEHAKEMLERIBindingSource.DataSource = typeof(AvukatProLib2.Entities.AV001_TDI_BIL_SOZLESME_HAKEMLERI);
            // 
            // persistentRepository1
            // 
            this.persistentRepository1.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueCari,
            this.rLueCariHakem,
            this.rLueDoviz,
            this.rLueOdemeTipi,
            this.repositoryItemSpinEdit1});
            // 
            // rLueCari
            // 
            this.rLueCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueCari.Name = "rLueCari";
            // 
            // rLueCariHakem
            // 
            this.rLueCariHakem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueCariHakem.Name = "rLueCariHakem";
            // 
            // rLueDoviz
            // 
            this.rLueDoviz.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDoviz.Name = "rLueDoviz";
            // 
            // rLueOdemeTipi
            // 
            this.rLueOdemeTipi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueOdemeTipi.Name = "rLueOdemeTipi";
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHAKEM_CARI_ID,
            this.colHAKEMI_SECEN_CARI_ID,
            this.colHAKEMLIK_TEKLIF_TARIHI,
            this.colHAKEMLIK_AZIL_TARIHI,
            this.colHAKEMLIGI_KABUL_TARIHI,
            this.colHAKEMLIKTEN_ISTIFA_TARIHI,
            this.colHAKEMLIKTEN_CEKINME_TARIHI,
            this.colUCRETIN_ODENME_SEKLI_ID,
            this.colHAKEMLIK_UCRETI,
            this.colHAKEMLIK_UCRETI_DOVIZ_ID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colHAKEM_CARI_ID
            // 
            this.colHAKEM_CARI_ID.Caption = "Hakem";
            this.colHAKEM_CARI_ID.ColumnEdit = this.rLueCariHakem;
            this.colHAKEM_CARI_ID.FieldName = "HAKEM_CARI_ID";
            this.colHAKEM_CARI_ID.Name = "colHAKEM_CARI_ID";
            this.colHAKEM_CARI_ID.Visible = true;
            this.colHAKEM_CARI_ID.VisibleIndex = 0;
            this.colHAKEM_CARI_ID.Width = 80;
            // 
            // colHAKEMI_SECEN_CARI_ID
            // 
            this.colHAKEMI_SECEN_CARI_ID.Caption = "Hakemi Seçen";
            this.colHAKEMI_SECEN_CARI_ID.ColumnEdit = this.rLueCari;
            this.colHAKEMI_SECEN_CARI_ID.FieldName = "HAKEMI_SECEN_CARI_ID";
            this.colHAKEMI_SECEN_CARI_ID.Name = "colHAKEMI_SECEN_CARI_ID";
            this.colHAKEMI_SECEN_CARI_ID.Visible = true;
            this.colHAKEMI_SECEN_CARI_ID.VisibleIndex = 1;
            this.colHAKEMI_SECEN_CARI_ID.Width = 63;
            // 
            // colHAKEMLIK_TEKLIF_TARIHI
            // 
            this.colHAKEMLIK_TEKLIF_TARIHI.Caption = "Teklif T.";
            this.colHAKEMLIK_TEKLIF_TARIHI.FieldName = "HAKEMLIK_TEKLIF_TARIHI";
            this.colHAKEMLIK_TEKLIF_TARIHI.Name = "colHAKEMLIK_TEKLIF_TARIHI";
            this.colHAKEMLIK_TEKLIF_TARIHI.Visible = true;
            this.colHAKEMLIK_TEKLIF_TARIHI.VisibleIndex = 2;
            this.colHAKEMLIK_TEKLIF_TARIHI.Width = 50;
            // 
            // colHAKEMLIK_AZIL_TARIHI
            // 
            this.colHAKEMLIK_AZIL_TARIHI.Caption = "Hakemlik Azil T.";
            this.colHAKEMLIK_AZIL_TARIHI.FieldName = "HAKEMLIK_AZIL_TARIHI";
            this.colHAKEMLIK_AZIL_TARIHI.Name = "colHAKEMLIK_AZIL_TARIHI";
            this.colHAKEMLIK_AZIL_TARIHI.Visible = true;
            this.colHAKEMLIK_AZIL_TARIHI.VisibleIndex = 3;
            this.colHAKEMLIK_AZIL_TARIHI.Width = 72;
            // 
            // colHAKEMLIGI_KABUL_TARIHI
            // 
            this.colHAKEMLIGI_KABUL_TARIHI.Caption = "Hakemliði Kabul T.";
            this.colHAKEMLIGI_KABUL_TARIHI.FieldName = "HAKEMLIGI_KABUL_TARIHI";
            this.colHAKEMLIGI_KABUL_TARIHI.Name = "colHAKEMLIGI_KABUL_TARIHI";
            this.colHAKEMLIGI_KABUL_TARIHI.Visible = true;
            this.colHAKEMLIGI_KABUL_TARIHI.VisibleIndex = 4;
            this.colHAKEMLIGI_KABUL_TARIHI.Width = 83;
            // 
            // colHAKEMLIKTEN_ISTIFA_TARIHI
            // 
            this.colHAKEMLIKTEN_ISTIFA_TARIHI.Caption = "Hakemlikten Ýstifa T.";
            this.colHAKEMLIKTEN_ISTIFA_TARIHI.FieldName = "HAKEMLIKTEN_ISTIFA_TARIHI";
            this.colHAKEMLIKTEN_ISTIFA_TARIHI.Name = "colHAKEMLIKTEN_ISTIFA_TARIHI";
            this.colHAKEMLIKTEN_ISTIFA_TARIHI.Visible = true;
            this.colHAKEMLIKTEN_ISTIFA_TARIHI.VisibleIndex = 5;
            this.colHAKEMLIKTEN_ISTIFA_TARIHI.Width = 80;
            // 
            // colHAKEMLIKTEN_CEKINME_TARIHI
            // 
            this.colHAKEMLIKTEN_CEKINME_TARIHI.Caption = "Hakemlikten Çekinme T.";
            this.colHAKEMLIKTEN_CEKINME_TARIHI.FieldName = "HAKEMLIKTEN_CEKINME_TARIHI";
            this.colHAKEMLIKTEN_CEKINME_TARIHI.Name = "colHAKEMLIKTEN_CEKINME_TARIHI";
            this.colHAKEMLIKTEN_CEKINME_TARIHI.Visible = true;
            this.colHAKEMLIKTEN_CEKINME_TARIHI.VisibleIndex = 6;
            this.colHAKEMLIKTEN_CEKINME_TARIHI.Width = 98;
            // 
            // colUCRETIN_ODENME_SEKLI_ID
            // 
            this.colUCRETIN_ODENME_SEKLI_ID.Caption = "Ücret Ödenme Þekli";
            this.colUCRETIN_ODENME_SEKLI_ID.ColumnEdit = this.rLueOdemeTipi;
            this.colUCRETIN_ODENME_SEKLI_ID.FieldName = "UCRETIN_ODENME_SEKLI_ID";
            this.colUCRETIN_ODENME_SEKLI_ID.Name = "colUCRETIN_ODENME_SEKLI_ID";
            this.colUCRETIN_ODENME_SEKLI_ID.Visible = true;
            this.colUCRETIN_ODENME_SEKLI_ID.VisibleIndex = 7;
            this.colUCRETIN_ODENME_SEKLI_ID.Width = 89;
            // 
            // colHAKEMLIK_UCRETI
            // 
            this.colHAKEMLIK_UCRETI.Caption = "Hakemlik Ücreti";
            this.colHAKEMLIK_UCRETI.ColumnEdit = this.repositoryItemSpinEdit1;
            this.colHAKEMLIK_UCRETI.FieldName = "HAKEMLIK_UCRETI";
            this.colHAKEMLIK_UCRETI.Name = "colHAKEMLIK_UCRETI";
            this.colHAKEMLIK_UCRETI.Visible = true;
            this.colHAKEMLIK_UCRETI.VisibleIndex = 8;
            this.colHAKEMLIK_UCRETI.Width = 81;
            // 
            // colHAKEMLIK_UCRETI_DOVIZ_ID
            // 
            this.colHAKEMLIK_UCRETI_DOVIZ_ID.Caption = "Döviz";
            this.colHAKEMLIK_UCRETI_DOVIZ_ID.ColumnEdit = this.rLueDoviz;
            this.colHAKEMLIK_UCRETI_DOVIZ_ID.FieldName = "HAKEMLIK_UCRETI_DOVIZ_ID";
            this.colHAKEMLIK_UCRETI_DOVIZ_ID.Name = "colHAKEMLIK_UCRETI_DOVIZ_ID";
            this.colHAKEMLIK_UCRETI_DOVIZ_ID.Visible = true;
            this.colHAKEMLIK_UCRETI_DOVIZ_ID.VisibleIndex = 9;
            this.colHAKEMLIK_UCRETI_DOVIZ_ID.Width = 55;
            // 
            // vGridControl1
            // 
            this.vGridControl1.DataSource = this.aV001TDIBILSOZLESMEHAKEMLERIBindingSource;
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.ExternalRepository = this.persistentRepository1;
            this.vGridControl1.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.BandsView;
            this.vGridControl1.Location = new System.Drawing.Point(0, 0);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.RecordWidth = 150;
            this.vGridControl1.RowHeaderWidth = 181;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowHAKEM_CARI_ID,
            this.rowHAKEMI_SECEN_CARI_ID,
            this.rowHAKEMLIK_TEKLIF_TARIHI,
            this.rowHAKEMLIK_AZIL_TARIHI,
            this.rowHAKEMLIGI_KABUL_TARIHI,
            this.rowHAKEMLIKTEN_ISTIFA_TARIHI,
            this.rowHAKEMLIKTEN_CEKINME_TARIHI,
            this.rowUCRETIN_ODENME_SEKLI_ID,
            this.rowHAKEMLIK_UCRETI,
            this.rowHAKEMLIK_UCRETI_DOVIZ_ID});
            this.vGridControl1.Size = new System.Drawing.Size(772, 272);
            this.vGridControl1.TabIndex = 7;
            this.vGridControl1.Visible = false;
            // 
            // rowHAKEM_CARI_ID
            // 
            this.rowHAKEM_CARI_ID.Name = "rowHAKEM_CARI_ID";
            this.rowHAKEM_CARI_ID.Properties.Caption = "Hakem";
            this.rowHAKEM_CARI_ID.Properties.FieldName = "HAKEM_CARI_ID";
            this.rowHAKEM_CARI_ID.Properties.RowEdit = this.rLueCariHakem;
            // 
            // rowHAKEMI_SECEN_CARI_ID
            // 
            this.rowHAKEMI_SECEN_CARI_ID.Name = "rowHAKEMI_SECEN_CARI_ID";
            this.rowHAKEMI_SECEN_CARI_ID.Properties.Caption = "Hakemi Seçen";
            this.rowHAKEMI_SECEN_CARI_ID.Properties.FieldName = "HAKEMI_SECEN_CARI_ID";
            this.rowHAKEMI_SECEN_CARI_ID.Properties.RowEdit = this.rLueCari;
            // 
            // rowHAKEMLIK_TEKLIF_TARIHI
            // 
            this.rowHAKEMLIK_TEKLIF_TARIHI.Name = "rowHAKEMLIK_TEKLIF_TARIHI";
            this.rowHAKEMLIK_TEKLIF_TARIHI.Properties.Caption = "Hakemlik Teklif T.";
            this.rowHAKEMLIK_TEKLIF_TARIHI.Properties.FieldName = "HAKEMLIK_TEKLIF_TARIHI";
            // 
            // rowHAKEMLIK_AZIL_TARIHI
            // 
            this.rowHAKEMLIK_AZIL_TARIHI.Name = "rowHAKEMLIK_AZIL_TARIHI";
            this.rowHAKEMLIK_AZIL_TARIHI.Properties.Caption = "Hakemlik Azil T.";
            this.rowHAKEMLIK_AZIL_TARIHI.Properties.FieldName = "HAKEMLIK_AZIL_TARIHI";
            // 
            // rowHAKEMLIGI_KABUL_TARIHI
            // 
            this.rowHAKEMLIGI_KABUL_TARIHI.Height = 19;
            this.rowHAKEMLIGI_KABUL_TARIHI.Name = "rowHAKEMLIGI_KABUL_TARIHI";
            this.rowHAKEMLIGI_KABUL_TARIHI.Properties.Caption = "Hakemliði Kabul T.";
            this.rowHAKEMLIGI_KABUL_TARIHI.Properties.FieldName = "HAKEMLIGI_KABUL_TARIHI";
            // 
            // rowHAKEMLIKTEN_ISTIFA_TARIHI
            // 
            this.rowHAKEMLIKTEN_ISTIFA_TARIHI.Name = "rowHAKEMLIKTEN_ISTIFA_TARIHI";
            this.rowHAKEMLIKTEN_ISTIFA_TARIHI.Properties.Caption = "Hakemlikten Ýstifa T.";
            this.rowHAKEMLIKTEN_ISTIFA_TARIHI.Properties.FieldName = "HAKEMLIKTEN_ISTIFA_TARIHI";
            // 
            // rowHAKEMLIKTEN_CEKINME_TARIHI
            // 
            this.rowHAKEMLIKTEN_CEKINME_TARIHI.Name = "rowHAKEMLIKTEN_CEKINME_TARIHI";
            this.rowHAKEMLIKTEN_CEKINME_TARIHI.Properties.Caption = "Hakemlikten Çekinme T.";
            this.rowHAKEMLIKTEN_CEKINME_TARIHI.Properties.FieldName = "HAKEMLIKTEN_CEKINME_TARIHI";
            // 
            // rowUCRETIN_ODENME_SEKLI_ID
            // 
            this.rowUCRETIN_ODENME_SEKLI_ID.Name = "rowUCRETIN_ODENME_SEKLI_ID";
            this.rowUCRETIN_ODENME_SEKLI_ID.Properties.Caption = "Ücretin Ödenme Þekli";
            this.rowUCRETIN_ODENME_SEKLI_ID.Properties.FieldName = "UCRETIN_ODENME_SEKLI_ID";
            this.rowUCRETIN_ODENME_SEKLI_ID.Properties.RowEdit = this.rLueOdemeTipi;
            // 
            // rowHAKEMLIK_UCRETI
            // 
            this.rowHAKEMLIK_UCRETI.Name = "rowHAKEMLIK_UCRETI";
            this.rowHAKEMLIK_UCRETI.Properties.Caption = "Hakemlik Ücreti";
            this.rowHAKEMLIK_UCRETI.Properties.FieldName = "HAKEMLIK_UCRETI";
            this.rowHAKEMLIK_UCRETI.Properties.RowEdit = this.repositoryItemSpinEdit1;
            // 
            // rowHAKEMLIK_UCRETI_DOVIZ_ID
            // 
            this.rowHAKEMLIK_UCRETI_DOVIZ_ID.Name = "rowHAKEMLIK_UCRETI_DOVIZ_ID";
            this.rowHAKEMLIK_UCRETI_DOVIZ_ID.Properties.Caption = "Döviz Tipi";
            this.rowHAKEMLIK_UCRETI_DOVIZ_ID.Properties.FieldName = "HAKEMLIK_UCRETI_DOVIZ_ID";
            this.rowHAKEMLIK_UCRETI_DOVIZ_ID.Properties.RowEdit = this.rLueDoviz;
            // 
            // ucSozlesmeHakemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataNavigator1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.vGridControl1);
            this.Name = "ucSozlesmeHakemleri";
            this.Size = new System.Drawing.Size(772, 272);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TDIBILSOZLESMEHAKEMLERIBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCariHakem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDoviz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOdemeTipi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource aV001TDIBILSOZLESMEHAKEMLERIBindingSource;
        private DevExpress.XtraEditors.Repository.PersistentRepository persistentRepository1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueCariHakem;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDoviz;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueOdemeTipi;
        private AdimAdimDavaKaydi.Util.DataNavigatorExtended dataNavigator1;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHAKEM_CARI_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHAKEMI_SECEN_CARI_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHAKEMLIK_TEKLIF_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHAKEMLIK_AZIL_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHAKEMLIGI_KABUL_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHAKEMLIKTEN_ISTIFA_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHAKEMLIKTEN_CEKINME_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowUCRETIN_ODENME_SEKLI_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHAKEMLIK_UCRETI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHAKEMLIK_UCRETI_DOVIZ_ID;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridControl1;
        private AdimAdimDavaKaydi.Util.ExtendedGridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colHAKEM_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colHAKEMI_SECEN_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colHAKEMLIK_TEKLIF_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colHAKEMLIK_AZIL_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colHAKEMLIGI_KABUL_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colHAKEMLIKTEN_ISTIFA_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colHAKEMLIKTEN_CEKINME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colUCRETIN_ODENME_SEKLI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colHAKEMLIK_UCRETI;
        private DevExpress.XtraGrid.Columns.GridColumn colHAKEMLIK_UCRETI_DOVIZ_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;

    }
}
