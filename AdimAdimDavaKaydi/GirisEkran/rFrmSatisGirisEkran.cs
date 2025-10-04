using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmSatisGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private AV001_TI_BIL_FOY _MyFoy;

        private int? AdliyeID;

        private int? BirimID;

        private int? GorevID;

        private int? IlanSekliID;

        private TList<AV001_TI_BIL_SATIS_MASTER> MyDataSource;

        private int? SatisIstenenID;

        private int? SatisIsteyenID;

        public rFrmSatisGirisEkran()
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
                SatisGetir(value);
                value.AV001_TI_BIL_SATIS_MASTERCollection.AddingNew += AV001_TI_BIL_SATIS_MASTERCollection_AddingNew;
            }
        }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += barButtonItem3_ItemClick;
        }

        public void SatisBilgileriKaydet()
        {
            DialogResult dr =
                XtraMessageBox.Show(
                    "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine +
                    "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                if (SatisKontrol())
                {
                    try
                    {
                        tran.BeginTransaction();
                        DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.DeepSave(tran,
                                                                                  MyFoy.
                                                                                      AV001_TI_BIL_SATIS_MASTERCollection);
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
                        "Kayýt Sýrasýnda ; \nSýra No \nSatýþ Ýstenme Þekli \nSatýþý Ýstenen \nÝlan Þekli \nSatýþýn Ýstenme Tarihi \nSatýþ Türü \nSorumlu Personel \nToplam Satýþ Deðeri \nDoviz Deðeri \nAlanlarýndan Herhangi Biri Boþ Geçilemez...");
                }
            }
        }

        public void SatisGetir(AV001_TI_BIL_FOY mFoy)
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(mFoy, false,
                                                                                DeepLoadType.IncludeChildren,
                                                                                typeof(TList<AV001_TI_BIL_SATIS_MASTER>
                                                                                    ));
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.DeepLoad(
                mFoy.AV001_TI_BIL_SATIS_MASTERCollection, false, DeepLoadType.IncludeChildren,
                typeof(TList<AV001_TI_BIL_SATIS_CHILD>), typeof(AV001_TI_BIL_FOY));
            ucSatisMaster1.MyDataSource = mFoy.AV001_TI_BIL_SATIS_MASTERCollection;
        }

        public bool SatisKontrol()
        {
            foreach (AV001_TI_BIL_SATIS_MASTER obj in MyFoy.AV001_TI_BIL_SATIS_MASTERCollection)
            {
                if (obj.SATIS_SIRA_NO == null || obj.SATIS_SIRA_NO == 0 || obj.SATISIN_ISTENME_SEKLI_ID == null ||
                    obj.SATISI_ISTENEN_CARI_ID == null || obj.ILAN_SEKLI == null || obj.SATIS_ISTEME_TARIHI == null ||
                    obj.SATIS_TURU_ID == null || obj.SATIS_SORUMLU_PERSONEL_ID == null ||
                    obj.TOPLAM_SATIS_DEGERI == Decimal.Zero || obj.TOPLAM_SATIS_DEGERI_DOVIZ_ID == null)
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

        private void AV001_TI_BIL_SATIS_MASTERCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_SATIS_MASTER tumSatislar = e.NewObject as AV001_TI_BIL_SATIS_MASTER;
            if (tumSatislar == null)
                tumSatislar = new AV001_TI_BIL_SATIS_MASTER();
            tumSatislar.ICRA_FOY_IDSource = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(MyFoy.ID);

            e.NewObject = tumSatislar;
        }

        private void barButtonItem3_ItemClick(object sender, EventArgs e)
        {
            //KAYDET
            SatisBilgileriKaydet();
        }

        private void gLueIcraFoy_EditValueChanged(object sender, EventArgs e)
        {
            MyFoy =
                DataRepository.AV001_TI_BIL_FOYProvider.GetByID(
                    (gLueIcraFoy.Properties.View.GetFocusedRow() as AvukatProLib.Arama.per_AV001_TI_BIL_FOY).ID);
        }

        private void LoadData()
        {
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueSatisiIsteyenID, null);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueSatisiIstenenID, null);

            lueIlanSekliID.Properties.NullText = "Seç";
            lueIlanSekliID.Enter += delegate { BelgeUtil.Inits.SatisIlanSekliGetir(lueIlanSekliID.Properties); };

            AvukatPro.Services.Implementations.DevExpressService.AdliyeDoldur(lueAdliyeID);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeGorevDoldur(lueGorevID);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeNoDoldur(lueBirimID);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueSorumluPersonelID, AvukatProLib.Extras.CariStatu.Personel);

            lueSatisTuruID.Properties.NullText = "Seç";
            lueSatisTuruID.Enter += delegate { BelgeUtil.Inits.SatisTuruGetir(lueSatisTuruID); };
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

        private void lueIlanSekliID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueIlanSekliID.EditValue != null)
                IlanSekliID = Convert.ToInt32(lueIlanSekliID.EditValue);
            else
                IlanSekliID = null;
        }

        private void lueSatisiIstenenID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSatisiIstenenID.EditValue != null)
                SatisIstenenID = (int)lueSatisiIstenenID.EditValue;
            else
                SatisIstenenID = null;
        }

        private void lueSatisiIsteyenID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSatisiIsteyenID.EditValue != null)
                SatisIsteyenID = (int)lueSatisiIsteyenID.EditValue;
            else
                SatisIsteyenID = null;
        }

        private void rFrmSatisGirisEkran_Load(object sender, EventArgs e)
        {
            MyDataSource = new TList<AV001_TI_BIL_SATIS_MASTER>();
            DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.DeepLoad(MyDataSource, false, DeepLoadType.IncludeChildren,
                                                                      typeof(TList<AV001_TI_BIL_SATIS_CHILD>),
                                                                      typeof(AV001_TI_BIL_FOY));
            ucSatisMaster1.MyDataSource = MyDataSource;

            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);

            gLueIcraFoy.Properties.DataSource = BelgeUtil.Inits.IcraDosyalariGetir();
            gLueIcraFoy.Properties.DisplayMember = "FOY_NO";

            LoadData();
        }

        private void sbtnSorgula_Click(object sender, EventArgs e)
        {
            TList<AV001_TI_BIL_SATIS_MASTER> SatisGirisiList = new TList<AV001_TI_BIL_SATIS_MASTER>();

            SatisGirisiList = DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.GetByFiltre(null, null, SatisIsteyenID,
                                                                                           SatisIstenenID, null,
                                                                                           IlanSekliID
                                                                                           , null, null, null, null,
                                                                                           null, null, null, null, null,
                                                                                           null, null
                                                                                           , null, null, null, null,
                                                                                           null, null, null, null,
                                                                                           AdliyeID, GorevID, BirimID
                                                                                           , null, null, null, null,
                                                                                           null, null, null, null, null
                                                                                           , null, null, null, null,
                                                                                           null, null, null, null);
            DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.DeepLoad(SatisGirisiList, false,
                                                                      DeepLoadType.IncludeChildren,
                                                                      typeof(TList<AV001_TI_BIL_SATIS_CHILD>));

            ucSatisMaster1.MyDataSource = SatisGirisiList;
        }

        private void sbtnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(layoutControl1.Controls);
            ucSatisMaster1.MyDataSource = null;
        }
    }
}