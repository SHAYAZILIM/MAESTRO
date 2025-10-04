namespace  AdimAdimDavaKaydi.IcraTakipForms
{
    partial class frmFoyTaraf
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.dataNavigatorExtended1 = new AdimAdimDavaKaydi.Util.DataNavigatorExtended();
            this.gcFoyTaraf = new DevExpress.XtraGrid.GridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.deTarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.rlueBorcluCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gwFoyTaraf = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIBRA_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACIZ_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vGridControl2 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rwCARI_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rwIBRA_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rwACIZ_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rwGECICI_REHIN_ACIGI_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rwKESIN_REHIN_ACIGI_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFoyTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarih.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueBorcluCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwFoyTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 321);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(507, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(357, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(432, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.clientPanel);
            this.c_pnlContainer.Size = new System.Drawing.Size(507, 346);
            this.c_pnlContainer.Controls.SetChildIndex(this.clientPanel, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.dataNavigatorExtended1);
            this.clientPanel.Controls.Add(this.vGridControl2);
            this.clientPanel.Controls.Add(this.gcFoyTaraf);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 0);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(507, 346);
            this.clientPanel.TabIndex = 2;
            // 
            // dataNavigatorExtended1
            // 
            this.dataNavigatorExtended1.Buttons.Append.Visible = false;
            this.dataNavigatorExtended1.Buttons.First.Visible = false;
            this.dataNavigatorExtended1.Buttons.Last.Visible = false;
            this.dataNavigatorExtended1.Buttons.NextPage.Visible = false;
            this.dataNavigatorExtended1.Buttons.PrevPage.Visible = false;
            this.dataNavigatorExtended1.Buttons.Remove.Visible = false;
            this.dataNavigatorExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigatorExtended1.Location = new System.Drawing.Point(0, 327);
            this.dataNavigatorExtended1.MyChartControl = null;
            this.dataNavigatorExtended1.MyGridControl = this.gcFoyTaraf;
            this.dataNavigatorExtended1.MyPivotGridControl = null;
            this.dataNavigatorExtended1.MyVGridControl = this.vGridControl2;
            this.dataNavigatorExtended1.Name = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.SelectButtonVisible = false;
            this.dataNavigatorExtended1.Size = new System.Drawing.Size(507, 19);
            this.dataNavigatorExtended1.TabIndex = 11;
            this.dataNavigatorExtended1.Text = "dataNavigatorExtended1";
            // 
            // gcFoyTaraf
            // 
            this.gcFoyTaraf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcFoyTaraf.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcFoyTaraf.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcFoyTaraf.ExternalRepository = this.MyRepository;
            this.gcFoyTaraf.Location = new System.Drawing.Point(0, 0);
            this.gcFoyTaraf.MainView = this.gwFoyTaraf;
            this.gcFoyTaraf.Name = "gcFoyTaraf";
            this.gcFoyTaraf.Size = new System.Drawing.Size(507, 346);
            this.gcFoyTaraf.TabIndex = 6;
            this.gcFoyTaraf.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwFoyTaraf});
            this.gcFoyTaraf.Visible = false;
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.deTarih,
            this.rlueBorcluCari});
            // 
            // deTarih
            // 
            this.deTarih.AutoHeight = false;
            this.deTarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTarih.Name = "deTarih";
            this.deTarih.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // rlueBorcluCari
            // 
            this.rlueBorcluCari.AutoHeight = false;
            this.rlueBorcluCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, false)});
            this.rlueBorcluCari.Name = "rlueBorcluCari";
            // 
            // gwFoyTaraf
            // 
            this.gwFoyTaraf.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCARI_ID,
            this.colIBRA_TARIHI,
            this.colACIZ_TARIHI,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gwFoyTaraf.GridControl = this.gcFoyTaraf;
            this.gwFoyTaraf.Name = "gwFoyTaraf";
            this.gwFoyTaraf.OptionsView.ShowDetailButtons = false;
            this.gwFoyTaraf.OptionsView.ShowGroupPanel = false;
            // 
            // colCARI_ID
            // 
            this.colCARI_ID.Caption = "Borçlu";
            this.colCARI_ID.ColumnEdit = this.rlueBorcluCari;
            this.colCARI_ID.FieldName = "CARI_ID";
            this.colCARI_ID.Name = "colCARI_ID";
            this.colCARI_ID.OptionsColumn.AllowEdit = false;
            this.colCARI_ID.Visible = true;
            this.colCARI_ID.VisibleIndex = 0;
            this.colCARI_ID.Width = 106;
            // 
            // colIBRA_TARIHI
            // 
            this.colIBRA_TARIHI.Caption = "Ýbra T.";
            this.colIBRA_TARIHI.ColumnEdit = this.deTarih;
            this.colIBRA_TARIHI.FieldName = "IBRA_TARIHI";
            this.colIBRA_TARIHI.Name = "colIBRA_TARIHI";
            this.colIBRA_TARIHI.Visible = true;
            this.colIBRA_TARIHI.VisibleIndex = 1;
            // 
            // colACIZ_TARIHI
            // 
            this.colACIZ_TARIHI.Caption = "Aciz T.";
            this.colACIZ_TARIHI.ColumnEdit = this.deTarih;
            this.colACIZ_TARIHI.FieldName = "ACIZ_TARIHI";
            this.colACIZ_TARIHI.Name = "colACIZ_TARIHI";
            this.colACIZ_TARIHI.Visible = true;
            this.colACIZ_TARIHI.VisibleIndex = 2;
            this.colACIZ_TARIHI.Width = 73;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Geçici R.Açýðý T.";
            this.gridColumn1.ColumnEdit = this.deTarih;
            this.gridColumn1.FieldName = "GECICI_REHIN_ACIGI_TARIHI";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 103;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Kesin R.Açýðý T.";
            this.gridColumn2.ColumnEdit = this.deTarih;
            this.gridColumn2.FieldName = "KESIN_REHIN_ACIGI_TARIHI";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 93;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Son Ödeme T.";
            this.gridColumn3.ColumnEdit = this.deTarih;
            this.gridColumn3.FieldName = "SON_ODEME_TARIHI";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 90;
            // 
            // vGridControl2
            // 
            this.vGridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl2.ExternalRepository = this.MyRepository;
            this.vGridControl2.Location = new System.Drawing.Point(0, 0);
            this.vGridControl2.Name = "vGridControl2";
            this.vGridControl2.RecordWidth = 314;
            this.vGridControl2.RowHeaderWidth = 167;
            this.vGridControl2.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rwCARI_ID,
            this.rwIBRA_TARIHI,
            this.rwACIZ_TARIHI,
            this.rwGECICI_REHIN_ACIGI_TARIHI,
            this.rwKESIN_REHIN_ACIGI_TARIHI});
            this.vGridControl2.Size = new System.Drawing.Size(507, 346);
            this.vGridControl2.TabIndex = 13;
            // 
            // rwCARI_ID
            // 
            this.rwCARI_ID.Name = "rwCARI_ID";
            this.rwCARI_ID.Properties.Caption = "Borçlu";
            this.rwCARI_ID.Properties.FieldName = "CARI_ID";
            this.rwCARI_ID.Properties.RowEdit = this.rlueBorcluCari;
            // 
            // rwIBRA_TARIHI
            // 
            this.rwIBRA_TARIHI.Height = 18;
            this.rwIBRA_TARIHI.Name = "rwIBRA_TARIHI";
            this.rwIBRA_TARIHI.Properties.Caption = "Ýbra T";
            this.rwIBRA_TARIHI.Properties.FieldName = "IBRA_TARIHI";
            this.rwIBRA_TARIHI.Properties.RowEdit = this.deTarih;
            // 
            // rwACIZ_TARIHI
            // 
            this.rwACIZ_TARIHI.Height = 17;
            this.rwACIZ_TARIHI.Name = "rwACIZ_TARIHI";
            this.rwACIZ_TARIHI.Properties.Caption = "Aciz T";
            this.rwACIZ_TARIHI.Properties.FieldName = "ACIZ_TARIHI";
            this.rwACIZ_TARIHI.Properties.RowEdit = this.deTarih;
            // 
            // rwGECICI_REHIN_ACIGI_TARIHI
            // 
            this.rwGECICI_REHIN_ACIGI_TARIHI.Height = 18;
            this.rwGECICI_REHIN_ACIGI_TARIHI.Name = "rwGECICI_REHIN_ACIGI_TARIHI";
            this.rwGECICI_REHIN_ACIGI_TARIHI.Properties.Caption = "Geçici Rehin Açýðý T";
            this.rwGECICI_REHIN_ACIGI_TARIHI.Properties.FieldName = "GECICI_REHIN_ACIGI_TARIHI";
            this.rwGECICI_REHIN_ACIGI_TARIHI.Properties.RowEdit = this.deTarih;
            // 
            // rwKESIN_REHIN_ACIGI_TARIHI
            // 
            this.rwKESIN_REHIN_ACIGI_TARIHI.Height = 18;
            this.rwKESIN_REHIN_ACIGI_TARIHI.Name = "rwKESIN_REHIN_ACIGI_TARIHI";
            this.rwKESIN_REHIN_ACIGI_TARIHI.Properties.Caption = "Kesin Rehin Açýðý T";
            this.rwKESIN_REHIN_ACIGI_TARIHI.Properties.FieldName = "KESIN_REHIN_ACIGI_TARIHI";
            this.rwKESIN_REHIN_ACIGI_TARIHI.Properties.RowEdit = this.deTarih;
            // 
            // frmFoyTaraf
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 346);
            this.Name = "frmFoyTaraf";
            this.Text = "Taraf Geliþmeleri Kayýt Formu";
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcFoyTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarih.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueBorcluCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwFoyTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        //private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        //private DevExpress.XtraBars.BarButtonItem btnKaydet;
        //private DevExpress.XtraBars.BarButtonItem btnVazgec;
        private DevExpress.XtraGrid.GridControl gcFoyTaraf;
        private DevExpress.XtraGrid.Views.Grid.GridView gwFoyTaraf;
        private DevExpress.XtraGrid.Columns.GridColumn colCARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colIBRA_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colACIZ_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private AdimAdimDavaKaydi.Util.DataNavigatorExtended dataNavigatorExtended1;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl2;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rwCARI_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rwIBRA_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rwACIZ_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rwGECICI_REHIN_ACIGI_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rwKESIN_REHIN_ACIGI_TARIHI;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit deTarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueBorcluCari;
    }
}