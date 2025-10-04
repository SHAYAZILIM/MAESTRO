using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Ajanda.Util
{
    public class AvpDataSourceCollection : List<AvpDataSource>
    {
        public AvpDataSource FindByKey(string key)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Key == key)
                {
                    return this[i];
                }
            }
            return null;
        }
    }
}