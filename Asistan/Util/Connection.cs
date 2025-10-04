using AvukatProLib;
using System;
using System.Collections.Generic;

namespace AvukatProAsistan.Util
{
    public static class Connection
    {
        private static string _ConStr;

        public static string ConStr
        {
            get
            {
                if (_ConStr == null || _ConStr == String.Empty)
                {
                    List<CompInfo> sList = CompInfo.CompInfoListGetir();
                    foreach (CompInfo info in sList)
                    {
                        _ConStr = sList[0].ConStr;
                    }
                }
                return _ConStr;
            }
            set
            {
                _ConStr = value;
            }
        }

    }
}