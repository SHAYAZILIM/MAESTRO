namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    partial class frmTopluDavaNispiHarcGuncelleme
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
            this.spYuzdeOran = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.panelDavaNispiHarcCetveli = new DevExpress.XtraEditors.PanelControl();
            this.gridDavaNizpiHarcCetveli = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Tarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colHarcKod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueHarcKod = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.HARC_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.YUZDE_BINDE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueBindeYuzde = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ORAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.spYuzdeOran)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDavaNispiHarcCetveli)).BeginInit();
            this.panelDavaNispiHarcCetveli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaNizpiHarcCetveli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueHarcKod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBindeYuzde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // spYuzdeOran
            // 
            this.spYuzdeOran.AutoHeight = false;
            this.spYuzdeOran.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spYuzdeOran.Name = "spYuzdeOran";
            // 
            // panelDavaNispiHarcCetveli
            // 
            this.panelDavaNispiHarcCetveli.Controls.Add(this.gridDavaNizpiHarcCetveli);
            this.panelDavaNispiHarcCetveli.Controls.Add(this.panelControl1);
            this.panelDavaNispiHarcCetveli.Controls.Add(this.panelControl2);
            this.panelDavaNispiHarcCetveli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDavaNispiHarcCetveli.Location = new System.Drawing.Point(0, 0);
            this.panelDavaNispiHarcCetveli.Name = "panelDavaNispiHarcCetveli";
            this.panelDavaNispiHarcCetveli.Size = new System.Drawing.Size(710, 430);
            this.panelDavaNispiHarcCetveli.TabIndex = 11;
            // 
            // gridDavaNizpiHarcCetveli
            // 
            this.gridDavaNizpiHarcCetveli.CustomButtonlarGorunmesin = false;
            this.gridDavaNizpiHarcCetveli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDavaNizpiHarcCetveli.DoNotExtendEmbedNavigator = false;
            this.gridDavaNizpiHarcCetveli.FilterText = null;
            this.gridDavaNizpiHarcCetveli.FilterValue = null;
            this.gridDavaNizpiHarcCetveli.GridlerDuzenlenebilir = true;
            this.gridDavaNizpiHarcCetveli.GridsFilterControl = null;
            this.gridDavaNizpiHarcCetveli.Location = new System.Drawing.Point(2, 72);
            this.gridDavaNizpiHarcCetveli.MainView = this.gridView1;
            this.gridDavaNizpiHarcCetveli.MyGridStyle = null;
            this.gridDavaNizpiHarcCetveli.Name = "gridDavaNizpiHarcCetveli";
            this.gridDavaNizpiHarcCetveli.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.spYuzdeOran,
            this.lueHarcKod,
            this.lueBindeYuzde});
            this.gridDavaNizpiHarcCetveli.ShowRowNumbers = false;
            this.gridDavaNizpiHarcCetveli.SilmeKaldirilsin = false;
            this.gridDavaNizpiHarcCetveli.Size = new System.Drawing.Size(706, 356);
            this.gridDavaNizpiHarcCetveli.TabIndex = 5;
            this.gridDavaNizpiHarcCetveli.TemizleKaldirGorunsunmu = false;
            this.gridDavaNizpiHarcCetveli.UniqueId = "fdf0865b-4791-40c4-936f-912081e3707d";
            this.gridDavaNizpiHarcCetveli.UseEmbeddedNavigator = true;
            this.gridDavaNizpiHarcCetveli.UseHyperDragDrop = false;
            this.gridDavaNizpiHarcCetveli.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Tarih,
            this.colHarcKod,
            this.HARC_ADI,
            this.YUZDE_BINDE,
            this.ORAN});
            this.gridView1.GridControl = this.gridDavaNizpiHarcCetveli;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Başlıkları Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Dava Nispi Harç Ekleyin ";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // Tarih
            // 
            this.Tarih.Caption = "Tarih";
            this.Tarih.ColumnEdit = this.repositoryItemDateEdit1;
            this.Tarih.FieldName = "TARIH";
            this.Tarih.Name = "Tarih";
            this.Tarih.Visible = true;
            this.Tarih.VisibleIndex = 0;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // colHarcKod
            // 
            this.colHarcKod.Caption = "Harç Kodu";
            this.colHarcKod.ColumnEdit = this.lueHarcKod;
            this.colHarcKod.FieldName = "HARC_KOD_ID";
            this.colHarcKod.Name = "colHarcKod";
            this.colHarcKod.Visible = true;
            this.colHarcKod.VisibleIndex = 1;
            // 
            // lueHarcKod
            // 
            this.lueHarcKod.AutoHeight = false;
            this.lueHarcKod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueHarcKod.Name = "lueHarcKod";
            // 
            // HARC_ADI
            // 
            this.HARC_ADI.Caption = "Harc Adı";
            this.HARC_ADI.FieldName = "HARC_ADI";
            this.HARC_ADI.Name = "HARC_ADI";
            this.HARC_ADI.Visible = true;
            this.HARC_ADI.VisibleIndex = 2;
            // 
            // YUZDE_BINDE
            // 
            this.YUZDE_BINDE.Caption = "BindeYuzde";
            this.YUZDE_BINDE.ColumnEdit = this.lueBindeYuzde;
            this.YUZDE_BINDE.FieldName = "YUZDE_BINDE";
            this.YUZDE_BINDE.Name = "YUZDE_BINDE";
            this.YUZDE_BINDE.Visible = true;
            this.YUZDE_BINDE.VisibleIndex = 3;
            // 
            // lueBindeYuzde
            // 
            this.lueBindeYuzde.AutoHeight = false;
            this.lueBindeYuzde.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBindeYuzde.Name = "lueBindeYuzde";
            // 
            // ORAN
            // 
            this.ORAN.Caption = "Oran";
            this.ORAN.ColumnEdit = this.spYuzdeOran;
            this.ORAN.FieldName = "ORAN";
            this.ORAN.Name = "ORAN";
            this.ORAN.Visible = true;
            this.ORAN.VisibleIndex = 4;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(706, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dava Nispi Harc Cetveli";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.dateTimePicker1);
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(706, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(180, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(10, 10);
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
            this.gridControlExtender1.GridControl = this.gridDavaNizpiHarcCetveli;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(307, 384);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 12;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmTopluDavaNispiHarcGuncelleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 430);
            this.Controls.Add(this.panelDavaNispiHarcCetveli);
            this.Controls.Add(this.gridControlExtender1);
            this.Name = "frmTopluDavaNispiHarcGuncelleme";
            this.Text = "Dava Nispi Harç Güncelleme";
            ((System.ComponentModel.ISupportInitialize)(this.spYuzdeOran)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDavaNispiHarcCetveli)).EndInit();
            this.panelDavaNispiHarcCetveli.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaNizpiHarcCetveli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueHarcKod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBindeYuzde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spYuzdeOran;
        private DevExpress.XtraEditors.PanelControl panelDavaNispiHarcCetveli;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDavaNizpiHarcCetveli;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Tarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colHarcKod;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueHarcKod;
        private DevExpress.XtraGrid.Columns.GridColumn HARC_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn YUZDE_BINDE;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueBindeYuzde;
        private DevExpress.XtraGrid.Columns.GridColumn ORAN;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}