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
    public partial class rFrmIhtiyatiHacizGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private AV001_TI_BIL_FOY _MyFoy;

        private int? AdliyeID;

        private int? BirimID;

        private string EsasNo;

        private int? GorevID;

        private DateTime? KararTarihi;

        private DateTime? KHCevirmeTarihi;

        private DateTime? MuvekkileIadeTarihi;

        private TList<AV001_TI_BIL_IHTIYATI_HACIZ> MyDataSource;

        private DateTime? TalepTarihi;

        private DateTime? TeminatIadeTarihi;

        private int? TeminatTuruID;

        public rFrmIhtiyatiHacizGirisEkran()
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
                IhtiyatiHacizGetir(value);
                value.AV001_TI_BIL_IHTIYATI_HACIZCollection.AddingNew += AV001_TI_BIL_IHTIYATI_HACIZCollection_AddingNew;
            }
        }

        public void IhtiyatiHacizGetir(AV001_TI_BIL_FOY mFoy)
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(mFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ>));
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.DeepLoad(mFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ_TARAF>), typeof(AV001_TI_BIL_FOY));
            ucIhtiyatiHacizBilgiGiris1.MyDataSource = mFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection;
        }

        public void IhtiyatiHAcizKaydet()
        {
            DialogResult dr =
                XtraMessageBox.Show(
                    "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine +
                    "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                if (IhtiyatiHacizKontrol())
                {
                    try
                    {
                        tran.BeginTransaction();
                        DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.DeepSave(tran,
                                                                                    MyFoy.
                                                                                        AV001_TI_BIL_IHTIYATI_HACIZCollection);
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
                        "Kayýt Sýrasýnda ; \nAdliye \nGörev \nEsas No \nKarar No \nAlanlarýndan Herhangi Biri Boþ Geçilemez...");
                }
            }
        }

        public bool IhtiyatiHacizKontrol()
        {
            if (MyFoy != null)
            {
                foreach (AV001_TI_BIL_IHTIYATI_HACIZ obj in MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection)
                {
                    if (obj.ADLI_BIRIM_ADLIYE_ID == null || obj.ADLI_BIRIM_GOREV_ID == null ||
                        string.IsNullOrEmpty(obj.ESAS_NO) || string.IsNullOrEmpty(obj.KARAR_NO))
                        return false;
                }
            }
            else
                return false;

            return true;
        }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += barButtonItem3_ItemClick;
            this.Button_Outlook_Click += barButtonItem20_ItemClick;
            this.Button_PDF_Click += barButtonItem22_ItemClick;
            this.Button_Word_Click += barButtonItem19_ItemClick;
            this.Button_Excel_Click += barButtonItem21_ItemClick;
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

        private void AV001_TI_BIL_IHTIYATI_HACIZCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_IHTIYATI_HACIZ tumIhtiyatiHacizler = e.NewObject as AV001_TI_BIL_IHTIYATI_HACIZ;
            if (tumIhtiyatiHacizler == null)
                tumIhtiyatiHacizler = new AV001_TI_BIL_IHTIYATI_HACIZ();
            tumIhtiyatiHacizler.ICRA_FOY_IDSource = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(MyFoy.ID);

            e.NewObject = tumIhtiyatiHacizler;
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
            IhtiyatiHAcizKaydet();
        }

        private void dtKararTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtKararTarihi.EditValue != null)
                KararTarihi = (DateTime?)dtKararTarihi.EditValue;
            else
                KararTarihi = null;
        }

        private void dtKHCevirmeTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtKHCevirmeTarihi.EditValue != null)
                KHCevirmeTarihi = (DateTime?)dtKHCevirmeTarihi.EditValue;
            else
                KHCevirmeTarihi = null;
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

        private void rFrmIhtiyatiHacizGirisEkran_Load(object sender, EventArgs e)
        {
            //LOAD
            //this.compRibbonExtender1.LoadMainMenu = true;
            //this.compRibbonExtender1.RibbonForExtend = null;
            //this.compRibbonExtender1.RibbonFormForExtend = this;
            //IhtyatiHacizGetir();

            MyDataSource = new TList<AV001_TI_BIL_IHTIYATI_HACIZ>();
            DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.DeepLoad(MyDataSource, false,
                                                                        DeepLoadType.IncludeChildren,
                                                                        typeof(AV001_TI_BIL_FOY));
            ucIhtiyatiHacizBilgiGiris1.MyDataSource = MyDataSource;

            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
            gLueIcraFoy.Properties.DataSource = BelgeUtil.Inits.IcraDosyalariGetir();
            gLueIcraFoy.Properties.DisplayMember = "FOY_NO";

            LoadData();
        }

        private void sbtnSorgula_Click(object sender, EventArgs e)
        {
            TList<AV001_TI_BIL_IHTIYATI_HACIZ> IhtiyatiHacizBilgileriList = new TList<AV001_TI_BIL_IHTIYATI_HACIZ>();
            IhtiyatiHacizBilgileriList = DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.GetByFiltre(AdliyeID,
                                                                                                        GorevID, BirimID,
                                                                                                        EsasNo,
                                                                                                        KHCevirmeTarihi,
                                                                                                        KararTarihi,
                                                                                                        TalepTarihi,
                                                                                                        TeminatTuruID,
                                                                                                        null, null,
                                                                                                        TeminatIadeTarihi,
                                                                                                        MuvekkileIadeTarihi,
                                                                                                        null);
            DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.DeepLoad(IhtiyatiHacizBilgileriList, false,
                                                                        DeepLoadType.IncludeChildren,
                                                                        typeof(TList<AV001_TI_BIL_FOY>));
            ucIhtiyatiHacizBilgiGiris1.MyDataSource = IhtiyatiHacizBilgileriList;
        }

        private void sbtnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(LCntrlIhtiyatiHaciz.Controls);
            ucIhtiyatiHacizBilgiGiris1.MyDataSource = null;
        }

        private void txtEsasNo_EditValueChanged(object sender, EventArgs e)
        {
            EsasNo = "%" + txtEsasNo.Text + "%";
            if (txtEsasNo.Text == string.Empty)
                EsasNo = null;
        }
    }
}