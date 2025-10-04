using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using AvukatProLib;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Is.Util
{
    /// <summary>
    /// Dava (AV001_TD_BIL_FOY),Icra(AV001_TI_BIL_FOY) Üzerindeki Otomatik Ýþ Üretimi
    /// </summary>
    public static class IsHelper
    {
        #region Private Methos

        private static string Aciklama(AV001_TD_BIL_FOY foy, TDIE_KOD_IS_ILISKI iliski, string[] degiskenler)
        {
            StringBuilder result = new StringBuilder();
            string[] aciklamaDegiskenler = null;

            #region Entity Sourcelarý Doluyor

            if (foy.ADLI_BIRIM_ADLIYE_ID.HasValue && foy.ADLI_BIRIM_ADLIYE_IDSource == null)
                foy.ADLI_BIRIM_ADLIYE_IDSource =
                    DataRepository.TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetByID(foy.ADLI_BIRIM_ADLIYE_ID.Value);

            if (foy.ADLI_BIRIM_NO_ID.HasValue && foy.ADLI_BIRIM_NO_IDSource == null)
                foy.ADLI_BIRIM_NO_IDSource =
                    DataRepository.TDI_KOD_ADLI_BIRIM_NOProvider.GetByID(foy.ADLI_BIRIM_NO_ID.Value);

            if (foy.ADLI_BIRIM_GOREV_ID.HasValue && foy.ADLI_BIRIM_GOREV_IDSource == null)
                foy.ADLI_BIRIM_GOREV_IDSource =
                    DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.GetByID(foy.ADLI_BIRIM_GOREV_ID.Value);

            #endregion Entity Sourcelarý Doluyor

            if (foy.ADLI_BIRIM_ADLIYE_ID.HasValue)
            {
                result.Append(foy.ADLI_BIRIM_ADLIYE_IDSource.ADLIYE);
                result.Append(",");
            }
            if (foy.ADLI_BIRIM_NO_ID.HasValue)
            {
                result.Append(foy.ADLI_BIRIM_NO_IDSource.NO);
                result.Append(" ");
            }
            if (foy.ADLI_BIRIM_GOREV_ID.HasValue)
            {
                result.Append("ve");
                result.Append(" ");
                result.Append(foy.ADLI_BIRIM_GOREV_IDSource.GOREV);
                result.Append(" ");
                result.Append("Olan");
                result.Append(" ");
            }
            if (foy.ESAS_NO != string.Empty && foy.ESAS_NO != DateTime.Today.Year.ToString())
            {
                result.Append(foy.ESAS_NO);
                result.Append(" ");
                result.Append("Esas Numaralý");
                result.Append(" ");
            }

            aciklamaDegiskenler = iliski.ACIKLAMA_DEGISKENLER.Split(',');
            if (aciklamaDegiskenler.Length == degiskenler.Length)
                result.Append(string.Format(iliski.ACIKLAMA, degiskenler));
            else
            {
                result = result.Remove(0, result.Length - 1);
                System.Windows.Forms.MessageBox.Show(
                    "Yapýlacak iþler otomatik olarak oluþturuldu fakat açýklamalar yazýlamýyor.Veritabýný kontrol etmeniz önerilir.",
                    "Uyarý",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

                //result.Append("Açýklama oluþturulurken beklenmeyen bir hata oluþtu.LütfenVeritabanýný kontrol ediniz.");
            }

            #region Kullanýlmýyor.

            //result.Append("Dava Dosyasýnda");
            //result.Append("(");
            //result.Append(foy.FOY_NO);
            //result.Append(")");
            //result.Append(" ");
            //if (taraflar.Count > 1)
            //{
            //    for (int i = 0; i < taraflar.Count; i++)
            //    {
            //        result.Append(taraflar[i]);
            //        result.Append(",");
            //    }
            //    result.Append(" ");
            //    result.Append("Ýsimli Taraflar Ýçin");
            //}
            //else if (taraflar.Count == 0)
            //{
            //    result.Append(" ");
            //    result.Append(taraflar[0]);
            //    result.Append(" ");
            //    result.Append("Ýsimli Taraf Ýçin");
            //}
            //result.Append(" ");
            //result.Append(Tarih.ToShortDateString());
            //result.Append("(");
            //result.Append(saat);
            //result.Append(")");
            //result.Append(" ");
            //result.Append("Tarihine Kadar");
            //result.Append(" ");
            //result.Append(key);

            #endregion Kullanýlmýyor.

            return result.ToString();
        }

        private static DateTime BitisTarihiHesapla(DateTime hesaplanacakTarih, TDIE_KOD_IS_ILISKI iliski)
        {
            int _day = 0;

            if (iliski.KAYITTAN_KAC_GUN_SONRA_KONTROL_EDILSIN.HasValue)
                _day = iliski.KAYITTAN_KAC_GUN_SONRA_KONTROL_EDILSIN.Value;

            try
            {
                hesaplanacakTarih = hesaplanacakTarih.AddDays(_day);

                hesaplanacakTarih = ucIcraTarafGelismeleri.HSonuOnemliGunKontrol(hesaplanacakTarih).Value;
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

            return hesaplanacakTarih;
        }

        private static TList<AV001_TD_BIL_DAVA_NEDEN_TARAF> CevapDilekcesiTarihiOlanlar(AV001_TD_BIL_FOY foy)
        {
            TList<AV001_TD_BIL_DAVA_NEDEN_TARAF> result = new TList<AV001_TD_BIL_DAVA_NEDEN_TARAF>();

            foreach (AV001_TD_BIL_DAVA_NEDEN neden in foy.AV001_TD_BIL_DAVA_NEDENCollection)
            {
                foreach (AV001_TD_BIL_DAVA_NEDEN_TARAF nedenTaraf in neden.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection)
                {
                    if (nedenTaraf.CEVAP_DILEKCESI_TARIHI.HasValue)
                        result.Add(nedenTaraf);
                }
            }

            return result;
        }

        private static bool DavaTipiHukukMu(AV001_TD_BIL_FOY foy)
        {
            return foy.DAVA_TIP_ID == (int)DavaTipi.HUKUK;
        }

        private static TList<AV001_TD_BIL_DAVA_NEDEN_TARAF> DuplikDilekcesiTarihiOlanlar(AV001_TD_BIL_FOY foy)
        {
            TList<AV001_TD_BIL_DAVA_NEDEN_TARAF> result = new TList<AV001_TD_BIL_DAVA_NEDEN_TARAF>();

            foreach (AV001_TD_BIL_DAVA_NEDEN neden in foy.AV001_TD_BIL_DAVA_NEDENCollection)
            {
                foreach (AV001_TD_BIL_DAVA_NEDEN_TARAF nedenTaraf in neden.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection)
                {
                    if (nedenTaraf.DUPLIK_TARIHI.HasValue)
                        result.Add(nedenTaraf);
                }
            }

            return result;
        }

        private static string IncelemeTuru(AV001_TD_BIL_CELSE c)
        {
            if (c.INCELEME_TUR_IDSource == null && c.INCELEME_TUR_ID.HasValue)
                c.INCELEME_TUR_IDSource = DataRepository.TDI_KOD_INCELEME_TURProvider.GetByID(c.INCELEME_TUR_ID.Value);

            StringBuilder sb = new StringBuilder();
            sb.Append(c.INCELEME_TUR_IDSource.TURU);
            sb.Append(" ");
            sb.Append("Ýncelemesi Yapýlmalýdýr.");

            return sb.ToString();
        }

        private static string IsKonusu(TDIE_KOD_IS_ILISKI iliski)
        {
            if (iliski.IS_KONU_IDSource == null && iliski.IS_KONU_ID.HasValue)
                iliski.IS_KONU_IDSource = DataRepository.TDIE_KOD_IS_TANIMProvider.GetByID(iliski.IS_KONU_ID.Value);

            return iliski.IS_KONU_IDSource.KONU;
        }

        private static void IsTarafEkle(TDIE_KOD_IS_ILISKI Iliski, AV001_TD_BIL_FOY foy, AV001_TDI_BIL_IS Is)
        {
            AV001_TDI_BIL_CARI cari = null;

            //bool yetkiliVarMi = false;

            if (foy.AV001_TD_BIL_FOY_TARAFCollection != null && foy.AV001_TD_BIL_FOY_TARAFCollection.Count == 0)
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TD_BIL_FOY_TARAF>));
            foreach (AV001_TD_BIL_FOY_TARAF taraf in foy.AV001_TD_BIL_FOY_TARAFCollection)
            {
                foreach (Grup uret in UretimIdList(Iliski))
                {
                    switch (uret)
                    {
                        case Grup.Sorumlusu:
                            for (int i = 0; i < foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Count; i++)
                            {
                                //Is.AV001_TDI_BIL_IS_TARAFCollection.Clear();//Duruþmalar üretilen otomatik iþlerde sadece son avukata iþ atanmasýna sebep olduðundan kapatýldý. MB
                                AV001_TDI_BIL_IS_TARAF trf = Is.AV001_TDI_BIL_IS_TARAFCollection.AddNew();
                                trf.CARI_ID = foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection[i].SORUMLU_AVUKAT_CARI_ID;

                                //edit [ZK]
                                //trf.IS_TARAF_ID = 2;//Sorumlusu
                                trf.IS_TARAF_ID = (int)IsTaraf.Sorumlusu;

                            }
                            break;

                        case Grup.Yetkilisi:
                        case Grup.Planlayan:

                            //cari = ((TList<AV001_TDI_BIL_CARI>)Inits.GetCachedData(CacheHelper.CacheType.CariFull)).Find(AV001_TDI_BIL_CARIColumn.YETKILI_MI, 1);
                            if (cari != null)
                            {
                                AV001_TDI_BIL_IS_TARAF trf = Is.AV001_TDI_BIL_IS_TARAFCollection.AddNew();
                                trf.CARI_ID = taraf.CARI_ID;

                                // edit [ZK]
                                // trf.IS_TARAF_ID =  10001;//Yetkilisi(Yeni Eklendi)
                                trf.IS_TARAF_ID = (int)IsTaraf.Yetkilisi;

                                //yetkiliVarMi = true;
                            }
                            break;

                        case Grup.Sahibi:

                            //cari = ((TList<AV001_TDI_BIL_CARI>)Inits.GetCachedData(CacheHelper.CacheType.CariFull)).Find(AV001_TDI_BIL_CARIColumn.MUVEKKIL_MI, 1);
                            if (cari != null)
                            {
                                AV001_TDI_BIL_IS_TARAF trf = Is.AV001_TDI_BIL_IS_TARAFCollection.AddNew();
                                trf.CARI_ID = taraf.CARI_ID;

                                //edit [ZK]
                                //trf.IS_TARAF_ID = 1;//Sahibi
                                trf.IS_TARAF_ID = (int)IsTaraf.Planlayan;
                            }
                            break;

                        case Grup.Hepsi:
                            break;
                    }
                }
            }

            if (Is.AV001_TDI_BIL_IS_TARAFCollection.Count > 0)
            {
                for (int i = 0; i < Is.AV001_TDI_BIL_IS_TARAFCollection.Count; i++)
                {
                    Is.AV001_TDI_BIL_IS_TARAFCollection[i].KAYIT_TARIHI = DateTime.Today;
                    Is.AV001_TDI_BIL_IS_TARAFCollection[i].KLASOR_KODU = "GENEL";
                    Is.AV001_TDI_BIL_IS_TARAFCollection[i].SUBE_KODU = 1;
                    Is.AV001_TDI_BIL_IS_TARAFCollection[i].KONTROL_NE_ZAMAN = DateTime.Today;
                    Is.AV001_TDI_BIL_IS_TARAFCollection[i].KONTROL_KIM = "AVUKATPRO";
                    Is.AV001_TDI_BIL_IS_TARAFCollection[i].KONTROL_VERSIYON = 1;
                    Is.AV001_TDI_BIL_IS_TARAFCollection[i].STAMP = 1;
                }
            }

            //return Is.AV001_TDI_BIL_IS_TARAFCollection;
        }

        private static bool IsVarmi(UcretlendirilmisIsler Kat, DateTime BitisTarihi, AV001_TD_BIL_FOY foy)
        {
            TList<AV001_TDI_BIL_IS> result =
                DataRepository.AV001_TDI_BIL_ISProvider.GetByDAVA_FOY_IDFromNN_IS_DAVA_FOY(foy.ID);

            result = result.FindAll(AV001_TDI_BIL_ISColumn.KATEGORI_ID, (int)Kat);

            //foreach (AV001_TDI_BIL_IS i in result)
            //{
            //    if (i.ONGORULEN_BITIS_TARIHI.Value.Date == BitisTarihi.Date)
            //        return true;
            //}

            return false;
        }

        private static string IsYeri(AV001_TDI_BIL_IS i)
        {
            if (i.ADLI_BIRIM_ADLIYE_IDSource == null && i.ADLI_BIRIM_ADLIYE_ID.HasValue)
            {
                //i.ADLI_BIRIM_ADLIYE_IDSource =
                //    DataRepository.TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetByID(i.ADLI_BIRIM_ADLIYE_ID.Value);

                //return i.ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;
            }

            return string.Empty;
        }

        private static TList<AV001_TD_BIL_FOY_TARAF> KanitDilekcesiTarihiOlanlar(AV001_TD_BIL_FOY foy)
        {
            TList<AV001_TD_BIL_FOY_TARAF> result = new TList<AV001_TD_BIL_FOY_TARAF>();

            foreach (AV001_TD_BIL_KANIT kanit in foy.AV001_TD_BIL_KANITCollection)
            {
                if (kanit.CARI_ID.HasValue)
                {
                    return foy.AV001_TD_BIL_FOY_TARAFCollection.FindAll(AV001_TD_BIL_FOY_TARAFColumn.CARI_ID,
                                                                        kanit.CARI_ID.Value);
                }
            }

            return result;
        }

        private static string KararTipi(AV001_TD_BIL_ARA_KARAR karar)
        {
            string result = string.Empty;

            switch ((AraKararTip)karar.TIP)
            {
                case AraKararTip.Kesin_Mehilli:
                    result = "Kesin Mehilli";
                    break;

                case AraKararTip.Mehilli:
                    result = "Mehilli";
                    break;

                case AraKararTip.Mehilsiz:
                    result = "Mehilsiz";
                    break;
            }

            return result;
        }

        private static bool MuvekkilDavaEdenMi(AV001_TD_BIL_FOY foy)
        {
            foreach (AV001_TD_BIL_FOY_TARAF t in foy.AV001_TD_BIL_FOY_TARAFCollection)
            {
                if (t.TARAF_KODUSource == null || t.TARAF_SIFAT_IDSource == null)
                    DataRepository.AV001_TD_BIL_FOY_TARAFProvider.DeepLoad(t, false, DeepLoadType.IncludeChildren,
                                                                           typeof(TDIE_KOD_TARAF_SIFAT),
                                                                           typeof(TDI_KOD_TARAF));

                if (t.TARAF_SIFAT_IDSource.HANGI_TARAF_NO == 3) //Dava Eden
                {
                    if (t.TARAF_KODUSource.ID == (int)TarafKodu.Muvekkil) return true;
                }
            }
            return false;
        }

        private static bool MuvekkilDavaEdilenMi(AV001_TD_BIL_FOY foy)
        {
            foreach (AV001_TD_BIL_FOY_TARAF t in foy.AV001_TD_BIL_FOY_TARAFCollection)
            {
                if (t.TARAF_KODUSource == null || t.TARAF_SIFAT_IDSource == null)
                    DataRepository.AV001_TD_BIL_FOY_TARAFProvider.DeepLoad(t, false, DeepLoadType.IncludeChildren,
                                                                           typeof(TDIE_KOD_TARAF_SIFAT),
                                                                           typeof(TDI_KOD_TARAF));

                if (t.TARAF_SIFAT_IDSource.HANGI_TARAF_NO == 4) //Dava Edilen
                {
                    if (t.TARAF_KODUSource.ID == (int)TarafKodu.Muvekkil) return true;
                }
            }
            return false;
        }

        private static TList<AV001_TD_BIL_DAVA_NEDEN_TARAF> ReplikDilekcesiTarihiOlanlar(AV001_TD_BIL_FOY foy)
        {
            TList<AV001_TD_BIL_DAVA_NEDEN_TARAF> result = new TList<AV001_TD_BIL_DAVA_NEDEN_TARAF>();

            foreach (AV001_TD_BIL_DAVA_NEDEN neden in foy.AV001_TD_BIL_DAVA_NEDENCollection)
            {
                foreach (AV001_TD_BIL_DAVA_NEDEN_TARAF nedenTaraf in neden.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection)
                {
                    if (nedenTaraf.REPLIK_TARIHI.HasValue)
                        result.Add(nedenTaraf);
                }
            }

            return result;
        }

        private static AV001_TDI_BIL_TEBLIGAT SonTebligatiGetir(AV001_TD_BIL_FOY foy)
        {
            TList<AV001_TDI_BIL_TEBLIGAT> result = null;

            foreach (AV001_TDI_BIL_TEBLIGAT teb in foy.AV001_TDI_BIL_TEBLIGATCollection)
            {
                if (teb.KONU_IDSource == null)
                    teb.KONU_IDSource = DataRepository.TDI_KOD_TEBLIGAT_KONUProvider.GetByID(teb.KONU_ID);

                if (teb.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count == 0)
                    teb.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddRange(
                        DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.GetByTEBLIGAT_ID(teb.ID));

                if (teb.KONU_IDSource.ANA_TUR_ID == 3 && teb.KONU_IDSource.ALT_TUR_ID == 31)
                {
                    if (result == null)
                        result = new TList<AV001_TDI_BIL_TEBLIGAT>();

                    result.Add(teb);
                }
            }

            if (result != null && result.Count > 0)
            {
                result.Sort("KAYIT_TARIHI DESC");

                return result[0];
            }

            return null;
        }

        private static TList<AV001_TDI_BIL_TEBLIGAT> TebligatBul(AV001_TD_BIL_FOY foy, Dilekce dilekce)
        {
            TList<AV001_TDI_BIL_TEBLIGAT> result = new TList<AV001_TDI_BIL_TEBLIGAT>();
            TList<AV001_TD_BIL_DAVA_NEDEN_TARAF> dnTaraflar = null;
            TList<AV001_TD_BIL_FOY_TARAF> foyTaraflar = null;

            switch (dilekce)
            {
                case Dilekce.Cevap_Dilekcesi:
                    dnTaraflar = CevapDilekcesiTarihiOlanlar(foy);
                    break;

                case Dilekce.Replik_Dilekcesi:
                    dnTaraflar = ReplikDilekcesiTarihiOlanlar(foy);
                    break;

                case Dilekce.Duplik_Dilekcesi:
                    dnTaraflar = DuplikDilekcesiTarihiOlanlar(foy);
                    break;

                case Dilekce.Temyiz_Dilekcesi:
                    foyTaraflar = TemyizDilekcesiTarihiOlanlar(foy);
                    break;

                case Dilekce.Kanit_Dilekcesi:
                    foyTaraflar = KanitDilekcesiTarihiOlanlar(foy);
                    break;
            }

            foreach (AV001_TDI_BIL_TEBLIGAT teb in TumTebligatlar(foy))
            {
                foreach (AV001_TDI_BIL_TEBLIGAT_MUHATAP muh in teb.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection)
                {
                    if (foyTaraflar == null)
                    {
                        for (int i = 0; i < dnTaraflar.Count; i++)
                        {
                            if (muh.MUHATAP_CARI_ID == dnTaraflar[i].TARAF_CARI_ID
                                || muh.ALAN_CARI_ID.HasValue && muh.ALAN_CARI_ID.Value == dnTaraflar[i].TARAF_CARI_ID)
                            {
                                if (!result.Contains(teb))
                                    result.Add(teb);
                            }
                        }
                    }

                    else if (dnTaraflar == null)
                    {
                        for (int i = 0; i < foyTaraflar.Count; i++)
                        {
                            if (muh.MUHATAP_CARI_ID == foyTaraflar[i].CARI_ID.Value
                                || muh.ALAN_CARI_ID.HasValue && muh.ALAN_CARI_ID.Value == foyTaraflar[i].CARI_ID.Value)
                            {
                                if (!result.Contains(teb))
                                    result.Add(teb);
                            }
                        }
                    }
                }
            }
            return result;
        }

        private static TList<AV001_TD_BIL_FOY_TARAF> TemyizDilekcesiTarihiOlanlar(AV001_TD_BIL_FOY foy)
        {
            TList<AV001_TD_BIL_FOY_TARAF> result = new TList<AV001_TD_BIL_FOY_TARAF>();

            foreach (AV001_TD_BIL_TEMYIZ temyiz in foy.AV001_TD_BIL_TEMYIZCollection)
            {
                foreach (AV001_TD_BIL_TEMYIZ_TARAF trf in temyiz.AV001_TD_BIL_TEMYIZ_TARAFCollection)
                {
                    if (trf.TEMYIZ_TARIHI.HasValue)
                        result.AddRange(
                            foy.AV001_TD_BIL_FOY_TARAFCollection.FindAll(AV001_TD_BIL_FOY_TARAFColumn.CARI_ID,
                                                                         trf.CARI_ID.Value));
                }
            }

            return result;
        }

        private static TList<AV001_TDI_BIL_TEBLIGAT> TumTebligatlar(AV001_TD_BIL_FOY foy)
        {
            TList<AV001_TDI_BIL_TEBLIGAT> result = new TList<AV001_TDI_BIL_TEBLIGAT>();
            foreach (AV001_TDI_BIL_TEBLIGAT teb in foy.AV001_TDI_BIL_TEBLIGATCollection)
            {
                if (teb.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count == 0)
                    teb.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddRange(
                        DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.GetByTEBLIGAT_ID(teb.ID));

                result.Add(teb);
            }
            return result;
        }

        private static List<int> UretimIdList(TDIE_KOD_IS_ILISKI Iliski)
        {
            List<int> IdList = new List<int>();
            if (Iliski.URETIM_GRUPLARI != null)
            {
                foreach (string s in Iliski.URETIM_GRUPLARI.Split(','))
                {
                    foreach (DataRow row in IsHelper.GrupGetir().Rows)
                    {
                        if (row.ItemArray[1].ToString().Trim() == s.Trim())
                            IdList.Add(Convert.ToInt32(row.ItemArray[0]));
                    }
                }
            }

            return IdList;
        }

        #endregion Private Methos

        #region Public Methods

        private static Dictionary<int, AV001_TDI_BIL_IS> araKararIsList = new Dictionary<int, AV001_TDI_BIL_IS>();

        private static Dictionary<int, AV001_TDI_BIL_IS> celseIsList = new Dictionary<int, AV001_TDI_BIL_IS>();

        public static bool AraKarardaIsVarmi(AV001_TD_BIL_ARA_KARAR araKarar)
        {
            AV001_TDI_BIL_IS seciliAraKarar =
                DataRepository.AV001_TDI_BIL_ISProvider.GetByARAKARAR_IDFromNN_IS_ARAKARAR(araKarar.ID).FirstOrDefault();

            if (seciliAraKarar != null)
                return true;
            else return false;
        }

        public static bool CelsedeIsVarmi(AV001_TD_BIL_CELSE celse)
        {
            AV001_TDI_BIL_IS seciliCelse =
                DataRepository.AV001_TDI_BIL_ISProvider.GetByCELSE_IDFromNN_IS_CELSE(celse.ID).FirstOrDefault();

            if (seciliCelse != null)
                return true;
            else return false;
        }

        public static void DavaIsleriniUret(AV001_TD_BIL_FOY foy)
        {
            TList<TDIE_KOD_IS_ILISKI> isler = DataRepository.TDIE_KOD_IS_ILISKIProvider.GetByMODUL_ID(2);
            TDIE_KOD_IS_ILISKI iliski = null;
            celseIsList.Clear();

            #region Celse Üzerinden Ýþ Üret

            foreach (AV001_TD_BIL_CELSE celse in foy.AV001_TD_BIL_CELSECollection)
            {
                if (celse.CELSE_MI)
                {
                    #region Duruþma Günü

                    iliski = isler.Find(TDIE_KOD_IS_ILISKIColumn.IS_KONU_ID, 3);

                    if (celse.TARIH > DateTime.MinValue && !CelsedeIsVarmi(celse))

                    //IsHelper.BitisTarihiHesapla(celse.TARIH, iliski), foy))
                    {
                        AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                        Is.KATEGORI_ID = (int)UcretlendirilmisIsler.DURUSMALAR;
                        Is.ONCELIK_ID = (int)IsOncelik.ÇOK_ACÝL;
                        Is.KONU = IsHelper.IsKonusu(iliski);
                        Is.ONGORULEN_BITIS_TARIHI = celse.TARIH;
                        Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                        new[]
                                                            {
                                                                foy.FOY_NO,
                                                                Is.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString()
                                                            });
                        Is.BASLANGIC_TARIHI = celse.TARIH;

                        Is.YAPILACAK_IS = Is.ACIKLAMA;
                        if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                        {
                            Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                            Is.AJANDADA_GORUNSUN_MU = true;
                        }
                        Is.STAMP = 0;

                        //IsHelper.IsTarafEkle(iliski, foy, Is);
                        Is.AV001_TDI_BIL_IS_TARAFCollection.Add(new AV001_TDI_BIL_IS_TARAF() { CARI_ID = celse.SORUMLU_AVUKAT_CARI1_ID, IS_TARAF_ID = 1 });
                        if (celse.SORUMLU_AVUKAT_CARI1_ID != celse.SORUMLU_AVUKAT_CARI2_ID)
                            Is.AV001_TDI_BIL_IS_TARAFCollection.Add(new AV001_TDI_BIL_IS_TARAF() { CARI_ID = celse.SORUMLU_AVUKAT_CARI2_ID, IS_TARAF_ID = 2 });
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);

                        celseIsList.Add(celse.ID, Is);
                    }

                    #endregion Duruþma Günü
                }

                else if (!celse.CELSE_MI && celse.INCELEME_TUR_ID.HasValue)
                {
                    #region Keþif Günü

                    iliski = isler.Find(TDIE_KOD_IS_ILISKIColumn.IS_KONU_ID, 5);

                    if (celse.TARIH > DateTime.MinValue &&
                        !IsVarmi(UcretlendirilmisIsler.DURUSMALAR, IsHelper.BitisTarihiHesapla(celse.TARIH, iliski), foy))
                    {
                        AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                        Is.KATEGORI_ID = (int)UcretlendirilmisIsler.DURUSMALAR;
                        Is.ONCELIK_ID = iliski.IS_ONCELIK_ID;
                        Is.KONU = IsHelper.IsKonusu(iliski);
                        Is.ONGORULEN_BITIS_TARIHI = IsHelper.BitisTarihiHesapla(celse.TARIH, iliski);
                        Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                        new[]
                                                            {
                                                                foy.FOY_NO,
                                                                Is.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString(),
                                                                IsHelper.IncelemeTuru(celse)
                                                            });
                        Is.BASLANGIC_TARIHI = celse.TARIH;
                        Is.YAPILACAK_IS = Is.ACIKLAMA;
                        if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                        {
                            Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                            Is.AJANDADA_GORUNSUN_MU = iliski.AJANDADA_GORUNSUN_MU.Value;
                        }
                        Is.STAMP = 0;

                        //IsHelper.IsTarafEkle(iliski, foy, Is);
                        Is.AV001_TDI_BIL_IS_TARAFCollection.Add(new AV001_TDI_BIL_IS_TARAF() { CARI_ID = celse.SORUMLU_AVUKAT_CARI1_ID, IS_TARAF_ID = 1 });
                        if (celse.SORUMLU_AVUKAT_CARI1_ID != celse.SORUMLU_AVUKAT_CARI2_ID)
                            Is.AV001_TDI_BIL_IS_TARAFCollection.Add(new AV001_TDI_BIL_IS_TARAF() { CARI_ID = celse.SORUMLU_AVUKAT_CARI2_ID, IS_TARAF_ID = 2 });
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);
                    }

                    #endregion Keþif Günü
                }
            }

            #endregion Celse Üzerinden Ýþ Üret

            #region Ara Kararýn Yerine Getirilmesi

            araKararIsList.Clear();
            iliski = isler.Find(TDIE_KOD_IS_ILISKIColumn.IS_KONU_ID, 10);
            foreach (AV001_TD_BIL_ARA_KARAR karar in foy.AV001_TD_BIL_ARA_KARARCollection)
            {
                if (karar.TARIH > DateTime.MinValue && !AraKarardaIsVarmi(karar))
                {
                    AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                    Is.KATEGORI_ID = (int)UcretlendirilmisIsler.ARA_KARARLAR;
                    Is.STAMP = 0;

                    Is.KONU = IsHelper.IsKonusu(iliski);
                    Is.ONCELIK_ID = (int)IsOncelik.ÇOK_ACÝL;
                    if (karar.YERINE_GETIRME_TARIH.HasValue)
                    {
                        Is.ONGORULEN_BITIS_TARIHI = IsHelper.BitisTarihiHesapla(karar.YERINE_GETIRME_TARIH.Value, iliski);
                        Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                                    new[]
                                                                    {
                                                                        foy.FOY_NO, Is.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString(),
                                                                        KararTipi(karar)
                                                                    });
                    }
                    Is.BASLANGIC_TARIHI = karar.YERINE_GETIRME_TARIH;

                    Is.YAPILACAK_IS = Is.ACIKLAMA;
                    if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                    {
                        Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                        Is.AJANDADA_GORUNSUN_MU = iliski.AJANDADA_GORUNSUN_MU.Value;
                    }

                    IsHelper.IsTarafEkle(iliski, foy, Is);

                    //Is.AV001_TDI_BIL_IS_TARAFCollection.Add(new AV001_TDI_BIL_IS_TARAF() { CARI_ID = karar., IS_TARAF_ID = 1 });
                    //if (karar.SORUMLU_AVUKAT_CARI1_ID != karar.SORUMLU_AVUKAT_CARI2_ID)
                    //    Is.AV001_TDI_BIL_IS_TARAFCollection.Add(new AV001_TDI_BIL_IS_TARAF() { CARI_ID = karar.SORUMLU_AVUKAT_CARI2_ID, IS_TARAF_ID = 2 });
                    foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);

                    araKararIsList.Add(karar.ID, Is);
                }
            }

            #endregion Ara Kararýn Yerine Getirilmesi

            #region Bekleyen Dosyanýn Takibe Konulmasý

            iliski = isler.Find(TDIE_KOD_IS_ILISKIColumn.IS_KONU_ID, 12);
            if (foy.AVUKATA_INTIKAL_TARIHI.HasValue && foy.FOY_DURUM_ID != Convert.ToInt32(FoyDurum.EVRAK))
            {
                if (IsHelper.IsVarmi(UcretlendirilmisIsler.DOSYA_INCELEME,
                                     IsHelper.BitisTarihiHesapla(foy.AVUKATA_INTIKAL_TARIHI.Value, iliski), foy))
                {
                    AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                    Is.KATEGORI_ID = (int)UcretlendirilmisIsler.DOSYA_INCELEME;
                    Is.ONGORULEN_BITIS_TARIHI = IsHelper.BitisTarihiHesapla(foy.AVUKATA_INTIKAL_TARIHI.Value, iliski);
                    Is.ONCELIK_ID = iliski.IS_ONCELIK_ID;
                    Is.STAMP = 0;
                    Is.KONU = IsHelper.IsKonusu(iliski);
                    Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                    new[]
                                                        {
                                                            foy.FOY_NO, Is.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString()
                                                        });
                    Is.BASLANGIC_TARIHI = foy.AVUKATA_INTIKAL_TARIHI;
                    Is.YAPILACAK_IS = Is.ACIKLAMA;
                    if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                    {
                        Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                        Is.AJANDADA_GORUNSUN_MU = iliski.AJANDADA_GORUNSUN_MU.Value;
                    }

                    IsHelper.IsTarafEkle(iliski, foy, Is);
                    foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);
                }
            }

            #endregion Bekleyen Dosyanýn Takibe Konulmasý

            #region Duruþma Bilgisi Girilmeyen ve Düþen Dosyanýn Harçsýz Yenilenmesi Uyarýsý

            iliski = isler.Find(TDIE_KOD_IS_ILISKIColumn.IS_KONU_ID, 13);
            if (foy.AV001_TD_BIL_CELSECollection.Count > 0)
            {
                foy.AV001_TD_BIL_CELSECollection.Sort("TARIH DESC");

                AV001_TD_BIL_CELSE celse = foy.AV001_TD_BIL_CELSECollection[0];

                if (celse.CELSE_MI && celse.CELSEYE_GIRILDI_MI.HasValue && !celse.CELSEYE_GIRILDI_MI.Value)
                {
                    if (celse.TARIH < DateTime.Today &&
                        !IsHelper.IsVarmi(UcretlendirilmisIsler.DURUSMALAR,
                                          IsHelper.BitisTarihiHesapla(celse.TARIH, iliski), foy)
                        && IsHelper.MuvekkilDavaEdenMi(foy) && IsHelper.DavaTipiHukukMu(foy))
                    {
                        AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                        Is.KATEGORI_ID = (int)UcretlendirilmisIsler.DURUSMALAR;
                        Is.ONGORULEN_BITIS_TARIHI = IsHelper.BitisTarihiHesapla(celse.TARIH, iliski);
                        Is.ONCELIK_ID = iliski.IS_ONCELIK_ID;
                        Is.STAMP = 0;
                        Is.KONU = IsHelper.IsKonusu(iliski);
                        Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                        new[]
                                                            {
                                                                Is.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString(),
                                                                foy.FOY_NO
                                                            });
                        Is.BASLANGIC_TARIHI = celse.TARIH;
                        Is.YAPILACAK_IS = Is.ACIKLAMA;
                        if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                        {
                            Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                            Is.AJANDADA_GORUNSUN_MU = iliski.AJANDADA_GORUNSUN_MU.Value;
                        }

                        IsHelper.IsTarafEkle(iliski, foy, Is);
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);
                    }
                }
            }

            #endregion Duruþma Bilgisi Girilmeyen ve Düþen Dosyanýn Harçsýz Yenilenmesi Uyarýsý

            #region Karara çýkan dosyalarda yönetimden Temyiz Edilme yada Edilmeme kararý istenme uyarýsý

            iliski = isler.Find(TDIE_KOD_IS_ILISKIColumn.IS_KONU_ID, 14);
            foreach (AV001_TD_BIL_MAHKEME_HUKUM hukum in foy.AV001_TD_BIL_MAHKEME_HUKUMCollection)
            {
                if (hukum.HUKUM_TARIHI > DateTime.MinValue &&
                    !IsHelper.IsVarmi(UcretlendirilmisIsler.INCELEMELER,
                                      IsHelper.BitisTarihiHesapla(hukum.HUKUM_TARIHI, iliski), foy))
                {
                    AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                    Is.KATEGORI_ID = (int)UcretlendirilmisIsler.INCELEMELER;
                    Is.ONCELIK_ID = iliski.IS_ONCELIK_ID;
                    Is.KONU = IsHelper.IsKonusu(iliski);
                    Is.STAMP = 0;
                    Is.ONGORULEN_BITIS_TARIHI = IsHelper.BitisTarihiHesapla(hukum.HUKUM_TARIHI, iliski);
                    Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                    new[]
                                                        {
                                                            foy.FOY_NO, Is.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString()
                                                        });
                    Is.BASLANGIC_TARIHI = hukum.HUKUM_TARIHI;
                    Is.YAPILACAK_IS = Is.ACIKLAMA;
                    if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                    {
                        Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                        Is.AJANDADA_GORUNSUN_MU = iliski.AJANDADA_GORUNSUN_MU.Value;
                    }

                    IsHelper.IsTarafEkle(iliski, foy, Is);
                    foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);
                }
            }

            #endregion Karara çýkan dosyalarda yönetimden Temyiz Edilme yada Edilmeme kararý istenme uyarýsý

            //

            #region Tutuklama Kararýna Ýtiraz Uyarýsý -

            iliski = isler.Find(TDIE_KOD_IS_ILISKIColumn.IS_KONU_ID, 22);

            foreach (AV001_TD_BIL_TUTUKLANMA t in foy.AV001_TD_BIL_TUTUKLANMACollection)
            {
                if (t.TUTUKLANMA_TARIHI.HasValue &&
                    IsHelper.IsVarmi(UcretlendirilmisIsler.YASAL_SURELI_ISLER,
                                     IsHelper.BitisTarihiHesapla(t.TUTUKLANMA_TARIHI.Value, iliski), foy) &&
                    IsHelper.MuvekkilDavaEdilenMi(foy))
                {
                    AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                    Is.KATEGORI_ID = (int)UcretlendirilmisIsler.YASAL_SURELI_ISLER;
                    Is.ONCELIK_ID = iliski.IS_ONCELIK_ID;
                    Is.STAMP = 0;
                    Is.KONU = IsHelper.IsKonusu(iliski);
                    Is.ONGORULEN_BITIS_TARIHI = IsHelper.BitisTarihiHesapla(t.TUTUKLANMA_TARIHI.Value, iliski);
                    Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                    new[]
                                                        {
                                                            foy.FOY_NO, Is.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString()
                                                        });
                    Is.BASLANGIC_TARIHI = t.TUTUKLANMA_TARIHI;
                    Is.YAPILACAK_IS = Is.ACIKLAMA;
                    if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                    {
                        Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                        Is.AJANDADA_GORUNSUN_MU = iliski.AJANDADA_GORUNSUN_MU.Value;
                    }

                    IsHelper.IsTarafEkle(iliski, foy, Is);
                    foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);
                }
                else if (t.SERBEST_BIRAKILMA_TARIHI.HasValue &&
                         IsHelper.IsVarmi(UcretlendirilmisIsler.YASAL_SURELI_ISLER,
                                          IsHelper.BitisTarihiHesapla(t.SERBEST_BIRAKILMA_TARIHI.Value, iliski), foy) &&
                         IsHelper.MuvekkilDavaEdenMi(foy))
                {
                    AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                    Is.KATEGORI_ID = (int)UcretlendirilmisIsler.YASAL_SURELI_ISLER;
                    Is.ONCELIK_ID = iliski.IS_ONCELIK_ID;
                    Is.STAMP = 0;
                    Is.KONU = IsHelper.IsKonusu(iliski);
                    Is.ONGORULEN_BITIS_TARIHI = IsHelper.BitisTarihiHesapla(t.SERBEST_BIRAKILMA_TARIHI.Value, iliski);
                    Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                    new[]
                                                        {
                                                            foy.FOY_NO,
                                                            Is.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString()
                                                        });
                    Is.YAPILACAK_IS = Is.ACIKLAMA;
                    Is.BASLANGIC_TARIHI = t.SERBEST_BIRAKILMA_TARIHI;
                    if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                    {
                        Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                        Is.AJANDADA_GORUNSUN_MU = iliski.AJANDADA_GORUNSUN_MU.Value;
                    }

                    IsHelper.IsTarafEkle(iliski, foy, Is);
                    foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);
                }
            }

            #endregion Tutuklama Kararýna Ýtiraz Uyarýsý -

            #region Karþý Tarafýn Kararý Temyiz Etmesi

            iliski = isler.Find(TDIE_KOD_IS_ILISKIColumn.IS_KONU_ID, 21);
            foreach (AV001_TD_BIL_TEMYIZ temyiz in foy.AV001_TD_BIL_TEMYIZCollection)
            {
                foreach (AV001_TD_BIL_TEMYIZ_TARAF tmyTaraf in temyiz.AV001_TD_BIL_TEMYIZ_TARAFCollection)
                {
                    AV001_TD_BIL_FOY_TARAF foyTaraf =
                        foy.AV001_TD_BIL_FOY_TARAFCollection.Find(AV001_TD_BIL_FOY_TARAFColumn.CARI_ID,
                                                                  tmyTaraf.CARI_ID.Value);

                    if (foyTaraf.TARAF_KODU == Convert.ToInt32(TarafKodlari.K))
                    {
                        if (temyiz.KARAR_TARIHI.HasValue &&
                            !IsHelper.IsVarmi(UcretlendirilmisIsler.INCELEMELER,
                                              IsHelper.BitisTarihiHesapla(temyiz.KARAR_TARIHI.Value, iliski), foy))
                        {
                            AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                            Is.KATEGORI_ID = (int)UcretlendirilmisIsler.INCELEMELER;
                            Is.ONCELIK_ID = iliski.IS_ONCELIK_ID;
                            Is.KONU = IsHelper.IsKonusu(iliski);
                            Is.STAMP = 0;
                            Is.ONGORULEN_BITIS_TARIHI = IsHelper.BitisTarihiHesapla(temyiz.KARAR_TARIHI.Value, iliski);
                            Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                            new[]
                                                                {
                                                                    foy.FOY_NO,
                                                                    Is.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString()
                                                                });
                            Is.BASLANGIC_TARIHI = temyiz.KARAR_TARIHI;
                            Is.YAPILACAK_IS = Is.ACIKLAMA;
                            if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                            {
                                Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                                Is.AJANDADA_GORUNSUN_MU = iliski.AJANDADA_GORUNSUN_MU.Value;
                            }

                            IsHelper.IsTarafEkle(iliski, foy, Is);
                            foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);
                        }
                    }
                }
            }

            #endregion Karþý Tarafýn Kararý Temyiz Etmesi

            #region Tutuklama Kararýna Ýtiraz Uyarýsý

            if (foy.DAVA_TIP_ID.Value == (int)DavaTipi.ASKERI_CEZA || foy.DAVA_TIP_ID.Value == (int)DavaTipi.CEZA ||
                foy.DAVA_TIP_ID.Value == (int)DavaTipi.ICRA_CEZA)
            {
                iliski = isler.Find(TDIE_KOD_IS_ILISKIColumn.IS_KONU_ID, 22);

                foreach (AV001_TD_BIL_TUTUKLANMA tk in foy.AV001_TD_BIL_TUTUKLANMACollection)
                {
                    if (tk.CARI_ID.HasValue)
                    {
                        AV001_TD_BIL_FOY_TARAF foyTaraf =
                            foy.AV001_TD_BIL_FOY_TARAFCollection.Find(AV001_TD_BIL_FOY_TARAFColumn.CARI_ID,
                                                                      tk.CARI_ID.Value);

                        if (foyTaraf != null)
                        {
                            if (foyTaraf.TARAF_KODU == Convert.ToInt32(TarafKodlari.M))
                            {
                                if (tk.TUTUKLANMA_TARIHI.HasValue && !IsHelper.IsVarmi(UcretlendirilmisIsler.DIGER,
                                                                                       IsHelper.BitisTarihiHesapla(
                                                                                           tk.TUTUKLANMA_TARIHI.Value,
                                                                                           iliski), foy))
                                {
                                    AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                                    Is.KATEGORI_ID = (int)UcretlendirilmisIsler.DIGER;
                                    Is.ONCELIK_ID = iliski.IS_ONCELIK_ID;
                                    Is.KONU = IsHelper.IsKonusu(iliski);
                                    Is.STAMP = 0;
                                    Is.ONGORULEN_BITIS_TARIHI = IsHelper.BitisTarihiHesapla(tk.TUTUKLANMA_TARIHI.Value,
                                                                                            iliski);
                                    Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                                    new[]
                                                                        {
                                                                            foy.FOY_NO,
                                                                            Is.ONGORULEN_BITIS_TARIHI.Value.
                                                                                ToShortDateString()
                                                                        });
                                    Is.YAPILACAK_IS = Is.ACIKLAMA;
                                    Is.BASLANGIC_TARIHI = tk.TUTUKLANMA_TARIHI;
                                    if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                                    {
                                        Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                                        Is.AJANDADA_GORUNSUN_MU = iliski.AJANDADA_GORUNSUN_MU.Value;
                                    }

                                    IsHelper.IsTarafEkle(iliski, foy, Is);
                                    foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);
                                }
                            }
                        }
                    }
                }
            }

            #endregion Tutuklama Kararýna Ýtiraz Uyarýsý

            if (foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY != null &&
                foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Count > 0)
            {
                for (int i = 0; i < foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Count; i++)
                {
                    if (foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].IsNew)
                    {
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].ADLI_BIRIM_ADLIYE_ID =
                            foy.ADLI_BIRIM_ADLIYE_ID;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].ADLI_BIRIM_GOREV_ID =
                            foy.ADLI_BIRIM_GOREV_ID;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].ADLI_BIRIM_NO_ID = foy.ADLI_BIRIM_NO_ID;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].MODUL_ID = 2;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].DURUM = false;

                        //foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].BASLANGIC_TARIHI = DateTime.Today;
                        if (foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].ADLI_BIRIM_ADLIYE_ID.HasValue)
                            foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].YER =
                                IsYeri(foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i]);
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].HER_GUN_MU = false;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].STATU_ID = 0;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].ETIKET_ID = 0;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].ESAS_NO = foy.ESAS_NO;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].REFERANS_NO = Guid.NewGuid().ToString("N");
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].STAMP = 1;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].KAYIT_TARIHI = DateTime.Today;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].KLASOR_KODU = "GENEL";
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].SUBE_KODU = 1;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].KONTROL_KIM = "AVUKATPRO";
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].KONTROL_NE_ZAMAN = DateTime.Today;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].KONTROL_VERSIYON = 1;
                    }
                }
            }
        }

        public static DataTable GrupGetir()
        {
            DataTable dt = new DataTable("Grup");
            dt.Columns.Add("ID");
            dt.Columns.Add("GRUP");
            foreach (Grup g in Enum.GetValues(typeof(Grup)))
            {
                dt.Rows.Add((int)g, g.ToString());
            }

            return dt;
        }

        public static DataTable HatýrlatmaSekli()
        {
            DataTable dt = new DataTable("HatýrlatmaSekli");
            dt.Columns.Add("ID");
            dt.Columns.Add("HATIRLATMA");
            foreach (HatýrlatmaSekli h in Enum.GetValues(typeof(HatýrlatmaSekli)))
            {
                dt.Rows.Add((int)h, h.ToString().Replace("_", " "));
            }

            return dt;
        }


        public static bool IsleriKaydet(AV001_TD_BIL_FOY foy)
        {
            //return IsleriKaydet(foy, null);
            List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
            CompInfo cmpNfo = cmpNfoList[0];

            if (string.IsNullOrEmpty(cmpNfo.OtomatikIsUretme))
                return IsleriKaydet(foy, null);
            else if (cmpNfo.OtomatikIsUretme == "0")
                return true;
            else
                return IsleriKaydet(foy, null);
        }

        public static bool IsleriKaydet(AV001_TD_BIL_FOY foy, TransactionManager trans)
        {
            List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
            CompInfo cmpNfo = cmpNfoList[0];

            bool sonuc = true;
            if (trans == null)
                trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                if (!trans.IsOpen)
                    trans.BeginTransaction();

                if (cmpNfo.OtomatikIsUretme == "2")
                    IsHelper.TebligatUzerindenIsUret(foy);

                IsHelper.DavaIsleriniUret(foy);
                TList<AV001_TDI_BIL_IS> isler = foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY;

                foreach (AV001_TDI_BIL_IS item in isler)
                {
                    if (item.KATEGORI_ID != 483)
                        item.KATEGORI_ID = 492;
                    item.AJANDADA_GORUNSUN_MU = true;
                    item.ONGORULEN_BITIS_TARIHI = item.BASLANGIC_TARIHI;
                    foreach (AV001_TDI_BIL_IS_TARAF item2 in item.AV001_TDI_BIL_IS_TARAFCollection)
                    {
                        item2.IS_TARAF_ID = 2;

                    }
                }

                if (isler != null && isler.Count > 0)
                {
                    DataRepository.AV001_TDI_BIL_ISProvider.DeepSave(isler, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IS_TARAF>));

                    TList<NN_IS_DAVA_FOY> result = DataRepository.NN_IS_DAVA_FOYProvider.GetByDAVA_FOY_ID(foy.ID);

                    for (int i = 0; i < isler.Count; i++)
                    {
                        NN_IS_DAVA_FOY nn = DataRepository.NN_IS_DAVA_FOYProvider.GetByIS_IDDAVA_FOY_ID(isler[i].ID, foy.ID);
                        if (nn == null)
                        {
                            nn = new NN_IS_DAVA_FOY();
                            nn.DAVA_FOY_ID = foy.ID;
                            nn.IS_ID = isler[i].ID;
                            result.Add(nn);
                        }
                    }

                    DataRepository.NN_IS_DAVA_FOYProvider.Save(trans, result);

                    foreach (var celseId in celseIsList.Keys)
                    {
                        NN_IS_CELSE isCelse = new NN_IS_CELSE();
                        isCelse.CELSE_ID = celseId;
                        isCelse.IS_ID = celseIsList[celseId].ID;
                        TList<NN_IS_CELSE> islerCelse = DataRepository.NN_IS_CELSEProvider.GetAll(trans);
                        if (islerCelse.Exists(delegate(NN_IS_CELSE cls) { return cls.IS_ID == isCelse.IS_ID; }))
                            continue;
                        AvukatProLib2.Data.DataRepository.NN_IS_CELSEProvider.Save(trans, isCelse);
                    }

                    foreach (var araKararId in araKararIsList.Keys)
                    {
                        NN_IS_ARAKARAR isAraKarar = new NN_IS_ARAKARAR();
                        isAraKarar.ARAKARAR_ID = araKararId;
                        isAraKarar.IS_ID = araKararIsList[araKararId].ID;
                        TList<NN_IS_ARAKARAR> islerAraKarar = DataRepository.NN_IS_ARAKARARProvider.GetAll(trans);
                        if (islerAraKarar.Exists(delegate(NN_IS_ARAKARAR krr) { return krr.IS_ID == isAraKarar.IS_ID; }))
                            continue;
                        AvukatProLib2.Data.DataRepository.NN_IS_ARAKARARProvider.DeepSave(trans, isAraKarar);
                    }

                    trans.Commit();
                }
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                ex.ToString();

                sonuc = false;
            }

            finally
            {
                trans.Dispose();
            }

            return sonuc;
        }

        public static void TebligatUzerindenIsUret(AV001_TD_BIL_FOY foy)
        {
            TDIE_KOD_IS_ILISKI iliski = null;
            AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatap = null;
            TList<NN_BELGE_TEBLIGAT> documents = null;
            AV001_TDI_BIL_TEBLIGAT tebligat = IsHelper.SonTebligatiGetir(foy);
            TList<TDIE_KOD_IS_ILISKI> isler = DataRepository.TDIE_KOD_IS_ILISKIProvider.GetByMODUL_ID(2);

            if (tebligat != null)
            {
                tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Sort("TEBLIG_TARIH DESC");

                muhatap = tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[0];

                if (DavaTipiHukukMu(foy) && tebligat.POSTALANMA_TARIH > DateTime.MinValue)
                {
                    if (IsHelper.MuvekkilDavaEdenMi(foy))
                    {
                        if (foy.AV001_TD_BIL_KANITCollection.Count == 0)
                        {
                            #region Dava dilekçesi ile birlikte kanýt listesi verildi mi kontrol et uyarýsý

                            iliski = isler.Find(TDIE_KOD_IS_ILISKIColumn.IS_KONU_ID, 15);

                            if (
                                !IsHelper.IsVarmi(UcretlendirilmisIsler.TEBLIGAT_ISLERI,
                                                  IsHelper.BitisTarihiHesapla(tebligat.POSTALANMA_TARIH, iliski), foy))
                            {
                                AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                                Is.KATEGORI_ID = (int)UcretlendirilmisIsler.TEBLIGAT_ISLERI;
                                Is.ONCELIK_ID = iliski.IS_ONCELIK_ID;
                                Is.KONU = IsHelper.IsKonusu(iliski);
                                Is.STAMP = 0;
                                Is.ONGORULEN_BITIS_TARIHI = IsHelper.BitisTarihiHesapla(tebligat.POSTALANMA_TARIH,
                                                                                        iliski);
                                Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                                new[]
                                                                    {
                                                                        foy.FOY_NO,
                                                                        Is.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString()
                                                                    });
                                Is.BASLANGIC_TARIHI = tebligat.POSTALANMA_TARIH;
                                Is.YAPILACAK_IS = Is.ACIKLAMA;
                                if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                                {
                                    Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                                    Is.AJANDADA_GORUNSUN_MU = iliski.AJANDADA_GORUNSUN_MU.Value;
                                }

                                IsHelper.IsTarafEkle(iliski, foy, Is);
                                foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);
                            }

                            #endregion Dava dilekçesi ile birlikte kanýt listesi verildi mi kontrol et uyarýsý
                        }

                        #region Duplik dilekçesi verilmesi uyarýsý (Duplik)

                        iliski = isler.Find(TDIE_KOD_IS_ILISKIColumn.IS_KONU_ID, 20);

                        if (
                            !IsHelper.IsVarmi(UcretlendirilmisIsler.TEBLIGAT_ISLERI,
                                              IsHelper.BitisTarihiHesapla(tebligat.POSTALANMA_TARIH, iliski), foy))
                        {
                            AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                            Is.KATEGORI_ID = (int)UcretlendirilmisIsler.TEBLIGAT_ISLERI;
                            Is.ONCELIK_ID = iliski.IS_ONCELIK_ID;
                            Is.KONU = IsHelper.IsKonusu(iliski);
                            Is.STAMP = 0;
                            Is.ONGORULEN_BITIS_TARIHI = IsHelper.BitisTarihiHesapla(tebligat.POSTALANMA_TARIH, iliski);
                            Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                            new[]
                                                                {
                                                                    foy.FOY_NO,
                                                                    Is.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString()
                                                                });
                            Is.BASLANGIC_TARIHI = tebligat.POSTALANMA_TARIH;
                            Is.YAPILACAK_IS = Is.ACIKLAMA;
                            if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                            {
                                Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                                Is.AJANDADA_GORUNSUN_MU = iliski.AJANDADA_GORUNSUN_MU.Value;
                            }

                            IsHelper.IsTarafEkle(iliski, foy, Is);
                            foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);
                        }

                        #endregion Duplik dilekçesi verilmesi uyarýsý (Duplik)
                    }

                    if (IsHelper.MuvekkilDavaEdilenMi(foy))
                    {
                        if (tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count > 0)
                        {
                            //muhatap.TEBLIG_TARIH = DateTime.Today.AddDays(20); - TEST ÝÇÝN SET ETTÝM[Ýko]
                            if (muhatap.TEBLIG_TARIH.HasValue)
                            {
                                #region Aleyhe davalarda cevap süresini uzatma veya cevap dilekçesi verilmesi uyarýsý

                                iliski = isler.Find(TDIE_KOD_IS_ILISKIColumn.IS_KONU_ID, 17);

                                if (
                                    !IsHelper.IsVarmi(UcretlendirilmisIsler.TEBLIGAT_ISLERI,
                                                      IsHelper.BitisTarihiHesapla(muhatap.TEBLIG_TARIH.Value, iliski),
                                                      foy))
                                {
                                    AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                                    Is.KATEGORI_ID = (int)UcretlendirilmisIsler.TEBLIGAT_ISLERI;
                                    Is.ONCELIK_ID = iliski.IS_ONCELIK_ID;
                                    Is.KONU = IsHelper.IsKonusu(iliski);
                                    Is.STAMP = 0;
                                    Is.ONGORULEN_BITIS_TARIHI = IsHelper.BitisTarihiHesapla(muhatap.TEBLIG_TARIH.Value,
                                                                                            iliski);
                                    Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                                    new[]
                                                                        {
                                                                            foy.FOY_NO,
                                                                            Is.ONGORULEN_BITIS_TARIHI.Value.
                                                                                ToShortDateString()
                                                                        });
                                    Is.BASLANGIC_TARIHI = muhatap.TEBLIG_TARIH;
                                    Is.YAPILACAK_IS = Is.ACIKLAMA;
                                    if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                                    {
                                        Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                                        Is.AJANDADA_GORUNSUN_MU = iliski.AJANDADA_GORUNSUN_MU.Value;
                                    }

                                    IsHelper.IsTarafEkle(iliski, foy, Is);
                                    foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);
                                }

                                #endregion Aleyhe davalarda cevap süresini uzatma veya cevap dilekçesi verilmesi uyarýsý

                                #region Cevaba cevap dilekçesi verilmesi uyarýsý (Replik)

                                iliski = isler.Find(TDIE_KOD_IS_ILISKIColumn.IS_KONU_ID, 19);

                                if (
                                    !IsHelper.IsVarmi(UcretlendirilmisIsler.TEBLIGAT_ISLERI,
                                                      IsHelper.BitisTarihiHesapla(muhatap.TEBLIG_TARIH.Value, iliski),
                                                      foy))
                                {
                                    AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                                    Is.KATEGORI_ID = (int)UcretlendirilmisIsler.TEBLIGAT_ISLERI;
                                    Is.ONCELIK_ID = iliski.IS_ONCELIK_ID;
                                    Is.KONU = IsHelper.IsKonusu(iliski);
                                    Is.STAMP = 0;
                                    Is.ONGORULEN_BITIS_TARIHI = IsHelper.BitisTarihiHesapla(muhatap.TEBLIG_TARIH.Value,
                                                                                            iliski);
                                    Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                                    new[]
                                                                        {
                                                                            foy.FOY_NO,
                                                                            Is.ONGORULEN_BITIS_TARIHI.Value.
                                                                                ToShortDateString()
                                                                        });
                                    Is.BASLANGIC_TARIHI = muhatap.TEBLIG_TARIH;
                                    Is.YAPILACAK_IS = Is.ACIKLAMA;
                                    if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                                    {
                                        Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                                        Is.AJANDADA_GORUNSUN_MU = iliski.AJANDADA_GORUNSUN_MU.Value;
                                    }
                                    IsHelper.IsTarafEkle(iliski, foy, Is);
                                    foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);
                                }

                                #endregion Cevaba cevap dilekçesi verilmesi uyarýsý (Replik)
                            }
                        }
                    }

                    #region Dava Dilekçesi Dosyaya baðlanmamýþ uyarýsý

                    documents = DataRepository.NN_BELGE_TEBLIGATProvider.GetByTEBLIGAT_ID(tebligat.ID);

                    if (documents.Count == 0)
                    {
                        iliski = isler.Find(TDIE_KOD_IS_ILISKIColumn.IS_KONU_ID, 23);

                        if (
                            !IsHelper.IsVarmi(UcretlendirilmisIsler.TEBLIGAT_ISLERI,
                                              IsHelper.BitisTarihiHesapla(tebligat.POSTALANMA_TARIH, iliski), foy))
                        {
                            AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                            Is.KATEGORI_ID = (int)UcretlendirilmisIsler.TEBLIGAT_ISLERI;
                            Is.ONCELIK_ID = iliski.IS_ONCELIK_ID;
                            Is.KONU = IsHelper.IsKonusu(iliski);
                            Is.STAMP = 0;
                            Is.ONGORULEN_BITIS_TARIHI = IsHelper.BitisTarihiHesapla(tebligat.POSTALANMA_TARIH, iliski);
                            Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                            new[]
                                                                {
                                                                    foy.FOY_NO, Is.REFERANS_NO,
                                                                    Is.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString()
                                                                });
                            Is.BASLANGIC_TARIHI = tebligat.POSTALANMA_TARIH;
                            Is.YAPILACAK_IS = Is.ACIKLAMA;
                            if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                            {
                                Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                                Is.AJANDADA_GORUNSUN_MU = iliski.AJANDADA_GORUNSUN_MU.Value;
                            }

                            IsHelper.IsTarafEkle(iliski, foy, Is);
                            foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);
                        }
                    }

                    #endregion Dava Dilekçesi Dosyaya baðlanmamýþ uyarýsý
                }
            }

            #region Cevap Dilekçesi Dosyaya baðlanmamýþ uyarýsý

            TList<AV001_TDI_BIL_TEBLIGAT> tebList = new TList<AV001_TDI_BIL_TEBLIGAT>();
            tebList = TebligatBul(foy, Dilekce.Cevap_Dilekcesi);
            if (tebList.Count > 0)
            {
                iliski = isler.Find(TDIE_KOD_IS_ILISKIColumn.IS_KONU_ID, 24);

                foreach (AV001_TDI_BIL_TEBLIGAT teb in tebList)
                {
                    if (teb.NN_BELGE_TEBLIGATCollection.Count == 0)
                    {
                        if (
                            !IsHelper.IsVarmi(UcretlendirilmisIsler.TEBLIGAT_ISLERI,
                                              IsHelper.BitisTarihiHesapla(teb.POSTALANMA_TARIH, iliski), foy))
                        {
                            AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                            Is.KATEGORI_ID = (int)UcretlendirilmisIsler.TEBLIGAT_ISLERI;
                            Is.ONCELIK_ID = iliski.IS_ONCELIK_ID;
                            Is.KONU = IsHelper.IsKonusu(iliski);
                            Is.STAMP = 0;
                            Is.ONGORULEN_BITIS_TARIHI = IsHelper.BitisTarihiHesapla(teb.POSTALANMA_TARIH, iliski);
                            Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                            new[]
                                                                {
                                                                    foy.FOY_NO, teb.TEBLIGAT_REFERANS_NO,
                                                                    Is.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString()
                                                                });
                            Is.BASLANGIC_TARIHI = teb.POSTALANMA_TARIH;
                            Is.YAPILACAK_IS = Is.ACIKLAMA;
                            if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                            {
                                Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                                Is.AJANDADA_GORUNSUN_MU = iliski.AJANDADA_GORUNSUN_MU.Value;
                            }

                            IsHelper.IsTarafEkle(iliski, foy, Is);
                            foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);
                        }
                    }
                }
            }

            #endregion Cevap Dilekçesi Dosyaya baðlanmamýþ uyarýsý

            #region Replik Dilekçesi Dosyaya Baðlanmamýþ Uyarýsý

            tebList = TebligatBul(foy, Dilekce.Replik_Dilekcesi);
            if (tebList.Count > 0)
            {
                iliski = isler.Find(TDIE_KOD_IS_ILISKIColumn.IS_KONU_ID, 25);

                foreach (AV001_TDI_BIL_TEBLIGAT teb in tebList)
                {
                    if (teb.NN_BELGE_TEBLIGATCollection.Count == 0)
                    {
                        if (
                            !IsHelper.IsVarmi(UcretlendirilmisIsler.TEBLIGAT_ISLERI,
                                              IsHelper.BitisTarihiHesapla(teb.POSTALANMA_TARIH, iliski), foy))
                        {
                            AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                            Is.KATEGORI_ID = (int)UcretlendirilmisIsler.TEBLIGAT_ISLERI;
                            Is.ONCELIK_ID = iliski.IS_ONCELIK_ID;
                            Is.KONU = IsHelper.IsKonusu(iliski);
                            Is.STAMP = 0;
                            Is.ONGORULEN_BITIS_TARIHI = IsHelper.BitisTarihiHesapla(teb.POSTALANMA_TARIH, iliski);
                            Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                            new[]
                                                                {
                                                                    foy.FOY_NO, teb.TEBLIGAT_REFERANS_NO,
                                                                    Is.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString()
                                                                });
                            Is.BASLANGIC_TARIHI = teb.POSTALANMA_TARIH;
                            Is.YAPILACAK_IS = Is.ACIKLAMA;
                            if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                            {
                                Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                                Is.AJANDADA_GORUNSUN_MU = iliski.AJANDADA_GORUNSUN_MU.Value;
                            }

                            IsHelper.IsTarafEkle(iliski, foy, Is);
                            foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);
                        }
                    }
                }
            }

            #endregion Replik Dilekçesi Dosyaya Baðlanmamýþ Uyarýsý

            #region Duplik Dilekçesi Dosyaya Baðlanmamýþ Uyarýsý

            tebList = TebligatBul(foy, Dilekce.Duplik_Dilekcesi);
            if (tebList.Count > 0)
            {
                iliski = isler.Find(TDIE_KOD_IS_ILISKIColumn.IS_KONU_ID, 26);

                foreach (AV001_TDI_BIL_TEBLIGAT teb in tebList)
                {
                    if (teb.NN_BELGE_TEBLIGATCollection.Count == 0)
                    {
                        if (
                            !IsHelper.IsVarmi(UcretlendirilmisIsler.TEBLIGAT_ISLERI,
                                              IsHelper.BitisTarihiHesapla(teb.POSTALANMA_TARIH, iliski), foy))
                        {
                            AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                            Is.KATEGORI_ID = (int)UcretlendirilmisIsler.TEBLIGAT_ISLERI;
                            Is.ONCELIK_ID = iliski.IS_ONCELIK_ID;
                            Is.KONU = IsHelper.IsKonusu(iliski);
                            Is.STAMP = 0;
                            Is.ONGORULEN_BITIS_TARIHI = IsHelper.BitisTarihiHesapla(teb.POSTALANMA_TARIH, iliski);
                            Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                            new[]
                                                                {
                                                                    foy.FOY_NO, teb.TEBLIGAT_REFERANS_NO,
                                                                    Is.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString()
                                                                });
                            Is.BASLANGIC_TARIHI = teb.POSTALANMA_TARIH;
                            Is.YAPILACAK_IS = Is.ACIKLAMA;
                            if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                            {
                                Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                                Is.AJANDADA_GORUNSUN_MU = iliski.AJANDADA_GORUNSUN_MU.Value;
                            }

                            IsHelper.IsTarafEkle(iliski, foy, Is);
                            foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);
                        }
                    }
                }
            }

            #endregion Duplik Dilekçesi Dosyaya Baðlanmamýþ Uyarýsý

            #region Temyiz Dilekçesi Dosyaya Baðlanmamýþ Uyarýsý

            tebList = TebligatBul(foy, Dilekce.Temyiz_Dilekcesi);
            if (tebList.Count > 0)
            {
                iliski = isler.Find(TDIE_KOD_IS_ILISKIColumn.IS_KONU_ID, 27);

                foreach (AV001_TDI_BIL_TEBLIGAT teb in tebList)
                {
                    if (teb.NN_BELGE_TEBLIGATCollection.Count == 0)
                    {
                        if (
                            !IsHelper.IsVarmi(UcretlendirilmisIsler.TEBLIGAT_ISLERI,
                                              IsHelper.BitisTarihiHesapla(teb.POSTALANMA_TARIH, iliski), foy))
                        {
                            AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                            Is.KATEGORI_ID = (int)UcretlendirilmisIsler.TEBLIGAT_ISLERI;
                            Is.ONCELIK_ID = iliski.IS_ONCELIK_ID;
                            Is.KONU = IsHelper.IsKonusu(iliski);
                            Is.STAMP = 0;
                            Is.ONGORULEN_BITIS_TARIHI = IsHelper.BitisTarihiHesapla(teb.POSTALANMA_TARIH, iliski);
                            Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                            new[]
                                                                {
                                                                    foy.FOY_NO, teb.TEBLIGAT_REFERANS_NO,
                                                                    Is.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString()
                                                                });
                            Is.BASLANGIC_TARIHI = teb.POSTALANMA_TARIH;
                            Is.YAPILACAK_IS = Is.ACIKLAMA;
                            if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                            {
                                Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                                Is.AJANDADA_GORUNSUN_MU = iliski.AJANDADA_GORUNSUN_MU.Value;
                            }

                            IsHelper.IsTarafEkle(iliski, foy, Is);
                            foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);
                        }
                    }
                }
            }

            #endregion Temyiz Dilekçesi Dosyaya Baðlanmamýþ Uyarýsý

            #region Kanýt Dilekçesi Dosyaya Baðlanmamýþ Uyarýsý

            tebList = TebligatBul(foy, Dilekce.Kanit_Dilekcesi);
            if (tebList.Count > 0)
            {
                iliski = isler.Find(TDIE_KOD_IS_ILISKIColumn.IS_KONU_ID, 28);

                foreach (AV001_TDI_BIL_TEBLIGAT teb in tebList)
                {
                    if (teb.NN_BELGE_TEBLIGATCollection.Count == 0)
                    {
                        if (
                            !IsHelper.IsVarmi(UcretlendirilmisIsler.TEBLIGAT_ISLERI,
                                              IsHelper.BitisTarihiHesapla(teb.POSTALANMA_TARIH, iliski), foy))
                        {
                            AV001_TDI_BIL_IS Is = new AV001_TDI_BIL_IS();
                            Is.KATEGORI_ID = (int)UcretlendirilmisIsler.TEBLIGAT_ISLERI;
                            Is.ONCELIK_ID = iliski.IS_ONCELIK_ID;
                            Is.KONU = IsHelper.IsKonusu(iliski);
                            Is.STAMP = 0;
                            Is.ONGORULEN_BITIS_TARIHI = IsHelper.BitisTarihiHesapla(teb.POSTALANMA_TARIH, iliski);
                            Is.ACIKLAMA = IsHelper.Aciklama(foy, iliski,
                                                            new[]
                                                                {
                                                                    foy.FOY_NO, teb.TEBLIGAT_REFERANS_NO,
                                                                    Is.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString()
                                                                });
                            Is.BASLANGIC_TARIHI = teb.POSTALANMA_TARIH;
                            Is.YAPILACAK_IS = Is.ACIKLAMA;
                            if (iliski.MUHASEBELESTIRILSIN_MI.HasValue && iliski.AJANDADA_GORUNSUN_MU.HasValue)
                            {
                                Is.MUHASEBELESTIRILSIN_MI = iliski.MUHASEBELESTIRILSIN_MI.Value;
                                Is.AJANDADA_GORUNSUN_MU = iliski.AJANDADA_GORUNSUN_MU.Value;
                            }

                            IsHelper.IsTarafEkle(iliski, foy, Is);
                            foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Add(Is);
                        }
                    }
                }
            }

            #endregion Kanýt Dilekçesi Dosyaya Baðlanmamýþ Uyarýsý

            if (foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY != null &&
                foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Count > 0)
            {
                for (int i = 0; i < foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY.Count; i++)
                {
                    if (foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].IsNew)
                    {
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].ADLI_BIRIM_ADLIYE_ID =
                            foy.ADLI_BIRIM_ADLIYE_ID;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].ADLI_BIRIM_GOREV_ID =
                            foy.ADLI_BIRIM_GOREV_ID;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].ADLI_BIRIM_NO_ID = foy.ADLI_BIRIM_NO_ID;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].MODUL_ID = 2;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].DURUM = false;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].BASLANGIC_TARIHI = DateTime.Today;
                        if (foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].ADLI_BIRIM_ADLIYE_ID.HasValue)
                            foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].YER =
                                IsYeri(foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i]);
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].HER_GUN_MU = false;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].STATU_ID = 0;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].ETIKET_ID = 0;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].ESAS_NO = foy.ESAS_NO;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].REFERANS_NO = Guid.NewGuid().ToString("N");
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].STAMP = 1;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].KAYIT_TARIHI = DateTime.Today;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].KLASOR_KODU = "GENEL";
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].SUBE_KODU = 1;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].KONTROL_KIM = "AVUKATPRO";
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].KONTROL_NE_ZAMAN = DateTime.Today;
                        foy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY[i].KONTROL_VERSIYON = 1;
                    }
                }
            }
        }

        #endregion Public Methods
    }

    #region Enums

    public enum Dilekce
    {
        Cevap_Dilekcesi,
        Replik_Dilekcesi,
        Duplik_Dilekcesi,
        Temyiz_Dilekcesi,
        Kanit_Dilekcesi
    }

    public enum IsOncelik
    {
        ÇOK_ACÝL = 1,
        ACÝL = 2,
        NORMAL = 3,
        BEKLEYEBÝLÝR = 4
    }

    internal enum Grup
    {
        Sorumlusu = 1,
        Yetkilisi = 2,
        Sahibi = 3,
        Planlayan = 4,
        Hepsi = 5
    }

    internal enum HatýrlatmaSekli
    {
        Mail = 0,
        Fax = 1,
        Sms = 2,
        Yazýcý = 3,
        Rapor = 4,
        Uyarý = 5,
        Makro = 6
    }
    public enum Sektor
    {
        Bankacýlýk = 1,
        Sigortacýlýk = 2,
        Finans_ve_Faktöring = 3,
        Telekomnikasyon = 4,
        Enerji = 5,
        STÖ = 6,
        Genel = 7
    }
    #endregion Enums
}