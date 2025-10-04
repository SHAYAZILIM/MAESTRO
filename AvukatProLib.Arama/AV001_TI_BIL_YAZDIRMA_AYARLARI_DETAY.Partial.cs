namespace AvukatProLib.Arama
{
    public partial class AV001_TI_BIL_YAZDIRMA_AYARLARI_DETAY
    {
        public override string ToString()
        {
            string st = string.Empty;
            if (this.AV001_TDIE_BIL_SABLON_RAPOR != null)
                st += this.AV001_TDIE_BIL_SABLON_RAPOR.AD;

            return st;
        }
    }
}