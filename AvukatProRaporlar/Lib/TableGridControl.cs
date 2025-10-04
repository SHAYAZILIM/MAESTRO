using DevExpress.XtraGrid.Views.Grid;

namespace AvukatProRaporlar.Lib
{
    public class TableGridControl : GridControlEx
    {
        public string DataSourceTable = "";

        public void SetDataSource()
        {
            this.DataSource = TablesGrids.GetTablesData(this.DataSourceTable);
        }
    }
}