using System.Collections.Generic;

namespace AvProExportImport.Util
{
    public class ExcelTable : System.Data.DataTable
    {
        private List<ColumnFormat> _formats;

        private List<CellStyle> _hücreStili;

        public List<ColumnFormat> Formats
        {
            get { return _formats; }
            set { _formats = value; }
        }

        public List<CellStyle> HücreStili
        {
            get { return _hücreStili; }
            set { _hücreStili = value; }
        }
    }
}