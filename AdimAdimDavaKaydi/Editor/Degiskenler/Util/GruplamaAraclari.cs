using AvukatProDegiskenler.Icra;
using AvukatProLib.Extras;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Data.Bases;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TXTextControl;

namespace AdimAdimDavaKaydi.Editor.Degiskenler.Util
{
    public static class BelgeAraclari
    {
        public static AV001_TDIE_BIL_BELGE BelgeKaydet(byte[] dizi, string dosyaIsmi, string dosyaUzantisi,
                                                       int belgeTurId)
        {
            var belge = new AV001_TDIE_BIL_BELGE();

            belge.BELGE_ADI = dosyaIsmi;
            belge.BELGE_REFERANS_NO = Guid.NewGuid().ToString().Substring(0, 7);
            belge.DOSYA_ADI = string.Format("{0}.{1}", dosyaIsmi, dosyaUzantisi);
            belge.DOKUMAN_UZANTI = dosyaUzantisi;
            belge.ICERIK = dizi;
            belge.BELGE_TUR_ID = belgeTurId; //9; // Rapor
            belge.ESAS_NO = "";
            belge.BELGEYI_YAZAN_ID = AvukatProLib.Kimlik.CurrentCariId;
            belge.STAMP = 0;
            TransactionManager tm = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tm.BeginTransaction();
                DataRepository.AV001_TDIE_BIL_BELGEProvider.Save(tm, belge);
                tm.Commit();
                return belge;
            }
            catch (Exception ex)
            {
                if (tm.IsOpen)
                    tm.Rollback();

                BelgeUtil.ErrorHandler.Catch("BelgeAraclari", ex);
            }

            return null;
        }
    }

    public class EditorAraclari
    {
        public static int GetCiktiSayisiBySablonAndIcraFoy(
                    AvpNg.Editor.UserControls.ucSablonYazdirmaSecim.YazdirmaSayilari yazdirmaSayilari, AV001_TI_BIL_FOY foy)
        {
            switch (yazdirmaSayilari)
            {
                case AvpNg.Editor.UserControls.ucSablonYazdirmaSecim.YazdirmaSayilari.Takip_Eden_Sayısı:
                    return HesapAraclari.Icra.AlacakliTarafSayisi(foy.ID);

                case AvpNg.Editor.UserControls.ucSablonYazdirmaSecim.YazdirmaSayilari.Takip_Edilen_Sayısı:
                    return HesapAraclari.Icra.BorcluTarafSayisi(foy.ID);

                case AvpNg.Editor.UserControls.ucSablonYazdirmaSecim.YazdirmaSayilari.Sorumlu_Avukat_Sayısı:
                    return HesapAraclari.Icra.SorumluAvukatSayisi(foy.ID);

                case
                    AvpNg.Editor.UserControls.ucSablonYazdirmaSecim.YazdirmaSayilari.
                        Takıp_Eden_Sayısı_ve_Sorumlu_Avukat_Sayısı:
                    return HesapAraclari.Icra.AlacakliTarafSayisi(foy.ID)
                           + HesapAraclari.Icra.SorumluAvukatSayisi(foy.ID);

                case
                    AvpNg.Editor.UserControls.ucSablonYazdirmaSecim.YazdirmaSayilari.
                        Takıp_Edılen_Sayısı_ve_Sorumlu_Avukat_Sayısı:
                    return HesapAraclari.Icra.AlacakliTarafSayisi(foy.ID)
                           + HesapAraclari.Icra.SorumluAvukatSayisi(foy.ID);

                case
                    AvpNg.Editor.UserControls.ucSablonYazdirmaSecim.YazdirmaSayilari.
                        Takıp_Eden_Sayısı_ve_Takıp_Edılen_Sayısı:
                    return HesapAraclari.Icra.AlacakliTarafSayisi(foy.ID)
                           + HesapAraclari.Icra.BorcluTarafSayisi(foy.ID);

                case
                    AvpNg.Editor.UserControls.ucSablonYazdirmaSecim.YazdirmaSayilari.
                        Takıp_Eden_Sayısı_ve_Takıp_Edılen_Sayısı_ve_Sorumlu_Avukat_Sayısı:
                    return HesapAraclari.Icra.AlacakliTarafSayisi(foy.ID)
                           + HesapAraclari.Icra.BorcluTarafSayisi(foy.ID)
                           + HesapAraclari.Icra.SorumluAvukatSayisi(foy.ID);

                case
                    AvpNg.Editor.UserControls.ucSablonYazdirmaSecim.YazdirmaSayilari.
                        Her_Taraf_için_ve_Bu_Tarafların_her_Bir_Adresi_İçinde_Birer_Tane:
                    return HesapAraclari.Icra.AlacakliTarafSayisi(foy.ID)
                           + HesapAraclari.Icra.BorcluTarafSayisi(foy.ID);

                case AvpNg.Editor.UserControls.ucSablonYazdirmaSecim.YazdirmaSayilari.Sadece_Bir_Kopyasını_Oluştur:
                    return 1;

                case AvpNg.Editor.UserControls.ucSablonYazdirmaSecim.YazdirmaSayilari.Hiçbiri:
                    return 0;

                default:
                    return 1;
            }

        }

        public static void InsertTextField(string yazi, int id, string name, List<TextField> lstfields, string Tablo)
        {
            TextField tf = new TextField();
            tf.ID = id;
            tf.Text = yazi;
            tf.Name = name;
            tf.DoubleClickEvent = true;
            tf.DoubledInputPosition = true;
            tf.Deleteable = true;
            tf.ShowActivated = true;

            lstfields.Add(tf);
        }

        public List<EditorDokuman> GetEditorDokumansBySablonAndDavaFoy(AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR sablon, AV001_TD_BIL_FOY foy, TextControl txControl)
        {
            byte[] dizi;
            txControl.Save(out dizi, BinaryStreamType.InternalFormat);

            EditorDokuman dokuman = new EditorDokuman(foy);
            dokuman.Dokuman = dizi;
            dokuman.Ad = sablon.AD;
            //if (GetTextControl(sablon, txControl))
            //{
            //    var gruplamaTipi = GetGruplamaTipiByTextFieldEnumerator(txControl.TextFields.GetEnumerator());

            //switch (gruplamaTipi)
            //{
            //    case EditorDokuman.GruplamaTipi.Standart:
            //    default:
            //        return new List<EditorDokuman>(new[] { GetEditorDokumansByStandartMode(txControl, foy, sablon) });

            //case EditorDokuman.GruplamaTipi.TakipEdilenAvukatları:
            //case EditorDokuman.GruplamaTipi.TarafBazindaTakipEdilenler:
            //    return GruplamaAraclari.Icra.IcraTarafBazindaGruplayarakAc(sablon, foy,
            //                                                               GruplamaAraclari.Icra.FoyTarafGrubu.
            //                                                                   TakipEdilenler, txControl, true);

            //case EditorDokuman.GruplamaTipi.TarafBazindaTakipEdenler:
            //    return GruplamaAraclari.Icra.IcraTarafBazindaGruplayarakAc(sablon, foy,
            //                                                               GruplamaAraclari.Icra.FoyTarafGrubu.
            //                                                                   TakipEdenler, txControl, true);

            //case EditorDokuman.GruplamaTipi.TarafBazindaTumTaraflar:
            //    return GruplamaAraclari.Icra.IcraTarafBazindaGruplayarakAc(sablon, foy,
            //                                                               GruplamaAraclari.Icra.FoyTarafGrubu.
            //                                                                   Tumu, txControl, false);

            //case EditorDokuman.GruplamaTipi.IcraGayrimenkulTapuMudurlukleri:
            //    return GruplamaAraclari.Icra.GetGrupluGayrimenkulTapuMudurluguneGore(foy, txControl, sablon);

            //case EditorDokuman.GruplamaTipi.ICraGayrimenkulBelediyeleri:
            //    return GruplamaAraclari.Icra.GetGrupluGayrimenkulBelediyereGore(foy, txControl, sablon);

            //case EditorDokuman.GruplamaTipi.AracTrafikSubeleri:
            //    return GruplamaAraclari.Icra.GetGrupluAracBilgileriTrafikSubesineGore(foy, txControl, sablon);

            //case EditorDokuman.GruplamaTipi.IcraGrupluNufusMudurlukleriTakipEdenTaraf:
            //    return GruplamaAraclari.Icra.GetGrupluNufusBilgileri(foy, txControl, sablon,
            //                                                         GruplamaAraclari.Icra.FoyTarafGrubu.
            //                                                             TakipEdenler);

            //case EditorDokuman.GruplamaTipi.IcraGrupluNufusMudurlukleriTakipEdilenTaraf:
            //    return GruplamaAraclari.Icra.GetGrupluNufusBilgileri(foy, txControl, sablon,
            //                                                         GruplamaAraclari.Icra.FoyTarafGrubu.
            //                                                             TakipEdilenler);

            //case EditorDokuman.GruplamaTipi.IcraGrupluNufusMudurlukleriFoyTaraf:
            //    return GruplamaAraclari.Icra.GetGrupluNufusBilgileri(foy, txControl, sablon,
            //                                                         GruplamaAraclari.Icra.FoyTarafGrubu.Tumu);

            //case EditorDokuman.GruplamaTipi.IcraGrupluNufusMudurlukleriIlceFoyTaraf:
            //    return GruplamaAraclari.Icra.GetGrupluIlceNufusBilgileri(foy, txControl, sablon,
            //                                                             GruplamaAraclari.Icra.FoyTarafGrubu.
            //                                                                 Tumu);

            //case EditorDokuman.GruplamaTipi.IcraGrupluNufusMudurlukleriIlceTakipEdenTaraf:
            //    return GruplamaAraclari.Icra.GetGrupluIlceNufusBilgileri(foy, txControl, sablon,
            //                                                             GruplamaAraclari.Icra.FoyTarafGrubu.
            //                                                                 TakipEdenler);

            //case EditorDokuman.GruplamaTipi.IcraGrupluNufusMudurlukleriIlceTakipEdilenTaraf:
            //    return GruplamaAraclari.Icra.GetGrupluIlceNufusBilgileri(foy, txControl, sablon,
            //                                                             GruplamaAraclari.Icra.FoyTarafGrubu.
            //                                                                 TakipEdilenler);

            //case EditorDokuman.GruplamaTipi.IcraGrupluBankayaGoreCekler:
            //    return GruplamaAraclari.Icra.GetGrupluCekBilgileriBankalaraGore(foy, txControl, sablon);

            //case EditorDokuman.GruplamaTipi.IcraGrupluBankayaSubelerineGoreCekler:
            //    return GruplamaAraclari.Icra.GetGrupluCekBilgileriBankaSubesineGore(foy, txControl, sablon);

            //case EditorDokuman.GruplamaTipi.IcraGruplu89_1Borclusu:
            //    return GruplamaAraclari.Icra.GetGruplu89Muhattaplari(foy, txControl, sablon,
            //                                                         TebligatKonu.HI_89_1);
            //case EditorDokuman.GruplamaTipi.IcraGruplu89_2Borclusu:
            //    return GruplamaAraclari.Icra.GetGruplu89Muhattaplari(foy, txControl, sablon,
            //                                                         TebligatKonu.HI_89_2);
            //case EditorDokuman.GruplamaTipi.IcraGruplu89_3Borclusu:
            //    return GruplamaAraclari.Icra.GetGruplu89Muhattaplari(foy, txControl, sablon,
            //                                                         TebligatKonu.HI_89_3);

            //case EditorDokuman.GruplamaTipi.IcraHacizleri:
            //    return GruplamaAraclari.Icra.GetGrupluHacizBorclulari(foy, txControl, sablon);
            //case EditorDokuman.GruplamaTipi.IcraGrupluNakiteDonmusGayriNakitler:
            //    return GruplamaAraclari.Icra.GetGrupluGayriNakitler(foy, txControl, sablon);
            //    }
            //}

            //return null;

            //dokuman.
            GetTextControl(sablon, txControl);

            return new List<EditorDokuman>(new[] { GetEditorDokumansByStandartMode(txControl, foy, sablon) });

            //return new List<EditorDokuman>() { dokuman };
        }

        /// <summary>
        /// Gönderdiğimiz föye göre şablonu doldurur ve Tekrar durumlarına göre EditorDokuman Listesi döndürür
        /// </summary>
        /// <param name="sablon"></param>
        /// <param name="foy"></param>
        /// <returns></returns>
        public List<EditorDokuman> GetEditorDokumansBySablonAndIcraFoy(AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR sablon,
                                                                       AV001_TI_BIL_FOY foy, TextControl txControl, string BarkodTip)
        {
            if (GetTextControl(sablon, txControl))
            {
                var gruplamaTipi = GetGruplamaTipiByTextFieldEnumerator(txControl.TextFields.GetEnumerator());

                switch (gruplamaTipi)
                {
                    case EditorDokuman.GruplamaTipi.Standart:
                    default:
                        return new List<EditorDokuman>(new[] { GetEditorDokumansByStandartMode(txControl, foy, sablon) });

                    case EditorDokuman.GruplamaTipi.TakipEdilenAvukatları:
                    case EditorDokuman.GruplamaTipi.TarafBazindaTakipEdilenler:
                        return GruplamaAraclari.Icra.IcraTarafBazindaGruplayarakAc(sablon, foy,
                                                                                   GruplamaAraclari.Icra.FoyTarafGrubu.
                                                                                       TakipEdilenler, txControl, true, BarkodTip);

                    case EditorDokuman.GruplamaTipi.TarafBazindaTakipEdenler:
                        return GruplamaAraclari.Icra.IcraTarafBazindaGruplayarakAc(sablon, foy,
                                                                                   GruplamaAraclari.Icra.FoyTarafGrubu.
                                                                                       TakipEdenler, txControl, true, BarkodTip);

                    case EditorDokuman.GruplamaTipi.TarafBazindaTumTaraflar:
                        return GruplamaAraclari.Icra.IcraTarafBazindaGruplayarakAc(sablon, foy,
                                                                                   GruplamaAraclari.Icra.FoyTarafGrubu.
                                                                                       Tumu, txControl, false, BarkodTip);

                    case EditorDokuman.GruplamaTipi.IcraGayrimenkulTapuMudurlukleri:
                        return GruplamaAraclari.Icra.GetGrupluGayrimenkulTapuMudurluguneGore(foy, txControl, sablon);

                    case EditorDokuman.GruplamaTipi.ICraGayrimenkulBelediyeleri:
                        return GruplamaAraclari.Icra.GetGrupluGayrimenkulBelediyereGore(foy, txControl, sablon);

                    case EditorDokuman.GruplamaTipi.AracTrafikSubeleri:
                        return GruplamaAraclari.Icra.GetGrupluAracBilgileriTrafikSubesineGore(foy, txControl, sablon);

                    case EditorDokuman.GruplamaTipi.IcraGrupluNufusMudurlukleriTakipEdenTaraf:
                        return GruplamaAraclari.Icra.GetGrupluNufusBilgileri(foy, txControl, sablon,
                                                                             GruplamaAraclari.Icra.FoyTarafGrubu.
                                                                                 TakipEdenler);

                    case EditorDokuman.GruplamaTipi.IcraGrupluNufusMudurlukleriTakipEdilenTaraf:
                        return GruplamaAraclari.Icra.GetGrupluNufusBilgileri(foy, txControl, sablon,
                                                                             GruplamaAraclari.Icra.FoyTarafGrubu.
                                                                                 TakipEdilenler);

                    case EditorDokuman.GruplamaTipi.IcraGrupluNufusMudurlukleriFoyTaraf:
                        return GruplamaAraclari.Icra.GetGrupluNufusBilgileri(foy, txControl, sablon,
                                                                             GruplamaAraclari.Icra.FoyTarafGrubu.Tumu);

                    case EditorDokuman.GruplamaTipi.IcraGrupluNufusMudurlukleriIlceFoyTaraf:
                        return GruplamaAraclari.Icra.GetGrupluIlceNufusBilgileri(foy, txControl, sablon,
                                                                                 GruplamaAraclari.Icra.FoyTarafGrubu.
                                                                                     Tumu);

                    case EditorDokuman.GruplamaTipi.IcraGrupluNufusMudurlukleriIlceTakipEdenTaraf:
                        return GruplamaAraclari.Icra.GetGrupluIlceNufusBilgileri(foy, txControl, sablon,
                                                                                 GruplamaAraclari.Icra.FoyTarafGrubu.
                                                                                     TakipEdenler);

                    case EditorDokuman.GruplamaTipi.IcraGrupluNufusMudurlukleriIlceTakipEdilenTaraf:
                        return GruplamaAraclari.Icra.GetGrupluIlceNufusBilgileri(foy, txControl, sablon,
                                                                                 GruplamaAraclari.Icra.FoyTarafGrubu.
                                                                                     TakipEdilenler);

                    case EditorDokuman.GruplamaTipi.IcraGrupluBankayaGoreCekler:
                        return GruplamaAraclari.Icra.GetGrupluCekBilgileriBankalaraGore(foy, txControl, sablon);

                    case EditorDokuman.GruplamaTipi.IcraGrupluBankayaSubelerineGoreCekler:
                        return GruplamaAraclari.Icra.GetGrupluCekBilgileriBankaSubesineGore(foy, txControl, sablon);

                    case EditorDokuman.GruplamaTipi.IcraGruplu89_1Borclusu:
                        return GruplamaAraclari.Icra.GetGruplu89Muhattaplari(foy, txControl, sablon,
                                                                             TebligatKonu.HI_89_1, BarkodTip);

                    case EditorDokuman.GruplamaTipi.IcraGruplu89_2Borclusu:
                        return GruplamaAraclari.Icra.GetGruplu89Muhattaplari(foy, txControl, sablon,
                                                                             TebligatKonu.HI_89_2, BarkodTip);

                    case EditorDokuman.GruplamaTipi.IcraGruplu89_3Borclusu:
                        return GruplamaAraclari.Icra.GetGruplu89Muhattaplari(foy, txControl, sablon,
                                                                             TebligatKonu.HI_89_3, BarkodTip);

                    case EditorDokuman.GruplamaTipi.IcraHacizleri:
                        return GruplamaAraclari.Icra.GetGrupluHacizBorclulari(foy, txControl, sablon);

                    case EditorDokuman.GruplamaTipi.IcraGrupluNakiteDonmusGayriNakitler:
                        return GruplamaAraclari.Icra.GetGrupluGayriNakitler(foy, txControl, sablon);
                }
            }

            return null;
        }

        public EditorDokuman GetEditorDokumansByStandartMode(TextControl txControl, AV001_TI_BIL_FOY foy,
                                                                     AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rapor)
        {
            TextField[] fieldListesi = new TextField[txControl.TextFields.Count];
            txControl.TextFields.CopyTo(fieldListesi, 0);

            foreach (var field in fieldListesi)
            {
                txControl.Select(field.Start, 1);
                object sonuc = GetValueByTextFieldAndFoy(field, foy, txControl);

                if (sonuc is DegiskenDegeri)
                {
                    var dEgeri = sonuc as DegiskenDegeri;
                    field.Text = dEgeri.Icerik;
                }
                else if (sonuc is string)
                {
                    if (sonuc.ToString().Length > 0 || field.Text.StartsWith("["))
                    {
                        if (string.IsNullOrEmpty(sonuc.ToString()) || sonuc.ToString() == "")
                            field.Text = " ";
                        else
                            field.Text = sonuc.ToString();
                    }
                }
                else if (sonuc is List<TextField>)
                {
                    var items = sonuc as List<TextField>;
                    field.Text = string.Empty;

                    foreach (var item in items)
                    {
                        field.Text += item.Text;
                    }
                }
            }

            byte[] dizi;
            txControl.Save(out dizi, BinaryStreamType.InternalFormat);

            EditorDokuman dokuman = new EditorDokuman(foy);
            dokuman.Dokuman = dizi;
            dokuman.Ad = rapor.AD;

            //Ödeme ve icra emirlerinin borçlu sayısından bir fazla yazdırılmasını sağlamak için eklendi.
            int[] idDizi = new int[] { 278, 279, 280, 281, 282, 283, 284, 273, 277, 341 };
            List<int> idListesi = new List<int>(idDizi);

            if (idListesi.Find(vi => vi == rapor.ID) != 0)
            {
                dokuman.CiktiSayisi = HesapAraclari.Icra.BorcluTarafSayisi(foy.ID) + 1;
            }

            //dokuman.Sablon = rapor;
            dokuman.Taraflar = EditorDokuman.EditorDokumanTarafCollection.GetAllTarafByEntity(foy);
            if (rapor.Tag != null)
                dokuman.CiktiSayisi =
                    GetCiktiSayisiBySablonAndIcraFoy(
                        (AvpNg.Editor.UserControls.ucSablonYazdirmaSecim.YazdirmaSayilari)rapor.Tag, foy);

            return dokuman;
        }

        //aykut
        public EditorDokuman GetEditorDokumansByStandartMode(TextControl txControl, AV001_TD_BIL_FOY foy, AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rapor)
        {
            TextField[] fieldListesi = new TextField[txControl.TextFields.Count];
            txControl.TextFields.CopyTo(fieldListesi, 0);

            foreach (var field in fieldListesi)
            {
                txControl.Select(field.Start, 1);
                object sonuc = GetValueByTextFieldAndFoy(field, foy, txControl);

                if (sonuc is DegiskenDegeri)
                {
                    var dEgeri = sonuc as DegiskenDegeri;
                    field.Text = dEgeri.Icerik;
                }
                else if (sonuc is string)
                {
                    if (sonuc.ToString().Length > 0 || field.Text.StartsWith("["))
                    {
                        if (string.IsNullOrEmpty(sonuc.ToString()) || sonuc.ToString() == "")
                            field.Text = " ";
                        else
                            field.Text = sonuc.ToString();
                    }
                }
                else if (sonuc is List<TextField>)
                {
                    var items = sonuc as List<TextField>;
                    field.Text = string.Empty;

                    foreach (var item in items)
                    {
                        field.Text += item.Text;
                    }
                }
            }

            byte[] dizi;
            txControl.Save(out dizi, BinaryStreamType.InternalFormat);

            EditorDokuman dokuman = new EditorDokuman(foy);
            dokuman.Dokuman = dizi;
            dokuman.Ad = rapor.AD;

            //Ödeme ve icra emirlerinin borçlu sayısından bir fazla yazdırılmasını sağlamak için eklendi.
            int[] idDizi = new int[] { 278, 279, 280, 281, 282, 283, 284, 273, 277, 341 };
            List<int> idListesi = new List<int>(idDizi);

            if (idListesi.Find(vi => vi == rapor.ID) != 0)
            {
                dokuman.CiktiSayisi = HesapAraclari.Icra.BorcluTarafSayisi(foy.ID) + 1;
            }

            //dokuman.Sablon = rapor;
            dokuman.Taraflar = EditorDokuman.EditorDokumanTarafCollection.GetAllTarafByEntity(foy);
            //if (rapor.Tag != null)
            //    dokuman.CiktiSayisi =
            //        GetCiktiSayisiBySablonAndIcraFoy(
            //            (AvpNg.Editor.UserControls.ucSablonYazdirmaSecim.YazdirmaSayilari)rapor.Tag, foy);

            return dokuman;
        }

        public List<TextField> GetFieldListByEditorDokumanAndTextControl(EditorDokuman dokuman, TextControl txControl)
        {
            List<TextField> fieldListesi = new List<TextField>();

            if (dokuman.Dokuman == null) return new List<TextField>();

            txControl.Load(dokuman.Dokuman, BinaryStreamType.InternalFormat);

            var fieldEnuma = txControl.TextFields.GetEnumerator();

            while (fieldEnuma.MoveNext())
            {
                fieldListesi.Add(fieldEnuma.Current as TextField);
            }

            return fieldListesi;
        }

        public EditorDokuman.GruplamaTipi GetGruplamaTipiByTextFieldEnumerator(
                    TextFieldCollection.TextFieldEnumerator fieldEnumerator)
        {
            while (fieldEnumerator.MoveNext())
            {
                var field = fieldEnumerator.Current as TextField;
                switch (field.Text)
                {
                    case "[ICRA] FOY TUM TARAFLAR":
                        return EditorDokuman.GruplamaTipi.TarafBazindaTumTaraflar;

                    case "[ICRA] TEBLIGAT TARAF BAZINDA AD ADRES":
                    case "[ICRA] FOY TARAF BAZINDA AD ADRES VEKILLI (TAKIP EDILEN)":
                    case "[ICRA] FOY TARAF BAZINDA AD ADRES (TAKIP EDILEN)":
                    case "[ICRA] FOY TARAF BORCLU VEKILLERI":
                    case "[ICRA] FOY TARAF BAZINDA PTT BARKOD":
                        return EditorDokuman.GruplamaTipi.TarafBazindaTakipEdilenler;

                    case "[ICRA] FOY TARAF BAZINDA AD ADRES (TAKIP EDEN)":
                        return EditorDokuman.GruplamaTipi.TakipEdilenAvukatları;

                    case "[ICRA] FOY TARAF BAZINDA AD ADRES VEKILLI (TAKIP EDEN)":
                        return EditorDokuman.GruplamaTipi.TarafBazindaTakipEdenler;

                    case "[ICRA] GRUPLU GAYRIMENKUL TAPU MUDURLUK":
                        return EditorDokuman.GruplamaTipi.IcraGayrimenkulTapuMudurlukleri;

                    case "[ICRA] GRUPLU ARAC TRAFIK SUBESI":
                        return EditorDokuman.GruplamaTipi.AracTrafikSubeleri;

                    case "[ICRA] GRUPLU GAYRIMENKUL BELEDIYESI":
                        return EditorDokuman.GruplamaTipi.ICraGayrimenkulBelediyeleri;

                    case "[ICRA] GRUPLU TAKIP EDEN TARAF NUFUS MUDURLUKLERI":
                        return EditorDokuman.GruplamaTipi.IcraGrupluNufusMudurlukleriTakipEdenTaraf;

                    case "[ICRA] GRUPLU TAKIP EDILEN TARAF NUFUS MUDURLUKLERI":
                        return EditorDokuman.GruplamaTipi.IcraGrupluNufusMudurlukleriTakipEdilenTaraf;

                    case "[ICRA] GRUPLU FOY TARAF NUFUS MUDURLUKLERI":
                        return EditorDokuman.GruplamaTipi.IcraGrupluNufusMudurlukleriFoyTaraf;

                    case "[ICRA] GRUPLU TAKIP EDEN TARAF ILCE NUFUS MUDURLUKLERI":
                        return EditorDokuman.GruplamaTipi.IcraGrupluNufusMudurlukleriIlceTakipEdenTaraf;

                    case "[ICRA] GRUPLU TAKIP EDILEN TARAF ILCE NUFUS MUDURLUKLERI":
                        return EditorDokuman.GruplamaTipi.IcraGrupluNufusMudurlukleriIlceTakipEdilenTaraf;

                    case "[ICRA] GRUPLU FOY TARAF ILCE NUFUS MUDURLUKLERI":
                        return EditorDokuman.GruplamaTipi.IcraGrupluNufusMudurlukleriIlceFoyTaraf;

                    case "[ICRA] GRUPLU FOY CEK BANKALARI":
                        return EditorDokuman.GruplamaTipi.IcraGrupluBankayaGoreCekler;

                    case "[ICRA] GRUPLU FOY CEK BANKA SUBELERI":
                        return EditorDokuman.GruplamaTipi.IcraGrupluBankayaSubelerineGoreCekler;

                    case "[ICRA] GRUPLU 89/1 HACIZ IHBARNAME BORCLULARI":
                    case "[ICRA] GRUPLU 89/1 HACIZ IHBARNAME BORCLULARI ADRESLI":
                        return EditorDokuman.GruplamaTipi.IcraGruplu89_1Borclusu;

                    case "[ICRA] GRUPLU 89/2 HACIZ IHBARNAME BORCLULARI":
                    case "[ICRA] GRUPLU 89/2 HACIZ IHBARNAME BORCLULARI ADRESLI":
                        return EditorDokuman.GruplamaTipi.IcraGruplu89_2Borclusu;

                    case "[ICRA] GRUPLU 89/3 HACIZ IHBARNAME BORCLULARI":
                    case "[ICRA] GRUPLU 89/3 HACIZ IHBARNAME BORCLULARI ADRESLI":
                        return EditorDokuman.GruplamaTipi.IcraGruplu89_3Borclusu;

                    case "[ICRA] GRUPLU HACIZ TARIH VE SAATI":
                    case "[ICRA] GRUPLU HACIZ BORCLU ADI":
                        return EditorDokuman.GruplamaTipi.IcraHacizleri;

                    case "[ICRA] GRUPLU GAYRINAKITLER":
                        return EditorDokuman.GruplamaTipi.IcraGrupluNakiteDonmusGayriNakitler;
                }
            }

            return EditorDokuman.GruplamaTipi.Standart;
        }

        /// <summary>
        /// gönderdiğimiz şablon raporu üzerinde bulunan TextField leri döndürür.
        /// </summary>
        /// <param name="rapor"></param>
        /// <returns></returns>
        private bool GetTextControl(AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rapor, TextControl txControl)
        {
            return LoadSablon(txControl, rapor);
        }

        private object GetValueByTextFieldAndFoy(TextField field, AV001_TI_BIL_FOY foy, TextControl txControl)
        {
            object returnValue = string.Empty;
            string name = string.Empty;
            IEntity Record = foy;
            try
            {
                //Hataya meyilli bir alan hata alırsak işine devam etsin
                name = field.Name.Substring(0, field.Name.LastIndexOf("__"));
            }
            catch
            {
            }

            //string degiskenAdi = GetDegiskenAdByGorunenAd(field.Text);
            switch (name.TrimEnd())
            {
                #region

                case "AntetBuroBilgileri":
                    TList<AV001_TDI_BIL_ANTET> aaa = AvukatProDegiskenler.Icra.Degiskenler.GetAntetBilgileri();
                    if (aaa.Count == 0)
                        returnValue = "";
                    else
                    {
                        returnValue = "";
                        returnValue += aaa[0].UST_1; //büro adı

                        string[] dizi = aaa[0].UST_2.Split(','); //avukat, kimlik nolar ve diğer bilgileri yazdırılıyor
                        List<string> olanlar = new List<string>();
                        List<string> olmayanlar = new List<string>();

                        foreach (string item in dizi)
                        {
                            if (!string.IsNullOrEmpty(item.Trim()))
                            {
                                AV001_TDI_BIL_CARI car = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(Convert.ToInt32(item.Trim()));
                                if (car.VERGI_DAIRESI.Length > 0)
                                {
                                    if (!olanlar.Contains(car.ID.ToString()))
                                        olanlar.Add(car.ID.ToString());
                                }
                                else
                                {
                                    if (!olmayanlar.Contains(car.ID.ToString()))
                                        olmayanlar.Add(car.ID.ToString());
                                }
                            }
                        }

                        foreach (string item in olanlar)
                        {
                            if (!string.IsNullOrEmpty(item.Trim()))
                            {
                                AV001_TDI_BIL_CARI car = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(Convert.ToInt32(item.Trim()));
                                returnValue += "\nAv. " + car.AD + " (";

                                TList<AV001_TDI_BIL_CARI_KIMLIK> tc = DataRepository.AV001_TDI_BIL_CARI_KIMLIKProvider.GetByCARI_ID(car.ID);

                                if (tc.Count > 0)
                                    returnValue += tc[0].TC_KIMLIK_NO.Length > 0 ? ("TC No :" + tc[0].TC_KIMLIK_NO) : "";

                                returnValue += " " + (car.VERGI_DAIRESI.Length > 0 ? ("VD/No :" + car.VERGI_DAIRESI + "/") : "") + (car.VERGI_DAIRESI.Length > 0 ? car.VERGI_NO : ("SGK No :" + car.SG_NO));
                                returnValue += ")";
                            }
                        }

                        foreach (string item in olmayanlar)
                        {
                            if (!string.IsNullOrEmpty(item.Trim()))
                            {
                                AV001_TDI_BIL_CARI car = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(Convert.ToInt32(item.Trim()));
                                returnValue += "\nAv. " + car.AD + " (";

                                TList<AV001_TDI_BIL_CARI_KIMLIK> tc = DataRepository.AV001_TDI_BIL_CARI_KIMLIKProvider.GetByCARI_ID(car.ID);

                                if (tc.Count > 0)
                                    returnValue += tc[0].TC_KIMLIK_NO.Length > 0 ? ("TC No :" + tc[0].TC_KIMLIK_NO) : "";

                                returnValue += " " + (car.VERGI_DAIRESI.Length > 0 ? ("VD/No :" + car.VERGI_DAIRESI + "/") : "") + (car.VERGI_DAIRESI.Length > 0 ? car.VERGI_NO : ("SGK No :" + car.SG_NO));
                                returnValue += ")";
                            }
                        }
                        returnValue += "\n" + aaa[0].ALT_1.Replace("\n", " "); // adres
                        returnValue += "\nTel :" + aaa[0].ALT_2 + " Fax :" + aaa[0].ALT_3 + " Email :" + aaa[0].ALT_5; //telefon fax email
                        returnValue += "\nBüro IBAN :" + aaa[0].UST_4;
                    }
                    break;

                case "MudurlukIBANNo":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetMudurlukIBANNo(foy);
                    break;
                //efe
                //[ICRA] MEHİL BİLGİLERİ
                case "ICRA_Mehil_Bilgileri":
                    AvukatProDegiskenler.Icra.Degiskenler.GetMehilBilgileri(foy, txControl, field);
                    break;

                //efe
                //[ICRA] İLAM BİLGİLERİ TABLOLU
                case "ICRA_Ilam_Bilgileri_Tablolu":
                    AvukatProDegiskenler.Icra.Degiskenler.GetIlamBilgileri(foy, txControl, field);
                    break;

                //efe
                //[ICRA] BORÇLU GELİŞMELERİ
                case "ICRA_Borclu_Gelismeleri":
                    AvukatProDegiskenler.Icra.Degiskenler.GetBorcluGelismeleri(foy, txControl, field);
                    break;

                //efe
                //[ICRA] BORÇLU TAAHHÜTLERİ
                case "ICRA_Borclu_Taahhutleri":
                    AvukatProDegiskenler.Icra.Degiskenler.GetBorcluTaahhutleri(foy, txControl, field);
                    break;

                //efe
                //[ICRA] TAKİP GELİŞMELERİ
                case "ICRA_Takip_Gelismeleri":
                    AvukatProDegiskenler.Icra.Degiskenler.GetTakipGelismeleri(foy, txControl, field);
                    break;

                //efe
                //[ICRA] MÜVEKKİLE ÖDEME BİLGİLERİ
                case "ICRA_Muvekkile_Odeme_Bilgileri":
                    AvukatProDegiskenler.Icra.Degiskenler.GetMuvekkileOdemeBilgileri(foy, txControl, field);
                    break;

                //efe
                //[ICRA] İHTİYATİ TEDBİR BİLGİSİ
                case "ICRA_Ihtiyati_Tedbir":
                    AvukatProDegiskenler.Icra.Degiskenler.GetIhtiyatiTedbirBilgisi(foy, txControl, field);
                    break;

                //efe
                //[ICRA] İHTİYATİ HACİZ BİLGİSİ
                case "ICRA_Ihtiyati_Haciz":
                    AvukatProDegiskenler.Icra.Degiskenler.GetIhtiyatiHacizBilgisi(foy, txControl, field);
                    break;

                //efe
                //[ICRA] BORÇLU ÖDEME BİLGİLERİ
                case "ICRA_Borclu_Odemeleri":
                    AvukatProDegiskenler.Icra.Degiskenler.GetBorcluOdemeBilgileri(foy, txControl, field);
                    break;

                //efe
                //[ICRA] HACİZ BİLGİLERİ
                case "ICRA_Haciz_Bilgileri":
                    AvukatProDegiskenler.Icra.Degiskenler.GetHacizBilgileri(foy, txControl, field);
                    break;

                //efe
                //[ICRA] SATIŞ BİLGİLERİ
                case "ICRA_Satis_Bilgileri":
                    AvukatProDegiskenler.Icra.Degiskenler.GetSatisBilgileri(foy, txControl, field);
                    break;

                //[ICRA] ALACAK NEDENLERI
                case "Icra_Alacak_Nedenleri":
                    AvukatProDegiskenler.Icra.Degiskenler.GetAlacakNedenleri(foy, txControl, field);
                    break;

                //[ICRA] ACIKLAMA
                case "Icra_Aciklama":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetAciklama(foy, txControl, field);
                    break;

                //[ICRA] INTIKAL TARIHI
                case "Icra_Intikal_Tarihi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIntikalTarihi(foy, txControl, field);
                    break;

                //[ICRA] INFAZ TARIHI
                case "Icra_Infaz_Tarihi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetInfazTarihi(foy, txControl, field);
                    break;

                //[ICRA] ORNEK KOD FORM TIPI
                case "Icra_Ornek_Kod_Form_Tipi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFormTipi(foy, txControl, field);
                    break;

                //[ICRA] HESAP DETAYLARI1
                case "Icra_Hesap_Detaylari_1":
                    AvukatProDegiskenler.Icra.Degiskenler.GetHesapDetaylari1(foy, txControl, field);
                    break;

                //[ICRA] HESAP DETAYLARI2
                case "Icra_Hesap_Detaylari_2":
                    AvukatProDegiskenler.Icra.Degiskenler.GetHesapDetaylari2(foy, txControl, field);
                    break;

                //[ICRA] HESAP DETAYLARI3
                case "Icra_Hesap_Detaylari_3":
                    AvukatProDegiskenler.Icra.Degiskenler.GetHesapDetaylari3(foy, txControl, field);
                    break;

                //[ICRA] IHTIYATI TEDBIR HACIZ TALEP TARIHI
                case "Icra_Ihtiyati_Tedbir_Haciz_Talep_Tarihi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIhtiyatiHacizTalepTarihi(foy, txControl,
                                                                                                    field);
                    break;

                //[ICRA] IHTIYATI TEDBIR HACIZ GOREVLI MAHKEMESI
                case "Icra_Ihtiyati_Tedbir_Haciz_Gorevli_Mahkemesi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIhtiyatiHacizMahkemeGorevi(foy, txControl,
                                                                                                      field);
                    break;

                //[ICRA] IHTIYATI TEDBIR HACIZ ESAS NO
                case "Icra_Ihtiyati_Tedbir_Haciz_Esas_No":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIhtiyatiHacizEsasNo(foy, txControl, field);
                    break;

                //[ICRA] HARC GENEL TOPLAMI
                case "Icra_Harc_Genel_Toplami":
                    AvukatProDegiskenler.Icra.Degiskenler.GetHarcGenelToplami(foy, txControl, field);
                    break;

                //[ICRA] ALACAK BILGILERI BONO ICIN<
                case "Icra_Alacak_Bilgileri_Bono_Icin":
                    AvukatProDegiskenler.Icra.Degiskenler.GetAlacakBilgileri_BonoIcin(foy, txControl, field);
                    break;

                //[ICRA] ALACAK BILGILERI CEK ICIN
                case "Icra_Alacak_Bilgileri_Cek_Icin":
                    AvukatProDegiskenler.Icra.Degiskenler.GetAlacakBilgileri_CekIcin(foy, txControl, field);
                    break;

                //[ICRA] HESAPLANMIS DEGERLER ACIKLAMASIZ
                case "Icra_Hesaplanmis_Degerler_Aciklamasiz":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetHesaplanmisDegerlerFromNesne(
                            ((AV001_TI_BIL_FOY)Record), txControl, "", "", false, field);
                    break;

                case "Icra_Harc_Detaylari":
                    AvukatProDegiskenler.Icra.Degiskenler.GetHarcDetaylari(foy, txControl, field);
                    break;

                case "Icra_Masraf_Makbuzu_Toplam":
                    AvukatProDegiskenler.Icra.Degiskenler.GetIcraGrupluMasrafBilgileri(foy, txControl, field,
                                                                                       AvukatProDegiskenler.Icra.
                                                                                           Degiskenler.MasrafGrubu.
                                                                                           Toplam);
                    break;

                //[ICRA] MASRAF MAKBUZU ALACAGA MAHSUPLU MAL ALIM
                case "Icra_Masraf_Makbuzu_AlacagaMahsupluMalAlim":
                    AvukatProDegiskenler.Icra.Degiskenler.GetIcraGrupluMasrafBilgileri(foy, txControl, field,
                                                                                       AvukatProDegiskenler.Icra.
                                                                                           Degiskenler.MasrafGrubu.
                                                                                           alacagaMahMalAlimMasraflari);
                    break;

                //[ICRA] MASRAF MAKBUZU DIGER ALACAKLAR
                case "Icra_Masraf_Makbuzu_DigerAlacakla":
                    AvukatProDegiskenler.Icra.Degiskenler.GetIcraGrupluMasrafBilgileri(foy, txControl, field,
                                                                                       AvukatProDegiskenler.Icra.
                                                                                           Degiskenler.MasrafGrubu.
                                                                                           digerAlacaklar);
                    break;

                //[ICRA] MASRAF MAKBUZU HACIZ KESIF
                case "Icra_Masraf_Makbuzu_Haciz_Kesif":
                    AvukatProDegiskenler.Icra.Degiskenler.GetIcraGrupluMasrafBilgileri(foy, txControl, field,
                                                                                       AvukatProDegiskenler.Icra.
                                                                                           Degiskenler.MasrafGrubu.
                                                                                           hacisKesif);
                    break;

                case "Icra_Masraf_Makbuzu_IlkMasraflar":
                    AvukatProDegiskenler.Icra.Degiskenler.GetIcraGrupluMasrafBilgileri(foy, txControl, field,
                                                                                       AvukatProDegiskenler.Icra.
                                                                                           Degiskenler.MasrafGrubu.
                                                                                           ilkMasraflar);
                    break;

                case "Icra_Borc_Taahhudu_Borclu_Adi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetGecerliTaahutBorcluAdi(foy);
                    break;

                case "Icra_Borc_Taahhudu_Taahhut_Tarihi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetGecerliTaahhutTarihi(foy);
                    break;

                case "Icra_Borc_Taahhudu_Odeme_Taahhutleri":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetGecerliTAahhutOdemeTaahhutleri(foy);
                    break;

                case "Icra_Borc_Taahhudu_Alacakli_Vekil_Adi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetGecerliTaahhutAlacakliVekilAdi(foy);
                    break;

                case "Icra_Borc_Taahhudu_Hesap_Degerleri":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetGecerliTaahhutHesapDegerleri(foy);
                    break;

                case "DavaDAVA_EDENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "IcraBORCLU_MIRASCI":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, 6, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "DavaDAVA_EDİLENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "IcraTAKİP_EDENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "Icra_Alacakli_Sifatli_Vekil_Bilgili":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, true, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "Icra_Borclu_Sifatli_Vekil_Bilgili":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, true, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "Icra_AlacakliBilgisiYEDAS":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetirForEnerji(Record, true, true);
                    break;

                case "Icra_AlacakliBilgisiNoAdresNoVekilTCYEDAS":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetirForEnerji(Record, true, false);
                    break;

                case "Icra_BorcluBilgisiYEDAS":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetirForEnerji(Record, false, true);
                    break;

                case "Icra_Borclu_Sifatli_Vekil_BilgiliTCYok":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, true, true, false);
                    break;

                case "Icra_Alacakli_Sifatli_Vekil_BilgiliTCYok":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, true, true, false);
                    break;

                case "IcraTAKİP_EDİLENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "SozlesmeDAVA_EDENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "SozlesmeDAVA_EDİLENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "HazirlikDAVA_EDENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "HazirlikDAVA_EDİLENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "RucuRÜCU_EDENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "RucuRÜCU_EDİLENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "DavaDAVA_KONUSU":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetDavaKonusu(((AV001_TD_BIL_FOY)Record).ID);
                    break;

                case "DavaCEZA_DAVA_KONUSU":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetDavaCezaKonusu(((AV001_TD_BIL_FOY)Record).ID);
                    break;

                case "DavaIDARE_DAVA_KONUSU":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetDavaIdareKonusu(((AV001_TD_BIL_FOY)Record).ID);
                    break;

                case "DavaHUKUKSAL_NEDENLER":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetHukuksalNedenler(((AV001_TD_BIL_FOY)Record).ID);
                    break;

                case "IcraTAKIP_TALEBI":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetIcraTakipTalebiFromNesne(((AV001_TI_BIL_FOY)Record));
                    break;

                case "IcraEsasNo":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetfoyBilgisiFromNesne(
                        (AV001_TI_BIL_FOY)Record, "ESAS_NO");

                    //returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraGrupluMasrafBilgileri((AV001_TI_BIL_FOY)Record, txControl, field);
                    break;

                case "IcraOrnekForm":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetFormOrnekAciklamaFromNesne(((AV001_TI_BIL_FOY)Record));
                    break;

                case "IcraAlacakNedenKodu":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetIcraKodAlacakNedeniFromNesne(
                            ((AV001_TI_BIL_FOY)Record));
                    break;

                case "IcraIcraMudurlugu":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetIcrmBilgisiFromNesne((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraTakipTarihi":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetfoyTakipTarihiFromNesne((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraTakipYolu":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetTakipYoluFromNesne(((AV001_TI_BIL_FOY)Record));
                    break;

                case "IcraAlacakNedeni":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetIcraAlacakNedeniFromNesne((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraKiraAlacakNeden":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetIcraKiraAlacakNedeniFromNesne((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraIlamBilgisi":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetIcraIlamBilgisiFromNesne((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraOrnek14TahliyeTalebi":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetOrnek14TahliyeTalebiFromNesne((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraHesaplanmisDegerler":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetHesaplanmisDegerlerFromNesne(
                            ((AV001_TI_BIL_FOY)Record), txControl, "", "", true, field);
                    break;

                case "IcraHesaplanmisDegerVeAciklaması":
                    AvukatProDegiskenler.Icra.Degiskenler.GetIcraHesapsWithAciklamaFromNesne((AV001_TI_BIL_FOY)Record,
                                                                                             txControl, true);
                    break;

                case "IcraSorumluAvukat":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraSorumluAvukat(
                        ((AV001_TI_BIL_FOY)Record), txControl, false);
                    break;

                case "SatisBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetSatisBilgisi(((AV001_TI_BIL_FOY)Record),
                                                                                        txControl,
                                                                                        txControl.Selection.Start);
                    break;

                case "HacizBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetHacizBilgisi(((AV001_TI_BIL_FOY)Record),
                                                                                        txControl,
                                                                                        txControl.Selection.Start);
                    break;

                case "GayrimenkulBilgisi":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetGayrimenkulIpotekBilgisi((AV001_TI_BIL_FOY)Record,
                                                                                          true);
                    break;

                case "CariKimlikBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraTarafCariKimlikBilgisi(Record, txControl, false, null,
                                                                                        null);
                    break;

                case "HacizMahkemeBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetHacizMahkeme(((AV001_TI_BIL_FOY)Record),
                                                                                        txControl,
                                                                                        txControl.Selection.Start);
                    break;

                case "SatisMahkemeBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetHacizMahkeme(((AV001_TI_BIL_FOY)Record),
                                                                                        txControl,
                                                                                        txControl.Selection.Start);
                    break;

                case "IcraBorcluVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "IcraAlacakliVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "IcraBORCLU_MIRASCIVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, 6, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "DavaDAVA_EDİLENCariBilgisiVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "DavaDAVA_EDENCariBilgisiVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                //case "IcraTAKİP_EDENCariBilgisiVekilsiz":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, false);
                //    break;
                case "IcraAlacakliVekilsizTCliIBANli":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetirTCliIBANLi(Record, true, null, false);
                    break;

                case "IcraTAKİP_EDİLENCariBilgisiVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "SozlesmeDAVA_EDENCariBilgisiVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "SozlesmeDAVA_EDİLENCariBilgisiVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "HazirlikDAVA_EDENCariBilgisiVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "HazirlikDAVA_EDİLENCariBilgisiVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "RucuRÜCU_EDEIcra_Arac_BilgisiNCariBilgisiVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "RucuRÜCU_EDİLENCariBilgisiVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "Sozlesme_Sozlesme_Bilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.getSozlesmeBilgisi((AV001_TI_BIL_FOY)Record, txControl, txControl.Selection.Start);
                    break;

                case "DovizliAlacakTakipTarihindeYtl":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.DovizliAlacakTakipTarihindeYtl(((AV001_TI_BIL_FOY)Record).ID, txControl, txControl.Selection.Start);
                    break;

                case "BuGun":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetBugun();
                    break;

                case "BuKullanici":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetCurrentUser();
                    break;

                case "BuSaat":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetBuSaat();
                    break;

                case "KayıtTarihi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetKayitTarihi(Record);
                    break;

                case "KayitSaati":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetKayitSaati(Record);
                    break;

                case "KaydiYapanKullanici":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetKayitEden(Record);
                    break;

                case "Sube":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetSube(Record);
                    break;

                case "RehinBorclusu":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, 6, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "Icra_Kredi_Borclusu":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraKrediBorclusu(foy, txControl, field);
                    break;

                case "Icra_Alacak_Turu":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraAlacakTuru(foy, txControl, field);
                    break;

                case "Icra_Karsi_Taraflar":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraKarsiTaraflar(foy, txControl, field);
                    break;

                case "Icra_Sorumlu_Adi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraSorumlusu(foy, txControl, field, false);
                    break;

                case "Icra_Yetkili_Adi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraSorumlusu(foy, txControl, field, true);
                    break;

                case "IcraIstirakIstenenBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.IcraIstirakIstenenBilgisi((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraIstirakIsteyenBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.IcraIstirakIstenenBilgisi((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraHacizUcuncuSahisBilgisi":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.IcraHacizUcuncuSahisBilgisi((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraAlacakliVekilBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.IcraAlacakliVekilBilgisi((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraTebligatMuhattabTebligtarihi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.IcraTebligatMuhattabTebligtarihi((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraIstihkakEdenBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.IcraIstihkakEdenBilgisi((AV001_TI_BIL_FOY)Record);
                    break;

                case "Temsilbilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetTemsilBilgisi((AV001_TI_BIL_FOY)Record, TemsilBilgileri.Tumu);
                    break;

                case "TemsilNoterBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetTemsilBilgisi((AV001_TI_BIL_FOY)Record, TemsilBilgileri.Noter);
                    break;

                case "TemsilYetkibilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetTemsilBilgisi((AV001_TI_BIL_FOY)Record, TemsilBilgileri.Yetki);
                    break;

                case "TemsilYevmiyeBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetTemsilBilgisi((AV001_TI_BIL_FOY)Record, TemsilBilgileri.Yevmiye);
                    break;

                case "IcraHarcDetayi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetHarcDetayi((AV001_TI_BIL_FOY)Record, txControl);
                    break;

                case "IcraFoyNo":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFoyNo((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraTakipOncesiOdeme":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetTakipOncesiOdeme((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraPostaPuluDegeri":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraPostaPulu((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraTakipEdilenKiraTahliyeTarihi":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetIcraKiraTahliyeTarihi((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraTakipEdilenAsilAlacak":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraAsılAlacak((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraAlacakliBabaAdi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("BABA_ADI",
                                                                                                 " Baba Adi : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliAnaAdi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("ANA_ADI",
                                                                                                 " Ana Adi : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliDogunYeri":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("DOGUM_YERI",
                                                                                                 " Doğum Yeri : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliDogunYili":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("DOGUM_TARIHI",
                                                                                                 " Baba Adi : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliTcKimlikNo":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("TC_KIMLIK_NO",
                                                                                                 " TC Kimlik No : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliCinsiyet":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("CINSIYET",
                                                                                                 " Cinsiyet : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliMedeniHali":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("MEDENI_HAL",
                                                                                                 " Medeni Hali : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliMahalleKoy":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("NKO_MAHALLE_KOY",
                                                                                                 " Kayitli Olduğu Mahalle/Köy : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliCiltNo":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("NKO_CILT_NO",
                                                                                                 " Cilt No : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliAileSiraNo":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("NKO_AILE_SIRA_NO",
                                                                                                 " Aile Sıra No : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliBelgeNoNo":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("BELGE_NO",
                                                                                                 " Belge No : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliDini":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("DINI", " Dini : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliKanGrubu":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("KAN_GRUP",
                                                                                                 " Kan Grubu : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraBorcluBabaAdi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("BABA_ADI",
                                                                                                 " Baba Adi : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluAnaAdi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("ANA_ADI",
                                                                                                 " Ana Adi : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluDogunYeri":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("DOGUM_YERI",
                                                                                                 " Doğum Yeri : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluDogunYili":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("DOGUM_TARIHI",
                                                                                                 " Baba Adi : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluTcKimlikNo":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("TC_KIMLIK_NO",
                                                                                                 " TC Kimlik No : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluCinsiyet":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("CINSIYET",
                                                                                                 " Cinsiyet : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluMedeniHali":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("MEDENI_HAL",
                                                                                                 " Medeni Hali : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluMahalleKoy":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("NKO_MAHALLE_KOY",
                                                                                                 " Kayitli Olduğu Mahalle/Köy : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluCiltNo":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("NKO_CILT_NO",
                                                                                                 " Cilt No : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluAileSiraNo":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("NKO_AILE_SIRA_NO",
                                                                                                 " Aile Sıra No : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluBelgeNoNo":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("BELGE_NO",
                                                                                                 " Belge No : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluDini":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("DINI", " Dini : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluKanGrubu":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("KAN_GRUP",
                                                                                                 " Kan Grubu : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraAlacakliIsmi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetAllTarafsValues((AV001_TI_BIL_FOY)Record,
                                                                                           "AD", true, false);
                    break;

                case "IcraBorcluIsmi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetAllTarafsValues((AV001_TI_BIL_FOY)Record,
                                                                                           "AD", false, false);
                    break;

                case "IcraBorcluAvukatAdi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetAllTarafsValues((AV001_TI_BIL_FOY)Record,
                                                                                           "AD", false, true);
                    break;

                case "IcraAlacakliAvukatAdi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetSorumluAvukat((AV001_TI_BIL_FOY)Record, txControl, field);
                    break;

                //case "IcraBorcluVekilBilgisi":
                //  returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetBorcluVekilBilgisi((AV001_TI_BIL_FOY)crt.Record);
                //break;
                case "IcraGayrimenkulGenelBilgileri":
                    AvukatProDegiskenler.Icra.Degiskenler.GetGayrimenkulGenelBilgileri((AV001_TI_BIL_FOY)Record, txControl, 1, true);
                    returnValue = "";
                    break;

                //case "IcraBirinciHacizIhbarnameTarihi":
                //returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetHacizIhbarnameTarihi((AV001_TI_BIL_FOY)Record, TebligatTuru.SeksenDokuzaBir, sender);
                //    break;
                //case "IcraIkinciHacizIhbarnameTarihi":
                //returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetHacizIhbarnameTarihi((AV001_TI_BIL_FOY)Record, TebligatTuru.SeksenDokuzaIki, sender);
                //    break;
                //case "IcraUcuncuHacizIhbarnameTarihi":
                //returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetHacizIhbarnameTarihi((AV001_TI_BIL_FOY)Record, TebligatTuru.SeksenDokuzaUc, sender);
                //break;
                case "Icra_Sozlesme_Bilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.getIcraSozlesmeBilgisi((AV001_TI_BIL_FOY)Record, txControl);
                    break;

                case "Icra_Arac_Bilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetAracBilgisi((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraFormOrnekNumarasi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetFormOrnekNumarasi((AV001_TI_BIL_FOY)Record);

                case "Icra_Haciz_Ihbarnamesi_Borclu_Bilgisi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetHacizIhbarnamesiBorcluBilgisi((AV001_TI_BIL_FOY)Record);

                case "Icra_Ucuncu_Sahislar":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetHacizIhbarnamesiUcuncuSahis((AV001_TI_BIL_FOY)Record, null);

                case "Icra_TEbligat_Listesi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetTebligatListesi((AV001_TI_BIL_FOY)Record);

                case "Icra_Depo_Alacagi_Tablolu":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetDepoAlacagi((AV001_TI_BIL_FOY)Record);

                case "Icra_Depo_Alacagi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetDepoAlacagiString((AV001_TI_BIL_FOY)Record);
                //case "Icra_Borclu_Il":
                //TODO : Cari İlce
                // return AvukatProDegiskenler.Icra.Degiskenler.GetCariIlIlce((AV001_TI_BIL_FOY)crt.Record, degisken, true, false);
                //break;
                //case "Icra_Borclu_Ilce":
                //TODO : Cari İlce
                //  return AvukatProDegiskenler.Icra.Degiskenler.GetCariIlIlce((AV001_TI_BIL_FOY)crt.Record, AvukatProDegiskenler.Icra.Degiskenler.DegiskenAdlari.Icra_Borclu_Il, true, false);
                //break;
                case "Icra_borclu_Il_Ilce":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetFromCariBilgileri((AV001_TI_BIL_FOY)Record, true, "IL", ",", "AD");

                case "Icra_Takip_Cikisi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraFoyFieldValues(((AV001_TI_BIL_FOY)Record), "TAKIP_CIKISI", "TAKIP_CIKISI");

                case "Icra_Odeme_Emri":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraFoyFieldValues(((AV001_TI_BIL_FOY)Record), "TO_ODEME_TOPLAMI", "TO_ODEME_TOPLAMI");

                case "Icra_Toplam_Tutar":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraKalanTutar((AV001_TI_BIL_FOY)Record);

                case "Icra_Rehin_Limiti_Aciklamasi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIpotekliAciklama(((AV001_TI_BIL_FOY)Record));

                case "Icra_Borclu_Nufus_Bilgisi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetNufusBilgiliTaraf(((AV001_TI_BIL_FOY)Record), true);

                case "Icra_Alacakli_Nufus_Bilgisi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetNufusBilgiliTaraf(((AV001_TI_BIL_FOY)Record), false);

                case "Icra_Borclu_Vergi_Dairesi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "VERGI_DAIRESI");

                case "Icra_Borclu_Vergi_No":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "VERGI_NO");
                //case "Icra_Borclu_Il":
                //    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)crt.Record), degisken, "IL", sender);
                //    break;
                //case "Icra_Borclu_Ilce":
                //    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)crt.Record),degisken, "ILCE", sender);
                //    break;
                case "Icra_Borclu_Ulke":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "ULKE");

                case "Icra_Borclu_Aktif_Adres":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "AKTIF_ADRES");

                case "Icra_Alacakli_Vergi_Dairesi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "VERGI_DAIRESI");

                case "Icra_Alacakli_Vergi_No":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "VERGI_NO");

                case "Icra_Alacakli_Il":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "IL");

                case "Icra_Alacakli_Ilce":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "ILCE");

                case "Icra_Alacakli_Ulke":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "ULKE");

                case "Icra_Alacakli_Aktif_Adres":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "AKTIF_ADRES");

                case "Icra_Alacak_Neden_Adlari":
                    return IcraAlacakNedenAdlari.DegeriGetir(((AV001_TI_BIL_FOY)Record));

                case "Icra_Yasal_Sure_Odeme":
                    return IcraFormTipineGoreYasalSure.DegeriGetir(((AV001_TI_BIL_FOY)Record), 4);

                case "Icra_Yasal_Sure_Mal_Beyanı":
                    return IcraFormTipineGoreYasalSure.DegeriGetir(((AV001_TI_BIL_FOY)Record), 2);

                case "Icra_Yasal_Sure_Sikayet":
                    return IcraFormTipineGoreYasalSure.DegeriGetir(((AV001_TI_BIL_FOY)Record), 5);

                case "Icra_Yasal_Sure_Itiraz":
                    return IcraFormTipineGoreYasalSure.DegeriGetir(((AV001_TI_BIL_FOY)Record), 1);

                case "Icra_Yasal_Sure_Mehil":
                    return IcraFormTipineGoreYasalSure.DegeriGetir(((AV001_TI_BIL_FOY)Record), 3);

                case "Icra_Yasal_Sure_Tahliye":
                    return IcraFormTipineGoreYasalSure.DegeriGetir(((AV001_TI_BIL_FOY)Record), 11);

                case "Icra_Yasal_Sure_Itirazdan_Sonra_Mal_Beyanı":
                    return IcraFormTipineGoreYasalSure.DegeriGetir(((AV001_TI_BIL_FOY)Record), 12);

                case "Icra_Takip_Kanıtları":
                    return AvukatProDegiskenler.Icra.Degiskenler.TakipKanitlari(((AV001_TI_BIL_FOY)Record));

                case "Icra_Foy_Sorumlulari":
                    return AvukatProDegiskenler.Icra.Degiskenler.IcraFoySorumlulariGetir((AV001_TI_BIL_FOY)Record);

                case "ICRA_Borclu_Taraf_Farkli_Sorumluluk":
                    return AvukatProDegiskenler.Icra.Degiskenler.IcraBorcluTarafFarkliSorumluluk((AV001_TI_BIL_FOY)Record);

                case "ICRA_Depo_Alacagi_Maktu_Harc":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraDepoAlacagiMaktuHarc((AV001_TI_BIL_FOY)Record);

                case "ICRAGayriNakitAlacaklar":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraGayriNakitAlacaklarimiz((AV001_TI_BIL_FOY)Record);

                case "ICRA_BankaHarctanMuaf":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraBankaHarctanMuaf((AV001_TI_BIL_FOY)Record);

                case "ICRA_89_Borclusu":
                    return AvukatProDegiskenler.Icra.Degiskenler.Get89Borclusu((AV001_TI_BIL_FOY)Record);

                case "ICRA_Gayrimenkul_Bilgisi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetGayrimenkulIpotekBilgisi((AV001_TI_BIL_FOY)Record, false);

                case "PROJE_TicariTakipAciklama":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetKlasoreBagliTakipAciklama((AV001_TI_BIL_FOY)Record);

                case "ICRA_IlamBilgileri":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIlamBilgileri((AV001_TI_BIL_FOY)Record);

                case "Icra_AlacakNedenYEDAS":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetAlacakNedenleriForEnerjiAlacaklari((AV001_TI_BIL_FOY)Record);

                case "Icra_Foy_Taraf_Bazinda_PTT_BARKOD":

                    //AV001_TDI_BIL_TEBLIGAT_MUHATAP
                    //  return AvukatProDegiskenler.Icra.Degiskenler.GetPTTBarkodGetir((AV001_TI_BIL_FOY)Record,);//burda
                    //case "Icra_IlkTakipDigerBilgiler":
                    //    return AvukatProDegiskenler.Icra.Degiskenler.GetIlkTalepDigerBilgiler((AV001_TI_BIL_FOY)Record);
                    returnValue = field.Text;
                    break;

                case "ICRA_Icra_Iliskili_Dosyalar":
                    AvukatProDegiskenler.Icra.Degiskenler.GetICRA_Icra_Iliskili_Dosyalar((AV001_TI_BIL_FOY)Record, txControl, field);
                    break;

                case "ICRA_Bolum":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetBolumFromNesne((AV001_TI_BIL_FOY)Record);

                case "ICRA_ReferansNo1":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetfoyBilgisiFromNesne((AV001_TI_BIL_FOY)Record, "REFERANS_NO");
                    break;

                case "ICRA_ReferansNo2":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetfoyBilgisiFromNesne((AV001_TI_BIL_FOY)Record, "REFERANS_NO2");
                    break;

                case "ICRA_ReferansNo3":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetfoyBilgisiFromNesne((AV001_TI_BIL_FOY)Record, "REFERANS_NO3");
                    break;

                case "ICRA_OzelKod1":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.ICRA_OzelKodGetir((AV001_TI_BIL_FOY)Record, AvukatProDegiskenler.Icra.Degiskenler.OzelKodTipleri.OzelKod1);
                    break;

                case "ICRA_OzelKod2":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.ICRA_OzelKodGetir((AV001_TI_BIL_FOY)Record, AvukatProDegiskenler.Icra.Degiskenler.OzelKodTipleri.OzelKod2);
                    break;

                case "ICRA_OzelKod3":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.ICRA_OzelKodGetir((AV001_TI_BIL_FOY)Record, AvukatProDegiskenler.Icra.Degiskenler.OzelKodTipleri.OzelKod3);
                    break;

                case "ICRA_OzelKod4":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.ICRA_OzelKodGetir((AV001_TI_BIL_FOY)Record, AvukatProDegiskenler.Icra.Degiskenler.OzelKodTipleri.OzelKod4);
                    break;

                case "AntetBankaBilgileri":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.AntetBankaBilgileri();
                    break;

                default:
                    returnValue = field.Text;
                    break;

                #endregion
            }

            return returnValue;
        }

        //aykut DAVA DEĞİŞKENLERİ
        private object GetValueByTextFieldAndFoy(TextField field, AV001_TD_BIL_FOY foy, TextControl txControl)
        {
            object returnValue = string.Empty;
            string name = string.Empty;
            IEntity Record = foy;
            try
            {
                //Hataya meyilli bir alan hata alırsak işine devam etsin
                name = field.Name.Substring(0, field.Name.LastIndexOf("__"));
            }
            catch
            {
            }

            //string degiskenAdi = GetDegiskenAdByGorunenAd(field.Text);
            switch (name.TrimEnd())
            {
                #region

                case "AntetBuroBilgileri":
                    TList<AV001_TDI_BIL_ANTET> aaa = AvukatProDegiskenler.Icra.Degiskenler.GetAntetBilgileri();
                    if (aaa.Count == 0)
                        returnValue = "";
                    else
                    {
                        returnValue = "";
                        returnValue += aaa[0].UST_1; //büro adı

                        string[] dizi = aaa[0].UST_2.Split(','); //avukat, kimlik nolar ve diğer bilgileri yazdırılıyor
                        List<string> olanlar = new List<string>();
                        List<string> olmayanlar = new List<string>();

                        foreach (string item in dizi)
                        {
                            if (!string.IsNullOrEmpty(item.Trim()))
                            {
                                AV001_TDI_BIL_CARI car = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(Convert.ToInt32(item.Trim()));
                                if (car.VERGI_DAIRESI.Length > 0)
                                {
                                    if (!olanlar.Contains(car.ID.ToString()))
                                        olanlar.Add(car.ID.ToString());
                                }
                                else
                                {
                                    if (!olmayanlar.Contains(car.ID.ToString()))
                                        olmayanlar.Add(car.ID.ToString());
                                }
                            }
                        }

                        foreach (string item in olanlar)
                        {
                            if (!string.IsNullOrEmpty(item.Trim()))
                            {
                                AV001_TDI_BIL_CARI car = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(Convert.ToInt32(item.Trim()));
                                returnValue += "\nAv. " + car.AD + " (";

                                TList<AV001_TDI_BIL_CARI_KIMLIK> tc = DataRepository.AV001_TDI_BIL_CARI_KIMLIKProvider.GetByCARI_ID(car.ID);

                                if (tc.Count > 0)
                                    returnValue += tc[0].TC_KIMLIK_NO.Length > 0 ? ("TC No :" + tc[0].TC_KIMLIK_NO) : "";

                                returnValue += " " + (car.VERGI_DAIRESI.Length > 0 ? ("VD/No :" + car.VERGI_DAIRESI + "/") : "") + (car.VERGI_DAIRESI.Length > 0 ? car.VERGI_NO : ("SGK No :" + car.SG_NO));
                                returnValue += ")";
                            }
                        }

                        foreach (string item in olmayanlar)
                        {
                            if (!string.IsNullOrEmpty(item.Trim()))
                            {
                                AV001_TDI_BIL_CARI car = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(Convert.ToInt32(item.Trim()));
                                returnValue += "\nAv. " + car.AD + " (";

                                TList<AV001_TDI_BIL_CARI_KIMLIK> tc = DataRepository.AV001_TDI_BIL_CARI_KIMLIKProvider.GetByCARI_ID(car.ID);

                                if (tc.Count > 0)
                                    returnValue += tc[0].TC_KIMLIK_NO.Length > 0 ? ("TC No :" + tc[0].TC_KIMLIK_NO) : "";

                                returnValue += " " + (car.VERGI_DAIRESI.Length > 0 ? ("VD/No :" + car.VERGI_DAIRESI + "/") : "") + (car.VERGI_DAIRESI.Length > 0 ? car.VERGI_NO : ("SGK No :" + car.SG_NO));
                                returnValue += ")";
                            }
                        }
                        returnValue += "\n" + aaa[0].ALT_1.Replace("\n", " "); // adres
                        returnValue += "\nTel :" + aaa[0].ALT_2 + " Fax :" + aaa[0].ALT_3 + " Email :" + aaa[0].ALT_5; //telefon fax email
                        returnValue += "\nBüro IBAN :" + aaa[0].UST_4;
                    }
                    break;
                //case "MudurlukIBANNo":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetMudurlukIBANNo(foy);
                //    break;
                ////efe
                ////[ICRA] MEHİL BİLGİLERİ
                //case "ICRA_Mehil_Bilgileri":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetMehilBilgileri(foy, txControl, field);
                //    break;

                ////efe
                ////[ICRA] İLAM BİLGİLERİ TABLOLU
                //case "ICRA_Ilam_Bilgileri_Tablolu":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetIlamBilgileri(foy, txControl, field);
                //    break;

                ////efe
                ////[ICRA] BORÇLU GELİŞMELERİ
                //case "ICRA_Borclu_Gelismeleri":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetBorcluGelismeleri(foy, txControl, field);
                //    break;

                ////efe
                ////[ICRA] BORÇLU TAAHHÜTLERİ
                //case "ICRA_Borclu_Taahhutleri":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetBorcluTaahhutleri(foy, txControl, field);
                //    break;

                ////efe
                ////[ICRA] TAKİP GELİŞMELERİ
                //case "ICRA_Takip_Gelismeleri":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetTakipGelismeleri(foy, txControl, field);
                //    break;

                ////efe
                ////[ICRA] MÜVEKKİLE ÖDEME BİLGİLERİ
                //case "ICRA_Muvekkile_Odeme_Bilgileri":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetMuvekkileOdemeBilgileri(foy, txControl, field);
                //    break;

                ////efe
                ////[ICRA] İHTİYATİ TEDBİR BİLGİSİ
                //case "ICRA_Ihtiyati_Tedbir":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetIhtiyatiTedbirBilgisi(foy, txControl, field);
                //    break;

                ////efe
                ////[ICRA] İHTİYATİ HACİZ BİLGİSİ
                //case "ICRA_Ihtiyati_Haciz":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetIhtiyatiHacizBilgisi(foy, txControl, field);
                //    break;

                ////efe
                ////[ICRA] BORÇLU ÖDEME BİLGİLERİ
                //case "ICRA_Borclu_Odemeleri":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetBorcluOdemeBilgileri(foy, txControl, field);
                //    break;

                ////efe
                ////[ICRA] HACİZ BİLGİLERİ
                //case "ICRA_Haciz_Bilgileri":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetHacizBilgileri(foy, txControl, field);
                //    break;

                ////efe
                ////[ICRA] SATIŞ BİLGİLERİ
                //case "ICRA_Satis_Bilgileri":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetSatisBilgileri(foy, txControl, field);
                //    break;

                ////[ICRA] ALACAK NEDENLERI
                //case "Icra_Alacak_Nedenleri":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetAlacakNedenleri(foy, txControl, field);
                //    break;

                ////[ICRA] ACIKLAMA
                //case "Icra_Aciklama":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetAciklama(foy, txControl, field);
                //    break;

                ////[ICRA] INTIKAL TARIHI
                //case "Icra_Intikal_Tarihi":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIntikalTarihi(foy, txControl, field);
                //    break;

                ////[ICRA] INFAZ TARIHI
                //case "Icra_Infaz_Tarihi":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetInfazTarihi(foy, txControl, field);
                //    break;

                ////[ICRA] ORNEK KOD FORM TIPI
                //case "Icra_Ornek_Kod_Form_Tipi":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFormTipi(foy, txControl, field);
                //    break;

                ////[ICRA] HESAP DETAYLARI1
                //case "Icra_Hesap_Detaylari_1":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetHesapDetaylari1(foy, txControl, field);
                //    break;

                ////[ICRA] HESAP DETAYLARI2
                //case "Icra_Hesap_Detaylari_2":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetHesapDetaylari2(foy, txControl, field);
                //    break;

                ////[ICRA] HESAP DETAYLARI3
                //case "Icra_Hesap_Detaylari_3":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetHesapDetaylari3(foy, txControl, field);
                //    break;

                ////[ICRA] IHTIYATI TEDBIR HACIZ TALEP TARIHI
                //case "Icra_Ihtiyati_Tedbir_Haciz_Talep_Tarihi":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIhtiyatiHacizTalepTarihi(foy, txControl,
                //                                                                                    field);
                //    break;

                ////[ICRA] IHTIYATI TEDBIR HACIZ GOREVLI MAHKEMESI
                //case "Icra_Ihtiyati_Tedbir_Haciz_Gorevli_Mahkemesi":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIhtiyatiHacizMahkemeGorevi(foy, txControl,
                //                                                                                      field);
                //    break;

                ////[ICRA] IHTIYATI TEDBIR HACIZ ESAS NO
                //case "Icra_Ihtiyati_Tedbir_Haciz_Esas_No":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIhtiyatiHacizEsasNo(foy, txControl, field);
                //    break;

                ////[ICRA] HARC GENEL TOPLAMI
                //case "Icra_Harc_Genel_Toplami":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetHarcGenelToplami(foy, txControl, field);
                //    break;

                ////[ICRA] ALACAK BILGILERI BONO ICIN<
                //case "Icra_Alacak_Bilgileri_Bono_Icin":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetAlacakBilgileri_BonoIcin(foy, txControl, field);
                //    break;

                ////[ICRA] ALACAK BILGILERI CEK ICIN
                //case "Icra_Alacak_Bilgileri_Cek_Icin":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetAlacakBilgileri_CekIcin(foy, txControl, field);
                //    break;

                //[ICRA] HESAPLANMIS DEGERLER ACIKLAMASIZ
                case "Icra_Hesaplanmis_Degerler_Aciklamasiz":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetHesaplanmisDegerlerFromNesne(
                            ((AV001_TI_BIL_FOY)Record), txControl, "", "", false, field);
                    break;

                //case "Icra_Harc_Detaylari":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetHarcDetaylari(foy, txControl, field);
                //    break;

                //case "Icra_Masraf_Makbuzu_Toplam":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetIcraGrupluMasrafBilgileri(foy, txControl, field,
                //                                                                       AvukatProDegiskenler.Icra.
                //                                                                           Degiskenler.MasrafGrubu.
                //                                                                           Toplam);
                //    break;

                ////[ICRA] MASRAF MAKBUZU ALACAGA MAHSUPLU MAL ALIM
                //case "Icra_Masraf_Makbuzu_AlacagaMahsupluMalAlim":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetIcraGrupluMasrafBilgileri(foy, txControl, field,
                //                                                                       AvukatProDegiskenler.Icra.
                //                                                                           Degiskenler.MasrafGrubu.
                //                                                                           alacagaMahMalAlimMasraflari);
                //    break;

                ////[ICRA] MASRAF MAKBUZU DIGER ALACAKLAR
                //case "Icra_Masraf_Makbuzu_DigerAlacakla":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetIcraGrupluMasrafBilgileri(foy, txControl, field,
                //                                                                       AvukatProDegiskenler.Icra.
                //                                                                           Degiskenler.MasrafGrubu.
                //                                                                           digerAlacaklar);
                //    break;

                ////[ICRA] MASRAF MAKBUZU HACIZ KESIF
                //case "Icra_Masraf_Makbuzu_Haciz_Kesif":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetIcraGrupluMasrafBilgileri(foy, txControl, field,
                //                                                                       AvukatProDegiskenler.Icra.
                //                                                                           Degiskenler.MasrafGrubu.
                //                                                                           hacisKesif);
                //    break;

                //case "Icra_Masraf_Makbuzu_IlkMasraflar":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetIcraGrupluMasrafBilgileri(foy, txControl, field,
                //                                                                       AvukatProDegiskenler.Icra.
                //                                                                           Degiskenler.MasrafGrubu.
                //                                                                           ilkMasraflar);
                //    break;

                //case "Icra_Borc_Taahhudu_Borclu_Adi":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetGecerliTaahutBorcluAdi(foy);
                //    break;

                //case "Icra_Borc_Taahhudu_Taahhut_Tarihi":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetGecerliTaahhutTarihi(foy);
                //    break;

                //case "Icra_Borc_Taahhudu_Odeme_Taahhutleri":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetGecerliTAahhutOdemeTaahhutleri(foy);
                //    break;

                //case "Icra_Borc_Taahhudu_Alacakli_Vekil_Adi":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetGecerliTaahhutAlacakliVekilAdi(foy);
                //    break;

                //case "Icra_Borc_Taahhudu_Hesap_Degerleri":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetGecerliTaahhutHesapDegerleri(foy);
                //    break;

                case "DavaDAVA_EDENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "IcraBORCLU_MIRASCI":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, 6, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "DavaDAVA_EDİLENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "IcraTAKİP_EDENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "Icra_Alacakli_Sifatli_Vekil_Bilgili":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, true, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "Icra_Borclu_Sifatli_Vekil_Bilgili":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, true, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "Icra_AlacakliBilgisiYEDAS":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetirForEnerji(Record, true, true);
                    break;

                case "Icra_AlacakliBilgisiNoAdresNoVekilTCYEDAS":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetirForEnerji(Record, true, false);
                    break;

                case "Icra_BorcluBilgisiYEDAS":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetirForEnerji(Record, false, true);
                    break;

                case "Icra_Borclu_Sifatli_Vekil_BilgiliTCYok":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, true, true, false);
                    break;

                case "Icra_Alacakli_Sifatli_Vekil_BilgiliTCYok":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, true, true, false);
                    break;

                case "IcraTAKİP_EDİLENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "SozlesmeDAVA_EDENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "SozlesmeDAVA_EDİLENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "HazirlikDAVA_EDENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "HazirlikDAVA_EDİLENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "RucuRÜCU_EDENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "RucuRÜCU_EDİLENCariBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "DavaDAVA_KONUSU":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetDavaKonusu(((AV001_TD_BIL_FOY)Record).ID);
                    break;

                case "DavaCEZA_DAVA_KONUSU":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetDavaCezaKonusu(((AV001_TD_BIL_FOY)Record).ID);
                    break;

                case "DavaIDARE_DAVA_KONUSU":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetDavaIdareKonusu(((AV001_TD_BIL_FOY)Record).ID);
                    break;

                case "DavaHUKUKSAL_NEDENLER":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetHukuksalNedenler(((AV001_TD_BIL_FOY)Record).ID);
                    break;

                case "IcraTAKIP_TALEBI":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetIcraTakipTalebiFromNesne(((AV001_TI_BIL_FOY)Record));
                    break;

                case "DAVA_Esas_No":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetfoyBilgisiFromNesne((AV001_TD_BIL_FOY)Record, "ESAS_NO");
                    break;

                case "IcraOrnekForm":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetFormOrnekAciklamaFromNesne(((AV001_TI_BIL_FOY)Record));
                    break;

                case "IcraAlacakNedenKodu":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetIcraKodAlacakNedeniFromNesne(
                            ((AV001_TI_BIL_FOY)Record));
                    break;

                case "IcraIcraMudurlugu":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetIcrmBilgisiFromNesne((AV001_TI_BIL_FOY)Record);
                    break;

                //yapıldı aykut
                //case "IcraTakipTarihi":
                //    returnValue =
                //        AvukatProDegiskenler.Icra.Degiskenler.GetfoyTakipTarihiFromNesne((AV001_TI_BIL_FOY)Record);
                //    break;

                case "IcraTakipYolu":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetTakipYoluFromNesne(((AV001_TI_BIL_FOY)Record));
                    break;

                case "IcraAlacakNedeni":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetIcraAlacakNedeniFromNesne((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraKiraAlacakNeden":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetIcraKiraAlacakNedeniFromNesne((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraIlamBilgisi":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetIcraIlamBilgisiFromNesne((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraOrnek14TahliyeTalebi":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetOrnek14TahliyeTalebiFromNesne((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraHesaplanmisDegerler":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetHesaplanmisDegerlerFromNesne(
                            ((AV001_TI_BIL_FOY)Record), txControl, "", "", true, field);
                    break;

                case "IcraHesaplanmisDegerVeAciklaması":
                    AvukatProDegiskenler.Icra.Degiskenler.GetIcraHesapsWithAciklamaFromNesne((AV001_TI_BIL_FOY)Record,
                                                                                             txControl, true);
                    break;

                //yapıldı aykut
                //case "IcraSorumluAvukat":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraSorumluAvukat(
                //        ((AV001_TI_BIL_FOY)Record), txControl, false);
                //    break;

                case "SatisBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetSatisBilgisi(((AV001_TI_BIL_FOY)Record),
                                                                                        txControl,
                                                                                        txControl.Selection.Start);
                    break;

                case "HacizBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetHacizBilgisi(((AV001_TI_BIL_FOY)Record),
                                                                                        txControl,
                                                                                        txControl.Selection.Start);
                    break;

                case "GayrimenkulBilgisi":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetGayrimenkulIpotekBilgisi((AV001_TI_BIL_FOY)Record,
                                                                                          true);
                    break;

                //case "CariKimlikBilgisi":
                //    AvukatProDegiskenler.Icra.Degiskenler.GetIcraTarafCariKimlikBilgisi(Record, txControl, false, null,
                //                                                                        null);
                //break;

                case "HacizMahkemeBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetHacizMahkeme(((AV001_TI_BIL_FOY)Record),
                                                                                        txControl,
                                                                                        txControl.Selection.Start);
                    break;

                case "SatisMahkemeBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetHacizMahkeme(((AV001_TI_BIL_FOY)Record),
                                                                                        txControl,
                                                                                        txControl.Selection.Start);
                    break;

                case "IcraBorcluVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "IcraAlacakliVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "IcraBORCLU_MIRASCIVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, 6, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "DavaDAVA_EDİLENCariBilgisiVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "DavaDAVA_EDENCariBilgisiVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                //case "IcraTAKİP_EDENCariBilgisiVekilsiz":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, false);
                //    break;
                //yapıldı aykut
                //case "IcraAlacakliVekilsizTCliIBANli":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetirTCliIBANLi(Record, true, null, false);
                //    break;

                //yapıldı aykut
                //case "IcraTAKİP_EDİLENCariBilgisiVekilsiz":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, false);
                //    break;

                case "SozlesmeDAVA_EDENCariBilgisiVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "SozlesmeDAVA_EDİLENCariBilgisiVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "HazirlikDAVA_EDENCariBilgisiVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "HazirlikDAVA_EDİLENCariBilgisiVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "RucuRÜCU_EDEIcra_Arac_BilgisiNCariBilgisiVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "RucuRÜCU_EDİLENCariBilgisiVekilsiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                case "Sozlesme_Sozlesme_Bilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.getSozlesmeBilgisi((AV001_TI_BIL_FOY)Record, txControl, txControl.Selection.Start);
                    break;

                case "DovizliAlacakTakipTarihindeYtl":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.DovizliAlacakTakipTarihindeYtl(((AV001_TI_BIL_FOY)Record).ID, txControl, txControl.Selection.Start);
                    break;

                case "BuGun":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetBugun();
                    break;

                case "BuKullanici":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetCurrentUser();
                    break;

                case "BuSaat":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetBuSaat();
                    break;

                case "KayıtTarihi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetKayitTarihi(Record);
                    break;

                case "KayitSaati":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetKayitSaati(Record);
                    break;

                case "KaydiYapanKullanici":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetKayitEden(Record);
                    break;

                case "Sube":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetSube(Record);
                    break;

                case "RehinBorclusu":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, 6, true, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adresli);
                    break;

                //case "Icra_Kredi_Borclusu":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraKrediBorclusu(foy, txControl, field);
                //    break;

                //case "Icra_Alacak_Turu":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraAlacakTuru(foy, txControl, field);
                //    break;

                //case "Icra_Karsi_Taraflar":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraKarsiTaraflar(foy, txControl, field);
                //    break;

                //case "Icra_Sorumlu_Adi":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraSorumlusu(foy, txControl, field, false);
                //    break;

                //case "Icra_Yetkili_Adi":
                //    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraSorumlusu(foy, txControl, field, true);
                //    break;

                case "IcraIstirakIstenenBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.IcraIstirakIstenenBilgisi((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraIstirakIsteyenBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.IcraIstirakIstenenBilgisi((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraHacizUcuncuSahisBilgisi":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.IcraHacizUcuncuSahisBilgisi((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraAlacakliVekilBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.IcraAlacakliVekilBilgisi((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraTebligatMuhattabTebligtarihi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.IcraTebligatMuhattabTebligtarihi((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraIstihkakEdenBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.IcraIstihkakEdenBilgisi((AV001_TI_BIL_FOY)Record);
                    break;

                case "Temsilbilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetTemsilBilgisi((AV001_TI_BIL_FOY)Record, TemsilBilgileri.Tumu);
                    break;

                case "TemsilNoterBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetTemsilBilgisi((AV001_TI_BIL_FOY)Record, TemsilBilgileri.Noter);
                    break;

                case "TemsilYetkibilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetTemsilBilgisi((AV001_TI_BIL_FOY)Record, TemsilBilgileri.Yetki);
                    break;

                case "TemsilYevmiyeBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetTemsilBilgisi((AV001_TI_BIL_FOY)Record, TemsilBilgileri.Yevmiye);
                    break;

                case "IcraHarcDetayi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetHarcDetayi((AV001_TI_BIL_FOY)Record, txControl);
                    break;

                case "DAVA_Dava_Foy_No":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFoyNo((AV001_TD_BIL_FOY)Record);
                    break;

                case "IcraTakipOncesiOdeme":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetTakipOncesiOdeme((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraPostaPuluDegeri":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraPostaPulu((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraTakipEdilenKiraTahliyeTarihi":
                    returnValue =
                        AvukatProDegiskenler.Icra.Degiskenler.GetIcraKiraTahliyeTarihi((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraTakipEdilenAsilAlacak":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraAsılAlacak((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraAlacakliBabaAdi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("BABA_ADI",
                                                                                                 " Baba Adi : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliAnaAdi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("ANA_ADI",
                                                                                                 " Ana Adi : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliDogunYeri":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("DOGUM_YERI",
                                                                                                 " Doğum Yeri : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliDogunYili":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("DOGUM_TARIHI",
                                                                                                 " Baba Adi : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliTcKimlikNo":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("TC_KIMLIK_NO",
                                                                                                 " TC Kimlik No : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliCinsiyet":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("CINSIYET",
                                                                                                 " Cinsiyet : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliMedeniHali":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("MEDENI_HAL",
                                                                                                 " Medeni Hali : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliMahalleKoy":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("NKO_MAHALLE_KOY",
                                                                                                 " Kayitli Olduğu Mahalle/Köy : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliCiltNo":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("NKO_CILT_NO",
                                                                                                 " Cilt No : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliAileSiraNo":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("NKO_AILE_SIRA_NO",
                                                                                                 " Aile Sıra No : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliBelgeNoNo":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("BELGE_NO",
                                                                                                 " Belge No : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliDini":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("DINI", " Dini : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraAlacakliKanGrubu":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("KAN_GRUP",
                                                                                                 " Kan Grubu : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, false);
                    break;

                case "IcraBorcluBabaAdi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("BABA_ADI",
                                                                                                 " Baba Adi : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluAnaAdi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("ANA_ADI",
                                                                                                 " Ana Adi : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluDogunYeri":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("DOGUM_YERI",
                                                                                                 " Doğum Yeri : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluDogunYili":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("DOGUM_TARIHI",
                                                                                                 " Baba Adi : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluTcKimlikNo":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("TC_KIMLIK_NO",
                                                                                                 " TC Kimlik No : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluCinsiyet":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("CINSIYET",
                                                                                                 " Cinsiyet : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluMedeniHali":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("MEDENI_HAL",
                                                                                                 " Medeni Hali : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluMahalleKoy":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("NKO_MAHALLE_KOY",
                                                                                                 " Kayitli Olduğu Mahalle/Köy : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluCiltNo":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("NKO_CILT_NO",
                                                                                                 " Cilt No : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluAileSiraNo":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("NKO_AILE_SIRA_NO",
                                                                                                 " Aile Sıra No : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluBelgeNoNo":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("BELGE_NO",
                                                                                                 " Belge No : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluDini":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("DINI", " Dini : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraBorcluKanGrubu":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetFromCariKimlikBilgisi("KAN_GRUP",
                                                                                                 " Kan Grubu : ",
                                                                                                 (AV001_TI_BIL_FOY)
                                                                                                 Record, true);
                    break;

                case "IcraAlacakliIsmi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetAllTarafsValues((AV001_TI_BIL_FOY)Record,
                                                                                           "AD", true, false);
                    break;

                case "IcraBorcluIsmi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetAllTarafsValues((AV001_TI_BIL_FOY)Record,
                                                                                           "AD", false, false);
                    break;

                case "IcraBorcluAvukatAdi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetAllTarafsValues((AV001_TI_BIL_FOY)Record,
                                                                                           "AD", false, true);
                    break;

                case "IcraAlacakliAvukatAdi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetSorumluAvukat((AV001_TI_BIL_FOY)Record, txControl, field);
                    break;

                //case "IcraBorcluVekilBilgisi":
                //  returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetBorcluVekilBilgisi((AV001_TI_BIL_FOY)crt.Record);
                //break;
                case "IcraGayrimenkulGenelBilgileri":
                    AvukatProDegiskenler.Icra.Degiskenler.GetGayrimenkulGenelBilgileri((AV001_TI_BIL_FOY)Record, txControl, 1, true);
                    returnValue = "";
                    break;

                //case "IcraBirinciHacizIhbarnameTarihi":
                //returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetHacizIhbarnameTarihi((AV001_TI_BIL_FOY)Record, TebligatTuru.SeksenDokuzaBir, sender);
                //    break;
                //case "IcraIkinciHacizIhbarnameTarihi":
                //returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetHacizIhbarnameTarihi((AV001_TI_BIL_FOY)Record, TebligatTuru.SeksenDokuzaIki, sender);
                //    break;
                //case "IcraUcuncuHacizIhbarnameTarihi":
                //returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetHacizIhbarnameTarihi((AV001_TI_BIL_FOY)Record, TebligatTuru.SeksenDokuzaUc, sender);
                //break;
                case "Icra_Sozlesme_Bilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.getIcraSozlesmeBilgisi((AV001_TI_BIL_FOY)Record, txControl);
                    break;

                case "Icra_Arac_Bilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetAracBilgisi((AV001_TI_BIL_FOY)Record);
                    break;

                case "IcraFormOrnekNumarasi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetFormOrnekNumarasi((AV001_TI_BIL_FOY)Record);

                case "Icra_Haciz_Ihbarnamesi_Borclu_Bilgisi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetHacizIhbarnamesiBorcluBilgisi((AV001_TI_BIL_FOY)Record);

                case "Icra_Ucuncu_Sahislar":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetHacizIhbarnamesiUcuncuSahis((AV001_TI_BIL_FOY)Record, null);

                case "Icra_TEbligat_Listesi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetTebligatListesi((AV001_TI_BIL_FOY)Record);

                case "Icra_Depo_Alacagi_Tablolu":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetDepoAlacagi((AV001_TI_BIL_FOY)Record);

                case "Icra_Depo_Alacagi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetDepoAlacagiString((AV001_TI_BIL_FOY)Record);
                //case "Icra_Borclu_Il":
                //TODO : Cari İlce
                // return AvukatProDegiskenler.Icra.Degiskenler.GetCariIlIlce((AV001_TI_BIL_FOY)crt.Record, degisken, true, false);
                //break;
                //case "Icra_Borclu_Ilce":
                //TODO : Cari İlce
                //  return AvukatProDegiskenler.Icra.Degiskenler.GetCariIlIlce((AV001_TI_BIL_FOY)crt.Record, AvukatProDegiskenler.Icra.Degiskenler.DegiskenAdlari.Icra_Borclu_Il, true, false);
                //break;
                case "Icra_borclu_Il_Ilce":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetFromCariBilgileri((AV001_TI_BIL_FOY)Record, true, "IL", ",", "AD");

                case "Icra_Takip_Cikisi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraFoyFieldValues(((AV001_TI_BIL_FOY)Record), "TAKIP_CIKISI", "TAKIP_CIKISI");

                case "Icra_Odeme_Emri":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraFoyFieldValues(((AV001_TI_BIL_FOY)Record), "TO_ODEME_TOPLAMI", "TO_ODEME_TOPLAMI");

                case "Icra_Toplam_Tutar":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraKalanTutar((AV001_TI_BIL_FOY)Record);

                case "Icra_Rehin_Limiti_Aciklamasi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIpotekliAciklama(((AV001_TI_BIL_FOY)Record));

                case "Icra_Borclu_Nufus_Bilgisi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetNufusBilgiliTaraf(((AV001_TI_BIL_FOY)Record), true);

                case "Icra_Alacakli_Nufus_Bilgisi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetNufusBilgiliTaraf(((AV001_TI_BIL_FOY)Record), false);

                case "Icra_Borclu_Vergi_Dairesi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "VERGI_DAIRESI");

                case "Icra_Borclu_Vergi_No":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "VERGI_NO");
                //case "Icra_Borclu_Il":
                //    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)crt.Record), degisken, "IL", sender);
                //    break;
                //case "Icra_Borclu_Ilce":
                //    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)crt.Record),degisken, "ILCE", sender);
                //    break;
                case "Icra_Borclu_Ulke":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "ULKE");

                case "Icra_Borclu_Aktif_Adres":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "AKTIF_ADRES");

                case "Icra_Alacakli_Vergi_Dairesi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "VERGI_DAIRESI");

                case "Icra_Alacakli_Vergi_No":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "VERGI_NO");

                case "Icra_Alacakli_Il":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "IL");

                case "Icra_Alacakli_Ilce":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "ILCE");

                case "Icra_Alacakli_Ulke":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "ULKE");

                case "Icra_Alacakli_Aktif_Adres":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), "AKTIF_ADRES");

                case "Icra_Alacak_Neden_Adlari":
                    return IcraAlacakNedenAdlari.DegeriGetir(((AV001_TI_BIL_FOY)Record));

                case "Icra_Yasal_Sure_Odeme":
                    return IcraFormTipineGoreYasalSure.DegeriGetir(((AV001_TI_BIL_FOY)Record), 4);

                case "Icra_Yasal_Sure_Mal_Beyanı":
                    return IcraFormTipineGoreYasalSure.DegeriGetir(((AV001_TI_BIL_FOY)Record), 2);

                case "Icra_Yasal_Sure_Sikayet":
                    return IcraFormTipineGoreYasalSure.DegeriGetir(((AV001_TI_BIL_FOY)Record), 5);

                case "Icra_Yasal_Sure_Itiraz":
                    return IcraFormTipineGoreYasalSure.DegeriGetir(((AV001_TI_BIL_FOY)Record), 1);

                case "Icra_Yasal_Sure_Mehil":
                    return IcraFormTipineGoreYasalSure.DegeriGetir(((AV001_TI_BIL_FOY)Record), 3);

                case "Icra_Yasal_Sure_Tahliye":
                    return IcraFormTipineGoreYasalSure.DegeriGetir(((AV001_TI_BIL_FOY)Record), 11);

                case "Icra_Yasal_Sure_Itirazdan_Sonra_Mal_Beyanı":
                    return IcraFormTipineGoreYasalSure.DegeriGetir(((AV001_TI_BIL_FOY)Record), 12);

                case "Icra_Takip_Kanıtları":
                    return AvukatProDegiskenler.Icra.Degiskenler.TakipKanitlari(((AV001_TI_BIL_FOY)Record));

                case "Icra_Foy_Sorumlulari":
                    return AvukatProDegiskenler.Icra.Degiskenler.IcraFoySorumlulariGetir((AV001_TI_BIL_FOY)Record);

                case "ICRA_Borclu_Taraf_Farkli_Sorumluluk":
                    return AvukatProDegiskenler.Icra.Degiskenler.IcraBorcluTarafFarkliSorumluluk((AV001_TI_BIL_FOY)Record);

                case "ICRA_Depo_Alacagi_Maktu_Harc":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraDepoAlacagiMaktuHarc((AV001_TI_BIL_FOY)Record);

                case "ICRAGayriNakitAlacaklar":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraGayriNakitAlacaklarimiz((AV001_TI_BIL_FOY)Record);

                case "ICRA_BankaHarctanMuaf":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIcraBankaHarctanMuaf((AV001_TI_BIL_FOY)Record);

                case "ICRA_89_Borclusu":
                    return AvukatProDegiskenler.Icra.Degiskenler.Get89Borclusu((AV001_TI_BIL_FOY)Record);

                case "ICRA_Gayrimenkul_Bilgisi":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetGayrimenkulIpotekBilgisi((AV001_TI_BIL_FOY)Record, false);

                case "PROJE_TicariTakipAciklama":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetKlasoreBagliTakipAciklama((AV001_TI_BIL_FOY)Record);

                case "ICRA_IlamBilgileri":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetIlamBilgileri((AV001_TI_BIL_FOY)Record);

                case "Icra_AlacakNedenYEDAS":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetAlacakNedenleriForEnerjiAlacaklari((AV001_TI_BIL_FOY)Record);

                case "Icra_Foy_Taraf_Bazinda_PTT_BARKOD":

                    //AV001_TDI_BIL_TEBLIGAT_MUHATAP
                    //  return AvukatProDegiskenler.Icra.Degiskenler.GetPTTBarkodGetir((AV001_TI_BIL_FOY)Record,);//burda
                    //case "Icra_IlkTakipDigerBilgiler":
                    //    return AvukatProDegiskenler.Icra.Degiskenler.GetIlkTalepDigerBilgiler((AV001_TI_BIL_FOY)Record);
                    returnValue = field.Text;
                    break;

                case "ICRA_Bolum":
                    return AvukatProDegiskenler.Icra.Degiskenler.GetBolumFromNesne((AV001_TI_BIL_FOY)Record);

                case "DAVA_Dava_Mahkeme_No_Gorev":
                    return AvukatProDegiskenler.Icra.Degiskenler.DAVA_Dava_Mahkeme_No_Gorev((AV001_TD_BIL_FOY)Record);

                case "DAVA_Dava_Tarihi":
                    {
                        string ss = AvukatProDegiskenler.Icra.Degiskenler.GetfoyBilgisiFromNesne((AV001_TD_BIL_FOY)Record, "DAVA_TARIHI");
                        if (!string.IsNullOrEmpty(ss))
                            returnValue = Convert.ToDateTime(ss).ToShortDateString();
                        else
                            returnValue = "";
                    }
                    break;

                case "DAVA_Dava_Tipi":
                    return AvukatProDegiskenler.Icra.Degiskenler.DAVA_Dava_Tipi((AV001_TD_BIL_FOY)Record);

                case "DAVA_Durum":
                    return AvukatProDegiskenler.Icra.Degiskenler.DAVA_Durum((AV001_TD_BIL_FOY)Record);

                case "DAVA_Dava_Degeri":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.DAVA_Dava_Degeri((AV001_TD_BIL_FOY)Record) + " " + AvukatProDegiskenler.Icra.Degiskenler.DovizDegeriGetir(((AV001_TD_BIL_FOY)Record).DAVA_DEGERI_DOVIZ_ID);
                    break;

                case "DAVA_Avukata_Intikal_Tarihi":
                    {
                        string ss = AvukatProDegiskenler.Icra.Degiskenler.GetfoyBilgisiFromNesne((AV001_TD_BIL_FOY)Record, "AVUKATA_INTIKAL_TARIHI");
                        if (!string.IsNullOrEmpty(ss))
                            returnValue = Convert.ToDateTime(ss).ToShortDateString();
                        else
                            returnValue = "";
                    }
                    break;

                case "DAVA_Feragat_Tarihi":
                    {
                        string ss = AvukatProDegiskenler.Icra.Degiskenler.GetfoyBilgisiFromNesne((AV001_TD_BIL_FOY)Record, "FOY_FERAGAT_TARIHI");
                        if (!string.IsNullOrEmpty(ss))
                            returnValue = Convert.ToDateTime(ss).ToShortDateString();
                        else
                            returnValue = "";
                    }
                    break;

                case "DAVA_Arsiv_Tarihi":
                    {
                        string ss = AvukatProDegiskenler.Icra.Degiskenler.GetfoyBilgisiFromNesne((AV001_TD_BIL_FOY)Record, "FOY_ARSIV_TARIHI");
                        if (!string.IsNullOrEmpty(ss))
                            returnValue = Convert.ToDateTime(ss).ToShortDateString();
                        else
                            returnValue = "";
                    }
                    break;

                case "DAVA_Dava_Talebi":
                    return AvukatProDegiskenler.Icra.Degiskenler.DAVA_Dava_Talebi((AV001_TD_BIL_FOY)Record);

                case "DAVA_Aciklama":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetfoyBilgisiFromNesne((AV001_TD_BIL_FOY)Record, "ACIKLAMA");
                    break;

                case "DAVA_Bolum":
                    return AvukatProDegiskenler.Icra.Degiskenler.DAVA_Bolum((AV001_TD_BIL_FOY)Record);

                case "DavaEdenVekilsizAdressiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, true, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adressiz);
                    break;

                case "DavaEdilenVekilsizAdressiz":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.TarafBilgisiGetir(Record, false, null, false, AvukatProDegiskenler.Icra.Degiskenler.AdresSecimleri.Adressiz);
                    break;

                case "Dava_Nedenleri":
                    AvukatProDegiskenler.Icra.Degiskenler.GetAlacakNedenleri((AV001_TD_BIL_FOY)Record, txControl, field);
                    break;

                case "Dava_IdariIslem":
                    AvukatProDegiskenler.Icra.Degiskenler.GetDava_IdariIslem((AV001_TD_BIL_FOY)Record, txControl, field);
                    break;

                case "DAVA_Ihtiyati_Tedbir":
                    AvukatProDegiskenler.Icra.Degiskenler.GetIhtiyatiTedbirBilgisi((AV001_TD_BIL_FOY)Record, txControl, field);
                    break;

                case "DAVA_Sorumlu_Avukat":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraSorumluAvukat(((AV001_TD_BIL_FOY)Record), txControl, false);
                    break;

                case "DAVA_Dava_Son_Durusma_Tarihi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetDAVA_Dava_Son_Durusma_Tarihi(((AV001_TD_BIL_FOY)Record), true);
                    break;

                case "DAVA_Dava_Son_Inceleme_Tarihi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetDAVA_Dava_Son_Durusma_Tarihi(((AV001_TD_BIL_FOY)Record), false);
                    break;

                case "DAVA_Dava_Son_Karar_Tarihi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetDAVA_Dava_Son_Karar_Tarihi(((AV001_TD_BIL_FOY)Record));
                    break;

                case "DAVA_Dava_Son_Temyiz_Tarihi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetDAVA_Dava_Son_Temyiz_Tarihi(((AV001_TD_BIL_FOY)Record));
                    break;

                case "DAVA_Dava_Hukum_Bilgisi":
                    AvukatProDegiskenler.Icra.Degiskenler.GetDAVA_Dava_Hukum_Bilgisi((AV001_TD_BIL_FOY)Record, txControl, field);
                    break;

                case "DAVA_Dava_Hukum_Bilgisi_Ceza":
                    AvukatProDegiskenler.Icra.Degiskenler.GetDAVA_Dava_Hukum_Bilgisi_Ceza((AV001_TD_BIL_FOY)Record, txControl, field);
                    break;

                case "DAVA_Dava_Temyiz_Bilgisi":
                    AvukatProDegiskenler.Icra.Degiskenler.GetDAVA_Dava_Temyiz_Bilgisi((AV001_TD_BIL_FOY)Record, txControl, field);
                    break;

                case "DAVA_Dava_Iliskili_Dosyalar":
                    AvukatProDegiskenler.Icra.Degiskenler.GetDAVA_Dava_Iliskili_Dosyalar((AV001_TD_BIL_FOY)Record, txControl, field);
                    break;

                case "DAVA_Dava_Gelismeleri":
                    AvukatProDegiskenler.Icra.Degiskenler.GetTakipGelismeleri((AV001_TD_BIL_FOY)Record, txControl, field);
                    break;

                case "DAVA_ReferansNo1":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetfoyBilgisiFromNesne((AV001_TD_BIL_FOY)Record, "REFERANS_NO");
                    break;

                case "DAVA_ReferansNo2":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetfoyBilgisiFromNesne((AV001_TD_BIL_FOY)Record, "REFERANS_NO2");
                    break;

                case "DAVA_ReferansNo3":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetfoyBilgisiFromNesne((AV001_TD_BIL_FOY)Record, "REFERANS_NO3");
                    break;

                case "DAVA_OzelKod1":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.DAVA_OzelKodGetir((AV001_TD_BIL_FOY)Record, AvukatProDegiskenler.Icra.Degiskenler.OzelKodTipleri.OzelKod1);
                    break;

                case "DAVA_OzelKod2":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.DAVA_OzelKodGetir((AV001_TD_BIL_FOY)Record, AvukatProDegiskenler.Icra.Degiskenler.OzelKodTipleri.OzelKod2);
                    break;

                case "DAVA_OzelKod3":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.DAVA_OzelKodGetir((AV001_TD_BIL_FOY)Record, AvukatProDegiskenler.Icra.Degiskenler.OzelKodTipleri.OzelKod3);
                    break;

                case "DAVA_OzelKod4":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.DAVA_OzelKodGetir((AV001_TD_BIL_FOY)Record, AvukatProDegiskenler.Icra.Degiskenler.OzelKodTipleri.OzelKod4);
                    break;

                case "AntetBankaBilgileri":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.AntetBankaBilgileri();
                    break;

                case "CariKimlikBilgisi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraTarafCariKimlikBilgisi(Record, txControl, false, null, null);
                    break;

                case "DAVA_Dava_Eden_Kimlik_Bilgileri":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraTarafCariKimlikBilgisi(Record, txControl, false, true, null);
                    break;

                case "DAVA_Dava_Edilen_Kimlik_Bilgileri":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.GetIcraTarafCariKimlikBilgisi(Record, txControl, false, false, null);
                    break;

                case "DAVA_Nobetci_Mahkeme_Bilgisi":
                    return AvukatProDegiskenler.Icra.Degiskenler.DAVA_Nobetci_Mahkeme_Bilgisi((AV001_TD_BIL_FOY)Record);

                case "DAVA_Faiz_Baslangic_Tarihi":
                    returnValue = AvukatProDegiskenler.Icra.Degiskenler.DAVA_Faiz_Baslangic_Tarihi(((AV001_TD_BIL_FOY)Record));
                    break;

                default:
                    returnValue = field.Text;
                    break;

                #endregion
            }

            return returnValue;
        }

        /// <summary>
        /// Gönderdiğimiz Text Controle gönderdiğimiz raporu yükler,
        /// yükleme başarılı olursa true döndürür,
        /// </summary>
        /// <param name="txControl"></param>
        /// <param name="rapor"></param>
        /// <returns></returns>
        private bool LoadSablon(TextControl txControl, object rapor)
        {
            AV001_TDIE_BIL_SABLON_RAPOR sablon = null;
            try
            {
                if (rapor is AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)
                    sablon =
                        DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.GetByID(((AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)rapor).ID);
                else sablon = (AV001_TDIE_BIL_SABLON_RAPOR)rapor;
                txControl.CreateControl();
                txControl.Show();
                txControl.Load(sablon.DOSYA, BinaryStreamType.InternalFormat);
                return true;
            }
            catch (Exception)
            {
                try
                {
                    txControl.Load(sablon.DOSYA, BinaryStreamType.MSWord);
                    return true;
                }
                catch (Exception)
                {
                    try
                    {
                        txControl.Load(sablon.DOSYA, BinaryStreamType.WordprocessingML);
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }
    }

    public static class EditorDataAraclari
    {
        public static class Icra
        {
            public static string GetAdliBirimGorev(int? adliBirimGorevId)
            {
                if (adliBirimGorevId == null) return string.Empty;

                string sorgu = string.Format(@"SELECT GOREV FROM dbo.TDI_KOD_ADLI_BIRIM_GOREV WHERE ID = {0}",
                                             adliBirimGorevId);

                var sonuc = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, sorgu);

                if (sonuc != null)
                {
                    return sonuc.ToString();
                }
                return string.Empty;
            }

            public static string GetAdliBirimNo(int? adliBirimNoId)
            {
                if (adliBirimNoId == null) return string.Empty;

                string sorgu = string.Format(@"SELECT NO FROM dbo.TDI_KOD_ADLI_BIRIM_NO WHERE ID = {0}", adliBirimNoId);

                var sonuc = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, sorgu);

                if (sonuc != null)
                {
                    return sonuc.ToString();
                }
                return string.Empty;
            }

            public static string GetAdliyeAdi(int? adliyeId)
            {
                if (adliyeId == null) return string.Empty;

                string sorgu = string.Format(@"SELECT ADLIYE FROM dbo.TDI_KOD_ADLI_BIRIM_ADLIYE WHERE ID = {0}",
                                             adliyeId);

                var sonuc = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, sorgu);

                if (sonuc != null)
                {
                    return sonuc.ToString();
                }

                return string.Empty;
            }

            /// <summary>
            /// Föye Bağlı olan kıymetli evraklar arasındaki çek kayıtlarına bağlı bankaları gruplayarak
            /// sonuçları döndürür
            /// </summary>
            /// <param name="foyId">İcra Föy Id </param>
            /// <returns></returns>
            public static TList<TDI_KOD_BANKA> GetBankaByFoyCek(int foyId)
            {
                string sorgu =
                    string.Format(
                        @"SELECT * FROM dbo.TDI_KOD_BANKA
                            WHERE ID IN
                            (SELECT DISTINCT BANKA_ID FROM dbo.AV001_TDI_BIL_KIYMETLI_EVRAK
                               WHERE EVRAK_TUR_ID = 1 AND ID IN
                                (SELECT KIYMETLI_EVRAK_ID FROM dbo.NN_ICRA_KIYMETLI_EVRAK
			                        WHERE ICRA_FOY_ID = {0}))",
                        foyId);

                var sonuclar =
                    TDI_KOD_BANKAProviderBaseCore.Fill(
                        DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu),
                        new TList<TDI_KOD_BANKA>(), 0, int.MaxValue);

                return sonuclar;
            }

            public static TList<TDI_KOD_BANKA_SUBE> GetBankaSubeleriByFoyCek(int foyId)
            {
                string sorgu =
                    string.Format(
                        @"SELECT * FROM dbo.TDI_KOD_BANKA_SUBE
	                        WHERE ID IN
	                        (SELECT SUBE_ID FROM dbo.AV001_TDI_BIL_KIYMETLI_EVRAK
		                        WHERE EVRAK_TUR_ID = 1 AND SUBE_ID IS NOT NULL AND ID IN
		                        (SELECT KIYMETLI_EVRAK_ID FROM dbo.NN_ICRA_KIYMETLI_EVRAK
			                        WHERE ICRA_FOY_ID = {0}))",
                        foyId);

                var sonuclar =
                    TDI_KOD_BANKA_SUBEProviderBaseCore.Fill(
                        DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu),
                        new TList<TDI_KOD_BANKA_SUBE>(), 0, int.MaxValue);

                return sonuclar;
            }

            /// <summary>
            /// Verilen föye bağlı gayrimenkullerin belediyelerini döndürür
            /// null olanları getirmez ve DISTINCT eder,
            /// </summary>
            /// <param name="foyId"></param>
            /// <returns></returns>
            ///
            public static TList<TDI_KOD_BELEDIYE> GetBelediyeByFoyGayrimenkul(int foyId)
            {
                string sorgu =
                    string.Format(
                        @"SELECT        BELD.*
                                    FROM            AV001_TI_BIL_GAYRIMENKUL AS GAY LEFT OUTER JOIN
                         TDI_KOD_BELEDIYE AS BELD ON GAY.BELEDIYE_ID = BELD.ID RIGHT OUTER JOIN
                         NN_ICRA_SOZLESME AS NN_IS RIGHT OUTER JOIN
                         NN_SOZLESME_GAYRIMENKUL AS NN_SG ON NN_IS.SOZLESME_ID = NN_SG.SOZLESME_ID ON GAY.ID = NN_SG.GAYRIMENKUL_ID
                            WHERE BELD.ID IS NOT NULL AND NN_IS.ICRA_FOY_ID = {0}"
                        , foyId);

                var sonuclar = TDI_KOD_BELEDIYEProviderBaseCore.Fill(
                    DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu),
                    new TList<TDI_KOD_BELEDIYE>(), 0, int.MaxValue);

                return sonuclar;
            }

            public static TList<AV001_TDI_BIL_CARI> GetCariByFoyAndNufusaKayitliIl(int foyId, int nufusMudurlukId,
                                                                                   GruplamaAraclari.Icra.FoyTarafGrubu
                                                                                       gruplamaTipi)
            {
                string kosul = string.Empty;

                switch (gruplamaTipi)
                {
                    case GruplamaAraclari.Icra.FoyTarafGrubu.TakipEdenler:
                        kosul =
                            string.Format(
                                @"AND	TARAF_SIFAT_ID IN (SELECT ID FROM TDIE_KOD_TARAF_SIFAT WHERE HANGI_TARAF_NO = 1)");
                        break;

                    case GruplamaAraclari.Icra.FoyTarafGrubu.TakipEdilenler:
                        kosul =
                            string.Format(
                                @"AND	TARAF_SIFAT_ID IN (SELECT ID FROM TDIE_KOD_TARAF_SIFAT WHERE HANGI_TARAF_NO = 2)");
                        break;

                    case GruplamaAraclari.Icra.FoyTarafGrubu.Tumu:
                    default:
                        break;
                }

                string sorgu =
                    string.Format(
                        @"SELECT * FROM dbo.AV001_TDI_BIL_CARI WHERE
	                                                ID IN
	                                            (SELECT CARI_ID FROM AV001_TDI_BIL_CARI_KIMLIK WHERE NKO_IL_ID = {1})
                                                AND
	                                                ID IN
	                                            (SELECT CARI_ID FROM AV001_TI_BIL_FOY_TARAF WHERE ICRA_FOY_ID = {0} {2})",
                        foyId, nufusMudurlukId, kosul);

                var sonuclar =
                    AV001_TDI_BIL_CARIProviderBaseCore.Fill(
                        DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu),
                        new TList<AV001_TDI_BIL_CARI>(), 0, int.MaxValue);

                return sonuclar;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="foyId"></param>
            /// <param name="bankaId"></param>
            /// <returns></returns>
            public static TList<AV001_TDI_BIL_KIYMETLI_EVRAK> GetCekByFoyAndBanka(int foyId, int bankaId)
            {
                string sorgu =
                    string.Format(
                        @"	SELECT * FROM dbo.AV001_TDI_BIL_KIYMETLI_EVRAK
		                                    WHERE EVRAK_TUR_ID = 1 AND BANKA_ID = 12 AND ID IN
		                                    (SELECT KIYMETLI_EVRAK_ID FROM dbo.NN_ICRA_KIYMETLI_EVRAK
			                                 WHERE ICRA_FOY_ID = 1750)");

                var sonuclar =
                    AV001_TDI_BIL_KIYMETLI_EVRAKProviderBaseCore.Fill(
                        DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu),
                        new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>(), 0, int.MaxValue);

                return sonuclar;
            }

            /// <summary>
            /// föye bağlı kıymetli evrakların banka şubelerini gruplayarak döndürür
            /// </summary>
            /// <param name="foyId"></param>
            /// <param name="bankaSubeId"></param>
            /// <returns></returns>
            public static TList<AV001_TDI_BIL_KIYMETLI_EVRAK> GetCekByFoyAndBankaSube(int foyId, int bankaSubeId)
            {
                string sorgu =
                    string.Format(
                        @"(SELECT * FROM dbo.AV001_TDI_BIL_KIYMETLI_EVRAK
		                        WHERE EVRAK_TUR_ID = 1 AND SUBE_ID = {1} AND ID IN
		                        (SELECT KIYMETLI_EVRAK_ID FROM dbo.NN_ICRA_KIYMETLI_EVRAK
			                        WHERE ICRA_FOY_ID = {0}))",
                        foyId, bankaSubeId);

                var sonuclar =
                    AV001_TDI_BIL_KIYMETLI_EVRAKProviderBaseCore.Fill(
                        DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu),
                        new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>(), 0, int.MaxValue);

                return sonuclar;
            }

            public static Dictionary<string, List<double?>> GetFaizTipVeOranlarById(int icraId)
            {
                string sorgu =
                    string.Format(
                        @"SELECT DISTINCT
                                (SELECT FAIZ_TIP FROM TDI_KOD_FAIZ_TIP WHERE ID = TO_ALACAK_FAIZ_TIP_ID) AS FAIZ_TIP ,
                                TO_UYGULANACAK_FAIZ_ORANI
                                FROM AV001_TI_BIL_ALACAK_NEDEN WHERE ICRA_FOY_ID = {0}",
                        icraId);

                var reader = DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu);

                Dictionary<string, List<double?>> sozluk = new Dictionary<string, List<double?>>();

                while (reader.Read())
                {
                    string faizTip = reader["FAIZ_TIP"].ToString();

                    if (sozluk.ContainsKey(faizTip))
                        sozluk[faizTip].Add(reader["TO_UYGULANACAK_FAIZ_ORANI"] as double?);
                    else
                    {
                        sozluk.Add(faizTip, new List<double?>());
                        sozluk[faizTip].Add(reader["TO_UYGULANACAK_FAIZ_ORANI"] as double?);
                    }
                }

                return sozluk;
            }

            public static TList<AV001_TI_BIL_GAYRIMENKUL> GetGayrimenkulByFoyAndBelediye(int icraFoyId, int belediyeId)
            {
                //                string sorgu =
                //                    string.Format(
                //                        @"SELECT * FROM AV001_TI_BIL_GAYRIMENKUL WHERE BELEDIYE_ID = {0} AND ID
                //	                                            IN
                //                                            (SELECT GAYRIMENKUL_ID FROM NN_ICRA_GAYRIMENKUL WHERE ICRA_FOY_ID = {1})",
                //                        belediyeId, icraFoyId);

                string sorgu1 =
                      string.Format(
                          @"  SELECT * FROM AV001_TI_BIL_GAYRIMENKUL WHERE BELEDIYE_ID = {0} AND ID IN (SELECT GAYRIMENKUL_ID FROM NN_SOZLESME_GAYRIMENKUL WHERE SOZLESME_ID IN (SELECT SOZLESME_ID  FROM NN_ICRA_SOZLESME WHERE ICRA_FOY_ID = {1} ) )", belediyeId, icraFoyId);

                var sonuclar = AV001_TI_BIL_GAYRIMENKULProviderBaseCore.Fill(
                    DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu1),
                    new TList<AV001_TI_BIL_GAYRIMENKUL>(), 0, int.MaxValue);

                return sonuclar;
            }

            public static TList<AV001_TI_BIL_GAYRIMENKUL> GetGayrimenkulByFoyAndTapuMudurlugu(int icraFoyId,
                                                                                              int tapuMudurlukId)
            {
                //                string sorgu =
                //                    string.Format(
                //                        @"SELECT * FROM AV001_TI_BIL_GAYRIMENKUL WHERE TAPU_MUDURLUK_ID = {0} AND ID
                //	                                            IN
                //                                            (SELECT GAYRIMENKUL_ID FROM NN_ICRA_GAYRIMENKUL WHERE ICRA_FOY_ID = {1})"
                //                        , tapuMudurlukId, icraFoyId);

                string sorgu1 =
                     string.Format(
                         @"  SELECT * FROM AV001_TI_BIL_GAYRIMENKUL WHERE TAPU_MUDURLUK_ID = {0} AND ID IN (SELECT GAYRIMENKUL_ID FROM NN_SOZLESME_GAYRIMENKUL WHERE SOZLESME_ID IN (SELECT SOZLESME_ID  FROM NN_ICRA_SOZLESME WHERE ICRA_FOY_ID = {1} ) )", tapuMudurlukId, icraFoyId);

                var sonuclar = AV001_TI_BIL_GAYRIMENKULProviderBaseCore.Fill(
                    DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu1),
                    new TList<AV001_TI_BIL_GAYRIMENKUL>(), 0, int.MaxValue);

                return sonuclar;
            }

            public static TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> GetGemiUcakAracByFoyAndTrafikSube(int foyId,
                                                                                                string trafikSubeAdi)
            {
                string sorgu =
                    string.Format(
                        @"SELECT * FROM dbo.AV001_TDI_BIL_GEMI_UCAK_ARAC WHERE TRAFIK_SUBESI = '{0}' AND ID IN
                                              (SELECT GEMI_UCAK_ARAC_ID FROM dbo.NN_ICRA_GEMI_UCAK_ARAC WHERE ICRA_FOY_ID = {1})",
                        trafikSubeAdi, foyId);
                var sonuclar = AV001_TDI_BIL_GEMI_UCAK_ARACProviderBaseCore.Fill(
                    DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu),
                    new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>(), 0, int.MaxValue);

                return sonuclar;
            }

            public static TList<AV001_TI_BIL_HACIZ_MASTER> GetHacizMasterByFoyAndYuzUcUygulansin(int icraFoyId,
                                                                                                 bool yuzUcUygulansin)
            {
                string sorgu =
                    string.Format(
                        @"SELECT * FROM dbo.AV001_TI_BIL_HACIZ_MASTER
	                                            WHERE ICRA_FOY_ID = {0}
	                                            AND YUZUC_UYGULANDI_MI = {1}"
                        , icraFoyId
                        , yuzUcUygulansin ? 1 : 0);

                var sonuc = AV001_TI_BIL_HACIZ_MASTERProviderBaseCore.Fill(
                    DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu),
                    new TList<AV001_TI_BIL_HACIZ_MASTER>(), 0, int.MaxValue);

                return sonuc;
            }

            public static TList<TDI_KOD_IL> GetIlByFoyTarafNufusKaydi(int foyId,
                                                                      GruplamaAraclari.Icra.FoyTarafGrubu tarafGrubu)
            {
                string kosul = string.Empty;

                switch (tarafGrubu)
                {
                    case GruplamaAraclari.Icra.FoyTarafGrubu.TakipEdenler:
                        kosul =
                            string.Format(
                                @"AND	TARAF_SIFAT_ID IN (SELECT ID FROM TDIE_KOD_TARAF_SIFAT WHERE HANGI_TARAF_NO = 1)");
                        break;

                    case GruplamaAraclari.Icra.FoyTarafGrubu.TakipEdilenler:
                        kosul =
                            string.Format(
                                @"AND	TARAF_SIFAT_ID IN (SELECT ID FROM TDIE_KOD_TARAF_SIFAT WHERE HANGI_TARAF_NO = 2)");
                        break;

                    case GruplamaAraclari.Icra.FoyTarafGrubu.Tumu:
                    default:
                        break;
                }

                string sorgu =
                    string.Format(
                        @"SELECT * FROM TDI_KOD_IL WHERE ID IN
                (SELECT DISTINCT NKO_IL_ID FROM dbo.AV001_TDI_BIL_CARI_KIMLIK WHERE NKO_IL_ID IS NOT NULL AND CARI_ID IN
                (SELECT CARI_ID FROM AV001_TI_BIL_FOY_TARAF WHERE ICRA_FOY_ID = {0} {1}))",
                        foyId, kosul);
                var sonuclar =
                    TDI_KOD_ILProviderBaseCore.Fill(
                        DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu),
                        new TList<TDI_KOD_IL>(), 0, int.MaxValue);

                return sonuclar;
            }

            public static TList<TDI_KOD_ILCE> GetIlceByFoyTarafNufusKaydi(int foyId,
                                                                          GruplamaAraclari.Icra.FoyTarafGrubu tarafGrubu)
            {
                string kosul = string.Empty;

                switch (tarafGrubu)
                {
                    case GruplamaAraclari.Icra.FoyTarafGrubu.TakipEdenler:
                        kosul =
                            string.Format(
                                @"AND	TARAF_SIFAT_ID IN (SELECT ID FROM TDIE_KOD_TARAF_SIFAT WHERE HANGI_TARAF_NO = 1)");
                        break;

                    case GruplamaAraclari.Icra.FoyTarafGrubu.TakipEdilenler:
                        kosul =
                            string.Format(
                                @"AND	TARAF_SIFAT_ID IN (SELECT ID FROM TDIE_KOD_TARAF_SIFAT WHERE HANGI_TARAF_NO = 2)");
                        break;

                    case GruplamaAraclari.Icra.FoyTarafGrubu.Tumu:
                    default:
                        break;
                }

                string sorgu =
                    string.Format(
                        @"SELECT * FROM TDI_KOD_ILCE WHERE ID IN
                (SELECT DISTINCT NKO_ILCE_ID FROM dbo.AV001_TDI_BIL_CARI_KIMLIK WHERE NKO_IL_ID IS NOT NULL AND CARI_ID IN
                (SELECT CARI_ID FROM AV001_TI_BIL_FOY_TARAF WHERE ICRA_FOY_ID = {0} {1}))",
                        foyId, kosul);
                var sonuclar =
                    TDI_KOD_ILCEProviderBaseCore.Fill(
                        DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu),
                        new TList<TDI_KOD_ILCE>(), 0, int.MaxValue);

                return sonuclar;
            }

            public static TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD> GetTaahhutChildByFoyAndGecerliMaster(int foyId)
            {
                string sorgu =
                    string.Format(
                        @" SELECT * FROM  dbo.AV001_TI_BIL_BORCLU_TAAHHUT_CHILD
                                            WHERE MASTER_TAAHHUT_ID IN (
                                            SELECT ID FROM [AV001_TI_BIL_BORCLU_TAAHHUT_MASTER]
                                            WHERE ICRA_FOY_ID = {0} AND GECERLI_MI = 1)
                                            ORDER BY SIRA_NO",
                        foyId);
                var sonuc = AV001_TI_BIL_BORCLU_TAAHHUT_CHILDProviderBaseCore.Fill(
                    DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu)
                    , new TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD>(), 0, int.MaxValue);

                return sonuc;
            }

            public static string GetTaahhutEdenMuvekkiliAdiByFoyIdAndGecerli(int? foyId)
            {
                string sorgu =
                    string.Format(
                        @"SELECT AD FROM AV001_TDI_BIL_CARI WHERE ID IN
                                            (SELECT AVUKAT_CARI_ID FROM AV001_TI_BIL_FOY_TARAF_VEKIL
                                            WHERE FOY_TARAF_ID IN
                                            (SELECT ID FROM AV001_TI_BIL_FOY_TARAF
                                            WHERE ICRA_FOY_ID = {0}
                                            AND
                                            CARI_ID IN
                                            (SELECT
	                                            TAAHHUT_EDEN_ID
                                            FROM dbo.AV001_TI_BIL_BORCLU_TAAHHUT_MASTER
                                            WHERE ICRA_FOY_ID = {0} AND GECERLI_MI = 1)))",
                        foyId);

                var sonuc = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, sorgu);

                if (sonuc != null)
                    return sonuc.ToString();

                return string.Empty;
            }

            public static AV001_TDI_BIL_CARI GetTaahhutMasterBorcluAdiByFoyAndGecerli(int foyId)
            {
                string sorgu =
                    string.Format(
                        @"SELECT TOP(1) * FROM AV001_TDI_BIL_CARI WHERE ID IN
                                                (SELECT TAAHHUT_EDEN_ID FROM [AV001_TI_BIL_BORCLU_TAAHHUT_MASTER]
                                                WHERE ICRA_FOY_ID = {0} AND GECERLI_MI = 1)",
                        foyId);

                var sonuc = AV001_TDI_BIL_CARIProviderBaseCore.Fill(
                    DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu)
                    , new TList<AV001_TDI_BIL_CARI>(), 0, int.MaxValue);
                if (sonuc.Count > 0)
                    return sonuc[0];

                return null;
            }

            public static TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER> GetTaahhutMasterByFoyAndGecerliMi(int foyId,
                                                                                                      bool gecerliMi)
            {
                string sorgu =
                    string.Format(
                        @"SELECT * FROM [AV001_TI_BIL_BORCLU_TAAHHUT_MASTER] WHERE
                                              ICRA_FOY_ID = {0} AND GECERLI_MI = {1}"
                        , foyId
                        , gecerliMi ? 1 : 0);

                var sonuclar = AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProviderBaseCore.Fill(
                    DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu)
                    , new TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>(), 0, int.MaxValue);

                return sonuclar;
            }

            public static DateTime? GetTaahhutMasterTarihByFoyAndGecerliMaster(int foyId)
            {
                string sorgu =
                    string.Format(
                        @"SELECT TAAHHUT_TARIHI FROM [AV001_TI_BIL_BORCLU_TAAHHUT_MASTER]
                                               WHERE ICRA_FOY_ID = {0} AND GECERLI_MI = 1",
                        foyId);

                var sonuc = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, sorgu) as DateTime?;
                return sonuc;
            }

            public static ParaVeDovizId GetTaahhutOdemeToplami(int taahhutMasterId)
            {
                var childler =
                    DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDProvider.GetByMASTER_TAAHHUT_ID(taahhutMasterId);
                List<ParaVeDovizId> paraListesi = new List<ParaVeDovizId>();

                foreach (var item in childler)
                {
                    paraListesi.Add(new ParaVeDovizId(item.TAAHHUT_MIKTARI, item.TAAHHUT_MIKTARI_DOVIZ_ID));
                }

                return ParaVeDovizId.Topla(paraListesi);
            }

            /// <summary>
            /// verilen foy ile NN_ICRA_GAYRIMENKUL Tablosunda nn bağlantılı olanı gayrimenkullerin tapu mudurluklerini verir
            /// degerleri gruplandırarak döndürür
            /// </summary>
            /// <param name="foyId"></param>
            /// <returns></returns>
            public static TList<TDI_KOD_TAPU_MUDURLUK> GetTapuMudurlukleriByFoyGayrimenkul(int icraFoyId)
            {
                string sorgu =
                    string.Format(
                        @"SELECT * FROM TDI_KOD_TAPU_MUDURLUK WHERE ID IN(
                         SELECT    DISTINCT TAPU_MUDURLUK_ID     FROM  AV001_TI_BIL_GAYRIMENKUL AS GAY  RIGHT OUTER JOIN
                         NN_ICRA_SOZLESME AS NN_IS RIGHT OUTER JOIN
                         NN_SOZLESME_GAYRIMENKUL AS NN_SG ON NN_IS.SOZLESME_ID = NN_SG.SOZLESME_ID ON GAY.ID = NN_SG.GAYRIMENKUL_ID  WHERE NN_IS.ICRA_FOY_ID = {0})",
                        icraFoyId);

                var sonuclar = TDI_KOD_TAPU_MUDURLUKProviderBaseCore.Fill(
                    DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu),
                    new TList<TDI_KOD_TAPU_MUDURLUK>(), 0, int.MaxValue);

                return sonuclar;
            }

            public static TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> GetTebligatMuhattapByFoyAndKonu(int foyId,
                                                                                                TebligatKonu
                                                                                                    tebligatKonu)
            {
                string sorgu =
                    string.Format(
                        @"SELECT * FROM dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP
                                                WHERE TEBLIGAT_ID IN
	                                            (SELECT ID FROM dbo.AV001_TDI_BIL_TEBLIGAT
                                                    WHERE ICRA_FOY_ID = {0} AND KONU_ID = {1})"
                        , foyId
                        , (int)tebligatKonu);

                var sonuclar =
                    AV001_TDI_BIL_TEBLIGAT_MUHATAPProviderBaseCore.Fill(
                        DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu),
                        new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>(), 0, int.MaxValue);

                return sonuclar;
            }

            public static DateTime? GetTebligTarihiByFoyAndKonuAndCariAltId(int foyId, TebligatKonu tebligatKonu,
                                                                            int cariAltId)
            {
                string sorgu =
                    string.Format(
                        @"SELECT TOP(1) TEBLIG_TARIH FROM dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP
                                                WHERE TEBLIGAT_ID IN
	                                            (SELECT ID FROM dbo.AV001_TDI_BIL_TEBLIGAT
                                                    WHERE ICRA_FOY_ID = {0}
                                                    AND TEBIGAT_KONU_ID = {1}
                                                    AND CARI_ALT_ID = {2})"
                        , foyId
                        , (int)tebligatKonu
                        , cariAltId);

                var sonuclar = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, sorgu);

                // AV001_TDI_BIL_TEBLIGAT_MUHATAPProviderBase.Fill(DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu), new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>(), 0, int.MaxValue);

                return sonuclar as DateTime?;
            }

            public static DateTime? GetTebligTarihiByFoyAndKonuAndCariId(int foyId, TebligatKonu tebligatKonu,
                                                                         int muhattapCariId)
            {
                string sorgu =
                    string.Format(
                        @"SELECT TOP(1) TEBLIG_TARIH FROM dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP
                                                WHERE TEBLIGAT_ID IN
	                                            (SELECT ID FROM dbo.AV001_TDI_BIL_TEBLIGAT
                                                    WHERE ICRA_FOY_ID = {0}
                                                    AND TEBIGAT_KONU_ID = {1}
                                                    AND MUHATAP_CARI_ID = {2})"
                        , foyId
                        , (int)tebligatKonu
                        , muhattapCariId);

                object sonuclar = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, sorgu);

                // AV001_TDI_BIL_TEBLIGAT_MUHATAPProviderBase.Fill(DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu), new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>(), 0, int.MaxValue);

                return sonuclar as DateTime?;
            }

            /// <summary>
            /// Föye NN_ICRA_GEMI_UCAK_ARAC ile bağlı AV001_TDI_BIL_GEMI_UCAK_ARAC kayıtlarının
            /// trafik şubelerini herşube bir kere gelicek şekilde döndürür
            /// </summary>
            /// <param name="icraFoyId"></param>
            /// <returns></returns>
            public static List<string> GetTrafikSubeMudurluguByFoyGemiUcakArac(int icraFoyId)
            {
                string sorgu =
                    string.Format(
                        @"SELECT DISTINCT TRAFIK_SUBESI FROM dbo.AV001_TDI_BIL_GEMI_UCAK_ARAC WHERE ID IN
                                               (SELECT GEMI_UCAK_ARAC_ID FROM dbo.NN_ICRA_GEMI_UCAK_ARAC WHERE ICRA_FOY_ID = {0})",
                        icraFoyId);

                List<string> liste = new List<string>();
                var reader = DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu);
                while (reader.Read())
                {
                    liste.Add(reader[0].ToString());
                }

                return liste;
            }
        }

        public static class Klasor
        {
            public static Dictionary<string, List<double?>> GetFaizTipVeOranlarById(int projeId)
            {
                string sorgu =
                    string.Format(
                        @"SELECT DISTINCT
                                (SELECT FAIZ_TIP FROM TDI_KOD_FAIZ_TIP WHERE ID = TO_ALACAK_FAIZ_TIP_ID) AS FAIZ_TIP ,
                                TO_UYGULANACAK_FAIZ_ORANI
                                FROM AV001_TI_BIL_ALACAK_NEDEN WHERE ID IN
                                (SELECT ICRA_FOY_ID FROM dbo.AV001_TDIE_BIL_PROJE_ICRA_FOY WHERE PROJE_ID = {0})
                                OR ID IN
                                (SELECT ALACAK_NEDEN_ID FROM dbo.AV001_TDIE_BIL_PROJE_ALACAK_NEDEN WHERE PROJE_ID = {0})"
                        , projeId);

                var reader = DataRepository.Provider.ExecuteReader(System.Data.CommandType.Text, sorgu);

                Dictionary<string, List<double?>> sozluk = new Dictionary<string, List<double?>>();

                while (reader.Read())
                {
                    string faizTip = reader["FAIZ_TIP"].ToString();

                    if (sozluk.ContainsKey(faizTip))
                        sozluk[faizTip].Add(reader["TO_UYGULANACAK_FAIZ_ORANI"] as double?);
                    else
                    {
                        sozluk.Add(faizTip, new List<double?>());
                        sozluk[faizTip].Add(reader["TO_UYGULANACAK_FAIZ_ORANI"] as double?);
                    }
                }

                return sozluk;
            }

            public static VList<R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPOR> GetIcraFoyIdByProjeId(int projeId)
            {
                return DataRepository.R_TI_BANKALI_TARAFLI_SORUMLULU_HESAPLI_RAPORProvider.GetByProjeId(projeId);
            }

            public static TList<AV001_TDIE_BIL_PROJE_SORUMLU> GetKlasorSorumlulariById(int projeId)
            {
                var sonuclar = DataRepository.AV001_TDIE_BIL_PROJE_SORUMLUProvider.GetByPROJE_ID(projeId);

                return sonuclar;
            }

            public static string GetKlasorSubesiById(int id)
            {
                var sonuc = DataRepository.TDIE_KOD_PROJE_OZEL_KODProvider.GetByID(id);

                if (sonuc != null)
                    return sonuc.OZEL_KOD;
                else
                    return "";
            }

            public static VList<V_PROJE_ALACAK_NEDEN_TARAF_SORUMLULUK> GetKlasorTarafSorumlulukByProjeId(int projeId)
            {
                return DataRepository.V_PROJE_ALACAK_NEDEN_TARAF_SORUMLULUKProvider.GetByProjeId(projeId);
            }

            public static string GetKlasorTipById(int id)
            {
                var sonuc = DataRepository.TDIE_KOD_PROJE_TIPProvider.GetByID(id);

                return sonuc.TIP;
            }

            public static VList<R_SORUSTURMA_GENEL_HESAPSIZ_TARAFLI> GetSorusturmaBilgileriByProjeId(int projeId)
            {
                var liste = DataRepository.R_SORUSTURMA_GENEL_HESAPSIZ_TARAFLIProvider.GetByProjeId(projeId);

                var foyler =
                    DataRepository.AV001_TI_BIL_FOYProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_ICRA_FOY(projeId);
                if (foyler.Count > 0)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyler, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI>),
                                                                     typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>));

                    foreach (var foy in foyler)
                    {
                        if (foy.AV001_TDI_BIL_KAYIT_ILISKICollection.Count > 0)
                        {
                            foreach (var iliski in foy.AV001_TDI_BIL_KAYIT_ILISKICollection)
                            {
                                liste.AddRange(GetSorusturmaBilgileriByKayitIliski(iliski));
                            }
                        }
                        else if (foy.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection.Count > 0)
                        {
                            foreach (var iliskiDetay in foy.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection)
                            {
                                liste.AddRange(GetSorusturmaBilgileriByKayitIliski(
                                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByID(
                                        iliskiDetay.KAYIT_ILISKI_ID)));
                            }
                        }
                    }
                }

                Dictionary<string, R_SORUSTURMA_GENEL_HESAPSIZ_TARAFLI> sozluk =
                    new Dictionary<string, R_SORUSTURMA_GENEL_HESAPSIZ_TARAFLI>();

                foreach (var item in liste)
                {
                    if (sozluk.ContainsKey(item.HAZIRLIK_NO))
                    {
                        var hazirlik = sozluk[item.HAZIRLIK_NO];
                        if (!hazirlik.SORUMLU_AVUKAT.Contains(item.SORUMLU_AVUKAT))
                            hazirlik.SORUMLU_AVUKAT += Environment.NewLine + item.SORUMLU_AVUKAT;

                        if (!hazirlik.SORUSTURMA_TARAF_ADI.Contains(item.SORUSTURMA_TARAF_ADI))
                            hazirlik.SORUSTURMA_TARAF_ADI += Environment.NewLine + item.SORUSTURMA_TARAF_ADI;
                    }
                    else
                        sozluk.Add(item.HAZIRLIK_NO, item);
                }

                liste.Clear();

                foreach (var item in sozluk)
                {
                    liste.Add(item.Value);
                }
                return liste;
            }

            public static VList<V_PROJE_TAAHUT_PROJE> GetTaahhutBilgileriByProjeID(int projeId)
            {
                return DataRepository.V_PROJE_TAAHUT_PROJEProvider.GetByProjeId(projeId);
            }

            public static VList<VDIE_PROJE_KIYMETLI_EVRAK> GetTeminatBilgileriByProjeId(int projeId, bool munzammmi)
            {
                AvukatProLib2.Data.VDIE_PROJE_KIYMETLI_EVRAKQuery qu = new VDIE_PROJE_KIYMETLI_EVRAKQuery();
                qu.Append(VDIE_PROJE_KIYMETLI_EVRAKColumn.PROJE_ID, projeId.ToString());
                qu.Append(VDIE_PROJE_KIYMETLI_EVRAKColumn.MUNZAM_SENET_MI, munzammmi.ToString());
                return DataRepository.VDIE_PROJE_KIYMETLI_EVRAKProvider.Find(qu);

                //return DataRepository.R_KIYMETLI_EVRAK_TARAFLI_RAPORProvider.GetByProjeId(projeId);
            }

            private static VList<R_SORUSTURMA_GENEL_HESAPSIZ_TARAFLI> GetSorusturmaBilgileriByKayitIliski(
                AV001_TDI_BIL_KAYIT_ILISKI kiliski)
            {
                var liste = new VList<R_SORUSTURMA_GENEL_HESAPSIZ_TARAFLI>();
                if (kiliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection.Count == 0)
                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.DeepLoad(kiliski, false,
                                                                               DeepLoadType.IncludeChildren,
                                                                               typeof(
                                                                                   TList
                                                                                   <AV001_TDI_BIL_KAYIT_ILISKI_DETAY>));

                var sorusturmalar =
                    kiliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection.Where(vi => vi.HEDEF_HAZIRLIK_ID.HasValue);
                foreach (var item in sorusturmalar)
                {
                    var kayitlar = DataRepository.R_SORUSTURMA_GENEL_HESAPSIZ_TARAFLIProvider
                        .Get("ID = " + item.HEDEF_HAZIRLIK_ID.Value, "ID ASC");

                    liste.AddRange(kayitlar);
                }

                return liste;
            }
        }

        public static class Kodlar
        {
            public static string GetIlAdi(int? ilId)
            {
                if (ilId == null) return string.Empty;

                string sorgu = string.Format(@"SELECT IL FROM TDI_KOD_IL WHERE ID = {0}", ilId.Value);

                var sonuc = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, sorgu);

                return sonuc.ToString();
            }

            public static string GetIlceAdi(int? ilceId)
            {
                if (ilceId == null) return string.Empty;

                string sorgu = string.Format(@"SELECT ILCE FROM TDI_KOD_ILCE WHERE ID = {0}", ilceId.Value);

                var sonuc = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, sorgu);

                return sonuc.ToString();
            }

            public static string GetSemtAdi(int semtId)
            {
                string sorgu = string.Format(@"SELECT SEMT FROM TDI_KOD_SEMT WHERE ID = {0}", semtId);

                var sonuc = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, sorgu);

                return sonuc.ToString();
            }
        }

        public static class Tools
        {
            //efe
            public static string GetAdliBirimGorev(int? AdliBirimGorevId)
            {
                if (!AdliBirimGorevId.HasValue) return string.Empty;

                return DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.GetByID((int)AdliBirimGorevId).GOREV;
            }

            //efe
            public static string GetAdliBirimNo(int? AdliBirimNoId)
            {
                if (!AdliBirimNoId.HasValue) return string.Empty;

                return DataRepository.TDI_KOD_ADLI_BIRIM_NOProvider.GetByID((int)AdliBirimNoId).NO;
            }

            public static string GetCari(int? CariId)
            {
                if (!CariId.HasValue) return string.Empty;

                return DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)CariId).AD;
            }

            //efe
            public static string GetDovizTipi(int? DovizTipiId)
            {
                if (!DovizTipiId.HasValue) return string.Empty;

                return DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetByID((int)DovizTipiId).DOVIZ_KODU;
            }

            //efe
            public static string GetIcraGelismeAdim(int? IcraGelismeAdimId)
            {
                if (!IcraGelismeAdimId.HasValue) return string.Empty;

                return DataRepository.TI_KOD_FOY_GELISME_ADIMProvider.GetByID((int)IcraGelismeAdimId).GELISME_ADIM;
            }

            //efe
            public static string GetIcraTarafiGetir(int? IcraTarafiGetirId)
            {
                if (!IcraTarafiGetirId.HasValue) return string.Empty;

                int cari_id = (Int32)DataRepository.AV001_TI_BIL_FOY_TARAFProvider.GetByID((int)IcraTarafiGetirId).CARI_ID;

                return DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)cari_id).AD;
            }

            //efe
            public static string GetMahkeme(int? AdliBirimAdliyeId)
            {
                if (!AdliBirimAdliyeId.HasValue) return string.Empty;

                return DataRepository.TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetByID((int)AdliBirimAdliyeId).ADLIYE;
            }

            //efe
            public static string GetOdemeTipi(int? OdemeTipiId)
            {
                if (!OdemeTipiId.HasValue) return string.Empty;

                return DataRepository.TDI_KOD_ODEME_TIPProvider.GetByID((int)OdemeTipiId).ODEME_TIP;
            }

            //efe
            public static string GetOdemeYeri(int? OdemeYerId)
            {
                if (!OdemeYerId.HasValue) return string.Empty;

                return DataRepository.TI_KOD_ODEME_YERIProvider.GetByID((int)OdemeYerId).ODEME_YERI;
            }

            public static string TarihBicimlendirme(DateTime? tarih)
            {
                if (tarih != null)
                    return TarihBicimlendirme(tarih.Value);

                else return string.Empty;
            }

            public static string TarihBicimlendirme(DateTime tarih)
            {
                return TarihBicimlendirme(tarih, false);
            }

            public static string TarihBicimlendirme(DateTime tarih, bool IsShort)
            {
                return tarih.ToShortDateString();                
            }
        }
    }

    public static class GruplamaAraclari
    {
        public static class Icra
        {
            #region Main Methodlar

            public enum FoyTarafGrubu
            {
                TakipEdenler,
                TakipEdilenler,
                Tumu
            }

            public static List<EditorDokuman> GetGruplu89Muhattaplari(AV001_TI_BIL_FOY foy, TextControl txControl,
                                                                      AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rapor, TebligatKonu konu, string BarkodTip)
            {
                List<EditorDokuman> dokumanListesi = new List<EditorDokuman>();
                EditorAraclari ea = new EditorAraclari();

                // Standart değişkenleri doldurup elimize bir dokuman nesnesi aldık
                var dokuman = ea.GetEditorDokumansByStandartMode(txControl, foy, rapor);

                var muhattaplar = EditorDataAraclari.Icra.GetTebligatMuhattapByFoyAndKonu(foy.ID, konu);

                foreach (var muhattap in muhattaplar)
                {
                    EditorDokuman yeniDokuman = new EditorDokuman(foy);
                    if (muhattap.CARI_ALT_ID.HasValue)
                        yeniDokuman.Ad = muhattap.CARI_ALT_ID.Value.ToString();
                    else
                        yeniDokuman.Ad = muhattap.MUHATAP_CARI_ID.ToString();
                    yeniDokuman.Taraflar.Add(muhattap.MUHATAP_CARI_ID, 34);

                    //yeniDokuman.Sablon = rapor;

                    var fieldListesi = ea.GetFieldListByEditorDokumanAndTextControl(dokuman, txControl);
                    yeniDokuman.Tur = rapor.AD;
                    yeniDokuman.TurID = rapor.ID;
                    if (rapor.ID == 333 || rapor.ID == 439 || rapor.ID == 504 || rapor.ID == 505 || rapor.ID == 507 || rapor.ID == 509 || rapor.ID == 510 || rapor.ID == 520 || rapor.ID == 1204 || rapor.ID == 1219 || rapor.ID == 3213 || rapor.ID == 3214 || rapor.ID == 3215 || rapor.ID == 3216)
                    {
                        foreach (var item in BarkodTip.Split(','))
                        {
                            if (item.ToString() == "1")
                            {
                                yeniDokuman.barkodTurID = 1;
                            }
                            else if (item.ToString() == "4")
                            {
                                yeniDokuman.barkodTurID = 4;
                            }
                            else if (item.ToString() == "0")
                            {
                                yeniDokuman.barkodTurID = 0;
                            }
                        }
                    }
                    else if (rapor.ID == 3211)
                    {
                        foreach (var item in BarkodTip.Split(','))
                        {
                            if (item.ToString() == "2")
                            {
                                yeniDokuman.barkodTurID = 2;
                            }
                            else if (item.ToString() == "0")
                            {
                                yeniDokuman.barkodTurID = 0;
                            }
                        }
                    }
                    else if (rapor.ID == 3212)
                    {
                        foreach (var item in BarkodTip.Split(','))
                        {
                            if (item.ToString() == "5")
                            {
                                yeniDokuman.barkodTurID = 5;
                            }
                            else if (item.ToString() == "0")
                            {
                                yeniDokuman.barkodTurID = 0;
                            }
                        }
                    }

                    foreach (var field in fieldListesi)
                    {
                        object result = string.Empty;

                        switch (field.Text)
                        {
                            case "[ICRA] GRUPLU 89/1 HACIZ IHBARNAME BORCLULARI":
                            case "[ICRA] GRUPLU 89/2 HACIZ IHBARNAME BORCLULARI":
                            case "[ICRA] GRUPLU 89/3 HACIZ IHBARNAME BORCLULARI":
                                result = GetTebligatMuhattapBilgisi(muhattap, false);
                                break;

                            case "[ICRA] GRUPLU 89/1 HACIZ IHBARNAME BORCLULARI ADRESLI":
                            case "[ICRA] GRUPLU 89/2 HACIZ IHBARNAME BORCLULARI ADRESLI":
                            case "[ICRA] GRUPLU 89/3 HACIZ IHBARNAME BORCLULARI ADRESLI":
                                result = GetTebligatMuhattapBilgisi(muhattap, true);
                                break;

                            case "[ICRA] GRUPLANAN HACIZ IHBARNAME TEBLIG TARIHI":
                            case "[ICRA] GRUPLU HACIZ BORCLU ADI":
                                result = GetTebligatMuhattapTebligTarihi(muhattap, konu);
                                break;

                            case "[ICRA] FOY TARAF BAZINDA PTT BARKOD":
                                field.Text = AvukatProDegiskenler.Icra.Degiskenler.GetPTTBarkodGetir(foy, muhattap.MUHATAP_CARI_ID, BarkodTip, rapor);
                                break;
                        }

                        SetFieldValue(field, result);
                    }

                    byte[] dizi;
                    txControl.Save(out dizi, BinaryStreamType.InternalFormat);

                    yeniDokuman.Dokuman = dizi;
                    dokumanListesi.Add(yeniDokuman);
                }

                return dokumanListesi;
            }

            public static List<EditorDokuman> GetGrupluAracBilgileriTrafikSubesineGore(AV001_TI_BIL_FOY foy,
                                                                                       TextControl txControl,
                                                                                       AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rapor)
            {
                List<EditorDokuman> dokumanListesi = new List<EditorDokuman>();
                EditorAraclari ea = new EditorAraclari();

                // Standart değişkenleri doldurup elimize bir dokuman nesnesi aldık
                var dokuman = ea.GetEditorDokumansByStandartMode(txControl, foy, rapor);

                var trafikSubeleri = EditorDataAraclari.Icra.GetTrafikSubeMudurluguByFoyGemiUcakArac(foy.ID);

                foreach (var tSube in trafikSubeleri)
                {
                    if (tSube.Length == 0) continue;

                    EditorDokuman yeniDokuman = new EditorDokuman(foy);
                    yeniDokuman.Ad = tSube;

                    //yeniDokuman.Sablon = rapor;

                    var fieldListesi = ea.GetFieldListByEditorDokumanAndTextControl(dokuman, txControl);

                    foreach (var field in fieldListesi)
                    {
                        object result = string.Empty;
                        switch (field.Text)
                        {
                            case "[ICRA] GRUPLU ARAC TRAFIK SUBESI":
                                result = tSube;
                                break;

                            case "[ICRA] TRAFIK SUBESINE GRUPLU ARAC BILGILERI":
                                result =
                                    GetAracBilgisi(EditorDataAraclari.Icra.GetGemiUcakAracByFoyAndTrafikSube(foy.ID,
                                                                                                             tSube));
                                break;

                            default:
                                break;
                        }

                        SetFieldValue(field, result);
                    }

                    byte[] dizi;
                    txControl.Save(out dizi, BinaryStreamType.InternalFormat);
                    yeniDokuman.Dokuman = dizi;
                    dokumanListesi.Add(yeniDokuman);
                }

                return dokumanListesi;
            }

            public static List<EditorDokuman> GetGrupluCekBilgileriBankalaraGore(AV001_TI_BIL_FOY foy,
                                                                                 TextControl txControl,
                                                                                 AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rapor)
            {
                List<EditorDokuman> dokumanListesi = new List<EditorDokuman>();
                EditorAraclari ea = new EditorAraclari();

                // Standart değişkenleri doldurup elimize bir dokuman nesnesi aldık
                var dokuman = ea.GetEditorDokumansByStandartMode(txControl, foy, rapor);

                var bankalar = EditorDataAraclari.Icra.GetBankaByFoyCek(foy.ID);

                foreach (var banka in bankalar)
                {
                    EditorDokuman yeniDokuman = new EditorDokuman(foy);
                    yeniDokuman.Ad = banka.BANKA;

                    //yeniDokuman.Sablon = rapor;

                    var fieldListesi = ea.GetFieldListByEditorDokumanAndTextControl(dokuman, txControl);

                    foreach (var field in fieldListesi)
                    {
                        object result = string.Empty;

                        switch (field.Text)
                        {
                            case "[ICRA] GRUPLU FOY CEK BANKALARI":
                                result = GetBanka(banka);
                                break;

                            case "[ICRA] BANKALARA GRUPLU CEK BILGILERI":
                                result = GetCekBilgileri(EditorDataAraclari.Icra.GetCekByFoyAndBanka(foy.ID, banka.ID));
                                break;
                        }

                        SetFieldValue(field, result);
                    }

                    byte[] dizi;

                    txControl.Save(out dizi, BinaryStreamType.InternalFormat);

                    yeniDokuman.Dokuman = dizi;

                    dokumanListesi.Add(yeniDokuman);
                }

                return dokumanListesi;
            }

            public static List<EditorDokuman> GetGrupluCekBilgileriBankaSubesineGore(AV001_TI_BIL_FOY foy,
                                                                                     TextControl txControl,
                                                                                     AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rapor)
            {
                List<EditorDokuman> dokumanListesi = new List<EditorDokuman>();
                EditorAraclari ea = new EditorAraclari();

                // Standart değişkenleri doldurup elimize bir dokuman nesnesi aldık
                var dokuman = ea.GetEditorDokumansByStandartMode(txControl, foy, rapor);

                var subeler = EditorDataAraclari.Icra.GetBankaSubeleriByFoyCek(foy.ID);

                foreach (var sube in subeler)
                {
                    EditorDokuman yeniDokuman = new EditorDokuman(foy);
                    yeniDokuman.Ad = sube.SUBE;

                    //yeniDokuman.Sablon = rapor;

                    var fieldListesi = ea.GetFieldListByEditorDokumanAndTextControl(dokuman, txControl);

                    foreach (var field in fieldListesi)
                    {
                        object result = string.Empty;

                        switch (field.Text)
                        {
                            case "[ICRA] GRUPLU FOY CEK BANKA SUBELERI":
                                result = GetBankaSubesi(sube);
                                break;

                            case "[ICRA] BANKA SUBELERINE GRUPLU CEK BILGILERI":
                                result =
                                    GetCekBilgileri(EditorDataAraclari.Icra.GetCekByFoyAndBankaSube(foy.ID, sube.ID));
                                break;
                        }

                        SetFieldValue(field, result);
                    }

                    byte[] dizi;

                    txControl.Save(out dizi, BinaryStreamType.InternalFormat);

                    yeniDokuman.Dokuman = dizi;

                    dokumanListesi.Add(yeniDokuman);
                }

                return dokumanListesi;
            }

            public static List<EditorDokuman> GetGrupluGayrimenkulBelediyereGore(AV001_TI_BIL_FOY foy,
                                                                                 TextControl txControl,
                                                                                 AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rapor)
            {
                List<EditorDokuman> dokumanListesi = new List<EditorDokuman>();
                EditorAraclari ea = new EditorAraclari();

                // Standart değişkenleri doldurup elimize bir dokuman nesnesi aldık
                var dokuman = ea.GetEditorDokumansByStandartMode(txControl, foy, rapor);

                var belediyeler = EditorDataAraclari.Icra.GetBelediyeByFoyGayrimenkul(foy.ID);

                foreach (var belediye in belediyeler)
                {
                    var fieldListesi = ea.GetFieldListByEditorDokumanAndTextControl(dokuman, txControl);
                    EditorDokuman yeniDokuman = new EditorDokuman(foy);
                    yeniDokuman.Ad = belediye.ADI;

                    //yeniDokuman.Sablon = rapor;

                    foreach (var field in fieldListesi)
                    {
                        object result = string.Empty;
                        switch (field.Text)
                        {
                            case "[ICRA] GRUPLU GAYRIMENKUL BELEDIYESI":
                                result = GetBelediye(belediye);
                                break;

                            case "[ICRA] BELEDIYEYE GRUPLU GAYRIMENKUL BILGILERI":
                                result =
                                    GetGayrimenkulBilgileri(
                                        EditorDataAraclari.Icra.GetGayrimenkulByFoyAndBelediye(foy.ID, belediye.ID));
                                break;

                            default:
                                break;
                        }

                        SetFieldValue(field, result);
                    }

                    byte[] dizi;
                    txControl.Save(out dizi, BinaryStreamType.InternalFormat);

                    yeniDokuman.Dokuman = dizi;
                    dokumanListesi.Add(yeniDokuman);
                }

                return dokumanListesi;
            }

            public static List<EditorDokuman> GetGrupluGayrimenkulTapuMudurluguneGore(AV001_TI_BIL_FOY foy,
                                                                                      TextControl txControl,
                                                                                      AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rapor)
            {
                List<EditorDokuman> dokumanListesi = new List<EditorDokuman>();
                EditorAraclari ea = new EditorAraclari();

                // Standart değişkenleri doldurup elimize bir dokuman nesnesi aldık
                var dokuman = ea.GetEditorDokumansByStandartMode(txControl, foy, rapor);

                var tapuMudurlukleri = EditorDataAraclari.Icra.GetTapuMudurlukleriByFoyGayrimenkul(foy.ID);

                #region Grupladığımız Kayıtlarda dönüp EditorDokuman nesneleri oluşturuyoruz

                foreach (var mudurluk in tapuMudurlukleri)
                {
                    var fieldListesi = ea.GetFieldListByEditorDokumanAndTextControl(dokuman, txControl);
                    EditorDokuman yeniDokuman = new EditorDokuman(foy);
                    yeniDokuman.Ad = mudurluk.ADI;

                    //yeniDokuman.Sablon = rapor;

                    foreach (var field in fieldListesi)
                    {
                        object result = string.Empty;
                        switch (field.Text)
                        {
                            case "[ICRA] GRUPLU GAYRIMENKUL TAPU MUDURLUK":
                                result = GetTapuMudurlugu(mudurluk);
                                break;

                            case "[ICRA] TAPU MUDURLUGUNE GRUPLU GAYRIMENKUL BILGILERI":
                                result =
                                    GetGayrimenkulBilgileri(
                                        EditorDataAraclari.Icra.GetGayrimenkulByFoyAndTapuMudurlugu(foy.ID, mudurluk.ID));
                                break;

                            default:

                                //result = field.Text;
                                break;
                        }

                        SetFieldValue(field, result);
                    }

                    byte[] dizi;
                    txControl.Save(out dizi, BinaryStreamType.InternalFormat);
                    yeniDokuman.Dokuman = dizi;
                    dokumanListesi.Add(yeniDokuman);
                }

                #endregion

                return dokumanListesi;
            }

            public static List<EditorDokuman> GetGrupluGayriNakitler(AV001_TI_BIL_FOY foy, TextControl txControl,
                                                                     AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rapor)
            {
                List<EditorDokuman> dokumanListesi = new List<EditorDokuman>();
                EditorAraclari ea = new EditorAraclari();

                // Standart değişkenleri doldurup elimize bir dokuman nesnesi aldık
                var dokuman = ea.GetEditorDokumansByStandartMode(txControl, foy, rapor);

                var gayriNakitler = HesapAraclari.Icra.AlacakNedenNakiteDonmusGayriNakitleriGetir(foy);

                foreach (var alacak in gayriNakitler)
                {
                    EditorDokuman yeniDokuman = new EditorDokuman(foy);

                    var nedenKod = DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(alacak.ALACAK_NEDEN_KOD_ID ?? 0);
                    if (nedenKod != null)
                    {
                        yeniDokuman.Ad = nedenKod.ALACAK_NEDENI;
                    }

                    //yeniDokuman.Sablon = rapor;

                    var fieldListesi = ea.GetFieldListByEditorDokumanAndTextControl(dokuman, txControl);

                    foreach (var field in fieldListesi)
                    {
                        object result = string.Empty;

                        switch (field.Text)
                        {
                            case "[ICRA] GRUPLU GAYRINAKITLER":
                                result = GetGayriNakitAlacakNedenKod(alacak);
                                break;

                            case "[ICRA] GAYRINAKITE GRUPLU MUHATTAP":
                                result = GetGayriNakitMuhattap(alacak);
                                break;

                            case "[ICRA] GAYRINAKITE GRUPLU DUZENLENME TARIHI":
                                result = GetGayriNakitDuzenlemeTarihi(alacak);
                                break;

                            case "[ICRA] GAYRINAKITE GRUPLU TUTARI":
                                result = GetGayriNakitTutari(alacak);
                                break;

                            case "[ICRA] GAYRINAKITE GRUPLU TAZMIN TARIHI":
                                result = GetGayriNakitTazminTarihi(alacak);
                                break;

                            case "[ICRA] GAYRINAKITE GRUPLU TAZMIN TUTARI":
                                result = GetGayriNakitTazminTutari(alacak);
                                break;

                            case "[ICRA] GAYRINAKITE GRUPLU ISLEME KONAN TUTAR":
                                result = GetGayriNakitIslemeKonanTutari(alacak);
                                break;

                            case "[ICRA] GAYRINAKITE GRUPLU FAIZ ORANI":
                                result = GetGayriNakitFaizOrani(alacak);
                                break;

                            case "[ICRA] GAYRINAKITE GRUPLU DEPO TARIHI":
                                result = GetGayriNakitDepoTarihi(alacak);
                                break;

                            case "[ICRA] GAYRINAKITE GRUPLU DEPO SAYISI":
                                result = GetGayriNakitDepoSayisi(alacak);
                                break;

                            case "[ICRA] GAYRINAKITE GRUPLU IADE TARIHI":
                                result = GetGayriNakitIadeTarihi(alacak);
                                break;

                            case "[ICRA] GAYRINAKITE GRUPLU IADE SAYISI":
                                result = GetGayriNakitIadeSayisi(alacak);
                                break;

                            case "[ICRA] GAYRINAKITE GRUPLU REFERANS NO":
                                result = GetGayriNakitReferansNo(alacak);
                                break;

                            case "[ICRA] GAYRINAKITE GRUPLU CEK YAPRAK SAYISI":
                                result = GetGayriNakitCekYapragiAdedi(alacak);
                                break;
                        }

                        SetFieldValue(field, result);
                    }

                    byte[] dizi;
                    txControl.Save(out dizi, BinaryStreamType.InternalFormat);

                    yeniDokuman.Dokuman = dizi;
                    dokumanListesi.Add(yeniDokuman);
                }

                return dokumanListesi;
            }

            public static List<EditorDokuman> GetGrupluHacizBorclulari(AV001_TI_BIL_FOY foy, TextControl txControl,
                                                                       AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rapor)
            {
                List<EditorDokuman> dokumanListesi = new List<EditorDokuman>();
                EditorAraclari ea = new EditorAraclari();

                // Standart değişkenleri doldurup elimize bir dokuman nesnesi aldık
                var dokuman = ea.GetEditorDokumansByStandartMode(txControl, foy, rapor);

                var hacizler = EditorDataAraclari.Icra.GetHacizMasterByFoyAndYuzUcUygulansin(foy.ID, true);

                foreach (var haciz in hacizler)
                {
                    EditorDokuman yeniDokuman = new EditorDokuman(foy);

                    yeniDokuman.Ad = haciz.HACIZ_TARIHI.ToString();

                    //yeniDokuman.Sablon = rapor;

                    var fieldListesi = ea.GetFieldListByEditorDokumanAndTextControl(dokuman, txControl);

                    foreach (var field in fieldListesi)
                    {
                        object result = string.Empty;

                        switch (field.Text)
                        {
                            case "[ICRA] GRUPLU HACIZ TARIH VE SAATI":
                                result = GetHacizTarihVeSaati(haciz);
                                break;

                            case "[ICRA] GRUPLU HACIZ BORCLU ADI":
                                result = HesapAraclari.Icra.CariAdiGetirByCariId(haciz.HACIZ_ISTENEN_CARI_ID);
                                break;

                            default:
                                break;
                        }

                        SetFieldValue(field, result);
                    }

                    byte[] dizi;
                    txControl.Save(out dizi, BinaryStreamType.InternalFormat);

                    yeniDokuman.Dokuman = dizi;
                    dokumanListesi.Add(yeniDokuman);
                }

                return dokumanListesi;
            }

            public static List<EditorDokuman> GetGrupluIlceNufusBilgileri(AV001_TI_BIL_FOY foy, TextControl txControl,
                                                                          AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rapor,
                                                                          GruplamaAraclari.Icra.FoyTarafGrubu tarafGrubu)
            {
                List<EditorDokuman> dokumanListesi = new List<EditorDokuman>();
                EditorAraclari ea = new EditorAraclari();

                // Standart değişkenleri doldurup elimize bir dokuman nesnesi aldık
                var dokuman = ea.GetEditorDokumansByStandartMode(txControl, foy, rapor);

                var nufusMudurlukleri = EditorDataAraclari.Icra.GetIlceByFoyTarafNufusKaydi(foy.ID, tarafGrubu);

                foreach (var ilce in nufusMudurlukleri)
                {
                    EditorDokuman yeniDokuman = new EditorDokuman(foy);
                    yeniDokuman.Ad = ilce.IL;

                    //yeniDokuman.Sablon = rapor;

                    var fieldListesi = ea.GetFieldListByEditorDokumanAndTextControl(dokuman, txControl);

                    foreach (var field in fieldListesi)
                    {
                        object result = string.Empty;

                        switch (field.Text)
                        {
                            case "[ICRA] GRUPLU TAKIP EDEN TARAF ILCE NUFUS MUDURLUKLERI":
                            case "[ICRA] GRUPLU TAKIP EDILEN TARAF ILCE NUFUS MUDURLUKLERI":
                            case "[ICRA] GRUPLU FOY TARAF ILCE NUFUS MUDURLUKLERI":
                                result = GruplamaAraclari.Icra.GetNufusMudurluguIlce(ilce);
                                break;

                            case "[ICRA] ILCE NUFUS MUDURLUGU GRUPLU TAKIP EDEN TARAFLAR":
                                result =
                                    GruplamaAraclari.Icra.GetCariBilgileri(
                                        EditorDataAraclari.Icra.GetCariByFoyAndNufusaKayitliIl(foy.ID, ilce.ID,
                                                                                               FoyTarafGrubu.
                                                                                                   TakipEdenler));
                                break;

                            case "[ICRA] ILCE NUFUS MUDURLUGUNE GRUPLU TAKIP EDILEN TARAFLAR":
                                result =
                                    GruplamaAraclari.Icra.GetCariBilgileri(
                                        EditorDataAraclari.Icra.GetCariByFoyAndNufusaKayitliIl(foy.ID, ilce.ID,
                                                                                               FoyTarafGrubu.
                                                                                                   TakipEdilenler));
                                break;

                            case "[ICRA] ILCE NUFUS MUDURLUGUNE GRUPLU FOY TARAFLAR":
                                result =
                                    GruplamaAraclari.Icra.GetCariBilgileri(
                                        EditorDataAraclari.Icra.GetCariByFoyAndNufusaKayitliIl(foy.ID, ilce.ID,
                                                                                               FoyTarafGrubu.Tumu));
                                break;
                        }

                        SetFieldValue(field, result);
                    }

                    byte[] dizi;
                    txControl.Save(out dizi, BinaryStreamType.InternalFormat);

                    yeniDokuman.Dokuman = dizi;
                    dokumanListesi.Add(yeniDokuman);
                }

                return dokumanListesi;
            }

            public static List<EditorDokuman> GetGrupluNufusBilgileri(AV001_TI_BIL_FOY foy, TextControl txControl,
                                                                      AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rapor,
                                                                      GruplamaAraclari.Icra.FoyTarafGrubu tarafGrubu)
            {
                List<EditorDokuman> dokumanListesi = new List<EditorDokuman>();
                EditorAraclari ea = new EditorAraclari();

                // Standart değişkenleri doldurup elimize bir dokuman nesnesi aldık
                var dokuman = ea.GetEditorDokumansByStandartMode(txControl, foy, rapor);

                var nufusMudurlukleri = EditorDataAraclari.Icra.GetIlByFoyTarafNufusKaydi(foy.ID, tarafGrubu);

                foreach (var il in nufusMudurlukleri)
                {
                    EditorDokuman yeniDokuman = new EditorDokuman(foy);
                    yeniDokuman.Ad = il.IL;

                    //yeniDokuman.Sablon = rapor;

                    var fieldListesi = ea.GetFieldListByEditorDokumanAndTextControl(dokuman, txControl);

                    foreach (var field in fieldListesi)
                    {
                        object result = string.Empty;

                        switch (field.Text)
                        {
                            case "[ICRA] GRUPLU TAKIP EDEN TARAF NUFUS MUDURLUKLERI":
                            case "[ICRA] GRUPLU TAKIP EDILEN TARAF NUFUS MUDURLUKLERI":
                            case "[ICRA] GRUPLU FOY TARAF NUFUS MUDURLUKLERI":
                                result = GruplamaAraclari.Icra.GetNufusMudurlugu(il);
                                break;

                            case "[ICRA] NUFUS MUDURLUGUNE GRUPLU TAKIP EDEN TARAFLAR":
                                result =
                                    GruplamaAraclari.Icra.GetCariBilgileri(
                                        EditorDataAraclari.Icra.GetCariByFoyAndNufusaKayitliIl(foy.ID, il.ID,
                                                                                               FoyTarafGrubu.
                                                                                                   TakipEdenler));
                                break;

                            case "[ICRA] NUFUS MUDURLUGUNE GRUPLU TAKIP EDILEN TARAFLAR":
                                result =
                                    GruplamaAraclari.Icra.GetCariBilgileri(
                                        EditorDataAraclari.Icra.GetCariByFoyAndNufusaKayitliIl(foy.ID, il.ID,
                                                                                               FoyTarafGrubu.
                                                                                                   TakipEdilenler));
                                break;

                            case "[ICRA] NUFUS MUDURLUGUNE GRUPLU FOY TARAFLAR":
                                result =
                                    GruplamaAraclari.Icra.GetCariBilgileri(
                                        EditorDataAraclari.Icra.GetCariByFoyAndNufusaKayitliIl(foy.ID, il.ID,
                                                                                               FoyTarafGrubu.Tumu));
                                break;
                        }

                        SetFieldValue(field, result);
                    }

                    byte[] dizi;
                    txControl.Save(out dizi, BinaryStreamType.InternalFormat);

                    yeniDokuman.Dokuman = dizi;
                    dokumanListesi.Add(yeniDokuman);
                }

                return dokumanListesi;
            }

            public static List<EditorDokuman> IcraTarafBazindaGruplayarakAc(AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR sablon,
                                                                            AV001_TI_BIL_FOY foy,
                                                                            GruplamaAraclari.Icra.FoyTarafGrubu
                                                                                takipEdenler, TextControl txControl,
                                                                            bool vekilli, string BarkodTip)
            {
                //Döndüreceğimiz EditorDokuman Listesi
                List<EditorDokuman> tekrarlananlar = new List<EditorDokuman>();

                try
                {
                    TList<AV001_TI_BIL_FOY> foyListesi = new TList<AV001_TI_BIL_FOY>();
                    EditorAraclari ea = new EditorAraclari();

                    //Standart Değişkenleri doldurup alıyoruz
                    var standartDokuman = ea.GetEditorDokumansByStandartMode(txControl, foy, sablon);

                    //Her taraf için standart değişkenleri doldurmamak için mevcut halini elimizde tutuyoruz
                    byte[] doluSablon = standartDokuman.Dokuman;

                    //Seçime göre takip eden yada edilen tarafları listemize alıyoruz
                    List<AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF> taraflar =
                        new List<AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF>();
                    if (takipEdenler == FoyTarafGrubu.TakipEdilenler)
                        taraflar = BelgeUtil.Inits.FoyTarafGetir(foy).FindAll(vi => !vi.TAKIP_EDEN_MI);
                    else if (takipEdenler == FoyTarafGrubu.TakipEdenler)
                        taraflar = BelgeUtil.Inits.FoyTarafGetir(foy).FindAll(vi => vi.TAKIP_EDEN_MI);
                    else if (takipEdenler == FoyTarafGrubu.Tumu)
                    {
                        taraflar = BelgeUtil.Inits.FoyTarafGetir(foy); // foy.AV001_TI_BIL_FOY_TARAFCollection;
                    }

                    //cari bilgisinin bulunmaması varsayılarak deepload çekip cari bilgilerini dolduruyoruz

                    foreach (var taraf in taraflar)
                    {
                        #region Dönüyoruz

                        txControl.Load(doluSablon, BinaryStreamType.InternalFormat);

                        EditorDokuman dokuman = new EditorDokuman(foy);
                        dokuman.Tur = sablon.AD;
                        dokuman.TurID = sablon.ID;
                        if (sablon.ID == 333 || sablon.ID == 439 || sablon.ID == 504 || sablon.ID == 505 || sablon.ID == 507 || sablon.ID == 509 || sablon.ID == 510 || sablon.ID == 520 || sablon.ID == 1204 || sablon.ID == 1219 || sablon.ID == 3213 || sablon.ID == 3214 || sablon.ID == 3215 || sablon.ID == 3216)
                        {
                            foreach (var item in BarkodTip.Split(','))
                            {
                                if (item.ToString() == "1")
                                {
                                    dokuman.barkodTurID = 1;
                                }
                                else if (item.ToString() == "4")
                                {
                                    dokuman.barkodTurID = 4;
                                }
                                else if (item.ToString() == "0")
                                {
                                    dokuman.barkodTurID = 0;
                                }
                            }
                        }
                        else if (sablon.ID == 3211)
                        {
                            foreach (var item in BarkodTip.Split(','))
                            {
                                if (item.ToString() == "2")
                                {
                                    dokuman.barkodTurID = 2;
                                }
                                else if (item.ToString() == "0")
                                {
                                    dokuman.barkodTurID = 0;
                                }
                            }
                        }
                        else if (sablon.ID == 3212)
                        {
                            foreach (var item in BarkodTip.Split(','))
                            {
                                if (item.ToString() == "5")
                                {
                                    dokuman.barkodTurID = 5;
                                }
                                else if (item.ToString() == "0")
                                {
                                    dokuman.barkodTurID = 0;
                                }
                            }
                        }

                        dokuman.Ad = taraf.AD;
                            dokuman.Taraflar.Add(taraf.CARI_ID.Value, taraf.TARAF_SIFAT_ID);

                        if (sablon.Tag != null)
                            dokuman.CiktiSayisi =
                                EditorAraclari.GetCiktiSayisiBySablonAndIcraFoy(
                                    (AvpNg.Editor.UserControls.ucSablonYazdirmaSecim.YazdirmaSayilari)sablon.Tag, foy);

                        var kalanFieldlar = txControl.TextFields.GetEnumerator();

                        List<TextField> fieldListesi = new List<TextField>();
                        while (kalanFieldlar.MoveNext())
                        {
                            fieldListesi.Add(kalanFieldlar.Current as TextField);
                        }

                        foreach (var field in fieldListesi)
                        {
                            switch (field.Text)
                            {
                                case "[İCRA] TEBLİGAT TARAF BAZINDA AD ADRES":
                                case "[ICRA] TEBLIGAT TARAF BAZINDA AD ADRES":
                                case "[ICRA] FOY TARAF BAZINDA AD ADRES (TAKIP EDEN)":
                                case "[ICRA] FOY TARAF BAZINDA AD ADRES (TAKIP EDILEN)":
                                case "[ICRA] FOY TUM TARAFLAR":
                                    field.Text =
                                        AvukatProDegiskenler.Icra.Degiskenler.GetFoyTarafBilgisi(taraf, true, false).
                                            Icerik;
                                    break;

                                case "[ICRA] FOY TARAF BAZINDA AD ADRES VEKILLI (TAKIP EDEN)":
                                case "[ICRA] FOY TARAF BAZINDA AD ADRES VEKILLI (TAKIP EDILEN)":
                                    field.Text =
                                        AvukatProDegiskenler.Icra.Degiskenler.GetFoyTarafBilgisi(taraf, true, true).
                                            Icerik;
                                    break;

                                case "[ICRA] FOY TARAF BORCLU VEKILLERI":
                                    field.Text =
                                        AvukatProDegiskenler.Icra.Degiskenler.GetFoyTarafBilgisi(taraf, false, true).
                                            Icerik;
                                    break;

                                case "[ICRA] FOY TARAF BAZINDA PTT BARKOD":
                                    field.Text = AvukatProDegiskenler.Icra.Degiskenler.GetPTTBarkodGetir(foy, (int)taraf.CARI_ID, BarkodTip, sablon);
                                    break;

                                default:
                                    break;
                            }
                        }

                        byte[] metin;
                        txControl.Save(out metin, BinaryStreamType.InternalFormat);

                        dokuman.Dokuman = metin;

                        tekrarlananlar.Add(dokuman);

                        #endregion
                    }
                    return tekrarlananlar;
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("TarafBazında Gruplama", ex);
                }

                return tekrarlananlar;
            }

            #endregion

            #region Yardımcı Methodlar

            #region Gruplu Depo Alacakları

            private static List<TextField> GetAracBilgisi(TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> aracListesi)
            {
                List<TextField> returnValue = new List<TextField>();

                for (int y = 0; y < aracListesi.Count; y++)
                {
                    if (aracListesi[y].ARAC_PLAKA.Length > 0)
                        EditorAraclari.InsertTextField(" Plaka : " + aracListesi[y].ARAC_PLAKA, aracListesi[y].ID,
                                                       "ARAC_PLAKA", returnValue, "AV001_TDI_BIL_GEMI_UCAK_ARAC");

                    if (aracListesi[y].ARAC_MODEL.Length > 0)
                        EditorAraclari.InsertTextField(", Model : " + aracListesi[y].ARAC_MODEL, aracListesi[y].ID,
                                                       "ARAC_MODEL", returnValue, "AV001_TDI_BIL_GEMI_UCAK_ARAC");

                    if (aracListesi[y].ADI.Length > 0)
                        EditorAraclari.InsertTextField(", Marka : " + aracListesi[y].ADI, aracListesi[y].ID,
                                                       "ARAC_MODEL", returnValue, "AV001_TDI_BIL_GEMI_UCAK_ARAC");

                    if (aracListesi[y].ARAC_TIP.Length > 0)
                        EditorAraclari.InsertTextField(", Tipi : " + aracListesi[y].ARAC_TIP, aracListesi[y].ID,
                                                       "ARAC_MODEL", returnValue, "AV001_TDI_BIL_GEMI_UCAK_ARAC");

                    if (aracListesi[y].ARAC_MOTOR_NO.Length > 0)
                        EditorAraclari.InsertTextField(", Motor No : " + aracListesi[y].ARAC_MOTOR_NO, aracListesi[y].ID,
                                                       "ARAC_MODEL", returnValue, "AV001_TDI_BIL_GEMI_UCAK_ARAC");

                    if (aracListesi[y].ARAC_SASI_NO.Length > 0)
                        EditorAraclari.InsertTextField(", Şasi No : " + aracListesi[y].ARAC_SASI_NO, aracListesi[y].ID,
                                                       "ARAC_MODEL", returnValue, "AV001_TDI_BIL_GEMI_UCAK_ARAC");

                    if (aracListesi[y].ARAC_SASI_NO.Length > 0)
                        EditorAraclari.InsertTextField(", Renk : " + aracListesi[y].ARAC_RENK, aracListesi[y].ID,
                                                       "ARAC_MODEL", returnValue, "AV001_TDI_BIL_GEMI_UCAK_ARAC");

                    if (aracListesi[y].RUHSAT_TARIHI.HasValue)
                        EditorAraclari.InsertTextField(
                            ", Ruhsat Tarihi : " +
                            EditorDataAraclari.Tools.TarihBicimlendirme(aracListesi[y].RUHSAT_TARIHI.Value),
                            aracListesi[y].ID, "ARAC_MODEL", returnValue, "AV001_TDI_BIL_GEMI_UCAK_ARAC");

                    EditorAraclari.InsertTextField(Environment.NewLine, aracListesi[y].ID, "yazi", returnValue, "yazi");
                }

                return returnValue;
            }

            private static string GetBanka(TDI_KOD_BANKA banka)
            {
                return banka.BANKA;
            }

            private static string GetBanka(int bankaId)
            {
                return
                    GetBanka(DataRepository.TDI_KOD_BANKAProvider.GetByID(bankaId));
            }

            private static string GetBankaSubesi(TDI_KOD_BANKA_SUBE sube)
            {
                return string.Format("{0}-{1}", GetBanka(sube.BANKA_ID), sube.SUBE);
            }

            private static string GetBelediye(TDI_KOD_BELEDIYE belediye)
            {
                return belediye.ADI;
            }

            private static string GetCariBilgileri(TList<AV001_TDI_BIL_CARI> cariListesi)
            {
                string sonuc = string.Empty;

                foreach (var cari in cariListesi)
                {
                    if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection.Count == 0)
                        DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(cari, false, DeepLoadType.IncludeChildren,
                                                                           typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));

                    sonuc += string.Format("Kimlik Bilgileri : {0}{1}", cari.AD, Environment.NewLine);

                    if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection.Count == 0)
                        continue;

                    sonuc += string.Format("T.C. No :{0} Baba Adı :{1} Ana Adı :{2} "
                                           , cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].TC_KIMLIK_NO
                                           , cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].BABA_ADI
                                           , cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].ANA_ADI);

                    if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_IL_IDSource != null)
                    {
                        sonuc += string.Format("İl : {0} "
                                               , cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_IL_IDSource.IL);
                    }
                    if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_ILCE_IDSource != null)
                    {
                        sonuc += string.Format("İlçe :{0}"
                                               , cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_ILCE_IDSource.ILCE);
                    }
                    if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_MAHALLE_KOY.Length > 0)
                        sonuc += string.Format(" Mahalle :{0} "
                                               , cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_MAHALLE_KOY);

                    if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_YERI.Length > 0)
                        sonuc += string.Format(" Doğum Yeri :{0} "
                                               , cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_YERI);

                    if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_TARIHI.HasValue)
                    {
                        sonuc += string.Format("Doğum Tarihi :{0} "
                                               ,
                                               cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_TARIHI.Value.
                                                   ToShortDateString());
                    }
                    if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_CILT_NO.Length > 0)
                        sonuc += string.Format("Cilt No :{0} "
                                               , cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_CILT_NO);

                    if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_AILE_SIRA_NO.Length > 0)
                        sonuc += string.Format("Aile Sıra No :{0}{1}"
                                               , cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_AILE_SIRA_NO
                                               , Environment.NewLine);

                    sonuc += Environment.NewLine;
                }
                return sonuc;
            }

            private static string GetCekBilgileri(TList<AV001_TDI_BIL_KIYMETLI_EVRAK> lstGayrimenkul)
            {
                string result = string.Empty;
                foreach (var cek in lstGayrimenkul)
                {
                    if (!cek.EVRAK_TUR_ID.HasValue && cek.EVRAK_TUR_ID.Value != 1)
                        continue;

                    if (cek.BANKA_IDSource != null)
                        DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(cek, false,
                                                                                     DeepLoadType.IncludeChildren,
                                                                                     typeof(TDI_KOD_BANKA));

                    if (cek.EVRAK_VADE_TARIHI.HasValue)
                        result += string.Format("Keşide Tarihi  : {0}\n",
                                                EditorDataAraclari.Tools.TarihBicimlendirme(cek.EVRAK_VADE_TARIHI.Value));
                    if (cek.BANKA_IDSource != null)
                        result += string.Format("Bankası/Şubesi : {0}-{1}\n", cek.BANKA_IDSource.BANKA,
                                                cek.SUBE_IDSource.SUBE);
                    if (cek.HESAP_NO.Length > 0)
                        result += string.Format("Hesap Numarası : {0}\n", cek.HESAP_NO);
                    if (cek.CEK_NO.Length > 0)
                        result += string.Format("Çek Numarası   : {0}\n", cek.CEK_NO);
                    if (cek.TUTAR != decimal.Zero)
                        result += string.Format("Tutarı         : {0}\n",
                                                new ParaVeDovizId(cek.TUTAR, cek.TUTAR_DOVIZ_ID).GetStringValue());
                }

                return result;
            }

            private static object GetGayrimenkulBilgileri(TList<AV001_TI_BIL_GAYRIMENKUL> lstGayriMenkuls)
            {
                List<TextField> returnValue = new List<TextField>();

                DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(lstGayriMenkuls, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE), typeof(TList<AV001_TDI_BIL_SOZLESME_DERECE>), typeof(TList<AV001_TDI_BIL_SOZLESME>));

                var list = lstGayriMenkuls.GroupBy(vi => vi.AV001_TDI_BIL_SOZLESMECollection_From_NN_SOZLESME_GAYRIMENKUL);

                var count = 0;
                foreach (var item in list)
                {
                    count++;
                    var gayrimenkul = item.FirstOrDefault();

                    #region CÜMLE DEĞİŞKENLERİ

                    string il = gayrimenkul.IL_IDSource != null ? gayrimenkul.IL_IDSource.IL : string.Empty;
                    string ilce = gayrimenkul.ILCE_IDSource != null ? gayrimenkul.ILCE_IDSource.ILCE
                                      : string.Empty;
                    string bucak = gayrimenkul.BUCAK;
                    string mahalle = gayrimenkul.MAHALLE_ADI;
                    string koy = gayrimenkul.KOY_ADI;
                    string mevki = gayrimenkul.MEVKI_ADI;
                    string ada = gayrimenkul.ADA_NO;
                    string pafta = gayrimenkul.PAFTA_NO;
                    string parsel = gayrimenkul.PARSEL_NO;
                    string arsaPayi = gayrimenkul.ARSA_PAYI;
                    string katNo = gayrimenkul.KAT_NO;
                    string bagimsizBolumNo = gayrimenkul.BAGIMSIZ_BOLUM_NO;
                    string niteligi = gayrimenkul.NITELIGI;
                    string derece = string.Empty;
                    string ipotekBedeli = string.Empty;

                    if (gayrimenkul.AV001_TDI_BIL_SOZLESME_DERECECollection.Count > 0)
                    {
                        var sDerece = gayrimenkul.AV001_TDI_BIL_SOZLESME_DERECECollection[0];
                        derece = sDerece.DERECESI;
                    }

                    AdimAdimDavaKaydi.Generalclass.SayiOkuma sa = new AdimAdimDavaKaydi.Generalclass.SayiOkuma();
                    ipotekBedeli = string.Format("{0} {1}", sa.ParaFormatla(item.Key.FirstOrDefault().BEDELI), BelgeUtil.Inits._DovizTipGetir.Find(vi => vi.ID == item.Key.FirstOrDefault().BEDELI_DOVIZ_ID).DOVIZ_KODU);

                    #endregion

                    #region Cümle

                    #region CÜMLE BAŞI

                    EditorAraclari.InsertTextField(count.ToString() + " - ", 0, "yazi", returnValue, "yazi"); //sıra numarası

                    #endregion

                    #region İL

                    if (il.Length > 0)
                    {
                        EditorAraclari.InsertTextField(il, gayrimenkul.IL_IDSource.ID, "IL", returnValue,
                                                       "TDI_KOD_IL");
                        EditorAraclari.InsertTextField(" İli, ", 0, "yazi", returnValue, "yazi");
                    }

                    #endregion

                    #region İLÇE

                    if (ilce.Length > 0)
                    {
                        EditorAraclari.InsertTextField(ilce, gayrimenkul.IL_IDSource.ID, "ILCE", returnValue,
                                                       "TDI_KOD_ILCE");
                        EditorAraclari.InsertTextField(" İlçesi, ", 0, "yazi", returnValue, "yazi");
                    }

                    #endregion

                    #region BUCAK

                    if (bucak.Length > 0)
                    {
                        EditorAraclari.InsertTextField(bucak, gayrimenkul.IL_IDSource.ID, "BUCAK", returnValue,
                                                       "TDI_KOD_TAPU_MUDURLUK");
                        EditorAraclari.InsertTextField(" Bucağı, ", 0, "yazi", returnValue, "yazi");
                    }

                    #endregion

                    #region MAHALLE

                    if (mahalle.Length > 0)
                    {
                        EditorAraclari.InsertTextField(mahalle, gayrimenkul.IL_IDSource.ID, "MAHALLE_ADI",
                                                       returnValue, "TDI_KOD_TAPU_MUDURLUK");
                        EditorAraclari.InsertTextField(" Mahallesi, ", 0, "yazi", returnValue, "yazi");
                    }

                    #endregion

                    #region KÖY

                    if (koy.Length > 0)
                    {
                        EditorAraclari.InsertTextField(koy, gayrimenkul.IL_IDSource.ID, "KOY_ADI", returnValue,
                                                       "TDI_KOD_TAPU_MUDURLUK");
                        EditorAraclari.InsertTextField(" Köyü, ", 0, "yazi", returnValue, "yazi");
                    }

                    //

                    #endregion

                    #region MEVKİ

                    if (mevki.Length > 0)
                    {
                        EditorAraclari.InsertTextField(mevki, gayrimenkul.ID, "MEVKI_ADI", returnValue,
                                                       "AV001_TI_BIL_GAYRIMENKUL");
                        EditorAraclari.InsertTextField(" Mevki, ", 0, "yazi", returnValue, "yazi");
                    }

                    #endregion

                    #region ADA

                    if (ada.Length > 0)
                    {
                        EditorAraclari.InsertTextField(ada, gayrimenkul.ID, "ADA_NO", returnValue,
                                                       "AV001_TI_BIL_GAYRIMENKUL");
                        EditorAraclari.InsertTextField(" Ada, ", 0, "yazi", returnValue, "yazi");
                    }

                    #endregion

                    #region PAFTA

                    if (pafta.Length > 0)
                    {
                        EditorAraclari.InsertTextField(pafta, gayrimenkul.ID, "PAFTA_NO", returnValue,
                                                       "AV001_TI_BIL_GAYRIMENKUL");
                        EditorAraclari.InsertTextField(" Pafta, ", 0, "yazi", returnValue, "yazi");
                    }

                    #endregion

                    #region PARSEL

                    if (parsel.Length > 0)
                    {
                        EditorAraclari.InsertTextField(parsel, gayrimenkul.ID, "PARSEL_NO", returnValue,
                                                       "AV001_TI_BIL_GAYRIMENKUL");
                        EditorAraclari.InsertTextField(" Parselde kayıtlı taşınmazın, ", 0, "yazi", returnValue, "yazi");
                    }

                    #endregion

                    #region ARSA PAYI

                    if (arsaPayi.Length > 0)
                    {
                        EditorAraclari.InsertTextField(arsaPayi, gayrimenkul.ID, "ARSA_PAYI", returnValue,
                                                       "AV001_TI_BIL_GAYRIMENKUL");
                        EditorAraclari.InsertTextField(" arsapaylı, ", 0, "yazi", returnValue, "yazi");
                    }

                    #endregion

                    #region KAT

                    if (katNo.Length > 0)
                    {
                        EditorAraclari.InsertTextField(katNo, gayrimenkul.ID, "KAT_NO", returnValue,
                                                       "AV001_TI_BIL_GAYRIMENKUL");
                        EditorAraclari.InsertTextField(" Kat,", 0, "yazi", returnValue, "yazi");
                    }

                    #endregion

                    #region BAĞIMSIZ NO

                    if (bagimsizBolumNo.Length > 0)
                    {
                        EditorAraclari.InsertTextField(bagimsizBolumNo, gayrimenkul.ID, "BAGIMSIZ_BOLUM_NO",
                                                       returnValue, "AV001_TI_BIL_GAYRIMENKUL");
                        EditorAraclari.InsertTextField(" Bağımsız Bölüm Nolu, ", 0, "yazi", returnValue, "yazi");
                    }

                    #endregion

                    #region NİTELİĞİ

                    if (niteligi.Length > 0)
                    {
                        EditorAraclari.InsertTextField(niteligi + ' ', gayrimenkul.ID, "NITELIGI", returnValue,
                                                       "AV001_TI_BIL_GAYRIMENKUL");

                        //EditorAraclari.InsertTextField("nitelikli", 0, "yazi", returnValue, "yazi");
                    }

                    #endregion

                    #endregion

                    #region Derece ve sıra bilgileri - İpotek Bedeli

                    EditorAraclari.InsertTextField(Environment.NewLine, 0, "yazi", returnValue, "yazi ");
                    if (derece.Length > 0)
                    {
                        EditorAraclari.InsertTextField("İpotek Derecesi : " + derece, 0, "yazi", returnValue, "yazi ");
                    }

                    EditorAraclari.InsertTextField(Environment.NewLine, 0, "yazi", returnValue, "yazi ");
                    EditorAraclari.InsertTextField("İpotek Bedeli : " + ipotekBedeli, 0, "yazi", returnValue, "yazi ");

                    #endregion

                    EditorAraclari.InsertTextField(Environment.NewLine, 0, "yazi", returnValue, "yazi ");
                }

                return returnValue;
            }

            /// <summary>
            /// [ICRA] GRUPLU GAYRINAKITLER
            /// </summary>
            /// <param name="neden"></param>
            /// <returns></returns>
            private static string GetGayriNakitAlacakNedenKod(AV001_TI_BIL_ALACAK_NEDEN neden)
            {
                if (neden.ALACAK_NEDEN_KOD_ID.HasValue)
                {
                    var nedenKod = DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(neden.ALACAK_NEDEN_KOD_ID.Value);
                    if (nedenKod != null)
                        return nedenKod.ALACAK_NEDENI;
                }

                return string.Empty;
            }

            /// <summary>
            /// [ICRA] GAYRINAKITE GRUPLU CEK YAPRAK SAYISI
            /// </summary>
            /// <param name="neden"></param>
            /// <returns></returns>
            private static string GetGayriNakitCekYapragiAdedi(AV001_TI_BIL_ALACAK_NEDEN neden)
            {
                return (neden.ADET ?? 0).ToString();
            }

            /// <summary>
            /// [ICRA] GAYRINAKITE GRUPLU DEPO SAYISI
            /// </summary>
            /// <param name="neden"></param>
            /// <returns></returns>
            private static string GetGayriNakitDepoSayisi(AV001_TI_BIL_ALACAK_NEDEN neden)
            {
                return (neden.DEPO_SAYISI ?? 0).ToString();
            }

            /// <summary>
            /// [ICRA] GAYRINAKITE GRUPLU DEPO TARIHI
            /// </summary>
            /// <param name="neden"></param>
            /// <returns></returns>
            private static string GetGayriNakitDepoTarihi(AV001_TI_BIL_ALACAK_NEDEN neden)
            {
                return EditorDataAraclari.Tools.TarihBicimlendirme(neden.DEPO_TARIHI);
            }

            /// <summary>
            /// [ICRA] GAYRINAKITE GRUPLU DUZENLENME TARIHI
            /// </summary>
            /// <param name="neden"></param>
            /// <returns></returns>
            private static string GetGayriNakitDuzenlemeTarihi(AV001_TI_BIL_ALACAK_NEDEN neden)
            {
                if (neden.DUZENLENME_TARIHI.HasValue)
                    return EditorDataAraclari.Tools.TarihBicimlendirme(neden.DUZENLENME_TARIHI.Value);

                return string.Empty;
            }

            /// <summary>
            /// [ICRA] GAYRINAKITE GRUPLI FAIZ ORANI
            /// </summary>
            /// <param name="neden"></param>
            /// <returns></returns>
            private static string GetGayriNakitFaizOrani(AV001_TI_BIL_ALACAK_NEDEN neden)
            {
                return "%" + neden.TO_UYGULANACAK_FAIZ_ORANI;
            }

            /// <summary>
            /// [ICRA] GAYRINAKITE GRUPLU IADE SAYISI
            /// </summary>
            /// <param name="neden"></param>
            /// <returns></returns>
            private static string GetGayriNakitIadeSayisi(AV001_TI_BIL_ALACAK_NEDEN neden)
            {
                return (neden.IADE_SAYISI ?? 0).ToString();
            }

            /// <summary>
            /// [ICRA] GAYRINAKITE GRUPLU IADE TARIHI
            /// </summary>
            /// <param name="neden"></param>
            /// <returns></returns>
            private static string GetGayriNakitIadeTarihi(AV001_TI_BIL_ALACAK_NEDEN neden)
            {
                return EditorDataAraclari.Tools.TarihBicimlendirme(neden.IADE_TARIHI);
            }

            /// <summary>
            /// [ICRA] GAYRINAKITE GRUPLU ISLEME KONAN TUTAR
            /// </summary>
            /// <param name="neden"></param>
            /// <returns></returns>
            private static string GetGayriNakitIslemeKonanTutari(AV001_TI_BIL_ALACAK_NEDEN neden)
            {
                return new ParaVeDovizId(neden.ISLEME_KONAN_TUTAR, neden.ISLEME_KONAN_TUTAR_DOVIZ_ID).GetStringValue();
            }

            /// <summary>
            /// [ICRA] GAYRINAKITE GRUPLU MUHATTAP
            /// </summary>
            /// <param name="neden"></param>
            /// <returns></returns>
            private static string GetGayriNakitMuhattap(AV001_TI_BIL_ALACAK_NEDEN neden)
            {
                return HesapAraclari.Icra.CariAdiGetirByCariId(neden.TEMINAT_MEKTUP_MUHATAP_CARI_ID);
            }

            /// <summary>
            /// [ICRA] GAYRINAKITE GRUPLU REFERANS NO
            /// </summary>
            /// <param name="neden"></param>
            /// <returns></returns>
            private static string GetGayriNakitReferansNo(AV001_TI_BIL_ALACAK_NEDEN neden)
            {
                return neden.REFERANS_NO;
            }

            /// <summary>
            /// [ICRA] GAYRINAKITE GRUPLU TAZMIN TARIHI
            /// </summary>
            /// <param name="neden"></param>
            /// <returns></returns>
            private static string GetGayriNakitTazminTarihi(AV001_TI_BIL_ALACAK_NEDEN neden)
            {
                if (neden.VADE_TARIHI.HasValue)
                    return EditorDataAraclari.Tools.TarihBicimlendirme(neden.VADE_TARIHI.Value);

                return string.Empty;
            }

            /// <summary>
            /// [ICRA] GAYRINAKITE GRUPLU TAZMIN TUTARI
            /// </summary>
            /// <param name="neden"></param>
            /// <returns></returns>
            private static string GetGayriNakitTazminTutari(AV001_TI_BIL_ALACAK_NEDEN neden)
            {
                return new ParaVeDovizId(neden.TAZMIN_MIKTARI, neden.TAZMIN_MIKTAR_DOVIZ_ID).GetStringValue();
            }

            /// <summary>
            /// [ICRA] GAYRINAKITE GRUPLU TUTARI
            /// </summary>
            /// <param name="neden"></param>
            /// <returns></returns>
            private static string GetGayriNakitTutari(AV001_TI_BIL_ALACAK_NEDEN neden)
            {
                return new ParaVeDovizId(neden.TUTARI, neden.TUTAR_DOVIZ_ID).GetStringValue();
            }

            #endregion

            private static string GetHacizTarihVeSaati(AV001_TI_BIL_HACIZ_MASTER haciz)
            {
                return haciz.HACIZ_TARIHI.ToString();
            }

            private static string GetNufusMudurlugu(TDI_KOD_IL il)
            {
                return il.IL;
            }

            private static string GetNufusMudurluguIlce(TDI_KOD_ILCE ilce)
            {
                return ilce.ILCE;
            }

            private static string GetTapuMudurlugu(TDI_KOD_TAPU_MUDURLUK tapuMudurlugu)
            {
                return tapuMudurlugu.ADI;
            }

            private static string GetTebligatMuhattapBilgisi(AV001_TDI_BIL_TEBLIGAT_MUHATAP muhattap, bool adresGelsin)
            {
                string result = string.Empty;

                if (muhattap.CARI_ALT_ID.HasValue)
                {
                    var altCari = DataRepository.AV001_TDI_BIL_CARI_ALTProvider.GetByID(muhattap.CARI_ALT_ID.Value);

                    result += altCari.AD;
                    result += string.Empty;

                    if (adresGelsin)
                    {
                        result += Environment.NewLine;

                        result += string.Format("{0} {1} {2}"
                                                , altCari.ADRES_1
                                                , altCari.ADRES_2
                                                , altCari.ADRES_3);
                        result += Environment.NewLine;

                        if (altCari.ADRES_SEMT_ID.HasValue)
                            result += string.Format(@" {0} ",
                                                    EditorDataAraclari.Kodlar.GetSemtAdi(altCari.ADRES_SEMT_ID.Value));
                        if (altCari.ILCE_ID.HasValue)
                            result += string.Format(@" {0} ",
                                                    EditorDataAraclari.Kodlar.GetIlceAdi(altCari.ILCE_ID.Value));
                        if (altCari.IL_ID.HasValue)
                            result += string.Format(@" {0} ", EditorDataAraclari.Kodlar.GetIlAdi(altCari.IL_ID.Value));
                    }
                }
                else
                {
                    var cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(muhattap.MUHATAP_CARI_ID);

                    result += cari.AD;

                    if (adresGelsin)
                    {
                        result += string.Format("{0} {1} {2}"
                                                , cari.Aktif_ADRES1
                                                , cari.Aktif_ADRES2
                                                , cari.Aktif_ADRES3);
                        result += Environment.NewLine;

                        //todo : Semt içinde aktif adres kontrolü yapılacak
                        //if (cari.ADRES_SEMT_ID.HasValue)
                        //    result += string.Format(@" {0} ", EditorDataAraclari.Kodlar.GetSemtAdi(altCari.ADRES_SEMT_ID.Value));
                        if (cari.Aktif_ILCE_ID.HasValue)
                            result += string.Format(@" {0} ",
                                                    EditorDataAraclari.Kodlar.GetIlceAdi(cari.Aktif_ILCE_ID.Value));
                        if (cari.Aktif_IL_ID.HasValue)
                            result += string.Format(@" {0} ", EditorDataAraclari.Kodlar.GetIlAdi(cari.Aktif_IL_ID.Value));
                    }
                }

                return result;
            }

            private static string GetTebligatMuhattapTebligTarihi(AV001_TDI_BIL_TEBLIGAT_MUHATAP muhattap,
                                                                  TebligatKonu konu)
            {
                DateTime? tarih = null;
                if (konu == TebligatKonu.HI_89_2 || konu == TebligatKonu.HI_89_3)
                {
                    if (muhattap.CARI_ALT_ID.HasValue)
                    {
                        tarih = EditorDataAraclari.Icra.GetTebligTarihiByFoyAndKonuAndCariAltId(
                            muhattap.ICRA_FOY_ID.Value,
                            konu == TebligatKonu.HI_89_2 ? TebligatKonu.HI_89_1 : TebligatKonu.HI_89_2,
                            muhattap.CARI_ALT_ID.Value);
                    }
                    else
                    {
                        tarih = EditorDataAraclari.Icra.GetTebligTarihiByFoyAndKonuAndCariId(
                            muhattap.ICRA_FOY_ID.Value,
                            konu == TebligatKonu.HI_89_2 ? TebligatKonu.HI_89_1 : TebligatKonu.HI_89_2,
                            muhattap.MUHATAP_CARI_ID);
                    }
                }

                if (tarih == null)
                    return string.Empty;

                return EditorDataAraclari.Tools.TarihBicimlendirme(tarih.Value);
            }

            private static void SetFieldValue(TextField field, object result)
            {
                if (result is string)
                {
                    if (result.ToString() != string.Empty)
                        field.Text = result.ToString();
                }
                else if (result is List<TextField>)
                {
                    var sonucFieldler = result as List<TextField>;
                    field.Text = string.Empty;
                    foreach (var teki in sonucFieldler)
                    {
                        field.Text += teki.Text;
                        field.Text += " ";
                    }
                }
            }

            #region Enums

            #endregion

            #endregion
        }
    }
}