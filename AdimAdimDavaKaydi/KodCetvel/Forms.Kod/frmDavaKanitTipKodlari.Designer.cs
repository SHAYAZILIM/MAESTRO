namespace  AnaForm
{
    partial class frmDavaKanitTipKodlari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDavaKanitTipKodlari));
            this.panelDavaKanitTipleri = new DevExpress.XtraEditors.PanelControl();
            this.gridDavaKanitTipKodlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.KANIT_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelDavaKanitTipleri)).BeginInit();
            this.panelDavaKanitTipleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaKanitTipKodlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDavaKanitTipleri
            // 
            this.panelDavaKanitTipleri.Controls.Add(this.gridDavaKanitTipKodlari);
            this.panelDavaKanitTipleri.Controls.Add(this.panelControl1);
            this.panelDavaKanitTipleri.Controls.Add(this.panelControl2);
            this.panelDavaKanitTipleri.Location = new System.Drawing.Point(10, 12);
            this.panelDavaKanitTipleri.Name = "panelDavaKanitTipleri";
            this.panelDavaKanitTipleri.Size = new System.Drawing.Size(750, 360);
            this.panelDavaKanitTipleri.TabIndex = 16;
            // 
            // gridDavaKanitTipKodlari
            // 
            this.gridDavaKanitTipKodlari.CustomButtonlarGorunmesin = false;
            this.gridDavaKanitTipKodlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDavaKanitTipKodlari.DoNotExtendEmbedNavigator = false;
            this.gridDavaKanitTipKodlari.FilterText = null;
            this.gridDavaKanitTipKodlari.FilterValue = null;
            this.gridDavaKanitTipKodlari.GridlerDuzenlenebilir = true;
            this.gridDavaKanitTipKodlari.GridsFilterControl = null;
            this.gridDavaKanitTipKodlari.Location = new System.Drawing.Point(2, 72);
            this.gridDavaKanitTipKodlari.MainView = this.gridView1;
            this.gridDavaKanitTipKodlari.MyGridStyle = null;
            this.gridDavaKanitTipKodlari.Name = "gridDavaKanitTipKodlari";
            this.gridDavaKanitTipKodlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemComboBox1});
            this.gridDavaKanitTipKodlari.ShowRowNumbers = false;
            this.gridDavaKanitTipKodlari.Size = new System.Drawing.Size(746, 286);
            this.gridDavaKanitTipKodlari.TabIndex = 5;
            this.gridDavaKanitTipKodlari.TemizleKaldirGorunsunmu = false;
            this.gridDavaKanitTipKodlari.UniqueId = "52db02ac-a65c-4e1b-ba0b-352807a64e29";
            this.gridDavaKanitTipKodlari.UseEmbeddedNavigator = true;
            this.gridDavaKanitTipKodlari.UseHyperDragDrop = false;
            this.gridDavaKanitTipKodlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.KANIT_TIP});
            this.gridView1.GridControl = this.gridDavaKanitTipKodlari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Dava Kanýt Tipi Ekle";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // KANIT_TIP
            // 
            this.KANIT_TIP.Caption = "Kanýt Tipi";
            this.KANIT_TIP.ColumnEdit = this.repositoryItemComboBox1;
            this.KANIT_TIP.FieldName = "KANIT_TIP";
            this.KANIT_TIP.Name = "KANIT_TIP";
            this.KANIT_TIP.Visible = true;
            this.KANIT_TIP.VisibleIndex = 0;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
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
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dava Kanit Tip Kodlari";
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
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridDavaKanitTipKodlari;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(428, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 17;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(27, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(88, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmDavaKanitTipKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 442);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelDavaKanitTipleri);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDavaKanitTipKodlari";
            this.Text = "Dava Kanýt Tip Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelDavaKanitTipleri)).EndInit();
            this.panelDavaKanitTipleri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaKanitTipKodlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelDavaKanitTipleri;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDavaKanitTipKodlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn KANIT_TIP;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}