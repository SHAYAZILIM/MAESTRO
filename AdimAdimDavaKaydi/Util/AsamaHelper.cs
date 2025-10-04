using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AvukatProLib.Extras;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Util
{
    public class AsamaHelper
    {
        public static TList<AV001_TDIE_BIL_ASAMA> AsamalariGetir(IOrtakAlanli entity)
        {
            TList<AV001_TDIE_BIL_ASAMA> result =
                AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_ASAMAProvider.GetByKAYNAK_KAYIT_IDKAYNAK_TABLO_ADI(
                    entity.ID, entity.TableName);
            return result;
        }

        public static bool BuAsamaOncedenVarmi(int asamaKodId, int altAsamaKodId, IOrtakAlanli entity)
        {
            TList<AV001_TDIE_BIL_ASAMA> olanlar = AsamalariGetir(entity);
            if (olanlar.Count == 0) return false;

            bool result = false;

            foreach (AV001_TDIE_BIL_ASAMA asama in olanlar)
            {
                if ((asama.ASAMA_ALT_KOD_ID.HasValue && asama.ASAMA_ALT_KOD_ID.Value == altAsamaKodId) &&
                    asama.ASAMA_KOD_ID == asamaKodId)
                    result = true;
            }
            return result;
        }

        public static bool AsamaVarmi(int asamaKodId, int altAsamaKodId, EntityBase entity)
        {
            bool result = false;
            if (entity.MyAsamaList != null)
                foreach (AV001_TDIE_BIL_ASAMA asama in entity.MyAsamaList)
                {
                    if (asama.ASAMA_ALT_KOD_ID.HasValue && asama.ASAMA_ALT_KOD_ID.Value == altAsamaKodId &&
                        asama.ASAMA_KOD_ID == asamaKodId)
                        result = true;
                }
            return result;
        }

        public static void IlkTebligatAsamaHallet(AV001_TD_BIL_FOY mFoy)
        {
            #region AsamaKayidi

            TList<TDIE_KOD_ASAMA_ILISKI> asama_ILISKIS =
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI(mFoy.TableName);

            if (mFoy.AV001_TDIE_BIL_ASAMACollection.Count == 0)
                mFoy.AV001_TDIE_BIL_ASAMACollection = new TList<AV001_TDIE_BIL_ASAMA>();

            foreach (string str in mFoy.ChangedProperties)
            {
                TList<TDIE_KOD_ASAMA_ILISKI> iliskiS =
                    asama_ILISKIS.FindAll(delegate(TDIE_KOD_ASAMA_ILISKI obj) { return obj.SUTUN_ADI.Contains(str); });

                foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskiS)
                {
                    if (iliski != null && iliski.ASAMA_URETSIN_MI)
                    {
                        #region Dava Neden Bazýnda Aþama Üretimi

                        foreach (AV001_TD_BIL_DAVA_NEDEN ndn in mFoy.AV001_TD_BIL_DAVA_NEDENCollection)
                        {
                            AV001_TDIE_BIL_ASAMA asm =
                                ndn.AV001_TDIE_BIL_ASAMACollection.Find(AV001_TDIE_BIL_ASAMAColumn.ASAMA_ALT_KOD_ID,
                                                                        iliski.ALT_ASAMA_KOD_ID.Value);
                            if (asm != null)
                            {
                                mFoy.AsamaDoldur(asm);
                                asm.ASAMA_ACIKLAMA = iliski.AsamaAciklamaGetir(mFoy);
                                asm.ASAMA_TARIHI = iliski.AsamaTarihGetir(mFoy);
                            }
                            else
                            {
                                if (iliski.ALT_ASAMA_KOD_IDSource == null)
                                    iliski.ALT_ASAMA_KOD_IDSource =
                                        DataRepository.TDIE_KOD_ASAMA_ALTProvider.GetByID(iliski.ALT_ASAMA_KOD_ID.Value);

                                AV001_TDIE_BIL_ASAMA asama = mFoy.AsamaGetir();
                                asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID.Value;
                                asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;
                                asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
                                asama.ASAMA_ACIKLAMA = iliski.AsamaAciklamaGetir(mFoy);
                                asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(mFoy);

                                foreach (
                                    AV001_TD_BIL_DAVA_NEDEN_TARAF taraf in ndn.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection)
                                {
                                    AV001_TDIE_BIL_ASAMA_TARAF trf = asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                                    if (taraf.TARAF_SIFAT_ID.HasValue && taraf.TARAF_CARI_ID > 0)
                                    {
                                        trf.CARI_ID = taraf.TARAF_CARI_ID;
                                        trf.SIFAT_ID = taraf.TARAF_SIFAT_ID.Value;
                                        AV001_TD_BIL_FOY_TARAF foy_TARAF =
                                            mFoy.AV001_TD_BIL_FOY_TARAFCollection.Find("CARI_ID", taraf.TARAF_CARI_ID);

                                        if (foy_TARAF != null)
                                            trf.KODU = ((TarafKodu)foy_TARAF.TARAF_KODU).ToString().Substring(0, 1);

                                        trf.ASAMAYI_YAPAN_MI = foy_TARAF.DAVA_EDEN_MI;
                                    }
                                }
                                foreach (
                                    AV001_TD_BIL_FOY_SORUMLU_AVUKAT avukat in
                                        mFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection)
                                {
                                    AV001_TDIE_BIL_ASAMA_SORUMLU srm =
                                        asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.AddNew();
                                    srm.CARI_ID = avukat.SORUMLU_AVUKAT_CARI_ID.Value;
                                }
                                mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                                //mFoy.ASAMA_IDSource = asama;
                                ndn.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                            }
                        }

                        #endregion
                    }

                    #region Ýlk tebligat üretimi

                    if (iliski != null && iliski.TEBLIGAT_URETSIN_MI && iliski.TEBLIGAT_KONU_ID.HasValue
                        && mFoy.DAVA_TIP_ID.HasValue && iliski.AsamaDegerKarsilastir(mFoy))
                    {
                        AV001_TDI_BIL_TEBLIGAT tebl =
                            mFoy.AV001_TDI_BIL_TEBLIGATCollection.Find(AV001_TDI_BIL_TEBLIGATColumn.KONU_ID,iliski.TEBLIGAT_KONU_ID.Value);
                        if (tebl != null)
                        {
                            tebl.ADLI_BIRIM_ADLIYE_ID = mFoy.ADLI_BIRIM_ADLIYE_ID;
                            tebl.ADLI_BIRIM_GOREV_ID = mFoy.ADLI_BIRIM_GOREV_ID;
                            tebl.ADLI_BIRIM_NO_ID = mFoy.ADLI_BIRIM_NO_ID;
                            tebl.DAVA_FOY_ID = mFoy.ID;
                            tebl.TEBLIGAT_HEDEF_TIP = 2;
                            tebl.TEBLIGAT_ESAS_NO = mFoy.ESAS_NO;

                            tebl.ACIKLAMA = iliski.AsamaAciklamaGetir(mFoy);
                            tebl.KONU_ID = iliski.TEBLIGAT_KONU_ID.Value;
                            if (iliski.TEBLIGAT_KONU_IDSource == null)
                                iliski.TEBLIGAT_KONU_IDSource =
                                    DataRepository.TDI_KOD_TEBLIGAT_KONUProvider.GetByID(iliski.TEBLIGAT_KONU_ID.Value);

                            //TODO: Yukarýdaki yer bugünü kurtarmak için yapýlmýþ olup acilen deðiþtirilmesi gerekmektedir.
                            if (iliski.TEBLIGAT_KONU_IDSource.ILK_TEBLIGAT_MI)
                            {
                                tebl.HAZIRLAMA_TARIH = mFoy.DAVA_TARIHI.Value;
                                tebl.POSTALANMA_TARIH = mFoy.DAVA_TARIHI.Value;
                                tebl.HAZIRLAYAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
                                //tebl.KAYIT_TARIHI = DataTime.Now;
                                tebl.KONTROL_NE_ZAMAN = DateTime.Now;
                                tebl.KONTROL_VERSIYON++;
                                tebl.DAVA_ILK_TEBLIGAT_MI = true;
                                tebl.ANA_TUR_ID = iliski.TEBLIGAT_KONU_IDSource.ANA_TUR_ID;
                                tebl.ALT_TUR_ID = iliski.TEBLIGAT_KONU_IDSource.ALT_TUR_ID;
                                tebl.MUHASEBE_ALT_KATEGORI_ID = (int)MuhasebeAltKategoriId.iLK_TEBLiGAT_GiDERi;
                                //TODO:Enum
                                tebl.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Clear();
                                tebl.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Clear();
                                foreach (AV001_TD_BIL_FOY_TARAF taraf in mFoy.AV001_TD_BIL_FOY_TARAFCollection)
                                {
                                    if (!taraf.DAVA_EDEN_MI) //Dava Edenler
                                    {
                                        AV001_TDI_BIL_TEBLIGAT_MUHATAP mhtp =
                                            tebl.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddNew();
                                        mhtp.TEBLIGAT_HEDEF_TIP = 2;
                                        mhtp.ALAN_CARI_ID = taraf.CARI_ID;
                                        mhtp.MUHATAP_CARI_ID = taraf.CARI_ID.Value;
                                        mhtp.MUHATAP_TARAF_KOD = (short)taraf.TARAF_KODU;
                                        mhtp.MUHASEBE_ALT_KATEGORI_ID =
                                            (int)AvukatProLib.Extras.MuhasebeAltKategoriId.iLK_TEBLiGAT_GiDERi;
                                        mhtp.EVRAK_TARIHI = DateTime.Today;
                                        mhtp.EVRAK_NO = DateTime.Today.Year + "/" + DateTime.Now.Millisecond;
                                        mhtp.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                                        mhtp.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                                        mhtp.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                                        mhtp.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                                        //TODO: Sýralý kayýt
                                        var cariAciklama = BelgeUtil.Inits.context.per_CARI_ACIKLAMAs.Single(item => item.ID == taraf.CARI_ID.Value); //Okan 12.08.2010
                                        mhtp.TEBLIGAT_ADRESI = String.Format("{0} {1} {2} {3}",
                                                                             cariAciklama.ADRES_1,
                                                                             cariAciklama.ILCE,
                                                                             cariAciklama.IL,
                                                                             cariAciklama.ULKE);
                                    }
                                    else //Takip Edenler
                                    {
                                        AV001_TDI_BIL_TEBLIGAT_YAPAN ypn =
                                            tebl.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddNew();
                                        ypn.YAPAN_CARI_ID = taraf.CARI_ID.Value;
                                        ypn.TARAF_KOD = ((TarafKodu)taraf.TARAF_KODU).ToString()[0].ToString();
                                    }
                                }
                            }
                        }
                        else
                        {
                            tebl = new AV001_TDI_BIL_TEBLIGAT();
                            tebl.ACIKLAMA = iliski.AsamaAciklamaGetir(mFoy);
                            tebl.KONU_ID = iliski.TEBLIGAT_KONU_ID.Value;
                            tebl.HAZIRLAYAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
                            tebl.TEBLIGAT_REFERANS_NO = AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit.TebligatReferansNoOlustur();
                            tebl.ADLI_BIRIM_ADLIYE_ID = mFoy.ADLI_BIRIM_ADLIYE_ID;
                            tebl.ADLI_BIRIM_GOREV_ID = mFoy.ADLI_BIRIM_GOREV_ID;
                            tebl.ADLI_BIRIM_NO_ID = mFoy.ADLI_BIRIM_NO_ID;
                            tebl.DAVA_FOY_ID = mFoy.ID;
                            tebl.TEBLIGAT_HEDEF_TIP = 2;
                            tebl.TEBLIGAT_ESAS_NO = mFoy.ESAS_NO;

                            //TODO: Yukarýdaki yer bugünü kurtarmak için yapýlmýþ olup acilen deðiþtirilmesi gerekmektedir.

                            if (iliski.TEBLIGAT_KONU_IDSource == null)
                                iliski.TEBLIGAT_KONU_IDSource =
                                    DataRepository.TDI_KOD_TEBLIGAT_KONUProvider.GetByID(iliski.TEBLIGAT_KONU_ID.Value);

                            if (iliski.TEBLIGAT_KONU_IDSource.ILK_TEBLIGAT_MI)
                            {
                                tebl.HAZIRLAMA_TARIH = mFoy.DAVA_TARIHI.Value;
                                tebl.POSTALANMA_TARIH = mFoy.DAVA_TARIHI.Value;
                                tebl.ANA_TUR_ID = iliski.TEBLIGAT_KONU_IDSource.ANA_TUR_ID;
                                tebl.ALT_TUR_ID = iliski.TEBLIGAT_KONU_IDSource.ALT_TUR_ID;
                                tebl.DAVA_ILK_TEBLIGAT_MI = true;
                                tebl.MUHASEBE_ALT_KATEGORI_ID =
                                    (int)AvukatProLib.Extras.MuhasebeAltKategoriId.iLK_TEBLiGAT_GiDERi;
                                //tebl.KAYIT_TARIHI = DataTime.Now;
                                tebl.KONTROL_NE_ZAMAN = DateTime.Now;
                                tebl.KONTROL_VERSIYON++;
                                tebl.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Clear();
                                tebl.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Clear();
                                foreach (AV001_TD_BIL_FOY_TARAF taraf in mFoy.AV001_TD_BIL_FOY_TARAFCollection)
                                {
                                    if (!taraf.DAVA_EDEN_MI) //Dava Edilenler
                                    {
                                        AV001_TDI_BIL_TEBLIGAT_MUHATAP mhtp =
                                            tebl.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddNew();
                                        mhtp.TEBLIGAT_HEDEF_TIP = 2;
                                        mhtp.ALAN_CARI_ID = taraf.CARI_ID;
                                        mhtp.MUHATAP_CARI_ID = taraf.CARI_ID.Value;
                                        mhtp.MUHATAP_TARAF_KOD = (short)taraf.TARAF_KODU;
                                        mhtp.MUHASEBE_ALT_KATEGORI_ID =
                                            (int)AvukatProLib.Extras.MuhasebeAltKategoriId.iLK_TEBLiGAT_GiDERi;
                                        mhtp.EVRAK_TARIHI = DateTime.Today;
                                        mhtp.EVRAK_NO = DateTime.Today.Year + "/" + DateTime.Now.Millisecond;
                                        mhtp.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                                        mhtp.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                                        mhtp.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                                        mhtp.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                                        //TODO: Sýralý kayýt
                                        var cariAciklama = BelgeUtil.Inits.context.per_CARI_ACIKLAMAs.Single(item => item.ID == taraf.CARI_ID.Value); //Okan 12.08.2010
                                        mhtp.TEBLIGAT_ADRESI = String.Format("{0} {1} {2} {3}",
                                                                             cariAciklama.ADRES_1,
                                                                             cariAciklama.ILCE,
                                                                             cariAciklama.IL,
                                                                             cariAciklama.ULKE);
                                    }
                                    else //TakipEdenler
                                    {
                                        AV001_TDI_BIL_TEBLIGAT_YAPAN ypn =
                                            tebl.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddNew();
                                        ypn.YAPAN_CARI_ID = taraf.CARI_ID.Value;
                                        ypn.TARAF_KOD = ((TarafKodu)taraf.TARAF_KODU).ToString()[0].ToString();
                                    }
                                }
                            }
                            mFoy.AV001_TDI_BIL_TEBLIGATCollection.Add(tebl);
                        }
                    }

                    #endregion
                }
            }

            #endregion
        }

        public static StringBuilder AciklamaGetir(AV001_TI_BIL_FOY mFoy, string tarafAdi, string tarih)
        {
            StringBuilder result = new StringBuilder();

            #region Entity Sourcelarini Kontrol Ediyor

            if (mFoy.ADLI_BIRIM_ADLIYE_ID.HasValue && mFoy.ADLI_BIRIM_ADLIYE_IDSource == null)
                mFoy.ADLI_BIRIM_ADLIYE_IDSource =
                    DataRepository.TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetByID(mFoy.ADLI_BIRIM_ADLIYE_ID.Value);

            if (mFoy.ADLI_BIRIM_NO_ID.HasValue && mFoy.ADLI_BIRIM_NO_IDSource == null)
                mFoy.ADLI_BIRIM_NO_IDSource =
                    DataRepository.TDI_KOD_ADLI_BIRIM_NOProvider.GetByID(mFoy.ADLI_BIRIM_NO_ID.Value);

            if (mFoy.ADLI_BIRIM_GOREV_ID.HasValue && mFoy.ADLI_BIRIM_GOREV_IDSource == null)
                mFoy.ADLI_BIRIM_GOREV_IDSource =
                    DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.GetByID(mFoy.ADLI_BIRIM_GOREV_ID.Value);

            #endregion

            if (mFoy.ADLI_BIRIM_ADLIYE_ID.HasValue)
            {
                result.Append("Adliyesi");
                result.Append(" ");
                result.Append(mFoy.ADLI_BIRIM_ADLIYE_IDSource.ADLIYE);
                result.Append(",");
            }

            if (mFoy.ADLI_BIRIM_NO_ID.HasValue)
            {
                result.Append("Adli Birim Numarasý");
                result.Append(" ");
                result.Append(mFoy.ADLI_BIRIM_NO_IDSource.NO);
                result.Append(" ");
            }

            if (mFoy.ADLI_BIRIM_GOREV_ID.HasValue)
            {
                result.Append("ve");
                result.Append(" ");
                result.Append("Görevi");
                result.Append(" ");
                result.Append(mFoy.ADLI_BIRIM_GOREV_IDSource.GOREV);
                result.Append(" ");
                result.Append("Olan");
                result.Append(" ");
            }

            if (mFoy.ESAS_NO != string.Empty && mFoy.ESAS_NO != "2009/")
            {
                result.Append(mFoy.ESAS_NO);
                result.Append("Esas Numaralý");
                result.Append(" ");
            }

            result.Append("Ýcra dosyasýnda");
            result.Append("(");
            result.Append(mFoy.FOY_NO);
            result.Append(")");
            result.Append(" ");
            result.Append(tarafAdi);
            result.Append(" ");
            result.Append("Ýsimli Taraf Ýçin");
            result.Append(" ");
            result.Append(tarih);
            result.Append(" ");
            result.Append("Tarihinde");

            return result;
        }

        /// <summary>
        /// Aþama Ýþlemlerinin büyük bir kýsmýnýn olduðu yer Bir kýsmý ise foyukaydet (Icrakayitform) da yer almaktadýr...
        /// </summary>
        /// <param name="mFoy">iþlem yapýlacak foy.</param>
        public static void AsamalariHallet(AV001_TI_BIL_FOY mFoy)
        {
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(mFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_ASAMA>));

            foreach (AV001_TI_BIL_IHTIYATI_HACIZ haciz in mFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection)
            {
                #region Ihtiyati Haciz (ilk Aþama) 17 - 23

                if (haciz.IsNew && !AsamaHelper.AsamaVarmi(17, 23, haciz))
                {
                    AV001_TDIE_BIL_ASAMA asm = new AV001_TDIE_BIL_ASAMA();
                    asm.ASAMA_KOD_ID = 17;
                    asm.ASAMA_ALT_KOD_ID = 23;
                    asm.ADLI_BIRIM_ADLIYE_ID = haciz.ADLI_BIRIM_ADLIYE_ID;
                    asm.ADLI_BIRIM_GOREV_ID = haciz.ADLI_BIRIM_GOREV_ID;
                    asm.ADLI_BIRIM_NO_ID = haciz.ADLI_BIRIM_NO_ID;
                    asm.ESAS_NO = haciz.ESAS_NO;
                    asm.ASAMA_TARIHI = haciz.KARAR_TARIHI;
                    asm.ASAMA_MODUL_ID = 1;
                    asm.ASAMA_KONU = "Ýhtiyati Haciz Kararý";
                    asm.ASAMA_ACIKLAMA =
                        String.Format(
                            "Ýlgili Borçlu hakkýnda {0} {1} {2}'nin {3} esas ,{4} karar ve {5} tarihli ihtiyati haciz kararý alýnmýþtýr.",
                            haciz.ADLI_BIRIM_ADLIYE_IDSource, haciz.ADLI_BIRIM_NO_IDSource,
                            haciz.ADLI_BIRIM_GOREV_IDSource, haciz.ESAS_NO, haciz.KARAR_NO,
                            haciz.KARAR_TARIHI.Value.ToShortDateString());
                    foreach (
                        AV001_TI_BIL_IHTIYATI_HACIZ_TARAF taraf in haciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection)
                    {
                        AV001_TDIE_BIL_ASAMA_TARAF trf = asm.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                        trf.CARI_ID = taraf.ICRA_CARI_TARAF_ID.Value;
                        trf.SIFAT_ID = taraf.TARAF_SIFAT_ID.Value;
                        trf.KODU = ((TarafKodu)taraf.TARAF_KODU).ToString()[0].ToString();
                        trf.SIFAT_IDSource = BelgeUtil.Inits.TarafSifatGetir(trf.SIFAT_ID);
                        if (trf.SIFAT_IDSource != null)
                            trf.ASAMAYI_YAPAN_MI = (trf.SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN");
                    }
                    foreach (AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                    {
                        AV001_TDIE_BIL_ASAMA_SORUMLU srm = asm.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.AddNew();
                        srm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                    }
                    haciz.MyAsamaList.Add(asm);
                    mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asm);
                }

                #endregion

                #region Ýhtiyati Haczin Kesinleþmesi 17-104

                if (!AsamaHelper.AsamaVarmi(17, 104, haciz) && haciz.K_H_CEVIRME_TARIHI.HasValue)
                {
                    AV001_TDIE_BIL_ASAMA asm = new AV001_TDIE_BIL_ASAMA();
                    asm.ASAMA_KOD_ID = 17;
                    asm.ASAMA_ALT_KOD_ID = 104;
                    asm.ADLI_BIRIM_ADLIYE_ID = haciz.ADLI_BIRIM_ADLIYE_ID;
                    asm.ADLI_BIRIM_GOREV_ID = haciz.ADLI_BIRIM_GOREV_ID;
                    asm.ADLI_BIRIM_NO_ID = haciz.ADLI_BIRIM_NO_ID;
                    asm.ESAS_NO = haciz.ESAS_NO;
                    asm.ASAMA_TARIHI = haciz.K_H_CEVIRME_TARIHI;
                    asm.ASAMA_MODUL_ID = 1;
                    asm.ASAMA_KONU = "Ýhtiyati Haczin Kesinleþmesi";
                    asm.ASAMA_ACIKLAMA =
                        String.Format(
                            "Ýlgili Borçlu hakkýnda {0} {1} {2}'nin {3} esas ,{4} karar ve {5} tarihli ihtiyati haciz kesinleþmiþtir.",
                            haciz.ADLI_BIRIM_ADLIYE_IDSource, haciz.ADLI_BIRIM_NO_IDSource,
                            haciz.ADLI_BIRIM_GOREV_IDSource, haciz.ESAS_NO, haciz.KARAR_NO,
                            haciz.K_H_CEVIRME_TARIHI.Value.ToShortDateString());
                    foreach (
                        AV001_TI_BIL_IHTIYATI_HACIZ_TARAF taraf in haciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection)
                    {
                        AV001_TDIE_BIL_ASAMA_TARAF trf = asm.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                        trf.CARI_ID = taraf.ICRA_CARI_TARAF_ID.Value;
                        trf.SIFAT_ID = taraf.TARAF_SIFAT_ID.Value;
                        trf.KODU = ((TarafKodu)taraf.TARAF_KODU).ToString()[0].ToString();
                        trf.SIFAT_IDSource = BelgeUtil.Inits.TarafSifatGetir(trf.SIFAT_ID);
                        if (trf.SIFAT_IDSource != null)
                            trf.ASAMAYI_YAPAN_MI = (trf.SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN");
                    }
                    foreach (AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                    {
                        AV001_TDIE_BIL_ASAMA_SORUMLU srm = asm.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.AddNew();
                        srm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                    }
                    haciz.MyAsamaList.Add(asm);
                    mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asm);
                }

                #endregion

                #region Ýhtiyati Haciz Talebi 17-1081

                if (!AsamaHelper.AsamaVarmi(17, 1081, haciz) && haciz.TALEP_TARIHI.HasValue)
                {
                    AV001_TDIE_BIL_ASAMA asm = new AV001_TDIE_BIL_ASAMA();
                    asm.ASAMA_KOD_ID = 17;
                    asm.ASAMA_ALT_KOD_ID = 1081;
                    asm.ADLI_BIRIM_ADLIYE_ID = haciz.ADLI_BIRIM_ADLIYE_ID;
                    asm.ADLI_BIRIM_GOREV_ID = haciz.ADLI_BIRIM_GOREV_ID;
                    asm.ADLI_BIRIM_NO_ID = haciz.ADLI_BIRIM_NO_ID;
                    asm.ESAS_NO = haciz.ESAS_NO;
                    asm.ASAMA_TARIHI = haciz.TALEP_TARIHI;
                    asm.ASAMA_MODUL_ID = 1;
                    asm.ASAMA_KONU = "Ýhtiyati Haciz Talebi";
                    asm.ASAMA_ACIKLAMA =
                        String.Format(
                            "Ýlgili Borçlu hakkýnda {0} {1} {2}'nin {3} esas ,{4} karar ve {5} tarihli ihtiyati haciz talep edilmiþtir.",
                            haciz.ADLI_BIRIM_ADLIYE_IDSource, haciz.ADLI_BIRIM_NO_IDSource,
                            haciz.ADLI_BIRIM_GOREV_IDSource, haciz.ESAS_NO, haciz.KARAR_NO,
                            haciz.TALEP_TARIHI.Value.ToShortDateString());
                    foreach (
                        AV001_TI_BIL_IHTIYATI_HACIZ_TARAF taraf in haciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection)
                    {
                        AV001_TDIE_BIL_ASAMA_TARAF trf = asm.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                        trf.CARI_ID = taraf.ICRA_CARI_TARAF_ID.Value;
                        trf.SIFAT_ID = taraf.TARAF_SIFAT_ID.Value;
                        trf.KODU = ((TarafKodu)taraf.TARAF_KODU).ToString()[0].ToString();
                        trf.SIFAT_IDSource = BelgeUtil.Inits.TarafSifatGetir(trf.SIFAT_ID);
                        if (trf.SIFAT_IDSource != null)
                            trf.ASAMAYI_YAPAN_MI = (trf.SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN");
                    }
                    foreach (AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                    {
                        AV001_TDIE_BIL_ASAMA_SORUMLU srm = asm.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.AddNew();
                        srm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                    }
                    haciz.MyAsamaList.Add(asm);
                    mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asm);
                }

                #endregion

                foreach (AV001_TI_BIL_IHTIYATI_HACIZ_TARAF taraf in haciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection)
                {
                    #region Ýhtiyatihacze itiraz aþamasý 17 -102

                    if (taraf.IHTIYATI_HACIZE_ITIRAZ_TARIHI.HasValue && !AsamaHelper.BuAsamaOncedenVarmi(17, 102, taraf) &&
                        !AsamaHelper.AsamaVarmi(17, 102, taraf))
                    {
                        //Ýhtiyatihacze itiraz aþamasý
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        haciz.AsamaDoldur(asama);
                        asama.ASAMA_KOD_ID = 17;
                        asama.ASAMA_ALT_KOD_ID = 102;
                        asama.ASAMA_TARIHI = taraf.IHTIYATI_HACIZE_ITIRAZ_TARIHI;
                        asama.ASAMA_KONU = "Ýhtiyati Hacize Ýtiraz";
                        asama.ASAMA_MODUL_ID = 1;
                        asama.ASAMA_ACIKLAMA =
                            taraf.IHTIYATI_HACIZE_ITIRAZ_NEDENI + " nedeni ile" + String.Format(
                                "Ýlgili Borçlu hakkýnda {0} {1} {2}'nin {3} esas ,{4} karar ve {5} tarihli ihtiyati haciz kararýna itiraz edilmiþtir",
                                haciz.ADLI_BIRIM_ADLIYE_IDSource,
                                haciz.ADLI_BIRIM_NO_IDSource,
                                haciz.ADLI_BIRIM_GOREV_IDSource,
                                haciz.ESAS_NO,
                                haciz.KARAR_NO,
                                haciz.KARAR_TARIHI.Value.
                                    ToShortDateString());
                        foreach (
                            AV001_TI_BIL_IHTIYATI_HACIZ_TARAF hTrf in haciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                            asmTaraf.CARI_ID = hTrf.ICRA_CARI_TARAF_ID.Value;
                            asmTaraf.SIFAT_ID = hTrf.TARAF_SIFAT_ID.Value;
                            asmTaraf.KODU = ((TarafKodu)hTrf.TARAF_KODU).ToString()[0].ToString();
                            asmTaraf.SIFAT_IDSource = BelgeUtil.Inits.TarafSifatGetir(asmTaraf.SIFAT_ID);
                            asmTaraf.ASAMAYI_YAPAN_MI = (hTrf == taraf);
                            if (asmTaraf.SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN" || asmTaraf.ASAMAYI_YAPAN_MI)
                            {
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }
                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm =
                                    new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }
                        taraf.MyAsamaList.Add(asama);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }

                    #endregion

                    #region TEMINAT_IADESINE_MUVAFAKAT aþamasý 17-103

                    if (taraf.TEMINAT_IADESINE_MUVAFAKAT_TARIHI.HasValue &&
                        !AsamaHelper.BuAsamaOncedenVarmi(17, 103, taraf) && !AsamaHelper.AsamaVarmi(17, 103, taraf))
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        haciz.AsamaDoldur(asama);
                        asama.ASAMA_KOD_ID = 17;
                        asama.ASAMA_ALT_KOD_ID = 103;
                        asama.ASAMA_TARIHI = taraf.TEMINAT_IADESINE_MUVAFAKAT_TARIHI;
                        asama.ASAMA_KONU = "Ýhtiyati Haciz Teminatýnýn Ýadesi";
                        asama.ASAMA_MODUL_ID = 1;
                        asama.ASAMA_ACIKLAMA =
                            String.Format(
                                "Ýlgili Borçlu tarafýndan {0} {1} {2}'nin {3} esas ,{4} karar ve {5} tarihli ihtiyati haciz kararýna iliþkin yatýrýlan teminatýn iadesine muvafakat edilmiþtir.",
                                haciz.ADLI_BIRIM_ADLIYE_IDSource,
                                haciz.ADLI_BIRIM_NO_IDSource,
                                haciz.ADLI_BIRIM_GOREV_IDSource,
                                haciz.ESAS_NO,
                                haciz.KARAR_NO,
                                haciz.KARAR_TARIHI.Value.ToShortDateString());
                        foreach (
                            AV001_TI_BIL_IHTIYATI_HACIZ_TARAF hTrf in haciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                            asmTaraf.CARI_ID = hTrf.ICRA_CARI_TARAF_ID.Value;
                            asmTaraf.SIFAT_ID = hTrf.TARAF_SIFAT_ID.Value;
                            asmTaraf.KODU = ((TarafKodu)hTrf.TARAF_KODU).ToString()[0].ToString();
                            asmTaraf.SIFAT_IDSource = BelgeUtil.Inits.TarafSifatGetir(asmTaraf.SIFAT_ID);
                            asmTaraf.ASAMAYI_YAPAN_MI = (hTrf == taraf);
                            if (asmTaraf.SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN" || asmTaraf.ASAMAYI_YAPAN_MI)
                            {
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }
                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm =
                                    new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }
                        taraf.MyAsamaList.Add(asama);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }

                    #endregion

                    #region Ýhtiyati Hacizin Kesinleþmesi 17-104

                    if (taraf.IHTIYATI_HACIZ_MAHKEMESI_KESINLESTIRME_TARIHI.HasValue &&
                        !AsamaHelper.BuAsamaOncedenVarmi(17, 104, taraf) && !AsamaHelper.AsamaVarmi(17, 104, taraf))
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        haciz.AsamaDoldur(asama);
                        asama.ASAMA_KOD_ID = 17;
                        asama.ASAMA_ALT_KOD_ID = 104;
                        asama.ASAMA_TARIHI = taraf.IHTIYATI_HACIZ_MAHKEMESI_KESINLESTIRME_TARIHI;
                        asama.ASAMA_KONU = "Ýhtiyati Haciz Kararýnýn Kesinleþmesi";
                        asama.ASAMA_MODUL_ID = 1;
                        asama.ASAMA_ACIKLAMA =
                            String.Format(
                                "Ýlgili Borçlu hakkýnda {0} {1} {2}'nin {3} esas ,{4} karar ve {5} tarihli ihtiyati haciz kararý kesinleþmiþtir.",
                                haciz.ADLI_BIRIM_ADLIYE_IDSource,
                                haciz.ADLI_BIRIM_NO_IDSource,
                                haciz.ADLI_BIRIM_GOREV_IDSource,
                                haciz.ESAS_NO,
                                haciz.KARAR_NO,
                                haciz.KARAR_TARIHI.Value.ToShortDateString());
                        foreach (
                            AV001_TI_BIL_IHTIYATI_HACIZ_TARAF hTrf in haciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                            asmTaraf.CARI_ID = hTrf.ICRA_CARI_TARAF_ID.Value;
                            asmTaraf.SIFAT_ID = hTrf.TARAF_SIFAT_ID.Value;
                            asmTaraf.KODU = ((TarafKodu)hTrf.TARAF_KODU).ToString()[0].ToString();
                            asmTaraf.SIFAT_IDSource = BelgeUtil.Inits.TarafSifatGetir(asmTaraf.SIFAT_ID);
                            asmTaraf.ASAMAYI_YAPAN_MI = (asmTaraf.SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN");
                            if (asmTaraf.SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN" || hTrf == taraf)
                            {
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }
                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm =
                                    new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }
                        taraf.MyAsamaList.Add(asama);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }

                    #endregion

                    #region Ýhtiyati Haczin Kaldýrýlmasý 17-105

                    if (taraf.IHTIYATI_HACIZIN_KALDIRILMASI_TARIHI.HasValue &&
                        !AsamaHelper.BuAsamaOncedenVarmi(17, 105, taraf) && !AsamaHelper.AsamaVarmi(17, 105, taraf))
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        haciz.AsamaDoldur(asama);
                        asama.ASAMA_KOD_ID = 17;
                        asama.ASAMA_ALT_KOD_ID = 105;
                        asama.ASAMA_TARIHI = taraf.IHTIYATI_HACIZIN_KALDIRILMASI_TARIHI;
                        asama.ASAMA_KONU = "Ýhtiyati Haciz Kararýnýn Kaldýrýlmasý";
                        asama.ASAMA_MODUL_ID = 1;
                        asama.ASAMA_ACIKLAMA =
                            String.Format(
                                "Ýlgili Borçlu hakkýnda {0} {1} {2}'nin {3} esas ,{4} karar ve {5} tarihli ihtiyati haciz kararý kaldýrýlmýþtýr.",
                                haciz.ADLI_BIRIM_ADLIYE_IDSource,
                                haciz.ADLI_BIRIM_NO_IDSource,
                                haciz.ADLI_BIRIM_GOREV_IDSource,
                                haciz.ESAS_NO,
                                haciz.KARAR_NO,
                                haciz.KARAR_TARIHI.Value.ToShortDateString());
                        foreach (
                            AV001_TI_BIL_IHTIYATI_HACIZ_TARAF hTrf in haciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                            asmTaraf.CARI_ID = hTrf.ICRA_CARI_TARAF_ID.Value;
                            asmTaraf.SIFAT_ID = hTrf.TARAF_SIFAT_ID.Value;
                            asmTaraf.KODU = ((TarafKodu)hTrf.TARAF_KODU).ToString()[0].ToString();
                            asmTaraf.SIFAT_IDSource = BelgeUtil.Inits.TarafSifatGetir(asmTaraf.SIFAT_ID);
                            asmTaraf.ASAMAYI_YAPAN_MI = (asmTaraf.SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN");
                            asmTaraf.MAHKEME_MI = asmTaraf.ASAMAYI_YAPAN_MI;
                            if (asmTaraf.SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN" || hTrf == taraf)
                            {
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }
                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm =
                                    new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }
                        taraf.MyAsamaList.Add(asama);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }

                    #endregion
                }
            }
            foreach (AV001_TDI_BIL_IHTIYATI_TEDBIR tedbir in mFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection)
            {
                #region Ýhtiyati Tedbir (Ýlk Aþama) 121-110

                if (tedbir.IsNew && !AsamaHelper.AsamaVarmi(121, 110, tedbir))
                {
                    AV001_TDIE_BIL_ASAMA asm = new AV001_TDIE_BIL_ASAMA();
                    asm.ASAMA_KOD_ID = 121;
                    asm.ASAMA_ALT_KOD_ID = 110;
                    asm.ADLI_BIRIM_ADLIYE_ID = tedbir.ADLI_BIRIM_ADLIYE_ID;
                    asm.ADLI_BIRIM_GOREV_ID = tedbir.ADLI_BIRIM_GOREV_ID;
                    asm.ADLI_BIRIM_NO_ID = tedbir.ADLI_BIRIM_NO_ID;
                    asm.ESAS_NO = tedbir.ESAS_NO;
                    asm.ASAMA_KONU = "Ýhtiyati Tedbir Kararý";
                    asm.ASAMA_ACIKLAMA =
                        String.Format(
                            "Ýlgili Borçlu hakkýnda {0} {1} {2}'nin {3} esas ,{4} karar ve {5} tarihli ihtiyati tedbir kararý alýnmýþtýr.",
                            tedbir.ADLI_BIRIM_ADLIYE_IDSource, tedbir.ADLI_BIRIM_NO_IDSource,
                            tedbir.ADLI_BIRIM_GOREV_IDSource, tedbir.ESAS_NO, tedbir.KARAR_NO,
                            tedbir.KARAR_TARIHI.Value.ToShortDateString());
                    foreach (
                        AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF taraf in
                            tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection)
                    {
                        AV001_TDIE_BIL_ASAMA_TARAF trf = asm.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                        trf.CARI_ID = taraf.ICRA_CARI_TARAF_ID.Value;
                        trf.SIFAT_ID = taraf.ICRA_TARAF_SIFAT_ID.Value;
                        trf.KODU = ((TarafKodu)taraf.TARAF_KODU).ToString()[0].ToString();
                        trf.SIFAT_IDSource = BelgeUtil.Inits.TarafSifatGetir(trf.SIFAT_ID);
                        if (trf.SIFAT_IDSource != null)
                            trf.ASAMAYI_YAPAN_MI = (trf.SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN");
                    }
                    foreach (AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                    {
                        if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                        {
                            AV001_TDIE_BIL_ASAMA_SORUMLU aSrm =
                                new AV001_TDIE_BIL_ASAMA_SORUMLU();

                            aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                            asm.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                        }
                    }
                    tedbir.MyAsamaList.Add(asm);
                    mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asm);
                }

                #endregion

                #region Ýhtiyati Tedbirin Ýþleme Konmasý 121-1080

                if (!AsamaHelper.AsamaVarmi(121, 1080, tedbir) && tedbir.DAVA_TARIHI > DateTime.MinValue)
                {
                    AV001_TDIE_BIL_ASAMA asm = new AV001_TDIE_BIL_ASAMA();
                    asm.ASAMA_KOD_ID = 121;
                    asm.ASAMA_ALT_KOD_ID = 1080;
                    asm.ADLI_BIRIM_ADLIYE_ID = tedbir.ADLI_BIRIM_ADLIYE_ID;
                    asm.ADLI_BIRIM_GOREV_ID = tedbir.ADLI_BIRIM_GOREV_ID;
                    asm.ADLI_BIRIM_NO_ID = tedbir.ADLI_BIRIM_NO_ID;
                    asm.ESAS_NO = tedbir.ESAS_NO;
                    asm.ASAMA_KONU = "Ýhtiyati Tedbirin Ýþleme Konmasý";
                    asm.ASAMA_TARIHI = tedbir.DAVA_TARIHI;
                    asm.ASAMA_ACIKLAMA =
                        String.Format(
                            "Ýlgili Borçlu hakkýnda {0} {1} {2}'nin {3} esas ,{4} karar ve {5} tarihli ihtiyati tedbir kararý alýnmýþtýr.",
                            tedbir.ADLI_BIRIM_ADLIYE_IDSource, tedbir.ADLI_BIRIM_NO_IDSource,
                            tedbir.ADLI_BIRIM_GOREV_IDSource, tedbir.ESAS_NO, tedbir.KARAR_NO,
                            tedbir.DAVA_TARIHI.HasValue ? tedbir.DAVA_TARIHI.Value.ToShortDateString() : "TARIH YOK");
                    foreach (
                        AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF taraf in
                            tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection)
                    {
                        AV001_TDIE_BIL_ASAMA_TARAF trf = asm.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                        trf.CARI_ID = taraf.ICRA_CARI_TARAF_ID.Value;
                        trf.SIFAT_ID = taraf.ICRA_TARAF_SIFAT_ID.Value;
                        trf.KODU = ((TarafKodu)taraf.TARAF_KODU).ToString()[0].ToString();
                        trf.SIFAT_IDSource = BelgeUtil.Inits.TarafSifatGetir(trf.SIFAT_ID);
                        if (trf.SIFAT_IDSource != null)
                            trf.ASAMAYI_YAPAN_MI = (trf.SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN");
                    }
                    foreach (AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                    {
                        if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                        {
                            AV001_TDIE_BIL_ASAMA_SORUMLU aSrm =
                                new AV001_TDIE_BIL_ASAMA_SORUMLU();

                            aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                            asm.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                        }
                    }
                    tedbir.MyAsamaList.Add(asm);
                    mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asm);
                }

                #endregion

                #region Ýhtiyati Tedbir Baþvurusu 121-110

                if (!AsamaHelper.AsamaVarmi(121, 110, tedbir) && tedbir.TALEP_TARIHI > DateTime.MinValue)
                {
                    AV001_TDIE_BIL_ASAMA asm = new AV001_TDIE_BIL_ASAMA();
                    asm.ASAMA_KOD_ID = 121;
                    asm.ASAMA_ALT_KOD_ID = 110;
                    asm.ADLI_BIRIM_ADLIYE_ID = tedbir.ADLI_BIRIM_ADLIYE_ID;
                    asm.ADLI_BIRIM_GOREV_ID = tedbir.ADLI_BIRIM_GOREV_ID;
                    asm.ADLI_BIRIM_NO_ID = tedbir.ADLI_BIRIM_NO_ID;
                    asm.ESAS_NO = tedbir.ESAS_NO;
                    asm.ASAMA_KONU = "Ýhtiyati Tedbir Baþvurusu";
                    asm.ASAMA_TARIHI = tedbir.TALEP_TARIHI;
                    asm.ASAMA_ACIKLAMA =
                        String.Format(
                            "Ýlgili Borçlu hakkýnda {0} {1} {2}'nin {3} esas ,{4} karar ve {5} tarihli ihtiyati tedbir kararý alýnmýþtýr.",
                            tedbir.ADLI_BIRIM_ADLIYE_IDSource, tedbir.ADLI_BIRIM_NO_IDSource,
                            tedbir.ADLI_BIRIM_GOREV_IDSource, tedbir.ESAS_NO, tedbir.KARAR_NO,
                            tedbir.TALEP_TARIHI.ToShortDateString());
                    foreach (
                        AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF taraf in
                            tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection)
                    {
                        AV001_TDIE_BIL_ASAMA_TARAF trf = asm.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                        trf.CARI_ID = taraf.ICRA_CARI_TARAF_ID.Value;
                        trf.SIFAT_ID = taraf.ICRA_TARAF_SIFAT_ID.Value;
                        trf.KODU = ((TarafKodu)taraf.TARAF_KODU).ToString()[0].ToString();
                        trf.SIFAT_IDSource = BelgeUtil.Inits.TarafSifatGetir(trf.SIFAT_ID);
                        if (trf.SIFAT_IDSource != null)
                            trf.ASAMAYI_YAPAN_MI = (trf.SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN");
                    }
                    foreach (AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                    {
                        if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                        {
                            AV001_TDIE_BIL_ASAMA_SORUMLU aSrm =
                                new AV001_TDIE_BIL_ASAMA_SORUMLU();

                            aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                            asm.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                        }
                    }
                    tedbir.MyAsamaList.Add(asm);
                    mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asm);
                }

                #endregion

                #region Ýhtiyati Tedbir Kararý Alýnmasý 121-266

                if (!AsamaHelper.AsamaVarmi(121, 266, tedbir) && tedbir.KARAR_TARIHI.HasValue)
                {
                    AV001_TDIE_BIL_ASAMA asm = new AV001_TDIE_BIL_ASAMA();
                    asm.ASAMA_KOD_ID = 121;
                    asm.ASAMA_ALT_KOD_ID = 266;
                    asm.ADLI_BIRIM_ADLIYE_ID = tedbir.ADLI_BIRIM_ADLIYE_ID;
                    asm.ADLI_BIRIM_GOREV_ID = tedbir.ADLI_BIRIM_GOREV_ID;
                    asm.ADLI_BIRIM_NO_ID = tedbir.ADLI_BIRIM_NO_ID;
                    asm.ESAS_NO = tedbir.ESAS_NO;
                    asm.ASAMA_KONU = "Ýhtiyati Tedbir Kararý Alýnmasý";
                    asm.ASAMA_TARIHI = tedbir.KARAR_TARIHI;
                    asm.ASAMA_ACIKLAMA =
                        String.Format(
                            "Ýlgili Borçlu hakkýnda {0} {1} {2}'nin {3} esas ,{4} karar ve {5} tarihli ihtiyati tedbir kararý alýnmýþtýr.",
                            tedbir.ADLI_BIRIM_ADLIYE_IDSource, tedbir.ADLI_BIRIM_NO_IDSource,
                            tedbir.ADLI_BIRIM_GOREV_IDSource, tedbir.ESAS_NO, tedbir.KARAR_NO,
                            tedbir.KARAR_TARIHI.Value.ToShortDateString());
                    foreach (
                        AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF taraf in
                            tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection)
                    {
                        AV001_TDIE_BIL_ASAMA_TARAF trf = asm.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                        trf.CARI_ID = taraf.ICRA_CARI_TARAF_ID.Value;
                        trf.SIFAT_ID = taraf.ICRA_TARAF_SIFAT_ID.Value;
                        trf.KODU = ((TarafKodu)taraf.TARAF_KODU).ToString()[0].ToString();
                        trf.SIFAT_IDSource = BelgeUtil.Inits.TarafSifatGetir(trf.SIFAT_ID);
                        if (trf.SIFAT_IDSource != null)
                            trf.ASAMAYI_YAPAN_MI = (trf.SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN");
                    }
                    foreach (AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                    {
                        if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                        {
                            AV001_TDIE_BIL_ASAMA_SORUMLU aSrm =
                                new AV001_TDIE_BIL_ASAMA_SORUMLU();

                            aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                            asm.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                        }
                    }
                    tedbir.MyAsamaList.Add(asm);
                    mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asm);
                }

                #endregion

                //TODO:Bunlar test edilecek [YY]

                foreach (
                    AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF taraf in tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection)
                {
                    #region ÝhtiyatiTedbire itiraz aþamasý 121-106

                    if (taraf.IHTIYATI_TEDBIRE_ITIRAZ_TARIHI.HasValue &&
                        !AsamaHelper.BuAsamaOncedenVarmi(121, 106, taraf) && !AsamaHelper.AsamaVarmi(121, 106, taraf))
                    {
                        //Ýhtiyatihacze itiraz aþamasý
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        tedbir.AsamaDoldur(asama);
                        asama.ASAMA_KOD_ID = 121;
                        asama.ASAMA_ALT_KOD_ID = 106;
                        asama.ASAMA_TARIHI = taraf.IHTIYATI_TEDBIRE_ITIRAZ_TARIHI;
                        asama.ASAMA_KONU = "Ýhtiyati Tedbire Ýtiraz";
                        asama.ASAMA_ACIKLAMA = String.Format(
                            "Ýlgili Borçlu hakkýnda {0} {1} {2}'nin {3} esas ,{4} karar ve {5} tarihli ihtiyati tedbir kararýna itiraz edilmiþtir",
                            tedbir.ADLI_BIRIM_ADLIYE_IDSource,
                            tedbir.ADLI_BIRIM_NO_IDSource,
                            tedbir.ADLI_BIRIM_GOREV_IDSource,
                            tedbir.ESAS_NO,
                            tedbir.KARAR_NO,
                            tedbir.KARAR_TARIHI.Value.ToShortDateString());
                        foreach (
                            AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF hTrf in
                                tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                            asmTaraf.CARI_ID = hTrf.ICRA_CARI_TARAF_ID.Value;
                            asmTaraf.SIFAT_ID = hTrf.ICRA_TARAF_SIFAT_ID.Value;
                            asmTaraf.KODU = ((TarafKodu)hTrf.TARAF_KODU).ToString()[0].ToString();
                            asmTaraf.SIFAT_IDSource = BelgeUtil.Inits.TarafSifatGetir(asmTaraf.SIFAT_ID);
                            asmTaraf.ASAMAYI_YAPAN_MI = (hTrf == taraf);
                            if (asmTaraf.SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN" || asmTaraf.ASAMAYI_YAPAN_MI)
                            {
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }
                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm =
                                    new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }
                        taraf.MyAsamaList.Add(asama);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }

                    #endregion

                    #region TEMINAT_IADESINE_MUVAFAKAT aþamasý 121-107

                    if (taraf.TEMINAT_IADESINE_MUVAFAKAT_TARIHI.HasValue &&
                        !AsamaHelper.BuAsamaOncedenVarmi(121, 107, taraf) && !AsamaHelper.AsamaVarmi(121, 107, taraf))
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        tedbir.AsamaDoldur(asama);
                        asama.ASAMA_KOD_ID = 121;
                        asama.ASAMA_ALT_KOD_ID = 107;
                        asama.ASAMA_TARIHI = taraf.TEMINAT_IADESINE_MUVAFAKAT_TARIHI;
                        asama.ASAMA_KONU = "Ýhtiyati Tedbir Teminatýnýn Ýadesi";
                        asama.ASAMA_ACIKLAMA =
                            String.Format(
                                "Ýlgili Borçlu tarafýndan {0} {1} {2}'nin {3} esas ,{4} karar ve {5} tarihli ihtiyati tedbir kararýna iliþkin yatýrýlan teminatýn iadesine muvafakat edilmiþtir.",
                                tedbir.ADLI_BIRIM_ADLIYE_IDSource,
                                tedbir.ADLI_BIRIM_NO_IDSource,
                                tedbir.ADLI_BIRIM_GOREV_IDSource,
                                tedbir.ESAS_NO,
                                tedbir.KARAR_NO,
                                tedbir.KARAR_TARIHI.Value.ToShortDateString());
                        foreach (
                            AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF hTrf in
                                tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                            asmTaraf.CARI_ID = hTrf.ICRA_CARI_TARAF_ID.Value;
                            asmTaraf.SIFAT_ID = hTrf.ICRA_TARAF_SIFAT_ID.Value;
                            asmTaraf.KODU = ((TarafKodu)hTrf.TARAF_KODU).ToString()[0].ToString();
                            asmTaraf.SIFAT_IDSource = BelgeUtil.Inits.TarafSifatGetir(asmTaraf.SIFAT_ID);
                            asmTaraf.ASAMAYI_YAPAN_MI = (hTrf == taraf);
                            if (asmTaraf.SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN" || asmTaraf.ASAMAYI_YAPAN_MI)
                            {
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }
                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm =
                                    new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }
                        taraf.MyAsamaList.Add(asama);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }

                    #endregion

                    #region Ýhtiyati Hacizin Kesinleþmesi 121-108

                    if (taraf.IHTIYATI_TEDBIR_MAHKEMESI_KESINLESTIRME_TARIHI.HasValue &&
                        !AsamaHelper.BuAsamaOncedenVarmi(121, 108, taraf) && !AsamaHelper.AsamaVarmi(121, 108, taraf))
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        tedbir.AsamaDoldur(asama);
                        asama.ASAMA_KOD_ID = 121;
                        asama.ASAMA_ALT_KOD_ID = 108;
                        asama.ASAMA_TARIHI = taraf.IHTIYATI_TEDBIR_MAHKEMESI_KESINLESTIRME_TARIHI;
                        asama.ASAMA_KONU = "Ýhtiyati Tedbir Kararýnýn Kesinleþmesi";
                        asama.ASAMA_ACIKLAMA =
                            String.Format(
                                "Ýlgili Borçlu hakkýnda {0} {1} {2}'nin {3} esas ,{4} karar ve {5} tarihli ihtiyati tedbir kararý kesinleþmiþtir.",
                                tedbir.ADLI_BIRIM_ADLIYE_IDSource,
                                tedbir.ADLI_BIRIM_NO_IDSource,
                                tedbir.ADLI_BIRIM_GOREV_IDSource,
                                tedbir.ESAS_NO,
                                tedbir.KARAR_NO,
                                tedbir.KARAR_TARIHI.Value.ToShortDateString());
                        foreach (
                            AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF hTrf in
                                tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                            asmTaraf.CARI_ID = hTrf.ICRA_CARI_TARAF_ID.Value;
                            asmTaraf.SIFAT_ID = hTrf.ICRA_TARAF_SIFAT_ID.Value;
                            asmTaraf.KODU = ((TarafKodu)hTrf.TARAF_KODU).ToString()[0].ToString();
                            asmTaraf.SIFAT_IDSource = BelgeUtil.Inits.TarafSifatGetir(asmTaraf.SIFAT_ID);
                            asmTaraf.ASAMAYI_YAPAN_MI = (asmTaraf.SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN");
                            if (asmTaraf.SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN" || hTrf == taraf)
                            {
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }
                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm =
                                    new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }
                        taraf.MyAsamaList.Add(asama);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }

                    #endregion

                    #region Ýhtiyati Haczin Kaldýrýlmasý 121-109

                    if (taraf.IHTIYATI_TEDBIRIN_KALDIRILMASI_TARIHI.HasValue &&
                        !AsamaHelper.BuAsamaOncedenVarmi(121, 109, taraf) && !AsamaHelper.AsamaVarmi(121, 109, taraf))
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        tedbir.AsamaDoldur(asama);
                        asama.ASAMA_KOD_ID = 121;
                        asama.ASAMA_ALT_KOD_ID = 109;
                        asama.ASAMA_TARIHI = taraf.IHTIYATI_TEDBIRIN_KALDIRILMASI_TARIHI;
                        asama.ASAMA_KONU = "Ýhtiyati Tedbir Kararýnýn Kaldýrýlmasý";
                        asama.ASAMA_ACIKLAMA =
                            String.Format(
                                "Ýlgili Borçlu hakkýnda {0} {1} {2}'nin {3} esas ,{4} karar ve {5} tarihli ihtiyati tedbir kararý kaldýrýlmýþtýr.",
                                tedbir.ADLI_BIRIM_ADLIYE_IDSource,
                                tedbir.ADLI_BIRIM_NO_IDSource,
                                tedbir.ADLI_BIRIM_GOREV_IDSource,
                                tedbir.ESAS_NO,
                                tedbir.KARAR_NO,
                                tedbir.KARAR_TARIHI.Value.ToShortDateString());
                        foreach (
                            AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF hTrf in
                                tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                            asmTaraf.CARI_ID = hTrf.ICRA_CARI_TARAF_ID.Value;
                            asmTaraf.SIFAT_ID = hTrf.ICRA_TARAF_SIFAT_ID.Value;
                            asmTaraf.KODU = ((TarafKodu)hTrf.TARAF_KODU).ToString()[0].ToString();
                            asmTaraf.SIFAT_IDSource = BelgeUtil.Inits.TarafSifatGetir(asmTaraf.SIFAT_ID);
                            asmTaraf.ASAMAYI_YAPAN_MI = (asmTaraf.SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN");
                            asmTaraf.MAHKEME_MI = asmTaraf.ASAMAYI_YAPAN_MI;
                            if (asmTaraf.SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN" || hTrf == taraf)
                            {
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }
                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm =
                                    new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }
                        taraf.MyAsamaList.Add(asama);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }

                    #endregion
                }
            }
            foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
            {
                AV001_TDIE_BIL_ASAMA asama = null;
                TList<AV001_TDIE_BIL_ASAMA> asamalar = new TList<AV001_TDIE_BIL_ASAMA>();

                #region Aciz Aþamasý 149-377

                if (taraf.ACIZ_TARIHI.HasValue && !AsamaHelper.BuAsamaOncedenVarmi(149, 377, taraf) &&
                    !AsamaHelper.AsamaVarmi(149, 377, taraf))
                {
                    asama = new AV001_TDIE_BIL_ASAMA();
                    mFoy.AsamaDoldur(asama);
                    asama.ASAMA_KOD_ID = 149;
                    asama.ASAMA_ALT_KOD_ID = 377;
                    asama.ASAMA_TARIHI = taraf.ACIZ_TARIHI;
                    asama.ASAMA_KONU = "Aciz";
                    asamalar.Add(asama);
                }

                #endregion

                #region Ýbra Aþamasý 149 - 1073

                if (taraf.IBRA_TARIHI.HasValue && !AsamaHelper.BuAsamaOncedenVarmi(149, 1073, taraf) &&
                    !AsamaHelper.AsamaVarmi(149, 1073, taraf))
                {
                    asama = new AV001_TDIE_BIL_ASAMA();
                    mFoy.AsamaDoldur(asama);
                    asama.ASAMA_KOD_ID = 149;
                    asama.ASAMA_ALT_KOD_ID = 1073;
                    asama.ASAMA_TARIHI = taraf.IBRA_TARIHI;
                    asama.ASAMA_KONU = "Ýbra";
                    asamalar.Add(asama);
                }

                #endregion

                #region Eðer Sulh Tarihi Takip Tarihinden Küçükse 149 - 1069

                if (taraf.SULH_TARIHI.HasValue && mFoy.TAKIP_TARIHI > taraf.SULH_TARIHI)
                {
                    if (!AsamaHelper.BuAsamaOncedenVarmi(149, 1069, taraf) && !AsamaHelper.AsamaVarmi(149, 1069, taraf))
                    {
                        asama = new AV001_TDIE_BIL_ASAMA();
                        mFoy.AsamaDoldur(asama);
                        asama.ASAMA_KOD_ID = 149;
                        asama.ASAMA_ALT_KOD_ID = 1069;
                        asama.ASAMA_TARIHI = taraf.SULH_TARIHI;
                        asama.ASAMA_KONU = "Sulh";
                        asamalar.Add(asama);
                    }
                }

                #endregion

                #region Eðer Takip Tarihine Eþit ancak Haciz ve Ýtiraz Yoksa 149 - 1070

                if (taraf.SULH_TARIHI.HasValue && mFoy.TAKIP_TARIHI >= taraf.SULH_TARIHI
                    && !ucIcraTarafGelismeleri.DosyadaItýrazVarmi(mFoy) &&
                    !ucIcraTarafGelismeleri.DosyadaHacizVarmi(mFoy))
                {
                    if (!AsamaHelper.BuAsamaOncedenVarmi(149, 1070, taraf) && !AsamaHelper.AsamaVarmi(149, 1070, taraf))
                    {
                        asama = new AV001_TDIE_BIL_ASAMA();
                        mFoy.AsamaDoldur(asama);
                        asama.ASAMA_KOD_ID = 149;
                        asama.ASAMA_ALT_KOD_ID = 1069;
                        asama.ASAMA_TARIHI = taraf.SULH_TARIHI;
                        asama.ASAMA_KONU = "Sulh";
                        asamalar.Add(asama);
                    }
                }

                #endregion

                #region Eðer Takipten Sonra ve Hacizden Sonra ise 149 - 1071

                if (ucIcraTarafGelismeleri.DosyadaHacizVarmi(mFoy))
                {
                    mFoy.AV001_TI_BIL_HACIZ_MASTERCollection.Sort("HACIZ_TARIHI ASC");

                    DateTime HacizTarihi = mFoy.AV001_TI_BIL_HACIZ_MASTERCollection[0].HACIZ_TARIHI;

                    if (mFoy.SULH_TARIHI > HacizTarihi && mFoy.SULH_TARIHI > mFoy.TAKIP_TARIHI &&
                        !AsamaHelper.BuAsamaOncedenVarmi(149, 1071, taraf) && !AsamaHelper.AsamaVarmi(149, 1071, taraf))
                    {
                        asama = new AV001_TDIE_BIL_ASAMA();
                        mFoy.AsamaDoldur(asama);
                        asama.ASAMA_KOD_ID = 149;
                        asama.ASAMA_ALT_KOD_ID = 1071;
                        asama.ASAMA_TARIHI = taraf.SULH_TARIHI;
                        asama.ASAMA_KONU = "Sulh";
                        asamalar.Add(asama);
                    }
                }

                #endregion

                #region Eðer Takip Tarihi ve Ýtiraz Tarihi Var ise 149 - 1072

                DateTime tmpTarih = DateTime.MinValue;
                if (ucIcraTarafGelismeleri.DosyadaItýrazVarmi(mFoy) && mFoy.TAKIP_TARIHI.HasValue)
                {
                    if (ucIcraTarafGelismeleri.ItirazGetir(mFoy) != null)
                        tmpTarih = ucIcraTarafGelismeleri.ItirazGetir(mFoy).ITIRAZ_TARIHI;
                }

                if (tmpTarih > DateTime.MinValue && !AsamaHelper.BuAsamaOncedenVarmi(149, 1072, taraf)
                    && !AsamaHelper.AsamaVarmi(149, 1072, taraf))
                {
                    asama = new AV001_TDIE_BIL_ASAMA();
                    mFoy.AsamaDoldur(asama);
                    asama.ASAMA_KOD_ID = 149;
                    asama.ASAMA_ALT_KOD_ID = 1072;

                    #region <CC-20090806>

                    // taraf.SULH_TARIHI olan alan tmpTarih olarak deðiþtirldi.

                    #endregion </CC-20090806>

                    asama.ASAMA_TARIHI = tmpTarih;
                    asama.ASAMA_KONU = "Sulh";
                    asamalar.Add(asama);
                }

                #endregion

                #region Protokol Aþamasý 116 - 122

                if (taraf.PROTOKOL_TARIHI.HasValue && !AsamaHelper.BuAsamaOncedenVarmi(116, 122, taraf) &&
                    !AsamaHelper.AsamaVarmi(116, 122, taraf))
                {
                    asama = new AV001_TDIE_BIL_ASAMA();
                    mFoy.AsamaDoldur(asama);
                    asama.ASAMA_KOD_ID = 116;
                    asama.ASAMA_ALT_KOD_ID = 122;
                    asama.ASAMA_TARIHI = taraf.PROTOKOL_TARIHI;
                    asama.ASAMA_KONU = "Protokol";
                    asamalar.Add(asama);
                }

                #endregion

                #region Rehin Açýðý Aþamasý(Geçici) 149 - 376

                if (taraf.GECICI_REHIN_ACIGI_TARIHI.HasValue &&
                    !AsamaHelper.BuAsamaOncedenVarmi(149, 376, taraf) && !AsamaHelper.AsamaVarmi(149, 376, taraf))
                {
                    asama = new AV001_TDIE_BIL_ASAMA();
                    mFoy.AsamaDoldur(asama);
                    asama.ASAMA_KOD_ID = 149;
                    asama.ASAMA_ALT_KOD_ID = 376;
                    asama.ASAMA_TARIHI = taraf.GECICI_REHIN_ACIGI_TARIHI;
                    asama.ASAMA_KONU = "Rehin Açýðý (Geçici)";
                    asamalar.Add(asama);
                }

                #endregion

                #region Rehin Açýðý Aþamasý(Kesin) 149 - 1075

                if (taraf.KESIN_REHIN_ACIGI_TARIHI.HasValue &&
                    !AsamaHelper.BuAsamaOncedenVarmi(149, 1075, taraf) && !AsamaHelper.AsamaVarmi(149, 1075, taraf))
                {
                    asama = new AV001_TDIE_BIL_ASAMA();
                    mFoy.AsamaDoldur(asama);
                    asama.ASAMA_KOD_ID = 149;
                    asama.ASAMA_ALT_KOD_ID = 1075;
                    asama.ASAMA_TARIHI = taraf.KESIN_REHIN_ACIGI_TARIHI;
                    asama.ASAMA_KONU = "Rehin Açýðý (Kesin)";
                    asamalar.Add(asama);
                }

                #endregion

                if (asama != null)
                {
                    StringBuilder aciklama = AsamaHelper.AciklamaGetir(mFoy,
                                                                       BelgeUtil.Inits.CariIsmiGetir(taraf.CARI_ID.Value),
                                                                       asama.ASAMA_TARIHI.Value.ToShortDateString());
                    aciklama.Append(" ");
                    aciklama.Append(asama.ASAMA_KONU);
                    aciklama.Append(" kararý verilmiþtir.");
                    asama.ASAMA_ACIKLAMA = aciklama.ToString();

                    foreach (AV001_TI_BIL_FOY_TARAF fTrf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                    {
                        AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                        asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
                        asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID;
                        asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
                        asmTaraf.SIFAT_IDSource = BelgeUtil.Inits.TarafSifatGetir(asmTaraf.SIFAT_ID);
                        asmTaraf.ASAMAYI_YAPAN_MI = fTrf.TAKIP_EDEN_MI;
                        asmTaraf.MAHKEME_MI = fTrf.TAKIP_EDEN_MI;
                        if (fTrf.TAKIP_EDEN_MI || taraf == fTrf)
                        {
                            asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                        }
                    }
                    foreach (AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                    {
                        if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                        {
                            AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                            aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                            asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                        }
                    }

                    taraf.MyAsamaList.Add(asama);
                    mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    asama.Dispose();
                }
            }

            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in mFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF taraf in neden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                {
                    #region Ýhtar Aþamasý 8-13

                    if (taraf.IHTAR_TARIHI.HasValue && !AsamaHelper.BuAsamaOncedenVarmi(8, 13, taraf) &&
                        !AsamaHelper.AsamaVarmi(8, 13, taraf))
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        mFoy.AsamaDoldur(asama);
                        asama.ASAMA_KOD_ID = 8;
                        asama.ASAMA_ALT_KOD_ID = 13;
                        asama.ASAMA_TARIHI = taraf.IHTAR_TARIHI;
                        asama.ASAMA_KONU = "Ýhtar Aþamasý";
                        asama.ASAMA_ACIKLAMA = String.Format("Ýlgili borçluya ihtar gönderilmiþtir.");
                        foreach (AV001_TI_BIL_FOY_TARAF fTrf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                            asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
                            asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID;
                            asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
                            asmTaraf.ASAMAYI_YAPAN_MI = fTrf.TAKIP_EDEN_MI;
                            if (fTrf.TAKIP_EDEN_MI ||
                                (taraf.TARAF_CARI_ID > 0 && fTrf.CARI_ID.HasValue &&
                                 taraf.TARAF_CARI_ID == fTrf.CARI_ID.Value))
                            {
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }
                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }
                        taraf.MyAsamaList.Add(asama);
                        neden.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }

                    #endregion

                    #region Ýhtar Teblig Aþamasý 8-113

                    if (taraf.IHTAR_TEBLIG_TARIHI.HasValue && !AsamaHelper.BuAsamaOncedenVarmi(8, 113, taraf) &&
                        !AsamaHelper.AsamaVarmi(8, 113, taraf))
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        mFoy.AsamaDoldur(asama);
                        asama.ASAMA_KOD_ID = 8;
                        asama.ASAMA_ALT_KOD_ID = 113;
                        asama.ASAMA_TARIHI = taraf.IHTAR_TEBLIG_TARIHI;
                        asama.ASAMA_KONU = "Ýhtar Teblið Aþamasý";
                        asama.ASAMA_ACIKLAMA = String.Format("Ýlgili borçluya ihtar teblið edilmiþtir.");
                        foreach (AV001_TI_BIL_FOY_TARAF fTrf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                            asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
                            asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID;
                            asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
                            asmTaraf.ASAMAYI_YAPAN_MI = fTrf.TAKIP_EDEN_MI;
                            if (fTrf.TAKIP_EDEN_MI ||
                                (taraf.TARAF_CARI_ID > 0 && fTrf.CARI_ID.HasValue &&
                                 taraf.TARAF_CARI_ID == fTrf.CARI_ID.Value))
                            {
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }
                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }
                        taraf.MyAsamaList.Add(asama);
                        neden.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }

                    #endregion

                    #region Temerrüt Aþamasý 8-114

                    if (taraf.TEMERRUT_TARIHI.HasValue && !AsamaHelper.BuAsamaOncedenVarmi(8, 114, taraf) &&
                        !AsamaHelper.AsamaVarmi(8, 114, taraf))
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        mFoy.AsamaDoldur(asama);
                        asama.ASAMA_KOD_ID = 8;
                        asama.ASAMA_ALT_KOD_ID = 114;
                        asama.ASAMA_TARIHI = taraf.TEMERRUT_TARIHI;
                        asama.ASAMA_KONU = "Temerrüt Aþamasý";
                        asama.ASAMA_ACIKLAMA = String.Format("Ýlgili borçlu temerrüde düþmüþtür.");
                        foreach (AV001_TI_BIL_FOY_TARAF fTrf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                            asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
                            asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID;
                            asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
                            asmTaraf.ASAMAYI_YAPAN_MI = fTrf.TAKIP_EDEN_MI;
                            if (fTrf.TAKIP_EDEN_MI ||
                                (taraf.TARAF_CARI_ID > 0 && fTrf.CARI_ID.HasValue &&
                                 taraf.TARAF_CARI_ID == fTrf.CARI_ID.Value))
                            {
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }
                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }
                        taraf.MyAsamaList.Add(asama);
                        neden.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }

                    #endregion

                    #region Protokol Aþamasý 122-116

                    if (taraf.PROTOKOL_TARIHI.HasValue && !AsamaHelper.BuAsamaOncedenVarmi(122, 116, taraf) &&
                        !AsamaHelper.AsamaVarmi(122, 116, taraf))
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        mFoy.AsamaDoldur(asama);
                        asama.ASAMA_KOD_ID = 122;
                        asama.ASAMA_ALT_KOD_ID = 116;
                        asama.ASAMA_TARIHI = taraf.PROTOKOL_TARIHI;
                        asama.ASAMA_KONU = "Protokol Aþamasý";
                        asama.ASAMA_ACIKLAMA = String.Format(
                            "Ýlgili borçlu ile {0} {1} tutarýnda protokol yapýlmýþtýr.", taraf.PROTOKOL_MIKTARI,
                            DovizHelper.CevirString(taraf.PROTOKOL_MIKTARI_DOVIZ_ID.Value));

                        foreach (AV001_TI_BIL_FOY_TARAF fTrf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                            asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
                            asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID;
                            asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
                            asmTaraf.ASAMAYI_YAPAN_MI = fTrf.TAKIP_EDEN_MI;
                            if (fTrf.TAKIP_EDEN_MI ||
                                (taraf.TARAF_CARI_ID > 0 && fTrf.CARI_ID.HasValue &&
                                 taraf.TARAF_CARI_ID == fTrf.CARI_ID.Value))
                            {
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }
                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }
                        taraf.MyAsamaList.Add(asama);
                        neden.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }

                    #endregion

                    #region Sulh Aþamasý 114-115

                    if (taraf.SULH_TARIHI.HasValue && !AsamaHelper.BuAsamaOncedenVarmi(114, 115, taraf) &&
                        !AsamaHelper.AsamaVarmi(114, 115, taraf))
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        mFoy.AsamaDoldur(asama);
                        asama.ASAMA_KOD_ID = 114;
                        asama.ASAMA_ALT_KOD_ID = 115;
                        asama.ASAMA_TARIHI = taraf.SULH_TARIHI;
                        asama.ASAMA_KONU = "Sulh Aþamasý";
                        asama.ASAMA_ACIKLAMA = String.Format("Ýlgili borçlu ile {0} tarihinde sulh yapýlmýþtýr.",
                                                             taraf.SULH_TARIHI.Value.ToShortDateString());

                        foreach (AV001_TI_BIL_FOY_TARAF fTrf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                            asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
                            asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID;
                            asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
                            asmTaraf.ASAMAYI_YAPAN_MI = fTrf.TAKIP_EDEN_MI;
                            if (fTrf.TAKIP_EDEN_MI ||
                                (taraf.TARAF_CARI_ID > 0 && fTrf.CARI_ID.HasValue &&
                                 taraf.TARAF_CARI_ID == fTrf.CARI_ID.Value))
                            {
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }
                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }
                        taraf.MyAsamaList.Add(asama);
                        neden.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }

                    #endregion

                    #region Zaman Aþýmý Aþamasý 123-118

                    if (taraf.ZAMAN_ASIMI_TARIHI.HasValue && !AsamaHelper.BuAsamaOncedenVarmi(123, 118, taraf) &&
                        !AsamaHelper.AsamaVarmi(123, 118, taraf))
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        mFoy.AsamaDoldur(asama);
                        asama.ASAMA_KOD_ID = 123;
                        asama.ASAMA_ALT_KOD_ID = 118;
                        asama.ASAMA_TARIHI = taraf.ZAMAN_ASIMI_TARIHI;
                        asama.ASAMA_KONU = "Zaman Aþýmý Aþamasý";
                        asama.ASAMA_ACIKLAMA =
                            String.Format("Borçlu ile ilgili alacak nedeni {0} tarihinde zaman aþýmýna uðramýþtýr.",
                                          taraf.ZAMAN_ASIMI_TARIHI.Value.ToShortDateString());

                        foreach (AV001_TI_BIL_FOY_TARAF fTrf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                            asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
                            asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID;
                            asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
                            asmTaraf.ASAMAYI_YAPAN_MI = (taraf.TARAF_CARI_ID > 0 && fTrf.CARI_ID.HasValue &&
                                                         taraf.TARAF_CARI_ID == fTrf.CARI_ID.Value);

                            if (fTrf.TAKIP_EDEN_MI || (taraf.TARAF_CARI_ID > 0 && fTrf.CARI_ID.HasValue &&
                                                       taraf.TARAF_CARI_ID == fTrf.CARI_ID.Value))
                            {
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }
                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }
                        taraf.MyAsamaList.Add(asama);
                        neden.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }

                    #endregion

                    #region Kesinleþme(Borca Ýtiraz Süresinin Sona Ermesi) 32-279

                    if (taraf.KESINLESME_TARIHI.HasValue && !AsamaHelper.BuAsamaOncedenVarmi(32, 279, taraf) &&
                        !AsamaHelper.AsamaVarmi(32, 279, taraf) &&
                        ucIcraTarafGelismeleri.GecikmisItirazlariBul(mFoy).Count > 0)
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        mFoy.AsamaDoldur(asama);
                        asama.ASAMA_KOD_ID = 32;
                        asama.ASAMA_ALT_KOD_ID = 279;
                        asama.ASAMA_TARIHI = taraf.KESINLESME_TARIHI;
                        asama.ASAMA_KONU = "Kesinleþme";
                        asama.ASAMA_ACIKLAMA =
                            String.Format("Borçlu ile ilgili alacak nedeni {0} tarihinde kesinleþmiþtir.",
                                          taraf.KESINLESME_TARIHI.Value.ToShortDateString());

                        foreach (AV001_TI_BIL_FOY_TARAF fTrf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                            asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
                            asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID;
                            asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
                            asmTaraf.ASAMAYI_YAPAN_MI = (taraf.TARAF_CARI_ID > 0 && fTrf.CARI_ID.HasValue &&
                                                         taraf.TARAF_CARI_ID == fTrf.CARI_ID.Value);

                            if (fTrf.TAKIP_EDEN_MI || (taraf.TARAF_CARI_ID > 0 && fTrf.CARI_ID.HasValue &&
                                                       taraf.TARAF_CARI_ID == fTrf.CARI_ID.Value))
                            {
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }
                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }
                        taraf.MyAsamaList.Add(asama);
                        neden.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }

                    #endregion

                    #region Kesinleþme(Mahkeme Kararý Ýbraz Edildi) 32-280

                    if (taraf.KESINLESME_TARIHI.HasValue && !AsamaHelper.BuAsamaOncedenVarmi(32, 280, taraf) &&
                        !AsamaHelper.AsamaVarmi(32, 280, taraf) &&
                        ucIcraTarafGelismeleri.KesinlesmeDurumu != KesinlesmeDurumu.TakipKesinlesmedi)
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        mFoy.AsamaDoldur(asama);
                        asama.ASAMA_KOD_ID = 32;
                        asama.ASAMA_ALT_KOD_ID = 280;
                        asama.ASAMA_TARIHI = taraf.KESINLESME_TARIHI;
                        asama.ASAMA_KONU = "Kesinleþme";
                        asama.ASAMA_ACIKLAMA =
                            String.Format("Borçlu ile ilgili alacak nedeni {0} tarihinde kesinleþmiþtir.",
                                          taraf.KESINLESME_TARIHI.Value.ToShortDateString());

                        foreach (AV001_TI_BIL_FOY_TARAF fTrf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                            asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
                            asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID;
                            asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
                            asmTaraf.ASAMAYI_YAPAN_MI = (taraf.TARAF_CARI_ID > 0 && fTrf.CARI_ID.HasValue &&
                                                         taraf.TARAF_CARI_ID == fTrf.CARI_ID.Value);

                            if (fTrf.TAKIP_EDEN_MI || (taraf.TARAF_CARI_ID > 0 && fTrf.CARI_ID.HasValue &&
                                                       taraf.TARAF_CARI_ID == fTrf.CARI_ID.Value))
                            {
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }
                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }
                        taraf.MyAsamaList.Add(asama);
                        neden.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }

                    #endregion
                }
            }

            #region Otomatik Ilisikiden Asama Üretme (TebligatMuhatapUzerinden)

            foreach (AV001_TDI_BIL_TEBLIGAT tebligat in mFoy.AV001_TDI_BIL_TEBLIGATCollection)
            {
                TList<TDIE_KOD_ASAMA_ILISKI> iliskisTebligat =
                    DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADITEBLIGAT_KONU_ID(
                        "AV001_TDI_BIL_TEBLIGAT_MUHATAP", tebligat.KONU_ID);
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(iliskisTebligat,
                                                                      false, DeepLoadType.IncludeChildren,
                                                                      typeof(TDIE_KOD_ASAMA_ALT),
                                                                      typeof(TDI_KOD_TEBLIGAT_KONU));
                foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskisTebligat)
                {
                    foreach (AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatap in tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection
                        )
                    {
                        if (iliski.AsamaDegerKarsilastir(muhatap) &&
                            !AsamaHelper.BuAsamaOncedenVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                             iliski.ALT_ASAMA_KOD_ID.Value, muhatap) &&
                            !AsamaHelper.AsamaVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                    iliski.ALT_ASAMA_KOD_ID.Value, muhatap))
                        {
                            AV001_TDIE_BIL_ASAMA asama = tebligat.AsamaGetir();
                            if (iliski.TEBLIGAT_KONU_IDSource != null)
                                asama.ASAMA_ACIKLAMA = String.Format("Muhataba {0} konulu tebligat {1}",
                                                                     iliski.TEBLIGAT_KONU_IDSource.KONU,
                                                                     iliski.AsamaAciklamaGetir(muhatap));
                            asama.ASAMA_KONU = iliski.TEBLIGAT_KONU_IDSource.KONU;
                            asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID;
                            asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;
                            asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
                            asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(muhatap);
                            foreach (
                                AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in
                                    mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                            {
                                if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                                {
                                    AV001_TDIE_BIL_ASAMA_SORUMLU aSrm =
                                        new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                    aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                    asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                                }
                            }
                            foreach (
                                AV001_TDI_BIL_TEBLIGAT_YAPAN yapan in tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection)
                            {
                                AV001_TDIE_BIL_ASAMA_TARAF trf = asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                                trf.CARI_ID = yapan.YAPAN_CARI_ID;
                                //trf.SIFAT_ID = 1;//TODO:yukardaki adamýn sýfatý gelicek buraya
                                trf.ASAMAYI_YAPAN_MI = true;
                            }
                            AV001_TDIE_BIL_ASAMA_TARAF trf2 = asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                            trf2.CARI_ID = muhatap.MUHATAP_CARI_ID;
                            //trf2.SIFAT_ID = 1;//TODO:yukardaki adamýn sýfatý gelicek buraya
                            trf2.ASAMAYI_YAPAN_MI = false;
                            muhatap.MyAsamaList.Add(asama);
                            mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                        }
                    }
                }
            }

            #endregion

            #region Otomatik Iliskiden Asama Üretme (Ödeme)

            TList<TDIE_KOD_ASAMA_ILISKI> iliskisOdeme =
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI("AV001_TI_BIL_BORCLU_ODEME");
            DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(iliskisOdeme,
                                                                  false, DeepLoadType.IncludeChildren,
                                                                  typeof(TDIE_KOD_ASAMA_ALT),
                                                                  typeof(TDI_KOD_TEBLIGAT_KONU));
            foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskisOdeme)
            {
                foreach (AV001_TI_BIL_BORCLU_ODEME odeme in mFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
                {
                    if (iliski.AsamaDegerKarsilastir(odeme) &&
                        !AsamaHelper.BuAsamaOncedenVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                         iliski.ALT_ASAMA_KOD_ID.Value, odeme) &&
                        !AsamaHelper.AsamaVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID, iliski.ALT_ASAMA_KOD_ID.Value,
                                                odeme))
                    {
                        AV001_TDIE_BIL_ASAMA asama = mFoy.AsamaGetir();
                        asama.ASAMA_ACIKLAMA = iliski.AsamaAciklamaGetir(odeme);
                        asama.ASAMA_KONU = "Borçlu Ödemesi";
                        asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID;
                        asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;
                        asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
                        asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(odeme);

                        if (true)
                        {
                            AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();
                            aSrm.CARI_ID = odeme.BORCLU_ADINA_ODENEN_CARI_ID.Value;
                            asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                        }

                        if (true)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF trf = asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                            trf.CARI_ID = odeme.ODEYEN_CARI_ID;
                            trf.ASAMAYI_YAPAN_MI = true;
                        }

                        foreach (AV001_TI_BIL_FOY_TARAF fTrf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            if (fTrf.TAKIP_EDEN_MI)
                            {
                                AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                                asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
                                asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID;
                                asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
                                asmTaraf.ASAMAYI_YAPAN_MI = false;
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                        odeme.MyAsamaList.Add(asama);
                    }
                }
            }

            #endregion

            #region Otomatik Iliskiden Asama Üretme (Mahsup)

            TList<TDIE_KOD_ASAMA_ILISKI> iliskisMahsup =
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI("AV001_TI_BIL_BORCLU_MAHSUP");
            DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(iliskisMahsup,
                                                                  false, DeepLoadType.IncludeChildren,
                                                                  typeof(TDIE_KOD_ASAMA_ALT),
                                                                  typeof(TDI_KOD_TEBLIGAT_KONU));
            foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskisMahsup)
            {
                foreach (AV001_TI_BIL_BORCLU_MAHSUP mahsup in mFoy.AV001_TI_BIL_BORCLU_MAHSUPCollection)
                {
                    if (iliski.AsamaDegerKarsilastir(mahsup) &&
                        !AsamaHelper.BuAsamaOncedenVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                         iliski.ALT_ASAMA_KOD_ID.Value, mahsup) &&
                        !AsamaHelper.AsamaVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID, iliski.ALT_ASAMA_KOD_ID.Value,
                                                mahsup))
                    {
                        AV001_TDIE_BIL_ASAMA asama = mFoy.AsamaGetir();
                        asama.ASAMA_ACIKLAMA = iliski.AsamaAciklamaGetir(mahsup);
                        asama.ASAMA_KONU = "Borçlu Mahsup";
                        asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID;
                        asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;
                        asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
                        asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(mahsup);

                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }

                        foreach (AV001_TI_BIL_FOY_TARAF fTrf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                            asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
                            asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID;

                            asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
                            asmTaraf.ASAMAYI_YAPAN_MI = fTrf.TAKIP_EDEN_MI;
                            asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                        }
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                        mahsup.MyAsamaList.Add(asama);
                    }
                }
            }

            #endregion

            #region Otomatik Iliskiden Asama Üretme (Feragat)

            TList<TDIE_KOD_ASAMA_ILISKI> iliskisFeragat =
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI("AV001_TI_BIL_FERAGAT");
            DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(iliskisFeragat,
                                                                  false, DeepLoadType.IncludeChildren,
                                                                  typeof(TDIE_KOD_ASAMA_ALT),
                                                                  typeof(TDI_KOD_TEBLIGAT_KONU));
            foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskisFeragat)
            {
                foreach (AV001_TI_BIL_FERAGAT feragat in mFoy.AV001_TI_BIL_FERAGATCollection)
                {
                    if (iliski.AsamaDegerKarsilastir(feragat) &&
                        !AsamaHelper.BuAsamaOncedenVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                         iliski.ALT_ASAMA_KOD_ID.Value, feragat) &&
                        !AsamaHelper.AsamaVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID, iliski.ALT_ASAMA_KOD_ID.Value,
                                                feragat))
                    {
                        AV001_TDIE_BIL_ASAMA asama = mFoy.AsamaGetir();
                        asama.ASAMA_ACIKLAMA = iliski.AsamaAciklamaGetir(feragat);
                        asama.ASAMA_KONU = "Alacaktan Feragat";
                        asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID;
                        asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;
                        asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
                        asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(feragat);

                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }

                        foreach (AV001_TI_BIL_FOY_TARAF fTrf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                            asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
                            asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID;
                            asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
                            asmTaraf.ASAMAYI_YAPAN_MI = fTrf.TAKIP_EDEN_MI;
                            asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                        }
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                        feragat.MyAsamaList.Add(asama);
                    }
                }
            }

            #endregion

            #region Otomatik Iliskiden Asama Üretime(Haciz-Istihkak-Istirak-KiymetTakdiri)

            TList<TDIE_KOD_ASAMA_ILISKI> iliskisHaciz =
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI("AV001_TI_BIL_HACIZ_MASTER");
            DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(iliskisHaciz,
                                                                  false, DeepLoadType.IncludeChildren,
                                                                  typeof(TDIE_KOD_ASAMA_ALT),
                                                                  typeof(TDI_KOD_TEBLIGAT_KONU));
            TList<TDIE_KOD_ASAMA_ILISKI> iliskisIstihkak =
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI("AV001_TI_BIL_ISTIHKAK");
            DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(iliskisIstihkak,
                                                                  false, DeepLoadType.IncludeChildren,
                                                                  typeof(TDIE_KOD_ASAMA_ALT),
                                                                  typeof(TDI_KOD_TEBLIGAT_KONU));
            TList<TDIE_KOD_ASAMA_ILISKI> iliskisIstirak =
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI("AV001_TI_BIL_HACIZ_ISTIRAK");
            DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(iliskisIstirak,
                                                                  false, DeepLoadType.IncludeChildren,
                                                                  typeof(TDIE_KOD_ASAMA_ALT),
                                                                  typeof(TDI_KOD_TEBLIGAT_KONU));

            TList<TDIE_KOD_ASAMA_ILISKI> iliskisKTakdiri =
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI("AV001_TI_BIL_KIYMET_TAKDIRI");
            DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(iliskisKTakdiri,
                                                                  false, DeepLoadType.IncludeChildren,
                                                                  typeof(TDIE_KOD_ASAMA_ALT),
                                                                  typeof(TDI_KOD_TEBLIGAT_KONU));

            foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskisHaciz)
            {
                #region Master

                foreach (AV001_TI_BIL_HACIZ_MASTER haciz in mFoy.AV001_TI_BIL_HACIZ_MASTERCollection)
                {
                    if (iliski.AsamaDegerKarsilastir(haciz) &&
                        !AsamaHelper.BuAsamaOncedenVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                         iliski.ALT_ASAMA_KOD_ID.Value, haciz) &&
                        !AsamaHelper.AsamaVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID, iliski.ALT_ASAMA_KOD_ID.Value,
                                                haciz))
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        if (haciz.TALIMAT_MI)
                        {
                            asama.ESAS_NO = haciz.TALIMAT_ESAS_NO;
                            asama.ADLI_BIRIM_ADLIYE_ID = haciz.TALIMAT_ADLI_BIRIM_ADLIYE_ID;
                            asama.ADLI_BIRIM_GOREV_ID = haciz.TALIMAT_ADLI_BIRIM_GOREV_ID;
                            asama.ADLI_BIRIM_NO_ID = haciz.TALIMAT_ADLI_BIRIM_NO_ID;
                        }
                        else
                        {
                            mFoy.AsamaDoldur(asama);
                        }

                        #region Asama Aciklama

                        if (!string.IsNullOrEmpty(iliski.ACIKLAMA))
                        {
                            asama.ASAMA_ACIKLAMA = iliski.AsamaAciklamaGetir(haciz);
                        }
                        else if (!haciz.HACIZE_KABIL_MAL_YOK)
                        {
                            string hacizYediEminAdamlar = String.Empty;
                            string hacizMallarOzet = String.Empty;
                            List<string> listYediEmmiler = new List<string>();
                            List<ParaVeDovizId> hacizliMenkul = new List<ParaVeDovizId>();
                            List<ParaVeDovizId> hacizliArac = new List<ParaVeDovizId>();

                            int hacizliGayriMenkul = new int();
                            foreach (AV001_TI_BIL_HACIZ_CHILD child in haciz.AV001_TI_BIL_HACIZ_CHILDCollection)
                            {
                                IcraMalKategori kategori = IcraMalKategori.Null;
                                try
                                {
                                    kategori = (IcraMalKategori)child.HACIZLI_MAL_KATEGORI_ID;
                                }
                                catch (Exception)
                                {
                                }
                                switch (kategori)
                                {
                                    case IcraMalKategori.Arac:
                                        hacizliArac.Add(new ParaVeDovizId(child.HACIZLI_MAL_DEGERI,
                                                                          child.HACIZLI_MAL_DEGERI_DOVIZ_ID));
                                        break;
                                    case IcraMalKategori.Menkul:
                                        hacizliMenkul.Add(new ParaVeDovizId(child.HACIZLI_MAL_DEGERI,
                                                                            child.HACIZLI_MAL_DEGERI_DOVIZ_ID));
                                        break;
                                    case IcraMalKategori.GayriMenkul:
                                        hacizliGayriMenkul++;
                                        break;
                                    default:
                                        break;
                                }
                                if (child.YEDIEMIN_CARI_IDSource != null &&
                                    listYediEmmiler.Contains(child.YEDIEMIN_CARI_IDSource.AD))
                                {
                                    listYediEmmiler.Add(child.YEDIEMIN_CARI_IDSource.AD);
                                }
                            }
                            if (hacizliMenkul.Count > 0)
                                hacizMallarOzet += String.Format("{0} kalem {1:2} TL deðerinde menkul, ",
                                                                 hacizliMenkul.Count,
                                                                 ParaVeDovizId.Topla(hacizliMenkul,
                                                                                     haciz.HACIZ_TARIHI).Para);
                            if (hacizliArac.Count > 0)
                                hacizMallarOzet += String.Format("{0} kalem {1:2} TL deðerinde araç, ",
                                                                 hacizliArac.Count,
                                                                 ParaVeDovizId.Topla(hacizliArac,
                                                                                     haciz.HACIZ_TARIHI).Para);
                            if (hacizliGayriMenkul > 0)
                                hacizMallarOzet += String.Format("{0} kalem gayrimenkul", hacizliGayriMenkul);
                            foreach (string eminamca in listYediEmmiler)
                            {
                                hacizYediEminAdamlar += eminamca + ",";
                            }
                            if (hacizYediEminAdamlar.EndsWith(","))
                                hacizYediEminAdamlar.Remove(hacizYediEminAdamlar.Length - 1, 1);
                            string hacizEkMi = haciz.GECICI_HACIZ_MI ? "ek " : "";
                            if (hacizliMenkul.Count == 0 && hacizliArac.Count == 0 && hacizliGayriMenkul > 0)
                            {
                                asama.ASAMA_ACIKLAMA =
                                    String.Format("Borçluya ait {0} adet gayrimenkulun kaydýna haciz þerhi konuldu",
                                                  hacizliGayriMenkul);
                            }
                            else if (haciz.MUHAFAZALI_KAYIT_VAR_MI)
                            {
                                hacizMallarOzet += String.Format("(Toplam deðeri:{0} TL)", haciz.HACIZ_TOPLAM_DEGERI);
                                asama.ASAMA_ACIKLAMA = String.Format("Borçlunun ({0}) adresinde {1} {5} " +
                                                                     "iþlemi yapýldý. {2} haczedildi.Mallar muhafaza altýna alýndý ve {3} isimli kiþi/kiþiler e yeddiemin " +
                                                                     "olarak býrakýldý. {4}", haciz.HACIZ_ADRESI,
                                                                     haciz.BORCLU_HAZIR_MI
                                                                         ? "borçlunun huzurunda"
                                                                         : "borçlunun yokluðunda",
                                                                     hacizMallarOzet, hacizYediEminAdamlar,
                                                                     haciz.YUZUC_UYGULANDI_MI
                                                                         ? "Borçluya zabýt sureti býrakýldý"
                                                                         : "",
                                                                     haciz.TALIMAT_MI
                                                                         ? hacizEkMi + "talimat haczi"
                                                                         : hacizEkMi + "haciz"
                                    );
                            }
                            else
                            {
                                hacizMallarOzet += String.Format("(Toplam deðeri:{0} TL)", haciz.HACIZ_TOPLAM_DEGERI);
                                asama.ASAMA_ACIKLAMA = String.Format("Borçlunun ({0}) adresinde {1} {5} " +
                                                                     "iþlemi yapýldý. {2} haczedildi.Mallar {3} isimli kiþi/kiþiler e yeddiemin " +
                                                                     "olarak býrakýldý. {4}", haciz.HACIZ_ADRESI,
                                                                     haciz.BORCLU_HAZIR_MI
                                                                         ? "borçlunun huzurunda"
                                                                         : "borçlunun yokluðunda",
                                                                     hacizMallarOzet, hacizYediEminAdamlar,
                                                                     haciz.YUZUC_UYGULANDI_MI
                                                                         ? "Borçluya zabýt sureti býrakýldý"
                                                                         : "",
                                                                     haciz.TALIMAT_MI
                                                                         ? hacizEkMi + "talimat haczi"
                                                                         : hacizEkMi + "haciz"
                                    );
                            }
                        }
                        else
                        {
                            asama.ASAMA_ACIKLAMA = String.Format("Borçlunun ({0}) adresinde {1} {2} " +
                                                                 "için hacze kabil mal bulunamadý. ", haciz.HACIZ_ADRESI,
                                                                 haciz.BORCLU_HAZIR_MI
                                                                     ? "borçlunun huzurunda"
                                                                     : "borçlunun yokluðunda",
                                                                 haciz.TALIMAT_MI ? "talimat haczi" : "haciz"
                                );
                        } //TODO:yukardaki hacizli mal adetleri vs.

                        #endregion

                        asama.ASAMA_KONU = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_ADI;
                        asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID;
                        asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;
                        asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
                        asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(haciz);

                        if (haciz.HACIZ_ISTEYEN_CARI_ID > 0)
                        {
                            AV001_TDIE_BIL_ASAMA_SORUMLU sorumlu = asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.AddNew();
                            sorumlu.CARI_ID = haciz.HACIZ_ISTEYEN_CARI_ID;
                        }
                        foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            if (taraf.TAKIP_EDEN_MI)
                            {
                                AV001_TDIE_BIL_ASAMA_TARAF asmTrf = asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                                asmTrf.ASAMAYI_YAPAN_MI = true;
                                asmTrf.CARI_ID = taraf.CARI_ID.Value;
                                asmTrf.SIFAT_ID = taraf.TARAF_SIFAT_ID;
                            }
                        }
                        AV001_TDIE_BIL_ASAMA_TARAF asmYapilan = asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                        asmYapilan.ASAMAYI_YAPAN_MI = false;
                        asmYapilan.CARI_ID = haciz.HACIZ_ISTENEN_CARI_ID;
                        haciz.MyAsamaList.Add(asama);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }
                }

                #endregion
            }
            foreach (AV001_TI_BIL_HACIZ_MASTER haciz in mFoy.AV001_TI_BIL_HACIZ_MASTERCollection)
            {
                #region Child (Istihkak-Istirak-KiymetTakdiri)

                foreach (AV001_TI_BIL_HACIZ_CHILD hChild in haciz.AV001_TI_BIL_HACIZ_CHILDCollection)
                {
                    #region (Istihkak)

                    foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskisIstihkak)
                    {
                        foreach (AV001_TI_BIL_ISTIHKAK istihkak in hChild.AV001_TI_BIL_ISTIHKAKCollection)
                        {
                            if (iliski.AsamaDegerKarsilastir(istihkak) &&
                                !AsamaHelper.BuAsamaOncedenVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                                 iliski.ALT_ASAMA_KOD_ID.Value, istihkak) &&
                                !AsamaHelper.AsamaVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                        iliski.ALT_ASAMA_KOD_ID.Value,
                                                        istihkak))
                            {
                                AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                                mFoy.AsamaDoldur(asama);
                                asama.ASAMA_KONU = asama.ASAMA_ALT_KOD_IDSource.ALT_ASAMA_ADI;
                                asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID;
                                asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;
                                asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
                                asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(istihkak);
                                asama.ASAMA_ACIKLAMA = iliski.AsamaAciklamaGetir(istihkak);

                                #region Asama Taraflar

                                foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                                {
                                    if (taraf.TAKIP_EDEN_MI)
                                    {
                                        AV001_TDIE_BIL_ASAMA_TARAF asmTrf =
                                            asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                                        asmTrf.ASAMAYI_YAPAN_MI = false;
                                        asmTrf.CARI_ID = taraf.CARI_ID.Value;
                                        asmTrf.SIFAT_ID = taraf.TARAF_SIFAT_ID;
                                    }
                                }
                                AV001_TDIE_BIL_ASAMA_TARAF asmBuTrf =
                                    asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                                asmBuTrf.ASAMAYI_YAPAN_MI = true;
                                asmBuTrf.CARI_ID = istihkak.ISTIHKAK_IDDIA_EDEN_ID.Value;

                                #endregion

                                #region Asama Sorumlular

                                foreach (
                                    AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in
                                        mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                                {
                                    if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                                    {
                                        AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                        aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                        asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                                    }
                                }

                                #endregion

                                mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                                istihkak.MyAsamaList.Add(asama);
                            }
                        }
                    }

                    #endregion

                    #region (Istirak)

                    foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskisIstirak)
                    {
                        foreach (AV001_TI_BIL_HACIZ_ISTIRAK istirak in hChild.AV001_TI_BIL_HACIZ_ISTIRAKCollection)
                        {
                            if (iliski.AsamaDegerKarsilastir(istirak) &&
                                !AsamaHelper.BuAsamaOncedenVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                                 iliski.ALT_ASAMA_KOD_ID.Value, istirak) &&
                                !AsamaHelper.AsamaVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                        iliski.ALT_ASAMA_KOD_ID.Value,
                                                        istirak))
                            {
                                AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                                mFoy.AsamaDoldur(asama);
                                asama.ASAMA_KONU = asama.ASAMA_ALT_KOD_IDSource.ALT_ASAMA_ADI;
                                asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID;
                                asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;
                                asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
                                asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(istirak);
                                asama.ASAMA_ACIKLAMA = iliski.AsamaAciklamaGetir(istirak);

                                #region Asama Taraflar

                                foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                                {
                                    if (taraf.TAKIP_EDEN_MI)
                                    {
                                        AV001_TDIE_BIL_ASAMA_TARAF asmTrf =
                                            asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                                        asmTrf.ASAMAYI_YAPAN_MI = false;
                                        asmTrf.CARI_ID = taraf.CARI_ID.Value;
                                        asmTrf.SIFAT_ID = taraf.TARAF_SIFAT_ID;
                                    }
                                }
                                AV001_TDIE_BIL_ASAMA_TARAF asmBuTrf =
                                    asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                                asmBuTrf.ASAMAYI_YAPAN_MI = true;
                                asmBuTrf.CARI_ID = istirak.ISTIRAK_ISTEYEN_CARI_ID.Value;

                                #endregion

                                #region Asama Sorumlular

                                foreach (
                                    AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in
                                        mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                                {
                                    if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                                    {
                                        AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                        aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                        asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                                    }
                                }

                                #endregion

                                mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                                istirak.MyAsamaList.Add(asama);
                            }
                        }
                    }

                    #endregion

                    #region (Kýymet Takdiri)

                    foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskisKTakdiri)
                    {
                        foreach (
                            AV001_TI_BIL_KIYMET_TAKDIRI kiymetTakdiri in hChild.AV001_TI_BIL_KIYMET_TAKDIRICollection)
                        {
                            if (iliski.AsamaDegerKarsilastir(kiymetTakdiri) &&
                                !AsamaHelper.BuAsamaOncedenVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                                 iliski.ALT_ASAMA_KOD_ID.Value, kiymetTakdiri) &&
                                !AsamaHelper.AsamaVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                        iliski.ALT_ASAMA_KOD_ID.Value,
                                                        kiymetTakdiri))
                            {
                                AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                                mFoy.AsamaDoldur(asama);

                                #region <YY-20090612>

                                //Burda bir patlama sözkonusuydu AÇ tespit etti ben çözdüm
                                asama.ASAMA_KONU = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_ADI;

                                #endregion </YY-20090612>

                                asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID;
                                asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;
                                asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
                                asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(kiymetTakdiri);
                                asama.ASAMA_ACIKLAMA = iliski.AsamaAciklamaGetir(kiymetTakdiri);

                                #region Asama Taraflar

                                foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                                {
                                    AV001_TDIE_BIL_ASAMA_TARAF asmTrf =
                                        asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                                    asmTrf.ASAMAYI_YAPAN_MI = taraf.TAKIP_EDEN_MI;
                                    asmTrf.CARI_ID = taraf.CARI_ID.Value;
                                    asmTrf.SIFAT_ID = taraf.TARAF_SIFAT_ID;
                                }

                                #endregion

                                #region Asama Sorumlular

                                foreach (
                                    AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in
                                        mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                                {
                                    if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                                    {
                                        AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                        aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                        asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                                    }
                                }

                                #endregion

                                mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                                kiymetTakdiri.MyAsamaList.Add(asama);
                            }
                        }
                    }

                    #endregion
                }

                #endregion
            }

            #endregion

            #region Otomatik Iliskiden Asama Üretime(Satýþ)

            //Burdaki aþamanýn düzgün üretilip üretilmediðine bakýlacak
            TList<TDIE_KOD_ASAMA_ILISKI> iliskisSatis =
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI("AV001_TI_BIL_SATIS_MASTER");
            DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(iliskisSatis,
                                                                  false, DeepLoadType.IncludeChildren,
                                                                  typeof(TDIE_KOD_ASAMA_ALT),
                                                                  typeof(TDI_KOD_TEBLIGAT_KONU));
            foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskisSatis)
            {
                #region Master

                foreach (AV001_TI_BIL_SATIS_MASTER satis in mFoy.AV001_TI_BIL_SATIS_MASTERCollection)
                {
                    if (iliski.AsamaDegerKarsilastir(satis) &&
                        !AsamaHelper.BuAsamaOncedenVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                         iliski.ALT_ASAMA_KOD_ID.Value, satis) &&
                        !AsamaHelper.AsamaVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID, iliski.ALT_ASAMA_KOD_ID.Value,
                                                satis))
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        if (satis.TALIMAT_MI)
                        {
                            asama.ADLI_BIRIM_ADLIYE_ID = satis.TALIMAT_ADLI_BIRIM_ADLIYE_ID;
                            asama.ADLI_BIRIM_GOREV_ID = satis.TALIMAT_ADLI_BIRIM_GOREV_ID;
                            asama.ADLI_BIRIM_NO_ID = satis.TALIMAT_ADLI_BIRIM_NO_ID;
                        }
                        else
                        {
                            mFoy.AsamaDoldur(asama);
                        }

                        #region Asama Aciklama

                        if (!string.IsNullOrEmpty(iliski.ACIKLAMA))
                        {
                            asama.ASAMA_ACIKLAMA = iliski.AsamaAciklamaGetir(satis);
                        }
                        else
                        {
                            //TODO:SAÐLAM KONTROL

                            string hacizYediEminAdamlar = String.Empty;
                            string hacizMallarOzet = String.Empty;
                            List<string> listYediEmmiler = new List<string>();
                            List<ParaVeDovizId> hacizliMenkul = new List<ParaVeDovizId>();
                            List<ParaVeDovizId> hacizliArac = new List<ParaVeDovizId>();

                            List<ParaVeDovizId> hacizliGayriMenkul = new List<ParaVeDovizId>();
                            foreach (AV001_TI_BIL_SATIS_CHILD child in satis.AV001_TI_BIL_SATIS_CHILDCollection)
                            {
                                IcraMalKategori kategori = IcraMalKategori.Null;
                                try
                                {
                                    kategori = (IcraMalKategori)child.HACIZLI_MAL_KAT_ID;
                                }
                                catch (Exception)
                                {
                                }
                                switch (kategori)
                                {
                                    case IcraMalKategori.Arac:
                                        hacizliArac.Add(new ParaVeDovizId(child.HACIZLI_MAL_DEGERI, 1));
                                        break;
                                    case IcraMalKategori.Menkul:
                                        hacizliMenkul.Add(new ParaVeDovizId(child.HACIZLI_MAL_DEGERI, 1));
                                        break;
                                    case IcraMalKategori.GayriMenkul:
                                        hacizliGayriMenkul.Add(new ParaVeDovizId(child.HACIZLI_MAL_DEGERI, 1));
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (hacizliMenkul.Count > 0)
                                hacizMallarOzet += String.Format("{0} kalem {1:2} TL deðerinde menkul, ",
                                                                 hacizliMenkul.Count,
                                                                 ParaVeDovizId.Topla(hacizliMenkul,
                                                                                     satis.SATIS_TARIHI_1.Value).Para);
                            if (hacizliArac.Count > 0)
                                hacizMallarOzet += String.Format("{0} kalem {1:2} TL deðerinde araç, ",
                                                                 hacizliArac.Count,
                                                                 ParaVeDovizId.Topla(hacizliArac,
                                                                                     satis.SATIS_TARIHI_1.Value).Para);
                            if (hacizliGayriMenkul.Count > 0)
                                hacizMallarOzet += String.Format("{0} kalem {1:2} TL deðerinde gayrimenkul, ",
                                                                 hacizliGayriMenkul.Count,
                                                                 ParaVeDovizId.Topla(hacizliGayriMenkul,
                                                                                     satis.SATIS_TARIHI_1.Value).Para);

                            string sonuc = String.Empty;
                            if (satis.SATIS_TARIHI_1.HasValue && satis.SATIS_GERCEKLESME_TARIHI.HasValue &&
                                satis.SATIS_TARIHI_1.Value == satis.SATIS_GERCEKLESME_TARIHI.Value)
                            {
                                sonuc = " 1. satýþ tarihinde gerçekleþti";
                            }
                            else if (satis.SATIS_TARIHI_2.HasValue && satis.SATIS_GERCEKLESME_TARIHI.HasValue &&
                                     satis.SATIS_TARIHI_2.Value == satis.SATIS_GERCEKLESME_TARIHI.Value)
                            {
                                sonuc = " 2. satýþ tarihinde gerçekleþti";
                            }
                            else if (!satis.SATIS_GERCEKLESME_TARIHI.HasValue)
                            {
                                sonuc = " henüz gerçekleþmemiþ";
                            }
                            AV001_TD_BIL_FAIZ fz = new AV001_TD_BIL_FAIZ();
                            hacizMallarOzet += String.Format("(Toplam deðeri:{0} TL)", satis.TOPLAM_SATIS_DEGERI);
                            asama.ASAMA_ACIKLAMA = String.Format("Borçlunun ilgili mallarý ({0}) için satýþ {1}",
                                                                 hacizMallarOzet, sonuc);
                        }

                        #endregion

                        asama.ASAMA_KONU = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_ADI;
                        asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID;
                        asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;
                        asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
                        asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(satis);

                        if (satis.SATIS_SORUMLU_PERSONEL_ID > 0)
                        {
                            //TODO:ACILACAK AMA BU SATIS GRIDINDE BI SAKATLIK VAR ARKADAS...
                            AV001_TDIE_BIL_ASAMA_SORUMLU sorumlu = asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.AddNew();
                            sorumlu.CARI_ID = satis.SATIS_SORUMLU_PERSONEL_ID;
                        }
                        foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTrf = asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                            asmTrf.ASAMAYI_YAPAN_MI = taraf.TAKIP_EDEN_MI;
                            asmTrf.CARI_ID = taraf.CARI_ID.Value;
                            asmTrf.SIFAT_ID = taraf.TARAF_SIFAT_ID;
                        }
                        if (satis.SATISI_ISTENEN_CARI_ID > 0)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmYapilan = asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                            asmYapilan.ASAMAYI_YAPAN_MI = false;

                            asmYapilan.CARI_ID = satis.SATISI_ISTENEN_CARI_ID;
                        }
                        satis.MyAsamaList.Add(asama);

                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }
                }

                #endregion
            }

            #endregion

            #region Otomatik Iliski Asama Üretime(MalBeyaný)

            TList<TDIE_KOD_ASAMA_ILISKI> iliskisMalBeyani =
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI("AV001_TI_BIL_MAL_BEYANI");
            DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(iliskisMalBeyani,
                                                                  false, DeepLoadType.IncludeChildren,
                                                                  typeof(TDIE_KOD_ASAMA_ALT),
                                                                  typeof(TDI_KOD_TEBLIGAT_KONU));
            foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskisMalBeyani)
            {
                foreach (AV001_TI_BIL_MAL_BEYANI malBeyani in mFoy.AV001_TI_BIL_MAL_BEYANICollection)
                {
                    if (iliski.AsamaDegerKarsilastir(malBeyani) &&
                        !AsamaHelper.BuAsamaOncedenVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                         iliski.ALT_ASAMA_KOD_ID.Value, malBeyani) &&
                        !AsamaHelper.AsamaVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID, iliski.ALT_ASAMA_KOD_ID.Value,
                                                malBeyani))
                    {
                        AV001_TDIE_BIL_ASAMA asama = mFoy.AsamaGetir();
                        string ackBir = String.Empty;
                        string ackIki = String.Empty;
                        if (!malBeyani.MAL_BEYAN_TARIHI.HasValue && malBeyani.SON_MAL_BEYAN_TARIHI.HasValue &&
                            malBeyani.SON_MAL_BEYAN_TARIHI.Value < DateTime.Today)
                        {
                            ackBir = "hiç";
                            ackIki = "bulunmadý";
                        }
                        else if (malBeyani.MAL_BEYAN_TARIHI.HasValue && malBeyani.SON_MAL_BEYAN_TARIHI.HasValue &&
                                 malBeyani.SON_MAL_BEYAN_TARIHI.Value < malBeyani.MAL_BEYAN_TARIHI.Value)
                        {
                            if (malBeyani.GECIKMIS_MI)
                                ackBir = "yasal olarak gecikmeli ";
                            else
                                ackBir = "süresinden sonra";
                            ackIki = "bulundu";
                        }
                        else if (malBeyani.MAL_BEYAN_TARIHI.HasValue && malBeyani.SON_MAL_BEYAN_TARIHI.HasValue &&
                                 malBeyani.SON_MAL_BEYAN_TARIHI.Value >= malBeyani.MAL_BEYAN_TARIHI.Value)
                        //TODO:YANLIÞ OLABÝLiR
                        {
                            if (!malBeyani.MAL_BEYANI_GECERLI_MI)
                                ackBir = "süresinde olmakla birlikte geçersiz";
                            else
                                ackBir = "süresinde";
                            ackIki = "bulundu";
                        }
                        if (malBeyani.SONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI)
                        {
                            bool ekDogrumu = false;
                            foreach (AV001_TI_BIL_MAL_BEYANI beyan in mFoy.AV001_TI_BIL_MAL_BEYANICollection)
                            {
                                if (malBeyani != beyan &&
                                    malBeyani.ICRA_TARAF_ID == beyan.ICRA_TARAF_ID &&
                                    !beyan.SONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI && beyan.MAL_BEYANI_GECERLI_MI)
                                {
                                    ackBir = "ek";
                                    ackIki = "bulundu";
                                    ekDogrumu = true;
                                }
                            }
                            if (!ekDogrumu)
                            {
                                asama.Tag = "sil";
                            }
                        }

                        asama.ASAMA_ACIKLAMA = String.Format("Borçlu {0} mal beyanýnda {1}", ackBir, ackIki);

                        asama.ASAMA_KONU = "Borçlu Mal Beyaný";
                        asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID;
                        asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;
                        asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
                        asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(malBeyani);
                        //TODO:Ref 5846546598

                        if (true)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF trf = asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                            trf.CARI_ID = malBeyani.ICRA_TARAF_ID;
                            trf.ASAMAYI_YAPAN_MI = true;
                        }

                        foreach (AV001_TI_BIL_FOY_TARAF fTrf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            if (fTrf.TAKIP_EDEN_MI)
                            {
                                AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                                asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
                                asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID;
                                asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
                                asmTaraf.ASAMAYI_YAPAN_MI = false;
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }
                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }
                        if (asama.Tag != null && asama.Tag.ToString() == "sil")
                        {
                            //Aþamayý malesef kaydetmiyoruz.
                        }
                        else
                        {
                            //Aþama kaydetmeye müsait kaydediyoruz
                            mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                            malBeyani.MyAsamaList.Add(asama);
                        }
                    }
                }
            }

            #endregion

            #region Otomatik Iliski Asama Üretimi (Ýtiraz)

            TList<TDIE_KOD_ASAMA_ILISKI> iliskisItiraz =
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI("AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN");
            DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(iliskisItiraz,
                                                                  false, DeepLoadType.IncludeChildren,
                                                                  typeof(TDIE_KOD_ASAMA_ALT),
                                                                  typeof(TDI_KOD_TEBLIGAT_KONU));
            foreach (AV001_TI_BIL_ALACAK_NEDEN aNeden in mFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskisItiraz)
                {
                    foreach (
                        AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN itiraz in aNeden.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection)
                    {
                        if (iliski.AsamaDegerKarsilastir(itiraz) &&
                            !AsamaHelper.BuAsamaOncedenVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                             iliski.ALT_ASAMA_KOD_ID.Value, itiraz) &&
                            !AsamaHelper.AsamaVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                    iliski.ALT_ASAMA_KOD_ID.Value, itiraz))
                        {
                            AV001_TDIE_BIL_ASAMA asama = mFoy.AsamaGetir();
                            string itirazNeye = String.Empty;
                            if (itiraz.BORCA_ITIRAZ_VARMI)
                            {
                                if (itiraz.ANA_PARA_ITIRAZ_TUTARI > 0)
                                    itirazNeye += "Anapara borcuna, ";
                                if (itiraz.FAIZE_ITIRAZ_TUTARI > 0)
                                    itirazNeye += "Faiz borcuna, ";
                            }
                            if (itiraz.IMZAYA_ITIRAZ_VARMI)
                            {
                                itirazNeye += "Ýmzaya, ";
                            }
                            if (itiraz.YETKIYE_ITIRAZ_VARMI)
                            {
                                itirazNeye += "Yetkiye, ";
                            }
                            string itirazNeZaman = String.Empty;
                            if (itiraz.SON_ITIRAZ_TARIHI.HasValue &&
                                itiraz.ITIRAZ_TARIHI <= itiraz.SON_ITIRAZ_TARIHI.Value)
                            {
                                itirazNeZaman = "zamanýnda itirazda";
                            }
                            else
                            {
                                itirazNeZaman = "zamanýndan sonra itirazda";
                            }
                            asama.ASAMA_ACIKLAMA =
                                String.Format(
                                    "Borçlu {0} tarihli {1:2} {2} miktarlý alacak nedenine ({3}) {4} {5}  bulunmuþtur ",
                                    aNeden.VADE_TARIHI.Value, aNeden.ISLEME_KONAN_TUTAR, ((DovizTip)
                                                                                          aNeden.
                                                                                              ISLEME_KONAN_TUTAR_DOVIZ_ID
                                                                                              .Value),
                                    aNeden.ALACAK_NEDEN_KOD_IDSource,
                                    itirazNeye, itirazNeZaman);

                            asama.ASAMA_KONU = "Borçlu Alacak Nedenine Ýtiraz";
                            asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID;
                            asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;
                            asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
                            asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(itiraz);
                            asama.ADLI_BIRIM_ADLIYE_ID = itiraz.ADLI_BIRIM_ADLIYE_ID;
                            asama.ADLI_BIRIM_GOREV_ID = itiraz.ADLI_BIRIM_GOREV_ID;
                            asama.ADLI_BIRIM_NO_ID = itiraz.ADLI_BIRIM_NO_ID;

                            if (true)
                            {
                                AV001_TDIE_BIL_ASAMA_TARAF trf = asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                                trf.CARI_ID = itiraz.ITIRAZ_EDEN_TARAF_ID;
                                trf.ASAMAYI_YAPAN_MI = true;
                            }

                            foreach (AV001_TI_BIL_FOY_TARAF fTrf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                            {
                                if (fTrf.TAKIP_EDEN_MI)
                                {
                                    AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                                    asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
                                    asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID;
                                    asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
                                    asmTaraf.ASAMAYI_YAPAN_MI = false;
                                    asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                                }
                            }
                            foreach (
                                AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in
                                    mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                            {
                                if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                                {
                                    AV001_TDIE_BIL_ASAMA_SORUMLU aSrm =
                                        new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                    aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                    asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                                }
                            }
                            itiraz.MyAsamaList.Add(asama);
                            mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                            aNeden.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                        }
                    }
                }
            }

            #endregion

            #region Otomatik Iliski Asama Üretimi (Taahhüt)

            TList<TDIE_KOD_ASAMA_ILISKI> iliskisTaahhut =
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI("AV001_TI_BIL_BORCLU_TAAHHUT_MASTER");
            DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(iliskisTaahhut,
                                                                  false, DeepLoadType.IncludeChildren,
                                                                  typeof(TDIE_KOD_ASAMA_ALT),
                                                                  typeof(TDI_KOD_TEBLIGAT_KONU));
            TList<TDIE_KOD_ASAMA_ILISKI> iliskisTaahhutChild =
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI("AV001_TI_BIL_BORCLU_TAAHHUT_CHILD");
            DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(iliskisTaahhutChild,
                                                                  false, DeepLoadType.IncludeChildren,
                                                                  typeof(TDIE_KOD_ASAMA_ALT),
                                                                  typeof(TDI_KOD_TEBLIGAT_KONU));
            foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskisTaahhut)
            {
                foreach (AV001_TI_BIL_BORCLU_TAAHHUT_MASTER taahhut in mFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection
                    )
                {
                    #region Master

                    if (iliski.AsamaDegerKarsilastir(taahhut) &&
                        !AsamaHelper.BuAsamaOncedenVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                         iliski.ALT_ASAMA_KOD_ID.Value, taahhut) &&
                        !AsamaHelper.AsamaVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                iliski.ALT_ASAMA_KOD_ID.Value, taahhut))
                    {
                        AV001_TDIE_BIL_ASAMA asama = mFoy.AsamaGetir();
                        string itirazNeye = string.Empty;

                        asama.ASAMA_KONU = "Borçlu Taahhüt";
                        asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID;
                        asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;
                        asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
                        asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(taahhut);
                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }
                        bool taahhutKabulEdilmemi = (iliski.SUTUN_ADI == "TAAHHUDU_KABUL_TARIHI");

                        if (true)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF trf = asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                            trf.CARI_ID = taahhut.TAAHHUT_EDEN_ID.Value;
                            trf.ASAMAYI_YAPAN_MI = !taahhutKabulEdilmemi;
                        }

                        foreach (AV001_TI_BIL_FOY_TARAF fTrf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            if (fTrf.TAKIP_EDEN_MI)
                            {
                                AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                                asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
                                asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID;
                                asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
                                asmTaraf.ASAMAYI_YAPAN_MI = taahhutKabulEdilmemi;
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }
                        taahhut.MyAsamaList.Add(asama);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }
                }

                    #endregion
            }
            foreach (AV001_TI_BIL_BORCLU_TAAHHUT_MASTER taahhut in mFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection)
            {
                //TODO:Test edilecek

                #region Child

                foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskisTaahhutChild)
                {
                    foreach (
                        AV001_TI_BIL_BORCLU_TAAHHUT_CHILD tChild in taahhut.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection)
                    {
                        if (iliski.AsamaDegerKarsilastir(tChild) &&
                            !AsamaHelper.BuAsamaOncedenVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                             iliski.ALT_ASAMA_KOD_ID.Value, tChild) &&
                            !AsamaHelper.AsamaVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                    iliski.ALT_ASAMA_KOD_ID.Value, tChild))
                        {
                            AV001_TDIE_BIL_ASAMA asama = mFoy.AsamaGetir();

                            asama.ASAMA_KONU = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_ADI;
                            asama.ASAMA_ACIKLAMA = iliski.AsamaAciklamaGetir(tChild);
                            asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID;
                            asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;
                            asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
                            asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(tChild);
                            foreach (
                                AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in
                                    mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                            {
                                if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                                {
                                    AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                    aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                    asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                                }
                            }
                            if (true)
                            {
                                AV001_TDIE_BIL_ASAMA_TARAF trf = asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                                trf.CARI_ID = taahhut.TAAHHUT_EDEN_ID.Value;
                                trf.ASAMAYI_YAPAN_MI = true;
                            }

                            foreach (AV001_TI_BIL_FOY_TARAF fTrf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                            {
                                if (fTrf.TAKIP_EDEN_MI)
                                {
                                    AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                                    asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
                                    asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID;
                                    asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
                                    asmTaraf.ASAMAYI_YAPAN_MI = false;
                                    asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                                }
                            }
                            tChild.MyAsamaList.Add(asama);
                            mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                        }
                    }
                }

                #endregion
            }

            #endregion

            #region Otomatik Iliskiden Asama Üretimi (Düsme-Yenileme)

            TList<TDIE_KOD_ASAMA_ILISKI> iliskisDusmeYenileme =
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI("AV001_TI_BIL_DUSME_YENILEME");
            DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(iliskisDusmeYenileme,
                                                                  false, DeepLoadType.IncludeChildren,
                                                                  typeof(TDIE_KOD_ASAMA_ALT),
                                                                  typeof(TDI_KOD_TEBLIGAT_KONU));
            foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskisDusmeYenileme)
            {
                foreach (AV001_TI_BIL_DUSME_YENILEME dusmeYenileme in mFoy.AV001_TI_BIL_DUSME_YENILEMECollection)
                {
                    if (iliski.AsamaDegerKarsilastir(dusmeYenileme) &&
                        !AsamaHelper.BuAsamaOncedenVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                         iliski.ALT_ASAMA_KOD_ID.Value, dusmeYenileme) &&
                        !AsamaHelper.AsamaVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                iliski.ALT_ASAMA_KOD_ID.Value,
                                                dusmeYenileme))
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        mFoy.AsamaDoldur(asama);
                        asama.ASAMA_KONU = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_ADI;
                        asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID;
                        asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;
                        asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
                        asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(dusmeYenileme);
                        asama.ASAMA_ACIKLAMA = iliski.AsamaAciklamaGetir(dusmeYenileme);

                        #region Asama Taraflar

                        foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTrf = asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                            asmTrf.ASAMAYI_YAPAN_MI = taraf.TAKIP_EDEN_MI;
                            asmTrf.CARI_ID = taraf.CARI_ID.Value;
                            asmTrf.SIFAT_ID = taraf.TARAF_SIFAT_ID;
                            if (iliski.ASAMA_TARIH_SUTUNU == "DUSME_TARIHI") //
                                asmTrf.MAHKEME_MI = true;
                        }

                        #endregion

                        #region Asama Sorumlular

                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }

                        #endregion

                        //TODO:burayý bi kontrol et
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                        dusmeYenileme.MyAsamaList.Add(asama);
                    }
                }
            }

            #endregion

            #region Otomatik Iliskiden Asama Üretimi (Tehiri Ýcra) (MEHIL ALMA)

            TList<TDIE_KOD_ASAMA_ILISKI> iliskisMehilAlma =
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI("AV001_TI_BIL_MEHIL");
            DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(iliskisMehilAlma,
                                                                  false, DeepLoadType.IncludeChildren,
                                                                  typeof(TDIE_KOD_ASAMA_ALT),
                                                                  typeof(TDI_KOD_TEBLIGAT_KONU));
            foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskisMehilAlma)
            {
                foreach (AV001_TI_BIL_MEHIL mehil in mFoy.AV001_TI_BIL_MEHILCollection)
                {
                    if (iliski.AsamaDegerKarsilastir(mehil) &&
                        !AsamaHelper.BuAsamaOncedenVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                         iliski.ALT_ASAMA_KOD_ID.Value, mehil) &&
                        !AsamaHelper.AsamaVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                iliski.ALT_ASAMA_KOD_ID.Value,
                                                mehil))
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        mFoy.AsamaDoldur(asama);
                        asama.ASAMA_KONU = asama.ASAMA_ALT_KOD_IDSource.ALT_ASAMA_ADI;
                        asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID;
                        asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;
                        asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
                        asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(mehil);
                        asama.ASAMA_ACIKLAMA = iliski.AsamaAciklamaGetir(mehil);

                        #region Asama Taraflar

                        foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTrf = asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                            asmTrf.ASAMAYI_YAPAN_MI = taraf.TAKIP_EDEN_MI;
                            asmTrf.CARI_ID = taraf.CARI_ID.Value;
                            asmTrf.SIFAT_ID = taraf.TARAF_SIFAT_ID;
                            if (iliski.ASAMA_TARIH_SUTUNU == "YARGITAY_MEHIL_KARAR_TARIHI") //
                            {
                                asmTrf.MAHKEME_MI = true;
                            }
                        }

                        #endregion

                        #region Asama Sorumlular

                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }

                        #endregion

                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                        mehil.MyAsamaList.Add(asama);
                    }
                }
            }

            #endregion

            #region Otomatik Iliskiden Asama Üretimi (Görüþme)

            TList<TDIE_KOD_ASAMA_ILISKI> iliskisGorusme =
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI("AV001_TDI_BIL_GORUSME");
            DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(iliskisGorusme,
                                                                  false, DeepLoadType.IncludeChildren,
                                                                  typeof(TDIE_KOD_ASAMA_ALT),
                                                                  typeof(TDI_KOD_TEBLIGAT_KONU));

            foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskisGorusme)
            {
                foreach (AV001_TDI_BIL_GORUSME gorusme in mFoy.AV001_TDI_BIL_GORUSMECollection)
                {
                    if (iliski.AsamaDegerKarsilastir(gorusme) &&
                        !AsamaHelper.BuAsamaOncedenVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
                                                         iliski.ALT_ASAMA_KOD_ID.Value, gorusme) &&
                        !AsamaHelper.AsamaVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID, iliski.ALT_ASAMA_KOD_ID.Value,
                                                gorusme))
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        mFoy.AsamaDoldur(asama);
                        foreach (AV001_TI_BIL_FOY_TARAF fTrf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            if (fTrf.TARAF_KODU == (byte)AvukatProLib.Extras.TarafKodu.Muvekkil ||
                                fTrf.TARAF_KODU == (byte)AvukatProLib.Extras.TarafKodu.Muvekkil)
                            {
                                AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                                asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
                                asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID;
                                asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
                                bool yapanMi = fTrf.TARAF_KODU == (byte)AvukatProLib.Extras.TarafKodu.Muvekkil;
                                asmTaraf.ASAMAYI_YAPAN_MI = yapanMi;
                                asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                            }
                        }

                        if (true)
                        {
                            AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();
                            aSrm.CARI_ID = gorusme.GORUSEN_CARI_ID;
                            asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                        }
                        //TODO : COMMENT EDÝLMÝÞTÝR DÜZELTÝNÝZ ..
                        //asama.ASAMA_ACIKLAMA = iliski.AsamaAciklamaGetir(mahsup);
                        asama.ASAMA_KONU = "Görüþme";
                        asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID;
                        asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;
                        asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
                        //asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(mahsup);

                        gorusme.MyAsamaList.Add(asama);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                    }
                }
            }

            #endregion

            #region Otomatik Iliskiden Asama Üretimi (Ýþ - Sonra Bakýlacak)

            //            TList<TDIE_KOD_ASAMA_ILISKI> iliskisIs =
            //DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI("AV001_TDI_BIL_IS");
            //            DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(iliskisIs,
            //                                                                  false, DeepLoadType.IncludeChildren,
            //                                                                  typeof(TDIE_KOD_ASAMA_ALT),
            //                                                                  typeof(TDI_KOD_TEBLIGAT_KONU));

            //            foreach (AV001_TDI_BIL_IS bilIs in mFoy.AV001_TDI_BIL_ISCollection)
            //            {
            //                foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskisIs)
            //                {
            //                    if (iliski.AsamaDegerKarsilastir(bilIs) && !AsamaHelper.BuAsamaOncedenVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID,
            //iliski.ALT_ASAMA_KOD_ID.Value, bilIs) && !AsamaHelper.AsamaVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID, iliski.ALT_ASAMA_KOD_ID.Value,
            //                            bilIs))
            //                    {
            //                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
            //                        if(bilIs.ADLI_BIRIM_ADLIYE_ID.HasValue && bilIs.ADLI_BIRIM_GOREV_ID.HasValue && bilIs.ADLI_BIRIM_NO_ID.HasValue )
            //                        {
            //                            asama.ADLI_BIRIM_ADLIYE_ID = bilIs.ADLI_BIRIM_ADLIYE_ID.Value;
            //                            asama.ADLI_BIRIM_GOREV_ID = bilIs.ADLI_BIRIM_GOREV_ID.Value;
            //                            asama.ADLI_BIRIM_NO_ID = bilIs.ADLI_BIRIM_NO_ID.Value;
            //                        }
            //                        else
            //                        {
            //                            mFoy.AsamaDoldur(asama);
            //                        }

            //                        #region X
            //                        //foreach (AV001_TI_BIL_FOY_TARAF fTrf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
            //                        //{
            //                        //    if (fTrf.TARAF_KODU == (byte)AvukatProLib.Extras.TarafKodu.Muvekkil || fTrf.TARAF_KODU == (byte)AvukatProLib.Extras.TarafKodu.Muvekkil)
            //                        //    {
            //                        //        AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
            //                        //        asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
            //                        //        asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID.Value;
            //                        //        asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
            //                        //        bool yapanMi = fTrf.TARAF_KODU == (byte)AvukatProLib.Extras.TarafKodu.Muvekkil;
            //                        //        asmTaraf.ASAMAYI_YAPAN_MI = yapanMi;
            //                        //        asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
            //                        //    }
            //                        //}
            //                        #endregion

            //                        foreach (AV001_TDI_BIL_IS_TARAF taraf in bilIs.AV001_TDI_BIL_IS_TARAFCollection)
            //                        {
            //                            taraf.
            //                        }
            //                        bilIs.AV001_TDI_BIL_IS_TARAFCollection
            //                        AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
            //                        asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
            //                        asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID.Value;
            //                        asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
            //                        bool yapanMi = fTrf.TARAF_KODU == (byte)AvukatProLib.Extras.TarafKodu.Muvekkil;
            //                        asmTaraf.ASAMAYI_YAPAN_MI = yapanMi;
            //                        asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);

            //                        if (bilIs.GORUSEN_CARI_ID.HasValue)
            //                        {
            //                            AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();
            //                            aSrm.CARI_ID = bilIs.GORUSEN_CARI_ID.Value;
            //                            asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
            //                        }

            //                        asama.ASAMA_ACIKLAMA = iliski.AsamaAciklamaGetir(mahsup);
            //                        asama.ASAMA_KONU = "Ýþ";
            //                        asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID;
            //                        asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
            //                        asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(mahsup);

            //                        bilIs.MyAsamaList.Add(asama);
            //                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
            //                    }
            //                }
            //            }

            #endregion

            #region Otomatik Iliskiden Takibin Neticelendirilmesi Aþamalarý

            TList<TDIE_KOD_ASAMA_ILISKI> foyIliski =
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI(mFoy.TableName);

            DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(foyIliski, false, DeepLoadType.IncludeChildren,
                                                                  typeof(TDIE_KOD_ASAMA_ALT),
                                                                  typeof(TDI_KOD_TEBLIGAT_KONU));

            foreach (string str in mFoy.ChangedProperties)
            {
                TList<TDIE_KOD_ASAMA_ILISKI> result =
                    foyIliski.FindAll(delegate(TDIE_KOD_ASAMA_ILISKI obj) { return obj.SUTUN_ADI.Contains(str); });
                foreach (TDIE_KOD_ASAMA_ILISKI iliski in result)
                {
                    //AV001_TDIE_BIL_ASAMA asama = null;
                    if (iliski != null && iliski.ASAMA_URETSIN_MI && iliski.ALT_ASAMA_KOD_IDSource != null
                        && iliski.AsamaDegerKarsilastir(mFoy) &&
                        !AsamaHelper.AsamaVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID, iliski.ALT_ASAMA_KOD_ID.Value,
                                                mFoy))
                    {
                        AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                        //if (!AsamaHelper.AsamaVarmi(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID, iliski.ALT_ASAMA_KOD_ID.Value, mFoy))
                        //asama = new AV001_TDIE_BIL_ASAMA();

                        //else
                        //{
                        //asama = DataRepository.AV001_TDIE_BIL_ASAMAProvider.fin GetByID(iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID);
                        //}

                        mFoy.AsamaDoldur(asama);
                        asama.ASAMA_KONU = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_ADI;
                        asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID;
                        asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;
                        asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
                        asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(mFoy);
                        asama.ASAMA_ACIKLAMA = iliski.AsamaAciklamaGetir(mFoy);

                        foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            if (taraf.TAKIP_EDEN_MI)
                            {
                                AV001_TDIE_BIL_ASAMA_TARAF asmTrf = asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                                asmTrf.ASAMAYI_YAPAN_MI = taraf.TAKIP_EDEN_MI;
                                asmTrf.CARI_ID = taraf.CARI_ID.Value;
                                asmTrf.SIFAT_ID = taraf.TARAF_SIFAT_ID;
                            }
                        }

                        foreach (
                            AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                                aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                                asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                            }
                        }

                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                        //mFoy.MyAsamaList.Clear();
                        mFoy.MyAsamaList.Add(asama);
                    }
                }
            }

            #endregion

            #region Dosya Üzerinden Sulh Tarihi Girildiðinde Oluþturulan Aþamalar

            if (mFoy.SULH_TARIHI.HasValue && mFoy.TAKIP_TARIHI.HasValue)
            {
                AV001_TDIE_BIL_ASAMA asm = null;

                //Sulh Tarihi Takip Tarihinden Küçükse
                if (mFoy.SULH_TARIHI < mFoy.TAKIP_TARIHI && !AsamaHelper.AsamaVarmi(149, 1069, mFoy))
                {
                    asm = new AV001_TDIE_BIL_ASAMA();
                    asm.ASAMA_KOD_ID = 149;
                    asm.ASAMA_ALT_KOD_ID = 1069;
                    asm.ASAMA_KONU = "Takip Açýlmadan Sulh";
                }

                //Sulh Tarihi Takip Tarihine Eþit Ancak Haciz ve Ýtiraz Yoksa
                if (mFoy.SULH_TARIHI >= mFoy.TAKIP_TARIHI && !ucIcraTarafGelismeleri.DosyadaHacizVarmi(mFoy)
                    && !ucIcraTarafGelismeleri.DosyadaItýrazVarmi(mFoy) && !AsamaHelper.AsamaVarmi(149, 1070, mFoy))
                {
                    asm = new AV001_TDIE_BIL_ASAMA();
                    asm.ASAMA_KOD_ID = 149;
                    asm.ASAMA_ALT_KOD_ID = 1070;
                    asm.ASAMA_KONU = "Takipten Sonra Sulh";
                }

                //Takipten Sonra ve Hacizden Sonra ise
                if (mFoy.AV001_TI_BIL_HACIZ_MASTERCollection.Count > 0)
                {
                    mFoy.AV001_TI_BIL_HACIZ_MASTERCollection.Sort("HACIZ_TARIHI ASC");

                    DateTime HacizTarihi = mFoy.AV001_TI_BIL_HACIZ_MASTERCollection[0].HACIZ_TARIHI;

                    if (mFoy.SULH_TARIHI > HacizTarihi && mFoy.SULH_TARIHI > mFoy.TAKIP_TARIHI &&
                        !AsamaHelper.AsamaVarmi(149, 1071, mFoy))
                    {
                        asm = new AV001_TDIE_BIL_ASAMA();
                        asm.ASAMA_KOD_ID = 149;
                        asm.ASAMA_ALT_KOD_ID = 1071;
                        asm.ASAMA_KONU = "Hacizden Sonra Sulh";
                    }
                }

                //Eðer Takip Tarihi ve Ýtiraz Tarihi Var ise
                if (mFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count > 0)
                {
                    TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> result = new TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>();
                    DateTime itirazTarihi = DateTime.MinValue;
                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in mFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        result.AddRange(neden.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection);
                    }

                    if (result.Count > 0)
                    {
                        result.Sort("ITIRAZ_TARIHI ASC");

                        itirazTarihi = result[0].ITIRAZ_TARIHI;
                    }
                    if (itirazTarihi > DateTime.MinValue && !AsamaHelper.AsamaVarmi(149, 1072, mFoy))
                    {
                        asm = new AV001_TDIE_BIL_ASAMA();
                        asm.ASAMA_KOD_ID = 149;
                        asm.ASAMA_ALT_KOD_ID = 1072;
                        asm.ASAMA_KONU = "Ýtirazdan Sonra Sulh";
                    }
                }
                if (asm != null)
                {
                    asm.ADLI_BIRIM_ADLIYE_ID = mFoy.ADLI_BIRIM_ADLIYE_ID;
                    asm.ADLI_BIRIM_GOREV_ID = mFoy.ADLI_BIRIM_GOREV_ID;
                    asm.ADLI_BIRIM_NO_ID = mFoy.ADLI_BIRIM_NO_ID;
                    asm.ESAS_NO = mFoy.ESAS_NO;
                    asm.ASAMA_TARIHI = mFoy.SULH_TARIHI;
                    asm.ICRA_FOY_ID = mFoy.ID;
                    asm.ASAMA_MODUL_ID = 1;

                    foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                    {
                        if (taraf.TAKIP_EDEN_MI)
                        {
                            AV001_TDIE_BIL_ASAMA_TARAF asmTrf = asm.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                            asmTrf.ASAMAYI_YAPAN_MI = taraf.TAKIP_EDEN_MI;
                            asmTrf.CARI_ID = taraf.CARI_ID.Value;
                            asmTrf.SIFAT_ID = taraf.TARAF_SIFAT_ID;
                            StringBuilder aciklama = AciklamaGetir(mFoy,
                                                                   BelgeUtil.Inits.CariIsmiGetir(taraf.CARI_ID.Value),
                                                                   asm.ASAMA_TARIHI.Value.ToShortDateString());
                            aciklama.Append(" ");
                            aciklama.Append(asm.ASAMA_KONU);
                            aciklama.Append(" Yapýldý.");
                            asm.ASAMA_ACIKLAMA = aciklama.ToString();
                        }
                    }

                    foreach (AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                    {
                        AV001_TDIE_BIL_ASAMA_SORUMLU srm = asm.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.AddNew();
                        srm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                    }

                    if (!mFoy.MyAsamaList.Contains(asm))
                        mFoy.MyAsamaList.Add(asm);
                    if (!mFoy.AV001_TDIE_BIL_ASAMACollection.Contains(asm))
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asm);
                    asm.Dispose();
                }
            }

            #endregion

            #region Takibin Avukata Ýntikal Tarihi

            if (mFoy.TAKIBIN_AVUKATA_INTIKAL_TARIHI.HasValue)
            {
                foreach (AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                {
                    AV001_TDIE_BIL_ASAMA asm = null;
                    AV001_TDI_BIL_CARI cari =
                        DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(sorumlu.SORUMLU_AVUKAT_CARI_ID.Value);
                    string tarafAdi = string.Empty;

                    if (cari.AVUKAT_MI && cari.KURUM_AVUKATI_MI)
                    {
                        if (!AsamaHelper.AsamaVarmi(16, 137, mFoy))
                        {
                            asm = new AV001_TDIE_BIL_ASAMA();
                            asm.ASAMA_KOD_ID = 16;
                            asm.ASAMA_ALT_KOD_ID = 137;
                            asm.ASAMA_KONU = "Sözleþmeli Avukata Sevk";
                            tarafAdi = cari.AD;
                        }
                    }
                    if (cari.PERSONEL_MI && cari.AVUKAT_MI)
                    {
                        if (AsamaHelper.AsamaVarmi(16, 138, mFoy))
                        {
                            asm = new AV001_TDIE_BIL_ASAMA();
                            asm.ASAMA_KOD_ID = 16;
                            asm.ASAMA_ALT_KOD_ID = 138;
                            asm.ASAMA_KONU = "Personel Avukata Sevk";
                            tarafAdi = cari.AD;
                        }
                    }

                    if (asm != null)
                    {
                        asm.ADLI_BIRIM_ADLIYE_ID = mFoy.ADLI_BIRIM_ADLIYE_ID;
                        asm.ADLI_BIRIM_GOREV_ID = mFoy.ADLI_BIRIM_GOREV_ID;
                        asm.ADLI_BIRIM_NO_ID = mFoy.ADLI_BIRIM_NO_ID;
                        asm.ESAS_NO = mFoy.ESAS_NO;
                        asm.ASAMA_TARIHI = mFoy.SULH_TARIHI;
                        asm.ICRA_FOY_ID = mFoy.ID;
                        asm.ASAMA_MODUL_ID = 1;

                        foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            if (taraf.TAKIP_EDEN_MI)
                            {
                                AV001_TDIE_BIL_ASAMA_TARAF asmTrf = asm.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                                asmTrf.ASAMAYI_YAPAN_MI = taraf.TAKIP_EDEN_MI;
                                asmTrf.CARI_ID = taraf.CARI_ID.Value;
                                asmTrf.SIFAT_ID = taraf.TARAF_SIFAT_ID;
                                StringBuilder aciklama = AciklamaGetir(mFoy, tarafAdi,
                                                                       mFoy.SULH_TARIHI.Value.ToShortDateString());
                                asm.ASAMA_ACIKLAMA = aciklama.ToString();
                            }
                        }

                        AV001_TDIE_BIL_ASAMA_SORUMLU srm = asm.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.AddNew();
                        srm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                        mFoy.MyAsamaList.Add(asm);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asm);
                        asm.Dispose();
                    }
                }
            }

            #endregion

            #region Kefalet Aþamasý 211-1082

            foreach (AV001_TI_BIL_KEFALET_BILGILERI kefalet in mFoy.AV001_TI_BIL_KEFALET_BILGILERICollection)
            {
                if (kefalet.KEFALET_TARIHI > DateTime.MinValue && !AsamaHelper.AsamaVarmi(211, 1082, kefalet))
                {
                    AV001_TDIE_BIL_ASAMA asama = new AV001_TDIE_BIL_ASAMA();
                    mFoy.AsamaDoldur(asama);
                    asama.ASAMA_KOD_ID = 211;
                    asama.ASAMA_ALT_KOD_ID = 1082;
                    asama.ASAMA_TARIHI = kefalet.KEFALET_TARIHI;
                    asama.ASAMA_KONU = "Kefalet";
                    if (kefalet.KEFALET_MIKTAR_DOVIZ_IDSource == null)
                        kefalet.KEFALET_MIKTAR_DOVIZ_IDSource =
                            BelgeUtil.Inits.DovizIdSource(kefalet.KEFALET_MIKTAR_DOVIZ_ID);
                    asama.ASAMA_ACIKLAMA =
                        String.Format(
                            "Borçlu ile ilgili alacak nedeni {0} tarihinde {1} {2} kefalet miktarý üzerinden dosyaya icra kefili alýnmýþtýr.",
                            kefalet.KEFALET_TARIHI.ToShortDateString(), kefalet.KEFALET_MIKTARI,
                            kefalet.KEFALET_MIKTAR_DOVIZ_IDSource.AD);

                    foreach (AV001_TI_BIL_FOY_TARAF fTrf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                    {
                        AV001_TDIE_BIL_ASAMA_TARAF asmTaraf = new AV001_TDIE_BIL_ASAMA_TARAF();
                        asmTaraf.CARI_ID = fTrf.CARI_ID.Value;
                        asmTaraf.SIFAT_ID = fTrf.TARAF_SIFAT_ID;
                        asmTaraf.KODU = ((TarafKodu)fTrf.TARAF_KODU).ToString()[0].ToString();
                        asmTaraf.ASAMAYI_YAPAN_MI = (kefalet.KEFIL_OLAN_CARI_ID == fTrf.CARI_ID.Value);

                        if (fTrf.TAKIP_EDEN_MI || (kefalet.KEFIL_OLAN_CARI_ID == fTrf.CARI_ID.Value))
                        {
                            asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.Add(asmTaraf);
                        }
                    }
                    foreach (
                        AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                    {
                        if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                        {
                            AV001_TDIE_BIL_ASAMA_SORUMLU aSrm = new AV001_TDIE_BIL_ASAMA_SORUMLU();

                            aSrm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                            asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Add(aSrm);
                        }
                    }

                    kefalet.MyAsamaList.Add(asama);
                    mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                }
            }

            #endregion

            #region Haciz Aþamalarý

            if (mFoy.AV001_TI_BIL_HACIZ_MASTERCollection.Count > 0)
            {
                foreach (AV001_TI_BIL_HACIZ_MASTER haciz in mFoy.AV001_TI_BIL_HACIZ_MASTERCollection)
                {
                    TList<AV001_TDIE_BIL_ASAMA> asmList = new TList<AV001_TDIE_BIL_ASAMA>();
                    if (haciz.HACIZ_TARIHI > DateTime.MinValue && haciz.HACIZ_MI.HasValue && haciz.HACIZ_MI.Value)
                    {
                        if (haciz.BAKIYE_HACIZI_MI && !AsamaHelper.AsamaVarmi(33, 1086, haciz) &&
                            !BuAsamaOncedenVarmi(33, 1086, haciz))
                        {
                            AV001_TDIE_BIL_ASAMA asm = new AV001_TDIE_BIL_ASAMA();
                            asm.ASAMA_ALT_KOD_ID = 1086;
                            asm.ASAMA_KONU = "Bakiye Haczi Yapýldý.";
                            asmList.Add(asm);
                        }
                        if (haciz.TALIMAT_MI && !AsamaHelper.AsamaVarmi(33, 211, haciz) &&
                            !BuAsamaOncedenVarmi(33, 211, haciz))
                        {
                            AV001_TDIE_BIL_ASAMA asm = new AV001_TDIE_BIL_ASAMA();
                            asm.ASAMA_ALT_KOD_ID = 211;
                            asm.ASAMA_KONU = "Talimat Haczi Yapýldý.";
                            asmList.Add(asm);
                        }
                        if (haciz.HACIZ_TALEP_TARIHI > DateTime.MinValue && !AsamaHelper.AsamaVarmi(33, 914, haciz) &&
                            !BuAsamaOncedenVarmi(33, 914, haciz))
                        {
                            AV001_TDIE_BIL_ASAMA asm = new AV001_TDIE_BIL_ASAMA();
                            asm.ASAMA_ALT_KOD_ID = 914;
                            asm.ASAMA_KONU = "Bakiye Haciz Yapýlmasý Ýçin Talep Açýldý.";
                            asmList.Add(asm);
                        }
                        if (haciz.MUHAFAZALI_KAYIT_VAR_MI && !AsamaHelper.AsamaVarmi(33, 165, haciz) &&
                            !BuAsamaOncedenVarmi(33, 165, haciz))
                        {
                            AV001_TDIE_BIL_ASAMA asm = new AV001_TDIE_BIL_ASAMA();
                            asm.ASAMA_ALT_KOD_ID = 165;
                            asm.ASAMA_KONU = "Bakiye Haciz ve Muhafaza Yapýldý.";
                            asmList.Add(asm);
                        }
                        if (haciz.TALIMAT_MI && haciz.MUHAFAZALI_KAYIT_VAR_MI && !AsamaHelper.AsamaVarmi(33, 166, haciz) &&
                            !BuAsamaOncedenVarmi(33, 166, haciz))
                        {
                            AV001_TDIE_BIL_ASAMA asm = new AV001_TDIE_BIL_ASAMA();
                            asm.ASAMA_ALT_KOD_ID = 166;
                            asm.ASAMA_KONU = "Talimat Haczi ve Muhafaza Yapýldý.";
                            asmList.Add(asm);
                        }
                    }

                    if (asmList.Count > 0)
                    {
                        for (int i = 0; i < asmList.Count; i++)
                        {
                            asmList[i].ASAMA_KOD_ID = 33;
                            asmList[i].ASAMA_TARIHI = haciz.HACIZ_TARIHI;
                            asmList[i].ADLI_BIRIM_ADLIYE_ID = mFoy.ADLI_BIRIM_ADLIYE_ID;
                            asmList[i].ADLI_BIRIM_GOREV_ID = mFoy.ADLI_BIRIM_GOREV_ID;
                            asmList[i].ADLI_BIRIM_NO_ID = mFoy.ADLI_BIRIM_NO_ID;
                            asmList[i].ESAS_NO = mFoy.ESAS_NO;
                            asmList[i].ICRA_FOY_ID = mFoy.ID;
                            asmList[i].ASAMA_MODUL_ID = 1;

                            foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                            {
                                if (taraf.TAKIP_EDEN_MI)
                                {
                                    AV001_TDIE_BIL_ASAMA_TARAF asmTrf =
                                        asmList[i].AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                                    asmTrf.ASAMAYI_YAPAN_MI = taraf.TAKIP_EDEN_MI;
                                    asmTrf.CARI_ID = taraf.CARI_ID.Value;
                                    asmTrf.SIFAT_ID = taraf.TARAF_SIFAT_ID;
                                    StringBuilder aciklama = AciklamaGetir(mFoy,
                                                                           BelgeUtil.Inits.CariIsmiGetir(
                                                                               taraf.CARI_ID.Value),
                                                                           haciz.HACIZ_TARIHI.ToShortDateString());

                                    aciklama.Append(" ");
                                    aciklama.Append("Mal ve Alacaklarý ile Ýlgili");
                                    aciklama.Append(" ");
                                    aciklama.Append(asmList[i].ASAMA_KONU);
                                    aciklama.AppendLine();
                                    aciklama.AppendLine(haciz.HACIZ_ACIKLAMA);
                                    asmList[i].ASAMA_ACIKLAMA = aciklama.ToString();
                                }
                            }

                            foreach (
                                AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in
                                    mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU srm =
                                    asmList[i].AV001_TDIE_BIL_ASAMA_SORUMLUCollection.AddNew();
                                srm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                            }
                        }

                        haciz.MyAsamaList.AddRange(asmList);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.AddRange(asmList);
                        asmList.Dispose();
                    }
                }
            }

            #endregion

            #region Satis Asamalarý

            if (mFoy.AV001_TI_BIL_SATIS_MASTERCollection.Count > 0)
            {
                foreach (AV001_TI_BIL_SATIS_MASTER satis in mFoy.AV001_TI_BIL_SATIS_MASTERCollection)
                {
                    TList<AV001_TDIE_BIL_ASAMA> asmList = new TList<AV001_TDIE_BIL_ASAMA>();
                    if (satis.SATIS_ISTEME_TARIHI > DateTime.MinValue && !AsamaHelper.AsamaVarmi(28, 233, satis)
                        && !AsamaHelper.BuAsamaOncedenVarmi(28, 233, satis))
                    {
                        AV001_TDIE_BIL_ASAMA asm = new AV001_TDIE_BIL_ASAMA();
                        asm.ASAMA_ALT_KOD_ID = 233;
                        asm.ASAMA_TARIHI = satis.SATIS_ISTEME_TARIHI;
                        asm.ASAMA_KONU = "Satýþ Talebi Ýstendi.";
                        asmList.Add(asm);
                    }

                    if (satis.SATIS_KESINLESME_TARIHI.HasValue && !AsamaHelper.AsamaVarmi(28, 1088, satis)
                        && !AsamaHelper.BuAsamaOncedenVarmi(28, 1088, satis))
                    {
                        AV001_TDIE_BIL_ASAMA asm = new AV001_TDIE_BIL_ASAMA();
                        asm.ASAMA_ALT_KOD_ID = 1088;
                        asm.ASAMA_TARIHI = satis.SATIS_KESINLESME_TARIHI;
                        asm.ASAMA_KONU = "Satýþ Kesinleþti.";
                        asmList.Add(asm);
                    }

                    if (satis.SATIS_GERCEKLESME_TARIHI.HasValue && !AsamaHelper.AsamaVarmi(28, 1087, satis)
                        && !AsamaHelper.BuAsamaOncedenVarmi(28, 1087, satis))
                    {
                        AV001_TDIE_BIL_ASAMA asm = new AV001_TDIE_BIL_ASAMA();
                        asm.ASAMA_ALT_KOD_ID = 1087;
                        asm.ASAMA_TARIHI = satis.SATIS_GERCEKLESME_TARIHI;
                        asm.ASAMA_KONU = "Mal ve Alacaklarla Ýlgili Satýþ Yapýldý.";
                        asmList.Add(asm);
                    }

                    if (asmList.Count > 0)
                    {
                        for (int i = 0; i < asmList.Count; i++)
                        {
                            asmList[i].ASAMA_KOD_ID = 28;
                            asmList[i].ADLI_BIRIM_ADLIYE_ID = mFoy.ADLI_BIRIM_ADLIYE_ID;
                            asmList[i].ADLI_BIRIM_GOREV_ID = mFoy.ADLI_BIRIM_GOREV_ID;
                            asmList[i].ADLI_BIRIM_NO_ID = mFoy.ADLI_BIRIM_NO_ID;
                            asmList[i].ESAS_NO = mFoy.ESAS_NO;
                            asmList[i].ICRA_FOY_ID = mFoy.ID;
                            asmList[i].ASAMA_MODUL_ID = 1;

                            foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                            {
                                if (taraf.TAKIP_EDEN_MI)
                                {
                                    AV001_TDIE_BIL_ASAMA_TARAF asmTrf =
                                        asmList[i].AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                                    asmTrf.ASAMAYI_YAPAN_MI = taraf.TAKIP_EDEN_MI;
                                    asmTrf.CARI_ID = taraf.CARI_ID.Value;
                                    asmTrf.SIFAT_ID = taraf.TARAF_SIFAT_ID;

                                    StringBuilder aciklama = AciklamaGetir(mFoy,
                                                                           BelgeUtil.Inits.CariIsmiGetir(
                                                                               taraf.CARI_ID.Value),
                                                                           asmList[i].ASAMA_TARIHI.Value.
                                                                               ToShortDateString());

                                    aciklama.Append(" ");
                                    aciklama.Append(asmList[i].ASAMA_KONU);
                                    aciklama.AppendLine();
                                    asmList[i].ASAMA_ACIKLAMA = aciklama.ToString();
                                }
                            }

                            foreach (
                                AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in
                                    mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU srm =
                                    asmList[i].AV001_TDIE_BIL_ASAMA_SORUMLUCollection.AddNew();
                                srm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                            }
                        }

                        satis.MyAsamaList.AddRange(asmList);
                        mFoy.AV001_TDIE_BIL_ASAMACollection.AddRange(asmList);
                        asmList.Dispose();
                    }
                }
            }

            #endregion

            #region Muvekkile Ödeme Aþamasý

            if (mFoy.AV001_TI_BIL_MUVEKKILE_ODEMECollectionGetByICRA_FOY_ID.Count > 0)
            {
                foreach (AV001_TI_BIL_MUVEKKILE_ODEME odeme in mFoy.AV001_TI_BIL_MUVEKKILE_ODEMECollectionGetByICRA_FOY_ID)
                {
                    if (odeme.ODEME_TARIHI.HasValue)
                    {
                        if (!AsamaHelper.AsamaVarmi(214, 1084, odeme) &&
                            !AsamaHelper.BuAsamaOncedenVarmi(214, 1084, odeme))
                        {
                            AV001_TDIE_BIL_ASAMA asm = new AV001_TDIE_BIL_ASAMA();
                            asm.ASAMA_ALT_KOD_ID = 214;
                            asm.ASAMA_KOD_ID = 1084;
                            asm.ASAMA_TARIHI = odeme.ODEME_TARIHI;
                            asm.ASAMA_KONU = "Müvekkile Ödeme Yapýldý.";
                            asm.ADLI_BIRIM_ADLIYE_ID = mFoy.ADLI_BIRIM_ADLIYE_ID;
                            asm.ADLI_BIRIM_GOREV_ID = mFoy.ADLI_BIRIM_GOREV_ID;
                            asm.ADLI_BIRIM_NO_ID = mFoy.ADLI_BIRIM_NO_ID;
                            asm.ESAS_NO = mFoy.ESAS_NO;
                            asm.ICRA_FOY_ID = mFoy.ID;
                            asm.ASAMA_MODUL_ID = 1;

                            foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                            {
                                if (taraf.TAKIP_EDEN_MI)
                                {
                                    AV001_TDIE_BIL_ASAMA_TARAF asmTrf =
                                        asm.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                                    asmTrf.ASAMAYI_YAPAN_MI = taraf.TAKIP_EDEN_MI;
                                    asmTrf.CARI_ID = taraf.CARI_ID.Value;
                                    asmTrf.SIFAT_ID = taraf.TARAF_SIFAT_ID;

                                    StringBuilder aciklama = AciklamaGetir(mFoy,
                                                                           BelgeUtil.Inits.CariIsmiGetir(
                                                                               taraf.CARI_ID.Value),
                                                                           asm.ASAMA_TARIHI.Value.ToShortDateString());

                                    if (odeme.ODEME_TIP_IDSource == null && odeme.ODEME_TIP_ID.HasValue)
                                        odeme.ODEME_TIP_IDSource =
                                            DataRepository.TDI_KOD_ODEME_TIPProvider.GetByID(odeme.ODEME_TIP_ID.Value);

                                    if (odeme.MIKTAR_DOVIZ_IDSource == null && odeme.MIKTAR_DOVIZ_ID.HasValue)
                                        odeme.MIKTAR_DOVIZ_IDSource =
                                            BelgeUtil.Inits.DovizIdSource(odeme.MIKTAR_DOVIZ_ID.Value);

                                    aciklama.Append(" ");
                                    aciklama.Append(odeme.ODEME_TIP_IDSource.ODEME_TIP);
                                    aciklama.Append(" ile");
                                    aciklama.Append(odeme.MIKTAR.ToString());
                                    aciklama.Append(" ");
                                    aciklama.Append(odeme.MIKTAR_DOVIZ_IDSource.DOVIZ_KODU);
                                    aciklama.Append(" Miktarýnda Ödeme Yapýldý.");
                                    asm.ASAMA_ACIKLAMA = aciklama.ToString();
                                }
                            }

                            foreach (
                                AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in
                                    mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU srm = asm.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.AddNew();
                                srm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                            }
                        }
                    }
                }
            }

            #endregion

            #region Þikayet Aþamasý

            if (mFoy.AV001_TI_BIL_SIKAYETCollection.Count > 0)
            {
                foreach (AV001_TI_BIL_SIKAYET sikayet in mFoy.AV001_TI_BIL_SIKAYETCollection)
                {
                    if (sikayet.SIKAYET_TARIHI.HasValue)
                    {
                        if (!AsamaHelper.AsamaVarmi(136, 226, sikayet))
                        //&& !AsamaHelper.BuAsamaOncedenVarmi(136, 226, sikayet)
                        {
                            AV001_TDIE_BIL_ASAMA asm = new AV001_TDIE_BIL_ASAMA();
                            asm.ASAMA_ALT_KOD_ID = 136;
                            asm.ASAMA_KOD_ID = 226;
                            asm.ASAMA_TARIHI = sikayet.SIKAYET_TARIHI;
                            asm.ASAMA_KONU = "Þikayet";
                            asm.ADLI_BIRIM_ADLIYE_ID = mFoy.ADLI_BIRIM_ADLIYE_ID;
                            asm.ADLI_BIRIM_GOREV_ID = mFoy.ADLI_BIRIM_GOREV_ID;
                            asm.ADLI_BIRIM_NO_ID = mFoy.ADLI_BIRIM_NO_ID;
                            asm.ESAS_NO = mFoy.ESAS_NO;
                            asm.ICRA_FOY_ID = mFoy.ID;
                            asm.ASAMA_MODUL_ID = 1;

                            foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                            {
                                if (taraf.TAKIP_EDEN_MI)
                                {
                                    AV001_TDIE_BIL_ASAMA_TARAF asmTrf =
                                        asm.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                                    asmTrf.ASAMAYI_YAPAN_MI = taraf.TAKIP_EDEN_MI;
                                    asmTrf.CARI_ID = taraf.CARI_ID.Value;
                                    asmTrf.SIFAT_ID = taraf.TARAF_SIFAT_ID;

                                    StringBuilder aciklama = AciklamaGetir(mFoy,
                                                                           BelgeUtil.Inits.CariIsmiGetir(
                                                                               taraf.CARI_ID.Value),
                                                                           asm.ASAMA_TARIHI.Value.ToShortDateString());

                                    if (sikayet.SIKAYET_NEDEN_IDSource == null && sikayet.SIKAYET_NEDEN_ID.HasValue)
                                        sikayet.SIKAYET_NEDEN_IDSource =
                                            DataRepository.TI_KOD_SIKAYET_NEDENProvider.GetByID(
                                                sikayet.SIKAYET_NEDEN_ID.Value);

                                    aciklama.Append(" ");
                                    aciklama.Append(sikayet.SIKAYET_NEDEN_IDSource.SIKAYET_NEDEN);
                                    aciklama.Append(" Nedeni Ýle");
                                    aciklama.Append(" ");
                                    aciklama.Append("Þikayet Yapýldý.");
                                    asm.ASAMA_ACIKLAMA = aciklama.ToString();
                                }
                            }

                            foreach (
                                AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlu in
                                    mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                            {
                                AV001_TDIE_BIL_ASAMA_SORUMLU srm = asm.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.AddNew();
                                srm.CARI_ID = sorumlu.SORUMLU_AVUKAT_CARI_ID.Value;
                            }
                        }
                    }
                }
            }

            #endregion

            DataRepository.AV001_TDIE_BIL_ASAMAProvider.DeepSave(mFoy.AV001_TDIE_BIL_ASAMACollection);
        }

        public static void IlkTebligatAsamaHallet(AV001_TI_BIL_FOY mFoy)
        {
            ////17.02.2014 hata alýnmaktaydý. kapatýldý.
            //return;
            #region AsamaKayidi

            TList<TDIE_KOD_ASAMA_ILISKI> asama_ILISKIS =
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI(mFoy.TableName);
            DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(asama_ILISKIS, false, DeepLoadType.IncludeChildren,
                                                                  typeof(TDIE_KOD_ASAMA_ALT),
                                                                  typeof(TDI_KOD_TEBLIGAT_KONU));
            if (mFoy.AV001_TDIE_BIL_ASAMACollection.Count == 0)
                mFoy.AV001_TDIE_BIL_ASAMACollection = new TList<AV001_TDIE_BIL_ASAMA>();

            foreach (string str in mFoy.ChangedProperties)
            {
                TList<TDIE_KOD_ASAMA_ILISKI> iliskiS =
                    asama_ILISKIS.FindAll(delegate(TDIE_KOD_ASAMA_ILISKI obj) { return obj.SUTUN_ADI.Contains(str); });
                foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskiS)
                {
                    try
                    {
                        if (iliski != null && iliski.ASAMA_URETSIN_MI && iliski.AsamaDegerKarsilastir(mFoy))
                        {
                            foreach (AV001_TI_BIL_ALACAK_NEDEN ndn in mFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                            {
                                AV001_TDIE_BIL_ASAMA asm =
                                    ndn.AV001_TDIE_BIL_ASAMACollection.Find(AV001_TDIE_BIL_ASAMAColumn.ASAMA_ALT_KOD_ID,
                                                                            iliski.ALT_ASAMA_KOD_ID.Value);

                                if (asm != null)
                                {
                                    mFoy.AsamaDoldur(asm);
                                    asm.ASAMA_ACIKLAMA = iliski.AsamaAciklamaGetir(mFoy);
                                    if (mFoy.FOY_FERAGAT_TARIHI.HasValue)
                                        asm.ASAMA_TARIHI = iliski.AsamaTarihGetir(mFoy);
                                }
                                else
                                {
                                    AV001_TDIE_BIL_ASAMA asama = mFoy.AsamaGetir();
                                    asama.ASAMA_ALT_KOD_ID = iliski.ALT_ASAMA_KOD_ID.Value;
                                    asama.ASAMA_KOD_ID = iliski.ALT_ASAMA_KOD_IDSource.ASAMA_ID;
                                    asama.ASAMA_MODUL_ID = iliski.ALT_ASAMA_KOD_IDSource.ALT_ASAMA_MODUL_ID;
                                    asama.ASAMA_ACIKLAMA = iliski.AsamaAciklamaGetir(mFoy);
                                    if (mFoy.FOY_FERAGAT_TARIHI.HasValue)
                                        asama.ASAMA_TARIHI = iliski.AsamaTarihGetir(mFoy);

                                    foreach (
                                        AV001_TI_BIL_ALACAK_NEDEN_TARAF taraf in
                                            ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                                    {
                                        AV001_TDIE_BIL_ASAMA_TARAF trf =
                                            asama.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddNew();
                                        if (taraf.TARAF_SIFAT_ID.HasValue && taraf.TARAF_CARI_ID > 0)
                                        {
                                            trf.CARI_ID = taraf.TARAF_CARI_ID;
                                            trf.SIFAT_ID = taraf.TARAF_SIFAT_ID.Value;
                                            AV001_TI_BIL_FOY_TARAF foy_TARAF =
                                                mFoy.AV001_TI_BIL_FOY_TARAFCollection.Find("CARI_ID",
                                                                                           taraf.TARAF_CARI_ID);
                                            if (foy_TARAF != null)
                                                trf.KODU = ((TarafKodu)foy_TARAF.TARAF_KODU).ToString().Substring(0, 1);

                                            trf.ASAMAYI_YAPAN_MI = foy_TARAF.TAKIP_EDEN_MI;
                                        }
                                    }
                                    foreach (
                                        AV001_TI_BIL_FOY_SORUMLU_AVUKAT avukat in
                                            mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                                    {
                                        AV001_TDIE_BIL_ASAMA_SORUMLU srm =
                                            asama.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.AddNew();
                                        srm.CARI_ID = avukat.SORUMLU_AVUKAT_CARI_ID.Value;
                                    }
                                    mFoy.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                                    //mFoy.ASAMA_IDSource = asama;
                                    ndn.AV001_TDIE_BIL_ASAMACollection.Add(asama);
                                }
                            }
                        }

                        // Ýlk tebligat üretimi
                        if (iliski != null && iliski.TEBLIGAT_URETSIN_MI && iliski.TEBLIGAT_KONU_ID.HasValue
                            && mFoy.FORM_TIP_ID.HasValue && iliski.AsamaDegerKarsilastir(mFoy))
                        {
                            AV001_TDI_BIL_TEBLIGAT tebl =
                                mFoy.AV001_TDI_BIL_TEBLIGATCollection.Find(AV001_TDI_BIL_TEBLIGATColumn.KONU_ID,
                                                                           iliski.TEBLIGAT_KONU_ID.Value);
                            if (tebl != null)
                            {
                                mFoy.TebligatDoldur(tebl);
                                tebl.ACIKLAMA = iliski.AsamaAciklamaGetir(mFoy);
                                tebl.KONU_ID = iliski.TEBLIGAT_KONU_ID.Value;
                                //TODO: Yukarýdaki yer bugünü kurtarmak için yapýlmýþ olup acilen deðiþtirilmesi gerekmektedir.
                                if (iliski.TEBLIGAT_KONU_IDSource.ILK_TEBLIGAT_MI)
                                {
                                    tebl.HAZIRLAMA_TARIH = mFoy.TAKIP_TARIHI.Value;
                                    tebl.POSTALANMA_TARIH = mFoy.TAKIP_TARIHI.Value;
                                    tebl.HAZIRLAYAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
                                    //tebl.KAYIT_TARIHI = DataTime.Now;
                                    tebl.KONTROL_NE_ZAMAN = DateTime.Now;
                                    tebl.KONTROL_VERSIYON++;
                                    tebl.ICRA_ILK_TEBLIGAT_MI = true;
                                    tebl.ANA_TUR_ID = iliski.TEBLIGAT_KONU_IDSource.ANA_TUR_ID;
                                    tebl.ALT_TUR_ID = iliski.TEBLIGAT_KONU_IDSource.ALT_TUR_ID;
                                    tebl.MUHASEBE_ALT_KATEGORI_ID = (int)MuhasebeAltKategoriId.iLK_TEBLiGAT_GiDERi;
                                    tebl.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Clear();
                                    tebl.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Clear();
                                    foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                                    {
                                        if (!taraf.TAKIP_EDEN_MI) //Takip Edilenler
                                        {
                                            AV001_TDI_BIL_TEBLIGAT_MUHATAP mhtp =
                                                tebl.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddNew();
                                            mhtp.TEBLIGAT_HEDEF_TIP = 1; //TODO:Enum
                                            mhtp.ALAN_CARI_ID = taraf.CARI_ID;
                                            mhtp.MUHATAP_CARI_ID = taraf.CARI_ID.Value;
                                            mhtp.MUHATAP_TARAF_KOD = taraf.TARAF_KODU;
                                            mhtp.MUHASEBE_ALT_KATEGORI_ID =
                                                (int)AvukatProLib.Extras.MuhasebeAltKategoriId.iLK_TEBLiGAT_GiDERi;
                                            mhtp.EVRAK_TARIHI = DateTime.Today;
                                            mhtp.EVRAK_NO = DateTime.Today.Year + "/" + DateTime.Now.Millisecond;
                                            mhtp.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                                            mhtp.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                                            mhtp.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                                            mhtp.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                                            //TODO: Sýralý kayýt

                                            var cariAciklama = BelgeUtil.Inits.context.per_CARI_ACIKLAMAs.Single(item => item.ID == taraf.CARI_ID.Value); //Okan 12.08.2010
                                            mhtp.TEBLIGAT_ADRESI = String.Format("{0} {1} {2} {3} ",
                                                                                 cariAciklama.ADRES_1,
                                                                                 cariAciklama.ILCE,
                                                                                 cariAciklama.IL,
                                                                                 cariAciklama.ULKE);
                                        }
                                        else //Takip Edenler
                                        {
                                            AV001_TDI_BIL_TEBLIGAT_YAPAN ypn = tebl.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddNew();
                                            ypn.YAPAN_CARI_ID = taraf.CARI_ID.Value;
                                            ypn.TARAF_KOD = ((TarafKodu)taraf.TARAF_KODU).ToString()[0].ToString();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                tebl = mFoy.TebligatGetir();
                                tebl.ACIKLAMA = iliski.AsamaAciklamaGetir(mFoy);
                                tebl.KONU_ID = iliski.TEBLIGAT_KONU_ID.Value;
                                tebl.HAZIRLAYAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
                                tebl.TEBLIGAT_REFERANS_NO = AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit.TebligatReferansNoOlustur();

                                //TODO: Yukarýdaki yer bugünü kurtarmak için yapýlmýþ olup acilen deðiþtirilmesi gerekmektedir.

                                if (iliski.TEBLIGAT_KONU_IDSource.ILK_TEBLIGAT_MI)
                                {
                                    tebl.HAZIRLAMA_TARIH = mFoy.TAKIP_TARIHI.Value;
                                    tebl.POSTALANMA_TARIH = mFoy.TAKIP_TARIHI.Value;
                                    tebl.ANA_TUR_ID = iliski.TEBLIGAT_KONU_IDSource.ANA_TUR_ID;
                                    tebl.ALT_TUR_ID = iliski.TEBLIGAT_KONU_IDSource.ALT_TUR_ID;
                                    tebl.ICRA_ILK_TEBLIGAT_MI = true;
                                    tebl.MUHASEBE_ALT_KATEGORI_ID =
                                        (int)AvukatProLib.Extras.MuhasebeAltKategoriId.iLK_TEBLiGAT_GiDERi;
                                    //tebl.KAYIT_TARIHI = DataTime.Now;
                                    tebl.KONTROL_NE_ZAMAN = DateTime.Now;
                                    tebl.KONTROL_VERSIYON++;
                                    tebl.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Clear();
                                    tebl.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Clear();
                                    foreach (AV001_TI_BIL_FOY_TARAF taraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                                    {
                                        if (!taraf.TAKIP_EDEN_MI) //Takip Edilenler
                                        {
                                            AV001_TDI_BIL_TEBLIGAT_MUHATAP mhtp =
                                                tebl.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddNew();
                                            mhtp.TEBLIGAT_HEDEF_TIP = 1; //TODO:Enum
                                            mhtp.ALAN_CARI_ID = taraf.CARI_ID;
                                            mhtp.MUHATAP_CARI_ID = taraf.CARI_ID.Value;
                                            mhtp.MUHATAP_TARAF_KOD = taraf.TARAF_KODU;
                                            mhtp.MUHASEBE_ALT_KATEGORI_ID =
                                                (int)AvukatProLib.Extras.MuhasebeAltKategoriId.iLK_TEBLiGAT_GiDERi;
                                            mhtp.EVRAK_TARIHI = DateTime.Today;
                                            mhtp.EVRAK_NO = DateTime.Today.Year + "/" + DateTime.Now.Millisecond;
                                            mhtp.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                                            mhtp.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                                            mhtp.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                                            mhtp.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                                            //TODO: Sýralý kayýt
                                            var cariAciklama = BelgeUtil.Inits.context.per_CARI_ACIKLAMAs.Single(item => item.ID == taraf.CARI_ID.Value); //Okan 12.08.2010
                                            mhtp.TEBLIGAT_ADRESI = String.Format("{0} {1} {2} {3}",
                                                                                 cariAciklama.ADRES_1,
                                                                                 cariAciklama.ILCE,
                                                                                 cariAciklama.IL,
                                                                                 cariAciklama.ULKE);
                                        }
                                        else //TakipEdenler
                                        {
                                            AV001_TDI_BIL_TEBLIGAT_YAPAN ypn =
                                                tebl.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddNew();
                                            ypn.YAPAN_CARI_ID = taraf.CARI_ID.Value;
                                            ypn.TARAF_KOD = ((TarafKodu)taraf.TARAF_KODU).ToString()[0].ToString();
                                        }
                                    }
                                }
                                mFoy.AV001_TDI_BIL_TEBLIGATCollection.Add(tebl);
                            }
                        }
                    }
                    catch 
                    {
                    }
                }
            }
            //TODO:Alacak neden taraflarý bazýnda aþama üret.

            #endregion
        }

        /// <summary>
        /// Asamalara ASAMA_MODUL_ID atayan metod
        /// </summary>
        /// <param name="foy">Icra foy</param>
        public static void AsamalaraModulAta(AV001_TI_BIL_FOY foy)
        {
            foreach (AV001_TDIE_BIL_ASAMA asama in foy.AV001_TDIE_BIL_ASAMACollection)
            {
                //Parametre Icra oldugu icin modulID 1 atandi
                asama.ASAMA_MODUL_ID = 1;
            }
        }

    }
}