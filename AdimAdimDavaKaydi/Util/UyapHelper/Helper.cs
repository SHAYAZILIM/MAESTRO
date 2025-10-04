using System;
using System.Collections.Generic;
using System.Text;
using AvukatProLib2.Entities;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Editor.Forms;

namespace AdimAdimDavaKaydi.Util.Uyap
{
    public static class Helper
    {
                                
        public static void SaveUyap(List<per_AV001_TI_BIL_ICRA_Arama> myFoyList, frmAdimAdimEditoreGonder editor)
        {
            UyapGenerator ugen = new UyapGenerator(editor);
            ugen.WriteToFile(myFoyList, System.Environment.GetFolderPath(System.Environment.SpecialFolder.Templates)+"\\tmpuyap.xml");
        }
        public static bool CheckUyap(List<per_AV001_TI_BIL_ICRA_Arama> myFoyList, frmAdimAdimEditoreGonder editor)
        {
            UyapGenerator ugen = new UyapGenerator(editor);



            return ugen.UyapGozdenGecir(myFoyList, String.Empty,true);
        }
    }
}
