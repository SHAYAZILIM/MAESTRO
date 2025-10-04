using DevExpress.XtraGrid.FilterEditor;

namespace AdimAdimDavaKaydi.Util.Grid.CustomFiltering
{
    public interface IExtendedGridControl
    {
        string FilterValue { get; set; }

        string FilterText { get; set; }

        GridFilterControl GridsFilterControl { get; set; }
    }
}