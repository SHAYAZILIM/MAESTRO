using System;

namespace AvukatProRaporlar.Raport.Util
{
    [Serializable]
    public enum DegerTipi
    {
        Sayısal,
        Alfabetik,
        Tarih,
        Mantıksal
    }

    [Serializable]
    public enum KarsilastirmaTipi
    {
        Sutun,
        Deger
    }

    /// <summary>
    /// Biçimlendirme değerlerini tutan class
    /// </summary>
    [Serializable]
    public class Bilgi
    {
        public Bilgi()
        {
        }

        public object deger1;

        public object deger2;

        private System.Drawing.Color arkaPlanRengi;

        private System.Drawing.Color arkaPlanRengi2;

        private DegerTipi degerTipi;

        private System.Drawing.Color kenarlikRengi;

        private DevExpress.XtraGrid.FormatConditionEnum kosul;

        private System.Drawing.Drawing2D.LinearGradientMode renkGecisYonu;

        private bool satiraUygula;

        private string sutun;

        private string sutun1;

        private string sutun2;

        private KarsilastirmaTipi tip;

        private System.Drawing.Color yaziRengi;

        [field: NonSerializedAttribute()]
        public event EventHandler<PropertyChangedEventArgler> PropertyChanged;

        /// <summary>
        /// Koşulun Uygulanacağı Hücrelerin Arka Plan Rengi
        /// </summary>
        [System.ComponentModel.Description("Koşulun Uygulanacağı Hücrelerin Arka Plan Rengi")]
        [System.ComponentModel.DisplayName("Arka Plan Rengi")]
        public System.Drawing.Color ArkaPlanRengi
        {
            get { return arkaPlanRengi; }
            set
            {
                arkaPlanRengi = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgler("ArkaPlanRengi", value));
            }
        }

        /// <summary>
        /// Koşulun Uygulanacağı Hücrelerin Arka Plan Geçiş Rengi
        /// </summary>
        [System.ComponentModel.Description("Koşulun Uygulanacağı Hücrelerin Arka Plan Geçiş Rengi")]
        [System.ComponentModel.DisplayName("Arka Plan Rengi 2")]
        public System.Drawing.Color ArkaPlanRengi2
        {
            get { return arkaPlanRengi2; }
            set
            {
                arkaPlanRengi2 = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgler("ArkaPlanRengi2", value));
            }
        }

        /// <summary>
        /// Uygulanacak Koşul İçin Birinci Karşılaştırma Değeri
        /// </summary>
        [System.ComponentModel.Description("Uygulanacak Koşul İçin Birinci Karşılaştırma Değeri")]
        [System.ComponentModel.DisplayName("Değer 1")]
        public object Deger1
        {
            get { return deger1; }
            set
            {
                if (tip == KarsilastirmaTipi.Deger)
                {
                    deger1 = value;
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgler("Deger1", value));
                }
            }
        }

        /// <summary>
        /// Uygulanacak Koşul İçin İkinci Karşılaştırma Değeri
        /// </summary>
        [System.ComponentModel.Description("Uygulanacak Koşul İçin İkinci Karşılaştırma Değeri")]
        [System.ComponentModel.DisplayName("Değer 2")]
        public object Deger2
        {
            get { return deger2; }
            set
            {
                if (tip == KarsilastirmaTipi.Deger)
                {
                    deger2 = value;
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgler("Deger2", value));
                }
            }
        }

        /// <summary>
        /// Değerlerin Tipi
        /// </summary>
        [System.ComponentModel.DisplayName("Değerlerin Tipi")]
        [System.ComponentModel.Description("Yapılacak Karşılaştırmanın Tipi (Sayısal : Sayısal Karşılaştırma\nAlfabetik : Alfabetik Karşılaştırma\nTarih : Tarih Karşılaştırması\nMantıksal : True(Evet)/False(Hayır) Karşılaştırma)")]
        public DegerTipi DegerlerinTipi
        {
            get { return degerTipi; }
            set
            {
                degerTipi = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgler("DegerlerinTipi", value));
            }
        }

        /// <summary>
        /// Koşulun Uygulanacağı Hücrelerin Kenarlık Rengi
        /// </summary>
        [System.ComponentModel.Description("Koşulun Uygulanacağı Hücrelerin Kenarlık Rengi")]
        [System.ComponentModel.DisplayName("Kenarlık Rengi")]
        public System.Drawing.Color KenarlikRengi
        {
            get { return kenarlikRengi; }
            set
            {
                kenarlikRengi = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgler("KenarlikRengi", value));
            }
        }

        /// <summary>
        /// Uygulanmasını İstediğiniz Koşul
        /// </summary>
        [System.ComponentModel.Description("Uygulanmasını İstediğiniz Koşul")]
        [System.ComponentModel.DisplayName("Koşul")]
        public DevExpress.XtraGrid.FormatConditionEnum Kosul
        {
            get { return kosul; }
            set
            {
                kosul = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgler("Kosul", value));
            }
        }

        /// <summary>
        /// Koşulun Uygulanacağı Hücrelerin İki Renk Arasındaki Geçiş Yönü
        /// </summary>
        [System.ComponentModel.Description("Koşulun Uygulanacağı Hücrelerin İki Renk Arasındaki Geçiş Yönü")]
        [System.ComponentModel.DisplayName("Renk Geçiş Yönü")]
        public System.Drawing.Drawing2D.LinearGradientMode RenkGecisYonu
        {
            get { return renkGecisYonu; }
            set
            {
                renkGecisYonu = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgler("RenkGecisYonu", value));
            }
        }

        /// <summary>
        /// Renklendirmeyi Satıra Uygula
        /// </summary>
        [System.ComponentModel.DisplayName("SatirinTumuneUygula")]
        [System.ComponentModel.Description("Renklendirmeyi Satıra Uygula")]
        public bool SatiraUygula
        {
            get { return satiraUygula; }
            set
            {
                satiraUygula = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgler("SatiraUygula", value));
            }
        }

        /// <summary>
        /// "Karşılaştırılacak olan sütun"
        /// </summary>
        [System.ComponentModel.Description("Karşılaştırılacak olan sütun")]
        [System.ComponentModel.DisplayName("Karşılaştırılacak sütun")]
        public string Sutun
        {
            get { return sutun; }
            set
            {
                sutun = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgler("Sutun", value));
            }
        }

        /// <summary>
        /// Karşılaştırılacak sütunlar Sutun1
        /// </summary>
        [System.ComponentModel.DisplayName("Sütun 1")]
        [System.ComponentModel.Description("Karşılaştırılacak sütunlar")]
        public string Sutun1
        {
            get { return sutun1; }
            set
            {
                sutun1 = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgler("Sutun1", value));
            }
        }

        /// <summary>
        /// Karşılaştırılacak sütunlar Stun2
        /// </summary>
        [System.ComponentModel.DisplayName("Sütun 2")]
        [System.ComponentModel.Description("Karşılaştırılacak sütunlar")]
        public string Sutun2
        {
            get { return sutun2; }
            set
            {
                sutun2 = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgler("Sutun2", value));
            }
        }

        /// <summary>
        /// Karşılaştırma Tipi
        /// </summary>
        [System.ComponentModel.DisplayName("Karşılaştırma Tipi")]
        [System.ComponentModel.Description("Başka Bir Sütun İle Karşılaştır / Değer İle Karşılaştır")]
        public KarsilastirmaTipi Tip
        {
            get { return tip; }
            set
            {
                if (value == KarsilastirmaTipi.Sutun)
                {
                    deger1 = null;
                    deger2 = null;
                }
                tip = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgler("Tip", value));
            }
        }

        /// <summary>
        /// Koşulun Uygulanacağı Hücrelerin Yazı Rengi
        /// </summary>
        [System.ComponentModel.Description("Koşulun Uygulanacağı Hücrelerin Yazı Rengi")]
        [System.ComponentModel.DisplayName("Yazı Rengi")]
        public System.Drawing.Color YaziRengi
        {
            get { return yaziRengi; }
            set
            {
                yaziRengi = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgler("YaziRengi", value));
            }
        }
    }

    [Serializable]
    public class PropertyChangedEventArgler : EventArgs
    {
        public PropertyChangedEventArgler()
        { }

        public PropertyChangedEventArgler(string propertyName, object value)
        {
            PropertyName = propertyName;
            Value = value;
        }

        private string _propertyName;
        private object _value;

        public string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }

        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}