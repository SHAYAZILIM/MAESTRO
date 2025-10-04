using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AvukatPro.Model.EntityClasses;
using AvukatProLib.Extras;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.Editor.Degiskenler.Util;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class rFrmTarafOdeme : Util.BaseClasses.AvpXtraForm
    {
        #region Fields

        public TList<AV001_TI_BIL_BORCLU_ODEME> result = new TList<AV001_TI_BIL_BORCLU_ODEME>();

        private bool _IsModul;
        private AV001_TI_BIL_FOY _myFoy;
        private int AcariId;
        private TList<AV001_TI_BIL_BORCLU_ODEME> addNewList;
        private int BcariId;
        private bool kaydedildi;
        private AV001_TI_BIL_BORCLU_ODEME myOdeme;

        #endregion Fields

        #region Constructors

        public rFrmTarafOdeme()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += rFrmTarafOdeme_Load;
            this.FormClosing += rFrmTarafOdeme_FormClosing;
            this.FormClosed += rFrmTarafOdeme_FormClosed;
            c_lueDosya.EditValueChanged += c_lueDosya_EditValueChanged;
        }

        #endregion Constructors

        #region Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_BORCLU_ODEME> AddNewList
        {
            get { return addNewList; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    addNewList = value;
                    dataNavigatorExtended1.DataSource = value;
                    vGridControl1.DataSource = dataNavigatorExtended1.DataSource;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsModul
        {
            get { return _IsModul; }
            set
            {
                _IsModul = value;
                panelControl1.Visible = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return _myFoy; }
            set
            {
                _myFoy = value;
                if (value != null)
                {
                    if (AddNewList == null)
                        AddNewList = new TList<AV001_TI_BIL_BORCLU_ODEME>();
                    AddNewList.AddingNew += AV001_TI_BIL_BORCLU_ODEMECollection_AddingNew;

                    //MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection.AddingNew += new AddingNewEventHandler(AV001_TI_BIL_BORCLU_ODEMECollection_AddingNew);
                    dataNavigatorExtended1.DataSource = AddNewList;
                    vGridControl1.DataSource = dataNavigatorExtended1.DataSource;
                    gcOdeme.DataSource = dataNavigatorExtended1.DataSource;

                    TList<AV001_TI_BIL_FOY_TARAF> tb =
                        AdimAdimDavaKaydi.IcraTakipForms.ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy);
                    if (tb != null && tb.Count > 0)
                        BcariId = Convert.ToInt32(tb[0].CARI_ID);
                    TList<AV001_TI_BIL_FOY_TARAF> ta =
                        AdimAdimDavaKaydi.IcraTakipForms.ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy);
                    if (ta != null && ta.Count > 0)
                        AcariId = Convert.ToInt32(ta[0].CARI_ID);

                    BelgeUtil.Inits.AlacakNedenByFoy(value, gLueAlacakNeden);
                    BelgeUtil.Inits.OdemeBorcluTarafByFoy(value, new[] { rlueOdeyenCari, rLueBorcluAdinaOdeyen });
                    BelgeUtil.Inits.OdemeAlacakliTarafByFoy(value, new[] { rLueOdenenCari });

                    //BV 17 Haziran 2011 - Dosya No Görünmesi için
                    c_lueDosya.EditValue = _myFoy.ID;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY_TARAF_GELISME MyGelisme
        {
            get;
            set;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_BORCLU_ODEME MyOdeme
        {
            get { return myOdeme; }
            set
            {
                myOdeme = value;
                if (value != null)
                {
                    if (MyFoy != null)
                    {
                        var odeme = ucIcraTarafGelismeleri.TarafOdemeleriniGetir(MyFoy);
                        odeme.ColumnChanged += BOdeme_ColumnChanged; //Okan 18.08.2010
                        result.Add(odeme);
                        dataNavigatorExtended1.DataSource = result;
                    }
                    if (addNewList == null) addNewList = new TList<AV001_TI_BIL_BORCLU_ODEME>();
                    addNewList.Add(value);
                    vGridControl1.DataSource = dataNavigatorExtended1.DataSource;
                    gcOdeme.DataSource = dataNavigatorExtended1.DataSource;
                    result.AddingNew += AV001_TI_BIL_BORCLU_ODEMECollection_AddingNew;
                }
            }
        }

        #endregion Properties

        #region Methods

        public void Show(AV001_TI_BIL_FOY f)
        {
            MyFoy = f;

            this.Show();
        }

        public void Show(AV001_TI_BIL_BORCLU_ODEME odeme, AV001_TI_BIL_FOY foy)
        {
            MyOdeme = odeme;
            MyFoy = foy;
            this.Show();
        }

        private void AV001_TI_BIL_BORCLU_ODEMECollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_BORCLU_ODEME BOdeme = new AV001_TI_BIL_BORCLU_ODEME();
            BOdeme.ColumnChanged += new AV001_TI_BIL_BORCLU_ODEMEEventHandler(BOdeme_ColumnChanged);
            BOdeme.BURO_HESAP_SAHIBI_CARI_BANKA_ID = (int?)vGridControl1.GetCellValue(vGridControl1.GetRowByFieldName("BURO_HESAP_CARI_BANKA_ID"), 0);

            //BOdeme.BURO_HESAP_SAHIBI_CARI_ID=;
            BOdeme.MUHATAP_HESAP_SAHIBI_CARI_BANKA_ID = (int?)vGridControl1.GetCellValue(vGridControl1.GetRowByFieldName("MUHATAP_HESAP_CARI_BANKA_ID"), 0);

            //BOdeme.MUHATAP_HESAP_SAHIBI_CARI_ID=;
            BOdeme.EFT_REFERANS_NO = (string)vGridControl1.GetCellValue(vGridControl1.GetRowByFieldName("EFT_REFERANS_NO"), 0);
            BOdeme.BANKA_DEKONT_NO = (string)vGridControl1.GetCellValue(vGridControl1.GetRowByFieldName("BANKA_DEKONT_NO"), 0);
            BOdeme.KIYMETLI_EVRAKI_BILGILERI_ID = (int?)vGridControl1.GetCellValue(vGridControl1.GetRowByFieldName("KIYMETLI_EVRAKI_BILGILERI_ID"), 0);

            //BOdeme.KIYMETLI_EVRAK_VADESINDE_ODENDI_MI = (bool)vGridControl1.GetCellValue(vGridControl1.GetRowByFieldName("KIYMETLI_EVRAK_VADESINDE_ODENDI_MI"), 0);
            //BOdeme.BELGE_ID = (int?)vGridControl1.GetCellValue(vGridControl1.GetRowByFieldName("BELGE_ID"), 0);
            BOdeme.ODEYEN_CARI_ID = BcariId;
            BOdeme.BORCLU_ADINA_ODEYEN_CARI_ID = BcariId;
            BOdeme.ODENEN_CARI_ID = AcariId;
            BOdeme.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            BOdeme.KAYIT_TARIHI = DateTime.Now;
            BOdeme.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            BOdeme.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            BOdeme.KONTROL_NE_ZAMAN = DateTime.Now;
            BOdeme.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            BOdeme.ODEME_KIM_ADINA = 1;
            BOdeme.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            BOdeme.ODEME_TIP_ID = 1;
            BOdeme.ODEME_YER_ID = 3;
            BOdeme.ICRADAN_CEKILME_TARIHI = null;
            e.NewObject = BOdeme;
        }

        private void BOdeme_ColumnChanged(object sender, AV001_TI_BIL_BORCLU_ODEMEEventArgs e)
        {
            #region Föyün tekrar hesaplanmasını önlemek için yapıldı. Okan 18.08.2010

            if (MyFoy == null || MyFoy.EXTRA_LONG1 == 1) return;
            switch (e.Column)
            {
                case AV001_TI_BIL_BORCLU_ODEMEColumn.ODEME_MIKTAR:
                case AV001_TI_BIL_BORCLU_ODEMEColumn.ODEME_MIKTAR_DOVIZ:
                case AV001_TI_BIL_BORCLU_ODEMEColumn.ODEME_MIKTAR_DOVIZ_ID:
                case AV001_TI_BIL_BORCLU_ODEMEColumn.ODEME_MIKTAR_KUR:
                case AV001_TI_BIL_BORCLU_ODEMEColumn.TAAHHUTE_DAGILAN_TUTAR:
                case AV001_TI_BIL_BORCLU_ODEMEColumn.TAAHHUTE_DAGILAN_TUTAR_DOVIZ_ID:
                    MyFoy.EXTRA_LONG1 = 1;
                    break;

            #endregion Föyün tekrar hesaplanmasını önlemek için yapıldı. Okan 18.08.2010

                case AV001_TI_BIL_BORCLU_ODEMEColumn.ODEME_YER_ID:
                    {
                        var odeme = sender as AV001_TI_BIL_BORCLU_ODEME;
                        if ((int)e.Value != (int)AvukatProLib.Extras.OdemeYeri.İCRA_DAİRESİNE)
                        {
                            odeme.ICRADAN_CEKILME_TARIHI = null;
                            rowICRADAN_CEKILME_TARIHI.Visible = false;
                        }
                        else
                        {
                            odeme.ICRADAN_CEKILME_TARIHI = DateTime.Now.Date;
                            rowICRADAN_CEKILME_TARIHI.Visible = true;
                        }
                        break;
                    }
            }
        }

        private void c_lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            vGridControl1.Enabled = true;
            if (c_lueDosya.EditValue != null)
                MyFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)c_lueDosya.EditValue);

            if (MyFoy != null)
            {
                BelgeUtil.Inits.AlacakNedenByFoy(MyFoy, gLueAlacakNeden);
                BelgeUtil.Inits.OdemeBorcluTarafByFoy(MyFoy, new[] { rlueOdeyenCari, rLueBorcluAdinaOdeyen });
                BelgeUtil.Inits.OdemeAlacakliTarafByFoy(MyFoy, new[] { rLueOdenenCari });
                MyGelisme = MyFoy.AV001_TI_BIL_FOY_TARAF_GELISMECollection.AddNew();
            }
        }

        private bool CikabilirMi(TList<AV001_TI_BIL_BORCLU_ODEME> list)
        {
            if (list == null || list.Count < 1)
                return true;
            foreach (AV001_TI_BIL_BORCLU_ODEME odeme in list)
            {
                if (odeme.IsNew || odeme.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void dataNavigatorExtended1_OnCevirClick(object sender, EventArgs e)
        {
            if (vGridControl1.Visible)
            {
                gcOdeme.Visible = true;
                vGridControl1.Visible = false;
                gcOdeme.BringToFront();
                gcOdeme.BringToFront();
            }
            else if (gcOdeme.Visible)
            {
                vGridControl1.Visible = true;
                gcOdeme.Visible = false;
                vGridControl1.BringToFront();
                vGridControl1.BringToFront();
            }
        }

        private void GeriAl(TList<AV001_TI_BIL_BORCLU_ODEME> list)
        {
            try
            {
                if (list.DeletedItems.Count > 0)
                    list.AddRange(list.DeletedItems);
                TList<AV001_TI_BIL_BORCLU_ODEME> silincekler = new TList<AV001_TI_BIL_BORCLU_ODEME>();
                foreach (AV001_TI_BIL_BORCLU_ODEME odeme in list)
                {
                    if (odeme != null)
                    {
                        if (!odeme.IsNew && odeme.HasDataChanged())
                            odeme.CancelChanges();
                        if (odeme.IsNew)
                        {
                            silincekler.Add(odeme);
                        }
                    }
                }
                foreach (AV001_TI_BIL_BORCLU_ODEME odeme in silincekler)
                {
                    list.Remove(odeme);
                }
                silincekler = null;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += rFrmTarafOdeme_Button_Kaydet_Click;
        }

        private bool InputKontrol(TList<AV001_TI_BIL_BORCLU_ODEME> list)
        {
            List<string> temp = new List<string>();
            foreach (AV001_TI_BIL_BORCLU_ODEME var in list)
            {
                if (var.ODEME_MIKTAR == 0)
                {
                    temp.Add(var.ODEME_TARIHI.ToString());
                }
            }

            StringBuilder sb = null;
            if (temp.Count > 0)
            {
                sb = new StringBuilder();
                foreach (string str in temp)
                {
                    sb.Append("*" + str);
                    sb.AppendLine(System.Environment.NewLine);
                }
            }
            if (sb != null)
            {
                XtraMessageBox.Show(sb + "tarihli ödemenin/ödemelerin miktarı girilmemiş.");
                return false;
            }

            return true;
        }

        private decimal[] kdvStopajHesapla(Boolean kdvDahil, Boolean stopajDahil, decimal brutPara)
        {
            decimal[] kdvStopaj = new decimal[3];
            TDI_CET_KDV kdv = new TDI_CET_KDV();
            TDI_CET_DIGER_VERGI stopaj = new TDI_CET_DIGER_VERGI();

            var k = DataRepository.TDI_CET_KDVProvider.Find("KDV_AD='GENEL'");
            kdv = DataRepository.TDI_CET_KDVProvider.GetByKATEGORI_IDTARIH(k[0].KATEGORI_ID, k.Max(i => i.TARIH));
            var s = DataRepository.TDI_CET_DIGER_VERGIProvider.Find("VERGI_TUR='STOPAJ'");
            stopaj = DataRepository.TDI_CET_DIGER_VERGIProvider.GetByVERGI_TUR_IDTARIH(s[0].VERGI_TUR_ID, s.Max(i => i.TARIH));

            decimal kdvOran = (decimal)kdv.KDV_ORAN / 100;
            decimal stopajOran = (decimal)stopaj.VERGI_ORAN / 100;
            decimal brut = 0;
            decimal KDV = 0;
            decimal STOPAJ = 0;
            if (kdvDahil)
            {
                if (stopajDahil)//KDV ve STOPAJ Dahil-------
                {
                    brut = brutPara / (100 + (decimal)kdv.KDV_ORAN + (decimal)stopaj.VERGI_ORAN) * 100;
                    KDV = brut * kdvOran;
                    STOPAJ = brut * stopajOran;
                    kdvStopaj[0] = brut + KDV;
                    kdvStopaj[1] = KDV;
                    kdvStopaj[2] = STOPAJ;
                }
                else if (!stopajDahil)//KDV Dahil, STOPAJ Hariç
                {
                    brut = brutPara / (100 + (decimal)kdv.KDV_ORAN) * 100;
                    KDV = brut * kdvOran;
                    STOPAJ = brutPara * stopajOran;
                    kdvStopaj[0] = brut;
                    kdvStopaj[1] = KDV;
                    kdvStopaj[2] = STOPAJ;
                }
            }
            else if (!kdvDahil)
            {
                if (stopajDahil)//KDV Hariç, STOPAJ Dahil
                {
                    brut = brutPara / (100 + (decimal)stopaj.VERGI_ORAN) * 100;
                    STOPAJ = brut * stopajOran;
                    KDV = brut * kdvOran;
                    kdvStopaj[0] = brut + KDV;
                    kdvStopaj[1] = KDV;
                    kdvStopaj[2] = STOPAJ;
                }
                else if (!stopajDahil)//KDV ve STOPAJ Hariç
                {
                    KDV = brutPara * kdvOran;
                    STOPAJ = brutPara * stopajOran;
                    kdvStopaj[0] = brutPara;
                    kdvStopaj[1] = KDV;
                    kdvStopaj[2] = STOPAJ;
                }
            }
            return kdvStopaj;
        }

        private AV001_TDI_BIL_MASRAF_AVANS_DETAY masrafAvansDetayOlustur(ParaVeDovizId odeme, AV001_TI_BIL_BORCLU_ODEME borcluOdeme)
        {
            AV001_TDI_BIL_MASRAF_AVANS_DETAY detay = new AV001_TDI_BIL_MASRAF_AVANS_DETAY();
            Av001TiBilVekaletSozlesmeEntity sozlesme = AvukatPro.Services.Implementations.DosyaService.GetSozlesmeById((int)MyFoy.VEKALET_SOZLESME_ID);
            decimal[] kdvStopaj = kdvStopajHesapla(sozlesme.KdvDahil, sozlesme.StopajIcindeMi, odeme.Para);

            detay.ADET = 1;
            detay.BIRIM_FIYAT = odeme.Para;
            detay.BIRIM_FIYAT_DOVIZ_ID = odeme.DovizId;
            detay.BORC_ALACAK_ID = (int)BorcAlacak.Borc;
            detay.TOPLAM_TUTAR = odeme.Para;
            detay.KDV_DAHIL = sozlesme.KdvDahil;
            detay.STOPAJ_SSDF_DAHIL = sozlesme.StopajIcindeMi;

            detay.KDV_TUTAR = kdvStopaj[1];
            detay.STOPAJ_SSDF_TUTAR = kdvStopaj[2];
            detay.GENEL_TOPLAM = kdvStopaj[0];
            detay.GENEL_TOPLAM_DOVIZ_ID = odeme.DovizId;
            detay.HAREKET_ANA_KATEGORI_ID = 10;
            detay.KAYIT_TARIHI = DateTime.Now;
            detay.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            detay.KONTROL_NE_ZAMAN = DateTime.Now;
            detay.SEGMENT_ID = MyFoy.SEGMENT_ID;
            detay.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            detay.SUBE_KOD_ID = AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID;
            detay.MUVEKKIL_CARI_ID = borcluOdeme.ODENEN_CARI_ID;
            detay.ODEME_TIP_ID = borcluOdeme.ODEME_TIP_ID;
            detay.TARIH = borcluOdeme.ODEME_TARIHI;

            return detay;
        }

        private void rFrmTarafOdeme_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (InputKontrol(MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection))
            {
                if (Save())
                {
                    kaydedildi = true;
                    if (XtraMessageBox.Show("Ödeme makbuzu yazdırmak istermisiniz ? ", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        foreach (var item in MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
                        {
                            OdemeMakbuzu.OdemeMakbuzuGetir(item);
                        }
                    }
                    this.Close();
                }

                else
                {
                    XtraMessageBox.Show("Kayıt Esnasında Hata Oluştu." + Environment.NewLine + "Dosya Kaydedilemedi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void rFrmTarafOdeme_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MyGelisme == null)
                return;

            if (MyFoy != null)
                ucIcraTarafGelismeleri.OdemeTarihiHesapla(MyGelisme, MyFoy);
        }

        private void rFrmTarafOdeme_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MyFoy == null)
                return;

            if (kaydedildi) return;

            if (!CikabilirMi(AddNewList))
            {
                DialogResult dr =
                    XtraMessageBox.Show("Yapılan değişiklikler kaydedilmedi.Çıkmak istediğinizden emin misiniz ?",
                                        "Vazgeç", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    GeriAl(AddNewList);
                }
                else
                    e.Cancel = true;
            }
        }

        private void rFrmTarafOdeme_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                BelgeUtil.Inits.OdemeTipiGetir(rlueOdemeTipi);
                BelgeUtil.Inits.OdemeYeriGetir(rLueOdemeYeri);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
                BelgeUtil.Inits.ParaBicimiAyarla(rLueMiktar);

                //BelgeUtil.Inits.AlacakNedenKodGetir(rLueAlacakNedenKod);
                BelgeUtil.Inits.OdemeDagilimGetir(rLueOdemeKimAdina);

                if (IsModul)
                {
                    BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliyeId);
                    BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliNoId);
                    AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, AvukatProLib.Extras.Modul.Icra, false);

                    //c_lueDosya.Properties.NullText = "Bir İcra Dosyası Seçiniz...";
                    //c_lueDosya.Enter += delegate { BelgeUtil.Inits.DosyaDoldur(AvukatProLib.Extras.ModulTip.Icra.ToString(), c_lueDosya); };
                }

                //var personelIDleri = DataRepository.AV001_TDI_BIL_CARIProvider.GetAll().FindAll(c => c.PERSONEL_MI == true).Select(c => c.ID);
                //TList<AV001_TDI_BIL_CARI_BANKA> personelHesap = new TList<AV001_TDI_BIL_CARI_BANKA>();
                //TList<AV001_TDI_BIL_CARI_BANKA> tümHesap = DataRepository.AV001_TDI_BIL_CARI_BANKAProvider.GetAll();

                //foreach (var id in personelIDleri)
                //{
                //    personelHesap.AddRange(DataRepository.AV001_TDI_BIL_CARI_BANKAProvider.GetByCARI_ID(id));
                //}
                AvukatPro.Services.Implementations.DevExpressService.KasaHesapBilgileriDoldur(rlueKasaHesap);
                AvukatPro.Services.Implementations.DevExpressService.MuhatapHesapBilgilerirDoldur(rlueMuhatapHesap);
                AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(rlueBelge);
                AvukatPro.Services.Implementations.DevExpressService.KiymetliEvrakDoldur(rlueKiymetliEvrak);
            }
        }

        private bool Save()
        {
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                trans.BeginTransaction();

                DataRepository.AV001_TI_BIL_FOYProvider.Save(trans, MyFoy); // Okan 18.08.2010

                foreach (AV001_TI_BIL_BORCLU_ODEME item in AddNewList)
                {
                    if (item.ODEME_YER_ID == (int)AvukatProLib.Extras.OdemeYeri.AVUKATA ||
                        item.ODEME_YER_ID == (int)AvukatProLib.Extras.OdemeYeri.İCRA_DAİRESİNE ||
                        item.ODEME_YER_ID == (int)AvukatProLib.Extras.OdemeYeri.SATIŞTAN ||
                        item.ODEME_YER_ID == (int)AvukatProLib.Extras.OdemeYeri.BANKA_HESABINA)
                        item.BORCLU_ADINA_ODENEN_CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
                    else
                        item.BORCLU_ADINA_ODENEN_CARI_ID = item.ODENEN_CARI_ID;

                    item.BORCLU_ADINA_ODEYEN_CARI_ID = item.ODEYEN_CARI_ID;
                    item.ICRA_FOY_ID = MyFoy.ID;

                    item.ALACAK_NEDEN_ID = null; //Kayıtta alacak nedeni seçtirilecek ama kaydı yaptırılmayacak. MB
                }

                foreach (var item in MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
                {
                    if (MyFoy != null)
                    {
                        foreach (var dagilim in item.AV001_TI_BIL_ODEME_DAGILIMCollection)
                        {
                            dagilim.ODEME_ID = item.ID;
                            MyFoy.AV001_TI_BIL_ODEME_DAGILIMCollection.Add(dagilim);
                        }
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(trans, MyFoy, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));
                    }
                }

                #region Sözleşme Ücreti Kesintisi Yap

                Av001TiBilVekaletSozlesmeEntity sozlesme = AvukatPro.Services.Implementations.DosyaService.GetSozlesmeById((int)MyFoy.VEKALET_SOZLESME_ID);
                if (sozlesme.OdemelerdenOransalKesilsin == true && sozlesme.KesintiOrani != null)
                    if (sozlesme.KesintiOrani > 0)
                        AddNewList[0] = VekaletBorcuOde(AddNewList[0], (double)sozlesme.KesintiOrani, trans);

                #endregion Sözleşme Ücreti Kesintisi Yap

                DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepSave(trans, AddNewList, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));
                trans.Commit();

                #region Foy muhasebe üretimi kapatıldı

                //foreach (var borcluOdeme in AddNewList)
                //    MuhasebeAraclari.SetMuhasebeVeDetayByIcraBorcluOdeme(borcluOdeme.ID);

                #endregion Foy muhasebe üretimi kapatıldı

                Forms.frmKlasorYeni.OdemelerYuklendi = false; //Ödeme kaydından sonra klasörde tüm ödemelerin refresh olması için eklendi. MB

                foreach (var mahsup in AddNewList)
                {
                    if (MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection.Exists(delegate(AV001_TI_BIL_BORCLU_ODEME pol) { return pol.ID == mahsup.ID; }))
                        continue;
                    MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection.AddRange(AddNewList);
                }

                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 || MyFoy.AV001_TI_BIL_FOY_TARAFCollection == null)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));

                #region Cari hesap üretimi açıldı!

                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection != null)
                {
                    foreach (var item in MyFoy.AV001_TI_BIL_FOY_TARAFCollection)
                    {
                        if (item.TAKIP_EDEN_MI && item.TARAF_KODU == (int)AvukatProLib.Extras.TarafKodu.Muvekkil)
                        {
                            foreach (var odeme in MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
                            {
                                if (odeme.ODEME_YER_ID == (int)AvukatProLib.Extras.OdemeYeri.AVUKATA || odeme.ODEME_YER_ID == (int)AvukatProLib.Extras.OdemeYeri.İCRA_DAİRESİNE || odeme.ODEME_YER_ID == (int)AvukatProLib.Extras.OdemeYeri.SATIŞTAN || odeme.ODEME_YER_ID == (int)AvukatProLib.Extras.OdemeYeri.BANKA_HESABINA)
                                    MuhasebeAraclari.SetCariHesapByBorcluOdeme(odeme.ID);
                            }
                        }
                    }
                }

                #endregion Cari hesap üretimi açıldı!

                ucIcraTarafGelismeleri.GelismeIslemleri(MyFoy);

                #region Masraf Avans üretimi kapatıldı !

                //TList<AV001_TDI_BIL_MASRAF_AVANS> masrafAvansListesi = new TList<AV001_TDI_BIL_MASRAF_AVANS>();
                //foreach (var odeme in MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
                //{
                //    //Ödeme yeri avukata , bankaya , icraya ise kayıt üretilecek
                //    if (odeme.ODEME_YER_ID == (int)OdemeYeri.AVUKATA
                //        || odeme.ODEME_YER_ID == (int)OdemeYeri.BANKA_HESABINA
                //        || odeme.ODEME_YER_ID == (int)OdemeYeri.İCRA_DAİRESİNE
                //        || odeme.ODEME_YER_ID == (int)OdemeYeri.SATIŞTAN)
                //    {
                //        AV001_TDI_BIL_MASRAF_AVANS ma = new AV001_TDI_BIL_MASRAF_AVANS();
                //        // Masraf Avansın alanları mevcut bilgilerden doldurulacak
                //        ma.CARI_ID = odeme.ODENEN_CARI_ID;
                //        ma.ICRA_FOY_ID = MyFoy.ID;
                //        //ma.ICRA_FOY_NO = MyFoy.FOY_NO; //Alanın Tipi Değiştirilecek
                //        ma.MANUEL_KAYIT_MI = false;
                //        ma.MASRAF_AVANS_TIP = (int)MasrafAvansTip.Masraf;

                //        ma.ACIKLAMA = String.Format("{0} Tarihinde {1} tarafından ödenen paranın karşılığı üretilmiştir", odeme.ODEME_TARIHI, Inits.CariIsmiGetir(odeme.ODEYEN_CARI_ID)); //Açıklama Üretilecek, şu tarihte borçlu tarafından ödenen paranın karşılığı üretilmiştir
                //        ma.BORCLU_CARI_ID = odeme.ODEYEN_CARI_ID;
                //        ma.CARI_HESAP_HEDEF_TIP = (int)Modul.Icra; // icra

                //        var maDetay = ma.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.AddNew();
                //        //detay ın bilgileri mevcut ödemeden doldurulacak
                //        //odeme yi borçlu yapıyorsa bu durumdan avukat (borçlu) Müvekkil (Alacaklı)

                //        maDetay.ACIKLAMA = ma.ACIKLAMA;  // Açıklama Üretilecek,
                //        maDetay.ADET = 1;
                //        maDetay.BIRIM_FIYAT = odeme.ODEME_MIKTAR ?? 0;
                //        maDetay.BIRIM_FIYAT_DOVIZ_ID = odeme.ODEME_MIKTAR_DOVIZ_ID;
                //        maDetay.TOPLAM_TUTAR = odeme.ODEME_MIKTAR ?? 0;
                //        maDetay.TOPLAM_TUTAR_DOVIZ_ID = odeme.ODEME_MIKTAR_DOVIZ_ID ?? 1;
                //        maDetay.GENEL_TOPLAM = odeme.ODEME_MIKTAR ?? 0;
                //        maDetay.GENEL_TOPLAM_DOVIZ_ID = odeme.ODEME_MIKTAR_DOVIZ_ID ?? 1;

                //        maDetay.BORC_ALACAK_ID = (int)BorcAlacak.Alacak;  //Testpit Edilecek, -- Alacak

                //        maDetay.HAREKET_ANA_KATEGORI_ID = (int)HareketAnaKategori.Odeme;
                //        maDetay.HAREKET_ALT_KATEGORI_ID = (int)HareketAltKategori.BorcluOdemesi;

                //        ///Katman Üzerinden verildiği Düşünülüyor
                //        //maDetay.MA_ICRA_FOY_ID = MyFoy.ID;
                //        //maDetay.MA_REFERANS_NO = ma.REFERANS_NO;

                //        //maDetay.MUVEKKIL_CARI_ID =  ma.CARI_ID; //Dosyanın Müvekkillerine
                //        maDetay.ODEME_TIP_ID = odeme.ODEME_TIP_ID;
                //        maDetay.ONAY_DURUM = 1;
                //        maDetay.ONAY_NO = "1";
                //        maDetay.ONAY_TARIHI = odeme.ODEME_TARIHI;
                //        maDetay.Onaylandi = true;
                //        maDetay.MuhasebelestirilecekMi = true;
                //        maDetay.TARIH = DateTime.Now;
                //        maDetay.TUM_MUVEKKILLERE_PAYLASTIR = true;
                //        maDetay.INCELENDI = true;

                //        masrafAvansListesi.Add(ma);
                //    }
                //}
                //if (masrafAvansListesi.Count > 0)
                //{
                //    trans.BeginTransaction();
                //    try
                //    {
                //        AV001_TDI_BIL_MASRAF_AVANS_DETAY ma;
                //        DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(trans, MyFoy, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_ODEME>));
                //        DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepSave(trans, masrafAvansListesi);
                //        trans.Commit();
                //    }
                //    catch (Exception ex)
                //    {
                //        if (trans.IsOpen)
                //            trans.Rollback();

                //        BelgeUtil.ErrorHandler.Catch(this, ex);
                //    }
                //    //foreach (var ma in masrafAvansListesi)
                //    //{
                //    //    MuhasebeHelper.MasrafAvansToKasa(ma);
                //    //}
                //}

                #endregion Masraf Avans üretimi kapatıldı !
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);

                return false;
            }

            return true;
        }

        private AV001_TI_BIL_BORCLU_ODEME VekaletBorcuOde(AV001_TI_BIL_BORCLU_ODEME odeme, double oran, TransactionManager tr)
        {
            AV001_TDI_BIL_MASRAF_AVANS masraf = new AV001_TDI_BIL_MASRAF_AVANS();

            masraf.ACIKLAMA = "Vekalet ücreti sözleşmesi gereği %" + oran.ToString("N") + "oranında kesilen vekalet ücreti kesintintisidir.";
            masraf.BORCLU_CARI_ID = odeme.ODEYEN_CARI_ID;
            masraf.CARI_HESAP_HEDEF_TIP = (int)Modul.Icra;
            masraf.CARI_ID = odeme.ODENEN_CARI_ID;
            masraf.ICRA_FOY_ID = MyFoy.ID;
            masraf.KAYIT_TARIHI = DateTime.Now;
            masraf.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            masraf.KONTROL_NE_ZAMAN = DateTime.Now;
            masraf.MANUEL_KAYIT_MI = false;
            masraf.MASRAF_AVANS_TIP = (int)MasrafAvansTip.Avans;
            masraf.REFERANS_NO = "BÖA-" + Guid.NewGuid().ToString().Substring(0, 5);
            masraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            masraf.SUBE_KOD_ID = AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID;

            ParaVeDovizId sozlesmeBorcu = AvukatPro.Services.Implementations.CariService.SozlesmeVekaletUcretiBorcu(MyFoy.ID);
            ParaVeDovizId takipBorcu = AvukatPro.Services.Implementations.CariService.TakipVekaletUcretiBorcu(MyFoy.ID);

            ParaVeDovizId toplamKesinti = new ParaVeDovizId();

            toplamKesinti.Para = ((decimal)odeme.ODEME_MIKTAR * (decimal)oran) / 100;
            toplamKesinti.DovizId = (int)odeme.ODEME_MIKTAR_DOVIZ_ID;

            ParaVeDovizId sozlesmeKesintisi = new ParaVeDovizId { Para = toplamKesinti.Para / 2, DovizId = toplamKesinti.DovizId };
            ParaVeDovizId takipKesintisi = new ParaVeDovizId { Para = toplamKesinti.Para / 2, DovizId = toplamKesinti.DovizId };

            #region Sozleşme vekalet ücreti kesintisi

            //sözleşme kesintisi borcdan azsa
            if (sozlesmeKesintisi.Para <= sozlesmeBorcu.Para && sozlesmeBorcu.Para > 0)
            {
                AV001_TDI_BIL_MASRAF_AVANS_DETAY sozlesmeAvansi = masrafAvansDetayOlustur(sozlesmeKesintisi, odeme);
                sozlesmeAvansi.HAREKET_ALT_KATEGORI_ID = 40;
                sozlesmeAvansi.ACIKLAMA = "Vekalet ücreti sözleşmesi gereği kesilen sözleşme vekalet ücreti avansıdır.";
                sozlesmeAvansi.ICRA_ODEME_ID = odeme.ID;
                masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(sozlesmeAvansi);
            }

            else if (sozlesmeBorcu.Para > 0)
            {
                AV001_TDI_BIL_MASRAF_AVANS_DETAY sozlesmeAvansi = masrafAvansDetayOlustur(sozlesmeBorcu, odeme);
                sozlesmeAvansi.HAREKET_ALT_KATEGORI_ID = 40;
                sozlesmeAvansi.ACIKLAMA = "Vekalet ücreti sözleşmesi gereği kesilen sözleşme vekalet ücreti avansıdır.";
                sozlesmeAvansi.ICRA_ODEME_ID = odeme.ID;
                masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(sozlesmeAvansi);

                takipKesintisi.Para += (sozlesmeKesintisi.Para - sozlesmeBorcu.Para);
            }

            else
            {
                takipKesintisi.Para = toplamKesinti.Para;
            }

            #endregion Sozleşme vekalet ücreti kesintisi

            #region Takip Vekalet Ücreti Kesintisi

            //takip kesintisi borcdan azsa
            if (takipKesintisi.Para <= takipBorcu.Para && takipBorcu.Para > 0)
            {
                AV001_TDI_BIL_MASRAF_AVANS_DETAY takipAvansi = masrafAvansDetayOlustur(takipKesintisi, odeme);
                takipAvansi.HAREKET_ALT_KATEGORI_ID = 942;
                takipAvansi.ACIKLAMA = "Vekalet ücreti sözleşmesi gereği kesilen takip vekalet ücreti avansıdır.";
                takipAvansi.ICRA_ODEME_ID = odeme.ID;
                masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(takipAvansi);
                odeme.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(takipAvansi);
            }

            else if (takipBorcu.Para > 0)
            {
                AV001_TDI_BIL_MASRAF_AVANS_DETAY takipAvansi = masrafAvansDetayOlustur(takipBorcu, odeme);
                takipAvansi.HAREKET_ALT_KATEGORI_ID = 942;
                takipAvansi.ACIKLAMA = "Vekalet ücreti sözleşmesi gereği kesilen takip vekalet ücreti avansıdır.";
                takipAvansi.ICRA_ODEME_ID = odeme.ID;
                masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(takipAvansi);
                odeme.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(takipAvansi);

                takipKesintisi = takipBorcu;
            }

            #endregion Takip Vekalet Ücreti Kesintisi

            if (masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Count > 0)
            {
                if (XtraMessageBox.Show("Odeme kaydınızdan sözleşme gereği " + masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Select(d => d.GENEL_TOPLAM).Sum().ToString("N") + " " + AvukatPro.Services.Implementations.DosyaService.DovizTipiById(masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[0].GENEL_TOPLAM_DOVIZ_ID) + " vekalet ücreti avansları oluşturulacaktır.\n Oluşturmak için Evet'e tıklayınız, masraf oluşturmadan ödemeyi kaydetmek için Hayır'a tıklayınız,\nişlemi iptal etmek için İptal'e tıklayınız.", "Bilgi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepSave(tr, masraf, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));
                }
            }

            return odeme;
        }

        #endregion Methods

        private void rlueBelge_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "ekle")
            {
                frmBelgeKayitUfak frmblg = new frmBelgeKayitUfak();
                frmblg.ShowDialog();
                AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(rlueBelge);
            }
        }
    }
}