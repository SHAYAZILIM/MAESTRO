namespace  AnaForm
{
    partial class frmItirazSonuclari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItirazSonuclari));
            this.panelItirazSonuclari = new DevExpress.XtraEditors.PanelControl();
            this.gridItirazSonuclari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ITIRAZ_SONUC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelItirazSonuclari)).BeginInit();
            this.panelItirazSonuclari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItirazSonuclari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelItirazSonuclari
            // 
            this.panelItirazSonuclari.Controls.Add(this.gridItirazSonuclari);
            this.panelItirazSonuclari.Controls.Add(this.panelControl1);
            this.panelItirazSonuclari.Controls.Add(this.panelControl2);
            this.panelItirazSonuclari.Location = new System.Drawing.Point(12, 12);
            this.panelItirazSonuclari.Name = "panelItirazSonuclari";
            this.panelItirazSonuclari.Size = new System.Drawing.Size(750, 360);
            this.panelItirazSonuclari.TabIndex = 10;
            // 
            // gridItirazSonuclari
            // 
            this.gridItirazSonuclari.CustomButtonlarGorunmesin = false;
            this.gridItirazSonuclari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItirazSonuclari.DoNotExtendEmbedNavigator = false;
            this.gridItirazSonuclari.FilterText = null;
            this.gridItirazSonuclari.FilterValue = null;
            this.gridItirazSonuclari.GridlerDuzenlenebilir = true;
            this.gridItirazSonuclari.GridsFilterControl = null;
            this.gridItirazSonuclari.Location = new System.Drawing.Point(2, 72);
            this.gridItirazSonuclari.MainView = this.gridView1;
            this.gridItirazSonuclari.MyGridStyle = null;
            this.gridItirazSonuclari.Name = "gridItirazSonuclari";
            this.gridItirazSonuclari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit5});
            this.gridItirazSonuclari.ShowRowNumbers = false;
            this.gridItirazSonuclari.Size = new System.Drawing.Size(746, 286);
            this.gridItirazSonuclari.TabIndex = 5;
            this.gridItirazSonuclari.TemizleKaldirGorunsunmu = false;
            this.gridItirazSonuclari.UniqueId = "3d6ed533-67f1-4bca-92a3-22978d31b765";
            this.gridItirazSonuclari.UseEmbeddedNavigator = true;
            this.gridItirazSonuclari.UseHyperDragDrop = false;
            this.gridItirazSonuclari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ITIRAZ_SONUC});
            this.gridView1.GridControl = this.gridItirazSonuclari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Ýtiraz Sonucu Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // ITIRAZ_SONUC
            // 
            this.ITIRAZ_SONUC.Caption = "Ýtiraz Sonuçlarý";
            this.ITIRAZ_SONUC.ColumnEdit = this.repositoryItemTextEdit5;
            this.ITIRAZ_SONUC.FieldName = "ITIRAZ_SONUC";
            this.ITIRAZ_SONUC.Name = "ITIRAZ_SONUC";
            this.ITIRAZ_SONUC.Visible = true;
            this.ITIRAZ_SONUC.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit5
            // 
            this.repositoryItemTextEdit5.AutoHeight = false;
            this.repositoryItemTextEdit5.Name = "repositoryItemTextEdit5";
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
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ýtiraz Sonuçlarý";
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
            this.gridControlExtender1.GridControl = this.gridItirazSonuclari;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(470, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 11;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(26, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmItirazSonuclari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 428);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelItirazSonuclari);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmItirazSonuclari";
            this.Text = "Ýtiraz Sonuçlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelItirazSonuclari)).EndInit();
            this.panelItirazSonuclari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItirazSonuclari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelItirazSonuclari;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridItirazSonuclari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn ITIRAZ_SONUC;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}