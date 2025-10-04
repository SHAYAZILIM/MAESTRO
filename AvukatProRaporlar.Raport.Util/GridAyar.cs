using System;
using System.Collections.Generic;

using System.Xml;
using System.Xml.Serialization;

namespace AvukatProRaporlar.Raport.Util
{
    [Serializable]
    public class GridAyar
    {
        public GridAyar()
        {
        }

        private string lastView;
        private string myCustomStyle;
        private List<Bilgi> styleConditions;

        [XmlAttribute(AttributeName = "LastView")]
        public string LastView
        {
            get { return lastView; }
            set { lastView = value; }
        }

        [XmlAttribute(AttributeName = "MyCustomStyle")]
        public string MyCustomStyle
        {
            get { return myCustomStyle; }
            set { myCustomStyle = value; }
        }

        [XmlArray(ElementName = "Bilgilers")]
        public List<Bilgi> StyleConditions
        {
            get { return styleConditions; }
            set { styleConditions = value; }
        }
    }
}