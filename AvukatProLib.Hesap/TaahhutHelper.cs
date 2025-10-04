using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvukatProLib.Hesap
{
    public class AlacaklariGrupla
    {
        /// <summary>
        /// Seçili Alacak Nedenlerine bağlı gruplama yapar
        /// </summary>
        /// <param name="foy"></param>
        /// <param name="alacaklar"></param>
        /// <param name="gayriNakitlerDahil"></param>
        public AlacaklariGrupla(AV001_TI_BIL_FOY foy, List<AV001_TI_BIL_ALACAK_NEDEN> alacaklar, bool gayriNakitlerDahil)
        {
            List<SimulasyonBirimi> birimListesi = new List<SimulasyonBirimi>();
            var nakitAlacaklar = alacaklar;
            var dovizeGrupluAlacakNedenleri = nakitAlacaklar.GroupBy(vi => vi.TUTAR_DOVIZ_ID);

            var eklenenFaizler = new List<AV001_TI_BIL_FAIZ>();
            foreach (var alacakNedenGrubu in dovizeGrupluAlacakNedenleri)
            {
                foreach (var aNeden in alacakNedenGrubu)
                {
                    TList<AV001_TI_BIL_ODEME_DAGILIM> dagilimListesi = new TList<AV001_TI_BIL_ODEME_DAGILIM>();
                    TList<AV001_TI_BIL_FAIZ> faizListesi = aNeden.AV001_TI_BIL_FAIZCollection;

                    //Ödeme dağılımları alacak neden taraflarına göre yapılmış,
                    //tarafların üzerinden o alacak nedenine ilişkin ödemeleri toplamaya çalışıyoruz
                    aNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.ForEach(delegate(AV001_TI_BIL_ALACAK_NEDEN_TARAF obj)
                    {
                        if (obj.AV001_TI_BIL_ODEME_DAGILIMCollection.Count == 0)
                            DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepLoad(obj, false,
                                DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));

                        dagilimListesi.AddRange(obj.AV001_TI_BIL_ODEME_DAGILIMCollection);
                    });

                    dagilimListesi.AddRange(aNeden.AV001_TI_BIL_ODEME_DAGILIMCollection);
                    var odemeler = dagilimListesi.Select(vi => new ParaVeDovizId(vi.TUTAR, vi.TUTAR_DOVIZ_ID)).ToList();
                    var faizler = faizListesi.Select(vi => new ParaVeDovizId(vi.FAIZ_TUTARI, vi.FAIZ_TUTARI_DOVIZ_ID)).ToList();

                    
                    var odemeToplami = ParaVeDovizId.Topla(odemeler);
                    var faizToplami = ParaVeDovizId.Topla(faizler);

                    var tutar = new ParaVeDovizId(aNeden.TUTARI, aNeden.TUTAR_DOVIZ_ID);

                    tutar = ParaVeDovizId.Cikart(tutar, odemeToplami);

                    SimulasyonBirimi birim = new SimulasyonBirimi(alacakNedenGrubu.Key ?? 1);

                    birim.ParaAsilAlacak = tutar;
                    birim.ParaFaizler = faizToplami;
                    birim.ParaBirimi = alacakNedenGrubu.Key ?? 1;

                    if (aNeden.ALACAK_NEDEN_KOD_IDSource == null)
                        DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(aNeden, false, DeepLoadType.IncludeChildren, typeof(TI_KOD_ALACAK_NEDEN));
                    if ((gayriNakitlerDahil && (aNeden.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.HasValue && aNeden.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.Value && !aNeden.VADE_TARIHI.HasValue)))
                    {
                        aNeden.TO_UYGULANACAK_FAIZ_ORANI = aNeden.UYGULANACAK_FAIZ_ORANI = 0;
                        birimListesi.Add(birim);
                    }
                    else if (!(aNeden.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.HasValue && aNeden.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.Value))
                    {
                        birimListesi.Add(birim);
                    }
                }
            }

            var harclar = new List<ParaVeDovizId>(
                new[]
                {
                    //Bakiye Karar ve İlam Harcı
                    //Karar Düzeltme Harcı
                    //new ParaVeDovizId(foy.PESIN_HARC, foy.PESIN_HARC_DOVIZ_ID),
                    //Temyiz Harcı
                    //new ParaVeDovizId(foy.DAMGA_PULU, foy.DAMGA_PULU_DOVIZ_ID),
                    //new ParaVeDovizId(foy.BASVURMA_HARCI, foy.BASVURMA_HARCI_DOVIZ_ID),
                    //new ParaVeDovizId(foy.PESIN_HARC, foy.PESIN_HARC_DOVIZ_ID),
                    //new ParaVeDovizId(foy.MASAYA_KATILMA_HARCI, foy.MASAYA_KATILMA_HARCI_DOVIZ_ID),
                    //new ParaVeDovizId(foy.PAYLASMA_HARCI, foy.PAYLASMA_HARCI_DOVIZ_ID),
                    //new ParaVeDovizId(foy.VEKALET_PULU, foy.VEKALET_PULU_DOVIZ_ID),
                    //new ParaVeDovizId(foy.VEKALET_HARCI, foy.VEKALET_HARCI_DOVIZ_ID),
                    new ParaVeDovizId(foy.TAHLIYE_HARCI, foy.TAHLIYE_HARCI_DOVIZ_ID),
                    new ParaVeDovizId(foy.TESLIM_HARCI, foy.TESLIM_HARCI_DOVIZ_ID),
                    new ParaVeDovizId(foy.FERAGAT_HARCI, foy.FERAGAT_HARCI_DOVIZ_ID),
                    new ParaVeDovizId(foy.ODENEN_TAHSIL_HARCI,foy.ODENEN_TAHSIL_HARCI_DOVIZ_ID)
                    //new ParaVeDovizId(foy.DEPO_HARCI, foy.DEPO_HARCI_DOVIZ_ID)
                });
            //if (foy.BAKIYE_HARC_TOPLAMA_EKLE)
            harclar.Add(new ParaVeDovizId(foy.KALAN_TAHSIL_HARCI, foy.KALAN_TAHSIL_HARCI_DOVIZ_ID));

            var vergiler = new List<ParaVeDovizId>(
                new[]
                {
                    new ParaVeDovizId(foy.BSMV_TO,foy.BSMV_TO_DOVIZ_ID),
                    new ParaVeDovizId(foy.BSMV_TS,foy.BSMV_TS_DOVIZ_ID),
                    new ParaVeDovizId(foy.KDV_TO, foy.KDV_TO_DOVIZ_ID),
                    new ParaVeDovizId(foy.KDV_TS, foy.KDV_TS_DOVIZ_ID),
                    new ParaVeDovizId(foy.KKDV_TO, foy.KKDV_TO_DOVIZ_ID),
                    new ParaVeDovizId(foy.OIV_TO, foy.OIV_TO_DOVIZ_ID),
                    new ParaVeDovizId(foy.OIV_TS, foy.OIV_TS_DOVIZ_ID)
                });

            var vekaletUcreti = new List<ParaVeDovizId>(
                new[]
                {
                    new ParaVeDovizId(foy.IT_VEKALET_UCRETI,foy.IT_VEKALET_UCRETI_DOVIZ_ID),
                    new ParaVeDovizId(foy.TAKIP_VEKALET_UCRETI,foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID),
                    new ParaVeDovizId(foy.DAVA_VEKALET_UCRETI, foy.DAVA_VEKALET_UCRETI_DOVIZ_ID),
                    new ParaVeDovizId(foy.TD_VEK_UCR,foy.TD_VEK_UCR_DOVIZ_ID),
                    //Adli Yardım Vekalet Ücreti
                    //CMK Vekalet Ücreti
                    //Dava Edilen Vekalet Ücreti
                    //İstinaf Vekalet Ücreti
                    //Tedbir Vekalet Ücreti
                    //Temyiz Vekalet Ücreti
                    //Tespit Vekalet Ücreti
                    new ParaVeDovizId(foy.DEPO_VEKALET_UCRETI,foy.DEPO_VEKALET_UCRET_DOVIZ_ID),
                    new ParaVeDovizId(foy.IH_VEKALET_UCRETI,foy.IH_VEKALET_UCRETI_DOVIZ_ID),
                    new ParaVeDovizId(foy.TAHLIYE_VEK_UCR,foy.TAHLIYE_VEK_UCR_DOVIZ_ID),
                    new ParaVeDovizId(foy.ILAM_VEK_UCR, foy.ILAM_VEK_UCR_DOVIZ_ID),
                });

            var masraflar = new List<ParaVeDovizId>(
                new[]
                {
                    new ParaVeDovizId(foy.TO_MASRAF_TOPLAMI,foy.TO_MASRAF_TOPLAMI_DOVIZ_ID),
                    new ParaVeDovizId(foy.TS_MASRAF_TOPLAMI,foy.TS_MASRAF_TOPLAMI_DOVIZ_ID),
                    new ParaVeDovizId(foy.ILK_TEBLIGAT_GIDERI, foy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID),
                    new ParaVeDovizId(foy.IHTAR_GIDERI, foy.IHTAR_GIDERI_DOVIZ_ID),
                    new ParaVeDovizId(foy.PROTESTO_GIDERI, foy.PROTESTO_GIDERI_DOVIZ_ID),
                    new ParaVeDovizId(foy.IH_GIDERI,foy.IH_GIDERI_DOVIZ_ID),
                    new ParaVeDovizId(foy.IT_GIDERI,foy.IT_GIDERI_DOVIZ_ID),
                    new ParaVeDovizId(foy.ILAM_TEBLIG_GIDERI, foy.ILAM_TEBLIG_GIDERI_DOVIZ_ID),
                    new ParaVeDovizId(foy.ILAM_YARGILAMA_GIDERI, foy.ILAM_YARGILAMA_GIDERI_DOVIZ_ID)
                });

            var tazminatlar = new List<ParaVeDovizId>(
                new[]
                {
                    new ParaVeDovizId(foy.CEK_KOMISYONU, foy.CEK_KOMISYONU_DOVIZ_ID),
                    new ParaVeDovizId(foy.KARSILIKSIZ_CEK_TAZMINATI, foy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID),
                    new ParaVeDovizId(foy.SONRAKI_TAZMINAT, foy.SONRAKI_TAZMINAT_DOVIZ_ID),
                    new ParaVeDovizId(foy.ILAM_INKAR_TAZMINATI, foy.ILAM_INKAR_TAZMINATI_DOVIZ_ID),
                    new ParaVeDovizId(foy.ICRA_INKAR_TAZMINATI, foy.ICRA_INKAR_TAZMINATI_DOVIZ_ID),
                    new ParaVeDovizId(foy.DAVA_INKAR_TAZMINATI, foy.DAVA_INKAR_TAZMINATI_DOVIZ_ID),
                    new ParaVeDovizId(foy.SONRAKI_TAZMINAT, foy.SONRAKI_TAZMINAT_DOVIZ_ID),
                    new ParaVeDovizId(foy.OZEL_TAZMINAT, foy.OZEL_TAZMINAT_DOVIZ_ID) // Cezai Şart
                });

            var digerAsilAlacak = new List<ParaVeDovizId>(
                new[]
                {
                    new ParaVeDovizId(foy.OZEL_TUTAR1, foy.OZEL_TUTAR1_DOVIZ_ID),
                    new ParaVeDovizId(foy.OZEL_TUTAR2, foy.OZEL_TUTAR2_DOVIZ_ID),
                    new ParaVeDovizId(foy.OZEL_TUTAR3, foy.OZEL_TUTAR3_DOVIZ_ID),
                });

            SimulasyonBirimi foyBirimi = new SimulasyonBirimi(1)
            {
                //ParaAsilAlacak = ParaVeDovizId.Topla(digerAsilAlacak),
                ParaVekaletUcreti = ParaVeDovizId.Topla(vekaletUcreti),
                ParaHarclar = ParaVeDovizId.Topla(harclar),
                ParaMasraflar = ParaVeDovizId.Topla(masraflar),
                ParaTazminatlar = ParaVeDovizId.Topla(tazminatlar),
                ParaVergiler = ParaVeDovizId.Topla(vergiler)
            };
            foyBirimi.ParaBirimi = foyBirimi.ParaDiger.DovizId;

            birimListesi.Add(foyBirimi);

            BirimListesi = birimListesi;

            BirimleriTekeIndir();
        }

        private List<SimulasyonBirimi> _BirimListesi;

        public List<SimulasyonBirimi> BirimListesi
        {
            get { return _BirimListesi; }
            set
            {
                _BirimListesi = value;

                if (value != null)
                {
                    foreach (var item in value)
                    {
                        item.SecimYapildi += new EventHandler<EventArgs>(item_SecimYapildi);
                    }
                }
            }
        }

        private void BirimleriTekeIndir()
        {
            var gruplular = this.BirimListesi.GroupBy(vi => vi.ParaBirimi);

            List<SimulasyonBirimi> yeniListe = new List<SimulasyonBirimi>();

            foreach (var grup in gruplular)
            {
                var alacakParalari = grup.Select(vi => new ParaVeDovizId(vi.ParaAsilAlacak.Para, vi.ParaAsilAlacak.DovizId)).ToList();
                var faizParalari = grup.Select(vi => new ParaVeDovizId(vi.ParaFaizler.Para, vi.ParaAsilAlacak.DovizId)).ToList();
                var digerParalari = grup.Select(vi => new ParaVeDovizId(vi.ParaDiger.Para, vi.ParaAsilAlacak.DovizId)).ToList();
                var vekaletParalari = grup.Select(vi => new ParaVeDovizId(vi.ParaVekaletUcreti.Para, vi.ParaAsilAlacak.DovizId)).ToList();
                var harcParalari = grup.Select(vi => new ParaVeDovizId(vi.ParaHarclar.Para, vi.ParaAsilAlacak.DovizId)).ToList();
                var masrafParalari = grup.Select(vi => new ParaVeDovizId(vi.ParaMasraflar.Para, vi.ParaAsilAlacak.DovizId)).ToList();
                var tazminatParalari = grup.Select(vi => new ParaVeDovizId(vi.ParaTazminatlar.Para, vi.ParaAsilAlacak.DovizId)).ToList();
                var vergiParalari = grup.Select(vi => new ParaVeDovizId(vi.ParaVergiler.Para, vi.ParaAsilAlacak.DovizId)).ToList();
                yeniListe.Add(new SimulasyonBirimi(grup.Key)
                    {
                        ParaDiger = ParaVeDovizId.Topla(digerParalari),
                        ParaFaizler = ParaVeDovizId.Topla(faizParalari),
                        ParaAsilAlacak = ParaVeDovizId.Topla(alacakParalari),
                        ParaVekaletUcreti = ParaVeDovizId.Topla(vekaletParalari),
                        ParaHarclar = ParaVeDovizId.Topla(harcParalari),
                        ParaMasraflar = ParaVeDovizId.Topla(masrafParalari),
                        ParaTazminatlar = ParaVeDovizId.Topla(tazminatParalari),
                        ParaVergiler = ParaVeDovizId.Topla(vergiParalari)
                    });
            }
            BirimListesi = yeniListe;
        }

        private void item_SecimYapildi(object sender, EventArgs e)
        {
            foreach (var item in _BirimListesi)
            {
                item.Secim = false;
            }
        }
    }

    /// <summary>
    /// Okan 28.05.2010 Alacak Nedenleri için kullanılacak
    /// </summary>
    public class AlacakNedenTmp : ICloneable
    {
        public AlacakNedenTmp(decimal tutar, double faizOran, double bsmvOran)
        {
            TUTARI = tutar;
            TO_UYGULANACAK_FAIZ_ORANI = faizOran;
            BSMV_ORANI = bsmvOran;
        }

        public decimal ANA_TOPLAM { get; set; }

        public decimal AYLIK_ANAPARA_ODEME { get; set; }

        public decimal AYLIK_BSMV
        {
            get
            {
                return AYLIK_DEVRE_FAIZI * Convert.ToDecimal(BSMV_ORANI) / 100;
            }
        }

        public decimal AYLIK_DEVRE_FAIZI
        {
            get
            {
                return TUTARI * Convert.ToDecimal(TO_UYGULANACAK_FAIZ_ORANI) / 1200;
            }
        }

        public decimal AYLIK_DIGER_ODEME
        {
            get
            {
                return AYLIK_TOPLAM_ODEME - AYLIK_ANAPARA_ODEME;
            }
        }

        public decimal AYLIK_TOPLAM_FAIZ
        {
            get
            {
                return AYLIK_DEVRE_FAIZI + AYLIK_BSMV;
            }
        }

        public decimal AYLIK_TOPLAM_ODEME { get; set; }

        public double BSMV_ORANI { get; set; }

        public decimal DEVRE_FAIZI { get; set; }

        public int FAIZ_GUNLERI { get; set; }

        public int ID { get; set; }

        public decimal ISLEMIS_FAIZ { get; set; }

        // Tutar + diğer giderler
        public double TO_UYGULANACAK_FAIZ_ORANI { get; set; }

        public int? TUTAR_DOVIZ_ID { get; set; }

        public decimal TUTARI { get; set; }

        public DateTime? VADE_TARIHI { get; set; }

        public override string ToString()
        {
            return String.Format("Tutar: {0} - Faiz Oranı: {1} - Aylık Ödeme: {2}", TUTARI, TO_UYGULANACAK_FAIZ_ORANI, AYLIK_ANAPARA_ODEME);
        }

        #region ICloneable Members

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion ICloneable Members
    }

    public class HesapKosulu
    {
        #region Properties

        private string _aciklama;
        private int _ay;

        private int _aydaBir;

        private AvukatProLib.Hesap.HesapYapar.FaizIsletimTipi _faizIsletimTipi;

        private double _faizOrani;

        private AV001_TI_BIL_FOY _foy;

        private int _gun;

        private HesapTipleri _hesapTipi;

        private bool _islemGordu;

        private ParaVeDovizId _odeme;

        private KosulSekli _sekil;

        private AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI _simulasyonCetveli;

        private DateTime _tarih;

        public string Aciklama
        {
            get { return _aciklama; }
            set { _aciklama = value; }
        }

        public int Ay
        {
            get { return _ay; }
            set { _ay = value; }
        }

        public int AydaBir
        {
            get { return _aydaBir; }
            set { _aydaBir = value; }
        }

        public AvukatProLib.Hesap.HesapYapar.FaizIsletimTipi FaizIsltimTipi
        {
            get { return _faizIsletimTipi; }
            set { _faizIsletimTipi = value; }
        }

        public double FaizOrani
        {
            get { return _faizOrani; }
            set { _faizOrani = value; }
        }

        public AV001_TI_BIL_FOY Foy
        {
            get { return _foy; }
            set { _foy = value; }
        }

        public int Gun
        {
            get { return _gun; }
            set { _gun = value; }
        }

        public HesapTipleri HesapTip
        {
            get { return _hesapTipi; }
            set { _hesapTipi = value; }
        }

        public bool IslemGordu
        {
            get { return _islemGordu; }
            set { _islemGordu = value; }
        }

        public ParaVeDovizId Odeme
        {
            get { return _odeme; }
            set { _odeme = value; }
        }

        public KosulSekli Sekil
        {
            get { return _sekil; }
            set { _sekil = value; }
        }

        public AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI SimulasyonCetveli
        {
            get
            {
                if (_simulasyonCetveli == null)
                {
                    if (this.Foy != null)
                        _simulasyonCetveli = HesapAraclari.SimilasyonHesapCetveli.GetSimilasyonCetveliByFoy(this.Foy);
                    else if (this.Foy == null)
                        return null;
                }
                return _simulasyonCetveli;
            }
            set
            {
                _simulasyonCetveli = value;
            }
        }

        public DateTime Tarih
        {
            get { return _tarih; }
            set { _tarih = value; }
        }

        #endregion Properties

        public enum HesapTipleri
        {
            Azalan = 1,
            BK84
        }

        public enum KosulSekli
        {
            Sekil1, Sekil2, Sekil3, Sekil4, Sekil5
        }

        public override string ToString()
        {
            return this.Aciklama;
        }
    }

    public class KlasoreTaahhut
    {
        public KlasoreTaahhut()
        {
        }

        public static AvukatProLib.Arama.AvpDataContext context = new AvukatProLib.Arama.AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

        public static AV001_TI_BIL_FOY IcraFoyleriniTopla(TList<AV001_TI_BIL_FOY> foyListesi)
        {
            HesapYapar hy = new HesapYapar();
            AV001_TI_BIL_FOY sahteFoy = new AV001_TI_BIL_FOY();

            foreach (var var in foyListesi)
            {
                AV001_TI_BIL_FOY hesapFoy = var;
                hy.IcraFoyHesapla(hesapFoy);
                TList<AV001_TI_BIL_FOY> tolanacakFoyler = new TList<AV001_TI_BIL_FOY>();
                tolanacakFoyler.Add(hesapFoy);
                tolanacakFoyler.Add(sahteFoy);

                sahteFoy = hy.TumFoyTopla(tolanacakFoyler, DateTime.Now);
                sahteFoy.SON_HESAP_TARIHI = hesapFoy.SON_HESAP_TARIHI;
            }
            sahteFoy.BIR_YIL_KAC_GUN = 365;
            return sahteFoy;
        }

        public static AV001_TI_BIL_FOY IcraFoyleriniTopla(List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA> foyListesi)
        {
            HesapYapar hy = new HesapYapar();
            AV001_TI_BIL_FOY sahteFoy = new AV001_TI_BIL_FOY();

            foreach (var var in foyListesi)
            {
                AV001_TI_BIL_FOY hesapFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(var.ID);
                hy.IcraFoyHesapla(hesapFoy);
                TList<AV001_TI_BIL_FOY> tolanacakFoyler = new TList<AV001_TI_BIL_FOY>();
                tolanacakFoyler.Add(hesapFoy);
                tolanacakFoyler.Add(sahteFoy);

                sahteFoy = hy.TumFoyTopla(tolanacakFoyler, DateTime.Now);
                sahteFoy.SON_HESAP_TARIHI = hesapFoy.SON_HESAP_TARIHI;
            }
            sahteFoy.BIR_YIL_KAC_GUN = 365;
            return sahteFoy;
        }

        public static AV001_TI_BIL_FOY IcraFoyleriniTopla(List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> foyListesi)
        {
            HesapYapar hy = new HesapYapar();
            AV001_TI_BIL_FOY sahteFoy = new AV001_TI_BIL_FOY();

            foreach (var var in foyListesi)
            {
                AV001_TI_BIL_FOY hesapFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(var.ID);
                hy.IcraFoyHesapla(hesapFoy);
                TList<AV001_TI_BIL_FOY> tolanacakFoyler = new TList<AV001_TI_BIL_FOY>();
                tolanacakFoyler.Add(hesapFoy);
                tolanacakFoyler.Add(sahteFoy);

                sahteFoy = hy.TumFoyTopla(tolanacakFoyler, DateTime.Now);
                sahteFoy.SON_HESAP_TARIHI = hesapFoy.SON_HESAP_TARIHI;
            }
            sahteFoy.BIR_YIL_KAC_GUN = 365;
            return sahteFoy;
        }
    }

    public class ManuelTaahhut
    {
        public ManuelTaahhut(AV001_TI_BIL_ALACAK_NEDEN alacakNedeni, AvukatProLib.Hesap.HesapKosulu.HesapTipleri hesapTipi, DateTime tarih, double faizOrani)
        {
            OdemeGruplari[MahsupKategori.Asil_Alacak].TUTARI = alacakNedeni.ISLEME_KONAN_TUTAR;
            OdemeGruplari[MahsupKategori.Faizler].TUTARI = decimal.Zero;
            FaizOrani = alacakNedeni.TO_UYGULANACAK_FAIZ_ORANI;
            HesapTipi = (int)hesapTipi;
            TaksitlendirmeBaslangicTarihi = tarih;
        }

        public ManuelTaahhut(ProjeTaahhut simulasyonCetveli, AvukatProLib.Hesap.HesapKosulu.HesapTipleri hesapTipi, DateTime tarih, double faizOrani)
        {
            OdemeGruplari[MahsupKategori.Asil_Alacak].TUTARI = DovizHelper.CevirYTL(simulasyonCetveli.ASIL_ALACAK, simulasyonCetveli.ASIL_ALACAK_DOVIZ_ID, simulasyonCetveli.SON_HESAP_TARIHI.Value);

            OdemeGruplari[MahsupKategori.Faizler].TUTARI = decimal.Zero;
            //OncekiFaizler = OdemeGruplari[MahsupKategori.Faizler].TUTARI;
            //DigerAlacaklar = DovizHelper.CevirYTL(simulasyonCetveli.KALAN, simulasyonCetveli.KALAN_DOVIZ_ID, simulasyonCetveli.SON_HESAP_TARIHI.Value)
            //                   - DovizHelper.CevirYTL(simulasyonCetveli.ASIL_ALACAK, simulasyonCetveli.ASIL_ALACAK_DOVIZ_ID, simulasyonCetveli.SON_HESAP_TARIHI.Value);

            HesapTipi = (int)hesapTipi;

            TaksitlendirmeBaslangicTarihi = tarih;

            FaizOrani = faizOrani;
            BirYilKacGun = simulasyonCetveli.BIR_YIL_KAC_GUN;
        }

        public ManuelTaahhut(AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI simulasyonCetveli, AvukatProLib.Hesap.HesapKosulu.HesapTipleri hesapTipi, DateTime tarih, double faizOrani)
        {
            OdemeGruplari[MahsupKategori.Asil_Alacak].TUTARI = simulasyonCetveli.ASIL_ALACAK; //DovizHelper.CevirYTL(simulasyonCetveli.ASIL_ALACAK, simulasyonCetveli.ASIL_ALACAK_DOVIZ_ID, simulasyonCetveli.SON_HESAP_TARIHI??tarih);

            OdemeGruplari[MahsupKategori.Faizler].TUTARI = simulasyonCetveli.FAIZ_TOPLAMI ?? 0; // decimal.Zero;
            //OncekiFaizler = OdemeGruplari[MahsupKategori.Faizler].TUTARI;
            //DigerAlacaklar = simulasyonCetveli.DIGER_GIDERLER;

            HesapTipi = (int)hesapTipi;

            TaksitlendirmeBaslangicTarihi = tarih;

            FaizOrani = faizOrani;
            BirYilKacGun = simulasyonCetveli.BIR_YIL_KAC_GUN;
        }

        public ManuelTaahhut(List<AV001_TI_BIL_ALACAK_NEDEN> alacakNedenList, AV001_TI_BIL_FOY myFoy, AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI simulasyonCetveli, SimulasyonBirimi simulasyonBirimi, AvukatProLib.Hesap.HesapKosulu.HesapTipleri hesapTipi, DateTime tarih, double faizOrani, List<AV001_TI_KOD_HESAP_TIP_SIRA> hesapSiraListesi, bool HarcDahilMi)
        {
            AlacakNedenTableList = alacakNedenList;
            SimulasyonBirimi = simulasyonBirimi;
            AraOdemeler = new List<HesapKosulu>();
            masterChildOdemePlani = new Dictionary<AV001_TI_BIL_ODEME_PLANI, List<AV001_TI_BIL_ODEME_PLANI>>();
            IlkSatirlariOlustur();
            OdemeGrubuListesi = new List<OdemeGrupDataSource>();
            AlacakNedenTmp tmpAlacak = null;
            AlacakNedenleri = new List<AlacakNedenTmp>();
            AlacakNedenleriTmp = new List<AlacakNedenTmp>();

            HesapTipi = (int)hesapTipi;
            TaksitlendirmeBaslangicTarihi = tarih;
            FaizOrani = faizOrani;
            BirYilKacGun = simulasyonCetveli.BIR_YIL_KAC_GUN;

            //CurrentDay = alacakNedenList[0].ICRA_FOY_IDSource.SON_HESAP_TARIHI.HasValue ? alacakNedenList[0].ICRA_FOY_IDSource.SON_HESAP_TARIHI.Value : alacakNedenList.Min(vi => vi.VADE_TARIHI.Value);
            CurrentDay = myFoy.SON_HESAP_TARIHI.HasValue ? myFoy.SON_HESAP_TARIHI.Value : alacakNedenList.Min(vi => vi.VADE_TARIHI.Value);

            foreach (AV001_TI_BIL_ALACAK_NEDEN alacak in alacakNedenList)
            {
                tmpAlacak = new AlacakNedenTmp(alacak.TUTARI, alacak.TO_UYGULANACAK_FAIZ_ORANI, BsmvOrani);
                tmpAlacak.ID = alacak.ID;
                tmpAlacak.VADE_TARIHI = alacak.VADE_TARIHI;
                tmpAlacak.TUTAR_DOVIZ_ID = alacak.TUTAR_DOVIZ_ID;
                tmpAlacak.ISLEMIS_FAIZ = alacak.AV001_TI_BIL_FAIZCollection.Sum(vi => vi.FAIZ_TUTARI);
                AlacakNedenleri.Add(tmpAlacak);
            }
            this.HesapSiralamaTumu = hesapSiraListesi ?? AvukatProLib2.Data.DataRepository.AV001_TI_KOD_HESAP_TIP_SIRAProvider.GetAll().ToList();
            MahsupKategoriGetir();
            OdemeGruplariOlustur(HarcDahilMi, myFoy);
            OdemeGrubuListesi.Add(new OdemeGrupDataSource(OdemeGruplari, myFoy));
        }

        #region Mahsup Kategorileri ve Ödeme Grupları

        private void MahsupKategoriGetir()
        {
            var kategoriList = BelgeUtil.Inits.MahsupKategoriGetir();
            MahsupKategorileri = new Dictionary<int, List<MahsupKategori>>();
            MahsupKategorileri.Add((int)HesapKosulu.HesapTipleri.Azalan, HesapSiraList);
            MahsupKategorileri.Add((int)HesapKosulu.HesapTipleri.BK84, HesapSiraList);
        }

        private void OdemeGruplariOlustur(bool HarcDahilMi, AV001_TI_BIL_FOY myFoy)
        {
            OdemeGruplari = new Dictionary<MahsupKategori, Odeme>();

            foreach (var mahsupKategori in MahsupKategorileri[HesapTipi])
            {
                switch (mahsupKategori)
                {
                    case MahsupKategori.Faizler:
                        OdemeGruplari.Add(mahsupKategori, new Odeme(SimulasyonBirimi.FAIZLER));
                        break;

                    case MahsupKategori.Asil_Alacak:
                        OdemeGruplari.Add(mahsupKategori, new Odeme(SimulasyonBirimi.ASIL_ALACAK));
                        break;

                    case MahsupKategori.Diger_Asil_Alacak:
                        OdemeGruplari.Add(mahsupKategori, new Odeme(myFoy.OZEL_TUTAR1 + myFoy.OZEL_TUTAR2 + myFoy.OZEL_TUTAR3));
                        break;

                    case MahsupKategori.Harclar:
                        OdemeGruplari.Add(mahsupKategori, new Odeme(HarcDahilMi ? SimulasyonBirimi.HARCLAR : 0));
                        break;

                    case MahsupKategori.Vergiler:
                        OdemeGruplari.Add(mahsupKategori, new Odeme(SimulasyonBirimi.VERGILER));
                        break;

                    case MahsupKategori.Diger:
                        OdemeGruplari.Add(mahsupKategori, new Odeme(SimulasyonBirimi.DIGER));
                        break;

                    case MahsupKategori.Vekalet_Ucreti:
                        OdemeGruplari.Add(mahsupKategori, new Odeme(SimulasyonBirimi.VEKALET_UCRETI));
                        break;

                    case MahsupKategori.Masraflar:
                        OdemeGruplari.Add(mahsupKategori, new Odeme(SimulasyonBirimi.MASRAFLAR));
                        break;

                    case MahsupKategori.Tazminatlar:
                        OdemeGruplari.Add(mahsupKategori, new Odeme(SimulasyonBirimi.TAZMINATLAR));
                        break;
                }
            }

            OdemeGruplariIlkDeger = new Dictionary<MahsupKategori, Odeme>(); // 3. Hesap Koşulu için ilk değerler ayrı bir değişkende tutuluyor.
            foreach (var item in OdemeGruplari)
            {
                OdemeGruplariIlkDeger.Add(item.Key, new Odeme(item.Value.TUTARI));
            }
        }

        #endregion Mahsup Kategorileri ve Ödeme Grupları

        public List<decimal> AsilAlacakList = new List<decimal>();

        public DateTime CurrentDay = DateTime.Today;

        public DateTime CurrentDayIlkDeger = DateTime.Today;

        public Dictionary<AV001_TI_BIL_ODEME_PLANI, List<AV001_TI_BIL_ODEME_PLANI>> masterChildOdemePlani;

        private List<HesapKosulu> _AraOdemeler;

        private int _birYilKacGun;

        private decimal _bsmv;

        private double _bsmvOrani;

        private List<DateTime> _faizinEklendigiTarihler;

        private double _faizOrani;

        private int _hesapTipi;

        private double _kdvOrani;

        private double _kkdvOrani;

        private TList<AV001_TI_BIL_ODEME_PLANI> _odemeListesi;

        private double _oivOrani;

        private DateTime _tarih;

        private List<AlacakNedenTmp> AlacakNedenleri;

        private List<AlacakNedenTmp> AlacakNedenleriTmp;

        private bool DemoTaahhut = false;

        private List<decimal> DonemFaizList = new List<decimal>();

        private List<decimal> DonemFaizListTmp = new List<decimal>();

        private delegate decimal KalanHesapla();

        public static double BSMV_ORANI { get; set; }

        public static double KDV_ORANI { get; set; }

        public static double KKDV_ORANI { get; set; }

        public static double OIV_ORANI { get; set; }

        public List<HesapKosulu> AraOdemeler
        {
            get { return _AraOdemeler; }
            set { _AraOdemeler = value; }
        }

        public decimal AsilAlacak
        {
            get
            {
                if (OdemeGruplari == null) return 0;
                return OdemeGruplari[MahsupKategori.Asil_Alacak].TUTARI;
            }
            set
            {
                if (OdemeGruplari == null) return;
                OdemeGruplari[MahsupKategori.Asil_Alacak].TUTARI = value;
            }
        }

        public int BirYilKacGun
        {
            get { return _birYilKacGun; }
            set { _birYilKacGun = value; }
        }

        public decimal BSMV
        {
            get { return _bsmv; }
            set { _bsmv = value; }
        }

        public decimal BSMVIlkDeger { get; set; }

        public double BsmvOrani
        {
            get
            {
                if (_bsmvOrani == 0)
                {
                    _bsmvOrani = FaizHelper.DigerVergiOraniGetir(DigerVergiTuru.BSMV, this.TaksitlendirmeBaslangicTarihi);
                }
                BSMV_ORANI = _bsmvOrani;
                return _bsmvOrani;
            }
        }

        public decimal DigerAlacaklar
        {
            get
            {
                if (OdemeGruplari == null) return 0;
                return OdemeGruplari[MahsupKategori.Diger].TUTARI +
                    OdemeGruplari[MahsupKategori.Harclar].TUTARI +
                    OdemeGruplari[MahsupKategori.Masraflar].TUTARI +
                    OdemeGruplari[MahsupKategori.Tazminatlar].TUTARI +
                    OdemeGruplari[MahsupKategori.Vekalet_Ucreti].TUTARI +
                    OdemeGruplari[MahsupKategori.Vergiler].TUTARI;
            }
        }

        public decimal DigerlerineOdenen
        {
            get
            {
                if (OdemeGruplari == null) return 0;
                return OdemeGruplari[MahsupKategori.Diger].ODEME_TUTARI +
                    OdemeGruplari[MahsupKategori.Harclar].ODEME_TUTARI +
                    OdemeGruplari[MahsupKategori.Masraflar].ODEME_TUTARI +
                    OdemeGruplari[MahsupKategori.Tazminatlar].ODEME_TUTARI +
                    OdemeGruplari[MahsupKategori.Vekalet_Ucreti].ODEME_TUTARI +
                    OdemeGruplari[MahsupKategori.Vergiler].ODEME_TUTARI;
            }
        }

        public List<DateTime> FaizinEklendigiTarihler
        {
            get { return _faizinEklendigiTarihler; }
            set { _faizinEklendigiTarihler = value; }
        }

        public decimal FaizlerToplami
        {
            get
            {
                if (OdemeGruplari == null) return 0;
                return OdemeGruplari[MahsupKategori.Faizler].TUTARI;
            }
            set
            {
                if (OdemeGruplari == null) return;
                OdemeGruplari[MahsupKategori.Faizler].TUTARI = value;
            }
        }

        public double FaizOrani
        {
            get { return _faizOrani; }
            set { _faizOrani = value; }
        }

        public List<AV001_TI_KOD_HESAP_TIP_SIRA> HesapSiralamaTumu { get; set; }

        public int HesapTipi
        {
            get { return _hesapTipi; }
            set { _hesapTipi = value; }
        }

        public decimal KalanTutar
        {
            get
            {
                if (OdemeGruplari == null) return 0;
                return OdemeGruplari.Values.Sum(item => item.TUTARI);
            }
        }

        public double KdvOrani
        {
            get
            {
                if (_kdvOrani == 0)
                {
                    _kdvOrani = FaizHelper.KDVOraniGetir(6, this.TaksitlendirmeBaslangicTarihi);
                }
                KDV_ORANI = _kdvOrani;
                return _kdvOrani;
            }
        }

        public DateTime? KesitTarihi { get; set; }

        public double KkdvOrani
        {
            get
            {
                if (_kkdvOrani == 0)
                {
                    _kkdvOrani = FaizHelper.DigerVergiOraniGetir(DigerVergiTuru.KKDF, this.TaksitlendirmeBaslangicTarihi);
                }
                KKDV_ORANI = _kkdvOrani;
                return _kkdvOrani;
            }
        }

        public Dictionary<int, List<MahsupKategori>> MahsupKategorileri { get; set; }

        public List<OdemeGrupDataSource> OdemeGrubuListesi { get; set; }

        public Dictionary<MahsupKategori, Odeme> OdemeGruplari { get; set; }

        public Dictionary<MahsupKategori, Odeme> OdemeGruplariIlkDeger { get; set; }

        public TList<AV001_TI_BIL_ODEME_PLANI> OdemeListesi
        {
            get
            {
                if (_odemeListesi == null)
                    _odemeListesi = new TList<AV001_TI_BIL_ODEME_PLANI>();

                return _odemeListesi;
            }
            set
            {
                _odemeListesi = value;
            }
        }

        public int OdemePlanSayisi { get; set; }

        public double OivOrani
        {
            get
            {
                if (_oivOrani == 0)
                {
                    _oivOrani = FaizHelper.DigerVergiOraniGetir(DigerVergiTuru.ÖİV, this.TaksitlendirmeBaslangicTarihi);
                }
                OIV_ORANI = _oivOrani;
                return _oivOrani;
            }
        }

        public SimulasyonBirimi SimulasyonBirimi { get; set; }

        // _._._ tarihi itibariyle bakiye göstermek için eklendi. Okan
        public bool SonOdemeYapildi { get; set; }

        public DateTime TaksitlendirmeBaslangicTarihi
        {
            get { return _tarih; }
            set { _tarih = value; }
        }

        public DateTime TarihIlkDeger { get; set; }

        private List<AV001_TI_BIL_ALACAK_NEDEN> AlacakNedenTableList { get; set; }

        private List<MahsupKategori> HesapSiraList
        {
            get
            {
                return this.HesapSirasi(this.HesapTipi)
                    .OrderBy(vi => vi.SIRA_NO)
                    .Select(vi => (MahsupKategori)vi.MAHSUP_KATEGORI_ID)
                    .ToList();
            }
        }

        // Hatalı kullanılmayacak // Okan
        public static List<DateTime> BankaDonemleri(DateTime sayac, HesapYapar.FaizIsletimTipi fIslemTipi)
        {
            if (fIslemTipi == HesapYapar.FaizIsletimTipi.Uc_Aylik_Standart_devrelerde_faiz_anaparaya_ilave_edilsin)
            {
                List<DateTime> list = new List<DateTime>();

                list.Add(new DateTime(sayac.Year - 1, 3, 31));
                list.Add(new DateTime(sayac.Year - 1, 6, 30));
                list.Add(new DateTime(sayac.Year - 1, 9, 30));
                list.Add(new DateTime(sayac.Year - 1, 12, 31));

                list.Add(new DateTime(sayac.Year, 3, 31));
                list.Add(new DateTime(sayac.Year, 6, 30));
                list.Add(new DateTime(sayac.Year, 9, 30));
                list.Add(new DateTime(sayac.Year, 12, 31));

                list.Add(new DateTime(sayac.Year + 1, 3, 31));
                list.Add(new DateTime(sayac.Year + 1, 6, 30));
                list.Add(new DateTime(sayac.Year + 1, 9, 30));
                list.Add(new DateTime(sayac.Year + 1, 12, 31));

                return list;
            }
            else if (fIslemTipi == HesapYapar.FaizIsletimTipi.Ay_sonlarinda_aylik_faiz_anaparaya_ilave_edilsin)
            {
                List<DateTime> list = new List<DateTime>();

                list.Add(new DateTime(sayac.Year - 1, 1, 31));
                list.Add(new DateTime(sayac.Year - 1, 2, DateTime.DaysInMonth(sayac.Year, 2)));
                list.Add(new DateTime(sayac.Year - 1, 3, 31));
                list.Add(new DateTime(sayac.Year - 1, 4, 30));
                list.Add(new DateTime(sayac.Year - 1, 5, 31));
                list.Add(new DateTime(sayac.Year - 1, 6, 30));
                list.Add(new DateTime(sayac.Year - 1, 7, 31));
                list.Add(new DateTime(sayac.Year - 1, 8, 31));
                list.Add(new DateTime(sayac.Year - 1, 9, 30));
                list.Add(new DateTime(sayac.Year - 1, 10, 31));
                list.Add(new DateTime(sayac.Year - 1, 11, 30));
                list.Add(new DateTime(sayac.Year - 1, 12, 31));

                list.Add(new DateTime(sayac.Year, 1, 31));
                list.Add(new DateTime(sayac.Year, 2, DateTime.DaysInMonth(sayac.Year, 2)));
                list.Add(new DateTime(sayac.Year, 3, 31));
                list.Add(new DateTime(sayac.Year, 4, 30));
                list.Add(new DateTime(sayac.Year, 5, 31));
                list.Add(new DateTime(sayac.Year, 6, 30));
                list.Add(new DateTime(sayac.Year, 7, 31));
                list.Add(new DateTime(sayac.Year, 8, 31));
                list.Add(new DateTime(sayac.Year, 9, 30));
                list.Add(new DateTime(sayac.Year, 10, 31));
                list.Add(new DateTime(sayac.Year, 11, 30));
                list.Add(new DateTime(sayac.Year, 12, 31));

                list.Add(new DateTime(sayac.Year + 1, 1, 31));
                list.Add(new DateTime(sayac.Year + 1, 2, DateTime.DaysInMonth(sayac.Year + 1, 2)));
                list.Add(new DateTime(sayac.Year + 1, 3, 31));
                list.Add(new DateTime(sayac.Year + 1, 4, 30));
                list.Add(new DateTime(sayac.Year + 1, 5, 31));
                list.Add(new DateTime(sayac.Year + 1, 6, 30));
                list.Add(new DateTime(sayac.Year + 1, 7, 31));
                list.Add(new DateTime(sayac.Year + 1, 8, 31));
                list.Add(new DateTime(sayac.Year + 1, 9, 30));
                list.Add(new DateTime(sayac.Year + 1, 10, 31));
                list.Add(new DateTime(sayac.Year + 1, 11, 30));
                list.Add(new DateTime(sayac.Year + 1, 12, 31));

                return list;
            }
            else if (fIslemTipi == HesapYapar.FaizIsletimTipi.Yil_sonlari_itibariyle_yillik_faiz_anaparaya_ilave_edilsin)
            {
                List<DateTime> list = new List<DateTime>();
                list.Add(new DateTime(sayac.Year - 1, 12, 31));
                list.Add(new DateTime(sayac.Year, 12, 31));
                list.Add(new DateTime(sayac.Year + 1, 12, 31));
                return list;
            }
            return null;
        }

        public static List<DateTime> BankaDonemleri(DateTime odemeYapilacakTarih, DateTime vadeTarihi, HesapYapar.FaizIsletimTipi fIslemTipi)
        {
            int year = vadeTarihi.Year;
            List<DateTime> list = new List<DateTime>();
            if (fIslemTipi == HesapYapar.FaizIsletimTipi.Temerrut_itibariyle_3_Aylik_devrelerde_faiz_anaparaya_ilave_edilsin)
            {
                while (odemeYapilacakTarih.Date >= vadeTarihi.Date)
                {
                    vadeTarihi = vadeTarihi.AddMonths(3);
                    if (odemeYapilacakTarih.Date >= vadeTarihi.Date)
                        list.Add(vadeTarihi);
                }
                return list;
            }
            else if (fIslemTipi == HesapYapar.FaizIsletimTipi.Uc_Aylik_Standart_devrelerde_faiz_anaparaya_ilave_edilsin)
            {
                DateTime tempTarih = vadeTarihi;
                while (odemeYapilacakTarih.Date >= vadeTarihi.Date)
                {
                    if (vadeTarihi.Month % 3 > 0)
                        vadeTarihi = vadeTarihi.AddMonths(3 - (vadeTarihi.Month % 3));
                    vadeTarihi = vadeTarihi.AddDays(DateTime.DaysInMonth(vadeTarihi.Year, vadeTarihi.Month) - vadeTarihi.Day);

                    tempTarih = tempTarih.AddMonths(3 - (vadeTarihi.Month % 3));
                    tempTarih = tempTarih.AddDays(DateTime.DaysInMonth(tempTarih.Year, tempTarih.Month) - tempTarih.Day);

                    if (odemeYapilacakTarih.Date >= vadeTarihi.Date)
                    {
                        list.Add(vadeTarihi);
                        vadeTarihi = tempTarih;
                    }
                }
                return list;
            }
            else if (fIslemTipi == HesapYapar.FaizIsletimTipi.Temerrut_itibariyle_aylik_faiz_anaparaya_ilave_edilsin)
            {
                while (odemeYapilacakTarih.Date >= vadeTarihi.Date)
                {
                    vadeTarihi = vadeTarihi.AddMonths(1);
                    if (odemeYapilacakTarih.Date >= vadeTarihi.Date)
                        list.Add(vadeTarihi);
                }
                return list;
            }
            else if (fIslemTipi == HesapYapar.FaizIsletimTipi.Ay_sonlarinda_aylik_faiz_anaparaya_ilave_edilsin)
            {
                while (odemeYapilacakTarih.Date >= vadeTarihi.Date)
                {
                    vadeTarihi = vadeTarihi.AddMonths(1);
                    vadeTarihi = vadeTarihi.AddDays(DateTime.DaysInMonth(vadeTarihi.Year, vadeTarihi.Month));
                    if (odemeYapilacakTarih.Date >= vadeTarihi.Date)
                        list.Add(vadeTarihi);
                }
                return list;
            }
            else if (fIslemTipi == HesapYapar.FaizIsletimTipi.Temerrut_itibariyle_yillik_faiz_anaparaya_ilave_edilsin)
            {
                while (odemeYapilacakTarih.Date >= vadeTarihi.Date)
                {
                    vadeTarihi = vadeTarihi.AddYears(1);
                    list.Add(vadeTarihi);
                }
                return list;
            }
            else if (fIslemTipi == HesapYapar.FaizIsletimTipi.Yil_sonlari_itibariyle_yillik_faiz_anaparaya_ilave_edilsin)
            {
                while (odemeYapilacakTarih.Date >= vadeTarihi.Date)
                {
                    vadeTarihi = vadeTarihi.AddYears(1).AddMonths(12 - vadeTarihi.Month).AddDays(31 - vadeTarihi.Day);
                    if (odemeYapilacakTarih.Date >= vadeTarihi.Date)
                        list.Add(vadeTarihi);
                }
                return list;
            }
            return null;
        }

        // Okan
        public Dictionary<AV001_TI_BIL_ODEME_PLANI, List<AV001_TI_BIL_ODEME_PLANI>> ManuelTaahutHesabiModel1(HesapKosulu gelenKosul, AV001_TI_BIL_FOY myFoy)//(AV001_TI_BIL_FOY myFoy, int inciGunu, decimal odenerekBitsin, DateTime tarih, HesapKosulu gelenKosul, double faizOrani,int aydaBir)
        {
            return ManuelTaahutHesabiModel1(0, gelenKosul, myFoy);
        }

        /// <summary>
        /// N Ayda bir N tutarını Ödeyerek Bitir
        /// </summary>
        /// <param name="myFoy"></param>
        /// <param name="inciGunu"></param>
        /// <param name="odenerekBitsin"></param>
        /// <param name="tarih"></param>
        /// <param name="gelenKosul"></param>
        /// <param name="faizOrani"></param>
        /// <param name="aydaBir"></param>
        /// <returns></returns>
        public Dictionary<AV001_TI_BIL_ODEME_PLANI, List<AV001_TI_BIL_ODEME_PLANI>> ManuelTaahutHesabiModel1(decimal Odeme, HesapKosulu gelenKosul, AV001_TI_BIL_FOY myFoy)
        {
            var mySimulasyonCetveli = gelenKosul.SimulasyonCetveli;

            bool devamEt = true;

            if (gelenKosul.Gun < DateTime.Today.Day && TaksitlendirmeBaslangicTarihi.Month == DateTime.Today.Month) TaksitlendirmeBaslangicTarihi = TaksitlendirmeBaslangicTarihi.AddMonths(1);
            int ay = TaksitlendirmeBaslangicTarihi.Month;
            DateTime OdemeYapilacakTarih = new DateTime(TaksitlendirmeBaslangicTarihi.Year, ay, gelenKosul.Gun);

            double faizOrani = FaizOrani;
            decimal onGorulenOdeme = decimal.Zero;

            onGorulenOdeme = Odeme > 0 ? Odeme : gelenKosul.Odeme.Para; // odenerekBitsin;

            int gecenAy = 0;
            int aydaBir = gelenKosul.AydaBir;

            do
            {
                SonsuzDonguKontrolu(OdemeListesi);

                if (KesitTarihi.HasValue && KesitTarihi.Value < OdemeYapilacakTarih)
                {
                    SonOdemeYapildi = true;
                    OdemeYapilacakTarih = KesitTarihi.Value;
                    onGorulenOdeme = 0;
                }

                gecenAy++;

                //     FaizAnaparaya(gtarih, gelenKosul, FaizinEklendigiTarihler, OdemeListesi);

                KeyValuePair<AV001_TI_BIL_ODEME_PLANI, List<AV001_TI_BIL_ODEME_PLANI>> planDetails = OdemeleriMahsupEt(gelenKosul, onGorulenOdeme, OdemeYapilacakTarih, gecenAy, out OdemeYapilacakTarih, out gecenAy, faizOrani, myFoy);

                AsilAlacakList.Add(OdemeGruplari[MahsupKategori.Asil_Alacak].TUTARI);
                OdemeListesi.Add(planDetails.Key);

                masterChildOdemePlani.Add(planDetails.Key, planDetails.Value); // Okan

                if (KalanTutar < 1 || SonOdemeYapildi)
                {
                    //Borç kalmadı artık çıkabiliriz
                    devamEt = false;
                }
                else
                {
                    CurrentDay = OdemeYapilacakTarih;
                    OdemeYapilacakTarih = OdemeYapilacakTarih.AddMonths(1);
                }

                planDetails.Key.BAKIYE = (KalanTutar);
                planDetails.Key.BAKIYE_DOVIZ_ID = planDetails.Key.ODEME_DOVIZ_ID;
            } while (devamEt);

            TaksitlendirmeBaslangicTarihi = OdemeYapilacakTarih;
            return masterChildOdemePlani;
        }

        public Dictionary<AV001_TI_BIL_ODEME_PLANI, List<AV001_TI_BIL_ODEME_PLANI>> ManuelTaahutHesabiModel2(HesapKosulu gelenKosul, bool useTarih, AV001_TI_BIL_FOY myFoy)
        {
            return ManuelTaahutHesabiModel2(gelenKosul, useTarih, true, myFoy);
        }

        /// <summary>
        /// N ay boyunca N tutarını öde
        /// </summary>
        /// <param name="myFoy"></param>
        /// <param name="incGunu"></param>
        /// <param name="odemeIle"></param>
        /// <param name="aydaOdensin"></param>
        /// <param name="tarih"></param>
        /// <param name="gelenKosul"></param>
        /// <param name="faizOrani"></param>
        /// <param name="aydaBir"></param>
        /// <returns></returns>
        public Dictionary<AV001_TI_BIL_ODEME_PLANI, List<AV001_TI_BIL_ODEME_PLANI>> ManuelTaahutHesabiModel2(HesapKosulu gelenKosul, bool useTarih, bool faizAnaparayaEkle, AV001_TI_BIL_FOY myFoy)
        {

            ///Simulasyon Cetveli çalışmasına geçilince parametre ezilerek yeni yapıya uyduruldu
            var mySimulasyonCetveli = gelenKosul.SimulasyonCetveli;

            #region Değerler

            decimal onGorulenOdeme = gelenKosul.Odeme.YtlHali;

            #endregion Değerler

            int ay = TaksitlendirmeBaslangicTarihi.Month;
            if (gelenKosul.Gun == 0) gelenKosul.Gun = 1;
            if (gelenKosul.Gun < DateTime.Today.Day && TaksitlendirmeBaslangicTarihi.Month == DateTime.Today.Month) ay++;

            if (ay == 13) ay = 1; //MB
            DateTime OdemeYapilacakTarih = new DateTime(TaksitlendirmeBaslangicTarihi.Year, ay, gelenKosul.Gun);

            int aydaOdensin = gelenKosul.Ay;
            int gecenAy = 0;
            double faizOrani = FaizOrani;
            int aydaBir = gelenKosul.AydaBir;

            if (useTarih)
            {
                OdemeYapilacakTarih = gelenKosul.Tarih;
                aydaOdensin = 1;
                gelenKosul.AydaBir = aydaBir = 1;
                if (!DemoTaahhut) gelenKosul.IslemGordu = true;
            }

            //TList<AV001_TI_BIL_ODEME_PLANI> OdemeListesi = new List<AV001_TI_BIL_ODEME_PLANI>();

            for (int i = 0; i < aydaOdensin; i++)
            {
                gecenAy++;

                if (KesitTarihi.HasValue && OdemeYapilacakTarih > KesitTarihi)
                {
                    SonOdemeYapildi = true;
                    OdemeYapilacakTarih = KesitTarihi.Value;
                    onGorulenOdeme = 0;
                }

                KeyValuePair<AV001_TI_BIL_ODEME_PLANI, List<AV001_TI_BIL_ODEME_PLANI>> planDetails = OdemeleriMahsupEt(gelenKosul, onGorulenOdeme, OdemeYapilacakTarih, gecenAy, out OdemeYapilacakTarih, out gecenAy, faizOrani, faizAnaparayaEkle, myFoy);

                CurrentDay = OdemeYapilacakTarih;
                OdemeYapilacakTarih = OdemeYapilacakTarih.AddMonths(1);

                AsilAlacakList.Add(OdemeGruplari[MahsupKategori.Asil_Alacak].TUTARI);
                //           OdemeListesi.Add(planDetails.Key);
                masterChildOdemePlani.Add(planDetails.Key, planDetails.Value); // Okan

                if (SonOdemeYapildi) break;
            }
            TaksitlendirmeBaslangicTarihi = OdemeYapilacakTarih;
            return masterChildOdemePlani;
        }

        /// <summary>
        /// N ayda bir ödeyerek  N Ayda bitir.
        /// </summary>
        /// <param name="myFoy"></param>
        /// <param name="incGunu"></param>
        /// <param name="aydaBitsin"></param>
        /// <param name="tarih"></param>
        /// <param name="gelenKosul"></param>
        /// <param name="faizOrani"></param>
        /// <param name="aydaBir"></param>
        /// <returns></returns>
        public Dictionary<AV001_TI_BIL_ODEME_PLANI, List<AV001_TI_BIL_ODEME_PLANI>> ManuelTaahutHesabiModel3(HesapKosulu gelenKosul, AV001_TI_BIL_FOY myFoy)//(AV001_TI_BIL_FOY myFoy, int incGunu, int aydaBitsin, DateTime tarih, HesapKosulu gelenKosul, double faizOrani,int aydaBir)
        {
            ///Simulasyon Cetveli yapısına geçilince parametre ezilmiştir
            var mySimulasyonCetveli = gelenKosul.SimulasyonCetveli;

            int days = 0;
            if (gelenKosul.Gun >= TaksitlendirmeBaslangicTarihi.Day)
            {
                days = (gelenKosul.Gun - DateTime.Today.Day) + 30 * (TaksitlendirmeBaslangicTarihi.Month - DateTime.Today.Month) + BirYilKacGun * (TaksitlendirmeBaslangicTarihi.Year - DateTime.Today.Year);
            }
            else
            {
                days = (DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) - gelenKosul.Gun) + 30 * (TaksitlendirmeBaslangicTarihi.Month - DateTime.Today.Month) + BirYilKacGun * (TaksitlendirmeBaslangicTarihi.Year - DateTime.Today.Year);
            }
            decimal taksitlendirmeBaslangicFaizi = (AlacakNedenleri.Sum(alacak => alacak.TUTARI) * Convert.ToDecimal(AlacakNedenleri[0].TO_UYGULANACAK_FAIZ_ORANI) / 36000 * days) * Convert.ToDecimal(1 + AlacakNedenleri[0].BSMV_ORANI / 100);

            DonemFaizListTmp = DonemFaizList.ToList();
            decimal onGorulenOdeme = OngorulenOdemeHesapla(AlacakNedenleri, gelenKosul, 0, AlacakNedenleri[0].BSMV_ORANI, AlacakNedenleri.Sum(item => item.TUTARI), OdemeGruplari[MahsupKategori.Faizler].TUTARI + DigerAlacaklar + taksitlendirmeBaslangicFaizi, myFoy);
            return ManuelTaahutHesabiModel1(onGorulenOdeme, gelenKosul, myFoy);
        }

        private static void SonsuzDonguKontrolu(TList<AV001_TI_BIL_ODEME_PLANI> odemeListesi)
        {
            if (odemeListesi.Count > 1500)
            {
                throw new Exception("Bu Koşullarla Hesap Tamamlanamaz! Koşulları Yeniden Değerlendiriniz.");
            }
        }

        private void FaizAnaparayaVeAraOdemeler(HesapKosulu gelenKosul, DateTime OdemeYapilacakTarih, AV001_TI_BIL_FOY myFoy)
        {
            #region Devrelere Göre Faizin Anaparaya Eklenmesi

            int faizGunleri = 0;
            Dictionary<DateTime, List<AlacakNedenTmp>> alacakDonemleri = new Dictionary<DateTime, List<AlacakNedenTmp>>();

            #region Banka Dönemleri getiriliyor

            // Tüm alacak nedenleri için en son ödeme yapılan tarih ve yeni ödemenin yapılacağı tarihler arasına düşen banka dönemleri (varsa) getiriliyor. // Okan
            for (int i = 0; i < AlacakNedenleri.Count; i++)
            {
                if ((int)gelenKosul.FaizIsltimTipi != 0)
                {
                    List<DateTime> bankaDonemleri = null;

                    if (((int)gelenKosul.FaizIsltimTipi == 1 || (int)gelenKosul.FaizIsltimTipi == 4 || (int)gelenKosul.FaizIsltimTipi == 5) && AlacakNedenleri[i].VADE_TARIHI.HasValue) //Standard devrelerde faizi anaparaya ekle
                        bankaDonemleri = BankaDonemleri(OdemeYapilacakTarih, CurrentDay, gelenKosul.FaizIsltimTipi);
                    else bankaDonemleri = BankaDonemleri(OdemeYapilacakTarih, AlacakNedenleri[i].VADE_TARIHI.Value, gelenKosul.FaizIsltimTipi);

                    foreach (var donem in bankaDonemleri)
                    {
                        if (!alacakDonemleri.ContainsKey(donem)) alacakDonemleri.Add(donem, new List<AlacakNedenTmp>() { AlacakNedenleri[i] });
                        else alacakDonemleri[donem].Add(AlacakNedenleri[i]);
                    }
                }
            }
            alacakDonemleri = alacakDonemleri.OrderBy(ad => ad.Key).ToDictionary(vi => vi.Key, vi => vi.Value);

            #endregion Banka Dönemleri getiriliyor

            List<DateTime> kullanilanDonemList = new List<DateTime>();
            decimal faiz = 0;

            #region Faizler Anaparaya ekleniyor ve Ara Ödemeler Mahsup ediliyor

            if (alacakDonemleri.Keys.Count == 0) //Banka dönemi bulunamadı varsa ara ödemeler mahsup edilecek.
            {
                #region Ara Ödemeler (Banka Dönemleiyle Ödeme Yapılacak Tarih arasında kalan zaman aralığında ara ödeme varsa mahsup ediliyor)

                AraOdemeleriMahsupEt(CurrentDay, OdemeYapilacakTarih, myFoy);

                #endregion Ara Ödemeler (Banka Dönemleiyle Ödeme Yapılacak Tarih arasında kalan zaman aralığında ara ödeme varsa mahsup ediliyor)
            }
            // Tüm banka dönemleri için faizler anaparalara ekleniyor ve varsa ara ödemeler mahsup ediliyor. // Okan
            foreach (var bankaDonem in alacakDonemleri.Keys)
            {
                if (KalanTutar == 0) break;
                if (bankaDonem.Date <= CurrentDay || (gelenKosul.Tarih != new DateTime() && bankaDonem.Date > gelenKosul.Tarih)) continue;

                #region Ara Ödemeler

                AraOdemeleriMahsupEt(CurrentDay, bankaDonem, myFoy);

                #endregion Ara Ödemeler

                faizGunleri = bankaDonem.Subtract(CurrentDay).Days;
                List<AlacakNedenTmp> aNedenleri = alacakDonemleri[bankaDonem];

                #region Faiz Anaparaya

                foreach (var neden in aNedenleri)
                {
                    faiz = ((neden.TUTARI * (decimal)neden.TO_UYGULANACAK_FAIZ_ORANI) / (gelenKosul.SimulasyonCetveli.BIR_YIL_KAC_GUN * 100) * faizGunleri);

                    neden.TUTARI += (faiz + neden.ISLEMIS_FAIZ);

                    OdemeGruplari[MahsupKategori.Asil_Alacak].TUTARI += (faiz + neden.ISLEMIS_FAIZ);
                    OdemeGruplari[MahsupKategori.Faizler].TUTARI -= neden.ISLEMIS_FAIZ;
                    OdemeGruplari[MahsupKategori.Vergiler].TUTARI += faiz * (decimal)(this.BsmvOrani / 100);
                    neden.ISLEMIS_FAIZ = 0;
                    neden.FAIZ_GUNLERI = faizGunleri;
                }

                #endregion Faiz Anaparaya

                CurrentDay = bankaDonem;

                kullanilanDonemList.Add(bankaDonem.Date);

                #region Faizin Anaparaya Eklendiği tarihler için Ödeme Planları oluşturuluyor

                AV001_TI_BIL_ODEME_PLANI plann = new AV001_TI_BIL_ODEME_PLANI();
                plann.ODEME = decimal.Zero;
                plann.ANA_PARAYA_ODENEN = plann.FAIZE_ODENEN = plann.DIGERLERINE_ODENEN = decimal.Zero;
                plann.ODEME_DOVIZ_ID = plann.BORC_TUTARI_DOVIZ_ID = plann.BAKIYE_DOVIZ_ID = plann.DEVRE_FAIZI_DOVIZ_ID = (gelenKosul.SimulasyonCetveli.ASIL_ALACAK_DOVIZ_ID ?? 1);
                plann.ANA_PARAYA_ODENEN_DOVIZ_ID = plann.FAIZE_ODENEN_DOVIZ_ID = plann.DIGERLERINE_ODENEN_DOVIZ_ID = gelenKosul.SimulasyonCetveli.ASIL_ALACAK_DOVIZ_ID;
                plann.DEVRE_FAIZI = faiz;
                plann.BORC_TUTARI = plann.BAKIYE = KalanTutar;
                plann.GUN = faizGunleri;
                plann.SIMULASYON_HESAP_CETVELI_IDSource = gelenKosul.SimulasyonCetveli;
                plann.KAYIT_TARIHI = DateTime.Today;
                plann.TARIH = bankaDonem;
                AsilAlacakList.Add(OdemeGruplari[MahsupKategori.Asil_Alacak].TUTARI);
                masterChildOdemePlani.Add(plann, new List<AV001_TI_BIL_ODEME_PLANI>());

                #endregion Faizin Anaparaya Eklendiği tarihler için Ödeme Planları oluşturuluyor

                #region Ara Ödemeler (Banka Dönemleiyle Ödeme Yapılacak Tarih arasında kalan zaman aralığında ara ödeme varsa mahsup ediliyor)

                AraOdemeleriMahsupEt(CurrentDay, OdemeYapilacakTarih, false, myFoy);

                #endregion Ara Ödemeler (Banka Dönemleiyle Ödeme Yapılacak Tarih arasında kalan zaman aralığında ara ödeme varsa mahsup ediliyor)
            }

            #endregion Faizler Anaparaya ekleniyor ve Ara Ödemeler Mahsup ediliyor

            #endregion Devrelere Göre Faizin Anaparaya Eklenmesi
        }

        /// <summary>
        /// Farklı faiz oranlarına sahip Alacak Nedenleri için faiz hesaplar
        /// </summary>
        /// <param name="alacaklar"></param>
        /// <param name="mySimulasyonCetveli"></param>
        /// <param name="faizOrani"></param>
        /// <param name="plan"></param>
        /// <param name="gtarih"></param>
        /// <param name="bsmv"></param>
        private void FaizGetir(HesapKosulu gelenKosul, AV001_TI_BIL_ODEME_PLANI plan, DateTime OdemeYapilacakTarih, decimal odeme, decimal digerAlacaklar, int hesapTipi, bool faizAnaparayaEkle, AV001_TI_BIL_FOY myFoy)
        {
            AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI mySimulasyonCetveli = gelenKosul.SimulasyonCetveli;
            decimal faiz = decimal.Zero;
            plan.DEVRE_FAIZI = decimal.Zero;

            if ((int)gelenKosul.FaizIsltimTipi != 0)
            {
                if (faizAnaparayaEkle)
                    FaizAnaparayaVeAraOdemeler(gelenKosul, OdemeYapilacakTarih, myFoy);
            }
            else if (gelenKosul.Sekil != HesapKosulu.KosulSekli.Sekil5)
                AraOdemeleriMahsupEt(CurrentDay, OdemeYapilacakTarih, myFoy);

            AlacakNedenleri = AlacakNedenleri.OrderBy(item => item.TO_UYGULANACAK_FAIZ_ORANI).ToList();
            plan.GUN = OdemeYapilacakTarih.Subtract(CurrentDay).Days;
            AlacakNedenleri.ForEach(item => item.FAIZ_GUNLERI = plan.GUN);

            foreach (var neden in AlacakNedenleri)
            {
                faiz = ((neden.TUTARI * (decimal)neden.TO_UYGULANACAK_FAIZ_ORANI) / (gelenKosul.SimulasyonCetveli.BIR_YIL_KAC_GUN * 100) * plan.GUN);
                //aykut ekrana vergilerin hesaplanması için silindi
                //OdemeGruplari[MahsupKategori.Vergiler].TUTARI += faiz * (decimal)(this.BsmvOrani / 100);
                OdemeGruplari[MahsupKategori.Faizler].TUTARI += faiz;
                neden.ISLEMIS_FAIZ += faiz;
                plan.DEVRE_FAIZI += faiz;

                AV001_TI_BIL_ALACAK_NEDEN aa = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID(neden.ID);

                if (aa.BSMV_HESAPLANSIN)
                {
                    OdemeGruplari[MahsupKategori.Vergiler].TUTARI += faiz * (decimal)(this.BsmvOrani / 100);
                    gelenKosul.SimulasyonCetveli.BSMV_TS += faiz * (decimal)(this.BsmvOrani / 100);
                }

                if (aa.KKDV_HESAPLANSIN)
                {
                    OdemeGruplari[MahsupKategori.Vergiler].TUTARI += faiz * (decimal)(this.KkdvOrani / 100);
                    gelenKosul.SimulasyonCetveli.KKDV_TO = faiz * (decimal)(this.KkdvOrani / 100);
                }

                if (aa.KDV_HESAPLANSIN)
                {
                    OdemeGruplari[MahsupKategori.Vergiler].TUTARI += faiz * (decimal)(this.KdvOrani / 100);
                    gelenKosul.SimulasyonCetveli.KDV_TS += faiz * (decimal)(this.KdvOrani / 100);
                }

                if (aa.OIV_HESAPLANSIN)
                {
                    OdemeGruplari[MahsupKategori.Vergiler].TUTARI += faiz * (decimal)(this.OivOrani / 100);
                    gelenKosul.SimulasyonCetveli.OIV_TS += faiz * (decimal)(this.OivOrani / 100);
                }
            }

            plan.BORC_TUTARI = KalanTutar;
        }

        private List<AV001_TI_KOD_HESAP_TIP_SIRA> HesapSirasi(int hesapTipId)
        {
            return this.HesapSiralamaTumu.FindAll(vi => vi.HESAP_TIP_ID == hesapTipId);
        }

        /// <summary>
        /// Ödeme Planı listesine ilk değerlerin olduğu bir satır oluşturarak listenin başına ekler
        /// </summary>
        private void IlkSatirlariOlustur()
        {
            foreach (var item in AlacakNedenTableList.OrderBy(vi => vi.VADE_TARIHI))
            {
                AV001_TI_BIL_ODEME_PLANI plan = new AV001_TI_BIL_ODEME_PLANI();
                plan.BORC_TUTARI = item.TUTARI;
                plan.BORC_TUTARI_DOVIZ_ID = item.TUTAR_DOVIZ_ID ?? 1;
                plan.ODEME = 0;
                plan.ODEME_DOVIZ_ID = item.TUTAR_DOVIZ_ID ?? 1;
                if (item.VADE_TARIHI.HasValue)//Vade Tarihi Null geldiğinden hata verdiğinden kontrol eklendi. MB
                    plan.TARIH = item.VADE_TARIHI.Value;
                plan.ANA_PARAYA_ODENEN = plan.FAIZE_ODENEN = plan.DIGERLERINE_ODENEN = 0;
                plan.ANA_PARAYA_ODENEN_DOVIZ_ID = plan.FAIZE_ODENEN_DOVIZ_ID = plan.DIGERLERINE_ODENEN_DOVIZ_ID = plan.DEVRE_FAIZI_DOVIZ_ID = plan.BAKIYE_DOVIZ_ID = item.TUTAR_DOVIZ_ID ?? 1;
                plan.BAKIYE = item.TUTARI;
                plan.DEVRE_FAIZI = 0;
                plan.FAIZ_ORAN = item.TO_UYGULANACAK_FAIZ_ORANI;
                //masterChildOdemePlani.Add(plan, new List<AV001_TI_BIL_ODEME_PLANI>());
            }
        }

        private void OdemeEkle(Odeme odeme)
        {
            foreach (var mahsupKategori in MahsupKategorileri[HesapTipi])
            {
                OdemeGruplari[mahsupKategori].OdemeCıkar(odeme);
                if (odeme.TUTARI == 0) break;
            }
        }

        private List<AV001_TI_BIL_ODEME_PLANI> OdemeleriDagit(Odeme anaparaya, Odeme faize)
        {
            List<AV001_TI_BIL_ODEME_PLANI> planList = new List<AV001_TI_BIL_ODEME_PLANI>();
            //Alacak Nedenleri faiz oranına göre sıralanıyor ve ödeme tutarları düşülüyor
            foreach (var aNeden in AlacakNedenleri.OrderBy(vi => vi.TO_UYGULANACAK_FAIZ_ORANI))
            {
                AV001_TI_BIL_ODEME_PLANI childPlan = new AV001_TI_BIL_ODEME_PLANI();
                childPlan.FAIZ_ORAN = aNeden.TO_UYGULANACAK_FAIZ_ORANI;
                childPlan.GUN = aNeden.FAIZ_GUNLERI;
                childPlan.BORC_TUTARI = aNeden.TUTARI + aNeden.ISLEMIS_FAIZ;
                childPlan.DEVRE_FAIZI = aNeden.DEVRE_FAIZI;

                #region Anaparaya Ödeme

                if (aNeden.TUTARI >= anaparaya.TUTARI)
                {
                    childPlan.ANA_PARAYA_ODENEN = anaparaya.TUTARI;
                    aNeden.TUTARI -= anaparaya.TUTARI;
                    anaparaya.TUTARI = 0;
                }
                else
                {
                    childPlan.ANA_PARAYA_ODENEN = aNeden.TUTARI;
                    anaparaya.TUTARI -= aNeden.TUTARI;
                    aNeden.TUTARI = 0;
                }

                #endregion Anaparaya Ödeme

                #region Faize Ödeme

                if (aNeden.ISLEMIS_FAIZ >= faize.TUTARI)
                {
                    childPlan.FAIZE_ODENEN = faize.TUTARI;
                    aNeden.ISLEMIS_FAIZ -= faize.TUTARI;
                    faize.TUTARI = 0;
                }
                else
                {
                    childPlan.FAIZE_ODENEN = aNeden.ISLEMIS_FAIZ;
                    faize.TUTARI -= aNeden.ISLEMIS_FAIZ;
                    aNeden.ISLEMIS_FAIZ = 0;
                }

                #endregion Faize Ödeme

                childPlan.ODEME = (childPlan.ANA_PARAYA_ODENEN ?? 0) + (childPlan.FAIZE_ODENEN ?? 0);
                childPlan.DIGERLERINE_ODENEN = 0;
                childPlan.BAKIYE = childPlan.BORC_TUTARI - (childPlan.ANA_PARAYA_ODENEN ?? 0) - (childPlan.FAIZE_ODENEN ?? 0);
                planList.Add(childPlan);
            }
            return planList;
        }

        // Okan
        private KeyValuePair<AV001_TI_BIL_ODEME_PLANI, List<AV001_TI_BIL_ODEME_PLANI>> OdemeleriMahsupEt(HesapKosulu gelenKosul, decimal onGorulenOdeme, DateTime gtarih1, int gecenAy1, out DateTime OdemeYapilacakTarih, out int gecenAy, double faizOrani, AV001_TI_BIL_FOY myFoy)
        {
            return OdemeleriMahsupEt(gelenKosul, onGorulenOdeme, gtarih1, gecenAy1, out OdemeYapilacakTarih, out gecenAy, faizOrani, true, myFoy);
        }

        private KeyValuePair<AV001_TI_BIL_ODEME_PLANI, List<AV001_TI_BIL_ODEME_PLANI>> OdemeleriMahsupEt(HesapKosulu gelenKosul, decimal onGorulenOdeme, DateTime gtarih1, int gecenAy1, out DateTime OdemeYapilacakTarih, out int gecenAy, double faizOrani, bool faizAnaparayaEkle, AV001_TI_BIL_FOY myFoy)
        {
            AV001_TI_BIL_ODEME_PLANI plan = new AV001_TI_BIL_ODEME_PLANI();
            List<AV001_TI_BIL_ODEME_PLANI> childPlanList = null;
            int aydaBir = gelenKosul.AydaBir;
            gecenAy = gecenAy1;
            OdemeYapilacakTarih = gtarih1;

            #region Hesap

            plan.BORC_TUTARI = KalanTutar;

            decimal odeme = (gecenAy == aydaBir) ? onGorulenOdeme : decimal.Zero;

            FaizGetir(gelenKosul, plan, OdemeYapilacakTarih, odeme, this.DigerAlacaklar, HesapTipi, faizAnaparayaEkle, myFoy);

            plan.FAIZ_ORAN = faizOrani;
            plan.TARIH = OdemeYapilacakTarih;

            plan.ODEME_DOVIZ_ID = gelenKosul.SimulasyonCetveli.ASIL_ALACAK_DOVIZ_ID ?? 1;

            if (gecenAy == aydaBir)
            {
                #region Ödemeler düşülüyor

                gecenAy = 0;

                OdemeEkle(new Odeme(onGorulenOdeme));

                plan.ODEME_DOVIZ_ID = gelenKosul.SimulasyonCetveli.ASIL_ALACAK_DOVIZ_ID ?? 1;
                plan.ODEME = OdemeGruplari.Values.Sum(item => item.ODEME_TUTARI);

                #region Ödemeler Alacak Nedenleri arasında dağıtılıyor

                childPlanList = OdemeleriDagit(new Odeme(OdemeGruplari[MahsupKategori.Asil_Alacak].ODEME_TUTARI), new Odeme(OdemeGruplari[MahsupKategori.Faizler].ODEME_TUTARI));

                if (!DemoTaahhut) OdemeGrubuListesi.Add(new OdemeGrupDataSource(OdemeGruplari, myFoy));

                #endregion Ödemeler Alacak Nedenleri arasında dağıtılıyor

                #endregion Ödemeler düşülüyor
            }

            plan.BAKIYE = OdemeGruplari.Values.Sum(item => item.TUTARI);
            plan.BAKIYE_DOVIZ_ID = plan.ODEME_DOVIZ_ID;

            plan.ANA_PARAYA_ODENEN = OdemeGruplari[MahsupKategori.Asil_Alacak].ODEME_TUTARI;
            plan.FAIZE_ODENEN = OdemeGruplari[MahsupKategori.Faizler].ODEME_TUTARI;
            plan.DIGERLERINE_ODENEN = DigerlerineOdenen;
            plan.DIGERLERINE_ODENEN_DOVIZ_ID = plan.ODEME_DOVIZ_ID;
            plan.FAIZE_ODENEN_DOVIZ_ID = plan.ODEME_DOVIZ_ID;
            plan.ANA_PARAYA_ODENEN_DOVIZ_ID = plan.ODEME_DOVIZ_ID;
            plan.ODEME_DOVIZ_ID = plan.ODEME_DOVIZ_ID;
            plan.BORC_TUTARI_DOVIZ_ID = plan.ODEME_DOVIZ_ID;
            plan.DEVRE_FAIZI_DOVIZ_ID = plan.ODEME_DOVIZ_ID;

            #endregion Hesap

            KeyValuePair<AV001_TI_BIL_ODEME_PLANI, List<AV001_TI_BIL_ODEME_PLANI>> odemePlanlari = new KeyValuePair<AV001_TI_BIL_ODEME_PLANI, List<AV001_TI_BIL_ODEME_PLANI>>(plan, childPlanList);
            return odemePlanlari;
        }

        #region Ara Ödemeler

        private List<HesapKosulu> IslemGorenKosulList = new List<HesapKosulu>();

        private HesapKosulu AraOdemeKosulGetir(DateTime sonOdemeYapilanTarih, DateTime donemTarihi)
        {
            if (AraOdemeler == null || AraOdemeler.Count == 0) return null;
            var odemeler = AraOdemeler.Where(odeme => !odeme.IslemGordu && odeme.Tarih < donemTarihi && odeme.Tarih > sonOdemeYapilanTarih);
            if (odemeler == null || odemeler.Count() == 0) return null;
            if (DemoTaahhut) IslemGorenKosulList.Add(odemeler.First());
            return odemeler.First();
        }

        private void AraOdemeleriMahsupEt(DateTime sonOdemeYapilanTarih, DateTime donemTarihi, AV001_TI_BIL_FOY myFoy)
        {
            AraOdemeleriMahsupEt(sonOdemeYapilanTarih, donemTarihi, true, myFoy);
        }

        private void AraOdemeleriMahsupEt(DateTime sonOdemeYapilanTarih, DateTime donemTarihi, bool faizAnaparayaEkle, AV001_TI_BIL_FOY myFoy)
        {
            var odeme = AraOdemeKosulGetir(sonOdemeYapilanTarih, donemTarihi);
            if (odeme != null) ManuelTaahutHesabiModel2(odeme, true, faizAnaparayaEkle, myFoy);
        }

        #endregion Ara Ödemeler

        #region 3. Koşul için yardımcı metodlar

        public static double OrtalamaFaizOraniHesapla(List<AlacakNedenTmp> alacaklar)
        {
            return Convert.ToDouble(alacaklar.Sum(item => item.TUTARI * Convert.ToDecimal(item.TO_UYGULANACAK_FAIZ_ORANI)) / alacaklar.Sum(item => item.TUTARI));
        }

        public static double OrtalamaFaizOraniHesapla(List<AV001_TI_BIL_ALACAK_NEDEN> alacaklar)
        {
            if (alacaklar == null || alacaklar.Count == 0 || alacaklar.Sum(item => item.TUTARI) == 0) return 0;
            return Convert.ToDouble(alacaklar.Sum(item => item.TUTARI * Convert.ToDecimal(item.TO_UYGULANACAK_FAIZ_ORANI)) / alacaklar.Sum(item => item.TUTARI));
        }

        /// <summary>
        /// Aylık ödeme hesaplar - Okan 28.05.2010
        /// </summary>
        /// <param name="months"></param>
        /// <param name="interestRate"></param>
        /// <param name="principal"></param>
        /// <param name="expense"></param>
        private decimal AylikOdemeHesapla(int months, double interestRate, double bsmvRate, decimal principal, decimal expense, bool firstMonthIncluded)
        {
            int tmpMonths = months;
            if (!firstMonthIncluded) tmpMonths = months - 1;
            double monthlyInterestRate = interestRate / 1200;
            double bsmvIncludedRate = 1 + bsmvRate / 100;
            decimal monthlyPayment = ((tmpMonths * Convert.ToDecimal(monthlyInterestRate * bsmvIncludedRate) * principal) + principal + expense) / Convert.ToDecimal(months + (months * (months - 1) / 2) * monthlyInterestRate * bsmvIncludedRate);
            return monthlyPayment;
        }

        private decimal OdemeFarkiHesapla(List<AlacakNedenTmp> alacaklar, HesapKosulu gelenKosul, decimal ongorulenOdeme, AV001_TI_BIL_FOY myFoy)
        {
            decimal odeme = 0;
            OdemeListesi.Clear();
            alacaklar.Clear();
            AlacakNedenleri.ForEach(item => alacaklar.Add((AlacakNedenTmp)item.Clone()));
            this.DonemFaizListTmp = this.DonemFaizList.ToList();
            ManuelTaahutHesabiModel1(ongorulenOdeme, gelenKosul, myFoy);
            IslemGorenKosulList.ForEach(kosul => kosul.IslemGordu = false);
            IslemGorenKosulList.Clear();
            TutarlariYenile();
            int araOdemeCount = 0;//AraOdemeler.Count(odm => OdemeListesi[0].TARIH <= odm.Tarih && OdemeListesi.Last().TARIH >= odm.Tarih);
            if (OdemeListesi.Count == 1) return OdemeListesi[0].ODEME;
            if (OdemeListesi.Count > gelenKosul.Ay + araOdemeCount)
            {
                for (int i = gelenKosul.Ay; i < OdemeListesi.Count; i++)
                {
                    odeme += OdemeListesi[i].ODEME;
                }
                odeme = odeme / gelenKosul.Ay;
                return OdemeFarkiHesapla(alacaklar, gelenKosul, ongorulenOdeme + odeme, myFoy);
            }
            else if (OdemeListesi.Count < gelenKosul.Ay + araOdemeCount)
            {
                for (int i = 0; i < OdemeListesi.Count; i++)
                {
                    odeme += OdemeListesi[i].ODEME;
                }
                odeme = odeme / gelenKosul.Ay;
                return OdemeFarkiHesapla(alacaklar, gelenKosul, ongorulenOdeme - odeme, myFoy);
            }
            else
            {
                //odeme = (OdemeListesi[OdemeListesi.Count - 2].ODEME - OdemeListesi.Last().ODEME);
                odeme = (OdemeListesi.First().ODEME - (OdemeListesi.Sum(vi => vi.ODEME) / OdemeListesi.Count));
                if (Math.Round(odeme, 2, MidpointRounding.AwayFromZero) == 0) return Math.Round(ongorulenOdeme, 2, MidpointRounding.AwayFromZero) + (decimal)0.01;
                odeme /= gelenKosul.Ay;
                return OdemeFarkiHesapla(alacaklar, gelenKosul, ongorulenOdeme - odeme, myFoy);
            }
        }

        /// <summary>
        /// Her ayın n. günü ödensin x ayda bitsin koşulu için öngörülen ödeme hesaplar.
        /// </summary>
        /// <param name="alacaklar"></param>
        /// <param name="months"></param>
        /// <param name="interestRate"></param>
        /// <param name="bsmvRate"></param>
        /// <param name="principal"></param>
        /// <param name="expense"></param>
        /// <returns></returns>
        private decimal OngorulenOdemeHesapla(List<AlacakNedenTmp> alacaklar, HesapKosulu gelenKosul, double interestRate, double bsmvRate, decimal principal, decimal expense, AV001_TI_BIL_FOY myFoy)
        {
            int months = gelenKosul.Ay;
            decimal onGorulenOdeme = 0;
            double faizOran = interestRate;
            TutarlariDemoYap();
            if (alacaklar != null) // Değişken faiz oranı
            {
                faizOran = OrtalamaFaizOraniHesapla(alacaklar);
            }
            onGorulenOdeme = AylikOdemeHesapla(months, faizOran, bsmvRate, principal, expense, false);
            onGorulenOdeme = OdemeFarkiHesapla(new List<AlacakNedenTmp>(), gelenKosul, onGorulenOdeme, myFoy);
            OdemeListesi.Clear();
            DemoTaahhut = false;
            return onGorulenOdeme;
        }

        private void TutarlariDemoYap()
        {
            DemoTaahhut = true;
            OdemePlanSayisi = masterChildOdemePlani.Keys.Count;
            BSMVIlkDeger = BSMV;
            TarihIlkDeger = TaksitlendirmeBaslangicTarihi;
            CurrentDayIlkDeger = CurrentDay;

            AlacakNedenleriTmp.Clear();
            foreach (var item in AlacakNedenleri)
            {
                AlacakNedenleriTmp.Add((AlacakNedenTmp)item.Clone());
            }

            OdemeGruplariIlkDeger.Clear();
            foreach (var item in OdemeGruplari)
            {
                OdemeGruplariIlkDeger.Add(item.Key, new Odeme(item.Value.TUTARI));
            }
        }

        private void TutarlariYenile()
        {
            BSMV = BSMVIlkDeger;
            TaksitlendirmeBaslangicTarihi = TarihIlkDeger;
            CurrentDay = CurrentDayIlkDeger;

            AlacakNedenleri.Clear();
            foreach (var item in AlacakNedenleriTmp)
            {
                AlacakNedenleri.Add((AlacakNedenTmp)item.Clone());
            }

            OdemeGruplari.Clear();
            foreach (var item in OdemeGruplariIlkDeger)
            {
                OdemeGruplari.Add(item.Key, new Odeme(item.Value.TUTARI));
            }

            int silinecekOdemePlanSayisi = masterChildOdemePlani.Keys.Count - OdemePlanSayisi;
            for (int i = 0; i < silinecekOdemePlanSayisi; i++)
            {
                masterChildOdemePlani.Remove(masterChildOdemePlani.Keys.Last()); // Sonradan eklenen ödeme planları siliniyor.
            }
        }

        #endregion 3. Koşul için yardımcı metodlar
    }

    public class Odeme
    {
        public Odeme(decimal tutar)
        {
            TUTARI = tutar;
        }

        public decimal ODEME_TOPLAMI { get; set; }

        public decimal ODEME_TUTARI { get; set; }

        public decimal TOPLAM { get { return ODEME_TOPLAMI + TUTARI; } }

        public decimal TUTARI { get; set; }

        public void OdemeCıkar(Odeme tutar)
        {
            if (TUTARI >= tutar.TUTARI)
            {
                ODEME_TUTARI = tutar.TUTARI;
                TUTARI -= tutar.TUTARI;
                ODEME_TOPLAMI += ODEME_TUTARI;
                tutar.TUTARI = 0;
            }
            else
            {
                ODEME_TUTARI = TUTARI;
                tutar.TUTARI -= TUTARI;
                ODEME_TOPLAMI += ODEME_TUTARI;
                TUTARI = 0;
            }
        }
    }

    public class OdemeGrubu : AV001_TI_BIL_ODEME_PLANI
    {
        public OdemeGrubu(TList<AV001_TI_BIL_ODEME_PLANI> odemePlanlari)
        {
            OdemePlanlari = odemePlanlari;

            OdemeleriTopla();
            BorcTutariToplami();
            DevreFaiziHesapla();
            FaizeOdenenTopla();
            AnaParayaOdenenTopla();
            DigerlereOdenenTopla();
        }

        public override decimal? ANA_PARAYA_ODENEN
        {
            get
            {
                return base.ANA_PARAYA_ODENEN;
            }
            set
            {
                base.ANA_PARAYA_ODENEN = value;
            }
        }

        public override decimal BORC_TUTARI
        {
            get
            {
                return base.BORC_TUTARI;
            }
            set
            {
                base.BORC_TUTARI = value;
            }
        }

        public override decimal DEVRE_FAIZI
        {
            get
            {
                return base.DEVRE_FAIZI;
            }
            set
            {
                base.DEVRE_FAIZI = value;
            }
        }

        public override decimal? DIGERLERINE_ODENEN
        {
            get
            {
                return base.DIGERLERINE_ODENEN;
            }
            set
            {
                base.DIGERLERINE_ODENEN = value;
            }
        }

        public override decimal? FAIZE_ODENEN
        {
            get
            {
                return base.FAIZE_ODENEN;
            }
            set
            {
                base.FAIZE_ODENEN = value;
            }
        }

        public override decimal ODEME
        {
            get
            {
                return base.ODEME;
            }
            set
            {
                base.ODEME = value;
            }
        }

        public TList<AV001_TI_BIL_ODEME_PLANI> OdemePlanlari { get; set; }

        #region Methots

        public static int AyFarki(DateTime bundan, DateTime buna)
        {
            int fark = 0;
            DateTime Bundan = bundan <= buna ? bundan : buna;
            DateTime Buna = buna >= bundan ? buna : bundan;

            while (Bundan.Year != Buna.Year || Bundan.Month != Buna.Month)
            {
                Bundan = Bundan.AddMonths(1);
                fark++;
            }

            return fark;
        }

        private void AnaParayaOdenenTopla()
        {
            if (OdemePlanlari.Count > 0)
            {
                var paralar = OdemePlanlari.Select(vi => new ParaVeDovizId(vi.ANA_PARAYA_ODENEN, vi.ANA_PARAYA_ODENEN_DOVIZ_ID)).ToList();

                var toplam = ParaVeDovizId.Topla(paralar);

                this.ANA_PARAYA_ODENEN = toplam.Para;
                this.ANA_PARAYA_ODENEN_DOVIZ_ID = toplam.DovizId;
            }
        }

        private void BorcTutariToplami()
        {
            if (OdemePlanlari != null && OdemePlanlari.Count() > 0)
            {
                var borcTutarlari = OdemePlanlari.OrderByDescending(vi => vi.TARIH).First();

                BORC_TUTARI = borcTutarlari.BORC_TUTARI;
                BORC_TUTARI_DOVIZ_ID = borcTutarlari.BORC_TUTARI_DOVIZ_ID;
                TARIH = borcTutarlari.TARIH;
            }
        }

        private void DevreFaiziHesapla()
        {
            if (OdemePlanlari.Count > 0)
            {
                var paralar = OdemePlanlari.Select(vi => new ParaVeDovizId(vi.DEVRE_FAIZI, vi.DEVRE_FAIZI_DOVIZ_ID)).ToList();

                ParaVeDovizId toplam = ParaVeDovizId.Topla(paralar);

                this.DEVRE_FAIZI = toplam.Para;
                this.DEVRE_FAIZI_DOVIZ_ID = toplam.DovizId;
            }
        }

        private void DigerlereOdenenTopla()
        {
            if (OdemePlanlari.Count > 0)
            {
                var paralar = OdemePlanlari.Select(vi => new ParaVeDovizId(vi.DIGERLERINE_ODENEN, vi.DIGERLERINE_ODENEN_DOVIZ_ID)).ToList();

                var toplam = ParaVeDovizId.Topla(paralar);

                this.DIGERLERINE_ODENEN = toplam.Para;
                this.DIGERLERINE_ODENEN_DOVIZ_ID = toplam.DovizId;
            }
        }

        private void FaizeOdenenTopla()
        {
            if (OdemePlanlari.Count > 0)
            {
                var paralar = OdemePlanlari.Select(vi => new ParaVeDovizId(vi.FAIZE_ODENEN, vi.FAIZE_ODENEN_DOVIZ_ID)).ToList();

                var toplam = ParaVeDovizId.Topla(paralar);

                this.FAIZE_ODENEN = toplam.Para;
                this.FAIZE_ODENEN_DOVIZ_ID = toplam.DovizId;
            }
        }

        private void OdemeleriTopla()
        {
            if (OdemePlanlari.Count > 0)
            {
                var paralar = OdemePlanlari.Select(vi => new ParaVeDovizId(vi.ODEME, vi.ODEME_DOVIZ_ID)).ToList();

                var toplam = ParaVeDovizId.Topla(paralar);

                this.ODEME = toplam.Para;
                this.ODEME_DOVIZ_ID = toplam.DovizId;
            }
        }

        #endregion Methots
    }

    public class OdemeGrupDataSource
    {
        public OdemeGrupDataSource(Dictionary<MahsupKategori, Odeme> OdemeGruplari, AV001_TI_BIL_FOY myFoy)
        {
            Faizler = OdemeGruplari[MahsupKategori.Faizler].TUTARI;
            Faizler_Odeme = OdemeGruplari[MahsupKategori.Faizler].ODEME_TUTARI;
            Asil_Alacak = OdemeGruplari[MahsupKategori.Asil_Alacak].TUTARI;
            Asil_Alacak_Odeme = OdemeGruplari[MahsupKategori.Asil_Alacak].ODEME_TUTARI;
            Diger_Asil_Alacak = OdemeGruplari[MahsupKategori.Diger_Asil_Alacak].TUTARI + myFoy.OZEL_TAZMINAT + myFoy.OZEL_TUTAR1 + myFoy.OZEL_TUTAR2 + myFoy.OZEL_TUTAR3;
            Diger_Asil_Alacak_Odeme = OdemeGruplari[MahsupKategori.Diger_Asil_Alacak].ODEME_TUTARI;
            Harclar = OdemeGruplari[MahsupKategori.Harclar].TUTARI;
            Harclar_Odeme = OdemeGruplari[MahsupKategori.Harclar].ODEME_TUTARI;
            Vergiler = OdemeGruplari[MahsupKategori.Vergiler].TUTARI;
            Vergiler_Odeme = OdemeGruplari[MahsupKategori.Vergiler].ODEME_TUTARI;
            Diger = OdemeGruplari[MahsupKategori.Diger].TUTARI;
            Diger_Odeme = OdemeGruplari[MahsupKategori.Diger].ODEME_TUTARI;
            Vekalet_Ucreti = OdemeGruplari[MahsupKategori.Vekalet_Ucreti].TUTARI;
            Vekalet_Ucreti_Odeme = OdemeGruplari[MahsupKategori.Vekalet_Ucreti].ODEME_TUTARI;
            Masraflar = OdemeGruplari[MahsupKategori.Masraflar].TUTARI;
            Masraflar_Odeme = OdemeGruplari[MahsupKategori.Masraflar].ODEME_TUTARI;
            Tazminatlar = OdemeGruplari[MahsupKategori.Tazminatlar].TUTARI;
            Tazminatlar_Odeme = OdemeGruplari[MahsupKategori.Tazminatlar].ODEME_TUTARI;
        }

        public decimal Asil_Alacak { get; set; }

        public decimal Asil_Alacak_Odeme { get; set; }

        public decimal Diger { get; set; }

        public decimal Diger_Asil_Alacak { get; set; }

        public decimal Diger_Asil_Alacak_Odeme { get; set; }

        public decimal Diger_Odeme { get; set; }

        public decimal Faizler { get; set; }

        public decimal Faizler_Odeme { get; set; }

        public decimal Harclar { get; set; }

        public decimal Harclar_Odeme { get; set; }

        public decimal Masraflar { get; set; }

        public decimal Masraflar_Odeme { get; set; }

        public decimal Tazminatlar { get; set; }

        public decimal Tazminatlar_Odeme { get; set; }

        public decimal Vekalet_Ucreti { get; set; }

        public decimal Vekalet_Ucreti_Odeme { get; set; }

        public decimal Vergiler { get; set; }

        public decimal Vergiler_Odeme { get; set; }
    }

    public class ProjeTaahhut : AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI
    {
        public ProjeTaahhut(List<OdemeGrubu> odemeGruplari)
        {
            this.OdemeGruplari = odemeGruplari;
            this.AsilAlacakHesapla();
        }

        public override decimal ASIL_ALACAK
        {
            get
            {
                return base.ASIL_ALACAK;
            }
            set
            {
                base.ASIL_ALACAK = value;
            }
        }

        public List<OdemeGrubu> OdemeGruplari { get; set; }

        #region Methots

        private void AsilAlacakHesapla()
        {
            if (OdemeGruplari.Count > 0)
            {
                List<ParaVeDovizId> borcTutarlari = OdemeGruplari.Select(vi => new ParaVeDovizId(vi.BORC_TUTARI, vi.BORC_TUTARI_DOVIZ_ID)).ToList();
                List<ParaVeDovizId> anaParayaOdenenler = OdemeGruplari.Select(vi => new ParaVeDovizId(vi.ANA_PARAYA_ODENEN, vi.ANA_PARAYA_ODENEN_DOVIZ_ID)).ToList();
                List<ParaVeDovizId> faizler = OdemeGruplari.Select(vi => new ParaVeDovizId(vi.DEVRE_FAIZI, vi.DEVRE_FAIZI_DOVIZ_ID)).ToList();
                List<ParaVeDovizId> faizeOdenenler = OdemeGruplari.Select(vi => new ParaVeDovizId(vi.FAIZE_ODENEN, vi.FAIZE_ODENEN_DOVIZ_ID)).ToList();

                ParaVeDovizId odemedenKalanFaiz = ParaVeDovizId.Cikart(ParaVeDovizId.Topla(faizler), ParaVeDovizId.Topla(faizeOdenenler));
                this.FAIZ_TOPLAMI = odemedenKalanFaiz.Para;
                this.FAIZ_TOPLAMI_DOVIZ_ID = odemedenKalanFaiz.DovizId;

                ParaVeDovizId odemedenKalanBorcTutari = ParaVeDovizId.Cikart(ParaVeDovizId.Topla(borcTutarlari), ParaVeDovizId.Topla(anaParayaOdenenler));

                ParaVeDovizId anaPara = ParaVeDovizId.Cikart(odemedenKalanBorcTutari, odemedenKalanFaiz);

                this.ASIL_ALACAK = anaPara.Para;
                this.ASIL_ALACAK_DOVIZ_ID = anaPara.DovizId;
            }
        }

        #endregion Methots
    }

    public class SimulasyonBirimi
    {
        public SimulasyonBirimi(int paraBirimi)
        {
            this.ParaBirimi = paraBirimi;
        }

        public event EventHandler<EventArgs> SecimYapildi;

        #region Properties

        private ParaVeDovizId _ParaAsilAlacak;
        private int _ParaBirimi;
        private ParaVeDovizId _ParaDiger;
        private ParaVeDovizId _ParaFaizler;
        private ParaVeDovizId _ParaHarclar;
        private ParaVeDovizId _ParaMasraflar;
        private ParaVeDovizId _ParaTazminatlar;
        private ParaVeDovizId _ParaVekaletUcreti;
        private ParaVeDovizId _ParaVergiler;
        private bool _Secim;

        public decimal ASIL_ALACAK
        {
            get
            {
                if (ParaAsilAlacak != null) return ParaAsilAlacak.Para;
                return decimal.Zero;
            }
        }

        public int ASIL_ALACAK_DOVIZ_ID
        {
            get
            {
                if (ParaAsilAlacak != null) return ParaAsilAlacak.DovizId;
                return 1;
            }
        }

        public decimal DIGER
        {
            get
            {
                if (ParaDiger != null) return ParaDiger.Para;
                return decimal.Zero;
            }
        }

        public int DIGER_DOVIZ_ID
        {
            get
            {
                if (ParaDiger != null) return ParaDiger.DovizId;
                return 1;
            }
        }

        public decimal FAIZLER
        {
            get
            {
                if (ParaFaizler != null) return ParaFaizler.Para;
                return decimal.Zero;
            }
        }

        public int FAIZLER_DOVIZ_ID
        {
            get
            {
                if (ParaFaizler != null) return ParaFaizler.DovizId;
                return 1;
            }
        }

        public decimal HARCLAR
        {
            get
            {
                if (ParaHarclar != null) return ParaHarclar.Para;
                return decimal.Zero;
            }
        }

        public int HARCLAR_DOVIZ_ID
        {
            get
            {
                if (ParaHarclar != null) return ParaHarclar.DovizId;
                return 1;
            }
        }

        public decimal MASRAFLAR
        {
            get
            {
                if (ParaMasraflar != null) return ParaMasraflar.Para;
                return decimal.Zero;
            }
        }

        public int MASRAFLAR_DOVIZ_ID
        {
            get
            {
                if (ParaMasraflar != null) return ParaMasraflar.DovizId;
                return 1;
            }
        }

        public ParaVeDovizId ParaAsilAlacak
        {
            get
            {
                if (_ParaAsilAlacak == null)
                    _ParaAsilAlacak = new ParaVeDovizId(0, this.ParaBirimi);
                return _ParaAsilAlacak;
            }
            set
            {
                _ParaAsilAlacak = value;
            }
        }

        public int ParaBirimi
        {
            get
            {
                if (_ParaBirimi == 0)
                    _ParaBirimi = 1;

                return _ParaBirimi;
            }
            set
            {
                _ParaBirimi = value;
            }
        }

        public ParaVeDovizId ParaDiger
        {
            get
            {
                if (_ParaDiger == null)
                    _ParaDiger = new ParaVeDovizId(0, this.ParaBirimi);
                return _ParaDiger;
            }
            set
            {
                _ParaDiger = value;
            }
        }

        public ParaVeDovizId ParaFaizler
        {
            get
            {
                if (_ParaFaizler == null)
                    _ParaFaizler = new ParaVeDovizId(0, this.ParaBirimi);
                return _ParaFaizler;
            }
            set
            {
                _ParaFaizler = value;
            }
        }

        public ParaVeDovizId ParaHarclar
        {
            get
            {
                if (_ParaHarclar == null)
                    _ParaHarclar = new ParaVeDovizId(0, this.ParaBirimi);
                return _ParaHarclar;
            }
            set
            {
                _ParaHarclar = value;
            }
        }

        public ParaVeDovizId ParaMasraflar
        {
            get
            {
                if (_ParaMasraflar == null)
                    _ParaMasraflar = new ParaVeDovizId(0, this.ParaBirimi);
                return _ParaMasraflar;
            }
            set
            {
                _ParaMasraflar = value;
            }
        }

        public ParaVeDovizId ParaTazminatlar
        {
            get
            {
                if (_ParaTazminatlar == null)
                    _ParaTazminatlar = new ParaVeDovizId(0, this.ParaBirimi);
                return _ParaTazminatlar;
            }
            set
            {
                _ParaTazminatlar = value;
            }
        }

        public ParaVeDovizId ParaToplam
        {
            get
            {
                return ParaVeDovizId.Topla(
                    ParaAsilAlacak, ParaHarclar, ParaTazminatlar, ParaMasraflar, ParaVergiler, ParaFaizler, ParaDiger, ParaVekaletUcreti);
            }
        }

        public ParaVeDovizId ParaVekaletUcreti
        {
            get
            {
                if (_ParaVekaletUcreti == null)
                    _ParaVekaletUcreti = new ParaVeDovizId(0, this.ParaBirimi);
                return _ParaVekaletUcreti;
            }
            set
            {
                _ParaVekaletUcreti = value;
            }
        }

        public ParaVeDovizId ParaVergiler
        {
            get
            {
                if (_ParaVergiler == null)
                    _ParaVergiler = new ParaVeDovizId(0, this.ParaBirimi);
                return _ParaVergiler;
            }
            set
            {
                _ParaVergiler = value;
            }
        }

        public bool Secim
        {
            get { return _Secim; }
            set
            {
                if (value && SecimYapildi != null)
                    SecimYapildi(this, new EventArgs());
                _Secim = value;
            }
        }

        /* Mahsup Kategorileri
         *
        Asil_Alacak = 2,
        Vekalet_Ucreti = 4,
        Harclar = 5,
        Tazminatlar = 6,
        Masraflar = 7,
        Faizler = 8,
        Vergiler = 9,
        Diger = 10
         *
        */

        public decimal TAZMINATLAR
        {
            get
            {
                if (ParaTazminatlar != null) return ParaTazminatlar.Para;
                return decimal.Zero;
            }
        }

        public int TAZMINATLAR_DOVIZ_ID
        {
            get
            {
                if (ParaTazminatlar != null) return ParaTazminatlar.DovizId;
                return 1;
            }
        }

        public decimal TOPLAM
        {
            get
            {
                if (ParaToplam != null) return ParaToplam.Para;

                return decimal.Zero;
            }
        }

        public decimal TOPLAM_DIGER
        {
            get
            {
                return ParaVeDovizId.Topla(ParaHarclar, ParaTazminatlar, ParaMasraflar, ParaVergiler, ParaDiger, ParaVekaletUcreti).Para;
            }
        }

        public int TOPLAM_DOVIZ_ID
        {
            get
            {
                if (ParaToplam != null) return ParaToplam.DovizId;
                return 1;
            }
        }

        public int VEKALET_DOVIZ_ID
        {
            get
            {
                if (ParaVekaletUcreti != null) return ParaVekaletUcreti.DovizId;
                return 1;
            }
        }

        public decimal VEKALET_UCRETI
        {
            get
            {
                if (ParaVekaletUcreti != null) return ParaVekaletUcreti.Para;
                return decimal.Zero;
            }
        }

        public decimal VERGILER
        {
            get
            {
                if (ParaVergiler != null) return ParaVergiler.Para;
                return decimal.Zero;
            }
        }

        public int VERGILER_DOVIZ_ID
        {
            get
            {
                if (ParaVergiler != null) return ParaVergiler.DovizId;
                return 1;
            }
        }

        #endregion Properties

        #region Methots

        public AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI GetSimulasyonCetveli()
        {
            var cetvel = new AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI();

            cetvel.ASIL_ALACAK = this.ASIL_ALACAK;
            cetvel.ASIL_ALACAK_DOVIZ_ID = this.ASIL_ALACAK_DOVIZ_ID;

            cetvel.HARC_TOPLAMI = this.HARCLAR;
            cetvel.HARC_TOPLAMI_DOVIZ_ID = this.HARCLAR_DOVIZ_ID;

            cetvel.OZEL_TAZMINAT = this.TAZMINATLAR;
            cetvel.OZEL_TAZMINAT_DOVIZ_ID = this.TAZMINATLAR_DOVIZ_ID;

            cetvel.TO_MASRAF_TOPLAMI = this.MASRAFLAR;
            cetvel.TO_MASRAF_TOPLAMI_DOVIZ_ID = this.MASRAFLAR_DOVIZ_ID;

            //cetvel VERGILER eklenecek

            cetvel.FAIZ_TOPLAMI = this.FAIZLER;
            cetvel.FAIZ_TOPLAMI_DOVIZ_ID = this.FAIZLER_DOVIZ_ID;

            cetvel.DIGER_GIDERLER = this.DIGER;
            cetvel.DIGER_GIDERLER_DOVIZ_ID = this.DIGER_DOVIZ_ID;

            cetvel.TAKIP_VEKALET_UCRETI = this.VEKALET_UCRETI; // Okan Vekalet Ücreti eklendi.
            cetvel.TAKIP_VEKALET_UCRETI_DOVIZ_ID = this.VEKALET_DOVIZ_ID;

            return cetvel;
        }

        #endregion Methots
    }

    public class TaahhutHelper
    {
        private DateTime _sayac;

        private AV001_TI_BIL_FOY _yeniFoy;

        public delegate void TarihDegisti(AV001_TI_BIL_FOY foy, DateTime sonTarih);

        public event TarihDegisti TarihDegistirildi;

        public DateTime sayac
        {
            get { return _sayac; }
            set
            {
                if (TarihDegistirildi != null)
                    TarihDegistirildi(yeniFoy, value);

                _sayac = value;
            }
        }

        public AV001_TI_BIL_FOY yeniFoy
        {
            get { return _yeniFoy; }
            set { _yeniFoy = value; }
        }

        public static List<DateTime> BankaDonemleri(DateTime sayac)
        {
            List<DateTime> list = new List<DateTime>();
            list.Add(new DateTime(sayac.Year - 1, 3, 29));
            list.Add(new DateTime(sayac.Year - 1, 6, 29));
            list.Add(new DateTime(sayac.Year - 1, 9, 29));
            list.Add(new DateTime(sayac.Year - 1, 12, 29));
            list.Add(new DateTime(sayac.Year, 3, 29));
            list.Add(new DateTime(sayac.Year, 6, 29));
            list.Add(new DateTime(sayac.Year, 9, 29));
            list.Add(new DateTime(sayac.Year, 12, 29));
            list.Add(new DateTime(sayac.Year + 1, 3, 29));
            list.Add(new DateTime(sayac.Year + 1, 6, 29));
            list.Add(new DateTime(sayac.Year + 1, 9, 29));
            list.Add(new DateTime(sayac.Year + 1, 12, 29));

            return list;
        }

        public static AV001_TI_BIL_ALACAK_NEDEN NedenKopyala(AV001_TI_BIL_ALACAK_NEDEN neden)
        {
            AV001_TI_BIL_ALACAK_NEDEN yeniNeden = new AV001_TI_BIL_ALACAK_NEDEN();

            yeniNeden.ICRA_FOY_ID = neden.ICRA_FOY_ID;
            yeniNeden.ALACAK_NEDEN_KOD_ID = neden.ALACAK_NEDEN_KOD_ID;
            yeniNeden.DIGER_ALACAK_NEDENI = neden.DIGER_ALACAK_NEDENI;
            yeniNeden.DEGERLER_SOZLESMEDEN_MI = neden.DEGERLER_SOZLESMEDEN_MI;
            yeniNeden.REFERANS_KAYIT_MI = neden.REFERANS_KAYIT_MI;
            yeniNeden.REFERANS_ALACAK_NEDEN_ID = neden.REFERANS_ALACAK_NEDEN_ID;
            yeniNeden.ALACAK_NEDEN_MAHSUP_SIRA = neden.ALACAK_NEDEN_MAHSUP_SIRA;
            yeniNeden.DAVA_FOY_ID = neden.DAVA_FOY_ID;
            yeniNeden.DAVA_OZET_FOY_ID = neden.DAVA_OZET_FOY_ID;
            yeniNeden.DUZENLENME_TARIHI = neden.DUZENLENME_TARIHI;
            yeniNeden.VADE_TARIHI = neden.VADE_TARIHI;
            yeniNeden.IHTAR_TARIHI = neden.IHTAR_TARIHI;
            yeniNeden.ILAMLI_MI = neden.ILAMLI_MI;
            yeniNeden.ILAM_BILGI_ID = neden.ILAM_BILGI_ID;
            yeniNeden.FAIZ_BASLANGIC_TARIHI = neden.FAIZ_BASLANGIC_TARIHI;
            yeniNeden.TUTAR_DOVIZ_ID = neden.TUTAR_DOVIZ_ID;
            yeniNeden.TUTAR_DOVIZ = neden.TUTAR_DOVIZ;
            yeniNeden.TUTAR_KURU = neden.TUTAR_KURU;
            yeniNeden.TUTARI = neden.TUTARI;
            yeniNeden.ISLEME_KONAN_TUTAR_DOVIZ_ID = neden.ISLEME_KONAN_TUTAR_DOVIZ_ID;
            yeniNeden.ISLEME_KONAN_TUTAR_DOVIZ = neden.ISLEME_KONAN_TUTAR_DOVIZ;
            yeniNeden.ISLEME_KONAN_TUTAR_KURU = neden.ISLEME_KONAN_TUTAR_KURU;
            yeniNeden.ISLEME_KONAN_TUTAR = neden.ISLEME_KONAN_TUTAR;
            yeniNeden.KO_ISLEME_KONAN_TUTAR = neden.KO_ISLEME_KONAN_TUTAR;
            yeniNeden.ALACAK_FAIZ_TIP_ID = neden.ALACAK_FAIZ_TIP_ID;
            yeniNeden.ALACAK_FAIZ_TIP = neden.ALACAK_FAIZ_TIP;
            yeniNeden.TO_ALACAK_FAIZ_TIP_ID = neden.TO_ALACAK_FAIZ_TIP_ID;
            yeniNeden.TO_ALACAK_FAIZ_TIP = neden.TO_ALACAK_FAIZ_TIP;
            yeniNeden.TO_UYGULANACAK_FAIZ_ORANI = neden.TO_UYGULANACAK_FAIZ_ORANI;
            yeniNeden.AYLIK_YILLIK = neden.AYLIK_YILLIK;
            yeniNeden.BIR_GUNE_AYLIK_FAIZ = neden.BIR_GUNE_AYLIK_FAIZ;
            yeniNeden.HER_AY_TAZMINAT_EKLE = neden.HER_AY_TAZMINAT_EKLE;
            yeniNeden.SABIT_FAIZ_UYGULA = neden.SABIT_FAIZ_UYGULA;
            yeniNeden.UYGULANACAK_FAIZ_ORANI = neden.UYGULANACAK_FAIZ_ORANI;
            yeniNeden.FERILERI_ANAPARAYA_EKLE = neden.FERILERI_ANAPARAYA_EKLE;
            yeniNeden.FAIZ_VADEDEN_EVVEL_3_YIL = neden.FAIZ_VADEDEN_EVVEL_3_YIL;
            yeniNeden.PROTESTO_GIDER_FAIZ_ISLESIN_MI = neden.PROTESTO_GIDER_FAIZ_ISLESIN_MI;
            yeniNeden.PROTESTO_GIDERI_FAIZ_ORANI = neden.PROTESTO_GIDERI_FAIZ_ORANI;

            return yeniNeden;
        }

        public static AV001_TI_BIL_BORCLU_ODEME OdemeEkle(ParaVeDovizId kacLira, AV001_TI_BIL_FOY yeniFoy, DateTime sayac, HesapKosulu gelenKosul)
        {
            return OdemeEkle(kacLira, yeniFoy, sayac, gelenKosul, true);
        }

        public static AV001_TI_BIL_BORCLU_ODEME OdemeEkle(ParaVeDovizId kacLira, AV001_TI_BIL_FOY yeniFoy, DateTime sayac, HesapKosulu gelenKosul, bool sonOdemeKontrolu)
        {
            AV001_TI_BIL_BORCLU_ODEME odeme = yeniFoy.AV001_TI_BIL_BORCLU_ODEMECollection.AddNew();
            AV001_TI_BIL_ODEME_PLANI odemePlani = new AV001_TI_BIL_ODEME_PLANI();

            #region Faiz Anaparaya

            if (gelenKosul.FaizIsltimTipi != HesapYapar.FaizIsletimTipi.Faiz_basit_usulde_hesaplansin)
            {
                int ayFarki = AyFarkiHesaplaToFaizIslemTipi(gelenKosul.FaizIsltimTipi);

                int mevcutFark = TarihCikar(sayac, yeniFoy.FAIZ_BASLANGIC_TARIHI);

                if (true)//(mevcutFark > ayFarki)
                {
                    List<DateTime> bankaDonemleri = BankaDonemleri(sayac);

                    DateTime? bulunan = null;

                    for (int i = bankaDonemleri.Count - 1; i >= 0; i--)
                    {
                        if (bankaDonemleri[i] <= sayac)
                        {
                            bulunan = bankaDonemleri[i];
                            break;
                        }
                    }
                    if (bulunan.HasValue)
                    {
                        ParaVeDovizId genelFaizToplami = FaiziAnaParayaEkle(gelenKosul, bulunan.Value);
                        odemePlani.DEVRE_FAIZI = genelFaizToplami.Para;
                        odemePlani.DEVRE_FAIZI_DOVIZ_ID = genelFaizToplami.DovizId;
                    }
                }
            }

            #endregion Faiz Anaparaya

            DateTime gunHesabiIlk = yeniFoy.SON_HESAP_TARIHI.HasValue ? yeniFoy.SON_HESAP_TARIHI.Value : sayac;

            odemePlani.BORC_TUTARI = yeniFoy.KALAN;
            odemePlani.BORC_TUTARI_DOVIZ_ID = yeniFoy.KALAN_DOVIZ_ID.HasValue ? yeniFoy.KALAN_DOVIZ_ID.Value : 1;

            #region Ödeme Miktarı

            if (DovizHelper.CevirYTL(kacLira.Para, kacLira.DovizId,
                DateTime.Now) > DovizHelper.CevirYTL(yeniFoy.KALAN, yeniFoy.KALAN_DOVIZ_ID, DateTime.Now) && sonOdemeKontrolu)
            {
                //kalan para ödeme tutarından az ise kalan para kadar ödeme yapıyoruz
                odeme.ODEME_MIKTAR = yeniFoy.KALAN;
                if (yeniFoy.KALAN_DOVIZ_ID.HasValue)
                    odeme.ODEME_MIKTAR_DOVIZ_ID = yeniFoy.KALAN_DOVIZ_ID.HasValue ? yeniFoy.KALAN_DOVIZ_ID.Value : 1;
            }
            else
            {
                odeme.ODEME_MIKTAR = kacLira.Para;
                odeme.ODEME_MIKTAR_DOVIZ_ID = kacLira.DovizId;
            }

            #endregion Ödeme Miktarı

            odeme.ODEME_TARIHI = sayac;

            #region Taraflar

            //Dosyanın taraflarlarından takip edenini ödenen cariye yazıyoruz
            if (yeniFoy.AV001_TI_BIL_FOY_TARAFCollection.FindAll(AV001_TI_BIL_FOY_TARAFColumn.TAKIP_EDEN_MI, true).Count > 0 &&
                yeniFoy.AV001_TI_BIL_FOY_TARAFCollection.FindAll(AV001_TI_BIL_FOY_TARAFColumn.TAKIP_EDEN_MI, true)[0].CARI_ID.HasValue)
                odeme.ODENEN_CARI_ID = yeniFoy.AV001_TI_BIL_FOY_TARAFCollection.FindAll(AV001_TI_BIL_FOY_TARAFColumn.TAKIP_EDEN_MI, true)[0].CARI_ID.Value;

            if (yeniFoy.AV001_TI_BIL_FOY_TARAFCollection.FindAll(AV001_TI_BIL_FOY_TARAFColumn.TAKIP_EDEN_MI, false).Count > 0 &&
                yeniFoy.AV001_TI_BIL_FOY_TARAFCollection.FindAll(AV001_TI_BIL_FOY_TARAFColumn.TAKIP_EDEN_MI, false)[0].CARI_ID.HasValue)
                odeme.ODEYEN_CARI_ID = yeniFoy.AV001_TI_BIL_FOY_TARAFCollection.FindAll(AV001_TI_BIL_FOY_TARAFColumn.TAKIP_EDEN_MI, false)[0].CARI_ID.Value;

            #endregion Taraflar

            //edit [ZK]
            //odeme.ODEME_TIP_ID = 10001;
            odeme.ODEME_TIP_ID = (int)OdemeTip.TAAHHÜT;
            odeme.ODEME_YER_ID = 1;

            yeniFoy.SON_HESAP_TARIHI = sayac;
            //Ödeme Sonrası oluşan değerleri almak için
            HesapYapar hy = new HesapYapar();
            hy.IcraFoyHesapla(yeniFoy);

            //sayac = sayac.AddMonths(1);

            #region Gösterim için ödeme planı

            odemePlani.ODEME = odeme.ODEME_MIKTAR.HasValue ? odeme.ODEME_MIKTAR.Value : 0;
            odemePlani.ODEME_DOVIZ_ID = odeme.ODEME_MIKTAR_DOVIZ_ID.HasValue ? odeme.ODEME_MIKTAR_DOVIZ_ID.Value : 1;
            odemePlani.BAKIYE = yeniFoy.KALAN;
            odemePlani.BAKIYE_DOVIZ_ID = yeniFoy.KALAN_DOVIZ_ID.HasValue ? yeniFoy.KALAN_DOVIZ_ID.Value : 1;
            odemePlani.TARIH = odeme.ODEME_TARIHI;
            odemePlani.FAIZ_TIP_ID = yeniFoy.FOY_FAIZ_TIP_ID;
            odemePlani.GUN = TarihCikar(sayac, gunHesabiIlk);

            decimal faizTurari = decimal.Zero;
            foreach (AV001_TI_BIL_FAIZ var in yeniFoy.AV001_TI_BIL_FAIZCollection)
            {
                faizTurari += var.FAIZ_TUTARI;
            }
            odemePlani.DEVRE_FAIZI = faizTurari;

            #endregion Gösterim için ödeme planı

            yeniFoy.AV001_TI_BIL_ODEME_PLANICollection.Add(odemePlani);

            return odeme;
        }

        public static TList<AV001_TI_BIL_ODEME_PLANI> OdemeToPlani(AV001_TI_BIL_FOY mFoy)
        {
            TList<AV001_TI_BIL_BORCLU_ODEME> borcluOdemeCollection = mFoy.AV001_TI_BIL_BORCLU_ODEMECollection;
            TList<AV001_TI_BIL_ODEME_PLANI> planListesi = new TList<AV001_TI_BIL_ODEME_PLANI>();

            decimal borcTutari = 0;
            int borcTutariDovizId = 1;
            DateTime? gunHesabi = null;

            for (int i = borcluOdemeCollection.Count; i > 0; i--)
            {
                int z = i - 1;
                AV001_TI_BIL_ODEME_PLANI plan = new AV001_TI_BIL_ODEME_PLANI();
                AV001_TI_BIL_BORCLU_ODEME odeme = borcluOdemeCollection[z];

                //AV001_TI_BIL_FOY foy = odeme.Tag as AV001_TI_BIL_FOY;

                int gunFarki = 0;
                if (gunHesabi.HasValue)
                {
                    gunFarki = TarihCikar(odeme.ODEME_TARIHI, gunHesabi.Value);
                }

                plan.ODEME = odeme.ODEME_MIKTAR.HasValue ? odeme.ODEME_MIKTAR.Value : 0;
                plan.ODEME_DOVIZ_ID = odeme.ODEME_MIKTAR_DOVIZ_ID.HasValue ? odeme.ODEME_MIKTAR_DOVIZ_ID.Value : 1;

                plan.BAKIYE = borcTutari;
                plan.BAKIYE_DOVIZ_ID = borcTutariDovizId;

                borcTutari += odeme.ODEME_MIKTAR.HasValue ? odeme.ODEME_MIKTAR.Value : 0;
                borcTutariDovizId = odeme.ODEME_MIKTAR_DOVIZ_ID.HasValue ? odeme.ODEME_MIKTAR_DOVIZ_ID.Value : 1;

                plan.BORC_TUTARI = borcTutari;
                plan.BORC_TUTARI_DOVIZ_ID = borcTutariDovizId;

                //plan.FOY_ID = foy.ID;
                //plan.FAIZ_TIP_ID = foy.FOY_FAIZ_TIP_ID;
                //plan.FAIZ_ORAN = foy.FOY_FAIZ_ORANI;

                plan.GUN = gunFarki;
                plan.TARIH = odeme.ODEME_TARIHI;
                gunHesabi = odeme.ODEME_TARIHI;

                TList<AV001_TI_BIL_FAIZ> faizler = mFoy.AV001_TI_BIL_FAIZCollection.FindAll(AV001_TI_BIL_FAIZColumn.FAIZ_BITIS_TARIHI, odeme.ODEME_TARIHI);
                List<ParaVeDovizId> faizTutariListesi = new List<ParaVeDovizId>();
                AV001_TI_BIL_FAIZ faiz = new AV001_TI_BIL_FAIZ();
                foreach (AV001_TI_BIL_FAIZ _faiz in faizler)
                {
                    faizTutariListesi.Add(new ParaVeDovizId(_faiz.FAIZ_TUTARI, _faiz.FAIZ_TUTARI_DOVIZ_ID));
                    faiz.FAIZ_BASLANGIC_TARIHI = _faiz.FAIZ_BASLANGIC_TARIHI;
                    faiz.FAIZ_BITIS_TARIHI = _faiz.FAIZ_BITIS_TARIHI;
                }

                ParaVeDovizId faizTutari = ParaVeDovizId.Topla(faizTutariListesi);
                faiz.FAIZ_TUTARI = faizTutari.Para;
                faiz.FAIZ_TUTARI_DOVIZ_ID = faizTutari.DovizId;

                plan.DEVRE_FAIZI = faiz.FAIZ_TUTARI;
                plan.DEVRE_FAIZI_DOVIZ_ID = faiz.FAIZ_TUTARI_DOVIZ_ID.HasValue
                                                ? faiz.FAIZ_TUTARI_DOVIZ_ID.Value
                                                : 1;

                plan.GUN = TarihCikar(faiz.FAIZ_BASLANGIC_TARIHI, faiz.FAIZ_BITIS_TARIHI);
                plan.FAIZ_ORAN = faiz.FAIZ_ORANI;

                plan.AV001_TI_BIL_BORCLU_ODEMECollection_From_NN_ICRA_ODEME_PLANI_BORCLU_ODEME.Add(odeme);
                plan.AV001_TI_BIL_FAIZCollection_From_NN_ICRA_ODEME_PLANI_FAIZ.Add(faiz);
                planListesi.Add(plan);
            }
            planListesi.Sort("TARIH");
            return planListesi;
        }

        public AV001_TI_BIL_FOY TaahhutHesapla(AV001_TI_BIL_FOY foy, byte kacinciGunu, ParaVeDovizId kacLira, DateTime baslangicTarihi)
        {
            HesapYapar hy = new HesapYapar();
            AV001_TI_BIL_FOY yeniFoy = foy;

            hy.IcraFoyHesapla(yeniFoy);

            DateTime sayac = new DateTime(baslangicTarihi.Year, baslangicTarihi.Month, kacinciGunu);

            while (yeniFoy.KALAN > 0)
            {
                AV001_TI_BIL_BORCLU_ODEME odeme = yeniFoy.AV001_TI_BIL_BORCLU_ODEMECollection.AddNew();

                if (DovizHelper.CevirYTL(kacLira.Para, kacLira.DovizId, DateTime.Now) > DovizHelper.CevirYTL(yeniFoy.KALAN, yeniFoy.KALAN_DOVIZ_ID, DateTime.Now))
                {
                    odeme.ODEME_MIKTAR = yeniFoy.KALAN;
                    if (yeniFoy.KALAN_DOVIZ_ID.HasValue)
                        odeme.ODEME_MIKTAR_DOVIZ_ID = yeniFoy.KALAN_DOVIZ_ID.HasValue ? yeniFoy.KALAN_DOVIZ_ID.Value : 1;
                }
                else
                {
                    odeme.ODEME_MIKTAR = kacLira.Para;
                    odeme.ODEME_MIKTAR_DOVIZ_ID = kacLira.DovizId;
                }

                odeme.ODEME_TARIHI = sayac;

                if (yeniFoy.AV001_TI_BIL_FOY_TARAFCollection.FindAll(AV001_TI_BIL_FOY_TARAFColumn.TAKIP_EDEN_MI, true).Count > 0)
                    if (yeniFoy.AV001_TI_BIL_FOY_TARAFCollection.FindAll(AV001_TI_BIL_FOY_TARAFColumn.TAKIP_EDEN_MI, true)[0].CARI_ID.HasValue)
                        odeme.ODENEN_CARI_ID = yeniFoy.AV001_TI_BIL_FOY_TARAFCollection.FindAll(AV001_TI_BIL_FOY_TARAFColumn.TAKIP_EDEN_MI, true)[0].CARI_ID.Value;

                if (yeniFoy.AV001_TI_BIL_FOY_TARAFCollection.FindAll(AV001_TI_BIL_FOY_TARAFColumn.TAKIP_EDEN_MI, false).Count > 0)
                    if (yeniFoy.AV001_TI_BIL_FOY_TARAFCollection.FindAll(AV001_TI_BIL_FOY_TARAFColumn.TAKIP_EDEN_MI, false)[0].CARI_ID.HasValue)
                        odeme.ODEYEN_CARI_ID = yeniFoy.AV001_TI_BIL_FOY_TARAFCollection.FindAll(AV001_TI_BIL_FOY_TARAFColumn.TAKIP_EDEN_MI, false)[0].CARI_ID.Value;

                // edit [ZK]
                // odeme.ODEME_TIP_ID = 10001;
                odeme.ODEME_TIP_ID = (int)OdemeTip.TAAHHÜT;
                odeme.ODEME_YER_ID = 1;
                yeniFoy.SON_HESAP_TARIHI = sayac;
                sayac = sayac.AddMonths(1);

                hy.IcraFoyHesapla(yeniFoy);
            }
            return yeniFoy;
        }

        public AV001_TI_BIL_FOY TaahhutHesaplaModel3(AV001_TI_BIL_FOY myFoy, int incGunu, int aydaBitsin, DateTime tarih, HesapKosulu gelenKosul)
        {
            sayac = tarih;
            HesapYapar hy = new HesapYapar();

            hy.IcraFoyHesapla(myFoy);
            for (int i = aydaBitsin; i > 0; i--)
            {
                ParaVeDovizId kalanPara = new ParaVeDovizId(myFoy.KALAN, myFoy.KALAN_DOVIZ_ID);

                decimal odenecekTutar = kalanPara.YtlHali / i;

                OdemeEkle(new ParaVeDovizId(odenecekTutar, 1), myFoy, sayac, gelenKosul);

                sayac = sayac.AddMonths(1);

                hy.IcraFoyHesapla(myFoy);
            }

            return myFoy;
        }

        public AV001_TI_BIL_FOY TaahhutHesaplaModel3se(AV001_TI_BIL_FOY myFoy, int incGunu, int aydaBitsin, DateTime tarih, HesapKosulu gelenKosul)
        {
            sayac = tarih;
            List<AV001_TI_BIL_BORCLU_ODEME> odemeListesi = new List<AV001_TI_BIL_BORCLU_ODEME>();
            HesapYapar hy = new HesapYapar();
            AV001_TI_BIL_FOY kopyaFoy = myFoy.DeepCopy();
            kopyaFoy.SON_HESAP_TARIHI = tarih.AddMonths(aydaBitsin);
            hy.IcraFoyHesapla(kopyaFoy);

            decimal aylikOngorulenOdeme = (new ParaVeDovizId(kopyaFoy.KALAN, kopyaFoy.KALAN_DOVIZ_ID).YtlHali / aydaBitsin);
            ///08-04-2008
            //myFoy.SON_HESAP_TARIHI = sayac;
            //hy.IcraFoyHesapla(myFoy);

            bool devamet = true;
            do
            {
                kopyaFoy.Dispose();
                kopyaFoy = myFoy.DeepCopy();
                sayac = tarih;
                odemeListesi.Clear();
                for (int i = aydaBitsin; i > 0; i--)
                {
                    //kopyaFoy.SON_HESAP_TARIHI = kopyaFoy.SON_HESAP_TARIHI.Value.AddMonths(1);
                    hy.IcraFoyHesapla(kopyaFoy);
                    //ParaVeDovizId kalanPara = new ParaVeDovizId(myFoy.KALAN, myFoy.KALAN_DOVIZ_ID);

                    //decimal odenecekTutar = kalanPara.YtlHali / i;

                    AV001_TI_BIL_BORCLU_ODEME odeme = OdemeEkle(new ParaVeDovizId(aylikOngorulenOdeme, 1), kopyaFoy, sayac, gelenKosul, false);

                    odemeListesi.Add(odeme);

                    sayac = sayac.AddMonths(1);

                    //hy.IcraFoyHesapla_OdemePlani(kopyaFoy);
                }
                if (kopyaFoy.KALAN > 1)
                {
                    decimal sonuc = (decimal)(kopyaFoy.KALAN / aydaBitsin);
                    aylikOngorulenOdeme += sonuc;
                    sayac = tarih;
                }
                else if (kopyaFoy.KALAN == 0)
                {
                    devamet = false;
                    sayac = tarih;
                }
                else if (kopyaFoy.KALAN < -1)
                {
                    decimal sonuc = (decimal)(kopyaFoy.KALAN / aydaBitsin);
                    aylikOngorulenOdeme += sonuc;
                    sayac = tarih;
                }
                else
                {
                    devamet = false;
                    sayac = tarih;
                }
            } while (devamet);

            for (int i = 0; i < aydaBitsin; i++)
            {
                AV001_TI_BIL_BORCLU_ODEME odeme = OdemeEkle(new ParaVeDovizId(aylikOngorulenOdeme, 1), myFoy, sayac, gelenKosul);

                odemeListesi.Add(odeme);

                sayac = sayac.AddMonths(1);

                //hy.IcraFoyHesapla(myFoy);
            }

            decimal odemeToplami = 0;

            foreach (AV001_TI_BIL_BORCLU_ODEME odeme in odemeListesi)
            {
                odemeToplami += odeme.ODEME_MIKTAR.HasValue ? odeme.ODEME_MIKTAR.Value : 0;
            }

            aylikOngorulenOdeme = odemeToplami / aydaBitsin;

            foreach (AV001_TI_BIL_BORCLU_ODEME odeme in odemeListesi)
            {
                odeme.ODEME_MIKTAR = aylikOngorulenOdeme;
            }

            //hy.IcraFoyHesapla_OdemePlani(myFoy);

            return myFoy;
        }

        public AV001_TI_BIL_FOY TaahhutHesaplaSE(AV001_TI_BIL_FOY foy, byte kacinciGunu, ParaVeDovizId kacLira, DateTime baslangicTarihi, int aydaBir, HesapKosulu gelenKosul)
        {
            HesapYapar hy = new HesapYapar();
            yeniFoy = foy;
            //hy.IcraFoyHesapla(yeniFoy);
            //hy.IcraFoyHesapla(yeniFoy);

            sayac = new DateTime(baslangicTarihi.Year, baslangicTarihi.Month, kacinciGunu);

            ParaVeDovizId kalanPara = new ParaVeDovizId(yeniFoy.KALAN, yeniFoy.KALAN_DOVIZ_ID);
            decimal sonuc = kalanPara.YtlHali / (kacLira.YtlHali > 0 ? kacLira.YtlHali : 1);

            do
            {
                //hy.IcraFoyHesapla(yeniFoy);
                kalanPara = new ParaVeDovizId(yeniFoy.KALAN, yeniFoy.KALAN_DOVIZ_ID);

                if (kalanPara.YtlHali <= kacLira.YtlHali && kalanPara.YtlHali > 0)
                {
                    OdemeEkle(new ParaVeDovizId(yeniFoy.KALAN, yeniFoy.KALAN_DOVIZ_ID), yeniFoy, sayac, gelenKosul);
                    hy.IcraFoyHesapla(yeniFoy);
                    //sayac = sayac.AddMonths(1);
                    break;
                }
                else if (kalanPara.YtlHali > kacLira.YtlHali && kalanPara.YtlHali > 0)
                {
                    OdemeEkle(kacLira, yeniFoy, sayac, gelenKosul);
                    sayac = sayac.AddMonths(aydaBir);
                }
                else if (kalanPara.YtlHali < 0)
                {
                    yeniFoy.AV001_TI_BIL_BORCLU_ODEMECollection[yeniFoy.AV001_TI_BIL_BORCLU_ODEMECollection.Count - 1].ODEME_MIKTAR -= yeniFoy.AV001_TI_BIL_BORCLU_ODEMECollection[yeniFoy.AV001_TI_BIL_BORCLU_ODEMECollection.Count - 1].ODEME_MIKTAR - (0 - kalanPara.Para);
                }

                hy.IcraFoyHesapla(yeniFoy);
                //sayac = sayac.AddMonths(1);
                kalanPara = new ParaVeDovizId(yeniFoy.KALAN, yeniFoy.KALAN_DOVIZ_ID);
            } while (kalanPara.YtlHali > 0);

            if (yeniFoy.KALAN < 0)
                yeniFoy.AV001_TI_BIL_BORCLU_ODEMECollection[yeniFoy.AV001_TI_BIL_BORCLU_ODEMECollection.Count - 1].ODEME_MIKTAR = yeniFoy.AV001_TI_BIL_BORCLU_ODEMECollection[yeniFoy.AV001_TI_BIL_BORCLU_ODEMECollection.Count - 1].ODEME_MIKTAR + yeniFoy.KALAN;

            hy.IcraFoyHesapla(yeniFoy);

            return yeniFoy;
        }

        public AV001_TI_BIL_FOY TahhutHesaplaModel2(AV001_TI_BIL_FOY myFoy, int inciGunu, int aySureIle, ParaVeDovizId odeme, DateTime tarih, HesapKosulu gelenKosul)
        {
            HesapYapar hy = new HesapYapar();
            yeniFoy = myFoy;
            sayac = new DateTime(tarih.Year, tarih.Month, inciGunu);

            ParaVeDovizId kalanPara = new ParaVeDovizId(yeniFoy.KALAN, yeniFoy.KALAN_DOVIZ_ID);
            decimal sonuc = kalanPara.YtlHali / odeme.YtlHali;

            for (int i = 1; i < aySureIle; i++)
            {
                if (kalanPara.YtlHali > odeme.YtlHali)
                {
                    OdemeEkle(odeme, yeniFoy, sayac, gelenKosul);
                    hy.IcraFoyHesapla_OdemePlani(yeniFoy);
                    sayac = sayac.AddMonths(1);
                }
                else
                {
                    OdemeEkle(odeme, yeniFoy, sayac, gelenKosul);
                    hy.IcraFoyHesapla_OdemePlani(yeniFoy);
                    break;
                }
                kalanPara = new ParaVeDovizId(yeniFoy.KALAN, yeniFoy.KALAN_DOVIZ_ID);
            }

            return yeniFoy;
        }

        private static int AyFarkiHesaplaToFaizIslemTipi(HesapYapar.FaizIsletimTipi faizIslemTipi)
        {
            int ayFarki = 0;

            #region AyFArkı

            switch (faizIslemTipi)
            {
                case HesapYapar.FaizIsletimTipi.Uc_Aylik_Standart_devrelerde_faiz_anaparaya_ilave_edilsin:
                    ayFarki = 3;
                    break;

                case HesapYapar.FaizIsletimTipi.Temerrut_itibariyle_3_Aylik_devrelerde_faiz_anaparaya_ilave_edilsin:
                    ayFarki = 3;
                    break;

                case HesapYapar.FaizIsletimTipi.Temerrut_itibariyle_yillik_faiz_anaparaya_ilave_edilsin:
                    ayFarki = 12;
                    break;

                case HesapYapar.FaizIsletimTipi.Yil_sonlari_itibariyle_yillik_faiz_anaparaya_ilave_edilsin:
                    ayFarki = 12;
                    break;

                case HesapYapar.FaizIsletimTipi.Ay_sonlarinda_aylik_faiz_anaparaya_ilave_edilsin:
                    ayFarki = 1;
                    break;

                case HesapYapar.FaizIsletimTipi.Temerrut_itibariyle_aylik_faiz_anaparaya_ilave_edilsin:
                    ayFarki = 1;
                    break;

                default:
                    break;
            }

            #endregion AyFArkı

            return ayFarki;
        }

        /// <summary>
        /// Faiz Anaparaya Eklenirse true döndürür
        /// </summary>
        /// <param name="gelenKosul"></param>
        /// <param name="eklenecekTarih"></param>
        /// <returns></returns>
        private static ParaVeDovizId FaiziAnaParayaEkle(HesapKosulu gelenKosul, DateTime eklenecekTarih)
        {
            AV001_TI_BIL_FOY foy = gelenKosul.Foy;

            if (foy.SON_HESAP_TARIHI > eklenecekTarih)
                return new ParaVeDovizId();

            ParaVeDovizId genelToplam = new ParaVeDovizId();
            if (foy.YedirilmisFaizTarihleri == null || !foy.YedirilmisFaizTarihleri.Contains(eklenecekTarih))
            {
                foy.SON_HESAP_TARIHI = eklenecekTarih;
                foreach (AV001_TI_BIL_ALACAK_NEDEN teki in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    teki.SON_HESAP_TARIHI = eklenecekTarih;
                }

                HesapYapar hy = new HesapYapar();
                hy.IcraFoyHesapla(foy);
                TList<AV001_TI_BIL_ALACAK_NEDEN> olusanNedenler = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

                foreach (AV001_TI_BIL_ALACAK_NEDEN neden in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    List<ParaVeDovizId> paralar = new List<ParaVeDovizId>();

                    foreach (AV001_TI_BIL_FAIZ faiz in neden.AV001_TI_BIL_FAIZCollection)
                    {
                        if (faiz.STAMP != 3)
                        {
                            if (faiz.FAIZ_BITIS_TARIHI > eklenecekTarih)
                            { }
                            else
                            {
                                paralar.Add(new ParaVeDovizId(faiz.FAIZ_TUTARI, faiz.FAIZ_TUTARI_DOVIZ_ID));
                                faiz.STAMP = 3;
                            }
                        }
                    }

                    ParaVeDovizId toplam = ParaVeDovizId.Topla(paralar);
                    if (toplam.YtlHali < 1)
                    {
                    }
                    genelToplam = ParaVeDovizId.Topla(toplam, genelToplam);
                    ParaVeDovizId islemeKonanToplamtoplam = ParaVeDovizId.Topla(toplam, new ParaVeDovizId(neden.ISLEME_KONAN_TUTAR, neden.ISLEME_KONAN_TUTAR_DOVIZ_ID));
                    ParaVeDovizId asilTutar = ParaVeDovizId.Topla(toplam, new ParaVeDovizId(neden.TUTARI, neden.TUTAR_DOVIZ_ID));

                    //neden.ISLEME_KONAN_TUTAR = islemeKonanToplamtoplam.Para;
                    //neden.ISLEME_KONAN_TUTAR_DOVIZ_ID = islemeKonanToplamtoplam.DovizId;
                    AV001_TI_BIL_ALACAK_NEDEN yeniNeden = NedenKopyala(neden);
                    neden.FAIZ_BASLANGIC_TARIHI = eklenecekTarih;
                    yeniNeden.FAIZ_BASLANGIC_TARIHI = eklenecekTarih;

                    yeniNeden.TUTARI = toplam.Para;
                    yeniNeden.TUTAR_DOVIZ_ID = toplam.DovizId;

                    yeniNeden.ISLEME_KONAN_TUTAR = toplam.Para;
                    yeniNeden.ISLEME_KONAN_TUTAR_DOVIZ_ID = toplam.DovizId;
                    olusanNedenler.Add(yeniNeden);
                }
                foy.FAIZ_BASLANGIC_TARIHI = eklenecekTarih;
                foy.AV001_TI_BIL_ALACAK_NEDENCollection.AddRange(olusanNedenler);
                if (foy.YedirilmisFaizTarihleri == null)
                    foy.YedirilmisFaizTarihleri = new List<DateTime>();

                foy.YedirilmisFaizTarihleri.Add(eklenecekTarih);
                //return true;
            }
            return genelToplam;
        }

        private static int TarihCikar(DateTime? sayac, DateTime? gunHesabiIlk)
        {
            try
            {
                if (sayac.HasValue && gunHesabiIlk.HasValue)
                {
                    TimeSpan tSon = gunHesabiIlk.Value - sayac.Value;
                    return ((int)tSon.TotalDays);
                }
                return 0;
            }
            catch 
            {
                return 0;
            }
        }

        #region Mürekkep Faiz

        private delegate decimal KalanTutar();

        public List<AV001_TI_BIL_ODEME_PLANI> ManuelTaahutHesabiModel3(AV001_TI_BIL_FOY myFoy, int incGunu, int aydaBitsin, DateTime tarih, HesapKosulu gelenKosul, double faizOrani)
        {
            HesapYapar hy = new HesapYapar();

            hy.IcraFoyHesapla(myFoy);

            #region Değerler

            //decimal kalanPara = myFoy.KALAN;

            decimal asilAlacak = myFoy.ASIL_ALACAK;

            decimal faizlerToplami = decimal.Zero;

            decimal digerAlacaklar = myFoy.KALAN - asilAlacak;

            int hesapTipi = myFoy.HESAPLAMA_TIPI;

            #endregion Değerler

            #region Delegate

            KalanTutar kalanTutar = delegate()
            {
                return asilAlacak + digerAlacaklar + faizlerToplami;
            };

            #endregion Delegate

            decimal onHesap = (decimal)((asilAlacak * (decimal)faizOrani) * (30 * aydaBitsin) / (myFoy.BIR_YIL_KAC_GUN + 10000));

            decimal onGorulenOdeme = (onHesap + kalanTutar()) / aydaBitsin;

            List<AV001_TI_BIL_ODEME_PLANI> odemeListesi = new List<AV001_TI_BIL_ODEME_PLANI>();
            bool devamEt = true;

            do
            {
                asilAlacak = myFoy.ASIL_ALACAK;
                digerAlacaklar = myFoy.KALAN - myFoy.ASIL_ALACAK;
                faizlerToplami = decimal.Zero;
                decimal tolamKalan = decimal.Zero;
                DateTime OdemeYapilacakTarih = tarih;

                for (int i = 0; i < aydaBitsin; i++)
                {
                    AV001_TI_BIL_ODEME_PLANI plan = new AV001_TI_BIL_ODEME_PLANI();

                    if (hesapTipi == 1)
                    {
                        #region Azalan Bakiye

                        plan.BORC_TUTARI = kalanTutar();
                        plan.DEVRE_FAIZI = ((asilAlacak * (decimal)faizOrani) * 30) / (myFoy.BIR_YIL_KAC_GUN + 10000);

                        faizlerToplami += plan.DEVRE_FAIZI;

                        plan.TARIH = OdemeYapilacakTarih;
                        plan.ODEME = onGorulenOdeme;
                        plan.ODEME_DOVIZ_ID = 1;

                        if (asilAlacak >= onGorulenOdeme)
                        {
                            asilAlacak -= onGorulenOdeme;
                        }
                        else if (asilAlacak < onGorulenOdeme)
                        {
                            decimal kalanOdeme = onGorulenOdeme - asilAlacak;
                            asilAlacak -= asilAlacak;

                            if (digerAlacaklar >= kalanOdeme)
                            {
                                digerAlacaklar -= kalanOdeme;
                            }
                            else if (digerAlacaklar < kalanOdeme)
                            {
                                kalanOdeme -= digerAlacaklar;
                                digerAlacaklar -= digerAlacaklar;

                                if (faizlerToplami >= kalanOdeme)
                                {
                                    faizlerToplami -= kalanOdeme;
                                }
                                else if (faizlerToplami < kalanOdeme)
                                {
                                    kalanOdeme -= faizlerToplami;

                                    faizlerToplami -= faizlerToplami;
                                }
                            }

                            tolamKalan += kalanOdeme;
                        }

                        plan.BAKIYE = kalanTutar() + plan.DEVRE_FAIZI;
                        plan.BAKIYE_DOVIZ_ID = 1;
                        OdemeYapilacakTarih = OdemeYapilacakTarih.AddMonths(1);

                        #endregion Azalan Bakiye
                    }
                    else if (hesapTipi == 2)
                    {
                        #region BK84

                        plan.BORC_TUTARI = kalanTutar();
                        plan.DEVRE_FAIZI = ((asilAlacak * (decimal)faizOrani) * 30) / (myFoy.BIR_YIL_KAC_GUN + 10000);

                        faizlerToplami += plan.DEVRE_FAIZI;

                        plan.TARIH = OdemeYapilacakTarih;
                        plan.ODEME = onGorulenOdeme;
                        plan.ODEME_DOVIZ_ID = 1;

                        if (digerAlacaklar >= onGorulenOdeme)
                        {
                            digerAlacaklar -= onGorulenOdeme;
                        }
                        else if (digerAlacaklar < onGorulenOdeme)
                        {
                            decimal kalanOdeme = onGorulenOdeme - digerAlacaklar;
                            digerAlacaklar -= digerAlacaklar;

                            if (faizlerToplami >= kalanOdeme)
                            {
                                faizlerToplami -= kalanOdeme;
                            }
                            else if (faizlerToplami < kalanOdeme)
                            {
                                kalanOdeme -= faizlerToplami;
                                faizlerToplami -= faizlerToplami;

                                if (asilAlacak >= kalanOdeme)
                                {
                                    faizlerToplami -= kalanOdeme;
                                }
                                else if (asilAlacak < kalanOdeme)
                                {
                                    kalanOdeme -= asilAlacak;

                                    asilAlacak -= asilAlacak;
                                }
                            }
                            tolamKalan += kalanOdeme;
                        }

                        plan.BAKIYE = kalanTutar() + plan.DEVRE_FAIZI;
                        plan.BAKIYE_DOVIZ_ID = 1;
                        OdemeYapilacakTarih = OdemeYapilacakTarih.AddMonths(1);

                        #endregion BK84
                    }

                    odemeListesi.Add(plan);
                }

                if (kalanTutar() < 0)
                {
                    decimal fark = kalanTutar() / aydaBitsin;
                    onGorulenOdeme += fark;
                }
                else if (kalanTutar() > 1)
                {
                    decimal fark = kalanTutar() / aydaBitsin;
                    onGorulenOdeme += fark;
                }
                else if (tolamKalan > 0)
                {
                    decimal fark = tolamKalan / aydaBitsin;
                    onGorulenOdeme += fark;
                }
                else
                {
                    devamEt = false;
                }
            } while (devamEt);

            return odemeListesi;
        }

        #endregion Mürekkep Faiz
    }
}