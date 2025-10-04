namespace  AnaForm
{
    partial class frmDavaMaktuHarcCetveli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDavaMaktuHarcCetveli));
            this.panelDavaMaktu = new DevExpress.XtraEditors.PanelControl();
            this.gridDavaMaktuHarc = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHARC_KOD_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueHarcKod = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.HARC_KOD_ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.DOVIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueDovizTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.DEGER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.rCb_DovizTipi = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.rCb_Harc_Kod = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelDavaMaktu)).BeginInit();
            this.panelDavaMaktu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaMaktuHarc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueHarcKod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_DovizTipi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_Harc_Kod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDavaMaktu
            // 
            this.panelDavaMaktu.Controls.Add(this.gridDavaMaktuHarc);
            this.panelDavaMaktu.Controls.Add(this.panelControl1);
            this.panelDavaMaktu.Controls.Add(this.panelControl2);
            this.panelDavaMaktu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDavaMaktu.Location = new System.Drawing.Point(0, 0);
            this.panelDavaMaktu.Name = "panelDavaMaktu";
            this.panelDavaMaktu.Size = new System.Drawing.Size(746, 493);
            this.panelDavaMaktu.TabIndex = 7;
            // 
            // gridDavaMaktuHarc
            // 
            this.gridDavaMaktuHarc.CustomButtonlarGorunmesin = false;
            this.gridDavaMaktuHarc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDavaMaktuHarc.DoNotExtendEmbedNavigator = false;
            this.gridDavaMaktuHarc.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridDavaMaktuHarc.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 6, true, true, "", "1")});
            this.gridDavaMaktuHarc.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridDavaMaktuHarc_EmbeddedNavigator_ButtonClick);
            this.gridDavaMaktuHarc.FilterText = null;
            this.gridDavaMaktuHarc.FilterValue = null;
            this.gridDavaMaktuHarc.GridlerDuzenlenebilir = true;
            this.gridDavaMaktuHarc.GridsFilterControl = null;
            this.gridDavaMaktuHarc.Location = new System.Drawing.Point(2, 62);
            this.gridDavaMaktuHarc.MainView = this.gridView1;
            this.gridDavaMaktuHarc.MyGridStyle = null;
            this.gridDavaMaktuHarc.Name = "gridDavaMaktuHarc";
            this.gridDavaMaktuHarc.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoExEdit1,
            this.rCb_DovizTipi,
            this.repositoryItemTextEdit1,
            this.repositoryItemDateEdit1,
            this.rCb_Harc_Kod,
            this.rLueDovizTip,
            this.repositoryItemSpinEdit1,
            this.lueHarcKod});
            this.gridDavaMaktuHarc.ShowRowNumbers = false;
            this.gridDavaMaktuHarc.SilmeKaldirilsin = false;
            this.gridDavaMaktuHarc.Size = new System.Drawing.Size(742, 429);
            this.gridDavaMaktuHarc.TabIndex = 5;
            this.gridDavaMaktuHarc.TemizleKaldirGorunsunmu = false;
            this.gridDavaMaktuHarc.UniqueId = "74353135-edc1-4e4a-80a7-f6b253dc1b4f";
            this.gridDavaMaktuHarc.UseEmbeddedNavigator = true;
            this.gridDavaMaktuHarc.UseHyperDragDrop = false;
            this.gridDavaMaktuHarc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHARC_KOD_ID,
            this.HARC_KOD_ACIKLAMA,
            this.DOVIZ,
            this.DEGER,
            this.TARIH});
            this.gridView1.GridControl = this.gridDavaMaktuHarc;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Harç Maktu Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // colHARC_KOD_ID
            // 
            this.colHARC_KOD_ID.Caption = "Harç Kod";
            this.colHARC_KOD_ID.ColumnEdit = this.lueHarcKod;
            this.colHARC_KOD_ID.FieldName = "HARC_KOD_ID";
            this.colHARC_KOD_ID.Name = "colHARC_KOD_ID";
            this.colHARC_KOD_ID.Visible = true;
            this.colHARC_KOD_ID.VisibleIndex = 0;
            // 
            // lueHarcKod
            // 
            this.lueHarcKod.AutoHeight = false;
            this.lueHarcKod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueHarcKod.Name = "lueHarcKod";
            // 
            // HARC_KOD_ACIKLAMA
            // 
            this.HARC_KOD_ACIKLAMA.Caption = "Harc Açýklama";
            this.HARC_KOD_ACIKLAMA.ColumnEdit = this.repositoryItemTextEdit1;
            this.HARC_KOD_ACIKLAMA.FieldName = "HARC_KOD_ACIKLAMA";
            this.HARC_KOD_ACIKLAMA.Name = "HARC_KOD_ACIKLAMA";
            this.HARC_KOD_ACIKLAMA.Visible = true;
            this.HARC_KOD_ACIKLAMA.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // DOVIZ
            // 
            this.DOVIZ.Caption = "Doviz Tipi";
            this.DOVIZ.ColumnEdit = this.rLueDovizTip;
            this.DOVIZ.FieldName = "DOVIZ_ID";
            this.DOVIZ.Name = "DOVIZ";
            this.DOVIZ.Visible = true;
            this.DOVIZ.VisibleIndex = 2;
            // 
            // rLueDovizTip
            // 
            this.rLueDovizTip.AutoHeight = false;
            this.rLueDovizTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDovizTip.Name = "rLueDovizTip";
            // 
            // DEGER
            // 
            this.DEGER.Caption = "Harç Maktu Deðeri";
            this.DEGER.ColumnEdit = this.repositoryItemSpinEdit1;
            this.DEGER.FieldName = "DEGER";
            this.DEGER.Name = "DEGER";
            this.DEGER.Visible = true;
            this.DEGER.VisibleIndex = 3;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // TARIH
            // 
            this.TARIH.Caption = "Tarih";
            this.TARIH.ColumnEdit = this.repositoryItemDateEdit1;
            this.TARIH.FieldName = "TARIH";
            this.TARIH.Name = "TARIH";
            this.TARIH.Visible = true;
            this.TARIH.VisibleIndex = 4;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // rCb_DovizTipi
            // 
            this.rCb_DovizTipi.AutoHeight = false;
            this.rCb_DovizTipi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_DovizTipi.Name = "rCb_DovizTipi";
            // 
            // rCb_Harc_Kod
            // 
            this.rCb_Harc_Kod.AutoHeight = false;
            this.rCb_Harc_Kod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_Harc_Kod.Name = "rCb_Harc_Kod";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 35);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(742, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dava Maktu Harç Cetveli";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(742, 33);
            this.panelControl2.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(5, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(100, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Harç Adý";
            this.gridColumn2.FieldName = "HARC_KOD_ACIKLAMA";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Döviz";
            this.gridColumn3.FieldName = "DOVIZ";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Deðeri";
            this.gridColumn4.FieldName = "DEGER";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tarih";
            this.gridColumn5.FieldName = "TARIH";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridDavaMaktuHarc;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(340, 410);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 8;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmDavaMaktuHarcCetveli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 493);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelDavaMaktu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDavaMaktuHarcCetveli";
            this.Text = "Dava Maktu Harç Cetveli";
            ((System.ComponentModel.ISupportInitialize)(this.panelDavaMaktu)).EndInit();
            this.panelDavaMaktu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaMaktuHarc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueHarcKod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_DovizTipi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_Harc_Kod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelDavaMaktu;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDavaMaktuHarc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn HARC_KOD_ACIKLAMA;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn DOVIZ;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_DovizTipi;
        private DevExpress.XtraGrid.Columns.GridColumn DEGER;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn TARIH;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_Harc_Kod;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDovizTip;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colHARC_KOD_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueHarcKod;
    }
}