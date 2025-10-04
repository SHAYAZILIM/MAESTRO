namespace  AdimAdimDavaKaydi.Sorusturma.UserControls
{
    partial class ucHazirlikHikaye
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
            this.gridHazirlikHikaye = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gwHazirlikHikaye = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHIKAYE_SUREC_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueHikayeSurec = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISTEKLER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutViewField_gridColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn3 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            ((System.ComponentModel.ISupportInitialize)(this.gridHazirlikHikaye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwHazirlikHikaye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueHikayeSurec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridHazirlikHikaye
            // 
            this.gridHazirlikHikaye.CustomButtonlarGorunmesin = false;
            this.gridHazirlikHikaye.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHazirlikHikaye.DoNotExtendEmbedNavigator = false;
            this.gridHazirlikHikaye.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridHazirlikHikaye.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridHazirlikHikaye.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni Kayýt", "YeniKayit"),
            new DevExpress.XtraEditors.NavigatorCustomButton(20, 20, true, true, "Kaydý Düzenle", "KaydiDuzenle")});
            this.gridHazirlikHikaye.FilterText = null;
            this.gridHazirlikHikaye.FilterValue = null;
            this.gridHazirlikHikaye.GridlerDuzenlenebilir = true;
            this.gridHazirlikHikaye.GridsFilterControl = null;
            this.gridHazirlikHikaye.Location = new System.Drawing.Point(0, 0);
            this.gridHazirlikHikaye.MainView = this.gwHazirlikHikaye;
            this.gridHazirlikHikaye.MyGridStyle = null;
            this.gridHazirlikHikaye.Name = "gridHazirlikHikaye";
            this.gridHazirlikHikaye.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueHikayeSurec});
            this.gridHazirlikHikaye.ShowRowNumbers = false;
            this.gridHazirlikHikaye.SilmeKaldirilsin = false;
            this.gridHazirlikHikaye.Size = new System.Drawing.Size(703, 507);
            this.gridHazirlikHikaye.TabIndex = 0;
            this.gridHazirlikHikaye.TemizleKaldirGorunsunmu = false;
            this.gridHazirlikHikaye.UniqueId = "8bbc87b2-f72c-44cb-92de-87933cb4abd0";
            this.gridHazirlikHikaye.UseEmbeddedNavigator = true;
            this.gridHazirlikHikaye.UseHyperDragDrop = false;
            this.gridHazirlikHikaye.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwHazirlikHikaye});
            this.gridHazirlikHikaye.ButtonClick += new System.EventHandler<DevExpress.XtraEditors.NavigatorButtonClickEventArgs>(this.gridHazirlikHikaye_ButtonClick);
            // 
            // gwHazirlikHikaye
            // 
            this.gwHazirlikHikaye.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHIKAYE_SUREC_ID,
            this.colACIKLAMA,
            this.colISTEKLER});
            this.gwHazirlikHikaye.GridControl = this.gridHazirlikHikaye;
            this.gwHazirlikHikaye.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, "")});
            this.gwHazirlikHikaye.IndicatorWidth = 20;
            this.gwHazirlikHikaye.Name = "gwHazirlikHikaye";
            this.gwHazirlikHikaye.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwHazirlikHikaye.OptionsNavigation.AutoFocusNewRow = true;
            this.gwHazirlikHikaye.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwHazirlikHikaye.OptionsView.ColumnAutoWidth = false;
            this.gwHazirlikHikaye.OptionsView.ShowAutoFilterRow = true;
            this.gwHazirlikHikaye.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwHazirlikHikaye.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gwHazirlikHikaye.OptionsView.ShowPreview = true;
            this.gwHazirlikHikaye.PreviewFieldName = "ACIKLAMA";
            // 
            // colHIKAYE_SUREC_ID
            // 
            this.colHIKAYE_SUREC_ID.Caption = "Süreç";
            this.colHIKAYE_SUREC_ID.ColumnEdit = this.rLueHikayeSurec;
            this.colHIKAYE_SUREC_ID.FieldName = "HIKAYE_SUREC_ID";
            this.colHIKAYE_SUREC_ID.Name = "colHIKAYE_SUREC_ID";
            this.colHIKAYE_SUREC_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colHIKAYE_SUREC_ID.Visible = true;
            this.colHIKAYE_SUREC_ID.VisibleIndex = 0;
            this.colHIKAYE_SUREC_ID.Width = 225;
            // 
            // rLueHikayeSurec
            // 
            this.rLueHikayeSurec.AutoHeight = false;
            this.rLueHikayeSurec.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueHikayeSurec.Name = "rLueHikayeSurec";
            // 
            // colACIKLAMA
            // 
            this.colACIKLAMA.Caption = "Açýklama";
            this.colACIKLAMA.FieldName = "ACIKLAMA";
            this.colACIKLAMA.Name = "colACIKLAMA";
            this.colACIKLAMA.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colACIKLAMA.Visible = true;
            this.colACIKLAMA.VisibleIndex = 2;
            this.colACIKLAMA.Width = 157;
            // 
            // colISTEKLER
            // 
            this.colISTEKLER.Caption = "Ýstekler";
            this.colISTEKLER.FieldName = "ISTEKLER";
            this.colISTEKLER.Name = "colISTEKLER";
            this.colISTEKLER.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colISTEKLER.Visible = true;
            this.colISTEKLER.VisibleIndex = 1;
            this.colISTEKLER.Width = 163;
            // 
            // gridControl1
            // 
            this.gridControl1.CustomButtonlarGorunmesin = false;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.DoNotExtendEmbedNavigator = false;
            this.gridControl1.FilterText = null;
            this.gridControl1.FilterValue = null;
            this.gridControl1.GridlerDuzenlenebilir = true;
            this.gridControl1.GridsFilterControl = null;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.layoutView1;
            this.gridControl1.MyGridStyle = null;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gridControl1.ShowRowNumbers = false;
            this.gridControl1.SilmeKaldirilsin = false;
            this.gridControl1.Size = new System.Drawing.Size(703, 507);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.TemizleKaldirGorunsunmu = false;
            this.gridControl1.UniqueId = "645bc401-9c81-4dd3-8569-60b414e9863a";
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.UseHyperDragDrop = false;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1});
            // 
            // layoutView1
            // 
            this.layoutView1.CardCaptionFormat = "Kayýt {0}";
            this.layoutView1.CardMinSize = new System.Drawing.Size(622, 74);
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.layoutView1.GridControl = this.gridControl1;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Süreç";
            this.gridColumn1.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.gridColumn1.FieldName = "HIKAYE_SUREC_ID";
            this.gridColumn1.LayoutViewField = this.layoutViewField_gridColumn1;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 225;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // layoutViewField_gridColumn1
            // 
            this.layoutViewField_gridColumn1.EditorPreferredWidth = 248;
            this.layoutViewField_gridColumn1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_gridColumn1.Name = "layoutViewField_gridColumn1";
            this.layoutViewField_gridColumn1.Size = new System.Drawing.Size(309, 27);
            this.layoutViewField_gridColumn1.TextSize = new System.Drawing.Size(45, 13);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Açýklama";
            this.gridColumn2.FieldName = "ACIKLAMA";
            this.gridColumn2.LayoutViewField = this.layoutViewField_gridColumn2;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 224;
            // 
            // layoutViewField_gridColumn2
            // 
            this.layoutViewField_gridColumn2.EditorPreferredWidth = 250;
            this.layoutViewField_gridColumn2.Location = new System.Drawing.Point(309, 0);
            this.layoutViewField_gridColumn2.Name = "layoutViewField_gridColumn2";
            this.layoutViewField_gridColumn2.Size = new System.Drawing.Size(311, 27);
            this.layoutViewField_gridColumn2.TextSize = new System.Drawing.Size(45, 13);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Ýstekler";
            this.gridColumn3.FieldName = "ISTEKLER";
            this.gridColumn3.LayoutViewField = this.layoutViewField_gridColumn3;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Width = 379;
            // 
            // layoutViewField_gridColumn3
            // 
            this.layoutViewField_gridColumn3.EditorPreferredWidth = 559;
            this.layoutViewField_gridColumn3.Location = new System.Drawing.Point(0, 27);
            this.layoutViewField_gridColumn3.Name = "layoutViewField_gridColumn3";
            this.layoutViewField_gridColumn3.Size = new System.Drawing.Size(620, 27);
            this.layoutViewField_gridColumn3.TextSize = new System.Drawing.Size(45, 13);
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "layoutViewTemplateCard";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_gridColumn1,
            this.layoutViewField_gridColumn3,
            this.layoutViewField_gridColumn2});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // ucHazirlikHikaye
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridHazirlikHikaye);
            this.Controls.Add(this.gridControl1);
            this.Name = "ucHazirlikHikaye";
            this.Size = new System.Drawing.Size(703, 507);
            this.Load += new System.EventHandler(this.ucHazirlikHikaye_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridHazirlikHikaye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwHazirlikHikaye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueHikayeSurec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridHazirlikHikaye;
        private DevExpress.XtraGrid.Views.Grid.GridView gwHazirlikHikaye;
        private DevExpress.XtraGrid.Columns.GridColumn colHIKAYE_SUREC_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueHikayeSurec;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn colISTEKLER;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridControl1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn2;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
    }
}
