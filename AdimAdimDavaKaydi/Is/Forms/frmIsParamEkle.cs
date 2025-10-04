using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Is.Util;
using AdimAdimDavaKaydi.Util.BaseClasses.AvpFormData;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;

namespace AdimAdimDavaKaydi.Is.Forms
{
    public partial class frmIsParamEkle : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmIsParamEkle()
        {
            InitializeComponent();
            this.Load += frmIsParamEkle_Load;
            this.DosyaKaydet += frmIsParamEkle_DosyaKaydet;
            CheckForIllegalCrossThreadCalls = false;
        }

        [Browsable(false)]
        public TList<TDIE_KOD_IS_ILISKI> AddNewList { get; set; }

        [Browsable(false)]
        public TList<TDIE_KOD_IS_ILISKI> IliskiResult
        {
            get
            {
                if (gcParametre.DataSource is TList<TDIE_KOD_IS_ILISKI>)
                    return (TList<TDIE_KOD_IS_ILISKI>)gcParametre.DataSource;
                return null;
            }
            set
            {
                if (value != null)
                {
                    gcParametre.DataSource = value;

                    if (AddNewList == null)
                    {
                        AddNewList = new TList<TDIE_KOD_IS_ILISKI>();
                        AddNewList.AddingNew += AddNewList_AddingNew;
                        TDIE_KOD_IS_ILISKI iliski = AddNewList.AddNew();
                        BindingToControls(iliski);
                    }
                }
            }
        }

        private void AddNewList_AddingNew(object sender, AddingNewEventArgs e)
        {
            TDIE_KOD_IS_ILISKI MyIliski = new TDIE_KOD_IS_ILISKI();

            MyIliski.HATIRLATMA_GUN = 0;
            MyIliski.BITIS_SURE_GUN = 0;
            MyIliski.KAYITTAN_KAC_GUN_SONRA_KONTROL_EDILSIN = 0;
            MyIliski.KAC_GUN_ONCEDEN_BILDIRILSIN = 0;
            MyIliski.KAYIT_TARIHI = DateTime.Today;
            MyIliski.KONTROL_NE_ZAMAN = DateTime.Today;
            MyIliski.KONTROL_VERSIYON = 1;
            MyIliski.STAMP = 1;
            MyIliski.SEKTOR_ID = (int)Sektor.Genel;
            MyIliski.IS_ONCELIK_ID = (int)IsOncelik.NORMAL;
            MyIliski.IS_URETILSIN_MI = true;

            e.NewObject = MyIliski;
        }

        private void BindingToControls(TDIE_KOD_IS_ILISKI iliski)
        {
            lkSektor.DataBindings.Clear();
            lkSektor.DataBindings.Add("EditValue", iliski, "SEKTOR_ID", true);

            lkKonu.DataBindings.Clear();
            lkKonu.DataBindings.Add("EditValue", iliski, "IS_KONU_ID", true);

            lkModul.DataBindings.Clear();
            lkModul.DataBindings.Add("EditValue", iliski, "MODUL_ID", true);

            lkOncelikDerecesi.DataBindings.Clear();
            lkOncelikDerecesi.DataBindings.Add("EditValue", iliski, "IS_ONCELIK_ID", true);

            cbUretilecekKisiGrup.DataBindings.Clear();
            cbUretilecekKisiGrup.DataBindings.Add("EditValue", iliski, "URETIM_GRUPLARI", true);

            cbUretilecekKisiYetkiGrup.DataBindings.Clear();
            cbUretilecekKisiYetkiGrup.DataBindings.Add("EditValue", iliski, "URETIM_YETKILERI", true);

            cbHatirlatmaGrup.DataBindings.Clear();
            cbHatirlatmaGrup.DataBindings.Add("EditValue", iliski, "HATIRLATMA_GRUPLARI", true);

            cbHatirlatmaYetkiGrup.DataBindings.Clear();
            cbHatirlatmaYetkiGrup.DataBindings.Add("EditValue", iliski, "HATIRLATMA_YETKILERI", true);

            spKac_Gun_Onceden_Bildirilsin.DataBindings.Clear();
            spKac_Gun_Onceden_Bildirilsin.DataBindings.Add("EditValue", iliski, "KAC_GUN_ONCEDEN_BILDIRILSIN", true);

            spHGun.DataBindings.Clear();
            spHGun.DataBindings.Add("EditValue", iliski, "HATIRLATMA_GUN", true);

            spKontrolGun.DataBindings.Clear();
            spKontrolGun.DataBindings.Add("EditValue", iliski, "KAYITTAN_KAC_GUN_SONRA_KONTROL_EDILSIN", true);

            spSure.DataBindings.Clear();
            spSure.DataBindings.Add("EditValue", iliski, "BITIS_SURE_GUN", true);

            ckYasalMi.DataBindings.Clear();
            ckYasalMi.DataBindings.Add("Checked", iliski, "SURE_YASAL_MI", true);

            ckAjandadaGorunsun.DataBindings.Clear();
            ckAjandadaGorunsun.DataBindings.Add("Checked", iliski, "AJANDADA_GORUNSUN_MU", true);

            ckMuhasebelestir.DataBindings.Clear();
            ckMuhasebelestir.DataBindings.Add("Checked", iliski, "MUHASEBELESTIRILSIN_MI", true);

            ckYoneticiyeBildir.DataBindings.Clear();
            ckYoneticiyeBildir.DataBindings.Add("Checked", iliski, "YONETICIYE_BILDIRILSIN_MI", true);

            ckAdliTatilUygulansýn.DataBindings.Clear();
            ckAdliTatilUygulansýn.DataBindings.Add("Checked", iliski, "ADLI_TATIL_UYGULANSIN_MI", true);

            ckResmiTatilUygulansýn.DataBindings.Clear();
            ckResmiTatilUygulansýn.DataBindings.Add("Checked", iliski, "RESMI_TATIL_UYGULANSIN_MI", true);

            lkHatirlatmaSekli.DataBindings.Clear();
            lkHatirlatmaSekli.DataBindings.Add("EditValue", iliski, "HATIRLATMA_SEKLI", true);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                XtraMessageBox.Show("Kayýt Güncelleme iþlemi tamamlandý.", "Kaydet-Güncelle",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            New();
        }

        private void bwDataLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();
        }

        private void bwDataLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GrupDoldur();

            HatýrlatmaSekliDoldur();

            lkModul.EditValueChanged += lkModul_EditValueChanged;
            lkSektor.EditValueChanged += lkSektor_EditValueChanged;
            cbHatirlatmaGrup.Closed += cbHatirlatmaGrup_Closed;
            gwParametre.FocusedRowChanged += gwParametre_FocusedRowChanged;
            ckYasalMi.CheckStateChanged += ckYasalMi_CheckStateChanged;
        }

        private void cbHatirlatmaGrup_Closed(object sender, ClosedEventArgs e)
        {
            lbHatýrlatmaGrup.Items.Clear();
            for (int i = 0; i < cbHatirlatmaGrup.Properties.Items.Count; i++)
            {
                if (cbHatirlatmaGrup.Properties.Items[i].CheckState == CheckState.Checked)
                {
                    lbHatýrlatmaGrup.Items.Add(cbHatirlatmaGrup.Properties.Items[i].Value);
                }
            }
        }

        private void ckYasalMi_CheckStateChanged(object sender, EventArgs e)
        {
            spSure.Enabled = !ckYasalMi.Checked;
        }

        private void DataRefresh()
        {
            IliskiResult.Clear();
            IliskiResult = DataRepository.TDIE_KOD_IS_ILISKIProvider.GetAll();
        }

        private void frmIsParamEkle_DosyaKaydet(object sender, AvpFormDataEventArgs e)
        {
        }

        private void frmIsParamEkle_Load(object sender, EventArgs e)
        {
            BackgroundWorker bwDataLoad = new BackgroundWorker();
            bwDataLoad.DoWork += bwDataLoad_DoWork;
            bwDataLoad.RunWorkerCompleted += bwDataLoad_RunWorkerCompleted;
            bwDataLoad.RunWorkerAsync();
            IliskiResult = DataRepository.TDIE_KOD_IS_ILISKIProvider.GetAll();
        }

        private void GrupDoldur()
        {
            foreach (DataRow dr in IsHelper.GrupGetir().Rows)
            {
                cbUretilecekKisiGrup.Properties.Items.Add(dr["GRUP"]);
                cbHatirlatmaGrup.Properties.Items.Add(dr["GRUP"]);
            }

            cbUretilecekKisiGrup.Properties.NullText = "Ýþ Üretilecek Grubu Seçiniz.";
            cbHatirlatmaGrup.Properties.NullText = "Ýþin Hatýrlatýlacaðý Grubu Seçiniz.";
        }

        private void gwParametre_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            TDIE_KOD_IS_ILISKI row = (TDIE_KOD_IS_ILISKI)gwParametre.GetFocusedRow();

            if (row != null)
            {
                BindingToControls(row);
            }
        }

        private void HatýrlatmaSekliDoldur()
        {
            lkHatirlatmaSekli.Properties.DataSource = IsHelper.HatýrlatmaSekli();
            lkHatirlatmaSekli.Properties.DisplayMember = "HATIRLATMA";
            lkHatirlatmaSekli.Properties.ValueMember = "ID";
            lkHatirlatmaSekli.Properties.Columns.Clear();
            lkHatirlatmaSekli.Properties.Columns.Add(new LookUpColumnInfo("HATIRLATMA", 30, "Hatýrlatma Þekli"));
        }

        private void lkModul_EditValueChanged(object sender, EventArgs e)
        {
            if (lkModul.Properties.DataSource != null && lkModul.EditValue != null)
            {
                lkKonu.Properties.DataSource =
                    DataRepository.TDIE_KOD_IS_TANIMProvider.Find("MODUL_ID = " + (int)lkModul.EditValue);
                lkKonu.Properties.ReadOnly = (((TList<TDIE_KOD_IS_TANIM>)lkKonu.Properties.DataSource).Count == 0);
            }
        }

        private void lkSektor_EditValueChanged(object sender, EventArgs e)
        {
            if (lkModul.Properties.DataSource != null && lkModul.ItemIndex > -1
                && lkSektor.Properties.DataSource != null && lkSektor.ItemIndex > -1)
            {
                lkKonu.Properties.DataSource = DataRepository.TDIE_KOD_IS_TANIMProvider.Find
                    (string.Format("MODUL_ID={0} AND SEKTOR_ID={1}", (int)lkModul.EditValue, (int)lkSektor.EditValue));
            }
        }

        private void LoadData()
        {
            BelgeUtil.Inits.IsKonuKodGetir(lkKonu);

            BelgeUtil.Inits.SektorKodGetir(lkSektor);

            BelgeUtil.Inits.ModulKodGetir(lkModul);

            BelgeUtil.Inits.IsOncelikGetir(lkOncelikDerecesi);

            BelgeUtil.Inits.KullaniciGrupGetir(new[] { cbHatirlatmaYetkiGrup, cbUretilecekKisiYetkiGrup });
        }

        private void New()
        {
            foreach (Control c in this.groupControl2.Controls)
            {
                if (c is LookUpEdit)
                    ((LookUpEdit)c).EditValue = null;

                if (c is SpinEdit)
                    ((SpinEdit)c).EditValue = 0;

                if (c is CheckEdit)
                    ((CheckEdit)c).Checked = false;
            }

            HatýrlatmaSekliDoldur();
            lbHatýrlatmaGrup.Items.Clear();
            cbHatirlatmaYetkiGrup.EditValue = null;
            cbHatirlatmaGrup.EditValue = null;
            cbUretilecekKisiGrup.EditValue = null;
            cbUretilecekKisiYetkiGrup.EditValue = null;

            TDIE_KOD_IS_ILISKI iliski = AddNewList.AddNew();
            BindingToControls(iliski);
        }

        private bool Save()
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            bool result = true;

            try
            {
                tran.BeginTransaction();
                for (int i = 0; i < AddNewList.Count; i++)
                {
                    if (AddNewList[i].MODUL_ID.HasValue)
                        IliskiResult.Add(AddNewList[i]);
                }
                DataRepository.TDIE_KOD_IS_ILISKIProvider.Save(tran, IliskiResult);

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();
                for (int i = 0; i < AddNewList.Count; i++)
                {
                    IliskiResult.Remove(AddNewList[i]);
                }

                result = false;
                BelgeUtil.ErrorHandler.Catch(this, ex, null);
            }

            finally
            {
                tran.Dispose();

                DataRefresh();
            }

            return result;
        }
    }
}