namespace ReportPro
{
    public class ChartDataSource
    {
        public ChartDataSource()
        {
        }

        public string _ArgumentName;

        public string ArgumentName
        {
            get { return _ArgumentName; }
            set { _ArgumentName = value; }
        }

        public int Value { get; set; }
    }

    public class ChartDataSource1
    {
        public ChartDataSource1()
        { }
        
        public string ArgumentName { get; set; }

        public int Value { get; set; }

        public int Yil { get; set; }
    }
}