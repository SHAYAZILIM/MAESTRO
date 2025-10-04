namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucHasarKayitvGrid
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
            DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties1 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties2 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dataNavigatorExtended1 = new AvukatPro.IcraTakipWin.UserControls.DataNavigatorExtended();
            this.vGridHasarKaydet = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rowHASAR_NO = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTEMINAT_ALT_TIP_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowHASAR_TARIHI_SAATI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowRUCU_DURUM_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowHASAR_DOSYA_DURUM_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.categoryRow1 = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.multiEditorRow1 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.rLueHasarDosyaDurum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueDOvizID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueTeminatAltTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueRucuDurum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridHasarKaydet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueHasarDosyaDurum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDOvizID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTeminatAltTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueRucuDurum)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.dataNavigatorExtended1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 646);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(835, 24);
            this.panelControl1.TabIndex = 0;
            // 
            // dataNavigatorExtended1
            // 
            this.dataNavigatorExtended1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataNavigatorExtended1.Location = new System.Drawing.Point(2, 2);
            this.dataNavigatorExtended1.MyChartControl = null;
            this.dataNavigatorExtended1.MyGridControl = null;
            this.dataNavigatorExtended1.MyPivotGridControl = null;
            this.dataNavigatorExtended1.MyVGridControl = null;
            this.dataNavigatorExtended1.Name = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.SelectButtonVisible = false;
            this.dataNavigatorExtended1.Size = new System.Drawing.Size(831, 20);
            this.dataNavigatorExtended1.TabIndex = 0;
            this.dataNavigatorExtended1.Text = "dataNavigatorExtended1";
            // 
            // vGridHasarKaydet
            // 
            this.vGridHasarKaydet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridHasarKaydet.Location = new System.Drawing.Point(0, 0);
            this.vGridHasarKaydet.Name = "vGridHasarKaydet";
            this.vGridHasarKaydet.RecordWidth = 335;
            this.vGridHasarKaydet.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueHasarDosyaDurum,
            this.rLueDOvizID,
            this.rLueTeminatAltTip,
            this.rLueRucuDurum});
            this.vGridHasarKaydet.RowHeaderWidth = 323;
            this.vGridHasarKaydet.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.categoryRow1,
            this.rowTEMINAT_ALT_TIP_ID,
            this.rowRUCU_DURUM_ID});
            this.vGridHasarKaydet.Size = new System.Drawing.Size(835, 670);
            this.vGridHasarKaydet.TabIndex = 1;
            // 
            // rowHASAR_NO
            // 
            this.rowHASAR_NO.Name = "rowHASAR_NO";
            this.rowHASAR_NO.Properties.Caption = "Hasar No";
            this.rowHASAR_NO.Properties.FieldName = "HASAR_NO";
            // 
            // rowTEMINAT_ALT_TIP_ID
            // 
            this.rowTEMINAT_ALT_TIP_ID.Name = "rowTEMINAT_ALT_TIP_ID";
            this.rowTEMINAT_ALT_TIP_ID.Properties.Caption = "Teminat Alt Tip";
            this.rowTEMINAT_ALT_TIP_ID.Properties.FieldName = "TEMINAT_ALT_TIP_ID";
            this.rowTEMINAT_ALT_TIP_ID.Properties.RowEdit = this.rLueTeminatAltTip;
            // 
            // rowHASAR_TARIHI_SAATI
            // 
            this.rowHASAR_TARIHI_SAATI.Name = "rowHASAR_TARIHI_SAATI";
            this.rowHASAR_TARIHI_SAATI.Properties.Caption = "Hasar T S";
            this.rowHASAR_TARIHI_SAATI.Properties.FieldName = "HASAR_TARIHI_SAATI";
            // 
            // rowRUCU_DURUM_ID
            // 
            this.rowRUCU_DURUM_ID.Name = "rowRUCU_DURUM_ID";
            this.rowRUCU_DURUM_ID.Properties.Caption = "Rücu Durum";
            this.rowRUCU_DURUM_ID.Properties.FieldName = "RUCU_DURUM_ID";
            this.rowRUCU_DURUM_ID.Properties.RowEdit = this.rLueRucuDurum;
            // 
            // rowHASAR_DOSYA_DURUM_ID
            // 
            this.rowHASAR_DOSYA_DURUM_ID.Name = "rowHASAR_DOSYA_DURUM_ID";
            this.rowHASAR_DOSYA_DURUM_ID.Properties.Caption = "Dosya Durum";
            this.rowHASAR_DOSYA_DURUM_ID.Properties.FieldName = "HASAR_DOSYA_DURUM_ID";
            this.rowHASAR_DOSYA_DURUM_ID.Properties.RowEdit = this.rLueHasarDosyaDurum;
            // 
            // categoryRow1
            // 
            this.categoryRow1.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowHASAR_NO,
            this.rowHASAR_TARIHI_SAATI,
            this.rowHASAR_DOSYA_DURUM_ID,
            this.multiEditorRow1});
            this.categoryRow1.Name = "categoryRow1";
            this.categoryRow1.Properties.Caption = "Hasar Bilgileri";
            // 
            // multiEditorRow1
            // 
            this.multiEditorRow1.Name = "multiEditorRow1";
            multiEditorRowProperties1.Caption = "Hasar Tutarý";
            multiEditorRowProperties1.FieldName = "HASAR_TUTARI";
            multiEditorRowProperties2.FieldName = "HASAR_TUTAR_DOVIZ_ID";
            multiEditorRowProperties2.RowEdit = this.rLueDOvizID;
            this.multiEditorRow1.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            multiEditorRowProperties1,
            multiEditorRowProperties2});
            // 
            // rLueHasarDosyaDurum
            // 
            this.rLueHasarDosyaDurum.AutoHeight = false;
            this.rLueHasarDosyaDurum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueHasarDosyaDurum.Name = "rLueHasarDosyaDurum";
            // 
            // rLueDOvizID
            // 
            this.rLueDOvizID.AutoHeight = false;
            this.rLueDOvizID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDOvizID.Name = "rLueDOvizID";
            // 
            // rLueTeminatAltTip
            // 
            this.rLueTeminatAltTip.AutoHeight = false;
            this.rLueTeminatAltTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueTeminatAltTip.Name = "rLueTeminatAltTip";
            // 
            // rLueRucuDurum
            // 
            this.rLueRucuDurum.AutoHeight = false;
            this.rLueRucuDurum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueRucuDurum.Name = "rLueRucuDurum";
            // 
            // ucHasarKayitvGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.vGridHasarKaydet);
            this.Name = "ucHasarKayitvGrid";
            this.Size = new System.Drawing.Size(835, 670);
            this.Load += new System.EventHandler(this.ucHasarKayitvGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridHasarKaydet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueHasarDosyaDurum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDOvizID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTeminatAltTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueRucuDurum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private AvukatPro.IcraTakipWin.UserControls.DataNavigatorExtended dataNavigatorExtended1;
        private DevExpress.XtraVerticalGrid.VGridControl vGridHasarKaydet;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow categoryRow1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHASAR_NO;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHASAR_TARIHI_SAATI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHASAR_DOSYA_DURUM_ID;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow multiEditorRow1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTEMINAT_ALT_TIP_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowRUCU_DURUM_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueHasarDosyaDurum;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDOvizID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTeminatAltTip;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueRucuDurum;
    }
}
