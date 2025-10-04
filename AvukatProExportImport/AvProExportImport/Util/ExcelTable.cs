using System.Collections.Generic;

namespace AvProExportImport.Util
{
    public class ExcelTable : System.Data.DataTable
    {
        private List<ColumnFormat> _formats;

        private List<CellStyle> _h�creStili;

        public List<ColumnFormat> Formats
        {
            get { return _formats; }
            set { _formats = value; }
        }

        public List<CellStyle> H�creStili
        {
            get { return _h�creStili; }
            set { _h�creStili = value; }
        }
    }
}