namespace AvukatProLib.Extras
{
    #region Enumerations

    public enum AdresBilgisi
    {
        Yaz,
        Yazma
    }

    public enum BorcAlacak
    {
        Borc = 2,
        Alacak = 1
    }

    public enum DovizIslemTipi
    {
        VadeTarihindeYtl = 0,
        TakipTarihindeOdemeYtl = 1,
        OdemeTarihindeYtl = 2
    }

    public enum FormType
    {
        AboutAvukatpro,
        AdimAdimEditoreGonder,
        AdimAdimIcraKaydi,
        Ajanda,
        AjandaGirisEkran,
        AlacakNedenEkle,
        AracGemiUcakGirisEkran,
        AsamaTebligatGirisi,
        BaglantiAyar,
        BelgeAramaEkran,
        BelgeGirisEkran,
        BelgeKayitUfak,
        CariAramaForm,
        CariGenelGiris,
        CariTakipForm,
        Cetvel,
        DavaDosyaKayitForm,
        DavaGirisEkran,
        DavaGirisHizliEkran,
        DavaTakip,
        DegiskenAyar,
        DurusmaAraKararGirisEkran,
        DurusmaCelseGirisEkran,
        Editor,
        FaizTipiKT,
        GayrimenkulGirisEkran,
        GenelAyar,
        GorusmeGirisEkran,
        GorusmeKayit,
        HacizGirisEkran,
        IcraDosyaKayit,
        IcraGirisEkran,
        IcraIlamMahkemeGiris,
        IcraTakip,
        IcraVekaletSozlesmesi,
        IhtiyatiHacizGirisEkran,
        IhtiyatiTedbirBilgileriGirisEkran,
        IlamBilgileriGirisEkran,
        IsKayitUfak,
        IsParamEkle,
        ItirazBilgileriGirisEkran,
        KasaGirisEkran,
        KayitIliski,
        KisayolOlustur,
        KiymetliEvrakKayit,
        KiymetliEvrakKayitLayout,
        KiymetliEvrakGirisEkran,
        KlasorGenel,
        KurumsalGirisEkran,
        LisansAktiveEtme,
        Main,
        MuhasebeGiris,
        MuhasebeGirisEkran,
        Muhasebelestirme,
        OdemeBilgileriGirisEkran,
        OdemePlani,
        ParolaDegistirme,
        PoliceHasarGirisEkran,
        ProjeAramaForm,
        ProjeGenel,
        ProjeGirisEkran,
        SatisGirisEkran,
        SikKullanilanEkle,
        SorusturmaGiris,
        SorusturmaGirisEkran,
        SorusturmaTakip,
        SozlesmeGirisEkran,
        SozlesmeKayit,
        SozlesmeTakip,
        TaahhutBilgileriGirisEkran,
        TebligatGirisEkran,
        TebligatKayitEkrani,
        TeminatMektupGirisEkran,
        TemsilBilgileriGirisEkran,
        TemsilKayit,
        TespitKaydetForm,
        TumDosyalar,
        TumMallarGirisEkran,
        YapilcakIsAramaEkran,
        YapilcakIslerGirisEkran
    }

    public enum HareketAltKategori
    {
        MuvekkileOdeme = 381,
        BorcluOdemesi = 377
    }

    public enum HareketAnaKategori
    {
        Odeme = 15,
        AvansHesabý = 10
    }

    public enum KdvTipi
    {
        ISayiliListe,
        IISayisiListe,
        IIISayiliListe,
        IVSayiliListe,
        Genel,
        Muhaf
    }

    public enum Modul
    {
        Icra = 1,
        Dava = 2,
        Sorusturma = 3,
        Sozlesme = 5,
        Muhasebe = 6,
        Genel = 7,
        Belge = 8,
        Tebligat = 9,
        Is = 10,
        IHTIYATI_HACIZ = 11,
        IHTIYATI_TEDBIR = 12,
        Klasor = 13,
        Ilam = 19,
        Gorusme = 20
    }

    public enum ModulTip
    {
        Sorusturma = 4,
        Dava = 2,
        Icra = 1,
        Sozlesme = 3,
        Tebligat = 5,
        YapilacakIsler = 6,
        CariArama = 7,
        Gorusme = 8
    }

    public enum OdemeYeri
    {
        ALACAKLIYA = 1,
        ÝCRA_DAÝRESÝNE = 2,
        AVUKATA = 3,
        SATIÞTAN = 4,
        TAKASTAN = 5,
        BANKA_HESABINA = 6
    }

    public enum SabitDegiskenFaiz
    {
        SabitFaiz = 0,
        Degisken = 1
    }

    public enum TaahhutDurum
    {
        IHLAL_YOK = 1,
        ZAMANINDAN_ONCE_EKSIK = 2,
        ZAMANINDAN_ONCE_TAM = 3,
        ZAMANINDA_EKSIK = 4,
        ZAMANINDA_TAM = 5,
        ZAMANINDAN_SONRA_EKSIK = 6,
        ZAMANINDAN_SONRA_TAM = 7,
        ZAMANINDA_ODEME_YOK = 8,
        TAAHHUT_KABUL_TARIHI_GIRILMEMIÞ = 9,
    }

    public enum TakipEldenmi
    {
        Elden_Takip,
        Elden_Takip_Deðildir
    }

    public enum TebligatZarfindaTutarBilgisi
    {
        Olsun,
        Olmasýn
    }

    public enum VekilBilgisi
    {
        Sorumlu_Avukattan,
        Taraf_Vekilinden,
        Antetten,
        Vekil_Bilgisi_Yazma
    }

    #endregion Enumerations
}