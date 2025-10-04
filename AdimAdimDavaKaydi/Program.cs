using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Util;
using Microsoft.Win32;

namespace AdimAdimDavaKaydi
{
    internal static class Program
    {
        //deneme2_2
        //deneme1
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static frmIntro myMainForm;

        private static Process proc;

        private static Dictionary<int, string> processId2MemoryProcessName = new Dictionary<int, string>();

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", (Exception)e.ExceptionObject);
        }


        [STAThread]
        private static void Main(string[] args)
        {
            proc = Process.GetCurrentProcess();
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            #region Koczere exe verilirken açýlacak

            #region Dominse

            //Impersonation imp = new Impersonation();
            //List<CompInfo> compList = CompInfo.CompInfoListGetir();
            //if (compList[0].ConnectionTip == (int) AvukatProLib.Extras.ConnectionTip.Domain_Server)
            //{
            //    string kullanici =
            //        compList[0].VeriTabanýKullanicisi.Split(new[] {'\\'}, StringSplitOptions.RemoveEmptyEntries)[1];
            //    string DomainAdi =
            //        compList[0].VeriTabanýKullanicisi.Split(new[] {'\\'}, StringSplitOptions.RemoveEmptyEntries)[0];
            //    string pswrd = compList[0].VeriTabaniKullaniciSfr;
            //    if (imp.impersonateValidUser(kullanici, DomainAdi, pswrd))
            //    {
            //    }
            //}

            #endregion Dominse

            #endregion Koczere exe verilirken açýlacak

            #region Kapanan Kodlar

            DevExpress.UserSkins.OfficeSkins.Register(); // <<<<<<<<<<<<
            DevExpress.UserSkins.BonusSkins.Register(); //<<<<<<<<<<<<
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.EnableVisualStyles();

            #endregion Kapanan Kodlar

            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;

            #region Skin Ayarlarý

            //DevExpress.Skins.SkinManager.DisableFormSkins();

            #endregion Skin Ayarlarý

            #region Açýlýþ Formunun Kontrolü

            try
            {

                RegistryKey reg = Registry.LocalMachine.
                                  OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                //reg.CreateSubKey("Asistan");
                
                // set value of "abc" to "efd" 
                reg.SetValue("Asistan", Path.Combine(Application.StartupPath, "Asistan.exe"), RegistryValueKind.String);

                // get value of "abc"; return 0 if value not found 
                string value = (string)reg.GetValue("abc", "0");


            }
            catch { }

            //timer kapatýldý
            //System.Timers.Timer tmr = new System.Timers.Timer(2000);            
            //tmr.Elapsed += new System.Timers.ElapsedEventHandler(tmr_Elapsed);
            //tmr.Start();
            myMainForm = new frmIntro();
            if (args.Length > 0 && args[0].StartsWith("-"))
            {
                if (args.Length > 1)
                {
                    string islemTipi = args[0].Replace("-", "").Trim();
                    string dosyaYolu = args[1].Trim();

                    if (!String.IsNullOrEmpty(islemTipi) && !String.IsNullOrEmpty(dosyaYolu))
                    {
                        switch (islemTipi)
                        {
                            case "DavaTakip":
                                frmIntro.AcilisSekli = Kisayol.AcilisSekli.DavaTakip;
                                break;

                            case "Editor":
                                frmIntro.AcilisSekli = Kisayol.AcilisSekli.Editor;
                                break;

                            case "IcraTakip":
                                frmIntro.AcilisSekli = Kisayol.AcilisSekli.IcraTakip;
                                break;

                            case "SorusturmaTakip":
                                frmIntro.AcilisSekli = Kisayol.AcilisSekli.SorusturmaTakip;
                                break;

                            case "isKayit":
                                frmIntro.AcilisSekli = Kisayol.AcilisSekli.Is;
                                break;
                            default:
                                frmIntro.AcilisSekli = Kisayol.AcilisSekli.Normal;
                                break;
                        }
                        myMainForm.AcilacakDosyaYolu = dosyaYolu;
                        myMainForm.StartUpParams = args;
                    }
                    if (!myMainForm.IsDisposed)
                        Application.Run(myMainForm);
                }
                if (!myMainForm.IsDisposed)
                    Application.Run(myMainForm);
            }
            else if (args.Length > 0)
            {
                FileInfo fInfo = new FileInfo(args[0]);
                if (fInfo.Exists)
                {
                    frmIntro.AcilisSekli = Kisayol.GetAcilisSekli(fInfo.Extension);
                    myMainForm.AcilacakDosyaYolu = fInfo.FullName;
                }
                if (!myMainForm.IsDisposed)
                    Application.Run(myMainForm);
            }
            else
            {
                if (!myMainForm.IsDisposed)
                    Application.Run(myMainForm);
            }

            #endregion Açýlýþ Formunun Kontrolü
        }
    }
}