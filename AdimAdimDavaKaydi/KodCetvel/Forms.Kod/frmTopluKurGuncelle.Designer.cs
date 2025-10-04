namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    partial class frmTopluKurGuncelle
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
            this.gridDovizKurlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.AD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TLDEGERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spTutar = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.cbBirim = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.rLueDoviz = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelDoviz = new DevExpress.XtraEditors.PanelControl();
            this.panelNavigasyon = new DevExpress.XtraEditors.PanelControl();
            this.dtpicker = new System.Windows.Forms.DateTimePicker();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.gridDovizKurlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBirim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDoviz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelDoviz)).BeginInit();
            this.panelDoviz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelNavigasyon)).BeginInit();
            this.panelNavigasyon.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridDovizKurlari
            // 
            this.gridDovizKurlari.CustomButtonlarGorunmesin = false;
            this.gridDovizKurlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDovizKurlari.DoNotExtendEmbedNavigator = false;
            this.gridDovizKurlari.FilterText = null;
            this.gridDovizKurlari.FilterValue = null;
            this.gridDovizKurlari.GridlerDuzenlenebilir = true;
            this.gridDovizKurlari.GridsFilterControl = null;
            this.gridDovizKurlari.Location = new System.Drawing.Point(2, 45);
            this.gridDovizKurlari.MainView = this.gridView1;
            this.gridDovizKurlari.MyGridStyle = null;
            this.gridDovizKurlari.Name = "gridDovizKurlari";
            this.gridDovizKurlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbBirim,
            this.rLueDoviz,
            this.spTutar});
            this.gridDovizKurlari.ShowRowNumbers = false;
            this.gridDovizKurlari.SilmeKaldirilsin = false;
            this.gridDovizKurlari.Size = new System.Drawing.Size(698, 276);
            this.gridDovizKurlari.TabIndex = 1;
            this.gridDovizKurlari.TemizleKaldirGorunsunmu = false;
            this.gridDovizKurlari.UniqueId = "4fd22ca2-c02e-409a-9d34-fee9bda015a6";
            this.gridDovizKurlari.UseEmbeddedNavigator = true;
            this.gridDovizKurlari.UseHyperDragDrop = false;
            this.gridDovizKurlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.AD,
            this.TARIH,
            this.TLDEGERI});
            this.gridView1.GridControl = this.gridDovizKurlari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Başlıkları Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Kur Girmek İçin Tıklayınız";
            this.gridView1.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsPrint.PrintPreview = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // AD
            // 
            this.AD.Caption = "Doviz Adı";
            this.AD.FieldName = "DOVIZ";
            this.AD.Name = "AD";
            this.AD.OptionsColumn.AllowEdit = false;
            this.AD.Visible = true;
            this.AD.VisibleIndex = 0;
            // 
            // TARIH
            // 
            this.TARIH.Caption = "Kur Tarihi";
            this.TARIH.FieldName = "TARIH";
            this.TARIH.Name = "TARIH";
            this.TARIH.OptionsColumn.AllowEdit = false;
            this.TARIH.Visible = true;
            this.TARIH.VisibleIndex = 1;
            // 
            // TLDEGERI
            // 
            this.TLDEGERI.Caption = "YTL Degeri";
            this.TLDEGERI.ColumnEdit = this.spTutar;
            this.TLDEGERI.FieldName = "TL_DEGERI";
            this.TLDEGERI.Name = "TLDEGERI";
            this.TLDEGERI.Visible = true;
            this.TLDEGERI.VisibleIndex = 2;
            // 
            // spTutar
            // 
            this.spTutar.AutoHeight = false;
            this.spTutar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spTutar.Name = "spTutar";
            // 
            // cbBirim
            // 
            this.cbBirim.AutoHeight = false;
            this.cbBirim.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBirim.Name = "cbBirim";
            // 
            // rLueDoviz
            // 
            this.rLueDoviz.AutoHeight = false;
            this.rLueDoviz.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDoviz.Name = "rLueDoviz";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Günlük Döviz Kurları";
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x221;
            this.sBtnKaydet.Location = new System.Drawing.Point(16, 6);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(114, 23);
            this.sBtnKaydet.TabIndex = 0;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(698, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // panelDoviz
            // 
            this.panelDoviz.Controls.Add(this.gridDovizKurlari);
            this.panelDoviz.Controls.Add(this.panelControl1);
            this.panelDoviz.Controls.Add(this.panelNavigasyon);
            this.panelDoviz.Location = new System.Drawing.Point(12, 12);
            this.panelDoviz.Name = "panelDoviz";
            this.panelDoviz.Size = new System.Drawing.Size(702, 323);
            this.panelDoviz.TabIndex = 4;
            // 
            // panelNavigasyon
            // 
            this.panelNavigasyon.Controls.Add(this.dtpicker);
            this.panelNavigasyon.Controls.Add(this.sBtnKaydet);
            this.panelNavigasyon.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNavigasyon.Location = new System.Drawing.Point(2, 2);
            this.panelNavigasyon.Name = "panelNavigasyon";
            this.panelNavigasyon.Size = new System.Drawing.Size(698, 43);
            this.panelNavigasyon.TabIndex = 2;
            // 
            // dtpicker
            // 
            this.dtpicker.Location = new System.Drawing.Point(215, 8);
            this.dtpicker.Name = "dtpicker";
            this.dtpicker.Size = new System.Drawing.Size(200, 21);
            this.dtpicker.TabIndex = 1;
            this.dtpicker.ValueChanged += new System.EventHandler(this.dtpicker_ValueChanged);
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = null;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridDovizKurlari;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(698, 249);
            this.gridControlExtender1.Location = new System.Drawing.Point(397, 351);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 5;
            this.gridControlExtender1.Text = "gridControlExtender1";
            // 
            // frmTopluKurGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 459);
            this.Controls.Add(this.panelDoviz);
            this.Controls.Add(this.gridControlExtender1);
            this.Name = "frmTopluKurGuncelle";
            this.Text = "frmTopluKurGuncelleme";
            ((System.ComponentModel.ISupportInitialize)(this.gridDovizKurlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBirim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDoviz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelDoviz)).EndInit();
            this.panelDoviz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelNavigasyon)).EndInit();
            this.panelNavigasyon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDovizKurlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn AD;
        private DevExpress.XtraGrid.Columns.GridColumn TARIH;
        private DevExpress.XtraGrid.Columns.GridColumn TLDEGERI;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spTutar;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cbBirim;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDoviz;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelDoviz;
        private DevExpress.XtraEditors.PanelControl panelNavigasyon;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private System.Windows.Forms.DateTimePicker dtpicker;


    }
}