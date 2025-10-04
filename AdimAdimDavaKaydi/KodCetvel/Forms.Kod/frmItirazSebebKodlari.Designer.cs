namespace  AnaForm
{
    partial class frmItirazSebebKodlari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItirazSebebKodlari));
            this.panelItirazSebebKodlari = new DevExpress.XtraEditors.PanelControl();
            this.gridItirazSebebKodlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ITIRAZ_SEBEP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit15 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelItirazSebebKodlari)).BeginInit();
            this.panelItirazSebebKodlari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItirazSebebKodlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelItirazSebebKodlari
            // 
            this.panelItirazSebebKodlari.Controls.Add(this.gridItirazSebebKodlari);
            this.panelItirazSebebKodlari.Controls.Add(this.panelControl1);
            this.panelItirazSebebKodlari.Controls.Add(this.panelControl2);
            this.panelItirazSebebKodlari.Location = new System.Drawing.Point(12, 12);
            this.panelItirazSebebKodlari.Name = "panelItirazSebebKodlari";
            this.panelItirazSebebKodlari.Size = new System.Drawing.Size(750, 360);
            this.panelItirazSebebKodlari.TabIndex = 14;
            // 
            // gridItirazSebebKodlari
            // 
            this.gridItirazSebebKodlari.CustomButtonlarGorunmesin = false;
            this.gridItirazSebebKodlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItirazSebebKodlari.DoNotExtendEmbedNavigator = false;
            this.gridItirazSebebKodlari.FilterText = null;
            this.gridItirazSebebKodlari.FilterValue = null;
            this.gridItirazSebebKodlari.GridlerDuzenlenebilir = true;
            this.gridItirazSebebKodlari.GridsFilterControl = null;
            this.gridItirazSebebKodlari.Location = new System.Drawing.Point(2, 72);
            this.gridItirazSebebKodlari.MainView = this.gridView1;
            this.gridItirazSebebKodlari.MyGridStyle = null;
            this.gridItirazSebebKodlari.Name = "gridItirazSebebKodlari";
            this.gridItirazSebebKodlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit15});
            this.gridItirazSebebKodlari.ShowRowNumbers = false;
            this.gridItirazSebebKodlari.Size = new System.Drawing.Size(746, 286);
            this.gridItirazSebebKodlari.TabIndex = 5;
            this.gridItirazSebebKodlari.TemizleKaldirGorunsunmu = false;
            this.gridItirazSebebKodlari.UniqueId = "baa1d7c6-ed57-4396-b6c4-782ec7e89caf";
            this.gridItirazSebebKodlari.UseEmbeddedNavigator = true;
            this.gridItirazSebebKodlari.UseHyperDragDrop = false;
            this.gridItirazSebebKodlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ITIRAZ_SEBEP});
            this.gridView1.GridControl = this.gridItirazSebebKodlari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Ýtiraz Sebebleri Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // ITIRAZ_SEBEP
            // 
            this.ITIRAZ_SEBEP.Caption = "Ýtiraz Sebeb";
            this.ITIRAZ_SEBEP.ColumnEdit = this.repositoryItemTextEdit15;
            this.ITIRAZ_SEBEP.FieldName = "ITIRAZ_SEBEP";
            this.ITIRAZ_SEBEP.Name = "ITIRAZ_SEBEP";
            this.ITIRAZ_SEBEP.Visible = true;
            this.ITIRAZ_SEBEP.VisibleIndex = 0;
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
            this.label1.Text = "Ýtiraz Sebeb Kodlarý";
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
            this.gridControlExtender1.GridControl = this.gridItirazSebebKodlari;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(457, 377);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 15;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(34, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmItirazSebebKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 418);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelItirazSebebKodlari);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmItirazSebebKodlari";
            this.Text = "Ýtiraz Sebep Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelItirazSebebKodlari)).EndInit();
            this.panelItirazSebebKodlari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItirazSebebKodlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelItirazSebebKodlari;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridItirazSebebKodlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn ITIRAZ_SEBEP;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit15;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}