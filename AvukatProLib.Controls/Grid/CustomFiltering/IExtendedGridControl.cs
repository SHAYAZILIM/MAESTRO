using DevExpress.XtraGrid.FilterEditor;

namespace AvukatProLib.Controls.Grid.CustomFiltering
{
    public interface IExtendedGridControl
    {
        string FilterText { get; set; }

        string FilterValue { get; set; }

        GridFilterControl GridsFilterControl { get; set; }
    }
}