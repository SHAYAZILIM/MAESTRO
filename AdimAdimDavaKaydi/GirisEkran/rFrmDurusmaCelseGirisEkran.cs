using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System.Data;
using AvukatProLib;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmDurusmaCelseGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private AV001_TD_BIL_FOY _MyFoy;

        public rFrmDurusmaCelseGirisEkran()
        {
            InitializeComponent();
            InitializeEvent();
        }

        private AV001_TD_BIL_FOY MyFoy
        {
            get { return _MyFoy; }
        }

        public void CelseDoldur(AV001_TD_BIL_FOY mFoy)
        {
            //AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(mFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_CELSE>));
            //AvukatProLib2.Data.DataRepository.AV001_TD_BIL_CELSEProvider.DeepLoad(mFoy.AV001_TD_BIL_CELSECollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_ARA_KARAR>), typeof(AV001_TD_BIL_FOY));
            //ucCelseTarafli1.MyDataSource = MyFoy.AV001_TD_BIL_CELSECollection;
        }

        public bool CelseKontrol()
        {
            foreach (AV001_TD_BIL_CELSE obj in MyFoy.AV001_TD_BIL_CELSECollection)
            {
                if (obj.TARIH == null || string.IsNullOrEmpty(obj.SAAT) || obj.SORUMLU_AVUKAT_CARI1_ID == null ||
                    string.IsNullOrEmpty(obj.CELSE_REFERANS_NO))
                    return false;
            }
            return true;
        }

        public void DurusmaCelseKaydet()
        {
            DialogResult dr =
                XtraMessageBox.Show(
                    "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine +
                    "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                if (CelseKontrol())
                {
                    try
                    {
                        tran.BeginTransaction();
                        DataRepository.AV001_TD_BIL_CELSEProvider.DeepSave(tran, MyFoy.AV001_TD_BIL_CELSECollection,
                                                                           DeepSaveType.IncludeChildren,
                                                                           typeof(TList<AV001_TD_BIL_CELSE>),
                                                                           typeof(TList<AV001_TDI_BIL_ARA_KARAR>));
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
                        "Kayýt Sýrasýnda ; \nTarih \nSaat \nSorumlu Avukat 1 \nCelse Referans Numarasý \nAlanlarýndan Herhangi Biri Boþ Geçilemez...");
                }
            }
        }

        public void InitializeEvent()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += barButtonItem3_ItemClick;
            this.Button_Outlook_Click += barButtonItem20_ItemClick;
            this.Button_PDF_Click += barButtonItem22_ItemClick;
            this.Button_Excel_Click += barButtonItem21_ItemClick;
            this.Button_Word_Click += barButtonItem19_ItemClick;
            this.Button_Editor_Click += barButtonItem18_ItemClick;
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
            DurusmaCelseKaydet();
        }
        
        private void LoadData()
        {
            lueSorumluAvukat1.Properties.NullText = "Seç";
            lueSorumluAvukat1.Enter += delegate { BelgeUtil.Inits.SorumluAvukatGetir(lueSorumluAvukat1); };

            lueSorumluAvukat2.Properties.NullText = "Seç";
            lueSorumluAvukat2.Enter += delegate { BelgeUtil.Inits.SorumluAvukatGetir(lueSorumluAvukat2); };            

            lueIncelemeTuru.Properties.NullText = "Seç";
            lueIncelemeTuru.Enter += delegate { BelgeUtil.Inits.IncelemeTurGetir(lueIncelemeTuru); };
        }
        
        private void rFrmDurusmaCelseGirisEkran_Load(object sender, EventArgs e)
        {
            //LOAD

            //ada.AV001_TD_BIL_ARA_KARARCollection
            //this.compRibbonExtender1.LoadMainMenu = true;
            //this.compRibbonExtender1.RibbonForExtend = null;
            //this.compRibbonExtender1.RibbonFormForExtend = this;
            //CelseDoldur();
            //ada.DavaEdenler
            //ada.DavaEdilenler

            this.WindowState = FormWindowState.Maximized;

            //MyDataSource = new TList<AV001_TD_BIL_CELSE>();
            //DataRepository.AV001_TD_BIL_CELSEProvider.DeepLoad(MyDataSource, false, DeepLoadType.IncludeChildren,
            //                                                   typeof(AV001_TD_BIL_FOY));
            //ucCelseTarafli1.MyDataSource = MyDataSource;

            //foreach (AV001_TD_BIL_CELSE var in MyDataSource)
            //{
            //    if (var.DAVA_FOY_IDSource != null)
            //    {
            //        DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(var.DAVA_FOY_IDSource, false,
            //                                                         DeepLoadType.IncludeChildren,
            //                                                         typeof(TList<AV001_TD_BIL_FOY_TARAF>));

            //        DataRepository.AV001_TD_BIL_FOY_TARAFProvider.DeepLoad(
            //            var.DAVA_FOY_IDSource.AV001_TD_BIL_FOY_TARAFCollection, false, DeepLoadType.IncludeChildren,
            //            typeof(AV001_TDI_BIL_CARI));
            //    }
            //}

            //ucCelseBilgileri1.MyDataSource = MyDataSource;
            LoadData();
        }

        private void sbtnSorgula_Click(object sender, EventArgs e)
        {
            //TList<AV001_TD_BIL_CELSE> CelseList = new TList<AV001_TD_BIL_CELSE>();
            //CelseList = DataRepository.AV001_TD_BIL_CELSEProvider.GetByFiltre(Tarih, null, SorumluAvukat1ID,
            //                                                                  SorumluAvukat2ID, Hakim1ID, Hakim2ID,
            //                                                                  Hakim3ID, SavciID, KatipID, MazeretVarmi,
            //                                                                  null, Celsemi, null, IncelemeTuruID,
            //                                                                  ReferansNo, CelseyeGirildimi);


            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            string where = " where a.ID<>-1";

            if (dtTarih.EditValue != null)
            {
                cn.AddParams("@TARIH", dtTarih.EditValue);
                where += " and a.TARIH=@TARIH";
            }

            if (lueIncelemeTuru.EditValue != null)
            {
                cn.AddParams("@INCELEME_TUR_ID", lueIncelemeTuru.EditValue);
                where += " and a.INCELEME_TUR_ID=@INCELEME_TUR_ID";
            }

            if (lueSorumluAvukat1.EditValue != null)
            {
                cn.AddParams("@SORUMLU_AVUKAT_CARI1_ID", lueSorumluAvukat1.EditValue);
                where += " and a.SORUMLU_AVUKAT_CARI1_ID=@SORUMLU_AVUKAT_CARI1_ID";
            }

            if (lueSorumluAvukat2.EditValue != null)
            {
                cn.AddParams("@SORUMLU_AVUKAT_CARI2_ID", lueSorumluAvukat2.EditValue);
                where += " and a.SORUMLU_AVUKAT_CARI2_ID=@SORUMLU_AVUKAT_CARI2_ID";
            }

            if (rgCelse.SelectedIndex != 2)
            {
                cn.AddParams("@CELSE_MI", rgCelse.SelectedIndex == 0 ? 1 : 0);
                where += " and a.CELSE_MI=@CELSE_MI";
            }

            if (rgCelseyeGirildi.SelectedIndex != 2)
            {
                cn.AddParams("@CELSEYE_GIRILDI_MI", rgCelseyeGirildi.SelectedIndex == 0 ? 1 : 0);
                where += " and a.CELSEYE_GIRILDI_MI=@CELSEYE_GIRILDI_MI";
            }

            if (rgMazeret.SelectedIndex != 2)
            {
                cn.AddParams("@MAZERET_VAR_MI", rgMazeret.SelectedIndex == 0 ? 1 : 0);
                where += " and a.MAZERET_VAR_MI=@MAZERET_VAR_MI";
            }

            if (!string.IsNullOrEmpty(txtReferansNo.Text))
            {
                cn.AddParams("@CELSE_REFERANS_NO", txtReferansNo.Text);
                where += " and a.CELSE_REFERANS_NO like '%' + @CELSE_REFERANS_NO + '%'";
            }

            if (dtTarih.EditValue == null)
            {
                if (rgZamanDilimi.SelectedIndex != 6)
                    where += Metotlar.ZamanDilimiParametresiOlustur(cn, "TARIH", rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString()).Replace(" TARIH"," a.TARIH");
            }

            ucCelseTarafli1.MyDataSource = cn.GetDataTable("SELECT b.ESAS_NO AS DavaESAS_NO, b.FOY_NO AS DavaFOY_NO, b.ADLI_BIRIM_ADLIYE_ID AS DavaADLI_BIRIM_ADLIYE_ID, b.ADLI_BIRIM_NO_ID AS DavaADLI_BIRIM_NO_ID, b.ADLI_BIRIM_GOREV_ID AS DavaADLI_BIRIM_GOREV_ID, b.DAVA_TARIHI AS DavaDAVA_TARIHI, a.TARIH, a.SORUMLU_AVUKAT_CARI1_ID, a.SORUMLU_AVUKAT_CARI2_ID, a.MAZERET_VAR_MI, a.MURAFA_MI, a.CELSE_MI, a.INCELEME_TUR_ID, a.ACIKLAMA, a.CELSE_REFERANS_NO , (SELECT TOP(1)davaciAd.AD FROM dbo.AV001_TD_BIL_FOY_TARAF(nolock) davaci INNER JOIN dbo.AV001_TDI_BIL_CARI(nolock) davaciAd ON davaciAd.ID=davaci.CARI_ID where davaci.DAVA_FOY_ID=a.DAVA_FOY_ID AND davaci.TARAF_SIFAT_ID IN (SELECT ID FROM dbo.TDIE_KOD_TARAF_SIFAT(nolock) c WHERE HANGI_TARAF_NO=3)) AS DavaEdenler , (SELECT TOP(1)davaliAd.AD FROM dbo.AV001_TD_BIL_FOY_TARAF(nolock) davali INNER JOIN dbo.AV001_TDI_BIL_CARI(nolock) davaliAd ON davaliAd.ID=davali.CARI_ID where davali.DAVA_FOY_ID=a.DAVA_FOY_ID AND davali.TARAF_SIFAT_ID IN (SELECT ID FROM dbo.TDIE_KOD_TARAF_SIFAT(nolock) c WHERE HANGI_TARAF_NO=4)) AS DavaEdilenler, a.ID, b.ID AS FOY_ID FROM dbo.AV001_TD_BIL_CELSE(nolock) a INNER JOIN dbo.AV001_TD_BIL_FOY(nolock) b ON b.ID=a.DAVA_FOY_ID" + where);

            //pGcCelse.MyDurusma = CelseList; aykut
        }

        private void sbtnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(navBarGroupControlContainer1.Controls);
            rgCelseyeGirildi.SelectedIndex = 3;
            rgMazeret.SelectedIndex = 3;
            rgCelse.SelectedIndex = 3;
            ucCelseTarafli1.MyDataSource = null;
            rgZamanDilimi.SelectedIndex = 6;
        }

        private void tabcDurusma_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            CreatePivot();
            pGcCelse.MyDurusma = ucCelseTarafli1.MyDataSource;
        }
    }
}