namespace AvProExportImport.Util
{
    public class ColumnFormat
    {
        private string _columnName;

        private string _format;

        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        public string Format
        {
            get { return _format; }
            set { _format = value; }
        }
    }
}