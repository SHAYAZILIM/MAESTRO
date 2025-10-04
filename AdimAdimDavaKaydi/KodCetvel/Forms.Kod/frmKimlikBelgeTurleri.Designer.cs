namespace  AnaForm
{
    partial class frmKimlikBelgeTurleri
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
            this.panelKimlikBelgeTurleri = new DevExpress.XtraEditors.PanelControl();
            this.gridKimlikBelgeTurleri = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.KIMLIK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit31 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelKimlikBelgeTurleri)).BeginInit();
            this.panelKimlikBelgeTurleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKimlikBelgeTurleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelKimlikBelgeTurleri
            // 
            this.panelKimlikBelgeTurleri.Controls.Add(this.gridKimlikBelgeTurleri);
            this.panelKimlikBelgeTurleri.Controls.Add(this.panelControl1);
            this.panelKimlikBelgeTurleri.Controls.Add(this.panelControl2);
            this.panelKimlikBelgeTurleri.Location = new System.Drawing.Point(17, 38);
            this.panelKimlikBelgeTurleri.Name = "panelKimlikBelgeTurleri";
            this.panelKimlikBelgeTurleri.Size = new System.Drawing.Size(740, 368);
            this.panelKimlikBelgeTurleri.TabIndex = 30;
            // 
            // gridKimlikBelgeTurleri
            // 
            this.gridKimlikBelgeTurleri.CustomButtonlarGorunmesin = false;
            this.gridKimlikBelgeTurleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridKimlikBelgeTurleri.DoNotExtendEmbedNavigator = false;
            this.gridKimlikBelgeTurleri.FilterText = null;
            this.gridKimlikBelgeTurleri.FilterValue = null;
            this.gridKimlikBelgeTurleri.GridlerDuzenlenebilir = true;
            this.gridKimlikBelgeTurleri.GridsFilterControl = null;
            this.gridKimlikBelgeTurleri.Location = new System.Drawing.Point(2, 72);
            this.gridKimlikBelgeTurleri.MainView = this.gridView1;
            this.gridKimlikBelgeTurleri.MyGridStyle = null;
            this.gridKimlikBelgeTurleri.Name = "gridKimlikBelgeTurleri";
            this.gridKimlikBelgeTurleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit31});
            this.gridKimlikBelgeTurleri.ShowRowNumbers = false;
            this.gridKimlikBelgeTurleri.Size = new System.Drawing.Size(736, 294);
            this.gridKimlikBelgeTurleri.TabIndex = 5;
            this.gridKimlikBelgeTurleri.TemizleKaldirGorunsunmu = false;
            this.gridKimlikBelgeTurleri.UniqueId = "690b36b2-e563-4889-93e1-21873d86095c";
            this.gridKimlikBelgeTurleri.UseEmbeddedNavigator = true;
            this.gridKimlikBelgeTurleri.UseHyperDragDrop = false;
            this.gridKimlikBelgeTurleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.KIMLIK});
            this.gridView1.GridControl = this.gridKimlikBelgeTurleri;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Belge Türleri Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // KIMLIK
            // 
            this.KIMLIK.Caption = "Kimlik Belge Türleri";
            this.KIMLIK.ColumnEdit = this.repositoryItemTextEdit31;
            this.KIMLIK.FieldName = "KIMLIK";
            this.KIMLIK.Name = "KIMLIK";
            this.KIMLIK.Visible = true;
            this.KIMLIK.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit31
            // 
            this.repositoryItemTextEdit31.AutoHeight = false;
            this.repositoryItemTextEdit31.Name = "repositoryItemTextEdit31";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(736, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Kimlik Belge Türleri";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(736, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridKimlikBelgeTurleri;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(736, 294);
            this.gridControlExtender1.Location = new System.Drawing.Point(511, 409);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 31;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(30, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmKimlikBelgeTurleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 444);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelKimlikBelgeTurleri);
            this.Name = "frmKimlikBelgeTurleri";
            this.Text = "Kimlik Belge Türleri";
            ((System.ComponentModel.ISupportInitialize)(this.panelKimlikBelgeTurleri)).EndInit();
            this.panelKimlikBelgeTurleri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridKimlikBelgeTurleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelKimlikBelgeTurleri;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridKimlikBelgeTurleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn KIMLIK;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit31;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}