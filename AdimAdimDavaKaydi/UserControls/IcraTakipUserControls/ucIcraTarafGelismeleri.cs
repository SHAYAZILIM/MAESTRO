using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.DavaTakip;
using AdimAdimDavaKaydi.Forms.Icra;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Util;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid;
using System.Data;
using AvukatProLib;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public class Gelisme
    {
        public Gelisme()
        { }

        public Gelisme(string _durum, int _deger, DateTime? _tarih)
        {
            Durum = _durum;
            Deger = _deger;
            Tarih = _tarih;
        }

        public int Deger { get; set; }

        public string Durum { get; set; }

        public DateTime? Tarih { get; set; }
    }

    public partial class ucIcraTarafGelismeleri : AvpXUserControl
    {
        public static int BorcluCariID;

        public static TList<AV001_TI_BIL_FOY_TARAF_GELISME> Gelismeler = new TList<AV001_TI_BIL_FOY_TARAF_GELISME>();

        public static AV001_TI_BIL_FOY_TARAF_GELISME myGelisme;

        private static ItirazDurumu itirazDurumu;

        private static KesinlesmeDurumu kesinlesmeDurumu;

        private static decimal odemeMiktari;

        private static DateTime? sonHacizTarihi;

        private static DateTime? sonItirazTarihi;

        private static DateTime? sonMalBeyaniTarihi;

        private static DateTime? sonOdemeTarihi;

        private static DateTime? taahhutuYerineGetirmeTarihi;

        private frmDavaTakip frm;

        private AV001_TI_BIL_FOY myFoy;

        private int styleIndex = -1;

        public ucIcraTarafGelismeleri()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucIcraTarafGelismeleri_Load;
        }

        private enum GelismeColumns
        {
            ACIZ_TARIHI = 1,
            BILA_TARIHI = 2,
            EK_MEHIL_TARIHI = 3,
            GECICI_REHIN_TARIHI = 4,
            IBRA_TARIHI = 5,
            IHTAR_TARIHI = 6,
            IHTAR_TEBLIG_TARIHI = 7,
            IHTIYATI_HACIZ_TALEP_TARIHI = 8,
            IHTIYATI_HACIZ_UYGULAMA_TARIHI = 9,
            IHTIYATI_TEDBIR_TALEP_TARIHI = 10,
            IHTIYATI_TEDBIR_UYGULAMA_TARIHI = 11,
            ILK_TEBLIGAT_TARIHI = 12,
            ITIRAZDAN_VAZGECME_TARIHI = 13,
            ITIRAZIN_KALDIRILMASI_DAVA_TARIHI = 14,
            ITIRAZ_KALDIRILMA_IHTAR_TARIHI = 15,
            ITIRAZ_TARIHI = 16,
            KESINLESME_TARIHI = 17,
            KESIN_REHIN_TARIHI = 18,
            MAL_BEYANI_DAVA_TARIHI = 19,
            MAL_BEYANI_TARIHI = 20,
            MEHIL_TARIHI = 21,
            SATIS_TARIHI = 22,
            SON_HACIZ_TARIHI = 23,
            SON_ITIRAZ_TARIHI = 24,
            SON_ODEME_TARIHI = 25,
            SUBEDEN_OLUMSUZ_CEVAP_TARIHI = 26,
            SUBEDEN_YENI_ADRES_BILDIRILDIGI_TARIH = 27,
            SUBEDEN_YENI_ADRES_ISTEME_TARIHI = 28,
            TAAHHUTU_IHLAL_DAVA_TARIHI = 29,
            TAAHHUT_TARIHI = 30,
            TEMERRUT_TARIHI = 31,
            YUZUC_TARIHI = 32,
            ZABITACA_YENI_ADRES_BULUNDUGU_TARIHI = 33,
            ZABITA_ARASTIRMA_OLUMSUZ_TARIHI = 34,
            ZABITA_ARASTIRMA_TARIHI = 35,
            ZAMAN_ASIMI_TARIHI = 36,
            ESAS_TAKIP_TARIHI = 37
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static ItirazDurumu ItirazDurumu
        {
            get { return ItirazDurumu.ItirazYok; }
            set { ucIcraTarafGelismeleri.itirazDurumu = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static KesinlesmeDurumu KesinlesmeDurumu
        {
            get { return ucIcraTarafGelismeleri.kesinlesmeDurumu; }
            set { ucIcraTarafGelismeleri.kesinlesmeDurumu = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static decimal OdemeMiktari
        {
            get { return ucIcraTarafGelismeleri.odemeMiktari; }
            set { ucIcraTarafGelismeleri.odemeMiktari = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static DateTime? SonHacizTarihi
        {
            get { return ucIcraTarafGelismeleri.sonHacizTarihi; }
            set { ucIcraTarafGelismeleri.sonHacizTarihi = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static DateTime? SonItirazTarihi
        {
            get { return ucIcraTarafGelismeleri.sonItirazTarihi; }
            set { ucIcraTarafGelismeleri.sonItirazTarihi = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static DateTime? SonMalBeyaniTarihi
        {
            get { return ucIcraTarafGelismeleri.sonMalBeyaniTarihi; }
            set { ucIcraTarafGelismeleri.sonMalBeyaniTarihi = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static DateTime? SonOdemeTarihi
        {
            get { return ucIcraTarafGelismeleri.sonOdemeTarihi; }
            set { ucIcraTarafGelismeleri.sonOdemeTarihi = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static DateTime? TaahhutuYerineGetirmeTarihi
        {
            get { return ucIcraTarafGelismeleri.taahhutuYerineGetirmeTarihi; }
            set { ucIcraTarafGelismeleri.taahhutuYerineGetirmeTarihi = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrBorcluId
        {
            get
            {
                return ucIcraTarafBilgileri.CurrBorcluId;
            }
            set
            {
                ucIcraTarafBilgileri.CurrBorcluId = value;
                BorcluCariID = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    BorcluCariID = CurrBorcluId;
                    if (lueTaraf != null)
                        lueTaraf.EditValue = BorcluCariID;
                    if (lueAdliye != null)
                        lueAdliye.EditValue = value.ADLI_BIRIM_ADLIYE_ID;
                    if (lueNo != null)
                        lueNo.EditValue = value.ADLI_BIRIM_NO_ID;
                    if (txtEsasNo != null)
                        txtEsasNo.EditValue = value.ESAS_NO;

                    TList<AV001_TI_BIL_FOY_TARAF_GELISME> result = new TList<AV001_TI_BIL_FOY_TARAF_GELISME>();// Gelismeler;// GelismeleriGuncelle(myFoy, myGelisme);

                    //if (myGelisme == null) //Geliþmelerin refresh olmasý için kapatýldý. MB
                    myGelisme = GelismeBul(value);
                    result.Add(myGelisme);

                    if (vgGelismeler != null)
                        vgGelismeler.DataSource = result;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] Styles
        {
            get
            {
                return new[]
                           {
                               "Caramel", "Money Twins", "Lilian", "The Asphalt World", "iMaginary",
                               "Black", "Blue", "Coffee", "Liquid Sky", "London Liquid Sky",
                               "Glass Oceans", "Stardust", "Xmas 2008 Blue", "Valentine", "McSkin",
                               "Summer 2008", "Office 2007 Blue", "Office 2007 Black", "Office 2007 Silver",
                               "Office 2007 Green", "Office 2007 Pink"
                           };
            }
        }

        public static string CurrTarafAdi(AV001_TI_BIL_FOY_TARAF taraf)
        {
            if (taraf.CARI_IDSource == null)
                taraf.CARI_IDSource = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(taraf.CARI_ID.Value);

            return taraf.CARI_IDSource.AD;
        }

        public static bool DosyadaHacizVarmi(AV001_TI_BIL_FOY MyFoy)
        {
            if (MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.Count > 0)
                return true;

            return false;
        }

        public static bool DosyadaItýrazVarmi(AV001_TI_BIL_FOY MyFoy)
        {
            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                if (neden.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection.Count == 0)
                    continue;
                else
                    return true;
            }

            return false;
        }

        public static TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> DosyaMuhataplariniGetir(AV001_TI_BIL_FOY foy)
        {
            AV001_TDI_BIL_TEBLIGAT tebligat = TebligatBul(foy, 4, 11, false);

            TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> result = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();

            result =
                tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.FindAll(
                    delegate(AV001_TDI_BIL_TEBLIGAT_MUHATAP muh) { return (muh.MUHATAP_CARI_ID == ucIcraTarafBilgileri.CurrBorcluId); });

            return result;
        }

        public static void DurumYaz(AV001_TI_BIL_FOY_TARAF_GELISME gelisme)
        {
            gelisme.ACIZ_TARIHI_DURUMU = string.Empty;
            gelisme.IBRA_TARIHI_DURUMU = string.Empty;
            gelisme.GECICI_REHIN_TARIHI_DURUMU = string.Empty;
            gelisme.KESIN_REHIN_TARIHI_DURUMU = string.Empty;

            if (gelisme.ACIZ_TARIHI.HasValue)
                gelisme.ACIZ_TARIHI_DURUMU = "Aciz Belgesi Alýndý";

            if (gelisme.IBRA_TARIHI.HasValue)
                gelisme.IBRA_TARIHI_DURUMU = "Ýbra Edildi";

            if (gelisme.GECICI_REHIN_TARIHI.HasValue)
                gelisme.GECICI_REHIN_TARIHI_DURUMU = "G.Rehin Açýðý";

            if (gelisme.KESIN_REHIN_TARIHI.HasValue)
                gelisme.KESIN_REHIN_TARIHI_DURUMU = "K.Rehin Açýðý";

            if (gelisme.ZAMAN_ASIMI_TARIHI.HasValue)
                gelisme.ZAMAN_ASIMI_TARIHI_DURUMU = "Zaman Aþýmý";
        }

        public static void FoyTarafUzerindekileriHesapla(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY_TARAF MyTaraf)
        {
            GonderilenGelisme.GECICI_REHIN_TARIHI = null;
            GonderilenGelisme.KESIN_REHIN_TARIHI = null;
            GonderilenGelisme.ACIZ_TARIHI = null;
            GonderilenGelisme.IBRA_TARIHI = null;

            if (MyTaraf.GECICI_REHIN_ACIGI_TARIHI.HasValue)
            {
                GonderilenGelisme.GECICI_REHIN_TARIHI = MyTaraf.GECICI_REHIN_ACIGI_TARIHI;
            }
            if (MyTaraf.KESIN_REHIN_ACIGI_TARIHI.HasValue)
            {
                GonderilenGelisme.KESIN_REHIN_TARIHI =
                    MyTaraf.KESIN_REHIN_ACIGI_TARIHI;
            }
            if (MyTaraf.KESIN_REHIN_ACIGI_TARIHI.HasValue || MyTaraf.GECICI_REHIN_ACIGI_TARIHI.HasValue)
            {
                GonderilenGelisme.KESIN_REHIN_TARIHI = MyTaraf.KESIN_REHIN_ACIGI_TARIHI;
            }

            GonderilenGelisme.ACIZ_TARIHI = MyTaraf.ACIZ_TARIHI;

            GonderilenGelisme.IBRA_TARIHI = MyTaraf.IBRA_TARIHI;

            DurumYaz(GonderilenGelisme);
        }

        public static TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> GecikmisItirazlariBul(AV001_TI_BIL_FOY MyFoy)
        {
            return MyFoy.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection.FindAll(
                delegate(AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN itiraz)
                {
                    return (itiraz.GECIKMIS_ITIRAZ_MI && itiraz.ITIRAZ_EDEN_TARAF_ID ==
                                                         ucIcraTarafBilgileri.CurrBorcluId &&
                            itiraz.ITIRAZ_TARIHI != null);
                });
        }

        public static bool GecikmisItirazMi(AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN itiraz)
        {
            if (itiraz.GECIKMIS_ITIRAZ_MI)
                return true;

            return false;
        }

        //Kaydet ve Güncelleme iþleminin kullanýldýðý metod.
        public static void GelismeIslemleri(AV001_TI_BIL_FOY myFoy)
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                if (myFoy == null) return;

                if (myFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>));

                foreach (var item in myFoy.AV001_TI_BIL_FOY_TARAFCollection)
                {
                    //if (item.TARAF_KODU == (int)TarafKodu.KarsiTaraf)
                    //{
                    if (!item.TAKIP_EDEN_MI)
                    {
                        if (item.CARI_ID.HasValue)
                        {
                            ucIcraTarafBilgileri.CurrBorcluId = item.CARI_ID.Value;
                            BorcluCariID = item.CARI_ID.Value;
                            myFoy.AV001_TI_BIL_FOY_TARAF_GELISMECollection = GelismeleriGuncelle(myFoy, null);
                        }
                    }
                }

                foreach (var item in myFoy.AV001_TI_BIL_FOY_TARAF_GELISMECollection)
                {
                    GelismleriKaydet(tran, item, myFoy, true);
                }
            }
            catch
            {
                if (tran.IsOpen)
                    tran.Rollback();
            }
        }

        public static TList<AV001_TI_BIL_FOY_TARAF_GELISME> GelismeleriGuncelle(AV001_TI_BIL_FOY Foy, AV001_TI_BIL_FOY_TARAF_GELISME Gelisme)
        {
            //if (Gelisme != null)
            //{
            //    int icraTarafID = (int)Gelisme.ICRA_FOY_TARAF_ID;
            //    BorcluCariID = (int)DataRepository.AV001_TI_BIL_FOY_TARAFProvider.GetByID(icraTarafID).CARI_ID;
            //}
            //if (myGelisme == null)
            myGelisme = GelismeBul(Foy);

            Gelisme = myGelisme;

            NedenTarafUzerindekileriHesapla(Gelisme, Foy);

            if (Foy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(Foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));

            if (Gelisme.ICRA_FOY_TARAF_ID.HasValue)
                FoyTarafUzerindekileriHesapla(Gelisme, Foy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.ID == Gelisme.ICRA_FOY_TARAF_ID));
            else
                FoyTarafUzerindekileriHesapla(Gelisme, Foy.AV001_TI_BIL_FOY_TARAFCollection.Find(vi => vi.CARI_ID == ucIcraTarafBilgileri.CurrBorcluId));

            TebligatTarihiHesapla(Gelisme, Foy);
            YuzucTarihiHesapla(Gelisme, Foy);
            HacizTarihiHesapla(Gelisme, Foy);
            ItirazTarihiHesapla(Gelisme, Foy);
            MalBeyaniTarihiHesapla(Gelisme, Foy);
            KesinlesmeTarihiHesapla(Gelisme, Foy);
            SonSatisTarihiHesapla(Gelisme, Foy);
            OdemeTarihiHesapla(Gelisme, Foy);
            IhtiyatiHacizHesapla(Gelisme, Foy);
            IhtiyatiHacizUygulamaHesapla(Gelisme, Foy);
            IhtiyatiTedbirHesapla(Gelisme, Foy);
            IhtiyatiTedbirUygulamaHesapla(Gelisme, Foy);
            IhlalDavaTarihiHesapla(Gelisme, Foy);
            MalBeyaniDavasýTarihiHesapla(Gelisme, Foy);
            ItirazDavasýTarihiHesapla(Gelisme, Foy);

            //TaahhutHesapla(Gelisme, Foy);
            TaahhutleriHesapla(Gelisme, Foy);
            MehilTarihiHesapla(Gelisme, Foy);
            SonGelismeyiHesapla(Gelisme);
            Gelismeler.Clear();//Geliþmelerin refresh olmasý için eklendi. MB
            Gelismeler.Add(Gelisme);

            return Gelismeler;
        }

        public static DateTime? HacizTarihiHesapla(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy)
        {
            AV001_TI_BIL_HACIZ_MASTER result = SonHacizKaydýnýGetir(MyFoy);

            GonderilenGelisme.SON_HACIZ_TARIHI = null;
            GonderilenGelisme.SON_HACIZ_TARIHI_DURUMU = string.Empty;

            if (result != null)
            {
                if (result.MUHAFAZALI_KAYIT_VAR_MI)
                {
                    GonderilenGelisme.SON_HACIZ_TARIHI = result.HACIZ_TARIHI;
                    GonderilenGelisme.SON_HACIZ_TARIHI_DURUMU = "Muhafazalý";
                }
                else if (result.AV001_TI_BIL_HACIZ_CHILDCollection.Count < 1)
                {
                    GonderilenGelisme.SON_HACIZ_TARIHI = result.HACIZ_TARIHI;
                    GonderilenGelisme.SON_HACIZ_TARIHI_DURUMU = "Mal Bulunamadý";
                }
                else
                {
                    GonderilenGelisme.SON_HACIZ_TARIHI = result.HACIZ_TARIHI;
                    GonderilenGelisme.SON_HACIZ_TARIHI_DURUMU = "Muhafazasýz " + string.Format("{0:N2}", result.HACIZ_TOPLAM_DEGERI);
                }
                if (MyFoy.FORM_TIP_ID == (int)FormTipleri.Form50 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form201)
                {
                    GonderilenGelisme.SON_HACIZ_TARIHI = result.HACIZ_TARIHI;
                    GonderilenGelisme.SON_HACIZ_TARIHI_DURUMU = "Rehinli";
                }
                else if (MyFoy.FORM_TIP_ID == (int)FormTipleri.Form151 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form152)
                {
                    GonderilenGelisme.SON_HACIZ_TARIHI = result.HACIZ_TARIHI;
                    GonderilenGelisme.SON_HACIZ_TARIHI_DURUMU = "Ýpotekli";
                }
            }

            else
            {
                if (GonderilenGelisme.KESINLESME_TARIHI.HasValue)
                {
                    switch ((FormTipleri)MyFoy.FORM_TIP_ID.Value)
                    {
                        case FormTipleri.Form51:
                        case FormTipleri.Form52:
                        case FormTipleri.Form49:
                        case FormTipleri.Form153:
                        case FormTipleri.Form163:
                            SonItirazTarihi = HSonuOnemliGunKontrol
                                (GonderilenGelisme.KESINLESME_TARIHI.Value.AddYears(1));

                            break;
                    }
                }

                if (SonHacizTarihi.HasValue)
                {
                    //GonderilenGelisme.SON_HACIZ_TARIHI = GonderilenGelisme.SON_HACIZ_TARIHI.Value;
                    GonderilenGelisme.SON_HACIZ_TARIHI_DURUMU = "Son H.T" + SonHacizTarihi.Value.ToShortDateString();
                }
            }

            return GonderilenGelisme.SON_HACIZ_TARIHI;
        }

        public static DateTime? HSonuOnemliGunKontrol(DateTime HesaplanacakTarih)
        {
            foreach (TDI_BIL_ONEMLI_GUN g in DataRepository.TDI_BIL_ONEMLI_GUNProvider.GetByTARIH_KATEGORI_ID(3))
            {
                if (g.BASLAMA_TARIHI == HesaplanacakTarih)
                    HesaplanacakTarih = HesaplanacakTarih.AddDays(1);

                if (HesaplanacakTarih.DayOfWeek == DayOfWeek.Saturday || HesaplanacakTarih.DayOfWeek == DayOfWeek.Sunday)
                    HesaplanacakTarih = HesaplanacakTarih.AddDays(1);

                if (HesaplanacakTarih.DayOfWeek == DayOfWeek.Saturday || HesaplanacakTarih.DayOfWeek == DayOfWeek.Sunday)
                    HSonuOnemliGunKontrol(HesaplanacakTarih);
            }

            return HesaplanacakTarih;
        }

        public static DateTime? IhlalDavaTarihiHesapla(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy)
        {
            GonderilenGelisme.TAAHHUTU_IHLAL_DAVA_TARIHI = null;
            GonderilenGelisme.TAAHHUTU_IHLAL_DAVA_TARIHI_DURUMU = string.Empty;
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.ICRA_DAIRESINDE_KARARLASTIRILAN_BORCUN_ODEME_SARTINI_IHLAL_ETMEK);
            TList<AV001_TD_BIL_FOY> result = IliskiliDavaKayitlari(MyFoy, dList);
            if (result.Count > 0)
            {
                result.Sort("DAVA_TARIHI DESC");
                string durum = DataRepository.per_TDI_KOD_FOY_DURUMProvider.Get("ID=" + result[0].FOY_DURUM_ID, "ID").FirstOrDefault().DURUM;
                GonderilenGelisme.TAAHHUTU_IHLAL_DAVA_TARIHI = result[0].DAVA_TARIHI;

                //GonderilenGelisme.TAAHHUTU_IHLAL_DAVA_TARIHI_DURUMU = "Dava kaydý var";
                GonderilenGelisme.TAAHHUTU_IHLAL_DAVA_TARIHI_DURUMU = durum;
            }

            return GonderilenGelisme.TAAHHUTU_IHLAL_DAVA_TARIHI;
        }

        public static bool IhlalVarmi(TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER> TaahhutMaster)
        {
            AV001_TI_BIL_BORCLU_TAAHHUT_MASTER gecerliTaahhut =
                TaahhutMaster.Find(AV001_TI_BIL_BORCLU_TAAHHUT_MASTERColumn.TAAHHUT_TARIHI, TaahhutMaster.Select(t => t.TAAHHUT_TARIHI).Max());

            if (gecerliTaahhut != null)
            {
                foreach (AV001_TI_BIL_BORCLU_TAAHHUT_CHILD child in
                        gecerliTaahhut.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection)
                {
                    if (child.DURUM_ID == 4 || child.DURUM_ID == 6 || child.DURUM_ID == 7 || child.DURUM_ID == 8)
                    {
                        TaahhutuYerineGetirmeTarihi = child.TAAHHUTU_YERINE_GETIRME_TARIHI;
                        return true;
                    }
                }
            }

            return false;
        }

        public static AV001_TI_BIL_IHTIYATI_HACIZ IhtiyatiHacizGetir(AV001_TI_BIL_FOY MyFoy)
        {
            TList<AV001_TI_BIL_IHTIYATI_HACIZ> result = new TList<AV001_TI_BIL_IHTIYATI_HACIZ>();

            if (MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ>));

            foreach (AV001_TI_BIL_IHTIYATI_HACIZ haciz in MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection)
            {
                if (haciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.DeepLoad(haciz, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ_TARAF>));

                foreach (AV001_TI_BIL_IHTIYATI_HACIZ_TARAF taraf in haciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection)
                {
                    if (taraf.ICRA_CARI_TARAF_ID == ucIcraTarafBilgileri.CurrBorcluId)
                        result.Add(haciz);
                }
            }

            if (result.Count > 0)
            {
                result.Sort("TALEP_TARIHI DESC");

                return result[0];
            }

            return null;
        }

        public static void IhtiyatiHacizHesapla(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy)
        {
            GonderilenGelisme.IHTIYATI_HACIZ_TALEP_TARIHI = null;
            GonderilenGelisme.IHTIYATI_HACIZ_TALEP_TARIHI_DURUMU = string.Empty;

            AV001_TI_BIL_IHTIYATI_HACIZ result = IhtiyatiHacizGetir(MyFoy);
            AV001_TI_BIL_HACIZ_MASTER result2 = SonHacizKaydýnýGetir(MyFoy);

            if (result != null && result.TALEP_TARIHI.HasValue)
            {
                //result.Sort("TALEP_TARIHI DESC");
                GonderilenGelisme.IHTIYATI_HACIZ_TALEP_TARIHI = result.TALEP_TARIHI;

                GonderilenGelisme.IHTIYATI_HACIZ_TALEP_TARIHI_DURUMU = "Ý.Haciz Ýstendi";

                if (!GonderilenGelisme.IHTIYATI_HACIZ_UYGULAMA_TARIHI.HasValue && result.KARAR_TARIHI.HasValue)
                    GonderilenGelisme.IHTIYATI_HACIZ_UYGULAMA_TARIHI_DURUMU = "Son T.- " + HSonuOnemliGunKontrol(result.KARAR_TARIHI.Value.AddDays(10)).Value.ToShortDateString();
            }
            if (result != null && result.K_H_CEVIRME_TARIHI.HasValue)
            {
                GonderilenGelisme.ESAS_TAKIP_TARIHI = result.K_H_CEVIRME_TARIHI.Value;
                GonderilenGelisme.ESAS_TAKIP_TARIHI_DURUMU = "Takibe Geçildi";
            }
            else if (result != null && result.KARAR_TARIHI.HasValue)
            {
                GonderilenGelisme.ESAS_TAKIP_TARIHI_DURUMU = "ETGT :" + SureHesapla(SureTipi.IH_TAKIBE_KOYMA_SURESI, result.KARAR_TARIHI.Value, MyFoy).Value.ToString("dd.MM.yyyy");
            }
            else if (result2 != null)
            {
                GonderilenGelisme.ESAS_TAKIP_TARIHI_DURUMU = "ETGT :" + SureHesapla(SureTipi.IH_UYGULAMA_SURESI, result2.HACIZ_TARIHI, MyFoy).Value.ToString("dd.MM.yyyy");
            }
        }

        public static TList<AV001_TI_BIL_IHTIYATI_HACIZ> IhtiyatiHacizleriGetir(AV001_TI_BIL_FOY MyFoy)
        {
            TList<AV001_TI_BIL_IHTIYATI_HACIZ> result = new TList<AV001_TI_BIL_IHTIYATI_HACIZ>();

            foreach (AV001_TI_BIL_IHTIYATI_HACIZ haciz in MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection)
            {
                foreach (AV001_TI_BIL_IHTIYATI_HACIZ_TARAF taraf in haciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection)
                {
                    if (taraf.ICRA_CARI_TARAF_ID == ucIcraTarafBilgileri.CurrBorcluId)
                        result.Add(haciz);
                }
            }

            return result;
        }

        public static void IhtiyatiHacizUygulamaHesapla(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy)
        {
            GonderilenGelisme.IHTIYATI_HACIZ_UYGULAMA_TARIHI = null;
            GonderilenGelisme.IHTIYATI_HACIZ_UYGULAMA_TARIHI_DURUMU = string.Empty;

            AV001_TI_BIL_HACIZ_MASTER result = SonHacizKaydýnýGetir(MyFoy);
            TList<AV001_TI_BIL_IHTIYATI_HACIZ> ihtHaciz = IhtiyatiHacizleriGetir(MyFoy);

            if (result != null && result.AV001_TI_BIL_HACIZ_CHILDCollection.Count > 0)
            {
                GonderilenGelisme.IHTIYATI_HACIZ_UYGULAMA_TARIHI = result.HACIZ_TARIHI;

                GonderilenGelisme.IHTIYATI_HACIZ_UYGULAMA_TARIHI_DURUMU = "Uygulandý";
            }
            else if (result != null && result.AV001_TI_BIL_HACIZ_CHILDCollection.Count < 1)
            {
                GonderilenGelisme.IHTIYATI_HACIZ_UYGULAMA_TARIHI = result.HACIZ_TARIHI;
                GonderilenGelisme.IHTIYATI_HACIZ_UYGULAMA_TARIHI_DURUMU = "Mal Bulunamadý";
            }
            else
            {
                if (!GonderilenGelisme.IHTIYATI_HACIZ_UYGULAMA_TARIHI.HasValue && ihtHaciz.Count > 0)
                {
                    if (ihtHaciz[0].KARAR_TARIHI.HasValue)
                        GonderilenGelisme.IHTIYATI_HACIZ_UYGULAMA_TARIHI_DURUMU = "Son T.-" + HSonuOnemliGunKontrol(ihtHaciz[0].KARAR_TARIHI.Value.AddDays(10)).Value.ToShortDateString();
                }
            }
        }

        public static TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> IhtiyatiTedbirGetir(AV001_TI_BIL_FOY MyFoy)
        {
            TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> result = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>();

            if (MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>));

            foreach (AV001_TDI_BIL_IHTIYATI_TEDBIR tedbir in MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection)
            {
                if (tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection.Count == 0)
                    DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.DeepLoad(tedbir, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF>));

                foreach (AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF taraf in tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection)
                {
                    if (taraf.ICRA_CARI_TARAF_ID == ucIcraTarafBilgileri.CurrBorcluId)
                        result.Add(tedbir);
                }
            }
            result.Sort("TALEP_TARIHI DESC");
            return result;
        }

        public static void IhtiyatiTedbirHesapla(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy)
        {
            GonderilenGelisme.IHTIYATI_TEDBIR_TALEP_TARIHI = null;
            GonderilenGelisme.IHTIYATI_TEDBIR_UYGULAMA_TARIHI_DURUMU = string.Empty;
            GonderilenGelisme.IHTIYATI_TEDBIR_TALEP_TARIHI_DURUMU = string.Empty;

            TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> result = IhtiyatiTedbirGetir(MyFoy);

            if (result.Count > 0)
            {
                result.Sort("TALEP_TARIHI DESC");
                GonderilenGelisme.IHTIYATI_TEDBIR_TALEP_TARIHI =
                    result[0].TALEP_TARIHI;

                GonderilenGelisme.IHTIYATI_TEDBIR_TALEP_TARIHI_DURUMU = "Ý.Tedbir Ýstendi";

                if (!GonderilenGelisme.IHTIYATI_TEDBIR_UYGULAMA_TARIHI.HasValue && result[0].KARAR_TARIHI.HasValue)
                    GonderilenGelisme.IHTIYATI_TEDBIR_UYGULAMA_TARIHI_DURUMU = "Son T.- " +
                                                                               HSonuOnemliGunKontrol(
                                                                                   result[0].KARAR_TARIHI.Value.AddDays(
                                                                                       10)).Value.ToShortDateString();
            }
        }

        public static void IhtiyatiTedbirUygulamaHesapla(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy)
        {
            GonderilenGelisme.IHTIYATI_TEDBIR_UYGULAMA_TARIHI = null;
            GonderilenGelisme.IHTIYATI_TEDBIR_UYGULAMA_TARIHI_DURUMU = string.Empty;

            AV001_TI_BIL_HACIZ_MASTER result = SonHacizKaydýnýGetir(MyFoy);
            TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> ihtTedbir = IhtiyatiTedbirGetir(MyFoy);

            if (result != null)
            {
                GonderilenGelisme.IHTIYATI_TEDBIR_UYGULAMA_TARIHI = result.HACIZ_TARIHI;

                GonderilenGelisme.IHTIYATI_TEDBIR_UYGULAMA_TARIHI_DURUMU = "Uygulandý";
            }
            else
            {
                if (!GonderilenGelisme.IHTIYATI_TEDBIR_UYGULAMA_TARIHI.HasValue && ihtTedbir.Count > 0)
                {
                    if (ihtTedbir[0].KARAR_TARIHI.HasValue)
                        GonderilenGelisme.IHTIYATI_TEDBIR_UYGULAMA_TARIHI_DURUMU = "Son T.-" +
                                                                                   HSonuOnemliGunKontrol(
                                                                                       ihtTedbir[0].KARAR_TARIHI.Value.
                                                                                           AddDays(10)).Value.
                                                                                       ToShortDateString();
                }
            }
        }

        public static TList<AV001_TD_BIL_FOY> IliskiliDavaKayitlari(AV001_TI_BIL_FOY MyFoy, List<DavaAdi> davaAdlari)
        {
            TList<AV001_TD_BIL_FOY> result = new TList<AV001_TD_BIL_FOY>();
            TList<AV001_TDI_BIL_KAYIT_ILISKI> kayitlar = KayitIliskiGetir(MyFoy.ID);

            if (kayitlar != null)
            {
                foreach (AV001_TDI_BIL_KAYIT_ILISKI master in kayitlar)
                {
                    List<int?> davaFoyIdList = (from item in master.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection where item.HEDEF_DAVA_FOY_ID.HasValue select item.HEDEF_DAVA_FOY_ID).ToList();
                    foreach (var id in davaFoyIdList)
                    {
                        var foy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)id);
                        if (foy != null && IsValid(foy.ID, davaAdlari))
                            result.Add(foy);
                    }
                }
            }

            return result;
        }

        public static bool IsValid(int davaFoyId, List<DavaAdi> davaAdlari) // Okan 20.08.2010
        {
            List<int> list = new List<int>();
            davaAdlari.ForEach(item => list.Add((int)item));
            return BelgeUtil.Inits.context.AV001_TD_BIL_FOYs.Count(item => item.ID == davaFoyId && item.AV001_TD_BIL_DAVA_NEDENs.Count(dn => dn.DAVA_NEDEN_KOD_ID.HasValue && list.Contains(dn.DAVA_NEDEN_KOD_ID.Value)) > 0 && item.AV001_TD_BIL_FOY_TARAFs.Count(t => t.CARI_ID == ucIcraTarafBilgileri.CurrBorcluId) > 0) > 0;
        }

        public static DateTime? ItirazDavasýTarihiHesapla(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy)
        {
            GonderilenGelisme.ITIRAZIN_KALDIRILMASI_DAVA_TARIHI = null;
            GonderilenGelisme.ITIRAZIN_KALDIRILMASI_DAVA_TARIHI_DURUMU = string.Empty;
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.ITIRAZIN_GECICI_OLARAK_KALDIRILMASI);
            dList.Add(DavaAdi.ITIRAZIN_KALDIRILMASI_VE_TAHLIYE);
            dList.Add(DavaAdi.ITIRAZIN_KESIN_OLARAK_KALDIRILMASI);

            TList<AV001_TD_BIL_FOY> result = IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count > 0)
            {
                result.Sort("DAVA_TARIHI DESC");
                string durum = DataRepository.per_TDI_KOD_FOY_DURUMProvider.Get("ID=" + result[0].FOY_DURUM_ID, "ID").FirstOrDefault().DURUM;
                GonderilenGelisme.ITIRAZIN_KALDIRILMASI_DAVA_TARIHI = result[0].DAVA_TARIHI;

                //GonderilenGelisme.ITIRAZIN_KALDIRILMASI_DAVA_TARIHI_DURUMU = "Ýtiraz davasý var" + " (" + durum + ")";

                GonderilenGelisme.ITIRAZIN_KALDIRILMASI_DAVA_TARIHI_DURUMU = durum;

                TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> itirazlar =
                   DataRepository.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENProvider.GetByICRA_FOY_ID(MyFoy.ID);
                if (itirazlar.Count == itirazlar.FindAll(i => i.ITIRAZ_SONUC_ID == (int)ItirazSonucu.KABUL_EDILDI).Count + itirazlar.FindAll(i => !i.ITIRAZ_SONUC_ID.HasValue).Count)
                {
                    GonderilenGelisme.KESINLESME_TARIHI = null;
                    GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Kesinleþmedi";
                    GonderilenGelisme.ITIRAZ_TARIHI_DURUMU = "Kabul Edildi";
                }
                else if (itirazlar.Count == itirazlar.FindAll(i => i.ITIRAZ_SONUC_ID == (int)ItirazSonucu.REDDEDILDI).Count + itirazlar.FindAll(i => !i.ITIRAZ_SONUC_ID.HasValue).Count)
                {
                    GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Kesinleþti";
                    GonderilenGelisme.ITIRAZ_TARIHI_DURUMU = "Reddedildi";
                }
                else if (itirazlar.Count == itirazlar.FindAll(i => i.ITIRAZ_SONUC_ID == (int)ItirazSonucu.INCELENIYOR).Count + itirazlar.FindAll(i => !i.ITIRAZ_SONUC_ID.HasValue).Count)
                {
                    GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Kesinleþmedi";
                    GonderilenGelisme.ITIRAZ_TARIHI_DURUMU = "Ýnceleniyor";
                }
                else
                {
                    GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Kýsmen Kesinleþti";
                    GonderilenGelisme.ITIRAZ_TARIHI_DURUMU = "Kýsmen Kabul";
                }
            }

            return GonderilenGelisme.MAL_BEYANI_DAVA_TARIHI;
        }

        public static AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN ItirazGetir(AV001_TI_BIL_FOY MyFoy)
        {
            TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> result = new TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>();

            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(neden, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>));
                foreach (AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN itiraz in neden.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection)
                {
                    if (itiraz.ITIRAZ_EDEN_TARAF_ID == ucIcraTarafBilgileri.CurrBorcluId)
                        result.Add(itiraz);
                }
            }

            if (result.Count > 0)
            {
                result.Sort("ITIRAZ_TARIHI DESC");
                return result[0];
            }

            return null;
        }

        public static bool ItirazlarinHepsiGecikmis(AV001_TI_BIL_FOY MyFoy)
        {
            if (GecikmisItirazlariBul(MyFoy).Count == MyFoy.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection.Count)
                return true;

            return false;
        }

        public static ItirazDurumu ItirazTarihiHesapla(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy)
        {
            if (MyFoy.FORM_TIP_ID == (int)FormTipleri.Form50 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form55 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form56 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form151 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form152 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form201)
                return ItirazDurumu.NULL;

            int t = TarafIndexBul(MyFoy);

            AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatap = MuhatapBul(TebligatBul(MyFoy, 4, 11, false));

            if (muhatap == null || MyFoy.FORM_TIP_IDSource.ILAMLI_MI)
            {
                GonderilenGelisme.SON_ITIRAZ_TARIHI = null;
                GonderilenGelisme.SON_ITIRAZ_TARIHI_DURUMU = string.Empty;
                return ItirazDurumu.ItirazYok;
            }

            AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN itiraz = ItirazGetir(MyFoy);

            //Tarafýn hiç itirazý yok ise...
            if (itiraz == null)
            {
                if (muhatap.TEBLIG_TARIH.HasValue)
                {
                    SonItirazTarihi = SureHesapla(SureTipi.ITIRAZ_SURESI, muhatap.TEBLIG_TARIH.Value, MyFoy);
                    GonderilenGelisme.SON_ITIRAZ_TARIHI = sonItirazTarihi;
                    if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count > 0)
                        MyFoy.AV001_TI_BIL_FOY_TARAFCollection[t].SON_ITIRAZ_TARIHI = SonItirazTarihi;
                    if (GonderilenGelisme.SON_ITIRAZ_TARIHI <= DateTime.Now.Date)
                        GonderilenGelisme.SON_ITIRAZ_TARIHI_DURUMU = "Ýtiraz Yok";
                    else
                        GonderilenGelisme.SON_ITIRAZ_TARIHI_DURUMU = string.Empty;
                    ItirazDurumu = ItirazDurumu.ItirazYok;
                }
            }
            else
            {
                GonderilenGelisme.SON_ITIRAZ_TARIHI_DURUMU = string.Empty;
                if (GecikmisItirazMi(itiraz) && itiraz.ITIRAZ_TARIHI > SonItirazTarihi)
                {
                    GonderilenGelisme.SON_ITIRAZ_TARIHI = SonItirazTarihi;
                    GonderilenGelisme.ITIRAZ_TARIHI = itiraz.ITIRAZ_TARIHI;
                    GonderilenGelisme.ITIRAZ_TARIHI_DURUMU = "Geçerli Ýtiraz";

                    ItirazDurumu = ItirazDurumu.GecikmisItiraz;
                }

                #region En son Degisenler

                //gecikmisItirazlar = GecikmisItirazlariBul(MyFoy);
                //if (ItirazlarinHepsiGecikmis(MyFoy))
                //{
                //GonderilenGelisme.ITIRAZ_TARIHI = MyFoy.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection[i].ITIRAZ_TARIHI;
                //GonderilenGelisme.ITIRAZ_TARIHI_DURUMU = "Gecikmiþ";

                //GonderilenGelisme.SON_ITIRAZ_TARIHI = MyFoy.AV001_TI_BIL_FOY_TARAFCollection[t].SON_ITIRAZ_TARIHI;
                //GonderilenGelisme.SON_ITIRAZ_TARIHI_DURUMU = string.Empty;

                //return ItirazDurumu.GecikmisItiraz;
                //}

                //if (!ItirazlarinHepsiGecikmis(MyFoy))
                //{
                //    MyFoy.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection.Sort("ITIRAZ_TARIHI DESC");

                //    if (MyFoy.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection[0].ITIRAZ_TARIHI < GonderilenGelisme.SON_ITIRAZ_TARIHI)
                //    {
                //        GonderilenGelisme.SON_ITIRAZ_TARIHI = MyFoy.AV001_TI_BIL_FOY_TARAFCollection[t].SON_ITIRAZ_TARIHI;
                //        GonderilenGelisme.SON_ITIRAZ_TARIHI_DURUMU = string.Empty;
                //    }
                //}

                //if (gecikmisItirazlar.Count > 0)
                //{
                //    GonderilenGelisme.ITIRAZ_TARIHI = MyFoy.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection[i].ITIRAZ_TARIHI;
                //    GonderilenGelisme.ITIRAZ_TARIHI_DURUMU = "Gecikmiþ Kýsmi";

                //    GonderilenGelisme.SON_ITIRAZ_TARIHI = MyFoy.AV001_TI_BIL_FOY_TARAFCollection[t].SON_ITIRAZ_TARIHI;
                //    GonderilenGelisme.SON_ITIRAZ_TARIHI_DURUMU = string.Empty;

                //    return ItirazDurumu.GecikmisKismi;
                //}

                #endregion En son Degisenler

                if (itiraz.ITIRAZ_TARIHI != null)
                {
                    GonderilenGelisme.ITIRAZ_TARIHI = itiraz.ITIRAZ_TARIHI;
                }
                if (!GecikmisItirazMi(itiraz) && SonItirazTarihi.HasValue)
                {
                    if (itiraz.ITIRAZ_TARIHI > SonItirazTarihi)
                    {
                        GonderilenGelisme.SON_ITIRAZ_TARIHI = SonItirazTarihi;
                        GonderilenGelisme.SON_ITIRAZ_TARIHI_DURUMU = string.Empty;

                        GonderilenGelisme.ITIRAZ_TARIHI = itiraz.ITIRAZ_TARIHI;
                        GonderilenGelisme.ITIRAZ_TARIHI_DURUMU = "Geçersiz Ýtiraz";

                        ItirazDurumu = ItirazDurumu.ÝtirazVar;
                    }
                }
                if (SonItirazTarihi.HasValue && itiraz.ITIRAZ_TARIHI <= SonItirazTarihi.Value)
                {
                    GonderilenGelisme.ITIRAZ_TARIHI = itiraz.ITIRAZ_TARIHI;
                    GonderilenGelisme.ITIRAZ_TARIHI_DURUMU = "Ýtiraz Var";

                    GonderilenGelisme.SON_ITIRAZ_TARIHI = SonItirazTarihi;
                    GonderilenGelisme.SON_ITIRAZ_TARIHI_DURUMU = string.Empty;

                    ItirazDurumu = ItirazDurumu.ÝtirazVar;
                }

                if (itiraz.ITIRAZDAN_VAZGECME_TARIHI.HasValue)
                {
                    GonderilenGelisme.SON_ITIRAZ_TARIHI_DURUMU = string.Empty;
                    GonderilenGelisme.ITIRAZDAN_VAZGECME_TARIHI = itiraz.ITIRAZDAN_VAZGECME_TARIHI;
                    GonderilenGelisme.ITIRAZDAN_VAZGECME_TARIHI_DURUMU = "Ýtiraz Vazgeçildi";
                }
                if (itiraz.ITIRAZ_KALDIRILMA_IHTAR_TARIHI.HasValue)
                {
                    GonderilenGelisme.SON_ITIRAZ_TARIHI_DURUMU = string.Empty;
                    GonderilenGelisme.ITIRAZ_KALDIRILMA_IHTAR_TARIHI = itiraz.ITIRAZ_KALDIRILMA_IHTAR_TARIHI;
                    GonderilenGelisme.ITIRAZ_KALDIRILMA_IHTAR_TARIHI_DURUMU = "Ýtirazýn Kaldýrýlmasý Ýhtar Edildi";
                }
                if (itiraz.ITIRAZ_SONUC_ID == (int)ItirazSonucu.KABUL_EDILDI)
                {
                }

                //Bu durumda itiraz sonucu hesapla
                //Teblig Tarihinden itibaren süre hesaplamasý yapýlýyor.
                if (muhatap.TEBLIG_TARIH.HasValue)
                {
                    SonItirazTarihi = SureHesapla(SureTipi.ITIRAZ_SURESI, muhatap.TEBLIG_TARIH.Value, MyFoy);
                    GonderilenGelisme.SON_ITIRAZ_TARIHI = sonItirazTarihi;

                    //GonderilenGelisme.SON_ITIRAZ_TARIHI_DURUMU = "Ýtiraz Yok";
                    ItirazDurumu = ItirazDurumu.ItirazYok;
                }
            }

            return ItirazDurumu;
        }

        public static TList<AV001_TDI_BIL_KAYIT_ILISKI> KayitIliskiGetir(int FoyId)
        {
            TList<AV001_TDI_BIL_KAYIT_ILISKI> result = new TList<AV001_TDI_BIL_KAYIT_ILISKI>();

            result = DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.Find(string.Format("KAYNAK_KAYIT_ID = {0}", FoyId));

            DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.DeepLoad(result, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>));

            return result;
        }

        public static DateTime? KesinlesmeTarihiHesapla(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy)
        {
            GonderilenGelisme.KESINLESME_TARIHI = null;
            GonderilenGelisme.KESINLESME_TARIHI_DURUMU = string.Empty;

            AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatap = MuhatapBul(TebligatBul(MyFoy, 4, 11, false));
            AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN result = ItirazGetir(MyFoy);

            AV001_TI_BIL_ALACAK_NEDEN_TARAF nedenTaraf = NedenTarafBul(MyFoy);

            if (GonderilenGelisme.SON_ITIRAZ_TARIHI.HasValue && result != null)
            {
                #region Sort iþlemi diðer yordamdan yapýlýyor

                //result.Sort("ITIRAZ_TARIHI DESC");

                //foreach (AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN itr in result)
                //{
                //if (result.Count < MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count &&
                //    itr.ITIRAZ_TARIHI < GonderilenGelisme.SON_ITIRAZ_TARIHI.Value)
                //{
                //    GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Kýsmen Kesinleþti";
                //    GonderilenGelisme.KESINLESME_TARIHI = MyFoy.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection[t].KESINLESME_TARIHI;
                //    KesinlesmeDurumu = KesinlesmeDurumu.KismenKesinlesti;
                //}
                //else if (!ItirazlarinHepsiGecikmis(MyFoy))
                //{
                //    GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Gecikmiþ Kýsmi";
                //    GonderilenGelisme.KESINLESME_TARIHI = MyFoy.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection[t].KESINLESME_TARIHI;
                //    KesinlesmeDurumu = KesinlesmeDurumu.GecikmisKýsmi;
                //}
                //}

                #endregion Sort iþlemi diðer yordamdan yapýlýyor

                if (DateTime.Now.Date < GonderilenGelisme.SON_ITIRAZ_TARIHI.Value)
                {
                    if (nedenTaraf != null)
                    {
                        if (result.ANA_PARA_ITIRAZ_TUTARI + result.FAIZE_ITIRAZ_TUTARI < nedenTaraf.ALACAK_TOPLAMI)
                        {
                            //GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Kýsmen Kesinleþti";
                            GonderilenGelisme.ITIRAZ_TARIHI_DURUMU = "Kýsmi Ýtiraz";
                        }
                        else
                        {
                            //GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Kesinleþti";
                            GonderilenGelisme.ITIRAZ_TARIHI_DURUMU = "Tümüne Ýtiraz";
                        }

                        nedenTaraf.KESINLESME_TARIHI = GonderilenGelisme.SON_ITIRAZ_TARIHI;
                        GonderilenGelisme.KESINLESME_TARIHI = nedenTaraf.KESINLESME_TARIHI;
                    }
                    if (KesinlesmeDurumu != null)
                        KesinlesmeDurumu = KesinlesmeDurumu.KismenKesinlesti;
                }
                else
                {
                    if (nedenTaraf != null)
                    {
                        TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> itirazlar =
                  DataRepository.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENProvider.GetByICRA_FOY_ID(result.ICRA_FOY_ID).FindAll(n => n.ITIRAZ_EDEN_TARAF_ID == result.ITIRAZ_EDEN_TARAF_ID && !n.ITIRAZDAN_VAZGECME_TARIHI.HasValue);

                        decimal islemeKonanTutar = 0;

                        TList<AV001_TI_BIL_ALACAK_NEDEN> alacakNedenleri = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByICRA_FOY_ID(result.ICRA_FOY_ID);

                        if (alacakNedenleri != null)
                            foreach (var alacakNeden in alacakNedenleri)
                            {
                                islemeKonanTutar += alacakNeden.ISLEME_KONAN_TUTAR;
                            }

                        List<AV001_TI_BIL_FAIZ> faiz = null;

                        decimal toplamFaiz = 0;
                        decimal anaPara = 0;
                        decimal faizeItiraz = 0;

                        if (itirazlar != null)
                            foreach (var itiraz in itirazlar)
                            {
                                faiz = DataRepository.AV001_TI_BIL_FAIZProvider.GetByICRA_ALACAK_NEDEN_ID(itiraz.ALACAK_NEDEN_ID).Where(vi => vi.FAIZ_TAKIPDEN_ONCE_MI == 1).ToList();

                                if (faiz != null)
                                {
                                    foreach (var item in faiz)
                                    {
                                        toplamFaiz += item.FAIZ_TUTARI;
                                    }
                                }

                                if (itiraz.ANA_PARA_ITIRAZ_TUTARI.HasValue)
                                    anaPara += (decimal)itiraz.ANA_PARA_ITIRAZ_TUTARI;

                                if (itiraz.FAIZE_ITIRAZ_TUTARI.HasValue)
                                    faizeItiraz += (decimal)itiraz.FAIZE_ITIRAZ_TUTARI;
                            }

                        if (itirazlar.Count > 0 && (anaPara + faizeItiraz < islemeKonanTutar + toplamFaiz))
                        {
                            GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Kýsmen Kesinleþti";
                            GonderilenGelisme.ITIRAZ_TARIHI_DURUMU = "Kýsmi Ýtiraz";
                        }
                        else if (itirazlar.Count == 0)
                        {
                            GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Kesinleþti";
                            GonderilenGelisme.ITIRAZ_TARIHI_DURUMU = "Ýtirazdan Vazgeçildi";
                        }
                        else if (GonderilenGelisme.ITIRAZ_TARIHI.Value > GonderilenGelisme.SON_ITIRAZ_TARIHI.Value && !GecikmisItirazMi(result))
                        {
                            GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Kesinleþti";
                            GonderilenGelisme.ITIRAZ_TARIHI_DURUMU = "Geçersiz Ýtiraz";
                        }

                        nedenTaraf.KESINLESME_TARIHI = GonderilenGelisme.SON_ITIRAZ_TARIHI;
                        GonderilenGelisme.KESINLESME_TARIHI = nedenTaraf.KESINLESME_TARIHI;
                            KesinlesmeDurumu = KesinlesmeDurumu.KismenKesinlesti;
                    }
                    else
                    {
                        GonderilenGelisme.KESINLESME_TARIHI = GonderilenGelisme.SON_ITIRAZ_TARIHI;
                        GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Kýsmen Kesinleþti";
                        GonderilenGelisme.ITIRAZ_TARIHI_DURUMU = "Kýsmi Ýtiraz";
                    }
                }

                if (muhatap != null)
                {
                    if (muhatap.TEBLIG_TARIH != null)
                    {
                        if (GonderilenGelisme.SON_ITIRAZ_TARIHI.HasValue &&
                            GonderilenGelisme.SON_ITIRAZ_TARIHI <= muhatap.TEBLIG_TARIH.Value)
                        {
                            GonderilenGelisme.KESINLESME_TARIHI = GonderilenGelisme.SON_ITIRAZ_TARIHI.Value.AddDays(1);
                            GonderilenGelisme.KESINLESME_TARIHI =
                                HSonuOnemliGunKontrol(GonderilenGelisme.SON_ITIRAZ_TARIHI.Value);

                            nedenTaraf.KESINLESME_TARIHI = GonderilenGelisme.KESINLESME_TARIHI;

                            GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Kesinleþti";
                            KesinlesmeDurumu = KesinlesmeDurumu.TakipKesinlesti;
                        }
                    }
                }

                if (GecikmisItirazMi(result))
                {
                    GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Gecikmiþ Kýsmi";
                    if (nedenTaraf != null)
                    {
                        nedenTaraf.KESINLESME_TARIHI = result.ITIRAZ_TARIHI;
                        GonderilenGelisme.KESINLESME_TARIHI = nedenTaraf.KESINLESME_TARIHI;
                    }
                        KesinlesmeDurumu = KesinlesmeDurumu.GecikmisKýsmi;
                }
            }
            else if (GonderilenGelisme.SON_ITIRAZ_TARIHI.HasValue && muhatap != null && muhatap.TEBLIG_TARIH.HasValue)
            {
                GonderilenGelisme.KESINLESME_TARIHI = SureHesapla(SureTipi.ODEME_SURESI, muhatap.TEBLIG_TARIH.Value, MyFoy);

                if (nedenTaraf != null)
                    nedenTaraf.KESINLESME_TARIHI = GonderilenGelisme.KESINLESME_TARIHI;

                if (GonderilenGelisme.KESINLESME_TARIHI.Value < DateTime.Now)
                    GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Kesinleþti";
                else
                    GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Kesinleþmedi";

                    KesinlesmeDurumu = KesinlesmeDurumu.TakipKesinlesmedi;
            }

            //if ((MyFoy.FORM_TIP_ID == (int)FormTipleri.Form151 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form201) && GonderilenGelisme.ILK_TEBLIGAT_TARIHI > DateTime.Now)
            //{
            //    GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Kesinleþti";
            //}
            if (GonderilenGelisme.ILK_TEBLIGAT_TARIHI.HasValue)
            {
                if ((MyFoy.FORM_TIP_ID == (int)FormTipleri.Form50 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form152) && GonderilenGelisme.ILK_TEBLIGAT_TARIHI > DateTime.Now && !GonderilenGelisme.ITIRAZ_TARIHI.HasValue)
                {
                    GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Kesinleþti";
                }
                if (MyFoy.FORM_TIP_IDSource.ILAMLI_MI && !GonderilenGelisme.MEHIL_TARIHI.HasValue)
                {
                    if (SureHesapla(SureTipi.MEHÝL_SÜRESÝ, GonderilenGelisme.ILK_TEBLIGAT_TARIHI.Value, MyFoy) < DateTime.Now.Date)
                        GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Kesinleþti";
                    else
                        GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Mehil Öncesi";
                }
                else if (MyFoy.FORM_TIP_IDSource.ILAMLI_MI && GonderilenGelisme.MEHIL_TARIHI.HasValue)
                {
                    TList<AV001_TI_BIL_MEHIL> mehiller = TarafMehilGetir(MyFoy);
                    if (mehiller.Count > 0)
                    {
                        DateTime kesinlesmeTarihi = GonderilenGelisme.ILK_TEBLIGAT_TARIHI.Value;
                        int eklenecekGun = 0;
                        int eklenecekAy = 0;

                        eklenecekGun += (int)mehiller[0].YARGITAY_MEHIL_MUDDETI_GUN;
                        eklenecekAy += (int)mehiller[0].YARGITAY_MEHIL_MUDDETI_AY;

                        if (mehiller[0].MEHIL_DEVAM_TARIHI.HasValue)
                        {
                            if (mehiller[0].MEHIL_DEVAM_GUN.HasValue)
                                eklenecekGun += (int)mehiller[0].MEHIL_DEVAM_GUN;
                            if (mehiller[0].MEHIL_DEVAM_AY.HasValue)
                                eklenecekAy += (int)mehiller[0].MEHIL_DEVAM_AY;
                        }

                        kesinlesmeTarihi = kesinlesmeTarihi.AddDays(eklenecekGun).AddMonths(eklenecekAy);
                        kesinlesmeTarihi = HSonuOnemliGunKontrol(kesinlesmeTarihi).Value;

                        if (kesinlesmeTarihi < DateTime.Now.Date)
                            GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Kesinleþti";
                        else
                            GonderilenGelisme.KESINLESME_TARIHI_DURUMU = "Mehil Öncesi";
                    }
                }
            }

            return GonderilenGelisme.KESINLESME_TARIHI;
        }

        public static AV001_TI_BIL_MAL_BEYANI MalBeyaniBul(AV001_TI_BIL_FOY MyFoy)
        {
            int tarafIndex = TarafIndexBul(MyFoy);
            if (tarafIndex == -1)
                return null;
            var result = DataRepository.AV001_TI_BIL_MAL_BEYANIProvider.Find(String.Format("ICRA_FOY_ID = {0} AND ICRA_TARAF_ID = {1} AND SONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI = {3}", MyFoy.ID, MyFoy.AV001_TI_BIL_FOY_TARAFCollection[tarafIndex].CARI_ID, 0, MyFoy.AV001_TI_BIL_FOY_TARAFCollection[tarafIndex].TAKIP_EDEN_MI));

            //kenan büyük
            if (result.Count > 0)
            {
                result.Sort("MAL_BEYAN_TARIHI DESC");
                return result[0];
            }
            return null;
        }

        public static DateTime? MalBeyaniDavasýTarihiHesapla(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy)
        {
            GonderilenGelisme.MAL_BEYANI_DAVA_TARIHI = null;
            GonderilenGelisme.MAL_BEYANI_DAVA_TARIHI_DURUMU = string.Empty;
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.MAL_BEYANINDA_BULUNMAMA);
            TList<AV001_TD_BIL_FOY> result = IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count > 0)
            {
                result.Sort("DAVA_TARIHI DESC");

                GonderilenGelisme.MAL_BEYANI_DAVA_TARIHI = result[0].DAVA_TARIHI;

                //GonderilenGelisme.MAL_BEYANI_DAVA_TARIHI_DURUMU = "M.beyaný davasý var";
                string durum = DataRepository.per_TDI_KOD_FOY_DURUMProvider.Get("ID=" + result[0].FOY_DURUM_ID, "ID").FirstOrDefault().DURUM;
                GonderilenGelisme.MAL_BEYANI_DAVA_TARIHI_DURUMU = durum;
            }

            return GonderilenGelisme.MAL_BEYANI_DAVA_TARIHI;
        }

        public static DateTime? MalBeyaniTarihiHesapla(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy)
        {
            if (MyFoy.FORM_TIP_ID == (int)FormTipleri.Form50 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form55 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form56 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form151 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form152 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form201)
            {
                return null;
            }
            AV001_TI_BIL_MAL_BEYANI result = ucIcraTarafGelismeleri.MalBeyaniBul(MyFoy);

            AV001_TDI_BIL_TEBLIGAT_MUHATAP Muhatap = null;

            if (!MyFoy.FORM_TIP_IDSource.ILAMLI_MI)
                Muhatap = MuhatapBul(TebligatBul(MyFoy, 4, 11, false));
            else
            {
                if (MyFoy.FORM_TIP_ID == (int)FormTipleri.Form56)
                    Muhatap = MuhatapBul(TebligatBul(MyFoy, 4, 86, false));
                else
                    Muhatap = MuhatapBul(TebligatBul(MyFoy, 4, 12, false));
            }

            //AV001_TDI_BIL_TEBLIGAT_MUHATAP Muhatap = MuhatapBul(TebligatBul(MyFoy, 4, 11, false));
            int t = TarafIndexBul(MyFoy);

            GonderilenGelisme.MAL_BEYANI_TARIHI = null;
            GonderilenGelisme.MAL_BEYANI_TARIHI_DURUMU = string.Empty;

            if (result != null)
            {
                if (!result.MAL_BEYANI_GECERLI_MI)
                {
                    GonderilenGelisme.MAL_BEYANI_TARIHI = result.MAL_BEYAN_TARIHI;
                    GonderilenGelisme.MAL_BEYANI_TARIHI_DURUMU = "Geçersiz Mal Beyaný";
                }

                else
                    GonderilenGelisme.MAL_BEYANI_TARIHI_DURUMU = "Mal Beyaný Var";

                SonMalBeyaniTarihi = result.MAL_BEYAN_TARIHI;
            }

            else if (ItirazDurumu == ItirazDurumu.ItirazYok ||
                     KesinlesmeDurumu == KesinlesmeDurumu.TakipKesinlesti
                     || ItirazDurumu == ItirazDurumu.KýsmiItirazVar)
            {
                //Bu durumda mal beyani tarihi hesaplanacak
                if (Muhatap != null)
                    if (Muhatap.TEBLIG_TARIH.HasValue)
                        SonMalBeyaniTarihi = SureHesapla(SureTipi.MAL_BEYANI, Muhatap.TEBLIG_TARIH.Value, MyFoy);
                if (SonMalBeyaniTarihi.HasValue && GonderilenGelisme.ILK_TEBLIGAT_TARIHI.HasValue)
                {
                    if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count > 0)
                    {
                        MyFoy.AV001_TI_BIL_FOY_TARAFCollection[t].SON_MAL_BEYANINDA_BULUNMA_TARIHI =
                                        SonMalBeyaniTarihi.Value;
                    }

                    GonderilenGelisme.MAL_BEYANI_TARIHI_DURUMU = "S.M.B.T-" +
                                                                 SonMalBeyaniTarihi.Value.ToShortDateString();
                }
            }

                //En az bir tanesine bile itiraz edilmemiþse ayný tarihi yaz.
            else if (ItirazDurumu == ItirazDurumu.ÝtirazVar &&
                     MyFoy.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection.Count ==
                     MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count)
            {
                MyFoy.AV001_TI_BIL_FOY_TARAFCollection[t].SON_MAL_BEYANINDA_BULUNMA_TARIHI = null;

                GonderilenGelisme.MAL_BEYANI_TARIHI = null;

                GonderilenGelisme.MAL_BEYANI_TARIHI_DURUMU = string.Empty;
            }

            else if (ItirazDurumu == ItirazDurumu.Reddedildi)
            {
                if (GonderilenGelisme.SON_ITIRAZ_TARIHI.HasValue)
                {
                    GonderilenGelisme.SON_ITIRAZ_TARIHI.Value.AddDays(3);

                    GonderilenGelisme.SON_ITIRAZ_TARIHI =
                        HSonuOnemliGunKontrol(GonderilenGelisme.SON_ITIRAZ_TARIHI.Value);

                    MyFoy.AV001_TI_BIL_FOY_TARAFCollection[t].SON_MAL_BEYANINDA_BULUNMA_TARIHI = null;

                    GonderilenGelisme.MAL_BEYANI_TARIHI = null;

                    GonderilenGelisme.MAL_BEYANI_TARIHI_DURUMU = "S.M.B.T-" +
                                                                 GonderilenGelisme.SON_ITIRAZ_TARIHI.Value.
                                                                     ToShortTimeString();
                }
            }

            return SonMalBeyaniTarihi;
        }

        public static DateTime? MehilTarihiHesapla(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy)
        {
            TList<AV001_TI_BIL_MEHIL> result = TarafMehilGetir(MyFoy);

            AV001_TDI_BIL_TEBLIGAT_MUHATAP Muhatap = null;

            if (!MyFoy.FORM_TIP_IDSource.ILAMLI_MI)
                Muhatap = MuhatapBul(TebligatBul(MyFoy, 4, 11, false));
            else
            {
                if (MyFoy.FORM_TIP_ID == (int)FormTipleri.Form56)
                    Muhatap = MuhatapBul(TebligatBul(MyFoy, 4, 86, false));
                else
                    Muhatap = MuhatapBul(TebligatBul(MyFoy, 4, 12, false));
            }

            GonderilenGelisme.EK_MEHIL_TARIHI = null;
            GonderilenGelisme.EK_MEHIL_TARIHI_DURUMU = null;
            GonderilenGelisme.MEHIL_TARIHI = null;
            GonderilenGelisme.MEHIL_TARIHI_DURUMU = null;

            if ((result == null || result.Count == 0) && Muhatap != null && MyFoy.FORM_TIP_IDSource.ILAMLI_MI)
            {
                DateTime? mehilT = new DateTime();
                if (Muhatap.TEBLIG_TARIH.HasValue)
                {
                    mehilT = SureHesapla(SureTipi.MEHÝL_SÜRESÝ, Muhatap.TEBLIG_TARIH.Value, MyFoy);
                    GonderilenGelisme.MEHIL_TARIHI_DURUMU = "S.M.T- " + mehilT.Value.ToShortDateString();
                }
            }

            foreach (AV001_TI_BIL_MEHIL mehil in result)
            {
                if (mehil.ICRA_MEHIL_ILAM_TEMYIZ_TARIHI.HasValue)
                {
                    GonderilenGelisme.MEHIL_TARIHI = mehil.ICRA_MEHIL_ILAM_TEMYIZ_TARIHI;
                    GonderilenGelisme.MEHIL_TARIHI_DURUMU = "Mehil Ýstendi";
                }

                if (mehil.YARGITAY_MEHIL_KARAR_TARIHI.HasValue)
                {
                    GonderilenGelisme.MEHIL_TARIHI = mehil.YARGITAY_MEHIL_KARAR_TARIHI;
                    GonderilenGelisme.MEHIL_TARIHI_DURUMU = "Mehil Alýndý";
                }

                if (mehil.MEHIL_DEVAM_TARIHI.HasValue)
                {
                    GonderilenGelisme.EK_MEHIL_TARIHI = mehil.EK_MEHIL_TARIHI;
                    GonderilenGelisme.EK_MEHIL_TARIHI_DURUMU = "Ek Mehil Ýstendi";
                    mehil.EK_MEHIL_VAR_MI = true;
                }
                if (mehil.EK_MEHIL_TARIHI.HasValue)
                {
                    GonderilenGelisme.EK_MEHIL_TARIHI = mehil.EK_MEHIL_TARIHI;
                    GonderilenGelisme.EK_MEHIL_TARIHI_DURUMU = "Ek Mehil Alýndý";
                    mehil.EK_MEHIL_VAR_MI = true;
                }

                else if (mehil.ICRA_MEHIL_ILAM_TEMYIZ_TARIHI.HasValue
                         && mehil.YARGITAY_MEHIL_KARAR_TARIHI.HasValue
                         && mehil.MEHIL_DEVAM_TARIHI.HasValue
                         && mehil.EK_MEHIL_TARIHI.HasValue)
                {
                    GonderilenGelisme.MEHIL_TARIHI = mehil.EK_MEHIL_TARIHI;
                    GonderilenGelisme.MEHIL_TARIHI_DURUMU = "Ek Mehil Alýndý";
                    mehil.EK_MEHIL_VAR_MI = true;
                }
            }

            return GonderilenGelisme.MEHIL_TARIHI;
        }

        public static AV001_TDI_BIL_TEBLIGAT_MUHATAP MuhatapBul(AV001_TDI_BIL_TEBLIGAT tebligat)
        {
            TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> result = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();

            if (tebligat == null)
                return null;
            try
            {
                DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(tebligat, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>));
            }
            catch
            {
            }
            result = tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.FindAll("MUHATAP_CARI_ID", ucIcraTarafBilgileri.CurrBorcluId);

            if (result.Count > 0)
            {
                result.Sort("TEBLIG_TARIH DESC");

                return result[0];
            }
            else if (tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count > 0)
                return tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[0];
            return null;
        }

        public static AV001_TI_BIL_ALACAK_NEDEN_TARAF NedenTarafBul(AV001_TI_BIL_FOY MyFoy)
        {
            TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> result = new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>();

            if (MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count <= 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
            foreach (var item in MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                if (item.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count <= 0)
                    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren,
                                                                              typeof(
                                                                                  TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>
                                                                                  ));
                result.AddRange(
                    item.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.FindAll(
                        taraf => taraf.TARAF_CARI_ID == ucIcraTarafBilgileri.CurrBorcluId).ToArray());
            }

            if (result.Count > 0)
            {
                result.Sort("KAYIT_TARIHI DESC");
                return result[0];
            }

            return null;
        }

        public static int NedenTarafIndexBul(AV001_TI_BIL_ALACAK_NEDEN AlacakNeden)
        {
            for (int i = 0; i < AlacakNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count; i++)
            {
                if (AlacakNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count > 0)
                {
                    if (AlacakNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection[i].TARAF_CARI_ID ==
                        ucIcraTarafBilgileri.CurrBorcluId)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public static void NedenTarafUzerindekileriHesapla(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy)
        {
            AV001_TI_BIL_ALACAK_NEDEN_TARAF result = NedenTarafBul(MyFoy);

            GonderilenGelisme.IHTAR_TARIHI_DURUMU = string.Empty;
            GonderilenGelisme.IHTAR_TARIHI = null;
            GonderilenGelisme.IHTAR_TEBLIG_TARIHI_DURUMU = string.Empty;
            GonderilenGelisme.IHTAR_TEBLIG_TARIHI = null;
            GonderilenGelisme.ZAMAN_ASIMI_TARIHI_DURUMU = string.Empty;
            GonderilenGelisme.ZAMAN_ASIMI_TARIHI = null;
            GonderilenGelisme.TEMERRUT_TARIHI_DURUMU = string.Empty;
            GonderilenGelisme.TEMERRUT_TARIHI = null;

            if (result != null)
            {
                if (result.IHTAR_TARIHI.HasValue)
                {
                    GonderilenGelisme.IHTAR_TARIHI = result.IHTAR_TARIHI;
                    GonderilenGelisme.IHTAR_TARIHI_DURUMU = "Gönderildi";
                }
                if (result.ZAMAN_ASIMI_TARIHI.HasValue)
                {
                    GonderilenGelisme.ZAMAN_ASIMI_TARIHI = result.ZAMAN_ASIMI_TARIHI;
                    GonderilenGelisme.ZAMAN_ASIMI_TARIHI_DURUMU = "Zaman Aþýmý";
                }
                if (result.IHTAR_TEBLIG_TARIHI.HasValue)
                {
                    GonderilenGelisme.IHTAR_TEBLIG_TARIHI = result.IHTAR_TEBLIG_TARIHI;
                    GonderilenGelisme.IHTAR_TEBLIG_TARIHI_DURUMU = "Teblið Edildi";
                }
                if (result.TEMERRUT_TARIHI.HasValue)
                {
                    GonderilenGelisme.TEMERRUT_TARIHI = result.TEMERRUT_TARIHI;
                    GonderilenGelisme.TEMERRUT_TARIHI_DURUMU = "Temerrüt";
                }
            }
        }

        public static DateTime? OdemeTarihiHesapla(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy)
        {
            if (GonderilenGelisme == null) return null;

            GonderilenGelisme.SON_ODEME_TARIHI = null;
            GonderilenGelisme.SON_ODEME_TARIHI_DURUMU = string.Empty;

            AV001_TI_BIL_BORCLU_ODEME result = TarafOdemeleriniGetir(MyFoy);

            //AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatap = MuhatapBul(TebligatBul(MyFoy, 4, 11, false));
            AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatap = null;

            if (MyFoy.FORM_TIP_ID == (int)FormTipleri.Form49 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form50 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form163 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form152 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form51 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form52 || MyFoy.FORM_TIP_ID == (int)FormTipleri.Form153)
                muhatap = MuhatapBul(TebligatBul(MyFoy, 4, 11, false));
            else
            {
                if (MyFoy.FORM_TIP_ID == (int)FormTipleri.Form56)
                    muhatap = MuhatapBul(TebligatBul(MyFoy, 4, 86, false));
                else
                    muhatap = MuhatapBul(TebligatBul(MyFoy, 4, 12, false));
            }
            int t = TarafIndexBul(MyFoy);

            if (result == null && muhatap != null && muhatap.TEBLIG_TARIH.HasValue)
            {
                TList<TI_BIL_YASAL_SURE> sureList =
                    DataRepository.TI_BIL_YASAL_SUREProvider.GetByFORM_TIP_ID(MyFoy.FORM_TIP_ID.Value);
                foreach (TI_BIL_YASAL_SURE s in sureList)
                {
                    if (s.SURE_TIP_ID == 4 && s.TAKIP_TALEP_ID == MyFoy.TAKIP_TALEP_ID.Value)
                    {
                        //GonderilenGelisme.SON_ODEME_TARIHI = muhatap.TEBLIG_TARIH.Value.AddDays(s.SURE_GUN);
                        SonOdemeTarihi = muhatap.TEBLIG_TARIH.Value.AddDays(s.SURE_GUN);

                        //Son tarih haftasonuna denk geliyorsa son ödeme tarihini 1 gün ileri at.
                        //Son tarih önemli günlere denk geliyorsa son ödeme tarihini 1 gün ileri at
                        foreach (
                            TDI_BIL_ONEMLI_GUN g in DataRepository.TDI_BIL_ONEMLI_GUNProvider.GetByTARIH_KATEGORI_ID(3))
                        {
                            if (SonOdemeTarihi.Value.DayOfWeek == DayOfWeek.Saturday ||
                                SonOdemeTarihi.Value.DayOfWeek == DayOfWeek.Sunday)

                                SonOdemeTarihi = SonOdemeTarihi.Value.AddDays(1);

                            if (g.BASLAMA_TARIHI == SonOdemeTarihi.Value)
                                SonOdemeTarihi = SonOdemeTarihi.Value.AddDays(1);
                        }
                        MyFoy.AV001_TI_BIL_FOY_TARAFCollection[t].SON_ODEME_TARIHI = SonOdemeTarihi;
                        GonderilenGelisme.SON_ODEME_TARIHI_DURUMU = "S.Ö.T=" + SonOdemeTarihi.Value.ToShortDateString();
                    }
                }
            }
            else if (result != null)
            {
                //Bu durumda tarafýn son ödeme tarihi ve ödenen miktar yazýlmalýdýr.
                TDI_KOD_DOVIZ_TIP dov = BelgeUtil.Inits.DovizIdSource(result.ODEME_MIKTAR_DOVIZ_ID.Value);
                GonderilenGelisme.SON_ODEME_TARIHI = result.ODEME_TARIHI;
                GonderilenGelisme.SON_ODEME_TARIHI_DURUMU = string.Format("{0:N2}", result.ODEME_MIKTAR) + dov.DOVIZ_KODU.ToUpper();
            }

            return GonderilenGelisme.SON_ODEME_TARIHI;
        }

        public static TList<AV001_TI_BIL_SATIS_CHILD> SatisChildGetir(AV001_TI_BIL_FOY MyFoy)
        {
            TList<AV001_TI_BIL_SATIS_CHILD> result = new TList<AV001_TI_BIL_SATIS_CHILD>();
            TList<AV001_TI_BIL_SATIS_MASTER> masterList = SatislariGetir(MyFoy);
            DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.DeepLoad(masterList, false, DeepLoadType.IncludeChildren,
                                                                      typeof(TList<AV001_TI_BIL_SATIS_CHILD>));
            masterList.ForEach(
                delegate(AV001_TI_BIL_SATIS_MASTER m) { result.AddRange(m.AV001_TI_BIL_SATIS_CHILDCollection); });

            return result;
        }

        public static TList<AV001_TI_BIL_SATIS_MASTER> SatislariGetir(AV001_TI_BIL_FOY MyFoy)
        {
            if (MyFoy.AV001_TI_BIL_SATIS_MASTERCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_SATIS_MASTER>));

            return MyFoy.AV001_TI_BIL_SATIS_MASTERCollection.FindAll(
                delegate(AV001_TI_BIL_SATIS_MASTER satis) { return (satis.SATISI_ISTENEN_CARI_ID == ucIcraTarafBilgileri.CurrBorcluId); });
        }

        public static void SonGelismeyiHesapla(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme)
        {
            //Dictionary<string, int> sonGelisme = new Dictionary<string, int>();
            List<Gelisme> gelismeList = new List<Gelisme>();

            //if (GonderilenGelisme.IHTAR_TARIHI.HasValue)
            //    sonGelisme.Add("", GonderilenGelisme.IHTAR_TARIHI.Value);
            //if (GonderilenGelisme.IHTAR_TEBLIG_TARIHI.HasValue)
            //    sonGelisme.Add("", GonderilenGelisme.IHTAR_TEBLIG_TARIHI.Value);
            if (GonderilenGelisme.ILK_TEBLIGAT_TARIHI_DURUMU == "Bekleniyor.")
                gelismeList.Add(new Gelisme("01 Tebligat Sonucu Beklenenler", 01, DateTime.Now.Date));
            if (GonderilenGelisme.IHTIYATI_HACIZ_TALEP_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("02 Ýhtiyati Haciz Ýstenenler", 02, GonderilenGelisme.IHTIYATI_HACIZ_TALEP_TARIHI.Value));
            if (GonderilenGelisme.IHTIYATI_HACIZ_UYGULAMA_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("03 Ýhtiyati Haciz Uygulananlar", 03, GonderilenGelisme.IHTIYATI_HACIZ_UYGULAMA_TARIHI.Value));
            if (GonderilenGelisme.ESAS_TAKIP_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("04 Takibe Konulanlar", 04, GonderilenGelisme.ESAS_TAKIP_TARIHI.Value));
            if (GonderilenGelisme.IHTIYATI_TEDBIR_TALEP_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("05 Ýhtiyati Tedbir Ýstenenler", 05, GonderilenGelisme.IHTIYATI_TEDBIR_TALEP_TARIHI.Value));
            if (GonderilenGelisme.IHTIYATI_TEDBIR_UYGULAMA_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("06 Ýhtiyati Tedbir Uygulananlar", 06, GonderilenGelisme.IHTIYATI_TEDBIR_UYGULAMA_TARIHI.Value));
            if (GonderilenGelisme.BILA_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("07 Tebligatý Bila Dönenler", 07, GonderilenGelisme.BILA_TARIHI.Value));
            if (GonderilenGelisme.ZABITA_ARASTIRMA_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("08 Zabýta Araþtýrmasý Ýstenenler", 08, GonderilenGelisme.ZABITA_ARASTIRMA_TARIHI.Value));
            if (GonderilenGelisme.ZABITA_ARASTIRMA_OLUMSUZ_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("09 Zabýta Araþtýrmasý Olumsuz Gelenler", 09, GonderilenGelisme.ZABITA_ARASTIRMA_OLUMSUZ_TARIHI.Value));
            if (GonderilenGelisme.ZABITACA_YENI_ADRES_BULUNDUGU_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("10 Yeni Adresi Tespit Edilenler", 10, GonderilenGelisme.ZABITACA_YENI_ADRES_BULUNDUGU_TARIHI.Value));
            if (GonderilenGelisme.SUBEDEN_YENI_ADRES_ISTEME_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("11 Þubeden Adres Ýstenenler", 11, GonderilenGelisme.SUBEDEN_YENI_ADRES_ISTEME_TARIHI.Value));
            if (GonderilenGelisme.SUBEDEN_OLUMSUZ_CEVAP_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("12 Þubeden Adres Cevabý Olumsuz Gelenler", 12, GonderilenGelisme.SUBEDEN_OLUMSUZ_CEVAP_TARIHI.Value));
            if (GonderilenGelisme.SUBEDEN_YENI_ADRES_BILDIRILDIGI_TARIH.HasValue)
                gelismeList.Add(new Gelisme("13 Yeni Adresi Tespit Edilenler", 13, GonderilenGelisme.SUBEDEN_YENI_ADRES_BILDIRILDIGI_TARIH.Value));
            if (GonderilenGelisme.ILK_TEBLIGAT_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("14 Tebligat Yapýlanlar", 14, GonderilenGelisme.ILK_TEBLIGAT_TARIHI.Value));
            if (GonderilenGelisme.MEHIL_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("15 Mehil Ýsteyenler", 15, GonderilenGelisme.MEHIL_TARIHI.Value));
            if (GonderilenGelisme.EK_MEHIL_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("16 Ek Mehil Ýsteyenler", 16, GonderilenGelisme.EK_MEHIL_TARIHI.Value));
            if (GonderilenGelisme.ITIRAZ_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("17 Ýtiraz Edenler", 17, GonderilenGelisme.ITIRAZ_TARIHI.Value));
            if (GonderilenGelisme.ITIRAZIN_KALDIRILMASI_DAVA_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("18 Kýsmen Ýtiraz Edenler", 18, GonderilenGelisme.ITIRAZIN_KALDIRILMASI_DAVA_TARIHI.Value));
            if (GonderilenGelisme.ITIRAZ_KALDIRILMA_IHTAR_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("19 Ýtirazýn Giderilmesi Davasý Açýlanlar", 19, GonderilenGelisme.ITIRAZ_KALDIRILMA_IHTAR_TARIHI.Value));
            if (GonderilenGelisme.ITIRAZDAN_VAZGECME_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("20 Ýtirazý Kýsmen Kaldýrýlanlar", 20, GonderilenGelisme.ITIRAZDAN_VAZGECME_TARIHI.Value));
            if (GonderilenGelisme.KESINLESME_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("21 Kesinleþenler", 21, GonderilenGelisme.KESINLESME_TARIHI.Value));
            if (GonderilenGelisme.SON_HACIZ_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("22 Haciz Yapýlanlar", 22, GonderilenGelisme.SON_HACIZ_TARIHI.Value));
            if (GonderilenGelisme.YUZUC_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("23 103 Tebligatý Yapýlanlar", 23, GonderilenGelisme.YUZUC_TARIHI.Value));
            if (GonderilenGelisme.SATIS_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("24 Satýþ Ýsteneler", 24, GonderilenGelisme.SATIS_TARIHI.Value));
            if (GonderilenGelisme.GECICI_REHIN_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("25 Geçici Rehin Açýðý Belgesi Alýnalar", 25, GonderilenGelisme.GECICI_REHIN_TARIHI.Value));
            if (GonderilenGelisme.KESIN_REHIN_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("26 Kesin Rehin Açýðý Belgesi Alýnalar", 26, GonderilenGelisme.KESIN_REHIN_TARIHI.Value));
            if (GonderilenGelisme.IBRA_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("27 Ýbra Edilenler", 27, GonderilenGelisme.IBRA_TARIHI.Value));
            if (GonderilenGelisme.ACIZ_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("28 Aciz Belgesi Alýnanlar", 28, GonderilenGelisme.ACIZ_TARIHI.Value));
            if (GonderilenGelisme.ZAMAN_ASIMI_TARIHI.HasValue)
                gelismeList.Add(new Gelisme("29 Zamanaþýmýndan Borcu Düþenler", 29, GonderilenGelisme.ZAMAN_ASIMI_TARIHI.Value));

            //if (GonderilenGelisme.ESAS_TAKIP_TARIHI.HasValue)
            //    sonGelisme.Add("", GonderilenGelisme.ESAS_TAKIP_TARIHI.Value);
            //if (GonderilenGelisme.K_TAKDIRI_IPT_DAVASI_TARIHI.HasValue)
            //    sonGelisme.Add("", GonderilenGelisme.K_TAKDIRI_IPT_DAVASI_TARIHI.Value);
            //if (GonderilenGelisme.KARSILIKSIZ_CEK_DAVASI_TARIHI.HasValue)
            //    sonGelisme.Add("", GonderilenGelisme.KARSILIKSIZ_CEK_DAVASI_TARIHI.Value);
            //if (GonderilenGelisme.KIYMET_TAKDIRI_TARIHI.HasValue)
            //    sonGelisme.Add("", GonderilenGelisme.KIYMET_TAKDIRI_TARIHI.Value);
            //if (GonderilenGelisme.MAL_BEYANI_DAVA_TARIHI.HasValue)
            //    sonGelisme.Add("", GonderilenGelisme.MAL_BEYANI_DAVA_TARIHI.Value);
            //if (GonderilenGelisme.MAL_BEYANI_TARIHI.HasValue)
            //    sonGelisme.Add("", GonderilenGelisme.MAL_BEYANI_TARIHI.Value);
            //if (GonderilenGelisme.SATISIN_FESHI_DAVASI_TARIHI.HasValue)
            //    sonGelisme.Add("", GonderilenGelisme.SATISIN_FESHI_DAVASI_TARIHI.Value);
            //if (GonderilenGelisme.SATISIN_IPTALI_TARIHI.HasValue)
            //    sonGelisme.Add("", GonderilenGelisme.SATISIN_IPTALI_TARIHI.Value);
            //if (GonderilenGelisme.SON_ITIRAZ_TARIHI.HasValue)
            //    sonGelisme.Add("Ýtiraz Edenler", GonderilenGelisme.SON_ITIRAZ_TARIHI.Value);
            //if (GonderilenGelisme.SON_ODEME_TARIHI.HasValue)
            //    sonGelisme.Add("", GonderilenGelisme.SON_ODEME_TARIHI.Value);
            //if (GonderilenGelisme.TAAHHUT_TARIHI.HasValue)
            //    sonGelisme.Add("", GonderilenGelisme.TAAHHUT_TARIHI.Value);
            //if (GonderilenGelisme.TAAHHUTU_IHLAL_DAVA_TARIHI.HasValue)
            //    sonGelisme.Add("", GonderilenGelisme.TAAHHUTU_IHLAL_DAVA_TARIHI.Value);
            //if (GonderilenGelisme.TAHLIYE_DAVASI_TARIHI.HasValue)
            //    sonGelisme.Add("", GonderilenGelisme.TAHLIYE_DAVASI_TARIHI.Value);
            //if (GonderilenGelisme.TEMERRUT_TARIHI.HasValue)
            //    sonGelisme.Add("", GonderilenGelisme.TEMERRUT_TARIHI.Value);
            //if (GonderilenGelisme.TESLIM_TAHLIYE_TARIHI.HasValue)
            //    sonGelisme.Add("", GonderilenGelisme.TESLIM_TAHLIYE_TARIHI.Value);

            var sortedSonGelisme = (from entry in gelismeList orderby entry.Durum descending select entry);

            if (sortedSonGelisme.Count() > 0)
            {
                GonderilenGelisme.SON_GELISME_TARIHI = sortedSonGelisme.FirstOrDefault().Tarih;
                GonderilenGelisme.SON_GELISME_TARIHI_DURUMU = sortedSonGelisme.FirstOrDefault().Durum;
            }
        }

        public static AV001_TI_BIL_HACIZ_MASTER SonHacizKaydýnýGetir(AV001_TI_BIL_FOY MyFoy)
        {
            TList<AV001_TI_BIL_HACIZ_MASTER> result = new TList<AV001_TI_BIL_HACIZ_MASTER>();

            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_HACIZ_MASTER>), typeof(TList<AV001_TI_BIL_HACIZ_CHILD>));

            result = MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.FindAll(
                delegate(AV001_TI_BIL_HACIZ_MASTER haciz) { return (haciz.HACIZ_ISTENEN_CARI_ID == ucIcraTarafBilgileri.CurrBorcluId); });

            if (result.Count > 0)
            {
                result.Sort("HACIZ_TARIHI DESC");

                return result[0];
            }

            return null;
        }

        public static DateTime? SonSatisTarihiHesapla(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy)
        {
            TList<AV001_TI_BIL_SATIS_CHILD> childList = SatisChildGetir(MyFoy);
            TList<AV001_TI_BIL_SATIS_MASTER> masterList = SatislariGetir(MyFoy);

            if (GonderilenGelisme == null || childList == null || masterList == null) return null;

            GonderilenGelisme.SATIS_TARIHI = null;
            GonderilenGelisme.SATIS_TARIHI_DURUMU = string.Empty;
            TList<AV001_TI_BIL_SATIS_CHILD> hesaplanacakSatislar = new TList<AV001_TI_BIL_SATIS_CHILD>();
            TList<AV001_TI_BIL_HACIZ_CHILD> hacizChld = new TList<AV001_TI_BIL_HACIZ_CHILD>();

            if (masterList.Count > 0)
            {
                masterList.Sort("SATIS_TARIHI_1 DESC");
                GonderilenGelisme.SATIS_TARIHI = masterList[0].SATIS_TARIHI_1;
                GonderilenGelisme.SATIS_TARIHI_DURUMU = "Satýþ Yapýldý.";
            }

            if (childList.Count > 0)
            {
                foreach (AV001_TI_BIL_SATIS_CHILD sChild in childList)
                {
                    if (sChild.MASTER_IDSource != null)
                    {
                        //DataRepository.AV001_TI_BIL_SATIS_CHILDProvider
                        //satis tarihi 1-2 var ise ve satis kesinlesme tarihide varsa bu satis kayitlarini geciyoruz.
                        //kesinlesme tarihi olmayýp satis tarihi olanlarda iþlem yap.

                        if (!sChild.MASTER_IDSource.SATIS_KESINLESME_TARIHI.HasValue &&
                            sChild.MASTER_IDSource.SATIS_TARIHI_1.HasValue ||
                            sChild.MASTER_IDSource.SATIS_TARIHI_2.HasValue)
                        {
                            //1.satis tarihine bak bu tarih günün tarihinden küçükse hesaplanacak satislara ekle.
                            if (sChild.MASTER_IDSource.SATIS_TARIHI_1 < DateTime.Now)
                            {
                                hesaplanacakSatislar.Add(sChild);
                            }
                        }
                    }
                }
                if (hesaplanacakSatislar.Count > 0)
                {
                    foreach (AV001_TI_BIL_SATIS_CHILD hesaplanacak in hesaplanacakSatislar)
                    {
                        if (hesaplanacak.HACIZ_CHILD_IDSource != null &&
                            hesaplanacak.HACIZ_CHILD_IDSource.MASTER_IDSource != null)
                        {
                            hacizChld.Add(hesaplanacak.HACIZ_CHILD_IDSource);
                        }
                    }
                }

                if (hacizChld.Count > 0)
                {
                    foreach (AV001_TI_BIL_HACIZ_CHILD hChild in hacizChld)
                    {
                        TI_KOD_MAL_KATEGORI malKat =
                            DataRepository.TI_KOD_MAL_KATEGORIProvider.GetByID(hChild.HACIZLI_MAL_KATEGORI_ID);

                        if (malKat.ID == (int)MalKategori.GAYRIMENKUL) //Gayrimenkullerde 2 yýl hesaplanýyor.
                        {
                            GonderilenGelisme.SATIS_TARIHI = hChild.MASTER_IDSource.HACIZ_TARIHI.AddYears(2);

                            GonderilenGelisme.SATIS_TARIHI = HSonuOnemliGunKontrol(GonderilenGelisme.SATIS_TARIHI.Value);
                        }
                        else if (malKat.ID == (int)MalKategori.MENKUL) // Menkullerde 1 yýl hesaplanýyor.
                        {
                            GonderilenGelisme.SATIS_TARIHI = hChild.MASTER_IDSource.HACIZ_TARIHI.AddYears(1);

                            GonderilenGelisme.SATIS_TARIHI = HSonuOnemliGunKontrol(GonderilenGelisme.SATIS_TARIHI.Value);
                        }
                    }
                }
            }

            return GonderilenGelisme.SATIS_TARIHI;
        }

        public static DateTime? SureHesapla(AvukatProLib.Extras.SureTipi SureTipiId, DateTime TebligTarihi, AV001_TI_BIL_FOY Foy)
        {
            List<AvukatProLib.Arama.per_TI_BIL_YASAL_SURE> sureler = BelgeUtil.Inits.YasalSureGetir().FindAll(s => s.FORM_TIP_ID == Foy.FORM_TIP_ID.Value && s.TAKIP_TALEP_ID == Foy.TAKIP_TALEP_ID.Value && s.SURE_TIP_ID == (int)SureTipiId);

            if (sureler.Count > 0)
            {
                sureler = sureler.OrderByDescending(item => item.KAYIT_TARIHI).ToList();

                //Teblig Tarihine bulunan güne ekle
                TebligTarihi = TebligTarihi.AddDays(sureler[0].SURE_GUN);

                //Önemli Gün Kontrolü Yap
                TebligTarihi = (DateTime)HSonuOnemliGunKontrol(TebligTarihi);
            }

            return TebligTarihi;
        }

        public static TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER> TaahhutGetir(AV001_TI_BIL_FOY MyFoy)
        {
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>), typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD>));
            return
                MyFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection.FindAll(
                    delegate(AV001_TI_BIL_BORCLU_TAAHHUT_MASTER m) { return (m.TAAHHUT_EDEN_ID == ucIcraTarafBilgileri.CurrBorcluId & m.GECERLI_MI == true); });
        }

        public static void TaahhutHesapla(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy)
        {
            GonderilenGelisme.TAAHHUT_TARIHI = null;
            GonderilenGelisme.TAAHHUT_TARIHI_DURUMU = null;

            TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER> result = TaahhutGetir(MyFoy);

            if (result.Count > 0)
            {
                result.Sort("TAAHHUT_TARIHI DESC");

                if (result[0].TAAHHUT_TARIHI != null)
                {
                    GonderilenGelisme.TAAHHUT_TARIHI = result[0].TAAHHUT_TARIHI;
                    GonderilenGelisme.TAAHHUT_TARIHI_DURUMU = "Taahhüt Verdi";
                }

                if (result[0].TAAHHUDU_KABUL_TARIHI.HasValue)
                {
                    GonderilenGelisme.TAAHHUT_TARIHI = result[0].TAAHHUDU_KABUL_TARIHI;
                    GonderilenGelisme.TAAHHUT_TARIHI_DURUMU = "Kabul Edildi";
                }

                if (result[0].TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.HasValue)
                {
                    GonderilenGelisme.TAAHHUT_TARIHI = result[0].TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI;
                    GonderilenGelisme.TAAHHUT_TARIHI_DURUMU = "Teblið Edildi";
                }

                if (IhlalVarmi(result) && TaahhutuYerineGetirmeTarihi.HasValue)
                {
                    GonderilenGelisme.TAAHHUT_TARIHI = result[0].TAAHHUDU_KABUL_TARIHI;
                    GonderilenGelisme.TAAHHUT_TARIHI_DURUMU = "Ýhlal-" +
                                                              TaahhutuYerineGetirmeTarihi.Value.ToShortDateString();
                }
            }
        }

        public static void TaahhutleriHesapla(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY Foy)
        {
            TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER> taahhutler = TaahhutGetir(Foy);
            if (taahhutler.Count < 1)
                return;
            taahhutler.Sort("TAAHHUT_TARIHI DESC");

            int i = 0;
            if (taahhutler.Count == 1)
                i = 0;
            else
                foreach (var taahhut in taahhutler)
                {
                    if (taahhut.GECERLI_MI == true)
                        break;
                    i++;
                }
            if (i == taahhutler.Count)
                i = 0;

            DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepLoad(taahhutler[i], true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD>));

            taahhutler[i].AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection.Sort("TAAHHUTU_YERINE_GETIRME_TARIHI");


            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

            decimal sonrakiTaahhudeDevreden = 0;

            DateTime masterTarihi = Convert.ToDateTime(taahhutler[i].TAAHHUT_TARIHI.ToShortDateString() + " 23:59:59");
            DateTime? odemeTarihi = null;

            cn.Clear();
            cn.AddParams("@ICRA_FOY_ID", Foy.ID);
            cn.AddParams("@ODEYEN_CARI_ID", BorcluCariID);
            cn.AddParams("@ODEME_TARIHI", masterTarihi);
            decimal odemetoPLAM = (decimal)cn.ExecuteScalar("SELECT isnull(sum(ODEME_MIKTAR),0) FROM dbo.AV001_TI_BIL_BORCLU_ODEME(nolock) WHERE ICRA_FOY_ID=@ICRA_FOY_ID AND ODEYEN_CARI_ID=@ODEYEN_CARI_ID AND ODEME_TARIHI >= @ODEME_TARIHI");
            odemeTarihi = (DateTime)cn.ExecuteScalar("SELECT ISNULL(MAX(DATEADD(dd, 0, DATEDIFF(dd, 0, ODEME_TARIHI))),GETDATE()) AS ODEME_TARIHI FROM dbo.AV001_TI_BIL_BORCLU_ODEME(nolock) WHERE ICRA_FOY_ID=@ICRA_FOY_ID AND ODEYEN_CARI_ID=@ODEYEN_CARI_ID AND ODEME_TARIHI >= @ODEME_TARIHI");

            foreach (var item in taahhutler[i].AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection)
            {
                //if (item.TAAHHUTU_YERINE_GETIRME_TARIHI <= DateTime.Now.Date && odemetoPLAM > 0)
                //{
                    DateTime taahhuttarihi = Convert.ToDateTime(item.TAAHHUTU_YERINE_GETIRME_TARIHI.ToShortDateString() + " 23:59:59");

                    //if (odemetoPLAM > 0)
                    //{
                    //    if (sonrakiTaahhudeDevreden > 0)
                    //    {
                    //        if (odemetoPLAM >= sonrakiTaahhudeDevreden)
                    //            odemetoPLAM = odemetoPLAM - sonrakiTaahhudeDevreden;
                    //        else
                    //            odemetoPLAM = sonrakiTaahhudeDevreden - odemetoPLAM;
                    //    }
                    //}
                    //if (odemetoPLAM == 0)
                    //{
                    //    DataTable dt = cn.GetDataTable("SELECT TOP(1) ODEME_MIKTAR, DATEADD(dd, 0, DATEDIFF(dd, 0, ODEME_TARIHI)) AS ODEME_TARIHI FROM dbo.AV001_TI_BIL_BORCLU_ODEME(nolock) WHERE ICRA_FOY_ID=@ICRA_FOY_ID AND ODEYEN_CARI_ID=@ODEYEN_CARI_ID AND ODEME_TARIHI > @ODEME_TARIHI ORDER BY ODEME_TARIHI");
                    //    if (dt.Rows.Count > 0)
                    //    {
                    //        odemetoPLAM = Convert.ToDecimal(dt.Rows[0][0].ToString());
                    //        odemeTarihi = Convert.ToDateTime(dt.Rows[0][1].ToString());
                    //    }
                    //}

                    if (item.TAAHHUTU_YERINE_GETIRME_TARIHI >= DateTime.Now.Date && odemetoPLAM <= 0)
                    {
                        item.DURUM_ID = (int)TaahhutDurum.IHLAL_YOK;
                        item.TAAHHUTTEN_KALAN_MIKTAR = 0;
                    }
                    else if (item.TAAHHUT_MIKTARI <= odemetoPLAM)
                    {
                        if (odemeTarihi != null && item.TAAHHUTU_YERINE_GETIRME_TARIHI.ToShortDateString() == odemeTarihi.Value.ToShortDateString())
                            item.DURUM_ID = (int)TaahhutDurum.ZAMANINDA_TAM;
                        else if (item.TAAHHUTU_YERINE_GETIRME_TARIHI > odemeTarihi.Value)
                            item.DURUM_ID = (int)TaahhutDurum.ZAMANINDAN_ONCE_TAM;
                        else
                            item.DURUM_ID = (int)TaahhutDurum.ZAMANINDAN_SONRA_TAM;

                        item.ODEME_MIKTARI = item.TAAHHUT_MIKTARI;
                        sonrakiTaahhudeDevreden += (odemetoPLAM - item.TAAHHUT_MIKTARI);
                        odemetoPLAM -= item.ODEME_MIKTARI;
                    }
                    else if (item.TAAHHUT_MIKTARI > odemetoPLAM)
                    {
                        if (odemetoPLAM == 0)
                        {
                            item.DURUM_ID = (int)TaahhutDurum.ZAMANINDA_ODEME_YOK;
                            item.ODEME_MIKTARI = 0;
                        }
                        else if (odemeTarihi != null && item.TAAHHUTU_YERINE_GETIRME_TARIHI.ToShortDateString() == odemeTarihi.Value.ToShortDateString())
                        {
                            item.DURUM_ID = (int)TaahhutDurum.ZAMANINDA_EKSIK;
                            item.ODEME_MIKTARI = odemetoPLAM;
                            sonrakiTaahhudeDevreden += odemetoPLAM;
                            odemetoPLAM -= odemetoPLAM;
                        }
                        else if (item.TAAHHUTU_YERINE_GETIRME_TARIHI > odemeTarihi.Value)
                        {
                            item.DURUM_ID = (int)TaahhutDurum.ZAMANINDAN_ONCE_EKSIK;
                            item.ODEME_MIKTARI = odemetoPLAM;
                            sonrakiTaahhudeDevreden += odemetoPLAM;
                            odemetoPLAM -= odemetoPLAM;
                        }
                        else
                        {
                            item.DURUM_ID = (int)TaahhutDurum.ZAMANINDAN_SONRA_EKSIK;
                            item.ODEME_MIKTARI = odemetoPLAM;
                            sonrakiTaahhudeDevreden += odemetoPLAM;
                            odemetoPLAM -= odemetoPLAM;
                        }
                    }
                    //else
                    //{
                    //    item.DURUM_ID = (int)TaahhutDurum.IHLAL_YOK;
                    //    item.TAAHHUTTEN_KALAN_MIKTAR = 0;
                    //}


                    //if (sonrakiTaahhudeDevreden == 0)
                    //    sonrakiTaahhudeDevreden = odemetoPLAM;
                    //else
                    //    sonrakiTaahhudeDevreden = odemetoPLAM + sonrakiTaahhudeDevreden - item.TAAHHUT_MIKTARI;

                    //item.ODEME_MIKTARI = (decimal)odemetoPLAM + sonrakiTaahhudeDevreden;

                    if (item.ODEME_MIKTARI >= item.TAAHHUT_MIKTARI)
                        item.TAAHHUTTEN_KALAN_MIKTAR = 0;
                    else
                        item.TAAHHUTTEN_KALAN_MIKTAR = item.TAAHHUT_MIKTARI - item.ODEME_MIKTARI;

                    //}
                //}
                //else
                //{
                //    item.DURUM_ID = (int)TaahhutDurum.IHLAL_YOK;
                //    item.TAAHHUTTEN_KALAN_MIKTAR = 0;
                //}
            }



            DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepSave(taahhutler[0]);

            //for (int odemeIndex = 0; odemeIndex < borclununOdemeleri.Count; odemeIndex++)
            //{
            //    if (borclununOdemeleri[odemeIndex].ODEME_MIKTAR + sonrakiTaahhudeDevreden > taahhut[i].AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection[odemeIndex].TAAHHUT_MIKTARI)
            //    {
            //        sonrakiTaahhudeDevreden = (decimal)borclununOdemeleri[odemeIndex].ODEME_MIKTAR + sonrakiTaahhudeDevreden - taahhut[i].AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection[odemeIndex].TAAHHUT_MIKTARI;
            //        taahhut[i].AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection[odemeIndex].DURUM_ID = (int)TaahhutDurum.ZAMANINDA_TAM;
            //        gecerlimi = true;
            //    }
            //    else if (borclununOdemeleri[odemeIndex].ODEME_MIKTAR + sonrakiTaahhudeDevreden == taahhut[i].AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection[odemeIndex].TAAHHUT_MIKTARI)
            //    {
            //        taahhut[i].AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection[odemeIndex].DURUM_ID = (int)TaahhutDurum.ZAMANINDA_TAM;
            //        gecerlimi = true;
            //    }
            //    else if (borclununOdemeleri[odemeIndex].ODEME_MIKTAR + sonrakiTaahhudeDevreden < taahhut[i].AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection[odemeIndex].TAAHHUT_MIKTARI)
            //    {
            //        taahhut[i].AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection[odemeIndex].DURUM_ID = (int)TaahhutDurum.ZAMANINDA_EKSIK;
            //        return false;
            //    }
            //}

            //return gecerlimi;

            //if (taahhut[i].AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection.Where(c => c.TAAHHUTU_YERINE_GETIRME_TARIHI <= DateTime.Now.Date).Select(c => c.TAAHHUT_MIKTARI).Sum() > borclununOdemeleri.Where(o => o.ODEME_TARIHI <= DateTime.Now.Date).Select(o => o.ODEME_MIKTAR).Sum())
            //{
            //    //taahhüt edilen miktarý toplam bakýmýndan ödememiþ
            //}
            if (taahhutler.Count > 0)
            {
                int ihlalSayisi = taahhutler[0].AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection.Where(t => t.DURUM_ID != (int)TaahhutDurum.ZAMANINDA_EKSIK || t.DURUM_ID != (int)TaahhutDurum.ZAMANINDA_ODEME_YOK || t.DURUM_ID != (int)TaahhutDurum.ZAMANINDAN_SONRA_EKSIK || t.DURUM_ID != (int)TaahhutDurum.ZAMANINDAN_SONRA_TAM).Count();
                GonderilenGelisme.TAAHHUT_TARIHI = taahhutler[0].TAAHHUT_TARIHI;
                if (taahhutler[0].AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection.Where(t => t.DURUM_ID != (int)TaahhutDurum.IHLAL_YOK).Count() > 0)
                {
                    GonderilenGelisme.TAAHHUT_TARIHI_DURUMU = "Ýhlal Yok";
                }

                else if (ihlalSayisi > 0)
                {
                    GonderilenGelisme.TAAHHUT_TARIHI_DURUMU = "Ýhlal Var (" + ihlalSayisi + ")";
                }
            }
        }

        public static int TarafIndexBul(AV001_TI_BIL_FOY MyFoy)
        {
            return MyFoy.AV001_TI_BIL_FOY_TARAFCollection.FindIndex(taraf => taraf.CARI_ID == BorcluCariID);
        }

        public static TList<AV001_TI_BIL_MEHIL> TarafMehilGetir(AV001_TI_BIL_FOY MyFoy)
        {
            if (MyFoy.AV001_TI_BIL_MEHILCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_MEHIL>));
            return
                MyFoy.AV001_TI_BIL_MEHILCollection.FindAll(
                    delegate(AV001_TI_BIL_MEHIL m) { return (m.ICRA_MEHIL_ISTEYEN_TARAF_ID == ucIcraTarafBilgileri.CurrBorcluId); });
        }

        public static AV001_TI_BIL_BORCLU_ODEME TarafOdemeleriniGetir(AV001_TI_BIL_FOY MyFoy)
        {
            TList<AV001_TI_BIL_BORCLU_ODEME> result = new TList<AV001_TI_BIL_BORCLU_ODEME>();

            if (MyFoy != null)
            {
                if (MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_BORCLU_ODEME>));

                result = MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection.FindAll(delegate
                                                                               (AV001_TI_BIL_BORCLU_ODEME odeme)
                                                                               {
                                                                                   return (odeme.ODEYEN_CARI_ID ==
                                                                                           ucIcraTarafBilgileri.
                                                                                               CurrBorcluId);
                                                                               });
            }
            if (result.Count > 0)
            {
                result.Sort("ODEME_TARIHI DESC");
                return result[0];
            }

            return null;
        }

        public static AV001_TDI_BIL_TEBLIGAT TebligatBul(AV001_TI_BIL_FOY MyFoy, int tAnaTurId, int tAltTurId, bool yuzuc)
        {
            TList<AV001_TDI_BIL_TEBLIGAT> result = new TList<AV001_TDI_BIL_TEBLIGAT>();
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_TEBLIGAT>));
            if (yuzuc)
            {
                foreach (AV001_TDI_BIL_TEBLIGAT var in MyFoy.AV001_TDI_BIL_TEBLIGATCollection)
                {
                    if (var.ANA_TUR_ID == tAnaTurId && var.ALT_TUR_ID == tAltTurId && !var.ICRA_ILK_TEBLIGAT_MI &&
                        var.KONU_ID == 164)
                        result.Add(var);
                }
            }
            else
            {
                if (MyFoy != null)
                {
                    foreach (AV001_TDI_BIL_TEBLIGAT var in MyFoy.AV001_TDI_BIL_TEBLIGATCollection)
                    {
                        if (var.ANA_TUR_ID == tAnaTurId && var.ALT_TUR_ID == tAltTurId && var.ICRA_ILK_TEBLIGAT_MI &&
                            var.KONU_ID != 164)
                            result.Add(var);
                    }
                }
            }
            if (result.Count > 0)
            {
                result.Sort("POSTALANMA_TARIH DESC");

                return result[0];
            }

            return null;
        }

        public static DateTime? TebligatTarihiHesapla(AV001_TI_BIL_FOY_TARAF_GELISME gonderilenGelisme, AV001_TI_BIL_FOY MyFoy)
        {
            if (MyFoy.FORM_TIP_IDSource == null)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TI_KOD_FORM_TIP));

            AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatap = null;

            if (!MyFoy.FORM_TIP_IDSource.ILAMLI_MI)
                muhatap = MuhatapBul(TebligatBul(MyFoy, 4, 11, false));
            else
            {
                if (MyFoy.FORM_TIP_ID == (int)FormTipleri.Form56)
                    muhatap = MuhatapBul(TebligatBul(MyFoy, 4, 86, false));
                else
                    muhatap = MuhatapBul(TebligatBul(MyFoy, 4, 12, false));
            }

            //gonderilenGelisme.BILA_TARIHI = null;
            gonderilenGelisme.BILA_TARIHI_DURUMU = string.Empty;

            //gonderilenGelisme.ZABITA_ARASTIRMA_TARIHI = null;
            gonderilenGelisme.ZABITA_ARASTIRMA_TARIHI_DURUMU = string.Empty;

            //gonderilenGelisme.ZABITA_ARASTIRMA_OLUMSUZ_TARIHI = null;
            gonderilenGelisme.ZABITA_ARASTIRMA_OLUMSUZ_TARIHI_DURUMU = string.Empty;

            //gonderilenGelisme.SUBEDEN_OLUMSUZ_CEVAP_TARIHI = null;
            gonderilenGelisme.SUBEDEN_OLUMSUZ_CEVAP_TARIHI_DURUMU = string.Empty;

            //gonderilenGelisme.SUBEDEN_YENI_ADRES_BILDIRILDIGI_TARIH = null;
            gonderilenGelisme.SUBEDEN_YENI_ADRES_BILDIRILDIGI_TARIH_DURUMU = string.Empty;

            //gonderilenGelisme.SUBEDEN_YENI_ADRES_ISTEME_TARIHI = null;
            gonderilenGelisme.SUBEDEN_YENI_ADRES_ISTEME_TARIHI_DURUMU = string.Empty;

            //gonderilenGelisme.ZABITACA_YENI_ADRES_BULUNDUGU_TARIHI = null;
            gonderilenGelisme.ZABITACA_YENI_ADRES_BULUNDUGU_TARIHI_DURUMU = string.Empty;

            if (muhatap != null)
            {
                if (!muhatap.TEBLIG_TARIH.HasValue)
                {
                    if (!muhatap.BILA_TEBLIG_MI && !muhatap.ZABITA_ARASTIRMASI_ISTENDI_MI &&
                        !muhatap.ZABITA_ARASTIRMASI_OLUMSUZ_MU)
                    {
                        gonderilenGelisme.ILK_TEBLIGAT_TARIHI_DURUMU = "Bekleniyor.";
                    }

                    else if (muhatap.BILA_TEBLIG_MI && !muhatap.ZABITA_ARASTIRMASI_ISTENDI_MI &&
                             !muhatap.ZABITA_ARASTIRMASI_OLUMSUZ_MU)
                    {
                        gonderilenGelisme.BILA_TARIHI = muhatap.BILA_TARIHI;
                        gonderilenGelisme.BILA_TARIHI_DURUMU = "Bila Teblið";
                    }

                    else if (muhatap.BILA_TEBLIG_MI && muhatap.ZABITA_ARASTIRMASI_ISTENDI_MI &&
                             muhatap.ZABITA_ARASTIRMASI_OLUMSUZ_MU)
                    {
                        gonderilenGelisme.ZABITA_ARASTIRMA_TARIHI = muhatap.ZABITA_ARASTIRMA_TARIHI;
                        gonderilenGelisme.ZABITA_ARASTIRMA_TARIHI_DURUMU = "Zabýta Araþtýrma Tarihi";
                    }

                    else if (muhatap.BILA_TEBLIG_MI && muhatap.ZABITA_ARASTIRMASI_ISTENDI_MI &&
                             !muhatap.ZABITA_ARASTIRMASI_OLUMSUZ_MU)
                    {
                        gonderilenGelisme.ZABITA_ARASTIRMA_OLUMSUZ_TARIHI = muhatap.OLUMSUZ_SONUC_TARIHI;
                        gonderilenGelisme.ZABITA_ARASTIRMA_OLUMSUZ_TARIHI_DURUMU = "Araþtýrma Olumsuz";
                    }
                }

                else if (muhatap.TEBLIG_TARIH.HasValue)
                {
                    //TODO: TIO - 20090715
                    //Error	5721	Argument '1': cannot convert from 'int?' to 'int'	E:\TfsBuildProje\AdimAdimDavaKaydi.root\AdimAdimDavaKaydi\AdimAdimDavaKaydi\UserControls\IcraTakipUserControls\ucIcraTarafGelismeleri.cs	1687	87	AdimAdimDavaKaydi
                    if (muhatap.ALAN_BAGLANTI_ID != null)
                    {
                        TDI_KOD_TEBLIGAT_ALAN_BAGLANTI kime = DataRepository.TDI_KOD_TEBLIGAT_ALAN_BAGLANTIProvider.GetByID((int)muhatap.ALAN_BAGLANTI_ID);

                        gonderilenGelisme.ILK_TEBLIGAT_TARIHI = muhatap.TEBLIG_TARIH;
                        gonderilenGelisme.ILK_TEBLIGAT_TARIHI_DURUMU = kime.BAGLANTI;
                    }
                    gonderilenGelisme.ILK_TEBLIGAT_TARIHI = muhatap.TEBLIG_TARIH;
                }

                if (muhatap.BILA_TARIHI.HasValue)
                {
                    //muhatap.BILA_TARIHI = DateTime.Now;
                    gonderilenGelisme.BILA_TARIHI = muhatap.BILA_TARIHI;
                    gonderilenGelisme.BILA_TARIHI_DURUMU = "Tebligat Bila";
                }
                else
                    gonderilenGelisme.BILA_TARIHI = null;

                if (muhatap.ZABITA_ARASTIRMA_TARIHI.HasValue)
                {
                    //muhatap.ZABITA_ARASTIRMA_TARIHI = DateTime.Now;
                    gonderilenGelisme.ZABITA_ARASTIRMA_TARIHI = muhatap.ZABITA_ARASTIRMA_TARIHI;
                    gonderilenGelisme.ZABITA_ARASTIRMA_TARIHI_DURUMU = "Z.Arast.Ýstendi.";
                }
                else
                    gonderilenGelisme.ZABITA_ARASTIRMA_TARIHI = null;

                if (muhatap.OLUMSUZ_SONUC_TARIHI.HasValue)
                {
                    //muhatap.OLUMSUZ_SONUC_TARIHI = DateTime.Now;
                    gonderilenGelisme.ZABITA_ARASTIRMA_OLUMSUZ_TARIHI = muhatap.OLUMSUZ_SONUC_TARIHI;
                    gonderilenGelisme.ZABITA_ARASTIRMA_OLUMSUZ_TARIHI_DURUMU = "Sonuç Olumsuz";
                }
                else
                    gonderilenGelisme.ZABITA_ARASTIRMA_OLUMSUZ_TARIHI = null;

                if (muhatap.SUBEDEN_OLUMSUZ_CEVAP_TARIHI.HasValue)
                {
                    gonderilenGelisme.SUBEDEN_OLUMSUZ_CEVAP_TARIHI = muhatap.SUBEDEN_OLUMSUZ_CEVAP_TARIHI;
                    gonderilenGelisme.SUBEDEN_OLUMSUZ_CEVAP_TARIHI_DURUMU = "Þb.Olumsuz Cvp Verdi";
                }
                else
                    gonderilenGelisme.SUBEDEN_OLUMSUZ_CEVAP_TARIHI = null;

                if (muhatap.SUBEDEN_YENI_ADRES_BILDIRILDIGI_TARIH.HasValue)
                {
                    gonderilenGelisme.SUBEDEN_YENI_ADRES_BILDIRILDIGI_TARIH =
                        muhatap.SUBEDEN_YENI_ADRES_BILDIRILDIGI_TARIH;
                    gonderilenGelisme.SUBEDEN_YENI_ADRES_BILDIRILDIGI_TARIH_DURUMU = "Þb.Yeni Adr.Bildirdi";
                }
                else
                    gonderilenGelisme.SUBEDEN_YENI_ADRES_BILDIRILDIGI_TARIH = null;

                if (muhatap.SUBEDEN_YENI_ADRES_ISTEME_TARIHI.HasValue)
                {
                    gonderilenGelisme.SUBEDEN_YENI_ADRES_ISTEME_TARIHI = muhatap.SUBEDEN_YENI_ADRES_ISTEME_TARIHI;
                    gonderilenGelisme.SUBEDEN_YENI_ADRES_ISTEME_TARIHI_DURUMU = "Þb.Yeni.Adr.Ýstendi";
                }
                else
                    gonderilenGelisme.SUBEDEN_YENI_ADRES_ISTEME_TARIHI = null;

                if (muhatap.ZABITACA_YENI_ADRES_BULUNDUGU_TARIHI.HasValue)
                {
                    gonderilenGelisme.ZABITACA_YENI_ADRES_BULUNDUGU_TARIHI =
                        muhatap.ZABITACA_YENI_ADRES_BULUNDUGU_TARIHI;
                    gonderilenGelisme.ZABITACA_YENI_ADRES_BULUNDUGU_TARIHI_DURUMU = "Zbt.Yeni.Adr.Buldu";
                }
                else
                    gonderilenGelisme.ZABITACA_YENI_ADRES_BULUNDUGU_TARIHI = null;

                return muhatap.TEBLIG_TARIH;
            }

            return null;
        }

        public static DateTime? YuzucTarihiHesapla(AV001_TI_BIL_FOY_TARAF_GELISME gonderilenGelisme, AV001_TI_BIL_FOY MyFoy)
        {
            AV001_TDI_BIL_TEBLIGAT_MUHATAP yuzucMuhatap = MuhatapBul(TebligatBul(MyFoy, 4, 13, true));

            gonderilenGelisme.YUZUC_TARIHI = null;
            gonderilenGelisme.YUZUC_TARIHI_DURUMU = string.Empty;

            if (yuzucMuhatap != null)
            {
                if (yuzucMuhatap.TEBLIG_TARIH.HasValue)
                {
                    gonderilenGelisme.YUZUC_TARIHI = yuzucMuhatap.TEBLIG_TARIH;
                    gonderilenGelisme.YUZUC_TARIHI_DURUMU = "103 Teblið";
                }
            }

            return gonderilenGelisme.YUZUC_TARIHI;
        }

        public int CurrAlacakliId(AV001_TI_BIL_FOY foy)
        {
            TList<AV001_TI_BIL_FOY_TARAF> result = new TList<AV001_TI_BIL_FOY_TARAF>();
            result = ucIcraTarafBilgileri.AlacakliTaraflariGetir(foy);

            if (result.Count > 0)
                return result[0].CARI_ID.Value;

            return 0;
        }

        private void dnGelisme_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null)
                return;
            if (e.Button.Tag.ToString() == "Refresh")
            {
                vgGelismeler.Refresh();

                XtraMessageBox.Show(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)].CARI_IDSource.AD + " " + " isimli tarafýn geliþmeleri güncellendi.", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.Button.Tag.ToString() == "Kaydet")
            {
                if (GelismleriKaydet(new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr), myGelisme, MyFoy, true))
                    XtraMessageBox.Show("Geliþmeler kaydedildi.", "Geliþmeleri Kaydet",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show("Kaydetme iþlemi yapýlamadý.", "Hata",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (e.Button.Tag.ToString() == "Yazdir")
            {
                //Yazdirma Ýþlemi
            }

            if (e.Button.Tag.ToString() == "Style")
            {
                GorunumDegistir();
            }

            if (e.Button.Tag.ToString() == "Excel")
            {
                frmInputBox frm = new frmInputBox();
                frm.StartPosition = FormStartPosition.CenterScreen;

                // frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();

                string path = frm.DosyaYolu;
                if (path != string.Empty)
                {
                    path = path + "\\gelismeler.xls";

                    if (System.IO.File.Exists(path))
                    {
                        DialogResult ds = XtraMessageBox.Show(path + " " + "zaten var.Üzerinde kaydedilsin mi?", "Uyarý", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (ds == DialogResult.Yes)
                        {
                            vgGelismeler.ExportToXls(path);

                            DialogResult ds2 =
                                XtraMessageBox.Show(
                                    "Excel dosyanýz" + " " + path + " " +
                                    "yoluna kaydedilmiþtir. Dosyayý açmak istiyor musunuz ?",
                                    "Excel Dosyasý Kaydedildi.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                            if (ds2 == DialogResult.OK)
                                System.Diagnostics.Process.Start(path);
                        }
                    }
                    else
                    {
                        vgGelismeler.ExportToXls(path);

                        DialogResult ds3 =
                            XtraMessageBox.Show(
                                "Excel dosyanýz" + " " + path + " " +
                                "yoluna kaydedilmiþtir. Dosyayý açmak istiyor musunuz ?", "Excel Dosyasý Kaydedildi.",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (ds3 == DialogResult.OK)
                            System.Diagnostics.Process.Start(path);
                    }
                }
            }
        }

        private void dnGelisme_PositionChanged(object sender, EventArgs e)
        {
            DataNavigator nav = sender as DataNavigator;

            ucIcraTarafBilgileri.CurrBorcluId =
                ((TList<AV001_TI_BIL_FOY_TARAF>)nav.DataSource)[nav.Position].CARI_ID.Value;
            CurrBorcluId = ((TList<AV001_TI_BIL_FOY_TARAF>)nav.DataSource)[nav.Position].CARI_ID.Value;
            BorcluCariID = ((TList<AV001_TI_BIL_FOY_TARAF>)nav.DataSource)[nav.Position].CARI_ID.Value;
            lueTaraf.EditValue = BorcluCariID;

            //ucIcraTarafBilgileri.TarafControl.EditValue = CurrBorcluId;

            TList<AV001_TI_BIL_FOY_TARAF_GELISME> result = GelismeleriGuncelle(MyFoy, myGelisme);

            vgGelismeler.DataSource = result;
        }

        private void HacizFormuAc(HacizKaynak kaynak)
        {
            AV001_TI_BIL_HACIZ_MASTER master = SonHacizKaydýnýGetir(MyFoy);

            if (master == null)
            {
                DialogResult dr = new DialogResult();
                switch (MyFoy.FORM_TIP_ID)
                {
                    case 2:
                    case 7:
                    case 8:
                    case 13:
                        dr = XtraMessageBox.Show(CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " + " isimli tarafa baðlý rehin kaydý bulunmadýðýndan sistem sizin için üretecektir.", "Rehin Kaydý Üretilecek", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        break;
                    default:
                        dr = XtraMessageBox.Show(CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " + " isimli tarafa baðlý haciz kaydý bulunmadýðýndan sistem sizin için üretecektir.", "Haciz Kaydý Üretilecek", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        break;
                }

                if (dr == DialogResult.OK)
                {
                    master = MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.AddNew();
                    master.HACIZ_ISTENEN_CARI_ID = CurrBorcluId;
                    master.TALIMAT_MI = true;
                    master.HACIZ_TARIHI = DateTime.Now;
                    master.HACIZ_KAYNAGI = (byte)kaynak;

                    //AV001_TI_BIL_HACIZ_CHILD child = master.AV001_TI_BIL_HACIZ_CHILDCollection.AddNew();

                    frmHacizGirisi frm = new frmHacizGirisi();
                    frm.HacizEdilecekMalVar = false;
                    frm.HacizKaynagi = kaynak;

                    frm.MyGelisme = myGelisme;
                    frm.HacizEdilecekMalVar = true;
                    frm.Show(MyFoy, master);
                }
            }
            else
            {
                DialogResult dr = new DialogResult();
                switch (MyFoy.FORM_TIP_ID)
                {
                    case 2:
                    case 7:
                    case 8:
                    case 13:
                        dr = XtraMessageBox.Show(
                              CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " + " isimli tarafa baðlý son rehin kaydýný açmak istiyor musunuz ?", "Rehin Formunu Aç", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        break;
                    default:
                        dr = XtraMessageBox.Show(
                          CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " + " isimli tarafa baðlý son haciz kaydýný açmak istiyor musunuz ?", "Haciz Formunu Aç", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        break;
                }

                if (dr == DialogResult.OK)
                {
                    frmHacizGirisi frm = new frmHacizGirisi();
                    frm.HacizKaynagi = kaynak;
                    frm.HacizEdilecekMalVar = true;
                    frm.MyGelisme = myGelisme;
                    frm.Show(MyFoy, master);
                }
            }
        }

        private void IhlalDavasýAc(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.ICRA_DAIRESINDE_KARARLASTIRILAN_BORCUN_ODEME_SARTINI_IHLAL_ETMEK);
            TList<AV001_TD_BIL_FOY> result = IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                DialogResult dr = XtraMessageBox.Show(CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " + "isimli tarafa baðlý dosyada ihlal davasý bulunmadýðýndan sistem sizin için üretecektir. Devam etmek istiyor musunuz?", "Dava Kaydý Üretilecek", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    if (!TaahhutuYerineGetirmeTarihi.HasValue)
                        XtraMessageBox.Show("Dava kaydý oluþturulmasý için ihlal tarihi gereklidir.", "Dava Kaydý Üretilecek", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        DavaCreator.DavaOlustur(
                            MyFoy, myGelisme,
                            DavaTalep.TAAHHUDU_IHLAL,
                            AdliBirimBolumGorev.ICM,
                            DavaTipi.ICRA_CEZA,
                            DavaAdi.ICRA_DAIRESINDE_KARARLASTIRILAN_BORCUN_ODEME_SARTINI_IHLAL_ETMEK,
                            TaahhutuYerineGetirmeTarihi.Value,
                            ucIcraTarafBilgileri.CurrTarafId, TarafSifat.DAVACI,
                            TarafKodu.Muvekkil,
                            ucIcraTarafBilgileri.CurrBorcluId,
                            TarafSifat.DAVALI,
                            TarafKodu.KarsiTaraf);
                    }
                }
            }

            else
            {
                string str = "Dosyayý";
                if (result.Count > 1)
                    str = "Dosyalarý";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya baðlý" + " " + result.Count + " " + "tane" + " " + "dava kaydý bulunmaktadýr." + str + " " + "takip ekranýnda açmak istiyor musunuz?", "Dava Takip", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        private void IhtiyatiHacizFormuAc()
        {
            frmIcraIhtiyatiHaciz frm = new frmIcraIhtiyatiHaciz();

            AV001_TI_BIL_IHTIYATI_HACIZ entity = IhtiyatiHacizGetir(MyFoy);

            if (entity == null)
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " +
                        " isimli tarafa baðlý ihtiyati haciz kaydý bulunmadýðýndan sistem sizin için otomatik olarak üretecektir.",
                        "Ýhtiyati Haciz Üretilecek",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    TList<AV001_TI_BIL_FOY_TARAF> taraf = MyFoy.AV001_TI_BIL_FOY_TARAFCollection;
                    frm.MyFoy = MyFoy;
                    frm.MyGelisme = myGelisme;
                    frm.MyDataSource = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.Show();
                }
            }
            else
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " +
                        " isimli tarafa baðlý son ihtiyati haciz kaydýný açmak istiyor musunuz ?.",
                        "Ýhtiyati Haciz Formunu Aç",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    frm.MyFoy = this.MyFoy;
                    frm.MyGelisme = myGelisme;
                    frm.MyDataSource = MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.Show();
                }
            }
        }

        private void IhtiyatiTedbirFormuAc()
        {
            frmDavaIcraIhtiyatiTedbir frm = new frmDavaIcraIhtiyatiTedbir();

            TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> result = IhtiyatiTedbirGetir(MyFoy);

            if (result.Count == 0)
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(vi => vi.CARI_ID == CurrBorcluId)/*[TarafIndexBul(MyFoy)]*/) + " " +
                        " isimli tarafa baðlý ihtiyati tedbir kaydý bulunmadýðýndan sistem sizin için otomatik olarak üretecektir.",
                        "Ýhtiyati Tedbir Üretilecek",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    AV001_TDI_BIL_IHTIYATI_TEDBIR addNew = MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.AddNew();
                    addNew.TALEP_TARIHI = DateTime.Today;
                    addNew.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID.Value;
                    addNew.ESAS_NO = MyFoy.ESAS_NO;
                    addNew.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID.Value;
                    addNew.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
                    addNew.BIRIM_NO = MyFoy.BIRIM_NO;
                    addNew.KAYIT_TARIHI = DateTime.Today;
                    addNew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    addNew.KONTROL_KIM = "AVUKATPRO";
                    addNew.KONTROL_NE_ZAMAN = DateTime.Today;
                    addNew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    addNew.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    addNew.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                    AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF taraf = addNew.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection.AddNew();

                    taraf.ADMIN_KAYIT_MI = false;
                    taraf.KAYIT_TARIHI = DateTime.Today;
                    taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    taraf.KONTROL_KIM = "AVUKATPRO";
                    taraf.KONTROL_NE_ZAMAN = DateTime.Today;
                    taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                    taraf.ICRA_CARI_TARAF_ID = CurrBorcluId;// ucIcraTarafBilgileri.CurrBorcluId;

                    if (BelgeUtil.Inits._FoyTarafGetir == null)
                        BelgeUtil.Inits._FoyTarafGetir = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAFs.ToList();

                    AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF t = BelgeUtil.Inits._FoyTarafGetir.Find(vi => vi.CARI_ID == CurrBorcluId);

                    taraf.ICRA_TARAF_SIFAT_ID = t.TARAF_SIFAT_ID;

                    result.Add(addNew);

                    frm.MyFoy = this.MyFoy;
                    frm.MyGelisme = myGelisme;
                    frm.MyDataSource = result;
                    frm.Show();
                }
            }
            else
            {
                frm.MyFoy = this.MyFoy;
                frm.MyGelisme = myGelisme;
                frm.MyDataSource = result;// MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;
                frm.Show();
            }
        }

        private void ItirazDavasýAc(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.ITIRAZIN_KESIN_OLARAK_KALDIRILMASI);
            dList.Add(DavaAdi.ITIRAZIN_KALDIRILMASI_VE_TAHLIYE);
            dList.Add(DavaAdi.ITIRAZIN_GECICI_OLARAK_KALDIRILMASI);

            TList<AV001_TD_BIL_FOY> result = IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " +
                        "isimli tarafa baðlý dosyada itiraz davasý bulunmadýðýndan sistem sizin için üretecektir. Devam etmek istiyor musunuz?", "Ýtiraz Davasý Üretilecek", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    if (!GonderilenGelisme.ITIRAZ_TARIHI.HasValue)
                    {
                        XtraMessageBox.Show("Ýtiraz tarihi bulunamýyor! Bu durumda yeni dava kaydý oluþturulamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ItirazFormuAc();

                        //XtraMessageBox.Show("Ýtiraz kaydý oluþturma istiyormusunuz?", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DavaCreator.DavaOlustur(
                            MyFoy, GonderilenGelisme,
                            DavaTalep.ITIRAZIN_KESIN_KALDIRILMASI_TALEBI,
                            AdliBirimBolumGorev.ICM,
                            DavaTipi.ICRA_HUKUK,
                            DavaAdi.ITIRAZIN_KESIN_OLARAK_KALDIRILMASI,
                            GonderilenGelisme.ITIRAZ_TARIHI.Value,
                            ucIcraTarafBilgileri.CurrTarafId, TarafSifat.DAVACI,
                            TarafKodu.Muvekkil,
                            ucIcraTarafBilgileri.CurrBorcluId,
                            TarafSifat.DAVALI,
                            TarafKodu.KarsiTaraf);
                    }
                }
            }

            else
            {
                string str = "Dosyayý";
                if (result.Count > 1)
                    str = "Dosyalarý";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya baðlý" + " " + result.Count + " " + "tane" + " " +
                                                      "itiraz davasý bulunmaktadýr." + str + " " +
                                                      "takip ekranýnda açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result[0].ID);
                }
            }
        }

        private void ItirazFormuAc()
        {
            AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN result = ItirazGetir(MyFoy);

            if (result == null)
            {
                DialogResult dr =
                    XtraMessageBox.Show(CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " + " isimli tarafa baðlý itiraz kaydý bulunmadýðýndan sistem sizin için otomatik olarak üretecektir.", "Ýtiraz Üretilecek", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> itirazAN = new TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>();
                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN itiraz =
                            neden.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection.AddNew();
                        itiraz.ALACAK_NEDEN_ID = neden.ID;
                        itiraz.ITIRAZ_EDEN_TARAF_ID = BorcluCariID;
                        if (MyFoy.ADLI_BIRIM_ADLIYE_ID.HasValue)
                            itiraz.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID.Value;
                        if (MyFoy.ADLI_BIRIM_GOREV_ID.HasValue)
                            itiraz.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID.Value;
                        itiraz.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
                        itiraz.BIRIM_NO = MyFoy.BIRIM_NO;
                        itiraz.ITIRAZ_TARIHI = DateTime.Today;
                        itirazAN.Add(itiraz);
                    }
                    rFrmItiraz frm = new rFrmItiraz();
                    frm.ItirazAlacakNeden = itirazAN;
                    frm.MyGelisme = myGelisme;
                    frm.MyFoy = this.MyFoy;
                    frm.Show(itirazAN);
                }
            }
            else
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " +
                        " isimli tarafa baðlý son itiraz kaydýný açmak istiyor musunuz ?", "Ýtiraz Formunu Aç",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    rFrmItiraz frm = new rFrmItiraz();
                    frm.MyGelisme = myGelisme;
                    frm.MyFoy = this.MyFoy;
                    frm.Show(result);
                }
            }
        }

        private void MalBeyaniDavasýAc(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.MAL_BEYANINDA_BULUNMAMA);
            TList<AV001_TD_BIL_FOY> result = IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " +
                        "isimli tarafa baðlý dosyada mal beyaný davasý bulunmadýðýndan sistem sizin için üretecektir. Devam etmek istiyor musunuz?",
                        "Mal Beyaný Dava Kaydý Üretilecek", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    if (!SonMalBeyaniTarihi.HasValue)
                        XtraMessageBox.Show("Son mal beyaný tarihi bulunamýyor!", "Hata", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                    else
                    {
                        DavaCreator.DavaOlustur(
                            MyFoy, GonderilenGelisme,
                            DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                            AdliBirimBolumGorev.ICM,
                            DavaTipi.ICRA_CEZA,
                            DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                            SonMalBeyaniTarihi.Value,
                            ucIcraTarafBilgileri.CurrTarafId, TarafSifat.DAVACI,
                            TarafKodu.Muvekkil,
                            ucIcraTarafBilgileri.CurrBorcluId,
                            TarafSifat.DAVALI,
                            TarafKodu.KarsiTaraf);
                    }
                }
            }

            else
            {
                string str = "Dosyayý";
                if (result.Count > 1)
                    str = "Dosyalarý";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya baðlý" + " " + result.Count + " " + "tane" + " " +
                                                      "mal beyaný dava kaydý bulunmaktadýr." + str + " " +
                                                      "takip ekranýnda açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        private void MalBeyaniFormuAc()
        {
            AV001_TI_BIL_MAL_BEYANI result = MalBeyaniBul(MyFoy);

            if (result == null)
            {
                DialogResult dr =
                    XtraMessageBox.Show(CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " "
                                        +
                                        " isimli tarafa baðlý mal beyaný kaydý bulunmadýðýndan sistem sizin için otomatik olarak üretecektir.",
                                        "Mal Beyaný Üretilecek",
                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    AV001_TI_BIL_MAL_BEYANI addNew = MyFoy.AV001_TI_BIL_MAL_BEYANICollection.AddNew();
                    addNew.ICRA_TARAF_ID = ucIcraTarafBilgileri.CurrBorcluId;
                    addNew.MAL_BEYAN_TARIHI = DateTime.Today;

                    Forms.frmMalBeyani frm = new AdimAdimDavaKaydi.Forms.frmMalBeyani();
                    frm.MyGelisme = myGelisme;
                    frm.Show(MyFoy);
                }
            }
            else
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " +
                        " isimli tarafa baðlý son mal beyaný kaydýný açmak istiyor musunuz ?", "Mal Beyaný Formunu Aç",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    Forms.frmMalBeyani frm = new AdimAdimDavaKaydi.Forms.frmMalBeyani();
                    frm.MyGelisme = myGelisme;
                    frm.Show(MyFoy);
                }
            }
        }

        private void MehilFormuAc()
        {
            rFrmMehil frm = new rFrmMehil();

            TList<AV001_TI_BIL_MEHIL> result = TarafMehilGetir(MyFoy);

            if (result.Count == 0)
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " +
                        " isimli tarafa baðlý mehil kaydý bulunmadýðýndan sistem sizin için üretecektir.",
                        "Mehil Üretilecek",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    AV001_TI_BIL_MEHIL addNew = MyFoy.AV001_TI_BIL_MEHILCollection.AddNew();
                    addNew.ICRA_MEHIL_ISTEYEN_TARAF_ID = ucIcraTarafBilgileri.CurrBorcluId;
                }

                frm.MyDataSource = new TList<AV001_TI_BIL_MEHIL>();
                frm.MyGelisme = myGelisme;
                frm.Show(MyFoy);
            }
            else
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " +
                        " isimli tarafa baðlý son mehil kaydýný açmak istiyor musunuz ?", "Mehil Formunu Aç",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    frm.MyDataSource = result;
                    frm.MyGelisme = myGelisme;
                    frm.Show(MyFoy);
                }
            }
        }

        private void OdemeFormuAc()
        {
            AV001_TI_BIL_BORCLU_ODEME odeme = TarafOdemeleriniGetir(MyFoy);

            if (odeme == null)
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " +
                        " isimli tarafa baðlý ödeme kaydý bulunmadýðýndan sistem sizin için üretecektir.",
                        "Ödeme Üretilecek",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    odeme = MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection.AddNew();
                    odeme.ODENEN_CARI_ID = CurrAlacakliId(MyFoy);
                    odeme.ODEYEN_CARI_ID = ucIcraTarafBilgileri.CurrBorcluId;
                    odeme.BORCLU_ADINA_ODEYEN_CARI_ID = ucIcraTarafBilgileri.CurrBorcluId;
                    odeme.BORCLU_ADINA_ODENEN_CARI_ID = CurrAlacakliId(MyFoy);
                    odeme.ODEME_TIP_ID = 1;
                    odeme.ODEME_TARIHI = DateTime.Today;
                    odeme.ADMIN_KAYIT_MI = false;
                    odeme.KAYIT_TARIHI = DateTime.Today;
                    odeme.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    odeme.KONTROL_KIM = "AVUKATPRO";
                    odeme.KONTROL_NE_ZAMAN = DateTime.Today;
                    odeme.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    odeme.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    odeme.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                    rFrmTarafOdeme frm = new rFrmTarafOdeme();
                    frm.MyGelisme = myGelisme;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.Show(odeme, MyFoy);
                }
            }
            else
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " +
                        " isimli tarafa baðlý son ödeme kaydýný açmak istiyor musunuz ?", "Ödeme Formunu Aç",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    rFrmTarafOdeme frm = new rFrmTarafOdeme();
                    frm.MyGelisme = myGelisme;
                    frm.Show(odeme, MyFoy);
                }
            }
        }

        private void RowFormat(FormTipleri mFormTipi)
        {
            if (mFormTipi == FormTipleri.Form54 || mFormTipi == FormTipleri.Form55)
                mRowItirazKalIhtT.Visible = false;
            else
                mRowItirazKalIhtT.Visible = true;

            if (mFormTipi == FormTipleri.Form54 || mFormTipi == FormTipleri.Form55
                || mFormTipi == FormTipleri.Form56)
            {
                mRowThutT.Visible = false;
                mRowTihlalDT.Visible = false;
            }
            else
            {
                mRowThutT.Visible = true;
                mRowTihlalDT.Visible = true;
            }

            if (mFormTipi == FormTipleri.Form50 || mFormTipi == FormTipleri.Form201 || mFormTipi == FormTipleri.Form151 ||
                mFormTipi == FormTipleri.Form152)
            {
                mRowSonHacizT.Properties.Caption = "Rehin T.";
            }
            else
                mRowSonHacizT.Properties.Caption = "Son Haciz T.";

            if (mFormTipi == FormTipleri.Form50 || mFormTipi == FormTipleri.Form54
                || mFormTipi == FormTipleri.Form55 || mFormTipi == FormTipleri.Form56
                || mFormTipi == FormTipleri.Form151 || mFormTipi == FormTipleri.Form152
                || mFormTipi == FormTipleri.Form201)
            {
                mRowYuzucT.Visible = false;
            }
            else
                mRowYuzucT.Visible = true;

            if (mFormTipi == FormTipleri.Form54 || mFormTipi == FormTipleri.Form55 || mFormTipi == FormTipleri.Form56)
                mRowSatisT.Visible = false;
            else
                mRowSatisT.Visible = true;

            if (mFormTipi == FormTipleri.Form50 || mFormTipi == FormTipleri.Form54
                || mFormTipi == FormTipleri.Form55 || mFormTipi == FormTipleri.Form56
                || mFormTipi == FormTipleri.Form151 || mFormTipi == FormTipleri.Form152
                || mFormTipi == FormTipleri.Form201)
            {
                mRowAcizT.Visible = false;
                mRowMBBDavaT.Visible = false;
                mRowMalBeyaniT.Visible = false;
            }
            else
            {
                mRowAcizT.Visible = true;
                mRowMBBDavaT.Visible = true;
                mRowMalBeyaniT.Visible = true;
            }

            if (!MyFoy.FORM_TIP_IDSource.ILAMLI_MI)
            {
                catRowMehilBilg.Visible = false;
            }
            else
            {
                catRowMehilBilg.Visible = true;
            }

            if (mFormTipi == FormTipleri.Form49 || mFormTipi == FormTipleri.Form51
                || mFormTipi == FormTipleri.Form52 || mFormTipi == FormTipleri.Form53
                || mFormTipi == FormTipleri.Form54 || mFormTipi == FormTipleri.Form55
                || mFormTipi == FormTipleri.Form56 || mFormTipi == FormTipleri.Form163
                || mFormTipi == FormTipleri.Form153)
            {
                catRowRehinT.Visible = false;
            }
            else
            {
                catRowRehinT.Visible = true;
            }
        }

        private void SatisFormuAc()
        {
            frmSatisGirisi frm = new frmSatisGirisi();

            TList<AV001_TI_BIL_SATIS_MASTER> result = SatislariGetir(MyFoy);

            if (result.Count == 0)
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " +
                        " isimli tarafa baðlý satýþ kaydý bulunmadýðýndan sistem sizin için üretecektir.",
                        "Satýþ Üretilecek",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    AV001_TI_BIL_SATIS_MASTER addNew = MyFoy.AV001_TI_BIL_SATIS_MASTERCollection.AddNew();
                    addNew.SATISI_ISTENEN_CARI_ID = ucIcraTarafBilgileri.CurrBorcluId;
                    addNew.ADMIN_KAYIT_MI = false;
                    addNew.KAYIT_TARIHI = DateTime.Today;
                    addNew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    addNew.KONTROL_KIM = "AVUKATPRO";
                    addNew.KONTROL_NE_ZAMAN = DateTime.Today;
                    addNew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    addNew.STAMP = AvukatProLib.Kimlik.DefaultStamp;

                    AV001_TI_BIL_SATIS_CHILD child = addNew.AV001_TI_BIL_SATIS_CHILDCollection.AddNew();

                    child.ADMIN_KAYIT_MI = false;
                    child.KAYIT_TARIHI = DateTime.Today;
                    child.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    child.KONTROL_KIM = "AVUKATPRO";
                    child.KONTROL_NE_ZAMAN = DateTime.Today;
                    child.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    child.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    child.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                }
            }

            frm.MyGelisme = myGelisme;
            frm.Show(MyFoy);
        }

        private void TaahhutFormuAc()
        {
            TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER> result = TaahhutGetir(MyFoy);

            if (result.Count == 0)
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " +
                        " isimli tarafa baðlý taahhut kaydý bulunmadýðýndan sistem sizin için üretecektir.",
                        "Taahhut Üretilecek",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    AV001_TI_BIL_BORCLU_TAAHHUT_MASTER tah = MyFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection.AddNew();
                    tah.TAAHHUT_TIP = 1;
                    tah.TAAHHUT_EDEN_ID = ucIcraTarafBilgileri.CurrBorcluId;
                    tah.TAAHHUT_TARIHI = DateTime.Today;
                    tah.TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI = DateTime.Today;
                    tah.TAAHHUDU_KABUL_TARIHI = DateTime.Today;
                    tah.RESMI_MI = true;
                    tah.GECERLI_MI = true;
                    tah.ADMIN_KAYIT_MI = false;
                    tah.KAYIT_TARIHI = DateTime.Today;
                    tah.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    tah.KONTROL_KIM = "AVUKATPRO";
                    tah.KONTROL_NE_ZAMAN = DateTime.Today;
                    tah.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    tah.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    tah.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                    AV001_TI_BIL_BORCLU_TAAHHUT_CHILD child = tah.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection.AddNew();
                    child.DURUM_ID = 1;
                    child.TAAHHUTU_YERINE_GETIRME_TARIHI = DateTime.Today;
                    child.ADMIN_KAYIT_MI = false;
                    child.KAYIT_TARIHI = DateTime.Today;
                    child.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    child.KONTROL_KIM = "AVUKATPRO";
                    child.KONTROL_NE_ZAMAN = DateTime.Today;
                    child.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    child.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    child.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                }
                rFrmTaahhut frm = new rFrmTaahhut();
                frm.MyFoy = this.MyFoy;
                frm.MyGelisme = myGelisme;
                frm.Show();
            }
            else
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " +
                        " isimli tarafa baðlý son taahhüt kaydýný açmak istiyor musunuz ?", "Taahhüt Formunu Aç",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    rFrmTaahhut frm = new rFrmTaahhut();
                    frm.MyFoy = this.MyFoy;
                    frm.MyGelisme = myGelisme;
                    frm.TaahhutList = result;
                    frm.TaahhutChild = result[0].AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection;
                    frm.Show();
                }
            }
        }

        private void TebligatFormuAc(bool Yuzuc)
        {
            AV001_TDI_BIL_TEBLIGAT tebligat = null;
            AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatap = MuhatapBul(tebligat);

            if (!Yuzuc)
            {
                #region TebligatFormu

                if (MyFoy.FORM_TIP_IDSource == null)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TI_KOD_FORM_TIP));

                if (!MyFoy.FORM_TIP_IDSource.ILAMLI_MI)
                    tebligat = TebligatBul(MyFoy, 4, 11, false);
                else
                {
                    if (MyFoy.FORM_TIP_ID == (int)FormTipleri.Form56)
                        tebligat = TebligatBul(MyFoy, 4, 86, false);
                    else
                        tebligat = TebligatBul(MyFoy, 4, 12, false);
                }

                if (tebligat == null)
                {
                    DialogResult dr =
                        XtraMessageBox.Show(
                            CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(vi => vi.CARI_ID == CurrBorcluId)/*[TarafIndexBul(MyFoy)]*/) + " " + " isimli tarafa baðlý tebligat kaydý bulunmadýðýndan sistem sizin için otomatik olarak üretecektir.", "Tebligat Üretilecek", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (dr == DialogResult.OK)
                    {
                        tebligat = MyFoy.AV001_TDI_BIL_TEBLIGATCollection.AddNew();
                        tebligat.ICRA_FOY_ID = MyFoy.ID;
                        tebligat.TEBLIGAT_HEDEF_TIP = 1;
                        tebligat.ANA_TUR_ID = 4;

                        if (!MyFoy.FORM_TIP_IDSource.ILAMLI_MI)
                            tebligat.ALT_TUR_ID = 11;
                        else
                        {
                            if (MyFoy.FORM_TIP_ID == (int)FormTipleri.Form56)
                                tebligat.ALT_TUR_ID = 86;
                            else
                                tebligat.ALT_TUR_ID = 12;
                        }

                        tebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;
                        tebligat.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
                        tebligat.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
                        tebligat.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
                        tebligat.ICRA_ILK_TEBLIGAT_MI = true;
                        tebligat.TEBLIGAT_REFERANS_NO = AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit.TebligatReferansNoOlustur();
                        if (BelgeUtil.Inits._TebligatHacizIhbarnameKonuGetir == null)
                            BelgeUtil.Inits._TebligatHacizIhbarnameKonuGetir = DataRepository.per_TDI_KOD_TEBLIGAT_KONUProvider.GetAll();
                        per_TDI_KOD_TEBLIGAT_KONU konu = BelgeUtil.Inits._TebligatHacizIhbarnameKonuGetir.
                            Find(delegate(per_TDI_KOD_TEBLIGAT_KONU k) { return (k.ALT_TUR_ID == 11 && k.ANA_TUR_ID == 4); });

                        tebligat.KONU_ID = konu.ID;
                        tebligat.KAYIT_TARIHI = DateTime.Today;
                        tebligat.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                        tebligat.KONTROL_KIM = "AVUKATPRO";
                        tebligat.KONTROL_NE_ZAMAN = DateTime.Now;
                        tebligat.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                        tebligat.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                        tebligat.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                        AV001_TDI_BIL_TEBLIGAT_MUHATAP muh = tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddNew();
                        muh.MUHATAP_CARI_ID = ucIcraTarafBilgileri.CurrBorcluId;

                        muh.KAYIT_TARIHI = DateTime.Today;
                        muh.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                        muh.KONTROL_KIM = "AVUKATPRO";
                        muh.KONTROL_NE_ZAMAN = DateTime.Today;
                        muh.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                        muh.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                        muh.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                        rFrmTebligat frm = new rFrmTebligat();
                        frm.TFormTipi = rFrmTebligat.TebligatFormTipi.TebligatFormu;

                        //frm.MdiParent = null;
                        frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frm.MyFoy = this.MyFoy;
                        frm.MyGelisme = myGelisme;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Show(tebligat);
                    }
                }

                else
                {
                    DialogResult dr = XtraMessageBox.Show(CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(vi => vi.CARI_ID == CurrBorcluId)/*[TarafIndexBul(MyFoy)]*/) + " " + " isimli tarafa baðlý tebligat kayýtlarýný açmak istiyor musunuz ?", "Tebligat Formunu Aç", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (dr == DialogResult.OK)
                    {
                        rFrmTebligat frm = new rFrmTebligat();
                        frm.TFormTipi = rFrmTebligat.TebligatFormTipi.TebligatFormu;
                        frm.MyFoy = this.MyFoy;
                        frm.MyGelisme = myGelisme;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        if (tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count == 0)
                            DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(tebligat, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>));
                        frm.MyTebligatMuhatap = tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Find(vi => vi.MUHATAP_CARI_ID == CurrBorcluId);
                        frm.Show(tebligat);
                    }
                }

                #endregion TebligatFormu
            }

            else
            {
                #region YuzucFormu

                tebligat = TebligatBul(MyFoy, 4, 13, true);

                if (tebligat == null)
                {
                    DialogResult dr =
                        XtraMessageBox.Show(
                            CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " +
                            " isimli tarafa baðlý 103 kaydý bulunmadýðýndan sistem sizin için otomatik olarak üretecektir.",
                            "Yüzüc Üretilecek", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (dr == DialogResult.OK)
                    {
                        tebligat = MyFoy.AV001_TDI_BIL_TEBLIGATCollection.AddNew();
                        tebligat.ICRA_FOY_ID = MyFoy.ID;
                        tebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;
                        tebligat.ANA_TUR_ID = 4;
                        tebligat.ALT_TUR_ID = 13;
                        tebligat.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
                        tebligat.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
                        tebligat.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
                        tebligat.ICRA_ILK_TEBLIGAT_MI = false;
                        tebligat.TEBLIGAT_REFERANS_NO = AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit.TebligatReferansNoOlustur();

                        tebligat.KONU_ID = 164; //Yuzuc Teblig
                        tebligat.KAYIT_TARIHI = DateTime.Today;
                        tebligat.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                        tebligat.KONTROL_KIM = "AVUKATPRO";
                        tebligat.KONTROL_NE_ZAMAN = DateTime.Today;
                        tebligat.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                        tebligat.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                        tebligat.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                        AV001_TDI_BIL_TEBLIGAT_MUHATAP muh = tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddNew();
                        muh.MUHATAP_CARI_ID = ucIcraTarafBilgileri.CurrBorcluId;
                        muh.KAYIT_TARIHI = DateTime.Today;
                        muh.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                        muh.KONTROL_KIM = "AVUKATPRO";
                        muh.KONTROL_NE_ZAMAN = DateTime.Today;
                        muh.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                        muh.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                        muh.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                        rFrmTebligat frm = new rFrmTebligat();
                        frm.TFormTipi = rFrmTebligat.TebligatFormTipi.YuzucFormu;
                        frm.Text = "Tebligat Kayýt Ekraný";
                        frm.MyFoy = this.MyFoy;
                        frm.MyGelisme = myGelisme;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Show(tebligat);
                    }
                }

                else
                {
                    DialogResult dr =
                        XtraMessageBox.Show(
                            CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " +
                            " isimli tarafa baðlý 103 kayýtlarýný açmak istiyor musunuz ?", "103 Formunu Aç",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (dr == DialogResult.OK)
                    {
                        rFrmTebligat frm = new rFrmTebligat();
                        frm.Text = "103 Kayýt Ekraný";
                        frm.TFormTipi = rFrmTebligat.TebligatFormTipi.YuzucFormu;
                        frm.MyFoy = this.MyFoy;
                        frm.MyGelisme = myGelisme;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Show(tebligat);
                    }
                }

                #endregion YuzucFormu
            }
        }

        private void ucIcraTarafGelismeleri_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded)
            {
                InitializeComponent();
                IsLoaded = true;
                this.vgGelismeler.DoubleClick += vgGelismeler_DoubleClick;
                dnGelisme.PositionChanged += dnGelisme_PositionChanged;
                dnGelisme.ButtonClick += dnGelisme_ButtonClick;
            }
            if (MyFoy != null)
            {
                if (myGelisme == null)
                    myGelisme = GelismeBul(MyFoy);

                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_ODEME>), typeof(TList<AV001_TI_BIL_SATIS_MASTER>));
                TList<AV001_TI_BIL_FOY_TARAF_GELISME> result = Gelismeler;// GelismeleriGuncelle(MyFoy, myGelisme);
                result.Add(myGelisme);

                if (vgGelismeler.DataSource == null)
                    vgGelismeler.DataSource = result;

                AvukatPro.Services.Implementations.DevExpressService.AdliyeDoldur(lueAdliye);
                AvukatPro.Services.Implementations.DevExpressService.AdliyeNoDoldur(lueNo);
                AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueTaraf);
                lueAdliye.EditValue = MyFoy.ADLI_BIRIM_ADLIYE_ID;
                lueNo.EditValue = MyFoy.ADLI_BIRIM_NO_ID;
                txtEsasNo.EditValue = MyFoy.ESAS_NO;
                lueTaraf.EditValue = BorcluCariID;

                dnGelisme.DataSource = ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy);
                dnGelisme.Position = TarafIndexBul(MyFoy) - 1;

                RowFormat((FormTipleri)MyFoy.FORM_TIP_ID.Value);

                if (BelgeUtil.Inits.PaketAdi == 1)
                    catRowIhtHaciz.Visible = false;
                else
                    catRowIhtHaciz.Visible = true;

                //Gelismeler.Clear();
                //vgGelismeler.Refresh();
            }
        }

        #region Private Methods

        private frmFoyTaraf _frmFoyTaraf;

        private rFrmAlacakNedenTaraf frmNedenTaraf;

        public static AV001_TI_BIL_FOY_TARAF_GELISME GelismeBul(AV001_TI_BIL_FOY Foy)
        {
            if (Foy == null)
                return null;
            if (Foy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(Foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));
            TList<AV001_TI_BIL_FOY_TARAF_GELISME> result = null;

            //if (Foy.AV001_TI_BIL_FOY_TARAF_GELISMECollection.Count > 0)
            //{
            //  int icraTarafID=  = (int)Foy.AV001_TI_BIL_FOY_TARAF_GELISMECollection[0].ICRA_FOY_TARAF_ID;
            //    BorcluCariID =(int)Foy.AV001_TI_BIL_FOY_TARAFCollection.Find(t=>t.ID==icraTarafID).CARI_ID;
            //}
            int foyTarafIndex = TarafIndexBul(Foy);

            if (foyTarafIndex >= 0)
            {
                result =
                    DataRepository.AV001_TI_BIL_FOY_TARAF_GELISMEProvider.Find
                        (string.Format("ICRA_FOY_ID= {0} AND ICRA_FOY_TARAF_ID= {1}", Foy.ID,
                                       Foy.AV001_TI_BIL_FOY_TARAFCollection[foyTarafIndex].ID));
            }

            //result = DataRepository.AV001_TI_BIL_FOY_TARAF_GELISMEProvider.Find(string.Format("ICRA_FOY_ID= {0} AND ICRA_FOY_TARAF_ID= {1}", Foy.ID, BorcluCariID));

            if (result == null || result.Count == 0)
                return new AV001_TI_BIL_FOY_TARAF_GELISME();

            return result[0];
        }

        private void GorunumDegistir()
        {
            if (styleIndex == Styles.Length - 1)
                styleIndex = -1;
            styleIndex++;

            vgGelismeler.LookAndFeel.UseDefaultLookAndFeel = false;
        }

        private void Progress(AV001_TI_BIL_FOY_TARAF trf, string columnName)
        {
            string str = columnName;
            str = str.ToLower();
            str = str.Replace("_", " ")
                .Replace("ý", "i")
                .Replace("g", "ð");

            if (columnName != string.Empty)
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(vi => vi.CARI_ID == CurrBorcluId)/*[TarafIndexBul(MyFoy)]*/) + " " +
                        " isimli tarafa baðlý" + " " + str + " " +
                        "bulunmadýðýndan sistem sizin için otomatik olarak üretecektir.",
                        str + " " + "üretilecek.",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    trf[columnName] = DateTime.Today;
                }

                _frmFoyTaraf = new frmFoyTaraf();
                _frmFoyTaraf.MyGelisme = myGelisme;
                _frmFoyTaraf.MyFoy = this.MyFoy;
                _frmFoyTaraf.StartPosition = FormStartPosition.CenterScreen;
                _frmFoyTaraf.Show(trf, myGelisme);
            }

            else
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(vi => vi.CARI_ID == CurrBorcluId)/*[TarafIndexBul(MyFoy)]*/) + " " +
                        " isimli tarafa baðlý kayýtlarý açmak istiyor musunuz ?", "Taraf Formunu Aç",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    _frmFoyTaraf = new frmFoyTaraf();
                    _frmFoyTaraf.MyGelisme = myGelisme;
                    _frmFoyTaraf.MyFoy = this.MyFoy;
                    _frmFoyTaraf.StartPosition = FormStartPosition.CenterScreen;
                    _frmFoyTaraf.Show(trf, myGelisme);
                }
            }
        }

        private void Progress(AV001_TI_BIL_ALACAK_NEDEN_TARAF trf, string columnName)
        {
            string str = columnName;
            str = str.ToLower();
            str = str.Replace("_", " ")
                .Replace("ý", "i")
                .Replace("g", "ð");

            if (columnName != string.Empty)
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " +
                        " isimli tarafa baðlý" + " " + str + " " +
                        "bulunmadýðýndan sistem sizin için otomatik olarak üretecektir.", "Otomatik Kayýt Üretimi",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    trf[columnName] = DateTime.Today;

                    frmNedenTaraf = new rFrmAlacakNedenTaraf();
                    frmNedenTaraf.MyGelisme = myGelisme;
                    frmNedenTaraf.MyFoy = this.MyFoy;
                    frmNedenTaraf.StartPosition = FormStartPosition.CenterScreen;
                    frmNedenTaraf.Show(trf);
                }
            }
            else
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        CurrTarafAdi(MyFoy.AV001_TI_BIL_FOY_TARAFCollection[TarafIndexBul(MyFoy)]) + " " +
                        " isimli tarafa baðlý kayýtlarý açmak istiyor musunuz ?", "Taraf Formunu Aç",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    frmNedenTaraf = new rFrmAlacakNedenTaraf();
                    frmNedenTaraf.MyGelisme = myGelisme;
                    frmNedenTaraf.MyFoy = this.MyFoy;
                    frmNedenTaraf.StartPosition = FormStartPosition.CenterScreen;
                    frmNedenTaraf.Show(trf);
                }
            }
        }

        private void TarafFormuAc(AV001_TI_BIL_FOY_TARAFColumn tarafColumn, AV001_TI_BIL_FOY foy)
        {
            AV001_TI_BIL_FOY_TARAF trf = new AV001_TI_BIL_FOY_TARAF();

            trf = foy.AV001_TI_BIL_FOY_TARAFCollection.Find(AV001_TI_BIL_FOY_TARAFColumn.CARI_ID, CurrBorcluId);

            if (tarafColumn == AV001_TI_BIL_FOY_TARAFColumn.ACIZ_TARIHI)
            {
                if (trf.ACIZ_TARIHI.HasValue)
                    Progress(trf, string.Empty);
                else
                    Progress(trf, "ACIZ_TARIHI");
            }
            else if (tarafColumn == AV001_TI_BIL_FOY_TARAFColumn.IBRA_TARIHI)
            {
                if (trf.IBRA_TARIHI.HasValue)
                    Progress(trf, string.Empty);
                else
                    Progress(trf, "IBRA_TARIHI");
            }
            else if (tarafColumn == AV001_TI_BIL_FOY_TARAFColumn.GECICI_REHIN_ACIGI_TARIHI)
            {
                if (trf.GECICI_REHIN_ACIGI_TARIHI.HasValue)
                    Progress(trf, string.Empty);
                else
                    Progress(trf, "GECICI_REHIN_ACIGI_TARIHI");
            }

            else if (tarafColumn == AV001_TI_BIL_FOY_TARAFColumn.KESIN_REHIN_ACIGI_TARIHI)
            {
                if (trf.KESIN_REHIN_ACIGI_TARIHI.HasValue)
                    Progress(trf, string.Empty);
                else
                    Progress(trf, "KESIN_REHIN_ACIGI_TARIHI");
            }
        }

        private void TarafFormuAc(AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn tarafColumn, AV001_TI_BIL_FOY foy)
        {
            AV001_TI_BIL_ALACAK_NEDEN_TARAF trf = new AV001_TI_BIL_ALACAK_NEDEN_TARAF();

            trf = NedenTarafBul(foy);

            if (tarafColumn == AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn.IHTAR_TARIHI && !trf.IHTAR_TARIHI.HasValue)
            {
                trf.IHTAR_TARIHI = DateTime.Today;

                Progress(trf, "IHTAR_TARIHI");
            }

            else if (tarafColumn == AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn.ZAMAN_ASIMI_TARIHI &&
                     !trf.ZAMAN_ASIMI_TARIHI.HasValue)
            {
                trf.ZAMAN_ASIMI_TARIHI = DateTime.Today;

                Progress(trf, "ZAMAN_ASIMI_TARIHI");
            }

            else if (tarafColumn == AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn.IHTAR_TEBLIG_TARIHI &&
                     !trf.IHTAR_TEBLIG_TARIHI.HasValue)
            {
                trf.IHTAR_TEBLIG_TARIHI = DateTime.Today;

                Progress(trf, "IHTAR_TEBLIG_TARIHI");
            }

            else if (tarafColumn == AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn.TEMERRUT_TARIHI &&
                     !trf.TEMERRUT_TARIHI.HasValue)
            {
                trf.TEMERRUT_TARIHI = DateTime.Today;

                Progress(trf, "TEMERRUT_TARIHI");
            }

            else
                Progress(trf, string.Empty);
        }

        #endregion Private Methods

        //public void OdemeRowFormatla(decimal _odemeMiktari)
        //{
        //    if (_odemeMiktari > 0)
        //    {
        //        BelgeUtil.Inits.ParaBicimiAyarla(tutar);
        //        mRowSonOdemeT.PropertiesCollection[1].RowEdit = tutar;
        //    }
        //    else
        //        mRowSonOdemeT.PropertiesCollection[1].RowEdit = txtEtiket;
        //}

        #region Kaydetme Ýþlemi

        public static bool GelismleriKaydet(TransactionManager tran, AV001_TI_BIL_FOY_TARAF_GELISME gelisme, AV001_TI_BIL_FOY MyFoy, bool transactionKapat)
        {
            bool result = true;
            int i = TarafIndexBul(MyFoy);

            try
            {
                if (!tran.IsOpen)
                    tran.BeginTransaction();

                DataRepository.AV001_TI_BIL_FOYProvider.Save(tran, MyFoy);
                DataRepository.AV001_TI_BIL_FOY_TARAFProvider.Save(tran, MyFoy.AV001_TI_BIL_FOY_TARAFCollection);

                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(tran, MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));

                DataRepository.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFProvider.Save(tran, MyFoy.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection);

                DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFProvider.Save(tran, MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection);

                DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(tran, MyFoy.AV001_TDI_BIL_TEBLIGATCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>));

                DataRepository.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENProvider.DeepSave(tran, MyFoy.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection);

                DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.Save(tran, MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection);

                DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.DeepSave(tran, MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.FindAll(m => m.ICRA_FOY_ID > 0));

                DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.DeepSave(tran, MyFoy.AV001_TI_BIL_SATIS_MASTERCollection);

                DataRepository.AV001_TI_BIL_MAL_BEYANIProvider.Save(tran, MyFoy.AV001_TI_BIL_MAL_BEYANICollection);

                DataRepository.AV001_TI_BIL_MEHILProvider.Save(tran, MyFoy.AV001_TI_BIL_MEHILCollection);

                //if(gelisme ==null) return
                gelisme.ICRA_FOY_ID = MyFoy.ID;
                gelisme.ICRA_FOY_TARAF_ID = MyFoy.AV001_TI_BIL_FOY_TARAFCollection[i].ID;
                var eskiler = DataRepository.AV001_TI_BIL_FOY_TARAF_GELISMEProvider.GetByICRA_FOY_TARAF_ID(tran, gelisme.ICRA_FOY_TARAF_ID);

                foreach (var item in eskiler)
                {
                    if (item.ID != gelisme.ID)
                        DataRepository.AV001_TI_BIL_FOY_TARAF_GELISMEProvider.Delete(tran, item);
                }

                DataRepository.AV001_TI_BIL_FOY_TARAF_GELISMEProvider.Save(tran, gelisme);

                if (transactionKapat)
                    tran.Commit();
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(typeof(ucIcraTarafGelismeleri), ex);

                result = false;
            }

            return result;
        }

        #endregion Kaydetme Ýþlemi

        private void vgGelismeler_DoubleClick(object sender, EventArgs e)
        {
            VGridControl vg = sender as VGridControl;
            AV001_TI_BIL_FOY_TARAF_GELISME gelisme = GelismeBul(MyFoy);
            if (vg.FocusedRow.Tag == null) return;

            GelismeColumns row = (GelismeColumns)vg.FocusedRow.Tag;
            switch (row)
            {
                case GelismeColumns.ACIZ_TARIHI:
                    TarafFormuAc(AV001_TI_BIL_FOY_TARAFColumn.ACIZ_TARIHI, MyFoy);
                    break;

                case GelismeColumns.IBRA_TARIHI:
                    TarafFormuAc(AV001_TI_BIL_FOY_TARAFColumn.IBRA_TARIHI, MyFoy);
                    break;

                case GelismeColumns.GECICI_REHIN_TARIHI:
                    if (gelisme.SON_ITIRAZ_TARIHI.HasValue)
                        TarafFormuAc(AV001_TI_BIL_FOY_TARAFColumn.GECICI_REHIN_ACIGI_TARIHI, MyFoy);
                    else
                        XtraMessageBox.Show("Geçici Rehin Açýðý Tarihi girebilmeniz için önce Rehin Kaydý girmelisiniz!");
                    break;

                case GelismeColumns.KESIN_REHIN_TARIHI:
                    if (gelisme.SON_ITIRAZ_TARIHI.HasValue)
                        TarafFormuAc(AV001_TI_BIL_FOY_TARAFColumn.KESIN_REHIN_ACIGI_TARIHI, MyFoy);
                    else
                        XtraMessageBox.Show("Kesin Rehin Açýðý Tarihi girebilmeniz için önce Rehin Kaydý girmelisiniz!");
                    break;

                case GelismeColumns.ZAMAN_ASIMI_TARIHI:
                    TarafFormuAc(AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn.ZAMAN_ASIMI_TARIHI, MyFoy);
                    break;

                case GelismeColumns.EK_MEHIL_TARIHI:
                    if (gelisme.MEHIL_TARIHI.HasValue)
                        MehilFormuAc();
                    else XtraMessageBox.Show("Ek Mehil Tarihi girebilmeniz için önce Mehil Tarihi girmelisiniz!");
                    break;

                case GelismeColumns.MEHIL_TARIHI:
                    if (gelisme.ILK_TEBLIGAT_TARIHI.HasValue)
                        MehilFormuAc();
                    else XtraMessageBox.Show("Mehil Tarihi girebilmeniz için önce Tebligat Tarihi girmelisiniz!");
                    break;

                case GelismeColumns.BILA_TARIHI:
                case GelismeColumns.ZABITACA_YENI_ADRES_BULUNDUGU_TARIHI:
                case GelismeColumns.ZABITA_ARASTIRMA_OLUMSUZ_TARIHI:
                case GelismeColumns.ZABITA_ARASTIRMA_TARIHI:
                case GelismeColumns.SUBEDEN_OLUMSUZ_CEVAP_TARIHI:
                case GelismeColumns.SUBEDEN_YENI_ADRES_BILDIRILDIGI_TARIH:
                case GelismeColumns.SUBEDEN_YENI_ADRES_ISTEME_TARIHI:
                case GelismeColumns.ILK_TEBLIGAT_TARIHI:
                    TebligatFormuAc(false);
                    break;

                case GelismeColumns.IHTAR_TEBLIG_TARIHI:
                    TarafFormuAc(AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn.IHTAR_TEBLIG_TARIHI, MyFoy);
                    break;

                case GelismeColumns.IHTAR_TARIHI:
                    TarafFormuAc(AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn.IHTAR_TARIHI, MyFoy);
                    break;

                case GelismeColumns.TEMERRUT_TARIHI:
                    TarafFormuAc(AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn.TEMERRUT_TARIHI, MyFoy);
                    break;

                case GelismeColumns.IHTIYATI_HACIZ_TALEP_TARIHI:
                    IhtiyatiHacizFormuAc();
                    break;

                case GelismeColumns.IHTIYATI_HACIZ_UYGULAMA_TARIHI:
                    if (gelisme.IHTIYATI_HACIZ_TALEP_TARIHI.HasValue)
                        HacizFormuAc(HacizKaynak.Ýhtiyati_Haciz);
                    else
                        XtraMessageBox.Show("Uygulama Tarihi girebilmeniz için önce Ýhtiyati Haciz Kaydý girmelisiniz!");
                    break;

                case GelismeColumns.IHTIYATI_TEDBIR_UYGULAMA_TARIHI:
                    if (gelisme.IHTIYATI_TEDBIR_TALEP_TARIHI.HasValue)
                        IhtiyatiTedbirFormuAc();
                    else
                        XtraMessageBox.Show("Uygulama Tarihi girebilmeniz için önce Ýhtiyati Tedbir Kaydý girmelisiniz!");
                    break;

                case GelismeColumns.IHTIYATI_TEDBIR_TALEP_TARIHI:
                    IhtiyatiTedbirFormuAc();
                    break;

                case GelismeColumns.ITIRAZIN_KALDIRILMASI_DAVA_TARIHI:
                    ItirazDavasýAc(myGelisme);
                    break;

                case GelismeColumns.ITIRAZ_KALDIRILMA_IHTAR_TARIHI:
                    if (gelisme.ITIRAZ_TARIHI.HasValue)
                        ItirazFormuAc();
                    else
                        XtraMessageBox.Show("Ýtirazýn Kaldýrýlmasý Tarihi girebilmeniz için önce Ýtiraz Tarihi girmelisiniz!");
                    break;

                case GelismeColumns.ITIRAZDAN_VAZGECME_TARIHI:
                    if (gelisme.ITIRAZ_TARIHI.HasValue)
                        ItirazFormuAc();
                    else
                        XtraMessageBox.Show("Ýtirazdan vazgeçebilmeniz için önce Ýtiraz Tarihi girmelisiniz!");
                    break;

                case GelismeColumns.ITIRAZ_TARIHI:
                    if (gelisme.ILK_TEBLIGAT_TARIHI.HasValue)
                        ItirazFormuAc();
                    else
                        XtraMessageBox.Show("Ýtiraz girebilmeniz için önce Tebligat Tarihi girmelisiniz!");
                    break;

                case GelismeColumns.MAL_BEYANI_DAVA_TARIHI:
                    MalBeyaniDavasýAc(myGelisme);
                    break;

                case GelismeColumns.MAL_BEYANI_TARIHI:
                    if (gelisme.ILK_TEBLIGAT_TARIHI.HasValue)
                        MalBeyaniFormuAc();
                    else
                        XtraMessageBox.Show("Mal Beyaný girebilmeniz için önce Tebligat Tarihi girmelisiniz!");
                    break;

                case GelismeColumns.SATIS_TARIHI:
                    if (gelisme.SON_HACIZ_TARIHI.HasValue)
                        SatisFormuAc();
                    else
                        XtraMessageBox.Show("Satýþ Tarihi girebilmeniz için önce Haciz Kaydý girmelisiniz!");
                    break;

                case GelismeColumns.SON_HACIZ_TARIHI:
                    if (gelisme.ILK_TEBLIGAT_TARIHI.HasValue)
                        HacizFormuAc(HacizKaynak.Normal_Haciz);
                    else
                        XtraMessageBox.Show("Son Haciz Tarihi girebilmeniz için önce Tebligat Kaydý girmelisiniz!");
                    break;

                case GelismeColumns.SON_ODEME_TARIHI:
                    OdemeFormuAc();
                    break;

                case GelismeColumns.TAAHHUTU_IHLAL_DAVA_TARIHI:
                    IhlalDavasýAc(myGelisme);
                    break;

                case GelismeColumns.TAAHHUT_TARIHI:
                    if (gelisme.ILK_TEBLIGAT_TARIHI.HasValue)
                        TaahhutFormuAc();
                    else
                        XtraMessageBox.Show("Taahhüt Kaydý girebilmeniz için önce Tebligat Kaydý girmelisiniz!");
                    break;

                case GelismeColumns.YUZUC_TARIHI:
                    if (gelisme.SON_HACIZ_TARIHI.HasValue)
                        TebligatFormuAc(true);
                    else
                        XtraMessageBox.Show("103 Tarihi girebilmeniz için önce Haciz Kaydý girmelisiniz!");
                    break;

                case GelismeColumns.ESAS_TAKIP_TARIHI:
                    if (gelisme.IHTIYATI_HACIZ_TALEP_TARIHI.HasValue)
                        HacizFormuAc(HacizKaynak.Ýhtiyati_Haciz);
                    else
                        XtraMessageBox.Show("Esas takip tarihi girebilmeniz için önce Ýhtiyati Haciz Kaydý girmelisiniz!");
                    break;
                default:
                    break;
            }
        }
    }
}