using System;
using System.Collections.Generic;

namespace BelgeUtil
{
    public class CacheHelper
    {
        public CacheHelper()
        { }

        public CacheHelper(DateTime cacheTime, object cachedObject)
        {
            _CacheTime = cacheTime;
            _CachedObject = cachedObject;
        }

        public CacheHelper(double minutesToCache, object cachedObject)
        {
            _CacheTime = DateTime.Now.AddSeconds(minutesToCache);
            _CachedObject = cachedObject;
        }

        public static List<CacheData> CachedDatas = null;
        public CacheType _CacheType;
        private static double _CacheDelay = 10;
        private static List<string> UsedCacheKeys = null;
        private object _CachedObject;

        private DateTime _CacheTime;

        private string _Key;

        public enum CacheType
        {
            CariFull,
            CariAvukat,
            CariBilirkisi,
            Diger
        }

        public static double CacheDelay
        {
            get { return CacheHelper._CacheDelay; }
            set { CacheHelper._CacheDelay = value; }
        }

        public object CachedObject
        {
            get { return _CachedObject; }
            set { _CachedObject = value; }
        }

        public DateTime CacheTime
        {
            get { return _CacheTime; }
            set { _CacheTime = value; }
        }

        public string Key
        {
            get { return _Key; }
            set
            {
                if (ValidateKey(value))
                {
                    _Key = value;
                }
            }
        }

        public static bool CacheMyData(CacheData data)
        {
            if (CachedDatas == null)
            {
                CachedDatas = new List<CacheData>();
                CachedDatas.Add(data);
            }
            if (CachedDatas.Count == 0)
            {
                CachedDatas.Add(data);
            }
            for (int i = 0; i < CachedDatas.Count; i++)
            {
                if (CachedDatas[i].Key != data.Key)
                {
                    CachedDatas.Add(data);
                    return true;
                }
            }
            return false;
        }

        public static CacheHelper GetByKeyValue(string Key)
        {
            //TODO : Keye göre cache bull
            return new CacheHelper();
        }

        public static CacheData GetCachedDataByIndex(int Index)
        {
            for (int i = 0; i < CachedDatas.Count; i++)
            {
                if (CachedDatas[i].Index == Index)
                {
                    return CachedDatas[i];
                }
            }
            return null;
        }

        public static CacheData GetCachedDataByKeyValue(string Key)
        {
            if (CachedDatas == null)
            {
                return null;
            }
            for (int i = 0; i < CachedDatas.Count; i++)
            {
                if (CachedDatas[i].Key == Key)
                {
                    return CachedDatas[i];
                }
            }
            return null;
        }

        public static object GetDataWithCacheControl(object Data, string Key)
        {
            CacheData cdata = CacheHelper.GetCachedDataByKeyValue(Key);
            if (cdata != null)
            {
                return cdata.Data;
            }

            CacheMyData(new CacheData(Key, Data));
            return Data;
        }

        private bool ValidateKey(string Key)
        {
            if (UsedCacheKeys == null)
            {
                UsedCacheKeys = new List<string>();
            }

            if (UsedCacheKeys.Contains(Key))
            {
                return false;
            }
            UsedCacheKeys.Add(Key);
            return true;
        }
    }
}