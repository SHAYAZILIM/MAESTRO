namespace  AnaForm
{
    partial class frmVekaletGecerlilikTip
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
            this.panelVekaletGecerlilikTipler = new DevExpress.XtraEditors.PanelControl();
            this.gridVekaletGecerlilik = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GECERLILIK_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelVekaletGecerlilikTipler)).BeginInit();
            this.panelVekaletGecerlilikTipler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVekaletGecerlilik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelVekaletGecerlilikTipler
            // 
            this.panelVekaletGecerlilikTipler.Controls.Add(this.gridVekaletGecerlilik);
            this.panelVekaletGecerlilikTipler.Controls.Add(this.panelControl1);
            this.panelVekaletGecerlilikTipler.Controls.Add(this.panelControl2);
            this.panelVekaletGecerlilikTipler.Location = new System.Drawing.Point(8, 16);
            this.panelVekaletGecerlilikTipler.Name = "panelVekaletGecerlilikTipler";
            this.panelVekaletGecerlilikTipler.Size = new System.Drawing.Size(750, 360);
            this.panelVekaletGecerlilikTipler.TabIndex = 17;
            // 
            // gridVekaletGecerlilik
            // 
            this.gridVekaletGecerlilik.CustomButtonlarGorunmesin = false;
            this.gridVekaletGecerlilik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVekaletGecerlilik.DoNotExtendEmbedNavigator = false;
            this.gridVekaletGecerlilik.FilterText = null;
            this.gridVekaletGecerlilik.FilterValue = null;
            this.gridVekaletGecerlilik.GridlerDuzenlenebilir = true;
            this.gridVekaletGecerlilik.GridsFilterControl = null;
            this.gridVekaletGecerlilik.Location = new System.Drawing.Point(2, 72);
            this.gridVekaletGecerlilik.MainView = this.gridView1;
            this.gridVekaletGecerlilik.MyGridStyle = null;
            this.gridVekaletGecerlilik.Name = "gridVekaletGecerlilik";
            this.gridVekaletGecerlilik.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.gridVekaletGecerlilik.ShowRowNumbers = false;
            this.gridVekaletGecerlilik.Size = new System.Drawing.Size(746, 286);
            this.gridVekaletGecerlilik.TabIndex = 5;
            this.gridVekaletGecerlilik.TemizleKaldirGorunsunmu = false;
            this.gridVekaletGecerlilik.UniqueId = "ccf93cc5-eb5a-4cc5-8d83-6022000a9fa4";
            this.gridVekaletGecerlilik.UseEmbeddedNavigator = true;
            this.gridVekaletGecerlilik.UseHyperDragDrop = false;
            this.gridVekaletGecerlilik.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GECERLILIK_TIP});
            this.gridView1.GridControl = this.gridVekaletGecerlilik;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Vekalet Geçerlilik Tipi Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // GECERLILIK_TIP
            // 
            this.GECERLILIK_TIP.Caption = "Vekalet Geçerlilik Tipi";
            this.GECERLILIK_TIP.ColumnEdit = this.repositoryItemTextEdit1;
            this.GECERLILIK_TIP.FieldName = "GECERLILIK_TIP";
            this.GECERLILIK_TIP.Name = "GECERLILIK_TIP";
            this.GECERLILIK_TIP.Visible = true;
            this.GECERLILIK_TIP.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
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
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Vekalet Geçerlilik Tip Kodlarý";
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
            this.gridControlExtender1.GridControl = this.gridVekaletGecerlilik;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(549, 383);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 18;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(94, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 7;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // frmVekaletGecerlilikTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 438);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelVekaletGecerlilikTipler);
            this.Name = "frmVekaletGecerlilikTip";
            this.Text = "Vekalet Geçerlilik Tip Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelVekaletGecerlilikTipler)).EndInit();
            this.panelVekaletGecerlilikTipler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridVekaletGecerlilik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelVekaletGecerlilikTipler;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridVekaletGecerlilik;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn GECERLILIK_TIP;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}