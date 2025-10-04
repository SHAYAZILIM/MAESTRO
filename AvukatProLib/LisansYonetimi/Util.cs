using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AvukatProLib.LisansYonetimi
{
    public static class LicenseUtil
    {
        private static ExtensionWorkerObject extensionWorkerObject = new ExtensionWorkerObject();
        private static License license = new License();

        public static int Asc(char String)
        {
            if (((int)String) < 0x80)
            {
                return (int)String;
            }
            char[] charBuf = new char[] { String };
            byte[] byteBuf = Encoding.Default.GetBytes(charBuf);
            if (byteBuf.Length == 0)
            {
                return 0;
            }
            else if (byteBuf.Length == 1)
            {
                return byteBuf[0];
            }
            else
            {
                return (int)(short)((byteBuf[0] << 8) | byteBuf[1]);
            }
        }

        public static int Asc(String String)
        {
            if (String == null || String.Length == 0)
            {
                throw new ArgumentException("Empty string");
            }
            return Asc(String[0]);
        }

        public static bool CheckInternetConnection()
        {
            Uri Url = new System.Uri("http://www.google.com");
            System.Net.WebRequest WebReq;
            System.Net.WebResponse Resp;
            WebReq = System.Net.WebRequest.Create(Url);
            try
            {
                Resp = WebReq.GetResponse();
                Resp.Close();
                WebReq = null;
                return true;
            }
            catch
            {
                WebReq = null;
                return false;
            }
        }

        public static char Chr(int CharCode)
        {
            byte[] byteBuf;
            char[] charBuf;
            if (CharCode >= 0 && CharCode <= 127)
            {
                return (char)CharCode;
            }
            else if (CharCode >= 128 && CharCode <= 255)
            {
                byteBuf = new byte[] { (byte)CharCode };
            }
            else if (CharCode >= -32768 && CharCode <= 65535)
            {
                byteBuf = new byte[] { (byte)(CharCode >> 8), (byte)CharCode };
            }
            else
            {
                throw new ArgumentException("Invalid character code.");
            }
            charBuf = Encoding.Default.GetChars(byteBuf);
            if (charBuf.Length == 0)
            {
                return '\u0000';
            }
            else
            {
                return charBuf[0];
            }
        }

        // Get a particular registry setting.
        public static String GetSetting(String AppName, String Section, String Key, String Default)
        {
            String subkey = GetKey(AppName, Section);
            RegistryKey key = Registry.CurrentUser.OpenSubKey(subkey);
            try
            {
                return key.GetValue(Key, Default).ToString();
            }
            catch
            {
                return "";
            }
            finally
            {
                if (key != null) key.Close();
            }
        }

        public static int InStr(String String1, String String2, [Optional][DefaultValue(0)] int Compare)
        {
            return InStr(1, String1, String2, Compare);
        }

        public static int InStr(int Start, String String1, String String2, int Compare)
        {
            if (Start < 1)
            {
                throw new ArgumentException("Invalid string index", "Start");
            }
            if (String1 == null || String1.Length == 0)
            {
                return 0;
            }
            if (String2 == null || String2.Length == 0)
            {
                return Start;
            }
            if (Start >= String1.Length)
            {
                return 0;
            }
            if (Compare == 0)
            {
                return (CultureInfo.CurrentCulture.CompareInfo.IndexOf(String1, String2, Start - 1, CompareOptions.Ordinal) + 1);
            }
            else
            {
                return (CultureInfo.CurrentCulture.CompareInfo.IndexOf(String1, String2, Start - 1, CompareOptions.IgnoreWidth | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreCase) + 1);
            }
        }

        public static bool IsDate(Object VarName)
        {
            if (VarName is DateTime)
            {
                return true;
            }
            else if (VarName is String)
            {
                try
                {
                    Convert.ToDateTime((String)VarName);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static string Left(string param, int length)
        {
            if (param.Length <= length)
            {
                return param;
            }
            return param.Substring(0, length);
        }

        public static void LicenseControl(CompInfo compInfo)
        {
            ValidatedKey validatedKey = AvukatProLib.LisansYonetimi.LicenseUtil.ValidateLicense(compInfo.LisansBilgisi.ProductKey);
            string registryKey = LicenseUtil.GetSetting(modGlobals.applicationName, modGlobals.gc_strSaveSectionName, "SerialNumber", "Unknown");
            ValidatedKey fromRegistry = null;
            if (!String.IsNullOrEmpty(registryKey)) fromRegistry = AvukatProLib.LisansYonetimi.LicenseUtil.ValidateLicense(registryKey);

            frmLicenseWarning licenseWarning;
            if (validatedKey == null || !validatedKey.MachineCodeValidates || validatedKey.Key == "Invalid")
            {
                licenseWarning = new frmLicenseWarning("Uygulama lisansı bulunamadı.\r\nÜrün aktivasyonu için lütfen Avukatpro destek ekibiyle iletişime geçiniz.");
                licenseWarning.ShowDialog();
            }
            else if (!validatedKey.IsCurrentlyValid)
            {
                if (validatedKey.DateValidThrough.Subtract(validatedKey.DateCreated).Days <= 30) //Demo lisans
                {
                    licenseWarning = new frmLicenseWarning("Demo kullanım süreniz sona erdi.\r\nLisans satın almak için lütfen Avukatpro destek ekibiyle iletişime geçiniz.", compInfo.LisansBilgisi.ProductKey);
                    licenseWarning.ShowDialog();
                }
                else
                {
                    licenseWarning = new frmLicenseWarning("Lisans süreniz sona erdi.\r\nOtomatik Uygulama ve Cetvel güncelleme işlemlerinden faydalanabilmek için Bakım sözleşmesini yenilemeniz gerekmektedir.", compInfo.LisansBilgisi.ProductKey, false);
                    if (compInfo.LisansBilgisi.PaketBilgileri == null || compInfo.LisansBilgisi.PaketBilgileri.Count() == 0 || compInfo.LisansBilgisi.PaketBilgileri[0].FormListesi.Count() == 0) licenseWarning.validationRequired = true;
                    licenseWarning.ShowDialog();
                }
            }
            else if (compInfo.LisansBilgisi.PaketBilgileri == null || compInfo.LisansBilgisi.PaketBilgileri.Count() == 0 || compInfo.LisansBilgisi.PaketBilgileri[0].FormListesi.Count() == 0)
            {
                licenseWarning = new frmLicenseWarning("Uygulama paket bilgileri bulunamadı.\r\nPaket bilgilerinin güncellenmesi için Avukatpro destek ekibiyle iletişime geçiniz.", compInfo.LisansBilgisi.ProductKey);
                licenseWarning.ShowDialog();
            }
            else // Geçerli lisans
            {
                if (fromRegistry == null)
                {
                    extensionWorkerObject.SaveKeyToRegistryEncrypted(validatedKey.Key + validatedKey.FreeformText);
                }

                // Registry'de kayıt varsa geçerli olup olmadığı kontrol ediliyor. Demo lisans anahtarıysa güncelleme yapılmayacak.
                // Gio dosyasındaki lisans anahtarı registry'deki anahtarla aynı değilse ve registry'deki anahtar demo bir anahtarsa gio dosyasındaki anahtar kontrol ediliyor.
                // Eğer gio dosyasındaki anahtarda yeni bir demo anahtarsa kayıta izin verilmiyor çünkü bir kullanıcı birden fazla demo kurulumu yapamaz.
                else if (fromRegistry.Key != validatedKey.Key && !fromRegistry.IsCurrentlyValid && (fromRegistry.DateValidThrough.Subtract(fromRegistry.DateCreated).Days <= 30))
                {
                    if (validatedKey.DateValidThrough.Subtract(validatedKey.DateCreated).Days <= 30) // Gio dosyasındaki anahtar demo bir anahtar
                    {
                        licenseWarning = new frmLicenseWarning("Demo kullanım süreniz sona erdi.\r\nLisans satın almak için lütfen Avukatpro destek ekibiyle iletişime geçiniz.", compInfo.LisansBilgisi.ProductKey);
                        licenseWarning.ShowDialog();
                    }
                    else // Gio dosyasında demo olmayan geçerli bir lisans anahtarı mevcut. Bu yeni değer registry'ye kaydediliyor
                        extensionWorkerObject.SaveKeyToRegistryEncrypted(validatedKey.Key + validatedKey.FreeformText);
                }
                else if (fromRegistry.IsCurrentlyValid && fromRegistry.DateValidThrough.Subtract(fromRegistry.DateCreated).Days <= 30)
                {
                    if (validatedKey.DateValidThrough.Subtract(validatedKey.DateCreated).Days > 30) // Registry'de demo bir anahtar varsa ve gio dosyasındaki anahtarda geçerli ve demo olmayan bir lisans anahtarıysa gio dosyasındaki anahtarı registry'ye kaydet.
                        extensionWorkerObject.SaveKeyToRegistryEncrypted(validatedKey.Key + validatedKey.FreeformText);
                    else if (validatedKey.DateValidThrough.Subtract(validatedKey.DateCreated).Days <= 30) //Hem registry'deki hem de gio dosyasındaki anahtarlar geçerli ve ikisi de demoysa registry'deki anahtarı gio dosyasına kaydet.
                    {
                        compInfo.LisansBilgisi.ProductKey = registryKey;
                        CompInfo.Kaydet(new List<CompInfo>() { compInfo });
                    }
                }
            }
        }

        public static string Mid(string Str, int Start)
        {
            if (Str == null)
            {
                return null;
            }
            else
            {
                return Mid(Str, Start, Str.Length);
            }
        }

        public static string Mid(string str, int Start, int Length)
        {
            if (Start <= 0)
            {
                throw new ArgumentException("Index must be greater than zero");
            }
            if (Length < 0)
            {
                throw new ArgumentException("Length must be greater than or equal to zero");
            }
            if ((Length == 0) || (str == null))
            {
                return "";
            }
            int length = str.Length;
            if (Start > length)
            {
                return "";
            }
            if ((Start + Length) > length)
            {
                return str.Substring(Start - 1);
            }
            return str.Substring(Start - 1, Length);
        }

        public static string Right(string param, int length)
        {
            if (param.Length <= length)
            {
                return param;
            }
            return param.Substring(param.Length - length, length);
        }

        // Save a particular registry setting.
        public static void SaveSetting(String AppName, String Section, String Key, String Setting)
        {
            String subkey = GetKey(AppName, Section);
            RegistryKey key = Registry.CurrentUser.CreateSubKey(subkey);
            try
            {
                key.SetValue(Key, Setting);
            }
            finally
            {
                key.Close();
            }
        }

        public static int UBound(Array Array, int Rank)
        {
            if (Array == null)
            {
                throw new ArgumentNullException("Array");
            }
            else if (Rank < 1 || Rank > Array.Rank)
            {
                throw new RankException("Invalid rank");
            }
            else
            {
                return Array.GetUpperBound(Rank - 1);
            }
        }

        /// <summary>
        /// Verilen lisans anahtarının geçerli olup olmadığının kontrolünü yapar.
        /// </summary>
        /// <param name="licenseKey">Lisans anahtarı</param>
        /// <returns></returns>
        public static ValidatedKey ValidateLicense(string licenseKey)
        {
            if (String.IsNullOrEmpty(licenseKey)) return null;
            return extensionWorkerObject.GetValidatedKey(license.PrivateKey, licenseKey, license.LocalMachineCode);
        }

        internal static string Reverse()
        {
            char[] strArray = "!m@rcH2010".ToCharArray();
            Array.Reverse(strArray);
            return new string(strArray);
        }

        // Get the registry key corresponding to an app and section.
        private static String GetKey(String AppName, String Section)
        {
            String subkey;
            subkey = "Software\\Avukatpro Yazilim Ltd.";
            if (AppName != null && AppName.Length != 0)
            {
                subkey += "\\";
                subkey += AppName;
                if (Section != null && Section.Length != 0)
                {
                    subkey += "\\";
                    subkey += Section;
                }
            }
            return subkey;
        }
    }
}