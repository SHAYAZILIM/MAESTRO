using AdimAdimDavaKaydi.Editor.Forms;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge;
using AvukatProLib2.Entities;
using Datas.TablesColumn;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TXTextControl;

namespace AvukatProDegiskenler.Util
{
    public static class DegiskenHelper
    {
        public static List<SeciliKayit> SelectedRecords = new List<SeciliKayit>();

        public static void AddToSeciliKayitlar(IEntity Record)
        {
            if (SelectedRecords == null)
            {
                SelectedRecords = new List<SeciliKayit>();
            }
            SeciliKayit kayit = new SeciliKayit();
            kayit.Kayit = Record;
            kayit.Id = (int)TablesColumnData.GetColumnValueByNameFromRecord(Record, "ID").Value;
            kayit.Modul = GetRecordsModul(Record);
            kayit.Degisken = new AV001_TDIE_BIL_SABLON_DEGISKENLER();

            SeciliKayit EskiKayit = GetSelectedKayitByModul(kayit.Modul);
            if (EskiKayit != null)
            {
                SelectedRecords.Remove(EskiKayit);
            }
            SelectedRecords.Add(kayit);
        }

        public static AV001_TDIE_BIL_SABLON_DEGISKENLER GetDegiskenByAd(string adi)
        {
            if (adi == "BorcluIsmi")
            {
                adi = "IcraBorcluIsmi";
            }
            return AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_DEGISKENLERProvider.GetByAD(adi);
        }

        public static SeciliKayit GetSelectedKayitByModul(int modul)
        {
            if (SelectedRecords == null) return null;
            for (int i = 0; i < SelectedRecords.Count; i++)
            {
                if (SelectedRecords[i].Modul == modul)
                {
                    return SelectedRecords[i];
                }
            }
            return null;
        }

        /// <summary>
        /// av001__tdýe_býl_sablon_degýskenler içerisine buradaki case de tan9ýmlý her adým bir degisken olarak tanýmlanýr
        /// modul , ad, gorunen ad, gibib bilgileri girilir. Deðiþkenlerin geri dönüþ degeri DegiskenDegeri tipindendir.
        ///
        ///
        /// </summary>
        /// <param name="degisken"></param>
        /// <param name="sender"></param>
        /// <param name="senderParent"></param>
        /// <returns></returns>
        public static object GetValue(AV001_TDIE_BIL_SABLON_DEGISKENLER degisken, uctxEditor sender,
                                      frmEditor senderParent)
        {
            // return null;

            if (SelectedRecords == null)
            {
                SetRecords(degisken);
            }

            IEntity Record = null;
            SeciliKayit SelRecord = GetSelectedKayitByModul(degisken.MODUL_ID);
            if (SelRecord != null)
            {
                Record = SelRecord.Kayit;
            }

            if (Record == null)
            {
                return string.Empty;
            }

            //   AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad((AV001_TI_BIL_FOY)crt.Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));

            object returnValue = "";

            switch (degisken.AD)
            {
                //case "DavaDAVA_EDENCariBilgisi":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, true, null, true);
                //    break;

                //case "IcraBORCLU_MIRASCI":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, true, 6, true);
                //    break;

                //case "DavaDAVA_EDÝLENCariBilgisi":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, false, null, true);
                //    break;

                //case "IcraTAKÝP_EDENCariBilgisi":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, true, null, true);
                //    break;

                //case "IcraTAKÝP_EDÝLENCariBilgisi":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, false, null, false);
                //    break;

                //case "SozlesmeDAVA_EDENCariBilgisi":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, true, null, true);
                //    break;

                //case "SozlesmeDAVA_EDÝLENCariBilgisi":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, false, null, true);
                //    break;

                //case "HazirlikDAVA_EDENCariBilgisi":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, true, null, true);
                //    break;

                //case "HazirlikDAVA_EDÝLENCariBilgisi":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, false, null, true);
                //    break;

                //case "RucuRÜCU_EDENCariBilgisi":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, true, null, true);
                //    break;

                //case "RucuRÜCU_EDÝLENCariBilgisi":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, false, null, true);
                //    break;
                //case "DavaDAVA_KONUSU":
                //    returnValue = Degiskenler.GetDavaKonusu(((AV001_TD_BIL_FOY)Record).ID);
                //    break;

                //case "DavaCEZA_DAVA_KONUSU":
                //    returnValue = Degiskenler.GetDavaCezaKonusu(((AV001_TD_BIL_FOY)Record).ID);
                //    break;

                //case "DavaIDARE_DAVA_KONUSU":
                //    returnValue = Degiskenler.GetDavaIdareKonusu(((AV001_TD_BIL_FOY)Record).ID);
                //    break;

                //case "DavaHUKUKSAL_NEDENLER":
                //    returnValue = Degiskenler.GetHukuksalNedenler(((AV001_TD_BIL_FOY)Record).ID);
                //    break;

                //case "IcraTAKIP_TALEBI":
                //    returnValue = Degiskenler.GetIcraTakipTalebiFromNesne(((AV001_TI_BIL_FOY)Record));
                //    break;

                //case "IcraEsasNo":
                //    returnValue = Degiskenler.GetfoyBilgisiFromNesne((AV001_TI_BIL_FOY)Record, "ESAS_NO");
                //    break;

                //case "IcraOrnekForm":
                //    returnValue = Degiskenler.GetFormOrnekAciklamaFromNesne(((AV001_TI_BIL_FOY)Record));
                //    break;

                //case "IcraAlacakNedenKodu":
                //    returnValue = Degiskenler.GetIcraKodAlacakNedeniFromNesne(((AV001_TI_BIL_FOY)Record));
                //    break;

                //case "IcraIcraMudurlugu":
                //    returnValue = Degiskenler.GetIcrmBilgisiFromNesne((AV001_TI_BIL_FOY)Record);
                //    break;

                //case "IcraTakipTarihi":
                //    returnValue = Degiskenler.GetfoyTakipTarihiFromNesne((AV001_TI_BIL_FOY)Record);
                //    break;

                //case "IcraTakipYolu":
                //    returnValue = Degiskenler.GetTakipYoluFromNesne(((AV001_TI_BIL_FOY)Record));
                //    break;

                //case "IcraAlacakNedeni":
                //    returnValue = Degiskenler.GetIcraAlacakNedeniFromNesne((AV001_TI_BIL_FOY)Record);
                //    break;

                //case "IcraKiraAlacakNeden":
                //    returnValue = Degiskenler.GetIcraKiraAlacakNedeniFromNesne((AV001_TI_BIL_FOY)Record);
                //    break;

                //case "IcraIlamBilgisi":
                //    returnValue = Degiskenler.GetIcraIlamBilgisiFromNesne((AV001_TI_BIL_FOY)Record);
                //    break;

                //case "IcraOrnek14TahliyeTalebi":
                //    returnValue = Degiskenler.GetOrnek14TahliyeTalebiFromNesne((AV001_TI_BIL_FOY)Record);
                //    break;

                //case "IcraHesaplanmisDegerler":
                //    returnValue = Degiskenler.GetHesaplanmisDegerlerFromNesne(((AV001_TI_BIL_FOY)Record), sender.textControl1, "", "");
                //    break;

                //case "IcraHesaplanmisDegerVeAciklamasý":
                //    Degiskenler.GetIcraHesapsWithAciklamaFromNesne((AV001_TI_BIL_FOY)Record, sender.textControl1);
                //    break;

                //case "IcraSorumluAvukat":
                //    returnValue = Degiskenler.GetIcraSorumluAvukat(((AV001_TI_BIL_FOY)Record), sender.textControl1, false);
                //    break;

                //case "SatisBilgisi":
                //    returnValue = Degiskenler.GetSatisBilgisi(((AV001_TI_BIL_FOY)Record), sender.textControl1, sender.textControl1.Selection.Start);
                //    break;

                //case "HacizBilgisi":
                //    returnValue = Degiskenler.GetHacizBilgisi(((AV001_TI_BIL_FOY)Record), sender.textControl1, sender.textControl1.Selection.Start);
                //    break;

                //case "GayrimenkulBilgisi":
                //    returnValue = Degiskenler.GetGayrimenkulIpotekBilgisi((AV001_TI_BIL_FOY)Record);
                //    break;

                //case "CariKimlikBilgisi":
                //    Degiskenler.GetIcraTarafCariKimlikBilgisi(Record, sender.textControl1, false, null, null);
                //    break;

                //case "HacizMahkemeBilgisi":
                //    returnValue = Degiskenler.GetHacizMahkeme(((AV001_TI_BIL_FOY)Record), sender.textControl1, sender.textControl1.Selection.Start);
                //    break;

                //case "SatisMahkemeBilgisi":
                //    returnValue = Degiskenler.GetHacizMahkeme(((AV001_TI_BIL_FOY)Record), sender.textControl1, sender.textControl1.Selection.Start);
                //    break;

                //case "IcraBorcluVekilsiz":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, false, null, false);
                //    break;

                //case "IcraAlacakliVekilsiz":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, true, null, false);
                //    break;

                //case "IcraBORCLU_MIRASCIVekilsiz":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, false, 6, false);
                //    break;

                //case "DavaDAVA_EDÝLENCariBilgisiVekilsiz":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, false, null, false);
                //    break;

                //case "DavaDAVA_EDENCariBilgisiVekilsiz":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, true, null, false);
                //    break;

                //case "IcraTAKÝP_EDENCariBilgisiVekilsiz":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, true, null, false);
                //    break;

                //case "IcraTAKÝP_EDÝLENCariBilgisiVekilsiz":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, false, null, false);
                //    break;

                //case "SozlesmeDAVA_EDENCariBilgisiVekilsiz":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, true, null, false);
                //    break;

                //case "SozlesmeDAVA_EDÝLENCariBilgisiVekilsiz":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, false, null, false);
                //    break;

                //case "HazirlikDAVA_EDENCariBilgisiVekilsiz":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, true, null, false);
                //    break;

                //case "HazirlikDAVA_EDÝLENCariBilgisiVekilsiz":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, false, null, false);
                //    break;

                //case "RucuRÜCU_EDENCariBilgisiVekilsiz":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, true, null, false);
                //    break;

                //case "RucuRÜCU_EDÝLENCariBilgisiVekilsiz":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, false, null, false);
                //    break;

                //case "Sozlesme_Sozlesme_Bilgisi":
                //    returnValue = Degiskenler.getSozlesmeBilgisi((AV001_TI_BIL_FOY)Record, sender.textControl1, sender.textControl1.Selection.Start);
                //    break;

                //case "DovizliAlacakTakipTarihindeYtl":
                //    returnValue = Degiskenler.DovizliAlacakTakipTarihindeYtl(((AV001_TI_BIL_FOY)Record).ID, sender.textControl1, sender.textControl1.Selection.Start);
                //    break;

                //case "BuGun":
                //    returnValue = Degiskenler.GetBugun();
                //    break;

                //case "BuKullanici":
                //    returnValue = Degiskenler.GetCurrentUser();
                //    break;
                //case "BuSaat":
                //    returnValue = Degiskenler.GetBuSaat();
                //    break;
                //case "KayýtTarihi":
                //    returnValue = Degiskenler.GetKayitTarihi((IEntity)Record);
                //    break;
                //case "KayitSaati":
                //    returnValue = Degiskenler.GetKayitSaati((IEntity)Record);
                //    break;

                //case "KaydiYapanKullanici":
                //    returnValue = Degiskenler.GetKayitEden((IEntity)Record);
                //    break;

                //case "Sube":
                //    returnValue = Degiskenler.GetSube((IEntity)Record);
                //    break;

                //case "RehinBorclusu":
                //    returnValue = Degiskenler.TarafBilgisiGetir(degisken, Record, sender, false, 6, true);
                //    break;

                //case "IcraIstirakIstenenBilgisi":
                //    returnValue = Degiskenler.IcraIstirakIstenenBilgisi((AV001_TI_BIL_FOY)Record);
                //    break;
                //case "IcraIstirakIsteyenBilgisi":
                //    returnValue = Degiskenler.IcraIstirakIstenenBilgisi((AV001_TI_BIL_FOY)Record);
                //    break;
                //case "IcraHacizUcuncuSahisBilgisi":
                //    returnValue = Degiskenler.IcraHacizUcuncuSahisBilgisi((AV001_TI_BIL_FOY)Record);
                //    break;
                //case "IcraAlacakliVekilBilgisi":
                //    returnValue = Degiskenler.IcraAlacakliVekilBilgisi((AV001_TI_BIL_FOY)Record);
                //    break;
                //case "IcraTebligatMuhattabTebligtarihi":
                //    returnValue = Degiskenler.IcraTebligatMuhattabTebligtarihi((AV001_TI_BIL_FOY)Record);
                //    break;
                //case "IcraIstihkakEdenBilgisi":
                //    returnValue = Degiskenler.IcraIstihkakEdenBilgisi((AV001_TI_BIL_FOY)Record);
                //    break;
                //case "Temsilbilgisi":
                //    returnValue = Degiskenler.GetTemsilBilgisi((AV001_TI_BIL_FOY)Record, TemsilBilgileri.Tumu, sender, sender.Parentform);
                //    break;
                //case "TemsilNoterBilgisi":
                //    returnValue = Degiskenler.GetTemsilBilgisi((AV001_TI_BIL_FOY)Record, TemsilBilgileri.Noter, sender, sender.Parentform);
                //    break;
                //case "TemsilYetkibilgisi":
                //    returnValue = Degiskenler.GetTemsilBilgisi((AV001_TI_BIL_FOY)Record, TemsilBilgileri.Yetki, sender, sender.Parentform);
                //    break;
                //case "TemsilYevmiyeBilgisi":
                //    returnValue = Degiskenler.GetTemsilBilgisi((AV001_TI_BIL_FOY)Record, TemsilBilgileri.Yevmiye, sender, sender.Parentform);
                //    break;
                //case "IcraHarcDetayi":
                //    returnValue = Degiskenler.GetHarcDetayi((AV001_TI_BIL_FOY)Record, sender.textControl1);
                //    break;
                //case "IcraFoyNo":
                //    returnValue = Degiskenler.GetFoyNo((AV001_TI_BIL_FOY)Record);
                //    break;
                //case "IcraTakipOncesiOdeme":
                //    returnValue = Degiskenler.GetTakipOncesiOdeme((AV001_TI_BIL_FOY)Record);
                //    break;
                //case "IcraPostaPuluDegeri":
                //    returnValue = Degiskenler.GetIcraPostaPulu((AV001_TI_BIL_FOY)Record);
                //    break;
                //case "IcraTakipEdilenKiraTahliyeTarihi":
                //    returnValue = Degiskenler.GetIcraKiraTahliyeTarihi((AV001_TI_BIL_FOY)Record);
                //    break;
                //case "IcraTakipEdilenAsilAlacak":
                //    returnValue = Degiskenler.GetIcraAsýlAlacak((AV001_TI_BIL_FOY)Record);
                //    break;
                //case "IcraAlacakliBabaAdi":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("BABA_ADI", " Baba Adi : ", (AV001_TI_BIL_FOY)Record, false);
                //    break;
                //case "IcraAlacakliAnaAdi":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("ANA_ADI", " Ana Adi : ", (AV001_TI_BIL_FOY)Record, false);
                //    break;
                //case "IcraAlacakliDogunYeri":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("DOGUM_YERI", " Doðum Yeri : ", (AV001_TI_BIL_FOY)Record, false);
                //    break;
                //case "IcraAlacakliDogunYili":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("DOGUM_TARIHI", " Baba Adi : ", (AV001_TI_BIL_FOY)Record, false);
                //    break;
                //case "IcraAlacakliTcKimlikNo":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("TC_KIMLIK_NO", " TC Kimlik No : ", (AV001_TI_BIL_FOY)Record, false);
                //    break;
                //case "IcraAlacakliCinsiyet":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("CINSIYET", " Cinsiyet : ", (AV001_TI_BIL_FOY)Record, false);
                //    break;
                //case "IcraAlacakliMedeniHali":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("MEDENI_HAL", " Medeni Hali : ", (AV001_TI_BIL_FOY)Record, false);
                //    break;
                //case "IcraAlacakliMahalleKoy":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("NKO_MAHALLE_KOY", " Kayitli Olduðu Mahalle/Köy : ", (AV001_TI_BIL_FOY)Record, false);
                //    break;
                //case "IcraAlacakliCiltNo":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("NKO_CILT_NO", " Cilt No : ", (AV001_TI_BIL_FOY)Record, false);
                //    break;
                //case "IcraAlacakliAileSiraNo":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("NKO_AILE_SIRA_NO", " Aile Sýra No : ", (AV001_TI_BIL_FOY)Record, false);
                //    break;
                //case "IcraAlacakliBelgeNoNo":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("BELGE_NO", " Belge No : ", (AV001_TI_BIL_FOY)Record, false);
                //    break;
                //case "IcraAlacakliDini":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("DINI", " Dini : ", (AV001_TI_BIL_FOY)Record, false);
                //    break;
                //case "IcraAlacakliKanGrubu":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("KAN_GRUP", " Kan Grubu : ", (AV001_TI_BIL_FOY)Record, false);
                //    break;
                //case "IcraBorcluBabaAdi":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("BABA_ADI", " Baba Adi : ", (AV001_TI_BIL_FOY)Record, true);
                //    break;
                //case "IcraBorcluAnaAdi":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("ANA_ADI", " Ana Adi : ", (AV001_TI_BIL_FOY)Record, true);
                //    break;
                //case "IcraBorcluDogunYeri":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("DOGUM_YERI", " Doðum Yeri : ", (AV001_TI_BIL_FOY)Record, true);
                //    break;
                //case "IcraBorcluDogunYili":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("DOGUM_TARIHI", " Baba Adi : ", (AV001_TI_BIL_FOY)Record, true);
                //    break;
                //case "IcraBorcluTcKimlikNo":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("TC_KIMLIK_NO", " TC Kimlik No : ", (AV001_TI_BIL_FOY)Record, true);
                //    break;
                //case "IcraBorcluCinsiyet":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("CINSIYET", " Cinsiyet : ", (AV001_TI_BIL_FOY)Record, true);
                //    break;
                //case "IcraBorcluMedeniHali":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("MEDENI_HAL", " Medeni Hali : ", (AV001_TI_BIL_FOY)Record, true);
                //    break;
                //case "IcraBorcluMahalleKoy":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("NKO_MAHALLE_KOY", " Kayitli Olduðu Mahalle/Köy : ", (AV001_TI_BIL_FOY)Record, true);
                //    break;
                //case "IcraBorcluCiltNo":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("NKO_CILT_NO", " Cilt No : ", (AV001_TI_BIL_FOY)Record, true);
                //    break;
                //case "IcraBorcluAileSiraNo":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("NKO_AILE_SIRA_NO", " Aile Sýra No : ", (AV001_TI_BIL_FOY)Record, true);
                //    break;
                //case "IcraBorcluBelgeNoNo":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("BELGE_NO", " Belge No : ", (AV001_TI_BIL_FOY)Record, true);
                //    break;
                //case "IcraBorcluDini":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("DINI", " Dini : ", (AV001_TI_BIL_FOY)Record, true);
                //    break;
                //case "IcraBorcluKanGrubu":
                //    returnValue = Degiskenler.GetFromCariKimlikBilgisi("KAN_GRUP", " Kan Grubu : ", (AV001_TI_BIL_FOY)Record, true);
                //    break;
                //case "IcraAlacakliIsmi":
                //    returnValue = Degiskenler.GetAllTarafsValues((AV001_TI_BIL_FOY)Record, "AD", true, false);
                //    break;
                //case "IcraBorcluIsmi":
                //    returnValue = Degiskenler.GetAllTarafsValues((AV001_TI_BIL_FOY)Record, "AD", false, false);
                //    break;
                //case "IcraBorcluAvukatAdi":
                //    returnValue = Degiskenler.GetAllTarafsValues((AV001_TI_BIL_FOY)Record, "AD", false, true);
                //    break;
                //case "IcraAlacakliAvukatAdi":
                //    returnValue = Degiskenler.GetAllTarafsValues((AV001_TI_BIL_FOY)Record, "AD", true, true);
                //    break;

                //case "IcraBorcluVekilBilgisi":
                //  //  returnValue = Degiskenler.GetBorcluVekilBilgisi((AV001_TI_BIL_FOY)crt.Record);
                //    break;
                //case "IcraGayrimenkulGenelBilgileri":
                //    Degiskenler.GetGayrimenkulGenelBilgileri((AV001_TI_BIL_FOY)Record, sender.textControl1, 1, true);
                //    returnValue = "";
                //    break;
                //case "IcraBirinciHacizIhbarnameTarihi":
                //    returnValue = Degiskenler.GetHacizIhbarnameTarihi((AV001_TI_BIL_FOY)Record, TebligatTuru.SeksenDokuzaBir,sender);
                //    break;
                //case "IcraIkinciHacizIhbarnameTarihi":
                //    returnValue = Degiskenler.GetHacizIhbarnameTarihi((AV001_TI_BIL_FOY)Record, TebligatTuru.SeksenDokuzaIki, sender);
                //    break;
                //case "IcraUcuncuHacizIhbarnameTarihi":
                //    returnValue = Degiskenler.GetHacizIhbarnameTarihi((AV001_TI_BIL_FOY)Record, TebligatTuru.SeksenDokuzaUc, sender);
                //    break;
                //case "Icra_Sozlesme_Bilgisi":
                //    returnValue = Degiskenler.getIcraSozlesmeBilgisi((AV001_TI_BIL_FOY)Record,  sender.textControl1);
                //    break;
                //case "Icra_Arac_Bilgisi":
                //    returnValue = Degiskenler.GetAracBilgisi((AV001_TI_BIL_FOY)Record);
                //    break;
                //case "IcraFormOrnekNumarasi":
                //    return Degiskenler.GetFormOrnekNumarasi((AV001_TI_BIL_FOY)Record);
                //    break;
                //case "Icra_Haciz_Ihbarnamesi_Borclu_Bilgisi":
                //    return Degiskenler.GetHacizIhbarnamesiBorcluBilgisi((AV001_TI_BIL_FOY)Record);
                //    break;
                //case "Icra_Ucuncu_Sahislar":
                //    return Degiskenler.GetHacizIhbarnamesiUcuncuSahis((AV001_TI_BIL_FOY)Record, sender.TebligatMuhatab);
                //    break;
                //case "Icra_TEbligat_Listesi":
                //    return Degiskenler.GetTebligatListesi((AV001_TI_BIL_FOY)Record, sender);
                //    break;
                //case "Icra_Depo_Alacagi_Tablolu":
                //    return Degiskenler.GetDepoAlacagi((AV001_TI_BIL_FOY)Record);
                //    break;
                //case "Icra_Depo_Alacagi":
                //    return Degiskenler.GetDepoAlacagiString((AV001_TI_BIL_FOY)Record);
                //    break;
                //case "Icra_Borclu_Il":
                //    //TODO : Cari Ýlce
                //   // return Degiskenler.GetCariIlIlce((AV001_TI_BIL_FOY)crt.Record, degisken, true, false);
                //    break;
                //case "Icra_Borclu_Ilce":
                //    //TODO : Cari Ýlce
                //  //  return Degiskenler.GetCariIlIlce((AV001_TI_BIL_FOY)crt.Record, Degiskenler.DegiskenAdlari.Icra_Borclu_Il, true, false);
                //    break;
                //case "Icra_borclu_Il_Ilce":
                //    return Degiskenler.GetFromCariBilgileri((AV001_TI_BIL_FOY)Record, true, "IL", ",",degisken, "AD");
                //    break;
                //case "Icra_Takip_Cikisi":
                //    return Degiskenler.GetIcraFoyFieldValues(((AV001_TI_BIL_FOY)Record), "TAKIP_CIKISI", degisken, "TAKIP_CIKISI");
                //    break;
                //case "Icra_Odeme_Emri":
                //    return Degiskenler.GetIcraFoyFieldValues(((AV001_TI_BIL_FOY)Record), "TO_ODEME_TOPLAMI",degisken, "TO_ODEME_TOPLAMI");
                //    break;
                //case "Icra_Toplam_Tutar":
                //    return Degiskenler.GetIcraKalanTutar((AV001_TI_BIL_FOY)Record);
                //    break;
                //case "Icra_Rehin_Limiti_Aciklamasi":
                //    return Degiskenler.GetIpotekliAciklama(((AV001_TI_BIL_FOY)Record));
                //    break;
                //case "Icra_Borclu_Nufus_Bilgisi":
                //    return Degiskenler.GetNufusBilgiliTaraf(((AV001_TI_BIL_FOY)Record), true, degisken);
                //    break;
                //case "Icra_Alacakli_Nufus_Bilgisi":
                //    return Degiskenler.GetNufusBilgiliTaraf(((AV001_TI_BIL_FOY)Record), false, degisken);
                //    break;

                //case "Icra_Borclu_Vergi_Dairesi":
                //    return Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), degisken, "VERGI_DAIRESI", sender);
                //    break;
                //case "Icra_Borclu_Vergi_No":
                //    return Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), degisken, "VERGI_NO", sender);
                //    break;
                ////case "Icra_Borclu_Il":
                ////    return Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)crt.Record), degisken, "IL", sender);
                ////    break;
                ////case "Icra_Borclu_Ilce":
                ////    return Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)crt.Record),degisken, "ILCE", sender);
                ////    break;
                //case "Icra_Borclu_Ulke":
                //    return Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), degisken, "ULKE", sender);
                //    break;
                //case "Icra_Borclu_Aktif_Adres":
                //    return Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), degisken, "AKTIF_ADRES", sender);
                //    break;
                //case "Icra_Alacakli_Vergi_Dairesi":
                //    return Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record),degisken, "VERGI_DAIRESI", sender);
                //    break;
                //case "Icra_Alacakli_Vergi_No":
                //    return Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), degisken, "VERGI_NO", sender);
                //    break;
                //case "Icra_Alacakli_Il":
                //    return Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record),degisken, "IL", sender);
                //    break;
                //case "Icra_Alacakli_Ilce":
                //    return Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), degisken, "ILCE", sender);
                //    break;
                //case "Icra_Alacakli_Ulke":
                //    return Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), degisken, "ULKE", sender);
                //    break;
                //case "Icra_Alacakli_Aktif_Adres":
                //    return Degiskenler.GetIcraCariBilgisi(((AV001_TI_BIL_FOY)Record), degisken, "AKTIF_ADRES", sender);
                //    break;
                //case "Icra_Alacak_Neden_Adlari":
                //    return IcraAlacakNedenAdlari.DegeriGetir(degisken, ((AV001_TI_BIL_FOY)Record));
                //    break;
                //case "Icra_Yasal_Sure_Odeme":
                //    return IcraFormTipineGoreYasalSure.DegeriGetir(degisken, ((AV001_TI_BIL_FOY)Record), 4);
                //    break;
                //case "Icra_Yasal_Sure_Mal_Beyaný":
                //    return IcraFormTipineGoreYasalSure.DegeriGetir(degisken, ((AV001_TI_BIL_FOY)Record), 2);
                //    break;
                //case "Icra_Yasal_Sure_Sikayet":
                //    return IcraFormTipineGoreYasalSure.DegeriGetir(degisken, ((AV001_TI_BIL_FOY)Record), 5);
                //    break;
                //case "Icra_Yasal_Sure_Itiraz":
                //    return IcraFormTipineGoreYasalSure.DegeriGetir(degisken, ((AV001_TI_BIL_FOY)Record), 1);
                //    break;
                //case "Icra_Yasal_Sure_Mehil":
                //    return IcraFormTipineGoreYasalSure.DegeriGetir(degisken, ((AV001_TI_BIL_FOY)Record), 3);
                //    break;
                //case "Icra_Yasal_Sure_Tahliye":
                //    return IcraFormTipineGoreYasalSure.DegeriGetir(degisken, ((AV001_TI_BIL_FOY)Record), 11);
                //    break;
                //case "Icra_Yasal_Sure_Itirazdan_Sonra_Mal_Beyaný":
                //    return IcraFormTipineGoreYasalSure.DegeriGetir(degisken, ((AV001_TI_BIL_FOY)Record), 12);
                //    break;
                //case "Icra_Takip_Kanýtlarý":
                //    return Degiskenler.TakipKanitlari(((AV001_TI_BIL_FOY)Record), degisken);
                //    break;
                //case "Icra_Foy_Sorumlulari":
                //    return Degiskenler.IcraFoySorumlulariGetir((AV001_TI_BIL_FOY)Record, degisken);
                //    break;
                //case "ICRA_Borclu_Taraf_Farkli_Sorumluluk":
                //    return Degiskenler.IcraBorcluTarafFarkliSorumluluk((AV001_TI_BIL_FOY)Record, degisken);
                //    break;
                //case "ICRA_Depo_Alacagi_Maktu_Harc":
                //    return Degiskenler.GetIcraDepoAlacagiMaktuHarc((AV001_TI_BIL_FOY)Record,degisken);
                //    break;
                //case "ICRAGayriNakitAlacaklar":
                //    return Degiskenler.GetIcraGayriNakitAlacaklarimiz((AV001_TI_BIL_FOY)Record, degisken);
                //    break;
                //case "ICRA_BankaHarctanMuaf":
                //    return Degiskenler.GetIcraBankaHarctanMuaf(degisken);
                //    break;
                //case "ICRA_89_Borclusu":
                //    return Degiskenler.Get89Borclusu((AV001_TI_BIL_FOY) Record,degisken);
                //case "ICRA_Gayrimenkul_Bilgisi":
                //    return Degiskenler.GetIcraGayrimenkulBilgileri((AV001_TI_BIL_FOY)Record, degisken);
                //    break;
                //default:
                //    returnValue = degisken.GORUNEN_AD;
                //    break;
            }
            return returnValue;
        }

        public static void SetRecords(AV001_TDIE_BIL_SABLON_DEGISKENLER degisken)
        {
            if (SelectedRecords == null)
            {
                SelectedRecords = new List<SeciliKayit>();
            }
            if (degisken.MODUL_ID == 2)
            {
                if (GetSelectedKayitByModul(degisken.MODUL_ID) == null)
                {
                    frmIcraSec icraSecim = new frmIcraSec();

                    //icraSecim.MdiParent = null;
                    icraSecim.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    icraSecim.Show();
                    SeciliKayit kayit = new SeciliKayit();
                    kayit.Kayit = (IEntity)icraSecim.kriter.Record;

                    if (icraSecim.kriter.Record == null) return;

                    kayit.Id =
                        (int)
                        TablesColumnData.GetColumnValueByNameFromRecord((IEntity)icraSecim.kriter.Record, "ID").Value;
                    kayit.Modul = degisken.MODUL_ID;
                    kayit.Degisken = degisken;
                    SelectedRecords.Add(kayit);
                }
            }
            if (degisken.MODUL_ID == 1)
            {
                frmIcraSec icraSecim = new frmIcraSec();

                //icraSecim.MdiParent = null;
                icraSecim.StartPosition = FormStartPosition.WindowsDefaultLocation;
                icraSecim.Show();
                if (icraSecim.kriter.Record != null)
                {
                    SeciliKayit kayit = new SeciliKayit();
                    kayit.Kayit = (IEntity)icraSecim.kriter.Record;
                    kayit.Id =
                        (int)
                        TablesColumnData.GetColumnValueByNameFromRecord((IEntity)icraSecim.kriter.Record, "ID").Value;
                    kayit.Modul = degisken.MODUL_ID;
                    kayit.Degisken = degisken;
                    SelectedRecords.Add(kayit);
                }
            }
        }

        private static int GetRecordsModul(IEntity Record)
        {
            if (Record.TableName == "AV001_TI_BIL_FOY")
            {
                return 2;
            }
            if (Record.TableName == "AV001_TD_BIL_FOY")
            {
                return 1;
            }
            return 2;
        }

        public class SeciliKayit
        {
            public AV001_TDIE_BIL_SABLON_DEGISKENLER Degisken { get; set; }

            public int Id { get; set; }

            public IEntity Kayit { get; set; }

            public int Modul { get; set; }
        }

        //public static AvukatProDegiskenler.Icra.Degiskenler.DegiskenAdlari GetDegiskenEnum(AV001_TDIE_BIL_SABLON_DEGISKENLER degisnkenKayit)
        //{
        //    object cevirilenSonuc = Enum.Parse(typeof(AvukatProDegiskenler.Icra.Degiskenler.DegiskenAdlari), degisnkenKayit.AD);

        //    if (cevirilenSonuc is AvukatProDegiskenler.Icra.Degiskenler.DegiskenAdlari)
        //    {
        //        return (AvukatProDegiskenler.Icra.Degiskenler.DegiskenAdlari)cevirilenSonuc;
        //    }

        //    return AvukatProDegiskenler.Icra.Degiskenler.DegiskenAdlari.BuKullanici;
        //}

        //public static string DegiskenAyarParser(IEntity Record)
        //{
        //    if (Record.TableName=="AV001_TDIE_BIL_ANTET")
        //    {
        //        TablesColumnData.GetColumnValueByNameFromRecord( Record,"ID");
        //    }
        //}

        //public static IEntity DegiskenDegerParser(AV001_TDIE_BIL_SABLON_DEGISKEN_AYAR ayar)
        //{
        //}
    }
}