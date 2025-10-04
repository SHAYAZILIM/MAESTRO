namespace  AnaForm
{
    partial class frmItirazinGiderilmeYolKodlari
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
            this.panelItirazinGiderilmeYollari = new DevExpress.XtraEditors.PanelControl();
            this.gridItirazinGiderilmeYollari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ITIRAZIN_GIDERILME_YOLU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit15 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.YASAL_DAYANAK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit16 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelItirazinGiderilmeYollari)).BeginInit();
            this.panelItirazinGiderilmeYollari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItirazinGiderilmeYollari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelItirazinGiderilmeYollari
            // 
            this.panelItirazinGiderilmeYollari.Controls.Add(this.gridItirazinGiderilmeYollari);
            this.panelItirazinGiderilmeYollari.Controls.Add(this.panelControl1);
            this.panelItirazinGiderilmeYollari.Controls.Add(this.panelControl2);
            this.panelItirazinGiderilmeYollari.Location = new System.Drawing.Point(12, 12);
            this.panelItirazinGiderilmeYollari.Name = "panelItirazinGiderilmeYollari";
            this.panelItirazinGiderilmeYollari.Size = new System.Drawing.Size(750, 360);
            this.panelItirazinGiderilmeYollari.TabIndex = 14;
            // 
            // gridItirazinGiderilmeYollari
            // 
            this.gridItirazinGiderilmeYollari.CustomButtonlarGorunmesin = false;
            this.gridItirazinGiderilmeYollari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItirazinGiderilmeYollari.DoNotExtendEmbedNavigator = false;
            this.gridItirazinGiderilmeYollari.FilterText = null;
            this.gridItirazinGiderilmeYollari.FilterValue = null;
            this.gridItirazinGiderilmeYollari.GridlerDuzenlenebilir = true;
            this.gridItirazinGiderilmeYollari.GridsFilterControl = null;
            this.gridItirazinGiderilmeYollari.Location = new System.Drawing.Point(2, 72);
            this.gridItirazinGiderilmeYollari.MainView = this.gridView1;
            this.gridItirazinGiderilmeYollari.MyGridStyle = null;
            this.gridItirazinGiderilmeYollari.Name = "gridItirazinGiderilmeYollari";
            this.gridItirazinGiderilmeYollari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit15,
            this.repositoryItemTextEdit16});
            this.gridItirazinGiderilmeYollari.ShowRowNumbers = false;
            this.gridItirazinGiderilmeYollari.Size = new System.Drawing.Size(746, 286);
            this.gridItirazinGiderilmeYollari.TabIndex = 5;
            this.gridItirazinGiderilmeYollari.TemizleKaldirGorunsunmu = false;
            this.gridItirazinGiderilmeYollari.UniqueId = "a7da9735-22d1-434e-b43b-b8e7e92e8607";
            this.gridItirazinGiderilmeYollari.UseEmbeddedNavigator = true;
            this.gridItirazinGiderilmeYollari.UseHyperDragDrop = false;
            this.gridItirazinGiderilmeYollari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ITIRAZIN_GIDERILME_YOLU,
            this.YASAL_DAYANAK});
            this.gridView1.GridControl = this.gridItirazinGiderilmeYollari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Ýtirazýn Giderilme Yolu Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // ITIRAZIN_GIDERILME_YOLU
            // 
            this.ITIRAZIN_GIDERILME_YOLU.Caption = "Ýtirazýn Giderilme Yolu";
            this.ITIRAZIN_GIDERILME_YOLU.ColumnEdit = this.repositoryItemTextEdit15;
            this.ITIRAZIN_GIDERILME_YOLU.FieldName = "ITIRAZIN_GIDERILME_YOLU";
            this.ITIRAZIN_GIDERILME_YOLU.Name = "ITIRAZIN_GIDERILME_YOLU";
            this.ITIRAZIN_GIDERILME_YOLU.Visible = true;
            this.ITIRAZIN_GIDERILME_YOLU.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit15
            // 
            this.repositoryItemTextEdit15.AutoHeight = false;
            this.repositoryItemTextEdit15.Name = "repositoryItemTextEdit15";
            // 
            // YASAL_DAYANAK
            // 
            this.YASAL_DAYANAK.Caption = "Yasal Dayanak";
            this.YASAL_DAYANAK.ColumnEdit = this.repositoryItemTextEdit16;
            this.YASAL_DAYANAK.FieldName = "YASAL_DAYANAK";
            this.YASAL_DAYANAK.Name = "YASAL_DAYANAK";
            this.YASAL_DAYANAK.Visible = true;
            this.YASAL_DAYANAK.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit16
            // 
            this.repositoryItemTextEdit16.AutoHeight = false;
            this.repositoryItemTextEdit16.Name = "repositoryItemTextEdit16";
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
            this.label1.Text = "Ýtirazýn Giderilme Yol Kodlarý";
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
            this.gridControlExtender1.GridControl = this.gridItirazinGiderilmeYollari;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(508, 377);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 15;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(36, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmItirazinGiderilmeYolKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 453);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelItirazinGiderilmeYollari);
            this.Name = "frmItirazinGiderilmeYolKodlari";
            this.Text = "Ýtirazýn Giderilme Yol Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelItirazinGiderilmeYollari)).EndInit();
            this.panelItirazinGiderilmeYollari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItirazinGiderilmeYollari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelItirazinGiderilmeYollari;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridItirazinGiderilmeYollari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn ITIRAZIN_GIDERILME_YOLU;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit15;
        private DevExpress.XtraGrid.Columns.GridColumn YASAL_DAYANAK;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit16;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}