using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AvukatProLib.LisansYonetimi
{
    public abstract class LicenseBase
    {
        internal LicenseBase()
        {
            this.m_strPassPhrase = PassPhrase.AVP;
            this.m_strHashAlgorithm = PassPhrase.MD5;
            this.m_strPasswordIterations = 2;
            this.m_strInitVector = PassPhrase.IV;
            this.m_intKeySize = 128;
            this.m_strPrivateKey = PassPhrase.PrivateKey;
            this.m_arMatrixLetters = new string[11, 4, 5];
        }

        internal LicenseBase(string p_strPrivateKey)
        {
            this.m_strPassPhrase = PassPhrase.AVP;
            this.m_strHashAlgorithm = PassPhrase.MD5;
            this.m_strPasswordIterations = 2;
            this.m_strInitVector = PassPhrase.IV;
            this.m_intKeySize = 128;
            this.m_strPrivateKey = string.Empty;
            this.m_arMatrixLetters = new string[11, 4, 5];
            if (string.IsNullOrEmpty(p_strPrivateKey))
            {
                throw new Exception("Invalid Private Key.");
            }
            this.m_strPrivateKey = LicenseUtil.Left(p_strPrivateKey, 25);
        }

        private const string c_strVERSION = "1.0.0.0";
        private static Random rand = new Random();
        private string[, ,] m_arMatrixLetters;
        private int m_intKeySize;
        private string m_strHashAlgorithm;
        private string m_strInitVector;
        private string m_strPassPhrase;
        private int m_strPasswordIterations;
        private string m_strPrivateKey;

        internal string[, ,] MatrixLetters
        {
            get
            {
                if (this.ArrayIsEmpty(this.m_arMatrixLetters))
                {
                    this.m_arMatrixLetters = this.SetMatrixLetters();
                }
                return this.m_arMatrixLetters;
            }
        }

        protected internal int Makers
        {
            get
            {
                return 999;
            }
        }

        protected internal string PublicKey
        {
            get
            {
                return this.m_strPrivateKey;
            }
            set
            {
                this.m_strPrivateKey = value;
            }
        }

        public static string Encrypt_GP(string p_strPublicKey)
        {
            int num3 = 0;
            string str2 = string.Empty;
            List<int> list = new List<int>();
            int num = 0;
            int num2 = 0;
            bool flag2 = false;
            bool flag = true;
            p_strPublicKey = LicenseUtil.Left(p_strPublicKey, 25);
            foreach (char ch in p_strPublicKey.ToCharArray())
            {
                list.Add(LicenseUtil.Asc(ch));
            }
            list.ForEach(item =>
                {
                    if (flag)
                    {
                        num3 = item;
                        flag = false;
                    }
                    if (flag2)
                    {
                        flag2 = false;
                        num += item;
                    }
                    else
                    {
                        flag2 = true;
                        num2 += item;
                    }
                });
            str2 = ((((2 * num) + (num2 + (num3 * 3))) + 64) * 11).ToString();
            return LicenseUtil.Right("00000" + str2, 5);
        }

        public string Encrypt(string plainText, int p_intUnlockCode)
        {
            string str2 = string.Empty;
            try
            {
                if (p_intUnlockCode <= 0)
                {
                    p_intUnlockCode = 0;
                }
                char[] chArray = plainText.ToCharArray();
                str2 = this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[0])), 2) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[1])), 0) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[2])), 0) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[3])), 3) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[4])), 2) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[5])), 1) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[14])), 3) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[6])), 1) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[7])), 3) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[8])), 3) + this.GetLetter(Convert.ToInt32(modMain.SafeStringVersion(chArray[9])), 1) + this.GetLetter(Convert.ToInt32(modMain.SafeStringVersion(chArray[10])), 0) + this.GetLetter(Convert.ToInt32(modMain.SafeStringVersion(chArray[11])), 2) + this.GetLetter(Convert.ToInt32(modMain.SafeStringVersion(chArray[12])), 3) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[13])), 3);

                //str2 = this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[0])), 2) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[1])), 0) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[2])), 0) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[3])), 3) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[4])), 2) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[5])), 1) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[6])), 3) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[7])), 1) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[8])), 3) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[9])), 3) + this.GetLetter(Convert.ToInt32(modMain.SafeStringVersion(chArray[10])), 1) + this.GetLetter(Convert.ToInt32(modMain.SafeStringVersion(chArray[11])), 0) + this.GetLetter(Convert.ToInt32(modMain.SafeStringVersion(chArray[12])), 2) + this.GetLetter(Convert.ToInt32(modMain.SafeStringVersion(chArray[13])), 3) + this.GetLetter(Convert.ToInt32(modMain.SafeString(chArray[14])), 3);
            }
            catch (Exception)
            {
                throw new Exception("Error Getting Letter");
            }
            try
            {
                str2 = this.FillString(str2, p_intUnlockCode);
            }
            catch (Exception)
            {
                throw new Exception("Error Doing FillString");
            }
            try
            {
                str2 = modMain.MakeReadable(str2);
            }
            catch (Exception)
            {
                throw new Exception("Error Doing MakeReadable");
            }
            return str2;
        }

        public string EncryptMD5(string plainText, string p_strSaltValue)
        {
            string str2 = string.Empty;
            try
            {
                byte[] rgbIV = Encoding.ASCII.GetBytes(this.m_strInitVector);
                byte[] rgbSalt = Encoding.ASCII.GetBytes(p_strSaltValue);
                byte[] buffer4 = Encoding.UTF8.GetBytes(plainText);
                PasswordDeriveBytes bytes = new PasswordDeriveBytes(this.m_strPassPhrase, rgbSalt, this.m_strHashAlgorithm, this.m_strPasswordIterations);
                int cb = 0;
                cb = (int)Math.Round((double)(((double)this.m_intKeySize) / 8.0));
                byte[] rgbKey = bytes.GetBytes(cb);
                RijndaelManaged managed = new RijndaelManaged();
                managed.Mode = CipherMode.CBC;
                ICryptoTransform transform = managed.CreateEncryptor(rgbKey, rgbIV);
                MemoryStream stream2 = new MemoryStream();
                CryptoStream stream = new CryptoStream(stream2, transform, CryptoStreamMode.Write);
                stream.Write(buffer4, 0, buffer4.Length);
                stream.FlushFinalBlock();
                byte[] inArray = stream2.ToArray();
                stream2.Close();
                stream.Close();
                str2 = Convert.ToBase64String(inArray);
            }
            catch (Exception)
            {
                str2 = null;
            }
            return str2;
        }

        public byte[] EncryptMD5_Byte(byte[] p_bteData, string p_strSaltValue)
        {
            byte[] buffer = null;
            try
            {
                byte[] rgbIV = Encoding.ASCII.GetBytes(this.m_strInitVector);
                byte[] rgbSalt = Encoding.ASCII.GetBytes(p_strSaltValue);
                byte[] buffer5 = p_bteData;
                PasswordDeriveBytes bytes = new PasswordDeriveBytes(this.m_strPassPhrase, rgbSalt, this.m_strHashAlgorithm, this.m_strPasswordIterations);
                int cb = 0;
                cb = (int)Math.Round((double)(((double)this.m_intKeySize) / 8.0));
                byte[] rgbKey = bytes.GetBytes(cb);
                RijndaelManaged managed = new RijndaelManaged();
                managed.Mode = CipherMode.CBC;
                ICryptoTransform transform = managed.CreateEncryptor(rgbKey, rgbIV);
                MemoryStream stream2 = new MemoryStream();
                CryptoStream stream = new CryptoStream(stream2, transform, CryptoStreamMode.Write);
                stream.Write(buffer5, 0, buffer5.Length);
                stream.FlushFinalBlock();
                buffer = stream2.ToArray();
                stream2.Close();
                stream.Close();
            }
            catch (Exception)
            {
            }
            return buffer;
        }

        internal string Decrypt(string EncryptedText)
        {
            EncryptedText = modMain.RemoveReadability(EncryptedText);
            EncryptedText = this.UnFillString(EncryptedText);
            char[] chArray = EncryptedText.ToCharArray();
            return this.UnSwitchLetter(modMain.SafeString(chArray[0]), 2).ToString() + this.UnSwitchLetter(modMain.SafeString(chArray[1]), 0).ToString() + this.UnSwitchLetter(modMain.SafeString(chArray[2]), 0).ToString() + this.UnSwitchLetter(modMain.SafeString(chArray[3]), 3).ToString() + this.UnSwitchLetter(modMain.SafeString(chArray[4]), 2).ToString() + this.UnSwitchLetter(modMain.SafeString(chArray[5]), 1).ToString() + this.UnSwitchLetter(modMain.SafeString(chArray[6]), 1).ToString() + this.UnSwitchLetter(modMain.SafeString(chArray[7]), 3).ToString() + this.UnSwitchLetter(modMain.SafeString(chArray[8]), 3).ToString() + this.UnSwitchLetter(modMain.SafeString(chArray[9]), 1).ToString() + this.UnSwitchLetter(modMain.SafeString(chArray[10]), 0).ToString() + this.UnSwitchLetter(modMain.SafeString(chArray[11]), 2).ToString() + this.UnSwitchLetter(modMain.SafeString(chArray[12]), 3).ToString() + this.UnSwitchLetter(modMain.SafeString(chArray[13]), 3).ToString() + this.UnSwitchLetter(modMain.SafeString(chArray[15]), 3).ToString();
        }

        internal string DecryptMD5(string cipherText, string p_strSaltValue)
        {
            string str2 = string.Empty;
            try
            {
                byte[] rgbIV = Encoding.ASCII.GetBytes(this.m_strInitVector);
                byte[] rgbSalt = Encoding.ASCII.GetBytes(p_strSaltValue);
                byte[] buffer = Convert.FromBase64String(cipherText);
                PasswordDeriveBytes bytes = new PasswordDeriveBytes(this.m_strPassPhrase, rgbSalt, this.m_strHashAlgorithm, this.m_strPasswordIterations);
                int cb = (int)Math.Round((double)(((double)this.m_intKeySize) / 8.0));
                byte[] rgbKey = bytes.GetBytes(cb);
                RijndaelManaged managed = new RijndaelManaged();
                managed.Mode = CipherMode.CBC;
                ICryptoTransform transform = managed.CreateDecryptor(rgbKey, rgbIV);
                MemoryStream stream2 = new MemoryStream(buffer);
                CryptoStream stream = new CryptoStream(stream2, transform, CryptoStreamMode.Read);
                byte[] buffer4 = new byte[buffer.Length + 1];
                int count = stream.Read(buffer4, 0, buffer4.Length);
                stream2.Close();
                stream.Close();
                str2 = Encoding.UTF8.GetString(buffer4, 0, count);
            }
            catch (Exception)
            {
                str2 = null;
            }
            return str2;
        }

        internal byte[] DecryptMD5_Byte(byte[] p_bteData, string p_strSaltValue, int p_intFileBufferLength)
        {
            CryptoStream stream = null;
            MemoryStream stream2 = null;
            byte[] buffer3 = null;
            try
            {
                byte[] rgbIV = Encoding.ASCII.GetBytes(this.m_strInitVector);
                byte[] rgbSalt = Encoding.ASCII.GetBytes(p_strSaltValue);
                byte[] buffer = p_bteData;
                PasswordDeriveBytes bytes = new PasswordDeriveBytes(this.m_strPassPhrase, rgbSalt, this.m_strHashAlgorithm, this.m_strPasswordIterations);
                int cb = (int)Math.Round((double)(((double)this.m_intKeySize) / 8.0));
                byte[] rgbKey = bytes.GetBytes(cb);
                RijndaelManaged managed = new RijndaelManaged();
                managed.Mode = CipherMode.CBC;
                ICryptoTransform transform = managed.CreateDecryptor(rgbKey, rgbIV);
                stream2 = new MemoryStream(buffer);
                stream = new CryptoStream(stream2, transform, CryptoStreamMode.Read);
            }
            catch (Exception)
            {
            }
            buffer3 = new byte[(p_intFileBufferLength - 1) + 1];
            try
            {
                if (stream != null)
                {
                    int num2 = stream.Read(buffer3, 0, p_intFileBufferLength);
                }
                if (stream2 != null)
                {
                    stream2.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
            }
            catch (Exception)
            {
            }
            return buffer3;
        }

        internal int GetFeatureCode(string p_strIN)
        {
            int num2 = 0;
            try
            {
                p_strIN = modMain.RemoveReadability(p_strIN);
                char[] array = p_strIN.ToCharArray();
                if ((array != null) && (LicenseUtil.UBound(array, 1) > 0))
                {
                    if (this.ValidateRandoms(modMain.SafeString(array[3]), modMain.SafeString(array[10])))
                    {
                        num2 = this.ReadFeatureCode(modMain.SafeString(array[3]));
                    }
                    return num2;
                }
            }
            catch (Exception)
            {
            }
            return num2;
        }

        internal string GetLetter(int p_intNumber, int p_intSeries)
        {
            int rndNumber = 0;
            rndNumber = this.GetRndNumber();
            if ((p_intNumber >= 0) && (p_intNumber <= 10) && (rndNumber >= 0) && (rndNumber <= 2) && (p_intSeries >= 0) && (p_intSeries <= 3))
            {
                return this.MatrixLetters[p_intNumber, rndNumber, p_intSeries];
            }
            return string.Empty;
        }

        internal string GetRandomLetter()
        {
            int seed = (Environment.TickCount & int.MaxValue);
            return LicenseUtil.Chr((short)'A' + new Random(seed).Next(26)).ToString();
        }

        internal string GetUnRandomLetter(string p_UnLetter)
        {
            int num = 0;
            num = LicenseUtil.Asc(p_UnLetter);
            return Convert.ToString(LicenseUtil.Chr((90 - num) + 65));
        }

        internal string MakeDemoKey(string p_strPrivateKey, int p_intNumberOfDays, License.FeaturesUnlocked p_intUnlockCode)
        {
            if (p_intNumberOfDays > 60)
            {
                p_intNumberOfDays = 60;
            }
            if (p_intNumberOfDays < 1)
            {
                p_intNumberOfDays = 1;
            }
            int num = modMain.SafeInteger(Encrypt_GP(p_strPrivateKey));
            string plainText = modMain.FixDate(DateTime.Now) + modMain.FixString(p_intNumberOfDays.ToString(), 3) + modMain.FixCompositeKey(num);
            return this.Encrypt(plainText, (int)p_intUnlockCode);
        }

        internal ValidatedKey ParseKey(string p_strEncryptedKey, int p_intMachineKey)
        {
            ValidatedKey key = new ValidatedKey();
            string str8 = string.Empty;
            string str = string.Empty;
            int num5 = 0;
            DateTime now = DateTime.Now;
            DateTime time = DateTime.Now.AddDays(-1.0);
            string str7 = string.Empty;
            string str2 = string.Empty;
            bool flag = false;
            int featureCode = 0;
            string str3 = string.Empty;
            int num = -1;
            int num2 = -1;
            int num4 = 0;
            string str6 = string.Empty;
            string encryptedText = string.Empty;
            string str4 = string.Empty;
            try
            {
                key.ValidVersion = "1.0.0.0";
                if (p_strEncryptedKey.Length > 23)
                {
                    str6 = this.DecryptMD5(p_strEncryptedKey, this.m_strPrivateKey);
                    if (string.IsNullOrEmpty(str6))
                    {
                        throw new Exception("Unable to determine key.");
                    }
                    encryptedText = str6.Substring(0, 23);
                    str4 = str6.Substring(23);
                }
                else
                {
                    encryptedText = p_strEncryptedKey;
                }
                key.FreeformText = str4;
                key.Key = encryptedText;
                str8 = this.Decrypt(encryptedText);
                str = LicenseUtil.Left(str8, 6);
                num5 = Convert.ToInt32(LicenseUtil.Mid(str8, 7, 4));
                str3 = LicenseUtil.Mid(str8, 11, 5);
                str7 = str.Substring(0, 2);
                str2 = str.Substring(2, 2);
                now = new DateTime(2000 + Convert.ToInt32(str.Substring(4, 2)), Convert.ToInt32(str7), Convert.ToInt32(str2));
                time = now.AddDays((double)num5);
                key.DateCreated = now;
                key.DateValidThrough = time;
                flag = this.RandomsMatch(encryptedText);
                if (flag)
                {
                    featureCode = this.GetFeatureCode(encryptedText);
                    key.Feature1 = this.MapFeatureCode(featureCode, 1);
                    key.Feature2 = this.MapFeatureCode(featureCode, 2);
                    key.Feature3 = this.MapFeatureCode(featureCode, 3);
                    key.Feature4 = this.MapFeatureCode(featureCode, 4);
                    key.Feature5 = this.MapFeatureCode(featureCode, 5);
                }
                try
                {
                    num = Convert.ToInt32(Encrypt_GP(this.m_strPrivateKey));
                }
                catch (Exception)
                {
                }
                num4 = p_intMachineKey;
                if (num4 <= 0)
                {
                    num4 = 0;
                }
                try
                {
                    num2 = Convert.ToInt32(str3);
                    key.PublicKeyValidates = (num2 == num) | (num2 == (num + num4));
                }
                catch (Exception)
                {
                    key.PublicKeyValidates = false;
                }
                key.MachineCodeValidates = key.PublicKeyValidates;

                //if (now.Subtract(time).Days == this.Makers)
                //{
                //    key.IsCurrentlyValid = flag & key.PublicKeyValidates;
                //    if (key.IsCurrentlyValid)
                //    {
                //        key.Expires = false;
                //    }
                //    else
                //    {
                //        key.Expires = true;
                //    }
                //}
                //else
                //{
                key.IsCurrentlyValid = (((DateTime.Compare(DateTime.Now, now) > 0) & (DateTime.Compare(DateTime.Now, time) < 0)) & flag) & key.PublicKeyValidates;
                key.Expires = true;

                //}
                if (!key.IsCurrentlyValid)
                {
                    //key.DateCreated = DateTime.Now;
                    //key.DateValidThrough = DateTime.Now.AddDays(-1.0);
                    key.IsCurrentlyValid = false;
                    key.Expires = true;
                    key.PublicKeyValidates = false;
                    key.Feature1 = false;
                    key.Feature2 = false;
                    key.Feature3 = false;
                    key.Feature4 = false;
                    key.Feature5 = false;
                }
            }
            catch (Exception)
            {
                key.DateCreated = DateTime.Now;
                key.DateValidThrough = DateTime.Now.AddDays(-1.0);
                key.IsCurrentlyValid = false;
                key.Expires = true;
                key.PublicKeyValidates = false;
                key.Key = "Invalid";
                key.Feature1 = false;
                key.Feature2 = false;
                key.Feature3 = false;
                key.Feature4 = false;
                key.Feature5 = false;
            }
            return key;
        }

        internal bool RandomsMatch(string p_strIN)
        {
            bool flag = false;
            try
            {
                p_strIN = modMain.RemoveReadability(p_strIN);
                char[] array = p_strIN.ToCharArray();
                if ((array != null) && (LicenseUtil.UBound(array, 1) > 0))
                {
                    flag = /*this.ValidateRandoms(modMain.SafeString(array[1]), modMain.SafeString(array[19])) &*/ this.ValidateRandoms(modMain.SafeString(array[3]), modMain.SafeString(array[10]));
                    return (flag & this.ValidateRandoms(modMain.SafeString(array[6]), modMain.SafeString(array[7])));
                }
                flag = false;
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }

        internal int ReadFeatureCode(string p_strLetter)
        {
            int num2 = 0;
            try
            {
                switch (LicenseUtil.Asc(p_strLetter))
                {
                    case 67:
                    case 81:
                    case 86:
                        return 2;

                    case 68:
                    case 78:
                    case 85:
                        return 8;

                    case 69:
                    case 82:
                    case 83:
                        return 4;

                    case 70:
                    case 72:
                    case 80:
                        return 16;

                    case 73:
                    case 75:
                    case 77:
                        return 32;
                }
                return 0;
            }
            catch (Exception)
            {
            }
            return num2;
        }

        internal ValidatedKey ValidateKey(string EncryptedString, int p_intMachineKey)
        {
            return this.ParseKey(EncryptedString, p_intMachineKey);
        }

        internal bool ValidateRandoms(string p_strA, string p_strB)
        {
            bool flag = false;
            int num = 0;
            int num2 = 0;
            try
            {
                num = LicenseUtil.Asc(p_strA);
                num2 = LicenseUtil.Asc(p_strB);
                flag = (num + num2) == 155;
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }

        private bool ArrayIsEmpty(string[, ,] p_arIN)
        {
            bool flag2 = false;
            try
            {
                if (p_arIN == null)
                {
                    return true;
                }
                if (p_arIN[0, 0, 0] == null)
                {
                    flag2 = true;
                }
            }
            catch (Exception)
            {
                flag2 = true;
            }
            return flag2;
        }

        private string FillString(string p_strIN, int p_intUnlockCode)
        {
            string str5 = string.Empty;
            List<string> list = new List<string>();
            string randomLetter = this.GetRandomLetter();
            string unRandomLetter = this.GetUnRandomLetter(randomLetter);
            string str8 = this.GetRandomLetter();
            string str4 = this.GetUnRandomLetter(str8);
            char[] chArray = p_strIN.ToCharArray();
            string letter = this.GetLetter(p_intUnlockCode);
            string str3 = this.GetUnRandomLetter(letter);
            list.Add(modMain.SafeString(chArray[2]));
            list.Add(modMain.SafeString(randomLetter));
            list.Add(modMain.SafeString(chArray[11]));
            list.Add(modMain.SafeString(letter));
            list.Add(modMain.SafeString(chArray[1]));
            list.Add(modMain.SafeString(chArray[5]));
            list.Add(modMain.SafeString(str8));
            list.Add(modMain.SafeString(str4));
            list.Add(modMain.SafeString(chArray[7]));
            list.Add(modMain.SafeString(chArray[10]));
            list.Add(modMain.SafeString(str3));
            list.Add(modMain.SafeString(chArray[0]));
            list.Add(modMain.SafeString(chArray[12]));
            list.Add(modMain.SafeString(chArray[8]));
            list.Add(modMain.SafeString(chArray[4]));
            list.Add(modMain.SafeString(chArray[9]));
            list.Add(modMain.SafeString(chArray[14]));
            list.Add(modMain.SafeString(chArray[13]));
            list.Add(modMain.SafeString(chArray[3]));
            list.Add(modMain.SafeString(chArray[6]));

            //    list.Add(modMain.SafeString(unRandomLetter));

            list.ForEach(item =>
            {
                str5 += item;
            });
            return str5;
        }

        private string GetLetter(int p_intNumber)
        {
            string str2 = string.Empty;
            int charCode = 0;
            try
            {
                if ((p_intNumber == 0) || (p_intNumber < 0))
                {
                    p_intNumber = 0;
                }
                charCode = 65 + this.GetRandomOption(p_intNumber);
                str2 = modMain.SafeString(LicenseUtil.Chr(charCode));
            }
            catch (Exception)
            {
            }
            return str2;
        }

        private int GetRandomOption(int p_intNumber)
        {
            int rndNumber = 0;
            int num3 = 0;
            rndNumber = this.GetRndNumber();
            switch (p_intNumber)
            {
                case 2:
                    switch (rndNumber)
                    {
                        case 0:
                            num3 = 2;
                            break;

                        case 1:
                            num3 = 21;
                            break;

                        case 2:
                            num3 = 16;
                            break;
                    }
                    return num3;

                case 4:
                    switch (rndNumber)
                    {
                        case 0:
                            num3 = 18;
                            break;

                        case 1:
                            num3 = 17;
                            break;

                        case 2:
                            num3 = 4;
                            break;
                    }
                    return num3;

                case 8:
                    switch (rndNumber)
                    {
                        case 0:
                            num3 = 13;
                            break;

                        case 1:
                            num3 = 20;
                            break;

                        case 2:
                            num3 = 3;
                            break;
                    }
                    return num3;

                case 16:
                    switch (rndNumber)
                    {
                        case 0:
                            num3 = 15;
                            break;

                        case 1:
                            num3 = 5;
                            break;

                        case 2:
                            num3 = 7;
                            break;
                    }
                    return num3;

                case 32:
                    switch (rndNumber)
                    {
                        case 0:
                            num3 = 8;
                            break;

                        case 1:
                            num3 = 10;
                            break;

                        case 2:
                            num3 = 12;
                            break;
                    }
                    return num3;
            }
            switch (rndNumber)
            {
                case 0:
                    num3 = 1;
                    break;

                case 1:
                    num3 = 24;
                    break;

                case 2:
                    return 19;
            }
            return num3;
        }

        private int GetRndNumber()
        {
            int num = 0;
            num = rand.Next(0, 6000);
            if (num > 4000)
            {
                return 2;
            }
            if (num > 2000)
            {
                return 1;
            }
            num = 0;
            return num;
        }

        private bool MapFeatureCode(int p_intFeatureCode, int p_intCurrentLevel)
        {
            bool flag = false;
            switch (p_intFeatureCode)
            {
                case 2:
                    return (p_intCurrentLevel == 1);

                case 4:
                    return ((p_intCurrentLevel == 1) || (p_intCurrentLevel == 2));

                case 8:
                    if ((p_intCurrentLevel != 1) && (p_intCurrentLevel != 2))
                    {
                    }
                    return (p_intCurrentLevel == 3);

                case 16:
                    if (((p_intCurrentLevel != 1) && (p_intCurrentLevel != 2)) && (p_intCurrentLevel != 3))
                    {
                    }
                    return (p_intCurrentLevel == 4);

                case 32:
                    flag = true;
                    break;
            }
            return flag;
        }

        private string[, ,] SetMatrixLetters()
        {
            string[, ,] strArray = new string[11, 3, 5];
            strArray[0, 0, 0] = "R";
            strArray[0, 1, 0] = "Z";
            strArray[0, 2, 0] = "T";
            strArray[1, 0, 0] = "N";
            strArray[1, 1, 0] = "S";
            strArray[1, 2, 0] = "A";
            strArray[2, 0, 0] = "E";
            strArray[2, 1, 0] = "I";
            strArray[2, 2, 0] = "O";
            strArray[3, 0, 0] = "C";
            strArray[3, 1, 0] = "B";
            strArray[3, 2, 0] = "G";
            strArray[4, 0, 0] = "H";
            strArray[4, 1, 0] = "W";
            strArray[4, 2, 0] = "K";
            strArray[5, 0, 0] = "X";
            strArray[5, 1, 0] = "F";
            strArray[5, 2, 0] = "D";
            strArray[6, 0, 0] = "M";
            strArray[6, 1, 0] = "L";
            strArray[6, 2, 0] = "L";
            strArray[7, 0, 0] = "V";
            strArray[7, 1, 0] = "Q";
            strArray[7, 2, 0] = "V";
            strArray[8, 0, 0] = "J";
            strArray[8, 1, 0] = "P";
            strArray[8, 2, 0] = "P";
            strArray[9, 0, 0] = "Y";
            strArray[9, 1, 0] = "U";
            strArray[9, 2, 0] = "Y";
            strArray[10, 0, 0] = "K";
            strArray[10, 1, 0] = "D";
            strArray[10, 2, 0] = "D";
            strArray[0, 0, 1] = "T";
            strArray[0, 1, 1] = "E";
            strArray[0, 2, 1] = "N";
            strArray[1, 0, 1] = "D";
            strArray[1, 1, 1] = "L";
            strArray[1, 2, 1] = "Z";
            strArray[2, 0, 1] = "J";
            strArray[2, 1, 1] = "A";
            strArray[2, 2, 1] = "O";
            strArray[3, 0, 1] = "K";
            strArray[3, 1, 1] = "G";
            strArray[3, 2, 1] = "H";
            strArray[4, 0, 1] = "X";
            strArray[4, 1, 1] = "I";
            strArray[4, 2, 1] = "B";
            strArray[5, 0, 1] = "Q";
            strArray[5, 1, 1] = "U";
            strArray[5, 2, 1] = "S";
            strArray[6, 0, 1] = "C";
            strArray[6, 1, 1] = "P";
            strArray[6, 2, 1] = "P";
            strArray[7, 0, 1] = "M";
            strArray[7, 1, 1] = "R";
            strArray[7, 2, 1] = "M";
            strArray[8, 0, 1] = "W";
            strArray[8, 1, 1] = "F";
            strArray[8, 2, 1] = "F";
            strArray[9, 0, 1] = "Y";
            strArray[9, 1, 1] = "V";
            strArray[9, 2, 1] = "Y";
            strArray[10, 0, 1] = "B";
            strArray[10, 1, 1] = "S";
            strArray[10, 2, 1] = "B";
            strArray[0, 0, 2] = "F";
            strArray[0, 1, 2] = "S";
            strArray[0, 2, 2] = "I";
            strArray[1, 0, 2] = "O";
            strArray[1, 1, 2] = "P";
            strArray[1, 2, 2] = "Y";
            strArray[2, 0, 2] = "J";
            strArray[2, 1, 2] = "A";
            strArray[2, 2, 2] = "Z";
            strArray[3, 0, 2] = "Q";
            strArray[3, 1, 2] = "B";
            strArray[3, 2, 2] = "H";
            strArray[4, 0, 2] = "C";
            strArray[4, 1, 2] = "K";
            strArray[4, 2, 2] = "N";
            strArray[5, 0, 2] = "X";
            strArray[5, 1, 2] = "W";
            strArray[5, 2, 2] = "T";
            strArray[6, 0, 2] = "E";
            strArray[6, 1, 2] = "R";
            strArray[6, 2, 2] = "E";
            strArray[7, 0, 2] = "V";
            strArray[7, 1, 2] = "L";
            strArray[7, 2, 2] = "L";
            strArray[8, 0, 2] = "M";
            strArray[8, 1, 2] = "D";
            strArray[8, 2, 2] = "D";
            strArray[9, 0, 2] = "G";
            strArray[9, 1, 2] = "U";
            strArray[9, 2, 2] = "G";
            strArray[10, 0, 2] = "N";
            strArray[10, 1, 2] = "T";
            strArray[10, 2, 2] = "N";
            strArray[0, 0, 3] = "I";
            strArray[0, 1, 3] = "T";
            strArray[0, 2, 3] = "B";
            strArray[1, 0, 3] = "M";
            strArray[1, 1, 3] = "J";
            strArray[1, 2, 3] = "R";
            strArray[2, 0, 3] = "E";
            strArray[2, 1, 3] = "N";
            strArray[2, 2, 3] = "W";
            strArray[3, 0, 3] = "G";
            strArray[3, 1, 3] = "Q";
            strArray[3, 2, 3] = "Z";
            strArray[4, 0, 3] = "V";
            strArray[4, 1, 3] = "C";
            strArray[4, 2, 3] = "O";
            strArray[5, 0, 3] = "D";
            strArray[5, 1, 3] = "Y";
            strArray[5, 2, 3] = "A";
            strArray[6, 0, 3] = "K";
            strArray[6, 1, 3] = "H";
            strArray[6, 2, 3] = "K";
            strArray[7, 0, 3] = "S";
            strArray[7, 1, 3] = "U";
            strArray[7, 2, 3] = "S";
            strArray[8, 0, 3] = "L";
            strArray[8, 1, 3] = "P";
            strArray[8, 2, 3] = "P";
            strArray[9, 0, 3] = "X";
            strArray[9, 1, 3] = "F";
            strArray[9, 2, 3] = "X";
            strArray[10, 0, 3] = "O";
            strArray[10, 1, 3] = "A";
            strArray[10, 2, 3] = "A";
            return strArray;
        }

        private string UnFillString(string p_strIN)
        {
            string str = string.Empty;
            List<string> list = new List<string>();
            char[] chArray = p_strIN.ToCharArray();
            list.Add(modMain.SafeString(chArray[11]));
            list.Add(modMain.SafeString(chArray[4]));
            list.Add(modMain.SafeString(chArray[0]));
            list.Add(modMain.SafeString(chArray[18]));
            list.Add(modMain.SafeString(chArray[14]));
            list.Add(modMain.SafeString(chArray[5]));
            list.Add(modMain.SafeString(chArray[8]));
            list.Add(modMain.SafeString(chArray[13]));
            list.Add(modMain.SafeString(chArray[15]));
            list.Add(modMain.SafeString(chArray[9]));
            list.Add(modMain.SafeString(chArray[2]));
            list.Add(modMain.SafeString(chArray[12]));
            list.Add(modMain.SafeString(chArray[17]));
            list.Add(modMain.SafeString(chArray[16]));
            list.Add(modMain.SafeString(chArray[6]));
            list.Add(modMain.SafeString(chArray[19]));
            list.ForEach(item => { str += item; });
            return str;
        }

        private string UnSwitchLetter(string p_strLetter, int p_intSeries)
        {
            if (p_intSeries == 0)
            {
                switch (p_strLetter)
                {
                    case "R":
                    case "Z":
                    case "T": return "0";

                    case "N":
                    case "S":
                    case "A": return "1";

                    case "E":
                    case "I":
                    case "O": return "2";

                    case "C":
                    case "B":
                    case "G": return "3";

                    case "H":
                    case "W":
                    case "K": return "4";

                    case "X":
                    case "F":
                    case "D": return "5";

                    case "M":
                    case "L": return "6";

                    case "V":
                    case "Q": return "7";

                    case "J":
                    case "P": return "8";

                    case "Y":
                    case "U": return "9";
                }
            }

            else if (p_intSeries == 1)
            {
                switch (p_strLetter)
                {
                    case "T":
                    case "E":
                    case "N": return "0";

                    case "D":
                    case "L":
                    case "Z": return "1";

                    case "J":
                    case "A":
                    case "O": return "2";

                    case "K":
                    case "G":
                    case "H": return "3";

                    case "X":
                    case "I":
                    case "B": return "4";

                    case "Q":
                    case "U":
                    case "S": return "5";

                    case "C":
                    case "P": return "6";

                    case "M":
                    case "R": return "7";

                    case "W":
                    case "F": return "8";

                    case "Y":
                    case "V": return "9";
                }
            }

            else if (p_intSeries == 2)
            {
                switch (p_strLetter)
                {
                    case "F":
                    case "S":
                    case "I": return "0";

                    case "O":
                    case "P":
                    case "Y": return "1";

                    case "J":
                    case "A":
                    case "Z": return "2";

                    case "Q":
                    case "B":
                    case "H": return "3";

                    case "C":
                    case "K":
                    case "N": return "4";

                    case "X":
                    case "W":
                    case "T": return "5";

                    case "E":
                    case "R": return "6";

                    case "V":
                    case "L": return "7";

                    case "M":
                    case "D": return "8";

                    case "G":
                    case "U": return "9";
                }
            }

            else if (p_intSeries == 3)
            {
                switch (p_strLetter)
                {
                    case "I":
                    case "T":
                    case "B": return "0";

                    case "M":
                    case "J":
                    case "R": return "1";

                    case "E":
                    case "N":
                    case "W": return "2";

                    case "G":
                    case "Q":
                    case "Z": return "3";

                    case "V":
                    case "C":
                    case "O": return "4";

                    case "D":
                    case "Y":
                    case "A": return "5";

                    case "K":
                    case "H": return "6";

                    case "S":
                    case "U": return "7";

                    case "L":
                    case "P": return "8";

                    case "X":
                    case "F": return "9";
                }
            }
            return string.Empty;
        }
    }
}