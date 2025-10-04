namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucBankaSubeSec
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
            this.components = new System.ComponentModel.Container();
            this.exGridBankaSube = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBANKA_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueBanka = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colBOLGE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueBankaBolge = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colKODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSUBE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colILCE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTELEFON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADRES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exGridBankaSube)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBanka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBankaBolge)).BeginInit();
            this.SuspendLayout();
            // 
            // exGridBankaSube
            // 
            this.exGridBankaSube.CustomButtonlarGorunmesin = false;
            this.exGridBankaSube.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGridBankaSube.DoNotExtendEmbedNavigator = false;
            this.exGridBankaSube.FilterText = null;
            this.exGridBankaSube.FilterValue = null;
            this.exGridBankaSube.GridlerDuzenlenebilir = true;
            this.exGridBankaSube.GridsFilterControl = null;
            this.exGridBankaSube.Location = new System.Drawing.Point(0, 0);
            this.exGridBankaSube.MainView = this.gridView1;
            this.exGridBankaSube.MyGridStyle = null;
            this.exGridBankaSube.Name = "exGridBankaSube";
            this.exGridBankaSube.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueBanka,
            this.rLueBankaBolge});
            this.exGridBankaSube.ShowRowNumbers = false;
            this.exGridBankaSube.Size = new System.Drawing.Size(807, 511);
            this.exGridBankaSube.TabIndex = 0;
            this.exGridBankaSube.TemizleKaldirGorunsunmu = false;
            this.exGridBankaSube.UniqueId = "24d2174d-9865-4669-a133-8107f4139632";
            this.exGridBankaSube.UseEmbeddedNavigator = true;
            this.exGridBankaSube.UseHyperDragDrop = false;
            this.exGridBankaSube.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBANKA_ID,
            this.colBOLGE_ID,
            this.colKODU,
            this.colSUBE,
            this.colACIKLAMA,
            this.colIL,
            this.colILCE,
            this.colTELEFON,
            this.colFAX,
            this.colADRES,
            this.gridColumn1});
            this.gridView1.GridControl = this.exGridBankaSube;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, "")});
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PreviewFieldName = "ACIKLAMA";
            // 
            // colBANKA_ID
            // 
            this.colBANKA_ID.Caption = "Banka";
            this.colBANKA_ID.ColumnEdit = this.rLueBanka;
            this.colBANKA_ID.FieldName = "BANKA_ID";
            this.colBANKA_ID.Name = "colBANKA_ID";
            this.colBANKA_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colBANKA_ID.Visible = true;
            this.colBANKA_ID.VisibleIndex = 1;
            // 
            // rLueBanka
            // 
            this.rLueBanka.AutoHeight = false;
            this.rLueBanka.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBanka.Name = "rLueBanka";
            // 
            // colBOLGE_ID
            // 
            this.colBOLGE_ID.Caption = "Bölge";
            this.colBOLGE_ID.ColumnEdit = this.rLueBankaBolge;
            this.colBOLGE_ID.FieldName = "BOLGE_ID";
            this.colBOLGE_ID.Name = "colBOLGE_ID";
            this.colBOLGE_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colBOLGE_ID.Visible = true;
            this.colBOLGE_ID.VisibleIndex = 2;
            // 
            // rLueBankaBolge
            // 
            this.rLueBankaBolge.AutoHeight = false;
            this.rLueBankaBolge.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBankaBolge.Name = "rLueBankaBolge";
            // 
            // colKODU
            // 
            this.colKODU.Caption = "Kodu";
            this.colKODU.FieldName = "KODU";
            this.colKODU.Name = "colKODU";
            this.colKODU.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colKODU.Visible = true;
            this.colKODU.VisibleIndex = 3;
            // 
            // colSUBE
            // 
            this.colSUBE.Caption = "Þube";
            this.colSUBE.FieldName = "SUBE";
            this.colSUBE.Name = "colSUBE";
            this.colSUBE.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSUBE.Visible = true;
            this.colSUBE.VisibleIndex = 4;
            // 
            // colACIKLAMA
            // 
            this.colACIKLAMA.Caption = "Açýklama";
            this.colACIKLAMA.FieldName = "ACIKLAMA";
            this.colACIKLAMA.Name = "colACIKLAMA";
            this.colACIKLAMA.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colACIKLAMA.Visible = true;
            this.colACIKLAMA.VisibleIndex = 5;
            // 
            // colIL
            // 
            this.colIL.Caption = "Ýl";
            this.colIL.FieldName = "IL";
            this.colIL.Name = "colIL";
            this.colIL.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colIL.Visible = true;
            this.colIL.VisibleIndex = 6;
            // 
            // colILCE
            // 
            this.colILCE.Caption = "Ýlçe";
            this.colILCE.FieldName = "ILCE";
            this.colILCE.Name = "colILCE";
            this.colILCE.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colILCE.Visible = true;
            this.colILCE.VisibleIndex = 7;
            // 
            // colTELEFON
            // 
            this.colTELEFON.Caption = "Telefon";
            this.colTELEFON.FieldName = "TELEFON";
            this.colTELEFON.Name = "colTELEFON";
            this.colTELEFON.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTELEFON.Visible = true;
            this.colTELEFON.VisibleIndex = 8;
            // 
            // colFAX
            // 
            this.colFAX.Caption = "Fax";
            this.colFAX.FieldName = "FAX";
            this.colFAX.Name = "colFAX";
            this.colFAX.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colFAX.Visible = true;
            this.colFAX.VisibleIndex = 9;
            // 
            // colADRES
            // 
            this.colADRES.Caption = "Adres";
            this.colADRES.FieldName = "ADRES";
            this.colADRES.Name = "colADRES";
            this.colADRES.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colADRES.Visible = true;
            this.colADRES.VisibleIndex = 10;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Seç";
            this.gridColumn1.FieldName = "IsSelected";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // ucBankaSubeSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exGridBankaSube);
            this.Name = "ucBankaSubeSec";
            this.Size = new System.Drawing.Size(807, 511);
            this.Load += new System.EventHandler(this.ucBankaSubeSec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exGridBankaSube)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBanka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBankaBolge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl exGridBankaSube;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colBANKA_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colBOLGE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colKODU;
        private DevExpress.XtraGrid.Columns.GridColumn colSUBE;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn colIL;
        private DevExpress.XtraGrid.Columns.GridColumn colILCE;
        private DevExpress.XtraGrid.Columns.GridColumn colTELEFON;
        private DevExpress.XtraGrid.Columns.GridColumn colFAX;
        private DevExpress.XtraGrid.Columns.GridColumn colADRES;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBanka;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBankaBolge;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}
