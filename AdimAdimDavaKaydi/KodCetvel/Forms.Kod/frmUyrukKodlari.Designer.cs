namespace  AnaForm
{
    partial class frmUyrukKodlari
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
            this.panelUyrukKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridUyrukKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.UYRUK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit41 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelUyrukKodlar)).BeginInit();
            this.panelUyrukKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUyrukKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUyrukKodlar
            // 
            this.panelUyrukKodlar.Controls.Add(this.gridUyrukKodlar);
            this.panelUyrukKodlar.Controls.Add(this.panelControl1);
            this.panelUyrukKodlar.Controls.Add(this.panelControl2);
            this.panelUyrukKodlar.Location = new System.Drawing.Point(12, 12);
            this.panelUyrukKodlar.Name = "panelUyrukKodlar";
            this.panelUyrukKodlar.Size = new System.Drawing.Size(750, 360);
            this.panelUyrukKodlar.TabIndex = 31;
            // 
            // gridUyrukKodlar
            // 
            this.gridUyrukKodlar.CustomButtonlarGorunmesin = false;
            this.gridUyrukKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUyrukKodlar.DoNotExtendEmbedNavigator = false;
            this.gridUyrukKodlar.FilterText = null;
            this.gridUyrukKodlar.FilterValue = null;
            this.gridUyrukKodlar.GridlerDuzenlenebilir = true;
            this.gridUyrukKodlar.GridsFilterControl = null;
            this.gridUyrukKodlar.Location = new System.Drawing.Point(2, 69);
            this.gridUyrukKodlar.MainView = this.gridView1;
            this.gridUyrukKodlar.MyGridStyle = null;
            this.gridUyrukKodlar.Name = "gridUyrukKodlar";
            this.gridUyrukKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit41});
            this.gridUyrukKodlar.ShowRowNumbers = false;
            this.gridUyrukKodlar.Size = new System.Drawing.Size(746, 289);
            this.gridUyrukKodlar.TabIndex = 5;
            this.gridUyrukKodlar.TemizleKaldirGorunsunmu = false;
            this.gridUyrukKodlar.UniqueId = "b19915ab-1c7a-41cd-96ee-377c137359e1";
            this.gridUyrukKodlar.UseEmbeddedNavigator = true;
            this.gridUyrukKodlar.UseHyperDragDrop = false;
            this.gridUyrukKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.UYRUK});
            this.gridView1.GridControl = this.gridUyrukKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Uyruk Kodlarý Ekle ";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // UYRUK
            // 
            this.UYRUK.Caption = "Uyruk Kodu";
            this.UYRUK.ColumnEdit = this.repositoryItemTextEdit41;
            this.UYRUK.FieldName = "UYRUK";
            this.UYRUK.Name = "UYRUK";
            this.UYRUK.Visible = true;
            this.UYRUK.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit41
            // 
            this.repositoryItemTextEdit41.AutoHeight = false;
            this.repositoryItemTextEdit41.Name = "repositoryItemTextEdit41";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 42);
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
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Uyruk Kodlarý";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.sBtnKaydet);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(746, 40);
            this.panelControl2.TabIndex = 2;
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridUyrukKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 69);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 289);
            this.gridControlExtender1.Location = new System.Drawing.Point(437, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 32;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(10, 9);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 7;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // frmUyrukKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 454);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelUyrukKodlar);
            this.Name = "frmUyrukKodlari";
            this.Text = "Uyruk Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelUyrukKodlar)).EndInit();
            this.panelUyrukKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUyrukKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelUyrukKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridUyrukKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn UYRUK;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit41;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}