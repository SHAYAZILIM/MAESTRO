using System;

namespace AdimAdimDavaKaydi
{
    /// <summary>
    /// Biçimlendirme deðerlerini tutan class
    /// </summary>
    [Serializable]
    public class Bilgi
    {
        [field: NonSerializedAttribute]
        public event EventHandler<PropertyChangedEventArgler> PropertyChanged;

        private string sutun;

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

        private System.Drawing.Color arkaPlanRengi;

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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgler("ArkaPlanRengi", value));
            }
        }

        private System.Drawing.Color arkaPlanRengi2;

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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgler("ArkaPlanRengi2", value));
            }
        }

        private System.Int32 arkaPlanRengiArgb;

        /// <summary>
        /// Koþulun Uygulanacaðý Hücrelerin Arka Plan Rengi
        /// </summary>
        [System.ComponentModel.Description("Koþulun Uygulanacaðý Hücrelerin Arka Plan Rengi")]
        [System.ComponentModel.DisplayName("Arka Plan Rengi Argb")]
        public System.Int32 ArkaPlanRengiArgb
        {
            get { return arkaPlanRengiArgb; }
            set
            {
                arkaPlanRengiArgb = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgler("ArkaPlanRengi", value));
            }
        }

        private System.Int32 arkaPlanRengi2Argb;

        /// <summary>
        /// Koþulun Uygulanacaðý Hücrelerin Arka Plan Geçiþ Rengi
        /// </summary>
        [System.ComponentModel.Description("Koþulun Uygulanacaðý Hücrelerin Arka Plan Geçiþ Rengi")]
        [System.ComponentModel.DisplayName("Arka Plan Rengi 2 Argb")]
        public System.Int32 ArkaPlanRengi2Argb
        {
            get { return arkaPlanRengi2Argb; }
            set
            {
                arkaPlanRengi2Argb = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgler("ArkaPlanRengi2", value));
            }
        }

        private System.Drawing.Color kenarlikRengi;

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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgler("KenarlikRengi", value));
            }
        }

        private System.Drawing.Color yaziRengi;

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

        private System.Int32 kenarlikRengiArgb;

        /// <summary>
        /// Koþulun Uygulanacaðý Hücrelerin Kenarlýk Rengi
        /// </summary>
        [System.ComponentModel.Description("Koþulun Uygulanacaðý Hücrelerin Kenarlýk Rengi")]
        [System.ComponentModel.DisplayName("Kenarlýk Rengi")]
        public System.Int32 KenarlikRengiArgb
        {
            get { return kenarlikRengiArgb; }
            set
            {
                kenarlikRengiArgb = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgler("KenarlikRengi", value));
            }
        }

        private System.Int32 yaziRengiArgb;

        /// <summary>
        /// Koþulun Uygulanacaðý Hücrelerin Yazý Rengi
        /// </summary>
        [System.ComponentModel.Description("Koþulun Uygulanacaðý Hücrelerin Yazý Rengi")]
        [System.ComponentModel.DisplayName("Yazý Rengi")]
        public System.Int32 YaziRengiArgb
        {
            get { return yaziRengiArgb; }
            set
            {
                yaziRengiArgb = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgler("YaziRengi", value));
            }
        }

        private System.Drawing.Drawing2D.LinearGradientMode renkGecisYonu;

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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgler("RenkGecisYonu", value));
            }
        }

        private DevExpress.XtraGrid.FormatConditionEnum kosul;

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

        public object deger1;

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

        public object deger2;

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

        private bool satiraUygula;

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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgler("SatiraUygula", value));
            }
        }

        private string sutun1;

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

        private string sutun2;

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

        private KarsilastirmaTipi tip;

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

        private DegerTipi degerTipi;

        /// <summary>
        /// Deðerlerin Tipi
        /// </summary>
        [System.ComponentModel.DisplayName("Deðerlerin Tipi")]
        [System.ComponentModel.Description(
            "Yapýlacak Karþýlaþtýrmanýn Tipi (Sayýsal : Sayýsal Karþýlaþtýrma\nAlfabetik : Alfabetik Karþýlaþtýrma\nTarih : Tarih Karþýlaþtýrmasý\nMantýksal : True(Evet)/False(Hayýr) Karþýlaþtýrma)"
            )]
        public DegerTipi DegerlerinTipi
        {
            get { return degerTipi; }
            set
            {
                degerTipi = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgler("DegerlerinTipi", value));
            }
        }
    }

    [Serializable]
    public class PropertyChangedEventArgler : EventArgs
    {
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

        public PropertyChangedEventArgler()
        {
        }

        public PropertyChangedEventArgler(string propertyName, object value)
        {
            PropertyName = propertyName;
            Value = value;
        }
    }

    [Serializable]
    public enum KarsilastirmaTipi
    {
        Sutun,
        Deger
    }

    [Serializable]
    public enum DegerTipi
    {
        Sayýsal,
        Alfabetik,
        Tarih,
        Mantýksal
    }
}