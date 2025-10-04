using AvukatPro.Model.EntityClasses;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Data.Bases;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BelgeUtil
{
    //TODO: Inýts Kýsa YOL TAHSIN

    public partial class Inits
    {
        public static VList<per_TDI_KOD_ADLI_BIRIM_ADLIYE> _AdliBirimAdliyeGetir;
        public static VList<per_TDI_KOD_ADLI_BIRIM_ADLIYE> _AdliBirimAdliyeGetir_Enter;
        public static VList<per_TDI_KOD_ADLI_BIRIM_ADLIYE> _AdliBirimAdliyeGetirSadeceAdliye;
        public static VList<per_TDI_KOD_ADLI_BIRIM_BOLUM> _AdliBirimBolumGetir;
        public static VList<per_TDI_KOD_ADLI_BIRIM_GOREV> _AdliBirimGorevGetir_Enter;
        public static VList<per_TDI_KOD_ADLI_BIRIM_GOREV> _AdliBirimGorevGetirSadeceN_Enter;
        public static VList<per_TDI_KOD_ADLI_BIRIM_NO> _AdliBirimNoGetir;
        public static VList<per_AV001_TDI_KOD_ADRES_DURUM> _AdresDurumGetir;
        public static VList<per_TDI_KOD_ADRES_TUR> _AdresTurGetir_Enter;
        public static List<AvukatProLib.Arama.per_AV001_TI_BIL_ALACAK_NEDEN> _AlacakNEdenGetir;

        /// <summary>
        /// AV001_TI_BIL_ALACAK_NEDEN_TARAF
        /// </summary>
        /// <param name="rLue"></param>
        public static List<AvukatProLib.Arama.per_AV001_TI_BIL_ALACAK_NEDEN_TARAF> _AlacakNedenTarafGetir;

        /// <summary>
        /// AV001_TD_BIL_ARA_KARAR
        /// </summary>
        /// <param name="rLue"></param>
        public static TList<AV001_TD_BIL_ARA_KARAR> _ArarKararGetir;

        public static VList<per_TDIE_KOD_ASAMA_ALT> _AsamaAltKodGetir;
        public static VList<per_TDIE_KOD_ASAMA> _AsamaKodGetir;
        public static VList<per_TDIE_KOD_ASAMA_MODUL> _AsamaModulGetir;
        public static VList<per_TDIE_KOD_ASAMA_OZEL_DURUM> _AsamaOzelDurumGetir;

        /// <summary>
        /// TDI_KOD_BANKA_BOLGE
        /// </summary>
        /// <param name="rLue"></param>
        public static TList<TDI_KOD_BANKA_BOLGE> _BankaBolgeGetir;

        public static VList<VDI_KOD_BANKA_SUBE> _BankadirekSubeIsmiGetir;
        public static VList<per_TDI_KOD_BANKA> _BankaGetir;
        public static VList<per_TDI_KOD_BANKA_KART_TIP> _BankaKartTip;
        public static List<AvukatProLib.Arama.VDI_KOD_BANKA_SUBE_Detay> _BankaSubeGetirDetay;
        public static List<AvukatProLib.Arama.per_TDI_KOD_BELEDIYE> _BelediyeGetirIlceyeGore;
        public static List<AvukatProLib.Arama.per_TDI_KOD_BELEDIYE> _BelediyeGetirTumu;
        public static List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> _BelgeGetir;
        public static VList<R_BELGELER_TARAFLI> _BelgeGetirTaraflý;
        public static TList<TDIE_KOD_BELGE_GIZLILIK> _BelgeGizlilikGetir;
        public static VList<per_AV001_TDI_KOD_BELGE_OZEL_KOD> _BelgeOzelKodGetir;

        /// <summary>
        /// TDIE_KOD_BELGE_TUR
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDIE_KOD_BELGE_TUR> _BelgeTurGetir;

        public static VList<BIRLESIK_SIK_KULLANILANLAR> _BIRLESIK_SIK_KULLANILANLARGetir;

        /// <summary>
        /// TDI_KOD_BIRIM
        /// </summary>
        /// <param name="lue"></param
        public static VList<per_TDI_KOD_BIRIM> _BirimKodGetir;

        public static VList<per_TDI_KOD_MUHASEBE_BORC_ALACAK> _BorcAlacakGetir;
        public static TList<AV001_TDI_BIL_CARI> _CariAdliPersonelKodGetir;
        public static TList<AV001_TDI_BIL_CARI_ALT> _CariAltGetir;
        public static TList<AV001_TDI_BIL_CARI> _CariAvukatGetir;
        public static VList<per_AV001_TDI_BIL_CARI> _CariAvukatKodGetir_Enter;
        public static VList<per_AV001_TDI_BIL_CARI> _CariAvukatOrtakligiKodGetir_Enter;
        public static TList<AV001_TDI_BIL_CARI> _CaridenFirmaGetir;
        public static TList<AV001_TDI_BIL_CARI> _CariFirmaGetir;
        public static TList<AV001_TDI_BIL_CARI> _CariGetir;
        public static TList<AV001_TDI_BIL_CARI> _CariGetirAvukatmi;
        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> _CariGetirBilirkisi;
        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> _CariHakemGetir;

        /// <summary>
        /// AV001_TDI_BIL_CARI_HESAP
        /// </summary>
        /// <param name="lue"></param
        public static TList<AV001_TDI_BIL_CARI_HESAP> _CariHesapGetir;

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> _CariIsmiGetir_Enter;
        public static TList<AV001_TDI_KOD_CARI_OZEL> _CariOzelKodGetir;
        public static TList<AV001_TDI_KOD_CARI_OZEL> _CariOzelKodGetir_Enter;
        public static VList<per_AV001_TDI_BIL_CARI> _CariPersonelKodGetir_Enter;
        public static List<AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT> _CariSifatGetir;
        public static VList<per_TDI_KOD_UNVAN> _CariUnvanGetir_Enter;
        public static TList<AV001_TD_BIL_CELSE> _Celseler;

        /// <summary>
        /// TDI_KOD_CINSIYET
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDI_KOD_CINSIYET> _CinsiyetGetir;

        /// <summary>
        /// TDI_KOD_DAVA_ADI
        /// </summary>
        /// <param name="lue"></param>
        public static List<AvukatProLib.Arama.per_TDI_KOD_DAVA_ADI> _DavaAdiGetir;

        public static List<AvukatProLib.Arama.per_TDI_KOD_DAVA_ADI> _DavaAdNedenKodGetir;

        //TDI_KOD_DAVA_ALT_TUR
        public static VList<per_TDI_KOD_DAVA_ALT_TUR> _DavaAltTurGetir;

        //TDI_KOD_DAVA_ANA_TUR
        public static VList<per_TDI_KOD_DAVA_ANA_TUR> _DavaAnaTurGetir;

        public static List<AvukatProLib.Arama.VTD_DAVA_DOSYALAR> _DavaDosyalar;
        public static VList<per_TD_KOD_HARC_NISPI> _DavaHarcTipi;
        public static VList<per_TD_KOD_DAVA_NEDEN_TIP> _DavaNedenTipGetir;

        //TDI_KOD_DAVA_OZEL_KOD
        public static VList<per_TDI_KOD_DAVA_OZEL_KOD> _DavaOzelKodGetir;

        public static TList<AV001_TI_BIL_DAVA_OZET> _DavaOzetNo;
        public static VList<per_TDI_KOD_DAVA_SONUC> _DavaSonuclariGetir;
        public static List<AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT> _DavaTarafSifatGetir;

        //TDI_KOD_DIGER_VERGI
        public static VList<per_TDI_KOD_DIGER_VERGI> _DigerVergiTuruGetir;

        /// <summary>
        /// TDIE_KOD_DIL
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDIE_KOD_DIL> _DilKodGetir;

        public static VList<per_TDI_KOD_FOY_DURUM> _DosyaDurumGetir;
        public static List<AvukatProLib.Arama.per_AV001_TI_BIL_FOY_SORUMLU_AVUKAT> _DosyaSorumluAvukatGetir;
        public static List<TDI_KOD_DOVIZ_TIP> _DovizSource;
        public static VList<per_TDI_KOD_DOVIZ_TIP> _DovizTipGetir;
        public static TList<TDI_KOD_DUSME_DEGISME_KODU> _DusmeYenilemeNedeni;

        /// <summary>
        /// TDI_KOD_FAIZ_KALEM
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDI_KOD_FAIZ_KALEM> _FaizKalemGetir;

        public static VList<per_TDI_KOD_FAIZ_TIP> _FaizTipiGetir;
        public static VList<per_TDI_KOD_FIRMA_TUR> _FirmaTurGetir_Enter;
        public static List<AvukatProLib.Arama.per_TI_KOD_FORM_TIP> _FormTipiGetir;
        public static VList<per_TDI_KOD_FOY_BIRIM> _FoyBirimGetir;
        public static VList<per_TDI_KOD_FOY_DURUM> _FoyDurumGetir_Enter;

        ///<summary>
        /// TDI_KOD_FOY_IADE_NEDEN
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDI_KOD_FOY_IADE_NEDEN> _FoyIadeNedenGetir;

        public static VList<per_TDI_KOD_FOY_OZEL_DURUM> _FoyOzelDurumGetir;
        public static VList<per_AV001_TDI_KOD_FOY_OZEL> _FoyOzelKodGetir;
        public static VList<per_AV001_TDI_KOD_FOY_OZEL> _FoyOzelKodGetir_Enter;
        public static VList<per_AV001_TDI_KOD_FOY_OZEL> _FoyOzelKodGetirProje;

        /// <summary>
        /// AV001_TI_BIL_FOY_TARAF
        /// </summary>
        /// <param name="rLue"></param>
        public static List<AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF> _FoyTarafGetir;

        public static VList<per_TDI_KOD_FOY_YERI> _FoyYeriGetir;
        public static TList<AV001_TI_BIL_GAYRIMENKUL> _GayrimenkulGetir;
        public static VList<per_TI_KOD_GAYRIMENKUL_TARAF_SIFAT> _GayriMenkulTarafSifatGetir;

        /// <summary>
        /// TD_KOD_FOY_GELISME_ADIM
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TD_KOD_FOY_GELISME_ADIM> _GelismeAdimGetir;

        public static TList<TI_KOD_FOY_GELISME_ADIM> _GelismeAdimGetirIcra;
        public static VList<per_TDI_KOD_IS_KOSUL_TIP> _GetIsKosulTip;
        public static List<AvukatProLib.Arama.per_HACIZLI_MALLAR_MASTER_CHILD> _HACIZLI_MALLAR_MASTER_CHILD;
        public static TList<AV001_TI_BIL_HACIZ_CHILD> _HacizChildGetir;

        //
        ///<summary>
        /// TI_KOD_HACIZ_ISLEM_DURUM
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TI_KOD_HACIZ_ISLEM_DURUM> _HacizIslemDurumGetir;

        public static VList<per_TDI_KOD_REHIN_HARC_ISTISNA> _HarcIstisnaGetir;

        //TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI
        public static VList<per_TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI> _HareketAnaKategoriGetir;

        public static VList<per_TDI_KOD_HATIRLATMA_PERIYOD> _HatirlatmaPeriyodGetir;

        /// <summary>
        /// TD_KOD_HAZIRLIK_DURUM
        /// </summary>
        /// <param name="lue"></param>
        public static VList<per_TD_KOD_HAZIRLIK_DURUM> _HazirlikDurumGetir;

        /// <summary>
        /// TD_KOD_HAZIRLIK_HIKAYE_SUREC
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TD_KOD_HAZIRLIK_HIKAYE_SUREC> _HazirlikHikayeSurecGetir;

        /// <summary>
        /// AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN
        /// </summary>
        /// <param name="rLue"></param>
        public static TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN> _HazirlikSikayetNedenGetir;

        /// <summary>
        /// TD_KOD_HAZIRLIK_SUREC_TIP
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TD_KOD_HAZIRLIK_SUREC_TIP> _HazirlikSurecGetir;

        /// <summary>
        /// TD_KOD_HAZIRLIK_SUREC_SONUC
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TD_KOD_HAZIRLIK_SUREC_SONUC> _HazirlikSurecSonucGetir;

        /// <summary>
        /// TD_KOD_FOY_HIKAYE_SUREC
        /// </summary>
        /// <param name="rLue"></param>
        public static TList<TD_KOD_FOY_HIKAYE_SUREC> _HikayeSurecGetir;

        public static TList<TI_KOD_FOY_HIKAYE_SUREC> _HikayeSurecGetirIcra;
        public static TList<TD_KOD_HAZIRLIK_HIKAYE_SUREC> _HikayeSurecGetirSorusturma;

        /// <summary>
        /// TDI_KOD_RUCU_IBRANAME_DURUM
        /// </summary>
        /// <param name="lue"></param
        public static VList<per_TDI_KOD_RUCU_IBRANAME_DURUM> _IbranameDurumGetir;

        public static DataTable _IcraDosyalarArama;

        ///<summary>
        /// TI_KOD_ERTELEME_NEDEN
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TI_KOD_ERTELEME_NEDEN> _IcraErtelemeNeden;

        public static VList<per_TI_KOD_HARC_NISPI> _IcraHarcTipi;
        public static VList<per_TI_KOD_ITIRAZ_SONUC> _IcraItirazSonucGetir_Enter;
        public static VList<VI_BIL_ICRA_TARAF_GELISMELERI> _IcraTarafGelismeleriGetir;

        /// <summary>
        /// AV001_TI_BIL_ILAM_MAHKEMESI
        /// </summary>
        /// <param name="lue"></param>
        public static List<AvukatProLib.Arama.per_AV001_TI_BIL_ILAM_MAHKEMESI> _IlamKararGetir;

        public static TList<TDI_KOD_ILAM_BELGE_TUR> _IlamTipiGetir;
        public static VList<per_TDI_KOD_ILCE> _IlceGetirOzetli_Enter;
        public static VList<per_TDI_KOD_ILCE> _IlceGetirTumu_Enter;
        public static VList<per_TDI_KOD_ILETISIM_ALT_KATEGORI> _IletisimaltKategoriGetir;
        public static VList<per_TDI_KOD_ILETISIM_ANA_KATEGORI> _IletisimAnaKategoriGetir;
        public static List<AvukatProLib.Arama.per_TDI_BIL_ILETISIM> _IletisimBilgileri;
        public static VList<per_TDI_KOD_IL> _IlGetir_Enter;
        public static VList<per_TDI_KOD_IL> _IlGetirUlkeyeGore;

        /// <summary>
        /// TI_KOD_IMTIYAZLI_ALACAK
        /// </summary>
        /// <param name="lue"></param>
        public static VList<per_TI_KOD_IMTIYAZLI_ALACAK> _ImtiyazliAlacakGetir;

        public static VList<PER_TDI_KOD_INCELEME_TUR> _IncelemeTurGetir;
        public static VList<per_TDI_KOD_IS_DURUM> _IsDurumGetir;
        public static VList<per_TDI_KOD_IS_ETIKET> _IsEtiketGetir;

        //AV001_TDI_BIL_IS
        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_I> _IsGetir;

        public static TList<AV001_TDI_BIL_IS> _IsGetirTable;
        public static VList<per_TDI_KOD_IS_IADE_NEDEN> _IsIadeNedeni;
        public static VList<per_TDIE_KOD_IS_TANIM> _IsKonuKodGetir;
        public static VList<per_TDI_KOD_IS_ONCELIK> _IsOncelikGetir;
        public static object _IsSozlesmeGetir;

        /// <summary>
        /// AV001_TDI_KOD_IS_SUREC
        /// </summary>
        /// <param name="rLue"></param>
        public static TList<AV001_TDI_KOD_IS_SUREC> _IsSurecGetir;

        public static VList<per_TDI_KOD_IS_TARAF> _IsTarafGetir;

        /// <summary>
        /// TI_KOD_ITIRAZ_SEBEP
        /// </summary>
        /// <param name="lue"></param>
        public static VList<per_TI_KOD_ITIRAZ_SEBEP> _ItirazSebebiGetir;

        public static VList<per_TI_KOD_ITIRAZ_SONUC> _ItirazSonucuGetir;

        ///<summary>
        /// TDI_KOD_KAN_GRUP
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDI_KOD_KAN_GRUP> _KanGrupGetir;

        public static VList<per_TD_KOD_MAHKEME_HUKUM> _KararSonucuGetir;
        public static VList<per_TD_KOD_YUKSEK_MAHKEME_KARAR_TIP> _KararTipGetir;
        public static VList<KASA_BILGILERI> _KasaBilgileriGetir;
        public static VList<per_TDI_KOD_KAYIT_ILISKI_NEDEN> _KayitIliskiNedenGetir;
        public static VList<per_TDI_KOD_KAYIT_ILISKI_TUR> _KayitIliskiTurGetir;
        public static VList<per_TDI_KOD_KDV> _KDVTipGetir;

        /// <summary>
        /// TI_KOD_KEFALET_KAPSAM
        /// </summary>
        /// <param name="lue"></param>
        public static VList<per_TI_KOD_KEFALET_KAPSAM> _KefaletKapsamGetir;

        /// <summary>
        /// TDI_KOD_KIMLIK
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDI_KOD_KIMLIK> _KimlikTurGetir;

        /// <summary>
        /// TDI_KOD_KIMLIK_VERILIS_NEDEN
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDI_KOD_KIMLIK_VERILIS_NEDEN> _KimlikVerilisNedenGetir;

        public static TList<AV001_TDI_BIL_KIYMETLI_EVRAK> _KiymetliEvrakGetir;

        //
        public static VList<per_TDI_KOD_KIYMETLI_EVRAK_STATU> _KiymetliEvrakStatuDurumGetir;

        public static VList<per_TDI_KOD_KIYMETLI_EVRAK_TARAF_TIP> _KiymetliEvrakTarafTipGetir;
        public static VList<per_TDI_KOD_KIYMETLI_EVRAK_TUR> _KiymetliEvrakTipiGetir;
        public static TList<AV001_TI_BIL_KIYMET_TAKDIRI> _KiymetTakdiriGetir;
        public static List<AvukatProLib.Arama.per_TIE_KOD_ALACAK_NEDEN_GRUP> _KOD_ALACAK_NEDEN_GRUP;
        public static List<AvukatProLib.Arama.per_TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> _KOD_ALACAK_NEDEN_GRUP_DEGISKEN;
        public static List<AvukatProLib.Arama.per_TDIE_KOD_SOZLUK> _KodSozlukGetir;
        public static VList<per_TDI_KOD_KREDI_GRUP> _KrediGrubu;
        public static VList<per_TDI_KOD_KREDI_TIP> _KrediTipiGetir;
        public static TList<CS_KOD_KULLANICI_GRUP> _KullaniciGrupGetir;

        //TDI_BIL_KULLANICI_LISTESI
        public static TList<TDI_BIL_KULLANICI_LISTESI> _KullaniciListesiGetir;

        public static VList<per_TDI_KOD_ILCE> _llceGetirIlle;
        public static VList<per_TDI_KOD_ADLI_BIRIM_GOREV> _MahkemeGoreviGetir_Enter;
        public static object _MahkemeHukumGetir;

        /// <summary>
        /// TD_KOD_MAHKEME_HUKUM_TIP
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TD_KOD_MAHKEME_HUKUM_TIP> _MahkemeHukumTipGetir;

        public static VList<per_TDI_KOD_MAHSUP_ALT_KATEGORI> _MahsupAltKategori;
        public static VList<per_TDI_KOD_MAHSUP_KATEGORI> _MahsupKategori;
        public static VList<per_TI_KOD_MAL_CINS> _MalcinsGetir;
        public static VList<per_TI_KOD_MAL_KATEGORI> _MalKategoriGetir;
        public static VList<per_TI_KOD_MAL_CINS> _MalKategoriTurCinsGetir;
        public static VList<per_TI_KOD_MAL_TUR> _MalTurGetir;

        /// <summary>
        /// TS_KOD_MARKA_TIP
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDI_KOD_REHIN_HARC_ISTISNA_BELGE> _MarkaTipGetir;

        public static TList<AV001_TDI_BIL_MASRAF_AVANS> _masrafAvansGetir;

        /// <summary>
        /// TDI_KOD_MEDENI_HAL
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDI_KOD_MEDENI_HAL> _MedeniHalGetir;

        public static VList<per_TDI_KOD_MESLEK> _MeslekGetir_Enter;

        /// <summary>
        /// TDIE_KOD_MODUL
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDIE_KOD_MODUL> _ModulKodGetir;

        ///<summary>
        /// TDIE_KOD_MODUL
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDIE_KOD_MODUL> _ModulKodGetirForKayitIliski;

        /// <summary>
        /// TDI_KOD_MUHASEBE_BELGE_TUR
        /// </summary>
        /// <param name="lue"></param
        public static VList<per_TDI_KOD_MUHASEBE_BELGE_TUR> _MuhasebeBelgeTurGetir;

        public static TList<TDI_KOD_MUHASEBE_AK> _MuhasebeDurumGetir;
        public static TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> _MuhasebeHareketAltKat;
        public static VList<per_TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> _MuhasebeHareketAltKategori;
        public static VList<per_TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> _MuhasebeHareketAltKategoriByAnakategoriIdAlti;
        public static VList<per_TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> _MuhasebeHareketAltKategoriForGorusme;

        ///<summary>
        /// TI_KOD_HARC_NISPI
        /// </summary>
        /// <param name="rLue"></param>
        public static List<AvukatProLib.Arama.per_TI_CET_NISPI_HARC> _NispiHarcKodGetir;

        public static VList<per_TDI_KOD_ODEME_TIP> _OdemeTipiGetir;
        public static VList<per_TI_KOD_ODEME_YERI> _odemeYeriGetir;
        public static VList<per_TDIE_KOD_OKUL> _OkulGetir;
        public static TList<AV001_TDI_BIL_FOY_ORTAKLIK> _OrtaklikFoyGetir;
        public static VList<per_AV001_TDIE_KOD_OZEL_KOD> _OzelKodGetir;
        public static VList<per_TDI_KOD_OZEL_TUTAR_KONU> _OzelTutarkonuGetir;
        public static List<AvukatProLib.Arama.per_AV001_TD_BIL_ARA_KARAR> _per_AV001_TD_BIL_ARA_KARAR;
        public static List<AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_NEW> _per_AV001_TD_BIL_HAZIRLIK;
        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_GEMI_UCAK_ARAC> _per_AV001_TDI_BIL_GEMI_UCAK_ARAC;
        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_I> _per_AV001_TDI_BIL_IS;
        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_IS_TARAF> _per_AV001_TDI_BIL_IS_TARAF;
        public static VList<per_AV001_TI_KOD_HESAP_TIP> _per_AV001_TI_KOD_HESAP_TIP;
        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> _per_CariGetir;
        public static VList<per_TDI_KOD_TEBLIGAT_SABLON> _per_TDI_KOD_TEBLIGAT_SABLON;
        public static VList<per_TI_KOD_FERAGAT_HESAP_KALEM> _per_TI_KOD_FERAGAT_HESAP_KALEM;
        public static VList<per_VDI_CARI_IS_TARAF> _per_VDI_CARI_IS_TARAFGetir;
        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> _perCariAvukatGetir;
        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_TEMINAT_MEKTUP> _perTeminatMektupGetir;

        /// <summary>
        /// TDI_KOD_POLICE_BRANS
        /// </summary>
        /// <param name="lue"></param
        public static VList<per_TDI_KOD_POLICE_BRANS> _PoliceBransGetir;

        public static List<AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE> _ProjeAdGetir;
        public static List<AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE_TARAF> _ProjeTarafGetir;
        public static List<AvukatProLib.Arama.per_R_BIRLESIK_TAKIPLER_SATI> _R_BIRLESIK_TAKIPLER_SATIS;
        public static VList<R_BIRLESIK_TAKIPLER_TEMINAT_MEKTUP> _R_BIRLESIK_TAKIPLER_TEMINAT_MEKTUPGetir;
        public static List<AvukatProLib.Arama.R_CARI_HESAP_DETAYLI> _R_CARI_HESAP_DETAYLIGetir;
        public static VList<per_TDI_KOD_REHIN_CINS> _RehinCinsGetir;

        /// <summary>
        /// TDI_KOD_REHIN_DURUM
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDI_KOD_REHIN_DURUM> _RehinDurumGetir;

        /// <summary>
        /// TDI_KOD_REHIN_HARC_ISTISNA_BELGE
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDI_KOD_REHIN_HARC_ISTISNA_BELGE> _RehinHarcIstisnaBelge;

        public static VList<per_TDI_KOD_REHIN_SICIL_TIP> _RehinSiciltipGetir;
        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_RUCU> _RucuGetir;

        ///<summary>
        /// TDI_KOD_RUCU_KAYNAK
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDI_KOD_RUCU_KAYNAK> _RucuKaynakKodGetir;

        /// <summary>
        /// TDIE_KOD_SABLON_ALT_KATEGORI
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDIE_KOD_SABLON_ALT_KATEGORI> _SablonAltKategoriGetir;

        public static List<AvukatProLib.Arama.VDIE_BIL_SABLON_DEGISKENLER> _SablonDegiskenler;
        public static List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> _SablonRaporGetir;
        public static List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> _SablonRaporGetirOtomatik;

        /// <summary>
        /// AV001_TDIE_BIL_SABLON_RAPOR_TIP
        /// </summary>
        /// <param name="rLue"></param>
        public static TList<AV001_TDIE_BIL_SABLON_RAPOR_TIP> _SablonRaporTipGetir;

        public static VList<per_AV001_TDI_KOD_SAHIS_DURUM> _SahisDurumGetir;

        /// <summary>
        /// TI_KOD_SATIS_ISTEME_SEKIL
        /// </summary>
        /// <param name="lue"></param>
        public static VList<per_TI_KOD_SATIS_ISTEME_SEKIL> _SatisIstemeSekliGetir;

        /// <summary>
        /// TI_KOD_SATIS_TURU
        /// </summary>
        /// <param name="lue"></param>
        public static VList<per_TI_KOD_SATIS_TURU> _SatisTuruGetir;

        /// <summary>
        /// TD_KOD_SAVCILIK_HUKUM
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TD_KOD_SAVCILIK_HUKUM> _SavcilikHukumGetir;

        public static VList<per_TDI_KOD_SEGMENT> _SegmentGetir;

        /// <summary>
        /// TDIE_KOD_SEKTOR
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDIE_KOD_SEKTOR> _SektorKodGetir;

        public static VList<per_TDI_KOD_SEMT> _SemtGetir;

        /// <summary>
        /// TD_KOD_SERBEST_BIRAKILMA_NEDEN
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TD_KOD_SERBEST_BIRAKILMA_NEDEN> _SerbestBirakilmaNedenGetir;

        public static VList<per_TDI_KOD_REHIN_SICIL_TIP> _SicilTipGetir;

        ///<summary>
        /// TDI_KOD_SIKAYET_KATEGORI
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDI_KOD_SIKAYET_KATEGORI> _SikayetKategoriGetir;

        /// <summary>
        /// TD_KOD_DAVA_TALEP
        /// </summary>
        /// <param name="lue"></param
        public static VList<per_TD_KOD_DAVA_TALEP> _SikayetKonuDavaTalepCezaGetir;

        /// <summary>
        /// TD_KOD_DAVA_TALEP
        /// </summary>
        /// <param name="lue"></param>
        public static VList<per_TD_KOD_DAVA_TALEP> _SikayetKonuDavaTalepGetir;

        public static List<AvukatProLib.Arama.per_TDI_KOD_DAVA_ADI> _sikayetNedenGetir;

        ///<summary>
        /// TI_KOD_SIKAYET_NEDEN
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TI_KOD_SIKAYET_NEDEN> _SikayetNedenGetir;

        public static List<AvukatProLib.Arama.VTD_SORUSTURMA_DOSYALAR> _SorusturmaDosyalar;
        public static VList<per_TDI_KOD_SOZLESME_ALT_TIP> _SozlesmeAltTipiHepsiGetir_Enter;
        public static List<per_TDI_KOD_SOZLESME_ALT_TIP> _SozlesmeAltTipiTipineGore;
        public static List<AvukatProLib.Arama.VTD_SOZLESME_DOSYALAR> _SozlesmeDosyalar;

        /// <summary>
        /// TDI_KOD_SOZLESME_DURUM
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDI_KOD_SOZLESME_DURUM> _SozlesmeDurumGetir;

        //TDI_KOD_SOZLESME_GELISME_ADIM
        public static VList<per_TDI_KOD_SOZLESME_GELISME_ADIM> _SozlesmeGelismeAdimGetir;

        public static TList<AV001_TDI_BIL_SOZLESME> _SozlesmeGetir;
        public static VList<per_TDI_KOD_SOZLESME_KATEGORILERI> _SozlesmeKategorisiGetir;
        public static VList<per_TDI_KOD_SOZLESME_OZEL> _SozlesmeOzelKod;

        ///<summary>
        /// TDI_KOD_SOZLESME_TAKYIDAT
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDI_KOD_SOZLESME_TAKYIDAT> _SozlesmeTakyidatGetir;

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_SOZLESME_TARAF> _SozlesmeTaraf;
        public static VList<per_TDI_KOD_SOZLESME_TIP> _SozlesmeTipiGetir_Enter;
        public static VList<per_TDI_KOD_SURE_OZEL> _SureOzelKodGetir;
        public static VList<per_TI_KOD_TAAHHUT_DURUM> _TaahhutDurumGetir;
        public static VList<per_TDI_KOD_TAHSILAT_DURUM> _TahsilatdurumGetir;
        public static VList<per_TI_KOD_TAKIP_TALEP> _TakipKonusuGetir_Enter;
        public static VList<per_TI_KOD_TAKIP_YOLU> _TakipYoluGetir;

        //TI_KOD_TAKIP_YONTEM
        public static VList<per_TI_KOD_TAKIP_YONTEM> _TakipYontemGetir;

        public static TList<TI_KOD_TALIMAT_ISLEM_TIP> _TalimatIslemGetir;
        public static VList<per_TDI_KOD_TAPU_MUDURLUK> _TapuMudurlukGetir;
        public static List<per_TDI_KOD_TAPU_MUDURLUK> _TapuMudurlukGetirIlceyeGore;
        public static TList<TDI_KOD_TARAF> _TarafKoduGetir;
        public static VList<per_TD_KOD_TARAF_STATU> _TarafStatuGetir;

        ///<summary>
        /// TDI_KOD_TARIH_KATEGORI
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDI_KOD_TARIH_KATEGORI> _TarihKategoriGetir;

        public static List<AvukatProLib.Arama.per_AV001_TD_BIL_FOY_TARAF> _TD_FoyTarafGetir;
        public static List<AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_TARAF> _TD_HazirlikTarafGetir;
        public static TList<TDIE_BIL_KULLANICI_SUBELERI> _TDIE_BIL_KULLANICI_SUBELERI;
        public static VList<per_TDI_KOD_TEBLIGAT_ALAN_BAGLANTI> _TebligatAlanBaglantiGetir_Enter;
        public static VList<per_TDI_KOD_TEBLIGAT_ALIM_SEKIL> _TebligatAlimSekli;
        public static VList<per_TDI_KOD_TEBLIGAT_ALINMAMA_NEDEN> _TebligatAlinmamaNedenGetir;

        /// <summary>
        /// TDI_KOD_TEBLIGAT_ALT_TUR
        /// </summary>
        /// <param name="lue"></param>
        public static VList<per_TDI_KOD_TEBLIGAT_ALT_TUR> _TebligatAltTurGetir;

        /// <summary>
        /// TDI_KOD_TEBLIGAT_ANA_TUR
        /// </summary>
        /// <param name="lue"></param>
        public static VList<per_TDI_KOD_TEBLIGAT_ANA_TUR> _TebligatAnaTurGetir;

        public static TList<AV001_TDI_BIL_TEBLIGAT> _TebligatGetir;
        public static VList<per_TDI_KOD_TEBLIGAT_KONU> _TebligatHacizIhbarnameKonuGetir;
        public static TList<TDI_KOD_TEBLIGAT_KONU> _TebligatKonuGetir;
        public static VList<per_TDI_KOD_TEBLIGAT_SEKIL> _TebligatSekliGetir;
        public static VList<per_TDI_KOD_TEBLIGAT_TESLIM_YER> _TebligatTeslimYerGetir;

        //TDI_KOD_TEBLIGAT_TIP
        public static TList<TDI_KOD_TEBLIGAT_TIP> _TebligatTipGetir;

        //
        ///<summary>
        /// TDI_KOD_POLICE_TEMINAT_ALT_TIP
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDI_KOD_POLICE_TEMINAT_ALT_TIP> _TeminatAltTipGetir;

        public static TList<AV001_TDI_BIL_TEMINAT_MEKTUP> _TeminatMektupGetir;
        public static VList<per_TI_KOD_TEMINAT_TUR> _TeminatTuruGetir;
        public static List<AvukatProLib.Arama.per_TEMSIL_TARAF_SORUMLU_BIRLESIK> _TEMSIL_TARAF_SORUMLU_BIRLESIK;
        public static VList<per_TDI_KOD_TEMSIL_SEKIL> _TemsilSekliGetir;
        public static VList<per_TDI_KOD_TEMSIL_SONA_ERME_SEBEP> _TemsilSonaErmeSebepGetir;
        public static VList<per_TDI_KOD_TEMSIL_TIP> _TemsilTipiGetir;
        public static VList<per_TDI_KOD_TEMSIL_TUR> _TemsilTuruGetir;
        public static VList<per_TD_KOD_TEMYIZ_TIP> _TemyizTipGetir;

        //TI_KOD_TESPIT_KONUSU
        public static VList<per_TI_KOD_TESPIT_KONUSU> _TespitKonusuGetir;

        /// <summary>
        /// TD_KOD_TESPIT_OZEL
        /// </summary>
        /// <param name="rLue"></param>
        public static TList<TD_KOD_TESPIT_OZEL> _TespitOzelKodGetir;

        public static VList<per_TI_KOD_ALACAK_NEDEN> _TI_KOD_AlacakNedeniDoldur;

        ///<summary>
        /// TD_KOD_TUTUKLANMA_TIP
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TD_KOD_TUTUKLANMA_TIP> _TutuklamaTipGetir;

        public static VList<per_TDI_KOD_ULKE> _UlkeGetir;

        /// <summary>
        /// TS_KOD_URUN_ALT_KATEGORI
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TS_KOD_URUN_ALT_KATEGORI> _UrunAltKategoriGetir;

        /// <summary>
        /// TS_KOD_URUN_KATEGORI
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TS_KOD_URUN_KATEGORI> _UrunKategoriGetir;

        /// <summary>
        /// TS_KOD_URUN_SINIF_KODLARI
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TS_KOD_URUN_SINIF_KODLARI> _UrunSinifKodlariGetir;

        public static VList<per_TDIE_KOD_UYARI_TIP> _UyariTipDoldur;

        /// <summary>
        /// TDI_KOD_UYRUK
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDI_KOD_UYRUK> _UyrukGetir;

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_FATURA> _VDI_BIL_FATURA_FOR_CARI_TAKIP;
        public static VList<VDI_BIL_IHTIYATI_TEDBIR_FOR_CARI_TAKIP> _VDI_BIL_IHTIYATI_TEDBIR_FOR_CARI_TAKIP;
        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_KIYMETLI_EVRAK> _VDIE_PROJE_KIYMETLI_EVRAK;
        public static VList<per_TDI_KOD_SOZLESME_KATEGORILERI> _VekaletSozlesmeGetir;
        public static List<AvukatProLib.Arama.per_TI_BIL_YASAL_SURE> _YasalSureGetir;
        public static TList<AV001_TDI_BIL_YAYIN> _YayinkitapGetir;

        /// <summary>
        /// TDI_KOD_YAYIN_TURLERI
        /// </summary>
        /// <param name="rLue"></param>
        public static VList<per_TDI_KOD_YAYIN_TURLERI> _YayinTurleriGetir;

        //TDIE_KOD_YAZI_STIL
        public static TList<TDIE_KOD_YAZI_STIL> _YaziStilGetir;

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> _YetkiliCariIsmiGetir_Enter;
        public static bool Enerjimi = false;
        public static int KrediBorclusu = 0;
        public static int PaketAdi = 0;
        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> per_TSorumluAvukatGetir;
        public static Dictionary<int, List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>> SablonRaporlar = new Dictionary<int, List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>>();
        public static bool Telekomunukasyonmu = false;
        private static AvukatProLib.Arama.AvpDataContext _context;
        private static byte alanNo;

        //public static void FoyOzelKodGetir(LookUpEdit lue)
        //{
        //    lue.Properties.Columns.Clear();
        //    lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 20, "Kod") });
        //    lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.AV001_TDI_KOD_FOY_OZELProvider.GetAll();
        //    lue.Properties.DisplayMember = "KOD";
        //    lue.Properties.ValueMember = "ID";
        //    lue.Properties.NullText = "Seç";
        //}
        /// <summary>
        /// Föy Özel kodlarýnýn getirilmesi için kullanýlan method. Sadece belirtilen alan ve ilgili modül için görünmesi gereken Özel kodlarý getirir.
        /// </summary>
        /// <param name="lue">Ýþlemin etkileyeceði control</param>
        /// <param name="AlanNo">Özel kod numarasý 1,2,3,4 olabilir </param>
        /// <param name="modul">Modül sadece ÝCRA,DAVA,SÖZLEÞME,SORUÞTURMA olabilir</param>
        /// <exception cref="Exception"></exception>
        ///
        private static Modul modul;

        private static List<AvukatProLib.Arama.per_AV001_TDI_BIL_KAYIT_ILISKI> per_AV001_TDI_BIL_KAYIT_ILISKI;

        /// <summary>
        /// Bütün Carileri getiren method
        /// </summary>
        /// <param name="lue">Verilerin atanacaðý kontrol</param>
        ///

        public static AvukatProLib.Arama.AvpDataContext context
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;
            }
        }

        public static List<TDI_KOD_DOVIZ_TIP> DovizSource
        {
            get
            {
                if (_DovizSource == null)
                    _DovizSource = new List<TDI_KOD_DOVIZ_TIP>(DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetAll());
                return _DovizSource;
            }
        }

        public static void AdliBirimAdliyeGetir(RepositoryItemLookUpEdit lue)
        {
            AdliBirimAdliyeGetir_Enter(lue, EventArgs.Empty);
        }

        public static void AdliBirimAdliyeGetir(LookUpEdit lue)
        {
            AdliBirimAdliyeGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void AdliBirimAdliyeGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                //try
                //{
                //    if (_AdliBirimAdliyeGetir == null)
                //    {
                //        if (CodeInfo<per_TDI_KOD_ADLI_BIRIM_ADLIYE>.ListeVarmi(typeof(per_TDI_KOD_ADLI_BIRIM_ADLIYE)))
                //            _AdliBirimAdliyeGetir = CodeInfo<per_TDI_KOD_ADLI_BIRIM_ADLIYE>.ListeGetir(typeof(per_TDI_KOD_ADLI_BIRIM_ADLIYE)) as VList<per_TDI_KOD_ADLI_BIRIM_ADLIYE>;
                //        else
                //        {
                //            _AdliBirimAdliyeGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetAll();
                //            CodeInfo<per_TDI_KOD_ADLI_BIRIM_ADLIYE>.ListeKaydet(_AdliBirimAdliyeGetir, typeof(per_TDI_KOD_ADLI_BIRIM_ADLIYE));
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    BelgeUtil.ErrorHandler.Catch(null, ex); return;
                //}

                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;

                lue.Columns.Clear();
                //lue.DataSource = _AdliBirimAdliyeGetir;
                lue.DataSource = cn.GetDataTable("select ID, IL, ILCE, ADLIYE from per_TDI_KOD_ADLI_BIRIM_ADLIYE(nolock)");
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ADLIYE", 20, "Adliye"), new LookUpColumnInfo("IL", 20, "Ýl"), new LookUpColumnInfo("ILCE", 20, "Ýlce") });
                lue.DisplayMember = "ADLIYE";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void AdliBirimAdliyeGetirSadeceAdliye(RepositoryItemLookUpEdit lue)
        {
            AdliBirimAdliyeGetirSadeceAdliye_Enter(lue, EventArgs.Empty);
        }

        public static void AdliBirimAdliyeGetirSadeceAdliye_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                lue.Columns.Clear();

                if (_AdliBirimAdliyeGetirSadeceAdliye == null)
                    _AdliBirimAdliyeGetirSadeceAdliye = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetAll();

                lue.DataSource = _AdliBirimAdliyeGetirSadeceAdliye;
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ADLIYE", 20, "Adliye") });
                lue.DisplayMember = "ADLIYE";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void AdliBirimBolumDoldur(RepositoryItemLookUpEdit lue)
        {
            AdliBirimBolumDoldur_Enter(lue, EventArgs.Empty);
        }

        public static void AdliBirimBolumDoldur_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_AdliBirimBolumGetir == null)
                {
                    _AdliBirimBolumGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ADLI_BIRIM_BOLUMProvider.GetAll();
                }
                lue.BeginUpdate();
                lue.DataSource = _AdliBirimBolumGetir.FindAll(item => item.ID != 4 || item.ID != 8 || item.ID != 83);
                lue.DisplayMember = "BIRIM";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("BIRIM", "Adli Birim Bölüm", 100));
                lue.EndUpdate();
            }
        }

        /// <summary>
        /// TDI_KOD_ADLI_BIRIM_BOLUM
        /// </summary>
        /// <param name="lue"></param>
        public static void AdliBirimBolumGetir(RepositoryItemLookUpEdit lue)
        {
            AdliBirimBolumGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_ADLI_BIRIM_BOLUM
        /// </summary>
        /// <param name="lue"></param
        public static void AdliBirimBolumGetir(LookUpEdit lue)
        {
            AdliBirimBolumGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void AdliBirimBolumGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_AdliBirimBolumGetir == null)
                {
                    if (_AdliBirimBolumGetir == null)
                    {
                        if (CodeInfo<per_TDI_KOD_ADLI_BIRIM_BOLUM>.ListeVarmi(typeof(per_TDI_KOD_ADLI_BIRIM_BOLUM)))
                            _AdliBirimBolumGetir = CodeInfo<per_TDI_KOD_ADLI_BIRIM_BOLUM>.ListeGetir(typeof(per_TDI_KOD_ADLI_BIRIM_BOLUM)) as VList<per_TDI_KOD_ADLI_BIRIM_BOLUM>;
                        else
                        {
                            _AdliBirimBolumGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_BOLUMProvider.GetAll();
                            CodeInfo<per_TDI_KOD_ADLI_BIRIM_BOLUM>.ListeKaydet(_AdliBirimBolumGetir, typeof(per_TDI_KOD_ADLI_BIRIM_BOLUM));
                        }
                    }
                }
                lue.DataSource = _AdliBirimBolumGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "BIRIM";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("BIRIM", "Adli Birim Bölüm", 100));
            }
        }

        public static void AdliBirimBolumGetirForDavaNedenAyarlar(RepositoryItemLookUpEdit lue)
        {
            AdliBirimBolumGetirForDavaNedenAyarlar_Enter(lue, EventArgs.Empty);
        }

        public static void AdliBirimBolumGetirForDavaNedenAyarlar_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_AdliBirimBolumGetir == null)
                {
                    _AdliBirimBolumGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ADLI_BIRIM_BOLUMProvider.GetAll();
                }
                lue.NullText = "Seç";
                lue.DataSource = _AdliBirimBolumGetir;
                lue.DisplayMember = "BIRIM";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("BIRIM", "Adli Birim Bölüm", 100));
            }
        }

        public static void AdliBirimBolumGetirIDKontrollu(RepositoryItemLookUpEdit rLue)
        {
            AdliBirimBolumGetirIDKontrollu_Enter(rLue, EventArgs.Empty);
        }

        public static void AdliBirimBolumGetirIDKontrollu_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (BelgeUtil.Inits._AdliBirimBolumGetir == null)
                {
                    if (CodeInfo<per_TDI_KOD_ADLI_BIRIM_BOLUM>.ListeVarmi(typeof(per_TDI_KOD_ADLI_BIRIM_BOLUM)))
                        _AdliBirimBolumGetir = CodeInfo<per_TDI_KOD_ADLI_BIRIM_BOLUM>.ListeGetir(typeof(per_TDI_KOD_ADLI_BIRIM_BOLUM)) as VList<per_TDI_KOD_ADLI_BIRIM_BOLUM>;
                    else
                    {
                        _AdliBirimBolumGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_BOLUMProvider.GetAll();
                        CodeInfo<per_TDI_KOD_ADLI_BIRIM_BOLUM>.ListeKaydet(_AdliBirimBolumGetir, typeof(per_TDI_KOD_ADLI_BIRIM_BOLUM));
                    }
                }
                VList<per_TDI_KOD_ADLI_BIRIM_BOLUM> obj = BelgeUtil.Inits._AdliBirimBolumGetir;
                int[] id = new int[] { 3, 4, 8, 83, 34, 35, 36 };
                for (int i = 0; i < id.Length; i++)
                {
                    obj.Remove(obj.Find("ID", id[i]));
                }
                rLue.BeginUpdate();
                rLue.DataSource = obj;
                rLue.DisplayMember = "BIRIM";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("BIRIM", "Adli Birim Bölüm", 100));
                rLue.EndUpdate();
            }
        }

        public static void AdliBirimGorevGetir(LookUpEdit lue)
        {
            AdliBirimGorevGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void AdliBirimGorevGetir(RepositoryItemLookUpEdit lue)
        {
            AdliBirimGorevGetir_Enter(lue, EventArgs.Empty);
        }

        public static void AdliBirimGorevGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_AdliBirimGorevGetir_Enter == null)
                {
                    if (CodeInfo<per_TDI_KOD_ADLI_BIRIM_GOREV>.ListeVarmi(typeof(per_TDI_KOD_ADLI_BIRIM_GOREV)))
                        _AdliBirimGorevGetir_Enter = CodeInfo<per_TDI_KOD_ADLI_BIRIM_GOREV>.ListeGetir(typeof(per_TDI_KOD_ADLI_BIRIM_GOREV)) as VList<per_TDI_KOD_ADLI_BIRIM_GOREV>;
                    else
                    {
                        _AdliBirimGorevGetir_Enter = DataRepository.per_TDI_KOD_ADLI_BIRIM_GOREVProvider.GetAll();
                        CodeInfo<per_TDI_KOD_ADLI_BIRIM_GOREV>.ListeKaydet(_AdliBirimGorevGetir_Enter, typeof(per_TDI_KOD_ADLI_BIRIM_GOREV));
                    }
                }
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("GOREV", 20, "Görev"), new LookUpColumnInfo("ACIKLAMA", 20, "Açýklama") });
                lue.DataSource = _AdliBirimGorevGetir_Enter;
                lue.DisplayMember = "GOREV";
                lue.ValueMember = "ID";
            }
        }

        public static void AdliBirimGorevGetirSadeceN(LookUpEdit lue)
        {
            AdliBirimGorevGetirSadeceN_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void AdliBirimGorevGetirSadeceN(RepositoryItemLookUpEdit lue)
        {
            AdliBirimGorevGetirSadeceN_Enter(lue, EventArgs.Empty);
        }

        public static void AdliBirimGorevGetirSadeceN_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_AdliBirimGorevGetirSadeceN_Enter == null)
                    _AdliBirimGorevGetirSadeceN_Enter = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ADLI_BIRIM_GOREVProvider.Get(" ADLI_BIRIM_BOLUM_KOD='N'", "GOREV DESC");
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("GOREV", 20, "Görev"), new LookUpColumnInfo("ACIKLAMA", 20, "Açýklama") });
                lue.DataSource = _AdliBirimGorevGetirSadeceN_Enter;

                //Find("ADLI_BIRIM_BOLUM_KOD='N'");
                lue.DisplayMember = "GOREV";
                lue.ValueMember = "ID";
            }
        }

        /// <summary>
        /// TDI_KOD_ADLI_BIRIM_NO
        /// </summary>
        /// <param name="lue"></param>
        public static void AdliBirimNoGetir(RepositoryItemLookUpEdit lue)
        {
            AdliBirimNoGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_ADLI_BIRIM_NO
        /// </summary>
        /// <param name="lue"></param
        public static void AdliBirimNoGetir(LookUpEdit lue)
        {
            AdliBirimNoGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void AdliBirimNoGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_AdliBirimNoGetir == null)
                {
                    if (_AdliBirimNoGetir == null)
                    {
                        if (CodeInfo<per_TDI_KOD_ADLI_BIRIM_NO>.ListeVarmi(typeof(per_TDI_KOD_ADLI_BIRIM_NO)))
                            _AdliBirimNoGetir = CodeInfo<per_TDI_KOD_ADLI_BIRIM_NO>.ListeGetir(typeof(per_TDI_KOD_ADLI_BIRIM_NO)) as VList<per_TDI_KOD_ADLI_BIRIM_NO>;
                        else
                        {
                            _AdliBirimNoGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_NOProvider.GetAll();
                            CodeInfo<per_TDI_KOD_ADLI_BIRIM_NO>.ListeKaydet(_AdliBirimNoGetir, typeof(per_TDI_KOD_ADLI_BIRIM_NO));
                        }
                    }
                }
                lue.DataSource = _AdliBirimNoGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "NO";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("NO", "Adli Birim No", 100));
            }
        }

        public static int? AdliBirimNoIdGetir(int adliBirimNo)
        {
            int? i = null;
            try
            {
                //TODO: VList dönüyor.
                TDI_KOD_ADLI_BIRIM_NO no = DataRepository.TDI_KOD_ADLI_BIRIM_NOProvider.GetByNO(adliBirimNo.ToString());
                if (no != null)
                {
                    i = no.ID;
                }
            }
            catch (Exception ex)
            {
                //Hata yakalayýcý methodumuzu çaðýrýyoruz.
                BelgeUtil.ErrorHandler.Catch(new Inits(), ex);
            }
            return i;
        }

        public static int? AdliBirimNoIdGetir(string no)
        {
            int k = 0;
            int.TryParse(no, out k);
            return AdliBirimNoIdGetir(k);
        }

        public static void AdresDurumGetir(RepositoryItemLookUpEdit rLue)
        {
            AdresDurumGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void AdresDurumGetir(LookUpEdit rLue)
        {
            AdresDurumGetir_Enter(rLue.Properties, EventArgs.Empty);
        }

        public static void AdresDurumGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_AdresDurumGetir == null)
                {
                    _AdresDurumGetir = DataRepository.per_AV001_TDI_KOD_ADRES_DURUMProvider.GetAll();
                }
                rLue.DataSource = _AdresDurumGetir;
                rLue.DisplayMember = "ADRES_DURUM";
                rLue.ValueMember = "ID";

                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("ADRES_DURUM", 30, "Adres Durum"));
            }
        }

        public static void AdresTurGetir(LookUpEdit lue)
        {
            AdresTurGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void AdresTurGetir(RepositoryItemLookUpEdit lue)
        {
            AdresTurGetir_Enter(lue, EventArgs.Empty);
        }

        public static void AdresTurGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_AdresTurGetir_Enter == null)
                {
                    _AdresTurGetir_Enter = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ADRES_TURProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_ADRES_TUR.TDI_KOD_ADRES_TURGetir();
                }
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ADRES_TUR", 10, "Tür") });
                lue.DataSource = _AdresTurGetir_Enter;
                lue.DisplayMember = "ADRES_TUR";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> AlacakliTarafByFoy(AV001_TI_BIL_FOY foy, RepositoryItemLookUpEdit[] controls)
        {
            if (foy == null) return null;

            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = cariList = AlacakliTarafGetir(foy);

            foreach (RepositoryItemLookUpEdit rLue in controls)
            {
                rLue.DataSource = cariList;
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.AddRange(new LookUpColumnInfo[]
                    {
                        new LookUpColumnInfo("KOD", 10, "Kod"),
                        new LookUpColumnInfo("AD", 30, "Ad")
                    });

                rLue.NullText = "Seç";
            }
            return cariList;
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> AlacakliTarafByFoy(AV001_TD_BIL_FOY foy, RepositoryItemLookUpEdit[] controls)
        {
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>();

            List<AvukatProLib.Arama.per_AV001_TD_BIL_FOY_TARAF> _TarafGetirByFoy = context.per_AV001_TD_BIL_FOY_TARAFs.Where(item => item.DAVA_FOY_ID == foy.ID).ToList();

            if (_per_CariGetir == null)
            {
                _per_CariGetir = context.per_AV001_TDI_BIL_CARIs.OrderBy(item => item.AD).ToList();
            }

            _TarafGetirByFoy.ForEach(item =>
            {
                AvukatProLib.Arama.per_AV001_TDI_BIL_CARI carim = _per_CariGetir.SingleOrDefault(cari => item.CARI_ID == cari.ID);
                if (carim != null) cariList.Add(carim);
            });

            foreach (RepositoryItemLookUpEdit rLue in controls)
            {
                rLue.DataSource = cariList;
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.AddRange(new LookUpColumnInfo[]
                    {
                        new LookUpColumnInfo("KOD", 10, "Kod"),
                        new LookUpColumnInfo("AD", 30, "Ad")
                    });

                rLue.NullText = "Seç";
            }

            return cariList;
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> AlacakliTarafByFoy(AV001_TD_BIL_HAZIRLIK foy, RepositoryItemLookUpEdit[] controls)
        {
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>();
            List<AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_TARAF> _TarafGetirByFoy = context.per_AV001_TD_BIL_HAZIRLIK_TARAFs.Where(item => item.HAZIRLIK_ID == foy.ID && (item.SIFAT == TarafSifat.YAKINAN.ToString() || item.SIFAT == TarafSifat.ALACAKLI.ToString() || item.SIFAT == TarafSifat.DAVALI.ToString())).ToList();

            if (_per_CariGetir == null)
            {
                _per_CariGetir = context.per_AV001_TDI_BIL_CARIs.ToList();
            }

            _TarafGetirByFoy.ForEach(item =>
            {
                AvukatProLib.Arama.per_AV001_TDI_BIL_CARI carim = _per_CariGetir.Single(cari => item.CARI_ID == cari.ID);
                if (carim != null) cariList.Add(carim);
            });

            foreach (RepositoryItemLookUpEdit rLue in controls)
            {
                rLue.DataSource = cariList;
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.AddRange(new LookUpColumnInfo[]
                    {
                        new LookUpColumnInfo("KOD", 10, "Kod"),
                        new LookUpColumnInfo("AD", 30, "Ad")
                    });

                rLue.NullText = "Seç";
            }

            return cariList;
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> AlacakliTarafGetir(AV001_TI_BIL_FOY foy)
        {
            if (foy == null) return null;
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>();

            List<AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF> _TarafGetirByFoy = context.per_AV001_TI_BIL_FOY_TARAFs.Where(item => item.ICRA_FOY_ID == foy.ID && item.TARAF_KODU == (byte)TarafKodu.Muvekkil).ToList();

            if (_per_CariGetir == null)
            {
                _per_CariGetir = context.per_AV001_TDI_BIL_CARIs.OrderBy(item => item.AD).ToList();
            }

            _TarafGetirByFoy.ForEach(item =>
            {
                AvukatProLib.Arama.per_AV001_TDI_BIL_CARI carim = _per_CariGetir.SingleOrDefault(cari => item.CARI_ID == cari.ID);
                if (carim != null) cariList.Add(carim);
            });
            return cariList;
        }

        public static void AlacakNedenByFoy(AV001_TDIE_BIL_PROJE proje, RepositoryItemGridLookUpEdit rGlue)
        {
            var alacaklar = DataRepository.V_PROJE_ALACAK_NEDEN_BILGILERI_TAKIPLI_TAKIPSIZProvider.GetByProjeId(proje.ID);

            rGlue.View.Columns[0].ColumnEdit = null;
            rGlue.View.Columns[0].FieldName = "ALACAK_NEDENI";

            GridColumn gColumnTutar = new GridColumn();
            GridColumn gColumnTutarDoviz = new GridColumn();
            GridColumn gColumnVadeTarihi = new GridColumn();

            RepositoryItemLookUpEdit rLueDoviz = new RepositoryItemLookUpEdit();
            RepositoryItemSpinEdit rSpinTutar = new RepositoryItemSpinEdit();

            Inits.DovizTipGetir(rLueDoviz);
            Inits.ParaBicimiAyarla(rSpinTutar);

            gColumnTutar.FieldName = "TUTARI";
            gColumnTutarDoviz.FieldName = "TUTAR_DOVIZ_ID";
            gColumnVadeTarihi.FieldName = "VADE_TARIHI";

            gColumnTutar.Caption = "Tutarý";
            gColumnTutarDoviz.Caption = " ";
            gColumnVadeTarihi.Caption = "Vade Tarihi";

            gColumnTutarDoviz.ColumnEdit = rLueDoviz;
            gColumnTutar.ColumnEdit = rSpinTutar;

            gColumnTutar.VisibleIndex = 1;
            gColumnTutarDoviz.VisibleIndex = 2;
            gColumnVadeTarihi.VisibleIndex = 3;

            rGlue.View.Columns.Add(gColumnTutar);
            rGlue.View.Columns.Add(gColumnTutarDoviz);
            rGlue.View.Columns.Add(gColumnVadeTarihi);

            rGlue.ValueMember = "ID";
            rGlue.DisplayMember = "ALACAK_NEDENI";
            rGlue.NullText = "Seç";
            rGlue.DataSource = alacaklar;
        }

        public static void AlacakNedenByFoy(AV001_TI_BIL_FOY foy, RepositoryItemGridLookUpEdit rGlue)
        {
            if (foy == null) return;
            if (_AlacakNEdenGetir == null)
            {
                _AlacakNEdenGetir = context.per_AV001_TI_BIL_ALACAK_NEDENs.ToList();
            }
            var alacaklar = _AlacakNEdenGetir.FindAll(vi => vi.ICRA_FOY_ID == foy.ID);

            GridColumn gColumnAlacakNedeni = new GridColumn();
            GridColumn gColumnTutar = new GridColumn();
            GridColumn gColumnTutarDoviz = new GridColumn();
            GridColumn gColumnVadeTarihi = new GridColumn();

            RepositoryItemLookUpEdit rLueDoviz = new RepositoryItemLookUpEdit();
            RepositoryItemSpinEdit rSpinTutar = new RepositoryItemSpinEdit();

            Inits.DovizTipGetir(rLueDoviz);
            Inits.ParaBicimiAyarla(rSpinTutar);

            gColumnAlacakNedeni.FieldName = "ALACAK_NEDENI";
            gColumnTutar.FieldName = "TUTARI";
            gColumnTutarDoviz.FieldName = "TUTAR_DOVIZ_ID";
            gColumnVadeTarihi.FieldName = "VADE_TARIHI";

            gColumnAlacakNedeni.Caption = "Alacak Nedeni";
            gColumnTutar.Caption = "Tutarý";
            gColumnTutarDoviz.Caption = " ";
            gColumnVadeTarihi.Caption = "Vade Tarihi";

            gColumnTutarDoviz.ColumnEdit = rLueDoviz;
            gColumnTutar.ColumnEdit = rSpinTutar;

            gColumnAlacakNedeni.VisibleIndex = 0;
            gColumnTutar.VisibleIndex = 1;
            gColumnTutarDoviz.VisibleIndex = 2;
            gColumnVadeTarihi.VisibleIndex = 3;

            rGlue.View.Columns.Add(gColumnAlacakNedeni);
            rGlue.View.Columns.Add(gColumnTutar);
            rGlue.View.Columns.Add(gColumnTutarDoviz);
            rGlue.View.Columns.Add(gColumnVadeTarihi);

            rGlue.DataSource = alacaklar;
            rGlue.ValueMember = "ALACAK_NEDEN_ID";
            rGlue.DisplayMember = "ALACAK_NEDENI";
            rGlue.NullText = "Seç";
        }

        public static void AlacakNedenByFoy(RepositoryItemLookUpEdit rLue)
        {
            if (_AlacakNEdenGetir == null)
            {
                _AlacakNEdenGetir = context.per_AV001_TI_BIL_ALACAK_NEDENs.ToList();
            }

            //TList<AV001_TI_BIL_ALACAK_NEDEN> AlacakNeden = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetAll();
            //DataTable dt = new DataTable();
            //dt.Columns.Add("ID");
            //dt.Columns.Add("Alacak Nedeni");
            //dt.Columns.Add("Tutarý");
            //dt.Columns.Add("Vade T");
            //TList<TI_KOD_ALACAK_NEDEN> AlacakNedenKod = new TList<TI_KOD_ALACAK_NEDEN>();
            //foreach (AV001_TI_BIL_ALACAK_NEDEN item in AlacakNeden)
            //{
            //    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TI_KOD_ALACAK_NEDEN));
            //    if (item.ALACAK_NEDEN_KOD_ID != null)
            //        dt.Rows.Add(item.ID, item.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI.ToString(), item.TUTARI, item.VADE_TARIHI);

            //}

            rLue.DataSource = _AlacakNEdenGetir;
            rLue.DisplayMember = "ALACAK_NEDENI";
            rLue.ValueMember = "ID";
            rLue.NullText = "Seç";
            rLue.Columns.Clear();
            //rLue.Columns.Add(new LookUpColumnInfo("Alacak Nedeni", "Alacak Nedeni", 100));
            //rLue.Columns.Add(new LookUpColumnInfo("Tutarý", "Tutarý", 100));
            //rLue.Columns.Add(new LookUpColumnInfo("Vade T", "Vade Tarihi", 100));
            rLue.Columns.Add(new LookUpColumnInfo("ALACAK_NEDENI", "Alacak Nedeni", 100));
            rLue.Columns.Add(new LookUpColumnInfo("TUTARI", "Tutarý", 100));
            rLue.Columns.Add(new LookUpColumnInfo("VADE_TARIHI", "Vade Tarihi", 100));
        }

        public static void AlacakNedenGetir(RepositoryItemLookUpEdit lue, bool depoAlacagimi, List<String> myAlacakNedenList)
        {
            _TI_KOD_AlacakNedeniDoldur = DataRepository.per_TI_KOD_ALACAK_NEDENProvider.GetAll();

            var alacakNedenList = _TI_KOD_AlacakNedeniDoldur.Where(ndn => ndn.DEPO_ALACAGI == depoAlacagimi && ndn.TAKIP_TALEP_KOD_ID == 15);

            alacakNedenList.OrderBy(vi => vi.ALACAK_NEDENI);
            lue.DataSource = alacakNedenList;
            lue.NullText = "Seç";
            lue.DisplayMember = "ALACAK_NEDENI";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ALACAK_NEDENI", "Alacak Neden", 100));
        }

        public static void AlacakNEdenGetir(RepositoryItemLookUpEdit lue)
        {
            // AlacakNEdenGetir_Enter(lue, EventArgs.Empty);
            AlacakNedenKodGetir_Enter(lue, EventArgs.Empty);
        }

        public static void AlacakNEdenGetir(LookUpEdit lue)
        {
            AlacakNEdenGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        /// <summary>
        /// AV001_TI_BIL_ALACAK_NEDEN
        /// </summary>
        /// <param name="lue"></param>
        /// <summary>
        /// AV001_TI_BIL_ALACAK_NEDEN
        /// </summary>
        /// <param name="lue"></param>
        public static void AlacakNEdenGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_AlacakNEdenGetir == null)
                {
                    _AlacakNEdenGetir = context.per_AV001_TI_BIL_ALACAK_NEDENs.ToList();
                }
                lue.NullText = "Seç";
                lue.DataSource = _AlacakNEdenGetir;
                lue.DisplayMember = "ALACAK_NEDENI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ALACAK_NEDENI", "Alacak Neden", 100));
            }
        }

        public static List<AvukatProLib.Arama.per_AV001_TI_BIL_ALACAK_NEDEN> AlacakNedenGetirByIcraFoyId(int icraFoyId)
        {
            if (_AlacakNEdenGetir != null)
                return _AlacakNEdenGetir.FindAll(item => item.ICRA_FOY_ID == icraFoyId);
            return context.per_AV001_TI_BIL_ALACAK_NEDENs.Where(item => item.ICRA_FOY_ID == icraFoyId).ToList();
        }

        public static List<AvukatProLib.Arama.per_AV001_TI_BIL_ALACAK_NEDEN> AlacakNedenGetirByIdList(List<int> idList)
        {
            if (_AlacakNEdenGetir != null)
                return (from item in _AlacakNEdenGetir where idList.Contains(item.ALACAK_NEDEN_ID) select item).ToList();
            return (from item in context.per_AV001_TI_BIL_ALACAK_NEDENs where idList.Contains(item.ALACAK_NEDEN_ID) select item).ToList();
        }

        //ALacak neden Doldurma
        public static void AlacakNedeniDoldur(RepositoryItemLookUpEdit[] lue, int takipTalepId)
        {
            if (_TI_KOD_AlacakNedeniDoldur == null)
            {
                _TI_KOD_AlacakNedeniDoldur = DataRepository.per_TI_KOD_ALACAK_NEDENProvider.GetAll();
            }
            var obj = _TI_KOD_AlacakNedeniDoldur.FindAll(item => item.TAKIP_TALEP_KOD_ID == takipTalepId);

            foreach (RepositoryItemLookUpEdit c in lue)
            {
                c.DataSource = obj;
                c.DisplayMember = "ALACAK_NEDENI";
                c.ValueMember = "ID";
                c.Columns.Clear();
                c.Columns.Add(new LookUpColumnInfo("ALACAK_NEDENI", "Alacak neden Kod", 40));
            }
        }

        public static void AlacakNedenKodGetir(LookUpEdit lue)
        {
            AlacakNedenKodGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void AlacakNedenKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TI_KOD_AlacakNedeniDoldur == null)
                {
                    if (CodeInfo<per_TI_KOD_ALACAK_NEDEN>.ListeVarmi(typeof(per_TI_KOD_ALACAK_NEDEN)))
                        _TI_KOD_AlacakNedeniDoldur = CodeInfo<per_TI_KOD_ALACAK_NEDEN>.ListeGetir(typeof(per_TI_KOD_ALACAK_NEDEN)) as VList<per_TI_KOD_ALACAK_NEDEN>;
                    else
                    {
                        _TI_KOD_AlacakNedeniDoldur = DataRepository.per_TI_KOD_ALACAK_NEDENProvider.GetAll();
                        CodeInfo<per_TI_KOD_ALACAK_NEDEN>.ListeKaydet(_TI_KOD_AlacakNedeniDoldur, typeof(per_TI_KOD_ALACAK_NEDEN));
                    }
                }
                lue.NullText = "Seç";
                lue.DataSource = _TI_KOD_AlacakNedeniDoldur;
                lue.DisplayMember = "ALACAK_NEDENI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ALACAK_NEDENI", "Alacak neden Kod", 40));
            }
        }

        //TI_KOD_ALACAK_NEDEN
        public static void AlacakNedenKodGetir1(RepositoryItemLookUpEdit rLue)
        {
            AlacakNedenKodGetir1_Enter(rLue, EventArgs.Empty);
        }

        public static void AlacakNedenKodGetir1_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_TI_KOD_AlacakNedeniDoldur == null)
                {
                    _TI_KOD_AlacakNedeniDoldur = DataRepository.per_TI_KOD_ALACAK_NEDENProvider.GetAll();
                }
                rLue.DataSource = _TI_KOD_AlacakNedeniDoldur;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "ALACAK_NEDENI";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("ALACAK_NEDENI", "Alacak Neden Kod", 100));
            }
        }

        //Find(string.Format("TAKIP_TALEP_KOD_ID={0}", takipTalepId));
        public static void AlacakNedenKodGetirByFormTip(LookUpEdit lue, int formTipID)
        {
            lue.Properties.NullText = "Seç";
            AlacakNedenKodGetirByFormTip_Enter(lue, EventArgs.Empty);
            lue.Tag = formTipID;
        }

        public static void AlacakNedenKodGetirByFormTip(RepositoryItemLookUpEdit rLue, int formId)
        {
            if (_TI_KOD_AlacakNedeniDoldur == null)
            {
                _TI_KOD_AlacakNedeniDoldur = DataRepository.per_TI_KOD_ALACAK_NEDENProvider.GetAll();
            }
            rLue.DataSource = _TI_KOD_AlacakNedeniDoldur.FindAll(vi => vi.FORM_TIP_ID == formId);
            rLue.ValueMember = "ID";
            rLue.DisplayMember = "ALACAK_NEDENI";

            LookUpColumnInfo ID = new LookUpColumnInfo("ID", 20);
            LookUpColumnInfo ALACAK_NEDENI = new LookUpColumnInfo("ALACAK_NEDENI", 40, "Alacak Nedeni");

            rLue.Columns.Clear();
            rLue.Columns.AddRange(new LookUpColumnInfo[] { ID, ALACAK_NEDENI });
        }

        public static void AlacakNedenKodGetirByFormTip_Enter(object sender, EventArgs e)
        {
            if (_TI_KOD_AlacakNedeniDoldur == null)
            {
                _TI_KOD_AlacakNedeniDoldur = DataRepository.per_TI_KOD_ALACAK_NEDENProvider.GetAll();
            }
            LookUpEdit lue = (LookUpEdit)sender;
            if (lue.Properties.DataSource == null)
            {
                int formTipID = Convert.ToInt32(lue.Tag);
                lue.Properties.DataSource = _TI_KOD_AlacakNedeniDoldur.Where(item => item.FORM_TIP_ID == formTipID).OrderByDescending(item => item.ALACAK_NEDENI);

                //GetByFORM_TIP_ID(formTipID);

                lue.Properties.DisplayMember = "ALACAK_NEDENI";
                lue.Properties.ValueMember = "ID";
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.Add(new LookUpColumnInfo("ALACAK_NEDENI", "Alacak Neden Kod", 40));
            }
        }

        public static VList<per_TI_KOD_ALACAK_NEDEN> AlacakNedenKodGetirByFormTipId(int formTipId)
        {
            if (_TI_KOD_AlacakNedeniDoldur != null)
                return new VList<per_TI_KOD_ALACAK_NEDEN>(_TI_KOD_AlacakNedeniDoldur.Where(vi => vi.FORM_TIP_ID == formTipId).ToList());
            return DataRepository.per_TI_KOD_ALACAK_NEDENProvider.Get("FORM_TIP_ID = " + formTipId, "ID");
        }

        public static void AlacakNedenKodGetirByTakipTalebi(LookUpEdit lue, int takipTalebiKonuID)
        {
            //if (_TI_KOD_AlacakNedeniDoldur == null)
            //{
            _TI_KOD_AlacakNedeniDoldur = DataRepository.per_TI_KOD_ALACAK_NEDENProvider.GetAll();

            //}
            lue.Properties.NullText = "Seç";
            lue.Properties.DataSource = _TI_KOD_AlacakNedeniDoldur.Where(item => item.TAKIP_TALEP_KOD_ID == takipTalebiKonuID).OrderByDescending(item => item.ALACAK_NEDENI);
            lue.Properties.DisplayMember = "ALACAK_NEDENI";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("ALACAK_NEDENI", "Alacak Neden Kod", 200));
        }

        public static void AlacakNedenTarafGetir(RepositoryItemLookUpEdit rLue)
        {
            AlacakNedenTarafGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void AlacakNedenTarafGetir(LookUpEdit lue)
        {
            AlacakNedenTarafGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void AlacakNedenTarafGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_AlacakNedenTarafGetir == null)
                {
                    _AlacakNedenTarafGetir = context.per_AV001_TI_BIL_ALACAK_NEDEN_TARAFs.ToList();
                }
                lue.DataSource = _AlacakNedenTarafGetir;
                lue.DisplayMember = "TARAF_CARI_ADI";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("TARAF_CARI_ADI", "Alacak Neden Taraf", 40));
            }
        }

        public static void AraKararGetir(RepositoryItemLookUpEdit rLue)
        {
            AraKararGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void AraKararGetir(LookUpEdit lue)
        {
            AraKararGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void AraKararGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_ArarKararGetir == null)
                {
                    _ArarKararGetir = AvukatProLib2.Data.DataRepository.AV001_TD_BIL_ARA_KARARProvider.GetAll();
                }
                rLue.DataSource = _ArarKararGetir;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "ARA_KARAR";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("ARA_KARAR", "Ara Karar", 100));
            }
        }

        public static List<AvukatProLib.Arama.per_AV001_TD_BIL_ARA_KARAR> AraKararlariGetir()
        {
            if (_per_AV001_TD_BIL_ARA_KARAR == null)
                _per_AV001_TD_BIL_ARA_KARAR = context.per_AV001_TD_BIL_ARA_KARARs.ToList();
            return _per_AV001_TD_BIL_ARA_KARAR;
        }

        public static List<AvukatProLib.Arama.per_AV001_TD_BIL_ARA_KARAR> AraKararlariGetirByFoy(int foyId)
        {
            if (_per_AV001_TD_BIL_ARA_KARAR != null)
                return _per_AV001_TD_BIL_ARA_KARAR.FindAll(item => item.DAVA_FOY_ID == foyId);
            return context.per_AV001_TD_BIL_ARA_KARARs.Where(item => item.DAVA_FOY_ID == foyId).ToList();
        }

        /// <summary>
        /// TDIE_KOD_ASAMA_ALT
        /// </summary>
        /// <param name="lue"></param>
        public static void AsamaAltKodGetir(RepositoryItemLookUpEdit lue)
        {
            AsamaAltKodGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDIE_KOD_ASAMA_ALT
        /// </summary>
        /// <param name="lue"></param
        public static void AsamaAltKodGetir(LookUpEdit lue)
        {
            AsamaAltKodGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void AsamaAltKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_AsamaAltKodGetir == null)
                {
                    _AsamaAltKodGetir = AvukatProLib2.Data.DataRepository.per_TDIE_KOD_ASAMA_ALTProvider.GetAll();
                }
                lue.DataSource = _AsamaAltKodGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "ALT_ASAMA_ADI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ALT_ASAMA_ADI", "Asama Alt Kod", 100));
            }
        }

        /// <summary>
        /// TDIE_KOD_ASAMA
        /// </summary>
        /// <param name="lue"></param>
        public static void AsamaKodGetir(RepositoryItemLookUpEdit lue)
        {
            AsamaKodGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDIE_KOD_ASAMA
        /// </summary>
        /// <param name="lue"></param
        public static void AsamaKodGetir(LookUpEdit lue)
        {
            AsamaKodGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void AsamaKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_AsamaKodGetir == null)
                {
                    if (CodeInfo<per_TDIE_KOD_ASAMA>.ListeVarmi(typeof(per_TDIE_KOD_ASAMA)))
                        _AsamaKodGetir = CodeInfo<per_TDIE_KOD_ASAMA>.ListeGetir(typeof(per_TDIE_KOD_ASAMA)) as VList<per_TDIE_KOD_ASAMA>;
                    else
                    {
                        _AsamaKodGetir = DataRepository.per_TDIE_KOD_ASAMAProvider.GetAll();
                        CodeInfo<per_TDIE_KOD_ASAMA>.ListeKaydet(_AsamaKodGetir, typeof(per_TDIE_KOD_ASAMA));
                    }
                }
                lue.DataSource = _AsamaKodGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "ASAMA_ADI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ASAMA_ADI", "Asama Kod", 100));
            }
        }

        /// <summary>
        /// TDIE_KOD_ASAMA_MODUL
        /// </summary>
        /// <param name="lue"></param>
        public static void AsamaModulGetir(RepositoryItemLookUpEdit lue)
        {
            AsamaModulGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDIE_KOD_ASAMA_MODUL
        /// </summary>
        /// <param name="lue"></param
        public static void AsamaModulGetir(LookUpEdit lue)
        {
            AsamaModulGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void AsamaModulGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_AsamaModulGetir == null)
                {
                    _AsamaModulGetir = AvukatProLib2.Data.DataRepository.per_TDIE_KOD_ASAMA_MODULProvider.GetAll();
                }
                lue.DataSource = _AsamaModulGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "MODUL_ADI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("MODUL_ADI", "Asama Modül", 100));
            }
        }

        /// <summary>
        /// TDIE_KOD_ASAMA_OZEL_DURUM
        /// </summary>
        /// <param name="lue"></param>
        public static void AsamaOzelDurumGetir(RepositoryItemLookUpEdit lue)
        {
            AsamaOzelDurumGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDIE_KOD_ASAMA_OZEL_DURUM
        /// </summary>
        /// <param name="lue"></param
        public static void AsamaOzelDurumGetir(LookUpEdit lue)
        {
            AsamaOzelDurumGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void AsamaOzelDurumGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_AsamaOzelDurumGetir == null)
                {
                    _AsamaOzelDurumGetir = AvukatProLib2.Data.DataRepository.per_TDIE_KOD_ASAMA_OZEL_DURUMProvider.GetAll();
                }
                lue.DataSource = _AsamaOzelDurumGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "OZEL_DURUM";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("OZEL_DURUM", "Aþama Özel Durum", 100));
            }
        }

        public static void BaglimiResim(RepositoryItemImageComboBox rLueBagli)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager();
            ImageList imageList1 = new ImageList();
            imageList1.Images.Add("bagli", AdimAdimDavaKaydi.Properties.Resources.belge_baglama);
            imageList1.Images.Add("bagliDegil", AdimAdimDavaKaydi.Properties.Resources.belge_baglama1);
            rLueBagli.SmallImages = imageList1;
        }

        public static void BankaBolgeGetir(RepositoryItemLookUpEdit rLue)
        {
            BankaBolgeGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void BankaBolgeGetir(LookUpEdit lue)
        {
            BankaBolgeGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void BankaBolgeGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_BankaBolgeGetir == null)
                {
                    _BankaBolgeGetir = AvukatProLib2.Data.DataRepository.TDI_KOD_BANKA_BOLGEProvider.GetAll();
                }
                lue.DataSource = _BankaBolgeGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "BOLGE";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("BOLGE", "Bölge", 40));
            }
        }

        public static void BankaDirekSubeGetir(LookUpEdit lue)
        {
            BankaDirekSubeGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void BankaDirekSubeGetir(RepositoryItemLookUpEdit lue)
        {//çalýþýyor
            BankaDirekSubeGetir_Enter(lue, EventArgs.Empty);
        }

        public static void BankaDirekSubeGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_BankadirekSubeIsmiGetir == null)
                {
                    _BankadirekSubeIsmiGetir = AvukatProLib2.Data.DataRepository.VDI_KOD_BANKA_SUBEProvider.GetAll();
                }
                lue.DataSource = _BankadirekSubeIsmiGetir;//
                // AvukatProLib.Facade.TDI_KOD_BANKA_SUBE.TDI_KOD_BANKA_SUBEGetir(bankaId);
                lue.DisplayMember = "SUBE";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("SUBE", 20, "Sube"), new LookUpColumnInfo("BOLGE", 20, "Bölge"), });
            }
        }

        public static void BankaDirekSubeIsmiGetir(LookUpEdit lue)
        {
            BankaDirekSubeIsmiGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void BankaDirekSubeIsmiGetir(RepositoryItemLookUpEdit lue)
        {
            BankaDirekSubeIsmiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void BankaDirekSubeIsmiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_BankadirekSubeIsmiGetir == null)
                {
                    _BankadirekSubeIsmiGetir = AvukatProLib2.Data.DataRepository.VDI_KOD_BANKA_SUBEProvider.GetAll();
                }
                lue.DataSource = _BankadirekSubeIsmiGetir;//
                // AvukatProLib.Facade.TDI_KOD_BANKA_SUBE.TDI_KOD_BANKA_SUBEGetir(bankaId);
                lue.DisplayMember = "SUBE";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("SUBE", 20, "Þube") });
            }
        }

        public static void BankaGetir(LookUpEdit lue)
        {
            BankaGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void BankaGetir(RepositoryItemLookUpEdit lue)
        {
            BankaGetir_Enter(lue, EventArgs.Empty);
        }

        public static void BankaGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_BankaGetir == null)
                    _BankaGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_BANKAProvider.GetAll();

                lue.DataSource = _BankaGetir;
                lue.DisplayMember = "BANKA";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("BANKA", 40, "Banka"));
            }
        }

        /// <summary>
        /// TDI_KOD_BANKA_KART_TIP
        /// </summary>
        /// <param name="rLue"></param>
        public static void BankaKartTipiGetir(RepositoryItemLookUpEdit rLue)
        {
            BankaKartTipiGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void BankaKartTipiGetir(LookUpEdit lue)
        {
            BankaKartTipiGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void BankaKartTipiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_BankaKartTip == null)
                {
                    _BankaKartTip = AvukatProLib2.Data.DataRepository.per_TDI_KOD_BANKA_KART_TIPProvider.GetAll();
                }
                lue.DataSource = _BankaKartTip;
                lue.NullText = "Seç";
                lue.DisplayMember = "KART_TIPI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("KART_TIPI", "Kart Tipi", 40));
            }
        }

        public static void BankaSubeGetir(LookUpEdit lue, int bankaId)
        {
            lue.Properties.NullText = "Seç";
            lue.Tag = bankaId;
            BankaSubeGetirForLookUpEdit_Enter(lue, EventArgs.Empty);
        }

        public static void BankaSubeGetir(RepositoryItemLookUpEdit lue, int bankaId)
        {
            lue.NullText = "Seç";
            lue.Tag = bankaId;
            SubeGetirBankayaGore_Enter(lue, EventArgs.Empty);
        }

        public static void BankaSubeGetir(LookUpEdit lue)
        {
            if (_BankaSubeGetir == null)
                _BankaSubeGetir = context.VDI_KOD_BANKA_SUBEs.ToList();

            lue.Properties.DataSource = _BankaSubeGetir;
            lue.Properties.DisplayMember = "SUBE";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.NullText = "Seç";
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[]
            {
                new LookUpColumnInfo("SUBE", 20, "Sube"), new LookUpColumnInfo("BOLGE", 20, "Bölge")
            });
        }

        public static void BankaSubeGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                int bankaId = (int)lue.Tag;
                if (_BankaSubeGetir != null)
                    lue.DataSource = _BankaSubeGetir.FindAll(item => item.BANKA_ID == bankaId).OrderByDescending(item => item.SUBE);
                else
                    lue.DataSource = context.VDI_KOD_BANKA_SUBEs.Where(vi => vi.BANKA_ID == bankaId).OrderByDescending(vi => vi.SUBE).ToList();

                lue.DisplayMember = "SUBE";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("SUBE", 20, "Sube") });
            }
        }

        public static void BankaSubeGetirForLookUpEdit_Enter(object sender, EventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            int bankaId = (int)lue.Tag;
            if (_BankaSubeGetir != null)
                lue.Properties.DataSource = _BankaSubeGetir.FindAll(item => item.BANKA_ID == bankaId).OrderByDescending(item => item.SUBE).ToList();
            else
                lue.Properties.DataSource = context.VDI_KOD_BANKA_SUBEs.Where(vi => vi.BANKA_ID == bankaId).OrderByDescending(vi => vi.SUBE).ToList();

            lue.Properties.DisplayMember = "SUBE";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("SUBE", 20, "Sube") });
        }

        public static void BelediyeGetirIlceyeGor(LookUpEdit lue, int IlceId)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ADI", 10, "Belediye") });
            lue.Properties.DataSource = context.per_TDI_KOD_BELEDIYEs.Where(vi => vi.ILCE_ID == IlceId).ToList();
            lue.Properties.DisplayMember = "ADI";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Belediye Seç";
        }

        public static void BelediyeGetirIlceyeGor(RepositoryItemLookUpEdit lue, int IlceId)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ADI", 10, "Belediye") });
            lue.DataSource = context.per_TDI_KOD_BELEDIYEs.Where(vi => vi.ILCE_ID == IlceId).ToList();
            lue.DisplayMember = "ADI";
            lue.ValueMember = "ID";
            lue.NullText = "Belediye Seç";
        }

        public static void BelediyeGetirTumu(RepositoryItemLookUpEdit lue)
        {
            BelediyeGetirTumu_Enter(lue, EventArgs.Empty);
        }

        public static void BelediyeGetirTumu_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_BelediyeGetirTumu == null)
                    _BelediyeGetirTumu = context.per_TDI_KOD_BELEDIYEs.ToList();
                lue.DataSource = _BelediyeGetirTumu;
                lue.DisplayMember = "ADI";
                lue.ValueMember = "ID";
                lue.NullText = "Belediye Seç";
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ADI", 10, "Belediye") });
            }
        }

        public static List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> BelgeGetir()
        {
            if (_BelgeGetir == null)
                _BelgeGetir = context.per_AV001_TDIE_BIL_BELGEs.ToList();
            return _BelgeGetir;
        }

        public static List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> BelgeGetirByDavaFoyId(int davaFoyID)
        {
            TList<NN_BELGE_DAVA> davaFoyList = DataRepository.NN_BELGE_DAVAProvider.GetByDAVA_FOY_ID(davaFoyID);
            List<int> idList = new List<int>();
            davaFoyList.ForEach(item => idList.Add(item.BELGE_ID));

            //if (_BelgeGetir != null)
            //    return (from item in _BelgeGetir where idList.Contains(item.ID) select item).ToList();
            return (from item in context.per_AV001_TDIE_BIL_BELGEs where idList.Contains(item.ID) select item).ToList();
        }

        public static List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> BelgeGetirByIcraFoyId(int icraFoyID)
        {
            TList<NN_BELGE_ICRA> icraFoyList = DataRepository.NN_BELGE_ICRAProvider.GetByICRA_FOY_ID(icraFoyID);
            List<int> idList = new List<int>();
            icraFoyList.ForEach(item => idList.Add(item.BELGE_ID));

            //if (_BelgeGetir != null)
            //    return (from item in _BelgeGetir where idList.Contains(item.ID) select item).ToList();
            return (from item in context.per_AV001_TDIE_BIL_BELGEs where idList.Contains(item.ID) select item).ToList();
        }

        public static List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> BelgeGetirByIdList(List<int> idList)
        {
            if (_BelgeGetir != null)
                return (from item in _BelgeGetir where idList.Contains(item.ID) select item).ToList();
            return (from item in context.per_AV001_TDIE_BIL_BELGEs where idList.Contains(item.ID) select item).ToList();
        }

        public static List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> BelgeGetirByProjeId(int projeId)
        {
            TList<AV001_TDIE_BIL_PROJE_BELGE> projeList = DataRepository.AV001_TDIE_BIL_PROJE_BELGEProvider.GetByPROJE_ID(projeId);
            List<int> idList = new List<int>();
            projeList.ForEach(item => idList.Add(item.BELGE_ID));
            if (_BelgeGetir != null)
                return (from item in _BelgeGetir where idList.Contains(item.ID) select item).ToList();
            return (from item in context.per_AV001_TDIE_BIL_BELGEs where idList.Contains(item.ID) select item).ToList();
        }

        public static List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> BelgeGetirBySatisId(int satisID)
        {
            TList<NN_BELGE_SATIS> satisList = DataRepository.NN_BELGE_SATISProvider.Find(string.Format("SATIS_ID = {0}", satisID));
            List<int> idList = new List<int>();
            satisList.ForEach(item => idList.Add(item.BELGE_ID));

            //if (_BelgeGetir != null)
            //    return (from item in _BelgeGetir where idList.Contains(item.ID) select item).ToList();
            return (from item in context.per_AV001_TDIE_BIL_BELGEs where idList.Contains(item.ID) select item).ToList();
        }

        public static List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> BelgeGetirBySorusturmaId(int sorusturmaID)
        {
            TList<NN_BELGE_HAZIRLIK> sozlesmeList = DataRepository.NN_BELGE_HAZIRLIKProvider.GetByHAZIRLIK_ID(sorusturmaID);
            List<int> idList = new List<int>();
            sozlesmeList.ForEach(item => idList.Add(item.BELGE_ID));

            //if (_BelgeGetir != null)
            //    return (from item in _BelgeGetir where idList.Contains(item.ID) select item).ToList();
            return (from item in context.per_AV001_TDIE_BIL_BELGEs where idList.Contains(item.ID) select item).ToList();
        }

        public static List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> BelgeGetirBySozlesmeId(int sozlesmeID)
        {
            TList<NN_BELGE_SOZLESME> sozlesmeList = DataRepository.NN_BELGE_SOZLESMEProvider.GetBySOZLESME_ID(sozlesmeID);
            List<int> idList = new List<int>();
            sozlesmeList.ForEach(item => idList.Add(item.BELGE_ID));

            //if (_BelgeGetir != null)
            //    return (from item in _BelgeGetir where idList.Contains(item.ID) select item).ToList();
            return (from item in context.per_AV001_TDIE_BIL_BELGEs where idList.Contains(item.ID) select item).ToList();
        }

        public static VList<R_BELGELER_TARAFLI> BelgeGetirTaraflý()
        {
            if (_BelgeGetirTaraflý == null)
                _BelgeGetirTaraflý = DataRepository.R_BELGELER_TARAFLIProvider.GetAll();
            return _BelgeGetirTaraflý;
        }

        public static VList<R_BELGELER_TARAFLI> BelgeGetirTaraflýByTarafId(int tarafId)
        {
            if (_BelgeGetirTaraflý != null)
                return _BelgeGetirTaraflý.FindAll("BELGE_TARAF_ID", tarafId);
            return DataRepository.R_BELGELER_TARAFLIProvider.Get("BELGE_TARAF_ID = " + tarafId, "ID");
        }

        //TDIE_KOD_BELGE_GIZLILIK
        public static void BelgeGizlilikGetir(RepositoryItemLookUpEdit rLue)
        {
            BelgeGizlilikgetir_Enter(rLue, EventArgs.Empty);
        }

        public static void BelgeGizlilikgetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_BelgeGizlilikGetir == null)
                {
                    _BelgeGizlilikGetir = DataRepository.TDIE_KOD_BELGE_GIZLILIKProvider.GetAll();
                }
                rLue.DataSource = _BelgeGizlilikGetir;
                rLue.DisplayMember = "GIZLILIK";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("GIZLILIK", 50, "Belge Gzililik"));
            }
        }

        /// <summary>
        /// AV001_TDI_KOD_BELGE_OZEL_KOD
        /// </summary>
        /// <param name="lue"></param>
        public static void BelgeOzelKodGetir(RepositoryItemLookUpEdit lue)
        {
            BelgeOzelKodGetir_Enter(lue, EventArgs.Empty);
        }

        //lueCariAlt
        /// <summary>
        /// AV001_TDI_KOD_BELGE_OZEL_KOD
        /// </summary>
        /// <param name="lue"></param
        public static void BelgeOzelKodGetir(LookUpEdit lue)
        {
            BelgeOzelKodGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void BelgeOzelKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_BelgeOzelKodGetir == null)
                {
                    _BelgeOzelKodGetir = AvukatProLib2.Data.DataRepository.per_AV001_TDI_KOD_BELGE_OZEL_KODProvider.GetAll();
                }
                lue.NullText = "Seç";
                lue.DataSource = _BelgeOzelKodGetir;
                lue.DisplayMember = "KOD";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("KOD", "Belge Özel Kod", 100));
            }
        }

        public static void BelgeOzelKodGetirForeach(LookUpEdit[] lues)
        {
            foreach (var item in lues)
            {
                BelgeOzelKodGetirForeach_Enter(item.Properties, EventArgs.Empty);
            }
        }

        public static void BelgeOzelKodGetirForeach_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_BelgeOzelKodGetir == null)
                {
                    _BelgeOzelKodGetir = AvukatProLib2.Data.DataRepository.per_AV001_TDI_KOD_BELGE_OZEL_KODProvider.GetAll();
                }
                lue.DataSource = _BelgeOzelKodGetir;
                lue.DisplayMember = "KOD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 30, "Belge Özel Kod") });
            }
        }

        public static void BelgeTurGetir(RepositoryItemLookUpEdit rLue)
        {
            BelgeTurGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void BelgeTurGetir(LookUpEdit lue)
        {
            BelgeTurGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void BelgeTurGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_BelgeTurGetir == null)
                {
                    _BelgeTurGetir = AvukatProLib2.Data.DataRepository.per_TDIE_KOD_BELGE_TURProvider.GetAll();
                }
                lue.DataSource = _BelgeTurGetir;
                lue.DisplayMember = "BELGE_TURU";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("BELGE_TURU", "Belge Türü", 40));
            }
        }

        public static VList<BIRLESIK_SIK_KULLANILANLAR> BIRLESIK_SIK_KULLANILANLARGetir()
        {
            if (_BIRLESIK_SIK_KULLANILANLARGetir == null) _BIRLESIK_SIK_KULLANILANLARGetir = DataRepository.BIRLESIK_SIK_KULLANILANLARProvider.GetAll();
            return _BIRLESIK_SIK_KULLANILANLARGetir;
        }

        public static VList<BIRLESIK_SIK_KULLANILANLAR> BIRLESIK_SIK_KULLANILANLARGetirbyKullaniciId(int kullaniciId)
        {
            if (_BIRLESIK_SIK_KULLANILANLARGetir != null) return _BIRLESIK_SIK_KULLANILANLARGetir.FindAll("KULLANICI_ID", kullaniciId);
            return DataRepository.BIRLESIK_SIK_KULLANILANLARProvider.GetByKullaniciId(kullaniciId);
        }

        /// <summary>
        /// TDI_KOD_BIRIM
        /// </summary>
        /// <param name="lue"></param
        public static void BirimKodGetir(LookUpEdit lue)
        {
            BirimKodGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void BirimKodGetir(RepositoryItemLookUpEdit rLue)
        {
            BirimKodGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void BirimKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_BirimKodGetir == null)
                {
                    _BirimKodGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_BIRIMProvider.GetAll();
                }
                lue.DataSource = _BirimKodGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "KOD";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("KOD", "Birim Kod", 100));
            }
        }

        /// <summary>
        /// TDI_KOD_MUHASEBE_BORC_ALACAK
        /// </summary>
        /// <param name="lue"></param>
        public static void BorcAlacakGetir(RepositoryItemLookUpEdit lue)
        {
            BorcAlacakGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_MUHASEBE_BORC_ALACAK
        /// </summary>
        /// <param name="lue"></param>
        public static void BorcAlacakGetir(LookUpEdit lue)
        {
            BorcAlacakGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void BorcAlacakGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_BorcAlacakGetir == null)
                {
                    _BorcAlacakGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_MUHASEBE_BORC_ALACAKProvider.GetAll();
                }

                lue.DataSource = _BorcAlacakGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "BORC_ALACAK";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("BORC_ALACAK", "Açýklama", 100));
            }
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> BorcluTarafByFoy(AV001_TI_BIL_FOY foy, RepositoryItemLookUpEdit[] controls)
        {
            if (foy == null) return null;

            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = BorcluTarafCariGetir(foy);

            foreach (RepositoryItemLookUpEdit rLue in controls)
            {
                rLue.DataSource = cariList;
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.AddRange(new LookUpColumnInfo[]
                    {
                        new LookUpColumnInfo("KOD", 10, "Kod"),
                        new LookUpColumnInfo("AD", 30, "Ad")
                    });

                rLue.NullText = "Seç";
            }

            return cariList;
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> BorcluTarafByFoy(Av001TiBilFoyEntity foy, RepositoryItemLookUpEdit[] controls)
        {
            if (foy == null) return null;

            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = BorcluTarafCariGetir(foy);

            foreach (RepositoryItemLookUpEdit rLue in controls)
            {
                rLue.DataSource = cariList;
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.AddRange(new LookUpColumnInfo[]
                    {
                        new LookUpColumnInfo("KOD", 10, "Kod"),
                        new LookUpColumnInfo("AD", 30, "Ad")
                    });

                rLue.NullText = "Seç";
            }

            return cariList;
        }

        public static void BorcluTarafByFoy(AV001_TDIE_BIL_PROJE foy, params RepositoryItemLookUpEdit[] controls)
        {
            if (_ProjeTarafGetir == null)
            {
                _ProjeTarafGetir = context.per_AV001_TDIE_BIL_PROJE_TARAFs.ToList();
            }

            foreach (RepositoryItemLookUpEdit rLue in controls)
            {
                rLue.DataSource = _ProjeTarafGetir.FindAll(item => item.PROJE_ID == foy.ID && !item.MUVEKKIL_MI);
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "CARI_ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.AddRange(new LookUpColumnInfo[]
                    {
                        new LookUpColumnInfo("KOD", 10, "Kod"),
                        new LookUpColumnInfo("AD", 30, "Ad")
                    });
                rLue.NullText = "Seç";
            }
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> BorcluTarafByFoy(AV001_TD_BIL_FOY foy, RepositoryItemLookUpEdit[] controls)
        {
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>();
            if (_TD_FoyTarafGetir == null)
            {
                _TD_FoyTarafGetir = context.per_AV001_TD_BIL_FOY_TARAFs.ToList();
            }
            List<AvukatProLib.Arama.per_AV001_TD_BIL_FOY_TARAF> _TarafGetirByFoy = _TD_FoyTarafGetir.Where(item => item.DAVA_FOY_ID == foy.ID && item.TARAF_KODU == (int)TarafKodu.KarsiTaraf).ToList();

            _TarafGetirByFoy.ForEach(item =>
            {
                AvukatProLib.Arama.per_AV001_TDI_BIL_CARI carim = context.per_AV001_TDI_BIL_CARIs.SingleOrDefault(cari => item.CARI_ID == cari.ID && !cari.MUVEKKIL_MI);
                if (carim != null) cariList.Add(carim);
            });

            foreach (RepositoryItemLookUpEdit rLue in controls)
            {
                rLue.DataSource = cariList;
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.AddRange(new LookUpColumnInfo[]
                    {
                        new LookUpColumnInfo("KOD", 10, "Kod"),
                        new LookUpColumnInfo("AD", 30, "Ad")
                    });

                rLue.NullText = "Seç";
            }
            return cariList;
        }

        public static void BorcluTarafByFoy(AV001_TD_BIL_HAZIRLIK foy, RepositoryItemLookUpEdit[] controls)
        {
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>();

            List<AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_TARAF> _TarafGetirByFoy = context.per_AV001_TD_BIL_HAZIRLIK_TARAFs.Where(item => item.HAZIRLIK_ID == foy.ID && item.TARAF_KODU == (short)TarafKodu.KarsiTaraf).ToList();

            if (_per_CariGetir == null)
            {
                _per_CariGetir = context.per_AV001_TDI_BIL_CARIs.OrderBy(item => item.AD).ToList();
            }

            _TarafGetirByFoy.ForEach(item =>
            {
                AvukatProLib.Arama.per_AV001_TDI_BIL_CARI carim = _per_CariGetir.Single(cari => item.CARI_ID == cari.ID);
                if (carim != null) cariList.Add(carim);
            });

            foreach (RepositoryItemLookUpEdit rLue in controls)
            {
                rLue.DataSource = cariList;
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.AddRange(new LookUpColumnInfo[]
                    {
                        new LookUpColumnInfo("KOD", 10, "Kod"),
                        new LookUpColumnInfo("AD", 30, "Ad")
                    });

                rLue.NullText = "Seç";
            }
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> BorcluTarafByFoy(AV001_TDI_BIL_SOZLESME foy, RepositoryItemLookUpEdit[] controls)
        {
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>();
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_SOZLESME_TARAF> sozlesmeTarafByFoy = context.per_AV001_TDI_BIL_SOZLESME_TARAFs.Where(item => item.SOZLESME_ID == foy.ID && (item.TARAF_SIFAT == TarafSifat.SANIK.ToString() || item.TARAF_SIFAT == TarafSifat.BORCLU.ToString() || item.TARAF_SIFAT == TarafSifat.DAVACI.ToString())).ToList();

            if (_per_CariGetir == null)
            {
                _per_CariGetir = context.per_AV001_TDI_BIL_CARIs.ToList();
            }

            sozlesmeTarafByFoy.ForEach(item =>
            {
                AvukatProLib.Arama.per_AV001_TDI_BIL_CARI carim = _per_CariGetir.Single(cari => item.CARI_ID == cari.ID);
                if (carim != null) cariList.Add(carim);
            });

            foreach (RepositoryItemLookUpEdit rLue in controls)
            {
                rLue.DataSource = cariList;
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.AddRange(new LookUpColumnInfo[]
                    {
                        new LookUpColumnInfo("KOD", 10, "Kod"),
                        new LookUpColumnInfo("AD", 30, "Ad")
                    });

                rLue.NullText = "Seç";
            }
            return cariList;
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> BorcluTarafCariGetir(Av001TiBilFoyEntity foy)
        {
            var tarafList = BorcluTarafGetir(foy);
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>();
            tarafList.ForEach(item =>
            {
                AvukatProLib.Arama.per_AV001_TDI_BIL_CARI carim = context.per_AV001_TDI_BIL_CARIs.SingleOrDefault(cari => cari.ID == item.CARI_ID);
                if (carim != null) cariList.Add(carim);
            });
            return cariList;
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> BorcluTarafCariGetir(AV001_TI_BIL_FOY foy)
        {
            var tarafList = BorcluTarafGetir(foy);
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>();
            tarafList.ForEach(item =>
            {
                AvukatProLib.Arama.per_AV001_TDI_BIL_CARI carim = context.per_AV001_TDI_BIL_CARIs.SingleOrDefault(cari => cari.ID == item.CARI_ID);
                if (carim != null) cariList.Add(carim);
            });
            return cariList;
        }

        public static List<AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF> BorcluTarafGetir(Av001TiBilFoyEntity foy)
        {
            if (_FoyTarafGetir != null)
            {
                return _FoyTarafGetir.FindAll(item => item.ICRA_FOY_ID == foy.Id && item.TARAF_KODU == (byte)TarafKodu.KarsiTaraf);
            }
            return BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAFs.Where(item => item.ICRA_FOY_ID == foy.Id && item.TARAF_KODU == (byte)TarafKodu.KarsiTaraf).ToList();
        }

        public static List<AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF> BorcluTarafGetir(AV001_TI_BIL_FOY foy)
        {
            if (_FoyTarafGetir != null)
            {
                return _FoyTarafGetir.FindAll(item => item.ICRA_FOY_ID == foy.ID && item.TARAF_KODU == (byte)TarafKodu.KarsiTaraf);
            }
            return BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAFs.Where(item => item.ICRA_FOY_ID == foy.ID && item.TARAF_KODU == (byte)TarafKodu.KarsiTaraf).ToList();
        }

        public static void CariAdliPersonelKodGetir(RepositoryItemLookUpEdit lue)
        {
            CariAdliPersonelKodGetir_Enter(lue, EventArgs.Empty);
        }

        public static void CariAdliPersonelKodGetir(LookUpEdit lue)
        {
            CariAdliPersonelKodGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void CariAdliPersonelKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_CariAdliPersonelKodGetir == null)
                {
                    _CariAdliPersonelKodGetir = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.Find("ADLI_PERSONEL_MI='True'");
                }
                lue.NullText = "Seç";
                lue.DataSource = _CariAdliPersonelKodGetir;

                //Get(" ADLI_PERSONEL_MI='TRUE'", "AD DESC");
                //Find("ADLI_PERSONEL_MI='True'");
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("KOD", 100, "Adli Personel Kodu"));
            }
        }

        public static void CariAktifAdresGetir(LookUpEdit lue)
        {
            CariAktifAdresGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void CariAktifAdresGetir(RepositoryItemLookUpEdit lue)
        {
            CariAktifAdresGetir_Enter(lue, EventArgs.Empty);
        }

        public static void CariAktifAdresGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("AktifAdres");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.CariAktifAdres tipi in Enum.GetValues(typeof(AvukatProLib.Extras.CariAktifAdres)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";

                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Aktif Adres"));
            }
        }

        /// <summary>
        /// AV001_TDI_BIL_CARI_ALT
        /// </summary>
        /// <param name="lue"></param>
        public static void CariAltGetir(RepositoryItemLookUpEdit lue)
        {
            CariAltGetir_Enter(lue, EventArgs.Empty);
        }

        public static void CariAltGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                _CariAltGetir = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARI_ALTProvider.GetAll();
                lue.DataSource = _CariAltGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("AD", "Alt Cari Adý", 100));
            }
        }

        public static void CariAltRefersh()
        {
            _CariAltGetir = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARI_ALTProvider.GetAll();
        }

        /// <summary>
        /// AV001_TDI_BIL_CARI (AVUKAT_MI=TRUE)
        /// </summary>
        /// <param name="lue"></param>
        public static void CariAvukatGetir(RepositoryItemLookUpEdit lue)
        {
            CariAvukatGetir_Enter(lue, EventArgs.Empty);
        }

        public static void CariAvukatGetir(LookUpEdit lue)
        {
            CariAvukatGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void CariAvukatGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_perCariAvukatGetir == null)
                {
                    if (_per_CariGetir != null)
                        _perCariAvukatGetir = _per_CariGetir.FindAll(item => item.AVUKAT_MI == true);
                    else
                    {
                        _perCariAvukatGetir = context.per_AV001_TDI_BIL_CARIs.Where(vi => vi.AVUKAT_MI).ToList();
                    }
                }
                //if (_CariAvukatGetir == null)
                //{
                //    _CariAvukatGetir = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.Find("AVUKAT_MI='True'");
                //}
                lue.DataSource = _perCariAvukatGetir;

                //Get("  AVUKAT_MI = 'TRUE'", "AD DESC");
                //Find("AVUKAT_MI='True'");
                lue.NullText = "Seç";
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod"), new LookUpColumnInfo("AD", 30, "Ad") });
            }
        }

        public static void CariAvukatGetirTemsil(RepositoryItemLookUpEdit lue)
        {
            CariAvukatGetirTemsil_Enter(lue, EventArgs.Empty);
        }

        public static void CariAvukatGetirTemsil_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_perCariAvukatGetir == null)
                {
                    if (_per_CariGetir != null)
                        _perCariAvukatGetir = _per_CariGetir.FindAll(item => item.AVUKAT_MI == true);
                    else
                    {
                        _perCariAvukatGetir = context.per_AV001_TDI_BIL_CARIs.Where(vi => vi.AVUKAT_MI).ToList();
                    }
                }
                lue.DataSource = _perCariAvukatGetir;//
                // AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.Find("AVUKAT_MI='True'");

                //Get("  AVUKAT_MI = 'TRUE'", "AD DESC");
                //Find("AVUKAT_MI='True'");
                lue.NullText = "Seç";
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod"), new LookUpColumnInfo("AD", 30, "Ad") });
            }
        }

        public static void CariAvukatKodGetir(LookUpEdit lue)
        {
            CariAvukatKodGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void CariAvukatKodGetir(RepositoryItemLookUpEdit lue)
        {
            per_AV001_TDI_BIL_CARIParameterBuilder builder = new per_AV001_TDI_BIL_CARIParameterBuilder();
            builder.AppendEquals(per_AV001_TDI_BIL_CARIColumn.BILIRKISI_MI, "True");
            CariAvukatKodGetir_Enter(lue, EventArgs.Empty);
        }

        //}
        public static void CariAvukatKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_per_CariGetir != null && _per_CariGetir.Count > 0)
                {
                    _CariAvukatKodGetir_Enter = new VList<per_AV001_TDI_BIL_CARI>(_per_CariGetir.FindAll(item => item.AVUKAT_MI == true));
                }
                else if (_CariAvukatKodGetir_Enter == null || _CariAvukatKodGetir_Enter.Count == 0)
                {
                    _CariAvukatKodGetir_Enter = DataRepository.per_AV001_TDI_BIL_CARIProvider.Get("AVUKAT_MI = 'TRUE'", "KOD");
                }

                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod") });
                lue.DataSource = _CariAvukatKodGetir_Enter;

                //Get(" AVUKAT_MI='true'", "KOD DESC");
                //Find("AVUKAT_MI = 'TRUE'");
                lue.DisplayMember = "KOD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void CariAvukatOrtakligiKodGetir(LookUpEdit lue)
        {
            CariAvukatOrtakligiKodGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void CariAvukatOrtakligiKodGetir(RepositoryItemLookUpEdit lue)
        {
            CariAvukatOrtakligiKodGetir_Enter(lue, EventArgs.Empty);
        }

        public static void CariAvukatOrtakligiKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_per_CariGetir != null && _per_CariGetir.Count > 0)
                {
                    _CariAvukatOrtakligiKodGetir_Enter = new VList<per_AV001_TDI_BIL_CARI>(_per_CariGetir.FindAll(item => item.FIRMA_MI == true && item.AVUKAT_ORTAKLIGI_MI == true));
                }
                else if (_CariAvukatOrtakligiKodGetir_Enter == null)
                {
                    _CariAvukatOrtakligiKodGetir_Enter = AvukatProLib2.Data.DataRepository.per_AV001_TDI_BIL_CARIProvider.Get("FIRMA_MI = 'TRUE' AND AVUKAT_ORTAKLIGI_MI = 'TRUE'", "KOD DESC");
                }

                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod") });
                lue.DataSource = _CariAvukatOrtakligiKodGetir_Enter;

                //Get("FIRMA_MI='true' AND AVUKAT_ORTAKLIGI_MI='true'", " KOD DESC");
                //Find("FIRMA_MI = 'TRUE' AND AVUKAT_ORTAKLIGI_MI = 'TRUE'");
                lue.DisplayMember = "KOD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void CariBilirKisiKoduGetir(LookUpEdit lue)
        {
            CariBilirKisiKoduGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void CariBilirKisiKoduGetir(RepositoryItemLookUpEdit lue)
        {
            CariBilirKisiKoduGetir_Enter(lue, EventArgs.Empty);
        }

        public static void CariBilirKisiKoduGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_per_CariGetir == null || _per_CariGetir.Count == 0)
                    _per_CariGetir = context.per_AV001_TDI_BIL_CARIs.ToList();

                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod"), new LookUpColumnInfo("AD", 30, "Ad") });
                lue.DataSource = _per_CariGetir;//Bilirkiþi mi kontrolü kaldýrýldý.
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void CaridenFirmaGetir(RepositoryItemLookUpEdit lue)
        {
            CaridenFirmaGetir_Enter(lue, EventArgs.Empty);
        }

        public static void CaridenFirmaGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_CaridenFirmaGetir == null)
                {
                    _CaridenFirmaGetir = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.Find("FIRMA_MI='True'");
                }

                lue.DataSource = _CaridenFirmaGetir;

                //Get(" FIRMA_MI='TRUE'", "AD DESC");
                //Find("FIRMA_MI='True'");
                lue.NullText = "Seç";
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 30, "Kurum") });
            }
        }

        public static void CariFirmaGetir(RepositoryItemLookUpEdit lue)
        {
            CariFirmaGetir_Enter(lue, EventArgs.Empty);
        }

        public static void CariFirmaGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_CariFirmaGetir == null)
                {
                    _CariFirmaGetir = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.Find("FIRMA_MI='True'");
                }
                lue.DataSource = _CariFirmaGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod"), new LookUpColumnInfo("AD", 30, "Ad") });
            }
        }

        /// <summary>
        /// Bütün Carileri getiren method
        /// </summary>
        /// <param name="lue">Verilerin atanacaðý kontrol</param>
        public static void CariGetir(LookUpEdit lue)
        {
            CariGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void CariGetir(RepositoryItemLookUpEdit lue)
        {
            //ToDo : viev e çevrilecek
            CariGetir_Enter(lue, EventArgs.Empty);
        }

        public static void CariGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_CariGetir == null)
                {
                    _CariGetir = DataRepository.AV001_TDI_BIL_CARIProvider.GetAll();
                    _CariGetir.Sort("AD ASC");
                }

                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod"), new LookUpColumnInfo("AD", 30, "Ad") });

                lue.DataSource = _CariGetir;
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void CariGetirAvukatmi(RepositoryItemLookUpEdit lue)
        {
            //ToDo : Prosedüre yazýlacak
            CariGetirAvukatmi_Enter(lue, EventArgs.Empty);
        }

        public static void CariGetirAvukatmi_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_CariGetirAvukatmi == null)
                {
                    _CariGetirAvukatmi = DataRepository.AV001_TDI_BIL_CARIProvider.GetAll();
                }
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("AVUKAT_MI", 10, "Avukat mý?"), new LookUpColumnInfo("AD", 30, "Ad") });
                TList<AV001_TDI_BIL_CARI> listem = _CariGetirAvukatmi;
                listem.Sort("AD ASC");
                lue.DataSource = listem;
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        /// <summary>
        /// BILIRKISI_MI=TRUE
        /// </summary>
        /// <param name="lue"></param>
        public static void CariGetirBilirkisi(RepositoryItemLookUpEdit lue)
        {
            // ToDo : PRosedüre yazýlacak
            CariGetirBilirkisi_Enter(lue, EventArgs.Empty);
        }

        public static void CariGetirBilirkisi_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_per_CariGetir != null && _per_CariGetir.Count > 0)
                {
                    _CariGetirBilirkisi = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>(_per_CariGetir.Where(item => item.BILIRKISI_MI == true).ToList());
                }
                else if (_CariGetirBilirkisi == null || _CariGetirBilirkisi.Count == 0)
                {
                    _CariGetirBilirkisi = context.per_AV001_TDI_BIL_CARIs.Where(vi => vi.BILIRKISI_MI).OrderByDescending(vi => vi.AD).ToList();
                }

                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod"), new LookUpColumnInfo("AD", 30, "Ad") });
                List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> listem = _CariGetirBilirkisi;

                //Get("BILIRKISI_MI='true'" , "AD DESC");
                //Find(string.Format("BILIRKISI_MI={0}", true));
                //listem.Sort("AD ASC");
                lue.DataSource = listem;
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> CariGetirByIdList(List<int> idList)
        {
            if (_per_CariGetir != null)
                return (from item in _per_CariGetir where idList.Contains(item.ID) select item).ToList();
            return (from item in context.per_AV001_TDI_BIL_CARIs where idList.Contains(item.ID) select item).ToList();
        }

        public static void CariGetirByTarafKodu(RepositoryItemLookUpEdit rLue, AvukatProLib.Extras.TarafKodu tarafKodu)
        {
            if (BelgeUtil.Inits._per_CariGetir == null)
                BelgeUtil.Inits._per_CariGetir = context.per_AV001_TDI_BIL_CARIs.OrderBy(item => item.AD).ToList();

            if (tarafKodu == AvukatProLib.Extras.TarafKodu.Muvekkil)
                rLue.DataSource = BelgeUtil.Inits._per_CariGetir.FindAll(vi => vi.MUVEKKIL_MI);
            else if (tarafKodu == AvukatProLib.Extras.TarafKodu.KarsiTaraf)
                rLue.DataSource = BelgeUtil.Inits._per_CariGetir.FindAll(vi => vi.KARSI_TARAF_MI);
            else
                rLue.DataSource = BelgeUtil.Inits._per_CariGetir;
            rLue.NullText = "Seç";
            rLue.ValueMember = "ID";
            rLue.DisplayMember = "AD";
            rLue.Columns.Clear();
            rLue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod"), new LookUpColumnInfo("AD", 30, "Ad"), new LookUpColumnInfo("VERGI_NO", 30, "Vergi/TC") });
        }

        public static void CariGetirRefersh()
        {
            _CariGetir = DataRepository.AV001_TDI_BIL_CARIProvider.GetAll();
        }

        /// <summary>
        /// Cari Hakemleri Getiren metot
        /// </summary>
        /// <param name="lue">Verilerin atanacaðý kontrol</param>
        public static void CariHakemGetir(RepositoryItemLookUpEdit lue)
        {
            //ToDo : prosedure yazýlacak
            CariHakemGetir_Enter(lue, EventArgs.Empty);
        }

        public static void CariHakemGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_CariHakemGetir == null)
                {
                    _CariHakemGetir = context.per_AV001_TDI_BIL_CARIs.Where(item => item.HAKEM_MI).OrderBy(item => item.AD).ToList();
                }

                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod"), new LookUpColumnInfo("AD", 30, "Ad") });

                //Get("HAKEM_MI='true'", "AD DESC");                //Find("HAKEM_MI = True");
                lue.DataSource = _CariHakemGetir;
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void CariHesapGetir(RepositoryItemLookUpEdit lue) // Kullanýlmýyor
        {
            CariHesapGetir_Enter(lue, EventArgs.Empty);
        }

        public static void CariHesapGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_CariHesapGetir == null)
                {
                    _CariHesapGetir = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARI_HESAPProvider.GetAll();
                }
                lue.DataSource = _CariHesapGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "CARI_ADI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("CARI_ADI", "Þahýs", 100));
            }
        }

        public static void CariIsmiGetir(LookUpEdit lue)
        {
            CariIsmiGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        /// <summary>
        /// Cari ismi döndürür
        /// </summary>
        /// <param name="CariId">Cari Id</param>
        /// <returns></returns>
        public static string CariIsmiGetir(int CariId)
        {
            if (_per_CariGetir != null && _per_CariGetir.Count == 0)
            {
                return _per_CariGetir.SingleOrDefault(item => item.ID == CariId).AD;
            }
            else return AvukatProLib2.Data.DataRepository.per_AV001_TDI_BIL_CARIProvider.Get(String.Format("ID = {0}", CariId), "ID").Single().AD;

        }

        public static void CariIsmiGetir(RepositoryItemLookUpEdit lue)
        {
            CariIsmiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void CariIsmiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_per_CariGetir == null || _per_CariGetir.Count == 0)
                {
                    _per_CariGetir = context.per_AV001_TDI_BIL_CARIs.OrderBy(item => item.AD).ToList();
                }
                _CariIsmiGetir_Enter = _per_CariGetir;

                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("AD", 10, "Adý") });
                lue.DataSource = _CariIsmiGetir_Enter;
                lue.DisplayMember = "KOD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void CariKoduGetir(LookUpEdit lue)
        {
            CariKoduGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void CariKoduGetir(RepositoryItemLookUpEdit lue)
        {
            CariKoduGetir_Enter(lue, EventArgs.Empty);
        }

        public static void CariKoduGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_per_CariGetir == null || _per_CariGetir.Count == 0)
                {
                    _per_CariGetir = context.per_AV001_TDI_BIL_CARIs.OrderBy(item => item.AD).ToList();
                }
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod") });
                lue.DataSource = _per_CariGetir; //GetCachedData(CacheHelper.CacheType.CariFull); //AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetAll();
                lue.DisplayMember = "KOD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void CariOzelKodGetir(LookUpEdit lue)
        {
            CariOzelKodGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void CariOzelKodGetir(RepositoryItemLookUpEdit lue)
        {
            // ToDo : VList Olacak;
            CariOzelKodGetir_Enter(lue, EventArgs.Empty);
        }

        public static void CariOzelKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_CariOzelKodGetir_Enter == null)
                    _CariOzelKodGetir_Enter = AvukatProLib2.Data.DataRepository.AV001_TDI_KOD_CARI_OZELProvider.GetAll();
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod") });
                lue.DataSource = _CariOzelKodGetir_Enter;

                //AvukatProLib.Facade.AV001_TDI_BIL_CARI_OZEL.AV001_TDI_BIL_CARI_OZELGetir();
                lue.DisplayMember = "KOD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        //public static void CariPersonelGetir(LookUpEdit lue)
        //{
        //    lue.Properties.Columns.Clear();
        //    lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("AD", 10, "Ad") });
        //    lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.Find("FIRMA_MI = 'FALSE' AND PERSONEL_MI = 'TRUE'");
        //    lue.Properties.DisplayMember = "AD";
        //    lue.Properties.ValueMember = "ID";
        //    lue.Properties.NullText = "Seç";
        public static void CariPersonelKodGetir(LookUpEdit lue)
        {
            CariPersonelKodGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void CariPersonelKodGetir(RepositoryItemLookUpEdit lue)
        {
            CariPersonelKodGetir_Enter(lue, EventArgs.Empty);
        }

        public static void CariPersonelKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_per_CariGetir != null && _per_CariGetir.Count > 0)
                {
                    _CariAvukatKodGetir_Enter = new VList<per_AV001_TDI_BIL_CARI>(_per_CariGetir.FindAll(item => item.FIRMA_MI == false && item.PERSONEL_MI == true));
                }
                else if (_CariPersonelKodGetir_Enter == null || _CariPersonelKodGetir_Enter.Count == 0)
                {
                    _CariPersonelKodGetir_Enter = DataRepository.per_AV001_TDI_BIL_CARIProvider.Get("FIRMA_MI = 'FALSE' AND PERSONEL_MI = 'TRUE'", "KOD");
                }

                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod") });
                lue.DataSource = _CariPersonelKodGetir_Enter;

                //Get(" PERSONEL_MI='true' AND FIRMA_MI = 'FALSE'", "KOD DESC");
                //Find("FIRMA_MI = 'FALSE' AND PERSONEL_MI = 'TRUE'");
                lue.DisplayMember = "KOD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        /// <summary>
        /// TDIE_KOD_TARAF_SIFAT tipinden tüm deðerleri getirir.
        /// </summary>
        /// <param name="lue"></param>
        public static void CariSifatGetir(RepositoryItemLookUpEdit lue)
        {
            CariSifatGetir_Enter(lue, EventArgs.Empty);
        }

        public static void CariSifatGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_CariSifatGetir == null)
                {
                    if (_TarafSifatGetir == null)
                        _CariSifatGetir = context.per_TDIE_KOD_TARAF_SIFATs.ToList();
                    else
                        _CariSifatGetir = _TarafSifatGetir;
                }
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("SIFAT", 20, "Sýfat") });
                lue.DataSource = _CariSifatGetir;

                //AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.GetAll();
                //AvukatProLib.Facade.TDI_KOD_ADLI_BIRIM_GOREV.TDI_KOD_ADLI_BIRIM_GOREVGetir();
                lue.ValueMember = "ID";
                lue.DisplayMember = "SIFAT";
                lue.NullText = "Seç";
            }
        }

        public static void CariTemsilTipiGetir(RepositoryItemLookUpEdit lue)
        {
            CariTemsilTipiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void CariTemsilTipiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (lue.DataSource == null)
                {
                    DataTable dt = new DataTable("TemsilTipi");
                    dt.Columns.Add("ID");
                    dt.Columns.Add("ACIKLAMA");
                    foreach (AvukatProLib.Extras.TemsilTipi tipi in Enum.GetValues(typeof(AvukatProLib.Extras.TemsilTipi)))
                    {
                        dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                    }
                    lue.NullText = "Seç";
                    lue.DataSource = dt;
                    lue.ValueMember = "ID";
                    lue.DisplayMember = "ACIKLAMA";

                    lue.Columns.Clear();
                    lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 20, "Temsil Tipi"));
                }
            }
        }

        public static void CariTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("CariTipi");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.CariTipi tipi in Enum.GetValues(typeof(AvukatProLib.Extras.CariTipi)))
                {
                    dt.Rows.Add(Convert.ToBoolean((int)tipi), tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";

                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Þahýs Tipi"));
            }
        }

        public static void CariTipiGetir(RepositoryItemLookUpEdit lue)
        {
            CariTipGetir_Enter(lue, EventArgs.Empty);
        }

        public static void CariTipiGetir(LookUpEdit lue)
        {
            CariTipGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void CariUnvanGetir(LookUpEdit lue)
        {
            CariUnvanGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void CariUnvanGetir(RepositoryItemLookUpEdit lue)
        {
            CariUnvanGetir_Enter(lue, EventArgs.Empty);
        }

        public static void CariUnvanGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_CariUnvanGetir_Enter == null)
                    _CariUnvanGetir_Enter = AvukatProLib2.Data.DataRepository.per_TDI_KOD_UNVANProvider.GetAll();
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("UNVAN", 10, "Ünvan") });
                lue.DataSource = _CariUnvanGetir_Enter;
                lue.DisplayMember = "UNVAN";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static string CariYeniKodGetir()
        {
            DataSet ds = DataRepository.AV001_TDI_BIL_CARIProvider.KodGetir(AvukatProLib.Kimlik.SubeKodu);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            return String.Empty;
        }

        public static void CinsiyetGetir(RepositoryItemLookUpEdit rLue)
        {
            CinsiyetGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void CinsiyetGetir(LookUpEdit lue)
        {
            CinsiyetGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void CinsiyetGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_CinsiyetGetir == null)
                {
                    _CinsiyetGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_CINSIYETProvider.GetAll();
                }
                lue.DataSource = _CinsiyetGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "CINSIYET";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("CINSIYET", "Cinsiyet", 40));
            }
        }

        public static void DavaAdi(RepositoryItemLookUpEdit lue)
        {
            DavaAdiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void DavaAdi(LookUpEdit lue)
        {
            DavaAdiGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void DavaAdiGetir(RepositoryItemLookUpEdit lue)
        {
            DavaAdiGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_DAVA_ADI
        /// </summary>
        /// <param name="lue"></param
        public static void DavaAdiGetir(LookUpEdit lue)
        {
            lue.Properties.NullText = "Seç";
            DavaAdiGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_DAVA_ADI
        /// </summary>
        /// <param name="lue"></param
        public static void DavaAdiGetir(RepositoryItemLookUpEdit lue, int Id)
        {
            if (_DavaAdiGetir != null)
            {
                lue.DataSource = _DavaAdiGetir.Where(item => item.ADLI_BIRIM_BOLUM_ID == Id).OrderByDescending(item => item.DAVA_ADI);
            }
            else
                lue.DataSource = context.per_TDI_KOD_DAVA_ADIs.Where(item => item.ADLI_BIRIM_BOLUM_ID == Id).OrderByDescending(item => item.DAVA_ADI);

            //GetByADLI_BIRIM_BOLUM_ID(Id);
            lue.NullText = "Seç";
            lue.DisplayMember = "DAVA_ADI";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("DAVA_ADI", "Dava Neden", 100));
        }

        public static void DavaAdiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_DavaAdiGetir == null)
                {
                    if (CodeInfo<AvukatProLib.Arama.per_TDI_KOD_DAVA_ADI>.ListeVarmi(typeof(AvukatProLib.Arama.per_TDI_KOD_DAVA_ADI)))
                        _DavaAdiGetir = CodeInfo<AvukatProLib.Arama.per_TDI_KOD_DAVA_ADI>.ListeGetir(typeof(AvukatProLib.Arama.per_TDI_KOD_DAVA_ADI)) as List<AvukatProLib.Arama.per_TDI_KOD_DAVA_ADI>;
                    else
                    {
                        _DavaAdiGetir = context.per_TDI_KOD_DAVA_ADIs.ToList();
                        CodeInfo<AvukatProLib.Arama.per_TDI_KOD_DAVA_ADI>.ListeKaydet(_DavaAdiGetir, typeof(AvukatProLib.Arama.per_TDI_KOD_DAVA_ADI));
                    }
                }
                lue.SearchMode = SearchMode.AutoComplete;
                lue.DataSource = _DavaAdiGetir;
                lue.PopupWidth = 400;
                lue.DisplayMember = "DAVA_ADI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("DAVA_ADI", "Dava Neden", 400));
            }
        }

        public static void DavaAdiGetirByDavaTipi(RepositoryItemLookUpEdit lue, int adliBirimBolumID)
        {
            lue.NullText = "Seç";
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_DAVA_ADIProvider.GetByADLI_BIRIM_BOLUM_ID(adliBirimBolumID);
            lue.DisplayMember = "DAVA_ADI";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("DAVA_ADI", "Dava Neden", 100));
        }

        public static void DavaAdiGetirForDavaNedenAyarlar(RepositoryItemLookUpEdit lue)
        {
            DavaAdiGetirForDavaNedenAyarlar_Enter(lue, EventArgs.Empty);
        }

        public static void DavaAdiGetirForDavaNedenAyarlar_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_DavaAdiGetir == null)
                {
                    _DavaAdiGetir = context.per_TDI_KOD_DAVA_ADIs.ToList();
                }
                lue.NullText = "Seç";
                lue.DataSource = _DavaAdiGetir;
                lue.DisplayMember = "DAVA_ADI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("DAVA_ADI", "Dava Neden", 100));
            }
        }

        /// <summary>
        /// TDI_KOD_DAVA_ADI
        /// </summary>
        /// <param name="lue">Sadece Dava Adý getiriyor dava neden kod deðil isim yanlýþ
        /// verilmiþ</param>
        public static void DavaAdNedenKodGetir(RepositoryItemLookUpEdit lue)
        {
            DavaAdNedenKodGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_DAVA_ADI
        /// </summary>
        /// <param name="lue"></param
        public static void DavaAdNedenKodGetir(LookUpEdit lue)
        {
            DavaAdNedenKodGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void DavaAdNedenKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_DavaAdNedenKodGetir == null)
                {
                    _DavaAdNedenKodGetir = context.per_TDI_KOD_DAVA_ADIs.ToList();
                }
                lue.NullText = "Seç";
                lue.DataSource = _DavaAdNedenKodGetir;
                lue.DisplayMember = "DAVA_ADI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("DAVA_ADI", "Dava Adý", 100));
            }
        }

        public static void DavaAltTurGetir(RepositoryItemLookUpEdit rLue)
        {
            DavaAltTurGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void DavaAltTurGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_DavaAltTurGetir == null)
                {
                    _DavaAltTurGetir = DataRepository.per_TDI_KOD_DAVA_ALT_TURProvider.GetAll();
                }
                rLue.DataSource = _DavaAltTurGetir;
                rLue.DisplayMember = "ALT_TUR";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("ALT_TUR", 30, "Dava Alt Tür"));
            }
        }

        public static void DavaAnaTurGetir(RepositoryItemLookUpEdit rLue)
        {
            DavaAnaTurGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void DavaAnaTurGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_DavaAnaTurGetir == null)
                {
                    _DavaAnaTurGetir = DataRepository.per_TDI_KOD_DAVA_ANA_TURProvider.GetAll();
                }
                rLue.DataSource = _DavaAnaTurGetir;
                rLue.DisplayMember = "DAVA_ANA_TUR_ADI";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("DAVA_ANA_TUR_ADI", 30, "Dava Ana Tür"));
            }
        }

        public static List<AvukatProLib.Arama.VTD_DAVA_DOSYALAR> DavaDosyalariGetir()
        {
            if (_DavaDosyalar == null)
                _DavaDosyalar = context.VTD_DAVA_DOSYALARs.ToList();
            return _DavaDosyalar;
        }

        public static List<AvukatProLib.Arama.VTD_DAVA_DOSYALAR> DavaDosyalariGetirbySube(int subeKodId)
        {
            if (_DavaDosyalar != null)
                return _DavaDosyalar.FindAll(item => item.SUBE_KOD_ID == subeKodId);
            return context.VTD_DAVA_DOSYALARs.Where(item => item.SUBE_KOD_ID == subeKodId).ToList();
        }

        public static void DavaHarcTipiGetir(RepositoryItemLookUpEdit rLue)
        {
            DavaHarcTipiGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void DavaHarcTipiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_DavaHarcTipi == null)
                {
                    _DavaHarcTipi = AvukatProLib2.Data.DataRepository.per_TD_KOD_HARC_NISPIProvider.GetAll();
                }
                rLue.DataSource = _DavaHarcTipi;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "HARC_ADI";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("HARC_ADI", "Nispi Harç Adý", 100));
            }
        }

        public static void DavaKonuGetirByAdliBirimBolumKod(RepositoryItemLookUpEdit lue, int davaTipi)
        {
            //if (AvukatProLib.Kimlik.SirketBilgisi.KurumsalMod == 1001)
            //{
            //    TList<TD_KOD_DAVA_TALEP> _DavaTalepGetir2 = null;
            //    TD_KOD_DAVA_TALEPQuery qu = new TD_KOD_DAVA_TALEPQuery();
            //    qu.AppendEquals(TD_KOD_DAVA_TALEPColumn.STAMP, "1");
            //    qu.AppendEquals(TD_KOD_DAVA_TALEPColumn.ADLI_BIRIM_BOLUM_ID, davaTipi.ToString());
            //    _DavaTalepGetir2 = DataRepository.TD_KOD_DAVA_TALEPProvider.Find(qu);
            //    lue.DataSource = _DavaTalepGetir2;
            //}
            //else
            //    lue.DataSource = DataRepository.TD_KOD_DAVA_TALEPProvider.GetByADLI_BIRIM_BOLUM_ID(davaTipi);

            if (_DavaTalepGetir == null)
            {
                _DavaTalepGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_DAVA_TALEPProvider.GetAll();
            }
            lue.DataSource = _DavaTalepGetir.Where(item => item.ADLI_BIRIM_BOLUM_ID == davaTipi);
            lue.DisplayMember = "DAVA_TALEP";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("DAVA_TALEP", "Talep", 40));
        }

        public static void DavaNedenBilGetir(RepositoryItemLookUpEdit lue, int davaFoyId)
        {
            lue.DataSource = BelgeUtil.Inits.context.per_AV001_TD_BIL_DAVA_NEDENIs.Where(item => item.FOY_ID == davaFoyId);
            lue.NullText = "Seç";
            lue.DisplayMember = "DIGER_DAVA_NEDEN";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("DIGER_DAVA_NEDEN", "Dava Neden", 100));
        }

        public static void DavaNedenByFoy(AV001_TD_BIL_FOY foy, DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit rGlue)
        {
            var davaNedenList = BelgeUtil.Inits.context.per_AV001_TD_BIL_DAVA_NEDENIs.Where(item => item.FOY_ID == foy.ID).ToList();

            GridColumn gColumnDavaNedeni = new GridColumn();
            GridColumn gColumnTutar = new GridColumn();
            GridColumn gColumnTutarDoviz = new GridColumn();
            GridColumn gColumnTarihi = new GridColumn();

            RepositoryItemLookUpEdit rLueDoviz = new RepositoryItemLookUpEdit();
            RepositoryItemSpinEdit rSpinTutar = new RepositoryItemSpinEdit();

            DovizTipGetir(rLueDoviz);
            ParaBicimiAyarla(rSpinTutar);

            gColumnDavaNedeni.FieldName = "DIGER_DAVA_NEDEN";
            gColumnTutar.FieldName = "TUTAR";
            gColumnTutarDoviz.FieldName = "TUTAR_DOVIZ_ID";
            gColumnTarihi.FieldName = "OLAY_SUC_TARIHI";

            gColumnDavaNedeni.Caption = "Dava Nedeni";
            gColumnTutar.Caption = "Tutarý";
            gColumnTutarDoviz.Caption = " ";
            gColumnTarihi.Caption = "Tarihi";

            gColumnTutarDoviz.ColumnEdit = rLueDoviz;
            gColumnTutar.ColumnEdit = rSpinTutar;

            gColumnDavaNedeni.VisibleIndex = 0;
            gColumnTutar.VisibleIndex = 1;
            gColumnTutarDoviz.VisibleIndex = 2;
            gColumnTarihi.VisibleIndex = 3;

            rGlue.View.Columns.Add(gColumnDavaNedeni);
            rGlue.View.Columns.Add(gColumnTutar);
            rGlue.View.Columns.Add(gColumnTutarDoviz);
            rGlue.View.Columns.Add(gColumnTarihi);

            rGlue.DataSource = davaNedenList;
            rGlue.ValueMember = "DAVA_NEDEN_ID";
            rGlue.DisplayMember = "DIGER_DAVA_NEDEN";
            rGlue.NullText = "Seç";
        }

        /// <summary>
        /// AV001_TD_BIL_DAVA_NEDEN
        /// </summary>
        /// <param name="lue"></param>
        public static void DavaNedenGetir(RepositoryItemLookUpEdit lue)
        {
            DavaAdiGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TD_KOD_DAVA_NEDEN_TIP
        /// </summary>
        /// <param name="lue"></param>
        public static void DavaNedenTipGetir(RepositoryItemLookUpEdit lue)
        {
            DavaNedenTipGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TD_KOD_DAVA_NEDEN_TIP
        /// </summary>
        /// <param name="lue"></param
        public static void DavaNedenTipGetir(LookUpEdit lue)
        {
            DavaNedenTipGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void DavaNedenTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_DavaNedenTipGetir == null)
                {
                    _DavaNedenTipGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_DAVA_NEDEN_TIPProvider.GetAll();
                }
                lue.NullText = "Seç";
                lue.DataSource = _DavaNedenTipGetir;
                lue.DisplayMember = "DAVA_NEDEN_TIP";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("DAVA_NEDEN_TIP", "Dava Neden Tip", 100));
            }
        }

        public static void DavaOzelKodGetir(RepositoryItemLookUpEdit rLue)
        {
            DavaOzelKodGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void DavaOzelKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_DavaOzelKodGetir == null)
                {
                    _DavaOzelKodGetir = DataRepository.per_TDI_KOD_DAVA_OZEL_KODProvider.GetAll();
                }
                rLue.DataSource = _DavaOzelKodGetir;
                rLue.DisplayMember = "OZEL_KOD";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("OZEL_KOD", 30, "Dava Özel Kodlar"));
            }
        }

        /// <summary>
        /// AV001_TI_BIL_DAVA_OZET
        /// </summary>
        /// <param name="lue"></param>
        public static void DavaOzetNo(RepositoryItemLookUpEdit lue)
        {
            DavaOzetNo_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// AV001_TI_BIL_DAVA_OZET
        /// </summary>
        /// <param name="lue"></param
        public static void DavaOzetNo(LookUpEdit lue)
        {
            DavaOzetNo_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void DavaOzetNo_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_DavaOzetNo == null)
                {
                    _DavaOzetNo = AvukatProLib2.Data.DataRepository.AV001_TI_BIL_DAVA_OZETProvider.GetAll();
                }
                lue.DataSource = _DavaOzetNo;
                lue.NullText = "Seç";
                lue.DisplayMember = "DAVA_FOY_NO";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("DAVA_FOY_NO", "Dava Özet No", 100));
            }
        }

        public static void DavaSonuclariGetir(RepositoryItemLookUpEdit lue)
        {
            DavaSonuclariGetir_Enter(lue, EventArgs.Empty);
        }

        public static void DavaSonuclariGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_DavaSonuclariGetir == null)
                {
                    _DavaSonuclariGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_DAVA_SONUCProvider.GetAll();
                }
                lue.DataSource = _DavaSonuclariGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "SONUC";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("SONUC", "S", 40));
            }
        }

        public static void DavaSorumluAvukatGetir(LookUpEdit lue, int davaID)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.DataSource = context.per_DavaSorumluAvukats.Where(vi => vi.DAVA_FOY_ID == davaID).ToList();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("AD", 0, "Avukat") });
            lue.Properties.DisplayMember = "AD";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lue">RepositoryItemLookUpEdit</param>
        /// <param name="Id">Adli Birim Bölüm Id</param>
        public static void DavaTalepGetirByAdliBirimBolumKod(RepositoryItemLookUpEdit lue, int Id)
        {
            if (_DavaTalepGetir == null)
            {
                _DavaTalepGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_DAVA_TALEPProvider.GetAll();
            }
            lue.DataSource = _DavaTalepGetir.Where(item => item.ADLI_BIRIM_BOLUM_ID == 1).OrderByDescending(item => item.DAVA_TALEP);

            //if (AvukatProLib.Kimlik.SirketBilgisi.KurumsalMod == 1001)
            //{
            //    TList<TD_KOD_DAVA_TALEP> _DavaTalepGetir2 = null;
            //    TD_KOD_DAVA_TALEPQuery qu = new TD_KOD_DAVA_TALEPQuery();
            //    qu.AppendEquals(TD_KOD_DAVA_TALEPColumn.STAMP, "1");
            //    qu.AppendEquals(TD_KOD_DAVA_TALEPColumn.ADLI_BIRIM_BOLUM_ID, Id.ToString());
            //    _DavaTalepGetir2 = DataRepository.TD_KOD_DAVA_TALEPProvider.Find(qu);
            //    lue.DataSource = _DavaTalepGetir2;
            //}
            //else
            //    lue.DataSource = DataRepository.per_TD_KOD_DAVA_TALEPProvider.Get(" ADLI_BIRIM_BOLUM_ID=" + Id, "DAVA_TALEP DESC");
            //GetByADLI_BIRIM_BOLUM_ID(Id);
            lue.DisplayMember = "DAVA_TALEP";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("DAVA_TALEP", "Talep", 40));
        }

        public static void DavaTalepGetirForDavaNedenAyarlar(RepositoryItemLookUpEdit lue)
        {
            DavaTalepGetirForDavaNedenAyarlar_Enter(lue, EventArgs.Empty);
        }

        public static void DavaTalepGetirForDavaNedenAyarlar_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_DavaTalepGetir == null)
                {
                    _DavaTalepGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_DAVA_TALEPProvider.GetAll();
                }
                lue.DataSource = _DavaTalepGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "DAVA_TALEP";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("DAVA_TALEP", "Talep", 40));
            }
        }

        /// <summary>
        /// TD_KOD_DAVA_TALEP
        /// </summary>
        /// <param name="rLue"></param>
        public static void DavaTalepKodGetir(RepositoryItemLookUpEdit rLue)
        {
            DavaTalepKodGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void DavaTalepKodGetir(LookUpEdit lue)
        {
            DavaTalepKodGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void DavaTalepKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_DavaTalepGetir == null)
                {
                    _DavaTalepGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_DAVA_TALEPProvider.GetAll();
                }
                lue.DataSource = _DavaTalepGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "DAVA_TALEP";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("DAVA_TALEP", "Dava Talep Getir", 40));
            }
        }

        public static void DavaTarafSifatGetir(RepositoryItemLookUpEdit rLue)
        {
            DavaTarafSifatGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void DavaTarafSifatGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_CariSifatGetir == null || _CariSifatGetir.Count == 0)
                {
                    _CariSifatGetir = context.per_TDIE_KOD_TARAF_SIFATs.ToList();
                }
                _DavaTarafSifatGetir = _CariSifatGetir.FindAll(vi => vi.HANGI_TARAF_NO == 4 || vi.HANGI_TARAF_NO == 3);

                //sifat.Filter = "HANGI_TARAF_NO = " + 4;
                rLue.DataSource = _DavaTarafSifatGetir;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "SIFAT";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("SIFAT", "Taraf Sýfat", 100));
            }
        }

        //Þablon kaydýndan yeni sablonun ilgili yere gelmesini saðlamak için eklendi. MB
        public static void DeleteAndCreateFolder(string filePath)
        {
            File.Delete(filePath);

            CodeInfo<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>.ListeKaydet(BelgeUtil.Inits.context.VDIE_BIL_SABLON_RAPORs.ToList(), typeof(AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR));
        }

        public static void DigerVergiVergiTuruGetir(RepositoryItemLookUpEdit rLue)
        {
            DigerVergiVergiTuruGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void DigerVergiVergiTuruGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_DigerVergiTuruGetir == null)
                {
                    _DigerVergiTuruGetir = DataRepository.per_TDI_KOD_DIGER_VERGIProvider.GetAll();
                }
                rLue.DataSource = _DigerVergiTuruGetir;
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("AD", 30, "Vergi Türü"));
            }
        }

        public static void DilKodGetir(RepositoryItemLookUpEdit rLue)
        {
            DilKodGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void DilKodGetir(LookUpEdit lue)
        {
            DilKodGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void DilKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_DilKodGetir == null)
                {
                    _DilKodGetir = AvukatProLib2.Data.DataRepository.per_TDIE_KOD_DILProvider.GetAll();
                }
                lue.DataSource = _DilKodGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "DIL";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("DIL", "Dil", 40));
            }
        }

        public static void DokumanUzantiComboBox(RepositoryItemImageComboBox rLueBelgeDosyaUzanti)
        {
            ImageList ýmageList1 = GetImageList(4);
            rLueBelgeDosyaUzanti.Items.AddRange(DokumanUzantiResimleri(ýmageList1));
            rLueBelgeDosyaUzanti.SmallImages = ýmageList1;
            rLueBelgeDosyaUzanti.LargeImages = ýmageList1;
            rLueBelgeDosyaUzanti.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
        }

        public static List<DevExpress.XtraEditors.Controls.ImageComboBoxItem> DokumanUzantiResimleri(ImageList lstImg)
        {
            List<DevExpress.XtraEditors.Controls.ImageComboBoxItem> resimler = new List<DevExpress.XtraEditors.Controls.ImageComboBoxItem>();

            string[] uzantilar = new string[] {
             "pst",
             "htm",
             "html",
             "mdb",
             "pst",
             "jpg",
             "jpeg",
             "gif",
             "png",
             "ico",
             "bmp",
             "wma",
             "wax",
             "wma",
             "mp3",
             "mp4",
             "wmx",
             "wmv",
             "asf",
             "avi",
             "mpeg",
             "mpeg4",
             "mpg",
             "pst",
             "xml",
             "xst",
             "xaml",
             "dtd",
             "docx",
             "xlsx",
             "xls",
             "doc",
             "pdf",
             "log",
             "txt",
             "rtf",
             "msg"
            };

            for (int i = 0; i < lstImg.Images.Count; i++)
            {
                resimler.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(uzantilar[i], i));
            }

            return resimler;
        }

        public static object DosyaDoldur(string modul)
        {
            object dtSrc = new object();
            if (!string.IsNullOrEmpty(modul))
            {
                switch (modul)
                {
                    case "Icra":
                        if (_IcraDosyalarArama == null)
                        {
                            //aykut hýzlandýrma 11.02.2013
                            //_IcraDosyalarArama = context.per_AV001_TI_BIL_ICRA_Aramas.ToList();
                            _IcraDosyalarArama = IcraDosyalariGetir();
                        }
                        dtSrc = _IcraDosyalarArama;
                        break;

                    case "Dava":
                        if (_DavaDosyalar == null)
                        {
                            _DavaDosyalar = context.VTD_DAVA_DOSYALARs.ToList();
                        }
                        dtSrc = _DavaDosyalar;
                        break;

                    case "Soruþturma":
                        if (_SorusturmaDosyalar == null)
                        {
                            _SorusturmaDosyalar = context.VTD_SORUSTURMA_DOSYALARs.ToList();
                        }
                        dtSrc = _SorusturmaDosyalar;
                        break;

                    case "Sözleþme":
                        if (_SozlesmeDosyalar == null)
                        {
                            _SozlesmeDosyalar = context.VTD_SOZLESME_DOSYALARs.ToList();
                        }
                        dtSrc = _SozlesmeDosyalar;
                        break;

                    case "Vekalet":
                        if (_TEMSIL_TARAF_SORUMLU_BIRLESIK == null)
                        {
                            _TEMSIL_TARAF_SORUMLU_BIRLESIK = context.per_TEMSIL_TARAF_SORUMLU_BIRLESIKs.ToList();
                        }
                        dtSrc = _TEMSIL_TARAF_SORUMLU_BIRLESIK;
                        break;

                    case "Haciz":
                        if (_HACIZLI_MALLAR_MASTER_CHILD == null)
                        {
                            _HACIZLI_MALLAR_MASTER_CHILD = context.per_HACIZLI_MALLAR_MASTER_CHILDs.ToList();
                        }
                        dtSrc = _HACIZLI_MALLAR_MASTER_CHILD;
                        break;

                    case "Satis":
                        if (_R_BIRLESIK_TAKIPLER_SATIS == null)
                            _R_BIRLESIK_TAKIPLER_SATIS = context.per_R_BIRLESIK_TAKIPLER_SATIs.ToList();
                        dtSrc = _R_BIRLESIK_TAKIPLER_SATIS;
                        break;

                    case "Duruþma/Celse":
                        if (_Celseler == null)
                            _Celseler = DataRepository.AV001_TD_BIL_CELSEProvider.GetAll();
                        dtSrc = _Celseler;
                        break;

                    case "Fatura":
                        if (_VDI_BIL_FATURA_FOR_CARI_TAKIP == null)
                        {
                            _VDI_BIL_FATURA_FOR_CARI_TAKIP = context.per_AV001_TDI_BIL_FATURAs.ToList();
                        }
                        dtSrc = _VDI_BIL_FATURA_FOR_CARI_TAKIP;
                        break;

                    case "Kiymetli Evrak":
                        if (_VDIE_PROJE_KIYMETLI_EVRAK == null)
                        {
                            _VDIE_PROJE_KIYMETLI_EVRAK = context.per_AV001_TDI_BIL_KIYMETLI_EVRAKs.ToList();
                        }
                        dtSrc = _VDIE_PROJE_KIYMETLI_EVRAK;
                        break;

                    default:
                        break;
                }
            }
            return dtSrc;
        }

        public static void DosyaDoldur(string modul, LookUpEdit rLue)
        {
            object dtSrc = new object();
            if (!string.IsNullOrEmpty(modul))
            {
                switch (modul)
                {
                    case "Icra":
                        dtSrc = DosyaDoldur(modul);
                        rLue.Properties.DataSource = dtSrc;
                        rLue.Properties.DisplayMember = "FOY_NO";
                        rLue.Properties.ValueMember = "ID";
                        rLue.Properties.Columns.Clear();
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FOY_NO", "Dosya No", 100));
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TAKIP_TARIHI", "Takip T", 100));
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ESAS_NO", "Esas No", 100));
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADLI_BIRIM_ADLIYE", "Adliye", 100));
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GOREV", "Görev", 100));
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADLI_BIRIM_NO", "Birim No", 100));
                        break;

                    case "Dava":
                        dtSrc = DosyaDoldur(modul);
                        rLue.Properties.DataSource = dtSrc;
                        rLue.Properties.DisplayMember = "FOY_NO";
                        rLue.Properties.ValueMember = "ID";
                        rLue.Properties.Columns.Clear();
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FOY_NO", "Dosya No", 100));
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DAVA_TARIHI", "Dava T", 100));
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ESAS_NO", "Esas No", 100));
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADLIYE", "Adliye", 100));
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GOREV", "Görev", 100));
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NO", "Birim No", 100));
                        break;

                    case "Soruþturma":
                        dtSrc = DosyaDoldur(modul);
                        rLue.Properties.DataSource = dtSrc;
                        rLue.Properties.DisplayMember = "HAZIRLIK_NO";
                        rLue.Properties.ValueMember = "ID";
                        rLue.Properties.Columns.Clear();
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HAZIRLIK_NO", "Dosya No", 100));
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HAZIRLIK_ESAS_NO", "Esas No", 100));
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADLIYE", "Adliye", 100));
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GOREV", "Görev", 100));
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NO", "Birim No", 100));
                        break;

                    case "Sözleþme":
                        dtSrc = DosyaDoldur(modul);
                        rLue.Properties.DataSource = dtSrc;
                        rLue.Properties.DisplayMember = "SOZLESME_NO";
                        rLue.Properties.ValueMember = "ID";
                        rLue.Properties.Columns.Clear();
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SOZLESME_NO", "Dosya No", 100));
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SICIL_YEVMIYE_NO", "Esas No", 100));
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADLIYE", "Adliye", 100));
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GOREV", "Görev", 100));
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NO", "Birim No", 100));
                        break;

                    case "Vekalet":
                        dtSrc = DosyaDoldur(modul);
                        rLue.Properties.DataSource = dtSrc;
                        rLue.Properties.DisplayMember = "DOSYA_NO";
                        rLue.Properties.ValueMember = "ID";
                        rLue.Properties.Columns.Clear();
                        rLue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DOSYA_NO", "Dosya No", 100));
                        break;

                    default:
                        rLue.Properties.DataSource = null;
                        break;
                }
            }
        }

        ///<summary>
        ///  TDI_KOD_FOY_DURUM
        /// /// </summary>
        /// <param name="rLue"></param>
        public static void DosyaDurumGetir(LookUpEdit lue)
        {
            DosyaDurumGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void DosyaDurumGetir(RepositoryItemLookUpEdit lue)
        {
            DosyaDurumGetir_Enter(lue, EventArgs.Empty);
        }

        public static void DosyaDurumGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_DosyaDurumGetir == null)
                    _DosyaDurumGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_FOY_DURUMProvider.GetAll();

                lue.DataSource = _DosyaDurumGetir;
                lue.DisplayMember = "DURUM";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("DURUM", 10, "Dosya Durum"));
            }
        }

        public static void DosyaHedefTipGetir(RepositoryItemLookUpEdit lue)
        {
            DosyaHedefTipGetir_Enter(lue, EventArgs.Empty);
        }

        public static void DosyaHedefTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("DosyaHedefTip");
                dt.Columns.Add("ID");
                dt.Columns.Add("DosyaHedefTip");
                foreach (AvukatProLib.Extras.DosyaTip tipi in Enum.GetValues(typeof(AvukatProLib.Extras.DosyaTip)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "DosyaHedefTip";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("DosyaHedefTip", 30, "Dosya Hedef Tipi"));
            }
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> DosyaSorumluAvukatGetir(AV001_TI_BIL_FOY foy, RepositoryItemLookUpEdit[] controls)
        {
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>();

            if (_DosyaSorumluAvukatGetir == null)
            {
                _DosyaSorumluAvukatGetir = context.per_AV001_TI_BIL_FOY_SORUMLU_AVUKATs.ToList();
            }

            if (_per_CariGetir != null)
            {
                _DosyaSorumluAvukatGetir.ForEach(item =>
                    {
                        cariList.AddRange(_per_CariGetir.Where(cari => cari.ID == item.SORUMLU_AVUKAT_CARI_ID));
                    });
            }
            else
            {
                _DosyaSorumluAvukatGetir.ForEach(item =>
                    {
                        cariList.AddRange(context.per_AV001_TDI_BIL_CARIs.Where(cari => cari.ID == item.SORUMLU_AVUKAT_CARI_ID));
                    });
            }

            foreach (RepositoryItemLookUpEdit rLue in controls)
            {
                rLue.DataSource = cariList;
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                    {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KOD", 10, "Kod"),
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AD", 30, "Ad")
                    });

                rLue.NullText = "Seç";
            }

            return cariList;
        }

        public static TDI_KOD_DOVIZ_TIP DovizIdSource(int id)
        {
            var dovizTip = DovizSource.Where(vi => vi.ID == id);
            return dovizTip.Count() > 0 ? dovizTip.First() : null;
        }

        /// <summary>
        /// DavaDovizIslemTipi
        /// </summary>
        /// <param name="lue"></param>
        public static void DovizIslemTipiGetir(LookUpEdit lue)
        {
            DovizIslemTipiGetir2_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void DovizIslemTipiGetir(RepositoryItemLookUpEdit lue)
        {
            DovizIslemTipiGetir2_Enter(lue, EventArgs.Empty);
        }

        public static void DovizIslemTipiGetir(RepositoryItemLookUpEdit[] controls)
        {
            foreach (var item in controls)
            {
                DovizIslemTipiGetir2_Enter(item, EventArgs.Empty);
            }
        }

        public static void DovizIslemTipiGetir2_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("DovizIslemTipi");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.DavaDovizIslemTipi tipi in Enum.GetValues(typeof(AvukatProLib.Extras.DavaDovizIslemTipi)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();

                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Döviz Ýþlem Tipi"));
            }
        }

        public static void DovizTipGetir(LookUpEdit lue)
        {
            DovizTipGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void DovizTipGetir(RepositoryItemLookUpEdit lue)
        {
            DovizTipGetir_Enter(lue, EventArgs.Empty);
        }

        public static void DovizTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_DovizTipGetir == null)
                {
                    if (CodeInfo<per_TDI_KOD_DOVIZ_TIP>.ListeVarmi(typeof(per_TDI_KOD_DOVIZ_TIP)))
                        _DovizTipGetir = CodeInfo<per_TDI_KOD_DOVIZ_TIP>.ListeGetir(typeof(per_TDI_KOD_DOVIZ_TIP)) as VList<per_TDI_KOD_DOVIZ_TIP>;
                    else
                    {
                        _DovizTipGetir = DataRepository.per_TDI_KOD_DOVIZ_TIPProvider.GetAll();
                        CodeInfo<per_TDI_KOD_DOVIZ_TIP>.ListeKaydet(_DovizTipGetir, typeof(per_TDI_KOD_DOVIZ_TIP));
                    }
                }

                lue.DataSource = _DovizTipGetir;
                lue.DisplayMember = "DOVIZ_KODU";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";

                //lue.Columns.Clear();
                if (lue.Columns.Count == 0)
                    lue.Columns.Add(new LookUpColumnInfo("DOVIZ_KODU", 10, "Birim"));
            }
        }

        public static void DusmeYenilemeNedeniGetir(LookUpEdit lue)
        {
            DusmeYenilemeNedeniGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void DusmeYenilemeNedeniGetir(RepositoryItemLookUpEdit lue)
        {
            if (_DusmeYenilemeNedeni == null)
                _DusmeYenilemeNedeni = DataRepository.TDI_KOD_DUSME_DEGISME_KODUProvider.GetAll();

            lue.Columns.Clear();
            lue.DataSource = _DusmeYenilemeNedeni;
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("DUS_DEG_KODU", 20, "Deðiþim Nedeni") });
            lue.DisplayMember = "DUS_DEG_KODU";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        public static void DusmeYenilemeNedeniGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_DusmeYenilemeNedeni == null)
                    _DusmeYenilemeNedeni = DataRepository.TDI_KOD_DUSME_DEGISME_KODUProvider.GetAll();

                lue.Columns.Clear();
                lue.DataSource = _DusmeYenilemeNedeni;
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("DUS_DEG_KODU", 20, "Deðiþim Nedeni") });
                lue.DisplayMember = "DUS_DEG_KODU";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void FaizIslemTipiGetir(RepositoryItemLookUpEdit lue)
        {
            FaizIslemTipiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void FaizIslemTipiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("FaizIslemTipi");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.DavaFaizIslemTipi tipi in Enum.GetValues(typeof(AvukatProLib.Extras.DavaFaizIslemTipi)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Faiz Ýþlem Tipi"));
            }
        }

        public static void FaizKalemGetir(RepositoryItemLookUpEdit rLue)
        {
            FaizKalemGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void FaizKalemGetir(LookUpEdit lue)
        {
            FaizKalemGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void FaizKalemGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_FaizKalemGetir == null)
                {
                    _FaizKalemGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_FAIZ_KALEMProvider.GetAll();
                }
                lue.DataSource = _FaizKalemGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "FAIZ_KALEMI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("FAIZ_KALEMI", "Faiz Kalemi", 40));
            }
        }

        public static void FaizTipiGetir(LookUpEdit lue)
        {
            FaizTipiGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void FaizTipiGetir(RepositoryItemLookUpEdit lue)
        {
            FaizTipiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void FaizTipiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;

            if (lue == null)
                return;

            if (lue.DataSource == null)
            {
                if (_FaizTipiGetir == null)
                {
                    if (CodeInfo<per_TDI_KOD_FAIZ_TIP>.ListeVarmi(typeof(per_TDI_KOD_FAIZ_TIP)))
                        _FaizTipiGetir = CodeInfo<per_TDI_KOD_FAIZ_TIP>.ListeGetir(typeof(AvukatProLib2.Entities.per_TDI_KOD_FAIZ_TIP)) as VList<per_TDI_KOD_FAIZ_TIP>;
                    else
                    {
                        _FaizTipiGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_FAIZ_TIPProvider.GetAll();
                        CodeInfo<per_TDI_KOD_FAIZ_TIP>.ListeKaydet(_FaizTipiGetir, typeof(per_TDI_KOD_FAIZ_TIP));
                    }
                }
                lue.DataSource = _FaizTipiGetir;
                lue.ValueMember = "ID";
                lue.DisplayMember = "FAIZ_TIP";
                lue.NullText = "Seç";
                LookUpColumnInfo c = new LookUpColumnInfo("ID", 2, "id");
                c.Visible = false;
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { c, new LookUpColumnInfo("FAIZ_TIP", 20, "Faiz Tip") });
            }
        }

        public static void FaturaHedefTipGetir(RepositoryItemLookUpEdit lue)
        {
            FaturaHedefTipGetir_Enter(lue, EventArgs.Empty);
        }

        public static void FaturaHedefTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("HedefTip");
                dt.Columns.Add("ID");
                dt.Columns.Add("HEDEF_TIP");
                foreach (AvukatProLib.Extras.FaturaHedefTip tipi in Enum.GetValues(typeof(AvukatProLib.Extras.FaturaHedefTip)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }

                lue.DataSource = dt;
                lue.DisplayMember = "HEDEF_TIP";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("HEDEF_TIP", 30, "Hedef Tipi"));
            }
        }

        public static void FaturaKapsamTipGetir(RepositoryItemLookUpEdit lue)
        {
            FaturaKapsamTipGetir_Enter(lue, EventArgs.Empty);
        }

        public static void FaturaKapsamTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("HedefTip");
                dt.Columns.Add("ID");
                dt.Columns.Add("KAPSAM_TIP");
                foreach (AvukatProLib.Extras.FaturaKapsamTip tipi in Enum.GetValues(typeof(AvukatProLib.Extras.FaturaKapsamTip)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }

                lue.DataSource = dt;
                lue.DisplayMember = "KAPSAM_TIP";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("KAPSAM_TIP", 30, "Hedef Tipi"));
            }
        }

        public static void FeragatHesapKalemGetir(RepositoryItemLookUpEdit rLue)
        {
            FeragatHesapKalemGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void FeragatHesapKalemGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_per_TI_KOD_FERAGAT_HESAP_KALEM == null)
                    _per_TI_KOD_FERAGAT_HESAP_KALEM = AvukatProLib2.Data.DataRepository.per_TI_KOD_FERAGAT_HESAP_KALEMProvider.GetAll();

                rLue.DataSource = _per_TI_KOD_FERAGAT_HESAP_KALEM;
                rLue.DisplayMember = "ACIKLAMA";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ACIKLAMA"));
                rLue.NullText = "Alacak Kalemi Seç";
            }
        }

        public static void FeragatKapsamiGetir(LookUpEdit lue)
        {
            FeragatKapsamiGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void FeragatKapsamiGetir(RepositoryItemLookUpEdit lue)
        {
            FeragatKapsamiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void FeragatKapsamiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("dtFeragatKapsami");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.FeragatKapsami tipi in Enum.GetValues(typeof(AvukatProLib.Extras.FeragatKapsami)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Feragat Kapsamý"));
            }
        }

        public static void FeragatTipiGetir(LookUpEdit lue)
        {
            FeragatTipiGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void FeragatTipiGetir(RepositoryItemLookUpEdit lue)
        {
            FeragatTipiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void FeragatTipiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("dtFeragatTipi");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.FeragatTipi tipi in Enum.GetValues(typeof(AvukatProLib.Extras.FeragatTipi)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Feragat Tipi"));
            }
        }

        public static void FirmaTurGetir(LookUpEdit lue)
        {
            FirmaTurGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void FirmaTurGetir(RepositoryItemLookUpEdit lue)
        {
            FirmaTurGetir_Enter(lue, EventArgs.Empty);
        }

        public static void FirmaTurGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_FirmaTurGetir_Enter == null)
                {
                    _FirmaTurGetir_Enter = AvukatProLib2.Data.DataRepository.per_TDI_KOD_FIRMA_TURProvider.GetAll();
                }
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("TUR", 10, "Tür") });
                lue.DataSource = _FirmaTurGetir_Enter;
                lue.DisplayMember = "TUR";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void FormTipiGetir(RepositoryItemLookUpEdit lue)
        {
            FormTipiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void FormTipiGetir(GridControl lue)
        {
            //lue.DisplayMember = "Ozet";
            //lue.ValueMember = "ID";
            if (_FormTipiGetir == null)
            {
                _FormTipiGetir = context.per_TI_KOD_FORM_TIPs.Where(item => item.FORM_ORNEK_NO != "48").ToList();
            }
            GridColumn clm = new GridColumn();
            clm.FieldName = "IsSelected";
            clm.Caption = "Seç";
            clm.Width = 50;
            clm.Visible = true;

            GridColumn clm2 = new GridColumn();
            clm2.FieldName = "Ozet";
            clm2.Caption = "No";
            clm2.Width = 100;
            clm2.Visible = true;

            GridColumn clm3 = new GridColumn();
            clm3.FieldName = "FORM_ADI";
            clm3.Caption = "Açýklama";
            clm3.Width = 300;
            clm3.Visible = true;

            ((GridView)lue.MainView).Columns.Add(clm);
            ((GridView)lue.MainView).Columns.Add(clm2);
            ((GridView)lue.MainView).Columns.Add(clm3);

            lue.DataSource = _FormTipiGetir;
        }

        public static void FormTipiGetir(LookUpEdit lue)
        {
            if (lue.Properties.DataSource == null)
            {
                if (_FormTipiGetir == null)
                {
                    _FormTipiGetir = context.per_TI_KOD_FORM_TIPs.Where(item => item.FORM_ORNEK_NO != "48").ToList();
                }
                lue.Properties.DisplayMember = "FORM_ADI";
                lue.Properties.ValueMember = "ID";
                lue.Properties.DataSource = _FormTipiGetir;
                lue.Properties.Columns.Clear();
                lue.Properties.PopupWidth = 400;
                lue.Properties.Columns.AddRange(new LookUpColumnInfo[]
                                     {
                                         new LookUpColumnInfo("Ozet",100,"No"),
                                         new LookUpColumnInfo("FORM_ADI",300,"Açýklama")
                                     });
                lue.Properties.NullText = "Seç";
            }
        }

        public static void FormTipiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_FormTipiGetir == null)
                {
                    if (CodeInfo<AvukatProLib.Arama.per_TI_KOD_FORM_TIP>.ListeVarmi(typeof(AvukatProLib.Arama.per_TI_KOD_FORM_TIP)))
                        _FormTipiGetir = CodeInfo<AvukatProLib.Arama.per_TI_KOD_FORM_TIP>.ListeGetir(typeof(AvukatProLib.Arama.per_TI_KOD_FORM_TIP)) as List<AvukatProLib.Arama.per_TI_KOD_FORM_TIP>;
                    else
                    {
                        _FormTipiGetir = context.per_TI_KOD_FORM_TIPs.Where(item => item.FORM_ORNEK_NO != "48").ToList();
                        CodeInfo<AvukatProLib.Arama.per_TI_KOD_FORM_TIP>.ListeKaydet(_FormTipiGetir, typeof(AvukatProLib.Arama.per_TI_KOD_FORM_TIP));
                    }

                    foreach (AvukatProLib.Arama.per_TI_KOD_FORM_TIP item in _FormTipiGetir)
                    {
                        item.FORM_ORNEK_NO = "Form " + item.FORM_ORNEK_NO + "(" + item.YENI_FORM_ORNEK_NO + ")";
                    }
                }
                lue.DataSource = _FormTipiGetir;
                lue.DisplayMember = "FORM_ORNEK_NO";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.PopupWidth = 650;
                lue.Columns.AddRange(new LookUpColumnInfo[]
                                     {
                                         new LookUpColumnInfo("FORM_ORNEK_NO",150,"No"),
                                         new LookUpColumnInfo("FORM_ADI",500,"Açýklama")
                                     });
            }
        }

        public static void FormTipineGoreAlacakNeden(RepositoryItemLookUpEdit lue, int formTipID)
        {
            if (_TI_KOD_AlacakNedeniDoldur == null)
            {
                _TI_KOD_AlacakNedeniDoldur = DataRepository.per_TI_KOD_ALACAK_NEDENProvider.GetDistinctByAlacakNeden();
            }
            lue.DataSource = _TI_KOD_AlacakNedeniDoldur;
            lue.NullText = "Seç";
            lue.DisplayMember = "ALACAK_NEDENI";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ALACAK_NEDENI", "Alacak Nedeni", 100));
        }

        /// <summary>
        /// TDI_KOD_FOY_BIRIM
        /// </summary>
        /// <param name="lue"></param>
        ///
        public static void FoyBirimGetir(LookUpEdit lue)
        {
            if (_FoyBirimGetir == null)
                _FoyBirimGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_FOY_BIRIMProvider.GetAll();

            lue.Properties.DataSource = _FoyBirimGetir;
            lue.Properties.ValueMember = "ID";
            lue.Properties.DisplayMember = "FOY_BIRIM";
            lue.Properties.NullText = "Seç";
            LookUpColumnInfo c = new LookUpColumnInfo("ID", 2, "id");
            c.Visible = false;
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { c, new LookUpColumnInfo("FOY_BIRIM", 20, "Föy Birim") });

            //TODO :<TIO - 20092406> ID si 1 olan Föy Birimi sürekli her yerde seçili gelmekteydi tarafýmdan Comment Edildi
            //lue.EditValue = 1;
        }

        public static void FoyBirimGetir(RepositoryItemLookUpEdit lue, int FoyBirimId)
        {
            if (_FoyBirimGetir != null)
            {
                lue.DataSource = _FoyBirimGetir.Where(item => item.ID == FoyBirimId).OrderByDescending(item => item.FOY_BIRIM);
            }
            else
                lue.DataSource = AvukatProLib2.Data.DataRepository.per_TDI_KOD_FOY_BIRIMProvider.Get("ID = " + FoyBirimId, "FOY_BIRIM DESC");
            lue.NullText = "Seç";
            lue.DisplayMember = "FOY_BIRIM";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("FOY_BIRIM", "Föy Birim", 40));
        }

        public static void FoyBirimGetir(RepositoryItemLookUpEdit lue)
        {
            if (_FoyBirimGetir == null)
                _FoyBirimGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_FOY_BIRIMProvider.GetAll();

            lue.DataSource = _FoyBirimGetir;
            lue.NullText = "Seç";
            lue.DisplayMember = "FOY_BIRIM";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("FOY_BIRIM", "Föy Birim", 40));
        }

        public static void FoyBirimGetirEdit(LookUpEdit lue)
        {
            FoyBirimGetirEdit_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void FoyBirimGetirEdit(RepositoryItemLookUpEdit lue)
        {
            FoyBirimGetirEdit_Enter(lue, EventArgs.Empty);
        }

        public static void FoyBirimGetirEdit_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_FoyBirimGetir == null)
                    _FoyBirimGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_FOY_BIRIMProvider.GetAll();

                lue.DataSource = _FoyBirimGetir;
                lue.ValueMember = "ID";
                lue.DisplayMember = "FOY_BIRIM";
                lue.NullText = "Seç";
                LookUpColumnInfo c = new LookUpColumnInfo("ID", 2, "id");
                c.Visible = false;
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { c, new LookUpColumnInfo("FOY_BIRIM", 20, "Föy Birim") });
            }
        }

        public static void FoyDurumGetir(LookUpEdit lue)
        {
            FoyDurumGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void FoyDurumGetir(RepositoryItemLookUpEdit rlue)
        {
            FoyDurumGetir_Enter(rlue, EventArgs.Empty);
        }

        public static void FoyDurumGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_FoyDurumGetir_Enter == null)
                {
                    if (CodeInfo<per_TDI_KOD_FOY_DURUM>.ListeVarmi(typeof(per_TDI_KOD_FOY_DURUM)))
                        _FoyDurumGetir_Enter = CodeInfo<per_TDI_KOD_FOY_DURUM>.ListeGetir(typeof(per_TDI_KOD_FOY_DURUM)) as VList<per_TDI_KOD_FOY_DURUM>;
                    else
                    {
                        _FoyDurumGetir_Enter = AvukatProLib2.Data.DataRepository.per_TDI_KOD_FOY_DURUMProvider.GetAll();
                        CodeInfo<per_TDI_KOD_FOY_DURUM>.ListeKaydet(_FoyDurumGetir_Enter, typeof(per_TDI_KOD_FOY_DURUM));
                    }
                }
                lue.DataSource = _FoyDurumGetir_Enter;
                lue.DisplayMember = "DURUM";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                LookUpColumnInfo DURUM = new LookUpColumnInfo("DURUM", 30, "Föy Durumu");
                lue.Columns.AddRange(new LookUpColumnInfo[] { DURUM });
            }
        }

        public static void FoyIadeNedenGetir(RepositoryItemLookUpEdit rLue)
        {
            FoyIadeNedenGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void FoyIadeNedenGetir(LookUpEdit lue)
        {
            FoyIadeNedenGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void FoyIadeNedenGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_FoyIadeNedenGetir == null)
                {
                    if (CodeInfo<per_TDI_KOD_FOY_IADE_NEDEN>.ListeVarmi(typeof(per_TDI_KOD_FOY_IADE_NEDEN)))
                        _FoyIadeNedenGetir = CodeInfo<per_TDI_KOD_FOY_IADE_NEDEN>.ListeGetir(typeof(per_TDI_KOD_FOY_IADE_NEDEN)) as VList<per_TDI_KOD_FOY_IADE_NEDEN>;
                    else
                    {
                        _FoyIadeNedenGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_FOY_IADE_NEDENProvider.GetAll();
                        CodeInfo<per_TDI_KOD_FOY_IADE_NEDEN>.ListeKaydet(_FoyIadeNedenGetir, typeof(per_TDI_KOD_FOY_IADE_NEDEN));
                    }
                }
                rLue.DataSource = _FoyIadeNedenGetir;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "IADE_NEDEN";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("IADE_NEDEN", "Ýade Nedeni", 100));
            }
        }

        public static void FoyOzelDurumGetir(RepositoryItemLookUpEdit lue)
        {
            FoyOzelDurumGetir_Enter(lue, EventArgs.Empty);
        }

        public static void FoyOzelDurumGetir(LookUpEdit lue)
        {
            FoyOzelDurumGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void FoyOzelDurumGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_FoyOzelDurumGetir == null)
                    _FoyOzelDurumGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_FOY_OZEL_DURUMProvider.GetAll();

                lue.DataSource = _FoyOzelDurumGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "FOY_OZEL_DURUM";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("FOY_OZEL_DURUM", "Özel Durum", 40));
            }
        }

        public static void FoyOzelDurumGetirByFoyBirimId(RepositoryItemLookUpEdit lue, int foyBirimId)
        {
            if (_FoyOzelDurumGetir != null)
                lue.DataSource = _FoyOzelDurumGetir.Where(item => item.FOY_BIRIM_ID == foyBirimId).OrderByDescending(item => item.FOY_OZEL_DURUM);
            else
                lue.DataSource = AvukatProLib2.Data.DataRepository.per_TDI_KOD_FOY_OZEL_DURUMProvider.Get(" FOY_BIRIM_ID=" + foyBirimId, "FOY_OZEL_DURUM DESC");

            lue.NullText = "Seç";
            lue.DisplayMember = "FOY_OZEL_DURUM";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("FOY_OZEL_DURUM", "Özel Durum", 40));
        }

        public static void FoyOzelDurumGetirByFoyBirimId(LookUpEdit lue, int FoyBirimId)
        {
            if (_FoyOzelDurumGetir != null)
                lue.Properties.DataSource = _FoyOzelDurumGetir.Where(item => item.FOY_BIRIM_ID == FoyBirimId).OrderByDescending(item => item.FOY_OZEL_DURUM);
            else
                lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.per_TDI_KOD_FOY_OZEL_DURUMProvider.Get(" FOY_BIRIM_ID=" + FoyBirimId, "FOY_OZEL_DURUM DESC");

            lue.Properties.ValueMember = "ID";
            lue.Properties.DisplayMember = "FOY_OZEL_DURUM";
            lue.Properties.NullText = "Seç";
            LookUpColumnInfo c = new LookUpColumnInfo("ID", 2, "id");
            c.Visible = false;
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { c, new LookUpColumnInfo("FOY_OZEL_DURUM", 20, "Föy Özel Durum") });
            lue.EditValue = 1;
        }

        public static void FoyOzelKodGetir(RepositoryItemLookUpEdit lue, byte alan, Modul modl)
        {
            alanNo = alan;
            modul = modl;
            FoyOzelKodGetirKosullu_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// Föy Özel kodlarýnýn getirilmesi için kullanýlan method. Sadece belirtilen alan ve ilgili
        /// modül için görünmesi gereken Özel kodlarý getirir.
        /// </summary>
        /// <param name="lue">Ýþlemin etkileyeceði control</param>
        /// <param name="AlanNo">Özel kod numarasý 1,2,3,4 olabilir</param>
        /// <param name="modul">Modül sadece ÝCRA,DAVA,SÖZLEÞME,SORUÞTURMA olabilir</param>
        /// <exception cref="Exception"></exception>
        public static void FoyOzelKodGetir(LookUpEdit lue, byte alanNo, Modul modul)
        {
            FoyOzelKodGetir(lue.Properties, alanNo, modul);
        }

        public static void FoyOzelKodGetir(RepositoryItemLookUpEdit lue)
        {
            if (_FoyOzelKodGetir == null)
                _FoyOzelKodGetir = AvukatProLib2.Data.DataRepository.per_AV001_TDI_KOD_FOY_OZELProvider.GetAll();

            lue.DataSource = _FoyOzelKodGetir;
            lue.NullText = "Seç";
            lue.DisplayMember = "KOD";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("KOD", "Föy Özel Kod", 100));
        }

        public static void FoyOzelKodGetir(LookUpEdit lue)
        {
            lue.Properties.NullText = "Seç";
            FoyOzelKodGetir_Enter(lue, EventArgs.Empty);
        }

        public static void FoyOzelKodGetir_Enter(object sender, EventArgs e)
        {
            //ToDo : View yapýlacak

            LookUpEdit lue = (LookUpEdit)sender;
            if (lue.Properties.DataSource == null)
            {
                if (_FoyOzelKodGetir_Enter == null)
                {
                    _FoyOzelKodGetir_Enter = AvukatProLib2.Data.DataRepository.per_AV001_TDI_KOD_FOY_OZELProvider.GetAll();
                }
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 20, "Kod") });
                lue.Properties.DataSource = _FoyOzelKodGetir_Enter;
                lue.Properties.DisplayMember = "KOD";
                lue.Properties.ValueMember = "ID";
            }
        }

        public static void FoyOzelKodGetirKosullu_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (alanNo > 4 || alanNo < 1)
                    throw new Exception(alanNo + " numaralý alan bulunamadý");
                List<AvukatProLib.Arama.per_AV001_TDI_KOD_FOY_OZEL_KOD> list = null;
                switch (modul)
                {
                    case Modul.Icra:
                        if (alanNo == 1)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN1 && vi.ICRA).ToList();
                        if (alanNo == 2)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN2 && vi.ICRA).ToList();
                        if (alanNo == 3)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN3 && vi.ICRA).ToList();
                        if (alanNo == 4)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN4 && vi.ICRA).ToList();
                        break;

                    case Modul.Dava:
                        if (alanNo == 1)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN1 && vi.DAVA).ToList();
                        if (alanNo == 2)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN2 && vi.DAVA).ToList();
                        if (alanNo == 3)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN3 && vi.DAVA).ToList();
                        if (alanNo == 4)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN4 && vi.DAVA).ToList();
                        break;

                    case Modul.Sorusturma:
                        if (alanNo == 1)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN1 && vi.HAZIRLIK).ToList();
                        if (alanNo == 2)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN2 && vi.HAZIRLIK).ToList();
                        if (alanNo == 3)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN3 && vi.HAZIRLIK).ToList();
                        if (alanNo == 4)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN4 && vi.HAZIRLIK).ToList();
                        break;

                    case Modul.Sozlesme:
                        if (alanNo == 1)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN1 && vi.SOZLESME).ToList();
                        if (alanNo == 2)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN2 && vi.SOZLESME).ToList();
                        if (alanNo == 3)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN3 && vi.SOZLESME).ToList();
                        if (alanNo == 4)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN4 && vi.SOZLESME).ToList();
                        break;

                    case Modul.Klasor:
                        if (alanNo == 1)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN1 && !vi.SOZLESME && !vi.HAZIRLIK && !vi.DAVA && !vi.ICRA).ToList();
                        if (alanNo == 2)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN2 && !vi.SOZLESME && !vi.HAZIRLIK && !vi.DAVA && !vi.ICRA).ToList();
                        if (alanNo == 3)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN3 && !vi.SOZLESME && !vi.HAZIRLIK && !vi.DAVA && !vi.ICRA).ToList();
                        if (alanNo == 4)
                            list = context.per_AV001_TDI_KOD_FOY_OZEL_KODs.Where(vi => vi.ALAN4 && !vi.SOZLESME && !vi.HAZIRLIK && !vi.DAVA && !vi.ICRA).ToList();
                        break;

                    default:
                        return;
                }

                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 20, "Kod") });
                lue.DataSource = list;
                lue.DisplayMember = "KOD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void FoyOzelKodGetirProje(LookUpEdit lue)
        {
            FoyOzelKodGetirProje_Enter(lue, EventArgs.Empty);
        }

        public static void FoyOzelKodGetirProje_Enter(object sender, EventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            if (lue.Properties.DataSource == null)
            {
                if (_FoyOzelKodGetirProje == null)
                {
                    _FoyOzelKodGetirProje = AvukatProLib2.Data.DataRepository.per_AV001_TDI_KOD_FOY_OZELProvider.GetAll();
                }
                lue.Properties.NullText = "Seç";
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 20, "Kod") });
                lue.Properties.DataSource = _FoyOzelKodGetirProje;
                lue.Properties.DisplayMember = "KOD";
                lue.Properties.ValueMember = "ID";
            }
        }

        public static void FoyTarafGetir(RepositoryItemLookUpEdit rLue)
        {
            if (_FoyTarafGetir == null)
            {
                _FoyTarafGetir = context.per_AV001_TI_BIL_FOY_TARAFs.ToList();
            }
            rLue.DataSource = _FoyTarafGetir;
            rLue.NullText = "Seç";
            rLue.DisplayMember = "AD";
            rLue.ValueMember = "ID";
            rLue.Columns.Clear();
            rLue.Columns.Add(new LookUpColumnInfo("AD", "Foy Taraf", 100));
        }

        public static List<AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF> FoyTarafGetir(AV001_TI_BIL_FOY foy)
        {
            return FoyTarafGetirByIcra(foy.ID);
        }

        public static void FoyTarafGetir(RepositoryItemLookUpEdit[] controls, AV001_TI_BIL_FOY foy)
        {
            foreach (RepositoryItemLookUpEdit lue in controls)
            {
                if (lue.DataSource == null)
                {
                    lue.DataSource = FoyTarafGetir(foy);
                    lue.DisplayMember = "AD";
                    lue.ValueMember = "CARI_ID";
                    lue.NullText = "Seç";

                    lue.Columns.Clear();
                    lue.Columns.AddRange(new LookUpColumnInfo[]
                    {
                         new LookUpColumnInfo("KOD", 10, "Kod"),
                         new LookUpColumnInfo("AD", 30, "Ad")
                    });
                }
            }
        }

        public static void FoyTarafGetir(RepositoryItemLookUpEdit[] controls, AV001_TD_BIL_FOY foy)
        {
            if (_TD_FoyTarafGetir == null)
            {
                _TD_FoyTarafGetir = context.per_AV001_TD_BIL_FOY_TARAFs.OrderBy(vi => vi.AD).ToList();
            }
            foreach (RepositoryItemLookUpEdit lue in controls)
            {
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[]
                {
                    new LookUpColumnInfo("KOD", 10, "Kod"),
                    new LookUpColumnInfo("AD", 30, "Ad") }
                );

                lue.DataSource = _TD_FoyTarafGetir.Where(item => item.DAVA_FOY_ID == foy.ID);
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void FoyTarafGetir(LookUpEdit lue)
        {
            lue.Properties.NullText = "Seç";
            FoyTarafGetir_Enter(lue, EventArgs.Empty);
        }

        public static List<AvukatProLib.Arama.per_AV001_TD_BIL_FOY_TARAF> FoyTarafGetir(AV001_TD_BIL_FOY foy)
        {
            //if (_TD_FoyTarafGetir == null || _TD_FoyTarafGetir.Count == 0)
            //{
            //    _TD_FoyTarafGetir = context.per_AV001_TD_BIL_FOY_TARAFs.Where(item => item.DAVA_FOY_ID == foy.ID).OrderBy(vi => vi.AD).ToList();
            //}
            //return _TD_FoyTarafGetir;

            return context.per_AV001_TD_BIL_FOY_TARAFs.Where(item => item.DAVA_FOY_ID == foy.ID).OrderBy(vi => vi.AD).ToList();
        }

        public static void FoyTarafGetir_Enter(object sender, EventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            if (lue.Properties.DataSource == null)
            {
                if (_FoyTarafGetir == null)
                {
                    _FoyTarafGetir = context.per_AV001_TI_BIL_FOY_TARAFs.ToList();
                }
                lue.Properties.DataSource = _FoyTarafGetir;
                lue.Properties.DisplayMember = "AD";
                lue.Properties.ValueMember = "ID";
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.Add(new LookUpColumnInfo("AD", "Foy Taraf", 40));
            }
        }

        public static List<AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF> FoyTarafGetirByIcra(int IcraFoyId)
        {
            if (_FoyTarafGetir != null)
            {
                return _FoyTarafGetir.FindAll(item => item.ICRA_FOY_ID == IcraFoyId);
            }
            return context.per_AV001_TI_BIL_FOY_TARAFs.Where(item => item.ICRA_FOY_ID == IcraFoyId).ToList();
        }

        //public static VList<VDI_KOD_BANKA_SUBE> _BankaSubeGetir;
        public static void FoyYeriGetir(RepositoryItemLookUpEdit lue)
        {
            FoyYeriGetir_Enter(lue, EventArgs.Empty);
        }

        public static void FoyYeriGetir(LookUpEdit lue)
        {
            FoyYeriGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void FoyYeriGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_FoyYeriGetir == null)
                    _FoyYeriGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_FOY_YERIProvider.GetAll();

                lue.DataSource = _FoyYeriGetir;
                lue.DisplayMember = "FOY_YERI";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("FOY_YERI", 10, "Föy Yeri"));
            }
        }

        public static void FoyYeriGetirByFoyBirimId(RepositoryItemLookUpEdit lue, int FoyBirimId)
        {
            if (_FoyYeriGetir != null)
                lue.DataSource = _FoyYeriGetir.Where(item => item.FOY_BIRIM_ID == FoyBirimId).OrderByDescending(item => item.FOY_YERI);
            else
                lue.DataSource = AvukatProLib2.Data.DataRepository.per_TDI_KOD_FOY_YERIProvider.Get(" FOY_BIRIM_ID=" + FoyBirimId, "FOY_YERI DESC");

            lue.NullText = "Seç";
            lue.DisplayMember = "FOY_YERI";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("FOY_YERI", "Föy Yeri", 40));
        }

        public static void FoyYeriGetirByFoyBirimId(LookUpEdit lue, int FoyBirimId)
        {
            if (_FoyYeriGetir != null)
                lue.Properties.DataSource = _FoyYeriGetir.Where(item => item.FOY_BIRIM_ID == FoyBirimId).OrderByDescending(item => item.FOY_YERI);
            else
                lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.per_TDI_KOD_FOY_YERIProvider.Get(" FOY_BIRIM_ID=" + FoyBirimId, "FOY_YERI DESC");

            lue.Properties.ValueMember = "ID";
            lue.Properties.DisplayMember = "FOY_YERI";
            lue.Properties.NullText = "Seç";
            LookUpColumnInfo c = new LookUpColumnInfo("ID", 2, "id");
            c.Visible = false;
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { c, new LookUpColumnInfo("FOY_YERI", 20, "Föy Yeri") });
        }

        public static void FoyYeriGetirByFoyBirimID(LookUpEdit lue, int FoyBirimID)
        {
            lue.Properties.BeginUpdate();
            lue.Properties.DisplayMember = "FOY_YERI";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("FOY_YERI", 30, "Föy Yeri"));
            lue.Properties.DataSource = DataRepository.per_TDI_KOD_FOY_YERIProvider.Get("FOY_BIRIM_ID=" + FoyBirimID, "FOY_YERI DESC");
            lue.Properties.EndUpdate();
        }

        public static TList<AV001_TI_BIL_GAYRIMENKUL> GayrimenkulGetir()
        {
            if (_GayrimenkulGetir == null)
                _GayrimenkulGetir = DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.GetAll();
            return _GayrimenkulGetir;
        }

        public static void GayriMenkulTarafSifatGetir(RepositoryItemLookUpEdit rLue)
        {
            GayriMenkulTarafSifatGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void GayriMenkulTarafSifatGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_GayriMenkulTarafSifatGetir == null)
                {
                    _GayriMenkulTarafSifatGetir = DataRepository.per_TI_KOD_GAYRIMENKUL_TARAF_SIFATProvider.GetAll();
                }
                rLue.DataSource = _GayriMenkulTarafSifatGetir;
                rLue.DisplayMember = "TARAF_SIFAT";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("TARAF_SIFAT", "Taraf Sýfat", 100));
            }
        }

        public static void GelismeAdimGetir(RepositoryItemLookUpEdit rLue)
        {
            GelismeAdimGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void GelismeAdimGetir(LookUpEdit lue)
        {
            GelismeAdimGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void GelismeAdimGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            _GelismeAdimGetir = DataRepository.per_TD_KOD_FOY_GELISME_ADIMProvider.GetAll();
            lue.DataSource = _GelismeAdimGetir;
            lue.NullText = "Seç";
            lue.DisplayMember = "GELISME_ADIM";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("GELISME_ADIM", "Geliþme Adým", 40));
        }

        public static void GelismeAdimGetirIcra(RepositoryItemLookUpEdit rLue)
        {
            GelismeAdimGetirIcra_Enter(rLue, EventArgs.Empty);
        }

        public static void GelismeAdimGetirIcra(LookUpEdit lue)
        {
            GelismeAdimGetirIcra_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void GelismeAdimGetirIcra_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_GelismeAdimGetirIcra == null)
                {
                    //_GelismeAdimGetir = DataRepository.per_TD_KOD_FOY_GELISME_ADIMProvider.GetAll();
                    _GelismeAdimGetirIcra = DataRepository.TI_KOD_FOY_GELISME_ADIMProvider.GetAll();
                }
                lue.DataSource = _GelismeAdimGetirIcra;
                lue.NullText = "Seç";
                lue.DisplayMember = "GELISME_ADIM";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("GELISME_ADIM", "Geliþme Adým", 40));
            }
        }

        public static void GelismeKaynakTipGetirForDava(RepositoryItemLookUpEdit lue)
        {
            GelismeKaynakTipGetirForDava_Enter(lue, EventArgs.Empty);
        }

        public static void GelismeKaynakTipGetirForDava_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("GelismeKaynakTipDava");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.DavaGelismeKaynakTip tipi in Enum.GetValues(typeof(AvukatProLib.Extras.DavaGelismeKaynakTip)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Kaynak Tipi"));
            }
        }

        public static void GelismeKaynakTipGetirForIcra(RepositoryItemLookUpEdit lue)
        {
            GelismeKaynakTipGetirForIcra_Enter(lue, EventArgs.Empty);
        }

        public static void GelismeKaynakTipGetirForIcra_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("GelismeKaynakTip");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.IcraGelismeKaynakTip tipi in Enum.GetValues(typeof(AvukatProLib.Extras.IcraGelismeKaynakTip)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Kaynak Tipi"));
            }
        }

        public static TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> GemiUcakAracGetirByDavaFoyId(int davaFoyID)
        {
            //TList<NN_DAVA_GEMI_UCAK_ARAC> davaFoyList = DataRepository.NN_DAVA_GEMI_UCAK_ARACProvider.GetByDAVA_FOY_ID(davaFoyID);
            //List<int> idList = new List<int>();
            //davaFoyList.ForEach(item => idList.Add(item.GEMI_UCAK_ARAC_ID));
            //if (_per_AV001_TDI_BIL_GEMI_UCAK_ARAC != null)
            //    return (from item in _per_AV001_TDI_BIL_GEMI_UCAK_ARAC where idList.Contains(item.ID) select item).ToList();
            //return (from item in context.per_AV001_TDI_BIL_GEMI_UCAK_ARACs where idList.Contains(item.ID) select item).ToList();
            return DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.GetByDAVA_FOY_ID(davaFoyID);
        }

        public static TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> GemiUcakAracGetirByDavaNedenId(int davaNedenID)
        {
            //TList<AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC> davaNedenList = DataRepository.AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARACProvider.GetByDAVA_NEDEN_ID(davaNedenID);
            //List<int> idList = new List<int>();
            //davaNedenList.ForEach(item => idList.Add(item.GEMI_UCAK_ARAC_ID));
            //if (_per_AV001_TDI_BIL_GEMI_UCAK_ARAC != null)
            //    return (from item in _per_AV001_TDI_BIL_GEMI_UCAK_ARAC where idList.Contains(item.ID) select item).ToList();
            //return (from item in context.per_AV001_TDI_BIL_GEMI_UCAK_ARACs where idList.Contains(item.ID) select item).ToList();
            return DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.GetByDAVA_NEDEN_IDFromAV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC(davaNedenID);
        }

        public static TList<NN_DAVA_GEMI_UCAK_ARAC> GemiUcakAracGetirByIdFromNNDava(int id)
        {
            return DataRepository.NN_DAVA_GEMI_UCAK_ARACProvider.GetByGEMI_UCAK_ARAC_ID(id);
        }

        public static TList<NN_ICRA_GEMI_UCAK_ARAC> GemiUcakAracGetirByIdFromNNIcra(int id)
        {
            return DataRepository.NN_ICRA_GEMI_UCAK_ARACProvider.GetByGEMI_UCAK_ARAC_ID(id);
        }

        public static TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> GemiUcakAracGetirBySikayetNedenId(int sikayetNedenID)
        {
            //TList<NN_SIKAYET_NEDEN_GEMI_UCAK_ARAC> sikayetNedenList = DataRepository.NN_SIKAYET_NEDEN_GEMI_UCAK_ARACProvider.GetByHAZIRLIK_SIKAYET_NEDEN_ID(sikayetNedenID);
            //List<int> idList = new List<int>();
            //sikayetNedenList.ForEach(item => idList.Add(item.GEMI_UCAK_ARAC_ID));
            //if (_per_AV001_TDI_BIL_GEMI_UCAK_ARAC != null)
            //    return (from item in _per_AV001_TDI_BIL_GEMI_UCAK_ARAC where idList.Contains(item.ID) select item).ToList();
            //return (from item in context.per_AV001_TDI_BIL_GEMI_UCAK_ARACs where idList.Contains(item.ID) select item).ToList();
            return DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.GetByHAZIRLIK_SIKAYET_NEDEN_IDFromNN_SIKAYET_NEDEN_GEMI_UCAK_ARAC(sikayetNedenID);
        }

        public static TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> GemiUcakAracGetirBySozlesmeFoyId(int sozlesmeFoyID)
        {
            //TList<NN_SOZLESME_GEMI_UCAK_ARAC> sozlesmeFoyList = DataRepository.NN_SOZLESME_GEMI_UCAK_ARACProvider.GetBySOZLESME_ID(sozlesmeFoyID);
            //List<int> idList = new List<int>();
            //sozlesmeFoyList.ForEach(item => idList.Add(item.GEMI_UCAK_ARAC_ID));
            //if (_per_AV001_TDI_BIL_GEMI_UCAK_ARAC != null)
            //    return (from item in _per_AV001_TDI_BIL_GEMI_UCAK_ARAC where idList.Contains(item.ID) select item).ToList();
            //return (from item in context.per_AV001_TDI_BIL_GEMI_UCAK_ARACs where idList.Contains(item.ID) select item).ToList();
            return DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.GetBySOZLESME_IDFromNN_SOZLESME_GEMI_UCAK_ARAC(sozlesmeFoyID);
        }

        public static void GemiUcakAraclariGetir(RepositoryItemLookUpEdit rLue)
        {
            if (_per_AV001_TDI_BIL_GEMI_UCAK_ARAC == null)
                _per_AV001_TDI_BIL_GEMI_UCAK_ARAC = context.per_AV001_TDI_BIL_GEMI_UCAK_ARACs.ToList();

            rLue.BeginUpdate();
            rLue.DataSource = _per_AV001_TDI_BIL_GEMI_UCAK_ARAC;
            rLue.DisplayMember = "ADI";
            rLue.ValueMember = "ID";
            rLue.Columns.Clear();
            rLue.Columns.Add(new LookUpColumnInfo("ADI", 20, "Araç Tipi"));
            rLue.EndUpdate();
        }

        public static string GetBuyukHarf(string eski)
        {
            string degisen = string.Empty;

            for (int i = 0; i < eski.Length; i++)
            {
                if (eski[i] == 'i')
                {
                    degisen += 'Ý';
                }
                else if (eski[i] == 'ý')
                {
                    degisen += 'I';
                }
                else
                {
                    degisen += eski[i].ToString().ToUpper().ToCharArray()[0];
                }
            }
            return degisen;
        }

        public static void GetBuyukHarfByRepositoryTextEdit(RepositoryItemTextEdit texEdit)
        {
            texEdit.Validating += SetBuyukHarfRepositoryItemTextEdit_Validating;
        }

        public static void GetCariImages(RepositoryItemImageComboBox combo)
        {
            ImageList lstImg = new ImageList();
            List<DevExpress.XtraEditors.Controls.ImageComboBoxItem> ktg = new List<DevExpress.XtraEditors.Controls.ImageComboBoxItem>();

            Image[] lstKateGoriImages = new Image[]
            {
                AdimAdimDavaKaydi.Properties.Resources.User_cubbeli_22x22,
                AdimAdimDavaKaydi.Properties.Resources.Administrator_3_22x22,
            };
            List<AvukatProLib.Arama.TDI_BIL_KULLANICI_LISTESI> lstKategori = context.TDI_BIL_KULLANICI_LISTESIs.Where(vi => (vi.AV001_TDI_BIL_CARI.PERSONEL_MI == true || vi.AV001_TDI_BIL_CARI.AVUKAT_MI == true) && vi.AV001_TDI_BIL_CARI.KURUM_AVUKATI_MI == false && vi.KULLANICI_AKTIF == true).ToList();

            lstImg.Images.Add(lstKateGoriImages[0]);
            lstImg.Images.Add(lstKateGoriImages[1]);

            foreach (var item in lstKategori)
            {
                if (item.AV001_TDI_BIL_CARI.AVUKAT_MI)
                {
                    ktg.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(item.AV001_TDI_BIL_CARI.AD, item.CARI_ID, 0));
                }
                else if (!item.AV001_TDI_BIL_CARI.AVUKAT_MI)
                {
                    ktg.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(item.AV001_TDI_BIL_CARI.AD, item.CARI_ID, 1));
                }
            }
            combo.Items.AddRange(ktg);
            combo.SmallImages = lstImg;
            combo.LargeImages = lstImg;
            combo.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
        }

        public static void GetIsKosulTip(RepositoryItemLookUpEdit rLue)
        {
            GetIsKosulTip_Enter(rLue, EventArgs.Empty);
        }

        public static void GetIsKosulTip_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_GetIsKosulTip == null)
                    _GetIsKosulTip = AvukatProLib2.Data.DataRepository.per_TDI_KOD_IS_KOSUL_TIPProvider.GetAll();

                rLue.Columns.Clear();
                rLue.DataSource = _GetIsKosulTip;
                rLue.Columns.Add(new LookUpColumnInfo("AD", 100, "Koþul"));
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
            }
        }

        /// <summary>
        /// muhasebe hareket alt kategoriye ait kayýtlarý resimli olarak geitrir
        /// </summary>
        /// <returns></returns>
        public static List<DevExpress.XtraEditors.Controls.ImageComboBoxItem> GetKategoriImages(ImageList lstImg)
        {
            List<DevExpress.XtraEditors.Controls.ImageComboBoxItem> ktg = new List<DevExpress.XtraEditors.Controls.ImageComboBoxItem>();

            TList<AvukatProLib2.Entities.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> lstKategori = AvukatProLib2.Data.DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(6);//("WHERE ANA_KATEGORI_ID=" + 6, "ALT_KATEGORI DESC");
            for (int i = 0; i < lstKategori.Count; i++)
            {
                if (lstKategori[i].ICON == null)
                {
                    lstImg.Images.Add(new Bitmap(20, 20));
                }
                else
                {
                    MemoryStream ms = new MemoryStream(lstKategori[i].ICON);

                    lstImg.Images.Add(Image.FromStream(ms));

                    //lstImg.Images.Add(Image.FromFile("c:\\aaaa.jpg"));
                }

                ktg.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(lstKategori[i].ALT_KATEGORI, lstKategori[i].ID, i));
            }

            return ktg;
        }

        public static List<DevExpress.XtraEditors.Controls.ImageComboBoxItem> GetMalKategoriImages(ImageList lstImg)
        {
            List<DevExpress.XtraEditors.Controls.ImageComboBoxItem> ktg = new List<DevExpress.XtraEditors.Controls.ImageComboBoxItem>();

            Image[] lstKateGoriImages = new Image[]
            {
                AdimAdimDavaKaydi.Properties.Resources.dosya_ac_40x40,
                AdimAdimDavaKaydi.Properties.Resources.dosya_ac_40x40,
                AdimAdimDavaKaydi.Properties.Resources.dosya_ac_40x40,
                AdimAdimDavaKaydi.Properties.Resources.gayrimenkul_40,
                AdimAdimDavaKaydi.Properties.Resources.maas_40,
                AdimAdimDavaKaydi.Properties.Resources.araba_40,
                AdimAdimDavaKaydi.Properties.Resources.gayrimenkul_40,
                AdimAdimDavaKaydi.Properties.Resources._3kisiden_hak_alacak40,
                AdimAdimDavaKaydi.Properties.Resources.gemi_40,
                AdimAdimDavaKaydi.Properties.Resources.ucak_40,
                AdimAdimDavaKaydi.Properties.Resources.menkul_40
            };

            TList<AvukatProLib2.Entities.TI_KOD_MAL_KATEGORI> lstKategori = AvukatProLib2.Data.DataRepository.TI_KOD_MAL_KATEGORIProvider.GetAll();
            for (int i = 0; i < lstKategori.Count; i++)
            {
                int imgIndex = i;

                if (lstKateGoriImages.Length < i)
                    lstImg.Images.Add(lstKateGoriImages[i]);
                if (imgIndex > (lstKateGoriImages.Length - 1))
                    imgIndex = lstKateGoriImages.Length - 1;

                ktg.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(lstKategori[i].KATEGORI, lstKategori[i].ID, imgIndex));
            }

            return ktg;
        }

        public static void GorusmeYonuGetir(RepositoryItemLookUpEdit lue)
        {
            GorusmeYonuGetir_Enter(lue, EventArgs.Empty);
        }

        public static void GorusmeYonuGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("GorusmeYonu");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.GorusmeYonu tipi in Enum.GetValues(typeof(AvukatProLib.Extras.GorusmeYonu)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Görüþme Yönü"));
            }
        }

        public static void GUATipGetirByGUATipId(RepositoryItemLookUpEdit lue, int guaTipId)
        {
            lue.DataSource =
                AvukatProLib2.Data.DataRepository.per_TDI_KOD_ARAC_TIPProvider.Get(" GEMI_UCAK_ARAC_TIP=" + guaTipId, "TIP DESC");

            //Find("GEMI_UCAK_ARAC_TIP='" + guaTipId + "'");
            lue.ValueMember = "ID";
            lue.DisplayMember = "TIP";
            lue.NullText = "Seç";
            LookUpColumnInfo c = new LookUpColumnInfo("ID", 2, "id");
            c.Visible = false;
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { c, new LookUpColumnInfo("TIP", 20, "Tip") });
        }

        public static void HacizChildGetir(AV001_TI_BIL_FOY foy, RepositoryItemLookUpEdit rLue)
        {
            rLue.DataSource = context.per_HACIZ_CHILD_BY_FOYs.Where(item => item.ICRA_FOY_ID == foy.ID).ToList();
            rLue.ValueMember = "ID";
            rLue.DisplayMember = "TUR";
            rLue.NullText = "Seç";
            rLue.Columns.Add(new LookUpColumnInfo("KATEGORI", "Kategori", 100));
            rLue.Columns.Add(new LookUpColumnInfo("TUR", "Tür", 100));
            rLue.Columns.Add(new LookUpColumnInfo("CINS", "Cins", 100));
        }

        public static TList<AV001_TI_BIL_HACIZ_CHILD> HacizChildGetir()
        {
            if (_HacizChildGetir == null)
                _HacizChildGetir = DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.GetAll();
            return _HacizChildGetir;
        }

        public static void HacizChildTipGetir(RepositoryItemLookUpEdit lue)
        {
            HacizChildTipGetir_Enter(lue, EventArgs.Empty);
        }

        public static void HacizChildTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("HacizChildTip");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (HAZIZ_CHILD_TIP tipi in Enum.GetValues(typeof(HAZIZ_CHILD_TIP)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Haciz Tipi"));
            }
        }

        public static void HacizIslemDurumGetir(RepositoryItemLookUpEdit rLue)
        {
            HacizIslemDurumgetir_Enter(rLue, EventArgs.Empty);
        }

        public static void HacizIslemDurumGetir(LookUpEdit lue)
        {
            HacizIslemDurumgetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void HacizIslemDurumgetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_HacizIslemDurumGetir == null)
                {
                    _HacizIslemDurumGetir = AvukatProLib2.Data.DataRepository.per_TI_KOD_HACIZ_ISLEM_DURUMProvider.GetAll();
                }
                rLue.DataSource = _HacizIslemDurumGetir;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "ISLEM_DURUM";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("ISLEM_DURUM", "Haciz Ýþlem Durum", 100));
            }
        }

        /// <summary>
        /// TDI_KOD_REHIN_HARC_ISTISNA
        /// </summary>
        /// <param name="rLue"></param>
        public static void HarcIstisnaGetir(RepositoryItemLookUpEdit rLue)
        {
            HarcIstisnaGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void HarcIstisnaGetir(LookUpEdit lue)
        {
            HarcIstisnaGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void HarcIstisnaGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_HarcIstisnaGetir == null)
                {
                    _HarcIstisnaGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_REHIN_HARC_ISTISNAProvider.GetAll();
                }
                lue.DataSource = _HarcIstisnaGetir;
                lue.DisplayMember = "HARC_ISTISNA";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("HARC_ISTISNA", "Harç Ýstisna", 40));
            }
        }

        public static void HareketAnaKategoriGetir(RepositoryItemLookUpEdit lue)
        {
            //ToDo : view yapýlacak
            HareketAnaKategoriGetir_Enter(lue, EventArgs.Empty);
        }

        //TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI
        public static void HareketAnaKategoriGetir(LookUpEdit lue)
        {
            HareketAnaKategoriGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void HareketAnaKategoriGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_HareketAnaKategoriGetir == null)
                {
                    _HareketAnaKategoriGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORIProvider.GetAll();
                }

                lue.DataSource = _HareketAnaKategoriGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "ANA_KATEGORI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ANA_KATEGORI", "Kategori", 100));
            }
        }

        public static void HatirlatmaPriyotGetir(RepositoryItemLookUpEdit lue)
        {
            HatirlatmaPriyotGetir_Enter(lue, EventArgs.Empty);
        }

        public static void HatirlatmaPriyotGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_HatirlatmaPeriyodGetir == null)
                {
                    _HatirlatmaPeriyodGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_HATIRLATMA_PERIYODProvider.GetAll();
                }
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("PERIYOD", 20, "Periyot") });
                lue.DataSource = _HatirlatmaPeriyodGetir;
                lue.DisplayMember = "PERIYOD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static List<AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_NEW> HazirlikDosyalariGetir()
        {
            if (_per_AV001_TD_BIL_HAZIRLIK == null)
                _per_AV001_TD_BIL_HAZIRLIK = context.per_AV001_TD_BIL_HAZIRLIK_NEWs.ToList();
            return _per_AV001_TD_BIL_HAZIRLIK;
        }

        public static List<AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_NEW> HazirlikDosyalariGetirBySube(int subeKodId)
        {
            if (_per_AV001_TD_BIL_HAZIRLIK != null)
                return _per_AV001_TD_BIL_HAZIRLIK.FindAll(item => item.SUBE_KOD_ID == subeKodId);
            return context.per_AV001_TD_BIL_HAZIRLIK_NEWs.Where(item => item.SUBE_KOD_ID == subeKodId).ToList();
        }

        public static void HazirlikDurumGetir(RepositoryItemLookUpEdit lue)
        {
            HazirlikDurumGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TD_KOD_HAZIRLIK_DURUM
        /// </summary>
        /// <param name="lue"></param
        public static void HazirlikDurumGetir(LookUpEdit lue)
        {
            HazirlikDurumGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void HazirlikDurumGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_HazirlikDurumGetir == null)
                {
                    _HazirlikDurumGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_HAZIRLIK_DURUMProvider.GetAll();
                }
                lue.DataSource = _HazirlikDurumGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "DURUM";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("DURUM", "Hazirlik Durum", 100));
            }
        }

        public static void HazirlikFoyNumarasiGetir(RepositoryItemLookUpEdit rLue)
        {
            HazirlikFoyNumarasiGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void HazirlikFoyNumarasiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                rLue.DisplayMember = "HAZIRLIK_NO";
                rLue.ValueMember = "ID";

                #region SUBEKONTROLLU VERI CEKME

                List<AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_NEW> hazirlikFoyList = BelgeUtil.Inits.HazirlikDosyalariGetir();

                if (AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null)
                    if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                        rLue.DataSource = hazirlikFoyList;
                    else
                        rLue.DataSource = hazirlikFoyList.FindAll(vi => vi.SUBE_KOD_ID == AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID);

                #endregion SUBEKONTROLLU VERI CEKME

                rLue.Columns.Clear();
                rLue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HAZIRLIK_NO"));
                rLue.NullText = "Hazýrlýk No Seç";
            }
        }

        public static void HazirlikHikayeSurecGetir(RepositoryItemLookUpEdit rLue)
        {
            HazirlikHikayeSurecGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void HazirlikHikayeSurecGetir(LookUpEdit lue)
        {
            HazirlikHikayeSurecGetir_Enter(lue, EventArgs.Empty);
        }

        public static void HazirlikHikayeSurecGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_HazirlikHikayeSurecGetir == null)
                {
                    _HazirlikHikayeSurecGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_HAZIRLIK_HIKAYE_SURECProvider.GetAll();
                }
                lue.DataSource = _HazirlikSurecSonucGetir;
                lue.DisplayMember = "HIKAYE_SUREC";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("HIKAYE_SUREC", "Hikaye Süreç", 40));
            }
        }

        public static void HazirlikSikayetNedenGetir(RepositoryItemLookUpEdit rLue)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Þikayet Nedeni");

            if (_HazirlikSikayetNedenGetir == null)
            {
                _HazirlikSikayetNedenGetir = AvukatProLib2.Data.DataRepository.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENProvider.GetAll();
            }
            foreach (AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN item in _HazirlikSikayetNedenGetir)
            {
                DataRepository.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_DAVA_ADI));
                if (item.SIKAYET_NEDEN_KOD_ID != null)
                    dt.Rows.Add(item.ID, item.SIKAYET_NEDEN_KOD_IDSource.DAVA_ADI.ToString());
            }
            rLue.DataSource = dt;
            rLue.NullText = "Seç";
            rLue.DisplayMember = "Þikayet Nedeni";
            rLue.ValueMember = "ID";
            rLue.Columns.Clear();
            rLue.Columns.Add(new LookUpColumnInfo("Þikayet Nedeni", "Þikayet Neden", 100));
        }

        public static void HazirlikSikayetNedenGetir(LookUpEdit lue)
        {
            lue.Properties.NullText = "Seç";
            HazirlikSikayetNedenGetir_Enter(lue, EventArgs.Empty);
        }

        public static void HazirlikSikayetNedenGetir_Enter(object sender, EventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            if (lue.Properties.DataSource == null)
            {
                if (_HazirlikSikayetNedenGetir == null)
                {
                    _HazirlikSikayetNedenGetir = AvukatProLib2.Data.DataRepository.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENProvider.GetAll();
                }
                lue.Properties.DataSource = _HazirlikSikayetNedenGetir;
                lue.Properties.DisplayMember = "SIKAYET_NEDEN_KOD";
                lue.Properties.ValueMember = "ID";

                lue.Properties.Columns.Clear();
                lue.Properties.Columns.Add(new LookUpColumnInfo("SIKAYET_NEDEN_KOD", "Þikayet Neden", 40));
            }
        }

        public static void HazirlikSurecGetir(RepositoryItemLookUpEdit rLue)
        {
            HazirlikSurecGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void HazirlikSurecGetir(LookUpEdit lue)
        {
            HazirlikSurecGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void HazirlikSurecGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_HazirlikSurecGetir == null)
                {
                    _HazirlikSurecGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_HAZIRLIK_SUREC_TIPProvider.GetAll();
                }
                lue.DataSource = _HazirlikSurecGetir;
                lue.DisplayMember = "SUREC_TIP";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("SUREC_TIP", "Süreç Tip", 40));
            }
        }

        public static void HazirlikSurecSonucGetir(RepositoryItemLookUpEdit rLue)
        {
            HazirlikSurecSonucGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void HazirlikSurecSonucGetir(LookUpEdit lue)
        {
            HazirlikSurecSonucGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void HazirlikSurecSonucGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_HazirlikSurecSonucGetir == null)
                {
                    _HazirlikSurecSonucGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_HAZIRLIK_SUREC_SONUCProvider.GetAll();
                }
                lue.DataSource = _HazirlikSurecSonucGetir;
                lue.DisplayMember = "SONUC";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("SONUC", "Süreç Sonuç", 40));
            }
        }

        public static void HikayeSurecGetir(RepositoryItemLookUpEdit rLue)
        {
            HikayeSurecGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void HikayeSurecGetir(LookUpEdit lue)
        {
            HikayeSurecGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void HikayeSurecGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_HikayeSurecGetir == null)
                {
                    _HikayeSurecGetir = AvukatProLib2.Data.DataRepository.TD_KOD_FOY_HIKAYE_SURECProvider.GetAll();
                }
                lue.DataSource = _HikayeSurecGetir;
                lue.DisplayMember = "HIKAYE_SUREC";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("HIKAYE_SUREC", "Hikaye Süreç", 40));
            }
        }

        public static void HikayeSurecGetirIcra(RepositoryItemLookUpEdit rLue)
        {
            HikayeSurecGetirIcra_Enter(rLue, EventArgs.Empty);
        }

        public static void HikayeSurecGetirIcra_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_HikayeSurecGetirIcra == null)
                {
                    _HikayeSurecGetirIcra = AvukatProLib2.Data.DataRepository.TI_KOD_FOY_HIKAYE_SURECProvider.GetAll();
                }
                rLue.DataSource = _HikayeSurecGetirIcra;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "HIKAYE_SUREC";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("HIKAYE_SUREC", "Hikaye Süreç", 100));
            }
        }

        public static void HikayeSurecGetirSorusturma(RepositoryItemLookUpEdit rLue)
        {
            HikayeSurecGetirSorusturma_Enter(rLue, EventArgs.Empty);
        }

        public static void HikayeSurecGetirSorusturma_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_HikayeSurecGetirSorusturma == null)
                {
                    _HikayeSurecGetirSorusturma = AvukatProLib2.Data.DataRepository.TD_KOD_HAZIRLIK_HIKAYE_SURECProvider.GetAll();
                }
                rLue.DataSource = _HikayeSurecGetirSorusturma;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "HIKAYE_SUREC";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("HIKAYE_SUREC", "Hikaye Süreç", 100));
            }
        }

        /// <summary>
        /// TDI_KOD_RUCU_IBRANAME_DURUM
        /// </summary>
        /// <param name="lue"></param
        public static void IbranameDurumGetir(LookUpEdit lue)
        {
            IbranameDurumGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void IbranameDurumGetir(RepositoryItemLookUpEdit rLue)
        {
            IbranameDurumGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void IbranameDurumGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_IbranameDurumGetir == null)
                {
                    _IbranameDurumGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_RUCU_IBRANAME_DURUMProvider.GetAll();
                }
                lue.DataSource = _IbranameDurumGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "IBRANAME_DURUM";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("IBRANAME_DURUM", "Ibraname Durum", 100));
            }
        }

        //aykut hýzlandýrma 11.02.2013
        public static DataTable IcraDosyalariGetir()
        {
            //if (_IcraDosyalarArama == null)
            //    _IcraDosyalarArama = context.per_AV001_TI_BIL_ICRA_Aramas.ToList();

            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            _IcraDosyalarArama = cn.GetDataTable("select * from per_AV001_TI_BIL_ICRA_Arama");

            return _IcraDosyalarArama;
        }

        //aykut hýzlandýrma 11.02.2013
        //public static List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> IcraDosyalariGetirAramaBySube(int subeKodId)
        //{
        //    if (_IcraDosyalarArama != null)
        //        return _IcraDosyalarArama.FindAll(item => item.SUBE_KOD_ID == subeKodId);
        //    return context.per_AV001_TI_BIL_ICRA_Aramas.Where(item => item.SUBE_KOD_ID == subeKodId).ToList();
        //}
        //public static List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> IcraDosyalariGetirBySube(int subeKodId)
        //{
        //    if (_IcraDosyalarArama != null)
        //        return _IcraDosyalarArama.FindAll(item => item.SUBE_KOD_ID == subeKodId);
        //    return context.per_AV001_TI_BIL_ICRA_Aramas.Where(item => item.SUBE_KOD_ID == subeKodId).ToList();
        //}

        public static DataTable IcraDosyalariGetirAramaBySube(int subeKodId)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

            return cn.GetDataTable("select * from per_AV001_TI_BIL_ICRA_Arama where SUBE_KOD_ID=" + subeKodId);
        }

        public static DataTable IcraDosyalariGetirByID(int ID)
        {
            //if (_IcraDosyalarArama == null)
            //    _IcraDosyalarArama = context.per_AV001_TI_BIL_ICRA_Aramas.ToList();

            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            _IcraDosyalarArama = cn.GetDataTable("select * from per_AV001_TI_BIL_ICRA_Arama where ID=" + ID);

            return _IcraDosyalarArama;
        }

        public static DataTable IcraDosyalariGetirBySube(int subeKodId)
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

            return cn.GetDataTable("select * from per_AV001_TI_BIL_ICRA_Arama where SUBE_KOD_ID=" + subeKodId);
        }

        /// <summary>
        /// ÝcraDovizIslemTipi
        /// </summary>
        /// <param name="lue"></param>
        public static void IcraDovizIslemTipiGetir(RepositoryItemLookUpEdit lue)
        {
            IcraDovizIslemTipiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void IcraDovizIslemTipiGetir(LookUpEdit lue)
        {
            IcraDovizIslemTipiGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void IcraDovizIslemTipiGetir(ComboBoxEdit cmb)
        {
            foreach (AvukatProLib.Extras.IcraDovizIslemTipi tipi in Enum.GetValues(typeof(AvukatProLib.Extras.IcraDovizIslemTipi)))
            {
                cmb.Properties.Items.Add(tipi.ToString().Replace("_", " "));
            }
        }

        public static void IcraDovizIslemTipiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("DovizIslemTipi");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.IcraDovizIslemTipi tipi in Enum.GetValues(typeof(AvukatProLib.Extras.IcraDovizIslemTipi)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Döviz Ýþlem Tipi"));
            }
        }

        public static void IcraErtelemeNedenGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_IcraErtelemeNeden == null)
                {
                    _IcraErtelemeNeden = AvukatProLib2.Data.DataRepository.per_TI_KOD_ERTELEME_NEDENProvider.GetAll();
                }
                rLue.DataSource = _IcraErtelemeNeden;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "ERTELEME_NEDEN";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("ERTELEME_NEDEN", "Icra Ertelenme Neden", 100));
            }
        }

        public static void IcraErtelenmeNedenGetir(RepositoryItemLookUpEdit rLue)
        {
            IcraErtelemeNedenGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void IcraErtelenmeNedenGetir(LookUpEdit lue)
        {
            IcraErtelemeNedenGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void IcraFoyNumarasiGetir(RepositoryItemLookUpEdit rLue)
        {
            IcraFoyNumarasiGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void IcraFoyNumarasiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                rLue.DisplayMember = "FOY_NO";
                rLue.ValueMember = "ID";

                #region SUBEKONTROLLU VERI CEKME

                //aykut hýzlandýrma 11.02.2013
                //List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> icraFoyList = BelgeUtil.Inits.IcraDosyalariGetir();
                DataTable icraFoyList = BelgeUtil.Inits.IcraDosyalariGetir();

                if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                    rLue.DataSource = icraFoyList;
                else
                    rLue.DataSource = IcraDosyalariGetirBySube(AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID);

                #endregion SUBEKONTROLLU VERI CEKME

                rLue.Columns.Clear();
                rLue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FOY_NO"));
                rLue.NullText = "Foy No Seç";
            }
        }

        public static void IcraHarcTipiGetir(RepositoryItemLookUpEdit rLue)
        {
            if (_IcraHarcTipi == null)
            {
                _IcraHarcTipi = AvukatProLib2.Data.DataRepository.per_TI_KOD_HARC_NISPIProvider.GetAll();
            }
            rLue.DataSource = _IcraHarcTipi;
            rLue.NullText = "Seç";
            rLue.DisplayMember = "HARC_ADI";
            rLue.ValueMember = "ID";
            rLue.Columns.Clear();
            rLue.Columns.Add(new LookUpColumnInfo("HARC_ADI", "Nispi Harç Adý", 100));
        }

        public static List<AvukatProLib.Arama.per_AV001_TI_BIL_FOY_HesapAlanlari> IcraHesapAlanlariGetirByFoyId(int foyId)
        {
            return context.per_AV001_TI_BIL_FOY_HesapAlanlaris.Where(item => item.ID == foyId).ToList();
        }

        public static void IcraItirazSonucGetir(LookUpEdit lue)
        {
            //TODO: getAll()[0] idi [0] ý sildim ..
            IcraItirazSonucGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void IcraItirazSonucGetir(RepositoryItemLookUpEdit lue)
        {
            IcraItirazSonucGetir_Enter(lue, EventArgs.Empty);
        }

        public static void IcraItirazSonucGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_IcraItirazSonucGetir_Enter == null)
                {
                    _IcraItirazSonucGetir_Enter = AvukatProLib2.Data.DataRepository.per_TI_KOD_ITIRAZ_SONUCProvider.GetAll();
                }
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ITIRAZ_SONUC", 40, "Ýtiraz Sonuç"));
                lue.DataSource = _IcraItirazSonucGetir_Enter;
                lue.ValueMember = "ID";
                lue.DisplayMember = "ITIRAZ_SONUC";
                lue.NullText = "Seç";
            }
        }

        public static void IcraNispiHarcKodGetir(RepositoryItemLookUpEdit rLue)
        {
            IcraNispiHarcKodGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void IcraNispiHarcKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_NispiHarcKodGetir == null)
                {
                    _NispiHarcKodGetir = context.per_TI_CET_NISPI_HARCs.ToList();
                }
                rLue.DataSource = _NispiHarcKodGetir;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "HARC_ADI";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("HARC_ADI", "Nispi Harç Adý", 100));
            }
        }

        public static void IcraSorumluAvukatGetir(LookUpEdit lue, int icraID)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.DataSource = context.per_IcraSorumluAvukats.Where(vi => vi.ICRA_FOY_ID == icraID).ToList();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("AD", 0, "Avukat") });
            lue.Properties.DisplayMember = "AD";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
        }

        public static VList<VI_BIL_ICRA_TARAF_GELISMELERI> IcraTarafGelismeleriGetir()
        {
            if (_IcraTarafGelismeleriGetir == null)
                _IcraTarafGelismeleriGetir = DataRepository.VI_BIL_ICRA_TARAF_GELISMELERIProvider.GetAll();
            return _IcraTarafGelismeleriGetir;
        }

        public static void IlamKararGetir(RepositoryItemLookUpEdit lue)
        {
            IlamKararGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// AV001_TI_BIL_ILAM_MAHKEMESI
        /// </summary>
        /// <param name="lue"></param
        public static void IlamKararGetir(LookUpEdit lue)
        {
            IlamKararGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void IlamKararGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_IlamKararGetir == null)
                {
                    _IlamKararGetir = context.per_AV001_TI_BIL_ILAM_MAHKEMESIs.ToList();
                }
                lue.DataSource = _IlamKararGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "KARAR_NO";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("KARAR_NO", "Karar No", 100));
            }
        }

        public static void IlamTipiGetir(RepositoryItemLookUpEdit lue)
        {
            IlamTipiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void IlamTipiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_IlamTipiGetir == null)
                    _IlamTipiGetir = AvukatProLib2.Data.DataRepository.TDI_KOD_ILAM_BELGE_TURProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_ILAM_BELGE_TUR.TDI_KOD_ILAM_BELGE_TURGetir();

                lue.DataSource = _IlamTipiGetir;
                lue.ValueMember = "ID";
                lue.DisplayMember = "BELGE_TUR";
                lue.NullText = " Seç";
                LookUpColumnInfo c = new LookUpColumnInfo("ID", 2, "id");
                c.Visible = false;
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { c, new LookUpColumnInfo("BELGE_TUR", 20, "Ýlam Tipi") });
            }
        }

        public static void IlceGetirIleGore(RepositoryItemLookUpEdit lue, int ilId)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ILCE", 10, "Ýlçe") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ILCEProvider.GetByIL_ID(ilId);//AvukatProLib.Facade.TDI_KOD_ILCE.TDI_KOD_ILCEIlineGoreGetir(ilId);
            lue.DisplayMember = "ILCE";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        public static void IlceGetirIleGore(LookUpEdit lue, int ilId)
        {
            lue.Properties.NullText = "Seç";
            IlceGetirIleGore_Enter(lue, EventArgs.Empty);
            lue.Tag = ilId;
        }

        public static void IlceGetirIleGore_Enter(object sender, EventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            if (lue.Properties.DataSource == null)
            {
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ILCE", 10, "Ýlçe") });
                int ilID = Convert.ToInt32(lue.Tag);
                lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ILCEProvider.GetByIL_ID(ilID);
                lue.Properties.DisplayMember = "ILCE";
                lue.Properties.ValueMember = "ID";
            }
        }

        public static void IlceGetirOzetli(LookUpEdit lue)
        {
            IlceGetirOzetli_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void IlceGetirOzetli(RepositoryItemLookUpEdit lue)
        {
            IlceGetirOzetli_Enter(lue, EventArgs.Empty);
        }

        public static void IlceGetirOzetli_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_IlceGetirOzetli_Enter == null)
                {
                    if (CodeInfo<per_TDI_KOD_ILCE>.ListeVarmi(typeof(per_TDI_KOD_ILCE)))
                        _IlceGetirOzetli_Enter = CodeInfo<per_TDI_KOD_ILCE>.ListeGetir(typeof(AvukatProLib2.Entities.per_TDI_KOD_ILCE)) as VList<per_TDI_KOD_ILCE>;
                    else
                    {
                        _IlceGetirOzetli_Enter = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ILCEProvider.GetAll();
                        CodeInfo<per_TDI_KOD_ILCE>.ListeKaydet(_IlceGetirOzetli_Enter, typeof(AvukatProLib2.Entities.per_TDI_KOD_ILCE));
                    }
                }
                lue.Columns.Clear();
                lue.NullText = "Seç";
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("IL", 20, "Ýl"), new LookUpColumnInfo("ILCE", 20, "Ýlçe") });
                lue.DataSource = _IlceGetirOzetli_Enter;
                lue.DisplayMember = "ILCE";
                lue.ValueMember = "ID";
            }
        }

        public static void IlceGetirTumu(LookUpEdit lue)
        {
            IlceGetirTumu_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void IlceGetirTumu(RepositoryItemLookUpEdit lue)
        {
            IlceGetirTumu_Enter(lue, EventArgs.Empty);
        }

        public static void IlceGetirTumu_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_IlceGetirTumu_Enter == null)
                {
                    _IlceGetirTumu_Enter = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ILCEProvider.GetAll();
                }
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ILCE", 10, "Ýlçe") });
                lue.DataSource = _IlceGetirTumu_Enter;
                lue.DisplayMember = "ILCE";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        /// <summary>
        /// TDI_KOD_ILETISIM_ALT_KATEGORI
        /// </summary>
        /// <param name="lue"></param>
        public static void IletisimaltKategoriGetir(RepositoryItemLookUpEdit lue)
        {
            IletisimaltKategoriGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_ILETISIM_ALT_KATEGORI
        /// </summary>
        /// <param name="lue"></param
        public static void IletisimaltKategoriGetir(LookUpEdit lue)
        {
            IletisimaltKategoriGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void IletisimaltKategoriGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_IletisimaltKategoriGetir == null)
                {
                    _IletisimaltKategoriGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ILETISIM_ALT_KATEGORIProvider.GetAll();
                }
                lue.DataSource = _IletisimaltKategoriGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "ALT_KATEGORI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ALT_KATEGORI", "Iletiþim Alt Kategori", 100));
            }
        }

        /// <summary>
        /// TDI_KOD_ILETISIM_ANA_KATEGORI
        /// </summary>
        /// <param name="lue"></param>
        public static void IletisimAnaKategoriGetir(RepositoryItemLookUpEdit lue)
        {
            IletisimAnaKategoriGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_ILETISIM_ANA_KATEGORI
        /// </summary>
        /// <param name="lue"></param
        public static void IletisimAnaKategoriGetir(LookUpEdit lue)
        {
            IletisimAnaKategoriGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void IletisimAnaKategoriGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_IletisimAnaKategoriGetir == null)
                {
                    _IletisimAnaKategoriGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ILETISIM_ANA_KATEGORIProvider.GetAll();
                }
                lue.DataSource = _IletisimAnaKategoriGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "ANA_KATEGORI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ANA_KATEGORI", "Iletiþim Ana Kategori", 100));
            }
        }

        public static List<AvukatProLib.Arama.per_TDI_BIL_ILETISIM> IletisimBilgileriGetir()
        {
            if (_IletisimBilgileri == null)
                _IletisimBilgileri = context.per_TDI_BIL_ILETISIMs.ToList();
            return _IletisimBilgileri;
        }

        public static void IlGetir(LookUpEdit lue)
        {
            IlGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void IlGetir(RepositoryItemLookUpEdit lue)
        {
            IlGetir_Enter(lue, EventArgs.Empty);
        }

        public static void IlGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_IlGetir_Enter == null)
                {
                    if (CodeInfo<per_TDI_KOD_IL>.ListeVarmi(typeof(per_TDI_KOD_IL)))
                        _IlGetir_Enter = CodeInfo<per_TDI_KOD_IL>.ListeGetir(typeof(AvukatProLib2.Entities.per_TDI_KOD_IL)) as VList<per_TDI_KOD_IL>;
                    else
                    {
                        _IlGetir_Enter = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ILProvider.GetAll();
                        CodeInfo<per_TDI_KOD_IL>.ListeKaydet(_IlGetir_Enter, typeof(per_TDI_KOD_IL));
                    }
                }
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("IL", 20, "Ýl") });
                lue.DataSource = _IlGetir_Enter;
                lue.DisplayMember = "IL";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void IlGetirUlkeyeGore(LookUpEdit lue, int ulkeId)
        {
            lue.Properties.NullText = "Seç";
            IlGetirUlkeyeGore_Enter(lue, EventArgs.Empty);
            lue.Tag = ulkeId;
        }

        public static void IlGetirUlkeyeGore(RepositoryItemLookUpEdit lue, int ulkeId)
        {
            if (_IlGetirUlkeyeGore == null)
            {
                _IlGetirUlkeyeGore = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ILProvider.GetAll();
                _IlGetirUlkeyeGore.Filter = "ULKE_ID = " + ulkeId;
            }
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("IL", 10, "Ýl") });
            lue.DataSource = _IlGetirUlkeyeGore;

            lue.DisplayMember = "IL";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        public static void IlGetirUlkeyeGore_Enter(object sender, EventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            if (lue.Properties.DataSource == null)
            {
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("IL", 10, "Ýl") });
                int ulkeID = Convert.ToInt32(lue.Tag);

                //TODO: per_TDI_KOD_ILProvider.GetByULKE_ID(ulkeID); method yapýlacak.
                lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ILProvider.GetByULKE_ID(ulkeID); //AvukatProLib.Facade.TDI_KOD_IL.UlkeyeGoreIlGetir(ulkeId);
                lue.Properties.DisplayMember = "IL";
                lue.Properties.ValueMember = "ID";
            }
        }

        public static void ImtiyazliAlacakGetir(RepositoryItemLookUpEdit lue)
        {
            ImtiyazliAlacakGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TI_KOD_IMTIYAZLI_ALACAK
        /// </summary>
        /// <param name="lue"></param
        public static void ImtiyazliAlacakGetir(LookUpEdit lue)
        {
            ImtiyazliAlacakGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void ImtiyazliAlacakGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_ImtiyazliAlacakGetir == null)
                {
                    _ImtiyazliAlacakGetir = AvukatProLib2.Data.DataRepository.per_TI_KOD_IMTIYAZLI_ALACAKProvider.GetAll();
                }
                lue.DataSource = _ImtiyazliAlacakGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "TUR";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("TUR", "Imtiyazli Alacak", 100));
            }
        }

        /// <summary>
        /// TDI_KOD_INCELEME_TUR
        /// </summary>
        /// <param name="lue"></param>
        public static void IncelemeTurGetir(RepositoryItemLookUpEdit lue)
        {
            IncelemeTurGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_INCELEME_TUR
        /// </summary>
        /// <param name="lue"></param
        public static void IncelemeTurGetir(LookUpEdit lue)
        {
            IncelemeTurGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void IncelemeTurGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_IncelemeTurGetir == null)
                {
                    _IncelemeTurGetir = AvukatProLib2.Data.DataRepository.PER_TDI_KOD_INCELEME_TURProvider.GetAll();
                }
                lue.NullText = "Seç";
                lue.DataSource = _IncelemeTurGetir;
                lue.DisplayMember = "TURU";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("TURU", "Inceleme Türü", 100));
            }
        }

        public static void IsDurumGetir(RepositoryItemLookUpEdit rLue)
        {
            IsDurumGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void IsDurumGetir(LookUpEdit lue)
        {
            IsDurumGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void IsDurumGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_IsDurumGetir == null)
                {
                    _IsDurumGetir = DataRepository.per_TDI_KOD_IS_DURUMProvider.GetAll();
                }
                rLue.DataSource = _IsDurumGetir;
                rLue.DisplayMember = "IS_DURUM";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("IS_DURUM", 30, "Durum"));
            }
        }

        public static void IsEtiketGetir(RepositoryItemLookUpEdit rLue)
        {
            IsEtiketGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void IsEtiketGetir(LookUpEdit lue)
        {
            IsEtiketGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void IsEtiketGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_IsEtiketGetir == null)
                {
                    _IsEtiketGetir = DataRepository.per_TDI_KOD_IS_ETIKETProvider.GetAll();
                }
                rLue.DataSource = _IsEtiketGetir;
                rLue.DisplayMember = "IS_ETIKET";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("IS_ETIKET", 30, "Etiket"));
            }
        }

        public static void IsGetir(RepositoryItemLookUpEdit rLue)
        {
            IsGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void IsGetir(LookUpEdit lue)
        {
            IsGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void IsGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_IsGetir == null)
                {
                    _IsGetir = context.per_AV001_TDI_BIL_Is.ToList();
                }
                rLue.DataSource = _IsGetir;
                rLue.DisplayMember = "YAPILACAK_IS";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("YAPILACAK_IS", 30, "Yapýlcak Ýþ"));
            }
        }

        public static TList<AV001_TDI_BIL_IS> IsGetirTable()
        {
            if (_IsGetirTable == null)
                _IsGetirTable = DataRepository.AV001_TDI_BIL_ISProvider.GetAll();
            return _IsGetirTable;
        }

        public static void IsIadeNedeniGetir(LookUpEdit lue)
        {
            IsIadeNedeniGetir_Enter(lue, EventArgs.Empty);
        }

        public static void IsIadeNedeniGetir_Enter(object sender, EventArgs e)
        {
            LookUpEdit lue = (sender as LookUpEdit);
            if (lue.Properties.DataSource == null)
            {
                if (_IsIadeNedeni == null)
                    _IsIadeNedeni = AvukatProLib2.Data.DataRepository.per_TDI_KOD_IS_IADE_NEDENProvider.GetAll();

                lue.Properties.Columns.Clear();
                lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("IS_IADE_NEDEN", 10, "Ýade Nedeni") });
                lue.Properties.DataSource = _IsIadeNedeni;
                lue.Properties.DisplayMember = "IS_IADE_NEDEN";
                lue.Properties.ValueMember = "ID";
                lue.Properties.NullText = "Seç";
            }
        }

        public static void IsKonuKodGetir(LookUpEdit lue)
        {
            lue.Properties.NullText = "Seç";
            IsKonuKodGetir_Enter(lue, EventArgs.Empty);
        }

        public static void IsKonuKodGetir(LookUpEdit lue, int ModulId)
        {
            lue.Properties.NullText = "Seç";
            IsKonuKodGetirByModulID_Enter(lue, EventArgs.Empty);
            lue.Tag = ModulId;
        }

        public static void IsKonuKodGetir_Enter(object sender, EventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            if (lue.Properties.DataSource == null)
            {
                if (_IsKonuKodGetir == null)
                {
                    _IsKonuKodGetir = AvukatProLib2.Data.DataRepository.per_TDIE_KOD_IS_TANIMProvider.GetAll();
                }
                lue.Properties.DataSource = _IsKonuKodGetir;
                lue.Properties.DisplayMember = "KONU";
                lue.Properties.ValueMember = "ID";
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.Add(new LookUpColumnInfo("KONU", "Konu", 70));
            }
        }

        public static void IsKonuKodGetirByModulID_Enter(object sender, EventArgs e)
        {
            if (_IsKonuKodGetir == null)
            {
                _IsKonuKodGetir = AvukatProLib2.Data.DataRepository.per_TDIE_KOD_IS_TANIMProvider.GetAll();
            }
            LookUpEdit lue = (LookUpEdit)sender;
            if (lue.Properties.DataSource == null)
            {
                int ModulID = Convert.ToInt32(lue.Tag);
                lue.Properties.DataSource = _IsKonuKodGetir.Where(item => item.MODUL_ID == ModulID);
                lue.Properties.DisplayMember = "KONU";
                lue.Properties.ValueMember = "ID";
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.Add(new LookUpColumnInfo("KONU", "Konu", 70));
            }
        }

        /// <summary>
        /// TDI_KOD_IS_ONCELIK
        /// </summary>
        /// <param name="lue"></param>
        public static void IsOncelikGetir(RepositoryItemLookUpEdit lue)
        {
            IsOncelikGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_IS_ONCELIK
        /// </summary>
        /// <param name="lue"></param
        public static void IsOncelikGetir(LookUpEdit lue)
        {
            IsOncelikGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void IsOncelikGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_IsOncelikGetir == null)
                {
                    _IsOncelikGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_IS_ONCELIKProvider.GetAll();
                }

                lue.DataSource = _IsOncelikGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "IS_ONCELIK";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("IS_ONCELIK", "Öncelik", 100));
            }
        }

        public static void IsSozlesmeGetir(RepositoryItemLookUpEdit lue)
        {
            //ToDo : view yapýlacak
            IsSozlesmeGetir_Enter(lue, EventArgs.Empty);
        }

        public static void IsSozlesmeGetir(LookUpEdit lue)
        {
            IsSozlesmeGetir_Enter(lue, EventArgs.Empty);
            /* Eski Düzen
            if (lue.Properties.DataSource == null)
            {
                if (_IsSozlesmeGetir == null)
                {
                    _IsSozlesmeGetir = context.AV001_TDI_BIL_IS_SOZLESMEs.Select(vi => new { vi.SOZLESME_KATEGORI_ACIKLAMA,vi.SOZLESME_KATEGORI, vi.ID });
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Sozlesme_Kategori");
                dt.Columns.Add("Aciklama");
                TList<TDI_KOD_SOZLESME_KATEGORILERI> SozlesmeKategori = new TList<TDI_KOD_SOZLESME_KATEGORILERI>();
                foreach (AV001_TDI_BIL_IS_SOZLESME item in _IsSozlesmeGetir)
                {
                    DataRepository.AV001_TDI_BIL_IS_SOZLESMEProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_SOZLESME_KATEGORILERI));
                    if (item.SOZLESME_KATEGORI_ID != null)
                        dt.Rows.Add(item.ID, item.SOZLESME_KATEGORI_IDSource.AD.ToString(), item.SOZLESME_KATEGORI_ACIKLAMA);
                }

                lue.Properties.DataSource = dt;
                lue.Properties.DisplayMember = "Sozlesme_Kategori";
                lue.Properties.ValueMember = "ID";

                lue.Properties.Columns.Add(new LookUpColumnInfo("Sozlesme_Kategori", "Sözleþme Kategori", 100));
                lue.Properties.Columns.Add(new LookUpColumnInfo("Aciklama", "Açýklama", 100));
            }
             */
        }

        public static void IsSozlesmeGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                //if (_IsSozlesmeGetir == null)
                //{
                    _IsSozlesmeGetir = context.per_AV001_TDI_BIL_IS_SOZLESMELERIs.ToList();
                //}

                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("SOZLESME_ADI", 45, "Sözleþme Adý") });
                lue.DataSource = _IsSozlesmeGetir;
                lue.DisplayMember = "SOZLESME_ADI";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void IsSurecGetir(RepositoryItemLookUpEdit rLue)
        {
            IsSurecGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void IsSurecGetir(LookUpEdit lue)
        {
            IsSurecGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void IsSurecGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_IsSurecGetir == null)
                {
                    _IsSurecGetir = AvukatProLib2.Data.DataRepository.AV001_TDI_KOD_IS_SURECProvider.GetAll();
                }
                lue.DataSource = _IsSurecGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "IS_SUREC";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("IS_SUREC", "Ýþ süreç", 40));
            }
        }

        /// <summary>
        /// TDI_KOD_IS_TARAF
        /// </summary>
        /// <param name="lue"></param>
        public static void IsTarafGetir(RepositoryItemLookUpEdit lue)
        {
            IsTarafGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_IS_TARAF
        /// </summary>
        /// <param name="lue"></param
        public static void IsTarafGetir(LookUpEdit lue)
        {
            IsTarafGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void IsTarafGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_IsTarafGetir == null)
                {
                    _IsTarafGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_IS_TARAFProvider.GetAll();
                }
                lue.DataSource = _IsTarafGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "IS_TARAF";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("IS_TARAF", "Iþ Taraf", 100));
            }
        }

        public static void ItirazSebebiGetir(RepositoryItemLookUpEdit lue)
        {
            ItirazSebebiGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TI_KOD_ITIRAZ_SEBEP
        /// </summary>
        /// <param name="lue"></param
        public static void ItirazSebebiGetir(LookUpEdit lue)
        {
            ItirazSebebiGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void ItirazSebebiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_ItirazSebebiGetir == null)
                {
                    _ItirazSebebiGetir = AvukatProLib2.Data.DataRepository.per_TI_KOD_ITIRAZ_SEBEPProvider.GetAll();
                }
                lue.DataSource = _ItirazSebebiGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "ITIRAZ_SEBEP";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ITIRAZ_SEBEP", "Itiraz Sebebi", 100));
            }
        }

        public static void ItirazSonucuGetir(RepositoryItemLookUpEdit rLue)
        {
            ItirazSonucuGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void ItirazSonucuGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_ItirazSonucuGetir == null)
                {
                    _ItirazSonucuGetir = DataRepository.per_TI_KOD_ITIRAZ_SONUCProvider.GetAll();
                }
                rLue.DataSource = _ItirazSonucuGetir;
                rLue.DisplayMember = "ITIRAZ_SONUC";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("ITIRAZ_SONUC", 30, "Ýtiraz Sonucu"));
            }
        }

        public static void KanGrupGetir(RepositoryItemLookUpEdit rLue)
        {
            KanGrupGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void KanGrupGetir(LookUpEdit lue)
        {
            KanGrupGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void KanGrupGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_KanGrupGetir == null)
                {
                    _KanGrupGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_KAN_GRUPProvider.GetAll();
                }
                rLue.DataSource = _KanGrupGetir;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "KAN_GRUP";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("KAN_GRUP", "Kan Grup", 100));
            }
        }

        //AV001_TD_BIL_DAVA_NEDEN
        /// <summary>
        /// TD_KOD_KANIT_TIP
        /// </summary>
        /// <param name="lue"></param>
        public static void KanitTipGetir(RepositoryItemLookUpEdit lue)
        {
            KanitTipGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TD_KOD_KANIT_TIP
        /// </summary>
        /// <param name="lue"></param>
        public static void KanitTipGetir(LookUpEdit lue)
        {
            KanitTipGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void KanitTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_KanitTipGetir == null)
                {
                    _KanitTipGetir = context.per_TD_KOD_KANIT_TIPs.ToList();
                }
                lue.NullText = "Seç";
                lue.DataSource = _KanitTipGetir;
                lue.DisplayMember = "KANIT_TIP";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("KANIT_TIP", "Kanýt Tip", 100));
            }
        }

        public static void KararSonucuGetir(RepositoryItemLookUpEdit rLue)
        {
            KararSonucuGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void KararSonucuGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_KararSonucuGetir == null)
                {
                    _KararSonucuGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_MAHKEME_HUKUMProvider.GetAll();
                }
                rLue.DataSource = _KararSonucuGetir;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "HUKUM";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("HUKUM", "Karar Sonucu", 100));
            }
        }

        /// <summary>
        /// TD_KOD_YUKSEK_MAHKEME_KARAR_TIP
        /// </summary>
        /// <param name="lue"></param>
        public static void KararTipGetir(RepositoryItemLookUpEdit lue)
        {
            KararTipGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TD_KOD_YUKSEK_MAHKEME_KARAR_TIP
        /// </summary>
        /// <param name="lue"></param
        public static void KararTipGetir(LookUpEdit lue)
        {
            KararTipGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void KararTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_KararTipGetir == null)
                {
                    _KararTipGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_YUKSEK_MAHKEME_KARAR_TIPProvider.GetAll();
                }
                lue.NullText = "Seç";
                lue.DataSource = _KararTipGetir;
                lue.DisplayMember = "KARAR_TIP";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("KARAR_TIP", "Karar Tipi", 100));
            }
        }

        public static VList<KASA_BILGILERI> KasaBilgileriGetir()
        {
            if (_KasaBilgileriGetir == null)
                _KasaBilgileriGetir = DataRepository.KASA_BILGILERIProvider.GetAll();
            return _KasaBilgileriGetir;
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_KAYIT_ILISKI> KayitIliskiGetir(int foyID)
        {
            if (per_AV001_TDI_BIL_KAYIT_ILISKI == null)
            {
                per_AV001_TDI_BIL_KAYIT_ILISKI = context.per_AV001_TDI_BIL_KAYIT_ILISKIs.Where(item => item.KAYNAK_KAYIT_ID == foyID).ToList();
            }
            return per_AV001_TDI_BIL_KAYIT_ILISKI;
        }

        /// <summary>
        /// TDI_KOD_KAYIT_ILISKI_NEDEN
        /// </summary>
        /// <param name="lue"></param>
        public static void KayitIliskiNedenGetir(RepositoryItemLookUpEdit lue)
        {
            KayitIliskiNedenGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_KAYIT_ILISKI_NEDEN
        /// </summary>
        /// <param name="lue"></param
        public static void KayitIliskiNedenGetir(LookUpEdit lue)
        {
            KayitIliskiNedenGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void KayitIliskiNedenGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_KayitIliskiNedenGetir == null)
                {
                    _KayitIliskiNedenGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_KAYIT_ILISKI_NEDENProvider.GetAll();
                }
                lue.DataSource = _KayitIliskiNedenGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "ILISKI_NEDEN";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ILISKI_NEDEN", "Kayýt Iliþki Neden", 100));
            }
        }

        /// <summary>
        /// TDI_KOD_KAYIT_ILISKI_TUR
        /// </summary>
        /// <param name="lue"></param>
        public static void KayitIliskiTurGetir(RepositoryItemLookUpEdit lue)
        {
            KayitIliskiTurGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_KAYIT_ILISKI_TUR
        /// </summary>
        /// <param name="lue"></param
        public static void KayitIliskiTurGetir(LookUpEdit lue)
        {
            KayitIliskiTurGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void KayitIliskiTurGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_KayitIliskiTurGetir == null)
                {
                    _KayitIliskiTurGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_KAYIT_ILISKI_TURProvider.GetAll();
                }
                lue.DataSource = _KayitIliskiTurGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "ILISKI_TUR";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ILISKI_TUR", "Kayýt Iliþki Tür", 100));
            }
        }

        public static void KayitliHesapTipleriGetir(LookUpEdit lue)
        {
            KayitliHesapTipleriGetir_Enter(lue, EventArgs.Empty);
        }

        public static void KayitliHesapTipleriGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_per_AV001_TI_KOD_HESAP_TIP == null)
                    _per_AV001_TI_KOD_HESAP_TIP = DataRepository.per_AV001_TI_KOD_HESAP_TIPProvider.GetAll();
                lue.DataSource = _per_AV001_TI_KOD_HESAP_TIP;
                lue.DisplayMember = "HESAP_TIP";
                lue.ValueMember = "ID";
            }
        }

        /// <summary>
        /// TDI_KOD_KDV
        /// </summary>
        /// <param name="lue"></param>
        public static void KDVTipGetir(RepositoryItemLookUpEdit lue)
        {
            KDVTipGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_KDV
        /// </summary>
        /// <param name="lue"></param
        public static void KDVTipGetir(LookUpEdit lue)
        {
            KDVTipGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void KDVTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_KDVTipGetir == null)
                {
                    if (CodeInfo<per_TDI_KOD_KDV>.ListeVarmi(typeof(per_TDI_KOD_KDV)))
                        _KDVTipGetir = CodeInfo<per_TDI_KOD_KDV>.ListeGetir(typeof(AvukatProLib2.Entities.per_TDI_KOD_KDV)) as VList<per_TDI_KOD_KDV>;
                    else
                    {
                        _KDVTipGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_KDVProvider.GetAll();
                        CodeInfo<per_TDI_KOD_KDV>.ListeKaydet(_KDVTipGetir, typeof(per_TDI_KOD_KDV));
                    }
                }
                lue.DataSource = _KDVTipGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("AD", "KDV Tipi", 100));
            }
        }

        public static void KEAhzolunmaSekliGetir(RepositoryItemLookUpEdit lue)
        {
            KEAhzolunmaSekliGetir_Enter(lue, EventArgs.Empty);
        }

        public static void KEAhzolunmaSekliGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("AhzolunmaSekli");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.KEvrakAhzolunmaSekli tipi in Enum.GetValues(typeof(AvukatProLib.Extras.KEvrakAhzolunmaSekli)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";

                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Ahzolunma Þekli"));
            }
        }

        public static void KefaletKapsamGetir(RepositoryItemLookUpEdit lue)
        {
            KefaletKapsamGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TI_KOD_KEFALET_KAPSAM
        /// </summary>
        /// <param name="lue"></param
        public static void KefaletKapsamGetir(LookUpEdit lue)
        {
            KefaletKapsamGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void KefaletKapsamGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_KefaletKapsamGetir == null)
                {
                    _KefaletKapsamGetir = AvukatProLib2.Data.DataRepository.per_TI_KOD_KEFALET_KAPSAMProvider.GetAll();
                }
                lue.DataSource = _KefaletKapsamGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "KEFALET_KAPSAM";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("KEFALET_KAPSAM", "Kefalet Kapsam", 100));
            }
        }

        public static void KESonucuGetir(RepositoryItemLookUpEdit lue)
        {
            KESonucuGetir_Enter(lue, EventArgs.Empty);
        }

        public static void KESonucuGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("KEvrakSonucu");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.KEvrakSonucu tipi in Enum.GetValues(typeof(AvukatProLib.Extras.KEvrakSonucu)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "EvrakSonucu"));
            }
        }

        public static void KimlikTurGetir(RepositoryItemLookUpEdit rLue)
        {
            KimlikTurGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void KimlikTurGetir(LookUpEdit lue)
        {
            KimlikTurGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void KimlikTurGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_KimlikTurGetir == null)
                {
                    _KimlikTurGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_KIMLIKProvider.GetAll();
                }
                lue.DataSource = _KimlikTurGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "KIMLIK";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("KIMLIK", "Kimlik Tür", 40));
            }
        }

        public static void KimlikVerilisNedenGetir(RepositoryItemLookUpEdit rLue)
        {
            KimlikVerilisNedenGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void KimlikVerilisNedenGetir(LookUpEdit lue)
        {
            KimlikVerilisNedenGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void KimlikVerilisNedenGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_KimlikVerilisNedenGetir == null)
                {
                    _KimlikVerilisNedenGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_KIMLIK_VERILIS_NEDENProvider.GetAll();
                }
                lue.DataSource = _KimlikVerilisNedenGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "VERILIS_NEDEN";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("VERILIS_NEDEN", "Kimlik Veriliþ Neden", 40));
            }
        }

        public static void KimYerineGetirecekEnumGetir(RepositoryItemLookUpEdit lue)
        {
            KimYerineGetirecekEnumGetir_Enter(lue, EventArgs.Empty);
        }

        public static void KimYerineGetirecekEnumGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("KimYerineGetirecek");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.KimYerineGetirecek tipi in Enum.GetValues(typeof(AvukatProLib.Extras.KimYerineGetirecek)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Kim Yerine Getirecek"));
            }
        }

        public static TList<AV001_TDI_BIL_KIYMETLI_EVRAK> KiymetliEvrakGetir()
        {
            if (_KiymetliEvrakGetir == null)
                _KiymetliEvrakGetir = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetAll();
            return _KiymetliEvrakGetir;
        }

        public static void KiymetliEvrakGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_KiymetliEvrakTipiGetir == null)
                    _KiymetliEvrakTipiGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_KIYMETLI_EVRAK_TURProvider.GetAll();

                lue.DataSource = _KiymetliEvrakTipiGetir;
                lue.DisplayMember = "TUR";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("TUR", 10, "Evrak türü"));
            }
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_KIYMETLI_EVRAK> KiymetliEvrakGetirByIdList(List<int> idList)
        {
            if (_VDIE_PROJE_KIYMETLI_EVRAK != null)
                return (from item in _VDIE_PROJE_KIYMETLI_EVRAK where idList.Contains(item.KIYMETLI_EVRAK_ID) select item).ToList();
            return (from item in context.per_AV001_TDI_BIL_KIYMETLI_EVRAKs where idList.Contains(item.KIYMETLI_EVRAK_ID) select item).ToList();
        }

        public static void KiymetliEvraklariGetir(RepositoryItemLookUpEdit lue)
        {
            KiymetliEvraklariGetir_Enter(lue, EventArgs.Empty);
        }

        public static void KiymetliEvraklariGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_KiymetliEvrakGetir == null)
                    _KiymetliEvrakGetir = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetAll();

                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Evrak Türü");
                dt.Columns.Add("Tanzim T");
                dt.Columns.Add("Vade T");
                dt.Columns.Add("Tutar");
                dt.Columns.Add("Banka");
                dt.Columns.Add("Þube");

                foreach (AV001_TDI_BIL_KIYMETLI_EVRAK item in _KiymetliEvrakGetir)
                {
                    DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_KIYMETLI_EVRAK_TUR), typeof(TDI_KOD_BANKA), typeof(TDI_KOD_BANKA_SUBE));

                    if (item.EVRAK_TUR_IDSource != null && item.BANKA_IDSource != null && item.SUBE_IDSource != null)
                        dt.Rows.Add(item.ID, item.EVRAK_TUR_IDSource.TUR, item.EVRAK_TANZIM_TARIHI, item.EVRAK_VADE_TARIHI, item.TUTAR, item.BANKA_IDSource.BANKA, item.SUBE_IDSource.SUBE);
                }

                lue.DataSource = dt;
                lue.NullText = "Seç";
                lue.DisplayMember = "Evrak Türü";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("Evrak Türü", "Evrak Türü", 40));
                lue.Columns.Add(new LookUpColumnInfo("Tanzim T", "Tanzim T", 12));
                lue.Columns.Add(new LookUpColumnInfo("Vade T", "Vade T", 12));
                lue.Columns.Add(new LookUpColumnInfo("Tutar", "Tutar", 20));
                lue.Columns.Add(new LookUpColumnInfo("Banka", "Banka", 100));
                lue.Columns.Add(new LookUpColumnInfo("Þube", "Þube", 100));
            }
        }

        public static void KiymetliEvrakStatuDurumGetir(RepositoryItemLookUpEdit rLue)
        {
            KiymetliEvrakStatuDurumGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void KiymetliEvrakStatuDurumGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_KiymetliEvrakStatuDurumGetir == null)
                {
                    _KiymetliEvrakStatuDurumGetir = DataRepository.per_TDI_KOD_KIYMETLI_EVRAK_STATUProvider.GetAll();
                }
                rLue.DataSource = _KiymetliEvrakStatuDurumGetir;
                rLue.DisplayMember = "STATU";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("STATU", 30, "Durum"));
            }
        }

        public static void KiymetliEvrakTarafTipGetir(RepositoryItemLookUpEdit rLue)
        {
            KiymetliEvrakTarafTipGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void KiymetliEvrakTarafTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_KiymetliEvrakTarafTipGetir == null)
                {
                    _KiymetliEvrakTarafTipGetir = DataRepository.per_TDI_KOD_KIYMETLI_EVRAK_TARAF_TIPProvider.GetAll();
                }
                rLue.DataSource = _KiymetliEvrakTarafTipGetir;
                rLue.DisplayMember = "TARAF_TIP";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("TARAF_TIP", 30, "Tip"));
            }
        }

        public static void KiymetliEvrakTipiGetir(RepositoryItemLookUpEdit lue)
        {
            KiymetliEvrakGetir_Enter(lue, EventArgs.Empty);
        }

        public static void KiymetliEvrakTipiGetir(LookUpEdit lue)
        {
            KiymetliEvrakGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static TList<AV001_TI_BIL_KIYMET_TAKDIRI> KiymetTakdiriGetir()
        {
            if (_KiymetTakdiriGetir == null)
                _KiymetTakdiriGetir = AvukatProLib2.Data.DataRepository.AV001_TI_BIL_KIYMET_TAKDIRIProvider.GetAll();
            return _KiymetTakdiriGetir;
        }

        public static void KlasorSorumluAvukatGetir(LookUpEdit lue, int klasorID)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.DataSource = context.per_KlasorSorumluAvukats.Where(vi => vi.PROJE_ID == klasorID).ToList();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("AD", 0, "Avukat") });
            lue.Properties.DisplayMember = "AD";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
        }

        public static List<AvukatProLib.Arama.per_TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> KOD_ALACAK_NEDEN_GRUP_DEGISKENGetir()
        {
            if (_KOD_ALACAK_NEDEN_GRUP_DEGISKEN == null)
                _KOD_ALACAK_NEDEN_GRUP_DEGISKEN = context.per_TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKENs.ToList();
            return _KOD_ALACAK_NEDEN_GRUP_DEGISKEN;
        }

        public static List<AvukatProLib.Arama.per_TIE_KOD_ALACAK_NEDEN_GRUP> KOD_ALACAK_NEDEN_GRUPGetir()
        {
            if (_KOD_ALACAK_NEDEN_GRUP == null)
                _KOD_ALACAK_NEDEN_GRUP = context.per_TIE_KOD_ALACAK_NEDEN_GRUPs.ToList();
            return _KOD_ALACAK_NEDEN_GRUP;
        }

        public static List<AvukatProLib.Arama.per_TDIE_KOD_SOZLUK> KodSozlukGetir()
        {
            if (_KodSozlukGetir == null)
                _KodSozlukGetir = context.per_TDIE_KOD_SOZLUKs.ToList();
            return _KodSozlukGetir;
        }

        public static void KrediGrubu(RepositoryItemLookUpEdit lue)
        {
            KrediGrubu_Enter(lue, EventArgs.Empty);
        }

        public static void KrediGrubu(LookUpEdit lue)
        {
            KrediGrubu_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void KrediGrubu_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if ((lue.DataSource == null))
            {
                // lue.BeginUpdate();
                if (_KrediGrubu == null)
                    _KrediGrubu = AvukatProLib2.Data.DataRepository.per_TDI_KOD_KREDI_GRUPProvider.GetAll();

                lue.DataSource = _KrediGrubu;
                lue.DisplayMember = "KREDI_GRUP";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("KREDI_GRUP", 10, "Kredi Grubu"));

                //lue.EndUpdate();
            }
        }

        public static void KrediGrubuGetirByFoyBirimID(LookUpEdit lue, int FoyBirimID)
        {
            lue.Properties.BeginUpdate();

            lue.Properties.DisplayMember = "KREDI_GRUP";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("KREDI_GRUP", 30, "Kredi Grubu"));
            lue.Properties.DataSource = DataRepository.per_TDI_KOD_KREDI_GRUPProvider.Get("FOY_BIRIM_ID=" + FoyBirimID, " KREDI_GRUP DESC");

            lue.Properties.EndUpdate();
        }

        //TDI_KOD_KREDI_GRUP
        public static void KrediGrupGetirByFoyBirim(LookUpEdit lue, int FoyBirim)
        {
            lue.Properties.NullText = "Seç";
            KrediGrupGetirByFoyBirim_Enter(lue, EventArgs.Empty);
            lue.Tag = FoyBirim;
        }

        public static void KrediGrupGetirByFoyBirim_Enter(object sender, EventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            if (lue.Properties.DataSource == null)
            {
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KREDI_GRUP", 10, "Kredi grup") });
                int FoyBirim = Convert.ToInt32(lue.Tag);
                lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.per_TDI_KOD_KREDI_GRUPProvider.Get("FOY_BIRIM_ID=" + FoyBirim, "KREDI_GRUP DESC");

                lue.Properties.DisplayMember = "KREDI_GRUP";
                lue.Properties.ValueMember = "ID";
            }
        }

        public static void KrediTipiGetir(RepositoryItemLookUpEdit lue)
        {
            KrediTipiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void KrediTipiGetir(LookUpEdit lue)
        {
            KrediTipiGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void KrediTipiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_KrediTipiGetir == null)
                    _KrediTipiGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_KREDI_TIPProvider.GetAll();

                lue.DataSource = _KrediTipiGetir;
                lue.ValueMember = "ID";
                lue.DisplayMember = "KREDI_TIP";
                lue.NullText = "Seç";
                LookUpColumnInfo ID = new LookUpColumnInfo("ID", 20);
                ID.Visible = false;

                LookUpColumnInfo KART_TIPI = new LookUpColumnInfo("KREDI_TIP", 40, "Kredi Tipi");
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { ID, KART_TIPI });
            }
        }

        public static void KrediTipiGetirByKrediGrup(RepositoryItemLookUpEdit lue, int KrediGrup)
        {
            if (_KrediTipiGetir != null)
            {
                lue.DataSource = _KrediTipiGetir.Where(item => item.KREDI_GRUP_ID == KrediGrup).OrderByDescending(item => item.KREDI_TIP);
            }
            else
                lue.DataSource = AvukatProLib2.Data.DataRepository.per_TDI_KOD_KREDI_TIPProvider.Get(" KREDI_GRUP_ID=" + KrediGrup, "KREDI_TIP DESC");

            lue.ValueMember = "ID";
            lue.DisplayMember = "KREDI_TIP";
            LookUpColumnInfo ID = new LookUpColumnInfo("ID", 20);
            ID.Visible = false;
            lue.NullText = "Seç";
            LookUpColumnInfo KART_TIPI = new LookUpColumnInfo("KREDI_TIP", 40, "Kredi Tipi");
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { ID, KART_TIPI });
        }

        public static void KrediTipiGetirByKrediGrup(LookUpEdit lue, int KrediGrup)
        {
            if (_KrediTipiGetir != null)
            {
                lue.Properties.DataSource = _KrediTipiGetir.Where(item => item.KREDI_GRUP_ID == KrediGrup).OrderByDescending(item => item.KREDI_TIP);
            }
            else
                lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.per_TDI_KOD_KREDI_TIPProvider.Get(" KREDI_GRUP_ID=" + KrediGrup, "KREDI_TIP DESC");

            lue.Properties.ValueMember = "ID";
            lue.Properties.DisplayMember = "KREDI_TIP";
            lue.Properties.NullText = "Seç";
            LookUpColumnInfo ID = new LookUpColumnInfo("ID", 20);
            ID.Visible = false;

            LookUpColumnInfo KART_TIPI = new LookUpColumnInfo("KREDI_TIP", 40, "Kredi Tipi");
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { ID, KART_TIPI });
        }

        public static void KullaniciGrupGetir(LookUpEdit lue)
        {
            lue.Properties.NullText = "Seç";
            KullaniciGrupGetir_Enter(lue, EventArgs.Empty);
        }

        public static void KullaniciGrupGetir(CheckedComboBoxEdit[] controls)
        {
            foreach (CheckedComboBoxEdit control in controls)
            {
                control.Properties.Items.Clear();
                foreach (CS_KOD_KULLANICI_GRUP gr in DataRepository.CS_KOD_KULLANICI_GRUPProvider.GetAll())
                {
                    control.Properties.Items.Add(gr.ADI);
                }
                control.Properties.NullText = "Seç";
            }
        }

        public static void KullaniciGrupGetir_Enter(object sender, EventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            if (lue.Properties.DataSource == null)
            {
                if (_KullaniciGrupGetir == null)
                {
                    _KullaniciGrupGetir = DataRepository.CS_KOD_KULLANICI_GRUPProvider.GetAll();
                }
                lue.Properties.DataSource = _KullaniciGrupGetir;
                lue.Properties.DisplayMember = "ADI";
                lue.Properties.ValueMember = "ID";

                lue.Properties.Columns.Clear();

                lue.Properties.Columns.Add(new LookUpColumnInfo("ADI", "Kullanýcý Grubu", 40));
            }
        }

        public static void KullaniciListesiGetir(RepositoryItemLookUpEdit rLue)
        {
            KullaniciListesiGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void KullaniciListesiGetir(LookUpEdit lue)
        {
            KullaniciListesiGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void KullaniciListesiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_KullaniciListesiGetir == null)
                {
                    _KullaniciListesiGetir = DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.GetAll();
                }
                rLue.DataSource = _KullaniciListesiGetir;
                rLue.DisplayMember = "KULLANICI_ADI";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("KULLANICI_ADI", 30, "Kullanýcý Adý"));
            }
        }

        //TDIE_BIL_KULLANICI_SUBELERI
        public static void KullaniciSubeleriGetir(RepositoryItemLookUpEdit rLue)
        {
            KullaniciSubeleriGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void KullaniciSubeleriGetir(LookUpEdit lue)
        {
            KullaniciSubeleriGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static TList<TDIE_BIL_KULLANICI_SUBELERI> KullaniciSubeleriGetir()
        {
            if (_TDIE_BIL_KULLANICI_SUBELERI == null)
                _TDIE_BIL_KULLANICI_SUBELERI = DataRepository.TDIE_BIL_KULLANICI_SUBELERIProvider.GetAll();
            return _TDIE_BIL_KULLANICI_SUBELERI;
        }

        public static void KullaniciSubeleriGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_KullaniciListesiGetir == null)
                {
                    _KullaniciListesiGetir = DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.GetAll();
                }
                rLue.DataSource = _KullaniciListesiGetir;
                rLue.DisplayMember = "SUBE_ADI";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("SUBE_ADI", 30, "Þube Kodu"));
            }
        }

        public static void KurBilgisiGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("KurBilgisi");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (AvukatProLib.Extras.KurBilgisi tur in Enum.GetValues(typeof(AvukatProLib.Extras.KurBilgisi)))
            {
                dt.Rows.Add((int)tur, tur.ToString());
            }
            lue.DataSource = dt;
            lue.ValueMember = "ID";
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 20, "Kur Bilgisi"));
        }

        public static void KurumsalGirisFormTipi(RepositoryItemLookUpEdit lue)
        {
            KurumsalGirisFormTipi_Enter(lue, EventArgs.Empty);
        }

        public static void KurumsalGirisFormTipi_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("FormTip");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (EkspressIslemler tipi in Enum.GetValues(typeof(EkspressIslemler)))
                {
                    string[] dizim = tipi.ToString().Split('_');
                    dt.Rows.Add((int)tipi, dizim[0] + " (Alt+" + dizim[1] + ")");
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Ýþlem"));
            }
        }

        public static void llceGetirIlle(RepositoryItemLookUpEdit lue)
        {
            if (_llceGetirIlle == null)
                _llceGetirIlle = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ILCEProvider.GetAll();

            lue.Columns.Clear();
            lue.DataSource = _llceGetirIlle;
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("IL", 20, "Ýl"), new LookUpColumnInfo("ILCE", 20, "Ýlce") });
            lue.DisplayMember = "ILCE";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        public static void MahkemeGoreviGetir(LookUpEdit lue)
        {
            MahkemeGoreviGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void MahkemeGoreviGetir(RepositoryItemLookUpEdit lue)
        {
            MahkemeGoreviGetir_Enter(lue, EventArgs.Empty);
        }

        ///<summary>
        ///<see cref="TDI_KOD_ADLI_BIRIM_GOREV"/> Tipindeki entityleri lookup içine doldurur.
        ///</summary>
        ///<param name="lue">Verilerin doldurulacaðý kontrol</param>
        ///<param name="ilamsizGorevlerleBirlikte">Tüm görevleri getirmek için true olmasý gerekir</param>
        public static void MahkemeGoreviGetir(RepositoryItemLookUpEdit lue, bool ilamsizGorevlerleBirlikte)
        {
            if (_MahkemeGoreviGetir_Enter == null)
            {
                _MahkemeGoreviGetir_Enter = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ADLI_BIRIM_GOREVProvider.GetAll();
            }

            if (ilamsizGorevlerleBirlikte)
            {
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[]
                                         {
                                             new LookUpColumnInfo("GOREV", 20, "Kod"),
                                             new LookUpColumnInfo("ACIKLAMA", 40, "Görev")
                                         });
                lue.DataSource = _MahkemeGoreviGetir_Enter;

                // AvukatProLib.Facade.TDI_KOD_ADLI_BIRIM_GOREV.TDI_KOD_ADLI_BIRIM_GOREVGetir();
                lue.ValueMember = "ID";
                lue.DisplayMember = "GOREV";
                lue.NullText = "Seç";
            }
            else
            {
                MahkemeGoreviGetir(lue);
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////ToDo : Burada Kaldýk gkn/////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///<summary>
        ///<see cref="TDI_KOD_ADLI_BIRIM_GOREV"/> Tipindeki entityleri lookup içine doldurur.
        ///</summary>
        ///<param name="lue">Verilerin doldurulacaðý kontrol</param>
        ///<param name="ilamsizGorevlerleBirlikte">Tüm görevleri getirmek için true olmasý gerekir</param>
        public static void MahkemeGoreviGetir(LookUpEdit lue, bool ilamsizGorevlerleBirlikte)
        {
            MahkemeGoreviGetir(lue.Properties, ilamsizGorevlerleBirlikte);
        }

        public static void MahkemeGoreviGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_MahkemeGoreviGetir_Enter == null)
                {
                    _MahkemeGoreviGetir_Enter = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ADLI_BIRIM_GOREVProvider.GetAll();
                }
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("GOREV", 20, "Kod"), new LookUpColumnInfo("ACIKLAMA", 40, "Görev") });
                lue.DataSource = _MahkemeGoreviGetir_Enter;

                // AvukatProLib.Facade.TDI_KOD_ADLI_BIRIM_GOREV.TDI_KOD_ADLI_BIRIM_GOREVGetir();
                lue.ValueMember = "ID";
                lue.DisplayMember = "GOREV";
            }
        }

        /// <summary>
        /// AV001_TD_BIL_MAHKEME_HUKUM
        /// </summary>
        /// <param name="lue"></param>
        public static void MahkemeHukumGetir(RepositoryItemLookUpEdit lue, int davaFoyID)
        {
            //ToDo : View yapýlacak
            lue.Tag = davaFoyID;
            MahkemeHukumGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// AV001_TD_BIL_MAHKEME_HUKUM
        /// </summary>
        /// <param name="lue"></param
        public static void MahkemeHukumGetir(LookUpEdit lue)
        {
            MahkemeHukumGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void MahkemeHukumGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                _MahkemeHukumGetir = context.per_AV001_TD_BIL_MAHKEME_HUKUMs.ToList();
                lue.NullText = "Seç";
                if (lue.Tag != null && lue.Tag is int)
                    lue.DataSource = (_MahkemeHukumGetir as List<AvukatProLib.Arama.per_AV001_TD_BIL_MAHKEME_HUKUM>).FindAll(vi => vi.DAVA_FOY_ID == (int)lue.Tag);
                else
                    lue.DataSource = _MahkemeHukumGetir;
                lue.DisplayMember = "HUKUM";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KARAR_NO", 10, "Karar No"), new LookUpColumnInfo("HUKUM_TARIHI", 30, "Karar Tarihi"), new LookUpColumnInfo("HUKUM", 10, "Karar"), new LookUpColumnInfo("TARAF_ADI", 10, "Taraf") });
            }
        }

        public static void MahkemeHukumTipGetir(RepositoryItemLookUpEdit rLue)
        {
            MahkemeHukumTipGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void MahkemeHukumTipGetir(LookUpEdit lue)
        {
            MahkemeHukumTipGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void MahkemeHukumTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_MahkemeHukumTipGetir == null)
                {
                    _MahkemeHukumTipGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_MAHKEME_HUKUM_TIPProvider.GetAll();
                }
                lue.DataSource = _MahkemeHukumTipGetir;
                lue.DisplayMember = "HUKUM_TIP";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("HUKUM_TIP", "Mahkeme Hüküm Tip", 40));
            }
        }

        /// <summary>
        /// TDI_KOD_MAHSUP_ALT_KATEGORI
        /// </summary>
        /// <param name="rLue"></param>
        public static void MahsupAltKategoriGetir(RepositoryItemLookUpEdit lue)
        {
            MahsupAltKategoriGetir_Enter(lue, EventArgs.Empty);
        }

        public static void MahsupAltKategoriGetir(LookUpEdit lue)
        {
            MahsupAltKategoriGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void MahsupAltKategoriGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_MahsupAltKategori == null)
                {
                    _MahsupAltKategori = AvukatProLib2.Data.DataRepository.per_TDI_KOD_MAHSUP_ALT_KATEGORIProvider.GetAll();
                }
                lue.DataSource = _MahsupAltKategori;
                lue.NullText = "Seç";
                lue.DisplayMember = "MAHSUP_ALT_KATEGORI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("MAHSUP_ALT_KATEGORI", "Mahsup Alt Kategori", 40));
            }
        }

        /// <summary>
        /// TDI_KOD_MAHSUP_KATEGORI
        /// </summary>
        /// <param name="rLue"></param>
        public static void MahsupKategoriGetir(RepositoryItemLookUpEdit rLue)
        {
            MahsupKategoriGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void MahsupKategoriGetir(LookUpEdit lue)
        {
            MahsupKategoriGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static VList<per_TDI_KOD_MAHSUP_KATEGORI> MahsupKategoriGetir()
        {
            if (_MahsupKategori == null)
            {
                _MahsupKategori = AvukatProLib2.Data.DataRepository.per_TDI_KOD_MAHSUP_KATEGORIProvider.GetAll();
            }
            return _MahsupKategori;
        }

        public static void MahsupKategoriGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                lue.DataSource = MahsupKategoriGetir();
                lue.DisplayMember = "MAHSUP_KATEGORI";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("MAHSUP_KATEGORI", "Mahsup Kategori", 40));
            }
        }

        /// <summary>
        /// TI_KOD_MAL_CINS
        /// </summary>
        /// <param name="lue"></param>
        public static void MalcinsGetir(RepositoryItemLookUpEdit lue)
        {
            if (_MalcinsGetir == null)
            {
                _MalcinsGetir = AvukatProLib2.Data.DataRepository.per_TI_KOD_MAL_CINSProvider.GetAll();
            }

            lue.DataSource = _MalcinsGetir;
            lue.NullText = "Seç";
            lue.DisplayMember = "CINS";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("CINS", "Mal Cinsi", 100));
        }

        /// <summary>
        /// TI_KOD_MAL_CINS
        /// </summary>
        /// <param name="lue"></param
        public static void MalcinsGetir(LookUpEdit lue)
        {
            lue.Properties.NullText = "Seç";
            MalcinsGetir_Enter(lue, EventArgs.Empty);
        }

        public static void MalcinsGetir_Enter(object sender, EventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            if (lue.Properties.DataSource == null)
            {
                if (_MalcinsGetir == null)
                {
                    _MalcinsGetir = AvukatProLib2.Data.DataRepository.per_TI_KOD_MAL_CINSProvider.GetAll();
                }
                lue.Properties.DataSource = _MalcinsGetir;
                lue.Properties.DisplayMember = "CINS";
                lue.Properties.ValueMember = "ID";
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.Add(new LookUpColumnInfo("CINS", "Mal Cinsi", 100));
            }
        }

        public static void MalCinsGetirRefersh()
        {
            _MalcinsGetir = DataRepository.per_TI_KOD_MAL_CINSProvider.GetAll();
        }

        public static void MalcinsGetirTureGore(RepositoryItemLookUpEdit lue, int TurId)
        {
            if (_MalcinsGetir == null)
            {
                _MalcinsGetir = AvukatProLib2.Data.DataRepository.per_TI_KOD_MAL_CINSProvider.GetAll();
            }
            lue.DataSource = _MalcinsGetir.FindAll(item => item.TUR_ID == TurId);

            //lue.DataSource = AvukatProLib2.Data.DataRepository.per_TI_KOD_MAL_CINSProvider.GetAll().Where(v => v.TUR_ID == TurId).ToList();
            lue.NullText = "Seç";
            lue.DisplayMember = "CINS";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("CINS", "Mal Cinsi", 100));
        }

        public static void MalikiGetirForGayrimenkulTaraf(LookUpEdit lue, int gayrimenkulID)
        {
            if (lue.Properties.DataSource == null)
            {
                List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariler = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>();
                var list = DataRepository.AV001_TI_BIL_GAYRIMENKUL_TARAFProvider.GetByGAYRI_MENKUL_ID(gayrimenkulID);
                list.ForEach(item =>
                {
                    if (item.TARAF_CARI_ID.HasValue)
                    {
                        if (_per_CariGetir == null)
                            _per_CariGetir = context.per_AV001_TDI_BIL_CARIs.ToList();
                        var cari = _per_CariGetir.Find(vi => vi.ID == item.TARAF_CARI_ID.Value);
                        if (cari != null && !cariler.Contains(cari))
                            cariler.Add(cari);
                    }
                });
                lue.Properties.DataSource = cariler;
                lue.Properties.DisplayMember = "AD";
                lue.Properties.ValueMember = "ID";
                lue.Properties.NullText = "Seç";
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.Add(new LookUpColumnInfo("AD", 30, "Ad"));
            }
        }

        public static void MalikiGetirForHacizIstenen(LookUpEdit lue, int cariID)
        {
            if (lue.Properties.DataSource == null)
            {
                lue.Properties.DataSource = BelgeUtil.Inits._per_CariGetir.FindAll(vi => vi.ID == cariID);
                lue.Properties.DisplayMember = "AD";
                lue.Properties.ValueMember = "ID";
                lue.Properties.NullText = "Seç";
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.Add(new LookUpColumnInfo("AD", 30, "Ad"));
            }
        }

        /// <summary>
        /// TI_KOD_MAL_KATEGORI
        /// </summary>
        /// <param name="lue"></param>
        public static void MalKategoriGetir(RepositoryItemLookUpEdit lue)
        {
            MalKategoriGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TI_KOD_MAL_KATEGORI
        /// </summary>
        /// <param name="lue"></param
        public static void MalKategoriGetir(LookUpEdit lue)
        {
            MalKategoriGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void MalKategoriGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_MalKategoriGetir == null)
                {
                    _MalKategoriGetir = AvukatProLib2.Data.DataRepository.per_TI_KOD_MAL_KATEGORIProvider.GetAll();
                }
                lue.DataSource = _MalKategoriGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "KATEGORI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("KATEGORI", "Mal Kategori", 100));
            }
        }

        /// <summary>
        ///Mal Kategorilerini Resimleri ile getirir
        /// </summary>
        /// <param name="combo"></param>
        public static void MalKategoriResimliGetir(RepositoryItemImageComboBox combo)
        {
            ImageList lstImg = new ImageList();

            combo.Items.AddRange(GetMalKategoriImages(lstImg).ToArray());
            combo.SmallImages = lstImg;
            combo.LargeImages = lstImg;
            combo.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
        }

        /// <summary>
        /// TI_KOD_MAL_KATEGORI_CINS_TUR
        /// </summary>
        /// <param name="lue"></param>
        public static void MalKategoriTurCinsGetir(RepositoryItemLookUpEdit lue)
        {
            MalKategoriTurCinsGetir_Enter(lue, EventArgs.Empty);
        }

        public static void MalKategoriTurCinsGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_MalKategoriTurCinsGetir == null)
                {
                    _MalKategoriTurCinsGetir = AvukatProLib2.Data.DataRepository.per_TI_KOD_MAL_CINSProvider.GetAll();
                }
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("CINS", 20, "Cins"), new LookUpColumnInfo("TUR", 20, "Tür"), new LookUpColumnInfo("KATEGORI", 20, "Kategori") });
                lue.DataSource = _MalKategoriTurCinsGetir;
                lue.DisplayMember = "CINS";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        /// <summary>
        /// TI_KOD_MAL_TUR
        /// </summary>
        /// <param name="lue"></param>
        public static void MalTurGetir(RepositoryItemLookUpEdit lue)
        {
            MalTurGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TI_KOD_MAL_TUR
        /// </summary>
        /// <param name="lue"></param
        public static void MalTurGetir(LookUpEdit lue)
        {
            MalTurGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void MalTurGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_MalTurGetir == null)
                {
                    _MalTurGetir = AvukatProLib2.Data.DataRepository.per_TI_KOD_MAL_TURProvider.GetAll();
                }
                lue.DataSource = _MalTurGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "TUR";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("TUR", "Mal Tür", 100));
            }
        }

        public static void MalTurGetirKategoriyeGore(LookUpEdit lue, int KatId)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.per_TI_KOD_MAL_TURProvider.GetAll().Where(v => v.KATEGORI_ID == KatId).ToList();
            lue.Properties.NullText = "Seç";
            lue.Properties.DisplayMember = "TUR";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("TUR", "Mal Tür", 100));
        }

        public static void MalTurGetirKategoriyeGore(RepositoryItemLookUpEdit rlue, int KatId)
        {
            rlue.DataSource = AvukatProLib2.Data.DataRepository.per_TI_KOD_MAL_TURProvider.GetAll().Where(v => v.KATEGORI_ID == KatId).ToList();
            rlue.NullText = "Seç";
            rlue.DisplayMember = "TUR";
            rlue.ValueMember = "ID";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("TUR", "Mal Tür", 100));
        }

        public static void MalTurGetirRefersh()
        {
            _MalTurGetir = DataRepository.per_TI_KOD_MAL_TURProvider.GetAll();
        }

        public static void MarkaTipGetir(RepositoryItemLookUpEdit rLue)
        {
            MarkaTipGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void MarkaTipGetir(LookUpEdit lue)
        {
            MarkaTipGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void MarkaTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_MarkaTipGetir == null)
                {
                    _MarkaTipGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_REHIN_HARC_ISTISNA_BELGEProvider.GetAll();
                }
                lue.DataSource = _MarkaTipGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "MARKA_TIP_AD";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("MARKA_TIP_AD", "Marka Tip", 40));
            }
        }

        public static void MasrafAvansGetirSozlesme(RepositoryItemLookUpEdit lue, AV001_TDI_BIL_SOZLESME foy)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Referans No");

            if (_masrafAvansGetir == null)
            {
                _masrafAvansGetir = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetBySOZLESME_ID(foy.ID);
            }
            foreach (var item in _masrafAvansGetir)
            {
                dt.Rows.Add(item.ID, item.REFERANS_NO + " (Tip :" + (MasrafAvansTip)item.MASRAF_AVANS_TIP + ")");
            }
            lue.DataSource = dt;
            lue.NullText = "Seç";
            lue.DisplayMember = "Referans No";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("Referans No", " Masraf Avans", 100));
        }

        public static void MasrafAvansHedefTipGetir(RepositoryItemLookUpEdit lue)
        {
            MasrafAvansHedefTipGetir_Enter(lue, EventArgs.Empty);
        }

        public static void MasrafAvansHedefTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("HedefTip");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.MasrafAvansHedefTip tipi in Enum.GetValues(typeof(AvukatProLib.Extras.MasrafAvansHedefTip)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Hedef Tipi"));
            }
        }

        public static void MedeniHalGetir(RepositoryItemLookUpEdit rLue)
        {
            MedeniHalGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void MedeniHalGetir(LookUpEdit lue)
        {
            MedeniHalGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void MedeniHalGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_MedeniHalGetir == null)
                {
                    _MedeniHalGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_MEDENI_HALProvider.GetAll();
                }
                lue.DataSource = _MedeniHalGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "MEDENI_HAL";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("MEDENI_HAL", "Medeni Hal", 40));
            }
        }

        public static void MeslekGetir(LookUpEdit lue)
        {
            MeslekGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void MeslekGetir(RepositoryItemLookUpEdit lue)
        {
            MeslekGetir_Enter(lue, EventArgs.Empty);
        }

        public static void MeslekGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_MeslekGetir_Enter == null)
                {
                    _MeslekGetir_Enter = AvukatProLib2.Data.DataRepository.per_TDI_KOD_MESLEKProvider.GetAll();
                }
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("MESLEK", 10, "Meslek") });
                lue.DataSource = _MeslekGetir_Enter;
                lue.DisplayMember = "MESLEK";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void ModulKodGetir(RepositoryItemLookUpEdit rLue)
        {
            ModulKodGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void ModulKodGetir(LookUpEdit lue)
        {
            ModulKodGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void ModulKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_ModulKodGetir == null)
                {
                    _ModulKodGetir = AvukatProLib2.Data.DataRepository.per_TDIE_KOD_MODULProvider.GetAll();
                }

                VList<per_TDIE_KOD_MODUL> modList = new VList<per_TDIE_KOD_MODUL>();

                foreach (per_TDIE_KOD_MODUL item in _ModulKodGetir)
                {
                    if (item.AD == "Dava" || item.AD == "Icra" || item.AD == "Soruþturma" || item.AD == "Sözleþme" || item.AD == "Genel")
                        modList.Add(item);
                }

                lue.DataSource = modList;
                lue.NullText = "Seç";
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("AD", "Modül Ad", 40));
            }
        }

        public static void ModulKodGetirForKayitIliski(RepositoryItemLookUpEdit rLue)
        {
            ModulKodGetirForKayitIliski_Enter(rLue, EventArgs.Empty);
        }

        public static void ModulKodGetirForKayitIliski(LookUpEdit lue)
        {
            ModulKodGetirForKayitIliski_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void ModulKodGetirForKayitIliski_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_ModulKodGetirForKayitIliski == null)
                {
                    _ModulKodGetirForKayitIliski = AvukatProLib2.Data.DataRepository.per_TDIE_KOD_MODULProvider.GetAll();
                    _ModulKodGetirForKayitIliski.Filter = "ID < 6";
                }
                rLue.DataSource = _ModulKodGetirForKayitIliski;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("AD", "Modül Ad", 100));
            }
        }

        /// <summary>
        /// TDI_KOD_MUHASEBE_BELGE_TUR
        /// </summary>
        /// <param name="lue"></param
        public static void MuhasebeBelgeTurGetir(LookUpEdit lue)
        {
            MuhasebeBelgeTurGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void MuhasebeBelgeTurGetir(RepositoryItemLookUpEdit rLue)
        {
            MuhasebeBelgeTurGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void MuhasebeBelgeTurGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_MuhasebeBelgeTurGetir == null)
                {
                    _MuhasebeBelgeTurGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_MUHASEBE_BELGE_TURProvider.GetAll();
                }
                lue.DataSource = _MuhasebeBelgeTurGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "TUR";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("TUR", "Muhasebe Belge Tür", 100));
            }
        }

        /// <summary>
        /// TDI_KOD_MUHASEBE_AK
        /// </summary>
        /// <param name="lue"></param
        public static void MuhasebeDurumGetir(LookUpEdit lue)
        {
            MuhasebeDurumGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_MUHASEBE_AK
        /// </summary>
        /// <param name="lue"></param
        public static void MuhasebeDurumGetir(RepositoryItemLookUpEdit rLue)
        {
            MuhasebeDurumGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void MuhasebeDurumGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_MuhasebeDurumGetir == null)
                {
                    _MuhasebeDurumGetir = AvukatProLib2.Data.DataRepository.TDI_KOD_MUHASEBE_AKProvider.GetAll();
                }
                lue.DataSource = _MuhasebeDurumGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "AK";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("AK", "Muhasebe Durum", 100));
            }
        }

        public static void MuhasebeHareketAltKategori(RepositoryItemLookUpEdit lue)
        {
            MuhasebeHareketAltKategori_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI
        /// </summary>
        /// <param name="lue"></param
        public static void MuhasebeHareketAltKategori(LookUpEdit lue)
        {
            MuhasebeHareketAltKategori_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void MuhasebeHareketAltKategori_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_MuhasebeHareketAltKategori == null)
                {
                    _MuhasebeHareketAltKategori = AvukatProLib2.Data.DataRepository.per_TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetAll();
                }

                lue.DataSource = _MuhasebeHareketAltKategori;
                lue.NullText = "Seç";
                lue.DisplayMember = "ALT_KATEGORI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ALT_KATEGORI", "Muhasebe Alt Kategori", 100));
            }
        }

        public static void MuhasebeHareketAltKategoriAnakatGetir(RepositoryItemLookUpEdit lue)
        {
            MuhasebeHareketAltKategoriAnakatGetir_Enter(lue, EventArgs.Empty);
        }

        public static void MuhasebeHareketAltKategoriAnakatGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_MuhasebeHareketAltKat == null)
                {
                    _MuhasebeHareketAltKat = AvukatProLib2.Data.DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetAll();
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Ana_Kategori");
                dt.Columns.Add("Alt_Kategori");
                TList<TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI> ANA_KAT = new TList<TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI>();
                foreach (TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI item in _MuhasebeHareketAltKat)
                {
                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI));
                    if (item.ANA_KATEGORI_IDSource != null)
                        dt.Rows.Add(item.ID, item.ANA_KATEGORI_IDSource.ANA_KATEGORI.ToString(), item.ALT_KATEGORI);
                }

                lue.DataSource = dt;
                lue.DisplayMember = "Alt_Kategori";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("Ana_Kategori", "Ana Kategori", 100));
                lue.Columns.Add(new LookUpColumnInfo("Alt_Kategori", "Alt Kategori", 100));
            }
        }

        /// <summary>
        /// TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI tablosundan anakategori id si 6 olanlari
        /// getirir(Ücretlendirilmiþ Ýþler)
        /// </summary>
        /// <param name="lue">doldurulacak repositoryitemlookupedit</param>
        public static void MuhasebeHareketAltKategoriByAnakategoriIdAlti(RepositoryItemLookUpEdit lue)
        {
            if (_MuhasebeHareketAltKategoriByAnakategoriIdAlti == null)
            {
                _MuhasebeHareketAltKategoriByAnakategoriIdAlti = AvukatProLib2.Data.DataRepository.per_TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.Get(" ANA_KATEGORI_ID=" + 6, "ALT_KATEGORI DESC");
            }

            lue.DataSource = _MuhasebeHareketAltKategoriByAnakategoriIdAlti;

            //GetByANA_KATEGORI_ID(6);
            lue.NullText = "Seç";
            lue.DisplayMember = "ALT_KATEGORI";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ALT_KATEGORI", "Muhasebe Alt Kategori", 100));
        }

        //public static void MuhasebeHareketAltKategoriByAnakategoriIdAlti(LookUpEdit lue)
        //{
        //    MuhasebeHareketAltKategoriByAnakategoriIdAlti(lue.Properties);
        //}
        /// <summary>
        /// TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI  tablosundan anakategori id si 6 olanlari getirir
        /// </summary>
        /// <param name="lue">doldurulacak repositoryitemlookupedit</param>
        public static void MuhasebeHareketAltKategoriByAnakategoriIdAlti(RepositoryItemLookUpEdit lue, int AnakKatID)
        {
            lue.DataSource = AvukatProLib2.Data.DataRepository.per_TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.Get(" ANA_KATEGORI_ID=" + AnakKatID, "ALT_KATEGORI DESC");
            lue.NullText = "Seç";
            lue.DisplayMember = "ALT_KATEGORI";
            lue.ValueMember = "ID";
            lue.Columns.Clear();

            lue.Columns.Add(new LookUpColumnInfo("ALT_KATEGORI", "Muhasebe Alt Kategori", 100));
        }

        /// <summary>
        /// TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI tablosundan anakategori id si 6 olanlari getirir
        /// </summary>
        /// <param name="lue">doldurulacak lookup</param>
        public static void MuhasebeHareketAltKategoriByAnakategoriIdAlti(LookUpEdit lue)
        {
            lue.Properties.NullText = "Seç";
            MuhasebeHareketAltKategoriByAnakategoriIdAlti_Enter(lue, EventArgs.Empty);
        }

        public static void MuhasebeHareketAltKategoriByAnakategoriIdAlti_Enter(object sender, EventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            if (lue.Properties.DataSource == null)
            {
                if (_MuhasebeHareketAltKategoriByAnakategoriIdAlti == null)
                {
                    _MuhasebeHareketAltKategoriByAnakategoriIdAlti = AvukatProLib2.Data.DataRepository.per_TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.Get(" ANA_KATEGORI_ID=" + 6, "ALT_KATEGORI DESC");
                }
                lue.Properties.DataSource = _MuhasebeHareketAltKategoriByAnakategoriIdAlti;

                lue.Properties.DisplayMember = "ALT_KATEGORI";
                lue.Properties.ValueMember = "ID";
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.Add(new LookUpColumnInfo("ALT_KATEGORI", "Muhasebe Alt Kategori", 100));
            }
        }

        public static void MuhasebeHareketAltKategoriForGorusme(RepositoryItemLookUpEdit lue)
        {
            MuhasebeHareketAltKategoriForGorusme_Enter(lue, EventArgs.Empty);
        }

        public static void MuhasebeHareketAltKategoriForGorusme(LookUpEdit lue)
        {
            MuhasebeHareketAltKategoriForGorusme_Enter(lue, EventArgs.Empty);
        }

        public static void MuhasebeHareketAltKategoriForGorusme_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_MuhasebeHareketAltKategoriForGorusme == null)
                {
                    _MuhasebeHareketAltKategoriForGorusme = AvukatProLib2.Data.DataRepository.per_TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.Get(" GORUSME_MI = 'TRUE'", "ALT_KATEGORI DESC");
                }
                lue.DataSource = _MuhasebeHareketAltKategoriForGorusme;
                lue.NullText = "Seç";
                lue.DisplayMember = "ALT_KATEGORI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ALT_KATEGORI", "Muhasebe Alt Kategori", 100));
            }
        }

        public static void MuhasebeHareketAltKategoriGetir(RepositoryItemImageComboBox combo)
        {
            ImageList lstImg = new ImageList();

            combo.Items.AddRange(GetKategoriImages(lstImg).ToArray());
            combo.SmallImages = lstImg;
            combo.LargeImages = lstImg;
            combo.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
        }

        public static void MuhasebeHareketHareketAltKatGetir(LookUpEdit lue)
        {
            //LookUpEdit lue = (LookUpEdit)sender;
            MuhasebeHareketHareketAltKatGetir_Enter(lue, EventArgs.Empty);
        }

        public static void MuhasebeHareketHareketAltKatGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (lue.DataSource == null)
                {
                    if (_MuhasebeHareketAltKategori == null)
                    {
                        _MuhasebeHareketAltKategori = AvukatProLib2.Data.DataRepository.per_TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetAll();
                    }

                    lue.DataSource = _MuhasebeHareketAltKategori;

                    lue.DisplayMember = "ALT_KATEGORI";
                    lue.ValueMember = "ID";
                    lue.Columns.Clear();
                    lue.Columns.Add(new LookUpColumnInfo("ALT_KATEGORI", "Muhasebe Alt Kategori", 100));
                }
            }
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> MuvekkilByFoy(Av001TiBilFoyEntity foy, RepositoryItemLookUpEdit[] controls)
        {
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>();
            if (_FoyTarafGetir == null)
            {
                _FoyTarafGetir = context.per_AV001_TI_BIL_FOY_TARAFs.ToList();
            }
            List<AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF> _TarafGetirByFoy = _FoyTarafGetir.Where(item => item.ICRA_FOY_ID == foy.Id && item.TARAF_KODU == (byte)TarafKodu.Muvekkil).ToList();

            _TarafGetirByFoy.ForEach(item =>
                {
                    AvukatProLib.Arama.per_AV001_TDI_BIL_CARI carim = context.per_AV001_TDI_BIL_CARIs.SingleOrDefault(cari => item.CARI_ID == cari.ID && cari.MUVEKKIL_MI);
                    if (carim != null) cariList.Add(carim);
                });

            foreach (RepositoryItemLookUpEdit rLue in controls)
            {
                rLue.DataSource = cariList;
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.AddRange(new LookUpColumnInfo[]
                    {
                        new LookUpColumnInfo("KOD", 10, "Kod"),
                        new LookUpColumnInfo("AD", 30, "Ad")
                    });
                rLue.NullText = "Seç";
            }
            return cariList;
        }

        // return cariList;
        //}
        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> MuvekkilByFoy(AV001_TI_BIL_FOY foy, RepositoryItemLookUpEdit[] controls)
        {
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>();
            if (_TD_FoyTarafGetir == null)
            {
                _TD_FoyTarafGetir = context.per_AV001_TD_BIL_FOY_TARAFs.ToList();
            }
            List<AvukatProLib.Arama.per_AV001_TD_BIL_FOY_TARAF> _TarafGetirByFoy = _TD_FoyTarafGetir.Where(item => item.DAVA_FOY_ID == foy.ID && item.TARAF_KODU == (int)TarafKodu.Muvekkil).ToList();

            _TarafGetirByFoy.ForEach(item =>
            {
                AvukatProLib.Arama.per_AV001_TDI_BIL_CARI carim = context.per_AV001_TDI_BIL_CARIs.SingleOrDefault(cari => item.CARI_ID == cari.ID && cari.MUVEKKIL_MI);
                if (carim != null) cariList.Add(carim);
            });

            foreach (RepositoryItemLookUpEdit rLue in controls)
            {
                rLue.DataSource = cariList;
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.AddRange(new LookUpColumnInfo[]
                    {
                        new LookUpColumnInfo("KOD", 10, "Kod"),
                        new LookUpColumnInfo("AD", 30, "Ad")
                    });

                rLue.NullText = "Seç";
            }

            return cariList;
        }

        // if (taraf.CARI_ID.HasValue && taraf.TARAF_SIFAT_IDSource.HANGI_TARAF_NO ==
        // (int)IcraTarafKodu.TakipEdilen) cariList.Add(taraf.CARI_IDSource); }
        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> MuvekkilByFoy(AV001_TD_BIL_FOY foy, RepositoryItemLookUpEdit[] controls)
        {
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>();
            if (_TD_FoyTarafGetir == null)
            {
                _TD_FoyTarafGetir = context.per_AV001_TD_BIL_FOY_TARAFs.ToList();
            }
            List<AvukatProLib.Arama.per_AV001_TD_BIL_FOY_TARAF> _TarafGetirByFoy = _TD_FoyTarafGetir.Where(item => item.DAVA_FOY_ID == foy.ID && item.TARAF_KODU == (int)TarafKodu.Muvekkil).ToList();

            _TarafGetirByFoy.ForEach(item =>
            {
                AvukatProLib.Arama.per_AV001_TDI_BIL_CARI carim = context.per_AV001_TDI_BIL_CARIs.SingleOrDefault(cari => item.CARI_ID == cari.ID && cari.MUVEKKIL_MI);
                if (carim != null) cariList.Add(carim);
            });

            foreach (RepositoryItemLookUpEdit rLue in controls)
            {
                rLue.DataSource = cariList;
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.AddRange(new LookUpColumnInfo[]
                    {
                        new LookUpColumnInfo("KOD", 10, "Kod"),
                        new LookUpColumnInfo("AD", 30, "Ad")
                    });

                rLue.NullText = "Seç";
            }

            return cariList;
        }

        // }
        public static void MuvekkilByFoy(AV001_TD_BIL_HAZIRLIK kaynak, RepositoryItemLookUpEdit[] repositoryItemLookUpEdit)
        {
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>();
            if (_TD_HazirlikTarafGetir == null)
            {
                _TD_HazirlikTarafGetir = context.per_AV001_TD_BIL_HAZIRLIK_TARAFs.ToList();
            }
            List<AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_TARAF> _TarafGetirByFoy = _TD_HazirlikTarafGetir.Where(item => item.HAZIRLIK_ID == kaynak.ID && item.TARAF_KODU == (short)TarafKodu.Muvekkil).ToList();

            _TarafGetirByFoy.ForEach(item =>
            {
                AvukatProLib.Arama.per_AV001_TDI_BIL_CARI carim = context.per_AV001_TDI_BIL_CARIs.SingleOrDefault(cari => item.CARI_ID == cari.ID && cari.MUVEKKIL_MI);
                if (carim != null) cariList.Add(carim);
            });

            foreach (RepositoryItemLookUpEdit rLue in repositoryItemLookUpEdit)
            {
                rLue.DataSource = cariList;
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.AddRange(new LookUpColumnInfo[]
                    {
                        new LookUpColumnInfo("KOD", 10, "Kod"),
                        new LookUpColumnInfo("AD", 30, "Ad")
                    });

                rLue.NullText = "Seç";
            }
        }

        // else if (taraf.CARI_IDSource == null) {
        // DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(taraf, false,
        // DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT));
        public static void MuvekkilByFoy(AV001_TDI_BIL_SOZLESME kaynak, RepositoryItemLookUpEdit[] repositoryItemLookUpEdit)
        {
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>();
            if (_SozlesmeTaraf == null)
            {
                _SozlesmeTaraf = context.per_AV001_TDI_BIL_SOZLESME_TARAFs.ToList();
            }
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_SOZLESME_TARAF> sozlesmeTarafByFoy = _SozlesmeTaraf.Where(item => item.SOZLESME_ID == kaynak.ID && (item.TARAF_SIFAT == TarafSifat.ALACAKLI.ToString() || item.TARAF_SIFAT == TarafSifat.DAVALI.ToString())).ToList();

            sozlesmeTarafByFoy.ForEach(item =>
            {
                AvukatProLib.Arama.per_AV001_TDI_BIL_CARI carim = context.per_AV001_TDI_BIL_CARIs.SingleOrDefault(cari => item.CARI_ID == cari.ID && cari.MUVEKKIL_MI);
                if (carim != null) cariList.Add(carim);
            });

            foreach (RepositoryItemLookUpEdit rLue in repositoryItemLookUpEdit)
            {
                rLue.DataSource = cariList;
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.AddRange(new LookUpColumnInfo[]
                    {
                        new LookUpColumnInfo("KOD", 10, "Kod"),
                        new LookUpColumnInfo("AD", 30, "Ad")
                    });

                rLue.NullText = "Seç";
            }
        }

        // foreach (AV001_TI_BIL_FOY_TARAF taraf in foy.AV001_TI_BIL_FOY_TARAFCollection) { if
        // (taraf.IsNew) { if (taraf.TARAF_SIFAT_IDSource == null) taraf.TARAF_SIFAT_IDSource =
        // DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID(taraf.TARAF_SIFAT_ID.Value); }
        public static void MuvekkilByFoy(AV001_TDIE_BIL_PROJE foy, params RepositoryItemLookUpEdit[] controls)
        {
            if (_ProjeTarafGetir == null)
            {
                _ProjeTarafGetir = context.per_AV001_TDIE_BIL_PROJE_TARAFs.ToList();
            }

            foreach (RepositoryItemLookUpEdit rLue in controls)
            {
                rLue.DataSource = _ProjeTarafGetir.FindAll(item => item.PROJE_ID == foy.ID && item.MUVEKKIL_MI);
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "CARI_ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.AddRange(new LookUpColumnInfo[]
                    {
                        new LookUpColumnInfo("KOD", 10, "Kod"),
                        new LookUpColumnInfo("AD", 30, "Ad")
                    });

                rLue.NullText = "Seç";
            }
        }

        public static void NispiHarcKodGetir(LookUpEdit lue)
        {
            IcraNispiHarcKodGetir(lue.Properties);
        }

        public static void OdemeAlacakliTarafByFoy(AV001_TI_BIL_FOY foy, RepositoryItemLookUpEdit[] controls)
        {
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>();
            if (_FoyTarafGetir == null)
            {
                _FoyTarafGetir = context.per_AV001_TI_BIL_FOY_TARAFs.ToList();
            }
            List<AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF> _TarafGetirByFoy = _FoyTarafGetir.Where(item => item.ICRA_FOY_ID == foy.ID && item.TAKIP_EDEN_MI).ToList();

            if (_per_CariGetir == null)
            {
                _per_CariGetir = context.per_AV001_TDI_BIL_CARIs.OrderBy(item => item.AD).ToList();
            }

            _TarafGetirByFoy.ForEach(item =>
            {
                AvukatProLib.Arama.per_AV001_TDI_BIL_CARI carim = _per_CariGetir.SingleOrDefault(cari => item.CARI_ID == cari.ID);
                if (carim != null) cariList.Add(carim);
            });

            foreach (RepositoryItemLookUpEdit rLue in controls)
            {
                rLue.DataSource = cariList;
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                    {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KOD", 10, "Kod"),
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AD", 30, "Ad")
                    });

                rLue.NullText = "Seç";
            }
        }

        public static void OdemeAlacakliTarafByProje(TList<AV001_TDI_BIL_CARI> cariList, RepositoryItemLookUpEdit rLue)
        {
            TList<AV001_TDI_BIL_CARI> muvekkilList = new TList<AV001_TDI_BIL_CARI>();
            cariList.ForEach(item =>
            {
                if (item.Tag == "M" || item.MUVEKKIL_MI)
                    muvekkilList.Add(item);
            });
            rLue.DataSource = muvekkilList;
            rLue.DisplayMember = "AD";
            rLue.ValueMember = "ID";
            rLue.NullText = "Seç";
            rLue.Columns.Clear();
            rLue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                    {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KOD", 10, "Kod"),
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AD", 30, "Ad")
                    });
            rLue.NullText = "Seç";
        }

        //public static TList<AV001_TDI_BIL_CARI> GetBorcluTarafByFoy(AV001_TI_BIL_FOY foy)
        //{
        //    TList<AV001_TDI_BIL_CARI> cariList = new TList<AV001_TDI_BIL_CARI>();
        public static void OdemeBorcluTarafByFoy(AV001_TI_BIL_FOY foy, RepositoryItemLookUpEdit[] controls)
        {
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>();
            if (_FoyTarafGetir == null)
            {
                _FoyTarafGetir = context.per_AV001_TI_BIL_FOY_TARAFs.ToList();
            }
            List<AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF> _TarafGetirByFoy = _FoyTarafGetir.Where(item => item.ICRA_FOY_ID == foy.ID && !item.TAKIP_EDEN_MI).ToList();

            _TarafGetirByFoy.ForEach(item =>
            {
                AvukatProLib.Arama.per_AV001_TDI_BIL_CARI carim = context.per_AV001_TDI_BIL_CARIs.SingleOrDefault(cari => item.CARI_ID == cari.ID);
                if (carim != null) cariList.Add(carim);
            });

            foreach (RepositoryItemLookUpEdit rLue in controls)
            {
                rLue.DataSource = cariList;
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                    {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KOD", 10, "Kod"),
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AD", 30, "Ad")
                    });

                rLue.NullText = "Seç";
            }
        }

        public static void OdemeBorcluTarafByProje(TList<AV001_TDI_BIL_CARI> cariList, RepositoryItemLookUpEdit rLue)
        {
            TList<AV001_TDI_BIL_CARI> borclularList = new TList<AV001_TDI_BIL_CARI>();
            cariList.ForEach(item =>
            {
                if (item.Tag == "B" || !item.MUVEKKIL_MI)
                    borclularList.Add(item);
            });
            rLue.DataSource = borclularList;
            rLue.DisplayMember = "AD";
            rLue.ValueMember = "ID";
            rLue.NullText = "Seç";
            rLue.Columns.Clear();
            rLue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                    {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KOD", 10, "Kod"),
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AD", 30, "Ad")
                    });
            rLue.NullText = "Seç";
        }

        public static void OdemeTipiGetir(RepositoryItemLookUpEdit lue)
        {
            OdemeTipiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void OdemeTipiGetir(LookUpEdit lue)
        {
            OdemeTipiGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void OdemeTipiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_OdemeTipiGetir == null)
                    _OdemeTipiGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ODEME_TIPProvider.GetAll();//
                // AvukatProLib.Facade.TDI_KOD_ODEME_TIP.TDI_KOD_ODEME_TIPGetir();

                lue.DataSource = _OdemeTipiGetir;
                lue.ValueMember = "ID";
                lue.DisplayMember = "ODEME_TIP";
                lue.NullText = "Seç";

                LookUpColumnInfo ID = new LookUpColumnInfo("ID", 20);
                ID.Visible = false;

                LookUpColumnInfo ODEME_TIP = new LookUpColumnInfo("ODEME_TIP", 40, "Ödeme Tipi");
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { ID, ODEME_TIP });
            }
        }

        public static void OdemeYeriGetir(RepositoryItemLookUpEdit lue)
        {
            OdemeYeriGetir_Enter(lue, EventArgs.Empty);
        }

        public static void OdemeYeriGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_odemeYeriGetir == null)
                    _odemeYeriGetir = AvukatProLib2.Data.DataRepository.per_TI_KOD_ODEME_YERIProvider.GetAll();

                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ODEME_YERI", 10, "Ödeme Yeri") });
                lue.DataSource = _odemeYeriGetir;
                lue.DisplayMember = "ODEME_YERI";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        /// <summary>
        /// TDIE_KOD_OKUL
        /// </summary>
        /// <param name="lue"></param
        public static void OkulGetir(LookUpEdit lue)
        {
            OkulGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        /// <summary>
        /// TDIE_KOD_OKUL
        /// </summary>
        /// <param name="lue"></param
        public static void OkulGetir(RepositoryItemLookUpEdit rLue)
        {
            OkulGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void OkulGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_OkulGetir == null)
                {
                    _OkulGetir = AvukatProLib2.Data.DataRepository.per_TDIE_KOD_OKULProvider.GetAll();
                }
                lue.DataSource = _OkulGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "OKUL";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("OKUL", "Okul", 100));
            }
        }

        /// <summary>
        /// AV001_TDI_BIL_FOY_ORTAKLIK
        /// </summary>
        /// <param name="lue"></param
        public static void OrtaklikFoyGetir(LookUpEdit lue)
        {
            OrtaklikFoyGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void OrtaklikFoyGetir(RepositoryItemLookUpEdit rLue)
        {
            OrtaklikFoyGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void OrtaklikFoyGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_OrtaklikFoyGetir == null)
                {
                    _OrtaklikFoyGetir = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_FOY_ORTAKLIKProvider.GetAll();
                }
                rLue.DataSource = _OrtaklikFoyGetir;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "ORTAKLIK_NO";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("ORTAKLIK_NO", "Ortaklýk No", 100));
            }
        }

        public static void OzelKodGetir(LookUpEdit lue)
        {
            OzelKodGetir_Enter(lue, EventArgs.Empty);
        }

        public static void OzelKodGetir(RepositoryItemLookUpEdit lue)
        {
            OzelKodGetir_Enter(lue, EventArgs.Empty);
        }

        public static void OzelKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_OzelKodGetir == null)
                {
                    _OzelKodGetir = AvukatProLib2.Data.DataRepository.per_AV001_TDIE_KOD_OZEL_KODProvider.GetAll();
                }
                lue.DataSource = _OzelKodGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "KOD";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("KOD", "Özel Kod", 100));
            }
        }

        /// <summary>
        /// TDI_KOD_OZEL_TUTAR_KONU
        /// </summary>
        /// <param name="lue"></param>
        public static void OzelTutarkonuGetir(RepositoryItemLookUpEdit lue)
        {
            OzelTutarkonuGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_OZEL_TUTAR_KONU
        /// </summary>
        /// <param name="lue"></param
        public static void OzelTutarkonuGetir(LookUpEdit lue)
        {
            OzelTutarkonuGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void OzelTutarkonuGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            //if (lue.DataSource == null)
            //{
            //if (_OzelTutarkonuGetir == null)
            //{
            _OzelTutarkonuGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_OZEL_TUTAR_KONUProvider.GetAll();
            //}
            lue.DataSource = _OzelTutarkonuGetir;
            lue.NullText = "Seç";
            lue.DisplayMember = "KONU";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("KONU", "Özel Tutar Konu", 100));
            //}
        }

        public static void ParaBicimiAyarla(RepositoryItemSpinEdit rud)
        {
            rud.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            rud.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            rud.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            rud.EditFormat.FormatString = "###,###,###,###,##0.00";
        }

        public static void perCariAvukatGetir(RepositoryItemLookUpEdit lue)
        {
            perCariAvukatGetir_Enter(lue, EventArgs.Empty);
        }

        public static void perCariAvukatGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_perCariAvukatGetir == null)
                {
                    if (_per_CariGetir != null)
                        _perCariAvukatGetir = _per_CariGetir.FindAll(item => item.AVUKAT_MI == true);
                    else
                    {
                        _perCariAvukatGetir = context.per_AV001_TDI_BIL_CARIs.Where(vi => vi.AVUKAT_MI).ToList();
                    }
                }

                lue.DataSource = _perCariAvukatGetir;

                //Get("  AVUKAT_MI = 'TRUE'", "AD DESC");
                //Find("AVUKAT_MI='True'");
                lue.NullText = "Seç";
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod"), new LookUpColumnInfo("AD", 30, "Ad") });
            }
        }

        public static void perCariAvukatGetirRefresh(RepositoryItemLookUpEdit lue)
        {
            //ToDo : viev e çevrilecek
            perCariAvukatGetirRefresh_Enter(lue, EventArgs.Empty);
        }

        public static void perCariAvukatGetirRefresh_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_per_CariGetir != null)
                    _perCariAvukatGetir = _per_CariGetir.FindAll(item => item.AVUKAT_MI == true);
                else
                {
                    _perCariAvukatGetir = context.per_AV001_TDI_BIL_CARIs.Where(vi => vi.AVUKAT_MI).ToList();
                }

                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod"), new LookUpColumnInfo("AD", 30, "Ad") });

                lue.DataSource = _perCariAvukatGetir;
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void perCariGetir(LookUpEdit lue)
        {
            perCariGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void perCariGetir(RepositoryItemLookUpEdit lue)
        {
            //ToDo : viev e çevrilecek
            perCariGetir_Enter(lue, EventArgs.Empty);
        }

        public static void perCariGetir(LookUpEdit[] lues)
        {
            foreach (var item in lues)
            {
                perCariGetir_Enter(item.Properties, EventArgs.Empty);
            }
        }

        public static void perCariGetir_Enter(object sender, EventArgs e)
        {
            try
            {
                RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
                //if (lue.DataSource == null)
                //{
                //if (_per_CariGetir == null)
                //{
                //    _per_CariGetir = context.per_AV001_TDI_BIL_CARIs.OrderBy(item => item.AD).ToList();
                //}
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod"), new LookUpColumnInfo("AD", 30, "Ad") });

                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                lue.DataSource = cn.GetDataTable("select ID, KOD, AD from per_AV001_TDI_BIL_CARI(nolock) order by AD");
                //lue.DataSource = _per_CariGetir;
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                //}
            }
            catch { ;}
        }

        public static void perCariGetir_Enter2(object sender, EventArgs e)
        {
            try
            {
                RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
                if (lue.DataSource == null)
                {
                    if (_per_CariGetir == null)
                    {
                        _per_CariGetir = context.per_AV001_TDI_BIL_CARIs.OrderBy(item => item.AD).ToList();
                    }

                    lue.Columns.Clear();
                    lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod"), new LookUpColumnInfo("AD", 30, "Ad") });

                    //ABSqlConnection cn = new ABSqlConnection();
                    //cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                    //lue.DataSource = cn.GetDataTable("select ID, KOD, AD from per_AV001_TDI_BIL_CARI(nolock) order by AD");
                    lue.DataSource = _per_CariGetir;
                    lue.DisplayMember = "AD";
                    lue.ValueMember = "ID";
                    lue.NullText = "Seç";
                }
            }
            catch { ;}
        }

        public static void perCariGetir2(RepositoryItemLookUpEdit lue)
        {
            //ToDo : viev e çevrilecek
            perCariGetir_Enter2(lue, EventArgs.Empty);
        }

        //Kurumsal giriþ ekranýndaki cari lookupýnda aþaðýdaki bilgilerin görünmesini saðlýyor.
        public static void perCariGetirKimlikIletisim(LookUpEdit lue)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.DataSource = context.per_CariKimlikIletisimBilgileris.OrderBy(vi => vi.AD).ToList();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("MUSTERI_NO", 0, "Müþteri No"), new LookUpColumnInfo("AD", 0, "Ad"), new LookUpColumnInfo("VERGI_NO", 0, "Vergi Numarasý"), new LookUpColumnInfo("TC_KIMLIK_NO", 0, "TC Kimlik No") });
            lue.Bounds = new Rectangle(10, 40, 300, 20);
            lue.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            lue.Properties.DisplayMember = "AD";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
        }

        public static void perCariGetirKimlikIletisim(GridLookUpEdit glue)
        {
            glue.Properties.View.Columns.Clear();

            GridColumn gColID = new GridColumn();
            gColID.FieldName = "ID";
            gColID.Caption = "ID";
            gColID.VisibleIndex = -1;
            glue.Properties.View.Columns.Add(gColID);

            GridColumn gColAd = new GridColumn();
            gColAd.FieldName = "AD";
            gColAd.Caption = "Ad";
            gColAd.VisibleIndex = 0;
            glue.Properties.View.Columns.Add(gColAd);

            GridColumn gColMusteriNo = new GridColumn();
            gColMusteriNo.FieldName = "MUSTERI_NO";
            gColMusteriNo.Caption = "Müþteri No";
            gColMusteriNo.VisibleIndex = 1;
            glue.Properties.View.Columns.Add(gColMusteriNo);

            GridColumn gColVergiNo = new GridColumn();
            gColVergiNo.FieldName = "VERGI_NO";
            gColVergiNo.Caption = "Vergi No";
            gColVergiNo.VisibleIndex = 2;
            glue.Properties.View.Columns.Add(gColVergiNo);

            GridColumn gColTCKimlikNo = new GridColumn();
            gColTCKimlikNo.FieldName = "TC_KIMLIK_NO";
            gColTCKimlikNo.Caption = "TC Kimlik No";
            gColTCKimlikNo.VisibleIndex = 3;
            glue.Properties.View.Columns.Add(gColTCKimlikNo);

            GridColumn gcolEskiUnvan = new GridColumn();
            gcolEskiUnvan.FieldName = "ESKI_UNVAN";
            gcolEskiUnvan.Caption = "Eski Ünvan";
            gcolEskiUnvan.VisibleIndex = 3;
            glue.Properties.View.Columns.Add(gcolEskiUnvan);

            glue.Properties.DataSource = context.per_CariKimlikIletisimBilgileris.OrderBy(vi => vi.AD).ToList(); ;
            glue.Properties.ValueMember = "ID";
            glue.Properties.DisplayMember = "AD";
            glue.Properties.NullText = "Seç";

            glue.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
        }

        public static void perCariGetirRefresh(RepositoryItemLookUpEdit lue)
        {
            //ToDo : viev e çevrilecek
            perCariGetirRefresh_Enter(lue, EventArgs.Empty);
        }

        public static void perCariGetirRefresh_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                _per_CariGetir = context.per_AV001_TDI_BIL_CARIs.OrderBy(item => item.AD).ToList();

                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod"), new LookUpColumnInfo("AD", 30, "Ad") });

                lue.DataSource = _per_CariGetir;
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_I> PerIsleriGetir()
        {
            if (_per_AV001_TDI_BIL_IS == null)
                _per_AV001_TDI_BIL_IS = context.per_AV001_TDI_BIL_Is.ToList();
            return _per_AV001_TDI_BIL_IS;
        }

        public static VList<per_VDI_CARI_IS_TARAF> PerIsTaraflariGetir()
        {
            if (_per_VDI_CARI_IS_TARAFGetir == null)
                _per_VDI_CARI_IS_TARAFGetir = DataRepository.per_VDI_CARI_IS_TARAFProvider.GetAll();
            return _per_VDI_CARI_IS_TARAFGetir;
        }

        public static void perSorumluAvukatGetir(RepositoryItemLookUpEdit lue)
        {
            if (per_TSorumluAvukatGetir == null)
            {
                if (_per_CariGetir != null)
                    per_TSorumluAvukatGetir = _per_CariGetir.FindAll(item => item.AVUKAT_MI == true && item.FIRMA_MI == false && item.PERSONEL_MI == true);
                else
                {
                    per_TSorumluAvukatGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.Where(item => item.AVUKAT_MI == true && item.FIRMA_MI == false && item.PERSONEL_MI == true).ToList();
                }
            }

            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 20, "Kod"), new LookUpColumnInfo("AD", 20, "Ad") });
            lue.DataSource = per_TSorumluAvukatGetir;

            //Get(" PERSONEL_MI='TRUE' AND FIRMA_MI='FALSE'", "AD DESC");
            //Find(string.Format("PERSONEL_MI='{0}' AND FIRMA_MI='{1}'", "TRUE", "FALSE"));
            lue.DisplayMember = "AD";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_IS_TARAF> PerTdiBilIsTaraflariGetir()
        {
            if (_per_AV001_TDI_BIL_IS_TARAF == null)
                _per_AV001_TDI_BIL_IS_TARAF = context.per_AV001_TDI_BIL_IS_TARAFs.ToList();
            return _per_AV001_TDI_BIL_IS_TARAF;
        }

        public static VList<per_TDI_KOD_TEBLIGAT_SABLON> PerTebligatSablonGetir()
        {
            if (_per_TDI_KOD_TEBLIGAT_SABLON == null)
                _per_TDI_KOD_TEBLIGAT_SABLON = DataRepository.per_TDI_KOD_TEBLIGAT_SABLONProvider.GetAll();
            return _per_TDI_KOD_TEBLIGAT_SABLON;
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_TEMINAT_MEKTUP> perTeminatMektupGetir()
        {
            if (_perTeminatMektupGetir == null) _perTeminatMektupGetir = context.per_AV001_TDI_BIL_TEMINAT_MEKTUPs.ToList();
            return _perTeminatMektupGetir;
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_TEMINAT_MEKTUP> perTeminatMektupGetirByfoy(int foyId)
        {
            if (_perTeminatMektupGetir != null) return _perTeminatMektupGetir.FindAll(item => item.ICRA_FOY_ID == foyId);
            return context.per_AV001_TDI_BIL_TEMINAT_MEKTUPs.Where(item => item.ICRA_FOY_ID == foyId).ToList();
        }

        public static void PoliceBransGetir(LookUpEdit lue)
        {
            PoliceBransGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_POLICE_BRANS
        /// </summary>
        /// <param name="lue"></param
        public static void PoliceBransGetir(RepositoryItemLookUpEdit rLue)
        {
            PoliceBransGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void PoliceBransGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_PoliceBransGetir == null)
                {
                    _PoliceBransGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_POLICE_BRANSProvider.GetAll();
                }
                lue.DataSource = _PoliceBransGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "POLICE_BRANS";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("POLICE_BRANS", "Poliçe Branþlarý", 100));
            }
        }

        public static void ProjeAdGetir(RepositoryItemLookUpEdit rLue)
        {
            ProjeAdGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void ProjeAdGetir(LookUpEdit lue)
        {
            ProjeAdGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void ProjeAdGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_ProjeAdGetir == null)
                {
                    if (AvukatProLib.Kimlik.SubeKodu != 2)
                        _ProjeAdGetir = context.per_AV001_TDIE_BIL_PROJEs.Where(item => item.SUBE_KOD_ID == AvukatProLib.Kimlik.SubeKodu).ToList();
                    else
                        _ProjeAdGetir = context.per_AV001_TDIE_BIL_PROJEs.ToList();
                }
                rLue.DataSource = _ProjeAdGetir.OrderBy(vi => vi.ADI).ToList();
                rLue.DisplayMember = "ADI";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("ADI", 30, "Proje Adý"));
            }
        }

        //TDI_KOD_IS_MADDE_KALEM
        //TODO : Katmandan Sonra Açýlacak
        //public static void IsMaddeKalemGetir(RepositoryItemLookUpEdit rLue)
        //{
        //    rLue.DataSource = DataRepository.TDI_KOD_IS_MADDE_KALEMProvider.GetAll();
        //    rLue.DisplayMember = "MADDE_KALEM";
        //    rLue.ValueMember = "ID";
        //    rLue.NullText = "Seç";
        //    rLue.Columns.Clear();
        //    rLue.Columns.Add(new LookUpColumnInfo("MADDE_KALEM", 30, "Ýþ Madde Kalem"));
        //}
        //public static void IsMaddeKalemGetir(LookUpEdit lue)
        //{
        //    IsMaddeKalemGetir(lue.Properties);
        //}
        //AV001_TDIE_BIL_PROJE
        public static void ProjeAdGetirRefresh(LookUpEdit lue)
        {
            _ProjeAdGetir = null;
            ProjeAdGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void ProjeAdGetirYenile(LookUpEdit rLue)
        {
            _ProjeAdGetir = null;
            ProjeAdGetir_Enter(rLue.Properties, EventArgs.Empty);
        }

        public static List<AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE_GENEL_NOT> ProjeGenelNotGetir(int projeId)
        {
            return context.per_AV001_TDIE_BIL_PROJE_GENEL_NOTs.Where(item => item.PROJE_ID == projeId).ToList();
        }

        public static TList<AV001_TDIE_BIL_PROJE_SORUMLU> ProjeSorumluGetir(int projeID)
        {
            return DataRepository.AV001_TDIE_BIL_PROJE_SORUMLUProvider.GetByPROJE_ID(projeID);
        }

        public static void ProjeTarafGetir(AV001_TDIE_BIL_PROJE proje, params RepositoryItemLookUpEdit[] controls)
        {
            if (_ProjeTarafGetir == null)
            {
                _ProjeTarafGetir = context.per_AV001_TDIE_BIL_PROJE_TARAFs.OrderBy(vi => vi.AD).ToList();
            }
            foreach (RepositoryItemLookUpEdit lue in controls)
            {
                lue.DataSource = _ProjeTarafGetir.FindAll(item => item.PROJE_ID == proje.ID);
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";

                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[]
                {
                    new LookUpColumnInfo("KOD", 10, "Kod"),
                    new LookUpColumnInfo("AD", 30, "Ad") }
                );
            }
        }

        public static VList<R_BIRLESIK_TAKIPLER_TEMINAT_MEKTUP> R_BIRLESIK_TAKIPLER_TEMINAT_MEKTUPGetir()
        {
            if (_R_BIRLESIK_TAKIPLER_TEMINAT_MEKTUPGetir == null) _R_BIRLESIK_TAKIPLER_TEMINAT_MEKTUPGetir = DataRepository.R_BIRLESIK_TAKIPLER_TEMINAT_MEKTUPProvider.GetAll();
            return _R_BIRLESIK_TAKIPLER_TEMINAT_MEKTUPGetir;
        }

        public static List<AvukatProLib.Arama.R_CARI_HESAP_DETAYLI> R_CARI_HESAP_DETAYLIGetir()
        {
            if (_R_CARI_HESAP_DETAYLIGetir == null)
                _R_CARI_HESAP_DETAYLIGetir = context.R_CARI_HESAP_DETAYLIs.ToList();
            return _R_CARI_HESAP_DETAYLIGetir;
        }

        /// <summary>
        /// AV001_TDI_BIL_FOY_ORTAKLIK
        /// </summary>
        ///
        /// <param name="lue"></param <summary> TDI_KOD_REHIN_CINS </summary> <param name="rLue"></param>
        public static void RehinCinsGetir(RepositoryItemLookUpEdit rLue)
        {
            RehinCinsGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void RehinCinsGetir(LookUpEdit lue)
        {
            RehinCinsGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void RehinCinsGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_RehinCinsGetir == null)
                {
                    _RehinCinsGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_REHIN_CINSProvider.GetAll();
                }
                lue.DataSource = _RehinCinsGetir;
                lue.DisplayMember = "REHIN_CINS";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("REHIN_CINS", "Rehin Cins", 40));
            }
        }

        public static void RehinDurumGetir(RepositoryItemLookUpEdit rLue)
        {
            RehinDurumGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void RehinDurumGetir(LookUpEdit lue)
        {
            RehinDurumGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void RehinDurumGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_RehinDurumGetir == null)
                {
                    _RehinDurumGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_REHIN_DURUMProvider.GetAll();
                }
                lue.DataSource = _RehinDurumGetir;
                lue.DisplayMember = "REHIN_DURUM";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("REHIN_DURUM", "Rehin Durum", 40));
            }
        }

        public static void RehinHarcIstisnaBelge(RepositoryItemLookUpEdit rLue)
        {
            RehinHarcIstisnaBelge_Enter(rLue, EventArgs.Empty);
        }

        public static void RehinHarcIstisnaBelge(LookUpEdit lue)
        {
            RehinHarcIstisnaBelge_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void RehinHarcIstisnaBelge_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_RehinHarcIstisnaBelge == null)
                {
                    _RehinHarcIstisnaBelge = AvukatProLib2.Data.DataRepository.per_TDI_KOD_REHIN_HARC_ISTISNA_BELGEProvider.GetAll();
                }
                lue.DataSource = _RehinHarcIstisnaBelge;
                lue.NullText = "Seç";
                lue.DisplayMember = "ISTISNA_BELGE";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ISTISNA_BELGE", "Harc Istisna Belge", 40));
            }
        }

        /// <summary>
        /// TDI_KOD_REHIN_SICIL_TIP
        /// </summary>
        /// <param name="rLue"></param>
        public static void RehinSiciltipGetir(RepositoryItemLookUpEdit rLue)
        {
            RehinSiciltipGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void RehinSiciltipGetir(LookUpEdit lue)
        {
            RehinSiciltipGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void RehinSiciltipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_RehinSiciltipGetir == null)
                {
                    _RehinSiciltipGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_REHIN_SICIL_TIPProvider.GetAll();
                }
                lue.DataSource = _RehinSiciltipGetir;
                lue.DisplayMember = "SICIL_TIP";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("SICIL_TIP", "Rehin Sicil Tip", 40));
            }
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_RUCU> RucuGetir()
        {
            if (_RucuGetir == null) _RucuGetir = context.per_AV001_TDI_BIL_RUCUs.ToList();
            return _RucuGetir;
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_RUCU> RucuGetirBySube(int subeKodId)
        {
            if (_RucuGetir != null) return _RucuGetir.FindAll(item => item.SUBE_KOD_ID == subeKodId);
            return context.per_AV001_TDI_BIL_RUCUs.Where(item => item.SUBE_KOD_ID == subeKodId).ToList();
        }

        public static void RucuKaynakKodGetir(RepositoryItemLookUpEdit rLue)
        {
            RucuKaynakKodGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void RucuKaynakKodGetir(LookUpEdit lue)
        {
            RucuKaynakKodGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void RucuKaynakKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_RucuKaynakKodGetir == null)
                {
                    _RucuKaynakKodGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_RUCU_KAYNAKProvider.GetAll();
                }
                rLue.DataSource = _RucuKaynakKodGetir;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "RUCU_KAYNAK";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("RUCU_KAYNAK", "Rücu Kaynak", 100));
            }
        }

        public static void RucuNoGetir(RepositoryItemLookUpEdit rLue, int? IcraFoyID)
        {
            rLue.DisplayMember = "DOSYA_NO";
            rLue.ValueMember = "ID";
            rLue.DataSource = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_RUCUProvider.GetByICRA_FOY_ID(IcraFoyID);
            rLue.Columns.Clear();
            rLue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DOSYA_NO"));
            rLue.NullText = "Rücu No Seç";
        }

        public static void SablonAltKategoriGetir(RepositoryItemLookUpEdit rLue)
        {
            SablonAltKategoriGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void SablonAltKategoriGetir(LookUpEdit lue)
        {
            SablonAltKategoriGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SablonAltKategoriGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_SablonAltKategoriGetir == null)
                {
                    _SablonAltKategoriGetir = AvukatProLib2.Data.DataRepository.per_TDIE_KOD_SABLON_ALT_KATEGORIProvider.GetAll();
                }
                lue.DataSource = _SablonAltKategoriGetir;
                lue.DisplayMember = "ADI";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ADI", "Sablon Alt Kategori", 40));
            }
        }

        public static List<AvukatProLib.Arama.VDIE_BIL_SABLON_DEGISKENLER> SablonDegiskenGetir()
        {
            if (_SablonDegiskenler == null)
                _SablonDegiskenler = context.VDIE_BIL_SABLON_DEGISKENLERs.ToList();
            return _SablonDegiskenler;
        }

        public static void SablonDegiskenGetir(RepositoryItemLookUpEdit rLue)
        {
            SablonDegiskenGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void SablonDegiskenGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                rLue.DataSource = SablonDegiskenGetir();
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AD"));
            }
        }

        public static void SablonRaporGetir(LookUpEdit lue)
        {
            SablonRaporGetir(lue.Properties);
        }

        public static void SablonRaporGetir(RepositoryItemLookUpEdit rLue)
        {
            if (_SablonRaporGetir == null)
            {
                if (CodeInfo<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>.ListeVarmi(typeof(AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)))
                    _SablonRaporGetir = CodeInfo<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>.ListeGetir(typeof(AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)) as List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>;
                else
                {
                    _SablonRaporGetir = BelgeUtil.Inits.context.VDIE_BIL_SABLON_RAPORs.ToList();
                    CodeInfo<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>.ListeKaydet(_SablonRaporGetir, typeof(AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR));
                }
            }
            rLue.DataSource = _SablonRaporGetir;
            rLue.NullText = "Seç";
            rLue.DisplayMember = "AD";
            rLue.ValueMember = "ID";
            rLue.Columns.Clear();
            rLue.Columns.Add(new LookUpColumnInfo("AD", "Sablon", 100));
        }

        public static List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> SablonRaporGetir(int modulId)
        {
            return context.VDIE_BIL_SABLON_RAPORs.Where(vi => vi.MODUL_ID == modulId || !vi.MODUL_ID.HasValue).ToList();
        }

        public static void SablonRaporGetir(GridLookUpEdit rLue, int modulId)
        {
            rLue.Properties.DataSource = SablonRaporGetir(modulId);
            rLue.Properties.NullText = "Seç";
            rLue.Properties.DisplayMember = "AD";
            rLue.Properties.ValueMember = "ID";
            rLue.Properties.View.Columns.Clear();

            GridColumn clmSec = new GridColumn();
            clmSec.ColumnEdit = new RepositoryItemCheckEdit();
            clmSec.FieldName = "IsSelected";
            clmSec.Caption = "Seç";
            clmSec.Width = 25;
            clmSec.Visible = true;
            clmSec.VisibleIndex = 0;

            GridColumn clmAd = new GridColumn();
            clmAd.FieldName = "AD";
            clmAd.Caption = "Þablon";
            clmAd.Width = 100;
            clmAd.Visible = true;
            clmAd.VisibleIndex = 1;

            rLue.Properties.View.Columns.Add(clmSec);
            rLue.Properties.View.Columns.Add(clmAd);
        }

        public static void SablonRaporGetirOtomatik(LookUpEdit lue)
        {
            SablonRaporGetirOtomatik_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SablonRaporGetirOtomatik(RepositoryItemLookUpEdit rLue)
        {
            SablonRaporGetirOtomatik_Enter(rLue, EventArgs.Empty);
        }

        public static void SablonRaporGetirOtomatik_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_SablonRaporGetir != null)
                {
                    _SablonRaporGetirOtomatik = _SablonRaporGetir.FindAll(item => item.DEGISKENI_VARMI == true);
                }
                else
                    _SablonRaporGetirOtomatik = BelgeUtil.Inits.context.VDIE_BIL_SABLON_RAPORs.Where(item => item.DEGISKENI_VARMI == true).ToList();
                rLue.DataSource = _SablonRaporGetirOtomatik;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "AD";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("AD", "Sablon", 100));
            }
        }

        public static void SablonRaporTipGetir(RepositoryItemLookUpEdit rLue)
        {
            SablonRaporTipGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void SablonRaporTipGetir(LookUpEdit lue)
        {
            SablonRaporTipGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SablonRaporTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_SablonRaporTipGetir == null)
                {
                    _SablonRaporTipGetir = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_RAPOR_TIPProvider.GetAll();
                }
                lue.DataSource = _SablonRaporTipGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("AD", "Sablon Rapor Ad", 40));
            }
        }

        public static void SahisDurumGetir(RepositoryItemLookUpEdit rLue)
        {
            SahisDurumGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void SahisDurumGetir(LookUpEdit lue)
        {
            SahisDurumGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SahisDurumGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_SahisDurumGetir == null)
                {
                    _SahisDurumGetir = DataRepository.per_AV001_TDI_KOD_SAHIS_DURUMProvider.GetAll();
                }
                lue.DataSource = _SahisDurumGetir;
                lue.DisplayMember = "SAHIS_DURUM";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("SAHIS_DURUM", 30, "Þahýs Durum"));
            }
        }

        public static void SatisIlanSekliGetir(RepositoryItemLookUpEdit lue)
        {
            SatisIlanSekliGetir_Enter(lue, EventArgs.Empty);
        }

        public static void SatisIlanSekliGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("SatisIlanSekli");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.SatisIlanSekli tipi in Enum.GetValues(typeof(AvukatProLib.Extras.SatisIlanSekli)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Satýþ Ýlan Þekli"));
            }
        }

        public static void SatisIstemeSekliGetir(RepositoryItemLookUpEdit lue)
        {
            SatisIstemeSekliGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TI_KOD_SATIS_ISTEME_SEKIL
        /// </summary>
        /// <param name="lue"></param
        public static void SatisIstemeSekliGetir(LookUpEdit lue)
        {
            SatisIstemeSekliGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SatisIstemeSekliGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_SatisIstemeSekliGetir == null)
                {
                    _SatisIstemeSekliGetir = AvukatProLib2.Data.DataRepository.per_TI_KOD_SATIS_ISTEME_SEKILProvider.GetAll();
                }
                lue.DataSource = _SatisIstemeSekliGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "SATIS_SEKLI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("SATIS_SEKLI", "Þatýþ Þekli", 100));
            }
        }

        public static void SatisTuruGetir(RepositoryItemLookUpEdit lue)
        {
            SatisTuruGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TI_KOD_SATIS_TURU
        /// </summary>
        /// <param name="lue"></param
        public static void SatisTuruGetir(LookUpEdit lue)
        {
            SatisTuruGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SatisTuruGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_SatisTuruGetir == null)
                {
                    _SatisTuruGetir = AvukatProLib2.Data.DataRepository.per_TI_KOD_SATIS_TURUProvider.GetAll();
                }
                lue.DataSource = _SatisTuruGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "TUR";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("TUR", "Þatýþ Türü", 100));
            }
        }

        public static void SavcilikHukumGetir(RepositoryItemLookUpEdit rLue)
        {
            SavcilikHukumGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void SavcilikHukumGetir(LookUpEdit lue)
        {
            SavcilikHukumGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SavcilikHukumGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_SavcilikHukumGetir == null)
                {
                    _SavcilikHukumGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_SAVCILIK_HUKUMProvider.GetAll();
                }
                lue.DataSource = _SavcilikHukumGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "SAVCILIK_HUKUM";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("SAVCILIK_HUKUM", "Savcýlýk Hüküm", 40));
            }
        }

        //Segmnnetin getiriesi için yazýlmýlþtýr
        public static void SegmentGetir(RepositoryItemLookUpEdit lue)
        {
            SegmentGetir_Enter(lue, EventArgs.Empty);
        }

        public static void SegmentGetir(LookUpEdit lue)
        {
            SegmentGetir_Enter(lue, EventArgs.Empty);
        }

        public static void SegmentGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (_SegmentGetir == null)
            {
                if (CodeInfo<per_TDI_KOD_SEGMENT>.ListeVarmi(typeof(per_TDI_KOD_SEGMENT)))
                    _SegmentGetir = CodeInfo<per_TDI_KOD_SEGMENT>.ListeGetir(typeof(per_TDI_KOD_SEGMENT)) as VList<per_TDI_KOD_SEGMENT>;
                else
                {
                    _SegmentGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_SEGMENTProvider.GetAll();
                    CodeInfo<per_TDI_KOD_SEGMENT>.ListeKaydet(_SegmentGetir, typeof(per_TDI_KOD_SEGMENT));
                }
            }
            if (lue.DataSource == null)
            {
                lue.DataSource = _SegmentGetir;
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("SEGMENT", 30, "Bölüm") });
                lue.DisplayMember = "SEGMENT";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void SektorKodGetir(RepositoryItemLookUpEdit rLue)
        {
            SektorKodGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void SektorKodGetir(LookUpEdit lue)
        {
            SektorKodGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SektorKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_SektorKodGetir == null)
                {
                    _SektorKodGetir = AvukatProLib2.Data.DataRepository.per_TDIE_KOD_SEKTORProvider.GetAll();
                }
                lue.DataSource = _SektorKodGetir;
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("AD", "Sektör Kod", 40));
            }
        }

        /// <summary>
        /// TDI_KOD_SEMT
        /// </summary>
        /// <param name="lue"></param>
        public static void SemtGetir(RepositoryItemLookUpEdit lue)
        {
            SemtGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_SEMT
        /// </summary>
        /// <param name="lue"></param
        public static void SemtGetir(LookUpEdit lue)
        {
            SemtGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SemtGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_SemtGetir == null)
                {
                    _SemtGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_SEMTProvider.GetAll();
                }

                lue.DataSource = _SemtGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "SEMT";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("SEMT", "Semt", 100));
            }
        }

        public static void SemtGetirIleGore(LookUpEdit lue, int ilceId)
        {
            lue.Properties.NullText = "Seç";
            SemtGetirIleGore_Enter(lue, EventArgs.Empty);
            lue.Tag = ilceId;
        }

        public static void SemtGetirIleGore_Enter(object sender, EventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            if (lue.Properties.DataSource == null)
            {
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("SEMT", 10, "Semt") });
                int ilceID = Convert.ToInt32(lue.Tag);
                lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.per_TDI_KOD_SEMTProvider.Get("ILCE_ID=" + ilceID, "SEMT DESC");

                // GetByILCE_ID(ilceID);
                lue.Properties.DisplayMember = "SEMT";
                lue.Properties.ValueMember = "ID";
            }
        }

        public static void SerbestBirakilmaNedenGetir(RepositoryItemLookUpEdit rLue)
        {
            SerbestBirakilmaNedenGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void SerbestBirakilmaNedenGetir(LookUpEdit lue)
        {
            SerbestBirakilmaNedenGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SerbestBirakilmaNedenGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_SerbestBirakilmaNedenGetir == null)
                {
                    _SerbestBirakilmaNedenGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_SERBEST_BIRAKILMA_NEDENProvider.GetAll();
                }
                lue.DataSource = _SerbestBirakilmaNedenGetir;
                lue.DisplayMember = "SERBEST_BIRAKILMA_NEDEN";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("SERBEST_BIRAKILMA_NEDEN", "Serbest Býrakýlma Nedeni", 40));
            }
        }

        public static void SetBuyukHarfRepositoryItemTextEdit_Validating(object sender, CancelEventArgs e)
        {
            var tEdit = sender as TextEdit;
            string yeni = tEdit.Text;
            string degisen = GetBuyukHarf(yeni);
            tEdit.Text = degisen;
        }

        public static void SicilTipGetir(RepositoryItemLookUpEdit lue)
        {
            SicilTipGetir_Enter(lue, EventArgs.Empty);
        }

        public static void SicilTipGetir(LookUpEdit lue)
        {
            SicilTipGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SicilTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if ((lue.DataSource == null))
            {
                if (_SicilTipGetir == null)
                    _SicilTipGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_REHIN_SICIL_TIPProvider.GetAll();//

                lue.DataSource = _SicilTipGetir;
                lue.ValueMember = "ID";
                lue.DisplayMember = "SICIL_TIP";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("SICIL_TIP", 20, "Sicil Tipi"));
            }
        }

        ///<summary>
        /// TDIE_KOD_ASAMA
        /// </summary>
        /// <param name="rLue"></param>
        public static void SikayetAsamaGetir(LookUpEdit lue)
        {
            SikayetAsamaGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SikayetAsamaGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_AsamaKodGetir != null)
                {
                    lue.DataSource = _AsamaKodGetir.Where(item => item.ASAMA_MODUL_ID == 3).OrderByDescending(item => item.ASAMA_ADI);
                }
                else
                    lue.DataSource = DataRepository.per_TDIE_KOD_ASAMAProvider.Get(" ASAMA_MODUL_ID=" + 3, "ASAMA_ADI DESC");
                lue.NullText = "Seç";
                lue.DisplayMember = "ASAMA_ADI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ASAMA_ADI", "Aþama", 100));
            }
        }

        public static void SikayetKategoriGetir(RepositoryItemLookUpEdit rLue)
        {
            SikayetKategoriGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void SikayetKategoriGetir(LookUpEdit lue)
        {
            SikayetKategoriGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SikayetKategoriGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_SikayetKategoriGetir == null)
                {
                    _SikayetKategoriGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_SIKAYET_KATEGORIProvider.GetAll();
                }
                rLue.DataSource = _SikayetKategoriGetir;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "TIP";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("TIP", "Þikayet Kategorisi", 100));
            }
        }

        public static void SikayetKonuDavaTalepCezaGetir(RepositoryItemLookUpEdit lue, string c)
        {
            if (lue.DataSource == null)
            {
                if (_DavaTalepGetir != null)
                {
                    _SikayetKonuDavaTalepCezaGetir = new VList<per_TD_KOD_DAVA_TALEP>(_DavaTalepGetir.Where(item => item.ADLI_BIRIM_BOLUM_ID == 1).OrderByDescending(item => item.DAVA_TALEP).ToList());
                }
                else if (_SikayetKonuDavaTalepCezaGetir == null)
                {
                    _SikayetKonuDavaTalepCezaGetir = DataRepository.per_TD_KOD_DAVA_TALEPProvider.Get(" ADLI_BIRIM_BOLUM_ID='1'", "DAVA_TALEP DESC");
                }

                lue.DataSource = _SikayetKonuDavaTalepCezaGetir;

                //Find("ADLI_BIRIM_BOLUM_ID='1'");
                lue.NullText = "Seç";
                lue.DisplayMember = "DAVA_TALEP";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("DAVA_TALEP", "Þikayet Konu", 100));
            }
        }

        public static void SikayetKonuDavaTalepCezaGetir(LookUpEdit lue, string c)
        {
            lue.Properties.NullText = "Seç";
            SikayetKonuDavaTalepCezaGetir_Enter(lue, EventArgs.Empty);
        }

        public static void SikayetKonuDavaTalepCezaGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_DavaTalepGetir != null)
                {
                    _SikayetKonuDavaTalepCezaGetir = new VList<per_TD_KOD_DAVA_TALEP>(_DavaTalepGetir.FindAll(item => item.ADLI_BIRIM_BOLUM_ID == 1).OrderByDescending(item => item.DAVA_TALEP).ToList());
                }
                else if (_SikayetKonuDavaTalepCezaGetir == null)
                {
                    _SikayetKonuDavaTalepCezaGetir = DataRepository.per_TD_KOD_DAVA_TALEPProvider.Get(" ADLI_BIRIM_BOLUM_ID='1'", "DAVA_TALEP DESC");
                }

                lue.DataSource = _SikayetKonuDavaTalepCezaGetir;

                //Find("ADLI_BIRIM_BOLUM_ID='1'");

                lue.DisplayMember = "DAVA_TALEP";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("DAVA_TALEP", "Þikayet Konu", 100));
            }
        }

        public static void SikayetKonuDavaTalepCezaRefresh()
        {
            _SikayetKonuDavaTalepCezaGetir = DataRepository.per_TD_KOD_DAVA_TALEPProvider.Get(" ADLI_BIRIM_BOLUM_ID='1'", "DAVA_TALEP DESC");
        }

        public static void SikayetKonuDavaTalepGetir(RepositoryItemLookUpEdit lue)
        {
            SikayetKonuDavaTalepGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TD_KOD_DAVA_TALEP
        /// </summary>
        /// <param name="lue"></param
        public static void SikayetKonuDavaTalepGetir(LookUpEdit lue)
        {
            SikayetKonuDavaTalepGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SikayetKonuDavaTalepGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_DavaTalepGetir == null)
                {
                    _DavaTalepGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_DAVA_TALEPProvider.GetAll();
                }
                _SikayetKonuDavaTalepGetir = _DavaTalepGetir;
                lue.DataSource = _SikayetKonuDavaTalepGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "DAVA_TALEP";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("DAVA_TALEP", "Þikayet Konu", 100));
            }
        }

        public static void SikayetNedenGetir(RepositoryItemLookUpEdit lue)
        {
            SikayetNedenGetir_Enter(lue, EventArgs.Empty);
        }

        public static void SikayetNEdenGetir(RepositoryItemLookUpEdit rLue)
        {
            SikayetNEdenGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void SikayetNEdenGetir(LookUpEdit lue)
        {
            SikayetNEdenGetir(lue.Properties);
        }

        public static void SikayetNedenGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_sikayetNedenGetir == null)
                    _sikayetNedenGetir = context.per_TDI_KOD_DAVA_ADIs.Where(vi => vi.ADLI_BIRIM_BOLUM_KOD == "C").OrderByDescending(vi => vi.DAVA_ADI).ToList();
                lue.DataSource = _sikayetNedenGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "DAVA_ADI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("DAVA_ADI", "Dava Seç", 100));
            }
        }

        public static void SikayetNEdenGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_SikayetNedenGetir == null)
                {
                    _SikayetNedenGetir = AvukatProLib2.Data.DataRepository.per_TI_KOD_SIKAYET_NEDENProvider.GetAll();
                }
                rLue.DataSource = _SikayetNedenGetir;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "SIKAYET_NEDEN";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("SIKAYET_NEDEN", "Þikayet Neden", 100));
            }
        }

        public static void SorumluAvukatGetir(RepositoryItemLookUpEdit lue)
        {
            if (per_TSorumluAvukatGetir == null)
            {
                if (_per_CariGetir != null)
                    per_TSorumluAvukatGetir = _per_CariGetir.FindAll(item => item.AVUKAT_MI == true && item.FIRMA_MI == false && item.PERSONEL_MI == true);
                else
                {
                    per_TSorumluAvukatGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.Where(item => item.AVUKAT_MI == true && item.FIRMA_MI == false && item.PERSONEL_MI == true).ToList();
                }
            }

            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 20, "Kod"), new LookUpColumnInfo("AD", 20, "Ad") });
            lue.DataSource = per_TSorumluAvukatGetir;

            //Get(" PERSONEL_MI='TRUE' AND FIRMA_MI='FALSE'", "AD DESC");
            //Find(string.Format("PERSONEL_MI='{0}' AND FIRMA_MI='{1}'", "TRUE", "FALSE"));
            lue.DisplayMember = "AD";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        public static void SorumluAvukatGetir(LookUpEdit lue)
        {
            lue.Properties.Columns.Clear();
            per_TSorumluAvukatGetir = SorumluAvukatGetir();
            lue.Properties.DataSource = per_TSorumluAvukatGetir;
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 20, "Kod"), new LookUpColumnInfo("AD", 20, "Ad") });
            lue.Properties.DisplayMember = "AD";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> SorumluAvukatGetir()
        {
            if (per_TSorumluAvukatGetir == null)
            {
                if (_per_CariGetir != null)
                    per_TSorumluAvukatGetir = _per_CariGetir.FindAll(item => item.AVUKAT_MI && !item.FIRMA_MI && item.PERSONEL_MI);
                else
                {
                    per_TSorumluAvukatGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.Where(item => item.AVUKAT_MI && !item.FIRMA_MI && item.PERSONEL_MI).ToList();
                }
            }
            return per_TSorumluAvukatGetir;
        }

        public static List<AvukatProLib.Arama.per_SORUMLU_AVUKAT_BY_FOY> SorumluAvukatGetirByFoyId(int foyId)
        {
            return context.per_SORUMLU_AVUKAT_BY_FOYs.Where(item => item.ICRA_FOY_ID == foyId).ToList();
        }

        public static void SorumluAvukatGetirRefresr()
        {
            if (per_TSorumluAvukatGetir == null)
            {
                if (_per_CariGetir != null)
                    per_TSorumluAvukatGetir = _per_CariGetir.FindAll(item => item.AVUKAT_MI == true && item.FIRMA_MI == false && item.PERSONEL_MI == true);
                else
                {
                    BelgeUtil.Inits.context.CommandTimeout = 99999999;
                    per_TSorumluAvukatGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.Where(item => item.AVUKAT_MI == true && item.FIRMA_MI == false && item.PERSONEL_MI == true).ToList();
                }
            }
        }

        //
        public static void SorumluTipGetir(RepositoryItemLookUpEdit lue)
        {
            SorumluTipGetir_Enter(lue, EventArgs.Empty);
        }

        public static void SorumluTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("SorumluTip");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.SorumluTip tipi in Enum.GetValues(typeof(AvukatProLib.Extras.SorumluTip)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Sorumlu Tipi"));
            }
        }

        public static void SorusturmaSorumluAvukatGetir(LookUpEdit lue, int sorusturmaID)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.DataSource = context.per_SorusturmaSorumluAvukats.Where(vi => vi.HAZIRLIK_ID == sorusturmaID).ToList();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("AD", 0, "Avukat") });
            lue.Properties.DisplayMember = "AD";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
        }

        public static void SozlesmeAltTipiHepsiGetir(LookUpEdit lue)
        {
            SozlesmeAltTipiHepsiGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SozlesmeAltTipiHepsiGetir(RepositoryItemLookUpEdit lue)
        {
            SozlesmeAltTipiHepsiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void SozlesmeAltTipiHepsiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_SozlesmeAltTipiHepsiGetir_Enter == null)
                    _SozlesmeAltTipiHepsiGetir_Enter = AvukatProLib2.Data.DataRepository.per_TDI_KOD_SOZLESME_ALT_TIPProvider.GetAll();

                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ALT_TIP", 40, "Sözleþme Alt Tipi") });
                lue.DataSource = _SozlesmeAltTipiHepsiGetir_Enter;
                lue.ValueMember = "ID";
                lue.DisplayMember = "ALT_TIP";
                lue.NullText = "Seç";
            }
        }

        public static void SozlesmeAltTipiHepsiGetirRefresh()
        {
            _SozlesmeAltTipiHepsiGetir_Enter = AvukatProLib2.Data.DataRepository.per_TDI_KOD_SOZLESME_ALT_TIPProvider.GetAll();
        }

        public static void SozlesmeAltTipiTipineGoreGetir(LookUpEdit lue, int TipId)
        {
            SozlesmeAltTipiTipineGoreGetir(lue.Properties, TipId);
        }

        public static void SozlesmeAltTipiTipineGoreGetir(RepositoryItemLookUpEdit rLue, int TipId)
        {
            if (_SozlesmeAltTipiHepsiGetir_Enter != null) _SozlesmeAltTipiTipineGore = _SozlesmeAltTipiHepsiGetir_Enter.FindAll(item => item.ANA_TIP_ID == TipId).ToList();
            _SozlesmeAltTipiTipineGore = AvukatProLib2.Data.DataRepository.per_TDI_KOD_SOZLESME_ALT_TIPProvider.Get("ANA_TIP_ID = " + TipId, "").ToList();
            rLue.Columns.Clear();
            rLue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ALT_TIP", 40, "Sözleþme Alt Tipi") });
            rLue.DataSource = _SozlesmeAltTipiTipineGore;
            rLue.ValueMember = "ID";
            rLue.DisplayMember = "ALT_TIP";
        }

        public static void SozlesmeDurumGetir(RepositoryItemLookUpEdit rLue)
        {
            SozlesmeDurumGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void SozlesmeDurumGetir(LookUpEdit lue)
        {
            SozlesmeDurumGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SozlesmeDurumGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_SozlesmeDurumGetir == null)
                {
                    _SozlesmeDurumGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_SOZLESME_DURUMProvider.GetAll();
                }
                lue.DataSource = _SozlesmeDurumGetir;
                lue.DisplayMember = "SOZLESME_DURUM";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("SOZLESME_DURUM", "Sözleþme Durum", 40));
            }
        }

        public static void SozlesmeGelismeAdimGetir(RepositoryItemLookUpEdit rLue)
        {
            if (_SozlesmeGelismeAdimGetir == null)
            {
                _SozlesmeGelismeAdimGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_SOZLESME_GELISME_ADIMProvider.GetAll();
            }
            rLue.DataSource = _SozlesmeGelismeAdimGetir;
            rLue.Columns.Clear();
            rLue.Columns.Add(new LookUpColumnInfo("GELISME_ADIM", "Geliþme Adým", 100));
            rLue.NullText = "Seç";
            rLue.DisplayMember = "GELISME_ADIM";
            rLue.ValueMember = "ID";
        }

        public static TList<AV001_TDI_BIL_SOZLESME> SozlesmeGetir()
        {
            if (_SozlesmeGetir == null)
                _SozlesmeGetir = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetAll();
            return _SozlesmeGetir;
        }

        public static void SozlesmeKategorisiGetir(RepositoryItemLookUpEdit lue)
        {
            SozlesmeKategorisiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void SozlesmeKategorisiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("AD", 20, "SozlesmeKategori") });

            _SozlesmeKategorisiGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_SOZLESME_KATEGORILERIProvider.GetAll();
            lue.DataSource = _SozlesmeKategorisiGetir;

            lue.DisplayMember = "AD";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        public static void SozlesmeKategorisiGetirRefresh()
        {
            _SozlesmeAltTipiHepsiGetir_Enter = AvukatProLib2.Data.DataRepository.per_TDI_KOD_SOZLESME_ALT_TIPProvider.GetAll();
        }

        public static void SozlesmeOzelKod(RepositoryItemLookUpEdit lue)
        {
            SozlesmeOzelKod_Enter(lue, EventArgs.Empty);
        }

        public static void SozlesmeOzelKod(LookUpEdit lue)
        {
            SozlesmeOzelKod_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SozlesmeOzelKod_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_SozlesmeOzelKod == null)
                    _SozlesmeOzelKod = DataRepository.per_TDI_KOD_SOZLESME_OZELProvider.GetAll();

                lue.DataSource = _SozlesmeOzelKod;
                lue.ValueMember = "ID";
                lue.DisplayMember = "SOZLESME_OZEL";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("SOZLESME_OZEL", 40, "Özel Kod"));
            }
        }

        public static void SozlesmeSekliGetir(LookUpEdit lue)
        {
            SozlesmeSekliGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SozlesmeSekliGetir(RepositoryItemLookUpEdit lue)
        {
            SozlesmeSekliGetir_Enter(lue, EventArgs.Empty);
        }

        public static void SozlesmeSekliGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("SozlesmeSekli");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.SozlesmeTur tur in Enum.GetValues(typeof(AvukatProLib.Extras.SozlesmeTur)))
                {
                    dt.Rows.Add((int)tur, tur.ToString());
                }
                lue.DataSource = dt;
                lue.ValueMember = "ID";
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";

                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 20, "Sözleþme Þekli"));
            }
        }

        public static void SozlesmeTakyidatKodGetir(RepositoryItemLookUpEdit rLue)
        {
            SozlesmeTakyidatKodGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void SozlesmeTakyidatKodGetir(LookUpEdit lue)
        {
            SozlesmeTakyidatKodGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SozlesmeTakyidatKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_SozlesmeTakyidatGetir == null)
                {
                    _SozlesmeTakyidatGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_SOZLESME_TAKYIDATProvider.GetAll();
                }
                rLue.DataSource = _SozlesmeTakyidatGetir;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "TAKYIDAT";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("TAKYIDAT", "Takyidat Kodlarý", 100));
            }
        }

        public static void SozlesmeTipiGetir(LookUpEdit lue)
        {
            SozlesmeTipiGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SozlesmeTipiGetir(RepositoryItemLookUpEdit lue)
        {
            SozlesmeTipiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void SozlesmeTipiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_SozlesmeTipiGetir_Enter == null)
                {
                    if (CodeInfo<per_TDI_KOD_SOZLESME_TIP>.ListeVarmi(typeof(per_TDI_KOD_SOZLESME_TIP)))
                        _SozlesmeTipiGetir_Enter = CodeInfo<per_TDI_KOD_SOZLESME_TIP>.ListeGetir(typeof(AvukatProLib2.Entities.per_TDI_KOD_SOZLESME_TIP)) as VList<per_TDI_KOD_SOZLESME_TIP>;
                    else
                    {
                        _SozlesmeTipiGetir_Enter = AvukatProLib2.Data.DataRepository.per_TDI_KOD_SOZLESME_TIPProvider.GetAll();

                        CodeInfo<per_TDI_KOD_SOZLESME_TIP>.ListeKaydet(_SozlesmeTipiGetir_Enter, typeof(per_TDI_KOD_SOZLESME_TIP));
                    }
                }
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("TIP", 40, "Sözleþme Tipi") });
                lue.DataSource = _SozlesmeTipiGetir_Enter;
                lue.ValueMember = "ID";
                lue.DisplayMember = "TIP";
                lue.NullText = "Seç";
            }
        }

        public static void SubeGetirBankayaGore_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            int bankaId = (int)lue.Tag;
            if (_BankaSubeGetir != null)
                lue.DataSource = _BankaSubeGetir.FindAll(item => item.BANKA_ID == bankaId).OrderByDescending(item => item.SUBE).ToList();
            else
                lue.DataSource = context.VDI_KOD_BANKA_SUBEs.Where(vi => vi.BANKA_ID == bankaId).OrderByDescending(vi => vi.SUBE).ToList();

            lue.DisplayMember = "SUBE";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("SUBE", 20, "Sube") });
        }

        /// <summary>
        /// TDI_KOD_SURE_OZEL
        /// </summary>
        /// <param name="lue"></param>
        public static void SureOzelKodGetir(RepositoryItemLookUpEdit lue)
        {
            SureOzelKodGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_SURE_OZEL
        /// </summary>
        /// <param name="lue"></param
        public static void SureOzelKodGetir(LookUpEdit lue)
        {
            SureOzelKodGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void SureOzelKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_SureOzelKodGetir == null)
                {
                    _SureOzelKodGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_SURE_OZELProvider.GetAll();
                }

                lue.DataSource = _SureOzelKodGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "SURE_OZEL";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("SURE_OZEL", "Süre Özel Kod", 100));
            }
        }

        /// <summary>
        /// sözleþem kaydý için süre birim tiplerini getiren metot
        /// </summary>
        /// <param name="lue"></param>
        public static void SureTipTipGetir(RepositoryItemLookUpEdit lue)
        {
            SureTipTipGetir_Enter(lue, EventArgs.Empty);
        }

        public static void SureTipTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("SüreBirinTipi");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.SureBirimTip tipi in Enum.GetValues(typeof(AvukatProLib.Extras.SureBirimTip)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Süre Birim Tipi"));
            }
        }

        /// <summary>
        /// TI_KOD_TAAHHUT_DURUM
        /// </summary>
        /// <param name="lue"></param>
        public static void TaahhutDurumGetir(RepositoryItemLookUpEdit lue)
        {
            TaahhutDurumGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TI_KOD_TAAHHUT_DURUM
        /// </summary>
        /// <param name="lue"></param
        public static void TaahhutDurumGetir(LookUpEdit lue)
        {
            TaahhutDurumGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TaahhutDurumGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TaahhutDurumGetir == null)
                {
                    _TaahhutDurumGetir = AvukatProLib2.Data.DataRepository.per_TI_KOD_TAAHHUT_DURUMProvider.GetAll();
                }
                lue.DataSource = _TaahhutDurumGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "DURUM";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("DURUM", "Taahhut Durum", 100));
            }
        }

        /// <summary>
        /// TaahhutTip
        /// </summary>
        /// <param name="lue"></param>
        public static void TaahhutTipGetir(RepositoryItemLookUpEdit lue)
        {
            TaahhutTipGetir_Enter(lue, EventArgs.Empty);
        }

        public static void TaahhutTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("dtTaadhutTipi");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.TaahhutResmiMi tipi in Enum.GetValues(typeof(AvukatProLib.Extras.TaahhutResmiMi)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Taahhut Tipi"));
            }
        }

        public static void TahsilatdurumGetir(RepositoryItemLookUpEdit lue)
        {
            TahsilatdurumGetir_Enter(lue, EventArgs.Empty);
        }

        public static void TahsilatdurumGetir(LookUpEdit lue)
        {
            TahsilatdurumGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TahsilatdurumGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TahsilatdurumGetir == null)
                    _TahsilatdurumGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_TAHSILAT_DURUMProvider.GetAll();

                lue.DataSource = _TahsilatdurumGetir;
                lue.ValueMember = "ID";
                lue.DisplayMember = "TAHSILAT_DURUM";
                lue.NullText = "Seç";
                LookUpColumnInfo ID = new LookUpColumnInfo("ID", 20);
                ID.Visible = false;

                LookUpColumnInfo KART_TIPI = new LookUpColumnInfo("TAHSILAT_DURUM", 40, "Tahsilat Durum");
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { ID, KART_TIPI });
            }
        }

        //TDI_KOD_TAHSILAT_DURUM
        public static void TahsilatdurumGetirByFoyBirim(RepositoryItemLookUpEdit lue, int FoyBirim)
        {
            if (_TahsilatdurumGetir != null)
            {
                lue.DataSource = _TahsilatdurumGetir.Where(item => item.FOY_BIRIM_ID == FoyBirim).OrderByDescending(item => item.TAHSILAT_DURUM);
            }
            else
                lue.DataSource = AvukatProLib2.Data.DataRepository.per_TDI_KOD_TAHSILAT_DURUMProvider.Get(" FOY_BIRIM_ID=" + FoyBirim, "TAHSILAT_DURUM DESC");

            lue.ValueMember = "ID";
            lue.DisplayMember = "TAHSILAT_DURUM";
            lue.NullText = "Seç";
            LookUpColumnInfo ID = new LookUpColumnInfo("ID", 20);
            ID.Visible = false;

            LookUpColumnInfo KART_TIPI = new LookUpColumnInfo("TAHSILAT_DURUM", 40, "Tahsilat Durum");
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { ID, KART_TIPI });
        }

        public static void TahsilatdurumGetirByFoyBirim(LookUpEdit lue, int FoyBirim)
        {
            if (_TahsilatdurumGetir != null)
            {
                lue.Properties.DataSource = _TahsilatdurumGetir.Where(item => item.FOY_BIRIM_ID == FoyBirim).OrderByDescending(item => item.TAHSILAT_DURUM);
            }
            else
                lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.per_TDI_KOD_TAHSILAT_DURUMProvider.Get(" FOY_BIRIM_ID=" + FoyBirim, "TAHSILAT_DURUM DESC");

            lue.Properties.ValueMember = "ID";
            lue.Properties.DisplayMember = "TAHSILAT_DURUM";
            lue.Properties.NullText = "Seç";
            LookUpColumnInfo ID = new LookUpColumnInfo("ID", 20);
            ID.Visible = false;

            LookUpColumnInfo KART_TIPI = new LookUpColumnInfo("TAHSILAT_DURUM", 40, "Tahsilat Durum");
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { ID, KART_TIPI });
        }

        public static void TakipKonusuGetir(LookUpEdit lue)
        {
            TakipKonusuGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TakipKonusuGetir(RepositoryItemLookUpEdit lue)
        {
            TakipKonusuGetir_Enter(lue, EventArgs.Empty);
        }

        public static void TakipKonusuGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TakipKonusuGetir_Enter == null)
                {
                    if (CodeInfo<per_TI_KOD_TAKIP_TALEP>.ListeVarmi(typeof(per_TI_KOD_TAKIP_TALEP)))
                        _TakipKonusuGetir_Enter = CodeInfo<per_TI_KOD_TAKIP_TALEP>.ListeGetir(typeof(per_TI_KOD_TAKIP_TALEP)) as VList<per_TI_KOD_TAKIP_TALEP>;
                    else
                    {
                        _TakipKonusuGetir_Enter = DataRepository.per_TI_KOD_TAKIP_TALEPProvider.GetAll();
                        CodeInfo<per_TI_KOD_TAKIP_TALEP>.ListeKaydet(_TakipKonusuGetir_Enter, typeof(per_TI_KOD_TAKIP_TALEP));
                    }
                }
                lue.DataSource = _TakipKonusuGetir_Enter;
                lue.ValueMember = "ID";
                lue.DisplayMember = "TALEP_ADI";
                LookUpColumnInfo sozlesmeKategori = new LookUpColumnInfo("TALEP_ADI", 30, "Takip Konusu");
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { sozlesmeKategori });
            }
        }

        public static void TakipYoluGetir(RepositoryItemLookUpEdit lue)
        {
            TakipYoluGetir_Enter(lue, EventArgs.Empty);
        }

        public static void TakipYoluGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TakipYoluGetir == null)
                {
                    _TakipYoluGetir = AvukatProLib2.Data.DataRepository.per_TI_KOD_TAKIP_YOLUProvider.GetAll();
                }
                lue.DataSource = _TakipYoluGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "TAKIP_YOLU";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("TAKIP_YOLU", "Takip Yolu", 100));
            }
        }

        public static void TakipYontemGetir(RepositoryItemLookUpEdit rLue)
        {
            TakipYontemGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void TakipYontemGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_TakipYontemGetir == null)
                {
                    _TakipYontemGetir = DataRepository.per_TI_KOD_TAKIP_YONTEMProvider.GetAll();
                }
                rLue.DataSource = _TakipYontemGetir;
                rLue.DisplayMember = "TAKIP_YONTEM";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("TAKIP_YONTEM", 30, "Takip Yöntem"));
            }
        }

        public static void TalimatIslemGetir(RepositoryItemLookUpEdit lue)
        {
            if (_TalimatIslemGetir == null)
                _TalimatIslemGetir = AvukatProLib2.Data.DataRepository.TI_KOD_TALIMAT_ISLEM_TIPProvider.GetAll();

            lue.DataSource = _TalimatIslemGetir;
            lue.NullText = "Seç";
            lue.DisplayMember = "ISLEM_TIP";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ISLEM_TIP", "Ýþlem Tip", 40));
        }

        public static void TapuMudurlukGetir(RepositoryItemLookUpEdit lue)
        {
            if (_TapuMudurlukGetir == null)
            {
                _TapuMudurlukGetir = DataRepository.per_TDI_KOD_TAPU_MUDURLUKProvider.GetAll();
            }
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ADI", 10, "Tapu Müdürlüðü") });
            lue.DataSource = _TapuMudurlukGetir;
            lue.DisplayMember = "ADI";
            lue.ValueMember = "ID";
            lue.NullText = "Tapu Müdürlüðü Seç";
        }

        public static void TapuMudurlukGetirIlceyeGore(RepositoryItemLookUpEdit lue, int IlceId)
        {
            _TapuMudurlukGetirIlceyeGore = DataRepository.per_TDI_KOD_TAPU_MUDURLUKProvider.GetAll().Where(v => v.ILCE_ID == IlceId).ToList();

            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ADI", 10, "Tapu Müdürlüðü") });
            lue.DataSource = _TapuMudurlukGetirIlceyeGore;
            lue.DisplayMember = "ADI";
            lue.ValueMember = "ID";
            lue.NullText = "Tapu Müdürlüðü Seç";
        }

        public static void TarafKoduEnumGetir(LookUpEdit lue)
        {
            TarafKoduEnumGetir2_Enter(lue, EventArgs.Empty);
        }

        //
        public static void TarafKoduEnumGetir(RepositoryItemLookUpEdit lue)
        {
            TarafKoduEnumGetir2_Enter(lue, EventArgs.Empty);
        }

        public static void TarafKoduEnumGetir2_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("TarafKodu");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.TarafKodlari tipi in Enum.GetValues(typeof(AvukatProLib.Extras.TarafKodlari)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Taraf Kodu"));
            }
        }

        /// <summary>
        /// TDI_KOD_TARAF
        /// </summary>
        /// <param name="lue"></param>
        public static void TarafKoduGetir(RepositoryItemLookUpEdit lue)
        {
            TarafKoduGetir_Enter(lue, EventArgs.Empty);
        }

        public static void TarafKoduGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TarafKoduGetir == null)
                {
                    if (CodeInfo<TDI_KOD_TARAF>.ListeVarmi(typeof(TDI_KOD_TARAF)))
                        _TarafKoduGetir = CodeInfo<TDI_KOD_TARAF>.ListeGetir(typeof(TDI_KOD_TARAF)) as TList<TDI_KOD_TARAF>;
                    else
                    {
                        _TarafKoduGetir = AvukatProLib2.Data.DataRepository.TDI_KOD_TARAFProvider.GetAll();
                        CodeInfo<TDI_KOD_TARAF>.ListeKaydet(_TarafKoduGetir, typeof(TDI_KOD_TARAF));
                    }
                }

                //ToDo : prosedur yazýlacak
                //TODO:	obj.IsSelected
                AvukatProLib2.Entities.TList<AvukatProLib2.Entities.TDI_KOD_TARAF> myList = _TarafKoduGetir;
                myList.ForEach(delegate(TDI_KOD_TARAF obj)
                {
                    obj.IsSelected = obj.KOD == "K";
                });
                lue.DataSource = myList;
                lue.NullText = "Seç";
                lue.DisplayMember = "KOD";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("TIP", 30, "Taraf Kodu"));
            }
        }

        public static void TarafKodunaGoreCariGetir(RepositoryItemLookUpEdit rlue, byte value)
        {
            if (Convert.ToByte(value) == Convert.ToByte(TarafKodlari.M))
                CariGetirByTarafKodu(rlue, TarafKodu.Muvekkil);
            else if (Convert.ToByte(value) == Convert.ToByte(TarafKodlari.K))
                CariGetirByTarafKodu(rlue, TarafKodu.KarsiTaraf);
            else if (Convert.ToByte(value) == Convert.ToByte(TarafKodlari.V))
            {
                rlue.DataSource = null;
                perCariAvukatGetir(rlue);
            }
            else
            {
                rlue.DataSource = null;
                perCariGetir(rlue);
            }
        }

        public static void TarafSifatGetir(RepositoryItemLookUpEdit rLue, string pHangiTarafi, string pAdliBirimBolumKod)
        {
            if (_TarafSifatGetir != null)
            {
                rLue.DataSource = _TarafSifatGetir.Where(item => item.HANGI_TARAFI == pHangiTarafi && (item.ADLI_BIRIM_BOLUM_KOD == "O" || item.ADLI_BIRIM_BOLUM_KOD == pAdliBirimBolumKod));
            }
            else
                rLue.DataSource = context.per_TDIE_KOD_TARAF_SIFATs.Where(item => item.HANGI_TARAFI == pHangiTarafi && (item.ADLI_BIRIM_BOLUM_KOD == "O" || item.ADLI_BIRIM_BOLUM_KOD == pAdliBirimBolumKod));

            //TODO: per_TDIE_KOD_TARAF_SIFAT view a ADLI_BIRIM_BOLUM_KOD alaný eklenecek.
            rLue.NullText = "Seç";
            rLue.DisplayMember = "SIFAT";
            rLue.ValueMember = "ID";
            rLue.Columns.Clear();
            rLue.Columns.Add(new LookUpColumnInfo("SIFAT", "Taraf Sýfat", 100));
        }

        public static void TarafSifatGetir(RepositoryItemLookUpEdit lue, string pHangiTarafi)
        {
            if (lue.DataSource == null)
            {
                if (_TarafSifatGetir != null)
                {
                    lue.DataSource = _TarafSifatGetir.FindAll(item => item.HANGI_TARAFI == pHangiTarafi);
                }
                else
                    lue.DataSource = context.per_TDIE_KOD_TARAF_SIFATs.Where(item => item.HANGI_TARAFI == pHangiTarafi).ToList();
                lue.NullText = "Seç";
                lue.DisplayMember = "SIFAT";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("SIFAT", "Taraf Sýfat", 100));
            }
        }

        public static List<AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT> TarafSifatGetirByIdList(List<int> idList)
        {
            if (_TarafSifatGetir != null)
            {
                return _TarafSifatGetir.FindAll(item => idList.Contains(item.ID));
            }
            else
                return context.per_TDIE_KOD_TARAF_SIFATs.Where(item => idList.Contains(item.ID)).ToList();
        }

        /// <summary>
        /// TD_KOD_TARAF_STATU
        /// </summary>
        /// <param name="lue"></param>
        public static void TarafStatuGetir(RepositoryItemLookUpEdit lue)
        {
            TarafStatuGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TD_KOD_TARAF_STATU
        /// </summary>
        /// <param name="lue"></param
        public static void TarafStatuGetir(LookUpEdit lue)
        {
            TarafStatuGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TarafStatuGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TarafStatuGetir == null)
                {
                    if (CodeInfo<per_TD_KOD_TARAF_STATU>.ListeVarmi(typeof(per_TD_KOD_TARAF_STATU)))
                        _TarafStatuGetir = CodeInfo<per_TD_KOD_TARAF_STATU>.ListeGetir(typeof(AvukatProLib2.Entities.per_TD_KOD_TARAF_STATU)) as VList<per_TD_KOD_TARAF_STATU>;
                    else
                    {
                        _TarafStatuGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_TARAF_STATUProvider.GetAll();
                        CodeInfo<per_TD_KOD_TARAF_STATU>.ListeKaydet(_TarafStatuGetir, typeof(per_TD_KOD_TARAF_STATU));
                    }
                }
                lue.NullText = "Seç";
                lue.DataSource = _TarafStatuGetir;
                lue.DisplayMember = "STATU";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("STATU", "Taraf Statü", 100));
            }
        }

        public static List<AvukatProLib.Arama.per_TARAF_AND_SIFAT_BY_FOY> TarafVeSifatGetirByFoyId(int foyId)
        {
            return context.per_TARAF_AND_SIFAT_BY_FOYs.Where(item => item.ICRA_FOY_ID == foyId).ToList();
        }

        public static void TarihAlaniAyarla(RepositoryItemDateEdit ridt)
        {
            ridt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            ridt.DisplayFormat.FormatString = "{0:dddd, MMMM d, yyyy}";
            ridt.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            ridt.EditFormat.FormatString = "{0:dddd, MMMM d, yyyy}";
        }

        public static void TarihKategoriGetir(RepositoryItemLookUpEdit rLue)
        {
            TarihkategoriGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void TarihKategoriGetir(LookUpEdit lue)
        {
            TarihkategoriGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TarihkategoriGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_TarihKategoriGetir == null)
                {
                    _TarihKategoriGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_TARIH_KATEGORIProvider.GetAll();
                }
                rLue.DataSource = _TarihKategoriGetir;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "ACIKLAMA";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", "Tarih Kategori", 100));
            }
        }

        public static void TazminatHesapTipiGetir(RepositoryItemLookUpEdit lue)
        {
            TazminatHesapTipiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void TazminatHesapTipiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("TazminatHesapTipi");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                foreach (AvukatProLib.Extras.DavaTazminatHesapTipi tipi in Enum.GetValues(typeof(AvukatProLib.Extras.DavaTazminatHesapTipi)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Tazminat Hesap Tipi"));
            }
        }

        /// <summary>
        /// ID 23 - 32 arasý TDI_KOD_TEBLIGAT_ALAN_BAGLANTI
        /// </summary>
        /// <param name="lue"></param>
        public static void TebligatAlanBaglantiGetir(LookUpEdit lue)
        {
            TebligatAlanBaglantiGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        //ToDo : Burada kaldýk gkn.
        /// <summary>
        /// ID 23 - 32 arasý
        /// TDI_KOD_TEBLIGAT_ALAN_BAGLANTI
        /// </summary>
        /// <param name="lue"></param>
        public static void TebligatAlanBaglantiGetir(RepositoryItemLookUpEdit lue)
        {
            TebligatAlanBaglantiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void TebligatAlanBaglantiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TebligatAlanBaglantiGetir_Enter == null)
                {
                    _TebligatAlanBaglantiGetir_Enter = DataRepository.per_TDI_KOD_TEBLIGAT_ALAN_BAGLANTIProvider.GetAll();
                }

                lue.DataSource = _TebligatAlanBaglantiGetir_Enter;
                lue.NullText = "Seç";
                lue.DisplayMember = "BAGLANTI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("BAGLANTI", "Baðlantý", 100));
            }
        }

        /// <summary>
        /// ID 23 - 32 arasý dahil olmayanlar
        /// </summary>
        /// <param name="lue"></param>
        public static void TebligatAlanBaglantiGetirBy23_32Haric(RepositoryItemLookUpEdit lue)
        {
            TebligatAlanBaglantiGetirBy23_32Haric_Enter(lue, EventArgs.Empty);
        }

        public static void TebligatAlanBaglantiGetirBy23_32Haric_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                VList<per_TDI_KOD_TEBLIGAT_ALAN_BAGLANTI> obj = new VList<per_TDI_KOD_TEBLIGAT_ALAN_BAGLANTI>();

                foreach (per_TDI_KOD_TEBLIGAT_ALAN_BAGLANTI var in DataRepository.per_TDI_KOD_TEBLIGAT_ALAN_BAGLANTIProvider.GetAll())
                {
                    if (var.ID >= 23 || var.ID <= 32)
                        obj.Add(var);
                }

                lue.DataSource = obj;
                lue.NullText = "Seç";
                lue.DisplayMember = "BAGLANTI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("BAGLANTI", "Baðlantý", 100));
            }
        }

        /// <summary>
        /// TDI_KOD_TEBLIGAT_ALIM_SEKIL
        /// </summary>
        /// <param name="lue"></param>
        public static void TebligatAlimSekli(RepositoryItemLookUpEdit lue)
        {
            TebligatAlimSekli_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_TEBLIGAT_ALIM_SEKIL
        /// </summary>
        /// <param name="lue"></param
        public static void TebligatAlimSekli(LookUpEdit lue)
        {
            TebligatAlimSekli_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TebligatAlimSekli_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TebligatAlimSekli == null)
                {
                    _TebligatAlimSekli = AvukatProLib2.Data.DataRepository.per_TDI_KOD_TEBLIGAT_ALIM_SEKILProvider.GetAll();
                }
                lue.DataSource = _TebligatAlimSekli;
                lue.NullText = "Seç";
                lue.DisplayMember = "SEKIL";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("SEKIL", "Tebligat Alým Þekli", 100));
            }
        }

        /// <summary>
        /// TDI_KOD_TEBLIGAT_ALINMAMA_NEDEN
        /// </summary>
        /// <param name="lue"></param>
        public static void TebligatAlinmamaNedenGetir(RepositoryItemLookUpEdit lue)
        {
            TebligatAlinmamaNedenGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_TEBLIGAT_ALINMAMA_NEDEN
        /// </summary>
        /// <param name="lue"></param
        public static void TebligatAlinmamaNedenGetir(LookUpEdit lue)
        {
            TebligatAlinmamaNedenGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TebligatAlinmamaNedenGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TebligatAlinmamaNedenGetir == null)
                {
                    _TebligatAlinmamaNedenGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_TEBLIGAT_ALINMAMA_NEDENProvider.GetAll();
                }
                lue.DataSource = _TebligatAlinmamaNedenGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "NEDEN";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("NEDEN", "Tebligat Alýnmama Neden", 100));
            }
        }

        public static void TebligatAltTurGetir(RepositoryItemLookUpEdit lue)
        {
            TebligatAltTurGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_TEBLIGAT_ALT_TUR
        /// </summary>
        /// <param name="lue"></param
        public static void TebligatAltTurGetir(LookUpEdit lue)
        {
            TebligatAltTurGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TebligatAltTurGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TebligatAltTurGetir == null)
                {
                    _TebligatAltTurGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_TEBLIGAT_ALT_TURProvider.GetAll();
                }
                lue.DataSource = _TebligatAltTurGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "ALT_TUR";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ALT_TUR", "Tebligat Alt Tür", 100));
            }
        }

        public static void TebligatAnaTurGetir(RepositoryItemLookUpEdit lue)
        {
            TebligatAnaTurGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_TEBLIGAT_ANA_TUR
        /// </summary>
        /// <param name="lue"></param
        public static void TebligatAnaTurGetir(LookUpEdit lue)
        {
            TebligatAnaTurGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TebligatAnaTurGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TebligatAnaTurGetir == null)
                {
                    _TebligatAnaTurGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_TEBLIGAT_ANA_TURProvider.GetAll();
                }
                lue.DataSource = _TebligatAnaTurGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "ANA_TUR";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ANA_TUR", "Tebligat Ana Tür", 100));
            }
        }

        public static TList<AV001_TDI_BIL_TEBLIGAT> TebligatGetir()
        {
            if (_TebligatGetir == null)
                _TebligatGetir = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetAll();
            return _TebligatGetir;
        }

        public static void TebligatHacizIhbarnameKonuGetir(RepositoryItemLookUpEdit lue)
        {
            TebligatHacizIhbarnameKonuGetir_Enter(lue, EventArgs.Empty);
        }

        // lue.Properties.DisplayMember = "KONU"; lue.Properties.ValueMember = "ID";
        // lue.Properties.Columns.Clear(); lue.Properties.Columns.Add(new LookUpColumnInfo("KONU",
        // "Tebligat Konu", 100)); }
        //}
        //
        public static void TebligatHacizIhbarnameKonuGetir(LookUpEdit lue)
        {
            TebligatHacizIhbarnameKonuGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        //public static void TebligatKonuGetir_Enter(object sender, EventArgs e)
        //{
        //    LookUpEdit lue = (LookUpEdit)sender;
        //    if (lue.Properties.DataSource == null)
        //    {
        //        lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_TEBLIGAT_KONUProvider.GetAll();
        public static void TebligatHacizIhbarnameKonuGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TebligatHacizIhbarnameKonuGetir == null)
                {
                    _TebligatHacizIhbarnameKonuGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_TEBLIGAT_KONUProvider.HacizIhbarnameKodGetir();
                }
                lue.DataSource = _TebligatHacizIhbarnameKonuGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "KONU";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("KONU", "Tebligat Konu", 100));
            }
        }

        /// <summary>
        /// TDI_KOD_TEBLIGAT_KONU
        /// </summary>
        /// <param name="lue"></param>
        public static void TebligatKonuGetir(RepositoryItemLookUpEdit lue)
        {
            TebligatkonuGetir_Enter(lue, EventArgs.Empty);
        }

        public static void TebligatKonuGetir(LookUpEdit lue)
        {
            TebligatkonuGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TebligatkonuGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TebligatKonuGetir == null)
                {
                    _TebligatKonuGetir = AvukatProLib2.Data.DataRepository.TDI_KOD_TEBLIGAT_KONUProvider.GetAll();
                }
                lue.DataSource = _TebligatKonuGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "KONU";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("KONU", "Tebligat Konu", 100));
            }
        }

        public static void TebligatKonuGetirKlasorAlacak(RepositoryItemLookUpEdit lue)
        {
            TebligatKonuGetirKlasorAlacak_Enter(lue, EventArgs.Empty);
        }

        public static void TebligatKonuGetirKlasorAlacak_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                TList<TDI_KOD_TEBLIGAT_KONU> konular = new TList<TDI_KOD_TEBLIGAT_KONU>();
                foreach (var item in AvukatProLib2.Data.DataRepository.TDI_KOD_TEBLIGAT_KONUProvider.GetAll())
                {
                    if (item.ID == 481 || item.ID == 482)
                        konular.Add(item);
                }
                lue.DataSource = konular;
                lue.NullText = "Seç";
                lue.DisplayMember = "KONU";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("KONU", "Tebligat Konu", 100));
            }
        }

        /// <summary>
        /// TDI_KOD_TEBLIGAT_SEKIL
        /// </summary>
        /// <param name="lue"></param>
        ///
        public static void TebligatSekliGetir(RepositoryItemLookUpEdit lue)
        {
            TebligatSekliGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_TEBLIGAT_SEKIL
        /// </summary>
        /// <param name="lue"></param
        public static void TebligatSekliGetir(LookUpEdit lue)
        {
            TebligatSekliGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TebligatSekliGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TebligatSekliGetir == null)
                {
                    _TebligatSekliGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_TEBLIGAT_SEKILProvider.GetAll();
                }
                lue.DataSource = _TebligatSekliGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "SEKIL";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("SEKIL", "Tebligat Þekli", 100));
            }
        }

        public static void TebligatSonucGetir(RepositoryItemLookUpEdit rlue)
        {
            rlue.Columns.Clear();
            rlue.DataSource = DataRepository.TDI_KOD_TEBLIGAT_SONUCProvider.GetAll();
            rlue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("TEBLIGAT_SONUC", 20, "Sonuç") });
            rlue.DisplayMember = "TEBLIGAT_SONUC";
            rlue.ValueMember = "ID";
            rlue.NullText = "Seç";
        }

        /// <summary>
        /// TDI_KOD_TEBLIGAT_TESLIM_YER
        /// </summary>
        /// <param name="lue"></param>
        public static void TebligatTeslimYerGetir(RepositoryItemLookUpEdit lue)
        {
            TebligatTeslimYerGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TDI_KOD_TEBLIGAT_TESLIM_YER
        /// </summary>
        /// <param name="lue"></param
        public static void TebligatTeslimYerGetir(LookUpEdit lue)
        {
            TebligatTeslimYerGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TebligatTeslimYerGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TebligatTeslimYerGetir == null)
                {
                    _TebligatTeslimYerGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_TEBLIGAT_TESLIM_YERProvider.GetAll();
                }
                lue.DataSource = _TebligatTeslimYerGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "YER";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("YER", "Tebligat Teslim Yeri", 100));
            }
        }

        public static void TebligatTipGetir(RepositoryItemLookUpEdit rLue)
        {
            TebligatTipGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void TebligatTipGetir(LookUpEdit lue)
        {
            TebligatTipGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TebligatTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_TebligatTipGetir == null)
                {
                    _TebligatTipGetir = DataRepository.TDI_KOD_TEBLIGAT_TIPProvider.GetAll();
                }
                rLue.DataSource = _TebligatTipGetir;
                rLue.DisplayMember = "ADI";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("ADI", 30, "Tebligat Tip"));
            }
        }

        public static void TeminatAltTipGetir(RepositoryItemLookUpEdit rLue)
        {
            TeminatAltTipGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void TeminatAltTipGetir(LookUpEdit lue)
        {
            TeminatAltTipGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TeminatAltTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_TeminatAltTipGetir == null)
                {
                    _TeminatAltTipGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_POLICE_TEMINAT_ALT_TIPProvider.GetAll();
                }
                rLue.DataSource = _TeminatAltTipGetir;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "TEMINAT_TIPI";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("TEMINAT_TIPI", "Teminat Alt Tipi", 100));
            }
        }

        public static void TeminatMektupGetir(RepositoryItemLookUpEdit lue)
        {
            //ToDo : viev yapýlacak
            TeminatMektupGetir_Enter(lue, EventArgs.Empty);
        }

        public static void TeminatMektupGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TeminatMektupGetir == null || _TeminatMektupGetir.Count == 0)
                {
                    _TeminatMektupGetir = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.GetAll();
                }
                lue.DataSource = _TeminatMektupGetir;
                lue.DisplayMember = "TIPI";
                lue.ValueMember = "ID";

                LookUpColumnInfo TIPI = new LookUpColumnInfo("TIPI", 40, "Teminat Mektup");

                lue.Columns.AddRange(new LookUpColumnInfo[] { TIPI });
                lue.NullText = "Seç";
            }
        }

        public static void TeminatTuruGetir(RepositoryItemLookUpEdit lue)
        {
            TeminatTuruGetir_Enter(lue, EventArgs.Empty);
        }

        public static void TeminatTuruGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TeminatTuruGetir == null)
                    _TeminatTuruGetir = AvukatProLib2.Data.DataRepository.per_TI_KOD_TEMINAT_TURProvider.GetAll();

                lue.DataSource = _TeminatTuruGetir;
                lue.DisplayMember = "TEMINAT_TUR";
                lue.ValueMember = "ID";
                LookUpColumnInfo TEMINAT_TUR = new LookUpColumnInfo("TEMINAT_TUR", 40, "Teminat Türü");
                lue.Columns.AddRange(new LookUpColumnInfo[] { TEMINAT_TUR });
                lue.NullText = "Seç";
            }
        }

        public static void TemsilSekilGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TemsilSekliGetir == null)
                {
                    if (CodeInfo<per_TDI_KOD_TEMSIL_SEKIL>.ListeVarmi(typeof(per_TDI_KOD_TEMSIL_SEKIL)))
                        _TemsilSekliGetir = CodeInfo<per_TDI_KOD_TEMSIL_SEKIL>.ListeGetir(typeof(per_TDI_KOD_TEMSIL_SEKIL)) as VList<per_TDI_KOD_TEMSIL_SEKIL>;
                    else
                    {
                        _TemsilSekliGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_TEMSIL_SEKILProvider.GetAll();
                        CodeInfo<per_TDI_KOD_TEMSIL_SEKIL>.ListeKaydet(_TemsilSekliGetir, typeof(per_TDI_KOD_TEMSIL_SEKIL));
                    }
                }

                lue.DataSource = _TemsilSekliGetir;
                lue.DisplayMember = "TEMSIL_SEKIL";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("TEMSIL_SEKIL", 10, "Temsil Þekli"));
            }
        }

        public static void TemsilSekliGetir(LookUpEdit lue)
        {
            TemsilSekilGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TemsilSekliGetir(RepositoryItemLookUpEdit lue)
        {
            TemsilSekilGetir_Enter(lue, EventArgs.Empty);
        }

        public static void TemsilSonaErmeSebepGetir(RepositoryItemLookUpEdit lue)
        {
            TemsilSonaErmeSebepGetir_Enter(lue, EventArgs.Empty);
        }

        public static void TemsilSonaErmeSebepGetir(LookUpEdit lue)
        {
            TemsilSonaErmeSebepGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TemsilSonaErmeSebepGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TemsilSonaErmeSebepGetir == null)
                {
                    _TemsilSonaErmeSebepGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_TEMSIL_SONA_ERME_SEBEPProvider.GetAll();
                }
                lue.DataSource = _TemsilSonaErmeSebepGetir;
                lue.DisplayMember = "SEBEP";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("SEBEP", "Sebep", 100));
                lue.NullText = "Seç";
            }
        }

        public static void TemsilTipiGetir(LookUpEdit lue)
        {
            TemsilTipiGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TemsilTipiGetir(RepositoryItemLookUpEdit lue)
        {
            TemsilTipiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void TemsilTipiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TemsilTipiGetir == null)
                    _TemsilTipiGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_TEMSIL_TIPProvider.GetAll();

                lue.DataSource = _TemsilTipiGetir;
                lue.ValueMember = "ID";
                lue.DisplayMember = "TIP";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("TIP", "Temsil Tip", 100));
            }
        }

        public static void TemsilTuruGetir(LookUpEdit lue)
        {
            TemsilTuruGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TemsilTuruGetir(RepositoryItemLookUpEdit lue)
        {
            TemsilTuruGetir_Enter(lue, EventArgs.Empty);
        }

        public static void TemsilTuruGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TemsilTuruGetir == null)
                    _TemsilTuruGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_TEMSIL_TURProvider.GetAll();

                lue.DataSource = _TemsilTuruGetir;
                lue.ValueMember = "ID";
                lue.DisplayMember = "TEMSIL_TURU";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("TEMSIL_TURU", 10, "Temsil Türü"));
            }
        }

        public static void TemsilYetkiKullanmaTipiGetir(RepositoryItemLookUpEdit lue)
        {
            TemsilYetkiKullanmaTipiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void TemsilYetkiKullanmaTipiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("YetkiKullanmaTipi");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");

                foreach (AvukatProLib.Extras.TemsilYetkiKullanmaSekli tipi in Enum.GetValues(typeof(AvukatProLib.Extras.TemsilYetkiKullanmaSekli)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "ACIKLAMA";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Yetki Kullanma Þekli"));
            }
        }

        /// <summary>
        /// TD_KOD_TEMYIZ_TIP
        /// </summary>
        /// <param name="lue"></param>
        public static void TemyizTipGetir(RepositoryItemLookUpEdit lue)
        {
            TemyizTipGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TD_KOD_TEMYIZ_TIP
        /// </summary>
        /// <param name="lue"></param
        public static void TemyizTipGetir(LookUpEdit lue)
        {
            TemyizTipGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TemyizTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TemyizTipGetir == null)
                {
                    _TemyizTipGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_TEMYIZ_TIPProvider.GetAll();
                }
                lue.NullText = "Seç";
                lue.DataSource = _TemyizTipGetir;
                lue.DisplayMember = "TEMYIZ_TIP";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("TEMYIZ_TIP", "Temyiz Tip", 100));
            }
        }

        public static void TespitKonuGetir(RepositoryItemLookUpEdit rLue)
        {
            TespitKonuGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void TespitKonuGetir(LookUpEdit lue)
        {
            TespitKonuGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TespitKonuGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_TespitKonusuGetir == null)
                {
                    _TespitKonusuGetir = DataRepository.per_TI_KOD_TESPIT_KONUSUProvider.GetAll();
                }
                rLue.DataSource = _TespitKonusuGetir;
                rLue.DisplayMember = "KONU";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("KONU", 30, "Tespit Konusu Getir"));
            }
        }

        public static void TespitOzelKodGetir(RepositoryItemLookUpEdit rLue)
        {
            TespitOzelKodGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void TespitOzelKodGetir(LookUpEdit lue)
        {
            TespitOzelKodGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TespitOzelKodGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_TespitOzelKodGetir == null)
                {
                    _TespitOzelKodGetir = AvukatProLib2.Data.DataRepository.TD_KOD_TESPIT_OZELProvider.GetAll();
                }
                lue.DataSource = _TespitOzelKodGetir;
                lue.DisplayMember = "TESPIT_OZEL";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("TESPIT_OZEL", "Tespit Özel Kod", 40));
            }
        }

        public static bool? ToBoolen(object data)
        {
            if (data == null) return null;
            bool Donecek = false;

            if (bool.TryParse(data.ToString(), out Donecek))
            {
                return Donecek;
            }
            return false;
        }

        public static DateTime ToDateTime(object data)
        {
            DateTime Donecek = DateTime.Now;
            if (DateTime.TryParse(data.ToString(), out Donecek))
            {
                return Donecek;
            }
            return DateTime.Now;
        }

        //Yeni kur bilgisi girildiðinde Hesaptaki kurlarýn sýfýrlanýp yenilerinin gelmesini saðlamak için eklendi. MB 1 = Yeni Nesil Kurumsal Finans 0 = Diðerleri
        // Kredi borçlusunun taraf olduðu dosyalarda vekalet ücretinin klasör hesabýna gelmesini saðlamak için eklendi. MB
        public static int ToInt32(object data)
        {
            if (data == null)
                return 0;
            int Donecek = 0;
            if (int.TryParse(data.ToString(), out Donecek))
            {
                return Donecek;
            }
            return 0;
        }

        public static short ToShort(object data)
        {
            short Donecek = 0;
            if (short.TryParse(data.ToString(), out Donecek))
            {
                return Donecek;
            }
            return 0;
        }

        //TutuklanmaGelisTip
        public static void TutuklanmaGelisTipGetir(RepositoryItemLookUpEdit lue)
        {
            TutuklanmaGelisTipGetir_Enter(lue, EventArgs.Empty);
        }

        public static void TutuklanmaGelisTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                DataTable dt = new DataTable("TutuklanmaGelisTip");
                dt.Columns.Add("ID");
                dt.Columns.Add("TutuklanmaGelisTip");
                foreach (AvukatProLib.Extras.TutuklanmaGelisTip tipi in Enum.GetValues(typeof(AvukatProLib.Extras.TutuklanmaGelisTip)))
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
                lue.DataSource = dt;
                lue.DisplayMember = "TutuklanmaGelisTip";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("TutuklanmaGelisTip", 30, "Tutuklanma Geliþ Tipi"));
            }
        }

        public static void TutuklanmaTipGetir(RepositoryItemLookUpEdit rLue)
        {
            TutuklanmaTipGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void TutuklanmaTipGetir(LookUpEdit lue)
        {
            TutuklanmaTipGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void TutuklanmaTipGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_TutuklamaTipGetir == null)
                {
                    _TutuklamaTipGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_TUTUKLANMA_TIPProvider.GetAll();
                }
                rLue.DataSource = _TutuklamaTipGetir;
                rLue.NullText = "Seç";
                rLue.DisplayMember = "TUTUKLANMA_TIP";
                rLue.ValueMember = "ID";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("TUTUKLANMA_TIP", "Tutuklanma Tipi", 100));
            }
        }

        public static void UlkeGetir(RepositoryItemLookUpEdit lue)
        {
            UlkeGetir_Enter(lue, EventArgs.Empty);
        }

        public static void UlkeGetir(LookUpEdit lue)
        {
            UlkeGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void UlkeGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_UlkeGetir == null)
                {
                    _UlkeGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ULKEProvider.GetAll();
                }
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ULKE", 10, "Ülke") });
                lue.DataSource = _UlkeGetir;
                lue.DisplayMember = "ULKE";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void UrunAltKategoriGetir(RepositoryItemLookUpEdit rLue)
        {
            UrunAltKategoriGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void UrunAltKategoriGetir(LookUpEdit lue)
        {
            UrunAltKategoriGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void UrunAltKategoriGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_UrunAltKategoriGetir == null)
                {
                    _UrunAltKategoriGetir = AvukatProLib2.Data.DataRepository.per_TS_KOD_URUN_ALT_KATEGORIProvider.GetAll();
                }
                lue.DataSource = _UrunAltKategoriGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "URUN_ALT_KATEGORI_ADI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("URUN_ALT_KATEGORI_ADI", "Ürün Alt Kategori", 40));
            }
        }

        public static void UrunKategoriGetir(RepositoryItemLookUpEdit rLue)
        {
            UrunKategoriGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void UrunKategoriGetir(LookUpEdit lue)
        {
            UrunKategoriGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void UrunKategoriGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_UrunKategoriGetir == null)
                {
                    _UrunKategoriGetir = AvukatProLib2.Data.DataRepository.per_TS_KOD_URUN_KATEGORIProvider.GetAll();
                }
                lue.DataSource = _UrunKategoriGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "URUN_KATEGORI_ADI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("URUN_KATEGORI_ADI", "Ürün Kategori", 40));
            }
        }

        public static void UrunSinifKodlariGetir(RepositoryItemLookUpEdit rLue)
        {
            UrunSinifKodlariGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void UrunSinifKodlariGetir(LookUpEdit lue)
        {
            UrunSinifKodlariGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void UrunSinifKodlariGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_UrunSinifKodlariGetir == null)
                {
                    _UrunSinifKodlariGetir = AvukatProLib2.Data.DataRepository.per_TS_KOD_URUN_SINIF_KODLARIProvider.GetAll();
                }
                lue.DataSource = _UrunSinifKodlariGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "ADI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ADI", "Ürün Sýnýf Kodlarý", 40));
            }
        }

        public static void UyariTipDoldur(RepositoryItemLookUpEdit lue)
        {
            UyariTipDoldur_Enter(lue, EventArgs.Empty);
        }

        public static void UyariTipDoldur(LookUpEdit lue)
        {
            UyariTipDoldur_Enter(lue, EventArgs.Empty);
        }

        public static void UyariTipDoldur_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_UyariTipDoldur == null)
                    _UyariTipDoldur = AvukatProLib2.Data.DataRepository.per_TDIE_KOD_UYARI_TIPProvider.GetAll();

                lue.DataSource = _UyariTipDoldur;
                lue.DisplayMember = "UYARI";
                lue.NullText = "Seç";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("UYARI", 50, "Uyarýlar"));
                lue.Columns.Add(new LookUpColumnInfo("RENK", 50, "Renk"));
            }
        }

        public static void UyrukGetir(RepositoryItemLookUpEdit rLue)
        {
            UyrukGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void UyrukGetir(LookUpEdit lue)
        {
            UyrukGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void UyrukGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_UyrukGetir == null)
                {
                    _UyrukGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_UYRUKProvider.GetAll();
                }
                lue.DataSource = _UyrukGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "UYRUK";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("UYRUK", "Uyruk", 40));
            }
        }

        public static VList<VDI_BIL_IHTIYATI_TEDBIR_FOR_CARI_TAKIP> VDI_BIL_IHTIYATI_TEDBIR_FOR_CARI_TAKIPGetir()
        {
            if (_VDI_BIL_IHTIYATI_TEDBIR_FOR_CARI_TAKIP == null)
                _VDI_BIL_IHTIYATI_TEDBIR_FOR_CARI_TAKIP = DataRepository.VDI_BIL_IHTIYATI_TEDBIR_FOR_CARI_TAKIPProvider.GetAll();
            return _VDI_BIL_IHTIYATI_TEDBIR_FOR_CARI_TAKIP;
        }

        /// <summary>
        /// TDI_KOD_TEBLIGAT_KONU
        /// </summary>
        /// <param name="lue"></param
        public static void VekaletSozlesmeGetir(LookUpEdit lue)
        {
            VekaletSozlesmeGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void VekaletSozlesmeGetir(RepositoryItemLookUpEdit lue)
        {
            VekaletSozlesmeGetir_Enter(lue, EventArgs.Empty);
        }

        public static void VekaletSozlesmeGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_VekaletSozlesmeGetir == null)
                {
                    _VekaletSozlesmeGetir = DataRepository.per_TDI_KOD_SOZLESME_KATEGORILERIProvider.GetAll();
                }

                lue.DataSource = _VekaletSozlesmeGetir;
                lue.ValueMember = "ID";
                lue.DisplayMember = "AD";
                lue.NullText = "Seç";
                LookUpColumnInfo id = new LookUpColumnInfo("ID", 20);
                id.Visible = false;
                LookUpColumnInfo sozlesmeKategori = new LookUpColumnInfo("AD", 30, "Sözleþme Kategorisi");
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { id, sozlesmeKategori });
            }
        }

        public static List<AvukatProLib.Arama.per_TI_BIL_YASAL_SURE> YasalSureGetir()
        {
            if (_YasalSureGetir == null) _YasalSureGetir = context.per_TI_BIL_YASAL_SUREs.ToList();
            return _YasalSureGetir;
        }

        /// <summary>
        /// AV001_TDI_BIL_YAYIN
        /// </summary>
        /// <param name="lue"></param>
        public static void YayinkitapGetir(RepositoryItemLookUpEdit lue)
        {
            YayinkitapGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// AV001_TDI_BIL_YAYIN
        /// </summary>
        /// <param name="lue"></param
        public static void YayinkitapGetir(LookUpEdit lue)
        {
            YayinkitapGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void YayinkitapGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_YayinkitapGetir == null)
                {
                    _YayinkitapGetir = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_YAYINProvider.GetAll();
                }
                lue.DataSource = _YayinkitapGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "KITAP_ADI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("KITAP_ADI", "Kitap Adý", 100));
            }
        }

        public static void YayinTurleriGetir(RepositoryItemLookUpEdit rLue)
        {
            YayinTurleriGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void YayinTurleriGetir(LookUpEdit lue)
        {
            YayinTurleriGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void YayinTurleriGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_YayinTurleriGetir == null)
                {
                    _YayinTurleriGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_YAYIN_TURLERIProvider.GetAll();
                }
                lue.DataSource = _YayinTurleriGetir;
                lue.NullText = "Seç";
                lue.DisplayMember = "YAYIN_TURU";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("YAYIN_TURU", "Yayýn Türü", 40));
            }
        }

        public static void YazdirmaSablonlariniDoldur(CheckedComboBoxEdit ccbe)
        {
            VList<per_TDI_KOD_TEBLIGAT_SABLON> sablon = PerTebligatSablonGetir();

            foreach (per_TDI_KOD_TEBLIGAT_SABLON sbl in sablon)
            {
                ccbe.Properties.BeginUpdate();
                ccbe.Properties.Items.Add(sbl.SABLON_ADI, true);
                ccbe.Properties.EndUpdate();
            }
        }

        public static void YaziStilGetir(RepositoryItemLookUpEdit rLue)
        {
            YaziStilGetir_Enter(rLue, EventArgs.Empty);
        }

        public static void YaziStilGetir(LookUpEdit lue)
        {
            YaziStilGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        public static void YaziStilGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit rLue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (rLue.DataSource == null)
            {
                if (_YaziStilGetir == null)
                {
                    _YaziStilGetir = DataRepository.TDIE_KOD_YAZI_STILProvider.GetAll();
                }
                rLue.DataSource = _YaziStilGetir;
                rLue.DisplayMember = "YAZI_STIL_ISIM";
                rLue.ValueMember = "ID";
                rLue.NullText = "Seç";
                rLue.Columns.Clear();
                rLue.Columns.Add(new LookUpColumnInfo("YAZI_STIL_ISIM", 30, "Yazý Stilleri"));
            }
        }

        public static void YetkiliCariIsmiGetir(LookUpEdit lue)
        {
            YetkiliCariIsmiGetir_Enter(lue.Properties, EventArgs.Empty);
        }

        /// <summary>
        /// Bütün Carileri getiren method
        /// </summary>
        /// <param name="lue">Verilerin atanacaðý kontrol</param>
        public static void YetkiliCariIsmiGetir(RepositoryItemLookUpEdit lue)
        {
            YetkiliCariIsmiGetir_Enter(lue, EventArgs.Empty);
        }

        public static void YetkiliCariIsmiGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_YetkiliCariIsmiGetir_Enter == null)
                {
                    _YetkiliCariIsmiGetir_Enter = context.per_AV001_TDI_BIL_CARIs.Where(item => item.YETKILI_MI || item.PERSONEL_MI).ToList();
                }
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("AD", 30, "Ad") });
                lue.DataSource = _YetkiliCariIsmiGetir_Enter;

                //Get(" PERSONEL_MI='true' AND YETKILI_MI = 'TRUE'", "AD DESC");
                //Find("YETKILI_MI = 'TRUE' OR PERSONEL_MI = 'TRUE'");
                lue.NullText = "Seç";
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
            }
        }

        public static void YuzdeBicimiAyarla(RepositoryItemSpinEdit rud)
        {
            rud.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            rud.DisplayFormat.FormatString = "\'%\'##0.##";
            rud.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            rud.EditFormat.FormatString = "\'%\'##0.##";
        }

        #region <CC-20090612>

        //Faiz detaylarý önce sonramýsý için eklendi

        public static void FaizdenOnce(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("FaizIslemTipi");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (AvukatProLib.Extras.FaizTakipdenOnce tipi in Enum.GetValues(typeof(AvukatProLib.Extras.FaizTakipdenOnce)))
            {
                dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
            }
            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Faiz Takipden Once"));
        }

        #endregion <CC-20090612>

        #region <CC-20090613>

        //Masraf Onay için onaylandý Onaylanmadý eklendi

        public static void OnayDurumGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("OnayDurum");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (AvukatProLib.Extras.MasrafOnay tipi in Enum.GetValues(typeof(AvukatProLib.Extras.MasrafOnay)))
            {
                if ((int)tipi == 1 || (int)tipi == 2 || (int)tipi == 3)
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Remove(0, 1).Insert(0, ((int)tipi).ToString() + '.'));
                }

                else
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
            }

            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Onaylandý"));
        }

        public static void OnayDurumGetir(LookUpEdit lue)
        {
            DataTable dt = new DataTable("OnayDurum");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (AvukatProLib.Extras.MasrafOnay tipi in Enum.GetValues(typeof(AvukatProLib.Extras.MasrafOnay)))
            {
                if ((int)tipi == 1 || (int)tipi == 2 || (int)tipi == 3)
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Remove(0, 1).Insert(0, ((int)tipi).ToString() + '.'));
                }
                else
                {
                    dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                }
            }
            lue.Properties.DataSource = dt;
            lue.Properties.DisplayMember = "ACIKLAMA";
            lue.Properties.NullText = "Seç";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Onaylandý"));
        }

        #endregion <CC-20090613>

        #region <MB-20100526>

        //Sorumlu Avukat, personel mi, avukat mý bilgisine göre süzülüyordu. Bu koþullara carinin aktif kullanýcý olup olmadýðý kontrolü de eklendi.

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> AktifAvukatlar;

        public static void AktifAvukatlariGetir(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 20, "Kod"), new LookUpColumnInfo("AD", 20, "Ad") });
            lue.DataSource = AktifAvukatlariGetir();
            lue.DisplayMember = "AD";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        public static void AktifAvukatlariGetir(RepositoryItemGridLookUpEdit glue)
        {
            glue.DataSource = AktifAvukatlariGetir();
            glue.ValueMember = "ID";
            glue.DisplayMember = "AD";
            glue.NullText = "Seç";
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> AktifAvukatlariGetir()
        {
            if (AktifAvukatlar != null) return AktifAvukatlar;
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> sorumluAvukatList = SorumluAvukatGetir();
            AktifAvukatlar = sorumluAvukatList.Where(sa => BelgeUtil.Inits.context.TDI_BIL_KULLANICI_LISTESIs.Count(item => item.CARI_ID == sa.ID && item.KULLANICI_AKTIF) > 0).ToList();
            return AktifAvukatlar;
        }

        #endregion <MB-20100526>

        #region <cc-20090620>

        // Odemekim adina ýnitsi yapýldý
        public static void OdemeKimAdina(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("OdemeKimAdina");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (AvukatProLib.Extras.OdemeKimAdina tur in Enum.GetValues(typeof(AvukatProLib.Extras.OdemeKimAdina)))
            {
                dt.Rows.Add((int)tur, tur.ToString());
            }
            lue.DataSource = dt;
            lue.ValueMember = "ID";
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 20, "Sözleþme Þekli"));
        }

        #endregion <cc-20090620>

        #region Metotlar

        public static TList<AV001_TDI_BIL_CARI> cariList = null;

        public static VList<per_TDI_KOD_ILCE> ILCElistem;

        public static VList<per_TDI_KOD_IL> ILlistem;

        public static void AdliBirimNoGetir(LookUpEdit[] lues)
        {
            foreach (var item in lues)
            {
                AdliBirimNoGetir_Enter(item.Properties, EventArgs.Empty);
            }
        }

        public static void AdliyeGetir(LookUpEdit[] lues)
        {
            foreach (var item in lues)
            {
                AdliyeGetir_Enter(item.Properties, EventArgs.Empty);
            }
        }

        public static void AdliyeGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (_AdliBirimAdliyeGetir == null)
                    _AdliBirimAdliyeGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetAll();
                VList<per_TDI_KOD_ADLI_BIRIM_ADLIYE> listem = _AdliBirimAdliyeGetir;

                lue.Columns.Clear();
                lue.DataSource = listem;
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ADLIYE", 20, "Adliye"), new LookUpColumnInfo("IL", 20, "Ýl"), new LookUpColumnInfo("ILCE", 20, "Ýlce") });
                lue.DisplayMember = "ADLIYE";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        public static void BankaGetir(LookUpEdit[] lues)
        {
            foreach (var item in lues)
            {
                BankaGetir_Enter(item.Properties, EventArgs.Empty);
            }
        }

        public static void BankaSubeGetir(LookUpEdit[] lues)
        {
            VList<VDI_KOD_BANKA_SUBE> listem = AvukatProLib2.Data.DataRepository.VDI_KOD_BANKA_SUBEProvider.GetAll();
            foreach (LookUpEdit lue in lues)
            {
                lue.Properties.DataSource = listem;
                lue.Properties.DisplayMember = "SUBE";
                lue.Properties.ValueMember = "ID";
                lue.Properties.NullText = "Seç";
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.AddRange(new LookUpColumnInfo[]
            {
                new LookUpColumnInfo("SUBE", 20, "Sube"), new LookUpColumnInfo("BOLGE", 20, "Bölge")
            });
            }
        }

        public static void BankaSubelerGetir(LookUpEdit[] lues)
        {
            foreach (var item in lues)
            {
                BankaSubelerGetir_Enter(item.Properties, EventArgs.Empty);
            }
        }

        public static void BankaSubelerGetir(RepositoryItemLookUpEdit lue)
        {
            BankaSubelerGetir_Enter(lue, EventArgs.Empty);
        }

        public static void BankaSubelerGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                VList<VDI_KOD_BANKA_SUBE> listem = AvukatProLib2.Data.DataRepository.VDI_KOD_BANKA_SUBEProvider.GetAll();

                lue.DataSource = listem;
                lue.ValueMember = "ID";
                lue.DisplayMember = "SUBE";
                lue.NullText = "Seç";
                LookUpColumnInfo ID = new LookUpColumnInfo("ID", 20);
                ID.Visible = false;
                LookUpColumnInfo SUBE = new LookUpColumnInfo("SUBE", 40, "Banka Þubesi");
                lue.Columns.Clear();

                //lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { ID, SUBE });
            }
        }

        public static void CariGetir(LookUpEdit[] lues)
        {
            foreach (var item in lues)
            {
                CariGetir_Enter(item.Properties, EventArgs.Empty);
            }
        }

        public static void FoyOzelDurumGetir(LookUpEdit[] lues)
        {
            foreach (var item in lues)
            {
                FoyOzelDurumGetir_Enter(item.Properties, EventArgs.Empty);
            }
        }

        public static void FoyOzelKodGetir(LookUpEdit[] lues)
        {
            VList<per_AV001_TDI_KOD_FOY_OZEL> listem = AvukatProLib2.Data.DataRepository.per_AV001_TDI_KOD_FOY_OZELProvider.GetAll();
            foreach (LookUpEdit lue in lues)
            {
                lue.Properties.DataSource = listem;
                lue.Properties.DisplayMember = "KOD";
                lue.Properties.ValueMember = "ID";
                lue.Properties.NullText = "Seç";
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 20, "Kod") });
            }
        }

        public static void IlceGetir(LookUpEdit[] lues)
        {
            foreach (var item in lues)
            {
                IlceGetir_Enter(item.Properties, EventArgs.Empty);
            }
        }

        public static void IlceGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                if (ILCElistem == null)
                    ILCElistem = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ILCEProvider.GetAll();

                lue.DataSource = ILCElistem;
                lue.DisplayMember = "ILCE";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ILCE", 10, "Ýlçe") });
            }
        }

        public static void IlGetir(LookUpEdit[] lues)
        {
            foreach (var item in lues)
            {
                IlGetir_Enter(item.Properties, EventArgs.Empty);
            }
        }

        public static void KrediGrubuGetir(LookUpEdit[] lues)
        {
            foreach (var item in lues)
            {
                KrediGrubuGetir_Enter(item.Properties, EventArgs.Empty);
            }
        }

        public static void KrediGrubuGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                VList<per_TDI_KOD_KREDI_GRUP> listem = AvukatProLib2.Data.DataRepository.per_TDI_KOD_KREDI_GRUPProvider.GetAll();

                lue.DataSource = listem;
                lue.DisplayMember = "KREDI_GRUP";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("KREDI_GRUP", 10, "Kredi Grubu"));
            }
        }

        public static void KrediTipiGetir(LookUpEdit[] lues)
        {
            foreach (var item in lues)
            {
                KrediTipiGetir_Enter(item.Properties, EventArgs.Empty);
            }
        }

        public static void SemtGetir(LookUpEdit[] lues)
        {
            foreach (var item in lues)
            {
                SemtGetir_Enter(item.Properties, EventArgs.Empty);
            }
        }

        public static void TakipKonusuGetir(LookUpEdit[] lues)
        {
            foreach (var item in lues)
            {
                TakipKonusuGetir_Enter(item.Properties, EventArgs.Empty);
            }
        }

        public static void UlkeGetir(LookUpEdit[] lues)
        {
            foreach (var item in lues)
            {
                UlkeGetir_Enter(item.Properties, EventArgs.Empty);
            }
        }

        #endregion Metotlar

        #region<CC-20090619>

        #endregion</CC-20090619>

        #region <KA-20090620>

        // Etiketin dolmasý saðlandý.

        #endregion </KA-20090620>

        #region <KA-20090624>

        // Ýþ Durum dolmasý saðlandý.

        #endregion </KA-20090624>

        #region <KA-20090703>

        // Hatýrlatma Periyot Doldurma.

        #endregion </KA-20090703>
    }
}