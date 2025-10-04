namespace  AnaForm
{
    partial class frmVekaletMaktuCetveli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVekaletMaktuCetveli));
            this.panelVekaletMaktu = new DevExpress.XtraEditors.PanelControl();
            this.gridVekaletMaktu = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BASLANGIC_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MIKTAR1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit19 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.MIKTAR1_DOVIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueDovizTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.MIKTAR2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit20 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.MIKTAR2_DOVIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OZEL_MIKTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit21 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.OZEL_MIKTAR_DOVIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MAKTUKOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueMaktuKod = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemDateEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.rCb_Miktar_1_Doviz = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.rCb_Miktar_2_Doviz = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.rCb_OzelMiktarDoviz = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.rCb_MaktuKodAciklama = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelVekaletMaktu)).BeginInit();
            this.panelVekaletMaktu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVekaletMaktu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaktuKod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit8.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_Miktar_1_Doviz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_Miktar_2_Doviz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_OzelMiktarDoviz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_MaktuKodAciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelVekaletMaktu
            // 
            this.panelVekaletMaktu.Controls.Add(this.gridVekaletMaktu);
            this.panelVekaletMaktu.Controls.Add(this.panelControl1);
            this.panelVekaletMaktu.Controls.Add(this.panelControl2);
            this.panelVekaletMaktu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVekaletMaktu.Location = new System.Drawing.Point(0, 0);
            this.panelVekaletMaktu.Name = "panelVekaletMaktu";
            this.panelVekaletMaktu.Size = new System.Drawing.Size(879, 409);
            this.panelVekaletMaktu.TabIndex = 15;
            // 
            // gridVekaletMaktu
            // 
            this.gridVekaletMaktu.CustomButtonlarGorunmesin = false;
            this.gridVekaletMaktu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVekaletMaktu.DoNotExtendEmbedNavigator = false;
            this.gridVekaletMaktu.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridVekaletMaktu.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 6, true, true, "", "1")});
            this.gridVekaletMaktu.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridVekaletMaktu_EmbeddedNavigator_ButtonClick);
            this.gridVekaletMaktu.FilterText = null;
            this.gridVekaletMaktu.FilterValue = null;
            this.gridVekaletMaktu.GridlerDuzenlenebilir = true;
            this.gridVekaletMaktu.GridsFilterControl = null;
            this.gridVekaletMaktu.Location = new System.Drawing.Point(2, 72);
            this.gridVekaletMaktu.MainView = this.gridView1;
            this.gridVekaletMaktu.MyGridStyle = null;
            this.gridVekaletMaktu.Name = "gridVekaletMaktu";
            this.gridVekaletMaktu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit8,
            this.repositoryItemTextEdit19,
            this.repositoryItemTextEdit20,
            this.rCb_Miktar_1_Doviz,
            this.rCb_Miktar_2_Doviz,
            this.repositoryItemTextEdit21,
            this.rCb_OzelMiktarDoviz,
            this.rCb_MaktuKodAciklama,
            this.rLueDovizTip,
            this.lueMaktuKod});
            this.gridVekaletMaktu.ShowRowNumbers = false;
            this.gridVekaletMaktu.SilmeKaldirilsin = false;
            this.gridVekaletMaktu.Size = new System.Drawing.Size(875, 335);
            this.gridVekaletMaktu.TabIndex = 5;
            this.gridVekaletMaktu.TemizleKaldirGorunsunmu = false;
            this.gridVekaletMaktu.UniqueId = "0f980564-42e2-40bc-9f9f-f6a0d44bd5ab";
            this.gridVekaletMaktu.UseEmbeddedNavigator = true;
            this.gridVekaletMaktu.UseHyperDragDrop = false;
            this.gridVekaletMaktu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BASLANGIC_TARIHI,
            this.MIKTAR1,
            this.MIKTAR1_DOVIZ,
            this.MIKTAR2,
            this.MIKTAR2_DOVIZ,
            this.OZEL_MIKTAR,
            this.OZEL_MIKTAR_DOVIZ,
            this.MAKTUKOD});
            this.gridView1.GridControl = this.gridVekaletMaktu;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, "")});
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Kayýt Girin ";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.RowCountChanged += new System.EventHandler(this.gridView1_RowCountChanged);
            // 
            // BASLANGIC_TARIHI
            // 
            this.BASLANGIC_TARIHI.Caption = "Baþ. Tarih";
            this.BASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            this.BASLANGIC_TARIHI.Name = "BASLANGIC_TARIHI";
            this.BASLANGIC_TARIHI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.BASLANGIC_TARIHI.Visible = true;
            this.BASLANGIC_TARIHI.VisibleIndex = 0;
            // 
            // MIKTAR1
            // 
            this.MIKTAR1.Caption = "Miktar 1";
            this.MIKTAR1.ColumnEdit = this.repositoryItemTextEdit19;
            this.MIKTAR1.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.MIKTAR1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.MIKTAR1.FieldName = "MIKTAR1";
            this.MIKTAR1.Name = "MIKTAR1";
            this.MIKTAR1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.MIKTAR1.Visible = true;
            this.MIKTAR1.VisibleIndex = 2;
            // 
            // repositoryItemTextEdit19
            // 
            this.repositoryItemTextEdit19.AutoHeight = false;
            this.repositoryItemTextEdit19.Name = "repositoryItemTextEdit19";
            // 
            // MIKTAR1_DOVIZ
            // 
            this.MIKTAR1_DOVIZ.Caption = " ";
            this.MIKTAR1_DOVIZ.ColumnEdit = this.rLueDovizTip;
            this.MIKTAR1_DOVIZ.CustomizationCaption = "Miktar1 Döviz";
            this.MIKTAR1_DOVIZ.FieldName = "MIKTAR1_DOVIZ_ID";
            this.MIKTAR1_DOVIZ.Name = "MIKTAR1_DOVIZ";
            this.MIKTAR1_DOVIZ.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.MIKTAR1_DOVIZ.Visible = true;
            this.MIKTAR1_DOVIZ.VisibleIndex = 3;
            // 
            // rLueDovizTip
            // 
            this.rLueDovizTip.AutoHeight = false;
            this.rLueDovizTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDovizTip.Name = "rLueDovizTip";
            // 
            // MIKTAR2
            // 
            this.MIKTAR2.Caption = "Miktar 2";
            this.MIKTAR2.ColumnEdit = this.repositoryItemTextEdit20;
            this.MIKTAR2.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.MIKTAR2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.MIKTAR2.FieldName = "MIKTAR2";
            this.MIKTAR2.Name = "MIKTAR2";
            this.MIKTAR2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.MIKTAR2.Visible = true;
            this.MIKTAR2.VisibleIndex = 4;
            // 
            // repositoryItemTextEdit20
            // 
            this.repositoryItemTextEdit20.AutoHeight = false;
            this.repositoryItemTextEdit20.Name = "repositoryItemTextEdit20";
            // 
            // MIKTAR2_DOVIZ
            // 
            this.MIKTAR2_DOVIZ.Caption = " ";
            this.MIKTAR2_DOVIZ.ColumnEdit = this.rLueDovizTip;
            this.MIKTAR2_DOVIZ.CustomizationCaption = "Miktar2 Döviz";
            this.MIKTAR2_DOVIZ.FieldName = "MIKTAR2_DOVIZ_ID";
            this.MIKTAR2_DOVIZ.Name = "MIKTAR2_DOVIZ";
            this.MIKTAR2_DOVIZ.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.MIKTAR2_DOVIZ.Visible = true;
            this.MIKTAR2_DOVIZ.VisibleIndex = 5;
            // 
            // OZEL_MIKTAR
            // 
            this.OZEL_MIKTAR.Caption = "Özel Miktar ";
            this.OZEL_MIKTAR.ColumnEdit = this.repositoryItemTextEdit21;
            this.OZEL_MIKTAR.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.OZEL_MIKTAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.OZEL_MIKTAR.FieldName = "OZEL_MIKTAR";
            this.OZEL_MIKTAR.Name = "OZEL_MIKTAR";
            this.OZEL_MIKTAR.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.OZEL_MIKTAR.Visible = true;
            this.OZEL_MIKTAR.VisibleIndex = 6;
            // 
            // repositoryItemTextEdit21
            // 
            this.repositoryItemTextEdit21.AutoHeight = false;
            this.repositoryItemTextEdit21.Name = "repositoryItemTextEdit21";
            // 
            // OZEL_MIKTAR_DOVIZ
            // 
            this.OZEL_MIKTAR_DOVIZ.Caption = " ";
            this.OZEL_MIKTAR_DOVIZ.ColumnEdit = this.rLueDovizTip;
            this.OZEL_MIKTAR_DOVIZ.CustomizationCaption = "Özel Miktar Döviz";
            this.OZEL_MIKTAR_DOVIZ.FieldName = "OZEL_MIKTAR_DOVIZ_ID";
            this.OZEL_MIKTAR_DOVIZ.Name = "OZEL_MIKTAR_DOVIZ";
            this.OZEL_MIKTAR_DOVIZ.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.OZEL_MIKTAR_DOVIZ.Visible = true;
            this.OZEL_MIKTAR_DOVIZ.VisibleIndex = 7;
            // 
            // MAKTUKOD
            // 
            this.MAKTUKOD.Caption = "MAKTU KOD";
            this.MAKTUKOD.ColumnEdit = this.lueMaktuKod;
            this.MAKTUKOD.FieldName = "MAKTU_KOD_ID";
            this.MAKTUKOD.Name = "MAKTUKOD";
            this.MAKTUKOD.Visible = true;
            this.MAKTUKOD.VisibleIndex = 1;
            // 
            // lueMaktuKod
            // 
            this.lueMaktuKod.AutoHeight = false;
            this.lueMaktuKod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMaktuKod.Name = "lueMaktuKod";
            // 
            // repositoryItemDateEdit8
            // 
            this.repositoryItemDateEdit8.AutoHeight = false;
            this.repositoryItemDateEdit8.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit8.Name = "repositoryItemDateEdit8";
            this.repositoryItemDateEdit8.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // rCb_Miktar_1_Doviz
            // 
            this.rCb_Miktar_1_Doviz.AutoHeight = false;
            this.rCb_Miktar_1_Doviz.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_Miktar_1_Doviz.Name = "rCb_Miktar_1_Doviz";
            // 
            // rCb_Miktar_2_Doviz
            // 
            this.rCb_Miktar_2_Doviz.AutoHeight = false;
            this.rCb_Miktar_2_Doviz.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_Miktar_2_Doviz.Name = "rCb_Miktar_2_Doviz";
            // 
            // rCb_OzelMiktarDoviz
            // 
            this.rCb_OzelMiktarDoviz.AutoHeight = false;
            this.rCb_OzelMiktarDoviz.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_OzelMiktarDoviz.Name = "rCb_OzelMiktarDoviz";
            // 
            // rCb_MaktuKodAciklama
            // 
            this.rCb_MaktuKodAciklama.AutoHeight = false;
            this.rCb_MaktuKodAciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_MaktuKodAciklama.Name = "rCb_MaktuKodAciklama";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(875, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Vekalet Maktu Cetveli";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.sBtnKaydet);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(875, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("sBtnKaydet.Image")));
            this.sBtnKaydet.Location = new System.Drawing.Point(19, 5);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(114, 23);
            this.sBtnKaydet.TabIndex = 1;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridVekaletMaktu;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(463, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 16;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmVekaletMaktuCetveli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 409);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelVekaletMaktu);
            this.Name = "frmVekaletMaktuCetveli";
            this.Text = "Vekalet Maktu Cetveli";
            ((System.ComponentModel.ISupportInitialize)(this.panelVekaletMaktu)).EndInit();
            this.panelVekaletMaktu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridVekaletMaktu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaktuKod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit8.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_Miktar_1_Doviz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_Miktar_2_Doviz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_OzelMiktarDoviz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_MaktuKodAciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelVekaletMaktu;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridVekaletMaktu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn BASLANGIC_TARIHI;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit8;
        private DevExpress.XtraGrid.Columns.GridColumn MIKTAR1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit19;
        private DevExpress.XtraGrid.Columns.GridColumn MIKTAR1_DOVIZ;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_Miktar_1_Doviz;
        private DevExpress.XtraGrid.Columns.GridColumn MIKTAR2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit20;
        private DevExpress.XtraGrid.Columns.GridColumn MIKTAR2_DOVIZ;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_Miktar_2_Doviz;
        private DevExpress.XtraGrid.Columns.GridColumn OZEL_MIKTAR;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit21;
        private DevExpress.XtraGrid.Columns.GridColumn OZEL_MIKTAR_DOVIZ;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_OzelMiktarDoviz;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_MaktuKodAciklama;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDovizTip;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueMaktuKod;
        private DevExpress.XtraGrid.Columns.GridColumn MAKTUKOD;
    }
}