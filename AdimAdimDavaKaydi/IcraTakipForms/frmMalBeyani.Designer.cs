namespace  AdimAdimDavaKaydi.IcraTakipForms
{
    partial class frmMalBeyani
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
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.dataNavigatorExtended1 = new AdimAdimDavaKaydi.Util.DataNavigatorExtended();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rLueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colICRA_TARAF_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAL_BEYANI_GECERLI_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAL_BEYAN_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colITIRAZDAN_ONCE_SONRA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGECIKMIS_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSON_MAL_BEYAN_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rowICRA_TARAF_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowMAL_BEYANI_GECERLI_MI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowMAL_BEYAN_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowITIRAZDAN_ONCE_SONRA = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowGECIKMIS_MI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSON_MAL_BEYAN_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.clientPanel);
            this.c_pnlContainer.Size = new System.Drawing.Size(649, 307);
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(666, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 361);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 361);
            // 
            // c_btnYardim
            // 
 
 
 
 
 
 
 
 
 
 
 
 
 
            // 
            // c_btnCaption
            // 
 
 
 
 
 
 
 
 
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.dataNavigatorExtended1);
            this.clientPanel.Controls.Add(this.vGridControl1);
            this.clientPanel.Controls.Add(this.gridControl1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 0);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(649, 307);
            this.clientPanel.TabIndex = 2;
            // 
            // dataNavigatorExtended1
            // 
            this.dataNavigatorExtended1.Buttons.Append.Tag = "FormdanEkle";
            this.dataNavigatorExtended1.Location = new System.Drawing.Point(0, 260);
            this.dataNavigatorExtended1.MyChartControl = null;
            this.dataNavigatorExtended1.MyGridControl = this.gridControl1;
            this.dataNavigatorExtended1.MyPivotGridControl = null;
            this.dataNavigatorExtended1.MyVGridControl = this.vGridControl1;
            this.dataNavigatorExtended1.Name = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.SelectButtonVisible = true;
            this.dataNavigatorExtended1.ShowToolTips = true;
            this.dataNavigatorExtended1.Size = new System.Drawing.Size(646, 19);
            this.dataNavigatorExtended1.TabIndex = 16;
            this.dataNavigatorExtended1.Text = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.OnCevirClick += new System.EventHandler(this.dataNavigatorExtended1_OnCevirClick);
            // 
            // gridControl1
            // 
            this.gridControl1.ExternalRepository = this.MyRepository;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(649, 246);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Visible = false;
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueCari,
            this.tarih});
            // 
            // rLueCari
            // 
            this.rLueCari.AutoHeight = false;
            this.rLueCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueCari.Name = "rLueCari";
            // 
            // tarih
            // 
            this.tarih.AutoHeight = false;
            this.tarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tarih.Name = "tarih";
            this.tarih.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colICRA_TARAF_ID,
            this.colMAL_BEYANI_GECERLI_MI,
            this.colMAL_BEYAN_TARIHI,
            this.colITIRAZDAN_ONCE_SONRA,
            this.colSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI,
            this.colGECIKMIS_MI,
            this.colSON_MAL_BEYAN_TARIHI});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colICRA_TARAF_ID
            // 
            this.colICRA_TARAF_ID.Caption = "Borçlu";
            this.colICRA_TARAF_ID.FieldName = "ICRA_TARAF_ID";
            this.colICRA_TARAF_ID.Name = "colICRA_TARAF_ID";
            this.colICRA_TARAF_ID.Visible = true;
            this.colICRA_TARAF_ID.VisibleIndex = 0;
            // 
            // colMAL_BEYANI_GECERLI_MI
            // 
            this.colMAL_BEYANI_GECERLI_MI.Caption = "Geçerli Mi";
            this.colMAL_BEYANI_GECERLI_MI.FieldName = "MAL_BEYANI_GECERLI_MI";
            this.colMAL_BEYANI_GECERLI_MI.Name = "colMAL_BEYANI_GECERLI_MI";
            this.colMAL_BEYANI_GECERLI_MI.Visible = true;
            this.colMAL_BEYANI_GECERLI_MI.VisibleIndex = 1;
            // 
            // colMAL_BEYAN_TARIHI
            // 
            this.colMAL_BEYAN_TARIHI.Caption = "Mal Beyaný T.";
            this.colMAL_BEYAN_TARIHI.FieldName = "MAL_BEYAN_TARIHI";
            this.colMAL_BEYAN_TARIHI.Name = "colMAL_BEYAN_TARIHI";
            this.colMAL_BEYAN_TARIHI.Visible = true;
            this.colMAL_BEYAN_TARIHI.VisibleIndex = 2;
            // 
            // colITIRAZDAN_ONCE_SONRA
            // 
            this.colITIRAZDAN_ONCE_SONRA.Caption = "Ýtirazdan Sonra Mý ?";
            this.colITIRAZDAN_ONCE_SONRA.FieldName = "ITIRAZDAN_ONCE_SONRA";
            this.colITIRAZDAN_ONCE_SONRA.Name = "colITIRAZDAN_ONCE_SONRA";
            this.colITIRAZDAN_ONCE_SONRA.Visible = true;
            this.colITIRAZDAN_ONCE_SONRA.VisibleIndex = 3;
            // 
            // colSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI
            // 
            this.colSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI.Caption = "Ek Mal Beyan Mý ?";
            this.colSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI.FieldName = "SONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI";
            this.colSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI.Name = "colSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI";
            this.colSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI.Visible = true;
            this.colSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI.VisibleIndex = 4;
            // 
            // colGECIKMIS_MI
            // 
            this.colGECIKMIS_MI.Caption = "Gecikmiþ Mi ?";
            this.colGECIKMIS_MI.FieldName = "GECIKMIS_MI";
            this.colGECIKMIS_MI.Name = "colGECIKMIS_MI";
            this.colGECIKMIS_MI.Visible = true;
            this.colGECIKMIS_MI.VisibleIndex = 5;
            // 
            // colSON_MAL_BEYAN_TARIHI
            // 
            this.colSON_MAL_BEYAN_TARIHI.Caption = "Son Mal Beyaný T.";
            this.colSON_MAL_BEYAN_TARIHI.FieldName = "SON_MAL_BEYAN_TARIHI";
            this.colSON_MAL_BEYAN_TARIHI.Name = "colSON_MAL_BEYAN_TARIHI";
            this.colSON_MAL_BEYAN_TARIHI.Visible = true;
            this.colSON_MAL_BEYAN_TARIHI.VisibleIndex = 6;
            // 
            // vGridControl1
            // 
            this.vGridControl1.ExternalRepository = this.MyRepository;
            this.vGridControl1.Location = new System.Drawing.Point(0, 0);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.RecordWidth = 192;
            this.vGridControl1.RowHeaderWidth = 170;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowICRA_TARAF_ID,
            this.rowMAL_BEYANI_GECERLI_MI,
            this.rowMAL_BEYAN_TARIHI,
            this.rowITIRAZDAN_ONCE_SONRA,
            this.rowSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI,
            this.rowGECIKMIS_MI,
            this.rowSON_MAL_BEYAN_TARIHI});
            this.vGridControl1.Size = new System.Drawing.Size(649, 263);
            this.vGridControl1.TabIndex = 2;
            // 
            // rowICRA_TARAF_ID
            // 
            this.rowICRA_TARAF_ID.Name = "rowICRA_TARAF_ID";
            this.rowICRA_TARAF_ID.Properties.Caption = "Borçlu";
            this.rowICRA_TARAF_ID.Properties.FieldName = "ICRA_TARAF_ID";
            this.rowICRA_TARAF_ID.Properties.RowEdit = this.rLueCari;
            // 
            // rowMAL_BEYANI_GECERLI_MI
            // 
            this.rowMAL_BEYANI_GECERLI_MI.Name = "rowMAL_BEYANI_GECERLI_MI";
            this.rowMAL_BEYANI_GECERLI_MI.Properties.Caption = "Mal Beyaný Geçerli mi";
            this.rowMAL_BEYANI_GECERLI_MI.Properties.FieldName = "MAL_BEYANI_GECERLI_MI";
            // 
            // rowMAL_BEYAN_TARIHI
            // 
            this.rowMAL_BEYAN_TARIHI.Name = "rowMAL_BEYAN_TARIHI";
            this.rowMAL_BEYAN_TARIHI.Properties.Caption = "Mal Beyaný T";
            this.rowMAL_BEYAN_TARIHI.Properties.FieldName = "MAL_BEYAN_TARIHI";
            this.rowMAL_BEYAN_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // rowITIRAZDAN_ONCE_SONRA
            // 
            this.rowITIRAZDAN_ONCE_SONRA.Name = "rowITIRAZDAN_ONCE_SONRA";
            this.rowITIRAZDAN_ONCE_SONRA.Properties.Caption = "Ýtirazdan Önce mi";
            this.rowITIRAZDAN_ONCE_SONRA.Properties.FieldName = "ITIRAZDAN_ONCE_SONRA";
            // 
            // rowSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI
            // 
            this.rowSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI.Name = "rowSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI";
            this.rowSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI.Properties.Caption = "Ek Beyan mý";
            this.rowSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI.Properties.FieldName = "SONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI";
            // 
            // rowGECIKMIS_MI
            // 
            this.rowGECIKMIS_MI.Name = "rowGECIKMIS_MI";
            this.rowGECIKMIS_MI.Properties.Caption = "Gecikmiþ mi";
            this.rowGECIKMIS_MI.Properties.FieldName = "GECIKMIS_MI";
            // 
            // rowSON_MAL_BEYAN_TARIHI
            // 
            this.rowSON_MAL_BEYAN_TARIHI.Name = "rowSON_MAL_BEYAN_TARIHI";
            this.rowSON_MAL_BEYAN_TARIHI.Properties.Caption = "Son Mal Beyan T";
            this.rowSON_MAL_BEYAN_TARIHI.Properties.FieldName = "SON_MAL_BEYAN_TARIHI";
            this.rowSON_MAL_BEYAN_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // frmMalBeyani
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 361);
            this.Name = "frmMalBeyani";
            this.Text = "Mal Beyaný Giriþ Formu";
            this.UstMenu = true;
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        //private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colICRA_TARAF_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colMAL_BEYANI_GECERLI_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colMAL_BEYAN_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colITIRAZDAN_ONCE_SONRA;
        private DevExpress.XtraGrid.Columns.GridColumn colSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colGECIKMIS_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colSON_MAL_BEYAN_TARIHI;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowICRA_TARAF_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMAL_BEYANI_GECERLI_MI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMAL_BEYAN_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowITIRAZDAN_ONCE_SONRA;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowGECIKMIS_MI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSON_MAL_BEYAN_TARIHI;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit tarih;
        private AdimAdimDavaKaydi.Util.DataNavigatorExtended dataNavigatorExtended1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem2;
    }
}