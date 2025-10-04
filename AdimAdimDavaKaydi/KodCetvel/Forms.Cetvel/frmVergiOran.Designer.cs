namespace AdimAdimDavaKaydi.KodCetvel.Forms.Cetvel
{
    partial class frmVergiOran
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
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.gridDosyaYerleri = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.VERGI_KOD_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueVergiKodu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.TARIFE_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtTarifeT = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.TARIFE_ORANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spTarifeOran = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.panelVergiOran = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridDosyaYerleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueVergiKodu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTarifeT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTarifeT.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTarifeOran)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelVergiOran)).BeginInit();
            this.panelVergiOran.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = null;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridDosyaYerleri;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(451, 372);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 36;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
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
            this.rlueVergiKodu,
            this.spTarifeOran,
            this.dtTarifeT});
            this.gridDosyaYerleri.ShowRowNumbers = false;
            this.gridDosyaYerleri.Size = new System.Drawing.Size(746, 286);
            this.gridDosyaYerleri.TabIndex = 5;
            this.gridDosyaYerleri.TemizleKaldirGorunsunmu = false;
            this.gridDosyaYerleri.UniqueId = "891afc8a-0d4c-4506-88ad-9ae891c0ed4f";
            this.gridDosyaYerleri.UseEmbeddedNavigator = true;
            this.gridDosyaYerleri.UseHyperDragDrop = false;
            this.gridDosyaYerleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.VERGI_KOD_ID,
            this.TARIFE_TARIHI,
            this.TARIFE_ORANI});
            this.gridView1.GridControl = this.gridDosyaYerleri;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Başlıkları Buraya Sürükleyin..";
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
            // VERGI_KOD_ID
            // 
            this.VERGI_KOD_ID.Caption = "Vergi Kodu";
            this.VERGI_KOD_ID.ColumnEdit = this.rlueVergiKodu;
            this.VERGI_KOD_ID.FieldName = "VERGI_KOD_ID";
            this.VERGI_KOD_ID.Name = "VERGI_KOD_ID";
            this.VERGI_KOD_ID.Visible = true;
            this.VERGI_KOD_ID.VisibleIndex = 0;
            // 
            // rlueVergiKodu
            // 
            this.rlueVergiKodu.AutoHeight = false;
            this.rlueVergiKodu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueVergiKodu.Name = "rlueVergiKodu";
            // 
            // TARIFE_TARIHI
            // 
            this.TARIFE_TARIHI.Caption = "Tarife T";
            this.TARIFE_TARIHI.ColumnEdit = this.dtTarifeT;
            this.TARIFE_TARIHI.FieldName = "TARIFE_TARIHI";
            this.TARIFE_TARIHI.Name = "TARIFE_TARIHI";
            this.TARIFE_TARIHI.Visible = true;
            this.TARIFE_TARIHI.VisibleIndex = 1;
            // 
            // dtTarifeT
            // 
            this.dtTarifeT.AutoHeight = false;
            this.dtTarifeT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTarifeT.Name = "dtTarifeT";
            this.dtTarifeT.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // TARIFE_ORANI
            // 
            this.TARIFE_ORANI.Caption = "Tarife Oran";
            this.TARIFE_ORANI.ColumnEdit = this.spTarifeOran;
            this.TARIFE_ORANI.FieldName = "TARIFE_ORANI";
            this.TARIFE_ORANI.Name = "TARIFE_ORANI";
            this.TARIFE_ORANI.Visible = true;
            this.TARIFE_ORANI.VisibleIndex = 2;
            // 
            // spTarifeOran
            // 
            this.spTarifeOran.AutoHeight = false;
            this.spTarifeOran.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spTarifeOran.Name = "spTarifeOran";
            // 
            // panelVergiOran
            // 
            this.panelVergiOran.Controls.Add(this.gridDosyaYerleri);
            this.panelVergiOran.Controls.Add(this.panelControl1);
            this.panelVergiOran.Controls.Add(this.panelControl2);
            this.panelVergiOran.Location = new System.Drawing.Point(35, 7);
            this.panelVergiOran.Name = "panelVergiOran";
            this.panelVergiOran.Size = new System.Drawing.Size(750, 360);
            this.panelVergiOran.TabIndex = 35;
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
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Vergi Oran";
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
            // frmVergiOran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 403);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelVergiOran);
            this.Name = "frmVergiOran";
            this.Text = "frmVergiOran";
            ((System.ComponentModel.ISupportInitialize)(this.gridDosyaYerleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueVergiKodu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTarifeT.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTarifeT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTarifeOran)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelVergiOran)).EndInit();
            this.panelVergiOran.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDosyaYerleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn VERGI_KOD_ID;
        private DevExpress.XtraGrid.Columns.GridColumn TARIFE_TARIHI;
        private DevExpress.XtraEditors.PanelControl panelVergiOran;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueVergiKodu;
        private DevExpress.XtraGrid.Columns.GridColumn TARIFE_ORANI;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dtTarifeT;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spTarifeOran;
    }
}