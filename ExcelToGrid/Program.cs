using ImportExportWithSelection.Import;
using System;
using System.Windows.Forms;

namespace ImportExportWithSelection
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new XtraForm1());//frmImportFromExcel<AV001_TI_BIL_FOY>());
        }
    }
}