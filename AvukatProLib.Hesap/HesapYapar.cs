using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AvukatProLib.Hesap
{
    public class HesapYapar
    {
        public event RunWorkerCompletedEventHandler IcraHesapSonucu;

        public static void HesaplaMasrafAvanslar(AV001_TI_BIL_FOY myFoy)
        {
            TList<AV001_TDI_BIL_MASRAF_AVANS> manuelAvanslar = myFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.FindAll(vi => vi.MANUEL_KAYIT_MI && vi.MASRAF_AVANS_TIP == 1);//Kaydedilen Avansların Diğer giderlere yansımaması için MASRAF_AVANS_TIP == 1 kotnrolü eklendi.
            if (myFoy.ID == 0)
            {
                myFoy.IHTAR_GIDERI = 0;
            }

            List<ParaVeDovizId> Eklenemeyenler = new List<ParaVeDovizId>();

            foreach (AV001_TDI_BIL_MASRAF_AVANS avans in manuelAvanslar)
            {
                if (avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Count == 0)
                    DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(avans, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));

                foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                {
                    TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI altKategori;
                    if (detay.HAREKET_ALT_KATEGORI_IDSource != null)
                    {
                        altKategori = detay.HAREKET_ALT_KATEGORI_IDSource;
                    }
                    else
                    {
                        altKategori = DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByID(detay.HAREKET_ALT_KATEGORI_ID);
                        DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.DeepLoad(altKategori, false, DeepLoadType.IncludeChildren, typeof(CS_KOD_HESAP_CETVEL_YERI));
                    }
                    //Toplam tutar, masraf gridinden - geliyordu. + yapmak için eklendi.
                    if (detay.TOPLAM_TUTAR < 0)
                        detay.TOPLAM_TUTAR *= -1;

                    if (altKategori != null)
                        if (myFoy.TAKIP_TARIHI.HasValue)
                            if (myFoy.TAKIP_TARIHI.Value >= detay.TARIH)
                            {
                                if (!altKategori.TO_HESAP_CETVEL_YERI.HasValue)
                                {
                                    Eklenemeyenler.Add(new ParaVeDovizId(detay.TOPLAM_TUTAR, 1));
                                    //ToDo : Katman basıldıktan sonra açılacak
                                    //Eklenemeyenler.Add(new ParaVeDovizId(detay.TOPLAM_TUTAR,detay.TOPLAM_TUTAR_DOVIZ_ID));
                                }
                                else
                                {
                                    ParaVeDovizId foydekiPara = new ParaVeDovizId((decimal)myFoy[altKategori.TO_HESAP_CETVEL_YERISource.KOLON_ADI], (int)myFoy[altKategori.TO_HESAP_CETVEL_YERISource.DOVIZ_KOLON_ADI.Trim()]);
                                    ParaVeDovizId detaydakiPara = new ParaVeDovizId(detay.TOPLAM_TUTAR, 1);
                                    //ToDo : Katman Basıldığında aşşağdaki kod kullanılacak
                                    //ParaVeDovizId detaydakiPara = new ParaVeDovizId(detay.TOPLAM_TUTAR, detay.TOPLAM_TUTAR_DOVIZ_ID);

                                    ParaVeDovizId toplam = ParaVeDovizId.Topla(foydekiPara, detaydakiPara);

                                    myFoy[altKategori.TO_HESAP_CETVEL_YERISource.KOLON_ADI.Trim()] = toplam.Para;
                                    myFoy[altKategori.TO_HESAP_CETVEL_YERISource.DOVIZ_KOLON_ADI.Trim()] = toplam.DovizId;
                                }
                            }
                            else if (myFoy.TAKIP_TARIHI.Value < detay.TARIH)
                            {
                                if (!altKategori.TS_HESAP_CETVEL_YERI.HasValue)
                                {
                                    //Eklenemeyenler.Add(new ParaVeDovizId(detay.TOPLAM_TUTAR, 1));
                                    //ToDo : Katman basılınca alttaki satır kullanılacak 0501
                                    Eklenemeyenler.Add(new ParaVeDovizId(detay.TOPLAM_TUTAR, detay.TOPLAM_TUTAR_DOVIZ_ID));
                                }
                                else
                                {
                                    ParaVeDovizId foydekiPara = new ParaVeDovizId((decimal)myFoy[altKategori.TS_HESAP_CETVEL_YERISource.KOLON_ADI.Trim()],
                                                        (int?)myFoy[altKategori.TS_HESAP_CETVEL_YERISource.DOVIZ_KOLON_ADI.Trim()]);
                                    //ParaVeDovizId detaydakiPara = new ParaVeDovizId(detay.TOPLAM_TUTAR, 1);
                                    //ToDo : Katman Basıldığında aşşağdaki kod kullanılacak
                                    ParaVeDovizId detaydakiPara = new ParaVeDovizId(detay.TOPLAM_TUTAR, detay.TOPLAM_TUTAR_DOVIZ_ID);

                                    ParaVeDovizId toplam = ParaVeDovizId.Topla(foydekiPara, detaydakiPara);

                                    myFoy[altKategori.TS_HESAP_CETVEL_YERISource.KOLON_ADI.Trim()] = toplam.Para;
                                    myFoy[altKategori.TS_HESAP_CETVEL_YERISource.DOVIZ_KOLON_ADI.Trim()] = toplam.DovizId;
                                }
                            }
                }
            }
            Eklenemeyenler.Add(new ParaVeDovizId(myFoy.DIGER_GIDERLER, myFoy.DIGER_GIDERLER_DOVIZ_ID.HasValue ? myFoy.DAVA_GIDERLERI_DOVIZ_ID.Value : 1));
            ParaVeDovizId sonuc = ParaVeDovizId.Topla(Eklenemeyenler);
            myFoy.DIGER_GIDERLER = sonuc.Para;
            myFoy.DIGER_GIDERLER_DOVIZ_ID = sonuc.DovizId;
        }

        public static string TebligatReferansNoOlustur()
        {
            var refNo = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, "SELECT TOP(1)TEBLIGAT_REFERANS_NO FROM AV001_TDI_BIL_TEBLIGAT ORDER BY ID DESC");
            if (refNo != null)
            {
                refNo = refNo.ToString().Substring(7, 5);
                int refNoSayi = Convert.ToInt32(refNo);
                return "E" + "-" + DateTime.Today.Year + "~" + (++refNoSayi).ToString();
            }
            else
            {
                string strRefNo = "E-" + DateTime.Today.Year.ToString() + "~10000";
                return strRefNo;
            }
        }

        /// <summary>
        /// Asıl Föyün belirli alanlarına eklenecek föyün değerlerini ekler,(gkn)
        /// </summary>
        /// <param name="asilFoy"></param>
        /// <param name="eklenecekFoy"></param>
        public void FoyleriTopla(AV001_TI_BIL_FOY asilFoy, AV001_TI_BIL_FOY eklenecekFoy)
        {
            asilFoy.BASVURMA_HARCI += DovizHelper.CevirYTL(eklenecekFoy.BASVURMA_HARCI, eklenecekFoy.BASVURMA_HARCI_DOVIZ_ID, DateTime.Now);
            asilFoy.BIRIKMIS_NAFAKA += DovizHelper.CevirYTL(eklenecekFoy.BIRIKMIS_NAFAKA, eklenecekFoy.BIRIKMIS_NAFAKA_DOVIZ_ID, DateTime.Now);
            asilFoy.CEK_KOMISYONU += DovizHelper.CevirYTL(eklenecekFoy.CEK_KOMISYONU, eklenecekFoy.CEK_KOMISYONU_DOVIZ_ID, DateTime.Now);
            asilFoy.DAMGA_PULU += DovizHelper.CevirYTL(eklenecekFoy.DAMGA_PULU, eklenecekFoy.DAMGA_PULU_DOVIZ_ID, DateTime.Now);
            asilFoy.DAVA_GIDERLERI += DovizHelper.CevirYTL(eklenecekFoy.DAVA_GIDERLERI, eklenecekFoy.DAVA_GIDERLERI_DOVIZ_ID, DateTime.Now);
            asilFoy.DAVA_INKAR_TAZMINATI += DovizHelper.CevirYTL(eklenecekFoy.DAVA_INKAR_TAZMINATI, eklenecekFoy.DAVA_INKAR_TAZMINATI_DOVIZ_ID, DateTime.Now);
            asilFoy.DAVA_VEKALET_UCRETI += DovizHelper.CevirYTL(eklenecekFoy.DAVA_VEKALET_UCRETI, eklenecekFoy.DAVA_VEKALET_UCRETI_DOVIZ_ID, DateTime.Now);
            asilFoy.DIGER_GIDERLER += DovizHelper.CevirYTL(eklenecekFoy.DIGER_GIDERLER, eklenecekFoy.DIGER_GIDERLER_DOVIZ_ID, DateTime.Now);
            asilFoy.DIGER_HARC += DovizHelper.CevirYTL(eklenecekFoy.DIGER_HARC, eklenecekFoy.DIGER_HARC_DOVIZ_ID, DateTime.Now);
            asilFoy.FERAGAT_HARCI += DovizHelper.CevirYTL(eklenecekFoy.FERAGAT_HARCI, eklenecekFoy.FERAGAT_HARCI_DOVIZ_ID, DateTime.Now);
            asilFoy.FERAGAT_TOPLAMI += DovizHelper.CevirYTL(eklenecekFoy.FERAGAT_TOPLAMI, eklenecekFoy.FERAGAT_TOPLAMI_DOVIZ_ID, DateTime.Now);
            asilFoy.HARC_TOPLAMI += DovizHelper.CevirYTL(eklenecekFoy.HARC_TOPLAMI, eklenecekFoy.HARC_TOPLAMI_DOVIZ_ID, DateTime.Now);
            asilFoy.ICRA_INKAR_TAZMINATI += DovizHelper.CevirYTL(eklenecekFoy.ICRA_INKAR_TAZMINATI, eklenecekFoy.ICRA_INKAR_TAZMINATI_DOVIZ_ID, DateTime.Now);
            asilFoy.IFLAS_BASVURMA_HARCI += DovizHelper.CevirYTL(eklenecekFoy.IFLAS_BASVURMA_HARCI, eklenecekFoy.IFLAS_BASVURMA_HARCI_DOVIZ_ID, DateTime.Now);
            asilFoy.IFLASIN_ACILMASI_HARCI += DovizHelper.CevirYTL(eklenecekFoy.IFLASIN_ACILMASI_HARCI, eklenecekFoy.IFLASIN_ACILMASI_HARCI_DOVIZ_ID, DateTime.Now);
            asilFoy.IH_VEKALET_UCRETI += DovizHelper.CevirYTL(eklenecekFoy.IH_VEKALET_UCRETI, eklenecekFoy.IH_VEKALET_UCRETI_DOVIZ_ID, DateTime.Now);
            asilFoy.IHTAR_GIDERI += DovizHelper.CevirYTL(eklenecekFoy.IHTAR_GIDERI, eklenecekFoy.IHTAR_GIDERI_DOVIZ_ID, DateTime.Now);
            asilFoy.ILAM_BK_YARG_ONAMA += DovizHelper.CevirYTL(eklenecekFoy.ILAM_BK_YARG_ONAMA, eklenecekFoy.ILAM_BK_YARG_ONAMA_DOVIZ_ID, DateTime.Now);
            asilFoy.ILAM_INKAR_TAZMINATI += DovizHelper.CevirYTL(eklenecekFoy.ILAM_INKAR_TAZMINATI, eklenecekFoy.ILAM_INKAR_TAZMINATI_DOVIZ_ID, DateTime.Now);
            asilFoy.ILAM_TEBLIG_GIDERI += DovizHelper.CevirYTL(eklenecekFoy.ILAM_TEBLIG_GIDERI, eklenecekFoy.ILAM_TEBLIG_GIDERI_DOVIZ_ID, DateTime.Now);
            asilFoy.ILAM_UCRETLER_TOPLAMI += DovizHelper.CevirYTL(eklenecekFoy.ILAM_UCRETLER_TOPLAMI, eklenecekFoy.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID, DateTime.Now);
            asilFoy.ILAM_VEK_UCR += DovizHelper.CevirYTL(eklenecekFoy.ILAM_VEK_UCR, eklenecekFoy.ILAM_VEK_UCR_DOVIZ_ID, DateTime.Now);
            asilFoy.ILAM_YARGILAMA_GIDERI += DovizHelper.CevirYTL(eklenecekFoy.ILAM_YARGILAMA_GIDERI, eklenecekFoy.ILAM_YARGILAMA_GIDERI_DOVIZ_ID, DateTime.Now);
            asilFoy.ILK_GIDERLER += DovizHelper.CevirYTL(eklenecekFoy.ILK_GIDERLER, eklenecekFoy.ILK_GIDERLER_DOVIZ_ID, DateTime.Now);
            asilFoy.ILK_TEBLIGAT_GIDERI += DovizHelper.CevirYTL(eklenecekFoy.ILK_TEBLIGAT_GIDERI, eklenecekFoy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID, DateTime.Now);
            asilFoy.IT_GIDERI += DovizHelper.CevirYTL(eklenecekFoy.IT_GIDERI, eklenecekFoy.IT_GIDERI_DOVIZ_ID, DateTime.Now);
            asilFoy.IT_HACIZDE_ODENEN += DovizHelper.CevirYTL(eklenecekFoy.IT_HACIZDE_ODENEN, eklenecekFoy.IT_HACIZDE_ODENEN_DOVIZ_ID, DateTime.Now);
            asilFoy.IT_VEKALET_UCRETI += DovizHelper.CevirYTL(eklenecekFoy.IT_VEKALET_UCRETI, eklenecekFoy.IT_VEKALET_UCRETI_DOVIZ_ID, DateTime.Now);
            asilFoy.KALAN += DovizHelper.CevirYTL(eklenecekFoy.KALAN, eklenecekFoy.KALAN_DOVIZ_ID, DateTime.Now);
            asilFoy.KARSI_VEKALET_TOPLAMI += DovizHelper.CevirYTL(eklenecekFoy.KARSI_VEKALET_TOPLAMI, eklenecekFoy.KARSI_VEKALET_TOPLAMI_DOVIZ_ID, DateTime.Now);
            asilFoy.KARSILIK_TUTARI += DovizHelper.CevirYTL(eklenecekFoy.KARSILIK_TUTARI, eklenecekFoy.KARSILIK_TUTARI_DOVIZ_ID, DateTime.Now);
            asilFoy.KARSILIKSIZ_CEK_TAZMINATI += DovizHelper.CevirYTL(eklenecekFoy.KARSILIKSIZ_CEK_TAZMINATI, eklenecekFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, DateTime.Now);
            asilFoy.MAHSUP_TOPLAMI += DovizHelper.CevirYTL(eklenecekFoy.MAHSUP_TOPLAMI, eklenecekFoy.MAHSUP_TOPLAMI_DOVIZ_ID, DateTime.Now);
            asilFoy.MASAYA_KATILMA_HARCI += DovizHelper.CevirYTL(eklenecekFoy.MASAYA_KATILMA_HARCI, eklenecekFoy.MASAYA_KATILMA_HARCI_DOVIZ_ID, DateTime.Now);
            asilFoy.ODEME_TOPLAMI += DovizHelper.CevirYTL(eklenecekFoy.ODEME_TOPLAMI, eklenecekFoy.ODEME_TOPLAMI_DOVIZ_ID, DateTime.Now);
            asilFoy.ODENEN_TAHSIL_HARCI += DovizHelper.CevirYTL(eklenecekFoy.ODENEN_TAHSIL_HARCI, eklenecekFoy.ODENEN_TAHSIL_HARCI_DOVIZ_ID, DateTime.Now);
            asilFoy.PAYLASMA_HARCI += DovizHelper.CevirYTL(eklenecekFoy.PAYLASMA_HARCI, eklenecekFoy.PAYLASMA_HARCI_DOVIZ_ID, DateTime.Now);
            asilFoy.PESIN_HARC += DovizHelper.CevirYTL(eklenecekFoy.PESIN_HARC, eklenecekFoy.PESIN_HARC_DOVIZ_ID, DateTime.Now);
            asilFoy.PROTESTO_GIDERI += DovizHelper.CevirYTL(eklenecekFoy.PROTESTO_GIDERI, eklenecekFoy.PROTESTO_GIDERI_DOVIZ_ID, DateTime.Now);
            asilFoy.TAHLIYE_HARCI += DovizHelper.CevirYTL(eklenecekFoy.TAHLIYE_HARCI, eklenecekFoy.TAHLIYE_HARCI_DOVIZ_ID, DateTime.Now);
            asilFoy.TAHLIYE_VEK_UCR += DovizHelper.CevirYTL(eklenecekFoy.TAHLIYE_VEK_UCR, eklenecekFoy.TAHLIYE_VEK_UCR_DOVIZ_ID, DateTime.Now);
            asilFoy.TAKIP_VEKALET_UCRETI += DovizHelper.CevirYTL(eklenecekFoy.TAKIP_VEKALET_UCRETI, eklenecekFoy.TAKIP_VEKALET_UCRETI_DOVIZ_ID, DateTime.Now);
            asilFoy.TD_BAKIYE_HARC += DovizHelper.CevirYTL(eklenecekFoy.TD_BAKIYE_HARC, eklenecekFoy.TD_BAKIYE_HARC_DOVIZ_ID, DateTime.Now);
            asilFoy.TD_GIDERI += DovizHelper.CevirYTL(eklenecekFoy.TD_GIDERI, eklenecekFoy.TD_GIDERI_DOVIZ_ID, DateTime.Now);
            asilFoy.TD_TEBLIG_GIDERI += DovizHelper.CevirYTL(eklenecekFoy.TD_TEBLIG_GIDERI, eklenecekFoy.TD_TEBLIG_GIDERI_DOVIZ_ID, DateTime.Now);
            asilFoy.TD_VEK_UCR += DovizHelper.CevirYTL(eklenecekFoy.TD_VEK_UCR, eklenecekFoy.TD_VEK_UCR_DOVIZ_ID, DateTime.Now);
            asilFoy.TESLIM_HARCI += DovizHelper.CevirYTL(eklenecekFoy.TESLIM_HARCI, eklenecekFoy.TESLIM_HARCI_DOVIZ_ID, DateTime.Now);
            asilFoy.TO_MASRAF_TOPLAMI += DovizHelper.CevirYTL(eklenecekFoy.TO_MASRAF_TOPLAMI, eklenecekFoy.TO_MASRAF_TOPLAMI_DOVIZ_ID, DateTime.Now);
            asilFoy.TO_ODEME_MAHSUP_TOPLAMI += DovizHelper.CevirYTL(eklenecekFoy.TO_ODEME_MAHSUP_TOPLAMI, eklenecekFoy.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID, DateTime.Now);
            asilFoy.TO_ODEME_TOPLAMI += DovizHelper.CevirYTL(eklenecekFoy.TO_ODEME_TOPLAMI, eklenecekFoy.TO_ODEME_TOPLAMI_DOVIZ_ID, DateTime.Now);
            asilFoy.TO_VEKALET_TOPLAMI += DovizHelper.CevirYTL(eklenecekFoy.TO_VEKALET_TOPLAMI, eklenecekFoy.TO_VEKALET_TOPLAMI_DOVIZ_ID, DateTime.Now);
            asilFoy.TO_YONETIMG_TAZMINATI += DovizHelper.CevirYTL(eklenecekFoy.TO_YONETIMG_TAZMINATI, eklenecekFoy.TO_YONETIMG_TAZMINATI_DOVIZ_ID, DateTime.Now);
            asilFoy.TS_MASRAF_TOPLAMI += DovizHelper.CevirYTL(eklenecekFoy.TS_MASRAF_TOPLAMI, eklenecekFoy.TS_MASRAF_TOPLAMI_DOVIZ_ID, DateTime.Now);
            asilFoy.TS_VEKALET_TOPLAMI += DovizHelper.CevirYTL(eklenecekFoy.TS_VEKALET_TOPLAMI, eklenecekFoy.TS_VEKALET_TOPLAMI_DOVIZ_ID, DateTime.Now);
            asilFoy.TUM_MASRAF_TOPLAMI += DovizHelper.CevirYTL(eklenecekFoy.TUM_MASRAF_TOPLAMI, eklenecekFoy.TUM_MASRAF_TOPLAMI_DOVIZ_ID, DateTime.Now);
            asilFoy.TUM_VEKALET_TOPLAMI += DovizHelper.CevirYTL(eklenecekFoy.TUM_VEKALET_TOPLAMI, eklenecekFoy.TUM_VEKALET_TOPLAMI_DOVIZ_ID, DateTime.Now);
            asilFoy.VEKALET_HARCI += DovizHelper.CevirYTL(eklenecekFoy.VEKALET_HARCI, eklenecekFoy.VEKALET_HARCI_DOVIZ_ID, DateTime.Now);
            asilFoy.VEKALET_PULU += DovizHelper.CevirYTL(eklenecekFoy.VEKALET_PULU, eklenecekFoy.VEKALET_PULU_DOVIZ_ID, DateTime.Now);
        }

        /// <summary>
        /// icra föy dizisini toplar
        /// </summary>
        /// <param name="foyListesi">verilen listeyi toplar</param>
        /// <param name="asilFoy">toplanan listeyi bu föyün üzerine ekler</param>
        public void FoyleriToplaLimited(List<AV001_TI_BIL_FOY> foyListesi, AV001_TI_BIL_FOY asilFoy)
        {
            AV001_TI_BIL_FOY araFoy = new AV001_TI_BIL_FOY();

            DateTime zaman = DateTime.Now;

            if (asilFoy.TAKIP_TARIHI != null)
                zaman = asilFoy.TAKIP_TARIHI.Value;

            #region Dictonory Oluşturuldu

            Dictionary<string, List<ParaVeDovizId>> paralarinSozlugu = new Dictionary<string, List<ParaVeDovizId>>();

            paralarinSozlugu.Add("BASVURMA_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("BIRIKMIS_NAFAKA", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("CEK_KOMISYONU", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("DAMGA_PULU", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("DAVA_GIDERLERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("DAVA_INKAR_TAZMINATI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("DAVA_VEKALET_UCRETI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("DIGER_GIDERLER", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("DIGER_HARC", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("FERAGAT_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("FERAGAT_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("HARC_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ICRA_INKAR_TAZMINATI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IFLAS_BASVURMA_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IFLASIN_ACILMASI_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IH_VEKALET_UCRETI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IHTAR_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILAM_BK_YARG_ONAMA", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILAM_INKAR_TAZMINATI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILAM_TEBLIG_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILAM_UCRETLER_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILAM_VEK_UCR", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILAM_YARGILAMA_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILK_GIDERLER", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILK_TEBLIGAT_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IT_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IT_HACIZDE_ODENEN", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IT_VEKALET_UCRETI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("KALAN", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("KARSI_VEKALET_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("KARSILIK_TUTARI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("KARSILIKSIZ_CEK_TAZMINATI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("MAHSUP_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("MASAYA_KATILMA_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ODEME_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ODENEN_TAHSIL_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("PAYLASMA_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("PESIN_HARC", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("PROTESTO_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TAHLIYE_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TAHLIYE_VEK_UCR", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TAKIP_VEKALET_UCRETI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TD_BAKIYE_HARC", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TD_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TD_TEBLIG_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TD_VEK_UCR", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TESLIM_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TO_MASRAF_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TO_ODEME_MAHSUP_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TO_ODEME_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TO_VEKALET_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TO_YONETIMG_TAZMINATI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TS_MASRAF_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TS_VEKALET_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TUM_MASRAF_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TUM_VEKALET_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("VEKALET_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("VEKALET_PULU", new List<ParaVeDovizId>());

            #endregion Dictonory Oluşturuldu

            foreach (AV001_TI_BIL_FOY foy in foyListesi)
            {
                #region İlgili Alanlara Değerler Ekleniyor

                paralarinSozlugu["BASVURMA_HARCI"].Add(new ParaVeDovizId(foy.BASVURMA_HARCI, foy.BASVURMA_HARCI_DOVIZ_ID));
                paralarinSozlugu["BIRIKMIS_NAFAKA"].Add(new ParaVeDovizId(foy.BIRIKMIS_NAFAKA, foy.BIRIKMIS_NAFAKA_DOVIZ_ID));
                paralarinSozlugu["CEK_KOMISYONU"].Add(new ParaVeDovizId(foy.CEK_KOMISYONU, foy.CEK_KOMISYONU_DOVIZ_ID));
                paralarinSozlugu["DAMGA_PULU"].Add(new ParaVeDovizId(foy.DAMGA_PULU, foy.DAMGA_PULU_DOVIZ_ID));
                paralarinSozlugu["DAVA_GIDERLERI"].Add(new ParaVeDovizId(foy.DAVA_GIDERLERI, foy.DAVA_GIDERLERI_DOVIZ_ID));
                paralarinSozlugu["DAVA_INKAR_TAZMINATI"].Add(new ParaVeDovizId(foy.DAVA_INKAR_TAZMINATI, foy.DAVA_INKAR_TAZMINATI_DOVIZ_ID));
                paralarinSozlugu["DAVA_VEKALET_UCRETI"].Add(new ParaVeDovizId(foy.DAVA_VEKALET_UCRETI, foy.DAVA_VEKALET_UCRETI_DOVIZ_ID));
                paralarinSozlugu["DIGER_GIDERLER"].Add(new ParaVeDovizId(foy.DIGER_GIDERLER, foy.DIGER_GIDERLER_DOVIZ_ID));
                paralarinSozlugu["DIGER_HARC"].Add(new ParaVeDovizId(foy.DIGER_HARC, foy.DIGER_HARC_DOVIZ_ID));
                paralarinSozlugu["FERAGAT_HARCI"].Add(new ParaVeDovizId(foy.FERAGAT_HARCI, foy.FERAGAT_HARCI_DOVIZ_ID));
                paralarinSozlugu["FERAGAT_TOPLAMI"].Add(new ParaVeDovizId(foy.FERAGAT_TOPLAMI, foy.FERAGAT_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["HARC_TOPLAMI"].Add(new ParaVeDovizId(foy.HARC_TOPLAMI, foy.HARC_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["ICRA_INKAR_TAZMINATI"].Add(new ParaVeDovizId(foy.ICRA_INKAR_TAZMINATI, foy.ICRA_INKAR_TAZMINATI_DOVIZ_ID));
                paralarinSozlugu["IFLAS_BASVURMA_HARCI"].Add(new ParaVeDovizId(foy.IFLAS_BASVURMA_HARCI, foy.IFLAS_BASVURMA_HARCI_DOVIZ_ID));
                paralarinSozlugu["IFLASIN_ACILMASI_HARCI"].Add(new ParaVeDovizId(foy.IFLASIN_ACILMASI_HARCI, foy.IFLASIN_ACILMASI_HARCI_DOVIZ_ID));
                paralarinSozlugu["IH_VEKALET_UCRETI"].Add(new ParaVeDovizId(foy.IH_VEKALET_UCRETI, foy.IH_VEKALET_UCRETI_DOVIZ_ID));
                paralarinSozlugu["IHTAR_GIDERI"].Add(new ParaVeDovizId(foy.IHTAR_GIDERI, foy.IHTAR_GIDERI_DOVIZ_ID));
                paralarinSozlugu["ILAM_BK_YARG_ONAMA"].Add(new ParaVeDovizId(foy.ILAM_BK_YARG_ONAMA, foy.ILAM_BK_YARG_ONAMA_DOVIZ_ID));
                paralarinSozlugu["ILAM_INKAR_TAZMINATI"].Add(new ParaVeDovizId(foy.ILAM_INKAR_TAZMINATI, foy.ILAM_INKAR_TAZMINATI_DOVIZ_ID));
                paralarinSozlugu["ILAM_TEBLIG_GIDERI"].Add(new ParaVeDovizId(foy.ILAM_TEBLIG_GIDERI, foy.ILAM_TEBLIG_GIDERI_DOVIZ_ID));
                paralarinSozlugu["ILAM_UCRETLER_TOPLAMI"].Add(new ParaVeDovizId(foy.ILAM_UCRETLER_TOPLAMI, foy.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["ILAM_VEK_UCR"].Add(new ParaVeDovizId(foy.ILAM_VEK_UCR, foy.ILAM_VEK_UCR_DOVIZ_ID));
                paralarinSozlugu["ILAM_YARGILAMA_GIDERI"].Add(new ParaVeDovizId(foy.ILAM_YARGILAMA_GIDERI, foy.ILAM_YARGILAMA_GIDERI_DOVIZ_ID));
                paralarinSozlugu["ILK_GIDERLER"].Add(new ParaVeDovizId(foy.ILK_GIDERLER, foy.ILK_GIDERLER_DOVIZ_ID));
                paralarinSozlugu["ILK_TEBLIGAT_GIDERI"].Add(new ParaVeDovizId(foy.ILK_TEBLIGAT_GIDERI, foy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID));
                paralarinSozlugu["IT_GIDERI"].Add(new ParaVeDovizId(foy.IT_GIDERI, foy.IT_GIDERI_DOVIZ_ID));
                paralarinSozlugu["IT_HACIZDE_ODENEN"].Add(new ParaVeDovizId(foy.IT_HACIZDE_ODENEN, foy.IT_HACIZDE_ODENEN_DOVIZ_ID));
                paralarinSozlugu["IT_VEKALET_UCRETI"].Add(new ParaVeDovizId(foy.IT_VEKALET_UCRETI, foy.IT_VEKALET_UCRETI_DOVIZ_ID));
                paralarinSozlugu["KALAN"].Add(new ParaVeDovizId(foy.KALAN, foy.KALAN_DOVIZ_ID));
                paralarinSozlugu["KARSI_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(foy.KARSI_VEKALET_TOPLAMI, foy.KARSI_VEKALET_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["KARSILIK_TUTARI"].Add(new ParaVeDovizId(foy.KARSILIK_TUTARI, foy.KARSILIK_TUTARI_DOVIZ_ID));
                paralarinSozlugu["KARSILIKSIZ_CEK_TAZMINATI"].Add(new ParaVeDovizId(foy.KARSILIKSIZ_CEK_TAZMINATI, foy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID));
                paralarinSozlugu["MAHSUP_TOPLAMI"].Add(new ParaVeDovizId(foy.MAHSUP_TOPLAMI, foy.MAHSUP_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["MASAYA_KATILMA_HARCI"].Add(new ParaVeDovizId(foy.MASAYA_KATILMA_HARCI, foy.MASAYA_KATILMA_HARCI_DOVIZ_ID));
                paralarinSozlugu["ODEME_TOPLAMI"].Add(new ParaVeDovizId(foy.ODEME_TOPLAMI, foy.ODEME_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["ODENEN_TAHSIL_HARCI"].Add(new ParaVeDovizId(foy.ODENEN_TAHSIL_HARCI, foy.ODENEN_TAHSIL_HARCI_DOVIZ_ID));
                paralarinSozlugu["PAYLASMA_HARCI"].Add(new ParaVeDovizId(foy.PAYLASMA_HARCI, foy.PAYLASMA_HARCI_DOVIZ_ID));
                paralarinSozlugu["PESIN_HARC"].Add(new ParaVeDovizId(foy.PESIN_HARC, foy.PESIN_HARC_DOVIZ_ID));
                paralarinSozlugu["PROTESTO_GIDERI"].Add(new ParaVeDovizId(foy.PROTESTO_GIDERI, foy.PROTESTO_GIDERI_DOVIZ_ID));
                paralarinSozlugu["TAHLIYE_HARCI"].Add(new ParaVeDovizId(foy.TAHLIYE_HARCI, foy.TAHLIYE_HARCI_DOVIZ_ID));
                paralarinSozlugu["TAHLIYE_VEK_UCR"].Add(new ParaVeDovizId(foy.TAHLIYE_VEK_UCR, foy.TAHLIYE_VEK_UCR_DOVIZ_ID));
                paralarinSozlugu["TAKIP_VEKALET_UCRETI"].Add(new ParaVeDovizId(foy.TAKIP_VEKALET_UCRETI, foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID));
                paralarinSozlugu["TD_BAKIYE_HARC"].Add(new ParaVeDovizId(foy.TD_BAKIYE_HARC, foy.TD_BAKIYE_HARC_DOVIZ_ID));
                paralarinSozlugu["TD_GIDERI"].Add(new ParaVeDovizId(foy.TD_GIDERI, foy.TD_GIDERI_DOVIZ_ID));
                paralarinSozlugu["TD_TEBLIG_GIDERI"].Add(new ParaVeDovizId(foy.TD_TEBLIG_GIDERI, foy.TD_TEBLIG_GIDERI_DOVIZ_ID));
                paralarinSozlugu["TD_VEK_UCR"].Add(new ParaVeDovizId(foy.TD_VEK_UCR, foy.TD_VEK_UCR_DOVIZ_ID));
                paralarinSozlugu["TESLIM_HARCI"].Add(new ParaVeDovizId(foy.TESLIM_HARCI, foy.TESLIM_HARCI_DOVIZ_ID));
                paralarinSozlugu["TO_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(foy.TO_MASRAF_TOPLAMI, foy.TO_MASRAF_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TO_ODEME_MAHSUP_TOPLAMI"].Add(new ParaVeDovizId(foy.TO_ODEME_MAHSUP_TOPLAMI, foy.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TO_ODEME_TOPLAMI"].Add(new ParaVeDovizId(foy.TO_ODEME_TOPLAMI, foy.TO_ODEME_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TO_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(foy.TO_VEKALET_TOPLAMI, foy.TO_VEKALET_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TO_YONETIMG_TAZMINATI"].Add(new ParaVeDovizId(foy.TO_YONETIMG_TAZMINATI, foy.TO_YONETIMG_TAZMINATI_DOVIZ_ID));
                paralarinSozlugu["TS_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(foy.TS_MASRAF_TOPLAMI, foy.TS_MASRAF_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TS_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(foy.TS_VEKALET_TOPLAMI, foy.TS_VEKALET_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TUM_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(foy.TUM_MASRAF_TOPLAMI, foy.TUM_MASRAF_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TUM_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(foy.TUM_VEKALET_TOPLAMI, foy.TUM_VEKALET_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["VEKALET_HARCI"].Add(new ParaVeDovizId(foy.VEKALET_HARCI, foy.VEKALET_HARCI_DOVIZ_ID));
                paralarinSozlugu["VEKALET_PULU"].Add(new ParaVeDovizId(foy.VEKALET_PULU, foy.VEKALET_PULU_DOVIZ_ID));

                #endregion İlgili Alanlara Değerler Ekleniyor
            }

            #region Ara Föye Değerler Atanıyor

            ParaVeDovizId sonucBASVURMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["BASVURMA_HARCI"], zaman); araFoy.BASVURMA_HARCI = sonucBASVURMA_HARCI.Para; araFoy.BASVURMA_HARCI_DOVIZ_ID = sonucBASVURMA_HARCI.DovizId;
            ParaVeDovizId sonucBIRIKMIS_NAFAKA = FaizHelper.ParalariTopla(paralarinSozlugu["BIRIKMIS_NAFAKA"], zaman); araFoy.BIRIKMIS_NAFAKA = sonucBIRIKMIS_NAFAKA.Para; araFoy.BIRIKMIS_NAFAKA_DOVIZ_ID = sonucBIRIKMIS_NAFAKA.DovizId;
            ParaVeDovizId sonucCEK_KOMISYONU = FaizHelper.ParalariTopla(paralarinSozlugu["CEK_KOMISYONU"], zaman); araFoy.CEK_KOMISYONU = sonucCEK_KOMISYONU.Para; araFoy.CEK_KOMISYONU_DOVIZ_ID = sonucCEK_KOMISYONU.DovizId;
            ParaVeDovizId sonucDAMGA_PULU = FaizHelper.ParalariTopla(paralarinSozlugu["DAMGA_PULU"], zaman); araFoy.DAMGA_PULU = sonucDAMGA_PULU.Para; araFoy.DAMGA_PULU_DOVIZ_ID = sonucDAMGA_PULU.DovizId;
            ParaVeDovizId sonucDAVA_GIDERLERI = FaizHelper.ParalariTopla(paralarinSozlugu["DAVA_GIDERLERI"], zaman); araFoy.DAVA_GIDERLERI = sonucDAVA_GIDERLERI.Para; araFoy.DAVA_GIDERLERI_DOVIZ_ID = sonucDAVA_GIDERLERI.DovizId;
            ParaVeDovizId sonucDAVA_INKAR_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["DAVA_INKAR_TAZMINATI"], zaman); araFoy.DAVA_INKAR_TAZMINATI = sonucDAVA_INKAR_TAZMINATI.Para; araFoy.DAVA_INKAR_TAZMINATI_DOVIZ_ID = sonucDAVA_INKAR_TAZMINATI.DovizId;
            ParaVeDovizId sonucDAVA_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["DAVA_VEKALET_UCRETI"], zaman); araFoy.DAVA_VEKALET_UCRETI = sonucDAVA_VEKALET_UCRETI.Para; araFoy.DAVA_VEKALET_UCRETI_DOVIZ_ID = sonucDAVA_VEKALET_UCRETI.DovizId;
            ParaVeDovizId sonucDIGER_GIDERLER = FaizHelper.ParalariTopla(paralarinSozlugu["DIGER_GIDERLER"], zaman); araFoy.DIGER_GIDERLER = sonucDIGER_GIDERLER.Para; araFoy.DIGER_GIDERLER_DOVIZ_ID = sonucDIGER_GIDERLER.DovizId;
            ParaVeDovizId sonucDIGER_HARC = FaizHelper.ParalariTopla(paralarinSozlugu["DIGER_HARC"], zaman); araFoy.DIGER_HARC = sonucDIGER_HARC.Para; araFoy.DIGER_HARC_DOVIZ_ID = sonucDIGER_HARC.DovizId;
            ParaVeDovizId sonucFERAGAT_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["FERAGAT_HARCI"], zaman); araFoy.FERAGAT_HARCI = sonucFERAGAT_HARCI.Para; araFoy.FERAGAT_HARCI_DOVIZ_ID = sonucFERAGAT_HARCI.DovizId;
            ParaVeDovizId sonucFERAGAT_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["FERAGAT_TOPLAMI"], zaman); araFoy.FERAGAT_TOPLAMI = sonucFERAGAT_TOPLAMI.Para; araFoy.FERAGAT_TOPLAMI_DOVIZ_ID = sonucFERAGAT_TOPLAMI.DovizId;
            ParaVeDovizId sonucHARC_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["HARC_TOPLAMI"], zaman); araFoy.HARC_TOPLAMI = sonucHARC_TOPLAMI.Para; araFoy.HARC_TOPLAMI_DOVIZ_ID = sonucHARC_TOPLAMI.DovizId;
            ParaVeDovizId sonucICRA_INKAR_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["ICRA_INKAR_TAZMINATI"], zaman); araFoy.ICRA_INKAR_TAZMINATI = sonucICRA_INKAR_TAZMINATI.Para; araFoy.ICRA_INKAR_TAZMINATI_DOVIZ_ID = sonucICRA_INKAR_TAZMINATI.DovizId;
            ParaVeDovizId sonucIFLAS_BASVURMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["IFLAS_BASVURMA_HARCI"], zaman); araFoy.IFLAS_BASVURMA_HARCI = sonucIFLAS_BASVURMA_HARCI.Para; araFoy.IFLAS_BASVURMA_HARCI_DOVIZ_ID = sonucIFLAS_BASVURMA_HARCI.DovizId;
            ParaVeDovizId sonucIFLASIN_ACILMASI_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["IFLASIN_ACILMASI_HARCI"], zaman); araFoy.IFLASIN_ACILMASI_HARCI = sonucIFLASIN_ACILMASI_HARCI.Para; araFoy.IFLASIN_ACILMASI_HARCI_DOVIZ_ID = sonucIFLASIN_ACILMASI_HARCI.DovizId;
            ParaVeDovizId sonucIH_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["IH_VEKALET_UCRETI"], zaman); araFoy.IH_VEKALET_UCRETI = sonucIH_VEKALET_UCRETI.Para; araFoy.IH_VEKALET_UCRETI_DOVIZ_ID = sonucIH_VEKALET_UCRETI.DovizId;
            ParaVeDovizId sonucIHTAR_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["IHTAR_GIDERI"], zaman); araFoy.IHTAR_GIDERI = sonucIHTAR_GIDERI.Para; araFoy.IHTAR_GIDERI_DOVIZ_ID = sonucIHTAR_GIDERI.DovizId;
            ParaVeDovizId sonucILAM_BK_YARG_ONAMA = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_BK_YARG_ONAMA"], zaman); araFoy.ILAM_BK_YARG_ONAMA = sonucILAM_BK_YARG_ONAMA.Para; araFoy.ILAM_BK_YARG_ONAMA_DOVIZ_ID = sonucILAM_BK_YARG_ONAMA.DovizId;
            ParaVeDovizId sonucILAM_INKAR_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_INKAR_TAZMINATI"], zaman); araFoy.ILAM_INKAR_TAZMINATI = sonucILAM_INKAR_TAZMINATI.Para; araFoy.ILAM_INKAR_TAZMINATI_DOVIZ_ID = sonucILAM_INKAR_TAZMINATI.DovizId;
            ParaVeDovizId sonucILAM_TEBLIG_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_TEBLIG_GIDERI"], zaman); araFoy.ILAM_TEBLIG_GIDERI = sonucILAM_TEBLIG_GIDERI.Para; araFoy.ILAM_TEBLIG_GIDERI_DOVIZ_ID = sonucILAM_TEBLIG_GIDERI.DovizId;
            ParaVeDovizId sonucILAM_UCRETLER_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_UCRETLER_TOPLAMI"], zaman); araFoy.ILAM_UCRETLER_TOPLAMI = sonucILAM_UCRETLER_TOPLAMI.Para; araFoy.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID = sonucILAM_UCRETLER_TOPLAMI.DovizId;
            ParaVeDovizId sonucILAM_VEK_UCR = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_VEK_UCR"], zaman); araFoy.ILAM_VEK_UCR = sonucILAM_VEK_UCR.Para; araFoy.ILAM_VEK_UCR_DOVIZ_ID = sonucILAM_VEK_UCR.DovizId;
            ParaVeDovizId sonucILAM_YARGILAMA_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_YARGILAMA_GIDERI"], zaman); araFoy.ILAM_YARGILAMA_GIDERI = sonucILAM_YARGILAMA_GIDERI.Para; araFoy.ILAM_YARGILAMA_GIDERI_DOVIZ_ID = sonucILAM_YARGILAMA_GIDERI.DovizId;
            ParaVeDovizId sonucILK_GIDERLER = FaizHelper.ParalariTopla(paralarinSozlugu["ILK_GIDERLER"], zaman); araFoy.ILK_GIDERLER = sonucILK_GIDERLER.Para; araFoy.ILK_GIDERLER_DOVIZ_ID = sonucILK_GIDERLER.DovizId;
            ParaVeDovizId sonucILK_TEBLIGAT_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["ILK_TEBLIGAT_GIDERI"], zaman); araFoy.ILK_TEBLIGAT_GIDERI = sonucILK_TEBLIGAT_GIDERI.Para; araFoy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID = sonucILK_TEBLIGAT_GIDERI.DovizId;
            ParaVeDovizId sonucIT_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["IT_GIDERI"], zaman); araFoy.IT_GIDERI = sonucIT_GIDERI.Para; araFoy.IT_GIDERI_DOVIZ_ID = sonucIT_GIDERI.DovizId;
            ParaVeDovizId sonucIT_HACIZDE_ODENEN = FaizHelper.ParalariTopla(paralarinSozlugu["IT_HACIZDE_ODENEN"], zaman); araFoy.IT_HACIZDE_ODENEN = sonucIT_HACIZDE_ODENEN.Para; araFoy.IT_HACIZDE_ODENEN_DOVIZ_ID = sonucIT_HACIZDE_ODENEN.DovizId;
            ParaVeDovizId sonucIT_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["IT_VEKALET_UCRETI"], zaman); araFoy.IT_VEKALET_UCRETI = sonucIT_VEKALET_UCRETI.Para; araFoy.IT_VEKALET_UCRETI_DOVIZ_ID = sonucIT_VEKALET_UCRETI.DovizId;
            ParaVeDovizId sonucKALAN = FaizHelper.ParalariTopla(paralarinSozlugu["KALAN"], zaman); araFoy.KALAN = sonucKALAN.Para; araFoy.KALAN_DOVIZ_ID = sonucKALAN.DovizId;
            ParaVeDovizId sonucKARSI_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["KARSI_VEKALET_TOPLAMI"], zaman); araFoy.KARSI_VEKALET_TOPLAMI = sonucKARSI_VEKALET_TOPLAMI.Para; araFoy.KARSI_VEKALET_TOPLAMI_DOVIZ_ID = sonucKARSI_VEKALET_TOPLAMI.DovizId;
            ParaVeDovizId sonucKARSILIK_TUTARI = FaizHelper.ParalariTopla(paralarinSozlugu["KARSILIK_TUTARI"], zaman); araFoy.KARSILIK_TUTARI = sonucKARSILIK_TUTARI.Para; araFoy.KARSILIK_TUTARI_DOVIZ_ID = sonucKARSILIK_TUTARI.DovizId;
            ParaVeDovizId sonucKARSILIKSIZ_CEK_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["KARSILIKSIZ_CEK_TAZMINATI"], zaman); araFoy.KARSILIKSIZ_CEK_TAZMINATI = sonucKARSILIKSIZ_CEK_TAZMINATI.Para; araFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = sonucKARSILIKSIZ_CEK_TAZMINATI.DovizId;
            ParaVeDovizId sonucMAHSUP_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["MAHSUP_TOPLAMI"], zaman); araFoy.MAHSUP_TOPLAMI = sonucMAHSUP_TOPLAMI.Para; araFoy.MAHSUP_TOPLAMI_DOVIZ_ID = sonucMAHSUP_TOPLAMI.DovizId;
            ParaVeDovizId sonucMASAYA_KATILMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["MASAYA_KATILMA_HARCI"], zaman); araFoy.MASAYA_KATILMA_HARCI = sonucMASAYA_KATILMA_HARCI.Para; araFoy.MASAYA_KATILMA_HARCI_DOVIZ_ID = sonucMASAYA_KATILMA_HARCI.DovizId;
            ParaVeDovizId sonucODEME_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["ODEME_TOPLAMI"], zaman); araFoy.ODEME_TOPLAMI = sonucODEME_TOPLAMI.Para; araFoy.ODEME_TOPLAMI_DOVIZ_ID = sonucODEME_TOPLAMI.DovizId;
            ParaVeDovizId sonucODENEN_TAHSIL_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["ODENEN_TAHSIL_HARCI"], zaman); araFoy.ODENEN_TAHSIL_HARCI = sonucODENEN_TAHSIL_HARCI.Para; araFoy.ODENEN_TAHSIL_HARCI_DOVIZ_ID = sonucODENEN_TAHSIL_HARCI.DovizId;
            ParaVeDovizId sonucPAYLASMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["PAYLASMA_HARCI"], zaman); araFoy.PAYLASMA_HARCI = sonucPAYLASMA_HARCI.Para; araFoy.PAYLASMA_HARCI_DOVIZ_ID = sonucPAYLASMA_HARCI.DovizId;
            ParaVeDovizId sonucPESIN_HARC = FaizHelper.ParalariTopla(paralarinSozlugu["PESIN_HARC"], zaman); araFoy.PESIN_HARC = sonucPESIN_HARC.Para; araFoy.PESIN_HARC_DOVIZ_ID = sonucPESIN_HARC.DovizId;
            ParaVeDovizId sonucPROTESTO_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["PROTESTO_GIDERI"], zaman); araFoy.PROTESTO_GIDERI = sonucPROTESTO_GIDERI.Para; araFoy.PROTESTO_GIDERI_DOVIZ_ID = sonucPROTESTO_GIDERI.DovizId;
            ParaVeDovizId sonucTAHLIYE_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["TAHLIYE_HARCI"], zaman); araFoy.TAHLIYE_HARCI = sonucTAHLIYE_HARCI.Para; araFoy.TAHLIYE_HARCI_DOVIZ_ID = sonucTAHLIYE_HARCI.DovizId;
            ParaVeDovizId sonucTAHLIYE_VEK_UCR = FaizHelper.ParalariTopla(paralarinSozlugu["TAHLIYE_VEK_UCR"], zaman); araFoy.TAHLIYE_VEK_UCR = sonucTAHLIYE_VEK_UCR.Para; araFoy.TAHLIYE_VEK_UCR_DOVIZ_ID = sonucTAHLIYE_VEK_UCR.DovizId;
            ParaVeDovizId sonucTAKIP_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["TAKIP_VEKALET_UCRETI"], zaman); araFoy.TAKIP_VEKALET_UCRETI = sonucTAKIP_VEKALET_UCRETI.Para; araFoy.TAKIP_VEKALET_UCRETI_DOVIZ_ID = sonucTAKIP_VEKALET_UCRETI.DovizId;
            ParaVeDovizId sonucTD_BAKIYE_HARC = FaizHelper.ParalariTopla(paralarinSozlugu["TD_BAKIYE_HARC"], zaman); araFoy.TD_BAKIYE_HARC = sonucTD_BAKIYE_HARC.Para; araFoy.TD_BAKIYE_HARC_DOVIZ_ID = sonucTD_BAKIYE_HARC.DovizId;
            ParaVeDovizId sonucTD_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["TD_GIDERI"], zaman); araFoy.TD_GIDERI = sonucTD_GIDERI.Para; araFoy.TD_GIDERI_DOVIZ_ID = sonucTD_GIDERI.DovizId;
            ParaVeDovizId sonucTD_TEBLIG_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["TD_TEBLIG_GIDERI"], zaman); araFoy.TD_TEBLIG_GIDERI = sonucTD_TEBLIG_GIDERI.Para; araFoy.TD_TEBLIG_GIDERI_DOVIZ_ID = sonucTD_TEBLIG_GIDERI.DovizId;
            ParaVeDovizId sonucTD_VEK_UCR = FaizHelper.ParalariTopla(paralarinSozlugu["TD_VEK_UCR"], zaman); araFoy.TD_VEK_UCR = sonucTD_VEK_UCR.Para; araFoy.TD_VEK_UCR_DOVIZ_ID = sonucTD_VEK_UCR.DovizId;
            ParaVeDovizId sonucTESLIM_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["TESLIM_HARCI"], zaman); araFoy.TESLIM_HARCI = sonucTESLIM_HARCI.Para; araFoy.TESLIM_HARCI_DOVIZ_ID = sonucTESLIM_HARCI.DovizId;
            ParaVeDovizId sonucTO_MASRAF_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_MASRAF_TOPLAMI"], zaman); araFoy.TO_MASRAF_TOPLAMI = sonucTO_MASRAF_TOPLAMI.Para; araFoy.TO_MASRAF_TOPLAMI_DOVIZ_ID = sonucTO_MASRAF_TOPLAMI.DovizId;
            ParaVeDovizId sonucTO_ODEME_MAHSUP_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_ODEME_MAHSUP_TOPLAMI"], zaman); araFoy.TO_ODEME_MAHSUP_TOPLAMI = sonucTO_ODEME_MAHSUP_TOPLAMI.Para; araFoy.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = sonucTO_ODEME_MAHSUP_TOPLAMI.DovizId;
            ParaVeDovizId sonucTO_ODEME_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_ODEME_TOPLAMI"], zaman); araFoy.TO_ODEME_TOPLAMI = sonucTO_ODEME_TOPLAMI.Para; araFoy.TO_ODEME_TOPLAMI_DOVIZ_ID = sonucTO_ODEME_TOPLAMI.DovizId;
            ParaVeDovizId sonucTO_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_VEKALET_TOPLAMI"], zaman); araFoy.TO_VEKALET_TOPLAMI = sonucTO_VEKALET_TOPLAMI.Para; araFoy.TO_VEKALET_TOPLAMI_DOVIZ_ID = sonucTO_VEKALET_TOPLAMI.DovizId;
            ParaVeDovizId sonucTO_YONETIMG_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_YONETIMG_TAZMINATI"], zaman); araFoy.TO_YONETIMG_TAZMINATI = sonucTO_YONETIMG_TAZMINATI.Para; araFoy.TO_YONETIMG_TAZMINATI_DOVIZ_ID = sonucTO_YONETIMG_TAZMINATI.DovizId;
            ParaVeDovizId sonucTS_MASRAF_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TS_MASRAF_TOPLAMI"], zaman); araFoy.TS_MASRAF_TOPLAMI = sonucTS_MASRAF_TOPLAMI.Para; araFoy.TS_MASRAF_TOPLAMI_DOVIZ_ID = sonucTS_MASRAF_TOPLAMI.DovizId;
            ParaVeDovizId sonucTS_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TS_VEKALET_TOPLAMI"], zaman); araFoy.TS_VEKALET_TOPLAMI = sonucTS_VEKALET_TOPLAMI.Para; araFoy.TS_VEKALET_TOPLAMI_DOVIZ_ID = sonucTS_VEKALET_TOPLAMI.DovizId;
            ParaVeDovizId sonucTUM_MASRAF_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TUM_MASRAF_TOPLAMI"], zaman); araFoy.TUM_MASRAF_TOPLAMI = sonucTUM_MASRAF_TOPLAMI.Para; araFoy.TUM_MASRAF_TOPLAMI_DOVIZ_ID = sonucTUM_MASRAF_TOPLAMI.DovizId;
            ParaVeDovizId sonucTUM_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TUM_VEKALET_TOPLAMI"], zaman); araFoy.TUM_VEKALET_TOPLAMI = sonucTUM_VEKALET_TOPLAMI.Para; araFoy.TUM_VEKALET_TOPLAMI_DOVIZ_ID = sonucTUM_VEKALET_TOPLAMI.DovizId;
            ParaVeDovizId sonucVEKALET_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["VEKALET_HARCI"], zaman); araFoy.VEKALET_HARCI = sonucVEKALET_HARCI.Para; araFoy.VEKALET_HARCI_DOVIZ_ID = sonucVEKALET_HARCI.DovizId;
            ParaVeDovizId sonucVEKALET_PULU = FaizHelper.ParalariTopla(paralarinSozlugu["VEKALET_PULU"], zaman); araFoy.VEKALET_PULU = sonucVEKALET_PULU.Para; araFoy.VEKALET_PULU_DOVIZ_ID = sonucVEKALET_PULU.DovizId;

            #endregion Ara Föye Değerler Atanıyor

            foreach (KeyValuePair<string, List<ParaVeDovizId>> teki in paralarinSozlugu)
            {
                teki.Value.Clear();
            }

            #region İlgili Alanlara Değerler Ekleniyor

            paralarinSozlugu["BASVURMA_HARCI"].Add(new ParaVeDovizId(asilFoy.BASVURMA_HARCI, asilFoy.BASVURMA_HARCI_DOVIZ_ID));
            paralarinSozlugu["BIRIKMIS_NAFAKA"].Add(new ParaVeDovizId(asilFoy.BIRIKMIS_NAFAKA, asilFoy.BIRIKMIS_NAFAKA_DOVIZ_ID));
            paralarinSozlugu["CEK_KOMISYONU"].Add(new ParaVeDovizId(asilFoy.CEK_KOMISYONU, asilFoy.CEK_KOMISYONU_DOVIZ_ID));
            paralarinSozlugu["DAMGA_PULU"].Add(new ParaVeDovizId(asilFoy.DAMGA_PULU, asilFoy.DAMGA_PULU_DOVIZ_ID));
            paralarinSozlugu["DAVA_GIDERLERI"].Add(new ParaVeDovizId(asilFoy.DAVA_GIDERLERI, asilFoy.DAVA_GIDERLERI_DOVIZ_ID));
            paralarinSozlugu["DAVA_INKAR_TAZMINATI"].Add(new ParaVeDovizId(asilFoy.DAVA_INKAR_TAZMINATI, asilFoy.DAVA_INKAR_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["DAVA_VEKALET_UCRETI"].Add(new ParaVeDovizId(asilFoy.DAVA_VEKALET_UCRETI, asilFoy.DAVA_VEKALET_UCRETI_DOVIZ_ID));
            paralarinSozlugu["DIGER_GIDERLER"].Add(new ParaVeDovizId(asilFoy.DIGER_GIDERLER, asilFoy.DIGER_GIDERLER_DOVIZ_ID));
            paralarinSozlugu["DIGER_HARC"].Add(new ParaVeDovizId(asilFoy.DIGER_HARC, asilFoy.DIGER_HARC_DOVIZ_ID));
            paralarinSozlugu["FERAGAT_HARCI"].Add(new ParaVeDovizId(asilFoy.FERAGAT_HARCI, asilFoy.FERAGAT_HARCI_DOVIZ_ID));
            paralarinSozlugu["FERAGAT_TOPLAMI"].Add(new ParaVeDovizId(asilFoy.FERAGAT_TOPLAMI, asilFoy.FERAGAT_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["HARC_TOPLAMI"].Add(new ParaVeDovizId(asilFoy.HARC_TOPLAMI, asilFoy.HARC_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["ICRA_INKAR_TAZMINATI"].Add(new ParaVeDovizId(asilFoy.ICRA_INKAR_TAZMINATI, asilFoy.ICRA_INKAR_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["IFLAS_BASVURMA_HARCI"].Add(new ParaVeDovizId(asilFoy.IFLAS_BASVURMA_HARCI, asilFoy.IFLAS_BASVURMA_HARCI_DOVIZ_ID));
            paralarinSozlugu["IFLASIN_ACILMASI_HARCI"].Add(new ParaVeDovizId(asilFoy.IFLASIN_ACILMASI_HARCI, asilFoy.IFLASIN_ACILMASI_HARCI_DOVIZ_ID));
            paralarinSozlugu["IH_VEKALET_UCRETI"].Add(new ParaVeDovizId(asilFoy.IH_VEKALET_UCRETI, asilFoy.IH_VEKALET_UCRETI_DOVIZ_ID));
            paralarinSozlugu["IHTAR_GIDERI"].Add(new ParaVeDovizId(asilFoy.IHTAR_GIDERI, asilFoy.IHTAR_GIDERI_DOVIZ_ID));
            paralarinSozlugu["ILAM_BK_YARG_ONAMA"].Add(new ParaVeDovizId(asilFoy.ILAM_BK_YARG_ONAMA, asilFoy.ILAM_BK_YARG_ONAMA_DOVIZ_ID));
            paralarinSozlugu["ILAM_INKAR_TAZMINATI"].Add(new ParaVeDovizId(asilFoy.ILAM_INKAR_TAZMINATI, asilFoy.ILAM_INKAR_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["ILAM_TEBLIG_GIDERI"].Add(new ParaVeDovizId(asilFoy.ILAM_TEBLIG_GIDERI, asilFoy.ILAM_TEBLIG_GIDERI_DOVIZ_ID));
            paralarinSozlugu["ILAM_UCRETLER_TOPLAMI"].Add(new ParaVeDovizId(asilFoy.ILAM_UCRETLER_TOPLAMI, asilFoy.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["ILAM_VEK_UCR"].Add(new ParaVeDovizId(asilFoy.ILAM_VEK_UCR, asilFoy.ILAM_VEK_UCR_DOVIZ_ID));
            paralarinSozlugu["ILAM_YARGILAMA_GIDERI"].Add(new ParaVeDovizId(asilFoy.ILAM_YARGILAMA_GIDERI, asilFoy.ILAM_YARGILAMA_GIDERI_DOVIZ_ID));
            paralarinSozlugu["ILK_GIDERLER"].Add(new ParaVeDovizId(asilFoy.ILK_GIDERLER, asilFoy.ILK_GIDERLER_DOVIZ_ID));
            paralarinSozlugu["ILK_TEBLIGAT_GIDERI"].Add(new ParaVeDovizId(asilFoy.ILK_TEBLIGAT_GIDERI, asilFoy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID));
            paralarinSozlugu["IT_GIDERI"].Add(new ParaVeDovizId(asilFoy.IT_GIDERI, asilFoy.IT_GIDERI_DOVIZ_ID));
            paralarinSozlugu["IT_HACIZDE_ODENEN"].Add(new ParaVeDovizId(asilFoy.IT_HACIZDE_ODENEN, asilFoy.IT_HACIZDE_ODENEN_DOVIZ_ID));
            paralarinSozlugu["IT_VEKALET_UCRETI"].Add(new ParaVeDovizId(asilFoy.IT_VEKALET_UCRETI, asilFoy.IT_VEKALET_UCRETI_DOVIZ_ID));
            paralarinSozlugu["KALAN"].Add(new ParaVeDovizId(asilFoy.KALAN, asilFoy.KALAN_DOVIZ_ID));
            paralarinSozlugu["KARSI_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(asilFoy.KARSI_VEKALET_TOPLAMI, asilFoy.KARSI_VEKALET_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["KARSILIK_TUTARI"].Add(new ParaVeDovizId(asilFoy.KARSILIK_TUTARI, asilFoy.KARSILIK_TUTARI_DOVIZ_ID));
            paralarinSozlugu["KARSILIKSIZ_CEK_TAZMINATI"].Add(new ParaVeDovizId(asilFoy.KARSILIKSIZ_CEK_TAZMINATI, asilFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["MAHSUP_TOPLAMI"].Add(new ParaVeDovizId(asilFoy.MAHSUP_TOPLAMI, asilFoy.MAHSUP_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["MASAYA_KATILMA_HARCI"].Add(new ParaVeDovizId(asilFoy.MASAYA_KATILMA_HARCI, asilFoy.MASAYA_KATILMA_HARCI_DOVIZ_ID));
            paralarinSozlugu["ODEME_TOPLAMI"].Add(new ParaVeDovizId(asilFoy.ODEME_TOPLAMI, asilFoy.ODEME_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["ODENEN_TAHSIL_HARCI"].Add(new ParaVeDovizId(asilFoy.ODENEN_TAHSIL_HARCI, asilFoy.ODENEN_TAHSIL_HARCI_DOVIZ_ID));
            paralarinSozlugu["PAYLASMA_HARCI"].Add(new ParaVeDovizId(asilFoy.PAYLASMA_HARCI, asilFoy.PAYLASMA_HARCI_DOVIZ_ID));
            paralarinSozlugu["PESIN_HARC"].Add(new ParaVeDovizId(asilFoy.PESIN_HARC, asilFoy.PESIN_HARC_DOVIZ_ID));
            paralarinSozlugu["PROTESTO_GIDERI"].Add(new ParaVeDovizId(asilFoy.PROTESTO_GIDERI, asilFoy.PROTESTO_GIDERI_DOVIZ_ID));
            paralarinSozlugu["TAHLIYE_HARCI"].Add(new ParaVeDovizId(asilFoy.TAHLIYE_HARCI, asilFoy.TAHLIYE_HARCI_DOVIZ_ID));
            paralarinSozlugu["TAHLIYE_VEK_UCR"].Add(new ParaVeDovizId(asilFoy.TAHLIYE_VEK_UCR, asilFoy.TAHLIYE_VEK_UCR_DOVIZ_ID));
            paralarinSozlugu["TAKIP_VEKALET_UCRETI"].Add(new ParaVeDovizId(asilFoy.TAKIP_VEKALET_UCRETI, asilFoy.TAKIP_VEKALET_UCRETI_DOVIZ_ID));
            paralarinSozlugu["TD_BAKIYE_HARC"].Add(new ParaVeDovizId(asilFoy.TD_BAKIYE_HARC, asilFoy.TD_BAKIYE_HARC_DOVIZ_ID));
            paralarinSozlugu["TD_GIDERI"].Add(new ParaVeDovizId(asilFoy.TD_GIDERI, asilFoy.TD_GIDERI_DOVIZ_ID));
            paralarinSozlugu["TD_TEBLIG_GIDERI"].Add(new ParaVeDovizId(asilFoy.TD_TEBLIG_GIDERI, asilFoy.TD_TEBLIG_GIDERI_DOVIZ_ID));
            paralarinSozlugu["TD_VEK_UCR"].Add(new ParaVeDovizId(asilFoy.TD_VEK_UCR, asilFoy.TD_VEK_UCR_DOVIZ_ID));
            paralarinSozlugu["TESLIM_HARCI"].Add(new ParaVeDovizId(asilFoy.TESLIM_HARCI, asilFoy.TESLIM_HARCI_DOVIZ_ID));
            paralarinSozlugu["TO_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(asilFoy.TO_MASRAF_TOPLAMI, asilFoy.TO_MASRAF_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TO_ODEME_MAHSUP_TOPLAMI"].Add(new ParaVeDovizId(asilFoy.TO_ODEME_MAHSUP_TOPLAMI, asilFoy.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TO_ODEME_TOPLAMI"].Add(new ParaVeDovizId(asilFoy.TO_ODEME_TOPLAMI, asilFoy.TO_ODEME_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TO_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(asilFoy.TO_VEKALET_TOPLAMI, asilFoy.TO_VEKALET_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TO_YONETIMG_TAZMINATI"].Add(new ParaVeDovizId(asilFoy.TO_YONETIMG_TAZMINATI, asilFoy.TO_YONETIMG_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["TS_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(asilFoy.TS_MASRAF_TOPLAMI, asilFoy.TS_MASRAF_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TS_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(asilFoy.TS_VEKALET_TOPLAMI, asilFoy.TS_VEKALET_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TUM_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(asilFoy.TUM_MASRAF_TOPLAMI, asilFoy.TUM_MASRAF_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TUM_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(asilFoy.TUM_VEKALET_TOPLAMI, asilFoy.TUM_VEKALET_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["VEKALET_HARCI"].Add(new ParaVeDovizId(asilFoy.VEKALET_HARCI, asilFoy.VEKALET_HARCI_DOVIZ_ID));
            paralarinSozlugu["VEKALET_PULU"].Add(new ParaVeDovizId(asilFoy.VEKALET_PULU, asilFoy.VEKALET_PULU_DOVIZ_ID));

            #endregion İlgili Alanlara Değerler Ekleniyor

            #region İlgili Alanlara Değerler Ekleniyor

            paralarinSozlugu["BASVURMA_HARCI"].Add(new ParaVeDovizId(araFoy.BASVURMA_HARCI, araFoy.BASVURMA_HARCI_DOVIZ_ID));
            paralarinSozlugu["BIRIKMIS_NAFAKA"].Add(new ParaVeDovizId(araFoy.BIRIKMIS_NAFAKA, araFoy.BIRIKMIS_NAFAKA_DOVIZ_ID));
            paralarinSozlugu["CEK_KOMISYONU"].Add(new ParaVeDovizId(araFoy.CEK_KOMISYONU, araFoy.CEK_KOMISYONU_DOVIZ_ID));
            paralarinSozlugu["DAMGA_PULU"].Add(new ParaVeDovizId(araFoy.DAMGA_PULU, araFoy.DAMGA_PULU_DOVIZ_ID));
            paralarinSozlugu["DAVA_GIDERLERI"].Add(new ParaVeDovizId(araFoy.DAVA_GIDERLERI, araFoy.DAVA_GIDERLERI_DOVIZ_ID));
            paralarinSozlugu["DAVA_INKAR_TAZMINATI"].Add(new ParaVeDovizId(araFoy.DAVA_INKAR_TAZMINATI, araFoy.DAVA_INKAR_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["DAVA_VEKALET_UCRETI"].Add(new ParaVeDovizId(araFoy.DAVA_VEKALET_UCRETI, araFoy.DAVA_VEKALET_UCRETI_DOVIZ_ID));
            paralarinSozlugu["DIGER_GIDERLER"].Add(new ParaVeDovizId(araFoy.DIGER_GIDERLER, araFoy.DIGER_GIDERLER_DOVIZ_ID));
            paralarinSozlugu["DIGER_HARC"].Add(new ParaVeDovizId(araFoy.DIGER_HARC, araFoy.DIGER_HARC_DOVIZ_ID));
            paralarinSozlugu["FERAGAT_HARCI"].Add(new ParaVeDovizId(araFoy.FERAGAT_HARCI, araFoy.FERAGAT_HARCI_DOVIZ_ID));
            paralarinSozlugu["FERAGAT_TOPLAMI"].Add(new ParaVeDovizId(araFoy.FERAGAT_TOPLAMI, araFoy.FERAGAT_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["HARC_TOPLAMI"].Add(new ParaVeDovizId(araFoy.HARC_TOPLAMI, araFoy.HARC_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["ICRA_INKAR_TAZMINATI"].Add(new ParaVeDovizId(araFoy.ICRA_INKAR_TAZMINATI, araFoy.ICRA_INKAR_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["IFLAS_BASVURMA_HARCI"].Add(new ParaVeDovizId(araFoy.IFLAS_BASVURMA_HARCI, araFoy.IFLAS_BASVURMA_HARCI_DOVIZ_ID));
            paralarinSozlugu["IFLASIN_ACILMASI_HARCI"].Add(new ParaVeDovizId(araFoy.IFLASIN_ACILMASI_HARCI, araFoy.IFLASIN_ACILMASI_HARCI_DOVIZ_ID));
            paralarinSozlugu["IH_VEKALET_UCRETI"].Add(new ParaVeDovizId(araFoy.IH_VEKALET_UCRETI, araFoy.IH_VEKALET_UCRETI_DOVIZ_ID));
            paralarinSozlugu["IHTAR_GIDERI"].Add(new ParaVeDovizId(araFoy.IHTAR_GIDERI, araFoy.IHTAR_GIDERI_DOVIZ_ID));
            paralarinSozlugu["ILAM_BK_YARG_ONAMA"].Add(new ParaVeDovizId(araFoy.ILAM_BK_YARG_ONAMA, araFoy.ILAM_BK_YARG_ONAMA_DOVIZ_ID));
            paralarinSozlugu["ILAM_INKAR_TAZMINATI"].Add(new ParaVeDovizId(araFoy.ILAM_INKAR_TAZMINATI, araFoy.ILAM_INKAR_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["ILAM_TEBLIG_GIDERI"].Add(new ParaVeDovizId(araFoy.ILAM_TEBLIG_GIDERI, araFoy.ILAM_TEBLIG_GIDERI_DOVIZ_ID));
            paralarinSozlugu["ILAM_UCRETLER_TOPLAMI"].Add(new ParaVeDovizId(araFoy.ILAM_UCRETLER_TOPLAMI, araFoy.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["ILAM_VEK_UCR"].Add(new ParaVeDovizId(araFoy.ILAM_VEK_UCR, araFoy.ILAM_VEK_UCR_DOVIZ_ID));
            paralarinSozlugu["ILAM_YARGILAMA_GIDERI"].Add(new ParaVeDovizId(araFoy.ILAM_YARGILAMA_GIDERI, araFoy.ILAM_YARGILAMA_GIDERI_DOVIZ_ID));
            paralarinSozlugu["ILK_GIDERLER"].Add(new ParaVeDovizId(araFoy.ILK_GIDERLER, araFoy.ILK_GIDERLER_DOVIZ_ID));
            paralarinSozlugu["ILK_TEBLIGAT_GIDERI"].Add(new ParaVeDovizId(araFoy.ILK_TEBLIGAT_GIDERI, araFoy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID));
            paralarinSozlugu["IT_GIDERI"].Add(new ParaVeDovizId(araFoy.IT_GIDERI, araFoy.IT_GIDERI_DOVIZ_ID));
            paralarinSozlugu["IT_HACIZDE_ODENEN"].Add(new ParaVeDovizId(araFoy.IT_HACIZDE_ODENEN, araFoy.IT_HACIZDE_ODENEN_DOVIZ_ID));
            paralarinSozlugu["IT_VEKALET_UCRETI"].Add(new ParaVeDovizId(araFoy.IT_VEKALET_UCRETI, araFoy.IT_VEKALET_UCRETI_DOVIZ_ID));
            paralarinSozlugu["KALAN"].Add(new ParaVeDovizId(araFoy.KALAN, araFoy.KALAN_DOVIZ_ID));
            paralarinSozlugu["KARSI_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(araFoy.KARSI_VEKALET_TOPLAMI, araFoy.KARSI_VEKALET_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["KARSILIK_TUTARI"].Add(new ParaVeDovizId(araFoy.KARSILIK_TUTARI, araFoy.KARSILIK_TUTARI_DOVIZ_ID));
            paralarinSozlugu["KARSILIKSIZ_CEK_TAZMINATI"].Add(new ParaVeDovizId(araFoy.KARSILIKSIZ_CEK_TAZMINATI, araFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["MAHSUP_TOPLAMI"].Add(new ParaVeDovizId(araFoy.MAHSUP_TOPLAMI, araFoy.MAHSUP_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["MASAYA_KATILMA_HARCI"].Add(new ParaVeDovizId(araFoy.MASAYA_KATILMA_HARCI, araFoy.MASAYA_KATILMA_HARCI_DOVIZ_ID));
            paralarinSozlugu["ODEME_TOPLAMI"].Add(new ParaVeDovizId(araFoy.ODEME_TOPLAMI, araFoy.ODEME_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["ODENEN_TAHSIL_HARCI"].Add(new ParaVeDovizId(araFoy.ODENEN_TAHSIL_HARCI, araFoy.ODENEN_TAHSIL_HARCI_DOVIZ_ID));
            paralarinSozlugu["PAYLASMA_HARCI"].Add(new ParaVeDovizId(araFoy.PAYLASMA_HARCI, araFoy.PAYLASMA_HARCI_DOVIZ_ID));
            paralarinSozlugu["PESIN_HARC"].Add(new ParaVeDovizId(araFoy.PESIN_HARC, araFoy.PESIN_HARC_DOVIZ_ID));
            paralarinSozlugu["PROTESTO_GIDERI"].Add(new ParaVeDovizId(araFoy.PROTESTO_GIDERI, araFoy.PROTESTO_GIDERI_DOVIZ_ID));
            paralarinSozlugu["TAHLIYE_HARCI"].Add(new ParaVeDovizId(araFoy.TAHLIYE_HARCI, araFoy.TAHLIYE_HARCI_DOVIZ_ID));
            paralarinSozlugu["TAHLIYE_VEK_UCR"].Add(new ParaVeDovizId(araFoy.TAHLIYE_VEK_UCR, araFoy.TAHLIYE_VEK_UCR_DOVIZ_ID));
            paralarinSozlugu["TAKIP_VEKALET_UCRETI"].Add(new ParaVeDovizId(araFoy.TAKIP_VEKALET_UCRETI, araFoy.TAKIP_VEKALET_UCRETI_DOVIZ_ID));
            paralarinSozlugu["TD_BAKIYE_HARC"].Add(new ParaVeDovizId(araFoy.TD_BAKIYE_HARC, araFoy.TD_BAKIYE_HARC_DOVIZ_ID));
            paralarinSozlugu["TD_GIDERI"].Add(new ParaVeDovizId(araFoy.TD_GIDERI, araFoy.TD_GIDERI_DOVIZ_ID));
            paralarinSozlugu["TD_TEBLIG_GIDERI"].Add(new ParaVeDovizId(araFoy.TD_TEBLIG_GIDERI, araFoy.TD_TEBLIG_GIDERI_DOVIZ_ID));
            paralarinSozlugu["TD_VEK_UCR"].Add(new ParaVeDovizId(araFoy.TD_VEK_UCR, araFoy.TD_VEK_UCR_DOVIZ_ID));
            paralarinSozlugu["TESLIM_HARCI"].Add(new ParaVeDovizId(araFoy.TESLIM_HARCI, araFoy.TESLIM_HARCI_DOVIZ_ID));
            paralarinSozlugu["TO_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(araFoy.TO_MASRAF_TOPLAMI, araFoy.TO_MASRAF_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TO_ODEME_MAHSUP_TOPLAMI"].Add(new ParaVeDovizId(araFoy.TO_ODEME_MAHSUP_TOPLAMI, araFoy.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TO_ODEME_TOPLAMI"].Add(new ParaVeDovizId(araFoy.TO_ODEME_TOPLAMI, araFoy.TO_ODEME_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TO_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(araFoy.TO_VEKALET_TOPLAMI, araFoy.TO_VEKALET_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TO_YONETIMG_TAZMINATI"].Add(new ParaVeDovizId(araFoy.TO_YONETIMG_TAZMINATI, araFoy.TO_YONETIMG_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["TS_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(araFoy.TS_MASRAF_TOPLAMI, araFoy.TS_MASRAF_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TS_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(araFoy.TS_VEKALET_TOPLAMI, araFoy.TS_VEKALET_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TUM_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(araFoy.TUM_MASRAF_TOPLAMI, araFoy.TUM_MASRAF_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TUM_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(araFoy.TUM_VEKALET_TOPLAMI, araFoy.TUM_VEKALET_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["VEKALET_HARCI"].Add(new ParaVeDovizId(araFoy.VEKALET_HARCI, araFoy.VEKALET_HARCI_DOVIZ_ID));
            paralarinSozlugu["VEKALET_PULU"].Add(new ParaVeDovizId(araFoy.VEKALET_PULU, araFoy.VEKALET_PULU_DOVIZ_ID));

            #endregion İlgili Alanlara Değerler Ekleniyor

            #region Toplam Sonuçu Oluşturuluyor

            sonucBASVURMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["BASVURMA_HARCI"], zaman); asilFoy.BASVURMA_HARCI = sonucBASVURMA_HARCI.Para; asilFoy.BASVURMA_HARCI_DOVIZ_ID = sonucBASVURMA_HARCI.DovizId;
            sonucBIRIKMIS_NAFAKA = FaizHelper.ParalariTopla(paralarinSozlugu["BIRIKMIS_NAFAKA"], zaman); asilFoy.BIRIKMIS_NAFAKA = sonucBIRIKMIS_NAFAKA.Para; asilFoy.BIRIKMIS_NAFAKA_DOVIZ_ID = sonucBIRIKMIS_NAFAKA.DovizId;
            sonucCEK_KOMISYONU = FaizHelper.ParalariTopla(paralarinSozlugu["CEK_KOMISYONU"], zaman); asilFoy.CEK_KOMISYONU = sonucCEK_KOMISYONU.Para; asilFoy.CEK_KOMISYONU_DOVIZ_ID = sonucCEK_KOMISYONU.DovizId;
            sonucDAMGA_PULU = FaizHelper.ParalariTopla(paralarinSozlugu["DAMGA_PULU"], zaman); asilFoy.DAMGA_PULU = sonucDAMGA_PULU.Para; asilFoy.DAMGA_PULU_DOVIZ_ID = sonucDAMGA_PULU.DovizId;
            sonucDAVA_GIDERLERI = FaizHelper.ParalariTopla(paralarinSozlugu["DAVA_GIDERLERI"], zaman); asilFoy.DAVA_GIDERLERI = sonucDAVA_GIDERLERI.Para; asilFoy.DAVA_GIDERLERI_DOVIZ_ID = sonucDAVA_GIDERLERI.DovizId;
            sonucDAVA_INKAR_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["DAVA_INKAR_TAZMINATI"], zaman); asilFoy.DAVA_INKAR_TAZMINATI = sonucDAVA_INKAR_TAZMINATI.Para; asilFoy.DAVA_INKAR_TAZMINATI_DOVIZ_ID = sonucDAVA_INKAR_TAZMINATI.DovizId;
            sonucDAVA_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["DAVA_VEKALET_UCRETI"], zaman); asilFoy.DAVA_VEKALET_UCRETI = sonucDAVA_VEKALET_UCRETI.Para; asilFoy.DAVA_VEKALET_UCRETI_DOVIZ_ID = sonucDAVA_VEKALET_UCRETI.DovizId;
            sonucDIGER_GIDERLER = FaizHelper.ParalariTopla(paralarinSozlugu["DIGER_GIDERLER"], zaman); asilFoy.DIGER_GIDERLER = sonucDIGER_GIDERLER.Para; asilFoy.DIGER_GIDERLER_DOVIZ_ID = sonucDIGER_GIDERLER.DovizId;
            sonucDIGER_HARC = FaizHelper.ParalariTopla(paralarinSozlugu["DIGER_HARC"], zaman); asilFoy.DIGER_HARC = sonucDIGER_HARC.Para; asilFoy.DIGER_HARC_DOVIZ_ID = sonucDIGER_HARC.DovizId;
            sonucFERAGAT_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["FERAGAT_HARCI"], zaman); asilFoy.FERAGAT_HARCI = sonucFERAGAT_HARCI.Para; asilFoy.FERAGAT_HARCI_DOVIZ_ID = sonucFERAGAT_HARCI.DovizId;
            sonucFERAGAT_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["FERAGAT_TOPLAMI"], zaman); asilFoy.FERAGAT_TOPLAMI = sonucFERAGAT_TOPLAMI.Para; asilFoy.FERAGAT_TOPLAMI_DOVIZ_ID = sonucFERAGAT_TOPLAMI.DovizId;
            sonucHARC_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["HARC_TOPLAMI"], zaman); asilFoy.HARC_TOPLAMI = sonucHARC_TOPLAMI.Para; asilFoy.HARC_TOPLAMI_DOVIZ_ID = sonucHARC_TOPLAMI.DovizId;
            sonucICRA_INKAR_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["ICRA_INKAR_TAZMINATI"], zaman); asilFoy.ICRA_INKAR_TAZMINATI = sonucICRA_INKAR_TAZMINATI.Para; asilFoy.ICRA_INKAR_TAZMINATI_DOVIZ_ID = sonucICRA_INKAR_TAZMINATI.DovizId;
            sonucIFLAS_BASVURMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["IFLAS_BASVURMA_HARCI"], zaman); asilFoy.IFLAS_BASVURMA_HARCI = sonucIFLAS_BASVURMA_HARCI.Para; asilFoy.IFLAS_BASVURMA_HARCI_DOVIZ_ID = sonucIFLAS_BASVURMA_HARCI.DovizId;
            sonucIFLASIN_ACILMASI_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["IFLASIN_ACILMASI_HARCI"], zaman); asilFoy.IFLASIN_ACILMASI_HARCI = sonucIFLASIN_ACILMASI_HARCI.Para; asilFoy.IFLASIN_ACILMASI_HARCI_DOVIZ_ID = sonucIFLASIN_ACILMASI_HARCI.DovizId;
            sonucIH_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["IH_VEKALET_UCRETI"], zaman); asilFoy.IH_VEKALET_UCRETI = sonucIH_VEKALET_UCRETI.Para; asilFoy.IH_VEKALET_UCRETI_DOVIZ_ID = sonucIH_VEKALET_UCRETI.DovizId;
            sonucIHTAR_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["IHTAR_GIDERI"], zaman); asilFoy.IHTAR_GIDERI = sonucIHTAR_GIDERI.Para; asilFoy.IHTAR_GIDERI_DOVIZ_ID = sonucIHTAR_GIDERI.DovizId;
            sonucILAM_BK_YARG_ONAMA = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_BK_YARG_ONAMA"], zaman); asilFoy.ILAM_BK_YARG_ONAMA = sonucILAM_BK_YARG_ONAMA.Para; asilFoy.ILAM_BK_YARG_ONAMA_DOVIZ_ID = sonucILAM_BK_YARG_ONAMA.DovizId;
            sonucILAM_INKAR_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_INKAR_TAZMINATI"], zaman); asilFoy.ILAM_INKAR_TAZMINATI = sonucILAM_INKAR_TAZMINATI.Para; asilFoy.ILAM_INKAR_TAZMINATI_DOVIZ_ID = sonucILAM_INKAR_TAZMINATI.DovizId;
            sonucILAM_TEBLIG_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_TEBLIG_GIDERI"], zaman); asilFoy.ILAM_TEBLIG_GIDERI = sonucILAM_TEBLIG_GIDERI.Para; asilFoy.ILAM_TEBLIG_GIDERI_DOVIZ_ID = sonucILAM_TEBLIG_GIDERI.DovizId;
            sonucILAM_UCRETLER_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_UCRETLER_TOPLAMI"], zaman); asilFoy.ILAM_UCRETLER_TOPLAMI = sonucILAM_UCRETLER_TOPLAMI.Para; asilFoy.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID = sonucILAM_UCRETLER_TOPLAMI.DovizId;
            sonucILAM_VEK_UCR = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_VEK_UCR"], zaman); asilFoy.ILAM_VEK_UCR = sonucILAM_VEK_UCR.Para; asilFoy.ILAM_VEK_UCR_DOVIZ_ID = sonucILAM_VEK_UCR.DovizId;
            sonucILAM_YARGILAMA_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_YARGILAMA_GIDERI"], zaman); asilFoy.ILAM_YARGILAMA_GIDERI = sonucILAM_YARGILAMA_GIDERI.Para; asilFoy.ILAM_YARGILAMA_GIDERI_DOVIZ_ID = sonucILAM_YARGILAMA_GIDERI.DovizId;
            sonucILK_GIDERLER = FaizHelper.ParalariTopla(paralarinSozlugu["ILK_GIDERLER"], zaman); asilFoy.ILK_GIDERLER = sonucILK_GIDERLER.Para; asilFoy.ILK_GIDERLER_DOVIZ_ID = sonucILK_GIDERLER.DovizId;
            sonucILK_TEBLIGAT_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["ILK_TEBLIGAT_GIDERI"], zaman); asilFoy.ILK_TEBLIGAT_GIDERI = sonucILK_TEBLIGAT_GIDERI.Para; asilFoy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID = sonucILK_TEBLIGAT_GIDERI.DovizId;
            sonucIT_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["IT_GIDERI"], zaman); asilFoy.IT_GIDERI = sonucIT_GIDERI.Para; asilFoy.IT_GIDERI_DOVIZ_ID = sonucIT_GIDERI.DovizId;
            sonucIT_HACIZDE_ODENEN = FaizHelper.ParalariTopla(paralarinSozlugu["IT_HACIZDE_ODENEN"], zaman); asilFoy.IT_HACIZDE_ODENEN = sonucIT_HACIZDE_ODENEN.Para; asilFoy.IT_HACIZDE_ODENEN_DOVIZ_ID = sonucIT_HACIZDE_ODENEN.DovizId;
            sonucIT_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["IT_VEKALET_UCRETI"], zaman); asilFoy.IT_VEKALET_UCRETI = sonucIT_VEKALET_UCRETI.Para; asilFoy.IT_VEKALET_UCRETI_DOVIZ_ID = sonucIT_VEKALET_UCRETI.DovizId;
            sonucKALAN = FaizHelper.ParalariTopla(paralarinSozlugu["KALAN"], zaman); asilFoy.KALAN = sonucKALAN.Para; asilFoy.KALAN_DOVIZ_ID = sonucKALAN.DovizId;
            sonucKARSI_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["KARSI_VEKALET_TOPLAMI"], zaman); asilFoy.KARSI_VEKALET_TOPLAMI = sonucKARSI_VEKALET_TOPLAMI.Para; asilFoy.KARSI_VEKALET_TOPLAMI_DOVIZ_ID = sonucKARSI_VEKALET_TOPLAMI.DovizId;
            sonucKARSILIK_TUTARI = FaizHelper.ParalariTopla(paralarinSozlugu["KARSILIK_TUTARI"], zaman); asilFoy.KARSILIK_TUTARI = sonucKARSILIK_TUTARI.Para; asilFoy.KARSILIK_TUTARI_DOVIZ_ID = sonucKARSILIK_TUTARI.DovizId;
            sonucKARSILIKSIZ_CEK_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["KARSILIKSIZ_CEK_TAZMINATI"], zaman); asilFoy.KARSILIKSIZ_CEK_TAZMINATI = sonucKARSILIKSIZ_CEK_TAZMINATI.Para; asilFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = sonucKARSILIKSIZ_CEK_TAZMINATI.DovizId;
            sonucMAHSUP_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["MAHSUP_TOPLAMI"], zaman); asilFoy.MAHSUP_TOPLAMI = sonucMAHSUP_TOPLAMI.Para; asilFoy.MAHSUP_TOPLAMI_DOVIZ_ID = sonucMAHSUP_TOPLAMI.DovizId;
            sonucMASAYA_KATILMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["MASAYA_KATILMA_HARCI"], zaman); asilFoy.MASAYA_KATILMA_HARCI = sonucMASAYA_KATILMA_HARCI.Para; asilFoy.MASAYA_KATILMA_HARCI_DOVIZ_ID = sonucMASAYA_KATILMA_HARCI.DovizId;
            sonucODEME_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["ODEME_TOPLAMI"], zaman); asilFoy.ODEME_TOPLAMI = sonucODEME_TOPLAMI.Para; asilFoy.ODEME_TOPLAMI_DOVIZ_ID = sonucODEME_TOPLAMI.DovizId;
            sonucODENEN_TAHSIL_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["ODENEN_TAHSIL_HARCI"], zaman); asilFoy.ODENEN_TAHSIL_HARCI = sonucODENEN_TAHSIL_HARCI.Para; asilFoy.ODENEN_TAHSIL_HARCI_DOVIZ_ID = sonucODENEN_TAHSIL_HARCI.DovizId;
            sonucPAYLASMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["PAYLASMA_HARCI"], zaman); asilFoy.PAYLASMA_HARCI = sonucPAYLASMA_HARCI.Para; asilFoy.PAYLASMA_HARCI_DOVIZ_ID = sonucPAYLASMA_HARCI.DovizId;
            sonucPESIN_HARC = FaizHelper.ParalariTopla(paralarinSozlugu["PESIN_HARC"], zaman); asilFoy.PESIN_HARC = sonucPESIN_HARC.Para; asilFoy.PESIN_HARC_DOVIZ_ID = sonucPESIN_HARC.DovizId;
            sonucPROTESTO_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["PROTESTO_GIDERI"], zaman); asilFoy.PROTESTO_GIDERI = sonucPROTESTO_GIDERI.Para; asilFoy.PROTESTO_GIDERI_DOVIZ_ID = sonucPROTESTO_GIDERI.DovizId;
            sonucTAHLIYE_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["TAHLIYE_HARCI"], zaman); asilFoy.TAHLIYE_HARCI = sonucTAHLIYE_HARCI.Para; asilFoy.TAHLIYE_HARCI_DOVIZ_ID = sonucTAHLIYE_HARCI.DovizId;
            sonucTAHLIYE_VEK_UCR = FaizHelper.ParalariTopla(paralarinSozlugu["TAHLIYE_VEK_UCR"], zaman); asilFoy.TAHLIYE_VEK_UCR = sonucTAHLIYE_VEK_UCR.Para; asilFoy.TAHLIYE_VEK_UCR_DOVIZ_ID = sonucTAHLIYE_VEK_UCR.DovizId;
            sonucTAKIP_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["TAKIP_VEKALET_UCRETI"], zaman); asilFoy.TAKIP_VEKALET_UCRETI = sonucTAKIP_VEKALET_UCRETI.Para; asilFoy.TAKIP_VEKALET_UCRETI_DOVIZ_ID = sonucTAKIP_VEKALET_UCRETI.DovizId;
            sonucTD_BAKIYE_HARC = FaizHelper.ParalariTopla(paralarinSozlugu["TD_BAKIYE_HARC"], zaman); asilFoy.TD_BAKIYE_HARC = sonucTD_BAKIYE_HARC.Para; asilFoy.TD_BAKIYE_HARC_DOVIZ_ID = sonucTD_BAKIYE_HARC.DovizId;
            sonucTD_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["TD_GIDERI"], zaman); asilFoy.TD_GIDERI = sonucTD_GIDERI.Para; asilFoy.TD_GIDERI_DOVIZ_ID = sonucTD_GIDERI.DovizId;
            sonucTD_TEBLIG_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["TD_TEBLIG_GIDERI"], zaman); asilFoy.TD_TEBLIG_GIDERI = sonucTD_TEBLIG_GIDERI.Para; asilFoy.TD_TEBLIG_GIDERI_DOVIZ_ID = sonucTD_TEBLIG_GIDERI.DovizId;
            sonucTD_VEK_UCR = FaizHelper.ParalariTopla(paralarinSozlugu["TD_VEK_UCR"], zaman); asilFoy.TD_VEK_UCR = sonucTD_VEK_UCR.Para; asilFoy.TD_VEK_UCR_DOVIZ_ID = sonucTD_VEK_UCR.DovizId;
            sonucTESLIM_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["TESLIM_HARCI"], zaman); asilFoy.TESLIM_HARCI = sonucTESLIM_HARCI.Para; asilFoy.TESLIM_HARCI_DOVIZ_ID = sonucTESLIM_HARCI.DovizId;
            sonucTO_MASRAF_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_MASRAF_TOPLAMI"], zaman); asilFoy.TO_MASRAF_TOPLAMI = sonucTO_MASRAF_TOPLAMI.Para; asilFoy.TO_MASRAF_TOPLAMI_DOVIZ_ID = sonucTO_MASRAF_TOPLAMI.DovizId;
            sonucTO_ODEME_MAHSUP_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_ODEME_MAHSUP_TOPLAMI"], zaman); asilFoy.TO_ODEME_MAHSUP_TOPLAMI = sonucTO_ODEME_MAHSUP_TOPLAMI.Para; asilFoy.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = sonucTO_ODEME_MAHSUP_TOPLAMI.DovizId;
            sonucTO_ODEME_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_ODEME_TOPLAMI"], zaman); asilFoy.TO_ODEME_TOPLAMI = sonucTO_ODEME_TOPLAMI.Para; asilFoy.TO_ODEME_TOPLAMI_DOVIZ_ID = sonucTO_ODEME_TOPLAMI.DovizId;
            sonucTO_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_VEKALET_TOPLAMI"], zaman); asilFoy.TO_VEKALET_TOPLAMI = sonucTO_VEKALET_TOPLAMI.Para; asilFoy.TO_VEKALET_TOPLAMI_DOVIZ_ID = sonucTO_VEKALET_TOPLAMI.DovizId;
            sonucTO_YONETIMG_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_YONETIMG_TAZMINATI"], zaman); asilFoy.TO_YONETIMG_TAZMINATI = sonucTO_YONETIMG_TAZMINATI.Para; asilFoy.TO_YONETIMG_TAZMINATI_DOVIZ_ID = sonucTO_YONETIMG_TAZMINATI.DovizId;
            sonucTS_MASRAF_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TS_MASRAF_TOPLAMI"], zaman); asilFoy.TS_MASRAF_TOPLAMI = sonucTS_MASRAF_TOPLAMI.Para; asilFoy.TS_MASRAF_TOPLAMI_DOVIZ_ID = sonucTS_MASRAF_TOPLAMI.DovizId;
            sonucTS_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TS_VEKALET_TOPLAMI"], zaman); asilFoy.TS_VEKALET_TOPLAMI = sonucTS_VEKALET_TOPLAMI.Para; asilFoy.TS_VEKALET_TOPLAMI_DOVIZ_ID = sonucTS_VEKALET_TOPLAMI.DovizId;
            sonucTUM_MASRAF_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TUM_MASRAF_TOPLAMI"], zaman); asilFoy.TUM_MASRAF_TOPLAMI = sonucTUM_MASRAF_TOPLAMI.Para; asilFoy.TUM_MASRAF_TOPLAMI_DOVIZ_ID = sonucTUM_MASRAF_TOPLAMI.DovizId;
            sonucTUM_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TUM_VEKALET_TOPLAMI"], zaman); asilFoy.TUM_VEKALET_TOPLAMI = sonucTUM_VEKALET_TOPLAMI.Para; asilFoy.TUM_VEKALET_TOPLAMI_DOVIZ_ID = sonucTUM_VEKALET_TOPLAMI.DovizId;
            sonucVEKALET_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["VEKALET_HARCI"], zaman); asilFoy.VEKALET_HARCI = sonucVEKALET_HARCI.Para; asilFoy.VEKALET_HARCI_DOVIZ_ID = sonucVEKALET_HARCI.DovizId;
            sonucVEKALET_PULU = FaizHelper.ParalariTopla(paralarinSozlugu["VEKALET_PULU"], zaman); asilFoy.VEKALET_PULU = sonucVEKALET_PULU.Para; asilFoy.VEKALET_PULU_DOVIZ_ID = sonucVEKALET_PULU.DovizId;

            #endregion Toplam Sonuçu Oluşturuluyor

            AlacaklarToplami(asilFoy, zaman);

            //ParaVeDovizId takipCikisi = FaizHelper.TakipCikisiHesapla(asilFoy);

            KalanBorcToplami(asilFoy, zaman);

            //return asilfoy;
        }

        public void HesapSonuToplamlari(AV001_TI_BIL_FOY foy)
        {
            #region Takip Öncesi Masraflar Toplamı

            var prTakipOncesiMasraflarToplami = ParaVeDovizId.Topla(new ParaVeDovizId(foy.IHTAR_GIDERI, foy.IHTAR_GIDERI_DOVIZ_ID),
                                                                    new ParaVeDovizId(foy.IH_GIDERI, foy.IH_GIDERI_DOVIZ_ID),
                                                                    new ParaVeDovizId(foy.IT_GIDERI, foy.IT_GIDERI_DOVIZ_ID));
            foy.TO_MASRAF_TOPLAMI = prTakipOncesiMasraflarToplami.Para;
            foy.TO_MASRAF_TOPLAMI_DOVIZ_ID = prTakipOncesiMasraflarToplami.DovizId;

            #endregion Takip Öncesi Masraflar Toplamı

            #region Takip Sonrası Masraflar Toplamı

            var prTakipSonrasiMasraflarToplami = ParaVeDovizId.Topla(new ParaVeDovizId(foy.ILK_GIDERLER, foy.ILK_GIDERLER_DOVIZ_ID),
                                                new ParaVeDovizId(foy.ILK_TEBLIGAT_GIDERI, foy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.TD_GIDERI, foy.TD_GIDERI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.TD_TEBLIG_GIDERI, foy.TD_TEBLIG_GIDERI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.VEKALET_PULU, foy.VEKALET_PULU_DOVIZ_ID),
                                                new ParaVeDovizId(foy.DIGER_GIDERLER, foy.DIGER_GIDERLER_DOVIZ_ID));
            foy.TS_MASRAF_TOPLAMI = prTakipSonrasiMasraflarToplami.Para;
            foy.TS_MASRAF_TOPLAMI_DOVIZ_ID = prTakipSonrasiMasraflarToplami.DovizId;

            #endregion Takip Sonrası Masraflar Toplamı

            #region Tüm Masraflar Toplamı

            var prTumMasraflarToplami = ParaVeDovizId.Topla(prTakipOncesiMasraflarToplami, prTakipSonrasiMasraflarToplami);
            foy.TUM_MASRAF_TOPLAMI = prTumMasraflarToplami.Para;
            foy.TUM_MASRAF_TOPLAMI_DOVIZ_ID = prTumMasraflarToplami.DovizId;

            #endregion Tüm Masraflar Toplamı

            #region Tüm Ödemeler Toplamı

            var prTumOdemelerToplami = ParaVeDovizId.Topla(new ParaVeDovizId(foy.ODEME_TOPLAMI, foy.ODEME_TOPLAMI_DOVIZ_ID),
                                                            new ParaVeDovizId(foy.TO_ODEME_TOPLAMI, foy.TO_ODEME_TOPLAMI_DOVIZ_ID));
            foy.TUM_ODEME_TOPLAMI = prTumOdemelerToplami.Para;
            foy.TUM_ODEME_TOPLAMI_DOVIZ_ID = prTumOdemelerToplami.DovizId;

            #endregion Tüm Ödemeler Toplamı

            #region Takip Öncesi Vekalet Toplamı

            var prTakipOncesiVekaletToplami = ParaVeDovizId.Topla(new ParaVeDovizId(foy.IH_VEKALET_UCRETI, foy.IH_VEKALET_UCRETI_DOVIZ_ID),
                                            new ParaVeDovizId(foy.IT_VEKALET_UCRETI, foy.IT_VEKALET_UCRETI_DOVIZ_ID),
                                            new ParaVeDovizId(foy.ILAM_VEK_UCR, foy.ILAM_VEK_UCR_DOVIZ_ID));
            foy.TO_VEKALET_TOPLAMI = prTakipOncesiVekaletToplami.Para;
            foy.TO_VEKALET_TOPLAMI_DOVIZ_ID = prTakipOncesiVekaletToplami.DovizId;

            #endregion Takip Öncesi Vekalet Toplamı

            #region Takip Sonrası Vekalet Toplamı

            var prTakipSonrasiVekaletToplami = ParaVeDovizId.Topla(new ParaVeDovizId(foy.TAKIP_VEKALET_UCRETI, foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.TAHLIYE_VEK_UCR, foy.TAHLIYE_VEK_UCR_DOVIZ_ID),
                                                new ParaVeDovizId(foy.TD_VEK_UCR, foy.TD_VEK_UCR_DOVIZ_ID));
            foy.TS_VEKALET_TOPLAMI = prTakipSonrasiVekaletToplami.Para;
            foy.TS_VEKALET_TOPLAMI_DOVIZ_ID = prTakipSonrasiVekaletToplami.DovizId;

            #endregion Takip Sonrası Vekalet Toplamı

            #region Tüm Vekalet Toplamı

            var prTumVekaletToplami = ParaVeDovizId.Topla(new ParaVeDovizId(foy.TS_VEKALET_TOPLAMI, foy.TS_VEKALET_TOPLAMI_DOVIZ_ID),
                                                        new ParaVeDovizId(foy.TO_VEKALET_TOPLAMI, foy.TO_VEKALET_TOPLAMI_DOVIZ_ID));

            foy.TUM_VEKALET_TOPLAMI = prTumVekaletToplami.Para;
            foy.TUM_VEKALET_TOPLAMI_DOVIZ_ID = prTumVekaletToplami.DovizId;

            #endregion Tüm Vekalet Toplamı

            #region Harçlar Toplamı

            var prHarclarToplami = ParaVeDovizId.Topla(new ParaVeDovizId(foy.BASVURMA_HARCI, foy.BASVURMA_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.DEPO_HARCI, foy.DEPO_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.DIGER_HARC, foy.DIGER_HARC_DOVIZ_ID),
                                                new ParaVeDovizId(foy.FERAGAT_HARCI, foy.FERAGAT_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.IFLAS_BASVURMA_HARCI, foy.IFLAS_BASVURMA_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.IFLASIN_ACILMASI_HARCI, foy.IFLASIN_ACILMASI_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.KALAN_TAHSIL_HARCI, foy.KALAN_TAHSIL_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.MASAYA_KATILMA_HARCI, foy.MASAYA_KATILMA_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.ODENEN_TAHSIL_HARCI, foy.ODENEN_TAHSIL_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.PAYLASMA_HARCI, foy.PAYLASMA_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.PESIN_HARC, foy.PESIN_HARC_DOVIZ_ID),
                                                new ParaVeDovizId(foy.TAHLIYE_HARCI, foy.TAHLIYE_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.TD_BAKIYE_HARC, foy.TD_BAKIYE_HARC_DOVIZ_ID),
                                                new ParaVeDovizId(foy.TESLIM_HARCI, foy.TESLIM_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.VEKALET_HARCI, foy.VEKALET_HARCI_DOVIZ_ID));
            foy.HARC_TOPLAMI = prHarclarToplami.Para;
            foy.HARC_TOPLAMI_DOVIZ_ID = prHarclarToplami.DovizId;

            #endregion Harçlar Toplamı

            #region Takip Sonrası Masraflar Toplamı

            var prTakipSonrasiMasraflarHarcToplami = ParaVeDovizId.Topla(prHarclarToplami, prTakipSonrasiMasraflarToplami);
            foy.TS_MASRAF_HARC_TOPLAMI = prTakipSonrasiMasraflarHarcToplami.Para;
            foy.TS_MASRAF_HARC_TOPLAMI_DOVIZ_ID = prTakipSonrasiMasraflarHarcToplami.DovizId;

            #endregion Takip Sonrası Masraflar Toplamı

            #region Risk Miktarı

            var prRiskMiktari = ParaVeDovizId.Topla(prTakipSonrasiMasraflarHarcToplami, new ParaVeDovizId(foy.ASIL_ALACAK, foy.ASIL_ALACAK_DOVIZ_ID));
            foy.RISK_MIKTARI = prRiskMiktari.Para;
            foy.RISK_MIKTARI_DOVIZ_ID = prRiskMiktari.DovizId;

            #endregion Risk Miktarı

            #region Riskten Kalan

            var prRisktenKalan = ParaVeDovizId.Cikart(prRiskMiktari, prTumOdemelerToplami);
            foy.RISKTEN_KALAN = prRiskMiktari.Para;
            foy.RISKTEN_KALAN_DOVIZ_ID = prRiskMiktari.DovizId;

            #endregion Riskten Kalan
        }

        public void HesapSonuToplamlari(AV001_TI_BIL_FOY_TARAF foy)
        {
            #region Takip Öncesi Masraflar Toplamı

            var prTakipOncesiMasraflarToplami = ParaVeDovizId.Topla(new ParaVeDovizId(foy.IHTAR_GIDERI, foy.IHTAR_GIDERI_DOVIZ_ID),
                                                                    new ParaVeDovizId(foy.IH_GIDERI, foy.IH_GIDERI_DOVIZ_ID),
                                                                    new ParaVeDovizId(foy.IT_GIDERI, foy.IT_GIDERI_DOVIZ_ID));
            foy.TO_MASRAF_TOPLAMI = prTakipOncesiMasraflarToplami.Para;
            foy.TO_MASRAF_TOPLAMI_DOVIZ_ID = prTakipOncesiMasraflarToplami.DovizId;

            #endregion Takip Öncesi Masraflar Toplamı

            #region Takip Sonrası Masraflar Toplamı

            var prTakipSonrasiMasraflarToplami = ParaVeDovizId.Topla(new ParaVeDovizId(foy.ILK_GIDERLER, foy.ILK_GIDERLER_DOVIZ_ID),
                                                new ParaVeDovizId(foy.ILK_TEBLIGAT_GIDERI, foy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.TD_GIDERI, foy.TD_GIDERI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.TD_TEBLIG_GIDERI, foy.TD_TEBLIG_GIDERI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.VEKALET_PULU, foy.VEKALET_PULU_DOVIZ_ID),
                                                new ParaVeDovizId(foy.DIGER_GIDERLER, foy.DIGER_GIDERLER_DOVIZ_ID));
            foy.TS_MASRAF_TOPLAMI = prTakipSonrasiMasraflarToplami.Para;
            foy.TS_MASRAF_TOPLAMI_DOVIZ_ID = prTakipSonrasiMasraflarToplami.DovizId;

            #endregion Takip Sonrası Masraflar Toplamı

            #region Tüm Masraflar Toplamı

            var prTumMasraflarToplami = ParaVeDovizId.Topla(prTakipOncesiMasraflarToplami, prTakipSonrasiMasraflarToplami);
            foy.TUM_MASRAF_TOPLAMI = prTumMasraflarToplami.Para;
            foy.TUM_MASRAF_TOPLAMI_DOVIZ_ID = prTumMasraflarToplami.DovizId;

            #endregion Tüm Masraflar Toplamı

            #region Tüm Ödemeler Toplamı

            // var prTumOdemelerToplami = ParaVeDovizId.Topla(new ParaVeDovizId(foy.ODEME_TOPLAMI, foy.ODEME_TOPLAMI_DOVIZ_ID),
            //                                                 new ParaVeDovizId(foy.TO_ODEME_TOPLAMI, foy.TO_ODEME_TOPLAMI_DOVIZ_ID));
            //foy.TUM_ODEME_TOPLAMI = prTumOdemelerToplami.Para;
            //foy.TUM_ODEME_TOPLAMI_DOVIZ_ID = prTumOdemelerToplami.DovizId;

            #endregion Tüm Ödemeler Toplamı

            #region Takip Öncesi Vekalet Toplamı

            var prTakipOncesiVekaletToplami = ParaVeDovizId.Topla(new ParaVeDovizId(foy.IH_VEKALET_UCRETI, foy.IH_VEKALET_UCRETI_DOVIZ_ID),
                                            new ParaVeDovizId(foy.IT_VEKALET_UCRETI, foy.IT_VEKALET_UCRETI_DOVIZ_ID),
                                            new ParaVeDovizId(foy.ILAM_VEK_UCR, foy.ILAM_VEK_UCR_DOVIZ_ID));
            foy.TO_VEKALET_TOPLAMI = prTakipOncesiVekaletToplami.Para;
            foy.TO_VEKALET_TOPLAMI_DOVIZ_ID = prTakipOncesiVekaletToplami.DovizId;

            #endregion Takip Öncesi Vekalet Toplamı

            #region Takip Sonrası Vekalet Toplamı

            var prTakipSonrasiVekaletToplami = ParaVeDovizId.Topla(new ParaVeDovizId(foy.TAKIP_VEKALET_UCRETI, foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.TAHLIYE_VEK_UCR, foy.TAHLIYE_VEK_UCR_DOVIZ_ID),
                                                new ParaVeDovizId(foy.TD_VEK_UCR, foy.TD_VEK_UCR_DOVIZ_ID));
            foy.TS_VEKALET_TOPLAMI = prTakipSonrasiVekaletToplami.Para;
            foy.TS_VEKALET_TOPLAMI_DOVIZ_ID = prTakipSonrasiVekaletToplami.DovizId;

            #endregion Takip Sonrası Vekalet Toplamı

            #region Tüm Vekalet Toplamı

            var prTumVekaletToplami = ParaVeDovizId.Topla(new ParaVeDovizId(foy.TS_VEKALET_TOPLAMI, foy.TS_VEKALET_TOPLAMI_DOVIZ_ID),
                                                        new ParaVeDovizId(foy.TO_VEKALET_TOPLAMI, foy.TO_VEKALET_TOPLAMI_DOVIZ_ID));

            foy.TUM_VEKALET_TOPLAMI = prTumVekaletToplami.Para;
            foy.TUM_VEKALET_TOPLAMI_DOVIZ_ID = prTumVekaletToplami.DovizId;

            #endregion Tüm Vekalet Toplamı

            #region Harçlar Toplamı

            var prHarclarToplami = ParaVeDovizId.Topla(new ParaVeDovizId(foy.BASVURMA_HARCI, foy.BASVURMA_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.DEPO_HARCI, foy.DEPO_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.DIGER_HARC, foy.DIGER_HARC_DOVIZ_ID),
                                                new ParaVeDovizId(foy.FERAGAT_HARCI, foy.FERAGAT_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.IFLAS_BASVURMA_HARCI, foy.IFLAS_BASVURMA_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.IFLASIN_ACILMASI_HARCI, foy.IFLASIN_ACILMASI_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.KALAN_TAHSIL_HARCI, foy.KALAN_TAHSIL_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.MASAYA_KATILMA_HARCI, foy.MASAYA_KATILMA_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.ODENEN_TAHSIL_HARCI, foy.ODENEN_TAHSIL_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.PAYLASMA_HARCI, foy.PAYLASMA_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.PESIN_HARC, foy.PESIN_HARC_DOVIZ_ID),
                                                new ParaVeDovizId(foy.TAHLIYE_HARCI, foy.TAHLIYE_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.TD_BAKIYE_HARC, foy.TD_BAKIYE_HARC_DOVIZ_ID),
                                                new ParaVeDovizId(foy.TESLIM_HARCI, foy.TESLIM_HARCI_DOVIZ_ID),
                                                new ParaVeDovizId(foy.VEKALET_HARCI, foy.VEKALET_HARCI_DOVIZ_ID));
            foy.HARC_TOPLAMI = prHarclarToplami.Para;
            foy.HARC_TOPLAMI_DOVIZ_ID = prHarclarToplami.DovizId;

            #endregion Harçlar Toplamı

            #region Takip Sonrası Masraflar Toplamı

            var prTakipSonrasiMasraflarHarcToplami = ParaVeDovizId.Topla(prHarclarToplami, prTakipSonrasiMasraflarToplami);
            foy.TS_MASRAF_HARC_TOPLAMI = prTakipSonrasiMasraflarHarcToplami.Para;
            foy.TS_MASRAF_HARC_TOPLAMI_DOVIZ_ID = prTakipSonrasiMasraflarHarcToplami.DovizId;

            #endregion Takip Sonrası Masraflar Toplamı

            #region Risk Miktarı

            //var prRiskMiktari = ParaVeDovizId.Topla(prTakipSonrasiMasraflarHarcToplami, new ParaVeDovizId(foy.ASIL_ALACAK, foy.ASIL_ALACAK_DOVIZ_ID));
            //foy.RISK_MIKTARI = prRiskMiktari.Para;
            //foy.RISK_MIKTARI_DOVIZ_ID = prRiskMiktari.DovizId;

            #endregion Risk Miktarı

            #region Riskten Kalan

            //var prRisktenKalan = ParaVeDovizId.Cikart(prRiskMiktari, prTumOdemelerToplami);
            //foy.RISKTEN_KALAN = prRiskMiktari.Para;
            //foy.RISKTEN_KALAN_DOVIZ_ID = prRiskMiktari.DovizId;

            #endregion Riskten Kalan
        }

        public void IcraFoyDeepLoad(AV001_TI_BIL_FOY mFoy)
        {
            if (mFoy.Tag != null && mFoy.Tag.ToString() == "Cekme")
                return;

            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(mFoy, true, DeepLoadType.IncludeChildren,
                    typeof(TList<AV001_TI_BIL_FOY_OZEL_KOD>),
                    typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                    typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>),
                    typeof(TList<AV001_TDI_BIL_GORUSME>),
                    typeof(TList<AV001_TI_BIL_BORCLU_ODEME>),
                    typeof(TList<AV001_TI_BIL_MAL_BEYANI>),
                    typeof(TList<AV001_TI_BIL_MAL_BEYAN_DETAY>),
                    typeof(TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>),
                    typeof(TList<AV001_TDI_BIL_TEBLIGAT>),
                    typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>),
                    typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>),
                    typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>),
                    typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>),
                    typeof(TList<AV001_TDIE_BIL_ASAMA>),
                    typeof(TList<AV001_TDIE_BIL_ASAMA_TARAF>),
                    typeof(TList<AV001_TDIE_BIL_ASAMA_SORUMLU>),
                    typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>),
                    typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ>),
                    typeof(TList<AV001_TI_BIL_KEFALET_BILGILERI>),
                    typeof(TList<AV001_TI_BIL_MUVEKKILE_ODEME>),
                    typeof(TList<AV001_TI_BIL_BORCLU_MAHSUP>),
                    typeof(TList<AV001_TI_BIL_FERAGAT>),
                    typeof(TList<AV001_TI_BIL_FOY_GENEL_NOT>),
                    typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>),
                    typeof(TList<AV001_TI_BIL_SATIS_MASTER>),
                    typeof(TList<AV001_TI_BIL_FOY_GELISME>),
                    typeof(TList<AV001_TI_BIL_DUSME_YENILEME>),
                    typeof(AV001_TI_KOD_HESAP_TIP),
                    typeof(TList<AV001_TI_BIL_HACIZ_MASTER>),
                    typeof(TList<AV001_TI_BIL_HACIZ_CHILD>),
                    typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>),
                    typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>),
                    typeof(TList<AV001_TDI_BIL_SOZLESME>),
                    typeof(TDIE_KOD_TARAF_SIFAT),
                    typeof(AV001_TDI_BIL_CARI),
                    typeof(TList<AV001_TI_BIL_ILAM_MAHKEMESI>)
             );

            foreach (AV001_TI_BIL_HACIZ_MASTER master in mFoy.AV001_TI_BIL_HACIZ_MASTERCollection)
            {
                foreach (AV001_TI_BIL_HACIZ_CHILD child in master.AV001_TI_BIL_HACIZ_CHILDCollection)
                {
                    DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepLoad(child, false, DeepLoadType.IncludeChildren,
                        typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>),
                        typeof(TList<AV001_TI_BIL_ISTIHKAK>),
                        typeof(TList<AV001_TI_BIL_HACIZ_ISTIRAK>));
                }
            }

            if (mFoy.AV001_TDI_BIL_TEBLIGATCollection.Count > 0)
                DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(mFoy.AV001_TDI_BIL_TEBLIGATCollection, false,
                    DeepLoadType.IncludeChildren,
                    typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>),
                    typeof(TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>));
        }

        public void IcraFoyHesapla(AV001_TI_BIL_FOY myFoy, DateTime SonHesapTarihi)
        {
            myFoy.SON_HESAP_TARIHI = SonHesapTarihi;
            IcraFoyHesapla(myFoy);
        }

        public void IcraFoyHesapla(AV001_TI_BIL_FOY myFoy, bool hesapladiktanSonraKaydet)
        {
            IcraFoyHesapla(myFoy);
            bool kaydoldu = false;
            if (hesapladiktanSonraKaydet)
                kaydoldu = Kaydet(myFoy);
        }

        public void IcraFoyHesapla(AV001_TI_BIL_FOY myFoy)
        {
            if (myFoy == null)
                return;

            IcraFoyDeepLoad(myFoy);
            myFoy.TO_HESAP_TIP_IDSource = DataRepository.AV001_TI_KOD_HESAP_TIPProvider.GetByID(myFoy.TO_HESAP_TIP_ID);
            myFoy.TS_HESAP_TIP_IDSource = DataRepository.AV001_TI_KOD_HESAP_TIPProvider.GetByID(myFoy.TS_HESAP_TIP_ID);

            myFoy.AV001_TI_BIL_ALACAK_NEDENCollection.ApplyFilter(vi => vi.AN_URETIP_TIP != (byte)AN_URETIP_TIP.SenetleTakibeKonuldu);

            if (myFoy.SON_HESAP_TARIHI.HasValue)
            {
                myFoy.AV001_TI_BIL_BORCLU_ODEMECollection.Filter = string.Format("{0} <= '{1}'", AV001_TI_BIL_BORCLU_ODEMEColumn.ODEME_TARIHI.ToString(), myFoy.SON_HESAP_TARIHI.Value.AddDays(1).ToString());
                myFoy.AV001_TI_BIL_FERAGATCollection.Filter = string.Format("{0} <= '{1}'", AV001_TI_BIL_FERAGATColumn.FERAGAT_TARIHI.ToString(), myFoy.SON_HESAP_TARIHI.Value.AddDays(1).ToString());
            }
            DataRepository.AV001_TI_BIL_FAIZProvider.Delete(myFoy.AV001_TI_BIL_FAIZCollection);

            foreach (var item in myFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
            {
                DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));

                DataRepository.AV001_TI_BIL_ODEME_DAGILIMProvider.Delete(item.AV001_TI_BIL_ODEME_DAGILIMCollection);
                item.AV001_TI_BIL_ODEME_DAGILIMCollection.Clear();
            }
            foreach (var item in myFoy.AV001_TI_BIL_FOY_TARAFCollection)
            {
                DataRepository.AV001_TI_BIL_ODEME_DAGILIMProvider.Delete(DataRepository.AV001_TI_BIL_ODEME_DAGILIMProvider.GetByALACAK_NEDEN_TARAF_ID(item.ID));
                item.AV001_TI_BIL_ODEME_DAGILIMCollection.Clear();
            }
            DataRepository.AV001_TI_BIL_ODEME_DAGILIMProvider.Delete(myFoy.AV001_TI_BIL_ODEME_DAGILIMCollection);
            myFoy.AV001_TI_BIL_ODEME_DAGILIMCollection.Clear();
            DataRepository.AV001_TI_BIL_FAIZProvider.Delete(myFoy.AV001_TI_BIL_FAIZCollection);
            DataRepository.AV001_TI_BIL_HARCProvider.Delete(myFoy.AV001_TI_BIL_HARCCollection);

            myFoy.AV001_TI_BIL_FAIZCollection.Clear();
            myFoy.AV001_TI_BIL_HARCCollection.Clear();

            if (myFoy.SON_HESAP_TARIHI == null)
                myFoy.SON_HESAP_TARIHI = DateTime.Now;

            TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> tumAlacakNedenTaraf = new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>();
            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                #region Alacak Neden Taraflarında Dönüyoruz

                foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF trf in neden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                {
                    DataRepository.AV001_TI_BIL_FAIZProvider.Delete(DataRepository.AV001_TI_BIL_FAIZProvider.GetByALACAK_NEDEN_TARAF_ID(trf.ID));

                    #region faiz kalemi  oluşturuyoruz

                    if (trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Count == 0)
                    {
                        AV001_TI_BIL_ALACAK_NEDEN ndn = neden;
                        if ((ndn.TO_ALACAK_FAIZ_TIP_ID.HasValue || (ndn.SABIT_FAIZ_UYGULA && ndn.TO_UYGULANACAK_FAIZ_ORANI > 0)) &&
    ndn.FAIZ_BASLANGIC_TARIHI.HasValue)
                        {
                            if (trf.TARAF_SIFAT_IDSource == null && trf.TARAF_SIFAT_ID.HasValue)
                                trf.TARAF_SIFAT_IDSource = DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID(trf.TARAF_SIFAT_ID.Value);

                            if (trf.TARAF_SIFAT_IDSource != null && trf.TARAF_SIFAT_IDSource.HANGI_TARAFI == "TAKİP EDİLEN")
                            {
                                #region Faiz Oluşturuyoruz

                                AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ faiz = new AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ();

                                faiz.FAIZ_BASLANGIC_TARIHI = ndn.FAIZ_BASLANGIC_TARIHI.Value;
                                faiz.FAIZ_BITIS_TARIHI = myFoy.TAKIP_TARIHI;
                                faiz.FAIZ_TIP_ID = ndn.TO_ALACAK_FAIZ_TIP_ID;
                                faiz.FAIZ_ORANI = ndn.TO_UYGULANACAK_FAIZ_ORANI;
                                faiz.SABIT_FAIZ = ndn.SABIT_FAIZ_UYGULA;
                                faiz.KAYIT_TARIHI = DateTime.Now;
                                faiz.KLASOR_KODU = Kimlikci.Kimlik.CurrentKlasorKodu;
                                faiz.KONTROL_KIM = Kimlikci.Kimlik.KullaniciAdi;
                                faiz.KONTROL_NE_ZAMAN = DateTime.Now;
                                faiz.STAMP = Kimlikci.Kimlik.DefaultStamp;
                                faiz.TARAF_CARI_ID = trf.TARAF_CARI_ID;

                                if ((ndn.ALACAK_FAIZ_TIP_ID.HasValue || (ndn.SABIT_FAIZ_UYGULA && ndn.UYGULANACAK_FAIZ_ORANI > 0)))
                                {
                                    bool gerekVar = true;
                                    if (ndn.SABIT_FAIZ_UYGULA &&
                                        (trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Count > 0 &&
                                         trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection[0].FAIZ_ORANI == ndn.UYGULANACAK_FAIZ_ORANI))
                                    {
                                        trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection[0].FAIZ_BITIS_TARIHI = myFoy.SON_HESAP_TARIHI;
                                        gerekVar = false;
                                    }
                                    if (!ndn.SABIT_FAIZ_UYGULA && trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Count > 0 &&
                                        trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection[0].FAIZ_TIP_ID.Value ==
                                        ndn.ALACAK_FAIZ_TIP_ID.Value)
                                    {
                                        trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection[0].FAIZ_BITIS_TARIHI = myFoy.SON_HESAP_TARIHI;
                                        gerekVar = false;
                                    }
                                    if (gerekVar)
                                    {
                                        //AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ faiz = new AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ();
                                        faiz.FAIZ_BASLANGIC_TARIHI = neden.FAIZ_BASLANGIC_TARIHI ?? DateTime.Today;
                                        faiz.FAIZ_BITIS_TARIHI = myFoy.TAKIP_TARIHI ?? DateTime.Today;
                                        faiz.FAIZ_TIP_ID = ndn.ALACAK_FAIZ_TIP_ID;
                                        faiz.FAIZ_ORANI = ndn.UYGULANACAK_FAIZ_ORANI;
                                        faiz.SABIT_FAIZ = ndn.SABIT_FAIZ_UYGULA;
                                        faiz.KAYIT_TARIHI = DateTime.Now;
                                        faiz.KLASOR_KODU = Kimlikci.Kimlik.CurrentKlasorKodu;
                                        faiz.KONTROL_KIM = Kimlikci.Kimlik.KullaniciAdi;
                                        faiz.KONTROL_NE_ZAMAN = DateTime.Now;
                                        faiz.STAMP = Kimlikci.Kimlik.DefaultStamp;
                                    }

                                    trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Add(faiz);
                                }

                                #endregion Faiz Oluşturuyoruz
                            }
                        }

                        if ((ndn.ALACAK_FAIZ_TIP_ID.HasValue || (ndn.SABIT_FAIZ_UYGULA && ndn.UYGULANACAK_FAIZ_ORANI > 0)))
                        {
                            if (trf.TARAF_SIFAT_ID.HasValue && trf.TARAF_SIFAT_IDSource == null)
                                DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepLoad(trf, true,
                                    DeepLoadType.IncludeChildren, typeof(TDIE_KOD_TARAF_SIFAT));

                            bool gerekVar = true;
                            if (ndn.SABIT_FAIZ_UYGULA &&
                                (trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Count > 0 &&
                                 trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection[0].FAIZ_ORANI == ndn.UYGULANACAK_FAIZ_ORANI))
                            {
                                trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection[0].FAIZ_BITIS_TARIHI = myFoy.SON_HESAP_TARIHI;
                                gerekVar = false;
                            }
                            if (!ndn.SABIT_FAIZ_UYGULA && trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Count > 0 &&
                                trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection[0].FAIZ_TIP_ID.Value ==
                                ndn.ALACAK_FAIZ_TIP_ID.Value)
                            {
                                trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection[0].FAIZ_BITIS_TARIHI = myFoy.SON_HESAP_TARIHI;
                                gerekVar = false;
                            }
                            if (gerekVar)
                            {
                                AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ faiz = new AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ();
                                faiz.FAIZ_BASLANGIC_TARIHI = myFoy.TAKIP_TARIHI.Value;
                                faiz.FAIZ_BITIS_TARIHI = myFoy.SON_HESAP_TARIHI;
                                faiz.FAIZ_TIP_ID = ndn.ALACAK_FAIZ_TIP_ID;
                                faiz.FAIZ_ORANI = ndn.UYGULANACAK_FAIZ_ORANI;
                                faiz.SABIT_FAIZ = ndn.SABIT_FAIZ_UYGULA;
                                faiz.KAYIT_TARIHI = DateTime.Now;
                                faiz.KLASOR_KODU = Kimlikci.Kimlik.CurrentKlasorKodu;
                                faiz.KONTROL_KIM = Kimlikci.Kimlik.KullaniciAdi;
                                faiz.KONTROL_NE_ZAMAN = DateTime.Now;
                                faiz.STAMP = Kimlikci.Kimlik.DefaultStamp;
                                trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Add(faiz);
                            }
                        }
                    }

                    #endregion faiz kalemi  oluşturuyoruz

                    trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Sort(string.Format("{0} DESC", AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZColumn.FAIZ_BITIS_TARIHI.ToString()));
                    if (trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Count > 0)
                        trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection[0].FAIZ_BITIS_TARIHI = myFoy.SON_HESAP_TARIHI;
                }

                #endregion Alacak Neden Taraflarında Dönüyoruz

                #region Takip Öncesi Faiz Tipi Seçilmemiş se

                if (!neden.TO_ALACAK_FAIZ_TIP_ID.HasValue)
                {
                    if (!neden.ALACAK_FAIZ_TIP_ID.HasValue)
                    {
                        neden.TO_ALACAK_FAIZ_TIP_ID = neden.ALACAK_FAIZ_TIP_ID;
                        neden.TO_UYGULANACAK_FAIZ_ORANI = neden.UYGULANACAK_FAIZ_ORANI;
                    }
                    else
                    {
                        neden.FAIZ_YOK = true;
                    }
                }

                #endregion Takip Öncesi Faiz Tipi Seçilmemiş se

                if (neden.ALACAK_FAIZ_TIP_ID == (int)FaizTip.Özel_Sabit_Faiz)
                    neden.SABIT_FAIZ_UYGULA = true;

                neden.AV001_TI_BIL_FAIZCollection.Clear();
                tumAlacakNedenTaraf.AddRange(neden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection);
            }

            if (myFoy.SON_HESAP_TARIHI < myFoy.TAKIP_TARIHI)
                myFoy.SON_HESAP_TARIHI = myFoy.TAKIP_TARIHI;

            myFoy.AV001_TI_BIL_FOY_TARAFCollection.Filter = "TAKIP_EDEN_MI = 'False'";
            TList<AV001_TI_BIL_FOY_TARAF> listTakipEdilen = new TList<AV001_TI_BIL_FOY_TARAF>();
            listTakipEdilen.AddRange(myFoy.AV001_TI_BIL_FOY_TARAFCollection);
            myFoy.AV001_TI_BIL_FOY_TARAFCollection.RemoveFilter();
            DateTime basla = DateTime.Now;

            HesapAlanlariKontrolu(myFoy);

            FaizHelper.HesaplaAsilAlacak(myFoy); // temiz

            FaizHelper.HesaplaTakipOncesiIslemisFaiz(myFoy);

            FaizHelper.HesaplaIlamFaizi(myFoy, Takip.Oncesi);

            FaizHelper.HesaplaIlam(myFoy);

            FaizHelper.ProtestoIhtarGiderHesapla(myFoy);

            FaizHelper.HesaplaIhtiyatiTedbirHaciz(true, myFoy, tumAlacakNedenTaraf);

            FaizHelper.HesaplaTakipOncesiOdeme(myFoy);
            FaizHelper.HesaplaMahsup(myFoy);
            //frmIcraDosyaKayit.HesaplaTaraf(myFoy);
            FaizHelper.HesaplaTakipCikisi(myFoy);

            //System.Diagnostics.Debug.WriteLine("HesaplaFoyTarafUzerine");
            //FaizHelper.HesaplaFoyTarafUzerine(myFoy); // yeni

            FaizHelper.HesaplaKalanTahsilHarciVs(myFoy);
            KalanTahsilHarcindanOdeneniDus(myFoy);

            FaizHelper.IcraTazminatHesapla(myFoy, Takip.Oncesi);

            FaizHelper.IcraTazminatHesapla(myFoy, Takip.Sonrasi);

            FaizHelper.IcraTazminatlariFoyUzerineYaz(myFoy);

            FaizHelper.IcraIlkGiderleriHesapla(myFoy, myFoy.AV001_TI_BIL_FOY_TARAFCollection, listTakipEdilen.Count); //değişti

            #region TakipSonrasi

            FaizHelper.HesaplaFeragatToplami(myFoy);

            FaizHelper.HesaplaOdemeToplami(myFoy);

            FaizHelper.HesaplaDigerGiderler(myFoy);

            FaizHelper.MahsupHallet(myFoy);

           
            FaizHelper.HesaplaSonrakiFaiz(myFoy);
            FaizHelper.HesaplaIlamFaizi(myFoy, Takip.Sonrasi);
            HesaplaMasrafAvanslar(myFoy);
            FaizHelper.HesaplaTaraf(myFoy);
            FaizHelper.HesaplaFoyTarafUzerine(myFoy);
            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                foreach (var item in neden.AV001_TI_BIL_FAIZCollection)
                {
                    #region <CC-20090612>

                    // faiz detayları foya atılmıyordu kapalıydı açıldı  alacak neden ve enson hesaplamna tarihleri eklendi..

                    #endregion <CC-20090612>

                    //item.ICRA_FOY_ID = myFoy.ID;
                    if (!myFoy.AV001_TI_BIL_FAIZCollection.Contains(item))
                    {
                        item.ICRA_ALACAK_NEDEN_ID = neden.ID;
                        item.EN_SON_FAIZ_HESAPLANMA_TARIHI = myFoy.SON_HESAP_TARIHI;
                        myFoy.AV001_TI_BIL_FAIZCollection.Add(item);
                    }

                    #region <YY-20090608>

                    //sıfır föy üzerinde kaydetmeden yapılan işlemde faiz kaydederken hata alınmakta idi
                    //bu kontrol ile birlikte giderildi.
                    if (myFoy.ID == 0)
                        item.ICRA_FOY_ID = null;
                    else
                        item.ICRA_FOY_ID = myFoy.ID;

                    #endregion <YY-20090608>
                }

                //neden.AV001_TI_BIL_FAIZCollection.Clear();
                //myFoy.AV001_TI_BIL_FAIZCollection.AddRange(neden.AV001_TI_BIL_FAIZCollection);
            }
            //foreach (AV001_TI_BIL_BORCLU_ODEME odeme in myFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
            //{
            //    myFoy.AV001_TI_BIL_ODEME_DAGILIMCollection.AddRange(odeme.AV001_TI_BIL_ODEME_DAGILIMCollection);
            //}
            //ucOdemeDagilim1.MyDataSource = myFoy.AV001_TI_BIL_ODEME_DAGILIMCollection;

            //TODO:Db değişikliği sonrası devam edilecek 10dk [YY]
            if (AvukatProLib.Kimlikci.Kimlik.Bilgi != null && AvukatProLib.Kimlikci.Kimlik.Bilgi.CARI_ID.HasValue)
            {
                foreach (AV001_TDI_BIL_MASRAF_AVANS mAvans in myFoy.AV001_TDI_BIL_MASRAF_AVANSCollection)
                {
                    mAvans.CARI_ID = AvukatProLib.Kimlikci.Kimlik.Bilgi.CARI_ID.Value;
                }
            }

            FaizHelper.IcraToplamKalemleriHesapla(myFoy);
            FaizHelper.IcraVekaletUcretiKatsayiHesapla(myFoy);
            FaizHelper.KalanHesapla(myFoy);

            #endregion TakipSonrasi

            //FaizHelper.HesaplaIlamFaizi(myFoy);

            //FaizHelper.TarafGayriNakitHesapla(myFoy);

            HesaplaBakiyeHarciHesabaDahilmi(myFoy);

            HesaplaAlacakNedenUzerine(myFoy);

            TaahhutKontrolGenel(myFoy);

            //myFoy.SON_HESAP_TARIHI = DateTime.Now;
            myFoy.AV001_TI_BIL_FERAGATCollection.Filter = string.Empty;
            myFoy.AV001_TI_BIL_BORCLU_ODEMECollection.Filter = string.Empty;
            // HesapSonuToplamlari(myFoy);
            HesapAraclari.Icra.DosyaHesabi.SetFoyAlanlariTopla(myFoy);
            //DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepSave(myFoy.AV001_TI_BIL_BORCLU_ODEMECollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));
            foreach (var taraf in myFoy.AV001_TI_BIL_FOY_TARAFCollection)
            {
                HesapSonuToplamlari(taraf);
                DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepSave(taraf, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));
            }

            DateTime bitir = DateTime.Now;
            TimeSpan fark = bitir - basla;
            Console.WriteLine("###################HESAP_SÜRESİ###########################");
            Console.WriteLine("{0}saat {0}dk {1}sn {2} ms", fark.Hours, fark.Minutes, fark.Seconds, fark.Milliseconds);
            Console.WriteLine("###################HESAP_SÜRESİ###########################");
        }

        public void IcraFoyHesapla_OdemePlani(AV001_TI_BIL_FOY myFoy)
        {
            if (myFoy.SON_HESAP_TARIHI.HasValue)
            {
                myFoy.AV001_TI_BIL_BORCLU_ODEMECollection.Filter = string.Format("{0} <= '{1}'", AV001_TI_BIL_BORCLU_ODEMEColumn.ODEME_TARIHI.ToString(), myFoy.SON_HESAP_TARIHI.Value.AddDays(1));
                myFoy.AV001_TI_BIL_FERAGATCollection.Filter = string.Format("{0} <= '{1}'", AV001_TI_BIL_FERAGATColumn.FERAGAT_TARIHI.ToString(), myFoy.SON_HESAP_TARIHI.Value.AddDays(1));
            }

            myFoy.AV001_TI_BIL_FAIZCollection.Clear();

            if (myFoy.SON_HESAP_TARIHI == null)
                myFoy.SON_HESAP_TARIHI = DateTime.Today;

            TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> tumAlacakNedenTaraf = new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>();
            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                tumAlacakNedenTaraf.AddRange(neden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection);
            }

            myFoy.AV001_TI_BIL_FOY_TARAFCollection.Filter = "TAKIP_EDEN_MI = 'False'";
            TList<AV001_TI_BIL_FOY_TARAF> listTakipEdilen = new TList<AV001_TI_BIL_FOY_TARAF>();
            listTakipEdilen.AddRange(myFoy.AV001_TI_BIL_FOY_TARAFCollection);
            myFoy.AV001_TI_BIL_FOY_TARAFCollection.RemoveFilter();
            DateTime basla = DateTime.Now;

            HesapAlanlariKontrolu(myFoy);

            System.Diagnostics.Debug.WriteLine("Hesapla Asil Alacak");
            FaizHelper.HesaplaAsilAlacak(myFoy);

            System.Diagnostics.Debug.WriteLine("Hesapla İlam");
            FaizHelper.HesaplaIlam(myFoy);

            System.Diagnostics.Debug.WriteLine("Protesto İhtar Gideri Hesapla");
            FaizHelper.ProtestoIhtarGiderHesapla(myFoy);

            System.Diagnostics.Debug.WriteLine("HesaplaIhtiyatiTedbirHaciz");
            FaizHelper.HesaplaIhtiyatiTedbirHaciz(true, myFoy, tumAlacakNedenTaraf);

            System.Diagnostics.Debug.WriteLine("HesaplaTakipOncesiOdeme");
            FaizHelper.HesaplaTakipOncesiOdeme(myFoy);

            FaizHelper.HesaplaIlamFaizi(myFoy, Takip.Oncesi);
            System.Diagnostics.Debug.WriteLine("HesaplaTakipCikisi");
            FaizHelper.HesaplaTakipCikisi(myFoy);

            System.Diagnostics.Debug.WriteLine("HesaplaFoyTarafUzerine");
            FaizHelper.HesaplaFoyTarafUzerine(myFoy); // yeni

            System.Diagnostics.Debug.WriteLine("HesaplaKalanTahsilHarciVs");
            FaizHelper.HesaplaKalanTahsilHarciVs(myFoy);
            KalanTahsilHarcindanOdeneniDus(myFoy);

            System.Diagnostics.Debug.WriteLine("IcraTazminatHesapla");
            FaizHelper.IcraTazminatHesapla(myFoy, Takip.Oncesi);

            System.Diagnostics.Debug.WriteLine("IcraTazminatHesapla");
            FaizHelper.IcraTazminatHesapla(myFoy, Takip.Sonrasi);

            System.Diagnostics.Debug.WriteLine("IcraTazminatlariFoyUzerineYaz");
            FaizHelper.IcraTazminatlariFoyUzerineYaz(myFoy);

            System.Diagnostics.Debug.WriteLine("IcraIlkGiderleriHesapla");
            FaizHelper.IcraIlkGiderleriHesapla(myFoy, myFoy.AV001_TI_BIL_FOY_TARAFCollection, listTakipEdilen.Count); //değişti

            #region TakipSonrasi

            System.Diagnostics.Debug.WriteLine("HesaplaFeragatToplami");
            FaizHelper.HesaplaFeragatToplami(myFoy);

            System.Diagnostics.Debug.WriteLine("HesaplaOdemeToplami");
            FaizHelper.HesaplaOdemeToplami(myFoy);

            System.Diagnostics.Debug.WriteLine("HesaplaDigerGiderler");
            FaizHelper.HesaplaDigerGiderler(myFoy);

            System.Diagnostics.Debug.WriteLine("HesaplaSonrakiFaiz");
            FaizHelper.HesaplaSonrakiFaiz_OdemePlan(myFoy);
            FaizHelper.HesaplaIlamFaizi(myFoy, Takip.Sonrasi);
            System.Diagnostics.Debug.WriteLine("HesaplaTaraf");
            FaizHelper.HesaplaTaraf(myFoy);
            System.Diagnostics.Debug.WriteLine("HesaplaFoyTarafUzerine");
            HesaplaAlacakNedenUzerine(myFoy);
            FaizHelper.HesaplaFoyTarafUzerine(myFoy);
            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                myFoy.AV001_TI_BIL_FAIZCollection.AddRange(neden.AV001_TI_BIL_FAIZCollection);
            }
            //foreach (AV001_TI_BIL_BORCLU_ODEME odeme in myFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
            //{
            //    myFoy.AV001_TI_BIL_ODEME_DAGILIMCollection.AddRange(odeme.AV001_TI_BIL_ODEME_DAGILIMCollection);
            //}
            //ucOdemeDagilim1.MyDataSource = myFoy.AV001_TI_BIL_ODEME_DAGILIMCollection;

            //TODO:Db değişikliği sonrası devam edilecek 10dk [YY]
            if (AvukatProLib.Kimlikci.Kimlik.Bilgi != null && AvukatProLib.Kimlikci.Kimlik.Bilgi.CARI_ID.HasValue)
            {
                foreach (AV001_TDI_BIL_MASRAF_AVANS mAvans in myFoy.AV001_TDI_BIL_MASRAF_AVANSCollection)
                {
                    mAvans.CARI_ID = AvukatProLib.Kimlikci.Kimlik.Bilgi.CARI_ID.Value;
                }
            }

            System.Diagnostics.Debug.WriteLine("IcraToplamKalemleriHesapla");
            FaizHelper.IcraToplamKalemleriHesapla(myFoy);
            System.Diagnostics.Debug.WriteLine("IcraVekaletUcretiKatsayiHesapla");
            FaizHelper.IcraVekaletUcretiKatsayiHesapla(myFoy);
            System.Diagnostics.Debug.WriteLine("KalanHesapla");
            FaizHelper.KalanHesapla(myFoy);

            #endregion TakipSonrasi

            System.Diagnostics.Debug.WriteLine("HesaplaBakiyeHarciHesabaDahilmi");
            HesaplaBakiyeHarciHesabaDahilmi(myFoy);
            System.Diagnostics.Debug.WriteLine("HesaplaBakiyeHarciHesabaDahilmi");
            HesaplaMasrafAvanslar(myFoy);

            TaahhutKontrolGenel(myFoy);

            myFoy.AV001_TI_BIL_FERAGATCollection.Filter = string.Empty;
            myFoy.AV001_TI_BIL_BORCLU_ODEMECollection.Filter = string.Empty;

            DateTime bitir = DateTime.Now;
            TimeSpan fark = bitir - basla;
            Console.WriteLine("###################HESAP_SÜRESİ###########################");
            Console.WriteLine("{0}saat {0}dk {1}sn {2} ms", fark.Hours, fark.Minutes, fark.Seconds, fark.Milliseconds);
            Console.WriteLine("###################HESAP_SÜRESİ###########################");
        }

        public void IcraFoyHesaplaBW(int foyID)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerAsync(foyID);
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

        public AV001_TI_BIL_FOY IcraFoyHesaplaByID(int foyId, DateTime sonHesapTarihi)
        {
            AV001_TI_BIL_FOY mFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(foyId);
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(mFoy, true, DeepLoadType.IncludeChildren,
                    typeof(TList<AV001_TI_BIL_FOY_OZEL_KOD>),
                    typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                    typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>),
                    typeof(TList<AV001_TDI_BIL_GORUSME>),
                    typeof(TList<AV001_TI_BIL_BORCLU_ODEME>),
                    typeof(TList<AV001_TI_BIL_MAL_BEYANI>),
                    typeof(TList<AV001_TI_BIL_MAL_BEYAN_DETAY>),
                    typeof(TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>),
                    typeof(TList<AV001_TDI_BIL_TEBLIGAT>),
                    typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>),
                    typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>),
                    typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>),
                    typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>),
                    typeof(TList<AV001_TDIE_BIL_ASAMA>),
                    typeof(TList<AV001_TDIE_BIL_ASAMA_TARAF>),
                    typeof(TList<AV001_TDIE_BIL_ASAMA_SORUMLU>),
                    typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>),
                    typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ>),
                    typeof(TList<AV001_TI_BIL_KEFALET_BILGILERI>),
                    typeof(TList<AV001_TI_BIL_MUVEKKILE_ODEME>),
                    typeof(TList<AV001_TI_BIL_BORCLU_MAHSUP>),
                    typeof(TList<AV001_TI_BIL_FERAGAT>),
                    typeof(TList<AV001_TI_BIL_FOY_GENEL_NOT>),
                    typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>),
                    typeof(TList<AV001_TI_BIL_SATIS_MASTER>),
                    typeof(TList<AV001_TI_BIL_FOY_GELISME>),
                    typeof(TList<AV001_TI_BIL_DUSME_YENILEME>),
                    typeof(AV001_TI_KOD_HESAP_TIP),
                    typeof(TList<AV001_TI_BIL_HACIZ_MASTER>),
                    typeof(TList<AV001_TI_BIL_HACIZ_CHILD>),
                    typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>),
                    typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>),
                    typeof(TList<AV001_TDI_BIL_SOZLESME>),
                    typeof(TDIE_KOD_TARAF_SIFAT),
                    typeof(AV001_TDI_BIL_CARI)
             );

            foreach (AV001_TI_BIL_HACIZ_MASTER master in mFoy.AV001_TI_BIL_HACIZ_MASTERCollection)
            {
                foreach (AV001_TI_BIL_HACIZ_CHILD child in master.AV001_TI_BIL_HACIZ_CHILDCollection)
                {
                    DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepLoad(child, false, DeepLoadType.IncludeChildren,
                        typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>),
                        typeof(TList<AV001_TI_BIL_ISTIHKAK>),
                        typeof(TList<AV001_TI_BIL_HACIZ_ISTIRAK>));
                }
            }

            if (mFoy.AV001_TDI_BIL_TEBLIGATCollection.Count > 0)
                DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(mFoy.AV001_TDI_BIL_TEBLIGATCollection, false,
                    DeepLoadType.IncludeChildren,
                    typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>),
                    typeof(TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>));

            mFoy.SON_HESAP_TARIHI = sonHesapTarihi;

            IcraFoyHesapla(mFoy);
            return mFoy;
        }

        /// <summary>
        /// Föy ID sinden yola çıkarak hesaplama yapar ve geriye föy döndürür (gkn)
        /// </summary>
        /// <param name="foyId"></param>
        /// <returns></returns>
        public AV001_TI_BIL_FOY IcraFoyHesaplaByID(int foyId)
        {
            AV001_TI_BIL_FOY mFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(foyId);
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(mFoy, true, DeepLoadType.IncludeChildren,
                    typeof(TList<AV001_TI_BIL_FOY_OZEL_KOD>),
                    typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                    typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>),
                    typeof(TList<AV001_TDI_BIL_GORUSME>),
                    typeof(TList<AV001_TI_BIL_BORCLU_ODEME>),
                    typeof(TList<AV001_TI_BIL_MAL_BEYANI>),
                    typeof(TList<AV001_TI_BIL_MAL_BEYAN_DETAY>),
                    typeof(TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>),
                    typeof(TList<AV001_TDI_BIL_TEBLIGAT>),
                    typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>),
                    typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>),
                    typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>),
                    typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>),
                    typeof(TList<AV001_TDIE_BIL_ASAMA>),
                    typeof(TList<AV001_TDIE_BIL_ASAMA_TARAF>),
                    typeof(TList<AV001_TDIE_BIL_ASAMA_SORUMLU>),
                    typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>),
                    typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ>),
                    typeof(TList<AV001_TI_BIL_KEFALET_BILGILERI>),
                    typeof(TList<AV001_TI_BIL_MUVEKKILE_ODEME>),
                    typeof(TList<AV001_TI_BIL_BORCLU_MAHSUP>),
                    typeof(TList<AV001_TI_BIL_FERAGAT>),
                    typeof(TList<AV001_TI_BIL_FOY_GENEL_NOT>),
                    typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>),
                    typeof(TList<AV001_TI_BIL_SATIS_MASTER>),
                    typeof(TList<AV001_TI_BIL_FOY_GELISME>),
                    typeof(TList<AV001_TI_BIL_DUSME_YENILEME>),
                    typeof(AV001_TI_KOD_HESAP_TIP),
                    typeof(TList<AV001_TI_BIL_HACIZ_MASTER>),
                    typeof(TList<AV001_TI_BIL_HACIZ_CHILD>),
                    typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>),
                    typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>),
                    typeof(TList<AV001_TDI_BIL_SOZLESME>),
                    typeof(TDIE_KOD_TARAF_SIFAT),
                    typeof(AV001_TDI_BIL_CARI),
                    typeof(TList<AV001_TI_BIL_FAIZ>),
                    typeof(TList<AV001_TI_BIL_ILAM_MAHKEMESI>)
             );

            foreach (AV001_TI_BIL_HACIZ_MASTER master in mFoy.AV001_TI_BIL_HACIZ_MASTERCollection)
            {
                foreach (AV001_TI_BIL_HACIZ_CHILD child in master.AV001_TI_BIL_HACIZ_CHILDCollection)
                {
                    DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepLoad(child, false, DeepLoadType.IncludeChildren,
                        typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>),
                        typeof(TList<AV001_TI_BIL_ISTIHKAK>),
                        typeof(TList<AV001_TI_BIL_HACIZ_ISTIRAK>));
                }
            }

            DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(mFoy.AV001_TI_BIL_ALACAK_NEDENCollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));

            if (mFoy.AV001_TDI_BIL_TEBLIGATCollection.Count > 0)
                DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(mFoy.AV001_TDI_BIL_TEBLIGATCollection, false,
                    DeepLoadType.IncludeChildren,
                    typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>),
                    typeof(TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>));

            IcraFoyHesapla(mFoy);
            return mFoy;
        }

        public void IcraFoyHesaplaDeepload(AV001_TI_BIL_FOY foy)
        {
            IcraFoyDeepLoad(foy);

            IcraFoyHesapla(foy);
        }

        /// <summary>
        /// Föyle ilişkili föylerin hesaplama işlemlerini yapar, toplar ve kaynak föy üzerinde toplanmış bir şekilde döndürür (gkn)
        /// </summary>
        /// <param name="mFoy">Kaynak & Hedef Föy Farketmez</param>
        /// <returns>Kaynak Föy</returns>
        public AV001_TI_BIL_FOY IliskiliKayit(AV001_TI_BIL_FOY mFoy)
        {
            try
            {
                AV001_TDI_BIL_KAYIT_ILISKI iliski = DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByILISKI_TUR_IDKAYNAK_KAYIT_ID(601, mFoy.ID);
                if (iliski != null)
                {
                    TList<AV001_TI_BIL_FOY> liste = new TList<AV001_TI_BIL_FOY>();
                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.DeepLoad(iliski, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>), typeof(AV001_TI_BIL_FOY));
                    if (iliski.KAYNAK_ICRA_FOY_ID != null)
                    {
                        AV001_TI_BIL_FOY kaynakFoy = iliski.KAYNAK_ICRA_FOY_IDSource.Copy();

                        foreach (AV001_TDI_BIL_KAYIT_ILISKI_DETAY iliskiDetay in iliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection)
                        {
                            AV001_TI_BIL_FOY foy = IcraFoyHesaplaByID(iliskiDetay.HEDEF_ICRA_FOY_ID.Value);

                            FoyleriTopla(kaynakFoy, foy);
                        }
                        return kaynakFoy;
                    }
                }
                else
                {
                    TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> detay = DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_ICRA_FOY_ID(mFoy.ID);

                    if (detay.Count > 0)
                    {
                        AV001_TDI_BIL_KAYIT_ILISKI iliskiLi = DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByID(detay[0].KAYIT_ILISKI_ID);
                        if (iliskiLi != null)
                        {
                            if (iliskiLi.KAYNAK_ICRA_FOY_ID != null)
                            {
                                AV001_TI_BIL_FOY foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(iliskiLi.KAYNAK_ICRA_FOY_ID.Value);
                                if (foy != null)
                                {
                                    return IliskiliKayit(foy);
                                }
                            }
                        }
                    }
                }
            }
            catch 
            {
                return null;
            }
            return null;
        }

        public bool Kaydet(AV001_TI_BIL_FOY foy)
        {
            TransactionManager trans = new TransactionManager(Kimlikci.Kimlik.SirketBilgisi.ConStr);
            try
            {
                trans.BeginTransaction();

                DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(trans, foy);

                DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepSave(trans, foy.AV001_TI_BIL_FOY_TARAFCollection);

                DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.DeepSave(trans, foy.AV001_TI_BIL_FOY_TARAF_VEKILCollection);

                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(trans, foy.AV001_TI_BIL_ALACAK_NEDENCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>), typeof(TList<AV001_TI_BIL_FAIZ>));

                foreach (AV001_TI_BIL_ALACAK_NEDEN neden in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    #region//Alacak Neden Taraf

                    DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepSave(trans, neden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection);
                    #endregion

                    #region  //Kıymetli Evrak
                    neden.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK.
                       ForEach(
                       delegate(AV001_TDI_BIL_KIYMETLI_EVRAK obj)
                       {
                           if (
                               neden.AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAKCollection.FindAll(AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAKColumn.KIYMETLI_EVRAK_ID, obj.ID).Count == 0)
                           {
                               AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK ke =
                                   neden.AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAKCollection.AddNew();

                               ke.KIYMETLI_EVRAK_IDSource = obj;
                           }
                       }
                       );
                    #endregion

                    #region//Kıymetli Evrak Taraf
                    //foreach (AV001_TDI_BIL_KIYMETLI_EVRAK evk in neden.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK)
                    //{
                    //    DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFProvider.DeepSave(trans, evk.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection);

                    //}

                    #endregion

                    #region //GEMİUÇAKARAÇ
                    neden.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARAC.
                            ForEach(
                            delegate(AV001_TDI_BIL_GEMI_UCAK_ARAC obj)
                            {
                                if (
                                    neden.AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARACCollection.FindAll(
                                        AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARACColumn.GEMI_UCAK_ARAC_ID, obj.ID).Count == 0)
                                {
                                    AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARAC gua =
                                        neden.AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARACCollection.AddNew();
                                    obj.ICRA_FOY_ID = foy.ID;
                                    gua.GEMI_UCAK_ARAC_IDSource = obj;
                                }
                            });

                    #endregion

                    #region Gayrimenkul
                    neden.AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKUL.ForEach(
                      delegate(AV001_TI_BIL_GAYRIMENKUL obj)
                      {
                          if (
                              neden.AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKULCollection.FindAll(
                                  AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKULColumn.GAYRIMENKUL_ID, obj.ID).Count ==
                              0)
                          {
                              AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKUL gm =
                                  neden.AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKULCollection.AddNew();

                              gm.GAYRIMENKUL_IDSource = obj;
                          }
                      }
                      );
                    #endregion

                    #region Sozlesme
                    neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.ForEach(delegate(AV001_TDI_BIL_SOZLESME obj)
                    {
                        if (neden.AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEWCollection.FindAll(AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEWColumn.SOZLESME_ID, obj.ID).Count == 0)
                        {
                            AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW gua = neden.AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEWCollection.AddNew();
                            obj.ICRA_FOY_ID = foy.ID;
                            gua.SOZLESME_IDSource = obj;
                        }
                    });
                    #endregion
                }

                #region //BorcluOdeme

                foreach (AV001_TI_BIL_BORCLU_TAAHHUT_MASTER masterTaahhut in foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection)
                {
                    if (masterTaahhut.GECERLI_MI.HasValue ? masterTaahhut.GECERLI_MI.Value : false)
                    {
                        foreach (AV001_TI_BIL_BORCLU_ODEME odeme in foy.AV001_TI_BIL_BORCLU_ODEMECollection)
                        {
                            if (odeme.IsNew)
                            {
                                foreach (AV001_TI_BIL_BORCLU_TAAHHUT_CHILD child in masterTaahhut.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection)
                                {
                                    ParaVeDovizId odemeMiktari = new ParaVeDovizId(odeme.ODEME_MIKTAR, odeme.ODEME_MIKTAR_DOVIZ_ID);
                                    decimal kalan = decimal.Zero;

                                    while (kalan > 0)
                                    {
                                        if (child.TAAHHUT_MIKTARI > child.ODEME_MIKTARI)
                                        {
                                            decimal odenecek = child.TAAHHUT_MIKTARI - child.ODEME_MIKTARI;
                                            if (odemeMiktari.YtlHali > 0)
                                            {
                                                kalan = odemeMiktari.YtlHali - odenecek;

                                                if (kalan >= 0)
                                                {
                                                    child.ODEME_MIKTARI = odenecek;
                                                    child.ODEME_MIKTARI_DOVIZ_ID = 1;
                                                }
                                                else if (kalan < 0)
                                                {
                                                    child.ODEME_MIKTARI = odemeMiktari.YtlHali;
                                                    child.ODEME_MIKTARI_DOVIZ_ID = 1;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepSave(trans, foy.AV001_TI_BIL_BORCLU_ODEMECollection);

                #endregion

                #region //Ihtiyati Haciz
                DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.DeepSave(foy.AV001_TI_BIL_IHTIYATI_HACIZCollection);
                #endregion

                #region  //Ilam Bilgisi
                // DataRepository.AV001_TI_BIL_ILAM_MAHKEMESIProvider.DeepSave(foy.AV001_TI_BIL_ILAM_MAHKEMESICollection);
                #endregion

                #region İlkTebligatKayıt
                //İlk tebligat üretimi
                TList<TDIE_KOD_ASAMA_ILISKI> asama_ILISKIS =
                   DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI(foy.TableName);
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(asama_ILISKIS, false, DeepLoadType.IncludeChildren,
                                                                      typeof(TDIE_KOD_ASAMA_ALT),
                                                                      typeof(TDI_KOD_TEBLIGAT_KONU));

                foreach (string str in foy.ChangedProperties)
                {
                    TList<TDIE_KOD_ASAMA_ILISKI> iliskiS = asama_ILISKIS.FindAll(delegate(TDIE_KOD_ASAMA_ILISKI obj) { return obj.SUTUN_ADI.Contains(str); });
                    foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskiS)
                    {
                        if (iliski != null && iliski.TEBLIGAT_URETSIN_MI && iliski.TEBLIGAT_KONU_ID.HasValue && foy.FORM_TIP_ID.HasValue && iliski.AsamaDegerKarsilastir(foy))
                        {
                            AV001_TDI_BIL_TEBLIGAT tebl = foy.AV001_TDI_BIL_TEBLIGATCollection.Find(AV001_TDI_BIL_TEBLIGATColumn.KONU_ID, iliski.TEBLIGAT_KONU_ID.Value);
                            if (tebl != null)
                            {
                                foy.TebligatDoldur(tebl);
                                tebl.ACIKLAMA = iliski.AsamaAciklamaGetir(foy);
                                tebl.KONU_ID = iliski.TEBLIGAT_KONU_ID.Value;
                                //TODO: Yukarıdaki yer bugünü kurtarmak için yapılmış olup acilen değiştirilmesi gerekmektedir.
                                if (iliski.TEBLIGAT_KONU_IDSource.ILK_TEBLIGAT_MI)
                                {
                                    tebl.HAZIRLAMA_TARIH = foy.TAKIP_TARIHI.Value;
                                    tebl.POSTALANMA_TARIH = foy.TAKIP_TARIHI.Value;
                                    tebl.HAZIRLAYAN_ID = Kimlikci.Kimlik.Bilgi.CARI_ID.Value;
                                    //tebl.KAYIT_TARIHI = DataTime.Now;
                                    tebl.KONTROL_NE_ZAMAN = DateTime.Now;
                                    tebl.KONTROL_VERSIYON++;
                                    tebl.ICRA_ILK_TEBLIGAT_MI = true;
                                    tebl.ANA_TUR_ID = iliski.TEBLIGAT_KONU_IDSource.ANA_TUR_ID;
                                    tebl.ALT_TUR_ID = iliski.TEBLIGAT_KONU_IDSource.ALT_TUR_ID;
                                    tebl.MUHASEBE_ALT_KATEGORI_ID = 1;
                                    tebl.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Clear();
                                    tebl.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Clear();
                                }
                                foreach (AV001_TI_BIL_FOY_TARAF taraf in foy.AV001_TI_BIL_FOY_TARAFCollection)
                                {
                                    if (!taraf.TAKIP_EDEN_MI) //Takip edilenler.//TODO:DÜZELT BURAYI
                                    {
                                        AV001_TDI_BIL_TEBLIGAT_MUHATAP mhtp =
                                            tebl.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddNew();
                                        mhtp.TEBLIGAT_HEDEF_TIP = 1;
                                        mhtp.ALAN_CARI_ID = taraf.CARI_ID;
                                        mhtp.MUHATAP_CARI_ID = taraf.CARI_ID.Value;
                                        mhtp.MUHATAP_TARAF_KOD = taraf.TARAF_KODU;
                                        mhtp.MUHASEBE_ALT_KATEGORI_ID =
                                            (int)AvukatProLib.Extras.MuhasebeAltKategoriId.iLK_TEBLiGAT_GiDERi;
                                        mhtp.EVRAK_TARIHI = DateTime.Today;
                                        mhtp.EVRAK_NO = DateTime.Today.Year + "/" + DateTime.Now.Millisecond;
                                        mhtp.KLASOR_KODU = Kimlikci.Kimlik.CurrentKlasorKodu;
                                        mhtp.KONTROL_KIM = Kimlikci.Kimlik.KullaniciAdi;
                                        mhtp.KONTROL_VERSIYON = Kimlikci.Kimlik.DefaultKontrolVersiyon;
                                        mhtp.STAMP = Kimlikci.Kimlik.DefaultStamp;
                                        //TODO: Sıralı kayıt
                                        //mhtp.TEBLIGAT_ADRESI = taraf.CARI_IDSource. //KALDI:aktiff adres
                                    }

                                    else if (taraf.TAKIP_EDEN_MI) //TakipEdenler//TODO:DÜZELT BURAYI
                                    {
                                        AV001_TDI_BIL_TEBLIGAT_YAPAN ypn =
                                            tebl.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddNew();
                                        ypn.YAPAN_CARI_ID = taraf.CARI_ID.Value;
                                        ypn.TARAF_KOD = ((TarafKodu)taraf.TARAF_KODU).ToString()[0].ToString();
                                    }
                                }
                            }

                            else
                            {
                                tebl = foy.TebligatGetir();
                                tebl.ACIKLAMA = iliski.AsamaAciklamaGetir(foy);
                                tebl.KONU_ID = iliski.TEBLIGAT_KONU_ID.Value;
                                tebl.HAZIRLAYAN_ID = Kimlikci.Kimlik.Bilgi.CARI_ID.Value;
                                tebl.TEBLIGAT_REFERANS_NO = TebligatReferansNoOlustur();

                                //TODO: Yukarıdaki yer bugünü kurtarmak için yapılmış olup acilen değiştirilmesi gerekmektedir.

                                if (iliski.TEBLIGAT_KONU_IDSource.ILK_TEBLIGAT_MI)
                                {
                                    tebl.HAZIRLAMA_TARIH = foy.TAKIP_TARIHI.Value;
                                    tebl.POSTALANMA_TARIH = foy.TAKIP_TARIHI.Value;
                                    tebl.ANA_TUR_ID = iliski.TEBLIGAT_KONU_IDSource.ANA_TUR_ID;
                                    tebl.ICRA_ILK_TEBLIGAT_MI = true;
                                    tebl.ALT_TUR_ID = iliski.TEBLIGAT_KONU_IDSource.ALT_TUR_ID;
                                    tebl.MUHASEBE_ALT_KATEGORI_ID = (int)AvukatProLib.Extras.MuhasebeAltKategoriId.iLK_TEBLiGAT_GiDERi; ;
                                    //tebl.KAYIT_TARIHI = DataTime.Now;
                                    tebl.KONTROL_NE_ZAMAN = DateTime.Now;
                                    tebl.KONTROL_VERSIYON++;
                                    tebl.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Clear();
                                    tebl.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Clear();
                                    foreach (AV001_TI_BIL_FOY_TARAF taraf in foy.AV001_TI_BIL_FOY_TARAFCollection)
                                    {
                                        if (!taraf.TAKIP_EDEN_MI) //Takip edilenler.//TODO:DÜZELT BURAYI
                                        {
                                            AV001_TDI_BIL_TEBLIGAT_MUHATAP mhtp =
                                                tebl.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddNew();
                                            mhtp.TEBLIGAT_HEDEF_TIP = 1;
                                            mhtp.ALAN_CARI_ID = taraf.CARI_ID;
                                            mhtp.MUHATAP_CARI_ID = taraf.CARI_ID.Value;
                                            mhtp.MUHATAP_TARAF_KOD = taraf.TARAF_KODU;
                                            mhtp.MUHASEBE_ALT_KATEGORI_ID =
                                                (int)AvukatProLib.Extras.MuhasebeAltKategoriId.iLK_TEBLiGAT_GiDERi;
                                            mhtp.EVRAK_TARIHI = DateTime.Today;
                                            mhtp.EVRAK_NO = DateTime.Today.Year + "/" + DateTime.Now.Millisecond;
                                            mhtp.KLASOR_KODU = Kimlikci.Kimlik.CurrentKlasorKodu;
                                            mhtp.KONTROL_KIM = Kimlikci.Kimlik.KullaniciAdi;
                                            mhtp.KONTROL_VERSIYON = Kimlikci.Kimlik.DefaultKontrolVersiyon;
                                            mhtp.STAMP = Kimlikci.Kimlik.DefaultStamp;
                                            //TODO: Sıralı kayıt
                                            //mhtp.TEBLIGAT_ADRESI = taraf.CARI_IDSource. //KALDI:aktiff adres
                                        }
                                        else //TODO:TakipEdenler
                                        {
                                            AV001_TDI_BIL_TEBLIGAT_YAPAN ypn =
                                                tebl.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddNew();
                                            ypn.YAPAN_CARI_ID = taraf.CARI_ID.Value;
                                            ypn.TARAF_KOD = ((TarafKodu)taraf.TARAF_KODU).ToString()[0].ToString();
                                        }
                                    }
                                }
                                foy.AV001_TDI_BIL_TEBLIGATCollection.Add(tebl);
                            }
                        }
                    }
                }

                DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(trans, foy.AV001_TDI_BIL_TEBLIGATCollection,
                    DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>),
                                                  typeof(TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>));
                #endregion

                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(trans, foy.AV001_TI_BIL_ALACAK_NEDENCollection);
                trans.Commit();

                if (foy.AV001_TI_BIL_FOY_TARAFCollection != null)
                    foreach (var item in foy.AV001_TI_BIL_FOY_TARAFCollection)
                    {
                        if (item.TAKIP_EDEN_MI && item.TARAF_KODU == (int)TarafKodu.Muvekkil)
                            MuhasebeAraclari.SetCariHesapByFoy(foy);
                    }

                return true;
            }

            catch 
            {
                if (trans.IsOpen)
                    trans.Rollback();

                return false;
            }
        }

        public void TaraflariToplaLimited(List<AV001_TI_BIL_FOY_TARAF> tarafListesi, AV001_TI_BIL_FOY_TARAF asilTaraf, DateTime? tarih)
        {
            AV001_TI_BIL_FOY_TARAF araTaraf = new AV001_TI_BIL_FOY_TARAF();

            DateTime zaman = DateTime.Now;

            if (tarih != null)
                zaman = tarih.Value;

            #region Dictonory Oluşturuldu
            Dictionary<string, List<ParaVeDovizId>> paralarinSozlugu = new Dictionary<string, List<ParaVeDovizId>>();

            paralarinSozlugu.Add("BASVURMA_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("BIRIKMIS_NAFAKA", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("CEK_KOMISYONU", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("DAMGA_PULU", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("DAVA_GIDERLERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("DAVA_INKAR_TAZMINATI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("DAVA_VEKALET_UCRETI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("DIGER_GIDERLER", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("DIGER_HARC", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("FERAGAT_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("FERAGAT_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("HARC_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ICRA_INKAR_TAZMINATI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IFLAS_BASVURMA_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IFLASIN_ACILMASI_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IH_VEKALET_UCRETI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IHTAR_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILAM_BK_YARG_ONAMA", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILAM_INKAR_TAZMINATI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILAM_TEBLIG_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILAM_UCRETLER_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILAM_VEK_UCR", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILAM_YARGILAMA_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILK_GIDERLER", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILK_TEBLIGAT_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IT_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IT_HACIZDE_ODENEN", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IT_VEKALET_UCRETI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("KALAN", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("KARSI_VEKALET_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("KARSILIK_TUTARI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("KARSILIKSIZ_CEK_TAZMINATI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("MAHSUP_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("MASAYA_KATILMA_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ODEME_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ODENEN_TAHSIL_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("PAYLASMA_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("PESIN_HARC", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("PROTESTO_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TAHLIYE_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TAHLIYE_VEK_UCR", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TAKIP_VEKALET_UCRETI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TD_BAKIYE_HARC", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TD_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TD_TEBLIG_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TD_VEK_UCR", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TESLIM_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TO_MASRAF_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TO_ODEME_MAHSUP_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TO_ODEME_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TO_VEKALET_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TO_YONETIMG_TAZMINATI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TS_MASRAF_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TS_VEKALET_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TUM_MASRAF_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TUM_VEKALET_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("VEKALET_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("VEKALET_PULU", new List<ParaVeDovizId>());

            #endregion

            foreach (AV001_TI_BIL_FOY_TARAF taraf in tarafListesi)
            {
                #region İlgili Alanlara Değerler Ekleniyor
                paralarinSozlugu["BASVURMA_HARCI"].Add(new ParaVeDovizId(taraf.BASVURMA_HARCI, taraf.BASVURMA_HARCI_DOVIZ_ID));
                paralarinSozlugu["BIRIKMIS_NAFAKA"].Add(new ParaVeDovizId(taraf.BIRIKMIS_NAFAKA, taraf.BIRIKMIS_NAFAKA_DOVIZ_ID));
                paralarinSozlugu["CEK_KOMISYONU"].Add(new ParaVeDovizId(taraf.CEK_KOMISYONU, taraf.CEK_KOMISYONU_DOVIZ_ID));
                paralarinSozlugu["DAMGA_PULU"].Add(new ParaVeDovizId(taraf.DAMGA_PULU, taraf.DAMGA_PULU_DOVIZ_ID));
                paralarinSozlugu["DAVA_GIDERLERI"].Add(new ParaVeDovizId(taraf.DAVA_GIDERLERI, taraf.DAVA_GIDERLERI_DOVIZ_ID));
                paralarinSozlugu["DAVA_INKAR_TAZMINATI"].Add(new ParaVeDovizId(taraf.DAVA_INKAR_TAZMINATI, taraf.DAVA_INKAR_TAZMINATI_DOVIZ_ID));
                paralarinSozlugu["DAVA_VEKALET_UCRETI"].Add(new ParaVeDovizId(taraf.DAVA_VEKALET_UCRETI, taraf.DAVA_VEKALET_UCRETI_DOVIZ_ID));
                paralarinSozlugu["DIGER_GIDERLER"].Add(new ParaVeDovizId(taraf.DIGER_GIDERLER, taraf.DIGER_GIDERLER_DOVIZ_ID));
                paralarinSozlugu["DIGER_HARC"].Add(new ParaVeDovizId(taraf.DIGER_HARC, taraf.DIGER_HARC_DOVIZ_ID));
                paralarinSozlugu["FERAGAT_HARCI"].Add(new ParaVeDovizId(taraf.FERAGAT_HARCI, taraf.FERAGAT_HARCI_DOVIZ_ID));
                paralarinSozlugu["FERAGAT_TOPLAMI"].Add(new ParaVeDovizId(taraf.FERAGAT_TOPLAMI, taraf.FERAGAT_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["HARC_TOPLAMI"].Add(new ParaVeDovizId(taraf.HARC_TOPLAMI, taraf.HARC_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["ICRA_INKAR_TAZMINATI"].Add(new ParaVeDovizId(taraf.ICRA_INKAR_TAZMINATI, taraf.ICRA_INKAR_TAZMINATI_DOVIZ_ID));
                paralarinSozlugu["IFLAS_BASVURMA_HARCI"].Add(new ParaVeDovizId(taraf.IFLAS_BASVURMA_HARCI, taraf.IFLAS_BASVURMA_HARCI_DOVIZ_ID));
                paralarinSozlugu["IFLASIN_ACILMASI_HARCI"].Add(new ParaVeDovizId(taraf.IFLASIN_ACILMASI_HARCI, taraf.IFLASIN_ACILMASI_HARCI_DOVIZ_ID));
                paralarinSozlugu["IH_VEKALET_UCRETI"].Add(new ParaVeDovizId(taraf.IH_VEKALET_UCRETI, taraf.IH_VEKALET_UCRETI_DOVIZ_ID));
                paralarinSozlugu["IHTAR_GIDERI"].Add(new ParaVeDovizId(taraf.IHTAR_GIDERI, taraf.IHTAR_GIDERI_DOVIZ_ID));
                paralarinSozlugu["ILAM_BK_YARG_ONAMA"].Add(new ParaVeDovizId(taraf.ILAM_BK_YARG_ONAMA, taraf.ILAM_BK_YARG_ONAMA_DOVIZ_ID));
                paralarinSozlugu["ILAM_INKAR_TAZMINATI"].Add(new ParaVeDovizId(taraf.ILAM_INKAR_TAZMINATI, taraf.ILAM_INKAR_TAZMINATI_DOVIZ_ID));
                paralarinSozlugu["ILAM_TEBLIG_GIDERI"].Add(new ParaVeDovizId(taraf.ILAM_TEBLIG_GIDERI, taraf.ILAM_TEBLIG_GIDERI_DOVIZ_ID));
                paralarinSozlugu["ILAM_UCRETLER_TOPLAMI"].Add(new ParaVeDovizId(taraf.ILAM_UCRETLER_TOPLAMI, taraf.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["ILAM_VEK_UCR"].Add(new ParaVeDovizId(taraf.ILAM_VEK_UCR, taraf.ILAM_VEK_UCR_DOVIZ_ID));
                paralarinSozlugu["ILAM_YARGILAMA_GIDERI"].Add(new ParaVeDovizId(taraf.ILAM_YARGILAMA_GIDERI, taraf.ILAM_YARGILAMA_GIDERI_DOVIZ_ID));
                paralarinSozlugu["ILK_GIDERLER"].Add(new ParaVeDovizId(taraf.ILK_GIDERLER, taraf.ILK_GIDERLER_DOVIZ_ID));
                paralarinSozlugu["ILK_TEBLIGAT_GIDERI"].Add(new ParaVeDovizId(taraf.ILK_TEBLIGAT_GIDERI, taraf.ILK_TEBLIGAT_GIDERI_DOVIZ_ID));
                paralarinSozlugu["IT_GIDERI"].Add(new ParaVeDovizId(taraf.IT_GIDERI, taraf.IT_GIDERI_DOVIZ_ID));
                paralarinSozlugu["IT_HACIZDE_ODENEN"].Add(new ParaVeDovizId(taraf.IT_HACIZDE_ODENEN, taraf.IT_HACIZDE_ODENEN_DOVIZ_ID));
                paralarinSozlugu["IT_VEKALET_UCRETI"].Add(new ParaVeDovizId(taraf.IT_VEKALET_UCRETI, taraf.IT_VEKALET_UCRETI_DOVIZ_ID));
                paralarinSozlugu["KALAN"].Add(new ParaVeDovizId(taraf.KALAN, taraf.KALAN_DOVIZ_ID));
                paralarinSozlugu["KARSI_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(taraf.KARSI_VEKALET_TOPLAMI, taraf.KARSI_VEKALET_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["KARSILIK_TUTARI"].Add(new ParaVeDovizId(taraf.KARSILIK_TUTARI, taraf.KARSILIK_TUTARI_DOVIZ_ID));
                paralarinSozlugu["KARSILIKSIZ_CEK_TAZMINATI"].Add(new ParaVeDovizId(taraf.KARSILIKSIZ_CEK_TAZMINATI, taraf.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID));
                paralarinSozlugu["MAHSUP_TOPLAMI"].Add(new ParaVeDovizId(taraf.MAHSUP_TOPLAMI, taraf.MAHSUP_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["MASAYA_KATILMA_HARCI"].Add(new ParaVeDovizId(taraf.MASAYA_KATILMA_HARCI, taraf.MASAYA_KATILMA_HARCI_DOVIZ_ID));
                paralarinSozlugu["ODEME_TOPLAMI"].Add(new ParaVeDovizId(taraf.ODEME_TOPLAMI, taraf.ODEME_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["ODENEN_TAHSIL_HARCI"].Add(new ParaVeDovizId(taraf.ODENEN_TAHSIL_HARCI, taraf.ODENEN_TAHSIL_HARCI_DOVIZ_ID));
                paralarinSozlugu["PAYLASMA_HARCI"].Add(new ParaVeDovizId(taraf.PAYLASMA_HARCI, taraf.PAYLASMA_HARCI_DOVIZ_ID));
                paralarinSozlugu["PESIN_HARC"].Add(new ParaVeDovizId(taraf.PESIN_HARC, taraf.PESIN_HARC_DOVIZ_ID));
                paralarinSozlugu["PROTESTO_GIDERI"].Add(new ParaVeDovizId(taraf.PROTESTO_GIDERI, taraf.PROTESTO_GIDERI_DOVIZ_ID));
                paralarinSozlugu["TAHLIYE_HARCI"].Add(new ParaVeDovizId(taraf.TAHLIYE_HARCI, taraf.TAHLIYE_HARCI_DOVIZ_ID));
                paralarinSozlugu["TAHLIYE_VEK_UCR"].Add(new ParaVeDovizId(taraf.TAHLIYE_VEK_UCR, taraf.TAHLIYE_VEK_UCR_DOVIZ_ID));
                paralarinSozlugu["TAKIP_VEKALET_UCRETI"].Add(new ParaVeDovizId(taraf.TAKIP_VEKALET_UCRETI, taraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID));
                paralarinSozlugu["TD_BAKIYE_HARC"].Add(new ParaVeDovizId(taraf.TD_BAKIYE_HARC, taraf.TD_BAKIYE_HARC_DOVIZ_ID));
                paralarinSozlugu["TD_GIDERI"].Add(new ParaVeDovizId(taraf.TD_GIDERI, taraf.TD_GIDERI_DOVIZ_ID));
                paralarinSozlugu["TD_TEBLIG_GIDERI"].Add(new ParaVeDovizId(taraf.TD_TEBLIG_GIDERI, taraf.TD_TEBLIG_GIDERI_DOVIZ_ID));
                paralarinSozlugu["TD_VEK_UCR"].Add(new ParaVeDovizId(taraf.TD_VEK_UCR, taraf.TD_VEK_UCR_DOVIZ_ID));
                paralarinSozlugu["TESLIM_HARCI"].Add(new ParaVeDovizId(taraf.TESLIM_HARCI, taraf.TESLIM_HARCI_DOVIZ_ID));
                paralarinSozlugu["TO_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(taraf.TO_MASRAF_TOPLAMI, taraf.TO_MASRAF_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TO_ODEME_MAHSUP_TOPLAMI"].Add(new ParaVeDovizId(taraf.TO_ODEME_MAHSUP_TOPLAMI, taraf.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TO_ODEME_TOPLAMI"].Add(new ParaVeDovizId(taraf.TO_ODEME_TOPLAMI, taraf.TO_ODEME_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TO_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(taraf.TO_VEKALET_TOPLAMI, taraf.TO_VEKALET_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TO_YONETIMG_TAZMINATI"].Add(new ParaVeDovizId(taraf.TO_YONETIMG_TAZMINATI, taraf.TO_YONETIMG_TAZMINATI_DOVIZ_ID));
                paralarinSozlugu["TS_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(taraf.TS_MASRAF_TOPLAMI, taraf.TS_MASRAF_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TS_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(taraf.TS_VEKALET_TOPLAMI, taraf.TS_VEKALET_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TUM_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(taraf.TUM_MASRAF_TOPLAMI, taraf.TUM_MASRAF_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TUM_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(taraf.TUM_VEKALET_TOPLAMI, taraf.TUM_VEKALET_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["VEKALET_HARCI"].Add(new ParaVeDovizId(taraf.VEKALET_HARCI, taraf.VEKALET_HARCI_DOVIZ_ID));
                paralarinSozlugu["VEKALET_PULU"].Add(new ParaVeDovizId(taraf.VEKALET_PULU, taraf.VEKALET_PULU_DOVIZ_ID));

                #endregion
            }

            #region Ara Föye Değerler Atanıyor

            ParaVeDovizId sonucBASVURMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["BASVURMA_HARCI"], zaman); araTaraf.BASVURMA_HARCI = sonucBASVURMA_HARCI.Para; araTaraf.BASVURMA_HARCI_DOVIZ_ID = sonucBASVURMA_HARCI.DovizId;
            ParaVeDovizId sonucBIRIKMIS_NAFAKA = FaizHelper.ParalariTopla(paralarinSozlugu["BIRIKMIS_NAFAKA"], zaman); araTaraf.BIRIKMIS_NAFAKA = sonucBIRIKMIS_NAFAKA.Para; araTaraf.BIRIKMIS_NAFAKA_DOVIZ_ID = sonucBIRIKMIS_NAFAKA.DovizId;
            ParaVeDovizId sonucCEK_KOMISYONU = FaizHelper.ParalariTopla(paralarinSozlugu["CEK_KOMISYONU"], zaman); araTaraf.CEK_KOMISYONU = sonucCEK_KOMISYONU.Para; araTaraf.CEK_KOMISYONU_DOVIZ_ID = sonucCEK_KOMISYONU.DovizId;
            ParaVeDovizId sonucDAMGA_PULU = FaizHelper.ParalariTopla(paralarinSozlugu["DAMGA_PULU"], zaman); araTaraf.DAMGA_PULU = sonucDAMGA_PULU.Para; araTaraf.DAMGA_PULU_DOVIZ_ID = sonucDAMGA_PULU.DovizId;
            ParaVeDovizId sonucDAVA_GIDERLERI = FaizHelper.ParalariTopla(paralarinSozlugu["DAVA_GIDERLERI"], zaman); araTaraf.DAVA_GIDERLERI = sonucDAVA_GIDERLERI.Para; araTaraf.DAVA_GIDERLERI_DOVIZ_ID = sonucDAVA_GIDERLERI.DovizId;
            ParaVeDovizId sonucDAVA_INKAR_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["DAVA_INKAR_TAZMINATI"], zaman); araTaraf.DAVA_INKAR_TAZMINATI = sonucDAVA_INKAR_TAZMINATI.Para; araTaraf.DAVA_INKAR_TAZMINATI_DOVIZ_ID = sonucDAVA_INKAR_TAZMINATI.DovizId;
            ParaVeDovizId sonucDAVA_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["DAVA_VEKALET_UCRETI"], zaman); araTaraf.DAVA_VEKALET_UCRETI = sonucDAVA_VEKALET_UCRETI.Para; araTaraf.DAVA_VEKALET_UCRETI_DOVIZ_ID = sonucDAVA_VEKALET_UCRETI.DovizId;
            ParaVeDovizId sonucDIGER_GIDERLER = FaizHelper.ParalariTopla(paralarinSozlugu["DIGER_GIDERLER"], zaman); araTaraf.DIGER_GIDERLER = sonucDIGER_GIDERLER.Para; araTaraf.DIGER_GIDERLER_DOVIZ_ID = sonucDIGER_GIDERLER.DovizId;
            ParaVeDovizId sonucDIGER_HARC = FaizHelper.ParalariTopla(paralarinSozlugu["DIGER_HARC"], zaman); araTaraf.DIGER_HARC = sonucDIGER_HARC.Para; araTaraf.DIGER_HARC_DOVIZ_ID = sonucDIGER_HARC.DovizId;
            ParaVeDovizId sonucFERAGAT_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["FERAGAT_HARCI"], zaman); araTaraf.FERAGAT_HARCI = sonucFERAGAT_HARCI.Para; araTaraf.FERAGAT_HARCI_DOVIZ_ID = sonucFERAGAT_HARCI.DovizId;
            ParaVeDovizId sonucFERAGAT_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["FERAGAT_TOPLAMI"], zaman); araTaraf.FERAGAT_TOPLAMI = sonucFERAGAT_TOPLAMI.Para; araTaraf.FERAGAT_TOPLAMI_DOVIZ_ID = sonucFERAGAT_TOPLAMI.DovizId;
            ParaVeDovizId sonucHARC_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["HARC_TOPLAMI"], zaman); araTaraf.HARC_TOPLAMI = sonucHARC_TOPLAMI.Para; araTaraf.HARC_TOPLAMI_DOVIZ_ID = sonucHARC_TOPLAMI.DovizId;
            ParaVeDovizId sonucICRA_INKAR_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["ICRA_INKAR_TAZMINATI"], zaman); araTaraf.ICRA_INKAR_TAZMINATI = sonucICRA_INKAR_TAZMINATI.Para; araTaraf.ICRA_INKAR_TAZMINATI_DOVIZ_ID = sonucICRA_INKAR_TAZMINATI.DovizId;
            ParaVeDovizId sonucIFLAS_BASVURMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["IFLAS_BASVURMA_HARCI"], zaman); araTaraf.IFLAS_BASVURMA_HARCI = sonucIFLAS_BASVURMA_HARCI.Para; araTaraf.IFLAS_BASVURMA_HARCI_DOVIZ_ID = sonucIFLAS_BASVURMA_HARCI.DovizId;
            ParaVeDovizId sonucIFLASIN_ACILMASI_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["IFLASIN_ACILMASI_HARCI"], zaman); araTaraf.IFLASIN_ACILMASI_HARCI = sonucIFLASIN_ACILMASI_HARCI.Para; araTaraf.IFLASIN_ACILMASI_HARCI_DOVIZ_ID = sonucIFLASIN_ACILMASI_HARCI.DovizId;
            ParaVeDovizId sonucIH_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["IH_VEKALET_UCRETI"], zaman); araTaraf.IH_VEKALET_UCRETI = sonucIH_VEKALET_UCRETI.Para; araTaraf.IH_VEKALET_UCRETI_DOVIZ_ID = sonucIH_VEKALET_UCRETI.DovizId;
            ParaVeDovizId sonucIHTAR_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["IHTAR_GIDERI"], zaman); araTaraf.IHTAR_GIDERI = sonucIHTAR_GIDERI.Para; araTaraf.IHTAR_GIDERI_DOVIZ_ID = sonucIHTAR_GIDERI.DovizId;
            ParaVeDovizId sonucILAM_BK_YARG_ONAMA = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_BK_YARG_ONAMA"], zaman); araTaraf.ILAM_BK_YARG_ONAMA = sonucILAM_BK_YARG_ONAMA.Para; araTaraf.ILAM_BK_YARG_ONAMA_DOVIZ_ID = sonucILAM_BK_YARG_ONAMA.DovizId;
            ParaVeDovizId sonucILAM_INKAR_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_INKAR_TAZMINATI"], zaman); araTaraf.ILAM_INKAR_TAZMINATI = sonucILAM_INKAR_TAZMINATI.Para; araTaraf.ILAM_INKAR_TAZMINATI_DOVIZ_ID = sonucILAM_INKAR_TAZMINATI.DovizId;
            ParaVeDovizId sonucILAM_TEBLIG_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_TEBLIG_GIDERI"], zaman); araTaraf.ILAM_TEBLIG_GIDERI = sonucILAM_TEBLIG_GIDERI.Para; araTaraf.ILAM_TEBLIG_GIDERI_DOVIZ_ID = sonucILAM_TEBLIG_GIDERI.DovizId;
            ParaVeDovizId sonucILAM_UCRETLER_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_UCRETLER_TOPLAMI"], zaman); araTaraf.ILAM_UCRETLER_TOPLAMI = sonucILAM_UCRETLER_TOPLAMI.Para; araTaraf.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID = sonucILAM_UCRETLER_TOPLAMI.DovizId;
            ParaVeDovizId sonucILAM_VEK_UCR = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_VEK_UCR"], zaman); araTaraf.ILAM_VEK_UCR = sonucILAM_VEK_UCR.Para; araTaraf.ILAM_VEK_UCR_DOVIZ_ID = sonucILAM_VEK_UCR.DovizId;
            ParaVeDovizId sonucILAM_YARGILAMA_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_YARGILAMA_GIDERI"], zaman); araTaraf.ILAM_YARGILAMA_GIDERI = sonucILAM_YARGILAMA_GIDERI.Para; araTaraf.ILAM_YARGILAMA_GIDERI_DOVIZ_ID = sonucILAM_YARGILAMA_GIDERI.DovizId;
            ParaVeDovizId sonucILK_GIDERLER = FaizHelper.ParalariTopla(paralarinSozlugu["ILK_GIDERLER"], zaman); araTaraf.ILK_GIDERLER = sonucILK_GIDERLER.Para; araTaraf.ILK_GIDERLER_DOVIZ_ID = sonucILK_GIDERLER.DovizId;
            ParaVeDovizId sonucILK_TEBLIGAT_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["ILK_TEBLIGAT_GIDERI"], zaman); araTaraf.ILK_TEBLIGAT_GIDERI = sonucILK_TEBLIGAT_GIDERI.Para; araTaraf.ILK_TEBLIGAT_GIDERI_DOVIZ_ID = sonucILK_TEBLIGAT_GIDERI.DovizId;
            ParaVeDovizId sonucIT_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["IT_GIDERI"], zaman); araTaraf.IT_GIDERI = sonucIT_GIDERI.Para; araTaraf.IT_GIDERI_DOVIZ_ID = sonucIT_GIDERI.DovizId;
            ParaVeDovizId sonucIT_HACIZDE_ODENEN = FaizHelper.ParalariTopla(paralarinSozlugu["IT_HACIZDE_ODENEN"], zaman); araTaraf.IT_HACIZDE_ODENEN = sonucIT_HACIZDE_ODENEN.Para; araTaraf.IT_HACIZDE_ODENEN_DOVIZ_ID = sonucIT_HACIZDE_ODENEN.DovizId;
            ParaVeDovizId sonucIT_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["IT_VEKALET_UCRETI"], zaman); araTaraf.IT_VEKALET_UCRETI = sonucIT_VEKALET_UCRETI.Para; araTaraf.IT_VEKALET_UCRETI_DOVIZ_ID = sonucIT_VEKALET_UCRETI.DovizId;
            ParaVeDovizId sonucKALAN = FaizHelper.ParalariTopla(paralarinSozlugu["KALAN"], zaman); araTaraf.KALAN = sonucKALAN.Para; araTaraf.KALAN_DOVIZ_ID = sonucKALAN.DovizId;
            ParaVeDovizId sonucKARSI_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["KARSI_VEKALET_TOPLAMI"], zaman); araTaraf.KARSI_VEKALET_TOPLAMI = sonucKARSI_VEKALET_TOPLAMI.Para; araTaraf.KARSI_VEKALET_TOPLAMI_DOVIZ_ID = sonucKARSI_VEKALET_TOPLAMI.DovizId;
            ParaVeDovizId sonucKARSILIK_TUTARI = FaizHelper.ParalariTopla(paralarinSozlugu["KARSILIK_TUTARI"], zaman); araTaraf.KARSILIK_TUTARI = sonucKARSILIK_TUTARI.Para; araTaraf.KARSILIK_TUTARI_DOVIZ_ID = sonucKARSILIK_TUTARI.DovizId;
            ParaVeDovizId sonucKARSILIKSIZ_CEK_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["KARSILIKSIZ_CEK_TAZMINATI"], zaman); araTaraf.KARSILIKSIZ_CEK_TAZMINATI = sonucKARSILIKSIZ_CEK_TAZMINATI.Para; araTaraf.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = sonucKARSILIKSIZ_CEK_TAZMINATI.DovizId;
            ParaVeDovizId sonucMAHSUP_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["MAHSUP_TOPLAMI"], zaman); araTaraf.MAHSUP_TOPLAMI = sonucMAHSUP_TOPLAMI.Para; araTaraf.MAHSUP_TOPLAMI_DOVIZ_ID = sonucMAHSUP_TOPLAMI.DovizId;
            ParaVeDovizId sonucMASAYA_KATILMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["MASAYA_KATILMA_HARCI"], zaman); araTaraf.MASAYA_KATILMA_HARCI = sonucMASAYA_KATILMA_HARCI.Para; araTaraf.MASAYA_KATILMA_HARCI_DOVIZ_ID = sonucMASAYA_KATILMA_HARCI.DovizId;
            ParaVeDovizId sonucODEME_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["ODEME_TOPLAMI"], zaman); araTaraf.ODEME_TOPLAMI = sonucODEME_TOPLAMI.Para; araTaraf.ODEME_TOPLAMI_DOVIZ_ID = sonucODEME_TOPLAMI.DovizId;
            ParaVeDovizId sonucODENEN_TAHSIL_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["ODENEN_TAHSIL_HARCI"], zaman); araTaraf.ODENEN_TAHSIL_HARCI = sonucODENEN_TAHSIL_HARCI.Para; araTaraf.ODENEN_TAHSIL_HARCI_DOVIZ_ID = sonucODENEN_TAHSIL_HARCI.DovizId;
            ParaVeDovizId sonucPAYLASMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["PAYLASMA_HARCI"], zaman); araTaraf.PAYLASMA_HARCI = sonucPAYLASMA_HARCI.Para; araTaraf.PAYLASMA_HARCI_DOVIZ_ID = sonucPAYLASMA_HARCI.DovizId;
            ParaVeDovizId sonucPESIN_HARC = FaizHelper.ParalariTopla(paralarinSozlugu["PESIN_HARC"], zaman); araTaraf.PESIN_HARC = sonucPESIN_HARC.Para; araTaraf.PESIN_HARC_DOVIZ_ID = sonucPESIN_HARC.DovizId;
            ParaVeDovizId sonucPROTESTO_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["PROTESTO_GIDERI"], zaman); araTaraf.PROTESTO_GIDERI = sonucPROTESTO_GIDERI.Para; araTaraf.PROTESTO_GIDERI_DOVIZ_ID = sonucPROTESTO_GIDERI.DovizId;
            ParaVeDovizId sonucTAHLIYE_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["TAHLIYE_HARCI"], zaman); araTaraf.TAHLIYE_HARCI = sonucTAHLIYE_HARCI.Para; araTaraf.TAHLIYE_HARCI_DOVIZ_ID = sonucTAHLIYE_HARCI.DovizId;
            ParaVeDovizId sonucTAHLIYE_VEK_UCR = FaizHelper.ParalariTopla(paralarinSozlugu["TAHLIYE_VEK_UCR"], zaman); araTaraf.TAHLIYE_VEK_UCR = sonucTAHLIYE_VEK_UCR.Para; araTaraf.TAHLIYE_VEK_UCR_DOVIZ_ID = sonucTAHLIYE_VEK_UCR.DovizId;
            ParaVeDovizId sonucTAKIP_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["TAKIP_VEKALET_UCRETI"], zaman); araTaraf.TAKIP_VEKALET_UCRETI = sonucTAKIP_VEKALET_UCRETI.Para; araTaraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID = sonucTAKIP_VEKALET_UCRETI.DovizId;
            ParaVeDovizId sonucTD_BAKIYE_HARC = FaizHelper.ParalariTopla(paralarinSozlugu["TD_BAKIYE_HARC"], zaman); araTaraf.TD_BAKIYE_HARC = sonucTD_BAKIYE_HARC.Para; araTaraf.TD_BAKIYE_HARC_DOVIZ_ID = sonucTD_BAKIYE_HARC.DovizId;
            ParaVeDovizId sonucTD_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["TD_GIDERI"], zaman); araTaraf.TD_GIDERI = sonucTD_GIDERI.Para; araTaraf.TD_GIDERI_DOVIZ_ID = sonucTD_GIDERI.DovizId;
            ParaVeDovizId sonucTD_TEBLIG_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["TD_TEBLIG_GIDERI"], zaman); araTaraf.TD_TEBLIG_GIDERI = sonucTD_TEBLIG_GIDERI.Para; araTaraf.TD_TEBLIG_GIDERI_DOVIZ_ID = sonucTD_TEBLIG_GIDERI.DovizId;
            ParaVeDovizId sonucTD_VEK_UCR = FaizHelper.ParalariTopla(paralarinSozlugu["TD_VEK_UCR"], zaman); araTaraf.TD_VEK_UCR = sonucTD_VEK_UCR.Para; araTaraf.TD_VEK_UCR_DOVIZ_ID = sonucTD_VEK_UCR.DovizId;
            ParaVeDovizId sonucTESLIM_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["TESLIM_HARCI"], zaman); araTaraf.TESLIM_HARCI = sonucTESLIM_HARCI.Para; araTaraf.TESLIM_HARCI_DOVIZ_ID = sonucTESLIM_HARCI.DovizId;
            ParaVeDovizId sonucTO_MASRAF_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_MASRAF_TOPLAMI"], zaman); araTaraf.TO_MASRAF_TOPLAMI = sonucTO_MASRAF_TOPLAMI.Para; araTaraf.TO_MASRAF_TOPLAMI_DOVIZ_ID = sonucTO_MASRAF_TOPLAMI.DovizId;
            ParaVeDovizId sonucTO_ODEME_MAHSUP_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_ODEME_MAHSUP_TOPLAMI"], zaman); araTaraf.TO_ODEME_MAHSUP_TOPLAMI = sonucTO_ODEME_MAHSUP_TOPLAMI.Para; araTaraf.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = sonucTO_ODEME_MAHSUP_TOPLAMI.DovizId;
            ParaVeDovizId sonucTO_ODEME_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_ODEME_TOPLAMI"], zaman); araTaraf.TO_ODEME_TOPLAMI = sonucTO_ODEME_TOPLAMI.Para; araTaraf.TO_ODEME_TOPLAMI_DOVIZ_ID = sonucTO_ODEME_TOPLAMI.DovizId;
            ParaVeDovizId sonucTO_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_VEKALET_TOPLAMI"], zaman); araTaraf.TO_VEKALET_TOPLAMI = sonucTO_VEKALET_TOPLAMI.Para; araTaraf.TO_VEKALET_TOPLAMI_DOVIZ_ID = sonucTO_VEKALET_TOPLAMI.DovizId;
            ParaVeDovizId sonucTO_YONETIMG_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_YONETIMG_TAZMINATI"], zaman); araTaraf.TO_YONETIMG_TAZMINATI = sonucTO_YONETIMG_TAZMINATI.Para; araTaraf.TO_YONETIMG_TAZMINATI_DOVIZ_ID = sonucTO_YONETIMG_TAZMINATI.DovizId;
            ParaVeDovizId sonucTS_MASRAF_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TS_MASRAF_TOPLAMI"], zaman); araTaraf.TS_MASRAF_TOPLAMI = sonucTS_MASRAF_TOPLAMI.Para; araTaraf.TS_MASRAF_TOPLAMI_DOVIZ_ID = sonucTS_MASRAF_TOPLAMI.DovizId;
            ParaVeDovizId sonucTS_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TS_VEKALET_TOPLAMI"], zaman); araTaraf.TS_VEKALET_TOPLAMI = sonucTS_VEKALET_TOPLAMI.Para; araTaraf.TS_VEKALET_TOPLAMI_DOVIZ_ID = sonucTS_VEKALET_TOPLAMI.DovizId;
            ParaVeDovizId sonucTUM_MASRAF_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TUM_MASRAF_TOPLAMI"], zaman); araTaraf.TUM_MASRAF_TOPLAMI = sonucTUM_MASRAF_TOPLAMI.Para; araTaraf.TUM_MASRAF_TOPLAMI_DOVIZ_ID = sonucTUM_MASRAF_TOPLAMI.DovizId;
            ParaVeDovizId sonucTUM_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TUM_VEKALET_TOPLAMI"], zaman); araTaraf.TUM_VEKALET_TOPLAMI = sonucTUM_VEKALET_TOPLAMI.Para; araTaraf.TUM_VEKALET_TOPLAMI_DOVIZ_ID = sonucTUM_VEKALET_TOPLAMI.DovizId;
            ParaVeDovizId sonucVEKALET_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["VEKALET_HARCI"], zaman); araTaraf.VEKALET_HARCI = sonucVEKALET_HARCI.Para; araTaraf.VEKALET_HARCI_DOVIZ_ID = sonucVEKALET_HARCI.DovizId;
            ParaVeDovizId sonucVEKALET_PULU = FaizHelper.ParalariTopla(paralarinSozlugu["VEKALET_PULU"], zaman); araTaraf.VEKALET_PULU = sonucVEKALET_PULU.Para; araTaraf.VEKALET_PULU_DOVIZ_ID = sonucVEKALET_PULU.DovizId;

            #endregion

            foreach (KeyValuePair<string, List<ParaVeDovizId>> teki in paralarinSozlugu)
            {
                teki.Value.Clear();
            }

            #region İlgili Alanlara Değerler Ekleniyor
            paralarinSozlugu["BASVURMA_HARCI"].Add(new ParaVeDovizId(asilTaraf.BASVURMA_HARCI, asilTaraf.BASVURMA_HARCI_DOVIZ_ID));
            paralarinSozlugu["BIRIKMIS_NAFAKA"].Add(new ParaVeDovizId(asilTaraf.BIRIKMIS_NAFAKA, asilTaraf.BIRIKMIS_NAFAKA_DOVIZ_ID));
            paralarinSozlugu["CEK_KOMISYONU"].Add(new ParaVeDovizId(asilTaraf.CEK_KOMISYONU, asilTaraf.CEK_KOMISYONU_DOVIZ_ID));
            paralarinSozlugu["DAMGA_PULU"].Add(new ParaVeDovizId(asilTaraf.DAMGA_PULU, asilTaraf.DAMGA_PULU_DOVIZ_ID));
            paralarinSozlugu["DAVA_GIDERLERI"].Add(new ParaVeDovizId(asilTaraf.DAVA_GIDERLERI, asilTaraf.DAVA_GIDERLERI_DOVIZ_ID));
            paralarinSozlugu["DAVA_INKAR_TAZMINATI"].Add(new ParaVeDovizId(asilTaraf.DAVA_INKAR_TAZMINATI, asilTaraf.DAVA_INKAR_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["DAVA_VEKALET_UCRETI"].Add(new ParaVeDovizId(asilTaraf.DAVA_VEKALET_UCRETI, asilTaraf.DAVA_VEKALET_UCRETI_DOVIZ_ID));
            paralarinSozlugu["DIGER_GIDERLER"].Add(new ParaVeDovizId(asilTaraf.DIGER_GIDERLER, asilTaraf.DIGER_GIDERLER_DOVIZ_ID));
            paralarinSozlugu["DIGER_HARC"].Add(new ParaVeDovizId(asilTaraf.DIGER_HARC, asilTaraf.DIGER_HARC_DOVIZ_ID));
            paralarinSozlugu["FERAGAT_HARCI"].Add(new ParaVeDovizId(asilTaraf.FERAGAT_HARCI, asilTaraf.FERAGAT_HARCI_DOVIZ_ID));
            paralarinSozlugu["FERAGAT_TOPLAMI"].Add(new ParaVeDovizId(asilTaraf.FERAGAT_TOPLAMI, asilTaraf.FERAGAT_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["HARC_TOPLAMI"].Add(new ParaVeDovizId(asilTaraf.HARC_TOPLAMI, asilTaraf.HARC_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["ICRA_INKAR_TAZMINATI"].Add(new ParaVeDovizId(asilTaraf.ICRA_INKAR_TAZMINATI, asilTaraf.ICRA_INKAR_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["IFLAS_BASVURMA_HARCI"].Add(new ParaVeDovizId(asilTaraf.IFLAS_BASVURMA_HARCI, asilTaraf.IFLAS_BASVURMA_HARCI_DOVIZ_ID));
            paralarinSozlugu["IFLASIN_ACILMASI_HARCI"].Add(new ParaVeDovizId(asilTaraf.IFLASIN_ACILMASI_HARCI, asilTaraf.IFLASIN_ACILMASI_HARCI_DOVIZ_ID));
            paralarinSozlugu["IH_VEKALET_UCRETI"].Add(new ParaVeDovizId(asilTaraf.IH_VEKALET_UCRETI, asilTaraf.IH_VEKALET_UCRETI_DOVIZ_ID));
            paralarinSozlugu["IHTAR_GIDERI"].Add(new ParaVeDovizId(asilTaraf.IHTAR_GIDERI, asilTaraf.IHTAR_GIDERI_DOVIZ_ID));
            paralarinSozlugu["ILAM_BK_YARG_ONAMA"].Add(new ParaVeDovizId(asilTaraf.ILAM_BK_YARG_ONAMA, asilTaraf.ILAM_BK_YARG_ONAMA_DOVIZ_ID));
            paralarinSozlugu["ILAM_INKAR_TAZMINATI"].Add(new ParaVeDovizId(asilTaraf.ILAM_INKAR_TAZMINATI, asilTaraf.ILAM_INKAR_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["ILAM_TEBLIG_GIDERI"].Add(new ParaVeDovizId(asilTaraf.ILAM_TEBLIG_GIDERI, asilTaraf.ILAM_TEBLIG_GIDERI_DOVIZ_ID));
            paralarinSozlugu["ILAM_UCRETLER_TOPLAMI"].Add(new ParaVeDovizId(asilTaraf.ILAM_UCRETLER_TOPLAMI, asilTaraf.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["ILAM_VEK_UCR"].Add(new ParaVeDovizId(asilTaraf.ILAM_VEK_UCR, asilTaraf.ILAM_VEK_UCR_DOVIZ_ID));
            paralarinSozlugu["ILAM_YARGILAMA_GIDERI"].Add(new ParaVeDovizId(asilTaraf.ILAM_YARGILAMA_GIDERI, asilTaraf.ILAM_YARGILAMA_GIDERI_DOVIZ_ID));
            paralarinSozlugu["ILK_GIDERLER"].Add(new ParaVeDovizId(asilTaraf.ILK_GIDERLER, asilTaraf.ILK_GIDERLER_DOVIZ_ID));
            paralarinSozlugu["ILK_TEBLIGAT_GIDERI"].Add(new ParaVeDovizId(asilTaraf.ILK_TEBLIGAT_GIDERI, asilTaraf.ILK_TEBLIGAT_GIDERI_DOVIZ_ID));
            paralarinSozlugu["IT_GIDERI"].Add(new ParaVeDovizId(asilTaraf.IT_GIDERI, asilTaraf.IT_GIDERI_DOVIZ_ID));
            paralarinSozlugu["IT_HACIZDE_ODENEN"].Add(new ParaVeDovizId(asilTaraf.IT_HACIZDE_ODENEN, asilTaraf.IT_HACIZDE_ODENEN_DOVIZ_ID));
            paralarinSozlugu["IT_VEKALET_UCRETI"].Add(new ParaVeDovizId(asilTaraf.IT_VEKALET_UCRETI, asilTaraf.IT_VEKALET_UCRETI_DOVIZ_ID));
            paralarinSozlugu["KALAN"].Add(new ParaVeDovizId(asilTaraf.KALAN, asilTaraf.KALAN_DOVIZ_ID));
            paralarinSozlugu["KARSI_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(asilTaraf.KARSI_VEKALET_TOPLAMI, asilTaraf.KARSI_VEKALET_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["KARSILIK_TUTARI"].Add(new ParaVeDovizId(asilTaraf.KARSILIK_TUTARI, asilTaraf.KARSILIK_TUTARI_DOVIZ_ID));
            paralarinSozlugu["KARSILIKSIZ_CEK_TAZMINATI"].Add(new ParaVeDovizId(asilTaraf.KARSILIKSIZ_CEK_TAZMINATI, asilTaraf.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["MAHSUP_TOPLAMI"].Add(new ParaVeDovizId(asilTaraf.MAHSUP_TOPLAMI, asilTaraf.MAHSUP_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["MASAYA_KATILMA_HARCI"].Add(new ParaVeDovizId(asilTaraf.MASAYA_KATILMA_HARCI, asilTaraf.MASAYA_KATILMA_HARCI_DOVIZ_ID));
            paralarinSozlugu["ODEME_TOPLAMI"].Add(new ParaVeDovizId(asilTaraf.ODEME_TOPLAMI, asilTaraf.ODEME_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["ODENEN_TAHSIL_HARCI"].Add(new ParaVeDovizId(asilTaraf.ODENEN_TAHSIL_HARCI, asilTaraf.ODENEN_TAHSIL_HARCI_DOVIZ_ID));
            paralarinSozlugu["PAYLASMA_HARCI"].Add(new ParaVeDovizId(asilTaraf.PAYLASMA_HARCI, asilTaraf.PAYLASMA_HARCI_DOVIZ_ID));
            paralarinSozlugu["PESIN_HARC"].Add(new ParaVeDovizId(asilTaraf.PESIN_HARC, asilTaraf.PESIN_HARC_DOVIZ_ID));
            paralarinSozlugu["PROTESTO_GIDERI"].Add(new ParaVeDovizId(asilTaraf.PROTESTO_GIDERI, asilTaraf.PROTESTO_GIDERI_DOVIZ_ID));
            paralarinSozlugu["TAHLIYE_HARCI"].Add(new ParaVeDovizId(asilTaraf.TAHLIYE_HARCI, asilTaraf.TAHLIYE_HARCI_DOVIZ_ID));
            paralarinSozlugu["TAHLIYE_VEK_UCR"].Add(new ParaVeDovizId(asilTaraf.TAHLIYE_VEK_UCR, asilTaraf.TAHLIYE_VEK_UCR_DOVIZ_ID));
            paralarinSozlugu["TAKIP_VEKALET_UCRETI"].Add(new ParaVeDovizId(asilTaraf.TAKIP_VEKALET_UCRETI, asilTaraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID));
            paralarinSozlugu["TD_BAKIYE_HARC"].Add(new ParaVeDovizId(asilTaraf.TD_BAKIYE_HARC, asilTaraf.TD_BAKIYE_HARC_DOVIZ_ID));
            paralarinSozlugu["TD_GIDERI"].Add(new ParaVeDovizId(asilTaraf.TD_GIDERI, asilTaraf.TD_GIDERI_DOVIZ_ID));
            paralarinSozlugu["TD_TEBLIG_GIDERI"].Add(new ParaVeDovizId(asilTaraf.TD_TEBLIG_GIDERI, asilTaraf.TD_TEBLIG_GIDERI_DOVIZ_ID));
            paralarinSozlugu["TD_VEK_UCR"].Add(new ParaVeDovizId(asilTaraf.TD_VEK_UCR, asilTaraf.TD_VEK_UCR_DOVIZ_ID));
            paralarinSozlugu["TESLIM_HARCI"].Add(new ParaVeDovizId(asilTaraf.TESLIM_HARCI, asilTaraf.TESLIM_HARCI_DOVIZ_ID));
            paralarinSozlugu["TO_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(asilTaraf.TO_MASRAF_TOPLAMI, asilTaraf.TO_MASRAF_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TO_ODEME_MAHSUP_TOPLAMI"].Add(new ParaVeDovizId(asilTaraf.TO_ODEME_MAHSUP_TOPLAMI, asilTaraf.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TO_ODEME_TOPLAMI"].Add(new ParaVeDovizId(asilTaraf.TO_ODEME_TOPLAMI, asilTaraf.TO_ODEME_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TO_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(asilTaraf.TO_VEKALET_TOPLAMI, asilTaraf.TO_VEKALET_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TO_YONETIMG_TAZMINATI"].Add(new ParaVeDovizId(asilTaraf.TO_YONETIMG_TAZMINATI, asilTaraf.TO_YONETIMG_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["TS_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(asilTaraf.TS_MASRAF_TOPLAMI, asilTaraf.TS_MASRAF_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TS_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(asilTaraf.TS_VEKALET_TOPLAMI, asilTaraf.TS_VEKALET_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TUM_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(asilTaraf.TUM_MASRAF_TOPLAMI, asilTaraf.TUM_MASRAF_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TUM_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(asilTaraf.TUM_VEKALET_TOPLAMI, asilTaraf.TUM_VEKALET_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["VEKALET_HARCI"].Add(new ParaVeDovizId(asilTaraf.VEKALET_HARCI, asilTaraf.VEKALET_HARCI_DOVIZ_ID));
            paralarinSozlugu["VEKALET_PULU"].Add(new ParaVeDovizId(asilTaraf.VEKALET_PULU, asilTaraf.VEKALET_PULU_DOVIZ_ID));

            #endregion
            #region İlgili Alanlara Değerler Ekleniyor
            paralarinSozlugu["BASVURMA_HARCI"].Add(new ParaVeDovizId(araTaraf.BASVURMA_HARCI, araTaraf.BASVURMA_HARCI_DOVIZ_ID));
            paralarinSozlugu["BIRIKMIS_NAFAKA"].Add(new ParaVeDovizId(araTaraf.BIRIKMIS_NAFAKA, araTaraf.BIRIKMIS_NAFAKA_DOVIZ_ID));
            paralarinSozlugu["CEK_KOMISYONU"].Add(new ParaVeDovizId(araTaraf.CEK_KOMISYONU, araTaraf.CEK_KOMISYONU_DOVIZ_ID));
            paralarinSozlugu["DAMGA_PULU"].Add(new ParaVeDovizId(araTaraf.DAMGA_PULU, araTaraf.DAMGA_PULU_DOVIZ_ID));
            paralarinSozlugu["DAVA_GIDERLERI"].Add(new ParaVeDovizId(araTaraf.DAVA_GIDERLERI, araTaraf.DAVA_GIDERLERI_DOVIZ_ID));
            paralarinSozlugu["DAVA_INKAR_TAZMINATI"].Add(new ParaVeDovizId(araTaraf.DAVA_INKAR_TAZMINATI, araTaraf.DAVA_INKAR_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["DAVA_VEKALET_UCRETI"].Add(new ParaVeDovizId(araTaraf.DAVA_VEKALET_UCRETI, araTaraf.DAVA_VEKALET_UCRETI_DOVIZ_ID));
            paralarinSozlugu["DIGER_GIDERLER"].Add(new ParaVeDovizId(araTaraf.DIGER_GIDERLER, araTaraf.DIGER_GIDERLER_DOVIZ_ID));
            paralarinSozlugu["DIGER_HARC"].Add(new ParaVeDovizId(araTaraf.DIGER_HARC, araTaraf.DIGER_HARC_DOVIZ_ID));
            paralarinSozlugu["FERAGAT_HARCI"].Add(new ParaVeDovizId(araTaraf.FERAGAT_HARCI, araTaraf.FERAGAT_HARCI_DOVIZ_ID));
            paralarinSozlugu["FERAGAT_TOPLAMI"].Add(new ParaVeDovizId(araTaraf.FERAGAT_TOPLAMI, araTaraf.FERAGAT_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["HARC_TOPLAMI"].Add(new ParaVeDovizId(araTaraf.HARC_TOPLAMI, araTaraf.HARC_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["ICRA_INKAR_TAZMINATI"].Add(new ParaVeDovizId(araTaraf.ICRA_INKAR_TAZMINATI, araTaraf.ICRA_INKAR_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["IFLAS_BASVURMA_HARCI"].Add(new ParaVeDovizId(araTaraf.IFLAS_BASVURMA_HARCI, araTaraf.IFLAS_BASVURMA_HARCI_DOVIZ_ID));
            paralarinSozlugu["IFLASIN_ACILMASI_HARCI"].Add(new ParaVeDovizId(araTaraf.IFLASIN_ACILMASI_HARCI, araTaraf.IFLASIN_ACILMASI_HARCI_DOVIZ_ID));
            paralarinSozlugu["IH_VEKALET_UCRETI"].Add(new ParaVeDovizId(araTaraf.IH_VEKALET_UCRETI, araTaraf.IH_VEKALET_UCRETI_DOVIZ_ID));
            paralarinSozlugu["IHTAR_GIDERI"].Add(new ParaVeDovizId(araTaraf.IHTAR_GIDERI, araTaraf.IHTAR_GIDERI_DOVIZ_ID));
            paralarinSozlugu["ILAM_BK_YARG_ONAMA"].Add(new ParaVeDovizId(araTaraf.ILAM_BK_YARG_ONAMA, araTaraf.ILAM_BK_YARG_ONAMA_DOVIZ_ID));
            paralarinSozlugu["ILAM_INKAR_TAZMINATI"].Add(new ParaVeDovizId(araTaraf.ILAM_INKAR_TAZMINATI, araTaraf.ILAM_INKAR_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["ILAM_TEBLIG_GIDERI"].Add(new ParaVeDovizId(araTaraf.ILAM_TEBLIG_GIDERI, araTaraf.ILAM_TEBLIG_GIDERI_DOVIZ_ID));
            paralarinSozlugu["ILAM_UCRETLER_TOPLAMI"].Add(new ParaVeDovizId(araTaraf.ILAM_UCRETLER_TOPLAMI, araTaraf.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["ILAM_VEK_UCR"].Add(new ParaVeDovizId(araTaraf.ILAM_VEK_UCR, araTaraf.ILAM_VEK_UCR_DOVIZ_ID));
            paralarinSozlugu["ILAM_YARGILAMA_GIDERI"].Add(new ParaVeDovizId(araTaraf.ILAM_YARGILAMA_GIDERI, araTaraf.ILAM_YARGILAMA_GIDERI_DOVIZ_ID));
            paralarinSozlugu["ILK_GIDERLER"].Add(new ParaVeDovizId(araTaraf.ILK_GIDERLER, araTaraf.ILK_GIDERLER_DOVIZ_ID));
            paralarinSozlugu["ILK_TEBLIGAT_GIDERI"].Add(new ParaVeDovizId(araTaraf.ILK_TEBLIGAT_GIDERI, araTaraf.ILK_TEBLIGAT_GIDERI_DOVIZ_ID));
            paralarinSozlugu["IT_GIDERI"].Add(new ParaVeDovizId(araTaraf.IT_GIDERI, araTaraf.IT_GIDERI_DOVIZ_ID));
            paralarinSozlugu["IT_HACIZDE_ODENEN"].Add(new ParaVeDovizId(araTaraf.IT_HACIZDE_ODENEN, araTaraf.IT_HACIZDE_ODENEN_DOVIZ_ID));
            paralarinSozlugu["IT_VEKALET_UCRETI"].Add(new ParaVeDovizId(araTaraf.IT_VEKALET_UCRETI, araTaraf.IT_VEKALET_UCRETI_DOVIZ_ID));
            paralarinSozlugu["KALAN"].Add(new ParaVeDovizId(araTaraf.KALAN, araTaraf.KALAN_DOVIZ_ID));
            paralarinSozlugu["KARSI_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(araTaraf.KARSI_VEKALET_TOPLAMI, araTaraf.KARSI_VEKALET_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["KARSILIK_TUTARI"].Add(new ParaVeDovizId(araTaraf.KARSILIK_TUTARI, araTaraf.KARSILIK_TUTARI_DOVIZ_ID));
            paralarinSozlugu["KARSILIKSIZ_CEK_TAZMINATI"].Add(new ParaVeDovizId(araTaraf.KARSILIKSIZ_CEK_TAZMINATI, araTaraf.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["MAHSUP_TOPLAMI"].Add(new ParaVeDovizId(araTaraf.MAHSUP_TOPLAMI, araTaraf.MAHSUP_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["MASAYA_KATILMA_HARCI"].Add(new ParaVeDovizId(araTaraf.MASAYA_KATILMA_HARCI, araTaraf.MASAYA_KATILMA_HARCI_DOVIZ_ID));
            paralarinSozlugu["ODEME_TOPLAMI"].Add(new ParaVeDovizId(araTaraf.ODEME_TOPLAMI, araTaraf.ODEME_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["ODENEN_TAHSIL_HARCI"].Add(new ParaVeDovizId(araTaraf.ODENEN_TAHSIL_HARCI, araTaraf.ODENEN_TAHSIL_HARCI_DOVIZ_ID));
            paralarinSozlugu["PAYLASMA_HARCI"].Add(new ParaVeDovizId(araTaraf.PAYLASMA_HARCI, araTaraf.PAYLASMA_HARCI_DOVIZ_ID));
            paralarinSozlugu["PESIN_HARC"].Add(new ParaVeDovizId(araTaraf.PESIN_HARC, araTaraf.PESIN_HARC_DOVIZ_ID));
            paralarinSozlugu["PROTESTO_GIDERI"].Add(new ParaVeDovizId(araTaraf.PROTESTO_GIDERI, araTaraf.PROTESTO_GIDERI_DOVIZ_ID));
            paralarinSozlugu["TAHLIYE_HARCI"].Add(new ParaVeDovizId(araTaraf.TAHLIYE_HARCI, araTaraf.TAHLIYE_HARCI_DOVIZ_ID));
            paralarinSozlugu["TAHLIYE_VEK_UCR"].Add(new ParaVeDovizId(araTaraf.TAHLIYE_VEK_UCR, araTaraf.TAHLIYE_VEK_UCR_DOVIZ_ID));
            paralarinSozlugu["TAKIP_VEKALET_UCRETI"].Add(new ParaVeDovizId(araTaraf.TAKIP_VEKALET_UCRETI, araTaraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID));
            paralarinSozlugu["TD_BAKIYE_HARC"].Add(new ParaVeDovizId(araTaraf.TD_BAKIYE_HARC, araTaraf.TD_BAKIYE_HARC_DOVIZ_ID));
            paralarinSozlugu["TD_GIDERI"].Add(new ParaVeDovizId(araTaraf.TD_GIDERI, araTaraf.TD_GIDERI_DOVIZ_ID));
            paralarinSozlugu["TD_TEBLIG_GIDERI"].Add(new ParaVeDovizId(araTaraf.TD_TEBLIG_GIDERI, araTaraf.TD_TEBLIG_GIDERI_DOVIZ_ID));
            paralarinSozlugu["TD_VEK_UCR"].Add(new ParaVeDovizId(araTaraf.TD_VEK_UCR, araTaraf.TD_VEK_UCR_DOVIZ_ID));
            paralarinSozlugu["TESLIM_HARCI"].Add(new ParaVeDovizId(araTaraf.TESLIM_HARCI, araTaraf.TESLIM_HARCI_DOVIZ_ID));
            paralarinSozlugu["TO_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(araTaraf.TO_MASRAF_TOPLAMI, araTaraf.TO_MASRAF_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TO_ODEME_MAHSUP_TOPLAMI"].Add(new ParaVeDovizId(araTaraf.TO_ODEME_MAHSUP_TOPLAMI, araTaraf.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TO_ODEME_TOPLAMI"].Add(new ParaVeDovizId(araTaraf.TO_ODEME_TOPLAMI, araTaraf.TO_ODEME_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TO_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(araTaraf.TO_VEKALET_TOPLAMI, araTaraf.TO_VEKALET_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TO_YONETIMG_TAZMINATI"].Add(new ParaVeDovizId(araTaraf.TO_YONETIMG_TAZMINATI, araTaraf.TO_YONETIMG_TAZMINATI_DOVIZ_ID));
            paralarinSozlugu["TS_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(araTaraf.TS_MASRAF_TOPLAMI, araTaraf.TS_MASRAF_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TS_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(araTaraf.TS_VEKALET_TOPLAMI, araTaraf.TS_VEKALET_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TUM_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(araTaraf.TUM_MASRAF_TOPLAMI, araTaraf.TUM_MASRAF_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["TUM_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(araTaraf.TUM_VEKALET_TOPLAMI, araTaraf.TUM_VEKALET_TOPLAMI_DOVIZ_ID));
            paralarinSozlugu["VEKALET_HARCI"].Add(new ParaVeDovizId(araTaraf.VEKALET_HARCI, araTaraf.VEKALET_HARCI_DOVIZ_ID));
            paralarinSozlugu["VEKALET_PULU"].Add(new ParaVeDovizId(araTaraf.VEKALET_PULU, araTaraf.VEKALET_PULU_DOVIZ_ID));

            #endregion

            #region Toplam Sonuçu Oluşturuluyor

            sonucBASVURMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["BASVURMA_HARCI"], zaman); asilTaraf.BASVURMA_HARCI = sonucBASVURMA_HARCI.Para; asilTaraf.BASVURMA_HARCI_DOVIZ_ID = sonucBASVURMA_HARCI.DovizId;
            sonucBIRIKMIS_NAFAKA = FaizHelper.ParalariTopla(paralarinSozlugu["BIRIKMIS_NAFAKA"], zaman); asilTaraf.BIRIKMIS_NAFAKA = sonucBIRIKMIS_NAFAKA.Para; asilTaraf.BIRIKMIS_NAFAKA_DOVIZ_ID = sonucBIRIKMIS_NAFAKA.DovizId;
            sonucCEK_KOMISYONU = FaizHelper.ParalariTopla(paralarinSozlugu["CEK_KOMISYONU"], zaman); asilTaraf.CEK_KOMISYONU = sonucCEK_KOMISYONU.Para; asilTaraf.CEK_KOMISYONU_DOVIZ_ID = sonucCEK_KOMISYONU.DovizId;
            sonucDAMGA_PULU = FaizHelper.ParalariTopla(paralarinSozlugu["DAMGA_PULU"], zaman); asilTaraf.DAMGA_PULU = sonucDAMGA_PULU.Para; asilTaraf.DAMGA_PULU_DOVIZ_ID = sonucDAMGA_PULU.DovizId;
            sonucDAVA_GIDERLERI = FaizHelper.ParalariTopla(paralarinSozlugu["DAVA_GIDERLERI"], zaman); asilTaraf.DAVA_GIDERLERI = sonucDAVA_GIDERLERI.Para; asilTaraf.DAVA_GIDERLERI_DOVIZ_ID = sonucDAVA_GIDERLERI.DovizId;
            sonucDAVA_INKAR_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["DAVA_INKAR_TAZMINATI"], zaman); asilTaraf.DAVA_INKAR_TAZMINATI = sonucDAVA_INKAR_TAZMINATI.Para; asilTaraf.DAVA_INKAR_TAZMINATI_DOVIZ_ID = sonucDAVA_INKAR_TAZMINATI.DovizId;
            sonucDAVA_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["DAVA_VEKALET_UCRETI"], zaman); asilTaraf.DAVA_VEKALET_UCRETI = sonucDAVA_VEKALET_UCRETI.Para; asilTaraf.DAVA_VEKALET_UCRETI_DOVIZ_ID = sonucDAVA_VEKALET_UCRETI.DovizId;
            sonucDIGER_GIDERLER = FaizHelper.ParalariTopla(paralarinSozlugu["DIGER_GIDERLER"], zaman); asilTaraf.DIGER_GIDERLER = sonucDIGER_GIDERLER.Para; asilTaraf.DIGER_GIDERLER_DOVIZ_ID = sonucDIGER_GIDERLER.DovizId;
            sonucDIGER_HARC = FaizHelper.ParalariTopla(paralarinSozlugu["DIGER_HARC"], zaman); asilTaraf.DIGER_HARC = sonucDIGER_HARC.Para; asilTaraf.DIGER_HARC_DOVIZ_ID = sonucDIGER_HARC.DovizId;
            sonucFERAGAT_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["FERAGAT_HARCI"], zaman); asilTaraf.FERAGAT_HARCI = sonucFERAGAT_HARCI.Para; asilTaraf.FERAGAT_HARCI_DOVIZ_ID = sonucFERAGAT_HARCI.DovizId;
            sonucFERAGAT_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["FERAGAT_TOPLAMI"], zaman); asilTaraf.FERAGAT_TOPLAMI = sonucFERAGAT_TOPLAMI.Para; asilTaraf.FERAGAT_TOPLAMI_DOVIZ_ID = sonucFERAGAT_TOPLAMI.DovizId;
            sonucHARC_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["HARC_TOPLAMI"], zaman); asilTaraf.HARC_TOPLAMI = sonucHARC_TOPLAMI.Para; asilTaraf.HARC_TOPLAMI_DOVIZ_ID = sonucHARC_TOPLAMI.DovizId;
            sonucICRA_INKAR_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["ICRA_INKAR_TAZMINATI"], zaman); asilTaraf.ICRA_INKAR_TAZMINATI = sonucICRA_INKAR_TAZMINATI.Para; asilTaraf.ICRA_INKAR_TAZMINATI_DOVIZ_ID = sonucICRA_INKAR_TAZMINATI.DovizId;
            sonucIFLAS_BASVURMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["IFLAS_BASVURMA_HARCI"], zaman); asilTaraf.IFLAS_BASVURMA_HARCI = sonucIFLAS_BASVURMA_HARCI.Para; asilTaraf.IFLAS_BASVURMA_HARCI_DOVIZ_ID = sonucIFLAS_BASVURMA_HARCI.DovizId;
            sonucIFLASIN_ACILMASI_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["IFLASIN_ACILMASI_HARCI"], zaman); asilTaraf.IFLASIN_ACILMASI_HARCI = sonucIFLASIN_ACILMASI_HARCI.Para; asilTaraf.IFLASIN_ACILMASI_HARCI_DOVIZ_ID = sonucIFLASIN_ACILMASI_HARCI.DovizId;
            sonucIH_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["IH_VEKALET_UCRETI"], zaman); asilTaraf.IH_VEKALET_UCRETI = sonucIH_VEKALET_UCRETI.Para; asilTaraf.IH_VEKALET_UCRETI_DOVIZ_ID = sonucIH_VEKALET_UCRETI.DovizId;
            sonucIHTAR_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["IHTAR_GIDERI"], zaman); asilTaraf.IHTAR_GIDERI = sonucIHTAR_GIDERI.Para; asilTaraf.IHTAR_GIDERI_DOVIZ_ID = sonucIHTAR_GIDERI.DovizId;
            sonucILAM_BK_YARG_ONAMA = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_BK_YARG_ONAMA"], zaman); asilTaraf.ILAM_BK_YARG_ONAMA = sonucILAM_BK_YARG_ONAMA.Para; asilTaraf.ILAM_BK_YARG_ONAMA_DOVIZ_ID = sonucILAM_BK_YARG_ONAMA.DovizId;
            sonucILAM_INKAR_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_INKAR_TAZMINATI"], zaman); asilTaraf.ILAM_INKAR_TAZMINATI = sonucILAM_INKAR_TAZMINATI.Para; asilTaraf.ILAM_INKAR_TAZMINATI_DOVIZ_ID = sonucILAM_INKAR_TAZMINATI.DovizId;
            sonucILAM_TEBLIG_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_TEBLIG_GIDERI"], zaman); asilTaraf.ILAM_TEBLIG_GIDERI = sonucILAM_TEBLIG_GIDERI.Para; asilTaraf.ILAM_TEBLIG_GIDERI_DOVIZ_ID = sonucILAM_TEBLIG_GIDERI.DovizId;
            sonucILAM_UCRETLER_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_UCRETLER_TOPLAMI"], zaman); asilTaraf.ILAM_UCRETLER_TOPLAMI = sonucILAM_UCRETLER_TOPLAMI.Para; asilTaraf.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID = sonucILAM_UCRETLER_TOPLAMI.DovizId;
            sonucILAM_VEK_UCR = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_VEK_UCR"], zaman); asilTaraf.ILAM_VEK_UCR = sonucILAM_VEK_UCR.Para; asilTaraf.ILAM_VEK_UCR_DOVIZ_ID = sonucILAM_VEK_UCR.DovizId;
            sonucILAM_YARGILAMA_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_YARGILAMA_GIDERI"], zaman); asilTaraf.ILAM_YARGILAMA_GIDERI = sonucILAM_YARGILAMA_GIDERI.Para; asilTaraf.ILAM_YARGILAMA_GIDERI_DOVIZ_ID = sonucILAM_YARGILAMA_GIDERI.DovizId;
            sonucILK_GIDERLER = FaizHelper.ParalariTopla(paralarinSozlugu["ILK_GIDERLER"], zaman); asilTaraf.ILK_GIDERLER = sonucILK_GIDERLER.Para; asilTaraf.ILK_GIDERLER_DOVIZ_ID = sonucILK_GIDERLER.DovizId;
            sonucILK_TEBLIGAT_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["ILK_TEBLIGAT_GIDERI"], zaman); asilTaraf.ILK_TEBLIGAT_GIDERI = sonucILK_TEBLIGAT_GIDERI.Para; asilTaraf.ILK_TEBLIGAT_GIDERI_DOVIZ_ID = sonucILK_TEBLIGAT_GIDERI.DovizId;
            sonucIT_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["IT_GIDERI"], zaman); asilTaraf.IT_GIDERI = sonucIT_GIDERI.Para; asilTaraf.IT_GIDERI_DOVIZ_ID = sonucIT_GIDERI.DovizId;
            sonucIT_HACIZDE_ODENEN = FaizHelper.ParalariTopla(paralarinSozlugu["IT_HACIZDE_ODENEN"], zaman); asilTaraf.IT_HACIZDE_ODENEN = sonucIT_HACIZDE_ODENEN.Para; asilTaraf.IT_HACIZDE_ODENEN_DOVIZ_ID = sonucIT_HACIZDE_ODENEN.DovizId;
            sonucIT_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["IT_VEKALET_UCRETI"], zaman); asilTaraf.IT_VEKALET_UCRETI = sonucIT_VEKALET_UCRETI.Para; asilTaraf.IT_VEKALET_UCRETI_DOVIZ_ID = sonucIT_VEKALET_UCRETI.DovizId;
            sonucKALAN = FaizHelper.ParalariTopla(paralarinSozlugu["KALAN"], zaman); asilTaraf.KALAN = sonucKALAN.Para; asilTaraf.KALAN_DOVIZ_ID = sonucKALAN.DovizId;
            sonucKARSI_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["KARSI_VEKALET_TOPLAMI"], zaman); asilTaraf.KARSI_VEKALET_TOPLAMI = sonucKARSI_VEKALET_TOPLAMI.Para; asilTaraf.KARSI_VEKALET_TOPLAMI_DOVIZ_ID = sonucKARSI_VEKALET_TOPLAMI.DovizId;
            sonucKARSILIK_TUTARI = FaizHelper.ParalariTopla(paralarinSozlugu["KARSILIK_TUTARI"], zaman); asilTaraf.KARSILIK_TUTARI = sonucKARSILIK_TUTARI.Para; asilTaraf.KARSILIK_TUTARI_DOVIZ_ID = sonucKARSILIK_TUTARI.DovizId;
            sonucKARSILIKSIZ_CEK_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["KARSILIKSIZ_CEK_TAZMINATI"], zaman); asilTaraf.KARSILIKSIZ_CEK_TAZMINATI = sonucKARSILIKSIZ_CEK_TAZMINATI.Para; asilTaraf.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = sonucKARSILIKSIZ_CEK_TAZMINATI.DovizId;
            sonucMAHSUP_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["MAHSUP_TOPLAMI"], zaman); asilTaraf.MAHSUP_TOPLAMI = sonucMAHSUP_TOPLAMI.Para; asilTaraf.MAHSUP_TOPLAMI_DOVIZ_ID = sonucMAHSUP_TOPLAMI.DovizId;
            sonucMASAYA_KATILMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["MASAYA_KATILMA_HARCI"], zaman); asilTaraf.MASAYA_KATILMA_HARCI = sonucMASAYA_KATILMA_HARCI.Para; asilTaraf.MASAYA_KATILMA_HARCI_DOVIZ_ID = sonucMASAYA_KATILMA_HARCI.DovizId;
            sonucODEME_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["ODEME_TOPLAMI"], zaman); asilTaraf.ODEME_TOPLAMI = sonucODEME_TOPLAMI.Para; asilTaraf.ODEME_TOPLAMI_DOVIZ_ID = sonucODEME_TOPLAMI.DovizId;
            sonucODENEN_TAHSIL_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["ODENEN_TAHSIL_HARCI"], zaman); asilTaraf.ODENEN_TAHSIL_HARCI = sonucODENEN_TAHSIL_HARCI.Para; asilTaraf.ODENEN_TAHSIL_HARCI_DOVIZ_ID = sonucODENEN_TAHSIL_HARCI.DovizId;
            sonucPAYLASMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["PAYLASMA_HARCI"], zaman); asilTaraf.PAYLASMA_HARCI = sonucPAYLASMA_HARCI.Para; asilTaraf.PAYLASMA_HARCI_DOVIZ_ID = sonucPAYLASMA_HARCI.DovizId;
            sonucPESIN_HARC = FaizHelper.ParalariTopla(paralarinSozlugu["PESIN_HARC"], zaman); asilTaraf.PESIN_HARC = sonucPESIN_HARC.Para; asilTaraf.PESIN_HARC_DOVIZ_ID = sonucPESIN_HARC.DovizId;
            sonucPROTESTO_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["PROTESTO_GIDERI"], zaman); asilTaraf.PROTESTO_GIDERI = sonucPROTESTO_GIDERI.Para; asilTaraf.PROTESTO_GIDERI_DOVIZ_ID = sonucPROTESTO_GIDERI.DovizId;
            sonucTAHLIYE_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["TAHLIYE_HARCI"], zaman); asilTaraf.TAHLIYE_HARCI = sonucTAHLIYE_HARCI.Para; asilTaraf.TAHLIYE_HARCI_DOVIZ_ID = sonucTAHLIYE_HARCI.DovizId;
            sonucTAHLIYE_VEK_UCR = FaizHelper.ParalariTopla(paralarinSozlugu["TAHLIYE_VEK_UCR"], zaman); asilTaraf.TAHLIYE_VEK_UCR = sonucTAHLIYE_VEK_UCR.Para; asilTaraf.TAHLIYE_VEK_UCR_DOVIZ_ID = sonucTAHLIYE_VEK_UCR.DovizId;
            sonucTAKIP_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["TAKIP_VEKALET_UCRETI"], zaman); asilTaraf.TAKIP_VEKALET_UCRETI = sonucTAKIP_VEKALET_UCRETI.Para; asilTaraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID = sonucTAKIP_VEKALET_UCRETI.DovizId;
            sonucTD_BAKIYE_HARC = FaizHelper.ParalariTopla(paralarinSozlugu["TD_BAKIYE_HARC"], zaman); asilTaraf.TD_BAKIYE_HARC = sonucTD_BAKIYE_HARC.Para; asilTaraf.TD_BAKIYE_HARC_DOVIZ_ID = sonucTD_BAKIYE_HARC.DovizId;
            sonucTD_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["TD_GIDERI"], zaman); asilTaraf.TD_GIDERI = sonucTD_GIDERI.Para; asilTaraf.TD_GIDERI_DOVIZ_ID = sonucTD_GIDERI.DovizId;
            sonucTD_TEBLIG_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["TD_TEBLIG_GIDERI"], zaman); asilTaraf.TD_TEBLIG_GIDERI = sonucTD_TEBLIG_GIDERI.Para; asilTaraf.TD_TEBLIG_GIDERI_DOVIZ_ID = sonucTD_TEBLIG_GIDERI.DovizId;
            sonucTD_VEK_UCR = FaizHelper.ParalariTopla(paralarinSozlugu["TD_VEK_UCR"], zaman); asilTaraf.TD_VEK_UCR = sonucTD_VEK_UCR.Para; asilTaraf.TD_VEK_UCR_DOVIZ_ID = sonucTD_VEK_UCR.DovizId;
            sonucTESLIM_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["TESLIM_HARCI"], zaman); asilTaraf.TESLIM_HARCI = sonucTESLIM_HARCI.Para; asilTaraf.TESLIM_HARCI_DOVIZ_ID = sonucTESLIM_HARCI.DovizId;
            sonucTO_MASRAF_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_MASRAF_TOPLAMI"], zaman); asilTaraf.TO_MASRAF_TOPLAMI = sonucTO_MASRAF_TOPLAMI.Para; asilTaraf.TO_MASRAF_TOPLAMI_DOVIZ_ID = sonucTO_MASRAF_TOPLAMI.DovizId;
            sonucTO_ODEME_MAHSUP_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_ODEME_MAHSUP_TOPLAMI"], zaman); asilTaraf.TO_ODEME_MAHSUP_TOPLAMI = sonucTO_ODEME_MAHSUP_TOPLAMI.Para; asilTaraf.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = sonucTO_ODEME_MAHSUP_TOPLAMI.DovizId;
            sonucTO_ODEME_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_ODEME_TOPLAMI"], zaman); asilTaraf.TO_ODEME_TOPLAMI = sonucTO_ODEME_TOPLAMI.Para; asilTaraf.TO_ODEME_TOPLAMI_DOVIZ_ID = sonucTO_ODEME_TOPLAMI.DovizId;
            sonucTO_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_VEKALET_TOPLAMI"], zaman); asilTaraf.TO_VEKALET_TOPLAMI = sonucTO_VEKALET_TOPLAMI.Para; asilTaraf.TO_VEKALET_TOPLAMI_DOVIZ_ID = sonucTO_VEKALET_TOPLAMI.DovizId;
            sonucTO_YONETIMG_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_YONETIMG_TAZMINATI"], zaman); asilTaraf.TO_YONETIMG_TAZMINATI = sonucTO_YONETIMG_TAZMINATI.Para; asilTaraf.TO_YONETIMG_TAZMINATI_DOVIZ_ID = sonucTO_YONETIMG_TAZMINATI.DovizId;
            sonucTS_MASRAF_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TS_MASRAF_TOPLAMI"], zaman); asilTaraf.TS_MASRAF_TOPLAMI = sonucTS_MASRAF_TOPLAMI.Para; asilTaraf.TS_MASRAF_TOPLAMI_DOVIZ_ID = sonucTS_MASRAF_TOPLAMI.DovizId;
            sonucTS_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TS_VEKALET_TOPLAMI"], zaman); asilTaraf.TS_VEKALET_TOPLAMI = sonucTS_VEKALET_TOPLAMI.Para; asilTaraf.TS_VEKALET_TOPLAMI_DOVIZ_ID = sonucTS_VEKALET_TOPLAMI.DovizId;
            sonucTUM_MASRAF_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TUM_MASRAF_TOPLAMI"], zaman); asilTaraf.TUM_MASRAF_TOPLAMI = sonucTUM_MASRAF_TOPLAMI.Para; asilTaraf.TUM_MASRAF_TOPLAMI_DOVIZ_ID = sonucTUM_MASRAF_TOPLAMI.DovizId;
            sonucTUM_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TUM_VEKALET_TOPLAMI"], zaman); asilTaraf.TUM_VEKALET_TOPLAMI = sonucTUM_VEKALET_TOPLAMI.Para; asilTaraf.TUM_VEKALET_TOPLAMI_DOVIZ_ID = sonucTUM_VEKALET_TOPLAMI.DovizId;
            sonucVEKALET_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["VEKALET_HARCI"], zaman); asilTaraf.VEKALET_HARCI = sonucVEKALET_HARCI.Para; asilTaraf.VEKALET_HARCI_DOVIZ_ID = sonucVEKALET_HARCI.DovizId;
            sonucVEKALET_PULU = FaizHelper.ParalariTopla(paralarinSozlugu["VEKALET_PULU"], zaman); asilTaraf.VEKALET_PULU = sonucVEKALET_PULU.Para; asilTaraf.VEKALET_PULU_DOVIZ_ID = sonucVEKALET_PULU.DovizId;

            #endregion

            TarafAlacaklarToplami(asilTaraf, zaman);

            TarafKalanBorcToplami(asilTaraf, zaman);
        }

        public AV001_TI_BIL_FOY TumFoyTopla(List<AV001_TI_BIL_FOY> foyler, DateTime? hesaplamaTarihi)
        {
            DateTime zaman = DateTime.Now;
            AV001_TI_BIL_FOY araFoy = new AV001_TI_BIL_FOY();

            if (hesaplamaTarihi != null)
                zaman = hesaplamaTarihi.Value;

            Dictionary<string, List<ParaVeDovizId>> paralarinSozlugu = new Dictionary<string, List<ParaVeDovizId>>();

            #region Sözlük Oluşturuluyor
            paralarinSozlugu.Add("ALACAK_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ASIL_ALACAK", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("BASVURMA_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("BIRIKMIS_NAFAKA", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("BSMV_TO", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("BSMV_TS", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("CEK_KOMISYONU", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("DAMGA_PULU", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("DAVA_GIDERLERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("DAVA_INKAR_TAZMINATI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("DAVA_VEKALET_UCRETI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("DIGER_GIDERLER", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("DIGER_HARC", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("EXTRA_MONEY1", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("EXTRA_MONEY2", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("FAIZ_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("FERAGAT_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("FERAGAT_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("HARC_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("HESAPLANMIS_BSMV", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("HESAPLANMIS_FAIZ", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("HESAPLANMIS_KDV", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("HESAPLANMIS_KKDF", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("HESAPLANMIS_OIV", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ICRA_INKAR_TAZMINATI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IFLAS_BASVURMA_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IFLASIN_ACILMASI_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IH_VEKALET_UCRETI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IHTAR_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILAM_BK_YARG_ONAMA", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILAM_INKAR_TAZMINATI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILAM_TEBLIG_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILAM_UCRETLER_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILAM_VEK_UCR", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILAM_YARGILAMA_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILK_GIDERLER", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ILK_TEBLIGAT_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ISLEMIS_FAIZ", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IT_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IT_HACIZDE_ODENEN", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("IT_VEKALET_UCRETI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("KALAN", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("KALAN_TAHSIL_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("KARSI_VEKALET_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("KARSILIK_TUTARI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("KARSILIKSIZ_CEK_TAZMINATI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("KDV_TO", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("KDV_TS", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("KKDV_TO", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("KO_ILAM_TOPLAM", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("MAHSUP_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("MASAYA_KATILMA_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ODEME_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("ODENEN_TAHSIL_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("OIV_TO", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("OIV_TS", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("OZEL_TAZMINAT", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("OZEL_TUTAR1", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("OZEL_TUTAR2", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("OZEL_TUTAR3", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("PAYLASMA_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("PESIN_HARC", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("PROTESTO_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("PROTOKOL_MIKTARI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("SONRAKI_FAIZ", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("SONRAKI_TAZMINAT", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TAHLIYE_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TAHLIYE_VEK_UCR", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TAKIP_CIKISI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TAKIP_VEKALET_UCRETI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TD_BAKIYE_HARC", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TD_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TD_TEBLIG_GIDERI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TD_VEK_UCR", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TESLIM_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TO_MASRAF_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TO_ODEME_MAHSUP_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TO_ODEME_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TO_VEKALET_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TO_YONETIMG_TAZMINATI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TS_MASRAF_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TS_VEKALET_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TUM_MASRAF_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("TUM_VEKALET_TOPLAMI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("VEKALET_HARCI", new List<ParaVeDovizId>());
            paralarinSozlugu.Add("VEKALET_PULU", new List<ParaVeDovizId>());

            #endregion

            foreach (AV001_TI_BIL_FOY foy in foyler)
            {
                #region Değerler Ekleniyor

                paralarinSozlugu["ALACAK_TOPLAMI"].Add(new ParaVeDovizId(foy.ALACAK_TOPLAMI, foy.ALACAK_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["ASIL_ALACAK"].Add(new ParaVeDovizId(foy.ASIL_ALACAK, foy.ASIL_ALACAK_DOVIZ_ID));
                paralarinSozlugu["BASVURMA_HARCI"].Add(new ParaVeDovizId(foy.BASVURMA_HARCI, foy.BASVURMA_HARCI_DOVIZ_ID));
                paralarinSozlugu["BIRIKMIS_NAFAKA"].Add(new ParaVeDovizId(foy.BIRIKMIS_NAFAKA, foy.BIRIKMIS_NAFAKA_DOVIZ_ID));
                paralarinSozlugu["BSMV_TO"].Add(new ParaVeDovizId(foy.BSMV_TO, foy.BSMV_TO_DOVIZ_ID));
                paralarinSozlugu["BSMV_TS"].Add(new ParaVeDovizId(foy.BSMV_TS, foy.BSMV_TS_DOVIZ_ID));
                paralarinSozlugu["CEK_KOMISYONU"].Add(new ParaVeDovizId(foy.CEK_KOMISYONU, foy.CEK_KOMISYONU_DOVIZ_ID));
                paralarinSozlugu["DAMGA_PULU"].Add(new ParaVeDovizId(foy.DAMGA_PULU, foy.DAMGA_PULU_DOVIZ_ID));
                paralarinSozlugu["DAVA_GIDERLERI"].Add(new ParaVeDovizId(foy.DAVA_GIDERLERI, foy.DAVA_GIDERLERI_DOVIZ_ID));
                paralarinSozlugu["DAVA_INKAR_TAZMINATI"].Add(new ParaVeDovizId(foy.DAVA_INKAR_TAZMINATI, foy.DAVA_INKAR_TAZMINATI_DOVIZ_ID));
                paralarinSozlugu["DAVA_VEKALET_UCRETI"].Add(new ParaVeDovizId(foy.DAVA_VEKALET_UCRETI, foy.DAVA_VEKALET_UCRETI_DOVIZ_ID));
                paralarinSozlugu["DIGER_GIDERLER"].Add(new ParaVeDovizId(foy.DIGER_GIDERLER, foy.DIGER_GIDERLER_DOVIZ_ID));
                paralarinSozlugu["DIGER_HARC"].Add(new ParaVeDovizId(foy.DIGER_HARC, foy.DIGER_HARC_DOVIZ_ID));
                paralarinSozlugu["EXTRA_MONEY1"].Add(new ParaVeDovizId(foy.EXTRA_MONEY1, foy.EXTRA_MONEY1_DOVIZ_ID));
                paralarinSozlugu["EXTRA_MONEY2"].Add(new ParaVeDovizId(foy.EXTRA_MONEY2, foy.EXTRA_MONEY2_DOVIZ_ID));
                paralarinSozlugu["FAIZ_TOPLAMI"].Add(new ParaVeDovizId(foy.FAIZ_TOPLAMI, foy.FAIZ_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["FERAGAT_HARCI"].Add(new ParaVeDovizId(foy.FERAGAT_HARCI, foy.FERAGAT_HARCI_DOVIZ_ID));
                paralarinSozlugu["FERAGAT_TOPLAMI"].Add(new ParaVeDovizId(foy.FERAGAT_TOPLAMI, foy.FERAGAT_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["HARC_TOPLAMI"].Add(new ParaVeDovizId(foy.HARC_TOPLAMI, foy.HARC_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["HESAPLANMIS_BSMV"].Add(new ParaVeDovizId(foy.HESAPLANMIS_BSMV, foy.HESAPLANMIS_BSMV_DOVIZ_ID));
                paralarinSozlugu["HESAPLANMIS_FAIZ"].Add(new ParaVeDovizId(foy.HESAPLANMIS_FAIZ, foy.HESAPLANMIS_FAIZ_DOVIZ_ID));
                paralarinSozlugu["HESAPLANMIS_KDV"].Add(new ParaVeDovizId(foy.HESAPLANMIS_KDV, foy.HESAPLANMIS_KDV_DOVIZ_ID));
                paralarinSozlugu["HESAPLANMIS_KKDF"].Add(new ParaVeDovizId(foy.HESAPLANMIS_KKDF, foy.HESAPLANMIS_KKDF_DOVIZ_ID));
                paralarinSozlugu["HESAPLANMIS_OIV"].Add(new ParaVeDovizId(foy.HESAPLANMIS_OIV, foy.HESAPLANMIS_OIV_DOVIZ_ID));
                paralarinSozlugu["ICRA_INKAR_TAZMINATI"].Add(new ParaVeDovizId(foy.ICRA_INKAR_TAZMINATI, foy.ICRA_INKAR_TAZMINATI_DOVIZ_ID));
                paralarinSozlugu["IFLAS_BASVURMA_HARCI"].Add(new ParaVeDovizId(foy.IFLAS_BASVURMA_HARCI, foy.IFLAS_BASVURMA_HARCI_DOVIZ_ID));
                paralarinSozlugu["IFLASIN_ACILMASI_HARCI"].Add(new ParaVeDovizId(foy.IFLASIN_ACILMASI_HARCI, foy.IFLASIN_ACILMASI_HARCI_DOVIZ_ID));
                paralarinSozlugu["IH_VEKALET_UCRETI"].Add(new ParaVeDovizId(foy.IH_VEKALET_UCRETI, foy.IH_VEKALET_UCRETI_DOVIZ_ID));
                paralarinSozlugu["IHTAR_GIDERI"].Add(new ParaVeDovizId(foy.IHTAR_GIDERI, foy.IHTAR_GIDERI_DOVIZ_ID));
                paralarinSozlugu["ILAM_BK_YARG_ONAMA"].Add(new ParaVeDovizId(foy.ILAM_BK_YARG_ONAMA, foy.ILAM_BK_YARG_ONAMA_DOVIZ_ID));
                paralarinSozlugu["ILAM_INKAR_TAZMINATI"].Add(new ParaVeDovizId(foy.ILAM_INKAR_TAZMINATI, foy.ILAM_INKAR_TAZMINATI_DOVIZ_ID));
                paralarinSozlugu["ILAM_TEBLIG_GIDERI"].Add(new ParaVeDovizId(foy.ILAM_TEBLIG_GIDERI, foy.ILAM_TEBLIG_GIDERI_DOVIZ_ID));
                paralarinSozlugu["ILAM_UCRETLER_TOPLAMI"].Add(new ParaVeDovizId(foy.ILAM_UCRETLER_TOPLAMI, foy.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["ILAM_VEK_UCR"].Add(new ParaVeDovizId(foy.ILAM_VEK_UCR, foy.ILAM_VEK_UCR_DOVIZ_ID));
                paralarinSozlugu["ILAM_YARGILAMA_GIDERI"].Add(new ParaVeDovizId(foy.ILAM_YARGILAMA_GIDERI, foy.ILAM_YARGILAMA_GIDERI_DOVIZ_ID));
                paralarinSozlugu["ILK_GIDERLER"].Add(new ParaVeDovizId(foy.ILK_GIDERLER, foy.ILK_GIDERLER_DOVIZ_ID));
                paralarinSozlugu["ILK_TEBLIGAT_GIDERI"].Add(new ParaVeDovizId(foy.ILK_TEBLIGAT_GIDERI, foy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID));
                paralarinSozlugu["ISLEMIS_FAIZ"].Add(new ParaVeDovizId(foy.ISLEMIS_FAIZ, foy.ISLEMIS_FAIZ_DOVIZ_ID));
                paralarinSozlugu["IT_GIDERI"].Add(new ParaVeDovizId(foy.IT_GIDERI, foy.IT_GIDERI_DOVIZ_ID));
                paralarinSozlugu["IT_HACIZDE_ODENEN"].Add(new ParaVeDovizId(foy.IT_HACIZDE_ODENEN, foy.IT_HACIZDE_ODENEN_DOVIZ_ID));
                paralarinSozlugu["IT_VEKALET_UCRETI"].Add(new ParaVeDovizId(foy.IT_VEKALET_UCRETI, foy.IT_VEKALET_UCRETI_DOVIZ_ID));
                paralarinSozlugu["KALAN"].Add(new ParaVeDovizId(foy.KALAN, foy.KALAN_DOVIZ_ID));
                paralarinSozlugu["KALAN_TAHSIL_HARCI"].Add(new ParaVeDovizId(foy.KALAN_TAHSIL_HARCI, foy.KALAN_TAHSIL_HARCI_DOVIZ_ID));
                paralarinSozlugu["KARSI_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(foy.KARSI_VEKALET_TOPLAMI, foy.KARSI_VEKALET_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["KARSILIK_TUTARI"].Add(new ParaVeDovizId(foy.KARSILIK_TUTARI, foy.KARSILIK_TUTARI_DOVIZ_ID));
                paralarinSozlugu["KARSILIKSIZ_CEK_TAZMINATI"].Add(new ParaVeDovizId(foy.KARSILIKSIZ_CEK_TAZMINATI, foy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID));
                paralarinSozlugu["KDV_TO"].Add(new ParaVeDovizId(foy.KDV_TO, foy.KDV_TO_DOVIZ_ID));
                paralarinSozlugu["KDV_TS"].Add(new ParaVeDovizId(foy.KDV_TS, foy.KDV_TS_DOVIZ_ID));
                paralarinSozlugu["KKDV_TO"].Add(new ParaVeDovizId(foy.KKDV_TO, foy.KKDV_TO_DOVIZ_ID));
                paralarinSozlugu["KO_ILAM_TOPLAM"].Add(new ParaVeDovizId(foy.KO_ILAM_TOPLAM, foy.KO_ILAM_TOPLAM_DOVIZ_ID));
                paralarinSozlugu["MAHSUP_TOPLAMI"].Add(new ParaVeDovizId(foy.MAHSUP_TOPLAMI, foy.MAHSUP_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["MASAYA_KATILMA_HARCI"].Add(new ParaVeDovizId(foy.MASAYA_KATILMA_HARCI, foy.MASAYA_KATILMA_HARCI_DOVIZ_ID));
                paralarinSozlugu["ODEME_TOPLAMI"].Add(new ParaVeDovizId(foy.ODEME_TOPLAMI, foy.ODEME_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["ODENEN_TAHSIL_HARCI"].Add(new ParaVeDovizId(foy.ODENEN_TAHSIL_HARCI, foy.ODENEN_TAHSIL_HARCI_DOVIZ_ID));
                paralarinSozlugu["OIV_TO"].Add(new ParaVeDovizId(foy.OIV_TO, foy.OIV_TO_DOVIZ_ID));
                paralarinSozlugu["OIV_TS"].Add(new ParaVeDovizId(foy.OIV_TS, foy.OIV_TS_DOVIZ_ID));
                paralarinSozlugu["OZEL_TAZMINAT"].Add(new ParaVeDovizId(foy.OZEL_TAZMINAT, foy.OZEL_TAZMINAT_DOVIZ_ID));
                paralarinSozlugu["OZEL_TUTAR1"].Add(new ParaVeDovizId(foy.OZEL_TUTAR1, foy.OZEL_TUTAR1_DOVIZ_ID));
                paralarinSozlugu["OZEL_TUTAR2"].Add(new ParaVeDovizId(foy.OZEL_TUTAR2, foy.OZEL_TUTAR2_DOVIZ_ID));
                paralarinSozlugu["OZEL_TUTAR3"].Add(new ParaVeDovizId(foy.OZEL_TUTAR3, foy.OZEL_TUTAR3_DOVIZ_ID));
                paralarinSozlugu["PAYLASMA_HARCI"].Add(new ParaVeDovizId(foy.PAYLASMA_HARCI, foy.PAYLASMA_HARCI_DOVIZ_ID));
                paralarinSozlugu["PESIN_HARC"].Add(new ParaVeDovizId(foy.PESIN_HARC, foy.PESIN_HARC_DOVIZ_ID));
                paralarinSozlugu["PROTESTO_GIDERI"].Add(new ParaVeDovizId(foy.PROTESTO_GIDERI, foy.PROTESTO_GIDERI_DOVIZ_ID));
                paralarinSozlugu["PROTOKOL_MIKTARI"].Add(new ParaVeDovizId(foy.PROTOKOL_MIKTARI, foy.PROTOKOL_MIKTARI_DOVIZ_ID));
                paralarinSozlugu["SONRAKI_FAIZ"].Add(new ParaVeDovizId(foy.SONRAKI_FAIZ, foy.SONRAKI_FAIZ_DOVIZ_ID));
                paralarinSozlugu["SONRAKI_TAZMINAT"].Add(new ParaVeDovizId(foy.SONRAKI_TAZMINAT, foy.SONRAKI_TAZMINAT_DOVIZ_ID));
                paralarinSozlugu["TAHLIYE_HARCI"].Add(new ParaVeDovizId(foy.TAHLIYE_HARCI, foy.TAHLIYE_HARCI_DOVIZ_ID));
                paralarinSozlugu["TAHLIYE_VEK_UCR"].Add(new ParaVeDovizId(foy.TAHLIYE_VEK_UCR, foy.TAHLIYE_VEK_UCR_DOVIZ_ID));
                paralarinSozlugu["TAKIP_CIKISI"].Add(new ParaVeDovizId(foy.TAKIP_CIKISI, foy.TAKIP_CIKISI_DOVIZ_ID));
                paralarinSozlugu["TAKIP_VEKALET_UCRETI"].Add(new ParaVeDovizId(foy.TAKIP_VEKALET_UCRETI, foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID));
                paralarinSozlugu["TD_BAKIYE_HARC"].Add(new ParaVeDovizId(foy.TD_BAKIYE_HARC, foy.TD_BAKIYE_HARC_DOVIZ_ID));
                paralarinSozlugu["TD_GIDERI"].Add(new ParaVeDovizId(foy.TD_GIDERI, foy.TD_GIDERI_DOVIZ_ID));
                paralarinSozlugu["TD_TEBLIG_GIDERI"].Add(new ParaVeDovizId(foy.TD_TEBLIG_GIDERI, foy.TD_TEBLIG_GIDERI_DOVIZ_ID));
                paralarinSozlugu["TD_VEK_UCR"].Add(new ParaVeDovizId(foy.TD_VEK_UCR, foy.TD_VEK_UCR_DOVIZ_ID));
                paralarinSozlugu["TESLIM_HARCI"].Add(new ParaVeDovizId(foy.TESLIM_HARCI, foy.TESLIM_HARCI_DOVIZ_ID));
                paralarinSozlugu["TO_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(foy.TO_MASRAF_TOPLAMI, foy.TO_MASRAF_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TO_ODEME_MAHSUP_TOPLAMI"].Add(new ParaVeDovizId(foy.TO_ODEME_MAHSUP_TOPLAMI, foy.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TO_ODEME_TOPLAMI"].Add(new ParaVeDovizId(foy.TO_ODEME_TOPLAMI, foy.TO_ODEME_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TO_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(foy.TO_VEKALET_TOPLAMI, foy.TO_VEKALET_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TO_YONETIMG_TAZMINATI"].Add(new ParaVeDovizId(foy.TO_YONETIMG_TAZMINATI, foy.TO_YONETIMG_TAZMINATI_DOVIZ_ID));
                paralarinSozlugu["TS_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(foy.TS_MASRAF_TOPLAMI, foy.TS_MASRAF_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TS_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(foy.TS_VEKALET_TOPLAMI, foy.TS_VEKALET_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TUM_MASRAF_TOPLAMI"].Add(new ParaVeDovizId(foy.TUM_MASRAF_TOPLAMI, foy.TUM_MASRAF_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["TUM_VEKALET_TOPLAMI"].Add(new ParaVeDovizId(foy.TUM_VEKALET_TOPLAMI, foy.TUM_VEKALET_TOPLAMI_DOVIZ_ID));
                paralarinSozlugu["VEKALET_HARCI"].Add(new ParaVeDovizId(foy.VEKALET_HARCI, foy.VEKALET_HARCI_DOVIZ_ID));
                paralarinSozlugu["VEKALET_PULU"].Add(new ParaVeDovizId(foy.VEKALET_PULU, foy.VEKALET_PULU_DOVIZ_ID));

                #endregion
                #region <YY-20090611>
                //Burda araföyü dolduruyoruz. Nitekim özet hesapta sıkıntı çekilmesin
                araFoy.AV001_TI_BIL_ALACAK_NEDENCollection.AddRange(foy.AV001_TI_BIL_ALACAK_NEDENCollection);
                araFoy.AV001_TI_BIL_ODEME_DAGILIMCollection.AddRange(foy.AV001_TI_BIL_ODEME_DAGILIMCollection);
                araFoy.AV001_TI_BIL_BORCLU_ODEMECollection.AddRange(foy.AV001_TI_BIL_BORCLU_ODEMECollection);
                araFoy.AV001_TI_BIL_FERAGATCollection.AddRange(foy.AV001_TI_BIL_FERAGATCollection);
                araFoy.AV001_TI_BIL_FOY_TARAFCollection.AddRange(foy.AV001_TI_BIL_FOY_TARAFCollection);
                araFoy.AV001_TI_BIL_FAIZCollection.AddRange(foy.AV001_TI_BIL_FAIZCollection);
                #endregion
            }

            #region Hesap Yapılıyor

            ParaVeDovizId sonucALACAK_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["ALACAK_TOPLAMI"], zaman); araFoy.ALACAK_TOPLAMI = sonucALACAK_TOPLAMI.Para; araFoy.ALACAK_TOPLAMI_DOVIZ_ID = sonucALACAK_TOPLAMI.DovizId;
            ParaVeDovizId sonucASIL_ALACAK = FaizHelper.ParalariTopla(paralarinSozlugu["ASIL_ALACAK"], zaman); araFoy.ASIL_ALACAK = sonucASIL_ALACAK.Para; araFoy.ASIL_ALACAK_DOVIZ_ID = sonucASIL_ALACAK.DovizId;
            ParaVeDovizId sonucBASVURMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["BASVURMA_HARCI"], zaman); araFoy.BASVURMA_HARCI = sonucBASVURMA_HARCI.Para; araFoy.BASVURMA_HARCI_DOVIZ_ID = sonucBASVURMA_HARCI.DovizId;
            ParaVeDovizId sonucBIRIKMIS_NAFAKA = FaizHelper.ParalariTopla(paralarinSozlugu["BIRIKMIS_NAFAKA"], zaman); araFoy.BIRIKMIS_NAFAKA = sonucBIRIKMIS_NAFAKA.Para; araFoy.BIRIKMIS_NAFAKA_DOVIZ_ID = sonucBIRIKMIS_NAFAKA.DovizId;
            ParaVeDovizId sonucBSMV_TO = FaizHelper.ParalariTopla(paralarinSozlugu["BSMV_TO"], zaman); araFoy.BSMV_TO = sonucBSMV_TO.Para; araFoy.BSMV_TO_DOVIZ_ID = sonucBSMV_TO.DovizId;
            ParaVeDovizId sonucBSMV_TS = FaizHelper.ParalariTopla(paralarinSozlugu["BSMV_TS"], zaman); araFoy.BSMV_TS = sonucBSMV_TS.Para; araFoy.BSMV_TS_DOVIZ_ID = sonucBSMV_TS.DovizId;
            ParaVeDovizId sonucCEK_KOMISYONU = FaizHelper.ParalariTopla(paralarinSozlugu["CEK_KOMISYONU"], zaman); araFoy.CEK_KOMISYONU = sonucCEK_KOMISYONU.Para; araFoy.CEK_KOMISYONU_DOVIZ_ID = sonucCEK_KOMISYONU.DovizId;
            ParaVeDovizId sonucDAMGA_PULU = FaizHelper.ParalariTopla(paralarinSozlugu["DAMGA_PULU"], zaman); araFoy.DAMGA_PULU = sonucDAMGA_PULU.Para; araFoy.DAMGA_PULU_DOVIZ_ID = sonucDAMGA_PULU.DovizId;
            ParaVeDovizId sonucDAVA_GIDERLERI = FaizHelper.ParalariTopla(paralarinSozlugu["DAVA_GIDERLERI"], zaman); araFoy.DAVA_GIDERLERI = sonucDAVA_GIDERLERI.Para; araFoy.DAVA_GIDERLERI_DOVIZ_ID = sonucDAVA_GIDERLERI.DovizId;
            ParaVeDovizId sonucDAVA_INKAR_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["DAVA_INKAR_TAZMINATI"], zaman); araFoy.DAVA_INKAR_TAZMINATI = sonucDAVA_INKAR_TAZMINATI.Para; araFoy.DAVA_INKAR_TAZMINATI_DOVIZ_ID = sonucDAVA_INKAR_TAZMINATI.DovizId;
            ParaVeDovizId sonucDAVA_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["DAVA_VEKALET_UCRETI"], zaman); araFoy.DAVA_VEKALET_UCRETI = sonucDAVA_VEKALET_UCRETI.Para; araFoy.DAVA_VEKALET_UCRETI_DOVIZ_ID = sonucDAVA_VEKALET_UCRETI.DovizId;
            ParaVeDovizId sonucDIGER_GIDERLER = FaizHelper.ParalariTopla(paralarinSozlugu["DIGER_GIDERLER"], zaman); araFoy.DIGER_GIDERLER = sonucDIGER_GIDERLER.Para; araFoy.DIGER_GIDERLER_DOVIZ_ID = sonucDIGER_GIDERLER.DovizId;
            ParaVeDovizId sonucDIGER_HARC = FaizHelper.ParalariTopla(paralarinSozlugu["DIGER_HARC"], zaman); araFoy.DIGER_HARC = sonucDIGER_HARC.Para; araFoy.DIGER_HARC_DOVIZ_ID = sonucDIGER_HARC.DovizId;
            ParaVeDovizId sonucEXTRA_MONEY1 = FaizHelper.ParalariTopla(paralarinSozlugu["EXTRA_MONEY1"], zaman); araFoy.EXTRA_MONEY1 = sonucEXTRA_MONEY1.Para; araFoy.EXTRA_MONEY1_DOVIZ_ID = sonucEXTRA_MONEY1.DovizId;
            ParaVeDovizId sonucEXTRA_MONEY2 = FaizHelper.ParalariTopla(paralarinSozlugu["EXTRA_MONEY2"], zaman); araFoy.EXTRA_MONEY2 = sonucEXTRA_MONEY2.Para; araFoy.EXTRA_MONEY2_DOVIZ_ID = sonucEXTRA_MONEY2.DovizId;
            ParaVeDovizId sonucFAIZ_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["FAIZ_TOPLAMI"], zaman); araFoy.FAIZ_TOPLAMI = sonucFAIZ_TOPLAMI.Para; araFoy.FAIZ_TOPLAMI_DOVIZ_ID = sonucFAIZ_TOPLAMI.DovizId;
            ParaVeDovizId sonucFERAGAT_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["FERAGAT_HARCI"], zaman); araFoy.FERAGAT_HARCI = sonucFERAGAT_HARCI.Para; araFoy.FERAGAT_HARCI_DOVIZ_ID = sonucFERAGAT_HARCI.DovizId;
            ParaVeDovizId sonucFERAGAT_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["FERAGAT_TOPLAMI"], zaman); araFoy.FERAGAT_TOPLAMI = sonucFERAGAT_TOPLAMI.Para; araFoy.FERAGAT_TOPLAMI_DOVIZ_ID = sonucFERAGAT_TOPLAMI.DovizId;
            ParaVeDovizId sonucHARC_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["HARC_TOPLAMI"], zaman); araFoy.HARC_TOPLAMI = sonucHARC_TOPLAMI.Para; araFoy.HARC_TOPLAMI_DOVIZ_ID = sonucHARC_TOPLAMI.DovizId;
            ParaVeDovizId sonucHESAPLANMIS_BSMV = FaizHelper.ParalariTopla(paralarinSozlugu["HESAPLANMIS_BSMV"], zaman); araFoy.HESAPLANMIS_BSMV = sonucHESAPLANMIS_BSMV.Para; araFoy.HESAPLANMIS_BSMV_DOVIZ_ID = sonucHESAPLANMIS_BSMV.DovizId;
            ParaVeDovizId sonucHESAPLANMIS_FAIZ = FaizHelper.ParalariTopla(paralarinSozlugu["HESAPLANMIS_FAIZ"], zaman); araFoy.HESAPLANMIS_FAIZ = sonucHESAPLANMIS_FAIZ.Para; araFoy.HESAPLANMIS_FAIZ_DOVIZ_ID = sonucHESAPLANMIS_FAIZ.DovizId;
            ParaVeDovizId sonucHESAPLANMIS_KDV = FaizHelper.ParalariTopla(paralarinSozlugu["HESAPLANMIS_KDV"], zaman); araFoy.HESAPLANMIS_KDV = sonucHESAPLANMIS_KDV.Para; araFoy.HESAPLANMIS_KDV_DOVIZ_ID = sonucHESAPLANMIS_KDV.DovizId;
            ParaVeDovizId sonucHESAPLANMIS_KKDF = FaizHelper.ParalariTopla(paralarinSozlugu["HESAPLANMIS_KKDF"], zaman); araFoy.HESAPLANMIS_KKDF = sonucHESAPLANMIS_KKDF.Para; araFoy.HESAPLANMIS_KKDF_DOVIZ_ID = sonucHESAPLANMIS_KKDF.DovizId;
            ParaVeDovizId sonucHESAPLANMIS_OIV = FaizHelper.ParalariTopla(paralarinSozlugu["HESAPLANMIS_OIV"], zaman); araFoy.HESAPLANMIS_OIV = sonucHESAPLANMIS_OIV.Para; araFoy.HESAPLANMIS_OIV_DOVIZ_ID = sonucHESAPLANMIS_OIV.DovizId;
            ParaVeDovizId sonucICRA_INKAR_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["ICRA_INKAR_TAZMINATI"], zaman); araFoy.ICRA_INKAR_TAZMINATI = sonucICRA_INKAR_TAZMINATI.Para; araFoy.ICRA_INKAR_TAZMINATI_DOVIZ_ID = sonucICRA_INKAR_TAZMINATI.DovizId;
            ParaVeDovizId sonucIFLAS_BASVURMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["IFLAS_BASVURMA_HARCI"], zaman); araFoy.IFLAS_BASVURMA_HARCI = sonucIFLAS_BASVURMA_HARCI.Para; araFoy.IFLAS_BASVURMA_HARCI_DOVIZ_ID = sonucIFLAS_BASVURMA_HARCI.DovizId;
            ParaVeDovizId sonucIFLASIN_ACILMASI_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["IFLASIN_ACILMASI_HARCI"], zaman); araFoy.IFLASIN_ACILMASI_HARCI = sonucIFLASIN_ACILMASI_HARCI.Para; araFoy.IFLASIN_ACILMASI_HARCI_DOVIZ_ID = sonucIFLASIN_ACILMASI_HARCI.DovizId;
            ParaVeDovizId sonucIH_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["IH_VEKALET_UCRETI"], zaman); araFoy.IH_VEKALET_UCRETI = sonucIH_VEKALET_UCRETI.Para; araFoy.IH_VEKALET_UCRETI_DOVIZ_ID = sonucIH_VEKALET_UCRETI.DovizId;
            ParaVeDovizId sonucIHTAR_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["IHTAR_GIDERI"], zaman); araFoy.IHTAR_GIDERI = sonucIHTAR_GIDERI.Para; araFoy.IHTAR_GIDERI_DOVIZ_ID = sonucIHTAR_GIDERI.DovizId;
            ParaVeDovizId sonucILAM_BK_YARG_ONAMA = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_BK_YARG_ONAMA"], zaman); araFoy.ILAM_BK_YARG_ONAMA = sonucILAM_BK_YARG_ONAMA.Para; araFoy.ILAM_BK_YARG_ONAMA_DOVIZ_ID = sonucILAM_BK_YARG_ONAMA.DovizId;
            ParaVeDovizId sonucILAM_INKAR_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_INKAR_TAZMINATI"], zaman); araFoy.ILAM_INKAR_TAZMINATI = sonucILAM_INKAR_TAZMINATI.Para; araFoy.ILAM_INKAR_TAZMINATI_DOVIZ_ID = sonucILAM_INKAR_TAZMINATI.DovizId;
            ParaVeDovizId sonucILAM_TEBLIG_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_TEBLIG_GIDERI"], zaman); araFoy.ILAM_TEBLIG_GIDERI = sonucILAM_TEBLIG_GIDERI.Para; araFoy.ILAM_TEBLIG_GIDERI_DOVIZ_ID = sonucILAM_TEBLIG_GIDERI.DovizId;
            ParaVeDovizId sonucILAM_UCRETLER_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_UCRETLER_TOPLAMI"], zaman); araFoy.ILAM_UCRETLER_TOPLAMI = sonucILAM_UCRETLER_TOPLAMI.Para; araFoy.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID = sonucILAM_UCRETLER_TOPLAMI.DovizId;
            ParaVeDovizId sonucILAM_VEK_UCR = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_VEK_UCR"], zaman); araFoy.ILAM_VEK_UCR = sonucILAM_VEK_UCR.Para; araFoy.ILAM_VEK_UCR_DOVIZ_ID = sonucILAM_VEK_UCR.DovizId;
            ParaVeDovizId sonucILAM_YARGILAMA_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["ILAM_YARGILAMA_GIDERI"], zaman); araFoy.ILAM_YARGILAMA_GIDERI = sonucILAM_YARGILAMA_GIDERI.Para; araFoy.ILAM_YARGILAMA_GIDERI_DOVIZ_ID = sonucILAM_YARGILAMA_GIDERI.DovizId;
            ParaVeDovizId sonucILK_GIDERLER = FaizHelper.ParalariTopla(paralarinSozlugu["ILK_GIDERLER"], zaman); araFoy.ILK_GIDERLER = sonucILK_GIDERLER.Para; araFoy.ILK_GIDERLER_DOVIZ_ID = sonucILK_GIDERLER.DovizId;
            ParaVeDovizId sonucILK_TEBLIGAT_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["ILK_TEBLIGAT_GIDERI"], zaman); araFoy.ILK_TEBLIGAT_GIDERI = sonucILK_TEBLIGAT_GIDERI.Para; araFoy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID = sonucILK_TEBLIGAT_GIDERI.DovizId;
            ParaVeDovizId sonucISLEMIS_FAIZ = FaizHelper.ParalariTopla(paralarinSozlugu["ISLEMIS_FAIZ"], zaman); araFoy.ISLEMIS_FAIZ = sonucISLEMIS_FAIZ.Para; araFoy.ISLEMIS_FAIZ_DOVIZ_ID = sonucISLEMIS_FAIZ.DovizId;
            ParaVeDovizId sonucIT_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["IT_GIDERI"], zaman); araFoy.IT_GIDERI = sonucIT_GIDERI.Para; araFoy.IT_GIDERI_DOVIZ_ID = sonucIT_GIDERI.DovizId;
            ParaVeDovizId sonucIT_HACIZDE_ODENEN = FaizHelper.ParalariTopla(paralarinSozlugu["IT_HACIZDE_ODENEN"], zaman); araFoy.IT_HACIZDE_ODENEN = sonucIT_HACIZDE_ODENEN.Para; araFoy.IT_HACIZDE_ODENEN_DOVIZ_ID = sonucIT_HACIZDE_ODENEN.DovizId;
            ParaVeDovizId sonucIT_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["IT_VEKALET_UCRETI"], zaman); araFoy.IT_VEKALET_UCRETI = sonucIT_VEKALET_UCRETI.Para; araFoy.IT_VEKALET_UCRETI_DOVIZ_ID = sonucIT_VEKALET_UCRETI.DovizId;
            ParaVeDovizId sonucKALAN = FaizHelper.ParalariTopla(paralarinSozlugu["KALAN"], zaman); araFoy.KALAN = sonucKALAN.Para; araFoy.KALAN_DOVIZ_ID = sonucKALAN.DovizId;
            ParaVeDovizId sonucKALAN_TAHSIL_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["KALAN_TAHSIL_HARCI"], zaman); araFoy.KALAN_TAHSIL_HARCI = sonucKALAN_TAHSIL_HARCI.Para; araFoy.KALAN_TAHSIL_HARCI_DOVIZ_ID = sonucKALAN_TAHSIL_HARCI.DovizId;
            ParaVeDovizId sonucKARSI_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["KARSI_VEKALET_TOPLAMI"], zaman); araFoy.KARSI_VEKALET_TOPLAMI = sonucKARSI_VEKALET_TOPLAMI.Para; araFoy.KARSI_VEKALET_TOPLAMI_DOVIZ_ID = sonucKARSI_VEKALET_TOPLAMI.DovizId;
            ParaVeDovizId sonucKARSILIK_TUTARI = FaizHelper.ParalariTopla(paralarinSozlugu["KARSILIK_TUTARI"], zaman); araFoy.KARSILIK_TUTARI = sonucKARSILIK_TUTARI.Para; araFoy.KARSILIK_TUTARI_DOVIZ_ID = sonucKARSILIK_TUTARI.DovizId;
            ParaVeDovizId sonucKARSILIKSIZ_CEK_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["KARSILIKSIZ_CEK_TAZMINATI"], zaman); araFoy.KARSILIKSIZ_CEK_TAZMINATI = sonucKARSILIKSIZ_CEK_TAZMINATI.Para; araFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = sonucKARSILIKSIZ_CEK_TAZMINATI.DovizId;
            ParaVeDovizId sonucKDV_TO = FaizHelper.ParalariTopla(paralarinSozlugu["KDV_TO"], zaman); araFoy.KDV_TO = sonucKDV_TO.Para; araFoy.KDV_TO_DOVIZ_ID = sonucKDV_TO.DovizId;
            ParaVeDovizId sonucKDV_TS = FaizHelper.ParalariTopla(paralarinSozlugu["KDV_TS"], zaman); araFoy.KDV_TS = sonucKDV_TS.Para; araFoy.KDV_TS_DOVIZ_ID = sonucKDV_TS.DovizId;
            ParaVeDovizId sonucKKDV_TO = FaizHelper.ParalariTopla(paralarinSozlugu["KKDV_TO"], zaman); araFoy.KKDV_TO = sonucKKDV_TO.Para; araFoy.KKDV_TO_DOVIZ_ID = sonucKKDV_TO.DovizId;
            ParaVeDovizId sonucKO_ILAM_TOPLAM = FaizHelper.ParalariTopla(paralarinSozlugu["KO_ILAM_TOPLAM"], zaman); araFoy.KO_ILAM_TOPLAM = sonucKO_ILAM_TOPLAM.Para; araFoy.KO_ILAM_TOPLAM_DOVIZ_ID = sonucKO_ILAM_TOPLAM.DovizId;
            ParaVeDovizId sonucMAHSUP_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["MAHSUP_TOPLAMI"], zaman); araFoy.MAHSUP_TOPLAMI = sonucMAHSUP_TOPLAMI.Para; araFoy.MAHSUP_TOPLAMI_DOVIZ_ID = sonucMAHSUP_TOPLAMI.DovizId;
            ParaVeDovizId sonucMASAYA_KATILMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["MASAYA_KATILMA_HARCI"], zaman); araFoy.MASAYA_KATILMA_HARCI = sonucMASAYA_KATILMA_HARCI.Para; araFoy.MASAYA_KATILMA_HARCI_DOVIZ_ID = sonucMASAYA_KATILMA_HARCI.DovizId;
            ParaVeDovizId sonucODEME_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["ODEME_TOPLAMI"], zaman); araFoy.ODEME_TOPLAMI = sonucODEME_TOPLAMI.Para; araFoy.ODEME_TOPLAMI_DOVIZ_ID = sonucODEME_TOPLAMI.DovizId;
            ParaVeDovizId sonucODENEN_TAHSIL_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["ODENEN_TAHSIL_HARCI"], zaman); araFoy.ODENEN_TAHSIL_HARCI = sonucODENEN_TAHSIL_HARCI.Para; araFoy.ODENEN_TAHSIL_HARCI_DOVIZ_ID = sonucODENEN_TAHSIL_HARCI.DovizId;
            ParaVeDovizId sonucOIV_TO = FaizHelper.ParalariTopla(paralarinSozlugu["OIV_TO"], zaman); araFoy.OIV_TO = sonucOIV_TO.Para; araFoy.OIV_TO_DOVIZ_ID = sonucOIV_TO.DovizId;
            ParaVeDovizId sonucOIV_TS = FaizHelper.ParalariTopla(paralarinSozlugu["OIV_TS"], zaman); araFoy.OIV_TS = sonucOIV_TS.Para; araFoy.OIV_TS_DOVIZ_ID = sonucOIV_TS.DovizId;
            ParaVeDovizId sonucOZEL_TAZMINAT = FaizHelper.ParalariTopla(paralarinSozlugu["OZEL_TAZMINAT"], zaman); araFoy.OZEL_TAZMINAT = sonucOZEL_TAZMINAT.Para; araFoy.OZEL_TAZMINAT_DOVIZ_ID = sonucOZEL_TAZMINAT.DovizId;
            ParaVeDovizId sonucOZEL_TUTAR1 = FaizHelper.ParalariTopla(paralarinSozlugu["OZEL_TUTAR1"], zaman); araFoy.OZEL_TUTAR1 = sonucOZEL_TUTAR1.Para; araFoy.OZEL_TUTAR1_DOVIZ_ID = sonucOZEL_TUTAR1.DovizId;
            ParaVeDovizId sonucOZEL_TUTAR2 = FaizHelper.ParalariTopla(paralarinSozlugu["OZEL_TUTAR2"], zaman); araFoy.OZEL_TUTAR2 = sonucOZEL_TUTAR2.Para; araFoy.OZEL_TUTAR2_DOVIZ_ID = sonucOZEL_TUTAR2.DovizId;
            ParaVeDovizId sonucOZEL_TUTAR3 = FaizHelper.ParalariTopla(paralarinSozlugu["OZEL_TUTAR3"], zaman); araFoy.OZEL_TUTAR3 = sonucOZEL_TUTAR3.Para; araFoy.OZEL_TUTAR3_DOVIZ_ID = sonucOZEL_TUTAR3.DovizId;
            ParaVeDovizId sonucPAYLASMA_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["PAYLASMA_HARCI"], zaman); araFoy.PAYLASMA_HARCI = sonucPAYLASMA_HARCI.Para; araFoy.PAYLASMA_HARCI_DOVIZ_ID = sonucPAYLASMA_HARCI.DovizId;
            ParaVeDovizId sonucPESIN_HARC = FaizHelper.ParalariTopla(paralarinSozlugu["PESIN_HARC"], zaman); araFoy.PESIN_HARC = sonucPESIN_HARC.Para; araFoy.PESIN_HARC_DOVIZ_ID = sonucPESIN_HARC.DovizId;
            ParaVeDovizId sonucPROTESTO_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["PROTESTO_GIDERI"], zaman); araFoy.PROTESTO_GIDERI = sonucPROTESTO_GIDERI.Para; araFoy.PROTESTO_GIDERI_DOVIZ_ID = sonucPROTESTO_GIDERI.DovizId;
            ParaVeDovizId sonucPROTOKOL_MIKTARI = FaizHelper.ParalariTopla(paralarinSozlugu["PROTOKOL_MIKTARI"], zaman); araFoy.PROTOKOL_MIKTARI = sonucPROTOKOL_MIKTARI.Para; araFoy.PROTOKOL_MIKTARI_DOVIZ_ID = sonucPROTOKOL_MIKTARI.DovizId;
            ParaVeDovizId sonucSONRAKI_FAIZ = FaizHelper.ParalariTopla(paralarinSozlugu["SONRAKI_FAIZ"], zaman); araFoy.SONRAKI_FAIZ = sonucSONRAKI_FAIZ.Para; araFoy.SONRAKI_FAIZ_DOVIZ_ID = sonucSONRAKI_FAIZ.DovizId;
            ParaVeDovizId sonucSONRAKI_TAZMINAT = FaizHelper.ParalariTopla(paralarinSozlugu["SONRAKI_TAZMINAT"], zaman); araFoy.SONRAKI_TAZMINAT = sonucSONRAKI_TAZMINAT.Para; araFoy.SONRAKI_TAZMINAT_DOVIZ_ID = sonucSONRAKI_TAZMINAT.DovizId;
            ParaVeDovizId sonucTAHLIYE_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["TAHLIYE_HARCI"], zaman); araFoy.TAHLIYE_HARCI = sonucTAHLIYE_HARCI.Para; araFoy.TAHLIYE_HARCI_DOVIZ_ID = sonucTAHLIYE_HARCI.DovizId;
            ParaVeDovizId sonucTAHLIYE_VEK_UCR = FaizHelper.ParalariTopla(paralarinSozlugu["TAHLIYE_VEK_UCR"], zaman); araFoy.TAHLIYE_VEK_UCR = sonucTAHLIYE_VEK_UCR.Para; araFoy.TAHLIYE_VEK_UCR_DOVIZ_ID = sonucTAHLIYE_VEK_UCR.DovizId;
            ParaVeDovizId sonucTAKIP_CIKISI = FaizHelper.ParalariTopla(paralarinSozlugu["TAKIP_CIKISI"], zaman); araFoy.TAKIP_CIKISI = sonucTAKIP_CIKISI.Para; araFoy.TAKIP_CIKISI_DOVIZ_ID = sonucTAKIP_CIKISI.DovizId;
            ParaVeDovizId sonucTAKIP_VEKALET_UCRETI = FaizHelper.ParalariTopla(paralarinSozlugu["TAKIP_VEKALET_UCRETI"], zaman); araFoy.TAKIP_VEKALET_UCRETI = sonucTAKIP_VEKALET_UCRETI.Para; araFoy.TAKIP_VEKALET_UCRETI_DOVIZ_ID = sonucTAKIP_VEKALET_UCRETI.DovizId;
            ParaVeDovizId sonucTD_BAKIYE_HARC = FaizHelper.ParalariTopla(paralarinSozlugu["TD_BAKIYE_HARC"], zaman); araFoy.TD_BAKIYE_HARC = sonucTD_BAKIYE_HARC.Para; araFoy.TD_BAKIYE_HARC_DOVIZ_ID = sonucTD_BAKIYE_HARC.DovizId;
            ParaVeDovizId sonucTD_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["TD_GIDERI"], zaman); araFoy.TD_GIDERI = sonucTD_GIDERI.Para; araFoy.TD_GIDERI_DOVIZ_ID = sonucTD_GIDERI.DovizId;
            ParaVeDovizId sonucTD_TEBLIG_GIDERI = FaizHelper.ParalariTopla(paralarinSozlugu["TD_TEBLIG_GIDERI"], zaman); araFoy.TD_TEBLIG_GIDERI = sonucTD_TEBLIG_GIDERI.Para; araFoy.TD_TEBLIG_GIDERI_DOVIZ_ID = sonucTD_TEBLIG_GIDERI.DovizId;
            ParaVeDovizId sonucTD_VEK_UCR = FaizHelper.ParalariTopla(paralarinSozlugu["TD_VEK_UCR"], zaman); araFoy.TD_VEK_UCR = sonucTD_VEK_UCR.Para; araFoy.TD_VEK_UCR_DOVIZ_ID = sonucTD_VEK_UCR.DovizId;
            ParaVeDovizId sonucTESLIM_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["TESLIM_HARCI"], zaman); araFoy.TESLIM_HARCI = sonucTESLIM_HARCI.Para; araFoy.TESLIM_HARCI_DOVIZ_ID = sonucTESLIM_HARCI.DovizId;
            ParaVeDovizId sonucTO_MASRAF_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_MASRAF_TOPLAMI"], zaman); araFoy.TO_MASRAF_TOPLAMI = sonucTO_MASRAF_TOPLAMI.Para; araFoy.TO_MASRAF_TOPLAMI_DOVIZ_ID = sonucTO_MASRAF_TOPLAMI.DovizId;
            ParaVeDovizId sonucTO_ODEME_MAHSUP_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_ODEME_MAHSUP_TOPLAMI"], zaman); araFoy.TO_ODEME_MAHSUP_TOPLAMI = sonucTO_ODEME_MAHSUP_TOPLAMI.Para; araFoy.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = sonucTO_ODEME_MAHSUP_TOPLAMI.DovizId;
            ParaVeDovizId sonucTO_ODEME_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_ODEME_TOPLAMI"], zaman); araFoy.TO_ODEME_TOPLAMI = sonucTO_ODEME_TOPLAMI.Para; araFoy.TO_ODEME_TOPLAMI_DOVIZ_ID = sonucTO_ODEME_TOPLAMI.DovizId;
            ParaVeDovizId sonucTO_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_VEKALET_TOPLAMI"], zaman); araFoy.TO_VEKALET_TOPLAMI = sonucTO_VEKALET_TOPLAMI.Para; araFoy.TO_VEKALET_TOPLAMI_DOVIZ_ID = sonucTO_VEKALET_TOPLAMI.DovizId;
            ParaVeDovizId sonucTO_YONETIMG_TAZMINATI = FaizHelper.ParalariTopla(paralarinSozlugu["TO_YONETIMG_TAZMINATI"], zaman); araFoy.TO_YONETIMG_TAZMINATI = sonucTO_YONETIMG_TAZMINATI.Para; araFoy.TO_YONETIMG_TAZMINATI_DOVIZ_ID = sonucTO_YONETIMG_TAZMINATI.DovizId;
            ParaVeDovizId sonucTS_MASRAF_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TS_MASRAF_TOPLAMI"], zaman); araFoy.TS_MASRAF_TOPLAMI = sonucTS_MASRAF_TOPLAMI.Para; araFoy.TS_MASRAF_TOPLAMI_DOVIZ_ID = sonucTS_MASRAF_TOPLAMI.DovizId;
            ParaVeDovizId sonucTS_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TS_VEKALET_TOPLAMI"], zaman); araFoy.TS_VEKALET_TOPLAMI = sonucTS_VEKALET_TOPLAMI.Para; araFoy.TS_VEKALET_TOPLAMI_DOVIZ_ID = sonucTS_VEKALET_TOPLAMI.DovizId;
            ParaVeDovizId sonucTUM_MASRAF_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TUM_MASRAF_TOPLAMI"], zaman); araFoy.TUM_MASRAF_TOPLAMI = sonucTUM_MASRAF_TOPLAMI.Para; araFoy.TUM_MASRAF_TOPLAMI_DOVIZ_ID = sonucTUM_MASRAF_TOPLAMI.DovizId;
            ParaVeDovizId sonucTUM_VEKALET_TOPLAMI = FaizHelper.ParalariTopla(paralarinSozlugu["TUM_VEKALET_TOPLAMI"], zaman); araFoy.TUM_VEKALET_TOPLAMI = sonucTUM_VEKALET_TOPLAMI.Para; araFoy.TUM_VEKALET_TOPLAMI_DOVIZ_ID = sonucTUM_VEKALET_TOPLAMI.DovizId;
            ParaVeDovizId sonucVEKALET_HARCI = FaizHelper.ParalariTopla(paralarinSozlugu["VEKALET_HARCI"], zaman); araFoy.VEKALET_HARCI = sonucVEKALET_HARCI.Para; araFoy.VEKALET_HARCI_DOVIZ_ID = sonucVEKALET_HARCI.DovizId;
            ParaVeDovizId sonucVEKALET_PULU = FaizHelper.ParalariTopla(paralarinSozlugu["VEKALET_PULU"], zaman); araFoy.VEKALET_PULU = sonucVEKALET_PULU.Para; araFoy.VEKALET_PULU_DOVIZ_ID = sonucVEKALET_PULU.DovizId;

            #endregion

            #region Toplamlara Ara Föye Atılıyor
            #region <GKN 20090608>
            ///Toplamlar araFöy Üzerine Yazıldı Method Tamamlandı

            araFoy.ALACAK_TOPLAMI = sonucALACAK_TOPLAMI.Para;
            araFoy.ASIL_ALACAK = sonucASIL_ALACAK.Para;
            araFoy.BASVURMA_HARCI = sonucBASVURMA_HARCI.Para;
            araFoy.BIRIKMIS_NAFAKA = sonucBIRIKMIS_NAFAKA.Para;
            araFoy.BSMV_TO = sonucBSMV_TO.Para;
            araFoy.BSMV_TS = sonucBSMV_TS.Para;
            araFoy.CEK_KOMISYONU = sonucCEK_KOMISYONU.Para;
            araFoy.DAMGA_PULU = sonucDAMGA_PULU.Para;
            araFoy.DAVA_GIDERLERI = sonucDAVA_GIDERLERI.Para;
            araFoy.DAVA_INKAR_TAZMINATI = sonucDAVA_INKAR_TAZMINATI.Para;
            araFoy.DAVA_VEKALET_UCRETI = sonucDAVA_VEKALET_UCRETI.Para;
            araFoy.DIGER_GIDERLER = sonucDIGER_GIDERLER.Para;
            araFoy.DIGER_HARC = sonucDIGER_HARC.Para;
            araFoy.EXTRA_MONEY1 = sonucEXTRA_MONEY1.Para;
            araFoy.EXTRA_MONEY2 = sonucEXTRA_MONEY2.Para;
            araFoy.FAIZ_TOPLAMI = sonucFAIZ_TOPLAMI.Para;
            araFoy.FERAGAT_HARCI = sonucFERAGAT_HARCI.Para;
            araFoy.FERAGAT_TOPLAMI = sonucFERAGAT_TOPLAMI.Para;
            araFoy.HARC_TOPLAMI = sonucHARC_TOPLAMI.Para;
            araFoy.HESAPLANMIS_BSMV = sonucHESAPLANMIS_BSMV.Para;
            araFoy.HESAPLANMIS_FAIZ = sonucHESAPLANMIS_FAIZ.Para;
            araFoy.HESAPLANMIS_KDV = sonucHESAPLANMIS_KDV.Para;
            araFoy.HESAPLANMIS_KKDF = sonucHESAPLANMIS_KKDF.Para;
            araFoy.HESAPLANMIS_OIV = sonucHESAPLANMIS_OIV.Para;
            araFoy.ICRA_INKAR_TAZMINATI = sonucICRA_INKAR_TAZMINATI.Para;
            araFoy.IFLAS_BASVURMA_HARCI = sonucIFLAS_BASVURMA_HARCI.Para;
            araFoy.IFLASIN_ACILMASI_HARCI = sonucIFLASIN_ACILMASI_HARCI.Para;
            araFoy.IH_VEKALET_UCRETI = sonucIH_VEKALET_UCRETI.Para;
            araFoy.IHTAR_GIDERI = sonucIHTAR_GIDERI.Para;
            araFoy.ILAM_BK_YARG_ONAMA = sonucILAM_BK_YARG_ONAMA.Para;
            araFoy.ILAM_INKAR_TAZMINATI = sonucILAM_INKAR_TAZMINATI.Para;
            araFoy.ILAM_TEBLIG_GIDERI = sonucILAM_TEBLIG_GIDERI.Para;
            araFoy.ILAM_UCRETLER_TOPLAMI = sonucILAM_UCRETLER_TOPLAMI.Para;
            araFoy.ILAM_VEK_UCR = sonucILAM_VEK_UCR.Para;
            araFoy.ILAM_YARGILAMA_GIDERI = sonucILAM_YARGILAMA_GIDERI.Para;
            araFoy.ILK_GIDERLER = sonucILK_GIDERLER.Para;
            araFoy.ILK_TEBLIGAT_GIDERI = sonucILK_TEBLIGAT_GIDERI.Para;
            araFoy.ISLEMIS_FAIZ = sonucISLEMIS_FAIZ.Para;
            araFoy.IT_GIDERI = sonucIT_GIDERI.Para;
            araFoy.IT_HACIZDE_ODENEN = sonucIT_HACIZDE_ODENEN.Para;
            araFoy.IT_VEKALET_UCRETI = sonucIT_VEKALET_UCRETI.Para;
            araFoy.KALAN = sonucKALAN.Para;
            araFoy.KALAN_TAHSIL_HARCI = sonucKALAN_TAHSIL_HARCI.Para;
            araFoy.KARSI_VEKALET_TOPLAMI = sonucKARSI_VEKALET_TOPLAMI.Para;
            araFoy.KARSILIK_TUTARI = sonucKARSILIK_TUTARI.Para;
            araFoy.KARSILIKSIZ_CEK_TAZMINATI = sonucKARSILIKSIZ_CEK_TAZMINATI.Para;
            araFoy.KDV_TO = sonucKDV_TO.Para;
            araFoy.KDV_TS = sonucKDV_TS.Para;
            araFoy.KKDV_TO = sonucKKDV_TO.Para;
            araFoy.KO_ILAM_TOPLAM = sonucKO_ILAM_TOPLAM.Para;
            araFoy.MAHSUP_TOPLAMI = sonucMAHSUP_TOPLAMI.Para;
            araFoy.MASAYA_KATILMA_HARCI = sonucMASAYA_KATILMA_HARCI.Para;
            araFoy.ODEME_TOPLAMI = sonucODEME_TOPLAMI.Para;
            araFoy.ODENEN_TAHSIL_HARCI = sonucODENEN_TAHSIL_HARCI.Para;
            araFoy.OIV_TO = sonucOIV_TO.Para;
            araFoy.OIV_TS = sonucOIV_TS.Para;
            araFoy.OZEL_TAZMINAT = sonucOZEL_TAZMINAT.Para;
            araFoy.OZEL_TUTAR1 = sonucOZEL_TUTAR1.Para;
            araFoy.OZEL_TUTAR2 = sonucOZEL_TUTAR2.Para;
            araFoy.OZEL_TUTAR3 = sonucOZEL_TUTAR3.Para;
            araFoy.PAYLASMA_HARCI = sonucPAYLASMA_HARCI.Para;
            araFoy.PESIN_HARC = sonucPESIN_HARC.Para;
            araFoy.PROTESTO_GIDERI = sonucPROTESTO_GIDERI.Para;
            araFoy.PROTOKOL_MIKTARI = sonucPROTOKOL_MIKTARI.Para;
            araFoy.SONRAKI_FAIZ = sonucSONRAKI_FAIZ.Para;
            araFoy.SONRAKI_TAZMINAT = sonucSONRAKI_TAZMINAT.Para;
            araFoy.TAHLIYE_HARCI = sonucTAHLIYE_HARCI.Para;
            araFoy.TAHLIYE_VEK_UCR = sonucTAHLIYE_VEK_UCR.Para;
            araFoy.TAKIP_CIKISI = sonucTAKIP_CIKISI.Para;
            araFoy.TAKIP_VEKALET_UCRETI = sonucTAKIP_VEKALET_UCRETI.Para;
            araFoy.TD_BAKIYE_HARC = sonucTD_BAKIYE_HARC.Para;
            araFoy.TD_GIDERI = sonucTD_GIDERI.Para;
            araFoy.TD_TEBLIG_GIDERI = sonucTD_TEBLIG_GIDERI.Para;
            araFoy.TD_VEK_UCR = sonucTD_VEK_UCR.Para;
            araFoy.TESLIM_HARCI = sonucTESLIM_HARCI.Para;
            araFoy.TO_MASRAF_TOPLAMI = sonucTO_MASRAF_TOPLAMI.Para;
            araFoy.TO_ODEME_MAHSUP_TOPLAMI = sonucTO_ODEME_MAHSUP_TOPLAMI.Para;
            araFoy.TO_ODEME_TOPLAMI = sonucTO_ODEME_TOPLAMI.Para;
            araFoy.TO_VEKALET_TOPLAMI = sonucTO_VEKALET_TOPLAMI.Para;
            araFoy.TO_YONETIMG_TAZMINATI = sonucTO_YONETIMG_TAZMINATI.Para;
            araFoy.TS_MASRAF_TOPLAMI = sonucTS_MASRAF_TOPLAMI.Para;
            araFoy.TS_VEKALET_TOPLAMI = sonucTS_VEKALET_TOPLAMI.Para;
            araFoy.TUM_MASRAF_TOPLAMI = sonucTUM_MASRAF_TOPLAMI.Para;
            araFoy.TUM_VEKALET_TOPLAMI = sonucTUM_VEKALET_TOPLAMI.Para;
            araFoy.VEKALET_HARCI = sonucVEKALET_HARCI.Para;
            araFoy.VEKALET_PULU = sonucVEKALET_PULU.Para;

            araFoy.BASVURMA_HARCI_DOVIZ_ID = sonucBASVURMA_HARCI.DovizId;
            araFoy.ODEME_TOPLAMI_DOVIZ_ID = sonucODEME_TOPLAMI.DovizId;
            araFoy.ODENEN_TAHSIL_HARCI_DOVIZ_ID = sonucODENEN_TAHSIL_HARCI.DovizId;
            araFoy.OIV_TO_DOVIZ_ID = sonucOIV_TO.DovizId;
            araFoy.OIV_TS_DOVIZ_ID = sonucOIV_TS.DovizId;
            araFoy.OZEL_TAZMINAT_DOVIZ_ID = sonucOZEL_TAZMINAT.DovizId;
            araFoy.OZEL_TUTAR1_DOVIZ_ID = sonucOZEL_TUTAR1.DovizId;
            araFoy.OZEL_TUTAR2_DOVIZ_ID = sonucOZEL_TUTAR2.DovizId;
            araFoy.OZEL_TUTAR3_DOVIZ_ID = sonucOZEL_TUTAR3.DovizId;
            araFoy.PAYLASMA_HARCI_DOVIZ_ID = sonucPAYLASMA_HARCI.DovizId;
            araFoy.PESIN_HARC_DOVIZ_ID = sonucPESIN_HARC.DovizId;
            araFoy.PROTESTO_GIDERI_DOVIZ_ID = sonucPROTESTO_GIDERI.DovizId;
            araFoy.PROTOKOL_MIKTARI_DOVIZ_ID = sonucPROTOKOL_MIKTARI.DovizId;
            araFoy.SONRAKI_FAIZ_DOVIZ_ID = sonucSONRAKI_FAIZ.DovizId;
            araFoy.SONRAKI_TAZMINAT_DOVIZ_ID = sonucSONRAKI_TAZMINAT.DovizId;
            araFoy.TAHLIYE_HARCI_DOVIZ_ID = sonucTAHLIYE_HARCI.DovizId;
            araFoy.TAHLIYE_VEK_UCR_DOVIZ_ID = sonucTAHLIYE_VEK_UCR.DovizId;
            araFoy.TAKIP_CIKISI_DOVIZ_ID = sonucTAKIP_CIKISI.DovizId;
            araFoy.TAKIP_VEKALET_UCRETI_DOVIZ_ID = sonucTAKIP_VEKALET_UCRETI.DovizId;
            araFoy.TD_BAKIYE_HARC_DOVIZ_ID = sonucTD_BAKIYE_HARC.DovizId;
            araFoy.TD_GIDERI_DOVIZ_ID = sonucTD_GIDERI.DovizId;
            araFoy.TD_TEBLIG_GIDERI_DOVIZ_ID = sonucTD_TEBLIG_GIDERI.DovizId;
            araFoy.TD_VEK_UCR_DOVIZ_ID = sonucTD_VEK_UCR.DovizId;
            araFoy.TESLIM_HARCI_DOVIZ_ID = sonucTESLIM_HARCI.DovizId;
            araFoy.TO_MASRAF_TOPLAMI_DOVIZ_ID = sonucTO_MASRAF_TOPLAMI.DovizId;
            araFoy.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = sonucTO_ODEME_MAHSUP_TOPLAMI.DovizId;
            araFoy.TO_ODEME_TOPLAMI_DOVIZ_ID = sonucTO_ODEME_TOPLAMI.DovizId;
            araFoy.TO_VEKALET_TOPLAMI_DOVIZ_ID = sonucTO_VEKALET_TOPLAMI.DovizId;
            araFoy.TO_YONETIMG_TAZMINATI_DOVIZ_ID = sonucTO_YONETIMG_TAZMINATI.DovizId;
            araFoy.TS_MASRAF_TOPLAMI_DOVIZ_ID = sonucTS_MASRAF_TOPLAMI.DovizId;
            araFoy.TS_VEKALET_TOPLAMI_DOVIZ_ID = sonucTS_VEKALET_TOPLAMI.DovizId;
            araFoy.TUM_MASRAF_TOPLAMI_DOVIZ_ID = sonucTUM_MASRAF_TOPLAMI.DovizId;
            araFoy.TUM_VEKALET_TOPLAMI_DOVIZ_ID = sonucTUM_VEKALET_TOPLAMI.DovizId;
            araFoy.VEKALET_HARCI_DOVIZ_ID = sonucVEKALET_HARCI.DovizId;
            araFoy.VEKALET_PULU_DOVIZ_ID = sonucVEKALET_PULU.DovizId;

            #endregion </GKN 20090608>
            #endregion

            #region <YY-20090611>
            //Takip tarihi atıyoruz sonradan patlıyor
            //TODO: Burası bu şekilde bilerek istenerek yapılmıştır başka bir çözüme ihtiyaç her daim vardır, var olacaktır. [YY]
            araFoy.TAKIP_TARIHI = DateTime.Today;
            araFoy.TAKIP_TALEP_ID = 1;
            araFoy.FORM_TIP_ID = 1;
            #endregion </YY-20090611>

            return araFoy;
        }

        private void AlacaklarToplami(AV001_TI_BIL_FOY myFoy, DateTime zaman)
        {
            List<ParaVeDovizId> toplanacakAlacaklarListesi = new List<ParaVeDovizId>();
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.TAKIP_CIKISI, myFoy.TAKIP_CIKISI_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.SONRAKI_FAIZ, myFoy.SONRAKI_FAIZ_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.BSMV_TS, myFoy.BSMV_TS_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.OIV_TS, myFoy.OIV_TS_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.KDV_TS, myFoy.KDV_TS_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.SONRAKI_TAZMINAT, myFoy.SONRAKI_TAZMINAT_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.BIRIKMIS_NAFAKA, myFoy.BIRIKMIS_NAFAKA_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.TS_MASRAF_TOPLAMI.Value, myFoy.TS_MASRAF_TOPLAMI_DOVIZ_ID.Value));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.TS_VEKALET_TOPLAMI.Value, myFoy.TS_VEKALET_TOPLAMI_DOVIZ_ID.Value));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.ODENEN_TAHSIL_HARCI, myFoy.ODENEN_TAHSIL_HARCI_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.DIGER_HARC, myFoy.DIGER_HARC_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.TAHLIYE_HARCI, myFoy.TAHLIYE_HARCI_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.MASAYA_KATILMA_HARCI, myFoy.MASAYA_KATILMA_HARCI_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.PAYLASMA_HARCI, myFoy.PAYLASMA_HARCI_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.ICRA_INKAR_TAZMINATI, myFoy.ICRA_INKAR_TAZMINATI_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.DAVA_INKAR_TAZMINATI, myFoy.DAVA_INKAR_TAZMINATI_DOVIZ_ID));

            ParaVeDovizId alacaklarToplami = FaizHelper.ParalariTopla(toplanacakAlacaklarListesi, zaman);
            myFoy.ALACAK_TOPLAMI = alacaklarToplami.Para;
            myFoy.ALACAK_TOPLAMI_DOVIZ_ID = alacaklarToplami.DovizId;
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Cancel)
                return;

            int foyId = int.Parse(e.Argument.ToString());
            AV001_TI_BIL_FOY hesalananFoy = IcraFoyHesaplaByID(foyId);
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IcraHesapSonucu(sender, e);
        }

        private void HesapAlanlariKontrolu(AV001_TI_BIL_FOY myFoy)
        {
            string hatalar = string.Empty;
            bool hataVar = false;

            #region AV001_TI_BIL_ALACAK_NEDEN.FAIZ_BASLANGIC_TARIHI.HasValue
            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                if (!neden.FAIZ_BASLANGIC_TARIHI.HasValue)
                {
                    neden.FAIZ_YOK = true;
                }
            }
            #endregion

            if (hataVar)
            {
                throw new Exception(hatalar);
            }
        }

        /// <summary>
        /// Faiz Kalemleri üzerindeki bsmv, kkdf, oiv tutarlarını alacak nedeninin üzerine ekliyor
        /// </summary>
        /// <param name="myFoy"></param>
        private void HesaplaAlacakNedenUzerine(AV001_TI_BIL_FOY myFoy)
        {
            foreach (var aNeden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                ParaVeDovizId bsmv = new ParaVeDovizId();
                ParaVeDovizId kkdf = new ParaVeDovizId();
                ParaVeDovizId oiv = new ParaVeDovizId();

                foreach (var faiz in aNeden.AV001_TI_BIL_FAIZCollection)
                {
                    bsmv = ParaVeDovizId.Topla(bsmv, new ParaVeDovizId(faiz.BSMV_TUTARI, faiz.BSMV_DOVIZ_ID, myFoy.TAKIP_TARIHI));
                    kkdf = ParaVeDovizId.Topla(kkdf, new ParaVeDovizId(faiz.KKDF_TUTARI, faiz.KKDF_DOVIZ_ID, myFoy.TAKIP_TARIHI));
                    oiv = ParaVeDovizId.Topla(oiv, new ParaVeDovizId(faiz.OIV_TUTARI, faiz.OIV_DOVIZ_ID, myFoy.TAKIP_TARIHI));
                }

                aNeden.BSMV_TUTARI = bsmv.Para;
                aNeden.BSMV_TUTARI_DOVIZ_ID = bsmv.DovizId;

                aNeden.KKDV_TUTARI = kkdf.Para;
                aNeden.KKDV_TUTARI_DOVIZ_ID = kkdf.DovizId;

                aNeden.OIV_TUTARI = oiv.Para;
                aNeden.OIV_TUTARI_DOVIZ_ID = oiv.DovizId;
            }
        }

        private void HesaplaBakiyeHarciHesabaDahilmi(AV001_TI_BIL_FOY myFoy)
        {
            if (myFoy.BAKIYE_HARC_TOPLAMA_EKLE)
            {
                List<ParaVeDovizId> toplanacakListesi = new List<ParaVeDovizId>();
                toplanacakListesi.Add(new ParaVeDovizId(myFoy.KALAN, myFoy.KALAN_DOVIZ_ID));
                toplanacakListesi.Add(new ParaVeDovizId(myFoy.KALAN_TAHSIL_HARCI, myFoy.KALAN_TAHSIL_HARCI_DOVIZ_ID.HasValue ? myFoy.KALAN_TAHSIL_HARCI_DOVIZ_ID.Value : 1));

                ParaVeDovizId toplam = ParaVeDovizId.Topla(toplanacakListesi);
                myFoy.KALAN = toplam.Para;
                myFoy.KALAN_DOVIZ_ID = toplam.DovizId;
            }
        }

        private void KalanBorcToplami(AV001_TI_BIL_FOY myFoy, DateTime zaman)
        {
            List<ParaVeDovizId> hesaplanacakKalanListesi = new List<ParaVeDovizId>();
            hesaplanacakKalanListesi.Add(new ParaVeDovizId(myFoy.ALACAK_TOPLAMI, myFoy.ALACAK_TOPLAMI_DOVIZ_ID, zaman));
            hesaplanacakKalanListesi.Add(new ParaVeDovizId(myFoy.FERAGAT_TOPLAMI, myFoy.FERAGAT_TOPLAMI_DOVIZ_ID, zaman));
            hesaplanacakKalanListesi.Add(new ParaVeDovizId(myFoy.ODEME_TOPLAMI, myFoy.ODEME_TOPLAMI_DOVIZ_ID, zaman));
            ParaVeDovizId kalanToplami = FaizHelper.ParalariTopla(hesaplanacakKalanListesi, zaman);

            myFoy.KALAN = kalanToplami.Para;
            myFoy.KALAN_DOVIZ_ID = kalanToplami.DovizId;
        }

        private void KalanTahsilHarcindanOdeneniDus(AV001_TI_BIL_FOY myFoy)
        {
            if (myFoy.KALAN_TAHSIL_HARCI_DOVIZ_ID == myFoy.PESIN_HARC_DOVIZ_ID)
            {
                myFoy.KALAN_TAHSIL_HARCI -= myFoy.PESIN_HARC;
            }
            else
            {
                ParaVeDovizId kanalharc = new ParaVeDovizId(myFoy.KALAN_TAHSIL_HARCI, myFoy.KALAN_TAHSIL_HARCI_DOVIZ_ID);
                ParaVeDovizId pesinHarc = new ParaVeDovizId(myFoy.PESIN_HARC, myFoy.PESIN_HARC_DOVIZ_ID);

                ParaVeDovizId gelen = ParaVeDovizId.Cikart(kanalharc, pesinHarc);
                myFoy.KALAN_TAHSIL_HARCI = gelen.Para;
                myFoy.KALAN_TAHSIL_HARCI_DOVIZ_ID = gelen.DovizId;
            }

            if (myFoy.KALAN_TAHSIL_HARCI < 0)
            {
                myFoy.KALAN_TAHSIL_HARCI = 0;
            }
        }

        #region <YY-20090608>

        //Tlist alan overload oluşturuldu
        public AV001_TI_BIL_FOY TumFoyTopla(TList<AV001_TI_BIL_FOY> foyler, DateTime? hesaplamaTarihi)
        {
            List<AV001_TI_BIL_FOY> sonuc = new List<AV001_TI_BIL_FOY>(foyler);
            return TumFoyTopla(sonuc, hesaplamaTarihi);
        }

        #endregion

        private void TarafAlacaklarToplami(AV001_TI_BIL_FOY_TARAF myTaraf, DateTime zaman)
        {
            List<ParaVeDovizId> toplanacakAlacaklarListesi = new List<ParaVeDovizId>();
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myTaraf.TAKIP_CIKISI, myTaraf.TAKIP_CIKISI_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myTaraf.SONRAKI_FAIZ, myTaraf.SONRAKI_FAIZ_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myTaraf.BSMV_TS, myTaraf.BSMV_TS_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myTaraf.OIV_TS, myTaraf.OIV_TS_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myTaraf.KDV_TS, myTaraf.KDV_TS_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myTaraf.SONRAKI_TAZMINAT, myTaraf.SONRAKI_TAZMINAT_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myTaraf.BIRIKMIS_NAFAKA, myTaraf.BIRIKMIS_NAFAKA_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myTaraf.TS_MASRAF_TOPLAMI, myTaraf.TS_MASRAF_TOPLAMI_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myTaraf.TS_VEKALET_TOPLAMI, myTaraf.TS_VEKALET_TOPLAMI_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myTaraf.ODENEN_TAHSIL_HARCI, myTaraf.ODENEN_TAHSIL_HARCI_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myTaraf.DIGER_HARC, myTaraf.DIGER_HARC_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myTaraf.TAHLIYE_HARCI, myTaraf.TAHLIYE_HARCI_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myTaraf.MASAYA_KATILMA_HARCI, myTaraf.MASAYA_KATILMA_HARCI_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myTaraf.PAYLASMA_HARCI, myTaraf.PAYLASMA_HARCI_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myTaraf.ICRA_INKAR_TAZMINATI, myTaraf.ICRA_INKAR_TAZMINATI_DOVIZ_ID));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myTaraf.DAVA_INKAR_TAZMINATI, myTaraf.DAVA_INKAR_TAZMINATI_DOVIZ_ID));

            ParaVeDovizId alacaklarToplami = FaizHelper.ParalariTopla(toplanacakAlacaklarListesi, zaman);
            myTaraf.ALACAK_TOPLAMI = alacaklarToplami.Para;
            myTaraf.ALACAK_TOPLAMI_DOVIZ_ID = alacaklarToplami.DovizId;
        }

        private void TarafKalanBorcToplami(AV001_TI_BIL_FOY_TARAF myTaraf, DateTime zaman)
        {
            List<ParaVeDovizId> hesaplanacakKalanListesi = new List<ParaVeDovizId>();
            hesaplanacakKalanListesi.Add(new ParaVeDovizId(myTaraf.ALACAK_TOPLAMI, myTaraf.ALACAK_TOPLAMI_DOVIZ_ID, zaman));
            hesaplanacakKalanListesi.Add(new ParaVeDovizId(myTaraf.FERAGAT_TOPLAMI, myTaraf.FERAGAT_TOPLAMI_DOVIZ_ID, zaman));
            hesaplanacakKalanListesi.Add(new ParaVeDovizId(myTaraf.ODEME_TOPLAMI, myTaraf.ODEME_TOPLAMI_DOVIZ_ID, zaman));
            ParaVeDovizId kalanToplami = FaizHelper.ParalariTopla(hesaplanacakKalanListesi, zaman);

            myTaraf.KALAN = kalanToplami.Para;
            myTaraf.KALAN_DOVIZ_ID = kalanToplami.DovizId;
        }

        #region Taahhüt

        public enum FaizIsletimTipi
        {
            Faiz_basit_usulde_hesaplansin = 0,
            Uc_Aylik_Standart_devrelerde_faiz_anaparaya_ilave_edilsin = 1,
            Temerrut_itibariyle_3_Aylik_devrelerde_faiz_anaparaya_ilave_edilsin = 2,
            Temerrut_itibariyle_yillik_faiz_anaparaya_ilave_edilsin = 3,
            Yil_sonlari_itibariyle_yillik_faiz_anaparaya_ilave_edilsin = 4,
            Ay_sonlarinda_aylik_faiz_anaparaya_ilave_edilsin = 5,
            Temerrut_itibariyle_aylik_faiz_anaparaya_ilave_edilsin = 6
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
            TAAHHUT_KABUL_TARIHI_GIRILMEMIŞ = 9,
        }

        public static void FaiziAnaParayaEkle(AV001_TI_BIL_FOY foy, FaizIsletimTipi faizTipi, DateTime taahhutIhlalTarihi)
        {
            int ayFarki = 0;
            switch (faizTipi)
            {
                #region switch
                case FaizIsletimTipi.Uc_Aylik_Standart_devrelerde_faiz_anaparaya_ilave_edilsin:
                    ayFarki = 3;
                    break;

                case FaizIsletimTipi.Temerrut_itibariyle_3_Aylik_devrelerde_faiz_anaparaya_ilave_edilsin:
                    ayFarki = 3;
                    break;

                case FaizIsletimTipi.Temerrut_itibariyle_yillik_faiz_anaparaya_ilave_edilsin:
                    ayFarki = 12;
                    break;

                case FaizIsletimTipi.Yil_sonlari_itibariyle_yillik_faiz_anaparaya_ilave_edilsin:
                    ayFarki = 12;
                    break;

                case FaizIsletimTipi.Ay_sonlarinda_aylik_faiz_anaparaya_ilave_edilsin:
                    ayFarki = 1;
                    break;

                case FaizIsletimTipi.Temerrut_itibariyle_aylik_faiz_anaparaya_ilave_edilsin:
                    ayFarki = 1;
                    break;

                default:
                    break;
                #endregion
            }

            DateTime faizinEklenmeTarihi = taahhutIhlalTarihi.AddMonths(ayFarki);

            if (foy.SON_HESAP_TARIHI.Value >= faizinEklenmeTarihi)
            {
                #region if
                HesapYapar hy = new HesapYapar();
                hy.IcraFoyHesapla(foy, faizinEklenmeTarihi);

                List<ParaVeDovizId> faizListesi = new List<ParaVeDovizId>();
                foreach (AV001_TI_BIL_FAIZ faiz in foy.AV001_TI_BIL_FAIZCollection)
                {
                    faizListesi.Add(new ParaVeDovizId(faiz.FAIZ_TUTARI, faiz.FAIZ_TUTARI_DOVIZ_ID));
                }
                ParaVeDovizId toplamFaiz = ParaVeDovizId.Topla(faizListesi);

                foreach (AV001_TI_BIL_ALACAK_NEDEN teki in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    teki.FAIZ_BASLANGIC_TARIHI = faizinEklenmeTarihi;
                }

                AV001_TI_BIL_ALACAK_NEDEN neden = foy.AV001_TI_BIL_ALACAK_NEDENCollection.AddNew();

                neden.TUTARI = toplamFaiz.Para;
                neden.TUTAR_DOVIZ_ID = toplamFaiz.DovizId;
                neden.STAMP = 5;
                neden.FAIZ_BASLANGIC_TARIHI = faizinEklenmeTarihi;

                hy.IcraFoyHesapla(foy);
                #endregion
            }
        }

        /// <summary>
        /// Yeni Ödeme Girilmesi Durumunda Taahhüt ün durumunu kontrol eder ve master taahhüt üzerine değerlendirmeyi yazar
        /// </summary>
        /// <param name="foy">Geçerli Föy</param>
        /// <param name="masterTaahhut">Geçerli Föyün Geçerli Taahhüt ü </param>
        public static void TaahhutKontrol(AV001_TI_BIL_FOY foy, AV001_TI_BIL_BORCLU_TAAHHUT_MASTER masterTaahhut)
        {
            if (masterTaahhut != null)
            {
                Dictionary<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD, TList<AV001_TI_BIL_BORCLU_ODEME>> eslesmeler = new Dictionary<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD, TList<AV001_TI_BIL_BORCLU_ODEME>>();

                TList<AV001_TI_BIL_BORCLU_ODEME> yeniOdemeListesi = new TList<AV001_TI_BIL_BORCLU_ODEME>();
                DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepLoad(masterTaahhut, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD>));
                TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD> childlar = masterTaahhut.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection;

                TList<AV001_TI_BIL_BORCLU_ODEME> devredenOdemeler = new TList<AV001_TI_BIL_BORCLU_ODEME>();

                foreach (AV001_TI_BIL_BORCLU_ODEME odeme in foy.AV001_TI_BIL_BORCLU_ODEMECollection)
                {
                    if (odeme.IsNew)
                    {
                        yeniOdemeListesi.Add(odeme);

                        odeme.TAAHHUTTE_KULLANILACAK = true;
                    }
                }
                yeniOdemeListesi.Sort(string.Format("{0}", AV001_TI_BIL_BORCLU_ODEMEColumn.ODEME_TARIHI.ToString()));

                childlar.Sort(string.Format("{0}", AV001_TI_BIL_BORCLU_TAAHHUT_CHILDColumn.TAAHHUTU_YERINE_GETIRME_TARIHI.ToString()));

                foreach (AV001_TI_BIL_BORCLU_TAAHHUT_CHILD child in childlar)
                {
                    ParaVeDovizId kalanBorc = ParaVeDovizId.Cikart(new ParaVeDovizId(child.TAAHHUT_MIKTARI, child.TAAHHUT_MIKTARI_DOVIZ_ID)
                                                                  , new ParaVeDovizId(child.ODEME_MIKTARI, child.ODEME_MIKTARI_DOVIZ_ID ?? 1));

                    if (kalanBorc.YtlHali == 0)
                    {
                        //bu taahhuut ödenmiş
                    }
                    else if (kalanBorc.YtlHali > 0)
                    {
                        foreach (AV001_TI_BIL_BORCLU_ODEME odeme in yeniOdemeListesi)
                        {
                            ParaVeDovizId kalanMebla = ParaVeDovizId.Cikart(new ParaVeDovizId(odeme.ODEME_MIKTAR, odeme.ODEME_MIKTAR_DOVIZ_ID ?? 1)
                                                                            , new ParaVeDovizId(odeme.TAAHHUTE_DAGILAN_TUTAR, odeme.TAAHHUTE_DAGILAN_TUTAR_DOVIZ_ID ?? 1));

                            if (kalanMebla.YtlHali > 0)
                            {
                                if (kalanBorc.YtlHali >= kalanMebla.YtlHali)
                                {
                                    ParaVeDovizId odemeMiktari = ParaVeDovizId.Topla(new ParaVeDovizId(child.ODEME_MIKTARI, child.ODEME_MIKTARI_DOVIZ_ID ?? 1), kalanMebla);
                                    child.ODEME_MIKTARI = odemeMiktari.Para;
                                    child.ODEME_MIKTARI_DOVIZ_ID = odemeMiktari.DovizId;

                                    ParaVeDovizId taahhuteDagilan = ParaVeDovizId.Topla(new ParaVeDovizId(odeme.TAAHHUTE_DAGILAN_TUTAR, odeme.TAAHHUTE_DAGILAN_TUTAR_DOVIZ_ID), kalanMebla);

                                    odeme.TAAHHUTE_DAGILAN_TUTAR_DOVIZ_ID = taahhuteDagilan.DovizId;
                                    odeme.TAAHHUTE_DAGILAN_TUTAR = taahhuteDagilan.Para;

                                    if (child.TAAHHUTU_YERINE_GETIRME_TARIHI < odeme.ODEME_TARIHI)
                                    {
                                        child.DURUM_ID = (int)TaahhutDurum.ZAMANINDAN_SONRA_EKSIK;
                                    }
                                    else if (child.TAAHHUTU_YERINE_GETIRME_TARIHI > odeme.ODEME_TARIHI)
                                    {
                                        child.DURUM_ID = (int)TaahhutDurum.ZAMANINDAN_ONCE_EKSIK;
                                    }
                                    else if (child.TAAHHUTU_YERINE_GETIRME_TARIHI == odeme.ODEME_TARIHI)
                                    {
                                        child.DURUM_ID = (int)TaahhutDurum.ZAMANINDA_EKSIK;
                                    }
                                }
                                else if (kalanBorc.YtlHali < kalanMebla.YtlHali)
                                {
                                    ParaVeDovizId odemeMiktari = ParaVeDovizId.Topla(new ParaVeDovizId(child.ODEME_MIKTARI, child.ODEME_MIKTARI_DOVIZ_ID ?? 1), kalanBorc);
                                    child.ODEME_MIKTARI = odemeMiktari.Para;
                                    child.ODEME_MIKTARI_DOVIZ_ID = odemeMiktari.DovizId;

                                    ParaVeDovizId taahhuteDagilan = ParaVeDovizId.Topla(new ParaVeDovizId(odeme.TAAHHUTE_DAGILAN_TUTAR, odeme.TAAHHUTE_DAGILAN_TUTAR_DOVIZ_ID), kalanBorc);

                                    odeme.TAAHHUTE_DAGILAN_TUTAR_DOVIZ_ID = taahhuteDagilan.DovizId;
                                    odeme.TAAHHUTE_DAGILAN_TUTAR = taahhuteDagilan.Para;

                                    if (child.TAAHHUTU_YERINE_GETIRME_TARIHI < odeme.ODEME_TARIHI)
                                    {
                                        //tAAHHÜTT iHLAL oLDU
                                        child.DURUM_ID = (int)TaahhutDurum.ZAMANINDAN_SONRA_TAM;
                                    }
                                    else if (child.TAAHHUTU_YERINE_GETIRME_TARIHI > odeme.ODEME_TARIHI)
                                    {
                                        child.DURUM_ID = (int)TaahhutDurum.ZAMANINDAN_ONCE_TAM;
                                    }
                                    else if (child.TAAHHUTU_YERINE_GETIRME_TARIHI == odeme.ODEME_TARIHI)
                                    {
                                        child.DURUM_ID = (int)TaahhutDurum.ZAMANINDA_TAM;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepSave(foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD>), typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>));
        }

        public static void TaahhutKontrol(AV001_TI_BIL_FOY foy)
        {
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>));

            AV001_TI_BIL_BORCLU_TAAHHUT_MASTER masterTaahhut = foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection.Find(AV001_TI_BIL_BORCLU_TAAHHUT_MASTERColumn.GECERLI_MI, true);

            TaahhutKontrol(foy, masterTaahhut);
        }

        public static void TaahhutKontrolGenel(AV001_TI_BIL_FOY foy)
        {
            //İlgili Föyün Üzerinde taahhut kaydının bulunmadığını kontrol edip deepload çekiyoruz,
            if (foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection == null)
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>));
            }
            ///yukardaki kontrol sonrasında hala ilgili föy ün taahhüt kaydı yoksa geri kalan
            ///işlemlerin yapılmasına gerek kalmadığından dolayı methodun dışına
            if (foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection == null) return;

            AV001_TI_BIL_BORCLU_TAAHHUT_MASTER gecerliTaahhut = foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection.Find(AV001_TI_BIL_BORCLU_TAAHHUT_MASTERColumn.GECERLI_MI, true);

            //Geçerli taahhüt yoksa methodun dışna çıkıyoruz
            if (gecerliTaahhut == null) return;

            //katman basılınca aşşağıdaki alan açılacak 14-03
            if (!gecerliTaahhut.TAAHHUT_IHLAL_TARIHI.HasValue)
            {
                foreach (AV001_TI_BIL_BORCLU_TAAHHUT_CHILD child in gecerliTaahhut.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection)
                {
                    if (!child.DURUM_ID.HasValue)
                        child.DURUM_ID = (int)TaahhutDurumuDegerlendir(child);

                    FaizIsletimTipi faizTipi = (FaizIsletimTipi)(gecerliTaahhut.FAIZ_ISTETIM_TIPI ?? 0);

                    if (faizTipi == FaizIsletimTipi.Temerrut_itibariyle_3_Aylik_devrelerde_faiz_anaparaya_ilave_edilsin
                        || faizTipi == FaizIsletimTipi.Temerrut_itibariyle_aylik_faiz_anaparaya_ilave_edilsin
                        || faizTipi == FaizIsletimTipi.Temerrut_itibariyle_yillik_faiz_anaparaya_ilave_edilsin)
                    {
                        if (child.DURUM_ID.HasValue)
                        {
                            TaahhutDurum durum = (TaahhutDurum)child.DURUM_ID.Value;
                            bool ihlalDurumu = IhlalDurumu(durum);
                            if (ihlalDurumu)
                            {
                                //Katman Basılınca Devreye Sokulacak 14-03
                                if (!gecerliTaahhut.TAAHHUT_IHLAL_TARIHI.HasValue)
                                {
                                    gecerliTaahhut.TAAHHUT_IHLAL_TARIHI = DateTime.Now;
                                }
                                FaiziAnaParayaEkle(foy, faizTipi, gecerliTaahhut.TAAHHUT_IHLAL_TARIHI.Value);
                            }
                        }
                    }
                    else if (faizTipi == FaizIsletimTipi.Ay_sonlarinda_aylik_faiz_anaparaya_ilave_edilsin
                        || faizTipi == FaizIsletimTipi.Uc_Aylik_Standart_devrelerde_faiz_anaparaya_ilave_edilsin
                        || faizTipi == FaizIsletimTipi.Yil_sonlari_itibariyle_yillik_faiz_anaparaya_ilave_edilsin)
                    {
                        //Taahhüt ihlal durumu aranmaksızın işlem yapılacak
                    }
                    else if (faizTipi == FaizIsletimTipi.Faiz_basit_usulde_hesaplansin)
                    {
                        //Müdahele yok yola devam
                    }
                }
            }
        }

        private static bool IhlalDurumu(TaahhutDurum durum)
        {
            bool ihlalDurumu = false;
            switch (durum)
            {
                case TaahhutDurum.ZAMANINDA_EKSIK:
                    ihlalDurumu = true;
                    break;

                case TaahhutDurum.ZAMANINDAN_SONRA_EKSIK:
                    ihlalDurumu = true;
                    break;

                case TaahhutDurum.ZAMANINDAN_SONRA_TAM:
                    ihlalDurumu = true;
                    break;

                case TaahhutDurum.ZAMANINDA_ODEME_YOK:
                    ihlalDurumu = true;
                    break;

                default:
                    ihlalDurumu = false;
                    break;
            }
            return ihlalDurumu;
        }

        private static TaahhutDurum TaahhutDurumuDegerlendir(AV001_TI_BIL_BORCLU_TAAHHUT_CHILD child)
        {
            ParaVeDovizId odemeMiktari = new ParaVeDovizId(child.ODEME_MIKTARI, child.ODEME_MIKTARI_DOVIZ_ID);
            ParaVeDovizId taahhutMiktari = new ParaVeDovizId(child.TAAHHUT_MIKTARI, child.TAAHHUT_MIKTARI_DOVIZ_ID);
            TaahhutDurum durumu = TaahhutDurum.IHLAL_YOK;

            if (child.TAAHHUTU_YERINE_GETIRME_TARIHI.Year == DateTime.Now.Year &&
                     child.TAAHHUTU_YERINE_GETIRME_TARIHI.Month == DateTime.Now.Month &&
                     child.TAAHHUTU_YERINE_GETIRME_TARIHI.Day == DateTime.Now.Day)
            {
                if (odemeMiktari.YtlHali == 0)
                    durumu = TaahhutDurum.ZAMANINDA_ODEME_YOK;
                else if (odemeMiktari.YtlHali >= taahhutMiktari.YtlHali)
                    durumu = TaahhutDurum.ZAMANINDA_TAM;
                else if (odemeMiktari.YtlHali < taahhutMiktari.YtlHali)
                    durumu = TaahhutDurum.ZAMANINDA_EKSIK;
            }
            else if (child.TAAHHUTU_YERINE_GETIRME_TARIHI > DateTime.Now)
            {
                if (odemeMiktari.YtlHali > taahhutMiktari.YtlHali)
                    durumu = TaahhutDurum.ZAMANINDAN_ONCE_TAM;
                else if (odemeMiktari.YtlHali < taahhutMiktari.YtlHali)
                    durumu = TaahhutDurum.ZAMANINDAN_ONCE_EKSIK;
            }
            else if (child.TAAHHUTU_YERINE_GETIRME_TARIHI < DateTime.Now)
            {
                if (odemeMiktari.YtlHali >= taahhutMiktari.YtlHali)
                    durumu = TaahhutDurum.ZAMANINDAN_SONRA_TAM;
                else if (odemeMiktari.YtlHali < taahhutMiktari.YtlHali)
                    durumu = TaahhutDurum.ZAMANINDAN_SONRA_EKSIK;
            }

            return durumu;
        }

        #endregion
    }
}