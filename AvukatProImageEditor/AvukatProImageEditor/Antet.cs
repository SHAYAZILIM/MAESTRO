using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace AvukatProImageEditor
{
    #region Enumerations

    [Serializable]
    public enum Renkler
    {
        Siyah,
        Beyaz,
        Kırmızı,
        Yeşil,
        Gri,
        Mavi,
        Sarı,
        Eflatun,
        Mor,
        Açık_Mavi,
        Açık_Yeşil,
        Koyu_Mavi,
        Koyu_Kırmızı,
        Açık_Kırmızı,
        Pembe,
        Kahveregi,
        Koyu_Yeşil,
        Lacivert,
        Bordo,
    }

    [Serializable]
    public enum ResimTipi
    {
        Logo,
        Resim,
    }

    #endregion Enumerations

    [Serializable]
    public class AntetDosyasi
    {
        #region Fields

        private AV001_TDIE_BIL_ANTET _antet;
        private int _Heigth;
        private List<Resimler> _resimler;
        private List<Yazilar> _Yazilar;
        private int width;

        #endregion Fields

        #region Properties

        public AV001_TDIE_BIL_ANTET Antet
        {
            get { return _antet; }
            set { _antet = value; }
        }

        public int Heigth
        {
            get { return _Heigth; }
            set { _Heigth = value; }
        }

        public List<Resimler> Resimler
        {
            get { return _resimler; }
            set { _resimler = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public List<Yazilar> Yazilar
        {
            get { return _Yazilar; }
            set { _Yazilar = value; }
        }

        #endregion Properties
    }

    [Serializable]
    public class CizilenNesne
    {
        #region Fields

        private int _x;
        private int _y;
        private int _z;

        #endregion Fields

        #region Properties

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public int Z
        {
            get { return _z; }
            set { _z = value; }
        }

        #endregion Properties
    }

    [Serializable]
    public class Resimler : CizilenNesne
    {
        #region Fields

        private object _dosya;
        private ResimTipi _tip;
        private int heigth;
        private int width;

        #endregion Fields

        #region Properties

        public object Dosya
        {
            get { return _dosya; }
            set { _dosya = value; }
        }

        public int Heigth
        {
            get { return heigth; }
            set { heigth = value; }
        }

        public ResimTipi Tip
        {
            get { return _tip; }
            set { _tip = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        #endregion Properties
    }

    [Serializable]
    public class Yazilar : CizilenNesne
    {
        #region Fields

        private Renkler _color;
        private Font _font;
        private string _text;

        #endregion Fields

        #region Properties

        public Renkler Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public Font Font
        {
            get { return _font; }
            set { _font = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        #endregion Properties
    }
}