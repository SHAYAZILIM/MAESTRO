namespace  AnaForm
{
    partial class frmKanGruplari
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
            this.panelKanGrupKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridKanGrupKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.KAN_GRUP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemDateEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelKanGrupKodlar)).BeginInit();
            this.panelKanGrupKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKanGrupKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit8.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelKanGrupKodlar
            // 
            this.panelKanGrupKodlar.Controls.Add(this.gridKanGrupKodlar);
            this.panelKanGrupKodlar.Controls.Add(this.panelControl1);
            this.panelKanGrupKodlar.Controls.Add(this.panelControl2);
            this.panelKanGrupKodlar.Location = new System.Drawing.Point(12, 12);
            this.panelKanGrupKodlar.Name = "panelKanGrupKodlar";
            this.panelKanGrupKodlar.Size = new System.Drawing.Size(740, 368);
            this.panelKanGrupKodlar.TabIndex = 32;
            // 
            // gridKanGrupKodlar
            // 
            this.gridKanGrupKodlar.CustomButtonlarGorunmesin = false;
            this.gridKanGrupKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridKanGrupKodlar.DoNotExtendEmbedNavigator = false;
            this.gridKanGrupKodlar.FilterText = null;
            this.gridKanGrupKodlar.FilterValue = null;
            this.gridKanGrupKodlar.GridlerDuzenlenebilir = true;
            this.gridKanGrupKodlar.GridsFilterControl = null;
            this.gridKanGrupKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridKanGrupKodlar.MainView = this.gridView1;
            this.gridKanGrupKodlar.MyGridStyle = null;
            this.gridKanGrupKodlar.Name = "gridKanGrupKodlar";
            this.gridKanGrupKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit8,
            this.repositoryItemTextEdit1});
            this.gridKanGrupKodlar.ShowRowNumbers = false;
            this.gridKanGrupKodlar.Size = new System.Drawing.Size(736, 294);
            this.gridKanGrupKodlar.TabIndex = 5;
            this.gridKanGrupKodlar.TemizleKaldirGorunsunmu = false;
            this.gridKanGrupKodlar.UniqueId = "e6e129d9-7e3a-43fd-b75e-f63c3f08eb21";
            this.gridKanGrupKodlar.UseEmbeddedNavigator = true;
            this.gridKanGrupKodlar.UseHyperDragDrop = false;
            this.gridKanGrupKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.KAN_GRUP});
            this.gridView1.GridControl = this.gridKanGrupKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Kan Grubu Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // KAN_GRUP
            // 
            this.KAN_GRUP.Caption = "Kan Grup Kodu";
            this.KAN_GRUP.ColumnEdit = this.repositoryItemTextEdit1;
            this.KAN_GRUP.FieldName = "KAN_GRUP";
            this.KAN_GRUP.Name = "KAN_GRUP";
            this.KAN_GRUP.Visible = true;
            this.KAN_GRUP.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemDateEdit8
            // 
            this.repositoryItemDateEdit8.AutoHeight = false;
            this.repositoryItemDateEdit8.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit8.Name = "repositoryItemDateEdit8";
            this.repositoryItemDateEdit8.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
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
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Kan Grup Kodlarý";
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
            this.gridControlExtender1.GridControl = this.gridKanGrupKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(736, 294);
            this.gridControlExtender1.Location = new System.Drawing.Point(470, 386);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 33;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(30, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmKanGruplari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 421);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelKanGrupKodlar);
            this.Name = "frmKanGruplari";
            this.Text = "Kan Gruplarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelKanGrupKodlar)).EndInit();
            this.panelKanGrupKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridKanGrupKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit8.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelKanGrupKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridKanGrupKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn KAN_GRUP;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit8;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}