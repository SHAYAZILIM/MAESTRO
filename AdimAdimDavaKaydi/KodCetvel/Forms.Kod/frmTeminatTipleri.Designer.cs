namespace  AnaForm
{
    partial class frmTeminatTipleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTeminatTipleri));
            this.panelTeminatTipleri = new DevExpress.XtraEditors.PanelControl();
            this.gridTeminatTipleri = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit10 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.navigator = new DevExpress.XtraEditors.ControlNavigator();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelTeminatTipleri)).BeginInit();
            this.panelTeminatTipleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeminatTipleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTeminatTipleri
            // 
            this.panelTeminatTipleri.Controls.Add(this.gridTeminatTipleri);
            this.panelTeminatTipleri.Controls.Add(this.panelControl1);
            this.panelTeminatTipleri.Controls.Add(this.panelControl2);
            this.panelTeminatTipleri.Location = new System.Drawing.Point(12, 12);
            this.panelTeminatTipleri.Name = "panelTeminatTipleri";
            this.panelTeminatTipleri.Size = new System.Drawing.Size(750, 360);
            this.panelTeminatTipleri.TabIndex = 18;
            // 
            // gridTeminatTipleri
            // 
            this.gridTeminatTipleri.CustomButtonlarGorunmesin = false;
            this.gridTeminatTipleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTeminatTipleri.DoNotExtendEmbedNavigator = false;
            this.gridTeminatTipleri.FilterText = null;
            this.gridTeminatTipleri.FilterValue = null;
            this.gridTeminatTipleri.GridlerDuzenlenebilir = true;
            this.gridTeminatTipleri.GridsFilterControl = null;
            this.gridTeminatTipleri.Location = new System.Drawing.Point(2, 72);
            this.gridTeminatTipleri.MainView = this.gridView1;
            this.gridTeminatTipleri.MyGridStyle = null;
            this.gridTeminatTipleri.Name = "gridTeminatTipleri";
            this.gridTeminatTipleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit10});
            this.gridTeminatTipleri.ShowRowNumbers = false;
            this.gridTeminatTipleri.Size = new System.Drawing.Size(746, 286);
            this.gridTeminatTipleri.TabIndex = 5;
            this.gridTeminatTipleri.TemizleKaldirGorunsunmu = false;
            this.gridTeminatTipleri.UniqueId = "08869111-86d6-4c09-8bed-e3d8b378e4bd";
            this.gridTeminatTipleri.UseEmbeddedNavigator = true;
            this.gridTeminatTipleri.UseHyperDragDrop = false;
            this.gridTeminatTipleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TIP});
            this.gridView1.GridControl = this.gridTeminatTipleri;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Teminat Tipi Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // TIP
            // 
            this.TIP.Caption = "Teminat Tipi";
            this.TIP.ColumnEdit = this.repositoryItemTextEdit10;
            this.TIP.FieldName = "TIP";
            this.TIP.Name = "TIP";
            this.TIP.Visible = true;
            this.TIP.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit10
            // 
            this.repositoryItemTextEdit10.AutoHeight = false;
            this.repositoryItemTextEdit10.Name = "repositoryItemTextEdit10";
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
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Teminat Tipleri";
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
            this.navigator.NavigatableControl = this.gridTeminatTipleri;
            this.navigator.Size = new System.Drawing.Size(364, 33);
            this.navigator.TabIndex = 8;
            this.navigator.Text = "controlNavigator1";
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridTeminatTipleri;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(546, 377);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 19;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmTeminatTipleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 419);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelTeminatTipleri);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTeminatTipleri";
            this.Text = "Teminat Tipleri";
            ((System.ComponentModel.ISupportInitialize)(this.panelTeminatTipleri)).EndInit();
            this.panelTeminatTipleri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTeminatTipleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTeminatTipleri;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTeminatTipleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.ControlNavigator navigator;
        private DevExpress.XtraGrid.Columns.GridColumn TIP;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit10;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
    }
}