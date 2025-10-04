using System;

namespace AvukatProLib.Controls
{
    [Serializable]
    public enum DegerTipi
    {
        Say�sal,
        Alfabetik,
        Tarih,
        Mant�ksal
    }

    [Serializable]
    public enum KarsilastirmaTipi
    {
        Sutun,
        Deger
    }

    /// <summary>
    /// Bi�imlendirme de�erlerini tutan class
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
        /// Ko�ulun Uygulanaca�� H�crelerin Arka Plan Rengi
        /// </summary>
        [System.ComponentModel.Description("Ko�ulun Uygulanaca�� H�crelerin Arka Plan Rengi")]
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
        /// Ko�ulun Uygulanaca�� H�crelerin Arka Plan Ge�i� Rengi
        /// </summary>
        [System.ComponentModel.Description("Ko�ulun Uygulanaca�� H�crelerin Arka Plan Ge�i� Rengi")]
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
        /// Uygulanacak Ko�ul ��in Birinci Kar��la�t�rma De�eri
        /// </summary>
        [System.ComponentModel.Description("Uygulanacak Ko�ul ��in Birinci Kar��la�t�rma De�eri")]
        [System.ComponentModel.DisplayName("De�er 1")]
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
        /// Uygulanacak Ko�ul ��in �kinci Kar��la�t�rma De�eri
        /// </summary>
        [System.ComponentModel.Description("Uygulanacak Ko�ul ��in �kinci Kar��la�t�rma De�eri")]
        [System.ComponentModel.DisplayName("De�er 2")]
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
        /// De�erlerin Tipi
        /// </summary>
        [System.ComponentModel.DisplayName("De�erlerin Tipi")]
        [System.ComponentModel.Description("Yap�lacak Kar��la�t�rman�n Tipi (Say�sal : Say�sal Kar��la�t�rma\nAlfabetik : Alfabetik Kar��la�t�rma\nTarih : Tarih Kar��la�t�rmas�\nMant�ksal : True(Evet)/False(Hay�r) Kar��la�t�rma)")]
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
        /// Ko�ulun Uygulanaca�� H�crelerin Kenarl�k Rengi
        /// </summary>
        [System.ComponentModel.Description("Ko�ulun Uygulanaca�� H�crelerin Kenarl�k Rengi")]
        [System.ComponentModel.DisplayName("Kenarl�k Rengi")]
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
        /// Uygulanmas�n� �stedi�iniz Ko�ul
        /// </summary>
        [System.ComponentModel.Description("Uygulanmas�n� �stedi�iniz Ko�ul")]
        [System.ComponentModel.DisplayName("Ko�ul")]
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
        /// Ko�ulun Uygulanaca�� H�crelerin �ki Renk Aras�ndaki Ge�i� Y�n�
        /// </summary>
        [System.ComponentModel.Description("Ko�ulun Uygulanaca�� H�crelerin �ki Renk Aras�ndaki Ge�i� Y�n�")]
        [System.ComponentModel.DisplayName("Renk Ge�i� Y�n�")]
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
        /// Renklendirmeyi Sat�ra Uygula
        /// </summary>
        [System.ComponentModel.DisplayName("SatirinTumuneUygula")]
        [System.ComponentModel.Description("Renklendirmeyi Sat�ra Uygula")]
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
        /// "Kar��la�t�r�lacak olan s�tun"
        /// </summary>
        [System.ComponentModel.Description("Kar��la�t�r�lacak olan s�tun")]
        [System.ComponentModel.DisplayName("Kar��la�t�r�lacak s�tun")]
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
        /// Kar��la�t�r�lacak s�tunlar Sutun1
        /// </summary>
        [System.ComponentModel.DisplayName("S�tun 1")]
        [System.ComponentModel.Description("Kar��la�t�r�lacak s�tunlar")]
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
        /// Kar��la�t�r�lacak s�tunlar Stun2
        /// </summary>
        [System.ComponentModel.DisplayName("S�tun 2")]
        [System.ComponentModel.Description("Kar��la�t�r�lacak s�tunlar")]
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
        /// Kar��la�t�rma Tipi
        /// </summary>
        [System.ComponentModel.DisplayName("Kar��la�t�rma Tipi")]
        [System.ComponentModel.Description("Ba�ka Bir S�tun �le Kar��la�t�r / De�er �le Kar��la�t�r")]
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
        /// Ko�ulun Uygulanaca�� H�crelerin Yaz� Rengi
        /// </summary>
        [System.ComponentModel.Description("Ko�ulun Uygulanaca�� H�crelerin Yaz� Rengi")]
        [System.ComponentModel.DisplayName("Yaz� Rengi")]
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