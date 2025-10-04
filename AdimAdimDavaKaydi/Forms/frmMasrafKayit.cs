using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmMasrafKayit : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmMasrafKayit()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.Load += new EventHandler(frmMasrafKayit_Load);
            this.Button_Kaydet_Click += new EventHandler<EventArgs>(frmMasrafKayit_Button_Kaydet_Click);
        }

        #region Properties

        public bool AktarimMi = false;

        private AV001_TD_BIL_FOY _Dava;

        private AV001_TI_BIL_FOY _Icra;

        private AV001_TDIE_BIL_PROJE _Proje;

        private AV001_TD_BIL_HAZIRLIK _Sorusturma;

        private AV001_TDI_BIL_SOZLESME _Sozlesme;

        private Dictionary<MasrafAltKategoriCustom, int> MasrafAltKategoriList = new Dictionary<MasrafAltKategoriCustom, int>();

        public AV001_TD_BIL_FOY Dava
        {
            get
            {
                return _Dava;
            }
            set
            {
                if (value != null)
                {
                    _Dava = value;
                    MasrafBilgileri.RafNumarası = _Dava.FOY_NO;
                    MasrafBilgileri.DosyaNo = _Dava.ESAS_NO;
                    MasrafBilgileri.AdliyeID = _Dava.ADLI_BIRIM_ADLIYE_ID;
                    MasrafBilgileri.NoID = _Dava.ADLI_BIRIM_NO_ID;
                    MasrafBilgileri.GorevID = _Dava.ADLI_BIRIM_GOREV_ID;

                    MasrafBilgileri.DavaID = _Dava.ID;
                    MasrafBilgileri.IcraID = MasrafBilgileri.SorusturmaID = MasrafBilgileri.SozlesmeID = null;
                }
            }
        }

        public AV001_TI_BIL_FOY Icra
        {
            get
            {
                return _Icra;
            }
            set
            {
                if (value != null)
                {
                    _Icra = value;
                    MasrafBilgileri.RafNumarası = _Icra.FOY_NO;
                    MasrafBilgileri.DosyaNo = _Icra.ESAS_NO;
                    MasrafBilgileri.AdliyeID = _Icra.ADLI_BIRIM_ADLIYE_ID;
                    MasrafBilgileri.NoID = _Icra.ADLI_BIRIM_NO_ID;
                    MasrafBilgileri.GorevID = _Icra.ADLI_BIRIM_GOREV_ID;

                    MasrafBilgileri.IcraID = _Icra.ID;
                    MasrafBilgileri.DavaID = MasrafBilgileri.SorusturmaID = MasrafBilgileri.SozlesmeID = null;
                }
            }
        }

        public AV001_TDI_BIL_MASRAF_AVANS Masraf { get; set; }

        public AV001_TDIE_BIL_PROJE Proje
        {
            get
            {
                return _Proje;
            }
            set
            {
                if (value != null)
                {
                    _Proje = value;
                    MasrafBilgileri.ProjeID = _Proje.ID;
                }
            }
        }

        public AV001_TD_BIL_HAZIRLIK Sorusturma
        {
            get
            {
                return _Sorusturma;
            }
            set
            {
                if (value != null)
                {
                    _Sorusturma = value;
                    MasrafBilgileri.RafNumarası = _Sorusturma.HAZIRLIK_NO;
                    MasrafBilgileri.DosyaNo = _Sorusturma.HAZIRLIK_ESAS_NO;
                    MasrafBilgileri.AdliyeID = _Sorusturma.ADLI_BIRIM_ADLIYE_ID;
                    MasrafBilgileri.NoID = _Sorusturma.ADLI_BIRIM_NO_ID;
                    MasrafBilgileri.GorevID = _Sorusturma.ADLI_BIRIM_GOREV_ID;

                    MasrafBilgileri.SorusturmaID = _Sorusturma.ID;
                    MasrafBilgileri.IcraID = MasrafBilgileri.DavaID = MasrafBilgileri.SozlesmeID = null;
                }
            }
        }

        public AV001_TDI_BIL_SOZLESME Sozlesme
        {
            get
            {
                return _Sozlesme;
            }
            set
            {
                if (value != null)
                {
                    _Sozlesme = value;
                    MasrafBilgileri.RafNumarası = _Sozlesme.SOZLESME_NO;
                    MasrafBilgileri.AdliyeID = _Sozlesme.ADLI_BIRIM_ADLIYE_ID;
                    MasrafBilgileri.NoID = _Sozlesme.ADLI_BIRIM_NO_ID;
                    MasrafBilgileri.GorevID = _Sozlesme.ADLI_BIRIM_GOREV_ID;

                    MasrafBilgileri.SozlesmeID = _Sozlesme.ID;
                    MasrafBilgileri.IcraID = MasrafBilgileri.SorusturmaID = MasrafBilgileri.DavaID = null;
                }
            }
        }

        #endregion Properties

        #region Methods

        public void Show(AV001_TI_BIL_FOY foy, AV001_TDIE_BIL_PROJE proje)
        {
            this.Proje = proje;
            this.Icra = foy;
            this.Show();
        }

        public void Show(AV001_TI_BIL_FOY foy)
        {
            this.Icra = foy;
            this.Show();
        }

        public void Show(AV001_TD_BIL_FOY foy)
        {
            this.Dava = foy;
            this.Show();
        }

        public void Show(AV001_TD_BIL_FOY foy, AV001_TDIE_BIL_PROJE proje)
        {
            this.Proje = proje;
            this.Dava = foy;
            this.Show();
        }

        public void Show(AV001_TD_BIL_HAZIRLIK foy)
        {
            this.Sorusturma = foy;
            this.Show();
        }

        public void Show(AV001_TD_BIL_HAZIRLIK foy, AV001_TDIE_BIL_PROJE proje)
        {
            this.Proje = proje;
            this.Sorusturma = foy;
            this.Show();
        }

        public void Show(AV001_TDI_BIL_SOZLESME foy)
        {
            this.Sozlesme = foy;
            this.Show();
        }

        public void Show(AV001_TDIE_BIL_PROJE foy)
        {
            this.Proje = foy;
            this.Show();
        }

        private void BindLookups()
        {
            BelgeUtil.Inits.AdliBirimAdliyeGetir(lueAdliye);
            BelgeUtil.Inits.AdliBirimNoGetir(lueNo);
            BelgeUtil.Inits.AdliBirimGorevGetir(lueGorev);
            BelgeUtil.Inits.ParaBicimiAyarla(spTutar);
        }

        private string GetAltKategoriText(MasrafAltKategoriCustom altKategori)
        {
            switch (altKategori)
            {
                case MasrafAltKategoriCustom.BASVURMA_HARCI:
                    return "Başvurma Harcı";

                case MasrafAltKategoriCustom.PESIN_HARC:
                    return "Peşin Harç";

                case MasrafAltKategoriCustom.VEKALET_HARCI:
                    return "Vekalet Harcı";

                case MasrafAltKategoriCustom.VEKALET_PULU:
                    return "Vekalet Pulu";

                case MasrafAltKategoriCustom.BARO_PULU:
                    return "Baro Pulu";

                case MasrafAltKategoriCustom.TEBLIGAT_GIDERI:
                    return "Tebligat Gideri";

                case MasrafAltKategoriCustom.DOSYA_KIRTASIYE_MASRAFI:
                    return "Dosya + Kırtasiye Masrafı";

                case MasrafAltKategoriCustom.MEMUR_MAHKEME_YOLLUGU:
                    return "Memur / Mahkeme Yolluğu";

                case MasrafAltKategoriCustom.RESMI_YOL_GIDERI:
                    return "Resmi Yol Gideri";

                case MasrafAltKategoriCustom.HAMAL:
                    return "Hamaliye";

                case MasrafAltKategoriCustom.NAKLIYE:
                    return "Nakliye";

                case MasrafAltKategoriCustom.CILINGIR:
                    return "Çilingir";

                case MasrafAltKategoriCustom.BILIRKISI_UCRETI:
                    return "Bilirkişi Ücreti";

                case MasrafAltKategoriCustom.TAHSIL_HARCI:
                    return "Tahsil Harcı";

                case MasrafAltKategoriCustom.CEZAEVI_HARCI:
                    return "Cezaevi Harcı";

                case MasrafAltKategoriCustom.GAZETE_ILAN_UCRETI:
                    return "Gazete İlan Ücreti";

                case MasrafAltKategoriCustom.YEDDIEMINLIK_MASRAFI:
                    return "Yeddieminlik Masrafı";

                case MasrafAltKategoriCustom.KARAR_HARCI:
                    return "Karar Harcı";

                case MasrafAltKategoriCustom.SURET_HARCI:
                    return "Suret Harcı";

                case MasrafAltKategoriCustom.MUDAHELE_HARCI:
                    return "Müdahele Harcı";

                case MasrafAltKategoriCustom.TEMYIZ_HARCI_VE_GONDERIM_MASRAFI:
                    return "Temyiz Harcı ve Gönderim Masrafı";

                case MasrafAltKategoriCustom.TASHIHI_KARAR_HARCI_VE_GONDERIM_MASRAFI:
                    return "Tashihi Karar Harcı ve Gönderim Masrafı";

                case MasrafAltKategoriCustom.IFLAS_KAYIT_HARCI:
                    return "İflas Kayıt Harcı";

                case MasrafAltKategoriCustom.IFLAS_DAVASINDA_IFLAS_HARCI:
                    return "İflas Davasında İflas Harcı";

                case MasrafAltKategoriCustom.IFLAS_TASFIYESI_ICIN_YATIRILAN_MASRAF:
                    return "İflas Tasfiyesi için Yatırılan Masraf";

                case MasrafAltKategoriCustom.IMAR_HARCI:
                    return "İmar Harcı";

                case MasrafAltKategoriCustom.NOTER_MASRAFI:
                    return "Noter Masrafı";

                case MasrafAltKategoriCustom.TICARET_SICIL_MASRAFI:
                    return "Ticaret Sicil Masrafı";

                case MasrafAltKategoriCustom.POSTA_GIDERI:
                    return "Posta Gideri";

                case MasrafAltKategoriCustom.FOTOKOPI:
                    return "Fotokopi";

                case MasrafAltKategoriCustom.YENILEME:
                    return "Yenileme";

                case MasrafAltKategoriCustom.DAMGA_VERGISI:
                    return "Damga Vergisi";

                case MasrafAltKategoriCustom.TELLALIYE:
                    return "Tellaliye";

                case MasrafAltKategoriCustom.ALIM_HARCI:
                    return "Alım Harcı";

                case MasrafAltKategoriCustom.SATIS_HARCI:
                    return "Satım Harcı";

                case MasrafAltKategoriCustom.KDV:
                    return "KDV";

                case MasrafAltKategoriCustom.EGITIM_KATKI_PAYI_FOY_PARASI:
                    return "Eğitim Katkı Payı / Föy Parası";

                case MasrafAltKategoriCustom.EMLAK_VERGISI_ARAC_VERGISI:
                    return "Emlak Vergisi / Araç Vergisi";

                default:
                    return "";
            }
        }

        private void GetKrediBorclusuCariID(AV001_TDIE_BIL_PROJE proje)
        {
            AV001_TI_BIL_ALACAK_NEDEN_TARAF krediBorclusu = null;

            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));

            DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
            foreach (var aNeden in proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI)
            {
                var taraf = aNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.FirstOrDefault(vi => vi.TARAF_SIFAT_ID == 2);
                if (taraf != null)
                {
                    krediBorclusu = aNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.FirstOrDefault(vi => vi.TARAF_SIFAT_ID == 2);
                    break;
                }
            }
            if (krediBorclusu != null)
                BelgeUtil.Inits.KrediBorclusu = krediBorclusu.TARAF_CARI_ID;

            if (BelgeUtil.Inits.KrediBorclusu == 0)
            {
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
                foreach (var aNeden in proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN)
                {
                    var taraf = aNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.FirstOrDefault(vi => vi.TARAF_SIFAT_ID == 2);
                    if (taraf != null)
                    {
                        krediBorclusu = aNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.FirstOrDefault(vi => vi.TARAF_SIFAT_ID == 2);
                        break;
                    }
                }
                if (krediBorclusu != null)
                    BelgeUtil.Inits.KrediBorclusu = krediBorclusu.TARAF_CARI_ID;
            }
        }

        private void GetMasrafGenelBilgiler()
        {
            #region Kredi Borçlusu / Dosya Tarafları

            if (Proje != null)
            {
                GetKrediBorclusuCariID(Proje);
                if (BelgeUtil.Inits.KrediBorclusu != 0)
                {
                    MasrafBilgileri.BorcluCariID = BelgeUtil.Inits.KrediBorclusu;
                    MasrafBilgileri.KrediBorclusu = BelgeUtil.Inits._per_CariGetir.Find(cari => cari.ID == BelgeUtil.Inits.KrediBorclusu).AD;
                    MasrafBilgileri.ProjeID = Proje.ID;
                }
            }

            if (Icra != null)
            {
                var tarafList = DataRepository.AV001_TI_BIL_FOY_TARAFProvider.GetByICRA_FOY_ID(Icra.ID);
                MasrafBilgileri.MuvekkilCariID = tarafList.Find(vi => vi.TARAF_KODU == (int)TarafKodu.Muvekkil).CARI_ID.Value;

                MasrafBilgileri.DosyaBorclulari = string.Empty;

                if (BelgeUtil.Inits._per_CariGetir == null)
                    BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();

                foreach (var item in tarafList.FindAll(vi => vi.TARAF_KODU != (int)TarafKodlari.M))
                {
                    MasrafBilgileri.DosyaBorclulari += BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == item.CARI_ID.Value).AD + ", ";
                }
                if (Proje == null)
                {
                    MasrafBilgileri.BorcluCariID = tarafList.FirstOrDefault(vi => !vi.TAKIP_EDEN_MI).CARI_ID.Value;
                    MasrafBilgileri.ProjeID = null;
                }
            }
            else if (Dava != null)
            {
                var tarafList = DataRepository.AV001_TD_BIL_FOY_TARAFProvider.GetByDAVA_FOY_ID(Dava.ID);
                MasrafBilgileri.MuvekkilCariID = tarafList.Find(vi => vi.TARAF_KODU == (int)TarafKodu.Muvekkil).CARI_ID.Value;

                MasrafBilgileri.DosyaBorclulari = string.Empty;

                if (BelgeUtil.Inits._per_CariGetir == null)
                    BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();

                foreach (var item in tarafList.FindAll(vi => vi.TARAF_KODU != (int)TarafKodlari.M))
                {
                    MasrafBilgileri.DosyaBorclulari += BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == item.CARI_ID.Value).AD + ", ";
                }

                if (Proje == null)
                {
                    MasrafBilgileri.BorcluCariID = tarafList.FirstOrDefault(vi => !vi.DAVA_EDEN_MI).CARI_ID.Value;
                    MasrafBilgileri.ProjeID = null;
                }
            }
            else if (Sorusturma != null)
            {
                var tarafList = DataRepository.AV001_TD_BIL_HAZIRLIK_TARAFProvider.GetByHAZIRLIK_ID(Sorusturma.ID);
                MasrafBilgileri.MuvekkilCariID = tarafList.Find(vi => vi.TARAF_KODU == (int)TarafKodu.Muvekkil).CARI_ID.Value;

                MasrafBilgileri.DosyaBorclulari = string.Empty;

                if (BelgeUtil.Inits._per_CariGetir == null)
                    BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();

                foreach (var item in tarafList.FindAll(vi => vi.TARAF_KODU != (int)TarafKodlari.M))
                {
                    MasrafBilgileri.DosyaBorclulari += BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == item.CARI_ID.Value).AD + ", ";
                }

                if (Proje == null)
                {
                    MasrafBilgileri.BorcluCariID = tarafList.FirstOrDefault(vi => !vi.SIKAYET_EDEN_MI).CARI_ID.Value;
                    MasrafBilgileri.ProjeID = null;
                }
            }

            txtKrediBorclusu.Text = MasrafBilgileri.KrediBorclusu;

            if (MasrafBilgileri.DosyaBorclulari != null)
                txtDosyaBorclulari.Text = MasrafBilgileri.DosyaBorclulari.Remove(MasrafBilgileri.DosyaBorclulari.Length - 2);

            #endregion Kredi Borçlusu / Dosya Tarafları

            #region Kredi Türleri

            List<string> alacakListesi = new List<string>();

            if (Proje != null)
            {
                if (Proje.AV001_TDIE_BIL_PROJE_ALACAK_NEDENCollection.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(Proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_ALACAK_NEDEN>));
                foreach (var alacak in Proje.AV001_TDIE_BIL_PROJE_ALACAK_NEDENCollection)
                {
                    if (alacak.ALACAK_NEDEN_IDSource == null)
                        DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDENProvider.DeepLoad(alacak, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_ALACAK_NEDEN));
                    if (alacak.ALACAK_NEDEN_IDSource.ALACAK_NEDEN_KOD_IDSource == null)
                        DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(alacak.ALACAK_NEDEN_IDSource, false, DeepLoadType.IncludeChildren, typeof(TI_KOD_ALACAK_NEDEN));
                    if (!alacakListesi.Contains(alacak.ALACAK_NEDEN_IDSource.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI))
                        alacakListesi.Add(alacak.ALACAK_NEDEN_IDSource.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI);
                }
            }
            else
            {
                if (Icra != null)
                {
                    if (Icra.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(Icra, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                    foreach (var alacak in Icra.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        if (alacak.ALACAK_NEDEN_KOD_IDSource == null)
                            DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(alacak, false, DeepLoadType.IncludeChildren, typeof(TI_KOD_ALACAK_NEDEN));
                        if (!alacakListesi.Contains(alacak.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI))
                            alacakListesi.Add(alacak.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI);
                    }
                }
            }

            string krediler = string.Empty;

            foreach (var item in alacakListesi)
            {
                krediler += item + ", ";
            }

            if (!string.IsNullOrEmpty(krediler))
                txtKrediTuru.Text = krediler.Remove(krediler.Length - 2);

            #endregion Kredi Türleri

            #region Raf No, Dosya No, Adliye/No/Görev, Şube

            txtRafNo.Text = MasrafBilgileri.RafNumarası;
            txtDosyaNo.Text = MasrafBilgileri.DosyaNo;
            lueAdliye.EditValue = MasrafBilgileri.AdliyeID;
            lueNo.EditValue = MasrafBilgileri.NoID;
            lueGorev.EditValue = MasrafBilgileri.GorevID;

            if (Proje != null)
                txtSubesi.Text = DataRepository.TDIE_KOD_PROJE_OZEL_KODProvider.GetByID(Proje.OZEL_KOD1_ID.Value).OZEL_KOD;

            #endregion Raf No, Dosya No, Adliye/No/Görev, Şube
        }

        private void MasrafAltKategoriOlustur()
        {
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.BASVURMA_HARCI, 19);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.PESIN_HARC, 37);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.VEKALET_HARCI, 32);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.VEKALET_PULU, 32);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.TEBLIGAT_GIDERI, 31);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.DOSYA_KIRTASIYE_MASRAFI, 16);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.MEMUR_MAHKEME_YOLLUGU, 1);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.RESMI_YOL_GIDERI, 12);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.HAMAL, 16);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.CILINGIR, 16);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.NAKLIYE, 16);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.BILIRKISI_UCRETI, 16);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.TAHSIL_HARCI, 17);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.CEZAEVI_HARCI, 17);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.GAZETE_ILAN_UCRETI, 16);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.YEDDIEMINLIK_MASRAFI, 51);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.KARAR_HARCI, 17);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.SURET_HARCI, 32);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.MUDAHELE_HARCI, 4);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.TEMYIZ_HARCI_VE_GONDERIM_MASRAFI, 4);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.TASHIHI_KARAR_HARCI_VE_GONDERIM_MASRAFI, 4);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.IFLAS_KAYIT_HARCI, 20);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.IFLAS_DAVASINDA_IFLAS_HARCI, 39);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.IFLAS_TASFIYESI_ICIN_YATIRILAN_MASRAF, 10);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.IMAR_HARCI, 44);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.NOTER_MASRAFI, 16);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.TICARET_SICIL_MASRAFI, 44);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.POSTA_GIDERI, 31);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.FOTOKOPI, 44);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.YENILEME, 6);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.DAMGA_VERGISI, 16);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.TELLALIYE, 16);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.ALIM_HARCI, 8);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.SATIS_HARCI, 16);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.KDV, 16);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.EGITIM_KATKI_PAYI_FOY_PARASI, 8);
            MasrafAltKategoriList.Add(MasrafAltKategoriCustom.EMLAK_VERGISI_ARAC_VERGISI, 8);
        }

        private void MasrafOlustur()
        {
            if (Masraf != null)
            {
                bndMasraf.DataSource = Masraf;

                if (AktarimMi)
                {
                    Masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.AddingNew += new AddingNewEventHandler(AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection_AddingNew);
                    foreach (var item in MasrafAltKategoriList)
                    {
                        AV001_TDI_BIL_MASRAF_AVANS_DETAY detay = Masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.AddNew();
                        detay.HAREKET_ALT_KATEGORI_ID = (int)item.Key;
                        detay.HAREKET_ALT_KATEGORI = GetAltKategoriText(item.Key);
                        detay.HAREKET_ANA_KATEGORI_ID = item.Value;
                    }
                }
                else
                {
                    if (Masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Count == 0)
                        DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(Masraf, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));
                }
                gcMasrafDetay.DataSource = Masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection;
                return;
            }
            bndMasraf.AddNew();
            Masraf = bndMasraf.Current as AV001_TDI_BIL_MASRAF_AVANS;
            Masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.AddingNew += new AddingNewEventHandler(AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection_AddingNew);
            foreach (var item in MasrafAltKategoriList)
            {
                AV001_TDI_BIL_MASRAF_AVANS_DETAY detay = Masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.AddNew();
                detay.HAREKET_ALT_KATEGORI_ID = (int)item.Key;
                detay.HAREKET_ALT_KATEGORI = GetAltKategoriText(item.Key);
                detay.HAREKET_ANA_KATEGORI_ID = item.Value;
            }
            gcMasrafDetay.DataSource = Masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection;
        }

        private string SetOncekiTutarToGridColumn(TList<AV001_TDI_BIL_MASRAF_AVANS> dosyaMasrafList, int altKategoriID)
        {
            decimal masrafToplamAltKategoriyeGore = 0;
            foreach (var item in dosyaMasrafList)
            {
                DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));
                var detay = item.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Find(vi => vi.HAREKET_ALT_KATEGORI_ID == altKategoriID);
                if (detay != null)
                    masrafToplamAltKategoriyeGore += detay.TOPLAM_TUTAR;
            }
            AdimAdimDavaKaydi.Generalclass.SayiOkuma so = new AdimAdimDavaKaydi.Generalclass.SayiOkuma();
            so.ParaFormatla(masrafToplamAltKategoriyeGore);

            return masrafToplamAltKategoriyeGore.ToString();
        }

        #endregion Methods

        #region Events

        private void AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_MASRAF_AVANS_DETAY detay = new AV001_TDI_BIL_MASRAF_AVANS_DETAY();

            detay.BORC_ALACAK_ID = 2;//Borç
            detay.ODEME_TIP_ID = (int)AvukatProLib.Extras.OdemeTip.NAKİT;
            detay.MUVEKKIL_CARI_ID = MasrafBilgileri.MuvekkilCariID;
            detay.TARIH = (bndMasraf.Current as AV001_TDI_BIL_MASRAF_AVANS).KAYIT_TARIHI;
            detay.TOPLAM_TUTAR_DOVIZ_ID = 1;//Masraflar hep TL olur.

            //Default Değerler
            detay.KAYIT_TARIHI = DateTime.Now;
            detay.KONTROL_NE_ZAMAN = DateTime.Now;
            detay.KONTROL_KIM = "AVUKATPRO";
            detay.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            detay.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            detay.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            detay.KLASOR_KODU = "GENEL";
            detay.TARIH = DateTime.Now.Date;
        }

        private void bndMasraf_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_MASRAF_AVANS masraf = new AV001_TDI_BIL_MASRAF_AVANS();

            masraf.CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
            masraf.MASRAF_AVANS_TIP = (int)AvukatProLib.Extras.MasrafAvansTip.Masraf;
            masraf.BORCLU_CARI_ID = MasrafBilgileri.BorcluCariID;
            masraf.CARI_HESAP_HEDEF_TIP = MasrafBilgileri.CariHesapHedefTip;
            masraf.DAVA_FOY_ID = MasrafBilgileri.DavaID;
            masraf.HAZIRLIK_ID = MasrafBilgileri.SorusturmaID;
            masraf.ICRA_FOY_ID = MasrafBilgileri.IcraID;
            masraf.MANUEL_KAYIT_MI = true;
            masraf.PROJE_ID = MasrafBilgileri.ProjeID;
            masraf.SOZLESME_ID = MasrafBilgileri.SozlesmeID;
            masraf.REFERANS_NO = string.Format(@"{0}\{1}\{2}", DateTime.Today.Year, DateTime.Today.Month, Guid.NewGuid().ToString().Split('-')[0].ToUpper());
            masraf.ESLESTI_MI = false;

            //Default Değerler
            masraf.KAYIT_TARIHI = DateTime.Now;
            masraf.KONTROL_NE_ZAMAN = DateTime.Now;
            masraf.KONTROL_KIM = "AVUKATPRO";
            masraf.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            masraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            masraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            masraf.KLASOR_KODU = "GENEL";

            e.NewObject = masraf;
        }

        private void frmMasrafKayit_Button_Kaydet_Click(object sender, EventArgs e)
        {
            var detayList = (gcMasrafDetay.DataSource as TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>).FindAll(vi => vi.TOPLAM_TUTAR != 0);

            if (AktarimMi)
            {
                decimal toplamMasraf = detayList.Sum(vi => vi.TOPLAM_TUTAR);
                if (Masraf.AKTARILAN_TOPLAM_TUTAR.HasValue)
                {
                    if (Masraf.AKTARILAN_TOPLAM_TUTAR.Value != toplamMasraf)
                    {
                        AdimAdimDavaKaydi.Generalclass.SayiOkuma sa = new AdimAdimDavaKaydi.Generalclass.SayiOkuma();

                        MessageBox.Show(string.Format("Aktarımda masraf toplamı {0} TL.\r\nGirilen toplam tutar eşleşmediğinden kayıt işlemi gerçekleştirilemedi.\r\nTutarları kontrol ediniz.", sa.ParaFormatla(Masraf.AKTARILAN_TOPLAM_TUTAR.Value)), "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            Masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Clear();
            Masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.AddRange(detayList);

            if (Masraf.KAYIT_TARIHI.ToShortDateString() != DateTime.Now.Date.ToShortDateString())
                foreach (var item in detayList)
                {
                    item.TARIH = Masraf.KAYIT_TARIHI;
                }

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                tran.BeginTransaction();
                DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepSave(tran, Masraf, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));
                if (Proje != null && (Icra == null && Dava == null && Sorusturma == null))
                {
                    AV001_TDIE_BIL_PROJE_MASRAF_AVANS masrafProje = Masraf.AV001_TDIE_BIL_PROJE_MASRAF_AVANSCollection.AddNew();
                    masrafProje.PROJE_ID = Proje.ID;
                    masrafProje.MASRAF_AVANS_ID = Masraf.ID;
                    DataRepository.AV001_TDIE_BIL_PROJE_MASRAF_AVANSProvider.Save(tran, masrafProje);
                }

                tran.Commit();
                AvukatProLib.Hesap.MuhasebeAraclari.SetCariHesapByMasrafAvans(Masraf.ID);
                Forms.frmKlasorYeni.MasraflarYuklendi = false;//Masraf kaydın yapıldığında klasördeki masrafların refresh olması için eklendi. MB
                if (!AktarimMi)
                    MessageBox.Show("Kaydedildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Aktarımdan gelen ve dağıtılmayan masraf \r\nilgili dosyaya kaydedildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                if (tran.IsOpen) tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);
                MessageBox.Show("Kaydedilemedi.", "İPTAL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void frmMasrafKayit_Load(object sender, EventArgs e)
        {
            BindLookups();
            MasrafAltKategoriOlustur();//Dictionary istenilen Alt Kategoriler ile dolduruluyor.
            GetMasrafGenelBilgiler();//Gridin üst kısmındaki alanlar dolduruluyor. Tarih ve açıklama dışında olanlar readolnly alanlar.
            MasrafOlustur();//Belirlenen kategorilerde masraf ve detayları oluşturuluyor.
        }

        private void gvMasrafDetay_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Tag == null) return;
            if ((int)e.Column.Tag == 1)
            {
                TList<AV001_TDI_BIL_MASRAF_AVANS> dosyaMasrafList = new TList<AV001_TDI_BIL_MASRAF_AVANS>();

                var masrafDetay = gvMasrafDetay.GetRow(e.RowHandle) as AV001_TDI_BIL_MASRAF_AVANS_DETAY;

                if (Proje != null && (Icra == null && Dava == null && Sorusturma == null))//Klasörden Masraf Kaydı
                {
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(Proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY>), typeof(TList<AV001_TD_BIL_FOY>), typeof(TList<AV001_TD_BIL_HAZIRLIK>), typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));

                    #region İcra

                    var icraList = Proje.AV001_TI_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY;

                    foreach (var item in icraList)
                    {
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));
                        dosyaMasrafList.AddRange(item.AV001_TDI_BIL_MASRAF_AVANSCollection);
                    }

                    #endregion İcra

                    #region Dava

                    var davaList = Proje.AV001_TD_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_DAVA_FOY;

                    foreach (var item in davaList)
                    {
                        DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));
                        dosyaMasrafList.AddRange(item.AV001_TDI_BIL_MASRAF_AVANSCollection);
                    }

                    #endregion Dava

                    #region Soruşturma

                    var sorusturmaList = Proje.AV001_TD_BIL_HAZIRLIKCollection_From_AV001_TDIE_BIL_PROJE_HAZIRLIK;

                    foreach (var item in sorusturmaList)
                    {
                        DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));
                        dosyaMasrafList.AddRange(item.AV001_TDI_BIL_MASRAF_AVANSCollection);
                    }

                    #endregion Soruşturma

                    #region Klasör

                    dosyaMasrafList.AddRange(Proje.AV001_TDI_BIL_MASRAF_AVANSCollection);

                    #endregion Klasör
                }
                else if (Icra != null)
                    dosyaMasrafList = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByICRA_FOY_ID(MasrafBilgileri.IcraID);
                else if (Dava != null)
                    dosyaMasrafList = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByDAVA_FOY_ID(MasrafBilgileri.DavaID);
                else if (Sorusturma != null)
                    dosyaMasrafList = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByHAZIRLIK_ID(MasrafBilgileri.SorusturmaID);

                e.DisplayText = SetOncekiTutarToGridColumn(dosyaMasrafList, masrafDetay.HAREKET_ALT_KATEGORI_ID);
            }
        }

        #endregion Events

        public static class MasrafBilgileri
        {
            public static int? AdliyeID { get; set; }

            public static int BorcluCariID { get; set; }

            public static int CariHesapHedefTip { get; set; }

            public static int? DavaID { get; set; }

            public static string DosyaBorclulari { get; set; }

            public static string DosyaNo { get; set; }

            public static int? GorevID { get; set; }

            public static int? IcraID { get; set; }

            public static string KrediBorclusu { get; set; }
            
            public static int MuvekkilCariID { get; set; }

            public static int? NoID { get; set; }

            public static int? ProjeID { get; set; }

            public static string RafNumarası { get; set; }

            public static int? SorusturmaID { get; set; }

            public static int? SozlesmeID { get; set; }
        }
    }
}