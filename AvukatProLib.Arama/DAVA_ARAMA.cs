using System;
using System.Linq;

namespace AvukatProLib.Arama
{
    public partial class AV001_TD_BIL_FOY
    {
        private string _ADLI_BIRIM_ADLIYE;
        private string _ADLI_BIRIM_GOREV;
        private string _ADLI_BIRIM_NO;
        private string _BOLUM;
        private string _BURO;
        private string _DAVA_EDEN;
        private int? _DAVA_EDEN_CARI_ID;
        private string _DAVA_EDEN_SIFAT;
        private int? _DAVA_EDEN_TK;
        private string _DAVA_EDILEN;
        private int? _DAVA_EDILEN_CARI_ID;
        private string _DAVA_EDILEN_SIFAT;
        private int? _DAVA_EDILEN_TK;
        private DateTime? _DURUSMA_TARIHI;
        private int? _GASAMA_ADI;
        private string _GASAMA_KONU;
        private string _GDAVA_TALEP;
        private string _GDAVA_TIP;
        private string _GOZEL_KOD1;
        private string _GOZEL_KOD2;
        private string _GOZEL_KOD3;
        private string _GOZEL_KOD4;
        private string _IZLEYEN;
        private int? _IZLEYEN_CARI_ID;
        private DateTime? _KESIF_TARIHI;
        private string _KULLANICI;
        private string _SORUMLU;

        private int? _SORUMLU_CARI_ID;

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

        public string ADLI_BIRIM_GOREV
        {
            get
            {
                //var sonuclar = ;
                if (this.TDI_KOD_ADLI_BIRIM_GOREV != null)
                    return _ADLI_BIRIM_GOREV = this.TDI_KOD_ADLI_BIRIM_GOREV.GOREV;

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

        public string DAVA_EDEN
        {
            get
            {
                var sonuclar = this.AV001_TD_BIL_FOY_TARAFs.Where(vi => vi.DAVA_EDEN_MI == true);
                if (sonuclar.Count() > 0)
                    return _DAVA_EDEN = sonuclar.First().AV001_TDI_BIL_CARI1.AD;
                return null;
            }
        }

        public int? DAVA_EDEN_CARI_ID
        {
            get
            {
                var sonuclar = this.AV001_TD_BIL_FOY_TARAFs.Where(vi => vi.DAVA_EDEN_MI == true);
                if (sonuclar.Count() > 0)
                    return _DAVA_EDEN_CARI_ID = sonuclar.First().AV001_TDI_BIL_CARI1.ID;
                return null;
            }
        }

        public string DAVA_EDEN_SIFAT
        {
            get
            {
                var sonuclar = this.AV001_TD_BIL_FOY_TARAFs.Where(vi => vi.DAVA_EDEN_MI == true);
                if (sonuclar.Count() > 0)
                    return _DAVA_EDEN_SIFAT = sonuclar.First().TDIE_KOD_TARAF_SIFAT.SIFAT;
                return null;
            }
        }

        public int? DAVA_EDEN_TK
        {
            get
            {
                var sonuclar = this.AV001_TD_BIL_FOY_TARAFs.Where(vi => vi.DAVA_EDEN_MI == true);
                if (sonuclar.Count() > 0)
                    return _DAVA_EDEN_TK = sonuclar.First().TARAF_KODU;
                return null;
            }
        }

        public string DAVA_EDILEN
        {
            get
            {
                var sonuclar = this.AV001_TD_BIL_FOY_TARAFs.Where(vi => vi.DAVA_EDEN_MI == false);
                if (sonuclar.Count() > 0)
                    return _DAVA_EDILEN = sonuclar.First().AV001_TDI_BIL_CARI1.AD;
                return null;
            }
        }

        public int? DAVA_EDILEN_CARI_ID
        {
            get
            {
                var sonuclar = this.AV001_TD_BIL_FOY_TARAFs.Where(vi => vi.DAVA_EDEN_MI == false);
                if (sonuclar.Count() > 0)
                    return _DAVA_EDILEN_CARI_ID = sonuclar.First().AV001_TDI_BIL_CARI1.ID;
                return null;
            }
        }

        public string DAVA_EDILEN_SIFAT
        {
            get
            {
                var sonuclar = this.AV001_TD_BIL_FOY_TARAFs.Where(vi => vi.DAVA_EDEN_MI == false);
                if (sonuclar.Count() > 0)
                    return _DAVA_EDILEN_SIFAT = sonuclar.First().TDIE_KOD_TARAF_SIFAT.SIFAT;

                return null;
            }
        }

        public int? DAVA_EDILEN_TK
        {
            get
            {
                var sonuclar = this.AV001_TD_BIL_FOY_TARAFs.Where(vi => vi.DAVA_EDEN_MI == false);
                if (sonuclar.Count() > 0)
                    return _DAVA_EDILEN_TK = sonuclar.First().TARAF_KODU;

                return null;
            }
        }

        public DateTime? DURUSMA_TARIHI
        {
            get
            {
                var sonuclar = this.AV001_TD_BIL_CELSEs.Where(vi => vi.CELSE_MI == true);
                if (sonuclar.Count() > 0)
                    return _DURUSMA_TARIHI = sonuclar.Max(vi => vi.TARIH);

                return null;
            }
        }

        public int? GASAMA_ADI
        {
            get
            {
                var sonuclar = this.AV001_TDIE_BIL_ASAMAs;
                if (sonuclar.Count() > 0)
                    return _GASAMA_ADI = sonuclar.First().ASAMA_KOD_ID;

                return null;
            }
        }

        public string GASAMA_KONU
        {
            get
            {
                var sonuclar = this.AV001_TDIE_BIL_ASAMAs;
                if (sonuclar.Count() > 0)
                    return _GASAMA_KONU = sonuclar.First().ASAMA_KONU;

                return null;
            }
        }

        public string GDAVA_TALEP
        {
            get
            {
                //var sonuclar = ;
                if (this.TD_KOD_DAVA_TALEP != null)
                    return _GDAVA_TALEP = this.TD_KOD_DAVA_TALEP.DAVA_TALEP;

                return null;
            }
        }

        public string GDAVA_TIP
        {
            get
            {
                //var sonuclar = ;
                if (this.TDI_KOD_ADLI_BIRIM_BOLUM != null)
                    return _GDAVA_TIP = this.TDI_KOD_ADLI_BIRIM_BOLUM.BIRIM;

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

        public string IZLEYEN
        {
            get
            {
                var sonuclar = this.AV001_TD_BIL_FOY_SORUMLU_AVUKATs.Where(vi => vi.YETKILI_MI == true);

                if (sonuclar.Count() > 0)
                    return _IZLEYEN = sonuclar.First().AV001_TDI_BIL_CARI.AD;
                return null;
            }
        }

        public int? IZLEYEN_CARI_ID
        {
            get
            {
                var sonuclar = this.AV001_TD_BIL_FOY_SORUMLU_AVUKATs.Where(vi => vi.YETKILI_MI == true);

                if (sonuclar.Count() > 0)
                    return _IZLEYEN_CARI_ID = sonuclar.First().SORUMLU_AVUKAT_CARI_ID.Value;

                return null;
            }
        }

        public DateTime? KESIF_TARIHI
        {
            get
            {
                var sonuclar = this.AV001_TD_BIL_CELSEs.Where(vi => vi.CELSE_MI == false);
                if (sonuclar.Count() > 0)
                    return _KESIF_TARIHI = sonuclar.Max(vi => vi.TARIH);

                return null;
            }
        }

        public string KULLANICI
        {
            get
            {
                //var sonuclar = ;
                if (this.TDI_BIL_KULLANICI_LISTESI != null && this.TDI_BIL_KULLANICI_LISTESI.AV001_TDI_BIL_CARI1 != null)
                    return _KULLANICI = this.TDI_BIL_KULLANICI_LISTESI.AV001_TDI_BIL_CARI1.AD;

                return null;
            }
        }

        public string SORUMLU
        {
            get
            {
                var sonuclar = this.AV001_TD_BIL_FOY_SORUMLU_AVUKATs.Where(vi => vi.YETKILI_MI == false);

                if (sonuclar.Count() > 0)
                    return _SORUMLU = sonuclar.First().AV001_TDI_BIL_CARI.AD;

                return null;
            }
        }

        public int? SORUMLU_CARI_ID
        {
            get
            {
                var sonuclar = this.AV001_TD_BIL_FOY_SORUMLU_AVUKATs.Where(vi => vi.YETKILI_MI == false);

                if (sonuclar.Count() > 0)
                    return _SORUMLU_CARI_ID = sonuclar.First().SORUMLU_AVUKAT_CARI_ID;

                return null;
            }
        }
    }
}