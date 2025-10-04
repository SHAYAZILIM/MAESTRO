using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AvukatProLib.PaketYonetimi
{
    public enum DbFormType
    {
        ConnectDb,
        CreateDb,
        CreateGio
    }

}