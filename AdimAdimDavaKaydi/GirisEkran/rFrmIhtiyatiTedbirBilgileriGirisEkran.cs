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
    public partial class rFrmIhtiyatiTedbirBilgileriGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private AV001_TI_BIL_FOY _MyFoy;

        private int? AdliyeID;

        private int? BirimID;

        private DateTime? DavaTarihi;

        private string EsasNo;

        private int? GorevID;

        private DateTime? KararTarihi;

        private DateTime? MuvekkileIadeTarihi;

        private TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> MyDataSource;

        private DateTime? TalepTarihi;

        private DateTime? TeminatIadeTarihi;

        private int? TeminatTuruID;

        public rFrmIhtiyatiTedbirBilgileriGirisEkran()
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
                IhtiyatiTedbirDoldur(value);
                value.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.AddingNew +=
                    AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_AddingNew;
            }
        }

        public void IhtiyatiTedbirDoldur(AV001_TI_BIL_FOY mFoy)
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(mFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>));
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.DeepLoad(mFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF>), typeof(AV001_TI_BIL_FOY));
            ucIhtiyatiTedbirBilgiGiris1.MyDataSource = mFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;
        }

        public void IhtiyatiTedbirKaydet()
        {
            DialogResult dr =
                XtraMessageBox.Show(
                    "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine +
                    "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                if (IhtiyatiTedbirKontrol())
                {
                    try
                    {
                        tran.BeginTransaction();
                        DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.DeepSave(tran,
                                                                                      MyFoy.
                                                                                          AV001_TDI_BIL_IHTIYATI_TEDBIRCollection);
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
                        "Kayýt Sýrasýnda ; \nAdliye \nGörev \nEsas No \nKarar No \nTalep Tarihi \nDava Tarihi \nAlanlarýndan Herhangi Biri Boþ Geçilemez...");
                }
            }
        }

        public bool IhtiyatiTedbirKontrol()
        {
            foreach (AV001_TDI_BIL_IHTIYATI_TEDBIR obj in MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection)
            {
                if (obj.ADLI_BIRIM_ADLIYE_ID == null || obj.ADLI_BIRIM_GOREV_ID == null || obj.DAVA_TARIHI == null ||
                    obj.TALEP_TARIHI == null || string.IsNullOrEmpty(obj.ESAS_NO) || string.IsNullOrEmpty(obj.KARAR_NO))
                    return false;
            }
            return true;
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

        private void AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_IHTIYATI_TEDBIR tumIhtiyatiTedbir = e.NewObject as AV001_TDI_BIL_IHTIYATI_TEDBIR;
            if (tumIhtiyatiTedbir == null)
                tumIhtiyatiTedbir = new AV001_TDI_BIL_IHTIYATI_TEDBIR();
            tumIhtiyatiTedbir.ICRA_FOY_IDSource = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(MyFoy.ID);

            e.NewObject = tumIhtiyatiTedbir;
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
            IhtiyatiTedbirKaydet();
        }

        private void dtDavaTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtDavaTarihi.EditValue != null)
                DavaTarihi = (DateTime?)dtDavaTarihi.EditValue;
            else
                DavaTarihi = null;
        }

        private void dtKararTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtKararTarihi.EditValue != null)
                KararTarihi = (DateTime?)dtKararTarihi.EditValue;
            else
                KararTarihi = null;
        }

        private void dtMuvekkileIadeTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtMuvekkileIadeTarihi.EditValue != null)
                MuvekkileIadeTarihi = (DateTime?)dtMuvekkileIadeTarihi.EditValue;
            else
                MuvekkileIadeTarihi = null;
        }

        private void dtTalepTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtTalepTarihi.EditValue != null)
                TalepTarihi = (DateTime?)dtTalepTarihi.EditValue;
            else
                TalepTarihi = null;
        }

        private void dtTeminatIadeTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtTeminatIadeTarihi.EditValue != null)
                TeminatIadeTarihi = (DateTime?)dtTeminatIadeTarihi.EditValue;
            else
                TeminatIadeTarihi = null;
        }

        private void gLueIcraFoy_EditValueChanged(object sender, EventArgs e)
        {
            MyFoy =
                DataRepository.AV001_TI_BIL_FOYProvider.GetByID(
                    (gLueIcraFoy.Properties.View.GetFocusedRow() as AvukatProLib.Arama.per_AV001_TI_BIL_FOY).ID);
        }

        private void LoadData()
        {
            lueAdliyeID.Properties.NullText = "Seç";
            lueAdliyeID.Enter += delegate { BelgeUtil.Inits.AdliBirimAdliyeGetir(lueAdliyeID); };

            lueGorevID.Properties.NullText = "Seç";
            lueGorevID.Enter += delegate { BelgeUtil.Inits.AdliBirimGorevGetir(lueGorevID); };

            lueBirimID.Properties.NullText = "Seç";
            lueBirimID.Enter += delegate { BelgeUtil.Inits.AdliBirimNoGetir(lueBirimID); };

            lueTeminatTuruID.Properties.NullText = "Seç";
            lueTeminatTuruID.Enter += delegate { BelgeUtil.Inits.TeminatTuruGetir(lueTeminatTuruID.Properties); };
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

        private void lueTeminatTuruID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTeminatTuruID.EditValue != null)
                TeminatTuruID = (int)lueTeminatTuruID.EditValue;
            else
                TeminatTuruID = null;
        }

        private void rFrmIhtiyatiTedbirBilgileriGirisEkran_Load(object sender, EventArgs e)
        {
            //LOAD
            //this.compRibbonExtender1.LoadMainMenu = true;
            //this.compRibbonExtender1.RibbonForExtend = null;
            //this.compRibbonExtender1.RibbonFormForExtend = this;
            //IhtiyatiTedbirDoldur();

            MyDataSource = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>();
            DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.DeepLoad(MyDataSource, false,
                                                                          DeepLoadType.IncludeChildren,
                                                                          typeof(AV001_TI_BIL_FOY));
            ucIhtiyatiTedbirBilgiGiris1.MyDataSource = MyDataSource;

            gLueIcraFoy.Properties.DataSource = BelgeUtil.Inits.IcraDosyalariGetir();
            gLueIcraFoy.Properties.DisplayMember = "FOY_NO";

            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);

            LoadData();
        }

        private void sbtnSorgula_Click(object sender, EventArgs e)
        {
            TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> IhtiyatiTedbirBilgileriList =
                new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>();
            IhtiyatiTedbirBilgileriList = DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.GetByFiltre(AdliyeID,
                                                                                                           GorevID,
                                                                                                           BirimID,
                                                                                                           EsasNo,
                                                                                                           DavaTarihi,
                                                                                                           KararTarihi,
                                                                                                           TalepTarihi,
                                                                                                           TeminatTuruID,
                                                                                                           null, null,
                                                                                                           TeminatIadeTarihi,
                                                                                                           MuvekkileIadeTarihi,
                                                                                                           null);
            ucIhtiyatiTedbirBilgiGiris1.MyDataSource = IhtiyatiTedbirBilgileriList;
        }

        private void sbtnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(LcntrlIhtiyatiTedbir.Controls);
            ucIhtiyatiTedbirBilgiGiris1.MyDataSource = null;
        }

        private void txtEsasNo_EditValueChanged(object sender, EventArgs e)
        {
            EsasNo = "%" + txtEsasNo.Text + "%";
            if (txtEsasNo.Text == string.Empty)
                EsasNo = null;
        }
    }
}