using AvukatProLib;
using AvukatProLib.Util;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace AdimAdimDavaKaydi.Ajanda.Forms.MainForms
{
    public class AjandaDataSource
    {
        public AjandaDataSource()
        {
        }

        public AjandaDataSource(string key, object data)
        {
            this.Key = key;
            this.Datas = data;
        }

        public object Datas { get; set; }

        public int Index { get; set; }

        public string Key { get; set; }

        public bool Save()
        {
            try
            {
                SaveRecord.Save(this.Datas);
            }
            catch 
            {
                return false;
            }

            return true;
        }
    }

    public class AjandaDataSourceCollection : List<AjandaDataSource>
    {
        public AjandaDataSource FindByKey(string key)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Key == key)
                {
                    return this[i];
                }
            }
            return null;
        }
    }

    public class AppointmentData
    {
        public AppointmentData(per_AV001_TDI_BIL_IS_Asistan item)
        {
            this.IS = item;
            this.ACIKLAMA = item.ACIKLAMA;
            this.ADLIYE = item.ADLIYE;
            this.GOREV = item.GOREV;
            this.NO = item.NO;
            this.AJANDADA_GORUNSUN_MU = item.AJANDADA_GORUNSUN_MU;
            this.BASLANGIC_TARIHI = item.BASLANGIC_TARIHI;
            this.BITIS_TARIHI = item.BITIS_TARIHI;
            this.DURUM = item.DURUM;
            this.ESAS_NO = item.ESAS_NO;
            this.ETIKET_ID = item.ETIKET_ID;
            this.HATIRLATILSIN_MI = item.HATIRLATILSIN_MI;
            this.HATIRLATMA_BILGISI = item.HATIRLATMA_BILGISI;
            this.HATIRLATMA_ID = item.HATIRLATMA_ID;
            this.ID = item.ID;
            this.IS_NO = item.IS_NO;
            this.ALT_KATEGORI = item.ALT_KATEGORI;
            this.KONU = item.KONU;
            this.ONGORULEN_BITIS_TARIHI = item.ONGORULEN_BITIS_TARIHI;
            this.TEKRARLAMA_BILGISI = item.TEKRARLAMA_BILGISI;
            this.TIP = item.TIP;
            this.YAPILACAK_IS = item.YAPILACAK_IS;
            this.YER = item.YER;
            this.isNew = false;
        }

        public AppointmentData(per_AV001_TDI_BIL_IS_Asistan item, int cariId)
        {
            if (item == null) return;
            this.IS = item;
            this.ACIKLAMA = item.ACIKLAMA;
            this.ADLIYE = item.ADLIYE;
            this.GOREV = item.GOREV;
            this.NO = item.NO;
            this.AJANDADA_GORUNSUN_MU = item.AJANDADA_GORUNSUN_MU;
            this.BASLANGIC_TARIHI = item.BASLANGIC_TARIHI;
            this.BITIS_TARIHI = item.BITIS_TARIHI;
            this.DURUM = item.DURUM;
            this.ESAS_NO = item.ESAS_NO;
            this.ETIKET_ID = item.ETIKET_ID;
            this.HATIRLATILSIN_MI = item.HATIRLATILSIN_MI;
            this.HATIRLATMA_BILGISI = item.HATIRLATMA_BILGISI;
            this.HATIRLATMA_ID = item.HATIRLATMA_ID;
            this.ID = item.ID;
            this.IS_NO = item.IS_NO;
            this.ALT_KATEGORI = item.ALT_KATEGORI;
            this.KONU = item.KONU;
            this.ONGORULEN_BITIS_TARIHI = item.ONGORULEN_BITIS_TARIHI;
            this.TEKRARLAMA_BILGISI = item.TEKRARLAMA_BILGISI;
            this.TIP = item.TIP;
            this.YAPILACAK_IS = item.YAPILACAK_IS;
            this.YER = item.YER;
            this.RESOURCEID = cariId;
            this.isNew = false;
        }

        public AppointmentData(per_AV001_TDI_BIL_IS_Asistan item, int cariId, bool isnew)
        {
            this.IS = item;
            this.ACIKLAMA = item.ACIKLAMA;
            this.ADLIYE = item.ADLIYE;
            this.GOREV = item.GOREV;
            this.NO = item.NO;
            this.AJANDADA_GORUNSUN_MU = item.AJANDADA_GORUNSUN_MU;
            this.BASLANGIC_TARIHI = item.BASLANGIC_TARIHI;
            this.BITIS_TARIHI = item.BITIS_TARIHI;
            this.DURUM = item.DURUM;
            this.ESAS_NO = item.ESAS_NO;
            this.ETIKET_ID = item.ETIKET_ID;
            this.HATIRLATILSIN_MI = item.HATIRLATILSIN_MI;
            this.HATIRLATMA_BILGISI = item.HATIRLATMA_BILGISI;
            this.HATIRLATMA_ID = item.HATIRLATMA_ID;
            this.ID = item.ID;
            this.IS_NO = item.IS_NO;
            this.ALT_KATEGORI = item.ALT_KATEGORI;
            this.KONU = item.KONU;
            this.ONGORULEN_BITIS_TARIHI = item.ONGORULEN_BITIS_TARIHI;
            this.TEKRARLAMA_BILGISI = item.TEKRARLAMA_BILGISI;
            this.TIP = item.TIP;
            this.YAPILACAK_IS = item.YAPILACAK_IS;
            this.YER = item.YER;
            this.RESOURCEID = cariId;
            this.isNew = isnew;
            if (isnew)
            {
                AV001_TDI_BIL_IS_TARAF taraf1 = new AV001_TDI_BIL_IS_TARAF();
                taraf1.CARI_ID = cariId;
                taraf1.IS_TARAF_ID = 1;
                AV001_TDI_BIL_IS_TARAF taraf2 = new AV001_TDI_BIL_IS_TARAF();
                taraf2.CARI_ID = cariId;
                taraf2.IS_TARAF_ID = 2;
                TARAFLAR.Add(taraf1);
                TARAFLAR.Add(taraf2);
            }
        }

        public AppointmentData(per_AV001_TDI_BIL_IS_Asistan item, int cariId, bool isnew, DateTime startDate)
        {
            this.IS = item;
            this.ACIKLAMA = item.ACIKLAMA;
            this.ADLIYE = item.ADLIYE;
            this.GOREV = item.GOREV;
            this.NO = item.NO;
            this.AJANDADA_GORUNSUN_MU = item.AJANDADA_GORUNSUN_MU;
            this.BASLANGIC_TARIHI = startDate;
            this.ONGORULEN_BITIS_TARIHI = startDate.AddHours(1);
            this.DURUM = item.DURUM;
            this.ESAS_NO = item.ESAS_NO;
            this.ETIKET_ID = item.ETIKET_ID;
            this.HATIRLATILSIN_MI = item.HATIRLATILSIN_MI;
            this.HATIRLATMA_BILGISI = item.HATIRLATMA_BILGISI;
            this.HATIRLATMA_ID = item.HATIRLATMA_ID;
            this.ID = item.ID;
            this.IS_NO = item.IS_NO;
            this.ALT_KATEGORI = item.ALT_KATEGORI;
            this.KONU = item.KONU;
            this.TEKRARLAMA_BILGISI = item.TEKRARLAMA_BILGISI;
            this.TIP = item.TIP;
            this.YAPILACAK_IS = item.YAPILACAK_IS;
            this.YER = item.YER;
            this.RESOURCEID = cariId;
            this.isNew = isnew;
            if (isnew)
            {
                AV001_TDI_BIL_IS_TARAF taraf1 = new AV001_TDI_BIL_IS_TARAF();
                taraf1.CARI_ID = cariId;
                taraf1.IS_TARAF_ID = 1;
                AV001_TDI_BIL_IS_TARAF taraf2 = new AV001_TDI_BIL_IS_TARAF();
                taraf2.CARI_ID = cariId;
                taraf2.IS_TARAF_ID = 2;
                TARAFLAR.Add(taraf1);
                TARAFLAR.Add(taraf2);
            }
        }

        public AppointmentData()
        {
            this.isNew = true;
        }

        private AppointmentPro _Appointment;

        private per_AV001_TDI_BIL_IS_Asistan _IS;

        public string ACIKLAMA { get; set; }

        public string ADLIYE { get; set; }

        public bool AJANDADA_GORUNSUN_MU { get; set; }

        public string ALT_KATEGORI { get; set; }

        public AppointmentPro Apointment
        {
            get
            {
                _Appointment = new AppointmentPro();
                _Appointment.AllDay = this.HER_GUN_MU ?? false; //.HasValue ? this.HER_GUN_MU.Value : false;
                _Appointment.Description = this.ACIKLAMA;
                _Appointment.Start = this.BASLANGIC_TARIHI ?? DateTime.Now; //.Value;
                _Appointment.End = this.ONGORULEN_BITIS_TARIHI ?? DateTime.Now; //.Value;
                _Appointment.HasReminder = this.HATIRLATILSIN_MI;
                _Appointment.LabelId = this.ETIKET_ID ?? 0; //.Value;
                _Appointment.Location = this.YER;
                _Appointment.ResourceId = this.RESOURCEID;
                _Appointment.StatusId = this.STATU_ID ?? 1; //.HasValue ? this.STATU_ID.Value : 1;
                _Appointment.Subject = GorunenAciklama(this);
                _Appointment.AppData = this;
                return _Appointment;
            }
        }

        public DateTime? BASLANGIC_TARIHI { get; set; }

        public DateTime? BITIS_TARIHI { get; set; }

        public bool DURUM { get; set; }

        public string ESAS_NO { get; set; }

        public int? ETIKET_ID { get; set; }

        public int? FORM_ID { get; set; }

        public string GOREV { get; set; }

        public bool HATIRLATILSIN_MI { get; set; }

        public string HATIRLATMA_BILGISI { get; set; }

        public int? HATIRLATMA_ID { get; set; }

        public bool? HER_GUN_MU { get; set; }

        public int ID { get; set; }

        public per_AV001_TDI_BIL_IS_Asistan IS
        {
            get
            {
                if (_IS == null) _IS = new per_AV001_TDI_BIL_IS_Asistan();
                _IS.ACIKLAMA = this.ACIKLAMA;
                if (string.IsNullOrEmpty(this.ADLIYE))
                    _IS.ADLIYE = this.ADLIYE;
                if (string.IsNullOrEmpty(this.GOREV))
                    _IS.GOREV = this.GOREV;
                if (string.IsNullOrEmpty(this.NO))
                    _IS.NO = this.NO;
                _IS.AJANDADA_GORUNSUN_MU = this.AJANDADA_GORUNSUN_MU;
                _IS.BASLANGIC_TARIHI = Convert.ToDateTime(this.BASLANGIC_TARIHI.Value);
                if (this.BITIS_TARIHI.HasValue)
                    _IS.BITIS_TARIHI = this.BITIS_TARIHI.Value;
                _IS.DURUM = this.DURUM;
                _IS.ESAS_NO = this.ESAS_NO;
                if (this.ETIKET_ID.HasValue)
                    _IS.ETIKET_ID = this.ETIKET_ID.Value;
                _IS.HATIRLATILSIN_MI = HATIRLATILSIN_MI;
                _IS.HATIRLATMA_BILGISI = HATIRLATMA_BILGISI;
                if (this.HATIRLATMA_ID.HasValue)
                    _IS.HATIRLATMA_ID = this.HATIRLATMA_ID.Value;
                _IS.ID = ID;
                _IS.IS_NO = IS_NO;
                if (string.IsNullOrEmpty(this.ALT_KATEGORI))
                    _IS.ALT_KATEGORI = this.ALT_KATEGORI;
                _IS.KONU = KONU;
                if (this.ONGORULEN_BITIS_TARIHI.HasValue)
                    _IS.ONGORULEN_BITIS_TARIHI = this.ONGORULEN_BITIS_TARIHI.Value;
                _IS.TEKRARLAMA_BILGISI = TEKRARLAMA_BILGISI;
                if (this.TIP.HasValue)
                    _IS.TIP = this.TIP.Value;
                _IS.YAPILACAK_IS = YAPILACAK_IS;
                _IS.YER = YER;
                return _IS;
            }
            set { _IS = value; }
        }

        public string IS_NO { get; set; }

        public bool isNew { get; set; }

        public DateTime KAYIT_TARIHI { get; set; }

        public string KONU { get; set; }

        public bool MUHASEBELESTIRILSIN_MI { get; set; }

        public string NO { get; set; }

        public int? ONCELIK_ID { get; set; }

        public DateTime? ONGORULEN_BITIS_TARIHI { get; set; }

        public string REFERANS_NO { get; set; }

        public int RESOURCEID { get; set; }

        public int? STATU_ID { get; set; }

        public int? SUBE_KOD_ID { get; set; }

        public TList<AV001_TDI_BIL_IS_TARAF> TARAFLAR { get; set; }

        public string TEKRARLAMA_BILGISI { get; set; }

        public int? TIP { get; set; }

        public string YAPILACAK_IS { get; set; }

        public string YER { get; set; }

        public AppointmentData Clone()
        {
            AppointmentData clone = new AppointmentData();
            clone.ACIKLAMA = this.ACIKLAMA;
            clone.ADLIYE = this.ADLIYE;
            clone.GOREV = this.GOREV;
            clone.NO = this.NO;
            clone.AJANDADA_GORUNSUN_MU = this.AJANDADA_GORUNSUN_MU;
            clone.BASLANGIC_TARIHI = this.BASLANGIC_TARIHI;
            clone.BITIS_TARIHI = this.BITIS_TARIHI;
            clone.DURUM = this.DURUM;
            clone.ESAS_NO = this.ESAS_NO;
            clone.ETIKET_ID = this.ETIKET_ID;
            clone.FORM_ID = this.FORM_ID;
            clone.HATIRLATILSIN_MI = this.HATIRLATILSIN_MI;
            clone.HATIRLATMA_BILGISI = this.HATIRLATMA_BILGISI;
            clone.HATIRLATMA_ID = this.HATIRLATMA_ID;
            clone.HER_GUN_MU = this.HER_GUN_MU;
            clone.ID = this.ID;
            clone.IS_NO = this.IS_NO;
            clone.KAYIT_TARIHI = this.KAYIT_TARIHI;
            clone.KONU = this.KONU;
            clone.MUHASEBELESTIRILSIN_MI = this.MUHASEBELESTIRILSIN_MI;
            clone.ONCELIK_ID = this.ONCELIK_ID;
            clone.ONGORULEN_BITIS_TARIHI = this.ONGORULEN_BITIS_TARIHI;
            clone.STATU_ID = this.STATU_ID;
            clone.SUBE_KOD_ID = this.SUBE_KOD_ID;
            clone.TEKRARLAMA_BILGISI = this.TEKRARLAMA_BILGISI;
            clone.TIP = this.TIP;
            clone.YAPILACAK_IS = this.YAPILACAK_IS;
            clone.YER = this.YER;
            clone.RESOURCEID = this.RESOURCEID;
            clone.TARAFLAR = this.TARAFLAR;
            return clone;
        }

        private string GorunenAciklama(AppointmentData appointmentData)
        {
            //string adliye, gorev, birimNo, kategori, esasNo = string.Empty;
            //adliye = string.Empty;
            //gorev = string.Empty;
            //birimNo = string.Empty;
            //kategori = string.Empty;
            string gorunenAciklama = string.Empty;

            //if (!string.IsNullOrEmpty(appointmentData.ADLIYE))
            //    adliye = appointmentData.ADLIYE;
            //if (!string.IsNullOrEmpty(appointmentData.GOREV))
            //    gorev = appointmentData.GOREV;
            //if (!string.IsNullOrEmpty(appointmentData.NO))
            //    birimNo = appointmentData.NO;

            //esasNo = appointmentData.ESAS_NO;

            //if (string.IsNullOrEmpty(appointmentData.ALT_KATEGORI))
            //    kategori = appointmentData.ALT_KATEGORI;

            gorunenAciklama = appointmentData.ALT_KATEGORI + " " + appointmentData.ADLIYE + " " + appointmentData.NO + " " + appointmentData.GOREV + " " + appointmentData.ESAS_NO + " ";

            return gorunenAciklama;
        }
    }

    public class AppointmentPro : Appointment
    {
        public AppointmentData AppData { get; set; }
    }

    public partial class frmAjanda : DevExpress.XtraEditors.XtraForm
    {
        public frmAjanda()
        {
            InitializeComponent();
            this._Isler = null;
            this.MdiParent = AnaForm.mdiAvukatPro.MainForm;
        }

        public frmAjanda(DataTable isler, IEntity openedRecord, bool takipEkranindan)
        {
            InitializeComponent();
            this.TakipEkranindanAjanda = takipEkranindan;
            this._Isler = isler;
            this.OpenedRecord = openedRecord;
        }

        public static DevExpress.XtraScheduler.SchedulerStorage SchedulerStorage;

        public bool TakipEkranindanAjanda;

        private Dictionary<per_AV001_TDI_BIL_CARI_Asistan, List<AppointmentData>> AllData;

        #region <KA-20090622>

        //TODO:Forma dava,icra,sözleþme,soruþturma iþ datasourcelarýnýn parametre olarak gönderilmesi saðlandý.

        #endregion <KA-20090622>

        public IEntity OpenedRecord { get; set; }

        #region <KA-20090622>

        //TODO:Genel ajanda formunun açýlmasý saðlandý. iþ data source ajanda formuna eklendi.

        #endregion <KA-20090622>

        private DataTable _Isler { get; set; }

        public void BindAllDataByCari(List<per_AV001_TDI_BIL_CARI_Asistan> lstCariler)
        {
            per_AV001_TDI_BIL_CARI_Asistan ben = DataRepository.per_AV001_TDI_BIL_CARI_AsistanProvider.Get("ID=" + Kimlikci.Kimlik.Cari_ID, "ID")[0];
            if (!lstCariler.Contains(ben))
                lstCariler.Add(ben);

            List<per_AV001_TDI_BIL_IS_Asistan> TumIsler = new List<per_AV001_TDI_BIL_IS_Asistan>();
            foreach (var cari in lstCariler)
            {
                string bas = ucIsAjanda1.ucAjanda1.dateNavigator1.SelectionStart.Year + "." + ucIsAjanda1.ucAjanda1.dateNavigator1.SelectionStart.Month + "." + ucIsAjanda1.ucAjanda1.dateNavigator1.SelectionStart.Day + " 00:00:00";
                string bit = ucIsAjanda1.ucAjanda1.dateNavigator1.SelectionEnd.Year + "." + ucIsAjanda1.ucAjanda1.dateNavigator1.SelectionEnd.Month + "." + ucIsAjanda1.ucAjanda1.dateNavigator1.SelectionEnd.Day + " 23:59:59";

                DateTime basTarih = Convert.ToDateTime(bas);
                DateTime bitTarih = Convert.ToDateTime(bit);

                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                cn.AddParams("@CARI_ID", cari.ID);
                cn.AddParams("@basTarih", basTarih);
                cn.AddParams("@bitTarih", bitTarih);
                _Isler = cn.GetDataTable("select a.* from dbo.per_AV001_TDI_BIL_IS_Asistan(nolock) a where AJANDADA_GORUNSUN_MU=1 and a.ID in (select IS_ID from dbo.AV001_TDI_BIL_IS_TARAF(nolock) x where x.CARI_ID=@CARI_ID and x.IS_TARAF_ID = 2) and BASLANGIC_TARIHI between @basTarih and @bitTarih");

                List<AppointmentData> lstCariIsler = new List<AppointmentData>();
                foreach (DataRow isl in _Isler.Rows)
                {
                    if (!lstCariIsler.Exists(delegate(AppointmentData apdata) { return apdata.ID == (int)isl["ID"]; }))
                    {
                        VList<per_AV001_TDI_BIL_IS_Asistan> ss = DataRepository.per_AV001_TDI_BIL_IS_AsistanProvider.Get("ID=" + isl["ID"], "ID");
                        lstCariIsler.Add(new AppointmentData(ss[0], cari.ID));
                    }
                    if (!AllData.Keys.Contains(cari))
                        AllData.Add(cari, lstCariIsler);
                }

                //_Isler = BelgeUtil.Inits.context.per_AV001_TDI_BIL_IS_Asistans.Where(item => item.AJANDADA_GORUNSUN_MU && BelgeUtil.Inits.context.AV001_TDI_BIL_IS_TARAFs.Where(c => c.CARI_ID == cari.ID && c.IS_TARAF_ID == 2).Select(vi => vi.IS_ID).Contains(item.ID)).ToList();
                //List<AppointmentData> lstCariIsler = new List<AppointmentData>();
                //foreach (var isl in _Isler)
                //    if (!lstCariIsler.Exists(delegate(AppointmentData apdata) { return apdata.ID == isl.ID; }))
                //        lstCariIsler.Add(new AppointmentData(isl, cari.ID));
                //if (!AllData.Keys.Contains(cari))
                //    AllData.Add(cari, lstCariIsler);
            }
        }

        public void BindAllDataByFoy()
        {
            Dictionary<per_AV001_TDI_BIL_CARI_Asistan, List<AppointmentData>> DataRef = new Dictionary<per_AV001_TDI_BIL_CARI_Asistan, List<AppointmentData>>();
            List<AppointmentData> lstCariIsler = new List<AppointmentData>();

            per_AV001_TDI_BIL_CARI_Asistan cari = null;
            cari = DataRepository.per_AV001_TDI_BIL_CARI_AsistanProvider.Get("ID=" + AvukatProLib.Kimlik.Bilgi.CARI_ID.Value, "ID")[0];

            string bas = ucIsAjanda1.ucAjanda1.dateNavigator1.SelectionStart.Year + "." + ucIsAjanda1.ucAjanda1.dateNavigator1.SelectionStart.Month + "." + ucIsAjanda1.ucAjanda1.dateNavigator1.SelectionStart.Day + " 00:00:00";
            string bit = ucIsAjanda1.ucAjanda1.dateNavigator1.SelectionEnd.Year + "." + ucIsAjanda1.ucAjanda1.dateNavigator1.SelectionEnd.Month + "." + ucIsAjanda1.ucAjanda1.dateNavigator1.SelectionEnd.Day + " 23:59:59";

            DateTime basTarih = Convert.ToDateTime(bas);
            DateTime bitTarih = Convert.ToDateTime(bit);

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            cn.AddParams("@CARI_ID", cari.ID);
            cn.AddParams("@basTarih", basTarih);
            cn.AddParams("@bitTarih", bitTarih);
            _Isler = cn.GetDataTable("select a.* from dbo.per_AV001_TDI_BIL_IS_Asistan(nolock) a where AJANDADA_GORUNSUN_MU=1 and a.ID in (select IS_ID from dbo.AV001_TDI_BIL_IS_TARAF(nolock) x where x.CARI_ID=@CARI_ID and x.IS_TARAF_ID = 2) and BASLANGIC_TARIHI between @basTarih and @bitTarih");

            foreach (DataRow isl in _Isler.Rows)
            {
                if (!lstCariIsler.Exists(delegate(AppointmentData apdata) { return apdata.ID == (int)isl["ID"]; }))
                {
                    VList<per_AV001_TDI_BIL_IS_Asistan> ss = DataRepository.per_AV001_TDI_BIL_IS_AsistanProvider.Get("ID=" + isl["ID"], "ID");
                    lstCariIsler.Add(new AppointmentData(ss[0], cari.ID));
                }
                if (lstCariIsler.Count > 0)
                {
                    if (DataRef.Where(vi => vi.Key == cari).ToList().Count == 0)
                        DataRef.Add(cari, lstCariIsler);
                }
            }

            AllData = DataRef;
        }

        public void SaveAll()
        {
            this.ucIsAjanda1.SaveAll();
        }

        private void frmAjanda_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            if (DesignMode)
            {
                return;
            }

            AjandaDataSourceCollection dsCol = new AjandaDataSourceCollection();

            #region <KA-20090622>

            //TODO:ajanda uc ye view olarak iþ datalarý gönderilmesi saðlandý.

            #endregion <KA-20090622>

            AllData = new Dictionary<per_AV001_TDI_BIL_CARI_Asistan, List<AppointmentData>>();
            BackgroundWorker bckWorker = new BackgroundWorker();
            bckWorker.DoWork += delegate
            {
                this.Enabled = false;
                if (this._Isler == null)
                {
                    List<per_AV001_TDI_BIL_CARI_Asistan> lstCariler = new List<per_AV001_TDI_BIL_CARI_Asistan>();
                    lstCariler.Add(DataRepository.per_AV001_TDI_BIL_CARI_AsistanProvider.Get("ID=" + AvukatProLib.Kimlik.Bilgi.CARI_ID.Value, "ID")[0]);
                    BindAllDataByCari(lstCariler);
                    SetMappings();
                }
                else
                {
                    BindAllDataByFoy();
                }
            };
            bckWorker.RunWorkerCompleted += delegate
            {
                this.ucIsAjanda1.TakipEkranindanAjanda = TakipEkranindanAjanda;
                this.ucIsAjanda1.Data = AllData;
                this.Enabled = true;

                ucIsAjanda1.ucAjanda1.barEditItem3.EditValue = "Benim Ýþlerim";
                ucIsAjanda1.ucAjanda1.BindAllData();
            };
            bckWorker.RunWorkerAsync();

            //TODO: yapýlan deðiþikliklerin kaybolmasý ile oluþan aþaðýdaki hata doðrýltusunda tarafýmdan comment edilmiþtir . Kadir in yaptýðý deðiþiklikler yok.
            //this.ucIsAjanda1.OpenedRecord = this.OpenedRecord;
        }

        private void SetMappings()
        {
            for (int i = 0; i < _Isler.Rows.Count; i++)
            {
                if (_Isler.Rows[i]["TEKRARLAMA_BILGISI"] == null)
                {
                    if (_Isler.Rows[i]["TEKRARLAMA_BILGISI"].ToString() == string.Empty)
                        _Isler.Rows[i]["TIP"] = (int)AppointmentType.Normal;
                }
            }
            SchedulerStorage = new SchedulerStorage();
            SchedulerStorage.Appointments.DataSource = _Isler;
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