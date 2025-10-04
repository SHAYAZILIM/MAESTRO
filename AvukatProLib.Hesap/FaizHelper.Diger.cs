using AvukatProLib.Extras;
using AvukatProLib2.Data;

//using AdimAdimDavaKaydi.Util;
using AvukatProLib2.Entities;
using System;

namespace AvukatProLib.Hesap
{
    public enum MahsupAltKategori
    {
        Ihtiyati_Tedbir_Vekalet_Ucreti = 1,
        Ilam_Vekalet_Ucreti = 2,
        Takip_Vekalet_Ucreti = 3,
        Dava_Vekalet_Ucreti = 4,
        Tahliye_Davasi_Vekalet_Ucreti = 5,
        Damga_Pulu = 6,
        Basvurma_Harci = 7,
        Pesin_Harc = 8,
        Masaya_Katilma_Harci = 9,
        Paylasma_Harci = 10,
        Vekalet_pulu = 11,
        Vekalet_Harci = 12,
        Tahliye_Harci = 13,
        Teslim_Harci = 14,
        Feragat_Harci = 15,
        Ilam_Bakiye_Karar_Harci = 16,
        Yargitay_Onama_Harci = 17,
        Dava_Inkar_Tazminati = 18,
        Icra_Inkar_Tazminati = 19,
        Cek_Tazminati = 20,
        Ilam_Inkar_Tazminati = 21,
        Ozel_Tazminat = 22,
        Birikmis_Tazminatlar = 23,
        Cek_Komisyonu = 24,
        Takip_Oncesi_Giderler = 25,
        Ihtiyati_Haciz_Gideri = 26,
        Ihtiyati_Tedbir_Gideri = 27,
        Protesto_Gideri = 28,
        Ihtar_Gideri = 29,
        Ilk_Giderler = 30,
        Dava_Giderleri = 31,
        Diger_Giderler = 32,
        Tahliye_Davasi_Teblig_Gideri = 33,
        Ilam_Yargilama_Giderleri = 34,
        Ilam_Teblig_Gideri = 35,
        Islemis_Faiz = 36,
        Sonraki_Faiz = 37,
        TO_BSMV = 38,
        TO_KKDF = 39,
        TO_OIV = 40,
        TO_KDV = 41,
        Odenen_Tahsil_Harci = 42,
        Kalan_Tahsil_Harci = 43,
        TS_BSMV = 44,
        TS_OIV = 45,
        TS_KDV = 46,
        Sonraki_Nafaka = 47,
        Alacak_Neden = 48,
        Ozel_Tutar_1 = 50,
        Ozel_Tutar_2 = 51,
        Ozel_Tutar_3 = 52,
        Ozel_Tutar_4 = 53,
        dvDava_Deðeri = 54,
        dvDava_Öncesi_Faiz = 55,
        dvSonraki_Faiz = 56,
        dvDiðer_Dava_Giderleri = 57,
        dvDiðer_Talep_Giderleri = 58,
        dvÝhtar_Gideri = 59,
        dvProtesto_Gideri = 60,
        dvTedbir_Giderleri = 61,
        dvTespit_Giderleri = 62,
        dvBakiye_Karar_ve_Ýlam_Harcý = 63,
        dvKarar_Düzeltme_Harcý = 64,
        dvPeþin_Harç = 65,
        dvTemyiz_Harcý = 66,
        dvBirikmiþ_Tazminat = 67,
        dvCezai_Þart_Toplamý = 68,
        dvÖzel_Tutar_1 = 69,
        dvÖzel_Tutar_2 = 70,
        dvÖzel_Tutar_3 = 71,
        dvTazminat = 72,
        dvAdli_Yardým_Vekalet_Ücreti = 73,
        dvCMK_Vekalet_Ücreti = 74,
        dvDava_Edilen_Vekalet_Ücreti = 75,
        dvÝstinaf_Vekalet_Ücreti = 76,
        dvTedbir_Vekalet_Ücreti = 77,
        dvTemyiz_Vekalet_Ücreti = 78,
        dvTespit_Vekalet_Ücreti = 79,
    }

    public enum MahsupKategori
    {
        Asil_Alacak = 2,
        Vekalet_Ucreti = 4,
        Harclar = 5,
        Tazminatlar = 6,
        Masraflar = 7,
        Faizler = 8,
        Vergiler = 9,
        Diger = 10,
        Diger_Asil_Alacak = 11
    }

    public enum Takip
    {
        Oncesi,
        Sonrasi
    }

    public enum VekaketUcretTipNo
    {
        Maktu = 0,
        Nispi = 1
    }

    public enum VekaletUcretKalemi
    {
        NispiTakipVekUcr = 0,
        MaktuTahliyeVekUcr = 2,
        MaktuTakipVekUcr = 3,
        MaktuIlamVekUcr = 4,
        NispiTakipVekUcrTaraf = 11,
        MaktuTakipVekUcrTaraf = 12,
        MaktuIhtiyatiHacizVekUcr = 21,
        MaktuIhtiyatiTedbirVekUcr = 22
    }

    public partial class FaizHelper
    {
        public static IcraNispiHarcTipi FeragatHarcTipiGetirByTarih(AV001_TI_BIL_FOY foy, DateTime dt)
        {
            IcraNispiHarcTipi result = IcraNispiHarcTipi.VAZGECME_HACiZDEN_ONCE;
            foreach (AV001_TI_BIL_HACIZ_MASTER haciz in foy.AV001_TI_BIL_HACIZ_MASTERCollection)
            {
                if (haciz.HACIZ_TARIHI <= dt)
                {
                    result = IcraNispiHarcTipi.VAZGECME_HACiZDEN_SONRA;
                }
            }
            foreach (AV001_TI_BIL_SATIS_MASTER satis in foy.AV001_TI_BIL_SATIS_MASTERCollection)
            {
                if (satis.SATIS_TARIHI_1.HasValue && satis.SATIS_TARIHI_1.Value <= dt)
                {
                    result = IcraNispiHarcTipi.VAZGECME_SATiSTAN_SONRA;
                }
            }
            return result;
        }

        public static decimal FoyKalemAlacakNedenineGoreOncekiMahsupGetir(AV001_TI_BIL_FOY foy, MahsupAltKategori mahsupAltKategoriId, AV001_TI_BIL_ALACAK_NEDEN alacakNeden)
        {
            decimal result = 0;
            TList<AV001_TI_BIL_ODEME_DAGILIM> listem =
                foy.AV001_TI_BIL_ODEME_DAGILIMCollection.FindAll(
                    AV001_TI_BIL_ODEME_DAGILIMColumn.MAHSUP_ALT_KATEGORI_ID,
                    (int)mahsupAltKategoriId);
            foreach (AV001_TI_BIL_ODEME_DAGILIM dagilim in listem)
            {
                if (dagilim.ALACAK_NEDEN_IDSource == alacakNeden && alacakNeden != null && dagilim.DAGILIM_TIPI == 1)
                {
                    result += dagilim.TUTAR;
                }
            }
            return result;
        }

        public static decimal FoyKalemAlacakNedenineGoreOncekiMahsupGetirTaraf(AV001_TI_BIL_FOY foy, MahsupAltKategori mahsupAltKategoriId, AV001_TI_BIL_FOY_TARAF taraf)
        {
            decimal result = 0;
            TList<AV001_TI_BIL_ODEME_DAGILIM> listem =
                foy.AV001_TI_BIL_ODEME_DAGILIMCollection.FindAll(
                    AV001_TI_BIL_ODEME_DAGILIMColumn.MAHSUP_ALT_KATEGORI_ID,
                    (int)mahsupAltKategoriId);
            foreach (AV001_TI_BIL_ODEME_DAGILIM dagilim in listem)
            {
                if (dagilim.DAGILIM_TIPI == 2 && ((dagilim.FOY_TARAF_IDSource == taraf && taraf != null) || (taraf != null && dagilim.FOY_TARAF_ID == taraf.ID)))
                {
                    result += dagilim.TUTAR;
                }
            }
            return result;
        }

        public static decimal FoyKalemAlacakNedenineGoreOncekiMahsupGetirTaraf(AV001_TI_BIL_FOY foy, MahsupAltKategori mahsupAltKategoriId, AV001_TI_BIL_ALACAK_NEDEN_TARAF taraf)
        {
            decimal result = 0;
            TList<AV001_TI_BIL_ODEME_DAGILIM> listem =
                foy.AV001_TI_BIL_ODEME_DAGILIMCollection.FindAll(
                    AV001_TI_BIL_ODEME_DAGILIMColumn.MAHSUP_ALT_KATEGORI_ID,
                    (int)mahsupAltKategoriId);
            foreach (AV001_TI_BIL_ODEME_DAGILIM dagilim in listem)
            {
                if (dagilim.DAGILIM_TIPI == 2 && ((dagilim.ALACAK_NEDEN_TARAF_IDSource == taraf && taraf != null) || (taraf != null && dagilim.ALACAK_NEDEN_TARAF_ID.HasValue && dagilim.ALACAK_NEDEN_TARAF_ID.Value == taraf.ID)))
                {
                    result += dagilim.TUTAR;
                }
            }
            return result;
        }

        public static decimal FoyKalemIlamaGoreOncekiMahsupGetir(AV001_TI_BIL_FOY foy, MahsupAltKategori mahsupAltKategoriId, AV001_TI_BIL_ILAM_MAHKEMESI ilam)
        {
            decimal result = 0;
            TList<AV001_TI_BIL_ODEME_DAGILIM> listem =
                foy.AV001_TI_BIL_ODEME_DAGILIMCollection.FindAll(
                    AV001_TI_BIL_ODEME_DAGILIMColumn.MAHSUP_ALT_KATEGORI_ID,
                    (int)mahsupAltKategoriId);
            foreach (AV001_TI_BIL_ODEME_DAGILIM dagilim in listem)
            {
                if (dagilim.ILAM_IDSource == ilam && ilam != null)
                {
                    result += dagilim.TUTAR;
                }
            }
            return result;
        }

        public static decimal FoyKalemOncekiMahsupTutariGetir(AV001_TI_BIL_FOY foy, MahsupAltKategori mahsupAltKategoriId, Takip hesapAraligi)
        {
            //Foy uzerinde kaleme(MahsupAltKategoriId) ait önceki mahsuplarý buluyoruz
            TList<AV001_TI_BIL_ODEME_DAGILIM> listem = foy.AV001_TI_BIL_ODEME_DAGILIMCollection.FindAll(AV001_TI_BIL_ODEME_DAGILIMColumn.MAHSUP_ALT_KATEGORI_ID,
                                                                                                        (int)mahsupAltKategoriId);

            decimal result = 0;
            //Foy uzerinde kaleme(MahsupAltKategoriId) ait önceki mahsuplarý  topluyoruz
            foreach (AV001_TI_BIL_ODEME_DAGILIM dagilim in listem)
            {
                //hesapAraligi Takip.Oncesi ise ve odeme tarihi takip oncesine denk geliyor  yada
                //hesapAraligi Takip.Sonrasi ise ve odeme tarihi takip sonrasina denk geliyor ise
                //degeri sonuca ekliyoruz
                //TODO:Burasý neden takip aralýðýna bakmýyor ? Sanýrým ne kadar düþüldüðünü bulmak için bakmamasý normal...
                //TODO:Mahsup hesabý burda biþiyler ters gidebilir **
                //if((hesapAraligi == Takip.Oncesi && dagilim.ODEME_TARIHI.Date <= foy.TAKIP_TARIHI.Value.Date) ||
                //   (hesapAraligi == Takip.Sonrasi && dagilim.ODEME_TARIHI.Date > foy.TAKIP_TARIHI.Value.Date))
                //{
                result += dagilim.TUTAR;
                //}
            }
            return result;
        }

        public static decimal FoyKalemOncekiMahsupTutariGetir(AV001_TI_BIL_FOY_TARAF taraf, MahsupAltKategori mahsupAltKategoriId, Takip hesapAraligi)
        {
            //Foy uzerinde kaleme(MahsupAltKategoriId) ait önceki mahsuplarý buluyoruz
            TList<AV001_TI_BIL_ODEME_DAGILIM> listem = taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.FindAll(AV001_TI_BIL_ODEME_DAGILIMColumn.MAHSUP_ALT_KATEGORI_ID,
                                                                                                          (int)mahsupAltKategoriId);

            decimal result = 0;
            //Foy uzerinde kaleme(MahsupAltKategoriId) ait önceki mahsuplarý  topluyoruz
            foreach (AV001_TI_BIL_ODEME_DAGILIM dagilim in listem)
            {
                //hesapAraligi Takip.Oncesi ise ve odeme tarihi takip oncesine denk geliyor  yada
                //hesapAraligi Takip.Sonrasi ise ve odeme tarihi takip sonrasina denk geliyor ise
                //degeri sonuca ekliyoruz
                //TODO:Mahsup hesabý burda biþiyler ters gidebilir **
                //if((hesapAraligi == Takip.Oncesi && dagilim.ODEME_TARIHI.Date <= foy.TAKIP_TARIHI.Value.Date) ||
                //   (hesapAraligi == Takip.Sonrasi && dagilim.ODEME_TARIHI.Date > foy.TAKIP_TARIHI.Value.Date))
                //{
                result += dagilim.TUTAR;
                //}
            }
            return result;
        }

        public static TList<AV001_TI_BIL_ODEME_DAGILIM> IcraOdemeDagilimGetir()
        {
            TList<AV001_TI_BIL_ODEME_DAGILIM> result = new TList<AV001_TI_BIL_ODEME_DAGILIM>();

            AV001_TI_BIL_ODEME_DAGILIM odemeDagilim = result.AddNew();
            //odemeDagilim.

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="feragat">feragat kalemi</param>
        /// <param name="foy">iþlem yapýlacak föy</param>
        /// <returns>kalan tutar</returns>
        public static decimal MahsupDusgetir(AV001_TI_BIL_FERAGAT feragat, AV001_TI_BIL_FOY foy)
        {
            if (feragat == null || foy == null)
                return -1;
            decimal odeme = DovizHelper.CevirYTL(feragat.FERAGAT_MIKTAR, feragat.FERAGAT_MIKTAR_DOVIZ_ID,
                                                 feragat.FERAGAT_TARIHI);
            MahsupAltKategori mahsupAltKategoriId = (MahsupAltKategori)feragat.MAHSUP_ALT_KATEGORI_ID;
            Takip hesapAraligi = Takip.Oncesi;
            if (foy.TAKIP_TARIHI.HasValue && feragat.FERAGAT_TARIHI >= foy.TAKIP_TARIHI.Value)
                hesapAraligi = Takip.Sonrasi;
            DateTime odemeTarihi = feragat.FERAGAT_TARIHI;
            AV001_TI_BIL_ODEME_DAGILIM dagit = foy.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
            dagit.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
            //EKLENTI : gkn
            dagit.MAHSUP_KATEGORI_ID = DataRepository.TDI_KOD_MAHSUP_ALT_KATEGORIProvider.GetByID((int)mahsupAltKategoriId).MAHSUP_KATEGORI_ID;
            dagit.TUTAR_DOVIZ_ID = 1; //YTL
            dagit.TUTAR_KUR = 1;
            dagit.ODEME_TARIHI = odemeTarihi;
            feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagit);
            //dagit.FOY_TARAF_IDSource = foyTarafGetir(feragat, foy);
            dagit.DAGILIM_TIPI = 1;

            decimal fyKalem;
            switch (mahsupAltKategoriId)
            {
                #region Case DigerAlacak

                case MahsupAltKategori.Takip_Vekalet_Ucreti:
                case MahsupAltKategori.Dava_Vekalet_Ucreti:
                case MahsupAltKategori.Tahliye_Davasi_Vekalet_Ucreti:
                case MahsupAltKategori.Pesin_Harc:
                case MahsupAltKategori.Masaya_Katilma_Harci:
                case MahsupAltKategori.Paylasma_Harci:
                case MahsupAltKategori.Tahliye_Harci:
                case MahsupAltKategori.Teslim_Harci:
                case MahsupAltKategori.Feragat_Harci:
                case MahsupAltKategori.Dava_Inkar_Tazminati:
                case MahsupAltKategori.Icra_Inkar_Tazminati:
                case MahsupAltKategori.Birikmis_Tazminatlar:
                case MahsupAltKategori.Dava_Giderleri:
                case MahsupAltKategori.Diger_Giderler:
                case MahsupAltKategori.Tahliye_Davasi_Teblig_Gideri:
                case MahsupAltKategori.Sonraki_Faiz:
                case MahsupAltKategori.TS_BSMV:
                case MahsupAltKategori.TS_KDV:
                case MahsupAltKategori.TS_OIV:
                case MahsupAltKategori.Sonraki_Nafaka:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = GetTLTutarByMahsupAltKategori(foy, mahsupAltKategoriId, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Ihtiyati_Tedbir_Vekalet_Ucreti:
                case MahsupAltKategori.Vekalet_pulu:
                case MahsupAltKategori.Vekalet_Harci:
                case MahsupAltKategori.Odenen_Tahsil_Harci:
                case MahsupAltKategori.Cek_Tazminati:
                case MahsupAltKategori.Ozel_Tazminat:
                case MahsupAltKategori.Damga_Pulu:
                case MahsupAltKategori.Basvurma_Harci:
                case MahsupAltKategori.Cek_Komisyonu:
                case MahsupAltKategori.Ihtiyati_Haciz_Gideri:
                case MahsupAltKategori.Ihtiyati_Tedbir_Gideri:
                case MahsupAltKategori.Protesto_Gideri:
                case MahsupAltKategori.Ihtar_Gideri:
                case MahsupAltKategori.Islemis_Faiz:
                case MahsupAltKategori.TO_BSMV:
                case MahsupAltKategori.TO_KDV:
                case MahsupAltKategori.TO_KKDF:
                case MahsupAltKategori.TO_OIV:

                    fyKalem = GetTLTutarByMahsupAltKategori(foy, mahsupAltKategoriId, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                #region comment

                case MahsupAltKategori.Takip_Oncesi_Giderler:
                    //Bu burda olmýycak
                    break;

                case MahsupAltKategori.Ilk_Giderler:
                    //YOK
                    break;

                case MahsupAltKategori.Kalan_Tahsil_Harci:
                    //if (hesapAraligi == Takip.Oncesi)
                    //    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    //fyKalem = DovizHelper.CevirYTL(foy.KALAN_TAHSIL_HARCI, foy.KALAN_TAHSIL_HARCI_DOVIZ_ID, odemeTarihi) -
                    //          FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    //if (fyKalem <= 0)
                    //    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    //if (fyKalem < odeme)
                    //{
                    //    dagit.TUTAR = fyKalem;
                    //    return odeme - fyKalem;
                    //}
                    //else if (fyKalem > odeme)
                    //{
                    //    dagit.TUTAR = odeme;
                    //    return 0;
                    //}
                    //else if (fyKalem == odeme)
                    //{
                    //    dagit.TUTAR = fyKalem;
                    //    return 0;
                    //}
                    break;

                case MahsupAltKategori.Yargitay_Onama_Harci:
                    //Yukardakine yapýyoruz
                    break;

                #endregion comment

                #endregion Case DigerAlacak

                #region case AsilAlacak

                case MahsupAltKategori.Alacak_Neden:
                case MahsupAltKategori.Ilam_Vekalet_Ucreti:
                case MahsupAltKategori.Ilam_Yargilama_Giderleri:
                case MahsupAltKategori.Ilam_Teblig_Gideri:
                case MahsupAltKategori.Ilam_Inkar_Tazminati:
                case MahsupAltKategori.Ilam_Bakiye_Karar_Harci:
                    int stat = 0;
                    decimal miktar = odeme;
                    while (stat < 9)
                    {
                        feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);

                        AV001_TI_BIL_ODEME_DAGILIM dagilim = foy.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                        dagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
                        dagilim.MAHSUP_KATEGORI_ID = DataRepository.TDI_KOD_MAHSUP_ALT_KATEGORIProvider.GetByID((int)mahsupAltKategoriId).MAHSUP_KATEGORI_ID;
                        dagilim.TUTAR_DOVIZ_ID = 1; //YTL
                        dagilim.TUTAR_KUR = 1;
                        dagilim.ODEME_TARIHI = odemeTarihi;
                        //dagilim.FOY_TARAF_IDSource = foyTarafGetir(feragat, foy);
                        dagilim.DAGILIM_TIPI = 1;
                        if (mahsupAltKategoriId == MahsupAltKategori.Alacak_Neden)
                            miktar = AlacakNedenUzerindenDus(foy, feragat, dagilim, miktar, out stat);
                        else
                            miktar = IlamUzerindenDus(foy, feragat, dagilim, miktar, out stat, mahsupAltKategoriId);

                        if (stat == 11 || dagilim.TUTAR == 0)
                        {
                            foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagilim);
                        }
                        else
                        {
                            feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagilim);
                        }
                    }
                    return miktar;

                #endregion case AsilAlacak

                default:
                    System.Diagnostics.Debug.WriteLine("Bak bi----- FaizHelper.Dava.cs Line 577");
                    break;
            }
            return odeme;
        }

        public static decimal MahsupDusgetir(AV001_TI_BIL_BORCLU_ODEME bOdeme, decimal odeme, MahsupAltKategori mahsupAltKategoriId, AV001_TI_BIL_FOY foy, Takip hesapAraligi)
        {
            if (odeme <= 0 || bOdeme == null || foy == null)
                return -1;
            DateTime odemeTarihi = bOdeme.ODEME_TARIHI;
            AV001_TI_BIL_ODEME_DAGILIM dagit = foy.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
            dagit.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
            dagit.MAHSUP_KATEGORI_ID = DataRepository.TDI_KOD_MAHSUP_ALT_KATEGORIProvider.GetByID((int)mahsupAltKategoriId).MAHSUP_KATEGORI_ID;

            dagit.TUTAR_DOVIZ_ID = 1; //YTL
            dagit.TUTAR_KUR = 1;
            dagit.ODEME_TARIHI = odemeTarihi;
            bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagit);
            dagit.FOY_TARAF_IDSource = foyTarafGetir(bOdeme, foy);
            dagit.DAGILIM_TIPI = 1;
            decimal fyKalem;
            switch (mahsupAltKategoriId)
            {
                #region Case DigerAlacak

                case MahsupAltKategori.Takip_Vekalet_Ucreti:
                case MahsupAltKategori.Dava_Vekalet_Ucreti:
                case MahsupAltKategori.Tahliye_Davasi_Vekalet_Ucreti:
                case MahsupAltKategori.Pesin_Harc:
                case MahsupAltKategori.Masaya_Katilma_Harci:
                case MahsupAltKategori.Paylasma_Harci:
                case MahsupAltKategori.Tahliye_Harci:
                case MahsupAltKategori.Teslim_Harci:
                case MahsupAltKategori.Feragat_Harci:
                case MahsupAltKategori.Dava_Inkar_Tazminati:
                case MahsupAltKategori.Icra_Inkar_Tazminati:
                case MahsupAltKategori.Birikmis_Tazminatlar:
                case MahsupAltKategori.Dava_Giderleri:
                case MahsupAltKategori.Diger_Giderler:
                case MahsupAltKategori.Tahliye_Davasi_Teblig_Gideri:
                case MahsupAltKategori.Sonraki_Faiz:
                case MahsupAltKategori.TS_BSMV:
                case MahsupAltKategori.TS_KDV:
                case MahsupAltKategori.TS_OIV:
                case MahsupAltKategori.Sonraki_Nafaka:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = GetTLTutarByMahsupAltKategori(foy, mahsupAltKategoriId, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Ihtiyati_Tedbir_Vekalet_Ucreti:
                case MahsupAltKategori.Vekalet_pulu:
                case MahsupAltKategori.Vekalet_Harci:
                case MahsupAltKategori.Odenen_Tahsil_Harci:
                case MahsupAltKategori.Cek_Tazminati:
                case MahsupAltKategori.Ozel_Tazminat:
                case MahsupAltKategori.Damga_Pulu:
                case MahsupAltKategori.Basvurma_Harci:
                case MahsupAltKategori.Cek_Komisyonu:
                case MahsupAltKategori.Ihtiyati_Haciz_Gideri:
                case MahsupAltKategori.Ihtiyati_Tedbir_Gideri:
                case MahsupAltKategori.Protesto_Gideri:
                case MahsupAltKategori.Ihtar_Gideri:
                case MahsupAltKategori.Islemis_Faiz:
                case MahsupAltKategori.TO_BSMV:
                case MahsupAltKategori.TO_KDV:
                case MahsupAltKategori.TO_KKDF:
                case MahsupAltKategori.TO_OIV:

                    fyKalem = GetTLTutarByMahsupAltKategori(foy, mahsupAltKategoriId, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                #region comment

                case MahsupAltKategori.Takip_Oncesi_Giderler:
                    //Bu burda olmýycak
                    break;

                case MahsupAltKategori.Ilk_Giderler:
                    //YOK
                    break;

                case MahsupAltKategori.Kalan_Tahsil_Harci:
                    //if (hesapAraligi == Takip.Oncesi)
                    //    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    //fyKalem = DovizHelper.CevirYTL(foy.KALAN_TAHSIL_HARCI, foy.KALAN_TAHSIL_HARCI_DOVIZ_ID, odemeTarihi) -
                    //          FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    //if (fyKalem <= 0)
                    //    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    //if (fyKalem < odeme)
                    //{
                    //    dagit.TUTAR = fyKalem;
                    //    return odeme - fyKalem;
                    //}
                    //else if (fyKalem > odeme)
                    //{
                    //    dagit.TUTAR = odeme;
                    //    return 0;
                    //}
                    //else if (fyKalem == odeme)
                    //{
                    //    dagit.TUTAR = fyKalem;
                    //    return 0;
                    //}
                    break;

                case MahsupAltKategori.Yargitay_Onama_Harci:
                    //Yukardakine yapýyoruz
                    break;

                #endregion comment

                #endregion Case DigerAlacak

                #region case AsilAlacak

                case MahsupAltKategori.Alacak_Neden:
                case MahsupAltKategori.Ilam_Vekalet_Ucreti:
                case MahsupAltKategori.Ilam_Yargilama_Giderleri:
                case MahsupAltKategori.Ilam_Teblig_Gideri:
                case MahsupAltKategori.Ilam_Inkar_Tazminati:
                case MahsupAltKategori.Ilam_Bakiye_Karar_Harci:
                    int stat = 0;
                    decimal miktar = odeme;
                    while (stat < 9)
                    {
                        bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);

                        AV001_TI_BIL_ODEME_DAGILIM dagilim = foy.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                        dagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
                        dagilim.MAHSUP_KATEGORI_ID = DataRepository.TDI_KOD_MAHSUP_ALT_KATEGORIProvider.GetByID((int)mahsupAltKategoriId).MAHSUP_KATEGORI_ID;
                        dagilim.TUTAR_DOVIZ_ID = 1; //YTL
                        dagilim.TUTAR_KUR = 1;
                        dagilim.ODEME_TARIHI = odemeTarihi;
                        //dagilim.FOY_TARAF_IDSource = foyTarafGetir(bOdeme, foy);
                        dagilim.DAGILIM_TIPI = 1;
                        if (mahsupAltKategoriId == MahsupAltKategori.Alacak_Neden)
                            miktar = AlacakNedenUzerindenDus(foy, bOdeme, dagilim, miktar, out stat);
                        else
                            miktar = IlamUzerindenDus(foy, bOdeme, dagilim, miktar, out stat, mahsupAltKategoriId);

                        if (stat == 11 || dagilim.TUTAR == 0)
                        {
                            foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagilim);
                        }
                        else
                        {
                            bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagilim);
                        }
                    }
                    return miktar;

                #endregion case AsilAlacak

                default:
                    System.Diagnostics.Debug.WriteLine("Bak bi----- FaizHelper.Dava.cs Line 1089");
                    break;
            }
            return odeme;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bOdeme">borçlu ödeme</param>
        /// <param name="odeme">ytl</param>
        /// <param name="mahsupAltKategoriId">kalemin adý/id si</param>
        /// <param name="foy">iþlem yapýlacak föy</param>
        /// <param name="hesapAraligi">iþlem yapýlacak hesaparalýðý</param>
        /// <returns>kalan tutar</returns>
        public static decimal MahsupDusgetirOld(AV001_TI_BIL_BORCLU_ODEME bOdeme, decimal odeme, MahsupAltKategori mahsupAltKategoriId, AV001_TI_BIL_FOY foy, Takip hesapAraligi)
        {
            if (odeme <= 0 || bOdeme == null || foy == null)
                return -1;
            DateTime odemeTarihi = bOdeme.ODEME_TARIHI;
            AV001_TI_BIL_ODEME_DAGILIM dagit = foy.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
            dagit.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
            dagit.MAHSUP_KATEGORI_ID = DataRepository.TDI_KOD_MAHSUP_ALT_KATEGORIProvider.GetByID((int)mahsupAltKategoriId).MAHSUP_KATEGORI_ID;

            dagit.TUTAR_DOVIZ_ID = 1; //YTL
            dagit.TUTAR_KUR = 1;
            dagit.ODEME_TARIHI = odemeTarihi;
            bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagit);
            dagit.FOY_TARAF_IDSource = foyTarafGetir(bOdeme, foy);
            dagit.DAGILIM_TIPI = 1;
            decimal fyKalem;
            switch (mahsupAltKategoriId)
            {
                #region Case DigerAlacak

                case MahsupAltKategori.Ihtiyati_Tedbir_Vekalet_Ucreti:

                    fyKalem = DovizHelper.CevirYTL(foy.IT_VEKALET_UCRETI, foy.IT_VEKALET_UCRETI_DOVIZ_ID, odemeTarihi) - FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    {
                        bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        return odeme;
                    }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }

                    break;

                case MahsupAltKategori.Takip_Vekalet_Ucreti:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(foy.TAKIP_VEKALET_UCRETI, foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Dava_Vekalet_Ucreti:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(foy.DAVA_VEKALET_UCRETI, foy.DAVA_VEKALET_UCRETI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Tahliye_Davasi_Vekalet_Ucreti:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(foy.TAHLIYE_VEK_UCR, foy.TAHLIYE_VEK_UCR_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Damga_Pulu:
                    fyKalem = DovizHelper.CevirYTL(foy.DAMGA_PULU, foy.DAMGA_PULU_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Basvurma_Harci:
                    fyKalem = DovizHelper.CevirYTL(foy.BASVURMA_HARCI, foy.BASVURMA_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Pesin_Harc:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(foy.PESIN_HARC, foy.PESIN_HARC_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Masaya_Katilma_Harci:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(foy.MASAYA_KATILMA_HARCI, foy.MASAYA_KATILMA_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Paylasma_Harci:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(foy.PAYLASMA_HARCI, foy.PAYLASMA_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Vekalet_pulu:
                    fyKalem = DovizHelper.CevirYTL(foy.VEKALET_PULU, foy.VEKALET_PULU_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Vekalet_Harci:
                    fyKalem = DovizHelper.CevirYTL(foy.VEKALET_HARCI, foy.VEKALET_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Tahliye_Harci:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(foy.TAHLIYE_HARCI, foy.TAHLIYE_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Teslim_Harci:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(foy.TESLIM_HARCI, foy.TESLIM_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Feragat_Harci:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }

                    fyKalem = DovizHelper.CevirYTL(foy.FERAGAT_HARCI, foy.FERAGAT_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Yargitay_Onama_Harci:
                    //Yukardakine yapýyoruz
                    break;

                case MahsupAltKategori.Odenen_Tahsil_Harci:
                    fyKalem = DovizHelper.CevirYTL(foy.ODENEN_TAHSIL_HARCI, foy.ODENEN_TAHSIL_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Kalan_Tahsil_Harci:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(foy.KALAN_TAHSIL_HARCI, foy.KALAN_TAHSIL_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Dava_Inkar_Tazminati:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(foy.DAVA_INKAR_TAZMINATI, foy.DAVA_INKAR_TAZMINATI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Icra_Inkar_Tazminati:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(foy.ICRA_INKAR_TAZMINATI, foy.ICRA_INKAR_TAZMINATI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Cek_Tazminati:
                    fyKalem = DovizHelper.CevirYTL(foy.KARSILIKSIZ_CEK_TAZMINATI, foy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Ozel_Tazminat:
                    fyKalem = DovizHelper.CevirYTL(foy.OZEL_TAZMINAT, foy.OZEL_TAZMINAT_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Birikmis_Tazminatlar:
                    if (hesapAraligi == Takip.Oncesi)
                    {
                        { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    }
                    fyKalem = DovizHelper.CevirYTL(foy.SONRAKI_TAZMINAT, foy.SONRAKI_TAZMINAT_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }

                    break;

                case MahsupAltKategori.Cek_Komisyonu:
                    fyKalem = DovizHelper.CevirYTL(foy.CEK_KOMISYONU, foy.CEK_KOMISYONU_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Takip_Oncesi_Giderler:
                    //Bu burda olmýycak
                    break;

                case MahsupAltKategori.Ihtiyati_Haciz_Gideri:
                    fyKalem = DovizHelper.CevirYTL(foy.IH_GIDERI, foy.IH_GIDERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Ihtiyati_Tedbir_Gideri:
                    fyKalem = DovizHelper.CevirYTL(foy.IT_GIDERI, foy.IT_GIDERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Protesto_Gideri:
                    fyKalem = DovizHelper.CevirYTL(foy.PROTESTO_GIDERI, foy.PROTESTO_GIDERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Ihtar_Gideri:
                    fyKalem = DovizHelper.CevirYTL(foy.IHTAR_GIDERI, foy.IHTAR_GIDERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Ilk_Giderler:
                    //YOK
                    break;

                case MahsupAltKategori.Dava_Giderleri:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(foy.DAVA_GIDERLERI, foy.DAVA_GIDERLERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Diger_Giderler:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(foy.DIGER_GIDERLER, foy.DIGER_GIDERLER_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Tahliye_Davasi_Teblig_Gideri:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(foy.TD_TEBLIG_GIDERI, foy.TD_TEBLIG_GIDERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Islemis_Faiz:
                    fyKalem = DovizHelper.CevirYTL(foy.ISLEMIS_FAIZ, foy.ISLEMIS_FAIZ_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Sonraki_Faiz:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(foy.SONRAKI_FAIZ, foy.SONRAKI_FAIZ_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TO_BSMV:
                    fyKalem = DovizHelper.CevirYTL(foy.BSMV_TO, foy.BSMV_TO_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TO_KDV:
                    fyKalem = DovizHelper.CevirYTL(foy.KDV_TO, foy.KDV_TO_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TO_KKDF:
                    fyKalem = DovizHelper.CevirYTL(foy.KKDV_TO, foy.KKDV_TO_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TO_OIV:
                    fyKalem = DovizHelper.CevirYTL(foy.OIV_TO, foy.OIV_TO_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TS_BSMV:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(foy.BSMV_TS, foy.BSMV_TS_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TS_KDV:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(foy.KDV_TS, foy.KDV_TS_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TS_OIV:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(foy.OIV_TS, foy.OIV_TS_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Sonraki_Nafaka:
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(foy.BIRIKMIS_NAFAKA, foy.BIRIKMIS_NAFAKA_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                #endregion Case DigerAlacak

                #region case AsilAlacak

                case MahsupAltKategori.Alacak_Neden:
                    {
                        #region eX

                        //fyKalem = DovizHelper.CevirYTL(foy.ASIL_ALACAK, foy.ASIL_ALACAK_DOVIZ_ID, odemeTarihi) -
                        //  FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                        //if (fyKalem <= 0)
                        //{
                        //    bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme;
                        //}
                        //if (fyKalem < odeme)
                        //{
                        //    dagit.TUTAR = fyKalem;
                        //    return odeme - fyKalem;

                        //}
                        //else if (fyKalem > odeme)
                        //{
                        //    dagit.TUTAR = fyKalem - odeme;
                        //    return 0;
                        //}
                        //else if (fyKalem == odeme)
                        //{
                        //    dagit.TUTAR = fyKalem;
                        //    return 0;
                        //}

                        #endregion eX

                        int stat = 0;
                        decimal miktar = odeme;
                        while (stat < 9)
                        {
                            bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                            foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);

                            AV001_TI_BIL_ODEME_DAGILIM dagilim = foy.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                            dagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
                            dagilim.MAHSUP_KATEGORI_ID = DataRepository.TDI_KOD_MAHSUP_ALT_KATEGORIProvider.GetByID((int)mahsupAltKategoriId).MAHSUP_KATEGORI_ID;

                            dagilim.TUTAR_DOVIZ_ID = 1; //YTL
                            dagilim.TUTAR_KUR = 1;
                            dagilim.ODEME_TARIHI = odemeTarihi;
                            dagilim.FOY_TARAF_IDSource = foyTarafGetir(bOdeme, foy);
                            dagilim.DAGILIM_TIPI = 1;
                            miktar = AlacakNedenUzerindenDus(foy, bOdeme, dagilim, miktar, out stat);
                            if (stat == 11 || dagilim.TUTAR == 0)
                            {
                                foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagilim);
                            }
                            else
                            {
                                bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagilim);
                            }
                        }
                        return miktar;
                    }

                case MahsupAltKategori.Ilam_Vekalet_Ucreti://KALDI: Burada 05 08 2008 20-22
                    int stat1 = 0;
                    decimal miktar1 = odeme;
                    while (stat1 < 9)
                    {
                        bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);

                        AV001_TI_BIL_ODEME_DAGILIM dagilim = foy.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                        dagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
                        dagilim.MAHSUP_KATEGORI_ID = DataRepository.TDI_KOD_MAHSUP_ALT_KATEGORIProvider.GetByID((int)mahsupAltKategoriId).MAHSUP_KATEGORI_ID;

                        dagilim.TUTAR_DOVIZ_ID = 1; //YTL
                        dagilim.TUTAR_KUR = 1;
                        dagilim.ODEME_TARIHI = odemeTarihi;
                        dagilim.DAGILIM_TIPI = 1;
                        dagilim.FOY_TARAF_IDSource = foyTarafGetir(bOdeme, foy);
                        miktar1 = IlamUzerindenDus(foy, bOdeme, dagilim, miktar1, out stat1, mahsupAltKategoriId);
                        if (stat1 == 11)
                        {
                            foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagilim);
                        }
                        else
                        {
                            bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagilim);
                        }
                    }
                    return miktar1;

                case MahsupAltKategori.Ilam_Yargilama_Giderleri:
                    int stat2 = 0;
                    decimal miktar2 = odeme;
                    while (stat2 < 9)
                    {
                        bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);

                        AV001_TI_BIL_ODEME_DAGILIM dagilim = foy.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                        dagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
                        dagilim.MAHSUP_KATEGORI_ID = DataRepository.TDI_KOD_MAHSUP_ALT_KATEGORIProvider.GetByID((int)mahsupAltKategoriId).MAHSUP_KATEGORI_ID;

                        dagilim.TUTAR_DOVIZ_ID = 1; //YTL
                        dagilim.TUTAR_KUR = 1;
                        dagilim.ODEME_TARIHI = odemeTarihi;
                        dagilim.DAGILIM_TIPI = 1;
                        dagilim.FOY_TARAF_IDSource = foyTarafGetir(bOdeme, foy);
                        miktar2 = IlamUzerindenDus(foy, bOdeme, dagilim, miktar2, out stat2, mahsupAltKategoriId);
                        if (stat2 == 11)
                        {
                            foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagilim);
                        }
                        else
                        {
                            bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagilim);
                        }
                    }
                    return miktar2;

                case MahsupAltKategori.Ilam_Teblig_Gideri:
                    int stat3 = 0;
                    decimal miktar3 = odeme;
                    while (stat3 < 9)
                    {
                        bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);

                        AV001_TI_BIL_ODEME_DAGILIM dagilim = foy.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                        dagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
                        dagilim.MAHSUP_KATEGORI_ID = DataRepository.TDI_KOD_MAHSUP_ALT_KATEGORIProvider.GetByID((int)mahsupAltKategoriId).MAHSUP_KATEGORI_ID;

                        dagilim.TUTAR_DOVIZ_ID = 1; //YTL
                        dagilim.TUTAR_KUR = 1;
                        dagilim.ODEME_TARIHI = odemeTarihi;
                        dagilim.DAGILIM_TIPI = 1;
                        dagilim.FOY_TARAF_IDSource = foyTarafGetir(bOdeme, foy);
                        miktar3 = IlamUzerindenDus(foy, bOdeme, dagilim, miktar3, out stat3, mahsupAltKategoriId);
                        if (stat3 == 11)
                        {
                            foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagilim);
                        }
                        else
                        {
                            bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagilim);
                        }
                    }
                    return miktar3;
                case MahsupAltKategori.Ilam_Inkar_Tazminati:
                    int stat4 = 0;
                    decimal miktar4 = odeme;
                    while (stat4 < 9)
                    {
                        bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);

                        AV001_TI_BIL_ODEME_DAGILIM dagilim = foy.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                        dagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
                        dagilim.MAHSUP_KATEGORI_ID = DataRepository.TDI_KOD_MAHSUP_ALT_KATEGORIProvider.GetByID((int)mahsupAltKategoriId).MAHSUP_KATEGORI_ID;

                        dagilim.TUTAR_DOVIZ_ID = 1; //YTL
                        dagilim.TUTAR_KUR = 1;
                        dagilim.ODEME_TARIHI = odemeTarihi;
                        dagilim.DAGILIM_TIPI = 1;
                        dagilim.FOY_TARAF_IDSource = foyTarafGetir(bOdeme, foy);
                        miktar4 = IlamUzerindenDus(foy, bOdeme, dagilim, miktar4, out stat4, mahsupAltKategoriId);
                        if (stat4 == 11)
                        {
                            foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagilim);
                        }
                        else
                        {
                            bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagilim);
                        }
                    }
                    return miktar4;

                case MahsupAltKategori.Ilam_Bakiye_Karar_Harci:
                    int stat5 = 0;
                    decimal miktar5 = odeme;
                    while (stat5 < 9)
                    {
                        bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);

                        AV001_TI_BIL_ODEME_DAGILIM dagilim = foy.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                        dagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
                        dagilim.MAHSUP_KATEGORI_ID = DataRepository.TDI_KOD_MAHSUP_ALT_KATEGORIProvider.GetByID((int)mahsupAltKategoriId).MAHSUP_KATEGORI_ID;

                        dagilim.TUTAR_DOVIZ_ID = 1; //YTL
                        dagilim.TUTAR_KUR = 1;
                        dagilim.ODEME_TARIHI = odemeTarihi;
                        dagilim.DAGILIM_TIPI = 1;
                        dagilim.FOY_TARAF_IDSource = foyTarafGetir(bOdeme, foy);
                        miktar5 = IlamUzerindenDus(foy, bOdeme, dagilim, miktar5, out stat5, mahsupAltKategoriId);
                        if (stat5 == 11)
                        {
                            foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagilim);
                        }
                        else
                        {
                            bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagilim);
                        }
                    }
                    return miktar5;

                #endregion case AsilAlacak

                default:
                    System.Diagnostics.Debug.WriteLine("Bak bi----- FaizHelper.Dava.cs Line 1089");
                    break;
            }
            return odeme;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bOdeme">borçlu ödeme</param>
        /// <param name="odeme">ytl</param>
        /// <param name="mahsupAltKategoriId">kalemin adý/id si</param>
        /// <param name="mFoy">iþlem yapýlacak föy</param>
        /// <param name="taraf">iþlem yapýlacak taraf</param>
        /// <param name="hesapAraligi">iþlem yapýlacak hesaparalýðý</param>
        /// <returns>kalan tutar</returns>
        public static decimal MahsupDusgetirTaraf
            (AV001_TI_BIL_BORCLU_ODEME bOdeme, decimal odeme, MahsupAltKategori mahsupAltKategoriId,
             AV001_TI_BIL_FOY_TARAF taraf, Takip hesapAraligi, AV001_TI_BIL_FOY mFoy)
        {
            System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - 1");
            if (odeme <= 0 || bOdeme == null || taraf == null)
                return -1;
            DateTime odemeTarihi = bOdeme.ODEME_TARIHI;
            AV001_TI_BIL_ODEME_DAGILIM dagit = taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
            dagit.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
            dagit.MAHSUP_KATEGORI_ID = DataRepository.TDI_KOD_MAHSUP_ALT_KATEGORIProvider.GetByID((int)mahsupAltKategoriId).MAHSUP_KATEGORI_ID;
            dagit.TUTAR_DOVIZ_ID = 1; //YTL
            dagit.TUTAR_KUR = 1;
            dagit.ODEME_TARIHI = odemeTarihi;
            bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagit);
            dagit.FOY_TARAF_ID = taraf.ID;
            dagit.DAGILIM_TIPI = 2;
            decimal fyKalem;
            System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - 2");

            switch (mahsupAltKategoriId)
            {
                #region Case DigerAlacak

                case MahsupAltKategori.Ihtiyati_Tedbir_Vekalet_Ucreti:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Ihtiyati_Tedbir_Vekalet_Ucreti");
                    fyKalem = DovizHelper.CevirYTL(taraf.IT_VEKALET_UCRETI, taraf.IT_VEKALET_UCRETI_DOVIZ_ID, odemeTarihi) - FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    {
                        bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        return odeme;
                    }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }

                    break;

                case MahsupAltKategori.Takip_Vekalet_Ucreti:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Takip_Vekalet_Ucreti");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.TAKIP_VEKALET_UCRETI, taraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Dava_Vekalet_Ucreti:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Dava_Vekalet_Ucreti");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.DAVA_VEKALET_UCRETI, taraf.DAVA_VEKALET_UCRETI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Tahliye_Davasi_Vekalet_Ucreti:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Tahliye_Davasi_Vekalet_Ucreti");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.TAHLIYE_VEK_UCR, taraf.TAHLIYE_VEK_UCR_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Damga_Pulu:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Damga_Pulu");
                    fyKalem = DovizHelper.CevirYTL(taraf.DAMGA_PULU, taraf.DAMGA_PULU_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Basvurma_Harci:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Basvurma_Harci");
                    fyKalem = DovizHelper.CevirYTL(taraf.BASVURMA_HARCI, taraf.BASVURMA_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Pesin_Harc:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Pesin_Harc");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.PESIN_HARC, taraf.PESIN_HARC_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Masaya_Katilma_Harci:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Masaya_Katilma_Harci");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.MASAYA_KATILMA_HARCI, taraf.MASAYA_KATILMA_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Paylasma_Harci:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Paylasma_Harci");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.PAYLASMA_HARCI, taraf.PAYLASMA_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Vekalet_pulu:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Vekalet_pulu");
                    fyKalem = DovizHelper.CevirYTL(taraf.VEKALET_PULU, taraf.VEKALET_PULU_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Vekalet_Harci:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Vekalet_Harci");
                    fyKalem = DovizHelper.CevirYTL(taraf.VEKALET_HARCI, taraf.VEKALET_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Tahliye_Harci:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Tahliye_Harci");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.TAHLIYE_HARCI, taraf.TAHLIYE_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Teslim_Harci:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Teslim_Harci");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.TESLIM_HARCI, taraf.TESLIM_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Feragat_Harci:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Feragat_Harci");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }

                    fyKalem = DovizHelper.CevirYTL(taraf.FERAGAT_HARCI, taraf.FERAGAT_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Yargitay_Onama_Harci:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Yargitay_Onama_Harci");
                    //Yukardakine yapýyoruz
                    break;

                case MahsupAltKategori.Odenen_Tahsil_Harci:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Odenen_Tahsil_Harci");
                    fyKalem = DovizHelper.CevirYTL(taraf.ODENEN_TAHSIL_HARCI, taraf.ODENEN_TAHSIL_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Kalan_Tahsil_Harci:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Kalan_Tahsil_Harci");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.KALAN_TAHSIL_HARCI, taraf.KALAN_TAHSIL_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Dava_Inkar_Tazminati:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Dava_Inkar_Tazminati");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.DAVA_INKAR_TAZMINATI, taraf.DAVA_INKAR_TAZMINATI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Icra_Inkar_Tazminati:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Icra_Inkar_Tazminati");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.ICRA_INKAR_TAZMINATI, taraf.ICRA_INKAR_TAZMINATI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Cek_Tazminati:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Cek_Tazminati");
                    fyKalem = DovizHelper.CevirYTL(taraf.KARSILIKSIZ_CEK_TAZMINATI, taraf.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Ozel_Tazminat:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Ozel_Tazminat");
                    fyKalem = DovizHelper.CevirYTL(taraf.OZEL_TAZMINAT, taraf.OZEL_TAZMINAT_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Birikmis_Tazminatlar:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Birikmis_Tazminatlar");
                    if (hesapAraligi == Takip.Oncesi)
                    {
                        { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    }
                    fyKalem = DovizHelper.CevirYTL(taraf.SONRAKI_TAZMINAT, taraf.SONRAKI_TAZMINAT_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }

                    break;

                case MahsupAltKategori.Cek_Komisyonu:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Cek_Komisyonu");
                    fyKalem = DovizHelper.CevirYTL(taraf.CEK_KOMISYONU, taraf.CEK_KOMISYONU_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Takip_Oncesi_Giderler:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Takip_Oncesi_Giderler");
                    //Bu burda olmýycak
                    break;

                case MahsupAltKategori.Ihtiyati_Haciz_Gideri:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Ihtiyati_Haciz_Gideri");
                    fyKalem = DovizHelper.CevirYTL(taraf.IH_GIDERI, taraf.IH_GIDERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Ihtiyati_Tedbir_Gideri:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Ihtiyati_Tedbir_Gideri");
                    fyKalem = DovizHelper.CevirYTL(taraf.IT_GIDERI, taraf.IT_GIDERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Protesto_Gideri:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Protesto_Gideri");
                    fyKalem = DovizHelper.CevirYTL(taraf.PROTESTO_GIDERI, taraf.PROTESTO_GIDERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Ihtar_Gideri:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Ihtar_Gideri");
                    fyKalem = DovizHelper.CevirYTL(taraf.IHTAR_GIDERI, taraf.IHTAR_GIDERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Ilk_Giderler:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Ilk_Giderler");
                    //YOK
                    break;

                case MahsupAltKategori.Dava_Giderleri:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Dava_Giderleri");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.DAVA_GIDERLERI, taraf.DAVA_GIDERLERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Diger_Giderler:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Diger_Giderler");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.DIGER_GIDERLER, taraf.DIGER_GIDERLER_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Tahliye_Davasi_Teblig_Gideri:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Tahliye_Davasi_Teblig_Gideri");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.TD_TEBLIG_GIDERI, taraf.TD_TEBLIG_GIDERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Islemis_Faiz:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Islemis_Faiz");
                    fyKalem = DovizHelper.CevirYTL(taraf.ISLEMIS_FAIZ, taraf.ISLEMIS_FAIZ_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Sonraki_Faiz:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Sonraki_Faiz");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.SONRAKI_FAIZ, taraf.SONRAKI_FAIZ_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TO_BSMV:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.TO_BSMV");
                    fyKalem = DovizHelper.CevirYTL(taraf.BSMV_TO, taraf.BSMV_TO_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TO_KDV:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.TO_KDV");
                    fyKalem = DovizHelper.CevirYTL(taraf.KDV_TO, taraf.KDV_TO_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TO_KKDF:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.TO_KKDF");
                    fyKalem = DovizHelper.CevirYTL(taraf.KKDV_TO, taraf.KKDV_TO_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TO_OIV:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.TO_OIV");
                    fyKalem = DovizHelper.CevirYTL(taraf.OIV_TO, taraf.OIV_TO_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TS_BSMV:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.TS_BSMV");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.BSMV_TS, taraf.BSMV_TS_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TS_KDV:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.TS_KDV");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.KDV_TS, taraf.KDV_TS_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TS_OIV:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.TS_OIV");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.OIV_TS, taraf.OIV_TS_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Sonraki_Nafaka:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Sonraki_Nafaka");
                    if (hesapAraligi == Takip.Oncesi)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.BIRIKMIS_NAFAKA, taraf.BIRIKMIS_NAFAKA_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                #endregion Case DigerAlacak

                #region case AsilAlacak

                case MahsupAltKategori.Alacak_Neden:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Alacak_Neden");
                    {
                        #region eX

                        //fyKalem = DovizHelper.CevirYTL(foy.ASIL_ALACAK, foy.ASIL_ALACAK_DOVIZ_ID, odemeTarihi) -
                        //  FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                        //if (fyKalem <= 0)
                        //{
                        //    bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme;
                        //}
                        //if (fyKalem < odeme)
                        //{
                        //    dagit.TUTAR = fyKalem;
                        //    return odeme - fyKalem;

                        //}
                        //else if (fyKalem > odeme)
                        //{
                        //    dagit.TUTAR = fyKalem - odeme;
                        //    return 0;
                        //}
                        //else if (fyKalem == odeme)
                        //{
                        //    dagit.TUTAR = fyKalem;
                        //    return 0;
                        //}

                        #endregion eX

                        int stat = 0;
                        decimal miktar = odeme;
                        while (stat < 9)
                        {
                            bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                            taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);

                            AV001_TI_BIL_ODEME_DAGILIM dagilim = taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                            dagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
                            dagilim.MAHSUP_KATEGORI_ID = DataRepository.TDI_KOD_MAHSUP_ALT_KATEGORIProvider.GetByID((int)mahsupAltKategoriId).MAHSUP_KATEGORI_ID;
                            dagilim.TUTAR_DOVIZ_ID = 1; //YTL
                            dagilim.TUTAR_KUR = 1;
                            dagilim.ODEME_TARIHI = odemeTarihi;
                            dagilim.DAGILIM_TIPI = 2;
                            dagilim.FOY_TARAF_ID = taraf.ID;
                            miktar = AlacakNedenUzerindenDus(mFoy, bOdeme, dagilim, miktar, out stat, taraf);
                            if (stat == 11 || dagilim.TUTAR == 0)
                            {
                                taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagilim);
                            }
                            else
                            {
                                bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagilim);
                            }
                        }
                        return miktar;
                    }

                case MahsupAltKategori.Ilam_Vekalet_Ucreti:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Ilam_Vekalet_Ucreti");
                    //TODO: ILAM Diger alacak gibi düþülücek onuyap
                    fyKalem = DovizHelper.CevirYTL(taraf.ILAM_VEK_UCR, taraf.ILAM_VEK_UCR_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    {
                        bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        return odeme;
                    }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }

                    break;

                case MahsupAltKategori.Ilam_Yargilama_Giderleri:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Ilam_Yargilama_Giderleri");
                    fyKalem = DovizHelper.CevirYTL(taraf.ILAM_YARGILAMA_GIDERI, taraf.ILAM_YARGILAMA_GIDERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    {
                        bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        return odeme;
                    }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    //int stat2 = 0;
                    //decimal miktar2 = odeme;
                    //while (stat2 < 9)
                    //{
                    //    bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                    //    taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);

                    //    AV001_TI_BIL_ODEME_DAGILIM dagilim = taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                    //    dagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
                    //    dagilim.TUTAR_DOVIZ_ID = 1; //YTL
                    //    dagilim.TUTAR_KUR = 1;
                    //    dagilim.ODEME_TARIHI = odemeTarihi;
                    //    dagilim.FOY_TARAF_IDSource =taraf;
                    //    miktar2 = IlamUzerindenDus(taraf, bOdeme, dagilim, miktar2, out stat2, mahsupAltKategoriId);
                    //    if (stat2 == 11)
                    //    {
                    //        taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagilim);

                    //    }
                    //    else
                    //    {
                    //        bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagilim);
                    //    }
                    //}
                    //return miktar2;
                    break;

                case MahsupAltKategori.Ilam_Teblig_Gideri:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Ilam_Teblig_Gideri");
                    fyKalem = DovizHelper.CevirYTL(taraf.ILAM_TEBLIG_GIDERI, taraf.ILAM_TEBLIG_GIDERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    {
                        bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        return odeme;
                    }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    //int stat3 = 0;
                    //decimal miktar3 = odeme;
                    //while (stat3 < 9)
                    //{
                    //    bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                    //    taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);

                    //    AV001_TI_BIL_ODEME_DAGILIM dagilim = taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                    //    dagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
                    //    dagilim.TUTAR_DOVIZ_ID = 1; //YTL
                    //    dagilim.TUTAR_KUR = 1;
                    //    dagilim.ODEME_TARIHI = odemeTarihi;
                    //    dagilim.FOY_TARAF_IDSource = taraf;
                    //    miktar3 = IlamUzerindenDus(taraf, bOdeme, dagilim, miktar3, out stat3, mahsupAltKategoriId);
                    //    if (stat3 == 11)
                    //    {
                    //        taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagilim);

                    //    }
                    //    else
                    //    {
                    //        bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagilim);
                    //    }
                    //}
                    //return miktar3;
                    break;

                case MahsupAltKategori.Ilam_Inkar_Tazminati:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Ilam_Inkar_Tazminati");
                    fyKalem = DovizHelper.CevirYTL(taraf.ILAM_INKAR_TAZMINATI, taraf.ILAM_INKAR_TAZMINATI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    {
                        bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        return odeme;
                    }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    //int stat4 = 0;
                    //decimal miktar4 = odeme;
                    //while (stat4 < 9)
                    //{
                    //    bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                    //    taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);

                    //    AV001_TI_BIL_ODEME_DAGILIM dagilim = taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                    //    dagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
                    //    dagilim.TUTAR_DOVIZ_ID = 1; //YTL
                    //    dagilim.TUTAR_KUR = 1;
                    //    dagilim.ODEME_TARIHI = odemeTarihi;
                    //    dagilim.FOY_TARAF_IDSource = taraf;
                    //    miktar4 = IlamUzerindenDus(taraf, bOdeme, dagilim, miktar4, out stat4, mahsupAltKategoriId);
                    //    if (stat4 == 11)
                    //    {
                    //        taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagilim);

                    //    }
                    //    else
                    //    {
                    //        bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagilim);
                    //    }
                    //}
                    //return miktar4;
                    break;

                case MahsupAltKategori.Ilam_Bakiye_Karar_Harci:
                    System.Diagnostics.Debug.WriteLine("MahsupDusgetirTaraf - MahsupAltKategori.Ilam_Bakiye_Karar_Harci");
                    //---
                    fyKalem = DovizHelper.CevirYTL(taraf.ILAM_BK_YARG_ONAMA, taraf.ILAM_BK_YARG_ONAMA_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    {
                        bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        return odeme;
                    }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    //int stat5 = 0;
                    //decimal miktar5 = odeme;
                    //while (stat5 < 9)
                    //{
                    //    bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                    //    taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);

                    //    AV001_TI_BIL_ODEME_DAGILIM dagilim = taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                    //    dagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
                    //    dagilim.TUTAR_DOVIZ_ID = 1; //YTL
                    //    dagilim.TUTAR_KUR = 1;
                    //    dagilim.ODEME_TARIHI = odemeTarihi;
                    //    dagilim.FOY_TARAF_IDSource = taraf;
                    //    miktar5 = IlamUzerindenDus(taraf, bOdeme, dagilim, miktar5, out stat5, mahsupAltKategoriId);
                    //    if (stat5 == 11)
                    //    {
                    //        taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagilim);

                    //    }
                    //    else
                    //    {
                    //        bOdeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagilim);
                    //    }
                    //}
                    //return miktar5;
                    break;

                #endregion case AsilAlacak

                default:
                    System.Diagnostics.Debug.WriteLine("Bak bi----- FaizHelper.Dava.cs Line 1089");
                    break;
            }
            return odeme;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="feragat">borçlu ödeme</param>
        /// <param name="taraf"></param>
        /// <param name="mFoy"></param>
        /// <returns>kalan tutar</returns>
        public static decimal MahsupDusgetirTaraf
            (AV001_TI_BIL_FERAGAT feragat, AV001_TI_BIL_FOY_TARAF taraf, AV001_TI_BIL_FOY mFoy)
        {
            if (feragat == null || taraf == null)
                return -1;
            MahsupAltKategori mahsupAltKategoriId = (MahsupAltKategori)feragat.MAHSUP_ALT_KATEGORI_ID;
            Takip hesapAraligi = Takip.Oncesi;
            decimal odeme = DovizHelper.CevirYTL(feragat.FERAGAT_MIKTAR, feragat.FERAGAT_MIKTAR_DOVIZ_ID,
                                                 feragat.FERAGAT_TARIHI);
            if (mFoy.TAKIP_TARIHI.HasValue && feragat.FERAGAT_TARIHI >= mFoy.TAKIP_TARIHI.Value)
                hesapAraligi = Takip.Sonrasi;
            DateTime odemeTarihi = feragat.FERAGAT_TARIHI;
            AV001_TI_BIL_ODEME_DAGILIM dagit = taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
            dagit.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
            dagit.MAHSUP_KATEGORI_ID = DataRepository.TDI_KOD_MAHSUP_ALT_KATEGORIProvider.GetByID((int)mahsupAltKategoriId).MAHSUP_KATEGORI_ID;

            dagit.TUTAR_DOVIZ_ID = 1; //YTL
            dagit.TUTAR_KUR = 1;
            dagit.ODEME_TARIHI = odemeTarihi;
            feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagit);
            dagit.FOY_TARAF_ID = taraf.ID;
            dagit.DAGILIM_TIPI = 2;
            decimal fyKalem;
            switch (mahsupAltKategoriId)
            {
                #region Case DigerAlacak

                case MahsupAltKategori.Ihtiyati_Tedbir_Vekalet_Ucreti:

                    fyKalem = DovizHelper.CevirYTL(taraf.IT_VEKALET_UCRETI, taraf.IT_VEKALET_UCRETI_DOVIZ_ID, odemeTarihi) - FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    {
                        feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        return odeme;
                    }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }

                    break;

                case MahsupAltKategori.Takip_Vekalet_Ucreti:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.TAKIP_VEKALET_UCRETI, taraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Dava_Vekalet_Ucreti:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.DAVA_VEKALET_UCRETI, taraf.DAVA_VEKALET_UCRETI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Tahliye_Davasi_Vekalet_Ucreti:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.TAHLIYE_VEK_UCR, taraf.TAHLIYE_VEK_UCR_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Damga_Pulu:
                    fyKalem = DovizHelper.CevirYTL(taraf.DAMGA_PULU, taraf.DAMGA_PULU_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Basvurma_Harci:
                    fyKalem = DovizHelper.CevirYTL(taraf.BASVURMA_HARCI, taraf.BASVURMA_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Pesin_Harc:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.PESIN_HARC, taraf.PESIN_HARC_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Masaya_Katilma_Harci:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.MASAYA_KATILMA_HARCI, taraf.MASAYA_KATILMA_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Paylasma_Harci:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.PAYLASMA_HARCI, taraf.PAYLASMA_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Vekalet_pulu:
                    fyKalem = DovizHelper.CevirYTL(taraf.VEKALET_PULU, taraf.VEKALET_PULU_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Vekalet_Harci:
                    fyKalem = DovizHelper.CevirYTL(taraf.VEKALET_HARCI, taraf.VEKALET_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Tahliye_Harci:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.TAHLIYE_HARCI, taraf.TAHLIYE_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Teslim_Harci:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.TESLIM_HARCI, taraf.TESLIM_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Feragat_Harci:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }

                    fyKalem = DovizHelper.CevirYTL(taraf.FERAGAT_HARCI, taraf.FERAGAT_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Yargitay_Onama_Harci:
                    //Yukardakine yapýyoruz
                    break;

                case MahsupAltKategori.Odenen_Tahsil_Harci:
                    fyKalem = DovizHelper.CevirYTL(taraf.ODENEN_TAHSIL_HARCI, taraf.ODENEN_TAHSIL_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Kalan_Tahsil_Harci:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.KALAN_TAHSIL_HARCI, taraf.KALAN_TAHSIL_HARCI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Dava_Inkar_Tazminati:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.DAVA_INKAR_TAZMINATI, taraf.DAVA_INKAR_TAZMINATI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Icra_Inkar_Tazminati:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.ICRA_INKAR_TAZMINATI, taraf.ICRA_INKAR_TAZMINATI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Cek_Tazminati:
                    fyKalem = DovizHelper.CevirYTL(taraf.KARSILIKSIZ_CEK_TAZMINATI, taraf.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Ozel_Tazminat:
                    fyKalem = DovizHelper.CevirYTL(taraf.OZEL_TAZMINAT, taraf.OZEL_TAZMINAT_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Birikmis_Tazminatlar:
                    if (hesapAraligi == Takip.Oncesi)
                    {
                        { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    }
                    fyKalem = DovizHelper.CevirYTL(taraf.SONRAKI_TAZMINAT, taraf.SONRAKI_TAZMINAT_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }

                    break;

                case MahsupAltKategori.Cek_Komisyonu:
                    fyKalem = DovizHelper.CevirYTL(taraf.CEK_KOMISYONU, taraf.CEK_KOMISYONU_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Takip_Oncesi_Giderler:
                    //Bu burda olmýycak
                    break;

                case MahsupAltKategori.Ihtiyati_Haciz_Gideri:
                    fyKalem = DovizHelper.CevirYTL(taraf.IH_GIDERI, taraf.IH_GIDERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Ihtiyati_Tedbir_Gideri:
                    fyKalem = DovizHelper.CevirYTL(taraf.IT_GIDERI, taraf.IT_GIDERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Protesto_Gideri:
                    fyKalem = DovizHelper.CevirYTL(taraf.PROTESTO_GIDERI, taraf.PROTESTO_GIDERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Ihtar_Gideri:
                    fyKalem = DovizHelper.CevirYTL(taraf.IHTAR_GIDERI, taraf.IHTAR_GIDERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Ilk_Giderler:
                    //YOK
                    break;

                case MahsupAltKategori.Dava_Giderleri:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.DAVA_GIDERLERI, taraf.DAVA_GIDERLERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Diger_Giderler:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.DIGER_GIDERLER, taraf.DIGER_GIDERLER_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Tahliye_Davasi_Teblig_Gideri:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.TD_TEBLIG_GIDERI, taraf.TD_TEBLIG_GIDERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Islemis_Faiz:
                    fyKalem = DovizHelper.CevirYTL(taraf.ISLEMIS_FAIZ, taraf.ISLEMIS_FAIZ_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Sonraki_Faiz:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.SONRAKI_FAIZ, taraf.SONRAKI_FAIZ_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TO_BSMV:
                    fyKalem = DovizHelper.CevirYTL(taraf.BSMV_TO, taraf.BSMV_TO_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TO_KDV:
                    fyKalem = DovizHelper.CevirYTL(taraf.KDV_TO, taraf.KDV_TO_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TO_KKDF:
                    fyKalem = DovizHelper.CevirYTL(taraf.KKDV_TO, taraf.KKDV_TO_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TO_OIV:
                    fyKalem = DovizHelper.CevirYTL(taraf.OIV_TO, taraf.OIV_TO_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TS_BSMV:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.BSMV_TS, taraf.BSMV_TS_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TS_KDV:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.KDV_TS, taraf.KDV_TS_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.TS_OIV:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.OIV_TS, taraf.OIV_TS_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                case MahsupAltKategori.Sonraki_Nafaka:
                    if (hesapAraligi == Takip.Oncesi)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    fyKalem = DovizHelper.CevirYTL(taraf.BIRIKMIS_NAFAKA, taraf.BIRIKMIS_NAFAKA_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    { feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme; }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    break;

                #endregion Case DigerAlacak

                #region case AsilAlacak

                case MahsupAltKategori.Alacak_Neden:
                    {
                        #region eX

                        //fyKalem = DovizHelper.CevirYTL(foy.ASIL_ALACAK, foy.ASIL_ALACAK_DOVIZ_ID, odemeTarihi) -
                        //  FoyKalemOncekiMahsupTutariGetir(foy, mahsupAltKategoriId, hesapAraligi);
                        //if (fyKalem <= 0)
                        //{
                        //    feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit); return odeme;
                        //}
                        //if (fyKalem < odeme)
                        //{
                        //    dagit.TUTAR = fyKalem;
                        //    return odeme - fyKalem;

                        //}
                        //else if (fyKalem > odeme)
                        //{
                        //    dagit.TUTAR = fyKalem - odeme;
                        //    return 0;
                        //}
                        //else if (fyKalem == odeme)
                        //{
                        //    dagit.TUTAR = fyKalem;
                        //    return 0;
                        //}

                        #endregion eX

                        int stat = 0;
                        decimal miktar = odeme;
                        while (stat < 9)
                        {
                            feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                            taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);

                            AV001_TI_BIL_ODEME_DAGILIM dagilim = taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                            dagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
                            dagilim.MAHSUP_KATEGORI_ID = DataRepository.TDI_KOD_MAHSUP_ALT_KATEGORIProvider.GetByID((int)mahsupAltKategoriId).MAHSUP_KATEGORI_ID;

                            dagilim.TUTAR_DOVIZ_ID = 1; //YTL
                            dagilim.TUTAR_KUR = 1;
                            dagilim.ODEME_TARIHI = odemeTarihi;
                            dagilim.DAGILIM_TIPI = 2;
                            dagilim.FOY_TARAF_ID = taraf.ID;
                            miktar = AlacakNedenUzerindenDus(mFoy, feragat, dagilim, miktar, out stat, taraf);
                            if (stat == 11 || dagilim.TUTAR == 0)
                            {
                                taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagilim);
                            }
                            else
                            {
                                feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagilim);
                            }
                        }
                        return miktar;
                    }

                case MahsupAltKategori.Ilam_Vekalet_Ucreti:
                    //TODO: ILAM Diger alacak gibi düþülücek onuyap
                    fyKalem = DovizHelper.CevirYTL(taraf.ILAM_VEK_UCR, taraf.ILAM_VEK_UCR_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    {
                        feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        return odeme;
                    }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }

                    break;

                case MahsupAltKategori.Ilam_Yargilama_Giderleri:
                    fyKalem = DovizHelper.CevirYTL(taraf.ILAM_YARGILAMA_GIDERI, taraf.ILAM_YARGILAMA_GIDERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    {
                        feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        return odeme;
                    }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    //int stat2 = 0;
                    //decimal miktar2 = odeme;
                    //while (stat2 < 9)
                    //{
                    //    feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                    //    taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);

                    //    AV001_TI_BIL_ODEME_DAGILIM dagilim = taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                    //    dagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
                    //    dagilim.TUTAR_DOVIZ_ID = 1; //YTL
                    //    dagilim.TUTAR_KUR = 1;
                    //    dagilim.ODEME_TARIHI = odemeTarihi;
                    //    dagilim.FOY_TARAF_IDSource =taraf;
                    //    miktar2 = IlamUzerindenDus(taraf, feragat, dagilim, miktar2, out stat2, mahsupAltKategoriId);
                    //    if (stat2 == 11)
                    //    {
                    //        taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagilim);

                    //    }
                    //    else
                    //    {
                    //        feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagilim);
                    //    }
                    //}
                    //return miktar2;
                    break;

                case MahsupAltKategori.Ilam_Teblig_Gideri:
                    fyKalem = DovizHelper.CevirYTL(taraf.ILAM_TEBLIG_GIDERI, taraf.ILAM_TEBLIG_GIDERI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    {
                        feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        return odeme;
                    }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    //int stat3 = 0;
                    //decimal miktar3 = odeme;
                    //while (stat3 < 9)
                    //{
                    //    feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                    //    taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);

                    //    AV001_TI_BIL_ODEME_DAGILIM dagilim = taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                    //    dagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
                    //    dagilim.TUTAR_DOVIZ_ID = 1; //YTL
                    //    dagilim.TUTAR_KUR = 1;
                    //    dagilim.ODEME_TARIHI = odemeTarihi;
                    //    dagilim.FOY_TARAF_IDSource = taraf;
                    //    miktar3 = IlamUzerindenDus(taraf, feragat, dagilim, miktar3, out stat3, mahsupAltKategoriId);
                    //    if (stat3 == 11)
                    //    {
                    //        taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagilim);

                    //    }
                    //    else
                    //    {
                    //        feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagilim);
                    //    }
                    //}
                    //return miktar3;
                    break;

                case MahsupAltKategori.Ilam_Inkar_Tazminati:
                    fyKalem = DovizHelper.CevirYTL(taraf.ILAM_INKAR_TAZMINATI, taraf.ILAM_INKAR_TAZMINATI_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    {
                        feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        return odeme;
                    }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    //int stat4 = 0;
                    //decimal miktar4 = odeme;
                    //while (stat4 < 9)
                    //{
                    //    feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                    //    taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);

                    //    AV001_TI_BIL_ODEME_DAGILIM dagilim = taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                    //    dagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
                    //    dagilim.TUTAR_DOVIZ_ID = 1; //YTL
                    //    dagilim.TUTAR_KUR = 1;
                    //    dagilim.ODEME_TARIHI = odemeTarihi;
                    //    dagilim.FOY_TARAF_IDSource = taraf;
                    //    miktar4 = IlamUzerindenDus(taraf, feragat, dagilim, miktar4, out stat4, mahsupAltKategoriId);
                    //    if (stat4 == 11)
                    //    {
                    //        taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagilim);

                    //    }
                    //    else
                    //    {
                    //        feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagilim);
                    //    }
                    //}
                    //return miktar4;
                    break;

                case MahsupAltKategori.Ilam_Bakiye_Karar_Harci:
                    //---
                    fyKalem = DovizHelper.CevirYTL(taraf.ILAM_BK_YARG_ONAMA, taraf.ILAM_BK_YARG_ONAMA_DOVIZ_ID, odemeTarihi) -
                              FoyKalemOncekiMahsupTutariGetir(taraf, mahsupAltKategoriId, hesapAraligi);
                    if (fyKalem <= 0)
                    {
                        feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                        return odeme;
                    }
                    if (fyKalem < odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        dagit.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        dagit.TUTAR = fyKalem;
                        return 0;
                    }
                    //int stat5 = 0;
                    //decimal miktar5 = odeme;
                    //while (stat5 < 9)
                    //{
                    //    feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);
                    //    taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagit);

                    //    AV001_TI_BIL_ODEME_DAGILIM dagilim = taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                    //    dagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategoriId;
                    //    dagilim.TUTAR_DOVIZ_ID = 1; //YTL
                    //    dagilim.TUTAR_KUR = 1;
                    //    dagilim.ODEME_TARIHI = odemeTarihi;
                    //    dagilim.FOY_TARAF_IDSource = taraf;
                    //    miktar5 = IlamUzerindenDus(taraf, feragat, dagilim, miktar5, out stat5, mahsupAltKategoriId);
                    //    if (stat5 == 11)
                    //    {
                    //        taraf.AV001_TI_BIL_ODEME_DAGILIMCollection.Remove(dagilim);

                    //    }
                    //    else
                    //    {
                    //        feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagilim);
                    //    }
                    //}
                    //return miktar5;
                    break;

                #endregion case AsilAlacak

                default:
                    System.Diagnostics.Debug.WriteLine("Bak bi----- FaizHelper.Dava.cs Line 1089");
                    break;
            }
            return odeme;
        }

        /// <summary>
        /// Ödemelerin/Feragatlarýn mahsup iþlemlerini halleden method (TARAF ve DOSYA BAZINDA)
        /// </summary>
        /// <param name="foy">Mahsup iþleminin yapýlacaðý foy dosyasý</param>
        /// <returns>Asýl alacaktan mahsup yapýldýysa true</returns>
        public static bool MahsupHallet(AV001_TI_BIL_FOY foy)
        {
            bool asilAlacaktanYedi = false;
            if (foy.TS_HESAP_TIP_IDSource != null)
            {
                System.Diagnostics.Debug.WriteLine("Deepload 1 ");
                DataRepository.AV001_TI_KOD_HESAP_TIPProvider.DeepLoad(foy.TS_HESAP_TIP_IDSource, false,
                                                                       DeepLoadType.IncludeChildren,
                                                                       foy.TS_HESAP_TIP_IDSource.
                                                                           AV001_TI_KOD_HESAP_TIP_SIRACollection.GetType
                                                                           ());

                System.Diagnostics.Debug.WriteLine("Deepload 2 ");

                DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepLoad(foy.AV001_TI_BIL_BORCLU_ODEMECollection, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));
                foy.TS_HESAP_TIP_IDSource.AV001_TI_KOD_HESAP_TIP_SIRACollection.Sort("SIRA_NO ASC");

                System.Diagnostics.Debug.WriteLine("Deepload 3 ");

                DataRepository.AV001_TI_KOD_HESAP_TIP_SIRAProvider.DeepLoad(
                    foy.TS_HESAP_TIP_IDSource.AV001_TI_KOD_HESAP_TIP_SIRACollection, true, DeepLoadType.IncludeChildren,
                    typeof(TDI_KOD_MAHSUP_KATEGORI), typeof(TList<TDI_KOD_MAHSUP_ALT_KATEGORI>));

                #region Odeme Olayi

                System.Diagnostics.Debug.WriteLine("Ödeme Olayý - Borçlu Ödemelerinde Dönüyor");

                foreach (AV001_TI_BIL_BORCLU_ODEME odeme in foy.AV001_TI_BIL_BORCLU_ODEMECollection)
                {
                    //Eðer daha önce ödemenin daðýlýmý yapýlmadý ise yapýyoruz

                    System.Diagnostics.Debug.WriteLine("-----");

                    if (odeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Count == 0)
                    {
                        #region Dosya Bazýnda Daðýlým

                        //Odeme tutarýný ödeme günündeki kurdan ytl ye ceviriyoruz.
                        decimal tutar = DovizHelper.CevirYTL(odeme.ODEME_MIKTAR, odeme.ODEME_MIKTAR_DOVIZ_ID, odeme.ODEME_TARIHI);
                        decimal digerGider = tutar * (decimal)foy.TS_HESAP_TIP_IDSource.DIGER_ALACAK_ORANI / 100;
                        decimal orgDigerGider = digerGider;
                        decimal asilAlacak = tutar * (decimal)foy.TS_HESAP_TIP_IDSource.ASIL_ALACAK_ORANI / 100;
                        decimal orgAsilAlacak = asilAlacak;
                        Takip takipZamani = Takip.Sonrasi;
                        if (odeme.ODEME_TARIHI.Date <= foy.TAKIP_TARIHI.Value.Date)
                        {
                            takipZamani = Takip.Oncesi;
                        }
                        int deneme = 0;

                        System.Diagnostics.Debug.WriteLine("1. while a giriyoruz");

                        while ((asilAlacak > 0 || digerGider > 0) && deneme < 5) //BUG:Bu 5 baþýmýza iþ açabilir
                        {
                            System.Diagnostics.Debug.WriteLine("-----");

                            for (int i = 0;
                                 i < foy.TS_HESAP_TIP_IDSource.AV001_TI_KOD_HESAP_TIP_SIRACollection.Count;
                                 i++)
                            {
                                AV001_TI_KOD_HESAP_TIP_SIRA hspSira =
                                    foy.TS_HESAP_TIP_IDSource.AV001_TI_KOD_HESAP_TIP_SIRACollection[i];
                                DataRepository.TDI_KOD_MAHSUP_KATEGORIProvider.DeepLoad(
                                    hspSira.MAHSUP_KATEGORI_IDSource, true, DeepLoadType.IncludeChildren,
                                    typeof(TList<TDI_KOD_MAHSUP_ALT_KATEGORI>));
                                hspSira.MAHSUP_KATEGORI_IDSource.TDI_KOD_MAHSUP_ALT_KATEGORICollection.Sort(
                                    "SIRA_NO ASC");
                                TList<TDI_KOD_MAHSUP_ALT_KATEGORI> liste =
                                    hspSira.MAHSUP_KATEGORI_IDSource.TDI_KOD_MAHSUP_ALT_KATEGORICollection;
                                if (hspSira.MAHSUP_KATEGORI_IDSource.AlacakTipi == AlacakTipi.DigerAlacak)
                                {
                                    for (int j = 0; j < liste.Count; j++)
                                    {
                                        if (digerGider <= 0)
                                            break;
                                        digerGider = MahsupDusgetir(odeme, digerGider, (MahsupAltKategori)liste[j].ID,
                                                                    foy,
                                                                    takipZamani);
                                    }
                                }
                                else //AsilAlacak ise
                                {
                                    for (int j = 0; j < liste.Count; j++)
                                    {
                                        if (asilAlacak <= 0)
                                            break;
                                        asilAlacak = MahsupDusgetir(odeme, asilAlacak, (MahsupAltKategori)liste[j].ID,
                                                                    foy,
                                                                    takipZamani);
                                        if (asilAlacak == orgAsilAlacak)
                                            deneme++;
                                    }
                                    if (orgAsilAlacak != 0 && orgAsilAlacak > asilAlacak)
                                        asilAlacaktanYedi = true;
                                }
                            }
                            //KALDI:Sonsuz döngüye girebilme ihtimali yüksek ? ? ? ?
                            if (foy.TS_HESAP_TIP_IDSource.AV001_TI_KOD_HESAP_TIP_SIRACollection.Count > 0)
                                if (asilAlacak > 0 && digerGider == 0)
                                {
                                    digerGider = asilAlacak;
                                    asilAlacak = 0;
                                }
                                else if (digerGider > 0 && asilAlacak == 0)
                                {
                                    asilAlacak = digerGider;
                                    digerGider = 0;
                                }
                                else
                                {
                                    if (asilAlacak > 0 && digerGider == 0)
                                    {
                                        digerGider = asilAlacak;
                                    }
                                    else if (digerGider > 0 && asilAlacak == 0)
                                    {
                                        asilAlacak = digerGider;
                                    }
                                    deneme++;
                                }
                        }
                        System.Diagnostics.Debug.WriteLine("1. while dan çýktýk");

                        #endregion Dosya Bazýnda Daðýlým

                        #region Taraf Bazýnda Daðýlým

                        System.Diagnostics.Debug.WriteLine("Taraf bazýnda daðýlým");

                        //Odeme tutarýný ödeme günündeki kurdan ytl ye ceviriyoruz.
                        decimal trfTutar = DovizHelper.CevirYTL(odeme.ODEME_MIKTAR, odeme.ODEME_MIKTAR_DOVIZ_ID, odeme.ODEME_TARIHI);
                        decimal trfDigerGider = trfTutar * (decimal)foy.TS_HESAP_TIP_IDSource.DIGER_ALACAK_ORANI / 100;
                        decimal trfOrgDigerGider = trfDigerGider;
                        decimal trfAsilAlacak = trfTutar * (decimal)foy.TS_HESAP_TIP_IDSource.ASIL_ALACAK_ORANI / 100;
                        decimal trgOrgAsilAlacak = trfAsilAlacak;
                        Takip trfTakipZamani = Takip.Sonrasi;
                        if (odeme.ODEME_TARIHI.Date <= foy.TAKIP_TARIHI.Value.Date)
                        {
                            trfTakipZamani = Takip.Oncesi;
                        }
                        int trfDeneme = 0;

                        System.Diagnostics.Debug.WriteLine("2. while a girdik");

                        while ((trfAsilAlacak > 0 || trfDigerGider > 0) && trfDeneme < 20)//BUG:Bu 5 baþýmýza iþ açabilir
                        {
                            System.Diagnostics.Debug.WriteLine("-------------\n foy.TS_HESAP_TIP_IDSource.AV001_TI_KOD_HESAP_TIP_SIRACollection' da Dönüyoruz");

                            for (int i = 0;
                                 i < foy.TS_HESAP_TIP_IDSource.AV001_TI_KOD_HESAP_TIP_SIRACollection.Count;
                                 i++)
                            {
                                System.Diagnostics.Debug.WriteLine("--");

                                AV001_TI_KOD_HESAP_TIP_SIRA hspSira =
                                    foy.TS_HESAP_TIP_IDSource.AV001_TI_KOD_HESAP_TIP_SIRACollection[i];

                                System.Diagnostics.Debug.WriteLine("DeepLoad Çekiyoruz");
                                DataRepository.TDI_KOD_MAHSUP_KATEGORIProvider.DeepLoad(
                                    hspSira.MAHSUP_KATEGORI_IDSource, true, DeepLoadType.IncludeChildren,
                                    typeof(TList<TDI_KOD_MAHSUP_ALT_KATEGORI>));
                                hspSira.MAHSUP_KATEGORI_IDSource.TDI_KOD_MAHSUP_ALT_KATEGORICollection.Sort(
                                    "SIRA_NO ASC");

                                System.Diagnostics.Debug.WriteLine("1");

                                TList<TDI_KOD_MAHSUP_ALT_KATEGORI> liste =
                                    hspSira.MAHSUP_KATEGORI_IDSource.TDI_KOD_MAHSUP_ALT_KATEGORICollection;
                                if (hspSira.MAHSUP_KATEGORI_IDSource.AlacakTipi == AlacakTipi.DigerAlacak)
                                {
                                    System.Diagnostics.Debug.WriteLine("2");

                                    for (int j = 0; j < liste.Count; j++)
                                    {
                                        System.Diagnostics.Debug.WriteLine("-3");

                                        if (trfDigerGider <= 0)
                                            break;
                                        trfDigerGider = MahsupDusgetirTaraf(odeme, trfDigerGider, (MahsupAltKategori)liste[j].ID,
                                                                            foyTarafGetir(odeme, foy),
                                                                            trfTakipZamani, foy);
                                    }
                                }
                                else //AsilAlacak ise
                                {
                                    System.Diagnostics.Debug.WriteLine("4");

                                    for (int j = 0; j < liste.Count; j++)
                                    {
                                        System.Diagnostics.Debug.WriteLine("-5");

                                        if (trfAsilAlacak <= 0)
                                            break;
                                        System.Diagnostics.Debug.WriteLine("-MahsupDusgetirTaraf");

                                        trfAsilAlacak = MahsupDusgetirTaraf(odeme, trfAsilAlacak, (MahsupAltKategori)liste[j].ID,
                                                                            foyTarafGetir(odeme, foy),
                                                                            trfTakipZamani, foy);
                                        if (trfAsilAlacak == trgOrgAsilAlacak)
                                            trfDeneme++;
                                    }
                                    if (trgOrgAsilAlacak != 0 && trgOrgAsilAlacak > trfAsilAlacak)
                                        asilAlacaktanYedi = true;
                                }
                            }
                            //KALDI:Sonsuz döngüye girebilme ihtimali yüksek ? ? ? ?
                            if (trfAsilAlacak > 0 && trfDigerGider == 0)
                            {
                                trfDigerGider = trfAsilAlacak;
                                trfAsilAlacak = 0;
                            }
                            else if (trfDigerGider > 0 && trfAsilAlacak == 0)
                            {
                                trfAsilAlacak = trfDigerGider;
                                trfDigerGider = 0;
                            }
                        }
                        System.Diagnostics.Debug.WriteLine("2. while dan çýktýk");

                        #endregion Taraf Bazýnda Daðýlým
                    }
                }

                #endregion Odeme Olayi
            }

            #region Feragat Olayi

            System.Diagnostics.Debug.WriteLine("feragat olayý");

            foreach (AV001_TI_BIL_FERAGAT feragat in foy.AV001_TI_BIL_FERAGATCollection)
            {
                System.Diagnostics.Debug.WriteLine("--");

                if (feragat.AV001_TI_BIL_ODEME_DAGILIMCollection != null && feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Count <= 0)
                {
                    #region Dosya Bazýnda

                    System.Diagnostics.Debug.WriteLine("Dosya Bazýnda");

                    feragat.DAGITILMAMIS_MIKTAR = MahsupDusgetir(feragat, foy);
                    feragat.DAGITILMAMIS_MIKTAR_DOVIZ_ID = 1;

                    #endregion Dosya Bazýnda

                    #region Taraf Bazýnda

                    System.Diagnostics.Debug.WriteLine("Taraf Bazýnda");

                    foreach (AV001_TI_BIL_FOY_TARAF taraf in foy.AV001_TI_BIL_FOY_TARAFCollection)
                    {
                        System.Diagnostics.Debug.WriteLine("----------");

                        taraf.FERAGAT_ARTAN += MahsupDusgetirTaraf(feragat, taraf, foy);
                    }

                    #endregion Taraf Bazýnda
                }
            }

            #endregion Feragat Olayi

            return asilAlacaktanYedi;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sabitFaizUygula"></param>
        /// <param name="mFoy"></param>
        /// <param name="mahsupAltKategoriId"></param>
        /// <param name="faizTipId"></param>
        /// <param name="faizBaslangicT"></param>
        /// <param name="faizBitisT"></param>
        /// <param name="islenicekTutar"></param>
        /// <param name="faizKalem"></param>
        /// <param name="neZaman">Takip.Oncesi yada Takip.Sonrasi olabilir</param>
        /// <param name="uygulanicakFaizOrani">sadece sabit faiz ise verilir sabitFaizUygula false olduðu durumlarda verilen deðer kullanýlmaz.</param>
        /// <returns></returns>
        public static TList<AV001_TI_BIL_FAIZ> MahsupluFaizHesapla(bool sabitFaizUygula, AV001_TI_BIL_FOY mFoy, MahsupAltKategori mahsupAltKategoriId, int faizTipId, DateTime faizBaslangicT, DateTime faizBitisT, ParaVeDovizId islenicekTutar, FaizKalem faizKalem, Takip neZaman, double uygulanicakFaizOrani)
        {
            TList<AV001_TI_BIL_FAIZ> faizler = new TList<AV001_TI_BIL_FAIZ>();

            #region FaizHesaplarý

            //Bu nedene ait odeme daðýlýmýný bul
            //Dosya bazýnda olduðunda daðýlým tipi 1 olur

            TList<AV001_TI_BIL_ODEME_DAGILIM> odemeListTemp = mFoy.AV001_TI_BIL_ODEME_DAGILIMCollection.FindAll(AV001_TI_BIL_ODEME_DAGILIMColumn.DAGILIM_TIPI, (byte)1).FindAll(
                AV001_TI_BIL_ODEME_DAGILIMColumn.MAHSUP_ALT_KATEGORI_ID, mahsupAltKategoriId);
            TList<AV001_TI_BIL_ODEME_DAGILIM> odemeList = new TList<AV001_TI_BIL_ODEME_DAGILIM>();

            foreach (AV001_TI_BIL_ODEME_DAGILIM dagilim in odemeListTemp)
            {
                if (neZaman == Takip.Oncesi && dagilim.ODEME_TARIHI < mFoy.TAKIP_TARIHI.Value)
                    odemeList.Add(dagilim);
                else if (neZaman == Takip.Sonrasi && dagilim.ODEME_TARIHI >= mFoy.TAKIP_TARIHI.Value)
                    odemeList.Add(dagilim);
            }

            odemeList.Sort("ODEME_TARIHI");

            if (sabitFaizUygula)
            {
                #region Mahsuplu FaizHesabý

                DateTime dtBaslangicT = faizBaslangicT;
                ParaVeDovizId pdPara = islenicekTutar;

                TList<AV001_TI_BIL_FAIZ> fs = new TList<AV001_TI_BIL_FAIZ>();
                for (int i = 0; i < odemeList.Count; i++)
                {
                    AV001_TI_BIL_ODEME_DAGILIM dagilim = odemeList[i];
                    fs.Add(
                        IcraSabitFaizHesapla(9, dtBaslangicT,
                                                        dagilim.ODEME_TARIHI,
                                                        pdPara.Para,
                                                        pdPara.DovizId,
                                                        mFoy.BIR_YIL_KAC_GUN,
                                                        uygulanicakFaizOrani)
                        );
                    pdPara.Para = pdPara.YtlCevir(dagilim.ODEME_TARIHI) - dagilim.TUTAR;
                    //Mahsuplar hep ytl olarak yapýlýyor
                    pdPara.Para = DovizHelper.CaprazCevir(new ParaVeDovizId(pdPara.Para, 1), pdPara.DovizId,
                                                          dagilim.ODEME_TARIHI);
                    //neden.KO_ISLEME_KONAN_TUTAR = pdPara.Para;
                    dtBaslangicT = dagilim.ODEME_TARIHI;
                    if (pdPara.Para <= 0)
                    {
                        break; //faiz iþlenicek para kalmadýysa bitir olayý.
                    }
                    if (i == odemeList.Count - 1)//Eðer sonuncuysa
                    {
                        fs.Add(
                            IcraSabitFaizHesapla(9, dagilim.ODEME_TARIHI,
                                                            faizBitisT,
                                                            pdPara.Para,
                                                            pdPara.DovizId,
                                                            mFoy.BIR_YIL_KAC_GUN,
                                                            uygulanicakFaizOrani)
                            );
                    }
                }
                if (fs.Count == 0)
                {
                    fs.Add(IcraSabitFaizHesapla(9, dtBaslangicT,
                                                           faizBitisT,
                                                           pdPara.Para,
                                                           pdPara.DovizId,
                                                           mFoy.BIR_YIL_KAC_GUN,
                                                           uygulanicakFaizOrani)

                        );
                }

                #endregion Mahsuplu FaizHesabý

                faizler.AddRange(fs);
            }
            else //Deðiþken Faiz
            {//TODO:TEST
                #region Mahsuplu FaizHesabý

                DateTime dtBaslangicT = faizBaslangicT;
                ParaVeDovizId pdPara = islenicekTutar;

                TList<AV001_TI_BIL_FAIZ> fs = new TList<AV001_TI_BIL_FAIZ>();
                for (int i = 0; i < odemeList.Count; i++)
                {
                    AV001_TI_BIL_ODEME_DAGILIM dagilim = odemeList[i];
                    fs.AddRange(
                        IcraDegiskenFaizHesapla(
                            faizTipId,
                            dtBaslangicT,
                            dagilim.ODEME_TARIHI,
                            pdPara.Para,
                            pdPara.DovizId,
                            mFoy.BIR_YIL_KAC_GUN));
                    pdPara.Para = pdPara.YtlCevir(dagilim.ODEME_TARIHI) - dagilim.TUTAR;
                    //Mahsuplar hep ytl olarak yapýlýyor
                    pdPara.Para = DovizHelper.CaprazCevir(new ParaVeDovizId(pdPara.Para, 1), pdPara.DovizId,
                                                          dagilim.ODEME_TARIHI);
                    //neden.KO_ISLEME_KONAN_TUTAR = pdPara.Para;
                    dtBaslangicT = dagilim.ODEME_TARIHI;
                    if (pdPara.Para <= 0)
                    {
                        break; //faiz iþlenicek para kalmadýysa bitir olayý.
                    }
                    if (i == odemeList.Count - 1)//Eðer sonuncuysa
                    {
                        fs.AddRange(IcraDegiskenFaizHesapla(
                                        faizTipId,
                                        dagilim.ODEME_TARIHI,
                                        faizBitisT,
                                        pdPara.Para,
                                        pdPara.DovizId,
                                        mFoy.BIR_YIL_KAC_GUN));
                    }
                }
                if (fs.Count == 0)
                {
                    fs.AddRange(
                        IcraDegiskenFaizHesapla(faizTipId,
                                                           faizBaslangicT,
                                                           faizBitisT,
                                                           pdPara.Para,
                                                           pdPara.DovizId,
                                                           mFoy.BIR_YIL_KAC_GUN)
                        );
                }

                #endregion Mahsuplu FaizHesabý

                faizler.AddRange(fs);
            }

            #endregion FaizHesaplarý

            foreach (AV001_TI_BIL_FAIZ faiz in faizler)
            {
                faiz.FAIZ_KALEM_ID = (int)faizKalem;
                if (neZaman == Takip.Oncesi)
                {
                    faiz.FAIZ_TAKIPDEN_ONCE_MI = 1;
                }
            }
            return faizler;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sabitFaizUygula"></param>
        /// <param name="mFoy"></param>
        /// <param name="mahsupAltKategoriId"></param>
        /// <param name="faizTipId"></param>
        /// <param name="faizBaslangicT"></param>
        /// <param name="faizBitisT"></param>
        /// <param name="islenicekTutar"></param>
        /// <param name="faizKalem"></param>
        /// <param name="uygulanicakFaizOrani">sadece sabit faiz ise verilir sabitFaizUygula false olduðu durumlarda verilen deðer kullanýlmaz.</param>
        /// <returns></returns>
        public static TList<AV001_TI_BIL_FAIZ> MahsupluFaizHesaplaTaraf(bool sabitFaizUygula, AV001_TI_BIL_FOY mFoy, MahsupAltKategori mahsupAltKategoriId, int faizTipId, DateTime faizBaslangicT, DateTime faizBitisT, ParaVeDovizId islenicekTutar, FaizKalem faizKalem, double uygulanicakFaizOrani, AV001_TI_BIL_ALACAK_NEDEN_TARAF taraf)
        {
            TList<AV001_TI_BIL_FAIZ> faizler = new TList<AV001_TI_BIL_FAIZ>();

            #region FaizHesaplarý

            //Bu nedene ait odeme daðýlýmýný bul
            //Dosya bazýnda olduðunda daðýlým tipi 1 olur
            TList<AV001_TI_BIL_ODEME_DAGILIM> odemeListtemP = mFoy.AV001_TI_BIL_ODEME_DAGILIMCollection.FindAll(AV001_TI_BIL_ODEME_DAGILIMColumn.DAGILIM_TIPI, (byte)1).FindAll(
                AV001_TI_BIL_ODEME_DAGILIMColumn.MAHSUP_ALT_KATEGORI_ID, (int)mahsupAltKategoriId);

            TList<AV001_TI_BIL_ODEME_DAGILIM> odemeList = new TList<AV001_TI_BIL_ODEME_DAGILIM>();
            foreach (AV001_TI_BIL_ODEME_DAGILIM dagilim in odemeListtemP)
            {
                if (dagilim.ODEME_TARIHI <= faizBitisT && dagilim.ODEME_TARIHI >= faizBaslangicT)
                {
                    odemeList.Add(dagilim);
                }
            }
            //.FindAll(
            //    delegate(AV001_TI_BIL_ODEME_DAGILIM obj)
            //        {
            //            //eðer alacak neden taraf ý doðru ise bul
            //            if ((obj.ALACAK_NEDEN_TARAF_ID.HasValue && obj.ALACAK_NEDEN_TARAF_ID.Value == taraf.ID) || (obj.ALACAK_NEDEN_TARAF_IDSource != null && obj.ALACAK_NEDEN_TARAF_IDSource == taraf))
            //            {//Taraf bazýnda hesapta takip öncesi sonrasý ayrýmý burada yapýlmamaktadýr bu nedenden dolayý aþaðýyý 110820081212 de yýlmaz commentlemiþtir.
            //                //if (neZaman == Takip.Oncesi && obj.ODEME_TARIHI < mFoy.TAKIP_TARIHI.Value)
            //                //return true;
            //                //else if (neZaman == Takip.Sonrasi && obj.ODEME_TARIHI >= mFoy.TAKIP_TARIHI.Value)
            //                //    return true;

            //                //Lakin þöyle bir þey var taraf bazýndaki faiz hesabýnda ödeme verilen faiz aralýðýna denk gelmesi gerekmektedir
            //                //Birden fazla faiz hesaplanacaðý için ..
            //                if (obj.ODEME_TARIHI <= faizBitisT && obj.ODEME_TARIHI >= faizBaslangicT)
            //                    return true;
            //            }
            //            return false;
            //        }
            //    );

            odemeList.Sort("ODEME_TARIHI");

            if (sabitFaizUygula)
            {
                #region Mahsuplu FaizHesabý

                DateTime dtBaslangicT = faizBaslangicT;
                ParaVeDovizId pdPara = islenicekTutar;

                TList<AV001_TI_BIL_FAIZ> fs = new TList<AV001_TI_BIL_FAIZ>();
                for (int i = 0; i < odemeList.Count; i++)
                {
                    AV001_TI_BIL_ODEME_DAGILIM dagilim = odemeList[i];
                    fs.Add(
                        IcraSabitFaizHesapla(9, dtBaslangicT,
                                                        dagilim.ODEME_TARIHI,
                                                        pdPara.Para,
                                                        pdPara.DovizId,
                                                        mFoy.BIR_YIL_KAC_GUN,
                                                        uygulanicakFaizOrani)
                        );
                    pdPara.Para = pdPara.YtlCevir(dagilim.ODEME_TARIHI) - dagilim.TUTAR;
                    //Mahsuplar hep ytl olarak yapýlýyor
                    pdPara.Para = DovizHelper.CaprazCevir(new ParaVeDovizId(pdPara.Para, 1), pdPara.DovizId,
                                                          dagilim.ODEME_TARIHI);
                    //neden.KO_ISLEME_KONAN_TUTAR = pdPara.Para;
                    dtBaslangicT = dagilim.ODEME_TARIHI;
                    if (pdPara.Para <= 0)
                    {
                        break; //faiz iþlenicek para kalmadýysa bitir olayý.
                    }
                    if (i == odemeList.Count - 1)//Eðer sonuncuysa
                    {
                        fs.Add(
                            IcraSabitFaizHesapla(9, dagilim.ODEME_TARIHI,
                                                            faizBitisT,
                                                            pdPara.Para,
                                                            pdPara.DovizId,
                                                            mFoy.BIR_YIL_KAC_GUN,
                                                            uygulanicakFaizOrani)
                            );
                    }
                }
                if (fs.Count == 0)
                {
                    fs.Add(IcraSabitFaizHesapla(9, dtBaslangicT,
                                                           faizBitisT,
                                                           pdPara.Para,
                                                           pdPara.DovizId,
                                                           mFoy.BIR_YIL_KAC_GUN,
                                                           uygulanicakFaizOrani)

                        );
                }

                #endregion Mahsuplu FaizHesabý

                faizler.AddRange(fs);
            }
            else //Deðiþken Faiz
            {//TODO:TEST
                #region Mahsuplu FaizHesabý

                DateTime dtBaslangicT = faizBaslangicT;
                ParaVeDovizId pdPara = islenicekTutar;

                TList<AV001_TI_BIL_FAIZ> fs = new TList<AV001_TI_BIL_FAIZ>();
                for (int i = 0; i < odemeList.Count; i++)
                {
                    AV001_TI_BIL_ODEME_DAGILIM dagilim = odemeList[i];
                    fs.AddRange(
                        IcraDegiskenFaizHesapla(
                            faizTipId,
                            dtBaslangicT,
                            dagilim.ODEME_TARIHI,
                            pdPara.Para,
                            pdPara.DovizId,
                            mFoy.BIR_YIL_KAC_GUN));
                    pdPara.Para = pdPara.YtlCevir(dagilim.ODEME_TARIHI) - dagilim.TUTAR;
                    //Mahsuplar hep ytl olarak yapýlýyor
                    pdPara.Para = DovizHelper.CaprazCevir(new ParaVeDovizId(pdPara.Para, 1), pdPara.DovizId,
                                                          dagilim.ODEME_TARIHI);
                    //neden.KO_ISLEME_KONAN_TUTAR = pdPara.Para;
                    dtBaslangicT = dagilim.ODEME_TARIHI;
                    if (pdPara.Para <= 0)
                    {
                        break; //faiz iþlenicek para kalmadýysa bitir olayý.
                    }
                    if (i == odemeList.Count - 1)//Eðer sonuncuysa
                    {
                        fs.AddRange(IcraDegiskenFaizHesapla(
                                        faizTipId,
                                        dagilim.ODEME_TARIHI,
                                        faizBitisT,
                                        pdPara.Para,
                                        pdPara.DovizId,
                                        mFoy.BIR_YIL_KAC_GUN));
                    }
                }
                if (fs.Count == 0)
                {
                    fs.AddRange(
                        IcraDegiskenFaizHesapla(faizTipId,
                                                           faizBaslangicT,
                                                           faizBitisT,
                                                           pdPara.Para,
                                                           pdPara.DovizId,
                                                           mFoy.BIR_YIL_KAC_GUN)
                        );
                }

                #endregion Mahsuplu FaizHesabý

                faizler.AddRange(fs);
            }

            #endregion FaizHesaplarý

            return faizler;
        }

        public static IcraNispiHarcTipi OdemeHarcTipiGetirByTarih(AV001_TI_BIL_FOY foy, DateTime dt)
        {
            IcraNispiHarcTipi result = IcraNispiHarcTipi.HACiZDEN_EVVEL_BAKiYE_HARC;
            foreach (AV001_TI_BIL_HACIZ_MASTER haciz in foy.AV001_TI_BIL_HACIZ_MASTERCollection)
            {
                if (haciz.HACIZ_TARIHI <= dt)
                {
                    result = IcraNispiHarcTipi.HACiZDEN_SONRA_BAKiYE_HARC;
                }
            }
            foreach (AV001_TI_BIL_SATIS_MASTER satis in foy.AV001_TI_BIL_SATIS_MASTERCollection)
            {
                if (satis.SATIS_TARIHI_1.HasValue && satis.SATIS_TARIHI_1.Value <= dt)
                {
                    result = IcraNispiHarcTipi.SATiSTAN_SONRA_BAKiYE_HARC;
                }
            }
            return result;
        }

        public static TList<AV001_TI_BIL_BORCLU_ODEME> OdemeListGetirByMahsupAltKategori(AV001_TI_BIL_FOY foy, MahsupAltKategori mahsupAltKategoriId)
        {
            TList<AV001_TI_BIL_BORCLU_ODEME> odemes = new TList<AV001_TI_BIL_BORCLU_ODEME>();
            TList<AV001_TI_BIL_ODEME_DAGILIM> listem = foy.AV001_TI_BIL_ODEME_DAGILIMCollection.FindAll(AV001_TI_BIL_ODEME_DAGILIMColumn.MAHSUP_ALT_KATEGORI_ID,
                                                                                                        (int)mahsupAltKategoriId);
            foreach (AV001_TI_BIL_ODEME_DAGILIM dagilim in listem)
            {
                odemes.Add(dagilim.ODEME_IDSource);
            }
            return odemes;
        }

        public static TList<AV001_TI_BIL_FAIZ> OzelTutarFaizHesapla(AV001_TI_BIL_FOY mFoy, Takip hesapAraligi)
        {
            DateTime dtBaslangicT = new DateTime();
            DateTime dtBitisT = new DateTime();

            TList<AV001_TI_BIL_FAIZ> result = new TList<AV001_TI_BIL_FAIZ>();
            if (mFoy.OZEL_TAZMINAT_FAIZ_ISLESINMI && mFoy.OZEL_TAZMINAT_FAIZ_BASLANGIC_TARIHI.HasValue)
            {
                if (hesapAraligi == Takip.Oncesi)
                {
                    dtBaslangicT = mFoy.OZEL_TAZMINAT_FAIZ_BASLANGIC_TARIHI.Value;
                    dtBitisT = mFoy.TAKIP_TARIHI.Value;
                }
                else
                {
                    dtBaslangicT = mFoy.TAKIP_TARIHI.Value;
                    dtBitisT = mFoy.SON_HESAP_TARIHI.Value;
                }
                //AV001_TI_BIL_FAIZ fz = FaizHelper.IcraSabitFaizHesapla((int)FaizTip.Özel_Sabit_Faiz,
                //                                                       mFoy.OZEL_TAZMINAT_FAIZ_BASLANGIC_TARIHI.Value,
                //                                                       mFoy.TAKIP_TARIHI.Value, mFoy.OZEL_TAZMINAT,
                //                                                       mFoy.OZEL_TAZMINAT_DOVIZ_ID.Value,
                //                                                       mFoy.BIR_YIL_KAC_GUN,
                //                                                       mFoy.OZEL_TAZMINAT_FAIZ_ORANI,
                //                                                       FaizKalem.ÖZEL_TAZMÝNAT);
                result.AddRange(FaizHelper.MahsupluFaizHesapla(true, mFoy, MahsupAltKategori.Ozel_Tazminat,
                                                               (int)FaizTip.Özel_Sabit_Faiz, dtBaslangicT, dtBitisT, new ParaVeDovizId(mFoy.OZEL_TAZMINAT, mFoy.OZEL_TAZMINAT_DOVIZ_ID), FaizKalem.ÖZEL_TAZMÝNAT,
                                                               hesapAraligi, mFoy.OZEL_TAZMINAT_FAIZ_ORANI));
            }
            if (mFoy.OZEL_TUTAR1_FAIZ_ISLESINMI && mFoy.OZEL_TUTAR1_FAIZ_BASLANGIC_TARIHI.HasValue)
            {
                if (hesapAraligi == Takip.Oncesi)
                {
                    dtBaslangicT = mFoy.OZEL_TUTAR1_FAIZ_BASLANGIC_TARIHI.Value;
                    dtBitisT = mFoy.TAKIP_TARIHI.Value;
                }
                else
                {
                    dtBaslangicT = mFoy.TAKIP_TARIHI.Value;
                    dtBitisT = mFoy.SON_HESAP_TARIHI.Value;
                }
                //AV001_TI_BIL_FAIZ fz =
                //    FaizHelper.IcraSabitFaizHesapla((int)FaizTip.Özel_Sabit_Faiz,
                //                                    mFoy.OZEL_TUTAR1_FAIZ_BASLANGIC_TARIHI.Value,
                //                                    mFoy.TAKIP_TARIHI.Value, mFoy.OZEL_TUTAR1,
                //                                    mFoy.OZEL_TUTAR1_DOVIZ_ID.Value, mFoy.BIR_YIL_KAC_GUN,
                //                                    mFoy.OZEL_TUTAR1_FAIZ_ORANI, FaizKalem.ÖZEL_TUTAR_1);
                //mFoy.AV001_TI_BIL_FAIZCollection.Add(fz);
                result.AddRange(FaizHelper.MahsupluFaizHesapla(true, mFoy, MahsupAltKategori.Ozel_Tutar_1,
                                                               (int)FaizTip.Özel_Sabit_Faiz, dtBaslangicT, dtBitisT, new ParaVeDovizId(mFoy.OZEL_TUTAR1, mFoy.OZEL_TUTAR1_DOVIZ_ID), FaizKalem.ÖZEL_TUTAR_1,
                                                               hesapAraligi, mFoy.OZEL_TUTAR1_FAIZ_ORANI));
            }
            if (mFoy.OZEL_TUTAR2_FAIZ_ISLESINMI && mFoy.OZEL_TUTAR2_FAIZ_BASLANGIC_TARIHI.HasValue)
            {
                if (hesapAraligi == Takip.Oncesi)
                {
                    dtBaslangicT = mFoy.OZEL_TUTAR2_FAIZ_BASLANGIC_TARIHI.Value;
                    dtBitisT = mFoy.TAKIP_TARIHI.Value;
                }
                else
                {
                    dtBaslangicT = mFoy.TAKIP_TARIHI.Value;
                    dtBitisT = mFoy.SON_HESAP_TARIHI.Value;
                }

                result.AddRange(FaizHelper.MahsupluFaizHesapla(true, mFoy, MahsupAltKategori.Ozel_Tutar_2,
                                                               (int)FaizTip.Özel_Sabit_Faiz, dtBaslangicT, dtBitisT, new ParaVeDovizId(mFoy.OZEL_TUTAR2, mFoy.OZEL_TUTAR1_DOVIZ_ID), FaizKalem.ÖZEL_TUTAR_2,
                                                               hesapAraligi, mFoy.OZEL_TUTAR2_FAIZ_ORANI));
            }
            if (mFoy.OZEL_TUTAR3_FAIZ_ISLESINMI && mFoy.OZEL_TUTAR3_FAIZ_BASLANGIC_TARIHI.HasValue)
            {
                if (hesapAraligi == Takip.Oncesi)
                {
                    dtBaslangicT = mFoy.OZEL_TUTAR3_FAIZ_BASLANGIC_TARIHI.Value;
                    dtBitisT = mFoy.TAKIP_TARIHI.Value;
                }
                else
                {
                    dtBaslangicT = mFoy.TAKIP_TARIHI.Value;
                    dtBitisT = mFoy.SON_HESAP_TARIHI.Value;
                }
                result.AddRange(FaizHelper.MahsupluFaizHesapla(true, mFoy, MahsupAltKategori.Ozel_Tutar_3,
                                                               (int)FaizTip.Özel_Sabit_Faiz, dtBaslangicT, dtBitisT, new ParaVeDovizId(mFoy.OZEL_TUTAR3, mFoy.OZEL_TUTAR3_DOVIZ_ID), FaizKalem.ÖZEL_TUTAR_3,
                                                               hesapAraligi, mFoy.OZEL_TUTAR3_FAIZ_ORANI));
            }
            return result;
        }

        private static TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> AlacakNedenTarafListesiGetir(AV001_TI_BIL_FOY foy, AV001_TI_BIL_FOY_TARAF taraf)
        {
            TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> result = new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>();
            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                #region <YY-20090610>

                //Burda taraflar dolu olmadýðý zaman ödeme daðýmýnda asýl alacak üzerinde daðýlým yapýlmýyor idi
                //Bu nedenle deepload çektim.
                if (neden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(neden, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>), typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>));

                #endregion <YY-20090610>

                foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF buTaraf in neden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                {
                    //burda bi bak source filan ne ayak
                    if (buTaraf.TARAF_CARI_ID > 0 && taraf.CARI_ID.HasValue && buTaraf.TARAF_CARI_ID == taraf.CARI_ID.Value)
                    {
                        result.Add(buTaraf);
                    }
                }
            }
            return result;
        }

        private static decimal AlacakNedenUzerindenDus
            (AV001_TI_BIL_FOY foy, AV001_TI_BIL_BORCLU_ODEME borcluOdeme, AV001_TI_BIL_ODEME_DAGILIM odemeDagilim, decimal odeme, out int stat)
        {
            foy.AV001_TI_BIL_ALACAK_NEDENCollection.Sort("ALACAK_NEDEN_MAHSUP_SIRA");
            for (int i = 0; i < foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++)
            {
                AV001_TI_BIL_ALACAK_NEDEN neden = foy.AV001_TI_BIL_ALACAK_NEDENCollection[i];

                DovizHelper.GetMerkezBankasiBilgisi(neden.ALACAK_NEDEN_KOD_ID);

                decimal fyKalem =
                    DovizHelper.CevirYTL(neden.ISLEME_KONAN_TUTAR, neden.ISLEME_KONAN_TUTAR_DOVIZ_ID,
                                         borcluOdeme.ODEME_TARIHI) -
                    FoyKalemAlacakNedenineGoreOncekiMahsupGetir(foy, MahsupAltKategori.Alacak_Neden, neden);
                if (odeme <= 0)
                {
                    stat = 9;
                    return 0;
                }
                if (fyKalem > 0)
                {
                    //odemeDagilim.ALACAK_NEDEN_IDSource = neden;
                    neden.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(odemeDagilim);
                    if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == i + 1)
                    {
                        stat = 9;//son
                    }
                    else
                    {
                        stat = 0;//daha var
                    }
                    if (fyKalem < odeme)
                    {
                        odemeDagilim.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        odemeDagilim.TUTAR = odeme;

                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        odemeDagilim.TUTAR = fyKalem;
                        return 0;
                    }
                }
            }
            stat = 10;//tutar yazýlmadý
            return odeme;
        }

        private static decimal AlacakNedenUzerindenDus
            (AV001_TI_BIL_FOY foy, AV001_TI_BIL_FERAGAT feragat, AV001_TI_BIL_ODEME_DAGILIM odemeDagilim, decimal odeme, out int stat)
        {
            foy.AV001_TI_BIL_ALACAK_NEDENCollection.Sort("ALACAK_NEDEN_MAHSUP_SIRA");
            for (int i = 0; i < foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++)
            {
                AV001_TI_BIL_ALACAK_NEDEN neden = foy.AV001_TI_BIL_ALACAK_NEDENCollection[i];

                DovizHelper.GetMerkezBankasiBilgisi(neden.ALACAK_NEDEN_KOD_ID);

                decimal fyKalem =
                    DovizHelper.CevirYTL(neden.ISLEME_KONAN_TUTAR, neden.ISLEME_KONAN_TUTAR_DOVIZ_ID,
                                         feragat.FERAGAT_TARIHI) -
                    FoyKalemAlacakNedenineGoreOncekiMahsupGetir(foy, MahsupAltKategori.Alacak_Neden, neden);
                if (odeme <= 0)
                {
                    stat = 9;
                    return 0;
                }
                if (fyKalem > 0)
                {
                    //odemeDagilim.ALACAK_NEDEN_IDSource = neden;
                    neden.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(odemeDagilim);
                    if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == i + 1)
                    {
                        stat = 9;//son
                    }
                    else
                    {
                        stat = 0;//daha var
                    }
                    if (fyKalem < odeme)
                    {
                        odemeDagilim.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        odemeDagilim.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        odemeDagilim.TUTAR = fyKalem;
                        return 0;
                    }
                }
            }
            stat = 10;//tutar yazýlmadý
            return odeme;
        }

        private static decimal AlacakNedenUzerindenDus
            (AV001_TI_BIL_FOY foy, AV001_TI_BIL_BORCLU_ODEME borcluOdeme, AV001_TI_BIL_ODEME_DAGILIM odemeDagilim, decimal odeme, out int stat, AV001_TI_BIL_FOY_TARAF taraf)
        {
            foy.AV001_TI_BIL_ALACAK_NEDENCollection.Sort("ALACAK_NEDEN_MAHSUP_SIRA");
            TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> taraflar = AlacakNedenTarafListesiGetir(foy, taraf);

            for (int i = 0; i < taraflar.Count; i++)
            {
                AV001_TI_BIL_ALACAK_NEDEN_TARAF nedenTaraf = taraflar[i];
                decimal fyKalem =
                    DovizHelper.CevirYTL(nedenTaraf.SORUMLU_OLUNAN_MIKTAR,
                                         nedenTaraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID,
                                         borcluOdeme.ODEME_TARIHI) -
                    FoyKalemAlacakNedenineGoreOncekiMahsupGetirTaraf(foy, MahsupAltKategori.Alacak_Neden, nedenTaraf);
                if (odeme <= 0)
                {
                    stat = 9;
                    return 0;
                }
                if (fyKalem > 0)
                {
                    odemeDagilim.ALACAK_NEDEN_TARAF_IDSource = nedenTaraf;

                    if (taraflar.Count == i + 1)
                    {
                        stat = 9; //son
                    }
                    else
                    {
                        stat = 0; //daha var
                    }
                    if (fyKalem < odeme)
                    {
                        odemeDagilim.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        odemeDagilim.TUTAR = odeme;
                        //Deneme için yazdýk (gkn)
                        //if (odeme >= 0 )
                        //    stat = 9;
                        //end
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        odemeDagilim.TUTAR = fyKalem;
                        return 0;
                    }
                }
            }
            stat = 10;//tutar yazýlmadý
            return odeme;
        }

        private static decimal AlacakNedenUzerindenDus
            (AV001_TI_BIL_FOY foy, AV001_TI_BIL_FERAGAT feragat, AV001_TI_BIL_ODEME_DAGILIM odemeDagilim, decimal odeme, out int stat, AV001_TI_BIL_FOY_TARAF taraf)
        {
            foy.AV001_TI_BIL_ALACAK_NEDENCollection.Sort("ALACAK_NEDEN_MAHSUP_SIRA");
            TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> taraflar = AlacakNedenTarafListesiGetir(foy, taraf);

            for (int i = 0; i < taraflar.Count; i++)
            {
                AV001_TI_BIL_ALACAK_NEDEN_TARAF nedenTaraf = taraflar[i];
                DovizHelper.GetMerkezBankasiBilgisi(nedenTaraf);
                decimal fyKalem =
                    DovizHelper.CevirYTL(nedenTaraf.SORUMLU_OLUNAN_MIKTAR,
                                         nedenTaraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID,
                                         feragat.FERAGAT_TARIHI) -
                    FoyKalemAlacakNedenineGoreOncekiMahsupGetirTaraf(foy, MahsupAltKategori.Alacak_Neden, nedenTaraf);
                if (odeme <= 0)
                {
                    stat = 9;
                    return 0;
                }
                if (fyKalem > 0)
                {
                    odemeDagilim.ALACAK_NEDEN_TARAF_IDSource = nedenTaraf;

                    if (taraflar.Count == i + 1)
                    {
                        stat = 9; //son
                    }
                    else
                    {
                        stat = 0; //daha var
                    }
                    if (fyKalem < odeme)
                    {
                        odemeDagilim.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        odemeDagilim.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        odemeDagilim.TUTAR = fyKalem;
                        return 0;
                    }
                }
            }
            stat = 10;//tutar yazýlmadý
            return odeme;
        }

        private static AV001_TI_BIL_FOY_TARAF foyTarafGetir(AV001_TI_BIL_BORCLU_ODEME odeme, AV001_TI_BIL_FOY foy)
        {
            foreach (AV001_TI_BIL_FOY_TARAF foyTaraf in foy.AV001_TI_BIL_FOY_TARAFCollection)
            {
                if ((foyTaraf.CARI_ID.HasValue && odeme.ODEYEN_CARI_ID == foyTaraf.CARI_ID.Value) || odeme.ODEYEN_CARI_IDSource != null && odeme.ODEYEN_CARI_IDSource == foyTaraf.CARI_IDSource)
                {
                    return foyTaraf;
                }
            }
            return null;
        }

        private static decimal GetTLTutarByMahsupAltKategori(AV001_TI_BIL_FOY foy, MahsupAltKategori mahsupAltKategoriId, DateTime odemeTarihi)
        {
            switch (mahsupAltKategoriId)
            {
                case MahsupAltKategori.Takip_Vekalet_Ucreti: return DovizHelper.CevirYTL(foy.TAKIP_VEKALET_UCRETI, foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Dava_Vekalet_Ucreti: return DovizHelper.CevirYTL(foy.DAVA_VEKALET_UCRETI, foy.DAVA_VEKALET_UCRETI_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Tahliye_Davasi_Vekalet_Ucreti: return DovizHelper.CevirYTL(foy.TAHLIYE_VEK_UCR, foy.TAHLIYE_VEK_UCR_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Pesin_Harc: return DovizHelper.CevirYTL(foy.PESIN_HARC, foy.PESIN_HARC_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Masaya_Katilma_Harci: return DovizHelper.CevirYTL(foy.MASAYA_KATILMA_HARCI, foy.MASAYA_KATILMA_HARCI_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Paylasma_Harci: return DovizHelper.CevirYTL(foy.PAYLASMA_HARCI, foy.PAYLASMA_HARCI_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Tahliye_Harci: return DovizHelper.CevirYTL(foy.TAHLIYE_HARCI, foy.TAHLIYE_HARCI_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Teslim_Harci: return DovizHelper.CevirYTL(foy.TESLIM_HARCI, foy.TESLIM_HARCI_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Feragat_Harci: return DovizHelper.CevirYTL(foy.FERAGAT_HARCI, foy.FERAGAT_HARCI_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Dava_Inkar_Tazminati: return DovizHelper.CevirYTL(foy.DAVA_INKAR_TAZMINATI, foy.DAVA_INKAR_TAZMINATI_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Icra_Inkar_Tazminati: return DovizHelper.CevirYTL(foy.ICRA_INKAR_TAZMINATI, foy.ICRA_INKAR_TAZMINATI_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Birikmis_Tazminatlar: return DovizHelper.CevirYTL(foy.SONRAKI_TAZMINAT, foy.SONRAKI_TAZMINAT_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Dava_Giderleri: return DovizHelper.CevirYTL(foy.DAVA_GIDERLERI, foy.DAVA_GIDERLERI_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Diger_Giderler: return DovizHelper.CevirYTL(foy.DIGER_GIDERLER, foy.DIGER_GIDERLER_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Tahliye_Davasi_Teblig_Gideri: return DovizHelper.CevirYTL(foy.TD_TEBLIG_GIDERI, foy.TD_TEBLIG_GIDERI_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Sonraki_Faiz: return DovizHelper.CevirYTL(foy.SONRAKI_FAIZ, foy.SONRAKI_FAIZ_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.TS_BSMV: return DovizHelper.CevirYTL(foy.BSMV_TS, foy.BSMV_TS_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.TS_KDV: return DovizHelper.CevirYTL(foy.KDV_TS, foy.KDV_TS_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.TS_OIV: return DovizHelper.CevirYTL(foy.OIV_TS, foy.OIV_TS_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Sonraki_Nafaka: return DovizHelper.CevirYTL(foy.BIRIKMIS_NAFAKA, foy.BIRIKMIS_NAFAKA_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Basvurma_Harci: return DovizHelper.CevirYTL(foy.BASVURMA_HARCI, foy.BASVURMA_HARCI_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Damga_Pulu: return DovizHelper.CevirYTL(foy.DAMGA_PULU, foy.DAMGA_PULU_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Vekalet_pulu: return DovizHelper.CevirYTL(foy.VEKALET_PULU, foy.VEKALET_PULU_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Vekalet_Harci: return DovizHelper.CevirYTL(foy.VEKALET_HARCI, foy.VEKALET_HARCI_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Odenen_Tahsil_Harci: return DovizHelper.CevirYTL(foy.ODENEN_TAHSIL_HARCI, foy.ODENEN_TAHSIL_HARCI_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Cek_Tazminati: return DovizHelper.CevirYTL(foy.KARSILIKSIZ_CEK_TAZMINATI, foy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Ozel_Tazminat: return DovizHelper.CevirYTL(foy.OZEL_TAZMINAT, foy.OZEL_TAZMINAT_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Cek_Komisyonu: return DovizHelper.CevirYTL(foy.CEK_KOMISYONU, foy.CEK_KOMISYONU_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Ihtiyati_Haciz_Gideri: return DovizHelper.CevirYTL(foy.IH_GIDERI, foy.IH_GIDERI_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Ihtiyati_Tedbir_Gideri: return DovizHelper.CevirYTL(foy.IT_GIDERI, foy.IT_GIDERI_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Protesto_Gideri: return DovizHelper.CevirYTL(foy.PROTESTO_GIDERI, foy.PROTESTO_GIDERI_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Ihtar_Gideri: return DovizHelper.CevirYTL(foy.IHTAR_GIDERI, foy.IHTAR_GIDERI_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Islemis_Faiz: return DovizHelper.CevirYTL(foy.ISLEMIS_FAIZ, foy.ISLEMIS_FAIZ_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.TO_BSMV: return DovizHelper.CevirYTL(foy.BSMV_TO, foy.BSMV_TO_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.TO_KDV: return DovizHelper.CevirYTL(foy.KDV_TO, foy.KDV_TO_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.TO_KKDF: return DovizHelper.CevirYTL(foy.KKDV_TO, foy.KKDV_TO_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.TO_OIV: return DovizHelper.CevirYTL(foy.OIV_TO, foy.OIV_TO_DOVIZ_ID, odemeTarihi);
                case MahsupAltKategori.Ihtiyati_Tedbir_Vekalet_Ucreti: return DovizHelper.CevirYTL(foy.IT_VEKALET_UCRETI, foy.IT_VEKALET_UCRETI_DOVIZ_ID, odemeTarihi);
            }

            return decimal.Zero;
        }

        private static decimal IlamUzerindenDus
            (AV001_TI_BIL_FOY foy, AV001_TI_BIL_FERAGAT feragat, AV001_TI_BIL_ODEME_DAGILIM odemeDagilim, decimal odeme, out int stat, MahsupAltKategori ilamKalemi)
        {
            //Ilamda sira yok
            // foy.AV001_TI_BIL_ALACAK_NEDENCollection.Sort("ALACAK_NEDEN_MAHSUP_SIRA");
            for (int i = 0; i < foy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count; i++)
            {
                AV001_TI_BIL_ILAM_MAHKEMESI ilam = foy.AV001_TI_BIL_ILAM_MAHKEMESICollection[i];

                decimal kalemTutar = 0;
                switch (ilamKalemi)
                {
                    case MahsupAltKategori.Ilam_Yargilama_Giderleri:
                        kalemTutar = DovizHelper.CevirYTL(ilam.YARGILAMA_GIDERI, ilam.YARGILAMA_GIDERI_DOVIZ_ID,
                                                          feragat.FERAGAT_TARIHI);
                        break;

                    case MahsupAltKategori.Ilam_Vekalet_Ucreti:
                        kalemTutar = DovizHelper.CevirYTL(ilam.ILAM_VEKALET_UCRETI, ilam.ILAM_VEKALET_UCRETI_DOVIZ_ID,
                                                          feragat.FERAGAT_TARIHI);
                        break;

                    case MahsupAltKategori.Ilam_Teblig_Gideri:
                        kalemTutar = DovizHelper.CevirYTL(ilam.ILAM_TEBLIG_GIDERI, ilam.ILAM_TEBLIG_GIDERI_DOVIZ_ID,
                                                          feragat.FERAGAT_TARIHI);
                        break;

                    case MahsupAltKategori.Ilam_Inkar_Tazminati:
                        kalemTutar = DovizHelper.CevirYTL(ilam.INKAR_TAZMINATI, ilam.INKAR_TAZMINATI_DOVIZ_ID,
                                                          feragat.FERAGAT_TARIHI);
                        break;

                    case MahsupAltKategori.Ilam_Bakiye_Karar_Harci:
                        kalemTutar = DovizHelper.CevirYTL(ilam.BAKIYE_KARAR_HARCI, ilam.BAKIYE_KARAR_HARCI_DOVIZ_ID,
                                                          feragat.FERAGAT_TARIHI);
                        break;

                    default:
                        stat = 11;
                        return 0;
                }
                decimal fyKalem = kalemTutar -
                                  FoyKalemIlamaGoreOncekiMahsupGetir(foy, ilamKalemi, ilam);
                if (odeme <= 0)
                {
                    stat = 9;
                    return 0;
                }
                if (fyKalem > 0)
                {
                    odemeDagilim.ILAM_IDSource = ilam;
                    if (foy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count == i + 1)
                    {
                        stat = 9;//son
                    }
                    else
                    {
                        stat = 0;//daha var
                    }
                    if (fyKalem < odeme)
                    {
                        odemeDagilim.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        odemeDagilim.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        odemeDagilim.TUTAR = fyKalem;
                        return 0;
                    }
                }
            }
            stat = 10;//tutar yazýlmadý
            return odeme;
        }

        private static decimal IlamUzerindenDus
            (AV001_TI_BIL_FOY foy, AV001_TI_BIL_BORCLU_ODEME borcluOdeme, AV001_TI_BIL_ODEME_DAGILIM odemeDagilim, decimal odeme, out int stat, MahsupAltKategori ilamKalemi)
        {
            //Ilamda sira yok
            // foy.AV001_TI_BIL_ALACAK_NEDENCollection.Sort("ALACAK_NEDEN_MAHSUP_SIRA");
            for (int i = 0; i < foy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count; i++)
            {
                AV001_TI_BIL_ILAM_MAHKEMESI ilam = foy.AV001_TI_BIL_ILAM_MAHKEMESICollection[i];

                decimal kalemTutar = 0;
                switch (ilamKalemi)
                {
                    case MahsupAltKategori.Ilam_Yargilama_Giderleri:
                        kalemTutar = DovizHelper.CevirYTL(ilam.YARGILAMA_GIDERI, ilam.YARGILAMA_GIDERI_DOVIZ_ID,
                                                          borcluOdeme.ODEME_TARIHI);
                        break;

                    case MahsupAltKategori.Ilam_Vekalet_Ucreti:
                        kalemTutar = DovizHelper.CevirYTL(ilam.ILAM_VEKALET_UCRETI, ilam.ILAM_VEKALET_UCRETI_DOVIZ_ID,
                                                          borcluOdeme.ODEME_TARIHI);
                        break;

                    case MahsupAltKategori.Ilam_Teblig_Gideri:
                        kalemTutar = DovizHelper.CevirYTL(ilam.ILAM_TEBLIG_GIDERI, ilam.ILAM_TEBLIG_GIDERI_DOVIZ_ID,
                                                          borcluOdeme.ODEME_TARIHI);
                        break;

                    case MahsupAltKategori.Ilam_Inkar_Tazminati:
                        kalemTutar = DovizHelper.CevirYTL(ilam.INKAR_TAZMINATI, ilam.INKAR_TAZMINATI_DOVIZ_ID,
                                                          borcluOdeme.ODEME_TARIHI);
                        break;

                    case MahsupAltKategori.Ilam_Bakiye_Karar_Harci:
                        kalemTutar = DovizHelper.CevirYTL(ilam.BAKIYE_KARAR_HARCI, ilam.BAKIYE_KARAR_HARCI_DOVIZ_ID,
                                                          borcluOdeme.ODEME_TARIHI);
                        break;

                    default:
                        stat = 11;
                        return 0;
                }
                decimal fyKalem = kalemTutar -
                                  FoyKalemIlamaGoreOncekiMahsupGetir(foy, ilamKalemi, ilam);
                if (odeme <= 0)
                {
                    stat = 9;
                    return 0;
                }
                if (fyKalem > 0)
                {
                    odemeDagilim.ILAM_IDSource = ilam;
                    if (foy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count == i + 1)
                    {
                        stat = 9;//son
                    }
                    else
                    {
                        stat = 0;//daha var
                    }
                    if (fyKalem < odeme)
                    {
                        odemeDagilim.TUTAR = fyKalem;
                        return odeme - fyKalem;
                    }
                    else if (fyKalem > odeme)
                    {
                        odemeDagilim.TUTAR = odeme;
                        return 0;
                    }
                    else if (fyKalem == odeme)
                    {
                        odemeDagilim.TUTAR = fyKalem;
                        return 0;
                    }
                }
            }
            stat = 10;//tutar yazýlmadý
            return odeme;
        }

        #region EX

        //private static void FoyUzerineTakipSonrasiFaizHesapla(AV001_TI_BIL_FOY foy)
        //{
        //    bool asilAlacaktanYedimi = MahsupHallet(foy);
        //    if(asilAlacaktanYedimi)
        //    {
        //        foy.AV001_TI_BIL_FAIZCollection.Filter = String.Format("FAIZ_KALEM_ID = {0}",(int)FaizKalem.ASIL_ALACAK);
        //        foreach (AV001_TI_BIL_ALACAK_NEDEN alacakNeden in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
        //        {
        //            foreach (AV001_TI_BIL_FAIZ faiz in alacakNeden.AV001_TI_BIL_FAIZCollection)
        //            {
        //                faiz.MarkToDelete();
        //            }
        //        }
        //    }
        //    //foreach (AV001_TI_BIL_BORCLU_ODEME odeme in foy.AV001_TI_BIL_BORCLU_ODEMECollection)
        //    //{
        //    //    //Takip oncesi ödeme faizleri ona göre hesapla.
        //    //    if (asilAlacaktanYedimi && odeme.ODEME_TARIHI.HasValue && foy.TAKIP_TARIHI.HasValue && odeme.ODEME_TARIHI.Value <= foy.TAKIP_TARIHI.Value)
        //    //    {
        //    //        //foy.AV001_TI_BIL_FAIZCollection.
        //    //    }
        //    //}
        //}

        #endregion EX

        #region Nispi Harc Kalemi Getir

        /// <summary>
        /// Verilen parametrelere göre <c ref="AV001_TI_BIL_HARC"/> tipinden yeni bir instance oluþturur. [NÝSPÝ]
        /// </summary>
        /// <param name="oran">Harc Oraný</param>
        /// <param name="harcTipi">Maktu Harc Tipi</param>
        /// <param name="matrah">Harcýn hesaplandýðý matrah</param>
        /// <param name="harcMiktari">Harc Tutarý</param>
        /// <param name="tarifeTarihi">Harc tarife tarihi</param>
        /// <returns></returns>
        public static AV001_TI_BIL_HARC HarcGetir(IcraNispiHarcTipi harcTipi, ParaVeDovizId matrah, double oran, decimal harcMiktari, DateTime tarifeTarihi)
        {
            return HarcGetir(harcTipi, matrah, oran, harcMiktari, tarifeTarihi, (byte)0);
        }

        /// <summary>
        /// Verilen parametrelere göre <c ref="AV001_TI_BIL_HARC"/> tipinden yeni bir instance oluþturur. [NÝSPÝ]
        /// </summary>
        /// <param name="oran">Harc Oraný</param>
        /// <param name="harcTipi">Maktu Harc Tipi</param>
        /// <param name="matrah">Harcýn hesaplandýðý matrah</param>
        /// <param name="harcMiktari">Harc Tutarý</param>
        /// <param name="tarifeTarihi">Harc tarife tarihi</param>
        /// <param name="harcSebebi">Tam olarak bilinmiyor araþtýrýlmakta</param>
        /// <returns></returns>
        public static AV001_TI_BIL_HARC HarcGetir(IcraNispiHarcTipi harcTipi, ParaVeDovizId matrah, double oran, decimal harcMiktari, DateTime tarifeTarihi, byte harcSebebi)
        {
            return HarcGetir(harcTipi, matrah, oran, harcMiktari, false, tarifeTarihi, harcSebebi);
        }

        /// <summary>
        /// Verilen parametrelere göre <c ref="AV001_TI_BIL_HARC"/> tipinden yeni bir instance oluþturur. [NÝSPÝ]
        /// </summary>
        /// <param name="oran">Harc Oraný</param>
        /// <param name="harcTipi">Maktu Harc Tipi</param>
        /// <param name="matrah">Harcýn hesaplandýðý matrah</param>
        /// <param name="harcMiktari">Harc Tutarý</param>
        /// <param name="feragatVarMi">Feragat Varmý</param>
        /// <param name="tarifeTarihi">Harc tarife tarihi</param>
        /// <param name="harcSebebi">Tam olarak bilinmiyor araþtýrýlmakta</param>
        /// <returns></returns>
        public static AV001_TI_BIL_HARC HarcGetir(IcraNispiHarcTipi harcTipi, ParaVeDovizId matrah, double oran, decimal harcMiktari, bool feragatVarMi, DateTime tarifeTarihi, byte harcSebebi)
        {
            return HarcGetir(harcTipi, matrah, oran, harcMiktari, false, feragatVarMi, tarifeTarihi, harcSebebi);
        }

        /// <summary>
        /// Verilen parametrelere göre <c ref="AV001_TI_BIL_HARC"/> tipinden yeni bir instance oluþturur. [NÝSPÝ]
        /// </summary>
        /// <param name="oran">Harc Oraný</param>
        /// <param name="harcTipi">Maktu Harc Tipi</param>
        /// <param name="matrah">Harcýn hesaplandýðý matrah</param>
        /// <param name="harcMiktari">Harc Tutarý</param>
        /// <param name="satisVarMi">Satýþ Varmý</param>
        /// <param name="feragatVarMi">Feragat Varmý</param>
        /// <param name="tarifeTarihi">Harc tarife tarihi</param>
        /// <param name="harcSebebi">Tam olarak bilinmiyor araþtýrýlmakta</param>
        /// <returns></returns>
        public static AV001_TI_BIL_HARC HarcGetir(IcraNispiHarcTipi harcTipi, ParaVeDovizId matrah, double oran, decimal harcMiktari, bool satisVarMi, bool feragatVarMi, DateTime tarifeTarihi, byte harcSebebi)
        {
            return HarcGetir(harcTipi, matrah, oran, harcMiktari, false, satisVarMi, feragatVarMi, tarifeTarihi, harcSebebi);
        }

        /// <summary>
        /// Verilen parametrelere göre <c ref="AV001_TI_BIL_HARC"/> tipinden yeni bir instance oluþturur. [NÝSPÝ]
        /// </summary>
        /// <param name="oran">Harc Oraný</param>
        /// <param name="harcTipi">Maktu Harc Tipi</param>
        /// <param name="matrah">Harcýn hesaplandýðý matrah</param>
        /// <param name="harcMiktari">Harc Tutarý</param>
        /// <param name="hacizVarMi">Haciz Varmý</param>
        /// <param name="satisVarMi">Satýþ Varmý</param>
        /// <param name="feragatVarMi">Feragat Varmý</param>
        /// <param name="tarifeTarihi">Harc tarife tarihi</param>
        /// <param name="harcSebebi">Tam olarak bilinmiyor araþtýrýlmakta</param>
        /// <returns></returns>
        public static AV001_TI_BIL_HARC HarcGetir(IcraNispiHarcTipi harcTipi, ParaVeDovizId matrah, double oran, decimal harcMiktari, bool hacizVarMi, bool satisVarMi, bool feragatVarMi, DateTime tarifeTarihi, byte harcSebebi)
        {
            AV001_TI_BIL_HARC harc = new AV001_TI_BIL_HARC();
            harc.NISPI_HARC_KALEM_ID = (int)harcTipi;
            harc.MATRAH_MIKTARI = matrah.Para;
            harc.MATRAH_MIKTARI_DOVIZ_ID = matrah.DovizId;
            harc.HARC_ORANI = oran;
            harc.HARC_MIKTARI = harcMiktari;
            harc.HARC_MIKTARI_DOVIZ_ID = 1;
            harc.HACIZ_VAR_MI = hacizVarMi;
            harc.SATIS_VAR_MI = satisVarMi;
            harc.FERAGAT_VAR_MI = feragatVarMi;
            harc.TARIFE_TARIHI = tarifeTarihi;
            harc.HARC_TIP_NO = 0;//nispi
            harc.HARC_TIPI = "NÝSPÝ";
            harc.HARC_SEBEBI = harcSebebi;
            return harc;
        }

        #endregion Nispi Harc Kalemi Getir

        #region Maktu Harç Kalemi Getir

        /// <summary>
        /// Verilen parametrelere göre <c ref="AV001_TI_BIL_HARC"/> tipinden yeni bir instance oluþturur. [MAKTU]
        /// </summary>
        /// <param name="harcTipi">Maktu Harc Tipi</param>
        /// <param name="matrah">Harcýn hesaplanacaðý matrah</param>
        /// <param name="harcMiktari">Harc Tutarý</param>
        /// <param name="tarifeTarihi">Harc tarife tarihi</param>
        /// <returns></returns>
        public static AV001_TI_BIL_HARC HarcGetir(MuhasebeAltKategoriId harcTipi, ParaVeDovizId matrah, decimal harcMiktari, DateTime tarifeTarihi)
        {
            return HarcGetir(harcTipi, matrah, harcMiktari, tarifeTarihi, (byte)0);
        }

        /// <summary>
        /// Verilen parametrelere göre <c ref="AV001_TI_BIL_HARC"/> tipinden yeni bir instance oluþturur. [MAKTU]
        /// </summary>
        /// <param name="harcTipi">Maktu Harc Tipi</param>
        /// <param name="matrah">Harcýn hesaplanacaðý matrah</param>
        /// <param name="harcMiktari">Harc Tutarý</param>
        /// <param name="tarifeTarihi">Harc tarife tarihi</param>
        /// <param name="harcSebebi">Tam olarak bilinmiyor araþtýrýlmakta</param>
        /// <returns></returns>
        public static AV001_TI_BIL_HARC HarcGetir(MuhasebeAltKategoriId harcTipi, ParaVeDovizId matrah, decimal harcMiktari, DateTime tarifeTarihi, byte harcSebebi)
        {
            return HarcGetir(harcTipi, matrah, harcMiktari, false, tarifeTarihi, harcSebebi);
        }

        /// <summary>
        /// Verilen parametrelere göre <c ref="AV001_TI_BIL_HARC"/> tipinden yeni bir instance oluþturur. [MAKTU]
        /// </summary>
        /// <param name="harcTipi">Maktu Harc Tipi</param>
        /// <param name="matrah">Harcýn hesaplanacaðý matrah</param>
        /// <param name="harcMiktari">Harc Tutarý</param>
        /// <param name="feragatVarMi">Feragat Varmý</param>
        /// <param name="tarifeTarihi">Harc tarife tarihi</param>
        /// <param name="harcSebebi">Tam olarak bilinmiyor araþtýrýlmakta</param>
        /// <returns></returns>
        public static AV001_TI_BIL_HARC HarcGetir(MuhasebeAltKategoriId harcTipi, ParaVeDovizId matrah, decimal harcMiktari, bool feragatVarMi, DateTime tarifeTarihi, byte harcSebebi)
        {
            return HarcGetir(harcTipi, matrah, harcMiktari, false, feragatVarMi, tarifeTarihi, harcSebebi);
        }

        /// <summary>
        /// Verilen parametrelere göre <c ref="AV001_TI_BIL_HARC"/> tipinden yeni bir instance oluþturur. [MAKTU]
        /// </summary>
        /// <param name="harcTipi">Maktu Harc Tipi</param>
        /// <param name="matrah">Harcýn hesaplanacaðý matrah</param>
        /// <param name="harcMiktari">Harc Tutarý</param>
        /// <param name="satisVarMi">Satýþ Varmý</param>
        /// <param name="feragatVarMi">Feragat Varmý</param>
        /// <param name="tarifeTarihi">Harc tarife tarihi</param>
        /// <param name="harcSebebi">Tam olarak bilinmiyor araþtýrýlmakta</param>
        /// <returns></returns>
        public static AV001_TI_BIL_HARC HarcGetir(MuhasebeAltKategoriId harcTipi, ParaVeDovizId matrah, decimal harcMiktari, bool satisVarMi, bool feragatVarMi, DateTime tarifeTarihi, byte harcSebebi)
        {
            return HarcGetir(harcTipi, matrah, harcMiktari, false, satisVarMi, feragatVarMi, tarifeTarihi, harcSebebi);
        }

        /// <summary>
        /// Verilen parametrelere göre <c ref="AV001_TI_BIL_HARC"/> tipinden yeni bir instance oluþturur. [MAKTU]
        /// </summary>
        /// <param name="harcTipi">Maktu Harc Tipi</param>
        /// <param name="matrah">Harcýn hesaplanacaðý matrah</param>
        /// <param name="harcMiktari">Harc Tutarý</param>
        /// <param name="hacizVarMi">Haciz Varmý</param>
        /// <param name="satisVarMi">Satýþ Varmý</param>
        /// <param name="feragatVarMi">Feragat Varmý</param>
        /// <param name="tarifeTarihi">Harc tarife tarihi</param>
        /// <param name="harcSebebi">Tam olarak bilinmiyor araþtýrýlmakta</param>
        /// <returns></returns>
        public static AV001_TI_BIL_HARC HarcGetir(MuhasebeAltKategoriId harcTipi, ParaVeDovizId matrah, decimal harcMiktari, bool hacizVarMi, bool satisVarMi, bool feragatVarMi, DateTime tarifeTarihi, byte harcSebebi)
        {
            AV001_TI_BIL_HARC harc = new AV001_TI_BIL_HARC();
            harc.MAKTU_HARC_KALEM_ID = (int)harcTipi;
            harc.MATRAH_MIKTARI = matrah.Para;
            harc.MATRAH_MIKTARI_DOVIZ_ID = matrah.DovizId;
            harc.HARC_MIKTARI = harcMiktari;
            harc.HARC_MIKTARI_DOVIZ_ID = 1;
            harc.HACIZ_VAR_MI = hacizVarMi;
            harc.SATIS_VAR_MI = satisVarMi;
            harc.FERAGAT_VAR_MI = feragatVarMi;
            harc.TARIFE_TARIHI = tarifeTarihi;
            harc.HARC_TIP_NO = 1;//nispi
            harc.HARC_TIPI = "MAKTU";
            harc.HARC_SEBEBI = harcSebebi;
            return harc;
        }

        #endregion Maktu Harç Kalemi Getir

        #region Vekalet Ücret Kalemi Getir

        /// <summary>
        /// <c ref="AV001_TI_BIL_VEKALET_UCRET"/>
        /// </summary>
        /// <param name="takipCikisi"></param>
        /// <param name="tarifeTarihi"></param>
        /// <param name="vekUcretKalemi"></param>
        /// <param name="vekUcretMiktari"></param>
        /// <param name="vekUcretOrani"></param>
        /// <param name="vekUcretTipNo"></param>
        /// <returns></returns>
        [Obsolete("Lütfen Hesaplama Tarihi olan methodu Kullaniniz", true)]
        public static AvukatProLib2.Entities.AV001_TI_BIL_VEKALET_UCRET VekaletUcretiGetir(ParaVeDovizId takipCikisi, DateTime tarifeTarihi, VekaletUcretKalemi vekUcretKalemi, ParaVeDovizId vekUcretMiktari, double vekUcretOrani, VekaketUcretTipNo vekUcretTipNo)
        {
            AvukatProLib2.Entities.AV001_TI_BIL_VEKALET_UCRET vekUcret = new AvukatProLib2.Entities.AV001_TI_BIL_VEKALET_UCRET();
            vekUcret.TAKIP_CIKISI = takipCikisi.Para;
            vekUcret.TAKIP_CIKISI_DOVIZ_ID = takipCikisi.DovizId;
            vekUcret.TARIFE_TARIHI = tarifeTarihi;
            vekUcret.VEK_UCR_MIKTARI = vekUcretMiktari.Para;
            vekUcret.VEK_UCR_MIKTARI_DOVIZ_ID = vekUcretMiktari.DovizId;
            vekUcret.VEK_UCR_ORANI = vekUcretOrani;
            vekUcret.VEK_UCR_TIP_NO = (byte)vekUcretTipNo; //Maktu-Nispi
            return vekUcret;
        }

        /// <summary>
        /// <c ref="AV001_TI_BIL_VEKALET_UCRET"/> tipinden bir kalem oluþturup geri döndürür. Herhangi bir hesaplama yapýlmamaktadýr.
        /// </summary>
        /// <param name="takipCikisi">Kalemin Takip Cikisi miktari</param>
        /// <param name="tarifeTarihi">Kalemin Takip Cikisi miktarinin Doviz Idsi</param>
        /// <param name="vekUcretKalemi">Ýlgili kalemin Kalem No su</param>
        /// <param name="vekUcretMiktari">Ýlgili kalemin miktari</param>
        /// <param name="vekUcretOrani">Ýlgili kalemin oraný</param>
        /// <param name="vekUcretTipNo">Maktu/Nispi</param>
        /// <returns>Verilen bilgiler ile ilgili bir vekalet ucret kalemi oluþturarak geri döndürür.</returns>
        public static AvukatProLib2.Entities.AV001_TI_BIL_VEKALET_UCRET VekaletUcretiGetir(ParaVeDovizId takipCikisi, DateTime tarifeTarihi, VekaletUcretKalemi vekUcretKalemi, ParaVeDovizId vekUcretMiktari, double vekUcretOrani, VekaketUcretTipNo vekUcretTipNo, DateTime? hesaplamaTarihi)
        {
            AvukatProLib2.Entities.AV001_TI_BIL_VEKALET_UCRET vekUcret = new AvukatProLib2.Entities.AV001_TI_BIL_VEKALET_UCRET();
            vekUcret.TAKIP_CIKISI = takipCikisi.Para;
            vekUcret.TAKIP_CIKISI_DOVIZ_ID = takipCikisi.DovizId;
            vekUcret.TARIFE_TARIHI = tarifeTarihi;
            vekUcret.VEK_UCR_MIKTARI = vekUcretMiktari.Para;
            vekUcret.VEK_UCR_MIKTARI_DOVIZ_ID = vekUcretMiktari.DovizId;
            vekUcret.VEK_UCR_ORANI = vekUcretOrani;
            vekUcret.VEK_UCR_TIP_NO = (byte)vekUcretTipNo; //Maktu-Nispi
            vekUcret.VEK_UCR_KALEM_NO = (byte)vekUcretKalemi;
            vekUcret.HESAPLAMA_TARIHI = hesaplamaTarihi ?? DateTime.Now;
            return vekUcret;
        }

        #endregion Vekalet Ücret Kalemi Getir

        #region FoyTaraf sorumluluk Oraný Hesapla

        /// <summary>
        /// Verilen föye ait taraflarýn sorumluluk oranlarýný hesaplar (Foy/Taraf Bazýnda)
        /// </summary>
        /// <param name="mFoy">Hesaplamanýn yapýlacaðý foy instance i</param>
        public static void FoyTarafSorumlulukOraniHesapla(AV001_TI_BIL_FOY mFoy)
        {
            foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
            {
                taraf.SORUMLULUK_ORANI = (double)(DovizHelper.CevirYTL(taraf.SORUMLU_OLUNAN_MIKTAR,
                                                                       taraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID,
                                                                       mFoy.TAKIP_TARIHI.Value) /
                                                  DovizHelper.CevirYTL(mFoy.ASIL_ALACAK, mFoy.ASIL_ALACAK_DOVIZ_ID.Value,
                                                                       mFoy.TAKIP_TARIHI.Value));
            }
        }

        #endregion FoyTaraf sorumluluk Oraný Hesapla
    }
}