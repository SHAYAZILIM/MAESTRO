namespace  AdimAdimDavaKaydi.Forms.Icra
{
    partial class frmAlacakGirisi
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
            this.ucAlacakNedenGirisi1 = new AdimAdimDavaKaydi.UserControls.ucAlacakNedenGirisi();
            this.ucAlacakNedenTaraf1 = new AdimAdimDavaKaydi.IcraTakip.UserControls.ucAlacakNedenTaraf();
            this.ucAlacakNedenTaraf_Faiz1 = new AdimAdimDavaKaydi.IcraTakip.UserControls.ucAlacakNedenTaraf_Faiz();
            this.tcAlacakGirisi = new DevExpress.XtraTab.XtraTabControl();
            this.tabDigerBilgiler = new DevExpress.XtraTab.XtraTabPage();
            this.btnMasrafEkle = new DevExpress.XtraEditors.SimpleButton();
            this.ucTebligatKayitUfakDock1 = new AdimAdimDavaKaydi.UserControls.ucTebligatKayitUfakDock();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.gcAlacak = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.aV001TIBILALACAKNEDENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gwAlacak = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALACAK_NEDEN_KOD_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIGER_ALACAK_NEDENI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDUZENLENME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVADE_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_BASLANGIC_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHESAPLAMA_MODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTUTARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTUTAR_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISLEME_KONAN_TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHARCA_ESAS_DEGER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHARCA_ESAS_DEGER_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_YOK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALACAK_FAIZ_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUYGULANACAK_FAIZ_ORANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTO_ALACAK_FAIZ_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTO_UYGULANACAK_FAIZ_ORANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSABIT_FAIZ_UYGULA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBIR_GUNE_AYLIK_FAIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIHTAR_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIHTAR_GIDERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIHTAR_GIDERI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROTESTO_GIDERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROTESTO_GIDERI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHER_AY_TAZMINAT_EKLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAZMINAT_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAZMINATI_ORANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCEK_TAZMINATI_ORANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKOMISYONU_ORANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBSMV_HESAPLANSIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKKDV_HESAPLANSIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOIV_HESAPLANSIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKDV_HESAPLANSIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKDV_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDAMGA_PULU_HESAPLANSIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSURE_GUN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSURE_AY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSURE_YIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colREFERANS_NO2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colREFERANS_NO3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GEMI_UCAK_ARAC_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CINSI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TESCIL_NUMARASI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TANIMA_ISARETI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.INSA_YILI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.INSA_YERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BOYU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ENI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TONALITOSU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BAGLAMA_LIMANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEKNIK_KUTUK_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ERISIM_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TIPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DERINLIGI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KUTUK_BOYU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ARAC_PLAKA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ARAC_MODEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ARAC_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ARAC_MOTOR_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ARAC_SASI_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ARAC_RENK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TRAFIK_SUBESI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RUHSAT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RUHSAT_SICIL_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colICRA_ALACAK_NEDEN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTARAF_CARI_ID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_BASLANGIC_TARIHI1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_BITIS_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSABIT_FAIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBIR_GUNE_AYLIK_FAIZ1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.EVRAK_TUR_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EVRAK_KAYIT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EVRAK_VADE_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EVRAK_TANZIM_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TUTAR_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NE_SEKILDE_AHZOLUNDUGU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BANKA_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SUBE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BANKA_SUBE_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HESAP_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CEK_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SORULDUGU_TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SORULMA_SONUCU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KARSILIK_TUTAR_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KARSILIK_TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SORAN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ARKASI_YAZILDI_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SERH_ACIKLAMASI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ILK_ALACAKLI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ILK_BORCLU_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SIKAYET_EDILDI_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KESIDE_YERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ODEME_YERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ISLEMLER_BASLADIMI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TUR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOZLESME_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOZLESME_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ALT_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TASNIF_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OZEL_KOD1_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OZEL_KOD2_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OZEL_KOD3_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OZEL_KOD4_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TASLAK_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IMZA_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BASLANGIC_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.YENILENME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SON_ISLEM_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BITIS_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BITIRILME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SURE_GUN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SURE_AY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SURE_YIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NOTER_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NOTER_YEVMIYE_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ADLI_BIRIM_ADLIYE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ADLI_BIRIM_GOREV_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ADLI_BIRIM_NO_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.YEDI_EMIN_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BEDELI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BEDELI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TAHLIYE_TAAHHUT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TAHLIYE_ADRESI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KART_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KREDI_KART_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CVV1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CVV2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SON_KULLANIM_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REHIN_CINS_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BORC_IKRARINI_HAVI_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HARC_ISTISNA_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HARC_ISTISNA_BELGE_TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HARC_ISTISNA_BELGE_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REHIN_DERECE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REHIN_SIRA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SICIL_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SICIL_BOLGE_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SICIL_ILCE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SICIL_IL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SICIL_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SICIL_YEVMIYE_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SICIL_TESCIL_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FEK_TARIHI3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REHIN_DURUM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOZLESME_DURUM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DURUM_ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REHIN_CINS_ANA_TURU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ISLEMLER_BASLADIMI1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UCRETIN_ODENME_SEKLI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HAKEM_YARGILAMASININ_YERI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SURE_UYGULAMA_TIPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView11 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TARAF_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IHTAR_TEBLIG_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEMERRUT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ZAMAN_ASIMI_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IHTAR_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn141 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn143 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn144 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn151 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn159 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn164 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabOnPanel = new DevExpress.XtraTab.XtraTabPage();
            this.tabKiymetliEvrak = new DevExpress.XtraTab.XtraTabPage();
            this.ucKiymetliEvrakTaraf1 = new AdimAdimDavaKaydi.ucKiymetliEvrakTaraf();
            this.ucKiymetliEvrak1 = new AdimAdimDavaKaydi.ucKiymetliEvrak();
            this.rlueAlacakNedeni = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueDovizID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcAlacakGirisi)).BeginInit();
            this.tcAlacakGirisi.SuspendLayout();
            this.tabDigerBilgiler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAlacak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TIBILALACAKNEDENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwAlacak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).BeginInit();
            this.tabOnPanel.SuspendLayout();
            this.tabKiymetliEvrak.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAlacakNedeni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDovizID)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.c_pnlAltButtons.Appearance.Options.UseBackColor = true;
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 616);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(509, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(359, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(434, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.tcAlacakGirisi);
            this.c_pnlContainer.Size = new System.Drawing.Size(509, 641);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.tcAlacakGirisi, 0);
            // 
            // ucAlacakNedenGirisi1
            // 
            this.ucAlacakNedenGirisi1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucAlacakNedenGirisi1.DtAlacakNeden = null;
            this.ucAlacakNedenGirisi1.Foy = null;
            this.ucAlacakNedenGirisi1.Location = new System.Drawing.Point(0, 0);
            this.ucAlacakNedenGirisi1.MyIcraTaraf = null;
            this.ucAlacakNedenGirisi1.Name = "ucAlacakNedenGirisi1";
            this.ucAlacakNedenGirisi1.SeciliNedenler = null;
            this.ucAlacakNedenGirisi1.ShowOnlyGridControl = false;
            this.ucAlacakNedenGirisi1.Size = new System.Drawing.Size(610, 604);
            this.ucAlacakNedenGirisi1.TabIndex = 0;
            this.ucAlacakNedenGirisi1.TakipsizAlacakMi = true;
            this.ucAlacakNedenGirisi1.FocusedNedenChanged += new DevExpress.XtraVerticalGrid.Events.IndexChangedEventHandler(this.ucAlacakNedenGirisi1_FocusedNedenChanged);
            this.ucAlacakNedenGirisi1.ValidateRecord += new DevExpress.XtraVerticalGrid.Events.ValidateRecordEventHandler(this.Neden_ValidateRecord);
            // 
            // ucAlacakNedenTaraf1
            // 
            this.ucAlacakNedenTaraf1.CanEditCari = true;
            this.ucAlacakNedenTaraf1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAlacakNedenTaraf1.DtAlacakNeden = null;
            this.ucAlacakNedenTaraf1.Location = new System.Drawing.Point(610, 0);
            this.ucAlacakNedenTaraf1.Name = "ucAlacakNedenTaraf1";
            this.ucAlacakNedenTaraf1.Size = new System.Drawing.Size(305, 331);
            this.ucAlacakNedenTaraf1.TabIndex = 1;
            this.ucAlacakNedenTaraf1.FocusedTarafChanged += new DevExpress.XtraVerticalGrid.Events.IndexChangedEventHandler(this.ucAlacakNedenTaraf1_FocusedTarafChanged);
            // 
            // ucAlacakNedenTaraf_Faiz1
            // 
            this.ucAlacakNedenTaraf_Faiz1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucAlacakNedenTaraf_Faiz1.DtAlacakNeden = null;
            this.ucAlacakNedenTaraf_Faiz1.Location = new System.Drawing.Point(610, 331);
            this.ucAlacakNedenTaraf_Faiz1.Name = "ucAlacakNedenTaraf_Faiz1";
            this.ucAlacakNedenTaraf_Faiz1.Size = new System.Drawing.Size(305, 273);
            this.ucAlacakNedenTaraf_Faiz1.TabIndex = 2;
            // 
            // tcAlacakGirisi
            // 
            this.tcAlacakGirisi.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.tcAlacakGirisi.Appearance.Options.UseBackColor = true;
            this.tcAlacakGirisi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcAlacakGirisi.Location = new System.Drawing.Point(0, 0);
            this.tcAlacakGirisi.Name = "tcAlacakGirisi";
            this.tcAlacakGirisi.SelectedTabPage = this.tabDigerBilgiler;
            this.tcAlacakGirisi.Size = new System.Drawing.Size(509, 616);
            this.tcAlacakGirisi.TabIndex = 9;
            this.tcAlacakGirisi.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabDigerBilgiler,
            this.tabOnPanel,
            this.tabKiymetliEvrak});
            this.tcAlacakGirisi.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.tcAlacakGirisi_SelectedPageChanging);
            // 
            // tabDigerBilgiler
            // 
            this.tabDigerBilgiler.Controls.Add(this.btnMasrafEkle);
            this.tabDigerBilgiler.Controls.Add(this.ucTebligatKayitUfakDock1);
            this.tabDigerBilgiler.Controls.Add(this.panelControl1);
            this.tabDigerBilgiler.Name = "tabDigerBilgiler";
            this.tabDigerBilgiler.Size = new System.Drawing.Size(502, 587);
            this.tabDigerBilgiler.Text = "Ýhtarname Bilgileri";
            // 
            // btnMasrafEkle
            // 
            this.btnMasrafEkle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMasrafEkle.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnMasrafEkle.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnMasrafEkle.Appearance.Options.UseBackColor = true;
            this.btnMasrafEkle.Appearance.Options.UseForeColor = true;
            this.btnMasrafEkle.Location = new System.Drawing.Point(363, 371);
            this.btnMasrafEkle.Name = "btnMasrafEkle";
            this.btnMasrafEkle.Size = new System.Drawing.Size(109, 22);
            this.btnMasrafEkle.TabIndex = 12;
            this.btnMasrafEkle.Text = "Ýhtar Masrafý Gir";
            this.btnMasrafEkle.Click += new System.EventHandler(this.btnMasrafEkle_Click);
            // 
            // ucTebligatKayitUfakDock1
            // 
            this.ucTebligatKayitUfakDock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTebligatKayitUfakDock1.Location = new System.Drawing.Point(0, 0);
            this.ucTebligatKayitUfakDock1.Name = "ucTebligatKayitUfakDock1";
            this.ucTebligatKayitUfakDock1.Size = new System.Drawing.Size(502, 397);
            this.ucTebligatKayitUfakDock1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.gcAlacak);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 397);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(502, 190);
            this.panelControl1.TabIndex = 11;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.BackColor = System.Drawing.Color.Red;
            this.simpleButton2.Appearance.BackColor2 = System.Drawing.Color.Red;
            this.simpleButton2.Appearance.BorderColor = System.Drawing.Color.Red;
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButton2.Appearance.Options.UseBackColor = true;
            this.simpleButton2.Appearance.Options.UseBorderColor = true;
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.simpleButton2.Location = new System.Drawing.Point(2, 166);
            this.simpleButton2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.simpleButton2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(498, 22);
            this.simpleButton2.TabIndex = 8;
            this.simpleButton2.Text = "Seçili Alacak Nedenlerine Ýhtarnameyi Baðla";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // gcAlacak
            // 
            this.gcAlacak.CustomButtonlarGorunmesin = false;
            this.gcAlacak.DataSource = this.aV001TIBILALACAKNEDENBindingSource;
            this.gcAlacak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAlacak.DoNotExtendEmbedNavigator = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcAlacak.FilterText = null;
            this.gcAlacak.FilterValue = null;
            this.gcAlacak.GridlerDuzenlenebilir = true;
            this.gcAlacak.GridsFilterControl = null;
            this.gcAlacak.Location = new System.Drawing.Point(2, 2);
            this.gcAlacak.MainView = this.gwAlacak;
            this.gcAlacak.MyGridStyle = null;
            this.gcAlacak.Name = "gcAlacak";
            this.gcAlacak.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueAlacakNedeni,
            this.rlueDovizID});
            this.gcAlacak.ShowRowNumbers = false;
            this.gcAlacak.SilmeKaldirilsin = false;
            this.gcAlacak.Size = new System.Drawing.Size(498, 186);
            this.gcAlacak.TabIndex = 7;
            this.gcAlacak.TemizleKaldirGorunsunmu = false;
            this.gcAlacak.UniqueId = "9a2af521-3975-4bb8-9e49-85d3bd83f3bd";
            this.gcAlacak.UseEmbeddedNavigator = true;
            this.gcAlacak.UseHyperDragDrop = false;
            this.gcAlacak.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwAlacak,
            this.gridView1,
            this.gridView2,
            this.gridView4,
            this.gridView6,
            this.gridView7,
            this.gridView11});
            // 
            // aV001TIBILALACAKNEDENBindingSource
            // 
            this.aV001TIBILALACAKNEDENBindingSource.DataSource = typeof(AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN);
            // 
            // gwAlacak
            // 
            this.gwAlacak.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.colALACAK_NEDEN_KOD_ID,
            this.colDIGER_ALACAK_NEDENI,
            this.colDUZENLENME_TARIHI,
            this.colVADE_TARIHI,
            this.colFAIZ_BASLANGIC_TARIHI,
            this.colHESAPLAMA_MODU,
            this.colTUTARI,
            this.colTUTAR_DOVIZ_ID,
            this.colISLEME_KONAN_TUTAR,
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID,
            this.colHARCA_ESAS_DEGER,
            this.colHARCA_ESAS_DEGER_DOVIZ_ID,
            this.colFAIZ_YOK,
            this.colALACAK_FAIZ_TIP_ID,
            this.colUYGULANACAK_FAIZ_ORANI,
            this.colTO_ALACAK_FAIZ_TIP_ID,
            this.colTO_UYGULANACAK_FAIZ_ORANI,
            this.colSABIT_FAIZ_UYGULA,
            this.colBIR_GUNE_AYLIK_FAIZ,
            this.colIHTAR_TARIHI,
            this.colIHTAR_GIDERI,
            this.colIHTAR_GIDERI_DOVIZ_ID,
            this.colPROTESTO_GIDERI,
            this.colPROTESTO_GIDERI_DOVIZ_ID,
            this.colHER_AY_TAZMINAT_EKLE,
            this.colTAZMINAT_TIP_ID,
            this.colTAZMINATI_ORANI,
            this.colCEK_TAZMINATI_ORANI,
            this.colKOMISYONU_ORANI,
            this.colBSMV_HESAPLANSIN,
            this.colKKDV_HESAPLANSIN,
            this.colOIV_HESAPLANSIN,
            this.colKDV_HESAPLANSIN,
            this.colKDV_TIP_ID,
            this.colDAMGA_PULU_HESAPLANSIN,
            this.colSURE_GUN,
            this.colSURE_AY,
            this.colSURE_YIL,
            this.colACIKLAMA,
            this.colREFERANS_NO2,
            this.colREFERANS_NO3});
            this.gwAlacak.GridControl = this.gcAlacak;
            this.gwAlacak.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TUTARI", this.colTUTARI, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "HARCA_ESAS_DEGER", this.colHARCA_ESAS_DEGER, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PROTESTO_GIDERI", this.colPROTESTO_GIDERI, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ISLEME_KONAN_TUTAR", this.colISLEME_KONAN_TUTAR, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PROTESTO_GIDERI", this.colPROTESTO_GIDERI, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, "")});
            this.gwAlacak.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gwAlacak.IndicatorWidth = 20;
            this.gwAlacak.Name = "gwAlacak";
            this.gwAlacak.NewItemRowText = "Yeni Kayýt Eklemek Ýçin Týklayýn..";
            this.gwAlacak.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwAlacak.OptionsNavigation.AutoFocusNewRow = true;
            this.gwAlacak.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwAlacak.OptionsView.RowAutoHeight = true;
            this.gwAlacak.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwAlacak.OptionsView.ShowDetailButtons = false;
            this.gwAlacak.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gwAlacak.OptionsView.ShowFooter = true;
            this.gwAlacak.OptionsView.ShowGroupPanel = false;
            this.gwAlacak.PaintStyleName = "Skin";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Seç";
            this.gridColumn8.FieldName = "IsSelected";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            this.gridColumn8.Width = 20;
            // 
            // colALACAK_NEDEN_KOD_ID
            // 
            this.colALACAK_NEDEN_KOD_ID.Caption = "Alacak Neden";
            this.colALACAK_NEDEN_KOD_ID.ColumnEdit = this.rlueAlacakNedeni;
            this.colALACAK_NEDEN_KOD_ID.FieldName = "ALACAK_NEDEN_KOD_ID";
            this.colALACAK_NEDEN_KOD_ID.Name = "colALACAK_NEDEN_KOD_ID";
            this.colALACAK_NEDEN_KOD_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colALACAK_NEDEN_KOD_ID.Visible = true;
            this.colALACAK_NEDEN_KOD_ID.VisibleIndex = 1;
            this.colALACAK_NEDEN_KOD_ID.Width = 32;
            // 
            // colDIGER_ALACAK_NEDENI
            // 
            this.colDIGER_ALACAK_NEDENI.Caption = "Diðer Alacak Nedeni";
            this.colDIGER_ALACAK_NEDENI.FieldName = "DIGER_ALACAK_NEDENI";
            this.colDIGER_ALACAK_NEDENI.Name = "colDIGER_ALACAK_NEDENI";
            this.colDIGER_ALACAK_NEDENI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDIGER_ALACAK_NEDENI.Width = 38;
            // 
            // colDUZENLENME_TARIHI
            // 
            this.colDUZENLENME_TARIHI.Caption = "Düz. T.";
            this.colDUZENLENME_TARIHI.FieldName = "DUZENLENME_TARIHI";
            this.colDUZENLENME_TARIHI.Name = "colDUZENLENME_TARIHI";
            this.colDUZENLENME_TARIHI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDUZENLENME_TARIHI.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colDUZENLENME_TARIHI.Visible = true;
            this.colDUZENLENME_TARIHI.VisibleIndex = 2;
            this.colDUZENLENME_TARIHI.Width = 21;
            // 
            // colVADE_TARIHI
            // 
            this.colVADE_TARIHI.Caption = "Vade T.";
            this.colVADE_TARIHI.FieldName = "VADE_TARIHI";
            this.colVADE_TARIHI.Name = "colVADE_TARIHI";
            this.colVADE_TARIHI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colVADE_TARIHI.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colVADE_TARIHI.Visible = true;
            this.colVADE_TARIHI.VisibleIndex = 3;
            this.colVADE_TARIHI.Width = 23;
            // 
            // colFAIZ_BASLANGIC_TARIHI
            // 
            this.colFAIZ_BASLANGIC_TARIHI.Caption = "Faiz. Baþ. T.";
            this.colFAIZ_BASLANGIC_TARIHI.FieldName = "FAIZ_BASLANGIC_TARIHI";
            this.colFAIZ_BASLANGIC_TARIHI.Name = "colFAIZ_BASLANGIC_TARIHI";
            this.colFAIZ_BASLANGIC_TARIHI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colFAIZ_BASLANGIC_TARIHI.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colFAIZ_BASLANGIC_TARIHI.Width = 24;
            // 
            // colHESAPLAMA_MODU
            // 
            this.colHESAPLAMA_MODU.Caption = "Hesap Modu";
            this.colHESAPLAMA_MODU.FieldName = "HESAPLAMA_MODU";
            this.colHESAPLAMA_MODU.Name = "colHESAPLAMA_MODU";
            this.colHESAPLAMA_MODU.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colHESAPLAMA_MODU.Width = 28;
            // 
            // colTUTARI
            // 
            this.colTUTARI.Caption = "Tutarý";
            this.colTUTARI.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colTUTARI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTUTARI.FieldName = "TUTARI";
            this.colTUTARI.Name = "colTUTARI";
            this.colTUTARI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTUTARI.Visible = true;
            this.colTUTARI.VisibleIndex = 4;
            this.colTUTARI.Width = 22;
            // 
            // colTUTAR_DOVIZ_ID
            // 
            this.colTUTAR_DOVIZ_ID.Caption = "  ";
            this.colTUTAR_DOVIZ_ID.ColumnEdit = this.rlueDovizID;
            this.colTUTAR_DOVIZ_ID.CustomizationCaption = "  ";
            this.colTUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
            this.colTUTAR_DOVIZ_ID.Name = "colTUTAR_DOVIZ_ID";
            this.colTUTAR_DOVIZ_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTUTAR_DOVIZ_ID.ToolTip = "TUTAR Birim";
            this.colTUTAR_DOVIZ_ID.Visible = true;
            this.colTUTAR_DOVIZ_ID.VisibleIndex = 5;
            this.colTUTAR_DOVIZ_ID.Width = 30;
            // 
            // colISLEME_KONAN_TUTAR
            // 
            this.colISLEME_KONAN_TUTAR.Caption = "Ýþleme Konan Tu.";
            this.colISLEME_KONAN_TUTAR.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colISLEME_KONAN_TUTAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colISLEME_KONAN_TUTAR.FieldName = "ISLEME_KONAN_TUTAR";
            this.colISLEME_KONAN_TUTAR.Name = "colISLEME_KONAN_TUTAR";
            this.colISLEME_KONAN_TUTAR.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colISLEME_KONAN_TUTAR.Visible = true;
            this.colISLEME_KONAN_TUTAR.VisibleIndex = 6;
            this.colISLEME_KONAN_TUTAR.Width = 28;
            // 
            // colISLEME_KONAN_TUTAR_DOVIZ_ID
            // 
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.Caption = " ";
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.ColumnEdit = this.rlueDovizID;
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.CustomizationCaption = " ";
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.FieldName = "ISLEME_KONAN_TUTAR_DOVIZ_ID";
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.Name = "colISLEME_KONAN_TUTAR_DOVIZ_ID";
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.ToolTip = "ISLEME KONAN TUTAR Birim";
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.Visible = true;
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.VisibleIndex = 7;
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.Width = 30;
            // 
            // colHARCA_ESAS_DEGER
            // 
            this.colHARCA_ESAS_DEGER.Caption = "Esas Deðer";
            this.colHARCA_ESAS_DEGER.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colHARCA_ESAS_DEGER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHARCA_ESAS_DEGER.FieldName = "HARCA_ESAS_DEGER";
            this.colHARCA_ESAS_DEGER.Name = "colHARCA_ESAS_DEGER";
            this.colHARCA_ESAS_DEGER.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colHARCA_ESAS_DEGER.Width = 22;
            // 
            // colHARCA_ESAS_DEGER_DOVIZ_ID
            // 
            this.colHARCA_ESAS_DEGER_DOVIZ_ID.CustomizationCaption = "HARCA_ESAS_DEGER_DOVIZ_ID";
            this.colHARCA_ESAS_DEGER_DOVIZ_ID.FieldName = "HARCA_ESAS_DEGER_DOVIZ_ID";
            this.colHARCA_ESAS_DEGER_DOVIZ_ID.Name = "colHARCA_ESAS_DEGER_DOVIZ_ID";
            this.colHARCA_ESAS_DEGER_DOVIZ_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colHARCA_ESAS_DEGER_DOVIZ_ID.ToolTip = "HARCA ESAS DEGER Birim";
            this.colHARCA_ESAS_DEGER_DOVIZ_ID.Width = 30;
            // 
            // colFAIZ_YOK
            // 
            this.colFAIZ_YOK.Caption = "Faiz Yok";
            this.colFAIZ_YOK.FieldName = "FAIZ_YOK";
            this.colFAIZ_YOK.Name = "colFAIZ_YOK";
            this.colFAIZ_YOK.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colFAIZ_YOK.Width = 20;
            // 
            // colALACAK_FAIZ_TIP_ID
            // 
            this.colALACAK_FAIZ_TIP_ID.Caption = "Faiz Tip";
            this.colALACAK_FAIZ_TIP_ID.FieldName = "ALACAK_FAIZ_TIP_ID";
            this.colALACAK_FAIZ_TIP_ID.Name = "colALACAK_FAIZ_TIP_ID";
            this.colALACAK_FAIZ_TIP_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colALACAK_FAIZ_TIP_ID.Width = 21;
            // 
            // colUYGULANACAK_FAIZ_ORANI
            // 
            this.colUYGULANACAK_FAIZ_ORANI.Caption = "Faiz Oraný";
            this.colUYGULANACAK_FAIZ_ORANI.FieldName = "UYGULANACAK_FAIZ_ORANI";
            this.colUYGULANACAK_FAIZ_ORANI.Name = "colUYGULANACAK_FAIZ_ORANI";
            this.colUYGULANACAK_FAIZ_ORANI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colUYGULANACAK_FAIZ_ORANI.Width = 21;
            // 
            // colTO_ALACAK_FAIZ_TIP_ID
            // 
            this.colTO_ALACAK_FAIZ_TIP_ID.Caption = "Alacak Faiz Tipi";
            this.colTO_ALACAK_FAIZ_TIP_ID.FieldName = "TO_ALACAK_FAIZ_TIP_ID";
            this.colTO_ALACAK_FAIZ_TIP_ID.Name = "colTO_ALACAK_FAIZ_TIP_ID";
            this.colTO_ALACAK_FAIZ_TIP_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTO_ALACAK_FAIZ_TIP_ID.Width = 23;
            // 
            // colTO_UYGULANACAK_FAIZ_ORANI
            // 
            this.colTO_UYGULANACAK_FAIZ_ORANI.Caption = "Uygulanacak Faiz Oraný";
            this.colTO_UYGULANACAK_FAIZ_ORANI.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colTO_UYGULANACAK_FAIZ_ORANI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTO_UYGULANACAK_FAIZ_ORANI.FieldName = "TO_UYGULANACAK_FAIZ_ORANI";
            this.colTO_UYGULANACAK_FAIZ_ORANI.Name = "colTO_UYGULANACAK_FAIZ_ORANI";
            this.colTO_UYGULANACAK_FAIZ_ORANI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTO_UYGULANACAK_FAIZ_ORANI.Width = 21;
            // 
            // colSABIT_FAIZ_UYGULA
            // 
            this.colSABIT_FAIZ_UYGULA.Caption = "S. F. Uygula";
            this.colSABIT_FAIZ_UYGULA.FieldName = "SABIT_FAIZ_UYGULA";
            this.colSABIT_FAIZ_UYGULA.Name = "colSABIT_FAIZ_UYGULA";
            this.colSABIT_FAIZ_UYGULA.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSABIT_FAIZ_UYGULA.Width = 21;
            // 
            // colBIR_GUNE_AYLIK_FAIZ
            // 
            this.colBIR_GUNE_AYLIK_FAIZ.Caption = "1 A.F";
            this.colBIR_GUNE_AYLIK_FAIZ.FieldName = "BIR_GUNE_AYLIK_FAIZ";
            this.colBIR_GUNE_AYLIK_FAIZ.Name = "colBIR_GUNE_AYLIK_FAIZ";
            this.colBIR_GUNE_AYLIK_FAIZ.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colBIR_GUNE_AYLIK_FAIZ.Width = 21;
            // 
            // colIHTAR_TARIHI
            // 
            this.colIHTAR_TARIHI.Caption = "Ýhtar T.";
            this.colIHTAR_TARIHI.FieldName = "IHTAR_TARIHI";
            this.colIHTAR_TARIHI.Name = "colIHTAR_TARIHI";
            this.colIHTAR_TARIHI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colIHTAR_TARIHI.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colIHTAR_TARIHI.Width = 21;
            // 
            // colIHTAR_GIDERI
            // 
            this.colIHTAR_GIDERI.Caption = "Ýhtar Gi.";
            this.colIHTAR_GIDERI.FieldName = "IHTAR_GIDERI";
            this.colIHTAR_GIDERI.Name = "colIHTAR_GIDERI";
            this.colIHTAR_GIDERI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colIHTAR_GIDERI.Width = 21;
            // 
            // colIHTAR_GIDERI_DOVIZ_ID
            // 
            this.colIHTAR_GIDERI_DOVIZ_ID.CustomizationCaption = "IHTAR_GIDERI_DOVIZ_ID";
            this.colIHTAR_GIDERI_DOVIZ_ID.FieldName = "IHTAR_GIDERI_DOVIZ_ID";
            this.colIHTAR_GIDERI_DOVIZ_ID.Name = "colIHTAR_GIDERI_DOVIZ_ID";
            this.colIHTAR_GIDERI_DOVIZ_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colIHTAR_GIDERI_DOVIZ_ID.ToolTip = "IHTAR GIDERI Birim";
            this.colIHTAR_GIDERI_DOVIZ_ID.Width = 30;
            // 
            // colPROTESTO_GIDERI
            // 
            this.colPROTESTO_GIDERI.Caption = "Pretesto Gideri";
            this.colPROTESTO_GIDERI.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colPROTESTO_GIDERI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPROTESTO_GIDERI.FieldName = "PROTESTO_GIDERI";
            this.colPROTESTO_GIDERI.Name = "colPROTESTO_GIDERI";
            this.colPROTESTO_GIDERI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPROTESTO_GIDERI.Width = 20;
            // 
            // colPROTESTO_GIDERI_DOVIZ_ID
            // 
            this.colPROTESTO_GIDERI_DOVIZ_ID.CustomizationCaption = "PROTESTO_GIDERI_DOVIZ_ID";
            this.colPROTESTO_GIDERI_DOVIZ_ID.FieldName = "PROTESTO_GIDERI_DOVIZ_ID";
            this.colPROTESTO_GIDERI_DOVIZ_ID.Name = "colPROTESTO_GIDERI_DOVIZ_ID";
            this.colPROTESTO_GIDERI_DOVIZ_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPROTESTO_GIDERI_DOVIZ_ID.ToolTip = "PROTESTO GIDERI Birim";
            this.colPROTESTO_GIDERI_DOVIZ_ID.Width = 30;
            // 
            // colHER_AY_TAZMINAT_EKLE
            // 
            this.colHER_AY_TAZMINAT_EKLE.Caption = "Taz. Ekle";
            this.colHER_AY_TAZMINAT_EKLE.FieldName = "HER_AY_TAZMINAT_EKLE";
            this.colHER_AY_TAZMINAT_EKLE.Name = "colHER_AY_TAZMINAT_EKLE";
            this.colHER_AY_TAZMINAT_EKLE.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colHER_AY_TAZMINAT_EKLE.Width = 20;
            // 
            // colTAZMINAT_TIP_ID
            // 
            this.colTAZMINAT_TIP_ID.Caption = "Tazminat Tip";
            this.colTAZMINAT_TIP_ID.FieldName = "TAZMINAT_TIP_ID";
            this.colTAZMINAT_TIP_ID.Name = "colTAZMINAT_TIP_ID";
            this.colTAZMINAT_TIP_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTAZMINAT_TIP_ID.Width = 20;
            // 
            // colTAZMINATI_ORANI
            // 
            this.colTAZMINATI_ORANI.Caption = "Tazminatýn Oraný";
            this.colTAZMINATI_ORANI.FieldName = "TAZMINATI_ORANI";
            this.colTAZMINATI_ORANI.Name = "colTAZMINATI_ORANI";
            this.colTAZMINATI_ORANI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTAZMINATI_ORANI.Width = 20;
            // 
            // colCEK_TAZMINATI_ORANI
            // 
            this.colCEK_TAZMINATI_ORANI.Caption = "Çek Taz. Oraný";
            this.colCEK_TAZMINATI_ORANI.FieldName = "CEK_TAZMINATI_ORANI";
            this.colCEK_TAZMINATI_ORANI.Name = "colCEK_TAZMINATI_ORANI";
            this.colCEK_TAZMINATI_ORANI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCEK_TAZMINATI_ORANI.Width = 20;
            // 
            // colKOMISYONU_ORANI
            // 
            this.colKOMISYONU_ORANI.Caption = "Kom.";
            this.colKOMISYONU_ORANI.FieldName = "KOMISYONU_ORANI";
            this.colKOMISYONU_ORANI.Name = "colKOMISYONU_ORANI";
            this.colKOMISYONU_ORANI.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colKOMISYONU_ORANI.Width = 20;
            // 
            // colBSMV_HESAPLANSIN
            // 
            this.colBSMV_HESAPLANSIN.Caption = "BSMV Hesaplansýn";
            this.colBSMV_HESAPLANSIN.FieldName = "BSMV_HESAPLANSIN";
            this.colBSMV_HESAPLANSIN.Name = "colBSMV_HESAPLANSIN";
            this.colBSMV_HESAPLANSIN.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colBSMV_HESAPLANSIN.Width = 20;
            // 
            // colKKDV_HESAPLANSIN
            // 
            this.colKKDV_HESAPLANSIN.Caption = "KKDV Hesaplansýn";
            this.colKKDV_HESAPLANSIN.FieldName = "KKDV_HESAPLANSIN";
            this.colKKDV_HESAPLANSIN.Name = "colKKDV_HESAPLANSIN";
            this.colKKDV_HESAPLANSIN.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colKKDV_HESAPLANSIN.Width = 20;
            // 
            // colOIV_HESAPLANSIN
            // 
            this.colOIV_HESAPLANSIN.Caption = "OIV Hesaplansýn";
            this.colOIV_HESAPLANSIN.FieldName = "OIV_HESAPLANSIN";
            this.colOIV_HESAPLANSIN.Name = "colOIV_HESAPLANSIN";
            this.colOIV_HESAPLANSIN.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colOIV_HESAPLANSIN.Width = 20;
            // 
            // colKDV_HESAPLANSIN
            // 
            this.colKDV_HESAPLANSIN.Caption = "KDV Hesaplansýn";
            this.colKDV_HESAPLANSIN.FieldName = "KDV_HESAPLANSIN";
            this.colKDV_HESAPLANSIN.Name = "colKDV_HESAPLANSIN";
            this.colKDV_HESAPLANSIN.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colKDV_HESAPLANSIN.Width = 20;
            // 
            // colKDV_TIP_ID
            // 
            this.colKDV_TIP_ID.Caption = "KDV Tipi";
            this.colKDV_TIP_ID.FieldName = "KDV_TIP_ID";
            this.colKDV_TIP_ID.Name = "colKDV_TIP_ID";
            this.colKDV_TIP_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colKDV_TIP_ID.Width = 20;
            // 
            // colDAMGA_PULU_HESAPLANSIN
            // 
            this.colDAMGA_PULU_HESAPLANSIN.Caption = "D. P. Hesaplansýn";
            this.colDAMGA_PULU_HESAPLANSIN.FieldName = "DAMGA_PULU_HESAPLANSIN";
            this.colDAMGA_PULU_HESAPLANSIN.Name = "colDAMGA_PULU_HESAPLANSIN";
            this.colDAMGA_PULU_HESAPLANSIN.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDAMGA_PULU_HESAPLANSIN.Width = 20;
            // 
            // colSURE_GUN
            // 
            this.colSURE_GUN.Caption = "Gün";
            this.colSURE_GUN.FieldName = "SURE_GUN";
            this.colSURE_GUN.Name = "colSURE_GUN";
            this.colSURE_GUN.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSURE_GUN.Width = 20;
            // 
            // colSURE_AY
            // 
            this.colSURE_AY.Caption = "Ay";
            this.colSURE_AY.FieldName = "SURE_AY";
            this.colSURE_AY.Name = "colSURE_AY";
            this.colSURE_AY.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSURE_AY.Width = 20;
            // 
            // colSURE_YIL
            // 
            this.colSURE_YIL.Caption = "Yýl";
            this.colSURE_YIL.FieldName = "SURE_YIL";
            this.colSURE_YIL.Name = "colSURE_YIL";
            this.colSURE_YIL.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSURE_YIL.Width = 20;
            // 
            // colACIKLAMA
            // 
            this.colACIKLAMA.Caption = "Açýklama";
            this.colACIKLAMA.FieldName = "ACIKLAMA";
            this.colACIKLAMA.Name = "colACIKLAMA";
            this.colACIKLAMA.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colACIKLAMA.Width = 20;
            // 
            // colREFERANS_NO2
            // 
            this.colREFERANS_NO2.Caption = "Ref. No 2";
            this.colREFERANS_NO2.FieldName = "REFERANS_NO2";
            this.colREFERANS_NO2.Name = "colREFERANS_NO2";
            this.colREFERANS_NO2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colREFERANS_NO2.Width = 20;
            // 
            // colREFERANS_NO3
            // 
            this.colREFERANS_NO3.Caption = "Ref. No 3";
            this.colREFERANS_NO3.FieldName = "REFERANS_NO3";
            this.colREFERANS_NO3.Name = "colREFERANS_NO3";
            this.colREFERANS_NO3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colREFERANS_NO3.Width = 52;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GEMI_UCAK_ARAC_TIP,
            this.ADI,
            this.CINSI,
            this.TESCIL_NUMARASI,
            this.TANIMA_ISARETI,
            this.INSA_YILI,
            this.INSA_YERI,
            this.BOYU,
            this.ENI,
            this.TONALITOSU,
            this.BAGLAMA_LIMANI,
            this.TEKNIK_KUTUK_NO,
            this.ERISIM_NO,
            this.TIPI,
            this.DERINLIGI,
            this.KUTUK_BOYU,
            this.ARAC_PLAKA,
            this.ARAC_MODEL,
            this.ARAC_TIP,
            this.ARAC_MOTOR_NO,
            this.ARAC_SASI_NO,
            this.ARAC_RENK,
            this.TRAFIK_SUBESI,
            this.RUHSAT_TARIHI,
            this.RUHSAT_SICIL_NO});
            this.gridView1.GridControl = this.gcAlacak;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView1.ViewCaption = "Gemi-Uçak-Araç";
            // 
            // GEMI_UCAK_ARAC_TIP
            // 
            this.GEMI_UCAK_ARAC_TIP.Caption = "Tip";
            this.GEMI_UCAK_ARAC_TIP.FieldName = "GEMI_UCAK_ARAC_TIP";
            this.GEMI_UCAK_ARAC_TIP.Name = "GEMI_UCAK_ARAC_TIP";
            this.GEMI_UCAK_ARAC_TIP.Visible = true;
            this.GEMI_UCAK_ARAC_TIP.VisibleIndex = 1;
            // 
            // ADI
            // 
            this.ADI.Caption = "Adý";
            this.ADI.FieldName = "ADI";
            this.ADI.Name = "ADI";
            this.ADI.Visible = true;
            this.ADI.VisibleIndex = 2;
            // 
            // CINSI
            // 
            this.CINSI.Caption = "Cinsi";
            this.CINSI.FieldName = "CINSI";
            this.CINSI.Name = "CINSI";
            this.CINSI.Visible = true;
            this.CINSI.VisibleIndex = 3;
            // 
            // TESCIL_NUMARASI
            // 
            this.TESCIL_NUMARASI.Caption = "Tescil Numarasý";
            this.TESCIL_NUMARASI.FieldName = "TESCIL_NUMARASI";
            this.TESCIL_NUMARASI.Name = "TESCIL_NUMARASI";
            this.TESCIL_NUMARASI.Visible = true;
            this.TESCIL_NUMARASI.VisibleIndex = 4;
            // 
            // TANIMA_ISARETI
            // 
            this.TANIMA_ISARETI.Caption = "Tanýma Ýþareti";
            this.TANIMA_ISARETI.FieldName = "TANIMA_ISARETI";
            this.TANIMA_ISARETI.Name = "TANIMA_ISARETI";
            this.TANIMA_ISARETI.Visible = true;
            this.TANIMA_ISARETI.VisibleIndex = 5;
            // 
            // INSA_YILI
            // 
            this.INSA_YILI.Caption = "Ýnþa Yýlý";
            this.INSA_YILI.FieldName = "INSA_YILI";
            this.INSA_YILI.Name = "INSA_YILI";
            this.INSA_YILI.Visible = true;
            this.INSA_YILI.VisibleIndex = 6;
            // 
            // INSA_YERI
            // 
            this.INSA_YERI.Caption = "Ýnþa Yeri";
            this.INSA_YERI.FieldName = "INSA_YERI";
            this.INSA_YERI.Name = "INSA_YERI";
            this.INSA_YERI.Visible = true;
            this.INSA_YERI.VisibleIndex = 7;
            // 
            // BOYU
            // 
            this.BOYU.Caption = "Boyu";
            this.BOYU.FieldName = "BOYU";
            this.BOYU.Name = "BOYU";
            this.BOYU.Visible = true;
            this.BOYU.VisibleIndex = 8;
            // 
            // ENI
            // 
            this.ENI.Caption = "Eni";
            this.ENI.FieldName = "ENI";
            this.ENI.Name = "ENI";
            this.ENI.Visible = true;
            this.ENI.VisibleIndex = 9;
            // 
            // TONALITOSU
            // 
            this.TONALITOSU.Caption = "Tonalitosu";
            this.TONALITOSU.FieldName = "TONALITOSU";
            this.TONALITOSU.Name = "TONALITOSU";
            this.TONALITOSU.Visible = true;
            this.TONALITOSU.VisibleIndex = 10;
            // 
            // BAGLAMA_LIMANI
            // 
            this.BAGLAMA_LIMANI.Caption = "Baðlama Limaný";
            this.BAGLAMA_LIMANI.FieldName = "BAGLAMA_LIMANI";
            this.BAGLAMA_LIMANI.Name = "BAGLAMA_LIMANI";
            this.BAGLAMA_LIMANI.Visible = true;
            this.BAGLAMA_LIMANI.VisibleIndex = 11;
            // 
            // TEKNIK_KUTUK_NO
            // 
            this.TEKNIK_KUTUK_NO.Caption = "Kütük No";
            this.TEKNIK_KUTUK_NO.FieldName = "TEKNIK_KUTUK_NO";
            this.TEKNIK_KUTUK_NO.Name = "TEKNIK_KUTUK_NO";
            this.TEKNIK_KUTUK_NO.Visible = true;
            this.TEKNIK_KUTUK_NO.VisibleIndex = 12;
            // 
            // ERISIM_NO
            // 
            this.ERISIM_NO.Caption = "Eriþim No";
            this.ERISIM_NO.FieldName = "ERISIM_NO";
            this.ERISIM_NO.Name = "ERISIM_NO";
            this.ERISIM_NO.Visible = true;
            this.ERISIM_NO.VisibleIndex = 13;
            // 
            // TIPI
            // 
            this.TIPI.Caption = "Tipi";
            this.TIPI.FieldName = "TIPI";
            this.TIPI.Name = "TIPI";
            this.TIPI.Visible = true;
            this.TIPI.VisibleIndex = 14;
            // 
            // DERINLIGI
            // 
            this.DERINLIGI.Caption = "Derinliði";
            this.DERINLIGI.FieldName = "DERINLIGI";
            this.DERINLIGI.Name = "DERINLIGI";
            this.DERINLIGI.Visible = true;
            this.DERINLIGI.VisibleIndex = 15;
            // 
            // KUTUK_BOYU
            // 
            this.KUTUK_BOYU.Caption = "Kütük Boyu";
            this.KUTUK_BOYU.FieldName = "KUTUK_BOYU";
            this.KUTUK_BOYU.Name = "KUTUK_BOYU";
            this.KUTUK_BOYU.Visible = true;
            this.KUTUK_BOYU.VisibleIndex = 16;
            // 
            // ARAC_PLAKA
            // 
            this.ARAC_PLAKA.Caption = "Plaka";
            this.ARAC_PLAKA.FieldName = "ARAC_PLAKA";
            this.ARAC_PLAKA.Name = "ARAC_PLAKA";
            this.ARAC_PLAKA.Visible = true;
            this.ARAC_PLAKA.VisibleIndex = 17;
            // 
            // ARAC_MODEL
            // 
            this.ARAC_MODEL.Caption = "Araç Model";
            this.ARAC_MODEL.FieldName = "ARAC_MODEL";
            this.ARAC_MODEL.Name = "ARAC_MODEL";
            this.ARAC_MODEL.Visible = true;
            this.ARAC_MODEL.VisibleIndex = 18;
            // 
            // ARAC_TIP
            // 
            this.ARAC_TIP.Caption = "Araç Tip";
            this.ARAC_TIP.FieldName = "ARAC_TIP";
            this.ARAC_TIP.Name = "ARAC_TIP";
            this.ARAC_TIP.Visible = true;
            this.ARAC_TIP.VisibleIndex = 19;
            // 
            // ARAC_MOTOR_NO
            // 
            this.ARAC_MOTOR_NO.Caption = "Araç Motor No";
            this.ARAC_MOTOR_NO.FieldName = "ARAC_MOTOR_NO";
            this.ARAC_MOTOR_NO.Name = "ARAC_MOTOR_NO";
            this.ARAC_MOTOR_NO.Visible = true;
            this.ARAC_MOTOR_NO.VisibleIndex = 20;
            // 
            // ARAC_SASI_NO
            // 
            this.ARAC_SASI_NO.Caption = "Þasi No";
            this.ARAC_SASI_NO.FieldName = "ARAC_SASI_NO";
            this.ARAC_SASI_NO.Name = "ARAC_SASI_NO";
            this.ARAC_SASI_NO.Visible = true;
            this.ARAC_SASI_NO.VisibleIndex = 21;
            // 
            // ARAC_RENK
            // 
            this.ARAC_RENK.Caption = "Araç Renk";
            this.ARAC_RENK.FieldName = "ARAC_RENK";
            this.ARAC_RENK.Name = "ARAC_RENK";
            this.ARAC_RENK.Visible = true;
            this.ARAC_RENK.VisibleIndex = 22;
            // 
            // TRAFIK_SUBESI
            // 
            this.TRAFIK_SUBESI.Caption = "Trafik Þubesi";
            this.TRAFIK_SUBESI.FieldName = "TRAFIK_SUBESI";
            this.TRAFIK_SUBESI.Name = "TRAFIK_SUBESI";
            this.TRAFIK_SUBESI.Visible = true;
            this.TRAFIK_SUBESI.VisibleIndex = 23;
            // 
            // RUHSAT_TARIHI
            // 
            this.RUHSAT_TARIHI.Caption = "Ruhsat T.";
            this.RUHSAT_TARIHI.FieldName = "RUHSAT_TARIHI";
            this.RUHSAT_TARIHI.Name = "RUHSAT_TARIHI";
            this.RUHSAT_TARIHI.Visible = true;
            this.RUHSAT_TARIHI.VisibleIndex = 24;
            // 
            // RUHSAT_SICIL_NO
            // 
            this.RUHSAT_SICIL_NO.Caption = "Sicil No";
            this.RUHSAT_SICIL_NO.FieldName = "RUHSAT_SICIL_NO";
            this.RUHSAT_SICIL_NO.Name = "RUHSAT_SICIL_NO";
            this.RUHSAT_SICIL_NO.Visible = true;
            this.RUHSAT_SICIL_NO.VisibleIndex = 0;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gcAlacak;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colICRA_ALACAK_NEDEN_ID,
            this.colTARAF_CARI_ID1,
            this.colFAIZ_BASLANGIC_TARIHI1,
            this.colFAIZ_BITIS_TARIHI,
            this.colSABIT_FAIZ,
            this.colBIR_GUNE_AYLIK_FAIZ1,
            this.colFAIZ_TIP_ID});
            this.gridView4.GridControl = this.gcAlacak;
            this.gridView4.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SABIT_FAIZ", this.colSABIT_FAIZ, "")});
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView4.ViewCaption = "Faiz";
            // 
            // colICRA_ALACAK_NEDEN_ID
            // 
            this.colICRA_ALACAK_NEDEN_ID.Caption = "Alacak Neden";
            this.colICRA_ALACAK_NEDEN_ID.FieldName = "ICRA_ALACAK_NEDEN_ID";
            this.colICRA_ALACAK_NEDEN_ID.Name = "colICRA_ALACAK_NEDEN_ID";
            // 
            // colTARAF_CARI_ID1
            // 
            this.colTARAF_CARI_ID1.Caption = "Þahýs";
            this.colTARAF_CARI_ID1.FieldName = "TARAF_CARI_ID";
            this.colTARAF_CARI_ID1.Name = "colTARAF_CARI_ID1";
            // 
            // colFAIZ_BASLANGIC_TARIHI1
            // 
            this.colFAIZ_BASLANGIC_TARIHI1.Caption = "Baþlangýç T.";
            this.colFAIZ_BASLANGIC_TARIHI1.FieldName = "FAIZ_BASLANGIC_TARIHI";
            this.colFAIZ_BASLANGIC_TARIHI1.Name = "colFAIZ_BASLANGIC_TARIHI1";
            this.colFAIZ_BASLANGIC_TARIHI1.Visible = true;
            this.colFAIZ_BASLANGIC_TARIHI1.VisibleIndex = 0;
            // 
            // colFAIZ_BITIS_TARIHI
            // 
            this.colFAIZ_BITIS_TARIHI.Caption = "Bitiþ T.";
            this.colFAIZ_BITIS_TARIHI.FieldName = "FAIZ_BITIS_TARIHI";
            this.colFAIZ_BITIS_TARIHI.Name = "colFAIZ_BITIS_TARIHI";
            this.colFAIZ_BITIS_TARIHI.Visible = true;
            this.colFAIZ_BITIS_TARIHI.VisibleIndex = 1;
            // 
            // colSABIT_FAIZ
            // 
            this.colSABIT_FAIZ.Caption = "Sabit Faiz";
            this.colSABIT_FAIZ.FieldName = "SABIT_FAIZ";
            this.colSABIT_FAIZ.Name = "colSABIT_FAIZ";
            this.colSABIT_FAIZ.Visible = true;
            this.colSABIT_FAIZ.VisibleIndex = 2;
            // 
            // colBIR_GUNE_AYLIK_FAIZ1
            // 
            this.colBIR_GUNE_AYLIK_FAIZ1.Caption = "1 Güne Aylik Faiz";
            this.colBIR_GUNE_AYLIK_FAIZ1.FieldName = "BIR_GUNE_AYLIK_FAIZ";
            this.colBIR_GUNE_AYLIK_FAIZ1.Name = "colBIR_GUNE_AYLIK_FAIZ1";
            this.colBIR_GUNE_AYLIK_FAIZ1.Visible = true;
            this.colBIR_GUNE_AYLIK_FAIZ1.VisibleIndex = 3;
            // 
            // colFAIZ_TIP_ID
            // 
            this.colFAIZ_TIP_ID.Caption = "Faiz Tip";
            this.colFAIZ_TIP_ID.FieldName = "FAIZ_TIP_ID";
            this.colFAIZ_TIP_ID.Name = "colFAIZ_TIP_ID";
            this.colFAIZ_TIP_ID.Visible = true;
            this.colFAIZ_TIP_ID.VisibleIndex = 4;
            // 
            // gridView6
            // 
            this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.EVRAK_TUR_ID,
            this.EVRAK_KAYIT_TARIHI,
            this.EVRAK_VADE_TARIHI,
            this.EVRAK_TANZIM_TARIHI,
            this.TUTAR_DOVIZ_ID,
            this.TUTAR,
            this.NE_SEKILDE_AHZOLUNDUGU,
            this.BANKA_ID,
            this.SUBE_ID,
            this.BANKA_SUBE_KODU,
            this.HESAP_NO,
            this.CEK_NO,
            this.SORULDUGU_TARIH,
            this.SORULMA_SONUCU,
            this.KARSILIK_TUTAR_DOVIZ_ID,
            this.KARSILIK_TUTAR,
            this.SORAN_ID,
            this.ARKASI_YAZILDI_MI,
            this.SERH_ACIKLAMASI,
            this.ILK_ALACAKLI_ID,
            this.ILK_BORCLU_ID,
            this.SIKAYET_EDILDI_MI,
            this.KESIDE_YERI,
            this.ODEME_YERI,
            this.ISLEMLER_BASLADIMI});
            this.gridView6.GridControl = this.gcAlacak;
            this.gridView6.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TUTAR", this.TUTAR, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KARSILIK_TUTAR", this.KARSILIK_TUTAR, "")});
            this.gridView6.Name = "gridView6";
            this.gridView6.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView6.OptionsView.ShowPreview = true;
            this.gridView6.PreviewFieldName = "SERH_ACIKLAMASI";
            this.gridView6.ViewCaption = "Kýymetli Evrak";
            // 
            // EVRAK_TUR_ID
            // 
            this.EVRAK_TUR_ID.Caption = "Evrak Tür";
            this.EVRAK_TUR_ID.FieldName = "EVRAK_TUR_ID";
            this.EVRAK_TUR_ID.Name = "EVRAK_TUR_ID";
            this.EVRAK_TUR_ID.Visible = true;
            this.EVRAK_TUR_ID.VisibleIndex = 0;
            // 
            // EVRAK_KAYIT_TARIHI
            // 
            this.EVRAK_KAYIT_TARIHI.Caption = "Evrak Kayýt T.";
            this.EVRAK_KAYIT_TARIHI.FieldName = "EVRAK_KAYIT_TARIHI";
            this.EVRAK_KAYIT_TARIHI.Name = "EVRAK_KAYIT_TARIHI";
            this.EVRAK_KAYIT_TARIHI.Visible = true;
            this.EVRAK_KAYIT_TARIHI.VisibleIndex = 1;
            // 
            // EVRAK_VADE_TARIHI
            // 
            this.EVRAK_VADE_TARIHI.Caption = "Vade T.";
            this.EVRAK_VADE_TARIHI.FieldName = "EVRAK_VADE_TARIHI";
            this.EVRAK_VADE_TARIHI.Name = "EVRAK_VADE_TARIHI";
            this.EVRAK_VADE_TARIHI.Visible = true;
            this.EVRAK_VADE_TARIHI.VisibleIndex = 2;
            // 
            // EVRAK_TANZIM_TARIHI
            // 
            this.EVRAK_TANZIM_TARIHI.Caption = "Tanzim T.";
            this.EVRAK_TANZIM_TARIHI.FieldName = "EVRAK_TANZIM_TARIHI";
            this.EVRAK_TANZIM_TARIHI.Name = "EVRAK_TANZIM_TARIHI";
            this.EVRAK_TANZIM_TARIHI.Visible = true;
            this.EVRAK_TANZIM_TARIHI.VisibleIndex = 3;
            // 
            // TUTAR_DOVIZ_ID
            // 
            this.TUTAR_DOVIZ_ID.Caption = "BRM";
            this.TUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
            this.TUTAR_DOVIZ_ID.Name = "TUTAR_DOVIZ_ID";
            this.TUTAR_DOVIZ_ID.Visible = true;
            this.TUTAR_DOVIZ_ID.VisibleIndex = 4;
            // 
            // TUTAR
            // 
            this.TUTAR.Caption = "Tutar";
            this.TUTAR.FieldName = "TUTAR";
            this.TUTAR.Name = "TUTAR";
            this.TUTAR.Visible = true;
            this.TUTAR.VisibleIndex = 5;
            // 
            // NE_SEKILDE_AHZOLUNDUGU
            // 
            this.NE_SEKILDE_AHZOLUNDUGU.Caption = "Ne Þekilde Ahzoldu";
            this.NE_SEKILDE_AHZOLUNDUGU.FieldName = "NE_SEKILDE_AHZOLUNDUGU";
            this.NE_SEKILDE_AHZOLUNDUGU.Name = "NE_SEKILDE_AHZOLUNDUGU";
            this.NE_SEKILDE_AHZOLUNDUGU.Visible = true;
            this.NE_SEKILDE_AHZOLUNDUGU.VisibleIndex = 6;
            // 
            // BANKA_ID
            // 
            this.BANKA_ID.Caption = "Banka";
            this.BANKA_ID.FieldName = "BANKA_ID";
            this.BANKA_ID.Name = "BANKA_ID";
            this.BANKA_ID.Visible = true;
            this.BANKA_ID.VisibleIndex = 7;
            // 
            // SUBE_ID
            // 
            this.SUBE_ID.Caption = "Þube";
            this.SUBE_ID.FieldName = "SUBE_ID";
            this.SUBE_ID.Name = "SUBE_ID";
            this.SUBE_ID.Visible = true;
            this.SUBE_ID.VisibleIndex = 8;
            // 
            // BANKA_SUBE_KODU
            // 
            this.BANKA_SUBE_KODU.Caption = "Banka Þube Kodu";
            this.BANKA_SUBE_KODU.FieldName = "BANKA_SUBE_KODU";
            this.BANKA_SUBE_KODU.Name = "BANKA_SUBE_KODU";
            this.BANKA_SUBE_KODU.Visible = true;
            this.BANKA_SUBE_KODU.VisibleIndex = 9;
            // 
            // HESAP_NO
            // 
            this.HESAP_NO.Caption = "Hesap No";
            this.HESAP_NO.FieldName = "HESAP_NO";
            this.HESAP_NO.Name = "HESAP_NO";
            this.HESAP_NO.Visible = true;
            this.HESAP_NO.VisibleIndex = 10;
            // 
            // CEK_NO
            // 
            this.CEK_NO.Caption = "Çek No";
            this.CEK_NO.FieldName = "CEK_NO";
            this.CEK_NO.Name = "CEK_NO";
            this.CEK_NO.Visible = true;
            this.CEK_NO.VisibleIndex = 11;
            // 
            // SORULDUGU_TARIH
            // 
            this.SORULDUGU_TARIH.Caption = "Sorulduðu T.";
            this.SORULDUGU_TARIH.FieldName = "SORULDUGU_TARIH";
            this.SORULDUGU_TARIH.Name = "SORULDUGU_TARIH";
            this.SORULDUGU_TARIH.Visible = true;
            this.SORULDUGU_TARIH.VisibleIndex = 12;
            // 
            // SORULMA_SONUCU
            // 
            this.SORULMA_SONUCU.Caption = "Sorulma Sonucu";
            this.SORULMA_SONUCU.FieldName = "SORULMA_SONUCU";
            this.SORULMA_SONUCU.Name = "SORULMA_SONUCU";
            this.SORULMA_SONUCU.Visible = true;
            this.SORULMA_SONUCU.VisibleIndex = 13;
            // 
            // KARSILIK_TUTAR_DOVIZ_ID
            // 
            this.KARSILIK_TUTAR_DOVIZ_ID.Caption = "BRM";
            this.KARSILIK_TUTAR_DOVIZ_ID.FieldName = "KARSILIK_TUTAR_DOVIZ_ID";
            this.KARSILIK_TUTAR_DOVIZ_ID.Name = "KARSILIK_TUTAR_DOVIZ_ID";
            this.KARSILIK_TUTAR_DOVIZ_ID.Visible = true;
            this.KARSILIK_TUTAR_DOVIZ_ID.VisibleIndex = 14;
            // 
            // KARSILIK_TUTAR
            // 
            this.KARSILIK_TUTAR.Caption = "Karþýlýk Tutar";
            this.KARSILIK_TUTAR.FieldName = "KARSILIK_TUTAR";
            this.KARSILIK_TUTAR.Name = "KARSILIK_TUTAR";
            this.KARSILIK_TUTAR.Visible = true;
            this.KARSILIK_TUTAR.VisibleIndex = 15;
            // 
            // SORAN_ID
            // 
            this.SORAN_ID.Caption = "Soran";
            this.SORAN_ID.FieldName = "SORAN_ID";
            this.SORAN_ID.Name = "SORAN_ID";
            this.SORAN_ID.Visible = true;
            this.SORAN_ID.VisibleIndex = 16;
            // 
            // ARKASI_YAZILDI_MI
            // 
            this.ARKASI_YAZILDI_MI.Caption = "Arkasý Yazýldýmý";
            this.ARKASI_YAZILDI_MI.FieldName = "ARKASI_YAZILDI_MI";
            this.ARKASI_YAZILDI_MI.Name = "ARKASI_YAZILDI_MI";
            this.ARKASI_YAZILDI_MI.Visible = true;
            this.ARKASI_YAZILDI_MI.VisibleIndex = 17;
            // 
            // SERH_ACIKLAMASI
            // 
            this.SERH_ACIKLAMASI.Caption = "Þerh Açýklama";
            this.SERH_ACIKLAMASI.FieldName = "SERH_ACIKLAMASI";
            this.SERH_ACIKLAMASI.Name = "SERH_ACIKLAMASI";
            this.SERH_ACIKLAMASI.Visible = true;
            this.SERH_ACIKLAMASI.VisibleIndex = 18;
            // 
            // ILK_ALACAKLI_ID
            // 
            this.ILK_ALACAKLI_ID.Caption = "Ýlk Alacaklý";
            this.ILK_ALACAKLI_ID.FieldName = "ILK_ALACAKLI_ID";
            this.ILK_ALACAKLI_ID.Name = "ILK_ALACAKLI_ID";
            this.ILK_ALACAKLI_ID.Visible = true;
            this.ILK_ALACAKLI_ID.VisibleIndex = 19;
            // 
            // ILK_BORCLU_ID
            // 
            this.ILK_BORCLU_ID.Caption = "Ýlk Borçlu";
            this.ILK_BORCLU_ID.FieldName = "ILK_BORCLU_ID";
            this.ILK_BORCLU_ID.Name = "ILK_BORCLU_ID";
            this.ILK_BORCLU_ID.Visible = true;
            this.ILK_BORCLU_ID.VisibleIndex = 20;
            // 
            // SIKAYET_EDILDI_MI
            // 
            this.SIKAYET_EDILDI_MI.Caption = "Þikayet Edildi mi";
            this.SIKAYET_EDILDI_MI.FieldName = "SIKAYET_EDILDI_MI";
            this.SIKAYET_EDILDI_MI.Name = "SIKAYET_EDILDI_MI";
            this.SIKAYET_EDILDI_MI.Visible = true;
            this.SIKAYET_EDILDI_MI.VisibleIndex = 21;
            // 
            // KESIDE_YERI
            // 
            this.KESIDE_YERI.Caption = "Keside Yeri";
            this.KESIDE_YERI.FieldName = "KESIDE_YERI";
            this.KESIDE_YERI.Name = "KESIDE_YERI";
            this.KESIDE_YERI.Visible = true;
            this.KESIDE_YERI.VisibleIndex = 22;
            // 
            // ODEME_YERI
            // 
            this.ODEME_YERI.Caption = "Ödeme Yeri";
            this.ODEME_YERI.FieldName = "ODEME_YERI";
            this.ODEME_YERI.Name = "ODEME_YERI";
            this.ODEME_YERI.Visible = true;
            this.ODEME_YERI.VisibleIndex = 23;
            // 
            // ISLEMLER_BASLADIMI
            // 
            this.ISLEMLER_BASLADIMI.Caption = "Ýþlemler Baþladýmý";
            this.ISLEMLER_BASLADIMI.FieldName = "ISLEMLER_BASLADIMI";
            this.ISLEMLER_BASLADIMI.Name = "ISLEMLER_BASLADIMI";
            this.ISLEMLER_BASLADIMI.Visible = true;
            this.ISLEMLER_BASLADIMI.VisibleIndex = 24;
            // 
            // gridView7
            // 
            this.gridView7.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TUR,
            this.SOZLESME_NO,
            this.SOZLESME_ADI,
            this.TIP_ID,
            this.ALT_TIP_ID,
            this.TASNIF_NO,
            this.OZEL_KOD1_ID,
            this.OZEL_KOD2_ID,
            this.OZEL_KOD3_ID,
            this.OZEL_KOD4_ID,
            this.TASLAK_TARIHI,
            this.IMZA_TARIHI,
            this.BASLANGIC_TARIHI,
            this.YENILENME_TARIHI,
            this.SON_ISLEM_TARIHI,
            this.BITIS_TARIHI,
            this.BITIRILME_TARIHI,
            this.SURE_GUN,
            this.SURE_AY,
            this.SURE_YIL,
            this.NOTER_TARIHI,
            this.NOTER_YEVMIYE_NO,
            this.ADLI_BIRIM_ADLIYE_ID,
            this.ADLI_BIRIM_GOREV_ID,
            this.ADLI_BIRIM_NO_ID,
            this.YEDI_EMIN_CARI_ID,
            this.BEDELI_DOVIZ_ID,
            this.BEDELI,
            this.TAHLIYE_TAAHHUT_TARIHI,
            this.TAHLIYE_ADRESI,
            this.KART_TIP_ID,
            this.KREDI_KART_NO,
            this.CVV1,
            this.CVV2,
            this.SON_KULLANIM_TARIHI,
            this.REHIN_CINS_ID,
            this.BORC_IKRARINI_HAVI_MI,
            this.HARC_ISTISNA_ID,
            this.HARC_ISTISNA_BELGE_TARIH,
            this.HARC_ISTISNA_BELGE_NO,
            this.REHIN_DERECE,
            this.REHIN_SIRA,
            this.SICIL_TIP_ID,
            this.SICIL_BOLGE_NO,
            this.SICIL_ILCE_ID,
            this.SICIL_IL_ID,
            this.SICIL_TARIHI,
            this.SICIL_YEVMIYE_NO,
            this.SICIL_TESCIL_NO,
            this.FEK_TARIHI3,
            this.REHIN_DURUM_ID,
            this.SOZLESME_DURUM_ID,
            this.DURUM_ACIKLAMA,
            this.ACIKLAMA,
            this.REHIN_CINS_ANA_TURU,
            this.ISLEMLER_BASLADIMI1,
            this.UCRETIN_ODENME_SEKLI_ID,
            this.HAKEM_YARGILAMASININ_YERI_ID,
            this.SURE_UYGULAMA_TIPI});
            this.gridView7.GridControl = this.gcAlacak;
            this.gridView7.Name = "gridView7";
            this.gridView7.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView7.OptionsView.ShowPreview = true;
            this.gridView7.PreviewFieldName = "ACIKLAMA";
            this.gridView7.ViewCaption = "Sözleþme";
            // 
            // TUR
            // 
            this.TUR.Caption = "Tür";
            this.TUR.FieldName = "TUR";
            this.TUR.Name = "TUR";
            this.TUR.Visible = true;
            this.TUR.VisibleIndex = 0;
            // 
            // SOZLESME_NO
            // 
            this.SOZLESME_NO.Caption = "Sözleþme No";
            this.SOZLESME_NO.FieldName = "SOZLESME_NO";
            this.SOZLESME_NO.Name = "SOZLESME_NO";
            this.SOZLESME_NO.Visible = true;
            this.SOZLESME_NO.VisibleIndex = 1;
            // 
            // SOZLESME_ADI
            // 
            this.SOZLESME_ADI.Caption = "Sözleþme Adý";
            this.SOZLESME_ADI.FieldName = "SOZLESME_ADI";
            this.SOZLESME_ADI.Name = "SOZLESME_ADI";
            this.SOZLESME_ADI.Visible = true;
            this.SOZLESME_ADI.VisibleIndex = 2;
            // 
            // TIP_ID
            // 
            this.TIP_ID.Caption = "Tip";
            this.TIP_ID.FieldName = "TIP_ID";
            this.TIP_ID.Name = "TIP_ID";
            this.TIP_ID.Visible = true;
            this.TIP_ID.VisibleIndex = 3;
            // 
            // ALT_TIP_ID
            // 
            this.ALT_TIP_ID.Caption = "Alt Tip";
            this.ALT_TIP_ID.FieldName = "ALT_TIP_ID";
            this.ALT_TIP_ID.Name = "ALT_TIP_ID";
            this.ALT_TIP_ID.Visible = true;
            this.ALT_TIP_ID.VisibleIndex = 4;
            // 
            // TASNIF_NO
            // 
            this.TASNIF_NO.Caption = "Tasnif No";
            this.TASNIF_NO.FieldName = "TASNIF_NO";
            this.TASNIF_NO.Name = "TASNIF_NO";
            this.TASNIF_NO.Visible = true;
            this.TASNIF_NO.VisibleIndex = 5;
            // 
            // OZEL_KOD1_ID
            // 
            this.OZEL_KOD1_ID.Caption = "Özel Kod 1";
            this.OZEL_KOD1_ID.FieldName = "OZEL_KOD1_ID";
            this.OZEL_KOD1_ID.Name = "OZEL_KOD1_ID";
            this.OZEL_KOD1_ID.Visible = true;
            this.OZEL_KOD1_ID.VisibleIndex = 6;
            // 
            // OZEL_KOD2_ID
            // 
            this.OZEL_KOD2_ID.Name = "OZEL_KOD2_ID";
            // 
            // OZEL_KOD3_ID
            // 
            this.OZEL_KOD3_ID.Caption = "Özel Kod 3";
            this.OZEL_KOD3_ID.FieldName = "OZEL_KOD3_ID";
            this.OZEL_KOD3_ID.Name = "OZEL_KOD3_ID";
            this.OZEL_KOD3_ID.Visible = true;
            this.OZEL_KOD3_ID.VisibleIndex = 7;
            // 
            // OZEL_KOD4_ID
            // 
            this.OZEL_KOD4_ID.Caption = "Özel Kod 4";
            this.OZEL_KOD4_ID.FieldName = "OZEL_KOD4_ID";
            this.OZEL_KOD4_ID.Name = "OZEL_KOD4_ID";
            this.OZEL_KOD4_ID.Visible = true;
            this.OZEL_KOD4_ID.VisibleIndex = 8;
            // 
            // TASLAK_TARIHI
            // 
            this.TASLAK_TARIHI.Caption = "Taslak T.";
            this.TASLAK_TARIHI.FieldName = "TASLAK_TARIHI";
            this.TASLAK_TARIHI.Name = "TASLAK_TARIHI";
            this.TASLAK_TARIHI.Visible = true;
            this.TASLAK_TARIHI.VisibleIndex = 9;
            // 
            // IMZA_TARIHI
            // 
            this.IMZA_TARIHI.Caption = "Ýmza T.";
            this.IMZA_TARIHI.FieldName = "IMZA_TARIHI";
            this.IMZA_TARIHI.Name = "IMZA_TARIHI";
            this.IMZA_TARIHI.Visible = true;
            this.IMZA_TARIHI.VisibleIndex = 10;
            // 
            // BASLANGIC_TARIHI
            // 
            this.BASLANGIC_TARIHI.Caption = "Baþlangýç T.";
            this.BASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            this.BASLANGIC_TARIHI.Name = "BASLANGIC_TARIHI";
            this.BASLANGIC_TARIHI.Visible = true;
            this.BASLANGIC_TARIHI.VisibleIndex = 11;
            // 
            // YENILENME_TARIHI
            // 
            this.YENILENME_TARIHI.Caption = "Yenileme T.";
            this.YENILENME_TARIHI.FieldName = "YENILENME_TARIHI";
            this.YENILENME_TARIHI.Name = "YENILENME_TARIHI";
            this.YENILENME_TARIHI.Visible = true;
            this.YENILENME_TARIHI.VisibleIndex = 12;
            // 
            // SON_ISLEM_TARIHI
            // 
            this.SON_ISLEM_TARIHI.Caption = "Son Ýþlem T.";
            this.SON_ISLEM_TARIHI.FieldName = "SON_ISLEM_TARIHI";
            this.SON_ISLEM_TARIHI.Name = "SON_ISLEM_TARIHI";
            this.SON_ISLEM_TARIHI.Visible = true;
            this.SON_ISLEM_TARIHI.VisibleIndex = 13;
            // 
            // BITIS_TARIHI
            // 
            this.BITIS_TARIHI.Caption = "Bitiþ T.";
            this.BITIS_TARIHI.FieldName = "BITIS_TARIHI";
            this.BITIS_TARIHI.Name = "BITIS_TARIHI";
            this.BITIS_TARIHI.Visible = true;
            this.BITIS_TARIHI.VisibleIndex = 14;
            // 
            // BITIRILME_TARIHI
            // 
            this.BITIRILME_TARIHI.Caption = "Bitirilme T.";
            this.BITIRILME_TARIHI.FieldName = "BITIRILME_TARIHI";
            this.BITIRILME_TARIHI.Name = "BITIRILME_TARIHI";
            this.BITIRILME_TARIHI.Visible = true;
            this.BITIRILME_TARIHI.VisibleIndex = 15;
            // 
            // SURE_GUN
            // 
            this.SURE_GUN.Caption = "Gün";
            this.SURE_GUN.FieldName = "SURE_GUN";
            this.SURE_GUN.Name = "SURE_GUN";
            this.SURE_GUN.Visible = true;
            this.SURE_GUN.VisibleIndex = 16;
            // 
            // SURE_AY
            // 
            this.SURE_AY.Caption = "Ay";
            this.SURE_AY.FieldName = "SURE_AY";
            this.SURE_AY.Name = "SURE_AY";
            this.SURE_AY.Visible = true;
            this.SURE_AY.VisibleIndex = 17;
            // 
            // SURE_YIL
            // 
            this.SURE_YIL.Caption = "Yýl";
            this.SURE_YIL.FieldName = "SURE_YIL";
            this.SURE_YIL.Name = "SURE_YIL";
            this.SURE_YIL.Visible = true;
            this.SURE_YIL.VisibleIndex = 18;
            // 
            // NOTER_TARIHI
            // 
            this.NOTER_TARIHI.Caption = "Noter T.";
            this.NOTER_TARIHI.FieldName = "NOTER_TARIHI";
            this.NOTER_TARIHI.Name = "NOTER_TARIHI";
            this.NOTER_TARIHI.Visible = true;
            this.NOTER_TARIHI.VisibleIndex = 19;
            // 
            // NOTER_YEVMIYE_NO
            // 
            this.NOTER_YEVMIYE_NO.Caption = "Yevmiye No";
            this.NOTER_YEVMIYE_NO.FieldName = "NOTER_YEVMIYE_NO";
            this.NOTER_YEVMIYE_NO.Name = "NOTER_YEVMIYE_NO";
            this.NOTER_YEVMIYE_NO.Visible = true;
            this.NOTER_YEVMIYE_NO.VisibleIndex = 20;
            // 
            // ADLI_BIRIM_ADLIYE_ID
            // 
            this.ADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
            this.ADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.ADLI_BIRIM_ADLIYE_ID.Name = "ADLI_BIRIM_ADLIYE_ID";
            this.ADLI_BIRIM_ADLIYE_ID.Visible = true;
            this.ADLI_BIRIM_ADLIYE_ID.VisibleIndex = 21;
            // 
            // ADLI_BIRIM_GOREV_ID
            // 
            this.ADLI_BIRIM_GOREV_ID.Caption = "Görev";
            this.ADLI_BIRIM_GOREV_ID.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.ADLI_BIRIM_GOREV_ID.Name = "ADLI_BIRIM_GOREV_ID";
            this.ADLI_BIRIM_GOREV_ID.Visible = true;
            this.ADLI_BIRIM_GOREV_ID.VisibleIndex = 22;
            // 
            // ADLI_BIRIM_NO_ID
            // 
            this.ADLI_BIRIM_NO_ID.Caption = "Birim No";
            this.ADLI_BIRIM_NO_ID.FieldName = "ADLI_BIRIM_NO_ID";
            this.ADLI_BIRIM_NO_ID.Name = "ADLI_BIRIM_NO_ID";
            this.ADLI_BIRIM_NO_ID.Visible = true;
            this.ADLI_BIRIM_NO_ID.VisibleIndex = 23;
            // 
            // YEDI_EMIN_CARI_ID
            // 
            this.YEDI_EMIN_CARI_ID.Caption = "Yeddi Emin";
            this.YEDI_EMIN_CARI_ID.FieldName = "YEDI_EMIN_CARI_ID";
            this.YEDI_EMIN_CARI_ID.Name = "YEDI_EMIN_CARI_ID";
            this.YEDI_EMIN_CARI_ID.Visible = true;
            this.YEDI_EMIN_CARI_ID.VisibleIndex = 24;
            // 
            // BEDELI_DOVIZ_ID
            // 
            this.BEDELI_DOVIZ_ID.Caption = "BRM";
            this.BEDELI_DOVIZ_ID.FieldName = "BEDELI_DOVIZ_ID";
            this.BEDELI_DOVIZ_ID.Name = "BEDELI_DOVIZ_ID";
            this.BEDELI_DOVIZ_ID.Visible = true;
            this.BEDELI_DOVIZ_ID.VisibleIndex = 25;
            // 
            // BEDELI
            // 
            this.BEDELI.Caption = "Bedeli";
            this.BEDELI.FieldName = "BEDELI";
            this.BEDELI.Name = "BEDELI";
            this.BEDELI.Visible = true;
            this.BEDELI.VisibleIndex = 26;
            // 
            // TAHLIYE_TAAHHUT_TARIHI
            // 
            this.TAHLIYE_TAAHHUT_TARIHI.Caption = "Taahhut T.";
            this.TAHLIYE_TAAHHUT_TARIHI.FieldName = "TAHLIYE_TAAHHUT_TARIHI";
            this.TAHLIYE_TAAHHUT_TARIHI.Name = "TAHLIYE_TAAHHUT_TARIHI";
            this.TAHLIYE_TAAHHUT_TARIHI.Visible = true;
            this.TAHLIYE_TAAHHUT_TARIHI.VisibleIndex = 27;
            // 
            // TAHLIYE_ADRESI
            // 
            this.TAHLIYE_ADRESI.Caption = "Tahliye Adresi";
            this.TAHLIYE_ADRESI.FieldName = "TAHLIYE_ADRESI";
            this.TAHLIYE_ADRESI.Name = "TAHLIYE_ADRESI";
            this.TAHLIYE_ADRESI.Visible = true;
            this.TAHLIYE_ADRESI.VisibleIndex = 28;
            // 
            // KART_TIP_ID
            // 
            this.KART_TIP_ID.Caption = "Kart Tipi";
            this.KART_TIP_ID.FieldName = "KART_TIP_ID";
            this.KART_TIP_ID.Name = "KART_TIP_ID";
            this.KART_TIP_ID.Visible = true;
            this.KART_TIP_ID.VisibleIndex = 29;
            // 
            // KREDI_KART_NO
            // 
            this.KREDI_KART_NO.Caption = "Kredi K. No";
            this.KREDI_KART_NO.FieldName = "KREDI_KART_NO";
            this.KREDI_KART_NO.Name = "KREDI_KART_NO";
            this.KREDI_KART_NO.Visible = true;
            this.KREDI_KART_NO.VisibleIndex = 30;
            // 
            // CVV1
            // 
            this.CVV1.Caption = "CVV1";
            this.CVV1.FieldName = "CVV1";
            this.CVV1.Name = "CVV1";
            this.CVV1.Visible = true;
            this.CVV1.VisibleIndex = 31;
            // 
            // CVV2
            // 
            this.CVV2.Caption = "CVV2";
            this.CVV2.FieldName = "CVV2";
            this.CVV2.Name = "CVV2";
            this.CVV2.Visible = true;
            this.CVV2.VisibleIndex = 32;
            // 
            // SON_KULLANIM_TARIHI
            // 
            this.SON_KULLANIM_TARIHI.Caption = "S.K.T";
            this.SON_KULLANIM_TARIHI.FieldName = "SON_KULLANIM_TARIHI";
            this.SON_KULLANIM_TARIHI.Name = "SON_KULLANIM_TARIHI";
            this.SON_KULLANIM_TARIHI.Visible = true;
            this.SON_KULLANIM_TARIHI.VisibleIndex = 33;
            // 
            // REHIN_CINS_ID
            // 
            this.REHIN_CINS_ID.Caption = "Rehin Cins";
            this.REHIN_CINS_ID.FieldName = "REHIN_CINS_ID";
            this.REHIN_CINS_ID.Name = "REHIN_CINS_ID";
            this.REHIN_CINS_ID.Visible = true;
            this.REHIN_CINS_ID.VisibleIndex = 34;
            // 
            // BORC_IKRARINI_HAVI_MI
            // 
            this.BORC_IKRARINI_HAVI_MI.Caption = "Borç Ikrarý Havimi";
            this.BORC_IKRARINI_HAVI_MI.FieldName = "BORC_IKRARINI_HAVI_MI";
            this.BORC_IKRARINI_HAVI_MI.Name = "BORC_IKRARINI_HAVI_MI";
            this.BORC_IKRARINI_HAVI_MI.Visible = true;
            this.BORC_IKRARINI_HAVI_MI.VisibleIndex = 35;
            // 
            // HARC_ISTISNA_ID
            // 
            this.HARC_ISTISNA_ID.Caption = "Harc Istisna";
            this.HARC_ISTISNA_ID.FieldName = "HARC_ISTISNA_ID";
            this.HARC_ISTISNA_ID.Name = "HARC_ISTISNA_ID";
            this.HARC_ISTISNA_ID.Visible = true;
            this.HARC_ISTISNA_ID.VisibleIndex = 36;
            // 
            // HARC_ISTISNA_BELGE_TARIH
            // 
            this.HARC_ISTISNA_BELGE_TARIH.Caption = "Belge T.";
            this.HARC_ISTISNA_BELGE_TARIH.FieldName = "HARC_ISTISNA_BELGE_TARIH";
            this.HARC_ISTISNA_BELGE_TARIH.Name = "HARC_ISTISNA_BELGE_TARIH";
            this.HARC_ISTISNA_BELGE_TARIH.Visible = true;
            this.HARC_ISTISNA_BELGE_TARIH.VisibleIndex = 37;
            // 
            // HARC_ISTISNA_BELGE_NO
            // 
            this.HARC_ISTISNA_BELGE_NO.Caption = "Belge No";
            this.HARC_ISTISNA_BELGE_NO.FieldName = "HARC_ISTISNA_BELGE_NO";
            this.HARC_ISTISNA_BELGE_NO.Name = "HARC_ISTISNA_BELGE_NO";
            this.HARC_ISTISNA_BELGE_NO.Visible = true;
            this.HARC_ISTISNA_BELGE_NO.VisibleIndex = 38;
            // 
            // REHIN_DERECE
            // 
            this.REHIN_DERECE.Caption = "Rehin Derece";
            this.REHIN_DERECE.FieldName = "REHIN_DERECE";
            this.REHIN_DERECE.Name = "REHIN_DERECE";
            this.REHIN_DERECE.Visible = true;
            this.REHIN_DERECE.VisibleIndex = 39;
            // 
            // REHIN_SIRA
            // 
            this.REHIN_SIRA.Caption = "Rehin Sýra";
            this.REHIN_SIRA.FieldName = "REHIN_SIRA";
            this.REHIN_SIRA.Name = "REHIN_SIRA";
            this.REHIN_SIRA.Visible = true;
            this.REHIN_SIRA.VisibleIndex = 40;
            // 
            // SICIL_TIP_ID
            // 
            this.SICIL_TIP_ID.Caption = "Sicil Tip";
            this.SICIL_TIP_ID.FieldName = "SICIL_TIP_ID";
            this.SICIL_TIP_ID.Name = "SICIL_TIP_ID";
            this.SICIL_TIP_ID.Visible = true;
            this.SICIL_TIP_ID.VisibleIndex = 41;
            // 
            // SICIL_BOLGE_NO
            // 
            this.SICIL_BOLGE_NO.Caption = "Sicil Bölge No";
            this.SICIL_BOLGE_NO.FieldName = "SICIL_BOLGE_NO";
            this.SICIL_BOLGE_NO.Name = "SICIL_BOLGE_NO";
            this.SICIL_BOLGE_NO.Visible = true;
            this.SICIL_BOLGE_NO.VisibleIndex = 42;
            // 
            // SICIL_ILCE_ID
            // 
            this.SICIL_ILCE_ID.Caption = "Ilçe";
            this.SICIL_ILCE_ID.FieldName = "SICIL_ILCE_ID";
            this.SICIL_ILCE_ID.Name = "SICIL_ILCE_ID";
            this.SICIL_ILCE_ID.Visible = true;
            this.SICIL_ILCE_ID.VisibleIndex = 43;
            // 
            // SICIL_IL_ID
            // 
            this.SICIL_IL_ID.Caption = "Il";
            this.SICIL_IL_ID.FieldName = "SICIL_IL_ID";
            this.SICIL_IL_ID.Name = "SICIL_IL_ID";
            this.SICIL_IL_ID.Visible = true;
            this.SICIL_IL_ID.VisibleIndex = 44;
            // 
            // SICIL_TARIHI
            // 
            this.SICIL_TARIHI.Caption = "Sicil T.";
            this.SICIL_TARIHI.FieldName = "SICIL_TARIHI";
            this.SICIL_TARIHI.Name = "SICIL_TARIHI";
            this.SICIL_TARIHI.Visible = true;
            this.SICIL_TARIHI.VisibleIndex = 45;
            // 
            // SICIL_YEVMIYE_NO
            // 
            this.SICIL_YEVMIYE_NO.Caption = "Yevmiye No";
            this.SICIL_YEVMIYE_NO.FieldName = "SICIL_YEVMIYE_NO";
            this.SICIL_YEVMIYE_NO.Name = "SICIL_YEVMIYE_NO";
            this.SICIL_YEVMIYE_NO.Visible = true;
            this.SICIL_YEVMIYE_NO.VisibleIndex = 46;
            // 
            // SICIL_TESCIL_NO
            // 
            this.SICIL_TESCIL_NO.Caption = "Tescil No";
            this.SICIL_TESCIL_NO.FieldName = "SICIL_TESCIL_NO";
            this.SICIL_TESCIL_NO.Name = "SICIL_TESCIL_NO";
            this.SICIL_TESCIL_NO.Visible = true;
            this.SICIL_TESCIL_NO.VisibleIndex = 47;
            // 
            // FEK_TARIHI3
            // 
            this.FEK_TARIHI3.Caption = "Fek T.";
            this.FEK_TARIHI3.FieldName = "FEK_TARIHI";
            this.FEK_TARIHI3.Name = "FEK_TARIHI3";
            this.FEK_TARIHI3.Visible = true;
            this.FEK_TARIHI3.VisibleIndex = 48;
            // 
            // REHIN_DURUM_ID
            // 
            this.REHIN_DURUM_ID.Caption = "Rehin Durum";
            this.REHIN_DURUM_ID.FieldName = "REHIN_DURUM_ID";
            this.REHIN_DURUM_ID.Name = "REHIN_DURUM_ID";
            this.REHIN_DURUM_ID.Visible = true;
            this.REHIN_DURUM_ID.VisibleIndex = 49;
            // 
            // SOZLESME_DURUM_ID
            // 
            this.SOZLESME_DURUM_ID.Caption = "Söz. Durum";
            this.SOZLESME_DURUM_ID.FieldName = "SOZLESME_DURUM_ID";
            this.SOZLESME_DURUM_ID.Name = "SOZLESME_DURUM_ID";
            this.SOZLESME_DURUM_ID.Visible = true;
            this.SOZLESME_DURUM_ID.VisibleIndex = 50;
            // 
            // DURUM_ACIKLAMA
            // 
            this.DURUM_ACIKLAMA.Caption = "Durum Açýklama";
            this.DURUM_ACIKLAMA.FieldName = "DURUM_ACIKLAMA";
            this.DURUM_ACIKLAMA.Name = "DURUM_ACIKLAMA";
            this.DURUM_ACIKLAMA.Visible = true;
            this.DURUM_ACIKLAMA.VisibleIndex = 51;
            // 
            // ACIKLAMA
            // 
            this.ACIKLAMA.Caption = "Açýklama";
            this.ACIKLAMA.FieldName = "ACIKLAMA";
            this.ACIKLAMA.Name = "ACIKLAMA";
            this.ACIKLAMA.Visible = true;
            this.ACIKLAMA.VisibleIndex = 52;
            // 
            // REHIN_CINS_ANA_TURU
            // 
            this.REHIN_CINS_ANA_TURU.Caption = "Rehin Cins Ana Tür";
            this.REHIN_CINS_ANA_TURU.FieldName = "REHIN_CINS_ANA_TURU";
            this.REHIN_CINS_ANA_TURU.Name = "REHIN_CINS_ANA_TURU";
            this.REHIN_CINS_ANA_TURU.Visible = true;
            this.REHIN_CINS_ANA_TURU.VisibleIndex = 53;
            // 
            // ISLEMLER_BASLADIMI1
            // 
            this.ISLEMLER_BASLADIMI1.Caption = "Ýþlemler Baþladýmý";
            this.ISLEMLER_BASLADIMI1.FieldName = "ISLEMLER_BASLADIMI";
            this.ISLEMLER_BASLADIMI1.Name = "ISLEMLER_BASLADIMI1";
            this.ISLEMLER_BASLADIMI1.Visible = true;
            this.ISLEMLER_BASLADIMI1.VisibleIndex = 54;
            // 
            // UCRETIN_ODENME_SEKLI_ID
            // 
            this.UCRETIN_ODENME_SEKLI_ID.Caption = "Ü. Ödenme Þekli";
            this.UCRETIN_ODENME_SEKLI_ID.FieldName = "UCRETIN_ODENME_SEKLI_ID";
            this.UCRETIN_ODENME_SEKLI_ID.Name = "UCRETIN_ODENME_SEKLI_ID";
            this.UCRETIN_ODENME_SEKLI_ID.Visible = true;
            this.UCRETIN_ODENME_SEKLI_ID.VisibleIndex = 55;
            // 
            // HAKEM_YARGILAMASININ_YERI_ID
            // 
            this.HAKEM_YARGILAMASININ_YERI_ID.Caption = "Yarg. Yeri";
            this.HAKEM_YARGILAMASININ_YERI_ID.FieldName = "HAKEM_YARGILAMASININ_YERI_ID";
            this.HAKEM_YARGILAMASININ_YERI_ID.Name = "HAKEM_YARGILAMASININ_YERI_ID";
            this.HAKEM_YARGILAMASININ_YERI_ID.Visible = true;
            this.HAKEM_YARGILAMASININ_YERI_ID.VisibleIndex = 56;
            // 
            // SURE_UYGULAMA_TIPI
            // 
            this.SURE_UYGULAMA_TIPI.Caption = "Süre Uygulama Yeri";
            this.SURE_UYGULAMA_TIPI.FieldName = "SURE_UYGULAMA_TIPI";
            this.SURE_UYGULAMA_TIPI.Name = "SURE_UYGULAMA_TIPI";
            this.SURE_UYGULAMA_TIPI.Visible = true;
            this.SURE_UYGULAMA_TIPI.VisibleIndex = 57;
            // 
            // gridView11
            // 
            this.gridView11.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TARAF_CARI_ID,
            this.IHTAR_TEBLIG_TARIHI,
            this.TEMERRUT_TARIHI,
            this.ZAMAN_ASIMI_TARIHI,
            this.IHTAR_TARIHI,
            this.gridColumn141,
            this.gridColumn143,
            this.gridColumn144,
            this.gridColumn151,
            this.gridColumn159,
            this.gridColumn164});
            this.gridView11.GridControl = this.gcAlacak;
            this.gridView11.Name = "gridView11";
            this.gridView11.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView11.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridView11.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView11.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView11.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView11.OptionsView.ColumnAutoWidth = false;
            this.gridView11.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView11.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView11.OptionsView.ShowAutoFilterRow = true;
            this.gridView11.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView11.PaintStyleName = "Skin";
            this.gridView11.ViewCaption = "Alacak Neden Taraf";
            // 
            // TARAF_CARI_ID
            // 
            this.TARAF_CARI_ID.Caption = "Taraf";
            this.TARAF_CARI_ID.FieldName = "TARAF_CARI_ID";
            this.TARAF_CARI_ID.Name = "TARAF_CARI_ID";
            this.TARAF_CARI_ID.Visible = true;
            this.TARAF_CARI_ID.VisibleIndex = 0;
            // 
            // IHTAR_TEBLIG_TARIHI
            // 
            this.IHTAR_TEBLIG_TARIHI.Caption = "Teblið T.";
            this.IHTAR_TEBLIG_TARIHI.FieldName = "IHTAR_TEBLIG_TARIHI";
            this.IHTAR_TEBLIG_TARIHI.Name = "IHTAR_TEBLIG_TARIHI";
            this.IHTAR_TEBLIG_TARIHI.Visible = true;
            this.IHTAR_TEBLIG_TARIHI.VisibleIndex = 1;
            // 
            // TEMERRUT_TARIHI
            // 
            this.TEMERRUT_TARIHI.Caption = "Temerrüt T.";
            this.TEMERRUT_TARIHI.FieldName = "TEMERRUT_TARIHI";
            this.TEMERRUT_TARIHI.Name = "TEMERRUT_TARIHI";
            this.TEMERRUT_TARIHI.Visible = true;
            this.TEMERRUT_TARIHI.VisibleIndex = 2;
            // 
            // ZAMAN_ASIMI_TARIHI
            // 
            this.ZAMAN_ASIMI_TARIHI.Caption = "Zaman Aþýmý";
            this.ZAMAN_ASIMI_TARIHI.FieldName = "ZAMAN_ASIMI_TARIHI";
            this.ZAMAN_ASIMI_TARIHI.Name = "ZAMAN_ASIMI_TARIHI";
            this.ZAMAN_ASIMI_TARIHI.Visible = true;
            this.ZAMAN_ASIMI_TARIHI.VisibleIndex = 3;
            // 
            // IHTAR_TARIHI
            // 
            this.IHTAR_TARIHI.Caption = "Ihtar T.";
            this.IHTAR_TARIHI.FieldName = "IHTAR_TARIHI";
            this.IHTAR_TARIHI.Name = "IHTAR_TARIHI";
            this.IHTAR_TARIHI.Visible = true;
            this.IHTAR_TARIHI.VisibleIndex = 4;
            // 
            // gridColumn141
            // 
            this.gridColumn141.Caption = "Sorumluluk Miktarý";
            this.gridColumn141.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.gridColumn141.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn141.FieldName = "SORUMLU_OLUNAN_MIKTAR";
            this.gridColumn141.Name = "gridColumn141";
            this.gridColumn141.Visible = true;
            this.gridColumn141.VisibleIndex = 5;
            // 
            // gridColumn143
            // 
            this.gridColumn143.Caption = "BRM";
            this.gridColumn143.FieldName = "SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID";
            this.gridColumn143.Name = "gridColumn143";
            this.gridColumn143.Visible = true;
            this.gridColumn143.VisibleIndex = 6;
            // 
            // gridColumn144
            // 
            this.gridColumn144.Caption = "Protesto Gideri";
            this.gridColumn144.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.gridColumn144.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn144.FieldName = "PROTESTO_GIDERI";
            this.gridColumn144.Name = "gridColumn144";
            this.gridColumn144.Visible = true;
            this.gridColumn144.VisibleIndex = 7;
            // 
            // gridColumn151
            // 
            this.gridColumn151.Caption = "BRM";
            this.gridColumn151.FieldName = "PROTESTO_GIDERI_DOVIZ_ID";
            this.gridColumn151.Name = "gridColumn151";
            this.gridColumn151.Visible = true;
            this.gridColumn151.VisibleIndex = 8;
            // 
            // gridColumn159
            // 
            this.gridColumn159.Caption = "Ýhtar Gideri";
            this.gridColumn159.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.gridColumn159.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn159.FieldName = "IHTAR_GIDERI";
            this.gridColumn159.Name = "gridColumn159";
            this.gridColumn159.Visible = true;
            this.gridColumn159.VisibleIndex = 9;
            // 
            // gridColumn164
            // 
            this.gridColumn164.Caption = "BRM";
            this.gridColumn164.FieldName = "IHTAR_GIDERI_DOVIZ_ID";
            this.gridColumn164.Name = "gridColumn164";
            this.gridColumn164.Visible = true;
            this.gridColumn164.VisibleIndex = 10;
            // 
            // tabOnPanel
            // 
            this.tabOnPanel.Controls.Add(this.ucAlacakNedenTaraf1);
            this.tabOnPanel.Controls.Add(this.ucAlacakNedenTaraf_Faiz1);
            this.tabOnPanel.Controls.Add(this.ucAlacakNedenGirisi1);
            this.tabOnPanel.Name = "tabOnPanel";
            this.tabOnPanel.Size = new System.Drawing.Size(915, 604);
            this.tabOnPanel.Text = "Alacak Giriþi";
            // 
            // tabKiymetliEvrak
            // 
            this.tabKiymetliEvrak.Controls.Add(this.ucKiymetliEvrakTaraf1);
            this.tabKiymetliEvrak.Controls.Add(this.ucKiymetliEvrak1);
            this.tabKiymetliEvrak.Name = "tabKiymetliEvrak";
            this.tabKiymetliEvrak.Size = new System.Drawing.Size(915, 604);
            this.tabKiymetliEvrak.Text = "Kýymetli Evrak Bilgileri";
            // 
            // ucKiymetliEvrakTaraf1
            // 
            this.ucKiymetliEvrakTaraf1.Location = new System.Drawing.Point(563, 0);
            this.ucKiymetliEvrakTaraf1.MyDataSource = null;
            this.ucKiymetliEvrakTaraf1.Name = "ucKiymetliEvrakTaraf1";
            this.ucKiymetliEvrakTaraf1.Size = new System.Drawing.Size(446, 112);
            this.ucKiymetliEvrakTaraf1.TabIndex = 1;
            // 
            // ucKiymetliEvrak1
            // 
            this.ucKiymetliEvrak1.Gorunum = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.ucKiymetliEvrak1.Location = new System.Drawing.Point(0, 0);
            this.ucKiymetliEvrak1.MyDataSource = null;
            this.ucKiymetliEvrak1.MyExtendedDataSource = null;
            this.ucKiymetliEvrak1.Name = "ucKiymetliEvrak1";
            this.ucKiymetliEvrak1.OnlyOneRecord = false;
            this.ucKiymetliEvrak1.Size = new System.Drawing.Size(557, 525);
            this.ucKiymetliEvrak1.TabIndex = 0;
            this.ucKiymetliEvrak1.FocusedRecordChanged += new DevExpress.XtraVerticalGrid.Events.IndexChangedEventHandler(this.ucKiymetliEvrak1_FocusedRecordChanged);
            // 
            // rlueAlacakNedeni
            // 
            this.rlueAlacakNedeni.AutoHeight = false;
            this.rlueAlacakNedeni.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueAlacakNedeni.Name = "rlueAlacakNedeni";
            // 
            // rlueDovizID
            // 
            this.rlueDovizID.AutoHeight = false;
            this.rlueDovizID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueDovizID.Name = "rlueDovizID";
            // 
            // frmAlacakGirisi
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 641);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAlacakGirisi";
            this.Text = "Alacak Giriþi";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.frmAlacakGirisi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcAlacakGirisi)).EndInit();
            this.tcAlacakGirisi.ResumeLayout(false);
            this.tabDigerBilgiler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAlacak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TIBILALACAKNEDENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwAlacak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).EndInit();
            this.tabOnPanel.ResumeLayout(false);
            this.tabKiymetliEvrak.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rlueAlacakNedeni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDovizID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AdimAdimDavaKaydi.UserControls.ucAlacakNedenGirisi ucAlacakNedenGirisi1;
        private AdimAdimDavaKaydi.IcraTakip.UserControls.ucAlacakNedenTaraf ucAlacakNedenTaraf1;
        private AdimAdimDavaKaydi.IcraTakip.UserControls.ucAlacakNedenTaraf_Faiz ucAlacakNedenTaraf_Faiz1;
        private DevExpress.XtraTab.XtraTabControl tcAlacakGirisi;
        private DevExpress.XtraTab.XtraTabPage tabOnPanel;
        private DevExpress.XtraTab.XtraTabPage tabDigerBilgiler;
        private AdimAdimDavaKaydi.UserControls.ucTebligatKayitUfakDock ucTebligatKayitUfakDock1;
        private DevExpress.XtraTab.XtraTabPage tabKiymetliEvrak;
        private ucKiymetliEvrak ucKiymetliEvrak1;
        private ucKiymetliEvrakTaraf ucKiymetliEvrakTaraf1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        public AdimAdimDavaKaydi.Util.ExtendedGridControl gcAlacak;
        private DevExpress.XtraGrid.Views.Grid.GridView gwAlacak;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn colALACAK_NEDEN_KOD_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colDIGER_ALACAK_NEDENI;
        private DevExpress.XtraGrid.Columns.GridColumn colDUZENLENME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colVADE_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_BASLANGIC_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colHESAPLAMA_MODU;
        private DevExpress.XtraGrid.Columns.GridColumn colTUTARI;
        private DevExpress.XtraGrid.Columns.GridColumn colTUTAR_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colISLEME_KONAN_TUTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colISLEME_KONAN_TUTAR_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colHARCA_ESAS_DEGER;
        private DevExpress.XtraGrid.Columns.GridColumn colHARCA_ESAS_DEGER_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_YOK;
        private DevExpress.XtraGrid.Columns.GridColumn colALACAK_FAIZ_TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colUYGULANACAK_FAIZ_ORANI;
        private DevExpress.XtraGrid.Columns.GridColumn colTO_ALACAK_FAIZ_TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTO_UYGULANACAK_FAIZ_ORANI;
        private DevExpress.XtraGrid.Columns.GridColumn colSABIT_FAIZ_UYGULA;
        private DevExpress.XtraGrid.Columns.GridColumn colBIR_GUNE_AYLIK_FAIZ;
        private DevExpress.XtraGrid.Columns.GridColumn colIHTAR_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colIHTAR_GIDERI;
        private DevExpress.XtraGrid.Columns.GridColumn colIHTAR_GIDERI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colPROTESTO_GIDERI;
        private DevExpress.XtraGrid.Columns.GridColumn colPROTESTO_GIDERI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colHER_AY_TAZMINAT_EKLE;
        private DevExpress.XtraGrid.Columns.GridColumn colTAZMINAT_TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTAZMINATI_ORANI;
        private DevExpress.XtraGrid.Columns.GridColumn colCEK_TAZMINATI_ORANI;
        private DevExpress.XtraGrid.Columns.GridColumn colKOMISYONU_ORANI;
        private DevExpress.XtraGrid.Columns.GridColumn colBSMV_HESAPLANSIN;
        private DevExpress.XtraGrid.Columns.GridColumn colKKDV_HESAPLANSIN;
        private DevExpress.XtraGrid.Columns.GridColumn colOIV_HESAPLANSIN;
        private DevExpress.XtraGrid.Columns.GridColumn colKDV_HESAPLANSIN;
        private DevExpress.XtraGrid.Columns.GridColumn colKDV_TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colDAMGA_PULU_HESAPLANSIN;
        private DevExpress.XtraGrid.Columns.GridColumn colSURE_GUN;
        private DevExpress.XtraGrid.Columns.GridColumn colSURE_AY;
        private DevExpress.XtraGrid.Columns.GridColumn colSURE_YIL;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn colREFERANS_NO2;
        private DevExpress.XtraGrid.Columns.GridColumn colREFERANS_NO3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn GEMI_UCAK_ARAC_TIP;
        private DevExpress.XtraGrid.Columns.GridColumn ADI;
        private DevExpress.XtraGrid.Columns.GridColumn CINSI;
        private DevExpress.XtraGrid.Columns.GridColumn TESCIL_NUMARASI;
        private DevExpress.XtraGrid.Columns.GridColumn TANIMA_ISARETI;
        private DevExpress.XtraGrid.Columns.GridColumn INSA_YILI;
        private DevExpress.XtraGrid.Columns.GridColumn INSA_YERI;
        private DevExpress.XtraGrid.Columns.GridColumn BOYU;
        private DevExpress.XtraGrid.Columns.GridColumn ENI;
        private DevExpress.XtraGrid.Columns.GridColumn TONALITOSU;
        private DevExpress.XtraGrid.Columns.GridColumn BAGLAMA_LIMANI;
        private DevExpress.XtraGrid.Columns.GridColumn TEKNIK_KUTUK_NO;
        private DevExpress.XtraGrid.Columns.GridColumn ERISIM_NO;
        private DevExpress.XtraGrid.Columns.GridColumn TIPI;
        private DevExpress.XtraGrid.Columns.GridColumn DERINLIGI;
        private DevExpress.XtraGrid.Columns.GridColumn KUTUK_BOYU;
        private DevExpress.XtraGrid.Columns.GridColumn ARAC_PLAKA;
        private DevExpress.XtraGrid.Columns.GridColumn ARAC_MODEL;
        private DevExpress.XtraGrid.Columns.GridColumn ARAC_TIP;
        private DevExpress.XtraGrid.Columns.GridColumn ARAC_MOTOR_NO;
        private DevExpress.XtraGrid.Columns.GridColumn ARAC_SASI_NO;
        private DevExpress.XtraGrid.Columns.GridColumn ARAC_RENK;
        private DevExpress.XtraGrid.Columns.GridColumn TRAFIK_SUBESI;
        private DevExpress.XtraGrid.Columns.GridColumn RUHSAT_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn RUHSAT_SICIL_NO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn colICRA_ALACAK_NEDEN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTARAF_CARI_ID1;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_BASLANGIC_TARIHI1;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_BITIS_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colSABIT_FAIZ;
        private DevExpress.XtraGrid.Columns.GridColumn colBIR_GUNE_AYLIK_FAIZ1;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_TIP_ID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraGrid.Columns.GridColumn EVRAK_TUR_ID;
        private DevExpress.XtraGrid.Columns.GridColumn EVRAK_KAYIT_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn EVRAK_VADE_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn EVRAK_TANZIM_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn TUTAR_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn TUTAR;
        private DevExpress.XtraGrid.Columns.GridColumn NE_SEKILDE_AHZOLUNDUGU;
        private DevExpress.XtraGrid.Columns.GridColumn BANKA_ID;
        private DevExpress.XtraGrid.Columns.GridColumn SUBE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn BANKA_SUBE_KODU;
        private DevExpress.XtraGrid.Columns.GridColumn HESAP_NO;
        private DevExpress.XtraGrid.Columns.GridColumn CEK_NO;
        private DevExpress.XtraGrid.Columns.GridColumn SORULDUGU_TARIH;
        private DevExpress.XtraGrid.Columns.GridColumn SORULMA_SONUCU;
        private DevExpress.XtraGrid.Columns.GridColumn KARSILIK_TUTAR_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn KARSILIK_TUTAR;
        private DevExpress.XtraGrid.Columns.GridColumn SORAN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn ARKASI_YAZILDI_MI;
        private DevExpress.XtraGrid.Columns.GridColumn SERH_ACIKLAMASI;
        private DevExpress.XtraGrid.Columns.GridColumn ILK_ALACAKLI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn ILK_BORCLU_ID;
        private DevExpress.XtraGrid.Columns.GridColumn SIKAYET_EDILDI_MI;
        private DevExpress.XtraGrid.Columns.GridColumn KESIDE_YERI;
        private DevExpress.XtraGrid.Columns.GridColumn ODEME_YERI;
        private DevExpress.XtraGrid.Columns.GridColumn ISLEMLER_BASLADIMI;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
        private DevExpress.XtraGrid.Columns.GridColumn TUR;
        private DevExpress.XtraGrid.Columns.GridColumn SOZLESME_NO;
        private DevExpress.XtraGrid.Columns.GridColumn SOZLESME_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn ALT_TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn TASNIF_NO;
        private DevExpress.XtraGrid.Columns.GridColumn OZEL_KOD1_ID;
        private DevExpress.XtraGrid.Columns.GridColumn OZEL_KOD2_ID;
        private DevExpress.XtraGrid.Columns.GridColumn OZEL_KOD3_ID;
        private DevExpress.XtraGrid.Columns.GridColumn OZEL_KOD4_ID;
        private DevExpress.XtraGrid.Columns.GridColumn TASLAK_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn IMZA_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn BASLANGIC_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn YENILENME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn SON_ISLEM_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn BITIS_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn BITIRILME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn SURE_GUN;
        private DevExpress.XtraGrid.Columns.GridColumn SURE_AY;
        private DevExpress.XtraGrid.Columns.GridColumn SURE_YIL;
        private DevExpress.XtraGrid.Columns.GridColumn NOTER_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn NOTER_YEVMIYE_NO;
        private DevExpress.XtraGrid.Columns.GridColumn ADLI_BIRIM_ADLIYE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn ADLI_BIRIM_GOREV_ID;
        private DevExpress.XtraGrid.Columns.GridColumn ADLI_BIRIM_NO_ID;
        private DevExpress.XtraGrid.Columns.GridColumn YEDI_EMIN_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn BEDELI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn BEDELI;
        private DevExpress.XtraGrid.Columns.GridColumn TAHLIYE_TAAHHUT_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn TAHLIYE_ADRESI;
        private DevExpress.XtraGrid.Columns.GridColumn KART_TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn KREDI_KART_NO;
        private DevExpress.XtraGrid.Columns.GridColumn CVV1;
        private DevExpress.XtraGrid.Columns.GridColumn CVV2;
        private DevExpress.XtraGrid.Columns.GridColumn SON_KULLANIM_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn REHIN_CINS_ID;
        private DevExpress.XtraGrid.Columns.GridColumn BORC_IKRARINI_HAVI_MI;
        private DevExpress.XtraGrid.Columns.GridColumn HARC_ISTISNA_ID;
        private DevExpress.XtraGrid.Columns.GridColumn HARC_ISTISNA_BELGE_TARIH;
        private DevExpress.XtraGrid.Columns.GridColumn HARC_ISTISNA_BELGE_NO;
        private DevExpress.XtraGrid.Columns.GridColumn REHIN_DERECE;
        private DevExpress.XtraGrid.Columns.GridColumn REHIN_SIRA;
        private DevExpress.XtraGrid.Columns.GridColumn SICIL_TIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn SICIL_BOLGE_NO;
        private DevExpress.XtraGrid.Columns.GridColumn SICIL_ILCE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn SICIL_IL_ID;
        private DevExpress.XtraGrid.Columns.GridColumn SICIL_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn SICIL_YEVMIYE_NO;
        private DevExpress.XtraGrid.Columns.GridColumn SICIL_TESCIL_NO;
        private DevExpress.XtraGrid.Columns.GridColumn FEK_TARIHI3;
        private DevExpress.XtraGrid.Columns.GridColumn REHIN_DURUM_ID;
        private DevExpress.XtraGrid.Columns.GridColumn SOZLESME_DURUM_ID;
        private DevExpress.XtraGrid.Columns.GridColumn DURUM_ACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn ACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn REHIN_CINS_ANA_TURU;
        private DevExpress.XtraGrid.Columns.GridColumn ISLEMLER_BASLADIMI1;
        private DevExpress.XtraGrid.Columns.GridColumn UCRETIN_ODENME_SEKLI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn HAKEM_YARGILAMASININ_YERI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn SURE_UYGULAMA_TIPI;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView11;
        private DevExpress.XtraGrid.Columns.GridColumn TARAF_CARI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn IHTAR_TEBLIG_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn TEMERRUT_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn ZAMAN_ASIMI_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn IHTAR_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn141;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn143;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn144;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn151;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn159;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn164;
        private System.Windows.Forms.BindingSource aV001TIBILALACAKNEDENBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnMasrafEkle;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueAlacakNedeni;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueDovizID;
    }
}
