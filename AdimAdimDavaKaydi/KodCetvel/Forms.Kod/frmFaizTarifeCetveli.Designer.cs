namespace  AnaForm
{
    partial class frmFaizTarifeCetveli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFaizTarifeCetveli));
            this.panelFaizTarifeCetveli = new DevExpress.XtraEditors.PanelControl();
            this.gridFaizTarifeCetveli = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Tarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.DOVIZ_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueDovizTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.FaizTip = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueFaizTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.TARIFE_BINDE_ORAN_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueBindeYuzde = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.TARIFE_TUTARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spTutar = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.spYuzde = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelFaizTarifeCetveli)).BeginInit();
            this.panelFaizTarifeCetveli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFaizTarifeCetveli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFaizTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBindeYuzde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spYuzde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFaizTarifeCetveli
            // 
            this.panelFaizTarifeCetveli.Controls.Add(this.gridFaizTarifeCetveli);
            this.panelFaizTarifeCetveli.Controls.Add(this.panelControl1);
            this.panelFaizTarifeCetveli.Controls.Add(this.panelControl2);
            this.panelFaizTarifeCetveli.Location = new System.Drawing.Point(12, 12);
            this.panelFaizTarifeCetveli.Name = "panelFaizTarifeCetveli";
            this.panelFaizTarifeCetveli.Size = new System.Drawing.Size(750, 360);
            this.panelFaizTarifeCetveli.TabIndex = 8;
            // 
            // gridFaizTarifeCetveli
            // 
            this.gridFaizTarifeCetveli.CustomButtonlarGorunmesin = false;
            this.gridFaizTarifeCetveli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFaizTarifeCetveli.DoNotExtendEmbedNavigator = false;
            this.gridFaizTarifeCetveli.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.gridFaizTarifeCetveli.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 6, true, true, "", 1)});
            this.gridFaizTarifeCetveli.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridFaizTarifeCetveli_EmbeddedNavigator_ButtonClick);
            this.gridFaizTarifeCetveli.FilterText = null;
            this.gridFaizTarifeCetveli.FilterValue = null;
            this.gridFaizTarifeCetveli.GridlerDuzenlenebilir = true;
            this.gridFaizTarifeCetveli.GridsFilterControl = null;
            this.gridFaizTarifeCetveli.Location = new System.Drawing.Point(2, 72);
            this.gridFaizTarifeCetveli.MainView = this.gridView1;
            this.gridFaizTarifeCetveli.MyGridStyle = null;
            this.gridFaizTarifeCetveli.Name = "gridFaizTarifeCetveli";
            this.gridFaizTarifeCetveli.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.rLueDovizTip,
            this.rLueFaizTip,
            this.spTutar,
            this.spYuzde,
            this.lueBindeYuzde});
            this.gridFaizTarifeCetveli.ShowRowNumbers = false;
            this.gridFaizTarifeCetveli.SilmeKaldirilsin = false;
            this.gridFaizTarifeCetveli.Size = new System.Drawing.Size(746, 286);
            this.gridFaizTarifeCetveli.TabIndex = 5;
            this.gridFaizTarifeCetveli.TemizleKaldirGorunsunmu = false;
            this.gridFaizTarifeCetveli.UniqueId = "bf8b6e2a-92c5-41b6-aac0-3b3c8198b51d";
            this.gridFaizTarifeCetveli.UseEmbeddedNavigator = true;
            this.gridFaizTarifeCetveli.UseHyperDragDrop = false;
            this.gridFaizTarifeCetveli.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Tarih,
            this.DOVIZ_TIP,
            this.FaizTip,
            this.TARIFE_BINDE_ORAN_MI,
            this.TARIFE_TUTARI});
            this.gridView1.GridControl = this.gridFaizTarifeCetveli;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, "")});
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Faiz Tarifesi Ekle";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // Tarih
            // 
            this.Tarih.Caption = "Tarih";
            this.Tarih.ColumnEdit = this.repositoryItemDateEdit1;
            this.Tarih.FieldName = "TARIFE_GECERLILIK_BASLANGIC_TARIHI";
            this.Tarih.Name = "Tarih";
            this.Tarih.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.Tarih.Visible = true;
            this.Tarih.VisibleIndex = 0;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // DOVIZ_TIP
            // 
            this.DOVIZ_TIP.Caption = "Döviz Tip";
            this.DOVIZ_TIP.ColumnEdit = this.rLueDovizTip;
            this.DOVIZ_TIP.FieldName = "DOVIZ_TIP_ID";
            this.DOVIZ_TIP.Name = "DOVIZ_TIP";
            this.DOVIZ_TIP.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.DOVIZ_TIP.Visible = true;
            this.DOVIZ_TIP.VisibleIndex = 1;
            // 
            // rLueDovizTip
            // 
            this.rLueDovizTip.AutoHeight = false;
            this.rLueDovizTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDovizTip.Name = "rLueDovizTip";
            // 
            // FaizTip
            // 
            this.FaizTip.Caption = "Faiz Tipi";
            this.FaizTip.ColumnEdit = this.rLueFaizTip;
            this.FaizTip.FieldName = "FAIZ_TIP_ID";
            this.FaizTip.Name = "FaizTip";
            this.FaizTip.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.FaizTip.Visible = true;
            this.FaizTip.VisibleIndex = 2;
            // 
            // rLueFaizTip
            // 
            this.rLueFaizTip.AutoHeight = false;
            this.rLueFaizTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueFaizTip.Name = "rLueFaizTip";
            // 
            // TARIFE_BINDE_ORAN_MI
            // 
            this.TARIFE_BINDE_ORAN_MI.Caption = "BindeYuzde";
            this.TARIFE_BINDE_ORAN_MI.ColumnEdit = this.lueBindeYuzde;
            this.TARIFE_BINDE_ORAN_MI.FieldName = "TARIFE_BINDE_ORAN_MI";
            this.TARIFE_BINDE_ORAN_MI.Name = "TARIFE_BINDE_ORAN_MI";
            this.TARIFE_BINDE_ORAN_MI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.TARIFE_BINDE_ORAN_MI.Visible = true;
            this.TARIFE_BINDE_ORAN_MI.VisibleIndex = 3;
            // 
            // lueBindeYuzde
            // 
            this.lueBindeYuzde.AutoHeight = false;
            this.lueBindeYuzde.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBindeYuzde.Name = "lueBindeYuzde";
            // 
            // TARIFE_TUTARI
            // 
            this.TARIFE_TUTARI.Caption = "Tarife Tutarý";
            this.TARIFE_TUTARI.ColumnEdit = this.spTutar;
            this.TARIFE_TUTARI.FieldName = "TARIFE_TUTARI";
            this.TARIFE_TUTARI.Name = "TARIFE_TUTARI";
            this.TARIFE_TUTARI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.TARIFE_TUTARI.Visible = true;
            this.TARIFE_TUTARI.VisibleIndex = 4;
            // 
            // spTutar
            // 
            this.spTutar.AutoHeight = false;
            this.spTutar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spTutar.Name = "spTutar";
            // 
            // spYuzde
            // 
            this.spYuzde.AutoHeight = false;
            this.spYuzde.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spYuzde.Name = "spYuzde";
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
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Faiz Tarife Cetveli";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(746, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(31, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridFaizTarifeCetveli;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(449, 381);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 9;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmFaizTarifeCetveli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 416);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelFaizTarifeCetveli);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFaizTarifeCetveli";
            this.Text = "Faiz Tarife Cetveli";
            this.Load += new System.EventHandler(this.frmFaizTarifeCetveli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelFaizTarifeCetveli)).EndInit();
            this.panelFaizTarifeCetveli.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFaizTarifeCetveli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueFaizTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBindeYuzde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spYuzde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelFaizTarifeCetveli;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridFaizTarifeCetveli;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Tarih;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn FaizTip;
        private DevExpress.XtraGrid.Columns.GridColumn TARIFE_BINDE_ORAN_MI;
        private DevExpress.XtraGrid.Columns.GridColumn TARIFE_TUTARI;
        private DevExpress.XtraGrid.Columns.GridColumn DOVIZ_TIP;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDovizTip;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueFaizTip;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spTutar;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spYuzde;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueBindeYuzde;
    }
}
