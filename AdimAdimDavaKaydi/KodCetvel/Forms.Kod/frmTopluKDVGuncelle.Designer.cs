namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    partial class frmTopluKDVGuncelle
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
            this.spOran = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dtpicker = new System.Windows.Forms.DateTimePicker();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.KDV_ORAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rCb_Kategori = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridKDVCetveli = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.Kategori = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueKategori = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.KDV_AD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelKDVCetvel = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.spOran)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_Kategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridKDVCetveli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelKDVCetvel)).BeginInit();
            this.panelKDVCetvel.SuspendLayout();
            this.SuspendLayout();
            // 
            // spOran
            // 
            this.spOran.AutoHeight = false;
            this.spOran.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spOran.Name = "spOran";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.dtpicker);
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(751, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // dtpicker
            // 
            this.dtpicker.Location = new System.Drawing.Point(187, 9);
            this.dtpicker.Name = "dtpicker";
            this.dtpicker.Size = new System.Drawing.Size(200, 21);
            this.dtpicker.TabIndex = 2;
            this.dtpicker.ValueChanged += new System.EventHandler(this.dtpicker_ValueChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(18, 9);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // KDV_ORAN
            // 
            this.KDV_ORAN.Caption = "KDV ORAN";
            this.KDV_ORAN.ColumnEdit = this.spOran;
            this.KDV_ORAN.FieldName = "KDV_ORAN";
            this.KDV_ORAN.Name = "KDV_ORAN";
            this.KDV_ORAN.Visible = true;
            this.KDV_ORAN.VisibleIndex = 3;
            // 
            // rCb_Kategori
            // 
            this.rCb_Kategori.AutoHeight = false;
            this.rCb_Kategori.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_Kategori.Name = "rCb_Kategori";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(751, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "KDV Cetveli";
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // gridKDVCetveli
            // 
            this.gridKDVCetveli.CustomButtonlarGorunmesin = false;
            this.gridKDVCetveli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridKDVCetveli.DoNotExtendEmbedNavigator = false;
            this.gridKDVCetveli.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridKDVCetveli.FilterText = null;
            this.gridKDVCetveli.FilterValue = null;
            this.gridKDVCetveli.GridlerDuzenlenebilir = true;
            this.gridKDVCetveli.GridsFilterControl = null;
            this.gridKDVCetveli.Location = new System.Drawing.Point(2, 72);
            this.gridKDVCetveli.MainView = this.gridView1;
            this.gridKDVCetveli.MyGridStyle = null;
            this.gridKDVCetveli.Name = "gridKDVCetveli";
            this.gridKDVCetveli.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit3,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.rCb_Kategori,
            this.rLueKategori,
            this.spOran});
            this.gridKDVCetveli.ShowRowNumbers = false;
            this.gridKDVCetveli.SilmeKaldirilsin = false;
            this.gridKDVCetveli.Size = new System.Drawing.Size(751, 414);
            this.gridKDVCetveli.TabIndex = 5;
            this.gridKDVCetveli.TemizleKaldirGorunsunmu = false;
            this.gridKDVCetveli.UniqueId = "a3ad14d8-d6ef-401e-9090-8f0825ace0a2";
            this.gridKDVCetveli.UseEmbeddedNavigator = true;
            this.gridKDVCetveli.UseHyperDragDrop = false;
            this.gridKDVCetveli.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TARIH,
            this.Kategori,
            this.KDV_AD,
            this.KDV_ORAN});
            this.gridView1.GridControl = this.gridKDVCetveli;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Başlıkları Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni KDV Oranı Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // TARIH
            // 
            this.TARIH.Caption = "Tarih";
            this.TARIH.ColumnEdit = this.repositoryItemDateEdit3;
            this.TARIH.FieldName = "TARIH";
            this.TARIH.Name = "TARIH";
            this.TARIH.Visible = true;
            this.TARIH.VisibleIndex = 0;
            // 
            // repositoryItemDateEdit3
            // 
            this.repositoryItemDateEdit3.AutoHeight = false;
            this.repositoryItemDateEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit3.Name = "repositoryItemDateEdit3";
            this.repositoryItemDateEdit3.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // Kategori
            // 
            this.Kategori.Caption = "Kategori";
            this.Kategori.ColumnEdit = this.rLueKategori;
            this.Kategori.FieldName = "KATEGORI_ID";
            this.Kategori.Name = "Kategori";
            this.Kategori.Visible = true;
            this.Kategori.VisibleIndex = 1;
            // 
            // rLueKategori
            // 
            this.rLueKategori.AutoHeight = false;
            this.rLueKategori.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueKategori.Name = "rLueKategori";
            // 
            // KDV_AD
            // 
            this.KDV_AD.Caption = "KDV AD";
            this.KDV_AD.ColumnEdit = this.repositoryItemTextEdit3;
            this.KDV_AD.FieldName = "KDV_AD";
            this.KDV_AD.Name = "KDV_AD";
            this.KDV_AD.Visible = true;
            this.KDV_AD.VisibleIndex = 2;
            // 
            // panelKDVCetvel
            // 
            this.panelKDVCetvel.Controls.Add(this.gridKDVCetveli);
            this.panelKDVCetvel.Controls.Add(this.panelControl1);
            this.panelKDVCetvel.Controls.Add(this.panelControl2);
            this.panelKDVCetvel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKDVCetvel.Location = new System.Drawing.Point(0, 0);
            this.panelKDVCetvel.Name = "panelKDVCetvel";
            this.panelKDVCetvel.Size = new System.Drawing.Size(755, 488);
            this.panelKDVCetvel.TabIndex = 11;
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = null;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridKDVCetveli;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(498, 368);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 12;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmTopluKDVGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 488);
            this.Controls.Add(this.panelKDVCetvel);
            this.Controls.Add(this.gridControlExtender1);
            this.Name = "frmTopluKDVGuncelle";
            this.Text = "frmTopluKDVGuncelle";
            ((System.ComponentModel.ISupportInitialize)(this.spOran)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_Kategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridKDVCetveli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelKDVCetvel)).EndInit();
            this.panelKDVCetvel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spOran;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraGrid.Columns.GridColumn KDV_ORAN;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_Kategori;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridKDVCetveli;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn TARIH;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn Kategori;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueKategori;
        private DevExpress.XtraGrid.Columns.GridColumn KDV_AD;
        private DevExpress.XtraEditors.PanelControl panelKDVCetvel;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private System.Windows.Forms.DateTimePicker dtpicker;
    }
}