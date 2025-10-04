using System;

namespace ReportPro
{
    [Serializable]
    public class SaveListItem
    {
        public SaveListItem(SaveReport sRapor)
        {
            FilePath = sRapor.FilePath;
            Grubu = sRapor.Grup;
            KayitTipi = sRapor.KaydinTipi;
            KullaniciID = sRapor.CariID;
            ReportName = sRapor.RaporAdi;
            AcilacakPencere = sRapor.AcilacakPencere;
        }
        
        public GridMenuItem.AcilacakPencere AcilacakPencere { get; set; }

        public string FilePath { get; set; }

        public string Grubu { get; set; }

        public SaveReport.KayitGizlilik KayitTipi { get; set; }

        public int KullaniciID { get; set; }

        public GridMenuItem.Modul ModulTipi { get; set; }

        public string ReportName { get; set; }

        public int UniqueId { get; set; }
    }
}