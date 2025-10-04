namespace  AnaForm
{
    partial class frmYayinTurleri
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
            this.panelYayinTurleri = new DevExpress.XtraEditors.PanelControl();
            this.gridYayinTurleri = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.YAYIN_TURU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit28 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelYayinTurleri)).BeginInit();
            this.panelYayinTurleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridYayinTurleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelYayinTurleri
            // 
            this.panelYayinTurleri.Controls.Add(this.gridYayinTurleri);
            this.panelYayinTurleri.Controls.Add(this.panelControl1);
            this.panelYayinTurleri.Controls.Add(this.panelControl2);
            this.panelYayinTurleri.Location = new System.Drawing.Point(8, 20);
            this.panelYayinTurleri.Name = "panelYayinTurleri";
            this.panelYayinTurleri.Size = new System.Drawing.Size(750, 360);
            this.panelYayinTurleri.TabIndex = 23;
            // 
            // gridYayinTurleri
            // 
            this.gridYayinTurleri.CustomButtonlarGorunmesin = false;
            this.gridYayinTurleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridYayinTurleri.DoNotExtendEmbedNavigator = false;
            this.gridYayinTurleri.FilterText = null;
            this.gridYayinTurleri.FilterValue = null;
            this.gridYayinTurleri.GridlerDuzenlenebilir = true;
            this.gridYayinTurleri.GridsFilterControl = null;
            this.gridYayinTurleri.Location = new System.Drawing.Point(2, 72);
            this.gridYayinTurleri.MainView = this.gridView1;
            this.gridYayinTurleri.MyGridStyle = null;
            this.gridYayinTurleri.Name = "gridYayinTurleri";
            this.gridYayinTurleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit28});
            this.gridYayinTurleri.ShowRowNumbers = false;
            this.gridYayinTurleri.Size = new System.Drawing.Size(746, 286);
            this.gridYayinTurleri.TabIndex = 5;
            this.gridYayinTurleri.TemizleKaldirGorunsunmu = false;
            this.gridYayinTurleri.UniqueId = "2710c6dd-8ae7-490c-8ec5-358c96cad7f4";
            this.gridYayinTurleri.UseEmbeddedNavigator = true;
            this.gridYayinTurleri.UseHyperDragDrop = false;
            this.gridYayinTurleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.YAYIN_TURU});
            this.gridView1.GridControl = this.gridYayinTurleri;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Yayýn Türleri Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // YAYIN_TURU
            // 
            this.YAYIN_TURU.Caption = "Yayin Türü";
            this.YAYIN_TURU.ColumnEdit = this.repositoryItemTextEdit28;
            this.YAYIN_TURU.FieldName = "YAYIN_TURU";
            this.YAYIN_TURU.Name = "YAYIN_TURU";
            this.YAYIN_TURU.Visible = true;
            this.YAYIN_TURU.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit28
            // 
            this.repositoryItemTextEdit28.AutoHeight = false;
            this.repositoryItemTextEdit28.Name = "repositoryItemTextEdit28";
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
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Yayýn Türleri";
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
            this.gridControlExtender1.GridControl = this.gridYayinTurleri;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(481, 385);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 24;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(5, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 7;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // frmYayinTurleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 423);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelYayinTurleri);
            this.Name = "frmYayinTurleri";
            this.Text = "Yayýn Türleri";
            ((System.ComponentModel.ISupportInitialize)(this.panelYayinTurleri)).EndInit();
            this.panelYayinTurleri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridYayinTurleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelYayinTurleri;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridYayinTurleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn YAYIN_TURU;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit28;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}