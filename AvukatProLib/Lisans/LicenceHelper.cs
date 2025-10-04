using AvukatProLib.Util;
using System;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace AvukatProLib.Lisans
{
    public static class LicenseHelper
    {
        private static string pwdString = "Aklmklmlk+%2312mlkmasdlşöm";

        public static bool CompareMachineCode(string productKey, string machineCodeToCompare)
        {
            return GetMachineCode(productKey) == machineCodeToCompare;
        }

        public static string DecryptLicence(string licence)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(licence);

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(pwdString));
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static string EncyptLicence(string licence)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(licence);

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(pwdString));
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string GetMachineCode(string productKey)
        {
            string deviceId = LicenseHelper.GetDiskDriveProperty("DeviceID");
            string caption = LicenseHelper.GetDiskDriveProperty("Caption");
            string model = LicenseHelper.GetDiskDriveProperty("Model");
            string size = LicenseHelper.GetDiskDriveProperty("Size");
            string serialNumber = LicenseHelper.GetDiskDriveProperty("SerialNumber");
            if (String.IsNullOrEmpty(serialNumber))
                serialNumber = LicenseHelper.GetPhysicalMediaProperty("SerialNumber", "WHERE Tag LIKE " + deviceId + "");
            string machineCode1 = String.Format("{0}A{1}V{2}P{5}R{3}O{4}", deviceId, caption, model, size, serialNumber, productKey);
            string machineCode2 = HashTool.CalculateMD5Hash(machineCode1);
            return machineCode2;
        }

        internal static string GetDiskDriveProperty(string propertyName)
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                int k = 0;
                foreach (ManagementObject wmi_HD in searcher.Get())
                {
                    k++;

                    foreach (PropertyData str in wmi_HD.Properties)
                    {
                        if (str.Name == propertyName)
                        {
                            return wmi_HD.GetPropertyValue(str.Name).ToString();
                        }
                    }

                    if (k == 1)
                        break;
                }
            }
            catch (Exception ex)
            {
                HataVer_LisansLog(ex, "GetDiskDriveProperty(\"" + propertyName + "\")");
            }
            return string.Empty;
        }

        internal static string GetPhysicalMediaProperty(string propertyName, string query)
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
                int k = 0;
                foreach (ManagementObject wmi_HD in searcher.Get())
                {
                    k++;

                    foreach (PropertyData str in wmi_HD.Properties)
                    {
                        if (str.Name == propertyName)
                        {
                            if (wmi_HD.GetPropertyValue(str.Name) != null)
                                return wmi_HD.GetPropertyValue(str.Name).ToString();
                        }
                    }

                    if (k == 1)
                        break;
                }
            }
            catch (Exception ex)
            {
                HataVer_LisansLog(ex, "GetDiskDriveProperty(\"" + propertyName + "\")");
            }
            return string.Empty;
        }

        private static void HataVer_LisansLog(Exception ex, string MethodAdi)
        {
            try
            {
                StreamWriter sW = File.CreateText(Application.StartupPath + "\\Licence.log");

                sW.WriteLine("---------- / " + DateTime.Now.ToString() + " / ----------");
                sW.WriteLine("Metod Adı: " + MethodAdi);
                sW.WriteLine("Exception: " + ex.ToString());
                sW.WriteLine("---------- / " + DateTime.Now.ToString() + " / ----------");
                sW.WriteLine();
                sW.Close();
            }
            catch (Exception exec)
            {
                MessageBox.Show("Dosya yolu yazma hatası" + Environment.NewLine + exec.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}