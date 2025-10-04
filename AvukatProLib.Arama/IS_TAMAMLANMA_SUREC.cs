using System;
using System.Linq;

namespace AvukatProLib.Arama
{
    public partial class AV001_TDI_BIL_IS_TAMAMLANMA_SURE
    {
        private int? _IS_ADLI_BIRIM_ADLIYE;
        private int? _IS_ADLI_BIRIM_GOREV;
        private int? _IS_ADLI_BIRIM_NO;
        private DateTime? _IS_BASLANGIC_TARIHI;
        private DateTime? _IS_BITIS_TARIHI;
        private string _IS_ESAS_NO;
        private string _IS_KATEGORI_ID;
        private int? _IS_KLASOR_ID;
        private string _IS_MUHATABI;
        private DateTime? _IS_ON_GORULEN_BITIS_TARIHI;
        private string _IS_SORUMLU;

        private string _IS_SOZLESME;

        private string _IS_SUREC;

        private string _MADDE_KALEM;

        public int? IS_ADLI_BIRIM_ADLIYE
        {
            get
            {
                if (this.AV001_TDI_BIL_I != null)
                {
                    return _IS_ADLI_BIRIM_ADLIYE = this.AV001_TDI_BIL_I.ADLI_BIRIM_ADLIYE_ID;
                }
                return null;
            }
        }

        public int? IS_ADLI_BIRIM_GOREV
        {
            get
            {
                if (this.AV001_TDI_BIL_I != null)
                {
                    return _IS_ADLI_BIRIM_GOREV = this.AV001_TDI_BIL_I.ADLI_BIRIM_GOREV_ID;
                }
                return null;
            }
        }

        public int? IS_ADLI_BIRIM_NO
        {
            get
            {
                if (this.AV001_TDI_BIL_I != null)
                {
                    return _IS_ADLI_BIRIM_NO = this.AV001_TDI_BIL_I.ADLI_BIRIM_NO_ID;
                }
                return null;
            }
        }

        public DateTime? IS_BASLANGIC_TARIHI
        {
            get
            {
                if (this.AV001_TDI_BIL_I != null)

                    return _IS_BASLANGIC_TARIHI = this.AV001_TDI_BIL_I.BASLANGIC_TARIHI;

                return null;
            }
        }

        public DateTime? IS_BITIS_TARIHI
        {
            get
            {
                if (this.AV001_TDI_BIL_I != null)

                    return _IS_BITIS_TARIHI = this.AV001_TDI_BIL_I.BITIS_TARIHI;

                return null;
            }
        }

        public string IS_DURUM
        {
            get
            {
                if (this.AV001_TDI_BIL_I != null)
                    if (this.AV001_TDI_BIL_I.DURUM == false)
                        return "Tamamlanmadı";
                    else
                        return "Tamalandı";
                return null;
            }
        }

        public string IS_ESAS_NO
        {
            get
            {
                if (this.AV001_TDI_BIL_I != null)
                {
                    return _IS_ESAS_NO = this.AV001_TDI_BIL_I.ESAS_NO;
                }
                return string.Empty;
            }
        }

        public string IS_KATEGORI_ID
        {
            get
            {
                if (this.AV001_TDI_BIL_I != null && this.AV001_TDI_BIL_I.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI != null)

                    return _IS_KATEGORI_ID = this.AV001_TDI_BIL_I.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI.ALT_KATEGORI;

                return null;
            }
        }

        public int? IS_KLASOR_ID
        {
            get
            {
                if (this.AV001_TDI_BIL_I != null)
                {
                    if (this.AV001_TDI_BIL_I.AV001_TDIE_BIL_PROJE_Is.Count > 0)
                        return _IS_KLASOR_ID = this.AV001_TDI_BIL_I.AV001_TDIE_BIL_PROJE_Is.FirstOrDefault().PROJE_ID;
                }
                return null;
            }
        }

        public string SURE_ST
        {
            get
            {
                if (SURE.HasValue)
                {
                    var c = TimeSpan.FromMilliseconds(this.SURE.Value);
                    return string.Format("{0:00}:{1:00}:{2:00}", c.Hours, c.Minutes, c.Seconds);
                }
                return string.Empty;
            }
        }

        public string IS_MUHATABI
        {
            get
            {
                if (this.AV001_TDI_BIL_I != null)
                {
                    if (this.AV001_TDI_BIL_I.AV001_TDI_BIL_IS_TARAFs.Count > 0)
                        try
                        {
                            return _IS_MUHATABI = this.AV001_TDI_BIL_I.AV001_TDI_BIL_IS_TARAFs.Where(v => v.IS_TARAF_ID == 3).FirstOrDefault().AV001_TDI_BIL_CARI.AD;
                        }
                        catch
                        {
                            return string.Empty;
                        }
                }
                return string.Empty;
            }
        }

        public DateTime? IS_ON_GORULEN_BITIS_TARIHI
        {
            get
            {
                if (this.AV001_TDI_BIL_I != null)

                    return _IS_ON_GORULEN_BITIS_TARIHI = this.AV001_TDI_BIL_I.ONGORULEN_BITIS_TARIHI;

                return null;
            }
        }

        public string IS_PLANLAYAN
        {
            get
            {
                if (this.AV001_TDI_BIL_I != null)
                {
                    if (this.AV001_TDI_BIL_I.AV001_TDI_BIL_IS_TARAFs.Count > 0)
                        try
                        {
                            return this.AV001_TDI_BIL_I.AV001_TDI_BIL_IS_TARAFs.Where(v => v.IS_TARAF_ID == 1).FirstOrDefault().AV001_TDI_BIL_CARI.AD;
                        }
                        catch
                        {
                            return string.Empty;
                        }
                }
                return string.Empty;
            }
        }

        public string IS_SORUMLU
        {
            get
            {
                if (this.AV001_TDI_BIL_CARI != null)
                    return _IS_SORUMLU = this.AV001_TDI_BIL_CARI.AD;
                return null;
            }
        }

        public string IS_SOZLESME
        {
            get
            {
                if (this.AV001_TDI_BIL_IS_SOZLESME != null)
                    return _IS_SOZLESME = this.AV001_TDI_BIL_IS_SOZLESME.TDI_KOD_SOZLESME_KATEGORILERI.AD;
                return null;
            }
        }

        public string IS_SUREC
        {
            get
            {
                if (this.AV001_TDI_KOD_IS_SUREC != null)
                    return _IS_SUREC = this.AV001_TDI_KOD_IS_SUREC.IS_SUREC;
                return null;
            }
        }

        public string MADDE_KALEM
        {
            get
            {
                if (this.TDI_KOD_IS_MADDE_KALEM != null)
                    return _MADDE_KALEM = this.TDI_KOD_IS_MADDE_KALEM.MADDE_KALEM;
                return null;
            }
        }
    }
}