using System;
using System.Runtime.InteropServices;

namespace AvukatPro.Net.Mail
{
    [Flags]
    internal enum ConnectionState : int
    {
        INTERNET_CONNECTION_MODEM = 0x1, INTERNET_CONNECTION_LAN = 0x2, INTERNET_CONNECTION_PROXY = 0x4, INTERNET_RAS_INSTALLED = 0x10, INTERNET_CONNECTION_OFFLINE = 0x20, INTERNET_CONNECTION_CONFIGURED = 0x40
    }

    public class Internet
    {
        public Internet()
        {
        }

        public static bool IsConnectedToInternet()
        {
            ConnectionState Description = 0;
            bool conn = InternetGetConnectedState(ref Description, 0);
            return conn;
        }

        [DllImport("wininet.dll", CharSet = CharSet.Auto)]
        private static extern bool InternetGetConnectedState(ref ConnectionState lpdwFlags, int dwReserved);
    }
}