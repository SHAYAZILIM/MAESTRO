namespace  AnaForm
{
    partial class frmMahsupTip
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
            this.panelMahsupTip = new DevExpress.XtraEditors.PanelControl();
            this.gridMahsupTip = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MAHSUP_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelMahsupTip)).BeginInit();
            this.panelMahsupTip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMahsupTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMahsupTip
            // 
            this.panelMahsupTip.Controls.Add(this.gridMahsupTip);
            this.panelMahsupTip.Controls.Add(this.panelControl1);
            this.panelMahsupTip.Controls.Add(this.panelControl2);
            this.panelMahsupTip.Location = new System.Drawing.Point(12, 12);
            this.panelMahsupTip.Name = "panelMahsupTip";
            this.panelMahsupTip.Size = new System.Drawing.Size(750, 360);
            this.panelMahsupTip.TabIndex = 10;
            // 
            // gridMahsupTip
            // 
            this.gridMahsupTip.CustomButtonlarGorunmesin = false;
            this.gridMahsupTip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMahsupTip.DoNotExtendEmbedNavigator = false;
            this.gridMahsupTip.FilterText = null;
            this.gridMahsupTip.FilterValue = null;
            this.gridMahsupTip.GridlerDuzenlenebilir = true;
            this.gridMahsupTip.GridsFilterControl = null;
            this.gridMahsupTip.Location = new System.Drawing.Point(2, 72);
            this.gridMahsupTip.MainView = this.gridView1;
            this.gridMahsupTip.MyGridStyle = null;
            this.gridMahsupTip.Name = "gridMahsupTip";
            this.gridMahsupTip.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox3});
            this.gridMahsupTip.ShowRowNumbers = false;
            this.gridMahsupTip.Size = new System.Drawing.Size(746, 286);
            this.gridMahsupTip.TabIndex = 5;
            this.gridMahsupTip.TemizleKaldirGorunsunmu = false;
            this.gridMahsupTip.UniqueId = "841ea7ac-e722-4e3f-ad41-da91357cfbb3";
            this.gridMahsupTip.UseEmbeddedNavigator = true;
            this.gridMahsupTip.UseHyperDragDrop = false;
            this.gridMahsupTip.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MAHSUP_TIP});
            this.gridView1.GridControl = this.gridMahsupTip;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Mahsup Tipi Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // MAHSUP_TIP
            // 
            this.MAHSUP_TIP.Caption = "Mahsup Tip";
            this.MAHSUP_TIP.ColumnEdit = this.repositoryItemComboBox3;
            this.MAHSUP_TIP.FieldName = "MAHSUP_TIP";
            this.MAHSUP_TIP.Name = "MAHSUP_TIP";
            this.MAHSUP_TIP.Visible = true;
            this.MAHSUP_TIP.VisibleIndex = 0;
            // 
            // repositoryItemComboBox3
            // 
            this.repositoryItemComboBox3.AutoHeight = false;
            this.repositoryItemComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox3.Name = "repositoryItemComboBox3";
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
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mahsup Tip Kodlarý";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
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
            this.gridControlExtender1.GridControl = this.gridMahsupTip;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(445, 377);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 11;
            this.gridControlExtender1.Text = "gridControlExtender1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(23, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmMahsupTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 406);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelMahsupTip);
            this.Name = "frmMahsupTip";
            this.Text = "Mahsup Tip Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelMahsupTip)).EndInit();
            this.panelMahsupTip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMahsupTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelMahsupTip;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridMahsupTip;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn MAHSUP_TIP;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox3;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}