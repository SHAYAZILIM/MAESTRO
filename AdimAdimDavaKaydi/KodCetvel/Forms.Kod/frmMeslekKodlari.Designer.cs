namespace  AnaForm
{
    partial class frmMeslekKodlari
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
            this.panelMeslekKodlari = new DevExpress.XtraEditors.PanelControl();
            this.gridMeslekKodlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MESLEK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit32 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelMeslekKodlari)).BeginInit();
            this.panelMeslekKodlari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMeslekKodlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMeslekKodlari
            // 
            this.panelMeslekKodlari.Controls.Add(this.gridMeslekKodlari);
            this.panelMeslekKodlari.Controls.Add(this.panelControl1);
            this.panelMeslekKodlari.Controls.Add(this.panelControl2);
            this.panelMeslekKodlari.Location = new System.Drawing.Point(2, 12);
            this.panelMeslekKodlari.Name = "panelMeslekKodlari";
            this.panelMeslekKodlari.Size = new System.Drawing.Size(740, 368);
            this.panelMeslekKodlari.TabIndex = 31;
            // 
            // gridMeslekKodlari
            // 
            this.gridMeslekKodlari.CustomButtonlarGorunmesin = false;
            this.gridMeslekKodlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMeslekKodlari.DoNotExtendEmbedNavigator = false;
            this.gridMeslekKodlari.FilterText = null;
            this.gridMeslekKodlari.FilterValue = null;
            this.gridMeslekKodlari.GridlerDuzenlenebilir = true;
            this.gridMeslekKodlari.GridsFilterControl = null;
            this.gridMeslekKodlari.Location = new System.Drawing.Point(2, 72);
            this.gridMeslekKodlari.MainView = this.gridView1;
            this.gridMeslekKodlari.MyGridStyle = null;
            this.gridMeslekKodlari.Name = "gridMeslekKodlari";
            this.gridMeslekKodlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit32});
            this.gridMeslekKodlari.ShowRowNumbers = false;
            this.gridMeslekKodlari.Size = new System.Drawing.Size(736, 294);
            this.gridMeslekKodlari.TabIndex = 5;
            this.gridMeslekKodlari.TemizleKaldirGorunsunmu = false;
            this.gridMeslekKodlari.UniqueId = "f9da232d-7fad-4fc4-8099-86a76984241d";
            this.gridMeslekKodlari.UseEmbeddedNavigator = true;
            this.gridMeslekKodlari.UseHyperDragDrop = false;
            this.gridMeslekKodlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MESLEK});
            this.gridView1.GridControl = this.gridMeslekKodlari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Meslek Kodlarý Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // MESLEK
            // 
            this.MESLEK.Caption = "Meslek Kodlarý";
            this.MESLEK.ColumnEdit = this.repositoryItemTextEdit32;
            this.MESLEK.FieldName = "MESLEK";
            this.MESLEK.Name = "MESLEK";
            this.MESLEK.Visible = true;
            this.MESLEK.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit32
            // 
            this.repositoryItemTextEdit32.AutoHeight = false;
            this.repositoryItemTextEdit32.Name = "repositoryItemTextEdit32";
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
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Meslek Kodlarý";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(736, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridMeslekKodlari;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(736, 294);
            this.gridControlExtender1.Location = new System.Drawing.Point(419, 387);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 32;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(50, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmMeslekKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 433);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelMeslekKodlari);
            this.Name = "frmMeslekKodlari";
            this.Text = "Meslek Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelMeslekKodlari)).EndInit();
            this.panelMeslekKodlari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMeslekKodlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelMeslekKodlari;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridMeslekKodlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn MESLEK;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit32;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}