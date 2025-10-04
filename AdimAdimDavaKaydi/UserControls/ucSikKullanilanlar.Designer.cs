namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucSikKullanilanlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSikKullanilanlar));
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.yenileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.ýmageList1 = new System.Windows.Forms.ImageList(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeList1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.ImageIndexFieldName = "MODUL";
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemImageEdit1});
            this.treeList1.SelectImageList = this.ýmageList1;
            this.treeList1.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;
            this.treeList1.Size = new System.Drawing.Size(304, 422);
            this.treeList1.StateImageList = this.ýmageList1;
            this.treeList1.TabIndex = 1;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Sýk Kullanýlanlar";
            this.treeListColumn1.ColumnEdit = this.repositoryItemButtonEdit1;
            this.treeListColumn1.FieldName = "ADI";
            this.treeListColumn1.MinWidth = 35;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 345;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.ReadOnly = true;
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.düzenleToolStripMenuItem,
            this.toolStripMenuItem1,
            this.yenileToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 70);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItem1.Text = "Sil";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // yenileToolStripMenuItem
            // 
            this.yenileToolStripMenuItem.Name = "yenileToolStripMenuItem";
            this.yenileToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.yenileToolStripMenuItem.Text = "Yenile";
            this.yenileToolStripMenuItem.Click += new System.EventHandler(this.yenileToolStripMenuItem_Click);
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Images = this.ýmageList1;
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.ValidateOnEnterKey = true;
            // 
            // ýmageList1
            // 
            this.ýmageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ýmageList1.ImageStream")));
            this.ýmageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ýmageList1.Images.SetKeyName(0, "Klasor");
            this.ýmageList1.Images.SetKeyName(1, "Icra");
            this.ýmageList1.Images.SetKeyName(2, "Dava");
            this.ýmageList1.Images.SetKeyName(3, "Sorusturma");
            this.ýmageList1.Images.SetKeyName(4, "Sozlesme");
            this.ýmageList1.Images.SetKeyName(5, "CariArama");
            this.ýmageList1.Images.SetKeyName(6, "Tebligat");
            this.ýmageList1.Images.SetKeyName(7, "Gorusme");
            this.ýmageList1.Images.SetKeyName(8, "YapilacakIsler");
            this.ýmageList1.Images.SetKeyName(9, "Dava");
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
            // ucSikKullanilanlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucSikKullanilanlar";
            this.Size = new System.Drawing.Size(304, 422);
            this.Load += new System.EventHandler(this.ucSikKullanilanlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private System.Windows.Forms.ImageList ýmageList1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
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
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
    }
}
