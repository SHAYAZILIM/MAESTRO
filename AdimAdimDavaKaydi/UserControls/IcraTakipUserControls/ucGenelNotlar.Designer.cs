namespace  AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    partial class ucGenelNotlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucGenelNotlar));
            this.gridControl1 = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn115 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn116 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit26 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueKontrolKim = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dnDavaGenelNotlar = new AdimAdimDavaKaydi.Util.DataNavigatorExtended();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit26.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueKontrolKim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.CustomButtonlarGorunmesin = false;
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.DoNotExtendEmbedNavigator = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl1.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(((int)(resources.GetObject("gridControl1.EmbeddedNavigator.CustomButtons"))), ((int)(resources.GetObject("gridControl1.EmbeddedNavigator.CustomButtons1"))), ((bool)(resources.GetObject("gridControl1.EmbeddedNavigator.CustomButtons2"))), ((bool)(resources.GetObject("gridControl1.EmbeddedNavigator.CustomButtons3"))), resources.GetString("gridControl1.EmbeddedNavigator.CustomButtons4"), resources.GetString("gridControl1.EmbeddedNavigator.CustomButtons5")),
            new DevExpress.XtraEditors.NavigatorCustomButton(((int)(resources.GetObject("gridControl1.EmbeddedNavigator.CustomButtons6"))), ((int)(resources.GetObject("gridControl1.EmbeddedNavigator.CustomButtons7"))), ((bool)(resources.GetObject("gridControl1.EmbeddedNavigator.CustomButtons8"))), ((bool)(resources.GetObject("gridControl1.EmbeddedNavigator.CustomButtons9"))), resources.GetString("gridControl1.EmbeddedNavigator.CustomButtons10"), resources.GetString("gridControl1.EmbeddedNavigator.CustomButtons11"))});
            this.gridControl1.FilterText = null;
            this.gridControl1.FilterValue = null;
            this.gridControl1.GridlerDuzenlenebilir = true;
            this.gridControl1.GridsFilterControl = null;
            this.gridControl1.MainView = this.gridView4;
            this.gridControl1.MyGridStyle = null;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemMemoExEdit8,
            this.repositoryItemDateEdit26,
            this.rlueKontrolKim});
            this.gridControl1.ShowRowNumbers = false;
            this.gridControl1.SilmeKaldirilsin = false;
            this.gridControl1.TemizleKaldirGorunsunmu = false;
            this.gridControl1.UniqueId = "9ce53d89-fb72-4266-9342-a4664e41a1dc";
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.UseHyperDragDrop = false;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            this.gridControl1.ButtonClick += new System.EventHandler<DevExpress.XtraEditors.NavigatorButtonClickEventArgs>(this.gridControl1_ButtonClick);
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn115,
            this.gridColumn116,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView4.GridControl = this.gridControl1;
            resources.ApplyResources(this.gridView4, "gridView4");
            this.gridView4.IndicatorWidth = 20;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView4.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView4.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView4.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView4.OptionsView.ColumnAutoWidth = false;
            this.gridView4.OptionsView.ShowAutoFilterRow = true;
            this.gridView4.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView4.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView4.OptionsView.ShowPreview = true;
            this.gridView4.PreviewFieldName = "NOTLAR";
            // 
            // gridColumn115
            // 
            resources.ApplyResources(this.gridColumn115, "gridColumn115");
            this.gridColumn115.ColumnEdit = this.repositoryItemTextEdit1;
            this.gridColumn115.FieldName = "FORM_ADI";
            this.gridColumn115.Name = "gridColumn115";
            this.gridColumn115.OptionsColumn.ReadOnly = true;
            // 
            // repositoryItemTextEdit1
            // 
            resources.ApplyResources(this.repositoryItemTextEdit1, "repositoryItemTextEdit1");
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // gridColumn116
            // 
            resources.ApplyResources(this.gridColumn116, "gridColumn116");
            this.gridColumn116.ColumnEdit = this.repositoryItemMemoExEdit8;
            this.gridColumn116.FieldName = "NOTLAR";
            this.gridColumn116.Name = "gridColumn116";
            this.gridColumn116.OptionsColumn.ReadOnly = true;
            // 
            // repositoryItemMemoExEdit8
            // 
            resources.ApplyResources(this.repositoryItemMemoExEdit8, "repositoryItemMemoExEdit8");
            this.repositoryItemMemoExEdit8.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemMemoExEdit8.Buttons"))))});
            this.repositoryItemMemoExEdit8.Name = "repositoryItemMemoExEdit8";
            // 
            // gridColumn3
            // 
            resources.ApplyResources(this.gridColumn3, "gridColumn3");
            this.gridColumn3.ColumnEdit = this.repositoryItemDateEdit26;
            this.gridColumn3.FieldName = "KONTROL_NE_ZAMAN";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            // 
            // repositoryItemDateEdit26
            // 
            resources.ApplyResources(this.repositoryItemDateEdit26, "repositoryItemDateEdit26");
            this.repositoryItemDateEdit26.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemDateEdit26.Buttons"))))});
            this.repositoryItemDateEdit26.Name = "repositoryItemDateEdit26";
            this.repositoryItemDateEdit26.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridColumn4
            // 
            resources.ApplyResources(this.gridColumn4, "gridColumn4");
            this.gridColumn4.FieldName = "KONTROL_KIM";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            // 
            // rlueKontrolKim
            // 
            resources.ApplyResources(this.rlueKontrolKim, "rlueKontrolKim");
            this.rlueKontrolKim.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rlueKontrolKim.Buttons"))))});
            this.rlueKontrolKim.Name = "rlueKontrolKim";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.dnDavaGenelNotlar);
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Name = "panelControl1";
            // 
            // dnDavaGenelNotlar
            // 
            this.dnDavaGenelNotlar.Buttons.CancelEdit.Visible = false;
            this.dnDavaGenelNotlar.Buttons.NextPage.Visible = false;
            this.dnDavaGenelNotlar.Buttons.PrevPage.Visible = false;
            resources.ApplyResources(this.dnDavaGenelNotlar, "dnDavaGenelNotlar");
            this.dnDavaGenelNotlar.MyChartControl = null;
            this.dnDavaGenelNotlar.MyGridControl = null;
            this.dnDavaGenelNotlar.MyPivotGridControl = null;
            this.dnDavaGenelNotlar.MyVGridControl = null;
            this.dnDavaGenelNotlar.Name = "dnDavaGenelNotlar";
            this.dnDavaGenelNotlar.SelectButtonVisible = false;
            // 
            // ucGenelNotlar
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucGenelNotlar";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit26.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueKontrolKim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn115;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn116;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit8;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit26;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private AdimAdimDavaKaydi.Util.DataNavigatorExtended dnDavaGenelNotlar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueKontrolKim;

    }
}
