namespace  AnaForm
{
    partial class frmTeminatMektupKonulari
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
            this.panelTeminatMektupKonular = new DevExpress.XtraEditors.PanelControl();
            this.gridTeminatMektupKonulari = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.KONU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit58 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTeminatMektupKonular)).BeginInit();
            this.panelTeminatMektupKonular.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeminatMektupKonulari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTeminatMektupKonular
            // 
            this.panelTeminatMektupKonular.Controls.Add(this.gridTeminatMektupKonulari);
            this.panelTeminatMektupKonular.Controls.Add(this.panelControl1);
            this.panelTeminatMektupKonular.Controls.Add(this.panelControl2);
            this.panelTeminatMektupKonular.Location = new System.Drawing.Point(12, 12);
            this.panelTeminatMektupKonular.Name = "panelTeminatMektupKonular";
            this.panelTeminatMektupKonular.Size = new System.Drawing.Size(750, 360);
            this.panelTeminatMektupKonular.TabIndex = 45;
            // 
            // gridTeminatMektupKonulari
            // 
            this.gridTeminatMektupKonulari.CustomButtonlarGorunmesin = false;
            this.gridTeminatMektupKonulari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTeminatMektupKonulari.DoNotExtendEmbedNavigator = false;
            this.gridTeminatMektupKonulari.FilterText = null;
            this.gridTeminatMektupKonulari.FilterValue = null;
            this.gridTeminatMektupKonulari.GridlerDuzenlenebilir = true;
            this.gridTeminatMektupKonulari.GridsFilterControl = null;
            this.gridTeminatMektupKonulari.Location = new System.Drawing.Point(2, 72);
            this.gridTeminatMektupKonulari.MainView = this.gridView1;
            this.gridTeminatMektupKonulari.MyGridStyle = null;
            this.gridTeminatMektupKonulari.Name = "gridTeminatMektupKonulari";
            this.gridTeminatMektupKonulari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit58});
            this.gridTeminatMektupKonulari.ShowRowNumbers = false;
            this.gridTeminatMektupKonulari.Size = new System.Drawing.Size(746, 286);
            this.gridTeminatMektupKonulari.TabIndex = 5;
            this.gridTeminatMektupKonulari.TemizleKaldirGorunsunmu = false;
            this.gridTeminatMektupKonulari.UniqueId = "34882005-12a5-4356-828f-b0947b4519c4";
            this.gridTeminatMektupKonulari.UseEmbeddedNavigator = true;
            this.gridTeminatMektupKonulari.UseHyperDragDrop = false;
            this.gridTeminatMektupKonulari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.KONU});
            this.gridView1.GridControl = this.gridTeminatMektupKonulari;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Teminat Mektup Konusu Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // KONU
            // 
            this.KONU.Caption = "Teminat Mektup Konusu";
            this.KONU.ColumnEdit = this.repositoryItemTextEdit58;
            this.KONU.FieldName = "KONU";
            this.KONU.Name = "KONU";
            this.KONU.Visible = true;
            this.KONU.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit58
            // 
            this.repositoryItemTextEdit58.AutoHeight = false;
            this.repositoryItemTextEdit58.Name = "repositoryItemTextEdit58";
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
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Teminat Mektup Konularý";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.sBtnKaydet);
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
            this.gridControlExtender1.GridControl = this.gridTeminatMektupKonulari;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(479, 379);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 46;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(76, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 7;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // frmTeminatMektupKonulari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 463);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelTeminatMektupKonular);
            this.Name = "frmTeminatMektupKonulari";
            this.Text = "Teminat Mektup Konularý";
            ((System.ComponentModel.ISupportInitialize)(this.panelTeminatMektupKonular)).EndInit();
            this.panelTeminatMektupKonular.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTeminatMektupKonulari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTeminatMektupKonular;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTeminatMektupKonulari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn KONU;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit58;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}