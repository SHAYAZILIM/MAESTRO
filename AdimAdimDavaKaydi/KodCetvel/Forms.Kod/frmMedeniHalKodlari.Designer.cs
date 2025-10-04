namespace  AnaForm
{
    partial class frmMedeniHalKodlari
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
            this.panelMedeniHalKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridMedeniHalKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MEDENI_HAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit32 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelMedeniHalKodlar)).BeginInit();
            this.panelMedeniHalKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMedeniHalKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMedeniHalKodlar
            // 
            this.panelMedeniHalKodlar.Controls.Add(this.gridMedeniHalKodlar);
            this.panelMedeniHalKodlar.Controls.Add(this.panelControl1);
            this.panelMedeniHalKodlar.Controls.Add(this.panelControl2);
            this.panelMedeniHalKodlar.Location = new System.Drawing.Point(12, 12);
            this.panelMedeniHalKodlar.Name = "panelMedeniHalKodlar";
            this.panelMedeniHalKodlar.Size = new System.Drawing.Size(740, 368);
            this.panelMedeniHalKodlar.TabIndex = 31;
            // 
            // gridMedeniHalKodlar
            // 
            this.gridMedeniHalKodlar.CustomButtonlarGorunmesin = false;
            this.gridMedeniHalKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMedeniHalKodlar.DoNotExtendEmbedNavigator = false;
            this.gridMedeniHalKodlar.FilterText = null;
            this.gridMedeniHalKodlar.FilterValue = null;
            this.gridMedeniHalKodlar.GridlerDuzenlenebilir = true;
            this.gridMedeniHalKodlar.GridsFilterControl = null;
            this.gridMedeniHalKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridMedeniHalKodlar.MainView = this.gridView1;
            this.gridMedeniHalKodlar.MyGridStyle = null;
            this.gridMedeniHalKodlar.Name = "gridMedeniHalKodlar";
            this.gridMedeniHalKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit32});
            this.gridMedeniHalKodlar.ShowRowNumbers = false;
            this.gridMedeniHalKodlar.Size = new System.Drawing.Size(736, 294);
            this.gridMedeniHalKodlar.TabIndex = 5;
            this.gridMedeniHalKodlar.TemizleKaldirGorunsunmu = false;
            this.gridMedeniHalKodlar.UniqueId = "9df35110-1d0c-4d12-8879-7eab9989f501";
            this.gridMedeniHalKodlar.UseEmbeddedNavigator = true;
            this.gridMedeniHalKodlar.UseHyperDragDrop = false;
            this.gridMedeniHalKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MEDENI_HAL});
            this.gridView1.GridControl = this.gridMedeniHalKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Medeni Hal Ekle";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // MEDENI_HAL
            // 
            this.MEDENI_HAL.Caption = "Medeni Hal Kodlarý";
            this.MEDENI_HAL.ColumnEdit = this.repositoryItemTextEdit32;
            this.MEDENI_HAL.FieldName = "MEDENI_HAL";
            this.MEDENI_HAL.Name = "MEDENI_HAL";
            this.MEDENI_HAL.Visible = true;
            this.MEDENI_HAL.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit32
            // 
            this.repositoryItemTextEdit32.AutoHeight = false;
            this.repositoryItemTextEdit32.Name = "repositoryItemTextEdit32";
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
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Medeni Hal Kodlarý";
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
            this.gridControlExtender1.GridControl = this.gridMedeniHalKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(736, 294);
            this.gridControlExtender1.Location = new System.Drawing.Point(457, 387);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 32;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(29, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmMedeniHalKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 438);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelMedeniHalKodlar);
            this.Name = "frmMedeniHalKodlari";
            this.Text = "Medeni Hal Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelMedeniHalKodlar)).EndInit();
            this.panelMedeniHalKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMedeniHalKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelMedeniHalKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridMedeniHalKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn MEDENI_HAL;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit32;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}