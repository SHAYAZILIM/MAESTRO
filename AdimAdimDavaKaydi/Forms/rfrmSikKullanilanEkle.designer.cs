namespace  AdimAdimDavaKaydi.Forms
{
    partial class rfrmSikKullanilanEkle
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.txtKategoriAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnKatEkle = new DevExpress.XtraEditors.SimpleButton();
            this.txtAciklama = new DevExpress.XtraEditors.MemoExEdit();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.txtAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            
            
            
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKategoriAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mrqEnAlt
            // 
            
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.clientPanel);
            this.c_pnlContainer.Size = new System.Drawing.Size(574, 437);
            this.c_pnlContainer.Controls.SetChildIndex(this.clientPanel, 0);
 
            // 
            // c_pnlAltButtons
            // 
 
 
            // 
            // c_btnIptal
            // 
 
            // 
            // c_btnTamam
            // 
 
            // 
            // prgEnAlt
            // 
            // 
            // c_btnYardim
            // 
 
 
 
 
 
 
 
 
 
 
 
 
 
            // 
            // c_btnCaption
            // 
 
 
 
 
 
 
 
 
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = null;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 6;
            this.ribbon.Name = "ribbon";
            this.ribbon.Size = new System.Drawing.Size(507, 20);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "barButtonItem5";
            this.barButtonItem5.Id = 5;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 437);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(507, 24);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.groupControl1);
            this.clientPanel.Controls.Add(this.txtAciklama);
            this.clientPanel.Controls.Add(this.btnKaydet);
            this.clientPanel.Controls.Add(this.txtAdi);
            this.clientPanel.Controls.Add(this.labelControl3);
            this.clientPanel.Controls.Add(this.labelControl1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 0);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(574, 437);
            this.clientPanel.TabIndex = 2;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.treeList1);
            this.groupControl1.Controls.Add(this.txtKategoriAdi);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.btnKatEkle);
            this.groupControl1.Location = new System.Drawing.Point(21, 64);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(532, 332);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "Kategori";
            // 
            // treeList1
            // 
            this.treeList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeList1.Location = new System.Drawing.Point(5, 23);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsView.ShowCheckBoxes = true;
            this.treeList1.Size = new System.Drawing.Size(522, 244);
            this.treeList1.TabIndex = 0;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Kategori Adı";
            this.treeListColumn1.FieldName = "ADI";
            this.treeListColumn1.MinWidth = 51;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Tarihi";
            this.treeListColumn2.FieldName = "Tarih";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            // 
            // txtKategoriAdi
            // 
            this.txtKategoriAdi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKategoriAdi.Location = new System.Drawing.Point(73, 274);
            this.txtKategoriAdi.Name = "txtKategoriAdi";
            this.txtKategoriAdi.Size = new System.Drawing.Size(454, 20);
            this.txtKategoriAdi.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Location = new System.Drawing.Point(9, 277);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(58, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Kategori Adı";
            // 
            // btnKatEkle
            // 
            this.btnKatEkle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKatEkle.Location = new System.Drawing.Point(413, 300);
            this.btnKatEkle.Name = "btnKatEkle";
            this.btnKatEkle.Size = new System.Drawing.Size(103, 23);
            this.btnKatEkle.TabIndex = 3;
            this.btnKatEkle.Text = "Kategori Ekle";
            this.btnKatEkle.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(94, 35);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtAciklama.Size = new System.Drawing.Size(145, 20);
            this.txtAciklama.TabIndex = 11;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(247, 33);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 10;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // txtAdi
            // 
            this.txtAdi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdi.Location = new System.Drawing.Point(94, 7);
            this.txtAdi.Name = "txtAdi";
            this.txtAdi.Size = new System.Drawing.Size(459, 20);
            this.txtAdi.TabIndex = 8;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(30, 39);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(41, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Açıklama";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(19, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "İsim";
            // 
            // rfrmSikKullanilanEkle
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 491);
            this.Name = "rfrmSikKullanilanEkle";
            this.Text = "Sık Kullanılan Ekle";
            this.UstMenu = true;
           // this.Load += new System.EventHandler(this.rfrmSikKullanilanEkle_Load);
 
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
 
 
 
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            this.clientPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKategoriAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.SimpleButton btnKatEkle;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraEditors.MemoExEdit txtAciklama;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraEditors.TextEdit txtKategoriAdi;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtAdi;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}