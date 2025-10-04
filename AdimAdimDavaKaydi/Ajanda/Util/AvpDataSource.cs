using AvukatProLib.Util;
using System;
using System.ComponentModel;

namespace AdimAdimDavaKaydi.Ajanda.Util
{
    public class AvpDataSource
    {
        public AvpDataSource()
        {
        }

        public AvpDataSource(string key, IBindingList data)
        {
            this.Key = key;
            this.Datas = data;
            if (BelgeUtil.CacheHelper.GetCachedDataByKeyValue(key) != null)
                BelgeUtil.CacheHelper.GetCachedDataByKeyValue(key).Data = data;
            else
                BelgeUtil.CacheHelper.CacheMyData(new BelgeUtil.CacheData(Key, data));
        }

        public IBindingList Datas { get; set; }

        public int Index { get; set; }

        public string Key { get; set; }

        public bool Save()
        {
            try
            {
                SaveRecord.Save(this.Datas);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}