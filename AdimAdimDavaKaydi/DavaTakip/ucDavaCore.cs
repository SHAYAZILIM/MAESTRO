using AdimAdimDavaKaydi.Util;
using AvukatPro.Model.EntityClasses;
using AvukatProLib;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.DavaTakip
{
    public partial class ucDavaCore : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        #region Fields

        private AV001_TD_BIL_FOY _myFoy;

        #endregion Fields

        #region Constructors

        public ucDavaCore()
        {
            InitializeComponent();
            this.Load += ucDavaCore_Load;
        }

        #endregion Constructors

        #region Properties

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return _myFoy; }
            set
            {
                _myFoy = value;
                if (value != null)
                {
                    try
                    {
                        Thread th = new Thread(new ThreadStart(delegate
                        {
                            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_OZEL_KOD>));
                            OzelKodBinding();
                            FoyOzelKodBinding();
                        }));
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                        this.ucDavaGridler1.MyFoy = value;
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
        }

        #endregion Properties

        #region Methods

        private void FoyOzelKodBinding()
        {
            if (MyFoy.AV001_TD_BIL_FOY_OZEL_KODCollection.Count == 0)
                MyFoy.AV001_TD_BIL_FOY_OZEL_KODCollection.AddNew();
            try
            {
                lueBanka.DataBindings.Clear();
                lueBanka.DataBindings.Add("EditValue", MyFoy.AV001_TD_BIL_FOY_OZEL_KODCollection, "BANKA_ID", true);

                lueSube.DataBindings.Clear();
                lueSube.DataBindings.Add("EditValue", MyFoy.AV001_TD_BIL_FOY_OZEL_KODCollection, "SUBE_ID", true);

                lueFoyYeri.DataBindings.Clear();
                lueFoyYeri.DataBindings.Add("EditValue", MyFoy.AV001_TD_BIL_FOY_OZEL_KODCollection, "FOY_YERI_ID", true);

                lueFoyBirim.DataBindings.Clear();
                lueFoyBirim.DataBindings.Add("EditValue", MyFoy.AV001_TD_BIL_FOY_OZEL_KODCollection, "FOY_BIRIM_ID", true);

                lueFoyOzelDurum.DataBindings.Clear();
                lueFoyOzelDurum.DataBindings.Add("EditValue", MyFoy.AV001_TD_BIL_FOY_OZEL_KODCollection, "FOY_OZEL_DURUM_ID", true);

                txtAciklama.DataBindings.Clear();
                txtAciklama.DataBindings.Add("TEXT", MyFoy.AV001_TD_BIL_FOY_OZEL_KODCollection, "ACIKLAMA", true);

                lueKrediGrup.DataBindings.Clear();
                lueKrediGrup.DataBindings.Add("EditValue", MyFoy.AV001_TD_BIL_FOY_OZEL_KODCollection, "KREDI_GRUP_ID", true);

                lueKrediTip.DataBindings.Clear();
                lueKrediTip.DataBindings.Add("EditValue", MyFoy.AV001_TD_BIL_FOY_OZEL_KODCollection, "KREDI_TIP_ID", true);

                lueTahsilat.DataBindings.Clear();
                lueTahsilat.DataBindings.Add("EditValue", MyFoy.AV001_TD_BIL_FOY_OZEL_KODCollection, "TAHSILAT_DURUM_ID", true);

                //KLASOR_1
                textEdit2.DataBindings.Clear();
                textEdit2.DataBindings.Add("TEXT", MyFoy.AV001_TD_BIL_FOY_OZEL_KODCollection, "KLASOR_1", true);

                //KLASOR_2
                textEdit3.DataBindings.Clear();
                textEdit3.DataBindings.Add("TEXT", MyFoy.AV001_TD_BIL_FOY_OZEL_KODCollection, "KLASOR_2", true);
            }
            catch
            {
            }
        }

        private void LoadData()
        {
            BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod_1, 1, AvukatProLib.Extras.Modul.Dava);
            BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod_2, 2, AvukatProLib.Extras.Modul.Dava);
            BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod_3, 3, AvukatProLib.Extras.Modul.Dava);
            BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod_4, 4, AvukatProLib.Extras.Modul.Dava);
            BelgeUtil.Inits.BankaGetir(lueBanka);
            BelgeUtil.Inits.BankaSubeGetir(lueSube);
            BelgeUtil.Inits.FoyBirimGetir(lueFoyBirim);
            BelgeUtil.Inits.FoyYeriGetir(lueFoyYeri);
            BelgeUtil.Inits.FoyOzelDurumGetir(lueFoyOzelDurum.Properties);
            BelgeUtil.Inits.KrediGrubu(lueKrediGrup);
            BelgeUtil.Inits.KrediTipiGetir(lueKrediTip.Properties);
            BelgeUtil.Inits.TahsilatdurumGetir(lueTahsilat.Properties);

            //TARIH         :  11 Eylül 2009 Cuma
            //KODU YAZAN    :  Mehmet Emin AYDOÐDU
            //NEDENI        :  Özel Kodlar ve Referans Baþlýklarýnýn Veri Tabnýndan Alýnmasý
            //Mehmet Bas

            #region Ozellestirme

            lblOzelKod1.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod1;
            lblOzelKod2.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod2;
            lblOzelKod3.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod3;
            lblOzelKod4.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod4;
            lblBanka.Text = Kimlikci.Kimlik.OrtakOzelDurum.Banka;
            lblFoyBirim.Text = Kimlikci.Kimlik.OrtakOzelDurum.FoyBirim;
            lblFoyYeri.Text = Kimlikci.Kimlik.OrtakOzelDurum.FoyYeri;
            lblKlasor1.Text = Kimlikci.Kimlik.OrtakOzelDurum.Klasor1;
            lblKrediGrup.Text = Kimlikci.Kimlik.OrtakOzelDurum.KrediGrup;
            lblKrediTip.Text = Kimlikci.Kimlik.OrtakOzelDurum.KrediTip;
            lblOzel.Text = Kimlikci.Kimlik.OrtakOzelDurum.Ozel;
            lblSube.Text = Kimlikci.Kimlik.OrtakOzelDurum.Sube;
            lblTahsilat.Text = Kimlikci.Kimlik.OrtakOzelDurum.Tahsilat;
            lblKlasor2.Text = Kimlikci.Kimlik.OrtakOzelDurum.Klasor2;
            lblRef1.Text = Kimlikci.Kimlik.DavaReferans.Referans1;
            lblRef2.Text = Kimlikci.Kimlik.DavaReferans.Referans2;
            lblRef3.Text = Kimlikci.Kimlik.DavaReferans.Referans3;

            #endregion Ozellestirme

            //Mehmet Bit
        }

        private void lookUpExtender1_OnClickOrProcessNewValue(object sender, LookUpExtenderEventArgs e)
        {
            if (e.SenderLookUp != null)
                if (e.SenderLookUp.Name.Contains("OzelKod"))
                {
                    try
                    {
                        byte alanNo = 0;
                        switch (e.SenderLookUp.Name)
                        {
                            case "lueOzelKod_1":
                                alanNo = 1;
                                break;

                            case "lueOzelKod_2":
                                alanNo = 2;
                                break;

                            case "lueOzelKod_3":
                                alanNo = 3;
                                break;

                            case "lueOzelKod_4":
                                alanNo = 4;
                                break;

                            default:
                                break;
                        }
                        frmFoyOzelKodEkle frm = new frmFoyOzelKodEkle();
                        frm.Davadan = true;
                        DialogResult dr = frm.ShowDialog(alanNo, e.SenderLookUp.Text);
                        if (dr == DialogResult.OK)
                        {
                            Av001TdiKodFoyOzelEntity ozel = frm.MyOzelKod;
                            if (ozel != null)
                                ((List<Av001TdiKodFoyOzelEntity>)e.SenderLookUp.Properties.DataSource).Add(ozel);
                        }
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
        }

        private void lueBanka_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                #region <AC - 20090617>

                // lueSube.Properties.DataSource view dan geldiði için TList VList olarak deðiþtirildi.
                ((VList<per_TDI_KOD_BANKA_SUBE>)lueSube.Properties.DataSource).Filter = "BANKA_ID = " +
                                                                                         (int)e.NewValue;

                #endregion <AC - 20090617>
            }
        }

        private void OzelKodBinding()
        {
            try
            {
                lueOzelKod_1.DataBindings.Clear();
                lueOzelKod_1.DataBindings.Add("EditValue", MyFoy, "DAVA_OZEL_KOD1_ID", true);

                lueOzelKod_2.DataBindings.Clear();
                lueOzelKod_2.DataBindings.Add("EditValue", MyFoy, "DAVA_OZEL_KOD2_ID", true);

                lueOzelKod_3.DataBindings.Clear();
                lueOzelKod_3.DataBindings.Add("EditValue", MyFoy, "DAVA_OZEL_KOD3_ID", true);

                lueOzelKod_4.DataBindings.Clear();
                lueOzelKod_4.DataBindings.Add("EditValue", MyFoy, "DAVA_OZEL_KOD4_ID", true);
                txtRef1.DataBindings.Add("TEXT", MyFoy, "REFERANS_NO", true);
                txtRef2.DataBindings.Add("TEXT", MyFoy, "REFERANS_NO2", true);
                txtRef3.DataBindings.Add("TEXT", MyFoy, "REFERANS_NO3", true);

                txtDosyaNotlari.DataBindings.Clear();
                txtDosyaNotlari.DataBindings.Add("TEXT", MyFoy, "ACIKLAMA", true);
            }
            catch
            {
            }
        }

        private void ucDavaCore_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            LoadData();
        }

        #endregion Methods
    }
}