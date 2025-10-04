using System;

using System.Xml.Serialization;

namespace AdimAdimDavaKaydi.UyapClass
{
    [Serializable]
    [XmlType("exchangeData")]
    [XmlRootAttribute("exchangeData")]
    public class ExchangeData
    {
        private Dosyalar _dosya;

        private ExchangeHeader _ExchangeHeader;

        [XmlElement("dosyalar")]
        public Dosyalar dosya
        { get { return _dosya; } set { _dosya = value; } }

        [XmlElement("exchangeHeader")]
        public ExchangeHeader ExchangeHeader
        { get { return _ExchangeHeader; } set { _ExchangeHeader = value; } }
    }

    [Serializable]
    [XmlType("exchangeHeader")]
    public class ExchangeHeader
    {
        private string _Version;

        [XmlAttribute("versiyon")]
        public string Version
        { get { return _Version; } set { _Version = value; } }
    }
}