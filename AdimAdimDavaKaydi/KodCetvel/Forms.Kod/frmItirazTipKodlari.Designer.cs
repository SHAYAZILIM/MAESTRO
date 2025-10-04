namespace  AnaForm
{
    partial class frmItirazTipKodlari
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
            this.panelItirazTipKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridItirazTipKodlari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ITIRAZ_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox6 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelItirazTipKodlar)).BeginInit();
            this.panelItirazTipKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItirazTipKodlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelItirazTipKodlar
            // 
            this.panelItirazTipKodlar.Controls.Add(this.gridItirazTipKodlari);
            this.panelItirazTipKodlar.Controls.Add(this.panelControl1);
            this.panelItirazTipKodlar.Controls.Add(this.panelControl2);
            this.panelItirazTipKodlar.Location = new System.Drawing.Point(12, 12);
            this.panelItirazTipKodlar.Name = "panelItirazTipKodlar";
            this.panelItirazTipKodlar.Size = new System.Drawing.Size(750, 360);
            this.panelItirazTipKodlar.TabIndex = 14;
            // 
            // gridItirazTipKodlari
            // 
            this.gridItirazTipKodlari.CustomButtonlarGorunmesin = false;
            this.gridItirazTipKodlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItirazTipKodlari.DoNotExtendEmbedNavigator = false;
            this.gridItirazTipKodlari.FilterText = null;
            this.gridItirazTipKodlari.FilterValue = null;
            this.gridItirazTipKodlari.GridlerDuzenlenebilir = true;
            this.gridItirazTipKodlari.GridsFilterControl = null;
            this.gridItirazTipKodlari.Location = new System.Drawing.Point(2, 72);
            this.gridItirazTipKodlari.MainView = this.gridView1;
            this.gridItirazTipKodlari.MyGridStyle = null;
            this.gridItirazTipKodlari.Name = "gridItirazTipKodlari";
            this.gridItirazTipKodlari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox6});
            this.gridItirazTipKodlari.ShowRowNumbers = false;
            this.gridItirazTipKodlari.Size = new System.Drawing.Size(746, 286);
            this.gridItirazTipKodlari.TabIndex = 5;
            this.gridItirazTipKodlari.TemizleKaldirGorunsunmu = false;
            this.gridItirazTipKodlari.UniqueId = "263b9e97-cbb9-4bcc-99d7-c5c24aa8c210";
            this.gridItirazTipKodlari.UseEmbeddedNavigator = true;
            this.gridItirazTipKodlari.UseHyperDragDrop = false;
            this.gridItirazTipKodlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ITIRAZ_TIP});
            this.gridView1.GridControl = this.gridItirazTipKodlari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Ýtiraz Tip Kodlarý Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // ITIRAZ_TIP
            // 
            this.ITIRAZ_TIP.Caption = "Ýtiraz Tip Kodu";
            this.ITIRAZ_TIP.ColumnEdit = this.repositoryItemComboBox6;
            this.ITIRAZ_TIP.FieldName = "ITIRAZ_TIP";
            this.ITIRAZ_TIP.Name = "ITIRAZ_TIP";
            this.ITIRAZ_TIP.Visible = true;
            this.ITIRAZ_TIP.VisibleIndex = 0;
            // 
            // repositoryItemComboBox6
            // 
            this.repositoryItemComboBox6.AutoHeight = false;
            this.repositoryItemComboBox6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox6.Name = "repositoryItemComboBox6";
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
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ýtiraz Tip Kodlarý";
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
            this.gridControlExtender1.GridControl = this.gridItirazTipKodlari;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(490, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 15;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(25, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmItirazTipKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 429);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelItirazTipKodlar);
            this.Name = "frmItirazTipKodlari";
            this.Text = "Ýtiraz Tip Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelItirazTipKodlar)).EndInit();
            this.panelItirazTipKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItirazTipKodlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelItirazTipKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridItirazTipKodlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn ITIRAZ_TIP;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox6;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}