namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    partial class ucTakipHikayesi
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
            this.gcTakipHikayesi = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gwTakipHikayesi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColHikayeSurecId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueHikayeSurec = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcColIstekler = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcColAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcTakipHikayesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwTakipHikayesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueHikayeSurec)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTakipHikayesi
            // 
            this.gcTakipHikayesi.CustomButtonlarGorunmesin = false;
            this.gcTakipHikayesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTakipHikayesi.DoNotExtendEmbedNavigator = false;
            this.gcTakipHikayesi.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcTakipHikayesi.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcTakipHikayesi.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni Kayıt", "YeniKayit"),
            new DevExpress.XtraEditors.NavigatorCustomButton(20, 20, true, true, "Kaydı Düzenle", "KaydiDuzenle")});
            this.gcTakipHikayesi.FilterText = null;
            this.gcTakipHikayesi.FilterValue = null;
            this.gcTakipHikayesi.GridlerDuzenlenebilir = true;
            this.gcTakipHikayesi.GridsFilterControl = null;
            this.gcTakipHikayesi.Location = new System.Drawing.Point(0, 0);
            this.gcTakipHikayesi.MainView = this.gwTakipHikayesi;
            this.gcTakipHikayesi.MyGridStyle = null;
            this.gcTakipHikayesi.Name = "gcTakipHikayesi";
            this.gcTakipHikayesi.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueHikayeSurec});
            this.gcTakipHikayesi.ShowRowNumbers = false;
            this.gcTakipHikayesi.SilmeKaldirilsin = false;
            this.gcTakipHikayesi.Size = new System.Drawing.Size(701, 299);
            this.gcTakipHikayesi.TabIndex = 0;
            this.gcTakipHikayesi.TemizleKaldirGorunsunmu = false;
            this.gcTakipHikayesi.UniqueId = "393fcdd9-dacd-4b88-970d-be831172fb1b";
            this.gcTakipHikayesi.UseEmbeddedNavigator = true;
            this.gcTakipHikayesi.UseHyperDragDrop = false;
            this.gcTakipHikayesi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwTakipHikayesi});
            this.gcTakipHikayesi.ButtonClick += new System.EventHandler<DevExpress.XtraEditors.NavigatorButtonClickEventArgs>(this.gcTakipHikayesi_ButtonClick);
            // 
            // gwTakipHikayesi
            // 
            this.gwTakipHikayesi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColID,
            this.gridColHikayeSurecId,
            this.gcColIstekler,
            this.gcColAciklama});
            this.gwTakipHikayesi.GridControl = this.gcTakipHikayesi;
            this.gwTakipHikayesi.IndicatorWidth = 20;
            this.gwTakipHikayesi.Name = "gwTakipHikayesi";
            this.gwTakipHikayesi.OptionsView.AutoCalcPreviewLineCount = true;
            this.gwTakipHikayesi.OptionsView.EnableAppearanceEvenRow = true;
            this.gwTakipHikayesi.OptionsView.ShowPreview = true;
            this.gwTakipHikayesi.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.True;
            this.gwTakipHikayesi.PreviewFieldName = "ACIKLAMA";
            // 
            // gridColID
            // 
            this.gridColID.Caption = "ID";
            this.gridColID.FieldName = "ID";
            this.gridColID.Name = "gridColID";
            // 
            // gridColHikayeSurecId
            // 
            this.gridColHikayeSurecId.Caption = "Süreç";
            this.gridColHikayeSurecId.ColumnEdit = this.rlueHikayeSurec;
            this.gridColHikayeSurecId.FieldName = "HIKAYE_SUREC_ID";
            this.gridColHikayeSurecId.Name = "gridColHikayeSurecId";
            this.gridColHikayeSurecId.OptionsColumn.ReadOnly = true;
            this.gridColHikayeSurecId.Visible = true;
            this.gridColHikayeSurecId.VisibleIndex = 0;
            // 
            // rlueHikayeSurec
            // 
            this.rlueHikayeSurec.AutoHeight = false;
            this.rlueHikayeSurec.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueHikayeSurec.Name = "rlueHikayeSurec";
            // 
            // gcColIstekler
            // 
            this.gcColIstekler.Caption = "İstekler";
            this.gcColIstekler.FieldName = "ISTEKLER";
            this.gcColIstekler.Name = "gcColIstekler";
            this.gcColIstekler.OptionsColumn.ReadOnly = true;
            this.gcColIstekler.Visible = true;
            this.gcColIstekler.VisibleIndex = 1;
            // 
            // gcColAciklama
            // 
            this.gcColAciklama.Caption = "Açıklama";
            this.gcColAciklama.FieldName = "ACIKLAMA";
            this.gcColAciklama.Name = "gcColAciklama";
            this.gcColAciklama.OptionsColumn.ReadOnly = true;
            this.gcColAciklama.Visible = true;
            this.gcColAciklama.VisibleIndex = 2;
            // 
            // ucTakipHikayesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcTakipHikayesi);
            this.Name = "ucTakipHikayesi";
            this.Size = new System.Drawing.Size(701, 299);
            ((System.ComponentModel.ISupportInitialize)(this.gcTakipHikayesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwTakipHikayesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueHikayeSurec)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gcTakipHikayesi;
        private DevExpress.XtraGrid.Views.Grid.GridView gwTakipHikayesi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColHikayeSurecId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueHikayeSurec;
        private DevExpress.XtraGrid.Columns.GridColumn gcColIstekler;
        private DevExpress.XtraGrid.Columns.GridColumn gcColAciklama;
    }
}
