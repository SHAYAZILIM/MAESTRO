namespace  AnaForm
{
    partial class frmTebligatAltTur
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
            this.panelTebligatAltTur = new DevExpress.XtraEditors.PanelControl();
            this.gridTebligatAltTur = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ANA_TUR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rCb_AnaTur = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ALT_TUR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit26 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTebligatAltTur)).BeginInit();
            this.panelTebligatAltTur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTebligatAltTur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_AnaTur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTebligatAltTur
            // 
            this.panelTebligatAltTur.Controls.Add(this.gridTebligatAltTur);
            this.panelTebligatAltTur.Controls.Add(this.panelControl1);
            this.panelTebligatAltTur.Controls.Add(this.panelControl2);
            this.panelTebligatAltTur.Location = new System.Drawing.Point(10, 53);
            this.panelTebligatAltTur.Name = "panelTebligatAltTur";
            this.panelTebligatAltTur.Size = new System.Drawing.Size(750, 360);
            this.panelTebligatAltTur.TabIndex = 20;
            // 
            // gridTebligatAltTur
            // 
            this.gridTebligatAltTur.CustomButtonlarGorunmesin = false;
            this.gridTebligatAltTur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTebligatAltTur.DoNotExtendEmbedNavigator = false;
            this.gridTebligatAltTur.FilterText = null;
            this.gridTebligatAltTur.FilterValue = null;
            this.gridTebligatAltTur.GridlerDuzenlenebilir = true;
            this.gridTebligatAltTur.GridsFilterControl = null;
            this.gridTebligatAltTur.Location = new System.Drawing.Point(2, 72);
            this.gridTebligatAltTur.MainView = this.gridView1;
            this.gridTebligatAltTur.MyGridStyle = null;
            this.gridTebligatAltTur.Name = "gridTebligatAltTur";
            this.gridTebligatAltTur.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit26,
            this.rCb_AnaTur});
            this.gridTebligatAltTur.ShowRowNumbers = false;
            this.gridTebligatAltTur.Size = new System.Drawing.Size(746, 286);
            this.gridTebligatAltTur.TabIndex = 5;
            this.gridTebligatAltTur.TemizleKaldirGorunsunmu = false;
            this.gridTebligatAltTur.UniqueId = "918a8e81-2030-4863-9e8b-f7b2d62d2314";
            this.gridTebligatAltTur.UseEmbeddedNavigator = true;
            this.gridTebligatAltTur.UseHyperDragDrop = false;
            this.gridTebligatAltTur.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ANA_TUR,
            this.ALT_TUR});
            this.gridView1.GridControl = this.gridTebligatAltTur;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Tebligat Alt Türü Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // ANA_TUR
            // 
            this.ANA_TUR.Caption = "Tebligat Ana Tür";
            this.ANA_TUR.ColumnEdit = this.rCb_AnaTur;
            this.ANA_TUR.FieldName = "ANA_TUR";
            this.ANA_TUR.Name = "ANA_TUR";
            this.ANA_TUR.Visible = true;
            this.ANA_TUR.VisibleIndex = 0;
            // 
            // rCb_AnaTur
            // 
            this.rCb_AnaTur.AutoHeight = false;
            this.rCb_AnaTur.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_AnaTur.Name = "rCb_AnaTur";
            // 
            // ALT_TUR
            // 
            this.ALT_TUR.Caption = "Tebligat Alt Tür";
            this.ALT_TUR.ColumnEdit = this.repositoryItemTextEdit26;
            this.ALT_TUR.FieldName = "ALT_TUR";
            this.ALT_TUR.Name = "ALT_TUR";
            this.ALT_TUR.Visible = true;
            this.ALT_TUR.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit26
            // 
            this.repositoryItemTextEdit26.AutoHeight = false;
            this.repositoryItemTextEdit26.Name = "repositoryItemTextEdit26";
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
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tebligat Alt Tür";
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
            this.gridControlExtender1.GridControl = this.gridTebligatAltTur;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(469, 420);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 21;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(21, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 7;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // frmTebligatAltTur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 466);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelTebligatAltTur);
            this.Name = "frmTebligatAltTur";
            this.Text = "Tebligat Alt Tür";
            ((System.ComponentModel.ISupportInitialize)(this.panelTebligatAltTur)).EndInit();
            this.panelTebligatAltTur.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTebligatAltTur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_AnaTur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTebligatAltTur;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTebligatAltTur;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn ANA_TUR;
        private DevExpress.XtraGrid.Columns.GridColumn ALT_TUR;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit26;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_AnaTur;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}