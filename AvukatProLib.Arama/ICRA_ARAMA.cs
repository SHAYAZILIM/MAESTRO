using System.Linq;

namespace AvukatProLib.Arama
{
    public partial class AV001_TI_BIL_FOY
    {
        private string _ADLI_BIRIM_ADLIYE;
        private string _ADLI_BIRIM_NO;
        private string _BOLUM;
        private string _BURO;
        private string _FORM_ADI;
        private string _GOZEL_KOD1;
        private string _GOZEL_KOD2;
        private string _GOZEL_KOD3;
        private string _GOZEL_KOD4;
        private string _GTAKIP_TALEP;
        private string _IZLEYEN;
        private int? _IZLEYEN_CARI_ID;
        private string _KULLANICI;
        private string _SORUMLU;

        private int? _SORUMLU_CARI_ID;

        private string _TAKIP_EDEN;

        private int? _TAKIP_EDEN_CARI_ID;

        private string _TAKIP_EDEN_SIFAT;

        private int? _TAKIP_EDEN_TK;

        private string _TAKIP_EDILEN;

        private int? _TAKIP_EDILEN_CARI_ID;

        private string _TAKIP_EDILEN_SIFAT;

        private int? _TAKIP_EDILEN_TK;

        private string _TO_HESAP_TIP;

        private string _TS_HESAP_TIP;

        public string ADLI_BIRIM_ADLIYE
        {
            get
            {
                //var sonuclar = ;
                if (this.TDI_KOD_ADLI_BIRIM_ADLIYE != null)
                    return _ADLI_BIRIM_ADLIYE = this.TDI_KOD_ADLI_BIRIM_ADLIYE.ADLIYE;

                return null;
            }
        }

        public string ADLI_BIRIM_NO
        {
            get
            {
                //var sonuclar = ;
                if (this.TDI_KOD_ADLI_BIRIM_NO != null)
                    return _ADLI_BIRIM_NO = this.TDI_KOD_ADLI_BIRIM_NO.NO;

                return null;
            }
        }

        public string BOLUM
        {
            get
            {
                //var sonuclar = ;
                if (this.TDI_KOD_SEGMENT != null)
                    return _BOLUM = this.TDI_KOD_SEGMENT.SEGMENT;

                return null;
            }
        }

        public string BURO
        {
            get
            {
                //var sonuclar = ;
                if (this.TDIE_BIL_KULLANICI_SUBELERI != null)
                    return _BURO = this.TDIE_BIL_KULLANICI_SUBELERI.SUBE_ADI;

                return null;
            }
        }

        public string FORM_ADI
        {
            get
            {
                //var sonuclar = ;
                if (this.TI_KOD_FORM_TIP != null)
                    return _FORM_ADI = "Form " + this.TI_KOD_FORM_TIP.FORM_ORNEK_NO + " (" + this.TI_KOD_FORM_TIP.YENI_FORM_ORNEK_NO + " )";

                return null;
            }
        }

        public string GDURUM
        {
            get
            {
                if (this.TDI_KOD_FOY_DURUM != null)
                    return _DURUM = this.TDI_KOD_FOY_DURUM.DURUM;

                return null;
            }
        }

        public string GOZEL_KOD1
        {
            get
            {
                //var sonuclar = ;
                if (this.AV001_TDI_KOD_FOY_OZEL != null)
                    return _GOZEL_KOD1 = this.AV001_TDI_KOD_FOY_OZEL.KOD;

                return null;
            }
        }

        public string GOZEL_KOD2
        {
            get
            {
                //var sonuclar = ;
                if (this.AV001_TDI_KOD_FOY_OZEL1 != null)
                    return _GOZEL_KOD2 = this.AV001_TDI_KOD_FOY_OZEL1.KOD;

                return null;
            }
        }

        public string GOZEL_KOD3
        {
            get
            {
                //var sonuclar = ;
                if (this.AV001_TDI_KOD_FOY_OZEL2 != null)
                    return _GOZEL_KOD3 = this.AV001_TDI_KOD_FOY_OZEL2.KOD;

                return null;
            }
        }

        public string GOZEL_KOD4
        {
            get
            {
                //var sonuclar = ;
                if (this.AV001_TDI_KOD_FOY_OZEL3 != null)
                    return _GOZEL_KOD4 = this.AV001_TDI_KOD_FOY_OZEL3.KOD;

                return null;
            }
        }

        public string GTAKIP_TALEP
        {
            get
            {
                //var sonuclar = ;
                if (this.TI_KOD_TAKIP_TALEP != null)
                    return _GTAKIP_TALEP = this.TI_KOD_TAKIP_TALEP.TALEP_ADI;

                return null;
            }
        }

        public string IZLEYEN
        {
            get
            {
                var sonuclar = this.AV001_TI_BIL_FOY_SORUMLU_AVUKATs.Where(vi => vi.YETKILI_MI == true);

                if (sonuclar != null && sonuclar.Count() > 0)
                    if (sonuclar.FirstOrDefault().AV001_TDI_BIL_CARI != null)
                        return _IZLEYEN = sonuclar.FirstOrDefault().AV001_TDI_BIL_CARI.AD;
                return null;
            }
        }

        public int? IZLEYEN_CARI_ID
        {
            get
            {
                var sonuclar = this.AV001_TI_BIL_FOY_SORUMLU_AVUKATs.Where(vi => vi.YETKILI_MI == true);

                if (sonuclar != null && sonuclar.Count() > 0)
                    if (sonuclar.FirstOrDefault().SORUMLU_AVUKAT_CARI_ID.HasValue)
                        return _IZLEYEN_CARI_ID = sonuclar.FirstOrDefault().SORUMLU_AVUKAT_CARI_ID.Value;

                return null;
            }
        }

        public string KULLANICI
        {
            get
            {
                try
                {
                    if (this.TDI_BIL_KULLANICI_LISTESI != null)
                        if (this.TDI_BIL_KULLANICI_LISTESI.AV001_TDI_BIL_CARI != null)
                            return _KULLANICI = this.TDI_BIL_KULLANICI_LISTESI.AV001_TDI_BIL_CARI.AD;
                }
                catch
                {
                    return string.Empty;
                }
                return string.Empty;
            }
        }

        public string SORUMLU
        {
            get
            {
                var sonuclar = this.AV001_TI_BIL_FOY_SORUMLU_AVUKATs.Where(vi => vi.YETKILI_MI == false);

                if (sonuclar != null && sonuclar.Count() > 0)
                    if (sonuclar.FirstOrDefault().AV001_TDI_BIL_CARI != null)
                        return _SORUMLU = sonuclar.FirstOrDefault().AV001_TDI_BIL_CARI.AD;

                return null;
            }
        }

        public int? SORUMLU_CARI_ID
        {
            get
            {
                var sonuclar = this.AV001_TI_BIL_FOY_SORUMLU_AVUKATs.Where(vi => vi.YETKILI_MI == false);

                if (sonuclar != null && sonuclar.Count() > 0)
                    return _SORUMLU_CARI_ID = sonuclar.FirstOrDefault().SORUMLU_AVUKAT_CARI_ID;

                return null;
            }
        }

        public string TAKIP_EDEN
        {
            get
            {
                var sonuclar = this.AV001_TI_BIL_FOY_TARAFs.Where(vi => vi.TAKIP_EDEN_MI == true);
                if (sonuclar != null && sonuclar.Count() > 0)
                    if (sonuclar.FirstOrDefault().AV001_TDI_BIL_CARI1 != null)
                        return _TAKIP_EDEN = sonuclar.FirstOrDefault().AV001_TDI_BIL_CARI1.AD;
                return null;
            }
        }

        public int? TAKIP_EDEN_CARI_ID
        {
            get
            {
                var sonuclar = this.AV001_TI_BIL_FOY_TARAFs.Where(vi => vi.TAKIP_EDEN_MI == true);
                if (sonuclar != null && sonuclar.Count() > 0)
                    if (sonuclar.FirstOrDefault().AV001_TDI_BIL_CARI1 != null)
                        return _TAKIP_EDEN_CARI_ID = sonuclar.FirstOrDefault().AV001_TDI_BIL_CARI1.ID;
                return null;
            }
        }

        public string TAKIP_EDEN_SIFAT
        {
            get
            {
                var sonuclar = this.AV001_TI_BIL_FOY_TARAFs.Where(vi => vi.TAKIP_EDEN_MI == true);
                if (sonuclar != null && sonuclar.Count() > 0)
                    if (sonuclar.FirstOrDefault().TDIE_KOD_TARAF_SIFAT != null)
                        return _TAKIP_EDEN_SIFAT = sonuclar.FirstOrDefault().TDIE_KOD_TARAF_SIFAT.SIFAT;
                return null;
            }
        }

        public int? TAKIP_EDEN_TK
        {
            get
            {
                var sonuclar = this.AV001_TI_BIL_FOY_TARAFs.Where(vi => vi.TAKIP_EDEN_MI == true);
                if (sonuclar != null && sonuclar.Count() > 0)
                    return _TAKIP_EDEN_TK = sonuclar.FirstOrDefault().TARAF_KODU;
                return null;
            }
        }

        public string TAKIP_EDILEN
        {
            get
            {
                var sonuclar = this.AV001_TI_BIL_FOY_TARAFs.Where(vi => vi.TAKIP_EDEN_MI == false);
                if (sonuclar != null && sonuclar.Count() > 0)
                    if (sonuclar.FirstOrDefault().AV001_TDI_BIL_CARI1 != null)
                        return _TAKIP_EDILEN = sonuclar.FirstOrDefault().AV001_TDI_BIL_CARI1.AD;
                return null;
            }
        }

        public int? TAKIP_EDILEN_CARI_ID
        {
            get
            {
                var sonuclar = this.AV001_TI_BIL_FOY_TARAFs.Where(vi => vi.TAKIP_EDEN_MI == false);
                if (sonuclar != null && sonuclar.Count() > 0)
                    if (sonuclar.FirstOrDefault().AV001_TDI_BIL_CARI1 != null)
                        return _TAKIP_EDILEN_CARI_ID = sonuclar.FirstOrDefault().AV001_TDI_BIL_CARI1.ID;
                return null;
            }
        }

        public string TAKIP_EDILEN_SIFAT
        {
            get
            {
                var sonuclar = this.AV001_TI_BIL_FOY_TARAFs.Where(vi => vi.TAKIP_EDEN_MI == false);
                if (sonuclar != null && sonuclar.Count() > 0)
                    if (sonuclar.FirstOrDefault().TDIE_KOD_TARAF_SIFAT != null)
                        return _TAKIP_EDILEN_SIFAT = sonuclar.FirstOrDefault().TDIE_KOD_TARAF_SIFAT.SIFAT;

                return null;
            }
        }

        public int? TAKIP_EDILEN_TK
        {
            get
            {
                var sonuclar = this.AV001_TI_BIL_FOY_TARAFs.Where(vi => vi.TAKIP_EDEN_MI == false);
                if (sonuclar != null && sonuclar.Count() > 0)
                    return _TAKIP_EDILEN_TK = sonuclar.FirstOrDefault().TARAF_KODU;

                return null;
            }
        }

        public string TO_HESAP_TIP
        {
            get
            {
                //var sonuclar = ;
                if (this.AV001_TI_KOD_HESAP_TIP != null)
                    return _TO_HESAP_TIP = this.AV001_TI_KOD_HESAP_TIP.HESAP_TIP;

                return null;
            }
        }

        public string TS_HESAP_TIP
        {
            get
            {
                //var sonuclar = ;
                if (this.AV001_TI_KOD_HESAP_TIP1 != null)
                    return _TS_HESAP_TIP = this.AV001_TI_KOD_HESAP_TIP1.HESAP_TIP;

                return null;
            }
        }
    }
}