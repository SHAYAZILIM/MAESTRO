using System;

namespace AvukatProLib.Arama
{
    public partial class AV001_TDI_BIL_CARI_HESAP_DETAY
    {
        private char? _BORC_ALACAK_ADI;

        private string _BURO;

        private string _CARI_AD;

        private bool? _CARI_AVUKAT;

        private bool? _CARI_FIRMA;

        private int? _CARI_ID;

        private string _CARI_KOD;

        private bool? _CARI_MUVEKKIL;

        private bool? _CARI_PERSONEL;

        private string _Dosya_No;

        private string _DURUM;

        private string _Esas_No;

        private string _FOY_ADLI_BIRIM_NO;

        private string _FOY_ADLIYE;

        private string _FOY_GOREV;

        private string _HESAP_ACIKLAMA;

        private string _HESAP_HAREKET_ALT_KAREGORI;

        private string _HESAP_HAREKET_ANA_KATEGORI;

        private int? _HESAP_ID;

        private string _KULLANICI;

        private string _ODEME_TIP_ADI;

        private string _REFERANS_NO;

        private string _Takip_Konusu;

        private DateTime? _Takip_T;

        public decimal ALINAN
        {
            get
            {
                if (this.BORC_ALACAK_ID == 1)
                    return this.GENEL_TOPLAM;
                return decimal.Zero;
            }
        }

        public int ALINAN_DOVIZ_ID
        {
            get
            {
                return this.BIRIM_FIYAT_DOVIZ_ID ?? 1;
            }
        }

        public char? BORC_ALACAK_ADI
        {
            get
            {
                if (this.TDI_KOD_MUHASEBE_BORC_ALACAK != null)
                    return _BORC_ALACAK_ADI = this.TDI_KOD_MUHASEBE_BORC_ALACAK.BORC_ALACAK;
                return null;
            }
        }

        public string BURO
        {
            get
            {
                if (this.AV001_TDI_BIL_CARI_HESAP != null)
                {
                    if (this.AV001_TDI_BIL_CARI_HESAP.TDIE_BIL_KULLANICI_SUBELERI != null)
                        return _BURO = this.AV001_TDI_BIL_CARI_HESAP.TDIE_BIL_KULLANICI_SUBELERI.SUBE_ADI;
                }
                return null;
            }
        }

        public string CARI_AD
        {
            get
            {
                if (this.AV001_TDI_BIL_CARI_HESAP.AV001_TDI_BIL_CARI != null)
                    return _CARI_AD = this.AV001_TDI_BIL_CARI_HESAP.AV001_TDI_BIL_CARI.AD;
                return null;
            }
        }

        public bool? CARI_AVUKAT
        {
            get
            {
                if (this.AV001_TDI_BIL_CARI_HESAP.AV001_TDI_BIL_CARI != null)
                    return _CARI_AVUKAT = this.AV001_TDI_BIL_CARI_HESAP.AV001_TDI_BIL_CARI.AVUKAT_MI;
                return null;
            }
        }

        public bool? CARI_FIRMA
        {
            get
            {
                if (this.AV001_TDI_BIL_CARI_HESAP.AV001_TDI_BIL_CARI != null)
                    return _CARI_FIRMA = this.AV001_TDI_BIL_CARI_HESAP.AV001_TDI_BIL_CARI.FIRMA_MI;
                return null;
            }
        }

        public int? CARI_ID
        {
            get
            {
                if (this.AV001_TDI_BIL_CARI_HESAP != null)
                    return _CARI_ID = this.AV001_TDI_BIL_CARI_HESAP.CARI_ID;
                return null;
            }
        }

        public string CARI_KOD
        {
            get
            {
                if (this.AV001_TDI_BIL_CARI_HESAP.AV001_TDI_BIL_CARI != null)
                    return _CARI_KOD = this.AV001_TDI_BIL_CARI_HESAP.AV001_TDI_BIL_CARI.KOD;
                return null;
            }
        }

        public bool? CARI_MUVEKKIL
        {
            get
            {
                if (this.AV001_TDI_BIL_CARI_HESAP.AV001_TDI_BIL_CARI != null)
                    return _CARI_MUVEKKIL = this.AV001_TDI_BIL_CARI_HESAP.AV001_TDI_BIL_CARI.MUVEKKIL_MI;
                return null;
            }
        }

        public bool? CARI_PERSONEL
        {
            get
            {
                if (this.AV001_TDI_BIL_CARI_HESAP.AV001_TDI_BIL_CARI != null)
                    return _CARI_PERSONEL = this.AV001_TDI_BIL_CARI_HESAP.AV001_TDI_BIL_CARI.PERSONEL_MI;
                return null;
            }
        }

        public string Dosya_No
        {
            get
            {
                if (this.ICRA_FOY_ID != null)
                    return this._Dosya_No = this.AV001_TI_BIL_FOY.FOY_NO;
                if (this.DAVA_FOY_ID != null)
                    return this._Dosya_No = this.AV001_TD_BIL_FOY.FOY_NO;
                if (this.HAZIRLIK_ID != null)
                    return this._Dosya_No = this.AV001_TD_BIL_HAZIRLIK.HAZIRLIK_NO;
                return null;
            }
        }

        public string DURUM
        {
            get
            {
                if (this.ICRA_FOY_ID != null)
                    return this._DURUM = this.AV001_TI_BIL_FOY.TDI_KOD_FOY_DURUM.DURUM;
                if (this.DAVA_FOY_ID != null)
                    return this._DURUM = this.AV001_TD_BIL_FOY.TDI_KOD_FOY_DURUM.DURUM;
                if (this.HAZIRLIK_ID != null)
                    return this._DURUM = this.AV001_TD_BIL_HAZIRLIK.TDI_KOD_FOY_DURUM.DURUM;

                return null;
            }
        }

        public string Esas_No
        {
            get
            {
                if (this.ICRA_FOY_ID != null)
                    return this._Esas_No = this.AV001_TI_BIL_FOY.ESAS_NO;
                if (this.DAVA_FOY_ID != null)
                    return this._Esas_No = this.AV001_TD_BIL_FOY.ESAS_NO;
                if (this.HAZIRLIK_ID != null)
                    return this._Esas_No = this.AV001_TD_BIL_HAZIRLIK.HAZIRLIK_ESAS_NO;

                return null;
            }
        }

        public string FOY_ADLI_BIRIM_NO
        {
            get
            {
                if (this.ICRA_FOY_ID != null)
                {
                    if (this.AV001_TI_BIL_FOY.TDI_KOD_ADLI_BIRIM_NO != null)
                        return this._FOY_ADLI_BIRIM_NO = this.AV001_TI_BIL_FOY.TDI_KOD_ADLI_BIRIM_NO.NO;
                }
                if (this.DAVA_FOY_ID != null)
                {
                    if (this.AV001_TD_BIL_FOY.TDI_KOD_ADLI_BIRIM_NO != null)
                        return this._FOY_ADLI_BIRIM_NO = this.AV001_TD_BIL_FOY.TDI_KOD_ADLI_BIRIM_NO.NO;
                }
                if (this.HAZIRLIK_ID != null)
                {
                    if (this.AV001_TD_BIL_HAZIRLIK.TDI_KOD_ADLI_BIRIM_NO != null)
                        return this._FOY_ADLI_BIRIM_NO = this.AV001_TD_BIL_HAZIRLIK.TDI_KOD_ADLI_BIRIM_NO.NO;
                }
                return null;
            }
        }

        public string FOY_ADLIYE
        {
            get
            {
                if (this.ICRA_FOY_ID != null)
                {
                    if (this.AV001_TI_BIL_FOY.TDI_KOD_ADLI_BIRIM_ADLIYE != null)
                        return this._FOY_ADLIYE = this.AV001_TI_BIL_FOY.TDI_KOD_ADLI_BIRIM_ADLIYE.ADLIYE;
                }
                if (this.DAVA_FOY_ID != null)
                {
                    if (this.AV001_TD_BIL_FOY.TDI_KOD_ADLI_BIRIM_ADLIYE != null)
                        return this._FOY_ADLIYE = this.AV001_TD_BIL_FOY.TDI_KOD_ADLI_BIRIM_ADLIYE.ADLIYE;
                }
                if (this.HAZIRLIK_ID != null)
                {
                    if (this.AV001_TD_BIL_HAZIRLIK.TDI_KOD_ADLI_BIRIM_ADLIYE != null)
                        return this._FOY_ADLIYE = this.AV001_TD_BIL_HAZIRLIK.TDI_KOD_ADLI_BIRIM_ADLIYE.ADLIYE;
                }
                return null;
            }
        }

        public string FOY_GOREV
        {
            get
            {
                if (this.ICRA_FOY_ID != null)
                    return this._FOY_GOREV = "ICRM";
                if (this.DAVA_FOY_ID != null)
                {
                    if (this.AV001_TD_BIL_FOY.TDI_KOD_ADLI_BIRIM_GOREV != null)
                        return this._FOY_GOREV = this.AV001_TD_BIL_FOY.TDI_KOD_ADLI_BIRIM_GOREV.GOREV;
                }
                if (this.HAZIRLIK_ID != null)
                {
                    if (this.AV001_TD_BIL_HAZIRLIK.TDI_KOD_ADLI_BIRIM_GOREV != null)
                        return this._FOY_GOREV = this.AV001_TD_BIL_HAZIRLIK.TDI_KOD_ADLI_BIRIM_GOREV.GOREV;
                }
                return null;
            }
        }

        public string HESAP_ACIKLAMA
        {
            get
            {
                if (this.AV001_TDI_BIL_CARI_HESAP != null)
                    return _HESAP_ACIKLAMA = this.AV001_TDI_BIL_CARI_HESAP.ACIKLAMA;
                return null;
            }
        }

        public string HESAP_HAREKET_ALT_KAREGORI
        {
            get
            {
                if (this.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI != null)
                    return this._HESAP_HAREKET_ALT_KAREGORI = this.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI.ALT_KATEGORI;

                return null;
            }
        }

        public string HESAP_HAREKET_ANA_KATEGORI
        {
            get
            {
                if (this.TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI != null)
                    return this._HESAP_HAREKET_ANA_KATEGORI = this.TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI.ANA_KATEGORI;

                return null;
            }
        }

        public int? HESAP_ID
        {
            get
            {
                if (this.AV001_TDI_BIL_CARI_HESAP != null)
                    return _HESAP_ID = this.AV001_TDI_BIL_CARI_HESAP.ID;
                return null;
            }
        }

        public decimal KALAN { get; set; }

        public int KALAN_DOVIZ_ID { get; set; }

        public string KULLANICI
        {
            get
            {
                if (this.AV001_TDI_BIL_CARI_HESAP != null)
                {
                    if (this.AV001_TDI_BIL_CARI_HESAP.TDI_BIL_KULLANICI_LISTESI != null)
                        return _KULLANICI = this.AV001_TDI_BIL_CARI_HESAP.TDI_BIL_KULLANICI_LISTESI.KULLANICI_ADI;
                }
                return null;
            }
        }

        public string ODEME_TIP_ADI
        {
            get
            {
                if (this.TDI_KOD_ODEME_TIP != null)
                    return _ODEME_TIP_ADI = this.TDI_KOD_ODEME_TIP.ODEME_TIP;
                return null;
            }
        }

        public decimal ODENEN
        {
            get
            {
                if (this.BORC_ALACAK_ID == 2)
                    return this.GENEL_TOPLAM;
                return decimal.Zero;
            }
        }

        public int ODENEN_DOVIZ_ID
        {
            get
            {
                return this.BIRIM_FIYAT_DOVIZ_ID ?? 1;
            }
        }

        public string REFERANS_NO
        {
            get
            {
                if (this.AV001_TDI_BIL_CARI_HESAP != null)
                    return _REFERANS_NO = this.AV001_TDI_BIL_CARI_HESAP.REFERANS_NO;
                return null;
            }
        }

        public string Takip_Konusu
        {
            get
            {
                if (this.ICRA_FOY_ID != null)
                {
                    if (this.AV001_TI_BIL_FOY.TI_KOD_TAKIP_TALEP != null)
                        return this._Takip_Konusu = this.AV001_TI_BIL_FOY.TI_KOD_TAKIP_TALEP.TALEP_ADI;
                }
                if (this.DAVA_FOY_ID != null)
                {
                    if (this.AV001_TD_BIL_FOY.TD_KOD_DAVA_TALEP != null)
                        return this._Takip_Konusu = this.AV001_TD_BIL_FOY.TD_KOD_DAVA_TALEP.DAVA_TALEP;
                }
                if (this.HAZIRLIK_ID != null)
                {
                    if (this.AV001_TD_BIL_HAZIRLIK.TD_KOD_DAVA_TALEP != null)
                        return this._Takip_Konusu = this.AV001_TD_BIL_HAZIRLIK.TD_KOD_DAVA_TALEP.DAVA_TALEP;
                }

                return null;
            }
        }

        public DateTime? Takip_T
        {
            get
            {
                if (this.ICRA_FOY_ID != null)
                    return this._Takip_T = this.AV001_TI_BIL_FOY.TAKIP_TARIHI;
                if (this.DAVA_FOY_ID != null)
                    return this._Takip_T = this.AV001_TD_BIL_FOY.DAVA_TARIHI;
                if (this.HAZIRLIK_ID != null)
                    return this._Takip_T = this.AV001_TD_BIL_HAZIRLIK.HAZIRLIK_TARIH;
                return null;
            }
        }
    }
}