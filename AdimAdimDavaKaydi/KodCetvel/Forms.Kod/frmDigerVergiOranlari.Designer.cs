namespace  AnaForm
{
    partial class frmDigerVergiOranlari
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
            this.panelDigerVergiOranlari = new DevExpress.XtraEditors.PanelControl();
            this.gridDigerVergiOranlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit12 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.VERGI_TUR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueVergiTur = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.VERGI_ORAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spVergi = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelDigerVergiOranlari)).BeginInit();
            this.panelDigerVergiOranlari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDigerVergiOranlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit12.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueVergiTur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spVergi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDigerVergiOranlari
            // 
            this.panelDigerVergiOranlari.Controls.Add(this.gridDigerVergiOranlari);
            this.panelDigerVergiOranlari.Controls.Add(this.panelControl1);
            this.panelDigerVergiOranlari.Controls.Add(this.panelControl2);
            this.panelDigerVergiOranlari.Location = new System.Drawing.Point(12, 12);
            this.panelDigerVergiOranlari.Name = "panelDigerVergiOranlari";
            this.panelDigerVergiOranlari.Size = new System.Drawing.Size(750, 360);
            this.panelDigerVergiOranlari.TabIndex = 20;
            // 
            // gridDigerVergiOranlari
            // 
            this.gridDigerVergiOranlari.CustomButtonlarGorunmesin = false;
            this.gridDigerVergiOranlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDigerVergiOranlari.DoNotExtendEmbedNavigator = false;
            this.gridDigerVergiOranlari.FilterText = null;
            this.gridDigerVergiOranlari.FilterValue = null;
            this.gridDigerVergiOranlari.GridlerDuzenlenebilir = true;
            this.gridDigerVergiOranlari.GridsFilterControl = null;
            this.gridDigerVergiOranlari.Location = new System.Drawing.Point(2, 72);
            this.gridDigerVergiOranlari.MainView = this.gridView1;
            this.gridDigerVergiOranlari.MyGridStyle = null;
            this.gridDigerVergiOranlari.Name = "gridDigerVergiOranlari";
            this.gridDigerVergiOranlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit12,
            this.rLueVergiTur,
            this.spVergi});
            this.gridDigerVergiOranlari.ShowRowNumbers = false;
            this.gridDigerVergiOranlari.SilmeKaldirilsin = false;
            this.gridDigerVergiOranlari.Size = new System.Drawing.Size(746, 286);
            this.gridDigerVergiOranlari.TabIndex = 5;
            this.gridDigerVergiOranlari.TemizleKaldirGorunsunmu = false;
            this.gridDigerVergiOranlari.UniqueId = "4c1a3aa0-fdf2-4544-bf76-cf28f5fc90d7";
            this.gridDigerVergiOranlari.UseEmbeddedNavigator = true;
            this.gridDigerVergiOranlari.UseHyperDragDrop = false;
            this.gridDigerVergiOranlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TARIH,
            this.VERGI_TUR,
            this.VERGI_ORAN});
            this.gridView1.GridControl = this.gridDigerVergiOranlari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Bir Diðer Vergi Oraný Giriniz";
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
            this.TARIH.ColumnEdit = this.repositoryItemDateEdit12;
            this.TARIH.FieldName = "TARIH";
            this.TARIH.Name = "TARIH";
            this.TARIH.Visible = true;
            this.TARIH.VisibleIndex = 0;
            // 
            // repositoryItemDateEdit12
            // 
            this.repositoryItemDateEdit12.AutoHeight = false;
            this.repositoryItemDateEdit12.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit12.Name = "repositoryItemDateEdit12";
            this.repositoryItemDateEdit12.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // VERGI_TUR
            // 
            this.VERGI_TUR.Caption = "Vergi Türü";
            this.VERGI_TUR.ColumnEdit = this.rLueVergiTur;
            this.VERGI_TUR.FieldName = "VERGI_TUR_ID";
            this.VERGI_TUR.Name = "VERGI_TUR";
            this.VERGI_TUR.Visible = true;
            this.VERGI_TUR.VisibleIndex = 1;
            // 
            // rLueVergiTur
            // 
            this.rLueVergiTur.AutoHeight = false;
            this.rLueVergiTur.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueVergiTur.Name = "rLueVergiTur";
            // 
            // VERGI_ORAN
            // 
            this.VERGI_ORAN.Caption = "Vergi Oran";
            this.VERGI_ORAN.ColumnEdit = this.spVergi;
            this.VERGI_ORAN.FieldName = "VERGI_ORAN";
            this.VERGI_ORAN.Name = "VERGI_ORAN";
            this.VERGI_ORAN.Visible = true;
            this.VERGI_ORAN.VisibleIndex = 2;
            // 
            // spVergi
            // 
            this.spVergi.AutoHeight = false;
            this.spVergi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spVergi.Name = "spVergi";
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
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Diðer Vergi Oranlarý ";
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
            this.gridControlExtender1.GridControl = this.gridDigerVergiOranlari;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(437, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 21;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmDigerVergiOranlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 430);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelDigerVergiOranlari);
            this.Name = "frmDigerVergiOranlari";
            this.Text = "Diðer Vergi Oranlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelDigerVergiOranlari)).EndInit();
            this.panelDigerVergiOranlari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDigerVergiOranlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit12.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueVergiTur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spVergi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelDigerVergiOranlari;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDigerVergiOranlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn TARIH;
        private DevExpress.XtraGrid.Columns.GridColumn VERGI_TUR;
        private DevExpress.XtraGrid.Columns.GridColumn VERGI_ORAN;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit12;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueVergiTur;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spVergi;
    }
}