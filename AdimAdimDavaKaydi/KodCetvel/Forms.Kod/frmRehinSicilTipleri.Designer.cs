namespace  AnaForm
{
    partial class frmRehinSicilTipleri
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
            this.panelRehinSicilTip = new DevExpress.XtraEditors.PanelControl();
            this.gridRehinSicilTipleri = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SICIL_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelRehinSicilTip)).BeginInit();
            this.panelRehinSicilTip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRehinSicilTipleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRehinSicilTip
            // 
            this.panelRehinSicilTip.Controls.Add(this.gridRehinSicilTipleri);
            this.panelRehinSicilTip.Controls.Add(this.panelControl1);
            this.panelRehinSicilTip.Controls.Add(this.panelControl2);
            this.panelRehinSicilTip.Location = new System.Drawing.Point(12, 12);
            this.panelRehinSicilTip.Name = "panelRehinSicilTip";
            this.panelRehinSicilTip.Size = new System.Drawing.Size(750, 360);
            this.panelRehinSicilTip.TabIndex = 45;
            // 
            // gridRehinSicilTipleri
            // 
            this.gridRehinSicilTipleri.CustomButtonlarGorunmesin = false;
            this.gridRehinSicilTipleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRehinSicilTipleri.DoNotExtendEmbedNavigator = false;
            this.gridRehinSicilTipleri.FilterText = null;
            this.gridRehinSicilTipleri.FilterValue = null;
            this.gridRehinSicilTipleri.GridlerDuzenlenebilir = true;
            this.gridRehinSicilTipleri.GridsFilterControl = null;
            this.gridRehinSicilTipleri.Location = new System.Drawing.Point(2, 72);
            this.gridRehinSicilTipleri.MainView = this.gridView1;
            this.gridRehinSicilTipleri.MyGridStyle = null;
            this.gridRehinSicilTipleri.Name = "gridRehinSicilTipleri";
            this.gridRehinSicilTipleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.gridRehinSicilTipleri.ShowRowNumbers = false;
            this.gridRehinSicilTipleri.Size = new System.Drawing.Size(746, 286);
            this.gridRehinSicilTipleri.TabIndex = 5;
            this.gridRehinSicilTipleri.TemizleKaldirGorunsunmu = false;
            this.gridRehinSicilTipleri.UniqueId = "31c85147-7a13-482e-8220-b55821b72ea8";
            this.gridRehinSicilTipleri.UseEmbeddedNavigator = true;
            this.gridRehinSicilTipleri.UseHyperDragDrop = false;
            this.gridRehinSicilTipleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SICIL_TIP});
            this.gridView1.GridControl = this.gridRehinSicilTipleri;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Rehin Sicil Tipleri Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // SICIL_TIP
            // 
            this.SICIL_TIP.Caption = "Sicil Tip";
            this.SICIL_TIP.ColumnEdit = this.repositoryItemTextEdit1;
            this.SICIL_TIP.FieldName = "SICIL_TIP";
            this.SICIL_TIP.Name = "SICIL_TIP";
            this.SICIL_TIP.Visible = true;
            this.SICIL_TIP.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
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
            this.label1.Text = "Rehin Sicil Tipleri";
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
            this.sBtnKaydet.Location = new System.Drawing.Point(29, 10);
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
            this.gridControlExtender1.GridControl = this.gridRehinSicilTipleri;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(503, 393);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 46;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmRehinSicilTipleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 462);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelRehinSicilTip);
            this.Name = "frmRehinSicilTipleri";
            this.Text = "Rehin Sicil Tipleri";
            ((System.ComponentModel.ISupportInitialize)(this.panelRehinSicilTip)).EndInit();
            this.panelRehinSicilTip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRehinSicilTipleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelRehinSicilTip;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridRehinSicilTipleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn SICIL_TIP;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}