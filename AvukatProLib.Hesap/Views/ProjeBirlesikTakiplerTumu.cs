using AvukatProLib2.Data;
using System;
using System.Collections.Generic;

namespace AvukatProLib.Hesap.Views
{
    public class ProjeBirlesikTakiplerTumu
    {
        #region properties

        public int? Adliye { get; set; }

        public int? BANKA_ID { get; set; }

        public string Dosya_No { get; set; }

        public int? Durum { get; set; }

        public string Esas_No { get; set; }

        public int? FOY_BIRIM_ID { get; set; }

        public int? FOY_OZEL_DURUM_ID { get; set; }

        public int? FOY_YERI_ID { get; set; }

        public int? Gorev { get; set; }

        public int? ID { get; set; }

        public int? K { get; set; }

        public DateTime? KAYIT_TARIHI { get; set; }

        public string KLASOR_1 { get; set; }

        public string KLASOR_2 { get; set; }

        public int? KONTROL_KIM_ID { get; set; }

        public int? KREDI_GRUP_ID { get; set; }

        public int? KREDI_TIP_ID { get; set; }

        public int? MODUL { get; set; }

        public int? No { get; set; }

        public string Ozel_Kod1 { get; set; }

        public string Ozel_Kod2 { get; set; }

        public string Ozel_Kod3 { get; set; }

        public string Ozel_Kod4 { get; set; }

        public string PROJE_ADI { get; set; }

        public string PROJE_DURUM { get; set; }

        public int? PROJE_ID { get; set; }

        public string PROJE_KOD { get; set; }

        public string Referans1 { get; set; }

        public string Referans2 { get; set; }

        public string Referans3 { get; set; }

        public string SEGMENT { get; set; }

        public string Sifat { get; set; }

        public int? Sorumlu_Adi { get; set; }

        public string SUBE { get; set; }

        public int? SUBE_ID { get; set; }

        public int? SUBE_KOD_ID { get; set; }

        public int SUBE_KODU { get; set; }

        public int? TAHSILAT_DURUM_ID { get; set; }

        public string Takip_Konusu { get; set; }

        public DateTime? Takip_T { get; set; }

        public int? Taraf_Adi { get; set; }

        public string Tipi { get; set; }

        public string YETKILI_CARI_ADI { get; set; }

        public int? YETKILI_CARI_ID { get; set; }

        public bool? YETKILI_MI { get; set; }

        #endregion properties

        #region Methotes

        private static List<ProjeBirlesikTakiplerTumu> liste;

        public static List<ProjeBirlesikTakiplerTumu> GetAll()
        {
            if (liste != null) return liste;
            string sorgu = "SELECT * FROM V_PROJE_BIRLESIK_TAKIPLER_TUMU_TEXT";

            var reader = AvukatProLib2.Data.DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu);

            return GetListByReader(reader);
        }

        public static string[] GetProperty()
        {
            var dizi = new string[]
            {
                "Dosya_No",
                "Adliye",
                "Gorev",
                "No",
                "Esas_No",
                "Takip_T",
                "Referans1",
                "Referans2",
                "Referans3",
                "Ozel_Kod1",
                "Ozel_Kod2",
                "Ozel_Kod3",
                "Ozel_Kod4",
                "Takip_Konusu",
                "Durum",
                "K",
                "Taraf_Adi",
                "Sifat",
                "Sorumlu_Adi",
                "Tipi",
                "ID",
                "BANKA_ID",
                "SUBE_ID",
                "FOY_BIRIM_ID",
                "FOY_YERI_ID",
                "FOY_OZEL_DURUM_ID",
                "TAHSILAT_DURUM_ID",
                "KREDI_GRUP_ID",
                "KREDI_TIP_ID",
                "KLASOR_1",
                "KLASOR_2",
                "SUBE_KODU",
                "KAYIT_TARIHI",
                "SUBE_KOD_ID",
                "KONTROL_KIM_ID",
                "MODUL",
                "PROJE_ID",
                "PROJE_ADI",
                "PROJE_KOD",
                "SEGMENT",
                "YETKILI_MI",
                "YETKILI_CARI_ID",
                "YETKILI_CARI_ADI",
                "SUBE",
                "PROJE_DURUM"
            };

            return dizi;
        }

        private static List<ProjeBirlesikTakiplerTumu> GetListByReader(System.Data.IDataReader result)
        {
            List<ProjeBirlesikTakiplerTumu> liste = new List<ProjeBirlesikTakiplerTumu>();
            //var property = typeof(BorcluTumMal).GetProperties();

            while (result.Read())
            {
                ProjeBirlesikTakiplerTumu mal = new ProjeBirlesikTakiplerTumu();

                foreach (var item in ProjeBirlesikTakiplerTumu.GetProperty())
                {
                    if (result[item] != DBNull.Value)
                        mal.GetType().GetProperty(item).SetValue(mal, result[item], null);
                }

                liste.Add(mal);
            }
            return liste;
        }

        #endregion Methotes

        public static List<ProjeBirlesikTakiplerTumu> GetByTumDosyalardaArama(int? TarafAdi, string DosyaNo, string EsasNo)
        {
            string sorgu = "SELECT * FROM V_PROJE_BIRLESIK_TAKIPLER_TUMU_TEXT";
            string kosul = string.Empty;

            if (TarafAdi.HasValue)
            {
                kosul += string.Format(" Taraf_Adi = {0} ", TarafAdi);
            }
            if (DosyaNo != null && DosyaNo.Length > 0)
            {
                if (DosyaNo.Length > 0)
                {
                    if (kosul.Length > 0)
                        kosul += " AND ";

                    kosul += string.Format(" Dosya_No = '{0}' ", DosyaNo);
                }
            }
            if (EsasNo != null && EsasNo.Length > 0)
            {
                if (EsasNo.Length > 0)
                {
                    if (kosul.Length > 0)
                        kosul += " AND ";

                    kosul += string.Format(" Esas_No = '{0}' ", EsasNo);
                }
            }
            if (kosul.Length > 0)
                kosul = " WHERE " + kosul;
            return GetListByReader(DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, string.Format("{0} {1}", sorgu, kosul)));
        }
    }
}