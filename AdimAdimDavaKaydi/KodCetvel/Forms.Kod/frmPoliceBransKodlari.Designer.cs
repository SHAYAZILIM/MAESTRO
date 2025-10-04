namespace  AnaForm
{
    partial class frmPoliceBransKodlari
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
            this.panelBransKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridPoliceBransKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.POLICE_BRANS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemComboBox19 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelBransKodlar)).BeginInit();
            this.panelBransKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPoliceBransKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBransKodlar
            // 
            this.panelBransKodlar.Controls.Add(this.gridPoliceBransKodlar);
            this.panelBransKodlar.Controls.Add(this.panelControl1);
            this.panelBransKodlar.Controls.Add(this.panelControl2);
            this.panelBransKodlar.Location = new System.Drawing.Point(18, 47);
            this.panelBransKodlar.Name = "panelBransKodlar";
            this.panelBransKodlar.Size = new System.Drawing.Size(750, 360);
            this.panelBransKodlar.TabIndex = 37;
            // 
            // gridPoliceBransKodlar
            // 
            this.gridPoliceBransKodlar.CustomButtonlarGorunmesin = false;
            this.gridPoliceBransKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPoliceBransKodlar.DoNotExtendEmbedNavigator = false;
            this.gridPoliceBransKodlar.FilterText = null;
            this.gridPoliceBransKodlar.FilterValue = null;
            this.gridPoliceBransKodlar.GridlerDuzenlenebilir = true;
            this.gridPoliceBransKodlar.GridsFilterControl = null;
            this.gridPoliceBransKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridPoliceBransKodlar.MainView = this.gridView1;
            this.gridPoliceBransKodlar.MyGridStyle = null;
            this.gridPoliceBransKodlar.Name = "gridPoliceBransKodlar";
            this.gridPoliceBransKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox19,
            this.repositoryItemTextEdit1});
            this.gridPoliceBransKodlar.ShowRowNumbers = false;
            this.gridPoliceBransKodlar.Size = new System.Drawing.Size(746, 286);
            this.gridPoliceBransKodlar.TabIndex = 5;
            this.gridPoliceBransKodlar.TemizleKaldirGorunsunmu = false;
            this.gridPoliceBransKodlar.UniqueId = "63609828-8042-448d-b5a5-88d039441a32";
            this.gridPoliceBransKodlar.UseEmbeddedNavigator = true;
            this.gridPoliceBransKodlar.UseHyperDragDrop = false;
            this.gridPoliceBransKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.POLICE_BRANS});
            this.gridView1.GridControl = this.gridPoliceBransKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Poliçe Branþlarý Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // POLICE_BRANS
            // 
            this.POLICE_BRANS.Caption = "Poliçe Branþ Kodlarý";
            this.POLICE_BRANS.ColumnEdit = this.repositoryItemTextEdit1;
            this.POLICE_BRANS.FieldName = "POLICE_BRANS";
            this.POLICE_BRANS.Name = "POLICE_BRANS";
            this.POLICE_BRANS.Visible = true;
            this.POLICE_BRANS.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemComboBox19
            // 
            this.repositoryItemComboBox19.AutoHeight = false;
            this.repositoryItemComboBox19.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox19.Name = "repositoryItemComboBox19";
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
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Poliçe Branþ Kodlarý";
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
            this.sBtnKaydet.Location = new System.Drawing.Point(44, 10);
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
            this.gridControlExtender1.GridControl = this.gridPoliceBransKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(394, 412);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 38;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmPoliceBransKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 454);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelBransKodlar);
            this.Name = "frmPoliceBransKodlari";
            this.Text = "Poliçe Branþ Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelBransKodlar)).EndInit();
            this.panelBransKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPoliceBransKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelBransKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridPoliceBransKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn POLICE_BRANS;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox19;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}