using System;
using System.Collections.Generic;

namespace AvukatProLib.LisansYonetimi
{
    public class LicenseTool : License
    {
        public LicenseTool()
        {
        }

        public LicenseTool(ExtensionWorkerObject p_objExtensionWorkerObject)
        {
            this.m_objExtensionWorkerObject = p_objExtensionWorkerObject;
        }

        public LicenseTool(string p_strPrivateKey)
            : base(p_strPrivateKey)
        {
        }

        public LicenseTool(ExtensionWorkerObject p_objExtensionWorkerObject, string p_strPrivateKey)
            : base(p_strPrivateKey)
        {
            this.m_objExtensionWorkerObject = p_objExtensionWorkerObject;
        }

        private const int mc_intMaxNumberOfKeys = 1000;
        private ExtensionWorkerObject m_objExtensionWorkerObject;
        //private bool Contains(ArrayList p_alKeys, string p_strKey)
        //{
        //    bool flag = false;
        //    string str = "";
        //    try
        //    {
        //        str = p_strKey;
        //        if (!string.IsNullOrEmpty(str))
        //        {
        //            IEnumerator enumerator = null;
        //            try
        //            {
        //                enumerator = p_alKeys.GetEnumerator();
        //                while (enumerator.MoveNext())
        //                {
        //                    string str2 = enumerator.Current.ToString();
        //                    if (this.StripReadability(str2) == this.StripReadability(str))
        //                    {
        //                        return true;
        //                    }
        //                }
        //                return flag;
        //            }
        //            finally
        //            {
        //                if (enumerator is IDisposable)
        //                {
        //                    (enumerator as IDisposable).Dispose();
        //                }
        //            }
        //            return flag;
        //        }
        //        flag = true;
        //    }
        //    catch (Exception)
        //    {
        //        flag = true;
        //    }
        //    return flag;
        //}

        public string Decryptpublicly(string p_strCipherText, string p_strSaltValue)
        {
            return base.DecryptMD5(p_strCipherText, p_strSaltValue);
        }

        public string Encryptpublicly(string p_strPlainText, string p_strSaltValue)
        {
            return base.EncryptMD5(p_strPlainText, p_strSaltValue);
        }

        public List<string> GenerateKeys(NewKeyProperties p_objNewKeyProperties)
        {
            List<string> list = new List<string>();
            int num2 = 0;
            try
            {
                if (p_objNewKeyProperties.NumberOfKeys < 1)
                {
                    p_objNewKeyProperties.NumberOfKeys = 1;
                }
                if (p_objNewKeyProperties.NumberOfKeys > 1000)
                {
                    p_objNewKeyProperties.NumberOfKeys = 1000;
                }

                //string str2 = LicenseUtil.Right(string.Format("0{0}", DateTime.Now.Day), 2);
                //string str3 = LicenseUtil.Right(string.Format("0{0}", DateTime.Now.Month), 2);
                //string str6 = LicenseUtil.Right(string.Format("20{0}", DateTime.Now.Year), 4);
                string str2 = LicenseUtil.Right(string.Format("0{0}", p_objNewKeyProperties.LicenseStartDate.Day), 2);
                string str3 = LicenseUtil.Right(string.Format("0{0}", p_objNewKeyProperties.LicenseStartDate.Month), 2);
                string str6 = LicenseUtil.Right(string.Format("20{0}", p_objNewKeyProperties.LicenseStartDate.Year), 4);
                string str5 = str3 + str2 + str6;

                //string plainText = this.GetKey(DateTime.Now, p_objNewKeyProperties.DaysValid.ToString(), p_objNewKeyProperties.MachineKey);
                string plainText = this.GetKey(p_objNewKeyProperties.LicenseStartDate, p_objNewKeyProperties.DaysValid.ToString(), p_objNewKeyProperties.MachineKey);
                int numberOfKeys = p_objNewKeyProperties.NumberOfKeys;
                for (int i = 1; i <= numberOfKeys; i++)
                {
                    num2++;
                    string item = this.Encrypt(plainText, p_objNewKeyProperties.UnlockCode);
                    if (!string.IsNullOrEmpty(p_objNewKeyProperties.FreeformText) && (p_objNewKeyProperties.FreeformText.Length > 0))
                    {
                        item = this.EncryptMD5(item + p_objNewKeyProperties.FreeformText, base.PrivateKey);
                    }
                    if (!list.Contains(item))
                    {
                        list.Add(item);
                    }
                    else
                    {
                        i--;
                    }
                    if (num2 > 100000)
                    {
                        break;
                    }
                }
                list.Sort();
            }
            catch (Exception)
            {
            }
            return list;
        }

        public string GetKey(DateTime DateIssued, string NumberOfDays, int p_intMachineCode)
        {
            ValidatedKey validatedKeyFromRegistry = null;
            if (this.m_objExtensionWorkerObject != null)
            {
                validatedKeyFromRegistry = new ValidatedKey();
            }
            if (validatedKeyFromRegistry == null)
            {
                NumberOfDays = "30";
            }
            else if (validatedKeyFromRegistry.Expires && ((modMain.SafeInteger(NumberOfDays) > 14) || (modMain.SafeInteger(NumberOfDays) < 1)))
            {
                NumberOfDays = "30";
            }
            int num2 = modMain.SafeInteger(this.Encrypt_GP(base.PrivateKey));
            int num = p_intMachineCode + num2;
            return (modMain.FixDate(DateIssued) + modMain.FixString(NumberOfDays, 4) + modMain.FixCompositeKey(num));
        }

        public int NumberOfDays()
        {
            return base.Makers;
        }
    }
}