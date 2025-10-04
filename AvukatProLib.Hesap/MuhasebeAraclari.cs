using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Data;

namespace AvukatProLib.Hesap
{
    //aykut muhasebe hesapla butonu otomatik hesapla
    public class MuhasebeAraclari
    {
        public static void SetCariHesapByBorcluOdeme(int borcluOdemeId)
        {
            try
            {
                DataRepository.Provider.ExecuteNonQuery("dbo._AV001_TI_BIL_BORCLU_ODEME_CariHesapOlustur_V3", borcluOdemeId);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("_AV001_TI_BIL_BORCLU_ODEME_CariHesapOlustur_V3"))
                {
                    DataRepository.Provider.ExecuteNonQuery(CommandType.Text, Views.Resource1._AV001_TI_BIL_BORCLU_ODEME_CariHesapOlustur);
                    SetCariHesapByBorcluOdeme(borcluOdemeId);
                    return;
                }
                throw ex;
            }
        }

        public static void SetCariHesapByDavaliBorcluOdeme(int davaliOdemeId)
        {
            try
            {
                DataRepository.Provider.ExecuteNonQuery("dbo.AV001_TD_BIL_BORCLU_ODEME_CariHesapOlustur", davaliOdemeId);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("AV001_TD_BIL_BORCLU_ODEME_CariHesapOlustur"))
                {
                    DataRepository.Provider.ExecuteNonQuery(CommandType.Text, Views.Resource1._AV001_TI_BIL_BORCLU_ODEME_CariHesapOlustur);
                    SetCariHesapByDavaliBorcluOdeme(davaliOdemeId);
                    return;
                }
                throw ex;
            }
        }

        public static void SetCariHesapByFoy(AV001_TI_BIL_FOY foy)
        {
            foreach (var item in foy.AV001_TI_BIL_BORCLU_ODEMECollection)
            {
                MuhasebeAraclari.SetCariHesapByBorcluOdeme(item.ID);
            }
            //masrafavans id 0 hata
            foreach (var item in foy.AV001_TDI_BIL_MASRAF_AVANSCollection)
            {
                if (item.ID != 0)
                    MuhasebeAraclari.SetCariHesapByMasrafAvans(item.ID);
            }
            foreach (var item in foy.AV001_TI_BIL_MUVEKKILE_ODEMECollectionGetByICRA_FOY_ID)
            {
                MuhasebeAraclari.SetCariHesapByMuvekkileOdeme(item.ID);
            }
        }

        public static void SetCariHesapByMasrafAvans(int masrafAvansId)
        {
            try
            {
                DataRepository.Provider.ExecuteNonQuery("dbo._AV001_TDI_BIL_MASRAF_AVANS_CariHesapOlustur_V4", masrafAvansId);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("_AV001_TDI_BIL_MASRAF_AVANS_CariHesapOlustur_V4"))
                {
                    DataRepository.Provider.ExecuteNonQuery(CommandType.Text, Views.Resource1._AV001_TDI_BIL_MASRAF_AVANS_CariHesapOlustur);
                    SetCariHesapByMasrafAvans(masrafAvansId);
                    return;
                }
                //throw ex;
            }
        }

        public static int SetCariHesapByMuhasebe(int muhasebeID, int cariID)
        {
            object[] parameters = new object[2] { muhasebeID, cariID };
            try
            {
                int id = 0;
                id = Convert.ToInt32(DataRepository.Provider.ExecuteScalar("AV001_TDI_BIL_CARI_HESAP_InsertByMuhasebe", parameters));
                return id;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("AV001_TDI_BIL_CARI_HESAP_InsertByMuhasebe"))
                {
                    //DataRepository.Provider.ExecuteNonQuery(CommandType.Text, );
                    SetCariHesapByMuhasebe(muhasebeID, cariID);
                    return 0;
                }
                throw ex;
            }
        }

        public static int SetCariHesapByMuhasebeDetay(int muhasebeID, int muhasebeDetayID, int cariID, decimal birimFiyat, int adet, int muvekkilSayisi)
        {
            object[] parameters = new object[6] { muhasebeID, muhasebeDetayID, cariID, birimFiyat, adet, muvekkilSayisi };

            try
            {
                int id = 0;
                id = Convert.ToInt32(DataRepository.Provider.ExecuteScalar("AV001_TDI_BIL_CARI_HESAP_DETAY_InsertByMuhasebe", parameters));
                return id;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("AV001_TDI_BIL_CARI_HESAP_DETAY_InsertByMuhasebe"))
                {
                    //DataRepository.Provider.ExecuteNonQuery(CommandType.Text, Views.Resource1._AV001_TDI_BIL_MASRAF_AVANS_CariHesapOlustur);
                    SetCariHesapByMuhasebeDetay(muhasebeID, muhasebeDetayID, cariID, birimFiyat, adet, muvekkilSayisi);
                    return 0;
                }
                throw ex;
            }
        }

        public static void SetCariHesapByMuvekkileOdeme(int muvekkileOdemeId)
        {
            try
            {
                DataRepository.Provider.ExecuteNonQuery("dbo._AV001_TI_BIL_MUVEKKILE_ODEME_CariHesapOlustur_V2", muvekkileOdemeId);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("_AV001_TI_BIL_MUVEKKILE_ODEME_CariHesapOlustur_V2"))
                {
                    DataRepository.Provider.ExecuteNonQuery(CommandType.Text, Views.Resource1._AV001_TI_BIL_MUVEKKILE_ODEME_CariHesapOlustur);
                    SetCariHesapByMuvekkileOdeme(muvekkileOdemeId);
                    return;
                }
                throw ex;
            }
        }

        public static void SetFoyMuhasebeByMasrafAvans(int masrafAvansId, int tipId)
        {
            object[] parameters = new object[2] { masrafAvansId, tipId };
            try
            {
                DataRepository.Provider.ExecuteNonQuery("AV001_TDI_BIL_FOY_MUHASEBE_InsertByMasrafAvans", parameters);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("AV001_TDI_BIL_FOY_MUHASEBE_InsertByMasrafAvans"))
                {
                    DataRepository.Provider.ExecuteNonQuery(CommandType.Text, Views.Resource1._AV001_TDI_BIL_MASRAF_AVANS_CariHesapOlustur);
                    SetFoyMuhasebeByMasrafAvans(masrafAvansId, tipId);
                    return;
                }

                throw ex;
            }
        }

        public static void SetFoyMuhasebeDetayByMasrafAvansDetay(int masrafAvansDetayId, int foyMuhasebeId, bool yenidenHesaplanabilir)
        {
            object[] parameters = new object[3] { masrafAvansDetayId, foyMuhasebeId, yenidenHesaplanabilir };
            try
            {
                DataRepository.Provider.ExecuteNonQuery("AV001_TDI_BIL_FOY_MUHASEBE_DETAY_InsertByMasrafAvans", parameters);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("AV001_TDI_BIL_FOY_MUHASEBE_DETAY_InsertByMasrafAvans"))
                {
                    DataRepository.Provider.ExecuteNonQuery(CommandType.Text, Views.Resource1._AV001_TDI_BIL_MASRAF_AVANS_CariHesapOlustur);
                    SetFoyMuhasebeDetayByMasrafAvansDetay(masrafAvansDetayId, foyMuhasebeId, yenidenHesaplanabilir);
                    return;
                }

                throw ex;
            }
        }

        public static void SetMuhasebeVeDetayByDavaBorcluOdeme(int OdemeId)
        {
            try
            {
                DataRepository.Provider.ExecuteNonQuery("AV001_TDI_BIL_FOY_MUHASEBEVeDetay_InsertByDavaBorcluOdeme", OdemeId);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("AV001_TDI_BIL_FOY_MUHASEBEVeDetay_InsertByDavaBorcluOdeme"))
                {
                    DataRepository.Provider.ExecuteNonQuery(CommandType.Text, Views.Resource1._AV001_TI_BIL_MUVEKKILE_ODEME_CariHesapOlustur);
                    SetMuhasebeVeDetayByDavaBorcluOdeme(OdemeId);
                    return;
                }
                throw ex;
            }
        }

        public static void SetMuhasebeVeDetayByIcraBorcluOdeme(int OdemeId)
        {
            try
            {
                DataRepository.Provider.ExecuteNonQuery("AV001_TDI_BIL_FOY_MUHASEBEVeDetay_InsertByIcraBorcluOdeme", OdemeId);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("AV001_TDI_BIL_FOY_MUHASEBEVeDetay_InsertByIcraBorcluOdeme"))
                {
                    DataRepository.Provider.ExecuteNonQuery(CommandType.Text, Views.Resource1._AV001_TI_BIL_MUVEKKILE_ODEME_CariHesapOlustur);
                    SetMuhasebeVeDetayByIcraBorcluOdeme(OdemeId);
                    return;
                }
                throw ex;
            }
        }

        public static void SetMuhasebeVeDetayByMuvekkileOdeme(int OdemeId, int muhasebeHedefTip)
        {
            object[] parameters = new object[2] { OdemeId, muhasebeHedefTip };
            try
            {
                DataRepository.Provider.ExecuteNonQuery("AV001_TDI_BIL_FOY_MUHASEBEVeDetay_InsertByMuvekkileOdeme", parameters);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("AV001_TDI_BIL_FOY_MUHASEBEVeDetay_InsertByMuvekkileOdeme"))
                {
                    DataRepository.Provider.ExecuteNonQuery(CommandType.Text, Views.Resource1._AV001_TI_BIL_MUVEKKILE_ODEME_CariHesapOlustur);
                    SetMuhasebeVeDetayByMuvekkileOdeme(OdemeId, muhasebeHedefTip);
                    return;
                }
                throw ex;
            }
        }
    }
}