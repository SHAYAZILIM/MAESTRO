namespace AvProExportImport.Util
{
    public class CellStyle
    {
        private string _columnName;

        private int _row;

        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }
    }
}