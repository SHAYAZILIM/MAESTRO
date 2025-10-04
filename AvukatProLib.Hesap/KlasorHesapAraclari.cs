using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvukatProLib.Hesap
{
    public class KlasorHesapAraclari
    {
        #region 1. Yapı

        public AvukatProLib.Hesap.HesapAraclari.OzetHesap GetKonsolideAlacaklarHesabi(AV001_TDIE_BIL_PROJE proje)
        {
            try
            {
                HesapYapar hsp = new HesapYapar();
                List<AV001_TI_BIL_FOY> foyler = new List<AV001_TI_BIL_FOY>();
                AV001_TDIE_BIL_PROJE aktif = proje;
                AV001_TI_BIL_FOY alacakNedenFoyu = new AV001_TI_BIL_FOY();

                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(aktif, false, DeepLoadType.IncludeChildren,
                    typeof(TList<AV001_TI_BIL_FOY>),
                    typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>),
                    typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>),
                    typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>));

                foreach (AV001_TI_BIL_FOY foy in aktif.AV001_TI_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY)
                {
                    if (AnaDosyami(foy))
                    {
                        foyler.Add(hsp.IcraFoyHesaplaByID(foy.ID));
                    }
                    else
                    {
                        AltDosyaDegerleriEkle(alacakNedenFoyu, foy);
                    }
                }
                alacakNedenFoyu.TAKIP_TARIHI = DateTime.Today;
                alacakNedenFoyu.SON_HESAP_TARIHI = DateTime.Today;
                alacakNedenFoyu.TAKIP_TALEP_ID = 1;
                alacakNedenFoyu.FORM_TIP_ID = 1;

                foreach (AV001_TI_BIL_ALACAK_NEDEN aNeden in aktif.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN)
                {
                    if (aNeden.ICRA_FOY_ID.HasValue) continue;

                    alacakNedenFoyu.AV001_TI_BIL_ALACAK_NEDENCollection.Add(aNeden);
                    foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF trf in aNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                    {
                        if (alacakNedenFoyu.AV001_TI_BIL_FOY_TARAFCollection.Find(AV001_TI_BIL_FOY_TARAFColumn.CARI_ID, trf.TARAF_CARI_ID) == null)
                        {
                            AV001_TI_BIL_FOY_TARAF fTrf = alacakNedenFoyu.AV001_TI_BIL_FOY_TARAFCollection.AddNew();
                            fTrf.CARI_ID = trf.TARAF_CARI_ID;
                            fTrf.TARAF_SIFAT_ID = trf.TARAF_SIFAT_ID ?? (int)AvukatProLib.Extras.TarafSifat.BORCLU; //ToDo : Burası düzenlenecek
                            if (trf.TARAF_SIFAT_IDSource != null)
                            {
                                fTrf.TAKIP_EDEN_MI = trf.TARAF_SIFAT_IDSource.HANGI_TARAFI == "TAKİP EDEN";
                            }
                            else if (trf.TARAF_SIFAT_ID.HasValue)
                            {
                                trf.TARAF_SIFAT_IDSource = DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID(trf.TARAF_SIFAT_ID ?? 0);
                                if (trf.TARAF_SIFAT_IDSource != null)
                                    fTrf.TAKIP_EDEN_MI = trf.TARAF_SIFAT_IDSource.HANGI_TARAFI == "TAKİP EDEN";
                            }
                        }
                    }
                }

                hsp.IcraFoyHesapla(alacakNedenFoyu);
                SanalFoyAlanlariniTemizle(alacakNedenFoyu);
                foyler.Add(alacakNedenFoyu);

                var sonuc = hsp.TumFoyTopla(foyler, DateTime.Today);

                return new HesapAraclari.OzetHesap(sonuc);
            }
            catch
            {
                throw;
                //BelgeUtil.ErrorHandler.Catch(this, ex, BelgeUtil.Bilesen.Hesap);
            }
        }

        public AvukatProLib.Hesap.HesapAraclari.OzetHesap GetTakipliAlacaklarHesabi(AV001_TDIE_BIL_PROJE proje)
        {
            TList<AV001_TI_BIL_FOY> foyListesi = new TList<AV001_TI_BIL_FOY>();
            AV001_TI_BIL_FOY araFoy = new AV001_TI_BIL_FOY();

            if (proje.AV001_TI_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY.Count > 0)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY>));

            foreach (var teki in proje.AV001_TI_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY)
            {
                if (AnaDosyami(teki))
                {
                    Hesap.Icra hey = new Hesap.Icra(teki);
                    foyListesi.Add(teki);
                }
                else
                {
                    AltDosyaDegerleriEkle(araFoy, teki);
                }

                TList<AV001_TI_BIL_FOY> altDosyalar = HesapAraclari.Icra.GetIliskiliAltIcraDosyalariByFoyId(teki.ID);

                foreach (var alt in altDosyalar)
                {
                    AltDosyaDegerleriEkle(araFoy, alt);
                }
            }

            HesapYapar hy = new HesapYapar();

            foyListesi.Add(araFoy);
            var toplamFoyu = hy.TumFoyTopla(foyListesi, DateTime.Now);

            return new HesapAraclari.OzetHesap(toplamFoyu);
        }

        public AvukatProLib.Hesap.HesapAraclari.OzetHesap GetTakipsizAlacaklarHesabi(AV001_TDIE_BIL_PROJE proje)
        {
            AV001_TI_BIL_FOY foy = new AV001_TI_BIL_FOY();

            #region Föyün üzerine değerler yerleştiriliyor

            if (proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN.Count == 0)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));

            foreach (var item in proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN)
            {
                if (KlasorHesapAraclari.GetAlacakNedenByEuId(item.EU_ID).Count == 0)//!item.ICRA_FOY_ID.HasValue)// &&  KlasorHesapAraclari.GetAlacakNedenByEuId(item.EU_ID).Count == 0)
                    foy.AV001_TI_BIL_ALACAK_NEDENCollection.Add(item);
            }

            if (proje.AV001_TI_BIL_BORCLU_ODEMECollection_From_AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEME.Count == 0)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_ODEME>));

            foreach (var item in proje.AV001_TI_BIL_BORCLU_ODEMECollection_From_AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEME)
            {
                if (!item.ICRA_FOY_ID.HasValue)
                    foy.AV001_TI_BIL_BORCLU_ODEMECollection.Add(item);
            }

            if (proje.AV001_TDI_BIL_MASRAF_AVANSCollection_From_AV001_TDIE_BIL_PROJE_MASRAF_AVANS.Count == 0)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));

            foreach (var item in proje.AV001_TDI_BIL_MASRAF_AVANSCollection_From_AV001_TDIE_BIL_PROJE_MASRAF_AVANS)
            {
                if (!item.ICRA_FOY_ID.HasValue && item.MASRAF_AVANS_TIP != (int)MasrafAvansTip.Avans)
                {
                    foy.AV001_TDI_BIL_MASRAF_AVANSCollection.Add(item);
                }
            }

            foy.SON_HESAP_TARIHI = DateTime.Now;
            foy.TAKIP_TARIHI = DateTime.Now;
            foy.TAKIP_TALEP_ID = 1;
            foy.FORM_TIP_ID = 1;

            #endregion Föyün üzerine değerler yerleştiriliyor

            Hesap.Icra hy = new Hesap.Icra(foy);

            foy.BAKIYE_HARC_TOPLAMA_EKLE = false;
            foy.BASVURMA_HARCI = 0;
            foy.BIRIKMIS_NAFAKA = 0;
            foy.DAVA_GIDERLERI = 0;
            foy.DAVA_INKAR_TAZMINATI = 0;
            foy.DAVA_VEKALET_UCRETI = 0;
            foy.DEPO_HARCI = 0;
            foy.DEPO_VEKALET_UCRETI = 0;
            foy.DIGER_HARC = 0;
            foy.FERAGAT_HARCI = 0;
            foy.FERAGAT_TOPLAMI = 0;
            foy.HARC_TOPLAMI = 0;
            foy.ILK_GIDERLER = 0;
            foy.ILK_TEBLIGAT_GIDERI = 0;
            foy.KALAN_TAHSIL_HARCI = 0;
            foy.KARSI_VEKALET_TOPLAMI = 0;
            foy.PAYLASMA_HARCI = 0;
            foy.TAHLIYE_HARCI = 0;
            foy.TD_BAKIYE_HARC = 0;
            foy.TESLIM_HARCI = 0;
            foy.TS_MASRAF_HARC_TOPLAMI = 0;
            foy.VEKALET_HARCI = 0;
            foy.VEKALET_PULU = 0;
            foy.VEKALET_UCRETINDEN_ODENEN = 0;
            foy.PESIN_HARC = 0;
            foy.TS_VEKALET_TOPLAMI = 0;

            AvukatProLib.Hesap.HesapAraclari.OzetHesap oh = new HesapAraclari.OzetHesap(foy);

            return oh;
        }

        #endregion 1. Yapı

        #region 2. Yapı

        public Hesap.Icra HesapAraci { get; set; }

        public HesapAraclari.OzetHesap GetKonsolideAlacaklarHesabi2G(AV001_TDIE_BIL_PROJE proje)
        {
            return GetKonsolideAlacaklarHesabi2G(proje, true);
        }

        public HesapAraclari.OzetHesap GetKonsolideAlacaklarHesabi2G(AV001_TDIE_BIL_PROJE proje, bool kaydet)
        {
            if (proje.AV001_TDIE_BIL_PROJE_HESAPCollection.Count == 0)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_HESAP>));

            AV001_TI_BIL_FOY sanalFoy = new AV001_TI_BIL_FOY();
            if (proje.AV001_TDIE_BIL_PROJE_HESAPCollection.Count > 0) sanalFoy.HESAPLAMA_TIPI = Convert.ToByte(proje.AV001_TDIE_BIL_PROJE_HESAPCollection[0].HESAPLAMA_TIPI);
            sanalFoy.BAKIYE_HARC_TOPLAMA_EKLE = false;//Klasörde True olması gerekiyormuş. MB // Tekrardan false yaptırıldı. MB

            ProjeDegerleriniEkle(sanalFoy, proje);

            #region Bağlı icra dosyalarının değerleri ekleniyor

            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY>));

            foreach (var foy in proje.AV001_TI_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY)
            {
                AltDosyaDegerleriEkle(sanalFoy, foy);
            }

            #endregion Bağlı icra dosyalarının değerleri ekleniyor

            #region Bağlı dava dosyalarının değerleri ekleniyor

            if (proje.AV001_TD_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_DAVA_FOY.Count == 0)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY>));

            foreach (var davaFoy in proje.AV001_TD_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_DAVA_FOY)
            {
                AltDosyaDegerleriEkle(sanalFoy, davaFoy);
            }

            #endregion Bağlı dava dosyalarının değerleri ekleniyor

            #region Bağlı soruşturma dosyalarının değerleri

            if (proje.AV001_TD_BIL_HAZIRLIKCollection_From_AV001_TDIE_BIL_PROJE_HAZIRLIK.Count == 0)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_HAZIRLIK>));

            foreach (var sorusturma in proje.AV001_TD_BIL_HAZIRLIKCollection_From_AV001_TDIE_BIL_PROJE_HAZIRLIK)
            {
                AltDosyaDegerleriEkle(sanalFoy, sorusturma);
            }

            #endregion Bağlı soruşturma dosyalarının değerleri

            ChildFoyAlacakNedenTaraflariniEkle(proje, sanalFoy);

            sanalFoy.AV001_TI_BIL_ALACAK_NEDENCollection.ApplyFilter(vi =>
                    (vi.AN_URETIP_TIP != (byte)AvukatProLib.Extras.AN_URETIP_TIP.MunzamSenet &&
                    vi.AN_URETIP_TIP != (byte)AvukatProLib.Extras.AN_URETIP_TIP.SenetleTakibeKonuldu)
                );

            sanalFoy.AV001_TI_BIL_ALACAK_NEDENCollection.ForEach(vi => AlacakIslemeKonanTutarAyarla(vi));

            ////Bankada internet bağlantısı olmadığından kur bilgilerini tablodan alıyor. tabloda işlem yapılan tarih yoksa giriş yapılması sağlamak ve yanlış hesap yapılmasını önlemek için bu şekilde yapıldı. Yukarıdaki "sanalFoy.AV001_TI_BIL_ALACAK_NEDENCollection.ForEach" aşağıdaki hale getirili MB
            //bool cikildi = false;
            //foreach (var item in sanalFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            //{
            //    bool durum = AlacakIslemeKonanTutarAyarla(item);

            //    if (!durum) { cikildi = true; break; }
            //}
            //if (cikildi) return new HesapAraclari.OzetHesap();

            //HesapYapar hy = new HesapYapar();

            //hy.IcraFoyHesapla(sanalFoy);

            HesapAraci = new Hesap.Icra(sanalFoy, kaydet);

            TarafTutarlariniTopla(sanalFoy, proje);

            #region Diğer Alanlar toplanıyor

            ParaVeDovizId paraVEKALET_PULU = new ParaVeDovizId();
            ParaVeDovizId paraVEKALET_HARCI = new ParaVeDovizId();
            //ParaVeDovizId paraIH_GIDERI_DOVIZ_ID = new ParaVeDovizId();
            ParaVeDovizId paraTS_VEKALET_TOPLAMI = new ParaVeDovizId();
            //ParaVeDovizId paraCEK_KOMISYONU = new ParaVeDovizId();
            //ParaVeDovizId paraKARSILIKSIZ_CEK_TAZMINATI = new ParaVeDovizId();

            //ParaVeDovizId para = new ParaVeDovizId();

            foreach (var item in proje.AV001_TI_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY)
            {
                //paraKARSILIKSIZ_CEK_TAZMINATI = ParaVeDovizId.Topla(paraKARSILIKSIZ_CEK_TAZMINATI, new ParaVeDovizId(item.KARSILIKSIZ_CEK_TAZMINATI, item.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID));
                //paraCEK_KOMISYONU = ParaVeDovizId.Topla(paraCEK_KOMISYONU, new ParaVeDovizId(item.CEK_KOMISYONU, item.CEK_KOMISYONU_DOVIZ_ID));

                //12.01.2014 poaş isteğiyle kaldırıldı.
                //Aşağıdaki if koşulu sadece Kredi borçlusunun taraf olduğu dosyalarda vekalet ücretinin klasör hesabına gelmesini sağlamak için eklendi. MB
                //if (item.AV001_TI_BIL_FOY_TARAFCollection.Find(vi => vi.CARI_ID == BelgeUtil.Inits.KrediBorclusu) == null) continue;
                paraVEKALET_PULU = ParaVeDovizId.Topla(paraVEKALET_PULU, new ParaVeDovizId(item.VEKALET_PULU, item.VEKALET_PULU_DOVIZ_ID));
                paraVEKALET_HARCI = ParaVeDovizId.Topla(paraVEKALET_HARCI, new ParaVeDovizId(item.VEKALET_HARCI, item.VEKALET_HARCI_DOVIZ_ID));
                //paraIH_GIDERI_DOVIZ_ID = ParaVeDovizId.Topla(paraIH_GIDERI_DOVIZ_ID, new ParaVeDovizId(item.IH_GIDERI, item.IH_GIDERI_DOVIZ_ID));
                paraTS_VEKALET_TOPLAMI = ParaVeDovizId.Topla(paraTS_VEKALET_TOPLAMI, new ParaVeDovizId(item.TS_VEKALET_TOPLAMI, item.TS_VEKALET_TOPLAMI_DOVIZ_ID));
            }

            sanalFoy.VEKALET_PULU = paraVEKALET_PULU.Para;
            sanalFoy.VEKALET_PULU_DOVIZ_ID = paraVEKALET_PULU.DovizId;

            sanalFoy.VEKALET_HARCI = paraVEKALET_HARCI.Para;
            sanalFoy.VEKALET_HARCI_DOVIZ_ID = paraVEKALET_HARCI.DovizId;

            //sanalFoy.IH_GIDERI = paraIH_GIDERI_DOVIZ_ID.Para;
            //sanalFoy.IH_GIDERI_DOVIZ_ID = paraIH_GIDERI_DOVIZ_ID.DovizId;

            sanalFoy.TS_VEKALET_TOPLAMI = paraTS_VEKALET_TOPLAMI.Para;
            sanalFoy.TS_VEKALET_TOPLAMI_DOVIZ_ID = paraTS_VEKALET_TOPLAMI.DovizId;

            //sanalFoy.CEK_KOMISYONU = paraCEK_KOMISYONU.Para;
            //sanalFoy.CEK_KOMISYONU_DOVIZ_ID = paraCEK_KOMISYONU.DovizId;

            //sanalFoy.KARSILIKSIZ_CEK_TAZMINATI = paraKARSILIKSIZ_CEK_TAZMINATI.Para;
            //sanalFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = paraKARSILIKSIZ_CEK_TAZMINATI.DovizId;

            #endregion Diğer Alanlar toplanıyor

            //Takip açılmamış klasörde harç hesaplanmasını önlemek için eklendi. MB
            if (DataRepository.AV001_TDIE_BIL_PROJE_ICRA_FOYProvider.GetByPROJE_ID(proje.ID).Count == 0)
                sanalFoy.BAKIYE_HARC_TOPLAMA_EKLE = false;

            var ozetHesap = new HesapAraclari.OzetHesap(sanalFoy);

            ozetHesap.MyProje = proje;

            if (proje.AV001_TDIE_BIL_PROJE_HESAPCollection.Count == 0)
                proje.AV001_TDIE_BIL_PROJE_HESAPCollection.Add(ozetHesap.GetProjeHesap());
            else
                ozetHesap.GetProjeHesap(proje.AV001_TDIE_BIL_PROJE_HESAPCollection[0]);

            //proje.AV001_TDIE_BIL_PROJE_HESAPCollection.ForEach(vi => vi.PROJE_ID = proje.ID);

            //DataRepository.AV001_TDIE_BIL_PROJE_HESAPProvider.Save(proje.AV001_TDIE_BIL_PROJE_HESAPCollection);

            if (kaydet)
            {
                //todo : prosedürde hata var düzeltilip kullanıma açılacak <gkn>
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepSave(proje, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_HESAP>));

                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN,
                     DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));
                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI,
                   DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));
            }

            #region xml çıktı

            //System.Xml.Serialization.XmlSerializer se = new System.Xml.Serialization.XmlSerializer(sanalFoy.GetType());

            //System.IO.FileStream fs = new System.IO.FileStream("deneme.xml", System.IO.FileMode.OpenOrCreate);

            //se.Serialize(fs, sanalFoy);

            //fs.Close();

            #endregion xml çıktı

            return ozetHesap;
        }

        /// <summary>
        /// Aynı alacak nedeninden farklı takipler açılmış ise üzerlerindeki işleme konan tutarları toplayıp
        /// asıl alacağın üzerine yazar
        /// </summary>
        /// <param name="vi"></param>
        /// <returns></returns>
        private void AlacakIslemeKonanTutarAyarla(AV001_TI_BIL_ALACAK_NEDEN aNeden)
        {
            if (aNeden.ISLEME_KONAN_TUTAR < 0) aNeden.ISLEME_KONAN_TUTAR *= -1;
            return;
        }

        private void AltDosyaDegerleriEkle(AV001_TI_BIL_FOY sanalFoy, AV001_TD_BIL_HAZIRLIK sorusturma)
        {
            if (sorusturma.AV001_TDI_BIL_MASRAF_AVANSCollection.Count == 0)
                DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(sorusturma, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>), typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));

            sanalFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.AddRange(sorusturma.AV001_TDI_BIL_MASRAF_AVANSCollection);
        }

        private void AltDosyaDegerleriEkle(AV001_TI_BIL_FOY sanalFoy, AV001_TD_BIL_FOY davaFoy)
        {
            if (davaFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.Count == 0)
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(davaFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>), typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));

            foreach (var item in davaFoy.AV001_TDI_BIL_MASRAF_AVANSCollection)
            {
                sanalFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.Add(item);
            }
        }

        #endregion 2. Yapı

        #region Tools

        public static TList<AV001_TI_BIL_ALACAK_NEDEN> GetAlacakNedenByEuId(Guid uniqId, bool tumuGelsin)
        {
            string sorgu = string.Format(@"SELECT * FROM AV001_TI_BIL_ALACAK_NEDEN
                                            WHERE EU_ID = '{0}' ", uniqId.ToString());
            string whereClause = string.Format(@"EU_ID = '{0}'", uniqId.ToString());
            if (!tumuGelsin)
            {
                sorgu += " AND ICRA_FOY_ID IS NOT NULL ";
            }

            var liste = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

            liste = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.Find(whereClause);

            if (!tumuGelsin)
            {
                liste = new TList<AV001_TI_BIL_ALACAK_NEDEN>(liste.Where(item => item.ICRA_FOY_ID != null).ToList());
            }
            //AvukatProLib2.Data.Bases.AV001_TI_BIL_ALACAK_NEDENProviderBase.Fill(
            //    DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu), liste, 0, int.MaxValue);

            return liste;
        }

        public static TList<AV001_TI_BIL_ALACAK_NEDEN> GetAlacakNedenByEuId(Guid? uniqId)
        {
            if (uniqId.HasValue)
                return GetAlacakNedenByEuId(uniqId.Value, false);

            return new TList<AV001_TI_BIL_ALACAK_NEDEN>();
        }

        /// <summary>
        /// Projenin taraf hesaplarını döndürür
        /// </summary>
        /// <param name="proje"></param>
        /// <returns></returns>
        public static TList<AV001_TDIE_BIL_PROJE_TARAF_HESAP> GetProjeTaraflari(AV001_TDIE_BIL_PROJE proje)
        {
            return proje.AV001_TDIE_BIL_PROJE_TARAF_HESAPCollection;
        }

        /// <summary>
        /// Sanal föy oluşturmada yada alt dosyadan değerler alınırken gerekli alanların alınıp
        /// eklenecek föy üzerine ekler
        /// </summary>
        /// <param name="eklenecekFoy">bu nesnenin üzerine eklenecek</param>
        /// <param name="altFoy">bu nesnedeki değerler eklenecek</param>
        private void AltDosyaDegerleriEkle(AV001_TI_BIL_FOY eklenecekFoy, AV001_TI_BIL_FOY altFoy)
        {
            var hesap = new Hesap.Icra(altFoy);

            //FoyDeepLoad(altFoy);

            if (altFoy.AV001_TI_BIL_BORCLU_ODEMECollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(altFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_ODEME>));
            foreach (AV001_TI_BIL_BORCLU_ODEME odm in altFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
            {
                #region <MB-20100714>

                //Klasör üzerinde ödeme varsa bu ödeme miktarının da takibe yansıması gerekiyor. Bu nedenle klasörden takip dosyası oluşturulurken dosya için klasördeki ödemenin kopyası bir ödeme oluşturuyorum. Bu ödemenin klasörde tekrar hesaplanmaması gerekiyor. Ama takibe ayrıca bir ödeme girilirse bu ödemenin klasör hesabına yansıması gerekli.Bu ayrımı sağlamak için klasörden takip oluşturken verdiğim ödeme (varsa) kaydının KAYNAK_TABLO_ID alanına "1" değerini veriyorum. Bu alan başka durumlarda değer almıyor.
                if (odm.KAYNAK_TABLO_ID != 1)
                    eklenecekFoy.AV001_TI_BIL_BORCLU_ODEMECollection.Add(odm);

                #endregion <MB-20100714>
            }

            foreach (AV001_TDI_BIL_MASRAF_AVANS mAvans in altFoy.AV001_TDI_BIL_MASRAF_AVANSCollection)
            {
                if (mAvans.MASRAF_AVANS_TIP == (int)MasrafAvansTip.Masraf)//(mAvans.MANUEL_KAYIT_MI && mAvans.MASRAF_AVANS_TIP == (int)MasrafAvansTip.Masraf)
                {
                    DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(mAvans, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));
                    eklenecekFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.Add(mAvans);
                }
            }
            foreach (AV001_TI_BIL_HARC harc in altFoy.AV001_TI_BIL_HARCCollection)
            {
                if (harc.NISPI_HARC_KALEM_ID != (int)AvukatProLib.Extras.IcraNispiHarcTipi.HACiZDEN_EVVEL_BAKiYE_HARC
                    && harc.NISPI_HARC_KALEM_ID != (int)AvukatProLib.Extras.IcraNispiHarcTipi.CEZAEVi_HARCi)
                    eklenecekFoy.AV001_TI_BIL_HARCCollection.Add(harc);
            }

            ParaVeDovizId ilkTebligatGideri = ParaVeDovizId.Topla(new ParaVeDovizId(eklenecekFoy.ILK_TEBLIGAT_GIDERI, eklenecekFoy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID),
                new ParaVeDovizId(altFoy.ILK_TEBLIGAT_GIDERI, altFoy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID));

            ParaVeDovizId prTAKIP_VEKALET_UCRETI = new ParaVeDovizId();

            // 12.01.2014 POAŞ ın talebi üzerine klasördeki hep foy için vekalet ücreti kredi borçlusu olsun olmasın toplam vekalet ücretine ekleniyor
            
            //if (altFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(vi => vi.CARI_ID == BelgeUtil.Inits.KrediBorclusu) != null)
                prTAKIP_VEKALET_UCRETI = ParaVeDovizId.Topla(new ParaVeDovizId(eklenecekFoy.TAKIP_VEKALET_UCRETI, eklenecekFoy.TAKIP_VEKALET_UCRETI_DOVIZ_ID),
                   new ParaVeDovizId(altFoy.TAKIP_VEKALET_UCRETI, altFoy.TAKIP_VEKALET_UCRETI_DOVIZ_ID));
            //else
            //    prTAKIP_VEKALET_UCRETI = new ParaVeDovizId(eklenecekFoy.TAKIP_VEKALET_UCRETI, eklenecekFoy.TAKIP_VEKALET_UCRETI_DOVIZ_ID);

            ParaVeDovizId prTAHLIYE_VEK_UCR = ParaVeDovizId.Topla(new ParaVeDovizId(eklenecekFoy.TAHLIYE_VEK_UCR, eklenecekFoy.TAHLIYE_VEK_UCR_DOVIZ_ID),
                new ParaVeDovizId(altFoy.TAHLIYE_VEK_UCR, altFoy.TAHLIYE_VEK_UCR_DOVIZ_ID));

            ParaVeDovizId prTD_VEK_UCR = ParaVeDovizId.Topla(new ParaVeDovizId(eklenecekFoy.TD_VEK_UCR, eklenecekFoy.TD_VEK_UCR_DOVIZ_ID),
                new ParaVeDovizId(altFoy.TD_VEK_UCR, altFoy.TD_VEK_UCR_DOVIZ_ID));

            ParaVeDovizId prDAVA_VEKALET_UCRETI = ParaVeDovizId.Topla(new ParaVeDovizId(eklenecekFoy.DAVA_VEKALET_UCRETI, eklenecekFoy.DAVA_VEKALET_UCRETI_DOVIZ_ID),
                new ParaVeDovizId(altFoy.DAVA_VEKALET_UCRETI, altFoy.DAVA_VEKALET_UCRETI_DOVIZ_ID));
            ParaVeDovizId prIH_VEKALET_UCRETI = ParaVeDovizId.Topla(new ParaVeDovizId(eklenecekFoy.IH_VEKALET_UCRETI, eklenecekFoy.IH_VEKALET_UCRETI_DOVIZ_ID),
                new ParaVeDovizId(altFoy.IH_VEKALET_UCRETI, altFoy.IH_VEKALET_UCRETI_DOVIZ_ID));

            ParaVeDovizId prPESIN_HARC = ParaVeDovizId.Topla(new ParaVeDovizId(eklenecekFoy.PESIN_HARC, eklenecekFoy.PESIN_HARC_DOVIZ_ID),
                new ParaVeDovizId(altFoy.PESIN_HARC, altFoy.PESIN_HARC_DOVIZ_ID));

            ParaVeDovizId prBASVURMA_HARCI = ParaVeDovizId.Topla(new ParaVeDovizId(eklenecekFoy.BASVURMA_HARCI, eklenecekFoy.BASVURMA_HARCI_DOVIZ_ID),
                new ParaVeDovizId(altFoy.BASVURMA_HARCI, altFoy.BASVURMA_HARCI_DOVIZ_ID));

            ParaVeDovizId prKARSILIKSIZ_CEK_TAZMINATI = ParaVeDovizId.Topla(new ParaVeDovizId(eklenecekFoy.KARSILIKSIZ_CEK_TAZMINATI, eklenecekFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID),
                new ParaVeDovizId(altFoy.KARSILIKSIZ_CEK_TAZMINATI, altFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID));

            ParaVeDovizId prCEK_KOMISYONU = ParaVeDovizId.Topla(new ParaVeDovizId(eklenecekFoy.CEK_KOMISYONU, eklenecekFoy.CEK_KOMISYONU_DOVIZ_ID),
                new ParaVeDovizId(altFoy.CEK_KOMISYONU, altFoy.CEK_KOMISYONU_DOVIZ_ID));

            ParaVeDovizId prDEPO_HARCI = ParaVeDovizId.Topla(new ParaVeDovizId(eklenecekFoy.DEPO_HARCI, eklenecekFoy.DEPO_HARCI_DOVIZ_ID),
                new ParaVeDovizId(altFoy.DEPO_HARCI, altFoy.DEPO_HARCI_DOVIZ_ID));

            ParaVeDovizId prDEPO_VEKALET_UCRETI = ParaVeDovizId.Topla(new ParaVeDovizId(eklenecekFoy.DEPO_VEKALET_UCRETI, eklenecekFoy.DEPO_VEKALET_UCRET_DOVIZ_ID),
    new ParaVeDovizId(altFoy.DEPO_VEKALET_UCRETI, altFoy.DEPO_VEKALET_UCRET_DOVIZ_ID));

            ParaVeDovizId prIH_GIDERI = ParaVeDovizId.Topla(new ParaVeDovizId(eklenecekFoy.IH_GIDERI, eklenecekFoy.IH_GIDERI_DOVIZ_ID),
                new ParaVeDovizId(altFoy.IH_GIDERI, altFoy.IH_GIDERI_DOVIZ_ID));

            eklenecekFoy.IH_GIDERI = prIH_GIDERI.Para;
            eklenecekFoy.IH_GIDERI_DOVIZ_ID = prIH_GIDERI.DovizId;

            eklenecekFoy.DEPO_HARCI = prDEPO_HARCI.Para;
            eklenecekFoy.DEPO_HARCI_DOVIZ_ID = prDEPO_HARCI.DovizId;

            eklenecekFoy.DEPO_VEKALET_UCRETI = prDEPO_VEKALET_UCRETI.Para;
            eklenecekFoy.DEPO_VEKALET_UCRET_DOVIZ_ID = prDEPO_VEKALET_UCRETI.DovizId;

            eklenecekFoy.CEK_KOMISYONU = prCEK_KOMISYONU.Para;
            eklenecekFoy.CEK_KOMISYONU_DOVIZ_ID = prCEK_KOMISYONU.DovizId;

            eklenecekFoy.KARSILIKSIZ_CEK_TAZMINATI = prKARSILIKSIZ_CEK_TAZMINATI.Para;
            eklenecekFoy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = prKARSILIKSIZ_CEK_TAZMINATI.DovizId;

            eklenecekFoy.ILK_TEBLIGAT_GIDERI = ilkTebligatGideri.Para;
            eklenecekFoy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID = ilkTebligatGideri.DovizId;

            eklenecekFoy.TAKIP_VEKALET_UCRETI = prTAKIP_VEKALET_UCRETI.Para;
            eklenecekFoy.TAKIP_VEKALET_UCRETI_DOVIZ_ID = prTAKIP_VEKALET_UCRETI.DovizId;

            eklenecekFoy.TAHLIYE_VEK_UCR = prTAHLIYE_VEK_UCR.Para;
            eklenecekFoy.TAHLIYE_VEK_UCR_DOVIZ_ID = prTAHLIYE_VEK_UCR.DovizId;

            eklenecekFoy.TD_VEK_UCR = prTD_VEK_UCR.Para;
            eklenecekFoy.TD_VEK_UCR_DOVIZ_ID = prTD_VEK_UCR.DovizId;

            eklenecekFoy.DAVA_VEKALET_UCRETI = prDAVA_VEKALET_UCRETI.Para;
            eklenecekFoy.DAVA_VEKALET_UCRETI_DOVIZ_ID = prDAVA_VEKALET_UCRETI.DovizId;

            eklenecekFoy.PESIN_HARC = prPESIN_HARC.Para;
            eklenecekFoy.PESIN_HARC_DOVIZ_ID = prPESIN_HARC.DovizId;

            eklenecekFoy.BASVURMA_HARCI = prBASVURMA_HARCI.Para;
            eklenecekFoy.BASVURMA_HARCI_DOVIZ_ID = prBASVURMA_HARCI.DovizId;

            eklenecekFoy.IH_VEKALET_UCRETI = prIH_VEKALET_UCRETI.Para;
            eklenecekFoy.IH_VEKALET_UCRETI_DOVIZ_ID = prIH_VEKALET_UCRETI.DovizId;

            var childFoyler = DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_ICRA_FOY_ID(altFoy.ID);

            if (childFoyler.Count == 0)
            {
                //Klasör alacağı haricindeki dosyalardan sadece masraf ve ödemeler alınıyor <gkn>
                //alacakların alımı iptal edildi <gkn>
                //foreach (var alacak in altFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                //{
                //    eklenecekFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Add(alacak);
                //}
            }
            else
                altFoy.Tag = true;
        }

        /// <summary>
        /// gönderilen föy nesnesinin ilişkili dosyalarda alt dosya olarak kayıtlı olup olmadığını kontrol eder
        /// </summary>
        /// <param name="mFoy"></param>
        /// <returns></returns>
        private bool AnaDosyami(AV001_TI_BIL_FOY mFoy)
        {
            TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> detaylar = DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_ICRA_FOY_ID(mFoy.ID);
            return detaylar.Count == 0;
        }

        private void ChildFoyAlacakNedenTaraflariniEkle(AV001_TDIE_BIL_PROJE proje, AV001_TI_BIL_FOY sanalFoy)
        {
            var childFoyler = proje.AV001_TI_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY.Where(vi => (bool?)vi.Tag == true);

            if (childFoyler.Count() > 0)
            {
                var alacakNEdensonucları = childFoyler.Select(vi => vi.AV001_TI_BIL_ALACAK_NEDENCollection);
                TList<AV001_TI_BIL_ALACAK_NEDEN> alacakNedenler = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

                foreach (var item in alacakNEdensonucları)
                {
                    alacakNedenler.AddRange(item);
                }

                foreach (var aNeden in alacakNedenler)
                {
                    var masterNedenler = sanalFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Where(vi => vi.EU_ID == aNeden.EU_ID);
                    if (masterNedenler.Count() > 0)
                    {
                        masterNedenler.First().AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.AddRange(aNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection);
                    }
                }
            }
        }

        /// <summary>
        /// proje nesnesine bağlı ilgili cariId  de kayıt varsa onu döndürür yoksa yeni oluşturur onu döndürür
        /// </summary>
        /// <param name="proje"></param>
        /// <param name="tarafCariId"></param>
        /// <returns></returns>
        private AV001_TDIE_BIL_PROJE_TARAF_HESAP GetProjeTaraf(AV001_TDIE_BIL_PROJE proje, int tarafCariId)
        {
            if (proje.AV001_TDIE_BIL_PROJE_TARAF_HESAPCollection.Count == 0)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren
                    , typeof(TList<AV001_TDIE_BIL_PROJE_TARAF_HESAP>));

            var taraf = proje.AV001_TDIE_BIL_PROJE_TARAF_HESAPCollection.Find(AV001_TDIE_BIL_PROJE_TARAF_HESAPColumn.CARI_ID, tarafCariId);

            if (taraf == null)
            {
                AV001_TDIE_BIL_PROJE_TARAF_HESAP yeniTaraf = proje.AV001_TDIE_BIL_PROJE_TARAF_HESAPCollection.AddNew();

                yeniTaraf.CARI_ID = tarafCariId;

                return yeniTaraf;
            }
            return taraf;
        }

        /// <summary>
        /// proje nesnesinin üzerindeki ilgili alanları hesaplanacak föyün üzerine ekler
        /// </summary>
        /// <param name="eklenecekFoy"></param>
        /// <param name="proje"></param>
        private void ProjeDegerleriniEkle(AV001_TI_BIL_FOY eklenecekFoy, AV001_TDIE_BIL_PROJE proje)
        {
            //Deepload çekilirken yapılan Count==0 kontrolü kapatıldı. Klasöre yeni bir alacak, ödeme, masraf girildiğinde ya da varolan düzenlendiğinde deepload çekilmeden yeni değerler hesaba katılmadığında kontroller kaptıldı. MB

            #region Alacak Nedenleri

            //if (proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN.Count == 0)
            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren,
                typeof(TList<AV001_TDIE_BIL_PROJE_ALACAK_NEDEN>),
                typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>),
                typeof(TList<AV001_TDIE_BIL_PROJE_HESAP>));

            foreach (var item in proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN)
            {
                //var iliskiKayitlari = DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByAlacakNedenEUID(item.EU_ID);

                //if (!item.ICRA_FOY_ID.HasValue && iliskiKayitlari.Count == 0)
                eklenecekFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Add(item);
            }

            #endregion Alacak Nedenleri

            #region Borçlu Ödemeleri

            //if (proje.AV001_TI_BIL_BORCLU_ODEMECollection_From_AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEME.Count == 0)
            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_ODEME>));

            foreach (var item in proje.AV001_TI_BIL_BORCLU_ODEMECollection_From_AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEME)
            {
                if (!item.ICRA_FOY_ID.HasValue)
                    eklenecekFoy.AV001_TI_BIL_BORCLU_ODEMECollection.Add(item);
            }

            #endregion Borçlu Ödemeleri

            #region Masraf Avans

            //if (proje.AV001_TDI_BIL_MASRAF_AVANSCollection_From_AV001_TDIE_BIL_PROJE_MASRAF_AVANS.Count == 0)
            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));

            foreach (var item in proje.AV001_TDI_BIL_MASRAF_AVANSCollection_From_AV001_TDIE_BIL_PROJE_MASRAF_AVANS)
            {
                if (!item.ICRA_FOY_ID.HasValue && item.MASRAF_AVANS_TIP != (int)MasrafAvansTip.Avans)
                {
                    eklenecekFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.Add(item);
                }
            }

            #endregion Masraf Avans

            eklenecekFoy.SON_HESAP_TARIHI = DateTime.Now;
            eklenecekFoy.TAKIP_TARIHI = proje.BASLANGIC_TARIHI; // DateTime.Now;
            eklenecekFoy.TAKIP_TALEP_ID = 1;
            eklenecekFoy.TS_HESAP_TIP_ID = eklenecekFoy.TO_HESAP_TIP_ID = proje.AV001_TDIE_BIL_PROJE_HESAPCollection.Count > 0 ? proje.AV001_TDIE_BIL_PROJE_HESAPCollection[0].HESAPLAMA_TIPI : 2;

            eklenecekFoy.TO_HESAP_TIP_IDSource = DataRepository.AV001_TI_KOD_HESAP_TIPProvider.GetByID(eklenecekFoy.TO_HESAP_TIP_ID);
            DataRepository.AV001_TI_KOD_HESAP_TIPProvider.DeepLoad(eklenecekFoy.TO_HESAP_TIP_IDSource, false, DeepLoadType.IncludeChildren,
                typeof(TList<AV001_TI_KOD_HESAP_TIP_SIRA>));

            eklenecekFoy.TS_HESAP_TIP_IDSource = eklenecekFoy.TO_HESAP_TIP_IDSource;
        }

        /// <summary>
        /// Hesaba gönderilen sanal föyün ilgisiz alanlarını sıfırlar
        /// </summary>
        /// <param name="alacakNedenFoyu"></param>
        private void SanalFoyAlanlariniTemizle(AV001_TI_BIL_FOY alacakNedenFoyu)
        {
            List<ParaVeDovizId> paralar = new List<ParaVeDovizId>();
            paralar.Add(new ParaVeDovizId(alacakNedenFoyu.ASIL_ALACAK, alacakNedenFoyu.ASIL_ALACAK_DOVIZ_ID));
            paralar.Add(new ParaVeDovizId(alacakNedenFoyu.ISLEMIS_FAIZ, alacakNedenFoyu.ISLEMIS_FAIZ_DOVIZ_ID));
            paralar.Add(new ParaVeDovizId(alacakNedenFoyu.BSMV_TO, alacakNedenFoyu.BSMV_TO_DOVIZ_ID));
            paralar.Add(new ParaVeDovizId(alacakNedenFoyu.KDV_TO, alacakNedenFoyu.KDV_TO_DOVIZ_ID));
            paralar.Add(new ParaVeDovizId(alacakNedenFoyu.OIV_TO, alacakNedenFoyu.OIV_TO_DOVIZ_ID));
            paralar.Add(new ParaVeDovizId(alacakNedenFoyu.KKDV_TO, alacakNedenFoyu.KKDV_TO_DOVIZ_ID));
            paralar.Add(new ParaVeDovizId(alacakNedenFoyu.CEK_KOMISYONU, alacakNedenFoyu.CEK_KOMISYONU_DOVIZ_ID));
            paralar.Add(new ParaVeDovizId(alacakNedenFoyu.PROTESTO_GIDERI, alacakNedenFoyu.PROTESTO_GIDERI_DOVIZ_ID));
            paralar.Add(new ParaVeDovizId(alacakNedenFoyu.PROTOKOL_MIKTARI, alacakNedenFoyu.PROTOKOL_MIKTARI_DOVIZ_ID));
            ParaVeDovizId pId = ParaVeDovizId.Topla(paralar);
            alacakNedenFoyu.TAKIP_CIKISI = pId.Para;
            alacakNedenFoyu.TAKIP_CIKISI_DOVIZ_ID = pId.DovizId;
            alacakNedenFoyu.KALAN = pId.Para;
            alacakNedenFoyu.KALAN_DOVIZ_ID = pId.DovizId;

            alacakNedenFoyu.FAIZ_TOPLAMI = 0;
            alacakNedenFoyu.BASVURMA_HARCI = 0;
            alacakNedenFoyu.BIRIKMIS_NAFAKA = 0;
            alacakNedenFoyu.OIV_TS = 0;
            alacakNedenFoyu.BSMV_TS = 0;
            alacakNedenFoyu.DAMGA_PULU = 0;
            alacakNedenFoyu.DAVA_GIDERLERI = 0;
            alacakNedenFoyu.DAVA_INKAR_TAZMINATI = 0;
            alacakNedenFoyu.DAVA_VEKALET_UCRETI = 0;
            alacakNedenFoyu.DIGER_GIDERLER = 0;
            alacakNedenFoyu.DIGER_HARC = 0;
            alacakNedenFoyu.EXTRA_MONEY1 = 0;
            alacakNedenFoyu.EXTRA_MONEY2 = 0;
            alacakNedenFoyu.FERAGAT_HARCI = 0;
            alacakNedenFoyu.FERAGAT_TOPLAMI = 0;
            alacakNedenFoyu.HARC_TOPLAMI = 0;
            alacakNedenFoyu.HESAPLANMIS_BSMV = 0;
            alacakNedenFoyu.HESAPLANMIS_FAIZ = 0;
            alacakNedenFoyu.HESAPLANMIS_KDV = 0;
            alacakNedenFoyu.HESAPLANMIS_KKDF = 0;
            alacakNedenFoyu.HESAPLANMIS_OIV = 0;
            alacakNedenFoyu.ICRA_INKAR_TAZMINATI = 0;
            alacakNedenFoyu.IFLAS_BASVURMA_HARCI = 0;
            alacakNedenFoyu.IFLASIN_ACILMASI_HARCI = 0;
            alacakNedenFoyu.IH_VEKALET_UCRETI = 0;
            alacakNedenFoyu.IHTAR_GIDERI = 0;
            alacakNedenFoyu.ILAM_BK_YARG_ONAMA = 0;
            alacakNedenFoyu.ILAM_INKAR_TAZMINATI = 0;
            alacakNedenFoyu.ILAM_TEBLIG_GIDERI = 0;
            alacakNedenFoyu.ILAM_UCRETLER_TOPLAMI = 0;
            alacakNedenFoyu.ILAM_VEK_UCR = 0;
            alacakNedenFoyu.ILAM_YARGILAMA_GIDERI = 0;
            alacakNedenFoyu.ILK_GIDERLER = 0;
            alacakNedenFoyu.ILK_TEBLIGAT_GIDERI = 0;
            alacakNedenFoyu.IT_GIDERI = 0;
            alacakNedenFoyu.IT_HACIZDE_ODENEN = 0;
            alacakNedenFoyu.IT_VEKALET_UCRETI = 0;

            alacakNedenFoyu.KALAN_TAHSIL_HARCI = 0;
            alacakNedenFoyu.KARSI_VEKALET_TOPLAMI = 0;
            alacakNedenFoyu.KARSILIK_TUTARI = 0;
            alacakNedenFoyu.KARSILIKSIZ_CEK_TAZMINATI = 0;
            alacakNedenFoyu.KDV_TS = 0;

            alacakNedenFoyu.KO_ILAM_TOPLAM = 0;
            alacakNedenFoyu.MAHSUP_TOPLAMI = 0;
            alacakNedenFoyu.MASAYA_KATILMA_HARCI = 0;
            alacakNedenFoyu.ODEME_TOPLAMI = 0;
            alacakNedenFoyu.ODENEN_TAHSIL_HARCI = 0;
            alacakNedenFoyu.OZEL_TAZMINAT = 0;
            alacakNedenFoyu.OZEL_TUTAR1 = 0;
            alacakNedenFoyu.OZEL_TUTAR2 = 0;
            alacakNedenFoyu.OZEL_TUTAR3 = 0;
            alacakNedenFoyu.PAYLASMA_HARCI = 0;
            alacakNedenFoyu.PESIN_HARC = 0;
            alacakNedenFoyu.SONRAKI_FAIZ = 0;
            alacakNedenFoyu.SONRAKI_TAZMINAT = 0;
            alacakNedenFoyu.TAHLIYE_HARCI = 0;
            alacakNedenFoyu.TAHLIYE_VEK_UCR = 0;
            alacakNedenFoyu.TAKIP_VEKALET_UCRETI = 0;
            alacakNedenFoyu.TD_BAKIYE_HARC = 0;
            alacakNedenFoyu.TD_GIDERI = 0;
            alacakNedenFoyu.TD_TEBLIG_GIDERI = 0;
            alacakNedenFoyu.TD_VEK_UCR = 0;
            alacakNedenFoyu.TESLIM_HARCI = 0;
            alacakNedenFoyu.TO_MASRAF_TOPLAMI = 0;
            alacakNedenFoyu.TO_ODEME_MAHSUP_TOPLAMI = 0;
            alacakNedenFoyu.TO_ODEME_TOPLAMI = 0;
            alacakNedenFoyu.TO_VEKALET_TOPLAMI = 0;
            alacakNedenFoyu.TO_YONETIMG_TAZMINATI = 0;
            alacakNedenFoyu.TS_MASRAF_TOPLAMI = 0;
            alacakNedenFoyu.TS_VEKALET_TOPLAMI = 0;
            alacakNedenFoyu.TUM_MASRAF_TOPLAMI = 0;
            alacakNedenFoyu.TUM_VEKALET_TOPLAMI = 0;
            alacakNedenFoyu.VEKALET_HARCI = 0;
            alacakNedenFoyu.VEKALET_PULU = 0;

            alacakNedenFoyu.ODEME_TOPLAMI_DOVIZ_ID = 1;
            alacakNedenFoyu.ODENEN_TAHSIL_HARCI_DOVIZ_ID = 1;
            alacakNedenFoyu.OIV_TO_DOVIZ_ID = 1;
            alacakNedenFoyu.OIV_TS_DOVIZ_ID = 1;
            alacakNedenFoyu.OZEL_TAZMINAT_DOVIZ_ID = 1;
            alacakNedenFoyu.OZEL_TUTAR1_DOVIZ_ID = 1;
            alacakNedenFoyu.OZEL_TUTAR2_DOVIZ_ID = 1;
            alacakNedenFoyu.OZEL_TUTAR3_DOVIZ_ID = 1;
            alacakNedenFoyu.PAYLASMA_HARCI_DOVIZ_ID = 1;
            alacakNedenFoyu.PESIN_HARC_DOVIZ_ID = 1;
            alacakNedenFoyu.PROTESTO_GIDERI_DOVIZ_ID = 1;
            alacakNedenFoyu.PROTOKOL_MIKTARI_DOVIZ_ID = 1;
            alacakNedenFoyu.SONRAKI_FAIZ_DOVIZ_ID = 1;
            alacakNedenFoyu.SONRAKI_TAZMINAT_DOVIZ_ID = 1;
            alacakNedenFoyu.TAHLIYE_HARCI_DOVIZ_ID = 1;
            alacakNedenFoyu.TAHLIYE_VEK_UCR_DOVIZ_ID = 1;
            alacakNedenFoyu.TAKIP_CIKISI_DOVIZ_ID = 1;
            alacakNedenFoyu.TAKIP_VEKALET_UCRETI_DOVIZ_ID = 1;
            alacakNedenFoyu.TD_BAKIYE_HARC_DOVIZ_ID = 1;
            alacakNedenFoyu.TD_GIDERI_DOVIZ_ID = 1;
            alacakNedenFoyu.TD_TEBLIG_GIDERI_DOVIZ_ID = 1;
            alacakNedenFoyu.TD_VEK_UCR_DOVIZ_ID = 1;
            alacakNedenFoyu.TESLIM_HARCI_DOVIZ_ID = 1;
            alacakNedenFoyu.TO_MASRAF_TOPLAMI_DOVIZ_ID = 1;
            alacakNedenFoyu.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = 1;
            alacakNedenFoyu.TO_ODEME_TOPLAMI_DOVIZ_ID = 1;
            alacakNedenFoyu.TO_VEKALET_TOPLAMI_DOVIZ_ID = 1;
            alacakNedenFoyu.TO_YONETIMG_TAZMINATI_DOVIZ_ID = 1;
            alacakNedenFoyu.TS_MASRAF_TOPLAMI_DOVIZ_ID = 1;
            alacakNedenFoyu.TS_VEKALET_TOPLAMI_DOVIZ_ID = 1;
            alacakNedenFoyu.TUM_MASRAF_TOPLAMI_DOVIZ_ID = 1;
            alacakNedenFoyu.TUM_VEKALET_TOPLAMI_DOVIZ_ID = 1;
            alacakNedenFoyu.VEKALET_HARCI_DOVIZ_ID = 1;
            alacakNedenFoyu.VEKALET_PULU_DOVIZ_ID = 1;
        }

        /// <summary>
        /// Proje taraf üzerindeki hesap alanlarına alacak neden taraf üzerinden ilk değerleri atıyor
        /// </summary>
        /// <param name="projeTaraf"></param>
        /// <param name="alacakNedenTaraf"></param>
        private void SetProjeTaraf(AV001_TDIE_BIL_PROJE_TARAF_HESAP projeTaraf, AV001_TI_BIL_ALACAK_NEDEN_TARAF alacakNedenTaraf)
        {
            #region Alanlar Eşitleniyor

            projeTaraf.ASIL_ALACAK = alacakNedenTaraf.ASIL_ALACAK;
            projeTaraf.ASIL_ALACAK_DOVIZ_ID = alacakNedenTaraf.ASIL_ALACAK_DOVIZ_ID;
            projeTaraf.BIRIKMIS_NAFAKA = alacakNedenTaraf.BIRIKMIS_NAFAKA;
            projeTaraf.BIRIKMIS_NAFAKA_DOVIZ_ID = alacakNedenTaraf.BIRIKMIS_NAFAKA_DOVIZ_ID;
            projeTaraf.BSMV_TO = alacakNedenTaraf.BSMV_TO;
            projeTaraf.BSMV_TO_DOVIZ_ID = alacakNedenTaraf.BSMV_TO_DOVIZ_ID;
            projeTaraf.BSMV_TS = alacakNedenTaraf.BSMV_TS;
            projeTaraf.BSMV_TS_DOVIZ_ID = alacakNedenTaraf.BSMV_TS_DOVIZ_ID;
            projeTaraf.CEK_KOMISYONU = alacakNedenTaraf.CEK_KOMISYONU;
            projeTaraf.CEK_KOMISYONU_DOVIZ_ID = alacakNedenTaraf.CEK_KOMISYONU_DOVIZ_ID;
            projeTaraf.CEK_TAZMINATI = alacakNedenTaraf.CEK_TAZMINATI;
            projeTaraf.CEK_TAZMINATI_DOVIZ_ID = alacakNedenTaraf.CEK_TAZMINATI_DOVIZ_ID;
            projeTaraf.DAMGA_PULU = alacakNedenTaraf.DAMGA_PULU;
            projeTaraf.DAMGA_PULU_DOVIZ_ID = alacakNedenTaraf.DAMGA_PULU_DOVIZ_ID;
            projeTaraf.DAVA_GIDERLERI = alacakNedenTaraf.DAVA_GIDERLERI;
            projeTaraf.DAVA_GIDERLERI_DOVIZ_ID = alacakNedenTaraf.DAVA_GIDERLERI_DOVIZ_ID;
            projeTaraf.DAVA_INKAR_TAZMINATI = alacakNedenTaraf.DAVA_INKAR_TAZMINATI;
            projeTaraf.DAVA_INKAR_TAZMINATI_DOVIZ_ID = alacakNedenTaraf.DAVA_INKAR_TAZMINATI_DOVIZ_ID;
            projeTaraf.DAVA_VEKALET_UCRETI = alacakNedenTaraf.DAVA_VEKALET_UCRETI;
            projeTaraf.DAVA_VEKALET_UCRETI_DOVIZ_ID = alacakNedenTaraf.DAVA_VEKALET_UCRETI_DOVIZ_ID;
            projeTaraf.DIGER_GIDERLER = alacakNedenTaraf.DIGER_GIDERLER;
            projeTaraf.DIGER_GIDERLER_DOVIZ_ID = alacakNedenTaraf.DIGER_GIDERLER_DOVIZ_ID;
            projeTaraf.DIGER_HARC = alacakNedenTaraf.DIGER_HARC;
            projeTaraf.DIGER_HARC_DOVIZ_ID = alacakNedenTaraf.DIGER_HARC_DOVIZ_ID;
            projeTaraf.FAIZ_TOPLAMI = alacakNedenTaraf.FAIZ_TOPLAMI;
            projeTaraf.FAIZ_TOPLAMI_DOVIZ_ID = alacakNedenTaraf.FAIZ_TOPLAMI_DOVIZ_ID;
            projeTaraf.FERAGAT_TOPLAMI = alacakNedenTaraf.FERAGAT_TOPLAMI;
            projeTaraf.FERAGAT_TOPLAMI_DOVIZ_ID = alacakNedenTaraf.FERAGAT_TOPLAMI_DOVIZ_ID;
            projeTaraf.HARC_TOPLAMI = alacakNedenTaraf.HARC_TOPLAMI;
            projeTaraf.HARC_TOPLAMI_DOVIZ_ID = alacakNedenTaraf.HARC_TOPLAMI_DOVIZ_ID;
            projeTaraf.HESAPLANMIS_BSMV = alacakNedenTaraf.HESAPLANMIS_BSMV;
            projeTaraf.HESAPLANMIS_BSMV_DOVIZ_ID = alacakNedenTaraf.HESAPLANMIS_BSMV_DOVIZ_ID;
            projeTaraf.HESAPLANMIS_FAIZ = alacakNedenTaraf.HESAPLANMIS_FAIZ;
            projeTaraf.HESAPLANMIS_FAIZ_DOVIZ_ID = alacakNedenTaraf.HESAPLANMIS_FAIZ_DOVIZ_ID;
            projeTaraf.HESAPLANMIS_KDV = alacakNedenTaraf.HESAPLANMIS_KDV;
            projeTaraf.HESAPLANMIS_KDV_DOVIZ_ID = alacakNedenTaraf.HESAPLANMIS_KDV_DOVIZ_ID;
            projeTaraf.HESAPLANMIS_KKDF = alacakNedenTaraf.HESAPLANMIS_KKDF;
            projeTaraf.HESAPLANMIS_KKDF_DOVIZ_ID = alacakNedenTaraf.HESAPLANMIS_KKDF_DOVIZ_ID;
            projeTaraf.HESAPLANMIS_OIV = alacakNedenTaraf.HESAPLANMIS_OIV;
            projeTaraf.HESAPLANMIS_OIV_DOVIZ_ID = alacakNedenTaraf.HESAPLANMIS_OIV_DOVIZ_ID;
            projeTaraf.ICRA_INKAR_TAZMINATI = alacakNedenTaraf.ICRA_INKAR_TAZMINATI;
            projeTaraf.ICRA_INKAR_TAZMINATI_DOVIZ_ID = alacakNedenTaraf.ICRA_INKAR_TAZMINATI_DOVIZ_ID;
            projeTaraf.IH_GIDERI = alacakNedenTaraf.IH_GIDERI;
            projeTaraf.IH_GIDERI_DOVIZ_ID = alacakNedenTaraf.IH_GIDERI_DOVIZ_ID;
            projeTaraf.IH_VEKALET_UCRETI = alacakNedenTaraf.IH_VEKALET_UCRETI;
            projeTaraf.IH_VEKALET_UCRETI_DOVIZ_ID = alacakNedenTaraf.IH_VEKALET_UCRETI_DOVIZ_ID;
            projeTaraf.IHTAR_GIDERI = alacakNedenTaraf.IHTAR_GIDERI;
            projeTaraf.IHTAR_GIDERI_DOVIZ_ID = alacakNedenTaraf.IHTAR_GIDERI_DOVIZ_ID;
            projeTaraf.ILAM_BK_YARG_ONAMA = alacakNedenTaraf.ILAM_BK_YARG_ONAMA;
            projeTaraf.ILAM_BK_YARG_ONAMA_DOVIZ_ID = alacakNedenTaraf.ILAM_BK_YARG_ONAMA_DOVIZ_ID;
            projeTaraf.ILAM_INKAR_TAZMINATI = alacakNedenTaraf.ILAM_INKAR_TAZMINATI;
            projeTaraf.ILAM_INKAR_TAZMINATI_DOVIZ_ID = alacakNedenTaraf.ILAM_INKAR_TAZMINATI_DOVIZ_ID;
            projeTaraf.ILAM_TEBLIG_GIDERI = alacakNedenTaraf.ILAM_TEBLIG_GIDERI;
            projeTaraf.ILAM_TEBLIG_GIDERI_DOVIZ_ID = alacakNedenTaraf.ILAM_TEBLIG_GIDERI_DOVIZ_ID;
            projeTaraf.ILAM_UCRETLER_TOPLAMI = alacakNedenTaraf.ILAM_UCRETLER_TOPLAMI;
            projeTaraf.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID = alacakNedenTaraf.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID;
            projeTaraf.ILAM_VEK_UCR = alacakNedenTaraf.ILAM_VEK_UCR;
            projeTaraf.ILAM_VEK_UCR_DOVIZ_ID = alacakNedenTaraf.ILAM_VEK_UCR_DOVIZ_ID;
            projeTaraf.ILAM_YARGILAMA_GIDERI = alacakNedenTaraf.ILAM_YARGILAMA_GIDERI;
            projeTaraf.ILAM_YARGILAMA_GIDERI_DOVIZ_ID = alacakNedenTaraf.ILAM_YARGILAMA_GIDERI_DOVIZ_ID;
            projeTaraf.ILK_GIDERLER = alacakNedenTaraf.ILK_GIDERLER;
            projeTaraf.ILK_GIDERLER_DOVIZ_ID = alacakNedenTaraf.ILK_GIDERLER_DOVIZ_ID;
            projeTaraf.ISLEMIS_FAIZ = alacakNedenTaraf.ISLEMIS_FAIZ;
            projeTaraf.ISLEMIS_FAIZ_DOVIZ_ID = alacakNedenTaraf.ISLEMIS_FAIZ_DOVIZ_ID;
            projeTaraf.IT_GIDERI = alacakNedenTaraf.IT_GIDERI;
            projeTaraf.IT_GIDERI_DOVIZ_ID = alacakNedenTaraf.IT_GIDERI_DOVIZ_ID;
            projeTaraf.IT_HACIZDE_ODENEN = alacakNedenTaraf.IT_HACIZDE_ODENEN;
            projeTaraf.IT_HACIZDE_ODENEN_DOVIZ_ID = alacakNedenTaraf.IT_HACIZDE_ODENEN_DOVIZ_ID;
            projeTaraf.IT_VEKALET_UCRETI = alacakNedenTaraf.IT_VEKALET_UCRETI;
            projeTaraf.IT_VEKALET_UCRETI_DOVIZ_ID = alacakNedenTaraf.IT_VEKALET_UCRETI_DOVIZ_ID;
            projeTaraf.KALAN = alacakNedenTaraf.KALAN;
            projeTaraf.KALAN_DOVIZ_ID = alacakNedenTaraf.KALAN_DOVIZ_ID;
            projeTaraf.KALAN_TAHSIL_HARCI = alacakNedenTaraf.KALAN_TAHSIL_HARCI;
            projeTaraf.KALAN_TAHSIL_HARCI_DOVIZ_ID = alacakNedenTaraf.KALAN_TAHSIL_HARCI_DOVIZ_ID;
            projeTaraf.KARSI_VEKALET_TOPLAMI = alacakNedenTaraf.KARSI_VEKALET_TOPLAMI;
            projeTaraf.KARSI_VEKALET_TOPLAMI_DOVIZ_ID = alacakNedenTaraf.KARSI_VEKALET_TOPLAMI_DOVIZ_ID;
            projeTaraf.KARSILIK_TUTARI = alacakNedenTaraf.KARSILIK_TUTARI;
            projeTaraf.KARSILIK_TUTARI_DOVIZ_ID = alacakNedenTaraf.KARSILIK_TUTARI_DOVIZ_ID;
            projeTaraf.KARSILIKSIZ_CEK_TAZMINATI = alacakNedenTaraf.KARSILIKSIZ_CEK_TAZMINATI;
            projeTaraf.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = alacakNedenTaraf.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID;
            projeTaraf.KDV_TO = alacakNedenTaraf.KDV_TO;
            projeTaraf.KDV_TO_DOVIZ_ID = alacakNedenTaraf.KDV_TO_DOVIZ_ID;
            projeTaraf.KDV_TS = alacakNedenTaraf.KDV_TS;
            projeTaraf.KDV_TS_DOVIZ_ID = alacakNedenTaraf.KDV_TS_DOVIZ_ID;
            projeTaraf.KKDV_TO = alacakNedenTaraf.KKDV_TO;
            projeTaraf.KKDV_TO_DOVIZ_ID = alacakNedenTaraf.KKDV_TO_DOVIZ_ID;
            projeTaraf.KOMISYONU = alacakNedenTaraf.KOMISYONU;
            projeTaraf.KOMISYONU_DOVIZ_ID = alacakNedenTaraf.KOMISYONU_DOVIZ_ID;
            projeTaraf.MAHSUP_TOPLAMI = alacakNedenTaraf.MAHSUP_TOPLAMI;
            projeTaraf.MAHSUP_TOPLAMI_DOVIZ_ID = alacakNedenTaraf.MAHSUP_TOPLAMI_DOVIZ_ID;
            projeTaraf.MASAYA_KATILMA_HARCI = alacakNedenTaraf.MASAYA_KATILMA_HARCI;
            projeTaraf.MASAYA_KATILMA_HARCI_DOVIZ_ID = alacakNedenTaraf.MASAYA_KATILMA_HARCI_DOVIZ_ID;
            projeTaraf.ODEME_TOPLAMI = alacakNedenTaraf.ODEME_TOPLAMI;
            projeTaraf.ODEME_TOPLAMI_DOVIZ_ID = alacakNedenTaraf.ODEME_TOPLAMI_DOVIZ_ID;
            projeTaraf.ODENEN_TAHSIL_HARCI = alacakNedenTaraf.ODENEN_TAHSIL_HARCI;
            projeTaraf.ODENEN_TAHSIL_HARCI_DOVIZ_ID = alacakNedenTaraf.ODENEN_TAHSIL_HARCI_DOVIZ_ID;
            projeTaraf.OIV_TO = alacakNedenTaraf.OIV_TO;
            projeTaraf.OIV_TO_DOVIZ_ID = alacakNedenTaraf.OIV_TO_DOVIZ_ID;
            projeTaraf.OIV_TS = alacakNedenTaraf.OIV_TS;
            projeTaraf.OIV_TS_DOVIZ_ID = alacakNedenTaraf.OIV_TS_DOVIZ_ID;
            projeTaraf.OZEL_TAZMINAT = alacakNedenTaraf.OZEL_TAZMINAT;
            projeTaraf.OZEL_TAZMINAT_DOVIZ_ID = alacakNedenTaraf.OZEL_TAZMINAT_DOVIZ_ID;
            projeTaraf.OZEL_TUTAR1 = alacakNedenTaraf.OZEL_TUTAR1 ?? 0;
            projeTaraf.OZEL_TUTAR1_DOVIZ_ID = alacakNedenTaraf.OZEL_TUTAR1_DOVIZ_ID;
            projeTaraf.OZEL_TUTAR2 = alacakNedenTaraf.OZEL_TUTAR2;
            projeTaraf.OZEL_TUTAR2_DOVIZ_ID = alacakNedenTaraf.OZEL_TUTAR2_DOVIZ_ID;
            projeTaraf.OZEL_TUTAR3 = alacakNedenTaraf.OZEL_TUTAR3;
            projeTaraf.OZEL_TUTAR3_DOVIZ_ID = alacakNedenTaraf.OZEL_TUTAR3_DOVIZ_ID;
            projeTaraf.PAYLASMA_HARCI = alacakNedenTaraf.PAYLASMA_HARCI;
            projeTaraf.PAYLASMA_HARCI_DOVIZ_ID = alacakNedenTaraf.PAYLASMA_HARCI_DOVIZ_ID;
            projeTaraf.PESIN_HARC = alacakNedenTaraf.PESIN_HARC;
            projeTaraf.PESIN_HARC_DOVIZ_ID = alacakNedenTaraf.PESIN_HARC_DOVIZ_ID;
            projeTaraf.PROTESTO_GIDERI = alacakNedenTaraf.PROTESTO_GIDERI;
            projeTaraf.PROTESTO_GIDERI_DOVIZ_ID = alacakNedenTaraf.PROTESTO_GIDERI_DOVIZ_ID;
            projeTaraf.PROTOKOL_MIKTARI = alacakNedenTaraf.PROTOKOL_MIKTARI;
            projeTaraf.PROTOKOL_MIKTARI_DOVIZ_ID = alacakNedenTaraf.PROTOKOL_MIKTARI_DOVIZ_ID;
            projeTaraf.SONRAKI_FAIZ = alacakNedenTaraf.SONRAKI_FAIZ;
            projeTaraf.SONRAKI_FAIZ_DOVIZ_ID = alacakNedenTaraf.SONRAKI_FAIZ_DOVIZ_ID;
            projeTaraf.SONRAKI_TAZMINAT = alacakNedenTaraf.SONRAKI_TAZMINAT;
            projeTaraf.SONRAKI_TAZMINAT_DOVIZ_ID = alacakNedenTaraf.SONRAKI_TAZMINAT_DOVIZ_ID;
            projeTaraf.SORUMLU_OLUNAN_MIKTAR = alacakNedenTaraf.SORUMLU_OLUNAN_MIKTAR;
            projeTaraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = alacakNedenTaraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID;
            projeTaraf.TAHLIYE_VEK_UCR = alacakNedenTaraf.TAHLIYE_VEK_UCR;
            projeTaraf.TAHLIYE_VEK_UCR_DOVIZ_ID = alacakNedenTaraf.TAHLIYE_VEK_UCR_DOVIZ_ID;
            projeTaraf.TAKIP_CIKISI = alacakNedenTaraf.TAKIP_CIKISI;
            projeTaraf.TAKIP_CIKISI_DOVIZ_ID = alacakNedenTaraf.TAKIP_CIKISI_DOVIZ_ID;
            projeTaraf.TAKIP_VEKALET_UCRETI = alacakNedenTaraf.TAKIP_VEKALET_UCRETI;
            projeTaraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID = alacakNedenTaraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID;
            projeTaraf.TAZMINATI = alacakNedenTaraf.TAZMINATI;
            projeTaraf.TAZMINATI_DOVIZ_ID = alacakNedenTaraf.TAZMINATI_DOVIZ_ID;
            projeTaraf.TD_BAKIYE_HARC = alacakNedenTaraf.TD_BAKIYE_HARC;
            projeTaraf.TD_BAKIYE_HARC_DOVIZ_ID = alacakNedenTaraf.TD_BAKIYE_HARC_DOVIZ_ID;
            projeTaraf.TD_GIDERI = alacakNedenTaraf.TD_GIDERI;
            projeTaraf.TD_GIDERI_DOVIZ_ID = alacakNedenTaraf.TD_GIDERI_DOVIZ_ID;
            projeTaraf.TD_TEBLIG_GIDERI = alacakNedenTaraf.TD_TEBLIG_GIDERI;
            projeTaraf.TD_TEBLIG_GIDERI_DOVIZ_ID = alacakNedenTaraf.TD_TEBLIG_GIDERI_DOVIZ_ID;
            projeTaraf.TD_VEK_UCR = alacakNedenTaraf.TD_VEK_UCR;
            projeTaraf.TD_VEK_UCR_DOVIZ_ID = alacakNedenTaraf.TD_VEK_UCR_DOVIZ_ID;
            projeTaraf.TO_MASRAF_TOPLAMI = alacakNedenTaraf.TO_MASRAF_TOPLAMI;
            projeTaraf.TO_MASRAF_TOPLAMI_DOVIZ_ID = alacakNedenTaraf.TO_MASRAF_TOPLAMI_DOVIZ_ID;
            projeTaraf.TO_ODEME_TOPLAMI = alacakNedenTaraf.TO_ODEME_TOPLAMI;
            projeTaraf.TO_ODEME_TOPLAMI_DOVIZ_ID = alacakNedenTaraf.TO_ODEME_TOPLAMI_DOVIZ_ID;
            projeTaraf.TO_VEKALET_TOPLAMI = alacakNedenTaraf.TO_VEKALET_TOPLAMI;
            projeTaraf.TO_VEKALET_TOPLAMI_DOVIZ_ID = alacakNedenTaraf.TO_VEKALET_TOPLAMI_DOVIZ_ID;
            projeTaraf.TS_MASRAF_TOPLAMI = alacakNedenTaraf.TS_MASRAF_TOPLAMI;
            projeTaraf.TS_MASRAF_TOPLAMI_DOVIZ_ID = alacakNedenTaraf.TS_MASRAF_TOPLAMI_DOVIZ_ID;
            projeTaraf.TS_VEKALET_TOPLAMI = alacakNedenTaraf.TS_VEKALET_TOPLAMI;
            projeTaraf.TS_VEKALET_TOPLAMI_DOVIZ_ID = alacakNedenTaraf.TS_VEKALET_TOPLAMI_DOVIZ_ID;
            projeTaraf.TUM_MASRAF_TOPLAMI = alacakNedenTaraf.TUM_MASRAF_TOPLAMI;
            projeTaraf.TUM_MASRAF_TOPLAMI_DOVIZ_ID = alacakNedenTaraf.TUM_MASRAF_TOPLAMI_DOVIZ_ID;
            projeTaraf.TUM_VEKALET_TOPLAMI = alacakNedenTaraf.TUM_VEKALET_TOPLAMI;
            projeTaraf.TUM_VEKALET_TOPLAMI_DOVIZ_ID = alacakNedenTaraf.TUM_VEKALET_TOPLAMI_DOVIZ_ID;

            #endregion Alanlar Eşitleniyor
        }

        private void TarafTutarlariniSifirla(AV001_TDIE_BIL_PROJE proje)
        {
            foreach (var trf in proje.AV001_TDIE_BIL_PROJE_TARAF_HESAPCollection)
            {
                trf.IHTAR_GIDERI_DOVIZ_ID = 1;
                trf.PROTESTO_GIDERI_DOVIZ_ID = 1;
                trf.TAZMINATI_DOVIZ_ID = 1;
                trf.CEK_TAZMINATI_DOVIZ_ID = 1;
                trf.KOMISYONU_DOVIZ_ID = 1;
                trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = 1;
                trf.ISLEMIS_FAIZ_DOVIZ_ID = 1;
                trf.ASIL_ALACAK_DOVIZ_ID = 1;
                trf.BSMV_TO_DOVIZ_ID = 1;
                trf.KKDV_TO_DOVIZ_ID = 1;
                trf.OIV_TO_DOVIZ_ID = 1;
                trf.KDV_TO_DOVIZ_ID = 1;
                trf.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = 1;
                trf.CEK_KOMISYONU_DOVIZ_ID = 1;
                trf.ILAM_YARGILAMA_GIDERI_DOVIZ_ID = 1;
                trf.ILAM_BK_YARG_ONAMA_DOVIZ_ID = 1;
                trf.ILAM_TEBLIG_GIDERI_DOVIZ_ID = 1;
                trf.ILAM_INKAR_TAZMINATI_DOVIZ_ID = 1;
                trf.ILAM_VEK_UCR_DOVIZ_ID = 1;
                trf.OZEL_TAZMINAT_DOVIZ_ID = 1;
                trf.OZEL_TUTAR1_DOVIZ_ID = 1;
                trf.OZEL_TUTAR2_DOVIZ_ID = 1;
                trf.OZEL_TUTAR3_DOVIZ_ID = 1;
                trf.TAKIP_CIKISI_DOVIZ_ID = 1;
                trf.SONRAKI_FAIZ_DOVIZ_ID = 1;
                trf.SONRAKI_TAZMINAT_DOVIZ_ID = 1;
                trf.BSMV_TS_DOVIZ_ID = 1;
                trf.OIV_TS_DOVIZ_ID = 1;
                trf.KDV_TS_DOVIZ_ID = 1;
                trf.ILK_GIDERLER_DOVIZ_ID = 1;
                trf.PESIN_HARC_DOVIZ_ID = 1;
                trf.ODENEN_TAHSIL_HARCI_DOVIZ_ID = 1;
                trf.KALAN_TAHSIL_HARCI_DOVIZ_ID = 1;
                trf.MASAYA_KATILMA_HARCI_DOVIZ_ID = 1;
                trf.PAYLASMA_HARCI_DOVIZ_ID = 1;
                trf.DAVA_GIDERLERI_DOVIZ_ID = 1;
                trf.DIGER_GIDERLER_DOVIZ_ID = 1;
                trf.TAKIP_VEKALET_UCRETI_DOVIZ_ID = 1;
                trf.DAVA_INKAR_TAZMINATI_DOVIZ_ID = 1;
                trf.DAVA_VEKALET_UCRETI_DOVIZ_ID = 1;
                trf.ODEME_TOPLAMI_DOVIZ_ID = 1;
                trf.TO_ODEME_TOPLAMI_DOVIZ_ID = 1;
                trf.MAHSUP_TOPLAMI_DOVIZ_ID = 1;
                trf.FERAGAT_TOPLAMI_DOVIZ_ID = 1;
                trf.ALACAK_TOPLAMI_DOVIZ_ID = 1;
                trf.KALAN_DOVIZ_ID = 1;
                trf.TAHLIYE_VEK_UCR_DOVIZ_ID = 1;
                trf.DIGER_HARC_DOVIZ_ID = 1;
                trf.TD_GIDERI_DOVIZ_ID = 1;
                trf.TD_BAKIYE_HARC_DOVIZ_ID = 1;
                trf.TD_VEK_UCR_DOVIZ_ID = 1;
                trf.TD_TEBLIG_GIDERI_DOVIZ_ID = 1;
                trf.BIRIKMIS_NAFAKA_DOVIZ_ID = 1;
                trf.ICRA_INKAR_TAZMINATI_DOVIZ_ID = 1;
                trf.DAMGA_PULU_DOVIZ_ID = 1;
                trf.PROTOKOL_MIKTARI_DOVIZ_ID = 1;
                trf.KARSILIK_TUTARI_DOVIZ_ID = 1;
                trf.HESAPLANMIS_FAIZ_DOVIZ_ID = 1;
                trf.HESAPLANMIS_KKDF_DOVIZ_ID = 1;
                trf.HESAPLANMIS_BSMV_DOVIZ_ID = 1;
                trf.HESAPLANMIS_KDV_DOVIZ_ID = 1;
                trf.HESAPLANMIS_OIV_DOVIZ_ID = 1;
                trf.TO_MASRAF_TOPLAMI_DOVIZ_ID = 1;
                trf.TS_MASRAF_TOPLAMI_DOVIZ_ID = 1;
                trf.TUM_MASRAF_TOPLAMI_DOVIZ_ID = 1;
                trf.HARC_TOPLAMI_DOVIZ_ID = 1;
                trf.TO_VEKALET_TOPLAMI_DOVIZ_ID = 1;
                trf.TS_VEKALET_TOPLAMI_DOVIZ_ID = 1;
                trf.TUM_VEKALET_TOPLAMI_DOVIZ_ID = 1;
                trf.KARSI_VEKALET_TOPLAMI_DOVIZ_ID = 1;
                trf.FAIZ_TOPLAMI_DOVIZ_ID = 1;
                trf.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID = 1;
                trf.IT_VEKALET_UCRETI_DOVIZ_ID = 1;
                trf.IT_GIDERI_DOVIZ_ID = 1;
                trf.IH_VEKALET_UCRETI_DOVIZ_ID = 1;
                trf.IH_GIDERI_DOVIZ_ID = 1;
                trf.IT_HACIZDE_ODENEN_DOVIZ_ID = 1;
                trf.BASVURMA_HARCI_DOVIZ_ID = 1;
                trf.VEKALET_HARCI_DOVIZ_ID = 1;
                trf.VEKALET_PULU_DOVIZ_ID = 1;
                trf.IFLAS_BASVURMA_HARCI_DOVIZ_ID = 1;
                trf.IFLASIN_ACILMASI_HARCI_DOVIZ_ID = 1;
                trf.ILK_TEBLIGAT_GIDERI_DOVIZ_ID = 1;
                trf.TAHLIYE_HARCI_DOVIZ_ID = 1;
                trf.TESLIM_HARCI_DOVIZ_ID = 1;
                trf.FERAGAT_HARCI_DOVIZ_ID = 1;
                trf.CEZA_EVI_HARCI_DOVIZ_ID = 1;
                trf.FERAGAT_ARTAN_DOVIZ_ID = 1;
                trf.TO_YONETIMG_TAZMINATI_DOVIZ_ID = 1;
                trf.TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = 1;
                trf.GAYRI_NAKTI_ALACAK_DOVIZ_ID = 1;
                trf.GAYRI_NAKTI_ALACAK_FAIZ_DOVIZ_ID = 1;
                trf.GAYRI_NAKITIN_TAZMININDEN_GELEN_ASIL_ALACAK_DOVIZ_ID = 1;
                trf.GAYRI_NAKITIN_TAZMININDEN_GELEN_ASIL_ALACAK_FAIZI_DOVIZ_ID = 1;
                trf.TAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID = 1;
                trf.GAYRI_NAKIT_KALAN_DOVIZ_ID = 1;
                trf.DEPO_VEKALET_UCRET_DOVIZ_ID = 1;
                trf.DEPO_HARCI_DOVIZ_ID = 1;
                trf.TS_MASRAF_HARC_TOPLAMI_DOVIZ_ID = 1;
                trf.RISK_MIKTARI_DOVIZ_ID = 1;
                trf.FAIZE_YAPILAN_TAHSILAT_DOVIZ_ID = 1;
                trf.ANA_PARAYA_YAPILAN_TAHSILAT_DOVIZ_ID = 1;
                trf.MASRAFA_YAPILAN_TAHSILAT_DOVIZ_ID = 1;
                trf.RISKTEN_KALAN_DOVIZ_ID = 1;
                trf.VEKALET_UCRETINDEN_ODENEN_DOVIZ_ID = 1;
                trf.TUM_ODEME_TOPLAMI_DOVIZ_ID = 1;
                trf.IHTAR_GIDERI = 0;
                trf.PROTESTO_GIDERI = 0;
                trf.TAZMINATI = 0;
                trf.CEK_TAZMINATI = 0;
                trf.KOMISYONU = 0;
                trf.SORUMLU_OLUNAN_MIKTAR = 0;
                trf.ISLEMIS_FAIZ = 0;
                trf.ASIL_ALACAK = 0;
                trf.BSMV_TO = 0;
                trf.KKDV_TO = 0;
                trf.OIV_TO = 0;
                trf.KDV_TO = 0;
                trf.KARSILIKSIZ_CEK_TAZMINATI = 0;
                trf.CEK_KOMISYONU = 0;
                trf.ILAM_YARGILAMA_GIDERI = 0;
                trf.ILAM_BK_YARG_ONAMA = 0;
                trf.ILAM_TEBLIG_GIDERI = 0;
                trf.ILAM_INKAR_TAZMINATI = 0;
                trf.ILAM_VEK_UCR = 0;
                trf.OZEL_TAZMINAT = 0;
                trf.OZEL_TUTAR1 = 0;
                trf.OZEL_TUTAR2 = 0;
                trf.OZEL_TUTAR3 = 0;
                trf.TAKIP_CIKISI = 0;
                trf.SONRAKI_FAIZ = 0;
                trf.SONRAKI_TAZMINAT = 0;
                trf.BSMV_TS = 0;
                trf.OIV_TS = 0;
                trf.KDV_TS = 0;
                trf.ILK_GIDERLER = 0;
                trf.PESIN_HARC = 0;
                trf.ODENEN_TAHSIL_HARCI = 0;
                trf.KALAN_TAHSIL_HARCI = 0;
                trf.MASAYA_KATILMA_HARCI = 0;
                trf.PAYLASMA_HARCI = 0;
                trf.DAVA_GIDERLERI = 0;
                trf.DIGER_GIDERLER = 0;
                trf.TAKIP_VEKALET_UCRETI = 0;
                trf.DAVA_INKAR_TAZMINATI = 0;
                trf.DAVA_VEKALET_UCRETI = 0;
                trf.ODEME_TOPLAMI = 0;
                trf.TO_ODEME_TOPLAMI = 0;
                trf.MAHSUP_TOPLAMI = 0;
                trf.FERAGAT_TOPLAMI = 0;
                trf.ALACAK_TOPLAMI = 0;
                trf.KALAN = 0;
                trf.TAHLIYE_VEK_UCR = 0;
                trf.DIGER_HARC = 0;
                trf.TD_GIDERI = 0;
                trf.TD_BAKIYE_HARC = 0;
                trf.TD_VEK_UCR = 0;
                trf.TD_TEBLIG_GIDERI = 0;
                trf.BIRIKMIS_NAFAKA = 0;
                trf.ICRA_INKAR_TAZMINATI = 0;
                trf.DAMGA_PULU = 0;
                trf.PROTOKOL_MIKTARI = 0;
                trf.KARSILIK_TUTARI = 0;
                trf.HESAPLANMIS_FAIZ = 0;
                trf.HESAPLANMIS_KKDF = 0;
                trf.HESAPLANMIS_BSMV = 0;
                trf.HESAPLANMIS_KDV = 0;
                trf.HESAPLANMIS_OIV = 0;
                trf.TO_MASRAF_TOPLAMI = 0;
                trf.TS_MASRAF_TOPLAMI = 0;
                trf.TUM_MASRAF_TOPLAMI = 0;
                trf.HARC_TOPLAMI = 0;
                trf.TO_VEKALET_TOPLAMI = 0;
                trf.TS_VEKALET_TOPLAMI = 0;
                trf.TUM_VEKALET_TOPLAMI = 0;
                trf.KARSI_VEKALET_TOPLAMI = 0;
                trf.FAIZ_TOPLAMI = 0;
                trf.ILAM_UCRETLER_TOPLAMI = 0;
                trf.IT_VEKALET_UCRETI = 0;
                trf.IT_GIDERI = 0;
                trf.IH_VEKALET_UCRETI = 0;
                trf.IH_GIDERI = 0;
                trf.IT_HACIZDE_ODENEN = 0;
                trf.BASVURMA_HARCI = 0;
                trf.VEKALET_HARCI = 0;
                trf.VEKALET_PULU = 0;
                trf.IFLAS_BASVURMA_HARCI = 0;
                trf.IFLASIN_ACILMASI_HARCI = 0;
                trf.ILK_TEBLIGAT_GIDERI = 0;
                trf.TAHLIYE_HARCI = 0;
                trf.TESLIM_HARCI = 0;
                trf.FERAGAT_HARCI = 0;
                trf.CEZA_EVI_HARCI = 0;
                trf.FERAGAT_ARTAN = 0;
                trf.TO_YONETIMG_TAZMINATI = 0;
                trf.TO_ODEME_MAHSUP_TOPLAMI = 0;
                trf.GAYRI_NAKTI_ALACAK = 0;
                trf.GAYRI_NAKTI_ALACAK_FAIZ = 0;
                trf.GAYRI_NAKITIN_TAZMININDEN_GELEN_ASIL_ALACAK = 0;
                trf.GAYRI_NAKITIN_TAZMININDEN_GELEN_ASIL_ALACAK_FAIZI = 0;
                trf.TAKIP_CIKIS_GAYRI_NAKIT = 0;
                trf.GAYRI_NAKIT_KALAN = 0;
                trf.DEPO_VEKALET_UCRETI = 0;
                trf.DEPO_HARCI = 0;
                trf.TS_MASRAF_HARC_TOPLAMI = 0;
                trf.RISK_MIKTARI = 0;
                trf.FAIZE_YAPILAN_TAHSILAT = 0;
                trf.ANA_PARAYA_YAPILAN_TAHSILAT = 0;
                trf.MASRAFA_YAPILAN_TAHSILAT = 0;
                trf.RISKTEN_KALAN = 0;
                trf.VEKALET_UCRETINDEN_ODENEN = 0;
                trf.TUM_ODEME_TOPLAMI = 0;
            }
        }

        /// <summary>
        /// Föyün üzerinde bulunan alacak nedenlerine bağlı tarafların hesaplarını proje üzerindeki
        /// taraf tablosunda toplar
        /// </summary>
        /// <param name="foy"></param>
        /// <param name="proje"></param>
        private void TarafTutarlariniTopla(AV001_TI_BIL_FOY foy, AV001_TDIE_BIL_PROJE proje)
        {
            TarafTutarlariniSifirla(proje);

            List<int> alacakliIDList = new List<int>();

            foreach (var aNeden in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                foreach (var anTaraf in aNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                {
                    if (anTaraf.TARAF_SIFAT_ID == 1)//Alacaklı sıfatındakiler gridde görünmeyecek. MB
                    {
                        //Liste eklenme sebebi : Takip açılınca taraflar silindiği için foreach içersinde taraf gelmiyo bu nedenle de gridde taraf görünmüyordu. Bu durumda tarafların proje taraflarından, sadece alacaklıların gelmesi için bu şekilde yapıldı. MB
                        if (!alacakliIDList.Contains(anTaraf.TARAF_CARI_ID))
                            alacakliIDList.Add(anTaraf.TARAF_CARI_ID);
                        continue;
                    }
                    var taraf = GetProjeTaraf(proje, anTaraf.TARAF_CARI_ID);

                    if (taraf.Tag == null)
                    {
                        SetProjeTaraf(taraf, anTaraf);
                        taraf.Tag = true;
                    }
                    else
                    {
                        ToplaProjeUzerineAlacakNedenTaraf(taraf, anTaraf);
                    }
                }
            }

            if (proje.AV001_TDIE_BIL_PROJE_TARAFCollection.Count == 0)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_TARAF>));
            //Alacak nedeni tarafları sıfırlandığında gride tarafların (alacaklı hariç) gelmesi sağlıyor. MB
            if (proje.AV001_TDIE_BIL_PROJE_TARAF_HESAPCollection.Count == 0 || proje.AV001_TDIE_BIL_PROJE_TARAF_HESAPCollection.Count != proje.AV001_TDIE_BIL_PROJE_TARAFCollection.Count - 1)
            {
                proje.AV001_TDIE_BIL_PROJE_TARAFCollection.ForEach(item =>
                    {
                        if (!alacakliIDList.Contains(item.CARI_ID))//Alacaklıların eklenmemesi kontrolü. MB
                        {
                            if (proje.AV001_TDIE_BIL_PROJE_TARAF_HESAPCollection.Find(vi => vi.CARI_ID == item.CARI_ID) == null)
                            {
                                AV001_TDIE_BIL_PROJE_TARAF_HESAP yeniTaraf = proje.AV001_TDIE_BIL_PROJE_TARAF_HESAPCollection.AddNew();
                                yeniTaraf.CARI_ID = item.CARI_ID;
                            }
                        }
                    });
            }
        }

        /// <summary>
        /// Mevcut proje tarafının üzerindeki değerlere alacak nedeni üzerindeki
        /// değerleri döviz toplam kurallarına uygun olarak ekler
        /// </summary>
        /// <param name="projeTaraf"></param>
        /// <param name="alacakNedenTaraf"></param>
        private void ToplaProjeUzerineAlacakNedenTaraf(AV001_TDIE_BIL_PROJE_TARAF_HESAP projeTaraf, AV001_TI_BIL_ALACAK_NEDEN_TARAF alacakNedenTaraf)
        {
            #region Tutarlar Toplanıyor

            var toplamASIL_ALACAK = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.ASIL_ALACAK, projeTaraf.ASIL_ALACAK_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.ASIL_ALACAK, alacakNedenTaraf.ASIL_ALACAK_DOVIZ_ID));
            var toplamBIRIKMIS_NAFAKA = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.BIRIKMIS_NAFAKA, projeTaraf.BIRIKMIS_NAFAKA_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.BIRIKMIS_NAFAKA, alacakNedenTaraf.BIRIKMIS_NAFAKA_DOVIZ_ID));
            var toplamBSMV_TO = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.BSMV_TO, projeTaraf.BSMV_TO_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.BSMV_TO, alacakNedenTaraf.BSMV_TO_DOVIZ_ID));
            var toplamBSMV_TS = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.BSMV_TS, projeTaraf.BSMV_TS_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.BSMV_TS, alacakNedenTaraf.BSMV_TS_DOVIZ_ID));
            var toplamCEK_KOMISYONU = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.CEK_KOMISYONU, projeTaraf.CEK_KOMISYONU_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.CEK_KOMISYONU, alacakNedenTaraf.CEK_KOMISYONU_DOVIZ_ID));
            var toplamCEK_TAZMINATI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.CEK_TAZMINATI, projeTaraf.CEK_TAZMINATI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.CEK_TAZMINATI, alacakNedenTaraf.CEK_TAZMINATI_DOVIZ_ID));
            var toplamDAMGA_PULU = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.DAMGA_PULU, projeTaraf.DAMGA_PULU_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.DAMGA_PULU, alacakNedenTaraf.DAMGA_PULU_DOVIZ_ID));
            var toplamDAVA_GIDERLERI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.DAVA_GIDERLERI, projeTaraf.DAVA_GIDERLERI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.DAVA_GIDERLERI, alacakNedenTaraf.DAVA_GIDERLERI_DOVIZ_ID));
            var toplamDAVA_INKAR_TAZMINATI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.DAVA_INKAR_TAZMINATI, projeTaraf.DAVA_INKAR_TAZMINATI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.DAVA_INKAR_TAZMINATI, alacakNedenTaraf.DAVA_INKAR_TAZMINATI_DOVIZ_ID));
            var toplamDAVA_VEKALET_UCRETI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.DAVA_VEKALET_UCRETI, projeTaraf.DAVA_VEKALET_UCRETI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.DAVA_VEKALET_UCRETI, alacakNedenTaraf.DAVA_VEKALET_UCRETI_DOVIZ_ID));
            var toplamDIGER_GIDERLER = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.DIGER_GIDERLER, projeTaraf.DIGER_GIDERLER_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.DIGER_GIDERLER, alacakNedenTaraf.DIGER_GIDERLER_DOVIZ_ID));
            var toplamDIGER_HARC = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.DIGER_HARC, projeTaraf.DIGER_HARC_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.DIGER_HARC, alacakNedenTaraf.DIGER_HARC_DOVIZ_ID));
            var toplamFAIZ_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.FAIZ_TOPLAMI, projeTaraf.FAIZ_TOPLAMI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.FAIZ_TOPLAMI, alacakNedenTaraf.FAIZ_TOPLAMI_DOVIZ_ID));
            var toplamFERAGAT_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.FERAGAT_TOPLAMI, projeTaraf.FERAGAT_TOPLAMI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.FERAGAT_TOPLAMI, alacakNedenTaraf.FERAGAT_TOPLAMI_DOVIZ_ID));
            var toplamHARC_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.HARC_TOPLAMI, projeTaraf.HARC_TOPLAMI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.HARC_TOPLAMI, alacakNedenTaraf.HARC_TOPLAMI_DOVIZ_ID));
            var toplamHESAPLANMIS_BSMV = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.HESAPLANMIS_BSMV, projeTaraf.HESAPLANMIS_BSMV_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.HESAPLANMIS_BSMV, alacakNedenTaraf.HESAPLANMIS_BSMV_DOVIZ_ID));
            var toplamHESAPLANMIS_FAIZ = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.HESAPLANMIS_FAIZ, projeTaraf.HESAPLANMIS_FAIZ_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.HESAPLANMIS_FAIZ, alacakNedenTaraf.HESAPLANMIS_FAIZ_DOVIZ_ID));
            var toplamHESAPLANMIS_KDV = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.HESAPLANMIS_KDV, projeTaraf.HESAPLANMIS_KDV_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.HESAPLANMIS_KDV, alacakNedenTaraf.HESAPLANMIS_KDV_DOVIZ_ID));
            var toplamHESAPLANMIS_KKDF = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.HESAPLANMIS_KKDF, projeTaraf.HESAPLANMIS_KKDF_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.HESAPLANMIS_KKDF, alacakNedenTaraf.HESAPLANMIS_KKDF_DOVIZ_ID));
            var toplamHESAPLANMIS_OIV = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.HESAPLANMIS_OIV, projeTaraf.HESAPLANMIS_OIV_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.HESAPLANMIS_OIV, alacakNedenTaraf.HESAPLANMIS_OIV_DOVIZ_ID));
            var toplamICRA_INKAR_TAZMINATI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.ICRA_INKAR_TAZMINATI, projeTaraf.ICRA_INKAR_TAZMINATI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.ICRA_INKAR_TAZMINATI, alacakNedenTaraf.ICRA_INKAR_TAZMINATI_DOVIZ_ID));
            var toplamIH_GIDERI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.IH_GIDERI, projeTaraf.IH_GIDERI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.IH_GIDERI, alacakNedenTaraf.IH_GIDERI_DOVIZ_ID));
            var toplamIH_VEKALET_UCRETI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.IH_VEKALET_UCRETI, projeTaraf.IH_VEKALET_UCRETI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.IH_VEKALET_UCRETI, alacakNedenTaraf.IH_VEKALET_UCRETI_DOVIZ_ID));
            var toplamIHTAR_GIDERI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.IHTAR_GIDERI, projeTaraf.IHTAR_GIDERI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.IHTAR_GIDERI, alacakNedenTaraf.IHTAR_GIDERI_DOVIZ_ID));
            var toplamILAM_BK_YARG_ONAMA = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.ILAM_BK_YARG_ONAMA, projeTaraf.ILAM_BK_YARG_ONAMA_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.ILAM_BK_YARG_ONAMA, alacakNedenTaraf.ILAM_BK_YARG_ONAMA_DOVIZ_ID));
            var toplamILAM_INKAR_TAZMINATI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.ILAM_INKAR_TAZMINATI, projeTaraf.ILAM_INKAR_TAZMINATI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.ILAM_INKAR_TAZMINATI, alacakNedenTaraf.ILAM_INKAR_TAZMINATI_DOVIZ_ID));
            var toplamILAM_TEBLIG_GIDERI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.ILAM_TEBLIG_GIDERI, projeTaraf.ILAM_TEBLIG_GIDERI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.ILAM_TEBLIG_GIDERI, alacakNedenTaraf.ILAM_TEBLIG_GIDERI_DOVIZ_ID));
            var toplamILAM_UCRETLER_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.ILAM_UCRETLER_TOPLAMI, projeTaraf.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.ILAM_UCRETLER_TOPLAMI, alacakNedenTaraf.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID));
            var toplamILAM_VEK_UCR = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.ILAM_VEK_UCR, projeTaraf.ILAM_VEK_UCR_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.ILAM_VEK_UCR, alacakNedenTaraf.ILAM_VEK_UCR_DOVIZ_ID));
            var toplamILAM_YARGILAMA_GIDERI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.ILAM_YARGILAMA_GIDERI, projeTaraf.ILAM_YARGILAMA_GIDERI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.ILAM_YARGILAMA_GIDERI, alacakNedenTaraf.ILAM_YARGILAMA_GIDERI_DOVIZ_ID));
            var toplamILK_GIDERLER = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.ILK_GIDERLER, projeTaraf.ILK_GIDERLER_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.ILK_GIDERLER, alacakNedenTaraf.ILK_GIDERLER_DOVIZ_ID));
            var toplamISLEMIS_FAIZ = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.ISLEMIS_FAIZ, projeTaraf.ISLEMIS_FAIZ_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.ISLEMIS_FAIZ, alacakNedenTaraf.ISLEMIS_FAIZ_DOVIZ_ID));
            var toplamIT_GIDERI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.IT_GIDERI, projeTaraf.IT_GIDERI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.IT_GIDERI, alacakNedenTaraf.IT_GIDERI_DOVIZ_ID));
            var toplamIT_HACIZDE_ODENEN = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.IT_HACIZDE_ODENEN, projeTaraf.IT_HACIZDE_ODENEN_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.IT_HACIZDE_ODENEN, alacakNedenTaraf.IT_HACIZDE_ODENEN_DOVIZ_ID));
            var toplamIT_VEKALET_UCRETI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.IT_VEKALET_UCRETI, projeTaraf.IT_VEKALET_UCRETI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.IT_VEKALET_UCRETI, alacakNedenTaraf.IT_VEKALET_UCRETI_DOVIZ_ID));
            var toplamKALAN = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.KALAN, projeTaraf.KALAN_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.KALAN, alacakNedenTaraf.KALAN_DOVIZ_ID));
            var toplamKALAN_TAHSIL_HARCI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.KALAN_TAHSIL_HARCI, projeTaraf.KALAN_TAHSIL_HARCI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.KALAN_TAHSIL_HARCI, alacakNedenTaraf.KALAN_TAHSIL_HARCI_DOVIZ_ID));
            var toplamKARSI_VEKALET_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.KARSI_VEKALET_TOPLAMI, projeTaraf.KARSI_VEKALET_TOPLAMI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.KARSI_VEKALET_TOPLAMI, alacakNedenTaraf.KARSI_VEKALET_TOPLAMI_DOVIZ_ID));
            var toplamKARSILIK_TUTARI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.KARSILIK_TUTARI, projeTaraf.KARSILIK_TUTARI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.KARSILIK_TUTARI, alacakNedenTaraf.KARSILIK_TUTARI_DOVIZ_ID));
            var toplamKARSILIKSIZ_CEK_TAZMINATI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.KARSILIKSIZ_CEK_TAZMINATI, projeTaraf.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.KARSILIKSIZ_CEK_TAZMINATI, alacakNedenTaraf.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID));
            var toplamKDV_TO = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.KDV_TO, projeTaraf.KDV_TO_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.KDV_TO, alacakNedenTaraf.KDV_TO_DOVIZ_ID));
            var toplamKDV_TS = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.KDV_TS, projeTaraf.KDV_TS_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.KDV_TS, alacakNedenTaraf.KDV_TS_DOVIZ_ID));
            var toplamKKDV_TO = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.KKDV_TO, projeTaraf.KKDV_TO_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.KKDV_TO, alacakNedenTaraf.KKDV_TO_DOVIZ_ID));
            var toplamKOMISYONU = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.KOMISYONU, projeTaraf.KOMISYONU_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.KOMISYONU, alacakNedenTaraf.KOMISYONU_DOVIZ_ID));
            var toplamMAHSUP_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.MAHSUP_TOPLAMI, projeTaraf.MAHSUP_TOPLAMI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.MAHSUP_TOPLAMI, alacakNedenTaraf.MAHSUP_TOPLAMI_DOVIZ_ID));
            var toplamMASAYA_KATILMA_HARCI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.MASAYA_KATILMA_HARCI, projeTaraf.MASAYA_KATILMA_HARCI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.MASAYA_KATILMA_HARCI, alacakNedenTaraf.MASAYA_KATILMA_HARCI_DOVIZ_ID));
            var toplamODEME_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.ODEME_TOPLAMI, projeTaraf.ODEME_TOPLAMI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.ODEME_TOPLAMI, alacakNedenTaraf.ODEME_TOPLAMI_DOVIZ_ID));
            var toplamODENEN_TAHSIL_HARCI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.ODENEN_TAHSIL_HARCI, projeTaraf.ODENEN_TAHSIL_HARCI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.ODENEN_TAHSIL_HARCI, alacakNedenTaraf.ODENEN_TAHSIL_HARCI_DOVIZ_ID));
            var toplamOIV_TO = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.OIV_TO, projeTaraf.OIV_TO_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.OIV_TO, alacakNedenTaraf.OIV_TO_DOVIZ_ID));
            var toplamOIV_TS = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.OIV_TS, projeTaraf.OIV_TS_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.OIV_TS, alacakNedenTaraf.OIV_TS_DOVIZ_ID));
            var toplamOZEL_TAZMINAT = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.OZEL_TAZMINAT, projeTaraf.OZEL_TAZMINAT_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.OZEL_TAZMINAT, alacakNedenTaraf.OZEL_TAZMINAT_DOVIZ_ID));
            var toplamOZEL_TUTAR1 = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.OZEL_TUTAR1, projeTaraf.OZEL_TUTAR1_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.OZEL_TUTAR1, alacakNedenTaraf.OZEL_TUTAR1_DOVIZ_ID));
            var toplamOZEL_TUTAR2 = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.OZEL_TUTAR2, projeTaraf.OZEL_TUTAR2_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.OZEL_TUTAR2, alacakNedenTaraf.OZEL_TUTAR2_DOVIZ_ID));
            var toplamOZEL_TUTAR3 = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.OZEL_TUTAR3, projeTaraf.OZEL_TUTAR3_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.OZEL_TUTAR3, alacakNedenTaraf.OZEL_TUTAR3_DOVIZ_ID));
            var toplamPAYLASMA_HARCI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.PAYLASMA_HARCI, projeTaraf.PAYLASMA_HARCI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.PAYLASMA_HARCI, alacakNedenTaraf.PAYLASMA_HARCI_DOVIZ_ID));
            var toplamPESIN_HARC = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.PESIN_HARC, projeTaraf.PESIN_HARC_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.PESIN_HARC, alacakNedenTaraf.PESIN_HARC_DOVIZ_ID));
            var toplamPROTESTO_GIDERI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.PROTESTO_GIDERI, projeTaraf.PROTESTO_GIDERI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.PROTESTO_GIDERI, alacakNedenTaraf.PROTESTO_GIDERI_DOVIZ_ID));
            var toplamPROTOKOL_MIKTARI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.PROTOKOL_MIKTARI, projeTaraf.PROTOKOL_MIKTARI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.PROTOKOL_MIKTARI, alacakNedenTaraf.PROTOKOL_MIKTARI_DOVIZ_ID));
            var toplamSONRAKI_FAIZ = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.SONRAKI_FAIZ, projeTaraf.SONRAKI_FAIZ_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.SONRAKI_FAIZ, alacakNedenTaraf.SONRAKI_FAIZ_DOVIZ_ID));
            var toplamSONRAKI_TAZMINAT = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.SONRAKI_TAZMINAT, projeTaraf.SONRAKI_TAZMINAT_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.SONRAKI_TAZMINAT, alacakNedenTaraf.SONRAKI_TAZMINAT_DOVIZ_ID));
            var toplamSORUMLU_OLUNAN_MIKTAR = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.SORUMLU_OLUNAN_MIKTAR, projeTaraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.SORUMLU_OLUNAN_MIKTAR, alacakNedenTaraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID));
            var toplamTAHLIYE_VEK_UCR = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.TAHLIYE_VEK_UCR, projeTaraf.TAHLIYE_VEK_UCR_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.TAHLIYE_VEK_UCR, alacakNedenTaraf.TAHLIYE_VEK_UCR_DOVIZ_ID));
            var toplamTAKIP_CIKISI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.TAKIP_CIKISI, projeTaraf.TAKIP_CIKISI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.TAKIP_CIKISI, alacakNedenTaraf.TAKIP_CIKISI_DOVIZ_ID));
            var toplamTAKIP_VEKALET_UCRETI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.TAKIP_VEKALET_UCRETI, projeTaraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.TAKIP_VEKALET_UCRETI, alacakNedenTaraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID));
            var toplamTAZMINATI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.TAZMINATI, projeTaraf.TAZMINATI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.TAZMINATI, alacakNedenTaraf.TAZMINATI_DOVIZ_ID));
            var toplamTD_BAKIYE_HARC = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.TD_BAKIYE_HARC, projeTaraf.TD_BAKIYE_HARC_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.TD_BAKIYE_HARC, alacakNedenTaraf.TD_BAKIYE_HARC_DOVIZ_ID));
            var toplamTD_GIDERI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.TD_GIDERI, projeTaraf.TD_GIDERI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.TD_GIDERI, alacakNedenTaraf.TD_GIDERI_DOVIZ_ID));
            var toplamTD_TEBLIG_GIDERI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.TD_TEBLIG_GIDERI, projeTaraf.TD_TEBLIG_GIDERI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.TD_TEBLIG_GIDERI, alacakNedenTaraf.TD_TEBLIG_GIDERI_DOVIZ_ID));
            var toplamTD_VEK_UCR = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.TD_VEK_UCR, projeTaraf.TD_VEK_UCR_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.TD_VEK_UCR, alacakNedenTaraf.TD_VEK_UCR_DOVIZ_ID));
            var toplamTO_MASRAF_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.TO_MASRAF_TOPLAMI, projeTaraf.TO_MASRAF_TOPLAMI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.TO_MASRAF_TOPLAMI, alacakNedenTaraf.TO_MASRAF_TOPLAMI_DOVIZ_ID));
            var toplamTO_ODEME_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.TO_ODEME_TOPLAMI, projeTaraf.TO_ODEME_TOPLAMI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.TO_ODEME_TOPLAMI, alacakNedenTaraf.TO_ODEME_TOPLAMI_DOVIZ_ID));
            var toplamTO_VEKALET_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.TO_VEKALET_TOPLAMI, projeTaraf.TO_VEKALET_TOPLAMI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.TO_VEKALET_TOPLAMI, alacakNedenTaraf.TO_VEKALET_TOPLAMI_DOVIZ_ID));
            var toplamTS_MASRAF_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.TS_MASRAF_TOPLAMI, projeTaraf.TS_MASRAF_TOPLAMI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.TS_MASRAF_TOPLAMI, alacakNedenTaraf.TS_MASRAF_TOPLAMI_DOVIZ_ID));
            var toplamTS_VEKALET_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.TS_VEKALET_TOPLAMI, projeTaraf.TS_VEKALET_TOPLAMI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.TS_VEKALET_TOPLAMI, alacakNedenTaraf.TS_VEKALET_TOPLAMI_DOVIZ_ID));
            var toplamTUM_MASRAF_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.TUM_MASRAF_TOPLAMI, projeTaraf.TUM_MASRAF_TOPLAMI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.TUM_MASRAF_TOPLAMI, alacakNedenTaraf.TUM_MASRAF_TOPLAMI_DOVIZ_ID));
            var toplamTUM_VEKALET_TOPLAMI = ParaVeDovizId.Topla(new ParaVeDovizId(projeTaraf.TUM_VEKALET_TOPLAMI, projeTaraf.TUM_VEKALET_TOPLAMI_DOVIZ_ID), new ParaVeDovizId(alacakNedenTaraf.TUM_VEKALET_TOPLAMI, alacakNedenTaraf.TUM_VEKALET_TOPLAMI_DOVIZ_ID));

            #endregion Tutarlar Toplanıyor

            #region Toplamlar Proje Taraf üzerine yazılıyor

            projeTaraf.ASIL_ALACAK = toplamASIL_ALACAK.Para;
            projeTaraf.ASIL_ALACAK_DOVIZ_ID = toplamASIL_ALACAK.DovizId;
            projeTaraf.BIRIKMIS_NAFAKA = toplamBIRIKMIS_NAFAKA.Para;
            projeTaraf.BIRIKMIS_NAFAKA_DOVIZ_ID = toplamBIRIKMIS_NAFAKA.DovizId;
            projeTaraf.BSMV_TO = toplamBSMV_TO.Para;
            projeTaraf.BSMV_TO_DOVIZ_ID = toplamBSMV_TO.DovizId;
            projeTaraf.BSMV_TS = toplamBSMV_TS.Para;
            projeTaraf.BSMV_TS_DOVIZ_ID = toplamBSMV_TS.DovizId;
            projeTaraf.CEK_KOMISYONU = toplamCEK_KOMISYONU.Para;
            projeTaraf.CEK_KOMISYONU_DOVIZ_ID = toplamCEK_KOMISYONU.DovizId;
            projeTaraf.CEK_TAZMINATI = toplamCEK_TAZMINATI.Para;
            projeTaraf.CEK_TAZMINATI_DOVIZ_ID = toplamCEK_TAZMINATI.DovizId;
            projeTaraf.DAMGA_PULU = toplamDAMGA_PULU.Para;
            projeTaraf.DAMGA_PULU_DOVIZ_ID = toplamDAMGA_PULU.DovizId;
            projeTaraf.DAVA_GIDERLERI = toplamDAVA_GIDERLERI.Para;
            projeTaraf.DAVA_GIDERLERI_DOVIZ_ID = toplamDAVA_GIDERLERI.DovizId;
            projeTaraf.DAVA_INKAR_TAZMINATI = toplamDAVA_INKAR_TAZMINATI.Para;
            projeTaraf.DAVA_INKAR_TAZMINATI_DOVIZ_ID = toplamDAVA_INKAR_TAZMINATI.DovizId;
            projeTaraf.DAVA_VEKALET_UCRETI = toplamDAVA_VEKALET_UCRETI.Para;
            projeTaraf.DAVA_VEKALET_UCRETI_DOVIZ_ID = toplamDAVA_VEKALET_UCRETI.DovizId;
            projeTaraf.DIGER_GIDERLER = toplamDIGER_GIDERLER.Para;
            projeTaraf.DIGER_GIDERLER_DOVIZ_ID = toplamDIGER_GIDERLER.DovizId;
            projeTaraf.DIGER_HARC = toplamDIGER_HARC.Para;
            projeTaraf.DIGER_HARC_DOVIZ_ID = toplamDIGER_HARC.DovizId;
            projeTaraf.FAIZ_TOPLAMI = toplamFAIZ_TOPLAMI.Para;
            projeTaraf.FAIZ_TOPLAMI_DOVIZ_ID = toplamFAIZ_TOPLAMI.DovizId;
            projeTaraf.FERAGAT_TOPLAMI = toplamFERAGAT_TOPLAMI.Para;
            projeTaraf.FERAGAT_TOPLAMI_DOVIZ_ID = toplamFERAGAT_TOPLAMI.DovizId;
            projeTaraf.HARC_TOPLAMI = toplamHARC_TOPLAMI.Para;
            projeTaraf.HARC_TOPLAMI_DOVIZ_ID = toplamHARC_TOPLAMI.DovizId;
            projeTaraf.HESAPLANMIS_BSMV = toplamHESAPLANMIS_BSMV.Para;
            projeTaraf.HESAPLANMIS_BSMV_DOVIZ_ID = toplamHESAPLANMIS_BSMV.DovizId;
            projeTaraf.HESAPLANMIS_FAIZ = toplamHESAPLANMIS_FAIZ.Para;
            projeTaraf.HESAPLANMIS_FAIZ_DOVIZ_ID = toplamHESAPLANMIS_FAIZ.DovizId;
            projeTaraf.HESAPLANMIS_KDV = toplamHESAPLANMIS_KDV.Para;
            projeTaraf.HESAPLANMIS_KDV_DOVIZ_ID = toplamHESAPLANMIS_KDV.DovizId;
            projeTaraf.HESAPLANMIS_KKDF = toplamHESAPLANMIS_KKDF.Para;
            projeTaraf.HESAPLANMIS_KKDF_DOVIZ_ID = toplamHESAPLANMIS_KKDF.DovizId;
            projeTaraf.HESAPLANMIS_OIV = toplamHESAPLANMIS_OIV.Para;
            projeTaraf.HESAPLANMIS_OIV_DOVIZ_ID = toplamHESAPLANMIS_OIV.DovizId;
            projeTaraf.ICRA_INKAR_TAZMINATI = toplamICRA_INKAR_TAZMINATI.Para;
            projeTaraf.ICRA_INKAR_TAZMINATI_DOVIZ_ID = toplamICRA_INKAR_TAZMINATI.DovizId;
            projeTaraf.IH_GIDERI = toplamIH_GIDERI.Para;
            projeTaraf.IH_GIDERI_DOVIZ_ID = toplamIH_GIDERI.DovizId;
            projeTaraf.IH_VEKALET_UCRETI = toplamIH_VEKALET_UCRETI.Para;
            projeTaraf.IH_VEKALET_UCRETI_DOVIZ_ID = toplamIH_VEKALET_UCRETI.DovizId;
            projeTaraf.IHTAR_GIDERI = toplamIHTAR_GIDERI.Para;
            projeTaraf.IHTAR_GIDERI_DOVIZ_ID = toplamIHTAR_GIDERI.DovizId;
            projeTaraf.ILAM_BK_YARG_ONAMA = toplamILAM_BK_YARG_ONAMA.Para;
            projeTaraf.ILAM_BK_YARG_ONAMA_DOVIZ_ID = toplamILAM_BK_YARG_ONAMA.DovizId;
            projeTaraf.ILAM_INKAR_TAZMINATI = toplamILAM_INKAR_TAZMINATI.Para;
            projeTaraf.ILAM_INKAR_TAZMINATI_DOVIZ_ID = toplamILAM_INKAR_TAZMINATI.DovizId;
            projeTaraf.ILAM_TEBLIG_GIDERI = toplamILAM_TEBLIG_GIDERI.Para;
            projeTaraf.ILAM_TEBLIG_GIDERI_DOVIZ_ID = toplamILAM_TEBLIG_GIDERI.DovizId;
            projeTaraf.ILAM_UCRETLER_TOPLAMI = toplamILAM_UCRETLER_TOPLAMI.Para;
            projeTaraf.ILAM_UCRETLER_TOPLAMI_DOVIZ_ID = toplamILAM_UCRETLER_TOPLAMI.DovizId;
            projeTaraf.ILAM_VEK_UCR = toplamILAM_VEK_UCR.Para;
            projeTaraf.ILAM_VEK_UCR_DOVIZ_ID = toplamILAM_VEK_UCR.DovizId;
            projeTaraf.ILAM_YARGILAMA_GIDERI = toplamILAM_YARGILAMA_GIDERI.Para;
            projeTaraf.ILAM_YARGILAMA_GIDERI_DOVIZ_ID = toplamILAM_YARGILAMA_GIDERI.DovizId;
            projeTaraf.ILK_GIDERLER = toplamILK_GIDERLER.Para;
            projeTaraf.ILK_GIDERLER_DOVIZ_ID = toplamILK_GIDERLER.DovizId;
            projeTaraf.ISLEMIS_FAIZ = toplamISLEMIS_FAIZ.Para;
            projeTaraf.ISLEMIS_FAIZ_DOVIZ_ID = toplamISLEMIS_FAIZ.DovizId;
            projeTaraf.IT_GIDERI = toplamIT_GIDERI.Para;
            projeTaraf.IT_GIDERI_DOVIZ_ID = toplamIT_GIDERI.DovizId;
            projeTaraf.IT_HACIZDE_ODENEN = toplamIT_HACIZDE_ODENEN.Para;
            projeTaraf.IT_HACIZDE_ODENEN_DOVIZ_ID = toplamIT_HACIZDE_ODENEN.DovizId;
            projeTaraf.IT_VEKALET_UCRETI = toplamIT_VEKALET_UCRETI.Para;
            projeTaraf.IT_VEKALET_UCRETI_DOVIZ_ID = toplamIT_VEKALET_UCRETI.DovizId;
            projeTaraf.KALAN = toplamKALAN.Para;
            projeTaraf.KALAN_DOVIZ_ID = toplamKALAN.DovizId;
            projeTaraf.KALAN_TAHSIL_HARCI = toplamKALAN_TAHSIL_HARCI.Para;
            projeTaraf.KALAN_TAHSIL_HARCI_DOVIZ_ID = toplamKALAN_TAHSIL_HARCI.DovizId;
            projeTaraf.KARSI_VEKALET_TOPLAMI = toplamKARSI_VEKALET_TOPLAMI.Para;
            projeTaraf.KARSI_VEKALET_TOPLAMI_DOVIZ_ID = toplamKARSI_VEKALET_TOPLAMI.DovizId;
            projeTaraf.KARSILIK_TUTARI = toplamKARSILIK_TUTARI.Para;
            projeTaraf.KARSILIK_TUTARI_DOVIZ_ID = toplamKARSILIK_TUTARI.DovizId;
            projeTaraf.KARSILIKSIZ_CEK_TAZMINATI = toplamKARSILIKSIZ_CEK_TAZMINATI.Para;
            projeTaraf.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = toplamKARSILIKSIZ_CEK_TAZMINATI.DovizId;
            projeTaraf.KDV_TO = toplamKDV_TO.Para;
            projeTaraf.KDV_TO_DOVIZ_ID = toplamKDV_TO.DovizId;
            projeTaraf.KDV_TS = toplamKDV_TS.Para;
            projeTaraf.KDV_TS_DOVIZ_ID = toplamKDV_TS.DovizId;
            projeTaraf.KKDV_TO = toplamKKDV_TO.Para;
            projeTaraf.KKDV_TO_DOVIZ_ID = toplamKKDV_TO.DovizId;
            projeTaraf.KOMISYONU = toplamKOMISYONU.Para;
            projeTaraf.KOMISYONU_DOVIZ_ID = toplamKOMISYONU.DovizId;
            projeTaraf.MAHSUP_TOPLAMI = toplamMAHSUP_TOPLAMI.Para;
            projeTaraf.MAHSUP_TOPLAMI_DOVIZ_ID = toplamMAHSUP_TOPLAMI.DovizId;
            projeTaraf.MASAYA_KATILMA_HARCI = toplamMASAYA_KATILMA_HARCI.Para;
            projeTaraf.MASAYA_KATILMA_HARCI_DOVIZ_ID = toplamMASAYA_KATILMA_HARCI.DovizId;
            projeTaraf.ODEME_TOPLAMI = toplamODEME_TOPLAMI.Para;
            projeTaraf.ODEME_TOPLAMI_DOVIZ_ID = toplamODEME_TOPLAMI.DovizId;
            projeTaraf.ODENEN_TAHSIL_HARCI = toplamODENEN_TAHSIL_HARCI.Para;
            projeTaraf.ODENEN_TAHSIL_HARCI_DOVIZ_ID = toplamODENEN_TAHSIL_HARCI.DovizId;
            projeTaraf.OIV_TO = toplamOIV_TO.Para;
            projeTaraf.OIV_TO_DOVIZ_ID = toplamOIV_TO.DovizId;
            projeTaraf.OIV_TS = toplamOIV_TS.Para;
            projeTaraf.OIV_TS_DOVIZ_ID = toplamOIV_TS.DovizId;
            projeTaraf.OZEL_TAZMINAT = toplamOZEL_TAZMINAT.Para;
            projeTaraf.OZEL_TAZMINAT_DOVIZ_ID = toplamOZEL_TAZMINAT.DovizId;
            projeTaraf.OZEL_TUTAR1 = toplamOZEL_TUTAR1.Para;
            projeTaraf.OZEL_TUTAR1_DOVIZ_ID = toplamOZEL_TUTAR1.DovizId;
            projeTaraf.OZEL_TUTAR2 = toplamOZEL_TUTAR2.Para;
            projeTaraf.OZEL_TUTAR2_DOVIZ_ID = toplamOZEL_TUTAR2.DovizId;
            projeTaraf.OZEL_TUTAR3 = toplamOZEL_TUTAR3.Para;
            projeTaraf.OZEL_TUTAR3_DOVIZ_ID = toplamOZEL_TUTAR3.DovizId;
            projeTaraf.PAYLASMA_HARCI = toplamPAYLASMA_HARCI.Para;
            projeTaraf.PAYLASMA_HARCI_DOVIZ_ID = toplamPAYLASMA_HARCI.DovizId;
            projeTaraf.PESIN_HARC = toplamPESIN_HARC.Para;
            projeTaraf.PESIN_HARC_DOVIZ_ID = toplamPESIN_HARC.DovizId;
            projeTaraf.PROTESTO_GIDERI = toplamPROTESTO_GIDERI.Para;
            projeTaraf.PROTESTO_GIDERI_DOVIZ_ID = toplamPROTESTO_GIDERI.DovizId;
            projeTaraf.PROTOKOL_MIKTARI = toplamPROTOKOL_MIKTARI.Para;
            projeTaraf.PROTOKOL_MIKTARI_DOVIZ_ID = toplamPROTOKOL_MIKTARI.DovizId;
            projeTaraf.SONRAKI_FAIZ = toplamSONRAKI_FAIZ.Para;
            projeTaraf.SONRAKI_FAIZ_DOVIZ_ID = toplamSONRAKI_FAIZ.DovizId;
            projeTaraf.SONRAKI_TAZMINAT = toplamSONRAKI_TAZMINAT.Para;
            projeTaraf.SONRAKI_TAZMINAT_DOVIZ_ID = toplamSONRAKI_TAZMINAT.DovizId;
            projeTaraf.SORUMLU_OLUNAN_MIKTAR = toplamSORUMLU_OLUNAN_MIKTAR.Para;
            projeTaraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = toplamSORUMLU_OLUNAN_MIKTAR.DovizId;
            projeTaraf.TAHLIYE_VEK_UCR = toplamTAHLIYE_VEK_UCR.Para;
            projeTaraf.TAHLIYE_VEK_UCR_DOVIZ_ID = toplamTAHLIYE_VEK_UCR.DovizId;
            projeTaraf.TAKIP_CIKISI = toplamTAKIP_CIKISI.Para;
            projeTaraf.TAKIP_CIKISI_DOVIZ_ID = toplamTAKIP_CIKISI.DovizId;
            projeTaraf.TAKIP_VEKALET_UCRETI = toplamTAKIP_VEKALET_UCRETI.Para;
            projeTaraf.TAKIP_VEKALET_UCRETI_DOVIZ_ID = toplamTAKIP_VEKALET_UCRETI.DovizId;
            projeTaraf.TAZMINATI = toplamTAZMINATI.Para;
            projeTaraf.TAZMINATI_DOVIZ_ID = toplamTAZMINATI.DovizId;
            projeTaraf.TD_BAKIYE_HARC = toplamTD_BAKIYE_HARC.Para;
            projeTaraf.TD_BAKIYE_HARC_DOVIZ_ID = toplamTD_BAKIYE_HARC.DovizId;
            projeTaraf.TD_GIDERI = toplamTD_GIDERI.Para;
            projeTaraf.TD_GIDERI_DOVIZ_ID = toplamTD_GIDERI.DovizId;
            projeTaraf.TD_TEBLIG_GIDERI = toplamTD_TEBLIG_GIDERI.Para;
            projeTaraf.TD_TEBLIG_GIDERI_DOVIZ_ID = toplamTD_TEBLIG_GIDERI.DovizId;
            projeTaraf.TD_VEK_UCR = toplamTD_VEK_UCR.Para;
            projeTaraf.TD_VEK_UCR_DOVIZ_ID = toplamTD_VEK_UCR.DovizId;
            projeTaraf.TO_MASRAF_TOPLAMI = toplamTO_MASRAF_TOPLAMI.Para;
            projeTaraf.TO_MASRAF_TOPLAMI_DOVIZ_ID = toplamTO_MASRAF_TOPLAMI.DovizId;
            projeTaraf.TO_ODEME_TOPLAMI = toplamTO_ODEME_TOPLAMI.Para;
            projeTaraf.TO_ODEME_TOPLAMI_DOVIZ_ID = toplamTO_ODEME_TOPLAMI.DovizId;
            projeTaraf.TO_VEKALET_TOPLAMI = toplamTO_VEKALET_TOPLAMI.Para;
            projeTaraf.TO_VEKALET_TOPLAMI_DOVIZ_ID = toplamTO_VEKALET_TOPLAMI.DovizId;
            projeTaraf.TS_MASRAF_TOPLAMI = toplamTS_MASRAF_TOPLAMI.Para;
            projeTaraf.TS_MASRAF_TOPLAMI_DOVIZ_ID = toplamTS_MASRAF_TOPLAMI.DovizId;
            projeTaraf.TS_VEKALET_TOPLAMI = toplamTS_VEKALET_TOPLAMI.Para;
            projeTaraf.TS_VEKALET_TOPLAMI_DOVIZ_ID = toplamTS_VEKALET_TOPLAMI.DovizId;
            projeTaraf.TUM_MASRAF_TOPLAMI = toplamTUM_MASRAF_TOPLAMI.Para;
            projeTaraf.TUM_MASRAF_TOPLAMI_DOVIZ_ID = toplamTUM_MASRAF_TOPLAMI.DovizId;
            projeTaraf.TUM_VEKALET_TOPLAMI = toplamTUM_VEKALET_TOPLAMI.Para;
            projeTaraf.TUM_VEKALET_TOPLAMI_DOVIZ_ID = toplamTUM_VEKALET_TOPLAMI.DovizId;

            #endregion Toplamlar Proje Taraf üzerine yazılıyor
        }

        #endregion Tools
    }
}