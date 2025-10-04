namespace  AdimAdimDavaKaydi.Sozlesme.Forms.Sozlesme.Util
{
    partial class ucSozlesmeGelismeAdimlari
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
            this.grdGelismeAdimlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.aV001TDIBILSOZLESMEGELISMEADIMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gwGelismeAdimlari = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGELISME_ADIM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueGelismeAdim = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTARAF_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueTarafCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rDtTarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rMeAciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGelismeAdimlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TDIBILSOZLESMEGELISMEADIMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwGelismeAdimlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGelismeAdim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDtTarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDtTarih.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMeAciklama)).BeginInit();
            this.SuspendLayout();
            // 
            // grdGelismeAdimlari
            // 
            this.grdGelismeAdimlari.CustomButtonlarGorunmesin = false;
            this.grdGelismeAdimlari.DataSource = this.aV001TDIBILSOZLESMEGELISMEADIMBindingSource;
            this.grdGelismeAdimlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdGelismeAdimlari.DoNotExtendEmbedNavigator = false;
            this.grdGelismeAdimlari.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grdGelismeAdimlari.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni Kayýt", "FormdanEkle"),
            new DevExpress.XtraEditors.NavigatorCustomButton(20, 20, true, true, "Kaydý Düzenle", "KayitDuzenle")});
            this.grdGelismeAdimlari.FilterText = null;
            this.grdGelismeAdimlari.FilterValue = null;
            this.grdGelismeAdimlari.GridlerDuzenlenebilir = true;
            this.grdGelismeAdimlari.GridsFilterControl = null;
            this.grdGelismeAdimlari.Location = new System.Drawing.Point(0, 0);
            this.grdGelismeAdimlari.MainView = this.gwGelismeAdimlari;
            this.grdGelismeAdimlari.MyGridStyle = null;
            this.grdGelismeAdimlari.Name = "grdGelismeAdimlari";
            this.grdGelismeAdimlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueTarafCari,
            this.rLueGelismeAdim,
            this.rDtTarih,
            this.rMeAciklama});
            this.grdGelismeAdimlari.ShowRowNumbers = false;
            this.grdGelismeAdimlari.SilmeKaldirilsin = false;
            this.grdGelismeAdimlari.Size = new System.Drawing.Size(628, 314);
            this.grdGelismeAdimlari.TabIndex = 0;
            this.grdGelismeAdimlari.TemizleKaldirGorunsunmu = false;
            this.grdGelismeAdimlari.UniqueId = "743b63a3-f0df-4cf0-8926-5770af0c1b1b";
            this.grdGelismeAdimlari.UseEmbeddedNavigator = true;
            this.grdGelismeAdimlari.UseHyperDragDrop = false;
            this.grdGelismeAdimlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwGelismeAdimlari});
            // 
            // aV001TDIBILSOZLESMEGELISMEADIMBindingSource
            // 
            this.aV001TDIBILSOZLESMEGELISMEADIMBindingSource.DataSource = typeof(AvukatProLib2.Entities.AV001_TDI_BIL_SOZLESME_GELISME_ADIM);
            // 
            // gwGelismeAdimlari
            // 
            this.gwGelismeAdimlari.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGELISME_ADIM_ID,
            this.colTARAF_ID,
            this.colTARIH,
            this.colACIKLAMA});
            this.gwGelismeAdimlari.GridControl = this.grdGelismeAdimlari;
            this.gwGelismeAdimlari.IndicatorWidth = 20;
            this.gwGelismeAdimlari.Name = "gwGelismeAdimlari";
            this.gwGelismeAdimlari.OptionsView.ShowPreview = true;
            this.gwGelismeAdimlari.PreviewFieldName = "ACIKLAMA";
            // 
            // colGELISME_ADIM_ID
            // 
            this.colGELISME_ADIM_ID.Caption = "Geliþme Adým";
            this.colGELISME_ADIM_ID.ColumnEdit = this.rLueGelismeAdim;
            this.colGELISME_ADIM_ID.FieldName = "GELISME_ADIM_ID";
            this.colGELISME_ADIM_ID.Name = "colGELISME_ADIM_ID";
            this.colGELISME_ADIM_ID.Visible = true;
            this.colGELISME_ADIM_ID.VisibleIndex = 0;
            // 
            // rLueGelismeAdim
            // 
            this.rLueGelismeAdim.AutoHeight = false;
            this.rLueGelismeAdim.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueGelismeAdim.Name = "rLueGelismeAdim";
            // 
            // colTARAF_ID
            // 
            this.colTARAF_ID.Caption = "Taraf";
            this.colTARAF_ID.ColumnEdit = this.rLueTarafCari;
            this.colTARAF_ID.FieldName = "TARAF_ID";
            this.colTARAF_ID.Name = "colTARAF_ID";
            this.colTARAF_ID.Visible = true;
            this.colTARAF_ID.VisibleIndex = 1;
            // 
            // rLueTarafCari
            // 
            this.rLueTarafCari.AutoHeight = false;
            this.rLueTarafCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueTarafCari.Name = "rLueTarafCari";
            // 
            // colTARIH
            // 
            this.colTARIH.Caption = "Tarih";
            this.colTARIH.ColumnEdit = this.rDtTarih;
            this.colTARIH.FieldName = "TARIH";
            this.colTARIH.Name = "colTARIH";
            this.colTARIH.Visible = true;
            this.colTARIH.VisibleIndex = 2;
            // 
            // rDtTarih
            // 
            this.rDtTarih.AutoHeight = false;
            this.rDtTarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rDtTarih.Name = "rDtTarih";
            this.rDtTarih.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // colACIKLAMA
            // 
            this.colACIKLAMA.Caption = "Açýklama";
            this.colACIKLAMA.ColumnEdit = this.rMeAciklama;
            this.colACIKLAMA.FieldName = "ACIKLAMA";
            this.colACIKLAMA.Name = "colACIKLAMA";
            this.colACIKLAMA.Visible = true;
            this.colACIKLAMA.VisibleIndex = 3;
            // 
            // rMeAciklama
            // 
            this.rMeAciklama.AutoHeight = false;
            this.rMeAciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rMeAciklama.Name = "rMeAciklama";
            // 
            // ucSozlesmeGelismeAdimlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdGelismeAdimlari);
            this.Name = "ucSozlesmeGelismeAdimlari";
            this.Size = new System.Drawing.Size(628, 314);
            ((System.ComponentModel.ISupportInitialize)(this.grdGelismeAdimlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TDIBILSOZLESMEGELISMEADIMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwGelismeAdimlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGelismeAdim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDtTarih.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDtTarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMeAciklama)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl grdGelismeAdimlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gwGelismeAdimlari;
        private System.Windows.Forms.BindingSource aV001TDIBILSOZLESMEGELISMEADIMBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colGELISME_ADIM_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTARAF_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTarafCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueGelismeAdim;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rDtTarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit rMeAciklama;
    }
}
