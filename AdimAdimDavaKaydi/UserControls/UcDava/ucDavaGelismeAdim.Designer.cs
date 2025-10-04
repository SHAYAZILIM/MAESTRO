namespace  AdimAdimDavaKaydi.UserControls.UcDava
{
    partial class ucDavaGelismeAdim
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.gridDavaGelismeAdim = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rlueGelismeAdimi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueTarafCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueKaynakTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.aciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.DavaGelismeAdim = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCELSE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKAYNAK_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGELISME_ADIM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTARAF_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rowCelse = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.editorRow1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.editorRow2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.editorRow3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.editorRow4 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.editorRow5 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.dataNavigatorExtended1 = new AvukatPro.IcraTakipWin.UserControls.DataNavigatorExtended();
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaGelismeAdim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueGelismeAdimi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTarafCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueKaynakTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DavaGelismeAdim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDavaGelismeAdim
            // 
            this.gridDavaGelismeAdim.CustomButtonlarGorunmesin = false;
            this.gridDavaGelismeAdim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDavaGelismeAdim.DoNotExtendEmbedNavigator = false;
            this.gridDavaGelismeAdim.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridDavaGelismeAdim.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni Kayýt", "FormAc"),
            new DevExpress.XtraEditors.NavigatorCustomButton(20, 20, true, true, "Düzenle", "KaydýDuzenle")});
            this.gridDavaGelismeAdim.ExternalRepository = this.MyRepository;
            this.gridDavaGelismeAdim.FilterText = null;
            this.gridDavaGelismeAdim.FilterValue = null;
            this.gridDavaGelismeAdim.GridlerDuzenlenebilir = true;
            this.gridDavaGelismeAdim.GridsFilterControl = null;
            this.gridDavaGelismeAdim.Location = new System.Drawing.Point(0, 0);
            this.gridDavaGelismeAdim.MainView = this.DavaGelismeAdim;
            this.gridDavaGelismeAdim.MyGridStyle = null;
            this.gridDavaGelismeAdim.Name = "gridDavaGelismeAdim";
            this.gridDavaGelismeAdim.ShowRowNumbers = false;
            this.gridDavaGelismeAdim.SilmeKaldirilsin = false;
            this.gridDavaGelismeAdim.Size = new System.Drawing.Size(645, 383);
            this.gridDavaGelismeAdim.TabIndex = 0;
            this.gridDavaGelismeAdim.TemizleKaldirGorunsunmu = false;
            this.gridDavaGelismeAdim.UniqueId = "78e190bb-7d0a-41ac-9b78-2e7cfe77f033";
            this.gridDavaGelismeAdim.UseEmbeddedNavigator = true;
            this.gridDavaGelismeAdim.UseHyperDragDrop = false;
            this.gridDavaGelismeAdim.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DavaGelismeAdim});
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueGelismeAdimi,
            this.rlueTarafCari,
            this.rlueKaynakTip,
            this.tarih,
            this.aciklama,
            this.repositoryItemMemoEdit1});
            // 
            // rlueGelismeAdimi
            // 
            this.rlueGelismeAdimi.AutoHeight = false;
            this.rlueGelismeAdimi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", "mEkle", null, true)
            });
            this.rlueGelismeAdimi.Name = "rlueGelismeAdimi";
            this.rlueGelismeAdimi.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.rlueGelismeAdimi_ProcessNewValue);
            this.rlueGelismeAdimi.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rlueGelismeAdimi_ButtonClick);
            // 
            // rlueTarafCari
            // 
            this.rlueTarafCari.AutoHeight = false;
            this.rlueTarafCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueTarafCari.Name = "rlueTarafCari";
            // 
            // rlueKaynakTip
            // 
            this.rlueKaynakTip.AutoHeight = false;
            this.rlueKaynakTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueKaynakTip.Name = "rlueKaynakTip";
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
            // aciklama
            // 
            this.aciklama.AutoHeight = false;
            this.aciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.aciklama.Name = "aciklama";
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            this.repositoryItemMemoEdit1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.repositoryItemMemoEdit1.ValidateOnEnterKey = true;
            // 
            // DavaGelismeAdim
            // 
            this.DavaGelismeAdim.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCELSE_ID,
            this.colKAYNAK_TIP,
            this.colGELISME_ADIM_ID,
            this.colTARAF_ID,
            this.colTARIH,
            this.colACIKLAMA});
            this.DavaGelismeAdim.GridControl = this.gridDavaGelismeAdim;
            this.DavaGelismeAdim.IndicatorWidth = 20;
            this.DavaGelismeAdim.Name = "DavaGelismeAdim";
            this.DavaGelismeAdim.OptionsBehavior.FocusLeaveOnTab = true;
            this.DavaGelismeAdim.OptionsDetail.AllowExpandEmptyDetails = true;
            this.DavaGelismeAdim.OptionsNavigation.AutoFocusNewRow = true;
            this.DavaGelismeAdim.OptionsNavigation.EnterMoveNextColumn = true;
            this.DavaGelismeAdim.OptionsView.AutoCalcPreviewLineCount = true;
            this.DavaGelismeAdim.OptionsView.ColumnAutoWidth = false;
            this.DavaGelismeAdim.OptionsView.ShowAutoFilterRow = true;
            this.DavaGelismeAdim.OptionsView.ShowChildrenInGroupPanel = true;
            this.DavaGelismeAdim.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.DavaGelismeAdim.OptionsView.ShowPreview = true;
            this.DavaGelismeAdim.PreviewFieldName = "ACIKLAMA";
            // 
            // colCELSE_ID
            // 
            this.colCELSE_ID.Caption = "Celse";
            this.colCELSE_ID.FieldName = "CELSE_ID";
            this.colCELSE_ID.Name = "colCELSE_ID";
            this.colCELSE_ID.OptionsColumn.ReadOnly = true;
            // 
            // colKAYNAK_TIP
            // 
            this.colKAYNAK_TIP.Caption = "Kaynak Tip";
            this.colKAYNAK_TIP.ColumnEdit = this.rlueKaynakTip;
            this.colKAYNAK_TIP.FieldName = "KAYNAK_TIP";
            this.colKAYNAK_TIP.Name = "colKAYNAK_TIP";
            this.colKAYNAK_TIP.OptionsColumn.ReadOnly = true;
            this.colKAYNAK_TIP.Visible = true;
            this.colKAYNAK_TIP.VisibleIndex = 0;
            // 
            // colGELISME_ADIM_ID
            // 
            this.colGELISME_ADIM_ID.Caption = "Geliþme Adým";
            this.colGELISME_ADIM_ID.ColumnEdit = this.rlueGelismeAdimi;
            this.colGELISME_ADIM_ID.FieldName = "GELISME_ADIM_ID";
            this.colGELISME_ADIM_ID.Name = "colGELISME_ADIM_ID";
            this.colGELISME_ADIM_ID.OptionsColumn.ReadOnly = true;
            this.colGELISME_ADIM_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colGELISME_ADIM_ID.Visible = true;
            this.colGELISME_ADIM_ID.VisibleIndex = 1;
            // 
            // colTARAF_ID
            // 
            this.colTARAF_ID.Caption = "Taraf";
            this.colTARAF_ID.ColumnEdit = this.rlueTarafCari;
            this.colTARAF_ID.FieldName = "TARAF_ID";
            this.colTARAF_ID.Name = "colTARAF_ID";
            this.colTARAF_ID.OptionsColumn.ReadOnly = true;
            this.colTARAF_ID.Visible = true;
            this.colTARAF_ID.VisibleIndex = 2;
            // 
            // colTARIH
            // 
            this.colTARIH.Caption = "Tarih";
            this.colTARIH.ColumnEdit = this.tarih;
            this.colTARIH.FieldName = "TARIH";
            this.colTARIH.Name = "colTARIH";
            this.colTARIH.OptionsColumn.ReadOnly = true;
            this.colTARIH.Visible = true;
            this.colTARIH.VisibleIndex = 3;
            // 
            // colACIKLAMA
            // 
            this.colACIKLAMA.Caption = "Açýklama";
            this.colACIKLAMA.ColumnEdit = this.aciklama;
            this.colACIKLAMA.FieldName = "ACIKLAMA";
            this.colACIKLAMA.Name = "colACIKLAMA";
            this.colACIKLAMA.OptionsColumn.ReadOnly = true;
            this.colACIKLAMA.Visible = true;
            this.colACIKLAMA.VisibleIndex = 4;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.vGridControl1);
            this.panelControl1.Controls.Add(this.dataNavigatorExtended1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(645, 383);
            this.panelControl1.TabIndex = 2;
            // 
            // vGridControl1
            // 
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.ExternalRepository = this.MyRepository;
            this.vGridControl1.Location = new System.Drawing.Point(2, 2);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.RecordWidth = 167;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowCelse,
            this.editorRow1,
            this.editorRow2,
            this.editorRow3,
            this.editorRow4,
            this.editorRow5});
            this.vGridControl1.Size = new System.Drawing.Size(641, 355);
            this.vGridControl1.TabIndex = 2;
            // 
            // rowCelse
            // 
            this.rowCelse.Name = "rowCelse";
            this.rowCelse.Properties.Caption = "Celse";
            this.rowCelse.Properties.FieldName = "CELSE_ID";
            this.rowCelse.Visible = false;
            // 
            // editorRow1
            // 
            this.editorRow1.Name = "editorRow1";
            this.editorRow1.Properties.Caption = "Kaynak Tip";
            this.editorRow1.Properties.FieldName = "KAYNAK_TIP";
            this.editorRow1.Properties.RowEdit = this.rlueKaynakTip;
            // 
            // editorRow2
            // 
            this.editorRow2.Name = "editorRow2";
            this.editorRow2.Properties.Caption = "Geliþme Adým";
            this.editorRow2.Properties.FieldName = "GELISME_ADIM_ID";
            this.editorRow2.Properties.RowEdit = this.rlueGelismeAdimi;
            // 
            // editorRow3
            // 
            this.editorRow3.Name = "editorRow3";
            this.editorRow3.Properties.Caption = "Taraf";
            this.editorRow3.Properties.FieldName = "TARAF_ID";
            this.editorRow3.Properties.RowEdit = this.rlueTarafCari;
            // 
            // editorRow4
            // 
            this.editorRow4.Name = "editorRow4";
            this.editorRow4.Properties.Caption = "Tarih";
            this.editorRow4.Properties.FieldName = "TARIH";
            // 
            // editorRow5
            // 
            this.editorRow5.Height = 66;
            this.editorRow5.Name = "editorRow5";
            this.editorRow5.Properties.Caption = "Açýklama";
            this.editorRow5.Properties.FieldName = "ACIKLAMA";
            this.editorRow5.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // dataNavigatorExtended1
            // 
            this.dataNavigatorExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigatorExtended1.Location = new System.Drawing.Point(2, 357);
            this.dataNavigatorExtended1.MyChartControl = null;
            this.dataNavigatorExtended1.MyGridControl = null;
            this.dataNavigatorExtended1.MyPivotGridControl = null;
            this.dataNavigatorExtended1.MyVGridControl = null;
            this.dataNavigatorExtended1.Name = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.SelectButtonVisible = false;
            this.dataNavigatorExtended1.Size = new System.Drawing.Size(641, 24);
            this.dataNavigatorExtended1.TabIndex = 1;
            this.dataNavigatorExtended1.Text = "dataNavigatorExtended1";
            // 
            // ucDavaGelismeAdim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridDavaGelismeAdim);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucDavaGelismeAdim";
            this.Size = new System.Drawing.Size(645, 383);
            this.Load += new System.EventHandler(this.ucDavaGelismeAdim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaGelismeAdim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueGelismeAdimi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTarafCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueKaynakTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DavaGelismeAdim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDavaGelismeAdim;
        private DevExpress.XtraGrid.Views.Grid.GridView DavaGelismeAdim;
        private DevExpress.XtraGrid.Columns.GridColumn colCELSE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colKAYNAK_TIP;
        private DevExpress.XtraGrid.Columns.GridColumn colGELISME_ADIM_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTARAF_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueGelismeAdimi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueTarafCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueKaynakTip;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit tarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit aciklama;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow editorRow1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow editorRow2;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow editorRow3;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow editorRow4;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow editorRow5;
        private AvukatPro.IcraTakipWin.UserControls.DataNavigatorExtended dataNavigatorExtended1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCelse;
    }
}
