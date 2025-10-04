namespace  AnaForm
{
    partial class frmKimlikVerilisNedenleri
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
            this.panelKimlikVerilisNedenleri = new DevExpress.XtraEditors.PanelControl();
            this.gridKimlikVerilisNedenleri = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.VERILIS_NEDEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit58 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.UYAP_KOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit59 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.UYAP_ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelKimlikVerilisNedenleri)).BeginInit();
            this.panelKimlikVerilisNedenleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKimlikVerilisNedenleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelKimlikVerilisNedenleri
            // 
            this.panelKimlikVerilisNedenleri.Controls.Add(this.gridKimlikVerilisNedenleri);
            this.panelKimlikVerilisNedenleri.Controls.Add(this.panelControl1);
            this.panelKimlikVerilisNedenleri.Controls.Add(this.panelControl2);
            this.panelKimlikVerilisNedenleri.Location = new System.Drawing.Point(17, 42);
            this.panelKimlikVerilisNedenleri.Name = "panelKimlikVerilisNedenleri";
            this.panelKimlikVerilisNedenleri.Size = new System.Drawing.Size(750, 360);
            this.panelKimlikVerilisNedenleri.TabIndex = 44;
            // 
            // gridKimlikVerilisNedenleri
            // 
            this.gridKimlikVerilisNedenleri.CustomButtonlarGorunmesin = false;
            this.gridKimlikVerilisNedenleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridKimlikVerilisNedenleri.DoNotExtendEmbedNavigator = false;
            this.gridKimlikVerilisNedenleri.FilterText = null;
            this.gridKimlikVerilisNedenleri.FilterValue = null;
            this.gridKimlikVerilisNedenleri.GridlerDuzenlenebilir = true;
            this.gridKimlikVerilisNedenleri.GridsFilterControl = null;
            this.gridKimlikVerilisNedenleri.Location = new System.Drawing.Point(2, 72);
            this.gridKimlikVerilisNedenleri.MainView = this.gridView1;
            this.gridKimlikVerilisNedenleri.MyGridStyle = null;
            this.gridKimlikVerilisNedenleri.Name = "gridKimlikVerilisNedenleri";
            this.gridKimlikVerilisNedenleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit58,
            this.repositoryItemTextEdit59,
            this.repositoryItemMemoExEdit5});
            this.gridKimlikVerilisNedenleri.ShowRowNumbers = false;
            this.gridKimlikVerilisNedenleri.Size = new System.Drawing.Size(746, 286);
            this.gridKimlikVerilisNedenleri.TabIndex = 5;
            this.gridKimlikVerilisNedenleri.TemizleKaldirGorunsunmu = false;
            this.gridKimlikVerilisNedenleri.UniqueId = "d5e24aa5-097a-4e8c-b81d-9edb4c6e4d41";
            this.gridKimlikVerilisNedenleri.UseEmbeddedNavigator = true;
            this.gridKimlikVerilisNedenleri.UseHyperDragDrop = false;
            this.gridKimlikVerilisNedenleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.VERILIS_NEDEN,
            this.UYAP_KOD,
            this.UYAP_ACIKLAMA});
            this.gridView1.GridControl = this.gridKimlikVerilisNedenleri;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Kimlik Veriliþ Nedeni Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // VERILIS_NEDEN
            // 
            this.VERILIS_NEDEN.Caption = "Veriliþ Nedeni";
            this.VERILIS_NEDEN.ColumnEdit = this.repositoryItemTextEdit58;
            this.VERILIS_NEDEN.FieldName = "VERILIS_NEDEN";
            this.VERILIS_NEDEN.Name = "VERILIS_NEDEN";
            this.VERILIS_NEDEN.Visible = true;
            this.VERILIS_NEDEN.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit58
            // 
            this.repositoryItemTextEdit58.AutoHeight = false;
            this.repositoryItemTextEdit58.Name = "repositoryItemTextEdit58";
            // 
            // UYAP_KOD
            // 
            this.UYAP_KOD.Caption = "UYAP Kod";
            this.UYAP_KOD.ColumnEdit = this.repositoryItemTextEdit59;
            this.UYAP_KOD.FieldName = "UYAP_KOD";
            this.UYAP_KOD.Name = "UYAP_KOD";
            this.UYAP_KOD.Visible = true;
            this.UYAP_KOD.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit59
            // 
            this.repositoryItemTextEdit59.AutoHeight = false;
            this.repositoryItemTextEdit59.Name = "repositoryItemTextEdit59";
            // 
            // UYAP_ACIKLAMA
            // 
            this.UYAP_ACIKLAMA.Caption = "UYAP Açýklama";
            this.UYAP_ACIKLAMA.ColumnEdit = this.repositoryItemMemoExEdit5;
            this.UYAP_ACIKLAMA.FieldName = "UYAP_ACIKLAMA";
            this.UYAP_ACIKLAMA.Name = "UYAP_ACIKLAMA";
            this.UYAP_ACIKLAMA.Visible = true;
            this.UYAP_ACIKLAMA.VisibleIndex = 2;
            // 
            // repositoryItemMemoExEdit5
            // 
            this.repositoryItemMemoExEdit5.AutoHeight = false;
            this.repositoryItemMemoExEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit5.Name = "repositoryItemMemoExEdit5";
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
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Kimlik Veriliþ Nedenleri";
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
            this.gridControlExtender1.GridControl = this.gridKimlikVerilisNedenleri;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(461, 409);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 45;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(27, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmKimlikVerilisNedenleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 444);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelKimlikVerilisNedenleri);
            this.Name = "frmKimlikVerilisNedenleri";
            this.Text = "Kimlik Veriliþ Nedenleri";
            ((System.ComponentModel.ISupportInitialize)(this.panelKimlikVerilisNedenleri)).EndInit();
            this.panelKimlikVerilisNedenleri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridKimlikVerilisNedenleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelKimlikVerilisNedenleri;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridKimlikVerilisNedenleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn VERILIS_NEDEN;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit58;
        private DevExpress.XtraGrid.Columns.GridColumn UYAP_KOD;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit59;
        private DevExpress.XtraGrid.Columns.GridColumn UYAP_ACIKLAMA;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit5;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}