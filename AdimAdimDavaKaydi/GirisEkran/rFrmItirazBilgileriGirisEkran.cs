using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmItirazBilgileriGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private AV001_TI_BIL_FOY _MyFoy;

        private int? AdliyeID;

        private int? BirimID;

        private bool? Borcami;

        private bool? DavasiAcildimi;

        private string EsasNo;

        private bool? GecikmisItirazmi;

        private bool? Gorevemi;

        private int? GorevID;

        private bool? Imzayami;

        private DateTime? ItirazdanVazgecmeTarihi;

        private int? ItirazEdenCariID;

        private int? ItirazSebepID;

        private DateTime? ItirazTarihi;

        private DateTime? KesinlesmeTarihi;

        private TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> MyDataSource;

        private DateTime? SonItirazTarihi;

        private bool? Yetkiyemi;

        public rFrmItirazBilgileriGirisEkran()
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
            set
            {
                _MyFoy = value;
                ItirazDoldur(value);
                value.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection.AddingNew +=
                    AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection_AddingNew;
            }
        }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Editor_Click += barButtonItem18_ItemClick;
            this.Button_Excel_Click += barButtonItem18_ItemClick;
            this.Button_Outlook_Click += barButtonItem20_ItemClick;
            this.Button_PDF_Click += barButtonItem22_ItemClick;
            this.Button_Word_Click += barButtonItem19_ItemClick;
            this.Button_Kaydet_Click += barButtonItem3_ItemClick;
        }

        public bool ItirazAlacakNedenKontrol()
        {
            foreach (AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN obj in MyFoy.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection)
            {
                if (obj.ALACAK_NEDEN_ID == null || obj.ITIRAZ_EDEN_TARAF_ID == null || obj.ITIRAZ_BEYAN_SEKLI == 0 ||
                    obj.ITIRAZ_TARIHI == null || obj.ADLI_BIRIM_ADLIYE_ID == null || obj.ADLI_BIRIM_GOREV_ID == null)
                    return false;
            }
            return true;
        }

        public void ItirazBilgileriKaydet()
        {
            DialogResult dr =
                XtraMessageBox.Show(
                    "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine +
                    "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                if (ItirazAlacakNedenKontrol())
                {
                    try
                    {
                        tran.BeginTransaction();
                        DataRepository.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENProvider.DeepSave(tran,
                                                                                         MyFoy.
                                                                                             AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection);
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
                        "Kayýt Sýrasýnda ; \nAlacak Nedeni \nÝtiraz Eden Tarafý \nÝtiraz Beyan Þekli \nÝtiraz Tarihi \nAdliye \nGörev \nAlanlarýndan Herhangi Biri Boþ Geçilemez...");
                }
            }
        }

        public void ItirazDoldur(AV001_TI_BIL_FOY mFoy)
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(mFoy, false,
                                                                                DeepLoadType.IncludeChildren,
                                                                                typeof(
                                                                                    TList
                                                                                    <AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>));
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENProvider.DeepLoad(
                mFoy.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection, false, DeepLoadType.IncludeChildren,
                typeof(AV001_TI_BIL_FOY));
            ucItirazBilgilerGiris1.MyDataSource = mFoy.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection;
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

        private void AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN tumAlacakNEden = e.NewObject as AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN;
            if (tumAlacakNEden == null)
                tumAlacakNEden = new AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN();
            tumAlacakNEden.ICRA_FOY_IDSource = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(MyFoy.ID);
            e.NewObject = tumAlacakNEden;
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

        private void barButtonItem22_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pdf);
        }

        private void barButtonItem3_ItemClick(object sender, EventArgs e)
        {
            //KAYDET
            ItirazBilgileriKaydet();
        }

        private void dtItirazdanVazgecmeTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtItirazdanVazgecmeTarihi.EditValue != null)
                ItirazdanVazgecmeTarihi = (DateTime?)dtItirazdanVazgecmeTarihi.EditValue;
            else
                ItirazdanVazgecmeTarihi = null;
        }

        private void dtKesinlesmeTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtKesinlesmeTarihi.EditValue != null)
                KesinlesmeTarihi = (DateTime?)dtKesinlesmeTarihi.EditValue;
            else
                KesinlesmeTarihi = null;
        }

        private void dtSonItirazTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtSonItirazTarihi.EditValue != null)
                SonItirazTarihi = (DateTime?)dtSonItirazTarihi.EditValue;
            else
                SonItirazTarihi = null;
        }

        private void gLueIcraFoy_EditValueChanged(object sender, EventArgs e)
        {
            MyFoy =
                DataRepository.AV001_TI_BIL_FOYProvider.GetByID(
                    (gLueIcraFoy.Properties.View.GetFocusedRow() as AvukatProLib.Arama.per_AV001_TI_BIL_FOY).ID);
        }

        private void LoadData()
        {
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueItirazEdenCariId, null);

            lueItirazSebepID.Enter += delegate { BelgeUtil.Inits.ItirazSebebiGetir(lueItirazSebepID); };
            AvukatPro.Services.Implementations.DevExpressService.AdliyeDoldur(lueAdliyeID);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeGorevDoldur(lueGorevID);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeNoDoldur(lueBirimID);
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

        private void lueItirazEdenCariId_EditValueChanged(object sender, EventArgs e)
        {
            if (lueItirazEdenCariId.EditValue != null)
                ItirazEdenCariID = (int)lueItirazEdenCariId.EditValue;
            else
                ItirazEdenCariID = null;
        }

        private void lueItirazSebepID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueItirazSebepID.EditValue != null)
                ItirazSebepID = (int)lueItirazSebepID.EditValue;
            else
                ItirazSebepID = null;
        }

        private void lueItirazTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (lueItirazTarihi.EditValue != null)
                ItirazTarihi = (DateTime?)lueItirazTarihi.EditValue;
            else
                ItirazTarihi = null;
        }

        private void rFrmItirazBilgileriGirisEkran_Load(object sender, EventArgs e)
        {
            MyDataSource = new TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>();
            DataRepository.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENProvider.DeepLoad(MyDataSource, false,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(AV001_TI_BIL_FOY));
            ucItirazBilgilerGiris1.MyDataSource = MyDataSource;

            gLueIcraFoy.Properties.DataSource = BelgeUtil.Inits.IcraDosyalariGetir();
            gLueIcraFoy.Properties.DisplayMember = "FOY_NO";
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);

            LoadData();
        }

        private void rgBorca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgBorca.Properties.Items[rgBorca.SelectedIndex].Value == null)
            {
                Borcami = null;
            }
            else
            {
                Borcami = Convert.ToBoolean(rgBorca.Properties.Items[rgBorca.SelectedIndex].Value);
            }
        }

        private void rgDavasiAcildi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgDavasiAcildi.Properties.Items[rgDavasiAcildi.SelectedIndex].Value == null)
            {
                DavasiAcildimi = null;
            }
            else
            {
                DavasiAcildimi = Convert.ToBoolean(rgDavasiAcildi.Properties.Items[rgDavasiAcildi.SelectedIndex].Value);
            }
        }

        private void rgGecikmisItiraz_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgGecikmisItiraz.Properties.Items[rgGecikmisItiraz.SelectedIndex].Value == null)
            {
                GecikmisItirazmi = null;
            }
            else
            {
                GecikmisItirazmi =
                    Convert.ToBoolean(rgGecikmisItiraz.Properties.Items[rgGecikmisItiraz.SelectedIndex].Value);
            }
        }

        private void rgGoreve_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgGoreve.Properties.Items[rgGoreve.SelectedIndex].Value == null)
            {
                Gorevemi = null;
            }
            else
            {
                Gorevemi = Convert.ToBoolean(rgGoreve.Properties.Items[rgGoreve.SelectedIndex].Value);
            }
        }

        private void rgImzaya_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgImzaya.Properties.Items[rgImzaya.SelectedIndex].Value == null)
            {
                Imzayami = null;
            }
            else
            {
                Imzayami = Convert.ToBoolean(rgImzaya.Properties.Items[rgImzaya.SelectedIndex].Value);
            }
        }

        private void rgYetkiye_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgYetkiye.Properties.Items[rgYetkiye.SelectedIndex].Value == null)
            {
                Yetkiyemi = null;
            }
            else
            {
                Yetkiyemi = Convert.ToBoolean(rgYetkiye.Properties.Items[rgYetkiye.SelectedIndex].Value);
            }
        }

        private void sbtnSorgula_Click(object sender, EventArgs e)
        {
            TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> ItirazBilgileriList = new TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>();
            ItirazBilgileriList = DataRepository.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENProvider.GetByFiltre(ItirazEdenCariID,
                                                                                                      Borcami, Imzayami,
                                                                                                      Yetkiyemi,
                                                                                                      Gorevemi,
                                                                                                      ItirazSebepID,
                                                                                                      null, null,
                                                                                                      AdliyeID, GorevID,
                                                                                                      BirimID, EsasNo,
                                                                                                      ItirazTarihi, null,
                                                                                                      null, null, null,
                                                                                                      KesinlesmeTarihi,
                                                                                                      null, null, null,
                                                                                                      null, null, null,
                                                                                                      DavasiAcildimi,
                                                                                                      GecikmisItirazmi,
                                                                                                      SonItirazTarihi,
                                                                                                      ItirazdanVazgecmeTarihi);
            ucItirazBilgilerGiris1.MyDataSource = ItirazBilgileriList;
        }

        private void sbtnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(LCntrItiraz.Controls);
            ucItirazBilgilerGiris1.MyDataSource = null;
            rgBorca.EditValue = 3;
            rgDavasiAcildi.SelectedIndex = 3;
            rgGecikmisItiraz.SelectedIndex = 3;
            rgGoreve.SelectedIndex = 3;
            rgImzaya.SelectedIndex = 3;
            rgYetkiye.SelectedIndex = 3;
        }

        private void txtEsasNo_EditValueChanged(object sender, EventArgs e)
        {
            EsasNo = "%" + txtEsasNo.Text + "%";
            if (txtEsasNo.Text == string.Empty)
                EsasNo = null;
        }
    }
}