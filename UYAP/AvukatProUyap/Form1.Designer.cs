namespace  AdimAdimDavaKaydi
{
    partial class Form1
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
            this.btnUyap = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.Yenile = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FORM_ORNEK_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FOY_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REFERANS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DURUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TAKIP_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ADLIYE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GOREV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BIRIM_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ESAS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ICRA_OZEL_KOD1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ICRA_OZEL_KOD2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ICRA_OZEL_KOD3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ICRA_OZEL_KOD4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ASIL_ALACAK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ISLEMIS_FAIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ISLEMIS_FAIZ_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TAKIP_CIKISI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SONRAKI_FAIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SONRAKI_FAIZ_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ODEME_TOPLAMI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TO_ODEME_TOPLAMI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KALAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KALAN_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ASAMA_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.saveUyapBelgeDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUyap
            // 
            this.btnUyap.Location = new System.Drawing.Point(138, 1);
            this.btnUyap.Name = "btnUyap";
            this.btnUyap.Size = new System.Drawing.Size(127, 39);
            this.btnUyap.TabIndex = 5;
            this.btnUyap.Text = "Uyap Çıktısı >>>";
            this.btnUyap.Click += new System.EventHandler(this.btnUyap_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.Yenile);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.btnUyap);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(949, 45);
            this.panelControl1.TabIndex = 6;
            // 
            // Yenile
            // 
            this.Yenile.Location = new System.Drawing.Point(5, 1);
            this.Yenile.Name = "Yenile";
            this.Yenile.Size = new System.Drawing.Size(127, 39);
            this.Yenile.TabIndex = 5;
            this.Yenile.Text = "Kayıtları Yenile";
            this.Yenile.Click += new System.EventHandler(this.Yenile_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(272, 1);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(127, 39);
            this.simpleButton2.TabIndex = 5;
            this.simpleButton2.Text = "Editör Çıktısı >>>";
            this.simpleButton2.Visible = false;
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // vGridControl1
            // 
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vGridControl1.Location = new System.Drawing.Point(639, 45);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.Size = new System.Drawing.Size(310, 555);
            this.vGridControl1.TabIndex = 8;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 45);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(639, 555);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.FORM_ORNEK_NO,
            this.FOY_NO,
            this.REFERANS_NO,
            this.DURUM,
            this.TAKIP_TARIHI,
            this.ADLIYE,
            this.GOREV,
            this.BIRIM_NO,
            this.ESAS_NO,
            this.ICRA_OZEL_KOD1,
            this.ICRA_OZEL_KOD2,
            this.ICRA_OZEL_KOD3,
            this.ICRA_OZEL_KOD4,
            this.TAKIBIN_AVUKATA_INTIKAL_TARIHI,
            this.TAKIBIN_MUVEKKILE_IADE_TARIHI,
            this.ASIL_ALACAK,
            this.ASIL_ALACAK_DOVIZ_ID,
            this.ISLEMIS_FAIZ,
            this.ISLEMIS_FAIZ_DOVIZ_ID,
            this.TAKIP_CIKISI,
            this.TAKIP_CIKISI_DOVIZ_ID,
            this.SONRAKI_FAIZ,
            this.SONRAKI_FAIZ_DOVIZ_ID,
            this.ODEME_TOPLAMI,
            this.ODEME_TOPLAMI_DOVIZ_ID,
            this.TO_ODEME_TOPLAMI,
            this.TO_ODEME_TOPLAMI_DOVIZ_ID,
            this.KALAN,
            this.KALAN_DOVIZ_ID,
            this.ACIKLAMA,
            this.ASAMA_ID,
            this.gridColumn12});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Başlıkları Buraya Sürükleyin";
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ASIL_ALACAK", this.ASIL_ALACAK, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ISLEMIS_FAIZ", this.ISLEMIS_FAIZ, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SONRAKI_FAIZ", this.SONRAKI_FAIZ, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_TOPLAMI", this.ODEME_TOPLAMI, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_ODEME_TOPLAMI", this.TO_ODEME_TOPLAMI, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KALAN", this.KALAN, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ISLEMIS_FAIZ_DOVIZ_ID", this.ISLEMIS_FAIZ_DOVIZ_ID, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_TOPLAMI_DOVIZ_ID", this.ODEME_TOPLAMI_DOVIZ_ID, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ASIL_ALACAK_DOVIZ_ID", this.ASIL_ALACAK_DOVIZ_ID, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KALAN_DOVIZ_ID", this.KALAN_DOVIZ_ID, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_ODEME_TOPLAMI_DOVIZ_ID", this.TO_ODEME_TOPLAMI_DOVIZ_ID, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SONRAKI_FAIZ_DOVIZ_ID", this.SONRAKI_FAIZ_DOVIZ_ID, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAKIP_CIKISI", this.TAKIP_CIKISI, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAKIP_CIKISI_DOVIZ_ID", this.TAKIP_CIKISI_DOVIZ_ID, "{0}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Bu Bölümden Yeni Kayıt Ekleyemezsiniz..";
            this.gridView1.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView1.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowPreview = true;
            this.gridView1.PreviewFieldName = "ACIKLAMA";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Seç";
            this.gridColumn1.FieldName = "IsSelected";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 55;
            // 
            // FORM_ORNEK_NO
            // 
            this.FORM_ORNEK_NO.Caption = "Örnek No";
            this.FORM_ORNEK_NO.FieldName = "FORM_TIP_ID";
            this.FORM_ORNEK_NO.Name = "FORM_ORNEK_NO";
            this.FORM_ORNEK_NO.Visible = true;
            this.FORM_ORNEK_NO.VisibleIndex = 1;
            this.FORM_ORNEK_NO.Width = 86;
            // 
            // FOY_NO
            // 
            this.FOY_NO.Caption = "Föy No";
            this.FOY_NO.FieldName = "FOY_NO";
            this.FOY_NO.Name = "FOY_NO";
            this.FOY_NO.Visible = true;
            this.FOY_NO.VisibleIndex = 2;
            this.FOY_NO.Width = 97;
            // 
            // REFERANS_NO
            // 
            this.REFERANS_NO.Caption = "Referans No";
            this.REFERANS_NO.FieldName = "REFERANS_NO";
            this.REFERANS_NO.Name = "REFERANS_NO";
            this.REFERANS_NO.Visible = true;
            this.REFERANS_NO.VisibleIndex = 3;
            this.REFERANS_NO.Width = 90;
            // 
            // DURUM
            // 
            this.DURUM.Caption = "Durum";
            this.DURUM.FieldName = "FOY_DURUM_ID";
            this.DURUM.Name = "DURUM";
            this.DURUM.Visible = true;
            this.DURUM.VisibleIndex = 4;
            this.DURUM.Width = 161;
            // 
            // TAKIP_TARIHI
            // 
            this.TAKIP_TARIHI.Caption = "Takip T.";
            this.TAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            this.TAKIP_TARIHI.Name = "TAKIP_TARIHI";
            this.TAKIP_TARIHI.Visible = true;
            this.TAKIP_TARIHI.VisibleIndex = 5;
            this.TAKIP_TARIHI.Width = 80;
            // 
            // ADLIYE
            // 
            this.ADLIYE.Caption = "Adliye";
            this.ADLIYE.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.ADLIYE.Name = "ADLIYE";
            this.ADLIYE.Visible = true;
            this.ADLIYE.VisibleIndex = 6;
            this.ADLIYE.Width = 137;
            // 
            // GOREV
            // 
            this.GOREV.Caption = "Görev";
            this.GOREV.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.GOREV.Name = "GOREV";
            this.GOREV.Visible = true;
            this.GOREV.VisibleIndex = 7;
            this.GOREV.Width = 124;
            // 
            // BIRIM_NO
            // 
            this.BIRIM_NO.Caption = "No";
            this.BIRIM_NO.FieldName = "ADLI_BIRIM_NO_ID";
            this.BIRIM_NO.Name = "BIRIM_NO";
            this.BIRIM_NO.Visible = true;
            this.BIRIM_NO.VisibleIndex = 8;
            this.BIRIM_NO.Width = 67;
            // 
            // ESAS_NO
            // 
            this.ESAS_NO.Caption = "Esas No";
            this.ESAS_NO.FieldName = "ESAS_NO";
            this.ESAS_NO.Name = "ESAS_NO";
            this.ESAS_NO.Visible = true;
            this.ESAS_NO.VisibleIndex = 9;
            this.ESAS_NO.Width = 67;
            // 
            // ICRA_OZEL_KOD1
            // 
            this.ICRA_OZEL_KOD1.Caption = "Özel Kod 1";
            this.ICRA_OZEL_KOD1.FieldName = "ICRA_OZEL_KOD1_ID";
            this.ICRA_OZEL_KOD1.Name = "ICRA_OZEL_KOD1";
            this.ICRA_OZEL_KOD1.Visible = true;
            this.ICRA_OZEL_KOD1.VisibleIndex = 10;
            // 
            // ICRA_OZEL_KOD2
            // 
            this.ICRA_OZEL_KOD2.Caption = "Özel Kod 2";
            this.ICRA_OZEL_KOD2.FieldName = "ICRA_OZEL_KOD2_ID";
            this.ICRA_OZEL_KOD2.Name = "ICRA_OZEL_KOD2";
            this.ICRA_OZEL_KOD2.Visible = true;
            this.ICRA_OZEL_KOD2.VisibleIndex = 11;
            // 
            // ICRA_OZEL_KOD3
            // 
            this.ICRA_OZEL_KOD3.Caption = "Özel Kod 3";
            this.ICRA_OZEL_KOD3.FieldName = "ICRA_OZEL_KOD3_ID";
            this.ICRA_OZEL_KOD3.Name = "ICRA_OZEL_KOD3";
            this.ICRA_OZEL_KOD3.Visible = true;
            this.ICRA_OZEL_KOD3.VisibleIndex = 12;
            // 
            // ICRA_OZEL_KOD4
            // 
            this.ICRA_OZEL_KOD4.Caption = "Özel Kod 4";
            this.ICRA_OZEL_KOD4.FieldName = "ICRA_OZEL_KOD4_ID";
            this.ICRA_OZEL_KOD4.Name = "ICRA_OZEL_KOD4";
            this.ICRA_OZEL_KOD4.Visible = true;
            this.ICRA_OZEL_KOD4.VisibleIndex = 13;
            // 
            // TAKIBIN_AVUKATA_INTIKAL_TARIHI
            // 
            this.TAKIBIN_AVUKATA_INTIKAL_TARIHI.Caption = "İntikal T.";
            this.TAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            this.TAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            this.TAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = true;
            this.TAKIBIN_AVUKATA_INTIKAL_TARIHI.VisibleIndex = 14;
            // 
            // TAKIBIN_MUVEKKILE_IADE_TARIHI
            // 
            this.TAKIBIN_MUVEKKILE_IADE_TARIHI.Caption = "İade T.";
            this.TAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            this.TAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            this.TAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = true;
            this.TAKIBIN_MUVEKKILE_IADE_TARIHI.VisibleIndex = 15;
            // 
            // ASIL_ALACAK
            // 
            this.ASIL_ALACAK.Caption = "Ana Para";
            this.ASIL_ALACAK.FieldName = "ASIL_ALACAK";
            this.ASIL_ALACAK.Name = "ASIL_ALACAK";
            this.ASIL_ALACAK.SummaryItem.DisplayFormat = "{0:###,###,###,###,##0.00}";
            this.ASIL_ALACAK.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.ASIL_ALACAK.Visible = true;
            this.ASIL_ALACAK.VisibleIndex = 16;
            // 
            // ASIL_ALACAK_DOVIZ_ID
            // 
            this.ASIL_ALACAK_DOVIZ_ID.Caption = "ASIL ALACAK DOVIZ";
            this.ASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            this.ASIL_ALACAK_DOVIZ_ID.Name = "ASIL_ALACAK_DOVIZ_ID";
            this.ASIL_ALACAK_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            this.ASIL_ALACAK_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.ASIL_ALACAK_DOVIZ_ID.Visible = true;
            this.ASIL_ALACAK_DOVIZ_ID.VisibleIndex = 17;
            // 
            // ISLEMIS_FAIZ
            // 
            this.ISLEMIS_FAIZ.Caption = "İşlenmiş Faiz";
            this.ISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            this.ISLEMIS_FAIZ.Name = "ISLEMIS_FAIZ";
            this.ISLEMIS_FAIZ.SummaryItem.DisplayFormat = "{0:###,###,###,###,##0.00}";
            this.ISLEMIS_FAIZ.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.ISLEMIS_FAIZ.SummaryItem.Tag = 1;
            this.ISLEMIS_FAIZ.Visible = true;
            this.ISLEMIS_FAIZ.VisibleIndex = 18;
            // 
            // ISLEMIS_FAIZ_DOVIZ_ID
            // 
            this.ISLEMIS_FAIZ_DOVIZ_ID.Caption = "İşlemiş Faiz Doviz";
            this.ISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            this.ISLEMIS_FAIZ_DOVIZ_ID.Name = "ISLEMIS_FAIZ_DOVIZ_ID";
            this.ISLEMIS_FAIZ_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            this.ISLEMIS_FAIZ_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.ISLEMIS_FAIZ_DOVIZ_ID.SummaryItem.Tag = 2;
            this.ISLEMIS_FAIZ_DOVIZ_ID.Visible = true;
            this.ISLEMIS_FAIZ_DOVIZ_ID.VisibleIndex = 19;
            // 
            // TAKIP_CIKISI
            // 
            this.TAKIP_CIKISI.Caption = "Takip Çıkışı";
            this.TAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            this.TAKIP_CIKISI.Name = "TAKIP_CIKISI";
            this.TAKIP_CIKISI.SummaryItem.DisplayFormat = "{0:###,###,###,###,##0.00}";
            this.TAKIP_CIKISI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.TAKIP_CIKISI.Visible = true;
            this.TAKIP_CIKISI.VisibleIndex = 20;
            // 
            // TAKIP_CIKISI_DOVIZ_ID
            // 
            this.TAKIP_CIKISI_DOVIZ_ID.Caption = "Takip Çıkışı Döviz";
            this.TAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            this.TAKIP_CIKISI_DOVIZ_ID.Name = "TAKIP_CIKISI_DOVIZ_ID";
            this.TAKIP_CIKISI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            this.TAKIP_CIKISI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.TAKIP_CIKISI_DOVIZ_ID.Visible = true;
            this.TAKIP_CIKISI_DOVIZ_ID.VisibleIndex = 21;
            // 
            // SONRAKI_FAIZ
            // 
            this.SONRAKI_FAIZ.Caption = "Sonraki Faiz";
            this.SONRAKI_FAIZ.FieldName = "SONRAKI_FAIZ";
            this.SONRAKI_FAIZ.Name = "SONRAKI_FAIZ";
            this.SONRAKI_FAIZ.SummaryItem.DisplayFormat = "{0:###,###,###,###,##0.00}";
            this.SONRAKI_FAIZ.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.SONRAKI_FAIZ.Visible = true;
            this.SONRAKI_FAIZ.VisibleIndex = 22;
            // 
            // SONRAKI_FAIZ_DOVIZ_ID
            // 
            this.SONRAKI_FAIZ_DOVIZ_ID.Caption = "Sonraki Faiz Döviz";
            this.SONRAKI_FAIZ_DOVIZ_ID.FieldName = "SONRAKI_FAIZ_DOVIZ_ID";
            this.SONRAKI_FAIZ_DOVIZ_ID.Name = "SONRAKI_FAIZ_DOVIZ_ID";
            this.SONRAKI_FAIZ_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            this.SONRAKI_FAIZ_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.SONRAKI_FAIZ_DOVIZ_ID.Visible = true;
            this.SONRAKI_FAIZ_DOVIZ_ID.VisibleIndex = 23;
            // 
            // ODEME_TOPLAMI
            // 
            this.ODEME_TOPLAMI.Caption = "Ödeme Toplamı";
            this.ODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            this.ODEME_TOPLAMI.Name = "ODEME_TOPLAMI";
            this.ODEME_TOPLAMI.SummaryItem.DisplayFormat = "{0:###,###,###,###,##0.00}";
            this.ODEME_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.ODEME_TOPLAMI.Visible = true;
            this.ODEME_TOPLAMI.VisibleIndex = 24;
            // 
            // ODEME_TOPLAMI_DOVIZ_ID
            // 
            this.ODEME_TOPLAMI_DOVIZ_ID.Caption = "Ödeme Toplamı Doviz Tipi";
            this.ODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            this.ODEME_TOPLAMI_DOVIZ_ID.Name = "ODEME_TOPLAMI_DOVIZ_ID";
            this.ODEME_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            this.ODEME_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.ODEME_TOPLAMI_DOVIZ_ID.Visible = true;
            this.ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 25;
            // 
            // TO_ODEME_TOPLAMI
            // 
            this.TO_ODEME_TOPLAMI.Caption = "T.Ö. Ödeme To.";
            this.TO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            this.TO_ODEME_TOPLAMI.Name = "TO_ODEME_TOPLAMI";
            this.TO_ODEME_TOPLAMI.SummaryItem.DisplayFormat = "{0:###,###,###,###,##0.00}";
            this.TO_ODEME_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.TO_ODEME_TOPLAMI.Visible = true;
            this.TO_ODEME_TOPLAMI.VisibleIndex = 26;
            // 
            // TO_ODEME_TOPLAMI_DOVIZ_ID
            // 
            this.TO_ODEME_TOPLAMI_DOVIZ_ID.Caption = "To Ödeme Döviz";
            this.TO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            this.TO_ODEME_TOPLAMI_DOVIZ_ID.Name = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            this.TO_ODEME_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            this.TO_ODEME_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.TO_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;
            this.TO_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 27;
            // 
            // KALAN
            // 
            this.KALAN.Caption = "Kalan";
            this.KALAN.FieldName = "KALAN";
            this.KALAN.Name = "KALAN";
            this.KALAN.SummaryItem.DisplayFormat = "{0:###,###,###,###,##0.00}";
            this.KALAN.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.KALAN.Visible = true;
            this.KALAN.VisibleIndex = 28;
            // 
            // KALAN_DOVIZ_ID
            // 
            this.KALAN_DOVIZ_ID.Caption = "Kalan Döviz";
            this.KALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            this.KALAN_DOVIZ_ID.Name = "KALAN_DOVIZ_ID";
            this.KALAN_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            this.KALAN_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.KALAN_DOVIZ_ID.Visible = true;
            this.KALAN_DOVIZ_ID.VisibleIndex = 29;
            // 
            // ACIKLAMA
            // 
            this.ACIKLAMA.Caption = "Açıklama";
            this.ACIKLAMA.FieldName = "ACIKLAMA";
            this.ACIKLAMA.Name = "ACIKLAMA";
            this.ACIKLAMA.Visible = true;
            this.ACIKLAMA.VisibleIndex = 30;
            // 
            // ASAMA_ID
            // 
            this.ASAMA_ID.Caption = "Aşama";
            this.ASAMA_ID.FieldName = "ASAMA_ID";
            this.ASAMA_ID.Name = "ASAMA_ID";
            this.ASAMA_ID.Visible = true;
            this.ASAMA_ID.VisibleIndex = 31;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Avukat İnt.";
            this.gridColumn12.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            this.gridColumn12.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateYear;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 600);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.vGridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Form1";
            this.Text = "Uyap";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnUyap;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.SaveFileDialog saveUyapBelgeDialog;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn FORM_ORNEK_NO;
        private DevExpress.XtraGrid.Columns.GridColumn FOY_NO;
        private DevExpress.XtraGrid.Columns.GridColumn REFERANS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn DURUM;
        private DevExpress.XtraGrid.Columns.GridColumn TAKIP_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn ADLIYE;
        private DevExpress.XtraGrid.Columns.GridColumn GOREV;
        private DevExpress.XtraGrid.Columns.GridColumn BIRIM_NO;
        private DevExpress.XtraGrid.Columns.GridColumn ESAS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn ICRA_OZEL_KOD1;
        private DevExpress.XtraGrid.Columns.GridColumn ICRA_OZEL_KOD2;
        private DevExpress.XtraGrid.Columns.GridColumn ICRA_OZEL_KOD3;
        private DevExpress.XtraGrid.Columns.GridColumn ICRA_OZEL_KOD4;
        private DevExpress.XtraGrid.Columns.GridColumn TAKIBIN_AVUKATA_INTIKAL_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn TAKIBIN_MUVEKKILE_IADE_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn ASIL_ALACAK;
        private DevExpress.XtraGrid.Columns.GridColumn ASIL_ALACAK_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn ISLEMIS_FAIZ;
        private DevExpress.XtraGrid.Columns.GridColumn ISLEMIS_FAIZ_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn TAKIP_CIKISI;
        private DevExpress.XtraGrid.Columns.GridColumn TAKIP_CIKISI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn SONRAKI_FAIZ;
        private DevExpress.XtraGrid.Columns.GridColumn SONRAKI_FAIZ_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn ODEME_TOPLAMI;
        private DevExpress.XtraGrid.Columns.GridColumn ODEME_TOPLAMI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn TO_ODEME_TOPLAMI;
        private DevExpress.XtraGrid.Columns.GridColumn TO_ODEME_TOPLAMI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn KALAN;
        private DevExpress.XtraGrid.Columns.GridColumn KALAN_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn ACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn ASAMA_ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.SimpleButton Yenile;

    }
}

