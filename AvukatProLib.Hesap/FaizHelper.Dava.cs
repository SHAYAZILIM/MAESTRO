using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;

namespace AvukatProLib.Hesap
{
    public enum HesaplanicakHarcTipi
    {
        IhtiyatiKararVeIlamHarci
    }

    public partial class FaizHelper
    {
        public static AV001_TD_BIL_FOY DavaDegeriniHesapla(AV001_TD_BIL_FOY myFoy)
        {
            List<ParaVeDovizId> paralarTutar = new List<ParaVeDovizId>();
            List<ParaVeDovizId> paralarDavaEdilenTutar = new List<ParaVeDovizId>();

            foreach (AV001_TD_BIL_DAVA_NEDEN neden in myFoy.AV001_TD_BIL_DAVA_NEDENCollection)
            {
                if (neden.TUTAR > 0)
                {
                    paralarTutar.Add(new ParaVeDovizId(neden.TUTAR, neden.TUTAR_DOVIZ_ID));
                }

                if (neden.DAVA_EDILEN_TUTAR > 0)
                {
                    paralarDavaEdilenTutar.Add(new ParaVeDovizId(neden.DAVA_EDILEN_TUTAR, neden.DAVA_EDILEN_TUTAR_DOVIZ_ID));
                }
            }

            ParaVeDovizId toplamTutar = ParaVeDovizId.Topla(paralarTutar);
            ParaVeDovizId toplamDavaEdienTutar = ParaVeDovizId.Topla(paralarDavaEdilenTutar);

            myFoy.DAVA_DEGERI = toplamTutar.Para;
            myFoy.DAVA_DEGERI_DOVIZ_ID = toplamTutar.DovizId;

            myFoy.CEZAI_SART_TOPLAMI = toplamDavaEdienTutar.Para;
            myFoy.CEZAI_SART_TOPLAMI_DOVIZ_ID = toplamDavaEdienTutar.DovizId;

            return myFoy;
        }

        /// <summary>
        /// Dava modülü için deðiþken faiz hesaplar ve <see cref="TList{AV001_TD_BIL_FAIZ}"/>  tipinde geri döndürür
        /// </summary>
        /// <seealso cref="IcraSabitFaizHesapla(int,DateTime,DateTime,decimal,int,int,double)"/>
        /// <param name="faizTipId">Deðiþken faizin tipi</param>
        /// <param name="baslangicT">Faiz baþlangýç tarihi</param>
        /// <param name="bitisT">Faiz bitiþ tarihi</param>
        /// <param name="tutar">Faiz hesaplanacak tutar</param>
        /// <param name="dovizTipId">Faiz hesaplanacak <paramref name="tutar"/> birimi</param>
        /// <param name="birYilKacGun">Bir yilin kaç gün olduðu</param>
        /// <returns>Hesaplanmýþ faizleri <see cref="TList{AV001_TD_BIL_FAIZ}"/> tipinde geri döndürür</returns>
        public static TList<AV001_TD_BIL_FAIZ> DavaDegiskenFaizHesapla(int faizTipId, DateTime baslangicT, DateTime bitisT, decimal tutar, int dovizTipId, int birYilKacGun)
        {
            TDI_CET_FAIZ_TARIFEQuery qu2 = new TDI_CET_FAIZ_TARIFEQuery(true);
            qu2.AppendLessThanOrEqual(TDI_CET_FAIZ_TARIFEColumn.TARIFE_GECERLILIK_BASLANGIC_TARIHI,
                                      baslangicT.ToString("yyyy/MM/dd 00:00:00"));
            qu2.AppendEquals(TDI_CET_FAIZ_TARIFEColumn.FAIZ_TIP_ID, faizTipId.ToString());
            qu2.AppendEquals(TDI_CET_FAIZ_TARIFEColumn.DOVIZ_TIP_ID, dovizTipId.ToString());
            int k = 0;
            TDI_CET_FAIZ_TARIFE ilkFaiz = null;
            TList<TDI_CET_FAIZ_TARIFE> ilkFaizLer = AvukatProLib2.Data.DataRepository.TDI_CET_FAIZ_TARIFEProvider.Find(qu2, "TARIFE_GECERLILIK_BASLANGIC_TARIHI DESC", 0, 1, out k);
            if (ilkFaizLer.Count > 0)
            {
                ilkFaiz = ilkFaizLer[0];
            }
            else
            {
                return new TList<AV001_TD_BIL_FAIZ>();
            }
            TDI_CET_FAIZ_TARIFEQuery qu = new TDI_CET_FAIZ_TARIFEQuery(true);
            qu.AppendGreaterThanOrEqual(TDI_CET_FAIZ_TARIFEColumn.TARIFE_GECERLILIK_BASLANGIC_TARIHI,
                                        ilkFaiz.TARIFE_GECERLILIK_BASLANGIC_TARIHI.ToString("yyyy/MM/dd 00:00:00"));
            qu.AppendLessThanOrEqual(TDI_CET_FAIZ_TARIFEColumn.TARIFE_GECERLILIK_BASLANGIC_TARIHI, bitisT.ToString("yyyy/MM/dd 00:00:00"));
            qu.AppendEquals(TDI_CET_FAIZ_TARIFEColumn.FAIZ_TIP_ID, faizTipId.ToString());
            qu.AppendEquals(TDI_CET_FAIZ_TARIFEColumn.DOVIZ_TIP_ID, dovizTipId.ToString());
            TList<TDI_CET_FAIZ_TARIFE> faizler =
                AvukatProLib2.Data.DataRepository.TDI_CET_FAIZ_TARIFEProvider.Find(qu, "TARIFE_GECERLILIK_BASLANGIC_TARIHI ASC");
            TList<AV001_TD_BIL_FAIZ> kalemler = new TList<AV001_TD_BIL_FAIZ>();
            DateTime currentDate = baslangicT;
            if (faizler.Count > 1)
            {
                //Eðer ikinci faiz var ise
                for (int i = 0; i < faizler.Count; i++)
                {
                    if (faizler.Count > i + 1) // eðer bir sonraki faiz var ise
                    {
                        if (bitisT > faizler[i + 1].TARIFE_GECERLILIK_BASLANGIC_TARIHI)
                        {
                            AV001_TD_BIL_FAIZ fk = kalemler.AddNew();
                            fk.FAIZ_BASLANGIC_TARIHI = currentDate.Date;
                            fk.FAIZ_BITIS_TARIHI = faizler[i + 1].TARIFE_GECERLILIK_BASLANGIC_TARIHI.Date;
                            fk.FAIZ_ORANI = faizler[i].TARIFE_TUTARI;
                            TimeSpan ts = fk.FAIZ_BITIS_TARIHI.Value - fk.FAIZ_BASLANGIC_TARIHI.Value;
                            int yuzdeBinde = faizler[i].TARIFE_BINDE_ORAN_MI == 1 ? 1000 : 100;
                            fk.GUN_FARKI = ts.Days;
                            fk.FAIZ_TUTARI = (tutar / yuzdeBinde * (decimal)fk.FAIZ_ORANI) / birYilKacGun * fk.GUN_FARKI;
                            fk.FAIZ_TIP_ID = faizTipId;
                            fk.FAIZ_TUTARI_DOVIZ_ID = dovizTipId;
                            fk.MATRAH_DOVIZ_ID = dovizTipId;
                            fk.MATRAH_TUTARI = tutar;
                            fk.KAYIT_TARIHI = DateTime.Now;
                            fk.KLASOR_KODU = "GENEL";
                            fk.KONTROL_KIM = "AVUKATPRO";
                            fk.KONTROL_NE_ZAMAN = DateTime.Now;
                            fk.KONTROL_VERSIYON = 1;
                            currentDate = faizler[i + 1].TARIFE_GECERLILIK_BASLANGIC_TARIHI.Date;
                        }
                    }
                    else // Eðer bir sonraki faiz yok ise
                    {
                        AV001_TD_BIL_FAIZ fk = kalemler.AddNew();
                        fk.FAIZ_BASLANGIC_TARIHI = currentDate.Date;
                        fk.FAIZ_BITIS_TARIHI = bitisT; //Bitiþ tarihini yazýyoruz
                        fk.FAIZ_ORANI = faizler[i].TARIFE_TUTARI;
                        TimeSpan ts = fk.FAIZ_BITIS_TARIHI.Value - fk.FAIZ_BASLANGIC_TARIHI.Value;
                        int yuzdeBinde = faizler[i].TARIFE_BINDE_ORAN_MI == 1 ? 1000 : 100;
                        fk.GUN_FARKI = ts.Days; // bitis tarihini hesaba katmýyoruz
                        fk.FAIZ_TUTARI = (tutar / yuzdeBinde * (decimal)fk.FAIZ_ORANI) / birYilKacGun * fk.GUN_FARKI;
                        fk.FAIZ_TIP_ID = faizTipId;
                        fk.FAIZ_TUTARI_DOVIZ_ID = dovizTipId;
                        fk.MATRAH_DOVIZ_ID = dovizTipId;
                        fk.MATRAH_TUTARI = tutar;
                        fk.KAYIT_TARIHI = DateTime.Now;
                        fk.KLASOR_KODU = "GENEL";
                        fk.KONTROL_KIM = "AVUKATPRO";
                        fk.KONTROL_NE_ZAMAN = DateTime.Now;
                        fk.KONTROL_VERSIYON = 1;
                        currentDate = bitisT;
                    }
                }
            }
            //eðer tek bir faiz bulunduysa
            else
            {
                AV001_TD_BIL_FAIZ fk = kalemler.AddNew();
                fk.FAIZ_BASLANGIC_TARIHI = baslangicT.Date;
                fk.FAIZ_BITIS_TARIHI = bitisT.Date;
                if (faizler.Count > 0)
                {
                    fk.FAIZ_ORANI = faizler[0].TARIFE_TUTARI;
                    TimeSpan ts = fk.FAIZ_BITIS_TARIHI.Value - fk.FAIZ_BASLANGIC_TARIHI.Value;
                    int yuzdeBinde = faizler[0].TARIFE_BINDE_ORAN_MI == 1 ? 1000 : 100;
                    fk.GUN_FARKI = ts.Days; // bitis tarihinide hesaba katmýyoruz ts.Days + 1 yok
                    fk.FAIZ_TUTARI = (tutar / yuzdeBinde * (decimal)fk.FAIZ_ORANI) / birYilKacGun * fk.GUN_FARKI;
                }
                fk.FAIZ_TIP_ID = faizTipId;
                fk.FAIZ_TUTARI_DOVIZ_ID = dovizTipId;
                fk.MATRAH_DOVIZ_ID = dovizTipId;
                fk.MATRAH_TUTARI = tutar;
                fk.KAYIT_TARIHI = DateTime.Now;
                fk.KLASOR_KODU = "GENEL";
                fk.KONTROL_KIM = "AVUKATPRO";
                fk.KONTROL_NE_ZAMAN = DateTime.Now;
                fk.KONTROL_VERSIYON = 1;
            }
            return kalemler;
        }

        /// <summary>
        /// Dava modülü için deðiþken faiz hesaplar ve <see cref="TList{AV001_TD_BIL_FAIZ}"/> tipinde geri döndürür
        /// </summary>
        /// <seealso cref="IcraSabitFaizHesapla(int,DateTime,DateTime,decimal,int,int,double)"/>
        /// <param name="faizTipId">Deðiþken faizin tipi</param>
        /// <param name="baslangicT">Faiz baþlangýç tarihi</param>
        /// <param name="bitisT">Faiz bitiþ tarihi</param>
        /// <param name="tutar">Faiz hesaplanacak tutar</param>
        /// <param name="dovizTipId">Faiz hesaplanacak tutar birimi</param>
        /// <param name="birYilKacGun">Bir yilin kaç gün olduðu</param>
        /// <param name="kalemId">Hesaplanan faizlerin kalem Id si</param>
        /// <returns>Hesaplanmýþ faizleri <see cref="TList{AV001_TD_BIL_FAIZ}"/> tipinde geri döndürür</returns>
        public static TList<AV001_TD_BIL_FAIZ> DavaDegiskenFaizHesapla(int faizTipId, DateTime baslangicT, DateTime bitisT, decimal tutar, int dovizTipId, int birYilKacGun, FaizKalem kalemId)
        {
            TList<AV001_TD_BIL_FAIZ> result =
                DavaDegiskenFaizHesapla(faizTipId, baslangicT, bitisT, tutar, dovizTipId, birYilKacGun);

            result.ForEach(delegate(AV001_TD_BIL_FAIZ obj)
                               {
                                   obj.FAIZ_KALEM_ID = (int)kalemId;
                               });
            return result;
        }

        public static AV001_TI_BIL_HARC DavaHarcHesaplaEkleGetir(HesaplanicakHarcTipi tipi, AV001_TD_BIL_FOY mFoy, DateTime gecerlilikTarihi, string adliBirimBolumKod)
        {
            switch (tipi)
            {
                case HesaplanicakHarcTipi.IhtiyatiKararVeIlamHarci:
                    ParaVeDovizId pId = FaizHelper.IhtiyatiKararVeIlamHarciGetir(gecerlilikTarihi, adliBirimBolumKod);
                    break;

                default:
                    break;
            }
            return new AV001_TI_BIL_HARC();
        }

        /// <summary>
        /// Dava modülü için sabit faiz hesaplar ve AV001_TD_BIL_FAIZ tipinde geri döndürür
        /// </summary>
        /// <seealso cref="IcraDegiskenFaizHesapla(int,DateTime,DateTime,decimal,int,int)"/>
        /// <param name="faizTipId">Sabit faizin tipi</param>
        /// <param name="baslangicT">Faiz baþlangýç tarihi</param>
        /// <param name="bitisT">Faiz bitiþ tarihi</param>
        /// <param name="tutar">Faiz hesaplanacak tutar</param>
        /// <param name="dovizTipId">Faiz hesaplanacak <paramref name="tutar"/> birimi</param>
        /// <param name="birYilKacGun">Bir yilin kaç gün olduðu</param>
        /// <param name="oran">Faiz oraný</param>
        /// <returns>Hesaplanmýþ faizi AV001_TD_BIL_FAIZ tipinde geri döndürür</returns>
        public static AV001_TD_BIL_FAIZ DavaSabitFaizHesapla(int faizTipId, DateTime baslangicT, DateTime bitisT, decimal tutar, int dovizTipId, int birYilKacGun, double oran)
        {
            AV001_TD_BIL_FAIZ fk = new AV001_TD_BIL_FAIZ();
            fk.FAIZ_BASLANGIC_TARIHI = baslangicT.Date;
            fk.FAIZ_BITIS_TARIHI = bitisT.Date;
            fk.FAIZ_ORANI = oran;
            TimeSpan ts = fk.FAIZ_BITIS_TARIHI.Value - fk.FAIZ_BASLANGIC_TARIHI.Value;
            int yuzdeBinde = 100;
            fk.GUN_FARKI = ts.Days; // bitis tarihinide hesaba katmýyoruz ts.Days+1 yok
            fk.FAIZ_TUTARI = (tutar / yuzdeBinde * (decimal)fk.FAIZ_ORANI) / birYilKacGun * fk.GUN_FARKI;
            fk.FAIZ_TIP_ID = faizTipId;
            fk.FAIZ_TUTARI_DOVIZ_ID = dovizTipId;
            fk.MATRAH_DOVIZ_ID = dovizTipId;
            fk.MATRAH_TUTARI = tutar;
            fk.KAYIT_TARIHI = DateTime.Now;
            fk.KLASOR_KODU = "GENEL";
            fk.KONTROL_KIM = "AVUKATPRO";
            fk.KONTROL_NE_ZAMAN = DateTime.Now;
            fk.KONTROL_VERSIYON = 1;
            return fk;
        }

        public static AV001_TD_BIL_FAIZ DavaSabitFaizHesapla(int faizTipId, DateTime baslangicT, DateTime bitisT, decimal tutar, int dovizTipId, int birYilKacGun, double oran, FaizKalem kalemId)
        {
            AV001_TD_BIL_FAIZ result = DavaSabitFaizHesapla(faizTipId, baslangicT, bitisT, tutar, dovizTipId, birYilKacGun, oran);
            result.FAIZ_KALEM_ID = (int)kalemId;
            return result;
        }

        public static TList<AV001_TD_BIL_FAIZ> MahsupluFaizHesapla(bool sabitFaizUygula, AV001_TD_BIL_FOY mFoy, MahsupAltKategori mahsupAltKategoriId, int faizTipId, DateTime faizBaslangicT, DateTime faizBitisT, ParaVeDovizId islenicekTutar, FaizKalem faizKalem, Takip neZaman, double uygulanicakFaizOrani)
        {
            TList<AV001_TD_BIL_FAIZ> faizler = new TList<AV001_TD_BIL_FAIZ>();

            #region FaizHesaplarý

            //Bu nedene ait odeme daðýlýmýný bul
            //Dosya bazýnda olduðunda daðýlým tipi 1 olur
            TList<AV001_TD_BIL_ODEME_DAGILIM> odemeList = mFoy.AV001_TD_BIL_ODEME_DAGILIMCollection.FindAll(AV001_TD_BIL_ODEME_DAGILIMColumn.DAGILIM_TIPI, 1).FindAll(
                AV001_TD_BIL_ODEME_DAGILIMColumn.MAHSUP_ALT_KATEGORI_ID, mahsupAltKategoriId).FindAll(
                delegate(AV001_TD_BIL_ODEME_DAGILIM obj)
                {
                    if (neZaman == Takip.Oncesi && obj.ODEME_TARIHI < mFoy.DAVA_TARIHI.Value)
                        return true;
                    else if (neZaman == Takip.Sonrasi && obj.ODEME_TARIHI >= mFoy.DAVA_TARIHI.Value)
                        return true;
                    return false;
                }
                );
            odemeList.Sort("ODEME_TARIHI");

            if (sabitFaizUygula)
            {
                #region Mahsuplu FaizHesabý

                DateTime dtBaslangicT = faizBaslangicT;
                ParaVeDovizId pdPara = islenicekTutar;

                TList<AV001_TD_BIL_FAIZ> fs = new TList<AV001_TD_BIL_FAIZ>();
                for (int i = 0; i < odemeList.Count; i++)
                {
                    AV001_TD_BIL_ODEME_DAGILIM dagilim = odemeList[i];
                    fs.Add(
                        DavaSabitFaizHesapla(9, dtBaslangicT,
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
                            DavaSabitFaizHesapla(9, dagilim.ODEME_TARIHI,
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
                    fs.Add(DavaSabitFaizHesapla(9, dtBaslangicT,
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

                TList<AV001_TD_BIL_FAIZ> fs = new TList<AV001_TD_BIL_FAIZ>();
                for (int i = 0; i < odemeList.Count; i++)
                {
                    AV001_TD_BIL_ODEME_DAGILIM dagilim = odemeList[i];
                    fs.AddRange(
                        DavaDegiskenFaizHesapla(
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
                        fs.AddRange(DavaDegiskenFaizHesapla(
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
                        DavaDegiskenFaizHesapla(faizTipId, faizBaslangicT,
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

            foreach (AV001_TD_BIL_FAIZ faiz in faizler)
            {
                faiz.FAIZ_KALEM_ID = (int)faizKalem;
                if (neZaman == Takip.Oncesi)
                {
                    faiz.FAIZ_DAVADAN_ONCE_MI = true;
                }
            }
            return faizler;
        }

        public static TList<AV001_TD_BIL_FAIZ> OzelTutarFaizHesapla(AV001_TD_BIL_FOY mFoy, Takip hesapAraligi)
        {
            DateTime dtBaslangicT = new DateTime();
            DateTime dtBitisT = new DateTime();

            TList<AV001_TD_BIL_FAIZ> result = new TList<AV001_TD_BIL_FAIZ>();

            if (mFoy.OZEL_TUTAR1_FAIZ_ISLESINMI && mFoy.OZEL_TUTAR1_FAIZ_TIP_ID.HasValue)
            {
                if (hesapAraligi == Takip.Oncesi)
                {
                    dtBaslangicT = mFoy.OZEL_TUTAR1_FAIZ_BASLANGIC_TARIHI.Value;
                    dtBitisT = mFoy.DAVA_TARIHI.Value;
                }
                else
                {
                    dtBaslangicT = mFoy.DAVA_TARIHI.Value;
                    dtBitisT = mFoy.SON_HESAP_TARIHI;
                }
                bool sabitmi = false;
                if (mFoy.OZEL_TUTAR1_FAIZ_TIP_ID.Value == (int)FaizTip.Özel_Sabit_Faiz)
                    sabitmi = true;
                result.AddRange(FaizHelper.MahsupluFaizHesapla(sabitmi, mFoy, MahsupAltKategori.dvÖzel_Tutar_1,
                                                               mFoy.OZEL_TUTAR1_FAIZ_TIP_ID.Value, dtBaslangicT, dtBitisT, new ParaVeDovizId(mFoy.OZEL_TUTAR1, mFoy.OZEL_TUTAR1_DOVIZ_ID), FaizKalem.ÖZEL_TUTAR_1,
                                                               hesapAraligi, mFoy.OZEL_TUTAR1_FAIZ_ORANI));
            }
            if (mFoy.OZEL_TUTAR2_FAIZ_ISLESINMI && mFoy.OZEL_TUTAR2_FAIZ_TIP_ID.HasValue)
            {
                if (hesapAraligi == Takip.Oncesi)
                {
                    dtBaslangicT = mFoy.OZEL_TUTAR2_FAIZ_BASLANGIC_TARIHI.Value;
                    dtBitisT = mFoy.DAVA_TARIHI.Value;
                }
                else
                {
                    dtBaslangicT = mFoy.DAVA_TARIHI.Value;
                    dtBitisT = mFoy.SON_HESAP_TARIHI;
                }
                bool sabitmi = false;
                if (mFoy.OZEL_TUTAR2_FAIZ_TIP_ID.Value == (int)FaizTip.Özel_Sabit_Faiz)
                    sabitmi = true;
                result.AddRange(FaizHelper.MahsupluFaizHesapla(sabitmi, mFoy, MahsupAltKategori.dvÖzel_Tutar_2,
                                                           mFoy.OZEL_TUTAR2_FAIZ_TIP_ID.Value, dtBaslangicT, dtBitisT, new ParaVeDovizId(mFoy.OZEL_TUTAR2, mFoy.OZEL_TUTAR2_DOVIZ_ID), FaizKalem.ÖZEL_TUTAR_2,
                                                           hesapAraligi, mFoy.OZEL_TUTAR2_FAIZ_ORANI));
            }
            if (mFoy.OZEL_TUTAR3_FAIZ_ISLESINMI && mFoy.OZEL_TUTAR3_FAIZ_TIP_ID.HasValue)
            {
                if (hesapAraligi == Takip.Oncesi)
                {
                    dtBaslangicT = mFoy.OZEL_TUTAR3_FAIZ_BASLANGIC_TARIHI.Value;
                    dtBitisT = mFoy.DAVA_TARIHI.Value;
                }
                else
                {
                    dtBaslangicT = mFoy.DAVA_TARIHI.Value;
                    dtBitisT = mFoy.SON_HESAP_TARIHI;
                }
                bool sabitmi = false;
                if (mFoy.OZEL_TUTAR3_FAIZ_TIP_ID.Value == (int)FaizTip.Özel_Sabit_Faiz)
                    sabitmi = true;
                result.AddRange(FaizHelper.MahsupluFaizHesapla(sabitmi, mFoy, MahsupAltKategori.dvÖzel_Tutar_3,
                                                               mFoy.OZEL_TUTAR3_FAIZ_TIP_ID.Value, dtBaslangicT, dtBitisT, new ParaVeDovizId(mFoy.OZEL_TUTAR3, mFoy.OZEL_TUTAR3_DOVIZ_ID), FaizKalem.ÖZEL_TUTAR_3,
                                                               hesapAraligi, mFoy.OZEL_TUTAR3_FAIZ_ORANI));
            }
            return result;
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

        #region Harc Kalem Getir

        #region Maktu

        ///<summary>
        /// Dava harç kalemi getirir.[MAKTU]
        ///</summary>
        ///<param name="harcTipi"></param>
        ///<param name="matrah"></param>
        ///<param name="harcMiktari"></param>
        ///<param name="tarifeTarihi"></param>
        ///<returns></returns>
        public static AV001_TD_BIL_HARC DavaHarcKalemGetir(MuhasebeAltKategoriId harcTipi, ParaVeDovizId matrah, decimal harcMiktari, DateTime tarifeTarihi)
        {
            return DavaHarcKalemGetir(harcTipi, matrah, harcMiktari, tarifeTarihi, (byte)0);
        }

        ///<summary>
        /// Dava harç kalemi getirir.[MAKTU]
        ///</summary>
        ///<param name="harcTipi"></param>
        ///<param name="matrah"></param>
        ///<param name="harcMiktari"></param>
        ///<param name="tarifeTarihi"></param>
        ///<param name="harcSebebi"></param>
        ///<returns></returns>
        public static AV001_TD_BIL_HARC DavaHarcKalemGetir(MuhasebeAltKategoriId harcTipi, ParaVeDovizId matrah, decimal harcMiktari, DateTime tarifeTarihi, byte harcSebebi)
        {
            AV001_TD_BIL_HARC harc = new AV001_TD_BIL_HARC();
            harc.MAKTU_HARC_KALEM_ID = (int)harcTipi;
            harc.MATRAH_MIKTARI_TUTARI = matrah.Para;
            harc.MATRAH_MIKTARI_DOVIZ_ID = matrah.DovizId;
            harc.HARC_MIKTARI_TUTARI = harcMiktari;
            harc.HARC_MIKTARI_DOVIZ_ID = 1;
            harc.TARIFE_TARIHI = tarifeTarihi;
            harc.HARC_TIP_NO = 1;//maktu
            harc.HARC_TIPI = "MAKTU";
            harc.HARC_SEBEBI = harcSebebi;
            return harc;
        }

        #endregion Maktu

        #region Nispi

        ///<summary>
        /// Dava Harç kalemi getirir [NÝSPÝ]
        ///</summary>
        ///<param name="harcTipi"></param>
        ///<param name="matrah"></param>
        ///<param name="oran"></param>
        ///<param name="harcMiktari"></param>
        ///<param name="tarifeTarihi"></param>
        ///<returns></returns>
        public static AV001_TI_BIL_HARC DavaHarcKalemGetir(DavaNispiHarcTipi harcTipi, ParaVeDovizId matrah, double oran, decimal harcMiktari, DateTime tarifeTarihi)
        {
            return DavaHarcKalemGetir(harcTipi, matrah, oran, harcMiktari, tarifeTarihi, (byte)0);
        }

        ///<summary>
        /// Dava Harç kalemi getirir [NÝSPÝ]
        ///</summary>
        ///<param name="harcTipi"></param>
        ///<param name="matrah"></param>
        ///<param name="oran"></param>
        ///<param name="harcMiktari"></param>
        ///<param name="tarifeTarihi"></param>
        ///<param name="harcSebebi"></param>
        ///<returns></returns>
        public static AV001_TI_BIL_HARC DavaHarcKalemGetir(DavaNispiHarcTipi harcTipi, ParaVeDovizId matrah, double oran, decimal harcMiktari, DateTime tarifeTarihi, byte harcSebebi)
        {
            AV001_TI_BIL_HARC harc = new AV001_TI_BIL_HARC();
            harc.NISPI_HARC_KALEM_ID = (int)harcTipi;
            harc.MATRAH_MIKTARI = matrah.Para;
            harc.MATRAH_MIKTARI_DOVIZ_ID = matrah.DovizId;
            harc.HARC_ORANI = oran;
            harc.HARC_MIKTARI = harcMiktari;
            harc.HARC_MIKTARI_DOVIZ_ID = 1;
            harc.TARIFE_TARIHI = tarifeTarihi;
            harc.HARC_TIP_NO = 0;//nispi
            harc.HARC_TIPI = "NÝSPÝ";
            harc.HARC_SEBEBI = harcSebebi;
            return harc;
        }

        #endregion Nispi

        #endregion Harc Kalem Getir
    }
}