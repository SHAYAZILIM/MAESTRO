namespace  AnaForm
{
    partial class frmYediEminUcretiNispi
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
            this.panelNispiYeddiEmin = new DevExpress.XtraEditors.PanelControl();
            this.gridNispiYeddiEmin = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit10 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.OZEL_BEDEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit23 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.OZEL_DOVIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueDoviz = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.BAKANLIK_BEDEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spTutar = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.BAKANLIK_DOVIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ORAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spOran = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelNispiYeddiEmin)).BeginInit();
            this.panelNispiYeddiEmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNispiYeddiEmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit10.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDoviz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spOran)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNispiYeddiEmin
            // 
            this.panelNispiYeddiEmin.Controls.Add(this.gridNispiYeddiEmin);
            this.panelNispiYeddiEmin.Controls.Add(this.panelControl1);
            this.panelNispiYeddiEmin.Controls.Add(this.panelControl2);
            this.panelNispiYeddiEmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNispiYeddiEmin.Location = new System.Drawing.Point(0, 0);
            this.panelNispiYeddiEmin.Name = "panelNispiYeddiEmin";
            this.panelNispiYeddiEmin.Size = new System.Drawing.Size(777, 417);
            this.panelNispiYeddiEmin.TabIndex = 18;
            // 
            // gridNispiYeddiEmin
            // 
            this.gridNispiYeddiEmin.CustomButtonlarGorunmesin = false;
            this.gridNispiYeddiEmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridNispiYeddiEmin.DoNotExtendEmbedNavigator = false;
            this.gridNispiYeddiEmin.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridNispiYeddiEmin.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 6, true, true, "", "1")});
            this.gridNispiYeddiEmin.FilterText = null;
            this.gridNispiYeddiEmin.FilterValue = null;
            this.gridNispiYeddiEmin.GridlerDuzenlenebilir = true;
            this.gridNispiYeddiEmin.GridsFilterControl = null;
            this.gridNispiYeddiEmin.Location = new System.Drawing.Point(2, 72);
            this.gridNispiYeddiEmin.MainView = this.gridView1;
            this.gridNispiYeddiEmin.MyGridStyle = null;
            this.gridNispiYeddiEmin.Name = "gridNispiYeddiEmin";
            this.gridNispiYeddiEmin.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit10,
            this.repositoryItemTextEdit23,
            this.rlueDoviz,
            this.spTutar,
            this.spOran});
            this.gridNispiYeddiEmin.ShowRowNumbers = false;
            this.gridNispiYeddiEmin.SilmeKaldirilsin = false;
            this.gridNispiYeddiEmin.Size = new System.Drawing.Size(773, 343);
            this.gridNispiYeddiEmin.TabIndex = 5;
            this.gridNispiYeddiEmin.TemizleKaldirGorunsunmu = false;
            this.gridNispiYeddiEmin.UniqueId = "ce2dc884-ba73-4817-b946-20114debbf99";
            this.gridNispiYeddiEmin.UseEmbeddedNavigator = true;
            this.gridNispiYeddiEmin.UseHyperDragDrop = false;
            this.gridNispiYeddiEmin.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TARIH,
            this.OZEL_BEDEL,
            this.OZEL_DOVIZ,
            this.BAKANLIK_BEDEL,
            this.BAKANLIK_DOVIZ,
            this.ORAN});
            this.gridView1.GridControl = this.gridNispiYeddiEmin;
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // TARIH
            // 
            this.TARIH.Caption = "Tarih";
            this.TARIH.ColumnEdit = this.repositoryItemDateEdit10;
            this.TARIH.FieldName = "TARIH";
            this.TARIH.Name = "TARIH";
            this.TARIH.Visible = true;
            this.TARIH.VisibleIndex = 0;
            // 
            // repositoryItemDateEdit10
            // 
            this.repositoryItemDateEdit10.AutoHeight = false;
            this.repositoryItemDateEdit10.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit10.Name = "repositoryItemDateEdit10";
            this.repositoryItemDateEdit10.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // OZEL_BEDEL
            // 
            this.OZEL_BEDEL.Caption = "Özel Bedel";
            this.OZEL_BEDEL.ColumnEdit = this.repositoryItemTextEdit23;
            this.OZEL_BEDEL.FieldName = "OZEL_BEDEL";
            this.OZEL_BEDEL.Name = "OZEL_BEDEL";
            this.OZEL_BEDEL.Visible = true;
            this.OZEL_BEDEL.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit23
            // 
            this.repositoryItemTextEdit23.AutoHeight = false;
            this.repositoryItemTextEdit23.Name = "repositoryItemTextEdit23";
            // 
            // OZEL_DOVIZ
            // 
            this.OZEL_DOVIZ.Caption = "Döv. Tipi";
            this.OZEL_DOVIZ.ColumnEdit = this.rlueDoviz;
            this.OZEL_DOVIZ.FieldName = "OZEL_DOVIZ_ID";
            this.OZEL_DOVIZ.Name = "OZEL_DOVIZ";
            this.OZEL_DOVIZ.Visible = true;
            this.OZEL_DOVIZ.VisibleIndex = 2;
            // 
            // rlueDoviz
            // 
            this.rlueDoviz.AutoHeight = false;
            this.rlueDoviz.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueDoviz.Name = "rlueDoviz";
            // 
            // BAKANLIK_BEDEL
            // 
            this.BAKANLIK_BEDEL.Caption = "Bakanlýk Bedel";
            this.BAKANLIK_BEDEL.ColumnEdit = this.spTutar;
            this.BAKANLIK_BEDEL.FieldName = "BAKANLIK_BEDEL";
            this.BAKANLIK_BEDEL.Name = "BAKANLIK_BEDEL";
            this.BAKANLIK_BEDEL.Visible = true;
            this.BAKANLIK_BEDEL.VisibleIndex = 3;
            // 
            // spTutar
            // 
            this.spTutar.AutoHeight = false;
            this.spTutar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spTutar.Name = "spTutar";
            // 
            // BAKANLIK_DOVIZ
            // 
            this.BAKANLIK_DOVIZ.Caption = "Bak. Döv.Tip";
            this.BAKANLIK_DOVIZ.ColumnEdit = this.rlueDoviz;
            this.BAKANLIK_DOVIZ.FieldName = "BAKANLIK_DOVIZ_ID";
            this.BAKANLIK_DOVIZ.Name = "BAKANLIK_DOVIZ";
            this.BAKANLIK_DOVIZ.Visible = true;
            this.BAKANLIK_DOVIZ.VisibleIndex = 4;
            // 
            // ORAN
            // 
            this.ORAN.Caption = "Oran";
            this.ORAN.ColumnEdit = this.spOran;
            this.ORAN.FieldName = "ORAN";
            this.ORAN.Name = "ORAN";
            this.ORAN.Visible = true;
            this.ORAN.VisibleIndex = 5;
            // 
            // spOran
            // 
            this.spOran.AutoHeight = false;
            this.spOran.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spOran.Name = "spOran";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(773, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nispi Yeddi Emin Ücretleri";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.sBtnKaydet);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(773, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(31, 14);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 8;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // frmYediEminUcretiNispi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 417);
            this.Controls.Add(this.panelNispiYeddiEmin);
            this.Name = "frmYediEminUcretiNispi";
            this.Text = "Nispi Yeddiemin Ücretleri";
            ((System.ComponentModel.ISupportInitialize)(this.panelNispiYeddiEmin)).EndInit();
            this.panelNispiYeddiEmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridNispiYeddiEmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit10.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDoviz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spOran)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelNispiYeddiEmin;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridNispiYeddiEmin;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn TARIH;
        private DevExpress.XtraGrid.Columns.GridColumn OZEL_BEDEL;
        private DevExpress.XtraGrid.Columns.GridColumn OZEL_DOVIZ;
        private DevExpress.XtraGrid.Columns.GridColumn BAKANLIK_BEDEL;
        private DevExpress.XtraGrid.Columns.GridColumn BAKANLIK_DOVIZ;
        private DevExpress.XtraGrid.Columns.GridColumn ORAN;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit10;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit23;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueDoviz;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spTutar;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spOran;
    }
}