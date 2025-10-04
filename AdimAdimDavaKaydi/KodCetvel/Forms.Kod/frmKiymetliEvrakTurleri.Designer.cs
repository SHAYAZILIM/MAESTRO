namespace  AnaForm
{
    partial class frmKiymetliEvrakTurleri
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
            this.panelKiymetliEvrakTurleri = new DevExpress.XtraEditors.PanelControl();
            this.gridKiymetliEvrakTurleri = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TUR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit22 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelKiymetliEvrakTurleri)).BeginInit();
            this.panelKiymetliEvrakTurleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKiymetliEvrakTurleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelKiymetliEvrakTurleri
            // 
            this.panelKiymetliEvrakTurleri.Controls.Add(this.gridKiymetliEvrakTurleri);
            this.panelKiymetliEvrakTurleri.Controls.Add(this.panelControl1);
            this.panelKiymetliEvrakTurleri.Controls.Add(this.panelControl2);
            this.panelKiymetliEvrakTurleri.Location = new System.Drawing.Point(5, 12);
            this.panelKiymetliEvrakTurleri.Name = "panelKiymetliEvrakTurleri";
            this.panelKiymetliEvrakTurleri.Size = new System.Drawing.Size(750, 360);
            this.panelKiymetliEvrakTurleri.TabIndex = 21;
            // 
            // gridKiymetliEvrakTurleri
            // 
            this.gridKiymetliEvrakTurleri.CustomButtonlarGorunmesin = false;
            this.gridKiymetliEvrakTurleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridKiymetliEvrakTurleri.DoNotExtendEmbedNavigator = false;
            this.gridKiymetliEvrakTurleri.FilterText = null;
            this.gridKiymetliEvrakTurleri.FilterValue = null;
            this.gridKiymetliEvrakTurleri.GridlerDuzenlenebilir = true;
            this.gridKiymetliEvrakTurleri.GridsFilterControl = null;
            this.gridKiymetliEvrakTurleri.Location = new System.Drawing.Point(2, 72);
            this.gridKiymetliEvrakTurleri.MainView = this.gridView1;
            this.gridKiymetliEvrakTurleri.MyGridStyle = null;
            this.gridKiymetliEvrakTurleri.Name = "gridKiymetliEvrakTurleri";
            this.gridKiymetliEvrakTurleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit22});
            this.gridKiymetliEvrakTurleri.ShowRowNumbers = false;
            this.gridKiymetliEvrakTurleri.Size = new System.Drawing.Size(746, 286);
            this.gridKiymetliEvrakTurleri.TabIndex = 5;
            this.gridKiymetliEvrakTurleri.TemizleKaldirGorunsunmu = false;
            this.gridKiymetliEvrakTurleri.UniqueId = "84b1e21f-5374-4b7a-9aa6-46319adde20e";
            this.gridKiymetliEvrakTurleri.UseEmbeddedNavigator = true;
            this.gridKiymetliEvrakTurleri.UseHyperDragDrop = false;
            this.gridKiymetliEvrakTurleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TUR});
            this.gridView1.GridControl = this.gridKiymetliEvrakTurleri;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Kýymetli Evrak Türü Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // TUR
            // 
            this.TUR.Caption = "Kýymetli Evrak Türleri";
            this.TUR.ColumnEdit = this.repositoryItemTextEdit22;
            this.TUR.FieldName = "TUR";
            this.TUR.Name = "TUR";
            this.TUR.Visible = true;
            this.TUR.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit22
            // 
            this.repositoryItemTextEdit22.AutoHeight = false;
            this.repositoryItemTextEdit22.Name = "repositoryItemTextEdit22";
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
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Kýymetli Evrak Türleri";
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
            this.gridControlExtender1.GridControl = this.gridKiymetliEvrakTurleri;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(507, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 22;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(27, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmKiymetliEvrakTurleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 452);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelKiymetliEvrakTurleri);
            this.Name = "frmKiymetliEvrakTurleri";
            this.Text = "Kýymetli Evrak Türleri";
            ((System.ComponentModel.ISupportInitialize)(this.panelKiymetliEvrakTurleri)).EndInit();
            this.panelKiymetliEvrakTurleri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridKiymetliEvrakTurleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelKiymetliEvrakTurleri;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridKiymetliEvrakTurleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn TUR;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit22;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}