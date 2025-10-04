using System;
using System.Windows.Forms;

namespace AvukatPro.Database
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Helper.List = AvukatProLib.CompInfo.CompInfoListGetir();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}