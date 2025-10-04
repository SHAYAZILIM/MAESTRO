namespace AvukatProRaporlar.Raport.Util.Inits
{
    public class Enums
    {
        public enum AraKararTip
        {
            Kesin_Mehilli = 2,
            Mehilli = 1,
            Mehilsiz = 0
        }

        public enum FaturaHedefTip
        {
            Dosyaya_Bağlı_Değil = 0,
            Icra_Dosyası = 1,
            Soruşturma_Dosyası = 3,
            Dava_Dosyası = 2
        }

        public enum FaturaKapsamTip
        {
            Dosya_Geneline_İlişkin = 0,
            Nedene_İlişkin = 1
        }

        public enum MasrafAvansTip
        {
            Masraf = 1,
            Avans = 2
        }
    }
}