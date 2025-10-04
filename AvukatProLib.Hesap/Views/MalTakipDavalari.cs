using AvukatProLib2.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace AvukatProLib.Hesap.Views
{
    public class MalTakipDavalari
    {
        public int ADLI_BIRIM_ADLIYE_ID { get; set; }

        public int ADLI_BIRIM_GOREV_ID { get; set; }

        public int ADLI_BIRIM_NO_ID { get; set; }

        public int DAVA_TALEP_ID { get; set; }

        public DateTime DAVA_TARIHI { get; set; }

        public string ESAS_NO { get; set; }

        public string FOY_NO { get; set; }

        public int ID { get; set; }

        public int SUBE_KOD_ID { get; set; }

        public static string[] GetFields()
        {
            string[] dizi = new string[]
            {
                "ID",
                "FOY_NO",
                "ESAS_NO",
                "ADLI_BIRIM_ADLIYE_ID",
                "ADLI_BIRIM_NO_ID",
                "ADLI_BIRIM_GOREV_ID",
                "DAVA_TARIHI",
                "DAVA_TALEP_ID",
                "SUBE_KOD_ID"
            };

            return dizi;
        }

        public static List<MalTakipDavalari> GetMalTakipDavalariByHacizChildId(int hacizChild)
        {
            IDataReader dr;
            try
            {
                dr = DataRepository.Provider.ExecuteReader("_MalTakipDavalariByHacizChildId", hacizChild);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("_MalTakipDavalariByHacizChildId"))
                {
                    DataRepository.Provider.ExecuteNonQuery(CommandType.Text, Views.Resource1._MalTakipDavalariByHacizChildId);
                    return GetMalTakipDavalariByHacizChildId(hacizChild);
                }
                throw ex;
            }
            return GetByReader(dr);
        }

        private static List<MalTakipDavalari> GetByReader(System.Data.IDataReader reader)
        {
            List<MalTakipDavalari> liste = new List<MalTakipDavalari>();
            while (reader.Read())
            {
                var arama = new MalTakipDavalari();

                foreach (var field in GetFields())
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