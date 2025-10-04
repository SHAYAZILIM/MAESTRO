using AvukatProLib2.Entities;
namespace AdimAdimDavaKaydi.Forms
{
    partial class frmKlasorYeni
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKlasorYeni));
            this.gvBorcluTarafVekil = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rbtnBorcluTemsilEkle = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueBorcluVekil = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueTemsilSekli = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcBorclu = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gwBorclu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBorcluAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueTarafCariB = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueBorcluTemsil = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvAlacakliTarafVekil = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTEMSIL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rbtnTemsilEkle = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colAVUKAT_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAlacakliAvukat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTEMSIL_SEKLI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAlacakliTemsilSekli = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcAlacak = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gwAlacak = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueTarafCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueAlacakliTemsil = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.bndProje = new System.Windows.Forms.BindingSource(this.components);
            this.pnlKlasor = new DevExpress.XtraEditors.PanelControl();
            this.lcProjeEkrani = new DevExpress.XtraLayout.LayoutControl();
            this.dateBeklenenBitisTarihi = new DevExpress.XtraEditors.DateEdit();
            this.spinKazanmaOrani = new DevExpress.XtraEditors.SpinEdit();
            this.txtRef3 = new DevExpress.XtraEditors.TextEdit();
            this.txtRef2 = new DevExpress.XtraEditors.TextEdit();
            this.txtRef1 = new DevExpress.XtraEditors.TextEdit();
            this.lueOzelKod4 = new AdimAdimDavaKaydi.Util.ExtendedLookUpEdit();
            this.lueOzelKod2 = new AdimAdimDavaKaydi.Util.ExtendedLookUpEdit();
            this.lueOzelKod3 = new AdimAdimDavaKaydi.Util.ExtendedLookUpEdit();
            this.lueOzelKod1 = new AdimAdimDavaKaydi.Util.ExtendedLookUpEdit();
            this.lueKrediGrubu = new DevExpress.XtraEditors.LookUpEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnTahsilatlariDagit = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnMasraflariDagit = new DevExpress.XtraEditors.SimpleButton();
            this.gcDagitilmamisTahsilatlar = new DevExpress.XtraGrid.GridControl();
            this.gvDagitilmamisTahsilatlar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rspTutarDagitilmisTahsilat = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueDovizDagitilmisTahsilat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcDagitilmamisMasraflar = new DevExpress.XtraGrid.GridControl();
            this.gvDagitilmamisMasraflar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueCariDagitilmamis = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rspTutarDagitilmamis = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcMasraflar = new DevExpress.XtraGrid.GridControl();
            this.gvMasraflar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTutar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rspTutar = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridColDosyaBilgisi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOdemeler = new DevExpress.XtraGrid.GridControl();
            this.gvOdemeler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueCariOdeme = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rspTutarOdeme = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueDovizTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueOdemeYeri = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueOdemeTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColDosyaBilgisiOdeme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTeklifKarar = new DevExpress.XtraGrid.GridControl();
            this.bndTeklifKarar = new System.Windows.Forms.BindingSource(this.components);
            this.gvTeklifKarar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTEKLIF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColKARAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucbelgetakip1 = new AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge.ucbelgetakip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcMaster = new DevExpress.XtraGrid.GridControl();
            this.gvMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTAAHHUT_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAAHHUT_EDEN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueProjeTaraf = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTAAHHUDU_KABUL_EDEN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAAHHUT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAAHHUDU_KABUL_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDAVASI_VAR_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDAVA_FOY_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRESMI_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGECERLI_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAAHHUT_SIRA_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupTaahhutDetay = new DevExpress.XtraEditors.GroupControl();
            this.gcChild = new DevExpress.XtraGrid.GridControl();
            this.gvChild = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSIRA_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDURUM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueTaahhutDurum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTAAHHUTU_YERINE_GETIRME_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAAHHUT_MIKTARI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueDoviz = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTAAHHUT_MIKTARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAAHHUTTEN_KALAN_MIKTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_MIKTARI_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEME_MIKTARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKAYIT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vgCChild = new DevExpress.XtraVerticalGrid.VGridControl();
            this.ucGorevler1 = new AdimAdimDavaKaydi.Is.UserControls.ucGorevGrid();
            this.gcGenelNotlar = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gvGenelNotlar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnNotAlan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnNotlar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueNotAlan = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.sbtnBul = new DevExpress.XtraEditors.SimpleButton();
            this.lueAra = new AdimAdimDavaKaydi.Util.ExtendedLookUpEdit();
            this.dtHesapKatTarihi = new DevExpress.XtraEditors.DateEdit();
            this.gcTaraflar = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueProjeTarafCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.ucIcraHesapCetveli1 = new AdimAdimDavaKaydi.UserControls.ucIcraHesapCetveli();
            this.pnlHesaplamaTipi = new System.Windows.Forms.Panel();
            this.lueHesapTipi = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.treeKrediHesapBilgileri = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cmsKrediBilgileri = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yeniKlasörOluşturToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klasörüSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.özelliklerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.yeniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlacak = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlacakNakit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlacakGayriNakit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlacakGayriNakitMektup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlacakGayriNakitCekTaahhut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlacakGayriNakitAkreditif = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlacakGayriNakitAval = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlacakGayriNakitDiger = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacak = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakCek = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakBono = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakPolice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTeminat = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTeminatIpotek = new System.Windows.Forms.ToolStripMenuItem();
            this.havaAracıİpoteğiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gemiİpoteğiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTeminatTicariIsletmeRehni = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTeminatMenkulRehni = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTeminatMenkulRehniAracRehni = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTeminatMenkulRehniHatRehni = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTeminatMenkulRehniMarkaRehni = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTeminatMenkulRehniTicariPlakaRehni = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTeminatMenkulRehniHisseSenediRehni = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTeminatMenkulRehniKambiyoSenedi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTeminatMenkulRehniKambiyoSenediBono = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTeminatMenkulRehniKambiyoSenediPolice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTeminatMenkulRehniKambiyoSenediCek = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTeminatMenkulRehniDigerMenkulRehni = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTeminatTeminatSenedi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSozlesme = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSozlesmeGenelKrediSozlesmesi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSozlesmeGenelKrediTaahhutname = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSozlesmeBankacilikHizmetSozlesmesi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSozlesmeKonutKrediSozlesmesi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSozlesmeIhtiyacKrediSozlesmesi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSozlesmeTasitKrediSozlesmesi = new System.Windows.Forms.ToolStripMenuItem();
            this.noterdenBorçİkrarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resenDüzenlenmişNoterSenediToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avukatlıkKm35AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTakipler = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTakiplerKlasoreGirilmisAlacaklardanTakipOlustur = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTakiplerYeniTakipAc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDavaDosyasi = new System.Windows.Forms.ToolStripMenuItem();
            this.davacıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.davalıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSorusturma = new System.Windows.Forms.ToolStripMenuItem();
            this.şikayetEdenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.şikayetEdilenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCizik2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiIhtiyatiHaciz = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiIhtiyatiTedbir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCizik = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiOdeme = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMasraf = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMalHakGirisi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIlamGirisi = new System.Windows.Forms.ToolStripMenuItem();
            this.ihtarnameGirişiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.munzamSenetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tazminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlacakDuzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmihtiyatiTedbirDuzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIlamBilgisiDuzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIhtiyatiHacizDuzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIhtiyatiHacizDilekcesi = new System.Windows.Forms.ToolStripMenuItem();
            this.ihtarnameDüzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmkiymetliEvrakBilgileriDuzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.ödemeyiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masrafDüzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ağacınTümünüAçToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ağacıTamamenKapatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aporToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klasörAğaçRaporuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordeGönderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exceleGönderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDFeGönderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporDüzenleyicisineGönderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imgKlasor = new System.Windows.Forms.ImageList(this.components);
            this.lueBolum = new DevExpress.XtraEditors.LookUpEdit();
            this.memAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.lueDurum = new DevExpress.XtraEditors.LookUpEdit();
            this.dtKapamaTarihi = new DevExpress.XtraEditors.DateEdit();
            this.dtIntikalTarihi = new DevExpress.XtraEditors.DateEdit();
            this.txtAd = new DevExpress.XtraEditors.TextEdit();
            this.txtKod = new DevExpress.XtraEditors.TextEdit();
            this.lueSube = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lcItemHesapKatTarihi = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcItemAra = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcItemBul = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcGroupBilgiler = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup2 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup10 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcItemYapilacakIsler = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup9 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcItemKrediHesapBilgileri = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcItemKodu = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcItemIntikalTarihi = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcItemAdi = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcItemDurum = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcItemKapamaTarihi = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcItemBolum = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcItemProjeAciklama = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcItemSube = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcItemKrediGrubu = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcItemTaraflar = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup8 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcItemKlasorHesabi = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup11 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcItemGenelNotlar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcGorupOdemePlani = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcItemOdemePlani = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcGroupDokumanlar = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcItemDokumanlar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcGroupTeklifKarar = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcItemTeklifKarar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcGroupMasraflar = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcItemMasraflar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcGroupOdemeler = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcItemOdemeler = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcGroupDagitilmamisMasraflar = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcItemDagitilmamisMasraflar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcItemMasraflariDagit = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcGroupDagitilmamisTahsilatlar = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcItemDagitilmamisTahsilatlar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcItemTahsilatlariDagit = new DevExpress.XtraLayout.LayoutControlItem();
            this.aV001TDIEBILPROJESORUMLUCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bndTaahhutMaster = new System.Windows.Forms.BindingSource(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnDuzenle = new DevExpress.XtraEditors.SimpleButton();
            this.gcIletisimBilgileri = new DevExpress.XtraGrid.GridControl();
            this.lvIletisimBilgileri = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.lvcAdres = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.rlueAdres = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.layoutViewField_layoutViewColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcIlce = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_3 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcIl = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_4 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcTel1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_6 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcTel2 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_7 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcCepTel1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_10 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcEmail1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_12 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcVergiDairesi = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_14 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcVergiNo = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_15 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcTcKimlikNo = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcBabaAdi = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcDogumTarihi = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_5 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcAnneKizlikSoyadi = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_8 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvcMusteriNo = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_9 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.rlueIlce = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueIl = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcSorumlu = new DevExpress.XtraGrid.GridControl();
            this.gwSorumluAvk = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueSorumlu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgIletisimBilgileri = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciIletisimBilgileri = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSorumlu = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBorclu = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvBorcluTarafVekil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnBorcluTemsilEkle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBorcluVekil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTemsilSekli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBorclu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwBorclu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafCariB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBorcluTemsil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAlacakliTarafVekil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnTemsilEkle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakliAvukat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakliTemsilSekli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAlacak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwAlacak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAlacakliTemsil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndProje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKlasor)).BeginInit();
            this.pnlKlasor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcProjeEkrani)).BeginInit();
            this.lcProjeEkrani.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateBeklenenBitisTarihi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBeklenenBitisTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinKazanmaOrani.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRef3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRef2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRef1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOzelKod4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOzelKod2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOzelKod3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOzelKod1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueKrediGrubu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDagitilmamisTahsilatlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDagitilmamisTahsilatlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspTutarDagitilmisTahsilat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDovizDagitilmisTahsilat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDagitilmamisMasraflar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDagitilmamisMasraflar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCariDagitilmamis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspTutarDagitilmamis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMasraflar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMasraflar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspTutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOdemeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOdemeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCariOdeme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspTutarOdeme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDovizTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueOdemeYeri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueOdemeTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTeklifKarar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndTeklifKarar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTeklifKarar)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueProjeTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupTaahhutDetay)).BeginInit();
            this.groupTaahhutDetay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcChild)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChild)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTaahhutDurum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDoviz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgCChild)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGenelNotlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenelNotlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueNotAlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHesapKatTarihi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHesapKatTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTaraflar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueProjeTarafCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.pnlHesaplamaTipi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueHesapTipi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeKrediHesapBilgileri)).BeginInit();
            this.cmsKrediBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueBolum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDurum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKapamaTarihi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKapamaTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIntikalTarihi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIntikalTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSube.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemHesapKatTarihi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemAra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemBul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupBilgiler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemYapilacakIsler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemKrediHesapBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemKodu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemIntikalTarihi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemAdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemDurum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemKapamaTarihi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemBolum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemProjeAciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemSube)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemKrediGrubu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemTaraflar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemKlasorHesabi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemGenelNotlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGorupOdemePlani)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemOdemePlani)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupDokumanlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemDokumanlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupTeklifKarar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemTeklifKarar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupMasraflar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemMasraflar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupOdemeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemOdemeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupDagitilmamisMasraflar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemDagitilmamisMasraflar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemMasraflariDagit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupDagitilmamisTahsilatlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemDagitilmamisTahsilatlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemTahsilatlariDagit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TDIEBILPROJESORUMLUCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndTaahhutMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcIletisimBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvIletisimBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAdres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueIlce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueIl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSorumlu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwSorumluAvk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSorumlu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgIletisimBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIletisimBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSorumlu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBorclu)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 638);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(1019, 10);
            // 
            // c_pnlFormSakla
            // 
            this.c_pnlFormSakla.Size = new System.Drawing.Size(343, 10);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(869, 0);
            this.c_btnIptal.Size = new System.Drawing.Size(75, 10);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(944, 0);
            this.c_btnTamam.Size = new System.Drawing.Size(75, 10);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.pnlKlasor);
            this.c_pnlContainer.Size = new System.Drawing.Size(1019, 648);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.pnlKlasor, 0);
            // 
            // gvBorcluTarafVekil
            // 
            this.gvBorcluTarafVekil.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn31,
            this.gridColumn32,
            this.gridColumn33});
            this.gvBorcluTarafVekil.GridControl = this.gcBorclu;
            this.gvBorcluTarafVekil.Name = "gvBorcluTarafVekil";
            this.gvBorcluTarafVekil.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gvBorcluTarafVekil.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvBorcluTarafVekil.OptionsView.ShowGroupPanel = false;
            this.gvBorcluTarafVekil.ViewCaption = "Taraf Vekilleri";
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "Temsil";
            this.gridColumn31.ColumnEdit = this.rbtnBorcluTemsilEkle;
            this.gridColumn31.FieldName = "TEMSIL_ID";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 0;
            // 
            // rbtnBorcluTemsilEkle
            // 
            this.rbtnBorcluTemsilEkle.AllowFocused = false;
            this.rbtnBorcluTemsilEkle.AutoHeight = false;
            this.rbtnBorcluTemsilEkle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rbtnBorcluTemsilEkle.Name = "rbtnBorcluTemsilEkle";
            this.rbtnBorcluTemsilEkle.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "Vekil";
            this.gridColumn32.ColumnEdit = this.rLueBorcluVekil;
            this.gridColumn32.FieldName = "AVUKAT_CARI_ID";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 1;
            // 
            // rLueBorcluVekil
            // 
            this.rLueBorcluVekil.AutoHeight = false;
            this.rLueBorcluVekil.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBorcluVekil.Name = "rLueBorcluVekil";
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "Şekil";
            this.gridColumn33.ColumnEdit = this.rLueTemsilSekli;
            this.gridColumn33.FieldName = "TEMSIL_SEKLI_ID";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 2;
            // 
            // rLueTemsilSekli
            // 
            this.rLueTemsilSekli.AutoHeight = false;
            this.rLueTemsilSekli.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueTemsilSekli.Name = "rLueTemsilSekli";
            // 
            // gcBorclu
            // 
            this.gcBorclu.CustomButtonlarGorunmesin = false;
            this.gcBorclu.DoNotExtendEmbedNavigator = false;
            this.gcBorclu.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcBorclu.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcBorclu.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gcBorclu.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gcBorclu.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gcBorclu.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gcBorclu.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcBorclu.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gcBorclu_EmbeddedNavigator_ButtonClick);
            this.gcBorclu.FilterText = null;
            this.gcBorclu.FilterValue = null;
            this.gcBorclu.GridlerDuzenlenebilir = true;
            this.gcBorclu.GridsFilterControl = null;
            this.gcBorclu.Location = new System.Drawing.Point(12, 216);
            this.gcBorclu.MainView = this.gwBorclu;
            this.gcBorclu.MyGridStyle = null;
            this.gcBorclu.Name = "gcBorclu";
            this.gcBorclu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueBorcluTemsil,
            this.rLueBorcluVekil,
            this.rLueTemsilSekli,
            this.rbtnBorcluTemsilEkle,
            this.rLueTarafCariB});
            this.gcBorclu.ShowOnlyPredefinedDetails = true;
            this.gcBorclu.ShowRowNumbers = false;
            this.gcBorclu.SilmeKaldirilsin = false;
            this.gcBorclu.Size = new System.Drawing.Size(304, 98);
            this.gcBorclu.TabIndex = 8;
            this.gcBorclu.TemizleKaldirGorunsunmu = false;
            this.gcBorclu.UniqueId = "2a174c5f-ca6c-4dd3-8707-603ec062fc68";
            this.gcBorclu.UseEmbeddedNavigator = true;
            this.gcBorclu.UseHyperDragDrop = false;
            this.gcBorclu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwBorclu,
            this.gvBorcluTarafVekil});
            // 
            // gwBorclu
            // 
            this.gwBorclu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBorcluAdi});
            this.gwBorclu.GridControl = this.gcBorclu;
            this.gwBorclu.IndicatorWidth = 20;
            this.gwBorclu.Name = "gwBorclu";
            this.gwBorclu.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwBorclu.OptionsDetail.AutoZoomDetail = true;
            this.gwBorclu.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gwBorclu.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gwBorclu.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gwBorclu.OptionsView.ShowGroupPanel = false;
            this.gwBorclu.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gwBorclu_RowClick);
            this.gwBorclu.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gwBorclu_FocusedRowChanged);
            // 
            // colBorcluAdi
            // 
            this.colBorcluAdi.Caption = "Borçlu Adı";
            this.colBorcluAdi.ColumnEdit = this.rLueTarafCariB;
            this.colBorcluAdi.FieldName = "CARI_ID";
            this.colBorcluAdi.Name = "colBorcluAdi";
            this.colBorcluAdi.OptionsColumn.AllowEdit = false;
            this.colBorcluAdi.OptionsColumn.ReadOnly = true;
            this.colBorcluAdi.Visible = true;
            this.colBorcluAdi.VisibleIndex = 0;
            this.colBorcluAdi.Width = 176;
            // 
            // rLueTarafCariB
            // 
            this.rLueTarafCariB.AutoHeight = false;
            this.rLueTarafCariB.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueTarafCariB.Name = "rLueTarafCariB";
            // 
            // rLueBorcluTemsil
            // 
            this.rLueBorcluTemsil.AutoHeight = false;
            this.rLueBorcluTemsil.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueBorcluTemsil.Name = "rLueBorcluTemsil";
            // 
            // gvAlacakliTarafVekil
            // 
            this.gvAlacakliTarafVekil.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTEMSIL_ID,
            this.colAVUKAT_CARI_ID,
            this.colTEMSIL_SEKLI_ID});
            this.gvAlacakliTarafVekil.GridControl = this.gcAlacak;
            this.gvAlacakliTarafVekil.Name = "gvAlacakliTarafVekil";
            this.gvAlacakliTarafVekil.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gvAlacakliTarafVekil.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvAlacakliTarafVekil.OptionsView.ShowGroupPanel = false;
            this.gvAlacakliTarafVekil.ViewCaption = "Taraf Vekilleri";
            // 
            // colTEMSIL_ID
            // 
            this.colTEMSIL_ID.Caption = "Temsil";
            this.colTEMSIL_ID.ColumnEdit = this.rbtnTemsilEkle;
            this.colTEMSIL_ID.FieldName = "TEMSIL_ID";
            this.colTEMSIL_ID.Name = "colTEMSIL_ID";
            this.colTEMSIL_ID.Visible = true;
            this.colTEMSIL_ID.VisibleIndex = 0;
            // 
            // rbtnTemsilEkle
            // 
            this.rbtnTemsilEkle.AutoHeight = false;
            this.rbtnTemsilEkle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rbtnTemsilEkle.Name = "rbtnTemsilEkle";
            this.rbtnTemsilEkle.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // colAVUKAT_CARI_ID
            // 
            this.colAVUKAT_CARI_ID.Caption = "Vekil";
            this.colAVUKAT_CARI_ID.ColumnEdit = this.rLueAlacakliAvukat;
            this.colAVUKAT_CARI_ID.FieldName = "AVUKAT_CARI_ID";
            this.colAVUKAT_CARI_ID.Name = "colAVUKAT_CARI_ID";
            this.colAVUKAT_CARI_ID.Visible = true;
            this.colAVUKAT_CARI_ID.VisibleIndex = 1;
            // 
            // rLueAlacakliAvukat
            // 
            this.rLueAlacakliAvukat.AutoHeight = false;
            this.rLueAlacakliAvukat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAlacakliAvukat.Name = "rLueAlacakliAvukat";
            // 
            // colTEMSIL_SEKLI_ID
            // 
            this.colTEMSIL_SEKLI_ID.Caption = "Şekil";
            this.colTEMSIL_SEKLI_ID.ColumnEdit = this.rLueAlacakliTemsilSekli;
            this.colTEMSIL_SEKLI_ID.FieldName = "TEMSIL_SEKLI_ID";
            this.colTEMSIL_SEKLI_ID.Name = "colTEMSIL_SEKLI_ID";
            this.colTEMSIL_SEKLI_ID.Visible = true;
            this.colTEMSIL_SEKLI_ID.VisibleIndex = 2;
            // 
            // rLueAlacakliTemsilSekli
            // 
            this.rLueAlacakliTemsilSekli.AutoHeight = false;
            this.rLueAlacakliTemsilSekli.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAlacakliTemsilSekli.Name = "rLueAlacakliTemsilSekli";
            // 
            // gcAlacak
            // 
            this.gcAlacak.CustomButtonlarGorunmesin = false;
            this.gcAlacak.DoNotExtendEmbedNavigator = true;
            this.gcAlacak.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gcAlacak.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcAlacak.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gcAlacak_EmbeddedNavigator_ButtonClick);
            this.gcAlacak.FilterText = null;
            this.gcAlacak.FilterValue = null;
            this.gcAlacak.GridlerDuzenlenebilir = true;
            this.gcAlacak.GridsFilterControl = null;
            this.gcAlacak.Location = new System.Drawing.Point(12, 12);
            this.gcAlacak.MainView = this.gwAlacak;
            this.gcAlacak.MyGridStyle = null;
            this.gcAlacak.Name = "gcAlacak";
            this.gcAlacak.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueAlacakliTemsil,
            this.rLueAlacakliAvukat,
            this.rLueAlacakliTemsilSekli,
            this.rbtnTemsilEkle,
            this.rLueTarafCari});
            this.gcAlacak.ShowOnlyPredefinedDetails = true;
            this.gcAlacak.ShowRowNumbers = false;
            this.gcAlacak.SilmeKaldirilsin = false;
            this.gcAlacak.Size = new System.Drawing.Size(304, 98);
            this.gcAlacak.TabIndex = 7;
            this.gcAlacak.TemizleKaldirGorunsunmu = false;
            this.gcAlacak.UniqueId = "1e8255cf-994e-4049-b388-10999233c346";
            this.gcAlacak.UseEmbeddedNavigator = true;
            this.gcAlacak.UseHyperDragDrop = false;
            this.gcAlacak.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwAlacak,
            this.gvAlacakliTarafVekil});
            // 
            // gwAlacak
            // 
            this.gwAlacak.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn38});
            this.gwAlacak.GridControl = this.gcAlacak;
            this.gwAlacak.IndicatorWidth = 20;
            this.gwAlacak.Name = "gwAlacak";
            this.gwAlacak.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwAlacak.OptionsDetail.AutoZoomDetail = true;
            this.gwAlacak.OptionsView.ShowGroupPanel = false;
            this.gwAlacak.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gwAlacak_RowClick);
            this.gwAlacak.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gwAlacak_FocusedRowChanged);
            // 
            // gridColumn38
            // 
            this.gridColumn38.Caption = "Alacaklı Adı";
            this.gridColumn38.ColumnEdit = this.rLueTarafCari;
            this.gridColumn38.FieldName = "CARI_ID";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.OptionsColumn.AllowEdit = false;
            this.gridColumn38.OptionsColumn.ReadOnly = true;
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 0;
            this.gridColumn38.Width = 176;
            // 
            // rLueTarafCari
            // 
            this.rLueTarafCari.AutoHeight = false;
            this.rLueTarafCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueTarafCari.Name = "rLueTarafCari";
            // 
            // rlueAlacakliTemsil
            // 
            this.rlueAlacakliTemsil.AutoHeight = false;
            this.rlueAlacakliTemsil.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueAlacakliTemsil.Name = "rlueAlacakliTemsil";
            // 
            // bndProje
            // 
            this.bndProje.DataSource = typeof(AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE>);
            // 
            // pnlKlasor
            // 
            this.pnlKlasor.Controls.Add(this.lcProjeEkrani);
            this.pnlKlasor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKlasor.Location = new System.Drawing.Point(0, 0);
            this.pnlKlasor.Name = "pnlKlasor";
            this.pnlKlasor.Size = new System.Drawing.Size(1019, 638);
            this.pnlKlasor.TabIndex = 10;
            // 
            // lcProjeEkrani
            // 
            this.lcProjeEkrani.Controls.Add(this.dateBeklenenBitisTarihi);
            this.lcProjeEkrani.Controls.Add(this.spinKazanmaOrani);
            this.lcProjeEkrani.Controls.Add(this.txtRef3);
            this.lcProjeEkrani.Controls.Add(this.txtRef2);
            this.lcProjeEkrani.Controls.Add(this.txtRef1);
            this.lcProjeEkrani.Controls.Add(this.lueOzelKod4);
            this.lcProjeEkrani.Controls.Add(this.lueOzelKod2);
            this.lcProjeEkrani.Controls.Add(this.lueOzelKod3);
            this.lcProjeEkrani.Controls.Add(this.lueOzelKod1);
            this.lcProjeEkrani.Controls.Add(this.lueKrediGrubu);
            this.lcProjeEkrani.Controls.Add(this.simpleButton1);
            this.lcProjeEkrani.Controls.Add(this.sbtnTahsilatlariDagit);
            this.lcProjeEkrani.Controls.Add(this.sbtnMasraflariDagit);
            this.lcProjeEkrani.Controls.Add(this.gcDagitilmamisTahsilatlar);
            this.lcProjeEkrani.Controls.Add(this.gcDagitilmamisMasraflar);
            this.lcProjeEkrani.Controls.Add(this.gcMasraflar);
            this.lcProjeEkrani.Controls.Add(this.gcOdemeler);
            this.lcProjeEkrani.Controls.Add(this.gcTeklifKarar);
            this.lcProjeEkrani.Controls.Add(this.panel2);
            this.lcProjeEkrani.Controls.Add(this.panel1);
            this.lcProjeEkrani.Controls.Add(this.ucGorevler1);
            this.lcProjeEkrani.Controls.Add(this.gcGenelNotlar);
            this.lcProjeEkrani.Controls.Add(this.sbtnBul);
            this.lcProjeEkrani.Controls.Add(this.lueAra);
            this.lcProjeEkrani.Controls.Add(this.dtHesapKatTarihi);
            this.lcProjeEkrani.Controls.Add(this.gcTaraflar);
            this.lcProjeEkrani.Controls.Add(this.panelControl2);
            this.lcProjeEkrani.Controls.Add(this.treeKrediHesapBilgileri);
            this.lcProjeEkrani.Controls.Add(this.lueBolum);
            this.lcProjeEkrani.Controls.Add(this.memAciklama);
            this.lcProjeEkrani.Controls.Add(this.lueDurum);
            this.lcProjeEkrani.Controls.Add(this.dtKapamaTarihi);
            this.lcProjeEkrani.Controls.Add(this.dtIntikalTarihi);
            this.lcProjeEkrani.Controls.Add(this.txtAd);
            this.lcProjeEkrani.Controls.Add(this.txtKod);
            this.lcProjeEkrani.Controls.Add(this.lueSube);
            this.lcProjeEkrani.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcProjeEkrani.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemHesapKatTarihi});
            this.lcProjeEkrani.Location = new System.Drawing.Point(2, 2);
            this.lcProjeEkrani.Name = "lcProjeEkrani";
            this.lcProjeEkrani.Root = this.layoutControlGroup1;
            this.lcProjeEkrani.Size = new System.Drawing.Size(1015, 634);
            this.lcProjeEkrani.TabIndex = 1;
            this.lcProjeEkrani.Text = "layoutControl1";
            // 
            // dateBeklenenBitisTarihi
            // 
            this.dateBeklenenBitisTarihi.EditValue = null;
            this.dateBeklenenBitisTarihi.Location = new System.Drawing.Point(740, 383);
            this.dateBeklenenBitisTarihi.Name = "dateBeklenenBitisTarihi";
            this.dateBeklenenBitisTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBeklenenBitisTarihi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateBeklenenBitisTarihi.Size = new System.Drawing.Size(227, 20);
            this.dateBeklenenBitisTarihi.StyleController = this.lcProjeEkrani;
            this.dateBeklenenBitisTarihi.TabIndex = 147;
            // 
            // spinKazanmaOrani
            // 
            this.spinKazanmaOrani.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinKazanmaOrani.Location = new System.Drawing.Point(528, 383);
            this.spinKazanmaOrani.Name = "spinKazanmaOrani";
            this.spinKazanmaOrani.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinKazanmaOrani.Size = new System.Drawing.Size(111, 20);
            this.spinKazanmaOrani.StyleController = this.lcProjeEkrani;
            this.spinKazanmaOrani.TabIndex = 146;
            // 
            // txtRef3
            // 
            this.txtRef3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndProje, "REFERANS_NO3", true));
            this.txtRef3.Location = new System.Drawing.Point(528, 359);
            this.txtRef3.Name = "txtRef3";
            this.txtRef3.Size = new System.Drawing.Size(439, 20);
            this.txtRef3.StyleController = this.lcProjeEkrani;
            this.txtRef3.TabIndex = 145;
            // 
            // txtRef2
            // 
            this.txtRef2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndProje, "REFERANS_NO2", true));
            this.txtRef2.Location = new System.Drawing.Point(528, 335);
            this.txtRef2.Name = "txtRef2";
            this.txtRef2.Size = new System.Drawing.Size(439, 20);
            this.txtRef2.StyleController = this.lcProjeEkrani;
            this.txtRef2.TabIndex = 145;
            // 
            // txtRef1
            // 
            this.txtRef1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndProje, "REFERANS_NO1", true));
            this.txtRef1.Location = new System.Drawing.Point(528, 311);
            this.txtRef1.Name = "txtRef1";
            this.txtRef1.Size = new System.Drawing.Size(439, 20);
            this.txtRef1.StyleController = this.lcProjeEkrani;
            this.txtRef1.TabIndex = 145;
            // 
            // lueOzelKod4
            // 
            this.lueOzelKod4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndProje, "OZEL_KOD4_ID", true));
            this.lueOzelKod4.Location = new System.Drawing.Point(800, 287);
            this.lueOzelKod4.Name = "lueOzelKod4";
            this.lueOzelKod4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueOzelKod4.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueOzelKod4.Size = new System.Drawing.Size(167, 20);
            this.lueOzelKod4.StyleController = this.lcProjeEkrani;
            this.lueOzelKod4.TabIndex = 145;
            this.lueOzelKod4.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueOzelKod4_ButtonClick);
            // 
            // lueOzelKod2
            // 
            this.lueOzelKod2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndProje, "OZEL_KOD2_ID", true));
            this.lueOzelKod2.Location = new System.Drawing.Point(800, 263);
            this.lueOzelKod2.Name = "lueOzelKod2";
            this.lueOzelKod2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueOzelKod2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueOzelKod2.Size = new System.Drawing.Size(167, 20);
            this.lueOzelKod2.StyleController = this.lcProjeEkrani;
            this.lueOzelKod2.TabIndex = 145;
            this.lueOzelKod2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueOzelKod2_ButtonClick);
            // 
            // lueOzelKod3
            // 
            this.lueOzelKod3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndProje, "OZEL_KOD3_ID", true));
            this.lueOzelKod3.Location = new System.Drawing.Point(528, 287);
            this.lueOzelKod3.Name = "lueOzelKod3";
            this.lueOzelKod3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueOzelKod3.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueOzelKod3.Size = new System.Drawing.Size(171, 20);
            this.lueOzelKod3.StyleController = this.lcProjeEkrani;
            this.lueOzelKod3.TabIndex = 145;
            this.lueOzelKod3.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueOzelKod3_ButtonClick);
            // 
            // lueOzelKod1
            // 
            this.lueOzelKod1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndProje, "OZEL_KOD1_ID", true));
            this.lueOzelKod1.Location = new System.Drawing.Point(528, 263);
            this.lueOzelKod1.Name = "lueOzelKod1";
            this.lueOzelKod1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueOzelKod1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueOzelKod1.Size = new System.Drawing.Size(171, 20);
            this.lueOzelKod1.StyleController = this.lcProjeEkrani;
            this.lueOzelKod1.TabIndex = 143;
            this.lueOzelKod1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueOzelKod1_ButtonClick);
            // 
            // lueKrediGrubu
            // 
            this.lueKrediGrubu.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndProje, "KREDI_GRUP_ID", true));
            this.lueKrediGrubu.Location = new System.Drawing.Point(528, 119);
            this.lueKrediGrubu.Name = "lueKrediGrubu";
            this.lueKrediGrubu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueKrediGrubu.Size = new System.Drawing.Size(439, 20);
            this.lueKrediGrubu.StyleController = this.lcProjeEkrani;
            this.lueKrediGrubu.TabIndex = 42;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(431, 93);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(536, 22);
            this.simpleButton1.StyleController = this.lcProjeEkrani;
            this.simpleButton1.TabIndex = 41;
            this.simpleButton1.Text = "Ticari Alacak Borçlusu";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // sbtnTahsilatlariDagit
            // 
            this.sbtnTahsilatlariDagit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnTahsilatlariDagit.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.sbtnTahsilatlariDagit.Appearance.Options.UseFont = true;
            this.sbtnTahsilatlariDagit.Appearance.Options.UseForeColor = true;
            this.sbtnTahsilatlariDagit.Location = new System.Drawing.Point(160, 62);
            this.sbtnTahsilatlariDagit.Name = "sbtnTahsilatlariDagit";
            this.sbtnTahsilatlariDagit.Size = new System.Drawing.Size(819, 22);
            this.sbtnTahsilatlariDagit.StyleController = this.lcProjeEkrani;
            this.sbtnTahsilatlariDagit.TabIndex = 40;
            this.sbtnTahsilatlariDagit.Text = "TAHSİLATLARI DAĞIT";
            this.sbtnTahsilatlariDagit.Click += new System.EventHandler(this.sbtnTahsilatlariDagit_Click);
            // 
            // sbtnMasraflariDagit
            // 
            this.sbtnMasraflariDagit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnMasraflariDagit.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.sbtnMasraflariDagit.Appearance.Options.UseFont = true;
            this.sbtnMasraflariDagit.Appearance.Options.UseForeColor = true;
            this.sbtnMasraflariDagit.Location = new System.Drawing.Point(160, 62);
            this.sbtnMasraflariDagit.Name = "sbtnMasraflariDagit";
            this.sbtnMasraflariDagit.Size = new System.Drawing.Size(819, 22);
            this.sbtnMasraflariDagit.StyleController = this.lcProjeEkrani;
            this.sbtnMasraflariDagit.TabIndex = 39;
            this.sbtnMasraflariDagit.Text = "MASRAFLARI DAĞIT";
            this.sbtnMasraflariDagit.Click += new System.EventHandler(this.sbtnMasraflariDagit_Click);
            // 
            // gcDagitilmamisTahsilatlar
            // 
            this.gcDagitilmamisTahsilatlar.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcDagitilmamisTahsilatlar.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcDagitilmamisTahsilatlar.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcDagitilmamisTahsilatlar.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcDagitilmamisTahsilatlar.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni", "Yeni")});
            this.gcDagitilmamisTahsilatlar.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gcOdemeler_EmbeddedNavigator_ButtonClick);
            this.gcDagitilmamisTahsilatlar.Location = new System.Drawing.Point(160, 88);
            this.gcDagitilmamisTahsilatlar.MainView = this.gvDagitilmamisTahsilatlar;
            this.gcDagitilmamisTahsilatlar.Name = "gcDagitilmamisTahsilatlar";
            this.gcDagitilmamisTahsilatlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rspTutarDagitilmisTahsilat,
            this.rlueDovizDagitilmisTahsilat});
            this.gcDagitilmamisTahsilatlar.Size = new System.Drawing.Size(819, 510);
            this.gcDagitilmamisTahsilatlar.TabIndex = 37;
            this.gcDagitilmamisTahsilatlar.UseEmbeddedNavigator = true;
            this.gcDagitilmamisTahsilatlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDagitilmamisTahsilatlar});
            // 
            // gvDagitilmamisTahsilatlar
            // 
            this.gvDagitilmamisTahsilatlar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn22,
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn27});
            this.gvDagitilmamisTahsilatlar.GridControl = this.gcDagitilmamisTahsilatlar;
            this.gvDagitilmamisTahsilatlar.Name = "gvDagitilmamisTahsilatlar";
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "ID";
            this.gridColumn22.FieldName = "ID";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Tarih";
            this.gridColumn25.FieldName = "ODEME_TARIHI";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.OptionsColumn.ReadOnly = true;
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 0;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "Tutar";
            this.gridColumn26.ColumnEdit = this.rspTutarDagitilmisTahsilat;
            this.gridColumn26.FieldName = "ODEME_MIKTAR";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowEdit = false;
            this.gridColumn26.OptionsColumn.ReadOnly = true;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 1;
            // 
            // rspTutarDagitilmisTahsilat
            // 
            this.rspTutarDagitilmisTahsilat.AutoHeight = false;
            this.rspTutarDagitilmisTahsilat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rspTutarDagitilmisTahsilat.Name = "rspTutarDagitilmisTahsilat";
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = " ";
            this.gridColumn27.ColumnEdit = this.rlueDovizDagitilmisTahsilat;
            this.gridColumn27.FieldName = "ODEME_MIKTAR_DOVIZ_ID";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.AllowEdit = false;
            this.gridColumn27.OptionsColumn.ReadOnly = true;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 2;
            // 
            // rlueDovizDagitilmisTahsilat
            // 
            this.rlueDovizDagitilmisTahsilat.AutoHeight = false;
            this.rlueDovizDagitilmisTahsilat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueDovizDagitilmisTahsilat.Name = "rlueDovizDagitilmisTahsilat";
            // 
            // gcDagitilmamisMasraflar
            // 
            this.gcDagitilmamisMasraflar.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcDagitilmamisMasraflar.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcDagitilmamisMasraflar.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcDagitilmamisMasraflar.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcDagitilmamisMasraflar.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni", "Yeni")});
            this.gcDagitilmamisMasraflar.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gcMasraflar_EmbeddedNavigator_ButtonClick);
            this.gcDagitilmamisMasraflar.Location = new System.Drawing.Point(160, 88);
            this.gcDagitilmamisMasraflar.MainView = this.gvDagitilmamisMasraflar;
            this.gcDagitilmamisMasraflar.Name = "gcDagitilmamisMasraflar";
            this.gcDagitilmamisMasraflar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueCariDagitilmamis,
            this.rspTutarDagitilmamis});
            this.gcDagitilmamisMasraflar.Size = new System.Drawing.Size(819, 510);
            this.gcDagitilmamisMasraflar.TabIndex = 38;
            this.gcDagitilmamisMasraflar.UseEmbeddedNavigator = true;
            this.gcDagitilmamisMasraflar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDagitilmamisMasraflar});
            // 
            // gvDagitilmamisMasraflar
            // 
            this.gvDagitilmamisMasraflar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.gvDagitilmamisMasraflar.GridControl = this.gcDagitilmamisMasraflar;
            this.gvDagitilmamisMasraflar.Name = "gvDagitilmamisMasraflar";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "ID";
            this.gridColumn5.FieldName = "ID";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Referans No";
            this.gridColumn7.FieldName = "REFERANS_NO";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 72;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Masraf Yapan";
            this.gridColumn8.ColumnEdit = this.rlueCariDagitilmamis;
            this.gridColumn8.FieldName = "CARI_ID";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 90;
            // 
            // rlueCariDagitilmamis
            // 
            this.rlueCariDagitilmamis.AutoHeight = false;
            this.rlueCariDagitilmamis.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueCariDagitilmamis.Name = "rlueCariDagitilmamis";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Tarih";
            this.gridColumn9.FieldName = "KAYIT_TARIHI";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            this.gridColumn9.Width = 52;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Toplam Tutar (YTL)";
            this.gridColumn10.ColumnEdit = this.rspTutarDagitilmamis;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Tag = 2;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 65;
            // 
            // rspTutarDagitilmamis
            // 
            this.rspTutarDagitilmamis.AutoHeight = false;
            this.rspTutarDagitilmamis.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rspTutarDagitilmamis.Name = "rspTutarDagitilmamis";
            // 
            // gcMasraflar
            // 
            this.gcMasraflar.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcMasraflar.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcMasraflar.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcMasraflar.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcMasraflar.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni", "Yeni")});
            this.gcMasraflar.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gcMasraflar_EmbeddedNavigator_ButtonClick);
            this.gcMasraflar.Location = new System.Drawing.Point(160, 62);
            this.gcMasraflar.MainView = this.gvMasraflar;
            this.gcMasraflar.Name = "gcMasraflar";
            this.gcMasraflar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueCari,
            this.rspTutar});
            this.gcMasraflar.Size = new System.Drawing.Size(819, 536);
            this.gcMasraflar.TabIndex = 37;
            this.gcMasraflar.UseEmbeddedNavigator = true;
            this.gcMasraflar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMasraflar});
            // 
            // gvMasraflar
            // 
            this.gvMasraflar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn12,
            this.gridColumn6,
            this.gridColumn13,
            this.colTutar,
            this.gridColDosyaBilgisi});
            this.gvMasraflar.GridControl = this.gcMasraflar;
            this.gvMasraflar.Name = "gvMasraflar";
            this.gvMasraflar.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvMasraflar_CustomColumnDisplayText);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "ID";
            this.gridColumn4.FieldName = "ID";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Referans No";
            this.gridColumn12.FieldName = "REFERANS_NO";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 72;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Masraf Yapan";
            this.gridColumn6.ColumnEdit = this.rlueCari;
            this.gridColumn6.FieldName = "CARI_ID";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 90;
            // 
            // rlueCari
            // 
            this.rlueCari.AutoHeight = false;
            this.rlueCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueCari.Name = "rlueCari";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Tarih";
            this.gridColumn13.FieldName = "KAYIT_TARIHI";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 2;
            this.gridColumn13.Width = 52;
            // 
            // colTutar
            // 
            this.colTutar.Caption = "Toplam Tutar (YTL)";
            this.colTutar.ColumnEdit = this.rspTutar;
            this.colTutar.Name = "colTutar";
            this.colTutar.Tag = 2;
            this.colTutar.Visible = true;
            this.colTutar.VisibleIndex = 3;
            this.colTutar.Width = 65;
            // 
            // rspTutar
            // 
            this.rspTutar.AutoHeight = false;
            this.rspTutar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rspTutar.Name = "rspTutar";
            // 
            // gridColDosyaBilgisi
            // 
            this.gridColDosyaBilgisi.Caption = "Dosya No";
            this.gridColDosyaBilgisi.Name = "gridColDosyaBilgisi";
            this.gridColDosyaBilgisi.Tag = 1;
            this.gridColDosyaBilgisi.Visible = true;
            this.gridColDosyaBilgisi.VisibleIndex = 4;
            this.gridColDosyaBilgisi.Width = 55;
            // 
            // gcOdemeler
            // 
            this.gcOdemeler.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcOdemeler.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcOdemeler.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcOdemeler.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcOdemeler.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni", "Yeni")});
            this.gcOdemeler.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gcOdemeler_EmbeddedNavigator_ButtonClick);
            this.gcOdemeler.Location = new System.Drawing.Point(160, 62);
            this.gcOdemeler.MainView = this.gvOdemeler;
            this.gcOdemeler.Name = "gcOdemeler";
            this.gcOdemeler.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueCariOdeme,
            this.rspTutarOdeme,
            this.rlueDovizTip,
            this.rlueOdemeYeri,
            this.rlueOdemeTip});
            this.gcOdemeler.Size = new System.Drawing.Size(819, 536);
            this.gcOdemeler.TabIndex = 36;
            this.gcOdemeler.UseEmbeddedNavigator = true;
            this.gcOdemeler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOdemeler});
            // 
            // gvOdemeler
            // 
            this.gvOdemeler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColDosyaBilgisiOdeme});
            this.gvOdemeler.GridControl = this.gcOdemeler;
            this.gvOdemeler.Name = "gvOdemeler";
            this.gvOdemeler.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvOdemeler_CustomColumnDisplayText);
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "ID";
            this.gridColumn14.FieldName = "ID";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Borçlu";
            this.gridColumn15.ColumnEdit = this.rlueCariOdeme;
            this.gridColumn15.FieldName = "ODEYEN_CARI_ID";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 0;
            // 
            // rlueCariOdeme
            // 
            this.rlueCariOdeme.AutoHeight = false;
            this.rlueCariOdeme.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueCariOdeme.Name = "rlueCariOdeme";
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "3.Kişi";
            this.gridColumn16.ColumnEdit = this.rlueCariOdeme;
            this.gridColumn16.FieldName = "BORCLU_ADINA_ODEYEN_CARI_ID";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.ReadOnly = true;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 1;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Tarih";
            this.gridColumn17.FieldName = "ODEME_TARIHI";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.ReadOnly = true;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 2;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Tutar";
            this.gridColumn18.ColumnEdit = this.rspTutarOdeme;
            this.gridColumn18.FieldName = "ODEME_MIKTAR";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.ReadOnly = true;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 3;
            // 
            // rspTutarOdeme
            // 
            this.rspTutarOdeme.AutoHeight = false;
            this.rspTutarOdeme.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rspTutarOdeme.Name = "rspTutarOdeme";
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = " ";
            this.gridColumn19.ColumnEdit = this.rlueDovizTip;
            this.gridColumn19.FieldName = "ODEME_MIKTAR_DOVIZ_ID";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.ReadOnly = true;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 4;
            // 
            // rlueDovizTip
            // 
            this.rlueDovizTip.AutoHeight = false;
            this.rlueDovizTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueDovizTip.Name = "rlueDovizTip";
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Ödeme Yeri";
            this.gridColumn20.ColumnEdit = this.rlueOdemeYeri;
            this.gridColumn20.FieldName = "ODEME_YER_ID";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.OptionsColumn.ReadOnly = true;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 5;
            // 
            // rlueOdemeYeri
            // 
            this.rlueOdemeYeri.AutoHeight = false;
            this.rlueOdemeYeri.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueOdemeYeri.Name = "rlueOdemeYeri";
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Ödeme Tipi";
            this.gridColumn21.ColumnEdit = this.rlueOdemeTip;
            this.gridColumn21.FieldName = "ODEME_TIP_ID";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.ReadOnly = true;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 6;
            // 
            // rlueOdemeTip
            // 
            this.rlueOdemeTip.AutoHeight = false;
            this.rlueOdemeTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueOdemeTip.Name = "rlueOdemeTip";
            // 
            // gridColDosyaBilgisiOdeme
            // 
            this.gridColDosyaBilgisiOdeme.Caption = "Dosya No";
            this.gridColDosyaBilgisiOdeme.Name = "gridColDosyaBilgisiOdeme";
            this.gridColDosyaBilgisiOdeme.OptionsColumn.AllowEdit = false;
            this.gridColDosyaBilgisiOdeme.OptionsColumn.ReadOnly = true;
            this.gridColDosyaBilgisiOdeme.Tag = 1;
            this.gridColDosyaBilgisiOdeme.Visible = true;
            this.gridColDosyaBilgisiOdeme.VisibleIndex = 7;
            // 
            // gcTeklifKarar
            // 
            this.gcTeklifKarar.DataSource = this.bndTeklifKarar;
            this.gcTeklifKarar.Location = new System.Drawing.Point(160, 62);
            this.gcTeklifKarar.MainView = this.gvTeklifKarar;
            this.gcTeklifKarar.Name = "gcTeklifKarar";
            this.gcTeklifKarar.Size = new System.Drawing.Size(819, 536);
            this.gcTeklifKarar.TabIndex = 35;
            this.gcTeklifKarar.UseEmbeddedNavigator = true;
            this.gcTeklifKarar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTeklifKarar});
            // 
            // bndTeklifKarar
            // 
            this.bndTeklifKarar.DataMember = "AV001_TDIE_BIL_PROJE_TEKLIF_KARARCollection";
            this.bndTeklifKarar.DataSource = this.bndProje;
            // 
            // gvTeklifKarar
            // 
            this.gvTeklifKarar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColID,
            this.gridColTEKLIF,
            this.gridColKARAR});
            this.gvTeklifKarar.GridControl = this.gcTeklifKarar;
            this.gvTeklifKarar.Name = "gvTeklifKarar";
            // 
            // gridColID
            // 
            this.gridColID.Caption = "ID";
            this.gridColID.Name = "gridColID";
            // 
            // gridColTEKLIF
            // 
            this.gridColTEKLIF.Caption = "Teklif";
            this.gridColTEKLIF.FieldName = "TEKLIF";
            this.gridColTEKLIF.Name = "gridColTEKLIF";
            this.gridColTEKLIF.Visible = true;
            this.gridColTEKLIF.VisibleIndex = 0;
            // 
            // gridColKARAR
            // 
            this.gridColKARAR.Caption = "Karar";
            this.gridColKARAR.FieldName = "KARAR";
            this.gridColKARAR.Name = "gridColKARAR";
            this.gridColKARAR.Visible = true;
            this.gridColKARAR.VisibleIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ucbelgetakip1);
            this.panel2.Location = new System.Drawing.Point(160, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(819, 536);
            this.panel2.TabIndex = 34;
            // 
            // ucbelgetakip1
            // 
            this.ucbelgetakip1.CurrentRecord = null;
            this.ucbelgetakip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucbelgetakip1.IdValue = 0;
            this.ucbelgetakip1.Location = new System.Drawing.Point(0, 0);
            this.ucbelgetakip1.MyDataSource = null;
            this.ucbelgetakip1.Name = "ucbelgetakip1";
            this.ucbelgetakip1.Size = new System.Drawing.Size(819, 536);
            this.ucbelgetakip1.TabIndex = 2;
            this.ucbelgetakip1.TableName = null;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainerControl1);
            this.panel1.Location = new System.Drawing.Point(160, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(819, 536);
            this.panel1.TabIndex = 33;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcMaster);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupTaahhutDetay);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(819, 536);
            this.splitContainerControl1.SplitterPosition = 209;
            this.splitContainerControl1.TabIndex = 20;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gcMaster
            // 
            this.gcMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMaster.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcMaster.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcMaster.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcMaster.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcMaster.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcMaster.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(10, 10, true, true, "Sil", "Sil")});
            this.gcMaster.EmbeddedNavigator.TextStringFormat = "Kayıt {0} / {1}";
            this.gcMaster.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gcMaster_EmbeddedNavigator_ButtonClick);
            this.gcMaster.Location = new System.Drawing.Point(0, 0);
            this.gcMaster.MainView = this.gvMaster;
            this.gcMaster.Name = "gcMaster";
            this.gcMaster.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueProjeTaraf});
            this.gcMaster.Size = new System.Drawing.Size(819, 209);
            this.gcMaster.TabIndex = 18;
            this.gcMaster.UseEmbeddedNavigator = true;
            this.gcMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMaster});
            // 
            // gvMaster
            // 
            this.gvMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTAAHHUT_TIP,
            this.colTAAHHUT_EDEN_ID,
            this.colTAAHHUDU_KABUL_EDEN_ID,
            this.colTAAHHUT_TARIHI,
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI,
            this.colTAAHHUDU_KABUL_TARIHI,
            this.colDAVASI_VAR_MI,
            this.colDAVA_FOY_ID,
            this.gridColumn3,
            this.colRESMI_MI,
            this.colGECERLI_MI,
            this.colTAAHHUT_SIRA_NO});
            this.gvMaster.GridControl = this.gcMaster;
            this.gvMaster.GroupCount = 1;
            this.gvMaster.Name = "gvMaster";
            this.gvMaster.OptionsDetail.ShowDetailTabs = false;
            this.gvMaster.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTAAHHUT_EDEN_ID, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvMaster.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvMaster_FocusedRowChanged);
            // 
            // colTAAHHUT_TIP
            // 
            this.colTAAHHUT_TIP.Caption = "Tip";
            this.colTAAHHUT_TIP.FieldName = "TAAHHUT_TIP";
            this.colTAAHHUT_TIP.Name = "colTAAHHUT_TIP";
            this.colTAAHHUT_TIP.OptionsColumn.AllowEdit = false;
            this.colTAAHHUT_TIP.OptionsColumn.ReadOnly = true;
            this.colTAAHHUT_TIP.Visible = true;
            this.colTAAHHUT_TIP.VisibleIndex = 0;
            // 
            // colTAAHHUT_EDEN_ID
            // 
            this.colTAAHHUT_EDEN_ID.Caption = "Borçlu";
            this.colTAAHHUT_EDEN_ID.ColumnEdit = this.rlueProjeTaraf;
            this.colTAAHHUT_EDEN_ID.FieldName = "TAAHHUT_EDEN_ID";
            this.colTAAHHUT_EDEN_ID.Name = "colTAAHHUT_EDEN_ID";
            this.colTAAHHUT_EDEN_ID.OptionsColumn.AllowEdit = false;
            this.colTAAHHUT_EDEN_ID.OptionsColumn.ReadOnly = true;
            this.colTAAHHUT_EDEN_ID.Visible = true;
            this.colTAAHHUT_EDEN_ID.VisibleIndex = 2;
            // 
            // rlueProjeTaraf
            // 
            this.rlueProjeTaraf.AutoHeight = false;
            this.rlueProjeTaraf.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueProjeTaraf.Name = "rlueProjeTaraf";
            // 
            // colTAAHHUDU_KABUL_EDEN_ID
            // 
            this.colTAAHHUDU_KABUL_EDEN_ID.Caption = "Alacaklı";
            this.colTAAHHUDU_KABUL_EDEN_ID.ColumnEdit = this.rlueProjeTaraf;
            this.colTAAHHUDU_KABUL_EDEN_ID.FieldName = "TAAHHUDU_KABUL_EDEN_ID";
            this.colTAAHHUDU_KABUL_EDEN_ID.Name = "colTAAHHUDU_KABUL_EDEN_ID";
            this.colTAAHHUDU_KABUL_EDEN_ID.OptionsColumn.AllowEdit = false;
            this.colTAAHHUDU_KABUL_EDEN_ID.OptionsColumn.ReadOnly = true;
            this.colTAAHHUDU_KABUL_EDEN_ID.Visible = true;
            this.colTAAHHUDU_KABUL_EDEN_ID.VisibleIndex = 2;
            // 
            // colTAAHHUT_TARIHI
            // 
            this.colTAAHHUT_TARIHI.Caption = "Taah. T";
            this.colTAAHHUT_TARIHI.FieldName = "TAAHHUT_TARIHI";
            this.colTAAHHUT_TARIHI.Name = "colTAAHHUT_TARIHI";
            this.colTAAHHUT_TARIHI.OptionsColumn.AllowEdit = false;
            this.colTAAHHUT_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTAAHHUT_TARIHI.Visible = true;
            this.colTAAHHUT_TARIHI.VisibleIndex = 3;
            // 
            // colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI
            // 
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.Caption = "Tebliğ T";
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.FieldName = "TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI";
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.Name = "colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI";
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.OptionsColumn.AllowEdit = false;
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.Visible = true;
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.VisibleIndex = 4;
            // 
            // colTAAHHUDU_KABUL_TARIHI
            // 
            this.colTAAHHUDU_KABUL_TARIHI.Caption = "Kabul T";
            this.colTAAHHUDU_KABUL_TARIHI.FieldName = "TAAHHUDU_KABUL_TARIHI";
            this.colTAAHHUDU_KABUL_TARIHI.Name = "colTAAHHUDU_KABUL_TARIHI";
            this.colTAAHHUDU_KABUL_TARIHI.OptionsColumn.AllowEdit = false;
            this.colTAAHHUDU_KABUL_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTAAHHUDU_KABUL_TARIHI.Visible = true;
            this.colTAAHHUDU_KABUL_TARIHI.VisibleIndex = 5;
            // 
            // colDAVASI_VAR_MI
            // 
            this.colDAVASI_VAR_MI.Caption = "Davası";
            this.colDAVASI_VAR_MI.FieldName = "DAVASI_VAR_MI";
            this.colDAVASI_VAR_MI.Name = "colDAVASI_VAR_MI";
            this.colDAVASI_VAR_MI.OptionsColumn.AllowEdit = false;
            this.colDAVASI_VAR_MI.OptionsColumn.ReadOnly = true;
            this.colDAVASI_VAR_MI.Visible = true;
            this.colDAVASI_VAR_MI.VisibleIndex = 6;
            // 
            // colDAVA_FOY_ID
            // 
            this.colDAVA_FOY_ID.Caption = "DAVA_FOY_ID";
            this.colDAVA_FOY_ID.FieldName = "DAVA_FOY_ID";
            this.colDAVA_FOY_ID.Name = "colDAVA_FOY_ID";
            this.colDAVA_FOY_ID.OptionsColumn.AllowEdit = false;
            this.colDAVA_FOY_ID.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Kayıt T";
            this.gridColumn3.FieldName = "KAYIT_TARIHI";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 7;
            // 
            // colRESMI_MI
            // 
            this.colRESMI_MI.Caption = "Resmi";
            this.colRESMI_MI.FieldName = "RESMI_MI";
            this.colRESMI_MI.Name = "colRESMI_MI";
            this.colRESMI_MI.OptionsColumn.AllowEdit = false;
            this.colRESMI_MI.OptionsColumn.ReadOnly = true;
            this.colRESMI_MI.Visible = true;
            this.colRESMI_MI.VisibleIndex = 8;
            // 
            // colGECERLI_MI
            // 
            this.colGECERLI_MI.Caption = "Geçerli";
            this.colGECERLI_MI.FieldName = "GECERLI_MI";
            this.colGECERLI_MI.Name = "colGECERLI_MI";
            this.colGECERLI_MI.OptionsColumn.AllowEdit = false;
            this.colGECERLI_MI.OptionsColumn.ReadOnly = true;
            this.colGECERLI_MI.Visible = true;
            this.colGECERLI_MI.VisibleIndex = 9;
            // 
            // colTAAHHUT_SIRA_NO
            // 
            this.colTAAHHUT_SIRA_NO.Caption = "T. Sıra No";
            this.colTAAHHUT_SIRA_NO.FieldName = "TAAHHUT_SIRA_NO";
            this.colTAAHHUT_SIRA_NO.Name = "colTAAHHUT_SIRA_NO";
            this.colTAAHHUT_SIRA_NO.OptionsColumn.AllowEdit = false;
            this.colTAAHHUT_SIRA_NO.OptionsColumn.ReadOnly = true;
            this.colTAAHHUT_SIRA_NO.Visible = true;
            this.colTAAHHUT_SIRA_NO.VisibleIndex = 1;
            // 
            // groupTaahhutDetay
            // 
            this.groupTaahhutDetay.Controls.Add(this.gcChild);
            this.groupTaahhutDetay.Controls.Add(this.vgCChild);
            this.groupTaahhutDetay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupTaahhutDetay.Location = new System.Drawing.Point(0, 0);
            this.groupTaahhutDetay.Name = "groupTaahhutDetay";
            this.groupTaahhutDetay.Size = new System.Drawing.Size(819, 322);
            this.groupTaahhutDetay.TabIndex = 19;
            this.groupTaahhutDetay.Text = "Ödeme Planı Detay";
            // 
            // gcChild
            // 
            this.gcChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcChild.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcChild.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcChild.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcChild.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcChild.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcChild.EmbeddedNavigator.TextStringFormat = "Kayıt {0} / {1}";
            this.gcChild.Location = new System.Drawing.Point(2, 21);
            this.gcChild.MainView = this.gvChild;
            this.gcChild.Name = "gcChild";
            this.gcChild.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueDoviz,
            this.rlueTaahhutDurum});
            this.gcChild.Size = new System.Drawing.Size(815, 299);
            this.gcChild.TabIndex = 16;
            this.gcChild.UseEmbeddedNavigator = true;
            this.gcChild.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvChild});
            // 
            // gvChild
            // 
            this.gvChild.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSIRA_NO,
            this.colDURUM_ID,
            this.colTAAHHUTU_YERINE_GETIRME_TARIHI,
            this.colTAAHHUT_MIKTARI_DOVIZ_ID,
            this.colTAAHHUT_MIKTARI,
            this.colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID,
            this.colTAAHHUTTEN_KALAN_MIKTAR,
            this.colODEME_MIKTARI_DOVIZ_ID,
            this.colODEME_MIKTARI,
            this.colKAYIT_TARIHI});
            this.gvChild.GridControl = this.gcChild;
            this.gvChild.Name = "gvChild";
            // 
            // colSIRA_NO
            // 
            this.colSIRA_NO.Caption = "Sıra No";
            this.colSIRA_NO.FieldName = "SIRA_NO";
            this.colSIRA_NO.Name = "colSIRA_NO";
            this.colSIRA_NO.OptionsColumn.AllowEdit = false;
            this.colSIRA_NO.OptionsColumn.ReadOnly = true;
            this.colSIRA_NO.Visible = true;
            this.colSIRA_NO.VisibleIndex = 0;
            // 
            // colDURUM_ID
            // 
            this.colDURUM_ID.Caption = "Durum";
            this.colDURUM_ID.ColumnEdit = this.rlueTaahhutDurum;
            this.colDURUM_ID.FieldName = "DURUM_ID";
            this.colDURUM_ID.Name = "colDURUM_ID";
            this.colDURUM_ID.OptionsColumn.AllowEdit = false;
            this.colDURUM_ID.OptionsColumn.ReadOnly = true;
            this.colDURUM_ID.Visible = true;
            this.colDURUM_ID.VisibleIndex = 8;
            // 
            // rlueTaahhutDurum
            // 
            this.rlueTaahhutDurum.AutoHeight = false;
            this.rlueTaahhutDurum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueTaahhutDurum.Name = "rlueTaahhutDurum";
            // 
            // colTAAHHUTU_YERINE_GETIRME_TARIHI
            // 
            this.colTAAHHUTU_YERINE_GETIRME_TARIHI.Caption = "Yerine G. T";
            this.colTAAHHUTU_YERINE_GETIRME_TARIHI.FieldName = "TAAHHUTU_YERINE_GETIRME_TARIHI";
            this.colTAAHHUTU_YERINE_GETIRME_TARIHI.Name = "colTAAHHUTU_YERINE_GETIRME_TARIHI";
            this.colTAAHHUTU_YERINE_GETIRME_TARIHI.OptionsColumn.AllowEdit = false;
            this.colTAAHHUTU_YERINE_GETIRME_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTAAHHUTU_YERINE_GETIRME_TARIHI.Visible = true;
            this.colTAAHHUTU_YERINE_GETIRME_TARIHI.VisibleIndex = 1;
            // 
            // colTAAHHUT_MIKTARI_DOVIZ_ID
            // 
            this.colTAAHHUT_MIKTARI_DOVIZ_ID.Caption = " ";
            this.colTAAHHUT_MIKTARI_DOVIZ_ID.ColumnEdit = this.rlueDoviz;
            this.colTAAHHUT_MIKTARI_DOVIZ_ID.CustomizationCaption = "Taahhüt Miktarı Döviz Tipi";
            this.colTAAHHUT_MIKTARI_DOVIZ_ID.FieldName = "TAAHHUT_MIKTARI_DOVIZ_ID";
            this.colTAAHHUT_MIKTARI_DOVIZ_ID.Name = "colTAAHHUT_MIKTARI_DOVIZ_ID";
            this.colTAAHHUT_MIKTARI_DOVIZ_ID.OptionsColumn.AllowEdit = false;
            this.colTAAHHUT_MIKTARI_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colTAAHHUT_MIKTARI_DOVIZ_ID.Visible = true;
            this.colTAAHHUT_MIKTARI_DOVIZ_ID.VisibleIndex = 3;
            // 
            // rlueDoviz
            // 
            this.rlueDoviz.AutoHeight = false;
            this.rlueDoviz.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueDoviz.Name = "rlueDoviz";
            // 
            // colTAAHHUT_MIKTARI
            // 
            this.colTAAHHUT_MIKTARI.Caption = "Miktar";
            this.colTAAHHUT_MIKTARI.FieldName = "TAAHHUT_MIKTARI";
            this.colTAAHHUT_MIKTARI.Name = "colTAAHHUT_MIKTARI";
            this.colTAAHHUT_MIKTARI.OptionsColumn.AllowEdit = false;
            this.colTAAHHUT_MIKTARI.OptionsColumn.ReadOnly = true;
            this.colTAAHHUT_MIKTARI.Visible = true;
            this.colTAAHHUT_MIKTARI.VisibleIndex = 2;
            // 
            // colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID
            // 
            this.colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.Caption = " ";
            this.colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.ColumnEdit = this.rlueDoviz;
            this.colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.CustomizationCaption = "Kalan Doviz Tipi";
            this.colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.FieldName = "TAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID";
            this.colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.Name = "colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID";
            this.colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.OptionsColumn.AllowEdit = false;
            this.colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.Visible = true;
            this.colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID.VisibleIndex = 7;
            // 
            // colTAAHHUTTEN_KALAN_MIKTAR
            // 
            this.colTAAHHUTTEN_KALAN_MIKTAR.Caption = "Kalan";
            this.colTAAHHUTTEN_KALAN_MIKTAR.FieldName = "TAAHHUTTEN_KALAN_MIKTAR";
            this.colTAAHHUTTEN_KALAN_MIKTAR.Name = "colTAAHHUTTEN_KALAN_MIKTAR";
            this.colTAAHHUTTEN_KALAN_MIKTAR.OptionsColumn.AllowEdit = false;
            this.colTAAHHUTTEN_KALAN_MIKTAR.OptionsColumn.ReadOnly = true;
            this.colTAAHHUTTEN_KALAN_MIKTAR.Visible = true;
            this.colTAAHHUTTEN_KALAN_MIKTAR.VisibleIndex = 6;
            // 
            // colODEME_MIKTARI_DOVIZ_ID
            // 
            this.colODEME_MIKTARI_DOVIZ_ID.Caption = " ";
            this.colODEME_MIKTARI_DOVIZ_ID.ColumnEdit = this.rlueDoviz;
            this.colODEME_MIKTARI_DOVIZ_ID.CustomizationCaption = "Ödeme Döviz Tipi";
            this.colODEME_MIKTARI_DOVIZ_ID.FieldName = "ODEME_MIKTARI_DOVIZ_ID";
            this.colODEME_MIKTARI_DOVIZ_ID.Name = "colODEME_MIKTARI_DOVIZ_ID";
            this.colODEME_MIKTARI_DOVIZ_ID.OptionsColumn.AllowEdit = false;
            this.colODEME_MIKTARI_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colODEME_MIKTARI_DOVIZ_ID.Visible = true;
            this.colODEME_MIKTARI_DOVIZ_ID.VisibleIndex = 5;
            // 
            // colODEME_MIKTARI
            // 
            this.colODEME_MIKTARI.Caption = "Ödeme";
            this.colODEME_MIKTARI.FieldName = "ODEME_MIKTARI";
            this.colODEME_MIKTARI.Name = "colODEME_MIKTARI";
            this.colODEME_MIKTARI.OptionsColumn.AllowEdit = false;
            this.colODEME_MIKTARI.OptionsColumn.ReadOnly = true;
            this.colODEME_MIKTARI.Visible = true;
            this.colODEME_MIKTARI.VisibleIndex = 4;
            // 
            // colKAYIT_TARIHI
            // 
            this.colKAYIT_TARIHI.Caption = "KAYIT_TARIHI";
            this.colKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
            this.colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
            this.colKAYIT_TARIHI.OptionsColumn.AllowEdit = false;
            this.colKAYIT_TARIHI.OptionsColumn.ReadOnly = true;
            // 
            // vgCChild
            // 
            this.vgCChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vgCChild.Location = new System.Drawing.Point(2, 21);
            this.vgCChild.Name = "vgCChild";
            this.vgCChild.RecordWidth = 126;
            this.vgCChild.RowHeaderWidth = 188;
            this.vgCChild.Size = new System.Drawing.Size(815, 299);
            this.vgCChild.TabIndex = 0;
            this.vgCChild.Visible = false;
            // 
            // ucGorevler1
            // 
            this.ucGorevler1.AllowInsert = false;
            this.ucGorevler1.AramaDockPanel = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            this.ucGorevler1.Location = new System.Drawing.Point(160, 62);
            this.ucGorevler1.MyDataSource = null;
            this.ucGorevler1.MyDataSourceView = null;
            this.ucGorevler1.Name = "ucGorevler1";
            this.ucGorevler1.SelectedRecord = null;
            this.ucGorevler1.SelectedRecordId = 0;
            this.ucGorevler1.ShowKayitEkranOnDoubleClick = true;
            this.ucGorevler1.Size = new System.Drawing.Size(819, 536);
            this.ucGorevler1.TabIndex = 1;
            // 
            // gcGenelNotlar
            // 
            this.gcGenelNotlar.CustomButtonlarGorunmesin = false;
            this.gcGenelNotlar.DoNotExtendEmbedNavigator = false;
            this.gcGenelNotlar.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcGenelNotlar.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcGenelNotlar.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni Kayıt", "FormAc"),
            new DevExpress.XtraEditors.NavigatorCustomButton(20, 20, true, true, "Düzenle", "KaydiDuzenle"),
            new DevExpress.XtraEditors.NavigatorCustomButton(12, 12, true, true, "Sil", "KaydiSil")});
            this.gcGenelNotlar.EmbeddedNavigator.TextStringFormat = "Kayıt {0} / {1}";
            this.gcGenelNotlar.FilterText = null;
            this.gcGenelNotlar.FilterValue = null;
            this.gcGenelNotlar.GridlerDuzenlenebilir = true;
            this.gcGenelNotlar.GridsFilterControl = null;
            this.gcGenelNotlar.Location = new System.Drawing.Point(160, 62);
            this.gcGenelNotlar.MainView = this.gvGenelNotlar;
            this.gcGenelNotlar.MyGridStyle = null;
            this.gcGenelNotlar.Name = "gcGenelNotlar";
            this.gcGenelNotlar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueNotAlan});
            this.gcGenelNotlar.ShowRowNumbers = false;
            this.gcGenelNotlar.SilmeKaldirilsin = false;
            this.gcGenelNotlar.Size = new System.Drawing.Size(819, 536);
            this.gcGenelNotlar.TabIndex = 31;
            this.gcGenelNotlar.TemizleKaldirGorunsunmu = false;
            this.gcGenelNotlar.UniqueId = "efea77e4-b63f-45a9-a8fa-19c5603d2da0";
            this.gcGenelNotlar.UseEmbeddedNavigator = true;
            this.gcGenelNotlar.UseHyperDragDrop = false;
            this.gcGenelNotlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGenelNotlar});
            this.gcGenelNotlar.ButtonClick += new System.EventHandler<DevExpress.XtraEditors.NavigatorButtonClickEventArgs>(this.gcGenelNotlar_ButtonClick);
            // 
            // gvGenelNotlar
            // 
            this.gvGenelNotlar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnNotAlan,
            this.gridColumnTarih,
            this.gridColumnNotlar});
            this.gvGenelNotlar.GridControl = this.gcGenelNotlar;
            this.gvGenelNotlar.IndicatorWidth = 20;
            this.gvGenelNotlar.Name = "gvGenelNotlar";
            this.gvGenelNotlar.OptionsView.AutoCalcPreviewLineCount = true;
            this.gvGenelNotlar.OptionsView.RowAutoHeight = true;
            this.gvGenelNotlar.OptionsView.ShowPreview = true;
            this.gvGenelNotlar.PreviewFieldName = "NOTLAR";
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "ID";
            this.gridColumnID.Name = "gridColumnID";
            // 
            // gridColumnNotAlan
            // 
            this.gridColumnNotAlan.Caption = "Not Alan";
            this.gridColumnNotAlan.FieldName = "KONTROL_KIM";
            this.gridColumnNotAlan.Name = "gridColumnNotAlan";
            this.gridColumnNotAlan.Visible = true;
            this.gridColumnNotAlan.VisibleIndex = 0;
            // 
            // gridColumnTarih
            // 
            this.gridColumnTarih.Caption = "Tarih";
            this.gridColumnTarih.FieldName = "KAYIT_TARIHI";
            this.gridColumnTarih.Name = "gridColumnTarih";
            this.gridColumnTarih.Visible = true;
            this.gridColumnTarih.VisibleIndex = 1;
            // 
            // gridColumnNotlar
            // 
            this.gridColumnNotlar.Caption = "Not";
            this.gridColumnNotlar.FieldName = "NOTLAR";
            this.gridColumnNotlar.Name = "gridColumnNotlar";
            this.gridColumnNotlar.Visible = true;
            this.gridColumnNotlar.VisibleIndex = 2;
            // 
            // rlueNotAlan
            // 
            this.rlueNotAlan.Name = "rlueNotAlan";
            // 
            // sbtnBul
            // 
            this.sbtnBul.Location = new System.Drawing.Point(909, 12);
            this.sbtnBul.Name = "sbtnBul";
            this.sbtnBul.Size = new System.Drawing.Size(94, 22);
            this.sbtnBul.StyleController = this.lcProjeEkrani;
            this.sbtnBul.TabIndex = 29;
            this.sbtnBul.Text = "BUL";
            this.sbtnBul.Click += new System.EventHandler(this.sbtnBul_Click);
            // 
            // lueAra
            // 
            this.lueAra.Location = new System.Drawing.Point(109, 12);
            this.lueAra.Name = "lueAra";
            this.lueAra.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAra.Size = new System.Drawing.Size(796, 20);
            this.lueAra.StyleController = this.lcProjeEkrani;
            this.lueAra.TabIndex = 28;
            this.lueAra.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lueAra_KeyUp);
            // 
            // dtHesapKatTarihi
            // 
            this.dtHesapKatTarihi.EditValue = null;
            this.dtHesapKatTarihi.Location = new System.Drawing.Point(536, 250);
            this.dtHesapKatTarihi.Name = "dtHesapKatTarihi";
            this.dtHesapKatTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtHesapKatTarihi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtHesapKatTarihi.Size = new System.Drawing.Size(321, 20);
            this.dtHesapKatTarihi.StyleController = this.lcProjeEkrani;
            this.dtHesapKatTarihi.TabIndex = 20;
            // 
            // gcTaraflar
            // 
            this.gcTaraflar.Location = new System.Drawing.Point(160, 574);
            this.gcTaraflar.MainView = this.gridView1;
            this.gcTaraflar.Name = "gcTaraflar";
            this.gcTaraflar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueProjeTarafCari});
            this.gcTaraflar.Size = new System.Drawing.Size(413, 448);
            this.gcTaraflar.TabIndex = 22;
            this.gcTaraflar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.gcTaraflar;
            this.gridView1.Name = "gridView1";
            this.gridView1.ViewCaption = "Proje Tarafları";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumnProjeID";
            this.gridColumn1.FieldName = "PROJE_ID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Taraf";
            this.gridColumn2.ColumnEdit = this.rlueProjeTarafCari;
            this.gridColumn2.FieldName = "CARI_ID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // rlueProjeTarafCari
            // 
            this.rlueProjeTarafCari.AutoHeight = false;
            this.rlueProjeTarafCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueProjeTarafCari.Name = "rlueProjeTarafCari";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.ucIcraHesapCetveli1);
            this.panelControl2.Controls.Add(this.pnlHesaplamaTipi);
            this.panelControl2.Location = new System.Drawing.Point(160, 62);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(819, 536);
            this.panelControl2.TabIndex = 23;
            // 
            // ucIcraHesapCetveli1
            // 
            this.ucIcraHesapCetveli1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIcraHesapCetveli1.Location = new System.Drawing.Point(2, 29);
            this.ucIcraHesapCetveli1.Name = "ucIcraHesapCetveli1";
            this.ucIcraHesapCetveli1.Size = new System.Drawing.Size(815, 505);
            this.ucIcraHesapCetveli1.TabIndex = 2;
            this.ucIcraHesapCetveli1.Tag = "H";
            // 
            // pnlHesaplamaTipi
            // 
            this.pnlHesaplamaTipi.Controls.Add(this.lueHesapTipi);
            this.pnlHesaplamaTipi.Controls.Add(this.labelControl1);
            this.pnlHesaplamaTipi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHesaplamaTipi.Location = new System.Drawing.Point(2, 2);
            this.pnlHesaplamaTipi.Name = "pnlHesaplamaTipi";
            this.pnlHesaplamaTipi.Size = new System.Drawing.Size(815, 27);
            this.pnlHesaplamaTipi.TabIndex = 3;
            // 
            // lueHesapTipi
            // 
            this.lueHesapTipi.Location = new System.Drawing.Point(115, 4);
            this.lueHesapTipi.Name = "lueHesapTipi";
            this.lueHesapTipi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "Düzenle", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "duzenle", null, true)});
            this.lueHesapTipi.Size = new System.Drawing.Size(257, 20);
            this.lueHesapTipi.StyleController = this.lcProjeEkrani;
            this.lueHesapTipi.TabIndex = 1;
            this.lueHesapTipi.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueHesapTipi_ButtonClick);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(49, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Hesap Tipi";
            // 
            // treeKrediHesapBilgileri
            // 
            this.treeKrediHesapBilgileri.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeKrediHesapBilgileri.ContextMenuStrip = this.cmsKrediBilgileri;
            this.treeKrediHesapBilgileri.Location = new System.Drawing.Point(172, 93);
            this.treeKrediHesapBilgileri.Name = "treeKrediHesapBilgileri";
            this.treeKrediHesapBilgileri.OptionsBehavior.DragNodes = true;
            this.treeKrediHesapBilgileri.OptionsBehavior.Editable = false;
            this.treeKrediHesapBilgileri.OptionsPrint.PrintAllNodes = true;
            this.treeKrediHesapBilgileri.OptionsPrint.PrintPreview = true;
            this.treeKrediHesapBilgileri.OptionsView.AutoCalcPreviewLineCount = true;
            this.treeKrediHesapBilgileri.OptionsView.ShowPreview = true;
            this.treeKrediHesapBilgileri.PreviewFieldName = "ACIKLAMA";
            this.treeKrediHesapBilgileri.Size = new System.Drawing.Size(231, 465);
            this.treeKrediHesapBilgileri.StateImageList = this.imgKlasor;
            this.treeKrediHesapBilgileri.TabIndex = 21;
            this.treeKrediHesapBilgileri.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeKrediHesapBilgileri_MouseDown);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Adı";
            this.treeListColumn1.FieldName = "ADI";
            this.treeListColumn1.MinWidth = 39;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Açıklama";
            this.treeListColumn2.FieldName = "ACIKLAMA";
            this.treeListColumn2.Name = "treeListColumn2";
            // 
            // cmsKrediBilgileri
            // 
            this.cmsKrediBilgileri.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniKlasörOluşturToolStripMenuItem,
            this.klasörüSilToolStripMenuItem,
            this.özelliklerToolStripMenuItem,
            this.toolStripMenuItem2,
            this.yeniToolStripMenuItem,
            this.tazminToolStripMenuItem,
            this.iadeToolStripMenuItem,
            this.depoToolStripMenuItem,
            this.tsmiAlacakDuzenle,
            this.tsmihtiyatiTedbirDuzenle,
            this.tsmIlamBilgisiDuzenle,
            this.tsmIhtiyatiHacizDuzenle,
            this.tsmIhtiyatiHacizDilekcesi,
            this.ihtarnameDüzenleToolStripMenuItem,
            this.tsmkiymetliEvrakBilgileriDuzenle,
            this.ödemeyiToolStripMenuItem,
            this.masrafDüzenleToolStripMenuItem,
            this.düzenleToolStripMenuItem,
            this.toolStripSeparator1,
            this.ağacınTümünüAçToolStripMenuItem,
            this.ağacıTamamenKapatToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItem1,
            this.aporToolStripMenuItem,
            this.klasörAğaçRaporuToolStripMenuItem});
            this.cmsKrediBilgileri.Name = "contextMenuStrip1";
            this.cmsKrediBilgileri.Size = new System.Drawing.Size(220, 506);
            this.cmsKrediBilgileri.Opening += new System.ComponentModel.CancelEventHandler(this.cmsKrediBilgileri_Opening);
            // 
            // yeniKlasörOluşturToolStripMenuItem
            // 
            this.yeniKlasörOluşturToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("yeniKlasörOluşturToolStripMenuItem.Image")));
            this.yeniKlasörOluşturToolStripMenuItem.Name = "yeniKlasörOluşturToolStripMenuItem";
            this.yeniKlasörOluşturToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.yeniKlasörOluşturToolStripMenuItem.Text = "Yeni &Klasör Oluştur";
            this.yeniKlasörOluşturToolStripMenuItem.Click += new System.EventHandler(this.yeniKlasörOluşturToolStripMenuItem_Click);
            // 
            // klasörüSilToolStripMenuItem
            // 
            this.klasörüSilToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("klasörüSilToolStripMenuItem.Image")));
            this.klasörüSilToolStripMenuItem.Name = "klasörüSilToolStripMenuItem";
            this.klasörüSilToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.klasörüSilToolStripMenuItem.Text = "&Sil";
            this.klasörüSilToolStripMenuItem.Click += new System.EventHandler(this.klasörüSilToolStripMenuItem_Click);
            // 
            // özelliklerToolStripMenuItem
            // 
            this.özelliklerToolStripMenuItem.Name = "özelliklerToolStripMenuItem";
            this.özelliklerToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.özelliklerToolStripMenuItem.Text = "Ö&zellikler";
            this.özelliklerToolStripMenuItem.Visible = false;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(216, 6);
            // 
            // yeniToolStripMenuItem
            // 
            this.yeniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAlacak,
            this.tsmiTeminat,
            this.tsmiSozlesme,
            this.tsmiTakipler,
            this.tsmiDavaDosyasi,
            this.tsmiSorusturma,
            this.tsmiCizik2,
            this.tsmiIhtiyatiHaciz,
            this.tsmiIhtiyatiTedbir,
            this.tsmiCizik,
            this.tsmiOdeme,
            this.tsmiMasraf,
            this.tsmiMalHakGirisi,
            this.tsmIlamGirisi,
            this.ihtarnameGirişiToolStripMenuItem,
            this.munzamSenetToolStripMenuItem});
            this.yeniToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("yeniToolStripMenuItem.Image")));
            this.yeniToolStripMenuItem.Name = "yeniToolStripMenuItem";
            this.yeniToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.yeniToolStripMenuItem.Text = "&Yeni..";
            // 
            // tsmiAlacak
            // 
            this.tsmiAlacak.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAlacakNakit,
            this.tsmiAlacakGayriNakit,
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacak});
            this.tsmiAlacak.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAlacak.Image")));
            this.tsmiAlacak.Name = "tsmiAlacak";
            this.tsmiAlacak.Size = new System.Drawing.Size(228, 22);
            this.tsmiAlacak.Tag = typeof(AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN);
            this.tsmiAlacak.Text = "&Alacak Girişi";
            this.tsmiAlacak.Click += new System.EventHandler(this.tsmiAlacakClick);
            // 
            // tsmiAlacakNakit
            // 
            this.tsmiAlacakNakit.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAlacakNakit.Image")));
            this.tsmiAlacakNakit.Name = "tsmiAlacakNakit";
            this.tsmiAlacakNakit.Size = new System.Drawing.Size(313, 22);
            this.tsmiAlacakNakit.Text = "Nakit";
            this.tsmiAlacakNakit.Visible = false;
            this.tsmiAlacakNakit.Click += new System.EventHandler(this.tsmiAlacakClick);
            // 
            // tsmiAlacakGayriNakit
            // 
            this.tsmiAlacakGayriNakit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAlacakGayriNakitMektup,
            this.tsmiAlacakGayriNakitCekTaahhut,
            this.tsmiAlacakGayriNakitAkreditif,
            this.tsmiAlacakGayriNakitAval,
            this.tsmiAlacakGayriNakitDiger});
            this.tsmiAlacakGayriNakit.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAlacakGayriNakit.Image")));
            this.tsmiAlacakGayriNakit.Name = "tsmiAlacakGayriNakit";
            this.tsmiAlacakGayriNakit.Size = new System.Drawing.Size(313, 22);
            this.tsmiAlacakGayriNakit.Text = "Gayri Nakit";
            this.tsmiAlacakGayriNakit.Visible = false;
            // 
            // tsmiAlacakGayriNakitMektup
            // 
            this.tsmiAlacakGayriNakitMektup.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAlacakGayriNakitMektup.Image")));
            this.tsmiAlacakGayriNakitMektup.Name = "tsmiAlacakGayriNakitMektup";
            this.tsmiAlacakGayriNakitMektup.Size = new System.Drawing.Size(131, 22);
            this.tsmiAlacakGayriNakitMektup.Text = "Mektup";
            this.tsmiAlacakGayriNakitMektup.Click += new System.EventHandler(this.tsmiAlacakClick);
            // 
            // tsmiAlacakGayriNakitCekTaahhut
            // 
            this.tsmiAlacakGayriNakitCekTaahhut.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAlacakGayriNakitCekTaahhut.Image")));
            this.tsmiAlacakGayriNakitCekTaahhut.Name = "tsmiAlacakGayriNakitCekTaahhut";
            this.tsmiAlacakGayriNakitCekTaahhut.Size = new System.Drawing.Size(131, 22);
            this.tsmiAlacakGayriNakitCekTaahhut.Text = "Çek Yaprağı";
            this.tsmiAlacakGayriNakitCekTaahhut.Click += new System.EventHandler(this.tsmiAlacakClick);
            // 
            // tsmiAlacakGayriNakitAkreditif
            // 
            this.tsmiAlacakGayriNakitAkreditif.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAlacakGayriNakitAkreditif.Image")));
            this.tsmiAlacakGayriNakitAkreditif.Name = "tsmiAlacakGayriNakitAkreditif";
            this.tsmiAlacakGayriNakitAkreditif.Size = new System.Drawing.Size(131, 22);
            this.tsmiAlacakGayriNakitAkreditif.Text = "Akreditif";
            this.tsmiAlacakGayriNakitAkreditif.Click += new System.EventHandler(this.tsmiAlacakClick);
            // 
            // tsmiAlacakGayriNakitAval
            // 
            this.tsmiAlacakGayriNakitAval.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAlacakGayriNakitAval.Image")));
            this.tsmiAlacakGayriNakitAval.Name = "tsmiAlacakGayriNakitAval";
            this.tsmiAlacakGayriNakitAval.Size = new System.Drawing.Size(131, 22);
            this.tsmiAlacakGayriNakitAval.Text = "Aval";
            this.tsmiAlacakGayriNakitAval.Click += new System.EventHandler(this.tsmiAlacakClick);
            // 
            // tsmiAlacakGayriNakitDiger
            // 
            this.tsmiAlacakGayriNakitDiger.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAlacakGayriNakitDiger.Image")));
            this.tsmiAlacakGayriNakitDiger.Name = "tsmiAlacakGayriNakitDiger";
            this.tsmiAlacakGayriNakitDiger.Size = new System.Drawing.Size(131, 22);
            this.tsmiAlacakGayriNakitDiger.Text = "Diğer";
            this.tsmiAlacakGayriNakitDiger.Click += new System.EventHandler(this.tsmiAlacakClick);
            // 
            // tsmiAlacakKiymetliEvrakaBaglanmisAlacak
            // 
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacak.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakCek,
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakBono,
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakPolice});
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacak.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAlacakKiymetliEvrakaBaglanmisAlacak.Image")));
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacak.Name = "tsmiAlacakKiymetliEvrakaBaglanmisAlacak";
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacak.Size = new System.Drawing.Size(313, 22);
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacak.Text = "Kıymetli Evraka (Gerçek Senede) Bağlanmış Alacak";
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacak.Visible = false;
            // 
            // tsmiAlacakKiymetliEvrakaBaglanmisAlacakCek
            // 
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakCek.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAlacakKiymetliEvrakaBaglanmisAlacakCek.Image")));
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakCek.Name = "tsmiAlacakKiymetliEvrakaBaglanmisAlacakCek";
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakCek.Size = new System.Drawing.Size(101, 22);
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakCek.Text = "Çek";
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakCek.Click += new System.EventHandler(this.tsmiAlacakClick);
            // 
            // tsmiAlacakKiymetliEvrakaBaglanmisAlacakBono
            // 
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakBono.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAlacakKiymetliEvrakaBaglanmisAlacakBono.Image")));
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakBono.Name = "tsmiAlacakKiymetliEvrakaBaglanmisAlacakBono";
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakBono.Size = new System.Drawing.Size(101, 22);
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakBono.Text = "Bono";
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakBono.Click += new System.EventHandler(this.tsmiAlacakClick);
            // 
            // tsmiAlacakKiymetliEvrakaBaglanmisAlacakPolice
            // 
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakPolice.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAlacakKiymetliEvrakaBaglanmisAlacakPolice.Image")));
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakPolice.Name = "tsmiAlacakKiymetliEvrakaBaglanmisAlacakPolice";
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakPolice.Size = new System.Drawing.Size(101, 22);
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakPolice.Text = "Poliçe";
            this.tsmiAlacakKiymetliEvrakaBaglanmisAlacakPolice.Click += new System.EventHandler(this.tsmiAlacakClick);
            // 
            // tsmiTeminat
            // 
            this.tsmiTeminat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTeminatIpotek,
            this.havaAracıİpoteğiToolStripMenuItem,
            this.gemiİpoteğiToolStripMenuItem,
            this.tsmiTeminatTicariIsletmeRehni,
            this.tsmiTeminatMenkulRehni,
            this.tsmiTeminatTeminatSenedi});
            this.tsmiTeminat.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTeminat.Image")));
            this.tsmiTeminat.Name = "tsmiTeminat";
            this.tsmiTeminat.Size = new System.Drawing.Size(228, 22);
            this.tsmiTeminat.Text = "Teminat";
            // 
            // tsmiTeminatIpotek
            // 
            this.tsmiTeminatIpotek.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTeminatIpotek.Image")));
            this.tsmiTeminatIpotek.Name = "tsmiTeminatIpotek";
            this.tsmiTeminatIpotek.Size = new System.Drawing.Size(259, 22);
            this.tsmiTeminatIpotek.Text = "İpotek";
            this.tsmiTeminatIpotek.Click += new System.EventHandler(this.tsmiTeminat_Click);
            // 
            // havaAracıİpoteğiToolStripMenuItem
            // 
            this.havaAracıİpoteğiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("havaAracıİpoteğiToolStripMenuItem.Image")));
            this.havaAracıİpoteğiToolStripMenuItem.Name = "havaAracıİpoteğiToolStripMenuItem";
            this.havaAracıİpoteğiToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.havaAracıİpoteğiToolStripMenuItem.Text = "Hava Aracı İpoteği";
            this.havaAracıİpoteğiToolStripMenuItem.Click += new System.EventHandler(this.tsmiTeminat_Click);
            // 
            // gemiİpoteğiToolStripMenuItem
            // 
            this.gemiİpoteğiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("gemiİpoteğiToolStripMenuItem.Image")));
            this.gemiİpoteğiToolStripMenuItem.Name = "gemiİpoteğiToolStripMenuItem";
            this.gemiİpoteğiToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.gemiİpoteğiToolStripMenuItem.Text = "Gemi İpoteği";
            this.gemiİpoteğiToolStripMenuItem.Click += new System.EventHandler(this.tsmiTeminat_Click);
            // 
            // tsmiTeminatTicariIsletmeRehni
            // 
            this.tsmiTeminatTicariIsletmeRehni.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTeminatTicariIsletmeRehni.Image")));
            this.tsmiTeminatTicariIsletmeRehni.Name = "tsmiTeminatTicariIsletmeRehni";
            this.tsmiTeminatTicariIsletmeRehni.Size = new System.Drawing.Size(259, 22);
            this.tsmiTeminatTicariIsletmeRehni.Text = "Ticari İşletme Rehni";
            this.tsmiTeminatTicariIsletmeRehni.Click += new System.EventHandler(this.tsmiTeminat_Click);
            // 
            // tsmiTeminatMenkulRehni
            // 
            this.tsmiTeminatMenkulRehni.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTeminatMenkulRehniAracRehni,
            this.tsmiTeminatMenkulRehniHatRehni,
            this.tsmiTeminatMenkulRehniMarkaRehni,
            this.tsmiTeminatMenkulRehniTicariPlakaRehni,
            this.tsmiTeminatMenkulRehniHisseSenediRehni,
            this.tsmiTeminatMenkulRehniKambiyoSenedi,
            this.tsmiTeminatMenkulRehniDigerMenkulRehni});
            this.tsmiTeminatMenkulRehni.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTeminatMenkulRehni.Image")));
            this.tsmiTeminatMenkulRehni.Name = "tsmiTeminatMenkulRehni";
            this.tsmiTeminatMenkulRehni.Size = new System.Drawing.Size(259, 22);
            this.tsmiTeminatMenkulRehni.Text = "Menkul Rehni";
            // 
            // tsmiTeminatMenkulRehniAracRehni
            // 
            this.tsmiTeminatMenkulRehniAracRehni.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTeminatMenkulRehniAracRehni.Image")));
            this.tsmiTeminatMenkulRehniAracRehni.Name = "tsmiTeminatMenkulRehniAracRehni";
            this.tsmiTeminatMenkulRehniAracRehni.Size = new System.Drawing.Size(230, 22);
            this.tsmiTeminatMenkulRehniAracRehni.Text = "Araç Rehni";
            this.tsmiTeminatMenkulRehniAracRehni.Click += new System.EventHandler(this.tsmiTeminat_Click);
            // 
            // tsmiTeminatMenkulRehniHatRehni
            // 
            this.tsmiTeminatMenkulRehniHatRehni.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTeminatMenkulRehniHatRehni.Image")));
            this.tsmiTeminatMenkulRehniHatRehni.Name = "tsmiTeminatMenkulRehniHatRehni";
            this.tsmiTeminatMenkulRehniHatRehni.Size = new System.Drawing.Size(230, 22);
            this.tsmiTeminatMenkulRehniHatRehni.Text = "Hat Rehni";
            this.tsmiTeminatMenkulRehniHatRehni.Click += new System.EventHandler(this.tsmiTeminat_Click);
            // 
            // tsmiTeminatMenkulRehniMarkaRehni
            // 
            this.tsmiTeminatMenkulRehniMarkaRehni.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTeminatMenkulRehniMarkaRehni.Image")));
            this.tsmiTeminatMenkulRehniMarkaRehni.Name = "tsmiTeminatMenkulRehniMarkaRehni";
            this.tsmiTeminatMenkulRehniMarkaRehni.Size = new System.Drawing.Size(230, 22);
            this.tsmiTeminatMenkulRehniMarkaRehni.Text = "Marka Rehni";
            this.tsmiTeminatMenkulRehniMarkaRehni.Click += new System.EventHandler(this.tsmiTeminat_Click);
            // 
            // tsmiTeminatMenkulRehniTicariPlakaRehni
            // 
            this.tsmiTeminatMenkulRehniTicariPlakaRehni.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTeminatMenkulRehniTicariPlakaRehni.Image")));
            this.tsmiTeminatMenkulRehniTicariPlakaRehni.Name = "tsmiTeminatMenkulRehniTicariPlakaRehni";
            this.tsmiTeminatMenkulRehniTicariPlakaRehni.Size = new System.Drawing.Size(230, 22);
            this.tsmiTeminatMenkulRehniTicariPlakaRehni.Text = "Ticari Plaka Rehni";
            this.tsmiTeminatMenkulRehniTicariPlakaRehni.Click += new System.EventHandler(this.tsmiTeminat_Click);
            // 
            // tsmiTeminatMenkulRehniHisseSenediRehni
            // 
            this.tsmiTeminatMenkulRehniHisseSenediRehni.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTeminatMenkulRehniHisseSenediRehni.Image")));
            this.tsmiTeminatMenkulRehniHisseSenediRehni.Name = "tsmiTeminatMenkulRehniHisseSenediRehni";
            this.tsmiTeminatMenkulRehniHisseSenediRehni.Size = new System.Drawing.Size(230, 22);
            this.tsmiTeminatMenkulRehniHisseSenediRehni.Text = "Hisse Senedi Rehni";
            this.tsmiTeminatMenkulRehniHisseSenediRehni.Click += new System.EventHandler(this.tsmiTeminat_Click);
            // 
            // tsmiTeminatMenkulRehniKambiyoSenedi
            // 
            this.tsmiTeminatMenkulRehniKambiyoSenedi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTeminatMenkulRehniKambiyoSenediBono,
            this.tsmiTeminatMenkulRehniKambiyoSenediPolice,
            this.tsmiTeminatMenkulRehniKambiyoSenediCek});
            this.tsmiTeminatMenkulRehniKambiyoSenedi.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTeminatMenkulRehniKambiyoSenedi.Image")));
            this.tsmiTeminatMenkulRehniKambiyoSenedi.Name = "tsmiTeminatMenkulRehniKambiyoSenedi";
            this.tsmiTeminatMenkulRehniKambiyoSenedi.Size = new System.Drawing.Size(230, 22);
            this.tsmiTeminatMenkulRehniKambiyoSenedi.Text = "Kambiyo Senedi (Müşteri Senedi)";
            this.tsmiTeminatMenkulRehniKambiyoSenedi.Visible = false;
            this.tsmiTeminatMenkulRehniKambiyoSenedi.Click += new System.EventHandler(this.tsmiTeminat_Click);
            // 
            // tsmiTeminatMenkulRehniKambiyoSenediBono
            // 
            this.tsmiTeminatMenkulRehniKambiyoSenediBono.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTeminatMenkulRehniKambiyoSenediBono.Image")));
            this.tsmiTeminatMenkulRehniKambiyoSenediBono.Name = "tsmiTeminatMenkulRehniKambiyoSenediBono";
            this.tsmiTeminatMenkulRehniKambiyoSenediBono.Size = new System.Drawing.Size(101, 22);
            this.tsmiTeminatMenkulRehniKambiyoSenediBono.Text = "Bono";
            // 
            // tsmiTeminatMenkulRehniKambiyoSenediPolice
            // 
            this.tsmiTeminatMenkulRehniKambiyoSenediPolice.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTeminatMenkulRehniKambiyoSenediPolice.Image")));
            this.tsmiTeminatMenkulRehniKambiyoSenediPolice.Name = "tsmiTeminatMenkulRehniKambiyoSenediPolice";
            this.tsmiTeminatMenkulRehniKambiyoSenediPolice.Size = new System.Drawing.Size(101, 22);
            this.tsmiTeminatMenkulRehniKambiyoSenediPolice.Text = "Poliçe";
            // 
            // tsmiTeminatMenkulRehniKambiyoSenediCek
            // 
            this.tsmiTeminatMenkulRehniKambiyoSenediCek.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTeminatMenkulRehniKambiyoSenediCek.Image")));
            this.tsmiTeminatMenkulRehniKambiyoSenediCek.Name = "tsmiTeminatMenkulRehniKambiyoSenediCek";
            this.tsmiTeminatMenkulRehniKambiyoSenediCek.Size = new System.Drawing.Size(101, 22);
            this.tsmiTeminatMenkulRehniKambiyoSenediCek.Text = "Çek";
            // 
            // tsmiTeminatMenkulRehniDigerMenkulRehni
            // 
            this.tsmiTeminatMenkulRehniDigerMenkulRehni.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTeminatMenkulRehniDigerMenkulRehni.Image")));
            this.tsmiTeminatMenkulRehniDigerMenkulRehni.Name = "tsmiTeminatMenkulRehniDigerMenkulRehni";
            this.tsmiTeminatMenkulRehniDigerMenkulRehni.Size = new System.Drawing.Size(230, 22);
            this.tsmiTeminatMenkulRehniDigerMenkulRehni.Text = "Diğer Menkul Rehni";
            this.tsmiTeminatMenkulRehniDigerMenkulRehni.Click += new System.EventHandler(this.tsmiTeminat_Click);
            // 
            // tsmiTeminatTeminatSenedi
            // 
            this.tsmiTeminatTeminatSenedi.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTeminatTeminatSenedi.Image")));
            this.tsmiTeminatTeminatSenedi.Name = "tsmiTeminatTeminatSenedi";
            this.tsmiTeminatTeminatSenedi.Size = new System.Drawing.Size(259, 22);
            this.tsmiTeminatTeminatSenedi.Text = "Teminat Amaçlı Müşteri ÇEK ve SENEDİ";
            this.tsmiTeminatTeminatSenedi.Click += new System.EventHandler(this.tsmiTeminat_Click);
            // 
            // tsmiSozlesme
            // 
            this.tsmiSozlesme.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSozlesmeGenelKrediSozlesmesi,
            this.tsmiSozlesmeGenelKrediTaahhutname,
            this.tsmiSozlesmeBankacilikHizmetSozlesmesi,
            this.tsmiSozlesmeKonutKrediSozlesmesi,
            this.tsmiSozlesmeIhtiyacKrediSozlesmesi,
            this.tsmiSozlesmeTasitKrediSozlesmesi,
            this.noterdenBorçİkrarıToolStripMenuItem,
            this.resenDüzenlenmişNoterSenediToolStripMenuItem,
            this.avukatlıkKm35AToolStripMenuItem});
            this.tsmiSozlesme.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSozlesme.Image")));
            this.tsmiSozlesme.Name = "tsmiSozlesme";
            this.tsmiSozlesme.Size = new System.Drawing.Size(228, 22);
            this.tsmiSozlesme.Text = "&Sözleşme";
            // 
            // tsmiSozlesmeGenelKrediSozlesmesi
            // 
            this.tsmiSozlesmeGenelKrediSozlesmesi.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSozlesmeGenelKrediSozlesmesi.Image")));
            this.tsmiSozlesmeGenelKrediSozlesmesi.Name = "tsmiSozlesmeGenelKrediSozlesmesi";
            this.tsmiSozlesmeGenelKrediSozlesmesi.Size = new System.Drawing.Size(351, 22);
            this.tsmiSozlesmeGenelKrediSozlesmesi.Text = "Genel Kredi Sözleşmesi";
            this.tsmiSozlesmeGenelKrediSozlesmesi.Click += new System.EventHandler(this.tsmiSozlesmeClick);
            // 
            // tsmiSozlesmeGenelKrediTaahhutname
            // 
            this.tsmiSozlesmeGenelKrediTaahhutname.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSozlesmeGenelKrediTaahhutname.Image")));
            this.tsmiSozlesmeGenelKrediTaahhutname.Name = "tsmiSozlesmeGenelKrediTaahhutname";
            this.tsmiSozlesmeGenelKrediTaahhutname.Size = new System.Drawing.Size(351, 22);
            this.tsmiSozlesmeGenelKrediTaahhutname.Text = "Genel Kredi Taahhütnamesi";
            this.tsmiSozlesmeGenelKrediTaahhutname.Click += new System.EventHandler(this.tsmiSozlesmeClick);
            // 
            // tsmiSozlesmeBankacilikHizmetSozlesmesi
            // 
            this.tsmiSozlesmeBankacilikHizmetSozlesmesi.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSozlesmeBankacilikHizmetSozlesmesi.Image")));
            this.tsmiSozlesmeBankacilikHizmetSozlesmesi.Name = "tsmiSozlesmeBankacilikHizmetSozlesmesi";
            this.tsmiSozlesmeBankacilikHizmetSozlesmesi.Size = new System.Drawing.Size(351, 22);
            this.tsmiSozlesmeBankacilikHizmetSozlesmesi.Text = "Bankacılık Hizmet Sözleşmesi";
            this.tsmiSozlesmeBankacilikHizmetSozlesmesi.Click += new System.EventHandler(this.tsmiSozlesmeClick);
            // 
            // tsmiSozlesmeKonutKrediSozlesmesi
            // 
            this.tsmiSozlesmeKonutKrediSozlesmesi.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSozlesmeKonutKrediSozlesmesi.Image")));
            this.tsmiSozlesmeKonutKrediSozlesmesi.Name = "tsmiSozlesmeKonutKrediSozlesmesi";
            this.tsmiSozlesmeKonutKrediSozlesmesi.Size = new System.Drawing.Size(351, 22);
            this.tsmiSozlesmeKonutKrediSozlesmesi.Text = "Konut Kredisi Sözleşmesi";
            this.tsmiSozlesmeKonutKrediSozlesmesi.Click += new System.EventHandler(this.tsmiSozlesmeClick);
            // 
            // tsmiSozlesmeIhtiyacKrediSozlesmesi
            // 
            this.tsmiSozlesmeIhtiyacKrediSozlesmesi.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSozlesmeIhtiyacKrediSozlesmesi.Image")));
            this.tsmiSozlesmeIhtiyacKrediSozlesmesi.Name = "tsmiSozlesmeIhtiyacKrediSozlesmesi";
            this.tsmiSozlesmeIhtiyacKrediSozlesmesi.Size = new System.Drawing.Size(351, 22);
            this.tsmiSozlesmeIhtiyacKrediSozlesmesi.Text = "İhtiyaç Kredisi Sözleşmesi";
            this.tsmiSozlesmeIhtiyacKrediSozlesmesi.Click += new System.EventHandler(this.tsmiSozlesmeClick);
            // 
            // tsmiSozlesmeTasitKrediSozlesmesi
            // 
            this.tsmiSozlesmeTasitKrediSozlesmesi.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSozlesmeTasitKrediSozlesmesi.Image")));
            this.tsmiSozlesmeTasitKrediSozlesmesi.Name = "tsmiSozlesmeTasitKrediSozlesmesi";
            this.tsmiSozlesmeTasitKrediSozlesmesi.Size = new System.Drawing.Size(351, 22);
            this.tsmiSozlesmeTasitKrediSozlesmesi.Text = "Taşıt Kredisi Sözleşmesi";
            this.tsmiSozlesmeTasitKrediSozlesmesi.Click += new System.EventHandler(this.tsmiSozlesmeClick);
            // 
            // noterdenBorçİkrarıToolStripMenuItem
            // 
            this.noterdenBorçİkrarıToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("noterdenBorçİkrarıToolStripMenuItem.Image")));
            this.noterdenBorçİkrarıToolStripMenuItem.Name = "noterdenBorçİkrarıToolStripMenuItem";
            this.noterdenBorçİkrarıToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.noterdenBorçİkrarıToolStripMenuItem.Text = "Noterden İmza Tasdikli Borç Senedi";
            this.noterdenBorçİkrarıToolStripMenuItem.Click += new System.EventHandler(this.tsmiSozlesmeClick);
            // 
            // resenDüzenlenmişNoterSenediToolStripMenuItem
            // 
            this.resenDüzenlenmişNoterSenediToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.resenDüzenlenmişNoterSenediToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("resenDüzenlenmişNoterSenediToolStripMenuItem.Image")));
            this.resenDüzenlenmişNoterSenediToolStripMenuItem.Name = "resenDüzenlenmişNoterSenediToolStripMenuItem";
            this.resenDüzenlenmişNoterSenediToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.resenDüzenlenmişNoterSenediToolStripMenuItem.Text = "Noterden Düzenleme Borç Senedi ( İLAM girişinden girilir. )";
            // 
            // avukatlıkKm35AToolStripMenuItem
            // 
            this.avukatlıkKm35AToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.avukatlıkKm35AToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("avukatlıkKm35AToolStripMenuItem.Image")));
            this.avukatlıkKm35AToolStripMenuItem.Name = "avukatlıkKm35AToolStripMenuItem";
            this.avukatlıkKm35AToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.avukatlıkKm35AToolStripMenuItem.Text = "Avukatlık K.m.35/A ( İLAM girişinden girilir. )";
            // 
            // tsmiTakipler
            // 
            this.tsmiTakipler.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTakiplerKlasoreGirilmisAlacaklardanTakipOlustur,
            this.tsmiTakiplerYeniTakipAc});
            this.tsmiTakipler.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTakipler.Image")));
            this.tsmiTakipler.Name = "tsmiTakipler";
            this.tsmiTakipler.Size = new System.Drawing.Size(228, 22);
            this.tsmiTakipler.Text = "Takipler";
            // 
            // tsmiTakiplerKlasoreGirilmisAlacaklardanTakipOlustur
            // 
            this.tsmiTakiplerKlasoreGirilmisAlacaklardanTakipOlustur.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTakiplerKlasoreGirilmisAlacaklardanTakipOlustur.Image")));
            this.tsmiTakiplerKlasoreGirilmisAlacaklardanTakipOlustur.Name = "tsmiTakiplerKlasoreGirilmisAlacaklardanTakipOlustur";
            this.tsmiTakiplerKlasoreGirilmisAlacaklardanTakipOlustur.Size = new System.Drawing.Size(388, 22);
            this.tsmiTakiplerKlasoreGirilmisAlacaklardanTakipOlustur.Text = "Klasöre Girilmiş Kredi Alacaklarından Takip Oluştur";
            this.tsmiTakiplerKlasoreGirilmisAlacaklardanTakipOlustur.Click += new System.EventHandler(this.alacaklardanİcraDosyasıOluşturToolStripMenuItem_Click);
            // 
            // tsmiTakiplerYeniTakipAc
            // 
            this.tsmiTakiplerYeniTakipAc.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTakiplerYeniTakipAc.Image")));
            this.tsmiTakiplerYeniTakipAc.Name = "tsmiTakiplerYeniTakipAc";
            this.tsmiTakiplerYeniTakipAc.Size = new System.Drawing.Size(388, 22);
            this.tsmiTakiplerYeniTakipAc.Text = "Teminat Senetlerinden(Müşteri Çek ve Bonosundan) Takip Oluştur";
            this.tsmiTakiplerYeniTakipAc.Click += new System.EventHandler(this.icraDosyasıToolStripMenuItem_Click);
            // 
            // tsmiDavaDosyasi
            // 
            this.tsmiDavaDosyasi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.davacıToolStripMenuItem,
            this.davalıToolStripMenuItem});
            this.tsmiDavaDosyasi.Image = ((System.Drawing.Image)(resources.GetObject("tsmiDavaDosyasi.Image")));
            this.tsmiDavaDosyasi.Name = "tsmiDavaDosyasi";
            this.tsmiDavaDosyasi.Size = new System.Drawing.Size(228, 22);
            this.tsmiDavaDosyasi.Text = "&Dava Dosyası";
            // 
            // davacıToolStripMenuItem
            // 
            this.davacıToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("davacıToolStripMenuItem.Image")));
            this.davacıToolStripMenuItem.Name = "davacıToolStripMenuItem";
            this.davacıToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.davacıToolStripMenuItem.Text = "Davacı";
            this.davacıToolStripMenuItem.Click += new System.EventHandler(this.davacıToolStripMenuItem_Click);
            // 
            // davalıToolStripMenuItem
            // 
            this.davalıToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("davalıToolStripMenuItem.Image")));
            this.davalıToolStripMenuItem.Name = "davalıToolStripMenuItem";
            this.davalıToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.davalıToolStripMenuItem.Text = "Davalı";
            this.davalıToolStripMenuItem.Click += new System.EventHandler(this.davalıToolStripMenuItem_Click);
            // 
            // tsmiSorusturma
            // 
            this.tsmiSorusturma.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.şikayetEdenToolStripMenuItem,
            this.şikayetEdilenToolStripMenuItem});
            this.tsmiSorusturma.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSorusturma.Image")));
            this.tsmiSorusturma.Name = "tsmiSorusturma";
            this.tsmiSorusturma.Size = new System.Drawing.Size(228, 22);
            this.tsmiSorusturma.Text = "Soruştur&ma";
            // 
            // şikayetEdenToolStripMenuItem
            // 
            this.şikayetEdenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("şikayetEdenToolStripMenuItem.Image")));
            this.şikayetEdenToolStripMenuItem.Name = "şikayetEdenToolStripMenuItem";
            this.şikayetEdenToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.şikayetEdenToolStripMenuItem.Text = "Şikayet Eden";
            this.şikayetEdenToolStripMenuItem.Click += new System.EventHandler(this.şikayetEdenToolStripMenuItem_Click);
            // 
            // şikayetEdilenToolStripMenuItem
            // 
            this.şikayetEdilenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("şikayetEdilenToolStripMenuItem.Image")));
            this.şikayetEdilenToolStripMenuItem.Name = "şikayetEdilenToolStripMenuItem";
            this.şikayetEdilenToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.şikayetEdilenToolStripMenuItem.Text = "Şikayet Edilen";
            this.şikayetEdilenToolStripMenuItem.Click += new System.EventHandler(this.şikayetEdilenToolStripMenuItem_Click);
            // 
            // tsmiCizik2
            // 
            this.tsmiCizik2.Name = "tsmiCizik2";
            this.tsmiCizik2.Size = new System.Drawing.Size(225, 6);
            // 
            // tsmiIhtiyatiHaciz
            // 
            this.tsmiIhtiyatiHaciz.Image = ((System.Drawing.Image)(resources.GetObject("tsmiIhtiyatiHaciz.Image")));
            this.tsmiIhtiyatiHaciz.Name = "tsmiIhtiyatiHaciz";
            this.tsmiIhtiyatiHaciz.Size = new System.Drawing.Size(228, 22);
            this.tsmiIhtiyatiHaciz.Text = "İhtiyati &Haciz";
            this.tsmiIhtiyatiHaciz.Click += new System.EventHandler(this.tsmiIhtiyatiHaciz_Click);
            // 
            // tsmiIhtiyatiTedbir
            // 
            this.tsmiIhtiyatiTedbir.Image = ((System.Drawing.Image)(resources.GetObject("tsmiIhtiyatiTedbir.Image")));
            this.tsmiIhtiyatiTedbir.Name = "tsmiIhtiyatiTedbir";
            this.tsmiIhtiyatiTedbir.Size = new System.Drawing.Size(228, 22);
            this.tsmiIhtiyatiTedbir.Text = "İhtiyati Ted&bir";
            this.tsmiIhtiyatiTedbir.Click += new System.EventHandler(this.tsmiIhtiyatiTedbir_Click);
            // 
            // tsmiCizik
            // 
            this.tsmiCizik.Name = "tsmiCizik";
            this.tsmiCizik.Size = new System.Drawing.Size(225, 6);
            // 
            // tsmiOdeme
            // 
            this.tsmiOdeme.Image = ((System.Drawing.Image)(resources.GetObject("tsmiOdeme.Image")));
            this.tsmiOdeme.Name = "tsmiOdeme";
            this.tsmiOdeme.Size = new System.Drawing.Size(228, 22);
            this.tsmiOdeme.Text = "Ö&deme";
            this.tsmiOdeme.Click += new System.EventHandler(this.tsmiOdeme_Click);
            // 
            // tsmiMasraf
            // 
            this.tsmiMasraf.Image = ((System.Drawing.Image)(resources.GetObject("tsmiMasraf.Image")));
            this.tsmiMasraf.Name = "tsmiMasraf";
            this.tsmiMasraf.Size = new System.Drawing.Size(228, 22);
            this.tsmiMasraf.Text = "Masra&f";
            this.tsmiMasraf.Click += new System.EventHandler(this.tsmiMasraf_Click);
            // 
            // tsmiMalHakGirisi
            // 
            this.tsmiMalHakGirisi.Image = ((System.Drawing.Image)(resources.GetObject("tsmiMalHakGirisi.Image")));
            this.tsmiMalHakGirisi.Name = "tsmiMalHakGirisi";
            this.tsmiMalHakGirisi.Size = new System.Drawing.Size(228, 22);
            this.tsmiMalHakGirisi.Text = "Mal / Hak Girişi";
            this.tsmiMalHakGirisi.Click += new System.EventHandler(this.tsmiMalHakGirisi_Click);
            // 
            // tsmIlamGirisi
            // 
            this.tsmIlamGirisi.Image = ((System.Drawing.Image)(resources.GetObject("tsmIlamGirisi.Image")));
            this.tsmIlamGirisi.Name = "tsmIlamGirisi";
            this.tsmIlamGirisi.Size = new System.Drawing.Size(228, 22);
            this.tsmIlamGirisi.Text = "İlam Girişi";
            this.tsmIlamGirisi.Click += new System.EventHandler(this.tsmIlamGirisi_Click);
            // 
            // ihtarnameGirişiToolStripMenuItem
            // 
            this.ihtarnameGirişiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ihtarnameGirişiToolStripMenuItem.Image")));
            this.ihtarnameGirişiToolStripMenuItem.Name = "ihtarnameGirişiToolStripMenuItem";
            this.ihtarnameGirişiToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.ihtarnameGirişiToolStripMenuItem.Text = "İhtarname Giriş";
            this.ihtarnameGirişiToolStripMenuItem.Click += new System.EventHandler(this.ihtarnameGirişiToolStripMenuItem_Click);
            // 
            // munzamSenetToolStripMenuItem
            // 
            this.munzamSenetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("munzamSenetToolStripMenuItem.Image")));
            this.munzamSenetToolStripMenuItem.Name = "munzamSenetToolStripMenuItem";
            this.munzamSenetToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.munzamSenetToolStripMenuItem.Text = "Alacak Senedi (MUNZAM SENET)";
            this.munzamSenetToolStripMenuItem.Click += new System.EventHandler(this.munzamSenetToolStripMenuItem_Click);
            // 
            // tazminToolStripMenuItem
            // 
            this.tazminToolStripMenuItem.Name = "tazminToolStripMenuItem";
            this.tazminToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.tazminToolStripMenuItem.Text = "Tazmin";
            this.tazminToolStripMenuItem.Click += new System.EventHandler(this.tazminToolStripMenuItem_Click);
            // 
            // iadeToolStripMenuItem
            // 
            this.iadeToolStripMenuItem.Name = "iadeToolStripMenuItem";
            this.iadeToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.iadeToolStripMenuItem.Text = "İade";
            this.iadeToolStripMenuItem.Click += new System.EventHandler(this.iadeToolStripMenuItem_Click);
            // 
            // depoToolStripMenuItem
            // 
            this.depoToolStripMenuItem.Name = "depoToolStripMenuItem";
            this.depoToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.depoToolStripMenuItem.Text = "Depo";
            this.depoToolStripMenuItem.Click += new System.EventHandler(this.depoToolStripMenuItem_Click);
            // 
            // tsmiAlacakDuzenle
            // 
            this.tsmiAlacakDuzenle.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAlacakDuzenle.Image")));
            this.tsmiAlacakDuzenle.Name = "tsmiAlacakDuzenle";
            this.tsmiAlacakDuzenle.Size = new System.Drawing.Size(219, 22);
            this.tsmiAlacakDuzenle.Tag = typeof(AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN);
            this.tsmiAlacakDuzenle.Text = "Alacak Neden &Duzenle";
            this.tsmiAlacakDuzenle.Click += new System.EventHandler(this.tsmiAlacakDuzenle_Click);
            // 
            // tsmihtiyatiTedbirDuzenle
            // 
            this.tsmihtiyatiTedbirDuzenle.Image = ((System.Drawing.Image)(resources.GetObject("tsmihtiyatiTedbirDuzenle.Image")));
            this.tsmihtiyatiTedbirDuzenle.Name = "tsmihtiyatiTedbirDuzenle";
            this.tsmihtiyatiTedbirDuzenle.Size = new System.Drawing.Size(219, 22);
            this.tsmihtiyatiTedbirDuzenle.Text = "İhtiyatiTedbir Duzenle";
            this.tsmihtiyatiTedbirDuzenle.Click += new System.EventHandler(this.tsmihtiyatiTedbirDuzenle_Click);
            // 
            // tsmIlamBilgisiDuzenle
            // 
            this.tsmIlamBilgisiDuzenle.Image = ((System.Drawing.Image)(resources.GetObject("tsmIlamBilgisiDuzenle.Image")));
            this.tsmIlamBilgisiDuzenle.Name = "tsmIlamBilgisiDuzenle";
            this.tsmIlamBilgisiDuzenle.Size = new System.Drawing.Size(219, 22);
            this.tsmIlamBilgisiDuzenle.Text = "Ilam Bilgisi Düzenle";
            this.tsmIlamBilgisiDuzenle.Click += new System.EventHandler(this.tsmIlamBilgisiDuzenle_Click);
            // 
            // tsmIhtiyatiHacizDuzenle
            // 
            this.tsmIhtiyatiHacizDuzenle.Image = ((System.Drawing.Image)(resources.GetObject("tsmIhtiyatiHacizDuzenle.Image")));
            this.tsmIhtiyatiHacizDuzenle.Name = "tsmIhtiyatiHacizDuzenle";
            this.tsmIhtiyatiHacizDuzenle.Size = new System.Drawing.Size(219, 22);
            this.tsmIhtiyatiHacizDuzenle.Text = "İhtiyati Haciz Düzenle";
            this.tsmIhtiyatiHacizDuzenle.Click += new System.EventHandler(this.tsmIhtiyatiHacizDuzenle_Click);
            // 
            // tsmIhtiyatiHacizDilekcesi
            // 
            this.tsmIhtiyatiHacizDilekcesi.Image = ((System.Drawing.Image)(resources.GetObject("tsmIhtiyatiHacizDilekcesi.Image")));
            this.tsmIhtiyatiHacizDilekcesi.Name = "tsmIhtiyatiHacizDilekcesi";
            this.tsmIhtiyatiHacizDilekcesi.Size = new System.Drawing.Size(219, 22);
            this.tsmIhtiyatiHacizDilekcesi.Text = "İhtiyati Haciz Dilekçesi";
            this.tsmIhtiyatiHacizDilekcesi.Click += new System.EventHandler(this.tsmIhtiyatiHacizDilekcesi_Click);
            // 
            // ihtarnameDüzenleToolStripMenuItem
            // 
            this.ihtarnameDüzenleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ihtarnameDüzenleToolStripMenuItem.Image")));
            this.ihtarnameDüzenleToolStripMenuItem.Name = "ihtarnameDüzenleToolStripMenuItem";
            this.ihtarnameDüzenleToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.ihtarnameDüzenleToolStripMenuItem.Text = "İhtarname Düzenle";
            this.ihtarnameDüzenleToolStripMenuItem.Click += new System.EventHandler(this.ihtarnameDüzenleToolStripMenuItem_Click);
            // 
            // tsmkiymetliEvrakBilgileriDuzenle
            // 
            this.tsmkiymetliEvrakBilgileriDuzenle.Image = ((System.Drawing.Image)(resources.GetObject("tsmkiymetliEvrakBilgileriDuzenle.Image")));
            this.tsmkiymetliEvrakBilgileriDuzenle.Name = "tsmkiymetliEvrakBilgileriDuzenle";
            this.tsmkiymetliEvrakBilgileriDuzenle.Size = new System.Drawing.Size(219, 22);
            this.tsmkiymetliEvrakBilgileriDuzenle.Text = " Kıymetli Evrak Bilgileri Düzenle";
            this.tsmkiymetliEvrakBilgileriDuzenle.Click += new System.EventHandler(this.tsmkiymetliEvrakBilgileriDuzenle_Click);
            // 
            // ödemeyiToolStripMenuItem
            // 
            this.ödemeyiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ödemeyiToolStripMenuItem.Image")));
            this.ödemeyiToolStripMenuItem.Name = "ödemeyiToolStripMenuItem";
            this.ödemeyiToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.ödemeyiToolStripMenuItem.Text = "Ödeme Düzenle";
            this.ödemeyiToolStripMenuItem.Click += new System.EventHandler(this.ödemeyiToolStripMenuItem_Click);
            // 
            // masrafDüzenleToolStripMenuItem
            // 
            this.masrafDüzenleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("masrafDüzenleToolStripMenuItem.Image")));
            this.masrafDüzenleToolStripMenuItem.Name = "masrafDüzenleToolStripMenuItem";
            this.masrafDüzenleToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.masrafDüzenleToolStripMenuItem.Text = "Masraf Düzenle";
            this.masrafDüzenleToolStripMenuItem.Click += new System.EventHandler(this.masrafDüzenleToolStripMenuItem_Click);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("düzenleToolStripMenuItem.Image")));
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(216, 6);
            // 
            // ağacınTümünüAçToolStripMenuItem
            // 
            this.ağacınTümünüAçToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ağacınTümünüAçToolStripMenuItem.Image")));
            this.ağacınTümünüAçToolStripMenuItem.Name = "ağacınTümünüAçToolStripMenuItem";
            this.ağacınTümünüAçToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.ağacınTümünüAçToolStripMenuItem.Text = "Ağacı Tamamen Aç";
            this.ağacınTümünüAçToolStripMenuItem.Click += new System.EventHandler(this.ağacınTümünüAçToolStripMenuItem_Click);
            // 
            // ağacıTamamenKapatToolStripMenuItem
            // 
            this.ağacıTamamenKapatToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ağacıTamamenKapatToolStripMenuItem.Image")));
            this.ağacıTamamenKapatToolStripMenuItem.Name = "ağacıTamamenKapatToolStripMenuItem";
            this.ağacıTamamenKapatToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.ağacıTamamenKapatToolStripMenuItem.Text = "Ağacı Tamamen Kapat";
            this.ağacıTamamenKapatToolStripMenuItem.Click += new System.EventHandler(this.ağacıTamamenKapatToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(216, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(219, 22);
            this.toolStripMenuItem1.Text = "Simülasyona Gönder";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // aporToolStripMenuItem
            // 
            this.aporToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aporToolStripMenuItem.Image")));
            this.aporToolStripMenuItem.Name = "aporToolStripMenuItem";
            this.aporToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.aporToolStripMenuItem.Text = "Kredi Dosyası Raporu";
            this.aporToolStripMenuItem.Click += new System.EventHandler(this.aporToolStripMenuItem_Click);
            // 
            // klasörAğaçRaporuToolStripMenuItem
            // 
            this.klasörAğaçRaporuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordeGönderToolStripMenuItem,
            this.exceleGönderToolStripMenuItem,
            this.pDFeGönderToolStripMenuItem,
            this.raporDüzenleyicisineGönderToolStripMenuItem1});
            this.klasörAğaçRaporuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("klasörAğaçRaporuToolStripMenuItem.Image")));
            this.klasörAğaçRaporuToolStripMenuItem.Name = "klasörAğaçRaporuToolStripMenuItem";
            this.klasörAğaçRaporuToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.klasörAğaçRaporuToolStripMenuItem.Text = "Klasör Ağaç Raporu";
            // 
            // wordeGönderToolStripMenuItem
            // 
            this.wordeGönderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("wordeGönderToolStripMenuItem.Image")));
            this.wordeGönderToolStripMenuItem.Name = "wordeGönderToolStripMenuItem";
            this.wordeGönderToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.wordeGönderToolStripMenuItem.Text = "Word\'e Gönder";
            this.wordeGönderToolStripMenuItem.Click += new System.EventHandler(this.wordeGönderToolStripMenuItem1_Click);
            // 
            // exceleGönderToolStripMenuItem
            // 
            this.exceleGönderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exceleGönderToolStripMenuItem.Image")));
            this.exceleGönderToolStripMenuItem.Name = "exceleGönderToolStripMenuItem";
            this.exceleGönderToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.exceleGönderToolStripMenuItem.Text = "Excel\'e Gönder";
            this.exceleGönderToolStripMenuItem.Click += new System.EventHandler(this.exceleGönderToolStripMenuItem1_Click);
            // 
            // pDFeGönderToolStripMenuItem
            // 
            this.pDFeGönderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pDFeGönderToolStripMenuItem.Image")));
            this.pDFeGönderToolStripMenuItem.Name = "pDFeGönderToolStripMenuItem";
            this.pDFeGönderToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.pDFeGönderToolStripMenuItem.Text = "PDF\'e Gönder";
            this.pDFeGönderToolStripMenuItem.Click += new System.EventHandler(this.pDFeGönderToolStripMenuItem1_Click);
            // 
            // raporDüzenleyicisineGönderToolStripMenuItem1
            // 
            this.raporDüzenleyicisineGönderToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("raporDüzenleyicisineGönderToolStripMenuItem1.Image")));
            this.raporDüzenleyicisineGönderToolStripMenuItem1.Name = "raporDüzenleyicisineGönderToolStripMenuItem1";
            this.raporDüzenleyicisineGönderToolStripMenuItem1.Size = new System.Drawing.Size(216, 22);
            this.raporDüzenleyicisineGönderToolStripMenuItem1.Text = "Rapor Düzenleyicisine Gönder";
            this.raporDüzenleyicisineGönderToolStripMenuItem1.Click += new System.EventHandler(this.raporDüzenleyicisineGönderToolStripMenuItem_Click);
            // 
            // imgKlasor
            // 
            this.imgKlasor.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgKlasor.ImageStream")));
            this.imgKlasor.TransparentColor = System.Drawing.Color.Transparent;
            this.imgKlasor.Images.SetKeyName(0, "ara_karar.png");
            this.imgKlasor.Images.SetKeyName(1, "masa01_22x22.png");
            this.imgKlasor.Images.SetKeyName(2, "money.png");
            this.imgKlasor.Images.SetKeyName(3, "20.png");
            this.imgKlasor.Images.SetKeyName(4, "adliyede_gorusme.png");
            this.imgKlasor.Images.SetKeyName(5, "Dava_22x22.png");
            this.imgKlasor.Images.SetKeyName(6, "fihrist1_22x22.png");
            this.imgKlasor.Images.SetKeyName(7, "haciz2.png");
            // 
            // lueBolum
            // 
            this.lueBolum.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndProje, "PROJE_TIP_ID", true));
            this.lueBolum.Location = new System.Drawing.Point(528, 215);
            this.lueBolum.Name = "lueBolum";
            this.lueBolum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBolum.Size = new System.Drawing.Size(439, 20);
            this.lueBolum.StyleController = this.lcProjeEkrani;
            this.lueBolum.TabIndex = 17;
            // 
            // memAciklama
            // 
            this.memAciklama.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndProje, "ACIKLAMA", true));
            this.memAciklama.Location = new System.Drawing.Point(443, 438);
            this.memAciklama.Name = "memAciklama";
            this.memAciklama.Size = new System.Drawing.Size(512, 136);
            this.memAciklama.StyleController = this.lcProjeEkrani;
            this.memAciklama.TabIndex = 16;
            // 
            // lueDurum
            // 
            this.lueDurum.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndProje, "DURUM_ID", true));
            this.lueDurum.Location = new System.Drawing.Point(800, 167);
            this.lueDurum.Name = "lueDurum";
            this.lueDurum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDurum.Size = new System.Drawing.Size(167, 20);
            this.lueDurum.StyleController = this.lcProjeEkrani;
            this.lueDurum.TabIndex = 9;
            // 
            // dtKapamaTarihi
            // 
            this.dtKapamaTarihi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndProje, "BITIS_TARIHI", true));
            this.dtKapamaTarihi.EditValue = null;
            this.dtKapamaTarihi.Location = new System.Drawing.Point(800, 191);
            this.dtKapamaTarihi.Name = "dtKapamaTarihi";
            this.dtKapamaTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtKapamaTarihi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtKapamaTarihi.Size = new System.Drawing.Size(167, 20);
            this.dtKapamaTarihi.StyleController = this.lcProjeEkrani;
            this.dtKapamaTarihi.TabIndex = 7;
            // 
            // dtIntikalTarihi
            // 
            this.dtIntikalTarihi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndProje, "BASLANGIC_TARIHI", true));
            this.dtIntikalTarihi.EditValue = null;
            this.dtIntikalTarihi.Location = new System.Drawing.Point(528, 191);
            this.dtIntikalTarihi.Name = "dtIntikalTarihi";
            this.dtIntikalTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtIntikalTarihi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtIntikalTarihi.Size = new System.Drawing.Size(171, 20);
            this.dtIntikalTarihi.StyleController = this.lcProjeEkrani;
            this.dtIntikalTarihi.TabIndex = 6;
            // 
            // txtAd
            // 
            this.txtAd.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndProje, "ADI", true));
            this.txtAd.Location = new System.Drawing.Point(528, 143);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(439, 20);
            this.txtAd.StyleController = this.lcProjeEkrani;
            this.txtAd.TabIndex = 5;
            // 
            // txtKod
            // 
            this.txtKod.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndProje, "KOD", true));
            this.txtKod.Location = new System.Drawing.Point(528, 167);
            this.txtKod.Name = "txtKod";
            this.txtKod.Size = new System.Drawing.Size(171, 20);
            this.txtKod.StyleController = this.lcProjeEkrani;
            this.txtKod.TabIndex = 4;
            // 
            // lueSube
            // 
            this.lueSube.Location = new System.Drawing.Point(528, 239);
            this.lueSube.Name = "lueSube";
            this.lueSube.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSube.Properties.DisplayMember = "OZEL_KOD";
            this.lueSube.Properties.NullText = "Seç";
            this.lueSube.Properties.ValueMember = "ID";
            this.lueSube.Properties.View = this.searchLookUpEdit1View;
            this.lueSube.Size = new System.Drawing.Size(439, 20);
            this.lueSube.StyleController = this.lcProjeEkrani;
            this.lueSube.TabIndex = 8;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn28});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "ID";
            this.gridColumn11.FieldName = "ID";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Ad";
            this.gridColumn23.FieldName = "AD";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 0;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Şube";
            this.gridColumn24.FieldName = "OZEL_KOD";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 1;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "CARI_ID";
            this.gridColumn28.FieldName = "CARI_ID";
            this.gridColumn28.Name = "gridColumn28";
            // 
            // lcItemHesapKatTarihi
            // 
            this.lcItemHesapKatTarihi.Control = this.dtHesapKatTarihi;
            this.lcItemHesapKatTarihi.CustomizationFormText = "layoutControlItem17";
            this.lcItemHesapKatTarihi.Location = new System.Drawing.Point(0, 168);
            this.lcItemHesapKatTarihi.Name = "lcItemHesapKatTarihi";
            this.lcItemHesapKatTarihi.Size = new System.Drawing.Size(396, 24);
            this.lcItemHesapKatTarihi.Text = "Hesap Kat T";
            this.lcItemHesapKatTarihi.TextSize = new System.Drawing.Size(67, 13);
            this.lcItemHesapKatTarihi.TextToControlDistance = 5;
            this.lcItemHesapKatTarihi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemAra,
            this.lcItemBul,
            this.lcGroupBilgiler});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1015, 634);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lcItemAra
            // 
            this.lcItemAra.Control = this.lueAra;
            this.lcItemAra.CustomizationFormText = "Ara";
            this.lcItemAra.Location = new System.Drawing.Point(0, 0);
            this.lcItemAra.Name = "lcItemAra";
            this.lcItemAra.Size = new System.Drawing.Size(897, 26);
            this.lcItemAra.Text = "Klasör";
            this.lcItemAra.TextSize = new System.Drawing.Size(94, 13);
            // 
            // lcItemBul
            // 
            this.lcItemBul.Control = this.sbtnBul;
            this.lcItemBul.CustomizationFormText = "Bul";
            this.lcItemBul.Location = new System.Drawing.Point(897, 0);
            this.lcItemBul.Name = "lcItemBul";
            this.lcItemBul.Size = new System.Drawing.Size(98, 26);
            this.lcItemBul.Text = "Bul";
            this.lcItemBul.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemBul.TextToControlDistance = 0;
            this.lcItemBul.TextVisible = false;
            // 
            // lcGroupBilgiler
            // 
            this.lcGroupBilgiler.CustomizationFormText = "layoutControlGroup6";
            this.lcGroupBilgiler.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup2});
            this.lcGroupBilgiler.Location = new System.Drawing.Point(0, 26);
            this.lcGroupBilgiler.Name = "lcGroupBilgiler";
            this.lcGroupBilgiler.Size = new System.Drawing.Size(995, 588);
            this.lcGroupBilgiler.Text = "Bilgiler";
            this.lcGroupBilgiler.TextVisible = false;
            // 
            // tabbedControlGroup2
            // 
            this.tabbedControlGroup2.CustomizationFormText = "tabbedControlGroup2";
            this.tabbedControlGroup2.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.tabbedControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup2.Name = "tabbedControlGroup2";
            this.tabbedControlGroup2.SelectedTabPage = this.layoutControlGroup10;
            this.tabbedControlGroup2.SelectedTabPageIndex = 2;
            this.tabbedControlGroup2.Size = new System.Drawing.Size(971, 564);
            this.tabbedControlGroup2.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup9,
            this.layoutControlGroup8,
            this.layoutControlGroup10,
            this.layoutControlGroup11,
            this.lcGorupOdemePlani,
            this.lcGroupDokumanlar,
            this.lcGroupTeklifKarar,
            this.lcGroupMasraflar,
            this.lcGroupOdemeler,
            this.lcGroupDagitilmamisMasraflar,
            this.lcGroupDagitilmamisTahsilatlar});
            this.tabbedControlGroup2.Text = "tabbedControlGroup2";
            this.tabbedControlGroup2.TextLocation = DevExpress.Utils.Locations.Left;
            this.tabbedControlGroup2.SelectedPageChanging += new DevExpress.XtraLayout.LayoutTabPageChangingEventHandler(this.tabbedControlGroup2_SelectedPageChanging);
            // 
            // layoutControlGroup10
            // 
            this.layoutControlGroup10.CustomizationFormText = "Yapılacak İşler";
            this.layoutControlGroup10.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemYapilacakIsler});
            this.layoutControlGroup10.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup10.Name = "layoutControlGroup10";
            this.layoutControlGroup10.Size = new System.Drawing.Size(823, 540);
            this.layoutControlGroup10.Text = "Yapılacak İşler";
            // 
            // lcItemYapilacakIsler
            // 
            this.lcItemYapilacakIsler.Control = this.ucGorevler1;
            this.lcItemYapilacakIsler.CustomizationFormText = "lcItemYapilacakIsler";
            this.lcItemYapilacakIsler.Location = new System.Drawing.Point(0, 0);
            this.lcItemYapilacakIsler.Name = "lcItemYapilacakIsler";
            this.lcItemYapilacakIsler.Size = new System.Drawing.Size(823, 540);
            this.lcItemYapilacakIsler.Text = "Yapılacak İşler";
            this.lcItemYapilacakIsler.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemYapilacakIsler.TextToControlDistance = 0;
            this.lcItemYapilacakIsler.TextVisible = false;
            // 
            // layoutControlGroup9
            // 
            this.layoutControlGroup9.CustomizationFormText = "Klasör Bilgileri";
            this.layoutControlGroup9.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup4,
            this.layoutControlGroup3});
            this.layoutControlGroup9.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup9.Name = "layoutControlGroup9";
            this.layoutControlGroup9.Size = new System.Drawing.Size(823, 540);
            this.layoutControlGroup9.Text = "Klasör Bilgileri";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Kredi Hesap Bilgileri";
            this.layoutControlGroup2.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutControlGroup2.ExpandButtonVisible = true;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemKrediHesapBilgileri});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(259, 512);
            this.layoutControlGroup2.Text = "Alacak Bilgileri";
            // 
            // lcItemKrediHesapBilgileri
            // 
            this.lcItemKrediHesapBilgileri.Control = this.treeKrediHesapBilgileri;
            this.lcItemKrediHesapBilgileri.CustomizationFormText = "layoutControlItem18";
            this.lcItemKrediHesapBilgileri.Location = new System.Drawing.Point(0, 0);
            this.lcItemKrediHesapBilgileri.Name = "lcItemKrediHesapBilgileri";
            this.lcItemKrediHesapBilgileri.Size = new System.Drawing.Size(235, 469);
            this.lcItemKrediHesapBilgileri.Text = "Kredi Hesap Bilgileri";
            this.lcItemKrediHesapBilgileri.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemKrediHesapBilgileri.TextToControlDistance = 0;
            this.lcItemKrediHesapBilgileri.TextVisible = false;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = "Kredi Dosya Detayları";
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemKodu,
            this.lcItemIntikalTarihi,
            this.lcItemAdi,
            this.lcItemDurum,
            this.lcItemKapamaTarihi,
            this.lcItemBolum,
            this.layoutControlGroup5,
            this.lcItemSube,
            this.layoutControlItem1,
            this.lcItemKrediGrubu,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem11,
            this.layoutControlItem12});
            this.layoutControlGroup4.Location = new System.Drawing.Point(259, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(564, 540);
            this.layoutControlGroup4.Text = "Ticari Alacak Detayları";
            // 
            // lcItemKodu
            // 
            this.lcItemKodu.Control = this.txtKod;
            this.lcItemKodu.CustomizationFormText = "layoutControlItem1";
            this.lcItemKodu.Location = new System.Drawing.Point(0, 74);
            this.lcItemKodu.Name = "lcItemKodu";
            this.lcItemKodu.Size = new System.Drawing.Size(272, 24);
            this.lcItemKodu.Text = "Klasör No";
            this.lcItemKodu.TextSize = new System.Drawing.Size(94, 13);
            // 
            // lcItemIntikalTarihi
            // 
            this.lcItemIntikalTarihi.Control = this.dtIntikalTarihi;
            this.lcItemIntikalTarihi.CustomizationFormText = "layoutControlItem3";
            this.lcItemIntikalTarihi.Location = new System.Drawing.Point(0, 98);
            this.lcItemIntikalTarihi.Name = "lcItemIntikalTarihi";
            this.lcItemIntikalTarihi.Size = new System.Drawing.Size(272, 24);
            this.lcItemIntikalTarihi.Text = "İntikal Tarihi";
            this.lcItemIntikalTarihi.TextSize = new System.Drawing.Size(94, 13);
            // 
            // lcItemAdi
            // 
            this.lcItemAdi.Control = this.txtAd;
            this.lcItemAdi.CustomizationFormText = "layoutControlItem2";
            this.lcItemAdi.Location = new System.Drawing.Point(0, 50);
            this.lcItemAdi.Name = "lcItemAdi";
            this.lcItemAdi.Size = new System.Drawing.Size(540, 24);
            this.lcItemAdi.Text = "Adı";
            this.lcItemAdi.TextSize = new System.Drawing.Size(94, 13);
            // 
            // lcItemDurum
            // 
            this.lcItemDurum.Control = this.lueDurum;
            this.lcItemDurum.CustomizationFormText = "layoutControlItem6";
            this.lcItemDurum.Location = new System.Drawing.Point(272, 74);
            this.lcItemDurum.Name = "lcItemDurum";
            this.lcItemDurum.Size = new System.Drawing.Size(268, 24);
            this.lcItemDurum.Text = "Durum";
            this.lcItemDurum.TextSize = new System.Drawing.Size(94, 13);
            // 
            // lcItemKapamaTarihi
            // 
            this.lcItemKapamaTarihi.Control = this.dtKapamaTarihi;
            this.lcItemKapamaTarihi.CustomizationFormText = "layoutControlItem4";
            this.lcItemKapamaTarihi.Location = new System.Drawing.Point(272, 98);
            this.lcItemKapamaTarihi.Name = "lcItemKapamaTarihi";
            this.lcItemKapamaTarihi.Size = new System.Drawing.Size(268, 24);
            this.lcItemKapamaTarihi.Text = "Kapama Tarihi";
            this.lcItemKapamaTarihi.TextSize = new System.Drawing.Size(94, 13);
            // 
            // lcItemBolum
            // 
            this.lcItemBolum.Control = this.lueBolum;
            this.lcItemBolum.CustomizationFormText = "layoutControlItem14";
            this.lcItemBolum.Location = new System.Drawing.Point(0, 122);
            this.lcItemBolum.Name = "lcItemBolum";
            this.lcItemBolum.Size = new System.Drawing.Size(540, 24);
            this.lcItemBolum.Text = "Bölüm";
            this.lcItemBolum.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.CustomizationFormText = "Açıklama";
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemProjeAciklama});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 314);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(540, 183);
            this.layoutControlGroup5.Text = "Sorumlu Avukat Görüşü";
            // 
            // lcItemProjeAciklama
            // 
            this.lcItemProjeAciklama.Control = this.memAciklama;
            this.lcItemProjeAciklama.CustomizationFormText = "layoutControlItem13";
            this.lcItemProjeAciklama.Location = new System.Drawing.Point(0, 0);
            this.lcItemProjeAciklama.Name = "lcItemProjeAciklama";
            this.lcItemProjeAciklama.Size = new System.Drawing.Size(516, 140);
            this.lcItemProjeAciklama.Text = "lcItemProjeAciklama";
            this.lcItemProjeAciklama.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemProjeAciklama.TextToControlDistance = 0;
            this.lcItemProjeAciklama.TextVisible = false;
            // 
            // lcItemSube
            // 
            this.lcItemSube.Control = this.lueSube;
            this.lcItemSube.CustomizationFormText = "layoutControlItem5";
            this.lcItemSube.Location = new System.Drawing.Point(0, 146);
            this.lcItemSube.Name = "lcItemSube";
            this.lcItemSube.Size = new System.Drawing.Size(540, 24);
            this.lcItemSube.Text = "Şube";
            this.lcItemSube.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.simpleButton1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(540, 26);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // lcItemKrediGrubu
            // 
            this.lcItemKrediGrubu.Control = this.lueKrediGrubu;
            this.lcItemKrediGrubu.CustomizationFormText = "Kredi Grubu";
            this.lcItemKrediGrubu.Location = new System.Drawing.Point(0, 26);
            this.lcItemKrediGrubu.Name = "lcItemKrediGrubu";
            this.lcItemKrediGrubu.Size = new System.Drawing.Size(540, 24);
            this.lcItemKrediGrubu.Text = "Kredi Grubu";
            this.lcItemKrediGrubu.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lueOzelKod1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 170);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(272, 24);
            this.layoutControlItem2.Text = "Özel Kod 1";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lueOzelKod3;
            this.layoutControlItem3.CustomizationFormText = "Özel Kod 3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 194);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(272, 24);
            this.layoutControlItem3.Text = "Özel Kod 3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lueOzelKod2;
            this.layoutControlItem4.CustomizationFormText = "Özel Kod 2";
            this.layoutControlItem4.Location = new System.Drawing.Point(272, 170);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(268, 24);
            this.layoutControlItem4.Text = "Özel Kod 2";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lueOzelKod4;
            this.layoutControlItem5.CustomizationFormText = "Özel Kod 4";
            this.layoutControlItem5.Location = new System.Drawing.Point(272, 194);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(268, 24);
            this.layoutControlItem5.Text = "Özel Kod 4";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtRef1;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 218);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(540, 24);
            this.layoutControlItem6.Text = "Referans No 1";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtRef2;
            this.layoutControlItem7.CustomizationFormText = "Referans No 2";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 242);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(540, 24);
            this.layoutControlItem7.Text = "Referans No 2";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtRef3;
            this.layoutControlItem8.CustomizationFormText = "Referans No 3";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 266);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(540, 24);
            this.layoutControlItem8.Text = "Referans No 3";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.spinKazanmaOrani;
            this.layoutControlItem11.CustomizationFormText = "Kazanma Oranı";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 290);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(212, 24);
            this.layoutControlItem11.Text = "Kazanma Oranı";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.dateBeklenenBitisTarihi;
            this.layoutControlItem12.CustomizationFormText = "Beklenen Bitiş Tarihi";
            this.layoutControlItem12.Location = new System.Drawing.Point(212, 290);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(328, 24);
            this.layoutControlItem12.Text = "Beklenen Bitiş Tarihi";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "layoutControlGroup3";
            this.layoutControlGroup3.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutControlGroup3.ExpandButtonVisible = true;
            this.layoutControlGroup3.Expanded = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemTaraflar});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 512);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(259, 28);
            this.layoutControlGroup3.Text = "Taraflar";
            // 
            // lcItemTaraflar
            // 
            this.lcItemTaraflar.Control = this.gcTaraflar;
            this.lcItemTaraflar.CustomizationFormText = "layoutControlItem19";
            this.lcItemTaraflar.Location = new System.Drawing.Point(0, 0);
            this.lcItemTaraflar.Name = "lcItemTaraflar";
            this.lcItemTaraflar.Size = new System.Drawing.Size(417, 452);
            this.lcItemTaraflar.Text = "lcItemTaraflar";
            this.lcItemTaraflar.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemTaraflar.TextToControlDistance = 0;
            this.lcItemTaraflar.TextVisible = false;
            // 
            // layoutControlGroup8
            // 
            this.layoutControlGroup8.CustomizationFormText = "Klasör Hesabı";
            this.layoutControlGroup8.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemKlasorHesabi});
            this.layoutControlGroup8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup8.Name = "layoutControlGroup8";
            this.layoutControlGroup8.Size = new System.Drawing.Size(823, 540);
            this.layoutControlGroup8.Text = "Klasör Hesabı";
            // 
            // lcItemKlasorHesabi
            // 
            this.lcItemKlasorHesabi.Control = this.panelControl2;
            this.lcItemKlasorHesabi.CustomizationFormText = "lcItemKlasorHesabi";
            this.lcItemKlasorHesabi.Location = new System.Drawing.Point(0, 0);
            this.lcItemKlasorHesabi.Name = "lcItemKlasorHesabi";
            this.lcItemKlasorHesabi.Size = new System.Drawing.Size(823, 540);
            this.lcItemKlasorHesabi.Text = "lcItemKlasorHesabi";
            this.lcItemKlasorHesabi.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemKlasorHesabi.TextToControlDistance = 0;
            this.lcItemKlasorHesabi.TextVisible = false;
            // 
            // layoutControlGroup11
            // 
            this.layoutControlGroup11.CustomizationFormText = "Genel Notlar";
            this.layoutControlGroup11.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemGenelNotlar});
            this.layoutControlGroup11.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup11.Name = "layoutControlGroup11";
            this.layoutControlGroup11.Size = new System.Drawing.Size(823, 540);
            this.layoutControlGroup11.Text = "Genel Notlar";
            // 
            // lcItemGenelNotlar
            // 
            this.lcItemGenelNotlar.Control = this.gcGenelNotlar;
            this.lcItemGenelNotlar.CustomizationFormText = "lcItemGenelNotlar";
            this.lcItemGenelNotlar.Location = new System.Drawing.Point(0, 0);
            this.lcItemGenelNotlar.Name = "lcItemGenelNotlar";
            this.lcItemGenelNotlar.Size = new System.Drawing.Size(823, 540);
            this.lcItemGenelNotlar.Text = "lcItemGenelNotlar";
            this.lcItemGenelNotlar.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemGenelNotlar.TextToControlDistance = 0;
            this.lcItemGenelNotlar.TextVisible = false;
            // 
            // lcGorupOdemePlani
            // 
            this.lcGorupOdemePlani.CustomizationFormText = "Ödeme Planı";
            this.lcGorupOdemePlani.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemOdemePlani});
            this.lcGorupOdemePlani.Location = new System.Drawing.Point(0, 0);
            this.lcGorupOdemePlani.Name = "lcGorupOdemePlani";
            this.lcGorupOdemePlani.Size = new System.Drawing.Size(823, 540);
            this.lcGorupOdemePlani.Text = "Ödeme Planı";
            // 
            // lcItemOdemePlani
            // 
            this.lcItemOdemePlani.Control = this.panel1;
            this.lcItemOdemePlani.CustomizationFormText = "Ödeme Planı";
            this.lcItemOdemePlani.Location = new System.Drawing.Point(0, 0);
            this.lcItemOdemePlani.Name = "lcItemOdemePlani";
            this.lcItemOdemePlani.Size = new System.Drawing.Size(823, 540);
            this.lcItemOdemePlani.Text = "Ödeme Planı";
            this.lcItemOdemePlani.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemOdemePlani.TextToControlDistance = 0;
            this.lcItemOdemePlani.TextVisible = false;
            // 
            // lcGroupDokumanlar
            // 
            this.lcGroupDokumanlar.CustomizationFormText = "Dökümanlar";
            this.lcGroupDokumanlar.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemDokumanlar});
            this.lcGroupDokumanlar.Location = new System.Drawing.Point(0, 0);
            this.lcGroupDokumanlar.Name = "lcGroupDokumanlar";
            this.lcGroupDokumanlar.Size = new System.Drawing.Size(823, 540);
            this.lcGroupDokumanlar.Text = "Dokümanlar";
            // 
            // lcItemDokumanlar
            // 
            this.lcItemDokumanlar.Control = this.panel2;
            this.lcItemDokumanlar.CustomizationFormText = "Dökümanlar";
            this.lcItemDokumanlar.Location = new System.Drawing.Point(0, 0);
            this.lcItemDokumanlar.Name = "lcItemDokumanlar";
            this.lcItemDokumanlar.Size = new System.Drawing.Size(823, 540);
            this.lcItemDokumanlar.Text = "Dökümanlar";
            this.lcItemDokumanlar.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemDokumanlar.TextToControlDistance = 0;
            this.lcItemDokumanlar.TextVisible = false;
            // 
            // lcGroupTeklifKarar
            // 
            this.lcGroupTeklifKarar.CustomizationFormText = "Teklif-Karar";
            this.lcGroupTeklifKarar.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemTeklifKarar});
            this.lcGroupTeklifKarar.Location = new System.Drawing.Point(0, 0);
            this.lcGroupTeklifKarar.Name = "lcGroupTeklifKarar";
            this.lcGroupTeklifKarar.Size = new System.Drawing.Size(823, 540);
            this.lcGroupTeklifKarar.Text = "Teklif-Karar";
            // 
            // lcItemTeklifKarar
            // 
            this.lcItemTeklifKarar.Control = this.gcTeklifKarar;
            this.lcItemTeklifKarar.CustomizationFormText = "Teklif-Karar";
            this.lcItemTeklifKarar.Location = new System.Drawing.Point(0, 0);
            this.lcItemTeklifKarar.Name = "lcItemTeklifKarar";
            this.lcItemTeklifKarar.Size = new System.Drawing.Size(823, 540);
            this.lcItemTeklifKarar.Text = "Teklif-Karar";
            this.lcItemTeklifKarar.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemTeklifKarar.TextToControlDistance = 0;
            this.lcItemTeklifKarar.TextVisible = false;
            // 
            // lcGroupMasraflar
            // 
            this.lcGroupMasraflar.CustomizationFormText = "Masraflar";
            this.lcGroupMasraflar.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemMasraflar});
            this.lcGroupMasraflar.Location = new System.Drawing.Point(0, 0);
            this.lcGroupMasraflar.Name = "lcGroupMasraflar";
            this.lcGroupMasraflar.Size = new System.Drawing.Size(823, 540);
            this.lcGroupMasraflar.Text = "Masraflar";
            // 
            // lcItemMasraflar
            // 
            this.lcItemMasraflar.Control = this.gcMasraflar;
            this.lcItemMasraflar.CustomizationFormText = "Masraflar";
            this.lcItemMasraflar.Location = new System.Drawing.Point(0, 0);
            this.lcItemMasraflar.Name = "lcItemMasraflar";
            this.lcItemMasraflar.Size = new System.Drawing.Size(823, 540);
            this.lcItemMasraflar.Text = "Masraflar";
            this.lcItemMasraflar.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemMasraflar.TextToControlDistance = 0;
            this.lcItemMasraflar.TextVisible = false;
            // 
            // lcGroupOdemeler
            // 
            this.lcGroupOdemeler.CustomizationFormText = "Ödemeler";
            this.lcGroupOdemeler.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemOdemeler});
            this.lcGroupOdemeler.Location = new System.Drawing.Point(0, 0);
            this.lcGroupOdemeler.Name = "lcGroupOdemeler";
            this.lcGroupOdemeler.Size = new System.Drawing.Size(823, 540);
            this.lcGroupOdemeler.Text = "Tahsilatlar";
            // 
            // lcItemOdemeler
            // 
            this.lcItemOdemeler.Control = this.gcOdemeler;
            this.lcItemOdemeler.CustomizationFormText = "Ödemeler";
            this.lcItemOdemeler.Location = new System.Drawing.Point(0, 0);
            this.lcItemOdemeler.Name = "lcItemOdemeler";
            this.lcItemOdemeler.Size = new System.Drawing.Size(823, 540);
            this.lcItemOdemeler.Text = "Ödemeler";
            this.lcItemOdemeler.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemOdemeler.TextToControlDistance = 0;
            this.lcItemOdemeler.TextVisible = false;
            // 
            // lcGroupDagitilmamisMasraflar
            // 
            this.lcGroupDagitilmamisMasraflar.CustomizationFormText = "Dağıtılmamış Masraflar";
            this.lcGroupDagitilmamisMasraflar.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemDagitilmamisMasraflar,
            this.lcItemMasraflariDagit});
            this.lcGroupDagitilmamisMasraflar.Location = new System.Drawing.Point(0, 0);
            this.lcGroupDagitilmamisMasraflar.Name = "lcGroupDagitilmamisMasraflar";
            this.lcGroupDagitilmamisMasraflar.Size = new System.Drawing.Size(823, 540);
            this.lcGroupDagitilmamisMasraflar.Text = "Dağıtılmamış Masraflar";
            // 
            // lcItemDagitilmamisMasraflar
            // 
            this.lcItemDagitilmamisMasraflar.Control = this.gcDagitilmamisMasraflar;
            this.lcItemDagitilmamisMasraflar.CustomizationFormText = "Dağıtılmamış Masraflar";
            this.lcItemDagitilmamisMasraflar.Location = new System.Drawing.Point(0, 26);
            this.lcItemDagitilmamisMasraflar.Name = "lcItemDagitilmamisMasraflar";
            this.lcItemDagitilmamisMasraflar.Size = new System.Drawing.Size(823, 514);
            this.lcItemDagitilmamisMasraflar.Text = "Dağıtılmamış Masraflar";
            this.lcItemDagitilmamisMasraflar.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemDagitilmamisMasraflar.TextToControlDistance = 0;
            this.lcItemDagitilmamisMasraflar.TextVisible = false;
            // 
            // lcItemMasraflariDagit
            // 
            this.lcItemMasraflariDagit.Control = this.sbtnMasraflariDagit;
            this.lcItemMasraflariDagit.CustomizationFormText = "Masraf Dağıt";
            this.lcItemMasraflariDagit.Location = new System.Drawing.Point(0, 0);
            this.lcItemMasraflariDagit.Name = "lcItemMasraflariDagit";
            this.lcItemMasraflariDagit.Size = new System.Drawing.Size(823, 26);
            this.lcItemMasraflariDagit.Text = "Masraf Dağıt";
            this.lcItemMasraflariDagit.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemMasraflariDagit.TextToControlDistance = 0;
            this.lcItemMasraflariDagit.TextVisible = false;
            // 
            // lcGroupDagitilmamisTahsilatlar
            // 
            this.lcGroupDagitilmamisTahsilatlar.CustomizationFormText = "Dağıtılmamış Tahsilatlar";
            this.lcGroupDagitilmamisTahsilatlar.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemDagitilmamisTahsilatlar,
            this.lcItemTahsilatlariDagit});
            this.lcGroupDagitilmamisTahsilatlar.Location = new System.Drawing.Point(0, 0);
            this.lcGroupDagitilmamisTahsilatlar.Name = "lcGroupDagitilmamisTahsilatlar";
            this.lcGroupDagitilmamisTahsilatlar.Size = new System.Drawing.Size(823, 540);
            this.lcGroupDagitilmamisTahsilatlar.Text = "Dağıtılmamış Tahsilatlar";
            // 
            // lcItemDagitilmamisTahsilatlar
            // 
            this.lcItemDagitilmamisTahsilatlar.Control = this.gcDagitilmamisTahsilatlar;
            this.lcItemDagitilmamisTahsilatlar.CustomizationFormText = "Dağıtılmamış Tahsilatlar";
            this.lcItemDagitilmamisTahsilatlar.Location = new System.Drawing.Point(0, 26);
            this.lcItemDagitilmamisTahsilatlar.Name = "lcItemDagitilmamisTahsilatlar";
            this.lcItemDagitilmamisTahsilatlar.Size = new System.Drawing.Size(823, 514);
            this.lcItemDagitilmamisTahsilatlar.Text = "Dağıtılmamış Tahsilatlar";
            this.lcItemDagitilmamisTahsilatlar.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemDagitilmamisTahsilatlar.TextToControlDistance = 0;
            this.lcItemDagitilmamisTahsilatlar.TextVisible = false;
            // 
            // lcItemTahsilatlariDagit
            // 
            this.lcItemTahsilatlariDagit.Control = this.sbtnTahsilatlariDagit;
            this.lcItemTahsilatlariDagit.CustomizationFormText = "Tahsilatları Dağıt";
            this.lcItemTahsilatlariDagit.Location = new System.Drawing.Point(0, 0);
            this.lcItemTahsilatlariDagit.Name = "lcItemTahsilatlariDagit";
            this.lcItemTahsilatlariDagit.Size = new System.Drawing.Size(823, 26);
            this.lcItemTahsilatlariDagit.Text = "Tahsilatları Dağıt";
            this.lcItemTahsilatlariDagit.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemTahsilatlariDagit.TextToControlDistance = 0;
            this.lcItemTahsilatlariDagit.TextVisible = false;
            // 
            // aV001TDIEBILPROJESORUMLUCollectionBindingSource
            // 
            this.aV001TDIEBILPROJESORUMLUCollectionBindingSource.DataMember = "AV001_TDIE_BIL_PROJE_SORUMLUCollection";
            this.aV001TDIEBILPROJESORUMLUCollectionBindingSource.DataSource = this.bndProje;
            // 
            // bndTaahhutMaster
            // 
            this.bndTaahhutMaster.DataSource = typeof(AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>);
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerRight});
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // hideContainerRight
            // 
            this.hideContainerRight.BackColor = System.Drawing.SystemColors.Control;
            this.hideContainerRight.Controls.Add(this.dockPanel1);
            this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideContainerRight.Location = new System.Drawing.Point(1000, 0);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(19, 648);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("37beca77-7025-46dd-9766-bbf800da2702");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(336, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(336, 648);
            this.dockPanel1.Text = "Taraflar";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.layoutControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(328, 621);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnDuzenle);
            this.layoutControl1.Controls.Add(this.gcIletisimBilgileri);
            this.layoutControl1.Controls.Add(this.gcSorumlu);
            this.layoutControl1.Controls.Add(this.gcBorclu);
            this.layoutControl1.Controls.Add(this.gcAlacak);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup6;
            this.layoutControl1.Size = new System.Drawing.Size(328, 621);
            this.layoutControl1.TabIndex = 17;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Location = new System.Drawing.Point(24, 575);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(280, 22);
            this.btnDuzenle.StyleController = this.layoutControl1;
            this.btnDuzenle.TabIndex = 11;
            this.btnDuzenle.Text = "Şahsın İletişim Bilgilerini Düzenle";
            // 
            // gcIletisimBilgileri
            // 
            this.gcIletisimBilgileri.Location = new System.Drawing.Point(24, 349);
            this.gcIletisimBilgileri.MainView = this.lvIletisimBilgileri;
            this.gcIletisimBilgileri.Name = "gcIletisimBilgileri";
            this.gcIletisimBilgileri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueIlce,
            this.rlueIl,
            this.rlueAdres});
            this.gcIletisimBilgileri.Size = new System.Drawing.Size(280, 222);
            this.gcIletisimBilgileri.TabIndex = 10;
            this.gcIletisimBilgileri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.lvIletisimBilgileri});
            // 
            // lvIletisimBilgileri
            // 
            this.lvIletisimBilgileri.CardMinSize = new System.Drawing.Size(260, 200);
            this.lvIletisimBilgileri.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.lvcAdres,
            this.lvcIlce,
            this.lvcIl,
            this.lvcTel1,
            this.lvcTel2,
            this.lvcCepTel1,
            this.lvcEmail1,
            this.lvcVergiDairesi,
            this.lvcVergiNo,
            this.lvcTcKimlikNo,
            this.lvcBabaAdi,
            this.lvcDogumTarihi,
            this.lvcAnneKizlikSoyadi,
            this.lvcMusteriNo});
            this.lvIletisimBilgileri.GridControl = this.gcIletisimBilgileri;
            this.lvIletisimBilgileri.Name = "lvIletisimBilgileri";
            this.lvIletisimBilgileri.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.lvIletisimBilgileri.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.lvIletisimBilgileri.OptionsBehavior.Editable = false;
            this.lvIletisimBilgileri.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.lvIletisimBilgileri.OptionsLayout.Columns.AddNewColumns = false;
            this.lvIletisimBilgileri.OptionsSingleRecordMode.CardAlignment = DevExpress.XtraGrid.Views.Layout.CardsAlignment.Near;
            this.lvIletisimBilgileri.OptionsSingleRecordMode.StretchCardToViewHeight = true;
            this.lvIletisimBilgileri.OptionsSingleRecordMode.StretchCardToViewWidth = true;
            this.lvIletisimBilgileri.OptionsView.CardsAlignment = DevExpress.XtraGrid.Views.Layout.CardsAlignment.Near;
            this.lvIletisimBilgileri.OptionsView.ShowCardCaption = false;
            this.lvIletisimBilgileri.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.lvIletisimBilgileri.OptionsView.ShowHeaderPanel = false;
            this.lvIletisimBilgileri.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
            this.lvIletisimBilgileri.TemplateCard = this.layoutViewCard1;
            // 
            // lvcAdres
            // 
            this.lvcAdres.Caption = "Adres";
            this.lvcAdres.ColumnEdit = this.rlueAdres;
            this.lvcAdres.FieldName = "ADRES";
            this.lvcAdres.LayoutViewField = this.layoutViewField_layoutViewColumn1;
            this.lvcAdres.Name = "lvcAdres";
            // 
            // rlueAdres
            // 
            this.rlueAdres.LinesCount = 2;
            this.rlueAdres.Name = "rlueAdres";
            // 
            // layoutViewField_layoutViewColumn1
            // 
            this.layoutViewField_layoutViewColumn1.EditorPreferredWidth = 195;
            this.layoutViewField_layoutViewColumn1.Location = new System.Drawing.Point(0, 60);
            this.layoutViewField_layoutViewColumn1.MaxSize = new System.Drawing.Size(0, 40);
            this.layoutViewField_layoutViewColumn1.MinSize = new System.Drawing.Size(85, 37);
            this.layoutViewField_layoutViewColumn1.Name = "layoutViewField_layoutViewColumn1";
            this.layoutViewField_layoutViewColumn1.Size = new System.Drawing.Size(260, 37);
            this.layoutViewField_layoutViewColumn1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_layoutViewColumn1.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1.TextToControlDistance = 5;
            // 
            // lvcIlce
            // 
            this.lvcIlce.Caption = "İlçe";
            this.lvcIlce.FieldName = "ILCE";
            this.lvcIlce.LayoutViewField = this.layoutViewField_layoutViewColumn1_3;
            this.lvcIlce.Name = "lvcIlce";
            // 
            // layoutViewField_layoutViewColumn1_3
            // 
            this.layoutViewField_layoutViewColumn1_3.EditorPreferredWidth = 96;
            this.layoutViewField_layoutViewColumn1_3.Location = new System.Drawing.Point(160, 97);
            this.layoutViewField_layoutViewColumn1_3.Name = "layoutViewField_layoutViewColumn1_3";
            this.layoutViewField_layoutViewColumn1_3.Size = new System.Drawing.Size(100, 20);
            this.layoutViewField_layoutViewColumn1_3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_layoutViewColumn1_3.TextToControlDistance = 0;
            this.layoutViewField_layoutViewColumn1_3.TextVisible = false;
            // 
            // lvcIl
            // 
            this.lvcIl.Caption = "İl - İlçe";
            this.lvcIl.FieldName = "IL";
            this.lvcIl.LayoutViewField = this.layoutViewField_layoutViewColumn1_4;
            this.lvcIl.Name = "lvcIl";
            // 
            // layoutViewField_layoutViewColumn1_4
            // 
            this.layoutViewField_layoutViewColumn1_4.EditorPreferredWidth = 95;
            this.layoutViewField_layoutViewColumn1_4.Location = new System.Drawing.Point(0, 97);
            this.layoutViewField_layoutViewColumn1_4.Name = "layoutViewField_layoutViewColumn1_4";
            this.layoutViewField_layoutViewColumn1_4.Size = new System.Drawing.Size(160, 20);
            this.layoutViewField_layoutViewColumn1_4.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1_4.TextToControlDistance = 5;
            // 
            // lvcTel1
            // 
            this.lvcTel1.Caption = "Tel";
            this.lvcTel1.FieldName = "TEL_1";
            this.lvcTel1.LayoutViewField = this.layoutViewField_layoutViewColumn1_6;
            this.lvcTel1.Name = "lvcTel1";
            // 
            // layoutViewField_layoutViewColumn1_6
            // 
            this.layoutViewField_layoutViewColumn1_6.EditorPreferredWidth = 95;
            this.layoutViewField_layoutViewColumn1_6.Location = new System.Drawing.Point(0, 117);
            this.layoutViewField_layoutViewColumn1_6.Name = "layoutViewField_layoutViewColumn1_6";
            this.layoutViewField_layoutViewColumn1_6.Size = new System.Drawing.Size(160, 20);
            this.layoutViewField_layoutViewColumn1_6.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1_6.TextToControlDistance = 5;
            // 
            // lvcTel2
            // 
            this.lvcTel2.Caption = "Tel 2";
            this.lvcTel2.FieldName = "TEL_2";
            this.lvcTel2.LayoutViewField = this.layoutViewField_layoutViewColumn1_7;
            this.lvcTel2.Name = "lvcTel2";
            // 
            // layoutViewField_layoutViewColumn1_7
            // 
            this.layoutViewField_layoutViewColumn1_7.EditorPreferredWidth = 96;
            this.layoutViewField_layoutViewColumn1_7.Location = new System.Drawing.Point(160, 117);
            this.layoutViewField_layoutViewColumn1_7.Name = "layoutViewField_layoutViewColumn1_7";
            this.layoutViewField_layoutViewColumn1_7.Size = new System.Drawing.Size(100, 20);
            this.layoutViewField_layoutViewColumn1_7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_layoutViewColumn1_7.TextToControlDistance = 0;
            this.layoutViewField_layoutViewColumn1_7.TextVisible = false;
            // 
            // lvcCepTel1
            // 
            this.lvcCepTel1.Caption = "Cep";
            this.lvcCepTel1.FieldName = "CEP_TEL";
            this.lvcCepTel1.LayoutViewField = this.layoutViewField_layoutViewColumn1_10;
            this.lvcCepTel1.Name = "lvcCepTel1";
            // 
            // layoutViewField_layoutViewColumn1_10
            // 
            this.layoutViewField_layoutViewColumn1_10.EditorPreferredWidth = 195;
            this.layoutViewField_layoutViewColumn1_10.Location = new System.Drawing.Point(0, 137);
            this.layoutViewField_layoutViewColumn1_10.Name = "layoutViewField_layoutViewColumn1_10";
            this.layoutViewField_layoutViewColumn1_10.Size = new System.Drawing.Size(260, 20);
            this.layoutViewField_layoutViewColumn1_10.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1_10.TextToControlDistance = 5;
            // 
            // lvcEmail1
            // 
            this.lvcEmail1.Caption = "Email";
            this.lvcEmail1.FieldName = "EMAIL_1";
            this.lvcEmail1.LayoutViewField = this.layoutViewField_layoutViewColumn1_12;
            this.lvcEmail1.Name = "lvcEmail1";
            // 
            // layoutViewField_layoutViewColumn1_12
            // 
            this.layoutViewField_layoutViewColumn1_12.EditorPreferredWidth = 195;
            this.layoutViewField_layoutViewColumn1_12.Location = new System.Drawing.Point(0, 157);
            this.layoutViewField_layoutViewColumn1_12.Name = "layoutViewField_layoutViewColumn1_12";
            this.layoutViewField_layoutViewColumn1_12.Size = new System.Drawing.Size(260, 20);
            this.layoutViewField_layoutViewColumn1_12.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1_12.TextToControlDistance = 5;
            // 
            // lvcVergiDairesi
            // 
            this.lvcVergiDairesi.Caption = "V. No";
            this.lvcVergiDairesi.FieldName = "VERGI_DAIRESI";
            this.lvcVergiDairesi.LayoutViewField = this.layoutViewField_layoutViewColumn1_14;
            this.lvcVergiDairesi.Name = "lvcVergiDairesi";
            // 
            // layoutViewField_layoutViewColumn1_14
            // 
            this.layoutViewField_layoutViewColumn1_14.EditorPreferredWidth = 95;
            this.layoutViewField_layoutViewColumn1_14.Location = new System.Drawing.Point(0, 177);
            this.layoutViewField_layoutViewColumn1_14.Name = "layoutViewField_layoutViewColumn1_14";
            this.layoutViewField_layoutViewColumn1_14.Size = new System.Drawing.Size(160, 20);
            this.layoutViewField_layoutViewColumn1_14.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1_14.TextToControlDistance = 5;
            // 
            // lvcVergiNo
            // 
            this.lvcVergiNo.Caption = "V. No";
            this.lvcVergiNo.FieldName = "VERGI_NO";
            this.lvcVergiNo.LayoutViewField = this.layoutViewField_layoutViewColumn1_15;
            this.lvcVergiNo.Name = "lvcVergiNo";
            // 
            // layoutViewField_layoutViewColumn1_15
            // 
            this.layoutViewField_layoutViewColumn1_15.EditorPreferredWidth = 96;
            this.layoutViewField_layoutViewColumn1_15.Location = new System.Drawing.Point(160, 177);
            this.layoutViewField_layoutViewColumn1_15.Name = "layoutViewField_layoutViewColumn1_15";
            this.layoutViewField_layoutViewColumn1_15.Size = new System.Drawing.Size(100, 20);
            this.layoutViewField_layoutViewColumn1_15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_layoutViewColumn1_15.TextToControlDistance = 0;
            this.layoutViewField_layoutViewColumn1_15.TextVisible = false;
            // 
            // lvcTcKimlikNo
            // 
            this.lvcTcKimlikNo.Caption = "Tc. No";
            this.lvcTcKimlikNo.FieldName = "TC_KIMLIK_NO";
            this.lvcTcKimlikNo.LayoutViewField = this.layoutViewField_layoutViewColumn1_1;
            this.lvcTcKimlikNo.Name = "lvcTcKimlikNo";
            // 
            // layoutViewField_layoutViewColumn1_1
            // 
            this.layoutViewField_layoutViewColumn1_1.EditorPreferredWidth = 69;
            this.layoutViewField_layoutViewColumn1_1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn1_1.Name = "layoutViewField_layoutViewColumn1_1";
            this.layoutViewField_layoutViewColumn1_1.Size = new System.Drawing.Size(134, 20);
            this.layoutViewField_layoutViewColumn1_1.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1_1.TextToControlDistance = 5;
            // 
            // lvcBabaAdi
            // 
            this.lvcBabaAdi.Caption = "B. Adi";
            this.lvcBabaAdi.FieldName = "BABA_ADI";
            this.lvcBabaAdi.LayoutViewField = this.layoutViewField_layoutViewColumn1_2;
            this.lvcBabaAdi.Name = "lvcBabaAdi";
            // 
            // layoutViewField_layoutViewColumn1_2
            // 
            this.layoutViewField_layoutViewColumn1_2.EditorPreferredWidth = 97;
            this.layoutViewField_layoutViewColumn1_2.Location = new System.Drawing.Point(0, 20);
            this.layoutViewField_layoutViewColumn1_2.Name = "layoutViewField_layoutViewColumn1_2";
            this.layoutViewField_layoutViewColumn1_2.Size = new System.Drawing.Size(162, 20);
            this.layoutViewField_layoutViewColumn1_2.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1_2.TextToControlDistance = 5;
            // 
            // lvcDogumTarihi
            // 
            this.lvcDogumTarihi.Caption = "D. T.";
            this.lvcDogumTarihi.FieldName = "DOGUM_TARIHI";
            this.lvcDogumTarihi.LayoutViewField = this.layoutViewField_layoutViewColumn1_5;
            this.lvcDogumTarihi.Name = "lvcDogumTarihi";
            // 
            // layoutViewField_layoutViewColumn1_5
            // 
            this.layoutViewField_layoutViewColumn1_5.EditorPreferredWidth = 61;
            this.layoutViewField_layoutViewColumn1_5.Location = new System.Drawing.Point(162, 20);
            this.layoutViewField_layoutViewColumn1_5.Name = "layoutViewField_layoutViewColumn1_5";
            this.layoutViewField_layoutViewColumn1_5.Size = new System.Drawing.Size(98, 20);
            this.layoutViewField_layoutViewColumn1_5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutViewField_layoutViewColumn1_5.TextSize = new System.Drawing.Size(28, 13);
            this.layoutViewField_layoutViewColumn1_5.TextToControlDistance = 5;
            // 
            // lvcAnneKizlikSoyadi
            // 
            this.lvcAnneKizlikSoyadi.Caption = "Kiz. Soyadı";
            this.lvcAnneKizlikSoyadi.FieldName = "ANNE_KIZLIK_SOYADI";
            this.lvcAnneKizlikSoyadi.LayoutViewField = this.layoutViewField_layoutViewColumn1_8;
            this.lvcAnneKizlikSoyadi.Name = "lvcAnneKizlikSoyadi";
            // 
            // layoutViewField_layoutViewColumn1_8
            // 
            this.layoutViewField_layoutViewColumn1_8.EditorPreferredWidth = 195;
            this.layoutViewField_layoutViewColumn1_8.Location = new System.Drawing.Point(0, 40);
            this.layoutViewField_layoutViewColumn1_8.Name = "layoutViewField_layoutViewColumn1_8";
            this.layoutViewField_layoutViewColumn1_8.Size = new System.Drawing.Size(260, 20);
            this.layoutViewField_layoutViewColumn1_8.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1_8.TextToControlDistance = 5;
            // 
            // lvcMusteriNo
            // 
            this.lvcMusteriNo.Caption = "Mus No";
            this.lvcMusteriNo.FieldName = "MUSTERI_NO";
            this.lvcMusteriNo.LayoutViewField = this.layoutViewField_layoutViewColumn1_9;
            this.lvcMusteriNo.Name = "lvcMusteriNo";
            // 
            // layoutViewField_layoutViewColumn1_9
            // 
            this.layoutViewField_layoutViewColumn1_9.EditorPreferredWidth = 61;
            this.layoutViewField_layoutViewColumn1_9.Location = new System.Drawing.Point(134, 0);
            this.layoutViewField_layoutViewColumn1_9.Name = "layoutViewField_layoutViewColumn1_9";
            this.layoutViewField_layoutViewColumn1_9.Size = new System.Drawing.Size(126, 20);
            this.layoutViewField_layoutViewColumn1_9.TextSize = new System.Drawing.Size(56, 13);
            this.layoutViewField_layoutViewColumn1_9.TextToControlDistance = 5;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.AppearanceGroup.BackColor = System.Drawing.Color.Khaki;
            this.layoutViewCard1.AppearanceGroup.Options.UseBackColor = true;
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.GroupBordersVisible = false;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_layoutViewColumn1,
            this.layoutViewField_layoutViewColumn1_4,
            this.layoutViewField_layoutViewColumn1_6,
            this.layoutViewField_layoutViewColumn1_10,
            this.layoutViewField_layoutViewColumn1_14,
            this.layoutViewField_layoutViewColumn1_7,
            this.layoutViewField_layoutViewColumn1_3,
            this.layoutViewField_layoutViewColumn1_2,
            this.layoutViewField_layoutViewColumn1_5,
            this.layoutViewField_layoutViewColumn1_8,
            this.layoutViewField_layoutViewColumn1_15,
            this.layoutViewField_layoutViewColumn1_12,
            this.layoutViewField_layoutViewColumn1_1,
            this.layoutViewField_layoutViewColumn1_9});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 5;
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // rlueIlce
            // 
            this.rlueIlce.AutoHeight = false;
            this.rlueIlce.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueIlce.Name = "rlueIlce";
            // 
            // rlueIl
            // 
            this.rlueIl.AutoHeight = false;
            this.rlueIl.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueIl.Name = "rlueIl";
            // 
            // gcSorumlu
            // 
            this.gcSorumlu.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcSorumlu.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcSorumlu.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gcSorumlu.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gcSorumlu.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gcSorumlu.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gcSorumlu.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcSorumlu.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(7, 7, true, true, "Sil", "KaydiSil")});
            this.gcSorumlu.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gcSorumlu_EmbeddedNavigator_ButtonClick);
            this.gcSorumlu.Location = new System.Drawing.Point(12, 114);
            this.gcSorumlu.MainView = this.gwSorumluAvk;
            this.gcSorumlu.Name = "gcSorumlu";
            this.gcSorumlu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueSorumlu});
            this.gcSorumlu.Size = new System.Drawing.Size(304, 98);
            this.gcSorumlu.TabIndex = 9;
            this.gcSorumlu.UseEmbeddedNavigator = true;
            this.gcSorumlu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwSorumluAvk});
            // 
            // gwSorumluAvk
            // 
            this.gwSorumluAvk.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn29,
            this.gridColumn30});
            this.gwSorumluAvk.GridControl = this.gcSorumlu;
            this.gwSorumluAvk.Name = "gwSorumluAvk";
            this.gwSorumluAvk.OptionsView.ShowDetailButtons = false;
            this.gwSorumluAvk.OptionsView.ShowGroupPanel = false;
            this.gwSorumluAvk.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gwSorumluAvk_RowClick);
            this.gwSorumluAvk.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gwSorumluAvk_FocusedRowChanged);
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "Sorumlu Avukat";
            this.gridColumn29.ColumnEdit = this.rLueSorumlu;
            this.gridColumn29.FieldName = "CARI_ID";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 0;
            this.gridColumn29.Width = 242;
            // 
            // rLueSorumlu
            // 
            this.rLueSorumlu.AutoHeight = false;
            this.rLueSorumlu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSorumlu.Name = "rLueSorumlu";
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "İzleyen";
            this.gridColumn30.FieldName = "YETKILI_MI";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 1;
            // 
            // layoutControlGroup6
            // 
            this.layoutControlGroup6.CustomizationFormText = "Root";
            this.layoutControlGroup6.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgIletisimBilgileri,
            this.layoutControlItem10,
            this.lciSorumlu,
            this.lciBorclu});
            this.layoutControlGroup6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup6.Name = "Root";
            this.layoutControlGroup6.Size = new System.Drawing.Size(328, 621);
            this.layoutControlGroup6.Text = "Root";
            this.layoutControlGroup6.TextVisible = false;
            // 
            // lcgIletisimBilgileri
            // 
            this.lcgIletisimBilgileri.CustomizationFormText = "İletişim Bilgileri";
            this.lcgIletisimBilgileri.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciIletisimBilgileri,
            this.layoutControlItem9});
            this.lcgIletisimBilgileri.Location = new System.Drawing.Point(0, 306);
            this.lcgIletisimBilgileri.Name = "lcgIletisimBilgileri";
            this.lcgIletisimBilgileri.Size = new System.Drawing.Size(308, 295);
            this.lcgIletisimBilgileri.Text = "İletişim Bilgileri";
            // 
            // lciIletisimBilgileri
            // 
            this.lciIletisimBilgileri.Control = this.gcIletisimBilgileri;
            this.lciIletisimBilgileri.CustomizationFormText = "lciIletisimBilgileri";
            this.lciIletisimBilgileri.Location = new System.Drawing.Point(0, 0);
            this.lciIletisimBilgileri.Name = "lciIletisimBilgileri";
            this.lciIletisimBilgileri.Size = new System.Drawing.Size(284, 226);
            this.lciIletisimBilgileri.Text = "lciIletisimBilgileri";
            this.lciIletisimBilgileri.TextSize = new System.Drawing.Size(0, 0);
            this.lciIletisimBilgileri.TextToControlDistance = 0;
            this.lciIletisimBilgileri.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnDuzenle;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 226);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(82, 26);
            this.layoutControlItem9.Name = "layoutControlItem2";
            this.layoutControlItem9.Size = new System.Drawing.Size(284, 26);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "layoutControlItem2";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.gcAlacak;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem10.Name = "layoutControlItem1";
            this.layoutControlItem10.Size = new System.Drawing.Size(308, 102);
            this.layoutControlItem10.Text = "layoutControlItem1";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextToControlDistance = 0;
            this.layoutControlItem10.TextVisible = false;
            // 
            // lciSorumlu
            // 
            this.lciSorumlu.Control = this.gcSorumlu;
            this.lciSorumlu.CustomizationFormText = "layoutControlItem85";
            this.lciSorumlu.Location = new System.Drawing.Point(0, 102);
            this.lciSorumlu.Name = "lciSorumlu";
            this.lciSorumlu.Size = new System.Drawing.Size(308, 102);
            this.lciSorumlu.Text = "lciSorumlu";
            this.lciSorumlu.TextSize = new System.Drawing.Size(0, 0);
            this.lciSorumlu.TextToControlDistance = 0;
            this.lciSorumlu.TextVisible = false;
            // 
            // lciBorclu
            // 
            this.lciBorclu.Control = this.gcBorclu;
            this.lciBorclu.CustomizationFormText = "layoutControlItem4";
            this.lciBorclu.Location = new System.Drawing.Point(0, 204);
            this.lciBorclu.Name = "lciBorclu";
            this.lciBorclu.Size = new System.Drawing.Size(308, 102);
            this.lciBorclu.Text = "lciBorclu";
            this.lciBorclu.TextSize = new System.Drawing.Size(0, 0);
            this.lciBorclu.TextToControlDistance = 0;
            this.lciBorclu.TextVisible = false;
            // 
            // frmKlasorYeni
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 648);
            this.Controls.Add(this.hideContainerRight);
            this.Name = "frmKlasorYeni";
            this.Text = "Klasör";
            this.Load += new System.EventHandler(this.frmKlasorYeni_Load);
            this.Controls.SetChildIndex(this.hideContainerRight, 0);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvBorcluTarafVekil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnBorcluTemsilEkle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBorcluVekil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTemsilSekli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBorclu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwBorclu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafCariB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueBorcluTemsil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAlacakliTarafVekil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnTemsilEkle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakliAvukat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakliTemsilSekli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAlacak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwAlacak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAlacakliTemsil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndProje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKlasor)).EndInit();
            this.pnlKlasor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcProjeEkrani)).EndInit();
            this.lcProjeEkrani.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateBeklenenBitisTarihi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBeklenenBitisTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinKazanmaOrani.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRef3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRef2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRef1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOzelKod4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOzelKod2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOzelKod3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOzelKod1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueKrediGrubu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDagitilmamisTahsilatlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDagitilmamisTahsilatlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspTutarDagitilmisTahsilat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDovizDagitilmisTahsilat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDagitilmamisMasraflar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDagitilmamisMasraflar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCariDagitilmamis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspTutarDagitilmamis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMasraflar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMasraflar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspTutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOdemeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOdemeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCariOdeme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspTutarOdeme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDovizTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueOdemeYeri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueOdemeTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTeklifKarar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndTeklifKarar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTeklifKarar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueProjeTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupTaahhutDetay)).EndInit();
            this.groupTaahhutDetay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcChild)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChild)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTaahhutDurum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDoviz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgCChild)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGenelNotlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenelNotlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueNotAlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHesapKatTarihi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHesapKatTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTaraflar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueProjeTarafCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.pnlHesaplamaTipi.ResumeLayout(false);
            this.pnlHesaplamaTipi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueHesapTipi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeKrediHesapBilgileri)).EndInit();
            this.cmsKrediBilgileri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueBolum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDurum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKapamaTarihi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKapamaTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIntikalTarihi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIntikalTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSube.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemHesapKatTarihi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemAra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemBul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupBilgiler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemYapilacakIsler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemKrediHesapBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemKodu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemIntikalTarihi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemAdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemDurum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemKapamaTarihi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemBolum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemProjeAciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemSube)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemKrediGrubu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemTaraflar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemKlasorHesabi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemGenelNotlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGorupOdemePlani)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemOdemePlani)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupDokumanlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemDokumanlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupTeklifKarar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemTeklifKarar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupMasraflar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemMasraflar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupOdemeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemOdemeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupDagitilmamisMasraflar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemDagitilmamisMasraflar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemMasraflariDagit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupDagitilmamisTahsilatlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemDagitilmamisTahsilatlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemTahsilatlariDagit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aV001TDIEBILPROJESORUMLUCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndTaahhutMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcIletisimBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvIletisimBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAdres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueIlce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueIl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSorumlu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwSorumluAvk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSorumlu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgIletisimBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIletisimBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSorumlu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBorclu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bndProje;
        private DevExpress.XtraEditors.PanelControl pnlKlasor;
        private DevExpress.XtraLayout.LayoutControl lcProjeEkrani;
        public AdimAdimDavaKaydi.Is.UserControls.ucGorevGrid ucGorevler1;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gcGenelNotlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGenelNotlar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnNotAlan;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueNotAlan;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTarih;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnNotlar;
        private DevExpress.XtraEditors.SimpleButton sbtnBul;
        private AdimAdimDavaKaydi.Util.ExtendedLookUpEdit lueAra;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gcTaraflar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraTreeList.TreeList treeKrediHesapBilgileri;
        private DevExpress.XtraEditors.DateEdit dtHesapKatTarihi;
        private DevExpress.XtraEditors.LookUpEdit lueBolum;
        private DevExpress.XtraEditors.MemoEdit memAciklama;
        private DevExpress.XtraEditors.LookUpEdit lueDurum;
        private DevExpress.XtraEditors.DateEdit dtKapamaTarihi;
        private DevExpress.XtraEditors.DateEdit dtIntikalTarihi;
        private DevExpress.XtraEditors.TextEdit txtAd;
        private DevExpress.XtraEditors.TextEdit txtKod;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem lcItemHesapKatTarihi;
        private DevExpress.XtraLayout.LayoutControlItem lcItemAra;
        private DevExpress.XtraLayout.LayoutControlItem lcItemBul;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private System.Windows.Forms.ContextMenuStrip cmsKrediBilgileri;
        private System.Windows.Forms.ToolStripMenuItem yeniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlacak;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlacakNakit;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlacakGayriNakit;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlacakGayriNakitMektup;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlacakGayriNakitCekTaahhut;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlacakGayriNakitAkreditif;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlacakGayriNakitAval;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlacakGayriNakitDiger;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlacakKiymetliEvrakaBaglanmisAlacak;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlacakKiymetliEvrakaBaglanmisAlacakCek;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlacakKiymetliEvrakaBaglanmisAlacakBono;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlacakKiymetliEvrakaBaglanmisAlacakPolice;
        private System.Windows.Forms.ToolStripMenuItem tsmiTeminat;
        private System.Windows.Forms.ToolStripMenuItem tsmiTeminatIpotek;
        private System.Windows.Forms.ToolStripMenuItem tsmiTeminatTicariIsletmeRehni;
        private System.Windows.Forms.ToolStripMenuItem tsmiTeminatMenkulRehni;
        private System.Windows.Forms.ToolStripMenuItem tsmiTeminatMenkulRehniAracRehni;
        private System.Windows.Forms.ToolStripMenuItem tsmiTeminatMenkulRehniHatRehni;
        private System.Windows.Forms.ToolStripMenuItem tsmiTeminatMenkulRehniMarkaRehni;
        private System.Windows.Forms.ToolStripMenuItem tsmiTeminatMenkulRehniTicariPlakaRehni;
        private System.Windows.Forms.ToolStripMenuItem tsmiTeminatMenkulRehniHisseSenediRehni;
        private System.Windows.Forms.ToolStripMenuItem tsmiTeminatMenkulRehniKambiyoSenedi;
        private System.Windows.Forms.ToolStripMenuItem tsmiTeminatMenkulRehniKambiyoSenediBono;
        private System.Windows.Forms.ToolStripMenuItem tsmiTeminatMenkulRehniKambiyoSenediPolice;
        private System.Windows.Forms.ToolStripMenuItem tsmiTeminatMenkulRehniKambiyoSenediCek;
        private System.Windows.Forms.ToolStripMenuItem tsmiTeminatMenkulRehniDigerMenkulRehni;
        private System.Windows.Forms.ToolStripMenuItem tsmiTeminatTeminatSenedi;
        private System.Windows.Forms.ToolStripMenuItem tsmiSozlesme;
        private System.Windows.Forms.ToolStripMenuItem tsmiSozlesmeGenelKrediSozlesmesi;
        private System.Windows.Forms.ToolStripMenuItem tsmiSozlesmeGenelKrediTaahhutname;
        private System.Windows.Forms.ToolStripMenuItem tsmiSozlesmeBankacilikHizmetSozlesmesi;
        private System.Windows.Forms.ToolStripMenuItem tsmiSozlesmeKonutKrediSozlesmesi;
        private System.Windows.Forms.ToolStripMenuItem tsmiSozlesmeIhtiyacKrediSozlesmesi;
        private System.Windows.Forms.ToolStripMenuItem tsmiSozlesmeTasitKrediSozlesmesi;
        private System.Windows.Forms.ToolStripMenuItem resenDüzenlenmişNoterSenediToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noterdenBorçİkrarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiTakipler;
        private System.Windows.Forms.ToolStripMenuItem tsmiTakiplerKlasoreGirilmisAlacaklardanTakipOlustur;
        private System.Windows.Forms.ToolStripMenuItem tsmiTakiplerYeniTakipAc;
        private System.Windows.Forms.ToolStripMenuItem tsmiDavaDosyasi;
        private System.Windows.Forms.ToolStripMenuItem tsmiSorusturma;
        private System.Windows.Forms.ToolStripSeparator tsmiCizik2;
        private System.Windows.Forms.ToolStripMenuItem tsmiIhtiyatiHaciz;
        private System.Windows.Forms.ToolStripMenuItem tsmiIhtiyatiTedbir;
        private System.Windows.Forms.ToolStripSeparator tsmiCizik;
        private System.Windows.Forms.ToolStripMenuItem tsmiOdeme;
        private System.Windows.Forms.ToolStripMenuItem tsmiMasraf;
        private System.Windows.Forms.ToolStripMenuItem tsmiMalHakGirisi;
        private System.Windows.Forms.ToolStripMenuItem tsmIlamGirisi;
        private System.Windows.Forms.ToolStripMenuItem ihtarnameGirişiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlacakDuzenle;
        private System.Windows.Forms.ToolStripMenuItem tsmihtiyatiTedbirDuzenle;
        private System.Windows.Forms.ToolStripMenuItem tsmIlamBilgisiDuzenle;
        private System.Windows.Forms.ToolStripMenuItem tsmIhtiyatiHacizDuzenle;
        private System.Windows.Forms.ToolStripMenuItem tsmIhtiyatiHacizDilekcesi;
        private System.Windows.Forms.ToolStripMenuItem ihtarnameDüzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmkiymetliEvrakBilgileriDuzenle;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem yeniKlasörOluşturToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem klasörüSilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem özelliklerToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueProjeTarafCari;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ağacınTümünüAçToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ağacıTamamenKapatToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ImageList imgKlasor;
        private AdimAdimDavaKaydi.UserControls.ucIcraHesapCetveli ucIcraHesapCetveli1;
        private System.Windows.Forms.ToolStripMenuItem aporToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem klasörAğaçRaporuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordeGönderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exceleGönderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDFeGönderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporDüzenleyicisineGönderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.BindingSource aV001TDIEBILPROJESORUMLUCollectionBindingSource;
        private System.Windows.Forms.ToolStripMenuItem munzamSenetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem havaAracıİpoteğiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gemiİpoteğiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem davacıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem davalıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem şikayetEdenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem şikayetEdilenToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gcMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMaster;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUT_TIP;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUT_EDEN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUDU_KABUL_EDEN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUT_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUDU_KABUL_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colDAVASI_VAR_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colDAVA_FOY_ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn colRESMI_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colGECERLI_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUT_SIRA_NO;
        private DevExpress.XtraEditors.GroupControl groupTaahhutDetay;
        private DevExpress.XtraGrid.GridControl gcChild;
        private DevExpress.XtraGrid.Views.Grid.GridView gvChild;
        private DevExpress.XtraGrid.Columns.GridColumn colSIRA_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colDURUM_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUTU_YERINE_GETIRME_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUT_MIKTARI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUT_MIKTARI;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTAAHHUTTEN_KALAN_MIKTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_MIKTARI_DOVIZ_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colODEME_MIKTARI;
        private DevExpress.XtraGrid.Columns.GridColumn colKAYIT_TARIHI;
        private DevExpress.XtraVerticalGrid.VGridControl vgCChild;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.BindingSource bndTaahhutMaster;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueProjeTaraf;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueDoviz;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueTaahhutDurum;
        private System.Windows.Forms.Panel panel2;
        private AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge.ucbelgetakip ucbelgetakip1;
        private DevExpress.XtraGrid.GridControl gcTeklifKarar;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTeklifKarar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTEKLIF;
        private DevExpress.XtraGrid.Columns.GridColumn gridColKARAR;
        private System.Windows.Forms.BindingSource bndTeklifKarar;
        private System.Windows.Forms.Panel pnlHesaplamaTipi;
        private DevExpress.XtraEditors.LookUpEdit lueHesapTipi;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ToolStripMenuItem ödemeyiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masrafDüzenleToolStripMenuItem;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup9;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem lcItemKrediHesapBilgileri;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem lcItemKodu;
        private DevExpress.XtraLayout.LayoutControlItem lcItemIntikalTarihi;
        private DevExpress.XtraLayout.LayoutControlItem lcItemAdi;
        private DevExpress.XtraLayout.LayoutControlItem lcItemDurum;
        private DevExpress.XtraLayout.LayoutControlItem lcItemKapamaTarihi;
        private DevExpress.XtraLayout.LayoutControlItem lcItemBolum;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlItem lcItemProjeAciklama;
        private DevExpress.XtraLayout.LayoutControlItem lcItemSube;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem lcItemTaraflar;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup8;
        private DevExpress.XtraLayout.LayoutControlItem lcItemKlasorHesabi;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup10;
        private DevExpress.XtraLayout.LayoutControlItem lcItemYapilacakIsler;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup11;
        private DevExpress.XtraLayout.LayoutControlItem lcItemGenelNotlar;
        private DevExpress.XtraLayout.LayoutControlGroup lcGorupOdemePlani;
        private DevExpress.XtraLayout.LayoutControlItem lcItemOdemePlani;
        private DevExpress.XtraLayout.LayoutControlGroup lcGroupDokumanlar;
        private DevExpress.XtraLayout.LayoutControlItem lcItemDokumanlar;
        private DevExpress.XtraLayout.LayoutControlGroup lcGroupTeklifKarar;
        private DevExpress.XtraLayout.LayoutControlItem lcItemTeklifKarar;
        private DevExpress.XtraLayout.LayoutControlGroup lcGroupMasraflar;
        private DevExpress.XtraLayout.LayoutControlGroup lcGroupOdemeler;
        private DevExpress.XtraGrid.GridControl gcMasraflar;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMasraflar;
        private DevExpress.XtraGrid.GridControl gcOdemeler;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOdemeler;
        private DevExpress.XtraLayout.LayoutControlItem lcItemMasraflar;
        private DevExpress.XtraLayout.LayoutControlItem lcItemOdemeler;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspTutar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDosyaBilgisi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCariOdeme;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspTutarOdeme;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDosyaBilgisiOdeme;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueDovizTip;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueOdemeYeri;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueOdemeTip;
        private DevExpress.XtraLayout.LayoutControlGroup lcGroupBilgiler;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tazminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depoToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn colTutar;
        private System.Windows.Forms.ToolStripMenuItem avukatlıkKm35AToolStripMenuItem;
        private DevExpress.XtraGrid.GridControl gcDagitilmamisMasraflar;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDagitilmamisMasraflar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCariDagitilmamis;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspTutarDagitilmamis;
        private DevExpress.XtraLayout.LayoutControlGroup lcGroupDagitilmamisMasraflar;
        private DevExpress.XtraLayout.LayoutControlItem lcItemDagitilmamisMasraflar;
        private DevExpress.XtraLayout.LayoutControlGroup lcGroupDagitilmamisTahsilatlar;
        private DevExpress.XtraGrid.GridControl gcDagitilmamisTahsilatlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDagitilmamisTahsilatlar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspTutarDagitilmisTahsilat;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueDovizDagitilmisTahsilat;
        private DevExpress.XtraLayout.LayoutControlItem lcItemDagitilmamisTahsilatlar;
        private DevExpress.XtraEditors.SimpleButton sbtnMasraflariDagit;
        private DevExpress.XtraLayout.LayoutControlItem lcItemMasraflariDagit;
        private DevExpress.XtraEditors.SimpleButton sbtnTahsilatlariDagit;
        private DevExpress.XtraLayout.LayoutControlItem lcItemTahsilatlariDagit;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LookUpEdit lueKrediGrubu;
        private DevExpress.XtraLayout.LayoutControlItem lcItemKrediGrubu;
        private DevExpress.XtraEditors.TextEdit txtRef3;
        private DevExpress.XtraEditors.TextEdit txtRef2;
        private DevExpress.XtraEditors.TextEdit txtRef1;
        private Util.ExtendedLookUpEdit lueOzelKod4;
        private Util.ExtendedLookUpEdit lueOzelKod2;
        private Util.ExtendedLookUpEdit lueOzelKod3;
        private Util.ExtendedLookUpEdit lueOzelKod1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.SearchLookUpEdit lueSube;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnDuzenle;
        private DevExpress.XtraGrid.GridControl gcIletisimBilgileri;
        private DevExpress.XtraGrid.Views.Layout.LayoutView lvIletisimBilgileri;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcAdres;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit rlueAdres;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcIlce;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_3;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcIl;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_4;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcTel1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_6;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcTel2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_7;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcCepTel1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_10;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcEmail1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_12;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcVergiDairesi;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_14;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcVergiNo;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_15;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcTcKimlikNo;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcBabaAdi;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_2;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcDogumTarihi;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_5;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcAnneKizlikSoyadi;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_8;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvcMusteriNo;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_9;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueIlce;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueIl;
        private DevExpress.XtraGrid.GridControl gcSorumlu;
        private DevExpress.XtraGrid.Views.Grid.GridView gwSorumluAvk;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private Util.ExtendedGridControl gcBorclu;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBorcluTarafVekil;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rbtnBorcluTemsilEkle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBorcluVekil;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTemsilSekli;
        private DevExpress.XtraGrid.Views.Grid.GridView gwBorclu;
        private DevExpress.XtraGrid.Columns.GridColumn colBorcluAdi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueBorcluTemsil;
        private Util.ExtendedGridControl gcAlacak;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAlacakliTarafVekil;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMSIL_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rbtnTemsilEkle;
        private DevExpress.XtraGrid.Columns.GridColumn colAVUKAT_CARI_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAlacakliAvukat;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMSIL_SEKLI_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAlacakliTemsilSekli;
        private DevExpress.XtraGrid.Views.Grid.GridView gwAlacak;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueAlacakliTemsil;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup6;
        private DevExpress.XtraLayout.LayoutControlGroup lcgIletisimBilgileri;
        private DevExpress.XtraLayout.LayoutControlItem lciIletisimBilgileri;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem lciSorumlu;
        private DevExpress.XtraLayout.LayoutControlItem lciBorclu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTarafCariB;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTarafCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSorumlu;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
        private DevExpress.XtraEditors.DateEdit dateBeklenenBitisTarihi;
        private DevExpress.XtraEditors.SpinEdit spinKazanmaOrani;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
    }
}
