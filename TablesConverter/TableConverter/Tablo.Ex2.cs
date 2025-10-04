using AvukatProLib2.Entities;
using System;
using System.Collections;
using System.Reflection;

namespace TableConverter
{
    public partial class TableStringConverter
    {
        public static IList GetEntityListInstanceByTableName(string Tablo)
        {
            Assembly asm = Assembly.Load("AvukatProLib2.Entities");
            var type = asm.GetType("AvukatProLib2.Entities." + Tablo);
            Type baseListType = typeof(TList<>);
            Type listType = baseListType.MakeGenericType(type);
            return Activator.CreateInstance(listType) as IList;
        }
    }
}