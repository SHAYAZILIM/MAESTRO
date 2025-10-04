using AvukatProLib2.Entities;

using TableConverter;

using Ent = AvukatProLib2.Entities;

namespace Datas.TablesColumn
{
    public partial class TablesColumnData
    {
        #region Methods

        public static EntityColumns GetColumnValueByNameFromRecord(IEntity Record, string ColumnName)
        {
            return GetColumnValueByName(Record, ColumnName);
        }

        public static void SetColumnValueByNameFromRecord(IEntity Record, string ColumnName, object Value)
        {
            SetColumnValueByName(Record, ColumnName, Value);
        }

        #endregion Methods
    }
}