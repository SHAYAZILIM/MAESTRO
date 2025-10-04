using System;
using System.Linq;

namespace AvukatProLib.Arama
{
    public partial class AV001_TDI_BIL_TEMSIL
    {
        private string _ADLI_BIRIM_ADLIYE;
        private string _ADLI_BIRIM_GOREV;
        private string _ADLI_BIRIM_NO;
        private string _AVUKAT_CARI;
        private string _EVRAK_SORUMLUSU;
        private string _SONA_ERME_SEBEB;
        private string _TARAF_CARI;
        private string _TEMSIL_SEKLI;

        private DateTime? _TEMSIL_SONA_ERME_TARIHI;

        private string _TEMSIL_TIP;

        private string _TEMSIL_TURU;

        private bool? _TEMSIL_YETKISI_VAR_MI;

        private string _TEMSILE_YETKILI_CARI1;

        private string _TEMSILE_YETKILI_CARI2;

        private string _TEMSILE_YETKILI_CARI3;

        public string ADLI_BIRIM_ADLIYE
        {
            get
            {
                if (this.TDI_KOD_ADLI_BIRIM_ADLIYE != null)
                    return _ADLI_BIRIM_ADLIYE = this.TDI_KOD_ADLI_BIRIM_ADLIYE.ADLIYE;

                return null;
            }
        }

        public string ADLI_BIRIM_GOREV
        {
            get
            {
                if (this.TDI_KOD_ADLI_BIRIM_GOREV != null)
                    return _ADLI_BIRIM_GOREV = this.TDI_KOD_ADLI_BIRIM_GOREV.GOREV;
                return null;
            }
        }

        public string ADLI_BIRIM_NO
        {
            get
            {
                if (this.TDI_KOD_ADLI_BIRIM_NO != null)
                    return _ADLI_BIRIM_NO = this.TDI_KOD_ADLI_BIRIM_NO.NO;
                return null;
            }
        }

        public string AVUKAT_CARI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEMSIL_AVUKATs.Count > 0 && this.AV001_TDI_BIL_TEMSIL_AVUKATs.FirstOrDefault().AV001_TDI_BIL_CARI != null)
                    return _AVUKAT_CARI = this.AV001_TDI_BIL_TEMSIL_AVUKATs.FirstOrDefault().AV001_TDI_BIL_CARI.AD;
                return null;
            }
        }

        public string EVRAK_SORUMLUSU
        {
            get
            {
                if (this.AV001_TDI_BIL_CARI != null)
                    return _EVRAK_SORUMLUSU = this.AV001_TDI_BIL_CARI.AD;
                return null;
            }
        }

        public string SONA_ERME_SEBEB
        {
            get
            {
                if (this.AV001_TDI_BIL_TEMSIL_TARAFs.Count > 0 && this.AV001_TDI_BIL_TEMSIL_TARAFs.FirstOrDefault().TDI_KOD_TEMSIL_SONA_ERME_SEBEP != null)
                    return _SONA_ERME_SEBEB = this.AV001_TDI_BIL_TEMSIL_TARAFs.FirstOrDefault().TDI_KOD_TEMSIL_SONA_ERME_SEBEP.SEBEP;
                return null;
            }
        }

        public string TARAF_CARI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEMSIL_TARAFs.Count > 0 && this.AV001_TDI_BIL_TEMSIL_TARAFs.FirstOrDefault().AV001_TDI_BIL_CARI != null)
                    return _TARAF_CARI = this.AV001_TDI_BIL_TEMSIL_TARAFs.FirstOrDefault().AV001_TDI_BIL_CARI.AD;
                return null;
            }
        }

        public string TEMSIL_SEKLI
        {
            get
            {
                if (this.TDI_KOD_TEMSIL_SEKIL != null)
                    return _TEMSIL_SEKLI = this.TDI_KOD_TEMSIL_SEKIL.TEMSIL_SEKIL;
                return null;
            }
        }

        public DateTime? TEMSIL_SONA_ERME_TARIHI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEMSIL_TARAFs.Count > 0)
                    return _TEMSIL_SONA_ERME_TARIHI = this.AV001_TDI_BIL_TEMSIL_TARAFs.FirstOrDefault().TEMSIL_SONA_ERME_TARIHI;
                return null;
            }
        }

        public string TEMSIL_TIP
        {
            get
            {
                if (this.AV001_TDI_BIL_TEMSIL_TARAFs.Count > 0 && this.AV001_TDI_BIL_TEMSIL_TARAFs.FirstOrDefault().TDI_KOD_TEMSIL_TIP != null)
                    return _TEMSIL_TIP = this.AV001_TDI_BIL_TEMSIL_TARAFs.FirstOrDefault().TDI_KOD_TEMSIL_TIP.TIP;
                return null;
            }
        }

        public string TEMSIL_TURU
        {
            get
            {
                if (this.TDI_KOD_TEMSIL_TUR != null)
                    return _TEMSIL_TURU = this.TDI_KOD_TEMSIL_TUR.TEMSIL_TURU;

                return null;
            }
        }

        public bool? TEMSIL_YETKISI_VAR_MI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEMSIL_TARAFs.Count > 0)
                    return _TEMSIL_YETKISI_VAR_MI = this.AV001_TDI_BIL_TEMSIL_TARAFs.FirstOrDefault().TEMSIL_YETKISI_VAR_MI;
                return null;
            }
        }

        public string TEMSILE_YETKILI_CARI1
        {
            get
            {
                if (this.AV001_TDI_BIL_TEMSIL_TARAFs.Count > 0 && this.AV001_TDI_BIL_TEMSIL_TARAFs.FirstOrDefault().AV001_TDI_BIL_CARI11 != null)
                    return _TEMSILE_YETKILI_CARI1 = this.AV001_TDI_BIL_TEMSIL_TARAFs.FirstOrDefault().AV001_TDI_BIL_CARI11.AD;
                return null;
            }
        }

        public string TEMSILE_YETKILI_CARI2
        {
            get
            {
                if (this.AV001_TDI_BIL_TEMSIL_TARAFs.Count > 0 && this.AV001_TDI_BIL_TEMSIL_TARAFs.FirstOrDefault().AV001_TDI_BIL_CARI12 != null)
                    return _TEMSILE_YETKILI_CARI2 = this.AV001_TDI_BIL_TEMSIL_TARAFs.FirstOrDefault().AV001_TDI_BIL_CARI12.AD;
                return null;
            }
        }

        public string TEMSILE_YETKILI_CARI3
        {
            get
            {
                if (this.AV001_TDI_BIL_TEMSIL_TARAFs.Count > 0 && this.AV001_TDI_BIL_TEMSIL_TARAFs.FirstOrDefault().AV001_TDI_BIL_CARI13 != null)
                    return _TEMSILE_YETKILI_CARI3 = this.AV001_TDI_BIL_TEMSIL_TARAFs.FirstOrDefault().AV001_TDI_BIL_CARI13.AD;
                return null;
            }
        }
    }
}