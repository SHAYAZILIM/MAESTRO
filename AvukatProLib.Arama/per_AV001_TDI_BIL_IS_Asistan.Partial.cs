namespace AvukatProLib.Arama
{
    public partial class per_AV001_TDI_BIL_IS_Asistan
    {
        private string _gorunenAciklama;
        private string  altKategori = string.Empty;

        public string GorunenAciklama
        {
            get
            {
                if (this is per_AV001_TDI_BIL_IS_Asistan)
                {
                    if (_gorunenAciklama == null)
                    {
                        string st = string.Empty;
                        if (this.ADLIYE != null)
                            st += this.ADLIYE + " - ";
                        if (this.NO != null)
                            st += this.NO + " - ";
                        if (this.GOREV != null)
                            st += this.GOREV + " - ";
                        if (this.ALT_KATEGORI != null)
                            st += this.ALT_KATEGORI + " - ";
                        st += this.KONU;
                        _gorunenAciklama = st;
                    }
                    return _gorunenAciklama;
                }
                return null;
            }
        }
    }
}