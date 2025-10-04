using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace AvukatPro.Database
{
    public class CetKodTable
    {
        private List<CetKodTableColumn> _Columns = new List<CetKodTableColumn>();

        public List<CetKodTableColumn> Columns
        {
            get { return _Columns; }
            set { _Columns = value; }
        }

        public string Name { get; set; }

        public bool IsSelected { get; set; }

        public static List<CetKodTable> GetTables(string file)
        {
            if (File.Exists(file))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<CetKodTable>));

                StreamReader reader = new StreamReader(file);
                List<CetKodTable> tables = (List<CetKodTable>)serializer.Deserialize(reader);
                reader.Close();
                return tables;
            }
            else
            {
                return new List<CetKodTable>();
            }
        }

        public static void SaveTables(string filepath, List<CetKodTable> tables)
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<CetKodTable>));

            System.IO.StreamWriter file = new System.IO.StreamWriter(filepath);
            writer.Serialize(file, tables);
            file.Close();
        }
    }

    public class CetKodTableColumn
    {
        public string DataType { get; set; }

        public bool IsCondition { get; set; }

        public bool IsIdentity { get; set; }

        public bool IsUpdate { get; set; }

        public string Name { get; set; }
    }
}