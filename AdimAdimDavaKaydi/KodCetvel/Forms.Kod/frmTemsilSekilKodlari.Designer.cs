namespace  AnaForm
{
    partial class frmTemsilSekilKodlari
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
            this.panelTahsilDurumKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridTemsilSekilKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TEMSIL_SEKIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit34 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTahsilDurumKodlar)).BeginInit();
            this.panelTahsilDurumKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTemsilSekilKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTahsilDurumKodlar
            // 
            this.panelTahsilDurumKodlar.Controls.Add(this.gridTemsilSekilKodlar);
            this.panelTahsilDurumKodlar.Controls.Add(this.panelControl1);
            this.panelTahsilDurumKodlar.Controls.Add(this.panelControl2);
            this.panelTahsilDurumKodlar.Location = new System.Drawing.Point(15, 28);
            this.panelTahsilDurumKodlar.Name = "panelTahsilDurumKodlar";
            this.panelTahsilDurumKodlar.Size = new System.Drawing.Size(740, 368);
            this.panelTahsilDurumKodlar.TabIndex = 33;
            // 
            // gridTemsilSekilKodlar
            // 
            this.gridTemsilSekilKodlar.CustomButtonlarGorunmesin = false;
            this.gridTemsilSekilKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTemsilSekilKodlar.DoNotExtendEmbedNavigator = false;
            this.gridTemsilSekilKodlar.FilterText = null;
            this.gridTemsilSekilKodlar.FilterValue = null;
            this.gridTemsilSekilKodlar.GridlerDuzenlenebilir = true;
            this.gridTemsilSekilKodlar.GridsFilterControl = null;
            this.gridTemsilSekilKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridTemsilSekilKodlar.MainView = this.gridView1;
            this.gridTemsilSekilKodlar.MyGridStyle = null;
            this.gridTemsilSekilKodlar.Name = "gridTemsilSekilKodlar";
            this.gridTemsilSekilKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit34});
            this.gridTemsilSekilKodlar.ShowRowNumbers = false;
            this.gridTemsilSekilKodlar.Size = new System.Drawing.Size(736, 294);
            this.gridTemsilSekilKodlar.TabIndex = 5;
            this.gridTemsilSekilKodlar.TemizleKaldirGorunsunmu = false;
            this.gridTemsilSekilKodlar.UniqueId = "f6f701ba-a7fa-4d19-bf3d-ff0b33513e92";
            this.gridTemsilSekilKodlar.UseEmbeddedNavigator = true;
            this.gridTemsilSekilKodlar.UseHyperDragDrop = false;
            this.gridTemsilSekilKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TEMSIL_SEKIL});
            this.gridView1.GridControl = this.gridTemsilSekilKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Temsil Þekli Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // TEMSIL_SEKIL
            // 
            this.TEMSIL_SEKIL.Caption = "Temsil Þekli";
            this.TEMSIL_SEKIL.ColumnEdit = this.repositoryItemTextEdit34;
            this.TEMSIL_SEKIL.FieldName = "TEMSIL_SEKIL";
            this.TEMSIL_SEKIL.Name = "TEMSIL_SEKIL";
            this.TEMSIL_SEKIL.Visible = true;
            this.TEMSIL_SEKIL.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit34
            // 
            this.repositoryItemTextEdit34.AutoHeight = false;
            this.repositoryItemTextEdit34.Name = "repositoryItemTextEdit34";
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
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Temsil Þekil Kodlarý";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.sBtnKaydet);
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
            this.gridControlExtender1.GridControl = this.gridTemsilSekilKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(736, 294);
            this.gridControlExtender1.Location = new System.Drawing.Point(490, 402);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 34;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(43, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 7;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // frmTemsilSekilKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 448);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelTahsilDurumKodlar);
            this.Name = "frmTemsilSekilKodlari";
            this.Text = "Temsil Þekil Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelTahsilDurumKodlar)).EndInit();
            this.panelTahsilDurumKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTemsilSekilKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTahsilDurumKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTemsilSekilKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn TEMSIL_SEKIL;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit34;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}