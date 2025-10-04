using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using AvukatProLib;
using System.Data;
using DevExpress.XtraBars;
using AdimAdimDavaKaydi.UserControls;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmTaahhutBilgileriGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private AV001_TI_BIL_FOY _MyFoy;

        private DataTable MyDataSource;

        public rFrmTaahhutBilgileriGirisEkran()
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

        public void TaahhutBilgileriKaydet()
        {
            DialogResult dr =
                XtraMessageBox.Show(
                    "İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine +
                    "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                if (TaahhutKontrol())
                {
                    try
                    {
                        tran.BeginTransaction();
                        DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepSave(tran,
                                                                                           MyFoy.
                                                                                               AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection);
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
                        "Kayıt Sırasında ; \nSıra No \nTipi \nTaahhüt Eden \nTah. Tarih \nAlanlarından Herhangi Biri Boş Geçilemez...");
                }
            }
        }

        public void TaahhutDoldur(AV001_TI_BIL_FOY mFoy)
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(mFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>));
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepLoad(mFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD>), typeof(TList<AV001_TDI_BIL_IS_GOREV_SONUC>), typeof(TList<AV001_TDI_BIL_IS_GOREV>), typeof(TList<AV001_TDIE_BIL_MESAJ>), typeof(AV001_TI_BIL_FOY));

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            ucTaahhutBilgileriGiris1.MyDataSource = cn.GetDataTable("SELECT * FROM dbo.R_BORCLU_TAAHHUT_MASTER(nolock) where ICRA_FOY_ID=" + mFoy.ID + " ORDER BY ICRA_FOY_ID, TAAHHUT_SIRA_NO, TAAHHUTU_YERINE_GETIRME_TARIHI");
        }

        public bool TaahhutKontrol()
        {
            foreach (AV001_TI_BIL_BORCLU_TAAHHUT_MASTER obj in MyFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection)
            {
                if (obj.TAAHHUT_SIRA_NO == null || obj.TAAHHUT_TARIHI == null || obj.TAAHHUT_TIP == null ||
                    obj.TAAHHUT_EDEN_ID == null || obj.TAAHHUT_SIRA_NO == 0)
                    return false;
            }
            return true;
        }
        
        private void barButtonItem18_ItemClick(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor frmEdit =
                new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor();
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
            TaahhutBilgileriKaydet();
        }

        private void rFrmTaahhutBilgileriGirisEkran_Load(object sender, EventArgs e)
        {
            //LOAD
            //this.compRibbonExtender1.LoadMainMenu = true;
            //this.compRibbonExtender1.RibbonForExtend = null;
            //this.compRibbonExtender1.RibbonFormForExtend = this;
            //TaahhutDoldur();

            //MyDataSource = new TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>();
            //DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepLoad(MyDataSource, false,
            //                                                                   DeepLoadType.IncludeChildren,
            //                                                                   typeof(AV001_TI_BIL_FOY));
            ucTaahhutBilgileriGiris1.MyDataSource = MyDataSource;

            //BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliye);
            //BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            //BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
            //gLueIcraFoy.Properties.DataSource = BelgeUtil.Inits.IcraDosyalariGetir();
            //gLueIcraFoy.Properties.DisplayMember = "FOY_NO";

            lueTipID.Properties.NullText = "Seç";
            lueTipID.Enter += delegate { BelgeUtil.Inits.TaahhutTipGetir(lueTipID.Properties); };

            lueTaahhutEden.Properties.NullText = "Seç";
            lueTaahhutEden.Enter += delegate
            { //BelgeUtil.Inits.perCariGetir(lueTaahhutEden); 
                AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueTaahhutEden, null);
            };

            lueKabulEden.Properties.NullText = "Seç";
            lueKabulEden.Enter += delegate { AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueTaahhutEden, null); };

            lueOzelKod1.Properties.NullText = "Seç";
            lueOzelKod1.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod1, 1, AvukatProLib.Extras.Modul.Icra); };

            lueOzelKod2.Properties.NullText = "Seç";
            lueOzelKod2.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod2, 2, AvukatProLib.Extras.Modul.Icra); };

            lueOzelKod3.Properties.NullText = "Seç";
            lueOzelKod3.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod3, 3, AvukatProLib.Extras.Modul.Icra); };

            lueOzelKod4.Properties.NullText = "Seç";
            lueOzelKod4.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod4, 4, AvukatProLib.Extras.Modul.Icra); };
        }

        public void sbtnSorgula_Click(object sender, EventArgs e)
        {
            // rgResmi.Properties.Items[rgResmi.SelectedIndex].Value

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            string where = " WHERE ICRA_FOY_ID<>-1";

            if (lueTipID.EditValue != null)
            {
                cn.AddParams("@TAAHHUT_TIP", lueTipID.EditValue);
                where += " and TAAHHUT_TIP=@TAAHHUT_TIP";
            }
            if (lueTaahhutEden.EditValue != null)
            {
                cn.AddParams("@TAAHHUT_EDEN_ID", lueTaahhutEden.EditValue);
                where += " and TAAHHUT_EDEN_ID=@TAAHHUT_EDEN_ID";
            }

            if (lueKabulEden.EditValue != null)
            {
                cn.AddParams("@TAAHHUDU_KABUL_EDEN_ID", lueKabulEden.EditValue);
                where += " and TAAHHUDU_KABUL_EDEN_ID=@TAAHHUDU_KABUL_EDEN_ID";
            }

            if (dtTaahhutTarihi.EditValue != null)
            {
                cn.AddParams("@TAAHHUT_TARIHI", dtTaahhutTarihi.EditValue);
                where += " and TAAHHUT_TARIHI=@TAAHHUT_TARIHI";
            }

            if (dtTebligTarihi.EditValue != null)
            {
                cn.AddParams("@TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI", dtTebligTarihi.EditValue);
                where += " and TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI=@TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI";
            }

            if (dtKabulTarihi.EditValue != null)
            {
                cn.AddParams("@TAAHHUDU_KABUL_TARIHI", dtKabulTarihi.EditValue);
                where += " and TAAHHUDU_KABUL_TARIHI=@TAAHHUDU_KABUL_TARIHI";
            }

            if (dtIhlalTarihi.EditValue != null)
            {
                cn.AddParams("@TAAHHUT_IHLAL_TARIHI", dtIhlalTarihi.EditValue);
                where += " and TAAHHUT_IHLAL_TARIHI=@TAAHHUT_IHLAL_TARIHI";
            }

            if (dateYerineGetirmeT.EditValue != null)
            {
                cn.AddParams("@TAAHHUTU_YERINE_GETIRME_TARIHI", dateYerineGetirmeT.EditValue);
                where += " and TAAHHUTU_YERINE_GETIRME_TARIHI=@TAAHHUTU_YERINE_GETIRME_TARIHI";
            }

            if (lueOzelKod1.EditValue != null)
            {
                cn.AddParams("@OZEL_KOD1", lueOzelKod1.EditValue);
                where += " and OZEL_KOD1=@OZEL_KOD1";
            }

            if (lueOzelKod2.EditValue != null)
            {
                cn.AddParams("@OZEL_KOD2", lueOzelKod2.EditValue);
                where += " and OZEL_KOD2=@OZEL_KOD2";
            }

            if (lueOzelKod3.EditValue != null)
            {
                cn.AddParams("@OZEL_KOD3", lueOzelKod3.EditValue);
                where += " and OZEL_KOD3=@OZEL_KOD3";
            }

            if (lueOzelKod4.EditValue != null)
            {
                cn.AddParams("@OZEL_KOD4", lueOzelKod4.EditValue);
                where += " and OZEL_KOD4=@OZEL_KOD4";
            }

            if (rgResmi.SelectedIndex != 2)
            {
                cn.AddParams("@RESMI_MI", rgResmi.SelectedIndex == 0 ? 1 : 0);
                where += " and RESMI_MI=@RESMI_MI";
            }

            if (rgDavasiVar.SelectedIndex != 2)
            {
                cn.AddParams("@DAVASI_VAR_MI", rgDavasiVar.SelectedIndex == 0 ? 1 : 0);
                where += " and DAVASI_VAR_MI=@DAVASI_VAR_MI";
            }

            if (rgZamanDilimi.SelectedIndex != 6)
            {
                if (dateYerineGetirmeT.EditValue == null)
                {
                    where += Metotlar.ZamanDilimiParametresiOlustur(cn, "TAAHHUTU_YERINE_GETIRME_TARIHI", rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString());
                }
            }

            ucTaahhutBilgileriGiris1.MyDataSource = cn.GetDataTable("SELECT * FROM dbo.R_BORCLU_TAAHHUT_MASTER(nolock)" + where + " ORDER BY ICRA_FOY_ID, TAAHHUT_SIRA_NO, TAAHHUTU_YERINE_GETIRME_TARIHI");
        }

        private void sbtnTemizle_Click(object sender, EventArgs e)
        {
            //FormlariTemizle(layoutControl1.Controls);
            rgDavasiVar.SelectedIndex = 3;
            rgResmi.SelectedIndex = 3;
            rgZamanDilimi.SelectedIndex = 6;
            ucTaahhutBilgileriGiris1.MyDataSource = null;
        }

    }
}