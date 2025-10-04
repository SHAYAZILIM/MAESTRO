using AvukatProAsistan.Util;
using AvukatProLib;
using AvukatProLib2.Data;
using AvukatProLib2.Data.SqlClient;
using DevExpress.XtraScheduler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Asistan.LinqDAL
{
    public enum FadeType { In, Out }

    public class Isler
    {
        public static bool ConYuklendi = false;
        public static DbAsistanDataContext dbAsistan;

        private static DevExpress.XtraScheduler.SchedulerStorage _SchedulerStorage;

        private static IEnumerable<per_AV001_TDI_BIL_IS_Asistan> cariIsler;

        private static IEnumerable<per_AV001_TDI_BIL_IS_Asistan> tarafIsler;

        public static SchedulerStorage SchedulerStorage
        {
            get { return Isler._SchedulerStorage; }
            set { Isler._SchedulerStorage = value; }
        }

        public static List<per_AV001_TDI_BIL_IS_Asistan> TumIsler { get; set; }

        public static void GetAll(TDI_BIL_KULLANICI_LISTESI userList)
        {
            if (!ConYuklendi)
            {
                CompInfo gio = CompInfo.CmpNfoList[0];
                SqlNetTiersProvider prov = new SqlNetTiersProvider();
                System.Collections.Specialized.NameValueCollection nameValueCollection = new System.Collections.Specialized.NameValueCollection();
                nameValueCollection.Add("UseStoredProcedure", "true");
                nameValueCollection.Add("EnableEntityTracking", "true");
                nameValueCollection.Add("EntityCreationalFactoryType", "AvukatProLib2.Entities.EntityFactory");
                nameValueCollection.Add("EnableMethodAuthorization", "false");
                nameValueCollection.Add("ConnectionString", gio.ConStr);
                nameValueCollection.Add("ConnectionStringName", "conStr" + gio.LisansBilgisi.AdSoyad);
                nameValueCollection.Add("ProviderInvariantName", "System.Data.SqlClient");
                prov.Initialize(gio.LisansBilgisi.AdSoyad, nameValueCollection);
                DataRepository.LoadProvider(prov, true);
                ConYuklendi = true;
            }

            dbAsistan.SubmitChanges();
            DataRepository.AV001_TDI_BIL_IS_TARAFProvider.GetByCARI_ID(userList.CARI_ID);
            TumIsler = new List<per_AV001_TDI_BIL_IS_Asistan>();

            cariIsler = dbAsistan.per_AV001_TDI_BIL_IS_Asistans.Where(item => DataRepository.AV001_TDI_BIL_IS_TARAFProvider.GetByCARI_ID(userList.CARI_ID).Select(vi => vi.IS_ID).Contains(item.ID));
            tarafIsler = cariIsler.AsEnumerable();
            TumIsler.AddRange(cariIsler);
            SetMappings();
        }

        private static void SetMappings()
        {
            for (int i = 0; i < TumIsler.Count; i++)
            {
                if (string.IsNullOrEmpty(TumIsler[i].TEKRARLAMA_BILGISI))
                    TumIsler[i].TIP = (int)AppointmentType.Normal;
            }
            SchedulerStorage = new SchedulerStorage();
            SchedulerStorage.Appointments.DataSource = TumIsler;
            SchedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ACIKLAMA", "ACIKLAMA"));
            SchedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ADLIBIRIMADLIYEID", "ADLIYE"));
            SchedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ADLIBIRIMGOREVID", "GOREV"));
            SchedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ADLIBIRIMNOID", "NO"));
            SchedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("AJANDADAGORUNSUNMU", "AJANDADA_GORUNSUN_MU"));
            SchedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("BITISTARIHI", "BITIS_TARIHI"));
            SchedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("DURUM", "DURUM"));
            SchedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ESAS_NO", "ESAS_NO"));
            SchedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("HATIRLATILSINMI", "HATIRLATILSIN_MI"));
            SchedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("HATIRLATMAID", "HATIRLATMA_ID"));
            SchedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ID", "ID"));
            SchedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("IS_NO", "IS_NO"));
            SchedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("KATEGORIID", "ALT_KATEGORI"));
            SchedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ONGORULENBITISTARIHI", "ONGORULEN_BITIS_TARIHI"));
            SchedulerStorage.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("BASLANGICTARIHI", "BASLANGIC_TARIHI"));
            SchedulerStorage.Appointments.Mappings.Start = "BASLANGIC_TARIHI";
            SchedulerStorage.Appointments.Mappings.Description = "YAPILACAK_IS";
            SchedulerStorage.Appointments.Mappings.End = "ONGORULEN_BITIS_TARIHI";
            SchedulerStorage.Appointments.Mappings.Label = "ETIKET_ID";
            SchedulerStorage.Appointments.Mappings.Location = "YER";
            SchedulerStorage.Appointments.Mappings.RecurrenceInfo = "TEKRARLAMA_BILGISI";
            SchedulerStorage.Appointments.Mappings.ReminderInfo = "HATIRLATMA_BILGISI";
            SchedulerStorage.Appointments.Mappings.Subject = "GorunenAciklama";
        }
    }
}