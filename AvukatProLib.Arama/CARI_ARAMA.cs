namespace AvukatProLib.Arama
{
    public partial class AV001_TDI_BIL_CARI
    {
        private string _ADRES_DURUM;

        private string _ADRES1;

        private string _ADRES2;

        private string _AKTIF_ADRES_SEMT;

        private string _AKTIF_ADRES_TUR;

        private string _AKTIF_ADRES1;

        private string _AKTIF_IL_ADI;

        private string _AKTIF_ILCE_ADI;

        private string _AKTIF_POSTA_KODU;

        private string _AKTIF_ULKE_ADI;

        private string _BAGLI_OLDUGU_YETKILI_CARI;

        private string _BANKA_ADI;

        private string _BANKA_SUBE_ADI;

        private string _CARI_MESLEK;

        private string _DILI;

        private string _FIRMA_TUR;

        private string _IL_ADI1;

        private string _IL_ADI2;

        private string _ILCE_ADI1;

        private string _ILCE_ADI2;

        private string _MEZUN_OLDUGU_OKUL;

        private string _OZEL_KOD1;

        private string _OZEL_KOD2;

        private string _OZEL_KOD3;

        private string _OZEL_KOD4;

        private string _REFERANS_SAHIS;

        private string _SICIL_YERI;

        private string _UNVAN1;

        private string _UNVAN2;

        private string _YETKILI1;

        private string _YETKILI2;

        public string ADRES_DURUM
        {
            get
            {
                if (AV001_TDI_KOD_ADRES_DURUM1 != null)
                    return _ADRES_DURUM = this.AV001_TDI_KOD_ADRES_DURUM1.ADRES_DURUM;
                return null;
            }
        }

        public string ADRES1
        {
            get
            {
                return _ADRES1 = this.ADRES_1 + this.ADRES_2 + this.ADRES_3;
            }
        }

        public string ADRES2
        {
            get
            {
                return _ADRES2 = this.ADRES2_1 + this.ADRES2_2 + this.ADRES2_3;
            }
        }

        public string AKTIF_ADRES_SEMT
        {
            get
            {
                if (this.AKTIF_ADRES)
                    return _AKTIF_ADRES_SEMT = this.TDI_KOD_SEMT.SEMT;
                if (this.AKTIF_ADRES_2)
                    return _AKTIF_ADRES_SEMT = this.TDI_KOD_SEMT1.SEMT;
                if (this.AKTIF_ADRES_3)
                    return _AKTIF_ADRES_SEMT = this.TDI_KOD_SEMT2.SEMT;
                return null;
            }
        }

        public string AKTIF_ADRES_TUR
        {
            get
            {
                if (this.AKTIF_ADRES)
                {
                    if (this.TDI_KOD_ADRES_TUR != null)
                        return _AKTIF_ADRES_TUR = this.TDI_KOD_ADRES_TUR.ADRES_TUR;
                }
                if (this.AKTIF_ADRES_2)
                {
                    if (this.TDI_KOD_ADRES_TUR1 != null)
                        return _AKTIF_ADRES_TUR = this.TDI_KOD_ADRES_TUR1.ADRES_TUR;
                }
                if (this.AKTIF_ADRES_3)
                {
                    if (this.TDI_KOD_ADRES_TUR2 != null)
                        return _AKTIF_ADRES_TUR = this.TDI_KOD_ADRES_TUR2.ADRES_TUR;
                }
                return null;
            }
        }

        public string AKTIF_ADRES1
        {
            get
            {
                if (this.AKTIF_ADRES)
                    return _AKTIF_ADRES1 = this.ADRES_1 + this.ADRES_2 + this.ADRES_3;
                if (this.AKTIF_ADRES_2)
                    return _AKTIF_ADRES1 = this.ADRES2_1 + this.ADRES2_2 + this.ADRES2_3;
                if (this.AKTIF_ADRES_3)
                    return _AKTIF_ADRES1 = this.ADRES3_1 + this.ADRES3_2 + this.ADRES3_3;
                return null;
            }
        }

        public string AKTIF_IL_ADI
        {
            get
            {
                if (this.AKTIF_ADRES)
                {
                    if (this.TDI_KOD_IL != null)
                        return _AKTIF_IL_ADI = this.TDI_KOD_IL.IL;
                }
                if (this.AKTIF_ADRES_2)
                {
                    if (this.TDI_KOD_IL1 != null)
                        return _AKTIF_IL_ADI = this.TDI_KOD_IL1.IL;
                }
                if (this.AKTIF_ADRES_3)
                {
                    if (this.TDI_KOD_IL2 != null)
                        return _AKTIF_IL_ADI = this.TDI_KOD_IL2.IL;
                }
                return null;
            }
        }

        public string AKTIF_ILCE_ADI
        {
            get
            {
                if (this.AKTIF_ADRES)
                {
                    if (this.TDI_KOD_ILCE != null)
                        return _AKTIF_ILCE_ADI = this.TDI_KOD_ILCE.ILCE;
                }
                if (this.AKTIF_ADRES_2)
                {
                    if (this.TDI_KOD_ILCE1 != null)
                        return _AKTIF_ILCE_ADI = this.TDI_KOD_ILCE1.ILCE;
                }
                if (this.AKTIF_ADRES_3)
                {
                    if (this.TDI_KOD_ILCE2 != null)
                        return _AKTIF_ILCE_ADI = this.TDI_KOD_ILCE2.ILCE;
                }

                return null;
            }
        }

        public string AKTIF_POSTA_KODU
        {
            get
            {
                if (this.AKTIF_ADRES)
                    return _AKTIF_POSTA_KODU = this.POSTA_KODU;
                if (this.AKTIF_ADRES_2)
                    return _AKTIF_POSTA_KODU = this.POSTA_KODU2;
                if (this.AKTIF_ADRES_3)
                    return _AKTIF_POSTA_KODU = this.POSTA_KODU3;
                return null;
            }
        }

        public string AKTIF_ULKE_ADI
        {
            get
            {
                if (this.AKTIF_ADRES)
                {
                    if (this.TDI_KOD_ULKE != null)
                        return _AKTIF_ULKE_ADI = this.TDI_KOD_ULKE.ULKE;
                }
                if (this.AKTIF_ADRES_2)
                {
                    if (this.TDI_KOD_ULKE1 != null)
                        return _AKTIF_ULKE_ADI = this.TDI_KOD_ULKE1.ULKE;
                }
                if (this.AKTIF_ADRES_3)
                {
                    if (this.TDI_KOD_ULKE2 != null)
                        return _AKTIF_ULKE_ADI = this.TDI_KOD_ULKE2.ULKE;
                }
                return null;
            }
        }

        //private string _ADRES_SEMT3;
        //public string ADRES_SEMT3
        //{
        //    get
        //    {
        //        return _ADRES_SEMT3 = this.TDI_KOD_SEMT2.SEMT;
        //    }
        //}
        public string BAGLI_OLDUGU_YETKILI_CARI
        {
            get
            {
                if (AV001_TDI_BIL_CARI1 != null)
                    return _BAGLI_OLDUGU_YETKILI_CARI = this.AV001_TDI_BIL_CARI1.AD;
                return null;
            }
        }

        public string BANKA_ADI
        {
            get
            {
                if (TDI_KOD_BANKA != null)
                    return _BANKA_ADI = this.TDI_KOD_BANKA.BANKA;
                return null;
            }
        }

        public string BANKA_SUBE_ADI
        {
            get
            {
                if (TDI_KOD_BANKA_SUBE != null)
                    return _BANKA_SUBE_ADI = this.TDI_KOD_BANKA_SUBE.SUBE;
                return null;
            }
        }

        //private string _ILCE_ADI3;
        //public string ILCE_ADI3
        //{
        //    get
        //    {
        //        return _ILCE_ADI3 = this.TDI_KOD_ILCE2.ILCE;
        //    }
        //}
        public string CARI_MESLEK
        {
            get
            {
                if (TDI_KOD_MESLEK != null)
                    return _CARI_MESLEK = this.TDI_KOD_MESLEK.MESLEK;
                return null;
            }
        }

        //private string _ADRES_SEMT2;
        //public string ADRES_SEMT2
        //{
        //    get
        //    {
        //        return _ADRES_SEMT2 = this.TDI_KOD_SEMT1.SEMT;
        //    }
        //}
        public string DILI
        {
            get
            {
                if (TDIE_KOD_DIL != null)
                    return _DILI = this.TDIE_KOD_DIL.DIL;
                return null;
            }
        }

        public string FIRMA_TUR
        {
            get
            {
                if (TDI_KOD_FIRMA_TUR != null)
                    return _FIRMA_TUR = this.TDI_KOD_FIRMA_TUR.TUR;
                return null;
            }
        }

        public string IL_ADI1
        {
            get
            {
                if (this.TDI_KOD_IL != null)
                    return _IL_ADI1 = this.TDI_KOD_IL.IL;
                return null;
            }
        }

        public string IL_ADI2
        {
            get
            {
                if (this.TDI_KOD_IL1 != null)
                    return _IL_ADI2 = this.TDI_KOD_IL1.IL;
                return null;
            }
        }

        public string ILCE_ADI1
        {
            get
            {
                if (this.TDI_KOD_ILCE != null)
                    return _ILCE_ADI1 = this.TDI_KOD_ILCE.ILCE;

                return null;
            }
        }

        public string ILCE_ADI2
        {
            get
            {
                if (this.TDI_KOD_ILCE1 != null)
                    return _ILCE_ADI2 = this.TDI_KOD_ILCE1.ILCE;

                return null;
            }
        }

        //private string _ADRES_SEMT1;
        //public string ADRES_SEMT1
        //{
        //    get
        //    {
        //        return _ADRES_SEMT1 = this.TDI_KOD_SEMT1.SEMT;
        //    }
        //}
        public string MEZUN_OLDUGU_OKUL
        {
            get
            {
                if (TDIE_KOD_OKUL != null)
                    return _MEZUN_OLDUGU_OKUL = this.TDIE_KOD_OKUL.OKUL;
                return null;
            }
        }

        public string OZEL_KOD1
        {
            get
            {
                if (AV001_TDI_KOD_CARI_OZEL != null)
                    return _OZEL_KOD1 = this.AV001_TDI_KOD_CARI_OZEL.KOD;
                return null;
            }
        }

        public string OZEL_KOD2
        {
            get
            {
                if (AV001_TDI_KOD_CARI_OZEL1 != null)
                    return _OZEL_KOD2 = this.AV001_TDI_KOD_CARI_OZEL1.KOD;
                return null;
            }
        }

        public string OZEL_KOD3
        {
            get
            {
                if (AV001_TDI_KOD_CARI_OZEL2 != null)
                    return _OZEL_KOD3 = this.AV001_TDI_KOD_CARI_OZEL2.KOD;
                return null;
            }
        }

        public string OZEL_KOD4
        {
            get
            {
                if (AV001_TDI_KOD_CARI_OZEL3 != null)
                    return _OZEL_KOD4 = this.AV001_TDI_KOD_CARI_OZEL3.KOD;
                return null;
            }
        }

        //private string _ILCE_ADI2;
        //public string ILCE_ADI2
        //{
        //    get
        //    {
        //        return _ILCE_ADI2 = this.TDI_KOD_ILCE1.ILCE;
        //    }
        //}
        public string REFERANS_SAHIS
        {
            get
            {
                if (AV001_TDI_BIL_CARI5 != null)
                    return _REFERANS_SAHIS = this.AV001_TDI_BIL_CARI5.AD;
                return null;
            }
        }

        public string SICIL_YERI
        {
            get
            {
                if (TDI_KOD_ILCE1 != null)
                    return _SICIL_YERI = this.TDI_KOD_ILCE1.ILCE;
                return null;
            }
        }

        public string ULKE_ADI1
        {
            get
            {
                if (this.TDI_KOD_ULKE != null)
                    return _AKTIF_ULKE_ADI = this.TDI_KOD_ULKE.ULKE;

                return null;
            }
        }

        public string ULKE_ADI2
        {
            get
            {
                if (this.TDI_KOD_ULKE1 != null)
                    return _AKTIF_ULKE_ADI = this.TDI_KOD_ULKE1.ULKE;
                return null;
            }
        }

        //private string _ULKE_ADI;
        //public string ULKE_ADI
        //{
        //    get
        //    {
        //        return _ULKE_ADI = this.TDI_KOD_ULKE.ULKE;
        //    }

        //}

        //private string _ULKE_ADI2;
        //public string ULKE_ADI2
        //{
        //    get
        //    {
        //        return _ULKE_ADI2 = this.TDI_KOD_ULKE1.ULKE;
        //    }

        //}

        //private string _ULKE_ADI3;
        //public string ULKE_ADI3
        //{
        //    get
        //    {
        //        return _ULKE_ADI3 = this.TDI_KOD_ULKE2.ULKE;
        //    }

        //}

        //private string _IL_ADI;
        //public string IL_ADI
        //{
        //    get
        //    {
        //        return _IL_ADI = this.TDI_KOD_IL.IL;
        //    }

        //}

        //private string _IL_ADI2;
        //public string IL_ADI2
        //{
        //    get
        //    {
        //        return _IL_ADI2 = this.TDI_KOD_IL1.IL;
        //    }
        //}

        //private string _IL_ADI3;
        //public string IL_ADI3
        //{
        //    get
        //    {
        //        return _IL_ADI3 = this.TDI_KOD_IL2.IL;
        //    }
        //}

        //private string _ILCE_ADI;
        //public string ILCE_ADI
        //{
        //    get
        //    {
        //        return _ILCE_ADI = this.TDI_KOD_ILCE.ILCE;
        //    }
        //}
        public string UNVAN1
        {
            get
            {
                if (TDI_KOD_UNVAN != null)
                    return _UNVAN1 = this.TDI_KOD_UNVAN.UNVAN;
                return null;
            }
        }

        public string UNVAN2
        {
            get
            {
                if (TDI_KOD_UNVAN1 != null)
                    return _UNVAN2 = this.TDI_KOD_UNVAN1.UNVAN;
                return null;
            }
        }

        public string YETKILI1
        {
            get
            {
                if (AV001_TDI_BIL_CARI6 != null)
                    return _YETKILI1 = this.AV001_TDI_BIL_CARI6.AD;
                return null;
            }
        }

        public string YETKILI2
        {
            get
            {
                if (AV001_TDI_BIL_CARI3 != null)
                    return _YETKILI2 = this.AV001_TDI_BIL_CARI3.AD;
                return null;
            }
        }

        //private string _ADRES_TUR1;
        //public string ADRES_TUR1
        //{
        //    get
        //    {
        //        return _ADRES_TUR1 = this.TDI_KOD_ADRES_TUR.ADRES_TUR;
        //    }
        //}

        //private string _ADRES_TUR2;
        //public string ADRES_TUR2
        //{
        //    get
        //    {
        //        return _ADRES_TUR2 = this.TDI_KOD_ADRES_TUR1.ADRES_TUR;
        //    }
        //}

        //private string _ADRES_TUR3;
        //public string ADRES_TUR3
        //{
        //    get
        //    {
        //        return _ADRES_TUR3 = this.TDI_KOD_ADRES_TUR2.ADRES_TUR;
        //    }
        //}
    }
}