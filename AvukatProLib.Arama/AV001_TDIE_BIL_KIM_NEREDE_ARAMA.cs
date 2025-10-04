namespace AvukatProLib.Arama
{
    public partial class AV001_TDIE_BIL_KIM_NEREDE
    {
        public string ADLIYE
        {
            get
            {
                if (this.TDI_KOD_ADLI_BIRIM_ADLIYE != null)
                    return this.TDI_KOD_ADLI_BIRIM_ADLIYE.ADLIYE;

                return null;
            }
        }
    }
}