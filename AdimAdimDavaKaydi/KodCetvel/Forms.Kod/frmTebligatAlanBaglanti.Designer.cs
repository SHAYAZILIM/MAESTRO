namespace  AnaForm
{
    partial class frmTebligatAlanBaglanti
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
            this.panelTebligatalanBaglanti = new DevExpress.XtraEditors.PanelControl();
            this.gridTebligatAlanBaglanti = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.KOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit17 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.BAGLANTI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit18 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelTebligatalanBaglanti)).BeginInit();
            this.panelTebligatalanBaglanti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTebligatAlanBaglanti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTebligatalanBaglanti
            // 
            this.panelTebligatalanBaglanti.Controls.Add(this.gridTebligatAlanBaglanti);
            this.panelTebligatalanBaglanti.Controls.Add(this.panelControl1);
            this.panelTebligatalanBaglanti.Controls.Add(this.panelControl2);
            this.panelTebligatalanBaglanti.Location = new System.Drawing.Point(12, 12);
            this.panelTebligatalanBaglanti.Name = "panelTebligatalanBaglanti";
            this.panelTebligatalanBaglanti.Size = new System.Drawing.Size(750, 360);
            this.panelTebligatalanBaglanti.TabIndex = 14;
            // 
            // gridTebligatAlanBaglanti
            // 
            this.gridTebligatAlanBaglanti.CustomButtonlarGorunmesin = false;
            this.gridTebligatAlanBaglanti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTebligatAlanBaglanti.DoNotExtendEmbedNavigator = false;
            this.gridTebligatAlanBaglanti.FilterText = null;
            this.gridTebligatAlanBaglanti.FilterValue = null;
            this.gridTebligatAlanBaglanti.GridlerDuzenlenebilir = true;
            this.gridTebligatAlanBaglanti.GridsFilterControl = null;
            this.gridTebligatAlanBaglanti.Location = new System.Drawing.Point(2, 72);
            this.gridTebligatAlanBaglanti.MainView = this.gridView1;
            this.gridTebligatAlanBaglanti.MyGridStyle = null;
            this.gridTebligatAlanBaglanti.Name = "gridTebligatAlanBaglanti";
            this.gridTebligatAlanBaglanti.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit17,
            this.repositoryItemTextEdit18});
            this.gridTebligatAlanBaglanti.ShowRowNumbers = false;
            this.gridTebligatAlanBaglanti.Size = new System.Drawing.Size(746, 286);
            this.gridTebligatAlanBaglanti.TabIndex = 5;
            this.gridTebligatAlanBaglanti.TemizleKaldirGorunsunmu = false;
            this.gridTebligatAlanBaglanti.UniqueId = "69be2a2e-35f1-4840-bde9-34ffe570b634";
            this.gridTebligatAlanBaglanti.UseEmbeddedNavigator = true;
            this.gridTebligatAlanBaglanti.UseHyperDragDrop = false;
            this.gridTebligatAlanBaglanti.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.KOD,
            this.BAGLANTI});
            this.gridView1.GridControl = this.gridTebligatAlanBaglanti;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Alan Baðlantýsý Ekleyin ";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // KOD
            // 
            this.KOD.Caption = "Tebligat Alan Baðlantý Kod";
            this.KOD.ColumnEdit = this.repositoryItemTextEdit17;
            this.KOD.FieldName = "KOD";
            this.KOD.Name = "KOD";
            this.KOD.Visible = true;
            this.KOD.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit17
            // 
            this.repositoryItemTextEdit17.AutoHeight = false;
            this.repositoryItemTextEdit17.Name = "repositoryItemTextEdit17";
            // 
            // BAGLANTI
            // 
            this.BAGLANTI.Caption = "Tebligat alan Baðlantý";
            this.BAGLANTI.ColumnEdit = this.repositoryItemTextEdit18;
            this.BAGLANTI.FieldName = "BAGLANTI";
            this.BAGLANTI.Name = "BAGLANTI";
            this.BAGLANTI.Visible = true;
            this.BAGLANTI.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit18
            // 
            this.repositoryItemTextEdit18.AutoHeight = false;
            this.repositoryItemTextEdit18.Name = "repositoryItemTextEdit18";
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
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tebligat alan Baðlantý";
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
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(56, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 6;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridTebligatAlanBaglanti;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(513, 394);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 15;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmTebligatAlanBaglanti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 438);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelTebligatalanBaglanti);
            this.Name = "frmTebligatAlanBaglanti";
            this.Text = "Tebligat Alan Baðlantý";
            ((System.ComponentModel.ISupportInitialize)(this.panelTebligatalanBaglanti)).EndInit();
            this.panelTebligatalanBaglanti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTebligatAlanBaglanti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTebligatalanBaglanti;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTebligatAlanBaglanti;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn KOD;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit17;
        private DevExpress.XtraGrid.Columns.GridColumn BAGLANTI;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit18;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}