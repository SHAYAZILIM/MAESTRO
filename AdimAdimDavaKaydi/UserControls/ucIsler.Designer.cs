namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucIsler
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucIsler));
            DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.yenileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgListIsler = new System.Windows.Forms.ImageList(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.bButonBelgeEkle = new DevExpress.XtraBars.BarButtonItem();
            this.bButonIsEkle = new DevExpress.XtraBars.BarButtonItem();
            this.bButonHatirlatmaEkle = new DevExpress.XtraBars.BarButtonItem();
            this.bButtonNotEkle = new DevExpress.XtraBars.BarButtonItem();
            this.bButonKisayolEkle = new DevExpress.XtraBars.BarButtonItem();
            this.bButtonGorusmeEkle = new DevExpress.XtraBars.BarButtonItem();
            this.bButtonSikKullanilan = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnSorusturma = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.bBtnIcraEkle = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnDavaEkle = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnSorusturmaEkle = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnSozlesmeEkle = new DevExpress.XtraBars.BarButtonItem();
            this.bBSahis = new DevExpress.XtraBars.BarButtonItem();
            this.bBTemsilEkle = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.treeView1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "treeListColumn2";
            this.treeListColumn2.FieldName = "IsYapildimi";
            this.treeListColumn2.Name = "treeListColumn2";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.yenileToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(114, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.toolStripMenuItem1.Text = "Sil";
            // 
            // yenileToolStripMenuItem
            // 
            this.yenileToolStripMenuItem.Name = "yenileToolStripMenuItem";
            this.yenileToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.yenileToolStripMenuItem.Text = "Yenile";
            this.yenileToolStripMenuItem.Click += new System.EventHandler(this.yenileToolStripMenuItem_Click);
            // 
            // imgListIsler
            // 
            this.imgListIsler.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListIsler.ImageStream")));
            this.imgListIsler.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListIsler.Images.SetKeyName(0, "Evvelki Gün");
            this.imgListIsler.Images.SetKeyName(1, "Dün");
            this.imgListIsler.Images.SetKeyName(2, "Bugün");
            this.imgListIsler.Images.SetKeyName(3, "Yarýn");
            this.imgListIsler.Images.SetKeyName(4, "Öbür Gün");
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barSubItem1,
            this.bBtnSorusturma,
            this.bButonBelgeEkle,
            this.bButonIsEkle,
            this.bButonHatirlatmaEkle,
            this.bButtonNotEkle,
            this.bButonKisayolEkle,
            this.bButtonGorusmeEkle,
            this.barButtonItem5,
            this.barSubItem2,
            this.bBtnIcraEkle,
            this.bBtnDavaEkle,
            this.bBtnSorusturmaEkle,
            this.bBtnSozlesmeEkle,
            this.barButtonItem2,
            this.bBSahis,
            this.bBTemsilEkle,
            this.barButtonItem3,
            this.bButtonSikKullanilan,
            this.barButtonItem4,
            this.barButtonItem6});
            this.barManager1.MaxItemId = 25;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Bu Kayda Ekle";
            this.barSubItem1.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_16x16;
            this.barSubItem1.Id = 4;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bButonBelgeEkle),
            new DevExpress.XtraBars.LinkPersistInfo(this.bButonIsEkle),
            new DevExpress.XtraBars.LinkPersistInfo(this.bButonHatirlatmaEkle),
            new DevExpress.XtraBars.LinkPersistInfo(this.bButtonNotEkle),
            new DevExpress.XtraBars.LinkPersistInfo(this.bButonKisayolEkle),
            new DevExpress.XtraBars.LinkPersistInfo(this.bButtonGorusmeEkle),
            new DevExpress.XtraBars.LinkPersistInfo(this.bButtonSikKullanilan)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // bButonBelgeEkle
            // 
            this.bButonBelgeEkle.Caption = "Belge";
            this.bButonBelgeEkle.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.belgeler12x12;
            this.bButonBelgeEkle.Id = 6;
            this.bButonBelgeEkle.Name = "bButonBelgeEkle";
            // 
            // bButonIsEkle
            // 
            this.bButonIsEkle.Caption = "Ýþ";
            this.bButonIsEkle.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.Gorevler_12x12;
            this.bButonIsEkle.Id = 7;
            this.bButonIsEkle.Name = "bButonIsEkle";
            // 
            // bButonHatirlatmaEkle
            // 
            this.bButonHatirlatmaEkle.Caption = "Hatýrlatma";
            this.bButonHatirlatmaEkle.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.bell;
            this.bButonHatirlatmaEkle.Id = 8;
            this.bButonHatirlatmaEkle.Name = "bButonHatirlatmaEkle";
            // 
            // bButtonNotEkle
            // 
            this.bButtonNotEkle.Caption = "Not";
            this.bButtonNotEkle.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.note_edit1;
            this.bButtonNotEkle.Id = 9;
            this.bButtonNotEkle.Name = "bButtonNotEkle";
            // 
            // bButonKisayolEkle
            // 
            this.bButonKisayolEkle.Caption = "Masaüstüne Kýsayol";
            this.bButonKisayolEkle.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.masa_ustu16x16;
            this.bButonKisayolEkle.Id = 10;
            this.bButonKisayolEkle.Name = "bButonKisayolEkle";
            // 
            // bButtonGorusmeEkle
            // 
            this.bButtonGorusmeEkle.Caption = "Görüþme";
            this.bButtonGorusmeEkle.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.telefonla_gorusme1;
            this.bButtonGorusmeEkle.Id = 11;
            this.bButtonGorusmeEkle.Name = "bButtonGorusmeEkle";
            // 
            // bButtonSikKullanilan
            // 
            this.bButtonSikKullanilan.Caption = "Sýk Kullanýlanlara Ekle";
            this.bButtonSikKullanilan.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.favorite_add_22x221;
            this.bButtonSikKullanilan.Id = 22;
            this.bButtonSikKullanilan.Name = "bButtonSikKullanilan";
            // 
            // bBtnSorusturma
            // 
            this.bBtnSorusturma.Caption = "Soruþturma";
            this.bBtnSorusturma.Id = 5;
            this.bBtnSorusturma.Name = "bBtnSorusturma";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Yeni";
            this.barButtonItem5.Id = 12;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Yeni";
            this.barSubItem2.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.yeni_16x16;
            this.barSubItem2.Id = 13;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnIcraEkle),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnDavaEkle),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnSorusturmaEkle),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnSozlesmeEkle),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBSahis),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBTemsilEkle)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // bBtnIcraEkle
            // 
            this.bBtnIcraEkle.Caption = "Ýcra Dosyasý";
            this.bBtnIcraEkle.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.Icra_Islemleri_12x12;
            this.bBtnIcraEkle.Id = 14;
            this.bBtnIcraEkle.Name = "bBtnIcraEkle";
            // 
            // bBtnDavaEkle
            // 
            this.bBtnDavaEkle.Caption = "Dava Dosyasý";
            this.bBtnDavaEkle.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.Dava_22x221;
            this.bBtnDavaEkle.Id = 15;
            this.bBtnDavaEkle.Name = "bBtnDavaEkle";
            // 
            // bBtnSorusturmaEkle
            // 
            this.bBtnSorusturmaEkle.Caption = "Soruþturma";
            this.bBtnSorusturmaEkle.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.savcilik_16x16;
            this.bBtnSorusturmaEkle.Id = 16;
            this.bBtnSorusturmaEkle.Name = "bBtnSorusturmaEkle";
            // 
            // bBtnSozlesmeEkle
            // 
            this.bBtnSozlesmeEkle.Caption = "Sözleþme";
            this.bBtnSozlesmeEkle.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.sozlesme_12x121;
            this.bBtnSozlesmeEkle.Id = 17;
            this.bBtnSozlesmeEkle.Name = "bBtnSozlesmeEkle";
            // 
            // bBSahis
            // 
            this.bBSahis.Caption = "Þahýs";
            this.bBSahis.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.personel_isleri1;
            this.bBSahis.Id = 19;
            this.bBSahis.Name = "bBSahis";
            // 
            // bBTemsilEkle
            // 
            this.bBTemsilEkle.Caption = "Temsil Belgesi";
            this.bBTemsilEkle.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.temsil_16x16;
            this.bBTemsilEkle.Id = 20;
            this.bBTemsilEkle.Name = "bBTemsilEkle";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 18;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 21;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 23;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Sil";
            this.barButtonItem6.Id = 24;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem6)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // treeView1
            // 
            this.treeView1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout);
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.treeListColumn2;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = true;
            this.treeView1.FormatConditions.AddRange(new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition[] {
            styleFormatCondition1});
            this.treeView1.ImageIndexFieldName = "imageIndex";
            this.treeView1.KeyFieldName = "Id";
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.treeView1.OptionsView.ShowPreview = true;
            this.treeView1.ParentFieldName = "ParentId";
            this.treeView1.PreviewFieldName = "YapilacakIs";
            this.treeView1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.treeView1.SelectImageList = this.imgListIsler;
            this.treeView1.Size = new System.Drawing.Size(304, 422);
            this.treeView1.TabIndex = 5;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.ColumnEdit = this.repositoryItemMemoEdit1;
            this.treeListColumn1.FieldName = "AD";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // ucIsler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucIsler";
            this.Size = new System.Drawing.Size(304, 422);
            this.Load += new System.EventHandler(this.ucSikKullanilanlar_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgListIsler;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem bButonBelgeEkle;
        private DevExpress.XtraBars.BarButtonItem bButonIsEkle;
        private DevExpress.XtraBars.BarButtonItem bButonHatirlatmaEkle;
        private DevExpress.XtraBars.BarButtonItem bButtonNotEkle;
        private DevExpress.XtraBars.BarButtonItem bButonKisayolEkle;
        private DevExpress.XtraBars.BarButtonItem bButtonGorusmeEkle;
        private DevExpress.XtraBars.BarButtonItem bButtonSikKullanilan;
        private DevExpress.XtraBars.BarButtonItem bBtnSorusturma;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem bBtnIcraEkle;
        private DevExpress.XtraBars.BarButtonItem bBtnDavaEkle;
        private DevExpress.XtraBars.BarButtonItem bBtnSorusturmaEkle;
        private DevExpress.XtraBars.BarButtonItem bBtnSozlesmeEkle;
        private DevExpress.XtraBars.BarButtonItem bBSahis;
        private DevExpress.XtraBars.BarButtonItem bBTemsilEkle;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem yenileToolStripMenuItem;
        private DevExpress.XtraTreeList.TreeList treeView1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
    }
}
