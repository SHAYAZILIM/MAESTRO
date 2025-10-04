using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmIlamBilgileriGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private AV001_TI_BIL_FOY _MyFoy;

        private int? AdliyeID;

        private int? BirimID;

        private DateTime? BozulmaTarihi;

        private string EsasNo;

        private int? GorevID;

        private DateTime? IlamDavaTarihi;

        private int? IlamTipID;

        private DateTime? KararTarihi;

        private DateTime? KesinlesmeTarihi;

        public rFrmIlamBilgileriGirisEkran()
        {
            InitializeComponent();
            InitializeEvents();
        }

        /// <summary>
        /// Þuanda seçili olan AV001_TI_BIL_FOY nesnesini temsil eder
        /// </summary>
        private AV001_TI_BIL_FOY MyFoy
        {
            get { return _MyFoy; }
        }

        public void IlamBilgiDoldur(AV001_TI_BIL_FOY mFoy)
        {
            if (mFoy != null)
                ucIlamBilgileriGirisEkran1.MyDataSource = BelgeUtil.Inits.context.per_TI_BIL_ILAM_MAHKEMESIs.Where(vi => vi.ICRA_FOY_ID == mFoy.ID).ToList();
        }

        public void IlamBilgileriKaydet()
        {
            DialogResult dr =
                XtraMessageBox.Show(
                    "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine +
                    "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                if (IlamMahkemesiKontrol())
                {
                    try
                    {
                        tran.BeginTransaction();
                        DataRepository.AV001_TI_BIL_ILAM_MAHKEMESIProvider.DeepSave(tran,
                                                                                    MyFoy.
                                                                                        AV001_TI_BIL_ILAM_MAHKEMESICollection);
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (tran.IsOpen)
                            tran.Rollback();
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
                else
                {
                    XtraMessageBox.Show(
                        "Kayýt Sýrasýnda ; \nAdliye \nGörev \nEsas No \nKarar No \nKarar Tarihi \nÝlam Tipi \nAlanlarýndan Herhangi Biri Boþ Geçilemez...");
                }
            }
        }

        public bool IlamMahkemesiKontrol()
        {
            foreach (AV001_TI_BIL_ILAM_MAHKEMESI obj in MyFoy.AV001_TI_BIL_ILAM_MAHKEMESICollection)
            {
                if (obj.ADLI_BIRIM_ADLIYE_ID == null || obj.ADLI_BIRIM_GOREV_ID == null ||
                    string.IsNullOrEmpty(obj.ESAS_NO) || string.IsNullOrEmpty(obj.KARAR_NO) || obj.KARAR_TARIHI == null ||
                    obj.ILAM_TIP_ID == null)
                    return false;
            }
            return true;
        }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Editor_Click += barButtonItem18_ItemClick;
            this.Button_Excel_Click += barButtonItem21_ItemClick;
            this.Button_Outlook_Click += barButtonItem21_ItemClick;
            this.Button_PDF_Click += barButtonItem22_ItemClick;
            this.Button_Word_Click += barButtonItem19_ItemClick;
            this.Button_Kaydet_Click += barButtonItem3_ItemClick;
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

        private void barButtonItem18_ItemClick(object sender, EventArgs e)
        {
            frmEditor frmEditor = new frmEditor();
            frmEditor.MdiParent = mdiAvukatPro.MainForm;
            frmEditor.Show();
        }

        private void barButtonItem19_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.doc);
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
            IlamBilgileriKaydet();
        }

        private void dtBozulmaTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtBozulmaTarihi.EditValue != null)
                BozulmaTarihi = (DateTime?)dtBozulmaTarihi.EditValue;
            else
                BozulmaTarihi = null;
        }

        private void dtIlamDavaTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtIlamDavaTarihi.EditValue != null)
                IlamDavaTarihi = (DateTime?)dtIlamDavaTarihi.EditValue;
            else
                IlamDavaTarihi = null;
        }

        private void dtKararTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtKararTarihi.EditValue != null)
                KararTarihi = (DateTime?)dtKararTarihi.EditValue;
            else
                KararTarihi = null;
        }

        private void dtKesinlesmeTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtKesinlesmeTarihi.EditValue != null)
                KesinlesmeTarihi = (DateTime?)dtKesinlesmeTarihi.EditValue;
            else
                KesinlesmeTarihi = null;
        }

        private void LoadData()
        {
            lueAdliyeID.Properties.NullText = "Seç";
            lueAdliyeID.Enter += delegate { BelgeUtil.Inits.AdliBirimAdliyeGetir(lueAdliyeID); };

            lueGorevID.Properties.NullText = "Seç";
            lueGorevID.Enter += delegate { BelgeUtil.Inits.AdliBirimGorevGetir(lueGorevID); };

            lueBirimID.Properties.NullText = "Seç";
            lueBirimID.Enter += delegate { BelgeUtil.Inits.AdliBirimNoGetir(lueBirimID); };

            lueIlamTipID.Properties.NullText = "Seç";
            lueIlamTipID.Enter += delegate { BelgeUtil.Inits.IlamTipiGetir(lueIlamTipID.Properties); };
        }

        private void lueAdliyeID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAdliyeID.EditValue != null)
                AdliyeID = (int)lueAdliyeID.EditValue;
            else
                AdliyeID = null;
        }

        private void lueBirimID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBirimID.EditValue != null)
                BirimID = (int)lueBirimID.EditValue;
            else
                BirimID = null;
        }

        private void lueGorevID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueGorevID.EditValue != null)
                GorevID = (int)lueGorevID.EditValue;
            else
                GorevID = null;
        }

        private void lueIlamTipID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueIlamTipID.EditValue != null)
                IlamTipID = (int)lueIlamTipID.EditValue;
            else
                IlamTipID = null;
        }

        private void rFrmIlamBilgileriGirisEkran_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void sbtnSorgula_Click(object sender, EventArgs e)
        {
            List<AvukatProLib.Arama.per_TI_BIL_ILAM_MAHKEMESI> IlamBilgileriList = new List<AvukatProLib.Arama.per_TI_BIL_ILAM_MAHKEMESI>();
            IlamBilgileriList = AvukatProLib.Arama.per_TI_BIL_ILAM_MAHKEMESIArama.GetByFilterView(AdliyeID, GorevID,
                                                                                               BirimID, EsasNo,
                                                                                               KararTarihi,
                                                                                               KesinlesmeTarihi,
                                                                                               BozulmaTarihi, IlamTipID,
                                                                                               IlamDavaTarihi);
            ucIlamBilgileriGirisEkran1.MyDataSource = IlamBilgileriList;
        }

        private void sbtnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(LCntrlIlamBilgileri.Controls);
            ucIlamBilgileriGirisEkran1.MyDataSource = null;
        }

        private void txtEsasNo_EditValueChanged(object sender, EventArgs e)
        {
            EsasNo = "%" + txtEsasNo.Text + "%";
            if (txtEsasNo.Text == string.Empty)
                EsasNo = null;
        }
    }
}