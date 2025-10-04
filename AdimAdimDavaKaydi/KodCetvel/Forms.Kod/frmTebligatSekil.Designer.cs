namespace  AnaForm
{
    partial class frmTebligatSekil
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
            this.panelTebligatSekli = new DevExpress.XtraEditors.PanelControl();
            this.gridTebligatSekli = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.KOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit31 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.SEKIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox11 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTebligatSekli)).BeginInit();
            this.panelTebligatSekli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTebligatSekli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTebligatSekli
            // 
            this.panelTebligatSekli.Controls.Add(this.gridTebligatSekli);
            this.panelTebligatSekli.Controls.Add(this.panelControl1);
            this.panelTebligatSekli.Controls.Add(this.panelControl2);
            this.panelTebligatSekli.Location = new System.Drawing.Point(12, 26);
            this.panelTebligatSekli.Name = "panelTebligatSekli";
            this.panelTebligatSekli.Size = new System.Drawing.Size(750, 360);
            this.panelTebligatSekli.TabIndex = 22;
            // 
            // gridTebligatSekli
            // 
            this.gridTebligatSekli.CustomButtonlarGorunmesin = false;
            this.gridTebligatSekli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTebligatSekli.DoNotExtendEmbedNavigator = false;
            this.gridTebligatSekli.FilterText = null;
            this.gridTebligatSekli.FilterValue = null;
            this.gridTebligatSekli.GridlerDuzenlenebilir = true;
            this.gridTebligatSekli.GridsFilterControl = null;
            this.gridTebligatSekli.Location = new System.Drawing.Point(2, 72);
            this.gridTebligatSekli.MainView = this.gridView1;
            this.gridTebligatSekli.MyGridStyle = null;
            this.gridTebligatSekli.Name = "gridTebligatSekli";
            this.gridTebligatSekli.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit31,
            this.repositoryItemComboBox11});
            this.gridTebligatSekli.ShowRowNumbers = false;
            this.gridTebligatSekli.Size = new System.Drawing.Size(746, 286);
            this.gridTebligatSekli.TabIndex = 5;
            this.gridTebligatSekli.TemizleKaldirGorunsunmu = false;
            this.gridTebligatSekli.UniqueId = "abd0c367-0990-4ceb-9346-3fd310cb2c87";
            this.gridTebligatSekli.UseEmbeddedNavigator = true;
            this.gridTebligatSekli.UseHyperDragDrop = false;
            this.gridTebligatSekli.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.KOD,
            this.SEKIL});
            this.gridView1.GridControl = this.gridTebligatSekli;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Tebligat Þekli Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // KOD
            // 
            this.KOD.Caption = "Tebligat Þekli Kod";
            this.KOD.ColumnEdit = this.repositoryItemTextEdit31;
            this.KOD.FieldName = "KOD";
            this.KOD.Name = "KOD";
            this.KOD.Visible = true;
            this.KOD.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit31
            // 
            this.repositoryItemTextEdit31.AutoHeight = false;
            this.repositoryItemTextEdit31.Name = "repositoryItemTextEdit31";
            // 
            // SEKIL
            // 
            this.SEKIL.Caption = "Tebligat Þekli";
            this.SEKIL.ColumnEdit = this.repositoryItemComboBox11;
            this.SEKIL.FieldName = "SEKIL";
            this.SEKIL.Name = "SEKIL";
            this.SEKIL.Visible = true;
            this.SEKIL.VisibleIndex = 1;
            // 
            // repositoryItemComboBox11
            // 
            this.repositoryItemComboBox11.AutoHeight = false;
            this.repositoryItemComboBox11.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox11.Name = "repositoryItemComboBox11";
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
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tebligat Þekli";
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
            this.gridControlExtender1.ForeColor = System.Drawing.Color.Transparent;
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridTebligatSekli;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(486, 393);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 23;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(10, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 7;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // frmTebligatSekil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 457);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelTebligatSekli);
            this.Name = "frmTebligatSekil";
            this.Text = "Tebligat Þekli";
            ((System.ComponentModel.ISupportInitialize)(this.panelTebligatSekli)).EndInit();
            this.panelTebligatSekli.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTebligatSekli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTebligatSekli;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTebligatSekli;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn KOD;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit31;
        private DevExpress.XtraGrid.Columns.GridColumn SEKIL;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox11;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}