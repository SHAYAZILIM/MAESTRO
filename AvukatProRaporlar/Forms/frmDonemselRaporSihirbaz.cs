using AvukatProLib;
using AvukatProLib.Arama;
using AvukatProRaporlar.Lib;
using AvukatProRaporlar.RaporSource;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraWizard;
using RaporDataSource.ViewDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AvukatProRaporlar.Forms
{
    internal struct AlacakNeden
    {
        private string _alacakNedeni;

        public string AlacakNedeni
        {
            get { return _alacakNedeni; }
            set { _alacakNedeni = value; }
        }
    }

    internal struct HukukBolumu
    {
        private string _hukukBolum;

        private int _id;

        public string HukukBolum
        {
            get { return _hukukBolum; }
            set { _hukukBolum = value; }
        }

        public int ID
        {
            set { _id = value; }
        }
    }
    
    internal struct SubeIDAD
    {
        private int _ID;
        private string _subeAdi;

        public int ID
        {
            set { _ID = value; }
        }

        public string SubeAdi
        {
            get { return _subeAdi; }
            set { _subeAdi = value; }
        }
    }

    internal struct TakipYolu
    {
        private int _id;
        private string _takipYolu;

        public int ID
        {
            set { _id = value; }
        }

        public string TakipYol
        {
            get { return _takipYolu; }
            set { _takipYolu = value; }
        }
    }

    public partial class frmDonemselRaporSihirbaz : DevExpress.XtraEditors.XtraForm
    {
        public frmDonemselRaporSihirbaz()
        {
            InitializeComponent();
            if (compList == null)
            {
                if (Program.compList == null)
                {
                    bw = new BackgroundWorker();
                    bool bwEntered = false;
                    bw.WorkerSupportsCancellation = true;
                    bw.DoWork += delegate
                    {
                        if (dbV == null)
                        {
                            compList = CompInfo.CompInfoListGetir();
                            dbV = new AvukatProViewDataContext(compList[0].ConStr);
                            var ks = dbV.TDI_BIL_KULLANICI_SUBE_BILGILERIs.Count();
                        }
                        bwEntered = true;
                    };
                    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                    if (!bw.IsBusy && !bwEntered) bw.RunWorkerAsync();
                }
                else
                {
                    this.dbV = Program.dbV;
                }
            }
        }

        public List<CompInfo> compList;
        public AvukatProViewDataContext dbV;
        public int raporTipi;
        private static frmDonemselRaporSihirbaz frm;
        private static DonemselRaporResult result;
        private IQueryable<AlacakNeden> alacakNedenleri;
        private bool bos = true;
        private BackgroundWorker bw;
        private List<FiltreBilgileri> filtreler;
        private Size formSize;
        private IQueryable<HukukBolumu> hukukBolumleri;
        private IQueryable<AvukatIDCariAD> kadroluAvukatlar;
        private IQueryable<AvukatIDCariAD> sozlesmeliAvukatlar;
        private IQueryable<SubeIDAD> subeler;
        private IQueryable<TakipYolu> takipYollari;
        private IQueryable<AvukatIDCariAD> tumAvukatlar;

        #region Çıktı Alma

        private void ExportIt(int ciktiTipi)
        {
            ////////////////////////
            PrintingSystem prts = new PrintingSystem();
            prts.ContinuousPageNumbering = true;

            CompositeLink compositeLink = new DevExpress.XtraPrintingLinks.CompositeLink(prts);
            compositeLink.PageHeaderFooter = "Dönemsel Rapor";
            compositeLink.BreakSpace = 25;
            System.Drawing.Printing.Margins mrg = new System.Drawing.Printing.Margins(1, 1, 30, 1);
            compositeLink.Margins = mrg;
            compositeLink.PaperKind = System.Drawing.Printing.PaperKind.A4Rotated;
            PrintableComponentLink link = new PrintableComponentLink();
            link.Component = gridControl1;
            PrintableComponentLink link2 = new PrintableComponentLink();
            link2.Component = gridControl2;
            PrintableComponentLink link3 = new PrintableComponentLink();
            link3.Component = gridControl3;
            compositeLink.Links.Add(link);
            compositeLink.Links.Add(link2);
            compositeLink.Links.Add(link3);
            SaveFileDialog sv = new SaveFileDialog();
            if (ciktiTipi == 0)
                compositeLink.ShowPreviewDialog();

            else if (ciktiTipi == 1) //Excel
            {
                sv.DefaultExt = "xls";
                sv.Filter = "Excel Dosya Türü|*.xls";
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    compositeLink.CreateDocument();
                    compositeLink.PrintingSystem.ExportToXls(sv.FileName);
                }
            }
            else if (ciktiTipi == 2) //Word
            {
                sv.DefaultExt = "doc";
                sv.Filter = "Word Dosya Türü|*.doc";
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    compositeLink.CreateDocument();
                    compositeLink.PrintingSystem.ExportToRtf(sv.FileName);
                }
            }
            else if (ciktiTipi == 3) //Pdf
            {
                sv.DefaultExt = "xls";
                sv.Filter = "PDF (E-Book) Dosya Türü|*.pdf";
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    compositeLink.CreateDocument();
                    compositeLink.PrintingSystem.ExportToPdf(sv.FileName);
                }
            }
            else if (ciktiTipi == 4) //E-mail
            {
                ///not implemented
            }
        }

        #endregion Çıktı Alma

        public static DonemselRaporResult ShowWizard()
        {
            frm = new frmDonemselRaporSihirbaz();
            frm.ShowDialog();
            return result;
        }

        public static DonemselRaporResult ShowWizard(int raporTipi)
        {
            frm = new frmDonemselRaporSihirbaz();
            frm.raporTipi = raporTipi;
            frm.ShowDialog();

            return result;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bw.CancelAsync();
        }

        private void dateNavigator1_EditDateModified(object sender, EventArgs e)
        {
            labelControl9.Text = dateNavigator1.DateTime.ToShortDateString();
            if (!(String.IsNullOrEmpty(labelControl10.Text.Trim()) || String.IsNullOrEmpty(labelControl10.Text.Trim())))
                wizardPage7.AllowNext = true;
            else
                wizardPage7.AllowNext = true;
        }

        private void dateNavigator2_EditDateModified(object sender, EventArgs e)
        {
            labelControl10.Text = dateNavigator2.DateTime.ToShortDateString();
            if (!(String.IsNullOrEmpty(labelControl10.Text.Trim()) || String.IsNullOrEmpty(labelControl10.Text.Trim())))
                wizardPage7.AllowNext = true;
            else
                wizardPage7.AllowNext = true;
        }

        private void DevreRaporlari()
        {
            if (AvukatProLib.Hesap.DovizHelper.dataCon == null)
                AvukatProLib.Hesap.DovizHelper.dataCon2 = dbV;

            rBankalaiTaraflisorumluRapor devre = new rBankalaiTaraflisorumluRapor();

            var predi = AvukatProLib.Arama.PredicateBuilder.True<KLASOR_DONEMSEL_RAPOR>();
            if (result.AvukatlarGenel != 2)
                predi = predi.And(vi => result.Avukatlar.Contains(vi.SORUMLU_CARI));
            if (!result.SubelerGenel)
                predi = predi.And(vi => result.Subeler.Contains(vi.SUBE));
            if (!result.KrediRaporlariGenel)
                predi = predi.And(vi => result.KrediRaporlari.Contains(vi.ALACAK_NEDENI));
            if (!result.HukukGenel)
                predi = predi.And(vi => result.HukukBolumleri.Contains(vi.BOLUM));

            var predi2 = AvukatProLib.Arama.PredicateBuilder.True<DONEMSEL_TAKIPLI_ALACAKLAR_RAPORLAR>(); // Bireysel ve Ticari
            // Takipli rapor için
            if (!result.TakipRaporlariGenel)
                predi2 = predi2.And(vi => result.TakipRaporlari.Contains(vi.TAKIP_YOLU));
            if (result.AvukatlarGenel != 2)
                predi2 = predi2.And(vi => result.Avukatlar.Contains(vi.SORUMLU_CARI));
            if (raporTipi == 2 && !result.KrediRaporlariGenel)
            {
                predi2 = predi2.And(vi => result.Subeler.Contains(vi.OZEL_KOD));
            }
            else if (raporTipi == 3)
                predi2 = predi2.And(vi => result.Subeler.Contains(vi.FOY_SUBE));

            if (!result.KrediRaporlariGenel)
                predi2 = predi2.And(vi => result.KrediRaporlari.Contains(vi.ALACAK_NEDENI));

            List<KlasorDonemselRaporGayrinakit> liste2;

            #region Ticari Krediler Tüm Alacaklar Sorguları

            if (result.RaporTuru == 1)
            {
                var klasorlerMain = dbV.KLASOR_DONEMSEL_RAPORs.Where(predi);

                var klasorler = (from tbl in klasorlerMain where !(tbl.DEPO_ALACAGI.HasValue && tbl.DEPO_ALACAGI.Value) select tbl).ToList();

                #region Dovizlileri TL'ye çevirme

                foreach (var tmp in klasorler)
                {
                    if (tmp.TUTAR_ANAPARA_DOVIZ_ID.HasValue && tmp.TUTAR_ANAPARA_DOVIZ_ID.Value > 1)
                        tmp.TUTAR_ANAPARA = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.TUTAR_ANAPARA.Value, tmp.TUTAR_ANAPARA_DOVIZ_ID.Value, DateTime.Today);
                    if (tmp.ODEME_ANAPARA_DOVIZ_ID.HasValue && tmp.ODEME_ANAPARA_DOVIZ_ID.Value > 1)
                        tmp.ODEME_ANAPARA = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.ODEME_ANAPARA.Value, tmp.ODEME_ANAPARA_DOVIZ_ID.Value, DateTime.Today);
                    if (tmp.ODEME_FAIZ_DOVIZ_ID.HasValue && tmp.ODEME_FAIZ_DOVIZ_ID.Value > 1)
                        tmp.ODEME_FAIZ = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.ODEME_FAIZ.Value, tmp.ODEME_FAIZ_DOVIZ_ID.Value, DateTime.Today);
                    if (tmp.TUTAR_GIDER_VERGISI_DOVIZ_ID.HasValue && tmp.TUTAR_GIDER_VERGISI_DOVIZ_ID.Value > 1)
                        tmp.TUTAR_GIDER_VERGISI = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.TUTAR_GIDER_VERGISI.Value, tmp.TUTAR_GIDER_VERGISI_DOVIZ_ID.Value, DateTime.Today);
                    if (tmp.TUTAR_MASRAF_DOVIZ_ID.HasValue && tmp.TUTAR_MASRAF_DOVIZ_ID.Value > 1)
                        tmp.TUTAR_MASRAF = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.TUTAR_MASRAF.Value, tmp.TUTAR_MASRAF_DOVIZ_ID.Value, DateTime.Today);
                    if (tmp.TUTAR_KOM_TAZ_DOVIZ_ID.HasValue && tmp.TUTAR_KOM_TAZ_DOVIZ_ID.Value > 1)
                        tmp.TUTAR_KOM_TAZ = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.TUTAR_KOM_TAZ.Value, tmp.TUTAR_KOM_TAZ_DOVIZ_ID.Value, DateTime.Today);
                    if (tmp.KALAN_ANAPARA_DOVIZ_ID.HasValue && tmp.KALAN_ANAPARA_DOVIZ_ID.Value > 1)
                        tmp.KALAN_ANAPARA = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.KALAN_ANAPARA.Value, tmp.KALAN_ANAPARA_DOVIZ_ID.Value, DateTime.Today);
                }

                #endregion Dovizlileri TL'ye çevirme

                var devirdenGelen = from tbl in klasorler where tbl.TUTAR_ANAPARA != null && tbl.BASLANGIC_TARIHI < result.rdat select new { tbl.TUTAR_ANAPARA, tbl.ALACAK_NEDENI };

                decimal devirdenGelenToplam;
                if (devirdenGelen.Count() > 0)
                    devirdenGelenToplam = devirdenGelen.Sum(item => item.TUTAR_ANAPARA.Value);
                else
                    devirdenGelenToplam = 0;

                var devirdenGelenAdetSorgu = from tbl in klasorler where tbl.BASLANGIC_TARIHI < result.rdat select tbl.ID;
                int devirdenGelenAdet = devirdenGelenAdetSorgu.Distinct().Count();

                var gelenSorgu = from tbl in klasorler where tbl.TUTAR_ANAPARA != null && tbl.BASLANGIC_TARIHI > result.rdat && tbl.BASLANGIC_TARIHI < result.rest select new { tbl.TUTAR_ANAPARA, tbl.ALACAK_NEDENI };
                decimal gelenToplam;
                if (gelenSorgu.Count() > 0)
                    gelenToplam = gelenSorgu.Sum(item => item.TUTAR_ANAPARA.Value);
                else
                    gelenToplam = 0;

                var gelenSorguEklenen = from tbl in klasorler where tbl.BASLANGIC_TARIHI > result.rdat && tbl.BASLANGIC_TARIHI < result.rest select tbl;
                int gelenAdet = gelenSorguEklenen.Select(item => item.ID).Distinct().Count();

                var gelenSorgu2 = from tbl in klasorler where tbl.BASLANGIC_TARIHI < result.rest select tbl;

                var tahsilatlaKapananSorgu = from tbl in gelenSorgu2 where tbl.DURUM_ID == 6 || tbl.DURUM_ID == 16 select new { tbl.ID, tbl.TUTAR_ANAPARA, tbl.ALACAK_NEDENI };
                int tahsilatlaKapananAdet = tahsilatlaKapananSorgu.Distinct().Count();

                var tahsilatlaKapananMiktarSorgu = from tbl in tahsilatlaKapananSorgu where tbl.TUTAR_ANAPARA != null select tbl.TUTAR_ANAPARA;
                decimal tahsilatlaKapananMiktar;
                if (tahsilatlaKapananMiktarSorgu.Count() > 0)
                    tahsilatlaKapananMiktar = tahsilatlaKapananMiktarSorgu.Sum(item => item.Value);
                else
                    tahsilatlaKapananMiktar = 0;

                var acizDerkenarSorgu = from tbl in gelenSorgu2 where (tbl.DURUM_ID == 3 || tbl.DURUM_ID == 24 || tbl.DURUM_ID == 29 || tbl.DURUM_ID == 30) select new { tbl.ID, tbl.TUTAR_ANAPARA };
                int acizDerkenarAdet = acizDerkenarSorgu.Distinct().Count();

                var acizDerkenarMiktarSorgu = from tbl in acizDerkenarSorgu where tbl.TUTAR_ANAPARA != null select tbl.TUTAR_ANAPARA; ;
                decimal acizDerkenarMiktar;
                if (acizDerkenarMiktarSorgu.Count() > 0)
                    acizDerkenarMiktar = acizDerkenarMiktarSorgu.Sum(item => item.Value);
                else
                    acizDerkenarMiktar = 0;

                var tahsilatDagilimiAnaparaSorgu = from tbl in gelenSorgu2 where tbl.ODEME_ANAPARA.HasValue select new { tbl.ODEME_ANAPARA, tbl.ALACAK_NEDENI }; ;
                decimal tdAnapara = 0;
                if (tahsilatDagilimiAnaparaSorgu.Count() > 0)
                    tdAnapara = tahsilatDagilimiAnaparaSorgu.Sum(item => item.ODEME_ANAPARA.Value);
                else
                    tdAnapara = 0;

                var tahsilatDagilimiFaizSorgu = from tbl in gelenSorgu2 where tbl.ODEME_FAIZ != null select new { tbl.ODEME_FAIZ, tbl.ALACAK_NEDENI }; ;
                decimal tdFaiz;
                if (tahsilatDagilimiFaizSorgu.Count() > 0)
                    tdFaiz = tahsilatDagilimiFaizSorgu.Sum(item => item.ODEME_FAIZ.Value);
                else
                    tdFaiz = 0;

                decimal tdMasraf = 0;
                var tahsilatDagilimiMasrafSorgu1 = from tbl in gelenSorgu2 where tbl.TUTAR_GIDER_VERGISI != null select new { tbl.TUTAR_GIDER_VERGISI, tbl.ALACAK_NEDENI }; ;
                if (tahsilatDagilimiMasrafSorgu1.Count() > 0)
                    tdMasraf += tahsilatDagilimiMasrafSorgu1.Sum(item => item.TUTAR_GIDER_VERGISI.Value);

                var tahsilatDagilimiMasrafSorgu2 = from tbl in gelenSorgu2 where tbl.TUTAR_MASRAF != null select new { tbl.TUTAR_MASRAF, tbl.ALACAK_NEDENI };
                if (tahsilatDagilimiMasrafSorgu2.Count() > 0)
                    tdMasraf += tahsilatDagilimiMasrafSorgu2.Sum(item => item.TUTAR_MASRAF.Value);

                var tahsilatDagilimiMasrafSorgu3 = from tbl in gelenSorgu2 where tbl.TUTAR_KOM_TAZ != null select new { tbl.TUTAR_KOM_TAZ, tbl.ALACAK_NEDENI }; ;
                if (tahsilatDagilimiMasrafSorgu3.Count() > 0)
                    tdMasraf += tahsilatDagilimiMasrafSorgu3.Sum(item => item.TUTAR_KOM_TAZ.Value);

                decimal devirMiktar = 0;
                var devirMiktarSorgu = from tbl in klasorler where tbl.KALAN_ANAPARA != null && tbl.BASLANGIC_TARIHI > result.rest select new { tbl.KALAN_ANAPARA, tbl.ALACAK_NEDENI }; ;
                if (devirMiktarSorgu.Count() > 0)
                    devirMiktar = devirMiktarSorgu.Sum(item => item.KALAN_ANAPARA.Value);

                var devirAdetSorgu = from tbl in klasorler where tbl.BASLANGIC_TARIHI > result.rest select tbl.ID;
                int devirAdet = devirAdetSorgu.Distinct().Count();

                #region Klasor bazında

                List<KlasorDonemselRaporNakit> listeMain = new List<KlasorDonemselRaporNakit>();
                KlasorDonemselRaporNakit nakitMain = new KlasorDonemselRaporNakit();

                nakitMain.devirdenAdet = devirdenGelenAdet;
                nakitMain.devirdenMiktar = devirdenGelenToplam;
                nakitMain.gelenAdet = gelenAdet;
                nakitMain.gelenMiktar = gelenToplam;
                nakitMain.tahsilatAdet = tahsilatlaKapananAdet;
                nakitMain.tahsilatMiktar = tahsilatlaKapananMiktar;
                nakitMain.acizAdet = acizDerkenarAdet;
                nakitMain.acizMiktar = acizDerkenarMiktar;
                nakitMain.tahsilatDagAnapara = tdAnapara;
                nakitMain.tahsilatDagFaize = tdFaiz;
                nakitMain.tahsilatDagMasraflara = tdMasraf;
                nakitMain.devirAdet = devirAdet;
                nakitMain.devirMiktar = devirMiktar;

                listeMain.Add(nakitMain);
                gridControl1.DataSource = listeMain;

                #endregion Klasor bazında

                var klasorler2 = (from tbl in klasorlerMain where (tbl.DEPO_ALACAGI.HasValue && tbl.DEPO_ALACAGI.Value && !tbl.VADE_TARIHI.HasValue) select tbl).ToList();

                #region Dovizlileri TL'ye çevirme

                foreach (var tmp in klasorler2)
                {
                    if (tmp.ISLEME_KONAN_TUTAR_DOVIZ_ID.HasValue && tmp.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value > 1)
                        tmp.ISLEME_KONAN_TUTAR = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.ISLEME_KONAN_TUTAR.Value, tmp.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value, DateTime.Today);
                    if (tmp.DEPO_EDILEN_TUTAR_DOVIZ_ID.HasValue && tmp.DEPO_EDILEN_TUTAR_DOVIZ_ID.Value > 1)
                        tmp.DEPO_EDILEN_TUTAR = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.DEPO_EDILEN_TUTAR.Value, tmp.DEPO_EDILEN_TUTAR_DOVIZ_ID.Value, DateTime.Today);
                    if (tmp.IADE_MIKTARI_DOVIZ_ID.HasValue && tmp.IADE_MIKTARI_DOVIZ_ID.Value > 1)
                        tmp.IADE_MIKTARI = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.IADE_MIKTARI.Value, tmp.IADE_MIKTARI_DOVIZ_ID.Value, DateTime.Today);
                    if (tmp.TAZMIN_MIKTAR_DOVIZ_ID.HasValue && tmp.TAZMIN_MIKTAR_DOVIZ_ID.Value > 1)
                        tmp.TAZMIN_MIKTARI = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.TAZMIN_MIKTARI.Value, tmp.TAZMIN_MIKTAR_DOVIZ_ID.Value, DateTime.Today);
                }

                #endregion Dovizlileri TL'ye çevirme

                var devirdenGelen2 = from tbl in klasorler2 where (tbl.DEPO_ALACAGI.HasValue && tbl.DEPO_ALACAGI.Value) && tbl.ISLEME_KONAN_TUTAR != null && tbl.BASLANGIC_TARIHI < result.rdat select tbl.ISLEME_KONAN_TUTAR;

                decimal devirdenGelenToplam2;
                if (devirdenGelen2.Count() > 0)
                    devirdenGelenToplam2 = devirdenGelen2.Sum(item => item.Value);
                else
                    devirdenGelenToplam2 = 0;

                var devirdenGelenAdetSorgu2 = from tbl in klasorler2 where tbl.BASLANGIC_TARIHI < result.rdat select tbl.ALACAK_NEDEN_ID;
                int devirdenGelenAdet2 = devirdenGelenAdetSorgu2.Distinct().Count();

                var gelenSorguEklenen2 = from tbl in klasorler2 where tbl.ISLEME_KONAN_TUTAR != null && tbl.BASLANGIC_TARIHI > result.rdat && tbl.BASLANGIC_TARIHI < result.rest select tbl.ISLEME_KONAN_TUTAR;

                decimal gelenToplam2;
                if (gelenSorguEklenen2.Count() > 0)
                    gelenToplam2 = gelenSorguEklenen2.Sum(item => item.Value);
                else
                    gelenToplam2 = 0;

                var gelenSorgu4 = from tbl in klasorler2 where tbl.BASLANGIC_TARIHI < result.rest select tbl;

                var gelenSorguEkle = from tbl in klasorler2 where tbl.BASLANGIC_TARIHI > result.rdat && tbl.BASLANGIC_TARIHI < result.rest select tbl.ALACAK_NEDEN_ID;
                int gelenAdet2 = gelenSorguEkle.Distinct().Count();

                var tahsilatlaKapananSorgu2 = from tbl in gelenSorgu4 select new { tbl.ALACAK_NEDEN_ID, tbl.DEPO_EDILEN_TUTAR, tbl.DEPO_SAYISI };
                int tahsilatlaKapananAdet2 = tahsilatlaKapananSorgu2.Distinct().Where(vi => vi.DEPO_SAYISI.HasValue).Count();

                var tahsilatlaKapananMiktarSorgu2 = from tbl in tahsilatlaKapananSorgu2 where tbl.DEPO_EDILEN_TUTAR.HasValue select tbl.DEPO_EDILEN_TUTAR;
                decimal tahsilatlaKapananMiktar2;
                if (tahsilatlaKapananMiktarSorgu2.Count() > 0)
                    tahsilatlaKapananMiktar2 = tahsilatlaKapananMiktarSorgu2.Sum(item => item.Value);
                else
                    tahsilatlaKapananMiktar2 = 0;

                var bankayaIadeSorgu = from tbl in gelenSorgu4 select new { tbl.ALACAK_NEDEN_ID, tbl.IADE_MIKTARI, tbl.IADE_SAYISI };
                int bankayaIadeAdet = bankayaIadeSorgu.Distinct().Where(vi => vi.IADE_SAYISI.HasValue).Count();

                var bankayaIadeMiktarSorgu = from tbl in bankayaIadeSorgu where tbl.IADE_MIKTARI.HasValue select tbl.IADE_MIKTARI;
                decimal bankayaIadeMiktar;
                if (bankayaIadeMiktarSorgu.Count() > 0)
                    bankayaIadeMiktar = bankayaIadeMiktarSorgu.Sum(item => item.Value);
                else
                    bankayaIadeMiktar = 0;

                var tazminEdilenMiktarSorgu = from tbl in gelenSorgu4 where tbl.TAZMIN_MIKTARI.HasValue select tbl.TAZMIN_MIKTARI;
                decimal tazminMiktar;
                if (tazminEdilenMiktarSorgu.Count() > 0)
                    tazminMiktar = tazminEdilenMiktarSorgu.Sum(item => item.Value);
                else
                    tazminMiktar = 0;

                var tazminEdilenAdetSorgu = from tbl in gelenSorgu4 select new { tbl.ALACAK_NEDEN_ID, tbl.TAZMIN_SAYISI, tbl.TAZMIN_MIKTARI };
                int tazminEdilenAdet = tazminEdilenAdetSorgu.Distinct().Where(vi => vi.TAZMIN_SAYISI.HasValue).Count();

                decimal devirMiktar2 = 0;
                var devirMiktarSorgu2 = from tbl in klasorler2 where tbl.ISLEME_KONAN_TUTAR != null && tbl.BASLANGIC_TARIHI > result.rest select new { tbl.ISLEME_KONAN_TUTAR, tbl.ALACAK_NEDENI }; ;
                if (devirMiktarSorgu2.Count() > 0)
                    devirMiktar2 = devirMiktarSorgu2.Sum(item => item.ISLEME_KONAN_TUTAR.Value);

                var devirAdetSorgu2 = from tbl in klasorler2 where tbl.BASLANGIC_TARIHI > result.rest select tbl.ALACAK_NEDEN_ID;
                int devirAdet2 = devirAdetSorgu2.Distinct().Count();

                #region Klasor bazında

                liste2 = new List<KlasorDonemselRaporGayrinakit>();
                KlasorDonemselRaporGayrinakit gayrinakit = new KlasorDonemselRaporGayrinakit();
                gayrinakit.bankayaAdet = bankayaIadeAdet;
                gayrinakit.bankayaMiktar = bankayaIadeMiktar;
                gayrinakit.devirAdet = devirAdet2;
                gayrinakit.devirdenAdet = devirdenGelenAdet2;
                gayrinakit.devirdenMiktar = devirdenGelenToplam2;
                gayrinakit.devirMiktar = devirMiktar2;
                gayrinakit.gelenAdet = gelenAdet2;
                gayrinakit.gelenMiktar = gelenToplam2;
                gayrinakit.tahsilatAdet = tahsilatlaKapananAdet2;
                gayrinakit.tahsilatMiktar = tahsilatlaKapananMiktar2;
                gayrinakit.tazminAdet = tazminEdilenAdet;
                gayrinakit.tazminMiktar = tazminMiktar;

                liste2.Add(gayrinakit);
                gridControl1.DataSource = listeMain;

                #endregion Klasor bazında

                gridControl1.DataSource = listeMain;
                gridControl2.DataSource = liste2;

                if (klasorlerMain.Count() == 0)
                    XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
            }

            #endregion Ticari Krediler Tüm Alacaklar Sorguları

            #region Ticari Krediler Takipli

            else if (raporTipi == 2)
            {
                var klasorlerMain = (dbV.DONEMSEL_TAKIPLI_ALACAKLAR_RAPORLARs.Where(predi2).Where(vi => vi.PROJE_ID.HasValue)).ToList();

                var klasorler = from tbl in klasorlerMain where !(tbl.DEPO_ALACAGI.HasValue && tbl.DEPO_ALACAGI.Value) select tbl;

                #region Dovizlileri TL'ye çevirme

                foreach (var tmp in klasorler)
                {
                    AvukatProLib.Hesap.DovizHelper.GetMerkezBankasiBilgisi(tmp.ALACAK_NEDEN_KOD_ID);

                    if (tmp.ISLEME_KONAN_TUTAR.HasValue && tmp.ISLEME_KONAN_TUTAR_DOVIZ_ID.HasValue && tmp.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value > 1)
                        tmp.ISLEME_KONAN_TUTAR = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.ISLEME_KONAN_TUTAR.Value, tmp.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value, DateTime.Today);
                    if (tmp.ODEME_DAGILIM_TUTAR.HasValue && tmp.ODEME_DAGILIM_TUTAR_DOVIZ_ID.HasValue && tmp.ODEME_DAGILIM_TUTAR_DOVIZ_ID.Value > 1)
                        tmp.ODEME_DAGILIM_TUTAR = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.ODEME_DAGILIM_TUTAR.Value, tmp.ODEME_DAGILIM_TUTAR_DOVIZ_ID.Value, DateTime.Today);
                }

                #endregion Dovizlileri TL'ye çevirme

                var devirdenGelen = from tbl in klasorler where tbl.ISLEME_KONAN_TUTAR != null && tbl.TAKIP_TARIHI < result.rdat select new { tbl.ISLEME_KONAN_TUTAR, tbl.ALACAK_NEDENI };

                decimal devirdenGelenToplam;
                if (devirdenGelen.Count() > 0)
                    devirdenGelenToplam = devirdenGelen.Sum(item => item.ISLEME_KONAN_TUTAR.Value);
                else
                    devirdenGelenToplam = 0;

                var devirdenGelenAdetSorgu = from tbl in klasorler where tbl.TAKIP_TARIHI < result.rdat select tbl.FOY_ID;
                int devirdenGelenAdet = devirdenGelenAdetSorgu.Distinct().Count();

                var gelenSorgu = from tbl in klasorler where tbl.ISLEME_KONAN_TUTAR != null && tbl.TAKIP_TARIHI > result.rdat && tbl.TAKIP_TARIHI < result.rest select new { tbl.ISLEME_KONAN_TUTAR, tbl.ALACAK_NEDENI };
                decimal gelenToplam;
                if (gelenSorgu.Count() > 0)
                    gelenToplam = gelenSorgu.Sum(item => item.ISLEME_KONAN_TUTAR.Value);
                else
                    gelenToplam = 0;

                var gelenSorguEklenen = from tbl in klasorler where tbl.TAKIP_TARIHI > result.rdat && tbl.TAKIP_TARIHI < result.rest select tbl;
                int gelenAdet = gelenSorguEklenen.Select(item => item.FOY_ID).Distinct().Count();

                var gelenSorgu2 = from tbl in klasorler where tbl.TAKIP_TARIHI < result.rest select tbl;

                var tahsilatlaKapananSorgu = from tbl in gelenSorgu2 where tbl.DURUM_ID == 6 || tbl.DURUM_ID == 16 select new { tbl.FOY_ID, tbl.ISLEME_KONAN_TUTAR, tbl.ALACAK_NEDENI };
                int tahsilatlaKapananAdet = tahsilatlaKapananSorgu.Distinct().Count();

                var tahsilatlaKapananMiktarSorgu = from tbl in tahsilatlaKapananSorgu where tbl.ISLEME_KONAN_TUTAR.HasValue select tbl.ISLEME_KONAN_TUTAR;
                decimal tahsilatlaKapananMiktar;
                if (tahsilatlaKapananMiktarSorgu.Count() > 0)
                    tahsilatlaKapananMiktar = tahsilatlaKapananMiktarSorgu.Sum(item => item.Value);
                else
                    tahsilatlaKapananMiktar = 0;

                var acizDerkenarSorgu = from tbl in gelenSorgu2 where (tbl.DURUM_ID == 3 || tbl.DURUM_ID == 24 || tbl.DURUM_ID == 29 || tbl.DURUM_ID == 30) select new { tbl.FOY_ID, tbl.ISLEME_KONAN_TUTAR };
                int acizDerkenarAdet = acizDerkenarSorgu.Distinct().Count();

                var acizDerkenarMiktarSorgu = from tbl in acizDerkenarSorgu where tbl.ISLEME_KONAN_TUTAR.HasValue select tbl.ISLEME_KONAN_TUTAR; ;
                decimal acizDerkenarMiktar;
                if (acizDerkenarMiktarSorgu.Count() > 0)
                    acizDerkenarMiktar = acizDerkenarMiktarSorgu.Sum(item => item.Value);
                else
                    acizDerkenarMiktar = 0;

                var tahsilatDagilimiAnaparaSorgu = from tbl in gelenSorgu2 where (tbl.MAHSUP_KATEGORI_ID == 12 || tbl.MAHSUP_KATEGORI_ID == 2) && tbl.ODEME_DAGILIM_TUTAR.HasValue select new { tbl.ODEME_DAGILIM_TUTAR, tbl.ALACAK_NEDENI }; ;
                decimal tdAnapara = 0;
                if (tahsilatDagilimiAnaparaSorgu.Count() > 0)
                    tdAnapara = tahsilatDagilimiAnaparaSorgu.Sum(item => item.ODEME_DAGILIM_TUTAR.Value);
                else
                    tdAnapara = 0;

                var tahsilatDagilimiFaizSorgu = from tbl in gelenSorgu2 where (tbl.MAHSUP_KATEGORI_ID == 17 || tbl.MAHSUP_KATEGORI_ID == 8) && tbl.ODEME_DAGILIM_TUTAR.HasValue select new { tbl.ODEME_DAGILIM_TUTAR, tbl.ALACAK_NEDENI }; ;
                decimal tdFaiz;
                if (tahsilatDagilimiFaizSorgu.Count() > 0)
                    tdFaiz = tahsilatDagilimiFaizSorgu.Sum(item => item.ODEME_DAGILIM_TUTAR.Value);
                else
                    tdFaiz = 0;

                decimal tdMasraf = 0;
                var tahsilatDagilimiMasrafSorgu1 = from tbl in gelenSorgu2 where (tbl.MAHSUP_KATEGORI_ID == 14 || tbl.MAHSUP_KATEGORI_ID == 5 || tbl.MAHSUP_KATEGORI_ID == 18 || tbl.MAHSUP_KATEGORI_ID == 9 || tbl.MAHSUP_KATEGORI_ID == 16 || tbl.MAHSUP_KATEGORI_ID == 7) && tbl.ODEME_DAGILIM_TUTAR.HasValue select new { tbl.ODEME_DAGILIM_TUTAR, tbl.ALACAK_NEDENI }; ;
                if (tahsilatDagilimiMasrafSorgu1.Count() > 0)
                    tdMasraf += tahsilatDagilimiMasrafSorgu1.Sum(item => item.ODEME_DAGILIM_TUTAR.Value);

                decimal devirMiktar = 0;
                var devirMiktarSorgu = from tbl in klasorler where tbl.ISLEME_KONAN_TUTAR.HasValue && tbl.TAKIP_TARIHI > result.rest select new { tbl.ISLEME_KONAN_TUTAR, tbl.ALACAK_NEDENI }; ;
                if (devirMiktarSorgu.Count() > 0)
                    devirMiktar = devirMiktarSorgu.Sum(item => item.ISLEME_KONAN_TUTAR.Value);

                var devirAdetSorgu = from tbl in klasorler where tbl.TAKIP_TARIHI > result.rest select tbl.FOY_ID;
                int devirAdet = devirAdetSorgu.Distinct().Count();

                #region Klasor bazında

                List<KlasorDonemselRaporNakit> listeMain = new List<KlasorDonemselRaporNakit>();
                KlasorDonemselRaporNakit nakitMain = new KlasorDonemselRaporNakit();

                nakitMain.devirdenAdet = devirdenGelenAdet;
                nakitMain.devirdenMiktar = devirdenGelenToplam;
                nakitMain.gelenAdet = gelenAdet;
                nakitMain.gelenMiktar = gelenToplam;
                nakitMain.tahsilatAdet = tahsilatlaKapananAdet;
                nakitMain.tahsilatMiktar = tahsilatlaKapananMiktar;
                nakitMain.acizAdet = acizDerkenarAdet;
                nakitMain.acizMiktar = acizDerkenarMiktar;
                nakitMain.tahsilatDagAnapara = tdAnapara;
                nakitMain.tahsilatDagFaize = tdFaiz;
                nakitMain.tahsilatDagMasraflara = tdMasraf;
                nakitMain.devirAdet = devirAdet;
                nakitMain.devirMiktar = devirMiktar;

                listeMain.Add(nakitMain);
                gridControl1.DataSource = listeMain;

                #endregion Klasor bazında

                var klasorler2 = (from tbl in klasorlerMain where (tbl.DEPO_ALACAGI.HasValue && tbl.DEPO_ALACAGI.Value && !tbl.VADE_TARIHI.HasValue) select tbl).ToList();

                #region Dovizlileri TL'ye çevirme

                foreach (var tmp in klasorler2)
                {
                    AvukatProLib.Hesap.DovizHelper.GetMerkezBankasiBilgisi(tmp.ALACAK_NEDEN_KOD_ID);

                    if (tmp.ISLEME_KONAN_TUTAR.HasValue && tmp.ISLEME_KONAN_TUTAR_DOVIZ_ID.HasValue && tmp.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value > 1)
                        tmp.ISLEME_KONAN_TUTAR = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.ISLEME_KONAN_TUTAR.Value, tmp.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value, DateTime.Today);
                    if (tmp.ODEME_DAGILIM_TUTAR.HasValue && tmp.ODEME_DAGILIM_TUTAR_DOVIZ_ID.HasValue && tmp.ODEME_DAGILIM_TUTAR_DOVIZ_ID.Value > 1)
                        tmp.ODEME_DAGILIM_TUTAR = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.ODEME_DAGILIM_TUTAR.Value, tmp.ODEME_DAGILIM_TUTAR_DOVIZ_ID.Value, DateTime.Today);

                    if (tmp.DEPO_EDILEN_TUTAR_DOVIZ_ID.HasValue && tmp.DEPO_EDILEN_TUTAR_DOVIZ_ID.Value > 1)
                        tmp.DEPO_EDILEN_TUTAR = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.DEPO_EDILEN_TUTAR.Value, tmp.DEPO_EDILEN_TUTAR_DOVIZ_ID.Value, DateTime.Today);
                    if (tmp.IADE_MIKTARI_DOVIZ_ID.HasValue && tmp.IADE_MIKTARI_DOVIZ_ID.Value > 1)
                        tmp.IADE_MIKTARI = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.IADE_MIKTARI.Value, tmp.IADE_MIKTARI_DOVIZ_ID.Value, DateTime.Today);
                    if (tmp.TAZMIN_MIKTAR_DOVIZ_ID.HasValue && tmp.TAZMIN_MIKTAR_DOVIZ_ID.Value > 1)
                        tmp.TAZMIN_MIKTARI = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.TAZMIN_MIKTARI.Value, tmp.TAZMIN_MIKTAR_DOVIZ_ID.Value, DateTime.Today);
                }

                #endregion Dovizlileri TL'ye çevirme

                var devirdenGelen2 = from tbl in klasorler2 where (tbl.DEPO_ALACAGI.HasValue && tbl.DEPO_ALACAGI.Value) && tbl.ISLEME_KONAN_TUTAR != null && tbl.TAKIP_TARIHI < result.rdat select tbl.ISLEME_KONAN_TUTAR;

                decimal devirdenGelenToplam2;
                if (devirdenGelen2.Count() > 0)
                    devirdenGelenToplam2 = devirdenGelen2.Sum(item => item.Value);
                else
                    devirdenGelenToplam2 = 0;

                var devirdenGelenAdetSorgu2 = from tbl in klasorler2 where tbl.TAKIP_TARIHI < result.rdat select tbl.ALACAK_NEDEN_ID;
                int devirdenGelenAdet2 = devirdenGelenAdetSorgu2.Distinct().Count();

                var gelenSorguEklenen2 = from tbl in klasorler2 where tbl.ISLEME_KONAN_TUTAR != null && tbl.TAKIP_TARIHI > result.rdat && tbl.TAKIP_TARIHI < result.rest select tbl.ISLEME_KONAN_TUTAR;

                decimal gelenToplam2;
                if (gelenSorguEklenen2.Count() > 0)
                    gelenToplam2 = gelenSorguEklenen2.Sum(item => item.Value);
                else
                    gelenToplam2 = 0;

                var gelenSorgu4 = from tbl in klasorler2 where tbl.TAKIP_TARIHI < result.rest select tbl;

                var gelenSorguEkle = from tbl in klasorler2 where tbl.TAKIP_TARIHI > result.rdat && tbl.TAKIP_TARIHI < result.rest select tbl.ALACAK_NEDEN_ID;
                int gelenAdet2 = gelenSorguEkle.Distinct().Count();

                var tahsilatlaKapananSorgu2 = from tbl in gelenSorgu4 select new { tbl.ALACAK_NEDEN_ID, tbl.DEPO_EDILEN_TUTAR, tbl.DEPO_SAYISI };
                int tahsilatlaKapananAdet2 = tahsilatlaKapananSorgu2.Distinct().Where(item => item.DEPO_SAYISI.HasValue).Count();

                var tahsilatlaKapananMiktarSorgu2 = from tbl in tahsilatlaKapananSorgu2 where tbl.DEPO_EDILEN_TUTAR.HasValue select tbl.DEPO_EDILEN_TUTAR;
                decimal tahsilatlaKapananMiktar2;
                if (tahsilatlaKapananMiktarSorgu2.Count() > 0)
                    tahsilatlaKapananMiktar2 = tahsilatlaKapananMiktarSorgu2.Sum(item => item.Value);
                else
                    tahsilatlaKapananMiktar2 = 0;

                var bankayaIadeSorgu = from tbl in gelenSorgu4 select new { tbl.ALACAK_NEDEN_ID, tbl.IADE_MIKTARI, tbl.IADE_SAYISI };
                int bankayaIadeAdet = bankayaIadeSorgu.Distinct().Where(item => item.IADE_SAYISI.HasValue).Count();

                var bankayaIadeMiktarSorgu = from tbl in bankayaIadeSorgu where tbl.IADE_MIKTARI.HasValue select tbl.IADE_MIKTARI;
                decimal bankayaIadeMiktar;
                if (bankayaIadeMiktarSorgu.Count() > 0)
                    bankayaIadeMiktar = bankayaIadeMiktarSorgu.Sum(item => item.Value);
                else
                    bankayaIadeMiktar = 0;

                var tazminEdilenMiktarSorgu = from tbl in gelenSorgu4 where tbl.TAZMIN_MIKTARI.HasValue select tbl.TAZMIN_MIKTARI;
                decimal tazminMiktar;
                if (tazminEdilenMiktarSorgu.Count() > 0)
                    tazminMiktar = tazminEdilenMiktarSorgu.Sum(item => item.Value);
                else
                    tazminMiktar = 0;

                var tazminEdilenAdetSorgu = from tbl in gelenSorgu4 select new { tbl.ALACAK_NEDEN_ID, tbl.TAZMIN_SAYISI };
                int tazminEdilenAdet = tazminEdilenAdetSorgu.Distinct().Where(item => item.TAZMIN_SAYISI.HasValue).Count();

                decimal devirMiktar2 = 0;
                var devirMiktarSorgu2 = from tbl in klasorler2 where tbl.ISLEME_KONAN_TUTAR != null && tbl.TAKIP_TARIHI > result.rest select new { tbl.ISLEME_KONAN_TUTAR, tbl.ALACAK_NEDENI }; ;
                if (devirMiktarSorgu2.Count() > 0)
                    devirMiktar2 = devirMiktarSorgu2.Sum(item => item.ISLEME_KONAN_TUTAR.Value);

                var devirAdetSorgu2 = from tbl in klasorler2 where tbl.TAKIP_TARIHI > result.rest select tbl.ALACAK_NEDEN_ID;
                int devirAdet2 = devirAdetSorgu2.Distinct().Count();

                #region Klasor bazında

                liste2 = new List<KlasorDonemselRaporGayrinakit>();
                KlasorDonemselRaporGayrinakit gayrinakit = new KlasorDonemselRaporGayrinakit();
                gayrinakit.bankayaAdet = bankayaIadeAdet;
                gayrinakit.bankayaMiktar = bankayaIadeMiktar;
                gayrinakit.devirAdet = devirAdet2;
                gayrinakit.devirdenAdet = devirdenGelenAdet2;
                gayrinakit.devirdenMiktar = devirdenGelenToplam2;
                gayrinakit.devirMiktar = devirMiktar2;
                gayrinakit.gelenAdet = gelenAdet2;
                gayrinakit.gelenMiktar = gelenToplam2;
                gayrinakit.tahsilatAdet = tahsilatlaKapananAdet2;
                gayrinakit.tahsilatMiktar = tahsilatlaKapananMiktar2;
                gayrinakit.tazminAdet = tazminEdilenAdet;
                gayrinakit.tazminMiktar = tazminMiktar;

                liste2.Add(gayrinakit);
                gridControl1.DataSource = listeMain;

                #endregion Klasor bazında

                gridControl1.DataSource = listeMain;
                gridControl2.DataSource = liste2;
                if (klasorlerMain.Count() == 0)
                    XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
            }

            #endregion Ticari Krediler Takipli

            #region Bireysel Krediler Takipli

            else if (raporTipi == 3)
            {
                var klasorlerMain = dbV.DONEMSEL_TAKIPLI_ALACAKLAR_RAPORLARs.Where(predi2).Where(vi => !vi.PROJE_ID.HasValue);

                var klasorler = (from tbl in klasorlerMain where !(tbl.DEPO_ALACAGI.HasValue && tbl.DEPO_ALACAGI.Value) select tbl).ToList();

                #region Dovizlileri TL'ye çevirme

                foreach (var tmp in klasorler)
                {
                    AvukatProLib.Hesap.DovizHelper.GetMerkezBankasiBilgisi(tmp.ALACAK_NEDEN_KOD_ID);

                    if (tmp.ISLEME_KONAN_TUTAR.HasValue && tmp.ISLEME_KONAN_TUTAR_DOVIZ_ID.HasValue && tmp.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value > 1)
                        tmp.ISLEME_KONAN_TUTAR = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.ISLEME_KONAN_TUTAR.Value, tmp.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value, DateTime.Today);
                    if (tmp.ODEME_DAGILIM_TUTAR.HasValue && tmp.ODEME_DAGILIM_TUTAR_DOVIZ_ID.HasValue && tmp.ODEME_DAGILIM_TUTAR_DOVIZ_ID.Value > 1)
                        tmp.ODEME_DAGILIM_TUTAR = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.ODEME_DAGILIM_TUTAR.Value, tmp.ODEME_DAGILIM_TUTAR_DOVIZ_ID.Value, DateTime.Today);
                }

                #endregion Dovizlileri TL'ye çevirme

                var devirdenGelen = from tbl in klasorler where tbl.ISLEME_KONAN_TUTAR != null && tbl.TAKIP_TARIHI < result.rdat select new { tbl.ISLEME_KONAN_TUTAR, tbl.ALACAK_NEDENI };

                decimal devirdenGelenToplam;
                if (devirdenGelen.Count() > 0)
                    devirdenGelenToplam = devirdenGelen.Sum(item => item.ISLEME_KONAN_TUTAR.Value);
                else
                    devirdenGelenToplam = 0;

                var devirdenGelenAdetSorgu = from tbl in klasorler where tbl.TAKIP_TARIHI < result.rdat select tbl.FOY_ID;
                int devirdenGelenAdet = devirdenGelenAdetSorgu.Distinct().Count();

                var gelenSorgu = from tbl in klasorler where tbl.ISLEME_KONAN_TUTAR != null && tbl.TAKIP_TARIHI > result.rdat && tbl.TAKIP_TARIHI < result.rest select new { tbl.ISLEME_KONAN_TUTAR, tbl.ALACAK_NEDENI };
                decimal gelenToplam;
                if (gelenSorgu.Count() > 0)
                    gelenToplam = gelenSorgu.Sum(item => item.ISLEME_KONAN_TUTAR.Value);
                else
                    gelenToplam = 0;

                var gelenSorguEklenen = from tbl in klasorler where tbl.TAKIP_TARIHI > result.rdat && tbl.TAKIP_TARIHI < result.rest select tbl;
                int gelenAdet = gelenSorguEklenen.Select(item => item.FOY_ID).Distinct().Count();

                var gelenSorgu2 = from tbl in klasorler where tbl.TAKIP_TARIHI < result.rest select tbl;

                var tahsilatlaKapananSorgu = from tbl in gelenSorgu2 where tbl.DURUM_ID == 6 || tbl.DURUM_ID == 16 select new { tbl.FOY_ID, tbl.ISLEME_KONAN_TUTAR, tbl.ALACAK_NEDENI };
                int tahsilatlaKapananAdet = tahsilatlaKapananSorgu.Distinct().Count();

                var tahsilatlaKapananMiktarSorgu = from tbl in tahsilatlaKapananSorgu where tbl.ISLEME_KONAN_TUTAR.HasValue select tbl.ISLEME_KONAN_TUTAR;
                decimal tahsilatlaKapananMiktar;
                if (tahsilatlaKapananMiktarSorgu.Count() > 0)
                    tahsilatlaKapananMiktar = tahsilatlaKapananMiktarSorgu.Sum(item => item.Value);
                else
                    tahsilatlaKapananMiktar = 0;

                var acizDerkenarSorgu = from tbl in gelenSorgu2 where (tbl.DURUM_ID == 3 || tbl.DURUM_ID == 24 || tbl.DURUM_ID == 29 || tbl.DURUM_ID == 30) select new { tbl.FOY_ID, tbl.ISLEME_KONAN_TUTAR };
                int acizDerkenarAdet = acizDerkenarSorgu.Distinct().Count();

                var acizDerkenarMiktarSorgu = from tbl in acizDerkenarSorgu where tbl.ISLEME_KONAN_TUTAR.HasValue select tbl.ISLEME_KONAN_TUTAR; ;
                decimal acizDerkenarMiktar;
                if (acizDerkenarMiktarSorgu.Count() > 0)
                    acizDerkenarMiktar = acizDerkenarMiktarSorgu.Sum(item => item.Value);
                else
                    acizDerkenarMiktar = 0;

                var tahsilatDagilimiAnaparaSorgu = from tbl in gelenSorgu2 where (tbl.MAHSUP_KATEGORI_ID == 12 || tbl.MAHSUP_KATEGORI_ID == 2) && tbl.ODEME_DAGILIM_TUTAR.HasValue select new { tbl.ODEME_DAGILIM_TUTAR, tbl.ALACAK_NEDENI }; ;
                decimal tdAnapara = 0;
                if (tahsilatDagilimiAnaparaSorgu.Count() > 0)
                    tdAnapara = tahsilatDagilimiAnaparaSorgu.Sum(item => item.ODEME_DAGILIM_TUTAR.Value);
                else
                    tdAnapara = 0;

                var tahsilatDagilimiFaizSorgu = from tbl in gelenSorgu2 where (tbl.MAHSUP_KATEGORI_ID == 17 || tbl.MAHSUP_KATEGORI_ID == 8) && tbl.ODEME_DAGILIM_TUTAR.HasValue select new { tbl.ODEME_DAGILIM_TUTAR, tbl.ALACAK_NEDENI }; ;
                decimal tdFaiz;
                if (tahsilatDagilimiFaizSorgu.Count() > 0)
                    tdFaiz = tahsilatDagilimiFaizSorgu.Sum(item => item.ODEME_DAGILIM_TUTAR.Value);
                else
                    tdFaiz = 0;

                decimal tdMasraf = 0;
                var tahsilatDagilimiMasrafSorgu1 = from tbl in gelenSorgu2 where (tbl.MAHSUP_KATEGORI_ID == 14 || tbl.MAHSUP_KATEGORI_ID == 5 || tbl.MAHSUP_KATEGORI_ID == 18 || tbl.MAHSUP_KATEGORI_ID == 9 || tbl.MAHSUP_KATEGORI_ID == 16 || tbl.MAHSUP_KATEGORI_ID == 7) && tbl.ODEME_DAGILIM_TUTAR.HasValue select new { tbl.ODEME_DAGILIM_TUTAR, tbl.ALACAK_NEDENI }; ;
                if (tahsilatDagilimiMasrafSorgu1.Count() > 0)
                    tdMasraf += tahsilatDagilimiMasrafSorgu1.Sum(item => item.ODEME_DAGILIM_TUTAR.Value);

                decimal devirMiktar = 0;
                var devirMiktarSorgu = from tbl in klasorler where tbl.ISLEME_KONAN_TUTAR.HasValue && tbl.TAKIP_TARIHI > result.rest select new { tbl.ISLEME_KONAN_TUTAR, tbl.ALACAK_NEDENI }; ;
                if (devirMiktarSorgu.Count() > 0)
                    devirMiktar = devirMiktarSorgu.Sum(item => item.ISLEME_KONAN_TUTAR.Value);

                var devirAdetSorgu = from tbl in klasorler where tbl.TAKIP_TARIHI > result.rest select tbl.FOY_ID;
                int devirAdet = devirAdetSorgu.Distinct().Count();

                #region Klasor bazında

                List<KlasorDonemselRaporNakit> listeMain = new List<KlasorDonemselRaporNakit>();
                KlasorDonemselRaporNakit nakitMain = new KlasorDonemselRaporNakit();

                nakitMain.devirdenAdet = devirdenGelenAdet;
                nakitMain.devirdenMiktar = devirdenGelenToplam;
                nakitMain.gelenAdet = gelenAdet;
                nakitMain.gelenMiktar = gelenToplam;
                nakitMain.tahsilatAdet = tahsilatlaKapananAdet;
                nakitMain.tahsilatMiktar = tahsilatlaKapananMiktar;
                nakitMain.acizAdet = acizDerkenarAdet;
                nakitMain.acizMiktar = acizDerkenarMiktar;
                nakitMain.tahsilatDagAnapara = tdAnapara;
                nakitMain.tahsilatDagFaize = tdFaiz;
                nakitMain.tahsilatDagMasraflara = tdMasraf;
                nakitMain.devirAdet = devirAdet;
                nakitMain.devirMiktar = devirMiktar;

                listeMain.Add(nakitMain);
                gridControl1.DataSource = listeMain;

                #endregion Klasor bazında

                var klasorler2 = (from tbl in klasorlerMain where (tbl.DEPO_ALACAGI.HasValue && tbl.DEPO_ALACAGI.Value && !tbl.VADE_TARIHI.HasValue) select tbl).ToList();

                #region Dovizlileri TL'ye çevirme

                foreach (var tmp in klasorler2)
                {
                    AvukatProLib.Hesap.DovizHelper.GetMerkezBankasiBilgisi(tmp.ALACAK_NEDEN_KOD_ID);

                    if (tmp.ISLEME_KONAN_TUTAR.HasValue && tmp.ISLEME_KONAN_TUTAR_DOVIZ_ID.HasValue && tmp.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value > 1)
                        tmp.ISLEME_KONAN_TUTAR = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.ISLEME_KONAN_TUTAR.Value, tmp.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value, DateTime.Today);
                    if (tmp.ODEME_DAGILIM_TUTAR.HasValue && tmp.ODEME_DAGILIM_TUTAR_DOVIZ_ID.HasValue && tmp.ODEME_DAGILIM_TUTAR_DOVIZ_ID.Value > 1)
                        tmp.ODEME_DAGILIM_TUTAR = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.ODEME_DAGILIM_TUTAR.Value, tmp.ODEME_DAGILIM_TUTAR_DOVIZ_ID.Value, DateTime.Today);
                    if (tmp.DEPO_EDILEN_TUTAR_DOVIZ_ID.HasValue && tmp.DEPO_EDILEN_TUTAR_DOVIZ_ID.Value > 1)
                        tmp.DEPO_EDILEN_TUTAR = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.DEPO_EDILEN_TUTAR.Value, tmp.DEPO_EDILEN_TUTAR_DOVIZ_ID.Value, DateTime.Today);
                    if (tmp.IADE_MIKTARI_DOVIZ_ID.HasValue && tmp.IADE_MIKTARI_DOVIZ_ID.Value > 1)
                        tmp.IADE_MIKTARI = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.IADE_MIKTARI.Value, tmp.IADE_MIKTARI_DOVIZ_ID.Value, DateTime.Today);
                    if (tmp.TAZMIN_MIKTAR_DOVIZ_ID.HasValue && tmp.TAZMIN_MIKTAR_DOVIZ_ID.Value > 1)
                        tmp.TAZMIN_MIKTARI = AvukatProLib.Hesap.DovizHelper.CevirYTL(tmp.TAZMIN_MIKTARI.Value, tmp.TAZMIN_MIKTAR_DOVIZ_ID.Value, DateTime.Today);
                }

                #endregion Dovizlileri TL'ye çevirme

                var devirdenGelen2 = from tbl in klasorler2 where (tbl.DEPO_ALACAGI.HasValue && tbl.DEPO_ALACAGI.Value) && tbl.ISLEME_KONAN_TUTAR != null && tbl.TAKIP_TARIHI < result.rdat select tbl.ISLEME_KONAN_TUTAR;

                decimal devirdenGelenToplam2;
                if (devirdenGelen2.Count() > 0)
                    devirdenGelenToplam2 = devirdenGelen2.Sum(item => item.Value);
                else
                    devirdenGelenToplam2 = 0;

                var devirdenGelenAdetSorgu2 = from tbl in klasorler2 where tbl.TAKIP_TARIHI < result.rdat select tbl.ALACAK_NEDEN_ID;
                int devirdenGelenAdet2 = devirdenGelenAdetSorgu2.Distinct().Count();

                var gelenSorguEklenen2 = from tbl in klasorler2 where tbl.ISLEME_KONAN_TUTAR != null && tbl.TAKIP_TARIHI > result.rdat && tbl.TAKIP_TARIHI < result.rest select tbl.ISLEME_KONAN_TUTAR;

                decimal gelenToplam2;
                if (gelenSorguEklenen2.Count() > 0)
                    gelenToplam2 = gelenSorguEklenen2.Sum(item => item.Value);
                else
                    gelenToplam2 = 0;

                var gelenSorgu4 = from tbl in klasorler2 where tbl.TAKIP_TARIHI < result.rest select tbl;

                var gelenSorguEkle = from tbl in klasorler2 where tbl.TAKIP_TARIHI > result.rdat && tbl.TAKIP_TARIHI < result.rest select tbl.ALACAK_NEDEN_ID;
                int gelenAdet2 = gelenSorguEkle.Distinct().Count();

                var tahsilatlaKapananSorgu2 = from tbl in gelenSorgu4 select new { tbl.ALACAK_NEDEN_ID, tbl.DEPO_EDILEN_TUTAR, tbl.DEPO_SAYISI };
                int tahsilatlaKapananAdet2 = tahsilatlaKapananSorgu2.Distinct().Where(vi => vi.DEPO_SAYISI.HasValue).Count();

                var tahsilatlaKapananMiktarSorgu2 = from tbl in tahsilatlaKapananSorgu2 where tbl.DEPO_EDILEN_TUTAR.HasValue select tbl.DEPO_EDILEN_TUTAR;
                decimal tahsilatlaKapananMiktar2;
                if (tahsilatlaKapananMiktarSorgu2.Count() > 0)
                    tahsilatlaKapananMiktar2 = tahsilatlaKapananMiktarSorgu2.Sum(item => item.Value);
                else
                    tahsilatlaKapananMiktar2 = 0;

                var bankayaIadeSorgu = from tbl in gelenSorgu4 select new { tbl.ALACAK_NEDEN_ID, tbl.IADE_MIKTARI, tbl.IADE_SAYISI };
                int bankayaIadeAdet = bankayaIadeSorgu.Distinct().Where(vi => vi.IADE_SAYISI.HasValue).Count();

                var bankayaIadeMiktarSorgu = from tbl in bankayaIadeSorgu where tbl.IADE_MIKTARI.HasValue select tbl.IADE_MIKTARI;
                decimal bankayaIadeMiktar;
                if (bankayaIadeMiktarSorgu.Count() > 0)
                    bankayaIadeMiktar = bankayaIadeMiktarSorgu.Sum(item => item.Value);
                else
                    bankayaIadeMiktar = 0;

                var tazminEdilenMiktarSorgu = from tbl in gelenSorgu4 where tbl.TAZMIN_MIKTARI.HasValue select tbl.TAZMIN_MIKTARI;
                decimal tazminMiktar;
                if (tazminEdilenMiktarSorgu.Count() > 0)
                    tazminMiktar = tazminEdilenMiktarSorgu.Sum(item => item.Value);
                else
                    tazminMiktar = 0;

                var tazminEdilenAdetSorgu = from tbl in gelenSorgu4 select new { tbl.TAZMIN_SAYISI, tbl.TAZMIN_MIKTARI, tbl.ALACAK_NEDEN_ID };
                int tazminEdilenAdet = tazminEdilenAdetSorgu.Distinct().Where(vi => vi.TAZMIN_SAYISI.HasValue).Count();

                decimal devirMiktar2 = 0;
                var devirMiktarSorgu2 = from tbl in klasorler2 where tbl.ISLEME_KONAN_TUTAR != null && tbl.TAKIP_TARIHI > result.rest select new { tbl.ISLEME_KONAN_TUTAR, tbl.ALACAK_NEDENI }; ;
                if (devirMiktarSorgu2.Count() > 0)
                    devirMiktar2 = devirMiktarSorgu2.Sum(item => item.ISLEME_KONAN_TUTAR.Value);

                var devirAdetSorgu2 = from tbl in klasorler2 where tbl.TAKIP_TARIHI > result.rest select tbl.ALACAK_NEDEN_ID;
                int devirAdet2 = devirAdetSorgu2.Distinct().Count();

                #region Klasor bazında

                liste2 = new List<KlasorDonemselRaporGayrinakit>();
                KlasorDonemselRaporGayrinakit gayrinakit = new KlasorDonemselRaporGayrinakit();
                gayrinakit.bankayaAdet = bankayaIadeAdet;
                gayrinakit.bankayaMiktar = bankayaIadeMiktar;
                gayrinakit.devirAdet = devirAdet2;
                gayrinakit.devirdenAdet = devirdenGelenAdet2;
                gayrinakit.devirdenMiktar = devirdenGelenToplam2;
                gayrinakit.devirMiktar = devirMiktar2;
                gayrinakit.gelenAdet = gelenAdet2;
                gayrinakit.gelenMiktar = gelenToplam2;
                gayrinakit.tahsilatAdet = tahsilatlaKapananAdet2;
                gayrinakit.tahsilatMiktar = tahsilatlaKapananMiktar2;
                gayrinakit.tazminAdet = tazminEdilenAdet;
                gayrinakit.tazminMiktar = tazminMiktar;

                liste2.Add(gayrinakit);
                gridControl1.DataSource = listeMain;

                #endregion Klasor bazında

                gridControl1.DataSource = listeMain;
                gridControl2.DataSource = liste2;
                if (klasorlerMain.Count() == 0)
                    XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır.");
            }

            #endregion Bireysel Krediler Takipli

            else
            {
                //Su anlık baska donemsel rapor yok
            }

            #region Filtre Bilgileri

            filtreler = new List<FiltreBilgileri>();
            filtreler.Add(new FiltreBilgileri("Risklerin Devir Alındığı Tarih", result.rdat.ToShortDateString()));
            filtreler.Add(new FiltreBilgileri("Rapora Esas Son Tarih", result.rest.ToShortDateString()));
            filtreler.Add(new FiltreBilgileri("Hukuk Bölüm Kriterleri", result.HukukBolumKriterleri));
            filtreler.Add(new FiltreBilgileri("Avukat Bilgileri", result.AvukatKriterleri));
            filtreler.Add(new FiltreBilgileri("Kredi Bilgileri", result.KrediKriterleri));
            filtreler.Add(new FiltreBilgileri("Sube Bilgileri", result.SubeKriterleri));
            filtreler.Add(new FiltreBilgileri("Takip Bilgileri", result.TakipKriterleri));
            gridControl3.DataSource = filtreler;
            bandedGridView4.OptionsView.ColumnAutoWidth = false;
            bandedGridView4.OptionsView.RowAutoHeight = true;

            #endregion Filtre Bilgileri
        }

        private void frmDonemselRaporSihirbaz_Load(object sender, EventArgs e)
        {
            formSize = this.Size;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxControl5.Items.Clear();
            listBoxControl6.Items.Clear();
            listBoxControl5.Enabled = true;
            labelControl17.Visible = false;
            lookUpEdit1.Visible = false;

            simpleButton34.Visible = false;

            if (radioGroup1.SelectedIndex == 0)
            {
                if (kadroluAvukatlar == null)
                    kadroluAvukatlar = from tbl in dbV.per_AV001_TDI_BIL_CARIs where tbl.AVUKAT_MI && tbl.PERSONEL_MI orderby tbl.AD select new AvukatIDCariAD { ID = tbl.ID, Ad = tbl.AD };

                foreach (AvukatIDCariAD tmp in kadroluAvukatlar)
                {
                    listBoxControl5.Items.Add(tmp.Ad);
                }
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                if (sozlesmeliAvukatlar == null)
                    sozlesmeliAvukatlar = from tbl in dbV.per_AV001_TDI_BIL_CARIs where tbl.AVUKAT_MI && tbl.KURUM_AVUKATI_MI orderby tbl.AD select new AvukatIDCariAD { ID = tbl.ID, Ad = tbl.AD };
                foreach (AvukatIDCariAD tmp in sozlesmeliAvukatlar)
                {
                    listBoxControl5.Items.Add(tmp.Ad);
                }
            }
            else if (radioGroup1.SelectedIndex == 2)
            {
                if (kadroluAvukatlar == null)
                    kadroluAvukatlar = from tbl in dbV.per_AV001_TDI_BIL_CARIs where tbl.AVUKAT_MI && tbl.PERSONEL_MI orderby tbl.AD select new AvukatIDCariAD { ID = tbl.ID, Ad = tbl.AD };

                foreach (AvukatIDCariAD tmp in kadroluAvukatlar)
                {
                    listBoxControl5.Items.Add(tmp.Ad);
                }
                if (sozlesmeliAvukatlar == null)
                    sozlesmeliAvukatlar = from tbl in dbV.per_AV001_TDI_BIL_CARIs where tbl.AVUKAT_MI && tbl.KURUM_AVUKATI_MI orderby tbl.AD select new AvukatIDCariAD { ID = tbl.ID, Ad = tbl.AD };
                foreach (AvukatIDCariAD tmp in sozlesmeliAvukatlar)
                {
                    listBoxControl5.Items.Add(tmp.Ad);
                }
            }
            else if (radioGroup1.SelectedIndex == 3)
            {
                listBoxControl5.Enabled = false;
                labelControl17.Visible = true;
                lookUpEdit1.Visible = true;
                simpleButton34.Visible = true;

                if (tumAvukatlar == null)
                    tumAvukatlar = from tbl in dbV.per_AV001_TDI_BIL_CARIs where tbl.AVUKAT_MI == true && (tbl.PERSONEL_MI || tbl.KURUM_AVUKATI_MI) orderby tbl.AD select new AvukatIDCariAD { ID = tbl.ID, Ad = tbl.AD };
                if (lookUpEdit1.Properties.DataSource == null)
                {
                    lookUpEdit1.Properties.DataSource = tumAvukatlar;
                    lookUpEdit1.Properties.DisplayMember = "Ad";
                    lookUpEdit1.Properties.ValueMember = "ID";
                }
            }
            else
            { }
            listBoxControl5.SelectedIndex = -1;
        }

        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup2.SelectedIndex == 0) //Türkçe
            {
                foreach (FiltreBilgileri tmp in filtreler)
                {
                    switch (tmp.FiltreAdi)
                    {
                        case "Brought Date of Risks":
                            tmp.FiltreAdi = "Risklerin Devir Alındığı Tarih"; break;
                        case "End Date of the Report":
                            tmp.FiltreAdi = "Rapora Esas Son Tarih"; break;
                        case "Segments":
                            tmp.FiltreAdi = "Hukuk Bölüm Kriterleri"; break;
                        case "Lawyers":
                            tmp.FiltreAdi = "Avukat Bilgileri"; break;
                        case "Credit Types":
                            tmp.FiltreAdi = "Kredi Bilgileri"; break;
                        case "Branches":
                            tmp.FiltreAdi = "Sube Bilgileri"; break;
                        case "Execution Ways":
                            tmp.FiltreAdi = "Takip Bilgileri"; break;
                    }
                    if (tmp.FiltreKriterleri == "All")
                        tmp.FiltreKriterleri = "Tümü";
                }

                Baslik.Caption = "Nakit";
                Baslik2.Caption = "Gayrinakit";
                gridBand7.Caption = "Rapor Filtre Bilgileri";
                FiltreAdi.Caption = "Filtre Adı";
                FiltreKriterleri.Caption = "Filtre Kriterleri";
                string rdt = result.rdat.ToShortDateString();
                string rst = result.rest.ToShortDateString();
                wizardPage4.Text = "Tebrikler! " + rdt + " - " + rst + " için dönemsel rapor çıktınız hazırlanmıştır.";
                DevirdenGelen.Caption = "<-- " + rdt + "\n Devirden Gelen";
                gelen.Caption = rdt + " - " + rst + " \nGelen";
                TahsilatlaKapanan.Caption = "<-- " + rst + " \nTahsilatla Kapanan";
                AcizDerkenar.Caption = "<-- " + rst + " \nAciz / Derkenarla Kapanan";
                TahsilatDagilimi.Caption = "<-- " + rst + " \nTahsilat Dağılımı";
                Devir.Caption = rst + " -->\nDevir";
                gridBand1.Caption = "<-- " + rdt + "\n Devirden Gelen";
                gridBand2.Caption = rdt + " - " + rst + " \n Gelen";
                gridBand3.Caption = "<-- " + rst + " \n Depo Edilen";
                gridBand4.Caption = "<-- " + rst + " \n Bankaya İade Edilen";
                gridBand5.Caption = "<-- " + rst + " \n Tazmin Edilen";
                gridBand6.Caption = rst + " -->\n Devir";
                DevirdenAdet.Caption = "Adet";
                DevirdenAdet2.Caption = "Adet";
                GelenAdet.Caption = "Adet";
                DevirdenMiktar.Caption = "Miktar";
                DevirdenMiktar2.Caption = "Miktar";
                GelenMiktar2.Caption = "Miktar";
                GelenMiktar.Caption = "Miktar";
                AcizAdet.Caption = "Adet";
                AcizMiktar.Caption = "Miktar";
                TahsilatAdet.Caption = "Adet";
                TahsilatAdet2.Caption = "Adet";
                TahsilatMiktar.Caption = "Miktar";
                TahsilatMiktar2.Caption = "Miktar";
                tdAnapara.Caption = "Anaparaya";
                tdFaiz.Caption = "Faize";
                tdMasraf.Caption = "Masraflara";
                DevirAdet.Caption = "Adet";
                DevirMiktar.Caption = "Miktar";
                DevirAdet2.Caption = "Adet";
                DevirMiktar2.Caption = "Miktar";
                BankayaIadeAdet.Caption = "Adet";
                BankayaIadeMiktar.Caption = "Miktar";
                TazminEdilenAdet.Caption = "Adet";
                TazminEdilenMiktar.Caption = "Miktar";
                GelenAdet2.Caption = "Adet";
            }
            else if (radioGroup2.SelectedIndex == 1) //İngilizce
            {
                foreach (FiltreBilgileri tmp in filtreler)
                {
                    switch (tmp.FiltreAdi)
                    {
                        case "Risklerin Devir Alındığı Tarih":
                            tmp.FiltreAdi = "Brought Date of Risks"; break;
                        case "Rapora Esas Son Tarih":
                            tmp.FiltreAdi = "End Date of the Report"; break;
                        case "Hukuk Bölüm Kriterleri":
                            tmp.FiltreAdi = "Segments"; break;
                        case "Avukat Bilgileri":
                            tmp.FiltreAdi = "Lawyers"; break;
                        case "Kredi Bilgileri":
                            tmp.FiltreAdi = "Credit Types"; break;
                        case "Sube Bilgileri":
                            tmp.FiltreAdi = "Branches"; break;
                        case "Takip Bilgileri":
                            tmp.FiltreAdi = "Execution Ways"; break;
                    }
                    if (tmp.FiltreKriterleri == "Tümü")
                        tmp.FiltreKriterleri = "All";
                }

                Baslik.Caption = "Cash";
                Baslik2.Caption = "Non-Cash";
                gridBand7.Caption = "Report Filters";
                FiltreAdi.Caption = "Filter Name";
                FiltreKriterleri.Caption = "Filter Criterias";
                string rdt = result.rdat.ToShortDateString();
                string rst = result.rest.ToShortDateString();
                wizardPage4.Text = "Congrulations! " + rdt + " - " + rst + " your report is ready below.";
                DevirdenGelen.Caption = "<-- " + rdt + "\n Brought Forward";
                gelen.Caption = rdt + " - " + rst + " \n Received";
                TahsilatlaKapanan.Caption = "<-- " + rst + " \nClosed due to collection";
                AcizDerkenar.Caption = "<-- " + rst + " \nClosed due to Insolvency Certificate/or similar certification";
                TahsilatDagilimi.Caption = "<-- " + rst + " \nDistribution of Collection";
                Devir.Caption = rst + " -->\nTransfer to";
                gridBand1.Caption = "<-- " + rdt + "\n Brought Forward";
                gridBand2.Caption = rdt + " - " + rst + " \n Received";
                gridBand3.Caption = "<-- " + rst + " \nClosed due to collection (Deposited to the Account)";
                gridBand4.Caption = "<-- " + rst + " \nReturned to the Bank";
                gridBand5.Caption = "<-- " + rst + " \nBecome Cash due to indemnificaiton";
                gridBand6.Caption = rst + " -->\nTransfer to";
                DevirdenAdet.Caption = "Qty";
                DevirdenAdet2.Caption = "Qty";
                GelenAdet.Caption = "Qty";
                GelenAdet2.Caption = "Qty";
                DevirdenMiktar.Caption = "Amount";
                DevirdenMiktar2.Caption = "Amount";
                GelenMiktar2.Caption = "Amount";
                GelenMiktar.Caption = "Amount";
                AcizAdet.Caption = "Qty";
                AcizMiktar.Caption = "Amount";
                TahsilatAdet.Caption = "Qty";
                TahsilatAdet2.Caption = "Qty";
                TahsilatMiktar.Caption = "Amount";
                TahsilatMiktar2.Caption = "Amount";
                tdAnapara.Caption = "As Principal Amount";
                tdFaiz.Caption = "As Interest";
                tdMasraf.Caption = "As Expenses";
                DevirAdet.Caption = "Qty";
                DevirMiktar.Caption = "Amount";
                DevirAdet2.Caption = "Qty";
                DevirMiktar2.Caption = "Amount";
                BankayaIadeAdet.Caption = "Qty";
                BankayaIadeMiktar.Caption = "Amount";
                TazminEdilenAdet.Caption = "Qty";
                TazminEdilenMiktar.Caption = "Amount";
            }
            else
            {
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (listBoxControl1.SelectedItems != null)
            {
                foreach (object tmp in listBoxControl1.SelectedItems)
                {
                    listBoxControl2.Items.Add(tmp);
                }

                int k;

                for (int i = listBoxControl1.SelectedItems.Count; i > 0; i--)
                {
                    k = listBoxControl1.SelectedIndices[i - 1];
                    listBoxControl1.Items.RemoveAt(k);
                }
                if (listBoxControl2.ItemCount > 0)
                    wizardPage1.AllowNext = true;
                else
                    wizardPage1.AllowNext = false;
            }
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            if (listBoxControl5.Items.Count != 0)
            {
                foreach (object tmp in listBoxControl5.Items)
                {
                    listBoxControl6.Items.Add(tmp);
                }

                listBoxControl5.Items.Clear();
            }
            if (listBoxControl6.ItemCount > 0)
                wizardPage3.AllowNext = true;
            else
                wizardPage3.AllowNext = false;
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            if (listBoxControl6.SelectedItems != null)
            {
                foreach (object tmp in listBoxControl6.SelectedItems)
                {
                    listBoxControl5.Items.Add(tmp);
                }

                int k;

                for (int i = listBoxControl6.SelectedItems.Count; i > 0; i--)
                {
                    k = listBoxControl6.SelectedIndices[i - 1];
                    listBoxControl6.Items.RemoveAt(k);
                }
                if (listBoxControl6.ItemCount > 0)
                    wizardPage3.AllowNext = true;
                else
                    wizardPage3.AllowNext = false;
            }
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            if (listBoxControl5.SelectedItems != null)
            {
                foreach (object tmp in listBoxControl5.SelectedItems)
                {
                    listBoxControl6.Items.Add(tmp);
                }

                int k;

                for (int i = listBoxControl5.SelectedItems.Count; i > 0; i--)
                {
                    k = listBoxControl5.SelectedIndices[i - 1];
                    listBoxControl5.Items.RemoveAt(k);
                }
                if (listBoxControl6.ItemCount > 0)
                    wizardPage3.AllowNext = true;
                else
                    wizardPage3.AllowNext = false;
            }
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            if (listBoxControl12.Items.Count != 0)
            {
                foreach (object tmp in listBoxControl12.Items)
                {
                    listBoxControl11.Items.Add(tmp);
                }

                listBoxControl12.Items.Clear();
                if (listBoxControl12.ItemCount > 0)
                    wizardPage6.AllowNext = true;
                else
                    wizardPage6.AllowNext = false;
            }
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            if (listBoxControl11.Items.Count != 0)
            {
                foreach (object tmp in listBoxControl11.Items)
                {
                    listBoxControl12.Items.Add(tmp);
                }

                listBoxControl11.Items.Clear();
                if (listBoxControl12.ItemCount > 0)
                    wizardPage6.AllowNext = true;
                else
                    wizardPage6.AllowNext = false;
            }
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            if (listBoxControl12.SelectedItems != null)
            {
                foreach (object tmp in listBoxControl12.SelectedItems)
                {
                    listBoxControl11.Items.Add(tmp);
                }

                int k;

                for (int i = listBoxControl12.SelectedItems.Count; i > 0; i--)
                {
                    k = listBoxControl12.SelectedIndices[i - 1];
                    listBoxControl12.Items.RemoveAt(k);
                }
                if (listBoxControl12.ItemCount > 0)
                    wizardPage6.AllowNext = true;
                else
                    wizardPage6.AllowNext = false;
            }
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            if (listBoxControl11.SelectedItems != null)
            {
                foreach (object tmp in listBoxControl11.SelectedItems)
                {
                    listBoxControl12.Items.Add(tmp);
                }

                int k;

                for (int i = listBoxControl11.SelectedItems.Count; i > 0; i--)
                {
                    k = listBoxControl11.SelectedIndices[i - 1];
                    listBoxControl11.Items.RemoveAt(k);
                }
                if (listBoxControl12.ItemCount > 0)
                    wizardPage6.AllowNext = true;
                else
                    wizardPage6.AllowNext = false;
            }
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            if (listBoxControl14.Items.Count != 0)
            {
                foreach (object tmp in listBoxControl14.Items)
                {
                    listBoxControl13.Items.Add(tmp);
                }

                listBoxControl14.Items.Clear();

                if (listBoxControl14.ItemCount > 0)
                    wizardPage8.AllowNext = true;
                else
                    wizardPage8.AllowNext = false;
            }
        }

        private void simpleButton18_Click(object sender, EventArgs e)
        {
            if (listBoxControl13.Items.Count != 0)
            {
                foreach (object tmp in listBoxControl13.Items)
                {
                    listBoxControl14.Items.Add(tmp);
                }

                listBoxControl13.Items.Clear();

                if (listBoxControl14.ItemCount > 0)
                    wizardPage8.AllowNext = true;
                else
                    wizardPage8.AllowNext = false;
            }
        }

        private void simpleButton19_Click(object sender, EventArgs e)
        {
            if (listBoxControl14.SelectedItems != null)
            {
                foreach (object tmp in listBoxControl14.SelectedItems)
                {
                    listBoxControl13.Items.Add(tmp);
                }

                int k;

                for (int i = listBoxControl14.SelectedItems.Count; i > 0; i--)
                {
                    k = listBoxControl14.SelectedIndices[i - 1];
                    listBoxControl14.Items.RemoveAt(k);
                }
                if (listBoxControl14.ItemCount > 0)
                    wizardPage8.AllowNext = true;
                else
                    wizardPage8.AllowNext = false;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (listBoxControl2.SelectedItems != null)
            {
                foreach (object tmp in listBoxControl2.SelectedItems)
                {
                    listBoxControl1.Items.Add(tmp);
                }

                int k;

                for (int i = listBoxControl2.SelectedItems.Count; i > 0; i--)
                {
                    k = listBoxControl2.SelectedIndices[i - 1];
                    listBoxControl2.Items.RemoveAt(k);
                }
                if (listBoxControl2.ItemCount > 0)
                    wizardPage1.AllowNext = true;
                else
                    wizardPage1.AllowNext = false;
            }
        }

        private void simpleButton20_Click(object sender, EventArgs e)
        {
            if (listBoxControl13.SelectedItems != null)
            {
                foreach (object tmp in listBoxControl13.SelectedItems)
                {
                    listBoxControl14.Items.Add(tmp);
                }

                int k;

                for (int i = listBoxControl13.SelectedItems.Count; i > 0; i--)
                {
                    k = listBoxControl13.SelectedIndices[i - 1];
                    listBoxControl13.Items.RemoveAt(k);
                }
                if (listBoxControl14.ItemCount > 0)
                    wizardPage8.AllowNext = true;
                else
                    wizardPage8.AllowNext = false;
            }
        }

        private void simpleButton21_Click(object sender, EventArgs e)
        {
            if (listBoxControl16.Items.Count != 0)
            {
                foreach (object tmp in listBoxControl16.Items)
                {
                    listBoxControl15.Items.Add(tmp);
                }

                listBoxControl16.Items.Clear();
                if (listBoxControl16.ItemCount > 0)
                    wizardPage9.AllowNext = true;
                else
                    wizardPage9.AllowNext = false;
            }
        }

        private void simpleButton22_Click(object sender, EventArgs e)
        {
            if (listBoxControl15.Items.Count != 0)
            {
                foreach (object tmp in listBoxControl15.Items)
                {
                    listBoxControl16.Items.Add(tmp);
                }

                listBoxControl15.Items.Clear();
                if (listBoxControl16.ItemCount > 0)
                    wizardPage9.AllowNext = true;
                else
                    wizardPage9.AllowNext = false;
            }
        }

        private void simpleButton23_Click(object sender, EventArgs e)
        {
            if (listBoxControl16.SelectedItems != null)
            {
                foreach (object tmp in listBoxControl16.SelectedItems)
                {
                    listBoxControl15.Items.Add(tmp);
                }

                int k;

                for (int i = listBoxControl16.SelectedItems.Count; i > 0; i--)
                {
                    k = listBoxControl16.SelectedIndices[i - 1];
                    listBoxControl16.Items.RemoveAt(k);
                }
                if (listBoxControl16.ItemCount > 0)
                    wizardPage9.AllowNext = true;
                else
                    wizardPage9.AllowNext = false;
            }
        }

        private void simpleButton24_Click(object sender, EventArgs e)
        {
            if (listBoxControl15.SelectedItems != null)
            {
                foreach (object tmp in listBoxControl15.SelectedItems)
                {
                    listBoxControl16.Items.Add(tmp);
                }

                int k;

                for (int i = listBoxControl15.SelectedItems.Count; i > 0; i--)
                {
                    k = listBoxControl15.SelectedIndices[i - 1];
                    listBoxControl15.Items.RemoveAt(k);
                }

                if (listBoxControl16.ItemCount > 0)
                    wizardPage9.AllowNext = true;
                else
                    wizardPage9.AllowNext = false;
            }
        }

        private void simpleButton29_Click(object sender, EventArgs e)
        {
            ExportIt(0);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (listBoxControl1.Items.Count != 0)
            {
                foreach (object tmp in listBoxControl1.Items)
                {
                    listBoxControl2.Items.Add(tmp);
                }

                listBoxControl1.Items.Clear();
            }
            if (listBoxControl2.ItemCount > 0)
                wizardPage1.AllowNext = true;
            else
                wizardPage1.AllowNext = false;
        }

        private void simpleButton30_Click(object sender, EventArgs e)
        {
            ExportIt(1);
        }

        private void simpleButton31_Click(object sender, EventArgs e)
        {
            ExportIt(3);
        }

        private void simpleButton32_Click(object sender, EventArgs e)
        {
            ExportIt(2);
        }

        private void simpleButton34_Click(object sender, EventArgs e)
        {
            if (!listBoxControl6.Items.Contains(lookUpEdit1.Text))
            {
                listBoxControl6.Items.Add(lookUpEdit1.Text);
                wizardPage3.AllowNext = true;
            }
        }

        private void simpleButton35_Click(object sender, EventArgs e)
        {
            if (!listBoxControl12.Items.Contains(lookUpEdit2.Text))
            {
                listBoxControl12.Items.Add(lookUpEdit2.Text);
                wizardPage6.AllowNext = true;
            }
            if (listBoxControl11.Items.Contains(lookUpEdit2.Text))
            {
                listBoxControl11.Items.Remove(lookUpEdit2.Text);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (listBoxControl2.Items.Count != 0)
            {
                foreach (object tmp in listBoxControl2.Items)
                {
                    listBoxControl1.Items.Add(tmp);
                }

                listBoxControl2.Items.Clear();
            }
            if (listBoxControl2.ItemCount > 0)
                wizardPage1.AllowNext = true;
            else
                wizardPage1.AllowNext = false;
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (listBoxControl6.Items.Count != 0)
            {
                foreach (object tmp in listBoxControl6.Items)
                {
                    listBoxControl5.Items.Add(tmp);
                }

                listBoxControl6.Items.Clear();
                if (listBoxControl6.ItemCount > 0)
                    wizardPage3.AllowNext = true;
                else
                    wizardPage3.AllowNext = false;
            }
        }

        private void wizardControl1_Click(object sender, EventArgs e)
        {
        }

        private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            result = new DonemselRaporResult();
            foreach (string tmp in listBoxControl2.Items)
                result.HukukBolumleri.Add(tmp);
            foreach (string tmp in listBoxControl6.Items)
                result.Avukatlar.Add(tmp);
            foreach (string tmp in listBoxControl12.Items)
                result.Subeler.Add(tmp);
            foreach (string tmp in listBoxControl14.Items)
                result.KrediRaporlari.Add(tmp);
            foreach (string tmp in listBoxControl16.Items)
                result.TakipRaporlari.Add(tmp);
            result.rdat = dateNavigator1.DateTime;
            result.rest = dateNavigator2.DateTime;

            frm.Close();
        }

        private void wizardControl1_PrevClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (e.Page == wizardPage4)
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = formSize;
            }
        }

        private void wizardControl1_SelectedPageChanged(object sender, WizardPageChangedEventArgs e)
        {
            if (e.Page == wizardPage1 && raporTipi != 1)
            {
                wizardControl1.SelectedPage = wizardPage9;
                return;
            }
            else if (e.PrevPage == wizardPage1 && e.Page == wizardPage9 && raporTipi == 1)
            {
                wizardControl1.SelectedPage = wizardPage8;
                return;
            }
            else if (e.PrevPage == wizardPage8 && e.Page == wizardPage9 && raporTipi == 1)
            {
                wizardControl1.SelectedPage = wizardPage1;
                return;
            }
            else
            { }

            #region page change

            #region Hukuk Bolumu Seçimi

            if (e.PrevPage == welcomeWP && e.Page == wizardPage1)
            {
                if (bos)
                {
                    if (raporTipi == 1)
                    {
                        if (hukukBolumleri == null)
                            hukukBolumleri = from tbl in dbV.per_TDIE_KOD_PROJE_TIPs select new HukukBolumu { ID = tbl.ID, HukukBolum = tbl.TIP };
                        foreach (HukukBolumu tmp in hukukBolumleri)
                        {
                            listBoxControl1.Items.Add(tmp.HukukBolum);
                        }
                        listBoxControl1.SelectedIndex = -1;
                    }
                    else { }
                }
            }

            #endregion Hukuk Bolumu Seçimi

            #region Subelerin Secimi

            if (e.PrevPage == wizardPage3 && e.Page == wizardPage6)
            {
                if (bos)
                {
                    if (subeler == null && (raporTipi == 1 || raporTipi == 2))
                        subeler = from tbl in dbV.per_TDIE_KOD_PROJE_OZEL_KODs where tbl.OZEL_KOD != "" orderby tbl.OZEL_KOD select new SubeIDAD { ID = tbl.ID, SubeAdi = tbl.OZEL_KOD };
                    if (subeler == null && raporTipi == 3)
                        subeler = from tbl in dbV.per_TDI_KOD_BANKA_SUBEs where tbl.BANKA_ID == 28 orderby tbl.SUBE select new SubeIDAD { SubeAdi = tbl.SUBE };
                    if (lookUpEdit2.Properties.DataSource == null)
                    {
                        lookUpEdit2.Properties.DataSource = subeler;
                        lookUpEdit2.Properties.DisplayMember = "SubeAdi";
                        lookUpEdit2.Properties.ValueMember = "ID";
                    }
                    foreach (SubeIDAD tmp in subeler)
                    {
                        listBoxControl11.Items.Add(tmp.SubeAdi);
                    }
                    listBoxControl11.SelectedIndex = -1;
                }
            }

            #endregion Subelerin Secimi

            #region Kredi Tipleri

            if ((e.PrevPage == wizardPage1 || e.PrevPage == wizardPage9) && e.Page == wizardPage8)
            {
                if (bos)
                {
                    if (alacakNedenleri == null)
                    {
                        alacakNedenleri = (from tbl in dbV.per_TI_KOD_ALACAK_NEDENs select new AlacakNeden { AlacakNedeni = tbl.ALACAK_NEDENI }).Distinct();
                    }
                    foreach (AlacakNeden tmp in alacakNedenleri)
                    {
                        listBoxControl13.Items.Add(tmp.AlacakNedeni);
                    }
                    listBoxControl13.SelectedIndex = -1;
                }
            }

            #endregion Kredi Tipleri

            #region Takip Yolları

            if (e.PrevPage == wizardPage1 && e.Page == wizardPage9)
            {
                if (raporTipi == 1)
                {
                    wizardControl1.SelectedPage = wizardPage8;
                }
                else if (raporTipi == 2 || raporTipi == 3)
                {
                    if (bos)
                    {
                        if (takipYollari == null)
                            takipYollari = (from tbl in dbV.per_TI_KOD_TAKIP_YOLUs select new TakipYolu { ID = tbl.ID, TakipYol = tbl.TAKIP_YOLU });
                        foreach (TakipYolu tmp in takipYollari)
                        {
                            listBoxControl15.Items.Add(tmp.TakipYol);
                        }
                        listBoxControl15.SelectedIndex = -1;
                    }
                }
                else { }
            }

            #endregion Takip Yolları

            else if (e.PrevPage == wizardPage7 && e.Page == wizardPage4)
            {
                bos = false;
                wizardPage4.AllowNext = false;
                result = new DonemselRaporResult();

                if (listBoxControl1.Items.Count == 0)
                {
                    result.HukukGenel = true;
                }

                if (listBoxControl5.Items.Count == 0 && radioGroup1.SelectedIndex != 3)
                {
                    result.AvukatlarGenel = radioGroup1.SelectedIndex;
                }
                if (listBoxControl11.Items.Count == 0)
                {
                    result.SubelerGenel = true;
                }
                if (listBoxControl13.Items.Count == 0)
                {
                    result.KrediRaporlariGenel = true;
                }
                if (listBoxControl15.Items.Count == 0)
                {
                    result.TakipRaporlariGenel = true;
                }

                foreach (string tmp in listBoxControl2.Items)
                    result.HukukBolumleri.Add(tmp);

                foreach (string tmp in listBoxControl6.Items)
                {
                    result.Avukatlar.Add(tmp);
                }
                foreach (string tmp in listBoxControl12.Items)
                    result.Subeler.Add(tmp);
                foreach (string tmp in listBoxControl14.Items)
                    result.KrediRaporlari.Add(tmp);
                foreach (string tmp in listBoxControl16.Items)
                    result.TakipRaporlari.Add(tmp);
                result.rdat = dateNavigator1.DateTime;
                result.rest = dateNavigator2.DateTime;
                result.RaporTuru = raporTipi;

                string rdt = result.rdat.ToShortDateString();
                string rst = result.rest.ToShortDateString();
                wizardPage4.Text = "Tebrikler! " + rdt + " - " + rst + " için dönemsel rapor çıktınız hazırlanmıştır.";

                DevirdenGelen.Caption = "<-- " + rdt + "\n Devirden Gelen";
                gelen.Caption = rdt + " - " + rst + " \nGelen";
                TahsilatlaKapanan.Caption = "<-- " + rst + " \nTahsilatla Kapanan";
                AcizDerkenar.Caption = "<-- " + rst + " \nAciz / Derkenarla Kapanan";
                TahsilatDagilimi.Caption = "<-- " + rst + " \nTahsilat Dağılımı";
                Devir.Caption = rst + " -->\nDevir";
                gridBand1.Caption = "<-- " + rdt + "\n Devirden Gelen";
                gridBand2.Caption = rdt + " - " + rst + " \n Gelen";
                gridBand3.Caption = "<-- " + rst + " \n Depo Edilen";
                gridBand4.Caption = "<-- " + rst + " \n Bankaya İade Edilen";
                gridBand5.Caption = "<-- " + rst + " \n Tazmin Edilen";
                gridBand6.Caption = rst + " -->\n Devir";

                DevreRaporlari();

                this.WindowState = FormWindowState.Maximized;
                this.MinimizeBox = true;
                this.MaximizeBox = true;
            }

            else { }

            #endregion page change
        }

        private void wizardControl1_SelectedPageChanging(object sender, DevExpress.XtraWizard.WizardPageChangingEventArgs e)
        {
        }

        private void wizardPage7_Click(object sender, EventArgs e)
        {
        }

        public class FiltreBilgileri
        {
            public FiltreBilgileri(string ad, string kriterler)
            {
                FiltreAdi = ad;
                FiltreKriterleri = kriterler;
            }

            public string FiltreAdi { set; get; }

            public string FiltreKriterleri { set; get; }
        }
    }
}