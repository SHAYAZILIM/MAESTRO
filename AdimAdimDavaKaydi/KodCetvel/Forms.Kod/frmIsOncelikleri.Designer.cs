namespace  AnaForm
{
    partial class frmIsOncelikleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIsOncelikleri));
            this.panelIsOncelikleri = new DevExpress.XtraEditors.PanelControl();
            this.gridIsOncelikleri = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IS_ONCELIK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit27 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelIsOncelikleri)).BeginInit();
            this.panelIsOncelikleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIsOncelikleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelIsOncelikleri
            // 
            this.panelIsOncelikleri.Controls.Add(this.gridIsOncelikleri);
            this.panelIsOncelikleri.Controls.Add(this.panelControl1);
            this.panelIsOncelikleri.Controls.Add(this.panelControl2);
            this.panelIsOncelikleri.Location = new System.Drawing.Point(6, 44);
            this.panelIsOncelikleri.Name = "panelIsOncelikleri";
            this.panelIsOncelikleri.Size = new System.Drawing.Size(750, 360);
            this.panelIsOncelikleri.TabIndex = 22;
            // 
            // gridIsOncelikleri
            // 
            this.gridIsOncelikleri.CustomButtonlarGorunmesin = false;
            this.gridIsOncelikleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridIsOncelikleri.DoNotExtendEmbedNavigator = false;
            this.gridIsOncelikleri.FilterText = null;
            this.gridIsOncelikleri.FilterValue = null;
            this.gridIsOncelikleri.GridlerDuzenlenebilir = true;
            this.gridIsOncelikleri.GridsFilterControl = null;
            this.gridIsOncelikleri.Location = new System.Drawing.Point(2, 72);
            this.gridIsOncelikleri.MainView = this.gridView1;
            this.gridIsOncelikleri.MyGridStyle = null;
            this.gridIsOncelikleri.Name = "gridIsOncelikleri";
            this.gridIsOncelikleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit27});
            this.gridIsOncelikleri.ShowRowNumbers = false;
            this.gridIsOncelikleri.Size = new System.Drawing.Size(746, 286);
            this.gridIsOncelikleri.TabIndex = 5;
            this.gridIsOncelikleri.TemizleKaldirGorunsunmu = false;
            this.gridIsOncelikleri.UniqueId = "d0f57729-c817-4081-a294-5adf6809e2cd";
            this.gridIsOncelikleri.UseEmbeddedNavigator = true;
            this.gridIsOncelikleri.UseHyperDragDrop = false;
            this.gridIsOncelikleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IS_ONCELIK});
            this.gridView1.GridControl = this.gridIsOncelikleri;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Ýþ Önceliði Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // IS_ONCELIK
            // 
            this.IS_ONCELIK.Caption = "Ýþ Öncelik";
            this.IS_ONCELIK.ColumnEdit = this.repositoryItemTextEdit27;
            this.IS_ONCELIK.FieldName = "IS_ONCELIK";
            this.IS_ONCELIK.Name = "IS_ONCELIK";
            this.IS_ONCELIK.Visible = true;
            this.IS_ONCELIK.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit27
            // 
            this.repositoryItemTextEdit27.AutoHeight = false;
            this.repositoryItemTextEdit27.Name = "repositoryItemTextEdit27";
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
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ýþ Öncelikleri";
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
            this.gridControlExtender1.GridControl = this.gridIsOncelikleri;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(454, 409);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 23;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(42, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmIsOncelikleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 449);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelIsOncelikleri);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIsOncelikleri";
            this.Text = "Ýþ Öncelikleri";
            ((System.ComponentModel.ISupportInitialize)(this.panelIsOncelikleri)).EndInit();
            this.panelIsOncelikleri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridIsOncelikleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelIsOncelikleri;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridIsOncelikleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn IS_ONCELIK;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit27;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}