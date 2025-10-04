namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    partial class frmDavaSonucKodlari
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.rtxteDavaSonuc = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.DAVASONUC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridDavaSonuc = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.panelDavaSonuc = new DevExpress.XtraEditors.PanelControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteDavaSonuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaSonuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDavaSonuc)).BeginInit();
            this.panelDavaSonuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(578, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dava Sonuç";
            // 
            // rtxteDavaSonuc
            // 
            this.rtxteDavaSonuc.AutoHeight = false;
            this.rtxteDavaSonuc.Name = "rtxteDavaSonuc";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(19, 10);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(117, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // DAVASONUC
            // 
            this.DAVASONUC.Caption = "Dava Sonuç";
            this.DAVASONUC.ColumnEdit = this.rtxteDavaSonuc;
            this.DAVASONUC.FieldName = "SONUC";
            this.DAVASONUC.Name = "DAVASONUC";
            this.DAVASONUC.Visible = true;
            this.DAVASONUC.VisibleIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(578, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DAVASONUC});
            this.gridView1.GridControl = this.gridDavaSonuc;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Başlıkları Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Dava Sonuç Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // gridDavaSonuc
            // 
            this.gridDavaSonuc.CustomButtonlarGorunmesin = false;
            this.gridDavaSonuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDavaSonuc.DoNotExtendEmbedNavigator = false;
            this.gridDavaSonuc.FilterText = null;
            this.gridDavaSonuc.FilterValue = null;
            this.gridDavaSonuc.GridlerDuzenlenebilir = true;
            this.gridDavaSonuc.GridsFilterControl = null;
            this.gridDavaSonuc.Location = new System.Drawing.Point(2, 72);
            this.gridDavaSonuc.MainView = this.gridView1;
            this.gridDavaSonuc.MyGridStyle = null;
            this.gridDavaSonuc.Name = "gridDavaSonuc";
            this.gridDavaSonuc.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rtxteDavaSonuc});
            this.gridDavaSonuc.ShowRowNumbers = false;
            this.gridDavaSonuc.SilmeKaldirilsin = false;
            this.gridDavaSonuc.Size = new System.Drawing.Size(578, 291);
            this.gridDavaSonuc.TabIndex = 5;
            this.gridDavaSonuc.TemizleKaldirGorunsunmu = false;
            this.gridDavaSonuc.UniqueId = "3242e327-0591-46a5-a0b8-8f65c0a4c469";
            this.gridDavaSonuc.UseEmbeddedNavigator = true;
            this.gridDavaSonuc.UseHyperDragDrop = false;
            this.gridDavaSonuc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // panelDavaSonuc
            // 
            this.panelDavaSonuc.Controls.Add(this.gridDavaSonuc);
            this.panelDavaSonuc.Controls.Add(this.panelControl1);
            this.panelDavaSonuc.Controls.Add(this.panelControl2);
            this.panelDavaSonuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDavaSonuc.Location = new System.Drawing.Point(0, 0);
            this.panelDavaSonuc.Name = "panelDavaSonuc";
            this.panelDavaSonuc.Size = new System.Drawing.Size(582, 365);
            this.panelDavaSonuc.TabIndex = 20;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // frmDavaSonucKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 365);
            this.Controls.Add(this.panelDavaSonuc);
            this.Name = "frmDavaSonucKodlari";
            this.Text = "frmDavaSonucKodlari";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteDavaSonuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaSonuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDavaSonuc)).EndInit();
            this.panelDavaSonuc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxteDavaSonuc;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Columns.GridColumn DAVASONUC;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDavaSonuc;
        private DevExpress.XtraEditors.PanelControl panelDavaSonuc;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}