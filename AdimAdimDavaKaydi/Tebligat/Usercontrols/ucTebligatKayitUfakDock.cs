using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge;
using AdimAdimDavaKaydi.Util;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;

namespace AdimAdimDavaKaydi.UserControls
{
    //<YY-20090625>
    //TODO: ACÝL BÝR ÞEKÝLDE BU CLASS REVIEW EDILMELI.. enteresan kodlar mevcut
    //</YY-20090625>
    public partial class ucTebligatKayitUfakDock : DevExpress.XtraEditors.XtraUserControl
    {
        public bool Ihtarname;

        public bool Klasordenmi;

        public AV001_TDIE_BIL_PROJE MyProje = new AV001_TDIE_BIL_PROJE();

        //Klasörden Baðýmsýz Ýhtarname Kaydý Yapýlabilmesi için eklendi. Gerekli Ýþlemler bu property üzerinden yapýlýyor.
        private TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> _myAlacakNedenTaraf;

        private AV001_TI_BIL_FOY _myFoy;

        private TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> muhataplar = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();

        private TList<AV001_TDI_BIL_TEBLIGAT_YAPAN> yapanlar = new TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>();

        public ucTebligatKayitUfakDock()
        {
            InitializeComponent();
            xtraTabPage2.PageVisible = false;
            c_lueDosya.EditValueChanged += c_lueDosya_EditValueChanged;
        }

        public event EventHandler<TebligatKaydedildiEventArgs> tebligatKaydedildi;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> MyAlacakNedenTaraf
        {
            get { return _myAlacakNedenTaraf; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    this._myAlacakNedenTaraf = value;

                    MyDataSource = new TList<AV001_TDI_BIL_TEBLIGAT>();
                    MyDataSource.AddNew();

                    DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepLoad(value, false,
                                                                                    DeepLoadType.IncludeChildren,
                                                                                    typeof(TDIE_KOD_TARAF_SIFAT));
                    foreach (var item in value)
                    {
                        if (item.TARAF_SIFAT_IDSource != null && item.TARAF_SIFAT_IDSource.HANGI_TARAF_NO == 1)

                        //TAKÝP EDEN
                        {
                            AV001_TDI_BIL_TEBLIGAT_YAPAN yapan = new AV001_TDI_BIL_TEBLIGAT_YAPAN();

                            yapan.KAYIT_TARIHI = DateTime.Now;
                            yapan.KONTROL_NE_ZAMAN = DateTime.Now;
                            yapan.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                            yapan.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                            yapan.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                            yapan.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                            yapan.YAPAN_CARI_ID = item.TARAF_CARI_ID;
                            yapanlar.Add(yapan);
                        }
                        else if (item.TARAF_SIFAT_IDSource != null && item.TARAF_SIFAT_IDSource.HANGI_TARAF_NO == 2)

                        //TAKÝP EDÝLEN
                        {
                            AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatap = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();

                            muhatap.KAYIT_TARIHI = DateTime.Now;
                            muhatap.KONTROL_NE_ZAMAN = DateTime.Now;
                            muhatap.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                            muhatap.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                            muhatap.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                            muhatap.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                            muhatap.MUHATAP_CARI_ID = item.TARAF_CARI_ID;
                            muhataplar.Add(muhatap);
                        }
                    }

                    exGridGonderen.DataSource = yapanlar;
                    exGridMuhatap.DataSource = muhataplar;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TDI_BIL_TEBLIGAT> MyDataSource
        {
            get
            {
                if (bndTebligat.DataSource is TList<AV001_TDI_BIL_TEBLIGAT> && !DesignMode)
                    return (TList<AV001_TDI_BIL_TEBLIGAT>)bndTebligat.DataSource;

                return null;
            }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren,
                                                                           typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>
                                                                               ),
                                                                           typeof(TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>),
                                                                           typeof(TList<AV001_TDIE_BIL_BELGE>),
                                                                           typeof(TList<TDI_KOD_TEBLIGAT_KONU>));
                    foreach (AV001_TDI_BIL_TEBLIGAT item in value)
                    {
                        DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.DeepLoad(
                            item.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection, false, DeepLoadType.IncludeChildren,
                            typeof(TList<AV001_TDI_BIL_CARI>));
                        DataRepository.AV001_TDI_BIL_TEBLIGAT_YAPANProvider.DeepLoad(
                            item.AV001_TDI_BIL_TEBLIGAT_YAPANCollection, false, DeepLoadType.IncludeChildren,
                            typeof(TList<AV001_TDI_BIL_CARI>));
                        DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren,
                                                                               typeof(TDI_KOD_TEBLIGAT_KONU));
                    }

                    this.bndTebligat.DataSource = value;
                    Bind();
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return _myFoy; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    this._myFoy = value;
                }
                if (Ihtarname)
                    setValue();
            }
        }

        public void IsKaydet()
        {
            AV001_TDI_BIL_IS ds = new AV001_TDI_BIL_IS();
            TList<AV001_TDI_BIL_IS> isler = new TList<AV001_TDI_BIL_IS>();
            ds.ACIKLAMA = memoEdit2.Text;
            ds.ADLI_BIRIM_ADLIYE_ID = (int)c_lueAdliye.EditValue;
            ds.ADLI_BIRIM_GOREV_ID = (int)c_leuGorev.EditValue;
            ds.ADLI_BIRIM_NO_ID = (int)c_lueBirimNo.EditValue;
            ds.AJANDADA_GORUNSUN_MU = true;
            ds.BASLANGIC_TARIHI = (DateTime)hAZIRLAMAtARIHIDateEdit.EditValue;
            ds.ESAS_NO = eSAS_NOTextEdit.Text;
            ds.HATIRLATILSIN_MI = hATIRLATILSIN_MICheckEdit.Checked;
            ds.KONU = string.Format("{0} nolu Evrak kaydý", textEdit1.Text);
            ds.ONGORULEN_BITIS_TARIHI = ds.BASLANGIC_TARIHI.Value.AddHours(1);
            ds.REFERANS_NO = rEFERANS_NOTextEdit.Text;
            ds.AV001_TDI_BIL_IS_TARAFCollection =
                (TList<AV001_TDI_BIL_IS_TARAF>)aV001TDIBILISTARAFCollectionBindingSource.DataSource;
            ds.MODUL_ID = 9;
            ds.STAMP = 0;
            if (hATIRLATILSIN_MICheckEdit.Checked)
            {
                SchedulerStorage schedulerStorage1 = new SchedulerStorage();

                schedulerStorage1.Appointments.DataSource = isler;
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ACIKLAMA", "ACIKLAMA"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ADLIBIRIMADLIYEID",
                                                                               "ADLI_BIRIM_ADLIYE_ID"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ADLIBIRIMGOREVID", "ADLI_BIRIM_GOREV_ID"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ADLIBIRIMNOID", "ADLI_BIRIM_NO_ID"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("AJANDADAGORUNSUNMU",
                                                                               "AJANDADA_GORUNSUN_MU"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("BITISTARIHI", "BITIS_TARIHI"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("DURUM", "DURUM"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ESASNO", "ESAS_NO"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("FORMID", "FORM_ID"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("HATIRLATILSINMI", "HATIRLATILSIN_MI"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("HATIRLATMAID", "HATIRLATMA_ID"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ID", "ID"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ISNO", "IS_NO"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("KATEGORIID", "KATEGORI_ID"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("KAYITTARIHI", "KAYIT_TARIHI"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("KLASORKODU", "KLASOR_KODU"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("KONTROLKIM", "KONTROL_KIM"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("KONTROLKIMID", "KONTROL_KIM_ID"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("KONTROLNEZAMAN", "KONTROL_NE_ZAMAN"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("KOSUL", "KOSUL"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("MODULID", "MODUL_ID"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("MUHASEBELESTIRILSINMI",
                                                                               "MUHASEBELESTIRILSIN_MI"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ONCELIKID", "ONCELIK_ID"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ONGORULENBITISZAMANI",
                                                                               "ONGORULEN_BITIS_ZAMANI"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("REFERANSNO", "REFERANS_NO"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("STAMP", "STAMP"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("STATUID", "STATU_ID"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("SUBEKODID", "SUBE_KOD_ID"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("SUBEKODU", "SUBE_KODU"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("TABLOID", "TABLO_ID"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("TARAFLAR", "TARAFLAR"));
                schedulerStorage1.Appointments.CustomFieldMappings.Add(
                    new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ZAMAN_KOSULU", "ZAMAN_KOSULU"));
                schedulerStorage1.Appointments.Mappings.AllDay = "HER_GUN_MU";
                schedulerStorage1.Appointments.Mappings.Description = "YAPILACAK_IS";
                schedulerStorage1.Appointments.Mappings.End = "ONGORULEN_BITIS_TARIHI";
                schedulerStorage1.Appointments.Mappings.Label = "ETIKET_ID";
                schedulerStorage1.Appointments.Mappings.Location = "YER";
                schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "TEKRARLAMA_BILGISI";
                schedulerStorage1.Appointments.Mappings.ReminderInfo = "HATIRLATMA_BILGISI";
                schedulerStorage1.Appointments.Mappings.Start = "BASLANGIC_TARIHI";
                schedulerStorage1.Appointments.Mappings.Status = "KONTROL_VERSIYON";
                schedulerStorage1.Appointments.Mappings.Subject = "KONU";
                schedulerStorage1.Appointments.Mappings.Type = "TIP";
                schedulerStorage1.Appointments.Add(schedulerStorage1.CreateAppointment(AppointmentType.Pattern));

                schedulerStorage1.Appointments[0].RecurrenceInfo.DayNumber =
                    ucHatirlatmaPeriyot1.RecurrenceInfo.DayNumber;
                schedulerStorage1.Appointments[0].RecurrenceInfo.Start = ds.BASLANGIC_TARIHI.Value;
                if (ucHatirlatmaPeriyot1.RecurrenceInfo.Range == RecurrenceRange.EndByDate)
                    schedulerStorage1.Appointments[0].RecurrenceInfo.End = ucHatirlatmaPeriyot1.RecurrenceInfo.End;
                else
                    schedulerStorage1.Appointments[0].RecurrenceInfo.End = ds.ONGORULEN_BITIS_TARIHI.Value;

                schedulerStorage1.Appointments[0].RecurrenceInfo.Month = ucHatirlatmaPeriyot1.RecurrenceInfo.Month;
                schedulerStorage1.Appointments[0].RecurrenceInfo.OccurrenceCount =
                    ucHatirlatmaPeriyot1.RecurrenceInfo.OccurrenceCount;
                schedulerStorage1.Appointments[0].RecurrenceInfo.Periodicity =
                    ucHatirlatmaPeriyot1.RecurrenceInfo.Periodicity;
                schedulerStorage1.Appointments[0].RecurrenceInfo.Range = ucHatirlatmaPeriyot1.RecurrenceInfo.Range;
                schedulerStorage1.Appointments[0].RecurrenceInfo.Type = ucHatirlatmaPeriyot1.RecurrenceInfo.Type;
                schedulerStorage1.Appointments[0].RecurrenceInfo.Duration =
                    schedulerStorage1.Appointments[0].RecurrenceInfo.End.Subtract(
                        schedulerStorage1.Appointments[0].RecurrenceInfo.Start);
                schedulerStorage1.Appointments[0].RecurrenceInfo.WeekDays = ucHatirlatmaPeriyot1.RecurrenceInfo.WeekDays;
                schedulerStorage1.Appointments[0].RecurrenceInfo.WeekOfMonth =
                    ucHatirlatmaPeriyot1.RecurrenceInfo.WeekOfMonth;
                Reminder rmd = schedulerStorage1.Appointments[0].CreateNewReminder();
                rmd.TimeBeforeStart = (TimeSpan)durationEdit1.EditValue;
                rmd.AlertTime = schedulerStorage1.Appointments[0].Start;
                schedulerStorage1.Appointments[0].Reminders.Add(rmd);
            }
            ds.TEKRARLAMA_BILGISI = isler[0].TEKRARLAMA_BILGISI;
            ds.HATIRLATMA_BILGISI = isler[0].HATIRLATMA_BILGISI;
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_ISProvider.Save(ds);

            NNProcess.SaveIs(ds, (IEntity)bndTebligat.Current);
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_IS_TARAFProvider.Save(ds.AV001_TDI_BIL_IS_TARAFCollection);
            foreach (AV001_TDI_BIL_IS_TARAF item in ds.AV001_TDI_BIL_IS_TARAFCollection)
            {
                if (checkEdit1.Checked)
                {
                    AV001_TDI_BIL_HATIRLAT hatirlatma = new AV001_TDI_BIL_HATIRLAT();
                    hatirlatma.ACIKLAMA = ds.TEKRARLAMA_BILGISI ?? string.Empty;
                    hatirlatma.IS_TARAF_ID = item.ID;
                    hatirlatma.BASLAMA_TARIHI = ds.BASLANGIC_TARIHI.Value;
                    hatirlatma.BITIS_TARIHI = ds.ONGORULEN_BITIS_TARIHI.Value;
                    hatirlatma.KULLANICI_ID =
                        AvukatProLib2.Data.DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.GetByKULLANICI_ADI(
                            AvukatProLib.Kimlik.KullaniciAdi).ID;
                    hatirlatma.BASLANGIC_ID = 1;
                    hatirlatma.PERIYOD_ID = 1;
                    hatirlatma.IS_ID = ds.ID;
                    string hTipi = "";
                    if (chkEkran.Checked) hTipi += "0";
                    if (chkMail.Checked) hTipi += ",1";
                    if (chkSms.Checked) hTipi += ",2";
                    hatirlatma.HATIRLATMA_TIPI = hTipi;
                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_HATIRLATProvider.Save(hatirlatma);

                    // item.HATIRLATMA_ID = hatirlatma.ID;
                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_IS_TARAFProvider.Update(item);
                }
            }
        }

        public void SetKayitSayisiGorunum()
        {
            c_btnKayitSayisi.Text = string.Format("{0} / {1}", this.bndTebligat.Position + 1, this.bndTebligat.Count);
        }

        //Todo: Burya yeni Show Metotu Eklendi  Canan
        public void Show(TList<AV001_TDI_BIL_TEBLIGAT> tebl)
        {
            MyDataSource = tebl;
        }

        public void ShowDialog(AV001_TI_BIL_FOY icra)
        {
            this.textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndTebligat,
                                                                             "ICRA_FOY_NO", true));
            this.MyDataSource = icra.AV001_TDI_BIL_TEBLIGATCollection;
        }

        public void ShowDialog(AV001_TD_BIL_HAZIRLIK hazirlik)
        {
            this.textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndTebligat,
                                                                             "HAZIRLIK_NO", true));
            this.MyDataSource = hazirlik.AV001_TDI_BIL_TEBLIGATCollection;
        }

        public void Yeni()
        {
            if (MyFoy != null)
            {
                MyFoy.AV001_TDI_BIL_TEBLIGATCollection.AddNew();
            }
            else
            {
                if (Ihtarname != true)
                {
                    object data = bndTebligat.AddNew();
                    MyDataSource = new TList<AV001_TDI_BIL_TEBLIGAT>();
                    MyDataSource.Add((AV001_TDI_BIL_TEBLIGAT)data);
                }
                else
                    MyDataSource.AddNew();
            }
        }

        private void AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatab = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();
            muhatab.OKUNDU_MU = false;
            muhatab.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            muhatab.KONTROL_NE_ZAMAN = DateTime.Today;
            muhatab.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            muhatab.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            muhatab.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            muhatab.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            e.NewObject = muhatab;
        }

        private void AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_TEBLIGAT_YAPAN yapan = new AV001_TDI_BIL_TEBLIGAT_YAPAN();
            yapan.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            yapan.KONTROL_NE_ZAMAN = DateTime.Today;
            yapan.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            yapan.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            yapan.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            yapan.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            e.NewObject = yapan;
        }

        private void Bind()
        {
            if (bndTebligat.DataSource != null)
            {
                BelgeUtil.Inits.perCariGetir(this.repositoryItemLookUpEdit2);
                BelgeUtil.Inits.IsTarafGetir(this.repositoryItemLookUpEdit1);

                this.c_lueFormTipi.DataBindings.Clear();
                this.c_lueBirimNo.DataBindings.Clear();
                this.lueTebTip.DataBindings.Clear();
                this.c_leuGorev.DataBindings.Clear();
                this.c_lueAdliye.DataBindings.Clear();
                this.memoEdit2.DataBindings.Clear();
                this.eSAS_NOTextEdit.DataBindings.Clear();
                this.rEFERANS_NOTextEdit.DataBindings.Clear();
                this.hAZIRLAMAtARIHIDateEdit.DataBindings.Clear();
                this.exGridBelge.DataBindings.Clear();
                this.c_lueFormTipi.DataBindings.Clear();

                this.c_lueFormTipi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndTebligat,
                                                                                     "KONU_ID", true));
                this.c_lueBirimNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndTebligat,
                                                                                    "ADLI_BIRIM_NO_ID", true));
                this.lueTebTip.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndTebligat, "TIP_ID",
                                                                                 true));
                this.c_leuGorev.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndTebligat,
                                                                                  "ADLI_BIRIM_GOREV_ID", true));
                this.c_lueAdliye.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndTebligat,
                                                                                   "ADLI_BIRIM_ADLIYE_ID", true));
                this.memoEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndTebligat,
                                                                                 "ACIKLAMA", true));
                this.eSAS_NOTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndTebligat,
                                                                                       "TEBLIGAT_ESAS_NO", true));
                this.rEFERANS_NOTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndTebligat,
                                                                                           "TEBLIGAT_REFERANS_NO", true));
                this.hAZIRLAMAtARIHIDateEdit.DataBindings.Add(new Binding("EditValue", this.bndTebligat,
                                                                          "HAZIRLAMA_TARIH", true));
                this.exGridBelge.DataBindings.Add(new System.Windows.Forms.Binding("DataSource", this.bndTebligat,
                                                                                   "AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_TEBLIGAT",
                                                                                   true));
                aV001TDIBILISTARAFCollectionBindingSource.DataSource = new TList<AV001_TDI_BIL_IS_TARAF>();
            }
        }

        private void bndTebligat_AddingNew(object sender, AddingNewEventArgs e)
        {
            if (this.DesignMode)
                return;
            if (MyFoy == null)
            {
                //TODO: Buraya yeni twbligat olýþmasý için e.new object için bir tane yeni tebligat yaratýldý Canan
                AV001_TDI_BIL_TEBLIGAT addnew = new AV001_TDI_BIL_TEBLIGAT();
                addnew.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;
                addnew.TIP_ID = 4; // Ýhtar
                addnew.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                addnew.KONTROL_NE_ZAMAN = DateTime.Today;
                addnew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                addnew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                addnew.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                addnew.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                addnew.TEBLIGAT_REFERANS_NO = AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit.TebligatReferansNoOlustur();

                e.NewObject = addnew;
                if (e.NewObject is AV001_TDI_BIL_TEBLIGAT)
                {
                    this.exGridBelge.DataSource = addnew.AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_TEBLIGAT;
                }
            }
            else
            {
                AV001_TDI_BIL_TEBLIGAT addnew = RecordGenerator.Generate.GenerateAV001_TDI_BIL_TEBLIGATByRecord(MyFoy);
                addnew.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;
                addnew.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                addnew.KONTROL_NE_ZAMAN = DateTime.Today;
                addnew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                addnew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                addnew.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                addnew.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                addnew.TEBLIGAT_REFERANS_NO = AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit.TebligatReferansNoOlustur();
                e.NewObject = addnew;
                if (e.NewObject is AV001_TDI_BIL_TEBLIGAT)
                {
                    this.exGridBelge.DataSource = addnew.AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_TEBLIGAT;
                }
            }
        }

        private void bndTebligat_CurrentChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            if (bndTebligat.Current is AV001_TDI_BIL_TEBLIGAT)
            {
                AV001_TDI_BIL_TEBLIGAT tep = (AV001_TDI_BIL_TEBLIGAT)bndTebligat.Current;
                this.exGridBelge.DataSource = tep.AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_TEBLIGAT;
                tep.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddingNew += AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew;

                this.exGridGonderen.DataSource = tep.AV001_TDI_BIL_TEBLIGAT_YAPANCollection;
                tep.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew;
                this.exGridMuhatap.DataSource = tep.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection;
            }
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (this.bndTebligat.Current is AV001_TDI_BIL_TEBLIGAT)
            {
                TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> lstMuhatabs = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();
                TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> lstUcuncuSahis = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();
                TList<AV001_TDI_BIL_CARI_ALT> altCariler = new TList<AV001_TDI_BIL_CARI_ALT>();

                AV001_TDI_BIL_TEBLIGAT tebligat = (AV001_TDI_BIL_TEBLIGAT)this.bndTebligat.Current;

                if (tebligat.KONU_ID == 162)
                {
                    for (int i = 0; i < tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count; i++)
                    {
                        AV001_TDI_BIL_TEBLIGAT_MUHATAP tebMuh = tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[i];
                        if (tebMuh.CARI_ALT_ID.HasValue)
                        {
                            lstMuhatabs.Add(tebMuh);
                            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.DeepLoad(tebMuh,
                                                                                                              false,
                                                                                                              DeepLoadType
                                                                                                                  .
                                                                                                                  IncludeChildren,
                                                                                                              typeof(
                                                                                                                  AV001_TDI_BIL_CARI_ALT
                                                                                                                  ));
                            altCariler.Add(tebMuh.CARI_ALT_IDSource);
                        }
                        else
                        {
                            lstUcuncuSahis.Add(tebMuh);
                        }
                    }

                    DialogResult dr =
                        XtraMessageBox.Show(
                            lstUcuncuSahis.Count +
                            " adet üçüncü þahýs  bilgisi girilmiþ yenilerini eklemek istermmisiniz ?",
                            "Üçüncü þahýs ekle ?", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        ImportExportWithSelection.Import.frmUcuncuSahisBilgileri frmUcuncuSahis =
                            new ImportExportWithSelection.Import.frmUcuncuSahisBilgileri();
                        frmUcuncuSahis.MyDataSource = altCariler;

                        //frmUcuncuSahis.MdiParent = null;
                        frmUcuncuSahis.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frmUcuncuSahis.Show();
                        altCariler = frmUcuncuSahis.MyDataSource;
                    }
                }

                if (tebligat.KONU_ID == 163)
                {
                    for (int i = 0; i < tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count; i++)
                    {
                        AV001_TDI_BIL_TEBLIGAT_MUHATAP tebMuh = tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[i];
                        if (tebMuh.CARI_ALT_ID.HasValue)
                        {
                            lstMuhatabs.Add(tebMuh);
                        }
                        else
                        {
                            lstUcuncuSahis.Add(tebMuh);
                        }
                    }
                }

                if (tebligat.KONU_ID == 450)
                {
                    for (int i = 0; i < tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count; i++)
                    {
                        AV001_TDI_BIL_TEBLIGAT_MUHATAP tebMuh = tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[i];
                        if (tebMuh.CARI_ALT_ID.HasValue)
                        {
                            lstMuhatabs.Add(tebMuh);
                        }
                        else
                        {
                            lstUcuncuSahis.Add(tebMuh);
                        }
                    }
                }

                tebligat.ICRA_FOY_ID = 1287;

                frmEditor editor = new frmEditor();

                if (tebligat.ICRA_FOY_ID.HasValue)
                {
                    editor.OpenSablonInNewTab(
                        AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.GetByID(301));
                }

                for (int i = 0; i < altCariler.Count; i++)
                {
                    AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatab = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();
                    muhatab.CARI_ALT_ID = altCariler[i].ID;
                    muhatab.CARI_ALT_IDSource = altCariler[i];
                    if (!altCariler[i].UST_CARI_ID.HasValue)
                    {
                        continue;
                    }
                    muhatab.MUHATAP_CARI_ID = altCariler[i].UST_CARI_ID.Value;
                    muhatab.OKUNDU_MU = false;
                    muhatab.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    muhatab.KONTROL_NE_ZAMAN = DateTime.Today;
                    muhatab.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    muhatab.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    muhatab.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    muhatab.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                    ///   muhatab.TEBLIGAT_ID = tebligat.ID;
                    muhatab.TEBLIGAT_IDSource = tebligat;
                    tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Add(muhatab);

                    if (tebligat.ICRA_FOY_ID.HasValue)
                    {
                        uctxEditor edit =
                            editor.OpenSablonInNewTab(
                                AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.GetByID(301));
                        edit.TebligatMuhatab = muhatab;
                        AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(tebligat, false,
                                                                                                  DeepLoadType.
                                                                                                      IncludeChildren,
                                                                                                  typeof(
                                                                                                      AV001_TI_BIL_FOY));
                        edit.SetFieldsValues(false);
                    }
                }
            }
        }

        private void c_btnGeri_Click(object sender, EventArgs e)
        {
            //GERÝ
            bndTebligat.MovePrevious();
            SetKayitSayisiGorunum();
        }

        private void c_btnIleri_Click(object sender, EventArgs e)
        {
            bndTebligat.MoveNext();
            SetKayitSayisiGorunum();
        }

        private void c_btnKaydet_Click(object sender, EventArgs e)
        {
            if (!Klasordenmi)
            {
                //KAYDET
                DialogResult dr =
                    XtraMessageBox.Show(
                        "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine +
                        "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    bndTebligat.EndEdit();
                    TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                    try
                    {
                        //Todo : Muahasebe  Alt kategori Id 2. 3. kayýtlarda 0 oluyordu onu düzenlemek için böle bir kontrol yapýldý Canan ....
                        foreach (var item in MyDataSource)
                        {
                            if (
                                item.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Exists(
                                    delegate(AV001_TDI_BIL_TEBLIGAT_YAPAN t) { return t.YAPAN_CARI_ID == null || t.YAPAN_CARI_ID == 0; }))
                            {
                                MessageBox.Show("Tebligat Yapan cari seçiniz.");
                                return;
                            }
                        }
                        foreach (AV001_TDI_BIL_TEBLIGAT var in MyDataSource)
                        {
                            if (var.MUHASEBE_ALT_KATEGORI_ID == 0 && var.MUHASEBE_ALT_KATEGORI_IDSource != null)
                            {
                                TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI mhak = var.MUHASEBE_ALT_KATEGORI_IDSource;
                                var.MUHASEBE_ALT_KATEGORI_ID = mhak.ID;
                            }

                            TDI_KOD_TEBLIGAT_KONU konu =
                                DataRepository.TDI_KOD_TEBLIGAT_KONUProvider.GetByID(var.KONU_ID);
                            if (konu != null)
                            {
                                var.ALT_TUR_ID = konu.ALT_TUR_ID;
                                var.ANA_TUR_ID = konu.ANA_TUR_ID;
                            }
                        }

                        #region <GKN-20090609>

                        //Kayýtta hata alýnýyordu null kontrolü yapýldý
                        if (MyFoy != null || (c_lueDosya.EditValue != null && (int)c_lueDosya.EditValue > -1))
                        {
                            MyDataSource.ForEach(delegate(AV001_TDI_BIL_TEBLIGAT t)
                                                     {
                                                         if (MyFoy != null)
                                                             if (MyFoy.ID != 0)
                                                                 t.ICRA_FOY_ID = MyFoy.ID;
                                                             else
                                                                 t.ICRA_FOY_IDSource = MyFoy;
                                                         else if (c_lueModul.Text == "Icra"
                                                                  && c_lueDosya.EditValue != null
                                                                  && (int)c_lueDosya.EditValue > -1)
                                                             t.ICRA_FOY_ID = (int)c_lueDosya.EditValue;
                                                         else if (c_lueModul.Text == "Dava"
                                                                  && c_lueDosya.EditValue != null
                                                                  && (int)c_lueDosya.EditValue > -1)
                                                             t.DAVA_FOY_ID = (int)c_lueDosya.EditValue;
                                                     });

                            //MyFoy.AV001_TDI_BIL_TEBLIGATCollection.AddRange(MyDataSource);
                        }

                        tran.BeginTransaction();

                        if (MyFoy == null)
                        {
                            DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(tran, MyDataSource);
                        }
                        else if (MyFoy != null)
                        {
                            if (MyFoy.ID > 0)
                                DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(tran,
                                                                                       MyFoy.
                                                                                           AV001_TDI_BIL_TEBLIGATCollection);
                        }
                        else
                        {
                            DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(tran, MyDataSource);
                        }
                        tran.Commit();
                        if (tebligatKaydedildi != null)
                            tebligatKaydedildi(this, new TebligatKaydedildiEventArgs(MyDataSource[0]));

                        #endregion <GKN-20090609>

                        if (chkYapilacakIs.Checked)
                            IsKaydet();
                        XtraMessageBox.Show("Kayýt Ýþlemi Tamamlandý...");
                    }
                    catch (Exception ex)
                    {
                        if (tran.IsOpen)
                            tran.Rollback();

                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
            else
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                var frm = this.ParentForm as AdimAdimDavaKaydi.Forms.Icra.frmAlacakGirisi;
                TList<AV001_TI_BIL_ALACAK_NEDEN> alacakNedenleri = null;
                try
                {
                    MyDataSource[0].TEBLIGAT_REFERANS_NO = AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit.TebligatReferansNoOlustur();
                    MyDataSource[0].ANA_TUR_ID =
                        DataRepository.TDI_KOD_TEBLIGAT_KONUProvider.GetByID((int)c_lueFormTipi.EditValue).ANA_TUR_ID;
                    MyDataSource[0].ALT_TUR_ID =
                        DataRepository.TDI_KOD_TEBLIGAT_KONUProvider.GetByID((int)c_lueFormTipi.EditValue).ALT_TUR_ID;

                    tran.BeginTransaction();

                    DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(tran, MyDataSource);

                    foreach (var yapan in yapanlar)
                    {
                        yapan.TEBLIGAT_ID = MyDataSource[0].ID;
                    }
                    DataRepository.AV001_TDI_BIL_TEBLIGAT_YAPANProvider.Save(tran, yapanlar);
                    foreach (var muhatap in muhataplar)
                    {
                        muhatap.TEBLIGAT_ID = MyDataSource[0].ID;
                    }
                    DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.Save(tran, muhataplar);

                    if (
                        !MyProje.AV001_TDIE_BIL_PROJE_IHTARNAMECollection.Exists(
                            vi => vi.TEBLIGAT_ID == MyDataSource[0].ID))
                    {
                        AV001_TDIE_BIL_PROJE_IHTARNAME iht = new AV001_TDIE_BIL_PROJE_IHTARNAME();
                        iht.TEBLIGAT_ID = MyDataSource[0].ID;
                        iht.PROJE_ID = MyProje.ID;
                        DataRepository.AV001_TDIE_BIL_PROJE_IHTARNAMEProvider.DeepSave(tran, iht);
                    }
                    if (frm != null && frm.alacneden != null)
                        alacakNedenleri = frm.alacneden.FindAll("IsSelected", true);

                    if (alacakNedenleri != null && alacakNedenleri.Count > 0)
                    {
                        foreach (var item in alacakNedenleri)
                        {
                            if (
                                !item.NN_TEBLIGAT_ALACAK_NEDENCollection.Exists(
                                    vi => vi.TEBLIGAT_ID == MyDataSource[0].ID))
                            {
                                NN_TEBLIGAT_ALACAK_NEDEN tebligatAlacak = new NN_TEBLIGAT_ALACAK_NEDEN();
                                tebligatAlacak.TEBLIGAT_ID = MyDataSource[0].ID;
                                tebligatAlacak.ALACAK_NEDEN_ID = item.ID;
                                DataRepository.NN_TEBLIGAT_ALACAK_NEDENProvider.DeepSave(tran, tebligatAlacak);
                            }
                        }
                    }

                    tran.Commit();

                    XtraMessageBox.Show("Kayýt Ýþlemi Baþarý ile Gerçekleþtirildi.", "BÝLGÝ", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen)
                        tran.Rollback();
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void c_btnYeni_Click(object sender, EventArgs e)
        {
            //YENÝ KAYIT
            tabIsTaraflari.Enabled = true;

            c_btnGeri.Enabled = true;
            c_btnIleri.Enabled = true;
            c_btnKaydet.Enabled = true;
            c_btnKayitSayisi.Enabled = true;
            c_cbtnHatirlat.Enabled = true;

            Yeni();
            SetKayitSayisiGorunum();
        }

        private void c_lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            switch (c_lueModul.Text)
            {
                case "Dava":
                    VTD_DAVA_DOSYALAR dosyaDava =
                        (VTD_DAVA_DOSYALAR)c_lueDosya.Properties.GetDataSourceRowByKeyValue(c_lueDosya.EditValue);
                    c_leuGorev.EditValue = dosyaDava.GOREV_ID;

                    //.ADLI_BIRIM_GOREV_ID;
                    c_lueAdliye.EditValue = dosyaDava.ADLIYE_ID;

                    //.ADLI_BIRIM_ADLIYE_ID;
                    c_lueBirimNo.EditValue = dosyaDava.BIRIM_ID;

                    //.ADLI_BIRIM_NO_ID;
                    eSAS_NOTextEdit.EditValue = dosyaDava.ESAS_NO;
                    break;

                case "Icra":
                    VTI_ICRA_DOSYALAR dosyaIcra =
                        (VTI_ICRA_DOSYALAR)c_lueDosya.Properties.GetDataSourceRowByKeyValue(c_lueDosya.EditValue);
                    c_leuGorev.EditValue = dosyaIcra.GOREV_ID;
                    c_lueAdliye.EditValue = dosyaIcra.ADLIYE_ID;
                    c_lueBirimNo.EditValue = dosyaIcra.BIRIM_ID;
                    eSAS_NOTextEdit.EditValue = dosyaIcra.ESAS_NO;
                    break;
                default:
                    break;
            }
            c_leuGorev.Enabled = false;
            c_lueAdliye.Enabled = false;
            c_lueBirimNo.Enabled = false;
            eSAS_NOTextEdit.Enabled = false;
        }

        private void c_lueFormTipi_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                TDI_KOD_TEBLIGAT_KONU Tk = DataRepository.TDI_KOD_TEBLIGAT_KONUProvider.GetByID((int)e.NewValue);

                if (MyDataSource != null)
                {
                    foreach (AV001_TDI_BIL_TEBLIGAT var in MyDataSource)
                    {
                        var.ANA_TUR_ID = Tk.ANA_TUR_ID;
                        var.ALT_TUR_ID = Tk.ALT_TUR_ID;
                        TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> Hak =
                            DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                Tk.ANA_TUR_ID);
                        foreach (TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI mhak in Hak)
                        {
                            var.MUHASEBE_ALT_KATEGORI_IDSource = mhak;
                        }
                    }
                }
            }
        }

        private void c_lueModul_EditValueChanged(object sender, EventArgs e)
        {
            BelgeUtil.Inits.DosyaDoldur(c_lueModul.Text, c_lueDosya);
        }

        private void checkEdit1_CheckedChanged_1(object sender, EventArgs e)
        {
            tabTekrarlama.PageVisible = checkEdit1.Checked;
        }

        private void chkYapilacakIs_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYapilacakIs.Checked)
                xtraTabPage2.PageVisible = true;
            else
                xtraTabPage2.PageVisible = false;
        }

        private void gridView3_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (gridView3.GetRow(e.RowHandle) is AV001_TDIE_BIL_BELGE)
            {
                TList<AV001_TDIE_BIL_BELGE> lstBelgeler = new TList<AV001_TDIE_BIL_BELGE>();
                AV001_TDIE_BIL_BELGE belgem = (AV001_TDIE_BIL_BELGE)gridView3.GetRow(e.RowHandle);
                lstBelgeler.Add(belgem);
                frmBelgeKayitUfak belgeKAydi = new frmBelgeKayitUfak();
                belgeKAydi.MyDataSource = lstBelgeler;

                //belgeKAydi.MdiParent = null;
                belgeKAydi.StartPosition = FormStartPosition.WindowsDefaultLocation;
                belgeKAydi.Show();
            }
        }

        private void hATIRLATILSIN_MICheckEdit_CheckedChanged_1(object sender, EventArgs e)
        {
            panel3.Visible = hATIRLATILSIN_MICheckEdit.Checked;
            durationEdit1.SelectedIndex = 0;
        }

        private void setValue()
        {
            aDLI_BIRIM_ADLIYE_IDLabel.Text = "Noteri";
            eSAS_NOLabel.Text = "Yevmiye No";
        }

        private void ucTebligatKayitUfakDock_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;
            BelgeUtil.Inits.AdliBirimGorevGetir(c_leuGorev.Properties);
            BelgeUtil.Inits.AdliBirimNoGetir(c_lueBirimNo.Properties);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(c_lueAdliye.Properties);
            BelgeUtil.Inits.TebligatTipGetir(lueTebTip);
            BelgeUtil.Inits.TebligatKonuGetir(c_lueFormTipi);
            BelgeUtil.Inits.perCariGetir(rlueGonderen);
            BelgeUtil.Inits.TarafKoduGetir(rlueTarafKod);
            BelgeUtil.Inits.perCariGetir(rlueMuhatap);
            BelgeUtil.Inits.TarafKoduGetir(rlueMuhatapTarafKod);

            if (Ihtarname)
                setValue();
            Bind();

            c_lueModul.EditValueChanged += c_lueModul_EditValueChanged;
            BelgeUtil.Inits.ModulKodGetir(c_lueModul);

            if (Klasordenmi)
            {
                panelControl4.Visible =
                    rEFERANS_NOTextEdit.Visible =
                    chkGelenMi.Visible =
                    chkYapilacakIs.Visible =
                    checkEdit2.Visible =
                    rEFERANS_NOLabel.Visible =
                    xtraTabPage1.PageVisible = !Klasordenmi;

                if (bndTebligat.Current != null && bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT != null)
                {
                    (bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT).TIP_ID = 4; //ÝHTARNAME
                    (bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT).KONU_ID = 481; //HESAP KAT ÝHTARNAMESÝ
                    (bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT).ADLI_BIRIM_GOREV_ID = 31; //NOT
                }
            }
        }

        #region tebligat taraflari

        public TList<AV001_TDI_BIL_TEBLIGAT_YAPAN> DavaTaraflarindanAl(AV001_TD_BIL_FOY icram,
                                                                       AV001_TDI_BIL_TEBLIGAT tebligat)
        {
            TList<AV001_TDI_BIL_TEBLIGAT_YAPAN> tebTaraflari = new TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>();
            AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(icram, false,
                                                                                AvukatProLib2.Data.DeepLoadType.
                                                                                    IncludeChildren,
                                                                                typeof(TList<AV001_TD_BIL_FOY_TARAF>),
                                                                                typeof(
                                                                                    TList
                                                                                    <AV001_TD_BIL_FOY_SORUMLU_AVUKAT>));

            for (int i = 0; i < icram.AV001_TD_BIL_FOY_TARAFCollection.Count; i++)
            {
                if (icram.AV001_TD_BIL_FOY_TARAFCollection[i].CARI_IDSource.MUVEKKIL_MI)
                {
                    AV001_TDI_BIL_TEBLIGAT_YAPAN taraf = new AV001_TDI_BIL_TEBLIGAT_YAPAN();

                    taraf.YAPAN_CARI_ID = icram.AV001_TD_BIL_FOY_TARAFCollection[i].CARI_ID.Value;
                    tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Add(taraf);
                }
                else if (!icram.AV001_TD_BIL_FOY_TARAFCollection[i].CARI_IDSource.MUVEKKIL_MI)
                {
                    AV001_TDI_BIL_TEBLIGAT_MUHATAP taraf = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();

                    taraf.MUHATAP_CARI_ID = icram.AV001_TD_BIL_FOY_TARAFCollection[i].CARI_ID.Value;
                    tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Add(taraf);
                }
            }

            tebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;

            //for (int y = 0; y < icram.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Count; y++)
            //{
            //    AV001_TDI_BIL_TEBLIGAT_YAPAN tarafso = new AV001_TDI_BIL_TEBLIGAT_YAPAN();

            //    tarafso.IS_TARAF_ID = 4;
            //    tarafso.CARI_ID = icram.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection[y].SORUMLU_AVUKAT_CARI_ID;
            //    isTaraflari.Add(tarafso);
            //}

            return tebTaraflari;
        }

        public void IcraTaraflarindanAl(AV001_TI_BIL_FOY icram, AV001_TDI_BIL_TEBLIGAT tebligat)
        {
            TList<AV001_TDI_BIL_TEBLIGAT_YAPAN> tebTaraflari = new TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>();
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(icram, false,
                                                                                AvukatProLib2.Data.DeepLoadType.
                                                                                    IncludeChildren,
                                                                                typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                                typeof(
                                                                                    TList
                                                                                    <AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
            for (int i = 0; i < icram.AV001_TI_BIL_FOY_TARAFCollection.Count; i++)
            {
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(
                    icram.AV001_TI_BIL_FOY_TARAFCollection[i], false, DeepLoadType.IncludeChildren,
                    typeof(AV001_TDI_BIL_CARI));

                if (icram.AV001_TI_BIL_FOY_TARAFCollection[i].TARAF_KODU == 1)
                {
                    AV001_TDI_BIL_TEBLIGAT_YAPAN taraf = new AV001_TDI_BIL_TEBLIGAT_YAPAN();

                    taraf.YAPAN_CARI_ID = icram.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_ID.Value;
                    tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Add(taraf);
                }
                else if (icram.AV001_TI_BIL_FOY_TARAFCollection[i].TARAF_KODU != 1)
                {
                    AV001_TDI_BIL_TEBLIGAT_MUHATAP taraf = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();
                    taraf.MUHATAP_CARI_ID = icram.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_ID.Value;
                    tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Add(taraf);
                }
            }

            tebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;

            //for (int y = 0; y < icram.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count; y++)
            //{
            //    AV001_TDI_BIL_TEBLIGAT_YAPAN tarafs = new AV001_TDI_BIL_TEBLIGAT_YAPAN();
            //    tarafs.IS_TARAF_ID = 2;
            //    tarafs.CARI_ID = icram.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[y].SORUMLU_AVUKAT_CARI_ID;
            //    isTaraflari.Add(tarafs);
            //}
        }

        public void SozlesmeTaraflarindanAl(AV001_TDI_BIL_SOZLESME icram, AV001_TDI_BIL_TEBLIGAT tebligat)
        {
            AV001_TDI_BIL_SOZLESME sozlesme = new AV001_TDI_BIL_SOZLESME();

            TList<AV001_TDI_BIL_TEBLIGAT_YAPAN> isTaraflari = new TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>();
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(icram, false,
                                                                                      AvukatProLib2.Data.DeepLoadType.
                                                                                          IncludeChildren,
                                                                                      typeof(
                                                                                          TList
                                                                                          <AV001_TDI_BIL_SOZLESME_TARAF>
                                                                                          ),
                                                                                      typeof(
                                                                                          TList
                                                                                          <
                                                                                          AV001_TDI_BIL_SOZLESME_SORUMLU
                                                                                          >));

            for (int i = 0; i < icram.AV001_TDI_BIL_SOZLESME_TARAFCollection.Count; i++)
            {
                AV001_TDI_BIL_TEBLIGAT_YAPAN taraf = new AV001_TDI_BIL_TEBLIGAT_YAPAN();

                //taraf.YAPAN_CARI_ID = 2;
                taraf.YAPAN_CARI_ID = icram.AV001_TDI_BIL_SOZLESME_TARAFCollection[i].CARI_ID.Value;
                isTaraflari.Add(taraf);
            }

            tebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;

            //for (int y = 0; y < icram.AV001_TDI_BIL_SOZLESME_SORUMLUCollection.Count; y++)
            //{
            //    AV001_TDI_BIL_TEBLIGAT_YAPAN tarafso = new AV001_TDI_BIL_TEBLIGAT_YAPAN();

            //    tarafso.IS_TARAF_ID = 4;
            //    tarafso.CARI_ID = icram.AV001_TDI_BIL_SOZLESME_SORUMLUCollection[y].SORUMLU_CARI_ID;
            //    isTaraflari.Add(tarafso);
            //}
        }

        #endregion tebligat taraflari
    }
}