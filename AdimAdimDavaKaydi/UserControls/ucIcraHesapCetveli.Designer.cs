namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucIcraHesapCetveli
    {
        private System.Windows.Forms.ToolStripMenuItem alanlarýGösterToolStripMenuItem;
        private System.Windows.Forms.BindingSource bndHesapCetveli;
        private System.Windows.Forms.BindingSource bndIcraFoy;
        private DevExpress.XtraEditors.SimpleButton btnDosyaKapakHesabi;
        private DevExpress.XtraEditors.SimpleButton btnHesapla;
        private DevExpress.XtraEditors.SimpleButton btnMasrafAvans;
        private DevExpress.XtraEditors.SimpleButton btnTakipSetiCikart;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbxTVUKatsayi;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colValue;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private AdimAdimDavaKaydi.Util.DataNavigatorExtended dataNavigatorExtended1;
        private DevExpress.XtraEditors.DateEdit dEditSonHesapTarihi;
        private System.Windows.Forms.ToolStripMenuItem excelEGönderToolStripMenuItem;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControl lcDosyaHesapla;
        private DevExpress.XtraLayout.LayoutControlItem lciAgaciAc;
        private DevExpress.XtraLayout.LayoutControlItem lciDosyaKapakHesabý;
        private DevExpress.XtraLayout.LayoutControlItem lciEditoreGonder;
        private DevExpress.XtraLayout.LayoutControlItem lciExceleGonder;
        private DevExpress.XtraLayout.LayoutControlItem lciMasrafAvans;
        private DevExpress.XtraLayout.LayoutControlItem lciPdfeGonder;
        private DevExpress.XtraLayout.LayoutControlItem lciRaporlamayaGonder;
        private DevExpress.XtraLayout.LayoutControlItem lciTakipSetiOlustur;
        private DevExpress.XtraLayout.LayoutControlItem lciTVUKatsayi;
        private DevExpress.XtraLayout.LayoutControlItem lciWorldeGonder;
        private LookUpExtender lookUpExtender1;
        private DevExpress.XtraEditors.LookUpEdit lueBirYilKacGun;
        private DevExpress.XtraEditors.LookUpEdit lueHesapTipiTO;
        private DevExpress.XtraEditors.LookUpEdit lueHesapTipiTS;
        private System.Windows.Forms.ToolStripMenuItem pdfEGönderToolStripMenuItem;
        private DevExpress.XtraEditors.Repository.PersistentRepository persistentRepository1;
        private System.Windows.Forms.PictureBox picWait;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkDoviz;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rudPara;
        private DevExpress.XtraEditors.SimpleButton sbtnAgaciAcKapat;
        private DevExpress.XtraEditors.SimpleButton sbtnEditoreGonder;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.SimpleButton simpleButton6;
        private DevExpress.XtraTab.XtraTabPage tabDosyaHesabi;
        private DevExpress.XtraTab.XtraTabPage tabHesapDetaylari;
        private DevExpress.XtraTab.XtraTabPage tabHesapOzeti;

        //private ucOzetHesap ucOzetHesap1;
        private DevExpress.XtraTreeList.TreeList treeHesap;

        private ucHesapDetaylari ucHesapDetaylari1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl2;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                try
                {
                    components.Dispose();
                }
                catch (System.Exception ex)
                {
                    BelgeUtil.ErrorHandler.Logger.ErrorException("Ýcra Hesap Cetveli", ex); 
                }
            }
            base.Dispose(disposing);
        }
        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucIcraHesapCetveli));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.rudPara = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.rlkDoviz = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.tabDosyaHesabi = new DevExpress.XtraTab.XtraTabPage();
            this.lcDosyaHesapla = new DevExpress.XtraLayout.LayoutControl();
            this.btnMasrafAvans = new DevExpress.XtraEditors.SimpleButton();
            this.btnDosyaKapakHesabi = new DevExpress.XtraEditors.SimpleButton();
            this.btnTakipSetiCikart = new DevExpress.XtraEditors.SimpleButton();
            this.picWait = new System.Windows.Forms.PictureBox();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.lueHesapTipiTS = new DevExpress.XtraEditors.LookUpEdit();
            this.bndIcraFoy = new System.Windows.Forms.BindingSource(this.components);
            this.sbtnEditoreGonder = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.lueBirYilKacGun = new DevExpress.XtraEditors.LookUpEdit();
            this.sbtnAgaciAcKapat = new DevExpress.XtraEditors.SimpleButton();
            this.lueHesapTipiTO = new DevExpress.XtraEditors.LookUpEdit();
            this.dEditSonHesapTarihi = new DevExpress.XtraEditors.DateEdit();
            this.treeHesap = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colValue = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bndHesapCetveli = new System.Windows.Forms.BindingSource(this.components);
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.btnHesapla = new DevExpress.XtraEditors.SimpleButton();
            this.cbxTVUKatsayi = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciAgaciAc = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciWorldeGonder = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciExceleGonder = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciRaporlamayaGonder = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPdfeGonder = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciEditoreGonder = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTakipSetiOlustur = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDosyaKapakHesabý = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciMasrafAvans = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTVUKatsayi = new DevExpress.XtraLayout.LayoutControlItem();
            this.lookUpExtender1 = new AdimAdimDavaKaydi.LookUpExtender();
            this.dataNavigatorExtended1 = new AdimAdimDavaKaydi.Util.DataNavigatorExtended();
            this.tabHesapOzeti = new DevExpress.XtraTab.XtraTabPage();
            this.tabHesapDetaylari = new DevExpress.XtraTab.XtraTabPage();
            this.ucHesapDetaylari1 = new AdimAdimDavaKaydi.UserControls.ucHesapDetaylari();
            this.persistentRepository1 = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.excelEGönderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pdfEGönderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alanlarýGösterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ucOzetHesap1 = new AdimAdimDavaKaydi.UserControls.ucOzetHesap();
            ((System.ComponentModel.ISupportInitialize)(this.rudPara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkDoviz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.tabDosyaHesabi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcDosyaHesapla)).BeginInit();
            this.lcDosyaHesapla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueHesapTipiTS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndIcraFoy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBirYilKacGun.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueHesapTipiTO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEditSonHesapTarihi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEditSonHesapTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeHesap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndHesapCetveli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxTVUKatsayi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAgaciAc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciWorldeGonder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExceleGonder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRaporlamayaGonder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPdfeGonder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEditoreGonder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTakipSetiOlustur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDosyaKapakHesabý)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMasrafAvans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTVUKatsayi)).BeginInit();
            this.tabHesapOzeti.SuspendLayout();
            this.tabHesapDetaylari.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rudPara
            // 
            this.rudPara.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rudPara.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.rudPara.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rudPara.EditFormat.FormatString = "###,###,###,###,##0.00";
            this.rudPara.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rudPara.Name = "rudPara";
            // 
            // rlkDoviz
            // 
            this.rlkDoviz.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkDoviz.Name = "rlkDoviz";
            this.rlkDoviz.NullText = "[Deðer Boþ]";
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HESAP_TIPI", "Hesap Tipi")});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl2.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.tabDosyaHesabi;
            this.xtraTabControl2.Size = new System.Drawing.Size(499, 625);
            this.xtraTabControl2.TabIndex = 7;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabHesapOzeti,
            this.tabDosyaHesabi,
            this.tabHesapDetaylari});
            this.xtraTabControl2.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.xtraTabControl2_SelectedPageChanging);
            // 
            // tabDosyaHesabi
            // 
            this.tabDosyaHesabi.Controls.Add(this.lcDosyaHesapla);
            this.tabDosyaHesabi.Controls.Add(this.lookUpExtender1);
            this.tabDosyaHesabi.Controls.Add(this.dataNavigatorExtended1);
            this.tabDosyaHesabi.Name = "tabDosyaHesabi";
            this.tabDosyaHesabi.Size = new System.Drawing.Size(493, 597);
            this.tabDosyaHesabi.Text = "Dosya Hesabý";
            // 
            // lcDosyaHesapla
            // 
            this.lcDosyaHesapla.Controls.Add(this.btnMasrafAvans);
            this.lcDosyaHesapla.Controls.Add(this.btnDosyaKapakHesabi);
            this.lcDosyaHesapla.Controls.Add(this.btnTakipSetiCikart);
            this.lcDosyaHesapla.Controls.Add(this.picWait);
            this.lcDosyaHesapla.Controls.Add(this.simpleButton4);
            this.lcDosyaHesapla.Controls.Add(this.simpleButton3);
            this.lcDosyaHesapla.Controls.Add(this.lueHesapTipiTS);
            this.lcDosyaHesapla.Controls.Add(this.sbtnEditoreGonder);
            this.lcDosyaHesapla.Controls.Add(this.simpleButton6);
            this.lcDosyaHesapla.Controls.Add(this.simpleButton5);
            this.lcDosyaHesapla.Controls.Add(this.lueBirYilKacGun);
            this.lcDosyaHesapla.Controls.Add(this.sbtnAgaciAcKapat);
            this.lcDosyaHesapla.Controls.Add(this.lueHesapTipiTO);
            this.lcDosyaHesapla.Controls.Add(this.dEditSonHesapTarihi);
            this.lcDosyaHesapla.Controls.Add(this.treeHesap);
            this.lcDosyaHesapla.Controls.Add(this.checkEdit1);
            this.lcDosyaHesapla.Controls.Add(this.btnHesapla);
            this.lcDosyaHesapla.Controls.Add(this.cbxTVUKatsayi);
            this.lcDosyaHesapla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcDosyaHesapla.Location = new System.Drawing.Point(0, 0);
            this.lcDosyaHesapla.Name = "lcDosyaHesapla";
            this.lcDosyaHesapla.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(561, 376, 250, 350);
            this.lcDosyaHesapla.Root = this.layoutControlGroup1;
            this.lcDosyaHesapla.Size = new System.Drawing.Size(493, 573);
            this.lcDosyaHesapla.TabIndex = 12;
            // 
            // btnMasrafAvans
            // 
            this.btnMasrafAvans.Image = ((System.Drawing.Image)(resources.GetObject("btnMasrafAvans.Image")));
            this.btnMasrafAvans.Location = new System.Drawing.Point(334, 509);
            this.btnMasrafAvans.Name = "btnMasrafAvans";
            this.btnMasrafAvans.Size = new System.Drawing.Size(146, 28);
            this.btnMasrafAvans.StyleController = this.lcDosyaHesapla;
            this.btnMasrafAvans.TabIndex = 28;
            this.btnMasrafAvans.Text = "Masraf Avans Ekle";
            this.btnMasrafAvans.Click += new System.EventHandler(this.btnMasrafAvans_Click);
            // 
            // btnDosyaKapakHesabi
            // 
            this.btnDosyaKapakHesabi.Appearance.Options.UseTextOptions = true;
            this.btnDosyaKapakHesabi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnDosyaKapakHesabi.Image = ((System.Drawing.Image)(resources.GetObject("btnDosyaKapakHesabi.Image")));
            this.btnDosyaKapakHesabi.Location = new System.Drawing.Point(12, 509);
            this.btnDosyaKapakHesabi.Name = "btnDosyaKapakHesabi";
            this.btnDosyaKapakHesabi.Size = new System.Drawing.Size(318, 28);
            this.btnDosyaKapakHesabi.StyleController = this.lcDosyaHesapla;
            this.btnDosyaKapakHesabi.TabIndex = 27;
            this.btnDosyaKapakHesabi.Text = "Dosya Kapak Hesabý";
            this.btnDosyaKapakHesabi.Click += new System.EventHandler(this.btnDosyaKapakHesabi_Click);
            // 
            // btnTakipSetiCikart
            // 
            this.btnTakipSetiCikart.Image = ((System.Drawing.Image)(resources.GetObject("btnTakipSetiCikart.Image")));
            this.btnTakipSetiCikart.Location = new System.Drawing.Point(334, 479);
            this.btnTakipSetiCikart.Name = "btnTakipSetiCikart";
            this.btnTakipSetiCikart.Size = new System.Drawing.Size(147, 26);
            this.btnTakipSetiCikart.StyleController = this.lcDosyaHesapla;
            this.btnTakipSetiCikart.TabIndex = 26;
            this.btnTakipSetiCikart.Text = "Takip Seti Oluþtur";
            this.btnTakipSetiCikart.Click += new System.EventHandler(this.btnTakipSetiCikart_Click);
            // 
            // picWait
            // 
            this.picWait.Location = new System.Drawing.Point(12, 541);
            this.picWait.Name = "picWait";
            this.picWait.Size = new System.Drawing.Size(469, 20);
            this.picWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picWait.TabIndex = 22;
            this.picWait.TabStop = false;
            this.picWait.Visible = false;
            // 
            // simpleButton4
            // 
            this.simpleButton4.Appearance.Options.UseTextOptions = true;
            this.simpleButton4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.simpleButton4.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton4.Image")));
            this.simpleButton4.Location = new System.Drawing.Point(334, 413);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(146, 30);
            this.simpleButton4.StyleController = this.lcDosyaHesapla;
            this.simpleButton4.TabIndex = 19;
            this.simpleButton4.Text = "Excel\'e Gönder";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Options.UseTextOptions = true;
            this.simpleButton3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.simpleButton3.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(154, 413);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(176, 30);
            this.simpleButton3.StyleController = this.lcDosyaHesapla;
            this.simpleButton3.TabIndex = 18;
            this.simpleButton3.Text = "Word\'e Gönder";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // lueHesapTipiTS
            // 
            this.lueHesapTipiTS.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "TS_HESAP_TIP_ID", true));
            this.lueHesapTipiTS.Location = new System.Drawing.Point(329, 333);
            this.lueHesapTipiTS.Name = "lueHesapTipiTS";
            this.lueHesapTipiTS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "Düzenle", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "duzenle", null, true)});
            this.lueHesapTipiTS.Size = new System.Drawing.Size(151, 20);
            this.lueHesapTipiTS.StyleController = this.lcDosyaHesapla;
            this.lueHesapTipiTS.TabIndex = 17;
            this.lueHesapTipiTS.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueHesapTipiTO_ButtonClick);
            // 
            // bndIcraFoy
            // 
            this.bndIcraFoy.DataSource = typeof(AvukatProLib2.Entities.AV001_TI_BIL_FOY);
            // 
            // sbtnEditoreGonder
            // 
            this.sbtnEditoreGonder.Appearance.Options.UseTextOptions = true;
            this.sbtnEditoreGonder.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.sbtnEditoreGonder.Image = ((System.Drawing.Image)(resources.GetObject("sbtnEditoreGonder.Image")));
            this.sbtnEditoreGonder.Location = new System.Drawing.Point(12, 479);
            this.sbtnEditoreGonder.Name = "sbtnEditoreGonder";
            this.sbtnEditoreGonder.Size = new System.Drawing.Size(318, 26);
            this.sbtnEditoreGonder.StyleController = this.lcDosyaHesapla;
            this.sbtnEditoreGonder.TabIndex = 25;
            this.sbtnEditoreGonder.Text = "Takip Çýktýlarý Ýçin Editöre Gönder";
            this.sbtnEditoreGonder.Click += new System.EventHandler(this.sbtnEditoreGonder_Click);
            // 
            // simpleButton6
            // 
            this.simpleButton6.Appearance.Options.UseTextOptions = true;
            this.simpleButton6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.simpleButton6.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton6.Image")));
            this.simpleButton6.Location = new System.Drawing.Point(12, 447);
            this.simpleButton6.Name = "simpleButton6";
            this.simpleButton6.Size = new System.Drawing.Size(318, 28);
            this.simpleButton6.StyleController = this.lcDosyaHesapla;
            this.simpleButton6.TabIndex = 21;
            this.simpleButton6.Text = "Rapor Ekranýna Gönder";
            this.simpleButton6.Click += new System.EventHandler(this.simpleButton6_Click);
            // 
            // simpleButton5
            // 
            this.simpleButton5.Appearance.Options.UseTextOptions = true;
            this.simpleButton5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.simpleButton5.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton5.Image")));
            this.simpleButton5.Location = new System.Drawing.Point(334, 447);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(146, 28);
            this.simpleButton5.StyleController = this.lcDosyaHesapla;
            this.simpleButton5.TabIndex = 20;
            this.simpleButton5.Text = "PDF\'e Gönder";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // lueBirYilKacGun
            // 
            this.lueBirYilKacGun.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "BIR_YIL_KAC_GUN", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lueBirYilKacGun.Location = new System.Drawing.Point(97, 357);
            this.lueBirYilKacGun.Name = "lueBirYilKacGun";
            this.lueBirYilKacGun.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBirYilKacGun.Size = new System.Drawing.Size(143, 20);
            this.lueBirYilKacGun.StyleController = this.lcDosyaHesapla;
            this.lueBirYilKacGun.TabIndex = 14;
            // 
            // sbtnAgaciAcKapat
            // 
            this.sbtnAgaciAcKapat.Appearance.Options.UseTextOptions = true;
            this.sbtnAgaciAcKapat.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.sbtnAgaciAcKapat.Image = ((System.Drawing.Image)(resources.GetObject("sbtnAgaciAcKapat.Image")));
            this.sbtnAgaciAcKapat.Location = new System.Drawing.Point(12, 413);
            this.sbtnAgaciAcKapat.Name = "sbtnAgaciAcKapat";
            this.sbtnAgaciAcKapat.Size = new System.Drawing.Size(138, 30);
            this.sbtnAgaciAcKapat.StyleController = this.lcDosyaHesapla;
            this.sbtnAgaciAcKapat.TabIndex = 24;
            this.sbtnAgaciAcKapat.Text = "Aðacý Aç";
            this.sbtnAgaciAcKapat.Click += new System.EventHandler(this.sbtnAgaciAcKapat_Click);
            // 
            // lueHesapTipiTO
            // 
            this.lueHesapTipiTO.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "TO_HESAP_TIP_ID", true));
            this.lueHesapTipiTO.Location = new System.Drawing.Point(97, 333);
            this.lueHesapTipiTO.Name = "lueHesapTipiTO";
            this.lueHesapTipiTO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "Düzenle", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", "duzenle", null, true)});
            this.lueHesapTipiTO.Size = new System.Drawing.Size(143, 20);
            this.lueHesapTipiTO.StyleController = this.lcDosyaHesapla;
            this.lueHesapTipiTO.TabIndex = 13;
            this.lueHesapTipiTO.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueHesapTipiTO_ButtonClick);
            // 
            // dEditSonHesapTarihi
            // 
            this.dEditSonHesapTarihi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "SON_HESAP_TARIHI", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dEditSonHesapTarihi.EditValue = null;
            this.dEditSonHesapTarihi.Location = new System.Drawing.Point(329, 357);
            this.dEditSonHesapTarihi.Name = "dEditSonHesapTarihi";
            this.dEditSonHesapTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dEditSonHesapTarihi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dEditSonHesapTarihi.Size = new System.Drawing.Size(151, 20);
            this.dEditSonHesapTarihi.StyleController = this.lcDosyaHesapla;
            this.dEditSonHesapTarihi.TabIndex = 12;
            // 
            // treeHesap
            // 
            this.treeHesap.AllowDrop = true;
            this.treeHesap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeHesap.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName,
            this.colValue});
            this.treeHesap.DataSource = this.bndHesapCetveli;
            this.treeHesap.DragNodesMode = DevExpress.XtraTreeList.TreeListDragNodesMode.Advanced;
            this.treeHesap.KeyFieldName = "Id";
            this.treeHesap.Location = new System.Drawing.Point(12, 31);
            this.treeHesap.Name = "treeHesap";
            this.treeHesap.OptionsBehavior.DragNodes = true;
            this.treeHesap.OptionsBehavior.Editable = false;
            this.treeHesap.OptionsBehavior.PopulateServiceColumns = true;
            this.treeHesap.ParentFieldName = "UstId";
            this.treeHesap.Size = new System.Drawing.Size(469, 298);
            this.treeHesap.TabIndex = 9;
            this.treeHesap.AfterExpand += new DevExpress.XtraTreeList.NodeEventHandler(this.treeHesap_AfterExpand);
            this.treeHesap.AfterCollapse += new DevExpress.XtraTreeList.NodeEventHandler(this.treeHesap_AfterCollapse);
            // 
            // colName
            // 
            this.colName.Caption = "Alacak Kalemi";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 301;
            // 
            // colValue
            // 
            this.colValue.AppearanceCell.Options.UseTextOptions = true;
            this.colValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValue.Caption = "Deðeri";
            this.colValue.FieldName = "Value";
            this.colValue.Name = "colValue";
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 1;
            this.colValue.Width = 150;
            // 
            // bndHesapCetveli
            // 
            this.bndHesapCetveli.DataSource = typeof(AvukatProLib.Hesap.HesapAraclari.IcraHesapCetveli.HesapAlani);
            // 
            // checkEdit1
            // 
            this.checkEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "BAKIYE_HARC_TOPLAMA_EKLE", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkEdit1.Location = new System.Drawing.Point(154, 381);
            this.checkEdit1.MaximumSize = new System.Drawing.Size(173, 24);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Bakiye Harç Dahil";
            this.checkEdit1.Size = new System.Drawing.Size(173, 19);
            this.checkEdit1.StyleController = this.lcDosyaHesapla;
            this.checkEdit1.TabIndex = 15;
            // 
            // btnHesapla
            // 
            this.btnHesapla.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnHesapla.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnHesapla.Appearance.Options.UseFont = true;
            this.btnHesapla.Appearance.Options.UseForeColor = true;
            this.btnHesapla.Appearance.Options.UseTextOptions = true;
            this.btnHesapla.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnHesapla.Image = ((System.Drawing.Image)(resources.GetObject("btnHesapla.Image")));
            this.btnHesapla.Location = new System.Drawing.Point(334, 381);
            this.btnHesapla.Name = "btnHesapla";
            this.btnHesapla.Size = new System.Drawing.Size(146, 28);
            this.btnHesapla.StyleController = this.lcDosyaHesapla;
            this.btnHesapla.TabIndex = 16;
            this.btnHesapla.Text = "Hesapla";
            this.btnHesapla.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // cbxTVUKatsayi
            // 
            this.cbxTVUKatsayi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndIcraFoy, "TAKIP_VEKALET_UCRETI_KATSAYI", true));
            this.cbxTVUKatsayi.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cbxTVUKatsayi.Location = new System.Drawing.Point(97, 381);
            this.cbxTVUKatsayi.Name = "cbxTVUKatsayi";
            this.cbxTVUKatsayi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxTVUKatsayi.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tam", 1D, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("3/4", 0.75D, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("1/2", 0.5D, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Yok", 0D, -1)});
            this.cbxTVUKatsayi.Properties.NullText = "[EditValue is null]";
            this.cbxTVUKatsayi.Properties.PopupSizeable = true;
            this.cbxTVUKatsayi.Size = new System.Drawing.Size(53, 20);
            this.cbxTVUKatsayi.StyleController = this.lcDosyaHesapla;
            this.cbxTVUKatsayi.TabIndex = 29;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.layoutControlItem7,
            this.lciAgaciAc,
            this.lciWorldeGonder,
            this.lciExceleGonder,
            this.layoutControlItem2,
            this.layoutControlItem8,
            this.lciRaporlamayaGonder,
            this.lciPdfeGonder,
            this.lciEditoreGonder,
            this.lciTakipSetiOlustur,
            this.layoutControlItem9,
            this.layoutControlItem6,
            this.layoutControlItem4,
            this.lciDosyaKapakHesabý,
            this.lciMasrafAvans,
            this.lciTVUKatsayi});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(493, 573);
            this.layoutControlGroup1.Text = "Dosya Bazýnda Hesap Deðerleri";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.treeHesap;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(473, 302);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(473, 302);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(473, 302);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lueHesapTipiTO;
            this.layoutControlItem5.CustomizationFormText = "Hesap Tipi";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 302);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(232, 24);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(232, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(232, 24);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "T. Ö. Hesap Tipi:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.checkEdit1;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(142, 350);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(180, 32);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(180, 32);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(180, 32);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // lciAgaciAc
            // 
            this.lciAgaciAc.Control = this.sbtnAgaciAcKapat;
            this.lciAgaciAc.CustomizationFormText = "layoutControlItem3";
            this.lciAgaciAc.Location = new System.Drawing.Point(0, 382);
            this.lciAgaciAc.MaxSize = new System.Drawing.Size(142, 34);
            this.lciAgaciAc.MinSize = new System.Drawing.Size(142, 34);
            this.lciAgaciAc.Name = "lciAgaciAc";
            this.lciAgaciAc.Size = new System.Drawing.Size(142, 34);
            this.lciAgaciAc.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciAgaciAc.Text = "lciAgaciAc";
            this.lciAgaciAc.TextSize = new System.Drawing.Size(0, 0);
            this.lciAgaciAc.TextToControlDistance = 0;
            this.lciAgaciAc.TextVisible = false;
            // 
            // lciWorldeGonder
            // 
            this.lciWorldeGonder.Control = this.simpleButton3;
            this.lciWorldeGonder.CustomizationFormText = "layoutControlItem10";
            this.lciWorldeGonder.Location = new System.Drawing.Point(142, 382);
            this.lciWorldeGonder.MaxSize = new System.Drawing.Size(180, 34);
            this.lciWorldeGonder.MinSize = new System.Drawing.Size(180, 34);
            this.lciWorldeGonder.Name = "lciWorldeGonder";
            this.lciWorldeGonder.Size = new System.Drawing.Size(180, 34);
            this.lciWorldeGonder.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciWorldeGonder.Text = "lciWorldeGonder";
            this.lciWorldeGonder.TextSize = new System.Drawing.Size(0, 0);
            this.lciWorldeGonder.TextToControlDistance = 0;
            this.lciWorldeGonder.TextVisible = false;
            // 
            // lciExceleGonder
            // 
            this.lciExceleGonder.Control = this.simpleButton4;
            this.lciExceleGonder.CustomizationFormText = "layoutControlItem11";
            this.lciExceleGonder.Location = new System.Drawing.Point(322, 382);
            this.lciExceleGonder.MaxSize = new System.Drawing.Size(150, 34);
            this.lciExceleGonder.MinSize = new System.Drawing.Size(150, 34);
            this.lciExceleGonder.Name = "lciExceleGonder";
            this.lciExceleGonder.Size = new System.Drawing.Size(151, 34);
            this.lciExceleGonder.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciExceleGonder.Text = "lciExceleGonder";
            this.lciExceleGonder.TextSize = new System.Drawing.Size(0, 0);
            this.lciExceleGonder.TextToControlDistance = 0;
            this.lciExceleGonder.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.picWait;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 510);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(473, 24);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnHesapla;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(322, 350);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(150, 32);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(150, 32);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(151, 32);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // lciRaporlamayaGonder
            // 
            this.lciRaporlamayaGonder.Control = this.simpleButton6;
            this.lciRaporlamayaGonder.CustomizationFormText = "layoutControlItem13";
            this.lciRaporlamayaGonder.Location = new System.Drawing.Point(0, 416);
            this.lciRaporlamayaGonder.MaxSize = new System.Drawing.Size(322, 32);
            this.lciRaporlamayaGonder.MinSize = new System.Drawing.Size(322, 32);
            this.lciRaporlamayaGonder.Name = "lciRaporlamayaGonder";
            this.lciRaporlamayaGonder.Size = new System.Drawing.Size(322, 32);
            this.lciRaporlamayaGonder.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciRaporlamayaGonder.Text = "lciRaporlamayaGonder";
            this.lciRaporlamayaGonder.TextSize = new System.Drawing.Size(0, 0);
            this.lciRaporlamayaGonder.TextToControlDistance = 0;
            this.lciRaporlamayaGonder.TextVisible = false;
            // 
            // lciPdfeGonder
            // 
            this.lciPdfeGonder.Control = this.simpleButton5;
            this.lciPdfeGonder.CustomizationFormText = "layoutControlItem12";
            this.lciPdfeGonder.Location = new System.Drawing.Point(322, 416);
            this.lciPdfeGonder.MaxSize = new System.Drawing.Size(150, 32);
            this.lciPdfeGonder.MinSize = new System.Drawing.Size(150, 32);
            this.lciPdfeGonder.Name = "lciPdfeGonder";
            this.lciPdfeGonder.Size = new System.Drawing.Size(151, 32);
            this.lciPdfeGonder.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciPdfeGonder.Text = "lciPdfeGonder";
            this.lciPdfeGonder.TextSize = new System.Drawing.Size(0, 0);
            this.lciPdfeGonder.TextToControlDistance = 0;
            this.lciPdfeGonder.TextVisible = false;
            // 
            // lciEditoreGonder
            // 
            this.lciEditoreGonder.Control = this.sbtnEditoreGonder;
            this.lciEditoreGonder.CustomizationFormText = "lciEditoreGonder";
            this.lciEditoreGonder.Location = new System.Drawing.Point(0, 448);
            this.lciEditoreGonder.MaxSize = new System.Drawing.Size(322, 30);
            this.lciEditoreGonder.MinSize = new System.Drawing.Size(322, 30);
            this.lciEditoreGonder.Name = "lciEditoreGonder";
            this.lciEditoreGonder.Size = new System.Drawing.Size(322, 30);
            this.lciEditoreGonder.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciEditoreGonder.Text = "lciEditoreGonder";
            this.lciEditoreGonder.TextSize = new System.Drawing.Size(0, 0);
            this.lciEditoreGonder.TextToControlDistance = 0;
            this.lciEditoreGonder.TextVisible = false;
            this.lciEditoreGonder.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lciTakipSetiOlustur
            // 
            this.lciTakipSetiOlustur.Control = this.btnTakipSetiCikart;
            this.lciTakipSetiOlustur.CustomizationFormText = "lciTakipSetiOlustur";
            this.lciTakipSetiOlustur.Location = new System.Drawing.Point(322, 448);
            this.lciTakipSetiOlustur.MaxSize = new System.Drawing.Size(151, 30);
            this.lciTakipSetiOlustur.MinSize = new System.Drawing.Size(151, 30);
            this.lciTakipSetiOlustur.Name = "lciTakipSetiOlustur";
            this.lciTakipSetiOlustur.Size = new System.Drawing.Size(151, 30);
            this.lciTakipSetiOlustur.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciTakipSetiOlustur.Text = "lciTakipSetiOlustur";
            this.lciTakipSetiOlustur.TextSize = new System.Drawing.Size(0, 0);
            this.lciTakipSetiOlustur.TextToControlDistance = 0;
            this.lciTakipSetiOlustur.TextVisible = false;
            this.lciTakipSetiOlustur.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.lueHesapTipiTS;
            this.layoutControlItem9.CustomizationFormText = "Takip Sonrasý Hesap Tipi";
            this.layoutControlItem9.Location = new System.Drawing.Point(232, 302);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(240, 24);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(240, 24);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(241, 24);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "T. S. Hesap Tipi:";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lueBirYilKacGun;
            this.layoutControlItem6.CustomizationFormText = "Bir Yýl Kaç Gün";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 326);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(232, 24);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(232, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(232, 24);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "Bir Yýl Kaç Gün";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dEditSonHesapTarihi;
            this.layoutControlItem4.CustomizationFormText = "Son Hesap Tarihi";
            this.layoutControlItem4.Location = new System.Drawing.Point(232, 326);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(240, 24);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(240, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(241, 24);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Son Hesap Tarihi";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(81, 13);
            // 
            // lciDosyaKapakHesabý
            // 
            this.lciDosyaKapakHesabý.Control = this.btnDosyaKapakHesabi;
            this.lciDosyaKapakHesabý.CustomizationFormText = "layoutControlItem3";
            this.lciDosyaKapakHesabý.Location = new System.Drawing.Point(0, 478);
            this.lciDosyaKapakHesabý.MaxSize = new System.Drawing.Size(322, 32);
            this.lciDosyaKapakHesabý.MinSize = new System.Drawing.Size(322, 32);
            this.lciDosyaKapakHesabý.Name = "lciDosyaKapakHesabý";
            this.lciDosyaKapakHesabý.Size = new System.Drawing.Size(322, 32);
            this.lciDosyaKapakHesabý.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciDosyaKapakHesabý.Text = "lciDosyaKapakHesabý";
            this.lciDosyaKapakHesabý.TextSize = new System.Drawing.Size(0, 0);
            this.lciDosyaKapakHesabý.TextToControlDistance = 0;
            this.lciDosyaKapakHesabý.TextVisible = false;
            // 
            // lciMasrafAvans
            // 
            this.lciMasrafAvans.Control = this.btnMasrafAvans;
            this.lciMasrafAvans.CustomizationFormText = "layoutControlItem10";
            this.lciMasrafAvans.Location = new System.Drawing.Point(322, 478);
            this.lciMasrafAvans.MaxSize = new System.Drawing.Size(150, 32);
            this.lciMasrafAvans.MinSize = new System.Drawing.Size(150, 32);
            this.lciMasrafAvans.Name = "lciMasrafAvans";
            this.lciMasrafAvans.Size = new System.Drawing.Size(151, 32);
            this.lciMasrafAvans.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciMasrafAvans.Text = "lciMasrafAvans";
            this.lciMasrafAvans.TextSize = new System.Drawing.Size(0, 0);
            this.lciMasrafAvans.TextToControlDistance = 0;
            this.lciMasrafAvans.TextVisible = false;
            // 
            // lciTVUKatsayi
            // 
            this.lciTVUKatsayi.Control = this.cbxTVUKatsayi;
            this.lciTVUKatsayi.CustomizationFormText = "T.V.Ü. Katsayýsý:";
            this.lciTVUKatsayi.Location = new System.Drawing.Point(0, 350);
            this.lciTVUKatsayi.MinSize = new System.Drawing.Size(50, 25);
            this.lciTVUKatsayi.Name = "lciTVUKatsayi";
            this.lciTVUKatsayi.Size = new System.Drawing.Size(142, 32);
            this.lciTVUKatsayi.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciTVUKatsayi.Text = "T.V.Ü. Katsayýsý:";
            this.lciTVUKatsayi.TextSize = new System.Drawing.Size(81, 13);
            // 
            // lookUpExtender1
            // 
            this.lookUpExtender1.AddLookUp = null;
            this.lookUpExtender1.AddRepoLookUp = null;
            this.lookUpExtender1.Location = new System.Drawing.Point(311, 529);
            this.lookUpExtender1.LookUpEditCollection = new DevExpress.XtraEditors.LookUpEdit[0];
            this.lookUpExtender1.Name = "lookUpExtender1";
            this.lookUpExtender1.RemoveLookUp = null;
            this.lookUpExtender1.RemoveRepoLookUp = null;
            this.lookUpExtender1.RepoLookUpEditCollection = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit[] {
        this.repositoryItemLookUpEdit2};
            this.lookUpExtender1.Size = new System.Drawing.Size(75, 23);
            this.lookUpExtender1.TabIndex = 8;
            this.lookUpExtender1.Text = "lookUpExtender1";
            this.lookUpExtender1.Visible = false;
            // 
            // dataNavigatorExtended1
            // 
            this.dataNavigatorExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigatorExtended1.Location = new System.Drawing.Point(0, 573);
            this.dataNavigatorExtended1.MyChartControl = null;
            this.dataNavigatorExtended1.MyGridControl = null;
            this.dataNavigatorExtended1.MyPivotGridControl = null;
            this.dataNavigatorExtended1.MyVGridControl = null;
            this.dataNavigatorExtended1.Name = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.SelectButtonVisible = false;
            this.dataNavigatorExtended1.Size = new System.Drawing.Size(493, 24);
            this.dataNavigatorExtended1.TabIndex = 7;
            this.dataNavigatorExtended1.Text = "dataNavigatorExtended1";
            // 
            // tabHesapOzeti
            // 
            this.tabHesapOzeti.Controls.Add(this.ucOzetHesap1);
            this.tabHesapOzeti.Name = "tabHesapOzeti";
            this.tabHesapOzeti.Size = new System.Drawing.Size(493, 597);
            this.tabHesapOzeti.Text = "Hesap Özeti";
            // 
            // tabHesapDetaylari
            // 
            this.tabHesapDetaylari.Controls.Add(this.ucHesapDetaylari1);
            this.tabHesapDetaylari.Name = "tabHesapDetaylari";
            this.tabHesapDetaylari.Size = new System.Drawing.Size(493, 597);
            this.tabHesapDetaylari.Text = "Hesap Detaylarý";
            // 
            // ucHesapDetaylari1
            // 
            this.ucHesapDetaylari1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucHesapDetaylari1.EkleKaldirButonuGizle = false;
            this.ucHesapDetaylari1.Location = new System.Drawing.Point(0, 0);
            this.ucHesapDetaylari1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucHesapDetaylari1.Name = "ucHesapDetaylari1";
            this.ucHesapDetaylari1.Size = new System.Drawing.Size(493, 597);
            this.ucHesapDetaylari1.TabIndex = 0;
            // 
            // persistentRepository1
            // 
            this.persistentRepository1.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlkDoviz,
            this.rudPara});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelEGönderToolStripMenuItem,
            this.pdfEGönderToolStripMenuItem,
            this.alanlarýGösterToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(152, 70);
            // 
            // excelEGönderToolStripMenuItem
            // 
            this.excelEGönderToolStripMenuItem.Name = "excelEGönderToolStripMenuItem";
            this.excelEGönderToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.excelEGönderToolStripMenuItem.Text = "Excel e gönder";
            // 
            // pdfEGönderToolStripMenuItem
            // 
            this.pdfEGönderToolStripMenuItem.Name = "pdfEGönderToolStripMenuItem";
            this.pdfEGönderToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.pdfEGönderToolStripMenuItem.Text = "Pdf e gönder";
            // 
            // alanlarýGösterToolStripMenuItem
            // 
            this.alanlarýGösterToolStripMenuItem.Name = "alanlarýGösterToolStripMenuItem";
            this.alanlarýGösterToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.alanlarýGösterToolStripMenuItem.Text = "Alanlarý Göster";
            // 
            // ucOzetHesap1
            // 
            this.ucOzetHesap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucOzetHesap1.HesabiGuncelle = false;
            this.ucOzetHesap1.Location = new System.Drawing.Point(0, 0);
            this.ucOzetHesap1.MyDataSource = null;
            this.ucOzetHesap1.MyProje = null;
            this.ucOzetHesap1.Name = "ucOzetHesap1";
            this.ucOzetHesap1.SetBaslikGrubu = AdimAdimDavaKaydi.UserControls.ucOzetHesap.BaslikGruplari.Dosya;
            this.ucOzetHesap1.Size = new System.Drawing.Size(493, 597);
            this.ucOzetHesap1.TabIndex = 0;
            // 
            // ucIcraHesapCetveli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl2);
            this.Name = "ucIcraHesapCetveli";
            this.Size = new System.Drawing.Size(499, 625);
            this.Tag = "H";
            this.Load += new System.EventHandler(this.ucHesapCetveli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rudPara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkDoviz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.tabDosyaHesabi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcDosyaHesapla)).EndInit();
            this.lcDosyaHesapla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueHesapTipiTS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndIcraFoy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBirYilKacGun.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueHesapTipiTO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEditSonHesapTarihi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEditSonHesapTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeHesap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndHesapCetveli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxTVUKatsayi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAgaciAc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciWorldeGonder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExceleGonder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRaporlamayaGonder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPdfeGonder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEditoreGonder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTakipSetiOlustur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDosyaKapakHesabý)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMasrafAvans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTVUKatsayi)).EndInit();
            this.tabHesapOzeti.ResumeLayout(false);
            this.tabHesapDetaylari.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ucOzetHesap ucOzetHesap1;
    }
}
