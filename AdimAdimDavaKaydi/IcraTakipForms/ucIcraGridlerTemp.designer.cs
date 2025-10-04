using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AdimAdimDavaKaydi.Is.UserControls;
using AvukatProLib.Extras;
using AvukatProLib.Util;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    partial class ucIcraGridlerTemp
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
            if (AuthHelperBase.loadedControlList.Contains(this.Name)) AuthHelperBase.loadedControlList.Remove(this.Name);
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        System.ComponentModel.ComponentResourceManager resources;
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources1 = new System.ComponentModel.ComponentResourceManager(typeof(ucIcraGridlerTemp));
            resources = resources1;
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.xtraTabControl9 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage3 = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabPage2 = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.rLueMalKategoriID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueMalTurID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueMalCinsID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueDovizTipID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueMallar = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rLueCariID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueSatisIstenmeSekliID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueSatisTuruID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rSpinTutarID = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.rLueMallarID = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.checkButton1 = new DevExpress.XtraEditors.CheckButton();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.ucZTrackBar1 = new AdimAdimDavaKaydi.ucZTrackBar();
            this.tabGridler = new DevExpress.XtraTab.XtraTabControl();
            this.tbMalBeyani = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabBorclununMallari = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabMalBeyan = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabArastırmaIleTespit = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tbOdeme = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl3 = new DevExpress.XtraTab.XtraTabControl();
            this.tabBorcluOdemeler = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabFeragat = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabMahsup = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabOdemeDagilimi = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tbItiraz = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl8 = new DevExpress.XtraTab.XtraTabControl();
            this.tabItirazlar = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabSikayetler = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tbGorusmeVeIletisim = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl12 = new DevExpress.XtraTab.XtraTabControl();
            this.tabGorusmeler = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabSMS = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabEmail = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tbDegisikIsler = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl5 = new DevExpress.XtraTab.XtraTabControl();
            this.tbIhtHaciz = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tbIhtTedbir = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tbDusmeYenileme = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tbTaahhutler = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tbHacizIslemleri = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tbSatis = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tbBos = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tbIadeAlinmamisTeminatlar = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tbAlacaklar = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl7 = new DevExpress.XtraTab.XtraTabControl();
            this.tpAlacaklar = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl11 = new DevExpress.XtraTab.XtraTabControl();
            this.tabAlacaklar = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabKefalet = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tpKiymetliEvrak = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabCntrlKiymetliEvrak = new DevExpress.XtraTab.XtraTabControl();
            this.tabPKiymetliEvrakGrid = new DevExpress.XtraTab.XtraTabPage();
            this.tabPKiymetliEvrakTaraf = new DevExpress.XtraTab.XtraTabPage();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.tpSozlesme = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl13 = new DevExpress.XtraTab.XtraTabControl();
            this.tabPSozlesmeBilgileri = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabpGayrimenkulArac = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabPageMenkulMal = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tbGelismeler = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tbTakipAsama = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tbDosyaBaglantilari = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.c_tpGorevler = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tbMehilBilgileri = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabHasarVePolice = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl4 = new DevExpress.XtraTab.XtraTabControl();
            this.tabHasar = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabPolice = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabDokumanlar = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl10 = new DevExpress.XtraTab.XtraTabControl();
            this.c_tpBelge = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabDosyaMuhasebesi = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl14 = new DevExpress.XtraTab.XtraTabControl();
            this.tabMasraflar = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabMuvekkilHesabı = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.xTabDosyaOzeti = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xTabMuvekkilOdeme = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xTabVekaletSozlesme = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xTabMeslekMakbuzu = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xTabVekaletIsSozlesme = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xTabMuvekkMuh = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xTabControlMuvekkilMuhasebe = new DevExpress.XtraTab.XtraTabControl();
            this.xTabPageMuvDosyaHesabi = new DevExpress.XtraTab.XtraTabPage();
            this.xTabPageMuvTumHesap = new DevExpress.XtraTab.XtraTabPage();
            //this.tabHEsapEkstre = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabTebligatGelenGidenEvrak = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabPMuvekkilTalimat = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabpSozlesme = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabpTakipHikayesi = new DevExpress.XtraTab.XtraTabPage();
            this.tabpIcraTalimatlari = new DevExpress.XtraTab.XtraTabPage();
            this.ucTrackBar1 = new AdimAdimDavaKaydi.ucTrackBar();
            this.compTabKaydir1 = new AdimAdimDavaKaydi.Util.compTabKaydir(this.components);
            this.tabIcraDosyasiMuhasebesi = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl9)).BeginInit();
            this.xtraTabControl9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMalKategoriID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMalTurID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMalCinsID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizTipID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMallar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCariID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSatisIstenmeSekliID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSatisTuruID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSpinTutarID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMallarID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabGridler)).BeginInit();
            this.tabGridler.SuspendLayout();
            this.tbMalBeyani.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tbOdeme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl3)).BeginInit();
            this.xtraTabControl3.SuspendLayout();
            this.tbItiraz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl8)).BeginInit();
            this.xtraTabControl8.SuspendLayout();
            this.tbGorusmeVeIletisim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl12)).BeginInit();
            this.xtraTabControl12.SuspendLayout();
            this.tbDegisikIsler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl5)).BeginInit();
            this.xtraTabControl5.SuspendLayout();
            this.tbAlacaklar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl7)).BeginInit();
            this.xtraTabControl7.SuspendLayout();
            this.tpAlacaklar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl11)).BeginInit();
            this.xtraTabControl11.SuspendLayout();
            this.tpKiymetliEvrak.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabCntrlKiymetliEvrak)).BeginInit();
            this.tabCntrlKiymetliEvrak.SuspendLayout();
            this.tpSozlesme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl13)).BeginInit();
            this.xtraTabControl13.SuspendLayout();
            this.tabpGayrimenkulArac.SuspendLayout();
            this.tabHasarVePolice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl4)).BeginInit();
            this.xtraTabControl4.SuspendLayout();
            this.tabDokumanlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl10)).BeginInit();
            this.xtraTabControl10.SuspendLayout();
            this.tabDosyaMuhasebesi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl14)).BeginInit();
            this.xtraTabControl14.SuspendLayout();
            this.tabMuvekkilHesabı.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xTabMuvekkMuh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xTabControlMuvekkilMuhasebe)).BeginInit();
            this.xTabControlMuvekkilMuhasebe.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            resources.ApplyResources(this.splitContainerControl1, "splitContainerControl1");
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.xtraTabControl9);
            resources.ApplyResources(this.splitContainerControl1.Panel1, "splitContainerControl1.Panel1");
            resources.ApplyResources(this.splitContainerControl1.Panel2, "splitContainerControl1.Panel2");
            this.splitContainerControl1.SplitterPosition = 201;
            // 
            // xtraTabControl9
            // 
            resources.ApplyResources(this.xtraTabControl9, "xtraTabControl9");
            this.xtraTabControl9.Name = "xtraTabControl9";
            this.xtraTabControl9.SelectedTabPage = this.xtraTabPage3;
            this.xtraTabControl9.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Name = "xtraTabPage3";
            resources.ApplyResources(this.xtraTabPage3, "xtraTabPage3");
            this.xtraTabPage3.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            resources.ApplyResources(this.xtraTabPage2, "xtraTabPage2");
            this.xtraTabPage2.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // rLueMalKategoriID
            // 
            resources.ApplyResources(this.rLueMalKategoriID, "rLueMalKategoriID");
            this.rLueMalKategoriID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueMalKategoriID.Buttons"))))});
            this.rLueMalKategoriID.Name = "rLueMalKategoriID";
            // 
            // rLueMalTurID
            // 
            resources.ApplyResources(this.rLueMalTurID, "rLueMalTurID");
            this.rLueMalTurID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueMalTurID.Buttons"))))});
            this.rLueMalTurID.Name = "rLueMalTurID";
            // 
            // rLueMalCinsID
            // 
            resources.ApplyResources(this.rLueMalCinsID, "rLueMalCinsID");
            this.rLueMalCinsID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueMalCinsID.Buttons"))))});
            this.rLueMalCinsID.Name = "rLueMalCinsID";
            // 
            // rLueDovizTipID
            // 
            resources.ApplyResources(this.rLueDovizTipID, "rLueDovizTipID");
            this.rLueDovizTipID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueDovizTipID.Buttons"))))});
            this.rLueDovizTipID.Name = "rLueDovizTipID";
            // 
            // rLueMallar
            // 
            resources.ApplyResources(this.rLueMallar, "rLueMallar");
            this.rLueMallar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueMallar.Buttons"))))});
            this.rLueMallar.Name = "rLueMallar";
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueCariID,
            this.rLueSatisIstenmeSekliID,
            this.rLueSatisTuruID,
            this.rLueMalKategoriID,
            this.rLueMalTurID,
            this.rLueMalCinsID,
            this.rLueDovizTipID,
            this.repositoryItemLookUpEdit8,
            this.rSpinTutarID,
            this.rLueMallarID,
            this.rLueMallar});
            // 
            // rLueCariID
            // 
            resources.ApplyResources(this.rLueCariID, "rLueCariID");
            this.rLueCariID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueCariID.Buttons"))))});
            this.rLueCariID.Name = "rLueCariID";
            // 
            // rLueSatisIstenmeSekliID
            // 
            resources.ApplyResources(this.rLueSatisIstenmeSekliID, "rLueSatisIstenmeSekliID");
            this.rLueSatisIstenmeSekliID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueSatisIstenmeSekliID.Buttons"))))});
            this.rLueSatisIstenmeSekliID.Name = "rLueSatisIstenmeSekliID";
            // 
            // rLueSatisTuruID
            // 
            resources.ApplyResources(this.rLueSatisTuruID, "rLueSatisTuruID");
            this.rLueSatisTuruID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueSatisTuruID.Buttons"))))});
            this.rLueSatisTuruID.Name = "rLueSatisTuruID";
            // 
            // repositoryItemLookUpEdit8
            // 
            resources.ApplyResources(this.repositoryItemLookUpEdit8, "repositoryItemLookUpEdit8");
            this.repositoryItemLookUpEdit8.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemLookUpEdit8.Buttons"))))});
            this.repositoryItemLookUpEdit8.Name = "repositoryItemLookUpEdit8";
            // 
            // rSpinTutarID
            // 
            resources.ApplyResources(this.rSpinTutarID, "rSpinTutarID");
            this.rSpinTutarID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rSpinTutarID.Name = "rSpinTutarID";
            // 
            // rLueMallarID
            // 
            resources.ApplyResources(this.rLueMallarID, "rLueMallarID");
            this.rLueMallarID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueMallarID.Buttons"))))});
            this.rLueMallarID.Name = "rLueMallarID";
            this.rLueMallarID.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.checkButton1);
            this.panelControl1.Controls.Add(this.popupContainerControl1);
            this.panelControl1.Controls.Add(this.popupContainerEdit1);
            this.panelControl1.Controls.Add(this.ucZTrackBar1);
            this.panelControl1.Controls.Add(this.ucTrackBar1);
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Name = "panelControl1";
            // 
            // checkButton1
            // 
            resources.ApplyResources(this.checkButton1, "checkButton1");
            this.checkButton1.Name = "checkButton1";
            this.checkButton1.CheckedChanged += new System.EventHandler(this.checkButton1_CheckedeklenenChanged);
            // 
            // popupContainerControl1
            // 
            resources.ApplyResources(this.popupContainerControl1, "popupContainerControl1");
            this.popupContainerControl1.Name = "popupContainerControl1";
            // 
            // popupContainerEdit1
            // 
            resources.ApplyResources(this.popupContainerEdit1, "popupContainerEdit1");
            this.popupContainerEdit1.Name = "popupContainerEdit1";
            this.popupContainerEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.popupContainerEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.popupContainerEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Transparent;
            serializableAppearanceObject1.BackColor2 = System.Drawing.Color.Transparent;
            serializableAppearanceObject1.BorderColor = System.Drawing.Color.Transparent;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject1.Options.UseBorderColor = true;
            serializableAppearanceObject1.Options.UseImage = true;
            this.popupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("popupContainerEdit1.Properties.Buttons"))), resources.GetString("popupContainerEdit1.Properties.Buttons1"), ((int)(resources.GetObject("popupContainerEdit1.Properties.Buttons2"))), ((bool)(resources.GetObject("popupContainerEdit1.Properties.Buttons3"))), ((bool)(resources.GetObject("popupContainerEdit1.Properties.Buttons4"))), ((bool)(resources.GetObject("popupContainerEdit1.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("popupContainerEdit1.Properties.Buttons6"))), global::AdimAdimDavaKaydi.Properties.Resources.wrench1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("popupContainerEdit1.Properties.Buttons7"), null, null, ((bool)(resources.GetObject("popupContainerEdit1.Properties.Buttons8"))))});
            this.popupContainerEdit1.Properties.CloseOnLostFocus = false;
            this.popupContainerEdit1.Properties.CloseOnOuterMouseClick = false;
            this.popupContainerEdit1.Properties.PopupControl = this.popupContainerControl1;
            // 
            // ucZTrackBar1
            // 
            resources.ApplyResources(this.ucZTrackBar1, "ucZTrackBar1");
            this.ucZTrackBar1.MyTabControl = this.tabGridler;
            this.ucZTrackBar1.Name = "ucZTrackBar1";
            // 
            // tabGridler
            // 
            this.tabGridler.AllowDrop = true;
            this.tabGridler.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabGridler.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.tabGridler, "tabGridler");
            this.tabGridler.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.tabGridler.Name = "tabGridler";
            this.tabGridler.SelectedTabPage = this.tbBos;
            this.tabGridler.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tbAlacaklar,
            this.tbDegisikIsler,
            this.tbDosyaBaglantilari,
            this.tabDokumanlar,
            this.tbDusmeYenileme,
            this.tbGelismeler,
            this.tbBos,
            this.tbIadeAlinmamisTeminatlar,
            this.tbHacizIslemleri,
            this.tabHasarVePolice,
            this.tabpIcraTalimatlari,
            this.tbGorusmeVeIletisim,
            this.c_tpGorevler,
            this.tbItiraz,
            this.tbMalBeyani,
            this.tabDosyaMuhasebesi,
            this.tbMehilBilgileri,
            this.tabPMuvekkilTalimat,
            this.tbOdeme,
            this.tbSatis,
            this.tbTaahhutler,
            this.tbTakipAsama,
            this.tabpTakipHikayesi,
            this.tabTebligatGelenGidenEvrak,
            this.tabpSozlesme

            });
            this.tabGridler.Selected += new DevExpress.XtraTab.TabPageEventHandler(this.tabGridler_Selected);
            // 
            // tbMalBeyani
            // 
            this.tbMalBeyani.Controls.Add(this.xtraTabControl1);
            resources.ApplyResources(this.tbMalBeyani, "tbMalBeyani");
            this.tbMalBeyani.Name = "tbMalBeyani";
            this.tbMalBeyani.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // xtraTabControl1
            // 
            resources.ApplyResources(this.xtraTabControl1, "xtraTabControl1");
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabBorclununMallari;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabMalBeyan,
            this.tabBorclununMallari,
            this.tabArastırmaIleTespit});
            // 
            // tabBorclununMallari
            // 
            this.tabBorclununMallari.Name = "tabBorclununMallari";
            resources.ApplyResources(this.tabBorclununMallari, "tabBorclununMallari");
            this.tabBorclununMallari.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabMalBeyan
            // 
            this.tabMalBeyan.Name = "tabMalBeyan";
            resources.ApplyResources(this.tabMalBeyan, "tabMalBeyan");
            this.tabMalBeyan.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabArastırmaIleTespit
            // 
            this.tabArastırmaIleTespit.Name = "tabArastırmaIleTespit";
            resources.ApplyResources(this.tabArastırmaIleTespit, "tabArastırmaIleTespit");
            this.tabArastırmaIleTespit.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tbOdeme
            // 
            this.tbOdeme.Controls.Add(this.xtraTabControl3);
            resources.ApplyResources(this.tbOdeme, "tbOdeme");
            this.tbOdeme.Name = "tbOdeme";
            this.tbOdeme.TabKulakRenk = System.Drawing.Color.Empty;
            this.tbOdeme.Tag = "2";
            // 
            // xtraTabControl3
            // 
            resources.ApplyResources(this.xtraTabControl3, "xtraTabControl3");
            this.xtraTabControl3.Name = "xtraTabControl3";
            this.xtraTabControl3.SelectedTabPage = this.tabBorcluOdemeler;
            this.xtraTabControl3.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabBorcluOdemeler,
            this.tabFeragat,
            this.tabMahsup,
            this.tabOdemeDagilimi});
            // 
            // tabBorcluOdemeler
            // 
            this.tabBorcluOdemeler.Name = "tabBorcluOdemeler";
            resources.ApplyResources(this.tabBorcluOdemeler, "tabBorcluOdemeler");
            this.tabBorcluOdemeler.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabFeragat
            // 
            this.tabFeragat.Name = "tabFeragat";
            resources.ApplyResources(this.tabFeragat, "tabFeragat");
            this.tabFeragat.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabMahsup
            // 
            this.tabMahsup.Name = "tabMahsup";
            resources.ApplyResources(this.tabMahsup, "tabMahsup");
            this.tabMahsup.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabOdemeDagilimi
            // 
            this.tabOdemeDagilimi.Name = "tabOdemeDagilimi";
            resources.ApplyResources(this.tabOdemeDagilimi, "tabOdemeDagilimi");
            this.tabOdemeDagilimi.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tbItiraz
            // 
            this.tbItiraz.Controls.Add(this.xtraTabControl8);
            resources.ApplyResources(this.tbItiraz, "tbItiraz");
            this.tbItiraz.Name = "tbItiraz";
            this.tbItiraz.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // xtraTabControl8
            // 
            resources.ApplyResources(this.xtraTabControl8, "xtraTabControl8");
            this.xtraTabControl8.Name = "xtraTabControl8";
            this.xtraTabControl8.SelectedTabPage = this.tabItirazlar;
            this.xtraTabControl8.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabItirazlar,
            this.tabSikayetler});
            // 
            // tabItirazlar
            // 
            this.tabItirazlar.Name = "tabItirazlar";
            resources.ApplyResources(this.tabItirazlar, "tabItirazlar");
            this.tabItirazlar.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabSikayetler
            // 
            this.tabSikayetler.Name = "tabSikayetler";
            resources.ApplyResources(this.tabSikayetler, "tabSikayetler");
            this.tabSikayetler.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tbGorusmeVeIletisim
            // 
            this.tbGorusmeVeIletisim.Controls.Add(this.xtraTabControl12);
            resources.ApplyResources(this.tbGorusmeVeIletisim, "tbGorusmeVeIletisim");
            this.tbGorusmeVeIletisim.Name = "tbGorusmeVeIletisim";
            this.tbGorusmeVeIletisim.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // xtraTabControl12
            // 
            resources.ApplyResources(this.xtraTabControl12, "xtraTabControl12");
            this.xtraTabControl12.Name = "xtraTabControl12";
            this.xtraTabControl12.SelectedTabPage = this.tabGorusmeler;
            this.xtraTabControl12.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabGorusmeler,
            this.tabSMS,
            this.tabEmail});
            // 
            // tabGorusmeler
            // 
            this.tabGorusmeler.Name = "tabGorusmeler";
            resources.ApplyResources(this.tabGorusmeler, "tabGorusmeler");
            this.tabGorusmeler.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabSMS
            // 
            this.tabSMS.Name = "tabSMS";
            this.tabSMS.PageVisible = false;
            resources.ApplyResources(this.tabSMS, "tabSMS");
            this.tabSMS.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabEmail
            // 
            this.tabEmail.Name = "tabEmail";
            this.tabEmail.PageVisible = false;
            resources.ApplyResources(this.tabEmail, "tabEmail");
            this.tabEmail.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tbDegisikIsler
            // 
            this.tbDegisikIsler.Controls.Add(this.xtraTabControl5);
            this.tbDegisikIsler.Name = "tbDegisikIsler";
            resources.ApplyResources(this.tbDegisikIsler, "tbDegisikIsler");
            this.tbDegisikIsler.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // xtraTabControl5
            // 
            resources.ApplyResources(this.xtraTabControl5, "xtraTabControl5");
            this.xtraTabControl5.Name = "xtraTabControl5";
            this.xtraTabControl5.SelectedTabPage = this.tbIhtHaciz;
            this.xtraTabControl5.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tbIhtHaciz,
            this.tbIhtTedbir});
            // 
            // tbIhtHaciz
            // 
            this.tbIhtHaciz.Name = "tbIhtHaciz";
            resources.ApplyResources(this.tbIhtHaciz, "tbIhtHaciz");
            this.tbIhtHaciz.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tbIhtTedbir
            // 
            this.tbIhtTedbir.Name = "tbIhtTedbir";
            resources.ApplyResources(this.tbIhtTedbir, "tbIhtTedbir");
            this.tbIhtTedbir.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tbDusmeYenileme
            // 
            this.tbDusmeYenileme.Name = "tbDusmeYenileme";
            resources.ApplyResources(this.tbDusmeYenileme, "tbDusmeYenileme");
            this.tbDusmeYenileme.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tbTaahhutler
            // 
            this.tbTaahhutler.Name = "tbTaahhutler";
            resources.ApplyResources(this.tbTaahhutler, "tbTaahhutler");
            this.tbTaahhutler.TabKulakRenk = System.Drawing.Color.Empty;
            this.tbTaahhutler.Tag = "1";
            // 
            // tbHacizIslemleri
            // 
            this.tbHacizIslemleri.Name = "tbHacizIslemleri";
            resources.ApplyResources(this.tbHacizIslemleri, "tbHacizIslemleri");
            this.tbHacizIslemleri.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tbSatis
            // 
            this.tbSatis.Name = "tbSatis";
            resources.ApplyResources(this.tbSatis, "tbSatis");
            this.tbSatis.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tbBos
            // 
            this.tbBos.Name = "tbBos";
            resources.ApplyResources(this.tbBos, "tbBos");
            this.tbBos.TabKulakRenk = System.Drawing.Color.Empty;
            //
            //tbIadeAlinmamisTeminatlar
            //
            this.tbIadeAlinmamisTeminatlar.Name = "tbIadeAlinmamisTeminatlar";
            this.tbIadeAlinmamisTeminatlar.Text = "İade Alınmamış Teminatlar";
            resources.ApplyResources(this.tbIadeAlinmamisTeminatlar, "tbIadeAlinmamisTeminatlar");
            this.tbIadeAlinmamisTeminatlar.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tbAlacaklar
            // 
            this.tbAlacaklar.Controls.Add(this.xtraTabControl7);
            resources.ApplyResources(this.tbAlacaklar, "tbAlacaklar");
            this.tbAlacaklar.Name = "tbAlacaklar";
            this.tbAlacaklar.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // xtraTabControl7
            // 
            resources.ApplyResources(this.xtraTabControl7, "xtraTabControl7");
            this.xtraTabControl7.Name = "xtraTabControl7";
            this.xtraTabControl7.SelectedTabPage = this.tpAlacaklar;
            this.xtraTabControl7.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpAlacaklar,
            this.tpKiymetliEvrak,
            this.tpSozlesme});
            // 
            // tpAlacaklar
            // 
            this.tpAlacaklar.Controls.Add(this.xtraTabControl11);
            this.tpAlacaklar.Name = "tpAlacaklar";
            resources.ApplyResources(this.tpAlacaklar, "tpAlacaklar");
            this.tpAlacaklar.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // xtraTabControl11
            // 
            resources.ApplyResources(this.xtraTabControl11, "xtraTabControl11");
            this.xtraTabControl11.Name = "xtraTabControl11";
            this.xtraTabControl11.SelectedTabPage = this.tabAlacaklar;
            this.xtraTabControl11.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabAlacaklar,
            this.tabKefalet});
            // 
            // tabAlacaklar
            // 
            this.tabAlacaklar.Name = "tabAlacaklar";
            resources.ApplyResources(this.tabAlacaklar, "tabAlacaklar");
            this.tabAlacaklar.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabKefalet
            // 
            this.tabKefalet.Name = "tabKefalet";
            resources.ApplyResources(this.tabKefalet, "tabKefalet");
            this.tabKefalet.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tpKiymetliEvrak
            // 
            this.tpKiymetliEvrak.Controls.Add(this.tabCntrlKiymetliEvrak);
            this.tpKiymetliEvrak.Controls.Add(this.splitterControl1);
            this.tpKiymetliEvrak.Name = "tpKiymetliEvrak";
            resources.ApplyResources(this.tpKiymetliEvrak, "tpKiymetliEvrak");
            this.tpKiymetliEvrak.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabCntrlKiymetliEvrak
            // 
            resources.ApplyResources(this.tabCntrlKiymetliEvrak, "tabCntrlKiymetliEvrak");
            this.tabCntrlKiymetliEvrak.Name = "tabCntrlKiymetliEvrak";
            this.tabCntrlKiymetliEvrak.SelectedTabPage = this.tabPKiymetliEvrakGrid;
            this.tabCntrlKiymetliEvrak.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPKiymetliEvrakGrid,
            this.tabPKiymetliEvrakTaraf});
            // 
            // tabPKiymetliEvrakGrid
            // 
            this.tabPKiymetliEvrakGrid.Name = "tabPKiymetliEvrakGrid";
            resources.ApplyResources(this.tabPKiymetliEvrakGrid, "tabPKiymetliEvrakGrid");
            // 
            // tabPKiymetliEvrakTaraf
            // 
            this.tabPKiymetliEvrakTaraf.Name = "tabPKiymetliEvrakTaraf";
            resources.ApplyResources(this.tabPKiymetliEvrakTaraf, "tabPKiymetliEvrakTaraf");
            // 
            // splitterControl1
            // 
            resources.ApplyResources(this.splitterControl1, "splitterControl1");
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.TabStop = false;
            // 
            // tpSozlesme
            // 
            this.tpSozlesme.Controls.Add(this.xtraTabControl13);
            this.tpSozlesme.Name = "tpSozlesme";
            resources.ApplyResources(this.tpSozlesme, "tpSozlesme");
            this.tpSozlesme.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // xtraTabControl13
            // 
            resources.ApplyResources(this.xtraTabControl13, "xtraTabControl13");
            this.xtraTabControl13.Name = "xtraTabControl13";
            this.xtraTabControl13.SelectedTabPage = this.tabPSozlesmeBilgileri;
            this.xtraTabControl13.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPSozlesmeBilgileri,
            this.tabpGayrimenkulArac,
            this.tabPageMenkulMal});
            // 
            // tabPSozlesmeBilgileri
            // 
            this.tabPSozlesmeBilgileri.Name = "tabPSozlesmeBilgileri";
            resources.ApplyResources(this.tabPSozlesmeBilgileri, "tabPSozlesmeBilgileri");
            this.tabPSozlesmeBilgileri.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabpGayrimenkulArac
            // 
            this.tabpGayrimenkulArac.Controls.Add(this.splitContainerControl1);
            this.tabpGayrimenkulArac.Name = "tabpGayrimenkulArac";
            resources.ApplyResources(this.tabpGayrimenkulArac, "tabpGayrimenkulArac");
            this.tabpGayrimenkulArac.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabPageMenkulMal
            // 
            this.tabPageMenkulMal.Name = "tabPageMenkulMal";
            resources.ApplyResources(this.tabPageMenkulMal, "tabPageMenkulMal");
            this.tabPageMenkulMal.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tbGelismeler
            // 
            this.tbGelismeler.Name = "tbGelismeler";
            resources.ApplyResources(this.tbGelismeler, "tbGelismeler");
            this.tbGelismeler.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tbTakipAsama
            // 
            this.tbTakipAsama.Name = "tbTakipAsama";
            this.tbTakipAsama.PageVisible = true;
            resources.ApplyResources(this.tbTakipAsama, "tbTakipAsama");
            this.tbTakipAsama.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tbDosyaBaglantilari
            // 
            resources.ApplyResources(this.tbDosyaBaglantilari, "tbDosyaBaglantilari");
            this.tbDosyaBaglantilari.Name = "tbDosyaBaglantilari";
            this.tbDosyaBaglantilari.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // c_tpGorevler
            // 
            this.c_tpGorevler.Name = "c_tpGorevler";
            resources.ApplyResources(this.c_tpGorevler, "c_tpGorevler");
            this.c_tpGorevler.TabKulakRenk = System.Drawing.Color.Empty;
            this.c_tpGorevler.Text = "İş Emirleri";
            // 
            // tbMehilBilgileri
            // 
            this.tbMehilBilgileri.Name = "tbMehilBilgileri";
            resources.ApplyResources(this.tbMehilBilgileri, "tbMehilBilgileri");
            this.tbMehilBilgileri.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabHasarVePolice
            // 
            this.tabHasarVePolice.Controls.Add(this.xtraTabControl4);
            this.tabHasarVePolice.Name = "tabHasarVePolice";
            resources.ApplyResources(this.tabHasarVePolice, "tabHasarVePolice");
            this.tabHasarVePolice.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // xtraTabControl4
            // 
            resources.ApplyResources(this.xtraTabControl4, "xtraTabControl4");
            this.xtraTabControl4.Name = "xtraTabControl4";
            this.xtraTabControl4.SelectedTabPage = this.tabHasar;
            this.xtraTabControl4.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabHasar,
            this.tabPolice});
            // 
            // tabHasar
            // 
            this.tabHasar.Name = "tabHasar";
            this.tabHasar.PageVisible = false;
            resources.ApplyResources(this.tabHasar, "tabHasar");
            this.tabHasar.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabPolice
            // 
            this.tabPolice.Name = "tabPolice";
            resources.ApplyResources(this.tabPolice, "tabPolice");
            this.tabPolice.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabDokumanlar
            // 
            this.tabDokumanlar.Controls.Add(this.xtraTabControl10);
            this.tabDokumanlar.Name = "tabDokumanlar";
            this.tabDokumanlar.Text = "Dokümanlar";
            resources.ApplyResources(this.tabDokumanlar, "tabDokumanlar");
            this.tabDokumanlar.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // xtraTabControl10
            // 
            resources.ApplyResources(this.xtraTabControl10, "xtraTabControl10");
            this.xtraTabControl10.Name = "xtraTabControl10";
            this.xtraTabControl10.SelectedTabPage = this.c_tpBelge;
            this.xtraTabControl10.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.c_tpBelge});
            // 
            // c_tpBelge
            // 
            this.c_tpBelge.Name = "c_tpBelge";
            resources.ApplyResources(this.c_tpBelge, "c_tpBelge");
            this.c_tpBelge.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabDosyaMuhasebesi
            // 
            this.tabDosyaMuhasebesi.Controls.Add(this.xtraTabControl14);
            this.tabDosyaMuhasebesi.Name = "tabDosyaMuhasebesi";
            resources.ApplyResources(this.tabDosyaMuhasebesi, "tabDosyaMuhasebesi");
            this.tabDosyaMuhasebesi.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // xtraTabControl14
            // 
            resources.ApplyResources(this.xtraTabControl14, "xtraTabControl14");
            this.xtraTabControl14.Name = "xtraTabControl14";
            this.xtraTabControl14.SelectedTabPage = this.tabMasraflar;
            this.xtraTabControl14.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabMuvekkilHesabı,
            this.tabMasraflar,
            this.tabIcraDosyasiMuhasebesi});
            // 
            // tabIcraDosyasiMuhasebesi
            // 
            this.tabIcraDosyasiMuhasebesi.Name = "tabIcraDosyasiMuhasebesi";
            resources.ApplyResources(this.tabIcraDosyasiMuhasebesi, "tabIcraDosyasiMuhasebesi");
            this.tabIcraDosyasiMuhasebesi.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabIcraDosyasiMuhasebesi.Text = "İcra Dosyası Muhasebesi";
            // 
            // tabMasraflar
            // 
            this.tabMasraflar.Name = "tabMasraflar";
            resources.ApplyResources(this.tabMasraflar, "tabMasraflar");
            this.tabMasraflar.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabMuvekkilHesabı
            // 
            this.tabMuvekkilHesabı.Controls.Add(this.xtraTabControl2);
            this.tabMuvekkilHesabı.Name = "tabMuvekkilHesabı";
            resources.ApplyResources(this.tabMuvekkilHesabı, "tabMuvekkilHesabı");
            this.tabMuvekkilHesabı.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // xtraTabControl2
            // 
            resources.ApplyResources(this.xtraTabControl2, "xtraTabControl2");
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.xTabDosyaOzeti;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xTabDosyaOzeti,
            this.xTabMuvekkilOdeme,
            this.xTabVekaletSozlesme,
            this.xTabMeslekMakbuzu,
            this.xTabVekaletIsSozlesme,
            this.xTabMuvekkMuh});
            // 
            // xTabDosyaOzeti
            // 
            this.xTabDosyaOzeti.Name = "xTabDosyaOzeti";
            resources.ApplyResources(this.xTabDosyaOzeti, "xTabDosyaOzeti");
            this.xTabDosyaOzeti.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // xTabMuvekkilOdeme
            // 
            this.xTabMuvekkilOdeme.Name = "xTabMuvekkilOdeme";
            resources.ApplyResources(this.xTabMuvekkilOdeme, "xTabMuvekkilOdeme");
            this.xTabMuvekkilOdeme.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // xTabVekaletSozlesme
            // 
            this.xTabVekaletSozlesme.Name = "xTabVekaletSozlesme";
            resources.ApplyResources(this.xTabVekaletSozlesme, "xTabVekaletSozlesme");
            this.xTabVekaletSozlesme.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // xTabMeslekMakbuzu
            // 
            this.xTabMeslekMakbuzu.Name = "xTabMeslekMakbuzu";
            resources.ApplyResources(this.xTabMeslekMakbuzu, "xTabMeslekMakbuzu");
            this.xTabMeslekMakbuzu.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // xTabVekaletIsSozlesme
            // 
            this.xTabVekaletIsSozlesme.Name = "xTabVekaletIsSozlesme";
            this.xTabVekaletIsSozlesme.PageVisible = false;
            resources.ApplyResources(this.xTabVekaletIsSozlesme, "xTabVekaletIsSozlesme");
            this.xTabVekaletIsSozlesme.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // xTabMuvekkMuh
            // 
            this.xTabMuvekkMuh.Controls.Add(this.xTabControlMuvekkilMuhasebe);
            this.xTabMuvekkMuh.Name = "xTabMuvekkMuh";
            resources.ApplyResources(this.xTabMuvekkMuh, "xTabMuvekkMuh");
            this.xTabMuvekkMuh.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // xTabControlMuvekkilMuhasebe
            // 
            resources.ApplyResources(this.xTabControlMuvekkilMuhasebe, "xTabControlMuvekkilMuhasebe");
            this.xTabControlMuvekkilMuhasebe.Name = "xTabControlMuvekkilMuhasebe";
            this.xTabControlMuvekkilMuhasebe.SelectedTabPage = this.xTabPageMuvDosyaHesabi;
            this.xTabControlMuvekkilMuhasebe.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xTabPageMuvDosyaHesabi,
            this.xTabPageMuvTumHesap});
            // 
            // xTabPageMuvDosyaHesabi
            // 
            this.xTabPageMuvDosyaHesabi.Name = "xTabPageMuvDosyaHesabi";
            resources.ApplyResources(this.xTabPageMuvDosyaHesabi, "xTabPageMuvDosyaHesabi");
            // 
            // xTabPageMuvTumHesap
            // 
            this.xTabPageMuvTumHesap.Name = "xTabPageMuvTumHesap";
            resources.ApplyResources(this.xTabPageMuvTumHesap, "xTabPageMuvTumHesap");
            // 
            // tabHEsapEkstre
            // 
            //this.tabHEsapEkstre.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            //this.tabHEsapEkstre.Appearance.Header.ForeColor = System.Drawing.Color.Red;
            //this.tabHEsapEkstre.Appearance.Header.Options.UseFont = true;
            //this.tabHEsapEkstre.Appearance.Header.Options.UseForeColor = true;
            //this.tabHEsapEkstre.Appearance.PageClient.BackColor = System.Drawing.Color.Red;
            //this.tabHEsapEkstre.Appearance.PageClient.Options.UseBackColor = true;
            //this.tabHEsapEkstre.Name = "tabHEsapEkstre";
            //resources.ApplyResources(this.tabHEsapEkstre, "tabHEsapEkstre");
            //this.tabHEsapEkstre.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabTebligatGelenGidenEvrak
            // 
            this.tabTebligatGelenGidenEvrak.Name = "tabTebligatGelenGidenEvrak";
            resources.ApplyResources(this.tabTebligatGelenGidenEvrak, "tabTebligatGelenGidenEvrak");
            this.tabTebligatGelenGidenEvrak.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabPMuvekkilTalimat
            // 
            this.tabPMuvekkilTalimat.Name = "tabPMuvekkilTalimat";
            resources.ApplyResources(this.tabPMuvekkilTalimat, "tabPMuvekkilTalimat");
            this.tabPMuvekkilTalimat.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabpSozlesme
            // 
            this.tabpSozlesme.Name = "tabpSozlesme";
            resources.ApplyResources(this.tabpSozlesme, "tabpSozlesme");
            this.tabpSozlesme.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // tabpTakipHikayesi
            // 
            this.tabpTakipHikayesi.Name = "tabpTakipHikayesi";
            resources.ApplyResources(this.tabpTakipHikayesi, "tabpTakipHikayesi");
            // 
            // tabpIcraTalimatlari
            // 
            this.tabpIcraTalimatlari.Name = "tabpIcraTalimatlari";
            resources.ApplyResources(this.tabpIcraTalimatlari, "tabpIcraTalimatlari");
            // 
            // ucTrackBar1
            // 
            resources.ApplyResources(this.ucTrackBar1, "ucTrackBar1");
            this.ucTrackBar1.MyTabControl = this.tabGridler;
            this.ucTrackBar1.Name = "ucTrackBar1";
            // 
            // compTabKaydir1
            // 
            this.compTabKaydir1.TabKontrol = this.tabGridler;
            // 
            // ucIcraGridler
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabGridler);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucIcraGridler";
            this.Load += new System.EventHandler(this.ucIcraGridler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl9)).EndInit();
            this.xtraTabControl9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rLueMalKategoriID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMalTurID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMalCinsID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizTipID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMallar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCariID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSatisIstenmeSekliID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSatisTuruID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSpinTutarID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMallarID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabGridler)).EndInit();
            this.tabGridler.ResumeLayout(false);
            this.tbMalBeyani.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tbOdeme.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl3)).EndInit();
            this.xtraTabControl3.ResumeLayout(false);
            this.tbItiraz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl8)).EndInit();
            this.xtraTabControl8.ResumeLayout(false);
            this.tbGorusmeVeIletisim.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl12)).EndInit();
            this.xtraTabControl12.ResumeLayout(false);
            this.tbDegisikIsler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl5)).EndInit();
            this.xtraTabControl5.ResumeLayout(false);
            this.tbAlacaklar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl7)).EndInit();
            this.xtraTabControl7.ResumeLayout(false);
            this.tpAlacaklar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl11)).EndInit();
            this.xtraTabControl11.ResumeLayout(false);
            this.tpKiymetliEvrak.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabCntrlKiymetliEvrak)).EndInit();
            this.tabCntrlKiymetliEvrak.ResumeLayout(false);
            this.tpSozlesme.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl13)).EndInit();
            this.xtraTabControl13.ResumeLayout(false);
            this.tabpGayrimenkulArac.ResumeLayout(false);
            this.tabHasarVePolice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl4)).EndInit();
            this.xtraTabControl4.ResumeLayout(false);
            this.tabDokumanlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl10)).EndInit();
            this.xtraTabControl10.ResumeLayout(false);
            this.tabDosyaMuhasebesi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl14)).EndInit();
            this.xtraTabControl14.ResumeLayout(false);
            this.tabMuvekkilHesabı.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xTabMuvekkMuh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xTabControlMuvekkilMuhasebe)).EndInit();
            this.xTabControlMuvekkilMuhasebe.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void CreateTabHacizGridler1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // tabHacizGridler1
            // 
            this.tabHacizGridler1 = new AdimAdimDavaKaydi.IcraTakipForms.tabHacizGridler();
            this.tbHacizIslemleri.Controls.Add(this.tabHacizGridler1);
            this.tabHacizGridler1.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.tabHacizGridler1, "tabHacizGridler1");
            this.tabHacizGridler1.HacizChildSelectedRow = null;
            this.tabHacizGridler1.HacizMasterSelectedRow = null;
            //this.tabHacizGridler1.MyFoy = null;
            this.tabHacizGridler1.Name = "tabHacizGridler1";
        }

        private void CreateUcGorevler1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucGorevler1
            // 
            this.ucGorevler1 = new AdimAdimDavaKaydi.Is.UserControls.ucGorevGrid();
            this.c_tpGorevler.Controls.Add(this.ucGorevler1);
            this.ucGorevler1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGorevler1.AllowInsert = false;
            this.ucGorevler1.AramaDockPanel = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            resources.ApplyResources(this.ucGorevler1, "ucGorevler1");
            //this.ucGorevler1.MyDataSource = null;
            //this.ucGorevler1.MyDataSourceView = null;
            this.ucGorevler1.Name = "ucGorevler1";
            this.ucGorevler1.SelectedRecord = null;
            this.ucGorevler1.SelectedRecordId = 0;
            this.ucGorevler1.ShowKayitEkranOnDoubleClick = true;
        }


        private void CreateUcSozlesmeGrid1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucSozlesmeGrid1
            // 
            this.ucSozlesmeGrid1 = new AdimAdimDavaKaydi.UserControls.ucSozlesmeGrid();
            this.tabpSozlesme.Controls.Add(this.ucSozlesmeGrid1);
            this.ucSozlesmeGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.ucSozlesmeGrid1, "ucSozlesmeGrid1");
            //this.ucSozlesmeGrid1.Foy = null;
            //this.ucSozlesmeGrid1.MyDataSource = null;
            //this.ucSozlesmeGrid1.MyDavaFoy = null;
            this.ucSozlesmeGrid1.Name = "ucSozlesmeGrid1";
        }

        private void CreateUcMuvekkilTalimatlari1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucMuvekkilTalimatlari1
            // 
            this.ucMuvekkilTalimatlari1 = new AdimAdimDavaKaydi.UserControls.ucMuvekkilTalimatlari();
            this.tabPMuvekkilTalimat.Controls.Add(this.ucMuvekkilTalimatlari1);
            this.ucMuvekkilTalimatlari1.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.ucMuvekkilTalimatlari1, "ucMuvekkilTalimatlari1");
            //this.ucMuvekkilTalimatlari1.MyDataSource = null;
            //this.ucMuvekkilTalimatlari1.MyDavaFoy = null;
            //this.ucMuvekkilTalimatlari1.MyFoy = null;
            this.ucMuvekkilTalimatlari1.Name = "ucMuvekkilTalimatlari1";
        }


        private void CreateucTebligatMuhatapForGiris1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            //ucTebligatMuhatapForGiris
            // 
            this.ucTebligatMuhatapForGiris1 = new AdimAdimDavaKaydi.UserControls.ucTebligatMuhatapForGiris();
            this.tabTebligatGelenGidenEvrak.Controls.Add(this.ucTebligatMuhatapForGiris1);
            this.ucTebligatMuhatapForGiris1.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.ucTebligatMuhatapForGiris1, "ucTebligatMuhatapForGiris1");
            //this.ucTebligat1.MyDataSource = null;
            //this.ucTebligat1.MyFoy = null;
            //this.ucTebligat1.MyHazirlikFoy = null;
            //this.ucTebligat1.MyIcraFoy = null;
            this.ucTebligatMuhatapForGiris1.Name = "ucTebligatMuhatapForGiris1";
        }

        //private void CreateUcIcraHesapCetveli1(System.ComponentModel.ComponentResourceManager resources)
        //{
        //    // 
        //    // ucIcraHesapCetveli1
        //    // 
        //    this.ucIcraHesapCetveli1 = new AdimAdimDavaKaydi.UserControls.ucIcraHesapCetveli();
        //    this.tabHEsapEkstre.Controls.Add(this.ucIcraHesapCetveli1);
        //    this.ucIcraHesapCetveli1.Dock = System.Windows.Forms.DockStyle.Fill;
        //    this.ucIcraHesapCetveli1.BarGorunsun = false;
        //    resources.ApplyResources(this.ucIcraHesapCetveli1, "ucIcraHesapCetveli1");
        //    this.ucIcraHesapCetveli1.Gorunum = DevExpress.XtraVerticalGrid.LayoutViewStyle.BandsView;
        //    this.ucIcraHesapCetveli1.KlasorHesabi = true;
        //    //this.ucIcraHesapCetveli1.MyFoyDataSource = null;
        //    this.ucIcraHesapCetveli1.MyOzetHesap = null;
        //    //this.ucIcraHesapCetveli1.MyTarafSource = null;
        //    this.ucIcraHesapCetveli1.Name = "ucIcraHesapCetveli1";
        //    this.ucIcraHesapCetveli1.OzetHesapBaslikGrubu = AdimAdimDavaKaydi.UserControls.ucOzetHesap.BaslikGruplari.Dosya;
        //    this.ucIcraHesapCetveli1.SadeceDosyaTabi = false;
        //    this.ucIcraHesapCetveli1.SadeceTarafTabi = false;
        //    this.ucIcraHesapCetveli1.SecilenSayfa = AdimAdimDavaKaydi.UserControls.ucIcraHesapCetveli.TabSayfalari.DosyaHesabi;
        //    this.ucIcraHesapCetveli1.Tag = "H";
        //}

        private void CreateUcMeslekMakbuzu1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucMeslekMakbuzu1
            // 
            this.ucMeslekMakbuzu1 = new AdimAdimDavaKaydi.Sorusturma.UserControls.ucMeslekMakbuzu();
            this.xTabMeslekMakbuzu.Controls.Add(this.ucMeslekMakbuzu1);
            this.ucMeslekMakbuzu1.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.ucMeslekMakbuzu1, "ucMeslekMakbuzu1");
            //this.ucMeslekMakbuzu1.MyDataSource = null;
            //this.ucMeslekMakbuzu1.MyFoy = null;
            //this.ucMeslekMakbuzu1.MyHazirlik = null;
            //this.ucMeslekMakbuzu1.MyIcraFoy = null;
            //this.ucMeslekMakbuzu1.MySozlesme = null;
            this.ucMeslekMakbuzu1.Name = "ucMeslekMakbuzu1";
        }

        private void CreateUcYapilcakIsSozlesme1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucYapilcakIsSozlesme1
            // 
            this.ucYapilcakIsSozlesme1 = new AdimAdimDavaKaydi.UserControls.UcDava.ucYapilcakIsSozlesme();
            this.ucYapilcakIsSozlesme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xTabVekaletIsSozlesme.Controls.Add(this.ucYapilcakIsSozlesme1);
            resources.ApplyResources(this.ucYapilcakIsSozlesme1, "ucYapilcakIsSozlesme1");
            this.ucYapilcakIsSozlesme1.Name = "ucYapilcakIsSozlesme1";
        }

        private void CreateucIcraVekaletSozlesmesi1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucIcraVekaletSozlesmesi1
            // 
            this.ucIcraVekaletSozlesmesi1 = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraVekaletSozlesmesi();
            this.xTabVekaletSozlesme.Controls.Add(this.ucIcraVekaletSozlesmesi1);
            this.ucIcraVekaletSozlesmesi1.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.ucIcraVekaletSozlesmesi1, "ucIcraVekaletSozlesmesi1");
            //this.ucIcraVekaletSozlesmesi1.MyDataSource = null;
            //this.ucIcraVekaletSozlesmesi1.MyDavaFoy = null;
            this.ucIcraVekaletSozlesmesi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIcraVekaletSozlesmesi1.Name = "ucIcraVekaletSozlesmesi1";
        }

        private void CreateGcMuvekkilOdemeleri(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // gcMuvekkilOdemeleri
            // 
            this.gcMuvekkilOdemeleri = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucMuvekkilOdemeleri();
            this.xTabMuvekkilOdeme.Controls.Add(this.gcMuvekkilOdemeleri);
            this.gcMuvekkilOdemeleri.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.gcMuvekkilOdemeleri, "gcMuvekkilOdemeleri");
            //this.gcMuvekkilOdemeleri.MyDataSource = null;
            //this.gcMuvekkilOdemeleri.MyDavaFoy = null;
            //this.gcMuvekkilOdemeleri.MyIcraFoy = null;
            this.gcMuvekkilOdemeleri.Name = "gcMuvekkilOdemeleri";
            this.gcMuvekkilOdemeleri.VerticalGorunsun = false;
        }

        private void CreateGcMasraflar(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // gcMasraflar
            // 
            this.gcMasraflar = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucMasraflar();
            this.tabMasraflar.Controls.Add(this.gcMasraflar);
            this.gcMasraflar.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.gcMasraflar, "gcMasraflar");
            //this.gcMasraflar.MyDataSource = null;
            //this.gcMasraflar.MyDavaFoy = null;
            //this.gcMasraflar.MyFoy = null;
            //this.gcMasraflar.MyHazirlikFoy = null;
            this.gcMasraflar.Name = "gcMasraflar";
        }

        private void CreateUcPoliceBilgileri1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucPoliceBilgileri1
            // 
            this.ucPoliceBilgileri1 = new AdimAdimDavaKaydi.UserControls.ucPoliceBilgileri();
            this.ucPoliceBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPolice.Controls.Add(this.ucPoliceBilgileri1);
            resources.ApplyResources(this.ucPoliceBilgileri1, "ucPoliceBilgileri1");
            //this.ucPoliceBilgileri1.MyDataSource = null;
            this.ucPoliceBilgileri1.Name = "ucPoliceBilgileri1";
        }

        private void CreateUcHasarBilgileri1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucHasarBilgileri1
            // 
            this.ucHasarBilgileri1 = new AdimAdimDavaKaydi.UserControls.ucHasarBilgileri();
            this.ucHasarBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabHasar.Controls.Add(this.ucHasarBilgileri1);
            resources.ApplyResources(this.ucHasarBilgileri1, "ucHasarBilgileri1");
            //this.ucHasarBilgileri1.MyDataSource = null;
            this.ucHasarBilgileri1.Name = "ucHasarBilgileri1";
        }

        private void CreateUcMehilBilgileri1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucMehilBilgileri1
            // 
            this.ucMehilBilgileri1 = new AdimAdimDavaKaydi.IcraTakipForms.ucMehilBilgileri();
            this.tbMehilBilgileri.Controls.Add(this.ucMehilBilgileri1);
            this.ucMehilBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.ucMehilBilgileri1, "ucMehilBilgileri1");
            //this.ucMehilBilgileri1.MyDataSource = null;
            //this.ucMehilBilgileri1.MyFoy = null;
            this.ucMehilBilgileri1.Name = "ucMehilBilgileri1";
        }

        private void CreateGcTakipAsama(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // gcTakipAsama
            // 
            this.gcTakipAsama = new AdimAdimDavaKaydi.UserControls.ucTakipAsamalar();
            this.gcTakipAsama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTakipAsama.Controls.Add(this.gcTakipAsama);
            resources.ApplyResources(this.gcTakipAsama, "gcTakipAsama");
            //this.gcTakipAsama.MyDataSource = null;
            //this.gcTakipAsama.MyFoy = null;
            this.gcTakipAsama.Name = "gcTakipAsama";
        }

        private void CreateGcGelisme(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // gcGelisme
            // 
            this.gcGelisme = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucGelismeler();
            this.gcGelisme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbGelismeler.Controls.Add(this.gcGelisme);
            resources.ApplyResources(this.gcGelisme, "gcGelisme");
            //this.gcGelisme.MyDataSource = null;
            this.gcGelisme.Name = "gcGelisme";
        }

        private void CreateSozlesmeMenkul(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // sozlesmeMenkul
            // 
            this.sozlesmeMenkul = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucBorcluMalBilgileri();
            this.sozlesmeMenkul.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageMenkulMal.Controls.Add(this.sozlesmeMenkul);
            resources.ApplyResources(this.sozlesmeMenkul, "sozlesmeMenkul");
            this.sozlesmeMenkul.FocusedIndex = 0;
            //this.sozlesmeMenkul.MyDataSource = null;
            //this.sozlesmeMenkul.MyFoy = null;
            //this.sozlesmeMenkul.MySozlesme = null;
            this.sozlesmeMenkul.MyType = AvukatProLib.Extras.ViewType.GridView;
            this.sozlesmeMenkul.Name = "sozlesmeMenkul";
            this.sozlesmeMenkul.ShowOnlyGridControl = false;
        }

        private void CreateUcAlacakNedenSozlesme(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucAlacakNedenSozlesme
            // 
            this.ucAlacakNedenSozlesme = new AdimAdimDavaKaydi.UserControls.ucSozlesmeGrid();
            this.ucAlacakNedenSozlesme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPSozlesmeBilgileri.Controls.Add(this.ucAlacakNedenSozlesme);
            resources.ApplyResources(this.ucAlacakNedenSozlesme, "ucAlacakNedenSozlesme");
            //this.ucAlacakNedenSozlesme.Foy = null;
            //this.ucAlacakNedenSozlesme.MyDataSource = null;
            //this.ucAlacakNedenSozlesme.MyDavaFoy = null;
            this.ucAlacakNedenSozlesme.Name = "ucAlacakNedenSozlesme";
        }

        private void CreateUcKiymetliEvrakGrid1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucKiymetliEvrakGrid1
            // 
            this.ucKiymetliEvrakGrid1 = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucKiymetliEvrakGrid();
            this.ucKiymetliEvrakGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPKiymetliEvrakGrid.Controls.Add(this.ucKiymetliEvrakGrid1);
            this.ucKiymetliEvrakGrid1.AppenButtonEnabled = true;
            resources.ApplyResources(this.ucKiymetliEvrakGrid1, "ucKiymetliEvrakGrid1");
            //this.ucKiymetliEvrakGrid1.Foy = null;
            //this.ucKiymetliEvrakGrid1.MyDataSource = null;
            this.ucKiymetliEvrakGrid1.Name = "ucKiymetliEvrakGrid1";
        }

        private void CreateUcKiymetliEvrakTaraf1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucKiymetliEvrakTaraf1
            // 
            this.ucKiymetliEvrakTaraf1 = new AdimAdimDavaKaydi.ucKiymetliEvrakTaraf();
            this.ucKiymetliEvrakTaraf1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPKiymetliEvrakTaraf.Controls.Add(this.ucKiymetliEvrakTaraf1);
            resources.ApplyResources(this.ucKiymetliEvrakTaraf1, "ucKiymetliEvrakTaraf1");
            //this.ucKiymetliEvrakTaraf1.MyDataSource = null;
            this.ucKiymetliEvrakTaraf1.Name = "ucKiymetliEvrakTaraf1";
        }

        private void CreateGcKefalet(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // gcKefalet
            // 
            this.gcKefalet = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucKefaletBilgileri();
            this.tabKefalet.Controls.Add(this.gcKefalet);
            this.gcKefalet.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.gcKefalet, "gcKefalet");
            //this.gcKefalet.MyDataSource = null;
            //this.gcKefalet.MyFoy = null;
            this.gcKefalet.MyView = AvukatProLib.Extras.ViewType.GridView;
            this.gcKefalet.Name = "gcKefalet";
        }

        private void CreateUcAlacaklar1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucAlacaklar1
            // 
            this.ucAlacaklar1 = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucAlacaklar();
            this.tabAlacaklar.Controls.Add(this.ucAlacaklar1);
            this.ucAlacaklar1.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.ucAlacaklar1, "ucAlacaklar1");
            //this.ucAlacaklar1.MyDataSource = null;
            //this.ucAlacaklar1.MyFoy = null;
            this.ucAlacaklar1.Name = "ucAlacaklar1";
        }

        private void CreateUcGenelNotlar(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucGenelNotlar
            // 
            this.ucGenelNotlar = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucGenelNotlar();
            this.ucGenelNotlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbBos.Controls.Add(this.ucGenelNotlar);
            resources.ApplyResources(this.ucGenelNotlar, "ucGenelNotlar");
            //this.ucGenelNotlar.MyDataSource = null;
            //this.ucGenelNotlar.MyFoy = null;
            this.ucGenelNotlar.MyType = AvukatProLib.Extras.ViewType.GridView;
            this.ucGenelNotlar.Name = "ucGenelNotlar";
        }

        private void CreateUcSatisMaster1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucSatisMaster1
            // 
            this.ucSatisMaster1 = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucSatisMaster();
            this.ucSatisMaster1.Dock = System.Windows.Forms.DockStyle.Fill;

            this.tbSatis.Controls.Add(this.ucSatisMaster1);
            this.ucSatisMaster1.BringToFront();
            resources.ApplyResources(this.ucSatisMaster1, "ucSatisMaster1");
            //this.ucSatisMaster1.MyDataSource = null;
            //this.ucSatisMaster1.MyFoy = null;
            this.ucSatisMaster1.Name = "ucSatisMaster1";
        }

        private void CreateGcTaahhut(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // gcTaahhut
            // 
            this.gcTaahhut = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucTaahhutler();
            this.tbTaahhutler.Controls.Add(this.gcTaahhut);
            this.gcTaahhut.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.gcTaahhut, "gcTaahhut");
            //this.gcTaahhut.MyDataSource = null;
            //this.gcTaahhut.MyFoy = null;
            this.gcTaahhut.Name = "gcTaahhut";
        }

        private void CreateGcDusmeYenileme(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // gcDusmeYenileme
            // 
            this.gcDusmeYenileme = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucDusmeYenileme();
            this.tbDusmeYenileme.Controls.Add(this.gcDusmeYenileme);
            this.gcDusmeYenileme.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.gcDusmeYenileme, "gcDusmeYenileme");
            //this.gcDusmeYenileme.MyDataSource = null;
            //this.gcDusmeYenileme.MyFoy = null;
            this.gcDusmeYenileme.MyView = AvukatProLib.Extras.ViewType.GridView;
            this.gcDusmeYenileme.Name = "gcDusmeYenileme";
        }

        private void CreateUcIcraTeminatMektup1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucIcraTeminatMektup1
            // 
            this.ucIcraTeminatMektup1 = new AdimAdimDavaKaydi.UserControls.ucIcraTeminatMektup();
            this.ucIcraTeminatMektup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbIadeAlinmamisTeminatlar.Controls.Add(this.ucIcraTeminatMektup1);
            resources.ApplyResources(this.ucIcraTeminatMektup1, "ucIcraTeminatMektup1");
            //this.ucIcraTeminatMektup1.MyDataSource = null;
            this.ucIcraTeminatMektup1.Name = "ucIcraTeminatMektup1";
        }

        private void CreateGcIhtiyatiTedbir(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // gcIhtiyatiTedbir
            // 
            this.gcIhtiyatiTedbir = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIhtiyatiTedbir();
            this.gcIhtiyatiTedbir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbIhtTedbir.Controls.Add(this.gcIhtiyatiTedbir);
            resources.ApplyResources(this.gcIhtiyatiTedbir, "gcIhtiyatiTedbir");
            //this.gcIhtiyatiTedbir.MyDataSource = null;
            //this.gcIhtiyatiTedbir.MyFoy = null;
            this.gcIhtiyatiTedbir.Name = "gcIhtiyatiTedbir";
        }

        private void CreateGcIhtiyatiHaciz(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // gcIhtiyatiHaciz
            // 
            this.gcIhtiyatiHaciz = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIhtiyatiHaciz();
            this.tbIhtHaciz.Controls.Add(this.gcIhtiyatiHaciz);
            this.gcIhtiyatiHaciz.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.gcIhtiyatiHaciz, "gcIhtiyatiHaciz");
            //this.gcIhtiyatiHaciz.MyDataSource = null;
            //this.gcIhtiyatiHaciz.MyFoy = null;
            this.gcIhtiyatiHaciz.Name = "gcIhtiyatiHaciz";
        }

        private void CreateUcEPosta1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucEPosta1
            // 
            this.ucEPosta1 = new AdimAdimDavaKaydi.UserControls.ucEPosta();
            this.ucEPosta1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEmail.Controls.Add(this.ucEPosta1);
            resources.ApplyResources(this.ucEPosta1, "ucEPosta1");
            //this.ucEPosta1.MyDataSource = null;
            //this.ucEPosta1.MyFoy = null;
            this.ucEPosta1.Name = "ucEPosta1";
        }

        private void CreateUcDavaSMS1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucDavaSMS1
            // 
            this.ucDavaSMS1 = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaSMS();
            this.ucDavaSMS1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSMS.Controls.Add(this.ucDavaSMS1);
            resources.ApplyResources(this.ucDavaSMS1, "ucDavaSMS1");
            //this.ucDavaSMS1.MyDataSource = null;
            this.ucDavaSMS1.Name = "ucDavaSMS1";
        }

        private void CreateGcGorusme(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // gcGorusme
            // 
            this.gcGorusme = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucGorusmeler();
            this.tabGorusmeler.Controls.Add(this.gcGorusme);
            this.gcGorusme.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.gcGorusme, "gcGorusme");
            //this.gcGorusme.MyDataSource = null;
            //this.gcGorusme.MyFoy = null;
            //this.gcGorusme.MyIcraFoy = null;
            //this.gcGorusme.MySozlesme = null;
            this.gcGorusme.Name = "gcGorusme";
        }

        private void CreateGcMalBeyani(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // gcMalBeyani
            // 
            this.gcMalBeyani = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucMalBeyani();
            this.tabMalBeyan.Controls.Add(this.gcMalBeyani);
            this.gcMalBeyani.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.gcMalBeyani, "gcMalBeyani");
            this.gcMalBeyani.MView = AvukatProLib.Extras.ViewType.GridView;
            //this.gcMalBeyani.MyDataSource = null;
            //this.gcMalBeyani.MyFoy = null;
            this.gcMalBeyani.Name = "gcMalBeyani";
        }

        private void CreateUcSikayetBilgileri1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucSikayetBilgileri1
            // 
            this.ucSikayetBilgileri1 = new AdimAdimDavaKaydi.UserControls.ucSikayetBilgileri();
            this.tabSikayetler.Controls.Add(this.ucSikayetBilgileri1);
            this.ucSikayetBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.ucSikayetBilgileri1, "ucSikayetBilgileri1");
            //this.ucSikayetBilgileri1.MyDataSource = null;
            //this.ucSikayetBilgileri1.MyFoy = null;
            this.ucSikayetBilgileri1.Name = "ucSikayetBilgileri1";
        }

        private void CreateUcItiraz(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucItiraz
            // 
            this.ucItiraz = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucItirazAlacakNeden();
            this.tabItirazlar.Controls.Add(this.ucItiraz);
            this.ucItiraz.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.ucItiraz, "ucItiraz");
            //this.ucItiraz.Foy = null;
            //this.ucItiraz.MyDataSource = null;
            this.ucItiraz.Name = "ucItiraz";
        }

        private void CreateGcOdemeDagilim(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // gcOdemeDagilim
            // 
            this.gcOdemeDagilim = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucOdemeDagilim();
            this.gcOdemeDagilim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOdemeDagilimi.Controls.Add(this.gcOdemeDagilim);
            resources.ApplyResources(this.gcOdemeDagilim, "gcOdemeDagilim");
            //this.gcOdemeDagilim.MyDataSource = null;
            //this.gcOdemeDagilim.MyFoy = null;
            this.gcOdemeDagilim.Name = "gcOdemeDagilim";
        }

        private void CreateGcMahsup(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // gcMahsup
            // 
            this.gcMahsup = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucMahsup();
            this.tabMahsup.Controls.Add(this.gcMahsup);
            this.gcMahsup.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.gcMahsup, "gcMahsup");
            //this.gcMahsup.MyDataSource = null;
            //this.gcMahsup.MyFoy = null;
            this.gcMahsup.Name = "gcMahsup";
        }

        private void CreateGcFeragat(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // gcFeragat
            // 
            this.gcFeragat = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucFeragat();
            this.tabFeragat.Controls.Add(this.gcFeragat);
            this.gcFeragat.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.gcFeragat, "gcFeragat");
            //this.gcFeragat.MyDataSource = null;
            //this.gcFeragat.MyFoy = null;
            this.gcFeragat.Name = "gcFeragat";
        }

        private void CreateUcTakipHikayesi(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucTakipHikayesi1
            // 
            this.ucTakipHikayesi1 = new UserControls.IcraTakipUserControls.ucTakipHikayesi();
            this.tabpTakipHikayesi.Controls.Add(this.ucTakipHikayesi1);
            resources.ApplyResources(this.ucTakipHikayesi1, "ucTakipHikayesi1");
            //this.ucTakipHikayesi1.MyDataSource = null;
            this.ucTakipHikayesi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTakipHikayesi1.Name = "ucTakipHikayesi1";
        }

        private void CreateUcIcraTalimatlari(System.ComponentModel.ComponentResourceManager resources)
        {
            this.ucIcraTalimatlari1 = new UserControls.IcraTakipUserControls.ucIcraTalimatlari();
            this.tabpIcraTalimatlari.Controls.Add(this.ucIcraTalimatlari1);
            // 
            // ucIcraTalimatlari1
            // 
            resources.ApplyResources(this.ucIcraTalimatlari1, "ucIcraTalimatlari1");
            this.ucIcraTalimatlari1.Name = "ucIcraTalimatlari1";
            this.ucIcraTalimatlari1.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void CreateGcBorcluOdeme(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // gcBorcluOdeme
            // 
            this.gcBorcluOdeme = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucOdemeler();
            this.tabBorcluOdemeler.Controls.Add(this.gcBorcluOdeme);
            this.gcBorcluOdeme.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.gcBorcluOdeme, "gcBorcluOdeme");
            //this.gcBorcluOdeme.MyDataSource = null;
            //this.gcBorcluOdeme.MyFoy = null;
            //this.gcBorcluOdeme.MyGelisme = null;
            //this.gcBorcluOdeme.MyProje = null;
            this.gcBorcluOdeme.Name = "gcBorcluOdeme";
        }

        private void CreateUcBorcluMalBilgileri2(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucBorcluMalBilgileri2
            // 
            this.ucBorcluMalBilgileri2 = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucBorcluMalBilgileri();
            this.tabArastırmaIleTespit.Controls.Add(this.ucBorcluMalBilgileri2);
            this.ucBorcluMalBilgileri2.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.ucBorcluMalBilgileri2, "ucBorcluMalBilgileri2");
            this.ucBorcluMalBilgileri2.FocusedIndex = 0;
            //this.ucBorcluMalBilgileri2.MyDataSource = null;
            //this.ucBorcluMalBilgileri2.MyFoy = null;
            //this.ucBorcluMalBilgileri2.MySozlesme = null;
            this.ucBorcluMalBilgileri2.MyType = AvukatProLib.Extras.ViewType.GridView;
            this.ucBorcluMalBilgileri2.Name = "ucBorcluMalBilgileri2";
            this.ucBorcluMalBilgileri2.ShowOnlyGridControl = false;
        }

        private void CreateUcBorcluMalBilgileri1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucBorcluMalBilgileri1
            // 
            this.ucBorcluMalBilgileri1 = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucBorcluMalBilgileri();
            this.tabBorclununMallari.Controls.Add(this.ucBorcluMalBilgileri1);
            this.ucBorcluMalBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.ucBorcluMalBilgileri1, "ucBorcluMalBilgileri1");
            this.ucBorcluMalBilgileri1.FocusedIndex = 0;
            //this.ucBorcluMalBilgileri1.MyDataSource = null;
            //this.ucBorcluMalBilgileri1.MyFoy = null;
            //this.ucBorcluMalBilgileri1.MySozlesme = null;
            this.ucBorcluMalBilgileri1.MyType = AvukatProLib.Extras.ViewType.GridView;
            this.ucBorcluMalBilgileri1.Name = "ucBorcluMalBilgileri1";
            this.ucBorcluMalBilgileri1.ShowOnlyGridControl = false;
        }

        private void CreateUcUcakGemiArac1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucUcakGemiArac1
            // 
            this.ucUcakGemiArac1 = new AdimAdimDavaKaydi.ucUcakGemiArac();
            this.ucUcakGemiArac1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Panel2.Controls.Add(this.ucUcakGemiArac1);
            // this.xtraTabPage2.Controls.Add(this.ucUcakGemiArac1);
            resources.ApplyResources(this.ucUcakGemiArac1, "ucUcakGemiArac1");
            //      this.ucUcakGemiArac1.KontrolTipi = AvukatProLib.Extras.GemiUcakAracTipi.SecimYapin;
            //this.ucUcakGemiArac1.MyDataSource = null;
            this.ucUcakGemiArac1.Name = "ucUcakGemiArac1";
        }

        private void CreateUcGayriMenkul1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucGayriMenkul1
            // 
            this.ucGayriMenkul1 = new AdimAdimDavaKaydi.ucGayriMenkul();
            this.ucGayriMenkul1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabPage2.Controls.Add(this.ucGayriMenkul1);
            resources.ApplyResources(this.ucGayriMenkul1, "ucGayriMenkul1");
            //this.ucGayriMenkul1.MyDataSource = null;
            this.ucGayriMenkul1.Name = "ucGayriMenkul1";
        }

        public void CreateUcbelgeTakip1(System.ComponentModel.ComponentResourceManager resources)
        {
            ucbelgetakip1 = new AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge.ucbelgetakip();
            this.c_tpBelge.Controls.Add(this.ucbelgetakip1);
            resources.ApplyResources(this.ucbelgetakip1, "ucbelgetakip1");
            this.ucbelgetakip1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucbelgetakip1.TableName = "AV001_TI_BIL_FOY";
        }

        private void CreateUcGayriMenkulTaraf1(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucGayriMenkulTaraf1
            // 
            this.ucGayriMenkulTaraf1 = new AdimAdimDavaKaydi.UserControls.ucGayriMenkulTaraf();
            this.xtraTabPage3.Controls.Add(this.ucGayriMenkulTaraf1);
            this.ucGayriMenkulTaraf1.Dock = System.Windows.Forms.DockStyle.Fill;
            resources.ApplyResources(this.ucGayriMenkulTaraf1, "ucGayriMenkulTaraf1");
            //this.ucGayriMenkulTaraf1.MyDataSource = null;
            this.ucGayriMenkulTaraf1.Name = "ucGayriMenkulTaraf1";
        }

        private void CreateUcIliskiDetay(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucIliskiDetay1
            // 
            this.ucIliskiDetay1 = new AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay();
            tbDosyaBaglantilari.Controls.Add(ucIliskiDetay1);
            this.ucIliskiDetay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIliskiDetay1.DataSourceIliskiliDosyalar = null;
            resources.ApplyResources(this.ucIliskiDetay1, "ucIliskiDetay1");
            this.ucIliskiDetay1.FoyId = 0;
            this.ucIliskiDetay1.IliskililerListe = null;
            this.ucIliskiDetay1.Name = "ucIliskiDetay1";
            this.ucIliskiDetay1.Tur = AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.NULL;
        }

        private void CreateUcIcraTakipMuvekkilHesabi(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucIcraTakipMuvekkilHesabi1
            // 
            this.ucIcraTakipMuvekkilHesabi1 = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTakipMuvekkilHesabi();
            this.xTabDosyaOzeti.Controls.Add(this.ucIcraTakipMuvekkilHesabi1);
            resources.ApplyResources(this.ucIcraTakipMuvekkilHesabi1, "ucIcraTakipMuvekkilHesabi1");
            this.ucIcraTakipMuvekkilHesabi1.Name = "ucIcraTakipMuvekkilHesabi1";
            this.ucIcraTakipMuvekkilHesabi1.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void CreateUcMuvekkilDosyaHesabi(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucMuhasebeGenel1
            // 
            this.ucMuhasebeGenel1 = new UserControls.ucMuhasebeGenel();
            this.xTabPageMuvDosyaHesabi.Controls.Add(this.ucMuhasebeGenel1);
            resources.ApplyResources(this.ucMuhasebeGenel1, "ucMuhasebeGenel1");
            this.ucMuhasebeGenel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMuhasebeGenel1.Name = "ucMuhasebeGenel1";
        }

        private void CreateUcMuvekkilTumHesabi(System.ComponentModel.ComponentResourceManager resources)
        {
            // 
            // ucMuhasebeGenel2
            // 
            this.ucMuhasebeGenel2 = new UserControls.ucMuhasebeGenel();
            this.xTabPageMuvTumHesap.Controls.Add(this.ucMuhasebeGenel2);
            resources.ApplyResources(this.ucMuhasebeGenel2, "ucMuhasebeGenel2");
            this.ucMuhasebeGenel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMuhasebeGenel2.Name = "ucMuhasebeGenel2";
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTab.XtraTabControl tabGridler;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tbBos;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tbIadeAlinmamisTeminatlar;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tbAlacaklar;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tbOdeme;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl3;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabBorcluOdemeler;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabOdemeDagilimi;
        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucOdemeDagilim gcOdemeDagilim;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tbMalBeyani;
        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucMalBeyani gcMalBeyani;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tbItiraz;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tbGorusmeVeIletisim;
        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucGorusmeler gcGorusme;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tbTakipAsama;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tbDegisikIsler;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl5;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tbIhtHaciz;
        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIhtiyatiHaciz gcIhtiyatiHaciz;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tbIhtTedbir;
        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIhtiyatiTedbir gcIhtiyatiTedbir;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tbDusmeYenileme;
        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucDusmeYenileme gcDusmeYenileme;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tbTaahhutler;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tbHacizIslemleri;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tbGelismeler;
        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucGelismeler gcGelisme;
        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucTaahhutler gcTaahhut;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tbDosyaBaglantilari;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage c_tpGorevler;
        private ucTrackBar ucTrackBar1;
        private ucZTrackBar ucZTrackBar1;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueCariID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSatisIstenmeSekliID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSatisTuruID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMalKategoriID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMalTurID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMalCinsID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDovizTipID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit8;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rSpinTutarID;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit rLueMallarID;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMallar;
        //private ucMehilBilgileri ucMehilBilgileri1;
        internal ucOdemeler gcBorcluOdeme;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tbMehilBilgileri;
        private ucMehilBilgileri ucMehilBilgileri1;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tbSatis;
        internal ucSatisMaster ucSatisMaster1;
        public ucAlacaklar ucAlacaklar1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabMalBeyan;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabBorclununMallari;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabArastırmaIleTespit;
        private ucBorcluMalBilgileri ucBorcluMalBilgileri1;
        private ucBorcluMalBilgileri ucBorcluMalBilgileri2;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabHasarVePolice;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl4;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabHasar;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabPolice;
        private AdimAdimDavaKaydi.UserControls.ucHasarBilgileri ucHasarBilgileri1;
        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit1;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private AdimAdimDavaKaydi.Util.compTabKaydir compTabKaydir1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl7;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tpAlacaklar;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tpKiymetliEvrak;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tpSozlesme;
        public ucGorevGrid ucGorevler1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl8;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabItirazlar;
        internal ucItirazAlacakNeden ucItiraz;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabSikayetler;
        private AdimAdimDavaKaydi.UserControls.ucSikayetBilgileri ucSikayetBilgileri1;
        private ucKiymetliEvrakGrid ucKiymetliEvrakGrid1;
        private ucKiymetliEvrakTaraf ucKiymetliEvrakTaraf1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        public tabHacizGridler tabHacizGridler1;
        public AdimAdimDavaKaydi.UserControls.ucTakipAsamalar gcTakipAsama;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabFeragat;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabMahsup;
        internal ucFeragat gcFeragat;
        private ucMahsup gcMahsup;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabDokumanlar;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl10;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage c_tpBelge;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl11;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabAlacaklar;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabKefalet;
        private ucKefaletBilgileri gcKefalet;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl12;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabGorusmeler;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabSMS;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabEmail;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucDavaSMS ucDavaSMS1;
        private AdimAdimDavaKaydi.UserControls.ucEPosta ucEPosta1;
        private AdimAdimDavaKaydi.UserControls.ucIcraTeminatMektup ucIcraTeminatMektup1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl13;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabPSozlesmeBilgileri;
        private AdimAdimDavaKaydi.UserControls.ucSozlesmeGrid ucAlacakNedenSozlesme;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabpGayrimenkulArac;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private ucUcakGemiArac ucUcakGemiArac1;
        public ucIliskiDetay ucIliskiDetay1;
        public ucIliskiDetay ucIliskiDetay2;
        public ucIliskiDetay ucIliskiDetay3;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabDosyaMuhasebesi;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl14;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabMuvekkilHesabı;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl2;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xTabMuvekkilOdeme;
        private ucMuvekkilOdemeleri gcMuvekkilOdemeleri;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xTabVekaletSozlesme;
        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraVekaletSozlesmesi ucIcraVekaletSozlesmesi1;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xTabVekaletIsSozlesme;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucYapilcakIsSozlesme ucYapilcakIsSozlesme1;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xTabDosyaOzeti;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xTabMeslekMakbuzu;
        private AdimAdimDavaKaydi.Sorusturma.UserControls.ucMeslekMakbuzu ucMeslekMakbuzu1;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xTabMuvekkMuh;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabMasraflar;
        public ucMasraflar gcMasraflar;
        //private AdimAdimDavaKaydi.Util.ExtendedTabPage tabHEsapEkstre;
        //public AdimAdimDavaKaydi.UserControls.ucIcraHesapCetveli ucIcraHesapCetveli1;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabPageMenkulMal;
        private ucBorcluMalBilgileri sozlesmeMenkul;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabTebligatGelenGidenEvrak;
        private AdimAdimDavaKaydi.UserControls.ucTebligatMuhatapForGiris ucTebligatMuhatapForGiris1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl9;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xtraTabPage3;
        private AdimAdimDavaKaydi.UserControls.ucGayriMenkulTaraf ucGayriMenkulTaraf1;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xtraTabPage2;
        private ucGayriMenkul ucGayriMenkul1;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabPMuvekkilTalimat;
        private AdimAdimDavaKaydi.UserControls.ucMuvekkilTalimatlari ucMuvekkilTalimatlari1;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabpSozlesme;
        private AdimAdimDavaKaydi.UserControls.ucSozlesmeGrid ucSozlesmeGrid1;
        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucGenelNotlar ucGenelNotlar;
        private AdimAdimDavaKaydi.UserControls.ucPoliceBilgileri ucPoliceBilgileri1;
        private DevExpress.XtraEditors.CheckButton checkButton1;
        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTakipMuvekkilHesabi ucIcraTakipMuvekkilHesabi1;
        private DevExpress.XtraTab.XtraTabControl xTabControlMuvekkilMuhasebe;
        private DevExpress.XtraTab.XtraTabPage xTabPageMuvDosyaHesabi;
        private DevExpress.XtraTab.XtraTabPage xTabPageMuvTumHesap;
        private UserControls.ucMuhasebeGenel ucMuhasebeGenel1;
        private UserControls.ucMuhasebeGenel ucMuhasebeGenel2;
        private DevExpress.XtraTab.XtraTabPage tabpTakipHikayesi;
        private UserControls.IcraTakipUserControls.ucTakipHikayesi ucTakipHikayesi1;
        private DevExpress.XtraTab.XtraTabPage tabpIcraTalimatlari;
        private UserControls.IcraTakipUserControls.ucIcraTalimatlari ucIcraTalimatlari1;
        private DevExpress.XtraTab.XtraTabControl tabCntrlKiymetliEvrak;
        private DevExpress.XtraTab.XtraTabPage tabPKiymetliEvrakGrid;
        private DevExpress.XtraTab.XtraTabPage tabPKiymetliEvrakTaraf;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabIcraDosyasiMuhasebesi;
    }
}

