using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TableConverter
{
    public partial class TableStringConverter
    {
        private static List<TDI_KOD_DOVIZ_TIP> _DovizSource;

        public static List<TDI_KOD_DOVIZ_TIP> DovizSource
        {
            get
            {
                if (_DovizSource == null)
                    _DovizSource = new List<TDI_KOD_DOVIZ_TIP>(DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetAll());
                return _DovizSource;
            }
        }

    }
}