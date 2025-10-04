using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TableConverter
{
    public partial class TableStringConverter
    {
        public static IList GetAllRecordByTableName(string Tablo)
        {
            var list = GetEntityListInstanceByTableName(Tablo);
            try
            {
                Assembly asm = Assembly.Load("AvukatProLib2.Data");
                var type = asm.GetType("AvukatProLib2.Data.DataRepository");
                var t = type.GetProperty(Tablo + "Provider").GetValue(type, null);
                Type typeofClassWithGenericStaticMethod = t.GetType();
                List<MethodInfo> l = new List<MethodInfo>(typeofClassWithGenericStaticMethod.GetMethods());
                MethodInfo mi;
                mi = l.FirstOrDefault(x => x.Name.ToUpper() == "GETALL" && x.GetParameters().Length == 0);
                var value = mi.Invoke(t, null);
                if (value is IList)
                    return value as IList;
                else
                    return list;
            }
            catch { }
            return list;
        }
    }
}