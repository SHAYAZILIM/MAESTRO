namespace AvukatProLib.Arama
{
    public partial class AV001_TDI_BIL_GORUSME
    {
        private string _DOSYA_ADLIYE;
        private string _DOSYA_BIRIM_NO;
        private string _DOSYA_NO;
        private string _GORUSEN_SAHIS;
        private string _GORUSULEN_CARI;
        private string _IS_KATEGORISI;

        private string _ISIN_YAPILDIGI_CARI;

        public string DOSYA_ADLIYE
        {
            get
            {
                if (this.ICRA_FOY_ID != null)
                {
                    if (this.AV001_TI_BIL_FOY.TDI_KOD_ADLI_BIRIM_ADLIYE != null)
                        return _DOSYA_ADLIYE = this.AV001_TI_BIL_FOY.TDI_KOD_ADLI_BIRIM_ADLIYE.ADLIYE;
                }
                if (this.DAVA_FOY_ID != null)
                {
                    if (this.AV001_TD_BIL_FOY.TDI_KOD_ADLI_BIRIM_ADLIYE != null)
                        return _DOSYA_ADLIYE = this.AV001_TD_BIL_FOY.TDI_KOD_ADLI_BIRIM_ADLIYE.ADLIYE;
                }
                if (this.HAZIRLIK_ID != null)
                {
                    if (this.AV001_TD_BIL_HAZIRLIK.TDI_KOD_ADLI_BIRIM_ADLIYE != null)
                        return _DOSYA_ADLIYE = this.AV001_TD_BIL_HAZIRLIK.TDI_KOD_ADLI_BIRIM_ADLIYE.ADLIYE;
                }
                return null;
            }
        }

        public string DOSYA_BIRIM_GOREV
        {
            get
            {
                if (this.ICRA_FOY_ID != null)
                {
                    if (this.AV001_TI_BIL_FOY.TDI_KOD_ADLI_BIRIM_GOREV != null)
                        return _DOSYA_BIRIM_NO = this.AV001_TI_BIL_FOY.TDI_KOD_ADLI_BIRIM_GOREV.GOREV;
                }
                if (this.DAVA_FOY_ID != null)
                {
                    if (this.AV001_TD_BIL_FOY.TDI_KOD_ADLI_BIRIM_GOREV != null)
                        return _DOSYA_BIRIM_NO = this.AV001_TD_BIL_FOY.TDI_KOD_ADLI_BIRIM_GOREV.GOREV;
                }
                if (this.HAZIRLIK_ID != null)
                {
                    if (this.AV001_TD_BIL_HAZIRLIK.TDI_KOD_ADLI_BIRIM_NO != null)
                        return _DOSYA_BIRIM_NO = AV001_TD_BIL_HAZIRLIK.TDI_KOD_ADLI_BIRIM_GOREV.GOREV;
                }
                return null;
            }
        }

        public string DOSYA_BIRIM_NO
        {
            get
            {
                if (this.ICRA_FOY_ID != null)
                {
                    if (this.AV001_TI_BIL_FOY.TDI_KOD_ADLI_BIRIM_NO != null)
                        return _DOSYA_BIRIM_NO = this.AV001_TI_BIL_FOY.TDI_KOD_ADLI_BIRIM_NO.NO;
                }
                if (this.DAVA_FOY_ID != null)
                {
                    if (this.AV001_TD_BIL_FOY.TDI_KOD_ADLI_BIRIM_NO != null)
                        return _DOSYA_BIRIM_NO = this.AV001_TD_BIL_FOY.TDI_KOD_ADLI_BIRIM_NO.NO;
                }
                if (this.HAZIRLIK_ID != null)
                {
                    if (this.AV001_TD_BIL_HAZIRLIK.TDI_KOD_ADLI_BIRIM_NO != null)
                        return _DOSYA_BIRIM_NO = AV001_TD_BIL_HAZIRLIK.TDI_KOD_ADLI_BIRIM_NO.NO;
                }
                return null;
            }
        }

        public string DOSYA_NO
        {
            get
            {
                if (this.ICRA_FOY_ID != null)
                {
                    return _DOSYA_NO = this.AV001_TI_BIL_FOY.FOY_NO;
                }
                if (this.DAVA_FOY_ID != null)
                {
                    return _DOSYA_NO = this.AV001_TD_BIL_FOY.FOY_NO;
                }
                if (this.HAZIRLIK_ID != null)
                    return _DOSYA_NO = this.AV001_TD_BIL_HAZIRLIK.HAZIRLIK_NO;

                return null;
            }
        }

        public string GORUSEN_SAHIS
        {
            get
            {
                if (this.AV001_TDI_BIL_CARI != null)
                    return _GORUSEN_SAHIS = this.AV001_TDI_BIL_CARI.AD;

                return null;
            }
        }

        public string GORUSULEN_CARI
        {
            get
            {
                if (this.AV001_TDI_BIL_CARI11 != null)
                    return _GORUSULEN_CARI = this.AV001_TDI_BIL_CARI11.AD;

                return null;
            }
        }

        public string IS_KATEGORISI
        {
            get
            {
                if (this.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI != null)
                    return _IS_KATEGORISI = this.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI.ALT_KATEGORI;

                return null;
            }
        }

        public string ISIN_YAPILDIGI_CARI
        {
            get
            {
                if (this.AV001_TDI_BIL_CARI3 != null)
                    return _ISIN_YAPILDIGI_CARI = this.AV001_TDI_BIL_CARI3.AD;

                return null;
            }
        }
    }
}