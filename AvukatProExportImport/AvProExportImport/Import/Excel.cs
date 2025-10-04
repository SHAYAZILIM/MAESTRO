using System;
using System.Data;
using System.Data.OleDb;

namespace AvProExportImport.Import
{
    public class Excel
    {
        public static DataSet ImportFromExcel(string file)
        {
            try
            {
                string conn07 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";

                string conn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";

                #region<CC-20090627>

                // excel dosyalarý önizlemede gösterirken  dosyaýda açýyordu düzeltildi
                //     ApplicationClass app = new ApplicationClass();
                //     Microsoft.Office.Interop.Excel.Workbook wb;
                //     Microsoft.Office.Interop.Excel.Worksheet ws;
                //     wb = app.Workbooks.Open(file,
                //Missing.Value, Missing.Value, Missing.Value,
                //Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                //Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                //Missing.Value, Missing.Value, Missing.Value);
                //     ws = (Worksheet)wb.Worksheets[1];

                #endregion </CC20090627>

                DataSet ds = new DataSet();
                OleDbConnection con;
                if (System.IO.Path.GetExtension(file) == ".xlsx")
                {
                    con = new OleDbConnection(conn07);
                }
                else
                {
                    // con = new OleDbConnection(conn);

                    con = new OleDbConnection(conn);
                }

                //try
                //{
                //    con = new OleDbConnection(conn);
                //}
                //catch (Exception ex)
                //{
                //    con = new OleDbConnection(conn07);
                //}
                con.Open();
                System.Data.DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + dt.Rows[0]["TABLE_NAME"] + "]", con);
                da.Fill(ds);
                con.Close();
                return ds;
            }
            catch 
            {
                return null;
            }
        }
    }
}