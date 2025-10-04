namespace  AnaForm
{
    partial class frmMinMaxDegerCetveli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMinMaxDegerCetveli));
            this.panelMinMaxDeger = new DevExpress.XtraEditors.PanelControl();
            this.gridMinMaxDeger = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MIN_DEGER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MIN_DEGER_DOVIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueDovizTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.MAX_DEGER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MAX_DEGER_DOVIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rCb_Aciklama = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelMinMaxDeger)).BeginInit();
            this.panelMinMaxDeger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMinMaxDeger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit6.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_Aciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMinMaxDeger
            // 
            this.panelMinMaxDeger.Controls.Add(this.gridMinMaxDeger);
            this.panelMinMaxDeger.Controls.Add(this.panelControl1);
            this.panelMinMaxDeger.Controls.Add(this.panelControl2);
            this.panelMinMaxDeger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMinMaxDeger.Location = new System.Drawing.Point(0, 0);
            this.panelMinMaxDeger.Name = "panelMinMaxDeger";
            this.panelMinMaxDeger.Size = new System.Drawing.Size(771, 439);
            this.panelMinMaxDeger.TabIndex = 13;
            // 
            // gridMinMaxDeger
            // 
            this.gridMinMaxDeger.CustomButtonlarGorunmesin = false;
            this.gridMinMaxDeger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMinMaxDeger.DoNotExtendEmbedNavigator = false;
            this.gridMinMaxDeger.FilterText = null;
            this.gridMinMaxDeger.FilterValue = null;
            this.gridMinMaxDeger.GridlerDuzenlenebilir = true;
            this.gridMinMaxDeger.GridsFilterControl = null;
            this.gridMinMaxDeger.Location = new System.Drawing.Point(2, 72);
            this.gridMinMaxDeger.MainView = this.gridView1;
            this.gridMinMaxDeger.MyGridStyle = null;
            this.gridMinMaxDeger.Name = "gridMinMaxDeger";
            this.gridMinMaxDeger.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit6,
            this.rCb_Aciklama,
            this.rLueDovizTip});
            this.gridMinMaxDeger.ShowRowNumbers = false;
            this.gridMinMaxDeger.SilmeKaldirilsin = false;
            this.gridMinMaxDeger.Size = new System.Drawing.Size(767, 365);
            this.gridMinMaxDeger.TabIndex = 5;
            this.gridMinMaxDeger.TemizleKaldirGorunsunmu = false;
            this.gridMinMaxDeger.UniqueId = "4338d0c9-e9ee-417b-b515-95d72fdde954";
            this.gridMinMaxDeger.UseEmbeddedNavigator = true;
            this.gridMinMaxDeger.UseHyperDragDrop = false;
            this.gridMinMaxDeger.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TARIH,
            this.ACIKLAMA,
            this.MIN_DEGER,
            this.MIN_DEGER_DOVIZ,
            this.MAX_DEGER,
            this.MAX_DEGER_DOVIZ});
            this.gridView1.GridControl = this.gridMinMaxDeger;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Min. Max Deðer Ekleyin ";
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
            this.TARIH.ColumnEdit = this.repositoryItemDateEdit6;
            this.TARIH.FieldName = "TARIH";
            this.TARIH.Name = "TARIH";
            this.TARIH.Visible = true;
            this.TARIH.VisibleIndex = 0;
            // 
            // repositoryItemDateEdit6
            // 
            this.repositoryItemDateEdit6.AutoHeight = false;
            this.repositoryItemDateEdit6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit6.Name = "repositoryItemDateEdit6";
            this.repositoryItemDateEdit6.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // ACIKLAMA
            // 
            this.ACIKLAMA.Caption = "Açýklama";
            this.ACIKLAMA.FieldName = "ACIKLAMA";
            this.ACIKLAMA.Name = "ACIKLAMA";
            this.ACIKLAMA.Visible = true;
            this.ACIKLAMA.VisibleIndex = 1;
            // 
            // MIN_DEGER
            // 
            this.MIN_DEGER.Caption = "Min. Deðer";
            this.MIN_DEGER.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.MIN_DEGER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.MIN_DEGER.FieldName = "MIN_DEGER";
            this.MIN_DEGER.Name = "MIN_DEGER";
            this.MIN_DEGER.Visible = true;
            this.MIN_DEGER.VisibleIndex = 2;
            // 
            // MIN_DEGER_DOVIZ
            // 
            this.MIN_DEGER_DOVIZ.Caption = " ";
            this.MIN_DEGER_DOVIZ.ColumnEdit = this.rLueDovizTip;
            this.MIN_DEGER_DOVIZ.CustomizationCaption = "Min Deðer Döviz";
            this.MIN_DEGER_DOVIZ.FieldName = "MIN_DEGER_DOVIZ_ID";
            this.MIN_DEGER_DOVIZ.Name = "MIN_DEGER_DOVIZ";
            this.MIN_DEGER_DOVIZ.Visible = true;
            this.MIN_DEGER_DOVIZ.VisibleIndex = 3;
            // 
            // rLueDovizTip
            // 
            this.rLueDovizTip.AutoHeight = false;
            this.rLueDovizTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDovizTip.Name = "rLueDovizTip";
            // 
            // MAX_DEGER
            // 
            this.MAX_DEGER.Caption = "Max Deðer";
            this.MAX_DEGER.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.MAX_DEGER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.MAX_DEGER.FieldName = "MAX_DEGER";
            this.MAX_DEGER.Name = "MAX_DEGER";
            this.MAX_DEGER.Visible = true;
            this.MAX_DEGER.VisibleIndex = 4;
            // 
            // MAX_DEGER_DOVIZ
            // 
            this.MAX_DEGER_DOVIZ.Caption = " ";
            this.MAX_DEGER_DOVIZ.ColumnEdit = this.rLueDovizTip;
            this.MAX_DEGER_DOVIZ.CustomizationCaption = "Max Deðer Döviz";
            this.MAX_DEGER_DOVIZ.FieldName = "MAX_DEGER_DOVIZ_ID";
            this.MAX_DEGER_DOVIZ.Name = "MAX_DEGER_DOVIZ";
            this.MAX_DEGER_DOVIZ.Visible = true;
            this.MAX_DEGER_DOVIZ.VisibleIndex = 5;
            // 
            // rCb_Aciklama
            // 
            this.rCb_Aciklama.AutoHeight = false;
            this.rCb_Aciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_Aciklama.Name = "rCb_Aciklama";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(767, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Minimum Maksimum Deðer Cetveli";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(767, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(24, 10);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridMinMaxDeger;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(411, 378);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 14;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmMinMaxDegerCetveli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 439);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelMinMaxDeger);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMinMaxDegerCetveli";
            this.Text = "Minimum Maksimum Deðer Cetveli";
            ((System.ComponentModel.ISupportInitialize)(this.panelMinMaxDeger)).EndInit();
            this.panelMinMaxDeger.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMinMaxDeger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit6.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_Aciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelMinMaxDeger;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridMinMaxDeger;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn TARIH;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit6;
        private DevExpress.XtraGrid.Columns.GridColumn ACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn MIN_DEGER;
        private DevExpress.XtraGrid.Columns.GridColumn MIN_DEGER_DOVIZ;
        private DevExpress.XtraGrid.Columns.GridColumn MAX_DEGER;
        private DevExpress.XtraGrid.Columns.GridColumn MAX_DEGER_DOVIZ;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_Aciklama;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDovizTip;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}