using DevExpress.XtraScheduler;
using System;

namespace Asistan.LinqDAL
{
    public class AppointmentData
    {
        public AppointmentData(AV001_TDI_BIL_I item)
        {
            this.ACIKLAMA = item.ACIKLAMA;
            this.BASLANGIC_TARIHI = item.BASLANGIC_TARIHI;
            this.ETIKET_ID = item.ETIKET_ID;
            this.HATIRLATILSIN_MI = item.HATIRLATILSIN_MI;
            this.HER_GUN_MU = item.HER_GUN_MU;
            this.KONU = item.KONU;
            this.ONGORULEN_BITIS_TARIHI = item.ONGORULEN_BITIS_TARIHI;
            this.STATU_ID = item.STATU_ID;
            this.YER = item.YER;
        }

        private AppointmentPro _Appointment;

        public string ACIKLAMA { get; set; }

        public AppointmentPro Apointment
        {
            get
            {
                _Appointment = new AppointmentPro();
                _Appointment.AllDay = this.HER_GUN_MU.HasValue ? this.HER_GUN_MU.Value : false;
                _Appointment.Description = this.ACIKLAMA;
                _Appointment.Start = this.BASLANGIC_TARIHI.Value;
                _Appointment.End = this.ONGORULEN_BITIS_TARIHI.Value;
                _Appointment.HasReminder = this.HATIRLATILSIN_MI;
                _Appointment.LabelId = this.ETIKET_ID.Value;
                _Appointment.Location = this.YER;
                _Appointment.StatusId = this.STATU_ID.HasValue ? this.STATU_ID.Value : 1;
                _Appointment.Subject = this.KONU;
                _Appointment.AppData = this;
                return _Appointment;
            }
        }

        public DateTime? BASLANGIC_TARIHI { get; set; }

        public int? ETIKET_ID { get; set; }

        public bool HATIRLATILSIN_MI { get; set; }

        public bool? HER_GUN_MU { get; set; }

        public string KONU { get; set; }

        public DateTime? ONGORULEN_BITIS_TARIHI { get; set; }

        public int? STATU_ID { get; set; }

        public string YER { get; set; }
    }

    public class AppointmentPro : Appointment
    {
        public AppointmentData AppData { get; set; }
    }
}