using AdimAdimDavaKaydi.Ajanda.Forms.MainForms;
using AdimAdimDavaKaydi.Ajanda.Forms.SmallForms;
using AdimAdimDavaKaydi.Ajanda.Util.Base;
using AvukatProLib;
using AvukatProLib.Util;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.Schedule;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Ajanda.UserControls
{
    public partial class ucAjanda : BaseUserControl
    {
        public ucAjanda()
        {
            InitializeComponent();
            schedulerControl2.Visible = false;
        }

        #region Variables and Properties

        public bool TakipEkranindanAjanda;
        private Dictionary<per_AV001_TDI_BIL_CARI_Asistan, List<AppointmentData>> _Data;
        private List<AppointmentData> lstCariIsler = new List<AppointmentData>();

        private List<per_AV001_TDI_BIL_CARI_Asistan> selectedCariList = new List<per_AV001_TDI_BIL_CARI_Asistan>();

        public Dictionary<per_AV001_TDI_BIL_CARI_Asistan, List<AppointmentData>> Data
        {
            get { return _Data; }
            set
            {
                _Data = value;
                if (value != null)
                    SetDataSource();
            }
        }

        public IEntity OpenedRecord { get; set; }

        #endregion Variables and Properties

        #region Events

        private string kolonlar = "a.*";

        public void repositoryItemComboBox1_EditValueChanging(object sender, ChangingEventArgs e)
        {
            selectedCariList.Clear();//ARCH
            schedulerControl2.Storage.Resources.Clear();
            schedulerControl2.Storage.Appointments.Clear();

            DataTable cariler = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

            switch (e.NewValue.ToString())
            {
                case "Benim Ýþlerim":
                    BindAllData();
                    //cariler = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARI_Asistans.Where(vi => vi.ID == Kimlik.Bilgi.CARI_ID.Value).ToList();
                    break;

                case "Þubemin Ýþleri":
                    cariler = cn.GetDataTable("SELECT CONVERT(BIT,0) AS IsSelected,ID, KOD, AD FROM dbo.AV001_TDI_BIL_CARI(nolock) z where PERSONEL_MI=1 and SUBE_KOD_ID=" + Kimlik.Bilgi.SUBE_ID);
                    break;

                case "Þube Avukatlarý":
                    cariler = cn.GetDataTable("SELECT CONVERT(BIT,0) AS IsSelected,ID, KOD, AD FROM dbo.AV001_TDI_BIL_CARI(nolock) z where PERSONEL_MI=1 and AVUKAT_MI=1 and SUBE_KOD_ID=" + Kimlik.Bilgi.SUBE_ID);
                    break;

                case "Tüm Avukatlar":
                    cariler = cn.GetDataTable("SELECT CONVERT(BIT,0) AS IsSelected,ID, KOD, AD FROM dbo.AV001_TDI_BIL_CARI(nolock) z where AVUKAT_MI=1");
                    break;

                default:
                    break;
            }
            gcKisiler.DataSource = cariler;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter =
                "Microsoft Office Outlook Holidays files (*.hol)|*.hol|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.FileName = "OUTLOOK.HOL";
            dlg.DefaultExt = "*.hol";
            dlg.CheckFileExists = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                OutlookHolidaysLoader loader = new OutlookHolidaysLoader();

                schedulerControl2.BeginUpdate();
                try
                {
                    schedulerControl2.WorkDays.Clear();
                    schedulerControl2.WorkDays.Add(WeekDays.WorkDays);
                    schedulerControl2.WorkDays.AddRange(loader.FromFile(dlg.FileName));
                }
                finally
                {
                    schedulerControl2.EndUpdate();
                }
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmOutlookSenkronizasyon OutlookForm = new frmOutlookSenkronizasyon();
            OutlookForm.Storage = this.schedulerControl2.Storage;
            OutlookForm.ShowDialog();
        }

        private void barEditItem1_ShowingEditor(object sender, DevExpress.XtraBars.ItemCancelEventArgs e)
        {
            TList<TDI_BIL_ONEMLI_GUN> finded = FindDays(schedulerControl2.SelectedInterval.Start.Date);
            for (int i = 0; i < finded.Count; i++)
            {
                lblOnemliGun.Text += finded[i].ACIKLAMA + Environment.NewLine;
            }
            if (finded.Count == 0)
            {
                lblOnemliGun.Text = "";
            }
        }

        private void bbtnCalismaSaatleri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCalismaSaatleri calismaSaatleri = new frmCalismaSaatleri();
            calismaSaatleri.ShowDialog(this.schedulerControl2);
        }

        private void bbtnYazdir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.schedulerControl2.ShowPrintOptionsForm();
        }

        private void dateNavigator1_Click(object sender, System.EventArgs e)
        {
            sbtnIsleriGetir_Click(sender, e);
        }

        private void gvKisiler_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Caption != "Seç") return;

            popupContainerKisiler.Text = string.Empty;

            per_AV001_TDI_BIL_CARI_Asistan currentCari = new per_AV001_TDI_BIL_CARI_Asistan();

            if (gvKisiler.GetFocusedRow() != null)
                currentCari = DataRepository.per_AV001_TDI_BIL_CARI_AsistanProvider.Get("ID=" + gvKisiler.GetFocusedRowCellValue("ID"), "ID")[0];

            if (!selectedCariList.Contains(currentCari))
                selectedCariList.Add(currentCari);
            else if (selectedCariList.Contains(currentCari))
                selectedCariList.Remove(currentCari);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string tarih = schedulerControl2.SelectedInterval.Start.Date.ToString("dd.MM");
            Process.Start("http://www.google.com.tr/search?hl=tr&q=" + tarih + "&meta=&aq=0&oq=av");
        }

        private void sbtnIsleriGetir_Click(object sender, EventArgs e)
        {
            gvKisiler.CloseEditor();//ARCH
            lstCariIsler.Clear();

            if (barEditItem3.EditValue.ToString() == "Benim Ýþlerim")
                BindAllData();
            else
                BindAllDataByCari(selectedCariList);
        }

        private void schedulerControl1_DragDrop(object sender, DragEventArgs e)
        {
            VList<VDI_BIL_IS> isler = (VList<VDI_BIL_IS>)e.Data.GetData(typeof(VList<VDI_BIL_IS>));
            if (isler != null && isler.Count >= 1)
            {
            }
            else
            {
                return;
            }
            DialogResult drBaslangicTarih = XtraMessageBox.Show("Baþlangýç Tarihi Bu gune Ayarlansýn mý ?"
                                                                , "Baþlama Tarihi Bu gune Ayarlansýn mý ?",
                                                                MessageBoxButtons.YesNo, MessageBoxIcon.Hand);

            DateTime dtStart = schedulerControl2.SelectedInterval.Start;

            DialogResult drSorumlu = XtraMessageBox.Show(isler.Count + " kaydýn sorumlusu deðiþtirilecek !",
                                                         schedulerControl2.SelectedResource.Caption +
                                                         " adli cari sorumlu olarak atansýn mý ?",
                                                         MessageBoxButtons.YesNo);

            for (int i = 0; i < isler.Count; i++)
            {
                isler[i].AJANDADA_GORUNSUN_MU = true;

                if (drBaslangicTarih == DialogResult.Yes)
                {
                    if (!isler[i].BITIS_TARIHI.HasValue)
                    {
                        isler[i].BITIS_TARIHI = isler[i].ONGORULEN_BITIS_TARIHI.Value - new TimeSpan(1, 12, 1, 1);
                    }
                    long bitisaralik = ((isler[i].BITIS_TARIHI.Value - isler[i].BASLANGIC_TARIHI.Value)).Ticks;
                    long ongorulenBitisAralik =
                        (((isler[i].ONGORULEN_BITIS_TARIHI.Value - isler[i].BASLANGIC_TARIHI.Value))).Ticks;
                    TimeSpan tms = TimeSpan.FromTicks(bitisaralik);
                    DateTime dtt = dtStart.AddTicks(bitisaralik);
                    isler[i].BASLANGIC_TARIHI = dtStart;
                    isler[i].BITIS_TARIHI = dtt;
                    isler[i].ONGORULEN_BITIS_TARIHI = dtStart + TimeSpan.FromTicks(ongorulenBitisAralik);
                }

                if (drSorumlu == DialogResult.Yes)
                {
                    int cari = 0;
                    if (schedulerControl2.SelectedResource.Id is int)
                    {
                        if (int.TryParse(schedulerControl2.SelectedResource.Id.ToString(), out cari))
                        {
                            SchedulerResourceHelper.SetRecordResource(isler[i], cari);
                            for (int y = 0; y < schedulerControl2.Storage.Appointments.Count; y++)
                            {
                                if (schedulerControl2.Storage.Appointments[y].GetRow(schedulerControl2.Storage) is VDI_BIL_IS)
                                {
                                    if (
                                        (schedulerControl2.Storage.Appointments[y].GetRow(schedulerControl2.Storage) as VDI_BIL_IS).ID ==
                                        isler[i].ID)
                                    {
                                        schedulerControl2.Storage.Appointments[y].ResourceIds.Add(
                                            schedulerControl2.SelectedResource.Id);
                                        schedulerControl2.RefreshData();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void schedulerControl1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e)
        {
            #region <MB-20091210>

            //Ajanda üzerinde iþe týklayýnca Ýþ kayýt formuna seçilen kaydýn gelmesi ve düzenleme yapýlabilmesi saðlandý.
            AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
            frmisKayit.ucIsKayitUfak1.YenileKayit += ucIsKayitUfak_Yenile;

            if (e.Appointment != null)
            {
                frmisKayit.ucIsKayitUfak1.SeciliGun = e.Appointment.End;

                if ((e.Appointment as AppointmentPro) != null)
                {
                    e.Handled = true;
                    AV001_TDI_BIL_IS acilacakis =
                        DataRepository.AV001_TDI_BIL_ISProvider.GetByID(((e.Appointment as AppointmentPro).AppData.ID));
                    frmisKayit.Record = acilacakis;
                    frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmisKayit.Show();
                }
                else
                {
                    e.Handled = true;
                    frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmisKayit.Show();
                }
            }

            #endregion <MB-20091210>
        }

        private void schedulerControl1_RemindersFormShowing(object sender, RemindersFormEventArgs e)
        {
            e.AlertNotifications.Clear();
        }

        private void schedulerStorage1_AppointmentChanging(object sender, PersistentObjectCancelEventArgs e)
        {
            AppointmentData Work;
            foreach (var item in schedulerControl2.Storage.Appointments.Items)
            {
                if ((item as AppointmentPro).AppData != null)
                    Work = (item as AppointmentPro).AppData;
                else
                {
                    Work = new AppointmentData((item as AppointmentPro).AppData.IS);
                }
                if (Work.isNew)
                {
                    foreach (var itm in Data)
                        if (itm.Key.ID == (int)Work.Apointment.ResourceId)
                            itm.Value.Add(Work);
                }
                Work.isNew = false;
            }
        }

        private void ucAjanda_Load(object sender, EventArgs e)
        {
            this.schedulerControl2.GoToDate(DateTime.Now);
            //schedulerStorage1.Resources.Mappings.Image = "Image";
            //schedulerStorage1.Resources[0].Image = Properties.Resources.Adobe_Acrobat_Reader1;

            gvKisiler.OptionsView.ShowAutoFilterRow = true;//ARCH
        }

        private void ucIsKayitUfak_Yenile(object sender, IsKayitEventArgs e)
        {
            lstCariIsler.Clear();

            if (selectedCariList.Count == 0)
                BindAllData();
            else
                BindAllDataByCari(selectedCariList);
        }

        #endregion Events

        #region Methods

        //private Dictionary<per_AV001_TDI_BIL_CARI_Asistan, List<AppointmentData>> AllData;
        private DataTable _Isler { get; set; }

        public void BindAllData()
        {
            //if ()
            //AllData.Clear();
            if (_Isler != null)
                _Isler.Clear();
            schedulerControl2.Storage.Resources.Clear();
            schedulerControl2.Storage.Appointments.Clear();

            string bas = dateNavigator1.SelectionStart.Year + "." + dateNavigator1.SelectionStart.Month + "." + dateNavigator1.SelectionStart.Day + " 00:00:00";
            string bit = dateNavigator1.SelectionEnd.Year + "." + dateNavigator1.SelectionEnd.Month + "." + dateNavigator1.SelectionEnd.Day + " 23:59:59";

            DateTime basTarih = Convert.ToDateTime(bas);
            DateTime bitTarih = Convert.ToDateTime(bit);

            Dictionary<per_AV001_TDI_BIL_CARI_Asistan, List<AppointmentData>> DataRef = new Dictionary<per_AV001_TDI_BIL_CARI_Asistan, List<AppointmentData>>();
            List<AppointmentData> lstCariIsler = new List<AppointmentData>();

            per_AV001_TDI_BIL_CARI_Asistan cari = null;
            cari = DataRepository.per_AV001_TDI_BIL_CARI_AsistanProvider.Get("ID=" + AvukatProLib.Kimlik.Bilgi.CARI_ID.Value, "ID")[0];

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            cn.AddParams("@CARI_ID", cari.ID);
            cn.AddParams("@basTarih", basTarih);
            cn.AddParams("@bitTarih", bitTarih);
            _Isler = cn.GetDataTable("select " + kolonlar + " from dbo.per_AV001_TDI_BIL_IS_Asistan(nolock) a where AJANDADA_GORUNSUN_MU=1 and a.ID in (select IS_ID from dbo.AV001_TDI_BIL_IS_TARAF(nolock) x where x.CARI_ID=@CARI_ID and x.IS_TARAF_ID = 2) and BASLANGIC_TARIHI between @basTarih and @bitTarih");

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
            //AllData = DataRef;

            //List<per_AV001_TDI_BIL_CARI_Asistan> lstCariler = new List<per_AV001_TDI_BIL_CARI_Asistan>();

            //schedulerControl2.Storage.Resources.Clear();
            //schedulerControl2.Storage.Appointments.Clear();

            //per_AV001_TDI_BIL_CARI_Asistan cari = null;
            //cari = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARI_Asistans.Where(vi => vi.ID == AvukatProLib.Kimlik.Bilgi.CARI_ID.Value).SingleOrDefault();

            ////foreach (var cari in lstCariler)
            ////{
            //    var cariIsler = BelgeUtil.Inits.context.per_AV001_TDI_BIL_IS_Asistans.Where(item => item.AJANDADA_GORUNSUN_MU && BelgeUtil.Inits.context.AV001_TDI_BIL_IS_TARAFs.Where(c => c.IS_TARAF_ID == 2).Select(vi => vi.IS_ID).Contains(item.ID) && BelgeUtil.Inits.context.NN_IS_CARIs.Where(m => m.CARI_ID == cari.ID).Select(vi => vi.IS_ID).Contains(item.ID)).ToList();

            //    if (cariIsler.Count == 0)
            //        return;
            //    lstCariIsler.Clear();//ARCH
            //    foreach (var isl in cariIsler)
            //        lstCariIsler.Add(new AppointmentData(isl, cari.ID));

            if (lstCariIsler != null && lstCariIsler.Count > 0)
                foreach (var itm in lstCariIsler)
                {
                    if (schedulerControl2.Storage.Resources.Items.Find(delegate(Resource r) { return (int)r.Id == cari.ID; }) == null)
                        schedulerControl2.Storage.Resources.Add(new Resource(cari.ID, cari.AD));
                    try
                    {
                        if (itm.Apointment.HasReminder)
                            itm.Apointment.Reminder.Dismiss();
                        itm.Apointment.HasReminder = false;

                        //itm.Apointment.Subject = itm.ALT_KATEGORI + " " + itm.ADLIYE + " " + itm.NO + " " + itm.GOREV + " " + itm.ESAS_NO + " " + itm.YER;
                        schedulerControl2.Storage.Appointments.Add(itm.Apointment);
                    }
                    catch
                    {
                    }

                    AV001_TDI_BIL_CARI car = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(cari.ID);
                    if (car.RESIM != null)
                    {
                        MemoryStream ms = new MemoryStream(car.RESIM);
                        Image returnImage = Image.FromStream(ms);
                        schedulerControl2.Storage.Resources[0].Image = returnImage;
                    }
                }
            ////}

            //XtraMessageBox.Show("Ýþler yüklendi.", "BÝLGÝ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            barEditItem3.EditValue = "Benim Ýþlerim";
        }

        public void BindAllDataByCari(List<per_AV001_TDI_BIL_CARI_Asistan> lstCariler)
        {
            //AllData.Clear();
            if (_Isler != null)
                _Isler = null;

            //bool varmi = false;
            //foreach (per_AV001_TDI_BIL_CARI_Asistan item in lstCariler)
            //{
            //    if (item.ID == Kimlikci.Kimlik.Cari_ID)
            //    {
            //        varmi = true;
            //        break;
            //    }
            //}
            //if (!varmi)
            //    lstCariler.Add(DataRepository.per_AV001_TDI_BIL_CARI_AsistanProvider.Get("ID=" + AvukatProLib.Kimlik.Bilgi.CARI_ID.Value, "ID")[0]);

            string bas = dateNavigator1.SelectionStart.Year + "." + dateNavigator1.SelectionStart.Month + "." + dateNavigator1.SelectionStart.Day + " 00:00:00";
            string bit = dateNavigator1.SelectionEnd.Year + "." + dateNavigator1.SelectionEnd.Month + "." + dateNavigator1.SelectionEnd.Day + " 23:59:59";

            DateTime basTarih = Convert.ToDateTime(bas);
            DateTime bitTarih = Convert.ToDateTime(bit);

            schedulerControl2.Storage.Resources.Clear();
            schedulerControl2.Storage.Appointments.Clear();

            List<per_AV001_TDI_BIL_IS_Asistan> TumIsler = new List<per_AV001_TDI_BIL_IS_Asistan>();
            foreach (var cari in lstCariler)
            {
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                cn.AddParams("@CARI_ID", cari.ID);
                cn.AddParams("@basTarih", basTarih);
                cn.AddParams("@bitTarih", bitTarih);

                _Isler = cn.GetDataTable("select " + kolonlar + " from dbo.per_AV001_TDI_BIL_IS_Asistan(nolock) a where AJANDADA_GORUNSUN_MU=1 and a.ID in (select IS_ID from dbo.AV001_TDI_BIL_IS_TARAF(nolock) x where x.CARI_ID=@CARI_ID and x.IS_TARAF_ID = 2) and BASLANGIC_TARIHI between @basTarih and @bitTarih");

                //_Isler = BelgeUtil.Inits.context.per_AV001_TDI_BIL_IS_Asistans.Where(item => item.AJANDADA_GORUNSUN_MU && BelgeUtil.Inits.context.AV001_TDI_BIL_IS_TARAFs.Where(c => c.CARI_ID == cari.ID && c.IS_TARAF_ID == 2).Select(vi => vi.IS_ID).Contains(item.ID)).ToList();

                List<AppointmentData> lstCariIsler = new List<AppointmentData>();
                foreach (DataRow isl in _Isler.Rows)
                {
                    if (!lstCariIsler.Exists(delegate(AppointmentData apdata) { return apdata.ID == (int)isl["ID"]; }))
                    {
                        VList<per_AV001_TDI_BIL_IS_Asistan> ss = DataRepository.per_AV001_TDI_BIL_IS_AsistanProvider.Get("ID=" + isl["ID"], "ID");
                        lstCariIsler.Add(new AppointmentData(ss[0], cari.ID));
                    }
                }

                if (lstCariIsler != null && lstCariIsler.Count > 0)
                    foreach (var itm in lstCariIsler)
                    {
                        if (schedulerControl2.Storage.Resources.Items.Find(delegate(Resource r) { return (int)r.Id == cari.ID; }) == null)
                            schedulerControl2.Storage.Resources.Add(new Resource(cari.ID, cari.AD));
                        try
                        {
                            if (itm.Apointment.HasReminder)
                                itm.Apointment.Reminder.Dismiss();
                            itm.Apointment.HasReminder = false;
                            schedulerControl2.Storage.Appointments.Add(itm.Apointment);
                        }
                        catch
                        {
                        }

                        AV001_TDI_BIL_CARI car = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(cari.ID);
                        if (car.RESIM != null)
                        {
                            MemoryStream ms = new MemoryStream(car.RESIM);
                            Image returnImage = Image.FromStream(ms);
                            schedulerControl2.Storage.Resources[schedulerControl2.Storage.Resources.Count - 1].Image = returnImage;
                        }
                    }
            }

            //XtraMessageBox.Show("Ýþler yüklendi.", "BÝLGÝ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SetDataSource()
        {
            schedulerControl2.Visible = false;
            schedulerControl2.Storage = frmAjanda.SchedulerStorage;
            schedulerControl2.Visible = true;

            //TODO: [PAKET] Ajanda

            barManager1.AllowCustomization = false;
            barManager1.AllowShowToolbarsPopup = false;
        }

        private TList<TDI_BIL_ONEMLI_GUN> FindDays(DateTime dt)
        {
            return
                AvukatProLib2.Data.DataRepository.TDI_BIL_ONEMLI_GUNProvider.Find(
                    String.Format("Month(BASLAMA_TARIHI) = {0} and Day(BASLAMA_TARIHI) = {1}", dt.Month, dt.Day));
        }

        #endregion Methods

        public void schedulerControl2_InitAppointmentImages(object sender, AppointmentImagesEventArgs e)
        {
            try
            {
                AV001_TDI_BIL_IS ist = DataRepository.AV001_TDI_BIL_ISProvider.GetByID((e.Appointment as AppointmentPro).AppData.IS.ID);

                TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI kat = DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByID((int)ist.KATEGORI_ID);

                if (kat.ICON != null)
                {
                    MemoryStream ms = new MemoryStream(kat.ICON);
                    Image returnImage = Image.FromStream(ms);

                    AppointmentImageInfo info = new AppointmentImageInfo();
                    info.Image = returnImage;
                    e.ImageInfoList.Add(info);
                }
            }
            catch { ;}
        }
    }
}