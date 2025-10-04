namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    partial class frmYazar
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
            this.label1 = new System.Windows.Forms.Label();
            this.gridYazarlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.YAZAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxteYazar = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelYazarlar = new DevExpress.XtraEditors.PanelControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridYazarlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteYazar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelYazarlar)).BeginInit();
            this.panelYazarlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Yazar";
            // 
            // gridYazarlar
            // 
            this.gridYazarlar.CustomButtonlarGorunmesin = false;
            this.gridYazarlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridYazarlar.DoNotExtendEmbedNavigator = false;
            this.gridYazarlar.FilterText = null;
            this.gridYazarlar.FilterValue = null;
            this.gridYazarlar.GridlerDuzenlenebilir = true;
            this.gridYazarlar.GridsFilterControl = null;
            this.gridYazarlar.Location = new System.Drawing.Point(2, 72);
            this.gridYazarlar.MainView = this.gridView1;
            this.gridYazarlar.MyGridStyle = null;
            this.gridYazarlar.Name = "gridYazarlar";
            this.gridYazarlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rtxteYazar});
            this.gridYazarlar.ShowRowNumbers = false;
            this.gridYazarlar.SilmeKaldirilsin = false;
            this.gridYazarlar.Size = new System.Drawing.Size(690, 303);
            this.gridYazarlar.TabIndex = 5;
            this.gridYazarlar.TemizleKaldirGorunsunmu = false;
            this.gridYazarlar.UniqueId = "3a680960-3c4a-4a38-b222-1ba808e0f963";
            this.gridYazarlar.UseEmbeddedNavigator = true;
            this.gridYazarlar.UseHyperDragDrop = false;
            this.gridYazarlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.YAZAR});
            this.gridView1.GridControl = this.gridYazarlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Başlıkları Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Yazar Adı Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // YAZAR
            // 
            this.YAZAR.Caption = "Yazar";
            this.YAZAR.ColumnEdit = this.rtxteYazar;
            this.YAZAR.FieldName = "YAZAR";
            this.YAZAR.Name = "YAZAR";
            this.YAZAR.Visible = true;
            this.YAZAR.VisibleIndex = 0;
            // 
            // rtxteYazar
            // 
            this.rtxteYazar.AutoHeight = false;
            this.rtxteYazar.Name = "rtxteYazar";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(690, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(690, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(20, 10);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(117, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // panelYazarlar
            // 
            this.panelYazarlar.Controls.Add(this.gridYazarlar);
            this.panelYazarlar.Controls.Add(this.panelControl1);
            this.panelYazarlar.Controls.Add(this.panelControl2);
            this.panelYazarlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelYazarlar.Location = new System.Drawing.Point(0, 0);
            this.panelYazarlar.Name = "panelYazarlar";
            this.panelYazarlar.Size = new System.Drawing.Size(694, 377);
            this.panelYazarlar.TabIndex = 21;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // frmYazar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 377);
            this.Controls.Add(this.panelYazarlar);
            this.Name = "frmYazar";
            this.Text = "Yazar Kodları";
            ((System.ComponentModel.ISupportInitialize)(this.gridYazarlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteYazar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelYazarlar)).EndInit();
            this.panelYazarlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private DevExpress.XtraEditors.PanelControl panelYazarlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridYazarlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn YAZAR;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxteYazar;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}