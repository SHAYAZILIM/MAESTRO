using AvukatProLib2.Entities;

namespace Datas.TablesColumn
{
    public partial class TablesColumnData
    {
        #region Methods

        public static void SetColumnValueByName(IEntity Record, string ColumnName, object Value)
        {
            if (Record == null) return;
            Record.GetType().GetProperty(ColumnName).SetValue(Record, Value, null);
        }

        #endregion Methods
    }
}