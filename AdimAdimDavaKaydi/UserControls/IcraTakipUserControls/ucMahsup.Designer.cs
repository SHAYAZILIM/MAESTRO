namespace  AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    partial class ucMahsup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMahsup));
            this.gridMahsupBilgileri = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rLueDovizID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.txtAciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.gwMahsupBilgileri = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAHSUP_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAHSUP_MIKTAR_DOVIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAHSUP_MIKTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACIKLAMA2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit42 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.compGridDovizSummary1 = new AdimAdimDavaKaydi.Util.compGridDovizSummary(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridMahsupBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwMahsupBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit42.VistaTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMahsupBilgileri
            // 
            this.gridMahsupBilgileri.CustomButtonlarGorunmesin = false;
            resources.ApplyResources(this.gridMahsupBilgileri, "gridMahsupBilgileri");
            this.gridMahsupBilgileri.DoNotExtendEmbedNavigator = false;
            this.gridMahsupBilgileri.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridMahsupBilgileri.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridMahsupBilgileri.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridMahsupBilgileri.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(((int)(resources.GetObject("gridMahsupBilgileri.EmbeddedNavigator.CustomButtons"))), ((int)(resources.GetObject("gridMahsupBilgileri.EmbeddedNavigator.CustomButtons1"))), ((bool)(resources.GetObject("gridMahsupBilgileri.EmbeddedNavigator.CustomButtons2"))), ((bool)(resources.GetObject("gridMahsupBilgileri.EmbeddedNavigator.CustomButtons3"))), resources.GetString("gridMahsupBilgileri.EmbeddedNavigator.CustomButtons4"), resources.GetString("gridMahsupBilgileri.EmbeddedNavigator.CustomButtons5")),
            new DevExpress.XtraEditors.NavigatorCustomButton(((int)(resources.GetObject("gridMahsupBilgileri.EmbeddedNavigator.CustomButtons6"))), ((int)(resources.GetObject("gridMahsupBilgileri.EmbeddedNavigator.CustomButtons7"))), ((bool)(resources.GetObject("gridMahsupBilgileri.EmbeddedNavigator.CustomButtons8"))), ((bool)(resources.GetObject("gridMahsupBilgileri.EmbeddedNavigator.CustomButtons9"))), resources.GetString("gridMahsupBilgileri.EmbeddedNavigator.CustomButtons10"), resources.GetString("gridMahsupBilgileri.EmbeddedNavigator.CustomButtons11"))});
            this.gridMahsupBilgileri.ExternalRepository = this.MyRepository;
            this.gridMahsupBilgileri.FilterText = null;
            this.gridMahsupBilgileri.FilterValue = null;
            this.gridMahsupBilgileri.GridlerDuzenlenebilir = true;
            this.gridMahsupBilgileri.GridsFilterControl = null;
            this.gridMahsupBilgileri.MainView = this.gwMahsupBilgileri;
            this.gridMahsupBilgileri.MyGridStyle = null;
            this.gridMahsupBilgileri.Name = "gridMahsupBilgileri";
            this.gridMahsupBilgileri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit42});
            this.gridMahsupBilgileri.ShowRowNumbers = false;
            this.gridMahsupBilgileri.SilmeKaldirilsin = false;
            this.gridMahsupBilgileri.TemizleKaldirGorunsunmu = false;
            this.gridMahsupBilgileri.UniqueId = "495e7cb8-0eaa-48a2-a5f6-664399eebd07";
            this.gridMahsupBilgileri.UseEmbeddedNavigator = true;
            this.gridMahsupBilgileri.UseHyperDragDrop = false;
            this.gridMahsupBilgileri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwMahsupBilgileri});
            this.gridMahsupBilgileri.ButtonClick += new System.EventHandler<DevExpress.XtraEditors.NavigatorButtonClickEventArgs>(this.gridMahsupBilgileri_ButtonClick);
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueDovizID,
            this.txtAciklama});
            // 
            // rLueDovizID
            // 
            resources.ApplyResources(this.rLueDovizID, "rLueDovizID");
            this.rLueDovizID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueDovizID.Buttons"))))});
            this.rLueDovizID.Name = "rLueDovizID";
            // 
            // txtAciklama
            // 
            resources.ApplyResources(this.txtAciklama, "txtAciklama");
            this.txtAciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("txtAciklama.Buttons"))))});
            this.txtAciklama.Name = "txtAciklama";
            // 
            // gwMahsupBilgileri
            // 
            this.gwMahsupBilgileri.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAHSUP_TARIHI,
            this.colMAHSUP_MIKTAR_DOVIZ,
            this.colMAHSUP_MIKTAR,
            this.colACIKLAMA2});
            this.gwMahsupBilgileri.GridControl = this.gridMahsupBilgileri;
            resources.ApplyResources(this.gwMahsupBilgileri, "gwMahsupBilgileri");
            this.gwMahsupBilgileri.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwMahsupBilgileri.GroupSummary"))), resources.GetString("gwMahsupBilgileri.GroupSummary1"), this.colMAHSUP_MIKTAR, resources.GetString("gwMahsupBilgileri.GroupSummary2")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwMahsupBilgileri.GroupSummary3"))), resources.GetString("gwMahsupBilgileri.GroupSummary4"), this.colMAHSUP_MIKTAR, resources.GetString("gwMahsupBilgileri.GroupSummary5")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwMahsupBilgileri.GroupSummary6"))), resources.GetString("gwMahsupBilgileri.GroupSummary7"), this.colMAHSUP_MIKTAR_DOVIZ, resources.GetString("gwMahsupBilgileri.GroupSummary8")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwMahsupBilgileri.GroupSummary9"))), resources.GetString("gwMahsupBilgileri.GroupSummary10"), this.colMAHSUP_MIKTAR, resources.GetString("gwMahsupBilgileri.GroupSummary11")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwMahsupBilgileri.GroupSummary12"))), resources.GetString("gwMahsupBilgileri.GroupSummary13"), this.colMAHSUP_MIKTAR_DOVIZ, resources.GetString("gwMahsupBilgileri.GroupSummary14")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwMahsupBilgileri.GroupSummary15"))), resources.GetString("gwMahsupBilgileri.GroupSummary16"), this.colMAHSUP_MIKTAR, resources.GetString("gwMahsupBilgileri.GroupSummary17")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwMahsupBilgileri.GroupSummary18"))), resources.GetString("gwMahsupBilgileri.GroupSummary19"), this.colMAHSUP_MIKTAR_DOVIZ, resources.GetString("gwMahsupBilgileri.GroupSummary20")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwMahsupBilgileri.GroupSummary21"))), resources.GetString("gwMahsupBilgileri.GroupSummary22"), this.colMAHSUP_MIKTAR, resources.GetString("gwMahsupBilgileri.GroupSummary23")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwMahsupBilgileri.GroupSummary24"))), resources.GetString("gwMahsupBilgileri.GroupSummary25"), this.colMAHSUP_MIKTAR_DOVIZ, resources.GetString("gwMahsupBilgileri.GroupSummary26")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwMahsupBilgileri.GroupSummary27"))), resources.GetString("gwMahsupBilgileri.GroupSummary28"), this.colMAHSUP_MIKTAR, resources.GetString("gwMahsupBilgileri.GroupSummary29")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwMahsupBilgileri.GroupSummary30"))), resources.GetString("gwMahsupBilgileri.GroupSummary31"), this.colMAHSUP_MIKTAR_DOVIZ, resources.GetString("gwMahsupBilgileri.GroupSummary32")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwMahsupBilgileri.GroupSummary33"))), resources.GetString("gwMahsupBilgileri.GroupSummary34"), this.colMAHSUP_MIKTAR, resources.GetString("gwMahsupBilgileri.GroupSummary35")),
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gwMahsupBilgileri.GroupSummary36"))), resources.GetString("gwMahsupBilgileri.GroupSummary37"), this.colMAHSUP_MIKTAR_DOVIZ, resources.GetString("gwMahsupBilgileri.GroupSummary38"))});
            this.gwMahsupBilgileri.IndicatorWidth = 20;
            this.gwMahsupBilgileri.Name = "gwMahsupBilgileri";
            this.gwMahsupBilgileri.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwMahsupBilgileri.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gwMahsupBilgileri.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gwMahsupBilgileri.OptionsNavigation.AutoFocusNewRow = true;
            this.gwMahsupBilgileri.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwMahsupBilgileri.OptionsView.ColumnAutoWidth = false;
            this.gwMahsupBilgileri.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gwMahsupBilgileri.OptionsView.ShowAutoFilterRow = true;
            this.gwMahsupBilgileri.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwMahsupBilgileri.OptionsView.ShowFooter = true;
            this.gwMahsupBilgileri.OptionsView.ShowPreview = true;
            this.gwMahsupBilgileri.PaintStyleName = "Skin";
            this.gwMahsupBilgileri.PreviewFieldName = "ACIKLAMA";
            // 
            // colMAHSUP_TARIHI
            // 
            resources.ApplyResources(this.colMAHSUP_TARIHI, "colMAHSUP_TARIHI");
            this.colMAHSUP_TARIHI.FieldName = "MAHSUP_TARIHI";
            this.colMAHSUP_TARIHI.Name = "colMAHSUP_TARIHI";
            this.colMAHSUP_TARIHI.OptionsColumn.AllowEdit = false;
            this.colMAHSUP_TARIHI.OptionsColumn.ReadOnly = true;
            // 
            // colMAHSUP_MIKTAR_DOVIZ
            // 
            resources.ApplyResources(this.colMAHSUP_MIKTAR_DOVIZ, "colMAHSUP_MIKTAR_DOVIZ");
            this.colMAHSUP_MIKTAR_DOVIZ.ColumnEdit = this.rLueDovizID;
            this.colMAHSUP_MIKTAR_DOVIZ.FieldName = "MAHSUP_MIKTAR_DOVIZ_ID";
            this.colMAHSUP_MIKTAR_DOVIZ.Name = "colMAHSUP_MIKTAR_DOVIZ";
            this.colMAHSUP_MIKTAR_DOVIZ.OptionsColumn.AllowEdit = false;
            this.colMAHSUP_MIKTAR_DOVIZ.OptionsColumn.ReadOnly = true;
            this.colMAHSUP_MIKTAR_DOVIZ.SummaryItem.DisplayFormat = resources.GetString("colMAHSUP_MIKTAR_DOVIZ.SummaryItem.DisplayFormat");
            this.colMAHSUP_MIKTAR_DOVIZ.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            // 
            // colMAHSUP_MIKTAR
            // 
            resources.ApplyResources(this.colMAHSUP_MIKTAR, "colMAHSUP_MIKTAR");
            this.colMAHSUP_MIKTAR.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colMAHSUP_MIKTAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMAHSUP_MIKTAR.FieldName = "MAHSUP_MIKTAR";
            this.colMAHSUP_MIKTAR.Name = "colMAHSUP_MIKTAR";
            this.colMAHSUP_MIKTAR.OptionsColumn.AllowEdit = false;
            this.colMAHSUP_MIKTAR.OptionsColumn.ReadOnly = true;
            this.colMAHSUP_MIKTAR.SummaryItem.DisplayFormat = resources.GetString("colMAHSUP_MIKTAR.SummaryItem.DisplayFormat");
            this.colMAHSUP_MIKTAR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            // 
            // colACIKLAMA2
            // 
            resources.ApplyResources(this.colACIKLAMA2, "colACIKLAMA2");
            this.colACIKLAMA2.ColumnEdit = this.txtAciklama;
            this.colACIKLAMA2.FieldName = "ACIKLAMA";
            this.colACIKLAMA2.Name = "colACIKLAMA2";
            this.colACIKLAMA2.OptionsColumn.AllowEdit = false;
            this.colACIKLAMA2.OptionsColumn.ReadOnly = true;
            // 
            // repositoryItemDateEdit42
            // 
            resources.ApplyResources(this.repositoryItemDateEdit42, "repositoryItemDateEdit42");
            this.repositoryItemDateEdit42.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemDateEdit42.Buttons"))))});
            this.repositoryItemDateEdit42.Name = "repositoryItemDateEdit42";
            this.repositoryItemDateEdit42.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // compGridDovizSummary1
            // 
            this.compGridDovizSummary1.AltToplamlarAktifMi = true;
            this.compGridDovizSummary1.MyGridView = this.gwMahsupBilgileri;
            this.compGridDovizSummary1.YasakliAlanlar = ((System.Collections.Generic.List<string>)(resources.GetObject("compGridDovizSummary1.YasakliAlanlar")));
            // 
            // ucMahsup
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridMahsupBilgileri);
            this.Name = "ucMahsup";
            this.Load += new System.EventHandler(this.ucMahsup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMahsupBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwMahsupBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit42.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit42)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridMahsupBilgileri;
        private DevExpress.XtraGrid.Views.Grid.GridView gwMahsupBilgileri;
        private DevExpress.XtraGrid.Columns.GridColumn colMAHSUP_TARIHI;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit42;
        private DevExpress.XtraGrid.Columns.GridColumn colMAHSUP_MIKTAR_DOVIZ;
        private DevExpress.XtraGrid.Columns.GridColumn colMAHSUP_MIKTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA2;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDovizID;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit txtAciklama;
        private AdimAdimDavaKaydi.Util.compGridDovizSummary compGridDovizSummary1;
    }
}
