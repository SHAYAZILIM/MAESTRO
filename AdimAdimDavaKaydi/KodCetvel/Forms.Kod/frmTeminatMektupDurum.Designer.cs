namespace  AnaForm
{
    partial class frmTeminatMektupDurum
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
            this.panelTeminatMektupDurumlar = new DevExpress.XtraEditors.PanelControl();
            this.gridTeminatMektupDurumlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TEMINAT_MEKTUP_DURUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit59 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTeminatMektupDurumlar)).BeginInit();
            this.panelTeminatMektupDurumlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeminatMektupDurumlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTeminatMektupDurumlar
            // 
            this.panelTeminatMektupDurumlar.Controls.Add(this.gridTeminatMektupDurumlari);
            this.panelTeminatMektupDurumlar.Controls.Add(this.panelControl1);
            this.panelTeminatMektupDurumlar.Controls.Add(this.panelControl2);
            this.panelTeminatMektupDurumlar.Location = new System.Drawing.Point(12, 12);
            this.panelTeminatMektupDurumlar.Name = "panelTeminatMektupDurumlar";
            this.panelTeminatMektupDurumlar.Size = new System.Drawing.Size(750, 360);
            this.panelTeminatMektupDurumlar.TabIndex = 46;
            // 
            // gridTeminatMektupDurumlari
            // 
            this.gridTeminatMektupDurumlari.CustomButtonlarGorunmesin = false;
            this.gridTeminatMektupDurumlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTeminatMektupDurumlari.DoNotExtendEmbedNavigator = false;
            this.gridTeminatMektupDurumlari.FilterText = null;
            this.gridTeminatMektupDurumlari.FilterValue = null;
            this.gridTeminatMektupDurumlari.GridlerDuzenlenebilir = true;
            this.gridTeminatMektupDurumlari.GridsFilterControl = null;
            this.gridTeminatMektupDurumlari.Location = new System.Drawing.Point(2, 72);
            this.gridTeminatMektupDurumlari.MainView = this.gridView1;
            this.gridTeminatMektupDurumlari.MyGridStyle = null;
            this.gridTeminatMektupDurumlari.Name = "gridTeminatMektupDurumlari";
            this.gridTeminatMektupDurumlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit59});
            this.gridTeminatMektupDurumlari.ShowRowNumbers = false;
            this.gridTeminatMektupDurumlari.Size = new System.Drawing.Size(746, 286);
            this.gridTeminatMektupDurumlari.TabIndex = 5;
            this.gridTeminatMektupDurumlari.TemizleKaldirGorunsunmu = false;
            this.gridTeminatMektupDurumlari.UniqueId = "ceb08571-1083-4192-910c-0d6bcd9b1a63";
            this.gridTeminatMektupDurumlari.UseEmbeddedNavigator = true;
            this.gridTeminatMektupDurumlari.UseHyperDragDrop = false;
            this.gridTeminatMektupDurumlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TEMINAT_MEKTUP_DURUM});
            this.gridView1.GridControl = this.gridTeminatMektupDurumlari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Teminat Mektup Tür ";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // TEMINAT_MEKTUP_DURUM
            // 
            this.TEMINAT_MEKTUP_DURUM.Caption = "Teminat Mektup Durum";
            this.TEMINAT_MEKTUP_DURUM.ColumnEdit = this.repositoryItemTextEdit59;
            this.TEMINAT_MEKTUP_DURUM.FieldName = "TEMINAT_MEKTUP_DURUM";
            this.TEMINAT_MEKTUP_DURUM.Name = "TEMINAT_MEKTUP_DURUM";
            this.TEMINAT_MEKTUP_DURUM.Visible = true;
            this.TEMINAT_MEKTUP_DURUM.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit59
            // 
            this.repositoryItemTextEdit59.AutoHeight = false;
            this.repositoryItemTextEdit59.Name = "repositoryItemTextEdit59";
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
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Teminat Mektup Durumlarý";
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
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridTeminatMektupDurumlari;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(422, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 47;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(86, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 7;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // frmTeminatMektupDurum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 456);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelTeminatMektupDurumlar);
            this.Name = "frmTeminatMektupDurum";
            this.Text = "Teminat Mektup Durumlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelTeminatMektupDurumlar)).EndInit();
            this.panelTeminatMektupDurumlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTeminatMektupDurumlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTeminatMektupDurumlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTeminatMektupDurumlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn TEMINAT_MEKTUP_DURUM;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit59;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}