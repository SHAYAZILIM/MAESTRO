namespace  AnaForm
{
    partial class frmYazismaTurKodlari
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
            this.panelYazismaTurKodlar = new DevExpress.XtraEditors.PanelControl();
            this.gridYazismaTurkodlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.YAZISMA_TIPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rCb_YazismaTipi = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.YAZISMA_TUR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit29 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.SURET_ADEDI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit30 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit28 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelYazismaTurKodlar)).BeginInit();
            this.panelYazismaTurKodlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridYazismaTurkodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_YazismaTipi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelYazismaTurKodlar
            // 
            this.panelYazismaTurKodlar.Controls.Add(this.gridYazismaTurkodlar);
            this.panelYazismaTurKodlar.Controls.Add(this.panelControl1);
            this.panelYazismaTurKodlar.Controls.Add(this.panelControl2);
            this.panelYazismaTurKodlar.Location = new System.Drawing.Point(18, 39);
            this.panelYazismaTurKodlar.Name = "panelYazismaTurKodlar";
            this.panelYazismaTurKodlar.Size = new System.Drawing.Size(740, 368);
            this.panelYazismaTurKodlar.TabIndex = 29;
            // 
            // gridYazismaTurkodlar
            // 
            this.gridYazismaTurkodlar.CustomButtonlarGorunmesin = false;
            this.gridYazismaTurkodlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridYazismaTurkodlar.DoNotExtendEmbedNavigator = false;
            this.gridYazismaTurkodlar.FilterText = null;
            this.gridYazismaTurkodlar.FilterValue = null;
            this.gridYazismaTurkodlar.GridlerDuzenlenebilir = true;
            this.gridYazismaTurkodlar.GridsFilterControl = null;
            this.gridYazismaTurkodlar.Location = new System.Drawing.Point(2, 72);
            this.gridYazismaTurkodlar.MainView = this.gridView1;
            this.gridYazismaTurkodlar.MyGridStyle = null;
            this.gridYazismaTurkodlar.Name = "gridYazismaTurkodlar";
            this.gridYazismaTurkodlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit28,
            this.repositoryItemTextEdit29,
            this.repositoryItemTextEdit30,
            this.rCb_YazismaTipi});
            this.gridYazismaTurkodlar.ShowRowNumbers = false;
            this.gridYazismaTurkodlar.Size = new System.Drawing.Size(736, 294);
            this.gridYazismaTurkodlar.TabIndex = 5;
            this.gridYazismaTurkodlar.TemizleKaldirGorunsunmu = false;
            this.gridYazismaTurkodlar.UniqueId = "94977d43-83bd-408f-8e13-1182ffcb4ed9";
            this.gridYazismaTurkodlar.UseEmbeddedNavigator = true;
            this.gridYazismaTurkodlar.UseHyperDragDrop = false;
            this.gridYazismaTurkodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.YAZISMA_TIPI,
            this.YAZISMA_TUR,
            this.SURET_ADEDI});
            this.gridView1.GridControl = this.gridYazismaTurkodlar;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Yazýþma Türü Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // YAZISMA_TIPI
            // 
            this.YAZISMA_TIPI.Caption = "Yazýþma Tipi";
            this.YAZISMA_TIPI.ColumnEdit = this.rCb_YazismaTipi;
            this.YAZISMA_TIPI.FieldName = "YAZISMA_TIPI";
            this.YAZISMA_TIPI.Name = "YAZISMA_TIPI";
            this.YAZISMA_TIPI.Visible = true;
            this.YAZISMA_TIPI.VisibleIndex = 0;
            // 
            // rCb_YazismaTipi
            // 
            this.rCb_YazismaTipi.AutoHeight = false;
            this.rCb_YazismaTipi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_YazismaTipi.Name = "rCb_YazismaTipi";
            // 
            // YAZISMA_TUR
            // 
            this.YAZISMA_TUR.Caption = "Yazýsma Tür";
            this.YAZISMA_TUR.ColumnEdit = this.repositoryItemTextEdit29;
            this.YAZISMA_TUR.FieldName = "YAZISMA_TUR";
            this.YAZISMA_TUR.Name = "YAZISMA_TUR";
            this.YAZISMA_TUR.Visible = true;
            this.YAZISMA_TUR.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit29
            // 
            this.repositoryItemTextEdit29.AutoHeight = false;
            this.repositoryItemTextEdit29.Name = "repositoryItemTextEdit29";
            // 
            // SURET_ADEDI
            // 
            this.SURET_ADEDI.Caption = "Suret Adeti";
            this.SURET_ADEDI.ColumnEdit = this.repositoryItemTextEdit30;
            this.SURET_ADEDI.FieldName = "SURET_ADEDI";
            this.SURET_ADEDI.Name = "SURET_ADEDI";
            this.SURET_ADEDI.Visible = true;
            this.SURET_ADEDI.VisibleIndex = 2;
            // 
            // repositoryItemTextEdit30
            // 
            this.repositoryItemTextEdit30.AutoHeight = false;
            this.repositoryItemTextEdit30.Name = "repositoryItemTextEdit30";
            // 
            // repositoryItemTextEdit28
            // 
            this.repositoryItemTextEdit28.AutoHeight = false;
            this.repositoryItemTextEdit28.Name = "repositoryItemTextEdit28";
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
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Yazýþma Tür Kodlarý";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.sBtnKaydet);
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
            this.gridControlExtender1.GridControl = this.gridYazismaTurkodlar;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(736, 294);
            this.gridControlExtender1.Location = new System.Drawing.Point(525, 412);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 30;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(45, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 7;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // frmYazismaTurKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 446);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelYazismaTurKodlar);
            this.Name = "frmYazismaTurKodlari";
            this.Text = "Yazýþma Tür Kodlarý";
            ((System.ComponentModel.ISupportInitialize)(this.panelYazismaTurKodlar)).EndInit();
            this.panelYazismaTurKodlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridYazismaTurkodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_YazismaTipi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelYazismaTurKodlar;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridYazismaTurkodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn YAZISMA_TIPI;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit28;
        private DevExpress.XtraGrid.Columns.GridColumn YAZISMA_TUR;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit29;
        private DevExpress.XtraGrid.Columns.GridColumn SURET_ADEDI;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit30;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_YazismaTipi;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}