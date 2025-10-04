using System;
using AdimAdimDavaKaydi.Util.BaseClasses.AvpFormClass.AvpFormUtil;

namespace AdimAdimDavaKaydi.Util.BaseClasses.AvpFormData
{
    [Serializable]
    public class AvpFormDataEventArgs : AvpFormEventArgs
    {
        private AvpDatas _data;

        public AvpDatas Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}