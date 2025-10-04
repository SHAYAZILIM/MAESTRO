namespace  AdimAdimDavaKaydi.IcraTakip.UserControls
{
    partial class ucAlacakNedenTaraf_Faiz
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
            this.gcAlacakNedenFaiz = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gvAlacakNedenFaiz = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFAIZ_BASLANGIC_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_BITIS_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSABIT_FAIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlkFaizTipId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colFAIZ_ORANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBIR_GUNE_AYLIK_FAIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.spORan = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAlacakNedenFaiz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAlacakNedenFaiz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkFaizTipId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spORan)).BeginInit();
            this.SuspendLayout();
            // 
            // gcAlacakNedenFaiz
            // 
            this.gcAlacakNedenFaiz.CustomButtonlarGorunmesin = false;
            this.gcAlacakNedenFaiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAlacakNedenFaiz.DoNotExtendEmbedNavigator = false;
            this.gcAlacakNedenFaiz.EmbeddedNavigator.TextStringFormat = "Kayýt {0} - {1} ";
            this.gcAlacakNedenFaiz.FilterText = null;
            this.gcAlacakNedenFaiz.FilterValue = null;
            this.gcAlacakNedenFaiz.GridlerDuzenlenebilir = true;
            this.gcAlacakNedenFaiz.GridsFilterControl = null;
            this.gcAlacakNedenFaiz.Location = new System.Drawing.Point(0, 0);
            this.gcAlacakNedenFaiz.MainView = this.gvAlacakNedenFaiz;
            this.gcAlacakNedenFaiz.MyGridStyle = null;
            this.gcAlacakNedenFaiz.Name = "gcAlacakNedenFaiz";
            this.gcAlacakNedenFaiz.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit1,
            this.rlkFaizTipId,
            this.spORan});
            this.gcAlacakNedenFaiz.ShowRowNumbers = false;
            this.gcAlacakNedenFaiz.Size = new System.Drawing.Size(540, 273);
            this.gcAlacakNedenFaiz.TabIndex = 3;
            this.gcAlacakNedenFaiz.TemizleKaldirGorunsunmu = false;
            this.gcAlacakNedenFaiz.UniqueId = "456b0a1e-dd6c-4658-a305-b0a56872656c";
            this.gcAlacakNedenFaiz.UseEmbeddedNavigator = true;
            this.gcAlacakNedenFaiz.UseHyperDragDrop = false;
            this.gcAlacakNedenFaiz.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAlacakNedenFaiz});
            // 
            // gvAlacakNedenFaiz
            // 
            this.gvAlacakNedenFaiz.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFAIZ_BASLANGIC_TARIHI,
            this.colFAIZ_BITIS_TARIHI,
            this.colSABIT_FAIZ,
            this.colFAIZ_TIP_ID,
            this.colFAIZ_ORANI,
            this.colBIR_GUNE_AYLIK_FAIZ});
            this.gvAlacakNedenFaiz.GridControl = this.gcAlacakNedenFaiz;
            this.gvAlacakNedenFaiz.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SABIT_FAIZ", this.colSABIT_FAIZ, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BIR_GUNE_AYLIK_FAIZ", this.colBIR_GUNE_AYLIK_FAIZ, "")});
            this.gvAlacakNedenFaiz.IndicatorWidth = 20;
            this.gvAlacakNedenFaiz.Name = "gvAlacakNedenFaiz";
            this.gvAlacakNedenFaiz.NewItemRowText = "Yeni Kayýt Eklemek Ýçin Týklayýn..";
            this.gvAlacakNedenFaiz.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gvAlacakNedenFaiz.OptionsNavigation.AutoFocusNewRow = true;
            this.gvAlacakNedenFaiz.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvAlacakNedenFaiz.OptionsView.ColumnAutoWidth = false;
            this.gvAlacakNedenFaiz.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvAlacakNedenFaiz.OptionsView.ShowAutoFilterRow = true;
            this.gvAlacakNedenFaiz.OptionsView.ShowChildrenInGroupPanel = true;
            this.gvAlacakNedenFaiz.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            // 
            // colFAIZ_BASLANGIC_TARIHI
            // 
            this.colFAIZ_BASLANGIC_TARIHI.Caption = "Faiz B. T.";
            this.colFAIZ_BASLANGIC_TARIHI.FieldName = "FAIZ_BASLANGIC_TARIHI";
            this.colFAIZ_BASLANGIC_TARIHI.Name = "colFAIZ_BASLANGIC_TARIHI";
            this.colFAIZ_BASLANGIC_TARIHI.Visible = true;
            this.colFAIZ_BASLANGIC_TARIHI.VisibleIndex = 0;
            this.colFAIZ_BASLANGIC_TARIHI.Width = 105;
            // 
            // colFAIZ_BITIS_TARIHI
            // 
            this.colFAIZ_BITIS_TARIHI.Caption = "Faiz Bi. T.";
            this.colFAIZ_BITIS_TARIHI.FieldName = "FAIZ_BITIS_TARIHI";
            this.colFAIZ_BITIS_TARIHI.Name = "colFAIZ_BITIS_TARIHI";
            this.colFAIZ_BITIS_TARIHI.Visible = true;
            this.colFAIZ_BITIS_TARIHI.VisibleIndex = 1;
            this.colFAIZ_BITIS_TARIHI.Width = 96;
            // 
            // colSABIT_FAIZ
            // 
            this.colSABIT_FAIZ.Caption = "S. Faiz";
            this.colSABIT_FAIZ.FieldName = "SABIT_FAIZ";
            this.colSABIT_FAIZ.Name = "colSABIT_FAIZ";
            this.colSABIT_FAIZ.Visible = true;
            this.colSABIT_FAIZ.VisibleIndex = 2;
            this.colSABIT_FAIZ.Width = 108;
            // 
            // colFAIZ_TIP_ID
            // 
            this.colFAIZ_TIP_ID.Caption = "Faiz Tipi";
            this.colFAIZ_TIP_ID.ColumnEdit = this.rlkFaizTipId;
            this.colFAIZ_TIP_ID.FieldName = "FAIZ_TIP_ID";
            this.colFAIZ_TIP_ID.Name = "colFAIZ_TIP_ID";
            this.colFAIZ_TIP_ID.Visible = true;
            this.colFAIZ_TIP_ID.VisibleIndex = 3;
            this.colFAIZ_TIP_ID.Width = 102;
            // 
            // rlkFaizTipId
            // 
            this.rlkFaizTipId.AutoHeight = false;
            this.rlkFaizTipId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkFaizTipId.Name = "rlkFaizTipId";
            this.rlkFaizTipId.NullText = "Seç";
            // 
            // colFAIZ_ORANI
            // 
            this.colFAIZ_ORANI.Caption = "Faiz Oraný";
            this.colFAIZ_ORANI.ColumnEdit = this.spORan;
            this.colFAIZ_ORANI.FieldName = "FAIZ_ORANI";
            this.colFAIZ_ORANI.Name = "colFAIZ_ORANI";
            this.colFAIZ_ORANI.Visible = true;
            this.colFAIZ_ORANI.VisibleIndex = 4;
            this.colFAIZ_ORANI.Width = 60;
            // 
            // colBIR_GUNE_AYLIK_FAIZ
            // 
            this.colBIR_GUNE_AYLIK_FAIZ.Caption = "Bir Güne Aylýk Faiz";
            this.colBIR_GUNE_AYLIK_FAIZ.FieldName = "BIR_GUNE_AYLIK_FAIZ";
            this.colBIR_GUNE_AYLIK_FAIZ.Name = "colBIR_GUNE_AYLIK_FAIZ";
            this.colBIR_GUNE_AYLIK_FAIZ.Visible = true;
            this.colBIR_GUNE_AYLIK_FAIZ.VisibleIndex = 5;
            this.colBIR_GUNE_AYLIK_FAIZ.Width = 137;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // spORan
            // 
            this.spORan.AutoHeight = false;
            this.spORan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spORan.Name = "spORan";
            // 
            // ucAlacakNedenTaraf_Faiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcAlacakNedenFaiz);
            this.Name = "ucAlacakNedenTaraf_Faiz";
            this.Size = new System.Drawing.Size(540, 273);
            this.Load += new System.EventHandler(this.ucAlacakNedenTaraf_Faiz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcAlacakNedenFaiz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAlacakNedenFaiz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkFaizTipId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spORan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion



        
        internal AdimAdimDavaKaydi.Util.ExtendedGridControl gcAlacakNedenFaiz;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAlacakNedenFaiz;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_BASLANGIC_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_BITIS_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colSABIT_FAIZ;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_TIP_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkFaizTipId;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_ORANI;
        private DevExpress.XtraGrid.Columns.GridColumn colBIR_GUNE_AYLIK_FAIZ;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spORan;


    }
}
