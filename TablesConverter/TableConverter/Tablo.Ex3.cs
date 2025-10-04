using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TableConverter
{
    public partial class TableStringConverter
    {
        public static object GetRecordByTableNameAndId(string Tablo, Int32 Id)
        {
            try
            {
                Assembly asm = Assembly.Load("AvukatProLib2.Data");
                var type = asm.GetType("AvukatProLib2.Data.DataRepository");
                var t = type.GetProperty(Tablo + "Provider").GetValue(type, null);
                Type typeofClassWithGenericStaticMethod = t.GetType();
                List<MethodInfo> l = new List<MethodInfo>(typeofClassWithGenericStaticMethod.GetMethods());
                MethodInfo mi;
                mi = l.FirstOrDefault(x => x.Name.ToUpper() == "GETBYID" && x.GetParameters().Length == 1);
                return mi.Invoke(t, new object[] { Id });
            }
            catch { }
            return new object();
        }
    }
}