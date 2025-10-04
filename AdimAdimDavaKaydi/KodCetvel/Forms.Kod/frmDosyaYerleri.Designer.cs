namespace  AnaForm
{
    partial class frmDosyaYerleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDosyaYerleri));
            this.panelDosyaYerleri = new DevExpress.XtraEditors.PanelControl();
            this.gridDosyaYerleri = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.FOY_BIRIM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueFoyBirim = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.FOY_YERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelDosyaYerleri)).BeginInit();
            this.panelDosyaYerleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDosyaYerleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFoyBirim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDosyaYerleri
            // 
            this.panelDosyaYerleri.Controls.Add(this.gridDosyaYerleri);
            this.panelDosyaYerleri.Controls.Add(this.panelControl1);
            this.panelDosyaYerleri.Controls.Add(this.panelControl2);
            this.panelDosyaYerleri.Location = new System.Drawing.Point(20, 57);
            this.panelDosyaYerleri.Name = "panelDosyaYerleri";
            this.panelDosyaYerleri.Size = new System.Drawing.Size(750, 360);
            this.panelDosyaYerleri.TabIndex = 33;
            // 
            // gridDosyaYerleri
            // 
            this.gridDosyaYerleri.CustomButtonlarGorunmesin = false;
            this.gridDosyaYerleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDosyaYerleri.DoNotExtendEmbedNavigator = false;
            this.gridDosyaYerleri.FilterText = null;
            this.gridDosyaYerleri.FilterValue = null;
            this.gridDosyaYerleri.GridlerDuzenlenebilir = true;
            this.gridDosyaYerleri.GridsFilterControl = null;
            this.gridDosyaYerleri.Location = new System.Drawing.Point(2, 72);
            this.gridDosyaYerleri.MainView = this.gridView1;
            this.gridDosyaYerleri.MyGridStyle = null;
            this.gridDosyaYerleri.Name = "gridDosyaYerleri";
            this.gridDosyaYerleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueFoyBirim});
            this.gridDosyaYerleri.ShowRowNumbers = false;
            this.gridDosyaYerleri.Size = new System.Drawing.Size(746, 286);
            this.gridDosyaYerleri.TabIndex = 5;
            this.gridDosyaYerleri.TemizleKaldirGorunsunmu = false;
            this.gridDosyaYerleri.UniqueId = "3694d2b4-4933-47e8-bb7e-889c0b9444ce";
            this.gridDosyaYerleri.UseEmbeddedNavigator = true;
            this.gridDosyaYerleri.UseHyperDragDrop = false;
            this.gridDosyaYerleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.FOY_BIRIM,
            this.FOY_YERI});
            this.gridView1.GridControl = this.gridDosyaYerleri;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Dosya Yeri Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // FOY_BIRIM
            // 
            this.FOY_BIRIM.Caption = "Dosya Birim";
            this.FOY_BIRIM.ColumnEdit = this.lueFoyBirim;
            this.FOY_BIRIM.FieldName = "FOY_BIRIM_ID";
            this.FOY_BIRIM.Name = "FOY_BIRIM";
            this.FOY_BIRIM.Visible = true;
            this.FOY_BIRIM.VisibleIndex = 0;
            // 
            // lueFoyBirim
            // 
            this.lueFoyBirim.AutoHeight = false;
            this.lueFoyBirim.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueFoyBirim.Name = "lueFoyBirim";
            // 
            // FOY_YERI
            // 
            this.FOY_YERI.Caption = "Dosya Yeri";
            this.FOY_YERI.FieldName = "FOY_YERI";
            this.FOY_YERI.Name = "FOY_YERI";
            this.FOY_YERI.Visible = true;
            this.FOY_YERI.VisibleIndex = 1;
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
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dosya Yerleri";
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
            this.simpleButton1.Location = new System.Drawing.Point(34, 6);
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
            this.gridControlExtender1.GridControl = this.gridDosyaYerleri;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(436, 422);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 34;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmDosyaYerleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 474);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelDosyaYerleri);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDosyaYerleri";
            this.Text = "Dosya Yerleri";
            ((System.ComponentModel.ISupportInitialize)(this.panelDosyaYerleri)).EndInit();
            this.panelDosyaYerleri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDosyaYerleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFoyBirim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelDosyaYerleri;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDosyaYerleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn FOY_BIRIM;
        private DevExpress.XtraGrid.Columns.GridColumn FOY_YERI;
        private AdimAdimDavaKaydi.IcraTakip .component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueFoyBirim;
    }
}