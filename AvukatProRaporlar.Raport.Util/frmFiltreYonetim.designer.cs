using AvukatProRaporlar.Raport.Util;
namespace AvukatProRaporlar.Raport.Util
{
    partial class frmFiltreYonetim
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
            this.extendedGridControl1 = new AvukatProRaporlar.Raport.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKategori = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFiltreAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmbFiltreKategori = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtFiltreAdi = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.extendedGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFiltreKategori.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiltreAdi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // extendedGridControl1
            // 
            this.extendedGridControl1.CustomButtonlarGorunmesin = false;
            this.extendedGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extendedGridControl1.DoNotExtendEmbedNavigator = false;
            this.extendedGridControl1.FilterText = null;
            this.extendedGridControl1.FilterValue = null;
            this.extendedGridControl1.GridsFilterControl = null;
            this.extendedGridControl1.Location = new System.Drawing.Point(0, 0);
            this.extendedGridControl1.MainView = this.gridView1;
            this.extendedGridControl1.MyGridStyle = null;
            this.extendedGridControl1.Name = "extendedGridControl1";
            this.extendedGridControl1.ShowRowNumbers = false;
            this.extendedGridControl1.Size = new System.Drawing.Size(232, 501);
            this.extendedGridControl1.TabIndex = 0;
            this.extendedGridControl1.TemizleKaldirGorunsunmu = false;
            this.extendedGridControl1.UniqueId = "eb89e9a5-2882-4dd3-8c25-ed7e03aea61c";
            this.extendedGridControl1.UseHyperDragDrop = false;
            this.extendedGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKategori,
            this.colFiltreAdi});
            this.gridView1.GridControl = this.extendedGridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colKategori, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colKategori
            // 
            this.colKategori.Caption = "Kategori";
            this.colKategori.FieldName = "FILTRE_KATEGORI";
            this.colKategori.Name = "colKategori";
            this.colKategori.Visible = true;
            this.colKategori.VisibleIndex = 0;
            // 
            // colFiltreAdi
            // 
            this.colFiltreAdi.Caption = "Filtre Adý";
            this.colFiltreAdi.FieldName = "FILTRE_ADI";
            this.colFiltreAdi.Name = "colFiltreAdi";
            this.colFiltreAdi.Visible = true;
            this.colFiltreAdi.VisibleIndex = 0;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.extendedGridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cmbFiltreKategori);
            this.panelControl1.Controls.Add(this.txtFiltreAdi);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 501);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(232, 56);
            this.panelControl1.TabIndex = 1;
            // 
            // cmbFiltreKategori
            // 
            this.cmbFiltreKategori.Location = new System.Drawing.Point(111, 5);
            this.cmbFiltreKategori.Name = "cmbFiltreKategori";
            this.cmbFiltreKategori.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFiltreKategori.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmbFiltreKategori.Properties.Items.AddRange(new object[] {
            "GENEL",
            "SIK KULLANILANLAR",
            "KOLAY RAPOR"});
            this.cmbFiltreKategori.Size = new System.Drawing.Size(116, 20);
            this.cmbFiltreKategori.TabIndex = 2;
            // 
            // txtFiltreAdi
            // 
            this.txtFiltreAdi.Location = new System.Drawing.Point(5, 5);
            this.txtFiltreAdi.Name = "txtFiltreAdi";
            this.txtFiltreAdi.Size = new System.Drawing.Size(100, 20);
            this.txtFiltreAdi.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(5, 28);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(222, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Aktif Filtreyi Kaydet";
           // this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmFiltreYonetim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 557);
            this.Controls.Add(this.extendedGridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmFiltreYonetim";
            this.Text = "frmFiltreYonetim";
            ((System.ComponentModel.ISupportInitialize)(this.extendedGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbFiltreKategori.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiltreAdi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

       private ExtendedGridControl extendedGridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colKategori;
        private DevExpress.XtraGrid.Columns.GridColumn colFiltreAdi;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbFiltreKategori;
        private DevExpress.XtraEditors.TextEdit txtFiltreAdi;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}