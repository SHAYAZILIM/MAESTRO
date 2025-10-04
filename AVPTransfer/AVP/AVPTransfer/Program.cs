using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AVPTransfer
{
    internal static class Program
    {
        #region Methods

        private static void cDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            EventLog eLog = new EventLog("AVPTransfer");
            if (!EventLog.SourceExists("AVPTransfer")) EventLog.CreateEventSource("AVPTransfer", "AVPTransfer");

            eLog.Source = "AVPTransfer";

            eLog.WriteEntry(string.Format("Unhandled Exception: {0}", ex.Message), EventLogEntryType.Error);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain cDomain = AppDomain.CurrentDomain;
            cDomain.UnhandledException += new UnhandledExceptionEventHandler(cDomain_UnhandledException);
            Application.Run(new frmMain());
        }

        #endregion Methods
    }
}