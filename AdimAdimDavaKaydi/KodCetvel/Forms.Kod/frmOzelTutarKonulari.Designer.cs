namespace  AnaForm
{
    partial class frmOzelTutarKonulari
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
            this.panelOzelTutarKonular = new DevExpress.XtraEditors.PanelControl();
            this.gridOzelTutarKonular = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.KONU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit31 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelOzelTutarKonular)).BeginInit();
            this.panelOzelTutarKonular.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOzelTutarKonular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOzelTutarKonular
            // 
            this.panelOzelTutarKonular.Controls.Add(this.gridOzelTutarKonular);
            this.panelOzelTutarKonular.Controls.Add(this.panelControl1);
            this.panelOzelTutarKonular.Controls.Add(this.panelControl2);
            this.panelOzelTutarKonular.Location = new System.Drawing.Point(12, 12);
            this.panelOzelTutarKonular.Name = "panelOzelTutarKonular";
            this.panelOzelTutarKonular.Size = new System.Drawing.Size(740, 368);
            this.panelOzelTutarKonular.TabIndex = 31;
            // 
            // gridOzelTutarKonular
            // 
            this.gridOzelTutarKonular.CustomButtonlarGorunmesin = false;
            this.gridOzelTutarKonular.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOzelTutarKonular.DoNotExtendEmbedNavigator = false;
            this.gridOzelTutarKonular.FilterText = null;
            this.gridOzelTutarKonular.FilterValue = null;
            this.gridOzelTutarKonular.GridlerDuzenlenebilir = true;
            this.gridOzelTutarKonular.GridsFilterControl = null;
            this.gridOzelTutarKonular.Location = new System.Drawing.Point(2, 72);
            this.gridOzelTutarKonular.MainView = this.gridView1;
            this.gridOzelTutarKonular.MyGridStyle = null;
            this.gridOzelTutarKonular.Name = "gridOzelTutarKonular";
            this.gridOzelTutarKonular.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit31});
            this.gridOzelTutarKonular.ShowRowNumbers = false;
            this.gridOzelTutarKonular.Size = new System.Drawing.Size(736, 294);
            this.gridOzelTutarKonular.TabIndex = 5;
            this.gridOzelTutarKonular.TemizleKaldirGorunsunmu = false;
            this.gridOzelTutarKonular.UniqueId = "75e23ebd-fc25-469a-8450-5c5e89b3d70b";
            this.gridOzelTutarKonular.UseEmbeddedNavigator = true;
            this.gridOzelTutarKonular.UseHyperDragDrop = false;
            this.gridOzelTutarKonular.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.KONU});
            this.gridView1.GridControl = this.gridOzelTutarKonular;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Öze Tutar Konularý Ekleyin ";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // KONU
            // 
            this.KONU.Caption = "Özel Tutar Konularý";
            this.KONU.ColumnEdit = this.repositoryItemTextEdit31;
            this.KONU.FieldName = "KONU";
            this.KONU.Name = "KONU";
            this.KONU.Visible = true;
            this.KONU.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit31
            // 
            this.repositoryItemTextEdit31.AutoHeight = false;
            this.repositoryItemTextEdit31.Name = "repositoryItemTextEdit31";
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
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Özel Tutar Konularý";
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
            this.sBtnKaydet.Location = new System.Drawing.Point(41, 10);
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
            this.gridControlExtender1.GridControl = this.gridOzelTutarKonular;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(736, 294);
            this.gridControlExtender1.Location = new System.Drawing.Point(501, 385);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 32;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmOzelTutarKonulari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 421);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelOzelTutarKonular);
            this.Name = "frmOzelTutarKonulari";
            this.Text = "Özel Tutar Konularý";
            ((System.ComponentModel.ISupportInitialize)(this.panelOzelTutarKonular)).EndInit();
            this.panelOzelTutarKonular.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridOzelTutarKonular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelOzelTutarKonular;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridOzelTutarKonular;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn KONU;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit31;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}