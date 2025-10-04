using AvProExportImport.Util;
using System;
using System.Reflection;

namespace AvProExportImport.Export
{
    public class Excel
    {
        public static void ToCurrentDocument(string file, string Baslik, ExcelTable veri)
        {
            ///excel uygulamas�
            Microsoft.Office.Interop.Excel.Application ExcelApp;

            ///uygulama i�in bir excel kitab�
            Microsoft.Office.Interop.Excel._Workbook ExcelWorkbook;

            /// kitap i�inde yer alacak bir excel sayfas�
            Microsoft.Office.Interop.Excel._Worksheet ExcelWorkSheet;

            ExcelApp = new Microsoft.Office.Interop.Excel.Application();

            // excel uygulamam�z� gorunur hale getirdik bu sayede ekrana bir excel penceresi ac�ld�
            ExcelApp.Visible = true;

            /// yeni bir excel work booku olusturduk
            ExcelWorkbook = (Microsoft.Office.Interop.Excel._Workbook)(ExcelApp.Workbooks.Add(
            Missing.Value));

            /// olusturdugumuz work book ile otomatik larak default sayfalar olustu ben buraa ilk
            /// sayfay� default ad� sayfa1 geldi�ini bildigim i�in ele ald�m ...
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel._Worksheet)ExcelWorkbook.Sheets[Baslik];

            /// Sayfam�n ad�n� de�i�tirdim
            ExcelWorkSheet.Name = Baslik;

            //Work Sheet im uzerindeki hucrelere veri giriyorum
            for (int i = 0; i < veri.Columns.Count; i++)
            {
                for (int y = 0; y < veri.Rows.Count; y++)
                {
                    ExcelWorkSheet.Cells[y, i] = veri.Rows[y][veri.Columns[i]].ToString();
                }
            }

            // Dosyam� nereye kaydetsem ...
            string savepath;
            savepath = file;

            ///Dosyay� kaydet.
            ///kaydetme i�lemi yap�l�rken  Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel12
            ///ile excel 12 format�nda kaydetme i�lemi yapt�m ...
            ExcelWorkbook.SaveAs(savepath, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel9795, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }

        public static void ToNewDocument(string file, string Baslik, ExcelTable veri)
        {
            ///excel uygulamas�
            Microsoft.Office.Interop.Excel.Application ExcelApp;

            ///uygulama i�in bir excel kitab�
            Microsoft.Office.Interop.Excel._Workbook ExcelWorkbook;

            /// kitap i�inde yer alacak bir excel sayfas�
            Microsoft.Office.Interop.Excel._Worksheet ExcelWorkSheet;

            ExcelApp = new Microsoft.Office.Interop.Excel.Application();

            // excel uygulamam�z� gorunur hale getirdik bu sayede ekrana bir excel penceresi ac�ld�
            ExcelApp.Visible = true;

            /// yeni bir excel work booku olusturduk
            ExcelWorkbook = (Microsoft.Office.Interop.Excel._Workbook)(ExcelApp.Workbooks.Add(
            Missing.Value));

            /// olusturdugumuz work book ile otomatik larak default sayfalar olustu ben buraa ilk
            /// sayfay� default ad� sayfa1 geldi�ini bildigim i�in ele ald�m ...
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel._Worksheet)ExcelWorkbook.Sheets["Sayfa1"];

            /// Sayfam�n ad�n� de�i�tirdim
            ExcelWorkSheet.Name = Baslik;

            //Work Sheet im uzerindeki hucrelere veri giriyorum
            for (int i = 0; i < veri.Columns.Count; i++)
            {
                for (int y = 0; y < veri.Rows.Count; y++)
                {
                    ExcelWorkSheet.Cells[y + 1, i + 1] = veri.Rows[y][veri.Columns[i]].ToString();
                }
            }

            // Dosyam� nereye kaydetsem ...
            string savepath;
            savepath = file;

            ///Dosyay� kaydet.
            ///kaydetme i�lemi yap�l�rken  Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel12
            ///ile excel 12 format�nda kaydetme i�lemi yapt�m ...
            ExcelWorkbook.SaveAs(savepath, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel9795, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }
    }
}