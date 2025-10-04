using AdimAdimDavaKaydi.Util.Uyap;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AvukatProUyap
{
    public static class Helper
    {
        public static void GetUyap(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama myFoy)
        {
            UyapGenerator ugen = new UyapGenerator();
            SaveFileDialog saveUyapBelgeDialog = new SaveFileDialog();
            saveUyapBelgeDialog.Filter = "*.xml|Uyap çýktýsý";
            if (saveUyapBelgeDialog.ShowDialog() == DialogResult.OK)
            {
                List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> myFoyList = new List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama>();
                myFoyList.Add(myFoy);
                ugen.WriteToFile(myFoyList, saveUyapBelgeDialog.FileName + ".xml");
            }
        }
    }
}