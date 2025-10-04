
namespace  AdimAdimDavaKaydi.Belge.UserControls
{
    partial class ucTaraf
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.c_gcTaraf = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueTarafKodu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSifatId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueSifat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.Cari = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.c_gcTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTarafKodu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueSifat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCari)).BeginInit();
            this.SuspendLayout();
            // 
            // c_gcTaraf
            // 
            this.c_gcTaraf.CustomButtonlarGorunmesin = false;
            this.c_gcTaraf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_gcTaraf.DoNotExtendEmbedNavigator = true;
            this.c_gcTaraf.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.c_gcTaraf.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(12, 12, true, true, "Sil", "Sil")});
            this.c_gcTaraf.FilterText = null;
            this.c_gcTaraf.FilterValue = null;
            this.c_gcTaraf.GridlerDuzenlenebilir = true;
            this.c_gcTaraf.GridsFilterControl = null;
            this.c_gcTaraf.Location = new System.Drawing.Point(0, 0);
            this.c_gcTaraf.MainView = this.gridView1;
            this.c_gcTaraf.MyGridStyle = null;
            this.c_gcTaraf.Name = "c_gcTaraf";
            this.c_gcTaraf.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueSifat,
            this.rlueCari,
            this.rlueTarafKodu});
            this.c_gcTaraf.ShowRowNumbers = false;
            this.c_gcTaraf.SilmeKaldirilsin = false;
            this.c_gcTaraf.Size = new System.Drawing.Size(353, 232);
            this.c_gcTaraf.TabIndex = 0;
            this.c_gcTaraf.TemizleKaldirGorunsunmu = false;
            this.c_gcTaraf.UniqueId = "7ae21df9-daf2-41da-9fa3-bc509a004414";
            this.c_gcTaraf.UseEmbeddedNavigator = true;
            this.c_gcTaraf.UseHyperDragDrop = false;
            this.c_gcTaraf.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.c_gcTaraf.ButtonClick += new System.EventHandler<DevExpress.XtraEditors.NavigatorButtonClickEventArgs>(this.c_gcTaraf_ButtonClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTK,
            this.colSifatId,
            this.Cari});
            this.gridView1.GridControl = this.c_gcTaraf;
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            // 
            // colTK
            // 
            this.colTK.Caption = "TK.";
            this.colTK.ColumnEdit = this.rlueTarafKodu;
            this.colTK.FieldName = "Kodu";
            this.colTK.Name = "colTK";
            this.colTK.Visible = true;
            this.colTK.VisibleIndex = 0;
            // 
            // rlueTarafKodu
            // 
            this.rlueTarafKodu.AutoHeight = false;
            this.rlueTarafKodu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueTarafKodu.Name = "rlueTarafKodu";
            // 
            // colSifatId
            // 
            this.colSifatId.Caption = "Sýfat";
            this.colSifatId.ColumnEdit = this.rlueSifat;
            this.colSifatId.FieldName = "SifatId";
            this.colSifatId.Name = "colSifatId";
            this.colSifatId.Visible = true;
            this.colSifatId.VisibleIndex = 1;
            this.colSifatId.Width = 100;
            // 
            // rlueSifat
            // 
            this.rlueSifat.AutoHeight = false;
            this.rlueSifat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueSifat.Name = "rlueSifat";
            // 
            // Cari
            // 
            this.Cari.Caption = "Þahýs";
            this.Cari.ColumnEdit = this.rlueCari;
            this.Cari.FieldName = "CariId";
            this.Cari.Name = "Cari";
            this.Cari.Visible = true;
            this.Cari.VisibleIndex = 2;
            this.Cari.Width = 212;
            // 
            // rlueCari
            // 
            this.rlueCari.AutoHeight = false;
            this.rlueCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Yeni", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "YeniKayit", null, true)});
            this.rlueCari.Name = "rlueCari";
            this.rlueCari.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rlueCari_ButtonClick);
            // 
            // ucTaraf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.c_gcTaraf);
            this.Name = "ucTaraf";
            this.Size = new System.Drawing.Size(353, 232);
            this.Load += new System.EventHandler(this.ucTaraf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_gcTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTarafKodu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueSifat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCari)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl c_gcTaraf;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSifatId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueSifat;
        private DevExpress.XtraGrid.Columns.GridColumn Cari;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCari;
        private DevExpress.XtraGrid.Columns.GridColumn colTK;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueTarafKodu;
    }
}
