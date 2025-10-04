namespace  AnaForm
{
    partial class frmTebligatTeslimYeri
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
            this.panelTebligatTeslimYeri = new DevExpress.XtraEditors.PanelControl();
            this.gridTebligatTeslimYeri = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.YER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit25 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTebligatTeslimYeri)).BeginInit();
            this.panelTebligatTeslimYeri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTebligatTeslimYeri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTebligatTeslimYeri
            // 
            this.panelTebligatTeslimYeri.Controls.Add(this.gridTebligatTeslimYeri);
            this.panelTebligatTeslimYeri.Controls.Add(this.panelControl1);
            this.panelTebligatTeslimYeri.Controls.Add(this.panelControl2);
            this.panelTebligatTeslimYeri.Location = new System.Drawing.Point(6, 12);
            this.panelTebligatTeslimYeri.Name = "panelTebligatTeslimYeri";
            this.panelTebligatTeslimYeri.Size = new System.Drawing.Size(750, 360);
            this.panelTebligatTeslimYeri.TabIndex = 18;
            // 
            // gridTebligatTeslimYeri
            // 
            this.gridTebligatTeslimYeri.CustomButtonlarGorunmesin = false;
            this.gridTebligatTeslimYeri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTebligatTeslimYeri.DoNotExtendEmbedNavigator = false;
            this.gridTebligatTeslimYeri.FilterText = null;
            this.gridTebligatTeslimYeri.FilterValue = null;
            this.gridTebligatTeslimYeri.GridlerDuzenlenebilir = true;
            this.gridTebligatTeslimYeri.GridsFilterControl = null;
            this.gridTebligatTeslimYeri.Location = new System.Drawing.Point(2, 72);
            this.gridTebligatTeslimYeri.MainView = this.gridView1;
            this.gridTebligatTeslimYeri.MyGridStyle = null;
            this.gridTebligatTeslimYeri.Name = "gridTebligatTeslimYeri";
            this.gridTebligatTeslimYeri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit25});
            this.gridTebligatTeslimYeri.ShowRowNumbers = false;
            this.gridTebligatTeslimYeri.Size = new System.Drawing.Size(746, 286);
            this.gridTebligatTeslimYeri.TabIndex = 5;
            this.gridTebligatTeslimYeri.TemizleKaldirGorunsunmu = false;
            this.gridTebligatTeslimYeri.UniqueId = "33144d38-7c3a-4656-8617-141524f9cf71";
            this.gridTebligatTeslimYeri.UseEmbeddedNavigator = true;
            this.gridTebligatTeslimYeri.UseHyperDragDrop = false;
            this.gridTebligatTeslimYeri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.YER});
            this.gridView1.GridControl = this.gridTebligatTeslimYeri;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Teslim Yeri Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // YER
            // 
            this.YER.Caption = "Tebliðat Teslim Yeri";
            this.YER.ColumnEdit = this.repositoryItemTextEdit25;
            this.YER.FieldName = "YER";
            this.YER.Name = "YER";
            this.YER.Visible = true;
            this.YER.VisibleIndex = 0;
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
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tebliðat Teslim Yeri";
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
            this.gridControlExtender1.GridControl = this.gridTebligatTeslimYeri;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(446, 395);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 19;
            this.gridControlExtender1.Text = "gridControlExtender1";
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(45, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 7;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // frmTebligatTeslimYeri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 454);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelTebligatTeslimYeri);
            this.Name = "frmTebligatTeslimYeri";
            this.Text = "Tebligat Teslim Yeri";
            ((System.ComponentModel.ISupportInitialize)(this.panelTebligatTeslimYeri)).EndInit();
            this.panelTebligatTeslimYeri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTebligatTeslimYeri)).EndInit();
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

        private DevExpress.XtraEditors.PanelControl panelTebligatTeslimYeri;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTebligatTeslimYeri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn YER;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit25;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}