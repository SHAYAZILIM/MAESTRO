namespace AvukatProLib.Extras
{
    public enum EksiltenTipi
    {
        Odeme,
        Feragat
    }

    public enum IcraHesapCetveli
    {
        Bos = 0,
        Asil_Alacak = 1,
        Islemis_Faiz = 2,
        Takip_Oncesi_BSMV = 3,
        Takip_Oncesi_KKDV = 4,
        Takip_Oncesi_OIV = 5,
        Takip_Oncesi_KDV = 6,
        Cek_Tazminati = 7,
        Cek_Komisyonu = 8,
        Ilam_Vekalet_Ucreti = 9,
        Ilam_Inkar_Tazminati = 10,
        Ilam_Teblig_Gideri = 11,
        Yargitay_Bak_ve_Ona_Harci = 12,
        Ilam_Yargi_Gideri = 13,
        Ihtiyati_Haciz_Gideri = 14,
        I_H_Vekalet_Ucreti = 15,
        Ihtiyati_Tedbir_Gideri = 16,
        I_T_Vekalet_Ucreti = 17,
        Ozel_Tutar_1 = 18,
        Ozel_Tutar_2 = 19,
        Ozel_Tutar_3 = 20,
        Ozel_Tazminat = 21,
        Ihtar_Gideri = 22,
        Protesto_Gideri = 23,
        Damga_Pulu = 24,
        I_Hacizde_Odenen = 25,
        Mahsup_Toplami = 26,
        Takip_Oncesi_Odeme = 27,
        Takip_Cikisi = 28,
        Sonraki_Faiz = 29,
        Takip_Sonrasi_BSMV = 30,
        Takip_Sonrasi_OIV = 31,
        Takip_Sonrasi_KDV = 32,
        Sonraki_Tazminat = 33,
        Birikmis_Nafaka = 34,
        Ilk_Giderler = 35,
        Tahliye_Davasi_Gideri = 36,
        Tahliye_Teblig_Gideri = 37,
        Dava_Giderleri = 38,
        Diger_Giderler = 39,
        Takip_Vekalet_Ucreti = 40,
        Tahliye_Vekalet_Ucreti = 41,
        Tahliye_Dava_Vekalet_Ucreti = 42,
        Dava_Vekalet_Ucreti = 43,
        Pesin_Harc = 44,
        Odenen_Tahsil_Harci = 45,
        Kalan_Tahsil_Harci = 46,
        Diger_Harclar = 47,
        Tahliye_Dava_Bakiye_Harci = 48,
        Paylasma_Harci = 49,
        Masaya_Katilma_Harci = 50,
        Icra_Inkar_Tazminati = 51,
        Dava_Inkar_Tazminati = 52,
        Feragat_Toplami = 53,
        Odeme_Toplami = 54,
        Basvurma_Harci = 55,
        Yerine_Getirme_Harci = 56,
        Maktu_Cezaevi_Harci = 57,
        Iflas_Pesin_Harci = 58,
        Iflas_Basvurma_Harci = 59,
        Cezaevi_Harci = 60,
        Menkul_Teslim_Harci = 61,
        Tahliye_Harci = 62,
        Iflasin_Acilmasi_Harci = 63,
        Kefalet_Harci = 64,
        Maktu_Konkordato_Harci = 65,
        Vekalet_Pulu = 66,
        Vekalet_Harci = 67,
        Ilk_Tebligat_Gideri = 68
    }

    public enum IcraMalKategori
    {
        Null = 0,
        GayriMenkul = 1,
        Gelir = 5,
        Arac = 2,
        Menkul = 7
    }

    public enum KayitIliskiNeden
    {
        ALT_DOSYA = 1,
        AYRILMIS_DAVA = 4,
        BIRLESMIS_DAVA = 3,
        EMSAL_DAVA = 5,
        HESAP_ICIN = 6,
        KARSILIK_DAVA = 2,
        NOTER_BELGELERI = 8,
        SAVCILIK_TESPIT = 7
    }

    public enum KayitIliskiTur
    {
        DAVA_DOSYASI = 5661,
        ICRA_DOSYASI = 601,
        IHTIYATI_HACIZ = 620,
        IHTIYATI_TEDBIR = 622,
        TESPIT_DOSYASI = 1730,
        RUCU_DOSYASI = 5600,
        HAZIRLIK_DOSYASI = 5610,
        TALIMAT_ICRA = 1703,
        TALIMAT_DAVA = 1704
    }

    public enum ModKurum
    {
        FinansBank = 101,
        INGBank = 102,
        HalkBank = 103,
        YKS = 201,
        Bedas = 701,
        Aygaz = 801
    }

    public enum ModSektor
    {
        Banka = 100,
        Sigorta = 200,
        Kamu = 300,
        Vakýf = 400,
        Telekominikasyon = 500,
        Belediye = 600,
        Enerji = 700,
        Petrol = 800,
        Ozel1 = 900,
        Ozel2 = 1000,
        Ozel3 = 1100
    }

    /// <summary>
    /// TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI
    /// </summary>
    public enum MuhasebeAnaKategori
    {
        MAHKEME_MASRAFLARI = 1,
        TAKIP_EDILENIN_ODEYECEGI_VEKALET_UCRETI = 2,
        TAKIP_EDENIN_ODEYECEGI_VEKALET_UCRETI = 3,
        HARCLAR_DAVA = 4,
        SOZLESME_VEKALET_UCRETI = 5,
        UCRETLENDIRILMIS_ISLER = 6,
        BURO_GIDERLERI = 8,
        CMUK_VEKALET_UCRETI = 9,
        AVANS_HESABI = 10,
        DIGER = 12,
        PERSONEL_KASA_HAREKETI = 13,
        ODEME = 15,
        ICRA_TAKIP_MASRAFLARI = 16,
        TAKIP_ALACAKLARI = 17,
        ALACAK_USTUNDEN_ALINAN_VERGILER = 18,
        HARCLAR_ICRA = 19,
        HARCLAR_IFLAS = 20,
        DAVA_EDEN_LEHINE_INKAR_TAZMINATI = 21,
        DAVA_EDILEN_LEHINE_INKAR_TAZMINATI = 22,
        TAZMINATLAR = 24,
        EVRAK_GIDERLERI = 30,
        HARCLAR_GENEL = 32,
        HARCLAR_BAKIYE = 34,
        MEMUR_YEVMIYE = 35,
        POSTA_GIDERLERI = 31,
        HARCLAR_IADE = 33,
        HARCLAR_ICRA_NISPI = 37,
        HARCLAR_IFLAS_NISPI = 39,
        HARCLAR_DAVA_NISPI = 40,
        HARCLAR_GENEL_NISPI = 41,
        DAVA_EDENIN_ODEYECEGI_VEKALET_UCRETI = 42,
        DAVA_EDILENIN_ODEYECEGI_VEKALET_UCRETI = 43,
        DAVA_ALACAKLARI = 44,
        BORCLU_ODEME = 45,
        YEDIEMIN_MAKTU_UCRETI = 50,
        YEDIEMIN_NISPI_UCRETI = 51,
        MUVEKKILE_ODENEN = 10002,
        MAAS_ODEME = 52,  //10003,
        ELEKTRIK_FATURASI = 53, //10004,
    }
}