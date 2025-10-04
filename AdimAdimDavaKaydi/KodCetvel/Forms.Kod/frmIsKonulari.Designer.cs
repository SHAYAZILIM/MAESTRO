namespace  AnaForm
{
    partial class frmIsKonulari
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
            this.panelIsKonulari = new DevExpress.XtraEditors.PanelControl();
            this.gridIsKonulari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IS_KONUSU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit22 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelIsKonulari)).BeginInit();
            this.panelIsKonulari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIsKonulari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelIsKonulari
            // 
            this.panelIsKonulari.Controls.Add(this.gridIsKonulari);
            this.panelIsKonulari.Controls.Add(this.panelControl1);
            this.panelIsKonulari.Controls.Add(this.panelControl2);
            this.panelIsKonulari.Location = new System.Drawing.Point(8, 12);
            this.panelIsKonulari.Name = "panelIsKonulari";
            this.panelIsKonulari.Size = new System.Drawing.Size(750, 360);
            this.panelIsKonulari.TabIndex = 20;
            // 
            // gridIsKonulari
            // 
            this.gridIsKonulari.CustomButtonlarGorunmesin = false;
            this.gridIsKonulari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridIsKonulari.DoNotExtendEmbedNavigator = false;
            this.gridIsKonulari.FilterText = null;
            this.gridIsKonulari.FilterValue = null;
            this.gridIsKonulari.GridlerDuzenlenebilir = true;
            this.gridIsKonulari.GridsFilterControl = null;
            this.gridIsKonulari.Location = new System.Drawing.Point(2, 72);
            this.gridIsKonulari.MainView = this.gridView1;
            this.gridIsKonulari.MyGridStyle = null;
            this.gridIsKonulari.Name = "gridIsKonulari";
            this.gridIsKonulari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit22});
            this.gridIsKonulari.ShowRowNumbers = false;
            this.gridIsKonulari.Size = new System.Drawing.Size(746, 286);
            this.gridIsKonulari.TabIndex = 5;
            this.gridIsKonulari.TemizleKaldirGorunsunmu = false;
            this.gridIsKonulari.UniqueId = "8a7a010c-f585-4f7e-8552-72438065a4ee";
            this.gridIsKonulari.UseEmbeddedNavigator = true;
            this.gridIsKonulari.UseHyperDragDrop = false;
            this.gridIsKonulari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IS_KONUSU});
            this.gridView1.GridControl = this.gridIsKonulari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Ýþ Konusu Ekleyin ";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // IS_KONUSU
            // 
            this.IS_KONUSU.Caption = "Ýþin Konusu";
            this.IS_KONUSU.ColumnEdit = this.repositoryItemTextEdit22;
            this.IS_KONUSU.FieldName = "IS_KONUSU";
            this.IS_KONUSU.Name = "IS_KONUSU";
            this.IS_KONUSU.Visible = true;
            this.IS_KONUSU.VisibleIndex = 0;
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
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ýþ Konularý";
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
            this.gridControlExtender1.GridControl = this.gridIsKonulari;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(508, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 21;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(33, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmIsKonulari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 445);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelIsKonulari);
            this.Name = "frmIsKonulari";
            this.Text = "Ýþ Konularý";
            ((System.ComponentModel.ISupportInitialize)(this.panelIsKonulari)).EndInit();
            this.panelIsKonulari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridIsKonulari)).EndInit();
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

        private DevExpress.XtraEditors.PanelControl panelIsKonulari;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridIsKonulari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn IS_KONUSU;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit22;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}