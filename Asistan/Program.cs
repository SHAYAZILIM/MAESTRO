using Asistan.LinqDAL;
using Asistan.Util;
using AvukatProAsistan.Util;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Asistan
{
    internal static class Program
    {
        public static BackgroundWorker bgw;
        public static bool girisYapilmis;
        public static string KullaniciAdi;

        public static void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (AvukatProLib.CompInfo.CompInfoListGetir()[0].UygulamaTipi == 0) // Server
            {
                bool serviceInstalled = false;
                foreach (ServiceController tmpServ in ServiceController.GetServices())
                {
                    if (tmpServ.ServiceName.Trim() == "AvukatproReminderService")
                    {
                        serviceInstalled = true;
                        break;
                    }
                }
                if (serviceInstalled)
                {
                    System.ServiceProcess.ServiceController sc = new System.ServiceProcess.ServiceController("AvukatproReminderService");
                    if (sc.Status == ServiceControllerStatus.Paused)
                        sc.Continue();
                    if (sc.Status != ServiceControllerStatus.Running)
                        sc.Start();
                }
                else
                {
                    try
                    {
                        InstallReminderService();
                        Thread.Sleep(20000);
                        System.ServiceProcess.ServiceController sc = new System.ServiceProcess.ServiceController("AvukatproReminderService");
                        try
                        {
                            if (sc.Status == ServiceControllerStatus.Paused)
                                sc.Continue();
                            if (sc.Status != ServiceControllerStatus.Running)
                                sc.Start();
                        }
                        catch
                        { }
                    }
                    catch
                    { }
                }
            }
        }

        private static void InstallReminderService()
        {
            string startupPath = Application.StartupPath;
            string batchFile = Path.Combine(startupPath, "installRemindersrv.bat");
            string servicePath = Path.Combine(startupPath, "Avukatpro.Reminder.exe");
            string dllPath = Path.Combine(startupPath, "SMSMakinesi.dll");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"@ECHO OFF");
            sb.AppendLine("REM The following directory is for .NET 2.0");
            sb.AppendLine("set DOTNETFX2=%SystemRoot%\\Microsoft.NET\\Framework\\v2.0.50727");
            sb.AppendLine("set PATH=%PATH%;%DOTNETFX2%");
            sb.AppendLine("echo Registering SMSMakinesi dll...");
            sb.AppendLine("echo ---------------------------------------------------");
            sb.AppendLine(String.Format("Regsvr32 /s \"{0}\"", dllPath));
            sb.AppendLine("echo ---------------------------------------------------");
            sb.AppendLine("echo Installing AvukatproReminder Service...");
            sb.AppendLine("echo ---------------------------------------------------");
            sb.AppendLine(String.Format("InstallUtil /i \"{0}\"", servicePath));
            sb.AppendLine("echo ---------------------------------------------------");
            sb.AppendLine("echo Done.");

            File.WriteAllText(batchFile, sb.ToString());
            Process p = new Process();

            p.StartInfo = new ProcessStartInfo(batchFile);
            p.StartInfo.CreateNoWindow = true;
            try
            {
                p.Start();
                p.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Servis kurulumu sırasında hata oluştu.\r\nHata: {0}", ex.Message));
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///
        [STAThread]
        private static void Main(string[] args)
        {
            bool isCreated;

            int count = args.Count();
            if (count > 0)
            {
                try
                {
                    KullaniciAdi = args[0].Trim().ToString();
                    girisYapilmis = true;
                }
                catch { }
            }
            else
                girisYapilmis = false;

            DevExpress.XtraScheduler.Localization.SchedulerLocalizer.Active = new SchLocalizer();
            DevExpress.XtraScheduler.Localization.SchedulerExtensionsLocalizer.Active = new SchExtensionsLocalizer();
            DevExpress.XtraScheduler.Localization.SchedulerExtensionsResLocalizer.Active = new SchExtensionsResLocalizer();
            DevExpress.XtraScheduler.Localization.SchedulerResLocalizer.Active = new SchResLocalizer();

            AsistanTray.sharedMutex = new Mutex(false, "OnceApplication", out isCreated);
            if (!isCreated)
            {
                //MessageBox.Show("Bu programın bir örneği zaten çalışıyor");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //try
            //{
            Isler.dbAsistan = new LinqDAL.DbAsistanDataContext(Connection.ConStr);

            AsistanTray mn = new AsistanTray();

            if (args.Count() > 0)
            {
                mn.Visible = false;
            }

            bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(bgw_DoWork); //SMS E-mail FAX WinService Kurulumu ve Kontrolü
            if (!bgw.IsBusy)
                bgw.RunWorkerAsync();

            Application.Run(new AsistanTray());
        }
    }
}