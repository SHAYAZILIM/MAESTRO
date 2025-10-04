namespace  AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    partial class ucKiymetliEvrakGrid
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
            this.multiEditorRowProperties1 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rSEKarsilikTutar = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.multiEditorRowProperties2 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rLueDovizId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.multiEditorRowProperties3 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rLueBankaId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.multiEditorRowProperties4 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rLueSubeId = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.multiEditorRowProperties5 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.multiEditorRowProperties6 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.bndKiymetliEvrak = new System.Windows.Forms.BindingSource(this.components);
            this.dataNavigatorExtended1 = new AdimAdimDavaKaydi.Util.DataNavigatorExtended();
            this.vGridKiymetliEvrak = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rLueEvrakTurId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueSoranID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueAhzolunmaSekli = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueSorulmaSonucu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rowEVRAK_TUR_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowEVRAK_KAYIT_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowEVRAK_VADE_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowEVRAK_TANZIM_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.mRowTutarDoviz = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.rowNE_SEKILDE_AHZOLUNDUGU = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.mRowBankaSube = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.rowBANKA_SUBE_KODU = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowHESAP_NO = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCEK_NO = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSORULMA_SONUCU = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.mRowKarsilikTutar = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.rowSORAN_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowARKASI_YAZILDI_MI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSERH_ACIKLAMASI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowILK_ALACAKLI_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowILK_BORCLU_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSIKAYET_EDILDI_MI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowODEME_YERI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowISLEMLER_BASLADIMI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.gcKiymetliEvrak = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gwKiymetliEvrak = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEVRAK_TUR_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueEvrakTuru = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colEVRAK_KAYIT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEVRAK_VADE_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEVRAK_TANZIM_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTUTAR_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueDovizTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colNE_SEKILDE_AHZOLUNDUGU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBANKA_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueBanka = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSUBE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueBankaSube = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.colBANKA_SUBE_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHESAP_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCEK_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSORULDUGU_TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSORULMA_SONUCU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKARSILIK_TUTAR_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKARSILIK_TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSORAN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueSoranCariID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colARKASI_YAZILDI_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSERH_ACIKLAMASI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colILK_ALACAKLI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colILK_BORCLU_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSIKAYET_EDILDI_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKESIDE_YERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_YERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISLEMLER_BASLADIMI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.rSEKarsilikTutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBankaId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSubeId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndKiymetliEvrak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridKiymetliEvrak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueEvrakTurId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSoranID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAhzolunmaSekli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSorulmaSonucu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcKiymetliEvrak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwKiymetliEvrak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueEvrakTuru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBanka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBankaSube)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSoranCariID)).BeginInit();
            this.SuspendLayout();
            // 
            // multiEditorRowProperties1
            // 
            this.multiEditorRowProperties1.Caption = "Tutar";
            this.multiEditorRowProperties1.FieldName = "TUTAR";
            this.multiEditorRowProperties1.RowEdit = this.rSEKarsilikTutar;
            // 
            // rSEKarsilikTutar
            // 
            this.rSEKarsilikTutar.AutoHeight = false;
            this.rSEKarsilikTutar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rSEKarsilikTutar.Name = "rSEKarsilikTutar";
            // 
            // multiEditorRowProperties2
            // 
            this.multiEditorRowProperties2.FieldName = "TUTAR_DOVIZ_ID";
            this.multiEditorRowProperties2.RowEdit = this.rLueDovizId;
            // 
            // rLueDovizId
            // 
            this.rLueDovizId.AutoHeight = false;
            this.rLueDovizId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDovizId.Name = "rLueDovizId";
            // 
            // multiEditorRowProperties3
            // 
            this.multiEditorRowProperties3.Caption = "Banka";
            this.multiEditorRowProperties3.FieldName = "BANKA_ID";
            this.multiEditorRowProperties3.RowEdit = this.rLueBankaId;
            // 
            // rLueBankaId
            // 
            this.rLueBankaId.AutoHeight = false;
            this.rLueBankaId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBankaId.Name = "rLueBankaId";
            // 
            // multiEditorRowProperties4
            // 
            this.multiEditorRowProperties4.Caption = "Þube";
            this.multiEditorRowProperties4.FieldName = "SUBE_ID";
            this.multiEditorRowProperties4.RowEdit = this.rLueSubeId;
            // 
            // rLueSubeId
            // 
            this.rLueSubeId.AutoHeight = false;
            this.rLueSubeId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSubeId.Name = "rLueSubeId";
            // 
            // multiEditorRowProperties5
            // 
            this.multiEditorRowProperties5.Caption = "Karþýlýk Tutar";
            this.multiEditorRowProperties5.FieldName = "KARSILIK_TUTAR";
            this.multiEditorRowProperties5.RowEdit = this.rSEKarsilikTutar;
            // 
            // multiEditorRowProperties6
            // 
            this.multiEditorRowProperties6.FieldName = "KARSILIK_TUTAR_DOVIZ_ID";
            this.multiEditorRowProperties6.RowEdit = this.rLueDovizId;
            // 
            // bndKiymetliEvrak
            // 
            this.bndKiymetliEvrak.DataSource = typeof(AvukatProLib2.Entities.AV001_TDI_BIL_KIYMETLI_EVRAK);
            // 
            // dataNavigatorExtended1
            // 
            this.dataNavigatorExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigatorExtended1.Location = new System.Drawing.Point(0, 284);
            this.dataNavigatorExtended1.MyChartControl = null;
            this.dataNavigatorExtended1.MyGridControl = null;
            this.dataNavigatorExtended1.MyPivotGridControl = null;
            this.dataNavigatorExtended1.MyVGridControl = this.vGridKiymetliEvrak;
            this.dataNavigatorExtended1.Name = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.SelectButtonVisible = false;
            this.dataNavigatorExtended1.Size = new System.Drawing.Size(812, 26);
            this.dataNavigatorExtended1.TabIndex = 3;
            this.dataNavigatorExtended1.Text = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.OnListedenGetirClick += new AdimAdimDavaKaydi.Util.ListedenGetirEventHandler(this.dataNavigatorExtended1_OnListedenGetirClick);
            // 
            // vGridKiymetliEvrak
            // 
            this.vGridKiymetliEvrak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridKiymetliEvrak.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.BandsView;
            this.vGridKiymetliEvrak.Location = new System.Drawing.Point(0, 0);
            this.vGridKiymetliEvrak.Name = "vGridKiymetliEvrak";
            this.vGridKiymetliEvrak.RecordWidth = 193;
            this.vGridKiymetliEvrak.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueEvrakTurId,
            this.rLueDovizId,
            this.rLueBankaId,
            this.rLueSubeId,
            this.rLueSoranID,
            this.rSEKarsilikTutar,
            this.rLueAhzolunmaSekli,
            this.rLueSorulmaSonucu});
            this.vGridKiymetliEvrak.RowHeaderWidth = 140;
            this.vGridKiymetliEvrak.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowEVRAK_TUR_ID,
            this.rowEVRAK_KAYIT_TARIHI,
            this.rowEVRAK_VADE_TARIHI,
            this.rowEVRAK_TANZIM_TARIHI,
            this.mRowTutarDoviz,
            this.rowNE_SEKILDE_AHZOLUNDUGU,
            this.mRowBankaSube,
            this.rowBANKA_SUBE_KODU,
            this.rowHESAP_NO,
            this.rowCEK_NO,
            this.rowSORULMA_SONUCU,
            this.mRowKarsilikTutar,
            this.rowSORAN_ID,
            this.rowARKASI_YAZILDI_MI,
            this.rowSERH_ACIKLAMASI,
            this.rowILK_ALACAKLI_ID,
            this.rowILK_BORCLU_ID,
            this.rowSIKAYET_EDILDI_MI,
            this.rowODEME_YERI,
            this.rowISLEMLER_BASLADIMI});
            this.vGridKiymetliEvrak.Size = new System.Drawing.Size(812, 310);
            this.vGridKiymetliEvrak.TabIndex = 5;
            // 
            // rLueEvrakTurId
            // 
            this.rLueEvrakTurId.AutoHeight = false;
            this.rLueEvrakTurId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueEvrakTurId.Name = "rLueEvrakTurId";
            // 
            // rLueSoranID
            // 
            this.rLueSoranID.AutoHeight = false;
            this.rLueSoranID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSoranID.Name = "rLueSoranID";
            // 
            // rLueAhzolunmaSekli
            // 
            this.rLueAhzolunmaSekli.AutoHeight = false;
            this.rLueAhzolunmaSekli.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAhzolunmaSekli.Name = "rLueAhzolunmaSekli";
            // 
            // rLueSorulmaSonucu
            // 
            this.rLueSorulmaSonucu.AutoHeight = false;
            this.rLueSorulmaSonucu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSorulmaSonucu.Name = "rLueSorulmaSonucu";
            // 
            // rowEVRAK_TUR_ID
            // 
            this.rowEVRAK_TUR_ID.Name = "rowEVRAK_TUR_ID";
            this.rowEVRAK_TUR_ID.Properties.Caption = "Evrak Türü";
            this.rowEVRAK_TUR_ID.Properties.FieldName = "EVRAK_TUR_ID";
            this.rowEVRAK_TUR_ID.Properties.RowEdit = this.rLueEvrakTurId;
            // 
            // rowEVRAK_KAYIT_TARIHI
            // 
            this.rowEVRAK_KAYIT_TARIHI.Name = "rowEVRAK_KAYIT_TARIHI";
            this.rowEVRAK_KAYIT_TARIHI.Properties.Caption = "Kayýt T";
            this.rowEVRAK_KAYIT_TARIHI.Properties.FieldName = "EVRAK_KAYIT_TARIHI";
            // 
            // rowEVRAK_VADE_TARIHI
            // 
            this.rowEVRAK_VADE_TARIHI.Height = 17;
            this.rowEVRAK_VADE_TARIHI.Name = "rowEVRAK_VADE_TARIHI";
            this.rowEVRAK_VADE_TARIHI.Properties.Caption = "Vade T";
            this.rowEVRAK_VADE_TARIHI.Properties.FieldName = "EVRAK_VADE_TARIHI";
            // 
            // rowEVRAK_TANZIM_TARIHI
            // 
            this.rowEVRAK_TANZIM_TARIHI.Name = "rowEVRAK_TANZIM_TARIHI";
            this.rowEVRAK_TANZIM_TARIHI.Properties.Caption = "Tanzim T";
            this.rowEVRAK_TANZIM_TARIHI.Properties.FieldName = "EVRAK_TANZIM_TARIHI";
            // 
            // mRowTutarDoviz
            // 
            this.mRowTutarDoviz.Name = "mRowTutarDoviz";
            this.mRowTutarDoviz.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties1,
            this.multiEditorRowProperties2});
            // 
            // rowNE_SEKILDE_AHZOLUNDUGU
            // 
            this.rowNE_SEKILDE_AHZOLUNDUGU.Height = 16;
            this.rowNE_SEKILDE_AHZOLUNDUGU.Name = "rowNE_SEKILDE_AHZOLUNDUGU";
            this.rowNE_SEKILDE_AHZOLUNDUGU.Properties.Caption = "Nasýl Ahzoldu";
            this.rowNE_SEKILDE_AHZOLUNDUGU.Properties.FieldName = "NE_SEKILDE_AHZOLUNDUGU";
            this.rowNE_SEKILDE_AHZOLUNDUGU.Properties.RowEdit = this.rLueAhzolunmaSekli;
            // 
            // mRowBankaSube
            // 
            this.mRowBankaSube.Name = "mRowBankaSube";
            this.mRowBankaSube.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties3,
            this.multiEditorRowProperties4});
            // 
            // rowBANKA_SUBE_KODU
            // 
            this.rowBANKA_SUBE_KODU.Name = "rowBANKA_SUBE_KODU";
            this.rowBANKA_SUBE_KODU.Properties.Caption = "Banka Þube Kodu";
            this.rowBANKA_SUBE_KODU.Properties.FieldName = "BANKA_SUBE_KODU";
            // 
            // rowHESAP_NO
            // 
            this.rowHESAP_NO.Name = "rowHESAP_NO";
            this.rowHESAP_NO.Properties.Caption = "Hesap No";
            this.rowHESAP_NO.Properties.FieldName = "HESAP_NO";
            // 
            // rowCEK_NO
            // 
            this.rowCEK_NO.Name = "rowCEK_NO";
            this.rowCEK_NO.Properties.Caption = "Çek No";
            this.rowCEK_NO.Properties.FieldName = "CEK_NO";
            // 
            // rowSORULMA_SONUCU
            // 
            this.rowSORULMA_SONUCU.Name = "rowSORULMA_SONUCU";
            this.rowSORULMA_SONUCU.Properties.Caption = "Sorulma Sonucu";
            this.rowSORULMA_SONUCU.Properties.FieldName = "SORULMA_SONUCU";
            this.rowSORULMA_SONUCU.Properties.RowEdit = this.rLueSorulmaSonucu;
            // 
            // mRowKarsilikTutar
            // 
            this.mRowKarsilikTutar.Name = "mRowKarsilikTutar";
            this.mRowKarsilikTutar.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            this.multiEditorRowProperties5,
            this.multiEditorRowProperties6});
            // 
            // rowSORAN_ID
            // 
            this.rowSORAN_ID.Name = "rowSORAN_ID";
            this.rowSORAN_ID.Properties.Caption = "Soran";
            this.rowSORAN_ID.Properties.FieldName = "SORAN_ID";
            this.rowSORAN_ID.Properties.RowEdit = this.rLueSoranID;
            // 
            // rowARKASI_YAZILDI_MI
            // 
            this.rowARKASI_YAZILDI_MI.Name = "rowARKASI_YAZILDI_MI";
            this.rowARKASI_YAZILDI_MI.Properties.Caption = "Arkasý Yazýldý";
            this.rowARKASI_YAZILDI_MI.Properties.FieldName = "ARKASI_YAZILDI_MI";
            // 
            // rowSERH_ACIKLAMASI
            // 
            this.rowSERH_ACIKLAMASI.Name = "rowSERH_ACIKLAMASI";
            this.rowSERH_ACIKLAMASI.Properties.Caption = "Þerh Açýklamasý";
            this.rowSERH_ACIKLAMASI.Properties.FieldName = "SERH_ACIKLAMASI";
            // 
            // rowILK_ALACAKLI_ID
            // 
            this.rowILK_ALACAKLI_ID.Name = "rowILK_ALACAKLI_ID";
            this.rowILK_ALACAKLI_ID.Properties.Caption = "Ýlk Alacaklý";
            this.rowILK_ALACAKLI_ID.Properties.FieldName = "ILK_ALACAKLI_ID";
            this.rowILK_ALACAKLI_ID.Properties.RowEdit = this.rLueSoranID;
            // 
            // rowILK_BORCLU_ID
            // 
            this.rowILK_BORCLU_ID.Name = "rowILK_BORCLU_ID";
            this.rowILK_BORCLU_ID.Properties.Caption = "Ýlk Borçlu";
            this.rowILK_BORCLU_ID.Properties.FieldName = "ILK_BORCLU_ID";
            this.rowILK_BORCLU_ID.Properties.RowEdit = this.rLueSoranID;
            // 
            // rowSIKAYET_EDILDI_MI
            // 
            this.rowSIKAYET_EDILDI_MI.Name = "rowSIKAYET_EDILDI_MI";
            this.rowSIKAYET_EDILDI_MI.Properties.Caption = "Þikayet Edildi";
            this.rowSIKAYET_EDILDI_MI.Properties.FieldName = "SIKAYET_EDILDI_MI";
            // 
            // rowODEME_YERI
            // 
            this.rowODEME_YERI.Name = "rowODEME_YERI";
            this.rowODEME_YERI.Properties.Caption = "Ödeme Yeri";
            this.rowODEME_YERI.Properties.FieldName = "ODEME_YERI";
            // 
            // rowISLEMLER_BASLADIMI
            // 
            this.rowISLEMLER_BASLADIMI.Name = "rowISLEMLER_BASLADIMI";
            this.rowISLEMLER_BASLADIMI.Properties.Caption = "Ýþlemler Baþladý";
            this.rowISLEMLER_BASLADIMI.Properties.FieldName = "ISLEMLER_BASLADIMI";
            // 
            // gcKiymetliEvrak
            // 
            this.gcKiymetliEvrak.CustomButtonlarGorunmesin = false;
            this.gcKiymetliEvrak.DataSource = this.bndKiymetliEvrak;
            this.gcKiymetliEvrak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcKiymetliEvrak.DoNotExtendEmbedNavigator = true;
            this.gcKiymetliEvrak.EmbeddedNavigator.Buttons.Append.Tag = "";
            this.gcKiymetliEvrak.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcKiymetliEvrak.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcKiymetliEvrak.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 6, true, true, "", "Form")});
            this.gcKiymetliEvrak.FilterText = null;
            this.gcKiymetliEvrak.FilterValue = null;
            this.gcKiymetliEvrak.GridlerDuzenlenebilir = true;
            this.gcKiymetliEvrak.GridsFilterControl = null;
            this.gcKiymetliEvrak.Location = new System.Drawing.Point(0, 0);
            this.gcKiymetliEvrak.MainView = this.gwKiymetliEvrak;
            this.gcKiymetliEvrak.MyGridStyle = null;
            this.gcKiymetliEvrak.Name = "gcKiymetliEvrak";
            this.gcKiymetliEvrak.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueEvrakTuru,
            this.rLueDovizTip,
            this.rLueBanka,
            this.rLueBankaSube,
            this.rLueSoranCariID});
            this.gcKiymetliEvrak.ShowRowNumbers = false;
            this.gcKiymetliEvrak.SilmeKaldirilsin = false;
            this.gcKiymetliEvrak.Size = new System.Drawing.Size(812, 310);
            this.gcKiymetliEvrak.TabIndex = 4;
            this.gcKiymetliEvrak.TemizleKaldirGorunsunmu = false;
            this.gcKiymetliEvrak.UniqueId = "ef39b9c5-517a-407f-be2b-3d006fa290a7";
            this.gcKiymetliEvrak.UseEmbeddedNavigator = true;
            this.gcKiymetliEvrak.UseHyperDragDrop = false;
            this.gcKiymetliEvrak.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwKiymetliEvrak});
            this.gcKiymetliEvrak.Visible = false;
            // 
            // gwKiymetliEvrak
            // 
            this.gwKiymetliEvrak.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEVRAK_TUR_ID,
            this.colEVRAK_KAYIT_TARIHI,
            this.colEVRAK_VADE_TARIHI,
            this.colEVRAK_TANZIM_TARIHI,
            this.colTUTAR_DOVIZ_ID,
            this.colNE_SEKILDE_AHZOLUNDUGU,
            this.colBANKA_ID,
            this.colSUBE_ID,
            this.colBANKA_SUBE_KODU,
            this.colHESAP_NO,
            this.colCEK_NO,
            this.colSORULDUGU_TARIH,
            this.colSORULMA_SONUCU,
            this.colKARSILIK_TUTAR_DOVIZ_ID,
            this.colKARSILIK_TUTAR,
            this.colSORAN_ID,
            this.colARKASI_YAZILDI_MI,
            this.colSERH_ACIKLAMASI,
            this.colILK_ALACAKLI_ID,
            this.colILK_BORCLU_ID,
            this.colSIKAYET_EDILDI_MI,
            this.colKESIDE_YERI,
            this.colODEME_YERI,
            this.colISLEMLER_BASLADIMI,
            this.gridColumn1});
            this.gwKiymetliEvrak.GridControl = this.gcKiymetliEvrak;
            this.gwKiymetliEvrak.IndicatorWidth = 20;
            this.gwKiymetliEvrak.Name = "gwKiymetliEvrak";
            this.gwKiymetliEvrak.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gwKiymetliEvrak.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gwKiymetliEvrak.OptionsView.ColumnAutoWidth = false;
            this.gwKiymetliEvrak.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gwKiymetliEvrak.OptionsView.ShowDetailButtons = false;
            // 
            // colEVRAK_TUR_ID
            // 
            this.colEVRAK_TUR_ID.Caption = "Evrak Türü";
            this.colEVRAK_TUR_ID.ColumnEdit = this.rLueEvrakTuru;
            this.colEVRAK_TUR_ID.FieldName = "EVRAK_TUR_ID";
            this.colEVRAK_TUR_ID.Name = "colEVRAK_TUR_ID";
            this.colEVRAK_TUR_ID.Visible = true;
            this.colEVRAK_TUR_ID.VisibleIndex = 0;
            // 
            // rLueEvrakTuru
            // 
            this.rLueEvrakTuru.AutoHeight = false;
            this.rLueEvrakTuru.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueEvrakTuru.Name = "rLueEvrakTuru";
            // 
            // colEVRAK_KAYIT_TARIHI
            // 
            this.colEVRAK_KAYIT_TARIHI.Caption = "Kayýt T";
            this.colEVRAK_KAYIT_TARIHI.FieldName = "EVRAK_KAYIT_TARIHI";
            this.colEVRAK_KAYIT_TARIHI.Name = "colEVRAK_KAYIT_TARIHI";
            this.colEVRAK_KAYIT_TARIHI.Visible = true;
            this.colEVRAK_KAYIT_TARIHI.VisibleIndex = 1;
            // 
            // colEVRAK_VADE_TARIHI
            // 
            this.colEVRAK_VADE_TARIHI.Caption = "Vade T";
            this.colEVRAK_VADE_TARIHI.FieldName = "EVRAK_VADE_TARIHI";
            this.colEVRAK_VADE_TARIHI.Name = "colEVRAK_VADE_TARIHI";
            this.colEVRAK_VADE_TARIHI.Visible = true;
            this.colEVRAK_VADE_TARIHI.VisibleIndex = 2;
            // 
            // colEVRAK_TANZIM_TARIHI
            // 
            this.colEVRAK_TANZIM_TARIHI.Caption = "Tanzim T";
            this.colEVRAK_TANZIM_TARIHI.FieldName = "EVRAK_TANZIM_TARIHI";
            this.colEVRAK_TANZIM_TARIHI.Name = "colEVRAK_TANZIM_TARIHI";
            this.colEVRAK_TANZIM_TARIHI.Visible = true;
            this.colEVRAK_TANZIM_TARIHI.VisibleIndex = 3;
            // 
            // colTUTAR_DOVIZ_ID
            // 
            this.colTUTAR_DOVIZ_ID.ColumnEdit = this.rLueDovizTip;
            this.colTUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
            this.colTUTAR_DOVIZ_ID.Name = "colTUTAR_DOVIZ_ID";
            this.colTUTAR_DOVIZ_ID.Visible = true;
            this.colTUTAR_DOVIZ_ID.VisibleIndex = 5;
            // 
            // rLueDovizTip
            // 
            this.rLueDovizTip.AutoHeight = false;
            this.rLueDovizTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDovizTip.Name = "rLueDovizTip";
            // 
            // colNE_SEKILDE_AHZOLUNDUGU
            // 
            this.colNE_SEKILDE_AHZOLUNDUGU.Caption = "Nasýl Ahzolundu";
            this.colNE_SEKILDE_AHZOLUNDUGU.FieldName = "NE_SEKILDE_AHZOLUNDUGU";
            this.colNE_SEKILDE_AHZOLUNDUGU.Name = "colNE_SEKILDE_AHZOLUNDUGU";
            this.colNE_SEKILDE_AHZOLUNDUGU.Visible = true;
            this.colNE_SEKILDE_AHZOLUNDUGU.VisibleIndex = 6;
            // 
            // colBANKA_ID
            // 
            this.colBANKA_ID.Caption = "Banka";
            this.colBANKA_ID.ColumnEdit = this.rLueBanka;
            this.colBANKA_ID.FieldName = "BANKA_ID";
            this.colBANKA_ID.Name = "colBANKA_ID";
            this.colBANKA_ID.Visible = true;
            this.colBANKA_ID.VisibleIndex = 7;
            // 
            // rLueBanka
            // 
            this.rLueBanka.AutoHeight = false;
            this.rLueBanka.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBanka.Name = "rLueBanka";
            // 
            // colSUBE_ID
            // 
            this.colSUBE_ID.Caption = "Þube";
            this.colSUBE_ID.ColumnEdit = this.rLueBankaSube;
            this.colSUBE_ID.FieldName = "SUBE_ID";
            this.colSUBE_ID.Name = "colSUBE_ID";
            this.colSUBE_ID.Visible = true;
            this.colSUBE_ID.VisibleIndex = 8;
            // 
            // rLueBankaSube
            // 
            this.rLueBankaSube.AutoHeight = false;
            this.rLueBankaSube.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBankaSube.Name = "rLueBankaSube";
            // 
            // colBANKA_SUBE_KODU
            // 
            this.colBANKA_SUBE_KODU.Caption = "Banka Þube Kodu";
            this.colBANKA_SUBE_KODU.FieldName = "BANKA_SUBE_KODU";
            this.colBANKA_SUBE_KODU.Name = "colBANKA_SUBE_KODU";
            this.colBANKA_SUBE_KODU.Visible = true;
            this.colBANKA_SUBE_KODU.VisibleIndex = 9;
            // 
            // colHESAP_NO
            // 
            this.colHESAP_NO.Caption = "Hesap No";
            this.colHESAP_NO.FieldName = "HESAP_NO";
            this.colHESAP_NO.Name = "colHESAP_NO";
            this.colHESAP_NO.Visible = true;
            this.colHESAP_NO.VisibleIndex = 10;
            // 
            // colCEK_NO
            // 
            this.colCEK_NO.Caption = "Çek No";
            this.colCEK_NO.FieldName = "CEK_NO";
            this.colCEK_NO.Name = "colCEK_NO";
            this.colCEK_NO.Visible = true;
            this.colCEK_NO.VisibleIndex = 11;
            // 
            // colSORULDUGU_TARIH
            // 
            this.colSORULDUGU_TARIH.Caption = "Sorulduðu T";
            this.colSORULDUGU_TARIH.FieldName = "SORULDUGU_TARIH";
            this.colSORULDUGU_TARIH.Name = "colSORULDUGU_TARIH";
            this.colSORULDUGU_TARIH.Visible = true;
            this.colSORULDUGU_TARIH.VisibleIndex = 12;
            // 
            // colSORULMA_SONUCU
            // 
            this.colSORULMA_SONUCU.Caption = "Sorulma Sonucu";
            this.colSORULMA_SONUCU.FieldName = "SORULMA_SONUCU";
            this.colSORULMA_SONUCU.Name = "colSORULMA_SONUCU";
            this.colSORULMA_SONUCU.Visible = true;
            this.colSORULMA_SONUCU.VisibleIndex = 13;
            // 
            // colKARSILIK_TUTAR_DOVIZ_ID
            // 
            this.colKARSILIK_TUTAR_DOVIZ_ID.ColumnEdit = this.rLueDovizTip;
            this.colKARSILIK_TUTAR_DOVIZ_ID.FieldName = "KARSILIK_TUTAR_DOVIZ_ID";
            this.colKARSILIK_TUTAR_DOVIZ_ID.Name = "colKARSILIK_TUTAR_DOVIZ_ID";
            this.colKARSILIK_TUTAR_DOVIZ_ID.Visible = true;
            this.colKARSILIK_TUTAR_DOVIZ_ID.VisibleIndex = 14;
            // 
            // colKARSILIK_TUTAR
            // 
            this.colKARSILIK_TUTAR.Caption = "Karþýlýk Tutarý";
            this.colKARSILIK_TUTAR.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.colKARSILIK_TUTAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKARSILIK_TUTAR.FieldName = "KARSILIK_TUTAR";
            this.colKARSILIK_TUTAR.Name = "colKARSILIK_TUTAR";
            this.colKARSILIK_TUTAR.Visible = true;
            this.colKARSILIK_TUTAR.VisibleIndex = 15;
            // 
            // colSORAN_ID
            // 
            this.colSORAN_ID.Caption = "Soran";
            this.colSORAN_ID.ColumnEdit = this.rLueSoranCariID;
            this.colSORAN_ID.FieldName = "SORAN_ID";
            this.colSORAN_ID.Name = "colSORAN_ID";
            this.colSORAN_ID.Visible = true;
            this.colSORAN_ID.VisibleIndex = 16;
            // 
            // rLueSoranCariID
            // 
            this.rLueSoranCariID.AutoHeight = false;
            this.rLueSoranCariID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSoranCariID.Name = "rLueSoranCariID";
            // 
            // colARKASI_YAZILDI_MI
            // 
            this.colARKASI_YAZILDI_MI.Caption = "Arkasý Yazýldý";
            this.colARKASI_YAZILDI_MI.FieldName = "ARKASI_YAZILDI_MI";
            this.colARKASI_YAZILDI_MI.Name = "colARKASI_YAZILDI_MI";
            this.colARKASI_YAZILDI_MI.Visible = true;
            this.colARKASI_YAZILDI_MI.VisibleIndex = 17;
            // 
            // colSERH_ACIKLAMASI
            // 
            this.colSERH_ACIKLAMASI.Caption = "Þerh Açýklamasý";
            this.colSERH_ACIKLAMASI.FieldName = "SERH_ACIKLAMASI";
            this.colSERH_ACIKLAMASI.Name = "colSERH_ACIKLAMASI";
            this.colSERH_ACIKLAMASI.Visible = true;
            this.colSERH_ACIKLAMASI.VisibleIndex = 18;
            // 
            // colILK_ALACAKLI_ID
            // 
            this.colILK_ALACAKLI_ID.Caption = "Ýlk Alacaklý";
            this.colILK_ALACAKLI_ID.ColumnEdit = this.rLueSoranCariID;
            this.colILK_ALACAKLI_ID.FieldName = "ILK_ALACAKLI_ID";
            this.colILK_ALACAKLI_ID.Name = "colILK_ALACAKLI_ID";
            this.colILK_ALACAKLI_ID.Visible = true;
            this.colILK_ALACAKLI_ID.VisibleIndex = 19;
            // 
            // colILK_BORCLU_ID
            // 
            this.colILK_BORCLU_ID.Caption = "Ýlk Borçlu";
            this.colILK_BORCLU_ID.ColumnEdit = this.rLueSoranCariID;
            this.colILK_BORCLU_ID.FieldName = "ILK_BORCLU_ID";
            this.colILK_BORCLU_ID.Name = "colILK_BORCLU_ID";
            this.colILK_BORCLU_ID.Visible = true;
            this.colILK_BORCLU_ID.VisibleIndex = 20;
            // 
            // colSIKAYET_EDILDI_MI
            // 
            this.colSIKAYET_EDILDI_MI.Caption = "Þikayet Edildi";
            this.colSIKAYET_EDILDI_MI.FieldName = "SIKAYET_EDILDI_MI";
            this.colSIKAYET_EDILDI_MI.Name = "colSIKAYET_EDILDI_MI";
            this.colSIKAYET_EDILDI_MI.Visible = true;
            this.colSIKAYET_EDILDI_MI.VisibleIndex = 21;
            // 
            // colKESIDE_YERI
            // 
            this.colKESIDE_YERI.Caption = "Keþide Yeri";
            this.colKESIDE_YERI.FieldName = "KESIDE_YERI";
            this.colKESIDE_YERI.Name = "colKESIDE_YERI";
            this.colKESIDE_YERI.Visible = true;
            this.colKESIDE_YERI.VisibleIndex = 22;
            // 
            // colODEME_YERI
            // 
            this.colODEME_YERI.Caption = "Ödeme Yeri";
            this.colODEME_YERI.FieldName = "ODEME_YERI";
            this.colODEME_YERI.Name = "colODEME_YERI";
            this.colODEME_YERI.Visible = true;
            this.colODEME_YERI.VisibleIndex = 23;
            // 
            // colISLEMLER_BASLADIMI
            // 
            this.colISLEMLER_BASLADIMI.Caption = "Ýþlemler Baþladý";
            this.colISLEMLER_BASLADIMI.FieldName = "ISLEMLER_BASLADIMI";
            this.colISLEMLER_BASLADIMI.Name = "colISLEMLER_BASLADIMI";
            this.colISLEMLER_BASLADIMI.Visible = true;
            this.colISLEMLER_BASLADIMI.VisibleIndex = 24;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tutar";
            this.gridColumn1.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "TUTAR";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            // 
            // ucKiymetliEvrakGrid
            // 
            this.Controls.Add(this.dataNavigatorExtended1);
            this.Controls.Add(this.vGridKiymetliEvrak);
            this.Controls.Add(this.gcKiymetliEvrak);
            this.Name = "ucKiymetliEvrakGrid";
            this.Size = new System.Drawing.Size(812, 310);
            ((System.ComponentModel.ISupportInitialize)(this.rSEKarsilikTutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBankaId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSubeId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndKiymetliEvrak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridKiymetliEvrak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueEvrakTurId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSoranID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAhzolunmaSekli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSorulmaSonucu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcKiymetliEvrak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwKiymetliEvrak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueEvrakTuru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBanka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBankaSube)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSoranCariID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bndKiymetliEvrak;
        private AdimAdimDavaKaydi.Util.DataNavigatorExtended dataNavigatorExtended1;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gcKiymetliEvrak;
        private DevExpress.XtraGrid.Views.Grid.GridView gwKiymetliEvrak;
        private DevExpress.XtraGrid.Columns.GridColumn colEVRAK_TUR_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueEvrakTuru;
        private DevExpress.XtraGrid.Columns.GridColumn colEVRAK_KAYIT_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colEVRAK_VADE_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colEVRAK_TANZIM_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTUTAR_DOVIZ_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDovizTip;
        private DevExpress.XtraGrid.Columns.GridColumn colNE_SEKILDE_AHZOLUNDUGU;
        private DevExpress.XtraGrid.Columns.GridColumn colBANKA_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBanka;
        private DevExpress.XtraGrid.Columns.GridColumn colSUBE_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rLueBankaSube;
        private DevExpress.XtraGrid.Columns.GridColumn colBANKA_SUBE_KODU;
        private DevExpress.XtraGrid.Columns.GridColumn colHESAP_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colCEK_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colSORULDUGU_TARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colSORULMA_SONUCU;
        private DevExpress.XtraGrid.Columns.GridColumn colKARSILIK_TUTAR_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colKARSILIK_TUTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colSORAN_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSoranCariID;
        private DevExpress.XtraGrid.Columns.GridColumn colARKASI_YAZILDI_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colSERH_ACIKLAMASI;
        private DevExpress.XtraGrid.Columns.GridColumn colILK_ALACAKLI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colILK_BORCLU_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSIKAYET_EDILDI_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colKESIDE_YERI;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_YERI;
        private DevExpress.XtraGrid.Columns.GridColumn colISLEMLER_BASLADIMI;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraVerticalGrid.VGridControl vGridKiymetliEvrak;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueEvrakTurId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDovizId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBankaId;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rLueSubeId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSoranID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowEVRAK_TUR_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowEVRAK_KAYIT_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowEVRAK_VADE_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowEVRAK_TANZIM_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowNE_SEKILDE_AHZOLUNDUGU;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowBANKA_SUBE_KODU;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHESAP_NO;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCEK_NO;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSORULMA_SONUCU;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSORAN_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowARKASI_YAZILDI_MI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSERH_ACIKLAMASI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowILK_ALACAKLI_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowILK_BORCLU_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSIKAYET_EDILDI_MI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowODEME_YERI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowISLEMLER_BASLADIMI;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rSEKarsilikTutar;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow mRowKarsilikTutar;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow mRowBankaSube;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow mRowTutarDoviz;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAhzolunmaSekli;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSorulmaSonucu;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties1;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties2;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties3;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties4;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties5;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties6;
    }
}
