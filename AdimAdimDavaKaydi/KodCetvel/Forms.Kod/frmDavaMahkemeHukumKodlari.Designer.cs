namespace  AnaForm
{
    partial class frmDavaMahkemeHukumKodlari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDavaMahkemeHukumKodlari));
            this.panelDavaMahkemeHukumleri = new DevExpress.XtraEditors.PanelControl();
            this.gridDavaMahkemeHukumleri = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ADLI_BIRIM_BOLUM_KOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAdliBirimBolum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.MAHKEME_TIPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueMahkemeTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.HUKUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rCb_MahkemeTip = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.rCb_AdlibirimBolumKod = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelDavaMahkemeHukumleri)).BeginInit();
            this.panelDavaMahkemeHukumleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaMahkemeHukumleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimBolum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMahkemeTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_MahkemeTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_AdlibirimBolumKod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDavaMahkemeHukumleri
            // 
            this.panelDavaMahkemeHukumleri.Controls.Add(this.gridDavaMahkemeHukumleri);
            this.panelDavaMahkemeHukumleri.Controls.Add(this.panelControl1);
            this.panelDavaMahkemeHukumleri.Controls.Add(this.panelControl2);
            this.panelDavaMahkemeHukumleri.Location = new System.Drawing.Point(12, 12);
            this.panelDavaMahkemeHukumleri.Name = "panelDavaMahkemeHukumleri";
            this.panelDavaMahkemeHukumleri.Size = new System.Drawing.Size(750, 360);
            this.panelDavaMahkemeHukumleri.TabIndex = 13;
            // 
            // gridDavaMahkemeHukumleri
            // 
            this.gridDavaMahkemeHukumleri.CustomButtonlarGorunmesin = false;
            this.gridDavaMahkemeHukumleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDavaMahkemeHukumleri.DoNotExtendEmbedNavigator = false;
            this.gridDavaMahkemeHukumleri.FilterText = null;
            this.gridDavaMahkemeHukumleri.FilterValue = null;
            this.gridDavaMahkemeHukumleri.GridlerDuzenlenebilir = true;
            this.gridDavaMahkemeHukumleri.GridsFilterControl = null;
            this.gridDavaMahkemeHukumleri.Location = new System.Drawing.Point(2, 72);
            this.gridDavaMahkemeHukumleri.MainView = this.gridView1;
            this.gridDavaMahkemeHukumleri.MyGridStyle = null;
            this.gridDavaMahkemeHukumleri.Name = "gridDavaMahkemeHukumleri";
            this.gridDavaMahkemeHukumleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.rCb_MahkemeTip,
            this.rCb_AdlibirimBolumKod,
            this.rLueAdliBirimBolum,
            this.rLueMahkemeTip});
            this.gridDavaMahkemeHukumleri.ShowRowNumbers = false;
            this.gridDavaMahkemeHukumleri.Size = new System.Drawing.Size(746, 286);
            this.gridDavaMahkemeHukumleri.TabIndex = 5;
            this.gridDavaMahkemeHukumleri.TemizleKaldirGorunsunmu = false;
            this.gridDavaMahkemeHukumleri.UniqueId = "7a6e39c3-c12a-432f-9596-67ee6dcb8695";
            this.gridDavaMahkemeHukumleri.UseEmbeddedNavigator = true;
            this.gridDavaMahkemeHukumleri.UseHyperDragDrop = false;
            this.gridDavaMahkemeHukumleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ADLI_BIRIM_BOLUM_KOD,
            this.MAHKEME_TIPI,
            this.HUKUM});
            this.gridView1.GridControl = this.gridDavaMahkemeHukumleri;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Mahkeme Hükümü Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // ADLI_BIRIM_BOLUM_KOD
            // 
            this.ADLI_BIRIM_BOLUM_KOD.Caption = "Adli Birim Bölüm Kod";
            this.ADLI_BIRIM_BOLUM_KOD.ColumnEdit = this.rLueAdliBirimBolum;
            this.ADLI_BIRIM_BOLUM_KOD.FieldName = "ADLI_BIRIM_BOLUM_ID";
            this.ADLI_BIRIM_BOLUM_KOD.Name = "ADLI_BIRIM_BOLUM_KOD";
            this.ADLI_BIRIM_BOLUM_KOD.Visible = true;
            this.ADLI_BIRIM_BOLUM_KOD.VisibleIndex = 0;
            // 
            // rLueAdliBirimBolum
            // 
            this.rLueAdliBirimBolum.AutoHeight = false;
            this.rLueAdliBirimBolum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliBirimBolum.Name = "rLueAdliBirimBolum";
            // 
            // MAHKEME_TIPI
            // 
            this.MAHKEME_TIPI.Caption = "Mahkeme Tipi";
            this.MAHKEME_TIPI.ColumnEdit = this.rLueMahkemeTip;
            this.MAHKEME_TIPI.FieldName = "MAHKEME_TIP_ID";
            this.MAHKEME_TIPI.Name = "MAHKEME_TIPI";
            this.MAHKEME_TIPI.Visible = true;
            this.MAHKEME_TIPI.VisibleIndex = 1;
            // 
            // rLueMahkemeTip
            // 
            this.rLueMahkemeTip.AutoHeight = false;
            this.rLueMahkemeTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMahkemeTip.Name = "rLueMahkemeTip";
            // 
            // HUKUM
            // 
            this.HUKUM.Caption = "Hüküm";
            this.HUKUM.ColumnEdit = this.repositoryItemTextEdit3;
            this.HUKUM.FieldName = "HUKUM";
            this.HUKUM.Name = "HUKUM";
            this.HUKUM.Visible = true;
            this.HUKUM.VisibleIndex = 2;
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // rCb_MahkemeTip
            // 
            this.rCb_MahkemeTip.AutoHeight = false;
            this.rCb_MahkemeTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_MahkemeTip.Name = "rCb_MahkemeTip";
            // 
            // rCb_AdlibirimBolumKod
            // 
            this.rCb_AdlibirimBolumKod.AutoHeight = false;
            this.rCb_AdlibirimBolumKod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_AdlibirimBolumKod.Name = "rCb_AdlibirimBolumKod";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(746, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dava Mahkeme Hüküm Kodlarý";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(746, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridDavaMahkemeHukumleri;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(409, 373);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 14;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(44, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmDavaMahkemeHukumKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 408);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelDavaMahkemeHukumleri);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDavaMahkemeHukumKodlari";
            this.Text = "Mahkeme Hüküm Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelDavaMahkemeHukumleri)).EndInit();
            this.panelDavaMahkemeHukumleri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaMahkemeHukumleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimBolum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMahkemeTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_MahkemeTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_AdlibirimBolumKod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelDavaMahkemeHukumleri;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDavaMahkemeHukumleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn ADLI_BIRIM_BOLUM_KOD;
        private DevExpress.XtraGrid.Columns.GridColumn MAHKEME_TIPI;
        private DevExpress.XtraGrid.Columns.GridColumn HUKUM;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_AdlibirimBolumKod;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_MahkemeTip;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliBirimBolum;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMahkemeTip;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}