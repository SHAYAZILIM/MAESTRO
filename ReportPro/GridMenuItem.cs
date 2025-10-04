using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportPro
{
    public class GridMenuItem
    {
        private string _grubu;

        private string _tipi;

        public enum AcilacakPencere
        {
            Chart_IcraGenelBilgilerTaraf_AyaGore,
            Chart_IcraGenelBilgilerTaraf_TakipKonusunaGore,
            Chart_IcraGenelBilgilerTaraf_YilaGore,
            Chart_IcraGenelBilgilerTaraf_MudurlugeGore,
            Chart_IcraGenelBilgilerTaraf_HaftaninGunlerineGore,

            Chart_IcraGenelBilgilerSorumlu_SorumluyaGore,
            Chart_IcraGenelBilgilerSorumlu_TakipkonusunaGore,
            Chart_IcraGenelBilgilerSorumlu_MudurlugeGore,

            Chart_DavaGenelBilgilerTarafa_DurumaGore,
            Chart_DavaGenelBilgilerTarafa_DavaKonusu,
            Chart_DavaGenelBilgilerTarafa_Mahkeme,
            Chart_DavaGenelBilgilerTarafa_Gorev,
            Chart_DavaGenelBilgilerTarafa_DavaTipi,
            Chart_DavaGenelBilgilerTarafa_DavaTarihiYil,
            Chart_DavaGenelBilgilerTarafa_DavaTarihiCeyrek,
            Chart_DavaGenelBilgilerTarafa_DavaTarihiAy,
            Chart_DavaGenelBilgilerTarafa_DavaTarihiGun,

            Chart_DavaGenelBilgilerSorumlu_DurumaGore,
            Chart_DavaGenelBilgilerSorumlu_DavaKonusunaGore,
            Chart_DavaGenelBilgilerSorumlu_MahkemeyeGore,
            Chart_DavaGenelBilgilerSorumlu_GoreveGore,
            Chart_DavaGenelBilgilerSorumlu_DavaTipineGore,
            Chart_DavaGenelBilgilerSorumlu_DavaTarihiYil,
            Chart_DavaGenelBilgilerSorumlu_DavaTarihiCeyrek,
            Chart_DavaGenelBilgilerSorumlu_DavaTarihiAy,
            Chart_DavaGenelBilgilerSorumlu_DavaTarihiGun,

            Pivot_Dava_SorumlusunaGore,
            Pivot_Dava_TarafinaGore,
            Pivot_Dava_DosyasinaGore,

            Pivot_Icra_SorumlusunaGore,
            Pivot_Icra_DosyayaGore,
            Pivot_Icra_TarafinaGore,

            Liste_Dava_TaraGore,
            Liste_Dava_SorumluyaGore,
            Liste_Icra_SorumluyaGore,
            Liste_Icra_TarafaGore,

            KulTanimli_Icra,
            KulTanimli_YapilacakIs,
            KulTanimli_Hesapli_Kapsamli_Genel_Tarafli,
            KulTanimli_Hesapli_Kapsamli_Genel_Sorumlu,
            KulTanimli_Sorusturma_Genel_Hesapsiz,
            KulTanimli_Sorusturma_Genel_Hesapsiz_Sorumlu,
            KulTanimli_sorusturma_Genel_Hesapsiz_Tarafli,
            KulTanimli_Tebligat_Muhatap,
            KulTanimli_Yapilacak_Isler,
            KulTanimli_Gorusmeler,
            KulTanimli_Belgeler,
            KulTanimli_Temsil,
            KulTanimli_Masraf_Avans,
            KulTanimli_Muhasebe_Tarafli,
            KulTanimli_Mal_Satis_Tarafli_Sorumlulu,
            KulTanimli_Temyiz_Takip,
            KulTanimli_Kasa_Bilgileri,
            KulTanimli_Kiymetli_Evrak_Genel,
            KulTanimli_Gayrimenkul_Genel,
            KulTanimli_Gemi_Ucak_Arac_Genel,
        }

        public enum Grup
        {
            Sorumlu,
            Taraf,
            Dosya,
            Genel,
            Diger,
        }

        [Serializable]
        public enum Modul
        {
            ICRA,
            DAVA,
            SORUSTURMA,
            TEBLIGAT,
            YAPILACAK_IS,
            GORUSMELER,
            BELGELER,
            TEMSIL,
            MUHASEBE,
        }

        public enum Tip
        {
            Chart = 1,
            Pivot = 2,
            Liste = 3,
            KullaniciTanimli = 4,
        }

        public string AcilacakPencereDegeri { get; set; }

        public string AcilacakRaporDeger { get; set; }

        public string Adi { get; set; }

        public string GrubDegeri { get; set; }

        public string Grubu
        {
            get
            {
                return String.IsNullOrEmpty(_grubu) ? GrubDegeri : _grubu;
            }
            set
            {
                _grubu = value;
            }
        }

        public string KullaniciTanimliDosyaYolu { get; set; }

        public string ModulDegeri { get; set; }

        public string Modulu
        {
            get
            {
                switch (ModulDegeri)
                {
                    case "ICRA":
                        return "İcra";
                    case "DAVA":
                        return "Dava";
                    case "SORUŞTURMA":
                        return "Soruşturma";
                    case "Tebligat":
                        return "Tebligat";
                    case "Genel":
                        return "Genel";
                    case "DONEMSEL RAPORLAR":
                        return "Dönemsel Raporlar";
                    case "KLASÖR":
                        return "Klasör";
                    default:
                        return "Genel";
                }
            }
            set
            {
                ModulDegeri = value;
            }
        }

        public Tip TipDegeri { get; set; }

        public string Tipi
        {
            get
            {
                switch (TipDegeri)
                {
                    case Tip.Chart:
                        return "Chart";

                    case Tip.Pivot:
                        return "Pivot";

                    case Tip.Liste:
                        return "Liste";

                    case Tip.KullaniciTanimli:
                        return "Kullanıcı Tanımlı";

                    default:
                        if (String.IsNullOrEmpty(_tipi))
                        {
                            return "Diğer";
                        }
                        else
                        {
                            return _tipi;
                        }
                }
            }
            set
            {
                _tipi = value;
            }
        }

        public Guid UniqueId { get; set; }

        public static List<GridMenuItem> GetListForSaveList(SaveList sl)
        {
            List<GridMenuItem> sonuc = sl.Select(vi =>
                                                     new GridMenuItem
                                                     {
                                                         GrubDegeri = "Diger",
                                                         Grubu = vi.Grubu,
                                                         AcilacakPencereDegeri = "KulTanimli_Icra",
                                                         ModulDegeri = "Icra",
                                                         TipDegeri = Tip.KullaniciTanimli,
                                                         Adi = vi.ReportName,
                                                         KullaniciTanimliDosyaYolu = vi.FilePath,
                                                     }).ToList();

            return sonuc;
        }
    }
}