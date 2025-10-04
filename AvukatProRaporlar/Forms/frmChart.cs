using AvukatProRaporlar.Lib;
using AvukatProRaporlar.RaporSource;
using AvukatProRaporlar.Raport.Util;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using RaporDataSource.TableDB;
using RaporDataSource.ViewDB;

//using RaporDataSources;
using ReportPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

//using AdimAdimDavaKaydi.Util;

namespace AvukatProRaporlar.Forms
{
    public static class PieExplodingHelper
    {
        public const string All = "All";
        public const string Custom = "Custom";
        public const string MaxValue = "Max Value";
        public const string MinValue = "Min Value";
        public const string None = "None";

        public static void ApplyMode(PieSeriesViewBase view, string mode)
        {
            switch (mode)
            {
                case Custom:
                    break;

                case None:
                    view.ExplodeMode = PieExplodeMode.None;
                    break;

                case All:
                    view.ExplodeMode = PieExplodeMode.All;
                    break;

                case MinValue:
                    view.ExplodeMode = PieExplodeMode.MinValue;
                    break;

                case MaxValue:
                    view.ExplodeMode = PieExplodeMode.MaxValue;
                    break;

                default:
                    ApplyFilterMode(view, mode);
                    break;
            }
        }

        public static List<string> CreateModeList(SeriesPointCollection points, bool supportCustom)
        {
            List<string> list = new List<string>();
            list.Add(None);
            list.Add(All);
            list.Add(MinValue);
            list.Add(MaxValue);
            foreach (SeriesPoint point in points)
                list.Add(point.Argument);
            if (supportCustom)
                list.Add(Custom);
            return list;
        }

        private static void ApplyFilterMode(PieSeriesViewBase view, string mode)
        {
            view.ExplodedPointsFilters.Clear();
            view.ExplodedPointsFilters.Add(CreateFilter(mode));
            view.ExplodeMode = PieExplodeMode.UseFilters;
        }

        private static SeriesPointFilter CreateFilter(string mode)
        {
            return new SeriesPointFilter(SeriesPointKey.Argument, DataFilterCondition.Equal, mode);
        }

        //public object DenemeRaporu()
        //{
        //    DBDataContext db = new DBDataContext();

        // db.AV001_TI_BIL_FOYs.Select(vi => new { FaizeYapilanTahsilat =
        // paraTopla(vi.AV001_TI_BIL_ODEME_DAGILIMs.Where(vii=>vii.MAHSUP_ALT_KATEGORI_ID ==
        // 3).Select(viiii=>new ParaVeDoviz { Tutar= viiii.TUTAR, Birim= viiii.TUTAR_DOVIZ_ID })),

        // });
        //}

        //private object paraTopla(IEnumerable<ParaVeDoviz> coll)
        //{
        //    var gruplar = coll.GroupBy(vi => vi.Birim);

        // if (gruplar.Count > 1) { foreach (var teki in gruplar) { } }

        //}
    }

    public partial class frmChart : XtraForm, iAVPForms
    {
        #region iAVPForms Members

        public void ExportDoc()
        {
        }

        public void ExportMail()
        {
            SaveFileTools.Exporter(chartControl1, Enums.KayitTipi.Html);
        }

        public void ExportPDF()
        {
            SaveFileTools.Exporter(chartControl1, Enums.KayitTipi.Pdf);
        }

        public void ExportPrint()
        {
            SaveFileTools.Exporter(chartControl1, Enums.KayitTipi.Print);
        }

        public void ExportXls()
        {
            SaveFileTools.Exporter(chartControl1, Enums.KayitTipi.Excel);
        }

        #endregion iAVPForms Members

        public frmChart()
        {
            InitializeComponent();
            gm = new GenelMetotlar();
        }

        private static PointOptions po1;
        private static PointOptions po2;
        private GenelMetotlar gm;

        public enum Bolumler
        {
            DavaGenelBilgilerTarafliHesapsiz,
            DavaGenelBilgilerSorumluHesapsiz,
            IcraGenelBilgilerTarafliHesapsiz,
            IcraGenelBilgilerSorumluHesapsiz,
            Dava_Dosyalar�n�n_Durumlar�na_G�re_Da��l�m�,
        }

        public Bolumler GrafikBolumu { get; set; }

        private TopNOptions Options { get { return chartControl1.Series.Count > 0 ? chartControl1.Series[0].TopNOptions : null; } }

        private void ChartaBas(IQueryable<ChartDataSource> data)
        {
            if (chartControl1.Series.Dolumu())
            {
                chartControl1.Series[0].DataSource = data;
                chartControl1.Series[0].ArgumentDataMember = "ArgumentName";
                chartControl1.Series[0].ValueDataMembers[0] = "Value";
            }
        }

        private void ChartaBasTrh(List<List<ChartDataSource1>> data)
        {
            if (chartControl1.Series.Dolumu())
            {
                Series series;
                chartControl1.Series.Clear();
                int i = 1;
                foreach (var T in data)
                {
                    series = new Series(T.Select(s => s.Yil).FirstOrDefault().ToString(), ViewType.RadarArea);

                    //title= new ChartTitle();//title.Text = ;
                    //chartControl1.Titles.Add(title);
                    series.DataSource = null;
                    series.DataSource = T;
                    series.ArgumentDataMember = "ArgumentName";
                    series.ValueDataMembers[0] = "Value";
                    i++;
                    chartControl1.Series.Add(series);
                }

                //DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
                //xyDiagram1.AxisX.Label.Staggered = true;
                //xyDiagram1.AxisX.Range.ScrollingRange.SideMarginsEnabled = true;
                //xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
                //xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
                //xyDiagram1.AxisY.Range.ScrollingRange.SideMarginsEnabled = true;
                //xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
                //xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
                //this.chartControl1.Diagram = xyDiagram1;
            }
        }

        private void IcraBorcluOdemeleri_Load(object sender, EventArgs e)
        {
            //AdimAdimDavaKaydi.Is.UserControls.ucGorevGrid gg = new AdimAdimDavaKaydi.Is.UserControls.ucGorevGrid();
            //gg.MyDataSource = from d in db.AV001_DAVA_GNL_BLGLRI_HSPSIZ_SRMLULUs select d;

            po1 = new PointOptions();
            po1.ValueNumericOptions.Precision = 0;
            po1.ValueNumericOptions.Format = NumericFormat.Number;

            po2 = new PointOptions();
            po2.ValueNumericOptions.Precision = 0;
            po1.ValueNumericOptions.Format = NumericFormat.Percent;
            this.ucChartDesignerControlPanel1.MyChartControl = this.chartControl1;

            List<string> renkListesi = RenkPaletleriniDoldur();

            grafikSecenekleriDoldur();

            luRenkPaleti.Properties.DataSource = renkListesi;

            dilimleriDoldur();
        }

        #region Chart DataSource

        #region DataSource De�i�tirme

        public enum Dava_Dosyalar�n�n_Durumlar�na_G�re_Da��l�m�
        {
        }

        public enum DvGnlBlglerSorumuyaGore
        {
            DurumaGore,
            DavaKonusunaGore,
            MahkemeyeGore,
            GoreveGore,
            DavaTipineGore,
            DavaTarihiYil,
            DavaTarihiCeyrek,
            DavaTarihiAy,
            DavaTarihiGun
        }

        public enum DvGnlBlglerTarafaGoreHesapsiz
        {
            DurumaGore,
            DavaKonusu,
            Mahkeme,
            Gorev,
            DavaTipi,
            DavaTarihiYil,
            DavaTarihiCeyrek,
            DavaTarihiAy,
            DavaTarihiGun,
        }

        public enum IcraGenelBilgilerSorumluyaGore
        {
            SorumluyaGore,
            TakipkonusunaGore,
            MudurlugeGore,
        }

        public enum IcraGenelBilgilerTarafaGore
        {
            TarafaGore,
            AyaGore,
            TakipKonusunaGore,
            YilaGore,
            MudurlugeGore,
            HaftaninGunlerineGore
        }

        #endregion DataSource De�i�tirme

        #region Dava Genel Bilgileri Sorumlusuna G�re

        private void DavaHspsizSorumlu_DavaKonusu()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            IQueryable<ChartDataSource> gruplar = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_SRMLULUs.GroupBy(vi => vi.Dava_Konusu).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key,
                Value = vi.Count()
            });

            ChartaBas(gruplar);
        }

        private void DavaHspsizSorumlu_DavaTarihCeyrek()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            var gruplar = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_SRMLULUs.GroupBy(vi => vi.Dava_T.Value.Month).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString(),
                Value = vi.Count(),
            });

            List<ChartDataSource> liste = new List<ChartDataSource>();
            liste.Add(new ChartDataSource() { ArgumentName = "1", Value = 0 });
            liste.Add(new ChartDataSource() { ArgumentName = "2", Value = 0 });
            liste.Add(new ChartDataSource() { ArgumentName = "3", Value = 0 });
            liste.Add(new ChartDataSource() { ArgumentName = "4", Value = 0 });

            foreach (var grup in gruplar)
            {
                switch (grup.ArgumentName)
                {
                    case "1":
                    case "2":
                    case "3":
                        liste[0].Value += grup.Value;
                        break;

                    case "4":
                    case "5":
                    case "6":
                        liste[1].Value += grup.Value;
                        break;

                    case "7":
                    case "8":
                    case "9":
                        liste[2].Value += grup.Value;
                        break;

                    case "10":
                    case "11":
                    case "12":
                        liste[3].Value += grup.Value;
                        break;
                }
            }

            if (chartControl1.Series.Dolumu())
            {
                chartControl1.Series[0].DataSource = null;

                chartControl1.Series[0].DataSource = liste;
                chartControl1.Series[0].ArgumentDataMember = "ArgumentName";
                chartControl1.Series[0].ValueDataMembers[0] = "Value";
            }
        }

        private void DavaHspsizSorumlu_DavaTarihiAy()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            IQueryable<ChartDataSource> gruplar = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_SRMLULUs.GroupBy(vi => vi.Dava_T.Value.Month).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString(),
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void DavaHspsizSorumlu_DavaTarihiGun()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            IQueryable<ChartDataSource> gruplar = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_SRMLULUs.GroupBy(vi => vi.Dava_T.Value.DayOfWeek).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString(),
                Value = vi.Count()
            });

            ChartaBas(gruplar);
        }

        private void DavaHspsizSorumlu_DavaTarihiYil()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            IQueryable<ChartDataSource> gruplar = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_SRMLULUs.GroupBy(vi => vi.Dava_T.Value.Year).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString(),
                Value = vi.Count()
            });

            ChartaBas(gruplar);
        }

        private void DavaHspsizSorumlu_DavaTipi()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            IQueryable<ChartDataSource> gruplar = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_SRMLULUs.GroupBy(vi => vi.Dava_Tipi).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key,
                Value = vi.Count()
            });

            ChartaBas(gruplar);
        }

        private void DavaHspsizSorumlu_DurumaGore()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            IQueryable<ChartDataSource> gruplar = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_SRMLULUs.GroupBy(vi => vi.DURUM).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key + " Adet : " + vi.Count(),
                Value = vi.Count()
            });

            ChartaBas(gruplar);
        }

        private void DavaHspsizSorumlu_Gorev()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            IQueryable<ChartDataSource> gruplar = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_SRMLULUs.GroupBy(vi => vi.GOREV).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key,
                Value = vi.Count(),
            });

            ChartaBas(gruplar);
        }

        private void DavaHspsizSorumlu_Mahkeme()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            IQueryable<ChartDataSource> gruplar = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_SRMLULUs.GroupBy(vi => vi.Mahkemesi).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key,
                Value = vi.Count(),
            });

            ChartaBas(gruplar);
        }

        #endregion Dava Genel Bilgileri Sorumlusuna G�re

        #region Dava Genel Bilgileri Tarafa Göre Hesapsız

        private void DavaHspsizTaraf_DavaKonusu()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            var gruplar = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_TARAFLIs.GroupBy(vi => vi.Dava_Konusu).Select(vi => new
            {
                DavaKonusu = vi.Key,
                Sayisi = vi.Count()
            });

            if (chartControl1.Series.Dolumu())
            {
                chartControl1.Series[0].DataSource = null;

                chartControl1.Series[0].DataSource = gruplar;
                chartControl1.Series[0].ArgumentDataMember = "DavaKonusu";
                chartControl1.Series[0].ValueDataMembers[0] = "Sayisi";
            }
        }

        private void DavaHspsizTaraf_DavaTarihCeyrek()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            var gruplar = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_TARAFLIs.GroupBy(vi => vi.Dava_T.Value.Month).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString(),
                Value = vi.Count(),
            });

            List<ChartDataSource> liste = new List<ChartDataSource>();
            liste.Add(new ChartDataSource() { ArgumentName = "1", Value = 0 });
            liste.Add(new ChartDataSource() { ArgumentName = "2", Value = 0 });
            liste.Add(new ChartDataSource() { ArgumentName = "3", Value = 0 });
            liste.Add(new ChartDataSource() { ArgumentName = "4", Value = 0 });

            foreach (var grup in gruplar)
            {
                switch (grup.ArgumentName)
                {
                    case "1":
                    case "2":
                    case "3":
                        liste[0].Value += grup.Value;
                        break;

                    case "4":
                    case "5":
                    case "6":
                        liste[1].Value += grup.Value;
                        break;

                    case "7":
                    case "8":
                    case "9":
                        liste[2].Value += grup.Value;
                        break;

                    case "10":
                    case "11":
                    case "12":
                        liste[3].Value += grup.Value;
                        break;
                }
            }

            if (chartControl1.Series.Dolumu())
            {
                chartControl1.Series[0].DataSource = null;

                chartControl1.Series[0].DataSource = liste;
                chartControl1.Series[0].ArgumentDataMember = "ArgumentName";
                chartControl1.Series[0].ValueDataMembers[0] = "Value";
            }
        }

        private void DavaHspsizTaraf_DavaTarihGun()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            var gruplar = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_TARAFLIs.GroupBy(vi => vi.Dava_T.Value.DayOfWeek).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString(),
                Value = vi.Count()
            });

            ChartaBas(gruplar);
        }

        private void DavaHspsizTaraf_DavaTarihiAy()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            var gruplar = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_TARAFLIs.GroupBy(vi => vi.Dava_T.Value.Month).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString(),
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void DavaHspsizTaraf_DavaTarihiYil()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            var gruplar = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_TARAFLIs.GroupBy(vi => vi.Dava_T.Value.Year).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString(),
                Value = vi.Count()
            });

            ChartaBas(gruplar);
        }

        private void DavaHspsizTaraf_DavaTipi()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            var gruplar = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_TARAFLIs.GroupBy(vi => vi.Dava_Tipi).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key,
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void DavaHspsizTaraf_DurumaGore()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            var gruplar = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_TARAFLIs.GroupBy(vi => vi.DURUM).Select(vi => new
            {
                Durum = vi.Key,
                Sayisi = vi.Count()
            });

            if (chartControl1.Series.Dolumu())
            {
                chartControl1.Series[0].DataSource = null;

                chartControl1.Series[0].DataSource = gruplar;
                chartControl1.Series[0].ArgumentDataMember = "Durum";
                chartControl1.Series[0].ValueDataMembers[0] = "Sayisi";
            }
        }

        private void DavaHspsizTaraf_Gorevi()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            var gruplar = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_TARAFLIs.GroupBy(vi => vi.GOREV).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key,
                Value = vi.Count()
            });

            ChartaBas(gruplar);
        }

        private void DavaHspsizTaraf_Mahkemesi()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            var gruplar = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_TARAFLIs.GroupBy(vi => vi.Mahkemesi).Select(vi => new
            {
                Mahkeme = vi.Key,
                Sayisi = vi.Count()
            });

            if (chartControl1.Series.Dolumu())
            {
                chartControl1.Series[0].DataSource = null;

                chartControl1.Series[0].DataSource = gruplar;
                chartControl1.Series[0].ArgumentDataMember = "Mahkeme";
                chartControl1.Series[0].ValueDataMembers[0] = "Sayisi";
            }
        }

        #endregion Dava Genel Bilgileri Tarafa Göre Hesapsız

        #region İcra Genel Bilgiler Hesapsız Taraflı

        private void IcraGenelHspsizTarafli_AyaGore()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            var sonuc = db.R_AV001_ICRA_GNL_BLGLRI_HSPSIZ_TARAFLIs.GroupBy(vi => vi.Takip_T.Value.Month).Select(vi => new
            {
                Sayisi = vi.Count(),
                Ay = vi.Key
            });

            if (chartControl1.Series.Dolumu())
            {
                chartControl1.Series[0].DataSource = null;

                chartControl1.Series[0].DataSource = sonuc;
                chartControl1.Series[0].ArgumentDataMember = "Ay";
                chartControl1.Series[0].ValueDataMembers[0] = "Sayisi";
            }
        }

        private void IcraGenelHspsizTarafli_HaftaninGunlerineGore()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            var sonuc = db.R_AV001_ICRA_GNL_BLGLRI_HSPSIZ_TARAFLIs.GroupBy(vi => vi.Takip_T.Value.DayOfWeek).Select(vi => new
            {
                Sayisi = vi.Count(),
                Gunler = vi.Key
            });

            if (chartControl1.Series.Dolumu())
            {
                chartControl1.Series[0].DataSource = null;

                chartControl1.Series[0].DataSource = sonuc;
                chartControl1.Series[0].ArgumentDataMember = "Gunler";
                chartControl1.Series[0].ValueDataMembers[0] = "Sayisi";
            }
        }

        private void IcraGenelHspsizTarafli_Mudurluk()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            IQueryable<ChartDataSource> gruplar = db.R_AV001_ICRA_GNL_BLGLRI_HSPSIZ_TARAFLIs.GroupBy(vi => vi.Mudurluk).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key,
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void IcraGenelHspsizTarafli_TakipKonusu()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            IQueryable<ChartDataSource> gruplar = db.R_AV001_ICRA_GNL_BLGLRI_HSPSIZ_TARAFLIs.GroupBy(vi => vi.Takip_Konusu).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key,
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void IcraGenelHspsizTarafli_YilaGore()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            chartControl1.Series[0].DataSource = null;
            var sonuc = db.R_AV001_ICRA_GNL_BLGLRI_HSPSIZ_TARAFLIs.GroupBy(vi => vi.Takip_T.Value.Year).Select(vi => new
            {
                Sayisi = vi.Count(),
                Yil = vi.Key
            });

            if (chartControl1.Series.Dolumu())
            {
                chartControl1.Series[0].DataSource = null;

                chartControl1.Series[0].DataSource = sonuc;
                chartControl1.Series[0].ArgumentDataMember = "Yil";
                chartControl1.Series[0].ValueDataMembers[0] = "Sayisi";
            }
        }

        #endregion İcra Genel Bilgiler Hesapsız Taraflı

        #region İcra Genel Bilgiler Hesapsız Sorumlulu

        private void IcraGenelHesapsizSorumlulu_MudurlugeGore()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);

            chartControl1.Series[0].DataSource = null;

            var gruplar = db.R_AV001_ICRA_GNL_BLGLRI_HSPSIZ_SRMLULUs.GroupBy(vi => vi.Mudurluk).Select(vi => new
            {
                Mudurluk = vi.Key,
                Sayisi = vi.Count()
            });

            if (chartControl1.Series.Dolumu())
            {
                chartControl1.Series[0].DataSource = null;

                chartControl1.Series[0].DataSource = gruplar;
                chartControl1.Series[0].ArgumentDataMember = "Mudurluk";
                chartControl1.Series[0].ValueDataMembers[0] = "Sayisi";
            }
        }

        private void IcraGenelHesapsizSorumlulu_SorumluyaGore()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            var gruplar = db.R_AV001_ICRA_GNL_BLGLRI_HSPSIZ_SRMLULUs.GroupBy(vi => vi.Sorumlu_Adi).Select(vi => new
            {
                SorumluAdi = vi.Key,
                DosyaSayisi = vi.Count()
            });

            if (chartControl1.Series.Dolumu())
            {
                chartControl1.Series[0].DataSource = null;

                chartControl1.Series[0].DataSource = gruplar;
                chartControl1.Series[0].ArgumentDataMember = "SorumluAdi";
                chartControl1.Series[0].ValueDataMembers[0] = "DosyaSayisi";
            }
        }

        private void IcraGenelHesapsizSorumlulu_TakipKonusunaGore()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            var gruplar = db.R_AV001_ICRA_GNL_BLGLRI_HSPSIZ_SRMLULUs.GroupBy(vi => vi.Takip_Konusu).Select(vi => new
            {
                TakipKonusu = vi.Key,
                Sayisi = vi.Count(),
            });

            if (chartControl1.Series.Dolumu())
            {
                chartControl1.Series[0].DataSource = null;

                chartControl1.Series[0].DataSource = gruplar;
                chartControl1.Series[0].ArgumentDataMember = "TakipKonusu";
                chartControl1.Series[0].ValueDataMembers[0] = "Sayisi";
            }
        }

        #endregion İcra Genel Bilgiler Hesapsız Sorumlulu

        //BackgroundWorker bw = new BackgroundWorker();

        public void TabloDegistir(string menuItem)
        {
            TabloDegistir(menuItem, true);

            //bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            //bw.RunWorkerAsync(menuItem);
            //bw.WorkerReportsProgress = true;
            //bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
        }

        public void TabloDegistir(string menuItem, bool secim)
        {
            switch (menuItem)
            {
                #region g�khan�nkiler

                case "Chart_IcraGenelBilgilerTaraf_AyaGore":
                    IcraGenelHspsizTarafli_AyaGore();
                    dilimleriDoldur();
                    break;

                case "Chart_IcraGenelBilgilerTaraf_TakipKonusunaGore":
                    IcraGenelHspsizTarafli_TakipKonusu();
                    dilimleriDoldur();
                    break;

                case "Chart_IcraGenelBilgilerTaraf_YilaGore":
                    IcraGenelHspsizTarafli_YilaGore();
                    dilimleriDoldur();
                    break;

                case "Chart_IcraGenelBilgilerTaraf_MudurlugeGore":
                    IcraGenelHspsizTarafli_Mudurluk();
                    dilimleriDoldur();
                    break;

                case "Chart_IcraGenelBilgilerTaraf_HaftaninGunlerineGore":
                    IcraGenelHspsizTarafli_HaftaninGunlerineGore();
                    dilimleriDoldur();
                    break;

                case "Chart_IcraGenelBilgilerSorumlu_SorumluyaGore":
                    IcraGenelHesapsizSorumlulu_SorumluyaGore();
                    dilimleriDoldur();
                    break;

                case "Chart_IcraGenelBilgilerSorumlu_TakipkonusunaGore":
                    IcraGenelHesapsizSorumlulu_TakipKonusunaGore();
                    dilimleriDoldur();
                    break;

                case "Chart_IcraGenelBilgilerSorumlu_MudurlugeGore":
                    IcraGenelHesapsizSorumlulu_MudurlugeGore();
                    dilimleriDoldur();
                    break;

                case "Chart_DavaGenelBilgilerTarafa_DurumaGore":
                    DavaHspsizTaraf_DurumaGore();
                    break;

                case "Chart_DavaGenelBilgilerTarafa_DavaKonusu":
                    DavaHspsizTaraf_DavaKonusu();
                    break;

                case "Chart_DavaGenelBilgilerTarafa_Mahkeme":
                    DavaHspsizTaraf_Mahkemesi();
                    break;

                case "Chart_DavaGenelBilgilerTarafa_Gorev":
                    DavaHspsizTaraf_Gorevi();
                    break;

                case "Chart_DavaGenelBilgilerTarafa_DavaTipi":
                    DavaHspsizTaraf_DavaTipi();
                    break;

                case "Chart_DavaGenelBilgilerTarafa_DavaTarihiYil":
                    DavaHspsizTaraf_DavaTarihiYil();
                    break;

                case "Chart_DavaGenelBilgilerTarafa_DavaTarihiCeyrek":
                    DavaHspsizTaraf_DavaTarihCeyrek();
                    break;

                case "Chart_DavaGenelBilgilerTarafa_DavaTarihiAy":
                    DavaHspsizTaraf_DavaTarihiAy();
                    break;

                case "Chart_DavaGenelBilgilerTarafa_DavaTarihiGun":
                    DavaHspsizTaraf_DavaTarihGun();
                    break;

                case "Chart_DavaGenelBilgilerSorumlu_DurumaGore":
                    DavaHspsizSorumlu_DurumaGore();
                    break;

                case "Chart_DavaGenelBilgilerSorumlu_DavaKonusunaGore":
                    DavaHspsizSorumlu_DavaKonusu();
                    break;

                case "Chart_DavaGenelBilgilerSorumlu_MahkemeyeGore":
                    DavaHspsizSorumlu_Mahkeme();
                    break;

                case "Chart_DavaGenelBilgilerSorumlu_GoreveGore":
                    DavaHspsizSorumlu_Gorev();
                    break;

                case "Chart_DavaGenelBilgilerSorumlu_DavaTipineGore":
                    DavaHspsizSorumlu_DavaTipi();
                    break;

                case "Chart_DavaGenelBilgilerSorumlu_DavaTarihiYil":
                    DavaHspsizSorumlu_DavaTarihiYil();
                    break;

                case "Chart_DavaGenelBilgilerSorumlu_DavaTarihiCeyrek":
                    DavaHspsizSorumlu_DavaTarihCeyrek();
                    break;

                case "Chart_DavaGenelBilgilerSorumlu_DavaTarihiAy":
                    DavaHspsizSorumlu_DavaTarihiAy();
                    break;

                case "Chart_DavaGenelBilgilerSorumlu_DavaTarihiGun":
                    DavaHspsizSorumlu_DavaTarihiGun();
                    break;

                #endregion g�khan�nkiler

                case "Dava Dosyalar�n�n Durumlar�na G�re Da��l�m�":
                    DavaDurumag�re();
                    break;

                case "Dava Dosyalar�n�n B�l�mlere G�re Da��l�m�":
                    DavaDosyalarininBolumlerineGoreDagilimi();
                    break;

                case "Dava Dosyalar�n�n Dava Tipine G�re Da��l�m":
                    DavaDosyalarininDavaTipineGoreDagilimi();
                    break;

                case "Dava Dosyalar�n�n Dava Taleplerine G�re Da��l�m�":
                    DavaDosyalarininDavaTaleplerineGoreDagilimi();
                    break;

                case "Dava Dosyalar�n�n B�rolara G�re Da��l�m�":
                    DavaDosyalarininBurolaraGoreDagilimi();
                    break;

                case "Dava Dosyalar�n�n Sorumlu Avukatlara G�re Da��l�m�":
                    DavaDosyalarininSorumluAvukatlaraGoreDagilimi();
                    break;

                case "Dava Dosyalar�n�n �zleyen Avukatlara G�re Da��l�m�":
                    DavaDosyalarininIzleyenAvukatlaraGoreDagilimi();
                    break;

                case "Dava Dosyalar�n�n Kazan�lan ve Kaybedilenlere G�re Da��l�m�":
                    DavaDosylarininKazanilanKaybedilenlereGoreDagilimi();
                    break;

                case "Dava Dosyalar�n�n B�lgelere G�re Da��l�m�":
                    DavaDosyalarininBolgelereGoreDagilimi();
                    break;

                case "Dava Dosyalar�n�n �ubelere G�re Da��l�m�":
                    DavaDosylarininSubelereGoreDagilimi();
                    break;

                case "�cra Dosyalar�n�n B�l�mlere G�re Da��l�m�":
                    IcraDosyalarininBolumlereGoreDagilimi();
                    break;

                case "�cra Dosyalar�n�n �cra Form Tipine G�re Da��l�m�":
                    IcraDosyalarininIcraFormTipineGoreDagilimi();
                    break;

                case "�cra Dosyalar�n�n �cra Taleplerine G�re Da��l�m�":
                    IcraDosyalarininIcraTaleplerineGoreDagilimi();
                    break;

                case "�cra Dosyalar�n�n �cra Alacak Nedenlerine G�re Da��l�m�":
                    IcraDosyalarininAlacakNedenlerineGoreDagilimi();
                    break;

                case "�cra Dosyalar�n�n �cra Alacak Nedenlerine G�re Da��l�m� Y�llara G�re":
                    IcraDosyalarininAlacakNedenlerineGoreDagilimiYillaraGore();
                    break;

                case "�cra Dosyalar�n�n B�rolara G�re Da��l�m�":
                    IcraDosyalarininBurolaraGoreDagilimi();
                    break;

                case "�cra Dosyalar�n�n Sorumlu Avukatlara G�re Da��l�m�":
                    IcraDosyalarininSorumluavukatlaraGoreDagilimi();
                    break;

                case "�cra Dosyalar�n�n �zleyen Avukatlara G�re Da��l�m�":
                    IcraDosyalarininIzleyenAvukatlaraGoreDagilimi();
                    break;

                case "�cra Dosyalar�n�n Durumlar�na G�re Da��l�m�":
                    IcraDosyalarininDurumlarinaGoreDagilimi();
                    break;

                case "�cra Dosyalar�n�n B�lgelere G�re Da��l�m�":
                    IcraDosyalarininBolgelereGoreDagilimi();
                    break;

                case "�cra Dosyalar�n�n �ubelere G�re Da��l�m�":
                    IcraDosyalarininSubelereGoreDagilimi();
                    break;

                case "�cra Dosyalar�n�n Kredi Tiplerine G�re Da��l�m�":
                    IcraDosyalarininKrediTipineGoreDagilimi();
                    break;

                case "Tahsilatlar�n Hukuk B�l�mlerine G�re Da��l�m�":
                    TahsilatLarinHukukBolumlerineGoreDagilimi();
                    break;

                case "Tahsilatlar�n �deme Yerine G�re Da��l�m�":
                    TahsilatlarinOdemeYerineGoreDagilimi();
                    break;

                case "Tahsilatlar�n �deme Tipine G�re Da��l�m�":
                    TahsilatlarinOdemeTipineGoreDagilimi();
                    break;

                case "Tahsilatlar�n Mahsup Kalemine G�re Da��l�m�":
                    TahsilatlarinMahsupKalemineGoreDagilimi();
                    break;

                case "Tahsilatlar�n Y�llara G�re Da��l�m�":
                    TahsilatlarinY�llaraGoreDagilimi();
                    break;

                case "Tahsilatlar�n Aylara G�re Da��l�m�":
                    TahsilatlarinAylaraGoreDagilimi();
                    break;

                case "Tahsilatlar�n B�rolara G�re Da��l�m�":
                    TahsilatlarinBurolaraGoreDagilimi();
                    break;

                case "Masraflar�n Hukuk B�l�mlerine g�re da��l�m�":
                    MasraflarinHukumBolumlerineGoreDagilimi();
                    break;

                case "Masraflar�n �deme Yerine G�re Da��l�m�":
                    MasraflarinOdemeYerineGoreDagilimi();
                    break;

                case "Masraflar�n �deme Tipine G�re Da��l�m�":
                    MasraflarinOdemeTipineGoreDagilimi();
                    break;

                case "Masraflar�n Mahsup Kalemine G�re Da��l�m�":
                    MasraflarinMahsupKalemineGoreDagilimi();
                    break;

                case "Tahsilatar�n B�lgelere G�re Da��l�m�":
                    TahsilatlarinBolgelereGoreDagilimi();
                    break;

                case "Tahsilatar�n �ubelere G�re Da��l�m�":
                    TahsilatlarinSubelereGoreDagilimi();
                    break;

                case "Masraflar�n Y�llara G�re Da��l�m�":
                    MasraflarinYillaraGoreDagilimi();
                    break;

                case "Masraflar�n Ana Kategorisine G�re Da��l�m�":
                    MasraflarinAnaKatagorisineGoreDagilimi();
                    break;

                case "Masraflar�n Alt Kategorilerine G�re Da��l�m�":
                    MasraflarinAltKategorisineDagilimi();
                    break;

                case "Masraflar�n Hukuk B�rolar�na G�re Da��l�m�":
                    MasraflarinHukukBurolar�naGoreDagilimi();
                    break;

                case "Avanslar�n Hukuk B�l�mlerine G�re Da��l�m�":
                    AvansLarinHukukBolumlerineGoreDagilimi();
                    break;

                case "Avanslar�n Hukuk B�rolar�na G�re Da��l�m�":
                    AvanslarinHukukBurolar�naGoreDagili();
                    break;

                case "Haciz Say�s� (B�rolara G�re)":
                    HacizSayisiBurolaraGore();
                    break;

                case "Sat�� Say�s� (B�rolara G�re)":
                    SatisSayisiBurolaraGore();
                    break;

                case "Tahsilat Say�s� (B�rolara G�re)":
                    TahsilatSayisiBurolaraGore();
                    break;

                case "Kapama Say�s� (B�rolara G�re)":
                    KapamaSayisiBurolaraGore();
                    break;

                case "Duru�ma Say�s� (B�rolara G�re)":
                    DurusmaSayisiBurolaraGore();
                    break;

                default:
                    break;
            }
        }

        private void AvansLarinHukukBolumlerineGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs.GroupBy(vi => vi.BOLUM).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "B�l�m Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void AvanslarinHukukBurolar�naGoreDagili()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs.GroupBy(vi => vi.SUBE_KOD_ID).Select(vi => new ChartDataSource
            {
                ArgumentName = gm.BuroAdiGetir((int?)vi.Key),
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void DavaDosyalarininBolgelereGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_DAVA_PRATIK_ARAMA_RAPORs.GroupBy(vi => vi.BOLGE).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "B�lge Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void DavaDosyalarininBolumlerineGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;
            IQueryable<ChartDataSource> gruplar = dbV.R_DAVA_PRATIK_ARAMA_RAPORs.GroupBy(vi => vi.BOLUM).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "B�l�m Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void DavaDosyalarininBurolaraGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_DAVA_PRATIK_ARAMA_RAPORs.GroupBy(vi => vi.SUBE_KOD_ID).Select(vi => new ChartDataSource
            {
                ArgumentName = gm.BuroAdiGetir((int)vi.Key),
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void DavaDosyalarininDavaTaleplerineGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_DAVA_PRATIK_ARAMA_RAPORs.GroupBy(vi => vi.DAVA_TALEP).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "Dava Talep Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
            chartControl1.Series[0].ChangeView(ViewType.Bar3D);
        }

        private void DavaDosyalarininDavaTipineGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;
            IQueryable<ChartDataSource> gruplar = dbV.R_DAVA_PRATIK_ARAMA_RAPORs.GroupBy(vi => vi.BIRIM).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "Dava Tipi Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void DavaDosyalarininIzleyenAvukatlaraGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_DAVA_PRATIK_ARAMA_RAPORs.GroupBy(vi => vi.IZLEYEN).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "�zleyen Avukat Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void DavaDosyalarininSorumluAvukatlaraGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_DAVA_PRATIK_ARAMA_RAPORs.GroupBy(vi => vi.SORUMLU).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "Sorumlu Avukat Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void DavaDosylarininKazanilanKaybedilenlereGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_HUKUM_TAKIP_RAPORs.GroupBy(vi => vi.HUKUM_ANLAM).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "Kazan�lan Kaybedilen Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void DavaDosylarininSubelereGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_DAVA_PRATIK_ARAMA_RAPORs.GroupBy(vi => vi.SUBE).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "�ube Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void DavaDurumag�re()
        {
            AvukatProViewDataContext dbV = Program.dbV;
            IQueryable<ChartDataSource> gruplar = dbV.R_DAVA_PRATIK_ARAMA_RAPORs.GroupBy(vi => vi.DURUM).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "Dava Durum Bilgisi Girilmemi�",
                Value = vi.Count()
            });

            ChartaBas(gruplar);
        }

        private void DurusmaSayisiBurolaraGore()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_DURUSMA_DAVA_GENEL_TARAFLI_RAPORs.GroupBy(vi => vi.SUBE_KOD_ID).Select(vi => new ChartDataSource
            {
                ArgumentName = gm.BuroAdiGetir((int?)vi.Key),
                Value = vi.Count()
            });

            if (dbV.R_DURUSMA_DAVA_GENEL_TARAFLI_RAPORs.GroupBy(vi => vi.SUBE_KOD_ID).Count() <= 0)
                XtraMessageBox.Show("Arad���n�z Kriterlere Uygun Kay�t Bulunamam��t�r");
            ChartaBas(gruplar);
        }

        private void HacizSayisiBurolaraGore()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_HACIZLI_MALLAR_MASTER_CHILD_RAPORs.GroupBy(vi => vi.SUBE_KOD_ID).Select(vi => new ChartDataSource
            {
                ArgumentName = gm.BuroAdiGetir((int)vi.Key),
                Value = vi.Count()
            });
            foreach (var item in gruplar)
            {
                item.ArgumentName = "";
            }
            ChartaBas(gruplar);
        }

        private void IcraDosyalarininAlacakNedenlerineGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.GroupBy(vi => vi.ALACAK_NEDENI).Select(vi => new ChartDataSource
          {
              ArgumentName = vi.Key.ToString() ?? "Alacak Neden Bilgisi Girilmemi�",
              Value = vi.Count()
          });
            ChartaBas(gruplar);
        }

        private void IcraDosyalarininAlacakNedenlerineGoreDagilimiYillaraGore()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            //ucChartTarih trh= new ucChartTarih();
            //trh.Dock = DockStyle.Fill;
            List<List<ChartDataSource1>> GRUP = new List<List<ChartDataSource1>>();
            List<ChartDataSource1> gruplar;
            List<int> yillar = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(T => T.TAKIP_TARIHI.HasValue).GroupBy(t => t.TAKIP_TARIHI.Value.Year).Select(v => v.Key).ToList();
            foreach (var item in yillar)
            {
                gruplar = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(t => t.TAKIP_TARIHI.Value.Year == item).GroupBy(vi => vi.ALACAK_NEDENI).Select(vi => new ChartDataSource1
                {
                    ArgumentName = vi.Key.ToString() ?? "Di�er",
                    Value = vi.Count(),
                    Yil = item
                }).ToList();
                GRUP.Add(gruplar);
            }

            ChartaBasTrh(GRUP);
        }

        private void IcraDosyalarininBolgelereGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.GroupBy(vi => vi.BOLGE).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "B�lge Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void IcraDosyalarininBolumlereGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.GroupBy(vi => vi.BOLUM).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? " B�l�m Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void IcraDosyalarininBurolaraGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.GroupBy(vi => vi.SUBE_KOD_ID).Select(vi => new ChartDataSource
            {
                ArgumentName = gm.BuroAdiGetir((int?)vi.Key),
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void IcraDosyalarininDurumlarinaGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.GroupBy(vi => vi.DURUM).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "Durum Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void IcraDosyalarininIcraFormTipineGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.GroupBy(vi => vi.FORM_TIPI).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "Form Tipi Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void IcraDosyalarininIcraTaleplerineGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.GroupBy(vi => vi.TALEP_ADI).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "Icra Talep Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void IcraDosyalarininIzleyenAvukatlaraGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.GroupBy(vi => vi.IZLEYEN).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "�zleyen Avukat Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void IcraDosyalarininKrediTipineGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.GroupBy(vi => vi.KREDI_TIP).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "Kredi Tipi Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void IcraDosyalarininSorumluavukatlaraGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.GroupBy(vi => vi.SORUMLU).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "Sorumlu Avukat Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void IcraDosyalarininSubelereGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.GroupBy(vi => vi.BANKA_SUBE).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "�ube Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void KapamaSayisiBurolaraGore()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vii => vii.KAPAMA_TARIHI != null).GroupBy(vi => vi.SUBE_KOD_ID).Select(vi => new ChartDataSource
            {
                ArgumentName = gm.BuroAdiGetir((int?)vi.Key),
                Value = vi.Count()
            });
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vii => vii.KAPAMA_TARIHI != null).Count() <= 0)
                XtraMessageBox.Show("Arad���n�z Kriterlere Uygun Kay�t Bulunamam��t�r");
            ChartaBas(gruplar);
        }

        private void MasraflarinAltKategorisineDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs.GroupBy(vi => vi.ALT_KATEGORI).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "Alt Kategori Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void MasraflarinAnaKatagorisineGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs.GroupBy(vi => vi.ANA_KATEGORI).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "Ana Kategori Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void MasraflarinHukukBurolar�naGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs.GroupBy(vi => vi.SUBE_KOD_ID).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "B�ro Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);

            // XtraMessageBox.Show("Rapor Yap�m A�amas�nda");
        }

        private void MasraflarinHukumBolumlerineGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;
            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs.GroupBy(vi => vi.BOLGE).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "B�lge Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
            if (dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs.Count() <= 0)
                XtraMessageBox.Show("Arad���n�z Kriterlere Uygun Kay�t Bulunamam��t�r.");
        }

        private void MasraflarinMahsupKalemineGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs.GroupBy(vi => vi.ODEME_TIP).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "�deme Tipi Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void MasraflarinOdemeTipineGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;
            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs.GroupBy(vi => vi.ODEME_TIP).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "�deme Tipi Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void MasraflarinOdemeYerineGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs.GroupBy(vi => vi.FOY_YERI).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "�deme Yeri Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void MasraflarinYillaraGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs.GroupBy(vi => vi.TAKIP_TARIHI.Value.Year).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString(),
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void SatisSayisiBurolaraGore()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_Master_IcraSatisGenel_Rapors.GroupBy(vi => vi.SUBE_KOD_ID).Select(vi => new ChartDataSource
            {
                ArgumentName = gm.BuroAdiGetir((int?)vi.Key),
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void TahsilatlarinAylaraGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;
            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs.GroupBy(vi => vi.TAKIP_TARIHI.Value.Month).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString(),
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void TahsilatlarinBolgelereGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs.GroupBy(vi => vi.BOLGE).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "B�lge Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void TahsilatlarinBurolaraGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs.GroupBy(vi => vi.SUBE_KOD_ID).Select(vi => new ChartDataSource
            {
                ArgumentName = gm.BuroAdiGetir((int?)vi.Key),
                Value = vi.Count()
            });

            //foreach (var item in gruplar)
            //{
            //    item.ArgumentName = "";
            //}
            ChartaBas(gruplar);
            if (dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs.Count() <= 0)
                XtraMessageBox.Show("Arad���n�z Kriterlere Uygun Kay�t Bulunamam��t�r.");
        }

        private void TahsilatLarinHukukBolumlerineGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs.GroupBy(vi => vi.BOLGE).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "Hukuk B�l�m Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void TahsilatlarinMahsupKalemineGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs.GroupBy(vi => vi.DAGILIM_TIPI).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "Mahsup Kalem Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void TahsilatlarinOdemeTipineGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs.GroupBy(vi => vi.ODEME_TIP).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "�deme Tipi Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void TahsilatlarinOdemeYerineGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs.GroupBy(vi => vi.ODEME_YERI).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "�deme Yeri Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void TahsilatlarinSubelereGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs.GroupBy(vi => vi.BANKA).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString() ?? "�ube Bilgisi Girilmemi�",
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void TahsilatlarinY�llaraGoreDagilimi()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs.GroupBy(vi => vi.TAKIP_TARIHI.Value.Year).Select(vi => new ChartDataSource
            {
                ArgumentName = vi.Key.ToString(),
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        private void TahsilatSayisiBurolaraGore()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            IQueryable<ChartDataSource> gruplar = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs.GroupBy(vi => vi.SUBE_KOD_ID).Select(vi => new ChartDataSource
            {
                ArgumentName = gm.BuroAdiGetir((int?)vi.Key),
                Value = vi.Count()
            });
            ChartaBas(gruplar);
        }

        #endregion Chart DataSource

        #region Grafikler

        private static List<string> RenkPaletleriniDoldur()
        {
            List<string> renkListesi = new List<string>();
            renkListesi.Add("Mixed");
            renkListesi.Add("Metro");
            renkListesi.Add("Opulent");
            renkListesi.Add("Origin");
            return renkListesi;
        }

        private void grafikSecenekleriDoldur()
        {
            luGrafikler.Properties.DataSource = Enum.GetValues(typeof(DevExpress.XtraCharts.ViewType));
        }

        private void luGrafikler_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraCharts.ViewType o = (DevExpress.XtraCharts.ViewType)luGrafikler.EditValue;
                chartControl1.Series[0].ChangeView(o);
            }
            catch 
            {
                //MessageBox.Show(ex.Message);
            }
        }

        #endregion Grafikler

        #region Secenekler

        private void cBoxDegerlendirme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Options == null)
                return;
            TopNMode mode = (TopNMode)cBoxDegerlendirme.SelectedIndex;
            Options.Mode = mode;

            //labelValue.Text = (string)comboBoxMode.SelectedItem + ":";
            spnValue.Properties.BeginInit();
            try
            {
                switch (mode)
                {
                    case TopNMode.Count:

                        spnValue.Properties.IsFloatValue = false;
                        spnValue.Properties.MinValue = 1;
                        spnValue.Properties.MaxValue = chartControl1.Series[0].Points.Count;
                        spnValue.Properties.Increment = 1;
                        spnValue.Properties.Mask.EditMask = "f0";
                        spnValue.EditValue = Options.Count;
                        lblValue.Text = "Kayıt Sayısı :";
                        break;

                    case TopNMode.ThresholdValue:
                        spnValue.Properties.IsFloatValue = true;
                        spnValue.Properties.MinValue = 0;
                        spnValue.Properties.MaxValue = decimal.Parse(chartControl1.Series[0].Points.ToArray().Max(vi => vi.Values.Max()).ToString());
                        spnValue.Properties.Increment = (spnValue.Properties.MaxValue - spnValue.Properties.MinValue) / 20;
                        spnValue.Properties.Mask.EditMask = "f0";
                        spnValue.EditValue = Options.ThresholdValue;
                        lblValue.Text = "En Düşük Değer :";
                        break;

                    case TopNMode.ThresholdPercent:
                        spnValue.Properties.IsFloatValue = true;
                        spnValue.Properties.MinValue = new decimal(1.5);
                        spnValue.Properties.MaxValue = 100;
                        spnValue.Properties.Increment = new decimal(0.1);
                        spnValue.Properties.Mask.EditMask = "f1";
                        spnValue.EditValue = Options.ThresholdPercent;
                        lblValue.Text = "En Düşük Değer";
                        break;

                    default:
                        spnValue.Enabled = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                throw;
            }
            spnValue.Properties.EndInit();
        }

        private void cBoxDilimler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chartControl1.Series.Count == 0)
                return;
            PieSeriesView view = chartControl1.Series[0].View as PieSeriesView;
            if (view != null)
            {
                string mode = (string)cBoxDilimler.SelectedItem;
                PieExplodingHelper.ApplyMode(view, mode);
            }
        }

        private void dilimleriDoldur()
        {
            cBoxDilimler.Properties.Items.Clear();
            if (chartControl1.Series[0].ArgumentDataMember != null)
            {
                cBoxDilimler.Properties.Items.AddRange(PieExplodingHelper.CreateModeList(chartControl1.Series[0].Points, false));
                cBoxDilimler.Properties.Items.AddRange(PieExplodingHelper.CreateModeList(chartControl1.Series[1].Points, false));
            }
            else if (chartControl1.Series[2].ArgumentDataMember != null)
            {
                cBoxDilimler.Properties.Items.AddRange(PieExplodingHelper.CreateModeList(chartControl1.Series[2].Points, false));
                cBoxDilimler.Properties.Items.AddRange(PieExplodingHelper.CreateModeList(chartControl1.Series[2].Points, false));
            }
            if (cBoxDilimler.Properties.Items.Dolumu())
            {
                cBoxDilimler.SelectedIndex = 0;
            }
        }

        private void luRenkPaleti_EditValueChanged(object sender, EventArgs e)
        {
            chartControl1.PaletteName = luRenkPaleti.EditValue.ToString();
        }

        private void spnValue_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Options != null)
                    switch (Options.Mode)
                    {
                        case TopNMode.Count:
                            Options.Count = Convert.ToInt32(spnValue.EditValue);
                            break;

                        case TopNMode.ThresholdValue:
                            Options.ThresholdValue = Convert.ToDouble(spnValue.EditValue);
                            break;

                        case TopNMode.ThresholdPercent:
                            Options.ThresholdPercent = Convert.ToDouble(spnValue.EditValue);
                            break;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion Secenekler
    }

}