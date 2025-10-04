namespace  AnaForm
{
    partial class frmSozlesmeAltTip
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
            this.panelSozlesmeAlttipleri = new DevExpress.XtraEditors.PanelControl();
            this.gridSozlesmeAltTipleri = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ANA_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rCb_AnaTip = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ALT_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit15 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelSozlesmeAlttipleri)).BeginInit();
            this.panelSozlesmeAlttipleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSozlesmeAltTipleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_AnaTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSozlesmeAlttipleri
            // 
            this.panelSozlesmeAlttipleri.Controls.Add(this.gridSozlesmeAltTipleri);
            this.panelSozlesmeAlttipleri.Controls.Add(this.panelControl1);
            this.panelSozlesmeAlttipleri.Controls.Add(this.panelControl2);
            this.panelSozlesmeAlttipleri.Location = new System.Drawing.Point(9, 12);
            this.panelSozlesmeAlttipleri.Name = "panelSozlesmeAlttipleri";
            this.panelSozlesmeAlttipleri.Size = new System.Drawing.Size(750, 360);
            this.panelSozlesmeAlttipleri.TabIndex = 13;
            // 
            // gridSozlesmeAltTipleri
            // 
            this.gridSozlesmeAltTipleri.CustomButtonlarGorunmesin = false;
            this.gridSozlesmeAltTipleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSozlesmeAltTipleri.DoNotExtendEmbedNavigator = false;
            this.gridSozlesmeAltTipleri.FilterText = null;
            this.gridSozlesmeAltTipleri.FilterValue = null;
            this.gridSozlesmeAltTipleri.GridlerDuzenlenebilir = true;
            this.gridSozlesmeAltTipleri.GridsFilterControl = null;
            this.gridSozlesmeAltTipleri.Location = new System.Drawing.Point(2, 72);
            this.gridSozlesmeAltTipleri.MainView = this.gridView1;
            this.gridSozlesmeAltTipleri.MyGridStyle = null;
            this.gridSozlesmeAltTipleri.Name = "gridSozlesmeAltTipleri";
            this.gridSozlesmeAltTipleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit15,
            this.rCb_AnaTip});
            this.gridSozlesmeAltTipleri.ShowRowNumbers = false;
            this.gridSozlesmeAltTipleri.Size = new System.Drawing.Size(746, 286);
            this.gridSozlesmeAltTipleri.TabIndex = 5;
            this.gridSozlesmeAltTipleri.TemizleKaldirGorunsunmu = false;
            this.gridSozlesmeAltTipleri.UniqueId = "4071087b-7df7-4f9b-af9c-f61521206a68";
            this.gridSozlesmeAltTipleri.UseEmbeddedNavigator = true;
            this.gridSozlesmeAltTipleri.UseHyperDragDrop = false;
            this.gridSozlesmeAltTipleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ANA_TIP,
            this.ALT_TIP});
            this.gridView1.GridControl = this.gridSozlesmeAltTipleri;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Sözleþme Alt Tipi Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // ANA_TIP
            // 
            this.ANA_TIP.Caption = "Sözleþme Ana Tip";
            this.ANA_TIP.ColumnEdit = this.rCb_AnaTip;
            this.ANA_TIP.FieldName = "ANA_TIP";
            this.ANA_TIP.Name = "ANA_TIP";
            this.ANA_TIP.Visible = true;
            this.ANA_TIP.VisibleIndex = 0;
            // 
            // rCb_AnaTip
            // 
            this.rCb_AnaTip.AutoHeight = false;
            this.rCb_AnaTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_AnaTip.Name = "rCb_AnaTip";
            // 
            // ALT_TIP
            // 
            this.ALT_TIP.Caption = "Sözleþme Alt Tip ";
            this.ALT_TIP.ColumnEdit = this.repositoryItemTextEdit15;
            this.ALT_TIP.FieldName = "ALT_TIP";
            this.ALT_TIP.Name = "ALT_TIP";
            this.ALT_TIP.Visible = true;
            this.ALT_TIP.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit15
            // 
            this.repositoryItemTextEdit15.AutoHeight = false;
            this.repositoryItemTextEdit15.Name = "repositoryItemTextEdit15";
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
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sözleþme Alt Tipleri";
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
            this.sBtnKaydet.Location = new System.Drawing.Point(45, 10);
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
            this.gridControlExtender1.GridControl = this.gridSozlesmeAltTipleri;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(512, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 14;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmSozlesmeAltTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 457);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelSozlesmeAlttipleri);
            this.Name = "frmSozlesmeAltTip";
            this.Text = "Sözleþme Alt Tipleri";
            ((System.ComponentModel.ISupportInitialize)(this.panelSozlesmeAlttipleri)).EndInit();
            this.panelSozlesmeAlttipleri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSozlesmeAltTipleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_AnaTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelSozlesmeAlttipleri;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridSozlesmeAltTipleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn ANA_TIP;
        private DevExpress.XtraGrid.Columns.GridColumn ALT_TIP;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit15;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_AnaTip;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}