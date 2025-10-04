using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvukatProLib.Hesap
{
    public partial class FaizHelper
    {
        public static bool TaahhutHesabiMi = false;

        public static void BosOlanAlanlariSil(Dictionary<int, decimal> vl)
        {
            List<int> silinecekler = new List<int>();
            //Boþ alanlarýn tespit edilmesi
            foreach (KeyValuePair<int, decimal> pair in vl)
            {
                if (pair.Value == 0)
                    silinecekler.Add(pair.Key);
            }
            //Tespit edilen boþ alanlarýn silinmesi
            foreach (int i in silinecekler)
            {
                vl.Remove(i);
            }
        }

        public static decimal DamgaPuluHesapla(DateTime takipTarihi, decimal tutar, out double oran)
        {
            oran = IcraHarcOraniGetir(takipTarihi, IcraNispiHarcTipi.DAMGA_PULU);

            return (tutar / 100 * (decimal)oran);
        }

        /// <summary>
        /// Ihtiyati haciz ve tedbir için harcKodAçýklamasýna göre TD_CET_MAKTU tablosundan tutar getirir.
        /// </summary>
        /// <param name="gecerlilikTarihi">Tutarýn geçerli olduðu tarih</param>
        /// <param name="harcKodAciklama">Tutarýn Süzüleceði harcKodAçýklama 'ATM KARAR VE ILAM HARCI' gibi</param>
        /// <returns>ParaVeDovizId Tipinden harc tutarý tutar</returns>
        public static ParaVeDovizId DavaHarcTutarGetir(DateTime gecerlilikTarihi, string harcKodAciklama)
        {
            TD_CET_HARC_MAKTUQuery qu2 = new TD_CET_HARC_MAKTUQuery(true);
            qu2.AppendLessThanOrEqual(TD_CET_HARC_MAKTUColumn.TARIH,
                                      gecerlilikTarihi.ToString("yyyy/MM/dd 00:00:00"));
            //qu2.AppendEquals(TD_CET_HARC_MAKTUColumn.HARC_KOD_ACIKLAMA, String.Format("{0}", harcKodAciklama));

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            int cetID = (int)cn.ExecuteScalar("SELECT ID FROM dbo.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI(nolock) WHERE ANA_KATEGORI_ID=4 AND ALT_KATEGORI='" + harcKodAciklama + "'");
            qu2.AppendEquals(TD_CET_HARC_MAKTUColumn.HARC_KOD_ID, cetID.ToString());

            int k = 0;
            TList<TD_CET_HARC_MAKTU> gelenler = DataRepository.TD_CET_HARC_MAKTUProvider.Find(qu2, "TARIH DESC", 0, 1, out k);
            if (gelenler.Count > 0)
            {
                TD_CET_HARC_MAKTU harc = gelenler[0];
                return new ParaVeDovizId(harc.DEGER, harc.HARC_KOD_ID);
            }
            else
            {
                return new ParaVeDovizId(0, 1);
            }
        }

        public static ParaVeDovizId DictionaryIleIslemYap(Dictionary<int, decimal> val)
        {
            if (val.Count > 1)
            {
                decimal ytlToplam = 0;
                foreach (KeyValuePair<int, decimal> pair in val)
                {
                    if (pair.Key == 1)
                        ytlToplam += pair.Value;
                    else if (pair.Key > 1)
                    {
                        //Dövizi bugünkü kurdan çeviriyoruz
                        ytlToplam += DovizHelper.CevirYTL(pair.Value, pair.Key, DateTime.Today);
                    }
                }
                return new ParaVeDovizId(ytlToplam, 1);
            }
            else
            {
                //Tek bir deðer olduðu için
                Dictionary<int, decimal>.Enumerator num = val.GetEnumerator();
                //Tek olan deðere ulaþýyor
                num.MoveNext();
                //bunun Doviztip ve miktar bilgilerini foy nesnesine yazýyoruz.
                return new ParaVeDovizId(num.Current.Value, num.Current.Key == 0 ? 1 : num.Current.Key);
            }
        }

        /// <summary>
        /// Diðer vergi oraný getirmek için kullanýlan method
        /// </summary>
        /// <param name="vergiTur">Diðer vergi türü</param>
        /// <param name="tarih">Verginin geçerli olduðu tarih</param>
        /// <returns>Vergi Oraný</returns>
        public static double DigerVergiOraniGetir(DigerVergiTuru vergiTur, DateTime tarih)
        {
            if (tarih == new DateTime()) tarih = DateTime.Now.Date;
            TDI_CET_DIGER_VERGIQuery qu = new TDI_CET_DIGER_VERGIQuery(true);
            qu.AppendEquals(TDI_CET_DIGER_VERGIColumn.VERGI_TUR_ID, ((int)vergiTur).ToString());
            qu.AppendLessThanOrEqual(TDI_CET_DIGER_VERGIColumn.TARIH, tarih.ToString("yyyy/MM/dd 00:00:00"));
            int k;
            TList<TDI_CET_DIGER_VERGI> vergiler =
                DataRepository.TDI_CET_DIGER_VERGIProvider.Find(qu, "TARIH DESC", 0, 1, out k);
            if (vergiler.Count == 0)
                throw new Exception(vergiTur.ToString() + " bilgisi veri tabanýnda bulunamadý.");
            TDI_CET_DIGER_VERGI vergim = vergiler[0];

            return vergim.VERGI_ORAN;
        }

        public static double FaizOraniGetir(int faizTipId, int? dovizTipId, DateTime? gecerlilikT)
        {
            //smalldatetime hatasý
            DateTime dtGecerlilik = DateTime.Today;
            int nmDovizTip = 1;
            if (gecerlilikT.HasValue)
                dtGecerlilik = gecerlilikT.Value;
            if (dovizTipId.HasValue)
                nmDovizTip = dovizTipId.Value;
            string query = String.Format("Select top(1) TARIFE_TUTARI from TDI_CET_FAIZ_TARIFE where TARIFE_GECERLILIK_BASLANGIC_TARIHI <= CONVERT(datetime,'{0}', 103) AND FAIZ_TIP_ID = {1} AND DOVIZ_TIP_ID = {2} order by TARIFE_GECERLILIK_BASLANGIC_TARIHI DESC", dtGecerlilik.ToShortDateString(), faizTipId, nmDovizTip);
            //string query = String.Format("Select top(1) TARIFE_TUTARI from TDI_CET_FAIZ_TARIFE where TARIFE_GECERLILIK_BASLANGIC_TARIHI <= getdate() AND FAIZ_TIP_ID = {0} AND DOVIZ_TIP_ID = {1} order by TARIFE_GECERLILIK_BASLANGIC_TARIHI DESC", faizTipId, nmDovizTip);
            var result = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, query);

            if (result != null) return Convert.ToDouble(result);
            return 0;
        }

        public static TList<AV001_TI_BIL_ALACAK_NEDEN> GayriNakitAlacakNedenleri(TList<AV001_TI_BIL_ALACAK_NEDEN> alacakNedenleri)
        {
            TList<AV001_TI_BIL_ALACAK_NEDEN> deposuzlaR = GayriNakitleriCikar(alacakNedenleri);
            TList<AV001_TI_BIL_ALACAK_NEDEN> depolular = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in alacakNedenleri)
            {
                if (!deposuzlaR.Contains(neden))
                    depolular.Add(neden);
            }
            return depolular;
        }

        /// <summary>
        /// Formda girilmiþ alacak nedenleri ile ilgili asýl alacak hesaplamasý yapar.
        /// </summary>
        public static void HesaplaAsilAlacak(AV001_TI_BIL_FOY mFoy)
        {
            #region Asýl Alacak

            mFoy.ASIL_ALACAK = 0;

            Dictionary<int, decimal> tutar = new Dictionary<int, decimal>();
            Dictionary<int, decimal> asilAlacak = new Dictionary<int, decimal>();
            Dictionary<int, decimal> depoAlacak = new Dictionary<int, decimal>();

            decimal asilAlacakToplami = 0;
            decimal tutarToplami = 0;

            int nVadeTarihindeYTL, nTakipTarihindeYTL, nOdemeTarihindeYTL = 0;

            nVadeTarihindeYTL = mFoy.AV001_TI_BIL_ALACAK_NEDENCollection.FindAll(vi => vi.HESAPLAMA_MODU == 1).Count;//(AV001_TI_BIL_ALACAK_NEDENColumn.HESAPLAMA_MODU, 1).Count;
            nTakipTarihindeYTL = mFoy.AV001_TI_BIL_ALACAK_NEDENCollection.FindAll(vi => vi.HESAPLAMA_MODU == 2).Count;//(AV001_TI_BIL_ALACAK_NEDENColumn.HESAPLAMA_MODU, 2).Count;
            nOdemeTarihindeYTL = mFoy.AV001_TI_BIL_ALACAK_NEDENCollection.FindAll(vi => vi.HESAPLAMA_MODU == 3).Count;//(AV001_TI_BIL_ALACAK_NEDENColumn.HESAPLAMA_MODU, 3).Count;

            DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(mFoy.AV001_TI_BIL_ALACAK_NEDENCollection, false, DeepLoadType.IncludeChildren, typeof(TI_KOD_ALACAK_NEDEN));

            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in mFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                if (HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(neden))
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
                            if (!item.TAZMIN_TUTARI.HasValue && !item.TAZMIN_TUTARI_DOVIZ_ID.HasValue) continue;

                            if (nVadeTarihindeYTL == 0 && nTakipTarihindeYTL == 0)  //Eðer sadece Ödeme tarihinde YTL seçilmiþ ise
                            {
                                if (asilAlacak.ContainsKey(item.TAZMIN_TUTARI_DOVIZ_ID.Value))
                                    asilAlacak[item.TAZMIN_TUTARI_DOVIZ_ID.Value] += item.TAZMIN_TUTARI.Value;
                                else
                                    asilAlacak.Add(item.TAZMIN_TUTARI_DOVIZ_ID.Value, item.TAZMIN_TUTARI.Value);

                                //YKS için eklendi.
                                if (tutar.ContainsKey(item.TAZMIN_TUTARI_DOVIZ_ID.Value))
                                    tutar[item.TAZMIN_TUTARI_DOVIZ_ID.Value] += item.TAZMIN_TUTARI.Value;
                                else
                                    tutar.Add(item.TAZMIN_TUTARI_DOVIZ_ID.Value, item.TAZMIN_TUTARI.Value);
                                //

                                var asilAlacakToplamiTekDovizliAlacak = ParaVeDovizId.Topla(asilAlacak.Select(vi => new ParaVeDovizId(vi.Value, vi.Key, DateTime.Today)).ToList());
                                mFoy.ASIL_ALACAK = asilAlacakToplamiTekDovizliAlacak.Para;
                                mFoy.ASIL_ALACAK_DOVIZ_ID = asilAlacakToplamiTekDovizliAlacak.DovizId;

                                //YKS için eklendi.
                                var tutarToplamiTekDovizliAlacak = ParaVeDovizId.Topla(tutar.Select(vi => new ParaVeDovizId(vi.Value, vi.Key, DateTime.Today)).ToList());
                                mFoy.PROTOKOL_MIKTARI = tutarToplamiTekDovizliAlacak.Para;
                                mFoy.PROTOKOL_MIKTARI_DOVIZ_ID = tutarToplamiTekDovizliAlacak.DovizId;
                                //

                                //mFoy.ASIL_ALACAK += DovizHelper.CevirYTL(neden.ISLEME_KONAN_TUTAR, neden.ISLEME_KONAN_TUTAR_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value, neden.ALACAK_NEDEN_KOD_ID.Value);
                                //mFoy.ASIL_ALACAK_DOVIZ_ID = 1;// TL gösterilir.
                            }
                            else
                            {
                                switch (neden.HESAPLAMA_MODU)
                                {
                                    case 1:
                                        //VadeTarihindeYTL
                                        mFoy.ASIL_ALACAK += DovizHelper.CevirYTL(item.TAZMIN_TUTARI.Value, item.TAZMIN_TUTARI_DOVIZ_ID.Value, item.TAZMIN_TARIHI.Value.Date, neden.ALACAK_NEDEN_KOD_ID);

                                        //YKS için eklendi.
                                        mFoy.PROTOKOL_MIKTARI += DovizHelper.CevirYTL(item.TAZMIN_TUTARI.Value, item.TAZMIN_TUTARI_DOVIZ_ID.Value, item.TAZMIN_TARIHI.Value.Date, neden.ALACAK_NEDEN_KOD_ID);
                                        break;

                                    case 2:
                                        //TakipTarihindeYTL
                                        mFoy.ASIL_ALACAK += DovizHelper.CevirYTL(item.TAZMIN_TUTARI.Value, item.TAZMIN_TUTARI_DOVIZ_ID.Value, mFoy.TAKIP_TARIHI.Value, neden.ALACAK_NEDEN_KOD_ID);

                                        //YKS için eklendi.
                                        mFoy.PROTOKOL_MIKTARI += DovizHelper.CevirYTL(item.TAZMIN_TUTARI.Value, item.TAZMIN_TUTARI_DOVIZ_ID.Value, mFoy.TAKIP_TARIHI.Value, neden.ALACAK_NEDEN_KOD_ID);
                                        break;

                                    case 3:
                                        //OdemeTarihindeYTL
                                        mFoy.ASIL_ALACAK += DovizHelper.CevirYTL(item.TAZMIN_TUTARI.Value, item.TAZMIN_TUTARI_DOVIZ_ID.Value, DateTime.Today, neden.ALACAK_NEDEN_KOD_ID);

                                        //YKS için eklendi.
                                        mFoy.PROTOKOL_MIKTARI += DovizHelper.CevirYTL(item.TAZMIN_TUTARI.Value, item.TAZMIN_TUTARI_DOVIZ_ID.Value, DateTime.Today, neden.ALACAK_NEDEN_KOD_ID);
                                        break;

                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (depoAlacak.ContainsKey(neden.ISLEME_KONAN_TUTAR_DOVIZ_ID ?? 1))
                            depoAlacak[neden.ISLEME_KONAN_TUTAR_DOVIZ_ID ?? 1] += neden.ISLEME_KONAN_TUTAR;
                        else
                            depoAlacak.Add(neden.ISLEME_KONAN_TUTAR_DOVIZ_ID ?? 1, neden.ISLEME_KONAN_TUTAR);

                        asilAlacakToplami += DovizHelper.CevirYTL(neden.ISLEME_KONAN_TUTAR, neden.ISLEME_KONAN_TUTAR_DOVIZ_ID, DateTime.Today.Date, neden.ALACAK_NEDEN_KOD_ID);

                        //YKS için eklendi.
                        tutarToplami += DovizHelper.CevirYTL(neden.TUTARI, neden.TUTAR_DOVIZ_ID, DateTime.Today.Date, neden.ALACAK_NEDEN_KOD_ID);
                    }
                }
                else
                {
                    if (neden.ISLEME_KONAN_TUTAR == 0)
                    {
                        neden.ISLEME_KONAN_TUTAR = neden.TUTARI;
                        neden.ISLEME_KONAN_TUTAR_DOVIZ_ID = neden.TUTAR_DOVIZ_ID;
                    }

                    if (neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.HasValue && neden.ISLEME_KONAN_TUTAR != 0 && neden.AN_URETIP_TIP != (int)AN_URETIP_TIP.MunzamSenet && neden.AN_URETIP_TIP != (int)AN_URETIP_TIP.HesapDisi)
                    {
                        DovizHelper.GetMerkezBankasiBilgisi(neden.ALACAK_NEDEN_KOD_ID);

                        //if (asilAlacak.ContainsKey(neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value))
                        //    asilAlacak[neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value] += neden.ISLEME_KONAN_TUTAR;
                        //else
                        //    asilAlacak.Add(neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value, neden.ISLEME_KONAN_TUTAR);

                        if (nVadeTarihindeYTL == 0 && nTakipTarihindeYTL == 0)  //Eðer sadece Ödeme tarihinde YTL seçilmiþ ise
                        {
                            if (asilAlacak.ContainsKey(neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value))
                                asilAlacak[neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value] += neden.ISLEME_KONAN_TUTAR;
                            else
                                asilAlacak.Add(neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value, neden.ISLEME_KONAN_TUTAR);

                            var asilAlacakToplamiTekDovizliAlacak = ParaVeDovizId.Topla(asilAlacak.Select(vi => new ParaVeDovizId(vi.Value, vi.Key, DateTime.Today)).ToList());
                            mFoy.ASIL_ALACAK = asilAlacakToplamiTekDovizliAlacak.Para;
                            mFoy.ASIL_ALACAK_DOVIZ_ID = asilAlacakToplamiTekDovizliAlacak.DovizId;

                            //mFoy.ASIL_ALACAK += DovizHelper.CevirYTL(neden.ISLEME_KONAN_TUTAR, neden.ISLEME_KONAN_TUTAR_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value, neden.ALACAK_NEDEN_KOD_ID.Value);
                            //mFoy.ASIL_ALACAK_DOVIZ_ID = 1;// TL gösterilir.
                        }
                        else
                        {
                            switch (neden.HESAPLAMA_MODU)
                            {
                                case 1:
                                    //VadeTarihindeYTL
                                    if (neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.HasValue && neden.VADE_TARIHI.HasValue)
                                    {
                                        mFoy.ASIL_ALACAK += DovizHelper.CevirYTL(neden.ISLEME_KONAN_TUTAR,
                                                                          neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                                                                          neden.VADE_TARIHI.Value.Date, neden.ALACAK_NEDEN_KOD_ID);
                                    }
                                    break;

                                case 2:
                                    //TakipTarihindeYTL
                                    if (neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.HasValue && mFoy.TAKIP_TARIHI.HasValue)
                                    {
                                        mFoy.ASIL_ALACAK += DovizHelper.CevirYTL(neden.ISLEME_KONAN_TUTAR,
                                                                          neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                                                                          mFoy.TAKIP_TARIHI.Value, neden.ALACAK_NEDEN_KOD_ID);
                                    }
                                    break;

                                case 3:
                                    //OdemeTarihindeYTL
                                    if (neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.HasValue)
                                    {
                                        mFoy.ASIL_ALACAK += DovizHelper.CevirYTL(neden.ISLEME_KONAN_TUTAR,
                                                                          neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                                                                          DateTime.Today, neden.ALACAK_NEDEN_KOD_ID);
                                    }
                                    break;

                                default:
                                    break;
                            }
                        }
                    }

                    #region YKS için eklendi. MB

                    if (neden.TUTARI != 0 && neden.AN_URETIP_TIP != (int)AN_URETIP_TIP.MunzamSenet && neden.AN_URETIP_TIP != (int)AN_URETIP_TIP.HesapDisi)
                    {
                        DovizHelper.GetMerkezBankasiBilgisi(neden.ALACAK_NEDEN_KOD_ID);

                        //if (asilAlacak.ContainsKey(neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value))
                        //    asilAlacak[neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value] += neden.ISLEME_KONAN_TUTAR;
                        //else
                        //    asilAlacak.Add(neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value, neden.ISLEME_KONAN_TUTAR);

                        if (nVadeTarihindeYTL == 0 && nTakipTarihindeYTL == 0)  //Eðer sadece Ödeme tarihinde YTL seçilmiþ ise
                        {
                            if (tutar.ContainsKey(neden.TUTAR_DOVIZ_ID.Value))
                                tutar[neden.TUTAR_DOVIZ_ID.Value] += neden.TUTARI;
                            else
                                tutar.Add(neden.TUTAR_DOVIZ_ID.Value, neden.TUTARI);

                            var asilAlacakToplamiTekDovizliAlacak = ParaVeDovizId.Topla(asilAlacak.Select(vi => new ParaVeDovizId(vi.Value, vi.Key, DateTime.Today)).ToList());
                            mFoy.PROTOKOL_MIKTARI = asilAlacakToplamiTekDovizliAlacak.Para;
                            mFoy.PROTOKOL_MIKTARI_DOVIZ_ID = asilAlacakToplamiTekDovizliAlacak.DovizId;

                            //mFoy.ASIL_ALACAK += DovizHelper.CevirYTL(neden.ISLEME_KONAN_TUTAR, neden.ISLEME_KONAN_TUTAR_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value, neden.ALACAK_NEDEN_KOD_ID.Value);
                            //mFoy.ASIL_ALACAK_DOVIZ_ID = 1;// TL gösterilir.
                        }
                        else
                        {
                            switch (neden.HESAPLAMA_MODU)
                            {
                                case 1:
                                    //VadeTarihindeYTL
                                    if (neden.VADE_TARIHI.HasValue)
                                    {
                                        mFoy.PROTOKOL_MIKTARI += DovizHelper.CevirYTL(neden.TUTARI,
                                                                          neden.TUTAR_DOVIZ_ID.Value,
                                                                          neden.VADE_TARIHI.Value.Date, neden.ALACAK_NEDEN_KOD_ID);
                                    }
                                    break;

                                case 2:
                                    //TakipTarihindeYTL
                                    if (neden.TUTAR_DOVIZ_ID.HasValue && mFoy.TAKIP_TARIHI.HasValue)
                                    {
                                        mFoy.PROTOKOL_MIKTARI += DovizHelper.CevirYTL(neden.TUTARI,
                                                                          neden.TUTAR_DOVIZ_ID.Value,
                                                                          mFoy.TAKIP_TARIHI.Value, neden.ALACAK_NEDEN_KOD_ID);
                                    }
                                    break;

                                case 3:
                                    //OdemeTarihindeYTL
                                    if (neden.TUTAR_DOVIZ_ID.HasValue)
                                    {
                                        mFoy.PROTOKOL_MIKTARI += DovizHelper.CevirYTL(neden.TUTARI,
                                                                          neden.TUTAR_DOVIZ_ID.Value,
                                                                          DateTime.Today, neden.ALACAK_NEDEN_KOD_ID);
                                    }
                                    break;

                                default:
                                    break;
                            }
                        }
                    }

                    #endregion YKS için eklendi. MB
                }
            }

            #region Gayri Nakti Alacak Toplanýyor

            if (depoAlacak.Count > 0)
            {
                var depoAlacagiToplami = ParaVeDovizId.Topla(depoAlacak.Select(vi => new ParaVeDovizId(vi.Value, vi.Key)).ToList());
                mFoy.GAYRI_NAKTI_ALACAK = depoAlacagiToplami.Para;
                mFoy.GAYRI_NAKTI_ALACAK_DOVIZ_ID = depoAlacagiToplami.DovizId;

                if (mFoy.ID > 0)
                {
                    ParaVeDovizId maktuHarc = IcraHarcTutarGetir(mFoy.TAKIP_TARIHI ?? DateTime.Now, (int)MuhasebeAltKategoriId.MAKTU_ICRA_HARC);
                    ParaVeDovizId maktuVekalet = IcraHarcTutarGetir(mFoy.TAKIP_TARIHI ?? DateTime.Now, (int)MuhasebeAltKategoriId.MAKTU_ICRA_VEKALET);

                    mFoy.DEPO_HARCI = maktuHarc.Para;
                    mFoy.DEPO_HARCI_DOVIZ_ID = maktuHarc.DovizId;

                    mFoy.DEPO_VEKALET_UCRETI = maktuVekalet.Para;
                    mFoy.DEPO_VEKALET_UCRET_DOVIZ_ID = maktuVekalet.DovizId;
                }
            }

            #endregion Gayri Nakti Alacak Toplanýyor

            //if (nVadeTarihindeYTL == 0 && nTakipTarihindeYTL == 0)  //Eðer sadece Ödeme tarihinde YTL seçilmiþ ise
            //{
            //    var asilAlacakToplami = ParaVeDovizId.Topla(asilAlacak.Select(vi => new ParaVeDovizId(vi.Value, vi.Key, DateTime.Today)).ToList());

            //    mFoy.ASIL_ALACAK = asilAlacakToplami.Para;
            //    mFoy.ASIL_ALACAK_DOVIZ_ID = asilAlacakToplami.DovizId;

            //}
            //else //Diðer tüm olasýlýklar için
            //{
            //    #region Tutarlar toplanýyor
            //    decimal ytlToplam = 0;

            //    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in mFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            //    {
            //        DovizHelper.GetMerkezBankasiBilgisi(neden.ALACAK_NEDEN_KOD_ID);

            //        if (HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(neden)) return;

            //        switch (neden.HESAPLAMA_MODU)
            //        {
            //            case 1:
            //                //VadeTarihindeYTL
            //                if (neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.HasValue && neden.VADE_TARIHI.HasValue)
            //                {
            //                    ytlToplam += DovizHelper.CevirYTL(neden.ISLEME_KONAN_TUTAR,
            //                                                      neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
            //                                                      neden.VADE_TARIHI.Value.Date);
            //                }
            //                break;
            //            case 2:
            //                //TakipTarihindeYTL
            //                if (neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.HasValue && mFoy.TAKIP_TARIHI.HasValue)
            //                {
            //                    ytlToplam += DovizHelper.CevirYTL(neden.ISLEME_KONAN_TUTAR,
            //                                                      neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
            //                                                      mFoy.TAKIP_TARIHI.Value);
            //                }
            //                break;
            //            case 3:
            //                //OdemeTarihindeYTL
            //                if (neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.HasValue)
            //                {
            //                    ytlToplam += DovizHelper.CevirYTL(neden.ISLEME_KONAN_TUTAR,
            //                                                      neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
            //                                                      DateTime.Today);
            //                }
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //    #endregion

            //    mFoy.ASIL_ALACAK = ytlToplam;
            //    mFoy.ASIL_ALACAK_DOVIZ_ID = 1;
            //}

            #endregion Asýl Alacak

            #region DamgaPulu Hesapla

            mFoy.DAMGA_PULU = 0;
            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in mFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                if (neden.DAMGA_PULU_HESAPLANSIN)
                {
                    double oran = 0;

                    DovizHelper.GetMerkezBankasiBilgisi(neden.ALACAK_NEDEN_KOD_ID);

                    mFoy.DAMGA_PULU +=
                        FaizHelper.DamgaPuluHesapla(mFoy.TAKIP_TARIHI.Value,
                                                    DovizHelper.CevirYTL(neden.ISLEME_KONAN_TUTAR,
                                                                         neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                                                                         mFoy.TAKIP_TARIHI.Value), out oran);
                    FaizHelper.IcraHarcKalemiEkleGetir(mFoy, IcraNispiHarcTipi.DAMGA_PULU, mFoy.DAMGA_PULU, mFoy.TAKIP_TARIHI.Value,
                        new ParaVeDovizId(neden.ISLEME_KONAN_TUTAR, neden.ISLEME_KONAN_TUTAR_DOVIZ_ID), oran);
                }
            }

            #endregion DamgaPulu Hesapla

            mFoy.DAMGA_PULU_DOVIZ_ID = 1;
        }

        public static void HesaplaDigerGiderler(AV001_TI_BIL_FOY mFoy)
        {
            mFoy.DIGER_GIDERLER = 0;

            List<ParaVeDovizId> paralar = new List<ParaVeDovizId>();
            foreach (AV001_TDI_BIL_MASRAF_AVANS masraf in mFoy.AV001_TDI_BIL_MASRAF_AVANSCollection)
            {
                if (masraf.MASRAF_AVANS_TIP == 1)
                {
                    foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                    {
                        if (detay.TO_HESAP_CETVEL_YERI == (int)IcraHesapCetveli.Diger_Giderler)
                            paralar.Add(new ParaVeDovizId(detay.TOPLAM_TUTAR, detay.BIRIM_FIYAT_DOVIZ_ID));
                    }
                }
            }
            ParaVeDovizId digerGiderix = FaizHelper.ParalariTopla(paralar, DateTime.Today);
            mFoy.DIGER_GIDERLER = digerGiderix.Para;
            mFoy.DIGER_GIDERLER_DOVIZ_ID = digerGiderix.DovizId;
        }

        public static void HesaplaFeragatToplami(AV001_TI_BIL_FOY mFoy)
        {
            List<ParaVeDovizId> paralar = new List<ParaVeDovizId>();
            foreach (AV001_TI_BIL_FERAGAT feragat in mFoy.AV001_TI_BIL_FERAGATCollection)
            {
                paralar.Add(new ParaVeDovizId(feragat.FERAGAT_MIKTAR, feragat.FERAGAT_MIKTAR_DOVIZ_ID));
            }
            ParaVeDovizId feragatx = FaizHelper.ParalariTopla(paralar, DateTime.Today);
            mFoy.FERAGAT_TOPLAMI = feragatx.Para * -1;
            mFoy.FERAGAT_TOPLAMI_DOVIZ_ID = feragatx.DovizId;
        }

        public static void HesaplaFoyTarafUzerine(AV001_TI_BIL_FOY mFoy)
        {
            foreach (AV001_TI_BIL_FOY_TARAF foyTaraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
            {
                if (!foyTaraf.TAKIP_EDEN_MI)
                {
                    #region foyTaraf Property Set

                    foyTaraf.IHTAR_GIDERI_DOVIZ_ID = 1;
                    foyTaraf.IHTAR_GIDERI = 0;
                    foyTaraf.PROTESTO_GIDERI_DOVIZ_ID = 1;
                    foyTaraf.PROTESTO_GIDERI = 0;
                    foyTaraf.TAZMINATI_DOVIZ_ID = 1;
                    foyTaraf.TAZMINATI = 0;
                    foyTaraf.CEK_TAZMINATI_DOVIZ_ID = 1;
                    foyTaraf.CEK_TAZMINATI = 0;
                    foyTaraf.KOMISYONU_DOVIZ_ID = 1;
                    foyTaraf.KOMISYONU = 0;
                    foyTaraf.SORUMLU_OLUNAN_MIKTAR = 0;
                    foyTaraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = 1;
                    foyTaraf.ISLEMIS_FAIZ_DOVIZ_ID = 1;
                    foyTaraf.ISLEMIS_FAIZ = 0;
                    foyTaraf.ASIL_ALACAK_DOVIZ_ID = 1;
                    foyTaraf.ASIL_ALACAK = 0;
                    foyTaraf.BSMV_TO_DOVIZ_ID = 1;
                    foyTaraf.BSMV_TO = 0;
                    foyTaraf.KKDV_TO_DOVIZ_ID = 1;
                    foyTaraf.KKDV_TO = 0;
                    foyTaraf.OIV_TO_DOVIZ_ID = 1;
                    foyTaraf.OIV_TO = 0;
                    foyTaraf.KDV_TO_DOVIZ_ID = 1;
                    foyTaraf.KDV_TO = 0;
                    foyTaraf.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = 1;
                    foyTaraf.KARSILIKSIZ_CEK_TAZMINATI = 0;
                    foyTaraf.CEK_KOMISYONU_DOVIZ_ID = 1;
                    foyTaraf.CEK_KOMISYONU = 0;
                    foyTaraf.ILAM_YARGILAMA_GIDERI_DOVIZ_ID = 1;
                    foyTaraf.ILAM_YARGILAMA_GIDERI = 0;
                    foyTaraf.ILAM_BK_YARG_ONAMA_DOVIZ_ID = 1;
                    foyTaraf.ILAM_BK_YARG_ONAMA = 0;
                    foyTaraf.ILAM_TEBLIG_GIDERI_DOVIZ_ID = 1;
                    foyTaraf.ILAM_TEBLIG_GIDERI = 0;
                    foyTaraf.ILAM_INKAR_TAZMINATI_DOVIZ_ID = 1;
                    foyTaraf.ILAM_INKAR_TAZMINATI = 0;
                    foyTaraf.ILAM_VEK_UCR_DOVIZ_ID = 1;
                    foyTaraf.ILAM_VEK_UCR = 0;
                    foyTaraf.OZEL_TAZMINAT_DOVIZ_ID = 1;
                    foyTaraf.OZEL_TAZMINAT = 0;
                    foyTaraf.TAKIP_CIKISI_DOVIZ_ID = 1;
                    foyTaraf.TAKIP_CIKISI = 0;
                    foyTaraf.SONRAKI_FAIZ_DOVIZ_ID = 1;
                    foyTaraf.SONRAKI_FAIZ = 0;
                    foyTaraf.SONRAKI_TAZMINAT_DOVIZ_ID = 1;
                    foyTaraf.SONRAKI_TAZMINAT = 0;
                    foyTaraf.BSMV_TS_DOVIZ_ID = 1;
                    foyTaraf.BSMV_TS = 0;
                    foyTaraf.OIV_TS_DOVIZ_ID = 1;
                    foyTaraf.OIV_TS = 0;
                    foyTaraf.KDV_TS_DOVIZ_ID = 1;
                    foyTaraf.KDV_TS = 0;
                    foyTaraf.ILK_GIDERLER_DOVIZ_ID = 1;
                    foyTaraf.ILK_GIDERLER = 0;
                    foyTaraf.PESIN_HARC_DOVIZ_ID = 1;
                    foyTaraf.PESIN_HARC = 0;
                    foyTaraf.ODENEN_TAHSIL_HARCI_DOVIZ_ID = 1;
                    foyTaraf.ODENEN_TAHSIL_HARCI = 0;
                    foyTaraf.KALAN_TAHSIL_HARCI_DOVIZ_ID = 1;
                    foyTaraf.KALAN_TAHSIL_HARCI = 0;
                    foyTaraf.MASAYA_KATILMA_HARCI_DOVIZ_ID = 1;
                    foyTaraf.MASAYA_KATILMA_HARCI = 0;
                    foyTaraf.PAYLASMA_HARCI_DOVIZ_ID = 1;
                    foyTaraf.PAYLASMA_HARCI = 0;
                    foyTaraf.DAVA_GIDERLERI_DOVIZ_ID = 1;
                    foyTaraf.DAVA_GIDERLERI = 0;
                    foyTaraf.DIGER_GIDERLER_DOVIZ_ID = 1;
                    foyTaraf.DIGER_GIDERLER = 0;
                    foyTaraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID = 1;
                    foyTaraf.TAKIP_VEKALET_UCRETI = 0;
                    foyTaraf.DAVA_INKAR_TAZMINATI_DOVIZ_ID = 1;
                    foyTaraf.DAVA_INKAR_TAZMINATI = 0;
                    foyTaraf.DAVA_VEKALET_UCRETI_DOVIZ_ID = 1;
                    foyTaraf.DAVA_VEKALET_UCRETI = 0;
                    foyTaraf.ODEME_TOPLAMI_DOVIZ_ID = 1;
                    foyTaraf.ODEME_TOPLAMI = 0;
                    foyTaraf.TO_ODEME_TOPLAMI_DOVIZ_ID = 1;
                    foyTaraf.TO_ODEME_TOPLAMI = 0;
                    foyTaraf.MAHSUP_TOPLAMI_DOVIZ_ID = 1;
                    foyTaraf.MAHSUP_TOPLAMI = 0;
                    foyTaraf.FERAGAT_TOPLAMI_DOVIZ_ID = 1;
                    foyTaraf.FERAGAT_TOPLAMI = 0;
                    foyTaraf.ALACAK_TOPLAMI_DOVIZ_ID = 1;
                    foyTaraf.ALACAK_TOPLAMI = 0;
                    foyTaraf.KALAN_DOVIZ_ID = 1;
                    foyTaraf.KALAN = 0;
                    foyTaraf.TAHLIYE_VEK_UCR_DOVIZ_ID = 1;
                    foyTaraf.TAHLIYE_VEK_UCR = 0;
                    foyTaraf.DIGER_HARC_DOVIZ_ID = 1;
                    foyTaraf.DIGER_HARC = 0;
                    foyTaraf.TD_GIDERI_DOVIZ_ID = 1;
                    foyTaraf.TD_GIDERI = 0;
                    foyTaraf.TD_BAKIYE_HARC_DOVIZ_ID = 1;
                    foyTaraf.TD_BAKIYE_HARC = 0;
                    foyTaraf.TD_VEK_UCR_DOVIZ_ID = 1;
                    foyTaraf.TD_VEK_UCR = 0;
                    foyTaraf.TD_TEBLIG_GIDERI_DOVIZ_ID = 1;
                    foyTaraf.TD_TEBLIG_GIDERI = 0;
                    foyTaraf.BIRIKMIS_NAFAKA_DOVIZ_ID = 1;
                    foyTaraf.BIRIKMIS_NAFAKA = 0;
                    foyTaraf.ICRA_INKAR_TAZMINATI_DOVIZ_ID = 1;
                    foyTaraf.ICRA_INKAR_TAZMINATI = 0;
                    foyTaraf.DAMGA_PULU_DOVIZ_ID = 1;
                    foyTaraf.DAMGA_PULU = 0;
                    foyTaraf.PROTOKOL_MIKTARI_DOVIZ_ID = 1;
                    foyTaraf.PROTOKOL_MIKTARI = 0;
                    foyTaraf.KARSILIK_TUTARI_DOVIZ_ID = 1;
                    foyTaraf.KARSILIK_TUTARI = 0;
                    foyTaraf.HESAPLANMIS_FAIZ = 0;
                    foyTaraf.HESAPLANMIS_FAIZ_DOVIZ_ID = 1;
                    foyTaraf.HESAPLANMIS_KKDF = 0;
                    foyTaraf.HESAPLANMIS_KKDF_DOVIZ_ID = 1;
                    foyTaraf.HESAPLANMIS_BSMV = 0;
                    foyTaraf.HESAPLANMIS_BSMV_DOVIZ_ID = 1;
                    foyTaraf.HESAPLANMIS_KDV = 0;
                    foyTaraf.HESAPLANMIS_KDV_DOVIZ_ID = 1;
                    foyTaraf.HESAPLANMIS_OIV = 0;
                    foyTaraf.HESAPLANMIS_OIV_DOVIZ_ID = 1;
                    foyTaraf.TO_MASRAF_TOPLAMI = 0;
                    foyTaraf.TO_MASRAF_TOPLAMI_DOVIZ_ID = 1;
                    foyTaraf.TS_MASRAF_TOPLAMI = 0;
                    foyTaraf.TS_MASRAF_TOPLAMI_DOVIZ_ID = 1;
                    foyTaraf.TUM_MASRAF_TOPLAMI = 0;
                    foyTaraf.TUM_MASRAF_TOPLAMI_DOVIZ_ID = 1;
                    foyTaraf.HARC_TOPLAMI = 0;
                    foyTaraf.HARC_TOPLAMI_DOVIZ_ID = 1;
                    foyTaraf.TO_VEKALET_TOPLAMI = 0;
                    foyTaraf.TO_VEKALET_TOPLAMI_DOVIZ_ID = 1;
                    foyTaraf.TS_VEKALET_TOPLAMI = 0;
                    foyTaraf.TS_VEKALET_TOPLAMI_DOVIZ_ID = 1;
                    foyTaraf.TUM_VEKALET_TOPLAMI = 0;
                    foyTaraf.TUM_VEKALET_TOPLAMI_DOVIZ_ID = 1;
                    foyTaraf.KARSI_VEKALET_TOPLAMI = 0;
                    foyTaraf.KARSI_VEKALET_TOPLAMI_DOVIZ_ID = 1;
                    foyTaraf.FAIZ_TOPLAMI = 0;
                    foyTaraf.FAIZ_TOPLAMI_DOVIZ_ID = 1;
                    foyTaraf.ILAM_UCRETLER_TOPLAMI = 0;
                    foyTaraf.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID = 1;
                    foyTaraf.IT_VEKALET_UCRETI_DOVIZ_ID = 1;
                    foyTaraf.IT_VEKALET_UCRETI = 0;
                    foyTaraf.IT_GIDERI_DOVIZ_ID = 1;
                    foyTaraf.IT_GIDERI = 0;
                    foyTaraf.IH_VEKALET_UCRETI_DOVIZ_ID = 1;
                    foyTaraf.IH_VEKALET_UCRETI = 0;
                    foyTaraf.IH_GIDERI_DOVIZ_ID = 1;
                    foyTaraf.IH_GIDERI = 0;
                    foyTaraf.IT_HACIZDE_ODENEN_DOVIZ_ID = 1;
                    foyTaraf.IT_HACIZDE_ODENEN = 0;

                    #endregion foyTaraf Property Set

                    foyTaraf.SORUMLULUK_ORANI = SorumlulukOraniGetirByCariId(foyTaraf.CARI_ID.Value, mFoy);

                    TList<AV001_TI_BIL_ALACAK_NEDEN> gayrisizNedenler = GayriNakitleriCikar(mFoy);
                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in gayrisizNedenler)
                    {
                        foreach (
                            AV001_TI_BIL_ALACAK_NEDEN_TARAF taraf in neden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                        {
                            if (taraf.TARAF_CARI_ID == foyTaraf.CARI_ID.Value)
                            {
                                ParaVeDovizId toplamIhtarGideri = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.IHTAR_GIDERI, taraf.IHTAR_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.IHTAR_GIDERI, foyTaraf.IHTAR_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.IHTAR_GIDERI = toplamIhtarGideri.Para;
                                foyTaraf.IHTAR_GIDERI_DOVIZ_ID = toplamIhtarGideri.DovizId;

                                ParaVeDovizId toplamPROTESTO_GIDERI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.PROTESTO_GIDERI, taraf.PROTESTO_GIDERI_DOVIZ_ID.Value, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.PROTESTO_GIDERI, foyTaraf.PROTESTO_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.PROTESTO_GIDERI = toplamPROTESTO_GIDERI.Para;
                                foyTaraf.PROTESTO_GIDERI_DOVIZ_ID = toplamPROTESTO_GIDERI.DovizId;

                                ParaVeDovizId toplamTAZMINATI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.TAZMINATI, taraf.TAZMINATI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.TAZMINATI, foyTaraf.TAZMINATI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.TAZMINATI = toplamTAZMINATI.Para;
                                foyTaraf.TAZMINATI_DOVIZ_ID = toplamTAZMINATI.DovizId;

                                ParaVeDovizId toplamCEK_TAZMINATI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.CEK_TAZMINATI, taraf.CEK_TAZMINATI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.CEK_TAZMINATI, foyTaraf.CEK_TAZMINATI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.CEK_TAZMINATI = toplamCEK_TAZMINATI.Para;
                                foyTaraf.CEK_TAZMINATI_DOVIZ_ID = toplamCEK_TAZMINATI.DovizId;

                                ParaVeDovizId toplamKOMISYONU = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.KOMISYONU, taraf.KOMISYONU_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.KOMISYONU, foyTaraf.KOMISYONU_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.KOMISYONU = toplamKOMISYONU.Para;
                                foyTaraf.KOMISYONU_DOVIZ_ID = toplamKOMISYONU.DovizId;

                                ParaVeDovizId toplamSORUMLU_OLUNAN_MIKTAR = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.SORUMLU_OLUNAN_MIKTAR, taraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.SORUMLU_OLUNAN_MIKTAR, foyTaraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.SORUMLU_OLUNAN_MIKTAR = toplamSORUMLU_OLUNAN_MIKTAR.Para;
                                foyTaraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = toplamSORUMLU_OLUNAN_MIKTAR.DovizId;

                                ParaVeDovizId toplamISLEMIS_FAIZ = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.ISLEMIS_FAIZ, taraf.ISLEMIS_FAIZ_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.ISLEMIS_FAIZ, foyTaraf.ISLEMIS_FAIZ_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.ISLEMIS_FAIZ = toplamISLEMIS_FAIZ.Para;
                                foyTaraf.ISLEMIS_FAIZ_DOVIZ_ID = toplamISLEMIS_FAIZ.DovizId;

                                foyTaraf.ISLEMIS_FAIZ = (foyTaraf.ISLEMIS_FAIZ < 0) ? 0 : foyTaraf.ISLEMIS_FAIZ;

                                ParaVeDovizId toplamASIL_ALACAK = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.ASIL_ALACAK, taraf.ASIL_ALACAK_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.ASIL_ALACAK, foyTaraf.ASIL_ALACAK_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.ASIL_ALACAK = toplamASIL_ALACAK.Para;
                                foyTaraf.ASIL_ALACAK_DOVIZ_ID = toplamASIL_ALACAK.DovizId;

                                ParaVeDovizId toplamBSMV_TO = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.BSMV_TO, taraf.BSMV_TO_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.BSMV_TO, foyTaraf.BSMV_TO_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.BSMV_TO = toplamBSMV_TO.Para;
                                foyTaraf.BSMV_TO_DOVIZ_ID = toplamBSMV_TO.DovizId;

                                ParaVeDovizId toplamKKDV_TO = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.KKDV_TO, taraf.KKDV_TO_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.KKDV_TO, foyTaraf.KKDV_TO_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.KKDV_TO = toplamKKDV_TO.Para;
                                foyTaraf.KKDV_TO_DOVIZ_ID = toplamKKDV_TO.DovizId;

                                ParaVeDovizId toplamOIV_TO = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.OIV_TO, taraf.OIV_TO_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.OIV_TO, foyTaraf.OIV_TO_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.OIV_TO = toplamOIV_TO.Para;
                                foyTaraf.OIV_TO_DOVIZ_ID = toplamOIV_TO.DovizId;

                                ParaVeDovizId toplamKDV_TO = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.KDV_TO, taraf.KDV_TO_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.KDV_TO, foyTaraf.KDV_TO_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.KDV_TO = toplamKDV_TO.Para;
                                foyTaraf.KDV_TO_DOVIZ_ID = toplamKDV_TO.DovizId;

                                ParaVeDovizId toplamKARSILIKSIZ_CEK_TAZMINATI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.KARSILIKSIZ_CEK_TAZMINATI, taraf.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.KARSILIKSIZ_CEK_TAZMINATI, foyTaraf.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.KARSILIKSIZ_CEK_TAZMINATI = toplamKARSILIKSIZ_CEK_TAZMINATI.Para;
                                foyTaraf.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = toplamKARSILIKSIZ_CEK_TAZMINATI.DovizId;

                                ParaVeDovizId toplamCEK_KOMISYONU = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.CEK_KOMISYONU, taraf.CEK_KOMISYONU_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.CEK_KOMISYONU, foyTaraf.CEK_KOMISYONU_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.CEK_KOMISYONU = toplamCEK_KOMISYONU.Para;
                                foyTaraf.CEK_KOMISYONU_DOVIZ_ID = toplamCEK_KOMISYONU.DovizId;

                                ParaVeDovizId toplamILAM_YARGILAMA_GIDERI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.ILAM_YARGILAMA_GIDERI, taraf.ILAM_YARGILAMA_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.ILAM_YARGILAMA_GIDERI, foyTaraf.ILAM_YARGILAMA_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.ILAM_YARGILAMA_GIDERI = toplamILAM_YARGILAMA_GIDERI.Para;
                                foyTaraf.ILAM_YARGILAMA_GIDERI_DOVIZ_ID = toplamILAM_YARGILAMA_GIDERI.DovizId;

                                ParaVeDovizId toplamILAM_BK_YARG_ONAMA = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.ILAM_BK_YARG_ONAMA, taraf.ILAM_BK_YARG_ONAMA_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.ILAM_BK_YARG_ONAMA, foyTaraf.ILAM_BK_YARG_ONAMA_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.ILAM_BK_YARG_ONAMA = toplamILAM_BK_YARG_ONAMA.Para;
                                foyTaraf.ILAM_BK_YARG_ONAMA_DOVIZ_ID = toplamILAM_BK_YARG_ONAMA.DovizId;

                                ParaVeDovizId toplamILAM_TEBLIG_GIDERI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.ILAM_TEBLIG_GIDERI, taraf.ILAM_TEBLIG_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.ILAM_TEBLIG_GIDERI, foyTaraf.ILAM_TEBLIG_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.ILAM_TEBLIG_GIDERI = toplamILAM_TEBLIG_GIDERI.Para;
                                foyTaraf.ILAM_TEBLIG_GIDERI_DOVIZ_ID = toplamILAM_TEBLIG_GIDERI.DovizId;

                                ParaVeDovizId toplamILAM_INKAR_TAZMINATI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.ILAM_INKAR_TAZMINATI, taraf.ILAM_INKAR_TAZMINATI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.ILAM_INKAR_TAZMINATI, foyTaraf.ILAM_INKAR_TAZMINATI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.ILAM_INKAR_TAZMINATI = toplamILAM_INKAR_TAZMINATI.Para;
                                foyTaraf.ILAM_INKAR_TAZMINATI_DOVIZ_ID = toplamILAM_INKAR_TAZMINATI.DovizId;

                                ParaVeDovizId toplamILAM_VEK_UCR = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.ILAM_VEK_UCR, taraf.ILAM_VEK_UCR_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.ILAM_VEK_UCR, foyTaraf.ILAM_VEK_UCR_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.ILAM_VEK_UCR = toplamILAM_VEK_UCR.Para;
                                foyTaraf.ILAM_VEK_UCR_DOVIZ_ID = toplamILAM_VEK_UCR.DovizId;

                                ParaVeDovizId toplamOZEL_TAZMINAT = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.OZEL_TAZMINAT, taraf.OZEL_TAZMINAT_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.OZEL_TAZMINAT, foyTaraf.OZEL_TAZMINAT_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.OZEL_TAZMINAT = toplamOZEL_TAZMINAT.Para;
                                foyTaraf.OZEL_TAZMINAT_DOVIZ_ID = toplamOZEL_TAZMINAT.DovizId;

                                ParaVeDovizId toplamOZEL_TUTAR1 = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.OZEL_TUTAR1, taraf.OZEL_TUTAR1_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.OZEL_TUTAR1, foyTaraf.OZEL_TUTAR1_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.OZEL_TUTAR1 = toplamOZEL_TUTAR1.Para;
                                foyTaraf.OZEL_TUTAR1_DOVIZ_ID = toplamOZEL_TUTAR1.DovizId;

                                ParaVeDovizId toplamOZEL_TUTAR2 = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.OZEL_TUTAR2, taraf.OZEL_TUTAR2_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.OZEL_TUTAR2, foyTaraf.OZEL_TUTAR2_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.OZEL_TUTAR2 = toplamOZEL_TUTAR2.Para;
                                foyTaraf.OZEL_TUTAR2_DOVIZ_ID = toplamOZEL_TUTAR2.DovizId;

                                ParaVeDovizId toplamOZEL_TUTAR3 = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.OZEL_TUTAR3, taraf.OZEL_TUTAR3_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.OZEL_TUTAR3, foyTaraf.OZEL_TUTAR3_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.OZEL_TUTAR3 = toplamOZEL_TUTAR3.Para;
                                foyTaraf.OZEL_TUTAR3_DOVIZ_ID = toplamOZEL_TUTAR3.DovizId;

                                ParaVeDovizId toplamTAKIP_CIKISI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.TAKIP_CIKISI, taraf.TAKIP_CIKISI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.TAKIP_CIKISI, foyTaraf.TAKIP_CIKISI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.TAKIP_CIKISI = toplamTAKIP_CIKISI.Para;
                                foyTaraf.TAKIP_CIKISI_DOVIZ_ID = toplamTAKIP_CIKISI.DovizId;

                                ParaVeDovizId toplamSONRAKI_FAIZ = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.SONRAKI_FAIZ, taraf.SONRAKI_FAIZ_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.SONRAKI_FAIZ, foyTaraf.SONRAKI_FAIZ_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.SONRAKI_FAIZ = toplamSONRAKI_FAIZ.Para;
                                foyTaraf.SONRAKI_FAIZ_DOVIZ_ID = toplamSONRAKI_FAIZ.DovizId;

                                foyTaraf.SONRAKI_FAIZ = (foyTaraf.SONRAKI_FAIZ < 0) ? 0 : foyTaraf.SONRAKI_FAIZ;

                                ParaVeDovizId toplamSONRAKI_TAZMINAT = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.SONRAKI_TAZMINAT, taraf.SONRAKI_TAZMINAT_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.SONRAKI_TAZMINAT, foyTaraf.SONRAKI_TAZMINAT_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.SONRAKI_TAZMINAT = toplamSONRAKI_TAZMINAT.Para;
                                foyTaraf.SONRAKI_TAZMINAT_DOVIZ_ID = toplamSONRAKI_TAZMINAT.DovizId;

                                ParaVeDovizId toplamBSMV_TS = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.BSMV_TS, taraf.BSMV_TS_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.BSMV_TS, foyTaraf.BSMV_TS_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.BSMV_TS = toplamBSMV_TS.Para;
                                foyTaraf.BSMV_TS_DOVIZ_ID = toplamBSMV_TS.DovizId;

                                ParaVeDovizId toplamOIV_TS = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.OIV_TS, taraf.OIV_TS_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.OIV_TS, foyTaraf.OIV_TS_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.OIV_TS = toplamOIV_TS.Para;
                                foyTaraf.OIV_TS_DOVIZ_ID = toplamOIV_TS.DovizId;

                                ParaVeDovizId toplamKDV_TS = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.KDV_TS, taraf.KDV_TS_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.KDV_TS, foyTaraf.KDV_TS_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.KDV_TS = toplamKDV_TS.Para;
                                foyTaraf.KDV_TS_DOVIZ_ID = toplamKDV_TS.DovizId;

                                ParaVeDovizId toplamPESIN_HARC = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.PESIN_HARC, taraf.PESIN_HARC_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.PESIN_HARC, foyTaraf.PESIN_HARC_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.PESIN_HARC = toplamPESIN_HARC.Para;
                                foyTaraf.PESIN_HARC_DOVIZ_ID = toplamPESIN_HARC.DovizId;

                                ParaVeDovizId toplamODENEN_TAHSIL_HARCI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.ODENEN_TAHSIL_HARCI, taraf.ODENEN_TAHSIL_HARCI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.ODENEN_TAHSIL_HARCI, foyTaraf.ODENEN_TAHSIL_HARCI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.ODENEN_TAHSIL_HARCI = toplamODENEN_TAHSIL_HARCI.Para;
                                foyTaraf.ODENEN_TAHSIL_HARCI_DOVIZ_ID = toplamODENEN_TAHSIL_HARCI.DovizId;

                                ParaVeDovizId toplamKALAN_TAHSIL_HARCI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.KALAN_TAHSIL_HARCI, taraf.KALAN_TAHSIL_HARCI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.KALAN_TAHSIL_HARCI, foyTaraf.KALAN_TAHSIL_HARCI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.KALAN_TAHSIL_HARCI = toplamKALAN_TAHSIL_HARCI.Para;
                                foyTaraf.KALAN_TAHSIL_HARCI_DOVIZ_ID = toplamKALAN_TAHSIL_HARCI.DovizId;

                                ParaVeDovizId toplamMASAYA_KATILMA_HARCI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.MASAYA_KATILMA_HARCI, taraf.MASAYA_KATILMA_HARCI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.MASAYA_KATILMA_HARCI, foyTaraf.MASAYA_KATILMA_HARCI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.MASAYA_KATILMA_HARCI = toplamMASAYA_KATILMA_HARCI.Para;
                                foyTaraf.MASAYA_KATILMA_HARCI_DOVIZ_ID = toplamMASAYA_KATILMA_HARCI.DovizId;

                                ParaVeDovizId toplamPAYLASMA_HARCI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.PAYLASMA_HARCI, taraf.PAYLASMA_HARCI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.PAYLASMA_HARCI, foyTaraf.PAYLASMA_HARCI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.PAYLASMA_HARCI = toplamPAYLASMA_HARCI.Para;
                                foyTaraf.PAYLASMA_HARCI_DOVIZ_ID = toplamPAYLASMA_HARCI.DovizId;

                                ParaVeDovizId toplamDAVA_GIDERLERI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.DAVA_GIDERLERI, taraf.DAVA_GIDERLERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.DAVA_GIDERLERI, foyTaraf.DAVA_GIDERLERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.DAVA_GIDERLERI = toplamDAVA_GIDERLERI.Para;
                                foyTaraf.DAVA_GIDERLERI_DOVIZ_ID = toplamDAVA_GIDERLERI.DovizId;

                                ParaVeDovizId toplamDIGER_GIDERLER = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.DIGER_GIDERLER, taraf.DIGER_GIDERLER_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.DIGER_GIDERLER, foyTaraf.DIGER_GIDERLER_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.DIGER_GIDERLER = toplamDIGER_GIDERLER.Para;
                                foyTaraf.DIGER_GIDERLER_DOVIZ_ID = toplamDIGER_GIDERLER.DovizId;

                                ParaVeDovizId toplamDAVA_INKAR_TAZMINATI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.DAVA_INKAR_TAZMINATI, taraf.DAVA_INKAR_TAZMINATI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.DAVA_INKAR_TAZMINATI, foyTaraf.DAVA_INKAR_TAZMINATI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.DAVA_INKAR_TAZMINATI = toplamDAVA_INKAR_TAZMINATI.Para;
                                foyTaraf.DAVA_INKAR_TAZMINATI_DOVIZ_ID = toplamDAVA_INKAR_TAZMINATI.DovizId;

                                ParaVeDovizId toplamODEME_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.ODEME_TOPLAMI, taraf.ODEME_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.ODEME_TOPLAMI, foyTaraf.ODEME_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.ODEME_TOPLAMI = toplamODEME_TOPLAMI.Para;
                                foyTaraf.ODEME_TOPLAMI_DOVIZ_ID = toplamODEME_TOPLAMI.DovizId;

                                ParaVeDovizId toplamTO_ODEME_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.TO_ODEME_TOPLAMI, taraf.TO_ODEME_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.TO_ODEME_TOPLAMI, foyTaraf.TO_ODEME_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.TO_ODEME_TOPLAMI = toplamTO_ODEME_TOPLAMI.Para;
                                foyTaraf.TO_ODEME_TOPLAMI_DOVIZ_ID = toplamTO_ODEME_TOPLAMI.DovizId;

                                ParaVeDovizId toplamMAHSUP_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.MAHSUP_TOPLAMI, taraf.MAHSUP_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.MAHSUP_TOPLAMI, foyTaraf.MAHSUP_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.MAHSUP_TOPLAMI = toplamMAHSUP_TOPLAMI.Para;
                                foyTaraf.MAHSUP_TOPLAMI_DOVIZ_ID = toplamMAHSUP_TOPLAMI.DovizId;

                                ParaVeDovizId toplamFERAGAT_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.FERAGAT_TOPLAMI, taraf.FERAGAT_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.FERAGAT_TOPLAMI, foyTaraf.FERAGAT_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.FERAGAT_TOPLAMI = toplamFERAGAT_TOPLAMI.Para;
                                foyTaraf.FERAGAT_TOPLAMI_DOVIZ_ID = toplamFERAGAT_TOPLAMI.DovizId;

                                ParaVeDovizId toplamALACAK_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.ALACAK_TOPLAMI, taraf.ALACAK_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.ALACAK_TOPLAMI, foyTaraf.ALACAK_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.ALACAK_TOPLAMI = toplamALACAK_TOPLAMI.Para;
                                foyTaraf.ALACAK_TOPLAMI_DOVIZ_ID = toplamALACAK_TOPLAMI.DovizId;

                                ParaVeDovizId toplamKALAN = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.KALAN, taraf.KALAN_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.KALAN, foyTaraf.KALAN_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.KALAN = toplamKALAN.Para;
                                foyTaraf.KALAN_DOVIZ_ID = toplamKALAN.DovizId;

                                ParaVeDovizId toplamTAHLIYE_VEK_UCR = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.TAHLIYE_VEK_UCR, taraf.TAHLIYE_VEK_UCR_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.TAHLIYE_VEK_UCR, foyTaraf.TAHLIYE_VEK_UCR_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.TAHLIYE_VEK_UCR = toplamTAHLIYE_VEK_UCR.Para;
                                foyTaraf.TAHLIYE_VEK_UCR_DOVIZ_ID = toplamTAHLIYE_VEK_UCR.DovizId;

                                ParaVeDovizId toplamDIGER_HARC = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.DIGER_HARC, taraf.DIGER_HARC_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.DIGER_HARC, foyTaraf.DIGER_HARC_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.DIGER_HARC = toplamDIGER_HARC.Para;
                                foyTaraf.DIGER_HARC_DOVIZ_ID = toplamDIGER_HARC.DovizId;

                                ParaVeDovizId toplamTD_GIDERI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.TD_GIDERI, taraf.TD_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.TD_GIDERI, foyTaraf.TD_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.TD_GIDERI = toplamTD_GIDERI.Para;
                                foyTaraf.TD_GIDERI_DOVIZ_ID = toplamTD_GIDERI.DovizId;

                                ParaVeDovizId toplamTD_BAKIYE_HARC = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.TD_BAKIYE_HARC, taraf.TD_BAKIYE_HARC_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.TD_BAKIYE_HARC, foyTaraf.TD_BAKIYE_HARC_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.TD_BAKIYE_HARC = toplamTD_BAKIYE_HARC.Para;
                                foyTaraf.TD_BAKIYE_HARC_DOVIZ_ID = toplamTD_BAKIYE_HARC.DovizId;

                                ParaVeDovizId toplamTD_VEK_UCR = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.TD_VEK_UCR, taraf.TD_VEK_UCR_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.TD_VEK_UCR, foyTaraf.TD_VEK_UCR_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.TD_VEK_UCR = toplamTD_VEK_UCR.Para;
                                foyTaraf.TD_VEK_UCR_DOVIZ_ID = toplamTD_VEK_UCR.DovizId;

                                ParaVeDovizId toplamTD_TEBLIG_GIDERI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.TD_TEBLIG_GIDERI, taraf.TD_TEBLIG_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.TD_TEBLIG_GIDERI, foyTaraf.TD_TEBLIG_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.TD_TEBLIG_GIDERI = toplamTD_TEBLIG_GIDERI.Para;
                                foyTaraf.TD_TEBLIG_GIDERI_DOVIZ_ID = toplamTD_TEBLIG_GIDERI.DovizId;

                                ParaVeDovizId toplamBIRIKMIS_NAFAKA = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.BIRIKMIS_NAFAKA, taraf.BIRIKMIS_NAFAKA_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.BIRIKMIS_NAFAKA, foyTaraf.BIRIKMIS_NAFAKA_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.BIRIKMIS_NAFAKA = toplamBIRIKMIS_NAFAKA.Para;
                                foyTaraf.BIRIKMIS_NAFAKA_DOVIZ_ID = toplamBIRIKMIS_NAFAKA.DovizId;

                                ParaVeDovizId toplamICRA_INKAR_TAZMINATI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.ICRA_INKAR_TAZMINATI, taraf.ICRA_INKAR_TAZMINATI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.ICRA_INKAR_TAZMINATI, foyTaraf.ICRA_INKAR_TAZMINATI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.ICRA_INKAR_TAZMINATI = toplamICRA_INKAR_TAZMINATI.Para;
                                foyTaraf.ICRA_INKAR_TAZMINATI_DOVIZ_ID = toplamICRA_INKAR_TAZMINATI.DovizId;

                                ParaVeDovizId toplamDAMGA_PULU = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.DAMGA_PULU, taraf.DAMGA_PULU_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.DAMGA_PULU, foyTaraf.DAMGA_PULU_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.DAMGA_PULU = toplamDAMGA_PULU.Para;
                                foyTaraf.DAMGA_PULU_DOVIZ_ID = toplamDAMGA_PULU.DovizId;

                                ParaVeDovizId toplamPROTOKOL_MIKTARI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.PROTOKOL_MIKTARI, taraf.PROTOKOL_MIKTARI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.PROTOKOL_MIKTARI, foyTaraf.PROTOKOL_MIKTARI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.PROTOKOL_MIKTARI = toplamPROTOKOL_MIKTARI.Para;
                                foyTaraf.PROTOKOL_MIKTARI_DOVIZ_ID = toplamPROTOKOL_MIKTARI.DovizId;

                                ParaVeDovizId toplamKARSILIK_TUTARI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.KARSILIK_TUTARI, taraf.KARSILIK_TUTARI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.KARSILIK_TUTARI, foyTaraf.KARSILIK_TUTARI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.KARSILIK_TUTARI = toplamKARSILIK_TUTARI.Para;
                                foyTaraf.KARSILIK_TUTARI_DOVIZ_ID = toplamKARSILIK_TUTARI.DovizId;

                                ParaVeDovizId toplamHESAPLANMIS_KKDF = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.HESAPLANMIS_KKDF, taraf.HESAPLANMIS_KKDF_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.HESAPLANMIS_KKDF, foyTaraf.HESAPLANMIS_KKDF_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.HESAPLANMIS_KKDF = toplamHESAPLANMIS_KKDF.Para;
                                foyTaraf.HESAPLANMIS_KKDF_DOVIZ_ID = toplamHESAPLANMIS_KKDF.DovizId;

                                ParaVeDovizId toplamHESAPLANMIS_BSMV = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.HESAPLANMIS_BSMV, taraf.HESAPLANMIS_BSMV_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.HESAPLANMIS_BSMV, foyTaraf.HESAPLANMIS_BSMV_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.HESAPLANMIS_BSMV = toplamHESAPLANMIS_BSMV.Para;
                                foyTaraf.HESAPLANMIS_BSMV_DOVIZ_ID = toplamHESAPLANMIS_BSMV.DovizId;

                                ParaVeDovizId toplamHESAPLANMIS_KDV = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.HESAPLANMIS_KDV, taraf.HESAPLANMIS_KDV_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.HESAPLANMIS_KDV, foyTaraf.HESAPLANMIS_KDV_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.HESAPLANMIS_KDV = toplamHESAPLANMIS_KDV.Para;
                                foyTaraf.HESAPLANMIS_KDV_DOVIZ_ID = toplamHESAPLANMIS_KDV.DovizId;

                                ParaVeDovizId toplamHESAPLANMIS_OIV = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.HESAPLANMIS_OIV, taraf.HESAPLANMIS_OIV_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.HESAPLANMIS_OIV, foyTaraf.HESAPLANMIS_OIV_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.HESAPLANMIS_OIV = toplamHESAPLANMIS_OIV.Para;
                                foyTaraf.HESAPLANMIS_OIV_DOVIZ_ID = toplamHESAPLANMIS_OIV.DovizId;

                                ParaVeDovizId toplamTO_MASRAF_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.TO_MASRAF_TOPLAMI, taraf.TO_MASRAF_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.TO_MASRAF_TOPLAMI, foyTaraf.TO_MASRAF_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.TO_MASRAF_TOPLAMI = toplamTO_MASRAF_TOPLAMI.Para;
                                foyTaraf.TO_MASRAF_TOPLAMI_DOVIZ_ID = toplamTO_MASRAF_TOPLAMI.DovizId;

                                ParaVeDovizId toplamTS_MASRAF_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.TS_MASRAF_TOPLAMI, taraf.TS_MASRAF_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.TS_MASRAF_TOPLAMI, foyTaraf.TS_MASRAF_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.TS_MASRAF_TOPLAMI = toplamTS_MASRAF_TOPLAMI.Para;
                                foyTaraf.TS_MASRAF_TOPLAMI_DOVIZ_ID = toplamTS_MASRAF_TOPLAMI.DovizId;

                                ParaVeDovizId toplamTUM_MASRAF_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.TUM_MASRAF_TOPLAMI, taraf.TUM_MASRAF_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.TUM_MASRAF_TOPLAMI, foyTaraf.TUM_MASRAF_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.TUM_MASRAF_TOPLAMI = toplamTUM_MASRAF_TOPLAMI.Para;
                                foyTaraf.TUM_MASRAF_TOPLAMI_DOVIZ_ID = toplamTUM_MASRAF_TOPLAMI.DovizId;

                                ParaVeDovizId toplamHARC_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.HARC_TOPLAMI, taraf.HARC_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.HARC_TOPLAMI, foyTaraf.HARC_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.HARC_TOPLAMI = toplamHARC_TOPLAMI.Para;
                                foyTaraf.HARC_TOPLAMI_DOVIZ_ID = toplamHARC_TOPLAMI.DovizId;

                                ParaVeDovizId toplamTS_VEKALET_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.TS_VEKALET_TOPLAMI, taraf.TS_VEKALET_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.TS_VEKALET_TOPLAMI, foyTaraf.TS_VEKALET_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.TS_VEKALET_TOPLAMI = toplamTS_VEKALET_TOPLAMI.Para;
                                foyTaraf.TS_VEKALET_TOPLAMI_DOVIZ_ID = toplamTS_VEKALET_TOPLAMI.DovizId;

                                ParaVeDovizId toplamTUM_VEKALET_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.TUM_VEKALET_TOPLAMI, taraf.TUM_VEKALET_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.TUM_VEKALET_TOPLAMI, foyTaraf.TUM_VEKALET_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.TUM_VEKALET_TOPLAMI = toplamTUM_VEKALET_TOPLAMI.Para;
                                foyTaraf.TUM_VEKALET_TOPLAMI_DOVIZ_ID = toplamTUM_VEKALET_TOPLAMI.DovizId;

                                ParaVeDovizId toplamKARSI_VEKALET_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.KARSI_VEKALET_TOPLAMI, taraf.KARSI_VEKALET_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.KARSI_VEKALET_TOPLAMI, foyTaraf.KARSI_VEKALET_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.KARSI_VEKALET_TOPLAMI = toplamKARSI_VEKALET_TOPLAMI.Para;
                                foyTaraf.KARSI_VEKALET_TOPLAMI_DOVIZ_ID = toplamKARSI_VEKALET_TOPLAMI.DovizId;

                                ParaVeDovizId toplamFAIZ_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.FAIZ_TOPLAMI, taraf.FAIZ_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.FAIZ_TOPLAMI, foyTaraf.FAIZ_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.FAIZ_TOPLAMI = toplamFAIZ_TOPLAMI.Para;
                                foyTaraf.FAIZ_TOPLAMI_DOVIZ_ID = toplamFAIZ_TOPLAMI.DovizId;

                                ParaVeDovizId toplamILAM_UCRETLER_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.ILAM_UCRETLER_TOPLAMI, taraf.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.ILAM_UCRETLER_TOPLAMI, foyTaraf.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.ILAM_UCRETLER_TOPLAMI = toplamILAM_UCRETLER_TOPLAMI.Para;
                                foyTaraf.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID = toplamILAM_UCRETLER_TOPLAMI.DovizId;

                                ParaVeDovizId toplamIT_VEKALET_UCRETI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.IT_VEKALET_UCRETI, taraf.IT_VEKALET_UCRETI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.IT_VEKALET_UCRETI, foyTaraf.IT_VEKALET_UCRETI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.IT_VEKALET_UCRETI = toplamIT_VEKALET_UCRETI.Para;
                                foyTaraf.IT_VEKALET_UCRETI_DOVIZ_ID = toplamIT_VEKALET_UCRETI.DovizId;

                                ParaVeDovizId toplamIT_GIDERI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.IT_GIDERI, taraf.IT_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.IT_GIDERI, foyTaraf.IT_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.IT_GIDERI = toplamIT_GIDERI.Para;
                                foyTaraf.IT_GIDERI_DOVIZ_ID = toplamIT_GIDERI.DovizId;

                                ParaVeDovizId toplamIH_VEKALET_UCRETI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.IH_VEKALET_UCRETI, taraf.IH_VEKALET_UCRETI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.IH_VEKALET_UCRETI, foyTaraf.IH_VEKALET_UCRETI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.IH_VEKALET_UCRETI = toplamIH_VEKALET_UCRETI.Para;
                                foyTaraf.IH_VEKALET_UCRETI_DOVIZ_ID = toplamIH_VEKALET_UCRETI.DovizId;

                                ParaVeDovizId toplamIH_GIDERI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.IH_GIDERI, taraf.IH_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.IH_GIDERI, foyTaraf.IH_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.IH_GIDERI = toplamIH_GIDERI.Para;
                                foyTaraf.IH_GIDERI_DOVIZ_ID = toplamIH_GIDERI.DovizId;

                                ParaVeDovizId toplamIT_HACIZDE_ODENEN = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.IT_HACIZDE_ODENEN, taraf.IT_HACIZDE_ODENEN_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                      new ParaVeDovizId(foyTaraf.IT_HACIZDE_ODENEN, foyTaraf.IT_HACIZDE_ODENEN_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.IT_HACIZDE_ODENEN = toplamIT_HACIZDE_ODENEN.Para;
                                foyTaraf.IT_HACIZDE_ODENEN_DOVIZ_ID = toplamIT_HACIZDE_ODENEN.DovizId;

                                //ParaVeDovizId toplamTAKIP_VEKALET_UCRETI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.TAKIP_VEKALET_UCRETI, taraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                //                                                       new ParaVeDovizId(foyTaraf.TAKIP_VEKALET_UCRETI, foyTaraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                //foyTaraf.TAKIP_VEKALET_UCRETI = toplamTAKIP_VEKALET_UCRETI.Para;
                                //foyTaraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID = toplamTAKIP_VEKALET_UCRETI.DovizId;

                                ParaVeDovizId toplamILK_GIDERLER = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.ILK_GIDERLER, taraf.ILK_GIDERLER_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                                                                       new ParaVeDovizId(foyTaraf.ILK_GIDERLER, foyTaraf.ILK_GIDERLER_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                foyTaraf.ILK_GIDERLER = toplamILK_GIDERLER.Para;
                                foyTaraf.ILK_GIDERLER_DOVIZ_ID = toplamILK_GIDERLER.DovizId;

                                //ParaVeDovizId toplamDAVA_VEKALET_UCRETI = ParaVeDovizId.Topla(new ParaVeDovizId(taraf.DAVA_VEKALET_UCRETI , taraf.DAVA_VEKALET_UCRETI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value),
                                //                                                       new ParaVeDovizId(foyTaraf.DAVA_VEKALET_UCRETI, foyTaraf.DAVA_VEKALET_UCRETI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value));
                                //foyTaraf.DAVA_VEKALET_UCRETI = toplamDAVA_VEKALET_UCRETI.Para;
                                //foyTaraf.DAVA_VEKALET_UCRETI_DOVIZ_ID = toplamDAVA_VEKALET_UCRETI.DovizId;

                                int bocluTarafSayisi = HesapAraclari.Icra.BorcluTarafSayisi(mFoy.ID);
                                if (bocluTarafSayisi < 1) bocluTarafSayisi = 1;

                                #region Takip Vekalet Ücreti

                                var tarafaDusenTakipVekalet = mFoy.TAKIP_VEKALET_UCRETI * (decimal)foyTaraf.SORUMLULUK_ORANI;

                                foyTaraf.TAKIP_VEKALET_UCRETI = tarafaDusenTakipVekalet;
                                foyTaraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID = mFoy.TAKIP_VEKALET_UCRETI_DOVIZ_ID ?? 1;

                                #endregion Takip Vekalet Ücreti

                                #region Dava Vekalet Ücreti

                                var tarafaDusenDavaVekalet = mFoy.DAVA_VEKALET_UCRETI * (decimal)foyTaraf.SORUMLULUK_ORANI;

                                foyTaraf.DAVA_VEKALET_UCRETI = tarafaDusenDavaVekalet;
                                foyTaraf.DAVA_VEKALET_UCRETI_DOVIZ_ID = mFoy.DAVA_VEKALET_UCRETI_DOVIZ_ID ?? 1;

                                #endregion Dava Vekalet Ücreti

                                #region Kalan Tahsil Harcý

                                var tarafaKalanTahsilHarci = mFoy.KALAN_TAHSIL_HARCI * (decimal)foyTaraf.SORUMLULUK_ORANI;

                                foyTaraf.KALAN_TAHSIL_HARCI = tarafaKalanTahsilHarci;
                                foyTaraf.KALAN_TAHSIL_HARCI_DOVIZ_ID = mFoy.KALAN_TAHSIL_HARCI_DOVIZ_ID ?? 1;

                                #endregion Kalan Tahsil Harcý

                                #region Feragat

                                var tarafaFeragatTahsilHarci = mFoy.FERAGAT_TOPLAMI * (decimal)foyTaraf.SORUMLULUK_ORANI;

                                foyTaraf.FERAGAT_TOPLAMI = tarafaFeragatTahsilHarci;
                                foyTaraf.FERAGAT_TOPLAMI_DOVIZ_ID = mFoy.FERAGAT_TOPLAMI_DOVIZ_ID ?? 1;

                                #endregion Feragat

                                #region Takip Öncesi Ödemeler

                                var toOdemeleri = HesaplaTarafOdemeToplamiTO(mFoy, foyTaraf.CARI_ID.Value);

                                foyTaraf.TO_ODEME_TOPLAMI = 0 - toOdemeleri.Para;
                                foyTaraf.TO_ODEME_TOPLAMI_DOVIZ_ID = toOdemeleri.DovizId;

                                #endregion Takip Öncesi Ödemeler

                                #region Takip Öncesi Ödemeler

                                var Odemeleri = HesaplaTarafOdemeToplamiTS(mFoy, foyTaraf.CARI_ID.Value);

                                foyTaraf.ODEME_TOPLAMI = 0 - Odemeleri.Para;
                                foyTaraf.ODEME_TOPLAMI_DOVIZ_ID = Odemeleri.DovizId;

                                #endregion Takip Öncesi Ödemeler

                                #region Diðer Giderler

                                var digerler = mFoy.DIGER_GIDERLER * (decimal)foyTaraf.SORUMLULUK_ORANI;

                                ParaVeDovizId digerGiderlerTOplami = ParaVeDovizId.Topla(new ParaVeDovizId(digerler, mFoy.DIGER_GIDERLER_DOVIZ_ID, mFoy.SON_HESAP_TARIHI),
                                                                        new ParaVeDovizId(foyTaraf.DIGER_GIDERLER, foyTaraf.DIGER_GIDERLER_DOVIZ_ID, mFoy.SON_HESAP_TARIHI));

                                foyTaraf.DIGER_GIDERLER = digerGiderlerTOplami.Para;
                                foyTaraf.DIGER_GIDERLER_DOVIZ_ID = digerGiderlerTOplami.DovizId;

                                #endregion Diðer Giderler
                            }
                        }
                    }
                }
            }
        }

        public static void HesaplaIhtiyatiTedbirHaciz(AV001_TI_BIL_FOY mFoy)
        {
            AV001_TDI_BIL_MASRAF_AVANS mHacizVekalet = new AV001_TDI_BIL_MASRAF_AVANS();
            mHacizVekalet.MASRAF_AVANS_TIP = 1; //Masraf
            AV001_TDI_BIL_MASRAF_AVANS mHacizGider = new AV001_TDI_BIL_MASRAF_AVANS();
            mHacizGider.MASRAF_AVANS_TIP = 1; //Masraf
            AV001_TDI_BIL_MASRAF_AVANS mTedbirVekalet = new AV001_TDI_BIL_MASRAF_AVANS();
            mTedbirVekalet.MASRAF_AVANS_TIP = 1; //Masraf
            AV001_TDI_BIL_MASRAF_AVANS mTedbirGider = new AV001_TDI_BIL_MASRAF_AVANS();
            mTedbirGider.MASRAF_AVANS_TIP = 1; //Masraf

            #region Ihtiyati Haciz MASRAF_AVANS DETAY

            foreach (AV001_TI_BIL_IHTIYATI_HACIZ haciz in mFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection)
            {
                //BUG: AVPNG-81 ile ilgili olarak eklenmiþtir (2satýr)[YY]
                if (!haciz.KARAR_TARIHI.HasValue)
                    return;

                #region VekaletTutar
                
                ParaVeDovizId vekBirimTutar = FaizHelper.VekaletTutariGetir(
                    haciz.KARAR_TARIHI.Value, 216);

                AV001_TDI_BIL_MASRAF_AVANS_DETAY vekMasrafAvans =
                    FaizHelper.IcraMasrafAvansGetir(vekBirimTutar.YtlCevir(mFoy.TAKIP_TARIHI.Value), 291, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID);
                mHacizVekalet.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(vekMasrafAvans);
                AV001_TI_BIL_VEKALET_UCRET vekUc = FaizHelper.VekaletUcretiGetir(new ParaVeDovizId(0, 1), haciz.KARAR_TARIHI.Value,
                  VekaletUcretKalemi.MaktuIhtiyatiHacizVekUcr, vekBirimTutar, 0,
                  VekaketUcretTipNo.Maktu, mFoy.SON_HESAP_TARIHI);
                //vekUc.HESAPLAMA_TARIHI = DateTime.Now;
                mFoy.AV001_TI_BIL_VEKALET_UCRETCollection.Add(vekUc);

                #endregion VekaletTutar

                #region VekaletHarc

                ParaVeDovizId vekHarcTutar =
                    FaizHelper.IcraHarcTutarGetir(haciz.KARAR_TARIHI.Value,
                                                  (int)MuhasebeAltKategoriId.VEKALET_HARCI);

                AV001_TDI_BIL_MASRAF_AVANS_DETAY vekHMasrafAvans =
                    FaizHelper.IcraMasrafAvansGetir(vekHarcTutar.YtlCevir(mFoy.TAKIP_TARIHI.Value),
                                                    (int)MuhasebeAltKategoriId.VEKALET_HARCI, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID);

                mHacizGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(vekHMasrafAvans);

                FaizHelper.IcraHarcKalemiEkleGetir(mFoy, MuhasebeAltKategoriId.VEKALET_HARCI,
                       vekHarcTutar.Para, haciz.KARAR_TARIHI.Value);

                #endregion VekaletHarc

                #region VekaletPulu

                //                ParaVeDovizId vekPulTutar =
                //                    FaizHelper.IcraHarcTutarGetir(haciz.KARAR_TARIHI.Value,
                //                                                  (int)MuhasebeAltKategoriId.VEKALET_PULU);
                //                mHacizGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                //                    FaizHelper.IcraMasrafAvansGetir(vekPulTutar.YtlCevir(mFoy.TAKIP_TARIHI.Value),
                //                                                    (int)MuhasebeAltKategoriId.VEKALET_PULU, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));
                //                FaizHelper.IcraHarcKalemiEkleGetir(mFoy, MuhasebeAltKategoriId.VEKALET_PULU,
                //vekPulTutar.Para, haciz.KARAR_TARIHI.Value);

                #endregion VekaletPulu

                #region BasvurmaHarci

                if (haciz.ADLI_BIRIM_GOREV_ID == null)
                {
                    System.Windows.Forms.MessageBox.Show(mFoy.FOY_NO + " numaralý dosyanýn ihtiyati haciz kaydý için Adli Birim Görev girilmemiþtir. Lütfen güncelleyiniz.");
                    return;
                }

                ParaVeDovizId basvurmaHarci =
                    FaizHelper.IhtiyatiBasvurmaHarciGetir(haciz.KARAR_TARIHI.Value,
                                                          DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.
                                                              GetByID(haciz.ADLI_BIRIM_GOREV_ID.Value).GOREV);

                mHacizGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                    FaizHelper.IcraMasrafAvansGetir(basvurmaHarci.Para, basvurmaHarci.DovizId, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));
                FaizHelper.IcraHarcKalemiEkleGetir(mFoy, (MuhasebeAltKategoriId)basvurmaHarci.DovizId,
basvurmaHarci.Para, haciz.KARAR_TARIHI.Value);
                // doviz ID de altkategoriId tutuyoruz

                #endregion BasvurmaHarci

                #region KararVeIlamHArci

                //aykut ihtiyati haciz ve tedbir peþin harçýnýn hesabý deðiþti
                //ParaVeDovizId kararIlamHarci = FaizHelper.IhtiyatiKararVeIlamHarciGetir(haciz.KARAR_TARIHI.Value, DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.GetByID(haciz.ADLI_BIRIM_GOREV_ID.Value).GOREV);

                ParaVeDovizId kararIlamHarci = FaizHelper.IhtiyatiKararVeIlamHarciGetir(haciz.KARAR_TARIHI.Value, "ÝHTÝYATÝ TEDBÝR MAKTU");

                mHacizGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                    FaizHelper.IcraMasrafAvansGetir(kararIlamHarci.Para, kararIlamHarci.DovizId, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));
                FaizHelper.IcraHarcKalemiEkleGetir(mFoy, (MuhasebeAltKategoriId)kararIlamHarci.DovizId,
kararIlamHarci.Para, haciz.KARAR_TARIHI.Value);

                #endregion KararVeIlamHArci
            }

            #endregion Ihtiyati Haciz MASRAF_AVANS DETAY

            #region Ihtiyati Tedbir MASRAF_AVANS DETAY

            foreach (AV001_TDI_BIL_IHTIYATI_TEDBIR tedbir in mFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection)
            {
                //BUG: AVPNG-81 ile ilgili olarak eklenmiþtir (2satýr)[YY]
                if (!tedbir.KARAR_TARIHI.HasValue)
                    return;

                #region VekaletTutar

                ParaVeDovizId vekBirimTutar = FaizHelper.VekaletTutariGetir(
                    tedbir.KARAR_TARIHI.Value, 216);
                AV001_TI_BIL_VEKALET_UCRET vekUc = FaizHelper.VekaletUcretiGetir(new ParaVeDovizId(0, 1), tedbir.KARAR_TARIHI.Value,
                                              VekaletUcretKalemi.MaktuIhtiyatiTedbirVekUcr, vekBirimTutar, 0,
                                              VekaketUcretTipNo.Maktu, mFoy.SON_HESAP_TARIHI);
                // vekUc.HESAPLAMA_TARIHI = DateTime.Now;
                mFoy.AV001_TI_BIL_VEKALET_UCRETCollection.Add(vekUc);
                AV001_TDI_BIL_MASRAF_AVANS_DETAY vekMasrafAvans =
                    FaizHelper.IcraMasrafAvansGetir(vekBirimTutar.YtlCevir(mFoy.TAKIP_TARIHI.Value), 291, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID);
                mTedbirVekalet.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(vekMasrafAvans);

                #endregion VekaletTutar

                #region VekaletHarc

                ParaVeDovizId vekHarcTutar =
                    FaizHelper.IcraHarcTutarGetir(tedbir.KARAR_TARIHI.Value,
                                                  (int)MuhasebeAltKategoriId.VEKALET_HARCI);
                FaizHelper.IcraHarcKalemiEkleGetir(mFoy, MuhasebeAltKategoriId.VEKALET_HARCI,
                                                   vekHarcTutar.Para, tedbir.KARAR_TARIHI.Value);
                AV001_TDI_BIL_MASRAF_AVANS_DETAY vekHMasrafAvans =
                    FaizHelper.IcraMasrafAvansGetir(vekHarcTutar.YtlCevir(mFoy.TAKIP_TARIHI.Value),
                                                    (int)MuhasebeAltKategoriId.VEKALET_HARCI, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID);

                mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(vekHMasrafAvans);

                #endregion VekaletHarc

                #region VekaletPulu

                //ParaVeDovizId vekPulTutar =
                //    FaizHelper.IcraHarcTutarGetir(tedbir.KARAR_TARIHI.Value,
                //                                  (int)MuhasebeAltKategoriId.VEKALET_PULU);
                //mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                //    FaizHelper.IcraMasrafAvansGetir(vekPulTutar.YtlCevir(mFoy.TAKIP_TARIHI.Value),
                //                                    (int)MuhasebeAltKategoriId.VEKALET_PULU, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));
                //FaizHelper.IcraHarcKalemiEkleGetir(mFoy, MuhasebeAltKategoriId.VEKALET_PULU,
                //       vekPulTutar.Para, tedbir.KARAR_TARIHI.Value);

                #endregion VekaletPulu

                #region BasvurmaHarci

                ParaVeDovizId basvurmaHarci =
                    FaizHelper.IhtiyatiBasvurmaHarciGetir(tedbir.KARAR_TARIHI.Value,
                                                          DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.
                                                              GetByID(tedbir.ADLI_BIRIM_GOREV_ID).
                                                              GOREV);
                mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                    FaizHelper.IcraMasrafAvansGetir(basvurmaHarci.Para, basvurmaHarci.DovizId, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));
                FaizHelper.IcraHarcKalemiEkleGetir(mFoy, (MuhasebeAltKategoriId)basvurmaHarci.DovizId,
                       basvurmaHarci.Para, tedbir.KARAR_TARIHI.Value);
                // doviz ID de altkategoriId tutuyoruz

                #endregion BasvurmaHarci

                #region KararVeIlamHArci

                ParaVeDovizId kararIlamHarci =
                    FaizHelper.IhtiyatiKararVeIlamHarciGetir(tedbir.KARAR_TARIHI.Value,
                                                             DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider
                                                                 .
                                                                 GetByID(tedbir.ADLI_BIRIM_GOREV_ID).
                                                                 GOREV);
                mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                    FaizHelper.IcraMasrafAvansGetir(kararIlamHarci.Para, kararIlamHarci.DovizId, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));
                // doviz ID de altkategoriId tutuyoruz
                FaizHelper.IcraHarcKalemiEkleGetir(mFoy, (MuhasebeAltKategoriId)kararIlamHarci.DovizId,
kararIlamHarci.Para, tedbir.KARAR_TARIHI.Value);

                #endregion KararVeIlamHArci
            }

            #endregion Ihtiyati Tedbir MASRAF_AVANS DETAY

            #region mFoy.IH_VEKALET_UCRETI

            if (mFoy.ID > 0)
            {
                mFoy.IH_VEKALET_UCRETI = 0;
                foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in mHacizVekalet.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                {
                    mFoy.IH_VEKALET_UCRETI += detay.TOPLAM_TUTAR;
                }
            }

            #endregion mFoy.IH_VEKALET_UCRETI

            #region mFoy.IH_GIDERI

            if (mFoy.ID > 0)
            {
                mFoy.IH_GIDERI = 0;
                foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in mHacizGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                {
                    mFoy.IH_GIDERI += detay.TOPLAM_TUTAR;
                }
            }

            #endregion mFoy.IH_GIDERI

            #region mFoy.IT_VEKALET_UCRETI

            mFoy.IT_VEKALET_UCRETI = 0;
            foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in mTedbirVekalet.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
            {
                mFoy.IT_VEKALET_UCRETI += detay.TOPLAM_TUTAR;
            }

            #endregion mFoy.IT_VEKALET_UCRETI

            #region mFoy.IT_GIDERI

            mFoy.IT_GIDERI = 0;
            foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
            {
                mFoy.IT_GIDERI += detay.TOPLAM_TUTAR;
            }

            #endregion mFoy.IT_GIDERI

            mFoy.IH_VEKALET_UCRETI_DOVIZ_ID = 1;
            mFoy.IT_VEKALET_UCRETI_DOVIZ_ID = 1;
            mFoy.IH_GIDERI_DOVIZ_ID = 1;
            mFoy.IT_GIDERI_DOVIZ_ID = 1;
            if (mHacizGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Count > 0)
                mFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.Add(mHacizGider);
            if (mHacizVekalet.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Count > 0)
                mFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.Add(mHacizVekalet);
            if (mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Count > 0)
                mFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.Add(mTedbirGider);
            if (mTedbirVekalet.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Count > 0)
                mFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.Add(mTedbirVekalet);
        }

        public static void HesaplaIhtiyatiTedbirHaciz(bool tarafIleBirlikte, AV001_TI_BIL_FOY mFoy, TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> listTumAlacakNedenTaraf)
        {
            #region Listeler

            TList<AV001_TDI_BIL_MASRAF_AVANS> mHacizVekalets = new TList<AV001_TDI_BIL_MASRAF_AVANS>();
            //mHacizVekalet.MASRAF_AVANS_TIP = 1; //Masraf
            TList<AV001_TDI_BIL_MASRAF_AVANS> mHacizGiders = new TList<AV001_TDI_BIL_MASRAF_AVANS>();
            //mHacizGider.MASRAF_AVANS_TIP = 1; //Masraf
            TList<AV001_TDI_BIL_MASRAF_AVANS> mTedbirVekalets = new TList<AV001_TDI_BIL_MASRAF_AVANS>();
            //mHacizGider.MASRAF_AVANS_TIP = 1; //Masraf
            TList<AV001_TDI_BIL_MASRAF_AVANS> mTedbirGiders = new TList<AV001_TDI_BIL_MASRAF_AVANS>();
            //mHacizGider.MASRAF_AVANS_TIP = 1; //Masraf

            #endregion Listeler

            #region Ihtiyati Haciz MASRAF_AVANS DETAY

            //aykut ihtiyati haciz
            int tarafSayisi = listTumAlacakNedenTaraf.Where(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI).Count();
            foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF item in listTumAlacakNedenTaraf.Where(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI))
            {
                foreach (AV001_TI_BIL_IHTIYATI_HACIZ haciz in mFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection)
                {
                    //TODO : Karar tarihi degeri Null oldugunda hata geliyordu has value kontrolu yapýldý .  Ersin 13 aralýk 2008 - 19:21
                    if (haciz.KARAR_TARIHI.HasValue && haciz.ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        #region Harç tutarlarý alýnýyor

                        ParaVeDovizId vekBirimTutar = FaizHelper.VekaletTutariGetir(haciz.KARAR_TARIHI.Value, 216);
                        ParaVeDovizId vekHarcTutar = FaizHelper.IcraHarcTutarGetir(haciz.KARAR_TARIHI.Value,
                                                                                   (int)
                                                                                   MuhasebeAltKategoriId.VEKALET_HARCI);
                        ParaVeDovizId vekPulTutar = FaizHelper.IcraHarcTutarGetir(haciz.KARAR_TARIHI.Value,
                                                                                  (int)
                                                                                  MuhasebeAltKategoriId.VEKALET_PULU);
                        ParaVeDovizId basvurmaHarci = FaizHelper.IhtiyatiBasvurmaHarciGetir(haciz.KARAR_TARIHI.Value,
                                                                                            DataRepository.
                                                                                                TDI_KOD_ADLI_BIRIM_GOREVProvider
                                                                                                .GetByID(
                                                                                                haciz.
                                                                                                    ADLI_BIRIM_GOREV_ID.Value
                                                                                                   ).GOREV);
                        ParaVeDovizId kararIlamHarci = FaizHelper.IhtiyatiKararVeIlamHarciGetir(
                            haciz.KARAR_TARIHI.Value,
                            DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.GetByID(haciz.ADLI_BIRIM_GOREV_ID.Value).
                                GOREV);

                        #endregion Harç tutarlarý alýnýyor

                        haciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection = DataRepository.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFProvider.GetByIHTIYATI_HACIZ_ID(haciz.ID);

                        foreach (AV001_TI_BIL_IHTIYATI_HACIZ_TARAF htrf in haciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection)
                        {
                            #region Taraflar

                            AV001_TDI_BIL_MASRAF_AVANS mHacizVekalet = new AV001_TDI_BIL_MASRAF_AVANS();
                            mHacizVekalet.BORCLU_CARI_ID = htrf.ICRA_CARI_TARAF_ID;
                            mHacizVekalet.MASRAF_AVANS_TIP = 1; //Masraf
                            mHacizVekalet.ACIKLAMA = "IHTIYATI HACIZ EsasNo: " + haciz.ESAS_NO;

                            AV001_TDI_BIL_MASRAF_AVANS mHacizGider = new AV001_TDI_BIL_MASRAF_AVANS();
                            mHacizGider.BORCLU_CARI_ID = htrf.ICRA_CARI_TARAF_ID;
                            mHacizGider.MASRAF_AVANS_TIP = 1; //Masraf
                            mHacizGider.ACIKLAMA = "IHTIYATI HACIZ EsasNo: " + haciz.ESAS_NO;

                            decimal cariSorumlulukOrani = (decimal)SorumlulukOraniGetirByCariId(htrf.ICRA_CARI_TARAF_ID.Value, mFoy);

                            //mHacizVekalet.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                            //    FaizHelper.IcraMasrafAvansGetir(
                            //        vekBirimTutar.YtlCevir(mFoy.TAKIP_TARIHI.Value) * cariSorumlulukOrani,
                            //        291, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));

                            mHacizGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                                FaizHelper.IcraMasrafAvansGetir(
                                    (vekHarcTutar.YtlCevir(mFoy.TAKIP_TARIHI.Value) * cariSorumlulukOrani) / tarafSayisi,
                                    (int)MuhasebeAltKategoriId.VEKALET_HARCI, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));
                            mHacizGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[0].MUVEKKIL_CARI_ID = item.TARAF_CARI_ID;

                            mHacizGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                                FaizHelper.IcraMasrafAvansGetir(
                                    (vekPulTutar.YtlCevir(mFoy.TAKIP_TARIHI.Value) * cariSorumlulukOrani) / tarafSayisi,
                                    (int)MuhasebeAltKategoriId.VEKALET_PULU, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));
                            mHacizGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[1].MUVEKKIL_CARI_ID = item.TARAF_CARI_ID;

                            mHacizGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                                FaizHelper.IcraMasrafAvansGetir(
                                    (basvurmaHarci.Para * cariSorumlulukOrani) / tarafSayisi,
                                                                basvurmaHarci.DovizId, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));
                            mHacizGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[2].MUVEKKIL_CARI_ID = item.TARAF_CARI_ID;

                            mHacizGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                                FaizHelper.IcraMasrafAvansGetir(
                                    (kararIlamHarci.Para * cariSorumlulukOrani) / tarafSayisi,
                                                                kararIlamHarci.DovizId, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));
                            mHacizGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[3].MUVEKKIL_CARI_ID = item.TARAF_CARI_ID;

                            mHacizGiders.Add(mHacizGider);
                            mHacizVekalets.Add(mHacizVekalet);

                            mHacizGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.ForEach(vi => vi.TARIH = haciz.KARAR_TARIHI ?? haciz.TALEP_TARIHI.Value);
                            mHacizVekalet.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.ForEach(vi => vi.TARIH = haciz.KARAR_TARIHI ?? haciz.TALEP_TARIHI.Value);

                            #endregion Taraflar
                        }
                    }
                }
            }

            #endregion Ihtiyati Haciz MASRAF_AVANS DETAY

            #region Ihtiyati Tedbir MASRAF_AVANS DETAY

            //aykut ihtiyati tedbir
            foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF item in listTumAlacakNedenTaraf.Where(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI))
            {
                mFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection = DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.GetByICRA_FOY_ID(mFoy.ID);

                foreach (var tedbir in mFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection)
                {
                    //BUG: AVPNG-81 ile ilgili olarak eklenmiþtir(2 satýr) [YY]
                    if (!tedbir.KARAR_TARIHI.HasValue)
                        return;

                    #region harç vekalet tutarlarý alýnýyor

                    ParaVeDovizId vekBirimTutar = FaizHelper.VekaletTutariGetir(
                        tedbir.KARAR_TARIHI.Value, 216);
                    ParaVeDovizId vekHarcTutar =
                        FaizHelper.IcraHarcTutarGetir(tedbir.KARAR_TARIHI.Value,
                                                      (int)MuhasebeAltKategoriId.VEKALET_HARCI);
                    ParaVeDovizId vekPulTutar =
                        FaizHelper.IcraHarcTutarGetir(tedbir.KARAR_TARIHI.Value,
                                                      (int)MuhasebeAltKategoriId.VEKALET_PULU);

                    ParaVeDovizId basvurmaHarci =
                        FaizHelper.IhtiyatiBasvurmaHarciGetir(tedbir.KARAR_TARIHI.Value,
                                                              DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.
                                                                  GetByID(tedbir.ADLI_BIRIM_GOREV_ID).
                                                                  GOREV);
                    ParaVeDovizId kararIlamHarci =
                        FaizHelper.IhtiyatiKararVeIlamHarciGetir(tedbir.KARAR_TARIHI.Value,
                                                                 DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider
                                                                     .GetByID(tedbir.ADLI_BIRIM_GOREV_ID).
                                                                     GOREV);

                    #endregion harç vekalet tutarlarý alýnýyor

                    tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection = DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFProvider.GetByIHTIYATI_TEDBIR_ID(tedbir.ID);

                    foreach (var ttrf in tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection)
                    {
                        #region Taraflar

                        AV001_TDI_BIL_MASRAF_AVANS mTedbirVekalet = new AV001_TDI_BIL_MASRAF_AVANS();
                        mTedbirVekalet.BORCLU_CARI_ID = ttrf.ICRA_CARI_TARAF_ID;
                        mTedbirVekalet.MASRAF_AVANS_TIP = 1; //Masraf
                        mTedbirVekalet.ACIKLAMA = "IHTIYATI TEDBIR EsasNo: " + tedbir.ESAS_NO;
                        AV001_TDI_BIL_MASRAF_AVANS mTedbirGider = new AV001_TDI_BIL_MASRAF_AVANS();
                        mTedbirGider.BORCLU_CARI_ID = ttrf.ICRA_CARI_TARAF_ID;
                        mTedbirGider.MASRAF_AVANS_TIP = 1; //Masraf
                        mTedbirGider.ACIKLAMA = "IHTIYATI TEDBIR EsasNo: " + tedbir.ESAS_NO;
                        //listTumAlacakNedenTaraf.Where(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI).Count()
                        //decimal cariSorumlulukOrani =
                        //    (decimal)SorumlulukOraniGetirByCariId(ttrf.ICRA_CARI_TARAF_ID.Value, mFoy);

                        decimal cariSorumlulukOrani = tarafSayisi;
                        //    (decimal)SorumlulukOraniGetirByCariId( , mFoy);

                        //mTedbirVekalet.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                        //    FaizHelper.IcraMasrafAvansGetir(
                        //        vekBirimTutar.YtlCevir(mFoy.TAKIP_TARIHI.Value) * cariSorumlulukOrani, 291, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));

                        mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                                FaizHelper.IcraMasrafAvansGetir(
                                    (vekHarcTutar.YtlCevir(mFoy.TAKIP_TARIHI.Value) * cariSorumlulukOrani) / tarafSayisi,
                                    (int)MuhasebeAltKategoriId.VEKALET_HARCI, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));
                        mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[0].MUVEKKIL_CARI_ID = item.TARAF_CARI_ID;

                        mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                            FaizHelper.IcraMasrafAvansGetir(
                                (vekPulTutar.YtlCevir(mFoy.TAKIP_TARIHI.Value) * cariSorumlulukOrani) / tarafSayisi,
                                (int)MuhasebeAltKategoriId.VEKALET_PULU, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));
                        mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[1].MUVEKKIL_CARI_ID = item.TARAF_CARI_ID;

                        mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                            FaizHelper.IcraMasrafAvansGetir(
                                (basvurmaHarci.Para * cariSorumlulukOrani) / tarafSayisi,
                                                            basvurmaHarci.DovizId, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));
                        mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[2].MUVEKKIL_CARI_ID = item.TARAF_CARI_ID;

                        mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                            FaizHelper.IcraMasrafAvansGetir(
                                (kararIlamHarci.Para * cariSorumlulukOrani) / tarafSayisi,
                                                            kararIlamHarci.DovizId, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));
                        mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[3].MUVEKKIL_CARI_ID = item.TARAF_CARI_ID;

                        mHacizGiders.Add(mTedbirGider);
                        mHacizVekalets.Add(mTedbirVekalet);

                        mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.ForEach(vi => vi.TARIH = tedbir.KARAR_TARIHI ?? tedbir.TALEP_TARIHI);
                        mTedbirVekalet.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.ForEach(vi => vi.TARIH = tedbir.KARAR_TARIHI ?? tedbir.TALEP_TARIHI);

                        //0000000000000000000000000
                        //mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                        //    FaizHelper.IcraMasrafAvansGetir(
                        //        (vekHarcTutar.YtlCevir(mFoy.TAKIP_TARIHI.Value) * cariSorumlulukOrani) / tarafSayisi,
                        //        (int)MuhasebeAltKategoriId.VEKALET_HARCI, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));
                        //mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[0].MUVEKKIL_CARI_ID = item.TARAF_CARI_ID;

                        //mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                        //    FaizHelper.IcraMasrafAvansGetir(
                        //        (vekPulTutar.YtlCevir(mFoy.TAKIP_TARIHI.Value) * cariSorumlulukOrani) / tarafSayisi,
                        //        (int)MuhasebeAltKategoriId.VEKALET_PULU, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));
                        //mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[1].MUVEKKIL_CARI_ID = item.TARAF_CARI_ID;

                        //mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                        //    FaizHelper.IcraMasrafAvansGetir(
                        //        (basvurmaHarci.Para * cariSorumlulukOrani) / tarafSayisi,
                        //                                    basvurmaHarci.DovizId, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));
                        //mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[2].MUVEKKIL_CARI_ID = item.TARAF_CARI_ID;
                        //// doviz ID de altkategoriId tutuyoruz

                        //mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                        //    FaizHelper.IcraMasrafAvansGetir(
                        //    (kararIlamHarci.Para * cariSorumlulukOrani) / tarafSayisi,
                        //                                    kararIlamHarci.DovizId, 1, mFoy.TAKIP_TARIHI.Value, mFoy.SEGMENT_ID));
                        //mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[3].MUVEKKIL_CARI_ID = item.TARAF_CARI_ID;

                        //mTedbirGiders.Add(mTedbirGider);
                        //mTedbirVekalets.Add(mTedbirVekalet);

                        //mTedbirGider.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.ForEach(vi => vi.TARIH = tedbir.KARAR_TARIHI ?? tedbir.TALEP_TARIHI);
                        //mTedbirVekalet.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.ForEach(vi => vi.TARIH = tedbir.KARAR_TARIHI ?? tedbir.TALEP_TARIHI);

                        #endregion Taraflar
                    }
                }
            }

            #endregion Ihtiyati Tedbir MASRAF_AVANS DETAY

            #region toplamlar için tutarlar sýfýrlanýyor

            if (mFoy.ID > 0)
            {
                mFoy.IH_VEKALET_UCRETI = 0;
                mFoy.IH_GIDERI = 0;
            }
            mFoy.IT_VEKALET_UCRETI = 0;
            mFoy.IT_GIDERI = 0;
            foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF taraf in listTumAlacakNedenTaraf)
            {
                taraf.IH_VEKALET_UCRETI = 0;
                taraf.IH_GIDERI = 0;
                taraf.IT_GIDERI = 0;
                taraf.IT_VEKALET_UCRETI = 0;
            }

            #endregion toplamlar için tutarlar sýfýrlanýyor

            #region taraf.IH_VEKALET_UCRETI

            foreach (AV001_TDI_BIL_MASRAF_AVANS avans in mHacizVekalets)
            {
                decimal avansToplam = 0;
                foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                {
                    //mFoy.IH_VEKALET_UCRETI += detay.TOPLAM_TUTAR;
                    avansToplam += detay.TOPLAM_TUTAR;
                }
                foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF taraf in
                        listTumAlacakNedenTaraf.FindAll(AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn.TARAF_CARI_ID, avans.BORCLU_CARI_ID.Value))
                {
                    taraf.IH_VEKALET_UCRETI += avansToplam;
                    taraf.IH_VEKALET_UCRETI_DOVIZ_ID = 1;
                }
            }

            #endregion taraf.IH_VEKALET_UCRETI

            #region taraf.IH_GIDERI

            foreach (AV001_TDI_BIL_MASRAF_AVANS avans in mHacizGiders)
            {
                decimal avansToplam = 0;
                foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                {
                    //mFoy.IH_GIDERI += detay.TOPLAM_TUTAR;
                    avansToplam += detay.TOPLAM_TUTAR;
                }
                foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF taraf in
                        listTumAlacakNedenTaraf.FindAll(AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn.TARAF_CARI_ID, avans.BORCLU_CARI_ID.Value))
                {
                    taraf.IH_GIDERI += avansToplam;
                    taraf.IH_GIDERI_DOVIZ_ID = 1;
                }
            }

            #endregion taraf.IH_GIDERI

            #region taraf.IT_VEKALET_UCRETI

            foreach (AV001_TDI_BIL_MASRAF_AVANS avans in mTedbirVekalets)
            {
                decimal avansToplam = 0;
                foreach (
                    AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                {
                    //mFoy.IT_VEKALET_UCRETI += detay.TOPLAM_TUTAR;
                    avansToplam += detay.TOPLAM_TUTAR;
                }
                foreach (
                    AV001_TI_BIL_ALACAK_NEDEN_TARAF taraf in
                        listTumAlacakNedenTaraf.FindAll(AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn.TARAF_CARI_ID, avans.BORCLU_CARI_ID.Value))
                {
                    taraf.IT_VEKALET_UCRETI += avansToplam;
                    taraf.IT_VEKALET_UCRETI_DOVIZ_ID = 1;
                }
            }

            #endregion taraf.IT_VEKALET_UCRETI

            #region taraf.IT_GIDERI

            foreach (AV001_TDI_BIL_MASRAF_AVANS avans in mTedbirGiders)
            {
                decimal avansToplam = 0;
                foreach (
                    AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                {
                    //mFoy.IT_GIDERI += detay.TOPLAM_TUTAR;
                    avansToplam += detay.TOPLAM_TUTAR;
                }
                foreach (
                    AV001_TI_BIL_ALACAK_NEDEN_TARAF taraf in
                        listTumAlacakNedenTaraf.FindAll(AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn.TARAF_CARI_ID, avans.BORCLU_CARI_ID.Value))
                {
                    taraf.IT_GIDERI += avansToplam;
                    taraf.IT_GIDERI_DOVIZ_ID = 1;
                }
            }

            #endregion taraf.IT_GIDERI

            TList<AV001_TDI_BIL_MASRAF_AVANS> otomatikKayitlar = mFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.FindAll(AV001_TDI_BIL_MASRAF_AVANSColumn.MANUEL_KAYIT_MI, false);
            if (mFoy.ID > 0)
            {
                foreach (AV001_TDI_BIL_MASRAF_AVANS avans in otomatikKayitlar)
                {
                    if (string.IsNullOrEmpty(avans.REFERANS_NO))
                        mFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.Remove(avans);
                    else if (!avans.REFERANS_NO.Contains("Ö"))
                        mFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.Remove(avans);
                }
            }

            mFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.AddRange(mHacizGiders);
            mFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.AddRange(mHacizVekalets);
            mFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.AddRange(mTedbirGiders);
            mFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.AddRange(mTedbirVekalets);
            HesaplaIhtiyatiTedbirHaciz(mFoy);

            List<AV001_TDI_BIL_MASRAF_AVANS> silinecekler = new List<AV001_TDI_BIL_MASRAF_AVANS>();
            foreach (AV001_TDI_BIL_MASRAF_AVANS item in mFoy.AV001_TDI_BIL_MASRAF_AVANSCollection)
            {
                foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY item1 in item.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                {
                    if (item1.MUVEKKIL_CARI_ID == null)
                    {
                        silinecekler.Add(item);
                        break;
                    }
                }
            }

            foreach (AV001_TDI_BIL_MASRAF_AVANS item in silinecekler)
            {
                mFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.Remove(item);
            }
        }

        public static void HesaplaIlam(AV001_TI_BIL_FOY mFoy)
        {
            if (mFoy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count == 0)
                return;
            Dictionary<int, decimal> dicInkarTazminati = new Dictionary<int, decimal>();
            Dictionary<int, decimal> dicYargilamaGideri = new Dictionary<int, decimal>();
            Dictionary<int, decimal> dicBakiyeKararHarci = new Dictionary<int, decimal>();
            Dictionary<int, decimal> dicYargitayOnamaHarci = new Dictionary<int, decimal>();
            Dictionary<int, decimal> dicIlamVekaletUcreti = new Dictionary<int, decimal>();
            Dictionary<int, decimal> dicIlamTebligGideri = new Dictionary<int, decimal>();
            foreach (TDI_KOD_DOVIZ_TIP tip in DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetAll())
            {
                dicInkarTazminati.Add(tip.ID, 0);
                dicYargilamaGideri.Add(tip.ID, 0);
                dicBakiyeKararHarci.Add(tip.ID, 0);
                dicYargitayOnamaHarci.Add(tip.ID, 0);
                dicIlamVekaletUcreti.Add(tip.ID, 0);
                dicIlamTebligGideri.Add(tip.ID, 0);
            }
            foreach (AV001_TI_BIL_ILAM_MAHKEMESI mhk in mFoy.AV001_TI_BIL_ILAM_MAHKEMESICollection)
            {
                dicInkarTazminati[mhk.INKAR_TAZMINATI_DOVIZ_ID ?? 1] += mhk.INKAR_TAZMINATI ?? 0;
                dicYargilamaGideri[mhk.YARGILAMA_GIDERI_DOVIZ_ID ?? 1] += mhk.YARGILAMA_GIDERI ?? 0;
                dicBakiyeKararHarci[mhk.BAKIYE_KARAR_HARCI_DOVIZ_ID ?? 1] += mhk.BAKIYE_KARAR_HARCI ?? 0;
                dicYargitayOnamaHarci[mhk.YARGITAY_ONAMA_HARCI_DOVIZ_ID ?? 1] += mhk.YARGITAY_ONAMA_HARCI ?? 0;
                dicIlamVekaletUcreti[mhk.ILAM_VEKALET_UCRETI_DOVIZ_ID ?? 1] += mhk.ILAM_VEKALET_UCRETI ?? 0;
                dicIlamTebligGideri[mhk.ILAM_TEBLIG_GIDERI_DOVIZ_ID ?? 1] += mhk.ILAM_TEBLIG_GIDERI ?? 0;

                #region //

                //FaizHelper.IlamMahkemesiFaizHesapla(mhk, mFoy);
                //ParaVeDovizId inkarTz = FaizHelper.IlamMahkemesiFaizTutarBul(mhk, FaizKalem.ÝNKAR_TAZMÝNATI);
                //-dicInkarTazminati[inkarTz.DovizId] += inkarTz.Para;
                //ParaVeDovizId yargilamaGid = FaizHelper.IlamMahkemesiFaizTutarBul(mhk, FaizKalem.YARGILAMA_GÝDERLERÝ);
                //-dicYargilamaGideri[yargilamaGid.DovizId] += yargilamaGid.Para;
                //ParaVeDovizId bakiyeKH = FaizHelper.IlamMahkemesiFaizTutarBul(mhk, FaizKalem.BAKÝYE_KARAR_HARCI);
                //--dicBakiyeKararHarci[bakiyeKH.DovizId] += bakiyeKH.Para;
                //ParaVeDovizId yargitayOH = FaizHelper.IlamMahkemesiFaizTutarBul(mhk, FaizKalem.YARGITAY_ONAMA_HARCI);
                //--dicYargitayOnamaHarci[yargitayOH.DovizId] += yargitayOH.Para;
                //ParaVeDovizId ilamVU = FaizHelper.IlamMahkemesiFaizTutarBul(mhk, FaizKalem.ÝLAM_VEKALET_ÜCRETÝ);
                //--dicIlamVekaletUcreti[ilamVU.DovizId] += ilamVU.Para;
                //ParaVeDovizId ilamTG = FaizHelper.IlamMahkemesiFaizTutarBul(mhk, FaizKalem.ÝLAM_TEBLÝÐ_GÝDERLERÝ);
                //dicIlamTebligGideri[ilamTG.DovizId] += ilamTG.Para;

                #endregion //
            }
            ParaVeDovizId.BosOlanAlanlariSil(dicInkarTazminati);
            ParaVeDovizId.BosOlanAlanlariSil(dicYargilamaGideri);
            ParaVeDovizId.BosOlanAlanlariSil(dicBakiyeKararHarci);
            ParaVeDovizId.BosOlanAlanlariSil(dicYargitayOnamaHarci);
            ParaVeDovizId.BosOlanAlanlariSil(dicIlamVekaletUcreti);
            ParaVeDovizId.BosOlanAlanlariSil(dicIlamTebligGideri);

            ParaVeDovizId tpInkarT = DictionaryIleIslemYap(dicInkarTazminati);
            ParaVeDovizId tpYargilamaG = DictionaryIleIslemYap(dicYargilamaGideri);
            ParaVeDovizId tpBakiyeKH = DictionaryIleIslemYap(dicBakiyeKararHarci);
            ParaVeDovizId tpYargitayOH = DictionaryIleIslemYap(dicYargitayOnamaHarci);
            ParaVeDovizId tpIlamVU = DictionaryIleIslemYap(dicIlamVekaletUcreti);
            ParaVeDovizId tpIlamTG = DictionaryIleIslemYap(dicIlamTebligGideri);

            mFoy.ILAM_INKAR_TAZMINATI = tpInkarT.Para;
            mFoy.ILAM_INKAR_TAZMINATI_DOVIZ_ID = tpInkarT.DovizId;
            mFoy.ILAM_YARGILAMA_GIDERI = tpYargilamaG.Para;
            mFoy.ILAM_YARGILAMA_GIDERI_DOVIZ_ID = tpYargilamaG.DovizId;

            if (tpBakiyeKH.DovizId == tpYargitayOH.DovizId)
            {
                mFoy.ILAM_BK_YARG_ONAMA = tpBakiyeKH.Para + tpYargitayOH.Para;
                mFoy.ILAM_BK_YARG_ONAMA_DOVIZ_ID = tpBakiyeKH.DovizId;
            }
            else
            {
                mFoy.ILAM_BK_YARG_ONAMA = tpBakiyeKH.YtlCevir(mFoy.TAKIP_TARIHI.Value) +
                                           tpYargitayOH.YtlCevir(mFoy.TAKIP_TARIHI.Value);
                mFoy.ILAM_BK_YARG_ONAMA_DOVIZ_ID = 1;
            }

            mFoy.ILAM_VEK_UCR = tpIlamVU.Para;
            mFoy.ILAM_VEK_UCR_DOVIZ_ID = tpIlamVU.DovizId;
            mFoy.ILAM_TEBLIG_GIDERI = tpIlamTG.Para;
            mFoy.ILAM_TEBLIG_GIDERI_DOVIZ_ID = tpIlamTG.DovizId;
        }

        public static void HesaplaIlamFaizi(AV001_TI_BIL_FOY mFoy, Takip neZaman)
        {
            foreach (AV001_TI_BIL_ILAM_MAHKEMESI mhk in mFoy.AV001_TI_BIL_ILAM_MAHKEMESICollection)
            {
                FaizHelper.IlamMahkemesiFaizHesapla(mhk, mFoy, neZaman);
                foreach (AV001_TI_BIL_FAIZ faiz in mhk.AV001_TI_BIL_FAIZCollection)
                {
                    if (mFoy.TAKIP_TARIHI.HasValue && faiz.FAIZ_BITIS_TARIHI.HasValue)
                    {
                        if (faiz.FAIZ_BITIS_TARIHI.Value <= mFoy.TAKIP_TARIHI.Value && neZaman == Takip.Oncesi)
                        {
                            //kkdf öiv bsmv gibi vergiler ilam m. faizinde olmiyacaðý için sadece
                            //tutar toplanmýþtýr.

                            ParaVeDovizId toplam = ParaVeDovizId.Topla(
                                new ParaVeDovizId(mFoy.ISLEMIS_FAIZ, mFoy.ISLEMIS_FAIZ_DOVIZ_ID, mFoy.TAKIP_TARIHI),
                                new ParaVeDovizId(faiz.FAIZ_TUTARI, faiz.FAIZ_TUTARI_DOVIZ_ID, mFoy.TAKIP_TARIHI));

                            mFoy.ISLEMIS_FAIZ = toplam.Para;
                            mFoy.ISLEMIS_FAIZ_DOVIZ_ID = toplam.DovizId;
                        }
                        else if (faiz.FAIZ_BITIS_TARIHI.Value > mFoy.TAKIP_TARIHI.Value && neZaman == Takip.Sonrasi)
                        {
                            ParaVeDovizId toplam = ParaVeDovizId.Topla(
                                new ParaVeDovizId(mFoy.SONRAKI_FAIZ, mFoy.SONRAKI_FAIZ_DOVIZ_ID, mFoy.SON_HESAP_TARIHI),
                                new ParaVeDovizId(faiz.FAIZ_TUTARI, faiz.FAIZ_TUTARI_DOVIZ_ID, mFoy.SON_HESAP_TARIHI));

                            mFoy.SONRAKI_FAIZ = toplam.Para;
                            mFoy.SONRAKI_FAIZ_DOVIZ_ID = toplam.DovizId;
                        }
                    }
                }
            }
        }

        public static void HesaplaKalanTahsilHarciVs(AV001_TI_BIL_FOY mFoy)
        {
            mFoy.AV001_TI_BIL_BORCLU_ODEMECollection.Sort("ODEME_TARIHI ASC");
            IcraNispiHarcTipi harcTipi = IcraNispiHarcTipi.HACiZDEN_EVVEL_BAKiYE_HARC;
            if (mFoy.AV001_TI_BIL_HACIZ_MASTERCollection.Count > 0)
                harcTipi = IcraNispiHarcTipi.HACiZDEN_SONRA_BAKiYE_HARC;
            if (mFoy.AV001_TI_BIL_SATIS_MASTERCollection.Count > 0)
                harcTipi = IcraNispiHarcTipi.SATiSTAN_SONRA_BAKiYE_HARC;

            decimal kalanPara = ParaVeDovizId.Cikart(new ParaVeDovizId(mFoy.TAKIP_CIKISI, mFoy.TAKIP_CIKISI_DOVIZ_ID),
                new ParaVeDovizId(mFoy.PESIN_HARC, mFoy.PESIN_HARC_DOVIZ_ID)).YtlCevir(mFoy.SON_HESAP_TARIHI ?? DateTime.Now); // YTL olduðunu varsayýyoruz çünkü harclarda var içinde ...
            decimal odenenTahsilHarci = 0;
            mFoy.FERAGAT_HARCI = 0;
            List<OdemeFeragat> dusenler = new List<OdemeFeragat>();
            foreach (AV001_TI_BIL_BORCLU_ODEME odeme in mFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
            {
                if (mFoy.TAKIP_TARIHI.HasValue && odeme.ODEME_TARIHI >= mFoy.TAKIP_TARIHI.Value)
                    dusenler.Add(new OdemeFeragat(odeme.ODEME_TARIHI,
                                                  new ParaVeDovizId(odeme.ODEME_MIKTAR, odeme.ODEME_MIKTAR_DOVIZ_ID),
                                                  EksiltenTipi.Odeme, odeme));
            }
            foreach (AV001_TI_BIL_FERAGAT feragat in mFoy.AV001_TI_BIL_FERAGATCollection)
            {
                if (mFoy.TAKIP_TARIHI.HasValue && feragat.FERAGAT_TARIHI >= mFoy.TAKIP_TARIHI.Value)
                    dusenler.Add(new OdemeFeragat(feragat.FERAGAT_TARIHI,
                                                  new ParaVeDovizId(feragat.FERAGAT_MIKTAR,
                                                                    feragat.FERAGAT_MIKTAR_DOVIZ_ID),
                                                  EksiltenTipi.Feragat, feragat));
            }
            dusenler.Sort(new Comparison<OdemeFeragat>(FaizHelper.compareOdemeFeragat));//TODO: Bak bakalým istediðini yapýyormu [YY]
            decimal cezaEviHarci = 0;
            foreach (OdemeFeragat oFeragat in dusenler)
            {
                if (oFeragat.Para.YtlCevir(oFeragat.Tarih) < kalanPara)
                {
                    ///
                    /// KALAN PARA - ye düþmeyecek. düþmeye yakýn harç hesabýný keseceðiz.
                    ///
                    if (oFeragat.Tipi == EksiltenTipi.Odeme)
                    {
                        double oran = FaizHelper.IcraHarcOraniGetir(oFeragat.Tarih, FaizHelper.OdemeHarcTipiGetirByTarih(mFoy, oFeragat.Tarih));
                        double cEHOran = FaizHelper.IcraHarcOraniGetir(oFeragat.Tarih, IcraNispiHarcTipi.CEZAEVi_HARCi);
                        decimal tmpOdenenTahsilHarci = (decimal)oran * oFeragat.Para.YtlCevir(oFeragat.Tarih) / 100;
                        odenenTahsilHarci += tmpOdenenTahsilHarci;
                        decimal tmpCezaEviHarci = (decimal)cEHOran * oFeragat.Para.YtlCevir(oFeragat.Tarih) / 100;
                        cezaEviHarci += tmpCezaEviHarci;
                        kalanPara -= oFeragat.Para.YtlCevir(oFeragat.Tarih);
                        FaizHelper.IcraHarcKalemiEkleGetir(mFoy, FaizHelper.OdemeHarcTipiGetirByTarih(mFoy, oFeragat.Tarih),
                                                           tmpOdenenTahsilHarci, oFeragat.Tarih, oFeragat.Para, oran);
                        FaizHelper.IcraHarcKalemiEkleGetir(mFoy, IcraNispiHarcTipi.CEZAEVi_HARCi, tmpCezaEviHarci,
                                                           oFeragat.Tarih, oFeragat.Para, cEHOran);
                    }
                    /// TODO:
                    /// KALAN PARA - ye düþmeyecek. düþmeye yakýn harç hesabýný keseceðiz.
                    /// YY
                    else if (oFeragat.Tipi == EksiltenTipi.Feragat)
                    {
                        double oran = FaizHelper.IcraHarcOraniGetir(oFeragat.Tarih, FaizHelper.FeragatHarcTipiGetirByTarih(mFoy, oFeragat.Tarih));
                        decimal tmpFeragatHarci = (decimal)oran * oFeragat.Para.YtlCevir(oFeragat.Tarih) / 100;
                        mFoy.FERAGAT_HARCI += tmpFeragatHarci;
                        kalanPara -= oFeragat.Para.YtlCevir(oFeragat.Tarih);
                        FaizHelper.IcraHarcKalemiEkleGetir(mFoy,
                                                           FaizHelper.FeragatHarcTipiGetirByTarih(mFoy, oFeragat.Tarih),
                                                           tmpFeragatHarci, oFeragat.Tarih, oFeragat.Para, oran);
                    }
                }
                else
                {
                    ///
                    /// KALAN PARA - ye düþmeyecek. düþmeye yakýn harç hesabýný keseceðiz.
                    ///
                    if (oFeragat.Tipi == EksiltenTipi.Odeme)
                    {
                        double oran = FaizHelper.IcraHarcOraniGetir(oFeragat.Tarih, FaizHelper.OdemeHarcTipiGetirByTarih(mFoy, oFeragat.Tarih));
                        double cEHOran = FaizHelper.IcraHarcOraniGetir(oFeragat.Tarih, IcraNispiHarcTipi.CEZAEVi_HARCi);
                        decimal tmpOdenenTahsilHarci = (decimal)oran * kalanPara / 100;
                        odenenTahsilHarci += tmpOdenenTahsilHarci;
                        decimal tmpCezaEviHarci = (decimal)cEHOran * kalanPara / 100;
                        cezaEviHarci += tmpCezaEviHarci;
                        kalanPara = 0;
                        FaizHelper.IcraHarcKalemiEkleGetir(mFoy, FaizHelper.OdemeHarcTipiGetirByTarih(mFoy, oFeragat.Tarih),
                                                           tmpOdenenTahsilHarci, oFeragat.Tarih, new ParaVeDovizId(kalanPara, 1), oran);
                        FaizHelper.IcraHarcKalemiEkleGetir(mFoy, IcraNispiHarcTipi.CEZAEVi_HARCi, tmpCezaEviHarci,
                                                           oFeragat.Tarih, new ParaVeDovizId(kalanPara, 1), cEHOran);
                    }
                    /// TODO:
                    /// KALAN PARA - ye düþmeyecek. düþmeye yakýn harç hesabýný keseceðiz.
                    /// YY
                    else if (oFeragat.Tipi == EksiltenTipi.Feragat)
                    {
                        double oran = FaizHelper.IcraHarcOraniGetir(oFeragat.Tarih, FaizHelper.FeragatHarcTipiGetirByTarih(mFoy, oFeragat.Tarih));
                        decimal tmpFeragatHarci = (decimal)oran * kalanPara / 100;
                        mFoy.FERAGAT_HARCI += tmpFeragatHarci;
                        kalanPara = 0;
                        FaizHelper.IcraHarcKalemiEkleGetir(mFoy,
                                                           FaizHelper.FeragatHarcTipiGetirByTarih(mFoy, oFeragat.Tarih),
                                                           tmpFeragatHarci, oFeragat.Tarih, new ParaVeDovizId(kalanPara, 1), oran);
                    }

                    break;
                }
            }
            double kalanTahsilHarcOrani = FaizHelper.IcraHarcOraniGetir(mFoy.SON_HESAP_TARIHI.Value, harcTipi);
            /// TODO:
            /// KALAN PARA - ye düþmeyecek. düþmeye yakýn harç hesabýný keseceðiz.
            /// YY
            ///
            //int[] dizi = new[] { 4, 5, 6, 7, 13 }; //ilamlý form tipleri
            ////Ýlamlý formlarda kalan tahsil harcý hesaplanmamalýymýþ. Bu nedenle if koþulu eklendi. MB
            //if (dizi.Contains(mFoy.FORM_TIP_ID ?? 0))
            //    mFoy.KALAN_TAHSIL_HARCI = 0;
            //else
            //Yukarýdaki 3 satýr TEKRARDAN Ýlamlý form tiplerinde kalan tahsil harcýnýn hesaplandýðýna karar verdiklerinden kapatýldý. MB
            mFoy.KALAN_TAHSIL_HARCI = ((decimal)kalanTahsilHarcOrani * kalanPara / 100);
            mFoy.ODENEN_TAHSIL_HARCI = odenenTahsilHarci;
            TList<AV001_TI_BIL_FOY_TARAF> listTakipEden =
                mFoy.AV001_TI_BIL_FOY_TARAFCollection.FindAll(AV001_TI_BIL_FOY_TARAFColumn.TAKIP_EDEN_MI, true);
            TList<AV001_TI_BIL_FOY_TARAF> listTakipEdilen =
                mFoy.AV001_TI_BIL_FOY_TARAFCollection.FindAll(AV001_TI_BIL_FOY_TARAFColumn.TAKIP_EDEN_MI, false);

            foreach (AV001_TI_BIL_FOY_TARAF taraf in listTakipEden)
            {
                taraf.CEZA_EVI_HARCI = cezaEviHarci / listTakipEden.Count;
            }
            foreach (AV001_TI_BIL_FOY_TARAF taraf in listTakipEdilen)
            {
                taraf.FERAGAT_HARCI = mFoy.FERAGAT_HARCI * (decimal)taraf.SORUMLULUK_ORANI;
                taraf.ODENEN_TAHSIL_HARCI = mFoy.ODENEN_TAHSIL_HARCI * (decimal)taraf.SORUMLULUK_ORANI;
                taraf.KALAN_TAHSIL_HARCI = mFoy.KALAN_TAHSIL_HARCI * (decimal)taraf.SORUMLULUK_ORANI;
            }
        }

        public static void HesaplaMahsup(AV001_TI_BIL_FOY mFoy)
        {
            var mahsuplar = mFoy.AV001_TI_BIL_BORCLU_MAHSUPCollection.Select(vi => new ParaVeDovizId(vi.MAHSUP_MIKTAR, vi.MAHSUP_MIKTAR_DOVIZ_ID, mFoy.TAKIP_TARIHI)).ToList();

            var toplam = ParaVeDovizId.Topla(mahsuplar);

            if (toplam.Para > 0)
                mFoy.MAHSUP_TOPLAMI = 0 - toplam.Para;
            else
                mFoy.MAHSUP_TOPLAMI = toplam.Para;

            mFoy.MAHSUP_TOPLAMI_DOVIZ_ID = toplam.DovizId;
        }

        public static void HesaplaOdemeToplami(AV001_TI_BIL_FOY mFoy)
        {
            List<ParaVeDovizId> paralar = new List<ParaVeDovizId>();
            foreach (AV001_TI_BIL_BORCLU_ODEME odeme in mFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
            {
                if (mFoy.TAKIP_TARIHI.HasValue && odeme.ODEME_TARIHI > mFoy.TAKIP_TARIHI.Value)
                    paralar.Add(new ParaVeDovizId(odeme.ODEME_MIKTAR, odeme.ODEME_MIKTAR_DOVIZ_ID));
            }
            ParaVeDovizId odemex = FaizHelper.ParalariTopla(paralar, DateTime.Today);
            if (odemex.Para > 0)
            {
                mFoy.ODEME_TOPLAMI = 0 - odemex.Para;
            }
            else
                mFoy.ODEME_TOPLAMI = odemex.Para;
            mFoy.ODEME_TOPLAMI_DOVIZ_ID = odemex.DovizId;
        }

        public static void HesaplaOdemeToplami(AV001_TI_BIL_FOY mFoy, TList<AV001_TI_BIL_BORCLU_ODEME> odemeListesi)
        {
            List<ParaVeDovizId> paralar = new List<ParaVeDovizId>();
            foreach (AV001_TI_BIL_BORCLU_ODEME odeme in odemeListesi)
            {
                if (mFoy.TAKIP_TARIHI.HasValue && odeme.ODEME_TARIHI > mFoy.TAKIP_TARIHI.Value)
                    paralar.Add(new ParaVeDovizId(odeme.ODEME_MIKTAR, odeme.ODEME_MIKTAR_DOVIZ_ID));
            }
            foreach (AV001_TI_BIL_BORCLU_ODEME odeme in mFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
            {
                if (mFoy.TAKIP_TARIHI.HasValue && odeme.ODEME_TARIHI > mFoy.TAKIP_TARIHI.Value)
                    paralar.Add(new ParaVeDovizId(odeme.ODEME_MIKTAR, odeme.ODEME_MIKTAR_DOVIZ_ID));
            }
            ParaVeDovizId odemex = FaizHelper.ParalariTopla(paralar, DateTime.Today);
            if (odemex.Para > 0)
            {
                mFoy.ODEME_TOPLAMI = 0 - odemex.Para;
            }
            else
                mFoy.ODEME_TOPLAMI = odemex.Para;
            mFoy.ODEME_TOPLAMI_DOVIZ_ID = odemex.DovizId;
        }

        public static void HesaplaSonrakiFaiz(AV001_TI_BIL_FOY mFoy) //Takip sonrasý iþlemiþ faiz
        {
            mFoy.SONRAKI_FAIZ = 0;
            //myFoy.TAKIP_TARIHI = dtTakipTarihi.DateTime;

            Dictionary<int, decimal> dicSonrakiFaiz = new Dictionary<int, decimal>();
            foreach (TDI_KOD_DOVIZ_TIP tip in DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetAll())
            {
                dicSonrakiFaiz.Add(tip.ID, 0);
            }
            int nVadeTarihindeYTL = 0;
            int nTakipTarihindeYTL = 0;
            int nOdemeTarihindeYTL = 0;

            //Tüm faizleri tutacaðýmýz iþimizi kolaylaþtýracak geçici liste
            TList<AV001_TI_BIL_FAIZ> faizler = new TList<AV001_TI_BIL_FAIZ>();

            //Alacak neden tiplerini Load ediyoruz (Çek olup olmadýðýný anlamak için) XXX
            //AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(
            //    myFoy.AV001_TI_BIL_ALACAK_NEDENCollection, true, DeepLoadType.IncludeChildren,
            //    typeof (TI_KOD_ALACAK_NEDEN));
            //mFoy.AV001_TI_BIL_ALACAK_NEDENCollection.ForEach(delegate(AV001_TI_BIL_ALACAK_NEDEN obj)
            //                                                      {
            //                                                          if ((mFoy.FAIZ_BASLANGIC_TARIHI.HasValue && obj.FAIZ_BASLANGIC_TARIHI.HasValue) && mFoy.FAIZ_BASLANGIC_TARIHI.Value < obj.FAIZ_BASLANGIC_TARIHI.Value)
            //                                                          {
            //                                                              mFoy.FAIZ_BASLANGIC_TARIHI =
            //                                                                  obj.FAIZ_BASLANGIC_TARIHI.Value;
            //                                                          }
            //                                                          else if (!mFoy.FAIZ_BASLANGIC_TARIHI.HasValue)
            //                                                          {
            //                                                              mFoy.FAIZ_BASLANGIC_TARIHI =
            //                                                                  obj.FAIZ_BASLANGIC_TARIHI;
            //                                                          }
            //                                                      }
            //                                                      );

            TList<AV001_TI_BIL_ALACAK_NEDEN> deposuzNedenler = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
            foreach (AV001_TI_BIL_ALACAK_NEDEN obj in mFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                if (!HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(obj))
                    deposuzNedenler.Add(obj);
            }

            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in deposuzNedenler)
            {
                //Yýlmaz tarafýndan yeni eklendi diðer faiz kalemlerinin üzerine yazmamasý için new kaldýrýlýp bu yapýya gidildi. 13.01.2009
                neden.AV001_TI_BIL_FAIZCollection.Filter = "FAIZ_TAKIPDEN_ONCE_MI = 0";

                #region FaizHesaplarý

                if (!neden.FAIZ_YOK)
                {
                    //Bu nedene ait odeme daðýlýmýný bul
                    //Daðýlým tipi 1 çünkü dosya bazýnda yapýlan daðýlýmlarý buluyoruz.
                    TList<AV001_TI_BIL_ODEME_DAGILIM> odemeList = new TList<AV001_TI_BIL_ODEME_DAGILIM>();
                    foreach (AV001_TI_BIL_ODEME_DAGILIM odeme in neden.AV001_TI_BIL_ODEME_DAGILIMCollection)
                    {
                        if (mFoy.TAKIP_TARIHI.HasValue)
                            if (odeme.DAGILIM_TIPI == 1)
                                if (odeme.MAHSUP_ALT_KATEGORI_ID == (int)MahsupAltKategori.Alacak_Neden)
                                    if (odeme.ODEME_TARIHI >= mFoy.TAKIP_TARIHI.Value)
                                        odemeList.Add(odeme);
                    }

                    #region //

                    //TList<AV001_TI_BIL_ODEME_DAGILIM> odemeList1 = neden.AV001_TI_BIL_ODEME_DAGILIMCollection.FindAll(
                    //    AV001_TI_BIL_ODEME_DAGILIMColumn.DAGILIM_TIPI, 1).FindAll(
                    //    AV001_TI_BIL_ODEME_DAGILIMColumn.MAHSUP_ALT_KATEGORI_ID,(int)MahsupAltKategori.Alacak_Neden).FindAll
                    //    (
                    //    delegate(AV001_TI_BIL_ODEME_DAGILIM obj)
                    //    {
                    //        if (obj.ODEME_TARIHI >= mFoy.TAKIP_TARIHI.Value) //takipsonrasý ödemeleri bul
                    //            return true;
                    //        return false;
                    //    }
                    //    );

                    #endregion //

                    odemeList.Sort("ODEME_TARIHI");

                    if (neden.TO_ALACAK_FAIZ_TIP_ID == 9)//Temerrüt Faizse sabit faiz uyguluyoruz//neden.SABIT_FAIZ_UYGULA)
                    {
                        #region Mahsuplu FaizHesabý

                        DateTime dtBaslangicT = mFoy.TAKIP_TARIHI.Value;
                        if (mFoy.FAIZ_BASLANGIC_TARIHI > mFoy.TAKIP_TARIHI)
                            dtBaslangicT = mFoy.FAIZ_BASLANGIC_TARIHI.Value;

                        ParaVeDovizId pdPara = new ParaVeDovizId();
                        pdPara.Para = neden.ISLEME_KONAN_TUTAR;
                        pdPara.DovizId = neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value;

                        TList<AV001_TI_BIL_FAIZ> fs = new TList<AV001_TI_BIL_FAIZ>();
                        for (int i = 0; i < odemeList.Count; i++)
                        {
                            AV001_TI_BIL_ODEME_DAGILIM dagilim = odemeList[i];
                            fs.Add(
                                FaizHelper.IcraSabitFaizHesapla(9, dtBaslangicT,
                                                                dagilim.ODEME_TARIHI,
                                                                pdPara.Para,
                                                                pdPara.DovizId,
                                                                mFoy.BIR_YIL_KAC_GUN,
                                                                neden.TO_UYGULANACAK_FAIZ_ORANI)

                                );
                            pdPara.Para = pdPara.YtlCevir(dagilim.ODEME_TARIHI) - dagilim.TUTAR;
                            //Mahsuplar hep ytl olarak yapýlýyor
                            pdPara.Para = DovizHelper.CaprazCevir(new ParaVeDovizId(pdPara.Para, 1), pdPara.DovizId,
                                                                  dagilim.ODEME_TARIHI);
                            neden.KO_ISLEME_KONAN_TUTAR = pdPara.Para;
                            dtBaslangicT = dagilim.ODEME_TARIHI;
                            if (pdPara.Para <= 0)
                            {
                                break; //faiz iþlenicek para kalmadýysa bitir olayý.
                            }
                            if (i == odemeList.Count - 1) //Eðer sonuncuysa
                            {
                                fs.Add(
                                    FaizHelper.IcraSabitFaizHesapla(9, dagilim.ODEME_TARIHI,
                                                                    mFoy.SON_HESAP_TARIHI.Value,
                                                                    pdPara.Para,
                                                                    pdPara.DovizId,
                                                                    mFoy.BIR_YIL_KAC_GUN,
                                                                    neden.TO_UYGULANACAK_FAIZ_ORANI));
                            }
                        }
                        if (fs.Count == 0)
                        {
                            fs.Add(
                                FaizHelper.IcraSabitFaizHesapla(9, mFoy.TAKIP_TARIHI.Value,
                                                                mFoy.SON_HESAP_TARIHI.Value,
                                                                neden.ISLEME_KONAN_TUTAR,
                                                                neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                                                                mFoy.BIR_YIL_KAC_GUN, neden.TO_UYGULANACAK_FAIZ_ORANI)

                                );
                        }

                        #endregion Mahsuplu FaizHesabý

                        #region //

                        //Özel Sabit Faiz
                        //AV001_TI_BIL_FAIZ fz =
                        //    FaizHelper.IcraSabitFaizHesapla(9, neden.FAIZ_BASLANGIC_TARIHI.Value,
                        //                                    mFoy.TAKIP_TARIHI.Value,
                        //                                    neden.ISLEME_KONAN_TUTAR,
                        //                                    neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                        //                                    mFoy.BIR_YIL_KAC_GUN, neden.TO_UYGULANACAK_FAIZ_ORANI);

                        //neden.AV001_TI_BIL_FAIZCollection = new TList<AV001_TI_BIL_FAIZ>();
                        //neden.AV001_TI_BIL_FAIZCollection.Add(fz);
                        //faizler.AddRange(neden.AV001_TI_BIL_FAIZCollection);

                        ///<b> DÝKKAT </b>
                        ///Aþaðýdaki kýsým TakipÖncesi Ýþlemiþ faiz kalemlerini ezdiðini düþündüðümüz için
                        ///Comment yapýlmýþtýr yanlýþ düþünüyorda olabiliriz hata çýkarsa günahý
                        ///Yýlmaz ve Gökhanýn boynunadýr.
                        //neden.AV001_TI_BIL_FAIZCollection = new TList<AV001_TI_BIL_FAIZ>();

                        #endregion //

                        neden.AV001_TI_BIL_FAIZCollection.AddRange(fs);
                        faizler.AddRange(neden.AV001_TI_BIL_FAIZCollection);
                    }
                    else //Deðiþken Faiz
                    {
                        //TODO:TEST

                        #region Mahsuplu FaizHesabý

                        DateTime dtBaslangicT = mFoy.TAKIP_TARIHI.Value;
                        if (mFoy.FAIZ_BASLANGIC_TARIHI > mFoy.TAKIP_TARIHI)
                            dtBaslangicT = mFoy.FAIZ_BASLANGIC_TARIHI.Value;

                        ParaVeDovizId pdPara = new ParaVeDovizId();
                        pdPara.Para = neden.ISLEME_KONAN_TUTAR;
                        pdPara.DovizId = neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value;

                        TList<AV001_TI_BIL_FAIZ> fs = new TList<AV001_TI_BIL_FAIZ>();
                        for (int i = 0; i < odemeList.Count; i++)
                        {
                            AV001_TI_BIL_ODEME_DAGILIM dagilim = odemeList[i];
                            fs.AddRange(
                                FaizHelper.IcraDegiskenFaizHesapla(
                                    neden.TO_ALACAK_FAIZ_TIP_ID.Value,
                                    dtBaslangicT,
                                    dagilim.ODEME_TARIHI,
                                    pdPara.Para,
                                    pdPara.DovizId,
                                    mFoy.BIR_YIL_KAC_GUN));
                            pdPara.Para = pdPara.YtlCevir(dagilim.ODEME_TARIHI) - dagilim.TUTAR;
                            //Mahsuplar hep ytl olarak yapýlýyor
                            pdPara.Para = DovizHelper.CaprazCevir(new ParaVeDovizId(pdPara.Para, 1), pdPara.DovizId,
                                                                  dagilim.ODEME_TARIHI);
                            neden.KO_ISLEME_KONAN_TUTAR = pdPara.Para;
                            dtBaslangicT = dagilim.ODEME_TARIHI;
                            if (pdPara.Para <= 0)
                            {
                                break; //faiz iþlenicek para kalmadýysa bitir olayý.
                            }
                            if (i == odemeList.Count - 1) //Eðer sonuncuysa
                            {
                                fs.AddRange(FaizHelper.IcraDegiskenFaizHesapla(
                                                neden.TO_ALACAK_FAIZ_TIP_ID.Value,
                                                dagilim.ODEME_TARIHI,
                                                mFoy.SON_HESAP_TARIHI.Value,
                                                pdPara.Para,
                                                pdPara.DovizId,
                                                mFoy.BIR_YIL_KAC_GUN));
                                //pdPara.Para = pdPara.YtlCevir(dagilim.ODEME_TARIHI) - dagilim.TUTAR;
                                //Mahsuplar hep ytl olarak yapýlýyor
                                //pdPara.Para = DovizHelper.CaprazCevir(new ParaVeDovizId(pdPara.Para, 1), pdPara.DovizId,
                                //     dagilim.ODEME_TARIHI);
                                //neden.KO_ISLEME_KONAN_TUTAR = pdPara.Para;
                            }
                        }
                        if (fs.Count == 0)
                        {
                            fs.AddRange(
                                FaizHelper.IcraDegiskenFaizHesapla(neden.TO_ALACAK_FAIZ_TIP_ID.HasValue ? neden.TO_ALACAK_FAIZ_TIP_ID.Value : 0,
                                                                   mFoy.TAKIP_TARIHI.Value,
                                                                   mFoy.SON_HESAP_TARIHI.Value,
                                                                   neden.ISLEME_KONAN_TUTAR,
                                                                   neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                                                                   mFoy.BIR_YIL_KAC_GUN)
                                );
                        }

                        #endregion Mahsuplu FaizHesabý

                        ///<b> DÝKKAT </b>
                        ///Aþaðýdaki kýsým TakipÖncesi Ýþlemiþ faiz kalemlerini ezdiðini düþündüðümüz için
                        ///Comment yapýlmýþtýr yanlýþ düþünüyorda olabiliriz hata çýkarsa günahý
                        ///Yýlmaz ve Gökhanýn boynunadýr.
                        //neden.AV001_TI_BIL_FAIZCollection = new TList<AV001_TI_BIL_FAIZ>();
                        neden.AV001_TI_BIL_FAIZCollection.AddRange(fs);
                        faizler.AddRange(neden.AV001_TI_BIL_FAIZCollection);
                    }
                }

                #endregion FaizHesaplarý

                #region DigerVergi Hesaplarý

                if (neden.KKDV_HESAPLANSIN)
                {
                    FaizHelper.IcraFaizUzerineDigerVergiHesapla(DigerVergiTuru.KKDF,
                                                                neden.AV001_TI_BIL_FAIZCollection,
                                                                mFoy.SON_HESAP_TARIHI.Value);
                }
                if (neden.OIV_HESAPLANSIN)
                {
                    FaizHelper.IcraFaizUzerineDigerVergiHesapla(DigerVergiTuru.ÖÝV,
                                                                neden.AV001_TI_BIL_FAIZCollection,
                                                                mFoy.SON_HESAP_TARIHI.Value);
                }
                if (neden.BSMV_HESAPLANSIN && BsmvKontrol(neden))
                {
                    FaizHelper.IcraFaizUzerineDigerVergiHesapla(DigerVergiTuru.BSMV,
                                                                neden.AV001_TI_BIL_FAIZCollection,
                                                                mFoy.SON_HESAP_TARIHI.Value);
                }
                if (neden.KDV_HESAPLANSIN && neden.KDV_TIP_ID.HasValue)
                {
                    FaizHelper.IcraFaizUzerineKDVHesapla(neden.KDV_TIP_ID.Value, neden.AV001_TI_BIL_FAIZCollection,
                                                         mFoy.SON_HESAP_TARIHI.Value);
                }

                #endregion DigerVergi Hesaplarý

                #region Çek komisyon Tazminat

                //if (
                //    DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(
                //        neden.ALACAK_NEDEN_KOD_ID.Value).ALACAK_NEDENI == "ÇEK")
                //{
                //    neden.CEK_TAZMINATI = (decimal)neden.CEK_TAZMINATI_ORANI * neden.ISLEME_KONAN_TUTAR / 100;
                //    neden.CEK_TAZMINATI_DOVIZ_ID = neden.ISLEME_KONAN_TUTAR_DOVIZ_ID;
                //    neden.KOMISYONU = (decimal)neden.KOMISYONU_ORANI *
                //                      DovizHelper.CevirYTL(neden.ISLEME_KONAN_TUTAR,
                //                                           neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                //                                           mFoy.TAKIP_TARIHI.Value) / 100;
                //    neden.KOMISYONU_DOVIZ_ID = 1; //YTL
                //    toplamCekKomisyonu += neden.KOMISYONU;
                //    //if (neden.CEK_TAZMINATI_DOVIZ_ID.HasValue)
                //    //    dicCekTazminati[neden.CEK_TAZMINATI_DOVIZ_ID.Value] += neden.CEK_TAZMINATI;
                //}

                #endregion Çek komisyon Tazminat

                #region IhtarGideriProtesto

                //if (neden.PROTESTO_GIDERI_DOVIZ_ID.HasValue && neden.PROTESTO_GIDERI > 0)
                //    toplamProtestoGideri +=
                //        DovizHelper.CevirYTL(neden.PROTESTO_GIDERI, neden.PROTESTO_GIDERI_DOVIZ_ID.Value,
                //                             mFoy.TAKIP_TARIHI.Value);
                //if (neden.IHTAR_GIDERI_DOVIZ_ID.HasValue && neden.IHTAR_GIDERI > 0)
                //    toplamIhtarGideri +=
                //        DovizHelper.CevirYTL(neden.IHTAR_GIDERI, neden.IHTAR_GIDERI_DOVIZ_ID.Value,
                //                             mFoy.TAKIP_TARIHI.Value);

                #endregion IhtarGideriProtesto

                #region DovizIslemleri(HesaplamaModu)

                switch (neden.HESAPLAMA_MODU)
                {
                    case 1:
                        nVadeTarihindeYTL++;
                        break;

                    case 2:
                        nTakipTarihindeYTL++;
                        break;

                    case 3:
                        nOdemeTarihindeYTL++;
                        break;

                    default:
                        break;
                }

                #endregion DovizIslemleri(HesaplamaModu)
            }

            decimal toplamKKDF = 0;
            decimal toplamOIV = 0;
            decimal toplamBSMV = 0;
            decimal toplamKDV = 0;

            #region Tum Foydeki Vergilerin Hesaplanmasý (BSMV,KKDF,OIV,KDV)

            foreach (AV001_TI_BIL_FAIZ faiz in faizler)
            {
                faiz.FAIZ_KALEM_ID = 1; //ASIL ALACAK
            }
            TList<AV001_TI_BIL_FAIZ> tsOzelTutarFaizi = FaizHelper.OzelTutarFaizHesapla(mFoy, Takip.Sonrasi);
            faizler.AddRange(tsOzelTutarFaizi);
            mFoy.AV001_TI_BIL_FAIZCollection.AddRange(tsOzelTutarFaizi);

            foreach (AV001_TI_BIL_FAIZ faiz in faizler)
            {
                dicSonrakiFaiz[faiz.FAIZ_TUTARI_DOVIZ_ID.Value] += faiz.FAIZ_TUTARI;

                faiz.FAIZ_KALEM_ID = 1; //ASIL ALACAK
                toplamBSMV += faiz.BSMV_TUTARI;
                toplamKKDF += faiz.KKDF_TUTARI;
                toplamOIV += faiz.OIV_TUTARI;
                toplamKDV += faiz.KDV_TUTARI;
                faiz.FAIZ_TAKIPDEN_ONCE_MI = 0;   //TODO : AV001_TI_BIL_FAIZ  tablosunda ilgili alan bit olarak ayarlandýktan sonra gerekli deðiþiþklik yapýlacak.. gkn
            }

            mFoy.OIV_TS = toplamOIV;
            mFoy.BSMV_TS = toplamBSMV;
            mFoy.KDV_TS = toplamKDV;
            mFoy.OIV_TS_DOVIZ_ID = 1;
            mFoy.BSMV_TS_DOVIZ_ID = 1;
            mFoy.KDV_TS_DOVIZ_ID = 1;

            #endregion Tum Foydeki Vergilerin Hesaplanmasý (BSMV,KKDF,OIV,KDV)

            #region IslemisFaiz & CekTazminati

            ParaVeDovizId.BosOlanAlanlariSil(dicSonrakiFaiz);
            //Eðer sadece Ödeme tarihinde YTL seçilmiþ ise
            if (nVadeTarihindeYTL == 0 && nTakipTarihindeYTL == 0)
            {
                #region IslemisFaiz

                //Eðer birden fazla döviz tipi var ise
                if (dicSonrakiFaiz.Count > 1)
                {
                    decimal ytlToplam = 0;
                    foreach (KeyValuePair<int, decimal> pair in dicSonrakiFaiz)
                    {
                        if (pair.Key == 1)
                            ytlToplam += pair.Value;
                        else if (pair.Key > 1)
                        {
                            //Dövizi bugünkü kurdan çeviriyoruz
                            ytlToplam += DovizHelper.CevirYTL(pair.Value, pair.Key, DateTime.Today);
                        }
                    }
                    //Hesaplanan deðerleri foy nesnesine yazýyoruz
                    mFoy.SONRAKI_FAIZ = (ytlToplam < 0) ? 0 : ytlToplam;
                    //YTL için 1 veriyoruz
                    mFoy.SONRAKI_FAIZ_DOVIZ_ID = 1;
                }
                else
                {
                    //Tek bir deðer olduðu için
                    Dictionary<int, decimal>.Enumerator num = dicSonrakiFaiz.GetEnumerator();
                    //Tek olan deðere ulaþýyor
                    num.MoveNext();
                    //bunun Doviztip ve miktar bilgilerini foy nesnesine yazýyoruz.
                    mFoy.SONRAKI_FAIZ = (num.Current.Value < 0) ? 0 : num.Current.Value;
                    mFoy.SONRAKI_FAIZ_DOVIZ_ID = num.Current.Key;
                    if (num.Current.Key == 0)
                    {
                        mFoy.SONRAKI_FAIZ_DOVIZ_ID = 1;
                    }
                }

                #endregion IslemisFaiz

                #region CekTazminati(Karsiliksiz)

                ////Eðer birden fazla döviz tipi var ise
                //if (dicCekTazminati.Count > 1)
                //{
                //    decimal ytlToplam = 0;
                //    foreach (KeyValuePair<int, decimal> pair in dicCekTazminati)
                //    {
                //        if (pair.Key == 1)
                //            ytlToplam += pair.Value;
                //        else if (pair.Key > 1)
                //        {
                //            //Dövizi bugünkü kurdan çeviriyoruz
                //            ytlToplam += DovizHelper.CevirYTL(pair.Value, pair.Key, DateTime.Today);
                //        }
                //    }
                //    mFoy.KARSILIKSIZ_CEK_TAZMINATI = ytlToplam;
                //    mFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = 1;
                //}
                //else
                //{
                //    //Tek bir deðer olduðu için
                //    Dictionary<int, decimal>.Enumerator num = dicCekTazminati.GetEnumerator();
                //    //Tek olan deðere ulaþýyor
                //    num.MoveNext();
                //    //bunun Doviztip ve miktar bilgilerini foy nesnesine yazýyoruz.
                //    mFoy.KARSILIKSIZ_CEK_TAZMINATI = num.Current.Value;
                //    mFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = num.Current.Key;
                //    if (num.Current.Key == 0)
                //    {
                //        mFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = 1;
                //    }
                //}

                #endregion CekTazminati(Karsiliksiz)
            }
            //Diðer tüm olasýlýklar için
            else
            {
                decimal ytlToplam = 0;
                TList<AV001_TI_BIL_ALACAK_NEDEN> gayriNakitsizNedenler = GayriNakitleriCikar(mFoy);
                foreach (AV001_TI_BIL_ALACAK_NEDEN neden in gayriNakitsizNedenler)
                {
                    #region IslemisFaiz

                    foreach (AV001_TI_BIL_FAIZ faiz in neden.AV001_TI_BIL_FAIZCollection)
                    {
                        if (faiz.FAIZ_BASLANGIC_TARIHI.HasValue && faiz.FAIZ_BASLANGIC_TARIHI.Value >= mFoy.TAKIP_TARIHI)
                        {
                            switch (neden.HESAPLAMA_MODU)
                            {
                                case 1:
                                    //VadeTarihindeYTL
                                    if (faiz.FAIZ_TUTARI_DOVIZ_ID.HasValue && neden.VADE_TARIHI.HasValue)
                                    {
                                        ytlToplam +=
                                            DovizHelper.CevirYTL(faiz.FAIZ_TUTARI, faiz.FAIZ_TUTARI_DOVIZ_ID.Value,
                                                                 neden.VADE_TARIHI.Value.Date);
                                    }
                                    break;

                                case 2:
                                    //TakipTarihindeYTL
                                    if (faiz.FAIZ_TUTARI_DOVIZ_ID.HasValue && mFoy.TAKIP_TARIHI.HasValue)
                                    {
                                        ytlToplam +=
                                            DovizHelper.CevirYTL(faiz.FAIZ_TUTARI, faiz.FAIZ_TUTARI_DOVIZ_ID.Value,
                                                                 mFoy.TAKIP_TARIHI.Value.Date);
                                    }
                                    break;

                                case 3:
                                    //OdemeTarihindeYTL
                                    if (faiz.FAIZ_TUTARI_DOVIZ_ID.HasValue)
                                    {
                                        ytlToplam +=
                                            DovizHelper.CevirYTL(faiz.FAIZ_TUTARI, faiz.FAIZ_TUTARI_DOVIZ_ID.Value,
                                                                 DateTime.Today);
                                    }
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                }

                    #endregion IslemisFaiz

                foreach (AV001_TI_BIL_FAIZ faiz in tsOzelTutarFaizi)
                {
                    if (faiz.FAIZ_BASLANGIC_TARIHI.HasValue && faiz.FAIZ_BASLANGIC_TARIHI.Value >= mFoy.TAKIP_TARIHI)
                    {
                        switch (3)
                        {
                            case 3:
                                //OdemeTarihindeYTL
                                if (faiz.FAIZ_TUTARI_DOVIZ_ID.HasValue)
                                {
                                    ytlToplam +=
                                        DovizHelper.CevirYTL(faiz.FAIZ_TUTARI, faiz.FAIZ_TUTARI_DOVIZ_ID.Value,
                                                             DateTime.Today);
                                }
                                break;

                            default:
                        }
                    }
                }
                //mFoy.KARSILIKSIZ_CEK_TAZMINATI = cekYtlToplam;
                //mFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = 1;
                mFoy.SONRAKI_FAIZ = (ytlToplam < 0) ? 0 : ytlToplam;
                mFoy.SONRAKI_FAIZ_DOVIZ_ID = 1;
                // mFoy.AV001_TI_BIL_FAIZCollection.AddRange(faizler);
            }

            #endregion IslemisFaiz & CekTazminati

            //Bunu Yukarýda alacak nedenlerinin faiz koleksiyonlarýna filtre verdiðimzi için burda kaldýrýyoruz
            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in mFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                neden.AV001_TI_BIL_FAIZCollection.RemoveFilter();
            }
        }

        public static void HesaplaSonrakiFaiz_OdemePlan(AV001_TI_BIL_FOY mFoy) //Takip sonrasý iþlemiþ faiz
        {
            mFoy.SONRAKI_FAIZ = 0;
            //myFoy.TAKIP_TARIHI = dtTakipTarihi.DateTime;

            Dictionary<int, decimal> dicSonrakiFaiz = new Dictionary<int, decimal>();
            foreach (TDI_KOD_DOVIZ_TIP tip in DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetAll())
            {
                dicSonrakiFaiz.Add(tip.ID, 0);
            }
            int nVadeTarihindeYTL = 0;
            int nTakipTarihindeYTL = 0;
            int nOdemeTarihindeYTL = 0;

            //Tüm faizleri tutacaðýmýz iþimizi kolaylaþtýracak geçici liste
            TList<AV001_TI_BIL_FAIZ> faizler = new TList<AV001_TI_BIL_FAIZ>();

            //Alacak neden tiplerini Load ediyoruz (Çek olup olmadýðýný anlamak için) XXX
            //AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(
            //    myFoy.AV001_TI_BIL_ALACAK_NEDENCollection, true, DeepLoadType.IncludeChildren,
            //    typeof (TI_KOD_ALACAK_NEDEN));
            //mFoy.AV001_TI_BIL_ALACAK_NEDENCollection.ForEach(delegate(AV001_TI_BIL_ALACAK_NEDEN obj)
            //                                                      {
            //                                                          if ((mFoy.FAIZ_BASLANGIC_TARIHI.HasValue && obj.FAIZ_BASLANGIC_TARIHI.HasValue) && mFoy.FAIZ_BASLANGIC_TARIHI.Value < obj.FAIZ_BASLANGIC_TARIHI.Value)
            //                                                          {
            //                                                              mFoy.FAIZ_BASLANGIC_TARIHI =
            //                                                                  obj.FAIZ_BASLANGIC_TARIHI.Value;
            //                                                          }
            //                                                          else if (!mFoy.FAIZ_BASLANGIC_TARIHI.HasValue)
            //                                                          {
            //                                                              mFoy.FAIZ_BASLANGIC_TARIHI =
            //                                                                  obj.FAIZ_BASLANGIC_TARIHI;
            //                                                          }
            //                                                      }
            //                                                      );

            TList<AV001_TI_BIL_ALACAK_NEDEN> deposuzNedenler = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
            foreach (AV001_TI_BIL_ALACAK_NEDEN obj in mFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                if (obj.ALACAK_NEDEN_KOD_IDSource != null && obj.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.HasValue)
                {
                    if (obj.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.Value && obj.VADE_TARIHI.HasValue)
                        obj.FAIZ_BASLANGIC_TARIHI = obj.VADE_TARIHI;

                    if ((obj.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.Value && obj.VADE_TARIHI.HasValue))
                        deposuzNedenler.Add(obj);
                    else if (!obj.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.Value)
                        deposuzNedenler.Add(obj);
                }
                else
                    deposuzNedenler.Add(obj);
            }

            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in deposuzNedenler)
            {
                //Yýlmaz tarafýndan yeni eklendi diðer faiz kalemlerinin üzerine yazmamasý için new kaldýrýlýp bu yapýya gidildi. 13.01.2009
                //neden.AV001_TI_BIL_FAIZCollection.Filter = "FAIZ_TAKIPDEN_ONCE_MI = 0";

                #region FaizHesaplarý

                if (!neden.FAIZ_YOK)
                {
                    //Bu nedene ait odeme daðýlýmýný bul
                    //Daðýlým tipi 1 çünkü dosya bazýnda yapýlan daðýlýmlarý buluyoruz.
                    TList<AV001_TI_BIL_ODEME_DAGILIM> odemeList = new TList<AV001_TI_BIL_ODEME_DAGILIM>();
                    foreach (AV001_TI_BIL_ODEME_DAGILIM odeme in neden.AV001_TI_BIL_ODEME_DAGILIMCollection)
                    {
                        if (neden.FAIZ_BASLANGIC_TARIHI.HasValue)
                            if (odeme.DAGILIM_TIPI == 1)
                                if (odeme.MAHSUP_ALT_KATEGORI_ID == (int)MahsupAltKategori.Alacak_Neden)
                                    if (odeme.ODEME_TARIHI >= neden.FAIZ_BASLANGIC_TARIHI.Value)
                                        odemeList.Add(odeme);
                    }

                    #region //

                    //TList<AV001_TI_BIL_ODEME_DAGILIM> odemeList1 = neden.AV001_TI_BIL_ODEME_DAGILIMCollection.FindAll(
                    //    AV001_TI_BIL_ODEME_DAGILIMColumn.DAGILIM_TIPI, 1).FindAll(
                    //    AV001_TI_BIL_ODEME_DAGILIMColumn.MAHSUP_ALT_KATEGORI_ID,(int)MahsupAltKategori.Alacak_Neden).FindAll
                    //    (
                    //    delegate(AV001_TI_BIL_ODEME_DAGILIM obj)
                    //    {
                    //        if (obj.ODEME_TARIHI >= mFoy.TAKIP_TARIHI.Value) //takipsonrasý ödemeleri bul
                    //            return true;
                    //        return false;
                    //    }
                    //    );

                    #endregion //

                    odemeList.Sort("ODEME_TARIHI");

                    if (neden.SABIT_FAIZ_UYGULA)
                    {
                        #region Mahsuplu FaizHesabý

                        DateTime dtBaslangicT = neden.FAIZ_BASLANGIC_TARIHI.Value;//mFoy.TAKIP_TARIHI.Value;
                        //if (mFoy.FAIZ_BASLANGIC_TARIHI > mFoy.TAKIP_TARIHI)
                        //    dtBaslangicT = mFoy.FAIZ_BASLANGIC_TARIHI.Value;

                        ParaVeDovizId pdPara = new ParaVeDovizId();
                        pdPara.Para = neden.ISLEME_KONAN_TUTAR;
                        pdPara.DovizId = neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value;

                        TList<AV001_TI_BIL_FAIZ> fs = new TList<AV001_TI_BIL_FAIZ>();
                        for (int i = 0; i < odemeList.Count; i++)
                        {
                            AV001_TI_BIL_ODEME_DAGILIM dagilim = odemeList[i];
                            fs.Add(
                                FaizHelper.IcraSabitFaizHesapla(9, dtBaslangicT,
                                                                dagilim.ODEME_TARIHI,
                                                                pdPara.Para,
                                                                pdPara.DovizId,
                                                                mFoy.BIR_YIL_KAC_GUN,
                                                                neden.TO_UYGULANACAK_FAIZ_ORANI)
                                //FaizHelper.IcraDegiskenFaizHesapla(
                                //    neden.TO_ALACAK_FAIZ_TIP_ID.Value,
                                //    dtBaslangicT,
                                //    dagilim.ODEME_TARIHI,
                                //    pdPara.Para,
                                //    pdPara.DovizId,
                                //    mFoy.BIR_YIL_KAC_GUN)
                                );
                            pdPara.Para = pdPara.YtlCevir(dagilim.ODEME_TARIHI) - dagilim.TUTAR;
                            //Mahsuplar hep ytl olarak yapýlýyor
                            pdPara.Para = DovizHelper.CaprazCevir(new ParaVeDovizId(pdPara.Para, 1), pdPara.DovizId,
                                                                  dagilim.ODEME_TARIHI);
                            neden.KO_ISLEME_KONAN_TUTAR = pdPara.Para;
                            dtBaslangicT = dagilim.ODEME_TARIHI;
                            if (pdPara.Para <= 0)
                            {
                                break; //faiz iþlenicek para kalmadýysa bitir olayý.
                            }
                            if (i == odemeList.Count - 1) //Eðer sonuncuysa
                            {
                                fs.Add(
                                    FaizHelper.IcraSabitFaizHesapla(9, dagilim.ODEME_TARIHI,
                                                                    mFoy.SON_HESAP_TARIHI.Value,
                                                                    pdPara.Para,
                                                                    pdPara.DovizId,
                                                                    mFoy.BIR_YIL_KAC_GUN,
                                                                    neden.TO_UYGULANACAK_FAIZ_ORANI));
                                //FaizHelper.IcraDegiskenFaizHesapla(
                                //        neden.TO_ALACAK_FAIZ_TIP_ID.Value,
                                //        dagilim.ODEME_TARIHI,
                                //        mFoy.TAKIP_TARIHI.Value,
                                //        pdPara.Para,
                                //        pdPara.DovizId,
                                //        mFoy.BIR_YIL_KAC_GUN));
                                //pdPara.Para = pdPara.YtlCevir(dagilim.ODEME_TARIHI) - dagilim.TUTAR;
                                //Mahsuplar hep ytl olarak yapýlýyor
                                //pdPara.Para = DovizHelper.CaprazCevir(new ParaVeDovizId(pdPara.Para, 1), pdPara.DovizId,
                                //     dagilim.ODEME_TARIHI);
                                //neden.KO_ISLEME_KONAN_TUTAR = pdPara.Para;
                            }
                        }
                        if (fs.Count == 0)
                        {
                            fs.Add(
                                FaizHelper.IcraSabitFaizHesapla(9, neden.FAIZ_BASLANGIC_TARIHI.Value,
                                                                mFoy.SON_HESAP_TARIHI.Value,
                                                                neden.ISLEME_KONAN_TUTAR,
                                                                neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                                                                mFoy.BIR_YIL_KAC_GUN, neden.TO_UYGULANACAK_FAIZ_ORANI)
                                //FaizHelper.IcraDegiskenFaizHesapla(neden.TO_ALACAK_FAIZ_TIP_ID.Value,
                                //                                   neden.FAIZ_BASLANGIC_TARIHI.Value,
                                //                                   mFoy.TAKIP_TARIHI.Value,
                                //                                   neden.ISLEME_KONAN_TUTAR,
                                //                                   neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                                //                                   mFoy.BIR_YIL_KAC_GUN)
                                );
                        }

                        #endregion Mahsuplu FaizHesabý

                        #region //

                        //Özel Sabit Faiz
                        //AV001_TI_BIL_FAIZ fz =
                        //    FaizHelper.IcraSabitFaizHesapla(9, neden.FAIZ_BASLANGIC_TARIHI.Value,
                        //                                    mFoy.TAKIP_TARIHI.Value,
                        //                                    neden.ISLEME_KONAN_TUTAR,
                        //                                    neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                        //                                    mFoy.BIR_YIL_KAC_GUN, neden.TO_UYGULANACAK_FAIZ_ORANI);

                        //neden.AV001_TI_BIL_FAIZCollection = new TList<AV001_TI_BIL_FAIZ>();
                        //neden.AV001_TI_BIL_FAIZCollection.Add(fz);
                        //faizler.AddRange(neden.AV001_TI_BIL_FAIZCollection);

                        ///<b> DÝKKAT </b>
                        ///Aþaðýdaki kýsým TakipÖncesi Ýþlemiþ faiz kalemlerini ezdiðini düþündüðümüz için
                        ///Comment yapýlmýþtýr yanlýþ düþünüyorda olabiliriz hata çýkarsa günahý
                        ///Yýlmaz ve Gökhanýn boynunadýr.
                        //neden.AV001_TI_BIL_FAIZCollection = new TList<AV001_TI_BIL_FAIZ>();

                        #endregion //

                        neden.AV001_TI_BIL_FAIZCollection.AddRange(fs);
                        faizler.AddRange(neden.AV001_TI_BIL_FAIZCollection);
                    }
                    else //Deðiþken Faiz
                    {
                        //TODO:TEST

                        #region Mahsuplu FaizHesabý

                        DateTime dtBaslangicT = neden.FAIZ_BASLANGIC_TARIHI.Value;//mFoy.TAKIP_TARIHI.Value;
                        //if (mFoy.FAIZ_BASLANGIC_TARIHI > mFoy.TAKIP_TARIHI)
                        //    dtBaslangicT = mFoy.FAIZ_BASLANGIC_TARIHI.Value;

                        ParaVeDovizId pdPara = new ParaVeDovizId();
                        pdPara.Para = neden.ISLEME_KONAN_TUTAR;
                        pdPara.DovizId = neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value;

                        TList<AV001_TI_BIL_FAIZ> fs = new TList<AV001_TI_BIL_FAIZ>();
                        for (int i = 0; i < odemeList.Count; i++)
                        {
                            AV001_TI_BIL_ODEME_DAGILIM dagilim = odemeList[i];
                            fs.AddRange(
                                FaizHelper.IcraDegiskenFaizHesapla(
                                    neden.TO_ALACAK_FAIZ_TIP_ID.Value,
                                    dtBaslangicT,
                                    dagilim.ODEME_TARIHI,
                                    pdPara.Para,
                                    pdPara.DovizId,
                                    mFoy.BIR_YIL_KAC_GUN));
                            pdPara.Para = pdPara.YtlCevir(dagilim.ODEME_TARIHI) - dagilim.TUTAR;
                            //Mahsuplar hep ytl olarak yapýlýyor
                            pdPara.Para = DovizHelper.CaprazCevir(new ParaVeDovizId(pdPara.Para, 1), pdPara.DovizId,
                                                                  dagilim.ODEME_TARIHI);
                            neden.KO_ISLEME_KONAN_TUTAR = pdPara.Para;
                            dtBaslangicT = dagilim.ODEME_TARIHI;
                            if (pdPara.Para <= 0)
                            {
                                break; //faiz iþlenicek para kalmadýysa bitir olayý.
                            }
                            if (i == odemeList.Count - 1) //Eðer sonuncuysa
                            {
                                fs.AddRange(FaizHelper.IcraDegiskenFaizHesapla(
                                                neden.TO_ALACAK_FAIZ_TIP_ID.Value,
                                                dagilim.ODEME_TARIHI,
                                                mFoy.SON_HESAP_TARIHI.Value,
                                                pdPara.Para,
                                                pdPara.DovizId,
                                                mFoy.BIR_YIL_KAC_GUN));
                                //pdPara.Para = pdPara.YtlCevir(dagilim.ODEME_TARIHI) - dagilim.TUTAR;
                                //Mahsuplar hep ytl olarak yapýlýyor
                                //pdPara.Para = DovizHelper.CaprazCevir(new ParaVeDovizId(pdPara.Para, 1), pdPara.DovizId,
                                //     dagilim.ODEME_TARIHI);
                                //neden.KO_ISLEME_KONAN_TUTAR = pdPara.Para;
                            }
                        }
                        if (fs.Count == 0)
                        {
                            fs.AddRange(
                                FaizHelper.IcraDegiskenFaizHesapla(neden.TO_ALACAK_FAIZ_TIP_ID.Value,
                                                                   neden.FAIZ_BASLANGIC_TARIHI.Value,
                                                                   mFoy.SON_HESAP_TARIHI.Value,
                                                                   neden.ISLEME_KONAN_TUTAR,
                                                                   neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                                                                   mFoy.BIR_YIL_KAC_GUN)
                                );
                        }

                        #endregion Mahsuplu FaizHesabý

                        ///<b> DÝKKAT </b>
                        ///Aþaðýdaki kýsým TakipÖncesi Ýþlemiþ faiz kalemlerini ezdiðini düþündüðümüz için
                        ///Comment yapýlmýþtýr yanlýþ düþünüyorda olabiliriz hata çýkarsa günahý
                        ///Yýlmaz ve Gökhanýn boynunadýr.
                        //neden.AV001_TI_BIL_FAIZCollection = new TList<AV001_TI_BIL_FAIZ>();
                        neden.AV001_TI_BIL_FAIZCollection.AddRange(fs);
                        faizler.AddRange(neden.AV001_TI_BIL_FAIZCollection);
                    }
                }

                #endregion FaizHesaplarý

                #region DigerVergi Hesaplarý

                if (neden.KKDV_HESAPLANSIN)
                {
                    FaizHelper.IcraFaizUzerineDigerVergiHesapla(DigerVergiTuru.KKDF,
                                                                neden.AV001_TI_BIL_FAIZCollection,
                                                                mFoy.SON_HESAP_TARIHI.Value);
                }
                if (neden.OIV_HESAPLANSIN)
                {
                    FaizHelper.IcraFaizUzerineDigerVergiHesapla(DigerVergiTuru.ÖÝV,
                                                                neden.AV001_TI_BIL_FAIZCollection,
                                                                mFoy.SON_HESAP_TARIHI.Value);
                }
                if (neden.BSMV_HESAPLANSIN && BsmvKontrol(neden))
                {
                    FaizHelper.IcraFaizUzerineDigerVergiHesapla(DigerVergiTuru.BSMV,
                                                                neden.AV001_TI_BIL_FAIZCollection,
                                                                mFoy.SON_HESAP_TARIHI.Value);
                }
                if (neden.KDV_HESAPLANSIN && neden.KDV_TIP_ID.HasValue)
                {
                    FaizHelper.IcraFaizUzerineKDVHesapla(neden.KDV_TIP_ID.Value, neden.AV001_TI_BIL_FAIZCollection,
                                                         mFoy.SON_HESAP_TARIHI.Value);
                }

                #endregion DigerVergi Hesaplarý

                #region Çek komisyon Tazminat

                //if (
                //    DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(
                //        neden.ALACAK_NEDEN_KOD_ID.Value).ALACAK_NEDENI == "ÇEK")
                //{
                //    neden.CEK_TAZMINATI = (decimal)neden.CEK_TAZMINATI_ORANI * neden.ISLEME_KONAN_TUTAR / 100;
                //    neden.CEK_TAZMINATI_DOVIZ_ID = neden.ISLEME_KONAN_TUTAR_DOVIZ_ID;
                //    neden.KOMISYONU = (decimal)neden.KOMISYONU_ORANI *
                //                      DovizHelper.CevirYTL(neden.ISLEME_KONAN_TUTAR,
                //                                           neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                //                                           mFoy.TAKIP_TARIHI.Value) / 100;
                //    neden.KOMISYONU_DOVIZ_ID = 1; //YTL
                //    toplamCekKomisyonu += neden.KOMISYONU;
                //    //if (neden.CEK_TAZMINATI_DOVIZ_ID.HasValue)
                //    //    dicCekTazminati[neden.CEK_TAZMINATI_DOVIZ_ID.Value] += neden.CEK_TAZMINATI;
                //}

                #endregion Çek komisyon Tazminat

                #region IhtarGideriProtesto

                //if (neden.PROTESTO_GIDERI_DOVIZ_ID.HasValue && neden.PROTESTO_GIDERI > 0)
                //    toplamProtestoGideri +=
                //        DovizHelper.CevirYTL(neden.PROTESTO_GIDERI, neden.PROTESTO_GIDERI_DOVIZ_ID.Value,
                //                             mFoy.TAKIP_TARIHI.Value);
                //if (neden.IHTAR_GIDERI_DOVIZ_ID.HasValue && neden.IHTAR_GIDERI > 0)
                //    toplamIhtarGideri +=
                //        DovizHelper.CevirYTL(neden.IHTAR_GIDERI, neden.IHTAR_GIDERI_DOVIZ_ID.Value,
                //                             mFoy.TAKIP_TARIHI.Value);

                #endregion IhtarGideriProtesto

                #region DovizIslemleri(HesaplamaModu)

                switch (neden.HESAPLAMA_MODU)
                {
                    case 1:
                        nVadeTarihindeYTL++;
                        break;

                    case 2:
                        nTakipTarihindeYTL++;
                        break;

                    case 3:
                        nOdemeTarihindeYTL++;
                        break;

                    default:
                        break;
                }

                #endregion DovizIslemleri(HesaplamaModu)
            }

            decimal toplamKKDF = 0;
            decimal toplamOIV = 0;
            decimal toplamBSMV = 0;
            decimal toplamKDV = 0;

            #region Tum Foydeki Vergilerin Hesaplanmasý (BSMV,KKDF,OIV,KDV)

            foreach (AV001_TI_BIL_FAIZ faiz in faizler)
            {
                faiz.FAIZ_KALEM_ID = 1; //ASIL ALACAK
            }
            TList<AV001_TI_BIL_FAIZ> tsOzelTutarFaizi = FaizHelper.OzelTutarFaizHesapla(mFoy, Takip.Sonrasi);
            faizler.AddRange(tsOzelTutarFaizi);
            mFoy.AV001_TI_BIL_FAIZCollection.AddRange(tsOzelTutarFaizi);

            foreach (AV001_TI_BIL_FAIZ faiz in faizler)
            {
                dicSonrakiFaiz[faiz.FAIZ_TUTARI_DOVIZ_ID.Value] += faiz.FAIZ_TUTARI;

                faiz.FAIZ_KALEM_ID = 1; //ASIL ALACAK
                toplamBSMV += faiz.BSMV_TUTARI;
                toplamKKDF += faiz.KKDF_TUTARI;
                toplamOIV += faiz.OIV_TUTARI;
                toplamKDV += faiz.KDV_TUTARI;
                faiz.FAIZ_TAKIPDEN_ONCE_MI = 0;   //TODO : AV001_TI_BIL_FAIZ  tablosunda ilgili alan bit olarak ayarlandýktan sonra gerekli deðiþiþklik yapýlacak.. gkn
            }

            mFoy.OIV_TS = toplamOIV;
            mFoy.BSMV_TS = toplamBSMV;
            mFoy.KDV_TS = toplamKDV;
            mFoy.OIV_TS_DOVIZ_ID = 1;
            mFoy.BSMV_TS_DOVIZ_ID = 1;
            mFoy.KDV_TS_DOVIZ_ID = 1;

            #endregion Tum Foydeki Vergilerin Hesaplanmasý (BSMV,KKDF,OIV,KDV)

            #region IslemisFaiz & CekTazminati

            ParaVeDovizId.BosOlanAlanlariSil(dicSonrakiFaiz);
            //Eðer sadece Ödeme tarihinde YTL seçilmiþ ise
            if (nVadeTarihindeYTL == 0 && nTakipTarihindeYTL == 0)
            {
                #region IslemisFaiz

                //Eðer birden fazla döviz tipi var ise
                if (dicSonrakiFaiz.Count > 1)
                {
                    decimal ytlToplam = 0;
                    foreach (KeyValuePair<int, decimal> pair in dicSonrakiFaiz)
                    {
                        if (pair.Key == 1)
                            ytlToplam += pair.Value;
                        else if (pair.Key > 1)
                        {
                            //Dövizi bugünkü kurdan çeviriyoruz
                            ytlToplam += DovizHelper.CevirYTL(pair.Value, pair.Key, DateTime.Today);
                        }
                    }
                    //Hesaplanan deðerleri foy nesnesine yazýyoruz
                    mFoy.SONRAKI_FAIZ = (ytlToplam < 0) ? 0 : ytlToplam;
                    //YTL için 1 veriyoruz
                    mFoy.SONRAKI_FAIZ_DOVIZ_ID = 1;
                }
                else
                {
                    //Tek bir deðer olduðu için
                    Dictionary<int, decimal>.Enumerator num = dicSonrakiFaiz.GetEnumerator();
                    //Tek olan deðere ulaþýyor
                    num.MoveNext();
                    //bunun Doviztip ve miktar bilgilerini foy nesnesine yazýyoruz.
                    mFoy.SONRAKI_FAIZ = (num.Current.Value < 0) ? 0 : num.Current.Value;
                    mFoy.SONRAKI_FAIZ_DOVIZ_ID = num.Current.Key;
                    if (num.Current.Key == 0)
                    {
                        mFoy.SONRAKI_FAIZ_DOVIZ_ID = 1;
                    }
                }

                #endregion IslemisFaiz

                #region CekTazminati(Karsiliksiz)

                ////Eðer birden fazla döviz tipi var ise
                //if (dicCekTazminati.Count > 1)
                //{
                //    decimal ytlToplam = 0;
                //    foreach (KeyValuePair<int, decimal> pair in dicCekTazminati)
                //    {
                //        if (pair.Key == 1)
                //            ytlToplam += pair.Value;
                //        else if (pair.Key > 1)
                //        {
                //            //Dövizi bugünkü kurdan çeviriyoruz
                //            ytlToplam += DovizHelper.CevirYTL(pair.Value, pair.Key, DateTime.Today);
                //        }
                //    }
                //    mFoy.KARSILIKSIZ_CEK_TAZMINATI = ytlToplam;
                //    mFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = 1;
                //}
                //else
                //{
                //    //Tek bir deðer olduðu için
                //    Dictionary<int, decimal>.Enumerator num = dicCekTazminati.GetEnumerator();
                //    //Tek olan deðere ulaþýyor
                //    num.MoveNext();
                //    //bunun Doviztip ve miktar bilgilerini foy nesnesine yazýyoruz.
                //    mFoy.KARSILIKSIZ_CEK_TAZMINATI = num.Current.Value;
                //    mFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = num.Current.Key;
                //    if (num.Current.Key == 0)
                //    {
                //        mFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = 1;
                //    }
                //}

                #endregion CekTazminati(Karsiliksiz)
            }
            //Diðer tüm olasýlýklar için
            else
            {
                decimal ytlToplam = 0;
                TList<AV001_TI_BIL_ALACAK_NEDEN> gayriNakitsizNedenler = GayriNakitleriCikar(mFoy);
                foreach (AV001_TI_BIL_ALACAK_NEDEN neden in gayriNakitsizNedenler)
                {
                    #region IslemisFaiz

                    foreach (AV001_TI_BIL_FAIZ faiz in neden.AV001_TI_BIL_FAIZCollection)
                    {
                        switch (neden.HESAPLAMA_MODU)
                        {
                            case 1:
                                //VadeTarihindeYTL
                                if (faiz.FAIZ_TUTARI_DOVIZ_ID.HasValue && neden.VADE_TARIHI.HasValue)
                                {
                                    ytlToplam +=
                                        DovizHelper.CevirYTL(faiz.FAIZ_TUTARI, faiz.FAIZ_TUTARI_DOVIZ_ID.Value,
                                                             neden.VADE_TARIHI.Value.Date);
                                }
                                break;

                            case 2:
                                //TakipTarihindeYTL
                                if (faiz.FAIZ_TUTARI_DOVIZ_ID.HasValue && mFoy.TAKIP_TARIHI.HasValue)
                                {
                                    ytlToplam +=
                                        DovizHelper.CevirYTL(faiz.FAIZ_TUTARI, faiz.FAIZ_TUTARI_DOVIZ_ID.Value,
                                                             mFoy.TAKIP_TARIHI.Value.Date);
                                }
                                break;

                            case 3:
                                //OdemeTarihindeYTL
                                if (faiz.FAIZ_TUTARI_DOVIZ_ID.HasValue)
                                {
                                    ytlToplam +=
                                        DovizHelper.CevirYTL(faiz.FAIZ_TUTARI, faiz.FAIZ_TUTARI_DOVIZ_ID.Value,
                                                             DateTime.Today);
                                }
                                break;

                            default:
                                break;
                        }
                    }

                    #endregion IslemisFaiz
                }
                //mFoy.KARSILIKSIZ_CEK_TAZMINATI = cekYtlToplam;
                //mFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = 1;
                mFoy.SONRAKI_FAIZ = (ytlToplam < 0) ? 0 : ytlToplam;
                mFoy.SONRAKI_FAIZ_DOVIZ_ID = 1;
                // mFoy.AV001_TI_BIL_FAIZCollection.AddRange(faizler);
            }

            #endregion IslemisFaiz & CekTazminati

            //Bunu Yukarýda alacak nedenlerinin faiz koleksiyonlarýna filtre verdiðimzi için burda kaldýrýyoruz
            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in mFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                neden.AV001_TI_BIL_FAIZCollection.RemoveFilter();
            }
        }

        public static void HesaplaTakipCikisi(AV001_TI_BIL_FOY mFoy)
        {
            FaizHelper.TakipCikisiHesapla(mFoy);
        }

        public static void HesaplaTakipCikisiTaraf(AV001_TI_BIL_ALACAK_NEDEN neden, DateTime takipTarihi)
        {
            foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF taraf in neden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
            {
                FaizHelper.TakipCikisiHesapla(taraf, takipTarihi);
            }
        }

        public static void HesaplaTakipOncesiIslemisFaiz(AV001_TI_BIL_FOY mFoy)
        {
            //TODO: KALDIR BURAYI YILMAZ (Yýlmaz)
            if (mFoy.BIR_YIL_KAC_GUN == 0)
                mFoy.BIR_YIL_KAC_GUN = 360; // gridden al
            mFoy.ISLEMIS_FAIZ = 0;
            //myFoy.TAKIP_TARIHI = dtTakipTarihi.DateTime;

            Dictionary<int, decimal> dicIslemisFaiz = new Dictionary<int, decimal>();
            Dictionary<int, decimal> dicCekTazminati = new Dictionary<int, decimal>();
            //foreach (TDI_KOD_DOVIZ_TIP tip in DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetAll())
            //{
            //    //dicIslemisFaiz.Add(tip.ID, 0);
            //    dicCekTazminati.Add(tip.ID, 0);
            //}
            int nVadeTarihindeYTL = 0;
            int nTakipTarihindeYTL = 0;
            int nOdemeTarihindeYTL = 0;

            decimal toplamCekKomisyonu = 0;
            decimal toplamIhtarGideri = 0;
            decimal toplamProtestoGideri = 0;

            //Tüm faizleri tutacaðýmýz iþimizi kolaylaþtýracak geçici liste
            TList<AV001_TI_BIL_FAIZ> faizler = new TList<AV001_TI_BIL_FAIZ>();

            //Alacak neden tiplerini Load ediyoruz (Çek olup olmadýðýný anlamak için) XXX
            //AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(
            //    myFoy.AV001_TI_BIL_ALACAK_NEDENCollection, true, DeepLoadType.IncludeChildren,
            //    typeof (TI_KOD_ALACAK_NEDEN));
            mFoy.AV001_TI_BIL_ALACAK_NEDENCollection.ForEach(delegate(AV001_TI_BIL_ALACAK_NEDEN obj)
            {
                if ((mFoy.FAIZ_BASLANGIC_TARIHI.HasValue && obj.FAIZ_BASLANGIC_TARIHI.HasValue) && mFoy.FAIZ_BASLANGIC_TARIHI.Value < obj.FAIZ_BASLANGIC_TARIHI.Value)
                {
                    mFoy.FAIZ_BASLANGIC_TARIHI =
                        obj.FAIZ_BASLANGIC_TARIHI.Value;
                }
                else if (!mFoy.FAIZ_BASLANGIC_TARIHI.HasValue)
                {
                    mFoy.FAIZ_BASLANGIC_TARIHI =
                        obj.FAIZ_BASLANGIC_TARIHI;
                }
            });

            TList<AV001_TI_BIL_ALACAK_NEDEN> deposuzNedenler = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
            foreach (AV001_TI_BIL_ALACAK_NEDEN obj in mFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                if (obj.ALACAK_NEDEN_KOD_IDSource != null && obj.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.HasValue)
                {
                    if (obj.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.Value && obj.VADE_TARIHI.HasValue)
                        obj.FAIZ_BASLANGIC_TARIHI = obj.VADE_TARIHI;

                    if (obj.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.Value && obj.VADE_TARIHI.HasValue)
                        deposuzNedenler.Add(obj);
                    else if (!obj.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.Value)
                        deposuzNedenler.Add(obj);
                }
                else
                    deposuzNedenler.Add(obj);
            }

            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in deposuzNedenler)// mFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                #region donüyoruz

                if (!neden.FAIZ_YOK)//Faiz var ise aþaðýdakileri yapýyoruz
                    if (!((mFoy.HESAPLANMIS_FAIZ.HasValue && mFoy.HESAPLANMIS_FAIZ.Value > 0) || (mFoy.HESAPLANMIS_KKDF.HasValue && mFoy.HESAPLANMIS_KKDF.Value > 0) || (mFoy.HESAPLANMIS_BSMV.HasValue && mFoy.HESAPLANMIS_BSMV.Value > 0) || (mFoy.HESAPLANMIS_OIV.HasValue && mFoy.HESAPLANMIS_OIV.Value > 0) || (mFoy.HESAPLANMIS_KDV.HasValue && mFoy.HESAPLANMIS_KDV.Value > 0)))
                    {
                        //Eðer Takip tarihi Faiz baþlangýç tarihinden büyük deðilse hesap yapmýyoruz.[YY] 21.03.2009 18:05
                        if (neden.FAIZ_BASLANGIC_TARIHI.HasValue && mFoy.TAKIP_TARIHI.HasValue && neden.FAIZ_BASLANGIC_TARIHI.Value < mFoy.TAKIP_TARIHI)
                        {
                            #region FaizHesaplarý

                            //Bu nedene ait odeme daðýlýmýný bul
                            //Daðýlým tipi 1 çünkü dosya bazýnda bir daðýlým arýyoruz.
                            TList<AV001_TI_BIL_ODEME_DAGILIM> odemeListTumu = neden.AV001_TI_BIL_ODEME_DAGILIMCollection;
                            TList<AV001_TI_BIL_ODEME_DAGILIM> odemeList = new TList<AV001_TI_BIL_ODEME_DAGILIM>();
                            foreach (AV001_TI_BIL_ODEME_DAGILIM dagilim in odemeListTumu)
                            {
                                if (mFoy.TAKIP_TARIHI.HasValue
                                    && dagilim.DAGILIM_TIPI == 1
                                    && dagilim.MAHSUP_ALT_KATEGORI_ID == (int)MahsupAltKategori.Alacak_Neden
                                    && dagilim.ODEME_TARIHI < mFoy.TAKIP_TARIHI.Value)
                                    odemeList.Add(dagilim);
                            }

                            odemeList.Sort("ODEME_TARIHI");

                            if (neden.TO_ALACAK_FAIZ_TIP_ID == 9)
                            {
                                #region Mahsuplu FaizHesabý

                                DateTime dtBaslangicT = neden.FAIZ_BASLANGIC_TARIHI.Value;
                                ParaVeDovizId pdPara = new ParaVeDovizId();
                                pdPara.Para = neden.ISLEME_KONAN_TUTAR;
                                pdPara.DovizId = neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value;

                                TList<AV001_TI_BIL_FAIZ> fs = new TList<AV001_TI_BIL_FAIZ>();
                                for (int i = 0; i < odemeList.Count; i++)
                                {
                                    AV001_TI_BIL_ODEME_DAGILIM dagilim = odemeList[i];
                                    fs.Add(
                                                FaizHelper.IcraSabitFaizHesapla(9, dtBaslangicT,
                                                dagilim.ODEME_TARIHI,
                                                pdPara.Para,
                                                pdPara.DovizId,
                                                mFoy.BIR_YIL_KAC_GUN,
                                                neden.TO_UYGULANACAK_FAIZ_ORANI));

                                    pdPara.Para = pdPara.YtlCevir(dagilim.ODEME_TARIHI) - dagilim.TUTAR;
                                    //Mahsuplar hep ytl olarak yapýlýyor
                                    pdPara.Para = DovizHelper.CaprazCevir(new ParaVeDovizId(pdPara.Para, 1), pdPara.DovizId,
                                                                          dagilim.ODEME_TARIHI);
                                    neden.KO_ISLEME_KONAN_TUTAR = pdPara.Para;
                                    dtBaslangicT = dagilim.ODEME_TARIHI;
                                    if (pdPara.Para <= 0)
                                    {
                                        break; //faiz iþlenicek para kalmadýysa bitir olayý.
                                    }
                                    if (i == odemeList.Count - 1)//Eðer sonuncuysa
                                    {
                                        fs.Add(
                                            FaizHelper.IcraSabitFaizHesapla(9, dagilim.ODEME_TARIHI,
                                                                            mFoy.TAKIP_TARIHI.Value,
                                                                            pdPara.Para,
                                                                            pdPara.DovizId,
                                                                            mFoy.BIR_YIL_KAC_GUN,
                                                                            neden.TO_UYGULANACAK_FAIZ_ORANI));
                                    }
                                }
                                if (fs.Count == 0)
                                {
                                    fs.Add(
                                        FaizHelper.IcraSabitFaizHesapla(9, neden.FAIZ_BASLANGIC_TARIHI.Value,
                                                                    mFoy.TAKIP_TARIHI.Value,
                                                                    neden.ISLEME_KONAN_TUTAR,
                                                                    neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                                                                    mFoy.BIR_YIL_KAC_GUN, neden.TO_UYGULANACAK_FAIZ_ORANI));
                                }

                                #endregion Mahsuplu FaizHesabý

                                //Özel Sabit Faiz
                                //AV001_TI_BIL_FAIZ fz =
                                //    FaizHelper.IcraSabitFaizHesapla(9, neden.FAIZ_BASLANGIC_TARIHI.Value,
                                //                                    mFoy.TAKIP_TARIHI.Value,
                                //                                    neden.ISLEME_KONAN_TUTAR,
                                //                                    neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                                //                                    mFoy.BIR_YIL_KAC_GUN, neden.TO_UYGULANACAK_FAIZ_ORANI);

                                //neden.AV001_TI_BIL_FAIZCollection = new TList<AV001_TI_BIL_FAIZ>();
                                //neden.AV001_TI_BIL_FAIZCollection.Add(fz);
                                //faizler.AddRange(neden.AV001_TI_BIL_FAIZCollection);
                                neden.AV001_TI_BIL_FAIZCollection = new TList<AV001_TI_BIL_FAIZ>();
                                neden.AV001_TI_BIL_FAIZCollection.AddRange(fs);
                                faizler.AddRange(neden.AV001_TI_BIL_FAIZCollection);
                            }
                            else //Deðiþken Faiz
                            {//TODO:TEST
                                #region Mahsuplu FaizHesabý

                                DateTime dtBaslangicT = neden.FAIZ_BASLANGIC_TARIHI.Value;
                                ParaVeDovizId pdPara = new ParaVeDovizId();
                                pdPara.Para = neden.ISLEME_KONAN_TUTAR;
                                pdPara.DovizId = neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value;

                                TList<AV001_TI_BIL_FAIZ> fs = new TList<AV001_TI_BIL_FAIZ>();
                                for (int i = 0; i < odemeList.Count; i++)
                                {
                                    AV001_TI_BIL_ODEME_DAGILIM dagilim = odemeList[i];
                                    fs.AddRange(
                                        FaizHelper.IcraDegiskenFaizHesapla(
                                            neden.TO_ALACAK_FAIZ_TIP_ID.Value,
                                            dtBaslangicT,
                                            dagilim.ODEME_TARIHI,
                                            pdPara.Para,
                                            pdPara.DovizId,
                                            mFoy.BIR_YIL_KAC_GUN));
                                    pdPara.Para = pdPara.YtlCevir(dagilim.ODEME_TARIHI) - dagilim.TUTAR;
                                    //Mahsuplar hep ytl olarak yapýlýyor
                                    pdPara.Para = DovizHelper.CaprazCevir(new ParaVeDovizId(pdPara.Para, 1), pdPara.DovizId,
                                                                          dagilim.ODEME_TARIHI);
                                    neden.KO_ISLEME_KONAN_TUTAR = pdPara.Para;
                                    dtBaslangicT = dagilim.ODEME_TARIHI;
                                    if (pdPara.Para <= 0)
                                    {
                                        break; //faiz iþlenicek para kalmadýysa bitir olayý.
                                    }
                                    if (i == odemeList.Count - 1)//Eðer sonuncuysa
                                    {
                                        fs.AddRange(FaizHelper.IcraDegiskenFaizHesapla(
                                                    neden.TO_ALACAK_FAIZ_TIP_ID.Value,
                                                    dagilim.ODEME_TARIHI,
                                                    mFoy.TAKIP_TARIHI.Value,
                                                    pdPara.Para,
                                                    pdPara.DovizId,
                                                    mFoy.BIR_YIL_KAC_GUN));
                                        //pdPara.Para = pdPara.YtlCevir(dagilim.ODEME_TARIHI) - dagilim.TUTAR;
                                        //Mahsuplar hep ytl olarak yapýlýyor
                                        //pdPara.Para = DovizHelper.CaprazCevir(new ParaVeDovizId(pdPara.Para, 1), pdPara.DovizId,
                                        //     dagilim.ODEME_TARIHI);
                                        //neden.KO_ISLEME_KONAN_TUTAR = pdPara.Para;
                                    }
                                }
                                if (fs.Count == 0)
                                {
                                    fs.AddRange(
                                        FaizHelper.IcraDegiskenFaizHesapla(neden.TO_ALACAK_FAIZ_TIP_ID.Value,
                                                                           neden.FAIZ_BASLANGIC_TARIHI.Value,
                                                                           mFoy.TAKIP_TARIHI.Value,
                                                                           neden.ISLEME_KONAN_TUTAR,
                                                                           neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                                                                           mFoy.BIR_YIL_KAC_GUN)
                                    );
                                }

                                #endregion Mahsuplu FaizHesabý

                                neden.AV001_TI_BIL_FAIZCollection = new TList<AV001_TI_BIL_FAIZ>();
                                neden.AV001_TI_BIL_FAIZCollection.AddRange(fs);

                                faizler.AddRange(neden.AV001_TI_BIL_FAIZCollection);
                            }

                            #endregion FaizHesaplarý

                            #region DigerVergi Hesaplarý

                            if (neden.KKDV_HESAPLANSIN)
                            {
                                FaizHelper.IcraFaizUzerineDigerVergiHesapla(DigerVergiTuru.KKDF,
                                                                            neden.AV001_TI_BIL_FAIZCollection,
                                                                            mFoy.TAKIP_TARIHI.Value);
                            }
                            if (neden.OIV_HESAPLANSIN)
                            {
                                FaizHelper.IcraFaizUzerineDigerVergiHesapla(DigerVergiTuru.ÖÝV,
                                                                            neden.AV001_TI_BIL_FAIZCollection,
                                                                            mFoy.TAKIP_TARIHI.Value);
                            }
                            if (neden.BSMV_HESAPLANSIN && BsmvKontrol(neden))
                            {
                                FaizHelper.IcraFaizUzerineDigerVergiHesapla(DigerVergiTuru.BSMV,
                                                                            neden.AV001_TI_BIL_FAIZCollection,
                                                                            mFoy.TAKIP_TARIHI.Value);
                            }
                            if (neden.KDV_HESAPLANSIN && neden.KDV_TIP_ID.HasValue)
                            {
                                FaizHelper.IcraFaizUzerineKDVHesapla(neden.KDV_TIP_ID.Value, neden.AV001_TI_BIL_FAIZCollection,
                                                                     mFoy.TAKIP_TARIHI.Value);
                            }

                            #endregion DigerVergi Hesaplarý
                        }
                    }
                    else if (faizler.Count < 1) //HESAPLANMIÞ FAÝZ KALEMÝ OLUÞTURMA
                    {
                        // ToDo :  FAIZ_BASLANGIC_TARIHI null gelirse hata patlatýyor (gkn)

                        AV001_TI_BIL_FAIZ fz = FaizHelper.IcraFaizKalemiGetir(9, mFoy.FAIZ_BASLANGIC_TARIHI.Value,
                                                                              mFoy.TAKIP_TARIHI.Value,
                                                                              mFoy.HESAPLANMIS_FAIZ.Value,
                                                                              mFoy.HESAPLANMIS_FAIZ_DOVIZ_ID.Value,
                                                                              mFoy.BIR_YIL_KAC_GUN, 0);
                        /*
                        FaizHelper.IcraSabitFaizHesapla(9, faiz.FAIZ_BASLANGIC_TARIHI,
                                                        faiz.FAIZ_BITIS_TARIHI.Value,
                                                        trf.SORUMLU_OLUNAN_MIKTAR.Value,
                                                        trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.Value,
                                                        myFoy.BIR_YIL_KAC_GUN, faiz.FAIZ_ORANI);
                        */

                        neden.AV001_TI_BIL_FAIZCollection = new TList<AV001_TI_BIL_FAIZ>();
                        fz.KKDF_TUTARI = mFoy.HESAPLANMIS_KKDF ?? 0;
                        fz.KKDF_DOVIZ_ID = mFoy.HESAPLANMIS_KKDF_DOVIZ_ID ?? 1;
                        fz.KDV_TUTARI = mFoy.HESAPLANMIS_KDV ?? 0;
                        fz.KDV_DOVIZ_ID = mFoy.HESAPLANMIS_KDV_DOVIZ_ID ?? 1;
                        fz.BSMV_TUTARI = mFoy.HESAPLANMIS_BSMV ?? 0;
                        fz.BSMV_DOVIZ_ID = mFoy.HESAPLANMIS_BSMV_DOVIZ_ID ?? 1;
                        fz.OIV_TUTARI = mFoy.HESAPLANMIS_OIV ?? 0;
                        fz.OIV_DOVIZ_ID = mFoy.HESAPLANMIS_OIV_DOVIZ_ID ?? 1;
                        neden.AV001_TI_BIL_FAIZCollection.Add(fz);
                        faizler.AddRange(neden.AV001_TI_BIL_FAIZCollection);
                    }

                DovizHelper.GetMerkezBankasiBilgisi(neden.ALACAK_NEDEN_KOD_ID);

                #region Çek komisyon Tazminat

                if (neden.ALACAK_NEDEN_KOD_ID.HasValue &&
                    DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(
                        neden.ALACAK_NEDEN_KOD_ID.Value).ALACAK_NEDENI == "ÇEK")
                {
                    neden.CEK_TAZMINATI = (decimal)neden.CEK_TAZMINATI_ORANI * neden.ISLEME_KONAN_TUTAR / 100;
                    neden.CEK_TAZMINATI_DOVIZ_ID = neden.ISLEME_KONAN_TUTAR_DOVIZ_ID;
                    neden.KOMISYONU = (decimal)neden.KOMISYONU_ORANI *
                                      DovizHelper.CevirYTL(neden.ISLEME_KONAN_TUTAR,
                                                           neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                                                           mFoy.TAKIP_TARIHI.Value, neden.ALACAK_NEDEN_KOD_ID) / 100;
                    neden.KOMISYONU_DOVIZ_ID = 1; //YTL
                    toplamCekKomisyonu += neden.KOMISYONU;
                    if (neden.CEK_TAZMINATI_DOVIZ_ID.HasValue)
                        if (dicCekTazminati.ContainsKey(neden.CEK_TAZMINATI_DOVIZ_ID.Value))
                            dicCekTazminati[neden.CEK_TAZMINATI_DOVIZ_ID.Value] += neden.CEK_TAZMINATI;
                        else
                            dicCekTazminati.Add(neden.CEK_TAZMINATI_DOVIZ_ID.Value, neden.CEK_TAZMINATI);
                }

                #endregion Çek komisyon Tazminat

                #region IhtarGideriProtesto

                if (neden.PROTESTO_GIDERI_DOVIZ_ID.HasValue && neden.PROTESTO_GIDERI > 0)
                    toplamProtestoGideri +=
                        DovizHelper.CevirYTL(neden.PROTESTO_GIDERI, neden.PROTESTO_GIDERI_DOVIZ_ID.Value,
                                             mFoy.TAKIP_TARIHI.Value, neden.ALACAK_NEDEN_KOD_ID);
                if (neden.IHTAR_GIDERI_DOVIZ_ID.HasValue && neden.IHTAR_GIDERI > 0)
                    toplamIhtarGideri +=
                        DovizHelper.CevirYTL(neden.IHTAR_GIDERI, neden.IHTAR_GIDERI_DOVIZ_ID.Value,
                                             mFoy.TAKIP_TARIHI.Value, neden.ALACAK_NEDEN_KOD_ID);

                #endregion IhtarGideriProtesto

                #region DovizIslemleri(HesaplamaModu)

                switch (neden.HESAPLAMA_MODU)
                {
                    case 1:
                        nVadeTarihindeYTL++;
                        break;

                    case 2:
                        nTakipTarihindeYTL++;
                        break;

                    case 3:
                        nOdemeTarihindeYTL++;
                        break;

                    default:
                        break;
                }

                #endregion DovizIslemleri(HesaplamaModu)

                #endregion donüyoruz
            }
            #region Tum Foydeki Vergilerin Hesaplanmasý (BSMV,KKDF,OIV,KDV)

            foreach (AV001_TI_BIL_FAIZ faiz in faizler)
            {
                faiz.FAIZ_KALEM_ID = 1; //ASIL ALACAK
            }
            TList<AV001_TI_BIL_FAIZ> toOzelTutarFaizleri = FaizHelper.OzelTutarFaizHesapla(mFoy, Takip.Oncesi);
            mFoy.AV001_TI_BIL_FAIZCollection.AddRange(toOzelTutarFaizleri);
            faizler.AddRange(toOzelTutarFaizleri);
            ParaVeDovizId toplamBSMVParaVeDoviz = new ParaVeDovizId();
            ParaVeDovizId toplamKKDFParaVeDoviz = new ParaVeDovizId();
            ParaVeDovizId toplamOIVParaVeDoviz = new ParaVeDovizId();
            ParaVeDovizId toplamKDVParaVeDoviz = new ParaVeDovizId();
            foreach (var faiz in faizler)
            {
                if (dicIslemisFaiz.ContainsKey(faiz.FAIZ_TUTARI_DOVIZ_ID.Value))
                    dicIslemisFaiz[faiz.FAIZ_TUTARI_DOVIZ_ID.Value] += faiz.FAIZ_TUTARI;
                else
                    dicIslemisFaiz.Add(faiz.FAIZ_TUTARI_DOVIZ_ID.Value, faiz.FAIZ_TUTARI);

                faiz.FAIZ_KALEM_ID = 1;
                faiz.FAIZ_TAKIPDEN_ONCE_MI = 1;

                toplamBSMVParaVeDoviz = ParaVeDovizId.Topla(toplamBSMVParaVeDoviz,
                    new ParaVeDovizId((faiz.BSMV_TUTARI < 0) ? 0 : faiz.BSMV_TUTARI, faiz.BSMV_DOVIZ_ID));
                toplamKKDFParaVeDoviz = ParaVeDovizId.Topla(toplamKKDFParaVeDoviz,
                    new ParaVeDovizId((faiz.KKDF_DOVIZ_ID < 0) ? 0 : faiz.KKDF_TUTARI, faiz.KKDF_DOVIZ_ID));
                toplamOIVParaVeDoviz = ParaVeDovizId.Topla(toplamOIVParaVeDoviz,
                    new ParaVeDovizId((faiz.OIV_TUTARI < 0) ? 0 : faiz.OIV_TUTARI, faiz.OIV_DOVIZ_ID));
                toplamKDVParaVeDoviz = ParaVeDovizId.Topla(toplamKDVParaVeDoviz,
                    new ParaVeDovizId((faiz.KDV_TUTARI < 0) ? 0 : faiz.KDV_TUTARI, faiz.KDV_DOVIZ_ID));
            }

            #region <CC-20090708>

            // yukardAKÝ YAPI HAZIRLANDIÐINDAN KAPATILMIÞTIR
            //foreach (AV001_TI_BIL_FAIZ faiz in faizler)
            //{
            //    if (dicIslemisFaiz.ContainsKey(faiz.FAIZ_TUTARI_DOVIZ_ID.Value))
            //        dicIslemisFaiz[faiz.FAIZ_TUTARI_DOVIZ_ID.Value] += faiz.FAIZ_TUTARI;
            //    else
            //        dicIslemisFaiz.Add(faiz.FAIZ_TUTARI_DOVIZ_ID.Value, faiz.FAIZ_TUTARI);

            //    faiz.FAIZ_KALEM_ID = 1; //ASIL ALACAK
            //    //toplamBSMV += (faiz.BSMV_TUTARI < 0) ? 0 : faiz.BSMV_TUTARI;
            //    //toplamKKDF += (faiz.KKDF_TUTARI < 0) ? 0 : faiz.KKDF_TUTARI;
            //   // toplamOIV += (faiz.OIV_TUTARI < 0) ? 0 : faiz.OIV_TUTARI;
            //    toplamKDV += (faiz.KDV_TUTARI < 0) ? 0 : faiz.KDV_TUTARI;
            //    faiz.FAIZ_TAKIPDEN_ONCE_MI = 1; //TODO : AV001_TI_BIL_FAIZ  tablosunda ilgili alan bit olarak ayarlandýktan sonra gerekli deðiþiþklik yapýlacak..
            //}

            #endregion <CC-20090708>

            mFoy.KKDV_TO = toplamKKDFParaVeDoviz.Para;
            mFoy.OIV_TO = toplamOIVParaVeDoviz.Para;
            mFoy.BSMV_TO = toplamBSMVParaVeDoviz.Para;
            mFoy.KDV_TO = toplamKDVParaVeDoviz.Para;
            mFoy.KKDV_TO_DOVIZ_ID = toplamKKDFParaVeDoviz.DovizId;
            mFoy.OIV_TO_DOVIZ_ID = toplamOIVParaVeDoviz.DovizId;
            mFoy.BSMV_TO_DOVIZ_ID = toplamBSMVParaVeDoviz.DovizId;
            mFoy.KDV_TO_DOVIZ_ID = toplamBSMVParaVeDoviz.DovizId;
            mFoy.CEK_KOMISYONU = toplamCekKomisyonu;
            mFoy.CEK_KOMISYONU_DOVIZ_ID = 1;

            #endregion Tum Foydeki Vergilerin Hesaplanmasý (BSMV,KKDF,OIV,KDV)

            #region IslemisFaiz & CekTazminati

            ParaVeDovizId.BosOlanAlanlariSil(dicIslemisFaiz);
            ParaVeDovizId.BosOlanAlanlariSil(dicCekTazminati);
            //Eðer sadece Ödeme tarihinde YTL seçilmiþ ise
            if (nVadeTarihindeYTL == 0 && nTakipTarihindeYTL == 0)
            {
                #region IslemisFaiz

                //Eðer birden fazla döviz tipi var ise
                if (dicIslemisFaiz.Count > 1)
                {
                    decimal ytlToplam = 0;
                    foreach (KeyValuePair<int, decimal> pair in dicIslemisFaiz)
                    {
                        if (pair.Key == 1)
                            ytlToplam += pair.Value;
                        else if (pair.Key > 1)
                        {
                            //Dövizi bugünkü kurdan çeviriyoruz
                            ytlToplam += DovizHelper.CevirYTL(pair.Value, pair.Key, DateTime.Today);
                        }
                    }
                    //Hesaplanan deðerleri foy nesnesine yazýyoruz
                    mFoy.ISLEMIS_FAIZ = (ytlToplam < 0) ? 0 : ytlToplam;
                    //YTL için 1 veriyoruz
                    mFoy.ISLEMIS_FAIZ_DOVIZ_ID = 1;
                }
                else
                {
                    //Tek bir deðer olduðu için
                    Dictionary<int, decimal>.Enumerator num = dicIslemisFaiz.GetEnumerator();
                    //Tek olan deðere ulaþýyor
                    num.MoveNext();
                    //bunun Doviztip ve miktar bilgilerini foy nesnesine yazýyoruz.
                    mFoy.ISLEMIS_FAIZ = (num.Current.Value < 0) ? 0 : num.Current.Value;
                    mFoy.ISLEMIS_FAIZ_DOVIZ_ID = num.Current.Key;
                    if (num.Current.Key == 0)
                    {
                        mFoy.ISLEMIS_FAIZ_DOVIZ_ID = 1;
                    }
                }

                #endregion IslemisFaiz

                #region CekTazminati(Karsiliksiz)

                //Eðer birden fazla döviz tipi var ise
                if (dicCekTazminati.Count > 1)
                {
                    decimal ytlToplam = 0;
                    foreach (KeyValuePair<int, decimal> pair in dicCekTazminati)
                    {
                        if (pair.Key == 1)
                            ytlToplam += pair.Value;
                        else if (pair.Key > 1)
                        {
                            //Dövizi bugünkü kurdan çeviriyoruz
                            ytlToplam += DovizHelper.CevirYTL(pair.Value, pair.Key, DateTime.Today);
                        }
                    }
                    mFoy.KARSILIKSIZ_CEK_TAZMINATI = ytlToplam;
                    mFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = 1;
                }
                else
                {
                    //Tek bir deðer olduðu için
                    Dictionary<int, decimal>.Enumerator num = dicCekTazminati.GetEnumerator();
                    //Tek olan deðere ulaþýyor
                    num.MoveNext();
                    //bunun Doviztip ve miktar bilgilerini foy nesnesine yazýyoruz.
                    mFoy.KARSILIKSIZ_CEK_TAZMINATI = num.Current.Value;
                    mFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = num.Current.Key;
                    if (num.Current.Key == 0)
                    {
                        mFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = 1;
                    }
                }

                #endregion CekTazminati(Karsiliksiz)
            }
            //Diðer tüm olasýlýklar için
            else
            {
                decimal ytlToplam = 0;
                decimal cekYtlToplam = 0;
                foreach (AV001_TI_BIL_ALACAK_NEDEN neden in mFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    #region IslemisFaiz

                    foreach (AV001_TI_BIL_FAIZ faiz in neden.AV001_TI_BIL_FAIZCollection)
                    {
                        switch (neden.HESAPLAMA_MODU)
                        {
                            case 1:
                                //VadeTarihindeYTL
                                if (faiz.FAIZ_TUTARI_DOVIZ_ID.HasValue && neden.VADE_TARIHI.HasValue)
                                {
                                    ytlToplam +=
                                        DovizHelper.CevirYTL(faiz.FAIZ_TUTARI, faiz.FAIZ_TUTARI_DOVIZ_ID.Value,
                                                             neden.VADE_TARIHI.Value.Date);
                                }
                                break;

                            case 2:
                                //TakipTarihindeYTL
                                if (faiz.FAIZ_TUTARI_DOVIZ_ID.HasValue && mFoy.TAKIP_TARIHI.HasValue)
                                {
                                    ytlToplam +=
                                        DovizHelper.CevirYTL(faiz.FAIZ_TUTARI, faiz.FAIZ_TUTARI_DOVIZ_ID.Value,
                                                             mFoy.TAKIP_TARIHI.Value.Date);
                                }
                                break;

                            case 3:
                                //OdemeTarihindeYTL
                                if (faiz.FAIZ_TUTARI_DOVIZ_ID.HasValue)
                                {
                                    ytlToplam +=
                                        DovizHelper.CevirYTL(faiz.FAIZ_TUTARI, faiz.FAIZ_TUTARI_DOVIZ_ID.Value,
                                                             DateTime.Today);
                                }
                                break;

                            default:
                                break;
                        }
                    }

                    #endregion IslemisFaiz

                    #region CekTazminati(Karsiliksiz)

                    switch (neden.HESAPLAMA_MODU)
                    {
                        case 1:
                            //VadeTarihindeYTL
                            if (neden.CEK_TAZMINATI_DOVIZ_ID.HasValue && neden.VADE_TARIHI.HasValue)
                            {
                                DovizHelper.GetMerkezBankasiBilgisi(neden.ALACAK_NEDEN_KOD_ID);
                                cekYtlToplam +=
                                    DovizHelper.CevirYTL(neden.CEK_TAZMINATI, neden.CEK_TAZMINATI_DOVIZ_ID.Value,
                                                         neden.VADE_TARIHI.Value.Date, neden.ALACAK_NEDEN_KOD_ID);
                            }
                            break;

                        case 2:
                            //TakipTarihindeYTL
                            if (neden.CEK_TAZMINATI_DOVIZ_ID.HasValue && mFoy.TAKIP_TARIHI.HasValue)
                            {
                                DovizHelper.GetMerkezBankasiBilgisi(neden.ALACAK_NEDEN_KOD_ID);
                                cekYtlToplam +=
                                    DovizHelper.CevirYTL(neden.CEK_TAZMINATI, neden.CEK_TAZMINATI_DOVIZ_ID.Value,
                                                         mFoy.TAKIP_TARIHI.Value.Date, neden.ALACAK_NEDEN_KOD_ID);
                            }
                            break;

                        case 3:
                            //OdemeTarihindeYTL
                            if (neden.CEK_TAZMINATI_DOVIZ_ID.HasValue)
                            {
                                DovizHelper.GetMerkezBankasiBilgisi(neden.ALACAK_NEDEN_KOD_ID);
                                cekYtlToplam +=
                                    DovizHelper.CevirYTL(neden.CEK_TAZMINATI, neden.CEK_TAZMINATI_DOVIZ_ID.Value,
                                                         DateTime.Today, neden
                                                         .ALACAK_NEDEN_KOD_ID);
                            }
                            break;

                        default:
                            break;
                    }

                    #endregion CekTazminati(Karsiliksiz)
                }

                foreach (AV001_TI_BIL_FAIZ faiz in toOzelTutarFaizleri)
                {
                    if (faiz.FAIZ_BASLANGIC_TARIHI.HasValue && faiz.FAIZ_BASLANGIC_TARIHI.Value < mFoy.TAKIP_TARIHI)
                    {
                        switch (3)
                        {
                            case 3:
                                //OdemeTarihindeYTL
                                if (faiz.FAIZ_TUTARI_DOVIZ_ID.HasValue)
                                {
                                    ytlToplam +=
                                        DovizHelper.CevirYTL(faiz.FAIZ_TUTARI, faiz.FAIZ_TUTARI_DOVIZ_ID.Value,
                                                             DateTime.Today);
                                }
                                break;

                            default:
                        }
                    }
                }
                mFoy.KARSILIKSIZ_CEK_TAZMINATI = cekYtlToplam;
                mFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = 1;
                mFoy.ISLEMIS_FAIZ = (ytlToplam < 0) ? 0 : ytlToplam;
                mFoy.ISLEMIS_FAIZ_DOVIZ_ID = 1;
            }

            #endregion IslemisFaiz & CekTazminati
        }

        public static void HesaplaTakipOncesiOdeme(AV001_TI_BIL_FOY mFoy)
        {
            HesaplaTakipOncesiOdeme(mFoy, new TList<AV001_TI_BIL_BORCLU_ODEME>());
        }

        public static void HesaplaTakipOncesiOdeme(AV001_TI_BIL_FOY mFoy, TList<AV001_TI_BIL_BORCLU_ODEME> digerODemeler)
        {
            Dictionary<int, decimal> dicIHOdeme = new Dictionary<int, decimal>();
            Dictionary<int, decimal> dicToOdeme = new Dictionary<int, decimal>();
            //foreach (TDI_KOD_DOVIZ_TIP tip in DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetAll())
            //{
            //    dicIHOdeme.Add(tip.ID, 0);
            //    dicToOdeme.Add(tip.ID, 0);
            //}

            TList<AV001_TI_BIL_BORCLU_ODEME> liste = new TList<AV001_TI_BIL_BORCLU_ODEME>();

            liste.AddRange(mFoy.AV001_TI_BIL_BORCLU_ODEMECollection);
            liste.AddRange(digerODemeler);

            foreach (AV001_TI_BIL_BORCLU_ODEME odeme in liste)
            {
                if (odeme.ODEME_TARIHI <= mFoy.TAKIP_TARIHI.Value)//Takip öncesi
                {
                    if (odeme.IHTIYATI_HACIZDE_MI)
                    {
                        if (dicIHOdeme.ContainsKey(odeme.ODEME_MIKTAR_DOVIZ_ID.HasValue ? odeme.ODEME_MIKTAR_DOVIZ_ID.Value : 1))
                            dicIHOdeme[odeme.ODEME_MIKTAR_DOVIZ_ID.HasValue ? odeme.ODEME_MIKTAR_DOVIZ_ID.Value : 1] += odeme.ODEME_MIKTAR.HasValue ? odeme.ODEME_MIKTAR.Value : 0;
                        else
                            dicIHOdeme.Add(odeme.ODEME_MIKTAR_DOVIZ_ID.HasValue ? odeme.ODEME_MIKTAR_DOVIZ_ID.Value : 1, odeme.ODEME_MIKTAR.HasValue ? odeme.ODEME_MIKTAR.Value : 0);
                    }
                    else
                    {
                        if (dicToOdeme.ContainsKey(odeme.ODEME_MIKTAR_DOVIZ_ID.HasValue ? odeme.ODEME_MIKTAR_DOVIZ_ID.Value : 1))
                            dicToOdeme[odeme.ODEME_MIKTAR_DOVIZ_ID.HasValue ? odeme.ODEME_MIKTAR_DOVIZ_ID.Value : 1] += odeme.ODEME_MIKTAR.HasValue ? odeme.ODEME_MIKTAR.Value : 0;
                        else
                            dicToOdeme.Add(odeme.ODEME_MIKTAR_DOVIZ_ID.HasValue ? odeme.ODEME_MIKTAR_DOVIZ_ID.Value : 1, odeme.ODEME_MIKTAR.HasValue ? odeme.ODEME_MIKTAR.Value : 0);
                    }
                }
            }
            //ParaVeDovizId.BosOlanAlanlariSil(dicIHOdeme);
            //ParaVeDovizId.BosOlanAlanlariSil(dicToOdeme);

            if (dicToOdeme.Count > 1)
            {
                foreach (AV001_TI_BIL_BORCLU_ODEME odeme in liste)
                {
                    if (odeme.ODEME_TARIHI <= mFoy.TAKIP_TARIHI.Value)//Takip öncesi
                    {
                        if (!odeme.IHTIYATI_HACIZDE_MI)
                        {
                            mFoy.TO_ODEME_TOPLAMI += DovizHelper.CevirYTL(odeme.ODEME_MIKTAR,
                                                                              odeme.ODEME_MIKTAR_DOVIZ_ID,
                                                                              odeme.ODEME_TARIHI);
                        }
                    }
                }
                mFoy.TO_ODEME_TOPLAMI_DOVIZ_ID = 1; //YTL
            }
            else
            {
                //Tek bir deðer olduðu için
                Dictionary<int, decimal>.Enumerator num = dicToOdeme.GetEnumerator();
                //Tek olan deðere ulaþýyor
                num.MoveNext();
                //bunun Doviztip ve miktar bilgilerini foy nesnesine yazýyoruz.
                mFoy.TO_ODEME_TOPLAMI = num.Current.Value;
                mFoy.TO_ODEME_TOPLAMI_DOVIZ_ID = num.Current.Key;
                if (mFoy.TO_ODEME_TOPLAMI_DOVIZ_ID == 0)
                    mFoy.TO_ODEME_TOPLAMI_DOVIZ_ID = 1;
            }
            mFoy.TO_ODEME_TOPLAMI = mFoy.TO_ODEME_TOPLAMI * -1;
            if (dicIHOdeme.Count > 1)
            {
                foreach (AV001_TI_BIL_BORCLU_ODEME odeme in liste)
                {
                    if (odeme.ODEME_TARIHI <= mFoy.TAKIP_TARIHI.Value)//Takip öncesi
                    {
                        if (odeme.IHTIYATI_HACIZDE_MI)
                        {
                            mFoy.IT_HACIZDE_ODENEN += DovizHelper.CevirYTL(odeme.ODEME_MIKTAR,
                                                                           odeme.ODEME_MIKTAR_DOVIZ_ID,
                                                                           odeme.ODEME_TARIHI);
                        }
                    }
                }

                mFoy.IT_HACIZDE_ODENEN_DOVIZ_ID = 1; //YTL
            }
            else
            {
                //Tek bir deðer olduðu için
                Dictionary<int, decimal>.Enumerator num = dicIHOdeme.GetEnumerator();
                //Tek olan deðere ulaþýyor
                num.MoveNext();
                //bunun Doviztip ve miktar bilgilerini foy nesnesine yazýyoruz.
                mFoy.IT_HACIZDE_ODENEN = num.Current.Value;
                mFoy.IT_HACIZDE_ODENEN_DOVIZ_ID = num.Current.Key;
                if (num.Current.Key == 0)
                    mFoy.IT_HACIZDE_ODENEN_DOVIZ_ID = 1;
            }
            mFoy.IT_HACIZDE_ODENEN = mFoy.IT_HACIZDE_ODENEN * -1;
            decimal mFoy_ToOdemeMahsup = 0;
            if (mFoy.IT_HACIZDE_ODENEN_DOVIZ_ID.HasValue && mFoy.TO_ODEME_TOPLAMI_DOVIZ_ID.HasValue &&
                mFoy.TAKIP_TARIHI.HasValue)
                mFoy_ToOdemeMahsup =
                    DovizHelper.CevirYTL(mFoy.IT_HACIZDE_ODENEN, mFoy.IT_HACIZDE_ODENEN_DOVIZ_ID.Value,
                                         mFoy.TAKIP_TARIHI.Value) +
                    DovizHelper.CevirYTL(mFoy.TO_ODEME_TOPLAMI, mFoy.TO_ODEME_TOPLAMI_DOVIZ_ID.Value,
                                         mFoy.TAKIP_TARIHI.Value);
            if (mFoy.MAHSUP_TOPLAMI_DOVIZ_ID.HasValue && mFoy.TAKIP_TARIHI.HasValue)
                mFoy.TO_ODEME_MAHSUP_TOPLAMI = mFoy_ToOdemeMahsup +
                                                DovizHelper.CevirYTL(mFoy.MAHSUP_TOPLAMI,
                                                                     mFoy.MAHSUP_TOPLAMI_DOVIZ_ID.Value,
                                                                     mFoy.TAKIP_TARIHI.Value);
        }

        public static void HesaplaTaraf(AV001_TI_BIL_FOY mFoy)
        {
            //TODO: burda
            TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> taraflar = new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>();
            //glkTarafBazindaHesap.Properties.DataSource = taraflar;
            //ucIcraHesapCetveli1.MyTarafSource = taraflar;

            TList<AV001_TI_BIL_ALACAK_NEDEN> deposuzNedenler = GayriNakitleriCikar(mFoy);

            #region <CC-20090707>

            // taraflarýn countuna bakýldý
            //DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(deposuzNedenler, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>), typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>));

            #endregion <CC-20090707>

            foreach (AV001_TI_BIL_ALACAK_NEDEN ndn in deposuzNedenler)
            {
                #region <CC-20090707>

                // taraflarýn countuna bakýldý
                if (ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count <= 0)
                    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(ndn, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>), typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>));

                #endregion <CC-20090707>

                foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF trf in ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                {
                    ///<summary>
                    /// Üzerinde bulunulan alacak nedeninin Foy bazýndaki sorumluluk oraný
                    ///</summary>
                    ///<example>
                    /// Foy Asýl alacaðý 5000 TL ise ve alacak nedeninin iþleme konan miktarý
                    /// 2500 TL ise bu deðer 0.5 olacaktýr. Foy Asýl alacaðý Alacak nedenin
                    /// iþleme konan miktarýna eþitse yani Foy de tek bir alacak nedeni var ise
                    /// Bu deðer 1 olacaktýr.
                    ///</example>
                    double nedenSorumlulukOrani = 0;

                    #region Taraf Sorumluluk Oraný Hesapla (NedenSorumlulukOranýHesapla)

                    //Tarafýn çeþitli kalemlerdeki hesaplamalarda kullanýlan Neden Sorumluluk oranýný
                    //Hesaplýyoruz.
                    if (trf.SORUMLU_OLUNAN_MIKTAR == ndn.ISLEME_KONAN_TUTAR &&
                       trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID == ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID)
                    {
                        trf.SORUMLULUK_ORANI = 1;
                    }

                    else
                    {
                        //Tarafýn sorumluluk miktarýný hesaplamak için iþleme konan tutar ile
                        //Tarafýn Sorumluluk miktarýný oranlýyoruz. Deðerler takip tarihi üzerinden
                        //TL ye çevrilerek oranlanýr.
                        try
                        {
                            DovizHelper.GetMerkezBankasiBilgisi(trf);

                            trf.SORUMLULUK_ORANI = (double)(
                                                                DovizHelper.CevirYTL(trf.SORUMLU_OLUNAN_MIKTAR,
                                                                                     trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID
                                                                                         , mFoy.TAKIP_TARIHI.Value) /
                                                                DovizHelper.CevirYTL(ndn.ISLEME_KONAN_TUTAR,
                                                                                     ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                                                                                     mFoy.TAKIP_TARIHI.Value));
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("Attempted to divide by zero."))
                                trf.SORUMLULUK_ORANI = 0;

                            //ToDo : Ýnceleme altýna alýnacak
                        }
                    }
                    //Alacak nedeninin Foy bazýndaki sorumluluk oranýný hesaplýyoruz
                    if (ndn.ISLEME_KONAN_TUTAR == mFoy.ASIL_ALACAK &&
                        ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID == mFoy.ASIL_ALACAK_DOVIZ_ID)
                    {
                        nedenSorumlulukOrani = 1;
                    }
                    else
                    {
                        //Alacak nedeninin foy bazýndaki sorumluluk oranýný hesaplamak için
                        //Foy üzerindeki asýl alacak ile alacak nedeni üzerindeki iþleme konan
                        //tutarý oranlýyoruz.
                        if (mFoy.ASIL_ALACAK > 0)
                        {
                            DovizHelper.GetMerkezBankasiBilgisi(ndn.ALACAK_NEDEN_KOD_ID);

                            nedenSorumlulukOrani =
                                (double)
                                (DovizHelper.CevirYTL(ndn.ISLEME_KONAN_TUTAR, ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                                                      mFoy.TAKIP_TARIHI.Value, ndn.ALACAK_NEDEN_KOD_ID) /
                                 DovizHelper.CevirYTL(mFoy.ASIL_ALACAK, mFoy.ASIL_ALACAK_DOVIZ_ID,
                                                      mFoy.TAKIP_TARIHI.Value));
                        }
                    }

                    #endregion Taraf Sorumluluk Oraný Hesapla (NedenSorumlulukOranýHesapla)

                    ///<summary>
                    ///Taraf üzerindeki hesaplanacak olan faiz kalemlerinin tutulduðu liste
                    ///</summary>
                    DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepLoad(trf, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>));
                    TList<AV001_TI_BIL_FAIZ> faizler = new TList<AV001_TI_BIL_FAIZ>();
                    //Faiz hesabý yapýlmak üzere tüm Taraf_Faiz kalemleri üzerinde geziyoruz.

                    //Taraf üzerindeki faiz kalemleri koleksiyonu için yeni bir instance oluþturuluyor
                    trf.AV001_TI_BIL_FAIZCollection = new TList<AV001_TI_BIL_FAIZ>();
                    foreach (
                        AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ faiz in trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection)
                    {
                        //Üzerinde bulunduðumuz faiz kalemi için faiz hesabý yapýyoruz.

                        #region FaizHesaplarý

                        if (!ndn.FAIZ_YOK) // Eðer Faiz Yok iþaretli deðil ise
                        {
                            TList<AV001_TI_BIL_FAIZ> lstSuankiFaizler = new TList<AV001_TI_BIL_FAIZ>();
                            //Eðer Föye elle girilmiþ hesaplanmýþ faiz deðerleri yok ise
                            if (
                                !((mFoy.HESAPLANMIS_FAIZ.HasValue && mFoy.HESAPLANMIS_FAIZ.Value > 0) ||
                                  (mFoy.HESAPLANMIS_KKDF.HasValue && mFoy.HESAPLANMIS_KKDF.Value > 0) ||
                                  (mFoy.HESAPLANMIS_BSMV.HasValue && mFoy.HESAPLANMIS_BSMV.Value > 0) ||
                                  (mFoy.HESAPLANMIS_OIV.HasValue && mFoy.HESAPLANMIS_OIV.Value > 0) ||
                                  (mFoy.HESAPLANMIS_KDV.HasValue && mFoy.HESAPLANMIS_KDV.Value > 0)))
                            {
                                //Eðer faiz kalemi Özel Sabit Faiz cinsinden ise
                                if (faiz.SABIT_FAIZ ?? false)
                                {
                                    //Ýlgili kalemin faiz baþlangýç tarihi ve bitiþ tarihi arasýndaki
                                    //kalem üzerindeki sabit faiz oraný ile faiz hesabý yapýlýp fz listesine
                                    //atýlýyor.
                                    TList<AV001_TI_BIL_FAIZ> fz =
                                        FaizHelper.MahsupluFaizHesaplaTaraf(true, mFoy,
                                                                            MahsupAltKategori.Alacak_Neden,
                                                                            9,
                                                                            faiz.FAIZ_BASLANGIC_TARIHI.Value,
                                                                            faiz.FAIZ_BITIS_TARIHI ?? mFoy.SON_HESAP_TARIHI.Value,
                                                                            new ParaVeDovizId(
                                                                                trf.SORUMLU_OLUNAN_MIKTAR,
                                                                                trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID),
                                                                            FaizKalem.ASIL_ALACAK,
                                                                            faiz.FAIZ_ORANI.Value, trf);
                                    //FaizHelper.IcraSabitFaizHesapla(9, faiz.FAIZ_BASLANGIC_TARIHI,
                                    //                                faiz.FAIZ_BITIS_TARIHI.Value,
                                    //                                trf.SORUMLU_OLUNAN_MIKTAR.Value,
                                    //                                trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.Value,
                                    //                                mFoy.BIR_YIL_KAC_GUN, faiz.FAIZ_ORANI);

                                    //Hesaplanmýþ olan faiz detay kalemleri  taraf'a baðlý faiz detay tablosuna atýlýyor
                                    trf.AV001_TI_BIL_FAIZCollection.AddRange(fz);
                                    //genel faizler koleksiyonuna hesaplanan faiz detay kalemleri ekleniyor.
                                    faizler.AddRange(fz);
                                    lstSuankiFaizler.AddRange(fz);
                                }
                                else //Deðiþken Faiz
                                {
                                    //Ýlgili kalemin faiz baþlangýç tarihi ve bitiþ tarihi arasýndaki
                                    //kalem üzerindeki deðiþken faiz tipi ile kademeli faiz hesabý yapýlýp fz listesine
                                    //atýlýyor.
                                    TList<AV001_TI_BIL_FAIZ> fs =
                                        FaizHelper.MahsupluFaizHesaplaTaraf(false, mFoy, MahsupAltKategori.Alacak_Neden,
                                                                           faiz.FAIZ_TIP_ID.HasValue ? faiz.FAIZ_TIP_ID.Value : 0,
                                                                            faiz.FAIZ_BASLANGIC_TARIHI.Value,
                                                                            faiz.FAIZ_BITIS_TARIHI ?? mFoy.SON_HESAP_TARIHI.Value,
                                                                            new ParaVeDovizId(
                                                                                trf.SORUMLU_OLUNAN_MIKTAR,
                                                                                trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID),
                                                                            FaizKalem.ASIL_ALACAK, faiz.FAIZ_ORANI.Value, trf);

                                    //FaizHelper.IcraDegiskenFaizHesapla(faiz.FAIZ_TIP_ID.Value,
                                    //faiz.FAIZ_BASLANGIC_TARIHI,
                                    //faiz.FAIZ_BITIS_TARIHI.Value,
                                    //trf.SORUMLU_OLUNAN_MIKTAR.Value,
                                    //trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.Value,
                                    //mFoy.BIR_YIL_KAC_GUN);

                                    //Hesaplanmýþ olan faiz detay kalemleri  taraf'a baðlý faiz detay tablosuna atýlýyor
                                    trf.AV001_TI_BIL_FAIZCollection.AddRange(fs);
                                    //genel faizler koleksiyonuna hesaplanan faiz detay kalemleri ekleniyor.
                                    faizler.AddRange(fs);
                                    lstSuankiFaizler.AddRange(fs);
                                }

                                //Faiz kalemi üzerine hesaplanan Diger vergilerin hesaplanmasý

                                #region DigerVergi Hesaplarý

                                if (ndn.KKDV_HESAPLANSIN)
                                {
                                    FaizHelper.IcraFaizUzerineDigerVergiHesapla(DigerVergiTuru.KKDF,
                                                                                lstSuankiFaizler,
                                                                                mFoy.TAKIP_TARIHI.Value);
                                }
                                if (ndn.OIV_HESAPLANSIN)
                                {
                                    FaizHelper.IcraFaizUzerineDigerVergiHesapla(DigerVergiTuru.ÖÝV,
                                                                                lstSuankiFaizler,
                                                                                mFoy.TAKIP_TARIHI.Value);
                                }
                                if (ndn.BSMV_HESAPLANSIN && BsmvKontrol(ndn))
                                {
                                    FaizHelper.IcraFaizUzerineDigerVergiHesapla(DigerVergiTuru.BSMV,
                                                                                lstSuankiFaizler,
                                                                                mFoy.TAKIP_TARIHI.Value);
                                }
                                if (ndn.KDV_HESAPLANSIN && ndn.KDV_TIP_ID.HasValue)
                                {
                                    FaizHelper.IcraFaizUzerineKDVHesapla(ndn.KDV_TIP_ID.Value,
                                                                         lstSuankiFaizler,
                                                                         mFoy.TAKIP_TARIHI.Value);
                                }

                                #endregion DigerVergi Hesaplarý
                            }
                            else // Hesaplanmýþ faiz kalemlerinin sorumluluða göre faiz kalemi olarak oluþturulup tarafýn faiz detay koleksiyonuna eklenmesi
                            {
                                AV001_TI_BIL_FAIZ fz = FaizHelper.IcraFaizKalemiGetir(9, ndn.FAIZ_BASLANGIC_TARIHI.Value,
                                                                                      mFoy.TAKIP_TARIHI.Value,
                                                                                      mFoy.HESAPLANMIS_FAIZ.Value *
                                                                                      (decimal)nedenSorumlulukOrani *
                                                                                      (decimal)trf.SORUMLULUK_ORANI,
                                                                                      mFoy.HESAPLANMIS_FAIZ_DOVIZ_ID ?? 1,
                                                                                      mFoy.BIR_YIL_KAC_GUN, 0);
                                /*
                                FaizHelper.IcraSabitFaizHesapla(9, faiz.FAIZ_BASLANGIC_TARIHI,
                                                                faiz.FAIZ_BITIS_TARIHI.Value,
                                                                trf.SORUMLU_OLUNAN_MIKTAR.Value,
                                                                trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.Value,
                                                                mFoy.BIR_YIL_KAC_GUN, faiz.FAIZ_ORANI);
                                */
                                trf.AV001_TI_BIL_FAIZCollection = new TList<AV001_TI_BIL_FAIZ>();
                                fz.KKDF_TUTARI = mFoy.HESAPLANMIS_KKDF ?? 0 * (decimal)nedenSorumlulukOrani *
                                                 (decimal)trf.SORUMLULUK_ORANI;
                                fz.KKDF_DOVIZ_ID = mFoy.HESAPLANMIS_KKDF_DOVIZ_ID ?? 1;
                                fz.KDV_TUTARI = mFoy.HESAPLANMIS_KDV ?? 0 * (decimal)nedenSorumlulukOrani *
                                                (decimal)trf.SORUMLULUK_ORANI;
                                fz.KDV_DOVIZ_ID = mFoy.HESAPLANMIS_KDV_DOVIZ_ID ?? 1;
                                fz.BSMV_TUTARI = mFoy.HESAPLANMIS_BSMV ?? 0 * (decimal)nedenSorumlulukOrani *
                                                 (decimal)trf.SORUMLULUK_ORANI;
                                fz.BSMV_DOVIZ_ID = mFoy.HESAPLANMIS_BSMV_DOVIZ_ID ?? 1;
                                fz.OIV_TUTARI = mFoy.HESAPLANMIS_OIV ?? 0 * (decimal)nedenSorumlulukOrani *
                                                (decimal)trf.SORUMLULUK_ORANI;
                                fz.OIV_DOVIZ_ID = mFoy.HESAPLANMIS_OIV_DOVIZ_ID ?? 1;
                                trf.AV001_TI_BIL_FAIZCollection.Add(fz);
                                faizler.AddRange(trf.AV001_TI_BIL_FAIZCollection);
                            }
                        }

                        #endregion FaizHesaplarý
                    }

                    #region Çek komisyon Tazminat

                    if (
                        DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(ndn.ALACAK_NEDEN_KOD_ID.Value).ALACAK_NEDENI ==
                        "ÇEK")
                    {
                        trf.CEK_TAZMINATI = (decimal)trf.CEK_TAZMINATI_ORANI * trf.SORUMLU_OLUNAN_MIKTAR / 100;
                        trf.CEK_TAZMINATI_DOVIZ_ID = trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID;

                        DovizHelper.GetMerkezBankasiBilgisi(trf);

                        trf.KOMISYONU = (decimal)trf.KOMISYONU_ORANI *
                                        DovizHelper.CevirYTL(trf.SORUMLU_OLUNAN_MIKTAR,
                                                             trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID,
                                                             mFoy.TAKIP_TARIHI.Value) / 100;
                        trf.KOMISYONU_DOVIZ_ID = 1; //YTL
                    }

                    #endregion Çek komisyon Tazminat

                    #region Taraftaki Vergilerin Hesaplanmasý (BSMV,KKDF,OIV,KDV)

                    decimal toplamKKDF = 0;
                    decimal toplamOIV = 0;
                    decimal toplamBSMV = 0;
                    decimal toplamKDV = 0;
                    decimal toplamFaiz = 0;
                    decimal toplamTsKKDF = 0;
                    decimal toplamTsOIV = 0;
                    decimal toplamTsBSMV = 0;
                    decimal toplamTsKDV = 0;
                    decimal toplamTsFaiz = 0;
                    //Tüm faiz kalemleri üzerinde gezilerek toplamlarýn hesaplanmasý
                    foreach (AV001_TI_BIL_FAIZ faiz in faizler)
                    {
                        //Aþþaðýdaki koþul < iken <= hale getirilmiþtir (yy)
                        if (faiz.FAIZ_BITIS_TARIHI.Value <= mFoy.TAKIP_TARIHI.Value)
                        {
                            toplamFaiz += faiz.FAIZ_TUTARI;

                            faiz.FAIZ_KALEM_ID = 1; //ASIL ALACAK TODO:Deðiþebilir
                            toplamBSMV += faiz.BSMV_TUTARI;
                            toplamKKDF += faiz.KKDF_TUTARI;
                            toplamOIV += faiz.OIV_TUTARI;
                            toplamKDV += faiz.KDV_TUTARI;
                        }
                        else
                        {
                            toplamTsFaiz += faiz.FAIZ_TUTARI;

                            faiz.FAIZ_KALEM_ID = 1; //ASIL ALACAK TODO:Deðiþebilir
                            toplamTsBSMV += faiz.BSMV_TUTARI;
                            toplamTsKKDF += faiz.KKDF_TUTARI;
                            toplamTsOIV += faiz.OIV_TUTARI;
                            toplamTsKDV += faiz.KDV_TUTARI;
                        }
                    }

                    trf.KKDV_TO = toplamKKDF;
                    trf.OIV_TO = toplamOIV;
                    trf.BSMV_TO = toplamBSMV;
                    trf.KDV_TO = toplamKDV;
                    trf.ISLEMIS_FAIZ = (toplamFaiz < 0) ? 0 : toplamFaiz;
                    trf.ISLEMIS_FAIZ_DOVIZ_ID = trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID;
                    trf.KKDV_TO_DOVIZ_ID = 1;
                    trf.OIV_TO_DOVIZ_ID = 1;
                    trf.BSMV_TO_DOVIZ_ID = 1;
                    trf.KDV_TO_DOVIZ_ID = 1;
                    trf.OIV_TS = toplamTsOIV;
                    trf.BSMV_TS = toplamTsBSMV;
                    trf.KDV_TS = toplamTsKDV;
                    trf.SONRAKI_FAIZ = (toplamTsFaiz < 0) ? 0 : toplamTsFaiz;
                    trf.SONRAKI_FAIZ_DOVIZ_ID = trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID;

                    //TODO: Takip sonrasý için hesapladýklarýný yaz (Taraf Bazýnda Hesap:)[YAZDIK - TEST ET]

                    #endregion Taraftaki Vergilerin Hesaplanmasý (BSMV,KKDF,OIV,KDV)

                    //trf.IT_VEKALET_UCRETI = mFoy.IT_VEKALET_UCRETI*(decimal)nedenSorumlulukOrani*(decimal)trf.SORUMLULUK_ORANI;
                    //trf.IT_GIDERI = mFoy.IT_GIDERI * (decimal)nedenSorumlulukOrani * (decimal)trf.SORUMLULUK_ORANI;
                    //trf.IT_VEKALET_UCRETI_DOVIZ_ID = 1;
                    //trf.IT_GIDERI_DOVIZ_ID = 1;

                    trf.ILAM_INKAR_TAZMINATI = mFoy.ILAM_INKAR_TAZMINATI * (decimal)nedenSorumlulukOrani *
                                               (decimal)trf.SORUMLULUK_ORANI;
                    trf.ILAM_INKAR_TAZMINATI_DOVIZ_ID = mFoy.ILAM_INKAR_TAZMINATI_DOVIZ_ID ?? 1;
                    trf.ILAM_YARGILAMA_GIDERI = mFoy.ILAM_YARGILAMA_GIDERI * (decimal)nedenSorumlulukOrani *
                                                (decimal)trf.SORUMLULUK_ORANI;
                    trf.ILAM_YARGILAMA_GIDERI_DOVIZ_ID = mFoy.ILAM_YARGILAMA_GIDERI_DOVIZ_ID ?? 1;
                    trf.ILAM_BK_YARG_ONAMA = mFoy.ILAM_BK_YARG_ONAMA * (decimal)nedenSorumlulukOrani *
                                             (decimal)trf.SORUMLULUK_ORANI;
                    trf.ILAM_BK_YARG_ONAMA_DOVIZ_ID = mFoy.ILAM_BK_YARG_ONAMA_DOVIZ_ID ?? 1;

                    trf.ILAM_VEK_UCR = mFoy.ILAM_VEK_UCR * (decimal)nedenSorumlulukOrani * (decimal)trf.SORUMLULUK_ORANI;
                    trf.ILAM_VEK_UCR_DOVIZ_ID = mFoy.ILAM_VEK_UCR_DOVIZ_ID.Value;
                    trf.ILAM_TEBLIG_GIDERI = mFoy.ILAM_TEBLIG_GIDERI * (decimal)nedenSorumlulukOrani *
                                             (decimal)trf.SORUMLULUK_ORANI;
                    trf.ILAM_TEBLIG_GIDERI_DOVIZ_ID = mFoy.ILAM_TEBLIG_GIDERI_DOVIZ_ID ?? 1;
                    trf.CEK_KOMISYONU = trf.KOMISYONU;
                    trf.CEK_KOMISYONU_DOVIZ_ID = trf.KOMISYONU_DOVIZ_ID;
                    trf.PROTESTO_GIDERI = ndn.PROTESTO_GIDERI * (decimal)trf.SORUMLULUK_ORANI.Value;
                    trf.DAMGA_PULU = mFoy.DAMGA_PULU * (decimal)nedenSorumlulukOrani * (decimal)trf.SORUMLULUK_ORANI;

                    var TarafBorcluMu = false;
                    if (trf != null)
                        TarafBorcluMu = HesapAraclari.Icra.AlacakNedenTarafBoclumu(mFoy.ID, trf.TARAF_CARI_ID);

                    #region Masraf Avans Kalemleri Sözlüðe Alýnýyor

                    Dictionary<MuhasebeAltKategoriId, ParaVeDovizId> masrafKalemleri = new Dictionary<MuhasebeAltKategoriId, ParaVeDovizId>();

                    foreach (var mAvans in mFoy.AV001_TDI_BIL_MASRAF_AVANSCollection)
                    {
                        if (mAvans.BORCLU_CARI_ID == trf.TARAF_CARI_ID)
                        {
                            foreach (var mDetay in mAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                            {
                                if (!masrafKalemleri.ContainsKey((MuhasebeAltKategoriId)mDetay.HAREKET_ALT_KATEGORI_ID))
                                    masrafKalemleri.Add((MuhasebeAltKategoriId)mDetay.HAREKET_ALT_KATEGORI_ID, new ParaVeDovizId(mDetay.TOPLAM_TUTAR, mDetay.TOPLAM_TUTAR_DOVIZ_ID));
                                else
                                {
                                    ParaVeDovizId toplam = ParaVeDovizId.Topla(masrafKalemleri[(MuhasebeAltKategoriId)mDetay.HAREKET_ALT_KATEGORI_ID], new ParaVeDovizId(mDetay.TOPLAM_TUTAR, mDetay.TOPLAM_TUTAR_DOVIZ_ID));
                                    masrafKalemleri[(MuhasebeAltKategoriId)mDetay.HAREKET_ALT_KATEGORI_ID] = toplam;
                                }
                            }
                        }
                    }

                    #endregion Masraf Avans Kalemleri Sözlüðe Alýnýyor

                    #region Peþin Harç

                    if (masrafKalemleri.ContainsKey((MuhasebeAltKategoriId)629)) // Peþin Harç enumlarda yaþanan karýþýklýktan dolayý
                    {
                        var pesinHarc = masrafKalemleri[(MuhasebeAltKategoriId)629];

                        trf.PESIN_HARC = pesinHarc.Para;
                        trf.PESIN_HARC_DOVIZ_ID = pesinHarc.DovizId;
                    }

                    #endregion Peþin Harç

                    #region Ýlk Giderler

                    List<ParaVeDovizId> IlkGiderlerListesi = new List<ParaVeDovizId>();

                    #region Ýlk Tebligat Gideri

                    if (TarafBorcluMu)
                    {
                        int tarafSayisi = HesapAraclari.Icra.BorcluTarafSayisi(mFoy.ID);

                        if (tarafSayisi == 0) tarafSayisi = 1;

                        var ilkTebligatKisiyeDusen = mFoy.ILK_TEBLIGAT_GIDERI / tarafSayisi;

                        ParaVeDovizId ilkTebligatGideri = new ParaVeDovizId(ilkTebligatKisiyeDusen, mFoy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID);

                        IlkGiderlerListesi.Add(ilkTebligatGideri);
                    }

                    #endregion Ýlk Tebligat Gideri

                    #region Vekalet Harcý, Vekalet Pulu, Baþvurma Harcý

                    foreach (var tekKalem in masrafKalemleri)
                    {
                        if (tekKalem.Key == MuhasebeAltKategoriId.VEKALET_HARCI
                            || tekKalem.Key == MuhasebeAltKategoriId.VEKALET_PULU
                            || tekKalem.Key == MuhasebeAltKategoriId.BAÞVURMA_HARCI)
                        {
                            IlkGiderlerListesi.Add(tekKalem.Value);
                        }
                    }

                    #endregion Vekalet Harcý, Vekalet Pulu, Baþvurma Harcý

                    if (IlkGiderlerListesi.Count > 0)
                    {
                        var ilkGiderlerToplami = ParaVeDovizId.Topla(IlkGiderlerListesi);
                        trf.ILK_GIDERLER = ilkGiderlerToplami.Para;
                        trf.ILK_GIDERLER_DOVIZ_ID = ilkGiderlerToplami.DovizId;
                    }

                    #endregion Ýlk Giderler

                    taraflar.Add(trf);

                    #region OdemeBilgileri

                    //Tarafýn yaptýðý ödeme var ise ilgili özet alana yazýlmak üzere toplanýyor.

                    Dictionary<int, decimal> dicIHOdeme = new Dictionary<int, decimal>();
                    Dictionary<int, decimal> dicToOdeme = new Dictionary<int, decimal>();
                    List<ParaVeDovizId> listTsOdeme = new List<ParaVeDovizId>();
                    //foreach (TDI_KOD_DOVIZ_TIP tip in DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetAll())
                    //{
                    //    dicIHOdeme.Add(tip.ID, 0);
                    //    dicToOdeme.Add(tip.ID, 0);
                    //}
                    foreach (AV001_TI_BIL_BORCLU_ODEME odeme in mFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
                    {
                        if (odeme.ODEYEN_CARI_ID == trf.TARAF_CARI_ID)
                        {
                            if (mFoy.TAKIP_TARIHI.HasValue && odeme.ODEME_TARIHI >= mFoy.TAKIP_TARIHI.Value)
                            {
                                listTsOdeme.Add(new ParaVeDovizId(odeme.ODEME_MIKTAR ?? 0, odeme.ODEME_MIKTAR_DOVIZ_ID ?? 0, odeme.ODEME_TARIHI));
                            }
                            else
                            {
                                if (odeme.IHTIYATI_HACIZDE_MI) //TODO:bit
                                {
                                    if (dicIHOdeme.ContainsKey(odeme.ODEME_MIKTAR_DOVIZ_ID ?? 1))
                                        dicIHOdeme[odeme.ODEME_MIKTAR_DOVIZ_ID ?? 1] += odeme.ODEME_MIKTAR ?? 0;
                                    else
                                        dicIHOdeme.Add(odeme.ODEME_MIKTAR_DOVIZ_ID ?? 1, odeme.ODEME_MIKTAR ?? 0);
                                }
                                else
                                {
                                    if (dicToOdeme.ContainsKey(odeme.ODEME_MIKTAR_DOVIZ_ID ?? 1))
                                        dicToOdeme[odeme.ODEME_MIKTAR_DOVIZ_ID ?? 1] += odeme.ODEME_MIKTAR ?? 0;
                                    else
                                        dicToOdeme.Add(odeme.ODEME_MIKTAR_DOVIZ_ID ?? 1, odeme.ODEME_MIKTAR ?? 0);
                                }
                            }
                        }
                    }
                    FaizHelper.BosOlanAlanlariSil(dicIHOdeme);
                    FaizHelper.BosOlanAlanlariSil(dicToOdeme);

                    ParaVeDovizId pvdTsOdeme = ParaVeDovizId.Topla(listTsOdeme);
                    trf.ODEME_TOPLAMI = pvdTsOdeme.Para;
                    trf.ODEME_TOPLAMI_DOVIZ_ID = pvdTsOdeme.DovizId;

                    if (dicToOdeme.Count > 1)
                    {
                        foreach (AV001_TI_BIL_BORCLU_ODEME odeme in mFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
                        {
                            if (odeme.ODEYEN_CARI_ID == trf.TARAF_CARI_ID)
                            {
                                if (!odeme.IHTIYATI_HACIZDE_MI) //TODO: bit
                                {
                                    trf.TO_ODEME_TOPLAMI += DovizHelper.CevirYTL(odeme.ODEME_MIKTAR,
                                                                                     odeme.ODEME_MIKTAR_DOVIZ_ID,
                                                                                     odeme.ODEME_TARIHI);
                                }
                            }
                        }
                        trf.TO_ODEME_TOPLAMI_DOVIZ_ID = 1; //YTL
                    }
                    else
                    {
                        //Tek bir deðer olduðu için
                        Dictionary<int, decimal>.Enumerator num = dicToOdeme.GetEnumerator();
                        //Tek olan deðere ulaþýyor
                        num.MoveNext();
                        //bunun Doviztip ve miktar bilgilerini foy nesnesine yazýyoruz.
                        trf.TO_ODEME_TOPLAMI = num.Current.Value;
                        trf.TO_ODEME_TOPLAMI_DOVIZ_ID = num.Current.Key;
                        if (num.Current.Key == 0)
                        {
                            trf.TO_ODEME_TOPLAMI_DOVIZ_ID = 1;
                        }
                    }
                    if (dicIHOdeme.Count > 1)
                    {
                        foreach (AV001_TI_BIL_BORCLU_ODEME odeme in mFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
                        {
                            if (odeme.ODEYEN_CARI_ID == trf.TARAF_CARI_ID)
                            {
                                if (odeme.IHTIYATI_HACIZDE_MI)
                                {
                                    trf.IT_HACIZDE_ODENEN += DovizHelper.CevirYTL(odeme.ODEME_MIKTAR,
                                                                                  odeme.ODEME_MIKTAR_DOVIZ_ID,
                                                                                  odeme.ODEME_TARIHI);
                                }
                            }
                        }
                        trf.IT_HACIZDE_ODENEN_DOVIZ_ID = 1; //YTL
                    }
                    else
                    {
                        //Tek bir deðer olduðu için
                        Dictionary<int, decimal>.Enumerator num = dicIHOdeme.GetEnumerator();
                        //Tek olan deðere ulaþýyor
                        num.MoveNext();
                        //bunun Doviztip ve miktar bilgilerini foy nesnesine yazýyoruz.
                        trf.IT_HACIZDE_ODENEN = num.Current.Value;
                        trf.IT_HACIZDE_ODENEN_DOVIZ_ID = num.Current.Key;
                        if (num.Current.Key == 0)
                        {
                            trf.IT_HACIZDE_ODENEN_DOVIZ_ID = 1;
                        }
                    }

                    #endregion OdemeBilgileri
                }
                HesaplaTakipCikisiTaraf(ndn, mFoy.TAKIP_TARIHI.Value);
            }
        }

        /// <summary>
        /// Tarafýn Takip Öncesi Ödemelerinin Toplamýný Döndürüyor
        /// </summary>
        /// <param name="mFoy"></param>
        /// <param name="tarafId"></param>
        /// <returns></returns>
        public static ParaVeDovizId HesaplaTarafOdemeToplamiTO(AV001_TI_BIL_FOY mFoy, int tarafId)
        {
            List<ParaVeDovizId> paralar = new List<ParaVeDovizId>();
            foreach (AV001_TI_BIL_BORCLU_ODEME odeme in mFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
            {
                if (odeme.ODEYEN_CARI_ID == tarafId
                    && mFoy.TAKIP_TARIHI.HasValue
                    && odeme.ODEME_TARIHI <= mFoy.TAKIP_TARIHI.Value)
                {
                    paralar.Add(new ParaVeDovizId(odeme.ODEME_MIKTAR, odeme.ODEME_MIKTAR_DOVIZ_ID));
                }
            }
            ParaVeDovizId odemex = FaizHelper.ParalariTopla(paralar, DateTime.Today);
            return odemex;
        }

        /// <summary>
        /// Tarafýn Takip Sonrasý Ödemelerinin Toplamýný Döndürüyor
        /// </summary>
        /// <param name="mFoy"></param>
        /// <param name="tarafId"></param>
        /// <returns></returns>
        public static ParaVeDovizId HesaplaTarafOdemeToplamiTS(AV001_TI_BIL_FOY mFoy, int tarafId)
        {
            List<ParaVeDovizId> paralar = new List<ParaVeDovizId>();
            foreach (AV001_TI_BIL_BORCLU_ODEME odeme in mFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
            {
                if (odeme.ODEYEN_CARI_ID == tarafId
                    && mFoy.TAKIP_TARIHI.HasValue
                    && odeme.ODEME_TARIHI > mFoy.TAKIP_TARIHI.Value)
                {
                    paralar.Add(new ParaVeDovizId(odeme.ODEME_MIKTAR, odeme.ODEME_MIKTAR_DOVIZ_ID));
                }
            }
            ParaVeDovizId odemex = FaizHelper.ParalariTopla(paralar, DateTime.Today);
            return odemex;
        }

        /// <summary>
        /// Icra modülü için deðiþken faiz hesaplar ve <see cref="TList{AV001_TI_BIL_FAIZ}"/>  tipinde geri döndürür
        /// </summary>
        /// <seealso cref="IcraSabitFaizHesapla(int,DateTime,DateTime,decimal,int,int,double)"/>
        /// <param name="faizTipId">Deðiþken faizin tipi</param>
        /// <param name="baslangicT">Faiz baþlangýç tarihi</param>
        /// <param name="bitisT">Faiz bitiþ tarihi</param>
        /// <param name="tutar">Faiz hesaplanacak tutar</param>
        /// <param name="dovizTipId">Faiz hesaplanacak <paramref name="tutar"/> birimi</param>
        /// <param name="birYilKacGun">Bir yilin kaç gün olduðu</param>
        /// <returns>Hesaplanmýþ faizleri <see cref="TList{AV001_TI_BIL_FAIZ}"/> tipinde geri döndürür</returns>
        public static TList<AV001_TI_BIL_FAIZ> IcraDegiskenFaizHesapla(int faizTipId, DateTime baslangicT, DateTime bitisT, decimal tutar, int dovizTipId, int birYilKacGun)
        {
            TDI_CET_FAIZ_TARIFEQuery qu2 = new TDI_CET_FAIZ_TARIFEQuery(true);
            qu2.AppendLessThanOrEqual(TDI_CET_FAIZ_TARIFEColumn.TARIFE_GECERLILIK_BASLANGIC_TARIHI,
                                      baslangicT.ToString("yyyy/MM/dd 00:00:00"));
            qu2.AppendEquals(TDI_CET_FAIZ_TARIFEColumn.FAIZ_TIP_ID, faizTipId.ToString());
            qu2.AppendEquals(TDI_CET_FAIZ_TARIFEColumn.DOVIZ_TIP_ID, dovizTipId.ToString());
            int k;
            TDI_CET_FAIZ_TARIFE ilkFaiz = null;
            TList<TDI_CET_FAIZ_TARIFE> ilkFaizLer = DataRepository.TDI_CET_FAIZ_TARIFEProvider.Find(qu2, "TARIFE_GECERLILIK_BASLANGIC_TARIHI DESC", 0, 1, out k);
            if (ilkFaizLer.Count > 0)
            {
                ilkFaiz = ilkFaizLer[0];
            }
            else
            {
                return new TList<AV001_TI_BIL_FAIZ>();
            }
            TDI_CET_FAIZ_TARIFEQuery qu = new TDI_CET_FAIZ_TARIFEQuery(true);
            qu.AppendGreaterThanOrEqual(TDI_CET_FAIZ_TARIFEColumn.TARIFE_GECERLILIK_BASLANGIC_TARIHI,
                                        ilkFaiz.TARIFE_GECERLILIK_BASLANGIC_TARIHI.ToString("yyyy/MM/dd 00:00:00"));
            qu.AppendLessThanOrEqual(TDI_CET_FAIZ_TARIFEColumn.TARIFE_GECERLILIK_BASLANGIC_TARIHI, bitisT.ToString("yyyy/MM/dd 00:00:00"));
            qu.AppendEquals(TDI_CET_FAIZ_TARIFEColumn.FAIZ_TIP_ID, faizTipId.ToString());
            qu.AppendEquals(TDI_CET_FAIZ_TARIFEColumn.DOVIZ_TIP_ID, dovizTipId.ToString());
            TList<TDI_CET_FAIZ_TARIFE> faizler =
                DataRepository.TDI_CET_FAIZ_TARIFEProvider.Find(qu, "TARIFE_GECERLILIK_BASLANGIC_TARIHI ASC");
            TList<AV001_TI_BIL_FAIZ> kalemler = new TList<AV001_TI_BIL_FAIZ>();
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
                            AV001_TI_BIL_FAIZ fk = kalemler.AddNew();
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
                        AV001_TI_BIL_FAIZ fk = kalemler.AddNew();
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
                AV001_TI_BIL_FAIZ fk = kalemler.AddNew();
                fk.FAIZ_BASLANGIC_TARIHI = baslangicT.Date;
                fk.FAIZ_BITIS_TARIHI = bitisT.Date;
                fk.FAIZ_ORANI = faizler[0].TARIFE_TUTARI;
                TimeSpan ts = fk.FAIZ_BITIS_TARIHI.Value - fk.FAIZ_BASLANGIC_TARIHI.Value;
                int yuzdeBinde = faizler[0].TARIFE_BINDE_ORAN_MI == 1 ? 1000 : 100;
                fk.GUN_FARKI = ts.Days; // bitis tarihinide hesaba katmýyoruz ts.Days + 1 yok
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
            }
            return kalemler;
        }

        /// <summary>
        /// Icra modülü için deðiþken faiz hesaplar ve <see cref="TList{AV001_TI_BIL_FAIZ}"/> tipinde geri döndürür
        /// </summary>
        /// <seealso cref="IcraSabitFaizHesapla(int,DateTime,DateTime,decimal,int,int,double)"/>
        /// <param name="faizTipId">Deðiþken faizin tipi</param>
        /// <param name="baslangicT">Faiz baþlangýç tarihi</param>
        /// <param name="bitisT">Faiz bitiþ tarihi</param>
        /// <param name="tutar">Faiz hesaplanacak tutar</param>
        /// <param name="dovizTipId">Faiz hesaplanacak tutar birimi</param>
        /// <param name="birYilKacGun">Bir yilin kaç gün olduðu</param>
        /// <param name="kalemId">Hesaplanan faizlerin kalem Id si</param>
        /// <returns>Hesaplanmýþ faizleri <see cref="TList{AV001_TI_BIL_FAIZ}"/> tipinde geri döndürür</returns>
        public static TList<AV001_TI_BIL_FAIZ> IcraDegiskenFaizHesapla(int faizTipId, DateTime baslangicT, DateTime bitisT, decimal tutar, int dovizTipId, int birYilKacGun, FaizKalem kalemId)
        {
            TList<AV001_TI_BIL_FAIZ> result =
                IcraDegiskenFaizHesapla(faizTipId, baslangicT, bitisT, tutar, dovizTipId, birYilKacGun);

            result.ForEach(delegate(AV001_TI_BIL_FAIZ obj)
            {
                obj.FAIZ_KALEM_ID = (int)kalemId;
            });
            return result;
        }

        public static AV001_TI_BIL_FAIZ IcraFaizKalemiGetir(int faizTipId, DateTime baslangicT, DateTime bitisT, decimal tutar, int dovizTipId, int birYilKacGun, double oran)
        {
            AV001_TI_BIL_FAIZ fk = new AV001_TI_BIL_FAIZ();
            fk.FAIZ_BASLANGIC_TARIHI = baslangicT.Date;
            fk.FAIZ_BITIS_TARIHI = bitisT.Date;
            fk.FAIZ_ORANI = oran;
            TimeSpan ts = fk.FAIZ_BITIS_TARIHI.Value - fk.FAIZ_BASLANGIC_TARIHI.Value;
            fk.GUN_FARKI = ts.Days; // bitis tarihinide hesaba katmýyoruz ts.Days+1 yok
            fk.FAIZ_TUTARI = tutar;//(tutar / yuzdeBinde * (decimal)fk.FAIZ_ORANI) / birYilKacGun * fk.GUN_FARKI;
            fk.FAIZ_TIP_ID = faizTipId;
            fk.FAIZ_TUTARI_DOVIZ_ID = dovizTipId;
            fk.KAYIT_TARIHI = DateTime.Now;
            fk.KLASOR_KODU = "GENEL";
            fk.KONTROL_KIM = "AVUKATPRO";
            fk.KONTROL_NE_ZAMAN = DateTime.Now;
            fk.KONTROL_VERSIYON = 1;
            return fk;
        }

        /// <summary>
        /// AV001_TI_BIL_FAIZ tipinden gönderilen liste üzerinde vergi hesaplamasý yapmak için kullanýlan method
        /// </summary>
        /// <param name="vergiTur">Hesaplamanýn yapýlacaðý vergi türü</param>
        /// <param name="faizler">Hesaplamanýn yazýlacaðý faizler</param>
        /// <param name="tarih">Icra foy için takip tarihi (tarih eðer faiz YTL den farklý bir birimde ise kurun hesaplanacaðý tarihtir ve verginin oranýný bulmak için kullanýlýr)</param>
        public static void IcraFaizUzerineDigerVergiHesapla(DigerVergiTuru vergiTur, TList<AV001_TI_BIL_FAIZ> faizler, DateTime tarih)
        {
            decimal vergiOran = (decimal)DigerVergiOraniGetir(vergiTur, tarih);
            foreach (AV001_TI_BIL_FAIZ faiz in faizler)
            {
                if (faiz.FAIZ_TUTARI_DOVIZ_ID.HasValue && faiz.FAIZ_TUTARI > 0)
                {
                    #region <GKN-20090612>

                    //hesaplamalarýn TL ye çevirmesi iptal edildi

                    switch (vergiTur)
                    {
                        case DigerVergiTuru.BSMV:
                            faiz.BSMV_DOVIZ_ID = 1;
                            //Faiz YTL olarak hesaplanmadýysa

                            
                                faiz.BSMV_TUTARI = faiz.FAIZ_TUTARI * vergiOran / 100;
                                faiz.BSMV_DOVIZ_ID = faiz.FAIZ_TUTARI_DOVIZ_ID;
                            
                            break;

                        case DigerVergiTuru.KKDF:
                            if (faiz.FAIZ_BASLANGIC_TARIHI < tarih.Date)
                            {
                                faiz.KKDF_DOVIZ_ID = 1;
                                //Faiz YTL olarak hesaplanmadýysa
                                
                                    faiz.KKDF_TUTARI = faiz.FAIZ_TUTARI * vergiOran / 100;
                                
                            }
                            break;

                        case DigerVergiTuru.ÖÝV:
                            faiz.OIV_DOVIZ_ID = 1;
                            //Faiz YTL olarak hesaplanmadýysa
                           
                                faiz.OIV_TUTARI = faiz.FAIZ_TUTARI * vergiOran / 100;
                                faiz.OIV_DOVIZ_ID = faiz.FAIZ_TUTARI_DOVIZ_ID;
                            
                            break;

                        default:
                            break;
                    }

                    #endregion <GKN-20090612>
                }
            }
        }

        public static void IcraFaizUzerineDigerVergiHesapla(DigerVergiTuru vergiTur, AV001_TI_BIL_FAIZ faiz, DateTime tarih)
        {
            decimal vergiOran = (decimal)DigerVergiOraniGetir(vergiTur, tarih);

            if (faiz.FAIZ_TUTARI_DOVIZ_ID.HasValue && faiz.FAIZ_TUTARI > 0)
            {
                #region <GKN-20090612>

                //hesaplamalarýn TL ye çevirmesi iptal edildi

                switch (vergiTur)
                {
                    case DigerVergiTuru.BSMV:
                        faiz.BSMV_DOVIZ_ID = 1;
                        //Faiz YTL olarak hesaplanmadýysa

                       
                            faiz.BSMV_TUTARI = faiz.FAIZ_TUTARI * vergiOran / 100;
                            faiz.BSMV_DOVIZ_ID = faiz.FAIZ_TUTARI_DOVIZ_ID;
                        
                        break;

                    case DigerVergiTuru.KKDF:
                        faiz.KKDF_DOVIZ_ID = 1;
                        //Faiz YTL olarak hesaplanmadýysa
                        
                            faiz.KKDF_TUTARI = faiz.FAIZ_TUTARI * vergiOran / 100;
                        
                        break;

                    case DigerVergiTuru.ÖÝV:
                        faiz.OIV_DOVIZ_ID = 1;
                        //Faiz YTL olarak hesaplanmadýysa
                       
                            faiz.OIV_TUTARI = faiz.FAIZ_TUTARI * vergiOran / 100;
                            faiz.OIV_DOVIZ_ID = faiz.FAIZ_TUTARI_DOVIZ_ID;
                        
                        break;

                    default:
                        break;
                }

                #endregion <GKN-20090612>
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="kdvKategoriId"></param>
        /// <param name="faizler"></param>
        /// <param name="tarih"></param>
        public static void IcraFaizUzerineKDVHesapla(int kdvKategoriId, TList<AV001_TI_BIL_FAIZ> faizler, DateTime tarih)
        {
            foreach (AV001_TI_BIL_FAIZ faiz in faizler)
            {
                if (faiz.FAIZ_TUTARI_DOVIZ_ID.HasValue && faiz.FAIZ_TUTARI > 0)
                {
                    faiz.KDV_DOVIZ_ID = 1;
                    faiz.KDV_TUTARI = faiz.FAIZ_TUTARI * (decimal)KDVOraniGetir(kdvKategoriId, tarih) / 100;
                }
            }
        }

        public static AV001_TI_BIL_HARC IcraHarcKalemiEkleGetir(AV001_TI_BIL_FOY foy, MuhasebeAltKategoriId mHAK, decimal harcMiktari, DateTime tarifeTarih)
        {
            AV001_TI_BIL_HARC harc = HarcGetir(mHAK, new ParaVeDovizId(0, 1), harcMiktari, tarifeTarih);
            foy.AV001_TI_BIL_HARCCollection.Add(harc);
            return harc;
        }

        public static AV001_TI_BIL_HARC IcraHarcKalemiEkleGetir(AV001_TI_BIL_FOY foy, IcraNispiHarcTipi harcTipi, decimal harcMiktari, DateTime tarifeTarih, ParaVeDovizId matrah, double oran)
        {
            AV001_TI_BIL_HARC harc = HarcGetir(harcTipi, matrah, oran, harcMiktari, tarifeTarih);
            foy.AV001_TI_BIL_HARCCollection.Add(harc);
            return harc;
        }

        public static AV001_TI_BIL_HARC IcraHarcKalemiEkleGetir(AV001_TI_BIL_FOY_TARAF taraf, MuhasebeAltKategoriId mHAK, decimal harcMiktari, DateTime tarifeTarih)
        {
            AV001_TI_BIL_HARC harc = HarcGetir(mHAK, new ParaVeDovizId(0, 1), harcMiktari, tarifeTarih);
            taraf.AV001_TI_BIL_HARCCollection.Add(harc);
            return harc;
        }

        public static AV001_TI_BIL_HARC IcraHarcKalemiEkleGetir(AV001_TI_BIL_FOY_TARAF taraf, IcraNispiHarcTipi harcTipi, decimal harcMiktari, DateTime tarifeTarih, ParaVeDovizId matrah, double oran)
        {
            AV001_TI_BIL_HARC harc = HarcGetir(harcTipi, matrah, oran, harcMiktari, tarifeTarih);
            taraf.AV001_TI_BIL_HARCCollection.Add(harc);
            return harc;
        }

        public static double IcraHarcOraniGetir(DateTime gecerlilikTarihi, IcraNispiHarcTipi harcTipi)
        {
            double result = 0;
            TI_CET_NISPI_HARCQuery qu2 = new TI_CET_NISPI_HARCQuery(true);
            qu2.AppendLessThanOrEqual(TI_CET_NISPI_HARCColumn.TARIH,
                                       gecerlilikTarihi.ToString("yyyy/MM/dd 00:00:00"));
            qu2.AppendEquals(TI_CET_NISPI_HARCColumn.HARC_KOD_ID, ((int)harcTipi).ToString());
            int k = 0;
            TI_CET_NISPI_HARC harc = DataRepository.TI_CET_NISPI_HARCProvider.Find(qu2, "TARIH DESC", 0, 1, out k)[0];
            if (harc.YUZDE_BINDE == 1)
                result = harc.ORAN / 10;
            else
                result = harc.ORAN;
            return result;
        }

        /// <summary>
        /// TI_CET_HARC_MAKTU tablosundan geçerlilik tarihi ve Muhasebe Hareket Alt Kategori Id ye göre Harç Tutarý Getirir
        /// </summary>
        /// <param name="gecerlilikT">Tutarýn geçer</param>
        /// <param name="MUHASEBE_HAREKET_ALT_KATEGORI_ID">Tutara ait hareket alt kategori Id</param>
        /// <returns></returns>
        public static ParaVeDovizId IcraHarcTutarGetir(DateTime gecerlilikT, int MUHASEBE_HAREKET_ALT_KATEGORI_ID)
        {
            TI_CET_HARC_MAKTUQuery qu2 = new TI_CET_HARC_MAKTUQuery(true);
            qu2.AppendLessThanOrEqual(TI_CET_HARC_MAKTUColumn.TARIH,
                                      gecerlilikT.ToString("yyyy/MM/dd 00:00:00"));
            qu2.AppendEquals(TI_CET_HARC_MAKTUColumn.HARC_KOD_ID, (MUHASEBE_HAREKET_ALT_KATEGORI_ID).ToString());
            int k = 0;

            var sonuclar = DataRepository.TI_CET_HARC_MAKTUProvider.Find(qu2, "TARIH DESC", 0, 1, out k);
            if (sonuclar.Count > 0)
            {
                TI_CET_HARC_MAKTU harc = sonuclar.First();
                return new ParaVeDovizId(harc.DEGER, harc.DOVIZ_ID);
            }

            return new ParaVeDovizId(0, 1);
        }

        /// <summary>
        /// ilk giderleri hesapla...
        /// </summary>
        /// <param name="foy"></param>
        /// <param name="tarafs">Foy Taraf</param>
        /// <param name="takipEdilenSayisi"></param>
        public static void IcraIlkGiderleriHesapla(AV001_TI_BIL_FOY foy, TList<AV001_TI_BIL_FOY_TARAF> tarafs, int takipEdilenSayisi)
        {
            if (foy.TAKIP_TALEP_ID.HasValue && foy.TAKIP_TALEP_IDSource == null)
                foy.TAKIP_TALEP_IDSource =
                    DataRepository.TI_KOD_TAKIP_TALEPProvider.GetByID(foy.TAKIP_TALEP_ID.Value);
            AvukatProLib2.Data.DataRepository.TI_KOD_TAKIP_TALEPProvider.DeepLoad(foy.TAKIP_TALEP_IDSource, true, DeepLoadType.IncludeChildren, typeof(TList<TI_KOD_TAKIP_TALEP_NISPI_HARC>), typeof(TList<TI_KOD_TAKIP_TALEP_MAKTU_HARC>));

            if (foy.AV001_TDI_BIL_MASRAF_AVANSCollection == null)
                foy.AV001_TDI_BIL_MASRAF_AVANSCollection = new TList<AV001_TDI_BIL_MASRAF_AVANS>();

            TList<AV001_TDI_BIL_MASRAF_AVANS> avanss = new TList<AV001_TDI_BIL_MASRAF_AVANS>();
            AV001_TDI_BIL_MASRAF_AVANS avans = foy.AV001_TDI_BIL_MASRAF_AVANSCollection.AddNew();
            avans.MASRAF_AVANS_TIP = 1;
            if (foy.AV001_TI_BIL_FOY_TARAFCollection == null)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));
            if (foy.AV001_TI_BIL_FOY_TARAFCollection != null && foy.AV001_TI_BIL_FOY_TARAFCollection.Where(vi => !vi.TAKIP_EDEN_MI).Count() > 0)
                avans.BORCLU_CARI_ID = foy.AV001_TI_BIL_FOY_TARAFCollection.Where(vi => !vi.TAKIP_EDEN_MI).FirstOrDefault().CARI_ID;
            avans.REFERANS_NO = string.Format(@"{0}\{1}\{2}", DateTime.Today.Year, DateTime.Today.Month, Guid.NewGuid().ToString().Split('-')[0].ToUpper());

            decimal basvurmaHarci = 0;
            decimal vekaletPulu = 0;
            decimal vekaletHarci = 0;
            decimal iflasBasvurmaHarci = 0;
            decimal iflasinAcilmasiHarci = 0;
            decimal pesinHarc = 0;

            //Vekalet pulu ve harcý bilgisi tarfa baðlanan vekil üzerinden hesaplanýyordu. bu iþlem iptal edildi. Her takipte bir tane vekalet pulu ve vekalet harcý hesabýnýn yapýlmasý saðlandý. MB ( Kenan Büyük talebi. )
            //#region VekaletPulAdet
            //Dictionary<int, int> dicVek = new Dictionary<int, int>();
            //TList<AV001_TI_BIL_FOY_TARAF_VEKIL> listVek = new TList<AV001_TI_BIL_FOY_TARAF_VEKIL>();

            //int tplVekAdt = 0;
            //foy.AV001_TI_BIL_FOY_TARAFCollection.Filter = string.Empty;
            //foreach (AV001_TI_BIL_FOY_TARAF taraf in foy.AV001_TI_BIL_FOY_TARAFCollection)
            //{
            //    DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(taraf, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF_VEKIL>));

            //    foreach (AV001_TI_BIL_FOY_TARAF_VEKIL vekil in taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection)
            //    {
            //        //Eðer bir temsile baðlý ise
            //        if (vekil.TEMSIL_ID.HasValue)
            //        {
            //            if (!dicVek.ContainsKey(vekil.TEMSIL_ID.Value))
            //                dicVek.Add(vekil.TEMSIL_ID.Value, 0);

            //        }//eðer yeni oluþturulmuþ bir temsile baðlý ise
            //        else if (vekil.TEMSIL_IDSource != null)
            //        {
            //            tplVekAdt++;

            //        }
            //        else // Eðer bir temsile baðlý deðil ise (karþý tarafýn temsilini girmek zorunda deðiliz
            //        {
            //            tplVekAdt++;
            //        }
            //    }
            //}
            //tplVekAdt += dicVek.Count;
            //#endregion

            // Klasör üzerinde harç hesaplamýyoruz <gkn>
            if (foy.ID != 0)
            {
                foreach (TI_KOD_TAKIP_TALEP_MAKTU_HARC mh in foy.TAKIP_TALEP_IDSource.TI_KOD_TAKIP_TALEP_MAKTU_HARCCollection)
                {
                    int mHAK = mh.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI_ID;
                    switch (mHAK)
                    {
                        case 440: //Baþvurma Harcý
                            basvurmaHarci = IcraHarcTutarGetir(foy.TAKIP_TARIHI.Value, mHAK).Para;
                            IcraHarcKalemiEkleGetir(foy, (MuhasebeAltKategoriId)mHAK, basvurmaHarci, foy.TAKIP_TARIHI.Value);
                            //TEST: Burasý yeni eklendi
                            //avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(IcraMasrafAvansGetir(basvurmaHarci, mHAK, 1, foy.TAKIP_TARIHI.Value));

                            break;

                        case 591: //Vekalet Pulu
                            vekaletPulu = IcraHarcTutarGetir(foy.TAKIP_TARIHI.Value, mHAK).Para * 1;// tplVekAdt; MB
                            IcraHarcKalemiEkleGetir(foy, (MuhasebeAltKategoriId)mHAK, vekaletPulu, foy.TAKIP_TARIHI.Value);
                            //TEST: Burasý yeni eklendi
                            //if (tplVekAdt != 0) //Vekalet pulu ve vekalet harcýnýn her durumda bir tane hesaplanmasý talebi. MB
                            //avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(IcraMasrafAvansGetir(vekaletPulu /*/ tplVekAdt*/, mHAK, 1/*tplVekAdt*/, foy.TAKIP_TARIHI.Value));
                            //else
                            //    avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(IcraMasrafAvansGetir(vekaletPulu, mHAK,tplVekAdt, foy.TAKIP_TARIHI.Value));
                            break;

                        case 590: //Vekalet Harcý
                            vekaletHarci = IcraHarcTutarGetir(foy.TAKIP_TARIHI.Value, mHAK).Para * 1;// tplVekAdt; MB
                            IcraHarcKalemiEkleGetir(foy, (MuhasebeAltKategoriId)mHAK, vekaletHarci, foy.TAKIP_TARIHI.Value);
                            //TEST: Burasý yeni eklendi
                            //if (tplVekAdt != 0)//Vekalet pulu ve vekalet harcýnýn her durumda bir tane hesaplanmasý talebi. MB
                            //avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(IcraMasrafAvansGetir(vekaletHarci /*/ tplVekAdt*/, mHAK, 1/*tplVekAdt*/, foy.TAKIP_TARIHI.Value));
                            //else
                            //    avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(IcraMasrafAvansGetir(vekaletHarci, mHAK, tplVekAdt, foy.TAKIP_TARIHI.Value));
                            break;

                        case 452: //ÝFLAS BAÞVURMA HARCI
                            iflasBasvurmaHarci = IcraHarcTutarGetir(foy.TAKIP_TARIHI.Value, mHAK).Para;
                            IcraHarcKalemiEkleGetir(foy, (MuhasebeAltKategoriId)mHAK, iflasBasvurmaHarci, foy.TAKIP_TARIHI.Value);
                            //TEST: Burasý yeni eklendi
                            //avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(IcraMasrafAvansGetir(iflasBasvurmaHarci, mHAK, 1, foy.TAKIP_TARIHI.Value));
                            break;

                        case 601: //ÝFLASIN AÇILMASI HARCI
                            iflasinAcilmasiHarci = IcraHarcTutarGetir(foy.TAKIP_TARIHI.Value, mHAK).Para;
                            IcraHarcKalemiEkleGetir(foy, (MuhasebeAltKategoriId)mHAK, iflasinAcilmasiHarci, foy.TAKIP_TARIHI.Value);
                            //TEST: Burasý yeni eklendi
                            //avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(IcraMasrafAvansGetir(iflasinAcilmasiHarci, mHAK, 1, foy.TAKIP_TARIHI.Value));
                            break;

                        case 592://SURET HARCI
                            //Suret harcý daha sonra
                            //suretHarci = IcraHarcTutarGetir(foy.TAKIP_TARIHI.Value, mHAK).Para;
                            break;

                        case 603: //KONKARDATO
                            //Hesap þuan yok
                            break;

                        default:

                            break;
                    }
                }

                foreach (TI_KOD_TAKIP_TALEP_NISPI_HARC nh in foy.TAKIP_TALEP_IDSource.TI_KOD_TAKIP_TALEP_NISPI_HARCCollection)
                {
                    int nHNId = nh.HARC_NISPI_ID;
                    switch ((IcraNispiHarcTipi)nHNId)
                    {
                        case IcraNispiHarcTipi.PESiN_HARC:
                            if (PesinHarcKosulu(foy))
                            {
                                double nhOran = IcraHarcOraniGetir(foy.TAKIP_TARIHI.Value, (IcraNispiHarcTipi)nHNId);

                                ParaVeDovizId takipsizAlacaklarToplami = TakipsizAlacaklarToplami(foy); //Klasör Ýçin Özel
                                ParaVeDovizId kalan = ParaVeDovizId.Cikart(new ParaVeDovizId(foy.TAKIP_CIKISI, foy.TAKIP_CIKISI_DOVIZ_ID),
                                    takipsizAlacaklarToplami);
                                if (kalan.Para < 0)
                                    kalan.Para = 0;
                                pesinHarc = (decimal)nhOran *
                                            (kalan.YtlCevir(foy.TAKIP_TARIHI ?? DateTime.Now) / 100); //BUNE: Niçin 100 e bölüyoruz oranlarmý þaþýrýyor
                                IcraHarcKalemiEkleGetir(foy, (IcraNispiHarcTipi)nHNId, pesinHarc, foy.TAKIP_TARIHI.Value, new ParaVeDovizId(foy.TAKIP_CIKISI, foy.TAKIP_CIKISI_DOVIZ_ID), nhOran);
                                //TEST: Burasý yeni eklendi
                                //avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(IcraMasrafAvansGetir(pesinHarc, 629, 1, foy.TAKIP_TARIHI.Value)); //PeþinHarç
                            }
                            break;

                        default:
                            break;
                    }
                }
            }

            #region Vekalet UcretiHesabý

            foy.AV001_TI_BIL_VEKALET_UCRETCollection.Clear();

            //Maktu
            if (foy.TAKIP_TALEP_IDSource.VEKALET_UCRETI_MAKTU_MU && foy.TAKIP_TALEP_IDSource.VEKALET_UCRETI_MAKTU_KOD_ID.HasValue)
            {
                ParaVeDovizId pvd = VekaletTutariGetir(foy.TAKIP_TARIHI.Value, foy.TAKIP_TALEP_IDSource.VEKALET_UCRETI_MAKTU_KOD_ID.Value);
                AvukatProLib2.Entities.AV001_TI_BIL_VEKALET_UCRET vekUc =
                    VekaletUcretiGetir(new ParaVeDovizId(foy.TAKIP_CIKISI, foy.TAKIP_CIKISI_DOVIZ_ID), foy.TAKIP_TARIHI.Value, VekaletUcretKalemi.MaktuTakipVekUcr, pvd, 0, VekaketUcretTipNo.Maktu, foy.SON_HESAP_TARIHI);
                //vekUc.HESAPLAMA_TARIHI = DateTime.Now;
                //TODO:TEST et  yeni eklendi

                foy.AV001_TI_BIL_VEKALET_UCRETCollection.Add(vekUc);

                foy.TAKIP_VEKALET_UCRETI = pvd.Para;
                foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID = pvd.DovizId;
            }
            else //Nispi
            {
                //foy.TAKIP_VEKALET_UCRETI =
                //TODO:Test et deðiþti
                NispiVekaletUcretiHesapla(foy);
                //foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID = 1;
                //foy.AV001_TI_BIL_VEKALET_UCRETCollection.Add(VekaletUcretiGetir(new ParaVeDovizId(foy.TAKIP_CIKISI,foy.TAKIP_CIKISI_DOVIZ_ID),foy.TAKIP_TARIHI.Value,VekaletUcretKalemi.NispiTakipVekUcr,new ParaVeDovizId(foy.TAKIP_VEKALET_UCRETI,foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID),, ));
            }

            #endregion Vekalet UcretiHesabý

            #region ÝlkTebligat_Gideri_Hesapla

            decimal ilkTebligatGideri = PostaGideriGetir(foy.TAKIP_TARIHI.Value, (int)MuhasebeAltKategoriId.iLK_TEBLiGAT_GiDERi).Para;
            //Ýlk Tebligat gideri harç olmadýðýndan bu kalemin harç collection'ýna eklenmesi olayý kapatýldý. MB
            //IcraHarcKalemiEkleGetir(foy, (MuhasebeAltKategoriId)568, ilkTebligatGideri, foy.TAKIP_TARIHI.Value);
            //TEST: Burasý yeni eklendi
            //avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(IcraMasrafAvansGetir(ilkTebligatGideri * takipEdilenSayisi, 568, 1, foy.TAKIP_TARIHI.Value));

            #endregion ÝlkTebligat_Gideri_Hesapla

            #region TarafBazýnda ÝlkGiderler

            //ilk icra kayýt da masraf oluþturmama iþlemi için eklendi. taraflar eksik geliyordu.
            tarafs = DataRepository.AV001_TI_BIL_FOY_TARAFProvider.GetByICRA_FOY_ID(foy.ID);

            int tarafSayisi = tarafs.Where(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI).Count();

            foreach (AV001_TI_BIL_FOY_TARAF taraf in tarafs)
            {
                //continue; // taraf bazýnda ilk gider hesabý iptal edildi
                if (taraf.TARAF_SIFAT_ID != (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)
                    continue;
                taraf.ILK_GIDERLER = 0;

                //decimal sorumlulukOran = (decimal)IcraSorumlulukOraniGetirByCariId(taraf.CARI_ID.Value, foy);
                decimal sorumlulukOran = (decimal)1 / tarafSayisi;
                AV001_TDI_BIL_MASRAF_AVANS mAvans = foy.AV001_TDI_BIL_MASRAF_AVANSCollection.AddNew(); //new AV001_TDI_BIL_MASRAF_AVANS();
                mAvans.MASRAF_AVANS_TIP = 1;
                mAvans.BORCLU_CARI_ID = taraf.CARI_ID;
                mAvans.BORCLU_CARI_IDSource = taraf.CARI_IDSource;
                if (basvurmaHarci * sorumlulukOran > 0)
                {
                    taraf.ILK_GIDERLER += basvurmaHarci * sorumlulukOran;
                    taraf.BASVURMA_HARCI = basvurmaHarci * sorumlulukOran;
                    IcraHarcKalemiEkleGetir(taraf, MuhasebeAltKategoriId.BAÞVURMA_HARCI, taraf.BASVURMA_HARCI,
                                            foy.TAKIP_TARIHI.Value);
                    mAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                        IcraMasrafAvansGetir(basvurmaHarci * sorumlulukOran, 440, 1, foy.TAKIP_TARIHI.Value, foy.SEGMENT_ID));
                }
                if (vekaletPulu * sorumlulukOran > 0)
                {
                    taraf.ILK_GIDERLER += vekaletPulu * sorumlulukOran;
                    taraf.VEKALET_PULU = vekaletPulu * sorumlulukOran;
                    IcraHarcKalemiEkleGetir(taraf, MuhasebeAltKategoriId.VEKALET_PULU, taraf.VEKALET_PULU,
                                            foy.TAKIP_TARIHI.Value);
                    mAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                        IcraMasrafAvansGetir(vekaletPulu * sorumlulukOran, 591, 1, foy.TAKIP_TARIHI.Value, foy.SEGMENT_ID));
                }
                if (vekaletHarci * sorumlulukOran > 0)
                {
                    taraf.ILK_GIDERLER += vekaletHarci * sorumlulukOran;
                    taraf.VEKALET_HARCI = vekaletHarci * sorumlulukOran;
                    IcraHarcKalemiEkleGetir(taraf, MuhasebeAltKategoriId.VEKALET_HARCI, taraf.VEKALET_HARCI,
                                            foy.TAKIP_TARIHI.Value);
                    mAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                        IcraMasrafAvansGetir(vekaletHarci * sorumlulukOran, 590, 1, foy.TAKIP_TARIHI.Value, foy.SEGMENT_ID));
                }
                if (iflasBasvurmaHarci * sorumlulukOran > 0)
                {
                    taraf.ILK_GIDERLER += iflasBasvurmaHarci * sorumlulukOran;
                    taraf.IFLAS_BASVURMA_HARCI = iflasBasvurmaHarci * sorumlulukOran;
                    IcraHarcKalemiEkleGetir(taraf, MuhasebeAltKategoriId.ÝFLAS_BAÞVURMA_HARCI, taraf.IFLAS_BASVURMA_HARCI,
                                            foy.TAKIP_TARIHI.Value);
                    mAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                        IcraMasrafAvansGetir(iflasBasvurmaHarci * sorumlulukOran, 452, 1, foy.TAKIP_TARIHI.Value, foy.SEGMENT_ID));
                }
                if (iflasinAcilmasiHarci * sorumlulukOran > 0)
                {
                    taraf.ILK_GIDERLER += iflasinAcilmasiHarci * sorumlulukOran;
                    taraf.IFLASIN_ACILMASI_HARCI = iflasinAcilmasiHarci * sorumlulukOran;
                    IcraHarcKalemiEkleGetir(taraf, MuhasebeAltKategoriId.MAKTU_ÝFLASIN_AÇILMASI_HARCI, taraf.IFLASIN_ACILMASI_HARCI,
                                            foy.TAKIP_TARIHI.Value);
                    mAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                        IcraMasrafAvansGetir(iflasinAcilmasiHarci * sorumlulukOran, 601, 1, foy.TAKIP_TARIHI.Value, foy.SEGMENT_ID));
                }
                if (pesinHarc * sorumlulukOran > 0)
                {
                    taraf.ILK_GIDERLER += pesinHarc * sorumlulukOran;
                    taraf.PESIN_HARC = pesinHarc * sorumlulukOran;
                    IcraHarcKalemiEkleGetir(taraf, MuhasebeAltKategoriId.PEÞÝN_HARÇ, taraf.PESIN_HARC,
                                            foy.TAKIP_TARIHI.Value);
                    mAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                        IcraMasrafAvansGetir(pesinHarc * sorumlulukOran, 629, 1, foy.TAKIP_TARIHI.Value, foy.SEGMENT_ID));
                }
                if (ilkTebligatGideri * sorumlulukOran > 0)
                {
                    taraf.ILK_GIDERLER += ilkTebligatGideri * sorumlulukOran;
                    taraf.ILK_TEBLIGAT_GIDERI = ilkTebligatGideri * sorumlulukOran;
                    IcraHarcKalemiEkleGetir(taraf, MuhasebeAltKategoriId.iLK_TEBLiGAT_GiDERi, taraf.ILK_TEBLIGAT_GIDERI,
                                            foy.TAKIP_TARIHI.Value);
                    mAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(
                        IcraMasrafAvansGetir(ilkTebligatGideri * sorumlulukOran, 568, 1, foy.TAKIP_TARIHI.Value, foy.SEGMENT_ID));
                }
                taraf.ILK_GIDERLER += ilkTebligatGideri;
                taraf.ILK_TEBLIGAT_GIDERI = ilkTebligatGideri;
                taraf.ILK_GIDERLER_DOVIZ_ID = 1;

                #region Vekalet ücreti taraf

                //Maktu
                if (foy.TAKIP_TALEP_IDSource.VEKALET_UCRETI_MAKTU_MU && foy.TAKIP_TALEP_IDSource.VEKALET_UCRETI_MAKTU_KOD_ID.HasValue)
                {
                    ParaVeDovizId pvd = VekaletTutariGetir(foy.TAKIP_TARIHI.Value,
                                                           foy.TAKIP_TALEP_IDSource.VEKALET_UCRETI_MAKTU_KOD_ID.Value);
                    taraf.TAKIP_VEKALET_UCRETI = pvd.Para * sorumlulukOran; //
                    AvukatProLib2.Entities.AV001_TI_BIL_VEKALET_UCRET vekUc = VekaletUcretiGetir(new ParaVeDovizId(0, 1), foy.TAKIP_TARIHI.Value, VekaletUcretKalemi.MaktuTakipVekUcrTaraf, new ParaVeDovizId(taraf.TAKIP_VEKALET_UCRETI, pvd.DovizId), 0, VekaketUcretTipNo.Maktu, foy.SON_HESAP_TARIHI);

                    taraf.AV001_TI_BIL_VEKALET_UCRETCollection.Add(vekUc);
                    taraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID = pvd.DovizId;
                }

                else //Nispi
                {
                    taraf.TAKIP_VEKALET_UCRETI = NispiVekaletUcretiHesapla(foy, taraf);
                    taraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID = 1;
                }

                #endregion Vekalet ücreti taraf

                foreach (var detay in mAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                {
                    detay.MUVEKKIL_CARI_ID = taraf.CARI_ID;
                    detay.BIRIM_FIYAT = -detay.BIRIM_FIYAT;
                    detay.TOPLAM_TUTAR = -detay.TOPLAM_TUTAR;
                    detay.GENEL_TOPLAM = detay.TOPLAM_TUTAR + detay.KDV_TUTAR + detay.STOPAJ_SSDF_TUTAR;
                    detay.ODEME_TIP_ID = (int)AvukatProLib.Extras.OdemeTip.NAKÝT;
                }
            }

            #endregion TarafBazýnda ÝlkGiderler

            //AV001_TDI_BIL_MASRAF_AVANS mav = foy.AV001_TDI_BIL_MASRAF_AVANSCollection.AddNew();
            //mav.MANUEL_KAYIT_MI = false;

            //foy.AV001_TDI_BIL_MASRAF_AVANSCollection.Add(avans);
            // ÝLKTEBLIGATGIDERI ++
            foy.VEKALET_HARCI = vekaletHarci;
            foy.VEKALET_PULU = vekaletPulu;
            foy.IFLAS_BASVURMA_HARCI = iflasBasvurmaHarci;
            foy.IFLASIN_ACILMASI_HARCI = iflasinAcilmasiHarci;

            if (foy.ID != 0)
            {
                foy.PESIN_HARC = pesinHarc;
                foy.BASVURMA_HARCI = basvurmaHarci;
                foy.ILK_TEBLIGAT_GIDERI = ilkTebligatGideri * takipEdilenSayisi;
            }
            foy.ILK_GIDERLER = foy.BASVURMA_HARCI + vekaletHarci + vekaletPulu + iflasBasvurmaHarci + iflasinAcilmasiHarci + foy.PESIN_HARC + foy.ILK_TEBLIGAT_GIDERI;
            foy.ILK_GIDERLER_DOVIZ_ID = 1;

            //mav.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(IcraMasrafAvansGetir(basvurmaHarci, (int)MuhasebeAltKategoriId.BAÞVURMA_HARCI, 1));
            //mav.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(IcraMasrafAvansGetir(vekaletHarci, (int)MuhasebeAltKategoriId.VEKALET_HARCI, 1));
            //mav.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(IcraMasrafAvansGetir(vekaletPulu, (int)MuhasebeAltKategoriId.VEKALET_PULU, 1));
            //mav.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(IcraMasrafAvansGetir(iflasBasvurmaHarci, (int)MuhasebeAltKategoriId.ÝFLAS_BAÞVURMA_HARCI, 1));
            //mav.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(IcraMasrafAvansGetir(iflasinAcilmasiHarci, 451, 1));
            //mav.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(IcraMasrafAvansGetir(pesinHarc, (int)MuhasebeAltKategoriId.PEÞÝN_HARÇ, 1));
            //mav.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(IcraMasrafAvansGetir(ilkTebligatGideri, (int)MuhasebeAltKategoriId.iLK_TEBLiGAT_GiDERi, takipEdilenSayisi));
        }

        /// <summary>
        /// Tüm müvekkillere paylaþtýr...
        /// </summary>
        /// <param name="tutar"></param>
        /// <param name="altKategoriId"></param>
        /// <param name="adet"></param>
        /// <returns></returns>
        public static AV001_TDI_BIL_MASRAF_AVANS_DETAY IcraMasrafAvansGetir(decimal tutar, int altKategoriId, int adet, DateTime foyTakipTarihi, int? segmentID)
        {
            return IcraMasrafAvansGetir(tutar, altKategoriId, adet, true, foyTakipTarihi, segmentID);
        }

        /// <summary>
        /// Masraf Avans Kalemi üretir ve getirir.
        /// </summary>
        /// <param name="tutar"></param>
        /// <param name="altKategoriId"></param>
        /// <param name="adet"></param>
        /// <param name="tumMuvekkillerePaylastir"></param>
        /// <returns></returns>
        public static AV001_TDI_BIL_MASRAF_AVANS_DETAY IcraMasrafAvansGetir(decimal tutar, int altKategoriId, int adet, bool tumMuvekkillerePaylastir, DateTime foyTakipTarihi, int? segmentID)
        {
            AV001_TDI_BIL_MASRAF_AVANS_DETAY dty = new AV001_TDI_BIL_MASRAF_AVANS_DETAY();
            if (segmentID.HasValue)
                dty.SEGMENT_ID = segmentID;
            dty.TUM_MUVEKKILLERE_PAYLASTIR = tumMuvekkillerePaylastir;
            dty.HAREKET_ALT_KATEGORI_ID = altKategoriId;
            TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI altKate =
                DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByID(altKategoriId);
            if (altKate != null)
            {
                dty.HAREKET_ANA_KATEGORI_ID = altKate.ANA_KATEGORI_ID;
                dty.TS_HESAP_CETVEL_YERI = altKate.TS_HESAP_CETVEL_YERI.HasValue ? Convert.ToByte(altKate.TS_HESAP_CETVEL_YERI.Value) : Convert.ToByte(0);
                dty.TO_HESAP_CETVEL_YERI = altKate.TO_HESAP_CETVEL_YERI.HasValue ? Convert.ToByte(altKate.TO_HESAP_CETVEL_YERI.Value) : Convert.ToByte(0);
            }
            dty.INCELENDI = false;
            dty.BORC_ALACAK_ID = 2;
            dty.KLASOR_KODU = "GENEL";
            dty.KONTROL_KIM = "AVUKATPRO";
            dty.KONTROL_NE_ZAMAN = DateTime.Now;
            dty.KONTROL_VERSIYON = 1;
            dty.KAYIT_TARIHI = DateTime.Now;
            dty.STAMP = 1;

            dty.SUBE_KODU = 1;
            dty.ADET = adet;
            dty.BIRIM_FIYAT = tutar;
            dty.BIRIM_FIYAT_DOVIZ_ID = 1;
            dty.TOPLAM_TUTAR = dty.BIRIM_FIYAT * dty.ADET;
            dty.TARIH = foyTakipTarihi;
            return dty;
        }

        /// <summary>
        /// Icra modülü için sabit faiz hesaplar ve AV001_TI_BIL_FAIZ tipinde geri döndürür
        /// </summary>
        /// <seealso cref="IcraDegiskenFaizHesapla(int,DateTime,DateTime,decimal,int,int)"/>
        /// <param name="faizTipId">Sabit faizin tipi</param>
        /// <param name="baslangicT">Faiz baþlangýç tarihi</param>
        /// <param name="bitisT">Faiz bitiþ tarihi</param>
        /// <param name="tutar">Faiz hesaplanacak tutar</param>
        /// <param name="dovizTipId">Faiz hesaplanacak <paramref name="tutar"/> birimi</param>
        /// <param name="birYilKacGun">Bir yilin kaç gün olduðu</param>
        /// <param name="oran">Faiz oraný</param>
        /// <returns>Hesaplanmýþ faizi AV001_TI_BIl_FAIZ tipinde geri döndürür</returns>
        public static AV001_TI_BIL_FAIZ IcraSabitFaizHesapla(int faizTipId, DateTime baslangicT, DateTime bitisT, decimal tutar, int dovizTipId, int birYilKacGun, double oran)
        {
            AV001_TI_BIL_FAIZ fk = new AV001_TI_BIL_FAIZ();
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

        public static AV001_TI_BIL_FAIZ IcraSabitFaizHesapla(int faizTipId, DateTime baslangicT, DateTime bitisT, decimal tutar, int dovizTipId, int birYilKacGun, double oran, FaizKalem kalemId)
        {
            AV001_TI_BIL_FAIZ result =
                IcraSabitFaizHesapla(faizTipId, baslangicT, bitisT, tutar, dovizTipId, birYilKacGun, oran);
            result.FAIZ_KALEM_ID = (int)kalemId;
            return result;
        }

        /// <summary>
        /// Taraflarýn tüm alacak nedenlerindeki taraflarýn sorumluluklarýnýn toplamýný getirir bu method verisi ile yapýlan hesaplarda alacak neden taraf larýndaki hesaplanmýþ deðerleri tekrar toplamaya gerek yoktur..
        /// </summary>
        /// <param name="cariId">Takip Edilen Cari ID</param>
        /// <param name="foy">Takip Edilenin bulunacaðý foy id Üzerinde AV001_TI_BIL_ALACAK_NEDENCollection bulunmasý ve bu collection içerisinde AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection olmasý gerekir</param>
        /// <exception cref="NullReferenceException"></exception>
        /// <returns></returns>
        public static double IcraSorumlulukOraniGetirByCariId(int cariId, AV001_TI_BIL_FOY foy)
        {
            TList<AV001_TI_BIL_ALACAK_NEDEN> gayriNakitsizler = GayriNakitleriCikar(foy);
            double sorumlulukOrani = 0;
            foreach (AV001_TI_BIL_ALACAK_NEDEN ndn in gayriNakitsizler)  //foy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                #region dönüyor..

                #region //

                //if (ndn.ISLEME_KONAN_TUTAR == 0)
                //{
                //    //uygulama alanlarý kontrolden geçirildi ve iþleme konan tutarýn sorumluluk oranlarý hesabýndaki 0 karþýlýðý 1 olarak deðiþtirildi, (gkn)
                //    //throw new InvalidOperationException("ISLEME_KONAN_TUTAR alaný sýfýr olamaz, Column ISLEME_KONAN_TUTAR can not be zero");
                //}
                //if (foy.ASIL_ALACAK == 0)
                //{
                //    //uygulama alanlarý kontrolden geçirildi ve Asýl alacaðýn  sorumluluk oranlarý hesabýnda ki 0 karþýlýðý 1 olarak deðiþtirildi, (gkn)
                //   // throw new InvalidOperationException("ASIL_ALACAK alaný sýfýr olamaz, Column ASIL_ALACAK can not be zero");

                //}

                #endregion //

                decimal asilAlacakTl = DovizHelper.CevirYTL(foy.ASIL_ALACAK, foy.ASIL_ALACAK_DOVIZ_ID, foy.TAKIP_TARIHI.Value);
                if (asilAlacakTl < 1) asilAlacakTl = 1;

                DovizHelper.GetMerkezBankasiBilgisi(ndn.ALACAK_NEDEN_KOD_ID);
                decimal islemeKonanTl = DovizHelper.CevirYTL(ndn.ISLEME_KONAN_TUTAR, ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value, foy.TAKIP_TARIHI.Value, ndn.ALACAK_NEDEN_KOD_ID);
                if (islemeKonanTl < 1) islemeKonanTl = 1;

                double nedenSorumlulukOrani = (double)(islemeKonanTl / asilAlacakTl);

                foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF trf in ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                {
                    if (trf.TARAF_CARI_ID == cariId)
                    {
                        if (trf.SORUMLU_OLUNAN_MIKTAR == ndn.ISLEME_KONAN_TUTAR &&
                            trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID == ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID)
                        {
                            trf.SORUMLULUK_ORANI = 1;
                        }
                        else
                        {
                            decimal trfSorumluOlunanMiktar = DovizHelper.CevirYTL(trf.SORUMLU_OLUNAN_MIKTAR.Value,
                                                                                    trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID
                                                                                    , foy.TAKIP_TARIHI.Value, ndn.ALACAK_NEDEN_KOD_ID);

                            if (trfSorumluOlunanMiktar < 1) trfSorumluOlunanMiktar = 1;
                            trf.SORUMLULUK_ORANI = (double)(trfSorumluOlunanMiktar / islemeKonanTl);

                            #region //

                            /*
                                trf.SORUMLULUK_ORANI = (double)(
                                                                   DovizHelper.CevirYTL(trf.SORUMLU_OLUNAN_MIKTAR,
                                                                                        trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID
                                                                                        , foy.TAKIP_TARIHI.Value) /
                                                                   DovizHelper.CevirYTL(ndn.ISLEME_KONAN_TUTAR,
                                                                                        ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID.
                                                                                            Value,
                                                                                        foy.TAKIP_TARIHI.Value));
                                 */

                            #endregion //
                        }
                        sorumlulukOrani += trf.SORUMLULUK_ORANI.Value * nedenSorumlulukOrani;
                    }
                }

                #endregion dönüyor..
            }

            return sorumlulukOrani;
        }

        public static double IcraSorumlulukOraniGetirByCariIdGayriNakit(int cariId, AV001_TI_BIL_FOY foy)
        {
            TList<AV001_TI_BIL_ALACAK_NEDEN> gayriNakitsizler = GayriNakitAlacakNedenleri(foy.AV001_TI_BIL_ALACAK_NEDENCollection);
            double sorumlulukOrani = 0;
            foreach (AV001_TI_BIL_ALACAK_NEDEN ndn in gayriNakitsizler)  //foy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                #region dönüyor..

                if (ndn.ISLEME_KONAN_TUTAR == 0)
                {
                    throw new InvalidOperationException("ISLEME_KONAN_TUTAR alaný sýfýr olamaz, Column ISLEME_KONAN_TUTAR can not be zero");
                }
                if (foy.GAYRI_NAKTI_ALACAK == 0)
                {
                    throw new InvalidOperationException("GAYRI_NAKTI_ALACAK alaný sýfýr olamaz, Column ASIL_ALACAK can not be zero");
                }

                DovizHelper.GetMerkezBankasiBilgisi(ndn.ALACAK_NEDEN_KOD_ID);

                double nedenSorumlulukOrani =
                    (double)
                    (DovizHelper.CevirYTL(ndn.ISLEME_KONAN_TUTAR, ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                                          foy.TAKIP_TARIHI.Value, ndn.ALACAK_NEDEN_KOD_ID) /
                     DovizHelper.CevirYTL(foy.GAYRI_NAKTI_ALACAK, foy.GAYRI_NAKTI_ALACAK_DOVIZ_ID.Value,
                                          foy.TAKIP_TARIHI.Value));

                foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF trf in ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                {
                    if (trf.TARAF_CARI_ID == cariId)
                    {
                        if (trf.SORUMLU_OLUNAN_MIKTAR == ndn.ISLEME_KONAN_TUTAR &&
                            trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID == ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID)
                        {
                            trf.SORUMLULUK_ORANI = 1;
                        }
                        else
                        {
                            DovizHelper.GetMerkezBankasiBilgisi(trf);

                            trf.SORUMLULUK_ORANI = (double)(
                                                               DovizHelper.CevirYTL(trf.SORUMLU_OLUNAN_MIKTAR,
                                                                                    trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID
                                                                                    , foy.TAKIP_TARIHI.Value) /
                                                               DovizHelper.CevirYTL(ndn.ISLEME_KONAN_TUTAR,
                                                                                    ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID.
                                                                                        Value,
                                                                                    foy.TAKIP_TARIHI.Value));
                        }
                        sorumlulukOrani += trf.SORUMLULUK_ORANI.Value * nedenSorumlulukOrani;
                    }
                }

                #endregion dönüyor..
            }

            return sorumlulukOrani;
        }

        /// <summary>
        /// Icra foyü üzerine tazminat hesaplar. Öncelikle takipönceis hesaplanmalýdýr aksi takdirde sadece takip öncesi kalemler kalacaktýr
        /// </summary>
        /// <param name="mFoy">Hesaplanacak foy instance i</param>
        /// <param name="neZaman">Hesap aralýðý</param>
        public static void IcraTazminatHesapla(AV001_TI_BIL_FOY mFoy, Takip neZaman)
        {
            if (neZaman == Takip.Oncesi)
            {
                mFoy.AV001_TI_BIL_TAZMINATCollection.Clear();
                mFoy.AV001_TI_BIL_ALACAK_NEDENCollection.ForEach(delegate
                                                                     (AV001_TI_BIL_ALACAK_NEDEN obj)
                {
                    obj.AV001_TI_BIL_TAZMINATCollection.Clear();
                }
                    );
            }
            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in mFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                if (neden.HER_AY_TAZMINAT_EKLE)
                {
                    TList<AV001_TI_BIL_TAZMINAT> tazminat = null;
                    if (neZaman == Takip.Oncesi)
                    {
                        tazminat = TazminatKalemiHesaplaGetir(neden.VADE_TARIHI.Value, mFoy.TAKIP_TARIHI.Value,
                                                              neden.ISLEME_KONAN_TUTAR,
                                                              neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                                                              mFoy.BIR_YIL_KAC_GUN, neden.TAZMINAT_FAIZ_ORANI,
                                                              neZaman, neden.ID);
                    }
                    else if (neZaman == Takip.Sonrasi)
                    {
                        tazminat = TazminatKalemiHesaplaGetir(mFoy.TAKIP_TARIHI.Value, mFoy.SON_HESAP_TARIHI.Value,
                                                              neden.ISLEME_KONAN_TUTAR,
                                                              neden.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                                                              mFoy.BIR_YIL_KAC_GUN, neden.TAZMINAT_FAIZ_ORANI,
                                                              neZaman, neden.ID);
                    }
                    if (tazminat != null)
                    {
                        foreach (var item in tazminat)
                        {
                            neden.AV001_TI_BIL_TAZMINATCollection.Add(item);
                            mFoy.AV001_TI_BIL_TAZMINATCollection.Add(item);
                        }
                    }
                }
            }
        }

        public static void IcraTazminatlariFoyUzerineYaz(AV001_TI_BIL_FOY mFoy)
        {
            mFoy.TO_YONETIMG_TAZMINATI = 0;
            mFoy.SONRAKI_TAZMINAT = 0;

            foreach (AV001_TI_BIL_TAZMINAT tazminat in mFoy.AV001_TI_BIL_TAZMINATCollection)
            {
                if (tazminat.TAZMINAT_TAKIPDEN_ONCE_MI)
                {
                    mFoy.TO_YONETIMG_TAZMINATI += DovizHelper.CevirYTL(tazminat.TAZMINAT_TUTARI,
                                                                       tazminat.TAZMINAT_TUTARI_DOVIZ_ID,
                                                                       mFoy.TAKIP_TARIHI.Value);
                }
                else
                {
                    mFoy.SONRAKI_TAZMINAT += DovizHelper.CevirYTL(tazminat.TAZMINAT_TUTARI,
                                                                  tazminat.TAZMINAT_TUTARI_DOVIZ_ID,
                                                                  mFoy.TAKIP_TARIHI.Value);
                }
            }
            foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
            {
                if (!taraf.TAKIP_EDEN_MI)
                {
                    taraf.SONRAKI_TAZMINAT = mFoy.SONRAKI_TAZMINAT * (decimal)taraf.SORUMLULUK_ORANI;
                    taraf.TO_YONETIMG_TAZMINATI = mFoy.TO_YONETIMG_TAZMINATI * (decimal)taraf.SORUMLULUK_ORANI;
                }
            }
        }

        public static void IcraToplamKalemleriHesapla(AV001_TI_BIL_FOY mFoy)
        {
            mFoy.TO_MASRAF_TOPLAMI = DovizHelper.CevirYTL(mFoy.IHTAR_GIDERI, mFoy.IHTAR_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value)
                                     + DovizHelper.CevirYTL(mFoy.PROTESTO_GIDERI, mFoy.PROTESTO_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value) +
                                     DovizHelper.CevirYTL(mFoy.DAMGA_PULU, mFoy.DAMGA_PULU_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value);
            mFoy.TO_MASRAF_TOPLAMI_DOVIZ_ID = 1;
            mFoy.TO_ODEME_MAHSUP_TOPLAMI = DovizHelper.CevirYTL(mFoy.IT_HACIZDE_ODENEN, mFoy.IT_HACIZDE_ODENEN_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value) +
                                           DovizHelper.CevirYTL(mFoy.MAHSUP_TOPLAMI, mFoy.MAHSUP_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value) +
                                           DovizHelper.CevirYTL(mFoy.TO_ODEME_TOPLAMI, mFoy.TO_ODEME_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value);
            mFoy.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = 1;
            mFoy.TS_MASRAF_TOPLAMI = DovizHelper.CevirYTL(mFoy.ILK_GIDERLER, mFoy.ILK_GIDERLER_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value) +
                                     DovizHelper.CevirYTL(mFoy.TD_GIDERI, mFoy.TD_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value) +
                                     DovizHelper.CevirYTL(mFoy.TD_TEBLIG_GIDERI, mFoy.TD_TEBLIG_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value) +
                                     DovizHelper.CevirYTL(mFoy.DAVA_GIDERLERI, mFoy.DAVA_GIDERLERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value) +
                                     DovizHelper.CevirYTL(mFoy.DIGER_GIDERLER, mFoy.DIGER_GIDERLER_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value);
            mFoy.TS_MASRAF_TOPLAMI_DOVIZ_ID = 1;
            mFoy.TS_VEKALET_TOPLAMI = DovizHelper.CevirYTL(mFoy.TAKIP_VEKALET_UCRETI, mFoy.TAKIP_VEKALET_UCRETI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value) +
                                      DovizHelper.CevirYTL(mFoy.TAHLIYE_VEK_UCR, mFoy.TAHLIYE_VEK_UCR_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value) +
                                      DovizHelper.CevirYTL(mFoy.TD_VEK_UCR, mFoy.TD_VEK_UCR_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value) +
                                      DovizHelper.CevirYTL(mFoy.DAVA_VEKALET_UCRETI, mFoy.DAVA_VEKALET_UCRETI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value);
            mFoy.TS_VEKALET_TOPLAMI_DOVIZ_ID = 1;
            mFoy.HARC_TOPLAMI = DovizHelper.CevirYTL(mFoy.ODENEN_TAHSIL_HARCI, mFoy.ODENEN_TAHSIL_HARCI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value) +
                                DovizHelper.CevirYTL(mFoy.DIGER_HARC, mFoy.DIGER_HARC_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value) +
                                DovizHelper.CevirYTL(mFoy.TD_BAKIYE_HARC, mFoy.TD_BAKIYE_HARC_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value) +
                                DovizHelper.CevirYTL(mFoy.PAYLASMA_HARCI, mFoy.PAYLASMA_HARCI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value) +
                                DovizHelper.CevirYTL(mFoy.MASAYA_KATILMA_HARCI, mFoy.MASAYA_KATILMA_HARCI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value);
            mFoy.HARC_TOPLAMI_DOVIZ_ID = 1;

            foreach (AV001_TI_BIL_FOY_TARAF var in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
            {
                var.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = 1;
                var.TO_ODEME_MAHSUP_TOPLAMI = DovizHelper.CevirYTL(var.IT_HACIZDE_ODENEN, var.IT_HACIZDE_ODENEN_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value) +
                                              DovizHelper.CevirYTL(var.TO_ODEME_TOPLAMI, var.TO_ODEME_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value) +
                                              DovizHelper.CevirYTL(var.MAHSUP_TOPLAMI, var.MAHSUP_TOPLAMI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value);

                var.TO_MASRAF_TOPLAMI = DovizHelper.CevirYTL(var.IHTAR_GIDERI, var.IHTAR_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value) +
                                        DovizHelper.CevirYTL(var.PROTESTO_GIDERI, var.PROTESTO_GIDERI_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value) +
                                        DovizHelper.CevirYTL(var.DAMGA_PULU, var.DAMGA_PULU_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value);
            }
        }

        public static void IcraVekaletUcretiKatsayiHesapla(AV001_TI_BIL_FOY mFoy)
        {
            mFoy.TAKIP_VEKALET_UCRETI = (decimal)mFoy.TAKIP_VEKALET_UCRETI_KATSAYI * mFoy.TAKIP_VEKALET_UCRETI;
        }

        public static ParaVeDovizId IhtiyatiBasvurmaHarciGetir(DateTime gecerlilikT, string adliBirimBolumKod)
        {
            return DavaHarcTutarGetir(gecerlilikT, String.Format("{0} BAÞVURMA HARCI", adliBirimBolumKod));
        }

        //public static ParaVeDovizId VekaletTutariGetir
        public static ParaVeDovizId IhtiyatiKararVeIlamHarciGetir(DateTime gecerlilikT, string adliBirimBolumKod)
        {
            return DavaHarcTutarGetir(gecerlilikT, String.Format("{0} KARAR VE ÝLAM HARCI", adliBirimBolumKod));
        }

        /// <summary>
        /// Takip Öncesi Ýlam faizi
        /// </summary>
        /// <param name="ilam"></param>
        /// <param name="bitisT"></param>
        /// <param name="birYilKacGun"></param>
        [Obsolete("Bunun yerine diger overload unu kullan Bu Mahsupsuz", true)]
        public static void IlamMahkemesiFaizHesapla(AV001_TI_BIL_ILAM_MAHKEMESI ilam, DateTime bitisT, int birYilKacGun)
        {
            if (ilam.KARAR_TARIHI.HasValue)
            {
                ilam.AV001_TI_BIL_FAIZCollection = new TList<AV001_TI_BIL_FAIZ>();

                if (ilam.INKAR_TAZMINAT_FAIZ_ISLESIN_MI)
                    ilam.AV001_TI_BIL_FAIZCollection.AddRange(
                        IcraDegiskenFaizHesapla(ilam.INKAR_TAZMINAT_FAIZ_TIP_ID.Value, ilam.KARAR_TARIHI.Value, bitisT,
                        ilam.INKAR_TAZMINATI.HasValue ? ilam.INKAR_TAZMINATI.Value : 0, ilam.INKAR_TAZMINATI_DOVIZ_ID.Value, birYilKacGun,
                                                FaizKalem.ÝNKAR_TAZMÝNATI));

                if (ilam.YARGILAMA_GIDERI_FAIZ_ISLESIN_MI)
                    ilam.AV001_TI_BIL_FAIZCollection.AddRange(
                        IcraDegiskenFaizHesapla(ilam.YARGILAMA_GIDERI_FAIZ_TIP_ID.Value, ilam.KARAR_TARIHI.Value, bitisT,
                        ilam.YARGILAMA_GIDERI.HasValue ? ilam.YARGILAMA_GIDERI.Value : 0, ilam.YARGILAMA_GIDERI_DOVIZ_ID.Value, birYilKacGun,
                                                FaizKalem.YARGILAMA_GÝDERLERÝ));

                if (ilam.BAKIYE_KARAR_HARCI_FAIZ_ISLESIN_MI)
                    ilam.AV001_TI_BIL_FAIZCollection.AddRange(
                        IcraDegiskenFaizHesapla(ilam.BAKIYE_KARAR_HARCI_FAIZ_TIP_ID.Value, ilam.KARAR_TARIHI.Value, bitisT,
                        ilam.BAKIYE_KARAR_HARCI.HasValue ? ilam.BAKIYE_KARAR_HARCI.Value : 0, ilam.BAKIYE_KARAR_HARCI_DOVIZ_ID.Value, birYilKacGun,
                                                FaizKalem.BAKÝYE_KARAR_HARCI));

                if (ilam.YARGITAY_ONAMA_HARCI_FAIZ_ISLESIN_MI)
                    ilam.AV001_TI_BIL_FAIZCollection.AddRange(
                        IcraDegiskenFaizHesapla(ilam.YARGITAY_ONAMA_HARCI_FAIZ_TIP_ID.Value, ilam.KARAR_TARIHI.Value, bitisT,
                        ilam.YARGITAY_ONAMA_HARCI.HasValue ? ilam.YARGITAY_ONAMA_HARCI.Value : 0, ilam.YARGITAY_ONAMA_HARCI_DOVIZ_ID.Value, birYilKacGun,
                                                FaizKalem.YARGITAY_ONAMA_HARCI));

                if (ilam.ILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI)
                    ilam.AV001_TI_BIL_FAIZCollection.AddRange(
                        IcraDegiskenFaizHesapla(ilam.ILAM_VEKALET_UCRET_FAIZ_TIP_ID.Value, ilam.KARAR_TARIHI.Value, bitisT,
                        ilam.ILAM_VEKALET_UCRETI.HasValue ? ilam.ILAM_VEKALET_UCRETI.Value : 0, ilam.ILAM_VEKALET_UCRETI_DOVIZ_ID.Value, birYilKacGun,
                                                FaizKalem.ÝLAM_VEKALET_ÜCRETÝ));

                if (ilam.ILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI)
                    ilam.AV001_TI_BIL_FAIZCollection.AddRange(
                        IcraDegiskenFaizHesapla(ilam.ILAM_TEBLIG_GIDER_FAIZ_TIP_ID.Value, ilam.KARAR_TARIHI.Value, bitisT,
                        ilam.ILAM_TEBLIG_GIDERI.HasValue ? ilam.ILAM_TEBLIG_GIDERI.Value : 0, ilam.ILAM_TEBLIG_GIDERI_DOVIZ_ID.Value, birYilKacGun,
                                                FaizKalem.ÝLAM_TEBLÝÐ_GÝDERLERÝ));
            }
        }

        /// <summary>
        /// Takip Öncesi Ýlam faizi (mahsuplu)
        /// </summary>
        /// <param name="ilam"></param>
        public static void IlamMahkemesiFaizHesapla(AV001_TI_BIL_ILAM_MAHKEMESI ilam, AV001_TI_BIL_FOY foy, Takip neZaman)
        {
            if (ilam.KARAR_TARIHI.HasValue)
            {
                ilam.AV001_TI_BIL_FAIZCollection = new TList<AV001_TI_BIL_FAIZ>();

                if (neZaman == Takip.Oncesi)
                {
                    DateTime bitisT = foy.TAKIP_TARIHI.Value;
                    if (ilam.INKAR_TAZMINAT_FAIZ_ISLESIN_MI)
                        ilam.AV001_TI_BIL_FAIZCollection.AddRange(
                            MahsupluFaizHesapla(false, foy, MahsupAltKategori.Ilam_Inkar_Tazminati, ilam.INKAR_TAZMINAT_FAIZ_TIP_ID.Value,
                                                ilam.KARAR_TARIHI.Value, bitisT, new ParaVeDovizId(ilam.INKAR_TAZMINATI, ilam.INKAR_TAZMINATI_DOVIZ_ID),
                                                FaizKalem.ÝNKAR_TAZMÝNATI, Takip.Oncesi, 0));

                    if (ilam.YARGILAMA_GIDERI_FAIZ_ISLESIN_MI)
                        ilam.AV001_TI_BIL_FAIZCollection.AddRange(
                            MahsupluFaizHesapla(false, foy, MahsupAltKategori.Ilam_Yargilama_Giderleri, ilam.YARGILAMA_GIDERI_FAIZ_TIP_ID.Value,
                                                ilam.KARAR_TARIHI.Value, bitisT, new ParaVeDovizId(ilam.YARGILAMA_GIDERI, ilam.YARGILAMA_GIDERI_DOVIZ_ID),
                                                FaizKalem.YARGILAMA_GÝDERLERÝ, Takip.Oncesi, 0));

                    if (ilam.BAKIYE_KARAR_HARCI_FAIZ_ISLESIN_MI)
                        ilam.AV001_TI_BIL_FAIZCollection.AddRange(
                            MahsupluFaizHesapla(false, foy, MahsupAltKategori.Ilam_Bakiye_Karar_Harci, ilam.BAKIYE_KARAR_HARCI_FAIZ_TIP_ID.Value,
                                                ilam.KARAR_TARIHI.Value, bitisT, new ParaVeDovizId(ilam.BAKIYE_KARAR_HARCI, ilam.BAKIYE_KARAR_HARCI_DOVIZ_ID),
                                                FaizKalem.BAKÝYE_KARAR_HARCI, Takip.Oncesi, 0));

                    if (ilam.YARGITAY_ONAMA_HARCI_FAIZ_ISLESIN_MI)
                        ilam.AV001_TI_BIL_FAIZCollection.AddRange(
                            MahsupluFaizHesapla(false, foy, MahsupAltKategori.Yargitay_Onama_Harci, ilam.YARGITAY_ONAMA_HARCI_FAIZ_TIP_ID.Value,
                                                ilam.KARAR_TARIHI.Value, bitisT, new ParaVeDovizId(ilam.YARGITAY_ONAMA_HARCI, ilam.YARGITAY_ONAMA_HARCI_DOVIZ_ID),
                                                FaizKalem.YARGITAY_ONAMA_HARCI, Takip.Oncesi, 0));

                    if (ilam.ILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI)
                        ilam.AV001_TI_BIL_FAIZCollection.AddRange(
                            MahsupluFaizHesapla(false, foy, MahsupAltKategori.Ilam_Vekalet_Ucreti, ilam.ILAM_VEKALET_UCRET_FAIZ_TIP_ID.Value,
                                                ilam.KARAR_TARIHI.Value, bitisT, new ParaVeDovizId(ilam.ILAM_VEKALET_UCRETI, ilam.ILAM_VEKALET_UCRETI_DOVIZ_ID),
                                                FaizKalem.ÝLAM_VEKALET_ÜCRETÝ, Takip.Oncesi, 0));

                    if (ilam.ILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI)
                        ilam.AV001_TI_BIL_FAIZCollection.AddRange(
                            MahsupluFaizHesapla(false, foy, MahsupAltKategori.Ilam_Teblig_Gideri, ilam.ILAM_TEBLIG_GIDER_FAIZ_TIP_ID.Value,
                                                ilam.KARAR_TARIHI.Value, bitisT, new ParaVeDovizId(ilam.ILAM_TEBLIG_GIDERI, ilam.ILAM_TEBLIG_GIDERI_DOVIZ_ID),
                                                FaizKalem.ÝLAM_TEBLÝÐ_GÝDERLERÝ, Takip.Oncesi, 0));
                }
                else if (neZaman == Takip.Sonrasi)
                {
                    DateTime bitisT = foy.SON_HESAP_TARIHI.Value;
                    if (ilam.INKAR_TAZMINAT_FAIZ_ISLESIN_MI)
                        ilam.AV001_TI_BIL_FAIZCollection.AddRange(
                            MahsupluFaizHesapla(false, foy, MahsupAltKategori.Ilam_Inkar_Tazminati, ilam.INKAR_TAZMINAT_FAIZ_TIP_ID.Value,
                                                foy.TAKIP_TARIHI.Value, bitisT, new ParaVeDovizId(ilam.INKAR_TAZMINATI, ilam.INKAR_TAZMINATI_DOVIZ_ID),
                                                FaizKalem.ÝNKAR_TAZMÝNATI, Takip.Sonrasi, 0));

                    if (ilam.YARGILAMA_GIDERI_FAIZ_ISLESIN_MI)
                        ilam.AV001_TI_BIL_FAIZCollection.AddRange(
                            MahsupluFaizHesapla(false, foy, MahsupAltKategori.Ilam_Yargilama_Giderleri, ilam.YARGILAMA_GIDERI_FAIZ_TIP_ID.Value,
                                                foy.TAKIP_TARIHI.Value, bitisT, new ParaVeDovizId(ilam.YARGILAMA_GIDERI, ilam.YARGILAMA_GIDERI_DOVIZ_ID),
                                                FaizKalem.YARGILAMA_GÝDERLERÝ, Takip.Sonrasi, 0));

                    if (ilam.BAKIYE_KARAR_HARCI_FAIZ_ISLESIN_MI)
                        ilam.AV001_TI_BIL_FAIZCollection.AddRange(
                            MahsupluFaizHesapla(false, foy, MahsupAltKategori.Ilam_Bakiye_Karar_Harci, ilam.BAKIYE_KARAR_HARCI_FAIZ_TIP_ID.Value,
                                                foy.TAKIP_TARIHI.Value, bitisT, new ParaVeDovizId(ilam.BAKIYE_KARAR_HARCI, ilam.BAKIYE_KARAR_HARCI_DOVIZ_ID),
                                                FaizKalem.BAKÝYE_KARAR_HARCI, Takip.Sonrasi, 0));

                    if (ilam.YARGITAY_ONAMA_HARCI_FAIZ_ISLESIN_MI)
                        ilam.AV001_TI_BIL_FAIZCollection.AddRange(
                            MahsupluFaizHesapla(false, foy, MahsupAltKategori.Yargitay_Onama_Harci, ilam.YARGITAY_ONAMA_HARCI_FAIZ_TIP_ID.Value,
                                                foy.TAKIP_TARIHI.Value, bitisT, new ParaVeDovizId(ilam.YARGITAY_ONAMA_HARCI, ilam.YARGITAY_ONAMA_HARCI_DOVIZ_ID),
                                                FaizKalem.YARGITAY_ONAMA_HARCI, Takip.Sonrasi, 0));

                    if (ilam.ILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI)
                        ilam.AV001_TI_BIL_FAIZCollection.AddRange(
                            MahsupluFaizHesapla(false, foy, MahsupAltKategori.Ilam_Vekalet_Ucreti, ilam.ILAM_VEKALET_UCRET_FAIZ_TIP_ID.Value,
                                                foy.TAKIP_TARIHI.Value, bitisT, new ParaVeDovizId(ilam.ILAM_VEKALET_UCRETI, ilam.ILAM_VEKALET_UCRETI_DOVIZ_ID),
                                                FaizKalem.ÝLAM_VEKALET_ÜCRETÝ, Takip.Sonrasi, 0));

                    if (ilam.ILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI)
                        ilam.AV001_TI_BIL_FAIZCollection.AddRange(
                            MahsupluFaizHesapla(false, foy, MahsupAltKategori.Ilam_Teblig_Gideri, ilam.ILAM_TEBLIG_GIDER_FAIZ_TIP_ID.Value,
                                                foy.TAKIP_TARIHI.Value, bitisT, new ParaVeDovizId(ilam.ILAM_TEBLIG_GIDERI, ilam.ILAM_TEBLIG_GIDERI_DOVIZ_ID),
                                                FaizKalem.ÝLAM_TEBLÝÐ_GÝDERLERÝ, Takip.Sonrasi, 0));
                }
                foy.AV001_TI_BIL_FAIZCollection.AddRange(ilam.AV001_TI_BIL_FAIZCollection);
            }
        }

        public static ParaVeDovizId IlamMahkemesiFaizTutarBul(AV001_TI_BIL_ILAM_MAHKEMESI ilam, FaizKalem klm)
        {
            decimal result = 0;
            int dovizId = 1;

            foreach (AV001_TI_BIL_FAIZ obj in ilam.AV001_TI_BIL_FAIZCollection)
            {
                if (obj.FAIZ_KALEM_ID.HasValue && obj.FAIZ_KALEM_ID.Value == (int)klm)
                {
                    result += obj.FAIZ_TUTARI;
                    if (dovizId == 0 && obj.FAIZ_TUTARI_DOVIZ_ID.HasValue)
                        dovizId = obj.FAIZ_TUTARI_DOVIZ_ID.Value;
                }
            }

            return new ParaVeDovizId(result, dovizId);
        }

        public static void KalanHesapla(AV001_TI_BIL_FOY myFoy)
        {
            myFoy.KALAN_DOVIZ_ID = 1;
            DateTime zaman = DateTime.Now;

            if (myFoy.TAKIP_TARIHI != null)
                zaman = myFoy.TAKIP_TARIHI.Value;
            if (myFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Any(q => q.HESAPLAMA_MODU == 3))
                zaman = DateTime.Today;
            #region Alacak Toplamý Hesaplanýyor

            List<ParaVeDovizId> toplanacakAlacaklarListesi = new List<ParaVeDovizId>();
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.TAKIP_CIKISI, myFoy.TAKIP_CIKISI_DOVIZ_ID, zaman));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.SONRAKI_FAIZ, myFoy.SONRAKI_FAIZ_DOVIZ_ID, zaman));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.BSMV_TS, myFoy.BSMV_TS_DOVIZ_ID, zaman));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.OIV_TS, myFoy.OIV_TS_DOVIZ_ID, zaman));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.KDV_TS, myFoy.KDV_TS_DOVIZ_ID, zaman));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.SONRAKI_TAZMINAT, myFoy.SONRAKI_TAZMINAT_DOVIZ_ID, zaman));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.BIRIKMIS_NAFAKA, myFoy.BIRIKMIS_NAFAKA_DOVIZ_ID, zaman));
            if (myFoy.TS_MASRAF_TOPLAMI != null && myFoy.TS_MASRAF_TOPLAMI_DOVIZ_ID != null) toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.TS_MASRAF_TOPLAMI.Value, myFoy.TS_MASRAF_TOPLAMI_DOVIZ_ID.Value, zaman));
            if (myFoy.TS_VEKALET_TOPLAMI != null && myFoy.TS_VEKALET_TOPLAMI_DOVIZ_ID != null) toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.TS_VEKALET_TOPLAMI.Value, myFoy.TS_VEKALET_TOPLAMI_DOVIZ_ID.Value, zaman));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.ODENEN_TAHSIL_HARCI, myFoy.ODENEN_TAHSIL_HARCI_DOVIZ_ID, zaman));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.DIGER_HARC, myFoy.DIGER_HARC_DOVIZ_ID, zaman));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.TAHLIYE_HARCI, myFoy.TAHLIYE_HARCI_DOVIZ_ID, zaman));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.MASAYA_KATILMA_HARCI, myFoy.MASAYA_KATILMA_HARCI_DOVIZ_ID, zaman));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.PAYLASMA_HARCI, myFoy.PAYLASMA_HARCI_DOVIZ_ID, zaman));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.ICRA_INKAR_TAZMINATI, myFoy.ICRA_INKAR_TAZMINATI_DOVIZ_ID, zaman));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.DAVA_INKAR_TAZMINATI, myFoy.DAVA_INKAR_TAZMINATI_DOVIZ_ID, zaman));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.DEPO_VEKALET_UCRETI, myFoy.DEPO_VEKALET_UCRET_DOVIZ_ID, zaman));
            toplanacakAlacaklarListesi.Add(new ParaVeDovizId(myFoy.DEPO_HARCI, myFoy.DEPO_HARCI_DOVIZ_ID, zaman));

            ParaVeDovizId alacaklarToplami = ParalariTopla(toplanacakAlacaklarListesi, zaman);
            myFoy.ALACAK_TOPLAMI = alacaklarToplami.Para;
            myFoy.ALACAK_TOPLAMI_DOVIZ_ID = alacaklarToplami.DovizId;

            #endregion Alacak Toplamý Hesaplanýyor

            #region Kalan Toplamý Hesaplanýyor

            List<ParaVeDovizId> hesaplanacakKalanListesi = new List<ParaVeDovizId>();
            hesaplanacakKalanListesi.Add(new ParaVeDovizId(myFoy.ALACAK_TOPLAMI, myFoy.ALACAK_TOPLAMI_DOVIZ_ID, zaman));
            hesaplanacakKalanListesi.Add(new ParaVeDovizId(myFoy.FERAGAT_TOPLAMI, myFoy.FERAGAT_TOPLAMI_DOVIZ_ID, zaman));
            hesaplanacakKalanListesi.Add(new ParaVeDovizId(myFoy.ODEME_TOPLAMI, myFoy.ODEME_TOPLAMI_DOVIZ_ID, zaman));
            if (myFoy.BAKIYE_HARC_TOPLAMA_EKLE)
                hesaplanacakKalanListesi.Add(new ParaVeDovizId(myFoy.KALAN_TAHSIL_HARCI, myFoy.KALAN_TAHSIL_HARCI_DOVIZ_ID, zaman));

            ParaVeDovizId kalanToplami = ParalariTopla(hesaplanacakKalanListesi, zaman);

            myFoy.KALAN = kalanToplami.Para;
            myFoy.KALAN_DOVIZ_ID = kalanToplami.DovizId;

            List<ParaVeDovizId> gayriNaktiAlacaklar = new List<ParaVeDovizId>();

            gayriNaktiAlacaklar.Add(new ParaVeDovizId(myFoy.DEPO_VEKALET_UCRETI ?? 0, myFoy.DEPO_VEKALET_UCRET_DOVIZ_ID, zaman));
            gayriNaktiAlacaklar.Add(new ParaVeDovizId(myFoy.DEPO_HARCI ?? 0, myFoy.DEPO_HARCI_DOVIZ_ID, zaman));
            gayriNaktiAlacaklar.Add(new ParaVeDovizId(myFoy.GAYRI_NAKTI_ALACAK ?? 0, myFoy.GAYRI_NAKTI_ALACAK_DOVIZ_ID, zaman));

            ParaVeDovizId gayriNaktiToplami = ParaVeDovizId.Topla(gayriNaktiAlacaklar);

            myFoy.GAYRI_NAKIT_KALAN = gayriNaktiToplami.Para;
            myFoy.GAYRI_NAKIT_KALAN_DOVIZ_ID = gayriNaktiToplami.DovizId;

            #endregion Kalan Toplamý Hesaplanýyor
        }

        public static double KDVOraniGetir(int kdvKategoriId, DateTime tarih)
        {
            string query = String.Format("select top(1) KDV_ORAN from TDI_CET_KDV where KATEGORI_ID = {0} AND TARIH <= CONVERT(datetime, '{1}', 103) order by TARIH DESC", kdvKategoriId, tarih.ToShortDateString());
            var result = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, query);
            if (result == null) throw new Exception(kdvKategoriId + " sistem nolu Kategoride KDV bilgisi veri tabanýnda bulunamadý.");
            return Convert.ToDouble(result);
        }

        /// <summary>
        /// TDI_CET_VEKALET_NISPI tablosundan nispi vekalet hesaplamak için kullanýlan method hesaplanmýþ deðerleri verilen foy üzerinde ilgili yerlere yazar
        /// </summary>
        /// <returns></returns>
        public static decimal NispiVekaletUcretiHesapla(AV001_TI_BIL_FOY foy)
        {
            ParaVeDovizId takipsizTutari = new ParaVeDovizId(0, 1);
            if (foy.ID == 0)
            {
                var takipsizNedenler = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

                foy.AV001_TI_BIL_ALACAK_NEDENCollection.ForEach(
                    vi =>
                    {
                        if (!vi.EU_ID.HasValue || (vi.EU_ID.HasValue
                            && KlasorHesapAraclari.GetAlacakNedenByEuId(vi.EU_ID.Value).Count == 0))
                        {
                            takipsizNedenler.Add(vi);
                        }
                    });

                var paralar = new List<ParaVeDovizId>();
                paralar.AddRange(takipsizNedenler.Select(vi => new ParaVeDovizId(vi.ISLEME_KONAN_TUTAR, vi.ISLEME_KONAN_TUTAR_DOVIZ_ID)).ToArray());
                //paralar.AddRange(takipsizNedenler.Select(vi => new ParaVeDovizId(vi.BSMV_TUTARI,vi.BSMV_TUTARI_DOVIZ_ID)).ToArray());
                //paralar.AddRange(takipsizNedenler.Select(vi => new ParaVeDovizId(vi.KKDV_TUTARI, vi.KKDV_TUTARI_DOVIZ_ID)).ToArray());
                paralar.AddRange(takipsizNedenler.Select(vi => new ParaVeDovizId(vi.CEK_TAZMINATI, vi.CEK_TAZMINATI_DOVIZ_ID)).ToArray());
                paralar.AddRange(takipsizNedenler.Select(vi => new ParaVeDovizId(vi.IHTAR_GIDERI, vi.IHTAR_GIDERI_DOVIZ_ID)).ToArray());
                paralar.AddRange(takipsizNedenler.Select(vi => new ParaVeDovizId(vi.PROTESTO_GIDERI, vi.PROTESTO_GIDERI_DOVIZ_ID)).ToArray());
                paralar.AddRange(takipsizNedenler.Select(vi => new ParaVeDovizId(vi.DAMGA_PULU, vi.DAMGA_PULU_DOVIZ_ID)).ToArray());

                takipsizNedenler.ForEach(vi =>
                {
                    paralar.AddRange(vi.AV001_TI_BIL_FAIZCollection.Select(fi => new ParaVeDovizId(fi.FAIZ_TUTARI, fi.FAIZ_TUTARI_DOVIZ_ID)).ToArray());
                    paralar.AddRange(vi.AV001_TI_BIL_FAIZCollection.Select(fi => new ParaVeDovizId(fi.BSMV_TUTARI, fi.BSMV_DOVIZ_ID)).ToArray());
                    paralar.AddRange(vi.AV001_TI_BIL_FAIZCollection.Select(fi => new ParaVeDovizId(fi.KKDF_TUTARI, fi.KKDF_DOVIZ_ID)).ToArray());
                    paralar.AddRange(vi.AV001_TI_BIL_FAIZCollection.Select(fi => new ParaVeDovizId(fi.OIV_TUTARI, fi.OIV_DOVIZ_ID)).ToArray());
                    paralar.AddRange(vi.AV001_TI_BIL_FAIZCollection.Select(fi => new ParaVeDovizId(fi.KDV_TUTARI, fi.KDV_DOVIZ_ID)).ToArray());
                });

                takipsizTutari = ParaVeDovizId.Topla(paralar);
            }

            DateTime gecerlilikT = foy.SON_HESAP_TARIHI.Value;
            //decimal tutar = foy.TAKIP_CIKISI;
            decimal tutar = DovizHelper.CevirYTL(foy.TAKIP_CIKISI, foy.TAKIP_CIKISI_DOVIZ_ID ?? 1, foy.TAKIP_TARIHI ?? DateTime.Now);

            if (takipsizTutari.Para != 0)
            {
                tutar = ParaVeDovizId.Cikart(new ParaVeDovizId(foy.TAKIP_CIKISI, foy.TAKIP_CIKISI_DOVIZ_ID),
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
                        AV001_TI_BIL_VEKALET_UCRET vekUc =
                            VekaletUcretiGetir(new ParaVeDovizId(foy.TAKIP_CIKISI, foy.TAKIP_CIKISI_DOVIZ_ID),
                                               findIt2[i].TARIH, VekaletUcretKalemi.NispiTakipVekUcr,
                                               new ParaVeDovizId(vekTtr, foy.TAKIP_CIKISI_DOVIZ_ID), oran, VekaketUcretTipNo.Nispi, foy.SON_HESAP_TARIHI);

                        #region <CC-20091106>

                        // Vekalet harcýnda takýp çýkýþý deðeri yanlýþ geliyordu  bu þekilde düzeltildi

                        #endregion <CC-20091106>

                        vekUc.VEK_UCR_MIKTARI_DOVIZ_ID = (int)DovizTip.TL;
                        vekUc.TAKIP_CIKISI = para;
                        vekUc.TAKIP_CIKISI_DOVIZ_ID = (int)DovizTip.TL;
                        foy.AV001_TI_BIL_VEKALET_UCRETCollection.Add(vekUc);
                    }
                    else if (para >= tutmaz)
                    {
                        decimal vekTtr = tutmaz / 100 * (decimal)oran;
                        hesaplandi += vekTtr;
                        AV001_TI_BIL_VEKALET_UCRET vekUc =
                            VekaletUcretiGetir(new ParaVeDovizId(foy.TAKIP_CIKISI, foy.TAKIP_CIKISI_DOVIZ_ID),
                                               findIt2[i].TARIH, VekaletUcretKalemi.NispiTakipVekUcr,
                                               new ParaVeDovizId(vekTtr, foy.TAKIP_CIKISI_DOVIZ_ID), oran, VekaketUcretTipNo.Nispi, foy.SON_HESAP_TARIHI);
                        // vekUc.HESAPLAMA_TARIHI = DateTime.Now;

                        #region <CC-20091106>

                        // Vekalet harcýnda takýp çýkýþý deðeri yanlýþ geliyordu  bu þekilde düzeltildi

                        #endregion <CC-20091106>

                        vekUc.VEK_UCR_MIKTARI_DOVIZ_ID = (int)DovizTip.TL;
                        vekUc.TAKIP_CIKISI = tutmaz;
                        vekUc.TAKIP_CIKISI_DOVIZ_ID = (int)DovizTip.TL;
                        foy.AV001_TI_BIL_VEKALET_UCRETCollection.Add(vekUc);

                        //tutmaz = 0;

                        break;
                    }
                }
            }
            if (foy.ID > 0)
            {
                //aykut 01.04.2013
                foy.TAKIP_VEKALET_UCRETI = hesaplandi;//DovizHelper.CevirYTL(hesaplandi, foy.TAKIP_CIKISI_DOVIZ_ID ?? 1, foy.TAKIP_TARIHI ?? DateTime.Now);
                foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID = 1;

                if (foy.TAKIP_VEKALET_UCRETI > 0)
                {
                    var degerler = DataRepository.TDI_CET_MIN_MAX_DEGERProvider.GetAll().OrderByDescending(vi => vi.TARIH);

                    foreach (var deger in degerler)
                    {
                        if (deger.TARIH > foy.SON_HESAP_TARIHI)
                            continue;
                        else
                        {
                            //if (foy.TAKIP_VEKALET_UCRETI < deger.MIN_DEGER)
                            //    foy.TAKIP_VEKALET_UCRETI = deger.MIN_DEGER;
                            //break;
                            if (foy.TAKIP_CIKISI <= deger.MIN_DEGER)
                            {
                                foy.TAKIP_VEKALET_UCRETI = foy.TAKIP_CIKISI;
                                foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID = foy.TAKIP_CIKISI_DOVIZ_ID;
                                break;
                            }
                            else
                            {
                                if (foy.TAKIP_VEKALET_UCRETI < deger.MIN_DEGER)
                                    foy.TAKIP_VEKALET_UCRETI = deger.MIN_DEGER;
                                break;
                            }
                        }
                    }
                }
            }

            foy.TAKIP_VEKALET_UCRETI = foy.TAKIP_VEKALET_UCRETI * (decimal)foy.TAKIP_VEKALET_UCRETI_KATSAYI;

            return foy.TAKIP_VEKALET_UCRETI;
        }

        public static ParaVeDovizId ParalariTopla(List<ParaVeDovizId> paralar, DateTime kurTarihi)
        {
            ParaVeDovizId result = new ParaVeDovizId();
            Dictionary<int, decimal> dicParalar = new Dictionary<int, decimal>();
            foreach (ParaVeDovizId pdId in paralar)
            {
                if (dicParalar.ContainsKey(pdId.DovizId))
                    dicParalar[pdId.DovizId] += pdId.Para;
                else
                    dicParalar.Add(pdId.DovizId, pdId.Para);
            }
            ParaVeDovizId.BosOlanAlanlariSil(dicParalar);
            if (dicParalar.Count > 1)
            {
                foreach (ParaVeDovizId pdId in paralar)
                {
                    result.Para += pdId.YtlCevir(kurTarihi);
                }
                result.DovizId = 1; //YTL
            }
            else
            {
                //Tek bir deðer olduðu için
                Dictionary<int, decimal>.Enumerator num = dicParalar.GetEnumerator();
                //Tek olan deðere ulaþýyor
                num.MoveNext();
                //bunun Doviztip ve miktar bilgilerini result a yazýyoruz
                result.Para = num.Current.Value;
                result.DovizId = num.Current.Key;
            }
            if (result.DovizId == 0)
                result.DovizId = 1;
            return result;
        }

        /// <summary>
        /// TDI_CET_POSTA_GIDER
        /// </summary>
        /// <param name="gecerlilikT"></param>
        /// <param name="MUHASEBE_HAREKET_ALT_KATEGORI_ID"></param>
        /// <returns></returns>
        public static ParaVeDovizId PostaGideriGetir(DateTime gecerlilikT, int MUHASEBE_HAREKET_ALT_KATEGORI_ID)
        {
            TDI_CET_POSTA_GIDERQuery qu2 = new TDI_CET_POSTA_GIDERQuery(true);
            qu2.AppendLessThanOrEqual(TDI_CET_POSTA_GIDERColumn.BASLANGIC_TARIHI,
                                      gecerlilikT.ToString("yyyy/MM/dd 00:00:00"));
            qu2.AppendEquals(TDI_CET_POSTA_GIDERColumn.ALT_KATEGORI_ID, (MUHASEBE_HAREKET_ALT_KATEGORI_ID).ToString());
            int k = 0;
            TDI_CET_POSTA_GIDER posta_GIDER =
                DataRepository.TDI_CET_POSTA_GIDERProvider.Find(qu2, "BASLANGIC_TARIHI DESC", 0, 1, out k)[0];
            return new ParaVeDovizId((decimal)posta_GIDER.MIKTAR, posta_GIDER.GIDER_DOVIZ_ID);
        }

        public static void ProtestoIhtarGiderHesapla(AV001_TI_BIL_FOY mFoy)
        {
            mFoy.IHTAR_GIDERI = 0;
            mFoy.PROTESTO_GIDERI = 0;

            List<ParaVeDovizId> ihtarGiderleri = new List<ParaVeDovizId>();
            if (mFoy.ID == 0)
            {
                int[] protestoIdleri = new int[] { 533, 817, 818, 543 };
                foreach (var mavans in mFoy.AV001_TDI_BIL_MASRAF_AVANSCollection)
                {
                    ihtarGiderleri.AddRange(mavans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection
                        .Where(vi => protestoIdleri.Contains(vi.HAREKET_ALT_KATEGORI_ID))
                        .Select(vi => new ParaVeDovizId(vi.TOPLAM_TUTAR, vi.TOPLAM_TUTAR_DOVIZ_ID, mFoy.TAKIP_TARIHI))
                        .ToList());
                }
            }
            else
            {
                ihtarGiderleri.AddRange(
                    mFoy.AV001_TI_BIL_ALACAK_NEDENCollection
                    .Select(vi => new ParaVeDovizId(vi.IHTAR_GIDERI, vi.IHTAR_GIDERI_DOVIZ_ID))
                    .ToList());
            }
            var ihtarToplami = ParaVeDovizId.Topla(ihtarGiderleri);
            mFoy.IHTAR_GIDERI = ihtarToplami.Para;
            mFoy.IHTAR_GIDERI_DOVIZ_ID = ihtarToplami.DovizId;

            TList<AV001_TI_BIL_ALACAK_NEDEN> gayrisizNedenler = GayriNakitleriCikar(mFoy);
            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in gayrisizNedenler)
            {
                ////<gkn> Takipsiz Alacak Kontrolü
                //if (!neden.ICRA_FOY_ID.HasValue) continue; //klasör hesabýnda takibi açýlmamýþ alacak nedenleri için hesaplamiyacaðýz

                //if (neden.IHTAR_GIDERI_DOVIZ_ID.HasValue)
                //    mFoy.IHTAR_GIDERI +=
                //        DovizHelper.CevirYTL(neden.IHTAR_GIDERI, neden.IHTAR_GIDERI_DOVIZ_ID.Value,
                //                             mFoy.TAKIP_TARIHI.Value);

                DovizHelper.GetMerkezBankasiBilgisi(neden.ALACAK_NEDEN_KOD_ID);
                if (neden.PROTESTO_GIDERI_DOVIZ_ID.HasValue)
                    if (mFoy.TAKIP_TARIHI.HasValue)
                        mFoy.PROTESTO_GIDERI +=
                            DovizHelper.CevirYTL(neden.PROTESTO_GIDERI, neden.PROTESTO_GIDERI_DOVIZ_ID ?? 1,
                                                 mFoy.TAKIP_TARIHI.Value, neden.ALACAK_NEDEN_KOD_ID);
            }
            mFoy.IHTAR_GIDERI_DOVIZ_ID = 1;
            mFoy.PROTESTO_GIDERI_DOVIZ_ID = 1;
        }

        public static double SorumlulukOraniGetirByCariId(int cariId, AV001_TI_BIL_FOY mFoy)
        {
            double sorumlulukOrani = 0;
            TList<AV001_TI_BIL_ALACAK_NEDEN> gayrisizNedenler = GayriNakitleriCikar(mFoy);
            foreach (AV001_TI_BIL_ALACAK_NEDEN ndn in gayrisizNedenler)
            {
                DovizHelper.GetMerkezBankasiBilgisi(ndn.ALACAK_NEDEN_KOD_ID);

                decimal islemeKonanTutar = DovizHelper.CevirYTL(ndn.ISLEME_KONAN_TUTAR, ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value,
                                          mFoy.TAKIP_TARIHI.Value, ndn.ALACAK_NEDEN_KOD_ID);
                decimal asilAlacak = DovizHelper.CevirYTL(mFoy.ASIL_ALACAK, mFoy.ASIL_ALACAK_DOVIZ_ID.Value,
                                          mFoy.TAKIP_TARIHI.Value);

                if (asilAlacak == decimal.Zero)
                    asilAlacak = 1;
                if (islemeKonanTutar == decimal.Zero)
                    islemeKonanTutar = 1;

                double nedenSorumlulukOrani = (double)(islemeKonanTutar / asilAlacak);

                foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF trf in ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                {
                    if (trf.TARAF_CARI_ID == cariId)
                    {
                        if (trf.SORUMLU_OLUNAN_MIKTAR == ndn.ISLEME_KONAN_TUTAR &&
                            trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID == ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID)
                        {
                            trf.SORUMLULUK_ORANI = 1;
                        }
                        else
                        {
                            DovizHelper.GetMerkezBankasiBilgisi(trf);

                            decimal sOMiktar = DovizHelper.CevirYTL(trf.SORUMLU_OLUNAN_MIKTAR,
                                                                                     trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID, mFoy.TAKIP_TARIHI.Value);
                            decimal iKTutar = DovizHelper.CevirYTL(ndn.ISLEME_KONAN_TUTAR,
                                                                                     ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID.
                                                                                         Value,
                                                                                     mFoy.TAKIP_TARIHI.Value);

                            if (sOMiktar == decimal.Zero)
                                sOMiktar = 1;
                            if (iKTutar == decimal.Zero)
                                iKTutar = 1;
                            //aykut sorunluluk oran miktar / tutar dý
                            trf.SORUMLULUK_ORANI = (double)(iKTutar / sOMiktar);
                        }
                        sorumlulukOrani += trf.SORUMLULUK_ORANI.Value * nedenSorumlulukOrani;
                    }
                }
            }
            return sorumlulukOrani;
        }

        public static ParaVeDovizId TakipCikisiHesapla(AV001_TI_BIL_FOY foy)
        {
            List<ParaVeDovizId> paralarinListesi = new List<ParaVeDovizId>();

            paralarinListesi.Add(new ParaVeDovizId(foy.ASIL_ALACAK, foy.ASIL_ALACAK_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.ISLEMIS_FAIZ, foy.ISLEMIS_FAIZ_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.BSMV_TO, foy.BSMV_TO_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.KKDV_TO, foy.KKDV_TO_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.OIV_TO, foy.OIV_TO_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.KDV_TO, foy.KDV_TO_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.CEK_KOMISYONU, foy.CEK_KOMISYONU_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.KARSILIKSIZ_CEK_TAZMINATI, foy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.ILAM_VEK_UCR, foy.ILAM_VEK_UCR_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.ILAM_INKAR_TAZMINATI, foy.ILAM_INKAR_TAZMINATI_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.ILAM_TEBLIG_GIDERI, foy.ILAM_TEBLIG_GIDERI_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.ILAM_BK_YARG_ONAMA, foy.ILAM_BK_YARG_ONAMA_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.ILAM_YARGILAMA_GIDERI, foy.ILAM_YARGILAMA_GIDERI_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.IH_GIDERI, foy.IH_GIDERI_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.IH_VEKALET_UCRETI, foy.IH_VEKALET_UCRETI_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.IT_GIDERI, foy.IT_GIDERI_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.IT_VEKALET_UCRETI, foy.IT_VEKALET_UCRETI_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.OZEL_TUTAR1, foy.OZEL_TUTAR1_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.OZEL_TUTAR2, foy.OZEL_TUTAR2_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.OZEL_TUTAR3, foy.OZEL_TUTAR3_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.OZEL_TAZMINAT, foy.OZEL_TAZMINAT_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.IHTAR_GIDERI, foy.IHTAR_GIDERI_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.PROTESTO_GIDERI, foy.PROTESTO_GIDERI_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.DAMGA_PULU, foy.DAMGA_PULU_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.IT_HACIZDE_ODENEN, foy.IT_HACIZDE_ODENEN_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.MAHSUP_TOPLAMI, foy.MAHSUP_TOPLAMI_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.TO_ODEME_TOPLAMI, foy.TO_ODEME_TOPLAMI_DOVIZ_ID, foy.TAKIP_TARIHI.Value));
            paralarinListesi.Add(new ParaVeDovizId(foy.TO_YONETIMG_TAZMINATI, foy.TO_YONETIMG_TAZMINATI_DOVIZ_ID, foy.TAKIP_TARIHI.Value));

            ParaVeDovizId sonuc = ParaVeDovizId.Topla(paralarinListesi);
            foy.TAKIP_CIKISI = sonuc.Para;
            foy.TAKIP_CIKISI_DOVIZ_ID = sonuc.DovizId; //Harçlý birþeyler olduðundan YTL

            return sonuc;
        }

        public static ParaVeDovizId TakipCikisiHesapla(AV001_TI_BIL_ALACAK_NEDEN_TARAF trf, DateTime takipT)
        {
            List<ParaVeDovizId> paralarinListesi = new List<ParaVeDovizId>();

            paralarinListesi.Add(new ParaVeDovizId(trf.SORUMLU_OLUNAN_MIKTAR, trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.ISLEMIS_FAIZ, trf.ISLEMIS_FAIZ_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.BSMV_TO, trf.BSMV_TO_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.KKDV_TO, trf.KKDV_TO_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.OIV_TO, trf.OIV_TO_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.KDV_TO, trf.KDV_TO_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.CEK_KOMISYONU, trf.CEK_KOMISYONU_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.CEK_TAZMINATI, trf.CEK_TAZMINATI_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.ILAM_VEK_UCR, trf.ILAM_VEK_UCR_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.ILAM_INKAR_TAZMINATI, trf.ILAM_INKAR_TAZMINATI_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.ILAM_TEBLIG_GIDERI, trf.ILAM_TEBLIG_GIDERI_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.ILAM_BK_YARG_ONAMA, trf.ILAM_BK_YARG_ONAMA_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.ILAM_YARGILAMA_GIDERI, trf.ILAM_YARGILAMA_GIDERI_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.IH_GIDERI, trf.IH_GIDERI_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.IH_VEKALET_UCRETI, trf.IH_VEKALET_UCRETI_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.IT_GIDERI, trf.IT_GIDERI_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.IT_VEKALET_UCRETI, trf.IT_VEKALET_UCRETI_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.OZEL_TUTAR1, trf.OZEL_TUTAR1_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.OZEL_TUTAR2, trf.OZEL_TUTAR2_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.OZEL_TUTAR3, trf.OZEL_TUTAR3_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.OZEL_TAZMINAT, trf.OZEL_TAZMINAT_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.IHTAR_GIDERI, trf.IHTAR_GIDERI_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.PROTESTO_GIDERI, trf.PROTESTO_GIDERI_DOVIZ_ID.Value, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.DAMGA_PULU, trf.DAMGA_PULU_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.IT_HACIZDE_ODENEN, trf.IT_HACIZDE_ODENEN_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.MAHSUP_TOPLAMI, trf.MAHSUP_TOPLAMI_DOVIZ_ID, takipT));
            paralarinListesi.Add(new ParaVeDovizId(trf.TO_ODEME_TOPLAMI, trf.TO_ODEME_TOPLAMI_DOVIZ_ID, takipT));

            ParaVeDovizId sonuc = ParaVeDovizId.Topla(paralarinListesi);
            trf.TAKIP_CIKISI = sonuc.Para;
            trf.TAKIP_CIKISI_DOVIZ_ID = sonuc.DovizId; //Harçlý birþeyler olduðundan YTL

            return sonuc;
        }

        public static void TarafGayriNakitHesapla(AV001_TI_BIL_FOY mFoy)
        {
            TList<AV001_TI_BIL_ALACAK_NEDEN> gayriNedenler = GayriNakitAlacakNedenleri(mFoy.AV001_TI_BIL_ALACAK_NEDENCollection);

            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in gayriNedenler)
            {
                foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF nedenTaraf in neden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                {
                    AV001_TI_BIL_FOY_TARAF foyTaraf = mFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(AV001_TI_BIL_FOY_TARAFColumn.CARI_ID, nedenTaraf.TARAF_CARI_ID);
                    ParaVeDovizId toplamAlacak = ParaVeDovizId.Topla(new ParaVeDovizId(nedenTaraf.SORUMLU_OLUNAN_MIKTAR, nedenTaraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID),
                        new ParaVeDovizId(foyTaraf.GAYRI_NAKTI_ALACAK, foyTaraf.GAYRI_NAKTI_ALACAK_DOVIZ_ID));

                    foyTaraf.GAYRI_NAKTI_ALACAK = toplamAlacak.Para;
                    foyTaraf.GAYRI_NAKTI_ALACAK_DOVIZ_ID = toplamAlacak.DovizId;
                }
            }

            decimal harc = mFoy.DEPO_HARCI ?? 0;
            decimal vekalet = mFoy.DEPO_VEKALET_UCRETI ?? 0;

            foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
            {
                if (taraf.CARI_ID.HasValue)
                {
                    decimal oran = (decimal)IcraSorumlulukOraniGetirByCariIdGayriNakit(taraf.CARI_ID.Value, mFoy);
                    if (oran > 0)
                    {
                        taraf.DEPO_HARCI = harc * oran;
                        taraf.DEPO_VEKALET_UCRETI = vekalet * oran;

                        taraf.DEPO_VEKALET_UCRET_DOVIZ_ID = mFoy.DEPO_VEKALET_UCRET_DOVIZ_ID ?? 1;
                        taraf.DEPO_HARCI_DOVIZ_ID = mFoy.DEPO_HARCI_DOVIZ_ID ?? 1;
                    }
                }
            }
        }

        public static TList<AV001_TI_BIL_TAZMINAT> TazminatKalemiHesaplaGetir(DateTime baslangicT, DateTime bitisT, decimal tutar, int dovizTipId, int birYilKacGun, double oran, Takip neZaman, int AlacakNedenID)
        {
            TList<AV001_TI_BIL_TAZMINAT> list = new TList<AV001_TI_BIL_TAZMINAT>();
            TimeSpan tss = DateTime.Today - baslangicT;

            int sonucAyFaki = 0;
            //sonucAyFaki = 12 * (DateTime.Today.Year - baslangicT.Year) + DateTime.Today.Month - baslangicT.Month;

            sonucAyFaki = Convert.ToInt32(Math.Round(Convert.ToDecimal((DateTime.Today - baslangicT).TotalDays / 30), 0));

            for (int i = 0; i < sonucAyFaki; i++)
            {
                AV001_TI_BIL_TAZMINAT tazminat = new AV001_TI_BIL_TAZMINAT();
                tazminat.ICRA_ALACAK_NEDEN_ID = AlacakNedenID;
                tazminat.TAZMINAT_BASLANGIC_TARIHI = baslangicT.AddMonths(i);
                if (baslangicT.AddMonths(i + 1) > DateTime.Today)
                    tazminat.TAZMINAT_BITIS_TARIHI = DateTime.Today;
                else
                    tazminat.TAZMINAT_BITIS_TARIHI = baslangicT.AddMonths(i + 1);

                bool takipOncesiMi = true;
                if (baslangicT.AddMonths(i + 1) > DateTime.Today)
                    takipOncesiMi = false;

                tazminat.TAZMINAT_TAKIPDEN_ONCE_MI = takipOncesiMi;
                tazminat.TAZMINAT_ORANI = oran;
                TimeSpan ts;
                if (baslangicT.AddMonths(i + 1) > DateTime.Today)
                    ts = DateTime.Today - baslangicT.AddMonths(i);
                else
                    ts = baslangicT.AddMonths(i + 1) - baslangicT.AddMonths(i);

                int yuzdeBinde = 100;
                tazminat.GUN_FARKI = ts.Days;
                tazminat.TAZMINAT_TUTARI = (tutar / yuzdeBinde * (decimal)tazminat.TAZMINAT_ORANI * 12) / birYilKacGun *
                                           tazminat.GUN_FARKI; // AYLIK tazminat oraný YAZILIYOR onun için 12 ile çarpýyoruz

                list.Add(tazminat);
            }

            //AV001_TI_BIL_TAZMINAT tazminat = new AV001_TI_BIL_TAZMINAT();
            //tazminat.TAZMINAT_BASLANGIC_TARIHI = baslangicT;
            //tazminat.TAZMINAT_BITIS_TARIHI = bitisT;
            //bool takipOncesiMi = false;
            //if (neZaman == Takip.Oncesi)
            //    takipOncesiMi = true;
            //tazminat.TAZMINAT_TAKIPDEN_ONCE_MI = takipOncesiMi;
            //tazminat.TAZMINAT_ORANI = oran;
            //TimeSpan ts = tazminat.TAZMINAT_BITIS_TARIHI.Value - tazminat.TAZMINAT_BASLANGIC_TARIHI.Value;
            //int yuzdeBinde = 100;
            //tazminat.GUN_FARKI = ts.Days;
            //tazminat.TAZMINAT_TUTARI = (tutar / yuzdeBinde * (decimal)tazminat.TAZMINAT_ORANI * 12) / birYilKacGun *
            //                           tazminat.GUN_FARKI; // AYLIK tazminat oraný YAZILIYOR onun için 12 ile çarpýyoruz
            return list;
        }

        /// <summary>
        /// TDI_CET_MAKTU_VEKALET tablosundan geçerlilik tarihi ve Muhasebe Hareket Alt Kategori Id ye göre VekaletUcreti Getirir
        /// </summary>
        /// <param name="gecerlilikT">Tutarýn geçer</param>
        /// <param name="MAKTU_KOD_ID">Tutara ait hareket MAktuKODID (291=(DURUSMASIZ) GÖRÜLMEKTE OLAN BIR DAVA IÇINDE OLMAMAK KOSULU ILE IHTIYATI HACIZ , IHTIYATI TEDBIR , DELILLERIN TESBITI , ICRANIN GERI BIRAKILMASI , ÖDEME VE TEVDI YERI BELIRLENMESI ISLERI IÇIN)</param>
        /// <returns></returns>
        public static ParaVeDovizId VekaletTutariGetir(DateTime gecerlilikT, int MAKTU_KOD_ID)
        {
            var harclar = DataRepository.TDI_CET_MAKTU_VEKALETProvider.GetAll();

            //TDI_CET_MAKTU_VEKALETQuery qu2 = new TDI_CET_MAKTU_VEKALETQuery(true);
            //qu2.AppendLessThanOrEqual(TDI_CET_MAKTU_VEKALETColumn.BASLANGIC_TARIHI,
            //                          gecerlilikT.ToString("yyyy/MM/dd 00:00:00"));
            //qu2.AppendEquals(TDI_CET_MAKTU_VEKALETColumn.MAKTU_KOD_ID, (MAKTU_KOD_ID).ToString());
            //int k = 0;
            TDI_CET_MAKTU_VEKALET harc = harclar.Where(q => q.BASLANGIC_TARIHI.Date <= gecerlilikT.Date && q.MAKTU_KOD_ID == MAKTU_KOD_ID).FirstOrDefault();
            if (harc == null)
                harc = harclar.Where(q => q.MAKTU_KOD_ID == MAKTU_KOD_ID).OrderBy(q => q.BASLANGIC_TARIHI).FirstOrDefault();
                //DataRepository.TDI_CET_MAKTU_VEKALETProvider.Find(qu2, "BASLANGIC_TARIHI DESC", 0, 1, out k)[0];
            if (harc == null)
                return new ParaVeDovizId(0, 1);
            return new ParaVeDovizId(harc.MIKTAR1, harc.MIKTAR1_DOVIZ_ID);
        }

        private static bool BsmvKontrol(AV001_TI_BIL_ALACAK_NEDEN neden)
        {
            if (neden.ALACAK_NEDEN_KOD_ID.HasValue && neden.ALACAK_NEDEN_KOD_IDSource == null)
                neden.ALACAK_NEDEN_KOD_IDSource = DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(neden.ALACAK_NEDEN_KOD_ID.Value);

            string[] dizi = new[] { "ÇEK", "SENET", "POLÝÇE" };

            return !dizi.Contains(neden.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI);
        }

        private static int compareOdemeFeragat(OdemeFeragat x, OdemeFeragat y)
        {
            return x.Tarih.CompareTo(y.Tarih);
        }

        private static TList<AV001_TI_BIL_ALACAK_NEDEN> GayriNakitleriCikar(TList<AV001_TI_BIL_ALACAK_NEDEN> nedenler)
        {
            TList<AV001_TI_BIL_ALACAK_NEDEN> deposuzNedenler = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
            foreach (AV001_TI_BIL_ALACAK_NEDEN obj in nedenler)
            {
                if (obj.ALACAK_NEDEN_KOD_IDSource != null && obj.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.HasValue)
                {
                    if (obj.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.Value && !obj.VADE_TARIHI.HasValue)
                        obj.FAIZ_BASLANGIC_TARIHI = obj.VADE_TARIHI;

                    if ((obj.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.Value && obj.VADE_TARIHI.HasValue))
                        deposuzNedenler.Add(obj);
                    else if (!obj.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.Value)
                        deposuzNedenler.Add(obj);
                }
                else
                    deposuzNedenler.Add(obj);
            }
            return deposuzNedenler;
        }

        private static TList<AV001_TI_BIL_ALACAK_NEDEN> GayriNakitleriCikar(AV001_TI_BIL_FOY mFoy)
        {
            TList<AV001_TI_BIL_ALACAK_NEDEN> deposuzNedenler = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
            foreach (AV001_TI_BIL_ALACAK_NEDEN obj in mFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                if (obj.ALACAK_NEDEN_KOD_IDSource != null && obj.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.HasValue)
                {
                    if (obj.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.Value && !obj.VADE_TARIHI.HasValue)
                        obj.FAIZ_BASLANGIC_TARIHI = obj.VADE_TARIHI;

                    if ((obj.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.Value && obj.VADE_TARIHI.HasValue))
                        deposuzNedenler.Add(obj);
                    else if (!obj.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.Value)
                        deposuzNedenler.Add(obj);
                }
                else
                    deposuzNedenler.Add(obj);
            }
            return deposuzNedenler;
        }

        /// <summary>
        /// Taraf bazýnda vekalet ücret hesabý :)
        /// </summary>
        /// <param name="foy"></param>
        /// <param name="taraf"></param>
        /// <returns></returns>
        private static decimal NispiVekaletUcretiHesapla(AV001_TI_BIL_FOY foy, AV001_TI_BIL_FOY_TARAF taraf)
        {
            DateTime gecerlilikT = foy.TAKIP_TARIHI.Value;
            decimal tutar = taraf.TAKIP_CIKISI;
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
                        AV001_TI_BIL_VEKALET_UCRET vekUc =
                            VekaletUcretiGetir(new ParaVeDovizId(taraf.TAKIP_CIKISI, taraf.TAKIP_CIKISI_DOVIZ_ID),
                                               findIt2[i].TARIH, VekaletUcretKalemi.NispiTakipVekUcrTaraf,
                                               new ParaVeDovizId(vekTtr, 1), oran, VekaketUcretTipNo.Nispi, foy.SON_HESAP_TARIHI);
                        //vekUc.HESAPLAMA_TARIHI = DateTime.Now;

                        #region <CC-20091106>

                        // Vekalet harcýnda takýp çýkýþý deðeri yanlýþ geliyordu  bu þekilde düzeltildi

                        #endregion <CC-20091106>

                        vekUc.TAKIP_CIKISI = para;
                        taraf.AV001_TI_BIL_VEKALET_UCRETCollection.Add(vekUc);
                    }
                    else if (para >= tutmaz)
                    {
                        decimal vekTtr = tutmaz / 100 * (decimal)oran;
                        hesaplandi += vekTtr;
                        AV001_TI_BIL_VEKALET_UCRET vekUc =
                            VekaletUcretiGetir(new ParaVeDovizId(taraf.TAKIP_CIKISI, taraf.TAKIP_CIKISI_DOVIZ_ID),
                                               findIt2[i].TARIH, VekaletUcretKalemi.NispiTakipVekUcrTaraf,
                                               new ParaVeDovizId(vekTtr, 1), oran, VekaketUcretTipNo.Nispi, foy.SON_HESAP_TARIHI);
                        //vekUc.HESAPLAMA_TARIHI = DateTime.Now;

                        #region <CC-20091106>

                        // Vekalet harcýnda takýp çýkýþý deðeri yanlýþ geliyordu  bu þekilde düzeltildi

                        #endregion <CC-20091106>

                        vekUc.TAKIP_CIKISI = tutmaz;
                        taraf.AV001_TI_BIL_VEKALET_UCRETCollection.Add(vekUc);

                        //tutmaz = 0;
                        break;
                    }
                }
            }

            taraf.TAKIP_VEKALET_UCRETI = hesaplandi;
            taraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID = 1;

            return hesaplandi;
        }

        private static bool PesinHarcKosulu(AV001_TI_BIL_FOY foy)
        {
            int[] dizi = new[] { 4, 5, 6, 7, 13 }; //ilamlý form tipleri

            if (dizi.Contains(foy.FORM_TIP_ID ?? 0))
            {
                //if (foy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Exists(vi => vi.ILAM_TIP_ID == 1))//Ýlamlý formlarda peþin harç hesaplanmamalýymýþ. Bu nedenle kapatýldý. MB
                return false;
            }

            return true;
        }

        /// <summary>
        /// Klasör Üzerinde girilen alacaklardan ICRA_FOY_ID alaný boþ olanlarýn
        /// iþleme konan tutarlarýný döviz toplama kurallarýna uygun toplayýp sonucu döndürüyoruz
        /// </summary>
        /// <param name="foy"></param>
        /// <returns></returns>
        private static ParaVeDovizId TakipsizAlacaklarToplami(AV001_TI_BIL_FOY foy)
        {
            var takipsizNedenler = foy.AV001_TI_BIL_ALACAK_NEDENCollection.Where(vi => !vi.ICRA_FOY_ID.HasValue);
            if (takipsizNedenler.Count() > 0)
            {
                var paralar = takipsizNedenler.Select(vi => new ParaVeDovizId(vi.ISLEME_KONAN_TUTAR, vi.ISLEME_KONAN_TUTAR_DOVIZ_ID));

                return ParaVeDovizId.Topla(paralar.ToList());
            }
            return new ParaVeDovizId(0, 1);
        }
    }

    public class ParaVeDovizId
    {
        public ParaVeDovizId()
        {
        }

        public ParaVeDovizId(decimal? para, int? dovizId)
        {
            _Para = 0;
            _DovizId = 1;
            if (para != null)
                _Para = para.Value;
            if (dovizId != null && dovizId > 0)
                _DovizId = dovizId.Value;
        }

        public ParaVeDovizId(decimal para, int dovizId)
        {
            _Para = para;
            _DovizId = dovizId;
        }

        public ParaVeDovizId(decimal para, int? dovizId)
        {
            _Para = para;
            if (dovizId.HasValue)
                _DovizId = dovizId.Value;
            else
            {
                _DovizId = 1;
            }
        }

        public ParaVeDovizId(decimal? para, int? dovizId, DateTime? pKurCevrimTarihi)
            : this(para, dovizId)
        {
            this.KurCevrimTarihi = pKurCevrimTarihi;
        }

        public ParaVeDovizId(decimal para, int dovizId, DateTime? pKurCevrimTarihi)
            : this(para, dovizId)
        {
            this.KurCevrimTarihi = pKurCevrimTarihi;
        }

        public ParaVeDovizId(decimal para, int dovizId, DateTime pKurCevrimTarihi)
            : this(para, dovizId)
        {
            this.KurCevrimTarihi = pKurCevrimTarihi;
        }

        public ParaVeDovizId(decimal para, int? dovizId, DateTime pKurCevrimTarihi)
            : this(para, dovizId)
        {
            this.KurCevrimTarihi = pKurCevrimTarihi;
        }

        public ParaVeDovizId(decimal para, int? dovizId, DateTime? pKurCevrimTarihi)
            : this(para, dovizId)
        {
            this.KurCevrimTarihi = pKurCevrimTarihi;
        }

        private static VList<per_TDI_KOD_DOVIZ_TIP> _DovizSource;
        private int _DovizId;
        private per_TDI_KOD_DOVIZ_TIP _DovizIdSource;
        private DateTime? _KurCevrimTarihi;
        private decimal _Para;

        public static VList<per_TDI_KOD_DOVIZ_TIP> DovizSource
        {
            get
            {
                if (_DovizSource == null)
                    _DovizSource = DataRepository.per_TDI_KOD_DOVIZ_TIPProvider.GetAll();
                return _DovizSource;
            }
        }

        public string DovizAdi
        {
            get
            {
                if (this.DovizIdSource == null) return string.Empty;
                return this.DovizIdSource.AD;
            }
        }

        public int DovizId
        {
            get
            {
                if (_DovizId < 1) _DovizId = 1;
                return _DovizId;
            }
            set { _DovizId = value; }
        }

        public per_TDI_KOD_DOVIZ_TIP DovizIdSource
        {
            get
            {
                if (_DovizId == 0)
                    return null;
                if (_DovizIdSource == null)
                    _DovizIdSource = GetDovizIdSource(_DovizId);
                return _DovizIdSource;
            }
        }

        public string DovizKodu
        {
            get
            {
                if (this.DovizIdSource == null) return string.Empty;
                return this.DovizIdSource.DOVIZ_KODU;
            }
        }

        /// <summary>
        /// Sonradan eklenen bir özelliktir. Topla static fonksiyonunda kullanýlabilmesi amaçlanmýþtýr.
        /// </summary>
        public DateTime? KurCevrimTarihi
        {
            get { return _KurCevrimTarihi; }
            set { _KurCevrimTarihi = value; }
        }

        public decimal Para
        {
            get { return _Para; }
            set { _Para = value; }
        }

        /// <summary>
        /// Bugünkü kurdan ytl ye çevirilmiþ hali
        /// </summary>
        public decimal YtlHali
        {
            get
            {
                if (_DovizId == 1)
                    return _Para;
                else
                    return DovizHelper.CevirYTL(_Para, _DovizId, this.KurCevrimTarihi ?? DateTime.Today);
            }
        }

        public static void BosOlanAlanlariSil(Dictionary<int, decimal> vl)
        {
            List<int> silinecekler = new List<int>();
            //Boþ alanlarýn tespit edilmesi
            foreach (KeyValuePair<int, decimal> pair in vl)
            {
                if (pair.Value == 0)
                    silinecekler.Add(pair.Key);
            }
            //Tespit edilen boþ alanlarýn silinmesi
            foreach (int i in silinecekler)
            {
                vl.Remove(i);
            }
        }

        public static ParaVeDovizId operator *(ParaVeDovizId p1, int p2)
        {
            return new ParaVeDovizId(p1.Para * p2, p1.DovizId, p1.KurCevrimTarihi);
        }

        public static ParaVeDovizId operator +(ParaVeDovizId p1, ParaVeDovizId p2)
        {
            List<ParaVeDovizId> liste = new List<ParaVeDovizId>();
            liste.Add(p1);
            liste.Add(p2);
            return Topla(liste);
        }

        public per_TDI_KOD_DOVIZ_TIP GetDovizIdSource(int id)
        {
            var dovizTip = DovizSource.Where(vi => vi.ID == id);
            return dovizTip.Count() > 0 ? dovizTip.First() : null;
        }

        /// <summary>
        /// 125,512.00 TL Þeklinde Deðer döndür
        /// </summary>
        /// <returns></returns>
        public string GetStringValue()
        {
            decimal d = decimal.Parse(this.Para.ToString().Trim());
            return string.Format("{0} {1}", d.ToString("###,###,###,###,##0.00"), this.DovizKodu);
        }

        public override string ToString()
        {
            decimal d = decimal.Parse(this.Para.ToString().Trim());
            return string.Format("{0} {1}", d.ToString("###,###,###,###,##0.00"), this.DovizKodu);
        }

        public decimal YtlCevir(DateTime dt)
        {
            if (_DovizId == 1)
                return _Para;
            else
                return DovizHelper.CevirYTL(_Para, _DovizId, dt);
        }

        public decimal YtlCevir(DateTime dt, int alacakNedenKodID)
        {
            if (_DovizId == 1)
                return _Para;
            else
                return DovizHelper.CevirYTL(_Para, _DovizId, dt, alacakNedenKodID);
        }

        #region Static Elemanlar

        public static ParaVeDovizId Cikart(ParaVeDovizId bundan, ParaVeDovizId bunu)
        {
            return Cikart(bundan, bunu, bundan.KurCevrimTarihi ?? DateTime.Today);
        }

        public static ParaVeDovizId Cikart(ParaVeDovizId bundan, ParaVeDovizId bunu, DateTime cevirmeTarihi)
        {
            if (bundan == null)
            {
                bundan = new ParaVeDovizId(0, 1);
                if (bunu != null)
                    bundan.DovizId = bunu.DovizId;
            }
            if (bunu == null)
            {
                bunu = new ParaVeDovizId(0, 1);
                bunu.DovizId = bundan.DovizId;
            }
            if (bunu.Para == 0)
                return bundan;

            if (bundan.DovizId == bunu.DovizId)
            {
                decimal sonuc = bundan.Para - bunu.Para;

                return new ParaVeDovizId(sonuc, bunu.DovizId);
            }
            else if (bundan.DovizId != bunu.DovizId)
            {
                return new ParaVeDovizId(bundan.Para - DovizHelper.CaprazCevir(bunu, bundan.DovizId, cevirmeTarihi), bundan.DovizId);
            }
            return new ParaVeDovizId(0, 1);
        }

        /// <summary>
        /// Verien listedeki paralarý YTL ye çevirerek toplar.
        /// </summary>
        /// <param name="paralar">toplanýcak paralar</param>
        /// <returns></returns>
        public static ParaVeDovizId Topla(List<ParaVeDovizId> paralar, DateTime kurTarihi)
        {
            ParaVeDovizId result = new ParaVeDovizId(0, 1);//0 YTL
            foreach (ParaVeDovizId id in paralar)
            {
                result.Para += id.YtlCevir(kurTarihi);
            }
            return result;
        }

        public static ParaVeDovizId Topla(params ParaVeDovizId[] paralar)
        {
            List<ParaVeDovizId> paraListesi = new List<ParaVeDovizId>();
            paraListesi.AddRange(paralar);
            return Topla(paraListesi);
        }

        /// <summary>
        /// Verien listedeki paralarý farklý tiplerde ise YTL ye çevirerek tek tipte ise aritmetik toplar.
        /// </summary>
        /// <param name="paralar">toplanýcak paralar</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        ///
        public static ParaVeDovizId Topla(List<ParaVeDovizId> paralar)
        {
            ParaVeDovizId result = new ParaVeDovizId(0, 1);//0 YTL
            Dictionary<int, decimal> sonuclar = new Dictionary<int, decimal>();
            //TList<TDI_KOD_DOVIZ_TIP> paraTipleri = DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetAll();
            //foreach (TDI_KOD_DOVIZ_TIP dTip in paraTipleri)
            //{
            //    sonuclar.Add(dTip.ID, 0);
            //}

            foreach (ParaVeDovizId id in paralar)
            {
                if (id != null && id.Para != 0)
                {
                    if (id.DovizId == 0)
                        id.DovizId = 1;

                    if (sonuclar.ContainsKey(id.DovizId))
                        sonuclar[id.DovizId] += id.Para;
                    else
                        sonuclar.Add(id.DovizId, id.Para);
                }
            }
            ParaVeDovizId.BosOlanAlanlariSil(sonuclar);
            if (sonuclar.Count == 1)
            {
                Dictionary<int, decimal>.Enumerator tor = sonuclar.GetEnumerator();
                tor.MoveNext();
                result.DovizId = tor.Current.Key;
                result.Para = tor.Current.Value;
                //                result._DovizIdSource = paraTipleri.Find(TDI_KOD_DOVIZ_TIPColumn.ID, tor.Current.Key);
            }
            else if (sonuclar.Count > 1)
            {
                result.DovizId = 1; //YTL
                foreach (ParaVeDovizId id in paralar)
                {
                    //Bug : Burdaki tarih alanýn kontrolünün yapýlmasý gerekiyor, geçici çözüm yapýldý
                    result.Para += id.YtlCevir(id.KurCevrimTarihi.HasValue ? id.KurCevrimTarihi.Value : DateTime.Today);
                }
            }
            if (result.DovizId == 0)
                result.DovizId = 1;

            return result;
        }

        #endregion Static Elemanlar
    }
}