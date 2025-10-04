namespace  AnaForm
{
    partial class frmSozlesmeDurum
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
            this.panelSozlesmDurumKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridSozlesmeDurumKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SOZLESME_DURUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit52 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelSozlesmDurumKodlar)).BeginInit();
            this.panelSozlesmDurumKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSozlesmeDurumKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSozlesmDurumKodlar
            // 
            this.panelSozlesmDurumKodlar.Controls.Add(this.gridSozlesmeDurumKodlar);
            this.panelSozlesmDurumKodlar.Controls.Add(this.panelControl1);
            this.panelSozlesmDurumKodlar.Controls.Add(this.panelControl2);
            this.panelSozlesmDurumKodlar.Location = new System.Drawing.Point(17, 47);
            this.panelSozlesmDurumKodlar.Name = "panelSozlesmDurumKodlar";
            this.panelSozlesmDurumKodlar.Size = new System.Drawing.Size(750, 360);
            this.panelSozlesmDurumKodlar.TabIndex = 40;
            // 
            // gridSozlesmeDurumKodlar
            // 
            this.gridSozlesmeDurumKodlar.CustomButtonlarGorunmesin = false;
            this.gridSozlesmeDurumKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSozlesmeDurumKodlar.DoNotExtendEmbedNavigator = false;
            this.gridSozlesmeDurumKodlar.FilterText = null;
            this.gridSozlesmeDurumKodlar.FilterValue = null;
            this.gridSozlesmeDurumKodlar.GridlerDuzenlenebilir = true;
            this.gridSozlesmeDurumKodlar.GridsFilterControl = null;
            this.gridSozlesmeDurumKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridSozlesmeDurumKodlar.MainView = this.gridView1;
            this.gridSozlesmeDurumKodlar.MyGridStyle = null;
            this.gridSozlesmeDurumKodlar.Name = "gridSozlesmeDurumKodlar";
            this.gridSozlesmeDurumKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit52});
            this.gridSozlesmeDurumKodlar.ShowRowNumbers = false;
            this.gridSozlesmeDurumKodlar.Size = new System.Drawing.Size(746, 286);
            this.gridSozlesmeDurumKodlar.TabIndex = 5;
            this.gridSozlesmeDurumKodlar.TemizleKaldirGorunsunmu = false;
            this.gridSozlesmeDurumKodlar.UniqueId = "93984101-9969-42a0-aa3c-08a0383f6de8";
            this.gridSozlesmeDurumKodlar.UseEmbeddedNavigator = true;
            this.gridSozlesmeDurumKodlar.UseHyperDragDrop = false;
            this.gridSozlesmeDurumKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SOZLESME_DURUM});
            this.gridView1.GridControl = this.gridSozlesmeDurumKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Sözleþme Durumlarý Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // SOZLESME_DURUM
            // 
            this.SOZLESME_DURUM.Caption = "Sözleþme Durum Kodlar";
            this.SOZLESME_DURUM.ColumnEdit = this.repositoryItemTextEdit52;
            this.SOZLESME_DURUM.FieldName = "SOZLESME_DURUM";
            this.SOZLESME_DURUM.Name = "SOZLESME_DURUM";
            this.SOZLESME_DURUM.Visible = true;
            this.SOZLESME_DURUM.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit52
            // 
            this.repositoryItemTextEdit52.AutoHeight = false;
            this.repositoryItemTextEdit52.Name = "repositoryItemTextEdit52";
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
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sözleþme Durum Kodlarý";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.sBtnKaydet);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(746, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(71, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 6;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridSozlesmeDurumKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(435, 414);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 41;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmSozlesmeDurum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 454);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelSozlesmDurumKodlar);
            this.Name = "frmSozlesmeDurum";
            this.Text = "Sözleþme Durum";
            ((System.ComponentModel.ISupportInitialize)(this.panelSozlesmDurumKodlar)).EndInit();
            this.panelSozlesmDurumKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSozlesmeDurumKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelSozlesmDurumKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridSozlesmeDurumKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn SOZLESME_DURUM;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit52;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}