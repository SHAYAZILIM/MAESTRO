using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;

namespace AdimAdimDavaKaydi.Util.Uyap
{

    [Serializable]
    [XmlType("exchangeData")]
    [XmlRootAttribute("exchangeData")]
    public class ExchangeData
    {
        [XmlElement("exchangeHeader")]
        public ExchangeHeader ExchangeHeader
        { get { return _ExchangeHeader; } set { _ExchangeHeader = value; } }

        private ExchangeHeader _ExchangeHeader;

        [XmlElement("dosyalar")]
        public Dosyalar dosya
        { get { return _dosya; } set { _dosya = value; } }

        private Dosyalar _dosya;

    }

    [Serializable]
    [XmlType("exchangeHeader")]
    public class ExchangeHeader
    {
        [XmlAttribute("versiyon")]
        public string Version
        { get { return _Version; } set { _Version = value; } }

        private string _Version;

    }

 
}
