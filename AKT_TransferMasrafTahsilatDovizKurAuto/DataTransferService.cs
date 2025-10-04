using AvukatProLib;
using AvukatProLib2.Data;
using AvukatProLib2.Data.SqlClient;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AKT_TransferMasrafTahsilatDovizKurAuto
{
    public partial class DataTransferService : ServiceBase
    {
        public DataTransferService()
        {
            InitializeComponent();
        }

        private int taskCheckerInterval = 300000;

        private System.Timers.Timer TimerTaskChecker;

        protected override void OnStart(string[] args)
        {
            TimerTaskChecker = new System.Timers.Timer();

            TimerTaskChecker.Interval = taskCheckerInterval;
            TimerTaskChecker.Elapsed += new System.Timers.ElapsedEventHandler(TimerTaskChecker_Elapsed);
            TimerTaskChecker.Start();
        }

        protected override void OnStop()
        {
        }

        private void GetConnectionSettings()
        {
            AvukatProLib.CompInfo info = CompInfo.CompInfoListGetir()[0];

            SqlNetTiersProvider prov = new SqlNetTiersProvider();
            System.Collections.Specialized.NameValueCollection nameValueCollection = new System.Collections.Specialized.NameValueCollection();
            nameValueCollection.Add("UseStoredProcedure", "false");
            nameValueCollection.Add("EnableEntityTracking", "true");
            nameValueCollection.Add("EntityCreationalFactoryType", "AvukatProLib2.Entities.EntityFactory");
            nameValueCollection.Add("EnableMethodAuthorization", "false");
            nameValueCollection.Add("ConnectionString", info.ConStr);
            nameValueCollection.Add("ConnectionStringName", "conStr" + info.LisansBilgisi.AdSoyad);
            nameValueCollection.Add("ProviderInvariantName", "System.Data.SqlClient");
            prov.Initialize(info.LisansBilgisi.AdSoyad, nameValueCollection);
            DataRepository.LoadProvider(prov, true);

            AvukatProLib2.Data.DataRepository.AddConnection(info.LisansBilgisi.AdSoyad, info.ConStr);

            AvukatProLib.Kimlik.SirketBilgisi = info;

            BelgeUtil.Inits.context = new AvukatProLib.Arama.AvpDataContext(info.ConStr);

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
        }

        private void TimerTaskChecker_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Windows Service ayrı bir proje olduğundan DB işlemlerinde çalışabilmek için aşağıdaki ayarların yapılması gerekmektedir.
            GetConnectionSettings();

            XDocument docs = new XDocument();

            #region Masraf

            List<Masraflar> MasrafList = new List<Masraflar>();
            docs = XDocument.Load(Application.StartupPath + "\\Masraflar.xml");

            foreach (var doc in docs.Descendants("MASRAF"))
            {
                MasrafList.Add(MethodsForMasrafTahsilat.BindMasrafXML(doc));
            }

            //MasrafList.ForEach(item => MethodsForMasrafTahsilat.CheckMasrafAvans(item));

            foreach (var item in MasrafList)
            {
                MethodsForMasrafTahsilat.CheckMasrafAvans(item);
            }

            //Tabloya kaydedilen aktarılan masrafların XML dostyasından silinmesi.
            docs.Descendants("MASRAF").Remove();
            docs.Save(Application.StartupPath + "\\Masraflar.xml");

            #endregion Masraf

            #region Tahsilat

            List<Tahsilatlar> TahsilatList = new List<Tahsilatlar>();
            docs = XDocument.Load(Application.StartupPath + "\\Tahsilatlar.xml");

            foreach (var doc in docs.Descendants("TAHSILAT"))
            {
                TahsilatList.Add(MethodsForMasrafTahsilat.BindTahsilatXML(doc));
            }

            TahsilatList.ForEach(item => MethodsForMasrafTahsilat.CheckTahsilat(item));

            //Tabloya kaydedilen aktarılan tahsilatların XML dosyasından silinmesi.
            docs.Descendants("TAHSILAT").Remove();
            docs.Save(Application.StartupPath + "\\Tahsilatlar.xml");

            #endregion Tahsilat

            #region Döviz Kurları

            List<DovizKur> DovizKurList = new List<DovizKur>();
            docs = XDocument.Load(Application.StartupPath + "\\DovizKurlari.xml");

            foreach (var doc in docs.Descendants("DOVIZKUR"))
            {
                DovizKurList.Add(MethodsForDovizKurlari.BindDovizKurlari(doc));
            }

            MethodsForDovizKurlari.SetDovizKur(DovizKurList);

            //Tabloya kaydedilen aktarılan döviz kurları XML dosyasından silinmesi.
            docs.Descendants("DOVIZKUR").Remove();
            docs.Save(Application.StartupPath + "\\DovizKurlari.xml");

            #endregion Döviz Kurları
        }
    }
}