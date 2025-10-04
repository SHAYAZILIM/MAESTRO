using AvukatProLib;
using AvukatProRaporlar.Lib;
using AvukatProRaporlar.RaporSource;
using DevExpress.Data.PivotGrid;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using RaporDataSource.TableDB;
using RaporDataSource.ViewDB;
using ReportPro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AvukatProRaporlar.Forms
{
    public partial class ftmPivotGrid : DevExpress.XtraEditors.XtraForm, iAVPForms
    {
        public ftmPivotGrid()
        {
            InitializeComponent();
            kasa = new RaporYapilacakIsSureDetay();
            chartControl1.DataSource = extendedPivotControl1;
            chartControl1.SeriesDataMember = "Series";
            chartControl1.SeriesTemplate.ArgumentDataMember = "Arguments";

            chartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });

            chartControl1.SeriesTemplate.LegendPointOptions.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;

            //chartControl1.SeriesTemplate.ChangeView(DevExpress.XtraCharts.ViewType.Line);
        }

        public string window;
        private BackgroundWorker bw = new BackgroundWorker();
        private RaporYapilacakIsSureDetay kasa;
        private AvukatProRaporlar.Lib.Enums.KayitTipi SecilenKayitTipi;

        public void pivotlayoutkaydet(string deger)
        {
            if (deger.Contains('/')) deger = deger.Replace('/', '-').ToString();
            string userAd = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            string _path = Application.StartupPath + "\\Pivotlayouts\\" + userAd + "\\";
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
            string filePath = _path + deger + ".yyl";
            try
            {
                if (XtraMessageBox.Show("Görünüm Kaydedilsin mi ?", deger, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    extendedPivotControl1.SaveLayoutToXml(filePath, OptionsLayoutBase.FullLayout);
            }
            catch 
            {
                MessageBox.Show("HATA!");
            }
        }

        public void TabloAc(string pencere)
        {
            TabloAc(pencere, true);
        }

        public void TabloAc(string pencere, bool secim)
        {
            switch (pencere)
            {
                #region gökhanınkiler

                case "Pivot_Dava_SorumlusunaGore":
                    DavaSorumlusunaGore();
                    break;

                case "Pivot_Dava_TarafinaGore":
                    DavaTarafinaGore();
                    break;

                case "Pivot_Dava_DosyasinaGore":
                    DavaDosyayaGore();
                    break;

                case "Pivot_Icra_SorumlusunaGore":
                    IcraSorumlusunaGore();
                    break;

                case "Pivot_Icra_DosyayaGore":
                    IcraDosyayaGore();
                    break;

                case "Pivot_Icra_TarafinaGore":
                    IcraTarafinaGore();
                    break;

                #endregion gökhanınkiler

                case "Temyiz Edilen Dosyalar":
                    TemyizEdilenDosyalar(pencere);
                    break;

                case "Düzeltilerek Lehe Onananlar":
                    DuzeltilerekLeheOnananlar();

                    //IcraDosyayaGore();
                    break;

                case "Bir Sonraki Aya Devreden (Üstteki Satırların Toplamı)":
                    BirSonrakiAyaDevreden(pencere);
                    break;

                case "Aciz ve Derkenarla Kapanan Dosyaların Anapara Toplamı":
                    AcizVeDerkenarlaKapananDosya(pencere);
                    break;

                case "Resmi Taahhütleri Alınmış Dosyalar":
                    ResmiTaahutleriAlinmisDosyalar(pencere);
                    break;

                case "Bu Ay İçinde Gelen Dosya Sayısı":
                    BuAyIcindeGelenDosyaSayisi(pencere);
                    break;

                case "Toplam (Devreden Ve Bu Ay Gelen) Dosya Sayısı":
                    ToplamDevredenDosyaSayisi(pencere);
                    break;

                case "Dosyalarının Durumlarına Göre Dağılımı":
                    DosyalarinDurumlarinaGoreDagilimi(pencere);
                    break;

                case "Dava Dosyalarının Dava Tarihine Göre Dağılımı":
                    davaDosyalarininDavaTGore(pencere);
                    break;

                case "Dava Dosyalarının Bürolara Göre Dağılımı":
                    davaDosyalarininBurolaraGore(pencere);
                    break;

                case "Dava Dosyalarının Bürolara İntikal Tarihine Göre Dağılımı":
                    davaDosyalarininBurolaraIntikalTGore(pencere);
                    break;

                case "Dava Dosyalarının Bölümlere Göre Dağılımı":
                    DavaDosyalarininBolumlerineGoreDagilimi(pencere);
                    break;

                case "Dava Dosyalarının Dava Tipine Göre Dağılım":
                    DavaDosyalarininDAvaTipineGoreDagilimi(pencere);
                    break;

                case "Dava Dosyalarının Dava Taleplerine Göre Dağılımı":
                    DavaDosyalarininDavaTaleplerineGoreDagilimi(pencere);
                    break;

                case "Dava Dosyalarının Sorumlu Avukatlara Göre Dağılımı":
                    DavaDosyalarininSorumluAvukatlaraGoreDagilimi(pencere);
                    break;

                case "Dava Dosyalarının İzleyen Avukatlara Göre Dağılımı":
                    DavaDosyalarininIzleyenAvukatlaraGoreDagilimi(pencere);
                    break;

                case "Dava Dosyalarının Kazanılan ve Kaybedilenlere Göre Dağılımı":
                    DavaDosyalarininKazanilanKaybedileneGoreDagilimi(pencere);
                    break;

                case "Dava Dosyalarının Bölgelere Göre Dağılımı":
                    DavaDosyalarininBolgelereGoreDagilimi(pencere);
                    break;

                case "Dava Dosyalarının Şubelere Göre Dağılımı":
                    DavaDosyalarininSubelereGoreDagilimi(pencere);
                    break;

                case "İcra Dosyalarının Bölümlere Göre Dağılımı":
                    IcraDosyayalarininBolumlereGore(pencere);
                    break;

                case "İcra Dosyalarının İcra Form Tipine Göre Dağılımı":
                    IcraDosyalarininFormTipineGore(pencere);
                    break;

                case "İcra Dosyalarının İcra Taleplerine Göre Dağılımı":
                    IcraDosyalarininIcraTaleplerineGoreDagilimi(pencere);
                    break;

                case "İcra Dosyalarının İcra Alacak Nedenlerine Göre Dağılımı":
                    IcraDosyalarininIcraAlacakNedenlerineGoreDagilimi(pencere);
                    break;

                case "İcra Dosyalarının İcra Alacak Nedenlerine Göre Dağılımı Yıllara Göre":
                    IcraDosyalarininAlacakNedenlerineGoreDagilimiYillaraGore(pencere);
                    break;

                case "İcra Dosyalarının Bürolara Göre Dağılımı":
                    IcraDosylarininBurolaraGoreDagilimi(pencere);
                    break;

                case "İcra Dosyalarının Sorumlu Avukatlara Göre Dağılımı":
                    IcraDosyalarininSorumluAvukatlaraGoreDagilimi(pencere);
                    break;

                case "İcra Dosyalarının İzleyen Avukatlara Göre Dağılımı":
                    IcraDosyalarininIzleyenAvukatlaraGoreDagilimi(pencere);
                    break;

                case "İcra Dosyalarının Durumlarına Göre Dağılımı":
                    IcraDosyalarininDurumlarineGoreDagilimi(pencere);
                    break;

                case "İcra Dosyalarının Bölgelere Göre Dağılımı":
                    IcraDosylarininBolgelereGoreDagilimi(pencere);
                    break;

                case "İcra Dosyalarının Şubelere Göre Dağılımı":
                    IcraDosyalarininSubelereGoreDagilimi(pencere);
                    break;

                case "İcra Dosyalarının Kredi Tiplerine Göre Dağılımı":
                    IcraDosylarininKrediTipineGoreDagilimi(pencere);
                    break;

                case "Takibe Konulan İcra Dosyalarının Kapananlara Oranı Aylara Göre":
                    TakibeKonulanIcraDosylarininKapanalaraOraniAylaraGore(pencere);
                    break;

                case "Takibe Konulan İcra Dosyalarının Kapananlara Oranı Yıllara Göre":
                    TakibeKonulanIcraDosylarininKapanalaraOraniYillaraGore(pencere);
                    break;

                case "Takibe Konulan İcra Dosyalarının Kapananlara Oranı Hukuk Bürolarına Göre":
                    TakibeKonulanIcraDosylarininKapanalaraOraniBurolaraGore(pencere);
                    break;

                case "Takibe Konulan İcra Dosyalarının Kapananlara Oranı Yılın Çeyreklerine Göre":
                    TakibeKonulanIcraDosylarininKapanalaraOraniyilinCeyreklereGore(pencere);
                    break;

                case "Takibe Konulan İcra Dosyalarının Kapananlara Oranı Hukuk Birimlerine Göre":
                    TakibeKonulanIcraDosylarininKapanalaraOraniBirimlereGore(pencere);
                    break;

                case "Takibe Konulan İcra Dosyalarının Kapananlara Oranı Hukuk Bölgelere Göre":
                    TakibeKonulanIcraDosylarininKapanalaraOraniBolgelereGore(pencere);
                    break;

                case "Takibe Konulan İcra Dosyalarının Kapananlara Oranı Hukuk Şubelere Göre":
                    TakibeKonulanIcraDosylarininKapanalaraOraniSubelereGore(pencere);
                    break;

                case "Takibe Konulan İcra Dosyalarının Kapananlara Oranı Hukuk Kredi Tiplerine Göre":
                    TakibeKonulanIcraDosylarininKapanalaraOraniKrediTipineGore(pencere);
                    break;

                case "İcra Dosyası Kapama Ortalaması Hukuk Bürolarına Göre":
                    IcraDosylarininKapamaOraniBurolaraGore(pencere);
                    break;

                case "Tahsilatların Hukuk Bölümlerine Göre Dağılımı":
                    TahsilatlarinBolumlereGoreDagilimi(pencere);
                    break;

                case "Tahsilatların Yılın Çeyreklerine Göre Dağılımı":
                    TahsilatlarinYilinCeyreklerineGoreDagilimi(pencere);
                    break;

                case "Tahsilatların Ödeme Yerine Göre Dağılımı":
                    TahsilatlarinOdemeYerineGoreDagilimi(pencere);
                    break;

                case "Tahsilatların Ödeme Tipine Göre Dağılımı":
                    TahsilatlarinOdemeTipineGoreDagilimi(pencere);
                    break;

                case "Tahsilatların Mahsup Kalemine Göre Dağılımı":
                    TahsilatlarinMahsupKalemineGoreDagilimi(pencere);
                    break;

                case "Tahsilatların Yıllara Göre Dağılımı":
                    TahsilatlarinYillaraGoreDagilimi(pencere);
                    break;

                case "Tahsilatların Aylara Göre Dağılımı":
                    TahsilatlarinAylaraGoreDagilimi(pencere);
                    break;

                case "Tahsilatların Bürolara Göre Dağılımı":
                    TahsilatlarinBurolaraGoreDagilimi(pencere);
                    break;

                case "Masrafların Hukuk Bölümlerine göre dağılımı":
                    MasraflarinHukukBolumlerineGoreDagilimi(pencere);
                    break;

                case "Masrafların Yılın Çeyreklerine Göre Dağılımı":
                    MasraflarinYilinCeyreklerineGoreDagilimi(pencere);
                    break;

                case "Masrafların Ödeme Yerine Göre Dağılımı":
                    MasraflarinOdemeYerineGoreDagilimi(pencere);
                    break;

                case "Masrafların Ödeme Tipine Göre Dağılımı":
                    MasraflarinOdemeTipineGoreDagilimi(pencere);
                    break;

                case "Masrafların Mahsup Kalemine Göre Dağılımı":
                    MasraflarinMahsupKalemineGoreDagilimi(pencere);
                    break;

                case "Tahsilatarın Bölgelere Göre Dağılımı":
                    TahsilatlarinBolgelereGoreDagilimi(pencere);
                    break;

                case "Tahsilatarın Şubelere Göre Dağılımı":
                    TahsilatlarinSubelereGoreDagilimi(pencere);
                    break;

                case "Masrafların Yıllara Göre Dağılımı":
                    MasraflarinYillaraGoreDagilimi(pencere);
                    break;

                case "Masrafların Aylara Göre Dağılımı":
                    MasraflarinAylaraGoreDagilimi(pencere);
                    break;

                case "En Çok Masraf Yapılan 50 Dosya":
                    EnCokMasrafYapilanElliDosya(pencere);
                    break;

                case "En Çok Masraf Yapan 10 Büro":
                    EnCokMasrafYapilanOnBuro(pencere);
                    break;

                case "En Çok Masraf Yapan 10 Sorumlu":
                    EnCokMasrafYapilanOnSorumlu(pencere);
                    break;

                case "Masrafların Ana Kategorisine Göre Dağılımı":
                    MasraflarinAnaKatagorisineGoreDagilimi(pencere);
                    break;

                case "Masrafların Alt Kategorilerine Göre Dağılımı":
                    MasraflarinAltKategorisineGoreDagilimi(pencere);
                    break;

                case "Masrafların Hukuk Bürolarına Göre Dağılımı":
                    MasraflarinBurolaraGoreDagilimi(pencere);
                    break;

                case "Avansların Hukuk Bölümlerine Göre Dağılımı":
                    AvanslarinBolumlereGoreDagilimi(pencere);
                    break;

                case "Avansların Hukuk Bürolarına Göre Dağılımı":
                    AvanslarinBurolaraGoreDagilimi(pencere);
                    break;

                case "Dava Dosyası Kapama Ortalaması Hukuk Bürolarına Göre":
                    DavaDosyasiKapamaOrtalamasıBurolaraGore(pencere);
                    break;

                case "Haciz Sayısı (Bürolara Göre)":
                    HacizSayisiBurolaraGore(pencere);
                    break;

                case "Satış Sayısı (Bürolara Göre)":
                    SatisSayisiBurolaraGore(pencere);
                    break;

                case "Tahsilat Sayısı (Bürolara Göre)":
                    TahsilatSatisiBurolaraGore(pencere);
                    break;

                case "Kapama Sayısı (Bürolara Göre)":
                    KapamaSayisiBurolaraGore(pencere);
                    break;

                case "Duruşma Sayısı (Bürolara Göre)":
                    DurusmaSayisiBurolaraGore(pencere);
                    break;

                case "Satış Sayısı (Aylara, Yıllara Göre)":
                    SatisSayisiAylaraYillaraGore(pencere);
                    break;

                case "Tahsilat Sayısı (Aylara, Yıllara Göre)":
                    TahsilatSayisiAylaraYillaraGore(pencere);
                    break;

                case "Kapama Sayısı (Aylara, Yıllara Göre)":
                    KapamaSayisiAylaraYillaraGore(pencere);
                    break;

                case "Açılan Dava Sayısı (Aylara, Yıllara Göre)":
                    AcilanDavaSayisiAylaraYillaraGore(pencere);
                    break;

                case "Açılan Takip Sayısı (Aylara, Yıllara Göre)":
                    AcilanTakipSayisiAylaraYillaraGore(pencere);
                    break;

                case "Bu Ay İçinde Tahsilat ve Derkenar İle Biten Dosya Sayısı":
                    BuAyIcindeTahsilatDerkenarIleBitenDosyaSayısı(pencere);
                    break;

                case "İcra Dosyalarinin Diğer Takip Kalemlerine Göre Dağilimi":
                    IcraDosyalarininDigerTakipKalemlerineGoreDagilimi(pencere);
                    break;

                case "İcra Dosyalarinin Alacak Miktarlarına Gore Dağilimi":
                    IcraDosyalarininAlacakMiktarlarinaGoreDagilimi(pencere);
                    break;

                case "Klasör Takipleri":
                    KlasorTakipleri(pencere);
                    break;

                case "Klasöre Bağlı İcra Takipleri":
                    KlasoreBagliIcraTakipleri(pencere);
                    break;

                case "Klasöre Bağlı Dava Takipleri":
                    KlasoreBagliDavaTakipleri(pencere);
                    break;

                case "Klasöre Bağlı Soruşturma Takipler":
                    KlasoreBagliSorusturmaTakipleri(pencere);
                    break;

                case "Krediler Bazında Klasörlerin Dağılımı":
                    KredilerBazindaKlasorlerinDagilimi(pencere);
                    break;

                case "Şubeler Bazında Klasörlerin Dağılımı":
                    SubelerBazindaKlasorlerinDagilimi(pencere);
                    break;

                case "Bürolara Bazında Klasörlerin Dağılımı":
                    BurolarBazindaKlasorlerinDagilimi(pencere);
                    break;

                case "Bölümlere Bazında Klasörlerin Dağılımı":
                    BolumlerBazindaKlasorlerinDagilimi(pencere);
                    break;

                case "Sözleşmeli Avukatlar Bazında Klasörlerin Dağılımı":
                    SozlesmeliBazindaKlasorlerinDagilimi(pencere);
                    break;

                case "Kadrolu Avukatlar Bazında Klasörlerin Dağılımı":
                    KadroluBazindaKlasorlerinDagilimi(pencere);
                    break;

                case "Geçen Aydan Klasörlerin Dağılımı":
                    GecenAydanKlasorlerinDagilimi(pencere);
                    break;

                case "Bu  Ay Gelen Klasörlerin Dağılımı":
                    BuAydanKlasorlerinDagilimi(pencere);
                    break;

                case "Tahsilatla Kapanan Klasörlerin Dağılımı":
                    TahsilatlaKapananKlasorlerinDagilimi(pencere);
                    break;

                case "Aciz/Derkanarla Kapanan Klasörlerin Dağılımı":
                    AcizDerkenarlaKapananKlasorlerinDagilimi(pencere);
                    break;

                case "Mahkeme İptal/Vazgeçme İle Kapanan Klasörlerin Dağılımı":
                    MahkemeIptalVazgecmeIleKlasorlerinDagilimi(pencere);
                    break;

                case "Tahsilat Bazında Klasörlerin Dağılımı":
                    TahsilatBazindaKlasorlerinDagilimi(pencere);
                    break;

                case "Yeni Döneme Devir Bazında Klasörlerin Dağılımı":
                    YeniDonemeDevirBazindaKlasorlerinDagilimi(pencere);
                    break;

                case "Benifikasyon Bazında Klasörlerin Dağılımı":
                    BenifikasyonBazindaKlasorlerinDagilimi(pencere);
                    break;

                case "Serbest Meslek Makbuzu Listesi (Müvekkillere Göre)":
                    SerbestMeslekMakbuzuMuvekkillere(pencere);
                    break;

                case "Serbest Meslek Makbuzu Listesi (Yıllara Göre)":
                    SerbestMeslekMakbuzuYillaraGore(pencere);
                    break;

                case "Serbest Meslek Makbuzu Listesi (Yıllara ve Modüllere Göre)":
                    SerbestMeslekMakbuzuYillaraModullereGore(pencere);
                    break;

                case "Kasa (Günlük-Kategorilere Göre)":
                    KasaGunlukKategorilereGore(pencere);
                    break;

                case "Kasa (Haftalık-Kategorilere Göre)":
                    KasaGunlukHaftalikKategorilereGore(pencere);
                    break;

                case "Kasa (Aylık-Kategorilere)":
                    KasaGunlukAylikKategorilereGore(pencere);
                    break;

                case "Kasa (Yıllık-Kategorilere Göre":
                    KasaGunlukYillikKategorilereGore(pencere);
                    break;

                case "Adliyesine Göre İşler":
                    AdliyesineGoreIsler(pencere);
                    break;

                case "Yerine Göre İşler":
                    YerineeGoreIsler(pencere);
                    break;

                case "Kategorisine Göre İşler":
                    KategorisineGoreIsler(pencere);
                    break;

                case "Yılına Göre İşler":
                    YilineGoreIsler(pencere);
                    break;

                case "Ayına Göre İşler":
                    AyinaGoreIsler(pencere);
                    break;

                case "Tarihine Göre İşler(Haftalık vs.)":
                    TarihineGoreIsler(pencere);
                    break;

                case "Gününe Göre İşler":
                    GununeGoreISler(pencere);
                    break;

                case "Müvekkile Göre İşler":
                    MuvekkilineGoreIsler(pencere);
                    break;

                case "Ücretlendirilmiş Yerine Göre İşler":
                    UcretlendirilmisYerineGoreIsler(pencere);
                    break;

                case "Ücretlendirilmiş Kategorisine Göre İşler":
                    UcretlendirilmisKategorisineGoreIsler(pencere);
                    break;

                case "Ücretlendirilmiş Tarihine Göre İşler(Haftalık vs.)":
                    UcretlendirilmisTarihineGoreIsler(pencere);
                    break;

                case "Ücretlendirilmiş Gününe Göre İşler":
                    UcretlendirilmisGununeGoreIsler(pencere);
                    break;

                case "Ücretlendirilmiş Yılına Göre İşler":
                    UcretlendirilmisYilinaGoreIsler(pencere);
                    break;

                case "Ücretlendirilmiş Ayına Göre İşler":
                    UcretlendirilmisAyinaGoreIsler(pencere);
                    break;

                case "Ücretlendirilmiş Müvekkile Göre İşler":
                    UcretlendirilmisMuvekkilineGoreIsler(pencere);
                    break;

                case "Karara Çıkan Dosyalar":
                    KararaCikanDosyalar(pencere);
                    break;

                default:
                    break;
            }
        }

        private void AcilanDavaSayisiAylaraYillaraGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            DavaPratikRapor rapor = new DavaPratikRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_DAVA_PRATIK_ARAMA_RAPORs.Where(vi => vi.DAVA_TARIHI != null);
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void AcilanTakipSayisiAylaraYillaraGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vii => vii.TAKIP_TARIHI != null);
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void AcizDerkenarlaKapananKlasorlerinDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporProjeGenel icra = new RaporProjeGenel();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_PROJE_GENELs.Where(vi => vi.DURUM == "ACİZ/DERKENAR" && vi.DURUM == "KISMEN ACİZ" && vi.DURUM == "DERKENAR");
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void AcizVeDerkenarlaKapananDosya(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor rapor = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();

            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vii => vii.DURUM == "ACİZ" || vii.DURUM == "DERKENAR");
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void AdliyesineGoreIsler(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_YAPILACAK_ISLERs.Where(vi => vi.IS_TARAF == "İşi Yapacak");
            PivotGridField[] fieldList = kasa.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void AvanslarinBolumlereGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            MasrafAvansBirlesik masraf = new MasrafAvansBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs;
            PivotGridField[] fieldList = masraf.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void AvanslarinBurolaraGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            MasrafAvansBirlesik masraf = new MasrafAvansBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs;
            PivotGridField[] fieldList = masraf.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void AyinaGoreIsler(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_YAPILACAK_ISLERs;
            PivotGridField[] fieldList = kasa.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void BenifikasyonBazindaKlasorlerinDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporProjeGenel icra = new RaporProjeGenel();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_PROJE_GENELs.Where(vii => vii.DURUM == "BONİFİKASYON");
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void BirSonrakiAyaDevreden(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor rapor = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vii => vii.DURUM == "DERDEST" && vii.TAKIP_TARIHI.Value.Month < DateTime.Now.Month);
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void BolumlerBazindaKlasorlerinDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporProjeGenel icra = new RaporProjeGenel();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_PROJE_GENELs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void btnGrafikSecti_Click(object sender, EventArgs e)
        {
                SaveFileTools.Exporter(chartControl1, SecilenKayitTipi);

            popupContainerControl1.Hide();
        }

        private void btnListeSecti_Click(object sender, EventArgs e)
        {
                SaveFileTools.Exporter(extendedPivotControl1, SecilenKayitTipi);

            popupContainerControl1.Hide();
        }

        private void btnPopupKapat_Click(object sender, EventArgs e)
        {
            popupContainerControl1.Hide();
        }

        private void BuAydanKlasorlerinDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporProjeGenel icra = new RaporProjeGenel();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_PROJE_GENELs.Where(vi => vi.BASLANGIC_TARIHI.Month >= DateTime.Now.Month);
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void BuAyIcindeGelenDosyaSayisi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor rapor = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vii => vii.DURUM == "DERDEST" || vii.DURUM == "EVRAK").Where(vii => vii.TAKIP_TARIHI.Value.Month == DateTime.Now.Month);
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void BuAyIcindeTahsilatDerkenarIleBitenDosyaSayısı(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor rapor = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            DateTime dtilk = StartMonthDatePre();
            DateTime dtson = EndMonthDatePre();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(t => t.DURUM.Contains("DERKENAR") || t.DURUM.Contains("ACİZ/DERKENAR") || t.DURUM.Contains("İNFAZ")).Where(vii => vii.KAPAMA_TARIHI <= dtilk && vii.KAPAMA_TARIHI >= dtson);
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
            if (dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(t => t.DURUM.Contains("DERKENAR") || t.DURUM.Contains("ACİZ/DERKENAR") || t.DURUM.Contains("İNFAZ")).Where(vii => vii.KAPAMA_TARIHI <= dtilk && vii.KAPAMA_TARIHI >= dtson).Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunanmamıştır");
        }

        private void BurolarBazindaKlasorlerinDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporProjeGenel icra = new RaporProjeGenel();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_PROJE_GENELs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void chBoxSatirToplami_CheckedChanged(object sender, EventArgs e)
        {   //DevExpress v2012 Upgrade
            //extendedPivotControl1.OptionsChartDataSource.ShowColumnGrandTotals = chBoxSatirToplami.Checked;
        }

        private void chBoxSutunToplami_CheckedChanged(object sender, EventArgs e)
        {   //DevExpress v2012 Upgrade
            //extendedPivotControl1.OptionsChartDataSource.ShowRowGrandTotals = chBoxSutunToplami.Checked;
        }

        private void chBoxYonDegis_CheckedChanged(object sender, EventArgs e)
        {   //DevExpress v2012 Upgrade
            //extendedPivotControl1.OptionsChartDataSource.ChartDataVertical = chBoxYonDegis.Checked;
        }

        private void DavaDosyalarininBolgelereGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            DavaPratikRapor rapor = new DavaPratikRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_DAVA_PRATIK_ARAMA_RAPORs;
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void DavaDosyalarininBolumlerineGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            DavaPratikRapor rapor = new DavaPratikRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_DAVA_PRATIK_ARAMA_RAPORs;
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void davaDosyalarininBurolaraGore(string pencere)
        {
            string s = CompInfo.CmpNfoList[0].ConStr;
            AvukatProViewDataContext dbV = Program.dbV;
            DavaPratikRapor rapor = new DavaPratikRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_DAVA_PRATIK_ARAMA_RAPORs;
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void davaDosyalarininBurolaraIntikalTGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            DavaPratikRapor rapor = new DavaPratikRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_DAVA_PRATIK_ARAMA_RAPORs;
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void DavaDosyalarininDavaTaleplerineGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            DavaPratikRapor rapor = new DavaPratikRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_DAVA_PRATIK_ARAMA_RAPORs;
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void davaDosyalarininDavaTGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            DavaPratikRapor rapor = new DavaPratikRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_DAVA_PRATIK_ARAMA_RAPORs;
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void DavaDosyalarininDAvaTipineGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            DavaPratikRapor rapor = new DavaPratikRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_DAVA_PRATIK_ARAMA_RAPORs;
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void DavaDosyalarininIzleyenAvukatlaraGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            DavaPratikRapor rapor = new DavaPratikRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_DAVA_PRATIK_ARAMA_RAPORs;
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void DavaDosyalarininKazanilanKaybedileneGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            mahkemeHukum huk = new mahkemeHukum();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_HUKUM_TAKIP_RAPORs;
            PivotGridField[] fieldList = huk.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void DavaDosyalarininSorumluAvukatlaraGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            DavaPratikRapor rapor = new DavaPratikRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_DAVA_PRATIK_ARAMA_RAPORs;
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void DavaDosyalarininSubelereGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            DavaPratikRapor rapor = new DavaPratikRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_DAVA_PRATIK_ARAMA_RAPORs;
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void DavaDosyasiKapamaOrtalamasıBurolaraGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            DavaPratikRapor rapor = new DavaPratikRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_DAVA_PRATIK_ARAMA_RAPORs;
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void DosyalarinDurumlarinaGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            DavaPratikRapor rapor = new DavaPratikRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_DAVA_PRATIK_ARAMA_RAPORs;
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void DurusmaSayisiBurolaraGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            DurusmaDavaGenelRapor durusma = new DurusmaDavaGenelRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_DURUSMA_DAVA_GENEL_TARAFLI_RAPORs.Where(vii => vii.CELSE_MI != true);
            PivotGridField[] fieldList = durusma.GetPivotFields(pencere);

            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
            if (sonuc.Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void DuzeltilerekLeheOnananlar()
        {
            AvukatProViewDataContext dbV = Program.dbV;
            TemyizTakipRapor temyiz = new TemyizTakipRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var obj = dbV.R_TEMYIZ_TAKIP_RAPORs.Where(vi => vi.HUKUM_ANLAM == "ONAMA").Where(vii => vii.DAVA_EDEN_SIFAT == "DAVACI").Where(viii => viii.KARAR_TIP == "Düzelterek Onama");
            PivotGridField[] fieldList = temyiz.GetPivotFields();
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = obj;
            PivotLayoutGoster("Düzeltilerek Lehe Onananlar");
            if (dbV.R_TEMYIZ_TAKIP_RAPORs.Where(vi => vi.HUKUM_ANLAM == "ONAMA").Where(vii => vii.DAVA_EDEN_SIFAT == "DAVACI").Where(viii => viii.KARAR_TIP == "Düzelterek Onama").Count() <= 0)
                XtraMessageBox.Show("Aradığınız Kriterlere Uygun Kayıt Bulunamamıştır");
        }

        private void EnCokMasrafYapilanElliDosya(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            MasrafAvansBirlesik masraf = new MasrafAvansBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs.OrderByDescending(v => v.TOPLAM_TUTAR).Take(50).ToList();
            PivotGridField[] fieldList = masraf.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void EnCokMasrafYapilanOnBuro(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            MasrafAvansBirlesik masraf = new MasrafAvansBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs.OrderByDescending(v => v.TOPLAM_TUTAR).Take(10).ToList();
            PivotGridField[] fieldList = masraf.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void EnCokMasrafYapilanOnSorumlu(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            MasrafAvansBirlesik masraf = new MasrafAvansBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs.OrderByDescending(v => v.TOPLAM_TUTAR).Take(10).ToList();
            PivotGridField[] fieldList = masraf.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private DateTime EndMonthDatePre()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);
        }

        private void GecenAydanKlasorlerinDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporProjeGenel icra = new RaporProjeGenel();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_PROJE_GENELs.Where(vi => vi.BASLANGIC_TARIHI.Month <= DateTime.Now.Month);
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void GununeGoreISler(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_YAPILACAK_ISLERs;
            PivotGridField[] fieldList = kasa.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void HacizSayisiBurolaraGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            HacizliMallarRapor rapor = new HacizliMallarRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_HACIZLI_MALLAR_MASTER_CHILD_RAPORs;
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void IcraDosyalarininAlacakMiktarlarinaGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void IcraDosyalarininAlacakNedenlerineGoreDagilimiYillaraGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void IcraDosyalarininDigerTakipKalemlerineGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void IcraDosyalarininDurumlarineGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void IcraDosyalarininFormTipineGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void IcraDosyalarininIcraAlacakNedenlerineGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void IcraDosyalarininIcraTaleplerineGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void IcraDosyalarininIzleyenAvukatlaraGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void IcraDosyalarininSorumluAvukatlaraGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void IcraDosyalarininSubelereGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void IcraDosyayalarininBolumlereGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void IcraDosylarininBolgelereGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void IcraDosylarininBurolaraGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void IcraDosylarininKapamaOraniBurolaraGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void IcraDosylarininKrediTipineGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void KadroluBazindaKlasorlerinDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporProjeGenel icra = new RaporProjeGenel();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_PROJE_GENELs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void KapamaSayisiAylaraYillaraGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vii => vii.KAPAMA_TARIHI != null);
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void KapamaSayisiBurolaraGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vii => vii.KAPAMA_TARIHI != null);
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void KararaCikanDosyalar(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            DavaPratikRapor rapor = new DavaPratikRapor();
            //extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            //var sonuc = dbV.R_DAVA_PRATIK_ARAMA_RAPORs.Where(vi => vi.DAVA_TARIHI != null);
            //PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            //extendedPivotControl1.Fields.AddRange(fieldList);
            //extendedPivotControl1.DataSource = sonuc;

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            DataTable dt = cn.GetDataTable("SELECT * FROM R_HUKUM_TAKIP_RAPOR_YENI");

            foreach (DataColumn col in dt.Columns)
            {
                if (col.ColumnName == "Mahkeme" || col.ColumnName == "No" || col.ColumnName == "Görev" || col.ColumnName == "Dava Nedeni" || col.ColumnName == "Dava Tarafı" || col.ColumnName == "Sorumlu" || col.ColumnName == "Karşı Taraf Adı" || col.ColumnName == "Müvekkil Adı")
                    extendedPivotControl1.Fields.Add(col.ColumnName, PivotArea.FilterArea);
                else if (col.ColumnName == "Dava Tutar" || col.ColumnName == "Tutar" || col.ColumnName == "Hüküm Değeri")
                    extendedPivotControl1.Fields.Add(col.ColumnName, PivotArea.DataArea);
                else if (col.ColumnName == "Dava Tip" || col.ColumnName == "Anlam" || col.ColumnName == "Hüküm T." || col.ColumnName == "Hüküm Tipi" || col.ColumnName == "Dava Konusu" || col.ColumnName == "Durum" || col.ColumnName == "Hüküm")
                    extendedPivotControl1.Fields.Add(col.ColumnName, PivotArea.RowArea);
                else
                {
                    extendedPivotControl1.Fields.Add(col.ColumnName, PivotArea.FilterArea);
                    extendedPivotControl1.Fields[extendedPivotControl1.Fields.Count - 1].Visible = false;

                    if (col.ColumnName == "TARAF_CARI_ID")
                    {
                        extendedPivotControl1.Fields[extendedPivotControl1.Fields.Count - 1].SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
                        extendedPivotControl1.Fields[extendedPivotControl1.Fields.Count - 1].Caption = "Dosya Sayısı";
                        extendedPivotControl1.Fields[extendedPivotControl1.Fields.Count - 1].Visible = true;
                        extendedPivotControl1.Fields[extendedPivotControl1.Fields.Count - 1].Area = PivotArea.DataArea;
                    }
                }
            }
            extendedPivotControl1.DataSource = dt;

            //PivotGridField[] fieldList = rapor.KararaCikanDosyalar();
            //extendedPivotControl1.Fields.AddRange(fieldList);

            PivotLayoutGoster(pencere);
        }

        private void KasaGunlukAylikKategorilereGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporKasaHareketleri kasa = new RaporKasaHareketleri();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_KASA_HAREKETLERIs;
            PivotGridField[] fieldList = kasa.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void KasaGunlukHaftalikKategorilereGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporKasaHareketleri kasa = new RaporKasaHareketleri();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_KASA_HAREKETLERIs;
            PivotGridField[] fieldList = kasa.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void KasaGunlukKategorilereGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporKasaHareketleri kasa = new RaporKasaHareketleri();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_KASA_HAREKETLERIs;
            PivotGridField[] fieldList = kasa.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void KasaGunlukYillikKategorilereGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporKasaHareketleri kasa = new RaporKasaHareketleri();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_KASA_HAREKETLERIs;
            PivotGridField[] fieldList = kasa.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void KategorisineGoreIsler(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_YAPILACAK_ISLERs;
            PivotGridField[] fieldList = kasa.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void KlasoreBagliDavaTakipleri(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporProjeDava dava = new RaporProjeDava();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_PROJE_DAVAs;
            PivotGridField[] fieldList = dava.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void KlasoreBagliIcraTakipleri(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporProjeIcra icra = new RaporProjeIcra();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_PROJE_ICRAs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void KlasoreBagliSorusturmaTakipleri(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporProjeSorusturma sorusturma = new RaporProjeSorusturma();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_PROJE_SORUSTURMAs;
            PivotGridField[] fieldList = sorusturma.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void KlasorTakipleri(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporProjeGenel icra = new RaporProjeGenel();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_PROJE_GENELs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void KredilerBazindaKlasorlerinDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporProjeAlacakNeden icra = new RaporProjeAlacakNeden();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_PROJE_ALACAK_NEDEN_TAKIPLI_TAKIPSIZs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                chartControl1.SeriesTemplate.ChangeView((DevExpress.XtraCharts.ViewType)lookGrafikSecimi.EditValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MahkemeIptalVazgecmeIleKlasorlerinDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporProjeGenel icra = new RaporProjeGenel();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_PROJE_GENELs.Where(vii => vii.DURUM == "MAHKEME KARARI İLE İPTAL" && vii.DURUM == "FERAGAT");
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void MasraflarinAltKategorisineGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            MasrafAvansBirlesik masraf = new MasrafAvansBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs;
            PivotGridField[] fieldList = masraf.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void MasraflarinAnaKatagorisineGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            MasrafAvansBirlesik masraf = new MasrafAvansBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs;
            PivotGridField[] fieldList = masraf.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void MasraflarinAylaraGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            MasrafAvansBirlesik masraf = new MasrafAvansBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs;
            PivotGridField[] fieldList = masraf.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void MasraflarinBurolaraGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            MasrafAvansBirlesik masraf = new MasrafAvansBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs;
            PivotGridField[] fieldList = masraf.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void MasraflarinHukukBolumlerineGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            MasrafAvansBirlesik masraf = new MasrafAvansBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs;
            PivotGridField[] fieldList = masraf.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void MasraflarinMahsupKalemineGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            MasrafAvansBirlesik masraf = new MasrafAvansBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs;
            PivotGridField[] fieldList = masraf.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void MasraflarinOdemeTipineGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            MasrafAvansBirlesik masraf = new MasrafAvansBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs;
            PivotGridField[] fieldList = masraf.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void MasraflarinOdemeYerineGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            MasrafAvansBirlesik masraf = new MasrafAvansBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs;
            PivotGridField[] fieldList = masraf.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void MasraflarinYilinCeyreklerineGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            MasrafAvansBirlesik masraf = new MasrafAvansBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs;
            PivotGridField[] fieldList = masraf.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void MasraflarinYillaraGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            MasrafAvansBirlesik masraf = new MasrafAvansBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_MASRAF_AVANS_BIRLESIKs;
            PivotGridField[] fieldList = masraf.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void MuvekkilineGoreIsler(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_YAPILACAK_ISLERs.Where(vi => vi.IS_TARAF == "İş Muhatabı (Kime ?)");
            PivotGridField[] fieldList = kasa.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void pivotGrid_Load(object sender, EventArgs e)
        {
            lookGrafikSecimi.Properties.DataSource = Enum.GetValues(typeof(DevExpress.XtraCharts.ViewType));

            //chBoxSutunToplami.Checked = extendedPivotControl1.OptionsChartDataSource.ShowColumnGrandTotals;
            //chBoxSatirToplami.Checked = extendedPivotControl1.OptionsChartDataSource.ShowRowGrandTotals;
            // chBoxYonDegis.Checked = extendedPivotControl1.OptionsChartDataSource.ChartDataVertical ;

            lookGrafikSecimi.SelectedText = "Full-Stacked Bar";

            // dataNavigatorExtended2.MyChartControl = this.chartControl1;
        }

        private void PivotLayoutGoster(string pencere)
        {
            if (pencere.Contains('/')) pencere = pencere.Replace('/', '-').ToString();
            if (PivotLayoutXmlOku() != null)
                if (File.Exists(PivotLayoutXmlOku() + pencere + ".yyl"))
                    extendedPivotControl1.RestoreLayoutFromXml(PivotLayoutXmlOku() + pencere + ".yyl", OptionsLayoutBase.FullLayout);
        }

        private string PivotLayoutXmlOku()
        {
            string userAd = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.KULLANICI_ADI;
            string _path = Application.StartupPath + "\\Pivotlayouts\\" + userAd + "\\";
            if (Directory.Exists(_path))
                return _path;
            return null;
        }

        private void ResmiTaahutleriAlinmisDosyalar(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            masterIcraBorcluTaahutGenelRapor icraborclu = new masterIcraBorcluTaahutGenelRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var obj = dbV.R_Master_IcraBorcluTaahhutGenel_Rapors.Where(vii => vii.RESMI_MI == 1);
            PivotGridField[] fieldList = icraborclu.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = obj;
            PivotLayoutGoster(pencere);
        }

        private void SatisSayisiAylaraYillaraGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            IcraSatisGenel rapor = new IcraSatisGenel();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_Master_IcraSatisGenel_Rapors;
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void SatisSayisiBurolaraGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            IcraSatisGenel rapor = new IcraSatisGenel();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_Master_IcraSatisGenel_Rapors;
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void SerbestMeslekMakbuzuMuvekkillere(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rSerbestMeslekMakbuzuRapor masraf = new rSerbestMeslekMakbuzuRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs;
            PivotGridField[] fieldList = masraf.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void SerbestMeslekMakbuzuYillaraGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rSerbestMeslekMakbuzuRapor masraf = new rSerbestMeslekMakbuzuRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs;
            PivotGridField[] fieldList = masraf.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void SerbestMeslekMakbuzuYillaraModullereGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rSerbestMeslekMakbuzuRapor masraf = new rSerbestMeslekMakbuzuRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_SERBEST_MESLEK_MAKBUZU_RAPORs;
            PivotGridField[] fieldList = masraf.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void SozlesmeliBazindaKlasorlerinDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporProjeGenel icra = new RaporProjeGenel();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_PROJE_GENELs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private DateTime StartMonthDatePre()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
        }

        private void SubelerBazindaKlasorlerinDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporProjeGenel icra = new RaporProjeGenel();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_PROJE_GENELs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TahsilatBazindaKlasorlerinDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporProjeGenel icra = new RaporProjeGenel();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_PROJE_GENELs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TahsilatlaKapananKlasorlerinDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporProjeGenel icra = new RaporProjeGenel();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_PROJE_GENELs.Where(vii => vii.DURUM == "KISMİ İNFAZ" && vii.DURUM == "İNFAZ");
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TahsilatlarinAylaraGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            BorcluOdemeBirlesik tahsilat = new BorcluOdemeBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs;
            PivotGridField[] fieldList = tahsilat.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TahsilatlarinBolgelereGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            BorcluOdemeBirlesik tahsilat = new BorcluOdemeBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs;
            PivotGridField[] fieldList = tahsilat.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TahsilatlarinBolumlereGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            BorcluOdemeBirlesik tahsilat = new BorcluOdemeBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs;
            PivotGridField[] fieldList = tahsilat.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TahsilatlarinBurolaraGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            BorcluOdemeBirlesik tahsilat = new BorcluOdemeBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs;
            PivotGridField[] fieldList = tahsilat.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TahsilatlarinMahsupKalemineGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            BorcluOdemeBirlesik tahsilat = new BorcluOdemeBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs;
            PivotGridField[] fieldList = tahsilat.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TahsilatlarinOdemeTipineGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            BorcluOdemeBirlesik tahsilat = new BorcluOdemeBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs;
            PivotGridField[] fieldList = tahsilat.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TahsilatlarinOdemeYerineGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            BorcluOdemeBirlesik tahsilat = new BorcluOdemeBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs;
            PivotGridField[] fieldList = tahsilat.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TahsilatlarinSubelereGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            BorcluOdemeBirlesik tahsilat = new BorcluOdemeBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs;
            PivotGridField[] fieldList = tahsilat.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TahsilatlarinYilinCeyreklerineGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            BorcluOdemeBirlesik tahsilat = new BorcluOdemeBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs;
            PivotGridField[] fieldList = tahsilat.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TahsilatlarinYillaraGoreDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            BorcluOdemeBirlesik tahsilat = new BorcluOdemeBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs;
            PivotGridField[] fieldList = tahsilat.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TahsilatSatisiBurolaraGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            BorcluOdemeBirlesik tahsilat = new BorcluOdemeBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs;
            PivotGridField[] fieldList = tahsilat.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TahsilatSayisiAylaraYillaraGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            BorcluOdemeBirlesik tahsilat = new BorcluOdemeBirlesik();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_BORCLU_ODEME_BIRLESIKs;
            PivotGridField[] fieldList = tahsilat.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TakibeKonulanIcraDosylarininKapanalaraOraniAylaraGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor bankali = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var obj = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = bankali.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = obj;
            PivotLayoutGoster(pencere);
        }

        private void TakibeKonulanIcraDosylarininKapanalaraOraniBirimlereGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TakibeKonulanIcraDosylarininKapanalaraOraniBolgelereGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TakibeKonulanIcraDosylarininKapanalaraOraniBurolaraGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TakibeKonulanIcraDosylarininKapanalaraOraniKrediTipineGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TakibeKonulanIcraDosylarininKapanalaraOraniSubelereGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TakibeKonulanIcraDosylarininKapanalaraOraniyilinCeyreklereGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TakibeKonulanIcraDosylarininKapanalaraOraniYillaraGore(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            rBankalaiTaraflisorumluRapor icra = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TarihineGoreIsler(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_YAPILACAK_ISLERs;
            PivotGridField[] fieldList = kasa.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void TemyizEdilenDosyalar(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            DavaPratikRapor rapor = new DavaPratikRapor();
            extendedPivotControl1.Fields.Clear();

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            DataTable dt = cn.GetDataTable("SELECT * FROM R_TEMYIZ_TAKIP_RAPOR_YENI");

            foreach (DataColumn col in dt.Columns)
            {
                if (col.ColumnName == "DAVAPOZISYONU" || col.ColumnName == "Yer. Mahkeme" || col.ColumnName == "Yer. No" || col.ColumnName == "Yer. Görev" || col.ColumnName == "Dava Nedeni" || col.ColumnName == "Sorumlu" || col.ColumnName == "Tebliğ T." || col.ColumnName == "Dava Konusu" || col.ColumnName == "Hüküm" || col.ColumnName == "Kesinleşme T." || col.ColumnName == "Müvekkil Adı" || col.ColumnName == "Karşı Taraf Adı" || col.ColumnName == "İzleyen" || col.ColumnName == "Başvuru Tip" || col.ColumnName == "Temyiz Eden")
                    extendedPivotControl1.Fields.Add(col.ColumnName, PivotArea.FilterArea);
                //else if (col.ColumnName == "" || col.ColumnName == "")
                //    extendedPivotControl1.Fields.Add(col.ColumnName, PivotArea.DataArea);
                else if (col.ColumnName == "Temyiz T" || col.ColumnName == "Tem Durum" || col.ColumnName == "Yük. Mahkeme" || col.ColumnName == "Yük. No" || col.ColumnName == "Yük. Görev" || col.ColumnName == "Yük Anlam" || col.ColumnName == "Temyiz Hüküm" || col.ColumnName == "Yer Anlam" || col.ColumnName == "Dava Tip")
                    extendedPivotControl1.Fields.Add(col.ColumnName, PivotArea.RowArea);
                else
                {
                    extendedPivotControl1.Fields.Add(col.ColumnName, PivotArea.FilterArea);
                    extendedPivotControl1.Fields[extendedPivotControl1.Fields.Count - 1].Visible = false;

                    if (col.ColumnName == "CARI_ID")
                    {
                        extendedPivotControl1.Fields[extendedPivotControl1.Fields.Count - 1].SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
                        extendedPivotControl1.Fields[extendedPivotControl1.Fields.Count - 1].Caption = "Dosya Sayısı";
                        extendedPivotControl1.Fields[extendedPivotControl1.Fields.Count - 1].Visible = true;
                        extendedPivotControl1.Fields[extendedPivotControl1.Fields.Count - 1].Area = PivotArea.DataArea;
                    }
                }
            }
            extendedPivotControl1.DataSource = dt;

            //PivotGridField[] fieldList = rapor.KararaCikanDosyalar();
            //extendedPivotControl1.Fields.AddRange(fieldList);

            PivotLayoutGoster(pencere);
        }

        private void ToplamDevredenDosyaSayisi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;
            rBankalaiTaraflisorumluRapor rapor = new rBankalaiTaraflisorumluRapor();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORs.Where(vii => vii.DURUM == "DERDEST" || vii.DURUM == "EVRAK");
            PivotGridField[] fieldList = rapor.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void UcretlendirilmisAyinaGoreIsler(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs;
            PivotGridField[] fieldList = kasa.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void UcretlendirilmisGununeGoreIsler(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs;
            PivotGridField[] fieldList = kasa.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void UcretlendirilmisKategorisineGoreIsler(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs;
            PivotGridField[] fieldList = kasa.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void UcretlendirilmisMuvekkilineGoreIsler(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs.Where(vi => vi.IS_TARAF == "İş Muhatabı (Kime ?)");
            PivotGridField[] fieldList = kasa.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void UcretlendirilmisTarihineGoreIsler(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs;
            PivotGridField[] fieldList = kasa.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void UcretlendirilmisYerineGoreIsler(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs.Where(vi => vi.IS_TARAF == "İşi Yapacak");
            PivotGridField[] fieldList = kasa.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void UcretlendirilmisYilinaGoreIsler(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_YAPILACAK_IS_SURE_DETAYs;
            PivotGridField[] fieldList = kasa.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void YeniDonemeDevirBazindaKlasorlerinDagilimi(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            RaporProjeGenel icra = new RaporProjeGenel();
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_PROJE_GENELs;
            PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void YerineeGoreIsler(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_YAPILACAK_ISLERs.Where(vi => vi.IS_TARAF == "İşi Yapacak");
            PivotGridField[] fieldList = kasa.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        private void YilineGoreIsler(string pencere)
        {
            AvukatProViewDataContext dbV = Program.dbV;

            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            var sonuc = dbV.R_RAPOR_YAPILACAK_ISLERs;
            PivotGridField[] fieldList = kasa.GetPivotFields(pencere);
            extendedPivotControl1.Fields.AddRange(fieldList);
            extendedPivotControl1.DataSource = sonuc;
            PivotLayoutGoster(pencere);
        }

        #region gökhanın yapıldıkları

        private void DavaDosyayaGore()
        {
            DBDataContext db = Program.db;
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();

            var sonuc = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_TARAFLIs.GroupBy(vi => vi.ID).Select(vi => vi.First()); ;

            PivotGridField fieldGorev = new PivotGridField("Gorev", PivotArea.FilterArea);
            PivotGridField fieldDavaKonusu = new PivotGridField("Dava_Konusu", PivotArea.FilterArea);
            PivotGridField fieldDavaTarihi = new PivotGridField("Dava_T", PivotArea.FilterArea);
            PivotGridField fieldMahkemesi = new PivotGridField("Mahkemesi", PivotArea.RowArea);
            PivotGridField fieldDavaTipi = new PivotGridField("Dava_Tipi", PivotArea.FilterArea);
            PivotGridField fieldDosyaSayisi = new PivotGridField("ID", PivotArea.DataArea);
            PivotGridField fieldDavayaCevTarihiYil = new PivotGridField("Davaya_Cev_T", PivotArea.FilterArea);
            PivotGridField fieldDavayaCevTarihiCeyrek = new PivotGridField("Davaya_Cev_T", PivotArea.FilterArea);
            PivotGridField fieldArsivTarihiYil = new PivotGridField("Arsiv_T", PivotArea.FilterArea);
            PivotGridField fieldArsivTarihiCeyrek = new PivotGridField("Arsiv_T", PivotArea.FilterArea);
            PivotGridField fieldAvukataGelsTarihiYil = new PivotGridField("Avukata_Gelis_T", PivotArea.ColumnArea);
            PivotGridField fieldAvukataGelsTarihiCeyrek = new PivotGridField("Avukata_Gelis_T", PivotArea.FilterArea);
            PivotGridField fieldDurum = new PivotGridField("DURUM", PivotArea.FilterArea);

            //fieldMahkemesi.SummaryType = PivotSummaryType.Count;
            fieldDosyaSayisi.SummaryType = PivotSummaryType.Count;
            fieldArsivTarihiYil.GroupInterval = PivotGroupInterval.DateYear;
            fieldArsivTarihiCeyrek.GroupInterval = PivotGroupInterval.DateQuarter;
            fieldAvukataGelsTarihiYil.GroupInterval = PivotGroupInterval.DateYear;
            fieldAvukataGelsTarihiCeyrek.GroupInterval = PivotGroupInterval.DateQuarter;
            fieldDavayaCevTarihiCeyrek.GroupInterval = PivotGroupInterval.DateQuarter;
            fieldDavayaCevTarihiYil.GroupInterval = PivotGroupInterval.DateYear;

            fieldDurum.Caption = "Durum";
            fieldGorev.Caption = "Görev";
            fieldDavaKonusu.Caption = "Dava Konusu";
            fieldDavaTarihi.Caption = "Dava Tarihi";
            fieldMahkemesi.Caption = "Mahkemesi";
            fieldDavaTipi.Caption = "Dava Tipi";
            fieldDosyaSayisi.Caption = "Dosya Sayısı";
            fieldDavayaCevTarihiYil.Caption = "Esas Dava Yil";
            fieldDavayaCevTarihiCeyrek.Caption = "Esas Dava Çeyrek";
            fieldArsivTarihiYil.Caption = "Arşiv Yıl";
            fieldArsivTarihiCeyrek.Caption = "Arşiv Çeyrek";
            fieldAvukataGelsTarihiCeyrek.Caption = "İntikal Çeyrek";
            fieldAvukataGelsTarihiYil.Caption = "İntikal Yıl";

            extendedPivotControl1.DataSource = sonuc;
            extendedPivotControl1.Fields.AddRange(new[] {fieldArsivTarihiYil,fieldArsivTarihiCeyrek, fieldAvukataGelsTarihiYil,fieldAvukataGelsTarihiCeyrek, fieldDavaKonusu,
                                                     fieldDavaTarihi, fieldDavaTipi ,fieldDavayaCevTarihiYil ,fieldDavayaCevTarihiCeyrek , fieldDurum , fieldGorev, fieldMahkemesi, fieldDosyaSayisi});
        }

        private void DavaSorumlusunaGore()
        {
            DBDataContext db = Program.db;
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();

            var sonuc = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_SRMLULUs;

            PivotGridField fieldGorev = new PivotGridField("Gorev", PivotArea.FilterArea);
            PivotGridField fieldDavaKonusu = new PivotGridField("Dava_Konusu", PivotArea.ColumnArea);
            PivotGridField fieldDavaTarihi = new PivotGridField("Dava_T", PivotArea.FilterArea);
            PivotGridField fieldMahkemesi = new PivotGridField("Mahkemesi", PivotArea.FilterArea);
            PivotGridField fieldDavaTipi = new PivotGridField("Dava_Tipi", PivotArea.FilterArea);
            PivotGridField fieldDurum = new PivotGridField("DURUM", PivotArea.FilterArea);
            PivotGridField fieldSorumlununAdi = new PivotGridField("Sorumlu_Adi", PivotArea.RowArea);
            PivotGridField fieldDosyaSayisi = new PivotGridField("ID", PivotArea.DataArea);
            PivotGridField fieldDavayaCevTarihiYil = new PivotGridField("Davaya_Cev_T", PivotArea.FilterArea);
            PivotGridField fieldDavayaCevTarihiCeyrek = new PivotGridField("Davaya_Cev_T", PivotArea.FilterArea);
            PivotGridField fieldArsivTarihiYil = new PivotGridField("Arsiv_T", PivotArea.FilterArea);
            PivotGridField fieldArsivTarihiCeyrek = new PivotGridField("Arsiv_T", PivotArea.FilterArea);
            PivotGridField fieldAvukataGelsTarihiYil = new PivotGridField("Avukata_Gelis_T", PivotArea.FilterArea);
            PivotGridField fieldAvukataGelsTarihiCeyrek = new PivotGridField("Avukata_Gelis_T", PivotArea.FilterArea);

            fieldDosyaSayisi.SummaryType = PivotSummaryType.Count;
            fieldDavayaCevTarihiCeyrek.GroupInterval = PivotGroupInterval.DateQuarter;
            fieldDavayaCevTarihiYil.GroupInterval = PivotGroupInterval.DateYear;
            fieldArsivTarihiYil.GroupInterval = PivotGroupInterval.DateYear;
            fieldArsivTarihiCeyrek.GroupInterval = PivotGroupInterval.DateQuarter;
            fieldAvukataGelsTarihiYil.GroupInterval = PivotGroupInterval.DateYear;
            fieldAvukataGelsTarihiCeyrek.GroupInterval = PivotGroupInterval.DateQuarter;
            fieldMahkemesi.SummaryType = PivotSummaryType.Count;

            fieldDurum.Caption = "Durum";
            fieldGorev.Caption = "Görev";
            fieldDavaKonusu.Caption = "Dava Konusu";
            fieldDavaTarihi.Caption = "Dava Tarihi";
            fieldDavaTarihi.Caption = "Dava Tipi";
            fieldSorumlununAdi.Caption = "Sorumlunun Adı";
            fieldDosyaSayisi.Caption = "Dosya Sayısı";
            fieldArsivTarihiYil.Caption = "Arşiv Yıl";
            fieldArsivTarihiCeyrek.Caption = "Arşiv Çeyrek";
            fieldAvukataGelsTarihiCeyrek.Caption = "İntikal Çeyrek";
            fieldAvukataGelsTarihiYil.Caption = "İntikal Yıl";
            fieldDavayaCevTarihiYil.Caption = "Esas Dava Yil";
            fieldDavayaCevTarihiCeyrek.Caption = "Esas Dava Çeyrek";

            extendedPivotControl1.DataSource = sonuc;
            extendedPivotControl1.Fields.AddRange(new[] {fieldArsivTarihiYil,fieldArsivTarihiCeyrek, fieldAvukataGelsTarihiYil,fieldAvukataGelsTarihiCeyrek, fieldDavaKonusu,
                                                     fieldDavaTarihi, fieldDavaTipi ,fieldDavayaCevTarihiYil ,fieldDavayaCevTarihiCeyrek , fieldDurum , fieldGorev, fieldMahkemesi, fieldSorumlununAdi, fieldDosyaSayisi});
        }

        private void DavaTarafinaGore()
        {
            DBDataContext db = Program.db;
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();

            var sonuc = db.R_AV001_DAVA_GNL_BLGLRI_HSPSIZ_TARAFLIs;
            PivotGridField fieldGorev = new PivotGridField("Gorev", PivotArea.FilterArea);
            PivotGridField fieldDavaKonusu = new PivotGridField("Dava_Konusu", PivotArea.ColumnArea);
            PivotGridField fieldDavaTarihi = new PivotGridField("Dava_T", PivotArea.FilterArea);
            PivotGridField fieldMahkemesi = new PivotGridField("Mahkemesi", PivotArea.FilterArea);
            PivotGridField fieldDavaTipi = new PivotGridField("Dava_Tipi", PivotArea.FilterArea);
            PivotGridField fieldTarafAdi = new PivotGridField("Taraf_Adi", PivotArea.FilterArea);
            PivotGridField fieldDosyaSayisi = new PivotGridField("ID", PivotArea.DataArea);
            PivotGridField fieldDavayaCevTarihiYil = new PivotGridField("Davaya_Cev_T", PivotArea.FilterArea);
            PivotGridField fieldDavayaCevTarihiCeyrek = new PivotGridField("Davaya_Cev_T", PivotArea.FilterArea);
            PivotGridField fieldArsivTarihiYil = new PivotGridField("Arsiv_T", PivotArea.FilterArea);
            PivotGridField fieldArsivTarihiCeyrek = new PivotGridField("Arsiv_T", PivotArea.FilterArea);
            PivotGridField fieldAvukataGelsTarihiYil = new PivotGridField("Avukata_Gelis_T", PivotArea.FilterArea);
            PivotGridField fieldAvukataGelsTarihiCeyrek = new PivotGridField("Avukata_Gelis_T", PivotArea.FilterArea);
            PivotGridField fieldDurum = new PivotGridField("DURUM", PivotArea.FilterArea);

            fieldDosyaSayisi.SummaryType = PivotSummaryType.Count;
            fieldArsivTarihiYil.GroupInterval = PivotGroupInterval.DateYear;
            fieldArsivTarihiCeyrek.GroupInterval = PivotGroupInterval.DateQuarter;
            fieldAvukataGelsTarihiYil.GroupInterval = PivotGroupInterval.DateYear;
            fieldAvukataGelsTarihiCeyrek.GroupInterval = PivotGroupInterval.DateQuarter;
            fieldDavayaCevTarihiCeyrek.GroupInterval = PivotGroupInterval.DateQuarter;
            fieldDavayaCevTarihiYil.GroupInterval = PivotGroupInterval.DateYear;

            fieldDavayaCevTarihiYil.Caption = "Esas Dava Yil";
            fieldDavayaCevTarihiCeyrek.Caption = "Esas Dava Çeyrek";
            fieldDurum.Caption = "Durum";
            fieldGorev.Caption = "Görev";
            fieldDavaKonusu.Caption = "Dava Konusu";
            fieldDavaTarihi.Caption = "Dava Tarihi";
            fieldMahkemesi.Caption = "Mahkemesi";
            fieldDavaTipi.Caption = "Dava Tipi";
            fieldTarafAdi.Caption = "Taraf Adı";
            fieldDosyaSayisi.Caption = "Dosya Sayısı";
            fieldArsivTarihiYil.Caption = "Arşiv Yıl";
            fieldArsivTarihiCeyrek.Caption = "Arşiv Çeyrek";
            fieldAvukataGelsTarihiCeyrek.Caption = "İntikal Çeyrek";
            fieldAvukataGelsTarihiYil.Caption = "İntikal Yıl";

            fieldMahkemesi.SummaryType = PivotSummaryType.Count;
            extendedPivotControl1.DataSource = sonuc;
            extendedPivotControl1.Fields.AddRange(new[] {fieldArsivTarihiYil,fieldArsivTarihiCeyrek, fieldAvukataGelsTarihiYil,fieldAvukataGelsTarihiCeyrek, fieldDavaKonusu,
                                                     fieldDavaTarihi, fieldDavaTipi ,fieldDavayaCevTarihiYil ,fieldDavayaCevTarihiCeyrek , fieldDurum , fieldGorev, fieldMahkemesi, fieldTarafAdi, fieldDosyaSayisi});
        }

        private void IcraDosyayaGore()
        {
            //DBDataContext db = Program.db;
            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();
            AvukatProViewDataContext dbV = Program.dbV;

            string a = "";
            string b = "";
            string c = "";
            string d = "";
            string e = "";
            List<string> dizi = new List<string>();
            foreach (var item in PvDDeneme.GetList())
            {
                a = item.P1.ToString();
                b = item.P2.ToString();
                c = item.P3.ToString();
                d = item.P4.ToString();
                e = item.P5.ToString();
                dizi.Add(a);
                dizi.Add(b);
                dizi.Add(c);
                dizi.Add(d);
                dizi.Add(e);
            }

            var sonuc = dizi;

            //PivotGridField fieldMonth = new PivotGridField("a", DevExpress.XtraPivotGrid.PivotArea.ColumnArea);
            //PivotGridField fieldYear = new PivotGridField("b", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            //PivotGridField fieldQuarter = new PivotGridField("c", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            //PivotGridField fieldMudruluk = new PivotGridField("d", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            //PivotGridField fieldID = new PivotGridField("e", DevExpress.XtraPivotGrid.PivotArea.DataArea);

            //extendedPivotControl1.Fields.AddRange(new[] { fieldQuarter, fieldMonth, fieldYear, fieldMudruluk, fieldID });

            //RaporProjeIcra icra = new RaporProjeIcra();
            //var sonuc = dbV.R_RAPOR_PROJE_ICRAs;
            //PivotGridField[] fieldList = icra.GetPivotFields(pencere);
            //extendedPivotControl1.Fields.AddRange(fieldList);
            // extendedPivotControl1.DataSource = sonuc;

            extendedPivotControl1.DataSource = dizi;
        }

        private void IcraSorumlusunaGore()
        {
            DBDataContext db = Program.db;

            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();

            var sonuc = db.R_AV001_ICRA_GNL_BLGLRI_HSPSIZ_SRMLULUs;  //Sorumlusuna Göre

            PivotGridField fieldMonth = new PivotGridField("Takip_T", DevExpress.XtraPivotGrid.PivotArea.ColumnArea);
            PivotGridField fieldYear = new PivotGridField("Takip_T", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            PivotGridField fieldQuarter = new PivotGridField("Takip_T", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            PivotGridField fieldMudruluk = new PivotGridField("Mudurluk", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            PivotGridField fieldDosyaSayisi = new PivotGridField("ID", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            PivotGridField fieldSorumluAdi = new PivotGridField("Sorumlu_Adi", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            PivotGridField fieldDurum = new PivotGridField("DURUM", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            PivotGridField fieldTakipTarihi = new PivotGridField("Takip_T", DevExpress.XtraPivotGrid.PivotArea.FilterArea);

            fieldDosyaSayisi.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldMonth.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateMonth;
            fieldYear.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear;
            fieldQuarter.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateQuarter;

            fieldMonth.Caption = "Ay";
            fieldQuarter.Caption = "Çeyrek";
            fieldYear.Caption = "Yıl";
            fieldMudruluk.Caption = "Müdürlük";
            fieldDosyaSayisi.Caption = "Dosya Sayısı";
            fieldSorumluAdi.Caption = "Sorumlu Adı";
            fieldDurum.Caption = "Durum";
            fieldTakipTarihi.Caption = "Takip Tarihi";

            extendedPivotControl1.DataSource = sonuc;
            extendedPivotControl1.Fields.AddRange(new[] { fieldSorumluAdi, fieldDurum, fieldTakipTarihi, fieldQuarter, fieldMonth, fieldYear, fieldMudruluk, fieldDosyaSayisi });
        }

        private void IcraTarafinaGore()
        {
            DBDataContext db = Program.db;

            extendedPivotControl1.DataSource = null;
            extendedPivotControl1.Fields.Clear();

            var sonuc = db.R_AV001_ICRA_GNL_BLGLRI_HSPSIZ_TARAFLIs;  //Sorumlusuna Göre

            PivotGridField fieldMonth = new PivotGridField("Takip_T", DevExpress.XtraPivotGrid.PivotArea.ColumnArea);
            PivotGridField fieldYear = new PivotGridField("Takip_T", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            PivotGridField fieldQuarter = new PivotGridField("Takip_T", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            PivotGridField fieldMudruluk = new PivotGridField("Mudurluk", DevExpress.XtraPivotGrid.PivotArea.FilterArea);

            //PivotGridField fieldID = new PivotGridField("ID", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            PivotGridField fieldDosyaSayisi = new PivotGridField("ID", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            PivotGridField fieldTarafinAdi = new PivotGridField("TarafinAdi", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            PivotGridField fieldDurum = new PivotGridField("DURUM", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            PivotGridField fieldTakipTarihi = new PivotGridField("Takip_T", DevExpress.XtraPivotGrid.PivotArea.FilterArea);

            fieldDosyaSayisi.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldMonth.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateMonth;
            fieldYear.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear;
            fieldQuarter.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateQuarter;

            fieldDosyaSayisi.Caption = "Dosya Sayısı";
            fieldMonth.Caption = "Ay";
            fieldQuarter.Caption = "Çeyrek";
            fieldYear.Caption = "Yıl";
            fieldMudruluk.Caption = "Müdürlük";
            fieldTarafinAdi.Caption = "Tarafın Adı";
            fieldDurum.Caption = "Durum";
            fieldTakipTarihi.Caption = "Takip Tarihi";

            extendedPivotControl1.DataSource = sonuc;
            extendedPivotControl1.Fields.AddRange(new[] { fieldTarafinAdi, fieldDurum, fieldTakipTarihi, fieldQuarter, fieldMonth, fieldYear, fieldMudruluk, fieldDosyaSayisi });
        }

        #endregion gökhanın yapıldıkları

        #region iAVPForms Members

        public void ExportMail()
        {
            SecilenKayitTipi = Enums.KayitTipi.Html;
            popupContainerControl1.Show();
            popupContainerControl1.SuspendLayout();
        }

        public void ExportPDF()
        {
            SecilenKayitTipi = Enums.KayitTipi.Pdf;
            popupContainerControl1.Show();
            popupContainerControl1.SuspendLayout();
        }

        public void ExportPrint()
        {
            SecilenKayitTipi = Enums.KayitTipi.Print;
            popupContainerControl1.Show();
            popupContainerControl1.SuspendLayout();
        }

        public void ExportXls()
        {
            SecilenKayitTipi = Enums.KayitTipi.Excel;
            popupContainerControl1.Show();
            popupContainerControl1.SuspendLayout();
        }

        #endregion iAVPForms Members
    }

}