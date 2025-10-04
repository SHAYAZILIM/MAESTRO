using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Sorusturma.UserControls
{
    public partial class ucSorusturmaCore : DevExpress.XtraEditors.XtraUserControl
    {
        #region Fields

        private AV001_TD_BIL_HAZIRLIK _myHazirlik;

        #endregion Fields

        #region Constructors

        public ucSorusturmaCore()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        [Browsable(false)]
        public AV001_TD_BIL_HAZIRLIK MyHazirlik
        {
            get { return _myHazirlik; }
            set
            {
                _myHazirlik = value;
                if (value != null)
                {
                    try
                    {
                        //this.ucSorusturmaGridler1.MyHazirlikFoy = value;

                        FoyOzelKodBinding();

                        //OzelKodBinding();
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
        }

        public TList<TD_BIL_HAZIRLIK_OZEL_KOD> OzelKod
        {
            get { return (TList<TD_BIL_HAZIRLIK_OZEL_KOD>)bndSorusturmaOzelKod.DataSource; }
            set
            {
                bndSorusturmaOzelKod.DataSource = value;
                if (OzelKod != null)
                {
                    FoyOzelKodBinding();
                }
            }
        }

        #endregion Properties

        #region Methods

        private void BindOzelKod()
        {
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod_1, 1, AvukatProLib.Extras.Modul.Sorusturma);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod_2, 2, AvukatProLib.Extras.Modul.Sorusturma);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod_3, 3, AvukatProLib.Extras.Modul.Sorusturma);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod_4, 4, AvukatProLib.Extras.Modul.Sorusturma);
        }

        /// <summary>
        /// BindData to Controls BankaOzelKodlari
        /// </summary>
        private void FoyOzelKodBinding()
        {
            if (MyHazirlik.TD_BIL_HAZIRLIK_OZEL_KODCollection.Count == 0)
            {
                MyHazirlik.TD_BIL_HAZIRLIK_OZEL_KODCollection.AddNew();
            }

            lueBanka.DataBindings.Clear();
            lueBanka.DataBindings.Add("EditValue", MyHazirlik.TD_BIL_HAZIRLIK_OZEL_KODCollection, "BANKA_ID", true);

            lueSube.DataBindings.Clear();
            lueSube.DataBindings.Add("EditValue", MyHazirlik.TD_BIL_HAZIRLIK_OZEL_KODCollection, "SUBE_ID", true);

            lueFoyYeri.DataBindings.Clear();
            lueFoyYeri.DataBindings.Add("EditValue", MyHazirlik.TD_BIL_HAZIRLIK_OZEL_KODCollection, "FOY_YERI_ID", true);

            lueFoyBirim.DataBindings.Clear();
            lueFoyBirim.DataBindings.Add("EditValue", MyHazirlik.TD_BIL_HAZIRLIK_OZEL_KODCollection, "FOY_BIRIM_ID",
                                         true);

            lueFoyOzelDurum.DataBindings.Clear();
            lueFoyOzelDurum.DataBindings.Add("EditValue", MyHazirlik.TD_BIL_HAZIRLIK_OZEL_KODCollection,
                                             "FOY_OZEL_DURUM_ID", true);

            txtAciklama.DataBindings.Clear();
            txtAciklama.DataBindings.Add("TEXT", MyHazirlik.TD_BIL_HAZIRLIK_OZEL_KODCollection, "ACIKLAMA", true);

            lueKrediGrup.DataBindings.Clear();
            lueKrediGrup.DataBindings.Add("EditValue", MyHazirlik.TD_BIL_HAZIRLIK_OZEL_KODCollection, "KREDI_GRUP_ID",
                                          true);

            lueKrediTip.DataBindings.Clear();
            lueKrediTip.DataBindings.Add("EditValue", MyHazirlik.TD_BIL_HAZIRLIK_OZEL_KODCollection, "KREDI_TIP_ID",
                                         true);

            lueTahsilat.DataBindings.Clear();
            lueTahsilat.DataBindings.Add("EditValue", MyHazirlik.TD_BIL_HAZIRLIK_OZEL_KODCollection, "TAHSILAT_DURUM_ID",
                                         true);

            textEdit2.DataBindings.Clear();
            textEdit2.DataBindings.Add("TEXT", MyHazirlik.TD_BIL_HAZIRLIK_OZEL_KODCollection, "KLASOR_1", true);

            textEdit3.DataBindings.Clear();
            textEdit3.DataBindings.Add("TEXT", MyHazirlik.TD_BIL_HAZIRLIK_OZEL_KODCollection, "KLASOR_2", true);
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BindOzelKod();
        }

        private void LoadData()
        {
            BindOzelKod();
            lueOzelKod_1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            lueOzelKod_2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            lueOzelKod_3.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            lueOzelKod_4.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);

            BelgeUtil.Inits.BankaGetir(lueBanka);
            BelgeUtil.Inits.FoyBirimGetir(lueFoyBirim);
            BelgeUtil.Inits.FoyOzelDurumGetir(lueFoyOzelDurum.Properties);
            BelgeUtil.Inits.FoyYeriGetir(lueFoyYeri);
            BelgeUtil.Inits.KrediGrubu(lueKrediGrup);
            BelgeUtil.Inits.KrediTipiGetir(lueKrediTip);
            BelgeUtil.Inits.BankaSubeGetir(lueSube);
            BelgeUtil.Inits.TaahhutDurumGetir(lueTahsilat);
            lblOzelKod1.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod1;
            lblOzelKod2.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod2;
            lblOzelKod3.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod3;
            lblOzelKod4.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod4;
            lblBanka.Text = Kimlikci.Kimlik.OrtakOzelDurum.Banka;
            lblFoyBirim.Text = Kimlikci.Kimlik.OrtakOzelDurum.FoyBirim;
            lblFoyYeri.Text = Kimlikci.Kimlik.OrtakOzelDurum.FoyYeri;
            lblKrediGrup.Text = Kimlikci.Kimlik.OrtakOzelDurum.KrediGrup;
            lblKrediTip.Text = Kimlikci.Kimlik.OrtakOzelDurum.KrediTip;
            lblOzel.Text = Kimlikci.Kimlik.OrtakOzelDurum.Ozel;
            lblSube.Text = Kimlikci.Kimlik.OrtakOzelDurum.Sube;
            lblTahsilat.Text = Kimlikci.Kimlik.OrtakOzelDurum.Tahsilat;
            lblKlasor1.Text = Kimlikci.Kimlik.OrtakOzelDurum.Klasor1;
            lblKlasor2.Text = Kimlikci.Kimlik.OrtakOzelDurum.Klasor2;
        }

        private void lookUpExtender1_OnClickOrProcessNewValue(object sender, LookUpExtenderEventArgs e)
        {
            if (e.SenderLookUp != null)
            {
                if (e.SenderLookUp.Properties.Name.Contains("OzelKod"))
                {
                    try
                    {
                        AV001_TDI_KOD_FOY_OZEL ozel = new AV001_TDI_KOD_FOY_OZEL();
                        ozel.KOD = e.TypedValue;
                        DataRepository.AV001_TDI_KOD_FOY_OZELProvider.Save(ozel);
                        ((TList<AV001_TDI_KOD_FOY_OZEL>)e.SenderLookUp.Properties.DataSource).Add(ozel);
                        XtraMessageBox.Show("Özel kod baþarýyla eklenmiþtir.");
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
        }

        private void lueBanka_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                #region <AC - 20090617>

                // lueSube.Properties.DataSource view dan geldiði için TList VList olarak deðiþtirildi.
                ((VList<per_TDI_KOD_BANKA_SUBE>)lueSube.Properties.DataSource).Filter = string.Empty;

                ((VList<per_TDI_KOD_BANKA_SUBE>)lueSube.Properties.DataSource).Filter = "BANKA_ID = " +
                                                                                         (int)e.NewValue;

                #endregion <AC - 20090617>
            }
        }

        private void lueOzelKod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == "ekle")
            {
                AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle frm = new AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle();
                frm.Show();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            }
        }

        //private void lueOzelKod_1_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    LookUpEdit lue = sender as LookUpEdit;

        //    if (e.Button.Tag != null && e.Button.Tag == "OKEkle")
        //    {
        //        frmFoyOzelKodEkle foyOKod = new frmFoyOzelKodEkle();
        //        foyOKod.Sorusturmadan = true;
        //        DialogResult dr = foyOKod.ShowDialog(1, lue.Text);
        //        if (dr == DialogResult.OK)
        //        {
        //            List<Av001TdiKodFoyOzelEntity> dtOzelKod =
        //                lueOzelKod_1.Properties.DataSource as List<Av001TdiKodFoyOzelEntity>;
        //            if (dtOzelKod != null && foyOKod.MyOzelKod != null)
        //            {
        //                dtOzelKod.Add(foyOKod.MyOzelKod);
        //            }
        //        }
        //    }
        //}

        //private void lueOzelKod_1_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        //{
        //    LookUpEdit lue = sender as LookUpEdit;
        //    if (!string.IsNullOrEmpty(lue.Text))
        //    {
        //        frmFoyOzelKodEkle foyOKod = new frmFoyOzelKodEkle();
        //        foyOKod.Sorusturmadan = true;
        //        DialogResult dr = foyOKod.ShowDialog(1, e.DisplayValue.ToString());
        //        if (dr == DialogResult.OK)
        //        {
        //            List<Av001TdiKodFoyOzelEntity> dtOzelKod =
        //                lueOzelKod_1.Properties.DataSource as List<Av001TdiKodFoyOzelEntity>;
        //            if (dtOzelKod != null && foyOKod.MyOzelKod != null)
        //            {
        //                dtOzelKod.Add(foyOKod.MyOzelKod);
        //            }
        //        }
        //    }
        //}

        //private void lueOzelKod_2_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    LookUpEdit lue = sender as LookUpEdit;

        //    if (e.Button.Tag != null && e.Button.Tag == "OKEkle")
        //    {
        //        frmFoyOzelKodEkle foyOKod = new frmFoyOzelKodEkle();
        //        foyOKod.Sorusturmadan = true;
        //        DialogResult dr = foyOKod.ShowDialog(2, lue.Text);
        //        if (dr == DialogResult.OK)
        //        {
        //            List<Av001TdiKodFoyOzelEntity> dtOzelKod =
        //                lueOzelKod_2.Properties.DataSource as List<Av001TdiKodFoyOzelEntity>;
        //            if (dtOzelKod != null && foyOKod.MyOzelKod != null)
        //            {
        //                dtOzelKod.Add(foyOKod.MyOzelKod);
        //            }
        //        }
        //    }
        //}

        //private void lueOzelKod_2_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        //{
        //    LookUpEdit lue = sender as LookUpEdit;
        //    if (!string.IsNullOrEmpty(lue.Text))
        //    {
        //        frmFoyOzelKodEkle foyOKod = new frmFoyOzelKodEkle();
        //        foyOKod.Sorusturmadan = true;
        //        DialogResult dr = foyOKod.ShowDialog(2, e.DisplayValue.ToString());
        //        if (dr == DialogResult.OK)
        //        {
        //            List<Av001TdiKodFoyOzelEntity> dtOzelKod =
        //                lueOzelKod_2.Properties.DataSource as List<Av001TdiKodFoyOzelEntity>;
        //            if (dtOzelKod != null && foyOKod.MyOzelKod != null)
        //            {
        //                dtOzelKod.Add(foyOKod.MyOzelKod);
        //            }
        //        }
        //    }
        //}

        //private void lueOzelKod_3_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    LookUpEdit lue = sender as LookUpEdit;

        //    if (e.Button.Tag != null && e.Button.Tag == "OKEkle")
        //    {
        //        frmFoyOzelKodEkle foyOKod = new frmFoyOzelKodEkle();
        //        foyOKod.Sorusturmadan = true;
        //        DialogResult dr = foyOKod.ShowDialog(3, lue.Text);
        //        if (dr == DialogResult.OK)
        //        {
        //            List<Av001TdiKodFoyOzelEntity> dtOzelKod =
        //                lueOzelKod_3.Properties.DataSource as List<Av001TdiKodFoyOzelEntity>;
        //            if (dtOzelKod != null && foyOKod.MyOzelKod != null)
        //            {
        //                dtOzelKod.Add(foyOKod.MyOzelKod);
        //            }
        //        }
        //    }
        //}

        //private void lueOzelKod_3_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        //{
        //    LookUpEdit lue = sender as LookUpEdit;
        //    if (!string.IsNullOrEmpty(lue.Text))
        //    {
        //        frmFoyOzelKodEkle foyOKod = new frmFoyOzelKodEkle();
        //        foyOKod.Sorusturmadan = true;
        //        DialogResult dr = foyOKod.ShowDialog(3, e.DisplayValue.ToString());
        //        if (dr == DialogResult.OK)
        //        {
        //            List<Av001TdiKodFoyOzelEntity> dtOzelKod =
        //                lueOzelKod_3.Properties.DataSource as List<Av001TdiKodFoyOzelEntity>;
        //            if (dtOzelKod != null && foyOKod.MyOzelKod != null)
        //            {
        //                dtOzelKod.Add(foyOKod.MyOzelKod);
        //            }
        //        }
        //    }
        //}

        //private void lueOzelKod_4_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    LookUpEdit lue = sender as LookUpEdit;

        //    if (e.Button.Tag != null && e.Button.Tag == "OKEkle")
        //    {
        //        frmFoyOzelKodEkle foyOKod = new frmFoyOzelKodEkle();
        //        foyOKod.Sorusturmadan = true;
        //        DialogResult dr = foyOKod.ShowDialog(4, lue.Text);
        //        if (dr == DialogResult.OK)
        //        {
        //            List<Av001TdiKodFoyOzelEntity> dtOzelKod =
        //                lueOzelKod_4.Properties.DataSource as List<Av001TdiKodFoyOzelEntity>;
        //            if (dtOzelKod != null && foyOKod.MyOzelKod != null)
        //            {
        //                dtOzelKod.Add(foyOKod.MyOzelKod);
        //            }
        //        }
        //    }
        //}

        //private void lueOzelKod_4_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        //{
        //    LookUpEdit lue = sender as LookUpEdit;
        //    if (!string.IsNullOrEmpty(lue.Text))
        //    {
        //        frmFoyOzelKodEkle foyOKod = new frmFoyOzelKodEkle();
        //        foyOKod.Sorusturmadan = true;
        //        DialogResult dr = foyOKod.ShowDialog(4, e.DisplayValue.ToString());
        //        if (dr == DialogResult.OK)
        //        {
        //            List<Av001TdiKodFoyOzelEntity> dtOzelKod =
        //                lueOzelKod_4.Properties.DataSource as List<Av001TdiKodFoyOzelEntity>;
        //            if (dtOzelKod != null && foyOKod.MyOzelKod != null)
        //            {
        //                dtOzelKod.Add(foyOKod.MyOzelKod);
        //            }
        //        }
        //    }
        //}

        //private void OzelKodBinding()
        //{
        //    lueOzelKod_1.DataBindings.Clear();
        //    lueOzelKod_1.DataBindings.Add("EditValue", MyHazirlik, "OZEL_KOD_1_ID", true);

        //    lueOzelKod_2.DataBindings.Clear();
        //    lueOzelKod_2.DataBindings.Add("EditValue", MyHazirlik, "OZEL_KOD_2_ID", true);

        //    lueOzelKod_3.DataBindings.Clear();
        //    lueOzelKod_3.DataBindings.Add("EditValue", MyHazirlik, "OZEL_KOD_3_ID", true);

        //    lueOzelKod_4.DataBindings.Clear();
        //    lueOzelKod_4.DataBindings.Add("EditValue", MyHazirlik, "OZEL_KOD_4_ID", true);
        //}

        private void ucSorusturmaCore_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            LoadData();
        }

        #endregion Methods
    }
}