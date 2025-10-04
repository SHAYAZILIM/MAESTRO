using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Icra
{
    public partial class frmAlacakGirisi : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmAlacakGirisi()
        {
            InitializeComponent(); //
            InitializeEvents();
        }

        public TList<AV001_TI_BIL_ALACAK_NEDEN> alacakNedenlerim = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

        public TList<AV001_TI_BIL_ALACAK_NEDEN> alacneden;

        public bool Ihtarname;

        public bool Klasordenmi;

        private AV001_TDI_BIL_MASRAF_AVANS avans = new AV001_TDI_BIL_MASRAF_AVANS();

        /// <summary>
        /// Ýlgili projeye yeni alacak nedenleri eklemek üzere formu açmak için kullanýlan method
        /// </summary>
        /// <param name="myProje">Yeni Alacak nedeninin ekleneceði proje</param>
        /// <returns></returns>
        private TList<TI_BIL_ICRA_KULLANICI_AYAR> icraGenelayarlar = new TList<TI_BIL_ICRA_KULLANICI_AYAR>();

        /// <summary>
        /// Yeni bir alacak neden taraf eklendiðinde ilk deðerlerini vermek için kullandýðýmýz method
        /// </summary>
        private bool trfM;

        public event EventHandler<EventArgs> Kaydedildi;

        public enum AlacakSekli
        {
            Sekilsiz,
            Nakit,
            GayriNakit_Mektup,
            GayriNakit_CekTaahhut,
            GayriNakit_Akreditif,
            GayriNakit_Aval,
            GayriNakit_Diger,
            KiymetliEvrak_Cek,
            KiymetliEvrak_Bono,
            KiymetliEvrak_Police
        }

        public AlacakSekli MyAlacakSekli { get; set; }

        /// <summary>
        /// Alacaklarýn kaydedileceði Proje nesnesi
        /// </summary>
        public AV001_TDIE_BIL_PROJE MyProje { get; set; }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            InitializeAlacakNeden();
        }

        private void addnew_ColumnChanged(object sender, AV001_TDI_BIL_TEBLIGATEventArgs e)
        {
            AV001_TDI_BIL_TEBLIGAT ihtarname = sender as AV001_TDI_BIL_TEBLIGAT;
            if (e.Column == AV001_TDI_BIL_TEBLIGATColumn.HAZIRLAMA_TARIH)
            {
            }
        }

        /// <summary>
        /// Alacak nedeni üzerinde bir alan deðiþtirildiðinde çalýþan method
        /// </summary>
        private void AlacakNedenColumnChanged(object sender, AV001_TI_BIL_ALACAK_NEDENEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN gonderen = (AV001_TI_BIL_ALACAK_NEDEN)sender;
            if (alacakNedenlerim.IndexOf(gonderen) == 0 //sadece ilk kayýt için ihtar masrafýný düzenliyoruz
                && avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Count > 0
                && gonderen.IHTAR_GIDERI == 0)
            {
                List<ParaVeDovizId> list = new List<ParaVeDovizId>();
                ParaVeDovizId par = new ParaVeDovizId();
                foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                {
                    par.Para = detay.ADET * detay.TOPLAM_TUTAR;
                    par.DovizId = detay.TOPLAM_TUTAR_DOVIZ_ID;
                    list.Add(par);
                }
                ParaVeDovizId toplam = ParaVeDovizId.Topla(list);
                gonderen.IHTAR_GIDERI = toplam.Para;
                gonderen.IHTAR_GIDERI_DOVIZ_ID = toplam.DovizId;
            }

            #region Tutar Doviz ID

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TO_UYGULANACAK_FAIZ_ORANI)
            {
                gonderen.UYGULANACAK_FAIZ_ORANI = gonderen.TO_UYGULANACAK_FAIZ_ORANI;
            }
            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TO_ALACAK_FAIZ_TIP_ID)
            {
                gonderen.ALACAK_FAIZ_TIP_ID = gonderen.TO_ALACAK_FAIZ_TIP_ID;
            }
            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TUTAR_DOVIZ_ID)
            {
                if (gonderen.TUTAR_DOVIZ_ID.HasValue)
                {
                    if (gonderen.TUTAR_DOVIZ_ID.Value > 1)
                    {
                        gonderen.HESAPLAMA_MODU = (byte)AvukatProLib.Extras.IcraDovizIslemTipi.Fiili_Ödeme_Tarihinde_TL;
                    }
                    else
                    {
                        gonderen.HESAPLAMA_MODU = (byte)AvukatProLib.Extras.IcraDovizIslemTipi.Vade_Tarihinde_TL;
                    }
                    gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID = gonderen.TUTAR_DOVIZ_ID;

                    //gonderen.ALACAK_FAIZ_TIP_ID = (int)FaizTip.En_Yüksek_Mevduat_Faizi;
                    //gonderen.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.En_Yüksek_Mevduat_Faizi;
                }
            }

            #endregion Tutar Doviz ID

            #region Faiz Oranlarý Getir

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TO_ALACAK_FAIZ_TIP_ID)
            {
                gonderen.TO_UYGULANACAK_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value,
                                                                               gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID,
                                                                               DateTime.Today);
            }
            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.ALACAK_FAIZ_TIP_ID)
            {
                gonderen.UYGULANACAK_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value,
                                                                            gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID,
                                                                            DateTime.Today);
            }

            #endregion Faiz Oranlarý Getir

            #region Düzenleme Tarihini Vade Tarihine At

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.DUZENLENME_TARIHI)
            {
                gonderen.VADE_TARIHI = (DateTime?)e.Value;
                gonderen.FAIZ_BASLANGIC_TARIHI = (DateTime?)e.Value;
            }

            #endregion Düzenleme Tarihini Vade Tarihine At

            #region VadeTarihini FBasTar a At

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.VADE_TARIHI)
            {
                gonderen.FAIZ_BASLANGIC_TARIHI = (DateTime?)e.Value;
            }

            #endregion VadeTarihini FBasTar a At

            #region Tutarý ÝþlemeKonana At

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TUTARI ||
                e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TUTAR_DOVIZ_ID ||
                e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.HESAPLAMA_MODU)
            {
                switch ((IcraDovizIslemTipi)gonderen.HESAPLAMA_MODU)
                {
                    case IcraDovizIslemTipi.Vade_Tarihinde_TL:
                        if (gonderen.TUTARI > 0)
                        {
                            DovizHelper.GetMerkezBankasiBilgisi(gonderen.ALACAK_NEDEN_KOD_ID);
                            gonderen.ISLEME_KONAN_TUTAR = DovizHelper.CevirYTL(gonderen.TUTARI, gonderen.TUTAR_DOVIZ_ID,
                                                                               gonderen.VADE_TARIHI ?? DateTime.Today, gonderen.ALACAK_NEDEN_KOD_ID);
                            ucAlacakNedenGirisi1.RefreshDataSource();
                            gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID = 1; //YTL
                        }
                        break;

                    case IcraDovizIslemTipi.Takip_Tarihinde_TL:
                        if (gonderen.TUTARI > 0)
                        {
                            DovizHelper.GetMerkezBankasiBilgisi(gonderen.ALACAK_NEDEN_KOD_ID);
                            gonderen.ISLEME_KONAN_TUTAR = DovizHelper.CevirYTL(gonderen.TUTARI, gonderen.TUTAR_DOVIZ_ID,
                                                                               DateTime.Today, gonderen.ALACAK_NEDEN_KOD_ID);
                            ucAlacakNedenGirisi1.RefreshDataSource();
                            gonderen.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.En_Yüksek_Mevduat_Faizi;
                            gonderen.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Reeskont_Avans;
                            gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID = 1; //YTL
                        }
                        break;

                    case IcraDovizIslemTipi.Fiili_Ödeme_Tarihinde_TL:
                        if (gonderen.TUTARI > 0)
                        {
                            gonderen.ISLEME_KONAN_TUTAR = gonderen.TUTARI;
                            gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID = gonderen.TUTAR_DOVIZ_ID;
                            ucAlacakNedenGirisi1.RefreshDataSource();
                        }
                        break;

                    default:
                        break;
                }
            }

            #endregion Tutarý ÝþlemeKonana At

            #region Alacak Nedene Göre Þekillen

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.ALACAK_NEDEN_KOD_ID)
            {
                ucAlacakNedenGirisi1.vgAlacakNedenGirisi_FocusedRecordChanged(ucAlacakNedenGirisi1.vgAlacakNedenGirisi,
                                                                              new IndexChangedEventArgs(
                                                                                  ucAlacakNedenGirisi1.
                                                                                      vgAlacakNedenGirisi.FocusedRecord,
                                                                                  -1));
            }

            #endregion Alacak Nedene Göre Þekillen

            #region Alacak Neden e Göre Biþiyler Yap

            if (gonderen.ALACAK_NEDEN_KOD_ID.HasValue && gonderen.ALACAK_NEDEN_KOD_ID.Value > 0 &&
                e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.ALACAK_NEDEN_KOD_ID)
            {
                gonderen.DIGER_ALACAK_NEDENI =
                    DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(gonderen.ALACAK_NEDEN_KOD_ID.Value).ALACAK_NEDENI;

                gonderen.KDV_HESAPLANSIN = false;
                gonderen.OIV_HESAPLANSIN = false;
                gonderen.BSMV_HESAPLANSIN = false;

                switch (gonderen.ALACAK_NEDEN_KOD_ID.Value)
                {
                    //case 51:    //Telefon Faturasý
                    case 81: //	49	KAÇAK ELEKTRÝK FATURASI
                    case 82: //	49	ELEKTRÝK FATURASI
                    case 84: //	49	TESVÝYE
                    case 88: //	49	TESCÝL
                    case 89: //	49	TEFTÝÞ
                        gonderen.KDV_HESAPLANSIN = true;
                        break;

                    case 42: //	49	TELEFON FATURASI
                    case 51: //	153	TELEFON FATURASI
                        gonderen.KDV_HESAPLANSIN = true;
                        gonderen.OIV_HESAPLANSIN = true;
                        break;

                    case 49: //KREDI KARTI
                    case 50: //KREDI ALACAÐI

                        gonderen.BSMV_HESAPLANSIN = true;
                        break;

                    default:

                        //gonderen.KDV_HESAPLANSIN = false;
                        //gonderen.OIV_HESAPLANSIN = false;
                        //gonderen.BSMV_HESAPLANSIN = false;
                        break;
                }
                TI_KOD_ALACAK_NEDEN alacakNeden =
                    DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(gonderen.ALACAK_NEDEN_KOD_ID.Value);
                switch (alacakNeden.ALACAK_NEDENI)
                {
                    case "ÇEK":
                    case "SENET":
                    case "POLÝÇE":
                        gonderen.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Reeskont_Avans;
                        gonderen.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Reeskont_Avans;
                        break;

                    default:
                        gonderen.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Temmerut_Faiz;
                        gonderen.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Temmerut_Faiz;
                        break;
                }
            }

            #endregion Alacak Neden e Göre Biþiyler Yap

            #region Cek Yapraðý kontrolleri

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.CEK_YAPRAGI_SORUMLULUK_MIKTARI)
            {
                gonderen.TUTARI = Convert.ToDecimal(gonderen.ADET * gonderen.CEK_YAPRAGI_SORUMLULUK_MIKTARI);
            }
            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.DEPO_SAYISI
                || e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.IADE_SAYISI)
            {
                int toplam = (gonderen.DEPO_SAYISI ?? 0) + (gonderen.IADE_SAYISI ?? 0);
                decimal tutar = (decimal)(gonderen.CEK_YAPRAGI_SORUMLULUK_MIKTARI * (toplam));
                gonderen.ISLEME_KONAN_TUTAR = Convert.ToDecimal(gonderen.TUTARI - tutar);
            }
            if (e.Column != AV001_TI_BIL_ALACAK_NEDENColumn.ISLEME_KONAN_TUTAR &&
                (gonderen.DEPO_SAYISI > 0 || gonderen.IADE_SAYISI > 0))
            {
                int toplam = (gonderen.DEPO_SAYISI ?? 0) + (gonderen.IADE_SAYISI ?? 0);
                decimal tutar = (decimal)(gonderen.CEK_YAPRAGI_SORUMLULUK_MIKTARI * (toplam));
                gonderen.ISLEME_KONAN_TUTAR = Convert.ToDecimal(gonderen.TUTARI - tutar);
            }

            #endregion Cek Yapraðý kontrolleri

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.ISLEME_KONAN_TUTAR)
            {
                foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF item in gonderen.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                {
                    DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepLoad(item, false,
                                                                                    DeepLoadType.IncludeChildren,
                                                                                    typeof(TList<AV001_TDI_BIL_CARI>));
                    if (item.TARAF_CARI_IDSource != null
                        && item.TARAF_CARI_IDSource.MUVEKKIL_MI == false)
                    {
                        item.TARAF_CARI_IDSource = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(item.TARAF_CARI_ID);
                        if (item.TARAF_CARI_IDSource.MUVEKKIL_MI == false)
                        {
                            item.SORUMLU_OLUNAN_MIKTAR = gonderen.ISLEME_KONAN_TUTAR;
                            item.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value;
                            item.IHTAR_GIDERI = gonderen.IHTAR_GIDERI;
                            item.TEMERRUT_TARIHI = gonderen.IHTAR_TARIHI;
                        }
                        item.IHTAR_GIDERI_DOVIZ_ID = gonderen.IHTAR_GIDERI_DOVIZ_ID.Value;
                    }
                }
            }
            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TAZMIN_MIKTARI ||
                e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TAZMIN_MIKTAR_DOVIZ_ID)
            {
                var kalan = ParaVeDovizId.Cikart(new ParaVeDovizId(gonderen.TUTARI, gonderen.TUTAR_DOVIZ_ID),
                                                 new ParaVeDovizId(gonderen.TAZMIN_MIKTARI,
                                                                   gonderen.TAZMIN_MIKTAR_DOVIZ_ID));

                gonderen.ISLEME_KONAN_TUTAR = kalan.Para;
                gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID = kalan.DovizId;
            }

            if (gonderen.TO_ALACAK_FAIZ_TIP_ID != (int)FaizTip.Özel_Sabit_Faiz)
            {
                gonderen.SABIT_FAIZ_UYGULA = false;
            }
            else
                gonderen.SABIT_FAIZ_UYGULA = true;
        }

        /// <summary>
        /// Verilen string deðere göre alacak neden ID yi ucAlacakNedenGirisi1.rlkAlacakNeden üzerinden bulup getiren method
        /// </summary>
        /// <param name="alacakNedenKod">Id si öðrenilmek istenen alacak neden string deðer</param>
        /// <returns></returns>
        private int alacakNedenKodIdGetir(string alacakNedenKod)
        {
            if (ucAlacakNedenGirisi1.rlkAlacakNeden.DataSource == null)
                BelgeUtil.Inits.AlacakNedenKodGetir1(ucAlacakNedenGirisi1.rlkAlacakNeden);
            VList<per_TI_KOD_ALACAK_NEDEN> anList =
                ucAlacakNedenGirisi1.rlkAlacakNeden.DataSource as VList<per_TI_KOD_ALACAK_NEDEN>;
            if (anList != null)
            {
                per_TI_KOD_ALACAK_NEDEN asd = anList.Find(per_TI_KOD_ALACAK_NEDENColumn.ALACAK_NEDENI, alacakNedenKod);
                if (asd != null)
                    return asd.ID;
            }
            return 0;
        }

        /// <summary>
        /// Yeni bir alacak nedeni eklendiðinde ilk deðerlerini vermek için kullandýðýmýz method
        /// </summary>
        private void alacakNedenlerim_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN eklenen = e.NewObject as AV001_TI_BIL_ALACAK_NEDEN;
            if (eklenen == null)
                eklenen = new AV001_TI_BIL_ALACAK_NEDEN();

            //e.NewObject = eklenen;
            eklenen.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.AddingNew +=
                AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection_AddingNew;
            eklenen.HESAPLAMA_MODU = (byte)AvukatProLib.Extras.IcraDovizIslemTipi.Vade_Tarihinde_TL;
            eklenen.ColumnChanged += AlacakNedenColumnChanged;
            int cekTazminatkod =
                DataRepository.TDI_KOD_TEMINAT_TAZMINATProvider.GetByTEMINAT_TAZMINAT_ADI(
                    "ÇEK TAZMÝNAT").ID;
            TList<TDI_CET_TEMINAT_TAZMINAT> cekTazminat =
                DataRepository.TDI_CET_TEMINAT_TAZMINATProvider.GetByKATEGORI_ID(cekTazminatkod);
            if (cekTazminat.Count > 0)
                eklenen.CEK_TAZMINATI_ORANI = cekTazminat[0].ORAN;
            else
                eklenen.CEK_TAZMINATI_ORANI = 5;
            eklenen.KOMISYONU_ORANI = 0.3;
            if (Kimlikci.Kimlik.SirketBilgisi.KurumsalMod == 1501)
            {
                eklenen.TO_ALACAK_FAIZ_TIP_ID = (byte)FaizTip.Temmerut_Faiz;
                eklenen.ALACAK_FAIZ_TIP_ID = (byte)FaizTip.Temmerut_Faiz;
                eklenen.BSMV_HESAPLANSIN = true;
            }

            eklenen.HESAPLAMA_MODU = (byte)AvukatProLib.Extras.IcraDovizIslemTipi.Vade_Tarihinde_TL;

            //Eðer e.NewObject ilk geldiðinde null ise eklenen e.NewObject in referansýný tutmuyor olacaðý için
            //Tekrar eþitliyoruz.
            if (ucAlacakNedenGirisi1.DtAlacakNeden != null && ucAlacakNedenGirisi1.DtAlacakNeden.Count > 0)
            {
                if (ucAlacakNedenGirisi1.DtAlacakNeden[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count > 0)
                {
                    foreach (var trf in ucAlacakNedenGirisi1.DtAlacakNeden[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                    {
                        eklenen.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Add(trf.Copy());
                    }
                }
                foreach (var item in eklenen.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                {
                    if (item.SORUMLU_OLUNAN_MIKTAR > 0)
                        item.SORUMLU_OLUNAN_MIKTAR = 0;
                }
                if (
                    ucAlacakNedenGirisi1.DtAlacakNeden[0].AV001_TDI_BIL_TEBLIGATCollection_From_NN_TEBLIGAT_ALACAK_NEDEN
                        .Count > 0)
                {
                    eklenen.AV001_TDI_BIL_TEBLIGATCollection_From_NN_TEBLIGAT_ALACAK_NEDEN.AddRange(
                        ucAlacakNedenGirisi1.DtAlacakNeden[0].
                            AV001_TDI_BIL_TEBLIGATCollection_From_NN_TEBLIGAT_ALACAK_NEDEN);
                    eklenen.IHTAR_TARIHI = ucAlacakNedenGirisi1.DtAlacakNeden[0].IHTAR_TARIHI;

                    eklenen.DUZENLENME_TARIHI = ucAlacakNedenGirisi1.DtAlacakNeden[0].DUZENLENME_TARIHI;
                    eklenen.VADE_TARIHI = ucAlacakNedenGirisi1.DtAlacakNeden[0].VADE_TARIHI;
                }
            }
            else
                eklenen.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.AddNew();
            e.NewObject = eklenen;
        }

        private void AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF keTaraf = new AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF();
            keTaraf.KAYIT_TARIHI = DateTime.Now;
            keTaraf.KONTROL_NE_ZAMAN = DateTime.Now;
            keTaraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            keTaraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            keTaraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            keTaraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            e.NewObject = keTaraf;
        }

        private void AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatab = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();
            muhatab.OKUNDU_MU = false;
            muhatab.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            muhatab.KONTROL_NE_ZAMAN = DateTime.Today;
            muhatab.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            muhatab.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            muhatab.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            muhatab.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            e.NewObject = muhatab;
        }

        private void AV001_TDI_BIL_TEBLIGATCollection_From_NN_TEBLIGAT_ALACAK_NEDEN_AddingNew(object sender,
                                                                                                      AddingNewEventArgs e)
        {
            TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> listTakipEdilen = new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>();
            TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> listTakipEden = new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>();
            AV001_TDI_BIL_TEBLIGAT addnew = new AV001_TDI_BIL_TEBLIGAT();
            addnew.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;
            addnew.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            addnew.KONTROL_NE_ZAMAN = DateTime.Today;
            addnew.ANA_TUR_ID = 2;
            addnew.ALT_TUR_ID = 46;
            addnew.TIP_ID = 4;
            addnew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addnew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            addnew.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            addnew.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            addnew.TEBLIGAT_REFERANS_NO = AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit.TebligatReferansNoOlustur();
            addnew.TEBLIGAT_HEDEF_TIP = (short)TebligatHedefTip.Ýcra;
            addnew.KONU_ID = (int)TebligatKonu.HESAP_KAT_IHTARNAMESI;
            addnew.ADLI_BIRIM_GOREV_ID = (int)AdliBirimBolumGorev.NOT;
            addnew.ColumnChanged += addnew_ColumnChanged;
            foreach (
                AV001_TI_BIL_ALACAK_NEDEN_TARAF trf in
                    ucAlacakNedenGirisi1.DtAlacakNeden[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
            {
                if (trf.TARAF_SIFAT_ID == (int)TarafSifat.ALACAKLI)
                    listTakipEden.Add(trf);
                else
                    listTakipEdilen.Add(trf);
            }
            TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> muhList = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();
            TList<AV001_TDI_BIL_TEBLIGAT_YAPAN> yapanList = new TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>();
            addnew.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddingNew +=
                AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew;
            AV001_TDI_BIL_TEBLIGAT_MUHATAP muh = null;
            AV001_TDI_BIL_TEBLIGAT_YAPAN yapan = null;
            if (ucAlacakNedenGirisi1.DtAlacakNeden[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count > 1)
            {
                muh = addnew.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddNew();
                yapan = addnew.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddNew();
                foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF muhtrf in listTakipEdilen)
                {
                    muh.TB_SUBEDEN_OLUMSUZ_CEVAP_TARIHI = DateTime.Now;
                    muh.TB_SUBEDEN_YENI_ADRES_BILDIRILDIGI_TARIH = DateTime.Now;
                    muh.TB_SUBEDEN_YENI_ADRES_ISTEME_TARIHI = DateTime.Now;
                    muh.TB_ZABITACA_YENI_ADRES_BULUNDUGU_TARIHI = DateTime.Now;
                    if (muhtrf.TARAF_CARI_ID != null && muhtrf.TARAF_CARI_ID != 0)
                    {
                        muh.MUHATAP_CARI_ID = muhtrf.TARAF_CARI_ID;
                        muh.MUHATAP_TARAF_KOD = (short)TarafKodlari.K;
                    }
                    else if (icraGenelayarlar.Count > 0)
                    {
                        muh.MUHATAP_CARI_ID = icraGenelayarlar[0].SECILI_KARSI_TARAF_CARI_ID.Value;
                        muh.MUHATAP_TARAF_KOD = (short)TarafKodlari.K;
                    }
                }

                foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF ypntrf in listTakipEden)
                {
                    if (ypntrf.TARAF_CARI_ID != null && ypntrf.TARAF_CARI_ID != 0)
                    {
                        yapan.YAPAN_CARI_ID = ypntrf.TARAF_CARI_ID;
                        yapan.TARAF_KOD = TarafKodlari.M.ToString();
                    }
                    else if (icraGenelayarlar.Count > 0)
                    {
                        yapan.YAPAN_CARI_ID = icraGenelayarlar[0].SECILI_MUVEKKIL_CARI_ID.Value;
                        yapan.TARAF_KOD = TarafKodlari.M.ToString();
                    }
                }
            }
            else
            {
                for (int i = 0; i < MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection.Count; i++)
                {
                    muh = addnew.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddNew();
                    yapan = addnew.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddNew();
                    AV001_TDIE_BIL_PROJE_TARAF pTrf = MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection[i];
                    if (pTrf.CARI_IDSource == null)
                        DataRepository.AV001_TDIE_BIL_PROJE_TARAFProvider.DeepLoad(pTrf, false,
                                                                                   DeepLoadType.IncludeChildren,
                                                                                   typeof(AV001_TDI_BIL_CARI));
                    if (pTrf.CARI_IDSource.MUVEKKIL_MI)
                    {
                        muh.MUHATAP_CARI_ID = pTrf.CARI_ID;
                        muh.MUHATAP_TARAF_KOD = (short)TarafKodu.Muvekkil;
                    }
                    else
                    {
                        yapan.YAPAN_CARI_ID = pTrf.CARI_ID;
                        yapan.TARAF_KOD = TarafKodu.KarsiTaraf.ToString();
                    }
                }
            }
            if (muh != null)
                muhList.Add(muh);
            if (yapan != null)
                yapanList.Add(yapan);
            addnew.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection = muhList;
            addnew.AV001_TDI_BIL_TEBLIGAT_YAPANCollection = yapanList;

            e.NewObject = addnew;
        }

        private void AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN_TARAF eklenen = e.NewObject as AV001_TI_BIL_ALACAK_NEDEN_TARAF;

            if (eklenen == null)
                eklenen = new AV001_TI_BIL_ALACAK_NEDEN_TARAF();
            icraGenelayarlar =
                DataRepository.TI_BIL_ICRA_KULLANICI_AYARProvider.GetByKULLANICI_ID(AvukatProLib.Kimlik.Bilgi.ID);
            if (!trfM)
            {
                if (icraGenelayarlar.Count > 0)
                {
                    //AV001_TI_BIL_ALACAK_NEDEN_TARAF trf = new AV001_TI_BIL_ALACAK_NEDEN_TARAF();

                    eklenen.TARAF_CARI_ID = icraGenelayarlar[0].SECILI_MUVEKKIL_CARI_ID.Value;
                    if (icraGenelayarlar[0].SECILI_MUVEKKIL_CARI_ID > 0)
                    {
                        eklenen.TARAF_CARI_IDSource =
                            DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(
                                icraGenelayarlar[0].SECILI_MUVEKKIL_CARI_ID.Value);
                        if (eklenen.TARAF_CARI_IDSource != null)
                            eklenen.TARAF_CARI_ADI = eklenen.TARAF_CARI_IDSource.AD;

                        eklenen.TARAF_SIFAT_ID = (int)TarafSifat.ALACAKLI;

                        trfM = true;
                    }
                }
            }

            eklenen.ColumnChanging += eklenen_ColumnChanging;

            //Eðer e.NewObject ilk geldiðinde null ise eklenen e.NewObject in referansýný tutmuyor olacaðý için
            //Tekrar eþitliyoruz.
            e.NewObject = eklenen;
        }

        private void btnMasrafEkle_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli frm =
                new AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli();
            frm.MyDataSource = avans;
            frm.ShowDialog(MyProje);
        }

        private void eklenen_ColumnChanging(object sender, AV001_TI_BIL_ALACAK_NEDEN_TARAFEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN_TARAF trf = sender as AV001_TI_BIL_ALACAK_NEDEN_TARAF;

            if (e.Column == AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn.TARAF_CARI_ID)
            {
                if (trf.TARAF_SIFAT_ID == null) return;
                if (trf.TARAF_SIFAT_ID != null && (int)trf.TARAF_SIFAT_ID != (int)TarafSifat.ALACAKLI)
                {
                    AV001_TI_BIL_ALACAK_NEDEN ndn = ucAlacakNedenGirisi1.CurrentNeden;
                    if (ndn == null) return;
                    trf.SORUMLU_OLUNAN_MIKTAR = ndn.ISLEME_KONAN_TUTAR;
                    trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value;
                    trf.PROTESTO_GIDERI = ndn.PROTESTO_GIDERI;
                    trf.PROTESTO_GIDERI_DOVIZ_ID = ndn.PROTESTO_GIDERI_DOVIZ_ID.Value;
                    trf.IHTAR_GIDERI = ndn.IHTAR_GIDERI;
                    trf.IHTAR_GIDERI_DOVIZ_ID = ndn.IHTAR_GIDERI_DOVIZ_ID.Value;
                    trf.IHTAR_TARIHI = ndn.IHTAR_TARIHI;
                    trf.TEMERRUT_TARIHI = ndn.IHTAR_TARIHI;
                    trf.IHTAR_TEBLIG_TARIHI = ndn.IHTAR_TARIHI;
                    trf.CEK_TAZMINATI_ORANI = ndn.CEK_TAZMINATI_ORANI;
                    trf.KOMISYONU_ORANI = ndn.KOMISYONU_ORANI;
                    trf.IHTAR_TARIHI = ndn.IHTAR_TARIHI;
                    trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Clear();
                    ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Clear();
                    AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ eklenen = new AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ();
                    eklenen.FAIZ_BASLANGIC_TARIHI = ndn.FAIZ_BASLANGIC_TARIHI ?? DateTime.Now;
                    eklenen.FAIZ_TIP_ID = ndn.TO_ALACAK_FAIZ_TIP_ID;
                    eklenen.FAIZ_ORANI = ndn.TO_UYGULANACAK_FAIZ_ORANI;
                    eklenen.SABIT_FAIZ = ndn.SABIT_FAIZ_UYGULA;
                    eklenen.KAYIT_TARIHI = DateTime.Now;
                    eklenen.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    eklenen.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    eklenen.KONTROL_NE_ZAMAN = DateTime.Now;
                    eklenen.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    eklenen.TARAF_CARI_ID = trf.TARAF_CARI_ID;
                    trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Add(eklenen);
                    ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Add(eklenen);
                }
            }
        }

        /// <summary>
        /// Form üzerindeki Kaydet butonuna týklandýðýnda çalýþan method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAlacakGirisi_Button_Kaydet_Click(object sender, EventArgs e)
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                //Uyap boþ geçilemez alanlarýn kontrolü yapýlýyor.

                #region <MB-20091226>

                List<String> uyapBosAlanlar = new List<string>();
                if (ucKiymetliEvrak1.MyDataSource != null)
                {
                    for (int i = 0; i < ucKiymetliEvrak1.MyDataSource.Count; i++)
                    {
                        AV001_TDI_BIL_KIYMETLI_EVRAK kiymetliEvrak = ucKiymetliEvrak1.MyDataSource[i];
                        TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF> kiymetliEvrakTaraf =
                            ucKiymetliEvrak1.MyDataSource[i].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection;

                        if (!kiymetliEvrak.EVRAK_TANZIM_TARIHI.HasValue)
                        {
                            uyapBosAlanlar.Add(
                                String.Format(
                                    "{0} numaralý kayýtta Tanzim Tarihi bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                    i + 1));
                        }
                        if (!kiymetliEvrak.EVRAK_VADE_TARIHI.HasValue)
                        {
                            uyapBosAlanlar.Add(
                                String.Format(
                                    "{0} numaralý kayýtta Vade tarihi bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                    i + 1));
                        }
                        if (kiymetliEvrak.TUTAR == null)
                        {
                            uyapBosAlanlar.Add(
                                String.Format(
                                    "{0} numaralý kayýtta Tutar bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ", i + 1));
                        }

                        if (kiymetliEvrak.EVRAK_TUR_ID.HasValue)
                        {
                            if (kiymetliEvrak.EVRAK_TUR_ID.Value == (int)EvrakTurleri.ÇEK)
                            {
                                if (!kiymetliEvrak.BANKA_ID.HasValue)
                                {
                                    uyapBosAlanlar.Add(
                                        String.Format(
                                            "{0} numaralý kayýtta Banka bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                            i + 1));
                                }
                                if (!kiymetliEvrak.SUBE_ID.HasValue)
                                {
                                    uyapBosAlanlar.Add(
                                        String.Format(
                                            "{0} numaralý kayýtta Þube bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                            i + 1));
                                }
                                if (string.IsNullOrEmpty(kiymetliEvrak.HESAP_NO.Trim()))
                                {
                                    uyapBosAlanlar.Add(
                                        String.Format(
                                            "{0} numaralý kayýtta Hesap No bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                            i + 1));
                                }
                                if (string.IsNullOrEmpty(kiymetliEvrak.CEK_NO.Trim()))
                                {
                                    uyapBosAlanlar.Add(
                                        String.Format(
                                            "{0} numaralý kayýtta Çek No bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                            i + 1));
                                }
                            }
                            if (kiymetliEvrak.EVRAK_TUR_ID.Value == (int)EvrakTurleri.BONO)
                            {
                                if (!kiymetliEvrak.EVRAK_VADE_TARIHI.HasValue)
                                {
                                    uyapBosAlanlar.Add(
                                        String.Format(
                                            "{0} numaralý kayýtta Vade tarihi bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                            i + 1));
                                }
                            }
                            if (kiymetliEvrak.EVRAK_TUR_ID.Value == (int)EvrakTurleri.POLÝÇE)
                            {
                                if (!kiymetliEvrak.EVRAK_VADE_TARIHI.HasValue)
                                {
                                    uyapBosAlanlar.Add(
                                        String.Format(
                                            "{0} numaralý kayýtta Vade tarihi bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                            i + 1));
                                }

                                if (!kiymetliEvrakTaraf[i].TARAF_CARI_ID.HasValue)
                                {
                                    uyapBosAlanlar.Add(
                                        String.Format(
                                            "{0} numaralý kayýtta Kýymetli Evrak Taraf bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                            i + 1));
                                }
                            }
                        }
                    }
                }

                if (uyapBosAlanlar.Count > 0)
                {
                    string birlestirilmisHata = string.Empty;
                    foreach (string str in uyapBosAlanlar)
                    {
                        birlestirilmisHata += Environment.NewLine + str;
                    }
                    DialogResult dr =
                        XtraMessageBox.Show(
                            "<Aþaðýda bulunan alan(lar) Uyap için zorunludur. Boþ geçmek istediðinize emin misiniz?" +
                            birlestirilmisHata, "Hata", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No)
                        return;
                }

                #endregion <MB-20091226>

                tran.BeginTransaction();

                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(tran, ucAlacakNedenGirisi1.DtAlacakNeden,
                                                                          DeepSaveType.IncludeChildren,
                                                                          typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>
                                                                              ));
                foreach (AV001_TI_BIL_ALACAK_NEDEN an in ucAlacakNedenGirisi1.DtAlacakNeden)
                {
                    foreach (var item in an.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                    {
                        item.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.ForEach(
                            vi => vi.TARAF_CARI_ID = item.TARAF_CARI_ID);
                    }
                    DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepSave(tran,
                                                                                    an.
                                                                                        AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection,
                                                                                    DeepSaveType.IncludeChildren,
                                                                                    typeof(
                                                                                        TList
                                                                                        <
                                                                                        AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ
                                                                                        >));
                }

                foreach (AV001_TI_BIL_ALACAK_NEDEN an in ucAlacakNedenGirisi1.DtAlacakNeden)
                {
                    an.AV001_TDI_BIL_MASRAF_AVANSCollection.Add(avans);

                    if (
                        MyProje.AV001_TDIE_BIL_PROJE_ALACAK_NEDENCollection.Exists(
                            delegate(AV001_TDIE_BIL_PROJE_ALACAK_NEDEN alacakNeden) { return alacakNeden.ALACAK_NEDEN_ID == an.ID; })) continue;
                    AV001_TDIE_BIL_PROJE_ALACAK_NEDEN alacak = new AV001_TDIE_BIL_PROJE_ALACAK_NEDEN();
                    alacak.ALACAK_NEDEN_ID = an.ID;
                    alacak.PROJE_ID = MyProje.ID;
                    DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDENProvider.DeepSave(tran, alacak);
                }

                if (ucKiymetliEvrak1.MyDataSource != null)
                {
                    DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepSave(tran, ucKiymetliEvrak1.MyDataSource,
                                                                                 DeepSaveType.IncludeChildren,
                                                                                 typeof(
                                                                                     TList
                                                                                     <AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF
                                                                                     >));

                    foreach (AV001_TDI_BIL_KIYMETLI_EVRAK item in ucKiymetliEvrak1.MyDataSource)
                    {
                        foreach (var aNeden in ucAlacakNedenGirisi1.DtAlacakNeden)
                        {
                            if (
                                aNeden.AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAKCollection.Exists(
                                    delegate(AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK kiymet) { return kiymet.KIYMETLI_EVRAK_ID == item.ID; })) continue;
                            AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK kEvrak =
                                new AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK();
                            kEvrak.KIYMETLI_EVRAK_ID = item.ID;
                            kEvrak.ALACAK_NEDEN_ID = aNeden.ID;
                            DataRepository.AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAKProvider.DeepSave(tran, kEvrak);
                        }
                    }
                }
                foreach (
                    AV001_TDI_BIL_TEBLIGAT an in
                        ucAlacakNedenGirisi1.CurrentNeden.AV001_TDI_BIL_TEBLIGATCollection_From_NN_TEBLIGAT_ALACAK_NEDEN
                    )
                {
                    if (
                        MyProje.AV001_TDIE_BIL_PROJE_IHTARNAMECollection.Exists(
                            delegate(AV001_TDIE_BIL_PROJE_IHTARNAME ihtarname) { return ihtarname.TEBLIGAT_ID == an.ID; })) continue;
                    AV001_TDIE_BIL_PROJE_IHTARNAME iht = new AV001_TDIE_BIL_PROJE_IHTARNAME();
                    iht.TEBLIGAT_ID = an.ID;
                    iht.PROJE_ID = MyProje.ID;
                    DataRepository.AV001_TDIE_BIL_PROJE_IHTARNAMEProvider.DeepSave(tran, iht);
                }
                tran.Commit();
                this.DialogResult = DialogResult.OK;
                if (this.Kaydedildi != null)
                    Kaydedildi(this, null);
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();

                XtraMessageBox.Show("Kayýt esnasýnda bir hata oluþtu. Alacak kayýt edilemedi.", "Kayýt Hatasý",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                BelgeUtil.ErrorHandler.Catch(this, ex, BelgeUtil.Bilesen.Kayit, BelgeUtil.Bilesen.Icra);
            }
        }

        private void frmAlacakGirisi_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.AlacakNedenKodGetir(rlueAlacakNedeni);
            BelgeUtil.Inits.DovizTipGetir(rlueDovizID);

            if (Klasordenmi)
            {
                tabOnPanel.PageVisible = !Klasordenmi;
                tabKiymetliEvrak.PageVisible = !Klasordenmi;
            }
        }

        private void IhtarnameBilgileriHazirla()
        {
            if (ucAlacakNedenGirisi1.DtAlacakNeden.Count > 0)
            {
                ucTebligatKayitUfakDock1.Ihtarname = true;

                //ucAlacakNedenGirisi1.DtAlacakNeden[0].AV001_TDI_BIL_TEBLIGATCollection_From_NN_TEBLIGAT_ALACAK_NEDEN.AddingNew += new AddingNewEventHandler(AV001_TDI_BIL_TEBLIGATCollection_From_NN_TEBLIGAT_ALACAK_NEDEN_AddingNew);
                TList<AV001_TDI_BIL_TEBLIGAT> tbList = new TList<AV001_TDI_BIL_TEBLIGAT>();
                tbList =
                    ucAlacakNedenGirisi1.DtAlacakNeden[0].AV001_TDI_BIL_TEBLIGATCollection_From_NN_TEBLIGAT_ALACAK_NEDEN;
                tbList.AddingNew += AV001_TDI_BIL_TEBLIGATCollection_From_NN_TEBLIGAT_ALACAK_NEDEN_AddingNew;
                ucTebligatKayitUfakDock1.MyDataSource = tbList;
                ucTebligatKayitUfakDock1.tebligatKaydedildi += ucTebligatKayitUfakDock1_tebligatKaydedildi;
            }
            else
            {
                // XtraMessageBox.Show("Dosyada Taraf Yok Taraf olmadan Ýhtarname Giremezsiniz...");
            }
        }

        /// <summary>
        /// Alacak nedeni datasource larýný ayalarmak için kullanýlan method
        /// </summary>
        private void InitializeAlacakNeden()
        {
            this.Enabled = false;

            if (alacakNedenlerim.Count > 0)
            {
                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(alacakNedenlerim[0], false,
                                                                          DeepLoadType.IncludeChildren,
                                                                          typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>
                                                                              ),
                                                                          typeof(
                                                                              TList
                                                                              <AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>));
                alacakNedenlerim[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.AddingNew +=
                    AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection_AddingNew;
                ucAlacakNedenTaraf1.FocusedTarafChanged += ucAlacakNedenTaraf1_FocusedTarafChanged;
                ucAlacakNedenTaraf1.DtAlacakNeden = alacakNedenlerim[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection;
                ucAlacakNedenTaraf_Faiz1.DtAlacakNeden =
                    alacakNedenlerim[0].AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection;
            }
            else
                alacakNedenlerim = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

            alacakNedenlerim.AddingNew += alacakNedenlerim_AddingNew;

            #region <YY-20090627>

            //Alacaklarýn þekillerinin uygulandýðý yer
            switch (MyAlacakSekli)
            {
                case AlacakSekli.Nakit:
                    {
                        AV001_TI_BIL_ALACAK_NEDEN ndn = alacakNedenlerim.AddNew();
                        ndn.IsSelected = true;
                    }
                    break;

                case AlacakSekli.GayriNakit_Akreditif:
                    {
                        AV001_TI_BIL_ALACAK_NEDEN ndn = alacakNedenlerim.AddNew();
                        ndn.IsSelected = true;
                        ndn.ALACAK_NEDEN_KOD_ID = alacakNedenKodIdGetir("VADELÝ AKREDÝTÝF");
                    }
                    break;

                case AlacakSekli.GayriNakit_Aval:
                    {
                        AV001_TI_BIL_ALACAK_NEDEN ndn = alacakNedenlerim.AddNew();
                        ndn.IsSelected = true;
                        ndn.ALACAK_NEDEN_KOD_ID = alacakNedenKodIdGetir("AVAL");
                    }
                    break;

                case AlacakSekli.GayriNakit_CekTaahhut:
                    {
                        AV001_TI_BIL_ALACAK_NEDEN ndn = alacakNedenlerim.AddNew();
                        ndn.IsSelected = true;
                        ndn.ALACAK_NEDEN_KOD_ID = alacakNedenKodIdGetir("ÇEK YAPRAÐI");
                    }
                    break;

                case AlacakSekli.GayriNakit_Diger:
                    {
                        AV001_TI_BIL_ALACAK_NEDEN ndn = alacakNedenlerim.AddNew();
                        ndn.IsSelected = true;
                        ndn.ALACAK_NEDEN_KOD_ID = alacakNedenKodIdGetir("DÝÐER DEPO");
                    }
                    break;

                case AlacakSekli.GayriNakit_Mektup:
                    {
                        AV001_TI_BIL_ALACAK_NEDEN ndn = alacakNedenlerim.AddNew();
                        ndn.IsSelected = true;
                        ndn.ALACAK_NEDEN_KOD_ID = alacakNedenKodIdGetir("MER`Ý TEMÝNAT MEKTUBU");
                    }
                    break;

                case AlacakSekli.KiymetliEvrak_Bono:
                    {
                        AV001_TI_BIL_ALACAK_NEDEN ndn = alacakNedenlerim.AddNew();
                        ndn.IsSelected = false;
                        ndn.ALACAK_NEDEN_KOD_ID = alacakNedenKodIdGetir("SENET");
                    }
                    break;

                case AlacakSekli.KiymetliEvrak_Cek:
                    {
                        AV001_TI_BIL_ALACAK_NEDEN ndn = alacakNedenlerim.AddNew();
                        ndn.IsSelected = false;
                        ndn.ALACAK_NEDEN_KOD_ID = alacakNedenKodIdGetir("ÇEK");
                    }
                    break;

                case AlacakSekli.KiymetliEvrak_Police:
                    {
                        AV001_TI_BIL_ALACAK_NEDEN ndn = alacakNedenlerim.AddNew();
                        ndn.IsSelected = false;
                        ndn.ALACAK_NEDEN_KOD_ID = alacakNedenKodIdGetir("POLÝÇE");
                    }
                    break;

                default:
                    break;
            }
            ucAlacakNedenGirisi1.DtAlacakNeden = alacakNedenlerim;
            if (Ihtarname)
            {
                tcAlacakGirisi.SelectedTabPage = this.tabDigerBilgiler;
            }

            ucAlacakNedenGirisi1.vgAlacakNedenGirisi_FocusedRecordChanged(ucAlacakNedenGirisi1.vgAlacakNedenGirisi,
                                                                          new IndexChangedEventArgs(
                                                                              ucAlacakNedenGirisi1.vgAlacakNedenGirisi.
                                                                                  FocusedRecord, -1));

            //TList<AV001_TI_BIL_ALACAK_NEDEN> TumAlacakNedenler=new TList<AV001_TI_BIL_ALACAK_NEDEN>();
            //if (MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN.Count > 0)
            //    TumAlacakNedenler.AddRange(MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN);
            //if (MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI.Count > 0)
            //    TumAlacakNedenler.AddRange(MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI);

            #endregion <YY-20090627>

            IhtarnameBilgileriHazirla();

            this.Enabled = true;
        }

        /// <summary>
        /// AvpXtraForm ile ilgili olan Eventlarýn kayýt edildiði method
        /// </summary>
        private void InitializeEvents()
        {
            if (Klasordenmi)
                this.Button_Kaydet_Click += frmAlacakGirisi_Button_Kaydet_Click;
            this.tsBtn_Kaydet.Enabled = false;

            //ucAlacakNedenTaraf1.dataNavigatorExtended1.Validating += new CancelEventHandler(dataNavigatorExtended1_Validating);
        }

        private void keList_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_KIYMETLI_EVRAK kEvrak = new AV001_TDI_BIL_KIYMETLI_EVRAK();
            kEvrak.KAYIT_TARIHI = DateTime.Now;
            kEvrak.NE_SEKILDE_AHZOLUNDUGU = (int)KEvrakAhzolunmaSekli.Nakten;
            kEvrak.KONTROL_NE_ZAMAN = DateTime.Now;
            kEvrak.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            kEvrak.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            kEvrak.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            kEvrak.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            e.NewObject = kEvrak;
        }

        /// <summary>
        /// Alacak nedenini Validate eden method
        /// </summary>
        private void Neden_ValidateRecord(object sender, DevExpress.XtraVerticalGrid.Events.ValidateRecordEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN ndn = ucAlacakNedenGirisi1.CurrentNeden;
            if (ndn == null) return;

            #region Alacak neden giriþi kontrolü [Validating]

            string sStr = frmIcraDosyaKayit.AlacakNedenValidate(ndn);
            if (sStr != string.Empty)
            {
                e.ErrorText = sStr;
                e.Valid = false;
            }

            #endregion Alacak neden giriþi kontrolü [Validating]

            if (e.Valid)

            {
                #region AlacakNedenTaraf - Faiz

                if (ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count >= 0)
                {
                    if (ndn.ISLEME_KONAN_TUTAR > 0 && ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID.HasValue)
                    {
                        //Eðer projenin taraflarý henüz yüklenmediyse yükleyelim.
                        if (MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection.Count == 0)
                            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false,
                                                                                 DeepLoadType.IncludeChildren,
                                                                                 typeof(
                                                                                     TList<AV001_TDIE_BIL_PROJE_TARAF>));
                        icraGenelayarlar =
                            DataRepository.TI_BIL_ICRA_KULLANICI_AYARProvider.GetByKULLANICI_ID(
                                AvukatProLib.Kimlik.Bilgi.ID);
                        if (icraGenelayarlar.Count > 0)
                        {
                            AV001_TI_BIL_ALACAK_NEDEN_TARAF trf = new AV001_TI_BIL_ALACAK_NEDEN_TARAF();
                            trf.TARAF_CARI_ID = icraGenelayarlar[0].SECILI_MUVEKKIL_CARI_ID.Value;
                            if (icraGenelayarlar[0].SECILI_MUVEKKIL_CARI_ID > 0)
                            {
                                trf.TARAF_CARI_IDSource =
                                    DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(
                                        icraGenelayarlar[0].SECILI_MUVEKKIL_CARI_ID.Value);
                                if (trf.TARAF_CARI_IDSource != null)
                                    trf.TARAF_CARI_ADI = trf.TARAF_CARI_IDSource.AD;

                                trf.TARAF_SIFAT_ID = (int)TarafSifat.ALACAKLI;
                            }
                        }

                        if (MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection.Count > 0 &&
                            ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count == 0)
                        {
                            foreach (AV001_TDIE_BIL_PROJE_TARAF taraf in MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection)
                            {
                                AV001_TI_BIL_ALACAK_NEDEN_TARAF trf = new AV001_TI_BIL_ALACAK_NEDEN_TARAF();
                                foreach (string s in trf.TableColumns)
                                {
                                    if (s.EndsWith("DOVIZ_ID"))
                                        trf[s] = 1;
                                }
                                trf.TARAF_CARI_ID = taraf.CARI_ID;
                                if (taraf.CARI_ID > 0)
                                {
                                    trf.TARAF_CARI_IDSource =
                                        DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(taraf.CARI_ID);
                                    if (trf.TARAF_CARI_IDSource != null)
                                        trf.TARAF_CARI_ADI = trf.TARAF_CARI_IDSource.AD;
                                }
                                else
                                    trf.TARAF_CARI_ADI = "<Cari Seçilmemiþ>";

                                //Tarafýn müvekkil olmadýðýný kontrol ederek taraf sorumluluklarýný veriyoruz.

                                trf.TARAF_SIFAT_ID = (int)TarafSifat.ALACAKLI;
                                if (trf.TARAF_CARI_IDSource != null && !trf.TARAF_CARI_IDSource.MUVEKKIL_MI)
                                {
                                    trf.SORUMLU_OLUNAN_MIKTAR = ndn.ISLEME_KONAN_TUTAR;
                                    trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value;
                                    trf.PROTESTO_GIDERI = ndn.PROTESTO_GIDERI;
                                    trf.PROTESTO_GIDERI_DOVIZ_ID = ndn.PROTESTO_GIDERI_DOVIZ_ID.Value;
                                    trf.IHTAR_GIDERI = ndn.IHTAR_GIDERI;
                                    trf.IHTAR_GIDERI_DOVIZ_ID = ndn.IHTAR_GIDERI_DOVIZ_ID.Value;
                                    trf.TEMERRUT_TARIHI = ndn.IHTAR_TARIHI;
                                    trf.CEK_TAZMINATI_ORANI = ndn.CEK_TAZMINATI_ORANI;
                                    trf.KOMISYONU_ORANI = ndn.KOMISYONU_ORANI;
                                    trf.IHTAR_TARIHI = ndn.IHTAR_TARIHI;
                                    trf.TARAF_SIFAT_ID = (int)TarafSifat.BORCLU;
                                }
                                trf.KAYIT_TARIHI = DateTime.Now;
                                trf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                                trf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                                trf.KONTROL_NE_ZAMAN = DateTime.Now;
                                trf.STAMP = AvukatProLib.Kimlik.DefaultStamp;

                                ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Add(trf);
                            }
                        }
                    }

                    if ((ndn.TO_ALACAK_FAIZ_TIP_ID.HasValue ||
                         (ndn.SABIT_FAIZ_UYGULA && ndn.TO_UYGULANACAK_FAIZ_ORANI > 0)) &&
                        ndn.FAIZ_BASLANGIC_TARIHI.HasValue)
                    {
                        foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF trf in ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                        {
                            trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Clear();
                            if (trf.TARAF_CARI_IDSource == null)
                                trf.TARAF_CARI_IDSource =
                                    DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(trf.TARAF_CARI_ID);

                            //Tarafýn müvekkil olmadýðýný kontrol ederek taraf faizlerini oluþturuyoruz.
                            if (trf.TARAF_CARI_IDSource != null && !trf.TARAF_CARI_IDSource.MUVEKKIL_MI)
                            {
                                AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ faiz = new AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ();
                                faiz.FAIZ_BASLANGIC_TARIHI = ndn.FAIZ_BASLANGIC_TARIHI.Value;

                                //faiz.FAIZ_BITIS_TARIHI = myFoy.TAKIP_TARIHI;
                                faiz.FAIZ_TIP_ID = ndn.TO_ALACAK_FAIZ_TIP_ID;
                                faiz.FAIZ_ORANI = ndn.TO_UYGULANACAK_FAIZ_ORANI;
                                faiz.SABIT_FAIZ = ndn.SABIT_FAIZ_UYGULA;
                                faiz.KAYIT_TARIHI = DateTime.Now;
                                faiz.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                                faiz.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                                faiz.KONTROL_NE_ZAMAN = DateTime.Now;
                                faiz.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                                faiz.TARAF_CARI_ID = trf.TARAF_CARI_ID;

                                if ((ndn.ALACAK_FAIZ_TIP_ID.HasValue ||
                                     (ndn.SABIT_FAIZ_UYGULA && ndn.UYGULANACAK_FAIZ_ORANI > 0)))
                                {
                                    trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Add(faiz);
                                }

                                trf.SORUMLU_OLUNAN_MIKTAR = ndn.ISLEME_KONAN_TUTAR;
                                trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID ?? 1;
                                trf.TEMERRUT_TARIHI = ndn.IHTAR_TARIHI;
                            }
                        }
                    }
                }

                #endregion AlacakNedenTaraf - Faiz

                #region Alacak nedeninden kiymetli evrak[ÇEK_SENET_POLÝÇE]ve taraflarý olusturma iþlemleri

                if (ndn.ALACAK_NEDEN_KOD_IDSource == null && !ndn.IsNew)
                {
                    AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(ndn, true,
                                                                                                 DeepLoadType.
                                                                                                     IncludeChildren,
                                                                                                 typeof(
                                                                                                     TI_KOD_ALACAK_NEDEN
                                                                                                     ));
                }
                else if (ndn.ALACAK_NEDEN_KOD_IDSource == null && ndn.IsNew)
                {
                    ndn.ALACAK_NEDEN_KOD_IDSource = AvukatProLib2.Data.DataRepository.TI_KOD_ALACAK_NEDENProvider.
                        GetByID(
                            ndn.ALACAK_NEDEN_KOD_ID.Value);
                }

                KiymetliEvrakTarafTip kTarafTipBorclu = new KiymetliEvrakTarafTip();
                KiymetliEvrakTarafTip kTarafTipAlacakli = new KiymetliEvrakTarafTip();
                TDI_KOD_KIYMETLI_EVRAK_TUR keTur = null;
                TList<AV001_TDI_BIL_KIYMETLI_EVRAK> keList = null;
                TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF> keTarafList = null;
                if (ndn.ALACAK_NEDEN_KOD_IDSource != null)
                {
                    switch (ndn.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI)
                    {
                        case "ÇEK":
                            keTur = AvukatProLib2.Data.DataRepository.TDI_KOD_KIYMETLI_EVRAK_TURProvider.GetByTUR(
                                ndn.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI);

                            kTarafTipBorclu = KiymetliEvrakTarafTip.Kesideci_Borclu;
                            kTarafTipAlacakli = KiymetliEvrakTarafTip.Alacakli;
                            break;

                        case "SENET":
                            keTur = AvukatProLib2.Data.DataRepository.TDI_KOD_KIYMETLI_EVRAK_TURProvider.GetByTUR(
                                ndn.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI);

                            kTarafTipBorclu = KiymetliEvrakTarafTip.Borclu;
                            kTarafTipAlacakli = KiymetliEvrakTarafTip.Alacakli;
                            break;

                        case "POLÝÇE":
                            keTur = AvukatProLib2.Data.DataRepository.TDI_KOD_KIYMETLI_EVRAK_TURProvider.GetByTUR(
                                ndn.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI);

                            kTarafTipAlacakli = KiymetliEvrakTarafTip.Lehtar;
                            kTarafTipBorclu = KiymetliEvrakTarafTip.Kesideci_Borclu;
                            break;

                        default:
                            break;
                    }
                }
                if (keTur != null)
                {
                    keList = ndn.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK;
                    keList.AddingNew += keList_AddingNew;
                    AV001_TDI_BIL_KIYMETLI_EVRAK kEvrak = null;
                    if (keList.Count > 0)
                        kEvrak = keList[0];
                    else
                        kEvrak = keList.AddNew();

                    kEvrak.EVRAK_TUR_ID = keTur.ID;
                    kEvrak.EVRAK_KAYIT_TARIHI = DateTime.Today;
                    kEvrak.EVRAK_TUR_IDSource = keTur;
                    kEvrak.EVRAK_VADE_TARIHI = ndn.VADE_TARIHI;
                    kEvrak.EVRAK_TANZIM_TARIHI = ndn.DUZENLENME_TARIHI;
                    kEvrak.TUTAR = ndn.TUTARI;
                    kEvrak.TUTAR_DOVIZ_ID = ndn.TUTAR_DOVIZ_ID;
                    kEvrak.TUTAR_DOVIZ_IDSource = ndn.TUTAR_DOVIZ_IDSource;
                    keTarafList = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>();
                    keTarafList.AddingNew += AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection_AddingNew;

                    for (int i = 0; i < MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection.Count; i++)
                    {
                        AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF keTaraf = keTarafList.AddNew();
                        AV001_TDIE_BIL_PROJE_TARAF pTrf = MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection[i];
                        if (pTrf.CARI_IDSource == null)
                            DataRepository.AV001_TDIE_BIL_PROJE_TARAFProvider.DeepLoad(pTrf, false,
                                                                                       DeepLoadType.IncludeChildren,
                                                                                       typeof(AV001_TDI_BIL_CARI));

                        keTaraf.TARAF_CARI_ID = pTrf.CARI_ID;

                        if (pTrf.CARI_IDSource.MUVEKKIL_MI)
                            keTaraf.TARAF_TIP_ID = (int)kTarafTipAlacakli;
                        else
                            keTaraf.TARAF_TIP_ID = (int)kTarafTipBorclu;

                        keTaraf.TAKIBE_KONULDU_MU = true;
                    }

                    kEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection.Clear();
                    kEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection.AddRange(keTarafList);
                }

                ucKiymetliEvrak1.MyDataSource = keList;
                ucKiymetliEvrak1.RefreshDataSource();

                ucKiymetliEvrakTaraf1.MyDataSource = keTarafList;

                ucAlacakNedenGirisi1.RefreshDataSource();
                alacneden.Add(ndn);

                //if (ndn.IsNew && !myFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Contains(ndn))
                //    myFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Add(ndn);
                //// trfList.AddRange(myFoy.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection);

                #endregion Alacak nedeninden kiymetli evrak[ÇEK_SENET_POLÝÇE]ve taraflarý olusturma iþlemleri
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (ucTebligatKayitUfakDock1.MyDataSource.Count == 0)
            {
                XtraMessageBox.Show("Kayýrlý ;Ýhtarnameniz Bulunmamaktadýr");
            }
            if (ucTebligatKayitUfakDock1.MyDataSource[0].ID == 0)
            {
                XtraMessageBox.Show("Lütfen Önce Ihtarnameyi Kaydediniz");
                return;
            }
            TList<AV001_TI_BIL_ALACAK_NEDEN> neden = alacneden;
            neden = neden.FindAll("IsSelected", true);
            foreach (var ndn in neden)
            {
                foreach (AV001_TDI_BIL_TEBLIGAT teblig in ucTebligatKayitUfakDock1.MyDataSource)
                {
                    if (teblig.MUHASEBE_ALT_KATEGORI_IDSource == null)
                    {
                        TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> Hak =
                            DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                teblig.ANA_TUR_ID);
                        foreach (TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI mhak in Hak)
                        {
                            teblig.MUHASEBE_ALT_KATEGORI_IDSource = mhak;
                        }
                    }
                    if (teblig.MUHASEBE_ALT_KATEGORI_ID == 0 && teblig.MUHASEBE_ALT_KATEGORI_IDSource != null)
                    {
                        TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI mhak = teblig.MUHASEBE_ALT_KATEGORI_IDSource;
                        teblig.MUHASEBE_ALT_KATEGORI_ID = mhak.ID;
                    }

                    ndn.AV001_TDI_BIL_MASRAF_AVANSCollection.Add(avans);

                    if (teblig.KONU_ID == 481)
                    {
                        TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                        try
                        {
                            tran.BeginTransaction();
                            DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.Save(tran, ndn);

                            if (
                                ndn.NN_TEBLIGAT_ALACAK_NEDENCollection.Exists(
                                    delegate(NN_TEBLIGAT_ALACAK_NEDEN ihtarname) { return ihtarname.TEBLIGAT_ID == teblig.ID; })) continue;
                            NN_TEBLIGAT_ALACAK_NEDEN teb = new NN_TEBLIGAT_ALACAK_NEDEN();
                            teb.ALACAK_NEDEN_ID = ndn.ID;
                            teb.TEBLIGAT_ID = teblig.ID;
                            DataRepository.NN_TEBLIGAT_ALACAK_NEDENProvider.Save(teb);

                            //if (MyProje.AV001_TDIE_BIL_PROJE_IHTARNAMECollection.Exists(delegate(AV001_TDIE_BIL_PROJE_IHTARNAME ihtarname)
                            //{
                            //    return ihtarname.TEBLIGAT_ID == teblig.ID;
                            //})) continue;
                            //AV001_TDIE_BIL_PROJE_IHTARNAME iht = new AV001_TDIE_BIL_PROJE_IHTARNAME();
                            //iht.TEBLIGAT_ID = teblig.ID;
                            //iht.PROJE_ID = MyProje.ID;
                            //DataRepository.AV001_TDIE_BIL_PROJE_IHTARNAMEProvider.Save(tran, iht);
                            tran.Commit();
                            XtraMessageBox.Show("Seçili Alacak Nedenine Ýhtarname Baðlanmýþtýr");
                        }
                        catch 
                        {
                        }
                    }
                }
            }
        }

        private void tcAlacakGirisi_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (tcAlacakGirisi.SelectedTabPage.Text == tabOnPanel.Text)
                this.tsBtn_Kaydet.Enabled = false;
            else
                this.tsBtn_Kaydet.Enabled = true;
        }

        /// <summary>
        /// Form üzerindeki seçili alacak nedeni deðiþtiðinde çalýþan method.
        /// </summary>
        private void ucAlacakNedenGirisi1_FocusedNedenChanged(object sender,
                                                              DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (ucAlacakNedenGirisi1.CurrentNeden != null)
            {
                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(ucAlacakNedenGirisi1.CurrentNeden, false,
                                                                          DeepLoadType.IncludeChildren,
                                                                          typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>
                                                                              ), typeof(TList<AV001_TDI_BIL_TEBLIGAT>),
                                                                          typeof(TList<NN_TEBLIGAT_ALACAK_NEDEN>),
                                                                          typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>),
                                                                          typeof(
                                                                              TList
                                                                              <AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK>
                                                                              ));
                ucAlacakNedenGirisi1.CurrentNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.AddingNew +=
                    AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection_AddingNew;
                ucAlacakNedenTaraf1.DtAlacakNeden =
                    ucAlacakNedenGirisi1.CurrentNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection;
                ucTebligatKayitUfakDock1.MyDataSource =
                    ucAlacakNedenGirisi1.CurrentNeden.AV001_TDI_BIL_TEBLIGATCollection_From_NN_TEBLIGAT_ALACAK_NEDEN;
                ucKiymetliEvrak1.MyDataSource =
                    ucAlacakNedenGirisi1.CurrentNeden.
                        AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK;
                DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(
                    ucAlacakNedenGirisi1.CurrentNeden.
                        AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK, false,
                    DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>));
                if (
                    ucAlacakNedenGirisi1.CurrentNeden.
                        AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK.Count > 0)
                {
                    ucKiymetliEvrakTaraf1.MyDataSource =
                        ucAlacakNedenGirisi1.CurrentNeden.
                            AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK[0].
                            AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection;
                }
            }
            if (ucAlacakNedenTaraf1.CurrentNedenTaraf != null)
                ucAlacakNedenTaraf_Faiz1.DtAlacakNeden =
                    ucAlacakNedenTaraf1.CurrentNedenTaraf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection;
        }

        /// <summary>
        /// Form üzerinde seçili alacakneden taraf deðiþtiðinde çalýþan method
        /// </summary>
        private void ucAlacakNedenTaraf1_FocusedTarafChanged(object sender,
                                                             DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (ucAlacakNedenTaraf1.CurrentNedenTaraf != null)
            {
                if (ucAlacakNedenTaraf1.CurrentNedenTaraf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepLoad(
                        ucAlacakNedenTaraf1.CurrentNedenTaraf, false, DeepLoadType.IncludeChildren,
                        typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>));
                ucAlacakNedenTaraf_Faiz1.DtAlacakNeden =
                    ucAlacakNedenTaraf1.CurrentNedenTaraf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection;
            }
        }

        private void ucKiymetliEvrak1_FocusedRecordChanged(object sender, IndexChangedEventArgs e)
        {
            if (ucKiymetliEvrak1.MyDataSource != null)
            {
                //CurrentEvrak diye birþey olsun tarafýda onu verelim güzel olsun
                if (e.NewIndex > -1 && ucKiymetliEvrak1.MyDataSource.Count > 0)
                    ucKiymetliEvrakTaraf1.MyDataSource =
                        ucKiymetliEvrak1.MyDataSource[e.NewIndex].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection;
            }
        }

        private void ucTebligatKayitUfakDock1_tebligatKaydedildi(object sender, TebligatKaydedildiEventArgs e)
        {
            if (e.Tebligat != null)
            {
                AV001_TDI_BIL_TEBLIGAT ihtarname = e.Tebligat;
                ucAlacakNedenGirisi1.DtAlacakNeden[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Clear();
                ucAlacakNedenGirisi1.DtAlacakNeden[0].IHTAR_TARIHI = ihtarname.HAZIRLAMA_TARIH;
                ucAlacakNedenGirisi1.DtAlacakNeden[0].DUZENLENME_TARIHI = ihtarname.HAZIRLAMA_TARIH;
                ucAlacakNedenGirisi1.DtAlacakNeden[0].VADE_TARIHI = ihtarname.HAZIRLAMA_TARIH;
                foreach (var item in ihtarname.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection)
                {
                    AV001_TI_BIL_ALACAK_NEDEN_TARAF muv = new AV001_TI_BIL_ALACAK_NEDEN_TARAF();
                    muv.TARAF_CARI_ID = item.MUHATAP_CARI_ID;
                    muv.TARAF_SIFAT_ID = (int)TarafSifat.BORCLU;
                    muv.IHTAR_TARIHI = ihtarname.HAZIRLAMA_TARIH;
                    muv.IHTAR_TEBLIG_TARIHI = item.TEBLIG_TARIH;
                    muv.TEMERRUT_TARIHI = ihtarname.HAZIRLAMA_TARIH;

                    if (avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Count > 0)
                    {
                        List<ParaVeDovizId> list = new List<ParaVeDovizId>();
                        ParaVeDovizId par = new ParaVeDovizId();
                        foreach (
                            AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                        {
                            par.Para = detay.ADET * detay.TOPLAM_TUTAR;
                            par.DovizId = detay.TOPLAM_TUTAR_DOVIZ_ID;
                            list.Add(par);
                        }
                        ParaVeDovizId toplam = ParaVeDovizId.Topla(list);
                        muv.IHTAR_GIDERI = toplam.Para;
                        muv.IHTAR_GIDERI_DOVIZ_ID = toplam.DovizId;
                    }
                    ucAlacakNedenGirisi1.DtAlacakNeden[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Add(muv);
                }
                foreach (var item in ihtarname.AV001_TDI_BIL_TEBLIGAT_YAPANCollection)
                {
                    AV001_TI_BIL_ALACAK_NEDEN_TARAF borc = new AV001_TI_BIL_ALACAK_NEDEN_TARAF();
                    borc.TARAF_CARI_ID = item.YAPAN_CARI_ID;
                    borc.TARAF_SIFAT_ID = (int)TarafSifat.ALACAKLI;
                    borc.IHTAR_TARIHI = ihtarname.HAZIRLAMA_TARIH;
                    if (avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Count > 0)
                    {
                        List<ParaVeDovizId> list = new List<ParaVeDovizId>();
                        ParaVeDovizId par = new ParaVeDovizId();
                        foreach (
                            AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                        {
                            par.Para = detay.ADET * detay.TOPLAM_TUTAR;
                            par.DovizId = detay.TOPLAM_TUTAR_DOVIZ_ID;
                            list.Add(par);
                        }
                        ParaVeDovizId toplam = ParaVeDovizId.Topla(list);
                        borc.IHTAR_GIDERI = toplam.Para;
                        borc.IHTAR_GIDERI_DOVIZ_ID = toplam.DovizId;
                    }
                    ucAlacakNedenGirisi1.DtAlacakNeden[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Add(borc);
                }
            }
        }
    }
}