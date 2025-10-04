//using AvukatProRaporlar;
using AvukatProRaporlar.Raport.Util;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace ReportPro
{
    [Serializable]
    public class SaveReport
    {
        [Serializable]
        public enum KayitGizlilik
        {
            Ozel, Genel
        }

        public ReportPro.GridMenuItem.AcilacakPencere AcilacakPencere { get; set; }

        public GridAyar Ayarlar { get; set; }

        public int CariID { get; set; }

        public string FilePath { get; set; }

        public string Grup { get; set; }

        public KayitGizlilik KaydinTipi { get; set; }

        public Stream Layout { get; set; }

        public string RaporAdi { get; set; }

        public static GridAyar AyarAl(GridView gv)
        {
            GridAyar ayarim = new GridAyar();

            //ayarim.StyleConditions = new List<Bilgi>();
            //foreach (StyleFormatCondition cnd in gv.FormatConditions)
            //{
            //    ayarim.StyleConditions.Add(cnd.Tag as AdimAdimDavaKaydi.Bilgi);
            //}
            //if (gv.Tag is string)
            //{
            //    ayarim.MyCustomStyle = gv.Tag.ToString();
            //}
            return ayarim;
        }

        public static SaveReport Oku(string path)
        {
            //string path = Utils.Tools.Temp + "Deneme1.apr";
            if (File.Exists(path))
            {
                Stream file = File.Open(path, FileMode.Open);
                BinaryFormatter vrf = new BinaryFormatter();
                SaveReport st = vrf.Deserialize(file) as SaveReport;
                file.Close();
                return st;
            }
            return null;
        }

        /// <summary>
        /// GridView nesnesi üzerinden Kayýt için gerekli ayarlarý almaya yarar
        /// </summary>
        public void Save()
        {
            string path = Application.StartupPath + "\\KayitliDosyalar\\" + Guid.NewGuid().ToString() + ".apr";
            this.FilePath = path;
            FileStream fs = new FileStream(path, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }
    }
}