namespace  AnaForm
{
    partial class frmYediEminUcretiMaktu
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
            this.panelYeddiEmin = new DevExpress.XtraEditors.PanelControl();
            this.gridYeddiEminCetveli = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAracTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.OZEL_BEDEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit23 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.OZEL_DOVIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueDovizTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.BAKANLIK_BEDEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BAKANLIK_DOVIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelYeddiEmin)).BeginInit();
            this.panelYeddiEmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridYeddiEminCetveli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAracTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelYeddiEmin
            // 
            this.panelYeddiEmin.Controls.Add(this.gridYeddiEminCetveli);
            this.panelYeddiEmin.Controls.Add(this.panelControl1);
            this.panelYeddiEmin.Controls.Add(this.panelControl2);
            this.panelYeddiEmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelYeddiEmin.Location = new System.Drawing.Point(0, 0);
            this.panelYeddiEmin.Name = "panelYeddiEmin";
            this.panelYeddiEmin.Size = new System.Drawing.Size(777, 429);
            this.panelYeddiEmin.TabIndex = 17;
            // 
            // gridYeddiEminCetveli
            // 
            this.gridYeddiEminCetveli.CustomButtonlarGorunmesin = false;
            this.gridYeddiEminCetveli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridYeddiEminCetveli.DoNotExtendEmbedNavigator = false;
            this.gridYeddiEminCetveli.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridYeddiEminCetveli.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 6, true, true, "", "1")});
            this.gridYeddiEminCetveli.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridYeddiEminCetveli_EmbeddedNavigator_ButtonClick);
            this.gridYeddiEminCetveli.FilterText = null;
            this.gridYeddiEminCetveli.FilterValue = null;
            this.gridYeddiEminCetveli.GridlerDuzenlenebilir = true;
            this.gridYeddiEminCetveli.GridsFilterControl = null;
            this.gridYeddiEminCetveli.Location = new System.Drawing.Point(2, 72);
            this.gridYeddiEminCetveli.MainView = this.gridView1;
            this.gridYeddiEminCetveli.MyGridStyle = null;
            this.gridYeddiEminCetveli.Name = "gridYeddiEminCetveli";
            this.gridYeddiEminCetveli.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit23,
            this.rLueAracTip,
            this.rLueDovizTip});
            this.gridYeddiEminCetveli.ShowRowNumbers = false;
            this.gridYeddiEminCetveli.SilmeKaldirilsin = false;
            this.gridYeddiEminCetveli.Size = new System.Drawing.Size(773, 355);
            this.gridYeddiEminCetveli.TabIndex = 5;
            this.gridYeddiEminCetveli.TemizleKaldirGorunsunmu = false;
            this.gridYeddiEminCetveli.UniqueId = "a36769ec-0f1d-4f77-9053-a75b9ed3229a";
            this.gridYeddiEminCetveli.UseEmbeddedNavigator = true;
            this.gridYeddiEminCetveli.UseHyperDragDrop = false;
            this.gridYeddiEminCetveli.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TARIH,
            this.TIP,
            this.OZEL_BEDEL,
            this.OZEL_DOVIZ,
            this.BAKANLIK_BEDEL,
            this.BAKANLIK_DOVIZ});
            this.gridView1.GridControl = this.gridYeddiEminCetveli;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yedi Maktu YeddiEmin Ücreti Ekleyin";
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
            this.TARIH.FieldName = "TARIH";
            this.TARIH.Name = "TARIH";
            this.TARIH.Visible = true;
            this.TARIH.VisibleIndex = 0;
            // 
            // TIP
            // 
            this.TIP.Caption = "Tip";
            this.TIP.ColumnEdit = this.rLueAracTip;
            this.TIP.FieldName = "TIP_ID";
            this.TIP.Name = "TIP";
            this.TIP.Visible = true;
            this.TIP.VisibleIndex = 1;
            // 
            // rLueAracTip
            // 
            this.rLueAracTip.AutoHeight = false;
            this.rLueAracTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAracTip.Name = "rLueAracTip";
            // 
            // OZEL_BEDEL
            // 
            this.OZEL_BEDEL.Caption = "Özel Bedel";
            this.OZEL_BEDEL.ColumnEdit = this.repositoryItemTextEdit23;
            this.OZEL_BEDEL.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.OZEL_BEDEL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.OZEL_BEDEL.FieldName = "OZEL_BEDEL";
            this.OZEL_BEDEL.Name = "OZEL_BEDEL";
            this.OZEL_BEDEL.Visible = true;
            this.OZEL_BEDEL.VisibleIndex = 2;
            // 
            // repositoryItemTextEdit23
            // 
            this.repositoryItemTextEdit23.AutoHeight = false;
            this.repositoryItemTextEdit23.Name = "repositoryItemTextEdit23";
            // 
            // OZEL_DOVIZ
            // 
            this.OZEL_DOVIZ.ColumnEdit = this.rLueDovizTip;
            this.OZEL_DOVIZ.FieldName = "OZEL_DOVIZ_ID";
            this.OZEL_DOVIZ.Name = "OZEL_DOVIZ";
            this.OZEL_DOVIZ.Visible = true;
            this.OZEL_DOVIZ.VisibleIndex = 3;
            // 
            // rLueDovizTip
            // 
            this.rLueDovizTip.AutoHeight = false;
            this.rLueDovizTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDovizTip.Name = "rLueDovizTip";
            // 
            // BAKANLIK_BEDEL
            // 
            this.BAKANLIK_BEDEL.Caption = "Bakanlýk Bedel";
            this.BAKANLIK_BEDEL.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.BAKANLIK_BEDEL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.BAKANLIK_BEDEL.FieldName = "BAKANLIK_BEDEL";
            this.BAKANLIK_BEDEL.Name = "BAKANLIK_BEDEL";
            this.BAKANLIK_BEDEL.Visible = true;
            this.BAKANLIK_BEDEL.VisibleIndex = 4;
            // 
            // BAKANLIK_DOVIZ
            // 
            this.BAKANLIK_DOVIZ.ColumnEdit = this.rLueDovizTip;
            this.BAKANLIK_DOVIZ.FieldName = "BAKANLIK_DOVIZ_ID";
            this.BAKANLIK_DOVIZ.Name = "BAKANLIK_DOVIZ";
            this.BAKANLIK_DOVIZ.Visible = true;
            this.BAKANLIK_DOVIZ.VisibleIndex = 5;
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
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Maktu Yeddi Emin Ücretleri Cetveli";
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
            this.sBtnKaydet.Location = new System.Drawing.Point(23, 5);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 7;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridYeddiEminCetveli;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(490, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 18;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmYediEminUcretiMaktu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 429);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelYeddiEmin);
            this.Name = "frmYediEminUcretiMaktu";
            this.Text = "Maktu Yeddiemin Ücretleri Cetveli";
            ((System.ComponentModel.ISupportInitialize)(this.panelYeddiEmin)).EndInit();
            this.panelYeddiEmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridYeddiEminCetveli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAracTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelYeddiEmin;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridYeddiEminCetveli;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn TARIH;
        private DevExpress.XtraGrid.Columns.GridColumn TIP;
        private DevExpress.XtraGrid.Columns.GridColumn OZEL_BEDEL;
        private DevExpress.XtraGrid.Columns.GridColumn OZEL_DOVIZ;
        private DevExpress.XtraGrid.Columns.GridColumn BAKANLIK_BEDEL;
        private DevExpress.XtraGrid.Columns.GridColumn BAKANLIK_DOVIZ;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit23;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAracTip;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDovizTip;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}