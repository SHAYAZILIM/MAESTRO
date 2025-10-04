namespace  AnaForm
{
    partial class frmRehinHarcIstisnaBelge
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
            this.panelRehinHarcIstisna = new DevExpress.XtraEditors.PanelControl();
            this.gridRehinHarcIstisna = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.HARC_ISTISNA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rCb_HarcIStisna = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ISTISNA_BELGE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit57 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelRehinHarcIstisna)).BeginInit();
            this.panelRehinHarcIstisna.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRehinHarcIstisna)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_HarcIStisna)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRehinHarcIstisna
            // 
            this.panelRehinHarcIstisna.Controls.Add(this.gridRehinHarcIstisna);
            this.panelRehinHarcIstisna.Controls.Add(this.panelControl1);
            this.panelRehinHarcIstisna.Controls.Add(this.panelControl2);
            this.panelRehinHarcIstisna.Location = new System.Drawing.Point(11, 12);
            this.panelRehinHarcIstisna.Name = "panelRehinHarcIstisna";
            this.panelRehinHarcIstisna.Size = new System.Drawing.Size(750, 360);
            this.panelRehinHarcIstisna.TabIndex = 44;
            // 
            // gridRehinHarcIstisna
            // 
            this.gridRehinHarcIstisna.CustomButtonlarGorunmesin = false;
            this.gridRehinHarcIstisna.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRehinHarcIstisna.DoNotExtendEmbedNavigator = false;
            this.gridRehinHarcIstisna.FilterText = null;
            this.gridRehinHarcIstisna.FilterValue = null;
            this.gridRehinHarcIstisna.GridlerDuzenlenebilir = true;
            this.gridRehinHarcIstisna.GridsFilterControl = null;
            this.gridRehinHarcIstisna.Location = new System.Drawing.Point(2, 72);
            this.gridRehinHarcIstisna.MainView = this.gridView1;
            this.gridRehinHarcIstisna.MyGridStyle = null;
            this.gridRehinHarcIstisna.Name = "gridRehinHarcIstisna";
            this.gridRehinHarcIstisna.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit57,
            this.rCb_HarcIStisna});
            this.gridRehinHarcIstisna.ShowRowNumbers = false;
            this.gridRehinHarcIstisna.Size = new System.Drawing.Size(746, 286);
            this.gridRehinHarcIstisna.TabIndex = 5;
            this.gridRehinHarcIstisna.TemizleKaldirGorunsunmu = false;
            this.gridRehinHarcIstisna.UniqueId = "3d7674d0-5262-43f9-9f9b-41f1b52a74d4";
            this.gridRehinHarcIstisna.UseEmbeddedNavigator = true;
            this.gridRehinHarcIstisna.UseHyperDragDrop = false;
            this.gridRehinHarcIstisna.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.HARC_ISTISNA,
            this.ISTISNA_BELGE});
            this.gridView1.GridControl = this.gridRehinHarcIstisna;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Harc Ýstisna Belgeleri Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // HARC_ISTISNA
            // 
            this.HARC_ISTISNA.Caption = "Harç Ýstisna";
            this.HARC_ISTISNA.ColumnEdit = this.rCb_HarcIStisna;
            this.HARC_ISTISNA.FieldName = "HARC_ISTISNA";
            this.HARC_ISTISNA.Name = "HARC_ISTISNA";
            this.HARC_ISTISNA.Visible = true;
            this.HARC_ISTISNA.VisibleIndex = 0;
            // 
            // rCb_HarcIStisna
            // 
            this.rCb_HarcIStisna.AutoHeight = false;
            this.rCb_HarcIStisna.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_HarcIStisna.Name = "rCb_HarcIStisna";
            // 
            // ISTISNA_BELGE
            // 
            this.ISTISNA_BELGE.Caption = "Ýstisna Belge";
            this.ISTISNA_BELGE.ColumnEdit = this.repositoryItemTextEdit57;
            this.ISTISNA_BELGE.FieldName = "ISTISNA_BELGE";
            this.ISTISNA_BELGE.Name = "ISTISNA_BELGE";
            this.ISTISNA_BELGE.Visible = true;
            this.ISTISNA_BELGE.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit57
            // 
            this.repositoryItemTextEdit57.AutoHeight = false;
            this.repositoryItemTextEdit57.Name = "repositoryItemTextEdit57";
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
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Rehin Harç Ýstisna Kodlarý";
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
            this.sBtnKaydet.Location = new System.Drawing.Point(79, 10);
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
            this.gridControlExtender1.GridControl = this.gridRehinHarcIstisna;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(448, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 45;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmRehinHarcIstisnaBelge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 467);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelRehinHarcIstisna);
            this.Name = "frmRehinHarcIstisnaBelge";
            this.Text = "Rehin Harç Ýstisna Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelRehinHarcIstisna)).EndInit();
            this.panelRehinHarcIstisna.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRehinHarcIstisna)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_HarcIStisna)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelRehinHarcIstisna;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridRehinHarcIstisna;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn HARC_ISTISNA;
        private DevExpress.XtraGrid.Columns.GridColumn ISTISNA_BELGE;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit57;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_HarcIStisna;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}