using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace AvukatPro.Net.Mail
{
    public delegate void ClientCommandEventHandler(object sender, string command);

    public delegate void DataReceivingEventHandler(object sender);

    public delegate void ServerResponseEventHandler(object sender, string response);

}