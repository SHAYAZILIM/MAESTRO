namespace  AnaForm
{
    partial class frmYuvarlamaCetveli
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
            this.panelYuvarlamaCetveli = new DevExpress.XtraEditors.PanelControl();
            this.gridYuvarlamaCetveli = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit9 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.HANE_ADEDI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit22 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelYuvarlamaCetveli)).BeginInit();
            this.panelYuvarlamaCetveli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridYuvarlamaCetveli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit9.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelYuvarlamaCetveli
            // 
            this.panelYuvarlamaCetveli.Controls.Add(this.gridYuvarlamaCetveli);
            this.panelYuvarlamaCetveli.Controls.Add(this.panelControl1);
            this.panelYuvarlamaCetveli.Controls.Add(this.panelControl2);
            this.panelYuvarlamaCetveli.Location = new System.Drawing.Point(12, 12);
            this.panelYuvarlamaCetveli.Name = "panelYuvarlamaCetveli";
            this.panelYuvarlamaCetveli.Size = new System.Drawing.Size(750, 360);
            this.panelYuvarlamaCetveli.TabIndex = 16;
            // 
            // gridYuvarlamaCetveli
            // 
            this.gridYuvarlamaCetveli.CustomButtonlarGorunmesin = false;
            this.gridYuvarlamaCetveli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridYuvarlamaCetveli.DoNotExtendEmbedNavigator = false;
            this.gridYuvarlamaCetveli.FilterText = null;
            this.gridYuvarlamaCetveli.FilterValue = null;
            this.gridYuvarlamaCetveli.GridlerDuzenlenebilir = true;
            this.gridYuvarlamaCetveli.GridsFilterControl = null;
            this.gridYuvarlamaCetveli.Location = new System.Drawing.Point(2, 72);
            this.gridYuvarlamaCetveli.MainView = this.gridView1;
            this.gridYuvarlamaCetveli.MyGridStyle = null;
            this.gridYuvarlamaCetveli.Name = "gridYuvarlamaCetveli";
            this.gridYuvarlamaCetveli.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit9,
            this.repositoryItemTextEdit22});
            this.gridYuvarlamaCetveli.ShowRowNumbers = false;
            this.gridYuvarlamaCetveli.Size = new System.Drawing.Size(746, 286);
            this.gridYuvarlamaCetveli.TabIndex = 5;
            this.gridYuvarlamaCetveli.TemizleKaldirGorunsunmu = false;
            this.gridYuvarlamaCetveli.UniqueId = "296b1627-af02-494b-bff0-0e2a80ff1e05";
            this.gridYuvarlamaCetveli.UseEmbeddedNavigator = true;
            this.gridYuvarlamaCetveli.UseHyperDragDrop = false;
            this.gridYuvarlamaCetveli.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TARIH,
            this.HANE_ADEDI});
            this.gridView1.GridControl = this.gridYuvarlamaCetveli;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Yuvarlama Deðeri Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // TARIH
            // 
            this.TARIH.Caption = "Tarih";
            this.TARIH.ColumnEdit = this.repositoryItemDateEdit9;
            this.TARIH.FieldName = "TARIH";
            this.TARIH.Name = "TARIH";
            this.TARIH.Visible = true;
            this.TARIH.VisibleIndex = 0;
            // 
            // repositoryItemDateEdit9
            // 
            this.repositoryItemDateEdit9.AutoHeight = false;
            this.repositoryItemDateEdit9.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit9.Name = "repositoryItemDateEdit9";
            this.repositoryItemDateEdit9.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // HANE_ADEDI
            // 
            this.HANE_ADEDI.Caption = "Kaç Hane ?";
            this.HANE_ADEDI.ColumnEdit = this.repositoryItemTextEdit22;
            this.HANE_ADEDI.FieldName = "HANE_ADEDI";
            this.HANE_ADEDI.Name = "HANE_ADEDI";
            this.HANE_ADEDI.Visible = true;
            this.HANE_ADEDI.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit22
            // 
            this.repositoryItemTextEdit22.AutoHeight = false;
            this.repositoryItemTextEdit22.Name = "repositoryItemTextEdit22";
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
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Yuvarlama Cetveli";
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
            this.sBtnKaydet.Location = new System.Drawing.Point(37, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 7;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridYuvarlamaCetveli;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(537, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 17;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmYuvarlamaCetveli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 430);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelYuvarlamaCetveli);
            this.Name = "frmYuvarlamaCetveli";
            this.Text = "Yuvarlama Cetveli";
            ((System.ComponentModel.ISupportInitialize)(this.panelYuvarlamaCetveli)).EndInit();
            this.panelYuvarlamaCetveli.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridYuvarlamaCetveli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit9.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelYuvarlamaCetveli;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridYuvarlamaCetveli;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn TARIH;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit9;
        private DevExpress.XtraGrid.Columns.GridColumn HANE_ADEDI;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit22;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}