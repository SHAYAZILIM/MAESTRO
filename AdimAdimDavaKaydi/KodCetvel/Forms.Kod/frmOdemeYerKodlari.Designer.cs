namespace  AnaForm
{
    partial class frmOdemeYerKodlari
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
            this.panelOdemeYerKodlari = new DevExpress.XtraEditors.PanelControl();
            this.gridOdemeYerKodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ODEME_YERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelOdemeYerKodlari)).BeginInit();
            this.panelOdemeYerKodlari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOdemeYerKodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOdemeYerKodlari
            // 
            this.panelOdemeYerKodlari.Controls.Add(this.gridOdemeYerKodlar);
            this.panelOdemeYerKodlari.Controls.Add(this.panelControl1);
            this.panelOdemeYerKodlari.Controls.Add(this.panelControl2);
            this.panelOdemeYerKodlari.Location = new System.Drawing.Point(12, 12);
            this.panelOdemeYerKodlari.Name = "panelOdemeYerKodlari";
            this.panelOdemeYerKodlari.Size = new System.Drawing.Size(750, 360);
            this.panelOdemeYerKodlari.TabIndex = 12;
            // 
            // gridOdemeYerKodlar
            // 
            this.gridOdemeYerKodlar.CustomButtonlarGorunmesin = false;
            this.gridOdemeYerKodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOdemeYerKodlar.DoNotExtendEmbedNavigator = false;
            this.gridOdemeYerKodlar.FilterText = null;
            this.gridOdemeYerKodlar.FilterValue = null;
            this.gridOdemeYerKodlar.GridlerDuzenlenebilir = true;
            this.gridOdemeYerKodlar.GridsFilterControl = null;
            this.gridOdemeYerKodlar.Location = new System.Drawing.Point(2, 72);
            this.gridOdemeYerKodlar.MainView = this.gridView1;
            this.gridOdemeYerKodlar.MyGridStyle = null;
            this.gridOdemeYerKodlar.Name = "gridOdemeYerKodlar";
            this.gridOdemeYerKodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox3});
            this.gridOdemeYerKodlar.ShowRowNumbers = false;
            this.gridOdemeYerKodlar.Size = new System.Drawing.Size(746, 286);
            this.gridOdemeYerKodlar.TabIndex = 5;
            this.gridOdemeYerKodlar.TemizleKaldirGorunsunmu = false;
            this.gridOdemeYerKodlar.UniqueId = "c97cb246-0c03-4ce8-93be-50b9a274df09";
            this.gridOdemeYerKodlar.UseEmbeddedNavigator = true;
            this.gridOdemeYerKodlar.UseHyperDragDrop = false;
            this.gridOdemeYerKodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ODEME_YERI});
            this.gridView1.GridControl = this.gridOdemeYerKodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Ödeme Yeri Ekleyin ";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // ODEME_YERI
            // 
            this.ODEME_YERI.Caption = "Ödeme Yeri";
            this.ODEME_YERI.ColumnEdit = this.repositoryItemComboBox3;
            this.ODEME_YERI.FieldName = "ODEME_YERI";
            this.ODEME_YERI.Name = "ODEME_YERI";
            this.ODEME_YERI.Visible = true;
            this.ODEME_YERI.VisibleIndex = 0;
            // 
            // repositoryItemComboBox3
            // 
            this.repositoryItemComboBox3.AutoHeight = false;
            this.repositoryItemComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox3.Name = "repositoryItemComboBox3";
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
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ödeme Yer Kodlarý ";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(746, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(41, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridOdemeYerKodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(439, 377);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 13;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmOdemeYerKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 419);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelOdemeYerKodlari);
            this.Name = "frmOdemeYerKodlari";
            this.Text = "Ödeme Yer Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelOdemeYerKodlari)).EndInit();
            this.panelOdemeYerKodlari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridOdemeYerKodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelOdemeYerKodlari;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridOdemeYerKodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn ODEME_YERI;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox3;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}