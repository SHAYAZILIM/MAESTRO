namespace  AnaForm
{
    partial class frmIlKodlari
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
            this.panelIlKodlari = new DevExpress.XtraEditors.PanelControl();
            this.gridIlKodlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ULKE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueUlkeGetir = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.IL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit32 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.PLAKA_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit31 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rCb_UlkeAd = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelIlKodlari)).BeginInit();
            this.panelIlKodlari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIlKodlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueUlkeGetir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_UlkeAd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelIlKodlari
            // 
            this.panelIlKodlari.Controls.Add(this.gridIlKodlari);
            this.panelIlKodlari.Controls.Add(this.panelControl1);
            this.panelIlKodlari.Controls.Add(this.panelControl2);
            this.panelIlKodlari.Location = new System.Drawing.Point(26, 44);
            this.panelIlKodlari.Name = "panelIlKodlari";
            this.panelIlKodlari.Size = new System.Drawing.Size(740, 368);
            this.panelIlKodlari.TabIndex = 32;
            // 
            // gridIlKodlari
            // 
            this.gridIlKodlari.CustomButtonlarGorunmesin = false;
            this.gridIlKodlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridIlKodlari.DoNotExtendEmbedNavigator = false;
            this.gridIlKodlari.FilterText = null;
            this.gridIlKodlari.FilterValue = null;
            this.gridIlKodlari.GridlerDuzenlenebilir = true;
            this.gridIlKodlari.GridsFilterControl = null;
            this.gridIlKodlari.Location = new System.Drawing.Point(2, 72);
            this.gridIlKodlari.MainView = this.gridView1;
            this.gridIlKodlari.MyGridStyle = null;
            this.gridIlKodlari.Name = "gridIlKodlari";
            this.gridIlKodlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rCb_UlkeAd,
            this.repositoryItemTextEdit31,
            this.repositoryItemTextEdit32,
            this.rLueUlkeGetir});
            this.gridIlKodlari.ShowRowNumbers = false;
            this.gridIlKodlari.Size = new System.Drawing.Size(736, 294);
            this.gridIlKodlari.TabIndex = 5;
            this.gridIlKodlari.TemizleKaldirGorunsunmu = false;
            this.gridIlKodlari.UniqueId = "505adcc7-ef64-40f7-a968-8ff3e73906a9";
            this.gridIlKodlari.UseEmbeddedNavigator = true;
            this.gridIlKodlari.UseHyperDragDrop = false;
            this.gridIlKodlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ULKE,
            this.IL,
            this.PLAKA_NO});
            this.gridView1.GridControl = this.gridIlKodlari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Kayýt Eklemek Ýçin Týklayýn ";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // ULKE
            // 
            this.ULKE.Caption = "Ülke";
            this.ULKE.ColumnEdit = this.rLueUlkeGetir;
            this.ULKE.FieldName = "ULKE_ID";
            this.ULKE.Name = "ULKE";
            this.ULKE.Visible = true;
            this.ULKE.VisibleIndex = 0;
            // 
            // rLueUlkeGetir
            // 
            this.rLueUlkeGetir.AutoHeight = false;
            this.rLueUlkeGetir.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueUlkeGetir.Name = "rLueUlkeGetir";
            // 
            // IL
            // 
            this.IL.Caption = "Ýl";
            this.IL.ColumnEdit = this.repositoryItemTextEdit32;
            this.IL.FieldName = "IL";
            this.IL.Name = "IL";
            this.IL.Visible = true;
            this.IL.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit32
            // 
            this.repositoryItemTextEdit32.AutoHeight = false;
            this.repositoryItemTextEdit32.Name = "repositoryItemTextEdit32";
            // 
            // PLAKA_NO
            // 
            this.PLAKA_NO.Caption = "Plaka Numarasý";
            this.PLAKA_NO.ColumnEdit = this.repositoryItemTextEdit31;
            this.PLAKA_NO.FieldName = "PLAKA_NO";
            this.PLAKA_NO.Name = "PLAKA_NO";
            this.PLAKA_NO.Visible = true;
            this.PLAKA_NO.VisibleIndex = 2;
            // 
            // repositoryItemTextEdit31
            // 
            this.repositoryItemTextEdit31.AutoHeight = false;
            this.repositoryItemTextEdit31.Name = "repositoryItemTextEdit31";
            // 
            // rCb_UlkeAd
            // 
            this.rCb_UlkeAd.AutoHeight = false;
            this.rCb_UlkeAd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_UlkeAd.Name = "rCb_UlkeAd";
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
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ýl Kodlarý";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
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
            this.gridControlExtender1.GridControl = this.gridIlKodlari;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(736, 294);
            this.gridControlExtender1.Location = new System.Drawing.Point(516, 419);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 33;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(28, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmIlKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 456);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelIlKodlari);
            this.Name = "frmIlKodlari";
            this.Text = "Ýl Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelIlKodlari)).EndInit();
            this.panelIlKodlari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridIlKodlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueUlkeGetir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_UlkeAd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelIlKodlari;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridIlKodlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn ULKE;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_UlkeAd;
        private DevExpress.XtraGrid.Columns.GridColumn IL;
        private DevExpress.XtraGrid.Columns.GridColumn PLAKA_NO;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit31;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit32;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueUlkeGetir;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}