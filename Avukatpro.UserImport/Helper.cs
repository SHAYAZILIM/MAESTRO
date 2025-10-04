using AvukatProLib;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Avukatpro.UserImport
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

        public static string GetConnectionString(string pFilePath)
        {
            string strConnectionString = string.Empty;
            string strExcelExt = System.IO.Path.GetExtension(pFilePath);

            if (strExcelExt == ".xls")
                strConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties= ""Excel 8.0;HDR=YES;""";
            //Ahad L. Amdani added support for .xslm for workbooks using macros
            else if (strExcelExt == ".xlsx" || strExcelExt == ".xlsm")
                strConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES""";
            else
                throw new ArgumentOutOfRangeException("Excel file extenstion is not known.");

            return string.Format(strConnectionString, pFilePath);
        }
    }
}