using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProLib.Rapor.Util
{
    internal interface IRaporSource
    {
        object ChartDataSource { get; set; }

        bool EnableChart { get; }

        bool EnableGrid { get; }

        bool EnablePivot { get; }

        bool EnablePrintChart { get; }

        bool EnablePrintList { get; }

        bool EnablePrintPivot { get; }

        bool EnableSaveChart { get; }

        bool EnableSaveList { get; }

        bool EnableSavePivot { get; }

        string Groups { get; }

        object ListDataSource { get; set; }

        string MenuName { get; }

        object PivotDataSource { get; set; }

        string Title { get; }

        GridColumn[] GetGridColumns();

        PivotGridField[] GetPivotFields();

        void PrintChart();

        void PrintListe();

        void PrintPivot();

        void SaveChart();

        void SaveListe();

        void SavePivot();
    }
}