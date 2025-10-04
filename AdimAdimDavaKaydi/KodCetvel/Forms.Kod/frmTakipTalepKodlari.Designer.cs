namespace  AnaForm
{
    partial class frmTakipTalepKodlari
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
            this.panelTakipTalepKodlari = new DevExpress.XtraEditors.PanelControl();
            this.gridTakipTalepKodlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TALEP_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit11 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.FORM_TIPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit12 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelTakipTalepKodlari)).BeginInit();
            this.panelTakipTalepKodlari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTakipTalepKodlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTakipTalepKodlari
            // 
            this.panelTakipTalepKodlari.Controls.Add(this.gridTakipTalepKodlari);
            this.panelTakipTalepKodlari.Controls.Add(this.panelControl1);
            this.panelTakipTalepKodlari.Controls.Add(this.panelControl2);
            this.panelTakipTalepKodlari.Location = new System.Drawing.Point(12, 12);
            this.panelTakipTalepKodlari.Name = "panelTakipTalepKodlari";
            this.panelTakipTalepKodlari.Size = new System.Drawing.Size(750, 360);
            this.panelTakipTalepKodlari.TabIndex = 19;
            // 
            // gridTakipTalepKodlari
            // 
            this.gridTakipTalepKodlari.CustomButtonlarGorunmesin = false;
            this.gridTakipTalepKodlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTakipTalepKodlari.DoNotExtendEmbedNavigator = false;
            this.gridTakipTalepKodlari.FilterText = null;
            this.gridTakipTalepKodlari.FilterValue = null;
            this.gridTakipTalepKodlari.GridlerDuzenlenebilir = true;
            this.gridTakipTalepKodlari.GridsFilterControl = null;
            this.gridTakipTalepKodlari.Location = new System.Drawing.Point(2, 72);
            this.gridTakipTalepKodlari.MainView = this.gridView1;
            this.gridTakipTalepKodlari.MyGridStyle = null;
            this.gridTakipTalepKodlari.Name = "gridTakipTalepKodlari";
            this.gridTakipTalepKodlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit11,
            this.repositoryItemTextEdit12});
            this.gridTakipTalepKodlari.ShowRowNumbers = false;
            this.gridTakipTalepKodlari.Size = new System.Drawing.Size(746, 286);
            this.gridTakipTalepKodlari.TabIndex = 5;
            this.gridTakipTalepKodlari.TemizleKaldirGorunsunmu = false;
            this.gridTakipTalepKodlari.UniqueId = "b1ad1d27-cbe5-4de1-a590-93f8167a2399";
            this.gridTakipTalepKodlari.UseEmbeddedNavigator = true;
            this.gridTakipTalepKodlari.UseHyperDragDrop = false;
            this.gridTakipTalepKodlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TALEP_ADI,
            this.FORM_TIPI});
            this.gridView1.GridControl = this.gridTakipTalepKodlari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Takip Talep Konusu Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // TALEP_ADI
            // 
            this.TALEP_ADI.Caption = "Talep Adý";
            this.TALEP_ADI.ColumnEdit = this.repositoryItemTextEdit11;
            this.TALEP_ADI.FieldName = "TALEP_ADI";
            this.TALEP_ADI.Name = "TALEP_ADI";
            this.TALEP_ADI.Visible = true;
            this.TALEP_ADI.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit11
            // 
            this.repositoryItemTextEdit11.AutoHeight = false;
            this.repositoryItemTextEdit11.Name = "repositoryItemTextEdit11";
            // 
            // FORM_TIPI
            // 
            this.FORM_TIPI.Caption = "Form Tipi";
            this.FORM_TIPI.ColumnEdit = this.repositoryItemTextEdit12;
            this.FORM_TIPI.FieldName = "FORM_TIPI";
            this.FORM_TIPI.Name = "FORM_TIPI";
            this.FORM_TIPI.Visible = true;
            this.FORM_TIPI.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit12
            // 
            this.repositoryItemTextEdit12.AutoHeight = false;
            this.repositoryItemTextEdit12.Name = "repositoryItemTextEdit12";
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
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Takip Talep Kodlarý";
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
            this.gridControlExtender1.GridControl = this.gridTakipTalepKodlari;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(406, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 20;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmTakipTalepKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 445);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelTakipTalepKodlari);
            this.Name = "frmTakipTalepKodlari";
            this.Text = "Takip Talep Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelTakipTalepKodlari)).EndInit();
            this.panelTakipTalepKodlari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTakipTalepKodlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTakipTalepKodlari;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTakipTalepKodlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn TALEP_ADI;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit11;
        private DevExpress.XtraGrid.Columns.GridColumn FORM_TIPI;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit12;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}