using System;

namespace AvukatProLib.LisansYonetimi
{
    public class License : LicenseBase
    {
        public License()
        {
            PrivateKey = PassPhrase.PrivateKey;
        }

        public License(string p_strPrivateKey)
            : base(p_strPrivateKey)
        {
        }

        private static int localMachineCode = -1;
        private string m_strPrivateKey;

        public enum FeaturesUnlocked
        {
            Feature1 = 2,
            Feature2 = 4,
            Feature3 = 8,
            Feature4 = 16,
            Feature5 = 32
        }

        public int LocalMachineCode
        {
            get
            {
                try
                {
                    if (localMachineCode != -1) return localMachineCode;

                    //string str = Util.GetSetting(modGlobals.applicationName, "SavedSettings", "MachineKey", "");
                    //try
                    //{
                    //    str = this.DecryptMD5(str, PP.PP1);
                    //}
                    //catch (Exception)
                    //{
                    //    str = string.Empty;
                    //}
                    //if (string.IsNullOrEmpty(str))
                    //{
                    DiskInfo diskInformation = HardwareInfo.GetDiskInformation();
                    string str2 = LicenseBase.Encrypt_GP(diskInformation.Signature + diskInformation.Size + diskInformation.SystemName);
                    if (!string.IsNullOrEmpty(str2))
                    {
                        localMachineCode = Convert.ToInt32(str2);
                    }

                    //    Util.SaveSetting(modGlobals.applicationName, "SavedSettings", "MachineKey", this.EncryptMD5(str2, PP.AVP));
                    return localMachineCode;
                    //}
                    //num = Convert.ToInt32(str);
                }
                catch (Exception)
                {
                }
                return localMachineCode;
            }
        }

        public string PrivateKey
        {
            get
            {
                //    return this.m_strPrivateKey;
                return base.PublicKey;
            }
            set
            {
                this.m_strPrivateKey = value;
                base.PublicKey = value;
            }
        }

        internal int Makers
        {
            get
            {
                return base.Makers;
            }
        }

        public string DecryptMD5(string p_strTextToDecrypt, string p_strSaltValue)
        {
            return base.DecryptMD5(p_strTextToDecrypt, p_strSaltValue);
        }

        public byte[] DecryptMD5_Byte(byte[] p_strDataToEncrypt, string p_strSaltValue, int p_intFileBufferLength)
        {
            return base.DecryptMD5_Byte(p_strDataToEncrypt, p_strSaltValue, p_intFileBufferLength);
        }

        public string Encrypt(string plainText, int p_intUnlockCode)
        {
            return base.Encrypt(plainText, p_intUnlockCode);
        }

        public string EncryptMD5(string p_strTextToEncrypt, string p_strSaltValue)
        {
            return base.EncryptMD5(p_strTextToEncrypt, p_strSaltValue);
        }

        public string GetLetter(int p_intNumber, int p_intSeries)
        {
            return base.GetLetter(p_intNumber, p_intSeries);
        }

        public string GetRandomLetter()
        {
            return base.GetRandomLetter();
        }

        public string GetUnRandomLetter(string p_UnLetter)
        {
            return base.GetUnRandomLetter(p_UnLetter);
        }

        public string MakeDemoKey(string p_strPrivateKey, int p_intDays, FeaturesUnlocked p_intUnlockCode)
        {
            return base.MakeDemoKey(p_strPrivateKey, p_intDays, p_intUnlockCode);
        }

        public ValidatedKey ValidateKey(string EncryptedString)
        {
            ValidatedKey key = base.ValidateKey(EncryptedString, this.LocalMachineCode);
            if (key != null)
            {
                key.MachineCode = this.LocalMachineCode;
            }
            return key;
        }

        public ValidatedKey ValidateKey(string EncryptedString, int p_intMachineCode)
        {
            ValidatedKey key = base.ValidateKey(EncryptedString, p_intMachineCode);
            if (key != null)
            {
                key.MachineCode = this.LocalMachineCode;
            }
            return key;
        }

        internal string Encrypt_GP(string p_strPublicKey)
        {
            return LicenseBase.Encrypt_GP(p_strPublicKey);
        }

        internal byte[] EncryptMD5_Byte(byte[] p_strDataToEncrypt, string p_strSaltValue)
        {
            return base.EncryptMD5_Byte(p_strDataToEncrypt, p_strSaltValue);
        }
    }
}