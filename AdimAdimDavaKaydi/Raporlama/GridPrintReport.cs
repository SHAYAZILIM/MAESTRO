using System;
using AdimAdimDavaKaydi;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using DevExpress.XtraGrid;

namespace GridRapor
{
    public static class GridPrintReport
    {
        public static void MailIt(GridControl grid)
        {
            //string file = DateTime.Now.ToString().Replace(".", "_").Replace(":", "_").Replace(" ", "_") + new Guid();
            string file = DateTime.Today.Day.ToString().PadLeft(2, '0') + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Year.ToString() + "_Rapor"; 
            //grid.ExportToHtml(Tools.TempFilesPath + file);
            grid.ExportToExcelOld(Tools.TempFilesPath + file + ".xls");
            AvukatProLib.Mail.frmMailSender frm = new AvukatProLib.Mail.frmMailSender(new System.Collections.Generic.List<string>() { Tools.TempFilesPath + file + ".xls" });
            frm.ShowDialog();

            //frmChooseFileAttachType fType = new frmChooseFileAttachType();
            //fType.AddFiles(Tools.TempFilesPath + file);
            //fType.Show();
        }

    }
}