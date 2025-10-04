using AvukatProLib.Extras;
using System;

namespace AvukatProLib.Hesap
{
    public class OdemeFeragat
    {
        public OdemeFeragat()
        {
        }

        public OdemeFeragat(DateTime tarih, ParaVeDovizId para, EksiltenTipi tipi)
            : this(tarih, para, tipi, null)
        {
        }

        public OdemeFeragat(DateTime tarih, ParaVeDovizId para, EksiltenTipi tipi, Object tag)
        {
            Tarih = tarih;
            Para = para;
            Tipi = tipi;
            Tag = tag;
        }

        public ParaVeDovizId Para;
        public Object Tag;
        public DateTime Tarih;
        public EksiltenTipi Tipi;
    }
}