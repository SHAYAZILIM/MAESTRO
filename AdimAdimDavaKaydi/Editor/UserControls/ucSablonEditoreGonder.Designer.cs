namespace  AdimAdimDavaKaydi.Editor.UserControls
{
    partial class ucSablonEditoreGonder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSablonEditoreGonder));
            this.btnYazdir = new DevExpress.XtraEditors.SimpleButton();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.linkTakipSetiDuzenle = new System.Windows.Forms.LinkLabel();
            this.linkTakipSetiSec = new System.Windows.Forms.LinkLabel();
            this.gridControl1 = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolSec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcolAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnYazdir
            // 
            this.btnYazdir.Image = ((System.Drawing.Image)(resources.GetObject("btnYazdir.Image")));
            this.btnYazdir.Location = new System.Drawing.Point(262, 0);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new System.Drawing.Size(83, 20);
            this.btnYazdir.TabIndex = 5;
            this.btnYazdir.Text = "Yazdýr >>";
            this.btnYazdir.Click += new System.EventHandler(this.btnYazdir_Click);
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.linkTakipSetiDuzenle);
            this.popupContainerControl1.Controls.Add(this.linkTakipSetiSec);
            this.popupContainerControl1.Controls.Add(this.gridControl1);
            this.popupContainerControl1.Location = new System.Drawing.Point(3, 27);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(342, 272);
            this.popupContainerControl1.TabIndex = 4;
            // 
            // linkTakipSetiDuzenle
            // 
            this.linkTakipSetiDuzenle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkTakipSetiDuzenle.AutoSize = true;
            this.linkTakipSetiDuzenle.Location = new System.Drawing.Point(177, 7);
            this.linkTakipSetiDuzenle.Name = "linkTakipSetiDuzenle";
            this.linkTakipSetiDuzenle.Size = new System.Drawing.Size(143, 13);
            this.linkTakipSetiDuzenle.TabIndex = 2;
            this.linkTakipSetiDuzenle.TabStop = true;
            this.linkTakipSetiDuzenle.Text = "Takip Setini Yeniden Düzenle";
            // 
            // linkTakipSetiSec
            // 
            this.linkTakipSetiSec.AutoSize = true;
            this.linkTakipSetiSec.Location = new System.Drawing.Point(3, 7);
            this.linkTakipSetiSec.Name = "linkTakipSetiSec";
            this.linkTakipSetiSec.Size = new System.Drawing.Size(81, 13);
            this.linkTakipSetiSec.TabIndex = 1;
            this.linkTakipSetiSec.TabStop = true;
            this.linkTakipSetiSec.Text = "Takip Setini Seç";
            this.linkTakipSetiSec.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTakipSetiSec_LinkClicked);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.CustomButtonlarGorunmesin = false;
            this.gridControl1.DoNotExtendEmbedNavigator = false;
            this.gridControl1.FilterText = null;
            this.gridControl1.FilterValue = null;
            this.gridControl1.GridlerDuzenlenebilir = true;
            this.gridControl1.GridsFilterControl = null;
            this.gridControl1.Location = new System.Drawing.Point(0, 26);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MyGridStyle = null;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.ShowRowNumbers = false;
            this.gridControl1.SilmeKaldirilsin = false;
            this.gridControl1.Size = new System.Drawing.Size(342, 246);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.TemizleKaldirGorunsunmu = false;
            this.gridControl1.UniqueId = "a1316c65-9b08-4ae7-9f99-c432d1e2a4b7";
            this.gridControl1.UseHyperDragDrop = false;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolSec,
            this.gcolAd});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseMove);
            // 
            // gcolSec
            // 
            this.gcolSec.Caption = "Seç";
            this.gcolSec.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gcolSec.FieldName = "IsSelected";
            this.gcolSec.Name = "gcolSec";
            this.gcolSec.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.gcolSec.Visible = true;
            this.gcolSec.VisibleIndex = 1;
            this.gcolSec.Width = 47;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gcolAd
            // 
            this.gcolAd.Caption = "Ad";
            this.gcolAd.FieldName = "AD";
            this.gcolAd.Name = "gcolAd";
            this.gcolAd.OptionsColumn.AllowEdit = false;
            this.gcolAd.OptionsColumn.ReadOnly = true;
            this.gcolAd.Visible = true;
            this.gcolAd.VisibleIndex = 0;
            this.gcolAd.Width = 356;
            // 
            // popupContainerEdit1
            // 
            this.popupContainerEdit1.EditValue = "Form Hazýrlama";
            this.popupContainerEdit1.Location = new System.Drawing.Point(0, 0);
            this.popupContainerEdit1.Name = "popupContainerEdit1";
            this.popupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEdit1.Properties.CloseOnLostFocus = false;
            this.popupContainerEdit1.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.popupContainerEdit1.Properties.NullText = "Lütfen Yazýþma Seçiniz";
            this.popupContainerEdit1.Properties.PopupControl = this.popupContainerControl1;
            this.popupContainerEdit1.Properties.ShowPopupCloseButton = false;
            this.popupContainerEdit1.Size = new System.Drawing.Size(256, 20);
            this.popupContainerEdit1.TabIndex = 3;
            this.popupContainerEdit1.ToolTipTitle = "Seçilen Þablonlar";
            this.popupContainerEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.popupContainerEdit1_Closed);
            // 
            // ucSablonEditoreGonder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnYazdir);
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.popupContainerEdit1);
            this.Name = "ucSablonEditoreGonder";
            this.Size = new System.Drawing.Size(348, 20);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            this.popupContainerControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnYazdir;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcolSec;
        private DevExpress.XtraGrid.Columns.GridColumn gcolAd;
        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit1;
        private System.Windows.Forms.LinkLabel linkTakipSetiSec;
        private System.Windows.Forms.LinkLabel linkTakipSetiDuzenle;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}
