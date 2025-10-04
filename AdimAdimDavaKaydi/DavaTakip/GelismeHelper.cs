using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;

namespace AdimAdimDavaKaydi.DavaTakip
{
    public class GelismeHelper
    {
        public enum DavaTip
        {
            Ceza = 1,
            Hukuk = 2,
            AsCeza = 6,
            Idare = 5,
            Vergi = 7,
            Noter = 9,
            Savcilik = 10,
            Icra_Ceza = 13,
            Icra_Hukuk = 23,
        }

        #region Static Methods

        /// <summary>
        /// All Rows Visible
        /// </summary>
        /// <param name="vg">VGrid Control</param>
        public static void GridRowsVisible(VGridControl vg)
        {
            foreach (DevExpress.XtraVerticalGrid.Rows.BaseRow row in vg.Rows)
            {
                row.Visible = false;
            }
        }

        #endregion Static Methods
    }
}