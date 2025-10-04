using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AvukatProLib.Hesap
{
    public class Hesap
    {
        public static bool Hesaplansinmi = true;

        public class AlacakKalemi
        {
            #region ctor

            public AlacakKalemi(DateTime takipTarihi, int birYilKAcGun)
            {
                this.OdemeFeragatDagilimlari = new TList<AV001_TI_BIL_ODEME_DAGILIM>();
                this.FaizKalemleri = new TList<AV001_TI_BIL_FAIZ>();
                this.FaizHesapla =
                this.KDVHesaplansin =
                this.KKDFHesapla =
                this.OIVHesapla =
                this.BSMVHesapla = false;
                this.TakipTarihi = takipTarihi;
                this.BirYilKacGun = birYilKAcGun;
            }

            public AlacakKalemi(AV001_TI_BIL_ALACAK_NEDEN aNeden, DateTime takipTarihi, int birYilKAcGun)
                : this(takipTarihi, birYilKAcGun)
            {
                try
                {
                    if (aNeden.AV001_TI_BIL_ODEME_DAGILIMCollection.Count == 0)
                    {
                        DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(aNeden, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));
                    }
                    DataRepository.AV001_TI_BIL_ODEME_DAGILIMProvider.Delete(aNeden.AV001_TI_BIL_ODEME_DAGILIMCollection);
                    aNeden.AV001_TI_BIL_ODEME_DAGILIMCollection.Clear();
                }
                catch 
                {
                    //Loglanacak
                }

                this.KalemTipi = AlacakKalemTipi.AsilAlacak;
                this.FaizHesapla = !aNeden.FAIZ_YOK;
                this.FaizOraniTakipOncesi = aNeden.TO_UYGULANACAK_FAIZ_ORANI;
                this.FaizOraniTakipSonrasi = aNeden.UYGULANACAK_FAIZ_ORANI;
                this.FaizTipiTakipOncesi = aNeden.TO_ALACAK_FAIZ_TIP_ID ?? 1;
                this.FaizTipiTakipSonrasi = aNeden.ALACAK_FAIZ_TIP_ID ?? 1;
                this.BSMVHesapla = aNeden.BSMV_HESAPLANSIN;
                this.OIVHesapla = aNeden.OIV_HESAPLANSIN;
                this.KKDFHesapla = aNeden.KKDV_HESAPLANSIN;
                this.KDVHesaplansin = aNeden.KDV_HESAPLANSIN;
                this.KDVTip = aNeden.KDV_TIP_ID ?? 1;
                //                this.Tutar = new ParaVeDovizId(aNeden.ISLEME_KONAN_TUTAR, aNeden.ISLEME_KONAN_TUTAR_DOVIZ_ID);
                this.AlacakKalemiTarihi = aNeden.VADE_TARIHI.Value;
                this._SonFaizHesapTarihi = aNeden.FAIZ_BASLANGIC_TARIHI;

                if (aNeden.ALACAK_NEDEN_KOD_ID.HasValue)
                {
                    var alacakNEdenAdi = DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(aNeden.ALACAK_NEDEN_KOD_ID.Value).ALACAK_NEDENI;
                    if (alacakNEdenAdi == "ÇEK")
                    {
                        aNeden.CEK_TAZMINATI = (decimal)aNeden.CEK_TAZMINATI_ORANI * aNeden.ISLEME_KONAN_TUTAR / 100;
                        aNeden.CEK_TAZMINATI_DOVIZ_ID = aNeden.ISLEME_KONAN_TUTAR_DOVIZ_ID;
                        aNeden.KOMISYONU = (decimal)aNeden.KOMISYONU_ORANI * aNeden.ISLEME_KONAN_TUTAR / 100;
                        aNeden.KOMISYONU_DOVIZ_ID = aNeden.ISLEME_KONAN_TUTAR_DOVIZ_ID ?? 1; //YTL
                        this.BSMVHesapla = false;
                        this.KKDFHesapla = false;
                        this.OIVHesapla = false;
                    }
                    else if (alacakNEdenAdi == "BONO")
                    {
                        aNeden.KOMISYONU = (decimal)aNeden.KOMISYONU_ORANI * aNeden.ISLEME_KONAN_TUTAR / 100;
                        aNeden.KOMISYONU_DOVIZ_ID = aNeden.ISLEME_KONAN_TUTAR_DOVIZ_ID ?? 1; //YTL
                        this.BSMVHesapla = false;
                        this.KKDFHesapla = false;
                        this.OIVHesapla = false;
                    }
                    else if (alacakNEdenAdi == "POLİÇE")
                    {
                        this.BSMVHesapla = false;
                        this.KKDFHesapla = false;
                        this.OIVHesapla = false;
                    }
                }
                this.Source = aNeden;
            }

            public AlacakKalemi(AV001_TDI_BIL_MASRAF_AVANS_DETAY masraf, DateTime takipTarihi, int birYilKAcGun)
                : this(takipTarihi, birYilKAcGun)
            {
                //                this.Tutar = new ParaVeDovizId(masraf.TOPLAM_TUTAR,masraf.TOPLAM_TUTAR_DOVIZ_ID);
                this.FaizHesapla = false;
                this.AlacakKalemiTarihi = masraf.TARIH;
                this.KalemTipi = AlacakKalemTipi.Masraf;
                this.Source = masraf;
            }

            public AlacakKalemi(AV001_TI_BIL_TAZMINAT tazminat, DateTime takipTarihi, int birYilKAcGun)
                : this(takipTarihi, birYilKAcGun)
            {
                this.AlacakKalemiTarihi = tazminat.TAZMINAT_BASLANGIC_TARIHI ?? this.TakipTarihi;
                this.KalemTipi = AlacakKalemTipi.Tazminatlar;
                this.Source = tazminat;
            }

            public AlacakKalemi(AV001_TI_BIL_HARC harc, DateTime takipTarihi, int birYilKAcGun)
                : this(takipTarihi, birYilKAcGun)
            {
                this.AlacakKalemiTarihi = harc.TARIFE_TARIHI;
                this.KalemTipi = AlacakKalemTipi.Harc;
                this.Source = harc;
            }

            public AlacakKalemi(AV001_TI_BIL_ALACAK_NEDEN aNeden, AvukatProLib.Arama.AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAY gayriDetay, DateTime takipTarihi, int birYilKAcGun)
                : this(takipTarihi, birYilKAcGun)
            {
                try
                {
                    if (aNeden.AV001_TI_BIL_ODEME_DAGILIMCollection.Count == 0)
                    {
                        DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(aNeden, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));
                    }
                    DataRepository.AV001_TI_BIL_ODEME_DAGILIMProvider.Delete(aNeden.AV001_TI_BIL_ODEME_DAGILIMCollection);
                    aNeden.AV001_TI_BIL_ODEME_DAGILIMCollection.Clear();
                }
                catch 
                {
                    //Loglanacak
                }

                this.KalemTipi = AlacakKalemTipi.AsilAlacak;
                this.FaizHesapla = true;
                this.FaizOraniTakipOncesi = aNeden.TO_UYGULANACAK_FAIZ_ORANI;
                this.FaizOraniTakipSonrasi = aNeden.UYGULANACAK_FAIZ_ORANI;
                this.FaizTipiTakipOncesi = aNeden.TO_ALACAK_FAIZ_TIP_ID ?? 1;
                this.FaizTipiTakipSonrasi = aNeden.ALACAK_FAIZ_TIP_ID ?? 1;
                this.BSMVHesapla = aNeden.BSMV_HESAPLANSIN;
                this.OIVHesapla = aNeden.OIV_HESAPLANSIN;
                this.KKDFHesapla = aNeden.KKDV_HESAPLANSIN;
                this.KDVHesaplansin = aNeden.KDV_HESAPLANSIN;
                this.KDVTip = aNeden.KDV_TIP_ID ?? 1;
                //                this.Tutar = new ParaVeDovizId(aNeden.ISLEME_KONAN_TUTAR, aNeden.ISLEME_KONAN_TUTAR_DOVIZ_ID);
                this.AlacakKalemiTarihi = gayriDetay.TAZMIN_TARIHI.Value;
                this._SonFaizHesapTarihi = aNeden.FAIZ_BASLANGIC_TARIHI;

                this.GayriDetay = gayriDetay;
                this.Source = aNeden;
            }

            private AlacakKalemi(AV001_TI_BIL_ILAM_MAHKEMESI ilam, IlamKalemi ilamKalemi, DateTime takipTarihi, int birYilKAcGun)
                : this(takipTarihi, birYilKAcGun)
            {
                switch (ilamKalemi)
                {
                    #region İnkar Tazminatı

                    case IlamKalemi.INKAR_TAZMINATI:
                        //this.Tutar = new ParaVeDovizId(ilam.INKAR_TAZMINATI, ilam.INKAR_TAZMINATI_DOVIZ_ID);
                        this.FaizHesapla = ilam.INKAR_TAZMINAT_FAIZ_ISLESIN_MI;
                        this.FaizOraniTakipOncesi = this.FaizOraniTakipSonrasi = ilam.INKAR_TAZMINAT_FAIZ_ORANI;
                        this.FaizTipiTakipOncesi = this.FaizTipiTakipSonrasi = ilam.INKAR_TAZMINAT_FAIZ_TIP_ID ?? 1;
                        this.KalemTipi = AlacakKalemTipi.Ilam_InkarTazminati;
                        break;

                    #endregion İnkar Tazminatı

                    #region Yargılama Gideri

                    case IlamKalemi.YARGILAMA_GIDERI:
                        //                        this.Tutar = new ParaVeDovizId(ilam.YARGILAMA_GIDERI, ilam.YARGILAMA_GIDERI_DOVIZ_ID);
                        this.FaizHesapla = ilam.YARGILAMA_GIDERI_FAIZ_ISLESIN_MI;
                        this.FaizOraniTakipOncesi = this.FaizOraniTakipSonrasi = ilam.YARGILAMA_GIDERI_FAIZ_ORANI ?? 0;
                        this.FaizTipiTakipOncesi = this.FaizTipiTakipSonrasi = ilam.YARGILAMA_GIDERI_FAIZ_TIP_ID ?? 1;
                        this.KalemTipi = AlacakKalemTipi.Ilam_YargilamaGideri;
                        break;

                    #endregion Yargılama Gideri

                    #region Bakiye Karar Harcı

                    case IlamKalemi.BAKIYE_KARAR_HARCI:
                        //                        this.Tutar = new ParaVeDovizId(ilam.BAKIYE_KARAR_HARCI, ilam.BAKIYE_KARAR_HARCI_DOVIZ_ID);
                        this.FaizHesapla = ilam.BAKIYE_KARAR_HARCI_FAIZ_ISLESIN_MI;
                        this.FaizOraniTakipOncesi = this.FaizOraniTakipSonrasi = ilam.BAKIYE_KARAR_HARCI_FAIZ_ORANI ?? 0;
                        this.FaizTipiTakipOncesi = this.FaizTipiTakipSonrasi = ilam.BAKIYE_KARAR_HARCI_FAIZ_TIP_ID ?? 1;
                        this.KalemTipi = AlacakKalemTipi.Ilam_BakiyeKararHarci;
                        break;

                    #endregion Bakiye Karar Harcı

                    #region Yargıtay Onama Harcı

                    case IlamKalemi.YARGITAY_ONAMA_HARCI:
                        //                        this.Tutar = new ParaVeDovizId(ilam.YARGITAY_ONAMA_HARCI, ilam.YARGITAY_ONAMA_HARCI_DOVIZ_ID);
                        this.FaizHesapla = ilam.YARGITAY_ONAMA_HARCI_FAIZ_ISLESIN_MI;
                        this.FaizOraniTakipOncesi = this.FaizOraniTakipSonrasi = ilam.YARGITAY_ONAMA_HARCI_FAIZ_ORANI ?? 0;
                        this.FaizTipiTakipOncesi = this.FaizTipiTakipSonrasi = ilam.YARGITAY_ONAMA_HARCI_FAIZ_TIP_ID ?? 1;
                        this.KalemTipi = AlacakKalemTipi.Ilam_YargitayOnamaHarci;
                        break;

                    #endregion Yargıtay Onama Harcı

                    #region İlam Vekalet Ücreti

                    case IlamKalemi.ILAM_VEKALET_UCRETI:
                        //                        this.Tutar = new ParaVeDovizId(ilam.ILAM_VEKALET_UCRETI, ilam.ILAM_VEKALET_UCRETI_DOVIZ_ID);
                        this.FaizHesapla = ilam.ILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI;
                        this.FaizOraniTakipOncesi = this.FaizOraniTakipSonrasi = ilam.ILAM_VEKALET_UCRET_FAIZ_ORANI ?? 0;
                        this.FaizTipiTakipOncesi = this.FaizTipiTakipSonrasi = ilam.ILAM_VEKALET_UCRET_FAIZ_TIP_ID ?? 1;
                        this.KalemTipi = AlacakKalemTipi.Ilam_VekaletUcreti;
                        break;

                    #endregion İlam Vekalet Ücreti

                    #region İlam Tebliğ Gideri

                    case IlamKalemi.ILAM_TEBLIG_GIDERI:
                        //                        this.Tutar = new ParaVeDovizId(ilam.ILAM_TEBLIG_GIDERI, ilam.ILAM_TEBLIG_GIDERI_DOVIZ_ID);
                        this.FaizHesapla = ilam.ILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI;
                        this.FaizOraniTakipOncesi = this.FaizOraniTakipSonrasi = ilam.ILAM_TEBLIG_GIDER_FAIZ_ORANI ?? 0;
                        this.FaizTipiTakipOncesi = this.FaizTipiTakipSonrasi = ilam.ILAM_TEBLIG_GIDER_FAIZ_TIP_ID ?? 1;
                        this.KalemTipi = AlacakKalemTipi.Ilam_TebligGideri;
                        break;

                    #endregion İlam Tebliğ Gideri
                }

                this.AlacakKalemiTarihi = ilam.KARAR_TARIHI.Value;

                this.Source = ilam;
            }

            private AlacakKalemi(AV001_TI_BIL_FOY foy, DigerKalemler dk)
                : this(foy.TAKIP_TARIHI.Value, (int)foy.BIR_YIL_KAC_GUN)
            {
                this.Source = foy;

                switch (dk)
                {
                    case DigerKalemler.ILK_TEBLIGAT_GIDERI:
                        this.KalemTipi = AlacakKalemTipi.ILK_TEBLIGAT_GIDERI;
                        this.FaizHesapla = false;
                        break;

                    case DigerKalemler.DEPO_HARCI:
                        this.KalemTipi = AlacakKalemTipi.DEPO_HARCI;
                        this.FaizHesapla = false;
                        break;

                    default:
                        break;
                }
            }

            private AlacakKalemi(AV001_TI_BIL_FOY foy, OzelTutar ot)
                : this(foy.TAKIP_TARIHI.Value, (int)foy.BIR_YIL_KAC_GUN)
            {
                this.Source = foy;
                switch (ot)
                {
                    case OzelTutar.Bir:
                        this.KalemTipi = AlacakKalemTipi.OzelTutarlar1;
                        this.FaizHesapla = foy.OZEL_TUTAR1_FAIZ_ISLESINMI;
                        this.FaizTipiTakipOncesi = this.FaizTipiTakipSonrasi = foy.OZEL_TUTAR1_FAIZ_TIP_ID ?? 1;
                        this.FaizOraniTakipOncesi = this.FaizOraniTakipSonrasi = foy.OZEL_TUTAR1_FAIZ_ORANI;
                        if (foy.OZEL_TUTAR1_FAIZ_BASLANGIC_TARIHI.HasValue)
                            this.AlacakKalemiTarihi = (DateTime)foy.OZEL_TUTAR1_FAIZ_BASLANGIC_TARIHI;
                        break;

                    case OzelTutar.Iki:
                        this.KalemTipi = AlacakKalemTipi.OzelTutarlar2;
                        this.FaizHesapla = foy.OZEL_TUTAR2_FAIZ_ISLESINMI;
                        this.FaizTipiTakipOncesi = this.FaizTipiTakipSonrasi = foy.OZEL_TUTAR2_FAIZ_TIP_ID ?? 1;
                        this.FaizOraniTakipOncesi = this.FaizOraniTakipSonrasi = foy.OZEL_TUTAR2_FAIZ_ORANI;
                        if (foy.OZEL_TUTAR2_FAIZ_BASLANGIC_TARIHI.HasValue)
                            this.AlacakKalemiTarihi = (DateTime)foy.OZEL_TUTAR2_FAIZ_BASLANGIC_TARIHI;
                        break;

                    case OzelTutar.Uc:
                        this.KalemTipi = AlacakKalemTipi.OzelTutarlar3;
                        this.FaizHesapla = foy.OZEL_TUTAR3_FAIZ_ISLESINMI;
                        this.FaizTipiTakipOncesi = this.FaizTipiTakipSonrasi = foy.OZEL_TUTAR3_FAIZ_TIP_ID ?? 1;
                        this.FaizOraniTakipOncesi = this.FaizOraniTakipSonrasi = foy.OZEL_TUTAR3_FAIZ_ORANI;
                        if (foy.OZEL_TUTAR3_FAIZ_BASLANGIC_TARIHI.HasValue)
                            this.AlacakKalemiTarihi = (DateTime)foy.OZEL_TUTAR3_FAIZ_BASLANGIC_TARIHI;
                        break;

                    case OzelTutar.OzelTazminat:
                        this.KalemTipi = AlacakKalemTipi.OzelTazminat;
                        this.FaizHesapla = foy.OZEL_TAZMINAT_FAIZ_ISLESINMI;
                        this.FaizTipiTakipOncesi = this.FaizTipiTakipSonrasi = foy.OZEL_TAZMINAT_DOVIZ_ID ?? 1;
                        this.FaizOraniTakipOncesi = this.FaizOraniTakipSonrasi = foy.OZEL_TAZMINAT_FAIZ_ORANI;
                        if (foy.OZEL_TAZMINAT_FAIZ_BASLANGIC_TARIHI.HasValue)
                            this.AlacakKalemiTarihi = (DateTime)foy.OZEL_TAZMINAT_FAIZ_BASLANGIC_TARIHI;
                        break;
                }

                //var ilkTarih = foy.AV001_TI_BIL_ALACAK_NEDENCollection.OrderBy(vi => vi.VADE_TARIHI).FirstOrDefault().VADE_TARIHI;

                //if (ilkTarih.HasValue)
                //    this.AlacakKalemiTarihi = ilkTarih.Value;
                //else
                //this.AlacakKalemiTarihi = foy.OZEL_TUTAR1_FAIZ_BASLANGIC_TARIHI;
            }

            private AlacakKalemi(AV001_TI_BIL_FOY foy, VekaletKalemleri vk)
                : this(foy.TAKIP_TARIHI.Value, (int)foy.BIR_YIL_KAC_GUN)
            {
                this.FaizHesapla = false;
                DateTime? ilkTarih = null;
                if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count > 0)
                    ilkTarih = foy.AV001_TI_BIL_ALACAK_NEDENCollection.OrderBy(vi => vi.VADE_TARIHI).FirstOrDefault().VADE_TARIHI;

                if (ilkTarih.HasValue)
                    this.AlacakKalemiTarihi = ilkTarih.Value;
                else
                    this.AlacakKalemiTarihi = foy.FAIZ_BASLANGIC_TARIHI ?? this.TakipTarihi;

                switch (vk)
                {
                    case VekaletKalemleri.DAVA_VEKALET_UCRETI:
                        this.AlacakKalemiTarihi = this.TakipTarihi;
                        this.KalemTipi = AlacakKalemTipi.DAVA_VEKALET_UCRETI;
                        break;

                    case VekaletKalemleri.DEPO_VEKALET_UCRETI:
                        this.AlacakKalemiTarihi = this.TakipTarihi;
                        this.KalemTipi = AlacakKalemTipi.DEPO_VEKALET_UCRETI;
                        break;

                    case VekaletKalemleri.IH_VEKALET_UCRETI:
                        this.KalemTipi = AlacakKalemTipi.IH_VEKALET_UCRETI;
                        break;

                    case VekaletKalemleri.IT_VEKALET_UCRETI:
                        this.KalemTipi = AlacakKalemTipi.IT_VEKALET_UCRETI;
                        break;

                    case VekaletKalemleri.TAHLIYE_VEK_UCR:
                        this.AlacakKalemiTarihi = this.TakipTarihi;
                        this.KalemTipi = AlacakKalemTipi.TAHLIYE_VEK_UCR;
                        break;

                    case VekaletKalemleri.TD_VEK_UCR:
                        this.KalemTipi = AlacakKalemTipi.TD_VEK_UCR;
                        break;

                    case VekaletKalemleri.TAKIP_VEKALET_UCRETI:
                        this.KalemTipi = AlacakKalemTipi.TAKIP_VEKALET_UCRETI;
                        break;

                    default:
                        break;
                }

                this.Source = foy;
            }

            #endregion ctor

            public static List<AlacakKalemi> DigerKalem(AV001_TI_BIL_FOY foy)
            {
                List<AlacakKalemi> liste = new List<AlacakKalemi>();
                if (foy.ILK_TEBLIGAT_GIDERI > 0)
                {
                    AlacakKalemi ak = new AlacakKalemi(foy, DigerKalemler.ILK_TEBLIGAT_GIDERI);
                    liste.Add(ak);
                }
                if (foy.DEPO_HARCI > 0)
                {
                    liste.Add(new AlacakKalemi(foy, DigerKalemler.DEPO_HARCI));
                }

                return liste;
            }

            public static List<AlacakKalemi> IlamAlacakKalemleri(AV001_TI_BIL_ILAM_MAHKEMESI ilam, DateTime takipTarihi, int birYilKacGun)
            {
                List<AlacakKalemi> kalemler = new List<AlacakKalemi>();
                if (ilam.ILAM_TEBLIG_GIDERI > 0) kalemler.Add(new AlacakKalemi(ilam, IlamKalemi.ILAM_TEBLIG_GIDERI, takipTarihi, birYilKacGun));
                if (ilam.BAKIYE_KARAR_HARCI > 0) kalemler.Add(new AlacakKalemi(ilam, IlamKalemi.BAKIYE_KARAR_HARCI, takipTarihi, birYilKacGun));
                if (ilam.ILAM_VEKALET_UCRETI > 0) kalemler.Add(new AlacakKalemi(ilam, IlamKalemi.ILAM_VEKALET_UCRETI, takipTarihi, birYilKacGun));
                if (ilam.INKAR_TAZMINATI > 0) kalemler.Add(new AlacakKalemi(ilam, IlamKalemi.INKAR_TAZMINATI, takipTarihi, birYilKacGun));
                if (ilam.YARGILAMA_GIDERI > 0) kalemler.Add(new AlacakKalemi(ilam, IlamKalemi.YARGILAMA_GIDERI, takipTarihi, birYilKacGun));
                if (ilam.YARGITAY_ONAMA_HARCI > 0) kalemler.Add(new AlacakKalemi(ilam, IlamKalemi.YARGITAY_ONAMA_HARCI, takipTarihi, birYilKacGun));

                return kalemler;
            }

            public static List<AlacakKalemi> OzelTutarAlacakKalemi(AV001_TI_BIL_FOY foy)
            {
                List<AlacakKalemi> liste = new List<AlacakKalemi>();
                if (foy.OZEL_TUTAR1 > 0)
                {
                    AlacakKalemi ak = new AlacakKalemi(foy, OzelTutar.Bir);
                    liste.Add(ak);
                }
                if (foy.OZEL_TUTAR2 > 0)
                {
                    AlacakKalemi ak = new AlacakKalemi(foy, OzelTutar.Iki);
                    liste.Add(ak);
                }
                if (foy.OZEL_TUTAR3 > 0)
                {
                    AlacakKalemi ak = new AlacakKalemi(foy, OzelTutar.Uc);
                    liste.Add(ak);
                }
                if (foy.OZEL_TAZMINAT > 0)
                {
                    AlacakKalemi ak = new AlacakKalemi(foy, OzelTutar.OzelTazminat);
                    liste.Add(ak);
                }

                return liste;
            }

            public static List<AlacakKalemi> VekaletAlacakKalemleri(AV001_TI_BIL_FOY foy)
            {
                List<AlacakKalemi> liste = new List<AlacakKalemi>();

                if (foy.DAVA_VEKALET_UCRETI > 0)
                    liste.Add(new AlacakKalemi(foy, VekaletKalemleri.DAVA_VEKALET_UCRETI));
                if (foy.DEPO_VEKALET_UCRETI > 0)
                    liste.Add(new AlacakKalemi(foy, VekaletKalemleri.DEPO_VEKALET_UCRETI));
                if (foy.IH_VEKALET_UCRETI > 0)
                    liste.Add(new AlacakKalemi(foy, VekaletKalemleri.IH_VEKALET_UCRETI));
                if (foy.IT_VEKALET_UCRETI > 0)
                    liste.Add(new AlacakKalemi(foy, VekaletKalemleri.IT_VEKALET_UCRETI));
                if (foy.TAHLIYE_VEK_UCR > 0)
                    liste.Add(new AlacakKalemi(foy, VekaletKalemleri.TAHLIYE_VEK_UCR));
                if (foy.TD_VEK_UCR > 0)
                    liste.Add(new AlacakKalemi(foy, VekaletKalemleri.TD_VEK_UCR));

                #region <MB-20101006>

                //Ödeme girildiği zaman takip vekalet ücretinin her seferinde eklenmesi faizlerin sürekli artmasına sebep olduğu için kapatıldı.
                //if (foy.TAKIP_VEKALET_UCRETI > 0)
                //    liste.Add(new AlacakKalemi(foy, VekaletKalemleri.TAKIP_VEKALET_UCRETI));

                #endregion <MB-20101006>

                return liste;
            }

            #region Enums

            public enum AlacakKalemTipi
            {
                AsilAlacak = 1,
                Masraf, //Faiz İşlemiyor
                Ilam_InkarTazminati,
                Ilam_YargilamaGideri,
                Ilam_BakiyeKararHarci,
                Ilam_VekaletUcreti,
                Ilam_TebligGideri,
                Ilam_YargitayOnamaHarci,
                Tazminatlar,
                OzelTutarlar1,
                OzelTutarlar2,
                OzelTutarlar3,
                DAVA_VEKALET_UCRETI,
                DEPO_VEKALET_UCRETI,
                IH_VEKALET_UCRETI,
                IT_VEKALET_UCRETI,
                TAHLIYE_VEK_UCR,
                TD_VEK_UCR,
                TAKIP_VEKALET_UCRETI,
                ILK_TEBLIGAT_GIDERI,
                Harc,
                OzelTazminat,
                DEPO_HARCI,
                HesaplanmisKalemler = 1
            }

            public enum OdemeDus
            {
                Alacak,
                Faiz
            }

            private enum DigerKalemler
            {
                ILK_TEBLIGAT_GIDERI, DEPO_HARCI
            }

            private enum IlamKalemi
            {
                INKAR_TAZMINATI,
                YARGILAMA_GIDERI,
                BAKIYE_KARAR_HARCI,
                YARGITAY_ONAMA_HARCI,
                ILAM_VEKALET_UCRETI,
                ILAM_TEBLIG_GIDERI
            }

            private enum OzelTutar
            {
                Bir, Iki, Uc, OzelTazminat
            }

            private enum VekaletKalemleri
            {
                DAVA_VEKALET_UCRETI,
                DEPO_VEKALET_UCRETI,
                IH_VEKALET_UCRETI,
                IT_VEKALET_UCRETI,
                TAHLIYE_VEK_UCR,
                TD_VEK_UCR,
                TAKIP_VEKALET_UCRETI
            }

            #endregion Enums

            #region Properties

            private int _BirYilKacGun = 365;

            private DateTime? _SonFaizHesapTarihi = null;

            public DateTime AlacakKalemiTarihi { get; set; }

            public int BirYilKacGun
            {
                get { return _BirYilKacGun; }
                set { _BirYilKacGun = value; }
            }

            public bool BSMVHesapla { get; set; }

            public bool FaizHesapla { get; set; }

            public TList<AV001_TI_BIL_FAIZ> FaizKalemleri { get; set; }

            public double FaizOraniTakipOncesi { get; set; }

            public double FaizOraniTakipSonrasi { get; set; }

            public int FaizTipiTakipOncesi { get; set; }

            public int FaizTipiTakipSonrasi { get; set; }

            public AvukatProLib.Arama.AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAY GayriDetay { get; set; }

            public AlacakKalemTipi KalemTipi { get; set; }

            public bool KDVHesaplansin { get; set; }

            public int KDVTip { get; set; }

            public bool KKDFHesapla { get; set; }

            public TList<AV001_TI_BIL_ODEME_DAGILIM> OdemeFeragatDagilimlari { get; set; }

            public ParaVeDovizId OdemeToplamiBSMV
            {
                get
                {
                    int[] dizi = new int[] { 38, 44 };
                    return ParaVeDovizId.Topla(OdemeFeragatDagilimlari
                        .Where(vi => dizi.Contains(vi.MAHSUP_ALT_KATEGORI_ID))
                        .Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());
                }
            }

            public ParaVeDovizId OdemeToplamiCekKomisyonu
            {
                get
                {
                    int[] dizi = new int[] { 24 };
                    return ParaVeDovizId.Topla(OdemeFeragatDagilimlari
                        .Where(vi => dizi.Contains(vi.MAHSUP_ALT_KATEGORI_ID))
                        .Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());
                }
            }

            public ParaVeDovizId OdemeToplamiCekTazminati
            {
                get
                {
                    int[] dizi = new int[] { 20 };
                    return ParaVeDovizId.Topla(OdemeFeragatDagilimlari
                        .Where(vi => dizi.Contains(vi.MAHSUP_ALT_KATEGORI_ID))
                        .Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());
                }
            }

            public ParaVeDovizId OdemeToplamiFaize
            {
                get
                {
                    int[] dizi = new int[] { 8, 17 };
                    return ParaVeDovizId.Topla(OdemeFeragatDagilimlari
                        .Where(vi => dizi.Contains(vi.MAHSUP_KATEGORI_ID))
                        .Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());
                }
            }

            public ParaVeDovizId OdemeToplamiIhtarGideri
            {
                get
                {
                    int[] dizi = new int[] { 29, 59 };
                    return ParaVeDovizId.Topla(OdemeFeragatDagilimlari
                        .Where(vi => dizi.Contains(vi.MAHSUP_ALT_KATEGORI_ID))
                        .Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());
                }
            }

            public ParaVeDovizId OdemeToplamiKDV
            {
                get
                {
                    int[] dizi = new int[] { 41, 46 };
                    return ParaVeDovizId.Topla(OdemeFeragatDagilimlari
                        .Where(vi => dizi.Contains(vi.MAHSUP_ALT_KATEGORI_ID))
                        .Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());
                }
            }

            public ParaVeDovizId OdemeToplamiKKDF
            {
                get
                {
                    return ParaVeDovizId.Topla(OdemeFeragatDagilimlari
                        .Where(vi => vi.MAHSUP_ALT_KATEGORI_ID == 39)
                        .Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());
                }
            }

            public ParaVeDovizId OdemeToplamiOIV
            {
                get
                {
                    int[] dizi = new int[] { 40, 45 };
                    return ParaVeDovizId.Topla(OdemeFeragatDagilimlari
                        .Where(vi => dizi.Contains(vi.MAHSUP_ALT_KATEGORI_ID))
                        .Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());
                }
            }

            public ParaVeDovizId OdemeToplamiProtestoGideri
            {
                get
                {
                    int[] dizi = new int[] { 28, 60 };
                    return ParaVeDovizId.Topla(OdemeFeragatDagilimlari
                        .Where(vi => dizi.Contains(vi.MAHSUP_ALT_KATEGORI_ID))
                        .Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());
                }
            }

            public ParaVeDovizId OdemeToplamiTutara
            {
                get
                {
                    int[] dizi = new int[] { 8, 17, };
                    int[] diziAlt = new int[] { 29, 59, 38, 44, 39, 40, 45, 41, 46 };
                    return ParaVeDovizId.Topla(OdemeFeragatDagilimlari
                        .Where(vi => !dizi.Contains(vi.MAHSUP_KATEGORI_ID) && !diziAlt.Contains(vi.MAHSUP_ALT_KATEGORI_ID))
                        .Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());
                }
            }

            public bool OIVHesapla { get; set; }

            public DateTime SonFaizHesapTarihi
            {
                set
                {
                    _SonFaizHesapTarihi = value;
                }
                get
                {
                    if (FaizKalemleri.Count > 0)
                    {
                        return FaizKalemleri.OrderByDescending(vi => vi.FAIZ_BITIS_TARIHI)
                            .FirstOrDefault()
                            .FAIZ_BITIS_TARIHI ?? (this._SonFaizHesapTarihi ?? this.AlacakKalemiTarihi);
                    }

                    return this._SonFaizHesapTarihi ?? this.AlacakKalemiTarihi;
                }
            }

            public object Source { get; set; }

            public DateTime TakipTarihi { get; set; }

            public ParaVeDovizId Tutar
            {
                get
                {
                    return ParaVeDovizId.Cikart(GetTutar(), OdemeToplamiTutara);
                }
            }

            public ParaVeDovizId TutarBSMV
            {
                get
                {
                    return ParaVeDovizId.Cikart(
                        ParaVeDovizId.Topla(this.FaizKalemleri.Select(vi => new ParaVeDovizId(vi.BSMV_TUTARI, vi.BSMV_DOVIZ_ID)).ToList()),
                        OdemeToplamiBSMV);
                }
            }

            public ParaVeDovizId TutarCekKomisyonu
            {
                get
                {
                    if (this.KalemTipi == AlacakKalemTipi.AsilAlacak)
                    {
                        var alacak = this.Source as AV001_TI_BIL_ALACAK_NEDEN;
                        if (alacak != null)
                        {
                            return ParaVeDovizId.Cikart(new ParaVeDovizId(alacak.KOMISYONU, alacak.KOMISYONU_DOVIZ_ID),
                                this.OdemeToplamiCekKomisyonu);
                        }
                    }
                    return new ParaVeDovizId(0, 1);
                }
            }

            public ParaVeDovizId TutarCekTazminati
            {
                get
                {
                    if (this.KalemTipi == AlacakKalemTipi.AsilAlacak)
                    {
                        var alacak = this.Source as AV001_TI_BIL_ALACAK_NEDEN;
                        if (alacak != null)
                        {
                            return ParaVeDovizId.Cikart(new ParaVeDovizId(alacak.CEK_TAZMINATI, alacak.CEK_TAZMINATI_DOVIZ_ID),
                                this.OdemeToplamiCekTazminati);
                        }
                    }
                    return new ParaVeDovizId(0, 1);
                }
            }

            public ParaVeDovizId TutarIhtarGideri
            {
                get
                {
                    if (this.KalemTipi == AlacakKalemTipi.AsilAlacak)
                    {
                        var alacak = this.Source as AV001_TI_BIL_ALACAK_NEDEN;
                        if (alacak != null)
                        {
                            return ParaVeDovizId.Cikart(new ParaVeDovizId(alacak.IHTAR_GIDERI, alacak.IHTAR_GIDERI_DOVIZ_ID),
                                this.OdemeToplamiIhtarGideri);
                        }
                    }
                    return new ParaVeDovizId(0, 1);
                }
            }

            public ParaVeDovizId TutariFaiz
            {
                get
                {
                    return ParaVeDovizId.Cikart(
                        ParaVeDovizId.Topla(this.FaizKalemleri.Select(vi => new ParaVeDovizId(vi.FAIZ_TUTARI, vi.FAIZ_TUTARI_DOVIZ_ID)).ToList()),
                        OdemeToplamiFaize);
                }
            }

            public ParaVeDovizId TutarKDV
            {
                get
                {
                    return ParaVeDovizId.Cikart(
                        ParaVeDovizId.Topla(this.FaizKalemleri.Select(vi => new ParaVeDovizId(vi.KDV_TUTARI, vi.KDV_DOVIZ_ID)).ToList()),
                        OdemeToplamiKDV);
                }
            }

            public ParaVeDovizId TutarKKDF
            {
                get
                {
                    return ParaVeDovizId.Cikart(
                        ParaVeDovizId.Topla(this.FaizKalemleri.Select(vi => new ParaVeDovizId(vi.KKDF_TUTARI, vi.KKDF_DOVIZ_ID)).ToList()),
                        OdemeToplamiKKDF);
                }
            }

            public ParaVeDovizId TutarOIV
            {
                get
                {
                    return ParaVeDovizId.Cikart(
                        ParaVeDovizId.Topla(this.FaizKalemleri.Select(vi => new ParaVeDovizId(vi.OIV_TUTARI, vi.OIV_DOVIZ_ID)).ToList()),
                        OdemeToplamiOIV);
                }
            }

            public ParaVeDovizId TutarProtestoGideri
            {
                get
                {
                    if (this.KalemTipi == AlacakKalemTipi.AsilAlacak)
                    {
                        var alacak = this.Source as AV001_TI_BIL_ALACAK_NEDEN;
                        if (alacak != null)
                        {
                            return ParaVeDovizId.Cikart(new ParaVeDovizId(alacak.PROTESTO_GIDERI, alacak.PROTESTO_GIDERI_DOVIZ_ID),
                                this.OdemeToplamiProtestoGideri);
                        }
                    }
                    return new ParaVeDovizId(0, 1);
                }
            }

            #endregion Properties

            #region Methots

            public TList<AV001_TI_BIL_ODEME_DAGILIM> EkleOdeme(AV001_TI_BIL_BORCLU_ODEME odeme, MahsupKategori mahsupKategori, Takip takip)
            {
                if (odeme.ODEME_TARIHI.Date < this.AlacakKalemiTarihi.Date)
                    return new TList<AV001_TI_BIL_ODEME_DAGILIM>();

                var dagitilanOdemelerToplami = ParaVeDovizId.Topla(odeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());

                var kalanOdeme = ParaVeDovizId.Cikart(new ParaVeDovizId(odeme.ODEME_MIKTAR, odeme.ODEME_MIKTAR_DOVIZ_ID, odeme.ODEME_TARIHI), dagitilanOdemelerToplami);

                if (kalanOdeme.Para <= 0)
                    return new TList<AV001_TI_BIL_ODEME_DAGILIM>();

                if (this.SonFaizHesapTarihi.Date < odeme.ODEME_TARIHI.Date)
                    this.FaizIsle(this.SonFaizHesapTarihi, odeme.ODEME_TARIHI, takip);

                TList<AV001_TI_BIL_ODEME_DAGILIM> liste = new TList<AV001_TI_BIL_ODEME_DAGILIM>();

                switch (mahsupKategori)
                {
                    case MahsupKategori.Faizler:

                        #region Faizler

                        if (this.TutariFaiz.Para > 0)
                        {
                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori,
                                takip == Takip.Oncesi ? MahsupAltKategori.Islemis_Faiz : MahsupAltKategori.Sonraki_Faiz,
                                this.TutariFaiz, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion Faizler

                        break;

                    case MahsupKategori.Asil_Alacak:
                    case MahsupKategori.Harclar:

                        #region Asıl Alacak

                        if (this.Tutar.Para > 0)
                        {
                            var mahsupAltKat = MahsupAltKategori.Alacak_Neden;
                            if (mahsupKategori == MahsupKategori.Harclar)
                                mahsupAltKat = MahsupAltKategori.Diger_Giderler;

                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori,
                                mahsupAltKat,
                                this.Tutar, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion Asıl Alacak

                        break;

                    case MahsupKategori.Vergiler:

                        #region BSMV

                        if (this.TutarBSMV.Para > 0)
                        {
                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme,
                                mahsupKategori, takip == Takip.Oncesi ? MahsupAltKategori.TO_BSMV : MahsupAltKategori.TS_BSMV,
                                this.TutarBSMV, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion BSMV

                        #region KDV

                        if (this.TutarKDV.Para > 0)
                        {
                            dagitilanOdemelerToplami = ParaVeDovizId.Topla(odeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());

                            kalanOdeme = ParaVeDovizId.Cikart(new ParaVeDovizId(odeme.ODEME_MIKTAR, odeme.ODEME_MIKTAR_DOVIZ_ID), dagitilanOdemelerToplami);

                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori,
                                 takip == Takip.Oncesi ? MahsupAltKategori.TO_KDV : MahsupAltKategori.TS_KDV,
                                this.TutarKDV, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion KDV

                        #region KKDF

                        if (this.TutarKKDF.Para > 0)
                        {
                            dagitilanOdemelerToplami = ParaVeDovizId.Topla(odeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());

                            kalanOdeme = ParaVeDovizId.Cikart(new ParaVeDovizId(odeme.ODEME_MIKTAR, odeme.ODEME_MIKTAR_DOVIZ_ID), dagitilanOdemelerToplami);

                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori, MahsupAltKategori.TO_KKDF, this.TutarKKDF, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion KKDF

                        #region OIV

                        if (this.TutarOIV.Para > 0)
                        {
                            dagitilanOdemelerToplami = ParaVeDovizId.Topla(odeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());

                            kalanOdeme = ParaVeDovizId.Cikart(new ParaVeDovizId(odeme.ODEME_MIKTAR, odeme.ODEME_MIKTAR_DOVIZ_ID), dagitilanOdemelerToplami);

                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori,
                                takip == Takip.Oncesi ? MahsupAltKategori.TO_OIV : MahsupAltKategori.TS_OIV,
                                  this.TutarOIV, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion OIV

                        #region Çek Komisyon

                        if (this.TutarCekKomisyonu.Para > 0)
                        {
                            dagitilanOdemelerToplami = ParaVeDovizId.Topla(odeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());

                            kalanOdeme = ParaVeDovizId.Cikart(new ParaVeDovizId(odeme.ODEME_MIKTAR, odeme.ODEME_MIKTAR_DOVIZ_ID), dagitilanOdemelerToplami);

                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori, MahsupAltKategori.Cek_Komisyonu, this.TutarCekKomisyonu, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion Çek Komisyon

                        break;

                    case MahsupKategori.Diger:

                        #region OzelTutarlar && ilam kalemleri

                        if (this.Tutar.Para > 0 &&
                            (this.KalemTipi == AlacakKalemTipi.OzelTutarlar1
                            || this.KalemTipi == AlacakKalemTipi.OzelTutarlar2
                            || this.KalemTipi == AlacakKalemTipi.OzelTutarlar3
                            || this.KalemTipi == AlacakKalemTipi.Ilam_BakiyeKararHarci
                            || this.KalemTipi == AlacakKalemTipi.Ilam_InkarTazminati
                            || this.KalemTipi == AlacakKalemTipi.Ilam_TebligGideri
                            || this.KalemTipi == AlacakKalemTipi.Ilam_VekaletUcreti
                            || this.KalemTipi == AlacakKalemTipi.Ilam_YargilamaGideri
                            || this.KalemTipi == AlacakKalemTipi.Ilam_YargitayOnamaHarci))
                        {
                            var mahsupEdilecek = new ParaVeDovizId();

                            if (this.Tutar.YtlHali > kalanOdeme.YtlHali)
                            {
                                mahsupEdilecek = kalanOdeme;
                            }
                            else
                            {
                                mahsupEdilecek.Para = DovizHelper.CaprazCevir(this.Tutar, kalanOdeme.DovizId,
                                                                         odeme.ODEME_TARIHI);
                                mahsupEdilecek.DovizId = kalanOdeme.DovizId;
                            }

                            var mahsupAltKat = MahsupAltKategori.Ozel_Tutar_1;

                            if (KalemTipi == AlacakKalemTipi.OzelTutarlar2)
                                mahsupAltKat = MahsupAltKategori.Ozel_Tutar_2;
                            else if (KalemTipi == AlacakKalemTipi.OzelTutarlar3)
                                mahsupAltKat = MahsupAltKategori.Ozel_Tutar_2;
                            else if (KalemTipi == AlacakKalemTipi.Ilam_BakiyeKararHarci)
                                mahsupAltKat = MahsupAltKategori.Ilam_Bakiye_Karar_Harci;
                            else if (KalemTipi == AlacakKalemTipi.Ilam_InkarTazminati)
                                mahsupAltKat = MahsupAltKategori.Ilam_Inkar_Tazminati;
                            else if (KalemTipi == AlacakKalemTipi.Ilam_TebligGideri)
                                mahsupAltKat = MahsupAltKategori.Ilam_Teblig_Gideri;
                            else if (KalemTipi == AlacakKalemTipi.Ilam_VekaletUcreti)
                                mahsupAltKat = MahsupAltKategori.Ilam_Vekalet_Ucreti;
                            else if (KalemTipi == AlacakKalemTipi.Ilam_YargilamaGideri)
                                mahsupAltKat = MahsupAltKategori.Ilam_Yargilama_Giderleri;
                            else if (KalemTipi == AlacakKalemTipi.Ilam_YargitayOnamaHarci)
                                mahsupAltKat = MahsupAltKategori.Yargitay_Onama_Harci;

                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = GetOdemeDagilim(odeme, mahsupEdilecek, mahsupKategori, mahsupAltKat);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion OzelTutarlar && ilam kalemleri

                        break;

                    case MahsupKategori.Vekalet_Ucreti:

                        #region Vekalet Ücreti

                        if (this.Tutar.Para > 0 &&
                           (this.KalemTipi == AlacakKalemTipi.DAVA_VEKALET_UCRETI
                           || this.KalemTipi == AlacakKalemTipi.DEPO_VEKALET_UCRETI
                           || this.KalemTipi == AlacakKalemTipi.IH_VEKALET_UCRETI
                           || this.KalemTipi == AlacakKalemTipi.IT_VEKALET_UCRETI
                           || this.KalemTipi == AlacakKalemTipi.TAHLIYE_VEK_UCR
                           || this.KalemTipi == AlacakKalemTipi.TAKIP_VEKALET_UCRETI
                           || this.KalemTipi == AlacakKalemTipi.TD_VEK_UCR))
                        {
                            var mahsupEdilecek = new ParaVeDovizId();

                            if (this.Tutar.YtlHali > kalanOdeme.YtlHali)
                            {
                                mahsupEdilecek = kalanOdeme;
                            }
                            else
                            {
                                mahsupEdilecek.Para = DovizHelper.CaprazCevir(this.Tutar, kalanOdeme.DovizId,
                                                                         odeme.ODEME_TARIHI);
                                mahsupEdilecek.DovizId = kalanOdeme.DovizId;
                            }

                            var mahsupAltKat = MahsupAltKategori.Dava_Vekalet_Ucreti;

                            if (KalemTipi == AlacakKalemTipi.DEPO_VEKALET_UCRETI)
                                mahsupAltKat = MahsupAltKategori.Takip_Vekalet_Ucreti;
                            else if (KalemTipi == AlacakKalemTipi.IH_VEKALET_UCRETI)
                                mahsupAltKat = MahsupAltKategori.Takip_Vekalet_Ucreti;
                            else if (KalemTipi == AlacakKalemTipi.IT_VEKALET_UCRETI)
                                mahsupAltKat = MahsupAltKategori.Ihtiyati_Tedbir_Vekalet_Ucreti;
                            else if (KalemTipi == AlacakKalemTipi.TAHLIYE_VEK_UCR)
                                mahsupAltKat = MahsupAltKategori.Tahliye_Davasi_Vekalet_Ucreti;
                            else if (KalemTipi == AlacakKalemTipi.TAKIP_VEKALET_UCRETI)
                                mahsupAltKat = MahsupAltKategori.Takip_Vekalet_Ucreti;
                            else if (KalemTipi == AlacakKalemTipi.TD_VEK_UCR)
                                mahsupAltKat = MahsupAltKategori.Tahliye_Davasi_Vekalet_Ucreti;

                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = GetOdemeDagilim(odeme, mahsupEdilecek, mahsupKategori, mahsupAltKat);
                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion Vekalet Ücreti

                        break;

                    case MahsupKategori.Masraflar:

                        #region Masraflar

                        if (this.KalemTipi == AlacakKalemTipi.Masraf && this.Tutar.Para > 0)
                        {
                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori, MahsupAltKategori.Diger_Giderler, this.Tutar, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion Masraflar

                        #region İlk Tebligat Gideri

                        if (this.KalemTipi == AlacakKalemTipi.ILK_TEBLIGAT_GIDERI)
                        {
                            var mahsupEdilecek = new ParaVeDovizId();

                            if (this.Tutar.YtlHali > kalanOdeme.YtlHali)
                            {
                                mahsupEdilecek = kalanOdeme;
                            }
                            else
                            {
                                mahsupEdilecek.Para = DovizHelper.CaprazCevir(this.Tutar, kalanOdeme.DovizId,
                                                                         odeme.ODEME_TARIHI);
                                mahsupEdilecek.DovizId = kalanOdeme.DovizId;
                            }

                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = GetOdemeDagilim(odeme, mahsupEdilecek, MahsupKategori.Masraflar, MahsupAltKategori.Ilam_Teblig_Gideri);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion İlk Tebligat Gideri

                        #region Ihtar Gideri

                        if (takip == Takip.Oncesi && this.TutarIhtarGideri.Para > 0)
                        {
                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori, MahsupAltKategori.Ihtar_Gideri, this.TutarIhtarGideri, kalanOdeme);
                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion Ihtar Gideri

                        #region Protesto Gideri

                        if (this.TutarProtestoGideri.Para > 0)
                        {
                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori, MahsupAltKategori.Protesto_Gideri, this.TutarProtestoGideri, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion Protesto Gideri

                        break;

                    case MahsupKategori.Tazminatlar:

                        #region Çek Tazminatı

                        if (this.TutarCekTazminati.Para > 0)
                        {
                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori, MahsupAltKategori.Cek_Tazminati, this.TutarCekTazminati, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }
                        if (this.KalemTipi == AlacakKalemTipi.OzelTazminat && this.Tutar.Para > 0)
                        {
                            var mahsupEdilecek = new ParaVeDovizId();

                            if (this.Tutar.YtlHali > kalanOdeme.YtlHali)
                            {
                                mahsupEdilecek = kalanOdeme;
                            }
                            else
                            {
                                mahsupEdilecek.Para = DovizHelper.CaprazCevir(this.Tutar, kalanOdeme.DovizId,
                                                                         odeme.ODEME_TARIHI);
                                mahsupEdilecek.DovizId = kalanOdeme.DovizId;
                            }

                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = GetOdemeDagilim(odeme, mahsupEdilecek, MahsupKategori.Tazminatlar, MahsupAltKategori.Ozel_Tazminat);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion Çek Tazminatı

                        break;
                }
                if (this.Source is AV001_TI_BIL_ALACAK_NEDEN)
                    (this.Source as AV001_TI_BIL_ALACAK_NEDEN).AV001_TI_BIL_ODEME_DAGILIMCollection.AddRange(liste);

                return liste;
            }

            public TList<AV001_TI_BIL_ODEME_DAGILIM> EkleOdeme(AV001_TI_BIL_FERAGAT odeme, MahsupKategori mahsupKategori, Takip takip)
            {
                if (odeme.FERAGAT_TARIHI.Date < this.AlacakKalemiTarihi.Date)
                    return new TList<AV001_TI_BIL_ODEME_DAGILIM>();

                var dagitilanOdemelerToplami = ParaVeDovizId.Topla(odeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());

                var kalanOdeme = ParaVeDovizId.Cikart(new ParaVeDovizId(odeme.FERAGAT_MIKTAR, odeme.FERAGAT_MIKTAR_DOVIZ_ID), dagitilanOdemelerToplami);

                if (kalanOdeme.Para <= 0)
                    return new TList<AV001_TI_BIL_ODEME_DAGILIM>();

                if (this.SonFaizHesapTarihi.Date < odeme.FERAGAT_TARIHI.Date)
                    this.FaizIsle(this.SonFaizHesapTarihi, odeme.FERAGAT_TARIHI, takip);

                TList<AV001_TI_BIL_ODEME_DAGILIM> liste = new TList<AV001_TI_BIL_ODEME_DAGILIM>();

                switch (mahsupKategori)
                {
                    case MahsupKategori.Faizler:

                        #region Faizler

                        if (this.TutariFaiz.Para > 0)
                        {
                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori,
                                takip == Takip.Oncesi ? MahsupAltKategori.Islemis_Faiz : MahsupAltKategori.Sonraki_Faiz,
                                this.TutariFaiz, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion Faizler

                        break;

                    case MahsupKategori.Asil_Alacak:
                    case MahsupKategori.Harclar:

                        #region Asıl Alacak

                        if (this.Tutar.Para > 0)
                        {
                            var mahsupAltKat = MahsupAltKategori.Alacak_Neden;
                            if (mahsupKategori == MahsupKategori.Harclar)
                                mahsupAltKat = MahsupAltKategori.Diger_Giderler;

                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori,
                                mahsupAltKat,
                                this.Tutar, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion Asıl Alacak

                        break;

                    case MahsupKategori.Vergiler:

                        #region BSMV

                        if (this.TutarBSMV.Para > 0)
                        {
                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme,
                                mahsupKategori, takip == Takip.Oncesi ? MahsupAltKategori.TO_BSMV : MahsupAltKategori.TS_BSMV,
                                this.TutarBSMV, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion BSMV

                        #region KDV

                        if (this.TutarKDV.Para > 0)
                        {
                            dagitilanOdemelerToplami = ParaVeDovizId.Topla(odeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());

                            kalanOdeme = ParaVeDovizId.Cikart(new ParaVeDovizId(odeme.FERAGAT_MIKTAR, odeme.FERAGAT_MIKTAR_DOVIZ_ID), dagitilanOdemelerToplami);

                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori,
                                 takip == Takip.Oncesi ? MahsupAltKategori.TO_KDV : MahsupAltKategori.TS_KDV,
                                this.TutarKDV, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion KDV

                        #region KKDF

                        if (this.TutarKKDF.Para > 0)
                        {
                            dagitilanOdemelerToplami = ParaVeDovizId.Topla(odeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());

                            kalanOdeme = ParaVeDovizId.Cikart(new ParaVeDovizId(odeme.FERAGAT_MIKTAR, odeme.FERAGAT_MIKTAR_DOVIZ_ID), dagitilanOdemelerToplami);

                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori, MahsupAltKategori.TO_KKDF, this.TutarKKDF, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion KKDF

                        #region OIV

                        if (this.TutarOIV.Para > 0)
                        {
                            dagitilanOdemelerToplami = ParaVeDovizId.Topla(odeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());

                            kalanOdeme = ParaVeDovizId.Cikart(new ParaVeDovizId(odeme.FERAGAT_MIKTAR, odeme.FERAGAT_MIKTAR_DOVIZ_ID), dagitilanOdemelerToplami);

                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori,
                                takip == Takip.Oncesi ? MahsupAltKategori.TO_OIV : MahsupAltKategori.TS_OIV,
                                  this.TutarOIV, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion OIV

                        #region Çek Komisyon

                        if (this.TutarCekKomisyonu.Para > 0)
                        {
                            dagitilanOdemelerToplami = ParaVeDovizId.Topla(odeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList());

                            kalanOdeme = ParaVeDovizId.Cikart(new ParaVeDovizId(odeme.FERAGAT_MIKTAR, odeme.FERAGAT_MIKTAR_DOVIZ_ID), dagitilanOdemelerToplami);

                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori, MahsupAltKategori.Cek_Komisyonu, this.TutarCekKomisyonu, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion Çek Komisyon

                        break;

                    case MahsupKategori.Diger:

                        #region OzelTutarlar && ilam kalemleri

                        if (this.Tutar.Para > 0 &&
                            (this.KalemTipi == AlacakKalemTipi.OzelTutarlar1
                            || this.KalemTipi == AlacakKalemTipi.OzelTutarlar2
                            || this.KalemTipi == AlacakKalemTipi.OzelTutarlar3
                            || this.KalemTipi == AlacakKalemTipi.Ilam_BakiyeKararHarci
                            || this.KalemTipi == AlacakKalemTipi.Ilam_InkarTazminati
                            || this.KalemTipi == AlacakKalemTipi.Ilam_TebligGideri
                            || this.KalemTipi == AlacakKalemTipi.Ilam_VekaletUcreti
                            || this.KalemTipi == AlacakKalemTipi.Ilam_YargilamaGideri
                            || this.KalemTipi == AlacakKalemTipi.Ilam_YargitayOnamaHarci))
                        {
                            var mahsupEdilecek = new ParaVeDovizId();

                            if (this.Tutar.YtlHali > kalanOdeme.YtlHali)
                            {
                                mahsupEdilecek = kalanOdeme;
                            }
                            else
                            {
                                mahsupEdilecek.Para = DovizHelper.CaprazCevir(this.Tutar, kalanOdeme.DovizId,
                                                                         odeme.FERAGAT_TARIHI);
                                mahsupEdilecek.DovizId = kalanOdeme.DovizId;
                            }

                            var mahsupAltKat = MahsupAltKategori.Ozel_Tutar_1;

                            if (KalemTipi == AlacakKalemTipi.OzelTutarlar2)
                                mahsupAltKat = MahsupAltKategori.Ozel_Tutar_2;
                            else if (KalemTipi == AlacakKalemTipi.OzelTutarlar3)
                                mahsupAltKat = MahsupAltKategori.Ozel_Tutar_2;
                            else if (KalemTipi == AlacakKalemTipi.Ilam_BakiyeKararHarci)
                                mahsupAltKat = MahsupAltKategori.Ilam_Bakiye_Karar_Harci;
                            else if (KalemTipi == AlacakKalemTipi.Ilam_InkarTazminati)
                                mahsupAltKat = MahsupAltKategori.Ilam_Inkar_Tazminati;
                            else if (KalemTipi == AlacakKalemTipi.Ilam_TebligGideri)
                                mahsupAltKat = MahsupAltKategori.Ilam_Teblig_Gideri;
                            else if (KalemTipi == AlacakKalemTipi.Ilam_VekaletUcreti)
                                mahsupAltKat = MahsupAltKategori.Ilam_Vekalet_Ucreti;
                            else if (KalemTipi == AlacakKalemTipi.Ilam_YargilamaGideri)
                                mahsupAltKat = MahsupAltKategori.Ilam_Yargilama_Giderleri;
                            else if (KalemTipi == AlacakKalemTipi.Ilam_YargitayOnamaHarci)
                                mahsupAltKat = MahsupAltKategori.Yargitay_Onama_Harci;

                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = GetOdemeDagilim(odeme, mahsupEdilecek, mahsupKategori, mahsupAltKat);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion OzelTutarlar && ilam kalemleri

                        break;

                    case MahsupKategori.Vekalet_Ucreti:

                        #region Vekalet Ücreti

                        if (this.Tutar.Para > 0 &&
                           (this.KalemTipi == AlacakKalemTipi.DAVA_VEKALET_UCRETI
                           || this.KalemTipi == AlacakKalemTipi.DEPO_VEKALET_UCRETI
                           || this.KalemTipi == AlacakKalemTipi.IH_VEKALET_UCRETI
                           || this.KalemTipi == AlacakKalemTipi.IT_VEKALET_UCRETI
                           || this.KalemTipi == AlacakKalemTipi.TAHLIYE_VEK_UCR
                           || this.KalemTipi == AlacakKalemTipi.TAKIP_VEKALET_UCRETI
                           || this.KalemTipi == AlacakKalemTipi.TD_VEK_UCR))
                        {
                            var mahsupEdilecek = new ParaVeDovizId();

                            if (this.Tutar.YtlHali > kalanOdeme.YtlHali)
                            {
                                mahsupEdilecek = kalanOdeme;
                            }
                            else
                            {
                                mahsupEdilecek.Para = DovizHelper.CaprazCevir(this.Tutar, kalanOdeme.DovizId,
                                                                         odeme.FERAGAT_TARIHI);
                                mahsupEdilecek.DovizId = kalanOdeme.DovizId;
                            }

                            var mahsupAltKat = MahsupAltKategori.Dava_Vekalet_Ucreti;

                            if (KalemTipi == AlacakKalemTipi.DEPO_VEKALET_UCRETI)
                                mahsupAltKat = MahsupAltKategori.Takip_Vekalet_Ucreti;
                            else if (KalemTipi == AlacakKalemTipi.IH_VEKALET_UCRETI)
                                mahsupAltKat = MahsupAltKategori.Takip_Vekalet_Ucreti;
                            else if (KalemTipi == AlacakKalemTipi.IT_VEKALET_UCRETI)
                                mahsupAltKat = MahsupAltKategori.Ihtiyati_Tedbir_Vekalet_Ucreti;
                            else if (KalemTipi == AlacakKalemTipi.TAHLIYE_VEK_UCR)
                                mahsupAltKat = MahsupAltKategori.Tahliye_Davasi_Vekalet_Ucreti;
                            else if (KalemTipi == AlacakKalemTipi.TAKIP_VEKALET_UCRETI)
                                mahsupAltKat = MahsupAltKategori.Takip_Vekalet_Ucreti;
                            else if (KalemTipi == AlacakKalemTipi.TD_VEK_UCR)
                                mahsupAltKat = MahsupAltKategori.Tahliye_Davasi_Vekalet_Ucreti;

                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = GetOdemeDagilim(odeme, mahsupEdilecek, mahsupKategori, mahsupAltKat);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion Vekalet Ücreti

                        break;

                    case MahsupKategori.Masraflar:

                        #region Masraflar

                        if (this.KalemTipi == AlacakKalemTipi.Masraf && this.Tutar.Para > 0)
                        {
                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori, MahsupAltKategori.Diger_Giderler, this.Tutar, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion Masraflar

                        #region İlk Tebligat Gideri

                        else if (this.KalemTipi == AlacakKalemTipi.ILK_TEBLIGAT_GIDERI && this.Tutar.Para > 0)
                        {
                            var mahsupEdilecek = new ParaVeDovizId();

                            if (this.Tutar.YtlHali > kalanOdeme.YtlHali)
                            {
                                mahsupEdilecek = kalanOdeme;
                            }
                            else
                            {
                                mahsupEdilecek.Para = DovizHelper.CaprazCevir(this.Tutar, kalanOdeme.DovizId,
                                                                         odeme.FERAGAT_TARIHI);
                                mahsupEdilecek.DovizId = kalanOdeme.DovizId;
                            }

                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = GetOdemeDagilim(odeme, mahsupEdilecek, MahsupKategori.Masraflar, MahsupAltKategori.Ilam_Teblig_Gideri);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion İlk Tebligat Gideri

                        #region Ihtar Gideri

                        if (this.TutarIhtarGideri.Para > 0)
                        {
                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori, MahsupAltKategori.Ihtar_Gideri, this.TutarIhtarGideri, kalanOdeme);
                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion Ihtar Gideri

                        #region Protesto Gideri

                        if (this.TutarProtestoGideri.Para > 0)
                        {
                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori, MahsupAltKategori.Protesto_Gideri, this.TutarProtestoGideri, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion Protesto Gideri

                        break;

                    case MahsupKategori.Tazminatlar:

                        #region Çek Tazminatı

                        if (this.TutarCekTazminati.Para > 0)
                        {
                            AV001_TI_BIL_ODEME_DAGILIM oDagilim = OdemeDagit(odeme, mahsupKategori, MahsupAltKategori.Cek_Tazminati, this.TutarCekTazminati, kalanOdeme);

                            this.OdemeFeragatDagilimlari.Add(oDagilim);
                            liste.Add(oDagilim);
                        }

                        #endregion Çek Tazminatı

                        break;
                }

                if (this.Source is AV001_TI_BIL_ALACAK_NEDEN)
                    (this.Source as AV001_TI_BIL_ALACAK_NEDEN).AV001_TI_BIL_ODEME_DAGILIMCollection.AddRange(liste);

                return liste;
            }

            public void FaizIsle(DateTime baslangic, DateTime bitis, Takip takip)
            {
                if (!this.FaizHesapla || baslangic > bitis)
                    return;

                int faizTipi = this.FaizTipiTakipOncesi;
                double faizOrani = this.FaizOraniTakipOncesi;
                TList<AV001_TI_BIL_FAIZ> yeniFaizler = new TList<AV001_TI_BIL_FAIZ>();

                if (takip == Takip.Sonrasi)
                {
                    faizTipi = this.FaizTipiTakipSonrasi;
                    faizOrani = this.FaizOraniTakipSonrasi;
                }

                #region Faiz

                if (faizTipi == 9)
                {
                    var faiz = FaizHelper.IcraSabitFaizHesapla(faizTipi, baslangic, bitis,
                                                               this.Tutar.Para
                                                               , this.Tutar.DovizId, this.BirYilKacGun,
                                                               faizOrani);
                    if (this.GayriDetay != null)
                        faiz = FaizHelper.IcraSabitFaizHesapla(faizTipi, this.GayriDetay.TAZMIN_TARIHI.Value, bitis,
                                                               this.GayriDetay.TAZMIN_TUTARI.Value
                                                               , this.GayriDetay.TAZMIN_TUTARI_DOVIZ_ID.Value, this.BirYilKacGun,
                                                               faizOrani);

                    yeniFaizler.Add(faiz);
                    FaizKalemleri.Add(faiz);
                }
                else
                {
                    var faiz = FaizHelper.IcraDegiskenFaizHesapla(
                           faizTipi,
                           baslangic,
                           bitis,
                           this.Tutar.Para,
                           this.Tutar.DovizId,
                           this.BirYilKacGun);

                    if (this.GayriDetay != null)
                        faiz = FaizHelper.IcraDegiskenFaizHesapla(
                           faizTipi,
                           this.GayriDetay.TAZMIN_TARIHI.Value,
                           bitis,
                            this.GayriDetay.TAZMIN_TUTARI.Value
                            , this.GayriDetay.TAZMIN_TUTARI_DOVIZ_ID.Value,
                           this.BirYilKacGun);

                    FaizKalemleri.AddRange(faiz);
                    yeniFaizler.AddRange(faiz);
                }

                #endregion Faiz

                #region KKDF

                if (this.KKDFHesapla)
                {
                    FaizHelper.IcraFaizUzerineDigerVergiHesapla(DigerVergiTuru.KKDF,
                                                                yeniFaizler,
                                                                this.TakipTarihi);
                }

                #endregion KKDF

                #region OIV

                if (this.OIVHesapla)
                {
                    FaizHelper.IcraFaizUzerineDigerVergiHesapla(DigerVergiTuru.ÖİV,
                                                                yeniFaizler,
                                                                this.TakipTarihi);
                }

                #endregion OIV

                #region BSMV

                if (this.BSMVHesapla)//neden.BSMV_HESAPLANSIN && BsmvKontrol(neden))
                {
                    FaizHelper.IcraFaizUzerineDigerVergiHesapla(DigerVergiTuru.BSMV,
                                                                yeniFaizler,
                                                                this.TakipTarihi);
                }

                #endregion BSMV

                #region KDV

                if (this.KDVHesaplansin)
                {
                    FaizHelper.IcraFaizUzerineKDVHesapla(this.KDVTip, yeniFaizler,
                                                         this.TakipTarihi);
                }

                #endregion KDV

                if (this.KalemTipi == AlacakKalemTipi.AsilAlacak && this.Source is AV001_TI_BIL_ALACAK_NEDEN)
                {
                    var alacak = this.Source as AV001_TI_BIL_ALACAK_NEDEN;

                    alacak.AV001_TI_BIL_FAIZCollection.AddRange(yeniFaizler);
                }
            }

            private AV001_TI_BIL_ODEME_DAGILIM GetOdemeDagilim(AV001_TI_BIL_FERAGAT odeme, ParaVeDovizId mahsupEdilecek, MahsupKategori mahsupKategori, MahsupAltKategori mahsupAltKategori)
            {
                var oDagilim = odeme.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                oDagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategori;
                oDagilim.MAHSUP_KATEGORI_ID = (int)mahsupKategori;
                oDagilim.TUTAR_KUR = 1;
                oDagilim.ODEME_TARIHI = odeme.FERAGAT_TARIHI;
                oDagilim.DAGILIM_TIPI = 1;
                oDagilim.TUTAR = mahsupEdilecek.Para;
                oDagilim.TUTAR_DOVIZ_ID = mahsupEdilecek.DovizId;
                return oDagilim;
            }

            private AV001_TI_BIL_ODEME_DAGILIM GetOdemeDagilim(AV001_TI_BIL_BORCLU_ODEME odeme, ParaVeDovizId mahsupEdilecek, MahsupKategori mahsupKategori, MahsupAltKategori mahsupAltKategori)
            {
                var oDagilim = odeme.AV001_TI_BIL_ODEME_DAGILIMCollection.AddNew();
                oDagilim.MAHSUP_ALT_KATEGORI_ID = (int)mahsupAltKategori;
                oDagilim.MAHSUP_KATEGORI_ID = (int)mahsupKategori;
                oDagilim.TUTAR_KUR = 1;
                oDagilim.ODEME_TARIHI = odeme.ODEME_TARIHI;
                oDagilim.DAGILIM_TIPI = 1;
                oDagilim.TUTAR = mahsupEdilecek.Para;
                oDagilim.TUTAR_DOVIZ_ID = mahsupEdilecek.DovizId;
                return oDagilim;
            }

            private ParaVeDovizId GetTutar()
            {
                switch (this.KalemTipi)
                {
                    case AlacakKalemTipi.AsilAlacak:
                        if (this.Source is AV001_TI_BIL_ALACAK_NEDEN)
                        {
                            var alacak = this.Source as AV001_TI_BIL_ALACAK_NEDEN;
                            return new ParaVeDovizId(alacak.ISLEME_KONAN_TUTAR, alacak.ISLEME_KONAN_TUTAR_DOVIZ_ID);
                        }
                        break;

                    case AlacakKalemTipi.ILK_TEBLIGAT_GIDERI:
                        var tgFoy = this.Source as AV001_TI_BIL_FOY;
                        return new ParaVeDovizId(tgFoy.ILK_TEBLIGAT_GIDERI, tgFoy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID);

                    case AlacakKalemTipi.Masraf:
                        var masraf = this.Source as AV001_TDI_BIL_MASRAF_AVANS_DETAY;
                        return new ParaVeDovizId(masraf.TOPLAM_TUTAR, masraf.TOPLAM_TUTAR_DOVIZ_ID);

                    case AlacakKalemTipi.Ilam_InkarTazminati:
                        var ilamInkar = this.Source as AV001_TI_BIL_ILAM_MAHKEMESI;
                        return new ParaVeDovizId(ilamInkar.INKAR_TAZMINATI, ilamInkar.INKAR_TAZMINATI_DOVIZ_ID);

                    case AlacakKalemTipi.Ilam_YargilamaGideri:
                        var yargilama = this.Source as AV001_TI_BIL_ILAM_MAHKEMESI;
                        return new ParaVeDovizId(yargilama.YARGILAMA_GIDERI, yargilama.YARGILAMA_GIDERI_DOVIZ_ID);

                    case AlacakKalemTipi.Ilam_BakiyeKararHarci:
                        var bakiyeKArar = this.Source as AV001_TI_BIL_ILAM_MAHKEMESI;
                        return new ParaVeDovizId(bakiyeKArar.BAKIYE_KARAR_HARCI, bakiyeKArar.BAKIYE_KARAR_HARCI_DOVIZ_ID);

                    case AlacakKalemTipi.Ilam_VekaletUcreti:
                        var ilamVekalet = this.Source as AV001_TI_BIL_ILAM_MAHKEMESI;
                        return new ParaVeDovizId(ilamVekalet.ILAM_VEKALET_UCRETI, ilamVekalet.ILAM_VEKALET_UCRETI_DOVIZ_ID);

                    case AlacakKalemTipi.Ilam_TebligGideri:
                        var ilamTeblig = this.Source as AV001_TI_BIL_ILAM_MAHKEMESI;
                        return new ParaVeDovizId(ilamTeblig.ILAM_TEBLIG_GIDERI, ilamTeblig.ILAM_TEBLIG_GIDERI_DOVIZ_ID);

                    case AlacakKalemTipi.Ilam_YargitayOnamaHarci:
                        var ilamYargitayOnama = this.Source as AV001_TI_BIL_ILAM_MAHKEMESI;
                        return new ParaVeDovizId(ilamYargitayOnama.YARGITAY_ONAMA_HARCI, ilamYargitayOnama.YARGITAY_ONAMA_HARCI_DOVIZ_ID);

                    case AlacakKalemTipi.OzelTutarlar1:
                        var foyOzel1 = this.Source as AV001_TI_BIL_FOY;
                        return new ParaVeDovizId(foyOzel1.OZEL_TUTAR1, foyOzel1.OZEL_TUTAR1_DOVIZ_ID);

                    case AlacakKalemTipi.OzelTutarlar2:
                        var foyOzel2 = this.Source as AV001_TI_BIL_FOY;
                        return new ParaVeDovizId(foyOzel2.OZEL_TUTAR2, foyOzel2.OZEL_TUTAR2_DOVIZ_ID);

                    case AlacakKalemTipi.OzelTutarlar3:
                        var foyOzel3 = this.Source as AV001_TI_BIL_FOY;
                        return new ParaVeDovizId(foyOzel3.OZEL_TUTAR3, foyOzel3.OZEL_TUTAR3_DOVIZ_ID);

                    case AlacakKalemTipi.OzelTazminat:
                        var foyOZelTazminat = this.Source as AV001_TI_BIL_FOY;
                        return new ParaVeDovizId(foyOZelTazminat.OZEL_TAZMINAT, foyOZelTazminat.OZEL_TAZMINAT_DOVIZ_ID);

                    case AlacakKalemTipi.DAVA_VEKALET_UCRETI:
                        var foyDavVek = this.Source as AV001_TI_BIL_FOY;
                        return new ParaVeDovizId(foyDavVek.DAVA_VEKALET_UCRETI, foyDavVek.DAVA_VEKALET_UCRETI_DOVIZ_ID);

                    case AlacakKalemTipi.DEPO_VEKALET_UCRETI:
                        var foyDepVek = this.Source as AV001_TI_BIL_FOY;
                        return new ParaVeDovizId(foyDepVek.DEPO_VEKALET_UCRETI, foyDepVek.DEPO_VEKALET_UCRET_DOVIZ_ID);

                    case AlacakKalemTipi.DEPO_HARCI:
                        var foyDepoHarc = this.Source as AV001_TI_BIL_FOY;
                        return new ParaVeDovizId(foyDepoHarc.DEPO_HARCI, foyDepoHarc.DEPO_HARCI_DOVIZ_ID);

                    case AlacakKalemTipi.IH_VEKALET_UCRETI:
                        var foyIhVek = this.Source as AV001_TI_BIL_FOY;
                        return new ParaVeDovizId(foyIhVek.IH_VEKALET_UCRETI, foyIhVek.IH_VEKALET_UCRETI_DOVIZ_ID);

                    case AlacakKalemTipi.IT_VEKALET_UCRETI:
                        var foyItVek = this.Source as AV001_TI_BIL_FOY;
                        return new ParaVeDovizId(foyItVek.IT_VEKALET_UCRETI, foyItVek.IT_VEKALET_UCRETI_DOVIZ_ID);

                    case AlacakKalemTipi.TAHLIYE_VEK_UCR:
                        var foyTahVek = this.Source as AV001_TI_BIL_FOY;
                        return new ParaVeDovizId(foyTahVek.TAHLIYE_VEK_UCR, foyTahVek.TAHLIYE_VEK_UCR_DOVIZ_ID);

                    case AlacakKalemTipi.TD_VEK_UCR:
                        var foyTdVek = this.Source as AV001_TI_BIL_FOY;
                        return new ParaVeDovizId(foyTdVek.TD_VEK_UCR, foyTdVek.TD_VEK_UCR_DOVIZ_ID);

                    case AlacakKalemTipi.TAKIP_VEKALET_UCRETI:
                        var foyTakipVek = this.Source as AV001_TI_BIL_FOY;
                        return new ParaVeDovizId(foyTakipVek.TAKIP_VEKALET_UCRETI, foyTakipVek.TAKIP_VEKALET_UCRETI_DOVIZ_ID);

                    case AlacakKalemTipi.Tazminatlar:
                        var tazmin = this.Source as AV001_TI_BIL_TAZMINAT;
                        return new ParaVeDovizId(tazmin.TAZMINAT_TUTARI, tazmin.TAZMINAT_TUTARI_DOVIZ_ID);

                    case AlacakKalemTipi.Harc:
                        var harc = this.Source as AV001_TI_BIL_HARC;
                        return new ParaVeDovizId(harc.HARC_MIKTARI, harc.HARC_MIKTARI_DOVIZ_ID);
                }

                return new ParaVeDovizId(0, 1);
            }

            private AV001_TI_BIL_ODEME_DAGILIM OdemeDagit(AV001_TI_BIL_FERAGAT odeme, MahsupKategori mahsupKategori, MahsupAltKategori mahsupAltKategori, ParaVeDovizId odemeKesilecekAlacak, ParaVeDovizId kalanOdeme)
            {
                var mahsupEdilecek = new ParaVeDovizId();
                var odemeMahsupBirimli = DovizHelper.CaprazCevir(kalanOdeme, odemeKesilecekAlacak.DovizId, odeme.FERAGAT_TARIHI);
                if (odemeKesilecekAlacak.Para > odemeMahsupBirimli)
                {
                    mahsupEdilecek.Para = odemeMahsupBirimli;
                    mahsupEdilecek.DovizId = odemeKesilecekAlacak.DovizId;
                }
                else
                {
                    mahsupEdilecek = odemeKesilecekAlacak;
                }

                AV001_TI_BIL_ODEME_DAGILIM oDagilim = GetOdemeDagilim(odeme, mahsupEdilecek, mahsupKategori, mahsupAltKategori);
                return oDagilim;
            }

            private AV001_TI_BIL_ODEME_DAGILIM OdemeDagit(AV001_TI_BIL_BORCLU_ODEME odeme, MahsupKategori mahsupKategori, MahsupAltKategori mahsupAltKategori, ParaVeDovizId odemeKesilecekAlacak, ParaVeDovizId kalanOdeme)
            {
                var mahsupEdilecek = new ParaVeDovizId();
                var odemeMahsupBirimli = DovizHelper.CaprazCevir(kalanOdeme, odemeKesilecekAlacak.DovizId, odeme.ODEME_TARIHI);
                if (odemeKesilecekAlacak.Para > odemeMahsupBirimli)
                {
                    mahsupEdilecek.Para = odemeMahsupBirimli;
                    mahsupEdilecek.DovizId = odemeKesilecekAlacak.DovizId;
                }
                else
                {
                    mahsupEdilecek = odemeKesilecekAlacak;
                }
                AV001_TI_BIL_ODEME_DAGILIM oDagilim = GetOdemeDagilim(odeme, mahsupEdilecek, mahsupKategori, mahsupAltKategori);
                return oDagilim;
            }

            #endregion Methots
        }

        public class Avanslar
        {
            public static TList<AV001_TDI_BIL_MASRAF_AVANS> AvansListesi = new TList<AV001_TDI_BIL_MASRAF_AVANS>();
        }

        public class Dava
        {
            public Dava(List<int> idList)
            {
                idList.ForEach(item =>
                {
                    AV001_TD_BIL_FOY foy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(item);
                    if (foy.DAVA_TARIHI.HasValue)
                    {
                        this.FaizHesapla(foy, Takip.Oncesi);
                        this.FaizHesapla(foy, Takip.Sonrasi);
                    }
                });
            }

            public static decimal NispiVekaletUcretiHesapla(AV001_TD_BIL_FOY foy)
            {
                ParaVeDovizId takipsizTutari = new ParaVeDovizId(0, 1);
                if (foy.ID == 0)
                {
                    var takipsizNedenler = new TList<AV001_TD_BIL_DAVA_NEDEN>();

                    foy.AV001_TD_BIL_DAVA_NEDENCollection.ForEach(vi => { takipsizNedenler.Add(vi); });

                    var paralar = new List<ParaVeDovizId>();
                    paralar.AddRange(takipsizNedenler.Select(vi => new ParaVeDovizId(vi.DAVA_EDILEN_TUTAR, vi.DAVA_EDILEN_TUTAR_DOVIZ_ID)).ToArray());
                    paralar.AddRange(takipsizNedenler.Select(vi => new ParaVeDovizId(vi.IHTAR_GIDERI, vi.IHTAR_GIDERI_DOVIZ_ID)).ToArray());
                    paralar.AddRange(takipsizNedenler.Select(vi => new ParaVeDovizId(vi.PROTESTO_GIDERI, vi.PROTESTO_GIDERI_DOVIZ_ID)).ToArray());
                    takipsizNedenler.ForEach(vi =>
                    {
                        paralar.AddRange(vi.AV001_TD_BIL_FAIZCollection.Select(fi => new ParaVeDovizId(fi.FAIZ_TUTARI, fi.FAIZ_TUTARI_DOVIZ_ID)).ToArray());
                    });

                    takipsizTutari = ParaVeDovizId.Topla(paralar);
                }
                DateTime gecerlilikT = foy.SON_HESAP_TARIHI;
                decimal tutar = foy.DAVA_DEGERI;//İCRADA TAKİP ÇIKIŞ I OLAN FIELD

                if (takipsizTutari.Para != 0)
                {
                    tutar = ParaVeDovizId.Cikart(new ParaVeDovizId(foy.DAVA_DEGERI, foy.DAVA_DEGERI_DOVIZ_ID),
                        takipsizTutari).Para;
                }
                //TODO:EXT VEKALET_UCRET tablosu
                if (tutar < 0)
                    tutar = 0;

                decimal hesaplandi = 0;
                decimal tutmaz = tutar;
                int k = 0;
                TDI_CET_VEKALET_NISPIQuery qu = new TDI_CET_VEKALET_NISPIQuery(true);

                qu.AppendLessThanOrEqual(TDI_CET_VEKALET_NISPIColumn.TARIH, gecerlilikT.ToString("yyyy/MM/dd 00:00:00"));
                TList<TDI_CET_VEKALET_NISPI> findIt = DataRepository.TDI_CET_VEKALET_NISPIProvider.Find(qu, "TARIH DESC", 0,
                                                                                                        1, out k);
                if (findIt.Count > 0)
                {
                    TDI_CET_VEKALET_NISPIQuery qu2 = new TDI_CET_VEKALET_NISPIQuery(true);
                    qu2.AppendEquals(TDI_CET_VEKALET_NISPIColumn.TARIH, findIt[0].TARIH.ToString("yyyy/MM/dd 00:00:00"));
                    //qu2.AppendLessThanOrEqual(TDI_CET_VEKALET_NISPIColumn.BOLGE1_KATSAYI, tutar.ToString());
                    TList<TDI_CET_VEKALET_NISPI> findIt2 = DataRepository.TDI_CET_VEKALET_NISPIProvider.Find(qu2, "BOLGE1_KATSAYI");
                    for (int i = 0; i < findIt2.Count; i++)
                    {
                        decimal para = findIt2[i].BOLGE1_KATSAYI;
                        double oran = findIt2[i].ORAN;
                        if (tutmaz > para)
                        {
                            decimal vekTtr = para / 100 * (decimal)oran;
                            hesaplandi += vekTtr;
                            tutmaz = tutmaz - para;
                            AV001_TD_BIL_VEKALET_UCRET vekUc =
                                VekaletUcretiGetir(new ParaVeDovizId(foy.DAVA_DEGERI, foy.DAVA_DEGERI_DOVIZ_ID),
                                                   findIt2[i].TARIH, VekaletUcretKalemi.NispiTakipVekUcr,
                                                   new ParaVeDovizId(vekTtr, foy.DAVA_DEGERI_DOVIZ_ID), oran, VekaketUcretTipNo.Nispi, foy.SON_HESAP_TARIHI);
                            vekUc.MATRAH_MIKTARI_TUTARI = para;
                            foy.AV001_TD_BIL_VEKALET_UCRETCollection.Add(vekUc);
                        }
                        else if (para >= tutmaz)
                        {
                            decimal vekTtr = tutmaz / 100 * (decimal)oran;
                            hesaplandi += vekTtr;
                            AV001_TD_BIL_VEKALET_UCRET vekUc = VekaletUcretiGetir(new ParaVeDovizId(foy.DAVA_DEGERI, foy.DAVA_DEGERI_DOVIZ_ID), findIt2[i].TARIH, VekaletUcretKalemi.NispiTakipVekUcr, new ParaVeDovizId(vekTtr, foy.DAVA_DEGERI_DOVIZ_ID), oran, VekaketUcretTipNo.Nispi, foy.SON_HESAP_TARIHI);
                            vekUc.MATRAH_MIKTARI_TUTARI = tutmaz;
                            foy.AV001_TD_BIL_VEKALET_UCRETCollection.Add(vekUc);
                            break;
                        }
                    }
                }
                if (foy.ID > 0)
                {
                    foy.DAVA_EDILEN_VEKALET_UCRETI = DovizHelper.CevirYTL(hesaplandi, foy.DAVA_DEGERI_DOVIZ_ID ?? 1, foy.DAVA_TARIHI ?? DateTime.Now);
                    foy.DAVA_EDILEN_VEKALET_UCRETI_DOVIZ_ID = 1;

                    if (foy.DAVA_EDILEN_VEKALET_UCRETI > 0)
                    {
                        var degerler = DataRepository.TDI_CET_MIN_MAX_DEGERProvider.GetAll().OrderByDescending(vi => vi.TARIH);

                        foreach (var deger in degerler)
                        {
                            if (deger.TARIH > foy.SON_HESAP_TARIHI)
                                continue;
                            else
                            {
                                if (foy.DAVA_EDILEN_VEKALET_UCRETI < deger.MIN_DEGER)
                                    foy.DAVA_EDILEN_VEKALET_UCRETI = deger.MIN_DEGER;
                                break;
                            }
                        }
                    }
                }
                return foy.DAVA_EDILEN_VEKALET_UCRETI;
            }

            public static AvukatProLib2.Entities.AV001_TD_BIL_VEKALET_UCRET VekaletUcretiGetir(ParaVeDovizId takipCikisi, DateTime tarifeTarihi, VekaletUcretKalemi vekUcretKalemi, ParaVeDovizId vekUcretMiktari, double vekUcretOrani, VekaketUcretTipNo vekUcretTipNo, DateTime? hesaplamaTarihi)
            {
                AvukatProLib2.Entities.AV001_TD_BIL_VEKALET_UCRET vekUcret = new AvukatProLib2.Entities.AV001_TD_BIL_VEKALET_UCRET();
                vekUcret.MATRAH_MIKTARI_TUTARI = takipCikisi.Para;
                vekUcret.MATRAH_MIKTARI_DOVIZ_ID = takipCikisi.DovizId;
                vekUcret.TARIFE_TARIHI = tarifeTarihi;
                vekUcret.VEK_UCR_MIKTARI = vekUcretMiktari.Para;
                vekUcret.VEK_UCR_MIKTARI_DOVIZ_ID = vekUcretMiktari.DovizId;
                vekUcret.VEK_UCR_ORANI = vekUcretOrani;
                vekUcret.VEK_UCR_TIP_NO = (byte)vekUcretTipNo; //Maktu-Nispi
                vekUcret.VEK_UCR_KALEM_ID = (byte)vekUcretKalemi;
                vekUcret.HESAPLAMA_TARIHI = hesaplamaTarihi ?? DateTime.Now;
                return vekUcret;
            }

            public void FaizHesapla(AV001_TD_BIL_FOY foy, Takip takip)
            {
                DateTime bitisTarihi = foy.DAVA_TARIHI.Value;
                int faizTipi;
                double faizOrani;
                TList<AV001_TD_BIL_FAIZ> yeniFaizler = new TList<AV001_TD_BIL_FAIZ>();
                if (foy.AV001_TD_BIL_DAVA_NEDENCollection.Count == 0)
                    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_DAVA_NEDEN>));
                if (takip == Takip.Oncesi)
                {
                    foy.ISLEMIS_FAIZ = 0;
                    foy.AV001_TD_BIL_DAVA_NEDENCollection.ForEach(item =>
                    {
                        if (item.DO_FAIZ_TIP_ID.HasValue)
                        {
                            faizTipi = item.DO_FAIZ_TIP_ID.Value;
                            faizOrani = item.DO_FAIZ_ORANI;

                            if (faizTipi == 9)
                            {
                                if (!item.FAIZ_TALEP_TARIHI.HasValue) return;

                                var faiz = FaizHelper.DavaSabitFaizHesapla(faizTipi, item.FAIZ_TALEP_TARIHI.Value, bitisTarihi, item.DAVA_EDILEN_TUTAR, item.DAVA_EDILEN_TUTAR_DOVIZ_ID.Value, (int)foy.BIR_YIL_KAC_GUN, faizOrani);
                                yeniFaizler.Add(faiz);
                                foy.ISLEMIS_FAIZ += faiz.FAIZ_TUTARI;
                            }
                            else
                            {
                                if (!item.FAIZ_TALEP_TARIHI.HasValue || !foy.DAVA_TARIHI.HasValue) return;

                                var faiz = FaizHelper.DavaDegiskenFaizHesapla(faizTipi, item.FAIZ_TALEP_TARIHI.Value, foy.DAVA_TARIHI.Value, item.DAVA_EDILEN_TUTAR, item.DAVA_EDILEN_TUTAR_DOVIZ_ID.Value, (int)foy.BIR_YIL_KAC_GUN);
                                yeniFaizler.AddRange(faiz);
                                foy.ISLEMIS_FAIZ += faiz.Sum(vi => vi.FAIZ_TUTARI);
                            }

                            item.AV001_TD_BIL_FAIZCollection.AddRange(yeniFaizler);
                            DataRepository.AV001_TD_BIL_FAIZProvider.Save(item.AV001_TD_BIL_FAIZCollection);
                            foy.ISLEMIS_FAIZ_DOVIZ_ID = 1;
                        }
                    });
                }
                else
                {
                    bitisTarihi = foy.SON_HESAP_TARIHI;
                    foy.SONRAKI_FAIZ = 0;
                    foy.AV001_TD_BIL_DAVA_NEDENCollection.ForEach(item =>
                    {
                        if (item.DO_FAIZ_TIP_ID.HasValue)
                        {
                            faizTipi = item.FAIZ_TIP_ID.Value;
                            faizOrani = item.FAIZ_ORANI;

                            if (faizTipi == 9)
                            {
                                var faiz = FaizHelper.DavaSabitFaizHesapla(faizTipi, foy.DAVA_TARIHI.Value, bitisTarihi, item.DAVA_EDILEN_TUTAR, item.DAVA_EDILEN_TUTAR_DOVIZ_ID.Value, (int)foy.BIR_YIL_KAC_GUN, faizOrani);
                                yeniFaizler.Add(faiz);
                                foy.SONRAKI_FAIZ += faiz.FAIZ_TUTARI;
                            }
                            else
                            {
                                var faiz = FaizHelper.DavaDegiskenFaizHesapla(faizTipi, foy.DAVA_TARIHI.Value, bitisTarihi, item.DAVA_EDILEN_TUTAR, item.DAVA_EDILEN_TUTAR_DOVIZ_ID.Value, (int)foy.BIR_YIL_KAC_GUN);
                                yeniFaizler.AddRange(faiz);
                                foy.SONRAKI_FAIZ += faiz.Sum(vi => vi.FAIZ_TUTARI);
                            }
                            item.AV001_TD_BIL_FAIZCollection.AddRange(yeniFaizler);
                            DataRepository.AV001_TD_BIL_FAIZProvider.Save(item.AV001_TD_BIL_FAIZCollection);
                            foy.SONRAKI_FAIZ_DOVIZ_ID = 1;
                        }
                    });
                }
                NispiVekaletUcretiHesapla(foy);
                DataRepository.AV001_TD_BIL_FOYProvider.Save(foy);
            }
        }

        public class Icra
        {
            #region ctor

            public Icra(AV001_TI_BIL_FOY foy)
                : this(foy, true)
            {
            }

            public Icra(AV001_TI_BIL_FOY foy, bool kaydedilsin)
                : this()
            {
                if (!foy.SON_HESAP_TARIHI.HasValue)
                    foy.SON_HESAP_TARIHI = DateTime.Today;

                #region Foy üzerinde o gün içinde hesaplama yapıldıysa ve değişiklik yapılmadıysa tekrar hesaplama yapmaz. Okan 18.08.2010

                if (foy.ID != 0 && !Hesap.Hesaplansinmi && (foy.SON_HESAP_TARIHI.Value.Date.CompareTo(DateTime.Today) == 0 && foy.EXTRA_LONG1 == 0))
                {
                    this.Foy = foy;

                    return;
                }

                #endregion Foy üzerinde o gün içinde hesaplama yapıldıysa ve değişiklik yapılmadıysa tekrar hesaplama yapmaz. Okan 18.08.2010

                if (!foy.TAKIP_TARIHI.HasValue)
                {
                    this.Foy = foy;

                    return;
                }

                #region İlk Değerleri ata

                this.AlacakKalemleri = new List<AlacakKalemi>();
                this.Foy = foy;
                this.TakipTarihi = foy.TAKIP_TARIHI.HasValue ? foy.TAKIP_TARIHI.Value.Date : DateTime.Today;
                this.SonHesapTarihi = foy.SON_HESAP_TARIHI.HasValue ? foy.SON_HESAP_TARIHI.Value.Date : DateTime.Today;
                this.HesapTipiTakipOncesi = foy.TO_HESAP_TIP_ID;
                this.HesapTipiTakipSonrasi = foy.TS_HESAP_TIP_ID;

                #endregion İlk Değerleri ata

                this.DeepLoad(foy);

                this.TutarSifirlama(foy);

                #region Ödemeleri faizleri temizle

                foreach (var odeme in foy.AV001_TI_BIL_BORCLU_ODEMECollection)
                {
                    DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepLoad(odeme, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_ODEME_DETAY>));

                    DataRepository.AV001_TI_BIL_ODEME_DAGILIMProvider.Delete(odeme.AV001_TI_BIL_ODEME_DAGILIMCollection);
                    odeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Clear();
                }
                TList<AV001_TI_BIL_BORCLU_ODEME> digerOdemeListesi = new TList<AV001_TI_BIL_BORCLU_ODEME>();
                foreach (var item in DigerOdemeler(foy))
                {
                    if (foy.AV001_TI_BIL_BORCLU_ODEMECollection.Find(vi => vi.ID == item.ID) == null)
                        digerOdemeListesi.Add(item);
                }
                foreach (var odeme in digerOdemeListesi)
                {
                    DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepLoad(odeme, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_ODEME_DETAY>));

                    DataRepository.AV001_TI_BIL_ODEME_DAGILIMProvider.Delete(odeme.AV001_TI_BIL_ODEME_DAGILIMCollection);
                    odeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Clear();
                }

                DataRepository.AV001_TI_BIL_ODEME_DAGILIMProvider.Delete(foy.AV001_TI_BIL_ODEME_DAGILIMCollection);
                foy.AV001_TI_BIL_ODEME_DAGILIMCollection.Clear();
                foreach (var feragat in foy.AV001_TI_BIL_FERAGATCollection)
                {
                    DataRepository.AV001_TI_BIL_FERAGATProvider.DeepLoad(feragat, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));

                    DataRepository.AV001_TI_BIL_ODEME_DAGILIMProvider.Delete(feragat.AV001_TI_BIL_ODEME_DAGILIMCollection);
                    feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Clear();
                }

                foreach (var item in foy.AV001_TDI_BIL_MASRAF_AVANSCollection)
                {
                    if (!item.MANUEL_KAYIT_MI)
                    {
                        if (!HesapAraclari.Tools.KayitSil("AV001_TDI_BIL_MASRAF_AVANS", "ID = " + item.ID))
                        {
                            if (item.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Count == 0)
                                DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));

                            DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.Delete(item.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection);

                            DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.Delete(item);
                        }
                    }
                }
                if (foy.ID > 0)
                {
                    DataRepository.AV001_TI_BIL_HARCProvider.Delete(foy.AV001_TI_BIL_HARCCollection);
                    foy.AV001_TI_BIL_HARCCollection.Clear();
                }
                DataRepository.AV001_TI_BIL_FAIZProvider.Delete(foy.AV001_TI_BIL_FAIZCollection);
                foy.AV001_TI_BIL_FAIZCollection.Clear();
                foreach (var item in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    DataRepository.AV001_TI_BIL_FAIZProvider.Delete(item.AV001_TI_BIL_FAIZCollection);
                    item.AV001_TI_BIL_FAIZCollection.Clear();
                }

                DataRepository.AV001_TI_BIL_VEKALET_UCRETProvider.Delete(foy.AV001_TI_BIL_VEKALET_UCRETCollection);
                foy.AV001_TI_BIL_VEKALET_UCRETCollection.Clear();

                #endregion Ödemeleri faizleri temizle

                #region Alacak Tarafları listeye Alınıyor

                TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> tumAlacakNedenTaraf = new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>();

                foreach (var item in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));

                    tumAlacakNedenTaraf.AddRange(item.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection);
                }

                #endregion Alacak Tarafları listeye Alınıyor

                FaizHelper.HesaplaAsilAlacak(foy);
                FaizHelper.ProtestoIhtarGiderHesapla(foy);
                FaizHelper.HesaplaIhtiyatiTedbirHaciz(true, foy, tumAlacakNedenTaraf);

                foreach (var item in foy.AV001_TI_BIL_TAZMINATCollection)
                {
                    DataRepository.AV001_TI_BIL_TAZMINATProvider.Delete(item.ID);
                }

                FaizHelper.IcraTazminatHesapla(foy, Takip.Oncesi);
                //FaizHelper.IcraTazminatHesapla(foy, Takip.Sonrasi);
                FaizHelper.IcraTazminatlariFoyUzerineYaz(foy);

                this.AlacakKalemleriOlustur(foy);

                #region Takip Öncesi Ödeme feragat

                foreach (var item in digerOdemeListesi.Where(vi => vi.ODEME_TARIHI <= this.TakipTarihi.Date).OrderBy(vi => vi.ODEME_TARIHI).ToList())
                {
                    EkleOdeme(item);
                }
                foreach (var item in foy.AV001_TI_BIL_BORCLU_ODEMECollection.Where(vi => vi.ODEME_TARIHI <= this.TakipTarihi.Date).OrderBy(vi => vi.ODEME_TARIHI).ToList())
                {
                    EkleOdeme(item);
                }
                foreach (var item in foy.AV001_TI_BIL_FERAGATCollection.Where(vi => vi.FERAGAT_TARIHI <= this.TakipTarihi.Date).OrderBy(vi => vi.FERAGAT_TARIHI).ToList())
                {
                    EkleOdeme(item);
                }

                #endregion Takip Öncesi Ödeme feragat

                this.FaizHesapla(this.TakipTarihi, Takip.Oncesi);
                FaizHelper.HesaplaTakipOncesiOdeme(foy, digerOdemeListesi);

                #region Takip Öncesi BSMV KKDF OIV KDV

                {
                    var bsmvTutarlari = new List<ParaVeDovizId>();
                    var kkdfTutarlari = new List<ParaVeDovizId>();
                    var oivTutarilari = new List<ParaVeDovizId>();
                    var kdvTutarilari = new List<ParaVeDovizId>();
                    var takipOncesiIslemisFaiz = new List<ParaVeDovizId>();

                    foreach (var item in this.AlacakKalemleri)
                    {
                        takipOncesiIslemisFaiz.AddRange(item.FaizKalemleri.Select(vi => new ParaVeDovizId(vi.FAIZ_TUTARI, vi.FAIZ_TUTARI_DOVIZ_ID)).ToList());
                        bsmvTutarlari.AddRange(item.FaizKalemleri.Select(vi => new ParaVeDovizId(vi.BSMV_TUTARI, vi.BSMV_DOVIZ_ID)).ToList());
                        kkdfTutarlari.AddRange(item.FaizKalemleri.Select(vi => new ParaVeDovizId(vi.KKDF_TUTARI, vi.KKDF_DOVIZ_ID)).ToList());
                        oivTutarilari.AddRange(item.FaizKalemleri.Select(vi => new ParaVeDovizId(vi.OIV_TUTARI, vi.OIV_DOVIZ_ID)).ToList());
                        kdvTutarilari.AddRange(item.FaizKalemleri.Select(vi => new ParaVeDovizId(vi.KDV_TUTARI, vi.KKDF_DOVIZ_ID)).ToList());
                    }

                    var bsmvToplami = ParaVeDovizId.Topla(bsmvTutarlari);
                    var kkdfToplami = ParaVeDovizId.Topla(kkdfTutarlari);
                    var oivToplami = ParaVeDovizId.Topla(oivTutarilari);
                    var kdvToplami = ParaVeDovizId.Topla(kdvTutarilari);
                    var takipOncesiIslemisFaizToplami = ParaVeDovizId.Topla(takipOncesiIslemisFaiz);

                    foy.ISLEMIS_FAIZ = takipOncesiIslemisFaizToplami.Para;
                    foy.ISLEMIS_FAIZ_DOVIZ_ID = takipOncesiIslemisFaizToplami.DovizId;

                    foy.BSMV_TO = bsmvToplami.Para;
                    foy.BSMV_TO_DOVIZ_ID = bsmvToplami.DovizId;

                    foy.KKDV_TO = kkdfToplami.Para;
                    foy.KKDV_TO_DOVIZ_ID = kkdfToplami.DovizId;

                    foy.OIV_TO = oivToplami.Para;
                    foy.OIV_TO_DOVIZ_ID = oivToplami.DovizId;

                    foy.KDV_TO = kdvToplami.Para;
                    foy.KDV_TO_DOVIZ_ID = kdvToplami.DovizId;
                }

                #endregion Takip Öncesi BSMV KKDF OIV KDV

                #region Çek Komisyonu & Tazminatı

                {
                    var komistonToplami = ParaVeDovizId.Topla(foy.AV001_TI_BIL_ALACAK_NEDENCollection.Select(vi => new ParaVeDovizId(vi.KOMISYONU, vi.KOMISYONU_DOVIZ_ID)).ToList());
                    var cekTazminatToplami = ParaVeDovizId.Topla(foy.AV001_TI_BIL_ALACAK_NEDENCollection.Select(vi => new ParaVeDovizId(vi.CEK_TAZMINATI, vi.CEK_TAZMINATI_DOVIZ_ID)).ToList());
                    foy.CEK_KOMISYONU = komistonToplami.Para;
                    foy.CEK_KOMISYONU_DOVIZ_ID = komistonToplami.DovizId;

                    foy.KARSILIKSIZ_CEK_TAZMINATI = cekTazminatToplami.Para;
                    foy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = cekTazminatToplami.DovizId;
                }

                #endregion Çek Komisyonu & Tazminatı

                #region Ilam Kalemleri

                {
                    var prBakiyeKararHarci = ParaVeDovizId.Topla(this.AlacakKalemleri.Where(vi => vi.KalemTipi == AlacakKalemi.AlacakKalemTipi.Ilam_BakiyeKararHarci || vi.KalemTipi == AlacakKalemi.AlacakKalemTipi.Ilam_YargitayOnamaHarci).Select(vi => vi.Tutar).ToList());
                    var prInkarTazminati = ParaVeDovizId.Topla(this.AlacakKalemleri.Where(vi => vi.KalemTipi == AlacakKalemi.AlacakKalemTipi.Ilam_InkarTazminati).Select(vi => vi.Tutar).ToList());
                    var prTebligGideri = ParaVeDovizId.Topla(this.AlacakKalemleri.Where(vi => vi.KalemTipi == AlacakKalemi.AlacakKalemTipi.Ilam_TebligGideri).Select(vi => vi.Tutar).ToList());
                    var prVekaletUCreti = ParaVeDovizId.Topla(this.AlacakKalemleri.Where(vi => vi.KalemTipi == AlacakKalemi.AlacakKalemTipi.Ilam_VekaletUcreti).Select(vi => vi.Tutar).ToList());
                    var prYargilamaGideri = ParaVeDovizId.Topla(this.AlacakKalemleri.Where(vi => vi.KalemTipi == AlacakKalemi.AlacakKalemTipi.Ilam_YargilamaGideri).Select(vi => vi.Tutar).ToList());

                    foy.ILAM_BK_YARG_ONAMA = prBakiyeKararHarci.Para;
                    foy.ILAM_BK_YARG_ONAMA_DOVIZ_ID = prBakiyeKararHarci.DovizId;

                    foy.ILAM_INKAR_TAZMINATI = prInkarTazminati.Para;
                    foy.ILAM_INKAR_TAZMINATI_DOVIZ_ID = prInkarTazminati.DovizId;

                    foy.ILAM_TEBLIG_GIDERI = prTebligGideri.Para;
                    foy.ILAM_TEBLIG_GIDERI_DOVIZ_ID = prTebligGideri.DovizId;

                    foy.ILAM_VEK_UCR = prVekaletUCreti.Para;
                    foy.ILAM_VEK_UCR_DOVIZ_ID = prVekaletUCreti.DovizId;

                    foy.ILAM_YARGILAMA_GIDERI = prYargilamaGideri.Para;
                    foy.ILAM_YARGILAMA_GIDERI_DOVIZ_ID = prYargilamaGideri.DovizId;
                }

                #endregion Ilam Kalemleri

                FaizHelper.HesaplaMahsup(foy);
                FaizHelper.HesaplaTakipCikisi(foy);
                FaizHelper.HesaplaFeragatToplami(foy);
                FaizHelper.HesaplaDigerGiderler(foy);
                HesapYapar.HesaplaMasrafAvanslar(foy);
                FaizHelper.IcraIlkGiderleriHesapla(foy, foy.AV001_TI_BIL_FOY_TARAFCollection,
                    foy.AV001_TI_BIL_FOY_TARAFCollection.Where(vi => !vi.TAKIP_EDEN_MI).Count());

                FaizHelper.HesaplaKalanTahsilHarciVs(foy);

                #region Takip Sonrası için Oluşan Alacak Kalemleri Ekleniyor

                this.AlacakKalemleri.AddRange(AlacakKalemi.DigerKalem(foy));

                #region Harç Kalemleri

                foreach (var item in foy.AV001_TI_BIL_HARCCollection)
                {
                    EkleAlacak(item);
                }
                foreach (var item in foy.AV001_TDI_BIL_MASRAF_AVANSCollection)
                {
                    if (!item.BORCLU_CARI_ID.HasValue)
                        EkleAlacak(item);
                }

                #endregion Harç Kalemleri

                #endregion Takip Sonrası için Oluşan Alacak Kalemleri Ekleniyor

                #region Takip Sonrası Ödeme Feragat

                foreach (var item in digerOdemeListesi.Where(vi => vi.ODEME_TARIHI > this.TakipTarihi.Date).OrderBy(vi => vi.ODEME_TARIHI).ToList())
                {
                    EkleOdeme(item);
                }
                foreach (var item in foy.AV001_TI_BIL_BORCLU_ODEMECollection.Where(vi => vi.ODEME_TARIHI > this.TakipTarihi.Date).OrderBy(vi => vi.ODEME_TARIHI).ToList())
                {
                    EkleOdeme(item);
                }
                foreach (var item in foy.AV001_TI_BIL_FERAGATCollection.Where(vi => vi.FERAGAT_TARIHI > this.TakipTarihi.Date).OrderBy(vi => vi.FERAGAT_TARIHI).ToList())
                {
                    EkleOdeme(item);
                }

                #endregion Takip Sonrası Ödeme Feragat

                FaizHelper.HesaplaOdemeToplami(foy, digerOdemeListesi);

                this.FaizHesapla(this.SonHesapTarihi, Takip.Sonrasi);

                #region Sonraki Faiz

                {
                    var takipSonrasiFaizler = this.FaizKalemleri.Where(vi => vi.FAIZ_BASLANGIC_TARIHI >= this.TakipTarihi.Date);

                    var faizlerToplami = ParaVeDovizId.Topla(takipSonrasiFaizler.Select(vi => new ParaVeDovizId(vi.FAIZ_TUTARI, vi.FAIZ_TUTARI_DOVIZ_ID)).ToList());
                    var bsmvToplami = ParaVeDovizId.Topla(takipSonrasiFaizler.Select(vi => new ParaVeDovizId(vi.BSMV_TUTARI, vi.BSMV_DOVIZ_ID)).ToList());
                    var oivToplami = ParaVeDovizId.Topla(takipSonrasiFaizler.Select(vi => new ParaVeDovizId(vi.OIV_TUTARI, vi.OIV_DOVIZ_ID)).ToList());
                    var kdvToplami = ParaVeDovizId.Topla(takipSonrasiFaizler.Select(vi => new ParaVeDovizId(vi.KDV_TUTARI, vi.KDV_DOVIZ_ID)).ToList());

                    foy.BSMV_TS = bsmvToplami.Para;
                    foy.BSMV_TS_DOVIZ_ID = bsmvToplami.DovizId;

                    foy.OIV_TS = oivToplami.Para;
                    foy.OIV_TS_DOVIZ_ID = oivToplami.DovizId;

                    foy.SONRAKI_FAIZ = faizlerToplami.Para;
                    foy.SONRAKI_FAIZ_DOVIZ_ID = faizlerToplami.DovizId;

                    foy.KDV_TS = kdvToplami.Para;
                    foy.KDV_TS_DOVIZ_ID = kdvToplami.DovizId;
                }

                #endregion Sonraki Faiz

                #region Üretilen Ödeme & Faiz Kalemleri Föye ekleniyor

                foreach (var item in this.AlacakKalemleri)
                {
                    foy.AV001_TI_BIL_ODEME_DAGILIMCollection.AddRange(item.OdemeFeragatDagilimlari);
                    foy.AV001_TI_BIL_FAIZCollection.AddRange(item.FaizKalemleri);
                    foreach (var tek in item.FaizKalemleri)
                    {
                        if (foy.TAKIP_TARIHI > (tek.FAIZ_BASLANGIC_TARIHI ?? DateTime.Now).Date)
                            tek.FAIZ_TAKIPDEN_ONCE_MI = 1;
                        else
                            tek.FAIZ_TAKIPDEN_ONCE_MI = 0;
                    }
                }

                #endregion Üretilen Ödeme & Faiz Kalemleri Föye ekleniyor

                FaizHelper.IcraToplamKalemleriHesapla(foy);
                FaizHelper.KalanHesapla(foy);
                HesapSonuToplamlari(foy);

                #region Carisiz masraf kalemlerine cari ekleniyor

                foy.AV001_TDI_BIL_MASRAF_AVANSCollection.ForEach(vi =>
                    {
                        if (vi.CARI_ID == 0)
                        {
                            vi.CARI_ID = Kimlikci.Kimlik.CurrentCariId;
                        }
                    });

                #endregion Carisiz masraf kalemlerine cari ekleniyor

                //var hesaplanmisKAlemler =  this.AlacakKalemleri.Where(vi=>vi.KalemTipi == AlacakKalemi.AlacakKalemTipi.HesaplanmisKalemler);
                if (this.HesaplanmisKalem != null)
                {
                    foreach (var item in this.HesaplanmisKalem.FaizKalemleri)
                    {
                        item.FAIZ_TAKIPDEN_ONCE_MI = 1;
                    }
                    foy.AV001_TI_BIL_ALACAK_NEDENCollection.First().AV001_TI_BIL_FAIZCollection.AddRange(this.HesaplanmisKalem.FaizKalemleri);
                }

                int aa = -1;
                foreach (AV001_TDI_BIL_MASRAF_AVANS item in foy.AV001_TDI_BIL_MASRAF_AVANSCollection)
                {
                    aa++;

                    if (item.REFERANS_NO.Contains("Ö"))
                    {
                        if (Avanslar.AvansListesi.Count > 0)
                            foy.AV001_TDI_BIL_MASRAF_AVANSCollection[aa].AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection = Avanslar.AvansListesi[aa].AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection;
                    }
                }

                if (kaydedilsin)
                    DeepSave(foy);

                DosyaMuhasebesiOlustur(foy);

                //Otomatik masraf oluşturma işlemi aykut 25.12.2012
                List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
                CompInfo cmpNfo = cmpNfoList[0];
                if (!cmpNfo.OtoMasrafUretilmesin)
                    Muhasebelestir(foy);

                #region // Okan 18.08.2010 // Föyde o gün içinde tekrar hesaplama yapılmasına gerek olmadığını gösterir.

                if (foy.ID != 0)
                {
                    foy.EXTRA_LONG1 = 0;
                    foy.SON_HESAP_TARIHI = DateTime.Today;
                    DataRepository.AV001_TI_BIL_FOYProvider.Save(foy);

                    //aykut eklendi otomatik masraf avanstan doğrudan müvekkile muhasebeleştirme iptal edildi
                    if (!foy.AV001_TDI_BIL_MASRAF_AVANSCollection[0].MANUEL_KAYIT_MI)
                    {
                        ABSqlConnection cn = new ABSqlConnection();
                        cn.CnString = cmpNfo.ConStr;
                        cn.AddParams("@FoyID", foy.ID);

                        DataTable dt1 = cn.GetDataTable("SELECT ID FROM dbo.AV001_TDI_BIL_CARI_HESAP WHERE ID IN (SELECT CARI_HESAP_ID FROM dbo.AV001_TDI_BIL_CARI_HESAP_DETAY WHERE ICRA_FOY_ID=@FoyID AND CARI_ID IN (SELECT ID FROM dbo.AV001_TDI_BIL_CARI WHERE ID IN (SELECT CARI_ID FROM dbo.AV001_TDI_BIL_CARI_HESAP WHERE ID IN (SELECT CARI_HESAP_ID FROM dbo.AV001_TDI_BIL_CARI_HESAP_DETAY WHERE ICRA_FOY_ID=@FoyID)) AND MUVEKKIL_MI=1 AND PERSONEL_MI=0))");

                        DataTable dt2 = cn.GetDataTable("SELECT ID FROM dbo.AV001_TDI_BIL_CARI_HESAP_DETAY WHERE CARI_HESAP_ID IN (SELECT ID FROM dbo.AV001_TDI_BIL_CARI_HESAP WHERE ID IN (SELECT CARI_HESAP_ID FROM dbo.AV001_TDI_BIL_CARI_HESAP_DETAY WHERE ICRA_FOY_ID=@FoyID AND CARI_ID IN (SELECT ID FROM dbo.AV001_TDI_BIL_CARI WHERE ID IN (SELECT CARI_ID FROM dbo.AV001_TDI_BIL_CARI_HESAP WHERE ID IN (SELECT CARI_HESAP_ID FROM dbo.AV001_TDI_BIL_CARI_HESAP_DETAY WHERE ICRA_FOY_ID=@FoyID)) AND MUVEKKIL_MI=1 AND PERSONEL_MI=0)))");

                        foreach (DataRow row in dt2.Rows)
                        {
                            cn.Clear();
                            cn.AddParams("@ID", row[0].ToString());
                            cn.ExcuteQuery("delete from dbo.AV001_TDI_BIL_CARI_HESAP_DETAY where ID=@ID");
                        }

                        foreach (DataRow row in dt1.Rows)
                        {
                            cn.Clear();
                            cn.AddParams("@ID", row[0].ToString());
                            cn.ExcuteQuery("delete from dbo.AV001_TDI_BIL_CARI_HESAP where ID=@ID");
                        }
                    }
                    //SON
                }

                #endregion // Okan 18.08.2010 // Föyde o gün içinde tekrar hesaplama yapılmasına gerek olmadığını gösterir.
                //DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(foy);
                DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepSave(foy.AV001_TI_BIL_BORCLU_ODEMECollection);
                foreach (var item in foy.AV001_TI_BIL_BORCLU_ODEMECollection)
                {
                    DataRepository.AV001_TI_BIL_ODEME_DAGILIMProvider.DeepSave(item.AV001_TI_BIL_ODEME_DAGILIMCollection);
                }
            }

            private Icra()
            {
                this.HesapSiralamaListeleri = AvukatProLib2.Data.DataRepository.AV001_TI_KOD_HESAP_TIP_SIRAProvider.GetAll();
            }

            private void Muhasebelestir(AV001_TI_BIL_FOY foy)
            {
                foreach (var masraf in foy.AV001_TDI_BIL_MASRAF_AVANSCollection)
                {
                    if (!masraf.MANUEL_KAYIT_MI)
                        MuhasebeAraclari.SetCariHesapByMasrafAvans(masraf.ID);
                }
            }

            #endregion ctor

            #region Properties

            public TList<AV001_TI_BIL_FAIZ> FaizKalemleri
            {
                get
                {
                    TList<AV001_TI_BIL_FAIZ> liste = new TList<AV001_TI_BIL_FAIZ>();

                    foreach (var item in this.AlacakKalemleri)
                    {
                        liste.AddRange(item.FaizKalemleri);
                    }

                    return liste;
                }
            }

            public AV001_TI_BIL_FOY Foy { get; set; }

            public List<MahsupKategori> HesapSirasiTakipOncesi
            {
                get
                {
                    return this.HesapSirasi(this.HesapTipiTakipOncesi)
                        .OrderBy(vi => vi.SIRA_NO)
                        .Select(vi => (MahsupKategori)vi.MAHSUP_KATEGORI_ID)
                        .ToList();
                }
            }

            public List<MahsupKategori> HesapSirasiTakipSonrasi
            {
                get
                {
                    return this.HesapSirasi(this.HesapTipiTakipSonrasi)
                        .OrderBy(vi => vi.SIRA_NO)
                        .Select(vi => (MahsupKategori)vi.MAHSUP_KATEGORI_ID)
                        .ToList();
                }
            }

            public int HesapTipiTakipOncesi { get; set; }

            public int HesapTipiTakipSonrasi { get; set; }

            public TList<AV001_TI_BIL_ODEME_DAGILIM> OdemeDagilimleri
            {
                get
                {
                    TList<AV001_TI_BIL_ODEME_DAGILIM> liste = new TList<AV001_TI_BIL_ODEME_DAGILIM>();

                    foreach (var item in this.AlacakKalemleri)
                    {
                        liste.AddRange(item.OdemeFeragatDagilimlari);
                    }

                    return liste;
                }
            }

            public DateTime SonHesapTarihi { get; set; }

            public DateTime TakipTarihi { get; set; }

            private List<AlacakKalemi> AlacakKalemleri { get; set; }

            private AlacakKalemi HesaplanmisKalem { get; set; }

            private TList<AV001_TI_KOD_HESAP_TIP_SIRA> HesapSiralamaListeleri { get; set; }

            #endregion Properties

            #region Methots

            #region Masraf Avansdan Dosya Muhasebe ve detay oluştur

            //aykut otomatik hesapla
            public void DosyaMuhasebesiOlustur(AV001_TDI_BIL_MASRAF_AVANS masrafAvans)
            {
                AV001_TDI_BIL_FOY_MUHASEBE gelenMuhasebe = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID).FirstOrDefault();
                if (gelenMuhasebe == null)
                {
                    MuhasebeAraclari.SetFoyMuhasebeByMasrafAvans(masrafAvans.ID, masrafAvans.CARI_HESAP_HEDEF_TIP);

                    gelenMuhasebe = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID).FirstOrDefault();
                }

                if (gelenMuhasebe != null)
                {
                    TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> mevcutMasrafDetay = DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID);
                    TList<AV001_TDI_BIL_FOY_MUHASEBE_DETAY> gelenMuhasebeDetay = DataRepository.AV001_TDI_BIL_FOY_MUHASEBE_DETAYProvider.GetByFOY_MUHASEBE_ID(gelenMuhasebe.ID);

                    if (mevcutMasrafDetay.Count > gelenMuhasebeDetay.Count)
                    {
                        foreach (var item in mevcutMasrafDetay)
                        {
                            //kontrol versiyon alanında masraf avans detay id tutulmaktadır
                            if (!gelenMuhasebeDetay.Any(m => m.KONTROL_VERSIYON == item.ID))
                            {
                                MuhasebeAraclari.SetFoyMuhasebeDetayByMasrafAvansDetay(item.ID, gelenMuhasebe.ID, !item.MA_MANUAL_KAYIT_MI);
                                AV001_TDI_BIL_FOY_MUHASEBE_DETAY muhasebeDetay = DataRepository.AV001_TDI_BIL_FOY_MUHASEBE_DETAYProvider.GetByMASRAF_AVANS_DETAY_ID(item.ID).FirstOrDefault();
                                if (muhasebeDetay.MASRAF_AVANS_DETAY_ID.HasValue)
                                {
                                    int muvekkilCariId = DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.GetByID(muhasebeDetay.MASRAF_AVANS_DETAY_ID.Value).MUVEKKIL_CARI_ID.Value;

                                    int cariHesapId = MuhasebeAraclari.SetCariHesapByMuhasebe(gelenMuhasebe.ID, muvekkilCariId);
                                    if (cariHesapId > 0)
                                        MuhasebeAraclari.SetCariHesapByMuhasebeDetay(gelenMuhasebe.ID, muhasebeDetay.ID, cariHesapId, muhasebeDetay.BIRIM_FIYAT, muhasebeDetay.ADET, 1);
                                    //muhasebeDetay.MUHASEBELESTIRILMEMIS_MIKTAR = 0;
                                    //son parametre yeniden hesaplanabilir olması için verildi
                                }
                                //DataRepository.AV001_TDI_BIL_FOY_MUHASEBE_DETAYProvider.DeepSave(muhasebeDetay);
                            }
                        }
                    }
                }
            }

            private void DosyaMuhasebesiOlustur(AV001_TI_BIL_FOY MyFoy)
            {
                if (MyFoy != null)
                {
                    int foyID = MyFoy.ID;
                    TList<AV001_TDI_BIL_MASRAF_AVANS> gelenMasrafAvans = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByICRA_FOY_ID(foyID);

                    try
                    {
                        foreach (var masrafAvans in gelenMasrafAvans)
                        {
                            AV001_TDI_BIL_FOY_MUHASEBE gelenMuhasebe = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID).FirstOrDefault();

                            if (masrafAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Count < 1)
                                DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(masrafAvans, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));

                            if (gelenMuhasebe == null)
                            {
                                DosyaMuhasebesiOlustur(masrafAvans);
                            }

                            gelenMuhasebe = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID).FirstOrDefault();

                            if (gelenMuhasebe != null)
                            {
                                TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> mevcutMasrafDetay = DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID);
                                TList<AV001_TDI_BIL_FOY_MUHASEBE_DETAY> gelenMuhasebeDetay = DataRepository.AV001_TDI_BIL_FOY_MUHASEBE_DETAYProvider.GetByFOY_MUHASEBE_ID(gelenMuhasebe.ID);

                                if (mevcutMasrafDetay.Count > gelenMuhasebeDetay.Count)
                                {
                                    DosyaMuhasebesiOlustur(masrafAvans);
                                }
                            }
                        }
                    }

                    catch (Exception)
                    {
                    }
                }
            }

            #endregion Masraf Avansdan Dosya Muhasebe ve detay oluştur

            public void EkleOdeme(AV001_TI_BIL_BORCLU_ODEME odeme)
            {
                if (odeme.ODEME_TARIHI <= this.TakipTarihi.Date) //takip öncesi ödeme
                {
                    foreach (var mahsupKategori in this.HesapSirasiTakipOncesi)
                    {
                        foreach (var alacakKalemi in GetAlacaklarByMahsupKategori(mahsupKategori))
                        {
                            alacakKalemi.EkleOdeme(odeme, mahsupKategori, Takip.Oncesi);
                        }
                    }
                }
                else if (odeme.ODEME_TARIHI > this.TakipTarihi.Date) // takip sonrası ödeme
                {
                    foreach (var mahsupKategori in this.HesapSirasiTakipSonrasi)
                    {
                        foreach (var alacakKalemi in GetAlacaklarByMahsupKategori(mahsupKategori))
                        {
                            alacakKalemi.EkleOdeme(odeme, mahsupKategori, Takip.Sonrasi);
                        }
                    }
                }
            }

            public void EkleOdeme(AV001_TI_BIL_FERAGAT odeme)
            {
                if (odeme.FERAGAT_TARIHI <= this.TakipTarihi.Date) //takip öncesi ödeme
                {
                    foreach (var mahsupKategori in this.HesapSirasiTakipOncesi)
                    {
                        foreach (var alacakKalemi in GetAlacaklarByMahsupKategori(mahsupKategori))
                        {
                            alacakKalemi.EkleOdeme(odeme, mahsupKategori, Takip.Oncesi);
                        }
                    }
                }
                else if (odeme.FERAGAT_TARIHI > this.TakipTarihi.Date) // takip sonrası ödeme
                {
                    foreach (var mahsupKategori in this.HesapSirasiTakipSonrasi)
                    {
                        foreach (var alacakKalemi in GetAlacaklarByMahsupKategori(mahsupKategori))
                        {
                            alacakKalemi.EkleOdeme(odeme, mahsupKategori, Takip.Sonrasi);
                        }
                    }
                }
            }

            public void FaizHesapla(DateTime bitisTarihi, Takip takip)
            {
                this.AlacakKalemleri.ForEach(vi => vi.FaizIsle(vi.SonFaizHesapTarihi, bitisTarihi, takip));
            }

            public void HesapSonuToplamlari(AV001_TI_BIL_FOY foy)
            {
                #region Tüm Ödemeler Toplamı

                var prTumOdemelerToplami = ParaVeDovizId.Topla(new ParaVeDovizId(foy.ODEME_TOPLAMI, foy.ODEME_TOPLAMI_DOVIZ_ID),
                                                                new ParaVeDovizId(foy.TO_ODEME_TOPLAMI, foy.TO_ODEME_TOPLAMI_DOVIZ_ID));
                foy.TUM_ODEME_TOPLAMI = prTumOdemelerToplami.Para;
                foy.TUM_ODEME_TOPLAMI_DOVIZ_ID = prTumOdemelerToplami.DovizId;

                #endregion Tüm Ödemeler Toplamı

                #region Risk Miktarı

                var prRiskMiktari = ParaVeDovizId.Topla(new ParaVeDovizId(foy.TS_MASRAF_TOPLAMI, foy.TS_MASRAF_TOPLAMI_DOVIZ_ID), new ParaVeDovizId(foy.ASIL_ALACAK, foy.ASIL_ALACAK_DOVIZ_ID));
                foy.RISK_MIKTARI = prRiskMiktari.Para;
                foy.RISK_MIKTARI_DOVIZ_ID = prRiskMiktari.DovizId;

                #endregion Risk Miktarı

                #region Riskten Kalan

                var prRisktenKalan = ParaVeDovizId.Cikart(prRiskMiktari, prTumOdemelerToplami);
                foy.RISKTEN_KALAN = prRiskMiktari.Para;
                foy.RISKTEN_KALAN_DOVIZ_ID = prRiskMiktari.DovizId;

                #endregion Riskten Kalan
            }

            private void DeepLoad(AV001_TI_BIL_FOY foy)
            {
                #region Deepload çek

                if (foy.Tag != null && foy.Tag.ToString() == "Cekme")
                    return;

                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren,
                    typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                    typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>),
                    typeof(TList<AV001_TI_BIL_ILAM_MAHKEMESI>),
                    typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>),
                    typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>),
                    typeof(TList<AV001_TI_BIL_BORCLU_ODEME>),
                    typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ>),
                    typeof(TList<AV001_TI_BIL_FERAGAT>),
                    typeof(TList<AV001_TI_BIL_FAIZ>),
                    typeof(TList<AV001_TI_BIL_VEKALET_UCRET>),
                    typeof(TList<AV001_TI_BIL_BORCLU_MAHSUP>),
                    typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>)
                    );

                if (foy.TO_HESAP_TIP_IDSource != null)
                    DataRepository.AV001_TI_KOD_HESAP_TIPProvider.DeepLoad(foy.TO_HESAP_TIP_IDSource, false, DeepLoadType.IncludeChildren,
                        typeof(TList<AV001_TI_KOD_HESAP_TIP_SIRA>));

                if (foy.TS_HESAP_TIP_IDSource != null)
                    DataRepository.AV001_TI_KOD_HESAP_TIPProvider.DeepLoad(foy.TO_HESAP_TIP_IDSource, false, DeepLoadType.IncludeChildren,
                        typeof(TList<AV001_TI_KOD_HESAP_TIP_SIRA>));

                #endregion Deepload çek
            }

            //    if (foy.AV001_TI_BIL_FOY_TARAFCollection != null)
            //        foreach (var item in foy.AV001_TI_BIL_FOY_TARAFCollection)
            //        {
            //            if (item.TAKIP_EDEN_MI && item.TARAF_KODU == (int)TarafKodu.Muvekkil)
            //                MuhasebeAraclari.SetCariHesapByFoy(foy);
            //        }
            //}
            private void DeepSave(AV001_TI_BIL_FOY foy)
            {
                if (foy.ID > 0)
                {
                    foreach (var masraf in foy.AV001_TDI_BIL_MASRAF_AVANSCollection)
                    {
                        foreach (var detay in masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                        {
                            detay.GENEL_TOPLAM = detay.TOPLAM_TUTAR + detay.KDV_TUTAR + detay.STOPAJ_SSDF_TUTAR;
                            detay.GENEL_TOPLAM_DOVIZ_ID = detay.TOPLAM_TUTAR_DOVIZ_ID;
                        }
                    }

                    //Otomatik masraf oluşturma işlemi aykut 25.12.2012
                    List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
                    CompInfo cmpNfo = cmpNfoList[0];

                    ABSqlConnection cn = new ABSqlConnection();
                    cn.CnString = cmpNfo.ConStr;

                    bool GirsinMi = false;

                    foreach (AV001_TI_BIL_FOY_TARAF item in foy.AV001_TI_BIL_FOY_TARAFCollection)
                    {
                        if (item.TARAF_KODU == 1 & cn.ExecuteScalar("select HANGI_TARAFI from dbo.TDIE_KOD_TARAF_SIFAT where ID=" + item.TARAF_SIFAT_ID).ToString() == "TAKİP EDİLEN")
                            GirsinMi = true;
                    }

                    //if (foy.AV001_TI_BIL_FOY_TARAFCollection[0].TARAF_KODU == 1 & foy.AV001_TI_BIL_FOY_TARAFCollection[0].TARAF_SIFAT_ID)

                    if (cmpNfo.OtoMasrafUretilmesin)
                    {
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(foy, DeepSaveType.IncludeChildren,
                        typeof(TList<AV001_TI_BIL_HARC>),
                            //typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>),
                            //typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>),
                        typeof(TList<AV001_TI_BIL_FAIZ>),
                        typeof(TList<AV001_TI_BIL_VEKALET_UCRET>),
                        typeof(TList<AV001_TI_BIL_TAZMINAT>),
                        typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>),
                        typeof(TList<AV001_TI_BIL_HARC>)
                        );
                    }
                    else if (GirsinMi)
                    {
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(foy, DeepSaveType.IncludeChildren,
                        typeof(TList<AV001_TI_BIL_HARC>),
                            //typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>),
                            //typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>),
                        typeof(TList<AV001_TI_BIL_FAIZ>),
                        typeof(TList<AV001_TI_BIL_VEKALET_UCRET>),
                        typeof(TList<AV001_TI_BIL_TAZMINAT>),
                        typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>),
                        typeof(TList<AV001_TI_BIL_HARC>)
                        );
                    }
                    else
                    {
                        if (foy.TAKIP_TARIHI > ABDegiskenler.OTO_MASRAF_TARIHI)
                        {
                            DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(foy, DeepSaveType.IncludeChildren,
                                typeof(TList<AV001_TI_BIL_HARC>),
                                typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>),
                                typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>),
                                typeof(TList<AV001_TI_BIL_FAIZ>),
                                typeof(TList<AV001_TI_BIL_VEKALET_UCRET>),
                                typeof(TList<AV001_TI_BIL_TAZMINAT>),
                                typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>),
                                typeof(TList<AV001_TI_BIL_HARC>)
                                );
                        }
                        else
                        {
                            DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(foy, DeepSaveType.IncludeChildren,
                            typeof(TList<AV001_TI_BIL_HARC>),
                                //typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>),
                                //typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>),
                            typeof(TList<AV001_TI_BIL_FAIZ>),
                            typeof(TList<AV001_TI_BIL_VEKALET_UCRET>),
                            typeof(TList<AV001_TI_BIL_TAZMINAT>),
                            typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>),
                            typeof(TList<AV001_TI_BIL_HARC>)
                            );
                        }
                    }
                }
                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(foy.AV001_TI_BIL_ALACAK_NEDENCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>), typeof(TList<AV001_TI_BIL_FAIZ>));
            }

            private TList<AV001_TI_BIL_BORCLU_ODEME> DigerOdemeler(AV001_TI_BIL_FOY foy)
            {
                var liste = new TList<AV001_TI_BIL_BORCLU_ODEME>();
                foreach (var item in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    liste.AddRange(DigerOdemeler(item));
                }
                return liste;
            }

            private TList<AV001_TI_BIL_BORCLU_ODEME> DigerOdemeler(AV001_TI_BIL_ALACAK_NEDEN neden)
            {
                TList<AV001_TI_BIL_BORCLU_ODEME> listOdeme = new TList<AV001_TI_BIL_BORCLU_ODEME>();
                if (neden.AV001_TI_BIL_BORCLU_ODEMECollection.Count == 0)
                    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(neden, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_ODEME>));
                listOdeme.AddRange(neden.AV001_TI_BIL_BORCLU_ODEMECollection);
                return listOdeme;

                //Ödemelerin takipteki ödemelerin birkaç katının gelmesine neden olduğu için kapatıldı.
                //Detaylı test edildikten sonra kaldırılacak. MB
                //if (!neden.EU_ID.HasValue)
                //    return new TList<AV001_TI_BIL_BORCLU_ODEME>();

                //var alacaklar = KlasorHesapAraclari.GetAlacakNedenByEuId(neden.EU_ID.Value, true); //Takipte mevcut olmayan alacak nedenlerinin ve bunlara bağlı olarak takipte olmayan ödeme collection'larının hesaba yansımasına sebep oluyordu. MB

                //DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(alacaklar, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_ODEME>));
                //TList<AV001_TI_BIL_BORCLU_ODEME> liste = new TList<AV001_TI_BIL_BORCLU_ODEME>();
                //foreach (var item in alacaklar)
                //{
                //    liste.AddRange(item.AV001_TI_BIL_BORCLU_ODEMECollection);
                //}
                //return liste;
            }

            private List<AlacakKalemi.AlacakKalemTipi> GetAlacakKalemTipiByMahsupKategori(MahsupKategori mahsupKategori)
            {
                var liste = new List<AlacakKalemi.AlacakKalemTipi>();

                switch (mahsupKategori)
                {
                    case MahsupKategori.Asil_Alacak:
                        liste.Add(AlacakKalemi.AlacakKalemTipi.AsilAlacak);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.HesaplanmisKalemler);
                        break;

                    case MahsupKategori.Vekalet_Ucreti:
                        liste.Add(AlacakKalemi.AlacakKalemTipi.DAVA_VEKALET_UCRETI);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.DEPO_VEKALET_UCRETI);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.IH_VEKALET_UCRETI);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.IT_VEKALET_UCRETI);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.TAHLIYE_VEK_UCR);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.TD_VEK_UCR);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.TAKIP_VEKALET_UCRETI);
                        break;

                    case MahsupKategori.Harclar:
                        liste.Add(AlacakKalemi.AlacakKalemTipi.Harc);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.DEPO_HARCI);
                        break;

                    case MahsupKategori.Tazminatlar:
                        liste.Add(AlacakKalemi.AlacakKalemTipi.Tazminatlar);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.OzelTazminat);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.AsilAlacak);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.HesaplanmisKalemler);
                        break;

                    case MahsupKategori.Masraflar:
                        liste.Add(AlacakKalemi.AlacakKalemTipi.Masraf);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.AsilAlacak);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.HesaplanmisKalemler);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.ILK_TEBLIGAT_GIDERI);
                        break;

                    case MahsupKategori.Faizler:
                        liste.Add(AlacakKalemi.AlacakKalemTipi.AsilAlacak);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.HesaplanmisKalemler);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.Ilam_BakiyeKararHarci);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.Ilam_InkarTazminati);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.Ilam_TebligGideri);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.Ilam_VekaletUcreti);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.Ilam_YargilamaGideri);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.Ilam_YargitayOnamaHarci);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.OzelTutarlar1);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.OzelTutarlar2);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.OzelTutarlar3);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.OzelTazminat);
                        break;

                    case MahsupKategori.Vergiler:
                        liste.Add(AlacakKalemi.AlacakKalemTipi.AsilAlacak);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.HesaplanmisKalemler);
                        break;

                    case MahsupKategori.Diger:
                        liste.Add(AlacakKalemi.AlacakKalemTipi.Ilam_BakiyeKararHarci);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.Ilam_InkarTazminati);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.Ilam_TebligGideri);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.Ilam_VekaletUcreti);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.Ilam_YargilamaGideri);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.Ilam_YargitayOnamaHarci);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.OzelTutarlar1);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.OzelTutarlar2);
                        liste.Add(AlacakKalemi.AlacakKalemTipi.OzelTutarlar3);
                        break;

                    default:
                        break;
                }

                return liste;
            }

            private List<AlacakKalemi> GetAlacaklarByMahsupKategori(MahsupKategori mahsupKategori)
            {
                return this.AlacakKalemleri.Where(vi => this.GetAlacakKalemTipiByMahsupKategori(mahsupKategori).Contains(vi.KalemTipi)).ToList();
            }

            private TList<AV001_TI_KOD_HESAP_TIP_SIRA> HesapSirasi(int hesapTipId)
            {
                return this.HesapSiralamaListeleri.FindAll(vi => vi.HESAP_TIP_ID == hesapTipId);
            }

            #region Alacak Ekle

            public void EkleAlacak(AV001_TI_BIL_TAZMINAT tazminat)
            {
                this.AlacakKalemleri.Add(new AlacakKalemi(tazminat, this.TakipTarihi, (int)this.Foy.BIR_YIL_KAC_GUN));
            }

            public void EkleAlacak(AV001_TI_BIL_ALACAK_NEDEN neden)
            {
                if (neden.VADE_TARIHI.HasValue && neden.AN_URETIP_TIP != (int)AN_URETIP_TIP.HesapDisi && neden.AN_URETIP_TIP != (int)AN_URETIP_TIP.MunzamSenet)
                    this.AlacakKalemleri.Add(new AlacakKalemi(neden, this.TakipTarihi, (int)this.Foy.BIR_YIL_KAC_GUN));
                else if (!neden.VADE_TARIHI.HasValue && neden.AN_URETIP_TIP != (int)AN_URETIP_TIP.MunzamSenet)
                {
                    var test = BelgeUtil.Inits.context.AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAYs.Where(vi => vi.ALACAK_NEDEN_ID == neden.ID && vi.TAZMIN_TARIHI.HasValue).ToList();

                    if (test.Count == 0)
                    {
                        var takipliList = DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLIProvider.GetByALACAK_NEDEN_ID(neden.ID);

                        foreach (var item in takipliList)
                        {
                            if (!item.KAYNAK_ALACAK_NEDEN_ID.HasValue) continue;
                            var kayitList = BelgeUtil.Inits.context.AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAYs.Where(vi => vi.ALACAK_NEDEN_ID == item.KAYNAK_ALACAK_NEDEN_ID.Value && vi.TAZMIN_TARIHI.HasValue).ToList();
                            if (kayitList != null && kayitList.Count > 0) test.AddRange(kayitList);
                        }
                    }

                    if (test.Count > 0)
                    {
                        foreach (var item in test)
                        {
                            this.AlacakKalemleri.Add(new AlacakKalemi(neden, item, this.TakipTarihi, (int)this.Foy.BIR_YIL_KAC_GUN));
                        }
                    }
                    else
                        return;
                }
            }

            public void EkleAlacak(AV001_TDI_BIL_MASRAF_AVANS mAvans)
            {
                if (mAvans.MANUEL_KAYIT_MI)
                {
                    if (mAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Count == 0)
                        AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(mAvans, true, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));

                    foreach (var item in mAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                    {
                        if (item.HAREKET_ALT_KATEGORI_ID != 817 && this.AlacakKalemleri.Where(vi => vi.Source.Equals(item)).Count() == 0)
                        {
                            this.AlacakKalemleri.Add(new AlacakKalemi(item, this.TakipTarihi, (int)this.Foy.BIR_YIL_KAC_GUN));
                        }
                    }
                }
            }

            public void EkleAlacak(AV001_TI_BIL_ILAM_MAHKEMESI ilam)
            {
                this.AlacakKalemleri.AddRange(AlacakKalemi.IlamAlacakKalemleri(ilam, this.TakipTarihi, (int)this.Foy.BIR_YIL_KAC_GUN));
            }

            public void EkleAlacak(AV001_TI_BIL_HARC harc)
            {
                if (harc.NISPI_HARC_KALEM_ID != 11) //Cezaevi harcı
                    this.AlacakKalemleri.Add(new AlacakKalemi(harc, this.TakipTarihi, (int)this.Foy.BIR_YIL_KAC_GUN));
            }

            /// <summary>
            /// Föy üzerindeki özel tutarlara ilişkin alacak kalemi oluşturur
            /// </summary>
            /// <param name="foy"></param>
            public void EkleAlacak(AV001_TI_BIL_FOY foy)
            {
                this.AlacakKalemleri.AddRange(AlacakKalemi.OzelTutarAlacakKalemi(foy));
                this.AlacakKalemleri.AddRange(AlacakKalemi.VekaletAlacakKalemleri(foy));
            }

            public void EkleHesaplanmisKalem(AV001_TI_BIL_FOY foy)
            {
                if (foy.HESAPLANMIS_BSMV.HasValue || foy.HESAPLANMIS_FAIZ.HasValue ||
                    foy.HESAPLANMIS_KDV.HasValue || foy.HESAPLANMIS_KKDF.HasValue ||
                    foy.HESAPLANMIS_OIV.HasValue)
                {
                    this.HesaplanmisKalem = new AlacakKalemi(foy.TAKIP_TARIHI ?? DateTime.Now, foy.BIR_YIL_KAC_GUN);

                    this.HesaplanmisKalem.KalemTipi = AlacakKalemi.AlacakKalemTipi.HesaplanmisKalemler;

                    this.HesaplanmisKalem.AlacakKalemiTarihi = foy.TAKIP_TARIHI ?? DateTime.Now;
                    DateTime dt = foy.TAKIP_TARIHI ?? DateTime.Now;
                    var faiz = new AV001_TI_BIL_FAIZ();

                    DateTime.TryParse(foy.EXTRA_STR1, out dt);
                    if (dt == new DateTime())
                        dt = foy.TAKIP_TARIHI ?? DateTime.Now;

                    faiz.FAIZ_BITIS_TARIHI = dt;

                    faiz.FAIZ_TIP_ID = (int)FaizTip.Temmerut_Faiz;
                    this.HesaplanmisKalem.BirYilKacGun = foy.BIR_YIL_KAC_GUN;
                    this.HesaplanmisKalem.BSMVHesapla = false;
                    this.HesaplanmisKalem.FaizHesapla = false;
                    this.HesaplanmisKalem.KDVHesaplansin = false;
                    this.HesaplanmisKalem.KKDFHesapla = false;
                    this.HesaplanmisKalem.OIVHesapla = false;
                    this.HesaplanmisKalem.Source = foy;

                    faiz.BSMV_TUTARI = foy.HESAPLANMIS_BSMV ?? 0;
                    faiz.BSMV_DOVIZ_ID = foy.HESAPLANMIS_BSMV_DOVIZ_ID;
                    faiz.FAIZ_TUTARI = foy.HESAPLANMIS_FAIZ ?? 0;
                    faiz.FAIZ_TUTARI_DOVIZ_ID = foy.HESAPLANMIS_FAIZ_DOVIZ_ID;
                    faiz.KKDF_TUTARI = foy.HESAPLANMIS_KKDF ?? 0;
                    faiz.KKDF_DOVIZ_ID = foy.HESAPLANMIS_KKDF_DOVIZ_ID;
                    faiz.OIV_TUTARI = foy.HESAPLANMIS_OIV ?? 0;
                    faiz.OIV_DOVIZ_ID = foy.HESAPLANMIS_OIV_DOVIZ_ID;
                    faiz.KDV_TUTARI = foy.HESAPLANMIS_KDV ?? 0;
                    faiz.KDV_DOVIZ_ID = foy.HESAPLANMIS_KDV_DOVIZ_ID;
                    faiz.FAIZ_TAKIPDEN_ONCE_MI = 1;
                    this.HesaplanmisKalem.FaizKalemleri.Add(faiz);
                }
            }

            private void AlacakKalemleriOlustur(AV001_TI_BIL_FOY foy)
            {
                this.EkleHesaplanmisKalem(foy);

                this.EkleAlacak(foy);

                foreach (var item in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    this.EkleAlacak(item);
                }
                foreach (var item in foy.AV001_TDI_BIL_MASRAF_AVANSCollection)
                {
                    this.EkleAlacak(item);
                }
                foreach (var item in foy.AV001_TI_BIL_ILAM_MAHKEMESICollection)
                {
                    this.EkleAlacak(item);
                }
                foreach (var item in foy.AV001_TI_BIL_TAZMINATCollection)
                {
                    this.EkleAlacak(item);
                }
                if (this.HesaplanmisKalem != null)
                {
                    foreach (var item in this.AlacakKalemleri)
                    {
                        if (item.KalemTipi != AlacakKalemi.AlacakKalemTipi.Ilam_BakiyeKararHarci &&
                            item.KalemTipi != AlacakKalemi.AlacakKalemTipi.Ilam_InkarTazminati &&
                            item.KalemTipi != AlacakKalemi.AlacakKalemTipi.Ilam_TebligGideri &&
                            item.KalemTipi != AlacakKalemi.AlacakKalemTipi.Ilam_VekaletUcreti &&
                            item.KalemTipi != AlacakKalemi.AlacakKalemTipi.Ilam_YargilamaGideri &&
                            item.KalemTipi != AlacakKalemi.AlacakKalemTipi.Ilam_YargitayOnamaHarci &&
                            item.KalemTipi != AlacakKalemi.AlacakKalemTipi.OzelTutarlar1 &&
                            item.KalemTipi != AlacakKalemi.AlacakKalemTipi.OzelTutarlar2 &&
                            item.KalemTipi != AlacakKalemi.AlacakKalemTipi.OzelTutarlar3)
                        {
                            item.SonFaizHesapTarihi = this.HesaplanmisKalem.SonFaizHesapTarihi;
                        }
                    }
                    this.AlacakKalemleri.Add(this.HesaplanmisKalem);
                }
            }

            #endregion Alacak Ekle

            private void TutarSifirlama(AV001_TI_BIL_FOY foy)
            {
                foy.DAVA_VEKALET_UCRETI = 0;
                foy.DAVA_VEKALET_UCRETI_DOVIZ_ID = 1;
            }

            //private void Muhasebelestir(AV001_TI_BIL_FOY foy)
            //{
            //    if (foy != null && foy.ID > 0)

            //        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));

            #endregion Methots
        }
    }
}