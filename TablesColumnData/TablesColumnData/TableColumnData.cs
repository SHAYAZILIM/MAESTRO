using AvukatProLib2.Entities;

namespace Datas.TablesColumn
{
    public partial class TablesColumnData
    {
        #region Methods

        public static EntityColumns GetColumnValueByName(IEntity Record, string ColumnName)
        {
            if (Record == null) return null;
            EntityColumns returnValue = new EntityColumns();
            returnValue.Name = ColumnName;
            returnValue.Table = Record.TableName;
            returnValue.Index = 2;
            returnValue.Type = Record.GetType().GetProperty(ColumnName).PropertyType.Name;
            returnValue.Value = Record.GetType().GetProperty(ColumnName).GetValue(Record, null);
            return returnValue;
        }

        #endregion Methods
    }
}