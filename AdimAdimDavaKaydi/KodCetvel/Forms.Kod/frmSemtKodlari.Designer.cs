namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    partial class frmSemtKodlari
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
            this.rCb_Ilce = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemTextEdit28 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.repositoryItemTextEdit29 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.Cins = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelSemtKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridSemtKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Ilce = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueIlce = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.PostaKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_Ilce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSemtKodlar)).BeginInit();
            this.panelSemtKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSemtKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIlce)).BeginInit();
            this.SuspendLayout();
            // 
            // rCb_Ilce
            // 
            this.rCb_Ilce.AutoHeight = false;
            this.rCb_Ilce.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_Ilce.Name = "rCb_Ilce";
            // 
            // repositoryItemTextEdit28
            // 
            this.repositoryItemTextEdit28.AutoHeight = false;
            this.repositoryItemTextEdit28.Name = "repositoryItemTextEdit28";
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
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mal Tür Kodları";
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
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(37, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // repositoryItemTextEdit29
            // 
            this.repositoryItemTextEdit29.AutoHeight = false;
            this.repositoryItemTextEdit29.Name = "repositoryItemTextEdit29";
            // 
            // Cins
            // 
            this.Cins.Caption = "Mal Cinsi";
            this.Cins.ColumnEdit = this.repositoryItemTextEdit29;
            this.Cins.FieldName = "SEMT";
            this.Cins.Name = "Cins";
            this.Cins.Visible = true;
            this.Cins.VisibleIndex = 1;
            // 
            // panelSemtKodlar
            // 
            this.panelSemtKodlar.Controls.Add(this.gridSemtKodlar);
            this.panelSemtKodlar.Controls.Add(this.panelControl1);
            this.panelSemtKodlar.Controls.Add(this.panelControl2);
            this.panelSemtKodlar.Location = new System.Drawing.Point(12, 12);
            this.panelSemtKodlar.Name = "panelSemtKodlar";
            this.panelSemtKodlar.Size = new System.Drawing.Size(740, 368);
            this.panelSemtKodlar.TabIndex = 30;
            // 
            // gridSemtKodlar
            // 
            this.gridSemtKodlar.CustomButtonlarGorunmesin = false;
            this.gridSemtKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSemtKodlar.DoNotExtendEmbedNavigator = false;
            this.gridSemtKodlar.FilterText = null;
            this.gridSemtKodlar.FilterValue = null;
            this.gridSemtKodlar.GridlerDuzenlenebilir = true;
            this.gridSemtKodlar.GridsFilterControl = null;
            this.gridSemtKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridSemtKodlar.MainView = this.gridView1;
            this.gridSemtKodlar.MyGridStyle = null;
            this.gridSemtKodlar.Name = "gridSemtKodlar";
            this.gridSemtKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit28,
            this.repositoryItemTextEdit29,
            this.rCb_Ilce,
            this.rLueIlce});
            this.gridSemtKodlar.ShowRowNumbers = false;
            this.gridSemtKodlar.SilmeKaldirilsin = false;
            this.gridSemtKodlar.Size = new System.Drawing.Size(736, 294);
            this.gridSemtKodlar.TabIndex = 5;
            this.gridSemtKodlar.TemizleKaldirGorunsunmu = false;
            this.gridSemtKodlar.UniqueId = "90c0c5fb-2993-4d09-bb5e-ac4bdebf4511";
            this.gridSemtKodlar.UseEmbeddedNavigator = true;
            this.gridSemtKodlar.UseHyperDragDrop = false;
            this.gridSemtKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Ilce,
            this.Cins,
            this.PostaKodu});
            this.gridView1.GridControl = this.gridSemtKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Başlıkları Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Mal Türü Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // Ilce
            // 
            this.Ilce.Caption = "İlçe";
            this.Ilce.ColumnEdit = this.rLueIlce;
            this.Ilce.FieldName = "ILCE_ID";
            this.Ilce.Name = "Ilce";
            this.Ilce.Visible = true;
            this.Ilce.VisibleIndex = 0;
            // 
            // rLueIlce
            // 
            this.rLueIlce.AutoHeight = false;
            this.rLueIlce.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueIlce.Name = "rLueIlce";
            // 
            // PostaKodu
            // 
            this.PostaKodu.Caption = "Posta Kodu";
            this.PostaKodu.FieldName = "POSTA_KODU";
            this.PostaKodu.Name = "PostaKodu";
            this.PostaKodu.Visible = true;
            this.PostaKodu.VisibleIndex = 2;
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = null;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridSemtKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(736, 294);
            this.gridControlExtender1.Location = new System.Drawing.Point(442, 385);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 31;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmSemtKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 385);
            this.Controls.Add(this.panelSemtKodlar);
            this.Controls.Add(this.gridControlExtender1);
            this.Name = "frmSemtKodlari";
            this.Text = "frmSemtKodlari";
            ((System.ComponentModel.ISupportInitialize)(this.rCb_Ilce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSemtKodlar)).EndInit();
            this.panelSemtKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSemtKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIlce)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_Ilce;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit28;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit29;
        private DevExpress.XtraGrid.Columns.GridColumn Cins;
        private DevExpress.XtraEditors.PanelControl panelSemtKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridSemtKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Ilce;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueIlce;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraGrid.Columns.GridColumn PostaKodu;
    }
}