namespace  AnaForm
{
    partial class frnIcraKodlar1
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
            this.panelSozlesmeTarafKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridSozlesmeTarafKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TARAF_SIFAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit54 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelSozlesmeTarafKodlar)).BeginInit();
            this.panelSozlesmeTarafKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSozlesmeTarafKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSozlesmeTarafKodlar
            // 
            this.panelSozlesmeTarafKodlar.Controls.Add(this.gridSozlesmeTarafKodlar);
            this.panelSozlesmeTarafKodlar.Controls.Add(this.panelControl1);
            this.panelSozlesmeTarafKodlar.Controls.Add(this.panelControl2);
            this.panelSozlesmeTarafKodlar.Location = new System.Drawing.Point(6, 51);
            this.panelSozlesmeTarafKodlar.Name = "panelSozlesmeTarafKodlar";
            this.panelSozlesmeTarafKodlar.Size = new System.Drawing.Size(750, 360);
            this.panelSozlesmeTarafKodlar.TabIndex = 42;
            // 
            // gridSozlesmeTarafKodlar
            // 
            this.gridSozlesmeTarafKodlar.CustomButtonlarGorunmesin = false;
            this.gridSozlesmeTarafKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSozlesmeTarafKodlar.DoNotExtendEmbedNavigator = false;
            this.gridSozlesmeTarafKodlar.FilterText = null;
            this.gridSozlesmeTarafKodlar.FilterValue = null;
            this.gridSozlesmeTarafKodlar.GridlerDuzenlenebilir = true;
            this.gridSozlesmeTarafKodlar.GridsFilterControl = null;
            this.gridSozlesmeTarafKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridSozlesmeTarafKodlar.MainView = this.gridView1;
            this.gridSozlesmeTarafKodlar.MyGridStyle = null;
            this.gridSozlesmeTarafKodlar.Name = "gridSozlesmeTarafKodlar";
            this.gridSozlesmeTarafKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit54});
            this.gridSozlesmeTarafKodlar.ShowRowNumbers = false;
            this.gridSozlesmeTarafKodlar.Size = new System.Drawing.Size(746, 286);
            this.gridSozlesmeTarafKodlar.TabIndex = 5;
            this.gridSozlesmeTarafKodlar.TemizleKaldirGorunsunmu = false;
            this.gridSozlesmeTarafKodlar.UniqueId = "9d8b8552-a003-4704-978a-e9578053ddc2";
            this.gridSozlesmeTarafKodlar.UseEmbeddedNavigator = true;
            this.gridSozlesmeTarafKodlar.UseHyperDragDrop = false;
            this.gridSozlesmeTarafKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TARAF_SIFAT});
            this.gridView1.GridControl = this.gridSozlesmeTarafKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Sözleþme Taraf Sýfatý Ekleyin ";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // TARAF_SIFAT
            // 
            this.TARAF_SIFAT.Caption = "Taraf Sýfat Kodlarý";
            this.TARAF_SIFAT.ColumnEdit = this.repositoryItemTextEdit54;
            this.TARAF_SIFAT.FieldName = "TARAF_SIFAT";
            this.TARAF_SIFAT.Name = "TARAF_SIFAT";
            this.TARAF_SIFAT.Visible = true;
            this.TARAF_SIFAT.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit54
            // 
            this.repositoryItemTextEdit54.AutoHeight = false;
            this.repositoryItemTextEdit54.Name = "repositoryItemTextEdit54";
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
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sözleþme Taraf Kodlarý";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.sBtnKaydet);
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
            this.gridControlExtender1.GridControl = this.gridSozlesmeTarafKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(490, 418);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 43;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(63, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 7;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // frnIcraKodlar1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 463);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelSozlesmeTarafKodlar);
            this.Name = "frnIcraKodlar1";
            this.Text = "Sözleþme Taraf Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelSozlesmeTarafKodlar)).EndInit();
            this.panelSozlesmeTarafKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSozlesmeTarafKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelSozlesmeTarafKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridSozlesmeTarafKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn TARAF_SIFAT;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit54;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}