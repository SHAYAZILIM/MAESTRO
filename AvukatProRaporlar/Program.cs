using AvukatProLib;
using AvukatProRaporlar.Forms;
using AvukatProRaporlar.Raport.Util;
using RaporDataSource.TableDB;
using RaporDataSource.ViewDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AvukatProRaporlar
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static string acilacakRapor;

        public static List<CompInfo> compList;

        public static DBDataContext db;

        public static AvukatProViewDataContext dbV;

        public static string diziArg;

        public static DateTime dovizGuncel;

        public static bool girisYapilmis;

        private static System.ComponentModel.BackgroundWorker bw = new System.ComponentModel.BackgroundWorker();

        private static bool bwEntered = false;

        private static void Application_Idle(object sender, EventArgs e)
        {
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += delegate
            {
                if (!String.IsNullOrEmpty(diziArg))
                {
                    var ks = dbV.TDI_BIL_KULLANICI_SUBE_BILGILERIs.Count();
                    var kullanici = db.TDI_BIL_KULLANICI_LISTESIs.Where(vi => vi.CARI_ID == Int32.Parse(diziArg));
                    AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi = (kullanici.First() as TDI_BIL_KULLANICI_LISTESI);
                    girisYapilmis = true;
                }
                else
                {
                    var kt = db.TDIE_BIL_KULLANICI_SUBELERIs.Count();
                    var kk = dbV.TDI_BIL_KULLANICI_SUBE_BILGILERIs.Count();
                    girisYapilmis = false;
                }

                bwEntered = true;
            };
            bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            if (!bw.IsBusy && !bwEntered) bw.RunWorkerAsync();
        }

        private static void bw_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Application.Idle -= Application_Idle;
        }

        [STAThread]
        private static void Main(params string[] dizi)
        {
            #region Dominse

            //Impersonation imp = new Impersonation();
            compList = CompInfo.CompInfoListGetir();
            int count = dizi.Count();
            if (count > 0)
            {
                diziArg = dizi[0];
                if (count > 1)
                {
                    acilacakRapor = dizi[1];
                }
                girisYapilmis = true;
            }

            //if (compList[0].ConnectionTip == (int)AvukatProLib.Extras.ConnectionTip.Domain_Server)
            //{
            //string kullanici = compList[0].VeriTabanıKullanicisi.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries)[1];
            //    string DomainAdi = compList[0].VeriTabanıKullanicisi.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries)[0];
            //    string pswrd = compList[0].VeriTabaniKullaniciSfr;
            //   if (imp.impersonateValidUser(kullanici, DomainAdi, pswrd))
            // {
            // }
            //}

            #endregion Dominse

            Application.Idle += new EventHandler(Application_Idle);

            Console.WriteLine("" + dizi.Count());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Connection con = new Connection();
            if (con.MyConnection == null)
            {
                con.MyConnection = compList[0].ConStr;
                db = new DBDataContext(con.MyConnection);
                dbV = new AvukatProViewDataContext(con.MyConnection);
            }
            else
            {
                db = new DBDataContext(con.MyConnection);
                dbV = new AvukatProViewDataContext(con.MyConnection);
            }

            frmMain mn = new frmMain();

            Application.Run(mn);
        }
    }

    /// <summary>
    ///  We inherit from WindowsFormApplicationBase which contains the logic for the application model, including
    ///  the single-instance functionality.
    /// </summary>
    //class App : Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
    //{C
    //    public App()
    //    {
    //        this.IsSingleInstance = true; // makes this a single-instance app
    //        this.EnableVisualStyles = true; // C# windowsForms apps typically turn this on.  We'll do the same thing here.
    //        this.ShutdownStyle = Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses; // the vb app model supports two different shutdown styles.  We'll use this one for the sample.
    //    }

    // /// <summary> /// This is how the application model learns what the main form is ///
    // </summary> protected override void OnCreateMainForm() { this.MainForm = new Form1(); }

    // /// <summary> /// Gets called when subsequent application launches occur. The subsequent app
    // launch will result in this function getting called /// and then the subsequent instances will
    // just exit. You might use this method to open the requested doc, or whatever /// </summary>
    // /// <param name="eventArgs"></param> protected override void
    // OnStartupNextInstance(Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs
    // eventArgs) { base.OnStartupNextInstance(eventArgs); System.Windows.Forms.MessageBox.Show("An
    // attempt to launch another instance of this app was made"); }
    //}
}