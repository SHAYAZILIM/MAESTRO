namespace  AnaForm
{
    partial class frmTebligatAlinmamaNeden
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
            this.panelTebAlinmamaNeden = new DevExpress.XtraEditors.PanelControl();
            this.gridTebligatAlinmamaNeden = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NEDEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit19 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelTebAlinmamaNeden)).BeginInit();
            this.panelTebAlinmamaNeden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTebligatAlinmamaNeden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTebAlinmamaNeden
            // 
            this.panelTebAlinmamaNeden.Controls.Add(this.gridTebligatAlinmamaNeden);
            this.panelTebAlinmamaNeden.Controls.Add(this.panelControl1);
            this.panelTebAlinmamaNeden.Controls.Add(this.panelControl2);
            this.panelTebAlinmamaNeden.Location = new System.Drawing.Point(8, 12);
            this.panelTebAlinmamaNeden.Name = "panelTebAlinmamaNeden";
            this.panelTebAlinmamaNeden.Size = new System.Drawing.Size(750, 360);
            this.panelTebAlinmamaNeden.TabIndex = 15;
            // 
            // gridTebligatAlinmamaNeden
            // 
            this.gridTebligatAlinmamaNeden.CustomButtonlarGorunmesin = false;
            this.gridTebligatAlinmamaNeden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTebligatAlinmamaNeden.DoNotExtendEmbedNavigator = false;
            this.gridTebligatAlinmamaNeden.FilterText = null;
            this.gridTebligatAlinmamaNeden.FilterValue = null;
            this.gridTebligatAlinmamaNeden.GridlerDuzenlenebilir = true;
            this.gridTebligatAlinmamaNeden.GridsFilterControl = null;
            this.gridTebligatAlinmamaNeden.Location = new System.Drawing.Point(2, 72);
            this.gridTebligatAlinmamaNeden.MainView = this.gridView1;
            this.gridTebligatAlinmamaNeden.MyGridStyle = null;
            this.gridTebligatAlinmamaNeden.Name = "gridTebligatAlinmamaNeden";
            this.gridTebligatAlinmamaNeden.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit19});
            this.gridTebligatAlinmamaNeden.ShowRowNumbers = false;
            this.gridTebligatAlinmamaNeden.Size = new System.Drawing.Size(746, 286);
            this.gridTebligatAlinmamaNeden.TabIndex = 5;
            this.gridTebligatAlinmamaNeden.TemizleKaldirGorunsunmu = false;
            this.gridTebligatAlinmamaNeden.UniqueId = "d2ed6344-a7f6-40dc-8142-e469945cb4dd";
            this.gridTebligatAlinmamaNeden.UseEmbeddedNavigator = true;
            this.gridTebligatAlinmamaNeden.UseHyperDragDrop = false;
            this.gridTebligatAlinmamaNeden.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.NEDEN});
            this.gridView1.GridControl = this.gridTebligatAlinmamaNeden;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Tebligat Alýnmama Nedeni Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // NEDEN
            // 
            this.NEDEN.Caption = "Tebligat Alýnmama Neden";
            this.NEDEN.ColumnEdit = this.repositoryItemTextEdit19;
            this.NEDEN.FieldName = "NEDEN";
            this.NEDEN.Name = "NEDEN";
            this.NEDEN.Visible = true;
            this.NEDEN.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit19
            // 
            this.repositoryItemTextEdit19.AutoHeight = false;
            this.repositoryItemTextEdit19.Name = "repositoryItemTextEdit19";
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
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tebligat Alýnmama Nedeni";
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
            this.sBtnKaydet.Location = new System.Drawing.Point(81, 10);
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
            this.gridControlExtender1.GridControl = this.gridTebligatAlinmamaNeden;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(349, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 16;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmTebligatAlinmamaNeden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 457);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelTebAlinmamaNeden);
            this.Name = "frmTebligatAlinmamaNeden";
            this.Text = "Tebligat Alýnmama Nedeni";
            ((System.ComponentModel.ISupportInitialize)(this.panelTebAlinmamaNeden)).EndInit();
            this.panelTebAlinmamaNeden.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTebligatAlinmamaNeden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTebAlinmamaNeden;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTebligatAlinmamaNeden;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn NEDEN;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit19;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}