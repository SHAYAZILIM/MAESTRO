namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    partial class frmMalCinsKodlari
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
            this.rCb_MalTur = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelMalCinsKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridMalCinsKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Tur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueMalTur = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.Cins = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit29 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit28 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_MalTur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMalCinsKodlar)).BeginInit();
            this.panelMalCinsKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMalCinsKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMalTur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rCb_MalTur
            // 
            this.rCb_MalTur.AutoHeight = false;
            this.rCb_MalTur.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_MalTur.Name = "rCb_MalTur";
            // 
            // panelMalCinsKodlar
            // 
            this.panelMalCinsKodlar.Controls.Add(this.gridMalCinsKodlar);
            this.panelMalCinsKodlar.Controls.Add(this.panelControl1);
            this.panelMalCinsKodlar.Controls.Add(this.panelControl2);
            this.panelMalCinsKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMalCinsKodlar.Location = new System.Drawing.Point(0, 0);
            this.panelMalCinsKodlar.Name = "panelMalCinsKodlar";
            this.panelMalCinsKodlar.Size = new System.Drawing.Size(576, 365);
            this.panelMalCinsKodlar.TabIndex = 28;
            // 
            // gridMalCinsKodlar
            // 
            this.gridMalCinsKodlar.CustomButtonlarGorunmesin = false;
            this.gridMalCinsKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMalCinsKodlar.DoNotExtendEmbedNavigator = false;
            this.gridMalCinsKodlar.FilterText = null;
            this.gridMalCinsKodlar.FilterValue = null;
            this.gridMalCinsKodlar.GridlerDuzenlenebilir = true;
            this.gridMalCinsKodlar.GridsFilterControl = null;
            this.gridMalCinsKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridMalCinsKodlar.MainView = this.gridView1;
            this.gridMalCinsKodlar.MyGridStyle = null;
            this.gridMalCinsKodlar.Name = "gridMalCinsKodlar";
            this.gridMalCinsKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit28,
            this.repositoryItemTextEdit29,
            this.rCb_MalTur,
            this.rLueMalTur});
            this.gridMalCinsKodlar.ShowRowNumbers = false;
            this.gridMalCinsKodlar.SilmeKaldirilsin = false;
            this.gridMalCinsKodlar.Size = new System.Drawing.Size(572, 291);
            this.gridMalCinsKodlar.TabIndex = 5;
            this.gridMalCinsKodlar.TemizleKaldirGorunsunmu = false;
            this.gridMalCinsKodlar.UniqueId = "50f537f9-e68a-44d2-ab4b-35ace697a9b8";
            this.gridMalCinsKodlar.UseEmbeddedNavigator = true;
            this.gridMalCinsKodlar.UseHyperDragDrop = false;
            this.gridMalCinsKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Tur,
            this.Cins});
            this.gridView1.GridControl = this.gridMalCinsKodlar;
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
            // Tur
            // 
            this.Tur.Caption = "Mal Türü";
            this.Tur.ColumnEdit = this.rLueMalTur;
            this.Tur.FieldName = "TUR_ID";
            this.Tur.Name = "Tur";
            this.Tur.Visible = true;
            this.Tur.VisibleIndex = 0;
            // 
            // rLueMalTur
            // 
            this.rLueMalTur.AutoHeight = false;
            this.rLueMalTur.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMalTur.Name = "rLueMalTur";
            // 
            // Cins
            // 
            this.Cins.Caption = "Mal Cinsi";
            this.Cins.ColumnEdit = this.repositoryItemTextEdit29;
            this.Cins.FieldName = "CINS";
            this.Cins.Name = "Cins";
            this.Cins.Visible = true;
            this.Cins.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit29
            // 
            this.repositoryItemTextEdit29.AutoHeight = false;
            this.repositoryItemTextEdit29.Name = "repositoryItemTextEdit29";
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
            this.panelControl1.Size = new System.Drawing.Size(572, 27);
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
            this.panelControl2.Size = new System.Drawing.Size(572, 43);
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
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = null;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridMalCinsKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(736, 294);
            this.gridControlExtender1.Location = new System.Drawing.Point(442, 385);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 29;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmMalCinsKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 365);
            this.Controls.Add(this.panelMalCinsKodlar);
            this.Controls.Add(this.gridControlExtender1);
            this.Name = "frmMalCinsKodlari";
            this.Text = "Mal Cins Kodları";
            ((System.ComponentModel.ISupportInitialize)(this.rCb_MalTur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMalCinsKodlar)).EndInit();
            this.panelMalCinsKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMalCinsKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMalTur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_MalTur;
        private DevExpress.XtraEditors.PanelControl panelMalCinsKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridMalCinsKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Tur;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMalTur;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit28;
        private DevExpress.XtraGrid.Columns.GridColumn Cins;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit29;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
    }
}