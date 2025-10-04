using DevExpress.XtraGrid.Views.Base;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Editor.General
{
    public static class EditorUtil
    {
        public static List<ViewColumnFilterInfo> filters = new List<ViewColumnFilterInfo>();

        public static AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR> SablonRaporlar =
            new AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR>();
    }
}