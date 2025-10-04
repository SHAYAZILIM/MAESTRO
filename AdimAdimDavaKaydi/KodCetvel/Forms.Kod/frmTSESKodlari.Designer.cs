namespace  AnaForm
{
    partial class frmTSESKodlari
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
            this.panelTemsilSonaErmeKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridTemsilSonaErmeSebeb = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SEBEP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit34 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTemsilSonaErmeKodlar)).BeginInit();
            this.panelTemsilSonaErmeKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTemsilSonaErmeSebeb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTemsilSonaErmeKodlar
            // 
            this.panelTemsilSonaErmeKodlar.Controls.Add(this.gridTemsilSonaErmeSebeb);
            this.panelTemsilSonaErmeKodlar.Controls.Add(this.panelControl1);
            this.panelTemsilSonaErmeKodlar.Controls.Add(this.panelControl2);
            this.panelTemsilSonaErmeKodlar.Location = new System.Drawing.Point(12, 12);
            this.panelTemsilSonaErmeKodlar.Name = "panelTemsilSonaErmeKodlar";
            this.panelTemsilSonaErmeKodlar.Size = new System.Drawing.Size(740, 368);
            this.panelTemsilSonaErmeKodlar.TabIndex = 33;
            // 
            // gridTemsilSonaErmeSebeb
            // 
            this.gridTemsilSonaErmeSebeb.CustomButtonlarGorunmesin = false;
            this.gridTemsilSonaErmeSebeb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTemsilSonaErmeSebeb.DoNotExtendEmbedNavigator = false;
            this.gridTemsilSonaErmeSebeb.FilterText = null;
            this.gridTemsilSonaErmeSebeb.FilterValue = null;
            this.gridTemsilSonaErmeSebeb.GridlerDuzenlenebilir = true;
            this.gridTemsilSonaErmeSebeb.GridsFilterControl = null;
            this.gridTemsilSonaErmeSebeb.Location = new System.Drawing.Point(2, 72);
            this.gridTemsilSonaErmeSebeb.MainView = this.gridView1;
            this.gridTemsilSonaErmeSebeb.MyGridStyle = null;
            this.gridTemsilSonaErmeSebeb.Name = "gridTemsilSonaErmeSebeb";
            this.gridTemsilSonaErmeSebeb.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit34});
            this.gridTemsilSonaErmeSebeb.ShowRowNumbers = false;
            this.gridTemsilSonaErmeSebeb.Size = new System.Drawing.Size(736, 294);
            this.gridTemsilSonaErmeSebeb.TabIndex = 5;
            this.gridTemsilSonaErmeSebeb.TemizleKaldirGorunsunmu = false;
            this.gridTemsilSonaErmeSebeb.UniqueId = "aaf65485-6c5d-4c23-a8d5-6460e4e0dff5";
            this.gridTemsilSonaErmeSebeb.UseEmbeddedNavigator = true;
            this.gridTemsilSonaErmeSebeb.UseHyperDragDrop = false;
            this.gridTemsilSonaErmeSebeb.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SEBEP});
            this.gridView1.GridControl = this.gridTemsilSonaErmeSebeb;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Temsil Sona Erme Sebebi Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // SEBEP
            // 
            this.SEBEP.Caption = "Temsil Sona Erme Sebebi";
            this.SEBEP.ColumnEdit = this.repositoryItemTextEdit34;
            this.SEBEP.FieldName = "SEBEP";
            this.SEBEP.Name = "SEBEP";
            this.SEBEP.Visible = true;
            this.SEBEP.VisibleIndex = 0;
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
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Temsil Sona Erme Sebepleri";
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
            this.gridControlExtender1.GridControl = this.gridTemsilSonaErmeSebeb;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(736, 294);
            this.gridControlExtender1.Location = new System.Drawing.Point(544, 399);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 34;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(90, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 7;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // frmTSESKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 453);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelTemsilSonaErmeKodlar);
            this.Name = "frmTSESKodlari";
            this.Text = "Temsil Sona Erme Sebepleri";
            ((System.ComponentModel.ISupportInitialize)(this.panelTemsilSonaErmeKodlar)).EndInit();
            this.panelTemsilSonaErmeKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTemsilSonaErmeSebeb)).EndInit();
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

        private DevExpress.XtraEditors.PanelControl panelTemsilSonaErmeKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTemsilSonaErmeSebeb;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn SEBEP;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit34;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}