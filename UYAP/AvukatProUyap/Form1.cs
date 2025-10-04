using AdimAdimDavaKaydi.Util.Uyap;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AdimAdimDavaKaydi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnUyap_Click(object sender, EventArgs e)
        {
            List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> myFoyList = new List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama>();
            int[] selectedRows = gridView1.GetSelectedRows();
            for (int i = 0; i < selectedRows.Length; i++)
            {
                AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama myFoy = BelgeUtil.Inits.context.per_AV001_TI_BIL_ICRA_Aramas.Single(vi => vi.ID == (gridView1.GetRow(selectedRows[i]) as AV001_TI_BIL_FOY).ID);
                if (myFoy == null)
                {
                    continue;
                }
                myFoyList.Add(myFoy);
            }

            // AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(,false, AvukatProLib2.Data.DeepLoadType.IncludeChildren,typeof(TDI_KOD_SOZLESME_TIP),typeof(TDI_KOD_DOVIZ_TIP));

            // myFoyList[0].AV001_TI_BIL_ALACAK_NEDENCollection[0].AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW[0].TIP_IDSource.TIP;

            //myFoyList[0].AV001_TI_BIL_ALACAK_NEDENCollection[0].AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW[0].BEDELI
            //    myFoyList[0].AV001_TI_BIL_ALACAK_NEDENCollection[0].AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW[0].BEDELI_DOVIZ_IDSource.AD;

            UyapGenerator ugen = new UyapGenerator();
            saveUyapBelgeDialog.ShowDialog();
            ugen.WriteToFile(myFoyList, saveUyapBelgeDialog.FileName + ".xml");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.GetAll();
            this.vGridControl1.DataSource = gridControl1.DataSource;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
        }

        private void Yenile_Click(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.GetAll();
            this.vGridControl1.DataSource = gridControl1.DataSource;
        }
    }

    // public class UyapGenerator { public string GetXmlAsString(object value) { string returnValue
    // = ""; StringBuilder sb = new StringBuilder(returnValue); TextWriter twriter = new
    // StringWriter(sb); XmlSerializer xs = new XmlSerializer(value.GetType());
    // XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();

    // xs.Serialize(twriter, value, xsn);

    // return sb.ToString(); }

    // public void WriteXmlToFile(object value, string file) { FileStream fs = new FileStream(file,
    // FileMode.Create); XmlSerializer xs = new XmlSerializer(value.GetType()); xs.Serialize(fs,
    // value); fs.Close(); }

    // public string GetXml(TList<AvukatProLib2.Entities.AV001_TI_BIL_FOY> IcraDosyalari) { return
    // GetXmlAsString(GetExchangeDatas(IcraDosyalari)); }

    // public bool WriteToFile(TList<AvukatProLib2.Entities.AV001_TI_BIL_FOY> IcraDosyalari, string
    // file) { //try //{ WriteXmlToFile(GetExchangeDatas(IcraDosyalari), file); //} //catch
    // (Exception ex) //{ //XtraMessageBox.Show(ex.Message); return false; //}

    // return true; }

    // public bool WriteToFile(AvukatProLib2.Entities.AV001_TI_BIL_FOY IcraDosya, string file) {
    // TList<AvukatProLib2.Entities.AV001_TI_BIL_FOY> returnValues = new TList<AV001_TI_BIL_FOY>();
    // returnValues.Add(IcraDosya); return WriteToFile(returnValues, file);

    // }

    // public ExchangeData GetExchangeDatas(TList<AvukatProLib2.Entities.AV001_TI_BIL_FOY>
    // IcraDosyalari) { ExchangeData exchangeData = new ExchangeData();
    //exchangeData.dosya = new List<Dosya>();
    //            for (int i = 0; i < IcraDosyalari.Count; i++)
    //            {
    //                ExchangeHeader header = new ExchangeHeader();
    //                header.Version = "1.0";
    //                exchangeData.ExchangeHeader = header;
    //                Dosya dsy = GetIcraAsDosya(IcraDosyalari[i]);

    // exchangeData.dosya.Add(dsy); }

    // return exchangeData; }

    // public Dosya GetIcraAsDosya(int IcraDosyaId) { return new Dosya(); }

    // public Dosya GetIcraAsDosya(AvukatProLib2.Entities.AV001_TI_BIL_FOY IcraDosya) {
    // AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(IcraDosya,false,
    // AvukatProLib2.Data.DeepLoadType.IncludeChildren,typeof(TList<AV001_TI_BIL_FOY_TARAF>)); AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(IcraDosya.AV001_TI_BIL_FOY_TARAFCollection,false, AvukatProLib2.Data.DeepLoadType.IncludeChildren,typeof(TList<AV001_TI_BIL_FOY_TARAF_VEKIL>),typeof(AV001_TDI_BIL_CARI));

    // for (int i = 0; i < IcraDosya.AV001_TI_BIL_FOY_TARAFCollection.Count; i++) { AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(IcraDosya.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource,false, AvukatProLib2.Data.DeepLoadType.IncludeChildren,typeof(TDI_KOD_DOVIZ_TIP),typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>),typeof(TDI_KOD_IL),typeof(TDI_KOD_ILCE));
    // }

    // Dosya returnValue = new Dosya(); returnValue.id ="dosya_"+IcraDosya.ID.ToString();
    // returnValue.dosyaTipi = "Genel İcra Dairesi"; returnValue.dosyaTuru = 0;
    // returnValue.takipTuru = 1; returnValue.takipYolu = 3; returnValue.takipSekli=0;
    // returnValue.alacaklininTalepEttigiHak = ""; //TODO : Takip Talep Konu
    // returnValue.BK84MaddeUygulansin=(IcraDosya.HESAPLAMA_TIPI==1 ? 'H' : 'E');
    // returnValue.taraflar=GetIcraTarafs(IcraDosya);

    // returnValue.BSMVUygulansin = (IcraDosya.BSMV_TO == 0 ? 'H' : 'E'); returnValue.KKDFUygulansin
    // = (IcraDosya.KKDV_TO==0 ? 'H' : 'E'); returnValue.aciklama48e9 = "";//TODO : Takip Talep Konu
    // returnValue.dosyaBelirleyicisi="";

    //// AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(IcraDosya, false,
    ////AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));

    // AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(IcraDosya.AV001_TI_BIL_FOY_TARAFCollection,
    // false, AvukatProLib2.Data.DeepLoadType.IncludeChildren,
    // typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>)); returnValue.VekilKisi=getVekilKisi(IcraDosya);
    // returnValue.evraklar= GetEvraklar(IcraDosya); returnValue.Ilamlar = GetIlamlar(IcraDosya);
    // returnValue.kontratKefiller = GetKontratKefils(IcraDosya); returnValue.digerAlacaklar =
    // GetDigerAlacaklar(IcraDosya); returnValue.cekler = GetCek(IcraDosya); returnValue.senetler =
    // GetSenet(IcraDosya); returnValue.policeler = GetPolice(IcraDosya);

    // return returnValue; }

    // public List<KontratKefil> GetKontratKefils(AV001_TI_BIL_FOY Foyum) { List<KontratKefil>
    // returnValues = new List<KontratKefil>(); for (int i = 0; i
    // < Foyum.AV001_TDI_BIL_SOZLESMECollection.Count; i++) { for (int y = 0; y
    // < Foyum.AV001_TDI_BIL_SOZLESMECollection[i].AV001_TDI_BIL_SOZLESME_TARAFCollection.Count; y++)
    // { if
    // (Foyum.AV001_TDI_BIL_SOZLESMECollection[i].AV001_TDI_BIL_SOZLESME_TARAFCollection[y].TARAF_SIFAT_ID
    // == 1) { KontratKefil kkefil = new KontratKefil(); kkefil.adres = getAdres(Foyum.AV001_TDI_BIL_SOZLESMECollection[i].AV001_TDI_BIL_SOZLESME_TARAFCollection[y].CARI_IDSource);
    // Kontrat kntrt = new Kontrat(); kntrt.aciklama = ""; kkefil.kontrat=kntrt; } }

    // } return returnValues; }

    // public Kontrat GetKontrat( AV001_TDI_BIL_SOZLESME Sozlesme) { Kontrat returnValue = new
    // Kontrat(); return returnValue; }

    // public List<Taraf> GetIcraTarafs(AvukatProLib2.Entities.AV001_TI_BIL_FOY IcraDosya) {
    // List<Taraf> returnValues = new List<Taraf>(); for (int i = 0; i
    // < IcraDosya.AV001_TI_BIL_FOY_TARAFCollection.Count; i++) { Taraf myTaraf = new Taraf();
    // myTaraf.id = "taraf_" + IcraDosya.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_ID.ToString();

    // KisiKurumBilgileri kurumbilgisi = new KisiKurumBilgileri(); kurumbilgisi.ad =
    // IcraDosya.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AD; kurumbilgisi.id =
    // "kisiKurumBilgileri_" + IcraDosya.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.ID; //
    // Sorulacak

    // kurumbilgisi.adres = getAdres(IcraDosya.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource);

    // for (int y = 0; y < IcraDosya.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection.Count; y++)
    // { kurumbilgisi.kisiTumBilgileri = getKisiTumBilgileri(IcraDosya.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[y]);
    // }

    // myTaraf.kisiKurumBilgileri = kurumbilgisi;

    // myTaraf.rolTur = getRolTur(IcraDosya.AV001_TI_BIL_FOY_TARAFCollection[i]);

    // returnValues.Add(myTaraf); }

    // return returnValues;

    // }

    // public RolTur getRolTur(AV001_TI_BIL_FOY_TARAF myTaraf) { RolTur rlTur = new RolTur();
    // AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(myTaraf,false,
    // AvukatProLib2.Data.DeepLoadType.IncludeChildren,typeof(TDIE_KOD_TARAF_SIFAT)); rlTur.rolID =
    // myTaraf.TARAF_SIFAT_IDSource.UYAP_KOD; rlTur.Rol =
    // myTaraf.TARAF_SIFAT_IDSource.UYAP_ACIKLAMA; return rlTur; }

    // public RolTur getRolTur(AV001_TI_BIL_ALACAK_NEDEN_TARAF myTaraf) { RolTur rlTur = new
    // RolTur();
    // AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepLoad(myTaraf,
    // false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TDIE_KOD_TARAF_SIFAT));
    // rlTur.rolID = myTaraf.TARAF_SIFAT_IDSource.UYAP_KOD; rlTur.Rol =
    // myTaraf.TARAF_SIFAT_IDSource.UYAP_ACIKLAMA; return rlTur; }

    // public List<Taraf> GetIcraTarafs(AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN
    // AlacakKalem) { List<Taraf> returnValues = new List<Taraf>(); for (int i = 0; i
    // < AlacakKalem.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count; i++) { AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepLoad(AlacakKalem.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection[i],false,
    // AvukatProLib2.Data.DeepLoadType.IncludeChildren,typeof(AV001_TDI_BIL_CARI)); Taraf myTaraf =
    // new Taraf(); myTaraf.id = "taraf_" +
    // AlacakKalem.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection[i].ID.ToString(); KisiKurumBilgileri
    // kurumbilgisi = new KisiKurumBilgileri(); kurumbilgisi.ad =
    // AlacakKalem.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection[i].TARAF_CARI_IDSource.AD;
    // kurumbilgisi.id = "kisiKurumBilgileri_" +
    // AlacakKalem.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection[i].TARAF_CARI_IDSource.ID; // Sorulacak

    // kurumbilgisi.adres =
    // getAdres(AlacakKalem.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection[i].TARAF_CARI_IDSource);

    // for (int y = 0; y < AlacakKalem.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection[i].TARAF_CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection.Count; y++)
    // { kurumbilgisi.kisiTumBilgileri = getKisiTumBilgileri(AlacakKalem.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection[i].TARAF_CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[y]);
    // }

    // myTaraf.kisiKurumBilgileri = kurumbilgisi;

    // myTaraf.rolTur = getRolTur(AlacakKalem.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection[i]);

    // returnValues.Add(myTaraf); }

    // return returnValues;

    // }

    // public enum AdresBilgiTipi { Il, Ilce, Adres, PostaKodu, AdresSirasi }

    // object GetAdresBilgi(AvukatProLib2.Entities.AV001_TDI_BIL_CARI carim, AdresBilgiTipi tip) {
    // if (carim.AKTIF_ADRES) { switch (tip) { case AdresBilgiTipi.Il: return carim.IL_IDSource;
    // break; case AdresBilgiTipi.Ilce: return carim.ILCE_IDSource; break; case
    // AdresBilgiTipi.Adres: return carim.ADRES_1; break; case AdresBilgiTipi.PostaKodu: return
    // carim.POSTA_KODU; break; case AdresBilgiTipi.AdresSirasi: return 1; break;
    // default:
    // break; } } if (carim.AKTIF_ADRES_2) { switch (tip) { case AdresBilgiTipi.Il: return
    // carim.IL2_IDSource; break; case AdresBilgiTipi.Ilce: return carim.ILCE2_IDSource; break; case
    // AdresBilgiTipi.Adres: return carim.ADRES_2; break; case AdresBilgiTipi.PostaKodu: return
    // carim.POSTA_KODU2; break; case AdresBilgiTipi.AdresSirasi: return 2; break;
    // default:
    // break; } }

    // if (carim.AKTIF_ADRES_3) { switch (tip) { case AdresBilgiTipi.Il: return carim.IL3_IDSource;
    // break; case AdresBilgiTipi.Ilce: return carim.ILCE3_IDSource; break; case
    // AdresBilgiTipi.Adres: return carim.ADRES_3; break; case AdresBilgiTipi.PostaKodu: return
    // carim.POSTA_KODU3; break; case AdresBilgiTipi.AdresSirasi: return 3; break;
    // default:

    // break; } }

    // return 0; }

    // Adres getAdres(AvukatProLib2.Entities.AV001_TDI_BIL_CARI carim) {
    // AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(carim, false,
    // AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TDI_KOD_ADRES_TUR),
    // typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE));

    // Adres adres = new Adres(); adres.adres = GetAdresBilgi(carim,
    // AdresBilgiTipi.Adres).ToString(); if (carim.ADRES_TUR_IDSource != null) { adres.adresTuru =
    // carim.ADRES_TUR_IDSource.UYAP_KOD; adres.adresTuruAciklama =
    // carim.ADRES_TUR_IDSource.UYAP_ACIKLAMA; } else { // adres.adresTuru =
    // carim.ADRES_TUR_IDSource.UYAP_KOD; }

    // adres.cepTelefon = carim.CEP_TEL; adres.elektronikPostaAdresi = carim.EMAIL_1; adres.fax =
    // carim.FAX; adres.id = "adres_" + carim.ID.ToString() + GetAdresBilgi(carim,
    // AdresBilgiTipi.AdresSirasi).ToString(); TDI_KOD_ILCE ilce =
    // ((TDI_KOD_ILCE)GetAdresBilgi(carim, AdresBilgiTipi.Ilce)); TDI_KOD_IL il =
    // ((TDI_KOD_IL)GetAdresBilgi(carim, AdresBilgiTipi.Il)); if (il!=null) {
    //adres.il = il.IL;
    //                adres.ilKodu = il.PLAKA_NO;
    //            }
    //            if (ilce!=null)
    //            {
    //  adres.ilce = ilce.ILCE;
    //                adres.ilceKodu = ilce.KOD;
    //            }

    // adres.postaKodu = GetAdresBilgi(carim, AdresBilgiTipi.PostaKodu).ToString(); adres.telefon =
    // carim.TEL_1;

    // return adres; }

    // KisiTumBilgileri getKisiTumBilgileri(AvukatProLib2.Entities.AV001_TDI_BIL_CARI_KIMLIK kimlik)
    // { AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARI_KIMLIKProvider.DeepLoad(kimlik, false,
    // AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI),
    // typeof(TDI_KOD_CINSIYET), typeof(TDI_KOD_KIMLIK_VERILIS_NEDEN), typeof(TDI_KOD_IL),
    // typeof(TDI_KOD_ILCE));

    // KisiTumBilgileri kisiTumBilgisi = new KisiTumBilgileri(); string[] adSoyad =
    // GetAdSoyadFromCari(kimlik.CARI_IDSource);

    // kisiTumBilgisi.adi = adSoyad[0]; kisiTumBilgisi.soyadi = adSoyad[1];
    // kisiTumBilgisi.oncekiSoyadi = kimlik.ONCEKI_SOYADI; kisiTumBilgisi.aileSiraNo =
    // kimlik.NKO_AILE_SIRA_NO; kisiTumBilgisi.anaAdi = kimlik.ANA_ADI; kisiTumBilgisi.babaAdi =
    // kimlik.BABA_ADI; kisiTumBilgisi.ciltNo = kimlik.NKO_CILT_NO; if (kimlik.CINSIYET_IDSource !=
    // null) { kisiTumBilgisi.cinsiyeti = (kimlik.CINSIYET_IDSource.ID == 1 ? 'E' : 'K'); } else {
    // //kisiTumBilgisi.cinsiyeti = 'E'; }

    // kisiTumBilgisi.cuzdanNo = kimlik.CUZDANIN_KAYIT_NO; kisiTumBilgisi.cuzdanSeriNo =
    // kimlik.CUZDANIN_KAYIT_NO; if (kimlik.DOGUM_TARIHI.HasValue) { kisiTumBilgisi.dogumTarihi =
    // kimlik.DOGUM_TARIHI.Value; }

    // kisiTumBilgisi.dogumYeri = kimlik.DOGUM_YERI; kisiTumBilgisi.kayitNo =
    // kimlik.CUZDANIN_KAYIT_NO; // kontrol kisiTumBilgisi.mahKoy = kimlik.NKO_MAHALLE_KOY; if
    // (kimlik.NKO_ILCE_IDSource != null) { kisiTumBilgisi.nufusaKayitIlceKodu =
    // kimlik.NKO_ILCE_IDSource.KOD; // Kod } if (kimlik.NKO_IL_IDSource != null) {
    // kisiTumBilgisi.nufusaKayitIlKodu = kimlik.NKO_IL_IDSource.PLAKA_NO;//Kod }

    // kisiTumBilgisi.siraNo = kimlik.NKO_SIRA_NO; kisiTumBilgisi.tcKimlikNo = kimlik.TC_KIMLIK_NO;
    // kisiTumBilgisi.vergiNo = kimlik.CARI_IDSource.VERGI_NO; kisiTumBilgisi.verildigiIlAdi =
    // kimlik.CUZDANIN_VERILDIGI_YER;//Kontrol kisiTumBilgisi.verildigiIlceAdi = kimlik.IL; //
    // Kontrol kisiTumBilgisi.verildigiIlceKodu = kimlik.ILCE; //Kontrol
    // kisiTumBilgisi.verildigiIlKodu = kimlik.NKO_CILT_NO; //Kontrol if
    // (kimlik.CUZDANIN_VERILIS_TARIHI.HasValue) { kisiTumBilgisi.verildigiTarih =
    // kimlik.CUZDANIN_VERILIS_TARIHI.Value;//Kontrol } if (kimlik.CUZDANIN_VERILME_NEDENI_IDSource
    // != null) { kisiTumBilgisi.verilisNedeni = kimlik.CUZDANIN_VERILME_NEDENI_IDSource.UYAP_KOD; }
    // //Kontrol

    // kisiTumBilgisi.ybnNfsKayitliOldgYer = "";//Kontrol

    // return kisiTumBilgisi; }

    // List<Vekil> getVekil(AvukatProLib2.Entities.AV001_TI_BIL_FOY myfoy) { List<Vekil> returnValue
    // = new List<Vekil>(); for (int i = 0; i < myfoy.AV001_TI_BIL_FOY_TARAFCollection.Count; i++) {
    // returnValue.AddRange(getVekil(myfoy.AV001_TI_BIL_FOY_TARAFCollection[i])); } return
    // returnValue; }

    // List<Vekil> getVekil(AvukatProLib2.Entities.AV001_TI_BIL_FOY_TARAF taraf) { List<Vekil>
    // returnValue = new List<Vekil>();

    // for (int i = 0; i < taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection.Count; i++) { Vekil vkl =
    // new Vekil(); string[] adSoyad =
    // GetAdSoyadFromCari(taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection[i].AVUKAT_CARI_IDSource);
    // vkl.adi = adSoyad[0]; vkl.soyadi = adSoyad[1]; vkl.avukatlikBuroAdi =
    // taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection[i].AVUKAT_CARI_IDSource.UNVAN;
    // vkl.bakanlikDosyaNo = ""; vkl.baroNo =
    // taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection[i].AVUKAT_CARI_IDSource.BARO_SICIL_NO;
    // vkl.borcluVekilMi = (taraf.TAKIP_EDEN_MI == true ? 'E' : 'H'); vkl.id = "vekil_" +
    // taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection[i].ID.ToString(); // vkl.kapanmaNedeni = ' ';
    // vkl.kurumAvikatiMi =
    // (taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection[i].AVUKAT_CARI_IDSource.KURUM_AVUKATI_MI ==
    // true ? 'E' : 'H'); vkl.sigortaliMi =
    // (taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection[i].AVUKAT_CARI_IDSource.SG_NO_KULLANIYOR_MU ==
    // true ? 'E' : 'H'); vkl.tbbNo =
    // taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection[i].AVUKAT_CARI_IDSource.BARO_BIRLIK_SICIL_NO;
    // vkl.tcKimlikNo =
    // taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection[i].AVUKAT_CARI_IDSource.VERGI_NO; vkl.vekilTipi
    // = 'E';// TODO :
    // taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection[i].TEMSIL_IDSource.ID.ToString(); // TODO: KOD;
    // vkl.vergiNo = taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection[i].AVUKAT_CARI_IDSource.VERGI_NO;
    // } return returnValue; }

    // Vekil getVekil(AvukatProLib2.Entities.AV001_TI_BIL_FOY_TARAF_VEKIL vekil) {
    // AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.DeepLoad(vekil,false,
    // AvukatProLib2.Data.DeepLoadType.IncludeChildren,typeof(AV001_TI_BIL_FOY_TARAF)); Vekil vkl =
    // new Vekil(); string[] adSoyad = GetAdSoyadFromCari(vekil.AVUKAT_CARI_IDSource); vkl.adi =
    // adSoyad[0]; vkl.soyadi = adSoyad[1]; vkl.avukatlikBuroAdi = vekil.AVUKAT_CARI_IDSource.UNVAN;
    // vkl.bakanlikDosyaNo = ""; vkl.baroNo = vekil.AVUKAT_CARI_IDSource.BARO_SICIL_NO;
    // vkl.borcluVekilMi = (vekil.FOY_TARAF_IDSource.TAKIP_EDEN_MI == true ? 'E' : 'H'); vkl.id =
    // "vekil_" + vekil.ID.ToString(); // vkl.kapanmaNedeni = ' '; vkl.kurumAvikatiMi =
    // (vekil.AVUKAT_CARI_IDSource.KURUM_AVUKATI_MI == true ? 'E' : 'H'); vkl.sigortaliMi =
    // (vekil.AVUKAT_CARI_IDSource.SG_NO_KULLANIYOR_MU == true ? 'E' : 'H'); vkl.tbbNo =
    // vekil.AVUKAT_CARI_IDSource.BARO_BIRLIK_SICIL_NO; vkl.tcKimlikNo =
    // vekil.AVUKAT_CARI_IDSource.VERGI_NO; vkl.vekilTipi = 'E';// TODO :
    // taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection[i].TEMSIL_IDSource.ID.ToString(); // TODO: KOD;

    // return vkl; }

    // List<VekilKisi> getVekilKisi(TList<AvukatProLib2.Entities.AV001_TI_BIL_FOY_TARAF_VEKIL>
    // tarafVekils) { List<VekilKisi> lstVekilKisi = new List<VekilKisi>();
    // AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.DeepLoad(tarafVekils,
    // false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI)); for (int
    // i = 0; i < tarafVekils.Count; i++) { if (tarafVekils[i].AVUKAT_CARI_IDSource != null) {
    // VekilKisi vekilKisisi = new VekilKisi(); vekilKisisi.adres =
    // getAdres(tarafVekils[i].AVUKAT_CARI_IDSource); vekilKisisi.id = "Vekil_" +
    // tarafVekils[i].ID.ToString(); AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(tarafVekils[i].AVUKAT_CARI_IDSource,
    // false, AvukatProLib2.Data.DeepLoadType.IncludeChildren,
    // typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>)); if
    // (tarafVekils[i].AVUKAT_CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection.Count <= 0) { if
    // (tarafVekils[i].AVUKAT_CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection.Count >= 1) {
    // vekilKisisi.kisiTumBilgileri =
    // getKisiTumBilgileri(tarafVekils[i].AVUKAT_CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0]);
    // } } vekilKisisi.vekil = getVekil(tarafVekils[i]); lstVekilKisi.Add(vekilKisisi); } } return
    // lstVekilKisi; }

    // List<VekilKisi> getVekilKisi(AvukatProLib2.Entities.AV001_TI_BIL_FOY Foyum) { List<VekilKisi>
    // lstVekilKisi = new List<VekilKisi>(); TList<AV001_TI_BIL_FOY_TARAF_VEKIL> lstVekils = new
    // TList<AV001_TI_BIL_FOY_TARAF_VEKIL>();

    // for (int i = 0; i < Foyum.AV001_TI_BIL_FOY_TARAFCollection.Count; i++) { for (int y = 0; y
    // < Foyum.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection.Count; y++)
    // { if (!IsInVekilCollection(lstVekils,
    // Foyum.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection[y])) {
    // lstVekils.Add(Foyum.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection[y]);
    // } } } lstVekilKisi.AddRange(getVekilKisi(lstVekils)); return lstVekilKisi; }

    // bool IsInVekilCollection(TList<AV001_TI_BIL_FOY_TARAF_VEKIL> lstVekils,
    // AV001_TI_BIL_FOY_TARAF_VEKIL vekil) { for (int i = 0; i < lstVekils.Count; i++) { if
    // (lstVekils[i].ID==vekil.ID) { return true; } } return false; }

    // AlacakKalemi GetAlacakKalemi(AV001_TI_BIL_ALACAK_NEDEN aneden) { AlacakKalemi AlacakKalem =
    // new AlacakKalemi(); AlacakKalem.aciklama = aneden.ACIKLAMA; AlacakKalem.akdiFaiz =
    // aneden.TO_UYGULANACAK_FAIZ_ORANI.ToString(); AlacakKalem.alacakKalemAdi = "";
    // AlacakKalem.alacakKalemIlkTutar = aneden.ISLEME_KONAN_TUTAR.ToString();
    // //AlacakKalem.alacakKalemKod; // = aneden.ALACAK_NEDEN_KOD_IDSource.uya;
    // AlacakKalem.alacakKalemKodAciklama = ""; AlacakKalem.alacakKalemKodTuru = "";
    // AlacakKalem.alacakKalemTip = ""; // AlacakKalem.alacakKalemTutar=lstAlacakNeden[i].K;
    // AlacakKalem.dovizKurCevrimi = ""; AlacakKalem.faizler = GetFaiz(aneden);
    // AlacakKalem.sabitTaksitTarihi=DateTime.Now;//=aneden.VADE_TARIHI.Value.tos.sa;
    // AlacakKalem.tutarAdi = ""; AlacakKalem.tutarTur = ""; AlacakKalem.Id = "alacakKalem_" +
    // aneden.ID.ToString(); AlacakKalem.refler = getRef(aneden);

    // //AlacakKalem.taraflar = GetIcraTarafs(aneden); return AlacakKalem; }

    // public List<AlacakKalemi> GetAlacakKalemleri(AvukatProLib2.Entities.AV001_TI_BIL_FOY Foyum) {
    // List<AlacakKalemi> returnValues = new List<AlacakKalemi>();

    // for (int i = 0; i < Foyum.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++) { AlacakKalemi
    // AlacakKalem = GetAlacakKalemi(Foyum.AV001_TI_BIL_ALACAK_NEDENCollection[i]);

    // returnValues.Add(AlacakKalem); }

    // return returnValues; }

    // public List<AlacakKalemi>
    // GetAlacakKalemleri(AvukatProLib2.Entities.AV001_TDI_BIL_KIYMETLI_EVRAK evrak) {
    // List<AlacakKalemi> returnValues = new List<AlacakKalemi>();
    // AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(evrak, false,
    // AvukatProLib2.Data.DeepLoadType.IncludeChildren , typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));

    // TList<AV001_TI_BIL_ALACAK_NEDEN> lstAlacakNeden =
    // evrak.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK;

    //
    // //AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(lstAlacakNeden,
    // false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<>)); for (int i = 0; i
    // < lstAlacakNeden.Count; i++) { AlacakKalemi AlacakKalem = GetAlacakKalemi(lstAlacakNeden[i]);

    // returnValues.Add(AlacakKalem); }

    // return returnValues; }

    // public List<Faiz> GetFaiz(AvukatProLib2.Entities.AV001_TI_BIL_FOY Foyum) { List<Faiz>
    // returnValues = new List<Faiz>();

    // return returnValues; }

    // public List<Faiz> GetFaiz(AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN AlacakNeden) {
    // List<Faiz> returnValue = new List<Faiz>();
    // AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(AlacakNeden,false,
    // AvukatProLib2.Data.DeepLoadType.IncludeChildren,typeof(TList<AV001_TI_BIL_FAIZ>)); for (int i
    // = 0; i < AlacakNeden.AV001_TI_BIL_FAIZCollection.Count; i++) { Faiz fz = new Faiz(); if
    // (AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_BASLANGIC_TARIHI.HasValue) {
    // fz.baslangicTarihi = AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_BASLANGIC_TARIHI.Value;
    // } if (AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_BITIS_TARIHI.HasValue) { fz.bitisTarihi
    // = AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_BITIS_TARIHI.Value; }

    // AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FAIZProvider.DeepLoad(
    // AlacakNeden.AV001_TI_BIL_FAIZCollection[i],false, AvukatProLib2.Data.DeepLoadType.IncludeChildren,typeof(TDI_KOD_FAIZ_TIP),typeof(TDI_KOD_DOVIZ_TIP));

    // fz.faizOrani = AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_ORANI.ToString();
    // fz.faizSureTip = AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_TIP_IDSource.UYAP_KOD;
    // fz.faizTipKodAciklama =
    // AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_TIP_IDSource.UYAP_ACIKLAMA; fz.faizTutar =
    // AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_TUTARI; fz.faizTutarTur =
    // AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_TUTARI_DOVIZ_IDSource.UYAP_KODU; // TODO:
    // fz.faizTutarTurAdi =
    // AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_TUTARI_DOVIZ_IDSource.UYAP_ACIKLAMA; // TODO
    // : fz.Id = "faiz_" + AlacakNeden.AV001_TI_BIL_FAIZCollection[i].ID.ToString();
    // returnValue.Add(fz); }

    // return returnValue; }

    // public List<Ref> getRef(AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN AlacakNeden) {
    // List<Ref> returnValue = new List<Ref>();
    // AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(AlacakNeden,false,
    // AvukatProLib2.Data.DeepLoadType.IncludeChildren,typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
    // for (int i = 0; i < AlacakNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count; i++) { Ref
    // rf = new Ref(); rf.to = "taraf"; rf.id = "taraf_" +
    // AlacakNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection[i].TARAF_CARI_ID.ToString();
    // returnValue.Add(rf); } return returnValue; }

    // public List<Ref> getRef(AvukatProLib2.Entities.AV001_TDI_BIL_KIYMETLI_EVRAK KiymetliEvrak) {
    // List<Ref> returnValue = new List<Ref>();
    // AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(KiymetliEvrak,
    // false, AvukatProLib2.Data.DeepLoadType.IncludeChildren,
    // typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>)); for (int i = 0; i
    // < KiymetliEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection.Count; i++) { //AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFProvider.DeepLoad(KiymetliEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection,
    // false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));

    // Ref rf = new Ref(); rf.to = "taraf"; rf.id = "taraf_" +
    // KiymetliEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection[i].TARAF_CARI_ID.ToString();
    // returnValue.Add(rf); } return returnValue; }

    // public List<Police> GetPolice(AV001_TI_BIL_FOY Foyum) { List<Police> returnValues = new
    // List<Police>(); for (int i = 0; i < Foyum.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++) { AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(Foyum.AV001_TI_BIL_ALACAK_NEDENCollection[i],false,
    // AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK>),typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>));
    // TList<AV001_TDI_BIL_KIYMETLI_EVRAK> lstKiymetliEvraks = Foyum.AV001_TI_BIL_ALACAK_NEDENCollection[i].AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK;
    // AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(lstKiymetliEvraks,
    // false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TDI_KOD_BANKA),
    // typeof(TDI_KOD_BANKA_SUBE), typeof(TDI_KOD_DOVIZ_TIP)); for (int y = 0; y
    // < lstKiymetliEvraks.Count; y++) {
    // AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(lstKiymetliEvraks,
    // false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TDI_KOD_BANKA),
    // typeof(TDI_KOD_BANKA_SUBE), typeof(TDI_KOD_DOVIZ_TIP));

    // if (lstKiymetliEvraks[y].EVRAK_TUR_ID == 3) { Police pol = new Police(); pol.belgeninTutari =
    // lstKiymetliEvraks[y].TUTAR; pol.Id = "police_" + lstKiymetliEvraks[y].ID.ToString();
    // pol.islemlerBasladimi = (lstKiymetliEvraks[y].ISLEMLER_BASLADIMI == true ? 'E' : 'H');

    // if (lstKiymetliEvraks[y].EVRAK_VADE_TARIHI.HasValue) { pol.kesideTarihi =
    // lstKiymetliEvraks[y].EVRAK_VADE_TARIHI.Value; } pol.kesideYeri =
    // lstKiymetliEvraks[y].KESIDE_YERI; bool KesideComma = false; bool LehtarComma = false; //bool
    // OdeyecekComma = false; for (int z = 0; z
    // < lstKiymetliEvraks[y].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection.Count; z++) { if
    // (lstKiymetliEvraks[y].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection[z].TARAF_TIP_ID == 5) {
    // LehtarComma = true; pol.lehtarAdSoyad +=
    // lstKiymetliEvraks[y].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection[z].TARAF_CARI_IDSource.AD +
    // ","; } if (lstKiymetliEvraks[y].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection[z].TARAF_TIP_ID
    // == 2) { KesideComma = true; pol.kesideciAdSoyad +=
    // lstKiymetliEvraks[y].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection[z].TARAF_CARI_IDSource.AD +
    // ","; } //if
    // (lstKiymetliEvraks[y].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection[z].TARAF_TIP_ID == 4) //{
    // // //OdeyecekComma = true; // pol.odeyecekKisiAdSoyad +=
    // lstKiymetliEvraks[y].BANKA_IDSource.BANKA; //}

    // if (LehtarComma) { pol.lehtarAdSoyad = pol.lehtarAdSoyad.Remove(pol.lehtarAdSoyad.Length - 1,
    // 1); }

    // if (KesideComma) { pol.kesideciAdSoyad =
    // pol.kesideciAdSoyad.Remove(pol.kesideciAdSoyad.Length - 1, 1); } //if (OdeyecekComma) //{ //
    // pol.odeyecekKisiAdSoyad = pol.odeyecekKisiAdSoyad.Remove(pol.odeyecekKisiAdSoyad.Length - 1,
    // 1); //}

    // } if (lstKiymetliEvraks[i].BANKA_ID.HasValue) { pol.odeyecekKisiAdSoyad +=
    // lstKiymetliEvraks[y].BANKA_IDSource.BANKA; } pol.odemeYeri = lstKiymetliEvraks[y].ODEME_YERI;
    // //pol.olmasiGrknPulDegeri = lstKiymetliEvraks[y].; pol.tutarAdi =
    // lstKiymetliEvraks[y].TUTAR_DOVIZ_IDSource.UYAP_ACIKLAMA; pol.tutarTur =
    // lstKiymetliEvraks[y].TUTAR_DOVIZ_IDSource.UYAP_KODU; // TODO : pol.uzerindekiPulunDegeri =
    // Foyum.AV001_TI_BIL_ALACAK_NEDENCollection[i].DAMGA_PULU.ToString(); // TODO : if
    // (lstKiymetliEvraks[y].EVRAK_VADE_TARIHI.HasValue) { pol.vadeTarihi =
    // lstKiymetliEvraks[y].EVRAK_VADE_TARIHI.Value; }

    // // if (lstKiymetliEvraks[i].SORULDUGU_TARIH.HasValue) //{ // pol.ibrazTarihi =
    // lstKiymetliEvraks[i].SORULDUGU_TARIH.Value; //}

    // //pol.bankaAdi = lstKiymetliEvraks[y].BANKA_IDSource.BANKA; //pol.bankaID = "banka_" +
    // lstKiymetliEvraks[y].BANKA_IDSource.ID.ToString(); //pol.bankaSubeAdi =
    // lstKiymetliEvraks[y].SUBE_IDSource.SUBE; //pol.bankaSubeAdres =
    // lstKiymetliEvraks[y].SUBE_IDSource.ADRES; //pol.bankaSubeIl =
    // lstKiymetliEvraks[y].SUBE_IDSource.IL; //pol.bankaSubeIlce =
    // lstKiymetliEvraks[y].SUBE_IDSource.ILCE; //pol.bankaSubeKod =
    // lstKiymetliEvraks[y].SUBE_IDSource.KODU; //if (lstKiymetliEvraks[i].SORULDUGU_TARIH.HasValue)
    // //{ // ck.ibrazTarihi = lstKiymetliEvraks[i].SORULDUGU_TARIH.Value; //} //ck.Id = "cek_" +
    // lstKiymetliEvraks[y].ID.ToString(); //ck.islemlerBasladimi = //if
    // (lstKiymetliEvraks[y].EVRAK_VADE_TARIHI.HasValue) //{ // ck.kesideTarihi =
    // lstKiymetliEvraks[y].EVRAK_VADE_TARIHI.Value; //}

    // //ck.kesideYeri = lstKiymetliEvraks[i].KESIDE_YERI; //ck.kocaNo =
    // lstKiymetliEvraks[y].CEK_NO; // TODO : //ck.odemeYeri = lstKiymetliEvraks[i].ODEME_YERI;
    // //ck.seriNo = lstKiymetliEvraks[y].CEK_NO; // TODO : //ck.tutar = lstKiymetliEvraks[y].TUTAR;
    // //ck.tutarTur = lstKiymetliEvraks[y].TUTAR_DOVIZ_IDSource.DOVIZ_KODU; // TODO :
    // //ck.tutarTurAciklama = lstKiymetliEvraks[y].TUTAR_DOVIZ_IDSource.DOVIZ_KODU; // TODO :
    // pol.refler = getRef(lstKiymetliEvraks[y]); pol.alacakKalemi =
    // GetAlacakKalemleri(lstKiymetliEvraks[y]); returnValues.Add(pol); } } } return returnValues; }

    // public List<Cek> GetCek(AV001_TI_BIL_FOY Foyum) { List<Cek> returnValues = new List<Cek>();
    // AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(Foyum, false,
    // AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
    // for (int i = 0; i < Foyum.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++) { AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(Foyum.AV001_TI_BIL_ALACAK_NEDENCollection[i],
    // false, AvukatProLib2.Data.DeepLoadType.IncludeChildren,
    // typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK>));

    // TList<AV001_TDI_BIL_KIYMETLI_EVRAK> lstKiymetliEvraks = Foyum.AV001_TI_BIL_ALACAK_NEDENCollection[i].AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK;

    //
    // AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(lstKiymetliEvraks,
    // false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TDI_KOD_BANKA),
    // typeof(TDI_KOD_BANKA_SUBE), typeof(TDI_KOD_DOVIZ_TIP));

    // for (int y = 0; y < lstKiymetliEvraks.Count; y++) { if (lstKiymetliEvraks[y].EVRAK_TUR_ID ==
    // 1) { Cek ck = new Cek(); ck.bankaAdi = lstKiymetliEvraks[y].BANKA_IDSource.BANKA; ck.bankaID
    // = "banka_" + lstKiymetliEvraks[y].BANKA_IDSource.ID.ToString(); ck.bankaSubeAdi =
    // lstKiymetliEvraks[y].SUBE_IDSource.SUBE; ck.bankaSubeAdres =
    // lstKiymetliEvraks[y].SUBE_IDSource.ADRES; ck.bankaSubeIl =
    // lstKiymetliEvraks[y].SUBE_IDSource.IL; ck.bankaSubeIlce =
    // lstKiymetliEvraks[y].SUBE_IDSource.ILCE; ck.bankaSubeKod =
    // lstKiymetliEvraks[y].SUBE_IDSource.KODU; if (lstKiymetliEvraks[y].SORULDUGU_TARIH.HasValue) {
    // ck.ibrazTarihi = lstKiymetliEvraks[y].SORULDUGU_TARIH.Value; } ck.Id = "cek_" +
    // lstKiymetliEvraks[y].ID.ToString(); ck.islemlerBasladimi =
    // (lstKiymetliEvraks[y].ISLEMLER_BASLADIMI == true ? 'E' : 'H'); if
    // (lstKiymetliEvraks[y].EVRAK_VADE_TARIHI.HasValue) { ck.kesideTarihi =
    // lstKiymetliEvraks[y].EVRAK_VADE_TARIHI.Value; }

    // ck.kesideYeri = lstKiymetliEvraks[y].KESIDE_YERI; ck.kocanNo = lstKiymetliEvraks[y].CEK_NO;
    // // TODO : ck.odemeYeri = lstKiymetliEvraks[y].ODEME_YERI; ck.seriNo =
    // lstKiymetliEvraks[y].HESAP_NO; // TODO : ck.tutar = lstKiymetliEvraks[y].TUTAR; ck.tutarTur =
    // lstKiymetliEvraks[y].TUTAR_DOVIZ_IDSource.DOVIZ_KODU; // TODO : ck.tutarTurAciklama =
    // lstKiymetliEvraks[y].TUTAR_DOVIZ_IDSource.DOVIZ_KODU; // TODO :

    // ck.alacakKalemi = GetAlacakKalemleri(lstKiymetliEvraks[y]);

    // returnValues.Add(ck); } } } return returnValues; }

    // public List<Senet> GetSenet(AV001_TI_BIL_FOY Foyum) { List<Senet> returnValues = new
    // List<Senet>(); for (int i = 0; i < Foyum.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++) {
    // TList<AV001_TDI_BIL_KIYMETLI_EVRAK> lstKiymetliEvraks = Foyum.AV001_TI_BIL_ALACAK_NEDENCollection[i].AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK;
    // for (int y = 0; y < lstKiymetliEvraks.Count; y++) {
    // AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(lstKiymetliEvraks,
    // false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TDI_KOD_BANKA),
    // typeof(TDI_KOD_BANKA_SUBE), typeof(TDI_KOD_DOVIZ_TIP));

    // if (lstKiymetliEvraks[y].EVRAK_TUR_ID == 1) { Senet sen = new Senet(); sen.belgeninTutari =
    // lstKiymetliEvraks[y].TUTAR; sen.Id = "sen_" + lstKiymetliEvraks[y].ID.ToString();
    // sen.islemlerBasladimi = (lstKiymetliEvraks[y].ISLEMLER_BASLADIMI == true ? 'E' : 'H');
    // sen.odemeYeri = lstKiymetliEvraks[y].ODEME_YERI; sen.olmasiGrknPulDegeri = ""; if
    // (lstKiymetliEvraks[y].EVRAK_TANZIM_TARIHI.HasValue) { sen.tanzimTarihi =
    // lstKiymetliEvraks[y].EVRAK_TANZIM_TARIHI.Value; }

    // sen.tanzimYeri = lstKiymetliEvraks[y].KESIDE_YERI; sen.tutarAdi =
    // lstKiymetliEvraks[y].TUTAR_DOVIZ_IDSource.UYAP_ACIKLAMA; // TODO : sen.tutarTur =
    // lstKiymetliEvraks[y].TUTAR_DOVIZ_IDSource.UYAP_KODU; // TODO : sen.uzerindekiPulunDegeri =
    // Foyum.AV001_TI_BIL_ALACAK_NEDENCollection[i].DAMGA_PULU.ToString(); if
    // (lstKiymetliEvraks[y].EVRAK_VADE_TARIHI.HasValue) { sen.vadeTarihi =
    // lstKiymetliEvraks[y].EVRAK_VADE_TARIHI.Value; }

    // //if (lstKiymetliEvraks[i].SORULDUGU_TARIH.HasValue) //{ // ck.ibrazTarihi =
    // lstKiymetliEvraks[i].SORULDUGU_TARIH.Value; //} //ck.Id = "cek_" +
    // lstKiymetliEvraks[y].ID.ToString(); //ck.islemlerBasladimi = //if
    // (lstKiymetliEvraks[y].EVRAK_VADE_TARIHI.HasValue) //{ // ck.kesideTarihi =
    // lstKiymetliEvraks[y].EVRAK_VADE_TARIHI.Value; //}

    // //ck.kesideYeri = lstKiymetliEvraks[i].KESIDE_YERI; //ck.kocaNo =
    // lstKiymetliEvraks[y].CEK_NO; // TODO : //ck.odemeYeri = lstKiymetliEvraks[i].ODEME_YERI;
    // //ck.seriNo = lstKiymetliEvraks[y].CEK_NO; // TODO : //ck.tutar = lstKiymetliEvraks[y].TUTAR;
    // //ck.tutarTur = lstKiymetliEvraks[y].TUTAR_DOVIZ_IDSource.DOVIZ_KODU; // TODO :
    // //ck.tutarTurAciklama = lstKiymetliEvraks[y].TUTAR_DOVIZ_IDSource.DOVIZ_KODU; // TODO :

    // sen.alacakKalemi = GetAlacakKalemleri(lstKiymetliEvraks[y]);

    // returnValues.Add(sen); } } } return returnValues; }

    // public List<Evrak> GetEvraklar(AV001_TI_BIL_FOY Foyum) { List<Evrak> returnValues = new
    // List<Evrak>();

    // for (int i = 0; i < Foyum.AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_ICRA.Count; i++) {
    // returnValues.Add(GetEvrak(Foyum.AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_ICRA[i].DOSYA_ADI,
    // Foyum.AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_ICRA[i].ICERIK)); }

    // return returnValues; }

    // Evrak GetEvrak(string dosyaAdi, byte[] icerik) { Evrak evrk = new Evrak(); MemoryStream fs =
    // new MemoryStream(icerik); // StreamReader sr = new StreamReader(fs); evrk.Data = icerik;
    // //evrk.Data = sr.ReadToEnd(); // sr.Close(); evrk.fileName = dosyaAdi; evrk.mimeType =
    // GetMimeType(dosyaAdi); return evrk; }

    // string GetMimeType(string fileName) { if (!fileName.Contains(".")) { return ""; } string
    // uzanti = fileName.Substring(fileName.LastIndexOf(".")).Trim(); switch (uzanti) { case "doc":
    // return "application/msword"; break; case "docx": return "application/msword"; break;
    // default:
    // return ""; break; }

    // }

    // public List<Ilam> GetIlamlar(AV001_TI_BIL_FOY Foyum) { List<Ilam> returnValues = new
    // List<Ilam>(); for (int i = 0; i < Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count; i++) {
    // Ilam ilm = new Ilam(); ilm.davaAcilisTarihi =
    // Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].KARAR_TARIHI.Value; ilm.ilamAciklama =
    // Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].ILAM_ACIKLAMASI; string[] ilamDosyaEsas =
    // Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].ESAS_NO.Split('~'); ilm.ilamDosyaNoYil =
    // ilamDosyaEsas[0]; ilm.ilamDosyaSira = ilamDosyaEsas[1]; ilm.ilamiVerenMahkeme =
    // Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].ADLI_BIRIM_ADLIYE_IDSource.ADLIYE; string[]
    // ilamKarar = Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].KARAR_NO.Split('~');
    // ilm.ilamKararNoYil =DateTime.Parse( ilamKarar[0]); ilm.ilamKararSira = ilamKarar[1]; ///
    // ilm.ilamKurumAd=Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].il /// ilm.ilamKurumTip ///
    // TODO : ilam Kurum Ad ve ilm.ilamKurumTip İlam tablosuna Eklenecek ilm.ilamTarihi =
    // Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].KAYIT_TARIHI ; // TODO :
    // //ilm.kesifTarihi=Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].; // ilm.kesinlesmeTarih =
    // Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].KARAR_KESINLESME_TARIHI.Value;
    // //ilm.paraylaOlculemeyenAlacak;

    // bool tcKimlikNoVarmi = false; for (int y = 0; y
    // < Foyum.AV001_TI_BIL_FOY_TARAFCollection.Count; y++) { ilm.tcKimlikNo = Foyum.AV001_TI_BIL_FOY_TARAFCollection[y].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].TC_KIMLIK_NO
    // + ","; tcKimlikNoVarmi = true; } if (tcKimlikNoVarmi) { ilm.tcKimlikNo =
    // ilm.tcKimlikNo.Remove(ilm.tcKimlikNo.Length - 1, 1); } }

    // return returnValues; }

    //        public DigerAlacak GetDigerAlacaklar(AV001_TI_BIL_FOY myFoy)
    //        {
    //            DigerAlacak returnValues = new DigerAlacak();
    //            returnValues.alacakKalemi = new List<AlacakKalemi>();
    //            int[] DigerAlacaklar = new int[] {
    //            53,
    //85,
    //64,
    //65,
    //66,
    //67,
    //68,
    //69,
    //70,
    //71,
    //72,
    //73,
    //74,
    //75,
    //76,
    //55,
    //54,

    // };

    // for (int i = 0; i < myFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++) { if
    // (myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].ALACAK_NEDEN_KOD_ID.HasValue) { for (int y = 0;
    // y < DigerAlacaklar.Length; y++) { if
    // (myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].ALACAK_NEDEN_KOD_ID.Value == DigerAlacaklar[y])
    // { AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i],
    // false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TDI_KOD_DOVIZ_TIP));

    // returnValues.alacakKalemi.Add(GetAlacakKalemi(myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i]));
    // returnValues.alacakNo = ""; returnValues.digerAlacakAciklama =
    // myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].ACIKLAMA; returnValues.Id = "digerAlacak_" +
    // myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].ID.ToString(); returnValues.tarih =
    // myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].KAYIT_TARIHI; returnValues.tutar =
    // myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].TUTARI.ToString(); if
    // (myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].TUTAR_DOVIZ_IDSource != null) {
    // returnValues.tutarAdi =
    // myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].TUTAR_DOVIZ_IDSource.UYAP_ACIKLAMA;
    // returnValues.tutarTur =
    // myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].TUTAR_DOVIZ_IDSource.UYAP_KODU; } } } } } if
    // (returnValues.alacakKalemi.Count==0) { return null; } return returnValues; }

    // string[] GetAdSoyadFromCari(AvukatProLib2.Entities.AV001_TDI_BIL_CARI carim) { string
    // returnValue = ""; string[] strArray = carim.AD.Split(' '); if (strArray.Length <= 1) {
    // strArray = (carim.AD+" -").Split(' '); return strArray; } return strArray; } }

    ////////////public class XmlTree
    ////////////{
    ////////////    public XmlDocumentElement Element { get; set; }
    ////////////    public TreeNode Node { get; set; }
    ////////////    public object Tag { get; set; }
    ////////////}

    //[Serializable]
    //public class Dosya1
    //{
    //    [XmlAttribute("id")]
    //    public int id { get; set; }

    // [XmlAttribute("dosyaTipi")] public string dosyaTipi { get; set; }

    // [XmlAttribute("dosyaTuru")] public int dosyaTuru { get; set; }

    // [XmlAttribute("takipTuru")] public int takipTuru { get; set; }

    // [XmlAttribute("takipYolu")] public int takipYolu { get; set; }

    // [XmlAttribute("takipSekli")] public int takipSekli { get; set; }

    // [XmlAttribute("alacaklininTalepEttigiHak")] public int alacaklininTalepEttigiHak { get; set;
    // }

    // [XmlAttribute("BK84MaddeUygulansin")] public char BK84MaddeUygulansin { get; set; }

    // [XmlAttribute("BSMVUygulansin")] public char BSMVUygulansin { get; set; }

    // [XmlAttribute("KKDFUygulansin")] public char KKDFUygulansin { get; set; }

    // [XmlAttribute("aciklama48e9")] public string aciklama48e9 { get; set; }

    // [XmlAttribute("dosyaBelirleyicisi")] public string dosyaBelirleyicisi { get; set; }

    // [XmlElement("evrak")] public List<Evrak> evraklar { get; set; }
    //}

    //////////[Serializable]
    //////////public class XmlDocumentElement
    //////////{
    //////////    public int Index { get; set; }
    //////////    public string Name { get; set; }
    //////////    public object Data { get; set; }
    //////////    public XmlDocumentElement Parent { get; set; }
    //////////    public List<XmlDocumentElement> Childs { get; set; }
    //////////}
}