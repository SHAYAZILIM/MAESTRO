namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    partial class ucIcraTalimatlari
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gcIcraTalimatlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gvIcraTalimatlari = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTalimatIslemTur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueIslemTur = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColAdliye = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueAdliyeID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueNoID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColGorev = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueGorevID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColEsasNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColIslemTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColIslemKonu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColIslemYapan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueIslemYapanID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueSorumluID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gwBorclu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBorclu = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcIcraTalimatlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIcraTalimatlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIslemTur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAdliyeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueNoID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueGorevID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueIslemYapanID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueSorumluID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwBorclu)).BeginInit();
            this.SuspendLayout();
            // 
            // gcIcraTalimatlari
            // 
            this.gcIcraTalimatlari.CustomButtonlarGorunmesin = false;
            this.gcIcraTalimatlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcIcraTalimatlari.DoNotExtendEmbedNavigator = false;
            this.gcIcraTalimatlari.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcIcraTalimatlari.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcIcraTalimatlari.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni Kayıt", "YeniKayit"),
            new DevExpress.XtraEditors.NavigatorCustomButton(20, 20, true, true, "Kaydı Düzenleme", "KaydiDuzenle")});
            this.gcIcraTalimatlari.FilterText = null;
            this.gcIcraTalimatlari.FilterValue = null;
            this.gcIcraTalimatlari.GridlerDuzenlenebilir = true;
            this.gcIcraTalimatlari.GridsFilterControl = null;
            gridLevelNode1.LevelTemplate = this.gwBorclu;
            gridLevelNode1.RelationName = "AV001_TI_BIL_TALIMAT_BORCLUCollection";
            this.gcIcraTalimatlari.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcIcraTalimatlari.Location = new System.Drawing.Point(0, 0);
            this.gcIcraTalimatlari.MainView = this.gvIcraTalimatlari;
            this.gcIcraTalimatlari.MyGridStyle = null;
            this.gcIcraTalimatlari.Name = "gcIcraTalimatlari";
            this.gcIcraTalimatlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueAdliyeID,
            this.rlueNoID,
            this.rlueGorevID,
            this.rlueIslemYapanID,
            this.rlueSorumluID,
            this.rLueIslemTur});
            this.gcIcraTalimatlari.ShowRowNumbers = false;
            this.gcIcraTalimatlari.SilmeKaldirilsin = false;
            this.gcIcraTalimatlari.Size = new System.Drawing.Size(564, 260);
            this.gcIcraTalimatlari.TabIndex = 0;
            this.gcIcraTalimatlari.TemizleKaldirGorunsunmu = false;
            this.gcIcraTalimatlari.UniqueId = "eee49563-aef6-4a44-a94d-33ecafbc4593";
            this.gcIcraTalimatlari.UseEmbeddedNavigator = true;
            this.gcIcraTalimatlari.UseHyperDragDrop = false;
            this.gcIcraTalimatlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvIcraTalimatlari,
            this.gwBorclu});
            this.gcIcraTalimatlari.ButtonClick += new System.EventHandler<DevExpress.XtraEditors.NavigatorButtonClickEventArgs>(this.gcIcraTalimatlari_ButtonClick);
            // 
            // gvIcraTalimatlari
            // 
            this.gvIcraTalimatlari.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColID,
            this.gridColTalimatIslemTur,
            this.gridColAdliye,
            this.gridColNo,
            this.gridColGorev,
            this.gridColEsasNo,
            this.gridColIslemTarihi,
            this.gridColIslemKonu,
            this.gridColIslemYapan,
            this.gridColumn10});
            this.gvIcraTalimatlari.GridControl = this.gcIcraTalimatlari;
            this.gvIcraTalimatlari.IndicatorWidth = 20;
            this.gvIcraTalimatlari.Name = "gvIcraTalimatlari";
            // 
            // gridColID
            // 
            this.gridColID.Caption = "ID";
            this.gridColID.FieldName = "ID";
            this.gridColID.Name = "gridColID";
            // 
            // gridColTalimatIslemTur
            // 
            this.gridColTalimatIslemTur.Caption = "Talimat İşlem";
            this.gridColTalimatIslemTur.ColumnEdit = this.rLueIslemTur;
            this.gridColTalimatIslemTur.FieldName = "TALIMAT_ISLEM_TUR_ID";
            this.gridColTalimatIslemTur.Name = "gridColTalimatIslemTur";
            this.gridColTalimatIslemTur.Visible = true;
            this.gridColTalimatIslemTur.VisibleIndex = 0;
            // 
            // rLueIslemTur
            // 
            this.rLueIslemTur.AutoHeight = false;
            this.rLueIslemTur.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueIslemTur.Name = "rLueIslemTur";
            // 
            // gridColAdliye
            // 
            this.gridColAdliye.Caption = "Adliye";
            this.gridColAdliye.ColumnEdit = this.rlueAdliyeID;
            this.gridColAdliye.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.gridColAdliye.Name = "gridColAdliye";
            this.gridColAdliye.OptionsColumn.ReadOnly = true;
            this.gridColAdliye.Visible = true;
            this.gridColAdliye.VisibleIndex = 1;
            // 
            // rlueAdliyeID
            // 
            this.rlueAdliyeID.AutoHeight = false;
            this.rlueAdliyeID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueAdliyeID.Name = "rlueAdliyeID";
            // 
            // gridColNo
            // 
            this.gridColNo.Caption = "No";
            this.gridColNo.ColumnEdit = this.rlueNoID;
            this.gridColNo.FieldName = "ADLI_BIRIM_NO_ID";
            this.gridColNo.Name = "gridColNo";
            this.gridColNo.OptionsColumn.ReadOnly = true;
            this.gridColNo.Visible = true;
            this.gridColNo.VisibleIndex = 2;
            // 
            // rlueNoID
            // 
            this.rlueNoID.AutoHeight = false;
            this.rlueNoID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueNoID.Name = "rlueNoID";
            // 
            // gridColGorev
            // 
            this.gridColGorev.Caption = "Görev";
            this.gridColGorev.ColumnEdit = this.rlueGorevID;
            this.gridColGorev.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.gridColGorev.Name = "gridColGorev";
            this.gridColGorev.Visible = true;
            this.gridColGorev.VisibleIndex = 3;
            // 
            // rlueGorevID
            // 
            this.rlueGorevID.AutoHeight = false;
            this.rlueGorevID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueGorevID.Name = "rlueGorevID";
            this.rlueGorevID.ReadOnly = true;
            // 
            // gridColEsasNo
            // 
            this.gridColEsasNo.Caption = "Esas No";
            this.gridColEsasNo.FieldName = "TALIMAT_ESAS_NO";
            this.gridColEsasNo.Name = "gridColEsasNo";
            this.gridColEsasNo.OptionsColumn.ReadOnly = true;
            this.gridColEsasNo.Visible = true;
            this.gridColEsasNo.VisibleIndex = 4;
            // 
            // gridColIslemTarihi
            // 
            this.gridColIslemTarihi.Caption = "Tarih";
            this.gridColIslemTarihi.FieldName = "ISLEM_TARIHI";
            this.gridColIslemTarihi.Name = "gridColIslemTarihi";
            this.gridColIslemTarihi.OptionsColumn.ReadOnly = true;
            this.gridColIslemTarihi.Visible = true;
            this.gridColIslemTarihi.VisibleIndex = 5;
            // 
            // gridColIslemKonu
            // 
            this.gridColIslemKonu.Caption = "Konu";
            this.gridColIslemKonu.FieldName = "ISLEM_KONUSU";
            this.gridColIslemKonu.Name = "gridColIslemKonu";
            this.gridColIslemKonu.OptionsColumn.ReadOnly = true;
            this.gridColIslemKonu.Visible = true;
            this.gridColIslemKonu.VisibleIndex = 6;
            // 
            // gridColIslemYapan
            // 
            this.gridColIslemYapan.Caption = "İşlem Yapan";
            this.gridColIslemYapan.ColumnEdit = this.rlueIslemYapanID;
            this.gridColIslemYapan.FieldName = "ISLEMI_YAPAN_ID";
            this.gridColIslemYapan.Name = "gridColIslemYapan";
            this.gridColIslemYapan.Visible = true;
            this.gridColIslemYapan.VisibleIndex = 7;
            // 
            // rlueIslemYapanID
            // 
            this.rlueIslemYapanID.AutoHeight = false;
            this.rlueIslemYapanID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueIslemYapanID.Name = "rlueIslemYapanID";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Sorumlu";
            this.gridColumn10.ColumnEdit = this.rlueSorumluID;
            this.gridColumn10.FieldName = "SORUMLU_ID";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            // 
            // rlueSorumluID
            // 
            this.rlueSorumluID.AutoHeight = false;
            this.rlueSorumluID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueSorumluID.Name = "rlueSorumluID";
            // 
            // gwBorclu
            // 
            this.gwBorclu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBorclu});
            this.gwBorclu.GridControl = this.gcIcraTalimatlari;
            this.gwBorclu.Name = "gwBorclu";
            this.gwBorclu.ViewCaption = "Talimat Borçlu";
            // 
            // colBorclu
            // 
            this.colBorclu.Caption = "Borçlu";
            this.colBorclu.ColumnEdit = this.rlueIslemYapanID;
            this.colBorclu.FieldName = "BORCLU_ID";
            this.colBorclu.Name = "colBorclu";
            this.colBorclu.Visible = true;
            this.colBorclu.VisibleIndex = 0;
            // 
            // ucIcraTalimatlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcIcraTalimatlari);
            this.Name = "ucIcraTalimatlari";
            this.Size = new System.Drawing.Size(564, 260);
            ((System.ComponentModel.ISupportInitialize)(this.gcIcraTalimatlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIcraTalimatlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIslemTur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAdliyeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueNoID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueGorevID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueIslemYapanID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueSorumluID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwBorclu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gcIcraTalimatlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gvIcraTalimatlari;
        private DevExpress.XtraGrid.Columns.GridColumn gridColID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTalimatIslemTur;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAdliye;
        private DevExpress.XtraGrid.Columns.GridColumn gridColNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGorev;
        private DevExpress.XtraGrid.Columns.GridColumn gridColEsasNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColIslemTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColIslemKonu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColIslemYapan;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueAdliyeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueNoID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueGorevID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueIslemYapanID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueSorumluID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueIslemTur;
        private DevExpress.XtraGrid.Views.Grid.GridView gwBorclu;
        private DevExpress.XtraGrid.Columns.GridColumn colBorclu;
    }
}
