namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    partial class frmProjeSubeKodlari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProjeSubeKodlari));
            this.label1 = new System.Windows.Forms.Label();
            this.gridAdresDurumlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.relueCariMuvekkil = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxteAdresDurum = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelProjeSube = new DevExpress.XtraEditors.PanelControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAdresDurumlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relueCariMuvekkil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteAdresDurum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelProjeSube)).BeginInit();
            this.panelProjeSube.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Proje Şube Kodları";
            // 
            // gridAdresDurumlari
            // 
            this.gridAdresDurumlari.CustomButtonlarGorunmesin = false;
            this.gridAdresDurumlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAdresDurumlari.DoNotExtendEmbedNavigator = false;
            this.gridAdresDurumlari.FilterText = null;
            this.gridAdresDurumlari.FilterValue = null;
            this.gridAdresDurumlari.GridlerDuzenlenebilir = true;
            this.gridAdresDurumlari.GridsFilterControl = null;
            this.gridAdresDurumlari.Location = new System.Drawing.Point(2, 72);
            this.gridAdresDurumlari.MainView = this.gridView1;
            this.gridAdresDurumlari.MyGridStyle = null;
            this.gridAdresDurumlari.Name = "gridAdresDurumlari";
            this.gridAdresDurumlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rtxteAdresDurum,
            this.relueCariMuvekkil});
            this.gridAdresDurumlari.ShowRowNumbers = false;
            this.gridAdresDurumlari.SilmeKaldirilsin = false;
            this.gridAdresDurumlari.Size = new System.Drawing.Size(476, 270);
            this.gridAdresDurumlari.TabIndex = 5;
            this.gridAdresDurumlari.TemizleKaldirGorunsunmu = false;
            this.gridAdresDurumlari.UniqueId = "865517a0-f910-4dcf-9a92-c0495500ddf4";
            this.gridAdresDurumlari.UseEmbeddedNavigator = true;
            this.gridAdresDurumlari.UseHyperDragDrop = false;
            this.gridAdresDurumlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.gridAdresDurumlari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Başlıkları Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Adres Durum Adı Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Cari";
            this.gridColumn1.ColumnEdit = this.relueCariMuvekkil;
            this.gridColumn1.FieldName = "CARI_ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // relueCariMuvekkil
            // 
            this.relueCariMuvekkil.AutoHeight = false;
            this.relueCariMuvekkil.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.relueCariMuvekkil.Name = "relueCariMuvekkil";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Şube";
            this.gridColumn2.FieldName = "OZEL_KOD";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "ID";
            this.gridColumn3.FieldName = "ID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            // 
            // rtxteAdresDurum
            // 
            this.rtxteAdresDurum.AutoHeight = false;
            this.rtxteAdresDurum.Name = "rtxteAdresDurum";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(476, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(476, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(19, 10);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(117, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // panelProjeSube
            // 
            this.panelProjeSube.Controls.Add(this.gridAdresDurumlari);
            this.panelProjeSube.Controls.Add(this.panelControl1);
            this.panelProjeSube.Controls.Add(this.panelControl2);
            this.panelProjeSube.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProjeSube.Location = new System.Drawing.Point(0, 0);
            this.panelProjeSube.Name = "panelProjeSube";
            this.panelProjeSube.Size = new System.Drawing.Size(480, 344);
            this.panelProjeSube.TabIndex = 19;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // frmProjeSubeKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 344);
            this.Controls.Add(this.panelProjeSube);
            this.Name = "frmProjeSubeKodlari";
            this.Text = "frmProjeSubeKodlari";
            this.Load += new System.EventHandler(this.frmProjeSubeKodlari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridAdresDurumlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relueCariMuvekkil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteAdresDurum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelProjeSube)).EndInit();
            this.panelProjeSube.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Util.ExtendedGridControl gridAdresDurumlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxteAdresDurum;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl panelProjeSube;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit relueCariMuvekkil;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}