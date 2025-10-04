using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmMuallakRaporu : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmMuallakRaporu()
        {
            InitializeComponent();
            gcMuallakRaporu.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            gcMuallakRaporAleyh.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            this.Load += new EventHandler(frmMuallakRaporu_Load);
        }

        public AdimAdimDavaKaydi.Util.compGridDovizSummary myCompGridDovizSummary;
        public AdimAdimDavaKaydi.Util.compGridDovizSummary myCompGridDovizSummary2;

        /// <summary>
        /// BV 19.07.2011 Teminat kontrolü
        /// </summary>
        private TList<AV001_TDI_BIL_TEMINAT_MEKTUP> _MyTeminatDataSource;

        private AvukatProLib.Arama.AvpDataContext db = new AvukatProLib.Arama.AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

        [Browsable(false)]
        public TList<AV001_TDI_BIL_TEMINAT_MEKTUP> MyTeminatDataSource
        {
            get { return _MyTeminatDataSource; }
            set
            {
                _MyTeminatDataSource = value;
            }
        }

        public void SagTusaEkle()
        {
            gcMuallakRaporu.RightClickPopup.LinkPersist = new DevExpress.XtraBars.LinksInfo();
            gcMuallakRaporAleyh.RightClickPopup.LinkPersist = new DevExpress.XtraBars.LinksInfo();
            foreach (DevExpress.XtraBars.LinkPersistInfo var in popupMenu1.LinksPersistInfo)
            {
                gcMuallakRaporu.RightClickPopup.LinkPersist.Add(var);
                gcMuallakRaporAleyh.RightClickPopup.LinkPersist.Add(var);
            }
        }

        private void frmMuallakRaporu_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.ParaBicimiAyarla(spTutar);
            BelgeUtil.Inits.DovizTipGetir(lueDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueDovizAleyh);

            SagTusaEkle();

            HesapIslemleri(gcMuallakRaporu, true);

            /* Kaldırıldı - Merve ilgili view düzenledikten sonra tekar gündeme gelecek
            myCompGridDovizSummary = new AdimAdimDavaKaydi.Util.compGridDovizSummary();
            myCompGridDovizSummary.AltToplamlarAktifMi = true;

            myCompGridDovizSummary.MyGridView = gvMuallakRapor;
            myCompGridDovizSummary2 = new AdimAdimDavaKaydi.Util.compGridDovizSummary();
            myCompGridDovizSummary2.AltToplamlarAktifMi = true;

            myCompGridDovizSummary2.MyGridView = gridView1;
            */
        }

        private void gcMuallakRaporAleyh_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            if (e.Button.Tag.ToString() == "FaizHesapla")
            {
                List<int> idList = new List<int>();
                foreach (AvukatProLib.Arama.R_MuallakRaporDavaNedeniBazinda item in (gcMuallakRaporAleyh.DataSource as List<AvukatProLib.Arama.R_MuallakRaporDavaNedeniBazinda>))
                {
                    if (item.IsSelected)
                        idList.Add(item.ID);
                }
                Hesap.Dava hesap = new Hesap.Dava(idList);
                HesapIslemleri(gcMuallakRaporAleyh, false);
                XtraMessageBox.Show("Faiz hesabı işlemi başarı ile gerçekleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gcMuallakRaporAleyh_ButtonTumunuKaldir(object sender, NavigatorButtonClickEventArgs e)
        {
            TumunuSecKaldir(gridView1, gcMuallakRaporAleyh, false);
        }

        private void gcMuallakRaporAleyh_ButtonTumunuSec(object sender, NavigatorButtonClickEventArgs e)
        {
            TumunuSecKaldir(gridView1, gcMuallakRaporAleyh, true);
        }

        private void gcMuallakRaporu_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            if (e.Button.Tag.ToString() == "FaizHesapla")
            {
                List<int> idList = new List<int>();
                foreach (AvukatProLib.Arama.R_MuallakRaporDavaNedeniBazinda item in (gcMuallakRaporu.DataSource as List<AvukatProLib.Arama.R_MuallakRaporDavaNedeniBazinda>))
                {
                    if (item.IsSelected)
                        idList.Add(item.ID);
                }
                Hesap.Dava hesap = new Hesap.Dava(idList);
                HesapIslemleri(gcMuallakRaporu, true);
                XtraMessageBox.Show("Faiz hesabı işlemi başarı ile gerçekleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gcMuallakRaporu_ButtonTumunuKaldir(object sender, NavigatorButtonClickEventArgs e)
        {
            TumunuSecKaldir(gvMuallakRapor, gcMuallakRaporu, false);
        }

        private void gcMuallakRaporu_ButtonTumunuSec(object sender, NavigatorButtonClickEventArgs e)
        {
            TumunuSecKaldir(gvMuallakRapor, gcMuallakRaporu, true);
        }

        private void HesapIslemleri(DevExpress.XtraGrid.GridControl gridControl, bool davaEdenmi)
        {
            gridControl.DataSource = db.R_MuallakRaporDavaNedeniBazindas.Where(vi => vi.FOY_DURUM_ID.Value != 7 && vi.DAVA_TIP_ID.Value == (int)AdimAdimDavaKaydi.DavaTakip.GelismeHelper.DavaTip.Hukuk && vi.DAVA_EDEN_MI == davaEdenmi).ToList();
            TList<AV001_TD_BIL_BORCLU_ODEME> borcluOdemeler = new TList<AV001_TD_BIL_BORCLU_ODEME>();

            //List<per_DAVA_NEDEN_POLICE> policeListesi = new List<per_DAVA_NEDEN_POLICE>();

            foreach (var item in gridControl.DataSource as List<AvukatProLib.Arama.R_MuallakRaporDavaNedeniBazinda>)
            {
                //var masraflar = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByDAVA_FOY_ID(item.ID);
                //masraflar.ForEach(masraf =>
                //{
                //    var masrafDetaylar = DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.GetByMASRAF_AVANS_ID(masraf.ID);
                //    item.DAVA_DIGER_GIDERLERI = masrafDetaylar.Sum(vi => vi.TOPLAM_TUTAR);
                //});
                // YKS 08.07.2011 BV

                // 19.07.2011 BV Teminat mektubu
                if (gridControl.MainView.Name == "gridView1")
                {
                    MyTeminatDataSource = DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.Find("DAVA_FOY_ID = " + item.ID);
                    if (MyTeminatDataSource.Count == 0)
                    {
                        item.IsTeminat = false;
                        if (item.DAVA_EDILEN_TUTAR.HasValue) item.DAVA_DIGER_GIDERLERI = (item.DAVA_EDILEN_TUTAR.Value * 2) / 100;
                    }
                    else
                    {
                        if (item.DAVA_EDILEN_TUTAR.HasValue) item.DAVA_DIGER_GIDERLERI = (item.DAVA_EDILEN_TUTAR.Value * 5) / 100;
                        item.DAVA_EDILEN_VEKALET_UCRETI = item.DAVA_EDILEN_VEKALET_UCRETI * 2;
                        item.IsTeminat = true;
                    }
                }
                else
                {
                    if (item.DAVA_EDILEN_TUTAR.HasValue) item.DAVA_DIGER_GIDERLERI = (item.DAVA_EDILEN_TUTAR.Value * 2) / 100;
                }

                if (!item.DAVA_EDILEN_TUTAR.HasValue) item.DAVA_EDILEN_TUTAR = 0;
                item.TOPLAM_ALACAK = item.DAVA_EDILEN_TUTAR.Value + item.ISLEMIS_FAIZ + item.SONRAKI_FAIZ + item.DAVA_DIGER_GIDERLERI + item.DAVA_EDILEN_VEKALET_UCRETI;
                if (!item.POLICE_LIMIT.HasValue) item.POLICE_LIMIT = 0;
                item.KALAN_ALACAK = item.TOPLAM_ALACAK - item.POLICE_LIMIT.Value;
                item.TOPLAM_ALACAK_DOVIZ_ID = item.DAVA_EDILEN_TUTAR_DOVIZ_ID;
                item.KALAN_ALACAK_DOVIZ_ID = item.TOPLAM_ALACAK_DOVIZ_ID;

                //if (gridView1.Columns["DAVA_OZEL_KOD1"] != null)

                //policeListesi = AvukatProLib.Arama.per_DAVA_NEDEN_POLICE_Sorgu.GetByFiltreView(item.ID);
                //if (policeListesi.Count != 0)
                //{
                //    item.PoliceliMi = true;
                //}
                //else
                //{
                //    item.PoliceliMi = false;
                //}

                borcluOdemeler = DataRepository.AV001_TD_BIL_BORCLU_ODEMEProvider.Find(" DAVA_FOY_ID = " + item.ID.ToString());

                if (borcluOdemeler.Count > 0)
                {
                    foreach (AV001_TD_BIL_BORCLU_ODEME borcOdeme in borcluOdemeler)
                    {
                        item.OdemeMiktar += borcOdeme.ODEME_MIKTAR;
                    }
                }
            }

            if (gridControl.MainView.Name == "gridView1")
            {
                gridView1.UpdateSummary();
                gridView1.UpdateTotalSummary();
                gridView1.UpdateGroupSummary();

                gridView1.GroupSummary.Clear();
                foreach (GridColumn item in gridView1.Columns)
                {
                    try
                    {
                        if (item.SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                            gridView1.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, item.FieldName, item, "{0:C2}");
                    }
                    catch { ;}
                }
            }
            else
            {
                gvMuallakRapor.UpdateSummary();
                gvMuallakRapor.UpdateTotalSummary();
                gvMuallakRapor.UpdateGroupSummary();

                gvMuallakRapor.GroupSummary.Clear();
                foreach (GridColumn item in gvMuallakRapor.Columns)
                {
                    try
                    {
                        if (item.SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                            gvMuallakRapor.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, item.FieldName, item, "{0:C2}");
                    }
                    catch { ;}
                }
            }
        }

        private void RightClickPopup_PopupButtonClick(object sender, ItemClickEventArgs e)
        {
            AvukatProLib.Arama.R_MuallakRaporDavaNedeniBazinda dosya;

            if (e.Item.Tag != null)
            {
                switch (e.Item.Name)
                {
                    case "barButtonItem1":
                        if (gridView1.GetFocusedRow() != null)
                        {
                            dosya = gridView1.GetFocusedRow() as AvukatProLib.Arama.R_MuallakRaporDavaNedeniBazinda;

                            frmTeminatlarMektuplar frmTeminatMektup = new frmTeminatlarMektuplar();

                            TList<AV001_TDI_BIL_TEMINAT_MEKTUP> mektuplar = DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.Find("DAVA_FOY_ID = " + dosya.ID.ToString());

                            if (mektuplar.Count != 0)
                            {
                                frmTeminatMektup.gcMektupListesi.DataSource = mektuplar;
                                frmTeminatMektup.Show();
                            }
                            else
                            {
                                return;
                            }
                        }
                        else if (gvMuallakRapor.GetFocusedRow() != null)
                        {
                            return;
                        }
                        break;

                    case "barButtonItem2":
                        if (gridView1.GetFocusedRow() != null)
                        {
                            dosya = gridView1.GetFocusedRow() as AvukatProLib.Arama.R_MuallakRaporDavaNedeniBazinda;
                        }
                        if (gvMuallakRapor.GetFocusedRow() != null)
                        {
                            dosya = gvMuallakRapor.GetFocusedRow() as AvukatProLib.Arama.R_MuallakRaporDavaNedeniBazinda;
                        }
                        else
                        {
                            dosya = null;
                        }

                        #region KNABug-04.12.2011-katman basılmalı bu view eklenmeli

                        //List<per_DAVA_NEDEN_POLICE> policeListesi = new List<per_DAVA_NEDEN_POLICE>();

                        //policeListesi = AvukatProLib.Arama.per_DAVA_NEDEN_POLICE_Sorgu.GetByFiltreView(dosya.ID);
                        //if (policeListesi.Count != 0)
                        //{
                        //    frmPoliceler frmPolice = new frmPoliceler();
                        //    frmPolice.grdControlPoliceListesi.DataSource = policeListesi;
                        //    frmPolice.Show();
                        //}
                        //else
                        //{
                        //    return;
                        //}

                        #endregion KNABug-04.12.2011-katman basılmalı bu view eklenmeli

                        break;

                    case "barButtonItem3":
                        if (gridView1.GetFocusedRow() != null)
                        {
                            dosya = gridView1.GetFocusedRow() as AvukatProLib.Arama.R_MuallakRaporDavaNedeniBazinda;
                        }
                        if (gvMuallakRapor.GetFocusedRow() != null)
                        {
                            dosya = gvMuallakRapor.GetFocusedRow() as AvukatProLib.Arama.R_MuallakRaporDavaNedeniBazinda;
                        }
                        else
                        {
                            dosya = null;
                        }

                        TList<AV001_TD_BIL_BORCLU_ODEME> borcluOdeme = new TList<AV001_TD_BIL_BORCLU_ODEME>();

                        borcluOdeme = DataRepository.AV001_TD_BIL_BORCLU_ODEMEProvider.Find(" DAVA_FOY_ID = " + dosya.ID.ToString());

                        if (borcluOdeme.Count != 0)
                        {
                            frmDavaOdemeler frmDavaOdemeleri = new frmDavaOdemeler();
                            frmDavaOdemeleri.MyDataSource = borcluOdeme;
                            frmDavaOdemeleri.Show();
                        }
                        else
                        {
                            return;
                        }
                        break;

                    case "barButtonItem4":
                        if (gridView1.GetFocusedRow() != null)
                        {
                            dosya = gridView1.GetFocusedRow() as AvukatProLib.Arama.R_MuallakRaporDavaNedeniBazinda;
                        }
                        if (gvMuallakRapor.GetFocusedRow() != null)
                        {
                            dosya = gvMuallakRapor.GetFocusedRow() as AvukatProLib.Arama.R_MuallakRaporDavaNedeniBazinda;
                        }
                        else
                        {
                            dosya = null;
                        }

                        //TList<AvukatProLib2.Entities.AV001_TD_BIL_DAVA_NEDEN> davaNedenleri = new TList<AvukatProLib2.Entities.AV001_TD_BIL_DAVA_NEDEN>();

                        //davaNedenleri = DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.Find(" DAVA_FOY_ID = " + dosya.ID.ToString());

                        //if (davaNedenleri.Count != 0)
                        //{
                        //    frmDavaNedenleri frmNedenler = new frmDavaNedenleri();
                        //    frmNedenler.grdControlDava.DataSource = davaNedenleri;

                        //    frmNedenler.Show();
                        //}
                        //else
                        //{
                        //    return;
                        //}
                        AvukatProLib2.Entities.AV001_TD_BIL_FOY dava = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(dosya.ID);

                        DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(dava, true, DeepLoadType.IncludeChildren, typeof(TList<AvukatProLib2.Entities.AV001_TD_BIL_DAVA_NEDEN>));

                        TList<AvukatProLib2.Entities.AV001_TD_BIL_DAVA_NEDEN> davaNedenleri = new TList<AvukatProLib2.Entities.AV001_TD_BIL_DAVA_NEDEN>();

                        davaNedenleri = dava.AV001_TD_BIL_DAVA_NEDENCollection;

                        if (davaNedenleri.Count != 0)
                        {
                            frmDavaNedenler frmNedenler = new frmDavaNedenler();
                            frmNedenler.grdControlDava.DataSource = davaNedenleri;

                            frmNedenler.Show();
                        }
                        else
                        {
                            return;
                        }
                        break;

                    default:
                        return;
                }
            }
        }

        private void TumunuSecKaldir(DevExpress.XtraGrid.Views.Grid.GridView gridView, DevExpress.XtraGrid.GridControl gridControl, bool secili)
        {
            foreach (AvukatProLib.Arama.R_MuallakRaporDavaNedeniBazinda tmp in (List<AvukatProLib.Arama.R_MuallakRaporDavaNedeniBazinda>)gridView.DataSource)
                tmp.IsSelected = false;
            for (int i = 0; i < gridView.DataRowCount; i++)
            {
                try
                {
                    AvukatProLib.Arama.R_MuallakRaporDavaNedeniBazinda tmp = (AvukatProLib.Arama.R_MuallakRaporDavaNedeniBazinda)gridView.GetRow(i);
                    tmp.IsSelected = secili;
                }
                catch
                {
                }
            }
            gridView.RefreshData();
            gridControl.RefreshDataSource();
            gridControl.Refresh();
        }

        private void xtraTabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (e.Page.Name == "xtraTabPage2")
                HesapIslemleri(gcMuallakRaporAleyh, false);
        }
    }
}