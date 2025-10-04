namespace  AnaForm
{
    partial class frmRehinDurum
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
            this.panelRehinDurum = new DevExpress.XtraEditors.PanelControl();
            this.gridRehinDurum = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.REHIN_DURUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit55 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelRehinDurum)).BeginInit();
            this.panelRehinDurum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRehinDurum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRehinDurum
            // 
            this.panelRehinDurum.Controls.Add(this.gridRehinDurum);
            this.panelRehinDurum.Controls.Add(this.panelControl1);
            this.panelRehinDurum.Controls.Add(this.panelControl2);
            this.panelRehinDurum.Location = new System.Drawing.Point(12, 12);
            this.panelRehinDurum.Name = "panelRehinDurum";
            this.panelRehinDurum.Size = new System.Drawing.Size(750, 360);
            this.panelRehinDurum.TabIndex = 43;
            // 
            // gridRehinDurum
            // 
            this.gridRehinDurum.CustomButtonlarGorunmesin = false;
            this.gridRehinDurum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRehinDurum.DoNotExtendEmbedNavigator = false;
            this.gridRehinDurum.FilterText = null;
            this.gridRehinDurum.FilterValue = null;
            this.gridRehinDurum.GridlerDuzenlenebilir = true;
            this.gridRehinDurum.GridsFilterControl = null;
            this.gridRehinDurum.Location = new System.Drawing.Point(2, 72);
            this.gridRehinDurum.MainView = this.gridView1;
            this.gridRehinDurum.MyGridStyle = null;
            this.gridRehinDurum.Name = "gridRehinDurum";
            this.gridRehinDurum.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit55});
            this.gridRehinDurum.ShowRowNumbers = false;
            this.gridRehinDurum.Size = new System.Drawing.Size(746, 286);
            this.gridRehinDurum.TabIndex = 5;
            this.gridRehinDurum.TemizleKaldirGorunsunmu = false;
            this.gridRehinDurum.UniqueId = "fef160fe-b9e6-445b-aaab-e0022548cb37";
            this.gridRehinDurum.UseEmbeddedNavigator = true;
            this.gridRehinDurum.UseHyperDragDrop = false;
            this.gridRehinDurum.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.REHIN_DURUM});
            this.gridView1.GridControl = this.gridRehinDurum;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Rehin Durumu Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // REHIN_DURUM
            // 
            this.REHIN_DURUM.Caption = "Rehin Durum ";
            this.REHIN_DURUM.ColumnEdit = this.repositoryItemTextEdit55;
            this.REHIN_DURUM.FieldName = "REHIN_DURUM";
            this.REHIN_DURUM.Name = "REHIN_DURUM";
            this.REHIN_DURUM.Visible = true;
            this.REHIN_DURUM.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit55
            // 
            this.repositoryItemTextEdit55.AutoHeight = false;
            this.repositoryItemTextEdit55.Name = "repositoryItemTextEdit55";
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
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Rehin Durum";
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
            this.sBtnKaydet.Location = new System.Drawing.Point(26, 10);
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
            this.gridControlExtender1.GridControl = this.gridRehinDurum;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(524, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 44;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmRehinDurum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 470);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelRehinDurum);
            this.Name = "frmRehinDurum";
            this.Text = "Rehin Durum";
            ((System.ComponentModel.ISupportInitialize)(this.panelRehinDurum)).EndInit();
            this.panelRehinDurum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRehinDurum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelRehinDurum;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridRehinDurum;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn REHIN_DURUM;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit55;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}