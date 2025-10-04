using System;
using System.Linq;

namespace AvukatProLib.Arama
{
    public partial class AV001_TDI_BIL_TEBLIGAT
    {
        private string _ALAN;
        private int? _ALAN_CARI_ID;
        private string _ALT_CARI;
        private string _BAGLANTI;
        private DateTime? _BILA_TARIHI;
        private bool _BILA_TEBLIG_MI;
        private DateTime? _BORCUN_ODENDIGI_TARIH;
        private string _BURO;
        private int? _CARI_ALT_ID;
        private string _Dosya_No;
        private string _DURUM;
        private string _Esas_No;
        private string _EVRAK_NO;
        private string _EVRAK_SONUC;
        private DateTime? _EVRAK_TARIHI;
        private string _FOY_ADLI_BIRIM_NO;
        private string _FOY_ADLIYE;
        private string _FOY_GOREV;
        private string _HAZIRLAYAN_CARI;
        private DateTime? _ICRAYA_BELGE_IBRAZ_TARIHI;
        private string _ILK_TEBLIGAT_YAPAN;

        private string _KULLANICI;

        private DateTime? _MENFI_TESPIT_DAVA_TARIHI;

        private string _MUHASEBE_ALT_KAT;

        private string _MUHATAP;

        private int? _MUHATAP_CARI_ID;

        private int _MUHATAP_ID;

        private short? _MUHATAP_TARAF_KOD;

        private string _NEDEN;

        private int? _ODEME_TUTAR_DOVIZ_ID;

        private decimal? _ODEME_TUTARI;

        private bool? _OKUNDU_MU;

        private DateTime? _OLUMSUZ_SONUC_TARIHI;

        private string _POSTA_DURUM;

        private bool _POSTALANDI_MI;

        private string _PTT_BARKOD_NO;

        private string _SEKLI;

        private DateTime? _SUBEDEN_OLUMSUZ_CEVAP_TARIHI;

        private DateTime? _SUBEDEN_YENI_ADRES_BILDIRILDIGI_TARIH;

        private DateTime? _SUBEDEN_YENI_ADRES_ISTEME_TARIHI;

        private string _Takip_Konusu;

        private DateTime? _Takip_T;

        private DateTime? _TEBLIG_TARIH;

        private string _TEBLIGAT_ADLI_BIRIM_ADLIYE;

        private string _TEBLIGAT_ADLI_BIRIM_GOREV;

        private string _TEBLIGAT_ADLI_BIRIM_NO;

        private string _TEBLIGAT_ADRESI;

        private string _TEBLIGAT_ALT_TUR;

        private string _TEBLIGAT_ANA_TUR;

        private DateTime? _TEBLIGAT_IPTAL_DAVA_TARIHI;

        private string _TEBLIGAT_KONU;

        private string _TEBLIGAT_SEKLI;

        private string _TEBLIGAT_SONUC;

        private DateTime? _TEBLIGAT_TEKIT_TARIHI;

        private DateTime? _TEBLIGATA_ITIRAZ_TARIHI;

        private DateTime? _TEBLIGATIN_KESINLESTIGI_TARIH;

        private DateTime? _ZABITA_ARASTIRMA_TARIHI;

        private bool _ZABITA_ARASTIRMASI_ISTENDI_MI;

        private bool _ZABITA_ARASTIRMASI_OLUMSUZ_MU;

        private DateTime? _ZABITACA_YENI_ADRES_BULUNDUGU_TARIHI;

        public string ALAN
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                {
                    return _ALAN = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs[0].AV001_TDI_BIL_CARI2.AD;
                }
                return string.Empty;
            }
        }

        public int? ALAN_CARI_ID
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _ALAN_CARI_ID = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs[0].ALAN_CARI_ID;
                return null;
            }
        }

        public string ALT_CARI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs[0].AV001_TDI_BIL_CARI_ALT != null)
                        return _ALT_CARI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs[0].AV001_TDI_BIL_CARI_ALT.AD;
                return string.Empty;
            }
        }

        public string BAGLANTI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs[0].TDI_KOD_TEBLIGAT_ALAN_BAGLANTI != null)
                        return this._BAGLANTI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs[0].TDI_KOD_TEBLIGAT_ALAN_BAGLANTI.BAGLANTI;

                return string.Empty;
            }
        }

        public DateTime? BILA_TARIHI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _BILA_TARIHI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().BILA_TARIHI;
                return null;
            }
        }

        public bool BILA_TEBLIG_MI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _BILA_TEBLIG_MI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().BILA_TEBLIG_MI;
                return false;
            }
        }

        public DateTime? BORCUN_ODENDIGI_TARIH
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _BORCUN_ODENDIGI_TARIH = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().BORCUN_ODENDIGI_TARIH;
                return null;
            }
        }

        public string BURO
        {
            get
            {
                if (this.TDIE_BIL_KULLANICI_SUBELERI != null)
                {
                    if (!string.IsNullOrEmpty(this.TDIE_BIL_KULLANICI_SUBELERI.SUBE_ADI))
                        return _BURO = this.TDIE_BIL_KULLANICI_SUBELERI.SUBE_ADI;
                }

                return string.Empty;
            }
        }

        public int? CARI_ALT_ID
        {
            get
            {
                return _CARI_ALT_ID = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs[0].CARI_ALT_ID;
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

        public string EVRAK_NO
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _EVRAK_NO = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().EVRAK_NO;
                return null;
            }
        }

        public string EVRAK_SONUC
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs[0].TDI_KOD_EVRAK_SONUC != null)
                        return _EVRAK_SONUC = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs[0].TDI_KOD_EVRAK_SONUC.EVRAK_SONUCU;
                return string.Empty;
            }
        }

        public DateTime? EVRAK_TARIHI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _EVRAK_TARIHI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().EVRAK_TARIHI;
                return null;
            }
        }

        public string FOY_ADLI_BIRIM_NO
        {
            get
            {
                if (this.ICRA_FOY_ID != null)
                    return this._FOY_ADLI_BIRIM_NO = this.AV001_TI_BIL_FOY.TDI_KOD_ADLI_BIRIM_NO.NO;
                if (this.DAVA_FOY_ID != null)
                    return this._FOY_ADLI_BIRIM_NO = this.AV001_TD_BIL_FOY.TDI_KOD_ADLI_BIRIM_NO.NO;
                if (this.HAZIRLIK_ID != null)
                    return this._FOY_ADLI_BIRIM_NO = this.AV001_TD_BIL_HAZIRLIK.TDI_KOD_ADLI_BIRIM_NO.NO;

                return null;
            }
        }

        public string FOY_ADLIYE
        {
            get
            {
                if (this.ICRA_FOY_ID != null)
                    return this._FOY_ADLIYE = this.AV001_TI_BIL_FOY.TDI_KOD_ADLI_BIRIM_ADLIYE.ADLIYE;
                if (this.DAVA_FOY_ID != null)
                    return this._FOY_ADLIYE = this.AV001_TD_BIL_FOY.TDI_KOD_ADLI_BIRIM_ADLIYE.ADLIYE;
                if (this.HAZIRLIK_ID != null)
                    return this._FOY_ADLIYE = this.AV001_TD_BIL_HAZIRLIK.TDI_KOD_ADLI_BIRIM_ADLIYE.ADLIYE;

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
                    return this._FOY_GOREV = this.AV001_TD_BIL_FOY.TDI_KOD_ADLI_BIRIM_GOREV.GOREV;
                if (this.HAZIRLIK_ID != null)
                    return this._FOY_GOREV = this.AV001_TD_BIL_HAZIRLIK.TDI_KOD_ADLI_BIRIM_GOREV.GOREV;

                return null;
            }
        }

        public string HAZIRLAYAN_CARI
        {
            get
            {
                return _HAZIRLAYAN_CARI = this.AV001_TDI_BIL_CARI1.AD;
            }
        }

        public DateTime? ICRAYA_BELGE_IBRAZ_TARIHI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _ICRAYA_BELGE_IBRAZ_TARIHI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().ICRAYA_BELGE_IBRAZ_TARIHI;
                return null;
            }
        }

        public string ILK_TEBLIGAT_YAPAN
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_YAPANs.Count > 0)
                    return _ILK_TEBLIGAT_YAPAN = this.AV001_TDI_BIL_TEBLIGAT_YAPANs[0].AV001_TDI_BIL_CARI.AD;

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

        public DateTime? MENFI_TESPIT_DAVA_TARIHI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _MENFI_TESPIT_DAVA_TARIHI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().MENFI_TESPIT_DAVA_TARIHI;
                return null;
            }
        }

        public string MUHASEBE_ALT_KAT
        {
            get
            {
                if (TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI != null)
                    return _MUHASEBE_ALT_KAT = this.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI.ALT_KATEGORI;

                return null;
            }
        }

        public string MUHATAP
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                {
                    return _MUHATAP = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs[0].AV001_TDI_BIL_CARI11.AD;
                }
                return string.Empty;
            }
        }

        public int? MUHATAP_CARI_ID
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _MUHATAP_CARI_ID = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().MUHATAP_CARI_ID;
                return null;
            }
        }

        public int MUHATAP_ID
        {
            get
            {
                return _MUHATAP_ID = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().ID;
            }
        }

        public short? MUHATAP_TARAF_KOD
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _MUHATAP_TARAF_KOD = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().MUHATAP_TARAF_KOD;
                return null;
            }
        }

        public string NEDEN
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs[0].TDI_KOD_TEBLIGAT_ALINMAMA_NEDEN != null)
                        return this._NEDEN = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs[0].TDI_KOD_TEBLIGAT_ALINMAMA_NEDEN.NEDEN;
                return string.Empty;
            }
        }

        public int? ODEME_TUTAR_DOVIZ_ID
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _ODEME_TUTAR_DOVIZ_ID = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().ODEME_TUTAR_DOVIZ_ID;
                return null;
            }
        }

        public decimal? ODEME_TUTARI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _ODEME_TUTARI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().ODEME_TUTARI;
                return null;
            }
        }

        public bool? OKUNDU_MU
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _OKUNDU_MU = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().OKUNDU_MU;
                return null;
            }
        }

        public DateTime? OLUMSUZ_SONUC_TARIHI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _OLUMSUZ_SONUC_TARIHI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().OLUMSUZ_SONUC_TARIHI;
                return null;
            }
        }

        public string POSTA_DURUM
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _POSTA_DURUM = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().POSTA_DURUM;
                return null;
            }
        }

        public bool POSTALANDI_MI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _POSTALANDI_MI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().POSTALANDI_MI;
                return false;
            }
        }

        public string PTT_BARKOD_NO
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _PTT_BARKOD_NO = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().PTT_BARKOD_NO;
                return null;
            }
        }

        public string SEKLI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs[0].TDI_KOD_TEBLIGAT_ALIM_SEKIL != null)
                        return this._SEKLI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs[0].TDI_KOD_TEBLIGAT_ALIM_SEKIL.SEKIL;

                return string.Empty;
            }
        }

        public DateTime? SUBEDEN_OLUMSUZ_CEVAP_TARIHI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _SUBEDEN_OLUMSUZ_CEVAP_TARIHI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().SUBEDEN_OLUMSUZ_CEVAP_TARIHI;
                return null;
            }
        }

        public DateTime? SUBEDEN_YENI_ADRES_BILDIRILDIGI_TARIH
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _SUBEDEN_YENI_ADRES_BILDIRILDIGI_TARIH = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().SUBEDEN_YENI_ADRES_BILDIRILDIGI_TARIH;
                return null;
            }
        }

        public DateTime? SUBEDEN_YENI_ADRES_ISTEME_TARIHI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _SUBEDEN_YENI_ADRES_ISTEME_TARIHI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().SUBEDEN_YENI_ADRES_ISTEME_TARIHI;
                return null;
            }
        }

        public string Takip_Konusu
        {
            get
            {
                if (this.ICRA_FOY_ID != null)
                    return this._Takip_Konusu = this.AV001_TI_BIL_FOY.TI_KOD_TAKIP_TALEP.TALEP_ADI;
                if (this.DAVA_FOY_ID != null)
                    return this._Takip_Konusu = this.AV001_TD_BIL_FOY.TD_KOD_DAVA_TALEP.DAVA_TALEP;
                if (this.HAZIRLIK_ID != null)
                    return this._Takip_Konusu = this.AV001_TD_BIL_HAZIRLIK.TD_KOD_DAVA_TALEP.DAVA_TALEP;

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

        public DateTime? TEBLIG_TARIH
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _TEBLIG_TARIH = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().TEBLIG_TARIH;
                return null;
            }
        }

        public string TEBLIGAT_ADLI_BIRIM_ADLIYE
        {
            get
            {
                if (this.TDI_KOD_ADLI_BIRIM_ADLIYE != null)
                    return this._TEBLIGAT_ADLI_BIRIM_ADLIYE = this.TDI_KOD_ADLI_BIRIM_ADLIYE.ADLIYE;
                return string.Empty;
            }
        }

        public string TEBLIGAT_ADLI_BIRIM_GOREV
        {
            get
            {
                if (this.TDI_KOD_ADLI_BIRIM_GOREV != null)
                    return this._TEBLIGAT_ADLI_BIRIM_GOREV = this.TDI_KOD_ADLI_BIRIM_GOREV.GOREV;
                return string.Empty;
            }
        }

        public string TEBLIGAT_ADLI_BIRIM_NO
        {
            get
            {
                if (this.TDI_KOD_ADLI_BIRIM_NO != null)
                    return this._TEBLIGAT_ADLI_BIRIM_NO = this.TDI_KOD_ADLI_BIRIM_NO.NO;
                return string.Empty;
            }
        }

        public string TEBLIGAT_ADRESI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _TEBLIGAT_ADRESI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().TEBLIGAT_ADRESI;
                return null;
            }
        }

        public string TEBLIGAT_ALT_TUR
        {
            get
            {
                return this._TEBLIGAT_ALT_TUR = this.TDI_KOD_TEBLIGAT_ALT_TUR.ALT_TUR;
            }
        }

        public string TEBLIGAT_ANA_TUR
        {
            get
            {
                return this._TEBLIGAT_ANA_TUR = this.TDI_KOD_TEBLIGAT_ANA_TUR.ANA_TUR;
            }
        }

        public DateTime? TEBLIGAT_IPTAL_DAVA_TARIHI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _TEBLIGAT_IPTAL_DAVA_TARIHI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().TEBLIGAT_IPTAL_DAVA_TARIHI;
                return null;
            }
        }

        public string TEBLIGAT_KONU
        {
            get
            {
                if (this.TDI_KOD_TEBLIGAT_KONU != null)
                    return this._TEBLIGAT_KONU = this.TDI_KOD_TEBLIGAT_KONU.KONU;
                return string.Empty;
            }
        }

        public string TEBLIGAT_SEKLI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                {
                    if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs[0].TDI_KOD_TEBLIGAT_SEKIL != null)
                        return this._TEBLIGAT_SEKLI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs[0].TDI_KOD_TEBLIGAT_SEKIL.SEKIL;
                }
                return string.Empty;
            }
        }

        public string TEBLIGAT_SONUC
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs[0].TDI_KOD_TEBLIGAT_SONUC != null)
                        return _TEBLIGAT_SONUC = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs[0].TDI_KOD_TEBLIGAT_SONUC.TEBLIGAT_SONUC;

                return string.Empty;
            }
        }

        public DateTime? TEBLIGAT_TEKIT_TARIHI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _TEBLIGAT_TEKIT_TARIHI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().TEBLIGAT_TEKIT_TARIHI;

                return null;
            }
        }

        public DateTime? TEBLIGATA_ITIRAZ_TARIHI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _TEBLIGATA_ITIRAZ_TARIHI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().TEBLIGATA_ITIRAZ_TARIHI;
                return null;
            }
        }

        public DateTime? TEBLIGATIN_KESINLESTIGI_TARIH
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _TEBLIGATIN_KESINLESTIGI_TARIH = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().TEBLIGATIN_KESINLESTIGI_TARIH;
                return null;
            }
        }

        public DateTime? ZABITA_ARASTIRMA_TARIHI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _ZABITA_ARASTIRMA_TARIHI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().ZABITA_ARASTIRMA_TARIHI;
                return null;
            }
        }

        public bool ZABITA_ARASTIRMASI_ISTENDI_MI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _ZABITA_ARASTIRMASI_ISTENDI_MI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().ZABITA_ARASTIRMASI_ISTENDI_MI;
                return false;
            }
        }

        public bool ZABITA_ARASTIRMASI_OLUMSUZ_MU
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _ZABITA_ARASTIRMASI_OLUMSUZ_MU = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().ZABITA_ARASTIRMASI_OLUMSUZ_MU;
                return false;
            }
        }

        public DateTime? ZABITACA_YENI_ADRES_BULUNDUGU_TARIHI
        {
            get
            {
                if (this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Count > 0)
                    return _ZABITACA_YENI_ADRES_BULUNDUGU_TARIHI = this.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.FirstOrDefault().ZABITACA_YENI_ADRES_BULUNDUGU_TARIHI;
                return null;
            }
        }
    }
}