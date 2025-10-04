namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    partial class frmDusmeDegismeKodlari
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
            this.gridDusmeDegistirme = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DUSMEDEGISTIRME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxteDusmeDegistirme = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelDusmeDegistirme = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDusmeDegistirme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteDusmeDegistirme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDusmeDegistirme)).BeginInit();
            this.panelDusmeDegistirme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDusmeDegistirme
            // 
            this.gridDusmeDegistirme.CustomButtonlarGorunmesin = false;
            this.gridDusmeDegistirme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDusmeDegistirme.DoNotExtendEmbedNavigator = false;
            this.gridDusmeDegistirme.FilterText = null;
            this.gridDusmeDegistirme.FilterValue = null;
            this.gridDusmeDegistirme.GridlerDuzenlenebilir = true;
            this.gridDusmeDegistirme.GridsFilterControl = null;
            this.gridDusmeDegistirme.Location = new System.Drawing.Point(2, 72);
            this.gridDusmeDegistirme.MainView = this.gridView1;
            this.gridDusmeDegistirme.MyGridStyle = null;
            this.gridDusmeDegistirme.Name = "gridDusmeDegistirme";
            this.gridDusmeDegistirme.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rtxteDusmeDegistirme});
            this.gridDusmeDegistirme.ShowRowNumbers = false;
            this.gridDusmeDegistirme.SilmeKaldirilsin = false;
            this.gridDusmeDegistirme.Size = new System.Drawing.Size(662, 331);
            this.gridDusmeDegistirme.TabIndex = 5;
            this.gridDusmeDegistirme.TemizleKaldirGorunsunmu = false;
            this.gridDusmeDegistirme.UniqueId = "de036662-8aff-4b21-97bb-89975c79dd01";
            this.gridDusmeDegistirme.UseEmbeddedNavigator = true;
            this.gridDusmeDegistirme.UseHyperDragDrop = false;
            this.gridDusmeDegistirme.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DUSMEDEGISTIRME});
            this.gridView1.GridControl = this.gridDusmeDegistirme;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Başlıkları Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Düşme Değiştirme Kodu Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // DUSMEDEGISTIRME
            // 
            this.DUSMEDEGISTIRME.Caption = "Düşme Değiştirme Kodu";
            this.DUSMEDEGISTIRME.ColumnEdit = this.rtxteDusmeDegistirme;
            this.DUSMEDEGISTIRME.FieldName = "DUS_DEG_KODU";
            this.DUSMEDEGISTIRME.Name = "DUSMEDEGISTIRME";
            this.DUSMEDEGISTIRME.Visible = true;
            this.DUSMEDEGISTIRME.VisibleIndex = 0;
            // 
            // rtxteDusmeDegistirme
            // 
            this.rtxteDusmeDegistirme.AutoHeight = false;
            this.rtxteDusmeDegistirme.Name = "rtxteDusmeDegistirme";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(19, 10);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(117, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // panelDusmeDegistirme
            // 
            this.panelDusmeDegistirme.Controls.Add(this.gridDusmeDegistirme);
            this.panelDusmeDegistirme.Controls.Add(this.panelControl1);
            this.panelDusmeDegistirme.Controls.Add(this.panelControl2);
            this.panelDusmeDegistirme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDusmeDegistirme.Location = new System.Drawing.Point(0, 0);
            this.panelDusmeDegistirme.Name = "panelDusmeDegistirme";
            this.panelDusmeDegistirme.Size = new System.Drawing.Size(666, 405);
            this.panelDusmeDegistirme.TabIndex = 21;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(662, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Düşme Değiştirme Kodları";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(662, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // frmDusmeDegismeKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 405);
            this.Controls.Add(this.panelDusmeDegistirme);
            this.Name = "frmDusmeDegismeKodlari";
            this.Text = "frmDusmeDegismeKodlari";
            ((System.ComponentModel.ISupportInitialize)(this.gridDusmeDegistirme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxteDusmeDegistirme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDusmeDegistirme)).EndInit();
            this.panelDusmeDegistirme.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDusmeDegistirme;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn DUSMEDEGISTIRME;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxteDusmeDegistirme;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl panelDusmeDegistirme;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}