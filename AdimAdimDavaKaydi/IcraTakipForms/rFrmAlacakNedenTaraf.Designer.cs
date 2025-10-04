namespace  AdimAdimDavaKaydi.IcraTakipForms
{
    partial class rFrmAlacakNedenTaraf
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
            this.bndAlacakNedenTaraf = new System.Windows.Forms.BindingSource(this.components);
            this.gwAlacakNedenTaraf = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTARAF_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colIHTAR_TEBLIG_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colTEMERRUT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZAMAN_ASIMI_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIHTAR_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAlacakNedenTaraf = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rowTARAF_CARI_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowIHTAR_TEBLIG_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTEMERRUT_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowZAMAN_ASIMI_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowIHTAR_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.dataNavigatorExtended1 = new AdimAdimDavaKaydi.Util.DataNavigatorExtended();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndAlacakNedenTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwAlacakNedenTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAlacakNedenTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.dataNavigatorExtended1);
            this.c_pnlContainer.Controls.Add(this.vGridControl1);
            this.c_pnlContainer.Controls.Add(this.gcAlacakNedenTaraf);
            this.c_pnlContainer.Size = new System.Drawing.Size(473, 277);
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(490, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 331);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 331);
            // 
            // c_btnYardim
            // 
 
 
 
 
 
 
 
 
 
 
 
 
 
            // 
            // c_btnCaption
            // 
 
 
 
 
 
 
 
 
            // 
            // bndAlacakNedenTaraf
            // 
            this.bndAlacakNedenTaraf.DataSource = typeof(AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN_TARAF);
            // 
            // gwAlacakNedenTaraf
            // 
            this.gwAlacakNedenTaraf.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTARAF_CARI_ID,
            this.colIHTAR_TEBLIG_TARIHI,
            this.colTEMERRUT_TARIHI,
            this.colZAMAN_ASIMI_TARIHI,
            this.colIHTAR_TARIHI});
            this.gwAlacakNedenTaraf.GridControl = this.gcAlacakNedenTaraf;
            this.gwAlacakNedenTaraf.IndicatorWidth = 20;
            this.gwAlacakNedenTaraf.Name = "gwAlacakNedenTaraf";
            this.gwAlacakNedenTaraf.OptionsBehavior.FocusLeaveOnTab = true;
            this.gwAlacakNedenTaraf.OptionsNavigation.AutoFocusNewRow = true;
            this.gwAlacakNedenTaraf.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwAlacakNedenTaraf.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gwAlacakNedenTaraf.OptionsView.ColumnAutoWidth = false;
            this.gwAlacakNedenTaraf.OptionsView.ShowDetailButtons = false;
            this.gwAlacakNedenTaraf.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gwAlacakNedenTaraf.OptionsView.ShowGroupPanel = false;
            this.gwAlacakNedenTaraf.PaintStyleName = "Skin";
            // 
            // colTARAF_CARI_ID
            // 
            this.colTARAF_CARI_ID.Caption = "Borçlu Adý";
            this.colTARAF_CARI_ID.ColumnEdit = this.rLueCari;
            this.colTARAF_CARI_ID.FieldName = "TARAF_CARI_ID";
            this.colTARAF_CARI_ID.Name = "colTARAF_CARI_ID";
            this.colTARAF_CARI_ID.Visible = true;
            this.colTARAF_CARI_ID.VisibleIndex = 0;
            this.colTARAF_CARI_ID.Width = 118;
            // 
            // rLueCari
            // 
            this.rLueCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueCari.Name = "rLueCari";
            this.rLueCari.NullText = "";
            this.rLueCari.ReadOnly = true;
            // 
            // colIHTAR_TEBLIG_TARIHI
            // 
            this.colIHTAR_TEBLIG_TARIHI.Caption = "Teblið T.";
            this.colIHTAR_TEBLIG_TARIHI.ColumnEdit = this.tarih;
            this.colIHTAR_TEBLIG_TARIHI.FieldName = "IHTAR_TEBLIG_TARIHI";
            this.colIHTAR_TEBLIG_TARIHI.Name = "colIHTAR_TEBLIG_TARIHI";
            this.colIHTAR_TEBLIG_TARIHI.Visible = true;
            this.colIHTAR_TEBLIG_TARIHI.VisibleIndex = 1;
            this.colIHTAR_TEBLIG_TARIHI.Width = 76;
            // 
            // tarih
            // 
            this.tarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tarih.Name = "tarih";
            this.tarih.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // colTEMERRUT_TARIHI
            // 
            this.colTEMERRUT_TARIHI.Caption = "Temerrut T.";
            this.colTEMERRUT_TARIHI.ColumnEdit = this.tarih;
            this.colTEMERRUT_TARIHI.FieldName = "TEMERRUT_TARIHI";
            this.colTEMERRUT_TARIHI.Name = "colTEMERRUT_TARIHI";
            this.colTEMERRUT_TARIHI.Visible = true;
            this.colTEMERRUT_TARIHI.VisibleIndex = 2;
            this.colTEMERRUT_TARIHI.Width = 78;
            // 
            // colZAMAN_ASIMI_TARIHI
            // 
            this.colZAMAN_ASIMI_TARIHI.Caption = "Zaman Aþýmý T.";
            this.colZAMAN_ASIMI_TARIHI.ColumnEdit = this.tarih;
            this.colZAMAN_ASIMI_TARIHI.FieldName = "ZAMAN_ASIMI_TARIHI";
            this.colZAMAN_ASIMI_TARIHI.Name = "colZAMAN_ASIMI_TARIHI";
            this.colZAMAN_ASIMI_TARIHI.Visible = true;
            this.colZAMAN_ASIMI_TARIHI.VisibleIndex = 3;
            this.colZAMAN_ASIMI_TARIHI.Width = 112;
            // 
            // colIHTAR_TARIHI
            // 
            this.colIHTAR_TARIHI.Caption = "Ýhtar T.";
            this.colIHTAR_TARIHI.ColumnEdit = this.tarih;
            this.colIHTAR_TARIHI.FieldName = "IHTAR_TARIHI";
            this.colIHTAR_TARIHI.Name = "colIHTAR_TARIHI";
            this.colIHTAR_TARIHI.Visible = true;
            this.colIHTAR_TARIHI.VisibleIndex = 4;
            this.colIHTAR_TARIHI.Width = 67;
            // 
            // gcAlacakNedenTaraf
            // 
            this.gcAlacakNedenTaraf.CustomButtonlarGorunmesin = false;
            this.gcAlacakNedenTaraf.DataSource = this.bndAlacakNedenTaraf;
            this.gcAlacakNedenTaraf.DoNotExtendEmbedNavigator = false;
            this.gcAlacakNedenTaraf.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcAlacakNedenTaraf.ExternalRepository = this.MyRepository;
            this.gcAlacakNedenTaraf.FilterText = null;
            this.gcAlacakNedenTaraf.FilterValue = null;
            this.gcAlacakNedenTaraf.GridsFilterControl = null;
            this.gcAlacakNedenTaraf.Location = new System.Drawing.Point(0, 0);
            this.gcAlacakNedenTaraf.MainView = this.gwAlacakNedenTaraf;
            this.gcAlacakNedenTaraf.MyGridStyle = null;
            this.gcAlacakNedenTaraf.Name = "gcAlacakNedenTaraf";
            this.gcAlacakNedenTaraf.ShowRowNumbers = false;
            this.gcAlacakNedenTaraf.Size = new System.Drawing.Size(473, 232);
            this.gcAlacakNedenTaraf.TabIndex = 11;
            this.gcAlacakNedenTaraf.TemizleKaldirGorunsunmu = false;
            this.gcAlacakNedenTaraf.UniqueId = "2f5df989-f337-4ac7-b434-58e452d3e8ac";
            this.gcAlacakNedenTaraf.UseHyperDragDrop = false;
            this.gcAlacakNedenTaraf.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwAlacakNedenTaraf});
            this.gcAlacakNedenTaraf.Visible = false;
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.tarih,
            this.rLueCari});
            // 
            // vGridControl1
            // 
            this.vGridControl1.ExternalRepository = this.MyRepository;
            this.vGridControl1.Location = new System.Drawing.Point(0, 1);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.RecordWidth = 166;
            this.vGridControl1.RowHeaderWidth = 121;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowTARAF_CARI_ID,
            this.rowIHTAR_TEBLIG_TARIHI,
            this.rowTEMERRUT_TARIHI,
            this.rowZAMAN_ASIMI_TARIHI,
            this.rowIHTAR_TARIHI});
            this.vGridControl1.Size = new System.Drawing.Size(473, 231);
            this.vGridControl1.TabIndex = 14;
            // 
            // rowTARAF_CARI_ID
            // 
            this.rowTARAF_CARI_ID.Name = "rowTARAF_CARI_ID";
            this.rowTARAF_CARI_ID.Properties.Caption = "Borçlu Adý";
            this.rowTARAF_CARI_ID.Properties.FieldName = "TARAF_CARI_ID";
            this.rowTARAF_CARI_ID.Properties.RowEdit = this.rLueCari;
            // 
            // rowIHTAR_TEBLIG_TARIHI
            // 
            this.rowIHTAR_TEBLIG_TARIHI.Height = 10;
            this.rowIHTAR_TEBLIG_TARIHI.Name = "rowIHTAR_TEBLIG_TARIHI";
            this.rowIHTAR_TEBLIG_TARIHI.Properties.Caption = "Ýhtar Teblið T";
            this.rowIHTAR_TEBLIG_TARIHI.Properties.FieldName = "IHTAR_TEBLIG_TARIHI";
            this.rowIHTAR_TEBLIG_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // rowTEMERRUT_TARIHI
            // 
            this.rowTEMERRUT_TARIHI.Name = "rowTEMERRUT_TARIHI";
            this.rowTEMERRUT_TARIHI.Properties.Caption = "Temerrüt T";
            this.rowTEMERRUT_TARIHI.Properties.FieldName = "TEMERRUT_TARIHI";
            this.rowTEMERRUT_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // rowZAMAN_ASIMI_TARIHI
            // 
            this.rowZAMAN_ASIMI_TARIHI.Name = "rowZAMAN_ASIMI_TARIHI";
            this.rowZAMAN_ASIMI_TARIHI.Properties.Caption = "Zaman Aþýmý T";
            this.rowZAMAN_ASIMI_TARIHI.Properties.FieldName = "ZAMAN_ASIMI_TARIHI";
            this.rowZAMAN_ASIMI_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // rowIHTAR_TARIHI
            // 
            this.rowIHTAR_TARIHI.Name = "rowIHTAR_TARIHI";
            this.rowIHTAR_TARIHI.Properties.Caption = "Ýhtar T";
            this.rowIHTAR_TARIHI.Properties.FieldName = "IHTAR_TARIHI";
            this.rowIHTAR_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // dataNavigatorExtended1
            // 
            this.dataNavigatorExtended1.Location = new System.Drawing.Point(0, 230);
            this.dataNavigatorExtended1.MyChartControl = null;
            this.dataNavigatorExtended1.MyGridControl = this.gcAlacakNedenTaraf;
            this.dataNavigatorExtended1.MyPivotGridControl = null;
            this.dataNavigatorExtended1.MyVGridControl = this.vGridControl1;
            this.dataNavigatorExtended1.Name = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.SelectButtonVisible = false;
            this.dataNavigatorExtended1.Size = new System.Drawing.Size(473, 19);
            this.dataNavigatorExtended1.TabIndex = 15;
            this.dataNavigatorExtended1.Text = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.OnCevirClick += new System.EventHandler(this.dataNavigatorExtended1_OnCevirClick);
            // 
            // rFrmAlacakNedenTaraf
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 331);
            this.Name = "rFrmAlacakNedenTaraf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alacak Neden Taraf Geliþmeleri";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.rFrmAlacakNedenTaraf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndAlacakNedenTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwAlacakNedenTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAlacakNedenTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        //private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        //private DevExpress.XtraBars.BarButtonItem btnKaydetCik;
        private System.Windows.Forms.BindingSource bndAlacakNedenTaraf;
        private DevExpress.XtraGrid.Views.Grid.GridView gwAlacakNedenTaraf;
        private DevExpress.XtraGrid.Columns.GridColumn colTARAF_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colIHTAR_TEBLIG_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMERRUT_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colZAMAN_ASIMI_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colIHTAR_TARIHI;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gcAlacakNedenTaraf;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTARAF_CARI_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowIHTAR_TEBLIG_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTEMERRUT_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowZAMAN_ASIMI_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowIHTAR_TARIHI;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit tarih;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private AdimAdimDavaKaydi.Util.DataNavigatorExtended dataNavigatorExtended1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}