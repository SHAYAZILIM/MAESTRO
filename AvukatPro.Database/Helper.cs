using AvukatProLib;
using NLog;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AvukatPro.Database
{
    public static class Helper
    {
        private static SqlConnection _Connection;
        private static string _ConnectionStr;
        private static Logger _Logger = LogManager.GetCurrentClassLogger();

        private static string _VT;

        public static SqlConnection Connection
        {
            get
            {
                if (_Connection == null)
                {
                    _Connection = new SqlConnection(ConnectionStr);
                }
                return _Connection;
            }
        }

        public static string ConnectionStr
        {
            get
            {
                if (string.IsNullOrEmpty(_ConnectionStr))
                    _ConnectionStr = List.FirstOrDefault().ConStr;
                return _ConnectionStr;
            }
            set
            {
                _ConnectionStr = value;
                _Connection = null;
            }
        }

        public static List<CompInfo> List
        {
            get;
            set;
        }

        public static Logger Logger
        {
            get { return _Logger; }
            set { _Logger = value; }
        }

        public static string VT
        {
            get
            {
                if (string.IsNullOrEmpty(_VT))
                {
                    _VT = Helper.List[0].HAVeriTabani;
                }
                return Helper._VT;
            }
            set { Helper._VT = value; }
        }
    }
}