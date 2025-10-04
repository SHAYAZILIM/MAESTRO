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
    public partial class rFrmTumMallarGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private AV001_TI_BIL_FOY _MyFoy;

        private int? AdliyeID;

        private string Adres;

        private int? BirimID;

        private int? CariID;

        private int? CinsID;

        private string EsasNo;

        private int? GorevID;

        private int? KategoriID;

        private string PlakaNo;

        private int? TurID;

        public rFrmTumMallarGirisEkran()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += rFrmTumMallarGirisEkran_Load;
        }

        /// <summary>
        /// Þuanda seçili olan AV001_TI_BIL_FOY nesnesini temsil eder
        /// </summary>
        private AV001_TI_BIL_FOY MyFoy
        {
            get { return _MyFoy; }
        }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Excel_Click += barButtonItem21_ItemClick;
            this.Button_Editor_Click += barButtonItem18_ItemClick;
            this.Button_Outlook_Click += barButtonItem20_ItemClick;
            this.Button_PDF_Click += barButtonItem22_ItemClick;
            this.Button_Word_Click += barButtonItem19_ItemClick;
            this.Button_Kaydet_Click += barButtonItem3_ItemClick;
        }

        public void TumMallarDoldur(AV001_TI_BIL_FOY mFoy)
        {
            /*
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(mFoy, false,
                                                                                DeepLoadType.IncludeChildren,
                                                                                typeof (TList<TDI_BIL_BORCLU_MAL>));

            AvukatProLib2.Data.DataRepository.TDI_BIL_BORCLU_MALProvider.DeepLoad(mFoy.TDI_BIL_BORCLU_MALCollection,
                                                                                  false, DeepLoadType.IncludeChildren,
                                                                                  typeof (
                                                                                      TList<AV001_TI_BIL_KIYMET_TAKDIRI>
                                                                                      ), typeof (AV001_TI_BIL_FOY));

            ucBorcluMallarGiris1.MyDataSource = mFoy.TDI_BIL_BORCLU_MALCollection;  */
            ucBorcluMallarGiris1.MyDataSource = BelgeUtil.Inits.context.per_TDI_BIL_BORCLU_MALs.Where(vi => vi.ICRA_FOY_ID == mFoy.ID).ToList();
        }

        public void TumMallarKaydet()
        {
            DialogResult dr =
                XtraMessageBox.Show(
                    "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine +
                    "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                if (TumMallarKontrol())
                {
                    try
                    {
                        tran.BeginTransaction();
                        DataRepository.TDI_BIL_BORCLU_MALProvider.DeepSave(tran, MyFoy.TDI_BIL_BORCLU_MALCollection);
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
                    XtraMessageBox.Show(
                        "Kayýt Sýrasýnda ; \nMal Sýra No \nMal Tür-Cins-Kategori \nMal Adedi \nAdet Birimi \nve Mal Tipi \nAlanlarýndan Herhangi Biri Boþ Geçilemez...");
            }
        }

        public bool TumMallarKontrol()
        {
            foreach (TDI_BIL_BORCLU_MAL obj in MyFoy.TDI_BIL_BORCLU_MALCollection)
            {
                if (obj.MAL_SIRA_NO == null || obj.HACIZLI_MAL_CINS_ID == null || obj.HACIZLI_MAL_ADET_BIRIM_ID == null ||
                    obj.HACIZLI_MAL_KATEGORI_ID == null || obj.HACIZLI_MAL_TUR_ID == null ||
                    obj.HACIZLI_MAL_ADEDI == null || obj.TIP == null || obj.HACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID == null ||
                    obj.HACIZLI_MAL_DEGERI_DOVIZ_ID == null || obj.YEDIEMIN_GUNLUK_UCRET_DOVIZ_ID == null ||
                    obj.MAL_SIRA_NO == 0)
                    return false;
            }
            return true;
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
            TumMallarKaydet();
        }

        private void LoadData()
        {
            lueKategoriID.Properties.NullText = "Seç";
            lueKategoriID.Enter += delegate { BelgeUtil.Inits.MalKategoriGetir(lueKategoriID); };

            lueTurID.Properties.NullText = "Seç";
            lueTurID.Enter += delegate { BelgeUtil.Inits.MalTurGetir(lueTurID); };

            lueCinsID.Properties.NullText = "Seç";
            lueCinsID.Enter += delegate { BelgeUtil.Inits.MalcinsGetir(lueCinsID); };

            lueCariID.Properties.NullText = "Seç";
            lueCariID.Enter += delegate { BelgeUtil.Inits.perCariGetir(lueCariID); };

            lueAdliyeID.Properties.NullText = "Seç";
            lueAdliyeID.Enter += delegate { BelgeUtil.Inits.AdliBirimAdliyeGetir(lueAdliyeID); };

            lueGorevID.Properties.NullText = "Seç";
            lueGorevID.Enter += delegate { BelgeUtil.Inits.AdliBirimGorevGetir(lueGorevID); };

            lueBirimID.Properties.NullText = "Seç";
            lueBirimID.Enter += delegate { BelgeUtil.Inits.AdliBirimNoGetir(lueBirimID); };
        }

        private void lueAdliyeID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAdliyeID.EditValue != null)
                AdliyeID = Convert.ToInt32(lueAdliyeID.EditValue);
            else
                AdliyeID = null;
        }

        private void lueBirimID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBirimID.EditValue != null)
                BirimID = Convert.ToInt32(lueBirimID.EditValue);
            else
                BirimID = null;
        }

        private void lueCariID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueCariID.EditValue != null)
                CariID = Convert.ToInt32(lueCariID.EditValue);
            else
                CariID = null;
        }

        private void lueCinsID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueCinsID.EditValue != null)
                CinsID = Convert.ToInt32(lueCinsID.EditValue);
            else
                CinsID = null;
        }

        private void lueGorevID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueGorevID.EditValue != null)
                GorevID = Convert.ToInt32(lueGorevID.EditValue);
            else
                GorevID = null;
        }

        private void lueKategoriID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueKategoriID.EditValue != null)
                KategoriID = Convert.ToInt32(lueKategoriID.EditValue);
            else
                KategoriID = null;
        }

        private void lueTurID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTurID.EditValue != null)
                TurID = Convert.ToInt32(lueTurID.EditValue);
            else
                TurID = null;
        }

        private void rFrmTumMallarGirisEkran_Load(object sender, EventArgs e)
        {
            //this.compRibbonExtender1.LoadMainMenu = true;
            //this.compRibbonExtender1.RibbonForExtend = null;
            //this.compRibbonExtender1.RibbonFormForExtend = this;

            /*enver tarafýndan view a çevrildi
            MyDataSource = new TList<TDI_BIL_BORCLU_MAL>();
            DataRepository.TDI_BIL_BORCLU_MALProvider.DeepLoad(MyDataSource, false, DeepLoadType.IncludeChildren,
                                                               typeof (TList<AV001_TI_BIL_KIYMET_TAKDIRI>),
                                                               typeof (AV001_TI_BIL_FOY));
            ucBorcluMallarGiris1.MyDataSource = MyDataSource;

            gLueIcraFoy.Properties.DataSource = BelgeUtil.Inits.IcraDosyalariGetir();
            gLueIcraFoy.Properties.DisplayMember = "FOY_NO";

            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
             */

            LoadData();
        }

        private void sbtnSorgula_Click(object sender, EventArgs e)
        {
            List<AvukatProLib.Arama.per_TDI_BIL_BORCLU_MAL> TumMalBilgileriList = new List<AvukatProLib.Arama.per_TDI_BIL_BORCLU_MAL>();
            TumMalBilgileriList = AvukatProLib.Arama.per_TDI_BIL_BORCLU_MALArama.GetByFilterView(null, KategoriID, TurID, CinsID,
                                                                                        PlakaNo, null, null, null, Adres,
                                                                                        CariID, AdliyeID, GorevID,
                                                                                        BirimID, EsasNo);
            ucBorcluMallarGiris1.MyDataSource = TumMalBilgileriList;
        }

        private void sbtnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(layoutControl1.Controls);
            ucBorcluMallarGiris1.MyDataSource = null;
            ucBorcluMallarGiris1.FilitreleriTemizle();
        }
        
        private void txtAdres_EditValueChanged(object sender, EventArgs e)
        {
            Adres = "%" + txtAdres.Text + "%";
            if (txtAdres.Text == string.Empty)
                Adres = null;
        }

        private void txtEsasNo_EditValueChanged(object sender, EventArgs e)
        {
            EsasNo = "%" + txtEsasNo.Text + "%";
            if (txtEsasNo.Text == string.Empty)
                EsasNo = null;
        }

        private void txtPlaka_EditValueChanged(object sender, EventArgs e)
        {
            PlakaNo = "%" + txtPlaka.Text + "%";
            if (txtPlaka.Text == string.Empty)
                PlakaNo = null;
        }
    }
}