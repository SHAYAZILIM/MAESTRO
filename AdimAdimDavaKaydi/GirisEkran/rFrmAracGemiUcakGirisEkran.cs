using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmAracGemiUcakGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private string Adi;

        private string BaglanmaLimani;

        private string Cinsi;

        private byte? GemiUcakAracTipID;

        private string MotorNo;

        private TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> MyDataSource = new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>();

        private string Plaka;

        private string RuhsatSicilNo;

        private DateTime? RuhsatTarihi;

        private string SaseNo;

        private int? Tipi;

        private string TrafikSubesi;

        public rFrmAracGemiUcakGirisEkran()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public void GemiUCakAracKaydet()
        {
            DialogResult dr =
                XtraMessageBox.Show(
                    "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine +
                    "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.DeepSave(tran, MyDataSource);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen)
                        tran.Rollback();
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += barButtonItem3_ItemClick;
            this.Button_PDF_Click += barButtonItem22_ItemClick;
            this.Button_Outlook_Click += barButtonItem20_ItemClick;
            this.Button_Excel_Click += barButtonItem21_ItemClick;
            this.Button_Word_Click += barButtonItem19_ItemClick;
        }

        private static void FormlariTemizle(Control.ControlCollection coll)
        {
            try
            {
                foreach (Control con in coll)
                {
                    if (con is LookUpEdit)
                    {
                        (con as LookUpEdit).EditValue = null;
                    }
                    else if (con is DateEdit)
                    {
                        ((DateEdit)con).EditValue = null;
                    }
                    else if (con is TextEdit)
                    {
                        con.Text = string.Empty;
                    }
                    else if (con is SpinEdit)
                    {
                        (con as SpinEdit).EditValue = null;
                    }
                }
            }
            catch 
            {
            }
        }

        private void barButtonItem19_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.doc);
        }

        private void barButtonItem20_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pst);
        }

        private void barButtonItem21_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.xls);
        }

        private void barButtonItem22_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pdf);
        }

        private void barButtonItem3_ItemClick(object sender, EventArgs e)
        {
            //KAYDET
            GemiUCakAracKaydet();
        }

        private void dtRuhsatTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtRuhsatTarihi.EditValue != null)
                RuhsatTarihi = (DateTime?)dtRuhsatTarihi.EditValue;
            else
                RuhsatTarihi = null;
        }

        private void lueAracTipi_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAracTipi.EditValue != null)
                GemiUcakAracTipID = Convert.ToByte(lueAracTipi.EditValue);
            else
                GemiUcakAracTipID = null;
        }

        private void lueTipi_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTipi.EditValue != null)
                Tipi = (int)lueTipi.EditValue;
            else
                Tipi = null;
        }

        private void rFrmAracGemiUcakGirisEkran_Load(object sender, EventArgs e)
        {
            MyDataSource = new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>();
            DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.DeepLoad(MyDataSource, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_MAL_BEYAN_DETAY>), typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>), typeof(TList<AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDAT>), typeof(TList<AV001_TDI_BIL_SOZLESME_DETAY>), typeof(VList<R_BIRLESIK_TAKIPLER_TUMU_GEMI_UCAK_ARAC>));
            ucAracBilgileriGiris1.MyDataSource = MyDataSource;

            lueAracTipi.Properties.NullText = "Seç";
            lueAracTipi.Enter += delegate { BelgeUtil.Inits.AracTipGetir(lueAracTipi.Properties); };

            lueTipi.Properties.NullText = "Seç";
            lueTipi.Enter += delegate { BelgeUtil.Inits.AracTipGetir(lueTipi.Properties); };
        }

        private void sbtnSorgula_Click(object sender, EventArgs e)
        {
            TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> AracGemiUcakList = new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>();

            AracGemiUcakList = DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.GetByFiltre(GemiUcakAracTipID, Adi, Cinsi, null, null, null, null, null, null, null, BaglanmaLimani, null, null, Tipi, null, null, Plaka, null, null, MotorNo, SaseNo, null, TrafikSubesi, RuhsatTarihi, RuhsatSicilNo, null, null);
            ucAracBilgileriGiris1.MyDataSource = AracGemiUcakList;
        }

        private void sbtnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(layoutControl1.Controls);
            ucAracBilgileriGiris1.MyDataSource = null;
        }

        private void txtAdi_EditValueChanged(object sender, EventArgs e)
        {
            Adi = "%" + txtAdi.Text + "%";
            if (txtAdi.Text == string.Empty)
                Adi = null;
        }

        private void txtBaglamaLimani_EditValueChanged(object sender, EventArgs e)
        {
            BaglanmaLimani = "%" + txtBaglamaLimani.Text + "%";
            if (txtBaglamaLimani.Text == string.Empty)
                BaglanmaLimani = null;
        }

        private void txtCinsi_EditValueChanged(object sender, EventArgs e)
        {
            Cinsi = "%" + txtCinsi.Text + "%";
            if (txtCinsi.Text == string.Empty)
                Cinsi = null;
        }

        private void txtMotorNo_EditValueChanged(object sender, EventArgs e)
        {
            MotorNo = "%" + txtMotorNo.Text + "%";
            if (txtMotorNo.Text == string.Empty)
                MotorNo = null;
        }

        private void txtPlaka_EditValueChanged(object sender, EventArgs e)
        {
            Plaka = "%" + txtPlaka.Text + "%";
            if (txtPlaka.Text == string.Empty)
                Plaka = null;
        }

        private void txtRuhsatSicilNo_EditValueChanged(object sender, EventArgs e)
        {
            RuhsatSicilNo = "%" + txtRuhsatSicilNo.Text + "%";
            if (txtRuhsatSicilNo.Text == string.Empty)
                RuhsatSicilNo = null;
        }

        private void txtSaseNo_EditValueChanged(object sender, EventArgs e)
        {
            SaseNo = "%" + txtSaseNo.Text + "%";
            if (txtSaseNo.Text == string.Empty)
                SaseNo = null;
        }

        private void txtTrafikSubesi_EditValueChanged(object sender, EventArgs e)
        {
            TrafikSubesi = "%" + txtTrafikSubesi.Text + "%";
            if (txtTrafikSubesi.Text == string.Empty)
                TrafikSubesi = null;
        }
    }
}