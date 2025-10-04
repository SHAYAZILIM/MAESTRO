namespace AvukatProLib.Util
{
    public class ConStringBilesenler
    {
        //Data Source=.;Initial Catalog=AvukatPro;Integrated Security=True ;Uid="";Password=;
        // "server=192.9.0.199;database=AVP_NHA_NG;uid=yilmaz;pwd=123
        private string DataSource;

        private string InitialCatalog;

        private bool IntegratedSecurity;

        public string datasource
        {
            get { return DataSource; }
            set { DataSource = value; }
        }

        public string initialcatalog
        {
            get { return InitialCatalog; }
            set { InitialCatalog = value; }
        }

        public bool integradsecurity
        {
            get { return IntegratedSecurity; }
            set { IntegratedSecurity = value; }
        }

        public void ConstrBirlestir(string server, string initialKatalog, bool integratedSecurity)
        {
        }
    }
}