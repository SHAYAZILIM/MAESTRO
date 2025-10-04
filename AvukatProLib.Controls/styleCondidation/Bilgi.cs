using System;

namespace AvukatProLib.Controls
{
    [Serializable]
    public enum DegerTipi
    {
        Sayýsal,
        Alfabetik,
        Tarih,
        Mantýksal
    }

    [Serializable]
    public enum KarsilastirmaTipi
    {
        Sutun,
        Deger
    }

    /// <summary>
    /// Biçimlendirme deðerlerini tutan class
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

        public event EventHandler<PropertyChangedEventArgler> PropertyChanged;

        /// <summary>
        /// Koþulun Uygulanacaðý Hücrelerin Arka Plan Rengi
        /// </summary>
        [System.ComponentModel.Description("Koþulun Uygulanacaðý Hücrelerin Arka Plan Rengi")]
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
        /// Koþulun Uygulanacaðý Hücrelerin Arka Plan Geçiþ Rengi
        /// </summary>
        [System.ComponentModel.Description("Koþulun Uygulanacaðý Hücrelerin Arka Plan Geçiþ Rengi")]
        [System.ComponentModel.DisplayName("Arka Plan Rengi 2")]
        public System.Drawing.Color ArkaPlanRengi2
        {
            get { return arkaPlanRengi2; }
            set
            {
                arkaPlanRengi2 = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgler("ArkaPlanRengi2", value));
            }
        }

        /// <summary>
        /// Uygulanacak Koþul Ýçin Birinci Karþýlaþtýrma Deðeri
        /// </summary>
        [System.ComponentModel.Description("Uygulanacak Koþul Ýçin Birinci Karþýlaþtýrma Deðeri")]
        [System.ComponentModel.DisplayName("Deðer 1")]
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
        /// Uygulanacak Koþul Ýçin Ýkinci Karþýlaþtýrma Deðeri
        /// </summary>
        [System.ComponentModel.Description("Uygulanacak Koþul Ýçin Ýkinci Karþýlaþtýrma Deðeri")]
        [System.ComponentModel.DisplayName("Deðer 2")]
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
        /// Deðerlerin Tipi
        /// </summary>
        [System.ComponentModel.DisplayName("Deðerlerin Tipi")]
        [System.ComponentModel.Description("Yapýlacak Karþýlaþtýrmanýn Tipi (Sayýsal : Sayýsal Karþýlaþtýrma\nAlfabetik : Alfabetik Karþýlaþtýrma\nTarih : Tarih Karþýlaþtýrmasý\nMantýksal : True(Evet)/False(Hayýr) Karþýlaþtýrma)")]
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
        /// Koþulun Uygulanacaðý Hücrelerin Kenarlýk Rengi
        /// </summary>
        [System.ComponentModel.Description("Koþulun Uygulanacaðý Hücrelerin Kenarlýk Rengi")]
        [System.ComponentModel.DisplayName("Kenarlýk Rengi")]
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
        /// Uygulanmasýný Ýstediðiniz Koþul
        /// </summary>
        [System.ComponentModel.Description("Uygulanmasýný Ýstediðiniz Koþul")]
        [System.ComponentModel.DisplayName("Koþul")]
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
        /// Koþulun Uygulanacaðý Hücrelerin Ýki Renk Arasýndaki Geçiþ Yönü
        /// </summary>
        [System.ComponentModel.Description("Koþulun Uygulanacaðý Hücrelerin Ýki Renk Arasýndaki Geçiþ Yönü")]
        [System.ComponentModel.DisplayName("Renk Geçiþ Yönü")]
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
        /// Renklendirmeyi Satýra Uygula
        /// </summary>
        [System.ComponentModel.DisplayName("SatirinTumuneUygula")]
        [System.ComponentModel.Description("Renklendirmeyi Satýra Uygula")]
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
        /// "Karþýlaþtýrýlacak olan sütun"
        /// </summary>
        [System.ComponentModel.Description("Karþýlaþtýrýlacak olan sütun")]
        [System.ComponentModel.DisplayName("Karþýlaþtýrýlacak sütun")]
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
        /// Karþýlaþtýrýlacak sütunlar Sutun1
        /// </summary>
        [System.ComponentModel.DisplayName("Sütun 1")]
        [System.ComponentModel.Description("Karþýlaþtýrýlacak sütunlar")]
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
        /// Karþýlaþtýrýlacak sütunlar Stun2
        /// </summary>
        [System.ComponentModel.DisplayName("Sütun 2")]
        [System.ComponentModel.Description("Karþýlaþtýrýlacak sütunlar")]
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
        /// Karþýlaþtýrma Tipi
        /// </summary>
        [System.ComponentModel.DisplayName("Karþýlaþtýrma Tipi")]
        [System.ComponentModel.Description("Baþka Bir Sütun Ýle Karþýlaþtýr / Deðer Ýle Karþýlaþtýr")]
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
        /// Koþulun Uygulanacaðý Hücrelerin Yazý Rengi
        /// </summary>
        [System.ComponentModel.Description("Koþulun Uygulanacaðý Hücrelerin Yazý Rengi")]
        [System.ComponentModel.DisplayName("Yazý Rengi")]
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