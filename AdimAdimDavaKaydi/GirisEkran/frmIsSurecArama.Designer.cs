using AdimAdimDavaKaydi.Util;
namespace AdimAdimDavaKaydi.GirisEkran
{
    partial class frmIsSurecArama
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.PointOptions pointOptions1 = new DevExpress.XtraCharts.PointOptions();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDURMA_NEDENI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueDurmaNeden = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colBASLAMA_TARIH_ZAMAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtTarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colDURMA_TARIH_ZAMAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDURMA_ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOZEL_ALAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIS_SORUMLU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIS_SUREC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIS_SOZLESME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMADDE_KALEM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIS_DURUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIS_BASLANGIC_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIS_ON_GORULEN_BITIS_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIS_BITIS_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIS_KATEGORI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIS_PLANLAYAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIS_MUHATABI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIS_KLASOR_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueKlasor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colIS_ADLI_BIRIM_ADLIYE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAdliye = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colIS_ADLI_BIRIM_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueadliBirimNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colIS_ADLI_BIRIM_GOREV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueGorev = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colIS_ESAS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBASLANGIC_ZAMANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBITIS_ZAMANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSUREC_ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMUHASEBELESTILMIS_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rChMuhasebelstirilmis = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colSURE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBIRIM_FIYAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rspFiyat = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueDoviz = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTOPLAM_FIYAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTOPLAM_FIYAT_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKONTROL_KIM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueKullanıcı = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSUBE_KOD_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueBuro = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueKategori = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.tabCtrlPivot = new DevExpress.XtraTab.XtraTabControl();
            this.tabPGenel = new DevExpress.XtraTab.XtraTabPage();
            this.nbCntSurecArama = new DevExpress.XtraNavBar.NavBarControl();
            this.nbGrbSorgu = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbGrbCntAramaKriter = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lueDosya = new DevExpress.XtraEditors.LookUpEdit();
            this.lueModul = new DevExpress.XtraEditors.LookUpEdit();
            this.txtEsasNo = new DevExpress.XtraEditors.TextEdit();
            this.lueGorev = new DevExpress.XtraEditors.LookUpEdit();
            this.lueAdliye = new DevExpress.XtraEditors.LookUpEdit();
            this.lueNo = new DevExpress.XtraEditors.LookUpEdit();
            this.lueMuhatab = new DevExpress.XtraEditors.LookUpEdit();
            this.dtBitisZmn = new DevExpress.XtraEditors.DateEdit();
            this.dtBaslangic = new DevExpress.XtraEditors.DateEdit();
            this.luePlanlayan = new DevExpress.XtraEditors.LookUpEdit();
            this.lueIsSurec = new DevExpress.XtraEditors.LookUpEdit();
            this.lueIsSozlesme = new DevExpress.XtraEditors.LookUpEdit();
            this.pnlLoutButon = new DevExpress.XtraEditors.PanelControl();
            this.lytCntButonlasr = new DevExpress.XtraLayout.LayoutControl();
            this.btnSorgula = new DevExpress.XtraEditors.SimpleButton();
            this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.lytGrbButonlar = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.chMuhasebelestirlmis = new DevExpress.XtraEditors.CheckEdit();
            this.chIsDurum = new DevExpress.XtraEditors.CheckEdit();
            this.lueKategori = new DevExpress.XtraEditors.LookUpEdit();
            this.dtIsBitisT = new DevExpress.XtraEditors.DateEdit();
            this.dtIsOngorulenBitisT = new DevExpress.XtraEditors.DateEdit();
            this.dtIsBaslangicT = new DevExpress.XtraEditors.DateEdit();
            this.lueSorumlu = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.GenelKriter = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Sorumlu = new DevExpress.XtraLayout.LayoutControlItem();
            this.BaslangicZmn = new DevExpress.XtraLayout.LayoutControlItem();
            this.BitisZmn = new DevExpress.XtraLayout.LayoutControlItem();
            this.Sozlesme = new DevExpress.XtraLayout.LayoutControlItem();
            this.Surec = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcntIsKriter = new DevExpress.XtraLayout.LayoutControlGroup();
            this.BaslangicT = new DevExpress.XtraLayout.LayoutControlItem();
            this.Muhatab = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.IsBitisT = new DevExpress.XtraLayout.LayoutControlItem();
            this.Planlayan = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Kategori = new DevExpress.XtraLayout.LayoutControlItem();
            this.ÖngorulenBitisT = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Butonlar = new DevExpress.XtraLayout.LayoutControlItem();
            this.nbGrbCntSonuc = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.nBGRbSonuc = new DevExpress.XtraNavBar.NavBarGroup();
            this.tabPPivot = new DevExpress.XtraTab.XtraTabPage();
            this.pnlPivot = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.pivotGridControl1 = new AdimAdimDavaKaydi.Util.ExtendedPivotControl();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.chBoxSutunToplami = new DevExpress.XtraEditors.CheckEdit();
            this.chBoxSatirToplami = new DevExpress.XtraEditors.CheckEdit();
            this.chBoxYonDegis = new DevExpress.XtraEditors.CheckEdit();
            this.lookGrafikSecimi = new DevExpress.XtraEditors.LookUpEdit();
            this.compNavBarAutoHeight1 = new AdimAdimDavaKaydi.Util.compNavBarAutoHeight(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDurmaNeden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTarih.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKlasor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueadliBirimNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGorev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rChMuhasebelstirilmis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspFiyat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDoviz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKullanıcı)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBuro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabCtrlPivot)).BeginInit();
            this.tabCtrlPivot.SuspendLayout();
            this.tabPGenel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbCntSurecArama)).BeginInit();
            this.nbCntSurecArama.SuspendLayout();
            this.nbGrbCntAramaKriter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueDosya.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueModul.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEsasNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGorev.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAdliye.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMuhatab.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBitisZmn.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBitisZmn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBaslangic.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBaslangic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePlanlayan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueIsSurec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueIsSozlesme.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLoutButon)).BeginInit();
            this.pnlLoutButon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lytCntButonlasr)).BeginInit();
            this.lytCntButonlasr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lytGrbButonlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chMuhasebelestirlmis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chIsDurum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueKategori.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIsBitisT.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIsBitisT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIsOngorulenBitisT.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIsOngorulenBitisT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIsBaslangicT.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIsBaslangicT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSorumlu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenelKriter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sorumlu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaslangicZmn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BitisZmn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sozlesme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Surec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcntIsKriter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaslangicT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Muhatab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsBitisT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Planlayan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ÖngorulenBitisT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Butonlar)).BeginInit();
            this.nbGrbCntSonuc.SuspendLayout();
            this.tabPPivot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPivot)).BeginInit();
            this.pnlPivot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chBoxSutunToplami.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chBoxSatirToplami.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chBoxYonDegis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrafikSecimi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 633);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(1000, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(850, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(925, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.pnlMain);
            this.c_pnlContainer.Size = new System.Drawing.Size(1000, 658);
            this.c_pnlContainer.Controls.SetChildIndex(this.pnlMain, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDURMA_NEDENI,
            this.colBASLAMA_TARIH_ZAMAN,
            this.colDURMA_TARIH_ZAMAN,
            this.colDURMA_ACIKLAMA,
            this.colOZEL_ALAN});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.ViewCaption = "Detay";
            // 
            // colDURMA_NEDENI
            // 
            this.colDURMA_NEDENI.Caption = "Durma Nedeni";
            this.colDURMA_NEDENI.ColumnEdit = this.rLueDurmaNeden;
            this.colDURMA_NEDENI.FieldName = "DURMA_NEDENI";
            this.colDURMA_NEDENI.Name = "colDURMA_NEDENI";
            this.colDURMA_NEDENI.Visible = true;
            this.colDURMA_NEDENI.VisibleIndex = 0;
            // 
            // rLueDurmaNeden
            // 
            this.rLueDurmaNeden.AutoHeight = false;
            this.rLueDurmaNeden.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDurmaNeden.Name = "rLueDurmaNeden";
            // 
            // colBASLAMA_TARIH_ZAMAN
            // 
            this.colBASLAMA_TARIH_ZAMAN.Caption = "Başlama T";
            this.colBASLAMA_TARIH_ZAMAN.ColumnEdit = this.dtTarih;
            this.colBASLAMA_TARIH_ZAMAN.FieldName = "BASLAMA_TARIH_ZAMAN";
            this.colBASLAMA_TARIH_ZAMAN.Name = "colBASLAMA_TARIH_ZAMAN";
            this.colBASLAMA_TARIH_ZAMAN.Visible = true;
            this.colBASLAMA_TARIH_ZAMAN.VisibleIndex = 1;
            // 
            // dtTarih
            // 
            this.dtTarih.AutoHeight = false;
            this.dtTarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTarih.Name = "dtTarih";
            this.dtTarih.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // colDURMA_TARIH_ZAMAN
            // 
            this.colDURMA_TARIH_ZAMAN.Caption = "Durma T";
            this.colDURMA_TARIH_ZAMAN.ColumnEdit = this.dtTarih;
            this.colDURMA_TARIH_ZAMAN.FieldName = "DURMA_TARIH_ZAMAN";
            this.colDURMA_TARIH_ZAMAN.Name = "colDURMA_TARIH_ZAMAN";
            this.colDURMA_TARIH_ZAMAN.Visible = true;
            this.colDURMA_TARIH_ZAMAN.VisibleIndex = 2;
            // 
            // colDURMA_ACIKLAMA
            // 
            this.colDURMA_ACIKLAMA.Caption = "Açıklama";
            this.colDURMA_ACIKLAMA.FieldName = "DURMA_ACIKLAMA";
            this.colDURMA_ACIKLAMA.Name = "colDURMA_ACIKLAMA";
            this.colDURMA_ACIKLAMA.Visible = true;
            this.colDURMA_ACIKLAMA.VisibleIndex = 3;
            // 
            // colOZEL_ALAN
            // 
            this.colOZEL_ALAN.Caption = "Süre";
            this.colOZEL_ALAN.FieldName = "OZEL_ALAN";
            this.colOZEL_ALAN.Name = "colOZEL_ALAN";
            this.colOZEL_ALAN.Visible = true;
            this.colOZEL_ALAN.VisibleIndex = 4;
            // 
            // gridControl1
            // 
            this.gridControl1.CustomButtonlarGorunmesin = false;
            this.gridControl1.DataSource = this.bindingSource1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.DoNotExtendEmbedNavigator = false;
            this.gridControl1.FilterText = null;
            this.gridControl1.FilterValue = null;
            this.gridControl1.GridlerDuzenlenebilir = true;
            this.gridControl1.GridsFilterControl = null;
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode1.RelationName = "AV001_TDI_BIL_IS_TAMAMLANMA_SURE_DETAYs";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MyGridStyle = null;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.dtTarih,
            this.rLueKategori,
            this.rLueKlasor,
            this.rLueAdliye,
            this.rLueadliBirimNo,
            this.rChMuhasebelstirilmis,
            this.rspFiyat,
            this.rLueDoviz,
            this.rLueKullanıcı,
            this.rLueBuro,
            this.rLueGorev,
            this.rLueDurmaNeden});
            this.gridControl1.ShowRowNumbers = false;
            this.gridControl1.SilmeKaldirilsin = false;
            this.gridControl1.Size = new System.Drawing.Size(982, 274);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.TemizleKaldirGorunsunmu = false;
            this.gridControl1.UniqueId = "b666a002-39ce-4dca-a90a-445b6e5be403";
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.UseHyperDragDrop = false;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(AvukatProLib.Arama.AV001_TDI_BIL_IS_TAMAMLANMA_SURE);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIS_SORUMLU,
            this.colIS_SUREC,
            this.colIS_SOZLESME,
            this.colMADDE_KALEM,
            this.colIS_DURUM,
            this.colIS_BASLANGIC_TARIHI,
            this.colIS_ON_GORULEN_BITIS_TARIHI,
            this.colIS_BITIS_TARIHI,
            this.colIS_KATEGORI_ID,
            this.colIS_PLANLAYAN,
            this.colIS_MUHATABI,
            this.colIS_KLASOR_ID,
            this.colIS_ADLI_BIRIM_ADLIYE,
            this.colIS_ADLI_BIRIM_NO,
            this.colIS_ADLI_BIRIM_GOREV,
            this.colIS_ESAS_NO,
            this.colBASLANGIC_ZAMANI,
            this.colBITIS_ZAMANI,
            this.colSUREC_ACIKLAMA,
            this.colMUHASEBELESTILMIS_MI,
            this.colSURE,
            this.colBIRIM_FIYAT,
            this.colBIRIM_FIYAT_DOVIZ_ID,
            this.colTOPLAM_FIYAT,
            this.colTOPLAM_FIYAT_DOVIZ_ID,
            this.colKONTROL_KIM_ID,
            this.colSUBE_KOD_ID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colIS_KATEGORI_ID, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gridView1_CustomSummaryCalculate);
            // 
            // colIS_SORUMLU
            // 
            this.colIS_SORUMLU.Caption = "Sorumlusu";
            this.colIS_SORUMLU.FieldName = "IS_SORUMLU";
            this.colIS_SORUMLU.Name = "colIS_SORUMLU";
            this.colIS_SORUMLU.OptionsColumn.ReadOnly = true;
            this.colIS_SORUMLU.Visible = true;
            this.colIS_SORUMLU.VisibleIndex = 10;
            this.colIS_SORUMLU.Width = 71;
            // 
            // colIS_SUREC
            // 
            this.colIS_SUREC.Caption = "İş Süreci";
            this.colIS_SUREC.FieldName = "IS_SUREC";
            this.colIS_SUREC.Name = "colIS_SUREC";
            this.colIS_SUREC.OptionsColumn.ReadOnly = true;
            this.colIS_SUREC.Visible = true;
            this.colIS_SUREC.VisibleIndex = 3;
            this.colIS_SUREC.Width = 63;
            // 
            // colIS_SOZLESME
            // 
            this.colIS_SOZLESME.Caption = "İş Sözleşmesi";
            this.colIS_SOZLESME.FieldName = "IS_SOZLESME";
            this.colIS_SOZLESME.Name = "colIS_SOZLESME";
            this.colIS_SOZLESME.OptionsColumn.ReadOnly = true;
            // 
            // colMADDE_KALEM
            // 
            this.colMADDE_KALEM.Caption = "Madde Kalem";
            this.colMADDE_KALEM.FieldName = "MADDE_KALEM";
            this.colMADDE_KALEM.Name = "colMADDE_KALEM";
            this.colMADDE_KALEM.OptionsColumn.ReadOnly = true;
            this.colMADDE_KALEM.Visible = true;
            this.colMADDE_KALEM.VisibleIndex = 2;
            this.colMADDE_KALEM.Width = 85;
            // 
            // colIS_DURUM
            // 
            this.colIS_DURUM.Caption = "Dr";
            this.colIS_DURUM.FieldName = "IS_DURUM";
            this.colIS_DURUM.Name = "colIS_DURUM";
            this.colIS_DURUM.OptionsColumn.ReadOnly = true;
            this.colIS_DURUM.Visible = true;
            this.colIS_DURUM.VisibleIndex = 0;
            this.colIS_DURUM.Width = 33;
            // 
            // colIS_BASLANGIC_TARIHI
            // 
            this.colIS_BASLANGIC_TARIHI.Caption = "Planlama T";
            this.colIS_BASLANGIC_TARIHI.ColumnEdit = this.dtTarih;
            this.colIS_BASLANGIC_TARIHI.FieldName = "IS_BASLANGIC_TARIHI";
            this.colIS_BASLANGIC_TARIHI.Name = "colIS_BASLANGIC_TARIHI";
            this.colIS_BASLANGIC_TARIHI.OptionsColumn.ReadOnly = true;
            this.colIS_BASLANGIC_TARIHI.Width = 63;
            // 
            // colIS_ON_GORULEN_BITIS_TARIHI
            // 
            this.colIS_ON_GORULEN_BITIS_TARIHI.Caption = "Öngörülen Bitiş T";
            this.colIS_ON_GORULEN_BITIS_TARIHI.ColumnEdit = this.dtTarih;
            this.colIS_ON_GORULEN_BITIS_TARIHI.FieldName = "IS_ON_GORULEN_BITIS_TARIHI";
            this.colIS_ON_GORULEN_BITIS_TARIHI.Name = "colIS_ON_GORULEN_BITIS_TARIHI";
            this.colIS_ON_GORULEN_BITIS_TARIHI.OptionsColumn.ReadOnly = true;
            this.colIS_ON_GORULEN_BITIS_TARIHI.Width = 93;
            // 
            // colIS_BITIS_TARIHI
            // 
            this.colIS_BITIS_TARIHI.Caption = "Kapama T";
            this.colIS_BITIS_TARIHI.ColumnEdit = this.dtTarih;
            this.colIS_BITIS_TARIHI.FieldName = "IS_BITIS_TARIHI";
            this.colIS_BITIS_TARIHI.Name = "colIS_BITIS_TARIHI";
            this.colIS_BITIS_TARIHI.OptionsColumn.ReadOnly = true;
            this.colIS_BITIS_TARIHI.Width = 59;
            // 
            // colIS_KATEGORI_ID
            // 
            this.colIS_KATEGORI_ID.Caption = "Kategori";
            this.colIS_KATEGORI_ID.FieldName = "IS_KATEGORI_ID";
            this.colIS_KATEGORI_ID.Name = "colIS_KATEGORI_ID";
            this.colIS_KATEGORI_ID.OptionsColumn.ReadOnly = true;
            this.colIS_KATEGORI_ID.Visible = true;
            this.colIS_KATEGORI_ID.VisibleIndex = 1;
            // 
            // colIS_PLANLAYAN
            // 
            this.colIS_PLANLAYAN.Caption = "Planlayan";
            this.colIS_PLANLAYAN.FieldName = "IS_PLANLAYAN";
            this.colIS_PLANLAYAN.Name = "colIS_PLANLAYAN";
            this.colIS_PLANLAYAN.OptionsColumn.ReadOnly = true;
            this.colIS_PLANLAYAN.Width = 58;
            // 
            // colIS_MUHATABI
            // 
            this.colIS_MUHATABI.Caption = "Muhatabı";
            this.colIS_MUHATABI.FieldName = "IS_MUHATABI";
            this.colIS_MUHATABI.Name = "colIS_MUHATABI";
            this.colIS_MUHATABI.OptionsColumn.ReadOnly = true;
            this.colIS_MUHATABI.Visible = true;
            this.colIS_MUHATABI.VisibleIndex = 11;
            this.colIS_MUHATABI.Width = 66;
            // 
            // colIS_KLASOR_ID
            // 
            this.colIS_KLASOR_ID.Caption = "Klasör";
            this.colIS_KLASOR_ID.ColumnEdit = this.rLueKlasor;
            this.colIS_KLASOR_ID.FieldName = "IS_KLASOR_ID";
            this.colIS_KLASOR_ID.Name = "colIS_KLASOR_ID";
            this.colIS_KLASOR_ID.OptionsColumn.ReadOnly = true;
            this.colIS_KLASOR_ID.Visible = true;
            this.colIS_KLASOR_ID.VisibleIndex = 16;
            this.colIS_KLASOR_ID.Width = 51;
            // 
            // rLueKlasor
            // 
            this.rLueKlasor.AutoHeight = false;
            this.rLueKlasor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueKlasor.Name = "rLueKlasor";
            // 
            // colIS_ADLI_BIRIM_ADLIYE
            // 
            this.colIS_ADLI_BIRIM_ADLIYE.Caption = "Adliye";
            this.colIS_ADLI_BIRIM_ADLIYE.ColumnEdit = this.rLueAdliye;
            this.colIS_ADLI_BIRIM_ADLIYE.FieldName = "IS_ADLI_BIRIM_ADLIYE";
            this.colIS_ADLI_BIRIM_ADLIYE.Name = "colIS_ADLI_BIRIM_ADLIYE";
            this.colIS_ADLI_BIRIM_ADLIYE.OptionsColumn.ReadOnly = true;
            this.colIS_ADLI_BIRIM_ADLIYE.Visible = true;
            this.colIS_ADLI_BIRIM_ADLIYE.VisibleIndex = 12;
            this.colIS_ADLI_BIRIM_ADLIYE.Width = 51;
            // 
            // rLueAdliye
            // 
            this.rLueAdliye.AutoHeight = false;
            this.rLueAdliye.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliye.Name = "rLueAdliye";
            // 
            // colIS_ADLI_BIRIM_NO
            // 
            this.colIS_ADLI_BIRIM_NO.Caption = "No";
            this.colIS_ADLI_BIRIM_NO.ColumnEdit = this.rLueadliBirimNo;
            this.colIS_ADLI_BIRIM_NO.FieldName = "IS_ADLI_BIRIM_NO";
            this.colIS_ADLI_BIRIM_NO.Name = "colIS_ADLI_BIRIM_NO";
            this.colIS_ADLI_BIRIM_NO.OptionsColumn.ReadOnly = true;
            this.colIS_ADLI_BIRIM_NO.Visible = true;
            this.colIS_ADLI_BIRIM_NO.VisibleIndex = 13;
            this.colIS_ADLI_BIRIM_NO.Width = 35;
            // 
            // rLueadliBirimNo
            // 
            this.rLueadliBirimNo.AutoHeight = false;
            this.rLueadliBirimNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueadliBirimNo.Name = "rLueadliBirimNo";
            // 
            // colIS_ADLI_BIRIM_GOREV
            // 
            this.colIS_ADLI_BIRIM_GOREV.Caption = "Görev";
            this.colIS_ADLI_BIRIM_GOREV.ColumnEdit = this.rLueGorev;
            this.colIS_ADLI_BIRIM_GOREV.FieldName = "IS_ADLI_BIRIM_GOREV";
            this.colIS_ADLI_BIRIM_GOREV.Name = "colIS_ADLI_BIRIM_GOREV";
            this.colIS_ADLI_BIRIM_GOREV.OptionsColumn.ReadOnly = true;
            this.colIS_ADLI_BIRIM_GOREV.Visible = true;
            this.colIS_ADLI_BIRIM_GOREV.VisibleIndex = 14;
            this.colIS_ADLI_BIRIM_GOREV.Width = 51;
            // 
            // rLueGorev
            // 
            this.rLueGorev.AutoHeight = false;
            this.rLueGorev.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueGorev.Name = "rLueGorev";
            // 
            // colIS_ESAS_NO
            // 
            this.colIS_ESAS_NO.Caption = "Esas No";
            this.colIS_ESAS_NO.FieldName = "IS_ESAS_NO";
            this.colIS_ESAS_NO.Name = "colIS_ESAS_NO";
            this.colIS_ESAS_NO.OptionsColumn.ReadOnly = true;
            this.colIS_ESAS_NO.Visible = true;
            this.colIS_ESAS_NO.VisibleIndex = 15;
            this.colIS_ESAS_NO.Width = 60;
            // 
            // colBASLANGIC_ZAMANI
            // 
            this.colBASLANGIC_ZAMANI.Caption = "Başlangıcı";
            this.colBASLANGIC_ZAMANI.ColumnEdit = this.dtTarih;
            this.colBASLANGIC_ZAMANI.FieldName = "BASLANGIC_ZAMANI";
            this.colBASLANGIC_ZAMANI.Name = "colBASLANGIC_ZAMANI";
            this.colBASLANGIC_ZAMANI.Visible = true;
            this.colBASLANGIC_ZAMANI.VisibleIndex = 4;
            this.colBASLANGIC_ZAMANI.Width = 68;
            // 
            // colBITIS_ZAMANI
            // 
            this.colBITIS_ZAMANI.Caption = "Bitişi";
            this.colBITIS_ZAMANI.ColumnEdit = this.dtTarih;
            this.colBITIS_ZAMANI.FieldName = "BITIS_ZAMANI";
            this.colBITIS_ZAMANI.Name = "colBITIS_ZAMANI";
            this.colBITIS_ZAMANI.Visible = true;
            this.colBITIS_ZAMANI.VisibleIndex = 5;
            this.colBITIS_ZAMANI.Width = 43;
            // 
            // colSUREC_ACIKLAMA
            // 
            this.colSUREC_ACIKLAMA.FieldName = "SUREC_ACIKLAMA";
            this.colSUREC_ACIKLAMA.Name = "colSUREC_ACIKLAMA";
            this.colSUREC_ACIKLAMA.Width = 102;
            // 
            // colMUHASEBELESTILMIS_MI
            // 
            this.colMUHASEBELESTILMIS_MI.Caption = "Muhasebeleştirilmiş";
            this.colMUHASEBELESTILMIS_MI.ColumnEdit = this.rChMuhasebelstirilmis;
            this.colMUHASEBELESTILMIS_MI.FieldName = "MUHASEBELESTILMIS_MI";
            this.colMUHASEBELESTILMIS_MI.Name = "colMUHASEBELESTILMIS_MI";
            this.colMUHASEBELESTILMIS_MI.Width = 103;
            // 
            // rChMuhasebelstirilmis
            // 
            this.rChMuhasebelstirilmis.AutoHeight = false;
            this.rChMuhasebelstirilmis.Name = "rChMuhasebelstirilmis";
            // 
            // colSURE
            // 
            this.colSURE.Caption = "Süre";
            this.colSURE.FieldName = "SURE_ST";
            this.colSURE.Name = "colSURE";
            this.colSURE.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)});
            this.colSURE.Visible = true;
            this.colSURE.VisibleIndex = 6;
            this.colSURE.Width = 44;
            // 
            // colBIRIM_FIYAT
            // 
            this.colBIRIM_FIYAT.Caption = "Birim Fiyat";
            this.colBIRIM_FIYAT.ColumnEdit = this.rspFiyat;
            this.colBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            this.colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
            this.colBIRIM_FIYAT.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BIRIM_FIYAT", "{0:N}")});
            this.colBIRIM_FIYAT.Visible = true;
            this.colBIRIM_FIYAT.VisibleIndex = 7;
            this.colBIRIM_FIYAT.Width = 71;
            // 
            // rspFiyat
            // 
            this.rspFiyat.AutoHeight = false;
            this.rspFiyat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rspFiyat.Name = "rspFiyat";
            // 
            // colBIRIM_FIYAT_DOVIZ_ID
            // 
            this.colBIRIM_FIYAT_DOVIZ_ID.Caption = " ";
            this.colBIRIM_FIYAT_DOVIZ_ID.ColumnEdit = this.rLueDoviz;
            this.colBIRIM_FIYAT_DOVIZ_ID.CustomizationCaption = "Birim Fiyat Doviz";
            this.colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            this.colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
            this.colBIRIM_FIYAT_DOVIZ_ID.Visible = true;
            this.colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 8;
            this.colBIRIM_FIYAT_DOVIZ_ID.Width = 25;
            // 
            // rLueDoviz
            // 
            this.rLueDoviz.AutoHeight = false;
            this.rLueDoviz.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDoviz.Name = "rLueDoviz";
            // 
            // colTOPLAM_FIYAT
            // 
            this.colTOPLAM_FIYAT.Caption = "Toplam Fiyat";
            this.colTOPLAM_FIYAT.ColumnEdit = this.rspFiyat;
            this.colTOPLAM_FIYAT.FieldName = "TOPLAM_FIYAT";
            this.colTOPLAM_FIYAT.Name = "colTOPLAM_FIYAT";
            this.colTOPLAM_FIYAT.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOPLAM_FIYAT", "{0:N}")});
            this.colTOPLAM_FIYAT.Visible = true;
            this.colTOPLAM_FIYAT.VisibleIndex = 9;
            this.colTOPLAM_FIYAT.Width = 83;
            // 
            // colTOPLAM_FIYAT_DOVIZ_ID
            // 
            this.colTOPLAM_FIYAT_DOVIZ_ID.Caption = " ";
            this.colTOPLAM_FIYAT_DOVIZ_ID.ColumnEdit = this.rLueDoviz;
            this.colTOPLAM_FIYAT_DOVIZ_ID.CustomizationCaption = "Toplam Fiyat doviz";
            this.colTOPLAM_FIYAT_DOVIZ_ID.FieldName = "TOPLAM_FIYAT_DOVIZ_ID";
            this.colTOPLAM_FIYAT_DOVIZ_ID.Name = "colTOPLAM_FIYAT_DOVIZ_ID";
            this.colTOPLAM_FIYAT_DOVIZ_ID.Visible = true;
            this.colTOPLAM_FIYAT_DOVIZ_ID.VisibleIndex = 17;
            this.colTOPLAM_FIYAT_DOVIZ_ID.Width = 25;
            // 
            // colKONTROL_KIM_ID
            // 
            this.colKONTROL_KIM_ID.Caption = "Kullanıcı";
            this.colKONTROL_KIM_ID.ColumnEdit = this.rLueKullanıcı;
            this.colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            this.colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            this.colKONTROL_KIM_ID.Width = 49;
            // 
            // rLueKullanıcı
            // 
            this.rLueKullanıcı.AutoHeight = false;
            this.rLueKullanıcı.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueKullanıcı.Name = "rLueKullanıcı";
            // 
            // colSUBE_KOD_ID
            // 
            this.colSUBE_KOD_ID.Caption = "Büro";
            this.colSUBE_KOD_ID.ColumnEdit = this.rLueBuro;
            this.colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            this.colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            this.colSUBE_KOD_ID.Width = 34;
            // 
            // rLueBuro
            // 
            this.rLueBuro.AutoHeight = false;
            this.rLueBuro.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBuro.Name = "rLueBuro";
            // 
            // rLueKategori
            // 
            this.rLueKategori.AutoHeight = false;
            this.rLueKategori.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueKategori.Name = "rLueKategori";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tabCtrlPivot);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1000, 658);
            this.pnlMain.TabIndex = 10;
            // 
            // tabCtrlPivot
            // 
            this.tabCtrlPivot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlPivot.Location = new System.Drawing.Point(2, 2);
            this.tabCtrlPivot.Name = "tabCtrlPivot";
            this.tabCtrlPivot.SelectedTabPage = this.tabPGenel;
            this.tabCtrlPivot.Size = new System.Drawing.Size(996, 654);
            this.tabCtrlPivot.TabIndex = 1;
            this.tabCtrlPivot.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPGenel,
            this.tabPPivot});
            // 
            // tabPGenel
            // 
            this.tabPGenel.Controls.Add(this.nbCntSurecArama);
            this.tabPGenel.Name = "tabPGenel";
            this.tabPGenel.Size = new System.Drawing.Size(990, 626);
            this.tabPGenel.Text = "Genel Rapor";
            // 
            // nbCntSurecArama
            // 
            this.nbCntSurecArama.ActiveGroup = this.nbGrbSorgu;
            this.nbCntSurecArama.ContentButtonHint = null;
            this.nbCntSurecArama.Controls.Add(this.nbGrbCntSonuc);
            this.nbCntSurecArama.Controls.Add(this.nbGrbCntAramaKriter);
            this.nbCntSurecArama.Dock = System.Windows.Forms.DockStyle.Top;
            this.nbCntSurecArama.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbGrbSorgu,
            this.nBGRbSonuc});
            this.nbCntSurecArama.Location = new System.Drawing.Point(0, 0);
            this.nbCntSurecArama.Name = "nbCntSurecArama";
            this.nbCntSurecArama.OptionsNavPane.ExpandedWidth = 990;
            this.nbCntSurecArama.Size = new System.Drawing.Size(990, 625);
            this.nbCntSurecArama.TabIndex = 0;
            this.nbCntSurecArama.Text = "navBarControl1";
            // 
            // nbGrbSorgu
            // 
            this.nbGrbSorgu.Caption = "Arama Kriterleri";
            this.nbGrbSorgu.ControlContainer = this.nbGrbCntAramaKriter;
            this.nbGrbSorgu.Expanded = true;
            this.nbGrbSorgu.GroupClientHeight = 271;
            this.nbGrbSorgu.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbGrbSorgu.Name = "nbGrbSorgu";
            // 
            // nbGrbCntAramaKriter
            // 
            this.nbGrbCntAramaKriter.Controls.Add(this.panelControl1);
            this.nbGrbCntAramaKriter.Name = "nbGrbCntAramaKriter";
            this.nbGrbCntAramaKriter.Size = new System.Drawing.Size(982, 264);
            this.nbGrbCntAramaKriter.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Location = new System.Drawing.Point(22, 18);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(875, 248);
            this.panelControl1.TabIndex = 1;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lueDosya);
            this.layoutControl1.Controls.Add(this.lueModul);
            this.layoutControl1.Controls.Add(this.txtEsasNo);
            this.layoutControl1.Controls.Add(this.lueGorev);
            this.layoutControl1.Controls.Add(this.lueAdliye);
            this.layoutControl1.Controls.Add(this.lueNo);
            this.layoutControl1.Controls.Add(this.lueMuhatab);
            this.layoutControl1.Controls.Add(this.dtBitisZmn);
            this.layoutControl1.Controls.Add(this.dtBaslangic);
            this.layoutControl1.Controls.Add(this.luePlanlayan);
            this.layoutControl1.Controls.Add(this.lueIsSurec);
            this.layoutControl1.Controls.Add(this.lueIsSozlesme);
            this.layoutControl1.Controls.Add(this.pnlLoutButon);
            this.layoutControl1.Controls.Add(this.chMuhasebelestirlmis);
            this.layoutControl1.Controls.Add(this.chIsDurum);
            this.layoutControl1.Controls.Add(this.lueKategori);
            this.layoutControl1.Controls.Add(this.dtIsBitisT);
            this.layoutControl1.Controls.Add(this.dtIsOngorulenBitisT);
            this.layoutControl1.Controls.Add(this.dtIsBaslangicT);
            this.layoutControl1.Controls.Add(this.lueSorumlu);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(871, 244);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lueDosya
            // 
            this.lueDosya.Location = new System.Drawing.Point(338, 43);
            this.lueDosya.Name = "lueDosya";
            this.lueDosya.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDosya.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueDosya.Size = new System.Drawing.Size(115, 20);
            this.lueDosya.StyleController = this.layoutControl1;
            this.lueDosya.TabIndex = 24;
            this.lueDosya.EditValueChanged += new System.EventHandler(this.lueDosya_EditValueChanged);
            // 
            // lueModul
            // 
            this.lueModul.Location = new System.Drawing.Point(108, 43);
            this.lueModul.Name = "lueModul";
            this.lueModul.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueModul.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueModul.Size = new System.Drawing.Size(142, 20);
            this.lueModul.StyleController = this.layoutControl1;
            this.lueModul.TabIndex = 23;
            this.lueModul.EditValueChanged += new System.EventHandler(this.lueModul_EditValueChanged);
            // 
            // txtEsasNo
            // 
            this.txtEsasNo.Location = new System.Drawing.Point(108, 91);
            this.txtEsasNo.Name = "txtEsasNo";
            this.txtEsasNo.Size = new System.Drawing.Size(141, 20);
            this.txtEsasNo.StyleController = this.layoutControl1;
            this.txtEsasNo.TabIndex = 22;
            this.txtEsasNo.TextChanged += new System.EventHandler(this.txtEsasNo_TextChanged);
            // 
            // lueGorev
            // 
            this.lueGorev.Location = new System.Drawing.Point(340, 67);
            this.lueGorev.Name = "lueGorev";
            this.lueGorev.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGorev.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueGorev.Size = new System.Drawing.Size(113, 20);
            this.lueGorev.StyleController = this.layoutControl1;
            this.lueGorev.TabIndex = 20;
            this.lueGorev.EditValueChanged += new System.EventHandler(this.lueGorev_EditValueChanged);
            // 
            // lueAdliye
            // 
            this.lueAdliye.Location = new System.Drawing.Point(108, 67);
            this.lueAdliye.Name = "lueAdliye";
            this.lueAdliye.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAdliye.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueAdliye.Size = new System.Drawing.Size(141, 20);
            this.lueAdliye.StyleController = this.layoutControl1;
            this.lueAdliye.TabIndex = 19;
            this.lueAdliye.EditValueChanged += new System.EventHandler(this.lueAdliye_EditValueChanged);
            // 
            // lueNo
            // 
            this.lueNo.Location = new System.Drawing.Point(253, 67);
            this.lueNo.Name = "lueNo";
            this.lueNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueNo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueNo.Size = new System.Drawing.Size(83, 20);
            this.lueNo.StyleController = this.layoutControl1;
            this.lueNo.TabIndex = 21;
            this.lueNo.EditValueChanged += new System.EventHandler(this.lueNo_EditValueChanged);
            // 
            // lueMuhatab
            // 
            this.lueMuhatab.Location = new System.Drawing.Point(108, 115);
            this.lueMuhatab.Name = "lueMuhatab";
            this.lueMuhatab.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMuhatab.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueMuhatab.Size = new System.Drawing.Size(142, 20);
            this.lueMuhatab.StyleController = this.layoutControl1;
            this.lueMuhatab.TabIndex = 18;
            this.lueMuhatab.EditValueChanged += new System.EventHandler(this.lueMuhatab_EditValueChanged);
            // 
            // dtBitisZmn
            // 
            this.dtBitisZmn.EditValue = null;
            this.dtBitisZmn.Location = new System.Drawing.Point(565, 139);
            this.dtBitisZmn.Name = "dtBitisZmn";
            this.dtBitisZmn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtBitisZmn.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtBitisZmn.Size = new System.Drawing.Size(176, 20);
            this.dtBitisZmn.StyleController = this.layoutControl1;
            this.dtBitisZmn.TabIndex = 7;
            this.dtBitisZmn.EditValueChanged += new System.EventHandler(this.dtBitisZmn_EditValueChanged);
            // 
            // dtBaslangic
            // 
            this.dtBaslangic.EditValue = null;
            this.dtBaslangic.Location = new System.Drawing.Point(565, 115);
            this.dtBaslangic.Name = "dtBaslangic";
            this.dtBaslangic.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtBaslangic.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtBaslangic.Size = new System.Drawing.Size(176, 20);
            this.dtBaslangic.StyleController = this.layoutControl1;
            this.dtBaslangic.TabIndex = 6;
            this.dtBaslangic.EditValueChanged += new System.EventHandler(this.dtBaslangic_EditValueChanged);
            // 
            // luePlanlayan
            // 
            this.luePlanlayan.Location = new System.Drawing.Point(338, 115);
            this.luePlanlayan.Name = "luePlanlayan";
            this.luePlanlayan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePlanlayan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luePlanlayan.Size = new System.Drawing.Size(115, 20);
            this.luePlanlayan.StyleController = this.layoutControl1;
            this.luePlanlayan.TabIndex = 17;
            this.luePlanlayan.EditValueChanged += new System.EventHandler(this.luePlanlayan_EditValueChanged);
            // 
            // lueIsSurec
            // 
            this.lueIsSurec.Location = new System.Drawing.Point(565, 91);
            this.lueIsSurec.Name = "lueIsSurec";
            this.lueIsSurec.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueIsSurec.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueIsSurec.Size = new System.Drawing.Size(176, 20);
            this.lueIsSurec.StyleController = this.layoutControl1;
            this.lueIsSurec.TabIndex = 8;
            this.lueIsSurec.EditValueChanged += new System.EventHandler(this.lueIsSurec_EditValueChanged);
            // 
            // lueIsSozlesme
            // 
            this.lueIsSozlesme.Location = new System.Drawing.Point(565, 67);
            this.lueIsSozlesme.Name = "lueIsSozlesme";
            this.lueIsSozlesme.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueIsSozlesme.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueIsSozlesme.Size = new System.Drawing.Size(176, 20);
            this.lueIsSozlesme.StyleController = this.layoutControl1;
            this.lueIsSozlesme.TabIndex = 9;
            this.lueIsSozlesme.EditValueChanged += new System.EventHandler(this.lueIsSozlesme_EditValueChanged);
            // 
            // pnlLoutButon
            // 
            this.pnlLoutButon.Controls.Add(this.lytCntButonlasr);
            this.pnlLoutButon.Location = new System.Drawing.Point(757, 12);
            this.pnlLoutButon.Name = "pnlLoutButon";
            this.pnlLoutButon.Size = new System.Drawing.Size(102, 220);
            this.pnlLoutButon.TabIndex = 16;
            // 
            // lytCntButonlasr
            // 
            this.lytCntButonlasr.Controls.Add(this.btnSorgula);
            this.lytCntButonlasr.Controls.Add(this.btnTemizle);
            this.lytCntButonlasr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lytCntButonlasr.Location = new System.Drawing.Point(2, 2);
            this.lytCntButonlasr.Name = "lytCntButonlasr";
            this.lytCntButonlasr.Root = this.lytGrbButonlar;
            this.lytCntButonlasr.Size = new System.Drawing.Size(98, 216);
            this.lytCntButonlasr.TabIndex = 0;
            this.lytCntButonlasr.Text = "layoutControl2";
            // 
            // btnSorgula
            // 
            this.btnSorgula.Location = new System.Drawing.Point(12, 118);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(74, 22);
            this.btnSorgula.StyleController = this.lytCntButonlasr;
            this.btnSorgula.TabIndex = 5;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(12, 70);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(74, 22);
            this.btnTemizle.StyleController = this.lytCntButonlasr;
            this.btnTemizle.TabIndex = 4;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // lytGrbButonlar
            // 
            this.lytGrbButonlar.CustomizationFormText = "lytGrbButonlar";
            this.lytGrbButonlar.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lytGrbButonlar.GroupBordersVisible = false;
            this.lytGrbButonlar.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem3});
            this.lytGrbButonlar.Location = new System.Drawing.Point(0, 0);
            this.lytGrbButonlar.Name = "lytGrbButonlar";
            this.lytGrbButonlar.Size = new System.Drawing.Size(98, 216);
            this.lytGrbButonlar.Text = "lytGrbButonlar";
            this.lytGrbButonlar.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnTemizle;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 58);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(78, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnSorgula;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 106);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(78, 26);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 132);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(78, 64);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 84);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(78, 22);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(78, 58);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // chMuhasebelestirlmis
            // 
            this.chMuhasebelestirlmis.Location = new System.Drawing.Point(481, 163);
            this.chMuhasebelestirlmis.Name = "chMuhasebelestirlmis";
            this.chMuhasebelestirlmis.Properties.Caption = "Muhasebeleştirilmiş";
            this.chMuhasebelestirlmis.Size = new System.Drawing.Size(260, 19);
            this.chMuhasebelestirlmis.StyleController = this.layoutControl1;
            this.chMuhasebelestirlmis.TabIndex = 10;
            this.chMuhasebelestirlmis.CheckedChanged += new System.EventHandler(this.chMuhasebelestirlmis_CheckedChanged);
            // 
            // chIsDurum
            // 
            this.chIsDurum.Location = new System.Drawing.Point(252, 163);
            this.chIsDurum.Name = "chIsDurum";
            this.chIsDurum.Properties.Caption = "Durum";
            this.chIsDurum.Size = new System.Drawing.Size(201, 19);
            this.chIsDurum.StyleController = this.layoutControl1;
            this.chIsDurum.TabIndex = 10;
            this.chIsDurum.CheckedChanged += new System.EventHandler(this.chIsDurum_CheckedChanged);
            // 
            // lueKategori
            // 
            this.lueKategori.Location = new System.Drawing.Point(337, 91);
            this.lueKategori.Name = "lueKategori";
            this.lueKategori.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueKategori.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueKategori.Size = new System.Drawing.Size(116, 20);
            this.lueKategori.StyleController = this.layoutControl1;
            this.lueKategori.TabIndex = 15;
            this.lueKategori.EditValueChanged += new System.EventHandler(this.lueKategori_EditValueChanged);
            // 
            // dtIsBitisT
            // 
            this.dtIsBitisT.EditValue = null;
            this.dtIsBitisT.Location = new System.Drawing.Point(108, 163);
            this.dtIsBitisT.Name = "dtIsBitisT";
            this.dtIsBitisT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtIsBitisT.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtIsBitisT.Size = new System.Drawing.Size(140, 20);
            this.dtIsBitisT.StyleController = this.layoutControl1;
            this.dtIsBitisT.TabIndex = 14;
            this.dtIsBitisT.EditValueChanged += new System.EventHandler(this.dtIsBitisT_EditValueChanged);
            // 
            // dtIsOngorulenBitisT
            // 
            this.dtIsOngorulenBitisT.EditValue = null;
            this.dtIsOngorulenBitisT.Location = new System.Drawing.Point(336, 139);
            this.dtIsOngorulenBitisT.Name = "dtIsOngorulenBitisT";
            this.dtIsOngorulenBitisT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtIsOngorulenBitisT.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtIsOngorulenBitisT.Size = new System.Drawing.Size(117, 20);
            this.dtIsOngorulenBitisT.StyleController = this.layoutControl1;
            this.dtIsOngorulenBitisT.TabIndex = 13;
            this.dtIsOngorulenBitisT.EditValueChanged += new System.EventHandler(this.dtIsOngorulenBitisT_EditValueChanged);
            // 
            // dtIsBaslangicT
            // 
            this.dtIsBaslangicT.EditValue = null;
            this.dtIsBaslangicT.Location = new System.Drawing.Point(108, 139);
            this.dtIsBaslangicT.Name = "dtIsBaslangicT";
            this.dtIsBaslangicT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtIsBaslangicT.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtIsBaslangicT.Size = new System.Drawing.Size(140, 20);
            this.dtIsBaslangicT.StyleController = this.layoutControl1;
            this.dtIsBaslangicT.TabIndex = 12;
            this.dtIsBaslangicT.EditValueChanged += new System.EventHandler(this.dtIsBaslangicT_EditValueChanged);
            // 
            // lueSorumlu
            // 
            this.lueSorumlu.Location = new System.Drawing.Point(565, 43);
            this.lueSorumlu.Name = "lueSorumlu";
            this.lueSorumlu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSorumlu.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueSorumlu.Size = new System.Drawing.Size(176, 20);
            this.lueSorumlu.StyleController = this.layoutControl1;
            this.lueSorumlu.TabIndex = 5;
            this.lueSorumlu.EditValueChanged += new System.EventHandler(this.lueSorumlu_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.GenelKriter,
            this.lcntIsKriter,
            this.Butonlar});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(871, 244);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // GenelKriter
            // 
            this.GenelKriter.CustomizationFormText = "İşin Süreci İle İlgili Kriterler";
            this.GenelKriter.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.Sorumlu,
            this.BaslangicZmn,
            this.BitisZmn,
            this.Sozlesme,
            this.Surec});
            this.GenelKriter.Location = new System.Drawing.Point(457, 0);
            this.GenelKriter.Name = "GenelKriter";
            this.GenelKriter.Size = new System.Drawing.Size(288, 224);
            this.GenelKriter.Text = "İşin Süreci İle İlgili Kriterler";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.chMuhasebelestirlmis;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(264, 61);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // Sorumlu
            // 
            this.Sorumlu.Control = this.lueSorumlu;
            this.Sorumlu.CustomizationFormText = "Sorumlu";
            this.Sorumlu.Location = new System.Drawing.Point(0, 0);
            this.Sorumlu.Name = "Sorumlu";
            this.Sorumlu.Size = new System.Drawing.Size(264, 24);
            this.Sorumlu.Text = "Sorumlu";
            this.Sorumlu.TextSize = new System.Drawing.Size(81, 13);
            // 
            // BaslangicZmn
            // 
            this.BaslangicZmn.Control = this.dtBaslangic;
            this.BaslangicZmn.CustomizationFormText = "Başlangıç Zamanı";
            this.BaslangicZmn.Location = new System.Drawing.Point(0, 72);
            this.BaslangicZmn.Name = "BaslangicZmn";
            this.BaslangicZmn.Size = new System.Drawing.Size(264, 24);
            this.BaslangicZmn.Text = "Muhasebe";
            this.BaslangicZmn.TextSize = new System.Drawing.Size(81, 13);
            // 
            // BitisZmn
            // 
            this.BitisZmn.Control = this.dtBitisZmn;
            this.BitisZmn.CustomizationFormText = "Bitiş Zamanı";
            this.BitisZmn.Location = new System.Drawing.Point(0, 96);
            this.BitisZmn.Name = "BitisZmn";
            this.BitisZmn.Size = new System.Drawing.Size(264, 24);
            this.BitisZmn.Text = "Başlangıç Zamanı";
            this.BitisZmn.TextSize = new System.Drawing.Size(81, 13);
            // 
            // Sozlesme
            // 
            this.Sozlesme.Control = this.lueIsSozlesme;
            this.Sozlesme.CustomizationFormText = "Süreç";
            this.Sozlesme.Location = new System.Drawing.Point(0, 24);
            this.Sozlesme.Name = "Sozlesme";
            this.Sozlesme.Size = new System.Drawing.Size(264, 24);
            this.Sozlesme.Text = "Sözleşme";
            this.Sozlesme.TextSize = new System.Drawing.Size(81, 13);
            // 
            // Surec
            // 
            this.Surec.Control = this.lueIsSurec;
            this.Surec.CustomizationFormText = "layoutControlItem8";
            this.Surec.Location = new System.Drawing.Point(0, 48);
            this.Surec.Name = "Surec";
            this.Surec.Size = new System.Drawing.Size(264, 24);
            this.Surec.Text = "Süreç";
            this.Surec.TextSize = new System.Drawing.Size(81, 13);
            // 
            // lcntIsKriter
            // 
            this.lcntIsKriter.CustomizationFormText = "Yapılacak İş Kriterleri";
            this.lcntIsKriter.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.BaslangicT,
            this.Muhatab,
            this.layoutControlItem8,
            this.IsBitisT,
            this.Planlayan,
            this.layoutControlItem12,
            this.layoutControlItem13,
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.Kategori,
            this.ÖngorulenBitisT,
            this.layoutControlItem4,
            this.layoutControlItem9});
            this.lcntIsKriter.Location = new System.Drawing.Point(0, 0);
            this.lcntIsKriter.Name = "lcntIsKriter";
            this.lcntIsKriter.Size = new System.Drawing.Size(457, 224);
            this.lcntIsKriter.Text = "Yapılacak İş Kriterleri";
            // 
            // BaslangicT
            // 
            this.BaslangicT.Control = this.dtIsBaslangicT;
            this.BaslangicT.CustomizationFormText = "Planlama T";
            this.BaslangicT.Location = new System.Drawing.Point(0, 96);
            this.BaslangicT.Name = "BaslangicT";
            this.BaslangicT.Size = new System.Drawing.Size(228, 24);
            this.BaslangicT.Text = "Planlama T";
            this.BaslangicT.TextSize = new System.Drawing.Size(81, 13);
            // 
            // Muhatab
            // 
            this.Muhatab.Control = this.lueMuhatab;
            this.Muhatab.CustomizationFormText = "Muhatab";
            this.Muhatab.Location = new System.Drawing.Point(0, 72);
            this.Muhatab.Name = "Muhatab";
            this.Muhatab.Size = new System.Drawing.Size(230, 24);
            this.Muhatab.Text = "Muhatab";
            this.Muhatab.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.lueAdliye;
            this.layoutControlItem8.CustomizationFormText = "Adliye";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(229, 24);
            this.layoutControlItem8.Text = "Adliye";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(81, 13);
            // 
            // IsBitisT
            // 
            this.IsBitisT.Control = this.dtIsBitisT;
            this.IsBitisT.CustomizationFormText = "Kapama T";
            this.IsBitisT.Location = new System.Drawing.Point(0, 120);
            this.IsBitisT.Name = "IsBitisT";
            this.IsBitisT.Size = new System.Drawing.Size(228, 61);
            this.IsBitisT.Text = "Kapama T";
            this.IsBitisT.TextSize = new System.Drawing.Size(81, 13);
            // 
            // Planlayan
            // 
            this.Planlayan.Control = this.luePlanlayan;
            this.Planlayan.CustomizationFormText = "Planlayan";
            this.Planlayan.Location = new System.Drawing.Point(230, 72);
            this.Planlayan.Name = "Planlayan";
            this.Planlayan.Size = new System.Drawing.Size(203, 24);
            this.Planlayan.Text = "Planlayan";
            this.Planlayan.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.lueModul;
            this.layoutControlItem12.CustomizationFormText = "Modul";
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(230, 24);
            this.layoutControlItem12.Text = "Modul";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.lueDosya;
            this.layoutControlItem13.CustomizationFormText = "Dosya";
            this.layoutControlItem13.Location = new System.Drawing.Point(230, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(203, 24);
            this.layoutControlItem13.Text = "Dosya";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.lueNo;
            this.layoutControlItem10.CustomizationFormText = "No";
            this.layoutControlItem10.Location = new System.Drawing.Point(229, 24);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(87, 24);
            this.layoutControlItem10.Text = "No";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextToControlDistance = 0;
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtEsasNo;
            this.layoutControlItem11.CustomizationFormText = "Esas No";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(229, 24);
            this.layoutControlItem11.Text = "Esas No";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(81, 13);
            // 
            // Kategori
            // 
            this.Kategori.Control = this.lueKategori;
            this.Kategori.CustomizationFormText = "Kategori";
            this.Kategori.Location = new System.Drawing.Point(229, 48);
            this.Kategori.Name = "Kategori";
            this.Kategori.Size = new System.Drawing.Size(204, 24);
            this.Kategori.Text = "Kategori";
            this.Kategori.TextSize = new System.Drawing.Size(81, 13);
            // 
            // ÖngorulenBitisT
            // 
            this.ÖngorulenBitisT.Control = this.dtIsOngorulenBitisT;
            this.ÖngorulenBitisT.CustomizationFormText = "Öngörülen Bitiş T";
            this.ÖngorulenBitisT.Location = new System.Drawing.Point(228, 96);
            this.ÖngorulenBitisT.Name = "ÖngorulenBitisT";
            this.ÖngorulenBitisT.Size = new System.Drawing.Size(205, 24);
            this.ÖngorulenBitisT.Text = "Öngörülen Bitiş T";
            this.ÖngorulenBitisT.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.chIsDurum;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(228, 120);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(205, 61);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.lueGorev;
            this.layoutControlItem9.CustomizationFormText = "Gorev";
            this.layoutControlItem9.Location = new System.Drawing.Point(316, 24);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(117, 24);
            this.layoutControlItem9.Text = "Gorev";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // Butonlar
            // 
            this.Butonlar.Control = this.pnlLoutButon;
            this.Butonlar.CustomizationFormText = "Butonlar";
            this.Butonlar.Location = new System.Drawing.Point(745, 0);
            this.Butonlar.Name = "Butonlar";
            this.Butonlar.Size = new System.Drawing.Size(106, 224);
            this.Butonlar.Text = "Butonlar";
            this.Butonlar.TextSize = new System.Drawing.Size(0, 0);
            this.Butonlar.TextToControlDistance = 0;
            this.Butonlar.TextVisible = false;
            // 
            // nbGrbCntSonuc
            // 
            this.nbGrbCntSonuc.Controls.Add(this.gridControl1);
            this.nbGrbCntSonuc.Name = "nbGrbCntSonuc";
            this.nbGrbCntSonuc.Size = new System.Drawing.Size(982, 274);
            this.nbGrbCntSonuc.TabIndex = 0;
            // 
            // nBGRbSonuc
            // 
            this.nBGRbSonuc.Caption = "Arama Sonuçları";
            this.nBGRbSonuc.ControlContainer = this.nbGrbCntSonuc;
            this.nBGRbSonuc.Expanded = true;
            this.nBGRbSonuc.GroupClientHeight = 281;
            this.nBGRbSonuc.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nBGRbSonuc.Name = "nBGRbSonuc";
            // 
            // tabPPivot
            // 
            this.tabPPivot.Controls.Add(this.pnlPivot);
            this.tabPPivot.Name = "tabPPivot";
            this.tabPPivot.Size = new System.Drawing.Size(990, 626);
            this.tabPPivot.Text = "Pivot Rapor";
            // 
            // pnlPivot
            // 
            this.pnlPivot.Controls.Add(this.panelControl2);
            this.pnlPivot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPivot.Location = new System.Drawing.Point(0, 0);
            this.pnlPivot.Name = "pnlPivot";
            this.pnlPivot.Size = new System.Drawing.Size(990, 626);
            this.pnlPivot.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.splitContainerControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(986, 622);
            this.panelControl2.TabIndex = 5;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Appearance.Options.UseTextOptions = true;
            this.splitContainerControl1.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.None;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.pivotGridControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.chartControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.ScrollBarSmallChange = 1;
            this.splitContainerControl1.Size = new System.Drawing.Size(982, 618);
            this.splitContainerControl1.SplitterPosition = 300;
            this.splitContainerControl1.TabIndex = 5;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.Size = new System.Drawing.Size(982, 300);
            this.pivotGridControl1.TabIndex = 0;
            this.pivotGridControl1.CustomSummary += new DevExpress.XtraPivotGrid.PivotGridCustomSummaryEventHandler(this.pivotGridControl1_CustomSummary);
            // 
            // chartControl1
            // 
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Location = new System.Drawing.Point(0, 71);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.RuntimeSelection = true;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            sideBySideBarSeriesLabel1.LineVisible = true;
            this.chartControl1.SeriesTemplate.Label = sideBySideBarSeriesLabel1;
            pointOptions1.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
            pointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            this.chartControl1.SeriesTemplate.LegendPointOptions = pointOptions1;
            this.chartControl1.SeriesTemplate.SynchronizePointOptions = false;
            this.chartControl1.Size = new System.Drawing.Size(982, 242);
            this.chartControl1.TabIndex = 7;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(982, 71);
            this.xtraTabControl1.TabIndex = 8;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.chBoxSutunToplami);
            this.xtraTabPage1.Controls.Add(this.chBoxSatirToplami);
            this.xtraTabPage1.Controls.Add(this.chBoxYonDegis);
            this.xtraTabPage1.Controls.Add(this.lookGrafikSecimi);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(976, 43);
            this.xtraTabPage1.Text = "Seçenekler";
            // 
            // chBoxSutunToplami
            // 
            this.chBoxSutunToplami.Location = new System.Drawing.Point(307, 7);
            this.chBoxSutunToplami.Name = "chBoxSutunToplami";
            this.chBoxSutunToplami.Properties.Caption = "Sütun Toplamı";
            this.chBoxSutunToplami.Size = new System.Drawing.Size(115, 19);
            this.chBoxSutunToplami.TabIndex = 3;
            // 
            // chBoxSatirToplami
            // 
            this.chBoxSatirToplami.Location = new System.Drawing.Point(213, 7);
            this.chBoxSatirToplami.Name = "chBoxSatirToplami";
            this.chBoxSatirToplami.Properties.Caption = "Satır Toplamı";
            this.chBoxSatirToplami.Size = new System.Drawing.Size(88, 19);
            this.chBoxSatirToplami.TabIndex = 2;
            // 
            // chBoxYonDegis
            // 
            this.chBoxYonDegis.Location = new System.Drawing.Point(128, 7);
            this.chBoxYonDegis.Name = "chBoxYonDegis";
            this.chBoxYonDegis.Properties.Caption = "Yön Değiştir";
            this.chBoxYonDegis.Size = new System.Drawing.Size(75, 19);
            this.chBoxYonDegis.TabIndex = 1;
            // 
            // lookGrafikSecimi
            // 
            this.lookGrafikSecimi.Location = new System.Drawing.Point(9, 6);
            this.lookGrafikSecimi.Name = "lookGrafikSecimi";
            this.lookGrafikSecimi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrafikSecimi.Properties.NullText = "Grafik Seçin";
            this.lookGrafikSecimi.Size = new System.Drawing.Size(100, 20);
            this.lookGrafikSecimi.TabIndex = 0;
            this.lookGrafikSecimi.EditValueChanged += new System.EventHandler(this.lookGrafikSecimi_EditValueChanged);
            // 
            // compNavBarAutoHeight1
            // 
            this.compNavBarAutoHeight1.DockingGroup = this.nBGRbSonuc;
            this.compNavBarAutoHeight1.MyNavBarControl = this.nbCntSurecArama;
            // 
            // frmIsSurecArama
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 658);
            this.Name = "frmIsSurecArama";
            this.Text = "Ücretlendirilmiş İşler Arama Ekranı";
            this.Load += new System.EventHandler(this.frmIsSurecArama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDurmaNeden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTarih.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKlasor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueadliBirimNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGorev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rChMuhasebelstirilmis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspFiyat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDoviz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKullanıcı)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBuro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabCtrlPivot)).EndInit();
            this.tabCtrlPivot.ResumeLayout(false);
            this.tabPGenel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nbCntSurecArama)).EndInit();
            this.nbCntSurecArama.ResumeLayout(false);
            this.nbGrbCntAramaKriter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueDosya.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueModul.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEsasNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGorev.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAdliye.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMuhatab.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBitisZmn.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBitisZmn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBaslangic.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBaslangic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePlanlayan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueIsSurec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueIsSozlesme.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLoutButon)).EndInit();
            this.pnlLoutButon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lytCntButonlasr)).EndInit();
            this.lytCntButonlasr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lytGrbButonlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chMuhasebelestirlmis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chIsDurum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueKategori.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIsBitisT.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIsBitisT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIsOngorulenBitisT.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIsOngorulenBitisT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIsBaslangicT.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIsBaslangicT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSorumlu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenelKriter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sorumlu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaslangicZmn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BitisZmn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sozlesme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Surec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcntIsKriter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaslangicT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Muhatab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsBitisT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Planlayan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ÖngorulenBitisT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Butonlar)).EndInit();
            this.nbGrbCntSonuc.ResumeLayout(false);
            this.tabPPivot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlPivot)).EndInit();
            this.pnlPivot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chBoxSutunToplami.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chBoxSatirToplami.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chBoxYonDegis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrafikSecimi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraNavBar.NavBarControl nbCntSurecArama;
        private DevExpress.XtraNavBar.NavBarGroup nbGrbSorgu;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer nbGrbCntAramaKriter;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer nbGrbCntSonuc;
        private DevExpress.XtraNavBar.NavBarGroup nBGRbSonuc;
        private AdimAdimDavaKaydi.Util.compNavBarAutoHeight compNavBarAutoHeight1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit lueIsSurec;
        private DevExpress.XtraEditors.DateEdit dtBitisZmn;
        private DevExpress.XtraEditors.DateEdit dtBaslangic;
        private DevExpress.XtraEditors.LookUpEdit lueSorumlu;
        private DevExpress.XtraLayout.LayoutControlItem Sorumlu;
        private DevExpress.XtraEditors.CheckEdit chMuhasebelestirlmis;
        private DevExpress.XtraEditors.LookUpEdit lueIsSozlesme;
        private DevExpress.XtraLayout.LayoutControlGroup GenelKriter;
        private DevExpress.XtraLayout.LayoutControlGroup lcntIsKriter;
        private DevExpress.XtraEditors.DateEdit dtIsBitisT;
        private DevExpress.XtraEditors.DateEdit dtIsOngorulenBitisT;
        private DevExpress.XtraEditors.DateEdit dtIsBaslangicT;
        private DevExpress.XtraLayout.LayoutControlItem BaslangicT;
        private DevExpress.XtraLayout.LayoutControlItem ÖngorulenBitisT;
        private DevExpress.XtraLayout.LayoutControlItem IsBitisT;
        private DevExpress.XtraEditors.LookUpEdit lueKategori;
        private DevExpress.XtraLayout.LayoutControlItem Kategori;
        private DevExpress.XtraEditors.PanelControl pnlLoutButon;
        private DevExpress.XtraLayout.LayoutControl lytCntButonlasr;
        private DevExpress.XtraEditors.SimpleButton btnSorgula;
        private DevExpress.XtraEditors.SimpleButton btnTemizle;
        private DevExpress.XtraLayout.LayoutControlGroup lytGrbButonlar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem Butonlar;
        private DevExpress.XtraTab.XtraTabControl tabCtrlPivot;
        private DevExpress.XtraTab.XtraTabPage tabPGenel;
        private DevExpress.XtraTab.XtraTabPage tabPPivot;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.CheckEdit chIsDurum;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private ExtendedGridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraEditors.LookUpEdit luePlanlayan;
        private DevExpress.XtraLayout.LayoutControlItem Planlayan;
        private DevExpress.XtraEditors.LookUpEdit lueMuhatab;
        private DevExpress.XtraLayout.LayoutControlItem Muhatab;
        private DevExpress.XtraLayout.LayoutControlItem BaslangicZmn;
        private DevExpress.XtraEditors.TextEdit txtEsasNo;
        private DevExpress.XtraEditors.LookUpEdit lueGorev;
        private DevExpress.XtraEditors.LookUpEdit lueAdliye;
        private DevExpress.XtraEditors.LookUpEdit lueNo;
        private DevExpress.XtraLayout.LayoutControlItem Sozlesme;
        private DevExpress.XtraLayout.LayoutControlItem Surec;
        private DevExpress.XtraLayout.LayoutControlItem BitisZmn;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.LookUpEdit lueDosya;
        private DevExpress.XtraEditors.LookUpEdit lueModul;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraGrid.Columns.GridColumn colIS_SORUMLU;
        private DevExpress.XtraGrid.Columns.GridColumn colIS_SUREC;
        private DevExpress.XtraGrid.Columns.GridColumn colIS_SOZLESME;
        private DevExpress.XtraGrid.Columns.GridColumn colMADDE_KALEM;
        private DevExpress.XtraGrid.Columns.GridColumn colIS_DURUM;
        private DevExpress.XtraGrid.Columns.GridColumn colIS_BASLANGIC_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colIS_ON_GORULEN_BITIS_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colIS_BITIS_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colIS_KATEGORI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colIS_PLANLAYAN;
        private DevExpress.XtraGrid.Columns.GridColumn colIS_MUHATABI;
        private DevExpress.XtraGrid.Columns.GridColumn colIS_KLASOR_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colIS_ADLI_BIRIM_ADLIYE;
        private DevExpress.XtraGrid.Columns.GridColumn colIS_ADLI_BIRIM_GOREV;
        private DevExpress.XtraGrid.Columns.GridColumn colIS_ADLI_BIRIM_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colIS_ESAS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colBASLANGIC_ZAMANI;
        private DevExpress.XtraGrid.Columns.GridColumn colBITIS_ZAMANI;
        private DevExpress.XtraGrid.Columns.GridColumn colSUREC_ACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn colMUHASEBELESTILMIS_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colSURE;
        private DevExpress.XtraGrid.Columns.GridColumn colBIRIM_FIYAT;
        private DevExpress.XtraGrid.Columns.GridColumn colBIRIM_FIYAT_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTOPLAM_FIYAT;
        private DevExpress.XtraGrid.Columns.GridColumn colTOPLAM_FIYAT_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colKONTROL_KIM_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSUBE_KOD_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dtTarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueKategori;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueKlasor;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliye;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueadliBirimNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rChMuhasebelstirilmis;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspFiyat;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDoviz;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueKullanıcı;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBuro;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueGorev;
        private DevExpress.XtraEditors.PanelControl pnlPivot;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private ExtendedPivotControl pivotGridControl1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.CheckEdit chBoxSutunToplami;
        private DevExpress.XtraEditors.CheckEdit chBoxSatirToplami;
        private DevExpress.XtraEditors.CheckEdit chBoxYonDegis;
        private DevExpress.XtraEditors.LookUpEdit lookGrafikSecimi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colDURMA_NEDENI;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDurmaNeden;
        private DevExpress.XtraGrid.Columns.GridColumn colBASLAMA_TARIH_ZAMAN;
        private DevExpress.XtraGrid.Columns.GridColumn colDURMA_TARIH_ZAMAN;
        private DevExpress.XtraGrid.Columns.GridColumn colDURMA_ACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn colOZEL_ALAN;
    }
}