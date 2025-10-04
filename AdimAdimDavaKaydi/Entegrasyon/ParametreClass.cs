using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Linq;

namespace AdimAdimDavaKaydi.Entegrasyon
{
    public static class ParametreClass
    {
        public static int MappingAlacakNedeni(string alacakNeden)
        {
            int alacakNedenKodID = 0;
            var alacakNedeni = DataRepository.TI_KOD_ALACAK_NEDENProvider.Find(string.Format("ALACAK_NEDENI = {0}", alacakNeden)).FirstOrDefault();

            return alacakNedeni == null ? alacakNedenKodID : alacakNedeni.ID;
        }

        public static int? MappingBanka(string banka)
        {
            var selectedBanka = DataRepository.TDI_KOD_BANKAProvider.Find(string.Format("BANKA = {0}", banka)).FirstOrDefault();

            if (selectedBanka != null) return selectedBanka.ID;
            else return null;
        }

        public static int? MappingBankaSube(string bankaSube)
        {
            var selectedBankaSube = DataRepository.TDI_KOD_BANKA_SUBEProvider.Find(string.Format("SUBE = {0}", bankaSube)).FirstOrDefault();

            if (selectedBankaSube != null) return selectedBankaSube.ID;
            else return null;
        }

        public static int MappingBirimi(string birim)
        {
            switch (birim)
            {
                case "TİCARİ TAKİP HUKUK GRUBU":
                    return 1;

                case "BİREYSEL TAKİP HUKUK GRUBU":
                    return 5;

                default:
                    return 0;
            }
        }

        public static int MappingDovizTip(string dovizTip)
        {
            if (string.IsNullOrEmpty(dovizTip) || dovizTip == "") return 1;
            int dovizTipID = 0;

            switch ((EnumsParametre.DovizTip)Enum.Parse(typeof(EnumsParametre.DovizTip), dovizTip, false))
            {
                case EnumsParametre.DovizTip.AED:
                    dovizTipID = 142;
                    break;

                case EnumsParametre.DovizTip.ATS:
                    dovizTipID = 26;
                    break;

                case EnumsParametre.DovizTip.AUD:
                    dovizTipID = 3;
                    break;

                case EnumsParametre.DovizTip.BEF:
                    dovizTipID = 24;
                    break;

                case EnumsParametre.DovizTip.BHD:
                    dovizTipID = 44;
                    break;

                case EnumsParametre.DovizTip.CAD:
                    dovizTipID = 9;
                    break;

                case EnumsParametre.DovizTip.CHF:
                    dovizTipID = 6;
                    break;

                case EnumsParametre.DovizTip.CZK:
                    dovizTipID = 90;
                    break;

                case EnumsParametre.DovizTip.DEM:
                    dovizTipID = 22;
                    break;

                case EnumsParametre.DovizTip.DKK:
                    dovizTipID = 4;
                    break;

                case EnumsParametre.DovizTip.EGP:
                    dovizTipID = 109;
                    break;

                case EnumsParametre.DovizTip.ESP:
                    dovizTipID = 27;
                    break;

                case EnumsParametre.DovizTip.EUR:
                    dovizTipID = 13;
                    break;

                case EnumsParametre.DovizTip.FIM:
                    dovizTipID = 28;
                    break;

                case EnumsParametre.DovizTip.FRF:
                    dovizTipID = 21;
                    break;

                case EnumsParametre.DovizTip.GBP:
                    dovizTipID = 5;
                    break;

                case EnumsParametre.DovizTip.GRD:
                    dovizTipID = 30;
                    break;

                case EnumsParametre.DovizTip.HUF:
                    dovizTipID = 67;
                    break;

                case EnumsParametre.DovizTip.IEP:
                    dovizTipID = 31;
                    break;

                case EnumsParametre.DovizTip.ITL:
                    dovizTipID = 33;
                    break;

                case EnumsParametre.DovizTip.JPY:
                    dovizTipID = 8;
                    break;

                case EnumsParametre.DovizTip.KWD:
                    dovizTipID = 10;
                    break;

                case EnumsParametre.DovizTip.LYD:

                    break;

                case EnumsParametre.DovizTip.MAD:
                    dovizTipID = 66;
                    break;

                case EnumsParametre.DovizTip.NLG:
                    dovizTipID = 23;
                    break;

                case EnumsParametre.DovizTip.NOK:
                    dovizTipID = 11;
                    break;

                case EnumsParametre.DovizTip.OMR:
                    dovizTipID = 145;
                    break;

                case EnumsParametre.DovizTip.PLN:
                    dovizTipID = 153;
                    break;

                case EnumsParametre.DovizTip.PTE:
                    dovizTipID = 35;
                    break;

                case EnumsParametre.DovizTip.QAR:
                    dovizTipID = 85;
                    break;

                case EnumsParametre.DovizTip.ROL:
                    dovizTipID = 16;
                    break;

                case EnumsParametre.DovizTip.RUB:

                    break;

                case EnumsParametre.DovizTip.SAR:
                    dovizTipID = 12;
                    break;

                case EnumsParametre.DovizTip.SEK:
                    dovizTipID = 7;
                    break;

                case EnumsParametre.DovizTip.SKK:
                    dovizTipID = 124;
                    break;

                case EnumsParametre.DovizTip.TL:
                    dovizTipID = 1;
                    break;

                case EnumsParametre.DovizTip.USD:
                    dovizTipID = 2;
                    break;

                case EnumsParametre.DovizTip.XAU:

                    break;

                case EnumsParametre.DovizTip.ZAR:
                    dovizTipID = 73;
                    break;

                default:
                    break;
            }

            return dovizTipID;
        }

        public static int MappingEvrakDurum(string durum)
        {
            int bonoDurumID = 0;

            switch (durum)
            {
                case "SENET GİRİLMİŞ":
                    bonoDurumID = 1;
                    break;

                case "TAHSİLE GÖNDERİLMİŞ":
                    bonoDurumID = 2;
                    break;

                case "ŞUBE KABUL ETMİŞ":
                    bonoDurumID = 3;
                    break;

                case "TAHSİL EDİLMİŞ":
                    bonoDurumID = 4;
                    break;

                case "PROTESTO EDİLMİŞ":
                    bonoDurumID = 5;
                    break;

                case "PROTESTOLU SENET TAHSİL":
                    bonoDurumID = 6;
                    break;

                case "ŞUBEYE İADE-YOLDAKİ SENETLER":
                    bonoDurumID = 7;
                    break;

                case "MÜŞTERİYE İADE":
                    bonoDurumID = 8;
                    break;

                case "PROTESTOLU SENET İADE-YOLDAKİ SENETLER":
                    bonoDurumID = 9;
                    break;

                case "PROTESTOLU SENET KABUL":
                    bonoDurumID = 10;
                    break;

                case "SENET MUHABİRDE":
                    bonoDurumID = 11;
                    break;

                case "MUHABİRDE PROTESTO ":
                    bonoDurumID = 12;
                    break;

                case "İADE EDİLMİŞ SENET KABUL":
                    bonoDurumID = 13;
                    break;

                case "MÜŞTERİYE İADE İÇİN BEKLİYOR":
                    bonoDurumID = 14;
                    break;

                case "PROTESTOLU SENET MÜŞTERİYE İADE":
                    bonoDurumID = 15;
                    break;

                case "İPTAL":
                    bonoDurumID = 16;
                    break;

                case "GİRİLMİŞ":
                    bonoDurumID = 17;
                    break;

                case "TAKASA GÖNDERİLMİŞ":
                    bonoDurumID = 18;
                    break;

                case "TAKASTAN KESİNLEŞMİŞ":
                    bonoDurumID = 19;
                    break;

                case "PROVİZYON ALINAMAMIŞ BANKAMIZ ÇEKİ":
                    bonoDurumID = 20;
                    break;

                case "TAHSİL EDİLMİŞ BANKAMIZ ÇEKİ":
                    bonoDurumID = 21;
                    break;

                case "KARŞILIKSIZ ÇIKMIŞ":
                    bonoDurumID = 22;
                    break;

                case "KARŞILIKSIZ ÇEK TAKASTAN İADE EDİLMİŞ":
                    bonoDurumID = 23;
                    break;

                case "TAKAS ÖNCESİ İADE EDİLMİŞ":
                    bonoDurumID = 24;
                    break;

                case "TAKASA GÖNDERİLECEK":
                    bonoDurumID = 25;
                    break;

                case "DEPODAN ÖDENMİŞ BANKAMIZ ÇEKİ":
                    bonoDurumID = 26;
                    break;

                case "ÖDENEMEMİŞ BANKAMIZ ÇEKİ":
                    bonoDurumID = 27;
                    break;

                case "KISMİ ÖDENMİŞ BANKAMIZ ÇEKİ":
                    bonoDurumID = 28;
                    break;

                case "KARŞILIKSIZ BİLDİRİLMİŞ BANKAMIZ ÇEKİ":
                    bonoDurumID = 29;
                    break;

                case "AKTİF":
                    bonoDurumID = 30;
                    break;

                case "ÇIKIŞ":
                    bonoDurumID = 32;
                    break;

                default:
                    break;
            }

            return bonoDurumID;
        }

        public static int? MappingIl(string il)
        {
            var selectedIl = DataRepository.TDI_KOD_ILProvider.Find(string.Format("IL = {0}", il)).FirstOrDefault();

            if (selectedIl != null) return selectedIl.ID;
            else return null;
        }

        public static int? MappingIlce(string ilce)
        {
            var selectedIlce = DataRepository.TDI_KOD_ILCEProvider.Find(string.Format("ILCE = {0}", ilce)).FirstOrDefault();

            if (selectedIlce != null) return selectedIlce.ID;
            else return null;
        }

        public static int MappingKrediGrubu(string krediGrubu)
        {
            int krediGrubuID = 0;

            switch (krediGrubu)
            {
                case "KURUMSAL":
                    krediGrubuID = 8;
                    break;

                case "TİCARİ":
                    krediGrubuID = 9;
                    break;

                case "KOBİ":
                    krediGrubuID = 10;
                    break;

                case "MİKRO":
                    krediGrubuID = 11;
                    break;

                case "Kredi Kartları":
                    krediGrubuID = 12;
                    break;

                case "KONUT":
                    krediGrubuID = 13;
                    break;

                case "OTOMOBİL":
                    krediGrubuID = 14;
                    break;

                case "DİĞER TÜKETİCİ KREDİLERİ":
                    krediGrubuID = 15;
                    break;

                default:
                    break;
            }

            return krediGrubuID;
        }

        public static void MappingSozlesmeTipAltTip(string sozlesmeTip, AV001_TDI_BIL_SOZLESME sozlesme)
        {
            switch (sozlesmeTip)
            {
                case "Bankacılık Hizmet Sözleşmesi":
                    sozlesme.TIP_ID = 2;//Kredi  Sözleşmesi
                    sozlesme.ALT_TIP_ID = 168;
                    break;

                //case "Forward İşlemlerine Münhasır GKS":
                //    break;
                case "Genel Kredi Sözleşmesi":
                    sozlesme.TIP_ID = 2;//Kredi  Sözleşmesi
                    sozlesme.ALT_TIP_ID = 14;
                    break;

                //case "Özel Metinli Kredi Sözleşmesi":
                //    break;
                case "Taksitli Ticari Kredi Sözleşmesi":
                    sozlesme.TIP_ID = 2;//Kredi  Sözleşmesi
                    sozlesme.ALT_TIP_ID = 10004;
                    break;

                default:
                    break;
            }
        }

        public static int MappingTarafSifat(string tarafSifat)
        {
            int tarafSifatID = 2;

            switch (tarafSifat)
            {
                case "BORÇLU":
                    tarafSifatID = 2;
                    break;

                case "KEŞİDECİ":
                    tarafSifatID = 2;
                    break;

                case "SON CİRANTA":
                    tarafSifatID = 3;
                    break;

                case "KEFİL":
                    tarafSifatID = 33;
                    break;

                default:
                    break;
            }

            return tarafSifatID;
        }

        public static int MappingTeminatDurum(string durum)
        {
            int teminatDurumID = 0;

            switch (durum)
            {
                case "Tamamen Ödendi":
                    teminatDurumID = 3;
                    break;

                case "Fek Edildi":
                    teminatDurumID = 4;
                    break;

                case "Kısmi Ödendi":
                    teminatDurumID = 5;
                    break;

                case "İade Edildi":
                    teminatDurumID = 6;
                    break;

                case "Mahkeme kararıyla iptal edildi":
                    teminatDurumID = 7;
                    break;

                case "Karşılıksız Çıktı":
                    teminatDurumID = 8;
                    break;

                case "Protesto Edildi":
                    teminatDurumID = 9;
                    break;

                case "Çıkış":
                    teminatDurumID = 10;
                    break;

                default:
                    break;
            }

            return teminatDurumID;
        }

        public static int? MappingUlke(string ulke)
        {
            var selectedUlke = DataRepository.TDI_KOD_ULKEProvider.Find(string.Format("ULKE = {0}", ulke)).FirstOrDefault();

            if (selectedUlke != null) return selectedUlke.ID;
            else return null;
        }
    }
}