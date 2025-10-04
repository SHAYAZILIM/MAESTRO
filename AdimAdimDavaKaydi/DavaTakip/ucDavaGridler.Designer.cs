using AdimAdimDavaKaydi.Is.UserControls;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AvukatPro.Services.Implementations;
using AvukatPro.Services.Interfaces;
using AvukatPro.Model.EntityClasses;
using System.Collections.Generic;
namespace AdimAdimDavaKaydi.DavaTakip
{
    partial class ucDavaGridler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDavaGridler));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelControl11 = new DevExpress.XtraEditors.PanelControl();
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.ucTrackBar1 = new AdimAdimDavaKaydi.ucTrackBar();
            this.tabGridler = new DevExpress.XtraTab.XtraTabControl();
            this.tabGenelNotlar = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabDavaNeden = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl9 = new DevExpress.XtraTab.XtraTabControl();
            this.tabDavaTalep = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabPIliskiliKayitlar = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabDnIliskiliKayitlar = new DevExpress.XtraTab.XtraTabControl();
            this.tabPDnGayrimenkulBilgileri = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabPDnAracBilgileri = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabPDnKiymetliEvrak = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabPDNSozlesmeBilgileri = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tbPPolice = new DevExpress.XtraTab.XtraTabPage();
            this.tabDavaHesabi = new DevExpress.XtraTab.XtraTabPage();
            this.tabCelseveArarKararBilgileri = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl7 = new DevExpress.XtraTab.XtraTabControl();
            this.tabCelseBilgi = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabAraKaraar = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabDusmeYenileme = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabKanit = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabHesap = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.tabDavaliOdemeleri = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabMasraf = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabDosyaMuhasebesi = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabPersonelHesabý = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabDavaliOdeme = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabGelisme = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabKayitIliskiDetay = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl6 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage14 = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.pnlButton = new DevExpress.XtraEditors.PanelControl();
            this.sbtnIliskiEkle = new DevExpress.XtraEditors.SimpleButton();
            this.tabAsama = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabDegisikIsveTeminat = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl3 = new DevExpress.XtraTab.XtraTabControl();
            this.tabTedbir = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabTespit = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabIletisim = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl4 = new DevExpress.XtraTab.XtraTabControl();
            this.tabGorusme = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabSms = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabMail = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabHukumveTemyiz = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl8 = new DevExpress.XtraTab.XtraTabControl();
            this.tabHukumBilgiler = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabTemyizbilgiler = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabDavaIzah = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabMüvekkilHesabý = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage9 = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabPage10 = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabPage11 = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabPage5 = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabPage3 = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl10 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage13 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage19 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage6 = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabPage8 = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.c_tpGorevler = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tbTutuklanma = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabDokumanlar = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl5 = new DevExpress.XtraTab.XtraTabControl();
            this.tabBelgeler = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabDavaSozlesmeleri = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabTebligatveGelenGidenEvrak = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabPMuvekkilOdeme = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabPIliskiliDKayýtlarý = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabControl11 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage16 = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabPage17 = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xtraTabPage18 = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.tabPSozlesmeBilgileri = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            this.xTabPIadeAlinmamisTeminatlar = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.ucZTrackBar2 = new AdimAdimDavaKaydi.ucZTrackBar();
            this.xtraTabPage15 = new AdimAdimDavaKaydi.Util.ExtendedTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl11)).BeginInit();
            this.panelControl11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabGridler)).BeginInit();
            this.tabGridler.SuspendLayout();
            this.tabDavaNeden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl9)).BeginInit();
            this.xtraTabControl9.SuspendLayout();
            this.tabPIliskiliKayitlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabDnIliskiliKayitlar)).BeginInit();
            this.tabDnIliskiliKayitlar.SuspendLayout();
            this.tabCelseveArarKararBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl7)).BeginInit();
            this.xtraTabControl7.SuspendLayout();
            this.tabHesap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.tabKayitIliskiDetay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl6)).BeginInit();
            this.xtraTabControl6.SuspendLayout();
            this.xtraTabPage14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButton)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.tabDegisikIsveTeminat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl3)).BeginInit();
            this.xtraTabControl3.SuspendLayout();
            this.tabIletisim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl4)).BeginInit();
            this.xtraTabControl4.SuspendLayout();
            this.tabHukumveTemyiz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl8)).BeginInit();
            this.xtraTabControl8.SuspendLayout();
            this.tabMüvekkilHesabý.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl10)).BeginInit();
            this.xtraTabControl10.SuspendLayout();
            this.tabDokumanlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl5)).BeginInit();
            this.xtraTabControl5.SuspendLayout();
            this.tabPIliskiliDKayýtlarý.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl11)).BeginInit();
            this.xtraTabControl11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl11
            // 
            this.panelControl11.Controls.Add(this.popupContainerEdit1);
            this.panelControl11.Controls.Add(this.panelControl2);
            this.panelControl11.Controls.Add(this.panelControl6);
            this.panelControl11.Controls.Add(this.popupContainerControl1);
            this.panelControl11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl11.Location = new System.Drawing.Point(647, 0);
            this.panelControl11.Name = "panelControl11";
            this.panelControl11.Size = new System.Drawing.Size(28, 453);
            this.panelControl11.TabIndex = 226;
            // 
            // popupContainerEdit1
            // 
            this.popupContainerEdit1.Location = new System.Drawing.Point(0, 3);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("popupContainerEdit1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, false)});
            this.popupContainerEdit1.Properties.CloseOnLostFocus = false;
            this.popupContainerEdit1.Properties.CloseOnOuterMouseClick = false;
            this.popupContainerEdit1.Properties.PopupControl = this.popupContainerControl1;
            this.popupContainerEdit1.Size = new System.Drawing.Size(26, 22);
            this.popupContainerEdit1.TabIndex = 235;
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Location = new System.Drawing.Point(6, 236);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(200, 277);
            this.popupContainerControl1.TabIndex = 231;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.ucTrackBar1);
            this.panelControl2.Location = new System.Drawing.Point(2, 26);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(24, 98);
            this.panelControl2.TabIndex = 234;
            // 
            // ucTrackBar1
            // 
            this.ucTrackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTrackBar1.Location = new System.Drawing.Point(2, 2);
            this.ucTrackBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucTrackBar1.MyTabControl = this.tabGridler;
            this.ucTrackBar1.Name = "ucTrackBar1";
            this.ucTrackBar1.Size = new System.Drawing.Size(20, 94);
            this.ucTrackBar1.TabIndex = 0;
            // 
            // tabGridler
            // 
            this.tabGridler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGridler.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.tabGridler.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.tabGridler.Location = new System.Drawing.Point(0, 0);
            this.tabGridler.MultiLine = DevExpress.Utils.DefaultBoolean.False;
            this.tabGridler.Name = "tabGridler";
            this.tabGridler.SelectedTabPage = this.tabGenelNotlar;
            this.tabGridler.Size = new System.Drawing.Size(647, 453);
            this.tabGridler.TabIndex = 228;
            this.tabGridler.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabDavaNeden,
            this.tabDavaHesabi,
            this.tabCelseveArarKararBilgileri,
            this.tabDusmeYenileme,
            this.tabKanit,
            this.tabHesap,
            this.tabDavaliOdeme,
            this.tabGelisme,
            this.tabKayitIliskiDetay,
            this.tabAsama,
            this.tabGenelNotlar,
            this.tabDegisikIsveTeminat,
            this.tabIletisim,
            this.tabHukumveTemyiz,
            this.tabDavaIzah,
            this.tabMüvekkilHesabý,
            this.xtraTabPage6,
            this.xtraTabPage8,
            this.c_tpGorevler,
            this.tbTutuklanma,
            this.tabDokumanlar,
            this.tabTebligatveGelenGidenEvrak,
            this.tabPMuvekkilOdeme,
            this.tabPIliskiliDKayýtlarý,
            this.xTabPIadeAlinmamisTeminatlar});
            // 
            // tabGenelNotlar
            // 
            this.tabGenelNotlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabGenelNotlar.Name = "tabGenelNotlar";
            this.tabGenelNotlar.Size = new System.Drawing.Size(484, 447);
            this.tabGenelNotlar.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabGenelNotlar.Text = "Notlar";
            // 
            // tabDavaNeden
            // 
            this.tabDavaNeden.Controls.Add(this.xtraTabControl9);
            this.tabDavaNeden.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabDavaNeden.Name = "tabDavaNeden";
            this.tabDavaNeden.PageVisible = false;
            this.tabDavaNeden.Size = new System.Drawing.Size(483, 447);
            this.tabDavaNeden.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabDavaNeden.Text = "Dava Talepleri";
            // 
            // xtraTabControl9
            // 
            this.xtraTabControl9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl9.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTabControl9.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl9.Name = "xtraTabControl9";
            this.xtraTabControl9.SelectedTabPage = this.tabDavaTalep;
            this.xtraTabControl9.Size = new System.Drawing.Size(483, 447);
            this.xtraTabControl9.TabIndex = 0;
            this.xtraTabControl9.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabDavaTalep,
            this.tabPIliskiliKayitlar});
            // 
            // tabDavaTalep
            // 
            this.tabDavaTalep.Name = "tabDavaTalep";
            this.tabDavaTalep.Size = new System.Drawing.Size(477, 419);
            this.tabDavaTalep.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabDavaTalep.Text = "Dava Talepleri";
            // 
            // tabPIliskiliKayitlar
            // 
            this.tabPIliskiliKayitlar.Controls.Add(this.tabDnIliskiliKayitlar);
            this.tabPIliskiliKayitlar.Name = "tabPIliskiliKayitlar";
            this.tabPIliskiliKayitlar.Size = new System.Drawing.Size(479, 420);
            this.tabPIliskiliKayitlar.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabPIliskiliKayitlar.Text = "Ýliþkili Kayýtlar";
            // 
            // tabDnIliskiliKayitlar
            // 
            this.tabDnIliskiliKayitlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDnIliskiliKayitlar.Location = new System.Drawing.Point(0, 0);
            this.tabDnIliskiliKayitlar.Name = "tabDnIliskiliKayitlar";
            this.tabDnIliskiliKayitlar.SelectedTabPage = this.tabPDnGayrimenkulBilgileri;
            this.tabDnIliskiliKayitlar.Size = new System.Drawing.Size(479, 420);
            this.tabDnIliskiliKayitlar.TabIndex = 0;
            this.tabDnIliskiliKayitlar.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPDnGayrimenkulBilgileri,
            this.tabPDnAracBilgileri,
            this.tabPDnKiymetliEvrak,
            this.tabPDNSozlesmeBilgileri,
            this.tbPPolice});
            // 
            // tabPDnGayrimenkulBilgileri
            // 
            this.tabPDnGayrimenkulBilgileri.Name = "tabPDnGayrimenkulBilgileri";
            this.tabPDnGayrimenkulBilgileri.Size = new System.Drawing.Size(473, 392);
            this.tabPDnGayrimenkulBilgileri.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabPDnGayrimenkulBilgileri.Text = "Gayrimenkul Bilgileri";
            // 
            // tabPDnAracBilgileri
            // 
            this.tabPDnAracBilgileri.Name = "tabPDnAracBilgileri";
            this.tabPDnAracBilgileri.Size = new System.Drawing.Size(473, 392);
            this.tabPDnAracBilgileri.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabPDnAracBilgileri.Text = "Araç Bilgileri";
            // 
            // tabPDnKiymetliEvrak
            // 
            this.tabPDnKiymetliEvrak.Name = "tabPDnKiymetliEvrak";
            this.tabPDnKiymetliEvrak.Size = new System.Drawing.Size(473, 392);
            this.tabPDnKiymetliEvrak.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabPDnKiymetliEvrak.Text = "Kýymetli Evrak Bilgileri";
            // 
            // tabPDNSozlesmeBilgileri
            // 
            this.tabPDNSozlesmeBilgileri.Name = "tabPDNSozlesmeBilgileri";
            this.tabPDNSozlesmeBilgileri.Size = new System.Drawing.Size(473, 392);
            this.tabPDNSozlesmeBilgileri.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabPDNSozlesmeBilgileri.Text = "Sözleþme Bilgileri";
            // 
            // tbPPolice
            // 
            this.tbPPolice.Name = "tbPPolice";
            this.tbPPolice.Size = new System.Drawing.Size(473, 392);
            this.tbPPolice.Text = "Police Bilgileri";
            // 
            // tabDavaHesabi
            // 
            this.tabDavaHesabi.Name = "tabDavaHesabi";
            this.tabDavaHesabi.Size = new System.Drawing.Size(483, 447);
            this.tabDavaHesabi.Text = "Dava Hesabý";
            // 
            // tabCelseveArarKararBilgileri
            // 
            this.tabCelseveArarKararBilgileri.Controls.Add(this.xtraTabControl7);
            this.tabCelseveArarKararBilgileri.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabCelseveArarKararBilgileri.Name = "tabCelseveArarKararBilgileri";
            this.tabCelseveArarKararBilgileri.Size = new System.Drawing.Size(483, 447);
            this.tabCelseveArarKararBilgileri.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabCelseveArarKararBilgileri.Text = "Duruþma / Ara Karar";
            // 
            // xtraTabControl7
            // 
            this.xtraTabControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl7.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl7.Name = "xtraTabControl7";
            this.xtraTabControl7.SelectedTabPage = this.tabCelseBilgi;
            this.xtraTabControl7.Size = new System.Drawing.Size(483, 447);
            this.xtraTabControl7.TabIndex = 1;
            this.xtraTabControl7.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabCelseBilgi,
            this.tabAraKaraar});
            // 
            // tabCelseBilgi
            // 
            this.tabCelseBilgi.Name = "tabCelseBilgi";
            this.tabCelseBilgi.Size = new System.Drawing.Size(477, 419);
            this.tabCelseBilgi.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabCelseBilgi.Text = "Duruþma";
            // 
            // tabAraKaraar
            // 
            this.tabAraKaraar.Name = "tabAraKaraar";
            this.tabAraKaraar.PageVisible = false;
            this.tabAraKaraar.Size = new System.Drawing.Size(479, 420);
            this.tabAraKaraar.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabAraKaraar.Text = "Ara Karar Bilgileri";
            // 
            // tabDusmeYenileme
            // 
            this.tabDusmeYenileme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabDusmeYenileme.Name = "tabDusmeYenileme";
            this.tabDusmeYenileme.Size = new System.Drawing.Size(483, 447);
            this.tabDusmeYenileme.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabDusmeYenileme.Text = "Mahkeme - Esas No Deðiþtir";
            // 
            // tabKanit
            // 
            this.tabKanit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabKanit.Name = "tabKanit";
            this.tabKanit.PageVisible = false;
            this.tabKanit.Size = new System.Drawing.Size(483, 447);
            this.tabKanit.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabKanit.Text = "Kanýtlar";
            // 
            // tabHesap
            // 
            this.tabHesap.Controls.Add(this.xtraTabControl2);
            this.tabHesap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabHesap.Name = "tabHesap";
            this.tabHesap.Size = new System.Drawing.Size(483, 447);
            this.tabHesap.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabHesap.Text = "Masraf ve Muhasebe";
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl2.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.tabDavaliOdemeleri;
            this.xtraTabControl2.Size = new System.Drawing.Size(483, 447);
            this.xtraTabControl2.TabIndex = 0;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabDavaliOdemeleri,
            this.tabMasraf,
            this.tabDosyaMuhasebesi,
            this.tabPersonelHesabý});
            // 
            // tabDavaliOdemeleri
            // 
            this.tabDavaliOdemeleri.Name = "tabDavaliOdemeleri";
            this.tabDavaliOdemeleri.PageVisible = false;
            this.tabDavaliOdemeleri.Size = new System.Drawing.Size(477, 419);
            this.tabDavaliOdemeleri.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabDavaliOdemeleri.Text = "Davalý Ödemeleri";
            // 
            // tabMasraf
            // 
            this.tabMasraf.Name = "tabMasraf";
            this.tabMasraf.Size = new System.Drawing.Size(479, 420);
            this.tabMasraf.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabMasraf.Text = "Masraf Avans";
            // 
            // tabDosyaMuhasebesi
            // 
            this.tabDosyaMuhasebesi.Name = "tabDosyaMuhasebesi";
            this.tabDosyaMuhasebesi.Size = new System.Drawing.Size(479, 420);
            this.tabDosyaMuhasebesi.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabDosyaMuhasebesi.Text = "Dosya Muhasebesi";
            // 
            // tabPersonelHesabý
            // 
            this.tabPersonelHesabý.Name = "tabPersonelHesabý";
            this.tabPersonelHesabý.PageVisible = false;
            this.tabPersonelHesabý.Size = new System.Drawing.Size(479, 420);
            this.tabPersonelHesabý.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabPersonelHesabý.Text = "Personel Hesabý";
            // 
            // tabDavaliOdeme
            // 
            this.tabDavaliOdeme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabDavaliOdeme.Name = "tabDavaliOdeme";
            this.tabDavaliOdeme.Size = new System.Drawing.Size(483, 447);
            this.tabDavaliOdeme.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabDavaliOdeme.Text = "Dava Ödemeleri";
            // 
            // tabGelisme
            // 
            this.tabGelisme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabGelisme.Name = "tabGelisme";
            this.tabGelisme.Size = new System.Drawing.Size(483, 447);
            this.tabGelisme.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabGelisme.Text = "Dava Gelismeleri";
            // 
            // tabKayitIliskiDetay
            // 
            this.tabKayitIliskiDetay.Controls.Add(this.xtraTabControl6);
            this.tabKayitIliskiDetay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabKayitIliskiDetay.Name = "tabKayitIliskiDetay";
            this.tabKayitIliskiDetay.Size = new System.Drawing.Size(483, 447);
            this.tabKayitIliskiDetay.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabKayitIliskiDetay.Text = "Dosya Ýliþkileri";
            // 
            // xtraTabControl6
            // 
            this.xtraTabControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl6.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl6.Name = "xtraTabControl6";
            this.xtraTabControl6.SelectedTabPage = this.xtraTabPage14;
            this.xtraTabControl6.Size = new System.Drawing.Size(483, 447);
            this.xtraTabControl6.TabIndex = 1;
            this.xtraTabControl6.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage14});
            // 
            // xtraTabPage14
            // 
            this.xtraTabPage14.Controls.Add(this.pnlButton);
            this.xtraTabPage14.Name = "xtraTabPage14";
            this.xtraTabPage14.Size = new System.Drawing.Size(477, 419);
            this.xtraTabPage14.TabKulakRenk = System.Drawing.Color.Empty;
            this.xtraTabPage14.Text = "Ýliþkili Dosyalar";
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.sbtnIliskiEkle);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButton.Location = new System.Drawing.Point(0, 0);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(477, 38);
            this.pnlButton.TabIndex = 0;
            // 
            // sbtnIliskiEkle
            // 
            this.sbtnIliskiEkle.Location = new System.Drawing.Point(15, 6);
            this.sbtnIliskiEkle.Name = "sbtnIliskiEkle";
            this.sbtnIliskiEkle.Size = new System.Drawing.Size(120, 23);
            this.sbtnIliskiEkle.TabIndex = 0;
            this.sbtnIliskiEkle.Text = "Ýliþkili Kayýt Ekle";
            this.sbtnIliskiEkle.Click += new System.EventHandler(this.sbtnIliskiEkle_Click);
            // 
            // tabAsama
            // 
            this.tabAsama.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabAsama.Name = "tabAsama";
            this.tabAsama.PageEnabled = false;
            this.tabAsama.PageVisible = false;
            this.tabAsama.Size = new System.Drawing.Size(483, 447);
            this.tabAsama.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabAsama.Text = "Dava Haritasý";
            // 
            // tabDegisikIsveTeminat
            // 
            this.tabDegisikIsveTeminat.Controls.Add(this.xtraTabControl3);
            this.tabDegisikIsveTeminat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabDegisikIsveTeminat.Name = "tabDegisikIsveTeminat";
            this.tabDegisikIsveTeminat.Size = new System.Drawing.Size(483, 447);
            this.tabDegisikIsveTeminat.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabDegisikIsveTeminat.Text = "Deðiþik Ýþ ve Teminat Bilgileri";
            // 
            // xtraTabControl3
            // 
            this.xtraTabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl3.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl3.Name = "xtraTabControl3";
            this.xtraTabControl3.SelectedTabPage = this.tabTedbir;
            this.xtraTabControl3.Size = new System.Drawing.Size(483, 447);
            this.xtraTabControl3.TabIndex = 0;
            this.xtraTabControl3.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabTedbir,
            this.tabTespit});
            // 
            // tabTedbir
            // 
            this.tabTedbir.Name = "tabTedbir";
            this.tabTedbir.Size = new System.Drawing.Size(477, 419);
            this.tabTedbir.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabTedbir.Text = "Tedbir Bilgileri";
            // 
            // tabTespit
            // 
            this.tabTespit.Name = "tabTespit";
            this.tabTespit.Size = new System.Drawing.Size(479, 420);
            this.tabTespit.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabTespit.Text = "Tespit Bilgileri";
            // 
            // tabIletisim
            // 
            this.tabIletisim.Controls.Add(this.xtraTabControl4);
            this.tabIletisim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabIletisim.Name = "tabIletisim";
            this.tabIletisim.Size = new System.Drawing.Size(483, 447);
            this.tabIletisim.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabIletisim.Text = "Görüþme";
            // 
            // xtraTabControl4
            // 
            this.xtraTabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl4.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl4.Name = "xtraTabControl4";
            this.xtraTabControl4.SelectedTabPage = this.tabGorusme;
            this.xtraTabControl4.Size = new System.Drawing.Size(483, 447);
            this.xtraTabControl4.TabIndex = 0;
            this.xtraTabControl4.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabGorusme,
            this.tabSms,
            this.tabMail});
            // 
            // tabGorusme
            // 
            this.tabGorusme.Name = "tabGorusme";
            this.tabGorusme.Size = new System.Drawing.Size(477, 419);
            this.tabGorusme.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabGorusme.Text = "Görüþmeler";
            // 
            // tabSms
            // 
            this.tabSms.Name = "tabSms";
            this.tabSms.PageVisible = false;
            this.tabSms.Size = new System.Drawing.Size(479, 420);
            this.tabSms.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabSms.Text = "Sms";
            // 
            // tabMail
            // 
            this.tabMail.Name = "tabMail";
            this.tabMail.PageVisible = false;
            this.tabMail.Size = new System.Drawing.Size(479, 420);
            this.tabMail.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabMail.Text = "E-Posta";
            // 
            // tabHukumveTemyiz
            // 
            this.tabHukumveTemyiz.Appearance.Header.ForeColor = System.Drawing.Color.Red;
            this.tabHukumveTemyiz.Appearance.Header.Options.UseForeColor = true;
            this.tabHukumveTemyiz.Controls.Add(this.xtraTabControl8);
            this.tabHukumveTemyiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabHukumveTemyiz.Name = "tabHukumveTemyiz";
            this.tabHukumveTemyiz.Size = new System.Drawing.Size(483, 447);
            this.tabHukumveTemyiz.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabHukumveTemyiz.Text = "Karar ve Kanun Yollarý";
            // 
            // xtraTabControl8
            // 
            this.xtraTabControl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl8.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl8.Name = "xtraTabControl8";
            this.xtraTabControl8.SelectedTabPage = this.tabHukumBilgiler;
            this.xtraTabControl8.Size = new System.Drawing.Size(483, 447);
            this.xtraTabControl8.TabIndex = 1;
            this.xtraTabControl8.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabHukumBilgiler,
            this.tabTemyizbilgiler});
            // 
            // tabHukumBilgiler
            // 
            this.tabHukumBilgiler.Name = "tabHukumBilgiler";
            this.tabHukumBilgiler.Size = new System.Drawing.Size(477, 419);
            this.tabHukumBilgiler.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabHukumBilgiler.Text = "Karar Bilgileri";
            // 
            // tabTemyizbilgiler
            // 
            this.tabTemyizbilgiler.Name = "tabTemyizbilgiler";
            this.tabTemyizbilgiler.Size = new System.Drawing.Size(479, 420);
            this.tabTemyizbilgiler.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabTemyizbilgiler.Text = "Kanun Yollarý";
            // 
            // tabDavaIzah
            // 
            this.tabDavaIzah.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabDavaIzah.Name = "tabDavaIzah";
            this.tabDavaIzah.PageVisible = false;
            this.tabDavaIzah.Size = new System.Drawing.Size(483, 447);
            this.tabDavaIzah.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabDavaIzah.Text = "Davanýn Ýzahý";
            // 
            // tabMüvekkilHesabý
            // 
            this.tabMüvekkilHesabý.Controls.Add(this.xtraTabControl1);
            this.tabMüvekkilHesabý.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabMüvekkilHesabý.Name = "tabMüvekkilHesabý";
            this.tabMüvekkilHesabý.Size = new System.Drawing.Size(483, 447);
            this.tabMüvekkilHesabý.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabMüvekkilHesabý.Text = "Müvekkil Hesabý";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage9;
            this.xtraTabControl1.Size = new System.Drawing.Size(483, 447);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage9,
            this.xtraTabPage10,
            this.xtraTabPage11,
            this.xtraTabPage5,
            this.xtraTabPage3});
            // 
            // xtraTabPage9
            // 
            this.xtraTabPage9.Name = "xtraTabPage9";
            this.xtraTabPage9.PageVisible = false;
            this.xtraTabPage9.Size = new System.Drawing.Size(477, 419);
            this.xtraTabPage9.TabKulakRenk = System.Drawing.Color.Empty;
            this.xtraTabPage9.Text = "Müvekkile Ödeme";
            // 
            // xtraTabPage10
            // 
            this.xtraTabPage10.Name = "xtraTabPage10";
            this.xtraTabPage10.PageVisible = false;
            this.xtraTabPage10.Size = new System.Drawing.Size(479, 420);
            this.xtraTabPage10.TabKulakRenk = System.Drawing.Color.Empty;
            this.xtraTabPage10.Text = "Vekalet Sözleþmesi";
            // 
            // xtraTabPage11
            // 
            this.xtraTabPage11.Name = "xtraTabPage11";
            this.xtraTabPage11.Size = new System.Drawing.Size(479, 420);
            this.xtraTabPage11.TabKulakRenk = System.Drawing.Color.Empty;
            this.xtraTabPage11.Text = "Yapýlacak Ýþ Sözleþmesi";
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(479, 420);
            this.xtraTabPage5.TabKulakRenk = System.Drawing.Color.Empty;
            this.xtraTabPage5.Text = "Meslek Makbuzu";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.xtraTabControl10);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(479, 420);
            this.xtraTabPage3.TabKulakRenk = System.Drawing.Color.Empty;
            this.xtraTabPage3.Text = "Müvekkil Muhasebesi";
            // 
            // xtraTabControl10
            // 
            this.xtraTabControl10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl10.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl10.Name = "xtraTabControl10";
            this.xtraTabControl10.SelectedTabPage = this.xtraTabPage13;
            this.xtraTabControl10.Size = new System.Drawing.Size(479, 420);
            this.xtraTabControl10.TabIndex = 1;
            this.xtraTabControl10.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage13,
            this.xtraTabPage19});
            // 
            // xtraTabPage13
            // 
            this.xtraTabPage13.Name = "xtraTabPage13";
            this.xtraTabPage13.Size = new System.Drawing.Size(473, 392);
            this.xtraTabPage13.Text = "Müvekkil Dosya Hesabý";
            // 
            // xtraTabPage19
            // 
            this.xtraTabPage19.Name = "xtraTabPage19";
            this.xtraTabPage19.Size = new System.Drawing.Size(473, 392);
            this.xtraTabPage19.Text = "Müvekkilin Tüm Hesabý";
            // 
            // xtraTabPage6
            // 
            this.xtraTabPage6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.xtraTabPage6.Name = "xtraTabPage6";
            this.xtraTabPage6.Size = new System.Drawing.Size(483, 447);
            this.xtraTabPage6.TabKulakRenk = System.Drawing.Color.Empty;
            this.xtraTabPage6.Text = "Poliçe";
            // 
            // xtraTabPage8
            // 
            this.xtraTabPage8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.xtraTabPage8.Name = "xtraTabPage8";
            this.xtraTabPage8.PageVisible = false;
            this.xtraTabPage8.Size = new System.Drawing.Size(483, 447);
            this.xtraTabPage8.TabKulakRenk = System.Drawing.Color.Empty;
            this.xtraTabPage8.Text = "Hasar Bilgileri";
            // 
            // c_tpGorevler
            // 
            this.c_tpGorevler.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.c_tpGorevler.Name = "c_tpGorevler";
            this.c_tpGorevler.Size = new System.Drawing.Size(483, 447);
            this.c_tpGorevler.TabKulakRenk = System.Drawing.Color.Empty;
            this.c_tpGorevler.Text = "Ýþ Emirleri";
            // 
            // tbTutuklanma
            // 
            this.tbTutuklanma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbTutuklanma.Name = "tbTutuklanma";
            this.tbTutuklanma.Size = new System.Drawing.Size(483, 447);
            this.tbTutuklanma.TabKulakRenk = System.Drawing.Color.Empty;
            this.tbTutuklanma.Text = "Tutuklanma Bilgileri";
            // 
            // tabDokumanlar
            // 
            this.tabDokumanlar.Controls.Add(this.xtraTabControl5);
            this.tabDokumanlar.Name = "tabDokumanlar";
            this.tabDokumanlar.Size = new System.Drawing.Size(483, 447);
            this.tabDokumanlar.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabDokumanlar.Text = "Dokümanlar";
            // 
            // xtraTabControl5
            // 
            this.xtraTabControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl5.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl5.Name = "xtraTabControl5";
            this.xtraTabControl5.SelectedTabPage = this.tabBelgeler;
            this.xtraTabControl5.Size = new System.Drawing.Size(483, 447);
            this.xtraTabControl5.TabIndex = 0;
            this.xtraTabControl5.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabBelgeler,
            this.tabDavaSozlesmeleri});
            // 
            // tabBelgeler
            // 
            this.tabBelgeler.Name = "tabBelgeler";
            this.tabBelgeler.Size = new System.Drawing.Size(477, 419);
            this.tabBelgeler.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabBelgeler.Text = "Belgeler";
            // 
            // tabDavaSozlesmeleri
            // 
            this.tabDavaSozlesmeleri.Name = "tabDavaSozlesmeleri";
            this.tabDavaSozlesmeleri.Size = new System.Drawing.Size(479, 420);
            this.tabDavaSozlesmeleri.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabDavaSozlesmeleri.Text = "Dava Sözleþmeleri";
            // 
            // tabTebligatveGelenGidenEvrak
            // 
            this.tabTebligatveGelenGidenEvrak.Name = "tabTebligatveGelenGidenEvrak";
            this.tabTebligatveGelenGidenEvrak.Size = new System.Drawing.Size(483, 447);
            this.tabTebligatveGelenGidenEvrak.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabTebligatveGelenGidenEvrak.Text = "Tebligat ve Gelen Giden Evrak";
            // 
            // tabPMuvekkilOdeme
            // 
            this.tabPMuvekkilOdeme.Name = "tabPMuvekkilOdeme";
            this.tabPMuvekkilOdeme.PageVisible = false;
            this.tabPMuvekkilOdeme.Size = new System.Drawing.Size(483, 447);
            this.tabPMuvekkilOdeme.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabPMuvekkilOdeme.Text = "Müvekkil Talimatlarý";
            // 
            // tabPIliskiliDKayýtlarý
            // 
            this.tabPIliskiliDKayýtlarý.Controls.Add(this.xtraTabControl11);
            this.tabPIliskiliDKayýtlarý.Name = "tabPIliskiliDKayýtlarý";
            this.tabPIliskiliDKayýtlarý.Size = new System.Drawing.Size(483, 447);
            this.tabPIliskiliDKayýtlarý.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabPIliskiliDKayýtlarý.Text = "Ýliþkili Kayýtlar";
            // 
            // xtraTabControl11
            // 
            this.xtraTabControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl11.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl11.Name = "xtraTabControl11";
            this.xtraTabControl11.SelectedTabPage = this.xtraTabPage16;
            this.xtraTabControl11.Size = new System.Drawing.Size(483, 447);
            this.xtraTabControl11.TabIndex = 1;
            this.xtraTabControl11.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage16,
            this.xtraTabPage17,
            this.xtraTabPage18,
            this.tabPSozlesmeBilgileri});
            // 
            // xtraTabPage16
            // 
            this.xtraTabPage16.Name = "xtraTabPage16";
            this.xtraTabPage16.Size = new System.Drawing.Size(477, 419);
            this.xtraTabPage16.TabKulakRenk = System.Drawing.Color.Empty;
            this.xtraTabPage16.Text = "Gayrimenkul Bilgileri";
            // 
            // xtraTabPage17
            // 
            this.xtraTabPage17.Name = "xtraTabPage17";
            this.xtraTabPage17.Size = new System.Drawing.Size(479, 420);
            this.xtraTabPage17.TabKulakRenk = System.Drawing.Color.Empty;
            this.xtraTabPage17.Text = "Araç Bilgileri";
            // 
            // xtraTabPage18
            // 
            this.xtraTabPage18.Name = "xtraTabPage18";
            this.xtraTabPage18.Size = new System.Drawing.Size(479, 420);
            this.xtraTabPage18.TabKulakRenk = System.Drawing.Color.Empty;
            this.xtraTabPage18.Text = "Kýymetli Evrak Bilgileri";
            // 
            // tabPSozlesmeBilgileri
            // 
            this.tabPSozlesmeBilgileri.Name = "tabPSozlesmeBilgileri";
            this.tabPSozlesmeBilgileri.Size = new System.Drawing.Size(479, 420);
            this.tabPSozlesmeBilgileri.TabKulakRenk = System.Drawing.Color.Empty;
            this.tabPSozlesmeBilgileri.Text = "Sözleþme Bilgileri";
            // 
            // xTabPIadeAlinmamisTeminatlar
            // 
            this.xTabPIadeAlinmamisTeminatlar.Name = "xTabPIadeAlinmamisTeminatlar";
            this.xTabPIadeAlinmamisTeminatlar.Size = new System.Drawing.Size(483, 447);
            this.xTabPIadeAlinmamisTeminatlar.Text = "Ýade Alýnmamýþ Teminatlar";
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.ucZTrackBar2);
            this.panelControl6.Location = new System.Drawing.Point(3, 128);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(24, 104);
            this.panelControl6.TabIndex = 232;
            // 
            // ucZTrackBar2
            // 
            this.ucZTrackBar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucZTrackBar2.Location = new System.Drawing.Point(2, 2);
            this.ucZTrackBar2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucZTrackBar2.MyTabControl = this.tabGridler;
            this.ucZTrackBar2.Name = "ucZTrackBar2";
            this.ucZTrackBar2.Size = new System.Drawing.Size(20, 100);
            this.ucZTrackBar2.TabIndex = 224;
            // 
            // xtraTabPage15
            // 
            this.xtraTabPage15.Name = "xtraTabPage15";
            this.xtraTabPage15.Size = new System.Drawing.Size(626, 300);
            this.xtraTabPage15.TabKulakRenk = System.Drawing.Color.Empty;
            // 
            // ucDavaGridler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabGridler);
            this.Controls.Add(this.panelControl11);
            this.Name = "ucDavaGridler";
            this.Size = new System.Drawing.Size(675, 453);
            this.Load += new System.EventHandler(this.ucDavaGridler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl11)).EndInit();
            this.panelControl11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabGridler)).EndInit();
            this.tabGridler.ResumeLayout(false);
            this.tabDavaNeden.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl9)).EndInit();
            this.xtraTabControl9.ResumeLayout(false);
            this.tabPIliskiliKayitlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabDnIliskiliKayitlar)).EndInit();
            this.tabDnIliskiliKayitlar.ResumeLayout(false);
            this.tabCelseveArarKararBilgileri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl7)).EndInit();
            this.xtraTabControl7.ResumeLayout(false);
            this.tabHesap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.tabKayitIliskiDetay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl6)).EndInit();
            this.xtraTabControl6.ResumeLayout(false);
            this.xtraTabPage14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlButton)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.tabDegisikIsveTeminat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl3)).EndInit();
            this.xtraTabControl3.ResumeLayout(false);
            this.tabIletisim.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl4)).EndInit();
            this.xtraTabControl4.ResumeLayout(false);
            this.tabHukumveTemyiz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl8)).EndInit();
            this.xtraTabControl8.ResumeLayout(false);
            this.tabMüvekkilHesabý.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl10)).EndInit();
            this.xtraTabControl10.ResumeLayout(false);
            this.tabDokumanlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl5)).EndInit();
            this.xtraTabControl5.ResumeLayout(false);
            this.tabPIliskiliDKayýtlarý.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl11)).EndInit();
            this.xtraTabControl11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void CreateGcDavaNeden()
        {
            this.gcDavaNeden = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaNeden();
            this.tabDavaTalep.Controls.Add(this.gcDavaNeden);
            // 
            // gcDavaNeden
            // 
            this.gcDavaNeden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDavaNeden.Location = new System.Drawing.Point(0, 0);
            this.gcDavaNeden.Name = "gcDavaNeden";
            this.gcDavaNeden.Size = new System.Drawing.Size(476, 417);
            this.gcDavaNeden.TabIndex = 1;

            this.gcDavaNeden.FocusedRowChanged += new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaNeden.OnFocusedRowChanged(gcDavaNeden_FocusedRowChanged);
        }

        private void CreateUcGenelNotlar()
        {
            this.ucGenelNotlar = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaGenelNotlar();
            // 
            // ucGenelNotlar
            // 
            this.ucGenelNotlar.MyType = AvukatProLib.Extras.ViewType.GridView;
            this.tabGenelNotlar.Controls.Add(this.ucGenelNotlar);
            this.ucGenelNotlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGenelNotlar.Location = new System.Drawing.Point(0, 0);
            this.ucGenelNotlar.Name = "ucGenelNotlar";
            this.ucGenelNotlar.Size = new System.Drawing.Size(483, 446);
            this.ucGenelNotlar.TabIndex = 0;
        }

        private void CreateDnGayriMenkulBilgileri()
        {
            this.dnGayrimenkulBilgileri = new AdimAdimDavaKaydi.ucGayriMenkul();
            // 
            // dnGayrimenkulBilgileri
            // 
            this.dnGayrimenkulBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dnGayrimenkulBilgileri.Location = new System.Drawing.Point(0, 0);
            this.dnGayrimenkulBilgileri.Name = "dnGayrimenkulBilgileri";
            this.dnGayrimenkulBilgileri.Size = new System.Drawing.Size(469, 388);
            this.dnGayrimenkulBilgileri.TabIndex = 0;
            this.tabPDnGayrimenkulBilgileri.Controls.Add(this.dnGayrimenkulBilgileri);
        }

        private void CreateDnAracBilgileri()
        {
            this.dnAracBilgileri = new AdimAdimDavaKaydi.ucUcakGemiArac();
            this.tabPDnAracBilgileri.Controls.Add(this.dnAracBilgileri);
            // 
            // dnAracBilgileri
            // 
            this.dnAracBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dnAracBilgileri.KontrolTipi = AvukatProLib.Extras.GemiUcakAracTipi.Arac;
            this.dnAracBilgileri.Location = new System.Drawing.Point(0, 0);
            this.dnAracBilgileri.Name = "dnAracBilgileri";
            this.dnAracBilgileri.Size = new System.Drawing.Size(469, 388);
            this.dnAracBilgileri.TabIndex = 0;
        }

        private void CreateDnKiymetliEvrakBilgileri()
        {
            this.dnKiymetliEvrakBilgileri = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucKiymetliEvrakGrid();
            this.tabPDnKiymetliEvrak.Controls.Add(this.dnKiymetliEvrakBilgileri);
            // 
            // dnKiymetliEvrakBilgileri
            // 
            this.dnKiymetliEvrakBilgileri.AppenButtonEnabled = null;
            this.dnKiymetliEvrakBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dnKiymetliEvrakBilgileri.Location = new System.Drawing.Point(0, 0);
            this.dnKiymetliEvrakBilgileri.Name = "dnKiymetliEvrakBilgileri";
            this.dnKiymetliEvrakBilgileri.Size = new System.Drawing.Size(469, 388);
            this.dnKiymetliEvrakBilgileri.TabIndex = 0;
        }

        // davaHesaplari
        private void CreateDavaHesapBilgileri()
        {
            this.davaHesaplari = new AdimAdimDavaKaydi.UserControls.ucDavaHesapCetveliSon();
            this.tabDavaHesabi.Controls.Add(this.davaHesaplari);
            // 
            // dnKiymetliEvrakBilgileri
            // 
            this.davaHesaplari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.davaHesaplari.Location = new System.Drawing.Point(0, 0);
            this.davaHesaplari.Name = "davaHesaplari";
            this.davaHesaplari.Size = new System.Drawing.Size(469, 388);
            this.davaHesaplari.TabIndex = 0;
        }

        private void CreateDnSozlesmeBilgileri()
        {
            this.dnSozlesmeBilgileri = new AdimAdimDavaKaydi.UserControls.ucSozlesmeBilgi();
            this.tabPDNSozlesmeBilgileri.Controls.Add(this.dnSozlesmeBilgileri);
            // 
            // dnSozlesmeBilgileri
            // 
            this.dnSozlesmeBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dnSozlesmeBilgileri.Location = new System.Drawing.Point(0, 0);
            this.dnSozlesmeBilgileri.MyDataSource = null;
            this.dnSozlesmeBilgileri.Name = "dnSozlesmeBilgileri";
            this.dnSozlesmeBilgileri.Size = new System.Drawing.Size(469, 388);
            this.dnSozlesmeBilgileri.TabIndex = 0;
        }

        private void CreateUcDavaPolice1()
        {
            this.ucDavaPolice1 = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaPolice();
            this.tbPPolice.Controls.Add(this.ucDavaPolice1);
            // 
            // ucDavaPolice1
            // 
            this.ucDavaPolice1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDavaPolice1.Location = new System.Drawing.Point(0, 0);
            this.ucDavaPolice1.MyType = AvukatProLib.Extras.ViewType.GridView;
            this.ucDavaPolice1.Name = "ucDavaPolice1";
            this.ucDavaPolice1.Size = new System.Drawing.Size(469, 388);
            this.ucDavaPolice1.TabIndex = 1;
        }

        private void CreateGcCelse()
        {
            this.gcCelse = new AdimAdimDavaKaydi.UserControls.UcDava.ucCelseBilgileri();
            this.tabCelseBilgi.Controls.Add(this.gcCelse);
            // 
            // gcCelse
            // 
            this.gcCelse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCelse.Location = new System.Drawing.Point(0, 0);
            this.gcCelse.MyType = AvukatProLib.Extras.ViewType.GridView;
            this.gcCelse.Name = "gcCelse";
            this.gcCelse.Size = new System.Drawing.Size(476, 417);
            this.gcCelse.TabIndex = 0;
        }

        private void CreateGcAraKarar()
        {
            this.gcAraKarar = new AdimAdimDavaKaydi.UserControls.UcDava.ucAraKarar();
            this.tabAraKaraar.Controls.Add(this.gcAraKarar);
            // 
            // gcAraKarar
            // 
            this.gcAraKarar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAraKarar.Location = new System.Drawing.Point(0, 0);
            this.gcAraKarar.MyType = AvukatProLib.Extras.ViewType.GridView;
            this.gcAraKarar.Name = "gcAraKarar";
            this.gcAraKarar.Size = new System.Drawing.Size(476, 417);
            this.gcAraKarar.TabIndex = 1;
        }

        private void CreateGcDusmeYenileme()
        {
            this.gcDusmeYenileme = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaDusmeYenileme();
            this.tabDusmeYenileme.Controls.Add(this.gcDusmeYenileme);
            // 
            // gcDusmeYenileme
            // 
            this.gcDusmeYenileme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDusmeYenileme.Location = new System.Drawing.Point(0, 0);
            this.gcDusmeYenileme.MyType = AvukatProLib.Extras.ViewType.GridView;
            this.gcDusmeYenileme.Name = "gcDusmeYenileme";
            this.gcDusmeYenileme.Size = new System.Drawing.Size(483, 446);
            this.gcDusmeYenileme.TabIndex = 0;
        }

        private void CreateGcKanit()
        {
            this.gcKanit = new AdimAdimDavaKaydi.UserControls.UcDava.ucKanit();
            this.tabKanit.Controls.Add(this.gcKanit);
            // 
            // gcKanit
            // 
            this.gcKanit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcKanit.Location = new System.Drawing.Point(0, 0);
            this.gcKanit.MView = AvukatProLib.Extras.ViewType.GridView;
            this.gcKanit.Name = "gcKanit";
            this.gcKanit.Size = new System.Drawing.Size(483, 446);
            this.gcKanit.TabIndex = 0;
        }

        /// <summary>
        /// MY
        /// </summary>
        private void CreateGcOdeme()
        {
            this.ucDavaliOdeme = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaliOdemeleri();
            this.tabDavaliOdeme.Controls.Add(this.ucDavaliOdeme);
            // 
            // ucDavaliOdeme
            // 
            this.ucDavaliOdeme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDavaliOdeme.MyType = AvukatProLib.Extras.ViewType.GridView;
            this.ucDavaliOdeme.Location = new System.Drawing.Point(0, 0);
            this.ucDavaliOdeme.Name = "ucDavaliOdeme";
            this.ucDavaliOdeme.Size = new System.Drawing.Size(483, 446);
            this.ucDavaliOdeme.TabIndex = 0;
        }

        private void CreateGcDavaOdeme()
        {
            this.gcDavaOdeme = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaliOdemeleri();
            this.tabDavaliOdemeleri.Controls.Add(this.gcDavaOdeme);
            // 
            // gcDavaOdeme
            // 
            this.gcDavaOdeme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDavaOdeme.Location = new System.Drawing.Point(0, 0);
            this.gcDavaOdeme.MyType = AvukatProLib.Extras.ViewType.GridView;
            this.gcDavaOdeme.Name = "gcDavaOdeme";
            this.gcDavaOdeme.Size = new System.Drawing.Size(476, 417);
            this.gcDavaOdeme.TabIndex = 1;
        }

        private void CreateUcMasraflar2()
        {
            this.ucMuhasebeGenel3 = new AdimAdimDavaKaydi.UserControls.ucMuhasebeGenel("Dava", "Masraf", MyFoy);
            this.ucMuhasebeGenel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMuhasebeGenel3.Location = new System.Drawing.Point(0, 0);
            this.ucMuhasebeGenel3.Name = "ucMuhasebeGenel3";
            this.ucMuhasebeGenel3.SaveStatus = false;
            this.ucMuhasebeGenel3.Size = new System.Drawing.Size(918, 276);
            this.ucMuhasebeGenel3.TabIndex = 9;

            this.ucMasraflar2 = new ucMasraflar();
            //aykut hýzlandýrma 25.01.2013
            //List<RMasrafAvansDetayli2Entity> gelen = AvukatPro.Services.Implementations.MasrafAvansService.GetAllMasrafByDavaFoyId(MyFoy.ID);
            ucMuhasebeGenel3.MyMasrafAvansDetayli = AvukatPro.Services.Implementations.MasrafAvansService.GetAllMasrafByDavaFoyId(MyFoy.ID);
            tabMasraf.Controls.Add(this.ucMuhasebeGenel3);
            //System.Collections.Generic.List<AdimAdimDavaKaydi.UserControls.AddSelection> ads = new System.Collections.Generic.List<AdimAdimDavaKaydi.UserControls.AddSelection>();
            //System.Collections.Generic.List<AvukatProLib.Arama.R_MASRAF_AVANS_DETAYLI2> sorgu = AvukatProLib.Arama.R_MASRAF_AVANS_DETAYLISorgu.GetByFiltreView(
            //        null, null, null, null, null, null, null, null, null, MyFoy.ID, null, null,
            //            (AvukatProLib.Extras.Modul?)2, null, null, null, AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            //foreach (AvukatProLib.Arama.R_MASRAF_AVANS_DETAYLI2 item in sorgu)
            //{
            //    AdimAdimDavaKaydi.UserControls.AddSelection selection = new AdimAdimDavaKaydi.UserControls.AddSelection(item);
            //    ads.Add(selection);
            //}
            //this.ucMuhasebeGenel3.MyMasrafAvansDetayliSonuc2 = ads;
            //this.tabMasraf.Controls.Add(this.ucMuhasebeGenel3);
        }


        private void CreateUcMasraflar1()
        {
            this.ucMasraflar1 = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucMasraflar();
            this.tabDosyaMuhasebesi.Controls.Add(this.ucMasraflar1);
            // 
            // ucMasraflar1
            // 
            this.ucMasraflar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMasraflar1.Location = new System.Drawing.Point(0, 0);
            this.ucMasraflar1.Name = "ucMasraflar1";
            this.ucMasraflar1.Size = new System.Drawing.Size(476, 417);
            this.ucMasraflar1.TabIndex = 0;
        }

        private void CreateUcMasraflar3()
        {
            this.ucMasraflar3 = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucMasraflar();
            this.tabPersonelHesabý.Controls.Add(this.ucMasraflar3);
            // 
            // ucMasraflar3
            // 
            this.ucMasraflar3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMasraflar3.Location = new System.Drawing.Point(0, 0);
            this.ucMasraflar3.Name = "ucMasraflar3";
            this.ucMasraflar3.Size = new System.Drawing.Size(476, 417);
            this.ucMasraflar3.TabIndex = 0;
        }

        private void CreateGcDavaGelismeAdim()
        {
            this.gcDavaGelismeAdim = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaGelismeAdim();
            this.tabGelisme.Controls.Add(this.gcDavaGelismeAdim);
            // 
            // gcDavaGelismeAdim
            // 
            this.gcDavaGelismeAdim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDavaGelismeAdim.Location = new System.Drawing.Point(0, 0);
            this.gcDavaGelismeAdim.MView = AvukatProLib.Extras.ViewType.GridView;
            this.gcDavaGelismeAdim.Name = "gcDavaGelismeAdim";
            this.gcDavaGelismeAdim.Size = new System.Drawing.Size(483, 446);
            this.gcDavaGelismeAdim.TabIndex = 0;
        }

        private void CreateUcIliskiDetay1()
        {
            this.ucIliskiDetay1 = new AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay();
            this.xtraTabPage14.Controls.Add(this.ucIliskiDetay1);
            // 
            // ucIliskiDetay1
            // 
            this.ucIliskiDetay1.DataSourceIliskiliDosyalar = null;
            this.ucIliskiDetay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIliskiDetay1.BringToFront();
            this.ucIliskiDetay1.FoyId = 0;
            this.ucIliskiDetay1.HesapCetveliGorunsun = false;
            this.ucIliskiDetay1.IliskililerListe = null;
            this.ucIliskiDetay1.Location = new System.Drawing.Point(0, 0);
            this.ucIliskiDetay1.Name = "ucIliskiDetay1";
            this.ucIliskiDetay1.Size = new System.Drawing.Size(476, 417);
            this.ucIliskiDetay1.TabIndex = 0;
            this.ucIliskiDetay1.Tur = AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.NULL;
        }

        private void CreateGcAsama()
        {
            this.gcAsama = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaAsama();
            this.tabAsama.Controls.Add(this.gcAsama);
            // 
            // gcAsama
            // 
            this.gcAsama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAsama.Location = new System.Drawing.Point(0, 0);
            this.gcAsama.Name = "gcAsama";
            this.gcAsama.Size = new System.Drawing.Size(483, 446);
            this.gcAsama.TabIndex = 0;
        }

        private void CreateUcDavaTedbirBilgileri1()
        {
            this.ucDavaTedbirBilgileri1 = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaTedbirBilgileri();
            this.tabTedbir.Controls.Add(this.ucDavaTedbirBilgileri1);
            // 
            // ucDavaTedbirBilgileri1
            // 
            this.ucDavaTedbirBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDavaTedbirBilgileri1.Location = new System.Drawing.Point(0, 0);
            this.ucDavaTedbirBilgileri1.Name = "ucDavaTedbirBilgileri1";
            this.ucDavaTedbirBilgileri1.Size = new System.Drawing.Size(476, 417);
            this.ucDavaTedbirBilgileri1.TabIndex = 0;
        }

        private void CreateUcDavaTespitBilgi1()
        {
            this.ucDavaTespitBilgi1 = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaTespitBilgi();
            this.tabTespit.Controls.Add(this.ucDavaTespitBilgi1);
            // 
            // ucDavaTespitBilgi1
            // 
            this.ucDavaTespitBilgi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDavaTespitBilgi1.Location = new System.Drawing.Point(0, 0);
            this.ucDavaTespitBilgi1.MyType = AvukatProLib.Extras.ViewType.GridView;
            this.ucDavaTespitBilgi1.Name = "ucDavaTespitBilgi1";
            this.ucDavaTespitBilgi1.Size = new System.Drawing.Size(476, 417);
            this.ucDavaTespitBilgi1.TabIndex = 0;
        }

        private void CreateGcTeminat()
        {
            this.gcTeminat = new AdimAdimDavaKaydi.UserControls.UcDava.ucTeminatBilgileri();
            this.xTabPIadeAlinmamisTeminatlar.Controls.Add(this.gcTeminat);
            // 
            // gcTeminat
            // 
            this.gcTeminat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTeminat.Location = new System.Drawing.Point(0, 0);
            this.gcTeminat.MView = AvukatProLib.Extras.ViewType.GridView;
            this.gcTeminat.Name = "gcTeminat";
            this.gcTeminat.Size = new System.Drawing.Size(476, 417);
            this.gcTeminat.TabIndex = 1;
        }

        private void CreateGcGorusme()
        {
            this.gcGorusme = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaGorusme();
            this.tabGorusme.Controls.Add(this.gcGorusme);
            // 
            // gcGorusme
            // 
            this.gcGorusme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcGorusme.Location = new System.Drawing.Point(0, 0);
            this.gcGorusme.Name = "gcGorusme";
            this.gcGorusme.Size = new System.Drawing.Size(476, 417);
            this.gcGorusme.TabIndex = 0;
        }

        private void CreateGcSms()
        {
            this.gcSms = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaSMS();
            this.tabSms.Controls.Add(this.gcSms);
            // 
            // gcSms
            // 
            this.gcSms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSms.Location = new System.Drawing.Point(0, 0);
            this.gcSms.Name = "gcSms";
            this.gcSms.Size = new System.Drawing.Size(476, 417);
            this.gcSms.TabIndex = 0;
        }

        private void CreateUcEPosta1()
        {
            this.ucEPosta1 = new AdimAdimDavaKaydi.UserControls.ucEPosta();
            this.tabMail.Controls.Add(this.ucEPosta1);
            // 
            // ucEPosta1
            // 
            this.ucEPosta1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEPosta1.Location = new System.Drawing.Point(0, 0);
            this.ucEPosta1.Name = "ucEPosta1";
            this.ucEPosta1.Size = new System.Drawing.Size(476, 417);
            this.ucEPosta1.TabIndex = 0;
        }

        private void CreateGcMahkemeHukum()
        {
            this.gcMahkemeHukum = new AdimAdimDavaKaydi.UserControls.ucMahkemeHukum();
            this.tabHukumBilgiler.Controls.Add(this.gcMahkemeHukum);
            // 
            // gcMahkemeHukum
            // 
            this.gcMahkemeHukum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMahkemeHukum.Location = new System.Drawing.Point(0, 0);
            this.gcMahkemeHukum.Name = "gcMahkemeHukum";
            this.gcMahkemeHukum.Size = new System.Drawing.Size(476, 417);
            this.gcMahkemeHukum.TabIndex = 0;
        }

        private void CreateGcTemyiz()
        {
            this.gcTemyiz = new AdimAdimDavaKaydi.UserControls.UcDava.ucTemyizBilgileri();
            this.tabTemyizbilgiler.Controls.Add(this.gcTemyiz);
            // 
            // gcTemyiz
            // 
            this.gcTemyiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTemyiz.Location = new System.Drawing.Point(0, 0);
            this.gcTemyiz.MyType = AvukatProLib.Extras.ViewType.GridView;
            this.gcTemyiz.Name = "gcTemyiz";
            this.gcTemyiz.Size = new System.Drawing.Size(476, 417);
            this.gcTemyiz.TabIndex = 1;
        }

        private void CreateGcDavaHikaye()
        {
            this.gcDavaHikaye = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaHikayesi();
            this.tabDavaIzah.Controls.Add(this.gcDavaHikaye);
            // 
            // gcDavaHikaye
            // 
            this.gcDavaHikaye.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDavaHikaye.Location = new System.Drawing.Point(0, 0);
            this.gcDavaHikaye.MyType = AvukatProLib.Extras.ViewType.GridView;
            this.gcDavaHikaye.Name = "gcDavaHikaye";
            this.gcDavaHikaye.Size = new System.Drawing.Size(483, 446);
            this.gcDavaHikaye.TabIndex = 0;
        }

        private void CreateGcMuvekkilOdeme()
        {
            this.gcMuvekkilOdeme = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucMuvekkilOdemeleri();
            this.xtraTabPage9.Controls.Add(this.gcMuvekkilOdeme);
            // 
            // gcMuvekkilOdeme
            // 
            this.gcMuvekkilOdeme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMuvekkilOdeme.Location = new System.Drawing.Point(0, 0);
            this.gcMuvekkilOdeme.Name = "gcMuvekkilOdeme";
            this.gcMuvekkilOdeme.Size = new System.Drawing.Size(476, 417);
            this.gcMuvekkilOdeme.TabIndex = 0;
            this.gcMuvekkilOdeme.VerticalGorunsun = false;
        }

        private void CreateGcVekaletSozlesme()
        {
            this.gcVekaletSozlesme = new AdimAdimDavaKaydi.UserControls.UcDava.ucVekaletSozlesmesi();
            this.xtraTabPage10.Controls.Add(this.gcVekaletSozlesme);
            // 
            // gcVekaletSozlesme
            // 
            this.gcVekaletSozlesme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcVekaletSozlesme.Location = new System.Drawing.Point(0, 0);
            this.gcVekaletSozlesme.Name = "gcVekaletSozlesme";
            this.gcVekaletSozlesme.Size = new System.Drawing.Size(476, 417);
            this.gcVekaletSozlesme.TabIndex = 0;
        }

        private void CreateGcYapilacakIsSozlesme()
        {
            this.gcYapilacakIsSozlesme = new AdimAdimDavaKaydi.UserControls.UcDava.ucYapilcakIsSozlesme();
            this.xtraTabPage11.Controls.Add(this.gcYapilacakIsSozlesme);
            // 
            // gcYapilacakIsSozlesme
            // 
            this.gcYapilacakIsSozlesme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcYapilacakIsSozlesme.Location = new System.Drawing.Point(0, 0);
            this.gcYapilacakIsSozlesme.Name = "gcYapilacakIsSozlesme";
            this.gcYapilacakIsSozlesme.Size = new System.Drawing.Size(476, 417);
            this.gcYapilacakIsSozlesme.TabIndex = 0;
        }

        private void CreateGcMeslekMakbuzu()
        {
            this.gcMeslekMakbuzu = new AdimAdimDavaKaydi.Sorusturma.UserControls.ucMeslekMakbuzu();
            this.xtraTabPage5.Controls.Add(this.gcMeslekMakbuzu);
            // 
            // gcMeslekMakbuzu
            // 
            this.gcMeslekMakbuzu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMeslekMakbuzu.Location = new System.Drawing.Point(0, 0);
            this.gcMeslekMakbuzu.Name = "gcMeslekMakbuzu";
            this.gcMeslekMakbuzu.Size = new System.Drawing.Size(476, 417);
            this.gcMeslekMakbuzu.TabIndex = 0;
        }

        private void CreateUcMuhasebeGenel1()
        {
            this.ucMuhasebeGenel1 = new AdimAdimDavaKaydi.UserControls.ucMuhasebeGenel();
            this.xtraTabPage13.Controls.Add(this.ucMuhasebeGenel1);
            // 
            // ucMuhasebeGenel1
            // 
            this.ucMuhasebeGenel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMuhasebeGenel1.Location = new System.Drawing.Point(0, 0);
            this.ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = null;
            this.ucMuhasebeGenel1.Name = "ucMuhasebeGenel1";
            this.ucMuhasebeGenel1.SaveStatus = false;
            this.ucMuhasebeGenel1.Size = new System.Drawing.Size(469, 388);
            this.ucMuhasebeGenel1.TabIndex = 1;
        }

        private void CreateUcMuhasebeGenel2()
        {
            this.ucMuhasebeGenel2 = new AdimAdimDavaKaydi.UserControls.ucMuhasebeGenel();
            this.xtraTabPage19.Controls.Add(this.ucMuhasebeGenel2);
            // 
            // ucMuhasebeGenel2
            // 
            this.ucMuhasebeGenel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMuhasebeGenel2.Location = new System.Drawing.Point(0, 0);
            this.ucMuhasebeGenel2.MyPersonelCariHesapDetayli= null;
            this.ucMuhasebeGenel2.Name = "ucMuhasebeGenel2";
            this.ucMuhasebeGenel2.SaveStatus = false;
            this.ucMuhasebeGenel2.Size = new System.Drawing.Size(469, 388);
            this.ucMuhasebeGenel2.TabIndex = 2;
        }

        private void CreateGcPolice()
        {
            this.gcPolice = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaPolice();
            this.xtraTabPage6.Controls.Add(this.gcPolice);
            // 
            // gcPolice
            // 
            this.gcPolice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPolice.Location = new System.Drawing.Point(0, 0);
            this.gcPolice.MyType = AvukatProLib.Extras.ViewType.GridView;
            this.gcPolice.Name = "gcPolice";
            this.gcPolice.Size = new System.Drawing.Size(483, 446);
            this.gcPolice.TabIndex = 0;
        }

        private void CreateGcHasar()
        {
            this.gcHasar = new AdimAdimDavaKaydi.UserControls.UcDava.ucDavaHasar();
            this.xtraTabPage8.Controls.Add(this.gcHasar);
            // 
            // gcHasar
            // 
            this.gcHasar.Location = new System.Drawing.Point(0, 0);
            this.gcHasar.Name = "gcHasar";
            this.gcHasar.Size = new System.Drawing.Size(518, 356);
            this.gcHasar.TabIndex = 0;
        }

        private void CreateUcGorevler1()
        {
            this.ucGorevler1 = new AdimAdimDavaKaydi.Is.UserControls.ucGorevGrid();
            this.c_tpGorevler.Controls.Add(this.ucGorevler1);
            // 
            // ucGorevler1
            // 
            this.ucGorevler1.AllowInsert = false;
            this.ucGorevler1.AramaDockPanel = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            this.ucGorevler1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGorevler1.Location = new System.Drawing.Point(0, 0);
            this.ucGorevler1.Name = "ucGorevler1";
            this.ucGorevler1.SelectedRecord = null;
            this.ucGorevler1.SelectedRecordId = 0;
            this.ucGorevler1.ShowKayitEkranOnDoubleClick = false;
            this.ucGorevler1.Size = new System.Drawing.Size(483, 446);
            this.ucGorevler1.TabIndex = 0;

            this.ucGorevler1.Saved += new AdimAdimDavaKaydi.Is.UserControls.ucGorevGrid.OnSaved(ucGorevler1_Saved);
        }

        private void CreateUcTutuklanmaVeGozAlt1()
        {
            this.ucTutuklanmaVeGozAlt1 = new AdimAdimDavaKaydi.DavaTakip.ucTutuklanmaVeGozAlt();
            this.tbTutuklanma.Controls.Add(this.ucTutuklanmaVeGozAlt1);
            // 
            // ucTutuklanmaVeGozAlt1
            // 
            this.ucTutuklanmaVeGozAlt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTutuklanmaVeGozAlt1.Location = new System.Drawing.Point(0, 0);
            this.ucTutuklanmaVeGozAlt1.MyType = AvukatProLib.Extras.ViewType.GridView;
            this.ucTutuklanmaVeGozAlt1.Name = "ucTutuklanmaVeGozAlt1";
            this.ucTutuklanmaVeGozAlt1.Size = new System.Drawing.Size(483, 446);
            this.ucTutuklanmaVeGozAlt1.TabIndex = 0;
        }

        private void CreateUcSozlesmeGrid1()
        {
            this.ucSozlesmeGrid1 = new AdimAdimDavaKaydi.UserControls.ucSozlesmeGrid();
            this.tabDavaSozlesmeleri.Controls.Add(this.ucSozlesmeGrid1);
            // 
            // ucSozlesmeGrid1
            // 
            this.ucSozlesmeGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSozlesmeGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucSozlesmeGrid1.Name = "ucSozlesmeGrid1";
            this.ucSozlesmeGrid1.Size = new System.Drawing.Size(476, 417);
            this.ucSozlesmeGrid1.TabIndex = 1;
        }

        private void CreateUcTebligat1()
        {
            this.ucTebligatMuhatapForGiris1 = new AdimAdimDavaKaydi.UserControls.ucTebligatMuhatapForGiris();
            this.tabTebligatveGelenGidenEvrak.Controls.Add(this.ucTebligatMuhatapForGiris1);
            // 
            // ucTebligat1
            // 
            this.ucTebligatMuhatapForGiris1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTebligatMuhatapForGiris1.Location = new System.Drawing.Point(0, 0);
            this.ucTebligatMuhatapForGiris1.Name = "ucTebligat1";
            this.ucTebligatMuhatapForGiris1.Size = new System.Drawing.Size(483, 446);
            this.ucTebligatMuhatapForGiris1.TabIndex = 2;
        }

        private void CreateUcMuvekkilTalimatlari1()
        {
            this.ucMuvekkilTalimatlari1 = new AdimAdimDavaKaydi.UserControls.ucMuvekkilTalimatlari();
            this.tabPMuvekkilOdeme.Controls.Add(this.ucMuvekkilTalimatlari1);
            // 
            // ucMuvekkilTalimatlari1
            // 
            this.ucMuvekkilTalimatlari1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMuvekkilTalimatlari1.Location = new System.Drawing.Point(0, 0);
            this.ucMuvekkilTalimatlari1.Name = "ucMuvekkilTalimatlari1";
            this.ucMuvekkilTalimatlari1.Size = new System.Drawing.Size(483, 446);
            this.ucMuvekkilTalimatlari1.TabIndex = 0;
        }

        private void CreateGayrimenkulBilgileri()
        {
            this.GayrimenkulBilgileri = new AdimAdimDavaKaydi.ucGayriMenkul();
            this.xtraTabPage16.Controls.Add(this.GayrimenkulBilgileri);
            // 
            // GayrimenkulBilgileri
            // 
            this.GayrimenkulBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GayrimenkulBilgileri.Location = new System.Drawing.Point(0, 0);
            this.GayrimenkulBilgileri.Name = "GayrimenkulBilgileri";
            this.GayrimenkulBilgileri.Size = new System.Drawing.Size(476, 417);
            this.GayrimenkulBilgileri.TabIndex = 0;
        }

        private void CreateAracBilgileri()
        {
            this.AracBilgileri = new AdimAdimDavaKaydi.ucUcakGemiArac();
            this.xtraTabPage17.Controls.Add(this.AracBilgileri);
            // 
            // AracBilgileri
            // 
            this.AracBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AracBilgileri.KontrolTipi = AvukatProLib.Extras.GemiUcakAracTipi.Arac;
            this.AracBilgileri.Location = new System.Drawing.Point(0, 0);
            this.AracBilgileri.Name = "AracBilgileri";
            this.AracBilgileri.Size = new System.Drawing.Size(476, 417);
            this.AracBilgileri.TabIndex = 0;
        }

        private void CreateKiymetliEvrakBilgileri()
        {
            this.KiymetliEvrakBilgileri = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucKiymetliEvrakGrid();
            this.xtraTabPage18.Controls.Add(this.KiymetliEvrakBilgileri);
            // 
            // KiymetliEvrakBilgileri
            // 
            this.KiymetliEvrakBilgileri.AppenButtonEnabled = null;
            this.KiymetliEvrakBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KiymetliEvrakBilgileri.Location = new System.Drawing.Point(0, 0);
            this.KiymetliEvrakBilgileri.Name = "KiymetliEvrakBilgileri";
            this.KiymetliEvrakBilgileri.Size = new System.Drawing.Size(476, 417);
            this.KiymetliEvrakBilgileri.TabIndex = 0;
        }

        private void CreateSozlesmeBilgileri()
        {
            this.SozlesmeBilgileri = new AdimAdimDavaKaydi.UserControls.ucSozlesmeBilgi();
            this.tabPSozlesmeBilgileri.Controls.Add(this.SozlesmeBilgileri);
            // 
            // SozlesmeBilgileri
            // 
            this.SozlesmeBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SozlesmeBilgileri.Location = new System.Drawing.Point(0, 0);
            this.SozlesmeBilgileri.Name = "SozlesmeBilgileri";
            this.SozlesmeBilgileri.Size = new System.Drawing.Size(476, 417);
            this.SozlesmeBilgileri.TabIndex = 1;
        }

        private void CreateBelge()
        {
            this.belge = new AdimAdimDavaKaydi.Belge.UserControls.ucbelgetakip();
            this.belge.Location = new System.Drawing.Point(0, 0);
            this.belge.Name = "belge";
            this.belge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBelgeler.Controls.Add(belge);
        }

        #endregion

        public AdimAdimDavaKaydi.Belge.UserControls.ucbelgetakip belge;
        private DevExpress.XtraEditors.PanelControl panelControl11;
        private DevExpress.XtraTab.XtraTabControl tabGridler;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabCelseveArarKararBilgileri;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucCelseBilgileri gcCelse;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabDusmeYenileme;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucDavaDusmeYenileme gcDusmeYenileme;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabDavaNeden;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabKanit;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucKanit gcKanit;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabDavaliOdeme;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabHesap;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl2;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabDavaliOdemeleri;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucDavaliOdemeleri gcDavaOdeme;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabMasraf;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabDosyaMuhasebesi;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabPersonelHesabý;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabGelisme;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucDavaGelismeAdim gcDavaGelismeAdim;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabKayitIliskiDetay;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabAsama;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabGenelNotlar;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucDavaGenelNotlar ucGenelNotlar;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabDegisikIsveTeminat;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl3;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabTedbir;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucDavaTedbirBilgileri ucDavaTedbirBilgileri1;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabTespit;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucDavaTespitBilgi ucDavaTespitBilgi1;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabIletisim;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl4;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabGorusme;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucDavaGorusme gcGorusme;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabSms;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucDavaSMS gcSms;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabMail;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabHukumveTemyiz;
        private AdimAdimDavaKaydi.UserControls.ucMahkemeHukum gcMahkemeHukum;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabDavaIzah;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucDavaHikayesi gcDavaHikaye;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabMüvekkilHesabý;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xtraTabPage9;
        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucMuvekkilOdemeleri gcMuvekkilOdeme;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xtraTabPage10;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucVekaletSozlesmesi gcVekaletSozlesme;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xtraTabPage11;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucYapilcakIsSozlesme gcYapilacakIsSozlesme;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xtraTabPage5;
        private AdimAdimDavaKaydi.Sorusturma.UserControls.ucMeslekMakbuzu gcMeslekMakbuzu;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xtraTabPage3;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xtraTabPage6;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucDavaPolice gcPolice;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xtraTabPage8;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucDavaHasar gcHasar;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl6;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage c_tpGorevler;
        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucMasraflar ucMasraflar1;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucDavaliOdemeleri ucDavaliOdeme;
        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucMasraflar ucMasraflar2;
        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucMasraflar ucMasraflar3;
        //private AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge.ucbelgetakip ucbelgetakip1;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tbTutuklanma;
        private ucTutuklanmaVeGozAlt ucTutuklanmaVeGozAlt1;
        private AdimAdimDavaKaydi.UserControls.ucEPosta ucEPosta1;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private ucZTrackBar ucZTrackBar2;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private ucTrackBar ucTrackBar1;
        //private AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge.ucbelgetakip ucbelgetakip1;
        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit1;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabDokumanlar;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl5;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabBelgeler;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabDavaSozlesmeleri;
        private AdimAdimDavaKaydi.UserControls.ucSozlesmeGrid ucSozlesmeGrid1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl7;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabCelseBilgi;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabAraKaraar;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucAraKarar gcAraKarar;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl8;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabHukumBilgiler;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabTemyizbilgiler;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucTemyizBilgileri gcTemyiz;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucTeminatBilgileri gcTeminat;
        public AdimAdimDavaKaydi.UserControls.UcDava.ucDavaAsama gcAsama;
        public ucGorevGrid ucGorevler1;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xtraTabPage14;
        public AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay ucIliskiDetay1;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabTebligatveGelenGidenEvrak;
        private AdimAdimDavaKaydi.UserControls.ucTebligatMuhatapForGiris ucTebligatMuhatapForGiris1;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabPMuvekkilOdeme;
        private AdimAdimDavaKaydi.UserControls.ucMuvekkilTalimatlari ucMuvekkilTalimatlari1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl9;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabDavaTalep;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucDavaNeden gcDavaNeden;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabPIliskiliKayitlar;
        private DevExpress.XtraTab.XtraTabControl tabDnIliskiliKayitlar;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabPDnGayrimenkulBilgileri;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabPDnAracBilgileri;
        private ucGayriMenkul dnGayrimenkulBilgileri;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xtraTabPage15;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabPDnKiymetliEvrak;
        private ucKiymetliEvrakGrid dnKiymetliEvrakBilgileri;
        private AdimAdimDavaKaydi.UserControls.ucDavaHesapCetveliSon davaHesaplari;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabPIliskiliDKayýtlarý;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl11;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xtraTabPage16;
        private ucGayriMenkul GayrimenkulBilgileri;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xtraTabPage17;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage xtraTabPage18;
        private ucKiymetliEvrakGrid KiymetliEvrakBilgileri;
        private ucUcakGemiArac dnAracBilgileri;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabPDNSozlesmeBilgileri;
        private AdimAdimDavaKaydi.UserControls.ucSozlesmeBilgi dnSozlesmeBilgileri;
        private ucUcakGemiArac AracBilgileri;
        private AdimAdimDavaKaydi.Util.ExtendedTabPage tabPSozlesmeBilgileri;
        private AdimAdimDavaKaydi.UserControls.ucSozlesmeBilgi SozlesmeBilgileri;
        private DevExpress.XtraTab.XtraTabPage tbPPolice;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucDavaPolice ucDavaPolice1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl10;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage13;
        private AdimAdimDavaKaydi.UserControls.ucMuhasebeGenel ucMuhasebeGenel1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage19;
        private AdimAdimDavaKaydi.UserControls.ucMuhasebeGenel ucMuhasebeGenel2;
        private AdimAdimDavaKaydi.UserControls.ucMuhasebeGenel ucMuhasebeGenel3;
        private DevExpress.XtraEditors.PanelControl pnlButton;
        private DevExpress.XtraEditors.SimpleButton sbtnIliskiEkle;
        private DevExpress.XtraTab.XtraTabPage xTabPIadeAlinmamisTeminatlar;
        private DevExpress.XtraTab.XtraTabPage tabDavaHesabi;
    }
}
