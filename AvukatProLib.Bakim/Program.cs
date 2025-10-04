using AvukatProLib.DbBackup;
using System;
using System.Windows.Forms;

namespace AvukatProLib.Bakim
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new rfrmMain());
            //Application.Run(new frmDbUpdate());

            #region Dominse

            string _sirketNfo = Application.StartupPath + "\\cmpnfo3.gio";

            //if (File.Exists(_sirketNfo))
            //{
            //   Impersonation imp = new Impersonation();
            //    List<CompInfo> compList = CompInfo.CompInfoListGetir();
            //    if (compList[0].ConnectionTip == (int)AvukatProLib.Extras.ConnectionTip.Domain_Server)
            //    {
            //        string kullanici = compList[0].VeriTabanýKullanicisi.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries)[1];
            //        string DomainAdi = compList[0].VeriTabanýKullanicisi.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries)[0];
            //        string pswrd = compList[0].VeriTabaniKullaniciSfr;
            //        if (imp.impersonateValidUser(kullanici, DomainAdi, pswrd))
            //        {
            //        }
            //    }
            //}

            #endregion Dominse

            if (args.Length > 0)
            {
                string islemTipi = args[0].Replace("-", "").Trim();
                switch (islemTipi)
                {
                    case "DbUpdate":
                        Application.Run(new frmDbUpdate());
                        break;

                    case "DbRestore":
                        Application.Run(new frmRestore());
                        break;

                    case "KurumsalMod":
                        Application.Run(new frmModDuzenleme());
                        break;

                    default:
                        Application.Run(new rfrmMain());
                        break;
                }
            }
            else
            {
                Application.Run(new rfrmMain());
            }
        }
    }
}