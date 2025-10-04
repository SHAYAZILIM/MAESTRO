using System;

namespace AvukatProLib.Extras
{
    public enum AdliBirimBolumGorev
    {
        UYM = 59,
        HD = 1,
        AGCM = 2,
        ATM = 3,
        BIM = 4,
        COM = 5,
        DGM = 6,
        TAM = 7,
        SCM = 8,
        SHM = 9,
        SOR = 10,
        TRM = 11,
        TUKM = 12,
        IDM = 14,
        IHUM = 15,
        ISM = 16,
        VERM = 17,
        ICRM = 18,
        AHM = 20,
        ACM = 21,
        ASCM = 22,
        KDM = 23,
        FSHM = 24,
        FSCM = 25,
        DAN = 26,
        ICM = 13,
        IFMD = 28,
        NOT = 31,
        BARO = 32,
        BUYE = 33,
        KONS = 34,
        CD = 36,
        YCGK = 37,
        YHGK = 38,
        AILM = 39,
        YIBBGK = 40,
        BKNS = 42,
        SVC = 43,
        BSVC = 44,
        YARG = 45,
        AYIM = 46,
        BHKB = 47,
        AIDM = 35,
        TSM = 48,
        DIM = 49,
        DA = 50,
        HKM = 51,
        YBSCV = 52
    }

    public enum AdliBirimBolumKod
    {
        C = 1,
        H = 2,
        I = 3,
        IF = 4,
        O = 8,
        OI = 83,
        N = 9,
        ID = 5,
        AC = 6,
        V = 7,
        CI = 13,
        HI = 23,
        IIF = 34,
        AID = 35,
        AYID = 36,
        SAV = 10
    }

    /// <summary>
    /// TDI_KOD_ARAC_TIP tablosundan turetilmistir.
    /// </summary>
    public enum AracTipi
    {
        OTOBUS = 1,
        KAMYON = 2,
        MINIBUS = 3,
        MIDIBUS = 4,
        KAMYONET = 5,
        DIGER = 6,
        UCAK = 7,
        GEMI = 8,
        ARAC = 9,

        //Edit [ZK] ID kucultme
        //ARAC = 10003,
        //GEMI = 10002,
        //UCAK = 10001,
    }

    public enum AraKararTip
    {
        Kesin_Mehilli = 2,
        Mehilli = 1,
        Mehilsiz = 0
    }

    public enum AramaKosulu
    {
        Taraf,
        RafNo,
        EsasNo
    }

    public enum CariAktifAdres
    {
        Birinci_Adres = 1,
        İkinci_Adres = 2
    }

    public enum CariStatu
    {
        Avukat,
        Müvekkil,
        Karşı_Taraf,
        Personel,
        Kurum_Avukatı,
        Avukat_Ortaklığı,
        Bilirkişi,
        Adli_Birim,
        Adli_Personel,
        Harçdan_Muaf,
        Yetkili
    }

    public enum CariStatuEX
    {
        Avukat = 4,
        Müvekkil = 1,
        Karşı_Taraf = 3,
        Personel = 2,
        Kurum_Avukatı = 4,
        Avukat_Ortaklığı = 2,
        Bilirkişi = 2,
        Adli_Birim = 2,
        Adli_Personel = 2,
        Harçdan_Muaf = 2,
        Yetkili = 2
    }

    public enum CariTipi
    {
        Gerçek = 0,
        Tüzel = 1
    }

    public enum CETTABLOADI
    {
        //TD_CET_CMUK_HAZIRLIK_VEKALET_MAKTU
        // SoruşturmaVekaletMaktu,
        // TD_CET_CMUK_VEKALET_MAKTU
        // VekaletMaktu,
        //TD_CET_GOREVLI_MAHKEME_BELIRLE
        Gorevli_Mahkeme,

        //TD_CET_HARC_MAKTU
        Dava_Harc_Maktu,

        //TD_CET_NISPI_HARC
        Dava_Nispi_Harc,

        // TDI_CET_DIGER_VERGI
        Diger_Vergi,

        //TDI_CET_EVRAK_GIDER
        Evrak_Gider,

        //TDI_CET_FAIZ_TARIFE
        CetFaiz_Tarife,

        //TDI_CET_GELIR_VERGISI
        Gelir_Vergisi,

        // TDI_CET_GUNLUK_DOVIZ_KUR
        Gunluk_Doviz_Kur,

        // TDI_CET_KDV
        Kdv,

        //TDI_CET_MAKTU_VEKALET
        Maktu_Vekalet,

        //TDI_CET_MEMUR_YEVMIYE
        Memur_Yevmiye,

        //TDI_CET_MIN_MAX_DEGER
        MinMax_Degeri,

        //TDI_CET_POLICE_TEMINAT_TUTAR
        Police_Teminat_Tutar,

        //TDI_CET_POSTA_GIDER
        Posta_Gider,

        // TDI_CET_TEMINAT_TAZMINAT
        Teminat_Tazminat,

        //TDI_CET_VEKALET_NISPI
        Vekalet_Nispi,

        // TDI_CET_YEDIEMIN_MAKTU_UCRET
        Yediemin_Maktu_Ucret,

        // TDI_CET_YEDIEMIN_NISPI_UCRET
        Yediemin_Nispi_Ucret,

        // TDI_CET_YUVARLAMA_DEGER
        Yuvarlama_Deger,

        //TDIE_CET_MERKEZ_DOSYA_ATAMA_DEGER
        Merkez_Dosya_Atama,

        //TI_CET_HARC_MAKTU
        Icra_Harc_Maktu,

        //TI_CET_NISPI_HARC
        Icra_Nispi_Harc,

        //TI_CET_VERGI_ORAN
        Icra_Vergi_Oran,
    }

    public enum CevapSuresi
    {
        //--select * from dbo.TDI_BIL_SURE where SURE_ADI like'%Cevap%'--//
        //--sorgusundan dönen sonuçlar üzerinden enum--//

        Davalinin_Cevap_Muddeti = 846,
        Duplik_Cevap_Muddeti = 1025,
        Replik_Cevap_Muddeti = 1026,
    }

    /// <summary>
    /// VDI_KOD_DAVA_ADI_KISITLI viewinden oluşturulmuştur.
    /// </summary>
    public enum DavaAdi : int
    {
        UCUNCU_SAHIS_TARAFINDAN_ILERI_SURULEN_ISTIHKAK = 12,
        TASINMAZ_IHALESININ_FESHI = 112,
        KIYMET_TAKDİRİNE_İTİRAZ = 1269,
        CEKI_KARSILIKSIZ_OLARAK_KESIDE_ETMEK = 1147,
        ICRA_TAKIBINE_ITIRAZIN_IPTALI = 1150,
        İFLASIN_HİLELİ_OLARAK_YAPILMASI = 2928,
        MAL_BEYANINDA_BULUNMAMA = 1160,
        İSTİHKAK = 3275,
        HİZMET_SEBEBİYLE_EMNİYETİ_SUİSTİMAL = 1132,
        TAHLİYESİ_EMROLUNAN_YERİ_KİRALAYANA_ZARAR_VERMEK_MAKSADI_İLE_İŞGAL_ETTİRMEK = 4983,
        NAFAKA_ŞARTINI_İHLAL = 5743,
        IFLAS = 57,
        OLUMSUZ_TESPİT = 14,
        IHTIYATI_TEDBIR = 1190,
        SENETTE_TAHRİFAT = 148,
        TEBLIGATIN_IPTALI = 1194,
        IHTIYATI_HACIZ = 1196,
        TAHLIYE = 1201,
        İSTİRDAT = 8049,
        ICRANIN_GERI_BIRAKILMASI_TAKIBIN_TALIKI = 1207,
        MEMURUN_ISLEMINI_SIKAYET = 1267,
        ITIRAZIN_GECICI_OLARAK_KALDIRILMASI = 1274,
        ALACAKLININ_ISTIHKAK_DAVASI = 1281,
        BORCA_ITIRAZ = 1287,
        IMZAYA_ITIRAZ_KOMBIYODA = 1288,
        İMZAYA_İTİRAZ = 1158,
        ITIRAZIN_KESIN_OLARAK_KALDIRILMASI = 1300,
        ITFA_SEBEBI_ILE_ICRANIN_GERI_BIRAKILMASI = 1303,
        ICRA_TAKIBINDEN_SONRA_ACILAN_MENFI_TESBIT = 1306,
        KENDI_EYLEMI_ILE_ACZINE_SEBEP_OLMAK_VEYA_DURUMUNU_BILEREK_AGIRLASTIRMAK = 1315,
        ALACAKLISINI_ZARARA_UGRATMAK_KASTI_ILE_MAL_VARLIGINI_EKSILTEN_ISLEM_YAPMAK = 1317,
        ADRES_DEGISIKLIGINI_BILDIRMEME = 1327,
        BIR_ISIN_YAPILMASINA_DAIR_ILAMA_AYKIRI_DAVRANMA = 1331,
        ALACAKLIYA_ICRA_DAIRESINCE_TESLIM_EDILEN_GAYRIMENKUL_VEYA_GEMIYE_TEKRAR_GIRMEK = 1464,
        COCUGUN_TESLIMI_ILE_ILGILI_ILAMIN_ICRASI_SIRASINDA_COCUGU_GIZLEMEKILAMIN_ICRASINDAN_SONRA_COCUGU_TEKRAR_KACIRMAK = 1978,
        GERCEGE_AYKIRI_MAL_BEYANINDA_BULUNMAK = 2568,
        ICRA_DAIRESINDE_KARARLASTIRILAN_BORCUN_ODEME_SARTINI_IHLAL_ETMEK = 2909,
        ILAN_HUKMUNE_AYKIRI_DAVRANMAK = 2966,
        IRTIFAK_HAKKININ_KURULMASI_VEYA_KALDIRILMASINA_ILISKIN_ILAM_HUKMUNE_AYKIRI_DAVRANMAK = 2996,
        KAZANCINDA_MAL_BEYANINDAN_SONRA_MEYDANA_GELEN_ARTISI_BILDIRMEMEK = 3543,
        NAFAKA_BORCUNU_ODEMEMEK = 4021,
        ICRA_TAKIBININ_IPTALI = 5642,
        BORCTAN_KURTULMA = 5644,
        IHALENIN_FESHI = 5652,
        ODEME_EMRI_IPTALI = 5664,
        ODEME_EMRINE_ITIRAZ = 5668,
        IPOTEGIN_TETKIK_MERCIINDE_KALDIRILMASI_FEKKI_ = 5825,
        ICRA_EMRINE_ITIRAZ = 5852,
        MESKENIYET_IDDIASI = 5855,
        MEMURA_HAKARET = 157,
        MEMURU_DOVMEK_YARALAMAK = 3864,
        DURUSMADA_HAKARET_VE_SOVME = 193,
        MUESSIR_FIILDE_BULUNMAK = 3979,
        IIK_269_A_GEREGI_TAHLIYE = 5894,
        ITIRAZIN_KALDIRILMASI_VE_TAHLIYE = 5895,
        HAKSIZ_IHTIYATI_HACIZDEN_KAYNAKLANAN_MADDI_TAZMINAT = 5959,
        GECIKMIS_ITIRAZ = 5992,
        YETKI_ITIRAZI = 5993,
        KUR_FARKINDA_DOGAN_ODEME_EMRININ_IPTALI = 6254,
        IHTIYATI_HACZIN_IPTALI = 6262,
        HACIZ_ISLEMININ_IPTALI = 6264,
        TICARI_ISLETME_YONETICISININ_BORCLARINI_ODEMEMESI = 6283,
        TAKIBIN_TALIKI = 8117,
        TASARRUFUN_IPTALI = 5928,
        YEDDI_EMINLIGI_SUISTIMAL = 1387
    }

    public enum DavaNispiHarcTipi
    {
        GENEL = 1,
        NAFAKA = 2,
        ORTAKLIGIN_GiDERiLMESi_SATIS = 3,
        ORTAKLIGIN_GiDERiLMESi_TAKSiM = 4,
        CELSE_HARCI = 5
    }

    public enum DavaSureTipi
    {
        ZamanAsimi = 1,
        HakDusumu = 2,
        Temyiz = 3,
        Itiraz = 4,
        Duzeltme = 5,
        Ihtar = 6,
        Ihbar = 7,
        Basvurma = 9,
        Iade = 10,
        Bekleme = 11,
        Cevap = 12,
        CevabaCevap = 13,
        BildirimdeBulunma = 14,
        AtamaSuresi = 15,
        CaymaHakkiniKullanma = 16,
        CezaCekme = 17,
        CezaUygulamaSuresi = 18,
        CekilmeSuresi = 19,
        DavaAcmaSuresi = 20,
        Davet = 21,
        DosyaSaklama = 22,
        Duplik = 23,
        Duyuru = 24,
        Egitim = 25,
        Erteleme = 26,
        EskiHaleGetirme = 27,
        Fesih = 28,
        GeriBirakma = 29,
        GörevSuresi = 30,
        Gozalt = 31,
        Gözetim = 32,
        Haciz = 33,
        HakiminReddi = 34,
        Havale = 35,
        IcraninGeriBirakilmasi = 36,
        Iktisap = 37,
        Ilan = 38,
        Inceleme = 39,
        Iptal = 40,
        Isletme = 41,
        Izin = 42,
        Kabul = 43,
        Karar = 44,
        KararDuzeltme = 45,
        KararaUyma = 46,
        Kayit = 47,
        Mahsup = 48,
        Muaflik = 49,
        Musahade = 50,
        Onay = 51,
        Odeme = 52,
        Red = 53,
        Replik = 54,
        Saklama = 55,
        Satis = 56,
        Savunma = 57,
        Sorgu = 58,
        Sorusturma = 59,
        SartliErteleme = 60,
        Sikayet = 61,
        Taahhut = 62,
        Tahakkuk = 63,
        Tahliye = 64,
        Tahsilat = 65,
        TakibeGecme = 66,
        TarhZamani = 67,
        Tasdik = 68,
        Teblig = 69,
        Tefhim = 70,
        Terkin = 71,
        Tescil = 72,
        Teslim = 73,
        ToplantiyaCagirma = 74,
        YakalamaveTutuklama = 75,
        YargilamaninIadesi = 76,
        YerineGetirme = 77,
        ZamanAsimiÖgrenme = 78,
        SikayetOgrenme = 79,
        HakDusumuOgrenme = 80
    }

    [Serializable]
    public enum DavaTarafKodu
    {
        Davacı = 1,
        Davalı = 3
    }

    /// <summary>
    /// Adli Birim Bölüm (TDI_KOD_ADLI_BIRIM_BOLUM) tablosundan gelmektedir.
    /// </summary>
    public enum DavaTipi
    {
        CEZA = 1,
        HUKUK = 2,
        ICRA = 3,
        IFLAS = 4,
        ORTAK = 8,
        ORTAK_ICRA = 83,
        NOTER = 9,
        IDARE = 5,
        ASKERI_CEZA = 6,
        VERGI = 7,
        ICRA_CEZA = 13,
        ICRA_HUKUK = 23,
        ICRA_IFLAS = 34,
        ASKERI_IDARI = 35,
        ASKERI_YUKSEK_ID = 36,
        SAVCILIK = 10,
    }

    public enum DigerVergiTuru
    {
        STOPAJ = 1,
        SSDF = 2,
        BSMV = 3,
        KKDF = 4,
        ÖİV = 5
    }

    public enum DosyaTip
    {
        Hazırlık = 1,
        DahiliDosya = 2,
        HariciDosya = 3
    }

    public enum DurumAciklama
    {
        YEMEK_ARASI = 0,
        TOPLANTI = 1,
        DINLENME = 2,
        TELEFONLA_GORUSME = 3,
        OZEL_DURUM = 4,
        DIGER = 5,
    }

    public enum EkspressIslemler
    {
        Belge_B,
        Tebligat_Z,
        Masraf_M,
        Not_N,
        Toplantı_T,
        Duruşma_J,
        AraKarar_A,
        Keşif_İnceleme_K,
        Haciz_H,
        Satış_S,
        Ödeme_O,
        Müvekkile_Ödeme_D,
        İş_I,
        Görüşme_F,
        Vekalet_V
    }

    public enum FaizKalem
    {
        ASIL_ALACAK = 1,
        PROTESTO_GİDERİ = 2,
        İHTAR_GİDERİ = 3,
        ÖZEL_TAZMİNAT = 4,
        ÇEK_TAZMİNATI = 5,
        İNKAR_TAZMİNATI = 6,
        YARGILAMA_GİDERLERİ = 7,
        İLAM_VEKALET_ÜCRETİ = 8,
        İLAM_TEBLİĞ_GİDERLERİ = 9,
        İHTİYATİ_HACİZ_VEK_ÜCRETİ = 10,
        ÖZEL_TUTAR_1 = 11,
        ÖZEL_TUTAR_2 = 12,
        ÖZEL_TUTAR_3 = 13,
        İPOTEK_SÖZLEŞMESİ_FAİZİ = 16,
        BAKİYE_KARAR_HARCI = 14,
        YARGITAY_ONAMA_HARCI = 15,
        REHİN_SÖZLEŞMESİ_FAİZİ = 17,
        TALEP_DİĞER_GİDERLER = 18,
        DAVA_DEĞERİ = 19,
        D_TAZMİNAT = 20
    }

    public enum FaizTip
    {
        Yasal_Faiz = 1,
        Reeskont_Avans = 2,
        TR_Libor = 3,
        En_Yüksek_Mevduat_Faizi = 5,
        Libor = 6,
        İşletme_Kredi_Faizi = 7,
        Özel_Sabit_Faiz = 9,
        Kullanıcı_Tanımlı_Faiz = 10,
        TEFE = 11,
        TÜFE = 12,
        Kanuni_Temerrüt_Faizi = 13,
        _6183_Tecil_Faizi = 14,
        Reeskont_İskonto = 15,
        Yasal_Faiz_2 = 16,
        Ticari_Temerrüt_Faizi = 17,
        _6183_Gecikme_Faizi = 18,
        Temmerut_Faiz = 9,
    }

    public enum FeragatKapsami
    {
        Föy_Geneline_İlişkin = 1,
        Alacak_Nedenine_İlişkin
    }

    public enum FeragatTipi
    {
        Son_Toplam_Üzerinden = 1,
        Alacak_Kalemlerinden = 0
    }

    public enum FoyDurum
    {
        EVRAK = 1,
        FAAL = 2,
        ACİZ = 3,
        DÜŞME = 4,
        FERAGAT = 5,
        İNFAZ = 6,
        ARŞİV = 7,
        KARAR = 8,
        TEMYİZ = 9,
        İADE = 10,
        AÇILACAK = 11,
        KAPATILACAK = 12,
        İDARİ_İŞLER = 14,
        TERKİN = 15,
        KISMİ_İNFAZ = 16,
        İNFAZ_ZAMAN_AŞIMI = 17,
        İNFAZ_REHİN_AÇIĞI = 18,
        İDARİ_TAKİP = 19,
        SULH = 20,
        SEMERESİZ = 21,
        İİDD = 22,
        KKK = 23,
        ACIZ_DERKENAR = 24,
        BONIFIKASYON = 25,
        KISMEN_TAHSILAT = 26,
        TAHSILAT = 27,
        INDIRIMLI_TAHSILAT = 28,
        DERKENAR = 29,
        KISMEN_ACIZ = 30,
        MAHKEME_KARARI_ILE_IPTAL = 31,
        TAKIPSIZ = 32,
        KREDISI_KAPANDI = 33,
        ITIRAZLI = 34,
        KAPATILDI = 35,
        DENEME = 10001
    }

    public enum GemiUcakAracTipi
    {
        SecimYapin = 0,
        Gemi = 1,
        Ucak = 2,
        Arac = 3
    }

    public enum GorusmeTipi
    {
        TELEFONLA_GÖRÜŞME = 493,
        BÜRODA_GÖRÜŞME = 494,
        KONFERAS_GÖRÜŞMESİ = 495,
        CEZAEVİNDE_GÖRÜŞME = 496,
        ADLİYEDE_GÖRÜŞME = 497,
        MÜVEKKİLİN_ADRESİNDE_GÖRÜŞME = 498,
        KARAKOLDA_GÖRÜŞME = 499,
        SAVCILIKTA_GÖRÜŞME = 500,
        HASTAHANEDE_GÖRÜŞME = 501
    }

    /// <summary>
    /// TI_KOD_MAL_CINS
    /// </summary>
    public enum HACIZLI_MAL_CINS
    {
        TAM_ARSA = 1,
        HİSSELİ_ARSA = 2,
        HİSSELİ_TARLA = 3,
        TAM_TARLA = 4,
        HİSSELİ_BINA = 5,
        TAM_BINA = 6,
        FABRİKA = 7,
        KAMYON = 8,
        OTOBÜS = 9,
        MİNÜBÜS = 10,
        MİDİBÜS = 11,
        KAMYONET = 12,
        DİĞER_BİNEK_VE_YÜK_VASITALARI = 13,
        TELEVİZYON = 14,
        RADYO = 15,
        ELEKTRİK_SÜRÜRGESİ = 16,
        ÜTÜ = 17,
        ÇAMAŞIR_MAKİNESİ = 18,
        BULAŞIK_MAKİNESİ = 19,
        ÇAMAŞIR_KURUTMA_MAKİNESİ = 20,
        SAÇ_KURUTMA_MAKİNESİ = 21,
        DİĞER_MUTFAK_ALETLERİ = 22,
        BİLGİSAYAR_PC = 23,
        BİLGİSAYAR_NOTE_BOOK = 24,
        BİLGİSAYAR_PALM = 25,
        CEP_TELEFONU = 26,
        MÜZİK_SETİ = 27,
        VCD_PLAYER = 28,
        VCD_RECORDER = 29,
        DVD_PLAYER = 30,
        DVD_RECORDER = 31,
        VİDEO = 32,
        KAMERA = 33,
        DİGİTAL_FOTOĞRAF_MAKİNESİ = 34,
        DİGER_GAYRİMENKUL = 35,
        DİGER_MENKUL = 36,
        DİGER_GELİR = 37,
        DİGER_ARAÇ = 38,
        ŞAHISDAKİ_HAK_VE_ALACAK_DİGER = 41,
        TELEFON = 42,
        KAMP_TİPİ_2_KG = 43,
        EV_TİPİ_12_KG = 44,
        TİCARİ_TİPİ_24_KG = 45,
        SANAYİ_TİPİ_45_KG = 47,
        FABRİKA_BİNASI = 48, //10002
        GEMİ = 49, //10003, //KB tabloda bu id de kalsın dedi
        UÇAK = 50, //10004 //KB tabloda bu id de kalsın dedi
    }

    public enum HACIZLI_MAL_KATEGORI
    {
        GAYRİMENKUL = 1,
        GELİR = 5,
        ARAÇ = 2,
        MENKUL = 7,
        ŞAHISTAKİ_HAK_VE_ALACAK = 6,
        GEMİ = 8,
        UÇAK = 9
    }

    public enum HACIZLI_MAL_TUR
    {
        ARSA = 2,
        TARLA = 3,
        BİNA = 4,
        BEYAZ_EŞYA = 8,
        MOBİLYA = 9,
        ELEKTRONİK_ALETLER = 10,
        GİYİM_EŞYASI = 11,
        ZİYNET = 12,
        SANAT_ESERİ = 13,
        BÜRO_MALZEMESİ = 14,
        MESLEK_ALETLERİ = 15,
        YAYIN = 16,
        SEBZE_MEYVE = 17,
        HAYVAN = 18,
        MAAŞ = 19,
        KAR_PAYI = 20,
        KİRA = 21,
        İŞ_MAKİNESİ = 22,
        TARIM_MAKİNESİ = 23,
        TAŞIMA_VASITASI = 24,
        ALACAKLAR = 26,
        TAZMİNATLAR = 27,
        DİĞER_GAYRİMENKUL = 28,
        DİĞER_MENKUL = 30,
        DİĞER_GELİR = 33,
        DİĞER_ARAÇ = 34,
        DİĞER_ŞAHISTAKİ_HAK_VE_ALACAK = 35,
        TÜPLÜ_GAZ = 36,
        ŞİLEP = 37,
        YOLCU_GEMİSİ = 38,
        TANKER = 39,
        DIGER_GEMI = 40,
        YOLCU_UÇAĞI = 41,
        HELIKOPTER = 42
    }

    public enum HacizliMalAdetBirim
    {
        KG = 1,
        GR = 2,
        BKR = 7,
        AD = 9,
        TON = 3,
        TNK = 4,
        ÇVL = 6,
        LT = 15
    }

    /// <summary>
    /// HACIZ_CHILD tablosuna tinyint bir alan eklendi TIP adında enumları aşağıdakilerdir.
    /// </summary>
    public enum HAZIZ_CHILD_TIP
    {
        Haciz_Edilmiş_Mal = 1,
        Rehin_Edilmiş_Mal = 2,
        Borçlunun_Beyan_Ettiği_Mal = 3,
        Araştırma_İle_Tespit_Edilmiş_Mal = 4
    }

    public enum HukumAdi
    {
        DAVANIN_REDDİ = 4,
        SULH = 6,
        VAZGEÇME = 7,
        DAVANIN_MAHKEMECE_KABULÜ = 8,
        DAVANIN_YENİLENMEMESİ_SEBEBİ_İLE_AÇILMAMIŞ_SAYILMASI = 9,
        YETKİSİZLİK = 10,
        GÖREVSİZLİK = 11,
        DAVANIN_AÇILMAMIŞ_SAYILMASI = 12,
        DAVANIN_KONUSUZ_KALMASI_SEBEBİ_İLE_KARAR_VERİLMESİNE_YER_OLMAMASI = 13,
        DERDESTLİK = 14,
        DAVANIN_DAVALI_TARAFINDAN_KABULÜ = 15,
        DAVANIN_BİR_BAŞKA_MAHKEMEYE_DEVRİ = 16,
        DAVANIN_MAHKEMECE_KISMEN_KABULÜ = 17,
        DAVA_ŞARTLARININ_EKSİK_OLMASI_NEDENİ_İLE_USULEN_RED = 18,
        DAVACININ_DAVALININ_MUVAFAKATI_İLE_DAVAYI_GERİ_ALMASI = 19,
        HAKİMİN_RED_İSTEMİNİ_KABULÜ = 20,
        GÖNDERME = 21,
        DÜŞME = 22,
        DURMA = 23,
        CEZA_KARAARNAMESİ = 24,
        MAHKUMİYET = 25,
        BERAAT = 26,
        TAZMİNAT_TALEBİNİN_KABULÜ = 27,
        TAZMİNAT_TALEBİNİN_REDDİ = 28,
        TAZMİNAT_TALEBİNİN_KISMEN_KABULÜ = 29,
        DAVA_DOSYASININ_CUMHURİYET_SAVCILIĞINA_GÖNDERİLMESİ = 30,
        DAVANIN_AYRILMASI = 31,
        DAVANIN_BİRLEŞTİRİLMESİ = 32,
        H_DAVA_ŞARTLARININ_EKSİK_OLMASI_NEDENİ_İLE_USULEN_RED = 33,
        H_DAVACININ_DAVALININ_MUVAFAKATI_İLE_DAVAYI_GERİ_ALMASI = 34,
        H_DAVANIN_AÇILMAMIŞ_SAYILMASI = 35,
        H_DAVANIN_BİR_BAŞKA_MAHKEMEYE_DEVRİ = 36,
        H_DAVANIN_DAVALI_TARAFINDAN_KABULÜ = 37,
        H_DAVANIN_KONUSUZ_KALMASI_SEBEBİ_İLE_KARAR_VERİLMESİNE_YER_OLMAMASI = 38,
        H_DAVANIN_MAHKEMECE_KABULÜ = 39,
        H_DAVANIN_MAHKEMECE_KISMEN_KABULÜ = 40,
        H_DAVANIN_YENİLENMEMESİ_SEBEBİ_İLE_AÇILMAMIŞ_SAYILMASI = 41,
        H_SULH = 42,
        H_VAZGEÇME = 43,
        O_DAVANIN_AYRILMASI = 44,
        O_DAVANIN_BİRLEŞTİRİLMESİ = 45,
        O_DAVANIN_REDDİ = 46,
        O_DERDESTLİK = 47,
        O_DÜŞME = 48,
        O_GÖNDERME = 49,
        O_GÖREVSİZLİK = 50,
        O_HAKİMİN_RED_İSTEMİNİ_KABULÜ = 51,
        O_YETKİSİZLİK = 52
    }

    public enum HukumTip
    {
        HAPIS = 1,
        AGIR_HAPIS = 3,
        HAFIF_HAPIS = 4,
        MUEBBET = 5,
        OLUM = 6,
        HAFIF_PARA_CEZASI = 7,
        AGIR_PARA_CEZASI = 8,
        HUCRE = 10,
        PARA_CEZASI = 12
    }

    public enum IcraNispiHarcTipi
    {
        PESiN_HARC = 1,
        HACiZDEN_EVVEL_BAKiYE_HARC = 2,
        HACiZDEN_SONRA_BAKiYE_HARC = 3,
        SATiSTAN_SONRA_BAKiYE_HARC = 4,
        MAAS_HACZiNDE = 5,
        iiK_125e3_GEREGi = 6,
        TEBLiG_iLE_TASiNMAZ_VE_GEMi_TESLiMiNDE = 7,
        iCRA_iLE_TASiNMAZ_VE_GEMi_TESLiMiNDE = 8,
        TEBLiG_iLE_TASiNiR_TESLiMiNDE = 9,
        iCRA_iLE_TASiNiR_TESLiMiNDE = 10,
        CEZAEVi_HARCi = 11,
        VAZGECME_HACiZDEN_ONCE = 12,
        VAZGECME_HACiZDEN_SONRA = 13,
        VAZGECME_SATiSTAN_SONRA = 14,
        NiSPi_iFLAS_HARCi = 16,
        DAMGA_PULU = 17
    }

    public enum IcraTarafKodu
    {
        TakipEden = 1,
        TakipEdilen = 2
    }

    public enum IhbarnameTip
    {
        BirinciHacizIhbarnamesi,
        IkinciHacizIhbarnamesi,
        UcuncuHacizIhbarnamesi,
        BorcluYap
    }

    public enum IncelemeTuru
    {
        BİLİRKİŞİ = 1,
        OTOPSİ = 2,
        FETHİ_KABİR = 3,
        TESPİT = 4,
        PARMAK_İZİ_İNCELEMESİ = 5,
        İMZA_İNCELEMESİ = 6,
        YAZI_İNCELEMESİ = 7,
        KAN_TESTİ = 8,
        DNA_TESTİ = 9,
        KEMİK_TESTİ = 10,
        İMZA_VE_YAZI = 11,
        DİĞER = 12,
        KEŞİF = 13
    }

    /// <summary>
    /// TDI_KOD_IS_TARAF tablosundan oluşturulmuştur.
    /// </summary>
    public enum IsTaraf
    {
        Planlayan = 1,
        Sorumlusu = 2,
        Is_Muhatabi__Kime__ = 3,
        Sahibi = 5,
        Dagitici = 6,
        Yetkilisi = 4
    }

    public enum ItirazDurumu
    {
        NULL = 0,
        ItirazYok = 1,
        İtirazVar = 2,
        KısmiItirazVar = 3,
        Geçersiz = 4,
        GecikmisItiraz = 5,
        GecikmisKismi = 6,
        KabulEdildi = 7,
        Reddedildi = 8,
        Inceleniyor = 9,
    }

    public enum KanitTiplari
    {
        BANT = 1,
        CD = 2,
        DAVA_DOSYASI = 3,
        DVD = 4,
        DİĞER = 5,
        FAX = 6,
        FİLM = 7,
        KAMBİYO_EVRAKI = 9,
        MEKTUP = 10,
        NOTER_EVRAKI = 11,
        PROTOKOL = 12,
        RESİM = 13,
        SÖZLEŞME = 14,
        TANIK = 15,
        TUTANAK = 16,
        VASİYETNAME = 17,
        VCD = 18,
        YAZILI_EVRAK = 19,
        YEMİN = 20,
        İHTARNAME = 21,
        İLAM = 22,
        İNCELEME = 23,
        SES_KASEDİ = 24,
        VİDEO_KASET = 25
    }

    public enum KararTipi
    {
        El_Koyma_Basılmış_Eserler_Eşya_vb = 1,
        Tensip_Kararı_Duruşma_Hazırlığı = 2,
        Sanık_Sorgusunun_Yapılmasına = 3,
        Mağdurun_Dinlenmesine = 4,
        Şikayetçinin_Dinlenmesine = 5,
        Davaya_Müdahale_Talebinin_Kabulüne = 6,
        Davaya_Müdahale_Talebinin_Reddine = 8,
        Kanıtların_Ortaya_Konulmasına = 9,
        Delilin_Ortaya_Konulmasından_Vazgeçilmesine = 10,
        Tanıkların_Duruşmada_Dinlenmelerine = 11,
        Bilirkişinin_Duruşmada_Dinlenmesine = 12,
        Belge_ve_Bilgilerin_Araştırılmasına = 13,
        Uzlaşma_Önerisi_Yapılmasına_Hakim_Tarafından = 14,
        Failin_Fiilinden_Doğmuş_Zararları_Gidermeye_İstekli_Olduğunun_Mağdura_Bildirilmesine = 15,
        Mağdurun_Zararların_Giderilmesi_Halinde_Uzlaşmaya_İstekli_Olduğunun_Bildirilmesine = 16,
        Hakim_Önünde_Uzlaştırma_Yapılmasına_İstek_Üzerine = 17,
        Barodan_Uzlaştırma_Avukatı_Görevlendirilmesinin_İstenmesine = 18,
        Fail_ve_Mağdurun_Uzlaştırıcı_Avukat_Üzerinde_Anlaşmaları_Nedeniyle_Uzlaştırıcının_Göreve_Başlamasına = 19,
        Uzlaştırma_Müzakerelerinin_Yapılmasına = 20,
        Müzakere_ve_Müdahale_Raporunu_Sunması_İçin_Uzlaştırıcıya_Ek_Süre_Verilmesine = 21,
        Zararın_Uzlaşmaya_Uygun_Olarak_Giderilmesine = 22,
        Kanıtların_Tetkikine = 23,
        Delile_Karşı_Diyeceklerinin_İlgililere_Sorulmasına = 24,
        Tarafların_Savunma_ve_Cevapları_Varsa_Sunmalarına = 25,
        Sanığa_Son_Sözün_Verilmesine = 26,
        Tahkikat_Yapılmasına = 27,
        Tahkikatın_Genişletilmesine = 28,
        Tahkikatın_Sona_Erdirilmesine = 29,
        Anayasaya_Aykırılık_İddiasının_Değerlendirilmesine = 31,
        Diğer_Yargılama_Sonucunun_Beklenmesine = 32,
        Diğer_Bir_Mahkemede_Görülmekte_Olan_Dava_Dosyasının_Celbine = 33,
        Türkiyede_İkametgahı_Bulunmayan_Davacının_Teminatı_Depo_Etmesine = 34,
        Kanuni_Noksanlıkların_Tamamlatılmasına = 35,
        Ticaret_Sicilinden_Yetkililer_ve_Adreslerinin_Celbine = 36,
        Kayıp_Geri_Dönmeyen_Tebligat_Akıbeti_Sorulmasına = 37,
        Temsilci_Vasi_Kayyum_Atanmasına = 38,
        Trafik_Sicil_ve_Emniyet_Müdürlüklerinden_Malik_ve_Adresin_Celbine = 39,
        Nüfus_Müdürlüğünden_Kayıtların_Celbine_ve_Adres_Sorulmasına = 40,
        Askerlik_Şubesinden_Bilgi_ve_Adres_Celbine = 41,
        Gaz_Dağıtım_Şirketinden_Bilgi_ve_Adres_Celbine_İGDAŞ_vb = 42,
        Su_ve_Kanalizasyon_İdarelerinden_Bilgi_ve_Adres_Celbine_İSKİ_vb_ = 43,
        Elektrik_Dağıtım_Şirketlerinden_Bilgi_ve_Adres_Celbine_BEDAŞ_AYEDAŞvb = 44,
        Sosyal_Güvenlik_Kurumlarından_Bilgi_ve_Adres_Celbine = 46,
        Esnaf_ve_Sanatkar_Oda_Sicillerinden_Bilgi_ve_Adres_Celbine = 47,
        Tapu_Sicil_Müdürlüğünden_Bilgi_ve_Adres_Celbine = 48,
        Muhtarlıktan_Bilgi_ve_Adres_Celbine = 49,
        Çalıştığı_Son_İşyerinden_Bilgi_ve_Adres_Celbine = 50,
        Vergi_Dairesinden_Bilgi_ve_Adres_Celbine = 51,
        Zabıta_Marifetiyle_Bilgi_ve_Adres_Araştırmasına = 52,
        Davaya_Cevap_Dilekçesinin_Sunmak_Üzere_Davalıya_Süre_Verilmesine = 53,
        Davaya_Cevaba_Davacının_Cevap_Cevabı_İçin_Süre_verilmesine = 54,
        Davalının_Replike_Cevabı_Düplik_İçin_Süre_verilmesine = 55,
        Davacının_Davalının_Cevabına_Karşı_Cevabı_İçin_Süre_verilmesine = 56,
        Davacıya_Kanıt_Listesini_Sunmak_Üzere_Süre_Verilmesine = 57,
        Davalıya_Kanıt_Listesini_Sunmak_Üzere_Süre_Verilmesine = 58,
        Olayla_İlgili_Tutanakların_Celbine = 59,
        Diğer_Mahkeme_Dosyaları_Celbine = 60,
        İcra_Takip_Dosyasının_Celbine = 61,
        Medarı_Tatbik_İmzaların_Celbine = 62,
        Karşılaştırılması_Yaptırılacak_İmzaların_Alınmasına = 63,
        Tarafların_İfadelerinin_Alınmasına = 64,
        Tanık_İfadelerinin_Alınmasına = 65,
        Olay_Yeri_Keşfine = 66,
        Bilirkişi_İncelemesi_Yaptırılmasına = 67,
        Fethi_Kabir_Yaptırılmasına = 68,
        DNA_Testi_Yaptırılmasına = 69,
        İmza_İncelemesi_Yaptırılmasına = 70,
        Kan_Testi_Yaptırılmasına = 71,
        Kemik_Testi_Yaptırılmasına = 72,
        Otopsi_ve_Adli_Tıp_İncelemesi_Yaptırılmasına = 73,
        Parmak_İzi_İncelemesi_Yaptırılmasına = 74,
        Yazı_İncelemesi_Yaptırılmasına = 75,
        Tanık_Beyanlarına_Karşı_Beyanlar_İçin_Süre_Verilmesine = 76,
        Kanıtlara_Karşı_Beyanlar_İçin_Süre_Verilmesine = 77,
        Dosyanın_Adli_Tıpba_Gönderilmesine = 78,
        Dosyanın_İncelemeden_Dönmesinin_Beklenmesine = 79,
        Dosyanın_Yeniden_Bilirkişiye_Sevkine_ = 80,
        Dosyanın_İncelemeden_Dönmemesi_Nedeniyle_Tekid_Müzekkeresi_Gönderilmesine = 81,
        Dosyanın_Gönderilmemesi_Nedeniyle_Tekid_Müzekkeresi_Gönderilmesine = 82,
        Diğer_Bekletici_Meseleler_Nedeniyle_Dosyanın_Bekletilmesine = 83,
        Anayasaya_Aykırılık_İddiası = 84,
        Davalının_Karşı_Dava_İkamesi = 85,
        Takas_ve_Mahsup_Talebi = 86,
        Karşı_Dava_Dilekçesinin_Tebliği = 87,
        Karşı_Davaya_Cevap_Verilmesi = 88,
        Teminat_Yatırılmasına_Yürütmenin_Durdurulması_Talebi_Nedeniyle = 89,
        Yürütmenin_Durdurulmasına = 91,
        İlk_İnceleme_Tensip_Kararı = 92,
        Şekli_Usuli_Hata_ve_Noksanları_Tamamlatılmasına = 94,
        İlk_İnceleme_Üzerine_Davanın_Yetkili_Görevli_Mahkemeye_Gönderilmesine = 95,
        Dava_Dilekçesinin_Tespit_Edilen_Gerçek_Hasıma_Tebliğine = 96,
        İdarenin_Davaya_Cevabının_Davacıya_Tebliğine = 97,
        Davalı_İdarenin_Cevabına_Karşı_Beyanların_Beklenmesine = 98,
        Duruşma_Yapılmasına_İdari_Davada = 99,
        Belgelerin_Resen_Araştırılmasına_İdare_ve_Vergi_Davaları = 100,
        Bilgilerin_Resen_Araştırılması_İdare_ve_Vergi_Davaları = 101,
        İlk_İnceleme_Üzerine_Davanın_Yetkili_Görevli_Mahkemeye_Gönderilmesine_ = 104,
        Dava_Dilekçesinin_Tespit_Edilecek_Gerçek_Hasıma_Tebliğine = 105,
        Duruşma_Yapılmasına_Vergi_Davası_Limit_Aşımı_ve_İstem_Üzerine = 106,
        Dosyanın_Mürafaalı_Olarak_İncelenmesine = 107,
        Duruşma_Tebligatı_Çıkarılmasına_Bozma_Kararı_Üzerine = 108,
        Belge_ve_Bilgilerin_Toplanmasına_Bozma_Kararı_Üzerine = 109,
        Ek_Bilirkişi_İncelemesine_Bozma_Kararı_Üzerine = 110,
        Yargılamanın_Yenilenmesi_Tensip_Kararı = 111,
        Yargılamanın_Yenilenmesi_İsteminde_Bulunanın_Teminat_Vermesine = 112,
        Güvence_Gösterilmesi_Nedeniyle_Yürütmenin_Ertelenmesine = 113,
        İlk_Yargılama_Sonrası_Ortaya_Çıkan_Delillerin_İncelenmesine = 114,
        Sonradan_Sunulan_Belgelere_Göre_Yeniden_Bilirkişi_İncelenmesine = 115,
        Durdurma_Suç_Konusu_Fiil_İşlem_Yayının_Durdurlması = 116,
        Tutuklanmasına = 117,
        Taşınmazlara_Hak_ve_Alacaklara_El_Koyulmasına = 118,
        Şirket_Yönetimi_İçin_Kayyım_Tayin_Edilmesine = 119,
        Telekomünikasyon_Yoluyla_Yapılan_İletişimin_Denetlenmesine = 120,
        Gizli_Soruşturmacı_Görevlendirilmesine = 121,
        Teknik_Araçlarla_İzlenmesine = 122,
        Yakalanmasına_ve_Gözaltına_alınmasına = 123,
        Tutuklama_Kararının_Geri_Alınmasına = 124,
        Şüphelinin_Suçla_İlgili_Sorgulanmasının_Yapılmasına = 125,
        Müsadereye_Ön_Ödeme_Yapılması_ve_Kamu_Davası_Açılmaması_Halinde_Mahkemece_Resen = 126,
        Ön_Ödeme_Nedeniyle_El_Konulan_Eşya_ve_Malvarlığının_İadesine_Mahkemece_Resen = 127,
        İddianamenin_Şekil_Şartlarına_Uygunluğunun_İncelenmesine = 128,
        İddianamenin_Mevcut_Sayılan_Deliller_Toplanmadan_Düzenlenmiş_Olması_Nedeniyle_İadesine = 129,
        İddianamenin_17_Maddeye_Aykırı_Düzenlenmesi_Nedeniyle_İadesine = 130,
        Ön_ödeme_veya_Uzlaşmaya_Tabi_Durumlarda_Bu_Usulün_Uygulanmamış_Olması_Nedeniyle_İadesine = 131,
        İddianamenin_Kabulüne_Kamu_Davasının_Açılmasına = 132,
        Hakem_İsimlerin_Taraflara_Bildirilmesine_Hakem_Tayin_Makamı_Sıfatıyla = 134,
        Dava_Dilekçesinin_Davalıya_ve_Hakemlere_Gönderilmesine = 135,
        Hakem_İkamesine = 136
    }

    public enum KayitTipiOfis
    {
        Excel,
        Pdf,
        Html,
        Print,
        Word
    }

    public enum KDVTipi
    {
        I_SAYILI_LİSTE = 1,
        II_SAYILI_LİSTE = 2,
        III_SAYILI_LİSTE = 4,
        IV_SAYILI_LİSTE = 5,
        GENEL = 6,
        MUAF = 8
    }

    public enum KesinlesmeDurumu
    {
        NULL = 0,
        TakipKesinlesti = 1,
        KismenKesinlesti = 2,
        GecikmisKısmi = 3,
        TakipKesinlesmedi = 4
    }

    public enum KimYerineGetirecek
    {
        Müvekkil = 0,
        KarşıTaraf = 1,
        Mahkeme = 2
    }

    public enum KlasorSecenekleri
    {
        Alacak,
        Teminat,
        Sozlesme,
        Takipler,
        Dava,
        Sorusturma,
        IhtiyatiHaciz,
        IhtiyatiTedbir,
        Odeme,
        Masraf,
        Mal,
        Ihtarname,
        Ilam,
        AlacakSenedi,
        Icra,
        Belge,
        GenelNot,
        Is,

        Taahhut,

        Tebligatlar
    }

    public enum KODTABLOADI
    {
        //AV001_TDI_KOD_ADRES_DURUM,
        AdresDurum,

        //AV001_TDI_KOD_BELGE_OZEL_KOD,
        BelgeOzelKod,

        // AV001_TDI_KOD_CARI_OZEL,
        CariOzel,

        // AV001_TDI_KOD_FOY_OZEL,
        OzelKod,

        //AV001_TDI_KOD_KLASOR,
        KlasorKod,

        //AV001_TDI_KOD_SAHIS_DURUM,
        SahisDurum,

        //TD_KOD_ARA_KARAR_TIP,
        AraKararTip,

        //TD_KOD_FOY_GELISME_ADIM,
        DavaGelismeAdim,

        // TD_KOD_TARAF_OZEL_DURUM,
        TarafOzelDurum,

        //TDI_KOD_ADRES_TUR,
        AdresTur,

        //TDI_KOD_BANKA,
        Banka,

        //TDI_KOD_BANKA_BOLGE,
        BankaBolge,

        //TDI_KOD_BANKA_SUBE,
        BankaSube,

        // TDI_KOD_BASIM_EVI,
        BasımEvi,

        //TDI_KOD_BELEDIYE,
        Belediye,

        //TDI_KOD_DAVA_NISPI_HARC,
        DavaNispiHarc,

        //TDI_KOD_DAVA_OZEL_KOD,
        DavaOzelKod,

        //TDI_KOD_DAVA_OZELLIK,
        DavaOzellik,

        //TDI_KOD_DAVA_SONUC,
        DavaSonuc,

        //TDI_KOD_DUSME_DEGISME_KODU,
        DusmeDegismeKodu,

        //TDI_KOD_FOY_IADE_NEDEN,
        IadeNeden,

        // TDI_KOD_IL,
        IL,

        // TDI_KOD_ILCE,
        ILCE,

        //TDI_KOD_ILETISIM_ALT_KATEGORI,
        IletisimAltKategori,

        //TDI_KOD_ILETISIM_ANA_KATEGORI,
        IletisimAnaKategori,

        // TDI_KOD_KREDI_GRUP,
        KrediGrup,

        // TDI_KOD_KREDI_TIP,
        KrediTip,

        //TDI_KOD_MESLEK,
        Meslek,

        //TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI,
        MuhasebeAltKategori,

        //TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI,
        MuhasebeAnaKategori,

        //TDI_KOD_OZEL_TUTAR_KONU,
        OzelTutarKonu,

        //TDI_KOD_SEGMENT,
        Bölge,

        //TDI_KOD_SEMT,
        Semt,

        // TDI_KOD_SOZLESME_ALT_TIP,
        SozlesmeAltTip,

        // TDI_KOD_TAHSIL_DURUM,
        TahsilDurum,

        // TDI_KOD_TAPU_MUDURLUK,
        TapuMudurluk,

        // TDI_KOD_ULKE,
        Ulke,

        // TDI_KOD_UNVAN,
        Unvan,

        // TDI_KOD_YAYIN_TURLERI,
        YayınTur,

        //TDI_KOD_YAZAR,
        Yazar,

        //TDI_KOD_YAZISMA_TIPI,
        YazismaTip,

        //TDI_KOD_YAZISMA_TUR,
        YazismaTur,

        // TDIE_KOD_OTOMATIK_DUZELT,
        OtomatikDuzelt,

        //TDIE_KOD_PROJE_OZEL_KOD,
        KlasorOzelKod,

        // TDIE_KOD_SEKTOR,
        Sektor,

        //TDIE_KOD_SOZLUK,
        Sozluk,

        //TI_KOD_FOY_GELISME_ADIM,
        IcraGelismeAdim,

        //TI_KOD_HARC_NISPI,
        HarcNispi,

        // TI_KOD_MAL_CINS,
        MalCins,

        // TI_KOD_MAL_KATEGORI,
        MalKategori,

        // TI_KOD_MAL_TUR,
        MalTur,

        // TI_KOD_SIKAYET_NEDEN,
        SikayetNeden,

        // TI_KOD_TAKIP_TALEP_MAKTU_HARC,
        TakipTalepMaktuHarc,

        //TI_KOD_TAKIP_TALEP_NISPI_HARC,
        TakipTalepNispiHarc,

        // TI_KOD_TESPIT_KONUSU,
        TespitHarc,

        //TI_KOD_VERGI,
        Vergi,

        //TS_KOD_MARKA_TIP,
        MarkaTip,

        //TS_KOD_URUN_ALT_KATEGORI,
        UrunAltKategori,

        // TS_KOD_URUN_KATEGORI,
        UrunKategori,

        // TS_KOD_URUN_SINIF_KODLARI,
        UrunSınıfKodları,

        // TDIE_KOD_PROJE_OZEL_KOD,
        ProjeSubeKodları,
    }

    public enum KurBilgisi
    {
        TCMB = 1,
        BANKA = 0
    }

    public enum MalKategori
    {
        NULL = 0,
        GAYRIMENKUL = 1,
        GELİR = 5,
        ARAÇ = 2,
        MENKUL = 7,
        SAHISTAKİ_HAK_VE_ALACAK = 6,
        GEMI = 8,
        UCAK = 9
    }

    public enum MalTip
    {
        Gayrimenkul,
        GemiUcakArac,
        Diger
    }

    public enum MasrafAltKategoriCustom
    {
        BASVURMA_HARCI = 440,
        PESIN_HARC = 629,
        VEKALET_HARCI = 590,
        VEKALET_PULU = 591,
        BARO_PULU = 810,
        TEBLIGAT_GIDERI = 568,
        DOSYA_KIRTASIYE_MASRAFI = 383,
        MEMUR_MAHKEME_YOLLUGU = 8,
        RESMI_YOL_GIDERI = 238,
        HAMAL = 392,
        NAKLIYE = 393,
        CILINGIR = 395,
        BILIRKISI_UCRETI = 382,
        TAHSIL_HARCI = 855,
        CEZAEVI_HARCI = 859,
        GAZETE_ILAN_UCRETI = 398,
        YEDDIEMINLIK_MASRAFI = 852,
        KARAR_HARCI = 862,
        SURET_HARCI = 592,
        MUDAHELE_HARCI = 34,
        TEMYIZ_HARCI_VE_GONDERIM_MASRAFI = 16,
        TASHIHI_KARAR_HARCI_VE_GONDERIM_MASRAFI = 33,
        IFLAS_KAYIT_HARCI = 452,
        IFLAS_DAVASINDA_IFLAS_HARCI = 451,
        IFLAS_TASFIYESI_ICIN_YATIRILAN_MASRAF = 4,
        IMAR_HARCI = 828,
        NOTER_MASRAFI = 813,
        TICARET_SICIL_MASRAFI = 829,
        POSTA_GIDERI = 567,
        FOTOKOPI = 830,
        YENILEME = 879,
        DAMGA_VERGISI = 811,
        TELLALIYE = 397,
        ALIM_HARCI = 245,
        SATIS_HARCI = 390,
        KDV = 812,
        EGITIM_KATKI_PAYI_FOY_PARASI = 337,
        EMLAK_VERGISI_ARAC_VERGISI = 248
    }

    public enum ModulNumber
    {
        Kurumsal_Belediye = 3001,
        Kurumsal_Banka = 1501,
        Kurumsal_Sigorta = 1001
    }

    public enum MuhasebeAltKategoriId
    {
        SHM_BAŞVURMA_HARCI = 10,
        MAAS_ÖDEMELERI = 894,
        AVANS_ODEMELERI = 895,
        IADE_AVANS_ODEMELERI = 896,
        PEŞİN_HARÇ = 11,
        TEMYİZ_HARCI = 16,
        SHM_CELSE_HARCI = 18,
        İHTİYATİ_TEDBİR_MAKTU_KARAR_ve_İLAM_HARCI = 23,
        TESBİT_MAKTU_KARAR_ve_İLAM_HARCI = 27,
        YÜKSEK_MAHKEMENİN_TEHİRİ_İCRA_HARCI = 30,
        KARAR_DÜZELTME_HARCI = 33,
        FERİ_MÜDAHELE_HARCI = 34,
        BAŞVURMA_HARCI = 440,
        YERİNE_GETİRME_HARCI = 441,
        İFLAS_BAŞVURMA_HARCI = 452,
        VEKALET_HARCI = 590,
        VEKALET_PULU = 591,
        SURET_HARCI = 592,
        MAKTU_TETKIK_MERCII_BASVURMA_HARCI = 594,
        MAKTU_TETKİK_MERCİİ_KARAR_VE_İLAM_HARCI = 596,
        MAKTU_CEZAEVİ_HARCI = 597,
        SHM_KARAR_VE_ILAM_HARCI = 598,
        AHM_KARAR_VE_ILAM_HARCI = 599,
        ATM_KARAR_VE_ILAM_HARCI = 600,
        MAKTU_İFLASIN_AÇILMASI_HARCI = 601,
        MAKTU_KONKORDATO_HARCI = 603,
        AHM_BAŞVURMA_HARCI = 615,
        ATM_BAŞVURMA_HARCI = 616,
        NISPI_CEZAEVI_HARCI = 644,
        AHM_CELSE_HARCI = 645,
        İHTİYATİ_HACİZ_KARAR_ve_İLAM_HARCI = 652,
        BİM_BAŞVURMA_HARCI = 802,
        YARG_BAŞVURMA_HARCI = 803,
        DAN_BAŞVURMA_HARCI = 804,
        BİM_KARAR_VE_İLAM_HARCI = 805,
        YARG_KARAR_VE_İLAM_HARCI = 806,
        DAN_KARAR_VE_İLAM_HARCI = 807,
        İDM_BAŞVURMA_HARCI = 808,
        İDM_KARAR_VE_İLAM_HARCI = 809,

        /// <summary>
        /// POSTA GİDERİ
        /// </summary>
        iCRA_POSTA_GiDERi = 567,

        /// <summary>
        /// POSTA GİDERİ
        /// </summary>
        iLK_TEBLiGAT_GiDERi = 568,

        /// <summary>
        /// POSTA GİDERİ
        /// </summary>
        ADi = 569,

        /// <summary>
        /// POSTA GİDERİ
        /// </summary>
        TAAHHUTLU = 570,

        /// <summary>
        /// POSTA GİDERİ
        /// </summary>
        iADELi_TAAHHUTLU = 571,

        /// <summary>
        /// POSTA GİDERİ
        /// </summary>
        EXPRESS = 572,

        /// <summary>
        /// POSTA GİDERİ
        /// </summary>
        APS = 573,

        /// <summary>
        /// POSTA GİDERİ
        /// </summary>
        KARGO = 574,

        /// <summary>
        /// POSTA GİDERİ
        /// </summary>
        KOLi = 575,

        /// <summary>
        /// POSTA GİDERİ
        /// </summary>
        ÖZEL_ULAK = 576,

        /// <summary>
        /// POSTA GİDERİ
        /// </summary>
        FAX = 577,

        /// <summary>
        /// POSTA GİDERİ
        /// </summary>
        E_MAIL = 578,

        /// <summary>
        /// POSTA GİDERİ
        /// </summary>
        TELEKS = 579,

        /// <summary>
        /// POSTA GİDERİ
        /// </summary>
        ICQ = 580,

        /// <summary>
        /// POSTA GİDERİ
        /// </summary>
        AIM = 581,

        /// <summary>
        /// POSTA GİDERİ
        /// </summary>
        SMS = 582,

        /// <summary>
        /// POSTA GİDERİ
        /// </summary>
        MUZEKKERE = 583,

        /// <summary>
        /// POSTA GİDERİ
        /// </summary>
        TEBLiGAT = 584,

        /// <summary>
        /// POSTA GİDERİ
        /// </summary>
        _103_TEBLiG_GiDERi = 589,

        MUHABERE_MASRAFI = 873,
        MAKTU_ICRA_HARC = 874,
        MAKTU_ICRA_VEKALET = 875
    }

    /// <summary>
    /// TDI_KOD_ODEME_TIP tablosundan oluşturulmuştur.
    /// </summary>
    public enum OdemeTip
    {
        NAKİT = 1,
        KREDİ_KARTI = 2,
        ÇEK = 3,
        SENET = 4,
        SATIŞTAN = 5,
        TAAHHÜT = 6,
        VİRMAN = 7
    }

    public enum SatisIstemeSekli
    {
        ALACAKLI_TARAF = 1,
        BORCLU_TARAF = 2,
        İCRA_MÜDÜRLÜĞÜ = 3
    }

    public enum SatisTur
    {
        İHALE_İLE = 1,
        PAZARLIK_İLE = 2
    }

    public enum SozlesmeTur
    {
        Yazılı = 0,
        Sozlu = 1
    }

    public enum SureBirimTip
    {
        Saat = 1,
    }

    public enum SureTipi
    {
        ITIRAZ_SURESI = 1,
        MAL_BEYANI = 2,
        MEHİL_SÜRESİ = 3,
        ODEME_SURESI = 4,
        SIKAYET_SURESI = 5,
        İTİRAZ_6_AY_DAN_BÜYÜK_KİRA_SÖZLEŞMESİ = 6,
        İTİRAZ_6_AY_DAN_KÜÇÜK_KİRA_SÖZLEŞMESİ = 7,
        ÖDEME_6_AY_DAN_BÜYÜK_KİRA_SÖZLEŞMESİ = 8,
        ÖDEME_6_AY_DAN_KÜÇÜK_KİRA_SÖZLEŞMESİ = 9,
        ÖDEME_HASILAT_KİRA_SÖZLEŞMESİ = 10,
        IH_UYGULAMA_SURESI = 14,
        IH_TAKIBE_KOYMA_SURESI = 15,
    }

    public enum TaahhutResmiMi
    {
        SOZLU_TAAHHUT,
        TARAFLAR_ARASI_PROTOKOL,
        ICRADA_RESMI_TAAHHUT
    }

    /// <summary>
    /// TI_KOD_TAKIP_TALEP
    /// </summary>
    public enum TakipTalep
    {
        //TalepAdı_FormTipi = ID
        ADI_ALACAK_49 = 1,

        MENKUL_REHNI_50 = 2,
        KIRA_51 = 3,
        KAMBIYO_ALACAGI_52 = 4,
        NAFAKA_53 = 5,
        ISCI_ALACAGI_53 = 6,
        ISIN_YAPILMASI_53 = 7,
        IRTIFAK_HAKKI_53 = 8,
        MENKUL_TESLIMI_54 = 9,
        GAYRIMENKUL_TAHLIYE_ve_TESLIMI_54 = 10,
        COCUK_TESLIMI_55 = 11,
        YAZILI_SOZLESMEYLE_TAHLIYE_56 = 12,
        IPOTEGIN_PARAYA_CEVRILMESI_151 = 13,
        IPOTEGIN_PARAYA_CEVRILMESI_152 = 14,
        ADI_ALACAK_153 = 15,
        KAMBIYO_ALACAGI_163 = 16,
        MENKUL_REHNI_201 = 17,
        ILAMLI_ALACAK_53 = 18,
    }

    /// <summary>
    /// VDIE_KOD_TARAF_SIFAT_DAVA viewinden oluşturulmuştur.
    /// TDIE_KOD_TARAF_SIFAT tablosu ile iliskili
    /// </summary>
    public enum TarafSifat
    {
        BORCLU = 2,
        ALACAKLI = 1,
        DAVACI = 7,
        DAVALI = 8,
        KATILAN_DAVALI = 9,
        SANIK = 10,
        YAKINAN = 11,
        MAGDUR_SANIK = 12,
        KATILAN_DAVACI = 13,
        MUDAHIL = 14,
        MAGDUR = 15,
        SUPHELI = 98,
        IHBAR_EDILEN_DAVALI = 10007,
        İCRA_KEFİL = 3,
        ALACAKLI_MİRASÇI = 5,
        ALACAKLI_ÜÇÜNCÜ_ŞAHIS = 87,
        ALACAKLI_ARACI_KİŞİ_KURUM = 88,
        ALACAKLI_HİSSEDAR = 89,
        ALACAKLI_TEREKE_SORUMLUSU = 90,
        BORÇLU_ÜÇÜNCÜ_ŞAHIS = 91,
        BORÇLU_ARACI_KİŞİ_KURUM = 92,
        BORÇLU_HİSSEDAR = 93,
        BORÇLU_TEREKE_SORUMLUSU = 94,
        MÜFLİS = 95,
        KİRACI = 96,
        İŞGALCİ = 97,
        REHİN_BORÇLUSU = 4,
        BORÇLU_MİRASÇI = 6,
        MÜTESELSİL_KEFİL = 33,
        _89_BORÇLUSU = 34,
        KİRALAYAN = 100,
        KİRACI_DAVA_EDEN = 99,
        MÜDAHİL = 14,
        MAĞDUR = 15,
        KEŞİDECİ = 37,
        İHTAR_EDEN = 38,
        FESİH_EDEN = 39,
        İTİRAZ_EDEN = 40,
        AZİL_EDEN = 41,
        İSTİFA_EDEN = 42,
        SÖZLEŞME_TARAFI = 43,
        ADİ_KEFİL = 44,
        TANIK = 45,
        TESPİT_İSTEYEN = 47,
        REHİN_EDEN = 48,
        HİBE_EDEN = 49,
        TEMLİK_EDEN = 50,
        ALACAKLI_DAVA_EDEN = 51,
        PROTESTO_EDEN = 52,
        VASİYET_EDEN = 53,
        FERAGAT_EDEN = 54,
        EVLATLIK_VEREN = 55,
        EMANET_EDEN = 56,
        İBRA_EDEN = 57,
        TAAHHÜT_EDEN = 58,
        VEKİL_EDEN = 59,
        SULH_OLAN = 60,
        MUVAFAKAT_EDEN = 61,
        MUHATAP = 62,
        İHTAR_EDİLEN = 65,
        FESİH_EDİLEN = 66,
        İTİRAZ_EDİLEN = 67,
        AZİL_EDİLEN = 68,
        SÖZLEŞME_TARAF = 70,
        KEFALET_ALAN = 71,
        TESPİT_İSTENEN = 72,
        REHİN_ALAN = 73,
        HİBE_ALAN = 74,
        TEMELLÜK_EDEN = 75,
        BORÇLU_DAVACI = 76,
        PROTESTO_OLUNAN = 77,
        VASİYET_OLUNAN = 78,
        EVLATLIK_ALAN = 79,
        EVLATLIK_OLAN = 80,
        EMANET_ALAN = 81,
        İBRA_OLUNAN = 82,
        TAAHHÜT_ALAN = 83,
        VEKİL_OLAN = 84,
        SULH_OLAN_2 = 85,
        MUVAFAKAT_ALAN = 86,
        MAĞDUR_SANIK = 12,
        İHBAR_EDİLEN_DAVALI = 101,
        ŞÜPHELİ = 98
    }

    public enum TarihTip
    {
        BorcOdemeTarihi,
        MenfiTespitDavasiTarihi
    }

    public enum TebligTip
    {
        Satis,
        KiymetTakdiri
    }

    public enum TemsilTipi
    {
        TEK_IMZAYLA = 0,
        İKİ_İMZAYLA = 1,
        ÜÇ_İMZAYLA = 2,
    }

    #region <cc-20090620>

    //odemekimadina enumu yapildi
    public enum OdemeKimAdina
    {
        BORCLU_ADINA = 0,
        KENDI_ADINA = 1,
    }

    #endregion <cc-20090620>

    public enum TutuklanmaGelisTip
    {
        TeslimOlma = 1,
        Yakalnma = 2
    }

    public enum UcretlendirilmisIsler
    {
        DEGISIK_IS_ISLEMLERI = 327,
        HACIZ = 328,
        ICRA_ISLEMLERI = 329,
        IHTARNAME = 330,
        DIGER = 331,
        SOZLESME_BASIT = 260,
        SATIS = 261,
        DISARDA_SOZ_DANISMA = 262,
        OZEL_SOZLESME = 263,
        NOTER_ISLEMLERI = 265,
        RESMI_DAIRE_ISI = 266,
        TEBLIGAT_ISLERI = 612,
        OTOPSI_KESIF_TESBIT = 268,
        SAVCILIKTA_BULUNMA = 272,
        SOZLESME_OZEL = 274,
        MAHKEMEDE_IS_TAKIBI = 275,
        RES_DAIRE_IS_TAKIBI = 276,
        TOPLANTIYA_KATILMA = 278,
        YAZILI_DANISMA = 279,
        HAVALE_YAPILACAK = 476,
        RANDEVU_VERILECEK = 477,
        RAPOR_HAZIRLANACAK = 478,
        DOSYA_INCELEME = 479,
        SORGUDA_BULUNMA = 480,
        TELEFONLA_DANISMA = 481,
        YASAL_SURELI_ISLER = 482,
        DURUSMALAR = 483,
        ARA_KARARLAR = 484,
        TAHSILAT = 485,
        HATIRLATMA = 486,
        FAX_ÇEKILECEK = 487,
        NOT = 488,
        GUNLUK_ISLER = 489,
        BURO_ISLERI = 490,
        PERSONEL_ISLERI = 491,
        INCELEMELER = 492,
        TELEFONLA_GORUSME = 493,
        BURODA_GORUSME = 494,
        KONFERAS_GORUSMESI = 495,
        CEZAEVINDE_GORUSME = 496,
        ADLIYEDE_GORUSME = 497,
        MUVEKKILIN_ADRESINDE_GORUSME = 498,
        KARAKOLDA_GORUSME = 499,
        SAVCILIKTA_GORUSME = 500,
        HASTAHANEDE_GORUSME = 501
    }

    public enum UYAPIslemSecimi
    {
        Kayit,
        Mail
    }

    public enum ViewType
    {
        VGrid,
        GridView,
        LayoutView
    }
}