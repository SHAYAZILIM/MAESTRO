using AvukatProLib.Util;
using DevExpress.XtraEditors;

namespace  AvukatProLib.Bakim
{
    partial class frmVeriTabaniSunucuIslemleri
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
            this.grdControlSunucuIslemleri = new DevExpress.XtraVerticalGrid.VGridControl();
            this.perSunucuIslemleri = new DevExpress.XtraEditors.Repository.PersistentRepository();
            this.aV001TDIBILCARIBindingSource = new System.Windows.Forms.BindingSource();
            this.dtNSunucuIslemleri = new DevExpress.XtraEditors.DataNavigator();
            this.cSKODPAKETBindingSource = new System.Windows.Forms.BindingSource();
            this.cS_KOD_PAKETTableAdapter = new AvukatProLib.Bakim.AVP_MYSDataSetTableAdapters.CS_KOD_PAKETTableAdapter();
            this.cS_KOD_FORM_LISTESI1TableAdapter = new AvukatProLib.Bakim.AVP_MYSDataSetTableAdapters.CS_KOD_FORM_LISTESI1TableAdapter();
            this.cS_KOD_FORM_LISTESITableAdapter = new AvukatProLib.Bakim.AVP_MYSDataSetTableAdapters.CS_KOD_FORM_LISTESITableAdapter();
            this.sunucuIslemleriBindingSource = new System.Windows.Forms.BindingSource();
            this.txtVeriTabaniSfr = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rudBaglantiZamanAsimi = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.rcbUygulamaProxyKullan = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.rudZaman = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.lueBaglantiTipi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlkKurumsalMod = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueConnectionTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueOturumAcmaModu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueUygulamaTipi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueHatirlatmaBilgisi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.btnDownloadsFolder = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnLogsFolder = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btnBackupFolder = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.crowPaket = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowPaket = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowLisansNo = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowBilgisayarID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowModulNo = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowUrunAdi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowBaslangicTarihi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowBitisTarihi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowVersiyon = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSurum = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.crowSirketBilgileri = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowSirketAdi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.crowUygulamaBilgileri = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowUygulamaTipi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.crowBaglantiTipi = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowBaglantiTipi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowOturumAçma = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.crowConnectionTip = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowConnectionTip = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.crowVeriTabani = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowVeriTabaniSunucu = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowVeriTabanýKullanicisi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowVeriTabaniKullaniciSfr = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowDomainAdi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowHAVeriTabani = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowMKVeriTabani = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSaKullaniciSfr = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowKomutZamanAsimi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowBaglantiZamanAsimi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.crowUygulamaSunucusu = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowUygulamaSunucuAdresi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowUProxyKullan = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.crowGuncelleme = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowSunucuAdresi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowGProxyKullan = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowBackupFolder = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowDownloadsFolder = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowLogsFolder = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTimeSchedule = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.crowProxyBilgileri = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowPSunucuAdresi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSunucuPortu = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowKullaniciAdi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowParola = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.crowOzelKodVeReferanslar = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowKurumsalMod = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.crowSMSBilgileri = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowSMSServisSaglayici = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSMSServisSaglayiciID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSMSGonderen = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSMSKullaniciAdi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSMSSifre = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSMSZamanAsimi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSMSIletisimTel = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSMSMusteriKodu = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSMSBayiKodu = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSMSApiKey = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSMSExtra1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSMSExtra2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSMSExtra3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.crowHatirlatmaBilgisi = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowHatirlatmaCokAcil = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowHatirlatmaAcil = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowHatirlatmaBekleyebilir = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.crowSmtpBilgileri = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowSmtpSunucu = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSmtpPort = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSmtpKullanýcýAdi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSmtpSifre = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSMTPSSL = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.cRowSistemTanimlari = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.cRowMuhHarTan = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowOtoMasrafUret = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowOtoKasaUret = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.cRowMuhYetkiliSifre = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowOnaySifresi1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowOnaySifresi2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowOnaySifresi3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.cRowDegisSilSifre = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowDegisSilSifresi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ((System.ComponentModel.ISupportInitialize)(this.grdControlSunucuIslemleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TDIBILCARIBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSKODPAKETBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sunucuIslemleriBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVeriTabaniSfr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rudBaglantiZamanAsimi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcbUygulamaProxyKullan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rudZaman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBaglantiTipi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkKurumsalMod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueConnectionTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOturumAcmaModu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueUygulamaTipi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueHatirlatmaBilgisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownloadsFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogsFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackupFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // grdControlSunucuIslemleri
            // 
            this.grdControlSunucuIslemleri.DataSource = this.sunucuIslemleriBindingSource;
            this.grdControlSunucuIslemleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdControlSunucuIslemleri.ExternalRepository = this.perSunucuIslemleri;
            this.grdControlSunucuIslemleri.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.grdControlSunucuIslemleri.Location = new System.Drawing.Point(0, 0);
            this.grdControlSunucuIslemleri.Name = "grdControlSunucuIslemleri";
            this.grdControlSunucuIslemleri.RecordWidth = 96;
            this.grdControlSunucuIslemleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rudZaman,
            this.repositoryItemRadioGroup1,
            this.lueBaglantiTipi,
            this.rlkKurumsalMod,
            this.rlueConnectionTip,
            this.repositoryItemLookUpEdit1,
            this.rLueOturumAcmaModu,
            this.rLueUygulamaTipi,
            this.rLueHatirlatmaBilgisi,
            this.repositoryItemDateEdit1,
            this.btnDownloadsFolder,
            this.btnLogsFolder,
            this.repositoryItemTimeEdit1,
            this.btnBackupFolder,
            this.repositoryItemCheckEdit1,
            this.repositoryItemLookUpEdit2});
            this.grdControlSunucuIslemleri.RowHeaderWidth = 104;
            this.grdControlSunucuIslemleri.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.crowPaket,
            this.crowSirketBilgileri,
            this.cRowSistemTanimlari,
            this.row,
            this.row1,
            this.row2});
            this.grdControlSunucuIslemleri.Size = new System.Drawing.Size(682, 444);
            this.grdControlSunucuIslemleri.TabIndex = 8;
            this.grdControlSunucuIslemleri.CustomUnboundData += new DevExpress.XtraVerticalGrid.Events.CustomDataEventHandler(this.grdControlSunucuIslemleri_CustomUnboundData);
            // 
            // perSunucuIslemleri
            // 
            this.perSunucuIslemleri.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.txtVeriTabaniSfr,
            this.rudBaglantiZamanAsimi,
            this.rcbUygulamaProxyKullan});
            // 
            // aV001TDIBILCARIBindingSource
            // 
            this.aV001TDIBILCARIBindingSource.DataSource = typeof(AvukatProLib2.Entities.AV001_TDI_BIL_CARI);
            // 
            // dtNSunucuIslemleri
            // 
            this.dtNSunucuIslemleri.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtNSunucuIslemleri.Location = new System.Drawing.Point(0, 444);
            this.dtNSunucuIslemleri.Name = "dtNSunucuIslemleri";
            this.dtNSunucuIslemleri.Size = new System.Drawing.Size(682, 24);
            this.dtNSunucuIslemleri.TabIndex = 9;
            this.dtNSunucuIslemleri.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.dtNSunucuIslemleri.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dtNSunucuIslemleri_ButtonClick);
            // 
            // cS_KOD_PAKETTableAdapter
            // 
            this.cS_KOD_PAKETTableAdapter.ClearBeforeFill = true;
            // 
            // cS_KOD_FORM_LISTESI1TableAdapter
            // 
            this.cS_KOD_FORM_LISTESI1TableAdapter.ClearBeforeFill = true;
            // 
            // cS_KOD_FORM_LISTESITableAdapter
            // 
            this.cS_KOD_FORM_LISTESITableAdapter.ClearBeforeFill = true;
            // 
            // sunucuIslemleriBindingSource
            // 
            this.sunucuIslemleriBindingSource.DataSource = typeof(AvukatProLib.CompInfo);
            // 
            // txtVeriTabaniSfr
            // 
            this.txtVeriTabaniSfr.Name = "txtVeriTabaniSfr";
            this.txtVeriTabaniSfr.PasswordChar = '*';
            // 
            // rudBaglantiZamanAsimi
            // 
            this.rudBaglantiZamanAsimi.AutoHeight = false;
            this.rudBaglantiZamanAsimi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rudBaglantiZamanAsimi.DisplayFormat.FormatString = "###.##0 ms";
            this.rudBaglantiZamanAsimi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rudBaglantiZamanAsimi.EditFormat.FormatString = "###.##0 ms";
            this.rudBaglantiZamanAsimi.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rudBaglantiZamanAsimi.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rudBaglantiZamanAsimi.Name = "rudBaglantiZamanAsimi";
            // 
            // rcbUygulamaProxyKullan
            // 
            this.rcbUygulamaProxyKullan.AutoHeight = false;
            this.rcbUygulamaProxyKullan.Name = "rcbUygulamaProxyKullan";
            this.rcbUygulamaProxyKullan.CheckedChanged += new System.EventHandler(this.rcbUygulamaProxyKullan_CheckedChanged);
            // 
            // rudZaman
            // 
            this.rudZaman.AutoHeight = false;
            this.rudZaman.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rudZaman.DisplayFormat.FormatString = "###0 ms";
            this.rudZaman.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rudZaman.EditFormat.FormatString = "###0 ms";
            this.rudZaman.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rudZaman.Name = "rudZaman";
            // 
            // repositoryItemRadioGroup1
            // 
            this.repositoryItemRadioGroup1.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "MS SQL"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Web Services")});
            this.repositoryItemRadioGroup1.Name = "repositoryItemRadioGroup1";
            // 
            // lueBaglantiTipi
            // 
            this.lueBaglantiTipi.AutoHeight = false;
            this.lueBaglantiTipi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBaglantiTipi.Name = "lueBaglantiTipi";
            this.lueBaglantiTipi.NullText = "Baðlantý Tipi Seçiniz";
            this.lueBaglantiTipi.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.lueBaglantiTipi_EditValueChanging);
            // 
            // rlkKurumsalMod
            // 
            this.rlkKurumsalMod.AutoHeight = false;
            this.rlkKurumsalMod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkKurumsalMod.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ModIsmi", "Mod Ýsmi"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ModNo", "Numara")});
            this.rlkKurumsalMod.DisplayMember = "ModIsmi";
            this.rlkKurumsalMod.Name = "rlkKurumsalMod";
            this.rlkKurumsalMod.NullText = "<Kurumsal Mod Seç>";
            this.rlkKurumsalMod.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.rlkKurumsalMod_EditValueChanging);
            // 
            // rlueConnectionTip
            // 
            this.rlueConnectionTip.AutoHeight = false;
            this.rlueConnectionTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueConnectionTip.Name = "rlueConnectionTip";
            this.rlueConnectionTip.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.rlueConnectionTip_EditValueChanging);
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PAKET_ADI", "PAKET ADI")});
            this.repositoryItemLookUpEdit1.DisplayMember = "PAKET_ADI";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "*";
            this.repositoryItemLookUpEdit1.ValueMember = "PAKET_ADI";
            // 
            // rLueOturumAcmaModu
            // 
            this.rLueOturumAcmaModu.AutoHeight = false;
            this.rLueOturumAcmaModu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueOturumAcmaModu.Name = "rLueOturumAcmaModu";
            this.rLueOturumAcmaModu.EditValueChanged += new System.EventHandler(this.rLueOturumAcmaModu_EditValueChanged);
            this.rLueOturumAcmaModu.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.rLueOturumAcmaModu_EditValueChanging);
            // 
            // rLueUygulamaTipi
            // 
            this.rLueUygulamaTipi.AutoHeight = false;
            this.rLueUygulamaTipi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueUygulamaTipi.DisplayMember = "Uygulama";
            this.rLueUygulamaTipi.Name = "rLueUygulamaTipi";
            this.rLueUygulamaTipi.ValueMember = "UygulamaTipi";
            // 
            // rLueHatirlatmaBilgisi
            // 
            this.rLueHatirlatmaBilgisi.AutoHeight = false;
            this.rLueHatirlatmaBilgisi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueHatirlatmaBilgisi.DisplayMember = "HatirlatmaBilgisi";
            this.rLueHatirlatmaBilgisi.Name = "rLueHatirlatmaBilgisi";
            this.rLueHatirlatmaBilgisi.ValueMember = "HatirlatmaTipi";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "hh:mm:ss";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemDateEdit1.EditFormat.FormatString = "hh:mm:ss";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // btnDownloadsFolder
            // 
            this.btnDownloadsFolder.AutoHeight = false;
            this.btnDownloadsFolder.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnDownloadsFolder.Name = "btnDownloadsFolder";
            this.btnDownloadsFolder.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnFolder_Click);
            // 
            // btnLogsFolder
            // 
            this.btnLogsFolder.AutoHeight = false;
            this.btnLogsFolder.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnLogsFolder.Name = "btnLogsFolder";
            this.btnLogsFolder.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnFolder_Click);
            // 
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.AutoHeight = false;
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
            // 
            // btnBackupFolder
            // 
            this.btnBackupFolder.AutoHeight = false;
            this.btnBackupFolder.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnBackupFolder.Name = "btnBackupFolder";
            this.btnBackupFolder.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnFolder_Click);
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KOD", "KOD", 31, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AD", "AD", 24, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit2.DataSource = this.aV001TDIBILCARIBindingSource;
            this.repositoryItemLookUpEdit2.DisplayMember = "AD";
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.ValueMember = "ID";
            // 
            // crowPaket
            // 
            this.crowPaket.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowPaket,
            this.rowLisansNo,
            this.rowBilgisayarID,
            this.rowModulNo,
            this.rowUrunAdi,
            this.rowBaslangicTarihi,
            this.rowBitisTarihi,
            this.rowVersiyon,
            this.rowSurum});
            this.crowPaket.Name = "crowPaket";
            this.crowPaket.Properties.Caption = "Paket Bilgisi";
            // 
            // rowPaket
            // 
            this.rowPaket.Name = "rowPaket";
            this.rowPaket.Properties.Caption = "Paket Adý";
            this.rowPaket.Properties.FieldName = "rowPaket0";
            this.rowPaket.Properties.ReadOnly = true;
            this.rowPaket.Properties.RowEdit = this.repositoryItemLookUpEdit1;
            this.rowPaket.Properties.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            // 
            // rowLisansNo
            // 
            this.rowLisansNo.Name = "rowLisansNo";
            this.rowLisansNo.Properties.Caption = "Lisans No";
            this.rowLisansNo.Properties.FieldName = "LisansNo";
            this.rowLisansNo.Properties.ReadOnly = true;
            // 
            // rowBilgisayarID
            // 
            this.rowBilgisayarID.Name = "rowBilgisayarID";
            this.rowBilgisayarID.Properties.Caption = "Bilgisayar ID";
            this.rowBilgisayarID.Properties.FieldName = "BilgisayarID";
            this.rowBilgisayarID.Properties.ReadOnly = true;
            // 
            // rowModulNo
            // 
            this.rowModulNo.Name = "rowModulNo";
            this.rowModulNo.Properties.Caption = "Modül No";
            this.rowModulNo.Properties.FieldName = "ModulNo";
            this.rowModulNo.Properties.ReadOnly = true;
            // 
            // rowUrunAdi
            // 
            this.rowUrunAdi.Name = "rowUrunAdi";
            this.rowUrunAdi.Properties.Caption = "Ürün Adý";
            this.rowUrunAdi.Properties.FieldName = "UrunAdi";
            this.rowUrunAdi.Properties.ReadOnly = true;
            // 
            // rowBaslangicTarihi
            // 
            this.rowBaslangicTarihi.Name = "rowBaslangicTarihi";
            this.rowBaslangicTarihi.Properties.Caption = "Baþlangýç Tarihi";
            this.rowBaslangicTarihi.Properties.FieldName = "BaslangicTarihi";
            this.rowBaslangicTarihi.Properties.ReadOnly = true;
            // 
            // rowBitisTarihi
            // 
            this.rowBitisTarihi.Name = "rowBitisTarihi";
            this.rowBitisTarihi.Properties.Caption = "Bitiþ Tarihi";
            this.rowBitisTarihi.Properties.FieldName = "BitisTarihi";
            this.rowBitisTarihi.Properties.ReadOnly = true;
            // 
            // rowVersiyon
            // 
            this.rowVersiyon.Name = "rowVersiyon";
            this.rowVersiyon.Properties.Caption = "Versiyon";
            this.rowVersiyon.Properties.FieldName = "Versiyon";
            this.rowVersiyon.Properties.ReadOnly = true;
            // 
            // rowSurum
            // 
            this.rowSurum.Name = "rowSurum";
            this.rowSurum.Properties.Caption = "Sürüm";
            this.rowSurum.Properties.FieldName = "Surum";
            this.rowSurum.Properties.ReadOnly = true;
            // 
            // crowSirketBilgileri
            // 
            this.crowSirketBilgileri.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowSirketAdi,
            this.crowUygulamaBilgileri,
            this.crowBaglantiTipi,
            this.crowConnectionTip,
            this.crowVeriTabani,
            this.crowUygulamaSunucusu,
            this.crowGuncelleme,
            this.crowProxyBilgileri,
            this.crowOzelKodVeReferanslar,
            this.crowSMSBilgileri,
            this.crowHatirlatmaBilgisi,
            this.crowSmtpBilgileri});
            this.crowSirketBilgileri.Height = 19;
            this.crowSirketBilgileri.Name = "crowSirketBilgileri";
            this.crowSirketBilgileri.Properties.Caption = "Þirket Bilgileri";
            // 
            // rowSirketAdi
            // 
            this.rowSirketAdi.Name = "rowSirketAdi";
            this.rowSirketAdi.Properties.Caption = "Þirket Adý";
            this.rowSirketAdi.Properties.FieldName = "CompanyName";
            // 
            // crowUygulamaBilgileri
            // 
            this.crowUygulamaBilgileri.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowUygulamaTipi});
            this.crowUygulamaBilgileri.Name = "crowUygulamaBilgileri";
            this.crowUygulamaBilgileri.Properties.Caption = "Uygulama Bilgileri";
            // 
            // rowUygulamaTipi
            // 
            this.rowUygulamaTipi.Name = "rowUygulamaTipi";
            this.rowUygulamaTipi.Properties.Caption = "Uygulama Tipi";
            this.rowUygulamaTipi.Properties.FieldName = "UygulamaTipi";
            this.rowUygulamaTipi.Properties.ReadOnly = true;
            this.rowUygulamaTipi.Properties.RowEdit = this.rLueUygulamaTipi;
            // 
            // crowBaglantiTipi
            // 
            this.crowBaglantiTipi.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowBaglantiTipi,
            this.rowOturumAçma});
            this.crowBaglantiTipi.Height = 15;
            this.crowBaglantiTipi.Name = "crowBaglantiTipi";
            this.crowBaglantiTipi.Properties.Caption = "Sunucu Tipi";
            // 
            // rowBaglantiTipi
            // 
            this.rowBaglantiTipi.Name = "rowBaglantiTipi";
            this.rowBaglantiTipi.Properties.Caption = "Baðlantý Tipi ";
            this.rowBaglantiTipi.Properties.FieldName = "BaglantiTipi";
            this.rowBaglantiTipi.Properties.RowEdit = this.lueBaglantiTipi;
            // 
            // rowOturumAçma
            // 
            this.rowOturumAçma.Height = 16;
            this.rowOturumAçma.Name = "rowOturumAçma";
            this.rowOturumAçma.Properties.Caption = "Oturum Açma";
            this.rowOturumAçma.Properties.FieldName = "OturumAcmaModu";
            this.rowOturumAçma.Properties.RowEdit = this.rLueOturumAcmaModu;
            // 
            // crowConnectionTip
            // 
            this.crowConnectionTip.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowConnectionTip});
            this.crowConnectionTip.Height = 19;
            this.crowConnectionTip.Name = "crowConnectionTip";
            this.crowConnectionTip.Properties.Caption = "Connection Tipi ";
            // 
            // rowConnectionTip
            // 
            this.rowConnectionTip.Name = "rowConnectionTip";
            this.rowConnectionTip.Properties.Caption = "Connection Tipi";
            this.rowConnectionTip.Properties.FieldName = "ConnectionTip";
            this.rowConnectionTip.Properties.RowEdit = this.rlueConnectionTip;
            // 
            // crowVeriTabani
            // 
            this.crowVeriTabani.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowVeriTabaniSunucu,
            this.rowDomainAdi,
            this.rowHAVeriTabani,
            this.rowMKVeriTabani,
            this.rowSaKullaniciSfr,
            this.rowKomutZamanAsimi,
            this.rowBaglantiZamanAsimi});
            this.crowVeriTabani.Name = "crowVeriTabani";
            this.crowVeriTabani.Properties.Caption = "Veri Tabaný";
            // 
            // rowVeriTabaniSunucu
            // 
            this.rowVeriTabaniSunucu.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowVeriTabanýKullanicisi,
            this.rowVeriTabaniKullaniciSfr});
            this.rowVeriTabaniSunucu.Name = "rowVeriTabaniSunucu";
            this.rowVeriTabaniSunucu.Properties.Caption = "VT Sunucu";
            this.rowVeriTabaniSunucu.Properties.FieldName = "VeriTabaniSunucu";
            // 
            // rowVeriTabanýKullanicisi
            // 
            this.rowVeriTabanýKullanicisi.Name = "rowVeriTabanýKullanicisi";
            this.rowVeriTabanýKullanicisi.Properties.Caption = "VT Kullanýcý Adý";
            this.rowVeriTabanýKullanicisi.Properties.FieldName = "VeriTabanýKullanicisi";
            // 
            // rowVeriTabaniKullaniciSfr
            // 
            this.rowVeriTabaniKullaniciSfr.Height = 16;
            this.rowVeriTabaniKullaniciSfr.Name = "rowVeriTabaniKullaniciSfr";
            this.rowVeriTabaniKullaniciSfr.Properties.Caption = "Veri Tabaný Kullanýcý Parolasý";
            this.rowVeriTabaniKullaniciSfr.Properties.FieldName = "VeriTabaniKullaniciSfr";
            this.rowVeriTabaniKullaniciSfr.Properties.RowEdit = this.txtVeriTabaniSfr;
            // 
            // rowDomainAdi
            // 
            this.rowDomainAdi.Name = "rowDomainAdi";
            this.rowDomainAdi.Properties.Caption = "Domain Adý";
            this.rowDomainAdi.Properties.FieldName = "DomainKullaniciAdi";
            this.rowDomainAdi.Visible = false;
            // 
            // rowHAVeriTabani
            // 
            this.rowHAVeriTabani.Name = "rowHAVeriTabani";
            this.rowHAVeriTabani.Properties.Caption = "NG Veri Tabaný";
            this.rowHAVeriTabani.Properties.FieldName = "HAVeriTabani";
            // 
            // rowMKVeriTabani
            // 
            this.rowMKVeriTabani.Name = "rowMKVeriTabani";
            this.rowMKVeriTabani.Properties.Caption = "MK Veri Tabaný";
            this.rowMKVeriTabani.Properties.FieldName = "MKVeriTabani";
            // 
            // rowSaKullaniciSfr
            // 
            this.rowSaKullaniciSfr.Name = "rowSaKullaniciSfr";
            this.rowSaKullaniciSfr.Properties.Caption = "SA Kullanýcý Parola";
            this.rowSaKullaniciSfr.Properties.FieldName = "SaKullaniciSfr";
            this.rowSaKullaniciSfr.Properties.RowEdit = this.txtVeriTabaniSfr;
            // 
            // rowKomutZamanAsimi
            // 
            this.rowKomutZamanAsimi.Name = "rowKomutZamanAsimi";
            this.rowKomutZamanAsimi.Properties.Caption = "Zaman Aþýmý (ms)";
            this.rowKomutZamanAsimi.Properties.FieldName = "KomutZamanAsimi";
            this.rowKomutZamanAsimi.Properties.RowEdit = this.rudZaman;
            // 
            // rowBaglantiZamanAsimi
            // 
            this.rowBaglantiZamanAsimi.Name = "rowBaglantiZamanAsimi";
            this.rowBaglantiZamanAsimi.Properties.Caption = "Baðlantý Zaman Aþýmý (ms)";
            this.rowBaglantiZamanAsimi.Properties.FieldName = "BaglantiZamanAsimi";
            this.rowBaglantiZamanAsimi.Properties.RowEdit = this.rudZaman;
            // 
            // crowUygulamaSunucusu
            // 
            this.crowUygulamaSunucusu.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowUygulamaSunucuAdresi,
            this.rowUProxyKullan});
            this.crowUygulamaSunucusu.Height = 19;
            this.crowUygulamaSunucusu.Name = "crowUygulamaSunucusu";
            this.crowUygulamaSunucusu.Properties.Caption = "Uygulama Sunucusu";
            // 
            // rowUygulamaSunucuAdresi
            // 
            this.rowUygulamaSunucuAdresi.Name = "rowUygulamaSunucuAdresi";
            this.rowUygulamaSunucuAdresi.Properties.Caption = "Uygulama Sunucu Adresi";
            this.rowUygulamaSunucuAdresi.Properties.FieldName = "UygulamaSunucuAdresi";
            // 
            // rowUProxyKullan
            // 
            this.rowUProxyKullan.Name = "rowUProxyKullan";
            this.rowUProxyKullan.Properties.Caption = "Proxy Kullan";
            this.rowUProxyKullan.Properties.FieldName = "UProxyKullan";
            this.rowUProxyKullan.Properties.RowEdit = this.rcbUygulamaProxyKullan;
            // 
            // crowGuncelleme
            // 
            this.crowGuncelleme.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowSunucuAdresi,
            this.rowGProxyKullan,
            this.rowBackupFolder,
            this.rowDownloadsFolder,
            this.rowLogsFolder,
            this.rowTimeSchedule});
            this.crowGuncelleme.Name = "crowGuncelleme";
            this.crowGuncelleme.Properties.Caption = "Güncelleme";
            // 
            // rowSunucuAdresi
            // 
            this.rowSunucuAdresi.Name = "rowSunucuAdresi";
            this.rowSunucuAdresi.Properties.Caption = "Sunucu Adresi";
            this.rowSunucuAdresi.Properties.FieldName = "GuncelSunucuAdresi";
            // 
            // rowGProxyKullan
            // 
            this.rowGProxyKullan.Name = "rowGProxyKullan";
            this.rowGProxyKullan.Properties.Caption = "Proxy Kullan";
            this.rowGProxyKullan.Properties.FieldName = "GuncelProxyKullan";
            this.rowGProxyKullan.Properties.RowEdit = this.rcbUygulamaProxyKullan;
            // 
            // rowBackupFolder
            // 
            this.rowBackupFolder.Name = "rowBackupFolder";
            this.rowBackupFolder.Properties.Caption = "Yedekleme Klasörü";
            this.rowBackupFolder.Properties.FieldName = "UpdaterBackupFolder";
            this.rowBackupFolder.Properties.RowEdit = this.btnBackupFolder;
            // 
            // rowDownloadsFolder
            // 
            this.rowDownloadsFolder.Height = 19;
            this.rowDownloadsFolder.Name = "rowDownloadsFolder";
            this.rowDownloadsFolder.Properties.Caption = "Ýndirilenler Klasörü";
            this.rowDownloadsFolder.Properties.FieldName = "DownloadsFolder";
            this.rowDownloadsFolder.Properties.RowEdit = this.btnDownloadsFolder;
            // 
            // rowLogsFolder
            // 
            this.rowLogsFolder.Name = "rowLogsFolder";
            this.rowLogsFolder.Properties.Caption = "Kayýt Bilgileri Klasörü";
            this.rowLogsFolder.Properties.FieldName = "LogsFolder";
            this.rowLogsFolder.Properties.RowEdit = this.btnLogsFolder;
            // 
            // rowTimeSchedule
            // 
            this.rowTimeSchedule.Name = "rowTimeSchedule";
            this.rowTimeSchedule.Properties.Caption = "Planlama Zamaný";
            this.rowTimeSchedule.Properties.FieldName = "TimeSchedule";
            this.rowTimeSchedule.Properties.RowEdit = this.repositoryItemTimeEdit1;
            // 
            // crowProxyBilgileri
            // 
            this.crowProxyBilgileri.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowPSunucuAdresi,
            this.rowSunucuPortu,
            this.rowKullaniciAdi,
            this.rowParola});
            this.crowProxyBilgileri.Height = 19;
            this.crowProxyBilgileri.Name = "crowProxyBilgileri";
            this.crowProxyBilgileri.Properties.Caption = "Proxy Bilgileri";
            // 
            // rowPSunucuAdresi
            // 
            this.rowPSunucuAdresi.Height = 17;
            this.rowPSunucuAdresi.Name = "rowPSunucuAdresi";
            this.rowPSunucuAdresi.Properties.Caption = "Sunucu Adresi";
            this.rowPSunucuAdresi.Properties.FieldName = "ProxySunucuAdresi";
            // 
            // rowSunucuPortu
            // 
            this.rowSunucuPortu.Name = "rowSunucuPortu";
            this.rowSunucuPortu.Properties.Caption = "Sunucu Portu";
            this.rowSunucuPortu.Properties.FieldName = "ProxySunucuPortu";
            // 
            // rowKullaniciAdi
            // 
            this.rowKullaniciAdi.Name = "rowKullaniciAdi";
            this.rowKullaniciAdi.Properties.Caption = "Kullanýcý Adý";
            this.rowKullaniciAdi.Properties.FieldName = "ProxyKullaniciAdi";
            // 
            // rowParola
            // 
            this.rowParola.Name = "rowParola";
            this.rowParola.Properties.Caption = "Parola";
            this.rowParola.Properties.FieldName = "ProxyParola";
            this.rowParola.Properties.RowEdit = this.txtVeriTabaniSfr;
            // 
            // crowOzelKodVeReferanslar
            // 
            this.crowOzelKodVeReferanslar.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowKurumsalMod});
            this.crowOzelKodVeReferanslar.Name = "crowOzelKodVeReferanslar";
            this.crowOzelKodVeReferanslar.Properties.Caption = "Özelkod ve Referanslar";
            // 
            // rowKurumsalMod
            // 
            this.rowKurumsalMod.Name = "rowKurumsalMod";
            this.rowKurumsalMod.Properties.Caption = "Kurumsal Mod";
            this.rowKurumsalMod.Properties.FieldName = "rowKurumsalMod0";
            this.rowKurumsalMod.Properties.RowEdit = this.rlkKurumsalMod;
            this.rowKurumsalMod.Properties.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            // 
            // crowSMSBilgileri
            // 
            this.crowSMSBilgileri.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowSMSServisSaglayici,
            this.rowSMSServisSaglayiciID,
            this.rowSMSGonderen,
            this.rowSMSKullaniciAdi,
            this.rowSMSSifre,
            this.rowSMSZamanAsimi,
            this.rowSMSIletisimTel,
            this.rowSMSMusteriKodu,
            this.rowSMSBayiKodu,
            this.rowSMSApiKey,
            this.rowSMSExtra1,
            this.rowSMSExtra2,
            this.rowSMSExtra3});
            this.crowSMSBilgileri.Name = "crowSMSBilgileri";
            this.crowSMSBilgileri.Properties.Caption = "SMS Bilgileri";
            // 
            // rowSMSServisSaglayici
            // 
            this.rowSMSServisSaglayici.Enabled = false;
            this.rowSMSServisSaglayici.Name = "rowSMSServisSaglayici";
            this.rowSMSServisSaglayici.Properties.Caption = "Servis Saðlayýcý (Sunucu firma)";
            this.rowSMSServisSaglayici.Properties.FieldName = "SMSServisSaglayici";
            // 
            // rowSMSServisSaglayiciID
            // 
            this.rowSMSServisSaglayiciID.Enabled = false;
            this.rowSMSServisSaglayiciID.Height = 17;
            this.rowSMSServisSaglayiciID.Name = "rowSMSServisSaglayiciID";
            this.rowSMSServisSaglayiciID.Properties.Caption = "Saðlayýcý ID";
            this.rowSMSServisSaglayiciID.Properties.FieldName = "SMSServisSaglayiciID";
            // 
            // rowSMSGonderen
            // 
            this.rowSMSGonderen.Name = "rowSMSGonderen";
            this.rowSMSGonderen.Properties.Caption = "Gönderen (Servisi kullanan firma veya kiþi)";
            this.rowSMSGonderen.Properties.FieldName = "SMSGonderen";
            // 
            // rowSMSKullaniciAdi
            // 
            this.rowSMSKullaniciAdi.Name = "rowSMSKullaniciAdi";
            this.rowSMSKullaniciAdi.Properties.Caption = "Kullanýcý Adý (Sunucu firmadan alýnan Kullanýcý Adý)";
            this.rowSMSKullaniciAdi.Properties.FieldName = "SMSKullaniciAdi";
            // 
            // rowSMSSifre
            // 
            this.rowSMSSifre.Name = "rowSMSSifre";
            this.rowSMSSifre.Properties.Caption = "Þifre (Sunucu firmadan alýnan Kullanýcý Þifre)";
            this.rowSMSSifre.Properties.FieldName = "SMSSifre";
            // 
            // rowSMSZamanAsimi
            // 
            this.rowSMSZamanAsimi.Enabled = false;
            this.rowSMSZamanAsimi.Name = "rowSMSZamanAsimi";
            this.rowSMSZamanAsimi.Properties.Caption = "Zaman Aþýmý";
            this.rowSMSZamanAsimi.Properties.FieldName = "SMSMaxGonderimSuresi";
            // 
            // rowSMSIletisimTel
            // 
            this.rowSMSIletisimTel.Name = "rowSMSIletisimTel";
            this.rowSMSIletisimTel.Properties.Caption = "SMS Iletisim Tel ( Firma Ýletiþim tel no)";
            this.rowSMSIletisimTel.Properties.FieldName = "SMSIletisimTel";
            // 
            // rowSMSMusteriKodu
            // 
            this.rowSMSMusteriKodu.Name = "rowSMSMusteriKodu";
            this.rowSMSMusteriKodu.Properties.Caption = "SMS Musteri Kodu (Sunucu Firmadan alýnan  müþteri kodu)";
            this.rowSMSMusteriKodu.Properties.FieldName = "SMSMusteriKodu";
            // 
            // rowSMSBayiKodu
            // 
            this.rowSMSBayiKodu.Name = "rowSMSBayiKodu";
            this.rowSMSBayiKodu.Properties.Caption = "SMS Bayi Kodu (Sunucu firmadan alýnan Vendor Id)";
            this.rowSMSBayiKodu.Properties.FieldName = "SMSBayiKodu";
            // 
            // rowSMSApiKey
            // 
            this.rowSMSApiKey.Name = "rowSMSApiKey";
            this.rowSMSApiKey.Properties.Caption = "SMS Api Key ( Sunucu firmadan alýnan Api Key)";
            this.rowSMSApiKey.Properties.FieldName = "SMSApiKey";
            // 
            // rowSMSExtra1
            // 
            this.rowSMSExtra1.Name = "rowSMSExtra1";
            this.rowSMSExtra1.Properties.Caption = "Extra1";
            this.rowSMSExtra1.Properties.FieldName = "SMSExtra1";
            // 
            // rowSMSExtra2
            // 
            this.rowSMSExtra2.Name = "rowSMSExtra2";
            this.rowSMSExtra2.Properties.Caption = "Extra2";
            this.rowSMSExtra2.Properties.FieldName = "SMSExtra2";
            // 
            // rowSMSExtra3
            // 
            this.rowSMSExtra3.Name = "rowSMSExtra3";
            this.rowSMSExtra3.Properties.Caption = "Extra3";
            this.rowSMSExtra3.Properties.FieldName = "SMSExtra3";
            // 
            // crowHatirlatmaBilgisi
            // 
            this.crowHatirlatmaBilgisi.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowHatirlatmaCokAcil,
            this.rowHatirlatmaAcil,
            this.rowHatirlatmaBekleyebilir});
            this.crowHatirlatmaBilgisi.Name = "crowHatirlatmaBilgisi";
            this.crowHatirlatmaBilgisi.Properties.Caption = "Hatýrlatma Bilgisi";
            // 
            // rowHatirlatmaCokAcil
            // 
            this.rowHatirlatmaCokAcil.Name = "rowHatirlatmaCokAcil";
            this.rowHatirlatmaCokAcil.Properties.Caption = "ÇOK ACÝL";
            this.rowHatirlatmaCokAcil.Properties.FieldName = "HatirlatmaCokAcil";
            this.rowHatirlatmaCokAcil.Properties.RowEdit = this.rLueHatirlatmaBilgisi;
            // 
            // rowHatirlatmaAcil
            // 
            this.rowHatirlatmaAcil.Name = "rowHatirlatmaAcil";
            this.rowHatirlatmaAcil.Properties.Caption = "ACÝL";
            this.rowHatirlatmaAcil.Properties.FieldName = "HatirlatmaAcil";
            this.rowHatirlatmaAcil.Properties.RowEdit = this.rLueHatirlatmaBilgisi;
            // 
            // rowHatirlatmaBekleyebilir
            // 
            this.rowHatirlatmaBekleyebilir.Name = "rowHatirlatmaBekleyebilir";
            this.rowHatirlatmaBekleyebilir.Properties.Caption = "BEKLEYEBÝLÝR";
            this.rowHatirlatmaBekleyebilir.Properties.FieldName = "HatirlatmaBekleyebilir";
            this.rowHatirlatmaBekleyebilir.Properties.RowEdit = this.rLueHatirlatmaBilgisi;
            // 
            // crowSmtpBilgileri
            // 
            this.crowSmtpBilgileri.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowSmtpSunucu,
            this.rowSmtpPort,
            this.rowSmtpKullanýcýAdi,
            this.rowSmtpSifre,
            this.rowSMTPSSL});
            this.crowSmtpBilgileri.Name = "crowSmtpBilgileri";
            this.crowSmtpBilgileri.Properties.Caption = "Mail Server Bilgileri";
            // 
            // rowSmtpSunucu
            // 
            this.rowSmtpSunucu.Height = 16;
            this.rowSmtpSunucu.Name = "rowSmtpSunucu";
            this.rowSmtpSunucu.Properties.Caption = "Giden Sunucu Adresi";
            this.rowSmtpSunucu.Properties.FieldName = "SMTPSunucuAdresi";
            // 
            // rowSmtpPort
            // 
            this.rowSmtpPort.Name = "rowSmtpPort";
            this.rowSmtpPort.Properties.Caption = "Giden Sunucu Port Numarasý";
            this.rowSmtpPort.Properties.FieldName = "SMTPPort";
            // 
            // rowSmtpKullanýcýAdi
            // 
            this.rowSmtpKullanýcýAdi.Name = "rowSmtpKullanýcýAdi";
            this.rowSmtpKullanýcýAdi.Properties.Caption = "Kullanýcý Adý (Email Adresi)";
            this.rowSmtpKullanýcýAdi.Properties.FieldName = "SMTPKullaniciAdi";
            // 
            // rowSmtpSifre
            // 
            this.rowSmtpSifre.Name = "rowSmtpSifre";
            this.rowSmtpSifre.Properties.Caption = "Þifre (Email Þifresi)";
            this.rowSmtpSifre.Properties.FieldName = "SMTPSifre";
            this.rowSmtpSifre.Properties.RowEdit = this.txtVeriTabaniSfr;
            // 
            // rowSMTPSSL
            // 
            this.rowSMTPSSL.Height = 16;
            this.rowSMTPSSL.Name = "rowSMTPSSL";
            this.rowSMTPSSL.Properties.Caption = "Giden Sunucu Güvenlik Sertifikasý Gerektiriyor Mu ?";
            this.rowSMTPSSL.Properties.FieldName = "SMTPSSL";
            this.rowSMTPSSL.Properties.RowEdit = this.rcbUygulamaProxyKullan;
            // 
            // cRowSistemTanimlari
            // 
            this.cRowSistemTanimlari.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.cRowMuhHarTan,
            this.cRowMuhYetkiliSifre,
            this.cRowDegisSilSifre});
            this.cRowSistemTanimlari.Name = "cRowSistemTanimlari";
            // 
            // cRowMuhHarTan
            // 
            this.cRowMuhHarTan.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowOtoMasrafUret,
            this.rowOtoKasaUret});
            this.cRowMuhHarTan.Name = "cRowMuhHarTan";
            this.cRowMuhHarTan.Properties.Caption = "Muhasebe Hareket Tanýmlarý";
            // 
            // rowOtoMasrafUret
            // 
            this.rowOtoMasrafUret.Name = "rowOtoMasrafUret";
            this.rowOtoMasrafUret.Properties.Caption = "Otomatik Masraf Üretilmesin";
            this.rowOtoMasrafUret.Properties.FieldName = "OtoMasrafUretilmesin";
            this.rowOtoMasrafUret.Properties.RowEdit = this.repositoryItemCheckEdit1;
            // 
            // rowOtoKasaUret
            // 
            this.rowOtoKasaUret.Name = "rowOtoKasaUret";
            this.rowOtoKasaUret.Properties.Caption = "Otomatik Kasa Hareketi Üretilmesin";
            this.rowOtoKasaUret.Properties.FieldName = "OtoKasaHareketiUretilmesin";
            this.rowOtoKasaUret.Properties.RowEdit = this.repositoryItemCheckEdit1;
            // 
            // cRowMuhYetkiliSifre
            // 
            this.cRowMuhYetkiliSifre.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowOnaySifresi1,
            this.rowOnaySifresi2,
            this.rowOnaySifresi3});
            this.cRowMuhYetkiliSifre.Name = "cRowMuhYetkiliSifre";
            this.cRowMuhYetkiliSifre.Properties.Caption = "Muhasebe Yetkili Þifre Tanýmlarý";
            // 
            // rowOnaySifresi1
            // 
            this.rowOnaySifresi1.Name = "rowOnaySifresi1";
            this.rowOnaySifresi1.Properties.Caption = "1. Onay Þifresi";
            this.rowOnaySifresi1.Properties.FieldName = "OnaySifresi1";
            // 
            // rowOnaySifresi2
            // 
            this.rowOnaySifresi2.Name = "rowOnaySifresi2";
            this.rowOnaySifresi2.Properties.Caption = "2. Onay Þifresi";
            this.rowOnaySifresi2.Properties.FieldName = "OnaySifresi2";
            // 
            // rowOnaySifresi3
            // 
            this.rowOnaySifresi3.Name = "rowOnaySifresi3";
            this.rowOnaySifresi3.Properties.Caption = "3. Onay Þifresi";
            this.rowOnaySifresi3.Properties.FieldName = "OnaySifresi3";
            // 
            // cRowDegisSilSifre
            // 
            this.cRowDegisSilSifre.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowDegisSilSifresi});
            this.cRowDegisSilSifre.Name = "cRowDegisSilSifre";
            this.cRowDegisSilSifre.Properties.Caption = "Deðiþtirme-Silme Þifre Tanýmlarý";
            // 
            // rowDegisSilSifresi
            // 
            this.rowDegisSilSifresi.Name = "rowDegisSilSifresi";
            this.rowDegisSilSifresi.Properties.Caption = "Deðiþtirme-Silme Þifresi";
            this.rowDegisSilSifresi.Properties.FieldName = "DegistirmeSilmeSifresi";
            // 
            // row
            // 
            this.row.Name = "row";
            this.row.Properties.Caption = "Tebligat Muhattap";
            this.row.Properties.FieldName = "TebligatVarsayilanCariId";
            this.row.Properties.RowEdit = this.repositoryItemLookUpEdit2;
            // 
            // row1
            // 
            this.row1.Name = "row1";
            this.row1.Properties.Caption = "Tebligat Ýþ Cari 1";
            this.row1.Properties.FieldName = "TebligatIsCariId";
            this.row1.Properties.RowEdit = this.repositoryItemLookUpEdit2;
            // 
            // row2
            // 
            this.row2.Name = "row2";
            this.row2.Properties.Caption = "Tebligat Ýþ Cari 2";
            this.row2.Properties.FieldName = "TebligatIsCariId2";
            this.row2.Properties.RowEdit = this.repositoryItemLookUpEdit2;
            // 
            // frmVeriTabaniSunucuIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 468);
            this.Controls.Add(this.grdControlSunucuIslemleri);
            this.Controls.Add(this.dtNSunucuIslemleri);
            this.Name = "frmVeriTabaniSunucuIslemleri";
            this.Text = "Veri Tabani Sunucu Islemleri";
            this.Load += new System.EventHandler(this.frmVeriTabaniSunucuIslemleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdControlSunucuIslemleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TDIBILCARIBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSKODPAKETBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sunucuIslemleriBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVeriTabaniSfr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rudBaglantiZamanAsimi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcbUygulamaProxyKullan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rudZaman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBaglantiTipi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkKurumsalMod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueConnectionTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueOturumAcmaModu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueUygulamaTipi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueHatirlatmaBilgisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownloadsFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogsFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackupFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private DevExpress.XtraVerticalGrid.VGridControl grdControlSunucuIslemleri;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rudZaman;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueBaglantiTipi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowBaglantiTipi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSirketAdi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowGProxyKullan;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowUProxyKullan;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowVeriTabanýKullanicisi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowVeriTabaniSunucu;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHAVeriTabani;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowKomutZamanAsimi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSaKullaniciSfr;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMKVeriTabani;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowVeriTabaniKullaniciSfr;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowBaglantiZamanAsimi;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow crowSirketBilgileri;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow crowBaglantiTipi;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow crowVeriTabani;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow crowUygulamaSunucusu;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowUygulamaSunucuAdresi;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow crowGuncelleme;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSunucuAdresi;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow crowProxyBilgileri;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowPSunucuAdresi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSunucuPortu;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowKullaniciAdi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowParola;
        private DataNavigator dtNSunucuIslemleri;
        private System.Windows.Forms.BindingSource sunucuIslemleriBindingSource;
        private DevExpress.XtraEditors.Repository.PersistentRepository perSunucuIslemleri;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtVeriTabaniSfr;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rudBaglantiZamanAsimi;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rcbUygulamaProxyKullan;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow crowOzelKodVeReferanslar;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkKurumsalMod;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowKurumsalMod;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow crowConnectionTip;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueConnectionTip;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowConnectionTip;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDomainAdi;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow crowPaket;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowPaket;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource cSKODPAKETBindingSource;
        private AvukatProLib.Bakim.AVP_MYSDataSetTableAdapters.CS_KOD_PAKETTableAdapter cS_KOD_PAKETTableAdapter;
        private AvukatProLib.Bakim.AVP_MYSDataSetTableAdapters.CS_KOD_FORM_LISTESI1TableAdapter cS_KOD_FORM_LISTESI1TableAdapter;
        private AvukatProLib.Bakim.AVP_MYSDataSetTableAdapters.CS_KOD_FORM_LISTESITableAdapter cS_KOD_FORM_LISTESITableAdapter;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowOturumAçma;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueOturumAcmaModu;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow crowSmtpBilgileri;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSmtpSunucu;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSmtpPort;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSmtpKullanýcýAdi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSmtpSifre;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow crowSMSBilgileri;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSMSServisSaglayici;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSMSServisSaglayiciID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSMSKullaniciAdi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSMSSifre;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSMSZamanAsimi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSMSExtra1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSMSExtra2;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSMSExtra3;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHatirlatmaCokAcil;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHatirlatmaAcil;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHatirlatmaBekleyebilir;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow crowHatirlatmaBilgisi;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow crowUygulamaBilgileri;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowUygulamaTipi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSMSGonderen;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueUygulamaTipi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueHatirlatmaBilgisi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowBackupFolder;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDownloadsFolder;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowLogsFolder;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTimeSchedule;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDownloadsFolder;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnLogsFolder;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnBackupFolder;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSMTPSSL;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSMSIletisimTel;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSMSMusteriKodu;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSMSBayiKodu;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSMSApiKey;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowLisansNo;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowBilgisayarID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowModulNo;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowUrunAdi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowBaslangicTarihi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowBitisTarihi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowVersiyon;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSurum;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow cRowSistemTanimlari;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow cRowMuhHarTan;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowOtoMasrafUret;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowOtoKasaUret;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow cRowMuhYetkiliSifre;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow cRowDegisSilSifre;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowOnaySifresi1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowOnaySifresi2;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowOnaySifresi3;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDegisSilSifresi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row;
        private System.Windows.Forms.BindingSource aV001TDIBILCARIBindingSource;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row2;


    }
}
