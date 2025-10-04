namespace  AnaForm
{
    partial class frmSureOzelKodlari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSureOzelKodlari));
            this.panelSureOzelKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridSureOzelKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SURE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit52 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.navigator = new DevExpress.XtraEditors.ControlNavigator();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelSureOzelKodlar)).BeginInit();
            this.panelSureOzelKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSureOzelKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSureOzelKodlar
            // 
            this.panelSureOzelKodlar.Controls.Add(this.gridSureOzelKodlar);
            this.panelSureOzelKodlar.Controls.Add(this.panelControl1);
            this.panelSureOzelKodlar.Controls.Add(this.panelControl2);
            this.panelSureOzelKodlar.Location = new System.Drawing.Point(12, 12);
            this.panelSureOzelKodlar.Name = "panelSureOzelKodlar";
            this.panelSureOzelKodlar.Size = new System.Drawing.Size(750, 360);
            this.panelSureOzelKodlar.TabIndex = 41;
            // 
            // gridSureOzelKodlar
            // 
            this.gridSureOzelKodlar.CustomButtonlarGorunmesin = false;
            this.gridSureOzelKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSureOzelKodlar.DoNotExtendEmbedNavigator = false;
            this.gridSureOzelKodlar.FilterText = null;
            this.gridSureOzelKodlar.FilterValue = null;
            this.gridSureOzelKodlar.GridlerDuzenlenebilir = true;
            this.gridSureOzelKodlar.GridsFilterControl = null;
            this.gridSureOzelKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridSureOzelKodlar.MainView = this.gridView1;
            this.gridSureOzelKodlar.MyGridStyle = null;
            this.gridSureOzelKodlar.Name = "gridSureOzelKodlar";
            this.gridSureOzelKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit52});
            this.gridSureOzelKodlar.ShowRowNumbers = false;
            this.gridSureOzelKodlar.Size = new System.Drawing.Size(746, 286);
            this.gridSureOzelKodlar.TabIndex = 5;
            this.gridSureOzelKodlar.TemizleKaldirGorunsunmu = false;
            this.gridSureOzelKodlar.UniqueId = "086ccfb2-c4ef-4dc1-9e7d-53643990f2a1";
            this.gridSureOzelKodlar.UseEmbeddedNavigator = true;
            this.gridSureOzelKodlar.UseHyperDragDrop = false;
            this.gridSureOzelKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SURE});
            this.gridView1.GridControl = this.gridSureOzelKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Süre Özel Kodu";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // SURE
            // 
            this.SURE.Caption = "Süre";
            this.SURE.ColumnEdit = this.repositoryItemTextEdit52;
            this.SURE.FieldName = "SURE";
            this.SURE.Name = "SURE";
            this.SURE.Visible = true;
            this.SURE.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit52
            // 
            this.repositoryItemTextEdit52.AutoHeight = false;
            this.repositoryItemTextEdit52.Name = "repositoryItemTextEdit52";
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
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Süre Özel Kodlarý";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.navigator);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(746, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // navigator
            // 
            this.navigator.Location = new System.Drawing.Point(5, 5);
            this.navigator.Name = "navigator";
            this.navigator.NavigatableControl = this.gridSureOzelKodlar;
            this.navigator.Size = new System.Drawing.Size(364, 33);
            this.navigator.TabIndex = 8;
            this.navigator.Text = "controlNavigator1";
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridSureOzelKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(405, 391);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 42;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmSureOzelKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 460);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelSureOzelKodlar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSureOzelKodlari";
            this.Text = "Süre Özel Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelSureOzelKodlar)).EndInit();
            this.panelSureOzelKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSureOzelKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelSureOzelKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridSureOzelKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.ControlNavigator navigator;
        private DevExpress.XtraGrid.Columns.GridColumn SURE;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit52;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
    }
}