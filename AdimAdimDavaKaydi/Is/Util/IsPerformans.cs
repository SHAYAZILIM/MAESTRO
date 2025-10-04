using System;
using System.Collections.Generic;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Is.Util
{
    /// <summary>
    /// AV001_TI_BIL_GELISME_PERFORMANS
    /// </summary>
    public static class IsPerformans
    {
        public static void PerformansKaydet(AV001_TI_BIL_FOY foy)
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                AV001_TI_BIL_GELISME_PERFORMANS performans = PerformansGetir(foy);
                if (performans != null)
                {
                    tran.BeginTransaction();

                    DataRepository.AV001_TI_BIL_GELISME_PERFORMANSProvider.Save(tran, performans);

                    tran.Commit();
                }
            }
            catch 
            {
                //Tahsin
                //BelgeUtil.ErrorHandler.Catch(this, ex);
                if (tran.IsOpen)
                    tran.Rollback();
            }

            finally
            {
                tran.Dispose();
            }
        }

        private static DateTime? BelgeSonIslemTarihi(AV001_TI_BIL_FOY foy)
        {
            DateTime? result = null;

            if (foy.AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_ICRA.Count > 0)
            {
                foy.AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_ICRA.Sort("KONTROL_NE_ZAMAN DESC");

                result = foy.AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_ICRA[0].KONTROL_NE_ZAMAN;
            }

            return result;
        }

        private static DateTime? FeragatSonIslemTarihi(AV001_TI_BIL_FOY foy)
        {
            DateTime? result = null;

            if (foy.AV001_TI_BIL_FERAGATCollection.Count > 0)
            {
                foy.AV001_TI_BIL_FERAGATCollection.Sort("KONTROL_NE_ZAMAN DESC");

                result = foy.AV001_TI_BIL_FERAGATCollection[0].KONTROL_NE_ZAMAN;
            }

            return result;
        }

        private static DateTime? FoySonIslemTarihi(AV001_TI_BIL_FOY foy)
        {
            if (foy.KONTROL_NE_ZAMAN > DateTime.MinValue)
                return foy.KONTROL_NE_ZAMAN;
            return null;
        }

        private static DateTime? GorusmeSonIslemTarihi(AV001_TI_BIL_FOY foy)
        {
            DateTime? result = null;

            if (foy.AV001_TDI_BIL_GORUSMECollection_From_NN_GORUSME_ICRA.Count > 0)
            {
                foy.AV001_TDI_BIL_GORUSMECollection_From_NN_GORUSME_ICRA.Sort("KONTROL_NE_ZAMAN DESC");

                result = foy.AV001_TDI_BIL_GORUSMECollection_From_NN_GORUSME_ICRA[0].KONTROL_NE_ZAMAN;
            }

            return result;
        }

        private static DateTime? HacizSonIslemTarihi(AV001_TI_BIL_FOY foy)
        {
            DateTime? result = null;
            TList<AV001_TI_BIL_HACIZ_CHILD> list = new TList<AV001_TI_BIL_HACIZ_CHILD>();
            for (int i = 0; i < foy.AV001_TI_BIL_HACIZ_MASTERCollection.Count; i++)
            {
                if (foy.AV001_TI_BIL_HACIZ_MASTERCollection[i].AV001_TI_BIL_HACIZ_CHILDCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.DeepLoad(
                        foy.AV001_TI_BIL_HACIZ_MASTERCollection[i], false,
                        DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_HACIZ_CHILD>));

                for (int j = 0;
                     j < foy.AV001_TI_BIL_HACIZ_MASTERCollection[i].AV001_TI_BIL_HACIZ_CHILDCollection.Count;
                     j++)
                {
                    if (
                        foy.AV001_TI_BIL_HACIZ_MASTERCollection[i].AV001_TI_BIL_HACIZ_CHILDCollection[j].
                            ChangedProperties.Count > 0)
                        list.Add(foy.AV001_TI_BIL_HACIZ_MASTERCollection[i].AV001_TI_BIL_HACIZ_CHILDCollection[j]);
                }
            }
            if (list.Count > 0)
            {
                list.Sort("KONTROL_NE_ZAMAN DESC");
                result = list[0].KONTROL_NE_ZAMAN;
            }
            if (foy.AV001_TI_BIL_HACIZ_MASTERCollection.Count > 0)
            {
                foy.AV001_TI_BIL_HACIZ_MASTERCollection.Sort("KONTROL_NE_ZAMAN DESC");
                result = foy.AV001_TI_BIL_HACIZ_MASTERCollection[0].KONTROL_NE_ZAMAN;
            }

            return result;
        }

        private static DateTime? IhtiyatiHacizSonIslemTarihi(AV001_TI_BIL_FOY foy)
        {
            DateTime? result = null;

            if (foy.AV001_TI_BIL_IHTIYATI_HACIZCollection.Count > 0)
            {
                foy.AV001_TI_BIL_IHTIYATI_HACIZCollection.Sort("KONTROL_NE_ZAMAN DESC");

                result = foy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].KONTROL_NE_ZAMAN;
            }

            return result;
        }

        private static DateTime? IhtiyatiTedbirSonIslemTarihi(AV001_TI_BIL_FOY foy)
        {
            DateTime? result = null;

            if (foy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.Count > 0)
            {
                foy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.Sort("KONTROL_NE_ZAMAN DESC");

                result = foy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection[0].KONTROL_NE_ZAMAN;
            }

            return result;
        }

        private static DateTime? IlamSonIslemTarihi(AV001_TI_BIL_FOY foy)
        {
            DateTime? result = null;

            if (foy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count > 0)
            {
                foy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Sort("KONTROL_NE_ZAMAN DESC");

                result = foy.AV001_TI_BIL_ILAM_MAHKEMESICollection[0].KONTROL_NE_ZAMAN;
            }

            return result;
        }

        private static DateTime? IstihkakSonIslemTarihi(AV001_TI_BIL_FOY foy)
        {
            DateTime? result = null;

            if (foy.AV001_TI_BIL_ISTIHKAKCollection.Count > 0)
            {
                foy.AV001_TI_BIL_ISTIHKAKCollection.Sort("KONTROL_NE_ZAMAN DESC");

                result = foy.AV001_TI_BIL_ISTIHKAKCollection[0].KONTROL_NE_ZAMAN;
            }

            return result;
        }

        private static DateTime? IstirakSonIslemTarihi(AV001_TI_BIL_FOY foy)
        {
            DateTime? result = null;

            if (foy.AV001_TI_BIL_HACIZ_ISTIRAKCollection.Count > 0)
            {
                foy.AV001_TI_BIL_HACIZ_ISTIRAKCollection.Sort("KONTROL_NE_ZAMAN DESC");

                result = foy.AV001_TI_BIL_HACIZ_ISTIRAKCollection[0].KONTROL_NE_ZAMAN;
            }

            return result;
        }

        private static DateTime? ItirazSonIslemTarihi(AV001_TI_BIL_FOY foy)
        {
            DateTime? result = null;

            if (foy.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection.Count > 0)
            {
                foy.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection.Sort("KONTROL_NE_ZAMAN DESC");

                result = foy.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection[0].KONTROL_NE_ZAMAN;
            }

            return result;
        }

        private static DateTime? KiymetTakdiriSonIslemTarihi(AV001_TI_BIL_FOY foy)
        {
            DateTime? result = null;

            if (foy.AV001_TI_BIL_KIYMET_TAKDIRICollection.Count > 0)
            {
                foy.AV001_TI_BIL_KIYMET_TAKDIRICollection.Sort("KONTROL_NE_ZAMAN DESC");

                result = foy.AV001_TI_BIL_KIYMET_TAKDIRICollection[0].KONTROL_NE_ZAMAN;
            }

            return result;
        }

        private static DateTime? MahsupSonIslemTarihi(AV001_TI_BIL_FOY foy)
        {
            DateTime? result = null;

            if (foy.AV001_TI_BIL_BORCLU_MAHSUPCollection.Count > 0)
            {
                foy.AV001_TI_BIL_BORCLU_MAHSUPCollection.Sort("KONTROL_NE_ZAMAN DESC");

                result = foy.AV001_TI_BIL_BORCLU_MAHSUPCollection[0].KONTROL_NE_ZAMAN;
            }
            return result;
        }

        private static DateTime? MalBeyaniSonIslemTarihi(AV001_TI_BIL_FOY foy)
        {
            DateTime? result = null;

            if (foy.AV001_TI_BIL_MAL_BEYANICollection.Count > 0)
            {
                foy.AV001_TI_BIL_MAL_BEYANICollection.Sort("KONTROL_NE_ZAMAN DESC");

                result = foy.AV001_TI_BIL_MAL_BEYANICollection[0].KONTROL_NE_ZAMAN;
            }

            return result;
        }

        private static AV001_TI_BIL_GELISME_PERFORMANS PerformansGetir(AV001_TI_BIL_FOY foy)
        {
            TList<AV001_TI_BIL_GELISME_PERFORMANS> perfList =
                DataRepository.AV001_TI_BIL_GELISME_PERFORMANSProvider.GetByICRA_FOY_ID(foy.ID);
            if (perfList.Count > 0)
            {
                AV001_TI_BIL_GELISME_PERFORMANS perf = perfList[0];
                DateTime? _date = null;
                if (perf == null)
                {
                    perf = new AV001_TI_BIL_GELISME_PERFORMANS();

                    List<DateTime> result = new List<DateTime>();
                    _date = perf.BELGE_TARIHI = IsPerformans.BelgeSonIslemTarihi(foy);
                    if (_date.HasValue) result.Add(_date.Value);
                    _date = perf.FERAGAT_TARIHI = IsPerformans.FeragatSonIslemTarihi(foy);
                    if (_date.HasValue) result.Add(_date.Value);
                    _date = perf.FOY_KONTROL_NE_ZAMAN = IsPerformans.FoySonIslemTarihi(foy);
                    if (_date.HasValue) result.Add(_date.Value);
                    _date = perf.GORUSME_TARIHI = IsPerformans.GorusmeSonIslemTarihi(foy);
                    if (_date.HasValue) result.Add(_date.Value);
                    _date = perf.HACIZ_TARIHI = IsPerformans.HacizSonIslemTarihi(foy);
                    if (_date.HasValue) result.Add(_date.Value);
                    _date = perf.IHTIHATI_HACIZ_TARIHI = IsPerformans.IhtiyatiHacizSonIslemTarihi(foy);
                    if (_date.HasValue) result.Add(_date.Value);
                    _date = perf.IHTIYATI_TEDBIR_TARIHI = IsPerformans.IhtiyatiTedbirSonIslemTarihi(foy);
                    if (_date.HasValue) result.Add(_date.Value);
                    _date = perf.ILAM_TARIHI = IsPerformans.IlamSonIslemTarihi(foy);
                    if (_date.HasValue) result.Add(_date.Value);
                    _date = perf.ISTIHKAK_TARIHI = IsPerformans.IstihkakSonIslemTarihi(foy);
                    if (_date.HasValue) result.Add(_date.Value);
                    _date = perf.ISTIRAK_TARIHI = IsPerformans.IstirakSonIslemTarihi(foy);
                    if (_date.HasValue) result.Add(_date.Value);
                    _date = perf.ITIRAZ_TARIHI = IsPerformans.ItirazSonIslemTarihi(foy);
                    if (_date.HasValue) result.Add(_date.Value);
                    _date = perf.KIYMET_TAKDIRI_TARIHI = IsPerformans.KiymetTakdiriSonIslemTarihi(foy);
                    if (_date.HasValue) result.Add(_date.Value);
                    _date = perf.MAHSUP_TARIHI = IsPerformans.MahsupSonIslemTarihi(foy);
                    if (_date.HasValue) result.Add(_date.Value);
                    _date = perf.MAL_BEYANI_TARIHI = IsPerformans.MalBeyaniSonIslemTarihi(foy);
                    if (_date.HasValue) result.Add(_date.Value);
                    _date = perf.SATIS_TARIHI = IsPerformans.SatisSonIslemTarihi(foy);
                    if (_date.HasValue) result.Add(_date.Value);
                    _date = perf.TAAHHUT_TARIHI = IsPerformans.TaahhutSonIslemTarihi(foy);
                    if (_date.HasValue) result.Add(_date.Value);
                    _date = perf.TEBLIGAT_TARIHI = IsPerformans.TebligatSonIslemTarihi(foy);
                    if (_date.HasValue) result.Add(_date.Value);
                    perf.SON_KAYIT_TARIHI = IsPerformans.SonKayitTarihiBul(result);
                    perf.ICRA_FOY_ID = foy.ID;
                }
                return perf;
            }
            return null;
        }

        private static DateTime? SatisSonIslemTarihi(AV001_TI_BIL_FOY foy)
        {
            DateTime? result = null;
            TList<AV001_TI_BIL_SATIS_CHILD> list = new TList<AV001_TI_BIL_SATIS_CHILD>();
            for (int i = 0; i < foy.AV001_TI_BIL_SATIS_MASTERCollection.Count; i++)
            {
                if (foy.AV001_TI_BIL_SATIS_MASTERCollection[i].AV001_TI_BIL_SATIS_CHILDCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.DeepLoad(
                        foy.AV001_TI_BIL_SATIS_MASTERCollection[i], false,
                        DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_SATIS_CHILD>));

                for (int j = 0;
                     j < foy.AV001_TI_BIL_SATIS_MASTERCollection[i].AV001_TI_BIL_SATIS_CHILDCollection.Count;
                     j++)
                {
                    if (
                        foy.AV001_TI_BIL_SATIS_MASTERCollection[i].AV001_TI_BIL_SATIS_CHILDCollection[j].
                            ChangedProperties.Count > 0)
                        list.Add(foy.AV001_TI_BIL_SATIS_MASTERCollection[i].AV001_TI_BIL_SATIS_CHILDCollection[j]);
                }
            }
            if (list.Count > 0)
            {
                list.Sort("KONTROL_NE_ZAMAN DESC");
                result = list[0].KONTROL_NE_ZAMAN;
            }
            if (foy.AV001_TI_BIL_SATIS_MASTERCollection.Count > 0)
            {
                foy.AV001_TI_BIL_SATIS_MASTERCollection.Sort("KONTROL_NE_ZAMAN DESC");
                result = foy.AV001_TI_BIL_SATIS_MASTERCollection[0].KONTROL_NE_ZAMAN;
            }

            return result;
        }

        private static DateTime? SonKayitTarihiBul(List<DateTime> list)
        {
            if (list.Count > 0)
            {
                list.Sort(new Comparison<DateTime>(SortAccendingByDate));
                return list[0];
            }

            return null;
        }

        private static int SortAccendingByDate(DateTime first, DateTime second)
        {
            return first.Date.CompareTo(second.Date);
        }

        private static DateTime? TaahhutSonIslemTarihi(AV001_TI_BIL_FOY foy)
        {
            DateTime? result = null;
            TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD> list = new TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD>();
            for (int i = 0; i < foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection.Count; i++)
            {
                if (
                    foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection[i].AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection.
                        Count == 0)
                    DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepLoad(
                        foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection[i], false,
                        DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD>));

                for (int j = 0;
                     j <
                     foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection[i].AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection.
                         Count;
                     j++)
                {
                    if (
                        foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection[i].AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection[
                            j].ChangedProperties.Count > 0)
                        list.Add(
                            foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection[i].
                                AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection[j]);
                }
            }
            if (list.Count > 0)
            {
                list.Sort("KONTROL_NE_ZAMAN DESC");
                result = list[0].KONTROL_NE_ZAMAN;
            }
            if (foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection.Count > 0)
            {
                foy.AV001_TI_BIL_SATIS_MASTERCollection.Sort("KONTROL_NE_ZAMAN DESC");
                result = foy.AV001_TI_BIL_SATIS_MASTERCollection[0].KONTROL_NE_ZAMAN;
            }

            return result;
        }

        private static DateTime? TebligatSonIslemTarihi(AV001_TI_BIL_FOY foy)
        {
            DateTime? result = null;

            if (foy.AV001_TDI_BIL_TEBLIGATCollection.Count > 0)
            {
                foy.AV001_TDI_BIL_TEBLIGATCollection.Sort("KONTROL_NE_ZAMAN DESC");

                result = foy.AV001_TDI_BIL_TEBLIGATCollection[0].KONTROL_NE_ZAMAN;
            }

            return result;
        }
    }
}