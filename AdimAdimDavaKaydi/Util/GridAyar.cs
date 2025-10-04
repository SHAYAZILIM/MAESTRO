using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AdimAdimDavaKaydi.Util
{
    [Serializable]
    public class GridAyar
    {
        private List<Bilgi> styleConditions;
        private string myCustomStyle;
        private string lastView;

        [XmlArray(ElementName = "Bilgilers")]
        public List<Bilgi> StyleConditions
        {
            get { return styleConditions; }
            set { styleConditions = value; }
        }

        [XmlAttribute(AttributeName = "MyCustomStyle")]
        public string MyCustomStyle
        {
            get { return myCustomStyle; }
            set { myCustomStyle = value; }
        }

        [XmlAttribute(AttributeName = "LastView")]
        public string LastView
        {
            get { return lastView; }
            set { lastView = value; }
        }
    }
}