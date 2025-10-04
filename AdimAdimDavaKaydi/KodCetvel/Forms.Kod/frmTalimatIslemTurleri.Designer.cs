namespace  AnaForm
{
    partial class frmTalimatIslemTurleri
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
            this.panelTalimatIslemTuru = new DevExpress.XtraEditors.PanelControl();
            this.gridTalimatIslemTuru = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ISLEM_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit26 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelTalimatIslemTuru)).BeginInit();
            this.panelTalimatIslemTuru.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTalimatIslemTuru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTalimatIslemTuru
            // 
            this.panelTalimatIslemTuru.Controls.Add(this.gridTalimatIslemTuru);
            this.panelTalimatIslemTuru.Controls.Add(this.panelControl1);
            this.panelTalimatIslemTuru.Controls.Add(this.panelControl2);
            this.panelTalimatIslemTuru.Location = new System.Drawing.Point(12, 12);
            this.panelTalimatIslemTuru.Name = "panelTalimatIslemTuru";
            this.panelTalimatIslemTuru.Size = new System.Drawing.Size(750, 360);
            this.panelTalimatIslemTuru.TabIndex = 19;
            // 
            // gridTalimatIslemTuru
            // 
            this.gridTalimatIslemTuru.CustomButtonlarGorunmesin = false;
            this.gridTalimatIslemTuru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTalimatIslemTuru.DoNotExtendEmbedNavigator = false;
            this.gridTalimatIslemTuru.FilterText = null;
            this.gridTalimatIslemTuru.FilterValue = null;
            this.gridTalimatIslemTuru.GridlerDuzenlenebilir = true;
            this.gridTalimatIslemTuru.GridsFilterControl = null;
            this.gridTalimatIslemTuru.Location = new System.Drawing.Point(2, 72);
            this.gridTalimatIslemTuru.MainView = this.gridView1;
            this.gridTalimatIslemTuru.MyGridStyle = null;
            this.gridTalimatIslemTuru.Name = "gridTalimatIslemTuru";
            this.gridTalimatIslemTuru.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit26});
            this.gridTalimatIslemTuru.ShowRowNumbers = false;
            this.gridTalimatIslemTuru.Size = new System.Drawing.Size(746, 286);
            this.gridTalimatIslemTuru.TabIndex = 5;
            this.gridTalimatIslemTuru.TemizleKaldirGorunsunmu = false;
            this.gridTalimatIslemTuru.UniqueId = "3fa4613b-6078-499d-bcaa-d57aeced8a87";
            this.gridTalimatIslemTuru.UseEmbeddedNavigator = true;
            this.gridTalimatIslemTuru.UseHyperDragDrop = false;
            this.gridTalimatIslemTuru.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ISLEM_TIP});
            this.gridView1.GridControl = this.gridTalimatIslemTuru;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Talimat Ýþlem Türü Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // ISLEM_TIP
            // 
            this.ISLEM_TIP.Caption = "Talimat Ýþlem Tipi";
            this.ISLEM_TIP.ColumnEdit = this.repositoryItemTextEdit26;
            this.ISLEM_TIP.FieldName = "ISLEM_TIP";
            this.ISLEM_TIP.Name = "ISLEM_TIP";
            this.ISLEM_TIP.Visible = true;
            this.ISLEM_TIP.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit26
            // 
            this.repositoryItemTextEdit26.AutoHeight = false;
            this.repositoryItemTextEdit26.Name = "repositoryItemTextEdit26";
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
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Talimat Ýþlem Türleri";
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
            this.sBtnKaydet.Location = new System.Drawing.Point(52, 10);
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
            this.gridControlExtender1.GridControl = this.gridTalimatIslemTuru;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(469, 377);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 20;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmTalimatIslemTurleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 402);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelTalimatIslemTuru);
            this.Name = "frmTalimatIslemTurleri";
            this.Text = "Talimat Ýþlem Türleri";
            ((System.ComponentModel.ISupportInitialize)(this.panelTalimatIslemTuru)).EndInit();
            this.panelTalimatIslemTuru.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTalimatIslemTuru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTalimatIslemTuru;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTalimatIslemTuru;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn ISLEM_TIP;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit26;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}