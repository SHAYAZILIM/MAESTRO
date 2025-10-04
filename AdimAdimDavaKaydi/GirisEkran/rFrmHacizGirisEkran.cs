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
    public partial class rFrmHacizGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private AV001_TI_BIL_FOY _MyFoy;

        private int? AdliyeID;

        private int? BirimID;

        private string EsasNo;

        private string HacizAdres;

        private int? HacizIstenenID;

        private int? HacizIsteyenID;

        private byte? HacizKaynagi;

        private bool? SehirDisimi;

        private int? SorumluPersonelID;

        private bool? Talimatmi;

        private DateTime? Tarih;

        public rFrmHacizGirisEkran()
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

        public void HacizDoldur(AV001_TI_BIL_FOY mFoy)
        {
           
            ucHaciz1.MyDataSource = BelgeUtil.Inits.context.per_TI_BIL_HACIZ_MASTER_MINIs.Where(vi => vi.FOY_NO == MyFoy.FOY_NO).ToList();
        }

        public void HacizGirisEkran()
        {
            DialogResult dr =
                XtraMessageBox.Show(
                    "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine +
                    "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                if (HacizKontrol())
                {
                    try
                    {
                        tran.BeginTransaction();
                        DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.DeepSave(tran,
                                                                                  MyFoy.
                                                                                      AV001_TI_BIL_HACIZ_MASTERCollection);
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
                        "Kayýt Sýrasýnda ; \nHaciz Tarihi-Saati \nSýra Nosu \nÝsteyen - Ýstenen Þahýs \nHaciz Talep Tarihi \nHaciz Kaynaðý \nÝcra Tutanak No \nSorumlu Personeli \nHaciz Adresi \nAlanlarýndan Herhangi Biri Boþ Geçilemez... ");
                }
            }
        }

        public bool HacizKontrol()
        {
            foreach (AV001_TI_BIL_HACIZ_MASTER obj in MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection)
            {
                if (string.IsNullOrEmpty(obj.HACIZ_SAATI) || obj.HACIZ_TARIHI == null || obj.HACIZ_SIRA_NO == null ||
                    obj.HACIZ_SORUMLU_PERSONEL_ID == null || obj.HACIZ_ISTENEN_CARI_ID == null ||
                    obj.HACIZ_ISTEYEN_CARI_ID == null || obj.HACIZ_TALEP_TARIHI == null || obj.HACIZ_KAYNAGI == 0 ||
                    string.IsNullOrEmpty(obj.ICRA_TUTANAK_NO) || string.IsNullOrEmpty(obj.HACIZ_ADRESI))
                    return false;
            }
            return true;
        }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += barButtonItem3_ItemClick;
            this.Button_Editor_Click += barButtonItem18_ItemClick;
            this.Button_Excel_Click += barButtonItem21_ItemClick;
            this.Button_PDF_Click += barButtonItem22_ItemClick;
            this.Button_Word_Click += barButtonItem19_ItemClick;
            this.Button_Outlook_Click += barButtonItem20_ItemClick;
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
            frmEditor frmEdit = new frmEditor();
            frmEdit.MdiParent = mdiAvukatPro.MainForm;
            frmEdit.Show();
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
            HacizGirisEkran();
        }

        private void dtTarih_EditValueChanged(object sender, EventArgs e)
        {
            if (dtTarih.EditValue != null)
                Tarih = (DateTime?)dtTarih.EditValue;
            else
                Tarih = null;
        }

        private void LoadData()
        {
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueHacizIsteyen, null);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueHacizIstenen, null);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeDoldur(lueAdliye);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeNoDoldur(lueBirim);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueSorumluPersonelID, AvukatProLib.Extras.CariStatu.Personel);

            lueHacizKaynagi.Properties.NullText = "Seç";
            lueHacizKaynagi.Enter += delegate { BelgeUtil.Inits.HAcizKaynakGetir(lueHacizKaynagi.Properties); };
        }

        private void lueAdliye_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAdliye.EditValue != null)
                AdliyeID = (int)lueAdliye.EditValue;
            else
                AdliyeID = null;
        }

        private void lueBirim_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBirim.EditValue != null)
                BirimID = (int)lueBirim.EditValue;
            else
                BirimID = null;
        }

        private void lueHacizIstenen_EditValueChanged(object sender, EventArgs e)
        {
            if (lueHacizIstenen.EditValue != null)
                HacizIstenenID = (int)lueHacizIstenen.EditValue;
            else
                HacizIstenenID = null;
        }

        private void lueHacizIsteyen_EditValueChanged(object sender, EventArgs e)
        {
            if (lueHacizIsteyen.EditValue != null)
                HacizIsteyenID = (int)lueHacizIsteyen.EditValue;
            else
                HacizIsteyenID = null;
        }

        private void lueHacizKaynagi_EditValueChanged(object sender, EventArgs e)
        {
            if (lueHacizKaynagi.EditValue != null)
                HacizKaynagi = Convert.ToByte(lueHacizKaynagi.EditValue);
            else
                HacizKaynagi = null;
        }

        private void lueSorumluPersonelID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSorumluPersonelID.EditValue != null)
                SorumluPersonelID = (int)lueSorumluPersonelID.EditValue;
            else
                SorumluPersonelID = null;
        }

        private void rFrmHacizGirisEkran_Load(object sender, EventArgs e)
        {
            //LOAD
            //this.compRibbonExtender1.LoadMainMenu = true;
            //this.compRibbonExtender1.RibbonForExtend = null;
            //this.compRibbonExtender1.RibbonFormForExtend = this;
            //HacizDoldur();
            /*
            MyDataSource = new TList<AV001_TI_BIL_HACIZ_MASTER>();
            DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.DeepLoad(MyDataSource, false, DeepLoadType.IncludeChildren,
                                                                      typeof (TList<AV001_TI_BIL_HACIZ_ISTIRAK>),
                                                                      typeof (TList<AV001_TI_BIL_KIYMET_TAKDIRI>),
                                                                      typeof (TList<AV001_TI_BIL_ISTIHKAK>),
                                                                      typeof (TList<AV001_TI_BIL_HACIZ_CHILD>),
                                                                      typeof (AV001_TI_BIL_FOY));
            ucHaciz1.MyDataSource = MyDataSource;
            */
            /*gLueIcraFoy.Properties.DataSource = BelgeUtil.Inits.IcraDosyalariGetir();
            gLueIcraFoy.Properties.DisplayMember = "FOY_NO";

            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo); */

            LoadData();
        }

        private void rgSehirDisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgSehirDisi.Properties.Items[rgSehirDisi.SelectedIndex].Value == null)
            {
                SehirDisimi = null;
            }
            else
            {
                SehirDisimi = Convert.ToBoolean(rgSehirDisi.Properties.Items[rgSehirDisi.SelectedIndex].Value);
            }
        }

        private void rgTalimat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgTalimat.Properties.Items[rgTalimat.SelectedIndex].Value == null)
            {
                Talimatmi = null;
            }
            else
            {
                Talimatmi = Convert.ToBoolean(rgTalimat.Properties.Items[rgTalimat.SelectedIndex].Value);
            }
        }

        private void sbtnSorgula_Click(object sender, EventArgs e)
        {
            List<AvukatProLib.Arama.per_TI_BIL_HACIZ_MASTER_MINI> HacizBilgilerList =
            AvukatProLib.Arama.per_TI_BIL_HACIZ_MASTER_MINIArama.GetByFilterView(Tarih, null, null,
                                                                                             Talimatmi, HacizIsteyenID,
                                                                                             HacizIstenenID, AdliyeID,
                                                                                             null, BirimID, EsasNo, null,
                                                                                             null, HacizKaynagi, null,
                                                                                             null, SorumluPersonelID,
                                                                                             SehirDisimi, HacizAdres,
                                                                                             null, null, null);
            ucHaciz1.MyDataSource = HacizBilgilerList;
        }

        private void sbtnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(LCntrlHaciz.Controls);
            ucHaciz1.MyDataSource = null;
        }

        private void txtEsasNo_EditValueChanged(object sender, EventArgs e)
        {
            EsasNo = "%" + txtEsasNo.Text + "%";
            if (txtEsasNo.Text == string.Empty)
                EsasNo = null;
        }

        private void txtHacizAdres_EditValueChanged(object sender, EventArgs e)
        {
            HacizAdres = "%" + txtHacizAdres.Text + "%";
            if (txtHacizAdres.Text == string.Empty)
                HacizAdres = null;
        }
    }
}