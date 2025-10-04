using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmKlasorAlacakGirisi : AvpXtraForm
    {
        #region <MB-20103003> LOAD

        public frmKlasorAlacakGirisi()
        {
            this.IsLoaded = false;
            InitializeComponent();
            InitializeEvents();

            this.Load += frmKlasorAlacakGirisi_Load;
        }

        public bool DepoAlacagimi = false;

        //Nakit
        public bool Duzenleme;

        //Düzenleme için kullanılan property
        private AV001_TI_BIL_ALACAK_NEDEN _MyAlacakNeden;

        private AV001_TDIE_BIL_PROJE _MyProje;

        private bool IhtarnameVarmi;

        public bool IsLoaded { get; set; }

        public AV001_TI_BIL_ALACAK_NEDEN MyAlacakNeden
        {
            get { return _MyAlacakNeden; }
            set
            {
                if (value != null)
                {
                    _MyAlacakNeden = value;

                    bndAlacakNedeni.DataSource = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID(value.ID);

                    //Düzenleme modunda ColumnChanged eventına girmesini sağlamak için eklendi. MB
                    (bndAlacakNedeni.Current as AV001_TI_BIL_ALACAK_NEDEN).ColumnChanged += alacakNeden_ColumnChanged;

                    bndAlacakNedenTaraf.DataSource =
                        DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.GetByICRA_ALACAK_NEDEN_ID(value.ID);
                    foreach (var item in bndAlacakNedenTaraf.DataSource as TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>)
                    {
                        item.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.AddRange(
                            DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZProvider.GetByALACAK_NEDEN_TARAF_ID(
                                item.ID));
                    }

                    AV001_TDI_BIL_MASRAF_AVANS masraf =
                        DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByALACAK_NEDEN_ID(value.ID).FirstOrDefault();
                    if (masraf != null)
                    {
                        DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(masraf, false,
                                                                                   DeepLoadType.IncludeChildren,
                                                                                   typeof(
                                                                                       TList
                                                                                       <AV001_TDI_BIL_MASRAF_AVANS_DETAY
                                                                                       >));

                        bndMasraf.DataSource = masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.FirstOrDefault();
                        lueMasrafYapan.EditValue = masraf.CARI_ID;
                    }

                    AV001_TDI_BIL_TEBLIGAT ihtarname =
                        DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByALACAK_NEDEN_IDFromNN_TEBLIGAT_ALACAK_NEDEN(
                            value.ID).FirstOrDefault();
                    if (ihtarname != null)
                    {
                        bndIhtarname.DataSource = ihtarname;
                        chIhtarname.Checked = true;
                        chIhtarname.Enabled = false;
                        lcGroupIhtarnameBilgileri.Enabled = chIhtarname.Checked;
                        IhtarnameVarmi = chIhtarname.Checked;
                    }
                }
            }
        }

        public AV001_TDIE_BIL_PROJE MyProje
        {
            get { return _MyProje; }
            set
            {
                if (!DesignMode && value != null)
                {
                    _MyProje = value;
                }
            }
        }

        private void AlacakNedenineGoreXML(bool depoAlacagimi, int alacakNedeni)
        {
            if (depoAlacagimi) //Gayrinakit
            {
                if (alacakNedeni == 93 || alacakNedeni == 94 || alacakNedeni == 95 || alacakNedeni == 96 || alacakNedeni == 97 || alacakNedeni == 98) //Çek Yaprağı
                    lcKlasorAlacakGirisi.RestoreLayoutFromXml(Application.StartupPath + "\\GayriNakitAlacakCekYapragi.xml");
                else /*if (alacakNedeni == 99 || alacakNedeni == 100 || alacakNedeni == 101 || alacakNedeni == 102 || alacakNedeni == 103 || alacakNedeni == 104) //MER`İ TEMİNAT MEKTUBU*/
                    lcKlasorAlacakGirisi.RestoreLayoutFromXml(Application.StartupPath + "\\GayriNakitAlacakMeriTeminatMektubu.xml");

                //else
                //    lcKlasorAlacakGirisi.RestoreLayoutFromXml(Application.StartupPath + "\\GayriNakitAlacaklarGenel.xml");
            }
            else //Nakit
            {
                if (alacakNedeni == 54) //Diğer Alacak
                    lcKlasorAlacakGirisi.RestoreLayoutFromXml(Application.StartupPath + "\\NakitAlacakDigerAlacak.xml");
                else
                    lcKlasorAlacakGirisi.RestoreLayoutFromXml(Application.StartupPath + "\\NakitAlacaklarGenel.xml");
            }
        }

        private void BindLookUps()
        {
            BelgeUtil.Inits.AdliBirimAdliyeGetir(lueMerci.Properties);
            BelgeUtil.Inits.AdliBirimNoGetir(lueBirimNo.Properties);
            BelgeUtil.Inits.AdliBirimGorevGetir(lueGorev.Properties);
            BelgeUtil.Inits.TebligatTipGetir(lueTebligatTip.Properties);
            BelgeUtil.Inits.TebligatKonuGetirKlasorAlacak(lueKonu.Properties);
            BelgeUtil.Inits.TarafSifatGetir(lueTarafSifati.Properties);
            BelgeUtil.Inits.MuhasebeHareketAltKategori(lueMasrafKalemi.Properties);
            BelgeUtil.Inits.IcraDovizIslemTipiGetir(lueDovizIslemTipi.Properties);
            BelgeUtil.Inits.AlacakNedenGetir(lueAlacakNedeni.Properties, DepoAlacagimi, myAlacakNedenList);

            BelgeUtil.Inits.FaizTipiGetir(lueFaizTipi.Properties);
            BelgeUtil.Inits.FaizTipiGetir(rlueFaizTip);

            BelgeUtil.Inits.perCariGetir(lueMasrafYapan.Properties);
            BelgeUtil.Inits.perCariGetir(lueTarafAd.Properties);
            BelgeUtil.Inits.perCariGetir(lueMuhatap.Properties);

            #region Döviz

            BelgeUtil.Inits.DovizTipGetir(lueMasrafTutariDoviz.Properties);
            BelgeUtil.Inits.DovizTipGetir(lueSorumlulukMiktariTarafDoviz.Properties);
            BelgeUtil.Inits.DovizTipGetir(lueSorumlulukMiktariDoviz.Properties);
            BelgeUtil.Inits.DovizTipGetir(lueIhtarGideriDoviz.Properties);
            BelgeUtil.Inits.DovizTipGetir(lueIhtarGideriTarafDoviz.Properties);
            BelgeUtil.Inits.DovizTipGetir(lueIslemeKonanTutarDoviz.Properties);
            BelgeUtil.Inits.DovizTipGetir(lueTutariDoviz.Properties);
            BelgeUtil.Inits.DovizTipGetir(lueTazminTutariDoviz.Properties);
            BelgeUtil.Inits.DovizTipGetir(lueIadeMiktariDoviz.Properties);
            BelgeUtil.Inits.DovizTipGetir(lueDepoMiktariDoviz.Properties);

            #endregion Döviz

            #region Para Biçimi Ayarla

            BelgeUtil.Inits.ParaBicimiAyarla(spIhtarGideri);
            BelgeUtil.Inits.ParaBicimiAyarla(spIhtarGideriTaraf);
            BelgeUtil.Inits.ParaBicimiAyarla(spIslemeKonanTutar);
            BelgeUtil.Inits.ParaBicimiAyarla(spSorumlulukMiktari);
            BelgeUtil.Inits.ParaBicimiAyarla(spSorumlulukMiktariTaraf);
            BelgeUtil.Inits.ParaBicimiAyarla(spTutari);
            BelgeUtil.Inits.ParaBicimiAyarla(spMasrafTutari);
            BelgeUtil.Inits.ParaBicimiAyarla(spTazminTutari);
            BelgeUtil.Inits.ParaBicimiAyarla(spIadeMiktari);
            BelgeUtil.Inits.ParaBicimiAyarla(spDepoMiktari);

            #endregion Para Biçimi Ayarla

            #region Yüzde Biçimi Ayarla

            BelgeUtil.Inits.YuzdeBicimiAyarla(spFaizOrani);
            BelgeUtil.Inits.YuzdeBicimiAyarla(spAktiFaiz);
            BelgeUtil.Inits.YuzdeBicimiAyarla(spCariFaiz);

            #endregion Yüzde Biçimi Ayarla
        }

        private void frmKlasorAlacakGirisi_Load(object sender, EventArgs e)
        {
            this.IsLoaded = true;

            BindLookUps();

            lcGroupIhtarnameBilgileri.Enabled = false;
            if (!Duzenleme)
            {
                lcGroupAlacakGirisi.Enabled = false;
                lcGroupAlacakTaraflari.Enabled = false;
                lcGroupAlacakNedenFaiz.Enabled = false;
            }
            if (!Duzenleme)
                lcKlasorAlacakGirisi.RestoreLayoutFromXml(Application.StartupPath + "\\GayriNakitAlacaklarGenel.xml");
            else
            {
                if (MyAlacakNeden.ALACAK_NEDEN_KOD_ID.HasValue)
                    AlacakNedenineGoreXML(DepoAlacagimi, MyAlacakNeden.ALACAK_NEDEN_KOD_ID.Value);
            }
            ReferansNoOzellestir();

            if (Duzenleme)
                (bndAlacakNedeni.Current as AV001_TI_BIL_ALACAK_NEDEN).IsSelected = DepoAlacagimi;
        }

        private void InitializeEvents()
        {
            EventlerKullanilacakMi = true;

            this.Button_Kaydet_Click += frmKlasorAlacakGirisi_Button_Kaydet_Click;
        }

        #region Klasörde Kullanılan Alacak Nedenleri

        private List<string> myAlacakNedenList = new[]
                                                     {
                                                         "BANKA KREDİ KARTI",
                                                         "BANKA KREDİ ALACAĞI",
                                                         "DİĞER ALACAK...",
                                                         "VADELİ AKREDİTİF",
                                                         "AVAL",
                                                         "BANKA KEFALETİ",
                                                         "DİĞER DEPO",
                                                         "DÖVİZE ENDEKSLİ SPOT KREDİ",
                                                         "KONUT KREDİSİ",
                                                         "ARAÇ KREDİSİ",
                                                         "TÜKETİCİ KREDİSİ",
                                                         "DÖVİZ KREDİSİ",
                                                         "İHRACAAT KREDİSİ",
                                                         "YATIRIM KREDİSİ",
                                                         "TAKSİTLİ TİCARİ KREDİ (TTK)",
                                                         "FİRMA TAŞIT KREDİSİ",
                                                         "KONUT GELİŞTİRME KREDİSİ",
                                                         "MORGATE",
                                                         "İHTİYAÇ KREDİSİ",
                                                         "ŞİRKET KREDİ KARTI",
                                                         "KREDİLİ MEVDUAT HESABI",
                                                         "PERSONEL KREDİSİ",
                                                         "YETKİLİ ÖDEME MERKEZİ KREDİSİ",
                                                         "KEFALET KREDİSİ",
                                                         "ÇEK TAAHHÜT KREDİSİ",
                                                         "İŞLETME KREDİSİ",
                                                         "SPOT KREDİ",
                                                         "ROTATİF KREDİ",
                                                         "TİCARİ KREDİLİ MEVDUAT HESABI (TKMH)",
                                                         "ÇEK YAPRAĞI",
                                                         "MER`İ TEMİNAT MEKTUBU",
                                                         "TAZMİN EDİLMİŞ ÇEK YAPRAĞI",
                                                         "TAZMİN EDİLMİŞ TEMİNAT MEKTUBU",
                                                         "TAZMİN EDİLMİŞ VADELİ AKREDİTİF",
                                                         "TAZMİN EDİLMİŞ AVAL",
                                                         "TAZMİN EDİLMİŞ BANKA KEFALETİ"
                                                     }.ToList();

        #endregion Klasörde Kullanılan Alacak Nedenleri

        private void ReferansNoOzellestir()
        {
            lcItemRefNo1.Text = AvukatProLib.Kimlikci.Kimlik.IcraAnReferans.Referans1;
            lcItemRefNo2.Text = AvukatProLib.Kimlikci.Kimlik.IcraAnReferans.Referans2;
            lcItemRefNo3.Text = AvukatProLib.Kimlikci.Kimlik.IcraAnReferans.Referans3;
        }

        #endregion <MB-20103003> LOAD

        #region <MB-20103003> KAYIT, ADDINGNEW EVENTS

        private void bndAlacakNedeni_AddingNew(object sender, AddingNewEventArgs e)
        {
            chIhtarname.Enabled = false;
            lcGroupAlacakGirisi.Enabled = true;

            AV001_TI_BIL_ALACAK_NEDEN alacakNeden = new AV001_TI_BIL_ALACAK_NEDEN();

            alacakNeden.KAYIT_TARIHI = DateTime.Now;
            alacakNeden.KONTROL_NE_ZAMAN = DateTime.Now;
            alacakNeden.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            alacakNeden.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            alacakNeden.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            alacakNeden.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;

            alacakNeden.HESAPLAMA_MODU = Convert.ToByte(AvukatProLib.Extras.IcraDovizIslemTipi.Vade_Tarihinde_TL);
            alacakNeden.ALACAK_FAIZ_TIP_ID = (int)AvukatProLib.Extras.FaizTip.Temmerut_Faiz;
            alacakNeden.UYGULANACAK_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)AvukatProLib.Extras.FaizTip.Temmerut_Faiz, 1, MyProje != null ? MyProje.BASLANGIC_TARIHI : DateTime.Today);

            //if (alacakNeden.UYGULANACAK_FAIZ_ORANI != 0)
            //    spFaizOrani.Enabled = false;

            alacakNeden.BSMV_HESAPLANSIN = true;
            alacakNeden.IsSelected = DepoAlacagimi;

            alacakNeden.ColumnChanged += alacakNeden_ColumnChanged;

            e.NewObject = alacakNeden;

            if (IhtarnameVarmi)
            {
                if (bndAlacakNedeni.List.Count == 0)
                {
                    if (bndMasraf.Current != null && (bndMasraf.Current as AV001_TDI_BIL_MASRAF_AVANS_DETAY) != null)
                    {
                        alacakNeden.IHTAR_GIDERI = (bndMasraf.Current as AV001_TDI_BIL_MASRAF_AVANS_DETAY).BIRIM_FIYAT;
                        alacakNeden.IHTAR_GIDERI_DOVIZ_ID =
                            (bndMasraf.Current as AV001_TDI_BIL_MASRAF_AVANS_DETAY).BIRIM_FIYAT_DOVIZ_ID;
                    }
                    if (bndIhtarname.Current != null && (bndIhtarname.Current as AV001_TDI_BIL_TEBLIGAT) != null)
                    {
                        alacakNeden.IHTAR_TARIHI = (bndIhtarname.Current as AV001_TDI_BIL_TEBLIGAT).POSTALANMA_TARIH;
                        alacakNeden.VADE_TARIHI = (bndIhtarname.Current as AV001_TDI_BIL_TEBLIGAT).POSTALANMA_TARIH;

                        //alacakNeden.DUZENLENME_TARIHI =
                        //    (bndIhtarname.Current as AV001_TDI_BIL_TEBLIGAT).POSTALANMA_TARIH;
                        //alacakNeden.FAIZ_BASLANGIC_TARIHI =
                        //    (bndIhtarname.Current as AV001_TDI_BIL_TEBLIGAT).POSTALANMA_TARIH;
                    }
                }
                else
                {
                    if (bndIhtarname.Current != null && (bndIhtarname.Current as AV001_TDI_BIL_TEBLIGAT) != null)
                    {
                        alacakNeden.IHTAR_TARIHI = (bndIhtarname.Current as AV001_TDI_BIL_TEBLIGAT).POSTALANMA_TARIH;
                        alacakNeden.VADE_TARIHI = (bndIhtarname.Current as AV001_TDI_BIL_TEBLIGAT).POSTALANMA_TARIH;

                        //alacakNeden.DUZENLENME_TARIHI =
                        //    (bndIhtarname.Current as AV001_TDI_BIL_TEBLIGAT).POSTALANMA_TARIH;
                        //alacakNeden.FAIZ_BASLANGIC_TARIHI =
                        //    (bndIhtarname.Current as AV001_TDI_BIL_TEBLIGAT).POSTALANMA_TARIH;
                    }
                }
            }

            if (bndAlacakNedeni.List.Count >= 1)
            {
                //İlk Alacak Nedeni Taraflarının Yeni Alacak Nedeninin Taraflarına da Eklenmesi
                if (
                    (bndAlacakNedeni.List[0] as AV001_TI_BIL_ALACAK_NEDEN).AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.
                        Count > 0)
                    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(
                        bndAlacakNedeni.List[0] as AV001_TI_BIL_ALACAK_NEDEN, false, DeepLoadType.IncludeChildren,
                        typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
                alacakNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.AddRange(
                    (bndAlacakNedeni.List[0] as AV001_TI_BIL_ALACAK_NEDEN).AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.
                        Select(vi => new AV001_TI_BIL_ALACAK_NEDEN_TARAF
                                         {
                                             TARAF_CARI_ID = vi.TARAF_CARI_ID,
                                             TARAF_SIFAT_ID = vi.TARAF_SIFAT_ID,
                                             IHTAR_GIDERI = vi.IHTAR_GIDERI,
                                             IHTAR_GIDERI_DOVIZ_ID = vi.IHTAR_GIDERI_DOVIZ_ID,
                                             IHTAR_TARIHI = vi.IHTAR_TARIHI,
                                             IHTAR_TEBLIG_TARIHI = vi.IHTAR_TEBLIG_TARIHI,
                                             TEMERRUT_TARIHI = vi.TEMERRUT_TARIHI,
                                             PROTESTO_GIDERI = vi.PROTESTO_GIDERI,
                                         }
                        ).ToArray());
            }
        }

        private void bndAlacakNedenTaraf_AddingNew(object sender, AddingNewEventArgs e)
        {
            lcGroupAlacakTaraflari.Enabled = true;
            lcGroupAlacakNedenFaiz.Enabled = true;

            AV001_TI_BIL_ALACAK_NEDEN_TARAF alacakNedenTaraf = new AV001_TI_BIL_ALACAK_NEDEN_TARAF();

            alacakNedenTaraf.KAYIT_TARIHI = DateTime.Now;
            alacakNedenTaraf.KONTROL_NE_ZAMAN = DateTime.Now;
            alacakNedenTaraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            alacakNedenTaraf.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            alacakNedenTaraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            alacakNedenTaraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;

            if (Duzenleme) alacakNedenTaraf.ICRA_ALACAK_NEDEN_ID = (bndAlacakNedeni.Current as AV001_TI_BIL_ALACAK_NEDEN).ID;

            if (bndAlacakNedenTaraf.Count == 0)
            {
                alacakNedenTaraf.TARAF_SIFAT_ID = (int)AvukatProLib.Extras.TarafSifat.ALACAKLI;

                TI_BIL_ICRA_KULLANICI_AYAR icraAyar =
                    DataRepository.TI_BIL_ICRA_KULLANICI_AYARProvider.GetByKULLANICI_ID(AvukatProLib.Kimlik.Bilgi.ID).
                        SingleOrDefault();
                if (icraAyar != null)
                {
                    if (icraAyar.SECILI_MUVEKKIL_CARI_ID.HasValue)
                        alacakNedenTaraf.TARAF_CARI_ID = icraAyar.SECILI_MUVEKKIL_CARI_ID.Value;
                }
            }
            else
            {
                alacakNedenTaraf.TARAF_SIFAT_ID = (int)AvukatProLib.Extras.TarafSifat.BORCLU;
                if (bndAlacakNedeni.Current != null)
                {
                    alacakNedenTaraf.SORUMLU_OLUNAN_MIKTAR =
                        (bndAlacakNedeni.Current as AV001_TI_BIL_ALACAK_NEDEN).ISLEME_KONAN_TUTAR;
                    alacakNedenTaraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID =
                        (bndAlacakNedeni.Current as AV001_TI_BIL_ALACAK_NEDEN).ISLEME_KONAN_TUTAR_DOVIZ_ID;
                }

                if (IhtarnameVarmi)
                {
                    if (bndMasraf.Current != null && (bndMasraf.Current as AV001_TDI_BIL_MASRAF_AVANS_DETAY) != null)
                    {
                        alacakNedenTaraf.IHTAR_GIDERI =
                            (bndMasraf.Current as AV001_TDI_BIL_MASRAF_AVANS_DETAY).BIRIM_FIYAT;
                        alacakNedenTaraf.IHTAR_GIDERI_DOVIZ_ID =
                            (bndMasraf.Current as AV001_TDI_BIL_MASRAF_AVANS_DETAY).BIRIM_FIYAT_DOVIZ_ID;
                    }
                    if (bndIhtarname.Current != null && (bndIhtarname.Current as AV001_TDI_BIL_TEBLIGAT) != null)
                    {
                        alacakNedenTaraf.IHTAR_TARIHI =
                            (bndIhtarname.Current as AV001_TDI_BIL_TEBLIGAT).POSTALANMA_TARIH;

                        //alacakNedenTaraf.TEMERRUT_TARIHI =
                        //    (bndIhtarname.Current as AV001_TDI_BIL_TEBLIGAT).POSTALANMA_TARIH;
                    }
                }
                if ((bndAlacakNedeni.Current as AV001_TI_BIL_ALACAK_NEDEN).VADE_TARIHI.HasValue)
                    alacakNedenTaraf.TEMERRUT_TARIHI = (bndAlacakNedeni.Current as AV001_TI_BIL_ALACAK_NEDEN).VADE_TARIHI.Value;

                alacakNedenTaraf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.AddingNew +=
                    bndAlacakNedenTarafFaiz_AddingNew;
                alacakNedenTaraf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.AddNew();
            }

            e.NewObject = alacakNedenTaraf;
        }

        private void bndAlacakNedenTarafFaiz_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ alacakNedenTarafFaiz = new AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ();

            alacakNedenTarafFaiz.KAYIT_TARIHI = DateTime.Now;
            alacakNedenTarafFaiz.KONTROL_NE_ZAMAN = DateTime.Now;
            alacakNedenTarafFaiz.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            alacakNedenTarafFaiz.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            alacakNedenTarafFaiz.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            alacakNedenTarafFaiz.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;

            AV001_TI_BIL_ALACAK_NEDEN alacakNeden = bndAlacakNedeni.Current as AV001_TI_BIL_ALACAK_NEDEN;

            if (alacakNeden.ALACAK_FAIZ_TIP_ID.HasValue)
                alacakNedenTarafFaiz.FAIZ_TIP_ID = alacakNeden.ALACAK_FAIZ_TIP_ID.Value;

            if (alacakNeden.FAIZ_BASLANGIC_TARIHI.HasValue)
                alacakNedenTarafFaiz.FAIZ_BASLANGIC_TARIHI = alacakNeden.FAIZ_BASLANGIC_TARIHI.Value;
            else
                alacakNedenTarafFaiz.FAIZ_BASLANGIC_TARIHI = MyProje.BASLANGIC_TARIHI;

            alacakNedenTarafFaiz.FAIZ_BITIS_TARIHI = MyProje.BASLANGIC_TARIHI;
            alacakNedenTarafFaiz.FAIZ_ORANI = alacakNeden.UYGULANACAK_FAIZ_ORANI;

            e.NewObject = alacakNedenTarafFaiz;
        }

        private void bndIhtarname_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_TEBLIGAT tebligat = new AV001_TDI_BIL_TEBLIGAT();

            tebligat.KAYIT_TARIHI = DateTime.Now;
            tebligat.KONTROL_NE_ZAMAN = DateTime.Now;
            tebligat.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            tebligat.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            tebligat.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            tebligat.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;

            tebligat.TIP_ID = 4; //İHTARNAME
            tebligat.KONU_ID = 481; //HESAP KAT İHTARNAMESİ
            tebligat.ADLI_BIRIM_GOREV_ID = 31; //NOT

            e.NewObject = tebligat;
        }

        private void bndMasraf_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_MASRAF_AVANS_DETAY detay = new AV001_TDI_BIL_MASRAF_AVANS_DETAY();

            detay.KAYIT_TARIHI = DateTime.Now;
            detay.KONTROL_NE_ZAMAN = DateTime.Now;
            detay.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            detay.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            detay.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            detay.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            detay.HAREKET_ALT_KATEGORI_ID = 533; //İHTAR GİDERİ

            e.NewObject = detay;
        }

        private void frmKlasorAlacakGirisi_Button_Kaydet_Click(object sender, EventArgs e)
        {
            TransactionManager tran = new TransactionManager(Kimlik.SirketBilgisi.ConStr);

            try
            {
                if (IhtarnameVarmi)
                {
                    AV001_TDI_BIL_TEBLIGAT ihtarname = bndIhtarname.Current as AV001_TDI_BIL_TEBLIGAT;
                    AV001_TDI_BIL_MASRAF_AVANS masraf = new AV001_TDI_BIL_MASRAF_AVANS();

                    TList<AV001_TI_BIL_ALACAK_NEDEN> alacakNedenleri = new TList<AV001_TI_BIL_ALACAK_NEDEN>(bndAlacakNedeni.List);

                    foreach (var item in alacakNedenleri)
                    {
                        if (!item.IsSelected && item.ALACAK_FAIZ_TIP_ID == (int)FaizTip.Temmerut_Faiz && item.UYGULANACAK_FAIZ_ORANI == 0)
                        {
                            XtraMessageBox.Show(string.Format("{0} Alacak Nedeninde Temerrüt Faiz Oranı Girilmemiş. Faiz Oranını Girip Tekrar Deneyiniz.", item.ALACAK_NEDENI), "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    tran.BeginTransaction();

                    if (!Duzenleme)
                    {
                        #region Masraf Default Alanlar

                        masraf.KAYIT_TARIHI = DateTime.Now;
                        masraf.KONTROL_NE_ZAMAN = DateTime.Now;
                        masraf.KONTROL_VERSIYON = Kimlik.DefaultKontrolVersiyon;
                        masraf.KONTROL_KIM_ID = Kimlik.Bilgi.ID;
                        masraf.STAMP = Kimlik.DefaultStamp;
                        masraf.KLASOR_KODU = Kimlik.CurrentKlasorKodu;
                        if (lueMasrafYapan.EditValue != null)
                            masraf.CARI_ID = (int)lueMasrafYapan.EditValue;
                        masraf.PROJE_ID = MyProje.ID;
                        masraf.REFERANS_NO = string.Format(@"{0}\{1}\{2}", DateTime.Today.Year, DateTime.Today.Month, Guid.NewGuid().ToString().Split('-')[0].ToUpper());
                        masraf.MANUEL_KAYIT_MI = true;

                        #endregion Masraf Default Alanlar

                        #region İhtarname Boş Geçilemez Alanlar

                        ihtarname.TEBLIGAT_REFERANS_NO = LayForm.frmLayTabligatKayit.TebligatReferansNoOlustur();
                        ihtarname.ANA_TUR_ID = DataRepository.TDI_KOD_TEBLIGAT_KONUProvider.GetByID((int)lueKonu.EditValue).ANA_TUR_ID;
                        ihtarname.ALT_TUR_ID = DataRepository.TDI_KOD_TEBLIGAT_KONUProvider.GetByID((int)lueKonu.EditValue).ALT_TUR_ID;

                        foreach (var item in alacakNedenleri[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                        {
                            AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(item.TARAF_CARI_ID);

                            if (cari != null)
                                if (cari.MUVEKKIL_MI == true)
                                    ihtarname.HAZIRLAYAN_ID = cari.ID;
                        }

                        #endregion İhtarname Boş Geçilemez Alanlar

                        DataRepository.AV001_TDI_BIL_TEBLIGATProvider.Save(tran, ihtarname);

                        if (ihtarname.KONU_ID == 482)//NOTERDEN BORÇ İKRARI
                        {
                            AV001_TI_BIL_ILAM_MAHKEMESI ilam = new AV001_TI_BIL_ILAM_MAHKEMESI();

                            ilam.KAYIT_TARIHI = DateTime.Now;
                            ilam.KONTROL_NE_ZAMAN = DateTime.Now;
                            ilam.KONTROL_VERSIYON = Kimlik.DefaultKontrolVersiyon;
                            ilam.KONTROL_KIM_ID = Kimlik.Bilgi.ID;
                            ilam.STAMP = Kimlik.DefaultStamp;
                            ilam.KLASOR_KODU = Kimlik.CurrentKlasorKodu;

                            ilam.ADLI_BIRIM_ADLIYE_ID = ihtarname.ADLI_BIRIM_ADLIYE_ID.Value;
                            ilam.ADLI_BIRIM_NO_ID = ihtarname.ADLI_BIRIM_NO_ID;
                            ilam.ADLI_BIRIM_GOREV_ID = ihtarname.ADLI_BIRIM_GOREV_ID.Value;
                            ilam.ESAS_NO = ihtarname.TEBLIGAT_ESAS_NO;
                            ilam.ILAM_TIP_ID = 5;//NOTER ALACAK SENEDI
                            ilam.KARAR_TARIHI = ihtarname.POSTALANMA_TARIH;

                            DataRepository.AV001_TI_BIL_ILAM_MAHKEMESIProvider.Save(tran, ilam);

                            if (!MyProje.AV001_TDIE_BIL_PROJE_ILAM_BILGILERICollection.Exists(vi => vi.ILAM_ID == ilam.ID))
                            {
                                AV001_TDIE_BIL_PROJE_ILAM_BILGILERI ilamProje = new AV001_TDIE_BIL_PROJE_ILAM_BILGILERI();
                                ilamProje.ILAM_ID = ilam.ID;
                                ilamProje.PROJE_ID = MyProje.ID;
                                DataRepository.AV001_TDIE_BIL_PROJE_ILAM_BILGILERIProvider.DeepSave(tran, ilamProje);
                            }
                        }

                        #region İhtarname Tarafları Kaydı

                        foreach (var item in alacakNedenleri[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                        {
                            AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(item.TARAF_CARI_ID);

                            if (cari != null)
                            {
                                if (cari.MUVEKKIL_MI == true)
                                {
                                    AV001_TDI_BIL_TEBLIGAT_YAPAN yapan = new AV001_TDI_BIL_TEBLIGAT_YAPAN();

                                    yapan.KAYIT_TARIHI = DateTime.Now;
                                    yapan.KONTROL_NE_ZAMAN = DateTime.Now;
                                    yapan.KONTROL_VERSIYON = Kimlik.DefaultKontrolVersiyon;
                                    yapan.KONTROL_KIM_ID = Kimlik.Bilgi.ID;
                                    yapan.STAMP = Kimlik.DefaultStamp;
                                    yapan.KLASOR_KODU = Kimlik.CurrentKlasorKodu;

                                    yapan.TEBLIGAT_ID = ihtarname.ID;
                                    yapan.YAPAN_CARI_ID = item.TARAF_CARI_ID;
                                    DataRepository.AV001_TDI_BIL_TEBLIGAT_YAPANProvider.DeepSave(tran, yapan);
                                }

                                else
                                {
                                    AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatap = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();

                                    muhatap.KAYIT_TARIHI = DateTime.Now;
                                    muhatap.KONTROL_NE_ZAMAN = DateTime.Now;
                                    muhatap.KONTROL_VERSIYON = Kimlik.DefaultKontrolVersiyon;
                                    muhatap.KONTROL_KIM_ID = Kimlik.Bilgi.ID;
                                    muhatap.STAMP = Kimlik.DefaultStamp;
                                    muhatap.KLASOR_KODU = Kimlik.CurrentKlasorKodu;

                                    muhatap.TEBLIGAT_ID = ihtarname.ID;
                                    muhatap.MUHATAP_CARI_ID = item.TARAF_CARI_ID;
                                    DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.DeepSave(tran, muhatap);
                                }
                            }
                        }

                        #endregion İhtarname Tarafları Kaydı
                    }

                    foreach (var item in alacakNedenleri)
                    {
                        if (item.ALACAK_NEDEN_KOD_ID != 54)//DIGER_ALACAK
                            item.DIGER_ALACAK_NEDENI = DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(item.ALACAK_NEDEN_KOD_ID.Value).ALACAK_NEDENI;

                        item.TO_ALACAK_FAIZ_TIP_ID = item.ALACAK_FAIZ_TIP_ID;
                        item.TO_UYGULANACAK_FAIZ_ORANI = item.UYGULANACAK_FAIZ_ORANI;

                        DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(tran, item);

                        TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> alacakNedenTaraf = item.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection;
                        if (Duzenleme)
                            alacakNedenTaraf = (bndAlacakNedenTaraf.List as TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>).FindAll(vi => vi.ICRA_ALACAK_NEDEN_ID == item.ID);

                        DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepSave(tran, alacakNedenTaraf, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>));

                        #region Taraf Faiz Kayıt

                        foreach (var tarafFaiz in item.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                        {
                            if (tarafFaiz.TARAF_SIFAT_ID != (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)
                            {
                                foreach (var faiz in tarafFaiz.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection)
                                {
                                    faiz.ALACAK_NEDEN_TARAF_ID = tarafFaiz.ID;
                                    faiz.ICRA_ALACAK_NEDEN_ID = item.ID;
                                }
                                DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZProvider.Save(tran, tarafFaiz.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection);
                            }
                        }

                        #endregion Taraf Faiz Kayıt

                        if (!Duzenleme && item.IHTAR_GIDERI != 0)
                        {
                            AV001_TDI_BIL_MASRAF_AVANS_DETAY detay = bndMasraf.Current as AV001_TDI_BIL_MASRAF_AVANS_DETAY;

                            masraf.ALACAK_NEDEN_ID = item.ID;
                            masraf.MASRAF_AVANS_TIP = (int)MasrafAvansTip.Masraf;
                            item.AV001_TDI_BIL_MASRAF_AVANSCollection.Add(masraf);

                            DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepSave(tran, item.AV001_TDI_BIL_MASRAF_AVANSCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));

                            detay.MASRAF_AVANS_ID = item.AV001_TDI_BIL_MASRAF_AVANSCollection[0].ID;
                            detay.TOPLAM_TUTAR = detay.BIRIM_FIYAT;
                            detay.TOPLAM_TUTAR_DOVIZ_ID = detay.BIRIM_FIYAT_DOVIZ_ID.Value;
                            detay.MUVEKKIL_CARI_ID = alacakNedenleri[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Where(vi => vi.TARAF_SIFAT_ID == (int)TarafSifat.ALACAKLI).FirstOrDefault().TARAF_CARI_ID;
                            detay.HAREKET_ANA_KATEGORI_ID = (int)MuhasebeAnaKategori.ICRA_TAKIP_MASRAFLARI;
                            detay.HAREKET_ALT_KATEGORI_ID = 813;

                            DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.Save(tran, detay);

                            AV001_TDIE_BIL_PROJE_MASRAF_AVANS projeMasraf = item.AV001_TDI_BIL_MASRAF_AVANSCollection[0].AV001_TDIE_BIL_PROJE_MASRAF_AVANSCollection.AddNew();

                            projeMasraf.PROJE_ID = MyProje.ID;
                            foreach (var pMasraf in item.AV001_TDI_BIL_MASRAF_AVANSCollection[0].AV001_TDIE_BIL_PROJE_MASRAF_AVANSCollection)
                            {
                                pMasraf.MASRAF_AVANS_ID = item.AV001_TDI_BIL_MASRAF_AVANSCollection[0].ID;
                                DataRepository.AV001_TDIE_BIL_PROJE_MASRAF_AVANSProvider.DeepSave(tran, pMasraf);
                            }

                            //if (!MyProje.AV001_TDIE_BIL_PROJE_MASRAF_AVANSCollection.Exists(vi => vi.MASRAF_AVANS_ID == masraf.ID))
                            //{
                            //    AV001_TDIE_BIL_PROJE_MASRAF_AVANS masrafProje = new AV001_TDIE_BIL_PROJE_MASRAF_AVANS();
                            //    masrafProje.PROJE_ID = MyProje.ID;
                            //    masrafProje.MASRAF_AVANS_ID = masraf.ID;
                            //    DataRepository.AV001_TDIE_BIL_PROJE_MASRAF_AVANSProvider.DeepSave(tran, masrafProje);
                            //}
                        }

                        if (MyProje.AV001_TDIE_BIL_PROJE_ALACAK_NEDENCollection.Count == 0)
                            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_ALACAK_NEDEN>));
                        if (!MyProje.AV001_TDIE_BIL_PROJE_ALACAK_NEDENCollection.Exists(vi => vi.ALACAK_NEDEN_ID == item.ID))
                        {
                            AV001_TDIE_BIL_PROJE_ALACAK_NEDEN alacak = new AV001_TDIE_BIL_PROJE_ALACAK_NEDEN();
                            alacak.ALACAK_NEDEN_ID = item.ID;
                            alacak.PROJE_ID = MyProje.ID;
                            DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDENProvider.DeepSave(tran, alacak);
                            MyProje.AV001_TDIE_BIL_PROJE_ALACAK_NEDENCollection.Add(alacak);
                        }

                        if (Duzenleme && item.NN_TEBLIGAT_ALACAK_NEDENCollection.Count() == 0)
                            DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TList<NN_TEBLIGAT_ALACAK_NEDEN>));
                        if (!item.NN_TEBLIGAT_ALACAK_NEDENCollection.Exists(vi => vi.TEBLIGAT_ID == ihtarname.ID))
                        {
                            NN_TEBLIGAT_ALACAK_NEDEN tebligatAlacak = new NN_TEBLIGAT_ALACAK_NEDEN();
                            tebligatAlacak.TEBLIGAT_ID = ihtarname.ID;
                            tebligatAlacak.ALACAK_NEDEN_ID = item.ID;
                            DataRepository.NN_TEBLIGAT_ALACAK_NEDENProvider.DeepSave(tran, tebligatAlacak);
                        }
                    }

                    if (!MyProje.AV001_TDIE_BIL_PROJE_IHTARNAMECollection.Exists(vi => vi.TEBLIGAT_ID == ihtarname.ID))
                    {
                        AV001_TDIE_BIL_PROJE_IHTARNAME iht = new AV001_TDIE_BIL_PROJE_IHTARNAME();
                        iht.TEBLIGAT_ID = ihtarname.ID;
                        iht.PROJE_ID = MyProje.ID;
                        DataRepository.AV001_TDIE_BIL_PROJE_IHTARNAMEProvider.DeepSave(tran, iht);
                    }

                    tran.Commit();

                    if (masraf.CARI_ID != 0 && masraf.ID != 0)
                        AvukatProLib.Hesap.MuhasebeAraclari.SetCariHesapByMasrafAvans(masraf.ID);

                    XtraMessageBox.Show("Kayıt işlemi başarı ile gerçekleştirildi.", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

                else
                {
                    TList<AV001_TI_BIL_ALACAK_NEDEN> alacakNedenleri = new TList<AV001_TI_BIL_ALACAK_NEDEN>(bndAlacakNedeni.List);

                    foreach (var item in alacakNedenleri)
                    {
                        if (!item.IsSelected && item.ALACAK_FAIZ_TIP_ID == (int)FaizTip.Temmerut_Faiz && item.UYGULANACAK_FAIZ_ORANI == 0)
                        {
                            XtraMessageBox.Show(string.Format("{0} Alacak Nedeninde Temerrüt Faiz Oranı Girilmemiş. Faiz Oranını Girip Tekrar Deneyiniz.", item.ALACAK_NEDENI), "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    tran.BeginTransaction();

                    foreach (var item in alacakNedenleri)
                    {
                        item.DIGER_ALACAK_NEDENI = DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(item.ALACAK_NEDEN_KOD_ID.Value).ALACAK_NEDENI;
                        item.TO_ALACAK_FAIZ_TIP_ID = item.ALACAK_FAIZ_TIP_ID;
                        item.TO_UYGULANACAK_FAIZ_ORANI = item.UYGULANACAK_FAIZ_ORANI;

                        DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(tran, item);

                        TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> alacakNedenTaraf = item.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection;
                        DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepSave(tran, alacakNedenTaraf, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>));

                        #region Taraf Faiz Kayıt

                        foreach (var tarafFaiz in item.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                        {
                            if (tarafFaiz.TARAF_SIFAT_ID != (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)
                            {
                                foreach (var faiz in tarafFaiz.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection)
                                {
                                    faiz.ALACAK_NEDEN_TARAF_ID = tarafFaiz.ID;
                                    faiz.ICRA_ALACAK_NEDEN_ID = item.ID;
                                }
                                DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZProvider.Save(tran, tarafFaiz.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection);
                            }
                        }

                        #endregion Taraf Faiz Kayıt

                        if (MyProje.AV001_TDIE_BIL_PROJE_ALACAK_NEDENCollection.Count == 0)
                            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_ALACAK_NEDEN>));
                        if (!MyProje.AV001_TDIE_BIL_PROJE_ALACAK_NEDENCollection.Exists(vi => vi.ALACAK_NEDEN_ID == item.ID))
                        {
                            AV001_TDIE_BIL_PROJE_ALACAK_NEDEN alacak = new AV001_TDIE_BIL_PROJE_ALACAK_NEDEN();
                            alacak.ALACAK_NEDEN_ID = item.ID;
                            alacak.PROJE_ID = MyProje.ID;
                            DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDENProvider.DeepSave(tran, alacak);
                            MyProje.AV001_TDIE_BIL_PROJE_ALACAK_NEDENCollection.Add(alacak);
                        }
                    }

                    tran.Commit();

                    XtraMessageBox.Show("Kayıt işlemi başarı ile gerçekleştirildi.", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        #endregion <MB-20103003> KAYIT, ADDINGNEW EVENTS

        #region <MB-20103003> EVENTS

        private void alacakNeden_ColumnChanged(object sender, AV001_TI_BIL_ALACAK_NEDENEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN alacak = sender as AV001_TI_BIL_ALACAK_NEDEN;
            if (alacak == null) return;

            #region ALACAK_FAIZ_TIP_ID

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.ALACAK_FAIZ_TIP_ID)
            {
                alacak.UYGULANACAK_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)e.Value, alacak.ISLEME_KONAN_TUTAR_DOVIZ_ID, MyProje != null ? MyProje.BASLANGIC_TARIHI : DateTime.Today);

                //if ((int)e.Value == (int)AvukatProLib.Extras.FaizTip.Temmerut_Faiz)
                //{
                //    if ((bndAlacakNedeni.Current as AV001_TI_BIL_ALACAK_NEDEN).UYGULANACAK_FAIZ_ORANI == 0)
                //        spFaizOrani.Enabled = true;
                //}
                //else
                //    spFaizOrani.Enabled = false;

                alacak.TO_ALACAK_FAIZ_TIP_ID = (int)e.Value;
            }

            #endregion ALACAK_FAIZ_TIP_ID

            #region CEK_YAPRAGI_SORUMLULUK_MIKTARI

            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.CEK_YAPRAGI_SORUMLULUK_MIKTARI)
            {
                alacak.TUTARI = Convert.ToDecimal(alacak.ADET * alacak.CEK_YAPRAGI_SORUMLULUK_MIKTARI);
            }

            #endregion CEK_YAPRAGI_SORUMLULUK_MIKTARI

            #region DEPO_SAYISI || IADE_SAYISI || TAZMIN_SAYISI)

            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.DEPO_SAYISI
                     || e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.IADE_SAYISI || e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TAZMIN_SAYISI)
            {
                if (alacak.CEK_YAPRAGI_SORUMLULUK_MIKTARI.HasValue)
                {
                    if (alacak.DEPO_SAYISI.HasValue)
                        alacak.DEPO_MIKTARI = alacak.CEK_YAPRAGI_SORUMLULUK_MIKTARI * alacak.DEPO_SAYISI;
                    if (alacak.IADE_SAYISI.HasValue)
                        alacak.IADE_MIKTARI = alacak.CEK_YAPRAGI_SORUMLULUK_MIKTARI * alacak.IADE_SAYISI;
                    if (alacak.TAZMIN_SAYISI.HasValue)
                        alacak.TAZMIN_MIKTARI = alacak.CEK_YAPRAGI_SORUMLULUK_MIKTARI * alacak.TAZMIN_SAYISI;

                    alacak.DEPO_MIKTARI_DOVIZ_ID = alacak.IADE_MIKTARI_DOVIZ_ID = alacak.TAZMIN_MIKTAR_DOVIZ_ID = alacak.CEK_YAPRAGI_SORUMLULUK_MIKTARI_DOVIZ_ID;
                }
                int toplam = (alacak.DEPO_SAYISI ?? 0) + (alacak.IADE_SAYISI ?? 0) + (alacak.TAZMIN_SAYISI ?? 0);
                decimal tutar = (decimal)(alacak.CEK_YAPRAGI_SORUMLULUK_MIKTARI * (toplam));
                alacak.ISLEME_KONAN_TUTAR = Convert.ToDecimal(alacak.TUTARI - tutar);
            }

            #endregion DEPO_SAYISI || IADE_SAYISI || TAZMIN_SAYISI)

            #region DEPO_MIKTARI || IADE_MIKTARI || TAZMIN_MIKTARI)

            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.DEPO_MIKTARI
                     || e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.IADE_MIKTARI || e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TAZMIN_MIKTARI)
            {
                if (alacak.CEK_YAPRAGI_SORUMLULUK_MIKTARI.HasValue) return;
                decimal tutar = 0;
                if (alacak.DEPO_MIKTARI.HasValue)
                    tutar += alacak.DEPO_MIKTARI.Value;
                if (alacak.IADE_MIKTARI.HasValue)
                    tutar += alacak.IADE_MIKTARI.Value;
                if (alacak.TAZMIN_MIKTARI.HasValue)
                    tutar += alacak.TAZMIN_MIKTARI.Value;
                alacak.ISLEME_KONAN_TUTAR = Convert.ToDecimal(alacak.TUTARI - tutar);
            }

            #endregion DEPO_MIKTARI || IADE_MIKTARI || TAZMIN_MIKTARI)

            #region TUTARI || TUTAR_DOVIZ_ID || HESAPLAMA_MODU

            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TUTARI ||
                     e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TUTAR_DOVIZ_ID ||
                     e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.HESAPLAMA_MODU)
            {
                if (alacak.HESAPLAMA_MODU != (int)IcraDovizIslemTipi.Takip_Tarihinde_TL)
                    if (alacak.TUTAR_DOVIZ_ID != 1)
                        alacak.HESAPLAMA_MODU = (int)IcraDovizIslemTipi.Fiili_Ödeme_Tarihinde_TL;

                if (alacak.IsSelected)
                {
                    alacak.ISLEME_KONAN_TUTAR = alacak.TUTARI;
                    alacak.ISLEME_KONAN_TUTAR_DOVIZ_ID = alacak.TUTAR_DOVIZ_ID.Value; //YTL
                    return;
                }

                switch ((IcraDovizIslemTipi)alacak.HESAPLAMA_MODU)
                {
                    case IcraDovizIslemTipi.Vade_Tarihinde_TL:
                        if (!alacak.VADE_TARIHI.HasValue)
                            alacak.VADE_TARIHI = DateTime.Today;
                        alacak.ISLEME_KONAN_TUTAR = AvukatProLib.Hesap.DovizHelper.CevirYTL(alacak.TUTARI,
                                                                                            alacak.TUTAR_DOVIZ_ID,
                                                                                            alacak.VADE_TARIHI.Value);
                        alacak.ISLEME_KONAN_TUTAR_DOVIZ_ID = 1; //YTL
                        break;

                    case IcraDovizIslemTipi.Takip_Tarihinde_TL:
                        if (MyProje.BASLANGIC_TARIHI == null)
                            MyProje.BASLANGIC_TARIHI = DateTime.Today;
                        AvukatProLib.Hesap.DovizHelper.GetMerkezBankasiBilgisi(alacak.ALACAK_NEDEN_KOD_ID);
                        alacak.ISLEME_KONAN_TUTAR = AvukatProLib.Hesap.DovizHelper.CevirYTL(alacak.TUTARI,
                                                                                            alacak.TUTAR_DOVIZ_ID,
                                                                                            MyProje.BASLANGIC_TARIHI, alacak.ALACAK_NEDEN_KOD_ID);

                        alacak.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.En_Yüksek_Mevduat_Faizi;
                        alacak.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Reeskont_Avans;
                        alacak.ISLEME_KONAN_TUTAR_DOVIZ_ID = 1; //YTL
                        break;

                    case IcraDovizIslemTipi.Fiili_Ödeme_Tarihinde_TL:
                        alacak.ISLEME_KONAN_TUTAR = alacak.TUTARI;
                        alacak.ISLEME_KONAN_TUTAR_DOVIZ_ID = alacak.TUTAR_DOVIZ_ID;

                        break;

                    default:
                        break;
                }

                if (Duzenleme)
                {
                    foreach (var item in (bndAlacakNedenTaraf.DataSource as TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>))
                    {
                        if (item.TARAF_SIFAT_ID == 1) continue;
                        else
                        {
                            item.SORUMLU_OLUNAN_MIKTAR = alacak.ISLEME_KONAN_TUTAR;
                            item.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = alacak.ISLEME_KONAN_TUTAR_DOVIZ_ID;
                        }
                    }
                }
            }

            #endregion TUTARI || TUTAR_DOVIZ_ID || HESAPLAMA_MODU

            #region VADE_TARIHI

            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.VADE_TARIHI)

            //if (alacak.ALACAK_NEDEN_KOD_ID != 99)//MER`İ TEMİNAT MEKTUBU//Gayrinakit alacaklarda vade ve düzenleme t. silindiğ için bu kontrol kaldırıldı.
            {
                alacak.DUZENLENME_TARIHI = (DateTime?)e.Value;
                alacak.FAIZ_BASLANGIC_TARIHI = (DateTime?)e.Value;

                alacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.FindAll(vi => vi.TARAF_SIFAT_ID != 1).ForEach(item =>
                    {
                        item.TEMERRUT_TARIHI = (DateTime?)e.Value;
                    });
            }

            #endregion VADE_TARIHI

            #region ALACAK_NEDEN_KOD_ID

            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.ALACAK_NEDEN_KOD_ID)
            {
                if (alacak.IsSelected)//Gayrinakit
                {
                    alacak.VADE_TARIHI = null;

                    //alacak.DUZENLENME_TARIHI = alacak.VADE_TARIHI;
                    //alacak.FAIZ_BASLANGIC_TARIHI = alacak.VADE_TARIHI;
                    //(bndAlacakNedeni.Current as AV001_TI_BIL_ALACAK_NEDEN).FAIZ_BASLANGIC_TARIHI = null;
                }
                else if (IhtarnameVarmi)//Nakit, İhtarname var.
                {
                    alacak.VADE_TARIHI = (bndIhtarname.Current as AV001_TDI_BIL_TEBLIGAT).POSTALANMA_TARIH;

                    //alacak.DUZENLENME_TARIHI = alacak.VADE_TARIHI;
                    //alacak.FAIZ_BASLANGIC_TARIHI = alacak.VADE_TARIHI;

                    //(bndAlacakNedeni.Current as AV001_TI_BIL_ALACAK_NEDEN).FAIZ_BASLANGIC_TARIHI = (bndIhtarname.Current as AV001_TDI_BIL_TEBLIGAT).POSTALANMA_TARIH;
                }
                else//Nakit, İhtarname yok.
                {
                    alacak.VADE_TARIHI = DateTime.Now;

                    //alacak.DUZENLENME_TARIHI = alacak.VADE_TARIHI;
                    //alacak.FAIZ_BASLANGIC_TARIHI = alacak.VADE_TARIHI;
                    //(bndAlacakNedeni.Current as AV001_TI_BIL_ALACAK_NEDEN).FAIZ_BASLANGIC_TARIHI = DateTime.Now;
                }
            }

            #endregion ALACAK_NEDEN_KOD_ID

            #region ISLEME_KONAN_TUTAR

            //2. ve sonraki alacak nedeni taraflarının Sorumluluk Miktarlarının o alacak nedeninin İşleme Konan Tutarının gelmesi sağlanıyor.
            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.ISLEME_KONAN_TUTAR ||
              e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.ISLEME_KONAN_TUTAR_DOVIZ_ID)
            {
                if (alacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count != 0 ||
                    alacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection != null)
                {
                    foreach (var item in alacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                    {
                        if (item.TARAF_SIFAT_ID != (int)TarafSifat.ALACAKLI)
                        {
                            item.SORUMLU_OLUNAN_MIKTAR = alacak.ISLEME_KONAN_TUTAR;
                            item.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = alacak.ISLEME_KONAN_TUTAR_DOVIZ_ID;
                        }
                    }
                }
            }

            #endregion ISLEME_KONAN_TUTAR

            #region UYGULANACAK_FAIZ_ORANI

            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.UYGULANACAK_FAIZ_ORANI)
            {
                if (alacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count != 0 ||
                    alacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection != null)
                {
                    foreach (var item in alacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                    {
                        if (item.TARAF_SIFAT_ID != (int)TarafSifat.ALACAKLI)
                        {
                            if (item.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Count == 0 ||
                                item.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection == null)
                            {
                                AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ faiz = new AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ();
                                faiz.FAIZ_TIP_ID = alacak.ALACAK_FAIZ_TIP_ID;
                                faiz.FAIZ_ORANI = alacak.UYGULANACAK_FAIZ_ORANI;
                                if (alacak.FAIZ_BASLANGIC_TARIHI.HasValue)
                                    faiz.FAIZ_BASLANGIC_TARIHI = alacak.FAIZ_BASLANGIC_TARIHI.Value;
                                else
                                    faiz.FAIZ_BASLANGIC_TARIHI = MyProje.BASLANGIC_TARIHI;
                                faiz.FAIZ_BITIS_TARIHI = MyProje.BASLANGIC_TARIHI;

                                item.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Add(faiz);
                            }
                        }
                    }
                }

                alacak.TO_UYGULANACAK_FAIZ_ORANI = (double)e.Value;
            }

            #endregion UYGULANACAK_FAIZ_ORANI
        }

        private void bndAlacakNedeni_ListChanged(object sender, ListChangedEventArgs e)
        {
            //if (!IsLoaded) return;

            //lcGroupAlacakGirisi.Enabled = (bndAlacakNedeni.Count >= 1);
        }

        private void bndAlacakNedenTaraf_ListChanged(object sender, ListChangedEventArgs e)
        {
            //if (!IsLoaded) return;

            //lcGroupAlacakTaraflari.Enabled = (bndAlacakNedenTaraf.Count >= 1);
            //lcGroupAlacakNedenFaiz.Enabled = (bndAlacakNedenTaraf.Count >= 1);
        }

        private void chIhtarname_CheckedChanged(object sender, EventArgs e)
        {
            lcGroupIhtarnameBilgileri.Enabled = chIhtarname.Checked;
            IhtarnameVarmi = chIhtarname.Checked;

            if (!Duzenleme)
            {
                if (IhtarnameVarmi)
                {
                    bndIhtarname.AddingNew += bndIhtarname_AddingNew;
                    bndIhtarname.AddNew();

                    bndMasraf.AddingNew += bndMasraf_AddingNew;
                    bndMasraf.AddNew();

                    //Kredi Şubesi'nin otomatik gelmesi için eklendi. Kredi Şubesi carisi bütün veritabanlarında sabit bir ID'ye sahip değil. O nedenle text'i sorgulandı. MB
                    var masrafYapan = BelgeUtil.Inits._per_CariGetir.Find(vi => vi.AD == "KREDİ ŞUBESİ");
                    if (masrafYapan != null) lueMasrafYapan.EditValue = masrafYapan.ID;
                }
                else
                {
                    bndIhtarname.Clear();
                    bndMasraf.Clear();
                }
            }
        }

        private void lueAlacakNedeni_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue == null) return;

            int alacakNedeni = (int)e.NewValue;

            if (rgAlacakNedenTip.EditValue == null)
            {
                XtraMessageBox.Show("Önce Alacak Nedeni Tipini Seçiniz.", "UYARI", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return;
            }
            AlacakNedenineGoreXML((bool)rgAlacakNedenTip.EditValue, alacakNedeni);
            ReferansNoOzellestir();
        }

        private void lueMuhatap_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;

            if ((e.Button.Tag as string) == "CariEkle")
            {
                frmCariGenelGiris frm = new frmCariGenelGiris();
                frm.tmpCariAd = lue.Text;

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
                frm.FormClosed += delegate
                                      {
                                          DialogResult dr = frm.KayitBasarili;
                                          if (dr == System.Windows.Forms.DialogResult.OK)
                                          {
                                              //Inits.perCariGetirRefresh();
                                              BelgeUtil.Inits.perCariGetir(lueMuhatap.Properties);
                                          }
                                      };
            }
        }

        private void lueTarafAd_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;

            if ((e.Button.Tag as string) == "CariEkle")
            {
                frmCariGenelGiris frm = new frmCariGenelGiris();
                frm.tmpCariAd = lue.Text;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
            }
        }

        private void rgAlacakNedenTip_EditValueChanging(object sender, ChangingEventArgs e)
        {
            BelgeUtil.Inits.AlacakNedenGetir(lueAlacakNedeni.Properties, (bool)e.NewValue, myAlacakNedenList);
        }

        #endregion <MB-20103003> EVENTS

        private void dnAlacakTaraflari_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "Sil")
            {
                AdimAdimDavaKaydi.Util.frmKayitSil frmSil = new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TI_BIL_ALACAK_NEDEN_TARAF", string.Format("ID = {0}", (bndAlacakNedenTaraf.Current as AV001_TI_BIL_ALACAK_NEDEN_TARAF).ID));
                frmSil.Show();
            }
        }
    }
}