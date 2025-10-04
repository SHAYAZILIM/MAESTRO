namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucFormIlamBilgileri
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gwIlamBilgisi = new DevExpress.XtraGrid.GridControl();
            this.bndIlam = new System.Windows.Forms.BindingSource(this.components);
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rLueAdliyeBirimAdliyeID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueGorevID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueDovizID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rTutar = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.txtAciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.rLueIlamTipID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIsSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colILAM_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADLI_BIRIM_ADLIYE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADLI_BIRIM_GOREV_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colESAS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKARAR_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKARAR_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKARAR_BOZULMA_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKARAR_KESINLESME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colILAM_TEBLIG_GIDERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colILAM_TEBLIG_GIDERI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYARGILAMA_GIDERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYARGILAMA_GIDERI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYARGILAMA_GIDERI_FAIZ_ISLESIN_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.COLILAM_VEKALET_UCRETI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colILAM_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colINKAR_TAZMINATI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colINKAR_TAZMINATI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colINKAR_TAZMINAT_FAIZ_ISLESIN_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colILAM_ACIKLAMASI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADLI_BIRIM_NO_I = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAdliBirimNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnIlamBilgisiSil = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lueAdliBirimNo = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpExtender1 = new AdimAdimDavaKaydi.LookUpExtender();
            this.lueIlamTipi = new DevExpress.XtraEditors.LookUpEdit();
            this.btnIlamBilgisiEkle = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl74 = new DevExpress.XtraEditors.LabelControl();
            this.rLueTebligDovizTip = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl75 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl77 = new DevExpress.XtraEditors.LabelControl();
            this.txtIlamNotu = new DevExpress.XtraEditors.MemoEdit();
            this.rLueYargilamaDoviz = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl85 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl46 = new DevExpress.XtraEditors.LabelControl();
            this.rudInkarTazminati = new DevExpress.XtraEditors.SpinEdit();
            this.rLueVekaletDoviz = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl78 = new DevExpress.XtraEditors.LabelControl();
            this.chcYargilamaFaiz = new DevExpress.XtraEditors.CheckEdit();
            this.rudVekaletUcreti = new DevExpress.XtraEditors.SpinEdit();
            this.rLueInkarDovizTip = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl84 = new DevExpress.XtraEditors.LabelControl();
            this.chcIlamTebligFaiz = new DevExpress.XtraEditors.CheckEdit();
            this.rudYargilamaGideri = new DevExpress.XtraEditors.SpinEdit();
            this.rLueMahkeme = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl80 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl83 = new DevExpress.XtraEditors.LabelControl();
            this.rudTebligGideri = new DevExpress.XtraEditors.SpinEdit();
            this.rLueGorev = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl79 = new DevExpress.XtraEditors.LabelControl();
            this.chcIlamVekaletFaiz = new DevExpress.XtraEditors.CheckEdit();
            this.dtKesinlesmeTarihi = new DevExpress.XtraEditors.DateEdit();
            this.txtEsasNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl81 = new DevExpress.XtraEditors.LabelControl();
            this.chcInkarFaiz = new DevExpress.XtraEditors.CheckEdit();
            this.dtKararBozulmaTarihi = new DevExpress.XtraEditors.DateEdit();
            this.txtKararNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl82 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl76 = new DevExpress.XtraEditors.LabelControl();
            this.dtKararTarihi = new DevExpress.XtraEditors.DateEdit();
            this.compGridDovizSummary1 = new AdimAdimDavaKaydi.Util.compGridDovizSummary(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gwIlamBilgisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndIlam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliyeBirimAdliyeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGorevID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIlamTipID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimNo)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueAdliBirimNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueIlamTipi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTebligDovizTip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlamNotu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueYargilamaDoviz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rudInkarTazminati.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueVekaletDoviz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chcYargilamaFaiz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rudVekaletUcreti.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueInkarDovizTip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chcIlamTebligFaiz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rudYargilamaGideri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMahkeme.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rudTebligGideri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGorev.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chcIlamVekaletFaiz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKesinlesmeTarihi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKesinlesmeTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEsasNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chcInkarFaiz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKararBozulmaTarihi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKararBozulmaTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKararNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKararTarihi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKararTarihi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Controls.Add(this.panel2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(655, 532);
            this.panelControl1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gwIlamBilgisi);
            this.panel1.Controls.Add(this.btnIlamBilgisiSil);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 270);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 260);
            this.panel1.TabIndex = 116;
            // 
            // gwIlamBilgisi
            // 
            this.gwIlamBilgisi.DataSource = this.bndIlam;
            this.gwIlamBilgisi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gwIlamBilgisi.ExternalRepository = this.MyRepository;
            this.gwIlamBilgisi.Location = new System.Drawing.Point(0, 0);
            this.gwIlamBilgisi.MainView = this.gridView1;
            this.gwIlamBilgisi.Name = "gwIlamBilgisi";
            this.gwIlamBilgisi.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueAdliBirimNo});
            this.gwIlamBilgisi.Size = new System.Drawing.Size(651, 237);
            this.gwIlamBilgisi.TabIndex = 112;
            this.gwIlamBilgisi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bndIlam
            // 
            this.bndIlam.DataSource = typeof(AvukatProLib2.Entities.AV001_TI_BIL_ILAM_MAHKEMESI);
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueAdliyeBirimAdliyeID,
            this.rLueGorevID,
            this.rLueDovizID,
            this.rTutar,
            this.txtAciklama,
            this.rLueIlamTipID});
            // 
            // rLueAdliyeBirimAdliyeID
            // 
            this.rLueAdliyeBirimAdliyeID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliyeBirimAdliyeID.Name = "rLueAdliyeBirimAdliyeID";
            // 
            // rLueGorevID
            // 
            this.rLueGorevID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueGorevID.Name = "rLueGorevID";
            // 
            // rLueDovizID
            // 
            this.rLueDovizID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDovizID.Name = "rLueDovizID";
            // 
            // rTutar
            // 
            this.rTutar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rTutar.Name = "rTutar";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtAciklama.Name = "txtAciklama";
            // 
            // rLueIlamTipID
            // 
            this.rLueIlamTipID.AutoHeight = false;
            this.rLueIlamTipID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueIlamTipID.Name = "rLueIlamTipID";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsSelected,
            this.colILAM_TIP,
            this.colADLI_BIRIM_ADLIYE_ID,
            this.colADLI_BIRIM_GOREV_ID,
            this.colESAS_NO,
            this.colKARAR_NO,
            this.colKARAR_TARIHI,
            this.colKARAR_BOZULMA_TARIHI,
            this.colKARAR_KESINLESME_TARIHI,
            this.colILAM_TEBLIG_GIDERI,
            this.colILAM_TEBLIG_GIDERI_DOVIZ_ID,
            this.colILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI,
            this.colYARGILAMA_GIDERI,
            this.colYARGILAMA_GIDERI_DOVIZ_ID,
            this.colYARGILAMA_GIDERI_FAIZ_ISLESIN_MI,
            this.COLILAM_VEKALET_UCRETI,
            this.colILAM_VEKALET_UCRETI_DOVIZ_ID,
            this.colILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI,
            this.colINKAR_TAZMINATI,
            this.colINKAR_TAZMINATI_DOVIZ_ID,
            this.colINKAR_TAZMINAT_FAIZ_ISLESIN_MI,
            this.colILAM_ACIKLAMASI,
            this.colADLI_BIRIM_NO_I});
            this.gridView1.GridControl = this.gwIlamBilgisi;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_TEBLIG_GIDERI", this.colILAM_TEBLIG_GIDERI, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_TEBLIG_GIDERI_DOVIZ_ID", this.colILAM_TEBLIG_GIDERI_DOVIZ_ID, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "YARGILAMA_GIDERI", this.colYARGILAMA_GIDERI, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "YARGILAMA_GIDERI_DOVIZ_ID", this.colYARGILAMA_GIDERI_DOVIZ_ID, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_VEKALET_UCRETI", this.COLILAM_VEKALET_UCRETI, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_VEKALET_UCRETI_DOVIZ_ID", this.colILAM_VEKALET_UCRETI_DOVIZ_ID, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "INKAR_TAZMINATI", this.colINKAR_TAZMINATI, "{0:###,###,###,###,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "INKAR_TAZMINATI_DOVIZ_ID", this.colINKAR_TAZMINATI_DOVIZ_ID, "{0}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colIsSelected
            // 
            this.colIsSelected.Caption = "Seç";
            this.colIsSelected.FieldName = "IsSelected";
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.Visible = true;
            this.colIsSelected.VisibleIndex = 0;
            this.colIsSelected.Width = 58;
            // 
            // colILAM_TIP
            // 
            this.colILAM_TIP.Caption = "Ýlam Tipi";
            this.colILAM_TIP.ColumnEdit = this.rLueIlamTipID;
            this.colILAM_TIP.FieldName = "ILAM_TIP_ID";
            this.colILAM_TIP.Name = "colILAM_TIP";
            this.colILAM_TIP.Visible = true;
            this.colILAM_TIP.VisibleIndex = 1;
            this.colILAM_TIP.Width = 103;
            // 
            // colADLI_BIRIM_ADLIYE_ID
            // 
            this.colADLI_BIRIM_ADLIYE_ID.Caption = "Mahkeme";
            this.colADLI_BIRIM_ADLIYE_ID.ColumnEdit = this.rLueAdliyeBirimAdliyeID;
            this.colADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.colADLI_BIRIM_ADLIYE_ID.Name = "colADLI_BIRIM_ADLIYE_ID";
            this.colADLI_BIRIM_ADLIYE_ID.Visible = true;
            this.colADLI_BIRIM_ADLIYE_ID.VisibleIndex = 2;
            this.colADLI_BIRIM_ADLIYE_ID.Width = 92;
            // 
            // colADLI_BIRIM_GOREV_ID
            // 
            this.colADLI_BIRIM_GOREV_ID.Caption = "Görev";
            this.colADLI_BIRIM_GOREV_ID.ColumnEdit = this.rLueGorevID;
            this.colADLI_BIRIM_GOREV_ID.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.colADLI_BIRIM_GOREV_ID.Name = "colADLI_BIRIM_GOREV_ID";
            this.colADLI_BIRIM_GOREV_ID.Visible = true;
            this.colADLI_BIRIM_GOREV_ID.VisibleIndex = 3;
            this.colADLI_BIRIM_GOREV_ID.Width = 85;
            // 
            // colESAS_NO
            // 
            this.colESAS_NO.Caption = "Esas No";
            this.colESAS_NO.FieldName = "ESAS_NO";
            this.colESAS_NO.Name = "colESAS_NO";
            this.colESAS_NO.Visible = true;
            this.colESAS_NO.VisibleIndex = 4;
            this.colESAS_NO.Width = 95;
            // 
            // colKARAR_NO
            // 
            this.colKARAR_NO.Caption = "Karar No";
            this.colKARAR_NO.FieldName = "KARAR_NO";
            this.colKARAR_NO.Name = "colKARAR_NO";
            this.colKARAR_NO.Visible = true;
            this.colKARAR_NO.VisibleIndex = 5;
            this.colKARAR_NO.Width = 104;
            // 
            // colKARAR_TARIHI
            // 
            this.colKARAR_TARIHI.Caption = "Karar Tarihi";
            this.colKARAR_TARIHI.FieldName = "KARAR_TARIHI";
            this.colKARAR_TARIHI.Name = "colKARAR_TARIHI";
            this.colKARAR_TARIHI.Visible = true;
            this.colKARAR_TARIHI.VisibleIndex = 6;
            this.colKARAR_TARIHI.Width = 93;
            // 
            // colKARAR_BOZULMA_TARIHI
            // 
            this.colKARAR_BOZULMA_TARIHI.Caption = "Bozulma Tarihi";
            this.colKARAR_BOZULMA_TARIHI.FieldName = "KARAR_BOZULMA_TARIHI";
            this.colKARAR_BOZULMA_TARIHI.Name = "colKARAR_BOZULMA_TARIHI";
            this.colKARAR_BOZULMA_TARIHI.Visible = true;
            this.colKARAR_BOZULMA_TARIHI.VisibleIndex = 7;
            this.colKARAR_BOZULMA_TARIHI.Width = 118;
            // 
            // colKARAR_KESINLESME_TARIHI
            // 
            this.colKARAR_KESINLESME_TARIHI.Caption = "Kesinleþme Tarihi";
            this.colKARAR_KESINLESME_TARIHI.FieldName = "KARAR_KESINLESME_TARIHI";
            this.colKARAR_KESINLESME_TARIHI.Name = "colKARAR_KESINLESME_TARIHI";
            this.colKARAR_KESINLESME_TARIHI.Visible = true;
            this.colKARAR_KESINLESME_TARIHI.VisibleIndex = 8;
            this.colKARAR_KESINLESME_TARIHI.Width = 119;
            // 
            // colILAM_TEBLIG_GIDERI
            // 
            this.colILAM_TEBLIG_GIDERI.Caption = "Ýlam Teblið Gideri";
            this.colILAM_TEBLIG_GIDERI.ColumnEdit = this.rTutar;
            this.colILAM_TEBLIG_GIDERI.FieldName = "ILAM_TEBLIG_GIDERI";
            this.colILAM_TEBLIG_GIDERI.Name = "colILAM_TEBLIG_GIDERI";
            this.colILAM_TEBLIG_GIDERI.SummaryItem.DisplayFormat = "{0:###,###,###,###,##0.00}";
            this.colILAM_TEBLIG_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.colILAM_TEBLIG_GIDERI.ToolTip = "Toplam";
            this.colILAM_TEBLIG_GIDERI.Visible = true;
            this.colILAM_TEBLIG_GIDERI.VisibleIndex = 9;
            this.colILAM_TEBLIG_GIDERI.Width = 133;
            // 
            // colILAM_TEBLIG_GIDERI_DOVIZ_ID
            // 
            this.colILAM_TEBLIG_GIDERI_DOVIZ_ID.ColumnEdit = this.rLueDovizID;
            this.colILAM_TEBLIG_GIDERI_DOVIZ_ID.FieldName = "ILAM_TEBLIG_GIDERI_DOVIZ_ID";
            this.colILAM_TEBLIG_GIDERI_DOVIZ_ID.Name = "colILAM_TEBLIG_GIDERI_DOVIZ_ID";
            this.colILAM_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            this.colILAM_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.colILAM_TEBLIG_GIDERI_DOVIZ_ID.Visible = true;
            this.colILAM_TEBLIG_GIDERI_DOVIZ_ID.VisibleIndex = 10;
            this.colILAM_TEBLIG_GIDERI_DOVIZ_ID.Width = 74;
            // 
            // colILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI
            // 
            this.colILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI.Caption = "Faiz Ýþlensin mi";
            this.colILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI.FieldName = "ILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI";
            this.colILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI.Name = "colILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI";
            this.colILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI.Visible = true;
            this.colILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI.VisibleIndex = 11;
            this.colILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI.Width = 112;
            // 
            // colYARGILAMA_GIDERI
            // 
            this.colYARGILAMA_GIDERI.Caption = "Yargýlama Gideri";
            this.colYARGILAMA_GIDERI.ColumnEdit = this.rTutar;
            this.colYARGILAMA_GIDERI.FieldName = "YARGILAMA_GIDERI";
            this.colYARGILAMA_GIDERI.Name = "colYARGILAMA_GIDERI";
            this.colYARGILAMA_GIDERI.SummaryItem.DisplayFormat = "{0:###,###,###,###,##0.00}";
            this.colYARGILAMA_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.colYARGILAMA_GIDERI.ToolTip = "Toplam";
            this.colYARGILAMA_GIDERI.Visible = true;
            this.colYARGILAMA_GIDERI.VisibleIndex = 12;
            this.colYARGILAMA_GIDERI.Width = 106;
            // 
            // colYARGILAMA_GIDERI_DOVIZ_ID
            // 
            this.colYARGILAMA_GIDERI_DOVIZ_ID.ColumnEdit = this.rLueDovizID;
            this.colYARGILAMA_GIDERI_DOVIZ_ID.FieldName = "YARGILAMA_GIDERI_DOVIZ_ID";
            this.colYARGILAMA_GIDERI_DOVIZ_ID.Name = "colYARGILAMA_GIDERI_DOVIZ_ID";
            this.colYARGILAMA_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            this.colYARGILAMA_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.colYARGILAMA_GIDERI_DOVIZ_ID.Visible = true;
            this.colYARGILAMA_GIDERI_DOVIZ_ID.VisibleIndex = 13;
            // 
            // colYARGILAMA_GIDERI_FAIZ_ISLESIN_MI
            // 
            this.colYARGILAMA_GIDERI_FAIZ_ISLESIN_MI.Caption = "Yargýlama Gideri Faiz Ýþlensin mi";
            this.colYARGILAMA_GIDERI_FAIZ_ISLESIN_MI.FieldName = "YARGILAMA_GIDERI_FAIZ_ISLESIN_MI";
            this.colYARGILAMA_GIDERI_FAIZ_ISLESIN_MI.Name = "colYARGILAMA_GIDERI_FAIZ_ISLESIN_MI";
            this.colYARGILAMA_GIDERI_FAIZ_ISLESIN_MI.Visible = true;
            this.colYARGILAMA_GIDERI_FAIZ_ISLESIN_MI.VisibleIndex = 14;
            this.colYARGILAMA_GIDERI_FAIZ_ISLESIN_MI.Width = 172;
            // 
            // COLILAM_VEKALET_UCRETI
            // 
            this.COLILAM_VEKALET_UCRETI.Caption = "Ýlam Vekalet Ücreti";
            this.COLILAM_VEKALET_UCRETI.ColumnEdit = this.rTutar;
            this.COLILAM_VEKALET_UCRETI.FieldName = "ILAM_VEKALET_UCRETI";
            this.COLILAM_VEKALET_UCRETI.Name = "COLILAM_VEKALET_UCRETI";
            this.COLILAM_VEKALET_UCRETI.SummaryItem.DisplayFormat = "{0:###,###,###,###,##0.00}";
            this.COLILAM_VEKALET_UCRETI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.COLILAM_VEKALET_UCRETI.ToolTip = "Toplam";
            this.COLILAM_VEKALET_UCRETI.Visible = true;
            this.COLILAM_VEKALET_UCRETI.VisibleIndex = 15;
            this.COLILAM_VEKALET_UCRETI.Width = 111;
            // 
            // colILAM_VEKALET_UCRETI_DOVIZ_ID
            // 
            this.colILAM_VEKALET_UCRETI_DOVIZ_ID.Caption = "ILAM_VEKALET_UCRETI_DOVIZ_ID";
            this.colILAM_VEKALET_UCRETI_DOVIZ_ID.ColumnEdit = this.rLueDovizID;
            this.colILAM_VEKALET_UCRETI_DOVIZ_ID.FieldName = "ILAM_VEKALET_UCRETI_DOVIZ_ID";
            this.colILAM_VEKALET_UCRETI_DOVIZ_ID.Name = "colILAM_VEKALET_UCRETI_DOVIZ_ID";
            this.colILAM_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            this.colILAM_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.colILAM_VEKALET_UCRETI_DOVIZ_ID.Visible = true;
            this.colILAM_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 16;
            this.colILAM_VEKALET_UCRETI_DOVIZ_ID.Width = 38;
            // 
            // colILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI
            // 
            this.colILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI.Caption = "Ýlam Vekalet Ücreti Faiz Ýþlensin mi";
            this.colILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI.FieldName = "ILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI";
            this.colILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI.Name = "colILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI";
            this.colILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI.Visible = true;
            this.colILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI.VisibleIndex = 17;
            this.colILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI.Width = 185;
            // 
            // colINKAR_TAZMINATI
            // 
            this.colINKAR_TAZMINATI.Caption = "Ýnkar Tazminatý";
            this.colINKAR_TAZMINATI.ColumnEdit = this.rTutar;
            this.colINKAR_TAZMINATI.FieldName = "INKAR_TAZMINATI";
            this.colINKAR_TAZMINATI.Name = "colINKAR_TAZMINATI";
            this.colINKAR_TAZMINATI.SummaryItem.DisplayFormat = "{0:###,###,###,###,##0.00}";
            this.colINKAR_TAZMINATI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.colINKAR_TAZMINATI.ToolTip = "Toplam";
            this.colINKAR_TAZMINATI.Visible = true;
            this.colINKAR_TAZMINATI.VisibleIndex = 18;
            this.colINKAR_TAZMINATI.Width = 95;
            // 
            // colINKAR_TAZMINATI_DOVIZ_ID
            // 
            this.colINKAR_TAZMINATI_DOVIZ_ID.ColumnEdit = this.rLueDovizID;
            this.colINKAR_TAZMINATI_DOVIZ_ID.FieldName = "INKAR_TAZMINATI_DOVIZ_ID";
            this.colINKAR_TAZMINATI_DOVIZ_ID.Name = "colINKAR_TAZMINATI_DOVIZ_ID";
            this.colINKAR_TAZMINATI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            this.colINKAR_TAZMINATI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            this.colINKAR_TAZMINATI_DOVIZ_ID.Visible = true;
            this.colINKAR_TAZMINATI_DOVIZ_ID.VisibleIndex = 19;
            this.colINKAR_TAZMINATI_DOVIZ_ID.Width = 38;
            // 
            // colINKAR_TAZMINAT_FAIZ_ISLESIN_MI
            // 
            this.colINKAR_TAZMINAT_FAIZ_ISLESIN_MI.Caption = "Ýnkar Tazminatý Faiz Ýþlensin mi";
            this.colINKAR_TAZMINAT_FAIZ_ISLESIN_MI.FieldName = "INKAR_TAZMINAT_FAIZ_ISLESIN_MI";
            this.colINKAR_TAZMINAT_FAIZ_ISLESIN_MI.Name = "colINKAR_TAZMINAT_FAIZ_ISLESIN_MI";
            this.colINKAR_TAZMINAT_FAIZ_ISLESIN_MI.Visible = true;
            this.colINKAR_TAZMINAT_FAIZ_ISLESIN_MI.VisibleIndex = 20;
            this.colINKAR_TAZMINAT_FAIZ_ISLESIN_MI.Width = 169;
            // 
            // colILAM_ACIKLAMASI
            // 
            this.colILAM_ACIKLAMASI.Caption = "Açýklama";
            this.colILAM_ACIKLAMASI.FieldName = "ILAM_ACIKLAMASI";
            this.colILAM_ACIKLAMASI.Name = "colILAM_ACIKLAMASI";
            this.colILAM_ACIKLAMASI.Visible = true;
            this.colILAM_ACIKLAMASI.VisibleIndex = 21;
            this.colILAM_ACIKLAMASI.Width = 20;
            // 
            // colADLI_BIRIM_NO_I
            // 
            this.colADLI_BIRIM_NO_I.Caption = "Adli Birim No";
            this.colADLI_BIRIM_NO_I.ColumnEdit = this.rLueAdliBirimNo;
            this.colADLI_BIRIM_NO_I.FieldName = "ADLI_BIRIM_NO_I";
            this.colADLI_BIRIM_NO_I.Name = "colADLI_BIRIM_NO_I";
            this.colADLI_BIRIM_NO_I.Visible = true;
            this.colADLI_BIRIM_NO_I.VisibleIndex = 22;
            // 
            // rLueAdliBirimNo
            // 
            this.rLueAdliBirimNo.AutoHeight = false;
            this.rLueAdliBirimNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliBirimNo.Name = "rLueAdliBirimNo";
            // 
            // btnIlamBilgisiSil
            // 
            this.btnIlamBilgisiSil.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnIlamBilgisiSil.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnIlamBilgisiSil.Location = new System.Drawing.Point(0, 237);
            this.btnIlamBilgisiSil.Name = "btnIlamBilgisiSil";
            this.btnIlamBilgisiSil.Size = new System.Drawing.Size(651, 23);
            this.btnIlamBilgisiSil.TabIndex = 113;
            this.btnIlamBilgisiSil.Text = "Seçili Bilgileri Sil";
            this.btnIlamBilgisiSil.Click += new System.EventHandler(this.btnIlamBilgisiSil_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lueAdliBirimNo);
            this.panel2.Controls.Add(this.lookUpExtender1);
            this.panel2.Controls.Add(this.lueIlamTipi);
            this.panel2.Controls.Add(this.btnIlamBilgisiEkle);
            this.panel2.Controls.Add(this.labelControl74);
            this.panel2.Controls.Add(this.rLueTebligDovizTip);
            this.panel2.Controls.Add(this.labelControl75);
            this.panel2.Controls.Add(this.labelControl77);
            this.panel2.Controls.Add(this.txtIlamNotu);
            this.panel2.Controls.Add(this.rLueYargilamaDoviz);
            this.panel2.Controls.Add(this.labelControl85);
            this.panel2.Controls.Add(this.labelControl46);
            this.panel2.Controls.Add(this.rudInkarTazminati);
            this.panel2.Controls.Add(this.rLueVekaletDoviz);
            this.panel2.Controls.Add(this.labelControl78);
            this.panel2.Controls.Add(this.chcYargilamaFaiz);
            this.panel2.Controls.Add(this.rudVekaletUcreti);
            this.panel2.Controls.Add(this.rLueInkarDovizTip);
            this.panel2.Controls.Add(this.labelControl84);
            this.panel2.Controls.Add(this.chcIlamTebligFaiz);
            this.panel2.Controls.Add(this.rudYargilamaGideri);
            this.panel2.Controls.Add(this.rLueMahkeme);
            this.panel2.Controls.Add(this.labelControl80);
            this.panel2.Controls.Add(this.labelControl83);
            this.panel2.Controls.Add(this.rudTebligGideri);
            this.panel2.Controls.Add(this.rLueGorev);
            this.panel2.Controls.Add(this.labelControl79);
            this.panel2.Controls.Add(this.chcIlamVekaletFaiz);
            this.panel2.Controls.Add(this.dtKesinlesmeTarihi);
            this.panel2.Controls.Add(this.txtEsasNo);
            this.panel2.Controls.Add(this.labelControl81);
            this.panel2.Controls.Add(this.chcInkarFaiz);
            this.panel2.Controls.Add(this.dtKararBozulmaTarihi);
            this.panel2.Controls.Add(this.txtKararNo);
            this.panel2.Controls.Add(this.labelControl82);
            this.panel2.Controls.Add(this.labelControl76);
            this.panel2.Controls.Add(this.dtKararTarihi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(651, 268);
            this.panel2.TabIndex = 115;
            // 
            // lueAdliBirimNo
            // 
            this.lueAdliBirimNo.Location = new System.Drawing.Point(91, 62);
            this.lueAdliBirimNo.Name = "lueAdliBirimNo";
            this.lueAdliBirimNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAdliBirimNo.Properties.NullText = "Seç";
            this.lueAdliBirimNo.Size = new System.Drawing.Size(72, 20);
            this.lueAdliBirimNo.TabIndex = 116;
            // 
            // lookUpExtender1
            // 
            this.lookUpExtender1.AddLookUp = null;
            this.lookUpExtender1.AddRepoLookUp = null;
            this.lookUpExtender1.Location = new System.Drawing.Point(85, 239);
            this.lookUpExtender1.LookUpEditCollection = new DevExpress.XtraEditors.LookUpEdit[] {
        this.lueIlamTipi};
            this.lookUpExtender1.Name = "lookUpExtender1";
            this.lookUpExtender1.RemoveLookUp = null;
            this.lookUpExtender1.RemoveRepoLookUp = null;
            this.lookUpExtender1.RepoLookUpEditCollection = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit[0];
            this.lookUpExtender1.Size = new System.Drawing.Size(75, 23);
            this.lookUpExtender1.TabIndex = 115;
            this.lookUpExtender1.Text = "lookUpExtender1";
            this.lookUpExtender1.Visible = false;
            this.lookUpExtender1.OnClickOrProcessNewValue += new AdimAdimDavaKaydi.LookUpExtenderEventHandler(this.lookUpExtender1_OnClickOrProcessNewValue);
            // 
            // lueIlamTipi
            // 
            this.lueIlamTipi.Location = new System.Drawing.Point(88, 11);
            this.lueIlamTipi.Name = "lueIlamTipi";
            this.lueIlamTipi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lueIlamTipi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "Ekle", "mEkle")});
            this.lueIlamTipi.Properties.NullText = "Seç";
            this.lueIlamTipi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueIlamTipi.Size = new System.Drawing.Size(155, 20);
            this.lueIlamTipi.TabIndex = 114;
            // 
            // btnIlamBilgisiEkle
            // 
            this.btnIlamBilgisiEkle.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnIlamBilgisiEkle.Location = new System.Drawing.Point(203, 234);
            this.btnIlamBilgisiEkle.Name = "btnIlamBilgisiEkle";
            this.btnIlamBilgisiEkle.Size = new System.Drawing.Size(444, 23);
            this.btnIlamBilgisiEkle.TabIndex = 112;
            this.btnIlamBilgisiEkle.Text = "Listeye Ekle";
            this.btnIlamBilgisiEkle.Click += new System.EventHandler(this.btnIlamBilgisiEkle_Click);
            // 
            // labelControl74
            // 
            this.labelControl74.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl74.Appearance.Options.UseFont = true;
            this.labelControl74.Location = new System.Drawing.Point(21, 13);
            this.labelControl74.Name = "labelControl74";
            this.labelControl74.Size = new System.Drawing.Size(63, 14);
            this.labelControl74.TabIndex = 80;
            this.labelControl74.Text = "Ýlam Tipi:";
            // 
            // rLueTebligDovizTip
            // 
            this.rLueTebligDovizTip.Location = new System.Drawing.Point(496, 9);
            this.rLueTebligDovizTip.Name = "rLueTebligDovizTip";
            this.rLueTebligDovizTip.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueTebligDovizTip.Properties.NullText = "Seç";
            this.rLueTebligDovizTip.Size = new System.Drawing.Size(62, 20);
            this.rLueTebligDovizTip.TabIndex = 95;
            // 
            // labelControl75
            // 
            this.labelControl75.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl75.Appearance.Options.UseFont = true;
            this.labelControl75.Location = new System.Drawing.Point(5, 38);
            this.labelControl75.Name = "labelControl75";
            this.labelControl75.Size = new System.Drawing.Size(79, 14);
            this.labelControl75.TabIndex = 79;
            this.labelControl75.Text = "Mahkemesi:";
            // 
            // labelControl77
            // 
            this.labelControl77.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl77.Appearance.Options.UseFont = true;
            this.labelControl77.Location = new System.Drawing.Point(6, 65);
            this.labelControl77.Name = "labelControl77";
            this.labelControl77.Size = new System.Drawing.Size(79, 14);
            this.labelControl77.TabIndex = 78;
            this.labelControl77.Text = "No / Görev:";
            // 
            // txtIlamNotu
            // 
            this.txtIlamNotu.Location = new System.Drawing.Point(203, 143);
            this.txtIlamNotu.Name = "txtIlamNotu";
            this.txtIlamNotu.Size = new System.Drawing.Size(444, 89);
            this.txtIlamNotu.TabIndex = 111;
            // 
            // rLueYargilamaDoviz
            // 
            this.rLueYargilamaDoviz.Location = new System.Drawing.Point(496, 37);
            this.rLueYargilamaDoviz.Name = "rLueYargilamaDoviz";
            this.rLueYargilamaDoviz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueYargilamaDoviz.Properties.NullText = "Seç";
            this.rLueYargilamaDoviz.Size = new System.Drawing.Size(62, 20);
            this.rLueYargilamaDoviz.TabIndex = 97;
            // 
            // labelControl85
            // 
            this.labelControl85.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl85.Appearance.Options.UseFont = true;
            this.labelControl85.Location = new System.Drawing.Point(261, 12);
            this.labelControl85.Name = "labelControl85";
            this.labelControl85.Size = new System.Drawing.Size(123, 14);
            this.labelControl85.TabIndex = 87;
            this.labelControl85.Text = "Ýlam Teblið Gideri:";
            // 
            // labelControl46
            // 
            this.labelControl46.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl46.Appearance.Options.UseFont = true;
            this.labelControl46.Location = new System.Drawing.Point(203, 123);
            this.labelControl46.Name = "labelControl46";
            this.labelControl46.Size = new System.Drawing.Size(70, 14);
            this.labelControl46.TabIndex = 86;
            this.labelControl46.Text = "Ýlam Notu:";
            // 
            // rudInkarTazminati
            // 
            this.rudInkarTazminati.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.rudInkarTazminati.Location = new System.Drawing.Point(390, 89);
            this.rudInkarTazminati.Name = "rudInkarTazminati";
            this.rudInkarTazminati.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rudInkarTazminati.Size = new System.Drawing.Size(100, 20);
            this.rudInkarTazminati.TabIndex = 107;
            // 
            // rLueVekaletDoviz
            // 
            this.rLueVekaletDoviz.Location = new System.Drawing.Point(496, 63);
            this.rLueVekaletDoviz.Name = "rLueVekaletDoviz";
            this.rLueVekaletDoviz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueVekaletDoviz.Properties.NullText = "Seç";
            this.rLueVekaletDoviz.Size = new System.Drawing.Size(62, 20);
            this.rLueVekaletDoviz.TabIndex = 96;
            // 
            // labelControl78
            // 
            this.labelControl78.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl78.Appearance.Options.UseFont = true;
            this.labelControl78.Location = new System.Drawing.Point(21, 119);
            this.labelControl78.Name = "labelControl78";
            this.labelControl78.Size = new System.Drawing.Size(64, 14);
            this.labelControl78.TabIndex = 81;
            this.labelControl78.Text = "Karar No:";
            // 
            // chcYargilamaFaiz
            // 
            this.chcYargilamaFaiz.Location = new System.Drawing.Point(562, 37);
            this.chcYargilamaFaiz.Name = "chcYargilamaFaiz";
            this.chcYargilamaFaiz.Properties.Caption = "Faiz Ýþlesin";
            this.chcYargilamaFaiz.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.chcYargilamaFaiz.Size = new System.Drawing.Size(85, 19);
            this.chcYargilamaFaiz.TabIndex = 94;
            // 
            // rudVekaletUcreti
            // 
            this.rudVekaletUcreti.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.rudVekaletUcreti.Location = new System.Drawing.Point(390, 63);
            this.rudVekaletUcreti.Name = "rudVekaletUcreti";
            this.rudVekaletUcreti.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rudVekaletUcreti.Size = new System.Drawing.Size(100, 20);
            this.rudVekaletUcreti.TabIndex = 110;
            // 
            // rLueInkarDovizTip
            // 
            this.rLueInkarDovizTip.Location = new System.Drawing.Point(496, 89);
            this.rLueInkarDovizTip.Name = "rLueInkarDovizTip";
            this.rLueInkarDovizTip.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueInkarDovizTip.Properties.NullText = "Seç";
            this.rLueInkarDovizTip.Size = new System.Drawing.Size(62, 20);
            this.rLueInkarDovizTip.TabIndex = 98;
            // 
            // labelControl84
            // 
            this.labelControl84.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl84.Appearance.Options.UseFont = true;
            this.labelControl84.Location = new System.Drawing.Point(251, 69);
            this.labelControl84.Name = "labelControl84";
            this.labelControl84.Size = new System.Drawing.Size(133, 14);
            this.labelControl84.TabIndex = 89;
            this.labelControl84.Text = "Ýlam Vekalet Ücreti:";
            // 
            // chcIlamTebligFaiz
            // 
            this.chcIlamTebligFaiz.Location = new System.Drawing.Point(562, 10);
            this.chcIlamTebligFaiz.Name = "chcIlamTebligFaiz";
            this.chcIlamTebligFaiz.Properties.Caption = "Faiz Ýþlesin";
            this.chcIlamTebligFaiz.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.chcIlamTebligFaiz.Size = new System.Drawing.Size(85, 19);
            this.chcIlamTebligFaiz.TabIndex = 92;
            // 
            // rudYargilamaGideri
            // 
            this.rudYargilamaGideri.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.rudYargilamaGideri.Location = new System.Drawing.Point(390, 36);
            this.rudYargilamaGideri.Name = "rudYargilamaGideri";
            this.rudYargilamaGideri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rudYargilamaGideri.Size = new System.Drawing.Size(100, 20);
            this.rudYargilamaGideri.TabIndex = 109;
            // 
            // rLueMahkeme
            // 
            this.rLueMahkeme.Location = new System.Drawing.Point(88, 36);
            this.rLueMahkeme.Name = "rLueMahkeme";
            this.rLueMahkeme.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMahkeme.Properties.NullText = "Seç";
            this.rLueMahkeme.Size = new System.Drawing.Size(155, 20);
            this.rLueMahkeme.TabIndex = 99;
            // 
            // labelControl80
            // 
            this.labelControl80.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl80.Appearance.Options.UseFont = true;
            this.labelControl80.Location = new System.Drawing.Point(32, 151);
            this.labelControl80.Name = "labelControl80";
            this.labelControl80.Size = new System.Drawing.Size(53, 14);
            this.labelControl80.TabIndex = 83;
            this.labelControl80.Text = "Karar T.";
            // 
            // labelControl83
            // 
            this.labelControl83.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl83.Appearance.Options.UseFont = true;
            this.labelControl83.Location = new System.Drawing.Point(267, 41);
            this.labelControl83.Name = "labelControl83";
            this.labelControl83.Size = new System.Drawing.Size(117, 14);
            this.labelControl83.TabIndex = 88;
            this.labelControl83.Text = "Yargýlama Gideri:";
            // 
            // rudTebligGideri
            // 
            this.rudTebligGideri.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.rudTebligGideri.Location = new System.Drawing.Point(390, 9);
            this.rudTebligGideri.Name = "rudTebligGideri";
            this.rudTebligGideri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rudTebligGideri.Size = new System.Drawing.Size(100, 20);
            this.rudTebligGideri.TabIndex = 108;
            // 
            // rLueGorev
            // 
            this.rLueGorev.Location = new System.Drawing.Point(169, 62);
            this.rLueGorev.Name = "rLueGorev";
            this.rLueGorev.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueGorev.Properties.NullText = "Seç";
            this.rLueGorev.Size = new System.Drawing.Size(72, 20);
            this.rLueGorev.TabIndex = 100;
            // 
            // labelControl79
            // 
            this.labelControl79.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl79.Appearance.Options.UseFont = true;
            this.labelControl79.Location = new System.Drawing.Point(27, 91);
            this.labelControl79.Name = "labelControl79";
            this.labelControl79.Size = new System.Drawing.Size(57, 14);
            this.labelControl79.TabIndex = 82;
            this.labelControl79.Text = "Esas No:";
            // 
            // chcIlamVekaletFaiz
            // 
            this.chcIlamVekaletFaiz.Location = new System.Drawing.Point(562, 64);
            this.chcIlamVekaletFaiz.Name = "chcIlamVekaletFaiz";
            this.chcIlamVekaletFaiz.Properties.Caption = "Faiz Ýþlesin";
            this.chcIlamVekaletFaiz.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.chcIlamVekaletFaiz.Size = new System.Drawing.Size(85, 19);
            this.chcIlamVekaletFaiz.TabIndex = 93;
            // 
            // dtKesinlesmeTarihi
            // 
            this.dtKesinlesmeTarihi.EditValue = null;
            this.dtKesinlesmeTarihi.Location = new System.Drawing.Point(88, 202);
            this.dtKesinlesmeTarihi.Name = "dtKesinlesmeTarihi";
            this.dtKesinlesmeTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtKesinlesmeTarihi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtKesinlesmeTarihi.Size = new System.Drawing.Size(100, 20);
            this.dtKesinlesmeTarihi.TabIndex = 105;
            // 
            // txtEsasNo
            // 
            this.txtEsasNo.Location = new System.Drawing.Point(88, 89);
            this.txtEsasNo.Name = "txtEsasNo";
            this.txtEsasNo.Size = new System.Drawing.Size(100, 20);
            this.txtEsasNo.TabIndex = 103;
            // 
            // labelControl81
            // 
            this.labelControl81.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl81.Appearance.Options.UseFont = true;
            this.labelControl81.Location = new System.Drawing.Point(32, 204);
            this.labelControl81.Name = "labelControl81";
            this.labelControl81.Size = new System.Drawing.Size(52, 14);
            this.labelControl81.TabIndex = 90;
            this.labelControl81.Text = "Kesin T.";
            // 
            // chcInkarFaiz
            // 
            this.chcInkarFaiz.Location = new System.Drawing.Point(562, 89);
            this.chcInkarFaiz.Name = "chcInkarFaiz";
            this.chcInkarFaiz.Properties.Caption = "Faiz Ýþlesin";
            this.chcInkarFaiz.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.chcInkarFaiz.Size = new System.Drawing.Size(85, 19);
            this.chcInkarFaiz.TabIndex = 91;
            // 
            // dtKararBozulmaTarihi
            // 
            this.dtKararBozulmaTarihi.EditValue = null;
            this.dtKararBozulmaTarihi.Location = new System.Drawing.Point(88, 174);
            this.dtKararBozulmaTarihi.Name = "dtKararBozulmaTarihi";
            this.dtKararBozulmaTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtKararBozulmaTarihi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtKararBozulmaTarihi.Size = new System.Drawing.Size(100, 20);
            this.dtKararBozulmaTarihi.TabIndex = 106;
            // 
            // txtKararNo
            // 
            this.txtKararNo.Location = new System.Drawing.Point(88, 117);
            this.txtKararNo.Name = "txtKararNo";
            this.txtKararNo.Size = new System.Drawing.Size(100, 20);
            this.txtKararNo.TabIndex = 102;
            // 
            // labelControl82
            // 
            this.labelControl82.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl82.Appearance.Options.UseFont = true;
            this.labelControl82.Location = new System.Drawing.Point(274, 94);
            this.labelControl82.Name = "labelControl82";
            this.labelControl82.Size = new System.Drawing.Size(109, 14);
            this.labelControl82.TabIndex = 85;
            this.labelControl82.Text = "Ýnkar Tazminatý:";
            // 
            // labelControl76
            // 
            this.labelControl76.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl76.Appearance.Options.UseFont = true;
            this.labelControl76.Location = new System.Drawing.Point(12, 177);
            this.labelControl76.Name = "labelControl76";
            this.labelControl76.Size = new System.Drawing.Size(72, 14);
            this.labelControl76.TabIndex = 84;
            this.labelControl76.Text = "Bozulma T.";
            // 
            // dtKararTarihi
            // 
            this.dtKararTarihi.EditValue = null;
            this.dtKararTarihi.Location = new System.Drawing.Point(88, 148);
            this.dtKararTarihi.Name = "dtKararTarihi";
            this.dtKararTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtKararTarihi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtKararTarihi.Size = new System.Drawing.Size(100, 20);
            this.dtKararTarihi.TabIndex = 104;
            // 
            // compGridDovizSummary1
            // 
            this.compGridDovizSummary1.AltToplamlarAktifMi = true;
            this.compGridDovizSummary1.MyGridView = this.gridView1;
            // 
            // ucFormIlamBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "ucFormIlamBilgileri";
            this.Size = new System.Drawing.Size(655, 532);
            this.Load += new System.EventHandler(this.ucFormIlamBilgileri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gwIlamBilgisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndIlam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliyeBirimAdliyeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGorevID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIlamTipID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimNo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueAdliBirimNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueIlamTipi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTebligDovizTip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlamNotu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueYargilamaDoviz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rudInkarTazminati.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueVekaletDoviz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chcYargilamaFaiz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rudVekaletUcreti.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueInkarDovizTip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chcIlamTebligFaiz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rudYargilamaGideri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMahkeme.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rudTebligGideri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGorev.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chcIlamVekaletFaiz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKesinlesmeTarihi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKesinlesmeTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEsasNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chcInkarFaiz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKararBozulmaTarihi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKararBozulmaTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKararNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKararTarihi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKararTarihi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gwIlamBilgisi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnIlamBilgisiEkle;
        private DevExpress.XtraEditors.LabelControl labelControl74;
        private DevExpress.XtraEditors.LookUpEdit rLueTebligDovizTip;
        private DevExpress.XtraEditors.LabelControl labelControl75;
        private DevExpress.XtraEditors.LabelControl labelControl77;
        private DevExpress.XtraEditors.MemoEdit txtIlamNotu;
        private DevExpress.XtraEditors.LookUpEdit rLueYargilamaDoviz;
        private DevExpress.XtraEditors.LabelControl labelControl85;
        private DevExpress.XtraEditors.LabelControl labelControl46;
        private DevExpress.XtraEditors.SpinEdit rudInkarTazminati;
        private DevExpress.XtraEditors.LookUpEdit rLueVekaletDoviz;
        private DevExpress.XtraEditors.LabelControl labelControl78;
        private DevExpress.XtraEditors.CheckEdit chcYargilamaFaiz;
        private DevExpress.XtraEditors.SpinEdit rudVekaletUcreti;
        private DevExpress.XtraEditors.LookUpEdit rLueInkarDovizTip;
        private DevExpress.XtraEditors.LabelControl labelControl84;
        private DevExpress.XtraEditors.CheckEdit chcIlamTebligFaiz;
        private DevExpress.XtraEditors.SpinEdit rudYargilamaGideri;
        private DevExpress.XtraEditors.LookUpEdit rLueMahkeme;
        private DevExpress.XtraEditors.LabelControl labelControl80;
        private DevExpress.XtraEditors.LabelControl labelControl83;
        private DevExpress.XtraEditors.SpinEdit rudTebligGideri;
        private DevExpress.XtraEditors.LookUpEdit rLueGorev;
        private DevExpress.XtraEditors.LabelControl labelControl79;
        private DevExpress.XtraEditors.CheckEdit chcIlamVekaletFaiz;
        private DevExpress.XtraEditors.DateEdit dtKesinlesmeTarihi;
        private DevExpress.XtraEditors.TextEdit txtEsasNo;
        private DevExpress.XtraEditors.LabelControl labelControl81;
        private DevExpress.XtraEditors.CheckEdit chcInkarFaiz;
        private DevExpress.XtraEditors.DateEdit dtKararBozulmaTarihi;
        private DevExpress.XtraEditors.TextEdit txtKararNo;
        private DevExpress.XtraEditors.LabelControl labelControl82;
        private DevExpress.XtraEditors.LabelControl labelControl76;
        private DevExpress.XtraEditors.DateEdit dtKararTarihi;
        private System.Windows.Forms.BindingSource bndIlam;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_ADLIYE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_GOREV_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colESAS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colKARAR_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colKARAR_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colKARAR_BOZULMA_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colILAM_TIP;
        private DevExpress.XtraGrid.Columns.GridColumn colINKAR_TAZMINAT_FAIZ_ISLESIN_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colINKAR_TAZMINATI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colINKAR_TAZMINATI;
        private DevExpress.XtraGrid.Columns.GridColumn colYARGILAMA_GIDERI_FAIZ_ISLESIN_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colYARGILAMA_GIDERI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colYARGILAMA_GIDERI;
        private DevExpress.XtraGrid.Columns.GridColumn colILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colILAM_TEBLIG_GIDERI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colILAM_TEBLIG_GIDERI;
        private DevExpress.XtraGrid.Columns.GridColumn colILAM_ACIKLAMASI;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSelected;
        private DevExpress.XtraGrid.Columns.GridColumn colKARAR_KESINLESME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn COLILAM_VEKALET_UCRETI;
        private DevExpress.XtraGrid.Columns.GridColumn colILAM_VEKALET_UCRETI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI;
        private LookUpExtender lookUpExtender1;
        private DevExpress.XtraEditors.LookUpEdit lueIlamTipi;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliyeBirimAdliyeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueGorevID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDovizID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rTutar;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit txtAciklama;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueIlamTipID;
        private DevExpress.XtraEditors.SimpleButton btnIlamBilgisiSil;
        private DevExpress.XtraEditors.LookUpEdit lueAdliBirimNo;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_NO_I;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliBirimNo;
        private AdimAdimDavaKaydi.Util.compGridDovizSummary compGridDovizSummary1;

    }
}
