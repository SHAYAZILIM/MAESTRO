namespace  AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    partial class frmSozlesmeTip
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
            this.panelSozlesmeTipleri = new DevExpress.XtraEditors.PanelControl();
            this.gridSozlesmeTipleri = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemComboBox9 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelSozlesmeTipleri)).BeginInit();
            this.panelSozlesmeTipleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSozlesmeTipleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSozlesmeTipleri
            // 
            this.panelSozlesmeTipleri.Controls.Add(this.gridSozlesmeTipleri);
            this.panelSozlesmeTipleri.Controls.Add(this.panelControl1);
            this.panelSozlesmeTipleri.Controls.Add(this.panelControl2);
            this.panelSozlesmeTipleri.Location = new System.Drawing.Point(3, 1);
            this.panelSozlesmeTipleri.Name = "panelSozlesmeTipleri";
            this.panelSozlesmeTipleri.Size = new System.Drawing.Size(750, 360);
            this.panelSozlesmeTipleri.TabIndex = 18;
            // 
            // gridSozlesmeTipleri
            // 
            this.gridSozlesmeTipleri.CustomButtonlarGorunmesin = false;
            this.gridSozlesmeTipleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSozlesmeTipleri.DoNotExtendEmbedNavigator = false;
            this.gridSozlesmeTipleri.FilterText = null;
            this.gridSozlesmeTipleri.FilterValue = null;
            this.gridSozlesmeTipleri.GridlerDuzenlenebilir = true;
            this.gridSozlesmeTipleri.GridsFilterControl = null;
            this.gridSozlesmeTipleri.Location = new System.Drawing.Point(2, 72);
            this.gridSozlesmeTipleri.MainView = this.gridView1;
            this.gridSozlesmeTipleri.MyGridStyle = null;
            this.gridSozlesmeTipleri.Name = "gridSozlesmeTipleri";
            this.gridSozlesmeTipleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox9,
            this.repositoryItemTextEdit1});
            this.gridSozlesmeTipleri.ShowRowNumbers = false;
            this.gridSozlesmeTipleri.Size = new System.Drawing.Size(746, 286);
            this.gridSozlesmeTipleri.TabIndex = 5;
            this.gridSozlesmeTipleri.TemizleKaldirGorunsunmu = false;
            this.gridSozlesmeTipleri.UniqueId = "c09b492d-ca30-46e6-96a2-8b6a4e62d3a2";
            this.gridSozlesmeTipleri.UseEmbeddedNavigator = true;
            this.gridSozlesmeTipleri.UseHyperDragDrop = false;
            this.gridSozlesmeTipleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TIP});
            this.gridView1.GridControl = this.gridSozlesmeTipleri;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Sözleþme Tipi Ekleyin";
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
            this.TIP.Caption = "Sözleþme TÝpi";
            this.TIP.ColumnEdit = this.repositoryItemTextEdit1;
            this.TIP.FieldName = "TIP";
            this.TIP.Name = "TIP";
            this.TIP.Visible = true;
            this.TIP.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemComboBox9
            // 
            this.repositoryItemComboBox9.AutoHeight = false;
            this.repositoryItemComboBox9.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox9.Name = "repositoryItemComboBox9";
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
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sözleþme Tipleri";
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
            this.sBtnKaydet.Location = new System.Drawing.Point(26, 10);
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
            this.gridControlExtender1.GridControl = this.gridSozlesmeTipleri;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(404, 366);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 19;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmSozlesmeTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 413);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelSozlesmeTipleri);
            this.Name = "frmSozlesmeTip";
            this.Text = "Sözleþme Tipleri";
            ((System.ComponentModel.ISupportInitialize)(this.panelSozlesmeTipleri)).EndInit();
            this.panelSozlesmeTipleri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSozlesmeTipleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelSozlesmeTipleri;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridSozlesmeTipleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn TIP;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox9;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}