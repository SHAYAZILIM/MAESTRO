using AvukatProLib2.Data;
using AvukatProLib2.Data.Bases;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AvukatProLib.Hesap
{
    public class HesapAraclari
    {
        public class Icra
        {
            /// <summary>
            /// Alacaklı Taraf Sayısı Döndürür
            /// </summary>
            /// <param name="IcraFoyId"></param>
            /// <returns></returns>
            public static int AlacakliTarafSayisi(int IcraFoyId)
            {
                string SorguCumlesi = "select COUNT(ID)  from dbo.AV001_TI_BIL_FOY_TARAF where TAKIP_EDEN_MI = 1 AND ICRA_FOY_ID = @FoyId";

                SqlCommand com = new SqlCommand(SorguCumlesi);
                var param = com.Parameters.Add("@FoyId", System.Data.SqlDbType.Int);
                param.Value = IcraFoyId;
                var soncu = (int)DataRepository.Provider.ExecuteScalar(com);

                return soncu;
            }

            /// <summary>
            /// Alacak Neden KodId sine göre adını döndürür
            /// </summary>
            /// <param name="kodId"></param>
            /// <returns></returns>
            public static string AlacakNedenAdiGetirByAlacakNedenKodId(int? kodId)
            {
                if (!kodId.HasValue)
                    return string.Empty;

                string SorguCumlesi = string.Format(@"select ALACAK_NEDENI from dbo.TI_KOD_ALACAK_NEDEN where ID = @Id ");

                SqlCommand com = new SqlCommand(SorguCumlesi);

                var paramCariId = com.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                paramCariId.Value = kodId;

                var sonuc = DataRepository.Provider.ExecuteScalar(com);
                if (sonuc != null)
                {
                    return sonuc.ToString();
                }

                return string.Empty;
            }

            /// <summary>
            /// İlgili Alacak Neden Kaydının Çek Yaprağı Olup Olmadığının Kontrolünü Yapıyor
            /// </summary>
            /// <param name="aNeden"></param>
            /// <returns></returns>
            public static bool AlacakNedenCekYapragimi(AV001_TI_BIL_ALACAK_NEDEN aNeden)
            {
                int[] dizi = new int[] { 93, 94, 95, 96, 97, 98 };

                if (aNeden.ALACAK_NEDEN_KOD_ID > 92 && aNeden.ALACAK_NEDEN_KOD_ID < 99)
                    return true;

                return false;
            }

            public static bool AlacakNedenCekYapragimi(AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN aNeden)
            {
                int[] dizi = new int[] { 93, 94, 95, 96, 97, 98 };

                if (aNeden.ALACAK_NEDEN_KOD_ID > 92 && aNeden.ALACAK_NEDEN_KOD_ID < 99)
                    return true;

                return false;
            }

            /// <summary>
            /// İlgili Föyün İlgili Tarafına ait çek yaprağı kayıtlarını dönödürür
            /// * Sadece Depo Alacağı Koşullarına uyanlar Döndürülür
            /// </summary>
            /// <param name="foy"></param>
            /// <param name="foyTaraf"></param>
            /// <returns></returns>
            public static TList<AV001_TI_BIL_ALACAK_NEDEN> AlacakNedenCelYapraklariByFoyAndTaraf(AV001_TI_BIL_FOY foy, AV001_TI_BIL_FOY_TARAF foyTaraf)
            {
                var depoNEdenleri = AlacakNedenGayriNakitleriGetir(foy);

                var alacakNEdenTaraflar = AlacakNedenTarafGetFoyAndTaraf(foy, foyTaraf);

                var tarafinDeposuzAlacakNedenleri = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

                foreach (var neden in depoNEdenleri)
                {
                    foreach (var taraf in alacakNEdenTaraflar)
                    {
                        if (neden.ID == taraf.ICRA_ALACAK_NEDEN_ID && AlacakNedenCekYapragimi(neden))
                            tarafinDeposuzAlacakNedenleri.Add(neden);
                    }
                }

                return tarafinDeposuzAlacakNedenleri;
            }

            public static List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN> AlacakNedenCelYapraklariByFoyAndTarafPerf(AV001_TI_BIL_FOY foy, AV001_TI_BIL_FOY_TARAF foyTaraf)
            {   //Todo Buraya Bakılacak
                /*
                var depoNEdenleri = AlacakNedenGayriNakitleriGetir(foy);

                var alacakNEdenTaraflar = AlacakNedenTarafGetFoyAndTaraf(foy, foyTaraf);

                var tarafinDeposuzAlacakNedenleri = new List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN>();

                foreach (var neden in depoNEdenleri)
                {
                    foreach (var taraf in alacakNEdenTaraflar)
                    {
                        if (neden.ID == taraf.ICRA_ALACAK_NEDEN_ID && AlacakNedenCekYapragimi(neden))
                            tarafinDeposuzAlacakNedenleri.Add(neden);
                    }
                }

                return tarafinDeposuzAlacakNedenleri;
                 */
                return new List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN>();
            }

            /// <summary>
            /// Verilen alacak nedeni depo alacağı olup olmadığınını döndür
            /// alacak neden kodu ve vade tarihinin olmaması kontrol edilmekte
            /// </summary>
            /// <param name="neden"></param>
            /// <returns></returns>
            public static bool AlacakNedenDepoAlacagiMi(AV001_TI_BIL_ALACAK_NEDEN neden)
            {
                if (neden.ALACAK_NEDEN_KOD_ID.HasValue
                    && neden.ALACAK_NEDEN_KOD_ID.Value > 92 // Depo alacakları 93 den
                    && neden.ALACAK_NEDEN_KOD_ID.Value < 129 // 128 e kadar devam etmektedi
                    && !neden.VADE_TARIHI.HasValue)
                    return true;

                return false;
            }

            public static bool AlacakNedenDepoAlacagiMi(AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN neden)
            {
                if (neden.ALACAK_NEDEN_KOD_ID.HasValue
                    && neden.ALACAK_NEDEN_KOD_ID.Value > 92 // Depo alacakları 93 den
                    && neden.ALACAK_NEDEN_KOD_ID.Value < 129 // 128 e kadar devam etmektedi
                    && !neden.VADE_TARIHI.HasValue)
                    return true;

                return false;
            }

            /// <summary>
            /// Verilen alacak nedeni depo alacağı olup nakite donduğunu döndür
            /// alacak neden kodu ve vade tarihinin olması kontrol edilmekte
            /// </summary>
            /// <param name="neden"></param>
            /// <returns></returns>
            public static bool AlacakNedenDepoAlacagiNakiteDonmusMu(AV001_TI_BIL_ALACAK_NEDEN neden)
            {
                if (neden.ALACAK_NEDEN_KOD_ID.HasValue
                    && neden.ALACAK_NEDEN_KOD_ID.Value > 92 // Depo alacakları 93 den
                    && neden.ALACAK_NEDEN_KOD_ID.Value < 129 // 128 e kadar devam etmektedi
                    && neden.VADE_TARIHI.HasValue)
                    return true;

                return false;
            }

            /// <summary>
            /// İlgili Föyün İlgili Tarafına bağlı Depo Alacaklarını Döndürür
            /// </summary>
            /// <param name="foy"></param>
            /// <param name="foyTaraf"></param>
            /// <returns></returns>
            public static TList<AV001_TI_BIL_ALACAK_NEDEN> AlacakNedenDepoAlacaklariByFoyAndTaraf(AV001_TI_BIL_FOY foy, AV001_TI_BIL_FOY_TARAF foyTaraf)
            {
                var depoNEdenleri = AlacakNedenGayriNakitleriGetir(foy);

                var alacakNEdenTaraflar = AlacakNedenTarafGetFoyAndTaraf(foy, foyTaraf);

                var tarafinDeposuzAlacakNedenleri = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

                foreach (var neden in depoNEdenleri)
                {
                    foreach (var taraf in alacakNEdenTaraflar)
                    {
                        if (neden.ID == taraf.ICRA_ALACAK_NEDEN_ID)
                            tarafinDeposuzAlacakNedenleri.Add(neden);
                    }
                }

                return tarafinDeposuzAlacakNedenleri;
            }

            public static List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN> AlacakNedenDepoAlacaklariByFoyAndTarafPerf(AV001_TI_BIL_FOY foy, AV001_TI_BIL_FOY_TARAF foyTaraf)
            {
                /* Todo
                var depoNEdenleri = AlacakNedenGayriNakitleriGetir(foy);

                var alacakNEdenTaraflar = AlacakNedenTarafGetFoyAndTaraf(foy, foyTaraf);

                var tarafinDeposuzAlacakNedenleri = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

                foreach (var neden in depoNEdenleri)
                {
                    foreach (var taraf in alacakNEdenTaraflar)
                    {
                        if (neden.ID == taraf.ICRA_ALACAK_NEDEN_ID)
                            tarafinDeposuzAlacakNedenleri.Add(neden);
                    }
                }

                return tarafinDeposuzAlacakNedenleri;
                 * */
                return new List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN>();
            }

            /// <summary>
            /// Deposuz Alacak Nedenlerini Geri Döndür
            /// </summary>
            /// <param name="foy"></param>
            /// <returns></returns>
            public static TList<AV001_TI_BIL_ALACAK_NEDEN> AlacakNedenGayriNakitleriGetir(AV001_TI_BIL_FOY foy)
            {
                if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                }

                var liste = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

                foreach (var aNeden in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    if (AlacakNedenDepoAlacagiMi(aNeden))
                        liste.Add(aNeden);
                }

                return liste;
            }

            /// <summary>
            /// İlgili Alacak Neden Kaydının MER`İ TEMİNAT MEKTUBU Olup Olmadığının Kontrolünü Yapıyor
            /// </summary>
            /// <param name="aNeden"></param>
            /// <returns></returns>
            public static bool AlacakNedenMeriTeminatMektubuMu(AV001_TI_BIL_ALACAK_NEDEN aNeden)
            {
                //int[] dizi = new int[] { 93, 94, 95, 96, 97, 98 };

                if (aNeden.ALACAK_NEDEN_KOD_ID > 98 && aNeden.ALACAK_NEDEN_KOD_ID < 105)
                    return true;

                return false;
            }

            /// <summary>
            /// Nakite Dönmüş Deposuz Alacak Nedenlerini Geri Döndür
            /// </summary>
            /// <param name="foy"></param>
            /// <returns></returns>
            public static TList<AV001_TI_BIL_ALACAK_NEDEN> AlacakNedenNakiteDonmusGayriNakitleriGetir(AV001_TI_BIL_FOY foy)
            {
                if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                }

                var liste = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

                foreach (var aNeden in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    if (AlacakNedenDepoAlacagiNakiteDonmusMu(aNeden))
                        liste.Add(aNeden);
                }

                return liste;
            }

            /// <summary>
            /// Verilen Tarafın Verilen föy üzeridne Borçlu olup olmadığını döndürüyor
            /// </summary>
            /// <param name="foyId"></param>
            /// <param name="tarafId"></param>
            /// <returns></returns>
            public static bool AlacakNedenTarafBoclumu(int foyId, int tarafId)
            {
                string SorguCumlesi = string.Format(@"select TAKIP_EDEN_MI from dbo.AV001_TI_BIL_FOY_TARAF where ICRA_FOY_ID = @FoyId and CARI_ID = @CariId ");

                SqlCommand com = new SqlCommand(SorguCumlesi);
                var paramFoyId = com.Parameters.Add("@FoyId", System.Data.SqlDbType.Int);
                var paramCariId = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
                paramCariId.Value = tarafId;
                paramFoyId.Value = foyId;

                var sonuc = DataRepository.Provider.ExecuteScalar(com);
                if (sonuc != null)
                {
                    return !(bool)sonuc;
                }

                return false;
            }

            /// <summary>
            /// İlgili Tarafın Föye Bağlı tüm alacak nedenlerindeki taraflarını Döndürür
            /// </summary>
            /// <param name="foy"></param>
            /// <param name="foyTaraf"></param>
            /// <returns></returns>
            public static TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> AlacakNedenTarafGetFoyAndTaraf(AV001_TI_BIL_FOY foy, AV001_TI_BIL_FOY_TARAF foyTaraf)
            {
                if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                    if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count > 0)
                        DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(foy.AV001_TI_BIL_ALACAK_NEDENCollection, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_ALACAK_NEDEN_TARAF));
                }
                else if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count > 0)
                {
                    if (foy.AV001_TI_BIL_ALACAK_NEDENCollection[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count == 0)
                        DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(foy.AV001_TI_BIL_ALACAK_NEDENCollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
                }

                TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> tarafinNedenleri = new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>();
                foreach (var neden in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    foreach (var nedenTaraf in neden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                    {
                        if (nedenTaraf.TARAF_CARI_ID == foyTaraf.CARI_ID)
                            tarafinNedenleri.Add(nedenTaraf);
                    }
                }
                return tarafinNedenleri;
            }

            /// <summary>
            /// Verilen Föyün Borçlu Taraflarını döndür
            /// </summary>
            /// <param name="foy"></param>
            /// <returns></returns>
            public static TList<AV001_TI_BIL_FOY_TARAF> BorclulariGetir(AV001_TI_BIL_FOY foy)
            {
                //var tarafList = BelgeUtil.Inits.BorcluTarafGetir(foy); // Okan 17.08.2010
                Dictionary<int?, int?> cariSozlugu = new Dictionary<int?, int?>();

                TList<AV001_TI_BIL_FOY_TARAF> taraflar = new TList<AV001_TI_BIL_FOY_TARAF>();
                TList<AV001_TI_BIL_FOY_TARAF> tarafList = DataRepository.AV001_TI_BIL_FOY_TARAFProvider.Find(String.Format("ICRA_FOY_ID = {0} AND TARAF_KODU = {1}", foy.ID, (byte)AvukatProLib.Extras.TarafKodu.KarsiTaraf));
                foreach (var taraf in tarafList)
                {
                    if (!(cariSozlugu.ContainsKey(taraf.CARI_ID) && cariSozlugu.ContainsValue(taraf.TARAF_SIFAT_ID)))
                    {
                        taraflar.Add(taraf);
                        cariSozlugu.Add(taraf.CARI_ID, taraf.TARAF_SIFAT_ID);
                    }
                }
                return taraflar;
            }

            /// <summary>
            /// Borçlu İcra Taraflarının Saysını Döndürür
            /// </summary>
            /// <param name="IcraFoyId">İcra Föy Kaydının ID si </param>
            /// <returns></returns>
            public static int BorcluTarafSayisi(int IcraFoyId)
            {
                string SorguCumlesi = "select COUNT(ID)  from dbo.AV001_TI_BIL_FOY_TARAF where TAKIP_EDEN_MI = 0 AND ICRA_FOY_ID = @FoyId";

                SqlCommand com = new SqlCommand(SorguCumlesi);
                var param = com.Parameters.Add("@FoyId", System.Data.SqlDbType.Int);
                param.Value = IcraFoyId;
                var soncu = (int)DataRepository.Provider.ExecuteScalar(com);

                return soncu;
            }

            public static string CariAdiGetirByCariId(int? cariId)
            {
                if (cariId == null)
                    return string.Empty;
                string SorguCumlesi = string.Format(@"select AD from dbo.AV001_TDI_BIL_CARI where ID = @CariId ");

                SqlCommand com = new SqlCommand(SorguCumlesi);

                var paramCariId = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
                paramCariId.Value = cariId;

                var sonuc = DataRepository.Provider.ExecuteScalar(com);
                if (sonuc != null)
                {
                    return sonuc.ToString();
                }

                return string.Empty;
            }

            public static string CariAdiYetkiDurumuGetirByCariId(int cariId)
            {
                string SorguCumlesi = string.Format(@"SELECT  AD +
                                            CASE
                                            WHEN YETKILI_MI = 0 THEN '#(SORUMLU)'
                                            WHEN YETKILI_MI = 1 THEN '#(İZLEYEN)'
                                            END  AS AD
                                            FROM dbo.AV001_TDI_BIL_CARI WHERE ID = @CariId");
                SqlCommand com = new SqlCommand(SorguCumlesi);

                var paramCariId = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
                paramCariId.Value = cariId;

                var sonuc = DataRepository.Provider.ExecuteScalar(com);
                if (sonuc != null)
                {
                    return sonuc.ToString();
                }

                return string.Empty;
            }

            public static TList<AV001_TI_BIL_ALACAK_NEDEN> GetAlacakNedenBonolar(AV001_TI_BIL_FOY foy)
            {
                TList<AV001_TI_BIL_ALACAK_NEDEN> alacaklar = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
                var dizi = new int?[] { 2, 36, 11, 38, 137, 138, 139, 140 }; //Bono Id leri

                if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));

                foreach (var item in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    if (dizi.Contains(item.ALACAK_NEDEN_KOD_ID))
                        alacaklar.Add(item);
                }

                return alacaklar;
            }

            public static TList<AV001_TI_BIL_ALACAK_NEDEN> GetAlacakNedenCekler(AV001_TI_BIL_FOY foy)
            {
                TList<AV001_TI_BIL_ALACAK_NEDEN> alacaklar = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
                var dizi = new int?[] { 1, 33, 34, 35, 129, 130, 131, 132 }; //Çek Id leri

                if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));

                foreach (var item in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    if (dizi.Contains(item.ALACAK_NEDEN_KOD_ID))
                        alacaklar.Add(item);
                }

                return alacaklar;
            }

            public static int GetAlacakNedeniByByAlacakNedenIdAndFormTipId(int alacakNedenId, int fromTipID)
            {
                var alacakNEdenleri = TI_KOD_ALACAK_NEDENProviderBase.Fill(
                  DataRepository.Provider.ExecuteReader("dbo._TI_KOD_ALACAK_NEDEN_GetByAlacakNedenIdAndFormTipId", alacakNedenId, fromTipID), new TList<TI_KOD_ALACAK_NEDEN>(), 0, int.MaxValue);

                if (alacakNEdenleri != null && alacakNEdenleri.Count > 0)
                {
                    return alacakNEdenleri[0].ID;
                }

                return alacakNedenId;
            }

            public static TList<AV001_TI_BIL_FOY> GetIliskiliAltIcraDosyalariByFoyId(int icraFoyId)
            {
                var sorgu = string.Format(@"SELECT * FROM AV001_TI_BIL_FOY WHERE ID IN
                    (select HEDEF_ICRA_FOY_ID from dbo.AV001_TDI_BIL_KAYIT_ILISKI_DETAY WHERE KAYIT_ILISKI_ID IN
                    (SELECT ID FROM AV001_TDI_BIL_KAYIT_ILISKI WHERE KAYNAK_ICRA_FOY_ID = {0} AND ILISKI_TUR_ID = 601 AND ILISKI_NEDEN_ID = 1))", icraFoyId);

                var sonuc = AV001_TI_BIL_FOYProviderBase.Fill(
                    DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu), new TList<AV001_TI_BIL_FOY>(), 0, int.MaxValue);
                return sonuc;
            }

            public static bool GetTarafSifatTakipEdenMi(int? tarafSifatId)
            {
                if (!tarafSifatId.HasValue) return false;

                List<int> liste = new List<int>() { 1, 5, 87, 88, 89, 90 };    //Taraf Sıfat tapblosunda takip edenmi id leri

                return liste.Contains(tarafSifatId.Value);
            }

            /// <summary>
            /// Verilen föy tarafının vekillerine count kontrolü yapar ve 0 olması durumunda deepload çekerek sonucu döndürür,
            /// </summary>
            /// <param name="taraf"></param>
            /// <returns></returns>
            public static TList<AV001_TI_BIL_FOY_TARAF_VEKIL> GetVekilByFoyTaraf(AV001_TI_BIL_FOY_TARAF taraf)
            {
                if (taraf == null) //kullanıldığı yerde null kontrolü gerektirmesin diye
                    return new TList<AV001_TI_BIL_FOY_TARAF_VEKIL>();

                if (taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(taraf, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF_VEKIL>));

                return taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection;
            }

            /// <summary>
            /// TDI_KOD_OZEL_TUTAR_KONU tablosundan bir id gönderiyorsunuz size konusunu getiriyor
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public static string OzelTutarKonuGetir(int ozelTutarKonuId)
            {
                string SorguCumlesi = string.Format(@"select KONU from dbo.TDI_KOD_OZEL_TUTAR_KONU where ID = @Id ");

                SqlCommand com = new SqlCommand(SorguCumlesi);

                var paramKonuId = com.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                paramKonuId.Value = ozelTutarKonuId;

                var sonuc = DataRepository.Provider.ExecuteScalar(com);
                if (sonuc != null)
                {
                    return sonuc.ToString();
                }

                return string.Empty;
            }

            /// <summary>
            /// Verilen icra foy id sine göre sorumlu avukat sayısını döndürür.
            /// </summary>
            /// <param name="IcraFoyId"></param>
            /// <returns></returns>
            public static int SorumluAvukatSayisi(int IcraFoyId)
            {
                string SorguCumlesi = "select COUNT(ID) from AV001_TI_BIL_FOY_SORUMLU_AVUKAT WHERE ICRA_FOY_ID = @FoyId";

                SqlCommand com = new SqlCommand(SorguCumlesi);
                var param = com.Parameters.Add("@FoyId", System.Data.SqlDbType.Int);
                param.Value = IcraFoyId;
                var soncu = (int)DataRepository.Provider.ExecuteScalar(com);

                return soncu;
            }

            public static TList<AV001_TI_BIL_FOY_TARAF> TakipEdenleriGetir(AV001_TI_BIL_FOY foy)
            {
                TList<AV001_TI_BIL_FOY_TARAF> taraflar = new TList<AV001_TI_BIL_FOY_TARAF>();
                if (foy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));

                foreach (var taraf in foy.AV001_TI_BIL_FOY_TARAFCollection)
                {
                    if (taraf.TARAF_SIFAT_IDSource == null)
                        DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(taraf, false, DeepLoadType.IncludeChildren, typeof(TDIE_KOD_TARAF_SIFAT));
                    if (taraf.TARAF_SIFAT_IDSource != null && taraf.TARAF_SIFAT_IDSource.HANGI_TARAF_NO == 1) // Takip Eden
                    {
                        taraflar.Add(taraf);
                    }
                }
                return taraflar;
            }

            public class DavaHesabi
            {
                #region Tutar Kalemlerini Toplanma İşlemi

                public static void SetFoyAlanlariTopla(AV001_TI_BIL_FOY obj)
                {
                    SetTakipOncesiHarclarToplami(obj);
                    SetTakipHarcToplamlari(obj);
                    SetTakipOncesiOdemeVeMahsupBilgileriToplamlari(obj);
                    SetTakipOncesiMasraflar(obj);
                    SetIlkGiderlerToplamlari(obj);
                    SetTakipSonrasiMasraflarToplami(obj);
                    SetMasrafToplamlari(obj);
                    SetTakipSonrasiVekaletToplamlari(obj);
                    SetTakipCikisi(obj);
                    SetAlacakToplami(obj);
                    SetKalanBorc(obj);
                }

                /// <summary>
                /// Alacak Toplamını Hesaplıyor
                /// </summary>
                /// <param name="obj"></param>
                private static void SetAlacakToplami(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prSONRAKI_FAIZ = new ParaVeDovizId(obj.SONRAKI_FAIZ, obj.SONRAKI_FAIZ_DOVIZ_ID);
                    ParaVeDovizId prTAKIP_CIKISI = new ParaVeDovizId(obj.TAKIP_CIKISI, obj.TAKIP_CIKISI_DOVIZ_ID);
                    ParaVeDovizId prBSMV_TS = new ParaVeDovizId(obj.BSMV_TS, obj.BSMV_TS_DOVIZ_ID);
                    ParaVeDovizId prOIV_TS = new ParaVeDovizId(obj.OIV_TS, obj.OIV_TS_DOVIZ_ID);
                    ParaVeDovizId prKDV_TS = new ParaVeDovizId(obj.KDV_TS, obj.KDV_TS_DOVIZ_ID);
                    ParaVeDovizId prSONRAKI_TAZMINAT = new ParaVeDovizId(obj.SONRAKI_TAZMINAT, obj.SONRAKI_TAZMINAT_DOVIZ_ID);
                    ParaVeDovizId prBIRIKMIS_NAFAKA = new ParaVeDovizId(obj.BIRIKMIS_NAFAKA, obj.BIRIKMIS_NAFAKA_DOVIZ_ID);
                    ParaVeDovizId prTS_MASRAF_TOPLAMI = new ParaVeDovizId(obj.TS_MASRAF_TOPLAMI, obj.TS_MASRAF_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId prTS_VEKALET_TOPLAMI = new ParaVeDovizId(obj.TS_VEKALET_TOPLAMI, obj.TS_VEKALET_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId prHARC_TOPLAMI = new ParaVeDovizId(obj.HARC_TOPLAMI, obj.HARC_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId prICRA_INKAR_TAZMINATI = new ParaVeDovizId(obj.ICRA_INKAR_TAZMINATI, obj.ICRA_INKAR_TAZMINATI_DOVIZ_ID);
                    ParaVeDovizId prDAVA_INKAR_TAZMINATI = new ParaVeDovizId(obj.DAVA_INKAR_TAZMINATI, obj.DAVA_INKAR_TAZMINATI_DOVIZ_ID);

                    //Bakiye Harç Hesaba Dahilse Eklenecek
                    ParaVeDovizId prKALAN_TAHSIL_HARCI = new ParaVeDovizId(obj.KALAN_TAHSIL_HARCI, obj.KALAN_TAHSIL_HARCI_DOVIZ_ID);

                    var liste = new List<ParaVeDovizId>();

                    liste.Add(prSONRAKI_FAIZ);
                    liste.Add(prTAKIP_CIKISI);
                    liste.Add(prBSMV_TS);
                    liste.Add(prOIV_TS);
                    liste.Add(prKDV_TS);
                    liste.Add(prSONRAKI_TAZMINAT);
                    liste.Add(prBIRIKMIS_NAFAKA);
                    liste.Add(prTS_MASRAF_TOPLAMI);
                    liste.Add(prTS_VEKALET_TOPLAMI);
                    liste.Add(prHARC_TOPLAMI);
                    liste.Add(prICRA_INKAR_TAZMINATI);
                    liste.Add(prDAVA_INKAR_TAZMINATI);

                    var toplam = ParaVeDovizId.Topla(liste);

                    if (obj.BAKIYE_HARC_TOPLAMA_EKLE)
                    {
                        toplam = ParaVeDovizId.Topla(toplam, prKALAN_TAHSIL_HARCI);
                    }

                    obj.ALACAK_TOPLAMI = toplam.Para;
                    obj.ALACAK_TOPLAMI_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// İlk Gider Toplamları
                /// </summary>
                /// <param name="obj"></param>
                private static void SetIlkGiderlerToplamlari(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prILK_TEBLIGAT_GIDERI = new ParaVeDovizId(obj.ILK_TEBLIGAT_GIDERI, obj.ILK_TEBLIGAT_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prBASVURMA_HARCI = new ParaVeDovizId(obj.BASVURMA_HARCI, obj.BASVURMA_HARCI_DOVIZ_ID);
                    ParaVeDovizId prPESIN_HARC = new ParaVeDovizId(obj.PESIN_HARC, obj.PESIN_HARC_DOVIZ_ID);
                    ParaVeDovizId prIFLAS_BASVURMA_HARCI = new ParaVeDovizId(obj.IFLAS_BASVURMA_HARCI, obj.IFLAS_BASVURMA_HARCI_DOVIZ_ID);
                    ParaVeDovizId prIFLASIN_ACILMASI_HARCI = new ParaVeDovizId(obj.IFLASIN_ACILMASI_HARCI, obj.IFLASIN_ACILMASI_HARCI_DOVIZ_ID);
                    ParaVeDovizId prVEKALET_HARCI = new ParaVeDovizId(obj.VEKALET_HARCI, obj.VEKALET_HARCI_DOVIZ_ID);
                    ParaVeDovizId prVEKALET_PULU = new ParaVeDovizId(obj.VEKALET_PULU, obj.VEKALET_PULU_DOVIZ_ID);

                    var toplam = ParaVeDovizId.Topla(
                        prILK_TEBLIGAT_GIDERI, prBASVURMA_HARCI, prPESIN_HARC,
                        prIFLAS_BASVURMA_HARCI, prIFLASIN_ACILMASI_HARCI, prVEKALET_HARCI,
                        prVEKALET_PULU);

                    obj.ILK_GIDERLER = toplam.Para;
                    obj.ILK_GIDERLER_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// KalanHesaplar
                /// </summary>
                /// <param name="obj"></param>
                private static void SetKalanBorc(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prFERAGAT_TOPLAMI = new ParaVeDovizId(obj.FERAGAT_TOPLAMI, obj.FERAGAT_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId prODEME_TOPLAMI = new ParaVeDovizId(obj.ODEME_TOPLAMI, obj.ODEME_TOPLAMI_DOVIZ_ID);

                    var toplam = ParaVeDovizId.Topla(prFERAGAT_TOPLAMI, prODEME_TOPLAMI);

                    #region <YY-20090618>

                    //Cikart şeklinde olan şey - leri çıkarttığı için düzenleme yapılmıştır.
                    toplam = ParaVeDovizId.Topla(new ParaVeDovizId(obj.ALACAK_TOPLAMI, obj.ALACAK_TOPLAMI_DOVIZ_ID), toplam);

                    #endregion <YY-20090618>

                    obj.KALAN = toplam.Para;
                    obj.KALAN_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// Masraf Kalemlerini Döviz Toplam Kurallarına Uygun Olarak Toplayıp
                /// TUM_MASRAF_TOPLAMI alanı üzerine yazmaktadır
                /// </summary>
                /// <param name="obj"></param>
                private static void SetMasrafToplamlari(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prILK_TEBLIGAT_GIDERI = new ParaVeDovizId(obj.ILK_TEBLIGAT_GIDERI, obj.ILK_TEBLIGAT_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prBASVURMA_HARCI = new ParaVeDovizId(obj.BASVURMA_HARCI, obj.BASVURMA_HARCI_DOVIZ_ID);
                    ParaVeDovizId prPESIN_HARC = new ParaVeDovizId(obj.PESIN_HARC, obj.PESIN_HARC_DOVIZ_ID);
                    ParaVeDovizId prIFLAS_BASVURMA_HARCI = new ParaVeDovizId(obj.IFLAS_BASVURMA_HARCI, obj.IFLAS_BASVURMA_HARCI_DOVIZ_ID);
                    ParaVeDovizId prIFLASIN_ACILMASI_HARCI = new ParaVeDovizId(obj.IFLASIN_ACILMASI_HARCI, obj.IFLASIN_ACILMASI_HARCI_DOVIZ_ID);
                    ParaVeDovizId prVEKALET_HARCI = new ParaVeDovizId(obj.VEKALET_HARCI, obj.VEKALET_HARCI_DOVIZ_ID);
                    ParaVeDovizId prVEKALET_PULU = new ParaVeDovizId(obj.VEKALET_PULU, obj.VEKALET_PULU_DOVIZ_ID);
                    ParaVeDovizId prTD_GIDERI = new ParaVeDovizId(obj.TD_GIDERI, obj.TD_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prTD_TEBLIG_GIDERI = new ParaVeDovizId(obj.TD_TEBLIG_GIDERI, obj.TD_TEBLIG_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prDAVA_GIDERLERI = new ParaVeDovizId(obj.DAVA_GIDERLERI, obj.DAVA_GIDERLERI_DOVIZ_ID);
                    ParaVeDovizId prDIGER_GIDERLER = new ParaVeDovizId(obj.DIGER_GIDERLER, obj.DIGER_GIDERLER_DOVIZ_ID);
                    ParaVeDovizId prODENEN_TAHSIL_HARCI = new ParaVeDovizId(obj.ODENEN_TAHSIL_HARCI, obj.ODENEN_TAHSIL_HARCI_DOVIZ_ID);
                    ParaVeDovizId prDIGER_HARC = new ParaVeDovizId(obj.DIGER_HARC, obj.DIGER_HARC_DOVIZ_ID);
                    ParaVeDovizId prTD_BAKIYE_HARC = new ParaVeDovizId(obj.TD_BAKIYE_HARC, obj.TD_BAKIYE_HARC_DOVIZ_ID);
                    ParaVeDovizId prPAYLASMA_HARCI = new ParaVeDovizId(obj.PAYLASMA_HARCI, obj.PAYLASMA_HARCI_DOVIZ_ID);
                    ParaVeDovizId prMASAYA_KATILMA_HARCI = new ParaVeDovizId(obj.MASAYA_KATILMA_HARCI, obj.MASAYA_KATILMA_HARCI_DOVIZ_ID);

                    var liste = new List<ParaVeDovizId>();
                    liste.Add(prILK_TEBLIGAT_GIDERI);
                    liste.Add(prBASVURMA_HARCI);
                    liste.Add(prPESIN_HARC);
                    liste.Add(prIFLAS_BASVURMA_HARCI);
                    liste.Add(prIFLASIN_ACILMASI_HARCI);
                    liste.Add(prVEKALET_HARCI);
                    liste.Add(prVEKALET_PULU);
                    liste.Add(prTD_GIDERI);
                    liste.Add(prTD_TEBLIG_GIDERI);
                    liste.Add(prDAVA_GIDERLERI);
                    liste.Add(prDIGER_GIDERLER);
                    liste.Add(prODENEN_TAHSIL_HARCI);
                    liste.Add(prDIGER_HARC);
                    liste.Add(prTD_BAKIYE_HARC);
                    liste.Add(prPAYLASMA_HARCI);
                    liste.Add(prMASAYA_KATILMA_HARCI);

                    var toplam = ParaVeDovizId.Topla(liste);

                    obj.TUM_MASRAF_TOPLAMI = toplam.Para;
                    obj.TUM_MASRAF_TOPLAMI_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// İlgili Alanları Toplayarak Takip Çıkışını Hesaplar
                ///
                /// </summary>
                /// <param name="obj"></param>
                private static void SetTakipCikisi(AV001_TI_BIL_FOY obj)
                {
                    var list = new List<ParaVeDovizId>();

                    ParaVeDovizId prISLEMIS_FAIZ = new ParaVeDovizId(obj.ISLEMIS_FAIZ, obj.ISLEMIS_FAIZ_DOVIZ_ID);
                    ParaVeDovizId prBSMV_TO = new ParaVeDovizId(obj.BSMV_TO, obj.BSMV_TO_DOVIZ_ID);
                    ParaVeDovizId prKKDV_TO = new ParaVeDovizId(obj.KKDV_TO, obj.KKDV_TO_DOVIZ_ID);
                    ParaVeDovizId prOIV_TO = new ParaVeDovizId(obj.OIV_TO, obj.OIV_TO_DOVIZ_ID);
                    ParaVeDovizId prKDV_TO = new ParaVeDovizId(obj.KDV_TO, obj.KDV_TO_DOVIZ_ID);
                    ParaVeDovizId prKARSILIKSIZ_CEK_TAZMINATI = new ParaVeDovizId(obj.KARSILIKSIZ_CEK_TAZMINATI, obj.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID);
                    ParaVeDovizId prCEK_KOMISYONU = new ParaVeDovizId(obj.CEK_KOMISYONU, obj.CEK_KOMISYONU_DOVIZ_ID);
                    ParaVeDovizId prILAM_VEK_UCR = new ParaVeDovizId(obj.ILAM_VEK_UCR, obj.ILAM_VEK_UCR_DOVIZ_ID);
                    ParaVeDovizId prILAM_INKAR_TAZMINATI = new ParaVeDovizId(obj.ILAM_INKAR_TAZMINATI, obj.ILAM_INKAR_TAZMINATI_DOVIZ_ID);
                    ParaVeDovizId prILAM_TEBLIG_GIDERI = new ParaVeDovizId(obj.ILAM_TEBLIG_GIDERI, obj.ILAM_TEBLIG_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prILAM_BK_YARG_ONAMA = new ParaVeDovizId(obj.ILAM_BK_YARG_ONAMA, obj.ILAM_BK_YARG_ONAMA_DOVIZ_ID);
                    ParaVeDovizId prILAM_YARGILAMA_GIDERI = new ParaVeDovizId(obj.ILAM_YARGILAMA_GIDERI, obj.ILAM_YARGILAMA_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prIH_GIDERI = new ParaVeDovizId(obj.IH_GIDERI, obj.IH_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prIH_VEKALET_UCRETI = new ParaVeDovizId(obj.IH_VEKALET_UCRETI, obj.IH_VEKALET_UCRETI_DOVIZ_ID);
                    ParaVeDovizId prIT_GIDERI = new ParaVeDovizId(obj.IT_GIDERI, obj.IT_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prIT_VEKALET_UCRETI = new ParaVeDovizId(obj.IT_VEKALET_UCRETI, obj.IT_VEKALET_UCRETI_DOVIZ_ID);
                    ParaVeDovizId prTO_MASRAF_TOPLAMI = new ParaVeDovizId(obj.TO_MASRAF_TOPLAMI, obj.TO_MASRAF_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId prTO_ODEME_MAHSUP_TOPLAMI = new ParaVeDovizId(obj.TO_ODEME_MAHSUP_TOPLAMI, obj.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId prASIL_ALACAK = new ParaVeDovizId(obj.ASIL_ALACAK, obj.ASIL_ALACAK_DOVIZ_ID);
                    list.Add(new ParaVeDovizId(obj.OZEL_TUTAR1, obj.OZEL_TUTAR1_DOVIZ_ID, obj.TAKIP_TARIHI.Value));
                    list.Add(new ParaVeDovizId(obj.OZEL_TUTAR2, obj.OZEL_TUTAR2_DOVIZ_ID, obj.TAKIP_TARIHI.Value));
                    list.Add(new ParaVeDovizId(obj.OZEL_TUTAR3, obj.OZEL_TUTAR3_DOVIZ_ID, obj.TAKIP_TARIHI.Value));
                    list.Add(new ParaVeDovizId(obj.OZEL_TAZMINAT, obj.OZEL_TAZMINAT_DOVIZ_ID, obj.TAKIP_TARIHI.Value));

                    //list.Add(prTO_ODEME_MAHSUP_TOPLAMI);
                    list.Add(prASIL_ALACAK);
                    list.Add(prISLEMIS_FAIZ);
                    list.Add(prBSMV_TO);
                    list.Add(prKKDV_TO);
                    list.Add(prOIV_TO);
                    list.Add(prKDV_TO);
                    list.Add(prKARSILIKSIZ_CEK_TAZMINATI);
                    list.Add(prCEK_KOMISYONU);
                    list.Add(prILAM_VEK_UCR);
                    list.Add(prILAM_INKAR_TAZMINATI);
                    list.Add(prILAM_TEBLIG_GIDERI);
                    list.Add(prILAM_BK_YARG_ONAMA);
                    list.Add(prILAM_YARGILAMA_GIDERI);
                    list.Add(prIH_GIDERI);
                    list.Add(prIH_VEKALET_UCRETI);
                    list.Add(prIT_GIDERI);
                    list.Add(prIT_VEKALET_UCRETI);
                    list.Add(prTO_MASRAF_TOPLAMI);
                    list.Add(prTO_ODEME_MAHSUP_TOPLAMI);

                    var toplam = ParaVeDovizId.Topla(list);

                    obj.TAKIP_CIKISI = toplam.Para;
                    obj.TAKIP_CIKISI_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// Takip Harç Toplamları
                /// </summary>
                /// <param name="obj"></param>
                private static void SetTakipHarcToplamlari(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prODENEN_TAHSIL_HARCI = new ParaVeDovizId(obj.ODENEN_TAHSIL_HARCI, obj.ODENEN_TAHSIL_HARCI_DOVIZ_ID);
                    ParaVeDovizId prDIGER_HARC = new ParaVeDovizId(obj.DIGER_HARC, obj.DIGER_HARC_DOVIZ_ID);
                    ParaVeDovizId prTD_BAKIYE_HARC = new ParaVeDovizId(obj.TD_BAKIYE_HARC, obj.TD_BAKIYE_HARC_DOVIZ_ID);
                    ParaVeDovizId prPAYLASMA_HARCI = new ParaVeDovizId(obj.PAYLASMA_HARCI, obj.PAYLASMA_HARCI_DOVIZ_ID);
                    ParaVeDovizId prMASAYA_KATILMA_HARCI = new ParaVeDovizId(obj.MASAYA_KATILMA_HARCI, obj.MASAYA_KATILMA_HARCI_DOVIZ_ID);

                    var toplam = ParaVeDovizId.Topla(
                        prODENEN_TAHSIL_HARCI, prDIGER_HARC, prTD_BAKIYE_HARC,
                        prPAYLASMA_HARCI, prMASAYA_KATILMA_HARCI);

                    obj.HARC_TOPLAMI = toplam.Para;
                    obj.HARC_TOPLAMI_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// Takip Öncesi Harçların Toplamı
                /// </summary>
                /// <param name="obj"></param>
                private static void SetTakipOncesiHarclarToplami(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prIT_HACIZDE_ODENEN = new ParaVeDovizId(obj.IT_HACIZDE_ODENEN, obj.IT_HACIZDE_ODENEN_DOVIZ_ID);
                    ParaVeDovizId prMAHSUP_TOPLAMI = new ParaVeDovizId(obj.MAHSUP_TOPLAMI, obj.MAHSUP_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId prTO_ODEME_TOPLAMI = new ParaVeDovizId(obj.TO_ODEME_TOPLAMI, obj.TO_ODEME_TOPLAMI_DOVIZ_ID);

                    var toplam = ParaVeDovizId.Topla(prIT_HACIZDE_ODENEN, prMAHSUP_TOPLAMI, prTO_ODEME_TOPLAMI);

                    obj.TO_ODEME_MAHSUP_TOPLAMI = toplam.Para;
                    obj.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// Takip Öncesi Masraf Kalemlerini Toplar
                /// </summary>
                /// <param name="obj"></param>
                private static void SetTakipOncesiMasraflar(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prDAMGA_PULU = new ParaVeDovizId(obj.DAMGA_PULU, obj.DAMGA_PULU_DOVIZ_ID);
                    ParaVeDovizId prPROTESTO_GIDERI = new ParaVeDovizId(obj.PROTESTO_GIDERI, obj.PROTESTO_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prIHTAR_GIDERI = new ParaVeDovizId(obj.IHTAR_GIDERI, obj.IHTAR_GIDERI_DOVIZ_ID);

                    var toplam = ParaVeDovizId.Topla(prDAMGA_PULU, prPROTESTO_GIDERI, prIHTAR_GIDERI);

                    obj.TO_MASRAF_TOPLAMI = toplam.Para;
                    obj.TO_MASRAF_TOPLAMI_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// Takip Öncesi Ödeme ve Mahsup Bilgileri Toplamları
                /// </summary>
                /// <param name="obj"></param>
                private static void SetTakipOncesiOdemeVeMahsupBilgileriToplamlari(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prIT_HACIZDE_ODENEN = new ParaVeDovizId(obj.IT_HACIZDE_ODENEN, obj.IT_HACIZDE_ODENEN_DOVIZ_ID);
                    ParaVeDovizId prMAHSUP_TOPLAMI = new ParaVeDovizId(obj.MAHSUP_TOPLAMI, obj.MAHSUP_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId prTO_ODEME_TOPLAMI = new ParaVeDovizId(obj.TO_ODEME_TOPLAMI, obj.TO_ODEME_TOPLAMI_DOVIZ_ID);

                    var toplam = ParaVeDovizId.Topla(prIT_HACIZDE_ODENEN, prMAHSUP_TOPLAMI, prTO_ODEME_TOPLAMI);

                    obj.TO_ODEME_MAHSUP_TOPLAMI = toplam.Para;
                    obj.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// Takip Sonrası Masraf Toplamı
                /// </summary>
                /// <param name="obj"></param>AV001_TI_BIL_FOY
                private static void SetTakipSonrasiMasraflarToplami(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prILK_GIDERLER = new ParaVeDovizId(obj.ILK_GIDERLER, obj.ILK_GIDERLER_DOVIZ_ID);
                    ParaVeDovizId prTD_GIDERI = new ParaVeDovizId(obj.TD_GIDERI, obj.TD_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prTD_TEBLIG_GIDERI = new ParaVeDovizId(obj.TD_TEBLIG_GIDERI, obj.TD_TEBLIG_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prDAVA_GIDERLERI = new ParaVeDovizId(obj.DAVA_GIDERLERI, obj.DAVA_GIDERLERI_DOVIZ_ID);
                    ParaVeDovizId prDIGER_GIDERLER = new ParaVeDovizId(obj.DIGER_GIDERLER, obj.DIGER_GIDERLER_DOVIZ_ID);

                    var toplam = ParaVeDovizId.Topla(
                        prILK_GIDERLER, prTD_GIDERI, prTD_TEBLIG_GIDERI,
                        prDAVA_GIDERLERI, prDIGER_GIDERLER);

                    ;

                    obj.TS_MASRAF_TOPLAMI = toplam.Para;
                    obj.TS_MASRAF_TOPLAMI_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// Vekalet Kalemlerini Döviz kurallarına uygun olarak Toplayıp nesne üzerindeki
                /// TS_VEKALET_TOPLAMI alanına yazıyor
                /// </summary>
                /// <param name="obj"></param>
                private static void SetTakipSonrasiVekaletToplamlari(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prTAKIP_VEKALET_UCRETI = new ParaVeDovizId(obj.TAKIP_VEKALET_UCRETI, obj.TAKIP_VEKALET_UCRETI_DOVIZ_ID);
                    ParaVeDovizId prTAHLIYE_VEK_UCR = new ParaVeDovizId(obj.TAHLIYE_VEK_UCR, obj.TAHLIYE_VEK_UCR_DOVIZ_ID);
                    ParaVeDovizId prTD_VEK_UCR = new ParaVeDovizId(obj.TD_VEK_UCR, obj.TD_VEK_UCR_DOVIZ_ID);
                    ParaVeDovizId prDAVA_VEKALET_UCRETI = new ParaVeDovizId(obj.DAVA_VEKALET_UCRETI, obj.DAVA_VEKALET_UCRETI_DOVIZ_ID);
                    //ParaVeDovizId prKALAN_TAHSIL_HARCI = new ParaVeDovizId(obj.KALAN_TAHSIL_HARCI, obj.KALAN_TAHSIL_HARCI_DOVIZ_ID);

                    var liste = new List<ParaVeDovizId>();

                    liste.Add(prTAKIP_VEKALET_UCRETI);
                    liste.Add(prTAHLIYE_VEK_UCR);
                    liste.Add(prTD_VEK_UCR);
                    liste.Add(prDAVA_VEKALET_UCRETI);
                    //liste.Add(prKALAN_TAHSIL_HARCI);

                    var toplam = ParaVeDovizId.Topla(liste);

                    obj.TS_VEKALET_TOPLAMI = toplam.Para;
                    obj.TS_VEKALET_TOPLAMI_DOVIZ_ID = toplam.DovizId;
                }

                #endregion Tutar Kalemlerini Toplanma İşlemi
            }

            public class DosyaHesabi
            {
                #region Tutar Kalemlerini Toplanma İşlemi

                public static void SetFoyAlanlariTopla(AV001_TI_BIL_FOY obj)
                {
                    SetTakipOncesiHarclarToplami(obj);
                    SetTakipHarcToplamlari(obj);
                    SetTakipOncesiOdemeVeMahsupBilgileriToplamlari(obj);
                    SetTakipOncesiMasraflar(obj);
                    SetIlkGiderlerToplamlari(obj);
                    SetTakipSonrasiMasraflarToplami(obj);
                    SetMasrafToplamlari(obj);
                    SetTakipSonrasiVekaletToplamlari(obj);
                    SetTakipCikisi(obj);
                    SetAlacakToplami(obj);
                    SetKalanBorc(obj);
                }

                /// <summary>
                /// Alacak Toplamını Hesaplıyor
                /// </summary>
                /// <param name="obj"></param>
                private static void SetAlacakToplami(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prSONRAKI_FAIZ = new ParaVeDovizId(obj.SONRAKI_FAIZ, obj.SONRAKI_FAIZ_DOVIZ_ID);
                    ParaVeDovizId prTAKIP_CIKISI = new ParaVeDovizId(obj.TAKIP_CIKISI, obj.TAKIP_CIKISI_DOVIZ_ID);
                    ParaVeDovizId prBSMV_TS = new ParaVeDovizId(obj.BSMV_TS, obj.BSMV_TS_DOVIZ_ID);
                    ParaVeDovizId prOIV_TS = new ParaVeDovizId(obj.OIV_TS, obj.OIV_TS_DOVIZ_ID);
                    ParaVeDovizId prKDV_TS = new ParaVeDovizId(obj.KDV_TS, obj.KDV_TS_DOVIZ_ID);
                    ParaVeDovizId prSONRAKI_TAZMINAT = new ParaVeDovizId(obj.SONRAKI_TAZMINAT, obj.SONRAKI_TAZMINAT_DOVIZ_ID);
                    ParaVeDovizId prBIRIKMIS_NAFAKA = new ParaVeDovizId(obj.BIRIKMIS_NAFAKA, obj.BIRIKMIS_NAFAKA_DOVIZ_ID);
                    ParaVeDovizId prTS_MASRAF_TOPLAMI = new ParaVeDovizId(obj.TS_MASRAF_TOPLAMI, obj.TS_MASRAF_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId prTS_VEKALET_TOPLAMI = new ParaVeDovizId(obj.TS_VEKALET_TOPLAMI, obj.TS_VEKALET_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId prHARC_TOPLAMI = new ParaVeDovizId(obj.HARC_TOPLAMI, obj.HARC_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId prICRA_INKAR_TAZMINATI = new ParaVeDovizId(obj.ICRA_INKAR_TAZMINATI, obj.ICRA_INKAR_TAZMINATI_DOVIZ_ID);
                    ParaVeDovizId prDAVA_INKAR_TAZMINATI = new ParaVeDovizId(obj.DAVA_INKAR_TAZMINATI, obj.DAVA_INKAR_TAZMINATI_DOVIZ_ID);

                    //Bakiye Harç Hesaba Dahilse Eklenecek
                    ParaVeDovizId prKALAN_TAHSIL_HARCI = new ParaVeDovizId(obj.KALAN_TAHSIL_HARCI, obj.KALAN_TAHSIL_HARCI_DOVIZ_ID);

                    var liste = new List<ParaVeDovizId>();

                    liste.Add(prSONRAKI_FAIZ);
                    liste.Add(prTAKIP_CIKISI);
                    liste.Add(prBSMV_TS);
                    liste.Add(prOIV_TS);
                    liste.Add(prKDV_TS);
                    liste.Add(prSONRAKI_TAZMINAT);
                    liste.Add(prBIRIKMIS_NAFAKA);
                    liste.Add(prTS_MASRAF_TOPLAMI);
                    liste.Add(prTS_VEKALET_TOPLAMI);
                    liste.Add(prHARC_TOPLAMI);
                    liste.Add(prICRA_INKAR_TAZMINATI);
                    liste.Add(prDAVA_INKAR_TAZMINATI);

                    var toplam = ParaVeDovizId.Topla(liste);

                    if (obj.BAKIYE_HARC_TOPLAMA_EKLE)
                    {
                        toplam = ParaVeDovizId.Topla(toplam, prKALAN_TAHSIL_HARCI);
                    }

                    obj.ALACAK_TOPLAMI = toplam.Para;
                    obj.ALACAK_TOPLAMI_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// İlk Gider Toplamları
                /// </summary>
                /// <param name="obj"></param>
                private static void SetIlkGiderlerToplamlari(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prILK_TEBLIGAT_GIDERI = new ParaVeDovizId(obj.ILK_TEBLIGAT_GIDERI, obj.ILK_TEBLIGAT_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prBASVURMA_HARCI = new ParaVeDovizId(obj.BASVURMA_HARCI, obj.BASVURMA_HARCI_DOVIZ_ID);
                    ParaVeDovizId prPESIN_HARC = new ParaVeDovizId(obj.PESIN_HARC, obj.PESIN_HARC_DOVIZ_ID);
                    ParaVeDovizId prIFLAS_BASVURMA_HARCI = new ParaVeDovizId(obj.IFLAS_BASVURMA_HARCI, obj.IFLAS_BASVURMA_HARCI_DOVIZ_ID);
                    ParaVeDovizId prIFLASIN_ACILMASI_HARCI = new ParaVeDovizId(obj.IFLASIN_ACILMASI_HARCI, obj.IFLASIN_ACILMASI_HARCI_DOVIZ_ID);
                    ParaVeDovizId prVEKALET_HARCI = new ParaVeDovizId(obj.VEKALET_HARCI, obj.VEKALET_HARCI_DOVIZ_ID);
                    ParaVeDovizId prVEKALET_PULU = new ParaVeDovizId(obj.VEKALET_PULU, obj.VEKALET_PULU_DOVIZ_ID);

                    var toplam = ParaVeDovizId.Topla(
                        prILK_TEBLIGAT_GIDERI, prBASVURMA_HARCI, prPESIN_HARC,
                        prIFLAS_BASVURMA_HARCI, prIFLASIN_ACILMASI_HARCI, prVEKALET_HARCI,
                        prVEKALET_PULU);

                    obj.ILK_GIDERLER = toplam.Para;
                    obj.ILK_GIDERLER_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// KalanHesaplar
                /// </summary>
                /// <param name="obj"></param>
                private static void SetKalanBorc(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prFERAGAT_TOPLAMI = new ParaVeDovizId(obj.FERAGAT_TOPLAMI, obj.FERAGAT_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId prODEME_TOPLAMI = new ParaVeDovizId(obj.ODEME_TOPLAMI, obj.ODEME_TOPLAMI_DOVIZ_ID);

                    var toplam = ParaVeDovizId.Topla(prFERAGAT_TOPLAMI, prODEME_TOPLAMI);

                    #region <YY-20090618>

                    //Cikart şeklinde olan şey - leri çıkarttığı için düzenleme yapılmıştır.
                    toplam = ParaVeDovizId.Topla(new ParaVeDovizId(obj.ALACAK_TOPLAMI, obj.ALACAK_TOPLAMI_DOVIZ_ID), toplam);

                    #endregion <YY-20090618>

                    obj.KALAN = toplam.Para;
                    obj.KALAN_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// Masraf Kalemlerini Döviz Toplam Kurallarına Uygun Olarak Toplayıp
                /// TUM_MASRAF_TOPLAMI alanı üzerine yazmaktadır
                /// </summary>
                /// <param name="obj"></param>
                private static void SetMasrafToplamlari(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prILK_TEBLIGAT_GIDERI = new ParaVeDovizId(obj.ILK_TEBLIGAT_GIDERI, obj.ILK_TEBLIGAT_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prBASVURMA_HARCI = new ParaVeDovizId(obj.BASVURMA_HARCI, obj.BASVURMA_HARCI_DOVIZ_ID);
                    ParaVeDovizId prPESIN_HARC = new ParaVeDovizId(obj.PESIN_HARC, obj.PESIN_HARC_DOVIZ_ID);
                    ParaVeDovizId prIFLAS_BASVURMA_HARCI = new ParaVeDovizId(obj.IFLAS_BASVURMA_HARCI, obj.IFLAS_BASVURMA_HARCI_DOVIZ_ID);
                    ParaVeDovizId prIFLASIN_ACILMASI_HARCI = new ParaVeDovizId(obj.IFLASIN_ACILMASI_HARCI, obj.IFLASIN_ACILMASI_HARCI_DOVIZ_ID);
                    ParaVeDovizId prVEKALET_HARCI = new ParaVeDovizId(obj.VEKALET_HARCI, obj.VEKALET_HARCI_DOVIZ_ID);
                    ParaVeDovizId prVEKALET_PULU = new ParaVeDovizId(obj.VEKALET_PULU, obj.VEKALET_PULU_DOVIZ_ID);
                    ParaVeDovizId prTD_GIDERI = new ParaVeDovizId(obj.TD_GIDERI, obj.TD_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prTD_TEBLIG_GIDERI = new ParaVeDovizId(obj.TD_TEBLIG_GIDERI, obj.TD_TEBLIG_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prDAVA_GIDERLERI = new ParaVeDovizId(obj.DAVA_GIDERLERI, obj.DAVA_GIDERLERI_DOVIZ_ID);
                    ParaVeDovizId prDIGER_GIDERLER = new ParaVeDovizId(obj.DIGER_GIDERLER, obj.DIGER_GIDERLER_DOVIZ_ID);
                    ParaVeDovizId prODENEN_TAHSIL_HARCI = new ParaVeDovizId(obj.ODENEN_TAHSIL_HARCI, obj.ODENEN_TAHSIL_HARCI_DOVIZ_ID);
                    ParaVeDovizId prDIGER_HARC = new ParaVeDovizId(obj.DIGER_HARC, obj.DIGER_HARC_DOVIZ_ID);
                    ParaVeDovizId prTD_BAKIYE_HARC = new ParaVeDovizId(obj.TD_BAKIYE_HARC, obj.TD_BAKIYE_HARC_DOVIZ_ID);
                    ParaVeDovizId prPAYLASMA_HARCI = new ParaVeDovizId(obj.PAYLASMA_HARCI, obj.PAYLASMA_HARCI_DOVIZ_ID);
                    ParaVeDovizId prMASAYA_KATILMA_HARCI = new ParaVeDovizId(obj.MASAYA_KATILMA_HARCI, obj.MASAYA_KATILMA_HARCI_DOVIZ_ID);

                    var liste = new List<ParaVeDovizId>();
                    liste.Add(prILK_TEBLIGAT_GIDERI);
                    liste.Add(prBASVURMA_HARCI);
                    liste.Add(prPESIN_HARC);
                    liste.Add(prIFLAS_BASVURMA_HARCI);
                    liste.Add(prIFLASIN_ACILMASI_HARCI);
                    liste.Add(prVEKALET_HARCI);
                    liste.Add(prVEKALET_PULU);
                    liste.Add(prTD_GIDERI);
                    liste.Add(prTD_TEBLIG_GIDERI);
                    liste.Add(prDAVA_GIDERLERI);
                    liste.Add(prDIGER_GIDERLER);
                    liste.Add(prODENEN_TAHSIL_HARCI);
                    liste.Add(prDIGER_HARC);
                    liste.Add(prTD_BAKIYE_HARC);
                    liste.Add(prPAYLASMA_HARCI);
                    liste.Add(prMASAYA_KATILMA_HARCI);

                    var toplam = ParaVeDovizId.Topla(liste);

                    obj.TUM_MASRAF_TOPLAMI = toplam.Para;
                    obj.TUM_MASRAF_TOPLAMI_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// İlgili Alanları Toplayarak Takip Çıkışını Hesaplar
                ///
                /// </summary>
                /// <param name="obj"></param>
                private static void SetTakipCikisi(AV001_TI_BIL_FOY obj)
                {
                    var list = new List<ParaVeDovizId>();

                    ParaVeDovizId prISLEMIS_FAIZ = new ParaVeDovizId(obj.ISLEMIS_FAIZ, obj.ISLEMIS_FAIZ_DOVIZ_ID);
                    ParaVeDovizId prBSMV_TO = new ParaVeDovizId(obj.BSMV_TO, obj.BSMV_TO_DOVIZ_ID);
                    ParaVeDovizId prKKDV_TO = new ParaVeDovizId(obj.KKDV_TO, obj.KKDV_TO_DOVIZ_ID);
                    ParaVeDovizId prOIV_TO = new ParaVeDovizId(obj.OIV_TO, obj.OIV_TO_DOVIZ_ID);
                    ParaVeDovizId prKDV_TO = new ParaVeDovizId(obj.KDV_TO, obj.KDV_TO_DOVIZ_ID);
                    ParaVeDovizId prKARSILIKSIZ_CEK_TAZMINATI = new ParaVeDovizId(obj.KARSILIKSIZ_CEK_TAZMINATI, obj.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID);
                    ParaVeDovizId prCEK_KOMISYONU = new ParaVeDovizId(obj.CEK_KOMISYONU, obj.CEK_KOMISYONU_DOVIZ_ID);
                    ParaVeDovizId prILAM_VEK_UCR = new ParaVeDovizId(obj.ILAM_VEK_UCR, obj.ILAM_VEK_UCR_DOVIZ_ID);
                    ParaVeDovizId prILAM_INKAR_TAZMINATI = new ParaVeDovizId(obj.ILAM_INKAR_TAZMINATI, obj.ILAM_INKAR_TAZMINATI_DOVIZ_ID);
                    ParaVeDovizId prILAM_TEBLIG_GIDERI = new ParaVeDovizId(obj.ILAM_TEBLIG_GIDERI, obj.ILAM_TEBLIG_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prILAM_BK_YARG_ONAMA = new ParaVeDovizId(obj.ILAM_BK_YARG_ONAMA, obj.ILAM_BK_YARG_ONAMA_DOVIZ_ID);
                    ParaVeDovizId prILAM_YARGILAMA_GIDERI = new ParaVeDovizId(obj.ILAM_YARGILAMA_GIDERI, obj.ILAM_YARGILAMA_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prIH_GIDERI = new ParaVeDovizId(obj.IH_GIDERI, obj.IH_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prIH_VEKALET_UCRETI = new ParaVeDovizId(obj.IH_VEKALET_UCRETI, obj.IH_VEKALET_UCRETI_DOVIZ_ID);
                    ParaVeDovizId prIT_GIDERI = new ParaVeDovizId(obj.IT_GIDERI, obj.IT_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prIT_VEKALET_UCRETI = new ParaVeDovizId(obj.IT_VEKALET_UCRETI, obj.IT_VEKALET_UCRETI_DOVIZ_ID);
                    ParaVeDovizId prTO_MASRAF_TOPLAMI = new ParaVeDovizId(obj.TO_MASRAF_TOPLAMI, obj.TO_MASRAF_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId prTO_ODEME_MAHSUP_TOPLAMI = new ParaVeDovizId(obj.TO_ODEME_MAHSUP_TOPLAMI, obj.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId prASIL_ALACAK = new ParaVeDovizId(obj.ASIL_ALACAK, obj.ASIL_ALACAK_DOVIZ_ID);
                    list.Add(new ParaVeDovizId(obj.OZEL_TUTAR1, obj.OZEL_TUTAR1_DOVIZ_ID, obj.TAKIP_TARIHI.Value));
                    list.Add(new ParaVeDovizId(obj.OZEL_TUTAR2, obj.OZEL_TUTAR2_DOVIZ_ID, obj.TAKIP_TARIHI.Value));
                    list.Add(new ParaVeDovizId(obj.OZEL_TUTAR3, obj.OZEL_TUTAR3_DOVIZ_ID, obj.TAKIP_TARIHI.Value));
                    list.Add(new ParaVeDovizId(obj.OZEL_TAZMINAT, obj.OZEL_TAZMINAT_DOVIZ_ID, obj.TAKIP_TARIHI.Value));

                    //list.Add(prTO_ODEME_MAHSUP_TOPLAMI);
                    list.Add(prASIL_ALACAK);
                    list.Add(prISLEMIS_FAIZ);
                    list.Add(prBSMV_TO);
                    list.Add(prKKDV_TO);
                    list.Add(prOIV_TO);
                    list.Add(prKDV_TO);
                    list.Add(prKARSILIKSIZ_CEK_TAZMINATI);
                    list.Add(prCEK_KOMISYONU);
                    list.Add(prILAM_VEK_UCR);
                    list.Add(prILAM_INKAR_TAZMINATI);
                    list.Add(prILAM_TEBLIG_GIDERI);
                    list.Add(prILAM_BK_YARG_ONAMA);
                    list.Add(prILAM_YARGILAMA_GIDERI);
                    list.Add(prIH_GIDERI);
                    list.Add(prIH_VEKALET_UCRETI);
                    list.Add(prIT_GIDERI);
                    list.Add(prIT_VEKALET_UCRETI);
                    list.Add(prTO_MASRAF_TOPLAMI);
                    list.Add(prTO_ODEME_MAHSUP_TOPLAMI);

                    var toplam = ParaVeDovizId.Topla(list);

                    obj.TAKIP_CIKISI = toplam.Para;
                    obj.TAKIP_CIKISI_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// Takip Harç Toplamları
                /// </summary>
                /// <param name="obj"></param>
                private static void SetTakipHarcToplamlari(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prODENEN_TAHSIL_HARCI = new ParaVeDovizId(obj.ODENEN_TAHSIL_HARCI, obj.ODENEN_TAHSIL_HARCI_DOVIZ_ID);
                    ParaVeDovizId prDIGER_HARC = new ParaVeDovizId(obj.DIGER_HARC, obj.DIGER_HARC_DOVIZ_ID);
                    ParaVeDovizId prTD_BAKIYE_HARC = new ParaVeDovizId(obj.TD_BAKIYE_HARC, obj.TD_BAKIYE_HARC_DOVIZ_ID);
                    ParaVeDovizId prPAYLASMA_HARCI = new ParaVeDovizId(obj.PAYLASMA_HARCI, obj.PAYLASMA_HARCI_DOVIZ_ID);
                    ParaVeDovizId prMASAYA_KATILMA_HARCI = new ParaVeDovizId(obj.MASAYA_KATILMA_HARCI, obj.MASAYA_KATILMA_HARCI_DOVIZ_ID);

                    var toplam = ParaVeDovizId.Topla(
                        prODENEN_TAHSIL_HARCI, prDIGER_HARC, prTD_BAKIYE_HARC,
                        prPAYLASMA_HARCI, prMASAYA_KATILMA_HARCI);

                    obj.HARC_TOPLAMI = toplam.Para;
                    obj.HARC_TOPLAMI_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// Takip Öncesi Harçların Toplamı
                /// </summary>
                /// <param name="obj"></param>
                private static void SetTakipOncesiHarclarToplami(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prIT_HACIZDE_ODENEN = new ParaVeDovizId(obj.IT_HACIZDE_ODENEN, obj.IT_HACIZDE_ODENEN_DOVIZ_ID);
                    ParaVeDovizId prMAHSUP_TOPLAMI = new ParaVeDovizId(obj.MAHSUP_TOPLAMI, obj.MAHSUP_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId prTO_ODEME_TOPLAMI = new ParaVeDovizId(obj.TO_ODEME_TOPLAMI, obj.TO_ODEME_TOPLAMI_DOVIZ_ID);

                    var toplam = ParaVeDovizId.Topla(prIT_HACIZDE_ODENEN, prMAHSUP_TOPLAMI, prTO_ODEME_TOPLAMI);

                    obj.TO_ODEME_MAHSUP_TOPLAMI = toplam.Para;
                    obj.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// Takip Öncesi Masraf Kalemlerini Toplar
                /// </summary>
                /// <param name="obj"></param>
                private static void SetTakipOncesiMasraflar(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prDAMGA_PULU = new ParaVeDovizId(obj.DAMGA_PULU, obj.DAMGA_PULU_DOVIZ_ID);
                    ParaVeDovizId prPROTESTO_GIDERI = new ParaVeDovizId(obj.PROTESTO_GIDERI, obj.PROTESTO_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prIHTAR_GIDERI = new ParaVeDovizId(obj.IHTAR_GIDERI, obj.IHTAR_GIDERI_DOVIZ_ID);

                    var toplam = ParaVeDovizId.Topla(prDAMGA_PULU, prPROTESTO_GIDERI, prIHTAR_GIDERI);

                    obj.TO_MASRAF_TOPLAMI = toplam.Para;
                    obj.TO_MASRAF_TOPLAMI_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// Takip Öncesi Ödeme ve Mahsup Bilgileri Toplamları
                /// </summary>
                /// <param name="obj"></param>
                private static void SetTakipOncesiOdemeVeMahsupBilgileriToplamlari(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prIT_HACIZDE_ODENEN = new ParaVeDovizId(obj.IT_HACIZDE_ODENEN, obj.IT_HACIZDE_ODENEN_DOVIZ_ID);
                    ParaVeDovizId prMAHSUP_TOPLAMI = new ParaVeDovizId(obj.MAHSUP_TOPLAMI, obj.MAHSUP_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId prTO_ODEME_TOPLAMI = new ParaVeDovizId(obj.TO_ODEME_TOPLAMI, obj.TO_ODEME_TOPLAMI_DOVIZ_ID);

                    var toplam = ParaVeDovizId.Topla(prIT_HACIZDE_ODENEN, prMAHSUP_TOPLAMI, prTO_ODEME_TOPLAMI);

                    obj.TO_ODEME_MAHSUP_TOPLAMI = toplam.Para;
                    obj.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// Takip Sonrası Masraf Toplamı
                /// </summary>
                /// <param name="obj"></param>AV001_TI_BIL_FOY
                private static void SetTakipSonrasiMasraflarToplami(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prILK_GIDERLER = new ParaVeDovizId(obj.ILK_GIDERLER, obj.ILK_GIDERLER_DOVIZ_ID);
                    ParaVeDovizId prTD_GIDERI = new ParaVeDovizId(obj.TD_GIDERI, obj.TD_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prTD_TEBLIG_GIDERI = new ParaVeDovizId(obj.TD_TEBLIG_GIDERI, obj.TD_TEBLIG_GIDERI_DOVIZ_ID);
                    ParaVeDovizId prDAVA_GIDERLERI = new ParaVeDovizId(obj.DAVA_GIDERLERI, obj.DAVA_GIDERLERI_DOVIZ_ID);
                    ParaVeDovizId prDIGER_GIDERLER = new ParaVeDovizId(obj.DIGER_GIDERLER, obj.DIGER_GIDERLER_DOVIZ_ID);

                    var toplam = ParaVeDovizId.Topla(
                        prILK_GIDERLER, prTD_GIDERI, prTD_TEBLIG_GIDERI,
                        prDAVA_GIDERLERI, prDIGER_GIDERLER);

                    ;

                    obj.TS_MASRAF_TOPLAMI = toplam.Para;
                    obj.TS_MASRAF_TOPLAMI_DOVIZ_ID = toplam.DovizId;
                }

                /// <summary>
                /// Vekalet Kalemlerini Döviz kurallarına uygun olarak Toplayıp nesne üzerindeki
                /// TS_VEKALET_TOPLAMI alanına yazıyor
                /// </summary>
                /// <param name="obj"></param>
                private static void SetTakipSonrasiVekaletToplamlari(AV001_TI_BIL_FOY obj)
                {
                    ParaVeDovizId prTAKIP_VEKALET_UCRETI = new ParaVeDovizId(obj.TAKIP_VEKALET_UCRETI, obj.TAKIP_VEKALET_UCRETI_DOVIZ_ID);
                    ParaVeDovizId prTAHLIYE_VEK_UCR = new ParaVeDovizId(obj.TAHLIYE_VEK_UCR, obj.TAHLIYE_VEK_UCR_DOVIZ_ID);
                    ParaVeDovizId prTD_VEK_UCR = new ParaVeDovizId(obj.TD_VEK_UCR, obj.TD_VEK_UCR_DOVIZ_ID);
                    ParaVeDovizId prDAVA_VEKALET_UCRETI = new ParaVeDovizId(obj.DAVA_VEKALET_UCRETI, obj.DAVA_VEKALET_UCRETI_DOVIZ_ID);
                    //ParaVeDovizId prKALAN_TAHSIL_HARCI = new ParaVeDovizId(obj.KALAN_TAHSIL_HARCI, obj.KALAN_TAHSIL_HARCI_DOVIZ_ID);

                    var liste = new List<ParaVeDovizId>();

                    liste.Add(prTAKIP_VEKALET_UCRETI);
                    liste.Add(prTAHLIYE_VEK_UCR);
                    liste.Add(prTD_VEK_UCR);
                    liste.Add(prDAVA_VEKALET_UCRETI);
                    //liste.Add(prKALAN_TAHSIL_HARCI);

                    var toplam = ParaVeDovizId.Topla(liste);

                    obj.TS_VEKALET_TOPLAMI = toplam.Para;
                    obj.TS_VEKALET_TOPLAMI_DOVIZ_ID = toplam.DovizId;
                }

                #endregion Tutar Kalemlerini Toplanma İşlemi
            }
        }

        public class IcraHesapCetveli
        {
            public IcraHesapCetveli(AV001_TI_BIL_FOY foy)
            {
                #region HesapAlanList.AddRange

                this.HesapAlanList.AddRange(new[]
                {
                    new HesapAlani(foy.TAKIP_CIKISI,foy.TAKIP_CIKISI_DOVIZ_ID,HesapAlanlari.TakipOncesi, HesapAlanlari.ROOT),
                    new HesapAlani(foy.ASIL_ALACAK,foy.ASIL_ALACAK_DOVIZ_ID,HesapAlanlari.ASIL_ALACAK, HesapAlanlari.TakipOncesi),
                    new HesapAlani(foy.ISLEMIS_FAIZ,foy.ISLEMIS_FAIZ_DOVIZ_ID,HesapAlanlari.ISLEMIS_FAIZ, HesapAlanlari.TakipOncesi),
                    new HesapAlani(foy.BSMV_TO,foy.BSMV_TO_DOVIZ_ID,HesapAlanlari.BSMV_TO, HesapAlanlari.TakipOncesi),
                    new HesapAlani(foy.KKDV_TO,foy.KKDV_TO_DOVIZ_ID,HesapAlanlari.KKDV_TO, HesapAlanlari.TakipOncesi),
                    new HesapAlani(foy.OIV_TO,foy.OIV_TO_DOVIZ_ID,HesapAlanlari.OIV_TO, HesapAlanlari.TakipOncesi),
                    new HesapAlani(foy.KDV_TO,foy.KDV_TO_DOVIZ_ID,HesapAlanlari.KDV_TO, HesapAlanlari.TakipOncesi),
                    new HesapAlani(foy.KARSILIKSIZ_CEK_TAZMINATI,foy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID,HesapAlanlari.KARSILIKSIZ_CEK_TAZMINATI, HesapAlanlari.TakipOncesi),
                    new HesapAlani(foy.CEK_KOMISYONU,foy.CEK_KOMISYONU_DOVIZ_ID,HesapAlanlari.CEK_KOMISYONU, HesapAlanlari.TakipOncesi),
                    new HesapAlani(0,1,HesapAlanlari.IlamGiderleri, HesapAlanlari.TakipOncesi),
                    new HesapAlani(foy.ILAM_INKAR_TAZMINATI,foy.ILAM_INKAR_TAZMINATI_DOVIZ_ID,HesapAlanlari.ILAM_INKAR_TAZMINATI, HesapAlanlari.IlamGiderleri),
                    new HesapAlani(foy.ILAM_VEK_UCR,foy.ILAM_VEK_UCR_DOVIZ_ID,HesapAlanlari.ILAM_VEK_UCR, HesapAlanlari.IlamGiderleri),
                    new HesapAlani(foy.ILAM_BK_YARG_ONAMA,foy.ILAM_BK_YARG_ONAMA_DOVIZ_ID,HesapAlanlari.ILAM_BK_YARG_ONAMA, HesapAlanlari.IlamGiderleri),
                    new HesapAlani(foy.ILAM_TEBLIG_GIDERI,foy.ILAM_TEBLIG_GIDERI_DOVIZ_ID,HesapAlanlari.ILAM_TEBLIG_GIDERI, HesapAlanlari.IlamGiderleri),
                    new HesapAlani(foy.ILAM_YARGILAMA_GIDERI,foy.ILAM_YARGILAMA_GIDERI_DOVIZ_ID,HesapAlanlari.ILAM_YARGILAMA_GIDERI, HesapAlanlari.IlamGiderleri),
                    new HesapAlani(foy.IH_GIDERI,foy.IH_GIDERI_DOVIZ_ID, HesapAlanlari.IH_GIDERI,HesapAlanlari.TakipOncesi),
                    new HesapAlani(foy.IH_VEKALET_UCRETI,foy.IH_VEKALET_UCRETI_DOVIZ_ID,HesapAlanlari.IH_VEKALET_UCRETI, HesapAlanlari.TakipOncesi),
                    new HesapAlani(foy.IT_GIDERI,foy.IT_GIDERI_DOVIZ_ID,HesapAlanlari.IT_GIDERI, HesapAlanlari.TakipOncesi),
                    new HesapAlani(foy.IT_VEKALET_UCRETI,foy.IT_VEKALET_UCRETI_DOVIZ_ID,HesapAlanlari.IT_VEKALET_UCRETI, HesapAlanlari.TakipOncesi),
                    new HesapAlani(foy.TO_MASRAF_TOPLAMI,foy.TO_MASRAF_TOPLAMI_DOVIZ_ID,HesapAlanlari.TO_MASRAF_TOPLAMI, HesapAlanlari.TakipOncesi),
                    new HesapAlani(foy.PROTESTO_GIDERI,foy.PROTESTO_GIDERI_DOVIZ_ID,HesapAlanlari.PROTESTO_GIDERI, HesapAlanlari.TO_MASRAF_TOPLAMI),
                    new HesapAlani(foy.IHTAR_GIDERI,foy.IHTAR_GIDERI_DOVIZ_ID,HesapAlanlari.IHTAR_GIDERI, HesapAlanlari.TO_MASRAF_TOPLAMI),
                    new HesapAlani(foy.DAMGA_PULU,foy.DAMGA_PULU_DOVIZ_ID,HesapAlanlari.DAMGA_PULU, HesapAlanlari.TO_MASRAF_TOPLAMI),
                    new HesapAlani(0,1,HesapAlanlari.TakipOncesiOzelTutarlar, HesapAlanlari.TakipOncesi),
                    new HesapAlani(foy.OZEL_TAZMINAT,foy.OZEL_TAZMINAT_DOVIZ_ID,HesapAlanlari.OZEL_TAZMINAT, HesapAlanlari.TakipOncesiOzelTutarlar),
                    new HesapAlani(foy.OZEL_TUTAR1,foy.OZEL_TUTAR1_DOVIZ_ID,HesapAlanlari.OZEL_TUTAR1, HesapAlanlari.TakipOncesiOzelTutarlar),
                    new HesapAlani(foy.OZEL_TUTAR2,foy.OZEL_TUTAR2_DOVIZ_ID,HesapAlanlari.OZEL_TUTAR2, HesapAlanlari.TakipOncesiOzelTutarlar),
                    new HesapAlani(foy.OZEL_TUTAR3,foy.OZEL_TUTAR3_DOVIZ_ID,HesapAlanlari.OZEL_TUTAR3, HesapAlanlari.TakipOncesiOzelTutarlar),
                    new HesapAlani(foy.TO_YONETIMG_TAZMINATI,foy.TO_YONETIMG_TAZMINATI_DOVIZ_ID,HesapAlanlari.TO_YONETIMG_TAZMINATI, HesapAlanlari.TakipOncesiOzelTutarlar),
                    new HesapAlani(foy.TO_ODEME_MAHSUP_TOPLAMI,foy.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID,HesapAlanlari.TO_ODEME_MAHSUP_TOPLAMI, HesapAlanlari.TakipOncesi),
                    new HesapAlani(foy.IT_HACIZDE_ODENEN,foy.IT_HACIZDE_ODENEN_DOVIZ_ID,HesapAlanlari.IT_HACIZDE_ODENEN, HesapAlanlari.TO_ODEME_MAHSUP_TOPLAMI),
                    new HesapAlani(foy.MAHSUP_TOPLAMI,foy.MAHSUP_TOPLAMI_DOVIZ_ID,HesapAlanlari.MAHSUP_TOPLAMI, HesapAlanlari.TO_ODEME_MAHSUP_TOPLAMI),
                    new HesapAlani(foy.TO_ODEME_TOPLAMI,foy.TO_ODEME_TOPLAMI_DOVIZ_ID,HesapAlanlari.TO_ODEME_TOPLAMI, HesapAlanlari.TO_ODEME_MAHSUP_TOPLAMI),
                    new HesapAlani(foy.TAKIP_CIKISI,foy.TAKIP_CIKISI_DOVIZ_ID,HesapAlanlari.TAKIP_CIKISI, HesapAlanlari.ROOT),
                    new HesapAlani(foy.KALAN,foy.KALAN_DOVIZ_ID,HesapAlanlari.TakipSonrasi, HesapAlanlari.ROOT),
                    new HesapAlani(foy.ALACAK_TOPLAMI,foy.ALACAK_TOPLAMI_DOVIZ_ID,HesapAlanlari.ALACAK_TOPLAMI, HesapAlanlari.TakipSonrasi),
                    new HesapAlani(foy.SONRAKI_FAIZ,foy.SONRAKI_FAIZ_DOVIZ_ID,HesapAlanlari.SONRAKI_FAIZ, HesapAlanlari.ALACAK_TOPLAMI),
                    new HesapAlani(foy.BSMV_TS,foy.BSMV_TS_DOVIZ_ID,HesapAlanlari.BSMV_TS, HesapAlanlari.ALACAK_TOPLAMI),
                    new HesapAlani(foy.KDV_TS,foy.KDV_TS_DOVIZ_ID,HesapAlanlari.KDV_TS, HesapAlanlari.ALACAK_TOPLAMI),
                    new HesapAlani(foy.OIV_TS,foy.OIV_TS_DOVIZ_ID,HesapAlanlari.OIV_TS, HesapAlanlari.ALACAK_TOPLAMI),
                    new HesapAlani(foy.SONRAKI_TAZMINAT,foy.SONRAKI_TAZMINAT_DOVIZ_ID,HesapAlanlari.SONRAKI_TAZMINAT, HesapAlanlari.ALACAK_TOPLAMI),
                    new HesapAlani(foy.BIRIKMIS_NAFAKA,foy.BIRIKMIS_NAFAKA_DOVIZ_ID,HesapAlanlari.BIRIKMIS_NAFAKA, HesapAlanlari.ALACAK_TOPLAMI),
                    new HesapAlani(foy.TS_MASRAF_TOPLAMI,foy.TS_MASRAF_TOPLAMI_DOVIZ_ID,HesapAlanlari.TS_MASRAF_TOPLAMI, HesapAlanlari.ALACAK_TOPLAMI),
                    new HesapAlani(foy.ILK_GIDERLER,foy.ILK_GIDERLER_DOVIZ_ID,HesapAlanlari.ILK_GIDERLER, HesapAlanlari.TS_MASRAF_TOPLAMI),
                    new HesapAlani(foy.BASVURMA_HARCI,foy.BASVURMA_HARCI_DOVIZ_ID,HesapAlanlari.BASVURMA_HARCI, HesapAlanlari.ILK_GIDERLER),
                    new HesapAlani(foy.IFLAS_BASVURMA_HARCI,foy.IFLAS_BASVURMA_HARCI_DOVIZ_ID,HesapAlanlari.IFLAS_BASVURMA_HARCI, HesapAlanlari.ILK_GIDERLER),
                    new HesapAlani(foy.IFLASIN_ACILMASI_HARCI,foy.IFLASIN_ACILMASI_HARCI_DOVIZ_ID,HesapAlanlari.IFLASIN_ACILMASI_HARCI, HesapAlanlari.ILK_GIDERLER),
                    new HesapAlani(foy.ILK_TEBLIGAT_GIDERI,foy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID,HesapAlanlari.ILK_TEBLIGAT_GIDERI, HesapAlanlari.ILK_GIDERLER),
                    new HesapAlani(foy.PESIN_HARC,foy.PESIN_HARC_DOVIZ_ID,HesapAlanlari.PESIN_HARC, HesapAlanlari.ILK_GIDERLER),
                    new HesapAlani(foy.VEKALET_HARCI,foy.VEKALET_HARCI_DOVIZ_ID,HesapAlanlari.VEKALET_HARCI, HesapAlanlari.ILK_GIDERLER),
                    new HesapAlani(foy.VEKALET_PULU,foy.VEKALET_PULU_DOVIZ_ID,HesapAlanlari.VEKALET_PULU, HesapAlanlari.ILK_GIDERLER),
                    new HesapAlani(foy.TD_GIDERI,foy.TD_GIDERI_DOVIZ_ID,HesapAlanlari.TD_GIDERI, HesapAlanlari.TS_MASRAF_TOPLAMI),
                    new HesapAlani(foy.TD_TEBLIG_GIDERI,foy.TD_TEBLIG_GIDERI_DOVIZ_ID,HesapAlanlari.TD_TEBLIG_GIDERI, HesapAlanlari.TS_MASRAF_TOPLAMI),
                    new HesapAlani(foy.DAVA_GIDERLERI,foy.DAVA_GIDERLERI_DOVIZ_ID,HesapAlanlari.DAVA_GIDERLERI, HesapAlanlari.TS_MASRAF_TOPLAMI),
                    new HesapAlani(foy.DIGER_GIDERLER,foy.DIGER_GIDERLER_DOVIZ_ID,HesapAlanlari.DIGER_GIDERLER, HesapAlanlari.TS_MASRAF_TOPLAMI),
                    new HesapAlani(foy.TS_VEKALET_TOPLAMI,foy.TS_VEKALET_TOPLAMI_DOVIZ_ID,HesapAlanlari.TS_VEKALET_TOPLAMI, HesapAlanlari.ALACAK_TOPLAMI),
                    new HesapAlani(foy.TAKIP_VEKALET_UCRETI,foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID,HesapAlanlari.TAKIP_VEKALET_UCRETI, HesapAlanlari.TS_VEKALET_TOPLAMI),
                    new HesapAlani(foy.TAHLIYE_VEK_UCR,foy.TAHLIYE_VEK_UCR_DOVIZ_ID,HesapAlanlari.TAHLIYE_VEK_UCR, HesapAlanlari.TS_VEKALET_TOPLAMI),
                    new HesapAlani(foy.TD_VEK_UCR,foy.TD_VEK_UCR_DOVIZ_ID,HesapAlanlari.TD_VEK_UCR, HesapAlanlari.TS_VEKALET_TOPLAMI),
                    new HesapAlani(foy.DAVA_VEKALET_UCRETI,foy.DAVA_VEKALET_UCRETI_DOVIZ_ID,HesapAlanlari.DAVA_VEKALET_UCRETI, HesapAlanlari.TS_VEKALET_TOPLAMI),
                    new HesapAlani(foy.HARC_TOPLAMI,foy.HARC_TOPLAMI_DOVIZ_ID,HesapAlanlari.HARC_TOPLAMI, HesapAlanlari.ALACAK_TOPLAMI),
                    new HesapAlani(foy.DIGER_HARC,foy.DIGER_HARC_DOVIZ_ID,HesapAlanlari.DIGER_HARC, HesapAlanlari.HARC_TOPLAMI),
                    new HesapAlani(foy.FERAGAT_HARCI,foy.FERAGAT_HARCI_DOVIZ_ID,HesapAlanlari.FERAGAT_HARCI, HesapAlanlari.HARC_TOPLAMI),
                    new HesapAlani(foy.MASAYA_KATILMA_HARCI,foy.MASAYA_KATILMA_HARCI_DOVIZ_ID,HesapAlanlari.MASAYA_KATILMA_HARCI, HesapAlanlari.HARC_TOPLAMI),
                    new HesapAlani(foy.ODENEN_TAHSIL_HARCI,foy.ODENEN_TAHSIL_HARCI_DOVIZ_ID,HesapAlanlari.ODENEN_TAHSIL_HARCI, HesapAlanlari.HARC_TOPLAMI),
                    new HesapAlani(foy.PAYLASMA_HARCI,foy.PAYLASMA_HARCI_DOVIZ_ID,HesapAlanlari.PAYLASMA_HARCI, HesapAlanlari.HARC_TOPLAMI),
                    new HesapAlani(foy.TAHLIYE_HARCI,foy.TAHLIYE_HARCI_DOVIZ_ID,HesapAlanlari.TAHLIYE_HARCI, HesapAlanlari.HARC_TOPLAMI),
                    new HesapAlani(foy.TD_BAKIYE_HARC,foy.TD_BAKIYE_HARC_DOVIZ_ID,HesapAlanlari.TD_BAKIYE_HARC, HesapAlanlari.HARC_TOPLAMI),
                    new HesapAlani(foy.TESLIM_HARCI,foy.TESLIM_HARCI_DOVIZ_ID,HesapAlanlari.TESLIM_HARCI, HesapAlanlari.HARC_TOPLAMI),
                    new HesapAlani(foy.KALAN_TAHSIL_HARCI,foy.KALAN_TAHSIL_HARCI_DOVIZ_ID,HesapAlanlari.KALAN_TAHSIL_HARCI, HesapAlanlari.ALACAK_TOPLAMI),
                    new HesapAlani(foy.ICRA_INKAR_TAZMINATI,foy.ICRA_INKAR_TAZMINATI_DOVIZ_ID,HesapAlanlari.ICRA_INKAR_TAZMINATI, HesapAlanlari.ALACAK_TOPLAMI),
                    new HesapAlani(foy.DAVA_INKAR_TAZMINATI,foy.DAVA_INKAR_TAZMINATI_DOVIZ_ID,HesapAlanlari.DAVA_INKAR_TAZMINATI, HesapAlanlari.ALACAK_TOPLAMI),
                    new HesapAlani(foy.ODEME_TOPLAMI,foy.ODEME_TOPLAMI_DOVIZ_ID,HesapAlanlari.ODEME_TOPLAMI, HesapAlanlari.TakipSonrasi),
                    new HesapAlani(foy.FERAGAT_TOPLAMI,foy.FERAGAT_TOPLAMI_DOVIZ_ID,HesapAlanlari.FERAGAT_TOPLAMI, HesapAlanlari.TakipSonrasi),
                    new HesapAlani(foy.KARSILIK_TUTARI,foy.KARSILIK_TUTARI_DOVIZ_ID,HesapAlanlari.KarsilikVeProtokolBilgileri, HesapAlanlari.ROOT),
                    new HesapAlani(foy.KARSILIK_TUTARI,foy.KARSILIK_TUTARI_DOVIZ_ID,HesapAlanlari.KARSILIK_TUTARI, HesapAlanlari.KarsilikVeProtokolBilgileri),
                    //new HesapAlani(foy.PROTOKOL_MIKTARI,foy.PROTOKOL_MIKTARI_DOVIZ_ID,HesapAlanlari.PROTOKOL_MIKTARI, HesapAlanlari.KarsilikVeProtokolBilgileri),
                    new HesapAlani(foy.TAKIP_CIKIS_GAYRI_NAKIT,foy.TAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID,HesapAlanlari.TAKIP_CIKIS_GAYRI_NAKIT, HesapAlanlari.ROOT),
                    new HesapAlani(foy.DEPO_HARCI,foy.DEPO_HARCI_DOVIZ_ID,HesapAlanlari.DEPO_HARCI, HesapAlanlari.TAKIP_CIKIS_GAYRI_NAKIT),
                    new HesapAlani(foy.DEPO_VEKALET_UCRETI,foy.DEPO_VEKALET_UCRET_DOVIZ_ID,HesapAlanlari.DEPO_VEKALET_UCRETI, HesapAlanlari.TAKIP_CIKIS_GAYRI_NAKIT),
                    new HesapAlani(foy.GAYRI_NAKTI_ALACAK,foy.GAYRI_NAKTI_ALACAK_DOVIZ_ID,HesapAlanlari.GAYRI_NAKTI_ALACAK, HesapAlanlari.TAKIP_CIKIS_GAYRI_NAKIT),
                    new HesapAlani(foy.GAYRI_NAKTI_ALACAK_FAIZ,foy.GAYRI_NAKTI_ALACAK_FAIZ_DOVIZ_ID,HesapAlanlari.GAYRI_NAKTI_ALACAK_FAIZ, HesapAlanlari.TAKIP_CIKIS_GAYRI_NAKIT),
                    new HesapAlani(foy.KALAN,foy.KALAN_DOVIZ_ID,HesapAlanlari.KALAN, HesapAlanlari.ROOT),
                    new HesapAlani(foy.GAYRI_NAKIT_KALAN,foy.GAYRI_NAKIT_KALAN_DOVIZ_ID,HesapAlanlari.GAYRI_NAKIT_KALAN, HesapAlanlari.ROOT)
                });
                var prGenelToplam = ParaVeDovizId.Topla(new ParaVeDovizId(foy.KALAN, foy.KALAN_DOVIZ_ID), new ParaVeDovizId(foy.GAYRI_NAKIT_KALAN, foy.GAYRI_NAKIT_KALAN_DOVIZ_ID));
                HesapAlanList.Add(new HesapAlani(prGenelToplam.Para, prGenelToplam.DovizId, HesapAlanlari.GenelToplam, HesapAlanlari.ROOT));

                #endregion HesapAlanList.AddRange

                if (!foy.BAKIYE_HARC_TOPLAMA_EKLE)
                {
                    GetHesapAlani(HesapAlanlari.KALAN_TAHSIL_HARCI).Value = new ParaVeDovizId(0, 1);
                }

                this.TutarlariYenile();
            }

            //Özel kodların konularının foyden alınabilmesini sağlamak için eklend.
            public static AV001_TI_BIL_FOY Foy;

            private static Dictionary<HesapAlanlari, string> _EtiketListesi;

            private List<HesapAlani> _HesapAlanList = new List<HesapAlani>();

            public enum HesapAlanlari
            {
                #region
                ROOT = 0,
                ALACAK_TOPLAMI,
                ANA_PARAYA_YAPILAN_TAHSILAT,
                ASIL_ALACAK,
                BASVURMA_HARCI,
                BIRIKMIS_NAFAKA,
                BSMV_TO,
                BSMV_TS,
                CEK_KOMISYONU,
                DAMGA_PULU,
                DAVA_GIDERLERI,
                DAVA_INKAR_TAZMINATI,
                DAVA_VEKALET_UCRETI,
                DEPO_HARCI,
                DEPO_VEKALET_UCRETI,
                DIGER_GIDERLER,
                DIGER_HARC,
                EXTRA_MONEY1,
                EXTRA_MONEY2,
                FAIZ_TOPLAMI,
                FAIZE_YAPILAN_TAHSILAT,
                FERAGAT_HARCI,
                FERAGAT_TOPLAMI,
                GAYRI_NAKIT_KALAN,
                GAYRI_NAKITIN_TAZMININDEN_GELEN_ASIL_ALACAK,
                GAYRI_NAKITIN_TAZMININDEN_GELEN_ASIL_ALACAK_FAIZI,
                GAYRI_NAKTI_ALACAK,
                GAYRI_NAKTI_ALACAK_FAIZ,
                HARC_TOPLAMI,
                HESAPLANMIS_BSMV,
                HESAPLANMIS_FAIZ,
                HESAPLANMIS_KDV,
                HESAPLANMIS_KKDF,
                HESAPLANMIS_OIV,
                ICRA_INKAR_TAZMINATI,
                IFLAS_BASVURMA_HARCI,
                IFLASIN_ACILMASI_HARCI,
                IH_GIDERI,
                IH_VEKALET_UCRETI,
                IHTAR_GIDERI,
                ILAM_BK_YARG_ONAMA,
                ILAM_INKAR_TAZMINATI,
                ILAM_TEBLIG_GIDERI,
                ILAM_UCRETLER_TOPLAMI,
                ILAM_VEK_UCR,
                ILAM_YARGILAMA_GIDERI,
                ILK_GIDERLER,
                ILK_TEBLIGAT_GIDERI,
                ISLEMIS_FAIZ,
                IT_GIDERI,
                IT_HACIZDE_ODENEN,
                IT_VEKALET_UCRETI,
                KALAN,
                KALAN_TAHSIL_HARCI,
                KARSI_VEKALET_TOPLAMI,
                KARSILIK_TUTARI,
                KARSILIKSIZ_CEK_TAZMINATI,
                KDV_TO,
                KDV_TS,
                KKDV_TO,
                KO_ILAM_TOPLAM,
                MAHSUP_TOPLAMI,
                MASAYA_KATILMA_HARCI,
                MASRAFA_YAPILAN_TAHSILAT,
                ODEME_TOPLAMI,
                ODENEN_TAHSIL_HARCI,
                OIV_TO,
                OIV_TS,
                OZEL_TAZMINAT,
                OZEL_TUTAR1,
                OZEL_TUTAR2,
                OZEL_TUTAR3,
                PAYLASMA_HARCI,
                PESIN_HARC,
                PROTESTO_GIDERI,

                //PROTOKOL_MIKTARI,
                RISK_MIKTARI,

                RISKTEN_KALAN,
                SONRAKI_FAIZ,
                SONRAKI_TAZMINAT,
                TAHLIYE_HARCI,
                TAHLIYE_VEK_UCR,
                TAKIP_CIKIS_GAYRI_NAKIT,
                TAKIP_CIKISI,
                TAKIP_VEKALET_UCRETI,
                TD_BAKIYE_HARC,
                TD_GIDERI,
                TD_TEBLIG_GIDERI,
                TD_VEK_UCR,
                TESLIM_HARCI,
                TO_MASRAF_TOPLAMI,
                TO_ODEME_MAHSUP_TOPLAMI,
                TO_ODEME_TOPLAMI,
                TO_VEKALET_TOPLAMI,
                TO_YONETIMG_TAZMINATI,
                TS_MASRAF_HARC_TOPLAMI,
                TS_MASRAF_TOPLAMI,
                TS_VEKALET_TOPLAMI,
                TUM_MASRAF_TOPLAMI,
                TUM_ODEME_TOPLAMI,
                TUM_VEKALET_TOPLAMI,
                VEKALET_HARCI,
                VEKALET_PULU,
                VEKALET_UCRETINDEN_ODENEN,
                TakipOncesi,
                TakipOncesiOzelTutarlar,
                TakipSonrasi,
                KarsilikVeProtokolBilgileri,
                IlamGiderleri,
                GenelToplam

                #endregion
            }

            #region Hesap Alanları

            public static Dictionary<HesapAlanlari, string> EtiketListesi
            {
                get
                {
                    if (_EtiketListesi == null)
                        _EtiketListesi = GetEtiketListesi();

                    return _EtiketListesi;
                }
            }

            public List<HesapAlani> HesapAlanList
            {
                get { return _HesapAlanList; }
                set { _HesapAlanList = value; }
            }

            public HesapAlani GetHesapAlani(HesapAlanlari alan)
            {
                return this.HesapAlanList.Where(vi => vi.Alan == alan).FirstOrDefault();
            }

            #endregion

            #region Etiketler

            private static Dictionary<HesapAlanlari, string> GetEtiketListesi()
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(Foy, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_OZEL_TUTAR_KONU));

                var sozluk = new Dictionary<HesapAlanlari, string>();

                sozluk.Add(HesapAlanlari.ROOT, "Hesap Alanları");
                sozluk.Add(HesapAlanlari.ALACAK_TOPLAMI, "Alacak Toplamı");
                sozluk.Add(HesapAlanlari.ANA_PARAYA_YAPILAN_TAHSILAT, "Ana Paraya Yapılan Tahsilat");
                sozluk.Add(HesapAlanlari.ASIL_ALACAK, "Asıl Alacak");
                sozluk.Add(HesapAlanlari.BASVURMA_HARCI, "Başvurma Harcı");
                sozluk.Add(HesapAlanlari.BIRIKMIS_NAFAKA, "Birikmiş Nafaka");
                sozluk.Add(HesapAlanlari.BSMV_TO, "Takip Öncesi BSMV");
                sozluk.Add(HesapAlanlari.BSMV_TS, "Takip Sonrası BSMV");
                sozluk.Add(HesapAlanlari.CEK_KOMISYONU, "Komisyon");
                sozluk.Add(HesapAlanlari.DAMGA_PULU, "Damga Pulu");
                sozluk.Add(HesapAlanlari.DAVA_GIDERLERI, "Dava Giderleri");
                sozluk.Add(HesapAlanlari.DAVA_INKAR_TAZMINATI, "Dava İnkar Tazminatı");
                sozluk.Add(HesapAlanlari.DAVA_VEKALET_UCRETI, "Dava Vekalet Ücreti");
                sozluk.Add(HesapAlanlari.DEPO_HARCI, "Depo Harcı");
                sozluk.Add(HesapAlanlari.DEPO_VEKALET_UCRETI, "Depo Vekalet Ücreti");
                sozluk.Add(HesapAlanlari.DIGER_GIDERLER, "Diğer Giderler");
                sozluk.Add(HesapAlanlari.DIGER_HARC, "Diğer Harç");
                sozluk.Add(HesapAlanlari.EXTRA_MONEY1, "Extra Para 1");
                sozluk.Add(HesapAlanlari.EXTRA_MONEY2, "Extra Para 2");
                sozluk.Add(HesapAlanlari.FAIZ_TOPLAMI, "Faiz Toplamı");
                sozluk.Add(HesapAlanlari.FAIZE_YAPILAN_TAHSILAT, "Faize Yapılan Tahsilat");
                sozluk.Add(HesapAlanlari.FERAGAT_HARCI, "Feragat Harcı");
                sozluk.Add(HesapAlanlari.FERAGAT_TOPLAMI, "Feragat Toplamı");
                sozluk.Add(HesapAlanlari.GAYRI_NAKIT_KALAN, "Gayri Nakit Kalan");
                sozluk.Add(HesapAlanlari.GAYRI_NAKITIN_TAZMININDEN_GELEN_ASIL_ALACAK, "Gayri Nakitin Tazmininden Gelen Asıl Alacak");
                sozluk.Add(HesapAlanlari.GAYRI_NAKITIN_TAZMININDEN_GELEN_ASIL_ALACAK_FAIZI, "Gayri Nakitin Tazmininden Gelen Asıl Alacak Faizi");
                sozluk.Add(HesapAlanlari.GAYRI_NAKTI_ALACAK, "Gayri Nakit Alacak");
                sozluk.Add(HesapAlanlari.GAYRI_NAKTI_ALACAK_FAIZ, "Gayri Nakit Alacak Faizi");
                sozluk.Add(HesapAlanlari.HARC_TOPLAMI, "Harç Toplamı");
                sozluk.Add(HesapAlanlari.HESAPLANMIS_BSMV, "Hesaplanmış BSMV");
                sozluk.Add(HesapAlanlari.HESAPLANMIS_FAIZ, "Hesaplanmış Faiz");
                sozluk.Add(HesapAlanlari.HESAPLANMIS_KDV, "Hesaplanmış KDV");
                sozluk.Add(HesapAlanlari.HESAPLANMIS_KKDF, "Hesaplanmış KKDF");
                sozluk.Add(HesapAlanlari.HESAPLANMIS_OIV, "Hesaplanmış OIV");
                sozluk.Add(HesapAlanlari.ICRA_INKAR_TAZMINATI, "İcra İnkar Tazminatı");
                sozluk.Add(HesapAlanlari.IFLAS_BASVURMA_HARCI, "İflas Başvurma Harcı");
                sozluk.Add(HesapAlanlari.IFLASIN_ACILMASI_HARCI, "İflasın Açılması Harcı");
                sozluk.Add(HesapAlanlari.IH_VEKALET_UCRETI, "İhtiyati Haciz Vekalet Ücreti");
                sozluk.Add(HesapAlanlari.IHTAR_GIDERI, "İhtar Gideri");
                sozluk.Add(HesapAlanlari.ILAM_BK_YARG_ONAMA, "İlam Bakiya Yarg Onama");
                sozluk.Add(HesapAlanlari.ILAM_INKAR_TAZMINATI, "İlam İnkar Tazminatı");
                sozluk.Add(HesapAlanlari.ILAM_TEBLIG_GIDERI, "İlam Tebliğ Gideri");
                sozluk.Add(HesapAlanlari.ILAM_UCRETLER_TOPLAMI, "İlam Ücretler Toplamı");
                sozluk.Add(HesapAlanlari.ILAM_VEK_UCR, "İlam Vekalet Ücreti");
                sozluk.Add(HesapAlanlari.ILAM_YARGILAMA_GIDERI, "İlam Yargılama Gideri");
                sozluk.Add(HesapAlanlari.ILK_GIDERLER, "İlk Giderler");
                sozluk.Add(HesapAlanlari.ILK_TEBLIGAT_GIDERI, "İlk Tebligat Gideri");
                sozluk.Add(HesapAlanlari.ISLEMIS_FAIZ, "İşlemiş Faiz");
                sozluk.Add(HesapAlanlari.IT_GIDERI, "İhtiyati Tedbir Gideri");
                sozluk.Add(HesapAlanlari.IT_HACIZDE_ODENEN, "İhtiyati Tedbirde Ödenen");
                sozluk.Add(HesapAlanlari.IT_VEKALET_UCRETI, "İhtiyati Tedbir Vekalet Ücreti");
                sozluk.Add(HesapAlanlari.KALAN, "Kalan");
                sozluk.Add(HesapAlanlari.KALAN_TAHSIL_HARCI, "Kalan Tahsil Harcı");
                sozluk.Add(HesapAlanlari.KARSI_VEKALET_TOPLAMI, "Karşı Vekalet Toplamı");
                sozluk.Add(HesapAlanlari.KARSILIK_TUTARI, "Karşılık Tutarı");
                sozluk.Add(HesapAlanlari.KARSILIKSIZ_CEK_TAZMINATI, "Karşılıksız Çek Tazminatı");
                sozluk.Add(HesapAlanlari.KDV_TO, "Takip Öncesi KDV");
                sozluk.Add(HesapAlanlari.KDV_TS, "Takip Sonrası KDV");
                sozluk.Add(HesapAlanlari.KKDV_TO, "Takip Öncesi KKDF");
                sozluk.Add(HesapAlanlari.KO_ILAM_TOPLAM, "KO İlam Toplamı");
                sozluk.Add(HesapAlanlari.MAHSUP_TOPLAMI, "Mahsup Toplamı");
                sozluk.Add(HesapAlanlari.MASAYA_KATILMA_HARCI, "Masaya Katılma Harcı");
                sozluk.Add(HesapAlanlari.MASRAFA_YAPILAN_TAHSILAT, "Masrafa Yapılan Tahsilat");
                sozluk.Add(HesapAlanlari.ODEME_TOPLAMI, "Ödeme Toplamı");
                sozluk.Add(HesapAlanlari.ODENEN_TAHSIL_HARCI, "Ödenen Tahsil Harcı");
                sozluk.Add(HesapAlanlari.OIV_TO, "Takip Öncesi OIV");
                sozluk.Add(HesapAlanlari.OIV_TS, "Takip Sonrası OIV");
                sozluk.Add(HesapAlanlari.OZEL_TAZMINAT, "Özel Tazminat");
                sozluk.Add(HesapAlanlari.OZEL_TUTAR1, Foy.OZEL_TUTAR1_KONU_ID.HasValue ? Foy.OZEL_TUTAR1_KONU_IDSource.KONU : "Özel Tutar1");
                sozluk.Add(HesapAlanlari.OZEL_TUTAR2, Foy.OZEL_TUTAR2_KONU_ID.HasValue ? Foy.OZEL_TUTAR2_KONU_IDSource.KONU : "Özel Tutar2");
                sozluk.Add(HesapAlanlari.OZEL_TUTAR3, Foy.OZEL_TUTAR3_KONU_ID.HasValue ? Foy.OZEL_TUTAR3_KONU_IDSource.KONU : "Özel Tutar3");
                sozluk.Add(HesapAlanlari.PAYLASMA_HARCI, "Paylaşma Harcı");
                sozluk.Add(HesapAlanlari.PESIN_HARC, "Peşin Harç");
                sozluk.Add(HesapAlanlari.PROTESTO_GIDERI, "Protesto Gideri");
                //sozluk.Add(HesapAlanlari.PROTOKOL_MIKTARI, "Protokol Miktarı");
                sozluk.Add(HesapAlanlari.RISK_MIKTARI, "Risk Miktarı");
                sozluk.Add(HesapAlanlari.RISKTEN_KALAN, "Riskten Kalan");
                sozluk.Add(HesapAlanlari.SONRAKI_FAIZ, "Sonraki Faiz");
                sozluk.Add(HesapAlanlari.SONRAKI_TAZMINAT, "Sonraki Tazminat");
                sozluk.Add(HesapAlanlari.TAHLIYE_HARCI, "Tahliye Harcı");
                sozluk.Add(HesapAlanlari.TAHLIYE_VEK_UCR, "Tahliye Vekalet Ücreti");
                sozluk.Add(HesapAlanlari.TAKIP_CIKIS_GAYRI_NAKIT, "Takip Çıkış Gayri Nakit");
                sozluk.Add(HesapAlanlari.TAKIP_CIKISI, "Takip Çıkışı");
                sozluk.Add(HesapAlanlari.TAKIP_VEKALET_UCRETI, "Takip Vekalet Ücreti");
                sozluk.Add(HesapAlanlari.TD_BAKIYE_HARC, "Tahliye Davası Bakiye Harcı");
                sozluk.Add(HesapAlanlari.TD_GIDERI, "Tahliye Davası Gideri");
                sozluk.Add(HesapAlanlari.TD_TEBLIG_GIDERI, "Tahliye Davası Tebliğ Gideri");
                sozluk.Add(HesapAlanlari.TD_VEK_UCR, "Tahliye Davası Vekalet Ücreti");
                sozluk.Add(HesapAlanlari.TESLIM_HARCI, "Teslim Harcı");
                sozluk.Add(HesapAlanlari.TO_MASRAF_TOPLAMI, "Takip Öncesi Masraf Toplamı");
                sozluk.Add(HesapAlanlari.TO_ODEME_MAHSUP_TOPLAMI, "Takip Öncesi Ödeme Mahsup Toplamı");
                sozluk.Add(HesapAlanlari.TO_ODEME_TOPLAMI, "Takip Öncesi Ödeme Toplamı");
                sozluk.Add(HesapAlanlari.TO_VEKALET_TOPLAMI, "Takip Öncesi Vekalet Toplamı");
                sozluk.Add(HesapAlanlari.TO_YONETIMG_TAZMINATI, "Takip Öncesi Yönetim Gider Tazminatı");
                sozluk.Add(HesapAlanlari.TS_MASRAF_HARC_TOPLAMI, "Takip Sonrası Masraf Harç Toplamı");
                sozluk.Add(HesapAlanlari.TS_MASRAF_TOPLAMI, "Takip Sonrası Masraf Toplamı");
                sozluk.Add(HesapAlanlari.TS_VEKALET_TOPLAMI, "Takip Sonrası Vekalet Toplamı");
                sozluk.Add(HesapAlanlari.TUM_MASRAF_TOPLAMI, "Tüm Masraf Toplamı");
                sozluk.Add(HesapAlanlari.TUM_ODEME_TOPLAMI, "Tüm Ödeme Toplamı");
                sozluk.Add(HesapAlanlari.TUM_VEKALET_TOPLAMI, "Tüm Vekalet Toplamı");
                sozluk.Add(HesapAlanlari.VEKALET_HARCI, "Vekalet Harcı");
                sozluk.Add(HesapAlanlari.VEKALET_PULU, "Vekalet Pulu");
                sozluk.Add(HesapAlanlari.VEKALET_UCRETINDEN_ODENEN, "Vekalet Ücretinden Ödenen");
                sozluk.Add(HesapAlanlari.TakipOncesi, "Takip Öncesi");
                sozluk.Add(HesapAlanlari.TakipOncesiOzelTutarlar, "Takip Öncesi Özel Tutarlar");
                sozluk.Add(HesapAlanlari.TakipSonrasi, "Takip Sonrası");
                sozluk.Add(HesapAlanlari.KarsilikVeProtokolBilgileri, "Karşılık ve Protokol Bilgileri");
                sozluk.Add(HesapAlanlari.IlamGiderleri, "İlam Giderleri");
                sozluk.Add(HesapAlanlari.IH_GIDERI, "İhtiyati Haciz Giderleri");
                sozluk.Add(HesapAlanlari.GenelToplam, "Genel Toplam");

                return sozluk;
            }

            #endregion

            /// <summary>
            /// Alt node varsa onların toplamını döndürür yoksa kendi para değerini döndürür
            /// </summary>
            /// <param name="hesapAlani"></param>
            /// <returns></returns>
            private ParaVeDovizId AltAlanToplami(HesapAlani hesapAlani)
            {
                var altHesapAlanlari = this.HesapAlanList.Where(vi => vi.UstAlan == hesapAlani.Alan);

                if (altHesapAlanlari.Count() > 0)
                {
                    List<ParaVeDovizId> liste = new List<ParaVeDovizId>();
                    foreach (var altHesapAlani in altHesapAlanlari)
                    {
                        altHesapAlani.Value = AltAlanToplami(altHesapAlani);
                        liste.Add(altHesapAlani.Value);
                    }

                    return ParaVeDovizId.Topla(liste);
                }

                return hesapAlani.Value;
            }

            /// <summary>
            /// hesap alanlarının alt üst toplam işlemlerini yapar
            /// </summary>
            private void TutarlariYenile()
            {
                foreach (var alan in this.HesapAlanList
                    .Where(vi => vi.Alan == HesapAlanlari.IlamGiderleri
                        || vi.Alan == HesapAlanlari.TakipOncesiOzelTutarlar
                        || vi.Alan == HesapAlanlari.TAKIP_CIKIS_GAYRI_NAKIT))
                {
                    alan.Value = AltAlanToplami(alan);
                }
            }

            public class HesapAlani
            {
                public HesapAlani(decimal? para, int? dovizId, HesapAlanlari alan, HesapAlanlari ustAlan)
                    : this(para, dovizId, alan)
                {
                    this.UstAlan = ustAlan;
                }

                public HesapAlani(decimal? para, int? dovizId, HesapAlanlari alan)
                    : this(para, dovizId)
                {
                    this.Alan = alan;
                }

                public HesapAlani(decimal? para, int? dovizId)
                {
                    this.Value = new ParaVeDovizId(para, dovizId);
                }

                public HesapAlani()
                {
                }

                public HesapAlanlari Alan { get; set; }

                public string CreateString
                {
                    get
                    {
                        if (this.Alan.ToString().Contains("_"))
                        {
                            return string.Format("new HesapAlani(foy.{0},foy.{0}_DOVIZ_ID,HesapAlanlari.{0}, HesapAlanlari.{1}),{2}", this.Alan.ToString(), this.UstAlan.ToString(), Environment.NewLine);
                        }
                        else
                        {
                            return string.Format("new HesapAlani(0,1,HesapAlanlari.{0}, HesapAlanlari.{1}),{2}", this.Alan.ToString(), this.UstAlan.ToString(), Environment.NewLine);
                        }
                    }
                }

                public int Id
                {
                    get { return (int)this.Alan; }
                    set { this.Alan = (HesapAlanlari)value; }
                }

                public string Name
                {
                    get
                    {
                        return EtiketListesi[this.Alan];
                    }
                }

                public HesapAlanlari UstAlan { get; set; }

                public int UstId
                {
                    get { return (int)this.UstAlan; }
                    set { this.UstAlan = (HesapAlanlari)value; }
                }

                public ParaVeDovizId Value { get; set; }
            }
        }

        public class OzetHesap
        {
            public OzetHesap()
            {
                var types = this.GetType().GetProperties();
                foreach (var item in types)
                {
                    if (item.PropertyType == typeof(ParaVeDovizId))
                    {
                        this.GetType().GetProperty(item.Name).SetValue(this, new ParaVeDovizId(), null);
                    }
                }
            }

            /// <summary>
            /// Takip Hesabı yapılmış nesne döndür.
            /// </summary>
            /// <param name="foy"></param>
            public OzetHesap(AV001_TI_BIL_FOY foy)
                : this()
            {
                this.MyFoy = foy;

                foy.BAKIYE_HARC_TOPLAMA_EKLE = false; //Klasör üzerinden takipli hesap yapılırken kalan tahsil harcının hesaba yansımasını engellemek için eklendi. MB

                TakipHesabi(foy);
            }

            /// <summary>
            /// Tarafın Alacak Neden Sorumluluklarına Göre Yapılmış Hesap Döndürür
            /// </summary>
            /// <param name="foy"></param>
            /// <param name="foyTaraf"></param>
            public OzetHesap(AV001_TI_BIL_FOY foy, AV001_TI_BIL_FOY_TARAF foyTaraf)
                : this()
            {
                this.MyFoy = foy;
                TarafHesabi(foy, foyTaraf);
            }

            public OzetHesap(AV001_TI_BIL_FOY foy, AV001_TDIE_BIL_PROJE_TARAF_HESAP foyTaraf, AV001_TDIE_BIL_PROJE proje)
                : this()
            {
                this.MyFoy = foy;
                this.MyProje = proje;
                TarafHesabi(foy, foyTaraf);
            }

            public OzetHesap(AV001_TI_BIL_FOY foy, OzetHesapTipi tipi)
                : this()
            {
                this.MyFoy = foy;
                switch (tipi)
                {
                    case OzetHesapTipi.TakipHesabi:
                        TakipHesabi(foy);
                        break;

                    case OzetHesapTipi.TakibiAcilmamisAlacakHesabi:
                        break;

                    case OzetHesapTipi.TakibiAcilmamisTeminatHesabi:
                        break;

                    case OzetHesapTipi.GayriNakitHesabi:
                        GayriNakitHesabi(foy);
                        break;

                    default:
                        break;
                }
            }

            public enum OzetHesapTipi
            {
                TakipHesabi,
                TakibiAcilmamisAlacakHesabi,
                TakibiAcilmamisTeminatHesabi,
                GayriNakitHesabi
            }

            public ParaVeDovizId IndirimAnaPara { get; set; }

            public ParaVeDovizId IndirimBankaAlacagindanKaln { get; set; }

            public ParaVeDovizId IndirimFaiz { get; set; }

            public ParaVeDovizId IndirimGiderVergisi { get; set; }

            public ParaVeDovizId IndirimHarclar { get; set; }

            public ParaVeDovizId IndirimKalan { get; set; }

            public ParaVeDovizId IndirimKomistonTazminat { get; set; }

            public ParaVeDovizId IndirimMasraf { get; set; }

            public ParaVeDovizId IndirimVekaletUcreti { get; set; }

            public ParaVeDovizId KalanAnaPara { get; set; }

            public ParaVeDovizId KalanBankaAlacagindanKaln { get; set; }

            public ParaVeDovizId KalanFaiz { get; set; }

            public ParaVeDovizId KalanGiderVergisi { get; set; }

            public ParaVeDovizId KalanHarclar { get; set; }

            public ParaVeDovizId KalanKalan { get; set; }

            public ParaVeDovizId KalanKomistonTazminat { get; set; }

            public ParaVeDovizId KalanMasraf { get; set; }

            public ParaVeDovizId KalanVekaletUcreti { get; set; }

            public AV001_TI_BIL_FOY MyFoy { get; set; }

            public AV001_TDIE_BIL_PROJE MyProje { get; set; }

            public ParaVeDovizId OdenenAnaPara { get; set; }

            public ParaVeDovizId OdenenBankaAlacagindanKaln { get; set; }

            public ParaVeDovizId OdenenFaiz { get; set; }

            public ParaVeDovizId OdenenGiderVergisi { get; set; }

            public ParaVeDovizId OdenenHarclar { get; set; }

            public ParaVeDovizId OdenenKalan { get; set; }

            public ParaVeDovizId OdenenKomistonTazminat { get; set; }

            public ParaVeDovizId OdenenMasraf { get; set; }

            public ParaVeDovizId OdenenVekaletUcreti { get; set; }

            public ParaVeDovizId TutarAnaPara { get; set; }

            public ParaVeDovizId TutarBankaAlacagindanKaln { get; set; }

            public ParaVeDovizId TutarFaiz { get; set; }

            public ParaVeDovizId TutarGiderVergisi { get; set; }

            public ParaVeDovizId TutarHarclar { get; set; }

            public ParaVeDovizId TutarKalan { get; set; }

            public ParaVeDovizId TutarKomistonTazminat { get; set; }

            public ParaVeDovizId TutarMasraf { get; set; }

            public ParaVeDovizId TutarVekaletUcreti { get; set; }

            public AV001_TDIE_BIL_PROJE_HESAP GetProjeHesap()
            {
                AV001_TDIE_BIL_PROJE_HESAP hesap = new AV001_TDIE_BIL_PROJE_HESAP();

                GetProjeHesap(hesap);

                return hesap;
            }

            public void GetProjeHesap(AV001_TDIE_BIL_PROJE_HESAP hesap)
            {
                #region İndirim

                hesap.INDIRIM_ANAPARA = this.IndirimAnaPara.Para;
                hesap.INDIRIM_ANAPARA_DOVIZ_ID = this.IndirimAnaPara.DovizId;
                hesap.INDIRIM_BANKA_BAKIYESI = this.IndirimBankaAlacagindanKaln.Para;
                hesap.INDIRIM_BANKA_BAKIYESI_DOVIZ_ID = this.IndirimBankaAlacagindanKaln.DovizId;
                hesap.INDIRIM_FAIZ = this.IndirimFaiz.Para;
                hesap.INDIRIM_FAIZ_DOVIZ_ID = this.IndirimFaiz.DovizId;
                hesap.INDIRIM_GIDER_VERGISI = this.IndirimGiderVergisi.Para;
                hesap.INDIRIM_GIDER_VERGISI_DOVIZ_ID = this.IndirimGiderVergisi.DovizId;
                hesap.INDIRIM_KALAN = this.IndirimKalan.Para;
                hesap.INDIRIM_KALAN_DOVIZ_ID = this.IndirimKalan.DovizId;
                hesap.INDIRIM_KOM_TAZ = this.IndirimKomistonTazminat.Para;
                hesap.INDIRIM_KOM_TAZ_DOVIZ_ID = this.IndirimKomistonTazminat.DovizId;
                hesap.INDIRIM_MASRAF = this.IndirimMasraf.Para;
                hesap.INDIRIM_MASRAF_DOVIZ_ID = this.IndirimMasraf.DovizId;
                if (hesap.INDIRIM_VEKALET_UCRETI == 0)
                {
                    hesap.INDIRIM_VEKALET_UCRETI = this.IndirimVekaletUcreti.Para;
                    hesap.INDIRIM_VEKALET_UCRETI_DOVIZ_ID = this.IndirimVekaletUcreti.DovizId;
                }

                #endregion

                #region Kalan
                hesap.KALAN_ANAPARA = this.KalanAnaPara.Para;
                hesap.KALAN_ANAPARA_DOVIZ_ID = this.KalanAnaPara.DovizId;
                hesap.KALAN_BANKA_BAKIYESI = this.KalanBankaAlacagindanKaln.Para;
                hesap.KALAN_BANKA_BAKIYESI_DOVIZ_ID = this.KalanBankaAlacagindanKaln.DovizId;
                hesap.KALAN_FAIZ = this.KalanFaiz.Para;
                hesap.KALAN_FAIZ_DOVIZ_ID = this.KalanFaiz.DovizId;
                hesap.KALAN_GIDER_VERGISI = this.KalanGiderVergisi.Para;
                hesap.KALAN_GIDER_VERGISI_DOVIZ_ID = this.KalanGiderVergisi.DovizId;
                hesap.KALAN_KALAN = this.KalanKalan.Para;
                hesap.KALAN_KALAN_DOVIZ_ID = this.KalanKalan.DovizId;
                hesap.KALAN_KOM_TAZ = this.KalanKomistonTazminat.Para;
                hesap.KALAN_KOM_TAZ_DOVIZ_ID = this.KalanKomistonTazminat.DovizId;
                hesap.KALAN_MASRAF = this.KalanMasraf.Para;
                hesap.KALAN_MASRAF_DOVIZ_ID = this.KalanMasraf.DovizId;
                hesap.KALAN_VEKALET_UCRETI = this.KalanVekaletUcreti.Para;
                hesap.KALAN_VEKALET_UCRETI_DOVIZ_ID = this.KalanVekaletUcreti.DovizId;

                #endregion

                #region Ödeme
                hesap.ODEME_ANAPARA = this.OdenenAnaPara.Para;
                hesap.ODEME_ANAPARA_DOVIZ_ID = this.OdenenAnaPara.DovizId;
                if (this.OdenenBankaAlacagindanKaln != null)
                {
                    hesap.ODEME_BANKA_BAKIYESI = this.OdenenBankaAlacagindanKaln.Para;
                    hesap.ODEME_BANKA_BAKIYESI_DOVIZ_ID = this.OdenenBankaAlacagindanKaln.DovizId;
                }
                hesap.ODEME_FAIZ = this.OdenenFaiz.Para;
                hesap.ODEME_FAIZ_DOVIZ_ID = this.OdenenFaiz.DovizId;
                hesap.ODEME_GIDER_VERGISI = this.OdenenGiderVergisi.Para;
                hesap.ODEME_GIDER_VERGISI_DOVIZ_ID = this.OdenenGiderVergisi.DovizId;
                hesap.ODEME_KALAN = this.OdenenKalan.Para;
                hesap.ODEME_KALAN_DOVIZ_ID = this.OdenenKalan.DovizId;
                if (this.OdenenKomistonTazminat != null)
                {
                    hesap.ODEME_KOM_TAZ = this.OdenenKomistonTazminat.Para;
                    hesap.ODEME_KOM_TAZ_DOVIZ_ID = this.OdenenKomistonTazminat.DovizId;
                }
                hesap.ODEME_MASRAF = this.OdenenMasraf.Para;
                hesap.ODEME_MASRAF_DOVIZ_ID = this.OdenenMasraf.DovizId;
                hesap.ODEME_VEKALET_UCRETI = this.OdenenVekaletUcreti.Para;
                hesap.ODEME_VEKALET_UCRETI_DOVIZ_ID = this.OdenenVekaletUcreti.DovizId;
                #endregion

                #region Tutar
                hesap.TUTAR_ANAPARA = this.TutarAnaPara.Para;
                hesap.TUTAR_ANAPARA_DOVIZ_ID = this.TutarAnaPara.DovizId;
                hesap.TUTAR_BANKA_BAKIYESI = this.TutarBankaAlacagindanKaln.Para;
                hesap.TUTAR_BANKA_BAKIYESI_DOVIZ_ID = this.TutarBankaAlacagindanKaln.DovizId;
                hesap.TUTAR_FAIZ = this.TutarFaiz.Para;
                hesap.TUTAR_FAIZ_DOVIZ_ID = this.TutarFaiz.DovizId;
                hesap.TUTAR_GIDER_VERGISI = this.TutarGiderVergisi.Para;
                hesap.TUTAR_GIDER_VERGISI_DOVIZ_ID = this.TutarGiderVergisi.DovizId;
                hesap.TUTAR_KALAN = this.TutarKalan.Para;
                hesap.TUTAR_KALAN_DOVIZ_ID = this.TutarKalan.DovizId;
                if (hesap.TUTAR_KOM_TAZ == 0)
                {
                    hesap.TUTAR_KOM_TAZ = this.TutarKomistonTazminat.Para;
                    hesap.TUTAR_KOM_TAZ_DOVIZ_ID = this.TutarKomistonTazminat.DovizId;
                }
                hesap.TUTAR_MASRAF = this.TutarMasraf.Para;
                hesap.TUTAR_MASRAF_DOVIZ_ID = this.TutarMasraf.DovizId;
                hesap.TUTAR_VEKALET_UCRETI = this.TutarVekaletUcreti.Para;
                hesap.TUTAR_VEKALET_UCRETI_DOVIZ_ID = this.TutarVekaletUcreti.DovizId;
                #endregion

                hesap.SON_HESAP_TARIHI = this.MyFoy.SON_HESAP_TARIHI ?? DateTime.Now;
                hesap.HESAPLAMA_TIPI = this.MyFoy.HESAPLAMA_TIPI;
                var riskToplami = ParaVeDovizId.Topla(this.TutarAnaPara, this.TutarHarclar, this.TutarMasraf);
                hesap.RISK_TOPLAMI = riskToplami.Para;
                hesap.RISK_TOPLAMI_DOVIZ_ID = riskToplami.DovizId;
            }

            #region Kaynaklar
            #endregion

            #region Tutar Alanları
            #endregion
            #region Ödenen Alanları
            #endregion
            #region İndirim Alanları
            #endregion
            #region Kalan Alanları
            #endregion

            #region Takip Hesabı

            private void AltToplamlar()
            {
                this.OdenenKalan = ParaVeDovizId.Topla(OdenenAnaPara,
                                                          OdenenFaiz,
                                                          OdenenGiderVergisi,
                                                          OdenenMasraf,
                                                          OdenenHarclar,
                                                          OdenenKomistonTazminat,
                                                          OdenenBankaAlacagindanKaln,
                                                          OdenenVekaletUcreti);
                this.IndirimKalan = ParaVeDovizId.Topla(IndirimAnaPara,
                                          IndirimFaiz,
                                          IndirimGiderVergisi,
                                          IndirimMasraf,
                                          IndirimHarclar,
                                          IndirimKomistonTazminat,
                                          IndirimBankaAlacagindanKaln,
                                          IndirimVekaletUcreti);
            }

            private void GayriNakitHesabi(AV001_TI_BIL_FOY foy)
            {
                ///Föye bağlı gayri nakit alacaklarını getiriyoruz
                var gayriNakitAlacaklar = HesapAraclari.Icra.AlacakNedenGayriNakitleriGetir(foy);

                if (gayriNakitAlacaklar.Count > 0)
                {
                    var asilAlacaklar = new List<ParaVeDovizId>();
                    var odenenListesi = new List<ParaVeDovizId>();

                    foreach (var neden in gayriNakitAlacaklar)
                    {
                        asilAlacaklar.Add(new ParaVeDovizId(neden.ISLEME_KONAN_TUTAR, neden.ISLEME_KONAN_TUTAR_DOVIZ_ID));

                        odenenListesi.Add(new ParaVeDovizId(neden.IADE_MIKTARI, neden.IADE_MIKTARI_DOVIZ_ID));
                        odenenListesi.Add(new ParaVeDovizId(neden.DEPO_MIKTARI, neden.DEPO_MIKTARI_DOVIZ_ID));
                    }

                    this.TutarAnaPara = ParaVeDovizId.Topla(asilAlacaklar);
                    this.OdenenAnaPara = ParaVeDovizId.Topla(odenenListesi);

                    this.KalanAnaPara = ParaVeDovizId.Cikart(this.TutarAnaPara, this.OdenenAnaPara);

                    if (foy.TAKIP_TARIHI.HasValue)
                    {
                        this.TutarHarclar = FaizHelper.IcraHarcTutarGetir(foy.TAKIP_TARIHI.Value, 440); //Başvurma Harcı

                        this.TutarVekaletUcreti = FaizHelper.VekaletTutariGetir(foy.TAKIP_TARIHI.Value, 297);  //297	İCRA DAİRELERİNDE YAPILAN TAKİPLER İÇİN
                    }
                }

                AltToplamlar();
                KalanHesapla();
            }

            private void KalanHesapla()
            {
                KalanAnaPara = ParaVeDovizId.Cikart(TutarAnaPara, ParaVeDovizId.Topla(OdenenAnaPara, IndirimAnaPara));
                KalanFaiz = ParaVeDovizId.Cikart(TutarFaiz, ParaVeDovizId.Topla(OdenenFaiz, IndirimFaiz));
                KalanGiderVergisi = ParaVeDovizId.Cikart(TutarGiderVergisi, ParaVeDovizId.Topla(OdenenGiderVergisi, IndirimGiderVergisi));
                KalanMasraf = ParaVeDovizId.Cikart(TutarMasraf, ParaVeDovizId.Topla(OdenenMasraf, IndirimMasraf));
                KalanHarclar = ParaVeDovizId.Cikart(TutarHarclar, ParaVeDovizId.Topla(OdenenHarclar, IndirimHarclar));
                KalanKomistonTazminat = ParaVeDovizId.Cikart(TutarKomistonTazminat, ParaVeDovizId.Topla(OdenenKomistonTazminat, IndirimKomistonTazminat));
                KalanBankaAlacagindanKaln = ParaVeDovizId.Cikart(TutarBankaAlacagindanKaln, ParaVeDovizId.Topla(OdenenBankaAlacagindanKaln, IndirimBankaAlacagindanKaln));
                KalanVekaletUcreti = ParaVeDovizId.Cikart(TutarVekaletUcreti, ParaVeDovizId.Topla(OdenenVekaletUcreti, IndirimVekaletUcreti));

                this.KalanKalan = ParaVeDovizId.Cikart(this.TutarKalan, ParaVeDovizId.Topla(this.OdenenKalan, this.IndirimKalan));
            }

            private void TakipHesabi(AV001_TI_BIL_FOY foy)
            {
                this.TakipHesabiTutarHesapla(foy);
                this.TakipHesabiOdenenHesapla(foy);
                this.TakipHesabiIndirimHesapla(foy);

                AltToplamlar();
                KalanHesapla();
            }

            private void TakipHesabiIndirimHesapla(AV001_TI_BIL_FOY obj)
            {
                Dictionary<MahsupKategori, List<ParaVeDovizId>> sozluk = new Dictionary<MahsupKategori, List<ParaVeDovizId>>();

                #region Deepload Kontürolü yapılıyor

                if (obj.AV001_TI_BIL_FERAGATCollection.Count == 0)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(obj, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FERAGAT>));
                    if (obj.AV001_TI_BIL_FERAGATCollection.Count > 0)
                        DataRepository.AV001_TI_BIL_FERAGATProvider.DeepLoad(obj.AV001_TI_BIL_FERAGATCollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));
                }
                else if (obj.AV001_TI_BIL_FERAGATCollection.Count > 0)
                {
                    if (obj.AV001_TI_BIL_FERAGATCollection[0].AV001_TI_BIL_ODEME_DAGILIMCollection.Count == 0)
                        DataRepository.AV001_TI_BIL_FERAGATProvider.DeepLoad(obj.AV001_TI_BIL_FERAGATCollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));
                }

                #endregion

                TList<AV001_TI_BIL_ODEME_DAGILIM> feragatListesi = new TList<AV001_TI_BIL_ODEME_DAGILIM>();

                #region Feragatların Dağılımı Tek Listeye alınıyor
                foreach (var feragat in obj.AV001_TI_BIL_FERAGATCollection)
                {
                    if (feragat.AV001_TI_BIL_ODEME_DAGILIMCollection.Count > 0)
                    {
                        feragatListesi.AddRange(feragat.AV001_TI_BIL_ODEME_DAGILIMCollection);
                    }
                }
                #endregion

                foreach (var dagilim in feragatListesi)
                {
                    #region Kalemler Ayrıştırılıyor
                    if (dagilim.DAGILIM_TIPI == 1)//dagilim.FERAGAT_ID != null)
                    {
                        if (!sozluk.ContainsKey((MahsupKategori)dagilim.MAHSUP_KATEGORI_ID))
                            sozluk.Add((MahsupKategori)dagilim.MAHSUP_KATEGORI_ID, new List<ParaVeDovizId>());

                        switch ((MahsupKategori)dagilim.MAHSUP_KATEGORI_ID)
                        {
                            case MahsupKategori.Asil_Alacak:
                            case MahsupKategori.Diger:
                                sozluk[MahsupKategori.Asil_Alacak].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));
                                break;

                            case MahsupKategori.Vekalet_Ucreti:
                                sozluk[MahsupKategori.Vekalet_Ucreti].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));
                                break;

                            case MahsupKategori.Harclar:
                                sozluk[MahsupKategori.Harclar].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));

                                break;

                            case MahsupKategori.Tazminatlar:
                                sozluk[MahsupKategori.Tazminatlar].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));

                                break;

                            case MahsupKategori.Masraflar:
                                sozluk[MahsupKategori.Masraflar].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));

                                break;

                            case MahsupKategori.Faizler:
                                sozluk[MahsupKategori.Faizler].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));

                                break;

                            case MahsupKategori.Vergiler:
                                sozluk[MahsupKategori.Vergiler].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));
                                break;

                            default:
                                break;
                        }
                    }
                    #endregion
                }

                foreach (var teki in sozluk)
                {
                    #region Toplamlar İçin Dönüyor
                    switch (teki.Key)
                    {
                        case MahsupKategori.Asil_Alacak:
                            this.IndirimAnaPara = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Vekalet_Ucreti:
                            this.IndirimVekaletUcreti = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Harclar:
                            this.IndirimHarclar = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Tazminatlar:
                            this.IndirimKomistonTazminat = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Masraflar:
                            this.IndirimMasraf = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Faizler:
                            this.IndirimFaiz = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Vergiler:
                            this.IndirimGiderVergisi = ParaVeDovizId.Topla(teki.Value);
                            break;

                        default:
                            break;
                    }
                    #endregion
                }
            }

            private void TakipHesabiOdenenHesapla(AV001_TI_BIL_FOY obj)
            {
                Dictionary<MahsupKategori, List<ParaVeDovizId>> sozluk = new Dictionary<MahsupKategori, List<ParaVeDovizId>>();

                #region Deepload Kontrolü Yapılarak Deepload Çekiliyor
                if (obj.AV001_TI_BIL_BORCLU_ODEMECollection.Count == 0)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(obj, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_ODEME>));
                    if (obj.AV001_TI_BIL_FERAGATCollection.Count > 0)
                        DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepLoad(obj.AV001_TI_BIL_BORCLU_ODEMECollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));
                }
                else if (obj.AV001_TI_BIL_BORCLU_ODEMECollection.Count > 0)
                {
                    if (obj.AV001_TI_BIL_BORCLU_ODEMECollection[0].AV001_TI_BIL_ODEME_DAGILIMCollection.Count == 0)
                        DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepLoad(obj.AV001_TI_BIL_BORCLU_ODEMECollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));
                }
                #endregion

                TList<AV001_TI_BIL_ODEME_DAGILIM> dagilimListesi = new TList<AV001_TI_BIL_ODEME_DAGILIM>();

                #region Tüm Ödeme Dağılımları Tek Listeye Alınıyor
                foreach (var odeme in obj.AV001_TI_BIL_BORCLU_ODEMECollection)
                {
                    if (odeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Count > 0)
                    {
                        dagilimListesi.AddRange(odeme.AV001_TI_BIL_ODEME_DAGILIMCollection);
                    }
                }
                #endregion

                ///Mahsup Kategorisine göre Sözlüğe alıyoruz
                foreach (var dagilim in dagilimListesi)
                {
                    #region Kalemler Ayrıştırılıyor
                    if (dagilim.DAGILIM_TIPI == 1)//dagilim.ODEME_ID != null)
                    {
                        var mahsupKategori = (MahsupKategori)dagilim.MAHSUP_KATEGORI_ID;
                        if (mahsupKategori == MahsupKategori.Diger)
                            mahsupKategori = MahsupKategori.Asil_Alacak;
                        if (!sozluk.ContainsKey(mahsupKategori))
                        {
                            sozluk.Add(mahsupKategori, new List<ParaVeDovizId>());
                        }

                        sozluk[mahsupKategori].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));
                    }
                    #endregion
                }
                ///Mahsum Kategorisine göre toplama işlemi yapılıyor
                foreach (var teki in sozluk)
                {
                    #region Toplamlar İçin Dönüyor
                    switch (teki.Key)
                    {
                        case MahsupKategori.Asil_Alacak:
                            this.OdenenAnaPara = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Vekalet_Ucreti:
                            this.OdenenVekaletUcreti = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Harclar:
                            this.OdenenHarclar = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Tazminatlar:
                            this.OdenenKomistonTazminat = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Masraflar:
                            this.OdenenMasraf = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Faizler:
                            this.OdenenFaiz = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Vergiler:
                            this.OdenenGiderVergisi = ParaVeDovizId.Topla(teki.Value);
                            break;

                        default:
                            break;
                    }
                    #endregion
                }

                //this.OdenenBankaAlacagindanKaln = ParaVeDovizId.Topla(OdenenAnaPara, OdenenHarclar, OdenenKomistonTazminat, OdenenMasraf, OdenenFaiz, OdenenGiderVergisi);
            }

            private void TakipHesabiTutarHesapla(AV001_TI_BIL_FOY obj)
            {
                //Tutar - anapara
                ParaVeDovizId prOzelTutar1 = new ParaVeDovizId(obj.OZEL_TUTAR1, obj.OZEL_TUTAR1_DOVIZ_ID);
                ParaVeDovizId prOzelTutar2 = new ParaVeDovizId(obj.OZEL_TUTAR2, obj.OZEL_TUTAR2_DOVIZ_ID);
                ParaVeDovizId prOzelTutar3 = new ParaVeDovizId(obj.OZEL_TUTAR3, obj.OZEL_TUTAR3_DOVIZ_ID);
                ParaVeDovizId prAsilAlacak = new ParaVeDovizId(obj.ASIL_ALACAK, obj.ASIL_ALACAK_DOVIZ_ID);
                this.TutarAnaPara = ParaVeDovizId.Topla(prOzelTutar1, prOzelTutar2, prOzelTutar3, prAsilAlacak);

                //Tutar - faiz
                ParaVeDovizId prISLEMIS_FAIZ = new ParaVeDovizId(obj.ISLEMIS_FAIZ, obj.ISLEMIS_FAIZ_DOVIZ_ID);
                ParaVeDovizId prSONRAKI_FAIZ = new ParaVeDovizId(obj.SONRAKI_FAIZ, obj.SONRAKI_FAIZ_DOVIZ_ID);

                this.TutarFaiz = ParaVeDovizId.Topla(prISLEMIS_FAIZ, prSONRAKI_FAIZ);

                //Tutar - gider vergisi
                ParaVeDovizId prBSMV_TS = new ParaVeDovizId(obj.BSMV_TS, obj.BSMV_TS_DOVIZ_ID);
                ParaVeDovizId prBSMV_TO = new ParaVeDovizId(obj.BSMV_TO, obj.BSMV_TO_DOVIZ_ID);
                ParaVeDovizId prKKDF_TO = new ParaVeDovizId(obj.KKDV_TO, obj.KKDV_TO_DOVIZ_ID);
                ParaVeDovizId prKDF_TO = new ParaVeDovizId(obj.KDV_TO, obj.KDV_TO_DOVIZ_ID);
                ParaVeDovizId prKDF_TS = new ParaVeDovizId(obj.KDV_TS, obj.KDV_TS_DOVIZ_ID);
                ParaVeDovizId prOIVTO = new ParaVeDovizId(obj.OIV_TO, obj.OIV_TO_DOVIZ_ID);
                ParaVeDovizId prOIVTS = new ParaVeDovizId(obj.OIV_TS, obj.OIV_TS_DOVIZ_ID);

                this.TutarGiderVergisi = ParaVeDovizId.Topla(prBSMV_TS, prBSMV_TO, prKKDF_TO, prKDF_TO, prKDF_TS, prOIVTO, prOIVTS);

                //Tutar - masraf
                ParaVeDovizId prDIGER_GIDERLER = new ParaVeDovizId(obj.DIGER_GIDERLER, obj.DIGER_GIDERLER_DOVIZ_ID);
                ParaVeDovizId prDAVA_GIDERLERI = new ParaVeDovizId(obj.DAVA_GIDERLERI, obj.DAVA_GIDERLERI_DOVIZ_ID);
                ParaVeDovizId prTD_GIDERI = new ParaVeDovizId(obj.TD_GIDERI, obj.TD_GIDERI_DOVIZ_ID);
                ParaVeDovizId prTD_TEBLIG_GIDERI = new ParaVeDovizId(obj.TD_TEBLIG_GIDERI, obj.TD_TEBLIG_GIDERI_DOVIZ_ID);
                ParaVeDovizId prTO_MASRAF_TOPLAMI = new ParaVeDovizId(obj.TO_MASRAF_TOPLAMI, obj.TO_MASRAF_TOPLAMI_DOVIZ_ID);
                ParaVeDovizId prILK_TEBLIGAT_GIDERI = new ParaVeDovizId(obj.ILK_TEBLIGAT_GIDERI, obj.ILK_TEBLIGAT_GIDERI_DOVIZ_ID);
                ParaVeDovizId prDAVA_VEKALET_UCRETI = new ParaVeDovizId(obj.DAVA_VEKALET_UCRETI, obj.DAVA_VEKALET_UCRETI_DOVIZ_ID);

                this.TutarMasraf = ParaVeDovizId.Topla(prDIGER_GIDERLER, prDAVA_GIDERLERI, prTD_GIDERI, prTD_TEBLIG_GIDERI, prTO_MASRAF_TOPLAMI, prILK_TEBLIGAT_GIDERI, prDAVA_VEKALET_UCRETI);

                //kalan - harçlar
                ParaVeDovizId prBASVURMA_HARCI = new ParaVeDovizId(obj.BASVURMA_HARCI, obj.BASVURMA_HARCI_DOVIZ_ID);
                ParaVeDovizId prPESIN_HARC = new ParaVeDovizId(obj.PESIN_HARC, obj.PESIN_HARC_DOVIZ_ID);
                ParaVeDovizId prIFLAS_BASVURMA_HARCI = new ParaVeDovizId(obj.IFLAS_BASVURMA_HARCI, obj.IFLAS_BASVURMA_HARCI_DOVIZ_ID);
                ParaVeDovizId prIFLASIN_ACILMASI_HARCI = new ParaVeDovizId(obj.IFLASIN_ACILMASI_HARCI, obj.IFLASIN_ACILMASI_HARCI_DOVIZ_ID);
                ParaVeDovizId prVEKALET_HARCI = new ParaVeDovizId(obj.VEKALET_HARCI, obj.VEKALET_HARCI_DOVIZ_ID);
                ParaVeDovizId prDIGER_HARC = new ParaVeDovizId(obj.DIGER_HARC, obj.DIGER_HARC_DOVIZ_ID);
                ParaVeDovizId prTD_BAKIYE_HARC = new ParaVeDovizId(obj.TD_BAKIYE_HARC, obj.TD_BAKIYE_HARC_DOVIZ_ID);
                ParaVeDovizId prPAYLASMA_HARCI = new ParaVeDovizId(obj.PAYLASMA_HARCI, obj.PAYLASMA_HARCI_DOVIZ_ID);
                ParaVeDovizId prMASAYA_KATILMA_HARCI = new ParaVeDovizId(obj.MASAYA_KATILMA_HARCI, obj.MASAYA_KATILMA_HARCI_DOVIZ_ID);
                ParaVeDovizId prODENEN_TAHSIL_HARCI = new ParaVeDovizId(obj.ODENEN_TAHSIL_HARCI, obj.ODENEN_TAHSIL_HARCI_DOVIZ_ID);
                ParaVeDovizId prVEKALET_PULU = new ParaVeDovizId(obj.VEKALET_PULU, obj.VEKALET_PULU_DOVIZ_ID);
                ParaVeDovizId prIHTIYATI_HACIZ_GIRERI = new ParaVeDovizId(obj.IH_GIDERI, obj.IH_GIDERI_DOVIZ_ID);
                ParaVeDovizId prDEPO_HARCI = new ParaVeDovizId(obj.DEPO_HARCI, obj.DEPO_HARCI_DOVIZ_ID);

                this.TutarHarclar = ParaVeDovizId.Topla(prDEPO_HARCI, prBASVURMA_HARCI, prPESIN_HARC, prIFLAS_BASVURMA_HARCI, prVEKALET_PULU,
                                               prIFLASIN_ACILMASI_HARCI, prVEKALET_HARCI, prDIGER_HARC, prTD_BAKIYE_HARC, prODENEN_TAHSIL_HARCI,
                                              prPAYLASMA_HARCI, prMASAYA_KATILMA_HARCI, prIHTIYATI_HACIZ_GIRERI);

                //Kalan Tahsil Harcı Hesaba dahil ise ekleme yapıyoruz
                if (obj.BAKIYE_HARC_TOPLAMA_EKLE)
                {
                    ParaVeDovizId prKALAN_TAHSIL_HARCI = new ParaVeDovizId(obj.KALAN_TAHSIL_HARCI, obj.KALAN_TAHSIL_HARCI_DOVIZ_ID);

                    this.TutarHarclar = ParaVeDovizId.Topla(this.TutarHarclar, prKALAN_TAHSIL_HARCI);
                }

                //Tutar - komisyon tazminat vs.
                ParaVeDovizId prCEK_KOMISYONU = new ParaVeDovizId(obj.CEK_KOMISYONU, obj.CEK_KOMISYONU_DOVIZ_ID);
                ParaVeDovizId prKARSILIKSIZ_CEK_TAZMINATI = new ParaVeDovizId(obj.KARSILIKSIZ_CEK_TAZMINATI, obj.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID);
                ParaVeDovizId prOZEL_TAMINAT = new ParaVeDovizId(obj.OZEL_TAZMINAT, obj.OZEL_TAZMINAT_DOVIZ_ID);

                this.TutarKomistonTazminat = ParaVeDovizId.Topla(prCEK_KOMISYONU, prKARSILIKSIZ_CEK_TAZMINATI, prOZEL_TAMINAT);

                //Tutar - banka alacağından
                ParaVeDovizId prALACAK_TOPLAMI = new ParaVeDovizId(obj.ALACAK_TOPLAMI, obj.ALACAK_TOPLAMI_DOVIZ_ID);

                //üstekinden çıkıcak
                ParaVeDovizId prTS_VEKALET_TOPLAMI = new ParaVeDovizId(obj.TS_VEKALET_TOPLAMI, obj.TS_VEKALET_TOPLAMI_DOVIZ_ID);
                ParaVeDovizId prIH_VEKALET_TOPLAMI = new ParaVeDovizId(obj.IH_VEKALET_UCRETI, obj.IH_VEKALET_UCRETI_DOVIZ_ID);
                ParaVeDovizId prDEPO_VEKALET_UCRETI = new ParaVeDovizId(obj.DEPO_VEKALET_UCRETI, obj.DEPO_VEKALET_UCRET_DOVIZ_ID);

                this.TutarBankaAlacagindanKaln = ParaVeDovizId.Topla(TutarKomistonTazminat, ParaVeDovizId.Cikart(prALACAK_TOPLAMI, prTS_VEKALET_TOPLAMI));

                //Tutar - vekalet ücreti
                this.TutarVekaletUcreti = ParaVeDovizId.Topla(prTS_VEKALET_TOPLAMI, prIH_VEKALET_TOPLAMI, prDEPO_VEKALET_UCRETI);

                //Tutar - kalan
                this.TutarKalan = ParaVeDovizId.Topla(this.TutarKomistonTazminat, this.TutarFaiz, this.TutarAnaPara, this.TutarHarclar,
                                                        this.TutarMasraf, this.TutarVekaletUcreti, this.TutarGiderVergisi); ;

                this.TutarBankaAlacagindanKaln = ParaVeDovizId.Cikart(this.TutarKalan, this.TutarVekaletUcreti);
            }

            #endregion

            #region Gayri Nakit Hesabı
            #endregion

            #region Taraf Hesabı

            private void TarafHesabi(AV001_TI_BIL_FOY foy, AV001_TI_BIL_FOY_TARAF taraf)
            {
                TarafHesabiTutarHesapla(taraf);
                TarafHesabiOdenenHesapla(foy, taraf);
                AltToplamlar();
                KalanHesapla();
            }

            private void TarafHesabi(AV001_TI_BIL_FOY foy, AV001_TDIE_BIL_PROJE_TARAF_HESAP taraf)
            {
                TarafHesabiTutarHesapla(taraf);
                TarafHesabiOdenenHesapla(foy, taraf);
                AltToplamlar();
                KalanHesapla();
            }

            private void TarafHesabiOdenenHesapla(AV001_TI_BIL_FOY obj, AV001_TI_BIL_FOY_TARAF trf)
            {
                Dictionary<MahsupKategori, List<ParaVeDovizId>> sozluk = new Dictionary<MahsupKategori, List<ParaVeDovizId>>();

                if (obj.AV001_TI_BIL_BORCLU_ODEMECollection.Count == 0)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(obj, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_ODEME>));
                    if (obj.AV001_TI_BIL_FERAGATCollection.Count > 0)
                        DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepLoad(obj.AV001_TI_BIL_BORCLU_ODEMECollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));
                }
                else if (obj.AV001_TI_BIL_BORCLU_ODEMECollection.Count > 0)
                {
                    if (obj.AV001_TI_BIL_BORCLU_ODEMECollection[0].AV001_TI_BIL_ODEME_DAGILIMCollection.Count == 0)
                        DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepLoad(obj.AV001_TI_BIL_BORCLU_ODEMECollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));
                }

                TList<AV001_TI_BIL_ODEME_DAGILIM> dagilimListesi = new TList<AV001_TI_BIL_ODEME_DAGILIM>();

                foreach (var odeme in obj.AV001_TI_BIL_BORCLU_ODEMECollection)
                {
                    if (odeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Count > 0)
                    {
                        foreach (var dagilim in odeme.AV001_TI_BIL_ODEME_DAGILIMCollection)
                        {
                            if (dagilim.FOY_TARAF_ID.HasValue
                                && dagilim.FOY_TARAF_ID.Value == trf.ID
                                && dagilim.DAGILIM_TIPI == 2)
                                dagilimListesi.Add(dagilim);
                        }
                        // dagilimListesi.AddRange(odeme.AV001_TI_BIL_ODEME_DAGILIMCollection);
                    }
                }

                foreach (var dagilim in dagilimListesi)
                {
                    #region Kalemler Ayrıştırılıyor
                    if (true)//dagilim.ODEME_ID != null)
                    {
                        if (!sozluk.ContainsKey((MahsupKategori)dagilim.MAHSUP_KATEGORI_ID))
                            sozluk.Add((MahsupKategori)dagilim.MAHSUP_KATEGORI_ID, new List<ParaVeDovizId>());

                        switch ((MahsupKategori)dagilim.MAHSUP_KATEGORI_ID)
                        {
                            case MahsupKategori.Asil_Alacak:
                            case MahsupKategori.Diger:
                                sozluk[MahsupKategori.Asil_Alacak].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));
                                break;

                            case MahsupKategori.Vekalet_Ucreti:
                                sozluk[MahsupKategori.Vekalet_Ucreti].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));
                                break;

                            case MahsupKategori.Harclar:
                                sozluk[MahsupKategori.Harclar].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));

                                break;

                            case MahsupKategori.Tazminatlar:
                                sozluk[MahsupKategori.Tazminatlar].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));

                                break;

                            case MahsupKategori.Masraflar:
                                sozluk[MahsupKategori.Masraflar].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));

                                break;

                            case MahsupKategori.Faizler:
                                sozluk[MahsupKategori.Faizler].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));

                                break;

                            case MahsupKategori.Vergiler:
                                sozluk[MahsupKategori.Vergiler].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));
                                break;

                            default:
                                break;
                        }
                    }
                    #endregion
                }

                foreach (var teki in sozluk)
                {
                    #region Toplamlar İçin Dönüyor
                    switch (teki.Key)
                    {
                        case MahsupKategori.Asil_Alacak:
                            this.OdenenAnaPara = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Vekalet_Ucreti:
                            this.OdenenVekaletUcreti = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Harclar:
                            this.OdenenHarclar = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Tazminatlar:
                            this.OdenenKomistonTazminat = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Masraflar:
                            this.OdenenMasraf = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Faizler:
                            this.OdenenFaiz = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Vergiler:
                            this.OdenenGiderVergisi = ParaVeDovizId.Topla(teki.Value);
                            break;

                        default:
                            break;
                    }
                    #endregion
                }
            }

            private void TarafHesabiOdenenHesapla(AV001_TI_BIL_FOY obj, AV001_TDIE_BIL_PROJE_TARAF_HESAP trf)
            {
                Dictionary<MahsupKategori, List<ParaVeDovizId>> sozluk = new Dictionary<MahsupKategori, List<ParaVeDovizId>>();

                if (obj.AV001_TI_BIL_BORCLU_ODEMECollection.Count == 0)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(obj, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_ODEME>));
                    if (obj.AV001_TI_BIL_FERAGATCollection.Count > 0)
                        DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepLoad(obj.AV001_TI_BIL_BORCLU_ODEMECollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));
                }
                else if (obj.AV001_TI_BIL_BORCLU_ODEMECollection.Count > 0)
                {
                    if (obj.AV001_TI_BIL_BORCLU_ODEMECollection[0].AV001_TI_BIL_ODEME_DAGILIMCollection.Count == 0)
                        DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepLoad(obj.AV001_TI_BIL_BORCLU_ODEMECollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));
                }

                TList<AV001_TI_BIL_ODEME_DAGILIM> dagilimListesi = new TList<AV001_TI_BIL_ODEME_DAGILIM>();

                foreach (var odeme in obj.AV001_TI_BIL_BORCLU_ODEMECollection)
                {
                    if (odeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Count > 0 && odeme.ODEYEN_CARI_ID == trf.CARI_ID)
                    {
                        foreach (var dagilim in odeme.AV001_TI_BIL_ODEME_DAGILIMCollection)
                        {
                            if (dagilim.DAGILIM_TIPI == 1)
                                dagilimListesi.Add(dagilim);
                        }
                        // dagilimListesi.AddRange(odeme.AV001_TI_BIL_ODEME_DAGILIMCollection);
                    }
                }

                foreach (var dagilim in dagilimListesi)
                {
                    #region Kalemler Ayrıştırılıyor
                    if (true)
                    {
                        if (!sozluk.ContainsKey((MahsupKategori)dagilim.MAHSUP_KATEGORI_ID))
                            sozluk.Add((MahsupKategori)dagilim.MAHSUP_KATEGORI_ID, new List<ParaVeDovizId>());

                        switch ((MahsupKategori)dagilim.MAHSUP_KATEGORI_ID)
                        {
                            case MahsupKategori.Asil_Alacak:
                            case MahsupKategori.Diger:
                                sozluk[MahsupKategori.Asil_Alacak].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));
                                break;

                            case MahsupKategori.Vekalet_Ucreti:
                                sozluk[MahsupKategori.Vekalet_Ucreti].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));
                                break;

                            case MahsupKategori.Harclar:
                                sozluk[MahsupKategori.Harclar].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));

                                break;

                            case MahsupKategori.Tazminatlar:
                                sozluk[MahsupKategori.Tazminatlar].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));

                                break;

                            case MahsupKategori.Masraflar:
                                sozluk[MahsupKategori.Masraflar].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));

                                break;

                            case MahsupKategori.Faizler:
                                sozluk[MahsupKategori.Faizler].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));

                                break;

                            case MahsupKategori.Vergiler:
                                sozluk[MahsupKategori.Vergiler].Add(new ParaVeDovizId(dagilim.TUTAR, dagilim.TUTAR_DOVIZ_ID));
                                break;

                            default:
                                break;
                        }
                    }
                    #endregion
                }

                foreach (var teki in sozluk)
                {
                    #region Toplamlar İçin Dönüyor
                    switch (teki.Key)
                    {
                        case MahsupKategori.Asil_Alacak:
                            this.OdenenAnaPara = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Vekalet_Ucreti:
                            this.OdenenVekaletUcreti = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Harclar:
                            this.OdenenHarclar = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Tazminatlar:
                            this.OdenenKomistonTazminat = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Masraflar:
                            this.OdenenMasraf = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Faizler:
                            this.OdenenFaiz = ParaVeDovizId.Topla(teki.Value);
                            break;

                        case MahsupKategori.Vergiler:
                            this.OdenenGiderVergisi = ParaVeDovizId.Topla(teki.Value);
                            break;

                        default:
                            break;
                    }
                    #endregion
                }
            }

            private void TarafHesabiTutarHesapla(AV001_TI_BIL_FOY_TARAF obj)
            {
                //Tutar - anapara
                this.TutarAnaPara = new ParaVeDovizId(obj.SORUMLU_OLUNAN_MIKTAR, obj.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID);

                //Tutar - faiz
                ParaVeDovizId prISLEMIS_FAIZ = new ParaVeDovizId(obj.ISLEMIS_FAIZ, obj.ISLEMIS_FAIZ_DOVIZ_ID);
                ParaVeDovizId prSONRAKI_FAIZ = new ParaVeDovizId(obj.SONRAKI_FAIZ, obj.SONRAKI_FAIZ_DOVIZ_ID);

                this.TutarFaiz = ParaVeDovizId.Topla(prISLEMIS_FAIZ, prSONRAKI_FAIZ);

                //Tutar - gider vergisi
                ParaVeDovizId prBSMV_TS = new ParaVeDovizId(obj.BSMV_TS, obj.BSMV_TS_DOVIZ_ID);
                ParaVeDovizId prBSMV_TO = new ParaVeDovizId(obj.BSMV_TO, obj.BSMV_TO_DOVIZ_ID);

                this.TutarGiderVergisi = ParaVeDovizId.Topla(prBSMV_TS, prBSMV_TO);

                //Tutar - masraf
                ParaVeDovizId prDIGER_GIDERLER = new ParaVeDovizId(obj.DIGER_GIDERLER, obj.DIGER_GIDERLER_DOVIZ_ID);
                ParaVeDovizId prDAVA_GIDERLERI = new ParaVeDovizId(obj.DAVA_GIDERLERI, obj.DAVA_GIDERLERI_DOVIZ_ID);
                ParaVeDovizId prTD_GIDERI = new ParaVeDovizId(obj.TD_GIDERI, obj.TD_GIDERI_DOVIZ_ID);
                ParaVeDovizId prTD_TEBLIG_GIDERI = new ParaVeDovizId(obj.TD_TEBLIG_GIDERI, obj.TD_TEBLIG_GIDERI_DOVIZ_ID);

                this.TutarMasraf = ParaVeDovizId.Topla(prDIGER_GIDERLER, prDAVA_GIDERLERI, prTD_GIDERI, prTD_TEBLIG_GIDERI);

                //kalan - harçlar
                ParaVeDovizId prBASVURMA_HARCI = new ParaVeDovizId(obj.BASVURMA_HARCI, obj.BASVURMA_HARCI_DOVIZ_ID);
                ParaVeDovizId prPESIN_HARC = new ParaVeDovizId(obj.PESIN_HARC, obj.PESIN_HARC_DOVIZ_ID);
                ParaVeDovizId prIFLAS_BASVURMA_HARCI = new ParaVeDovizId(obj.IFLAS_BASVURMA_HARCI, obj.IFLAS_BASVURMA_HARCI_DOVIZ_ID);
                ParaVeDovizId prIFLASIN_ACILMASI_HARCI = new ParaVeDovizId(obj.IFLASIN_ACILMASI_HARCI, obj.IFLASIN_ACILMASI_HARCI_DOVIZ_ID);
                ParaVeDovizId prVEKALET_HARCI = new ParaVeDovizId(obj.VEKALET_HARCI, obj.VEKALET_HARCI_DOVIZ_ID);
                ParaVeDovizId prDIGER_HARC = new ParaVeDovizId(obj.DIGER_HARC, obj.DIGER_HARC_DOVIZ_ID);
                ParaVeDovizId prTD_BAKIYE_HARC = new ParaVeDovizId(obj.TD_BAKIYE_HARC, obj.TD_BAKIYE_HARC_DOVIZ_ID);
                ParaVeDovizId prPAYLASMA_HARCI = new ParaVeDovizId(obj.PAYLASMA_HARCI, obj.PAYLASMA_HARCI_DOVIZ_ID);
                ParaVeDovizId prMASAYA_KATILMA_HARCI = new ParaVeDovizId(obj.MASAYA_KATILMA_HARCI, obj.MASAYA_KATILMA_HARCI_DOVIZ_ID);
                ParaVeDovizId prODENEN_TAHSIL_HARCI = new ParaVeDovizId(obj.ODENEN_TAHSIL_HARCI, obj.ODENEN_TAHSIL_HARCI_DOVIZ_ID);
                ParaVeDovizId prVEKALET_PULU = new ParaVeDovizId(obj.VEKALET_PULU, obj.VEKALET_PULU_DOVIZ_ID);

                this.TutarHarclar = ParaVeDovizId.Topla(prPESIN_HARC, prDIGER_HARC, prTD_BAKIYE_HARC, prODENEN_TAHSIL_HARCI, prVEKALET_PULU,
                                              prPAYLASMA_HARCI, prMASAYA_KATILMA_HARCI, prBASVURMA_HARCI, prIFLAS_BASVURMA_HARCI,
                                              prIFLASIN_ACILMASI_HARCI, prVEKALET_HARCI);

                //Kalan Tahsil Harcı Hesaba dahil ise ekleme yapıyoruz
                if (obj.BAKIYE_HARC_TOPLAMA_EKLE)
                {
                    ParaVeDovizId prKALAN_TAHSIL_HARCI = new ParaVeDovizId(obj.KALAN_TAHSIL_HARCI, obj.KALAN_TAHSIL_HARCI_DOVIZ_ID);

                    this.TutarHarclar = ParaVeDovizId.Topla(this.TutarHarclar, prKALAN_TAHSIL_HARCI);
                }

                //Tutar - komisyon tazminat vs.
                ParaVeDovizId prCEK_KOMISYONU = new ParaVeDovizId(obj.CEK_KOMISYONU, obj.CEK_KOMISYONU_DOVIZ_ID);
                ParaVeDovizId prKARSILIKSIZ_CEK_TAZMINATI = new ParaVeDovizId(obj.KARSILIKSIZ_CEK_TAZMINATI, obj.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID);

                this.TutarKomistonTazminat = ParaVeDovizId.Topla(prCEK_KOMISYONU, prKARSILIKSIZ_CEK_TAZMINATI);

                ////Tutar - banka alacağından
                //ParaVeDovizId prALACAK_TOPLAMI = new ParaVeDovizId(obj.ALACAK_TOPLAMI, obj.ALACAK_TOPLAMI_DOVIZ_ID);
                ////üstekinden çıkıcak
                ParaVeDovizId prTS_VEKALET_TOPLAMI = new ParaVeDovizId(obj.TS_VEKALET_TOPLAMI, obj.TS_VEKALET_TOPLAMI_DOVIZ_ID);

                //this.TutarBankaAlacagindanKaln = ParaVeDovizId.Topla(TutarKomistonTazminat, ParaVeDovizId.Cikart(prALACAK_TOPLAMI, prTS_VEKALET_TOPLAMI));

                //Tutar - vekalet ücreti
                this.TutarVekaletUcreti = prTS_VEKALET_TOPLAMI;

                //Tutar - kalan
                this.TutarKalan = ParaVeDovizId.Topla(this.TutarKomistonTazminat, this.TutarFaiz, this.TutarAnaPara, this.TutarHarclar,
                                                        this.TutarMasraf, this.TutarVekaletUcreti, this.TutarGiderVergisi); ;

                //Banka Alacağından Kalan
                this.TutarBankaAlacagindanKaln = ParaVeDovizId.Cikart(this.TutarKalan, this.TutarVekaletUcreti);
            }

            private void TarafHesabiTutarHesapla(AV001_TDIE_BIL_PROJE_TARAF_HESAP obj)
            {
                //Tutar - anapara
                this.TutarAnaPara = new ParaVeDovizId(obj.SORUMLU_OLUNAN_MIKTAR, obj.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID);

                //Tutar - faiz
                ParaVeDovizId prISLEMIS_FAIZ = new ParaVeDovizId(obj.ISLEMIS_FAIZ, obj.ISLEMIS_FAIZ_DOVIZ_ID);
                ParaVeDovizId prSONRAKI_FAIZ = new ParaVeDovizId(obj.SONRAKI_FAIZ, obj.SONRAKI_FAIZ_DOVIZ_ID);

                this.TutarFaiz = ParaVeDovizId.Topla(prISLEMIS_FAIZ, prSONRAKI_FAIZ);

                //Tutar - gider vergisi
                ParaVeDovizId prBSMV_TS = new ParaVeDovizId(obj.BSMV_TS, obj.BSMV_TS_DOVIZ_ID);
                ParaVeDovizId prBSMV_TO = new ParaVeDovizId(obj.BSMV_TO, obj.BSMV_TO_DOVIZ_ID);

                this.TutarGiderVergisi = ParaVeDovizId.Topla(prBSMV_TS, prBSMV_TO);

                //Tutar - masraf
                ParaVeDovizId prDIGER_GIDERLER = new ParaVeDovizId(obj.DIGER_GIDERLER, obj.DIGER_GIDERLER_DOVIZ_ID);
                ParaVeDovizId prDAVA_GIDERLERI = new ParaVeDovizId(obj.DAVA_GIDERLERI, obj.DAVA_GIDERLERI_DOVIZ_ID);
                ParaVeDovizId prTD_GIDERI = new ParaVeDovizId(obj.TD_GIDERI, obj.TD_GIDERI_DOVIZ_ID);
                ParaVeDovizId prTD_TEBLIG_GIDERI = new ParaVeDovizId(obj.TD_TEBLIG_GIDERI, obj.TD_TEBLIG_GIDERI_DOVIZ_ID);

                this.TutarMasraf = ParaVeDovizId.Topla(prDIGER_GIDERLER, prDAVA_GIDERLERI, prTD_GIDERI, prTD_TEBLIG_GIDERI);

                //kalan - harçlar
                ParaVeDovizId prBASVURMA_HARCI = new ParaVeDovizId(obj.BASVURMA_HARCI, obj.BASVURMA_HARCI_DOVIZ_ID);
                ParaVeDovizId prPESIN_HARC = new ParaVeDovizId(obj.PESIN_HARC, obj.PESIN_HARC_DOVIZ_ID);
                ParaVeDovizId prIFLAS_BASVURMA_HARCI = new ParaVeDovizId(obj.IFLAS_BASVURMA_HARCI, obj.IFLAS_BASVURMA_HARCI_DOVIZ_ID);
                ParaVeDovizId prIFLASIN_ACILMASI_HARCI = new ParaVeDovizId(obj.IFLASIN_ACILMASI_HARCI, obj.IFLASIN_ACILMASI_HARCI_DOVIZ_ID);
                ParaVeDovizId prVEKALET_HARCI = new ParaVeDovizId(obj.VEKALET_HARCI, obj.VEKALET_HARCI_DOVIZ_ID);
                ParaVeDovizId prDIGER_HARC = new ParaVeDovizId(obj.DIGER_HARC, obj.DIGER_HARC_DOVIZ_ID);
                ParaVeDovizId prTD_BAKIYE_HARC = new ParaVeDovizId(obj.TD_BAKIYE_HARC, obj.TD_BAKIYE_HARC_DOVIZ_ID);
                ParaVeDovizId prPAYLASMA_HARCI = new ParaVeDovizId(obj.PAYLASMA_HARCI, obj.PAYLASMA_HARCI_DOVIZ_ID);
                ParaVeDovizId prMASAYA_KATILMA_HARCI = new ParaVeDovizId(obj.MASAYA_KATILMA_HARCI, obj.MASAYA_KATILMA_HARCI_DOVIZ_ID);
                ParaVeDovizId prODENEN_TAHSIL_HARCI = new ParaVeDovizId(obj.ODENEN_TAHSIL_HARCI, obj.ODENEN_TAHSIL_HARCI_DOVIZ_ID);
                ParaVeDovizId prVEKALET_PULU = new ParaVeDovizId(obj.VEKALET_PULU, obj.VEKALET_PULU_DOVIZ_ID);

                this.TutarHarclar = ParaVeDovizId.Topla(prPESIN_HARC, prDIGER_HARC, prTD_BAKIYE_HARC, prODENEN_TAHSIL_HARCI, prVEKALET_PULU,
                                              prPAYLASMA_HARCI, prMASAYA_KATILMA_HARCI, prBASVURMA_HARCI, prIFLAS_BASVURMA_HARCI,
                                              prIFLASIN_ACILMASI_HARCI, prVEKALET_HARCI);

                //Kalan Tahsil Harcı Hesaba dahil ise ekleme yapıyoruz
                if (obj.BAKIYE_HARC_TOPLAMA_EKLE ?? false)
                {
                    ParaVeDovizId prKALAN_TAHSIL_HARCI = new ParaVeDovizId(obj.KALAN_TAHSIL_HARCI, obj.KALAN_TAHSIL_HARCI_DOVIZ_ID);

                    this.TutarHarclar = ParaVeDovizId.Topla(this.TutarHarclar, prKALAN_TAHSIL_HARCI);
                }

                //Tutar - komisyon tazminat vs.
                ParaVeDovizId prCEK_KOMISYONU = new ParaVeDovizId(obj.CEK_KOMISYONU, obj.CEK_KOMISYONU_DOVIZ_ID);
                ParaVeDovizId prKARSILIKSIZ_CEK_TAZMINATI = new ParaVeDovizId(obj.KARSILIKSIZ_CEK_TAZMINATI, obj.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID);

                this.TutarKomistonTazminat = ParaVeDovizId.Topla(prCEK_KOMISYONU, prKARSILIKSIZ_CEK_TAZMINATI);

                ////Tutar - banka alacağından
                //ParaVeDovizId prALACAK_TOPLAMI = new ParaVeDovizId(obj.ALACAK_TOPLAMI, obj.ALACAK_TOPLAMI_DOVIZ_ID);
                ////üstekinden çıkıcak
                ParaVeDovizId prTS_VEKALET_TOPLAMI = new ParaVeDovizId(obj.TS_VEKALET_TOPLAMI, obj.TS_VEKALET_TOPLAMI_DOVIZ_ID);

                //this.TutarBankaAlacagindanKaln = ParaVeDovizId.Topla(TutarKomistonTazminat, ParaVeDovizId.Cikart(prALACAK_TOPLAMI, prTS_VEKALET_TOPLAMI));

                //Tutar - vekalet ücreti
                this.TutarVekaletUcreti = prTS_VEKALET_TOPLAMI;

                //Tutar - kalan
                this.TutarKalan = ParaVeDovizId.Topla(this.TutarKomistonTazminat, this.TutarFaiz, this.TutarAnaPara, this.TutarHarclar,
                                                        this.TutarMasraf, this.TutarVekaletUcreti, this.TutarGiderVergisi); ;

                //Banka Alacağından Kalan
                this.TutarBankaAlacagindanKaln = ParaVeDovizId.Cikart(this.TutarKalan, this.TutarVekaletUcreti);
            }

            #endregion

            #region Alt Toplamlar ve Kalan Hesabı
            #endregion
        }

        public class SimilasyonHesapCetveli
        {
            /// <summary>
            /// Değer Değişiklerini Yakalayıp Toplam Alanlarını güncelliyor,
            /// AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI.ColumnChanged  eventi  yakalanmalıdır
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public static void EventMethod_ColumnChanged(object sender, AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELIEventArgs e)
            {
                switch (e.Column)
                {
                    case AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELIColumn.ALACAK_TOPLAMI:
                    case AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELIColumn.ALACAK_TOPLAMI_DOVIZ_ID:
                    case AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELIColumn.KALAN:
                    case AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELIColumn.KALAN_DOVIZ_ID:
                    case AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELIColumn.TUM_MASRAF_TOPLAMI:
                    case AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELIColumn.TUM_MASRAF_TOPLAMI_DOVIZ_ID:
                    case AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELIColumn.TUM_VEKALET_TOPLAMI:
                    case AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELIColumn.TUM_VEKALET_TOPLAMI_DOVIZ_ID:
                    case AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELIColumn.TAKIP_CIKISI:
                    case AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELIColumn.TAKIP_CIKISI_DOVIZ_ID:
                        break;

                    default:
                        HesapAraclari.SimilasyonHesapCetveli.SetFoyAlanlariHesapla(sender as AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI);

                        break;
                }
            }

            /// <summary>
            /// AV001_TI_BIL_FOY Nesnesini AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI Tipinde Geri döndürür;
            /// (Uyuşan Alanları Eşitler)
            /// </summary>
            /// <param name="foy"></param>
            /// <returns></returns>
            public static AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI GetSimilasyonCetveliByFoy(AV001_TI_BIL_FOY foy)
            {
                if (foy == null)
                    return null;
                AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI ctv = new AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI();

                ctv.ALACAK_TOPLAMI = foy.ALACAK_TOPLAMI;
                ctv.ALACAK_TOPLAMI_DOVIZ_ID = foy.ALACAK_TOPLAMI_DOVIZ_ID;
                ctv.ASIL_ALACAK = foy.ASIL_ALACAK;
                ctv.ASIL_ALACAK_DOVIZ_ID = foy.ASIL_ALACAK_DOVIZ_ID;
                ctv.BASVURMA_HARCI = foy.BASVURMA_HARCI;
                ctv.BASVURMA_HARCI_DOVIZ_ID = foy.BASVURMA_HARCI_DOVIZ_ID;
                ctv.BIR_YIL_KAC_GUN = foy.BIR_YIL_KAC_GUN;
                ctv.BIRIKMIS_NAFAKA = foy.BIRIKMIS_NAFAKA;
                ctv.BIRIKMIS_NAFAKA_DOVIZ_ID = foy.BIRIKMIS_NAFAKA_DOVIZ_ID;
                ctv.BSMV_TO = foy.BSMV_TO;
                ctv.BSMV_TO_DOVIZ_ID = foy.BSMV_TO_DOVIZ_ID;
                ctv.BSMV_TS = foy.BSMV_TS;
                ctv.BSMV_TS_DOVIZ_ID = foy.BSMV_TS_DOVIZ_ID;
                ctv.CEK_KOMISYONU = foy.CEK_KOMISYONU;
                ctv.CEK_KOMISYONU_DOVIZ_ID = foy.CEK_KOMISYONU_DOVIZ_ID;
                ctv.DAVA_GIDERLERI = foy.DAVA_GIDERLERI;
                ctv.DAVA_GIDERLERI_DOVIZ_ID = foy.DAVA_GIDERLERI_DOVIZ_ID;
                ctv.DAVA_INKAR_TAZMINATI = foy.DAVA_INKAR_TAZMINATI;
                ctv.DAVA_INKAR_TAZMINATI_DOVIZ_ID = foy.DAVA_INKAR_TAZMINATI_DOVIZ_ID;
                ctv.DAVA_VEKALET_UCRETI = foy.DAVA_VEKALET_UCRETI;
                ctv.DAVA_VEKALET_UCRETI_DOVIZ_ID = foy.DAVA_VEKALET_UCRETI_DOVIZ_ID;
                ctv.DIGER_GIDERLER = foy.DIGER_GIDERLER;
                ctv.DIGER_GIDERLER_DOVIZ_ID = foy.DIGER_GIDERLER_DOVIZ_ID;
                ctv.DIGER_HARC = foy.DIGER_HARC;
                ctv.DIGER_HARC_DOVIZ_ID = foy.DIGER_HARC_DOVIZ_ID;
                ctv.FAIZ_BASLANGIC_TARIHI = foy.FAIZ_BASLANGIC_TARIHI;
                ctv.FERAGAT_TOPLAMI = foy.FERAGAT_TOPLAMI;
                ctv.FERAGAT_TOPLAMI_DOVIZ_ID = foy.FERAGAT_TOPLAMI_DOVIZ_ID;
                ctv.HESAPLAMA_TIPI = foy.HESAPLAMA_TIPI;
                ctv.ICRA_INKAR_TAZMINATI_DOVIZ_ID = foy.ICRA_INKAR_TAZMINATI_DOVIZ_ID;
                ctv.IH_GIDERI = foy.IH_GIDERI;
                ctv.IH_GIDERI_DOVIZ_ID = foy.IH_GIDERI_DOVIZ_ID;
                ctv.IH_VEKALET_UCRETI = foy.IH_VEKALET_UCRETI;
                ctv.IH_VEKALET_UCRETI_DOVIZ_ID = foy.IH_VEKALET_UCRETI_DOVIZ_ID;
                ctv.IHTAR_GIDERI = foy.IHTAR_GIDERI;
                ctv.IHTAR_GIDERI_DOVIZ_ID = foy.IHTAR_GIDERI_DOVIZ_ID;
                ctv.ILAM_BK_YARG_ONAMA = foy.ILAM_BK_YARG_ONAMA;
                ctv.ILAM_BK_YARG_ONAMA_DOVIZ_ID = foy.ILAM_BK_YARG_ONAMA_DOVIZ_ID;
                ctv.ILAM_INKAR_TAZMINATI = foy.ILAM_INKAR_TAZMINATI;
                ctv.ILAM_INKAR_TAZMINATI_DOVIZ_ID = foy.ILAM_INKAR_TAZMINATI_DOVIZ_ID;
                ctv.ILAM_TEBLIG_GIDERI = foy.ILAM_TEBLIG_GIDERI;
                ctv.ILAM_TEBLIG_GIDERI_DOVIZ_ID = foy.ILAM_TEBLIG_GIDERI_DOVIZ_ID;
                ctv.ILAM_VEK_UCR = foy.ILAM_VEK_UCR;
                ctv.ILAM_VEK_UCR_DOVIZ_ID = foy.ILAM_VEK_UCR_DOVIZ_ID;
                ctv.ILAM_YARGILAMA_GIDERI = foy.ILAM_YARGILAMA_GIDERI;
                ctv.ILAM_YARGILAMA_GIDERI_DOVIZ_ID = foy.ILAM_YARGILAMA_GIDERI_DOVIZ_ID;
                ctv.ILK_GIDERLER = foy.ILK_GIDERLER;
                ctv.ILK_GIDERLER_DOVIZ_ID = foy.ILK_GIDERLER_DOVIZ_ID;
                ctv.ILK_TEBLIGAT_GIDERI = foy.ILK_TEBLIGAT_GIDERI;
                ctv.ILK_TEBLIGAT_GIDERI_DOVIZ_ID = foy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID;
                ctv.IS_SOZLESME_ID = foy.IS_SOZLESME_ID;
                ctv.ISLEMIS_FAIZ = foy.ISLEMIS_FAIZ;
                ctv.ISLEMIS_FAIZ_DOVIZ_ID = foy.ISLEMIS_FAIZ_DOVIZ_ID;
                ctv.IT_HACIZDE_ODENEN = foy.IT_HACIZDE_ODENEN;
                ctv.IT_HACIZDE_ODENEN_DOVIZ_ID = foy.IT_HACIZDE_ODENEN_DOVIZ_ID;
                ctv.KALAN = foy.KALAN;
                ctv.KALAN_DOVIZ_ID = foy.KALAN_DOVIZ_ID;
                ctv.KALAN_TAHSIL_HARCI = foy.KALAN_TAHSIL_HARCI;
                ctv.KALAN_TAHSIL_HARCI_DOVIZ_ID = foy.KALAN_TAHSIL_HARCI_DOVIZ_ID;
                ctv.KARSILIKSIZ_CEK_TAZMINATI = foy.KARSILIKSIZ_CEK_TAZMINATI;
                ctv.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = foy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID;
                ctv.KDV_TO = foy.KDV_TO;
                ctv.KDV_TO_DOVIZ_ID = foy.KDV_TO_DOVIZ_ID;
                ctv.KDV_TS = foy.KDV_TS;
                ctv.KDV_TS_DOVIZ_ID = foy.KDV_TS_DOVIZ_ID;
                ctv.KKDV_TO = foy.KKDV_TO;
                ctv.KKDV_TO_DOVIZ_ID = foy.KKDV_TO_DOVIZ_ID;
                ctv.KO_IH_GIDERI = foy.KO_IH_GIDERI;
                ctv.KO_IH_VEKALET_UCRETI = foy.KO_IH_VEKALET_UCRETI;
                ctv.KO_ILAM_BK_YARG_ONAMA = foy.KO_ILAM_BK_YARG_ONAMA;
                ctv.KO_ILAM_INKAR_TAZMINATI = foy.KO_ILAM_INKAR_TAZMINATI;
                ctv.KO_ILAM_TEBLIG_GIDERI = foy.KO_ILAM_TEBLIG_GIDERI;
                ctv.KO_ILAM_TOPLAM = foy.KO_ILAM_TOPLAM;
                ctv.KO_ILAM_TOPLAM_DOVIZ_ID = foy.KO_ILAM_TOPLAM_DOVIZ_ID;
                ctv.KO_ILAM_VEK_UCR = foy.KO_ILAM_VEK_UCR;
                ctv.KO_ILAM_YARGILAMA_GIDERI = foy.KO_ILAM_YARGILAMA_GIDERI;
                ctv.KO_ISLEMIS_FAIZ = foy.KO_ISLEMIS_FAIZ;
                ctv.KO_OZEL_TUTAR1 = foy.KO_OZEL_TUTAR1;
                ctv.KO_OZEL_TUTAR2 = foy.KO_OZEL_TUTAR2;
                ctv.KO_OZEL_TUTAR3 = foy.KO_OZEL_TUTAR3;
                ctv.MAHSUP_TOPLAMI = foy.MAHSUP_TOPLAMI;
                ctv.MAHSUP_TOPLAMI_DOVIZ_ID = foy.MAHSUP_TOPLAMI_DOVIZ_ID;
                ctv.MASAYA_KATILMA_HARCI = foy.MASAYA_KATILMA_HARCI;
                ctv.MASAYA_KATILMA_HARCI_DOVIZ_ID = foy.MASAYA_KATILMA_HARCI_DOVIZ_ID;
                ctv.ODEME_TOPLAMI = foy.ODEME_TOPLAMI;
                ctv.ODEME_TOPLAMI_DOVIZ_ID = foy.ODEME_TOPLAMI_DOVIZ_ID;
                ctv.ODENEN_TAHSIL_HARCI = foy.ODENEN_TAHSIL_HARCI;
                ctv.ODENEN_TAHSIL_HARCI_DOVIZ_ID = foy.ODENEN_TAHSIL_HARCI_DOVIZ_ID;
                ctv.OIV_TO = foy.OIV_TO;
                ctv.OIV_TO_DOVIZ_ID = foy.OIV_TO_DOVIZ_ID;
                ctv.OIV_TS = foy.OIV_TS;
                ctv.OIV_TS_DOVIZ_ID = foy.OIV_TS_DOVIZ_ID;
                ctv.OZEL_TAZMINAT = foy.OZEL_TAZMINAT;
                ctv.OZEL_TAZMINAT_DOVIZ_ID = foy.OZEL_TAZMINAT_DOVIZ_ID;
                ctv.OZEL_TAZMINAT_FAIZ_ORANI = foy.OZEL_TAZMINAT_FAIZ_ORANI;
                ctv.OZEL_TUTAR1 = foy.OZEL_TUTAR1;
                ctv.OZEL_TUTAR1_BAKIYE = foy.OZEL_TUTAR1_BAKIYE;
                ctv.OZEL_TUTAR1_DOVIZ_ID = foy.OZEL_TUTAR1_DOVIZ_ID;
                ctv.OZEL_TUTAR1_FAIZ_ISLESINMI = foy.OZEL_TUTAR1_FAIZ_ISLESINMI;
                ctv.OZEL_TUTAR2 = foy.OZEL_TUTAR2;
                ctv.OZEL_TUTAR2_BAKIYE = foy.OZEL_TUTAR2_BAKIYE;
                ctv.OZEL_TUTAR2_DOVIZ_ID = foy.OZEL_TUTAR2_DOVIZ_ID;
                ctv.OZEL_TUTAR3 = foy.OZEL_TUTAR3;
                ctv.OZEL_TUTAR3_BAKIYE = foy.OZEL_TUTAR3_BAKIYE;
                ctv.OZEL_TUTAR3_DOVIZ_ID = foy.OZEL_TUTAR3_DOVIZ_ID;
                ctv.PAYLASMA_HARCI = foy.PAYLASMA_HARCI;
                ctv.PAYLASMA_HARCI_DOVIZ_ID = foy.PAYLASMA_HARCI_DOVIZ_ID;
                ctv.PESIN_HARC = foy.PESIN_HARC;
                ctv.PESIN_HARC_DOVIZ_ID = foy.PESIN_HARC_DOVIZ_ID;
                ctv.PROTESTO_GIDERI = foy.PROTESTO_GIDERI;
                ctv.PROTESTO_GIDERI_DOVIZ_ID = foy.PROTESTO_GIDERI_DOVIZ_ID;
                ctv.SON_HESAP_TARIHI = foy.SON_HESAP_TARIHI;
                ctv.SONRAKI_FAIZ = foy.SONRAKI_FAIZ;
                ctv.SONRAKI_FAIZ_DOVIZ_ID = foy.SONRAKI_FAIZ_DOVIZ_ID;
                ctv.SONRAKI_TAZMINAT = foy.SONRAKI_TAZMINAT;
                ctv.SONRAKI_TAZMINAT_DOVIZ_ID = foy.SONRAKI_TAZMINAT_DOVIZ_ID;
                ctv.TAHLIYE_VEK_UCR = foy.TAHLIYE_VEK_UCR;
                ctv.TAHLIYE_VEK_UCR_DOVIZ_ID = foy.TAHLIYE_VEK_UCR_DOVIZ_ID;
                ctv.TAKIP_CIKISI = foy.TAKIP_CIKISI;
                ctv.TAKIP_CIKISI_DOVIZ_ID = foy.TAKIP_CIKISI_DOVIZ_ID;
                ctv.TAKIP_VEKALET_UCRETI = foy.TAKIP_VEKALET_UCRETI;
                ctv.TAKIP_VEKALET_UCRETI_DOVIZ_ID = foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID;
                ctv.TAKIP_VEKALET_UCRETI_KATSAYI = foy.TAKIP_VEKALET_UCRETI_KATSAYI;
                ctv.TD_BAKIYE_HARC = foy.TD_BAKIYE_HARC;
                ctv.TD_BAKIYE_HARC_DOVIZ_ID = foy.TD_BAKIYE_HARC_DOVIZ_ID;
                ctv.TD_GIDERI = foy.TD_GIDERI;
                ctv.TD_GIDERI_DOVIZ_ID = foy.TD_GIDERI_DOVIZ_ID;
                ctv.TD_TEBLIG_GIDERI = foy.TD_TEBLIG_GIDERI;
                ctv.TD_TEBLIG_GIDERI_DOVIZ_ID = foy.TD_TEBLIG_GIDERI_DOVIZ_ID;
                ctv.TD_VEK_UCR = foy.TD_VEK_UCR;
                ctv.TD_VEK_UCR_DOVIZ_ID = foy.TD_VEK_UCR_DOVIZ_ID;
                ctv.TO_ODEME_TOPLAMI = foy.TO_ODEME_TOPLAMI;
                ctv.TO_ODEME_TOPLAMI_DOVIZ_ID = foy.TO_ODEME_TOPLAMI_DOVIZ_ID;
                ctv.VEKALET_SOZLESME_ID = foy.VEKALET_SOZLESME_ID;
                ctv.ICRA_FOY_ID = foy.ID;
                ctv.BAKIYE_HARC_HESABA_DAHIL = foy.BAKIYE_HARC_TOPLAMA_EKLE;
                ctv.FAIZ_TOPLAMI = foy.FAIZ_TOPLAMI;
                ctv.FAIZ_TOPLAMI_DOVIZ_ID = foy.FAIZ_TOPLAMI_DOVIZ_ID;
                return ctv;
            }

            #region Tutar Kalemlerini Toplanma İşlemi

            public static void SetFoyAlanlariHesapla(AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI obj)
            {
                SetTakipOncesiHarclarToplami(obj);
                SetTakipHarcToplamlari(obj);
                SetTakipOncesiOdemeVeMahsupBilgileriToplamlari(obj);
                SetTakipOncesiMasraflar(obj);
                SetIlkGiderlerToplamlari(obj);
                SetTakipSonrasiMasraflarToplami(obj);
                SetMasrafToplamlari(obj);
                SetTakipSonrasiVekaletToplamlari(obj);
                SetTakipCikisi(obj);
                SetAlacakToplami(obj);
                SetFaizToplamlar(obj);

                #region <GKN-20090725>
                //Ne diye kapandı bilinmiyor ama ihtiyaçtan dolayı geri açıldı

                #region <CC-20090623>
                // toplu ödemede kalanı bozduğundan kapatılmıştır
                SetKalanBorc(obj);
                #endregion </CC-20090623>

                #endregion </GKN-20090725>
            }

            /// <summary>
            /// Alacak Toplamını Hesaplıyor
            /// </summary>
            /// <param name="obj"></param>
            private static void SetAlacakToplami(AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI obj)
            {
                ParaVeDovizId prSONRAKI_FAIZ = new ParaVeDovizId(obj.SONRAKI_FAIZ, obj.SONRAKI_FAIZ_DOVIZ_ID);
                ParaVeDovizId prTAKIP_CIKISI = new ParaVeDovizId(obj.TAKIP_CIKISI, obj.TAKIP_CIKISI_DOVIZ_ID);
                ParaVeDovizId prBSMV_TS = new ParaVeDovizId(obj.BSMV_TS, obj.BSMV_TS_DOVIZ_ID);
                ParaVeDovizId prOIV_TS = new ParaVeDovizId(obj.OIV_TS, obj.OIV_TS_DOVIZ_ID);
                ParaVeDovizId prKDV_TS = new ParaVeDovizId(obj.KDV_TS, obj.KDV_TS_DOVIZ_ID);
                ParaVeDovizId prSONRAKI_TAZMINAT = new ParaVeDovizId(obj.SONRAKI_TAZMINAT, obj.SONRAKI_TAZMINAT_DOVIZ_ID);
                ParaVeDovizId prBIRIKMIS_NAFAKA = new ParaVeDovizId(obj.BIRIKMIS_NAFAKA, obj.BIRIKMIS_NAFAKA_DOVIZ_ID);
                ParaVeDovizId prTS_MASRAF_TOPLAMI = new ParaVeDovizId(obj.TS_MASRAF_TOPLAMI, obj.TS_MASRAF_TOPLAMI_DOVIZ_ID);
                ParaVeDovizId prTS_VEKALET_TOPLAMI = new ParaVeDovizId(obj.TS_VEKALET_TOPLAMI, obj.TS_VEKALET_TOPLAMI_DOVIZ_ID);
                ParaVeDovizId prHARC_TOPLAMI = new ParaVeDovizId(obj.HARC_TOPLAMI, obj.HARC_TOPLAMI_DOVIZ_ID);
                ParaVeDovizId prICRA_INKAR_TAZMINATI = new ParaVeDovizId(obj.ICRA_INKAR_TAZMINATI, obj.ICRA_INKAR_TAZMINATI_DOVIZ_ID);
                ParaVeDovizId prDAVA_INKAR_TAZMINATI = new ParaVeDovizId(obj.DAVA_INKAR_TAZMINATI, obj.DAVA_INKAR_TAZMINATI_DOVIZ_ID);

                //Bakiye Harç Hesaba Dahilse Eklenecek
                ParaVeDovizId prKALAN_TAHSIL_HARCI = new ParaVeDovizId(obj.KALAN_TAHSIL_HARCI, obj.KALAN_TAHSIL_HARCI_DOVIZ_ID);

                var liste = new List<ParaVeDovizId>();

                liste.Add(prSONRAKI_FAIZ);
                liste.Add(prTAKIP_CIKISI);
                liste.Add(prBSMV_TS);
                liste.Add(prOIV_TS);
                liste.Add(prKDV_TS);
                liste.Add(prSONRAKI_TAZMINAT);
                liste.Add(prBIRIKMIS_NAFAKA);
                liste.Add(prTS_MASRAF_TOPLAMI);
                liste.Add(prTS_VEKALET_TOPLAMI);
                liste.Add(prHARC_TOPLAMI);
                liste.Add(prICRA_INKAR_TAZMINATI);
                liste.Add(prDAVA_INKAR_TAZMINATI);

                var toplam = ParaVeDovizId.Topla(liste);

                if (obj.BAKIYE_HARC_HESABA_DAHIL.HasValue && obj.BAKIYE_HARC_HESABA_DAHIL.Value)
                {
                    toplam = ParaVeDovizId.Topla(toplam, prKALAN_TAHSIL_HARCI);
                }

                obj.ALACAK_TOPLAMI = toplam.Para;
                obj.ALACAK_TOPLAMI_DOVIZ_ID = toplam.DovizId;
            }

            private static void SetFaizToplamlar(AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI obj)
            {
                var islemisFaiz = new ParaVeDovizId(obj.ISLEMIS_FAIZ, obj.ISLEMIS_FAIZ_DOVIZ_ID);
                var sonrakiFaiz = new ParaVeDovizId(obj.SONRAKI_FAIZ, obj.SONRAKI_FAIZ_DOVIZ_ID);

                var toplam = ParaVeDovizId.Topla(islemisFaiz, sonrakiFaiz);

                obj.FAIZ_TOPLAMI = toplam.Para;
                obj.FAIZ_TOPLAMI_DOVIZ_ID = toplam.DovizId;
            }

            /// <summary>
            /// İlk Gider Toplamları
            /// </summary>
            /// <param name="obj"></param>
            private static void SetIlkGiderlerToplamlari(AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI obj)
            {
                ParaVeDovizId prILK_TEBLIGAT_GIDERI = new ParaVeDovizId(obj.ILK_TEBLIGAT_GIDERI, obj.ILK_TEBLIGAT_GIDERI_DOVIZ_ID);
                ParaVeDovizId prBASVURMA_HARCI = new ParaVeDovizId(obj.BASVURMA_HARCI, obj.BASVURMA_HARCI_DOVIZ_ID);
                ParaVeDovizId prPESIN_HARC = new ParaVeDovizId(obj.PESIN_HARC, obj.PESIN_HARC_DOVIZ_ID);
                ParaVeDovizId prIFLAS_BASVURMA_HARCI = new ParaVeDovizId(obj.IFLAS_BASVURMA_HARCI, obj.IFLAS_BASVURMA_HARCI_DOVIZ_ID);
                ParaVeDovizId prIFLASIN_ACILMASI_HARCI = new ParaVeDovizId(obj.IFLASIN_ACILMASI_HARCI, obj.IFLASIN_ACILMASI_HARCI_DOVIZ_ID);
                ParaVeDovizId prVEKALET_HARCI = new ParaVeDovizId(obj.VEKALET_HARCI, obj.VEKALET_HARCI_DOVIZ_ID);
                ParaVeDovizId prVEKALET_PULU = new ParaVeDovizId(obj.VEKALET_PULU, obj.VEKALET_PULU_DOVIZ_ID);

                var toplam = ParaVeDovizId.Topla(
                    prILK_TEBLIGAT_GIDERI, prBASVURMA_HARCI, prPESIN_HARC,
                    prIFLAS_BASVURMA_HARCI, prIFLASIN_ACILMASI_HARCI, prVEKALET_HARCI,
                    prVEKALET_PULU);

                obj.ILK_GIDERLER = toplam.Para;
                obj.ILK_GIDERLER_DOVIZ_ID = toplam.DovizId;
            }

            /// <summary>
            /// KalanHesaplar
            /// </summary>
            /// <param name="obj"></param>
            private static void SetKalanBorc(AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI obj)
            {
                ParaVeDovizId prFERAGAT_TOPLAMI = new ParaVeDovizId(obj.FERAGAT_TOPLAMI, obj.FERAGAT_TOPLAMI_DOVIZ_ID);
                ParaVeDovizId prODEME_TOPLAMI = new ParaVeDovizId(obj.ODEME_TOPLAMI, obj.ODEME_TOPLAMI_DOVIZ_ID);

                var toplam = ParaVeDovizId.Topla(prFERAGAT_TOPLAMI, prODEME_TOPLAMI);

                if (toplam.YtlHali > 0)
                    toplam = ParaVeDovizId.Cikart(new ParaVeDovizId(obj.ALACAK_TOPLAMI, obj.ALACAK_TOPLAMI_DOVIZ_ID), toplam);
                else
                    toplam = ParaVeDovizId.Topla(new ParaVeDovizId(obj.ALACAK_TOPLAMI, obj.ALACAK_TOPLAMI_DOVIZ_ID), toplam);

                //if (obj.BAKIYE_HARC_HESABA_DAHIL??false)
                //    toplam = ParaVeDovizId.Topla(toplam, new ParaVeDovizId(obj.KALAN_TAHSIL_HARCI, obj.KALAN_TAHSIL_HARCI_DOVIZ_ID));

                obj.KALAN = toplam.Para;
                obj.KALAN_DOVIZ_ID = toplam.DovizId;
            }

            /// <summary>
            /// Masraf Kalemlerini Döviz Toplam Kurallarına Uygun Olarak Toplayıp
            /// TUM_MASRAF_TOPLAMI alanı üzerine yazmaktadır
            /// </summary>
            /// <param name="obj"></param>
            private static void SetMasrafToplamlari(AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI obj)
            {
                ParaVeDovizId prILK_TEBLIGAT_GIDERI = new ParaVeDovizId(obj.ILK_TEBLIGAT_GIDERI, obj.ILK_TEBLIGAT_GIDERI_DOVIZ_ID);
                ParaVeDovizId prBASVURMA_HARCI = new ParaVeDovizId(obj.BASVURMA_HARCI, obj.BASVURMA_HARCI_DOVIZ_ID);
                ParaVeDovizId prPESIN_HARC = new ParaVeDovizId(obj.PESIN_HARC, obj.PESIN_HARC_DOVIZ_ID);
                ParaVeDovizId prIFLAS_BASVURMA_HARCI = new ParaVeDovizId(obj.IFLAS_BASVURMA_HARCI, obj.IFLAS_BASVURMA_HARCI_DOVIZ_ID);
                ParaVeDovizId prIFLASIN_ACILMASI_HARCI = new ParaVeDovizId(obj.IFLASIN_ACILMASI_HARCI, obj.IFLASIN_ACILMASI_HARCI_DOVIZ_ID);
                ParaVeDovizId prVEKALET_HARCI = new ParaVeDovizId(obj.VEKALET_HARCI, obj.VEKALET_HARCI_DOVIZ_ID);
                ParaVeDovizId prVEKALET_PULU = new ParaVeDovizId(obj.VEKALET_PULU, obj.VEKALET_PULU_DOVIZ_ID);
                ParaVeDovizId prTD_GIDERI = new ParaVeDovizId(obj.TD_GIDERI, obj.TD_GIDERI_DOVIZ_ID);
                ParaVeDovizId prTD_TEBLIG_GIDERI = new ParaVeDovizId(obj.TD_TEBLIG_GIDERI, obj.TD_TEBLIG_GIDERI_DOVIZ_ID);
                ParaVeDovizId prDAVA_GIDERLERI = new ParaVeDovizId(obj.DAVA_GIDERLERI, obj.DAVA_GIDERLERI_DOVIZ_ID);
                ParaVeDovizId prDIGER_GIDERLER = new ParaVeDovizId(obj.DIGER_GIDERLER, obj.DIGER_GIDERLER_DOVIZ_ID);
                ParaVeDovizId prODENEN_TAHSIL_HARCI = new ParaVeDovizId(obj.ODENEN_TAHSIL_HARCI, obj.ODENEN_TAHSIL_HARCI_DOVIZ_ID);
                ParaVeDovizId prDIGER_HARC = new ParaVeDovizId(obj.DIGER_HARC, obj.DIGER_HARC_DOVIZ_ID);
                ParaVeDovizId prTD_BAKIYE_HARC = new ParaVeDovizId(obj.TD_BAKIYE_HARC, obj.TD_BAKIYE_HARC_DOVIZ_ID);
                ParaVeDovizId prPAYLASMA_HARCI = new ParaVeDovizId(obj.PAYLASMA_HARCI, obj.PAYLASMA_HARCI_DOVIZ_ID);
                ParaVeDovizId prMASAYA_KATILMA_HARCI = new ParaVeDovizId(obj.MASAYA_KATILMA_HARCI, obj.MASAYA_KATILMA_HARCI_DOVIZ_ID);

                var liste = new List<ParaVeDovizId>();
                liste.Add(prILK_TEBLIGAT_GIDERI);
                liste.Add(prBASVURMA_HARCI);
                liste.Add(prPESIN_HARC);
                liste.Add(prIFLAS_BASVURMA_HARCI);
                liste.Add(prIFLASIN_ACILMASI_HARCI);
                liste.Add(prVEKALET_HARCI);
                liste.Add(prVEKALET_PULU);
                liste.Add(prTD_GIDERI);
                liste.Add(prTD_TEBLIG_GIDERI);
                liste.Add(prDAVA_GIDERLERI);
                liste.Add(prDIGER_GIDERLER);
                liste.Add(prODENEN_TAHSIL_HARCI);
                liste.Add(prDIGER_HARC);
                liste.Add(prTD_BAKIYE_HARC);
                liste.Add(prPAYLASMA_HARCI);
                liste.Add(prMASAYA_KATILMA_HARCI);

                var toplam = ParaVeDovizId.Topla(liste);

                obj.TUM_MASRAF_TOPLAMI = toplam.Para;
                obj.TUM_MASRAF_TOPLAMI_DOVIZ_ID = toplam.DovizId;
            }

            /// <summary>
            /// İlgili Alanları Toplayarak Takip Çıkışını Hesaplar
            ///
            /// </summary>
            /// <param name="obj"></param>
            private static void SetTakipCikisi(AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI obj)
            {
                ParaVeDovizId prISLEMIS_FAIZ = new ParaVeDovizId(obj.ISLEMIS_FAIZ, obj.ISLEMIS_FAIZ_DOVIZ_ID);
                ParaVeDovizId prBSMV_TO = new ParaVeDovizId(obj.BSMV_TO, obj.BSMV_TO_DOVIZ_ID);
                ParaVeDovizId prKKDV_TO = new ParaVeDovizId(obj.KKDV_TO, obj.KKDV_TO_DOVIZ_ID);
                ParaVeDovizId prOIV_TO = new ParaVeDovizId(obj.OIV_TO, obj.OIV_TO_DOVIZ_ID);
                ParaVeDovizId prKDV_TO = new ParaVeDovizId(obj.KDV_TO, obj.KDV_TO_DOVIZ_ID);
                ParaVeDovizId prKARSILIKSIZ_CEK_TAZMINATI = new ParaVeDovizId(obj.KARSILIKSIZ_CEK_TAZMINATI, obj.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID);
                ParaVeDovizId prCEK_KOMISYONU = new ParaVeDovizId(obj.CEK_KOMISYONU, obj.CEK_KOMISYONU_DOVIZ_ID);
                ParaVeDovizId prILAM_VEK_UCR = new ParaVeDovizId(obj.ILAM_VEK_UCR, obj.ILAM_VEK_UCR_DOVIZ_ID);
                ParaVeDovizId prILAM_INKAR_TAZMINATI = new ParaVeDovizId(obj.ILAM_INKAR_TAZMINATI, obj.ILAM_INKAR_TAZMINATI_DOVIZ_ID);
                ParaVeDovizId prILAM_TEBLIG_GIDERI = new ParaVeDovizId(obj.ILAM_TEBLIG_GIDERI, obj.ILAM_TEBLIG_GIDERI_DOVIZ_ID);
                ParaVeDovizId prILAM_BK_YARG_ONAMA = new ParaVeDovizId(obj.ILAM_BK_YARG_ONAMA, obj.ILAM_BK_YARG_ONAMA_DOVIZ_ID);
                ParaVeDovizId prILAM_YARGILAMA_GIDERI = new ParaVeDovizId(obj.ILAM_YARGILAMA_GIDERI, obj.ILAM_YARGILAMA_GIDERI_DOVIZ_ID);
                ParaVeDovizId prIH_GIDERI = new ParaVeDovizId(obj.IH_GIDERI, obj.IH_GIDERI_DOVIZ_ID);
                ParaVeDovizId prIH_VEKALET_UCRETI = new ParaVeDovizId(obj.IH_VEKALET_UCRETI, obj.IH_VEKALET_UCRETI_DOVIZ_ID);
                ParaVeDovizId prIT_GIDERI = new ParaVeDovizId(obj.IT_GIDERI, obj.IT_GIDERI_DOVIZ_ID);
                ParaVeDovizId prIT_VEKALET_UCRETI = new ParaVeDovizId(obj.IT_VEKALET_UCRETI, obj.IT_VEKALET_UCRETI_DOVIZ_ID);
                ParaVeDovizId prTO_MASRAF_TOPLAMI = new ParaVeDovizId(obj.TO_MASRAF_TOPLAMI, obj.TO_MASRAF_TOPLAMI_DOVIZ_ID);
                ParaVeDovizId prTO_ODEME_MAHSUP_TOPLAMI = new ParaVeDovizId(obj.TO_ODEME_MAHSUP_TOPLAMI, obj.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID);
                ParaVeDovizId prASIL_ALACAK = new ParaVeDovizId(obj.ASIL_ALACAK, obj.ASIL_ALACAK_DOVIZ_ID);

                var list = new List<ParaVeDovizId>();

                //list.Add(prTO_ODEME_MAHSUP_TOPLAMI);
                list.Add(prASIL_ALACAK);
                list.Add(prISLEMIS_FAIZ);
                list.Add(prBSMV_TO);
                list.Add(prKKDV_TO);
                list.Add(prOIV_TO);
                list.Add(prKDV_TO);
                list.Add(prKARSILIKSIZ_CEK_TAZMINATI);
                list.Add(prCEK_KOMISYONU);
                list.Add(prILAM_VEK_UCR);
                list.Add(prILAM_INKAR_TAZMINATI);
                list.Add(prILAM_TEBLIG_GIDERI);
                list.Add(prILAM_BK_YARG_ONAMA);
                list.Add(prILAM_YARGILAMA_GIDERI);
                list.Add(prIH_GIDERI);
                list.Add(prIH_VEKALET_UCRETI);
                list.Add(prIT_GIDERI);
                list.Add(prIT_VEKALET_UCRETI);
                list.Add(prTO_MASRAF_TOPLAMI);

                var toplam = ParaVeDovizId.Topla(list);

                if (prTO_ODEME_MAHSUP_TOPLAMI.Para > 0)
                    toplam = ParaVeDovizId.Cikart(toplam, prTO_ODEME_MAHSUP_TOPLAMI);
                else
                    toplam = ParaVeDovizId.Topla(toplam, prTO_ODEME_MAHSUP_TOPLAMI);

                obj.TAKIP_CIKISI = toplam.Para;
                obj.TAKIP_CIKISI_DOVIZ_ID = toplam.DovizId;
            }

            /// <summary>
            /// Takip Harç Toplamları
            /// </summary>
            /// <param name="obj"></param>
            private static void SetTakipHarcToplamlari(AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI obj)
            {
                ParaVeDovizId prODENEN_TAHSIL_HARCI = new ParaVeDovizId(obj.ODENEN_TAHSIL_HARCI, obj.ODENEN_TAHSIL_HARCI_DOVIZ_ID);
                ParaVeDovizId prDIGER_HARC = new ParaVeDovizId(obj.DIGER_HARC, obj.DIGER_HARC_DOVIZ_ID);
                ParaVeDovizId prTD_BAKIYE_HARC = new ParaVeDovizId(obj.TD_BAKIYE_HARC, obj.TD_BAKIYE_HARC_DOVIZ_ID);
                ParaVeDovizId prPAYLASMA_HARCI = new ParaVeDovizId(obj.PAYLASMA_HARCI, obj.PAYLASMA_HARCI_DOVIZ_ID);
                ParaVeDovizId prMASAYA_KATILMA_HARCI = new ParaVeDovizId(obj.MASAYA_KATILMA_HARCI, obj.MASAYA_KATILMA_HARCI_DOVIZ_ID);

                var toplam = ParaVeDovizId.Topla(
                    prODENEN_TAHSIL_HARCI, prDIGER_HARC, prTD_BAKIYE_HARC,
                    prPAYLASMA_HARCI, prMASAYA_KATILMA_HARCI);

                obj.HARC_TOPLAMI = toplam.Para;
                obj.HARC_TOPLAMI_DOVIZ_ID = toplam.DovizId;
            }

            /// <summary>
            /// Takip Öncesi Harçların Toplamı
            /// </summary>
            /// <param name="obj"></param>
            private static void SetTakipOncesiHarclarToplami(AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI obj)
            {
                ParaVeDovizId prIT_HACIZDE_ODENEN = new ParaVeDovizId(obj.IT_HACIZDE_ODENEN, obj.IT_HACIZDE_ODENEN_DOVIZ_ID);
                ParaVeDovizId prMAHSUP_TOPLAMI = new ParaVeDovizId(obj.MAHSUP_TOPLAMI, obj.MAHSUP_TOPLAMI_DOVIZ_ID);
                ParaVeDovizId prTO_ODEME_TOPLAMI = new ParaVeDovizId(obj.TO_ODEME_TOPLAMI, obj.TO_ODEME_TOPLAMI_DOVIZ_ID);

                var toplam = ParaVeDovizId.Topla(prIT_HACIZDE_ODENEN, prMAHSUP_TOPLAMI, prTO_ODEME_TOPLAMI);

                obj.TO_ODEME_MAHSUP_TOPLAMI = toplam.Para;
                obj.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = toplam.DovizId;
            }

            /// <summary>
            /// Takip Öncesi Masraf Kalemlerini Toplar
            /// </summary>
            /// <param name="obj"></param>
            private static void SetTakipOncesiMasraflar(AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI obj)
            {
                ParaVeDovizId prDAMGA_PULU = new ParaVeDovizId(obj.DAMGA_PULU, obj.DAMGA_PULU_DOVIZ_ID);
                ParaVeDovizId prPROTESTO_GIDERI = new ParaVeDovizId(obj.PROTESTO_GIDERI, obj.PROTESTO_GIDERI_DOVIZ_ID);
                ParaVeDovizId prIHTAR_GIDERI = new ParaVeDovizId(obj.IHTAR_GIDERI, obj.IHTAR_GIDERI_DOVIZ_ID);

                var toplam = ParaVeDovizId.Topla(prDAMGA_PULU, prPROTESTO_GIDERI, prIHTAR_GIDERI);

                obj.TO_MASRAF_TOPLAMI = toplam.Para;
                obj.TO_MASRAF_TOPLAMI_DOVIZ_ID = toplam.DovizId;
            }

            /// <summary>
            /// Takip Öncesi Ödeme ve Mahsup Bilgileri Toplamları
            /// </summary>
            /// <param name="obj"></param>
            private static void SetTakipOncesiOdemeVeMahsupBilgileriToplamlari(AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI obj)
            {
                ParaVeDovizId prIT_HACIZDE_ODENEN = new ParaVeDovizId(obj.IT_HACIZDE_ODENEN, obj.IT_HACIZDE_ODENEN_DOVIZ_ID);
                ParaVeDovizId prMAHSUP_TOPLAMI = new ParaVeDovizId(obj.MAHSUP_TOPLAMI, obj.MAHSUP_TOPLAMI_DOVIZ_ID);
                ParaVeDovizId prTO_ODEME_TOPLAMI = new ParaVeDovizId(obj.TO_ODEME_TOPLAMI, obj.TO_ODEME_TOPLAMI_DOVIZ_ID);

                var toplam = ParaVeDovizId.Topla(prIT_HACIZDE_ODENEN, prMAHSUP_TOPLAMI, prTO_ODEME_TOPLAMI);

                ParaVeDovizId prTO_ODEME_MAHSUP_TOPLAMI = new ParaVeDovizId(obj.TO_ODEME_MAHSUP_TOPLAMI, obj.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID);
            }

            /// <summary>
            /// Takip Sonrası Masraf Toplamı
            /// </summary>
            /// <param name="obj"></param>
            private static void SetTakipSonrasiMasraflarToplami(AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI obj)
            {
                ParaVeDovizId prILK_GIDERLER = new ParaVeDovizId(obj.ILK_GIDERLER, obj.ILK_GIDERLER_DOVIZ_ID);
                ParaVeDovizId prTD_GIDERI = new ParaVeDovizId(obj.TD_GIDERI, obj.TD_GIDERI_DOVIZ_ID);
                ParaVeDovizId prTD_TEBLIG_GIDERI = new ParaVeDovizId(obj.TD_TEBLIG_GIDERI, obj.TD_TEBLIG_GIDERI_DOVIZ_ID);
                ParaVeDovizId prDAVA_GIDERLERI = new ParaVeDovizId(obj.DAVA_GIDERLERI, obj.DAVA_GIDERLERI_DOVIZ_ID);
                ParaVeDovizId prDIGER_GIDERLER = new ParaVeDovizId(obj.DIGER_GIDERLER, obj.DIGER_GIDERLER_DOVIZ_ID);

                var toplam = ParaVeDovizId.Topla(
                    prILK_GIDERLER, prTD_GIDERI, prTD_TEBLIG_GIDERI,
                    prDAVA_GIDERLERI, prDIGER_GIDERLER);

                ;

                obj.TS_MASRAF_TOPLAMI = toplam.Para;
                obj.TS_MASRAF_TOPLAMI_DOVIZ_ID = toplam.DovizId;
            }

            /// <summary>
            /// Vekalet Kalemlerini Döviz kurallarına uygun olarak Toplayıp nesne üzerindeki
            /// TS_VEKALET_TOPLAMI alanına yazıyor
            /// </summary>
            /// <param name="obj"></param>
            private static void SetTakipSonrasiVekaletToplamlari(AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI obj)
            {
                ParaVeDovizId prTAKIP_VEKALET_UCRETI = new ParaVeDovizId(obj.TAKIP_VEKALET_UCRETI, obj.TAKIP_VEKALET_UCRETI_DOVIZ_ID);
                ParaVeDovizId prTAHLIYE_VEK_UCR = new ParaVeDovizId(obj.TAHLIYE_VEK_UCR, obj.TAHLIYE_VEK_UCR_DOVIZ_ID);
                ParaVeDovizId prTD_VEK_UCR = new ParaVeDovizId(obj.TD_VEK_UCR, obj.TD_VEK_UCR_DOVIZ_ID);
                ParaVeDovizId prDAVA_VEKALET_UCRETI = new ParaVeDovizId(obj.DAVA_VEKALET_UCRETI, obj.DAVA_VEKALET_UCRETI_DOVIZ_ID);
                //ParaVeDovizId prKALAN_TAHSIL_HARCI = new ParaVeDovizId(obj.KALAN_TAHSIL_HARCI, obj.KALAN_TAHSIL_HARCI_DOVIZ_ID);

                var liste = new List<ParaVeDovizId>();

                liste.Add(prTAKIP_VEKALET_UCRETI);
                liste.Add(prTAHLIYE_VEK_UCR);
                liste.Add(prTD_VEK_UCR);
                liste.Add(prDAVA_VEKALET_UCRETI);
                //liste.Add(prKALAN_TAHSIL_HARCI);

                var toplam = ParaVeDovizId.Topla(liste);

                obj.TS_VEKALET_TOPLAMI = toplam.Para;
                obj.TS_VEKALET_TOPLAMI_DOVIZ_ID = toplam.DovizId;
            }

            #endregion
        }

        public class Tools
        {
            public enum ProsedureList
            {
                spDeleteRow,
                spDeletePreview
            }

            public static bool KayitSil(string tableName, string where)
            {
                SqlConnection con = new SqlConnection(Kimlikci.Kimlik.SirketBilgisi.ConStr);
                SqlCommand cmd = new SqlCommand("spDeleteRows", con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cTableName", tableName);
                    cmd.Parameters.AddWithValue("@cCriteria", where);
                    cmd.Parameters.AddWithValue("@iRowsAffected", 0);
                    cmd.Parameters["@iRowsAffected"].Direction = ParameterDirection.Output;
                    cmd.CommandTimeout = 0;

                    con.Open();
                    cmd.ExecuteReader();
                    con.Close();
                }
                catch (Exception ex)
                {
                    if (con.State != System.Data.ConnectionState.Closed)
                        con.Close();

                    if (ex.Message.Contains("Could not find stored procedure"))
                    {
                        DataRepository.Provider.ExecuteNonQuery(CommandType.Text, Views.Resource1.spDeleteRows);
                        DataRepository.Provider.ExecuteNonQuery(CommandType.Text, Views.Resource1.spDeleteRowsPreview);
                        return KayitSil(tableName, where);
                    }

                    return false;
                }
                return true;
            }

            public static bool ProsedureOlustur(ProsedureList prosedure)
            {
                string st = String.Empty;
                switch (prosedure)
                {
                    case ProsedureList.spDeleteRow:
                        st = Views.Resource1.spDeleteRows;
                        break;

                    case ProsedureList.spDeletePreview:
                        st = Views.Resource1.spDeleteRowsPreview;
                        break;

                    default:
                        break;
                }
                if (st.Length > 0)
                {
                    DataRepository.Provider.ExecuteNonQuery(CommandType.Text, st);
                    return true;
                }
                return false;
            }
        }
    }
}