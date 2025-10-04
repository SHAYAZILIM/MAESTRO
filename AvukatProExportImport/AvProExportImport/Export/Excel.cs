using AvProExportImport.Util;
using System;
using System.Reflection;

namespace AvProExportImport.Export
{
    public class Excel
    {
        public static void ToCurrentDocument(string file, string Baslik, ExcelTable veri)
        {
            ///excel uygulamasý
            Microsoft.Office.Interop.Excel.Application ExcelApp;

            ///uygulama için bir excel kitabý
            Microsoft.Office.Interop.Excel._Workbook ExcelWorkbook;

            /// kitap içinde yer alacak bir excel sayfasý
            Microsoft.Office.Interop.Excel._Worksheet ExcelWorkSheet;

            ExcelApp = new Microsoft.Office.Interop.Excel.Application();

            // excel uygulamamýzý gorunur hale getirdik bu sayede ekrana bir excel penceresi acýldý
            ExcelApp.Visible = true;

            /// yeni bir excel work booku olusturduk
            ExcelWorkbook = (Microsoft.Office.Interop.Excel._Workbook)(ExcelApp.Workbooks.Add(
            Missing.Value));

            /// olusturdugumuz work book ile otomatik larak default sayfalar olustu ben buraa ilk
            /// sayfayý default adý sayfa1 geldiðini bildigim için ele aldým ...
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel._Worksheet)ExcelWorkbook.Sheets[Baslik];

            /// Sayfamýn adýný deðiþtirdim
            ExcelWorkSheet.Name = Baslik;

            //Work Sheet im uzerindeki hucrelere veri giriyorum
            for (int i = 0; i < veri.Columns.Count; i++)
            {
                for (int y = 0; y < veri.Rows.Count; y++)
                {
                    ExcelWorkSheet.Cells[y, i] = veri.Rows[y][veri.Columns[i]].ToString();
                }
            }

            // Dosyamý nereye kaydetsem ...
            string savepath;
            savepath = file;

            ///Dosyayý kaydet.
            ///kaydetme iþlemi yapýlýrken  Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel12
            ///ile excel 12 formatýnda kaydetme iþlemi yaptým ...
            ExcelWorkbook.SaveAs(savepath, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel9795, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }

        public static void ToNewDocument(string file, string Baslik, ExcelTable veri)
        {
            ///excel uygulamasý
            Microsoft.Office.Interop.Excel.Application ExcelApp;

            ///uygulama için bir excel kitabý
            Microsoft.Office.Interop.Excel._Workbook ExcelWorkbook;

            /// kitap içinde yer alacak bir excel sayfasý
            Microsoft.Office.Interop.Excel._Worksheet ExcelWorkSheet;

            ExcelApp = new Microsoft.Office.Interop.Excel.Application();

            // excel uygulamamýzý gorunur hale getirdik bu sayede ekrana bir excel penceresi acýldý
            ExcelApp.Visible = true;

            /// yeni bir excel work booku olusturduk
            ExcelWorkbook = (Microsoft.Office.Interop.Excel._Workbook)(ExcelApp.Workbooks.Add(
            Missing.Value));

            /// olusturdugumuz work book ile otomatik larak default sayfalar olustu ben buraa ilk
            /// sayfayý default adý sayfa1 geldiðini bildigim için ele aldým ...
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel._Worksheet)ExcelWorkbook.Sheets["Sayfa1"];

            /// Sayfamýn adýný deðiþtirdim
            ExcelWorkSheet.Name = Baslik;

            //Work Sheet im uzerindeki hucrelere veri giriyorum
            for (int i = 0; i < veri.Columns.Count; i++)
            {
                for (int y = 0; y < veri.Rows.Count; y++)
                {
                    ExcelWorkSheet.Cells[y + 1, i + 1] = veri.Rows[y][veri.Columns[i]].ToString();
                }
            }

            // Dosyamý nereye kaydetsem ...
            string savepath;
            savepath = file;

            ///Dosyayý kaydet.
            ///kaydetme iþlemi yapýlýrken  Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel12
            ///ile excel 12 formatýnda kaydetme iþlemi yaptým ...
            ExcelWorkbook.SaveAs(savepath, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel9795, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }
    }
}