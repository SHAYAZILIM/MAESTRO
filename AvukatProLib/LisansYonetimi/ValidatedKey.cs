using System;
using System.Collections.Generic;

namespace AvukatProLib.LisansYonetimi
{
    public class ValidatedKey
    {
        public DateTime DateCreated;
        public DateTime DateValidThrough;
        public bool Expires;
        public bool Feature1;
        public bool Feature2;
        public bool Feature3;
        public bool Feature4;
        public bool Feature5;
        public bool IsCurrentlyValid;
        public string Key;
        public int MachineCode;
        public bool MachineCodeValidates;
        public bool PublicKeyValidates;
        public bool UsesMachineCode;
        public string ValidVersion;
        private string m_strFreeformText = string.Empty;

        public string FreeformText
        {
            get
            {
                if (string.IsNullOrEmpty(this.m_strFreeformText))
                {
                    this.m_strFreeformText = "";
                }
                return this.m_strFreeformText;
            }
            set
            {
                this.m_strFreeformText = value;
            }
        }

        public List<string> FreeformTextItems
        {
            get
            {
                List<string> list2;
                string item = string.Empty;
                try
                {
                    string[] strArray = this.FreeformText.Split("|".ToCharArray());
                    list2 = new List<string>();
                    if (strArray.Length > 0)
                    {
                        foreach (string str2 in strArray)
                        {
                            list2.Add(str2);
                        }
                        return list2;
                    }
                    item = this.FreeformText;
                    list2.Add(item);
                }
                catch (Exception)
                {
                    list2 = new List<string>();
                    item = this.FreeformText;
                    list2.Add(item);
                }
                return list2;
            }
        }
    }
}