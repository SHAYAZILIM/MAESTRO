namespace  AnaForm
{
    partial class frmTebligatAlimSekli
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
            this.panelTebligatAlimSekli = new DevExpress.XtraEditors.PanelControl();
            this.gridTebligatAlimSekli = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SEKIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit25 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelTebligatAlimSekli)).BeginInit();
            this.panelTebligatAlimSekli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTebligatAlimSekli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTebligatAlimSekli
            // 
            this.panelTebligatAlimSekli.Controls.Add(this.gridTebligatAlimSekli);
            this.panelTebligatAlimSekli.Controls.Add(this.panelControl1);
            this.panelTebligatAlimSekli.Controls.Add(this.panelControl2);
            this.panelTebligatAlimSekli.Location = new System.Drawing.Point(2, 12);
            this.panelTebligatAlimSekli.Name = "panelTebligatAlimSekli";
            this.panelTebligatAlimSekli.Size = new System.Drawing.Size(750, 360);
            this.panelTebligatAlimSekli.TabIndex = 19;
            // 
            // gridTebligatAlimSekli
            // 
            this.gridTebligatAlimSekli.CustomButtonlarGorunmesin = false;
            this.gridTebligatAlimSekli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTebligatAlimSekli.DoNotExtendEmbedNavigator = false;
            this.gridTebligatAlimSekli.FilterText = null;
            this.gridTebligatAlimSekli.FilterValue = null;
            this.gridTebligatAlimSekli.GridlerDuzenlenebilir = true;
            this.gridTebligatAlimSekli.GridsFilterControl = null;
            this.gridTebligatAlimSekli.Location = new System.Drawing.Point(2, 72);
            this.gridTebligatAlimSekli.MainView = this.gridView1;
            this.gridTebligatAlimSekli.MyGridStyle = null;
            this.gridTebligatAlimSekli.Name = "gridTebligatAlimSekli";
            this.gridTebligatAlimSekli.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit25});
            this.gridTebligatAlimSekli.ShowRowNumbers = false;
            this.gridTebligatAlimSekli.Size = new System.Drawing.Size(746, 286);
            this.gridTebligatAlimSekli.TabIndex = 5;
            this.gridTebligatAlimSekli.TemizleKaldirGorunsunmu = false;
            this.gridTebligatAlimSekli.UniqueId = "50d960cb-4b25-4e8c-9321-edbea96cb343";
            this.gridTebligatAlimSekli.UseEmbeddedNavigator = true;
            this.gridTebligatAlimSekli.UseHyperDragDrop = false;
            this.gridTebligatAlimSekli.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SEKIL});
            this.gridView1.GridControl = this.gridTebligatAlimSekli;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Tebligat Alým Þekli Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // SEKIL
            // 
            this.SEKIL.Caption = "Tebligat Alým Þekli";
            this.SEKIL.ColumnEdit = this.repositoryItemTextEdit25;
            this.SEKIL.FieldName = "SEKIL";
            this.SEKIL.Name = "SEKIL";
            this.SEKIL.Visible = true;
            this.SEKIL.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit25
            // 
            this.repositoryItemTextEdit25.AutoHeight = false;
            this.repositoryItemTextEdit25.Name = "repositoryItemTextEdit25";
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
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tebligat Alým Þekli";
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
            this.sBtnKaydet.Location = new System.Drawing.Point(38, 10);
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
            this.gridControlExtender1.GridControl = this.gridTebligatAlimSekli;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(455, 389);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 20;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmTebligatAlimSekli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 462);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelTebligatAlimSekli);
            this.Name = "frmTebligatAlimSekli";
            this.Text = "Tebligat Alým Þekli";
            ((System.ComponentModel.ISupportInitialize)(this.panelTebligatAlimSekli)).EndInit();
            this.panelTebligatAlimSekli.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTebligatAlimSekli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTebligatAlimSekli;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTebligatAlimSekli;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn SEKIL;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit25;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}