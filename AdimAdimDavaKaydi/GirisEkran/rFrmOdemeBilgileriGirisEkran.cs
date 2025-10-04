using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AvukatPro.Model.EntityClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System.Data;
using AvukatProLib;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmOdemeBilgileriGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private AV001_TI_BIL_FOY _MyFoy;

        public rFrmOdemeBilgileriGirisEkran()
        {
            InitializeComponent();
            InitializeEvents();
        }

        /// <summary>
        /// Şuanda seçili olan AV001_TI_BIL_FOY nesnesini temsil eder
        /// </summary>
        private AV001_TI_BIL_FOY MyFoy
        {
            get { return _MyFoy; }
        }

        public bool BorcluOdemeKontrol()
        {
            if (MyFoy != null)
            {
                foreach (AV001_TI_BIL_BORCLU_ODEME obj in MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
                {
                    if (obj.ODEYEN_CARI_ID == null || obj.ODENEN_CARI_ID == null || obj.ODEME_YER_ID == null ||
                        obj.ODEME_TARIHI == null || obj.ODEME_TIP_ID == null)
                        return false;
                }
                return true;
            }
            return false;
        }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Editor_Click += barButtonItem18_ItemClick;
            this.Button_Excel_Click += barButtonItem21_ItemClick;
            this.Button_Outlook_Click += barButtonItem20_ItemClick;
            this.Button_PDF_Click += barButtonItem22_ItemClick;
            this.Button_Word_Click += barButtonItem19_ItemClick;
            this.Button_Kaydet_Click += barButtonItem3_ItemClick;
        }

        public void OdemeBilgileriKaydet()
        {
            DialogResult dr =
                XtraMessageBox.Show(
                    "İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine +
                    "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                if (BorcluOdemeKontrol())
                {
                    try
                    {
                        AvukatProLib.Hesap.HesapYapar.TaahhutKontrol(MyFoy);
                        tran.BeginTransaction();
                        if (MyFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection != null)
                            DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepSave(tran,
                                                                                               MyFoy.
                                                                                                   AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection);

                        DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepSave(tran,
                                                                                  MyFoy.
                                                                                      AV001_TI_BIL_BORCLU_ODEMECollection);
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
                        "Kayıt Sırasında ; \nÖdeyen - Ödenen Şahıs \nÖdeme Yeri \nÖdeme Tarihi \nÖdeme Tipi \nAlanlarından Herhangi Biri Boş Geçilemez...");
                }
            }
        }

        public void OdemeIcraDoldur(AV001_TI_BIL_FOY mFoy)
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(mFoy, false, DeepLoadType.IncludeChildren, typeof(TList<TDI_BIL_BORCLU_MAL>));
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

            OdemeBilgileriKaydet();
        }
                
        private void LoadData()
        {
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueOdeyenCariID, null);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueOdenenCariID, null);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeDoldur(lueAdliyeID);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeNoDoldur(lueBirimID);

            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod1, 1, AvukatProLib.Extras.Modul.Icra);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod2, 2, AvukatProLib.Extras.Modul.Icra);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod3, 3, AvukatProLib.Extras.Modul.Icra);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod4, 4, AvukatProLib.Extras.Modul.Icra);

            lueODemeTipi.Properties.NullText = "Seç";
            lueODemeTipi.Enter += delegate { BelgeUtil.Inits.OdemeTipiGetir(lueODemeTipi); };

            lueODemeYeri.Properties.NullText = "Seç";
            lueODemeYeri.Enter += delegate { BelgeUtil.Inits.OdemeYeriGetir(lueODemeYeri.Properties); };
        }
                                                                
        private void rFrmOdemeBilgileriGirisEkran_Load(object sender, EventArgs e)
        {
            //MyDataSource = new DataTable();
            //ucOdemeGirisView.MyDataSource = MyDataSource;
            this.WindowState = FormWindowState.Maximized;
            LoadData();

            //refefa .Text = Kimlikci.Kimlik.DavaReferans.Referans1;
            //lciRef2.Text = Kimlikci.Kimlik.DavaReferans.Referans2;
            //lciRef3.Text = Kimlikci.Kimlik.DavaReferans.Referans3;
            lcItemOzelKod1.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod1;
            lcItemOzelKod2.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod2;
            lcItemOzelKod3.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod3;
            lcItemOzelKod4.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod4;
        }
        
        private void sbtnSorgula_Click(object sender, EventArgs e)
        {
            AvukatPro.Services.Messaging.GetOdemeByFiltreRequest request = new AvukatPro.Services.Messaging.GetOdemeByFiltreRequest();

            if (lueAdliyeID.Text.Length > 0 & lueAdliyeID.Text != "Seçiniz")
                request.Adliye = lueAdliyeID.Text;
            else
                request.Adliye = null;

            if (lueBirimID.Text.Length > 0 & lueBirimID.Text != "Seçiniz")
                request.AdliNo = lueBirimID.Text;
            else
                request.AdliNo = null;

            if (txtEsasNo.Text.Length > 0)
                request.EsasNo = txtEsasNo.Text;
            else
                request.EsasNo = null;

            if (dtIcradanCekilmeTarihi.EditValue != null)
                request.IcradanCekilmeTarihi = (DateTime?)dtIcradanCekilmeTarihi.EditValue;
            else
                request.IcradanCekilmeTarihi = null;

            if (rgIhtiyatiHacizde.Properties.Items[rgIhtiyatiHacizde.SelectedIndex].Value == null)
            {
                request.IhtiyatiHacizdenmi = null;
            }
            else
            {
                request.IhtiyatiHacizdenmi =
                    Convert.ToBoolean(rgIhtiyatiHacizde.Properties.Items[rgIhtiyatiHacizde.SelectedIndex].Value);
            }

            if (rgMassHaczinden.Properties.Items[rgMassHaczinden.SelectedIndex].Value == null)
            {
                request.MaasHaczindenmi = null;
            }
            else
            {
                request.MaasHaczindenmi =
                    Convert.ToBoolean(rgMassHaczinden.Properties.Items[rgMassHaczinden.SelectedIndex].Value);
            }

            if (dtOdemeTarihi.EditValue != null)
                request.OdemeTarihi = (DateTime?)dtOdemeTarihi.EditValue;
            else
                request.OdemeTarihi = null;

            if (lueODemeTipi.EditValue != null)
                request.OdemeTipiID = (int)lueODemeTipi.EditValue;
            else
                request.OdemeTipiID = null;


            if (lueODemeYeri.EditValue != null)
                request.OdemeYeriID = (int)lueODemeYeri.EditValue;

            if (lueOdenenCariID.EditValue != null && !string.IsNullOrEmpty(lueOdenenCariID.EditValue.ToString()))
                request.OdenenCariID = (int)lueOdenenCariID.EditValue;
            else
                request.OdenenCariID = null;

            if (lueOdeyenCariID.EditValue != null && !string.IsNullOrEmpty(lueOdeyenCariID.EditValue.ToString()))
                request.OdeyenCariID = (int)lueOdeyenCariID.EditValue;
            else
                request.OdeyenCariID = null;

            if (lueOzelKod1.EditValue != null)
                request.OzelKod1ID = (int)lueOzelKod1.EditValue;
            else
                request.OzelKod1ID = null;

            if (lueOzelKod2.EditValue != null)
                request.OzelKod2ID = (int)lueOzelKod2.EditValue;
            else
                request.OzelKod2ID = null;

            if (lueOzelKod3.EditValue != null)
                request.OzelKod3ID = (int)lueOzelKod3.EditValue;
            else
                request.OzelKod3ID = null;

            if (lueOzelKod4.EditValue != null)
                request.OzelKod4ID = (int)lueOzelKod4.EditValue;
            else
                request.OzelKod4ID = null;

            ucOdemeGirisView.MyDataSource = AvukatPro.Services.Implementations.DosyaService.GetOdemeByFiltre(request, rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString());
            //pGOdemeBilgileri.MyOdemeExpress = ucOdemeGirisView.MyDataSource;
            //tabPivotRapor.PageEnabled = true;

            //var obj = DataRepository.R_EXPRESS_BORCLU_ODEME_PROJEProvider.GetByFiltre(null, , , null, null, , , , , , , null, null, null, null, null, null, null, null, null, null, null, null, null, null, , , null, , null, null, null, null, null, , , , ).GroupBy(vi => vi.ESAS_NO).ToList();

            //VList<R_EXPRESS_BORCLU_ODEME_PROJE> OdemeBilgileriList = new VList<R_EXPRESS_BORCLU_ODEME_PROJE>();
            //foreach (var item in obj)
            //{
            //    foreach (var test in item)
            //    {
            //        if (OdemeBilgileriList.Find(vi => vi.ID == test.ID) == null) OdemeBilgileriList.Add(test);
            //    }
            //}
            //ucOdemeGirisView.MyDataSource = OdemeBilgileriList;
        }

        private void sbtnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(lcOdemeBilgileri.Controls);
            ucOdemeGirisView.MyDataSource = null;
            rgIhtiyatiHacizde.SelectedIndex = 3;
            rgMassHaczinden.SelectedIndex = 3;
            rgZamanDilimi.SelectedIndex = 6;
        }
        
        void tabcOdemeBilgileri_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabcOdemeBilgileri.SelectedTabPageIndex == 1)
            {
                PivotCreate();
                pGOdemeBilgileri.MyOdemeExpress = ucOdemeGirisView.MyDataSource;
                tabPivotRapor.PageEnabled = true;
            }
        }
    }
}
