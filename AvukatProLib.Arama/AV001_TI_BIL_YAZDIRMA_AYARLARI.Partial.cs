namespace AvukatProLib.Arama
{
    public partial class AV001_TI_BIL_YAZDIRMA_AYARLARI
    {
        public override string ToString()
        {
            string st = string.Empty;
            if (this.TI_KOD_FORM_TIP != null)
                st += this.TI_KOD_FORM_TIP.FORM_ORNEK_NO + " " + this.TI_KOD_FORM_TIP.FORM_ADI;
            return st;
        }
    }
}