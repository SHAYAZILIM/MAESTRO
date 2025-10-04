using System.Linq;

namespace AvukatProLib.Arama
{
    public partial class AV001_TDI_BIL_I
    {
        private string _ADLI_BIRIM_ADLIYE;
        private string _ADLI_BIRIM_GOREV;
        private string _BIRIM_NO;
        private string _IS_MUHATABI;
        private string _IS_MUHATABI_KODU;
        private string _IS_ONCELIK;
        private string _ISI_VEREN;
        private string _ISI_VEREN_KODU;
        private string _ISI_YAPACAK;

        private string _ISI_YAPACAK_KODU;

        private string _KATEGORI;

        private string _KULLANICI_ADI;

        private string _SUBE_ADI;

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

        public string BIRIM_NO
        {
            get
            {
                if (this.TDI_KOD_ADLI_BIRIM_NO != null)
                    return _BIRIM_NO = this.TDI_KOD_ADLI_BIRIM_NO.NO;
                return null;
            }
        }

        public string IS_MUHATABI
        {
            get
            {
                var sonuclar = this.AV001_TDI_BIL_IS_TARAFs.Where(v => v.TDI_KOD_IS_TARAF != null && v.TDI_KOD_IS_TARAF.IS_TARAF == "İş Muhatabı (Kime ?)");

                if (sonuclar != null && sonuclar.Count() > 0)
                    return _IS_MUHATABI = sonuclar.First().AV001_TDI_BIL_CARI1.AD;
                return null;
            }
        }

        public string IS_MUHATABI_KODU
        {
            get
            {
                var sonuclar = this.AV001_TDI_BIL_IS_TARAFs.Where(v => v.TDI_KOD_IS_TARAF.IS_TARAF == "İş Muhatabı (Kime ?)");

                if (sonuclar != null && sonuclar.Count() > 0)
                    return _IS_MUHATABI_KODU = sonuclar.First().TDI_KOD_IS_TARAF.IS_TARAF;
                return null;
            }
        }

        public string IS_ONCELIK
        {
            get
            {
                if (this.TDI_KOD_IS_ONCELIK != null)
                    return _IS_ONCELIK = this.TDI_KOD_IS_ONCELIK.IS_ONCELIK;
                return null;
            }
        }

        public string ISI_VEREN
        {
            get
            {
                var sonuclar = this.AV001_TDI_BIL_IS_TARAFs.Where(v => v.TDI_KOD_IS_TARAF != null && v.TDI_KOD_IS_TARAF.IS_TARAF == "İşi Veren");

                if (sonuclar != null && sonuclar.Count() > 0)
                    return _ISI_VEREN = sonuclar.First().AV001_TDI_BIL_CARI1.AD;
                return null;
            }
        }

        public string ISI_VEREN_KODU
        {
            get
            {
                var sonuclar = this.AV001_TDI_BIL_IS_TARAFs.Where(v => v.TDI_KOD_IS_TARAF != null && v.TDI_KOD_IS_TARAF.IS_TARAF == "İşi Veren");

                if (sonuclar != null && sonuclar.Count() > 0)
                    return _ISI_VEREN_KODU = sonuclar.First().TDI_KOD_IS_TARAF.IS_TARAF;
                return null;
            }
        }

        public string ISI_YAPACAK
        {
            get
            {
                if (this.AV001_TDI_BIL_IS_TARAFs.Count > 0)
                {
                    var sonuclar = this.AV001_TDI_BIL_IS_TARAFs.Where(v => v.TDI_KOD_IS_TARAF != null && v.TDI_KOD_IS_TARAF.IS_TARAF == "İşi Yapacak");

                    if (sonuclar != null && sonuclar.Count() > 0)
                        return _ISI_YAPACAK = sonuclar.First().AV001_TDI_BIL_CARI1.AD;
                }
                return null;
            }
        }

        public string ISI_YAPACAK_KODU
        {
            get
            {
                var sonuclar = this.AV001_TDI_BIL_IS_TARAFs.Where(v => v.TDI_KOD_IS_TARAF != null && v.TDI_KOD_IS_TARAF.IS_TARAF == "İşi Yapacak");

                if (sonuclar != null && sonuclar.Count() > 0)
                    return _ISI_YAPACAK_KODU = sonuclar.First().TDI_KOD_IS_TARAF.IS_TARAF;
                return null;
            }
        }

        public string KATEGORI
        {
            get
            {
                if (this.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI != null)
                    return _KATEGORI = this.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI.ALT_KATEGORI;
                return null;
            }
        }

        public string KULLANICI_ADI
        {
            get
            {
                if (this.TDI_BIL_KULLANICI_LISTESI != null)
                    return _KULLANICI_ADI = this.TDI_BIL_KULLANICI_LISTESI.KULLANICI_ADI;
                return null;
            }
        }

        public string SUBE_ADI
        {
            get
            {
                if (this.TDIE_BIL_KULLANICI_SUBELERI != null)
                    return _SUBE_ADI = this.TDIE_BIL_KULLANICI_SUBELERI.SUBE_ADI;
                return null;
            }
        }

        //private string _IS_SORUMLU;
        //public string IS_SORUMLU
        //{
        //    get
        //    {
        //        if (this.AV001_TDI_BIL_IS_TAMAMLANMA_SUREs[0].AV001_TDI_BIL_CARI!=null)
        //            return _IS_SORUMLU = this.AV001_TDI_BIL_IS_TAMAMLANMA_SUREs[0].AV001_TDI_BIL_CARI.AD;
        //        return null;

        //    }
        //}

        //private string _IS_SUREC;
        //public string IS_SUREC
        //{
        //    get
        //    {
        //        if (this.AV001_TDI_BIL_IS_TAMAMLANMA_SUREs[0].AV001_TDI_KOD_IS_SUREC != null)
        //            return _IS_SUREC = this.AV001_TDI_BIL_IS_TAMAMLANMA_SUREs[0].AV001_TDI_KOD_IS_SUREC.IS_SUREC;
        //        return null;

        //    }
        //}

        //private DateTime? _BASLANGIC_ZAMANI;
        //public DateTime? BASLANGIC_ZAMANI
        //{
        //    get
        //    {
        //        if (this.AV001_TDI_BIL_IS_TAMAMLANMA_SUREs != null)
        //            return _BASLANGIC_ZAMANI = this.AV001_TDI_BIL_IS_TAMAMLANMA_SUREs[0].BASLANGIC_ZAMANI;
        //        return null;

        //    }
        //}

        //private DateTime? _BITIS_ZAMANI;
        //public DateTime? BITIS_ZAMANI
        //{
        //    get
        //    {
        //        if (this.AV001_TDI_BIL_IS_TAMAMLANMA_SUREs != null)
        //            return _BITIS_ZAMANI = this.AV001_TDI_BIL_IS_TAMAMLANMA_SUREs[0].BITIS_ZAMANI;
        //        return null;

        //    }
        //}

        //private string _SUREC_ACIKLAMA;
        //public string SUREC_ACIKLAMA
        //{
        //    get
        //    {
        //        if (this.AV001_TDI_BIL_IS_TAMAMLANMA_SUREs != null)
        //            return _SUREC_ACIKLAMA = this.AV001_TDI_BIL_IS_TAMAMLANMA_SUREs[0].SUREC_ACIKLAMA;
        //        return null;

        //    }
        //}

        //private bool? _MUHASEBELESTILMIS_MI;
        //public bool? MUHASEBELESTILMIS_MI
        //{
        //    get
        //    {
        //        if (this.AV001_TDI_BIL_IS_TAMAMLANMA_SUREs != null)
        //            return _MUHASEBELESTILMIS_MI = this.AV001_TDI_BIL_IS_TAMAMLANMA_SUREs[0].MUHASEBELESTILMIS_MI;
        //        return null;

        //    }
        //}
    }
}