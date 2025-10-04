using AvukatProLib2.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace AvukatProLib.Hesap.Views
{
    public class HizliArama
    {
        public int? ADLI_BIRIM_ADLIYE_ID { get; set; }

        public int? ADLI_BIRIM_GOREV_ID { get; set; }

        public int? ADLI_BIRIM_NO_ID { get; set; }

        public string ESAS_NO { get; set; }

        public string FOY_NO { get; set; }

        public int ID { get; set; }

        public DateTime? TAKIP_TARIHI { get; set; }

        public string TIPI { get; set; }

        public static List<HizliArama> GetByCariId(int cariId, int subeKodId)
        {
            IDataReader dr;
            try
            {
                dr = DataRepository.Provider.ExecuteReader("_TUM_DOSYALAR_BulCariId_V3", cariId, subeKodId);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("_TUM_DOSYALAR_BulCariId_V3"))
                {
                    DataRepository.Provider.ExecuteNonQuery(CommandType.Text, Views.Resource1.SP_TUM_DOSYALAR_BulCari);
                    return GetByCariId(cariId, subeKodId);
                }
                throw ex;
            }
            return GetByReader(dr);
        }

        public static List<HizliArama> GetByEsasNo(string esasNo, int subeKodId)
        {
            IDataReader dr;
            try
            {
                dr = DataRepository.Provider.ExecuteReader("_TUM_DOSYALAR_BulEsasNo_V2", esasNo, subeKodId);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("_TUM_DOSYALAR_BulEsasNo_V2"))
                {
                    DataRepository.Provider.ExecuteNonQuery(CommandType.Text, Views.Resource1.SP_TUM_DOSYALAR_BulEsasNo);
                    return GetByEsasNo(esasNo, subeKodId);
                }
                throw ex;
            }
            return GetByReader(dr);
        }

        public static List<HizliArama> GetByFoyNo(string foyNo, int subeKodId)
        {
            IDataReader dr;
            try
            {
                dr = DataRepository.Provider.ExecuteReader("_TUM_DOSYALAR_BulFoyNo_v3", foyNo, subeKodId);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("_TUM_DOSYALAR_BulFoyNo_v3"))
                {
                    DataRepository.Provider.ExecuteNonQuery(CommandType.Text, Views.Resource1.SP_TUM_DOSYALAR_BulFoyNo);
                    return GetByFoyNo(foyNo, subeKodId);
                }
                throw ex;
            }
            return GetByReader(dr);
        }

        public static string[] GetProperties()
        {
            return new string[]
            {
                "ID",
                "FOY_NO",
                "ESAS_NO",
                "ADLI_BIRIM_ADLIYE_ID",
                "ADLI_BIRIM_NO_ID",
                "ADLI_BIRIM_GOREV_ID",
                "TAKIP_TARIHI",
                "TIPI"
            };
        }

        private static List<HizliArama> GetByReader(System.Data.IDataReader reader)
        {
            List<HizliArama> liste = new List<HizliArama>();
            while (reader.Read())
            {
                var arama = new HizliArama();

                foreach (var field in HizliArama.GetProperties())
                {
                    var obje = reader[field];
                    if (obje != DBNull.Value)
                        arama.GetType().GetProperty(field).SetValue(arama, obje, null);
                }

                liste.Add(arama);
            }

            return liste;
        }
    }
}