namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucMuvekkilTalimatlari
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
            this.exMuvekkilTlimat = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rDateTalimat = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.rTimeTalimat = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.rMemoAciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.rLueTalimatKonusu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueMuvekkil = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gwMuvekilTalimat = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTALIMAT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTALIMAT_SAATI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTALIMAT_ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTALIMAT_KONUSU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTALIMATI_VEREN_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTALIMAT_ILETEN_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exMuvekkilTlimat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateTalimat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateTalimat.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTimeTalimat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMemoAciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTalimatKonusu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuvekkil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwMuvekilTalimat)).BeginInit();
            this.SuspendLayout();
            // 
            // exMuvekkilTlimat
            // 
            this.exMuvekkilTlimat.CustomButtonlarGorunmesin = false;
            this.exMuvekkilTlimat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exMuvekkilTlimat.DoNotExtendEmbedNavigator = false;
            this.exMuvekkilTlimat.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.exMuvekkilTlimat.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.exMuvekkilTlimat.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.exMuvekkilTlimat.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni Kayıt", "FormAc"),
            new DevExpress.XtraEditors.NavigatorCustomButton(20, 20, true, true, "Düzenle", "KaydıDuzenle")});
            this.exMuvekkilTlimat.ExternalRepository = this.MyRepository;
            this.exMuvekkilTlimat.FilterText = null;
            this.exMuvekkilTlimat.FilterValue = null;
            this.exMuvekkilTlimat.GridlerDuzenlenebilir = true;
            this.exMuvekkilTlimat.GridsFilterControl = null;
            this.exMuvekkilTlimat.Location = new System.Drawing.Point(0, 0);
            this.exMuvekkilTlimat.MainView = this.gwMuvekilTalimat;
            this.exMuvekkilTlimat.MyGridStyle = null;
            this.exMuvekkilTlimat.Name = "exMuvekkilTlimat";
            this.exMuvekkilTlimat.ShowRowNumbers = false;
            this.exMuvekkilTlimat.SilmeKaldirilsin = false;
            this.exMuvekkilTlimat.Size = new System.Drawing.Size(749, 323);
            this.exMuvekkilTlimat.TabIndex = 0;
            this.exMuvekkilTlimat.TemizleKaldirGorunsunmu = false;
            this.exMuvekkilTlimat.UniqueId = "c834b9f4-f3f2-47ea-8e05-4ab3a0f70bfa";
            this.exMuvekkilTlimat.UseEmbeddedNavigator = true;
            this.exMuvekkilTlimat.UseHyperDragDrop = false;
            this.exMuvekkilTlimat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwMuvekilTalimat});
            this.exMuvekkilTlimat.ButtonClick += new System.EventHandler<DevExpress.XtraEditors.NavigatorButtonClickEventArgs>(this.exMuvekkilTlimat_ButtonClick);
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rDateTalimat,
            this.rTimeTalimat,
            this.rMemoAciklama,
            this.rLueTalimatKonusu,
            this.rLueMuvekkil,
            this.rLueCari});
            // 
            // rDateTalimat
            // 
            this.rDateTalimat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rDateTalimat.Name = "rDateTalimat";
            this.rDateTalimat.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // rTimeTalimat
            // 
            this.rTimeTalimat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rTimeTalimat.Name = "rTimeTalimat";
            // 
            // rMemoAciklama
            // 
            this.rMemoAciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rMemoAciklama.Name = "rMemoAciklama";
            // 
            // rLueTalimatKonusu
            // 
            this.rLueTalimatKonusu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueTalimatKonusu.Name = "rLueTalimatKonusu";
            // 
            // rLueMuvekkil
            // 
            this.rLueMuvekkil.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMuvekkil.Name = "rLueMuvekkil";
            // 
            // rLueCari
            // 
            this.rLueCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueCari.Name = "rLueCari";
            // 
            // gwMuvekilTalimat
            // 
            this.gwMuvekilTalimat.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTALIMAT_TARIHI,
            this.colTALIMAT_SAATI,
            this.colTALIMAT_ACIKLAMA,
            this.colTALIMAT_KONUSU,
            this.colTALIMATI_VEREN_CARI_ID,
            this.colTALIMAT_ILETEN_CARI_ID});
            this.gwMuvekilTalimat.GridControl = this.exMuvekkilTlimat;
            this.gwMuvekilTalimat.IndicatorWidth = 20;
            this.gwMuvekilTalimat.Name = "gwMuvekilTalimat";
            // 
            // colTALIMAT_TARIHI
            // 
            this.colTALIMAT_TARIHI.Caption = "Talimat T";
            this.colTALIMAT_TARIHI.ColumnEdit = this.rDateTalimat;
            this.colTALIMAT_TARIHI.FieldName = "TALIMAT_TARIHI";
            this.colTALIMAT_TARIHI.Name = "colTALIMAT_TARIHI";
            this.colTALIMAT_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTALIMAT_TARIHI.Visible = true;
            this.colTALIMAT_TARIHI.VisibleIndex = 0;
            // 
            // colTALIMAT_SAATI
            // 
            this.colTALIMAT_SAATI.Caption = "Talimat Saati";
            this.colTALIMAT_SAATI.ColumnEdit = this.rTimeTalimat;
            this.colTALIMAT_SAATI.FieldName = "TALIMAT_TARIHI";
            this.colTALIMAT_SAATI.Name = "colTALIMAT_SAATI";
            this.colTALIMAT_SAATI.OptionsColumn.ReadOnly = true;
            this.colTALIMAT_SAATI.Visible = true;
            this.colTALIMAT_SAATI.VisibleIndex = 1;
            // 
            // colTALIMAT_ACIKLAMA
            // 
            this.colTALIMAT_ACIKLAMA.Caption = "Açıklama";
            this.colTALIMAT_ACIKLAMA.ColumnEdit = this.rMemoAciklama;
            this.colTALIMAT_ACIKLAMA.FieldName = "TALIMAT_ACIKLAMA";
            this.colTALIMAT_ACIKLAMA.Name = "colTALIMAT_ACIKLAMA";
            this.colTALIMAT_ACIKLAMA.OptionsColumn.ReadOnly = true;
            this.colTALIMAT_ACIKLAMA.Visible = true;
            this.colTALIMAT_ACIKLAMA.VisibleIndex = 2;
            // 
            // colTALIMAT_KONUSU
            // 
            this.colTALIMAT_KONUSU.Caption = "Talimat Konusu";
            this.colTALIMAT_KONUSU.FieldName = "TALIMAT_KONUSU";
            this.colTALIMAT_KONUSU.Name = "colTALIMAT_KONUSU";
            this.colTALIMAT_KONUSU.OptionsColumn.ReadOnly = true;
            this.colTALIMAT_KONUSU.Visible = true;
            this.colTALIMAT_KONUSU.VisibleIndex = 3;
            // 
            // colTALIMATI_VEREN_CARI_ID
            // 
            this.colTALIMATI_VEREN_CARI_ID.Caption = "Talimatı Veren";
            this.colTALIMATI_VEREN_CARI_ID.ColumnEdit = this.rLueMuvekkil;
            this.colTALIMATI_VEREN_CARI_ID.FieldName = "TALIMATI_VEREN_CARI_ID";
            this.colTALIMATI_VEREN_CARI_ID.Name = "colTALIMATI_VEREN_CARI_ID";
            this.colTALIMATI_VEREN_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colTALIMATI_VEREN_CARI_ID.Visible = true;
            this.colTALIMATI_VEREN_CARI_ID.VisibleIndex = 4;
            // 
            // colTALIMAT_ILETEN_CARI_ID
            // 
            this.colTALIMAT_ILETEN_CARI_ID.Caption = "Talimatı İleten";
            this.colTALIMAT_ILETEN_CARI_ID.ColumnEdit = this.rLueCari;
            this.colTALIMAT_ILETEN_CARI_ID.FieldName = "TALIMAT_ILETEN_CARI_ID";
            this.colTALIMAT_ILETEN_CARI_ID.Name = "colTALIMAT_ILETEN_CARI_ID";
            this.colTALIMAT_ILETEN_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colTALIMAT_ILETEN_CARI_ID.Visible = true;
            this.colTALIMAT_ILETEN_CARI_ID.VisibleIndex = 5;
            // 
            // ucMuvekkilTalimatlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exMuvekkilTlimat);
            this.Name = "ucMuvekkilTalimatlari";
            this.Size = new System.Drawing.Size(749, 323);
            ((System.ComponentModel.ISupportInitialize)(this.exMuvekkilTlimat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateTalimat.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateTalimat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTimeTalimat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMemoAciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTalimatKonusu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMuvekkil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwMuvekilTalimat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl exMuvekkilTlimat;
        private DevExpress.XtraGrid.Views.Grid.GridView gwMuvekilTalimat;
        private DevExpress.XtraGrid.Columns.GridColumn colTALIMAT_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTALIMAT_SAATI;
        private DevExpress.XtraGrid.Columns.GridColumn colTALIMAT_ACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn colTALIMAT_KONUSU;
        private DevExpress.XtraGrid.Columns.GridColumn colTALIMATI_VEREN_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTALIMAT_ILETEN_CARI_ID;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rDateTalimat;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit rTimeTalimat;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit rMemoAciklama;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTalimatKonusu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMuvekkil;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueCari;
       
    }
}
