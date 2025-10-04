using System;

namespace AvukatProLib.LisansYonetimi
{
    public sealed class modMain
    {
        public static string FixCompositeKey(int p_intCompositeKey)
        {
            if (p_intCompositeKey <= 0)
            {
                return "00000";
            }
            return FixString(p_intCompositeKey.ToString(), 5);
        }

        public static string FixDate(DateTime dteIn)
        {
            if (LicenseUtil.IsDate(dteIn) && dteIn != null)
            {
                return (LicenseUtil.Right(dteIn.Month.ToString().PadLeft(2, '0'), 2) + LicenseUtil.Right(dteIn.Day.ToString().PadLeft(2, '0'), 2) + LicenseUtil.Right(dteIn.Year.ToString().PadLeft(2, '0'), 2));
            }
            return string.Empty;
        }

        public static string FixString(string p_strStringIn, int p_intNumberofChars)
        {
            if (p_intNumberofChars < 0)
            {
                p_intNumberofChars = 0;
            }
            return LicenseUtil.Right(SafeString(p_strStringIn), p_intNumberofChars).PadLeft(p_intNumberofChars, '0');
        }

        public static string MakeReadable(string strText)
        {
            string str = string.Empty;
            int num = 0;
            if (string.IsNullOrEmpty(strText))
            {
                return str;
            }
            strText = strText.Replace("-", "");
            char[] chArray = strText.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                string str3 = chArray[i].ToString();
                num++;
                str = str + str3;
                if (num == 5)
                {
                    str = str + "-";
                    num = 0;
                }
            }
            return (LicenseUtil.Mid(str, 1, str.Length - 3) + LicenseUtil.Right(str, 3).Replace("-", ""));
        }

        public static string RemoveReadability(string strText)
        {
            return strText.Replace("-", "").Replace(" ", "");
        }

        public static int SafeInteger(object p_objIn)
        {
            int num = -1;
            if (p_objIn != null)
            {
                try
                {
                    num = Convert.ToInt32(p_objIn);
                }
                catch (Exception)
                {
                }
            }
            return num;
        }

        public static string SafeString(object p_objIn)
        {
            string str2 = string.Empty;
            if (p_objIn != null)
            {
                try
                {
                    str2 = p_objIn.ToString();
                }
                catch (Exception)
                {
                }
            }
            return str2;
        }

        public static string SafeStringVersion(object p_objIn)
        {
            string str2 = string.Empty;
            if (p_objIn != null)
            {
                try
                {
                    str2 = p_objIn.ToString();
                    if (str2 == ".")
                    {
                        str2 = "10";
                    }
                }
                catch (Exception)
                {
                }
            }
            return str2;
        }
    }
}