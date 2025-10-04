namespace  AnaForm
{
    partial class frmTespitOzelKodlari
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
            this.panelTespitOzelKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridTespitOzelKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TESPIT_OZEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTespitOzelKodlar)).BeginInit();
            this.panelTespitOzelKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTespitOzelKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTespitOzelKodlar
            // 
            this.panelTespitOzelKodlar.Controls.Add(this.gridTespitOzelKodlar);
            this.panelTespitOzelKodlar.Controls.Add(this.panelControl1);
            this.panelTespitOzelKodlar.Controls.Add(this.panelControl2);
            this.panelTespitOzelKodlar.Location = new System.Drawing.Point(12, 12);
            this.panelTespitOzelKodlar.Name = "panelTespitOzelKodlar";
            this.panelTespitOzelKodlar.Size = new System.Drawing.Size(750, 360);
            this.panelTespitOzelKodlar.TabIndex = 15;
            // 
            // gridTespitOzelKodlar
            // 
            this.gridTespitOzelKodlar.CustomButtonlarGorunmesin = false;
            this.gridTespitOzelKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTespitOzelKodlar.DoNotExtendEmbedNavigator = false;
            this.gridTespitOzelKodlar.FilterText = null;
            this.gridTespitOzelKodlar.FilterValue = null;
            this.gridTespitOzelKodlar.GridlerDuzenlenebilir = true;
            this.gridTespitOzelKodlar.GridsFilterControl = null;
            this.gridTespitOzelKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridTespitOzelKodlar.MainView = this.gridView1;
            this.gridTespitOzelKodlar.MyGridStyle = null;
            this.gridTespitOzelKodlar.Name = "gridTespitOzelKodlar";
            this.gridTespitOzelKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.gridTespitOzelKodlar.ShowRowNumbers = false;
            this.gridTespitOzelKodlar.Size = new System.Drawing.Size(746, 286);
            this.gridTespitOzelKodlar.TabIndex = 5;
            this.gridTespitOzelKodlar.TemizleKaldirGorunsunmu = false;
            this.gridTespitOzelKodlar.UniqueId = "55da2310-eac9-46e4-a502-dcd16d763ba2";
            this.gridTespitOzelKodlar.UseEmbeddedNavigator = true;
            this.gridTespitOzelKodlar.UseHyperDragDrop = false;
            this.gridTespitOzelKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TESPIT_OZEL});
            this.gridView1.GridControl = this.gridTespitOzelKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Tespit Özel kodu Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // TESPIT_OZEL
            // 
            this.TESPIT_OZEL.Caption = "Tespit Özel Konularý";
            this.TESPIT_OZEL.ColumnEdit = this.repositoryItemTextEdit1;
            this.TESPIT_OZEL.FieldName = "TESPIT_OZEL";
            this.TESPIT_OZEL.Name = "TESPIT_OZEL";
            this.TESPIT_OZEL.Visible = true;
            this.TESPIT_OZEL.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
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
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tespit Özel Kodlarý";
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
            this.gridControlExtender1.GridControl = this.gridTespitOzelKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(558, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 16;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(38, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 7;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // frmTespitOzelKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 441);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelTespitOzelKodlar);
            this.Name = "frmTespitOzelKodlari";
            this.Text = "Tespit Özel Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelTespitOzelKodlar)).EndInit();
            this.panelTespitOzelKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTespitOzelKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTespitOzelKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTespitOzelKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn TESPIT_OZEL;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}