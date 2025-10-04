namespace  AnaForm
{
    partial class frmDavaGelismeKodlari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDavaGelismeKodlari));
            this.panelDavaGelismeKadlar = new DevExpress.XtraEditors.PanelControl();
            this.gridDavaGelismeKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GELISME_ADIM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelDavaGelismeKadlar)).BeginInit();
            this.panelDavaGelismeKadlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaGelismeKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDavaGelismeKadlar
            // 
            this.panelDavaGelismeKadlar.Controls.Add(this.gridDavaGelismeKodlar);
            this.panelDavaGelismeKadlar.Controls.Add(this.panelControl1);
            this.panelDavaGelismeKadlar.Controls.Add(this.panelControl2);
            this.panelDavaGelismeKadlar.Location = new System.Drawing.Point(10, 13);
            this.panelDavaGelismeKadlar.Name = "panelDavaGelismeKadlar";
            this.panelDavaGelismeKadlar.Size = new System.Drawing.Size(750, 360);
            this.panelDavaGelismeKadlar.TabIndex = 14;
            // 
            // gridDavaGelismeKodlar
            // 
            this.gridDavaGelismeKodlar.CustomButtonlarGorunmesin = false;
            this.gridDavaGelismeKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDavaGelismeKodlar.DoNotExtendEmbedNavigator = false;
            this.gridDavaGelismeKodlar.FilterText = null;
            this.gridDavaGelismeKodlar.FilterValue = null;
            this.gridDavaGelismeKodlar.GridlerDuzenlenebilir = true;
            this.gridDavaGelismeKodlar.GridsFilterControl = null;
            this.gridDavaGelismeKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridDavaGelismeKodlar.MainView = this.gridView1;
            this.gridDavaGelismeKodlar.MyGridStyle = null;
            this.gridDavaGelismeKodlar.Name = "gridDavaGelismeKodlar";
            this.gridDavaGelismeKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.gridDavaGelismeKodlar.ShowRowNumbers = false;
            this.gridDavaGelismeKodlar.Size = new System.Drawing.Size(746, 286);
            this.gridDavaGelismeKodlar.TabIndex = 5;
            this.gridDavaGelismeKodlar.TemizleKaldirGorunsunmu = false;
            this.gridDavaGelismeKodlar.UniqueId = "cb2c13de-d479-49c5-b3f2-4cd21725463c";
            this.gridDavaGelismeKodlar.UseEmbeddedNavigator = true;
            this.gridDavaGelismeKodlar.UseHyperDragDrop = false;
            this.gridDavaGelismeKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GELISME_ADIM});
            this.gridView1.GridControl = this.gridDavaGelismeKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Geliþme Adým Ekle ";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // GELISME_ADIM
            // 
            this.GELISME_ADIM.Caption = "Geliþme Adýmý";
            this.GELISME_ADIM.ColumnEdit = this.repositoryItemTextEdit1;
            this.GELISME_ADIM.FieldName = "GELISME_ADIM";
            this.GELISME_ADIM.Name = "GELISME_ADIM";
            this.GELISME_ADIM.Visible = true;
            this.GELISME_ADIM.VisibleIndex = 0;
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
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dava Dosyasý Geliþme Kodlarý";
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
            this.gridControlExtender1.GridControl = this.gridDavaGelismeKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(422, 378);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 15;
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
            // frmDavaGelismeKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 418);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelDavaGelismeKadlar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDavaGelismeKodlari";
            this.Text = "Dava Dosyasý Geliþme Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelDavaGelismeKadlar)).EndInit();
            this.panelDavaGelismeKadlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaGelismeKodlar)).EndInit();
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

        private DevExpress.XtraEditors.PanelControl panelDavaGelismeKadlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDavaGelismeKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn GELISME_ADIM;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}