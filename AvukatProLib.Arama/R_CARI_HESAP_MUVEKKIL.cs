using System.Data;

namespace AvukatProLib.Arama
{
    public class R_CARI_HESAP_MUVEKKIL
    {
        public static bool KullaniciMuvekkilMi(string con, int kullaniciID)
        {
            AvpDataContext data = new AvpDataContext(con);
            //Select("MUVEKKIL_MI=1")
            bool muvekkilMi = false;
            foreach (DataRow item in data.AV001_TDI_BIL_CARIs.Select("ID=" + kullaniciID + " and MUVEKKIL_MI=1"))
            {
                muvekkilMi = true;
            }

            return muvekkilMi;
        }
    }
}