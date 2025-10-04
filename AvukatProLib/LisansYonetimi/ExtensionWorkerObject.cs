using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AvukatProLib.LisansYonetimi
{
    public class ExtensionWorkerObject
    {
        public ExtensionWorkerObject()
            : this(string.Empty)
        {
        }

        public ExtensionWorkerObject(string p_strApplicationDataPath)
        {
            this.m_strApplicationDataPath = string.Empty;
            this.m_strApplicationDataPath = p_strApplicationDataPath;
        }

        private const string mc_strPrivateKeyName = "PrivateKey";
        private const string mc_strpublicRegistrationKeyName = "SerialNumber";
        private const string mc_strSNFileName = "PG_SerialKeyMaker.key";
        private string m_strApplicationDataPath;

        public string ApplicationDataPath
        {
            get
            {
                return this.m_strApplicationDataPath;
            }
        }

        private string EncryptedPrivateKey
        {
            get
            {
                return "iPsYCVeZcT4hj1C+RF8zYh0IfqP0jF9AjQGucz11LM4=";
            }
        }

        private string NonPublicHex
        {
            get
            {
                return LicenseUtil.Reverse();
            }
        }

        private string PublicHex
        {
            get
            {
                return "hEj7z/TAdLZM5lirExLfjA==";
            }
        }

        public static string SafeString(object p_objObject)
        {
            string str2 = string.Empty;
            try
            {
                if (p_objObject != null)
                {
                    return (p_objObject as string);
                }
                str2 = string.Empty;
            }
            catch (Exception)
            {
                str2 = string.Empty;
            }
            return str2;
        }

        public byte[] DecryptFileData(byte[] p_bteData, string p_strKey, int p_intFileBufferLength)
        {
            License license = new License();
            return license.DecryptMD5_Byte(p_bteData, p_strKey, p_intFileBufferLength);
        }

        public string DecryptKey(string p_strEncryptedKey)
        {
            License license = new License();
            return license.DecryptMD5(p_strEncryptedKey, license.DecryptMD5(this.EncryptedPrivateKey, license.DecryptMD5(this.PublicHex, SafeString(this.NonPublicHex))));
        }

        public string EncodeFileString(string p_strFileString)
        {
            License license = new License();
            return license.Encrypt_GP(p_strFileString);
        }

        public byte[] EncryptFileData(byte[] p_bteData, string p_strKey)
        {
            License license = new License();
            return license.EncryptMD5_Byte(p_bteData, p_strKey);
        }

        public string EncryptKey(string p_strKey)
        {
            License license = new License();
            return license.EncryptMD5(p_strKey, license.DecryptMD5(this.EncryptedPrivateKey, license.DecryptMD5(this.PublicHex, SafeString(this.NonPublicHex))));
        }

        public List<string> GenerateKey(NewKeyProperties p_objKeyProperties, ref string p_strLastErrorText)
        {
            LicenseTool tool = new LicenseTool(this, p_objKeyProperties.PrivateKey);

            //if (p_objKeyProperties.UnlimitedDaysValid)
            //{
            //    p_objKeyProperties.DaysValid = tool.NumberOfDays();
            //}
            if (p_objKeyProperties.DaysValid < 1)
            {
                p_objKeyProperties.DaysValid = 1;
            }

            //if (p_objKeyProperties.DaysValid > tool.NumberOfDays())
            //{
            //    p_objKeyProperties.DaysValid = tool.NumberOfDays();
            //}
            //if ((p_objKeyProperties.DaysValid > 360) & !p_objKeyProperties.UnlimitedDaysValid)
            //{
            //    p_objKeyProperties.DaysValid = 360;
            //}
            List<string> list = tool.GenerateKeys(p_objKeyProperties);
            if (string.IsNullOrEmpty(p_strLastErrorText))
            {
                p_strLastErrorText = "No Errors";
            }
            return list;
        }

        public int GetMachineCode()
        {
            LicenseTool tool = new LicenseTool(this);
            return tool.LocalMachineCode;
        }

        public ValidatedKey GetValidatedKey(string p_strPrivateKey, string p_strKey, [Optional, DefaultParameterValue(0)] int p_intMachineCode)
        {
            LicenseTool tool = new LicenseTool(this, p_strPrivateKey);
            return tool.ValidateKey(p_strKey, p_intMachineCode);
        }

        public ValidatedKey GetValidatedKeyByKey(string p_strKey)
        {
            ValidatedKey key2;
            try
            {
                if (!string.IsNullOrEmpty(p_strKey))
                {
                    License license = new License();
                    return this.GetValidatedKey(license.DecryptMD5(this.EncryptedPrivateKey, license.DecryptMD5(this.PublicHex, SafeString(this.NonPublicHex))), p_strKey, 0);
                }
                key2 = null;
            }
            catch (Exception)
            {
                key2 = null;
            }
            return key2;
        }

        public ValidatedKey GetValidatedKeyFromRegistry()
        {
            ValidatedKey key2 = null;
            string encryptedPrivateKey = string.Empty;
            string str = string.Empty;
            string str4 = string.Empty;
            string str3 = string.Empty;
            try
            {
                encryptedPrivateKey = this.EncryptedPrivateKey;
                str = LicenseUtil.GetSetting(modGlobals.applicationName, modGlobals.gc_strSaveSectionName, "SerialNumber", "Unknown");
            }
            catch (Exception)
            {
            }
            try
            {
                License license = new License();

                //   str4 = license.DecryptMD5(encryptedPrivateKey, license.DecryptMD5(this.PublicHex, SafeString(this.NonPublicHex)));
                //   str3 = license.DecryptMD5(str, str4);
                str3 = license.DecryptMD5(str, license.PrivateKey);
                key2 = this.GetValidatedKey(license.PrivateKey, str3, license.LocalMachineCode);
            }
            catch (Exception)
            {
                key2 = null;
            }
            return key2;
        }

        public string ReadHashedKey()
        {
            string str2 = string.Empty;
            string str3 = string.Empty;
            try
            {
                str2 = LicenseUtil.GetSetting(modGlobals.applicationName, modGlobals.gc_strSaveSectionName, "PrivateKey", "Unknown");
                LicenseTool tool = new LicenseTool(this, "Somr!240003%");
                str3 = tool.Decryptpublicly(str2, tool.Decryptpublicly(this.PublicHex, SafeString(this.NonPublicHex)));
            }
            catch (Exception)
            {
                str3 = null;
            }
            return str3;
        }

        public bool SaveEncryptedKeyToRegistry(string encryptedSerialNumber)
        {
            bool flag = false;
            string setting = string.Empty;
            try
            {
                LicenseUtil.SaveSetting(modGlobals.applicationName, modGlobals.gc_strSaveSectionName, "SerialNumber", encryptedSerialNumber);
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }

        public void SaveHashedKey(string p_strPrivateKey)
        {
            try
            {
                LicenseTool tool = new LicenseTool(this, p_strPrivateKey);
                string setting = tool.Encryptpublicly(p_strPrivateKey, tool.DecryptMD5(this.PublicHex, SafeString(this.NonPublicHex)));
                LicenseUtil.SaveSetting(modGlobals.applicationName, modGlobals.gc_strSaveSectionName, "PrivateKey", setting);
            }
            catch (Exception)
            {
            }
        }

        public bool SaveKeyToRegistryEncrypted(string p_strpublicSerialKey)
        {
            bool flag = false;
            string setting = string.Empty;
            try
            {
                //        setting = this.EncryptKey(p_strpublicSerialKey);
                License license = new License();
                setting = license.EncryptMD5(p_strpublicSerialKey, license.PrivateKey);
                flag = SaveEncryptedKeyToRegistry(setting);
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }
    }
}