namespace  AnaForm
{
    partial class frmUlkeKodlari
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
            this.panelUlkeKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridUlkeKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ULKE_ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.KOD_ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.KOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ULKE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelUlkeKodlar)).BeginInit();
            this.panelUlkeKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUlkeKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUlkeKodlar
            // 
            this.panelUlkeKodlar.Controls.Add(this.gridUlkeKodlar);
            this.panelUlkeKodlar.Controls.Add(this.panelControl1);
            this.panelUlkeKodlar.Controls.Add(this.panelControl2);
            this.panelUlkeKodlar.Location = new System.Drawing.Point(12, 12);
            this.panelUlkeKodlar.Name = "panelUlkeKodlar";
            this.panelUlkeKodlar.Size = new System.Drawing.Size(740, 368);
            this.panelUlkeKodlar.TabIndex = 34;
            // 
            // gridUlkeKodlar
            // 
            this.gridUlkeKodlar.CustomButtonlarGorunmesin = false;
            this.gridUlkeKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUlkeKodlar.DoNotExtendEmbedNavigator = false;
            this.gridUlkeKodlar.FilterText = null;
            this.gridUlkeKodlar.FilterValue = null;
            this.gridUlkeKodlar.GridlerDuzenlenebilir = true;
            this.gridUlkeKodlar.GridsFilterControl = null;
            this.gridUlkeKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridUlkeKodlar.MainView = this.gridView1;
            this.gridUlkeKodlar.MyGridStyle = null;
            this.gridUlkeKodlar.Name = "gridUlkeKodlar";
            this.gridUlkeKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2});
            this.gridUlkeKodlar.ShowRowNumbers = false;
            this.gridUlkeKodlar.SilmeKaldirilsin = false;
            this.gridUlkeKodlar.Size = new System.Drawing.Size(736, 294);
            this.gridUlkeKodlar.TabIndex = 5;
            this.gridUlkeKodlar.TemizleKaldirGorunsunmu = false;
            this.gridUlkeKodlar.UniqueId = "bed6d9eb-1914-4712-aa19-92e7231cca34";
            this.gridUlkeKodlar.UseEmbeddedNavigator = true;
            this.gridUlkeKodlar.UseHyperDragDrop = false;
            this.gridUlkeKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ULKE_,
            this.KOD_});
            this.gridView1.GridControl = this.gridUlkeKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Ülke Kodlarý Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // ULKE_
            // 
            this.ULKE_.Caption = "Ülke";
            this.ULKE_.ColumnEdit = this.repositoryItemTextEdit1;
            this.ULKE_.FieldName = "ULKE";
            this.ULKE_.Name = "ULKE_";
            this.ULKE_.Visible = true;
            this.ULKE_.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // KOD_
            // 
            this.KOD_.Caption = "Kodu";
            this.KOD_.ColumnEdit = this.repositoryItemTextEdit2;
            this.KOD_.FieldName = "KOD";
            this.KOD_.Name = "KOD_";
            this.KOD_.Visible = true;
            this.KOD_.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
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
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ülke Kodlarý";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.sBtnKaydet);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(736, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(29, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 7;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // KOD
            // 
            this.KOD.Caption = "Ülke Kodlarý";
            this.KOD.FieldName = "KOD";
            this.KOD.Name = "KOD";
            this.KOD.Visible = true;
            this.KOD.VisibleIndex = 0;
            // 
            // ULKE
            // 
            this.ULKE.Caption = "Ülke Kodu";
            this.ULKE.FieldName = "ULKE";
            this.ULKE.Name = "ULKE";
            this.ULKE.Visible = true;
            this.ULKE.VisibleIndex = 0;
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridUlkeKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(736, 294);
            this.gridControlExtender1.Location = new System.Drawing.Point(511, 387);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 35;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmUlkeKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 448);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelUlkeKodlar);
            this.Name = "frmUlkeKodlari";
            this.Text = "Ülke Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelUlkeKodlar)).EndInit();
            this.panelUlkeKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUlkeKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelUlkeKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridUlkeKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn ULKE;
        private DevExpress.XtraGrid.Columns.GridColumn ULKE_;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn KOD;
        private DevExpress.XtraGrid.Columns.GridColumn KOD_;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}