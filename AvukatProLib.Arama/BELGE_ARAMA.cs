using System.Linq;

namespace AvukatProLib.Arama
{
    public partial class AV001_TDIE_BIL_BELGE
    {
        private string _ADLIYE;
        private string _ASAMA_ADI;
        private string _BELGE_TARAF;
        private string _BELGE_TURU;
        private string _BELGEYI_YAZAN;

        private string _BURO;

        private string _GOREV;

        private string _KULLANICI;

        private string _NO;

        private string _SIFAT;

        public string ADLIYE
        {
            get
            {
                if (TDI_KOD_ADLI_BIRIM_ADLIYE != null)
                    return _ADLIYE = this.TDI_KOD_ADLI_BIRIM_ADLIYE.ADLIYE;

                return null;
            }
        }

        public string ASAMA_ADI
        {
            get
            {
                if (this.AV001_TDIE_BIL_ASAMAs.Count > 0)
                    return _ASAMA_ADI = this.AV001_TDIE_BIL_ASAMAs[0].TDIE_KOD_ASAMA.ASAMA_ADI;

                return null;
            }
        }

        public string BELGE_TARAF
        {
            get
            {
                if (AV001_TDIE_BIL_BELGE_TARAFs.Count() > 0)
                    return _BELGE_TARAF = this.AV001_TDIE_BIL_BELGE_TARAFs[0].AV001_TDI_BIL_CARI1.AD;

                return null;
            }
        }

        public string BELGE_TURU
        {
            get
            {
                return _BELGE_TURU = this.TDIE_KOD_BELGE_TUR.BELGE_TURU;
            }
        }

        public string BELGEYI_YAZAN
        {
            get
            {
                if (this.AV001_TDI_BIL_CARI1 != null)
                    return _BELGEYI_YAZAN = this.AV001_TDI_BIL_CARI1.AD;
                return string.Empty;
            }
        }

        public string BURO
        {
            get
            {
                return _BURO = this.TDIE_BIL_KULLANICI_SUBELERI.SUBE_ADI;
            }
        }

        public string GOREV
        {
            get
            {
                if (TDI_KOD_ADLI_BIRIM_GOREV != null)
                    return _GOREV = this.TDI_KOD_ADLI_BIRIM_GOREV.GOREV;

                return null;
            }
        }

        public string KULLANICI
        {
            get
            {
                return _KULLANICI = this.TDI_BIL_KULLANICI_LISTESI.KULLANICI_ADI;
            }
        }

        public string NO
        {
            get
            {
                if (TDI_KOD_ADLI_BIRIM_NO != null)
                    return _NO = this.TDI_KOD_ADLI_BIRIM_NO.NO;

                return null;
            }
        }

        public string SIFAT
        {
            get
            {
                if (this.AV001_TDIE_BIL_BELGE_TARAFs.Count > 0)
                    return _SIFAT = this.AV001_TDIE_BIL_BELGE_TARAFs[0].TDIE_KOD_TARAF_SIFAT.SIFAT;

                return null;
            }
        }
    }
}