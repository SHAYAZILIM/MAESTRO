using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Muhasebe;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatPro.Model.EntityClasses;
using AvukatPro.Services.Messaging;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System.Data;

namespace AdimAdimDavaKaydi.Sozlesme.Forms.Sozlesme.Util
{
    public partial class ucSozlesmeGridler : AvpXUserControl
    {
        #region Fields

        private AvukatProLib.Arama.AvpDataContext context =
            new AvukatProLib.Arama.AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

        private AV001_TDI_BIL_SOZLESME mySozlesme;

        #endregion Fields

        #region Constructors

        public ucSozlesmeGridler()
        {
            //if (DesignMode)
            InitializeComponent();

            this.Load += ucSozlesmeGridler_Load;
        }

        #endregion Constructors

        #region Properties

        [Browsable(false)]
        public AV001_TDI_BIL_SOZLESME MySozlesme
        {
            get { return mySozlesme; }
            set
            {
                mySozlesme = value;
                if (ucbelgetakip1 != null)
                    this.ucbelgetakip1.CurrentRecord = this.mySozlesme;
                if (value != null && this.DesignMode == false)
                {
                    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(MySozlesme, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_OZEL_KOD>));
                    this.DataDegisitir(value);
                }
            }
        }

        #endregion Properties

        #region Methods

        private void BindOzelKod()
        {
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod_1, 1, Modul.Sozlesme);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod_2, 2, Modul.Sozlesme);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod_3, 3, Modul.Sozlesme);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod_4, 4, Modul.Sozlesme);
        }

        private void DataBinding(AV001_TDI_BIL_SOZLESME MySozlesme)
        {
            if (MySozlesme.AV001_TDI_BIL_SOZLESME_OZEL_KODCollection.Count == 0)
                MySozlesme.AV001_TDI_BIL_SOZLESME_OZEL_KODCollection.AddNew();

            lueBanka.DataBindings.Clear();
            lueBanka.DataBindings.Add("EditValue", MySozlesme.AV001_TDI_BIL_SOZLESME_OZEL_KODCollection, "BANKA_ID",
                                      true);

            lueSube.DataBindings.Clear();
            lueSube.DataBindings.Add("EditValue", MySozlesme.AV001_TDI_BIL_SOZLESME_OZEL_KODCollection, "SUBE_ID", true);

            lueFoyYeri.DataBindings.Clear();
            lueFoyYeri.DataBindings.Add("EditValue", MySozlesme.AV001_TDI_BIL_SOZLESME_OZEL_KODCollection, "FOY_YERI_ID",
                                        true);

            lueFoyBirim.DataBindings.Clear();
            lueFoyBirim.DataBindings.Add("EditValue", MySozlesme.AV001_TDI_BIL_SOZLESME_OZEL_KODCollection,
                                         "FOY_BIRIM_ID", true);

            lueFoyOzelDurum.DataBindings.Clear();
            lueFoyOzelDurum.DataBindings.Add("EditValue", MySozlesme.AV001_TDI_BIL_SOZLESME_OZEL_KODCollection,
                                             "FOY_OZEL_DURUM_ID", true);

            txtAciklama.DataBindings.Clear();
            txtAciklama.DataBindings.Add("TEXT", MySozlesme.AV001_TDI_BIL_SOZLESME_OZEL_KODCollection, "ACIKLAMA", true);

            lueKrediGrup.DataBindings.Clear();
            lueKrediGrup.DataBindings.Add("EditValue", MySozlesme.AV001_TDI_BIL_SOZLESME_OZEL_KODCollection,
                                          "KREDI_GRUP_ID", true);

            lueKrediTip.DataBindings.Clear();
            lueKrediTip.DataBindings.Add("EditValue", MySozlesme.AV001_TDI_BIL_SOZLESME_OZEL_KODCollection,
                                         "KREDI_TIP_ID", true);

            lueTahsilat.DataBindings.Clear();
            lueTahsilat.DataBindings.Add("EditValue", MySozlesme.AV001_TDI_BIL_SOZLESME_OZEL_KODCollection,
                                         "TAHSILAT_DURUM_ID", true);

            textEdit2.DataBindings.Clear();
            textEdit2.DataBindings.Add("TEXT", MySozlesme.AV001_TDI_BIL_SOZLESME_OZEL_KODCollection, "KLASOR_1", true);

            textEdit3.DataBindings.Clear();
            textEdit3.DataBindings.Add("TEXT", MySozlesme.AV001_TDI_BIL_SOZLESME_OZEL_KODCollection, "KLASOR_2", true);

            //lueOzelKod_1.DataBindings.Clear();
            //lueOzelKod_1.DataBindings.Add("EditValue", MySozlesme, "OZEL_KOD1_ID", true);

            //lueOzelKod_2.DataBindings.Clear();
            //lueOzelKod_2.DataBindings.Add("EditValue", MySozlesme, "OZEL_KOD2_ID", true);

            //lueOzelKod_3.DataBindings.Clear();
            //lueOzelKod_3.DataBindings.Add("EditValue", MySozlesme, "OZEL_KOD3_ID", true);

            //lueOzelKod_4.DataBindings.Clear();
            //lueOzelKod_4.DataBindings.Add("EditValue", MySozlesme, "OZEL_KOD4_ID", true);
        }

        private void DataDegisitir(AV001_TDI_BIL_SOZLESME sozlesme)
        {
            try
            {
                this.Enabled = false;
                TList<AV001_TDI_BIL_KIYMETLI_EVRAK> kiymet = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
                TList<AV001_TDI_BIL_IS> IsSozList = new TList<AV001_TDI_BIL_IS>();
                AV001_TDI_BIL_IS IsSoz = new AV001_TDI_BIL_IS();
                IsSoz.STAMP = 0;
                TList<AV001_TI_BIL_GAYRIMENKUL> gayri = new TList<AV001_TI_BIL_GAYRIMENKUL>();
                TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> arac = new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>();

                BackgroundWorker bckWorker = new BackgroundWorker();
                bckWorker.DoWork += delegate
                                        {
                                            DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(sozlesme, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_DETAY>), typeof(TList<AV001_TDI_BIL_SOZLESME_HUKUM>), typeof(TList<AV001_TDI_BIL_SOZLESME>), typeof(TList<NN_IS_SOZLESME>), typeof(TList<AV001_TDI_BIL_IS>), typeof(TList<NN_SOZLESME_SOZLESME>), typeof(TList<AV001_TDIE_BIL_ASAMA>), typeof(TList<AV001_TDI_BIL_SOZLESME_GELISME_ADIM>), typeof(TList<NN_SOZLESME_GORUSME>),

                                                //typeof(TList<AV001_TS_BIL_SOZLESME_URUN_BILGILERI>),
                                                typeof(TList<NN_BELGE_SOZLESME>), typeof(TList<AV001_TI_BIL_GAYRIMENKUL>), typeof(TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>), typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>), typeof(TList<NN_SOZLESME_SOZLESME>), typeof(TList<AV001_TDI_BIL_IS_SOZLESME>), typeof(TList<NN_SOZLESME_GAYRIMENKUL>), typeof(TList<NN_SOZLESME_GEMI_UCAK_ARAC>), typeof(TList<NN_SOZLESME_KIYMETLI_EVRAK>), typeof(TList<AV001_TDI_BIL_SOZLESME_OZEL_KOD>), typeof(TList<AV001_TDIE_BIL_BELGE>), typeof(TList<AV001_TDI_BIL_FOY_MUHASEBE>), typeof(TList<TDI_BIL_BORCLU_MAL>));

                                            //****Bu Kýsým Eksik Gerekli deðiþiklikler yapýldýktan sonra devam edilecek
                                            //(srmn)
                                            //IlýskýDetay burada view hazirlanacak Canan
                                            //for (int i = 0; i < sozlesme.NN_SOZLESME_KIYMETLI_EVRAKCollection.Count; i++)
                                            //    kiymet.Add(DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByID(sozlesme.NN_SOZLESME_KIYMETLI_EVRAKCollection[i].KIYMETLI_EVRAK_ID));

                                            //foreach (NN_IS_SOZLESME var in sozlesme.NN_IS_SOZLESMECollection)
                                            //{
                                            //    IsSoz = DataRepository.AV001_TDI_BIL_ISProvider.GetByID(var.IS_ID);
                                            //    IsSozList.Add(IsSoz);
                                            //}

                                            //for (int i = 0; i < sozlesme.NN_SOZLESME_GAYRIMENKULCollection.Count; i++)
                                            //    gayri.Add(DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.GetByID(sozlesme.NN_SOZLESME_GAYRIMENKULCollection[i].GAYRIMENKUL_ID));

                                            //for (int i = 0; i < sozlesme.NN_SOZLESME_GEMI_UCAK_ARACCollection.Count; i++)
                                            //    arac.Add(DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.GetByID(sozlesme.NN_SOZLESME_GEMI_UCAK_ARACCollection[i].GEMI_UCAK_ARAC_ID));
                                        };
                bckWorker.RunWorkerCompleted += delegate
                                                    {
                                                        this.Enabled = true;

                                                        //SozlesmeDetaylari
                                                        if (ucSozlesmeDetaylari1 == null)
                                                            CreateUcSozlesmeDetaylari1();
                                                        ucSozlesmeDetaylari1.MyDataSource =
                                                            sozlesme.AV001_TDI_BIL_SOZLESME_DETAYCollection;
                                                        ucSozlesmeDetaylari1.MySozlesme = this.MySozlesme;

                                                        //SozlesmeMaddeleri
                                                        if (ucSozlesmeHukum1 == null)
                                                            CreateUcSozlesmeHukum1();
                                                        ucSozlesmeHukum1.MyDataSource =
                                                            sozlesme.AV001_TDI_BIL_SOZLESME_HUKUMCollection;

                                                        // borçlu mal bilgileri
                                                        if (ucBorcluMalBilgileri1 == null)
                                                            CreateUcBorcluMalBilgileri();
                                                        ucBorcluMalBilgileri1.MySozlesme = sozlesme;

                                                        //YapýlacakIsler
                                                        if (ucGorevGrid1 == null)
                                                            CreateUcGorevGrid1();
                                                        ucGorevGrid1.SelectedRecord = MySozlesme;
                                                        ucGorevGrid1.SelectedRecordId = MySozlesme.ID;
                                                        ucGorevGrid1.MyDataSource =
                                                            sozlesme.AV001_TDI_BIL_ISCollection_From_NN_IS_SOZLESME;

                                                        //Dokumanlar
                                                        // sozlesmesinde yeni forum yapýlacak solution  ele geçirilince canan

                                                        //sozlesme.NN_S
                                                        //****Bu Kýsým Eksik Gerekli deðiþiklikler yapýldýktan sonra devam edilecek
                                                        //(srmn)
                                                        if (ucSozlesmeGrid1 == null)
                                                            CreateUcSozlesmeGrid1();
                                                        ucSozlesmeGrid1.MyDataSource =
                                                            sozlesme.
                                                                AV001_TDI_BIL_SOZLESMECollection_From_NN_SOZLESME_SOZLESMESOZLESME_IDFromNN_SOZLESME_SOZLESME;
                                                        ucSozlesmeGrid1.AnaSozlesmeID = sozlesme.ID;

                                                        //SozlesmeHaritasi
                                                        if (ucSozlesmeAsamalari1 == null)
                                                            CreateUcSozlesmeAsamalari1();
                                                        ucSozlesmeAsamalari1.MyDataSource =
                                                            sozlesme.AV001_TDIE_BIL_ASAMACollection;

                                                        //GeliþmeAdýmlarý
                                                        if (ucSozlesmeGelismeAdimlari1 == null)
                                                            CreateUcSozlesmeGelismeAdimlari1();
                                                        ucSozlesmeGelismeAdimlari1.MySozlesme = sozlesme;
                                                        ucSozlesmeGelismeAdimlari1.MyDataSource =
                                                            sozlesme.AV001_TDI_BIL_SOZLESME_GELISME_ADIMCollection;

                                                        //Iletiþim
                                                        if (ucGorusmeler1 == null)
                                                            CreateUcGorusmeler1();
                                                        ucGorusmeler1.MySozlesme = sozlesme;
                                                        ucGorusmeler1.MyDataSource =
                                                            sozlesme.
                                                                AV001_TDI_BIL_GORUSMECollection_From_NN_GORUSME_SOZLESME;

                                                        //**Sözleþmede sms olacak mý?
                                                        //ucDavaSMS1.MyDataSource=sozlesme.

                                                        //  ucEPosta1.MyDataSource = sozlesme.AV001_TDIE_BIL_MESAJCollection_From_NN_MESAJ_SOZLESME;
                                                        if (ucSozlesmeIliskiliDosyalar1 == null)
                                                            CreateUcSozlesmeIliskiliDosyalar1();

                                                        //tebligat yeni Bir tane user kontrol Yapýlabilir
                                                        if (ucTebligat1 == null)
                                                            CreateUcTebligat1();
                                                        ucTebligat1.MySozlesmeFoy = sozlesme;

                                                        //UrunBilgileri
                                                        if (ucUrunBilgileri1 == null)
                                                            CreateUcUrunBilgileri1();
                                                        ucUrunBilgileri1.MyDataSource =
                                                            sozlesme.AV001_TS_BIL_SOZLESME_URUN_BILGILERICollection_From_NN_SOZLESME_URUN_SOZLESME;
                                                        if (ucbelgetakip1 == null)
                                                            CreateUcBelgeTakip1();
                                                        ucbelgetakip1.TableName = "AV001_TDI_BIL_SOZLESME";
                                                        ucbelgetakip1.IdValue = sozlesme.ID;
                                                        ucbelgetakip1.CurrentRecord = sozlesme;
                                                        ucbelgetakip1.MyDataSource = BelgeUtil.Inits.BelgeGetirBySozlesmeId(sozlesme.ID);

                                                        //ucYapilcakIsSozlesme1.MyDataSource = IsSozList;
                                                        if (ucMeslekMakbuzu1 == null)
                                                            CreateUcMeslekMakbuzu1();
                                                        ucMeslekMakbuzu1.MySozlesme = MySozlesme;
                                                        ucMeslekMakbuzu1.MyDataSource = AvukatPro.Services.Implementations.DosyaService.GetAllFaturaByFoy(MySozlesme.ID, Modul.Sozlesme);

                                                        //ucMeslekMakbuzu1.MyDataSource =
                                                        //    sozlesme.AV001_TDI_BIL_FATURACollection;

                                                        //ucMuhasebeBilgileri1.MySozlesme = sozlesme;
                                                        //ucMuhasebeBilgileri1.MyDataSource = sozlesme.AV001_TDI_BIL_FOY_MUHASEBECollection;
                                                        //Prosedür atanacak sonra Ýliþkili dosyalar Atanacak
                                                        // Gayrimenkul
                                                        if (ucGayrimenkulGiris1 == null)
                                                            CreateUcGayrimenkulGiris1();
                                                        ucGayrimenkulGiris1.MySozlesme = sozlesme;

                                                        //ucGayrimenkulGiris1.MyDataSource =
                                                        //    sozlesme.
                                                        //        AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL;
                                                        //GemiuçakArc
                                                        if (ucUcakGemiArac1 == null)
                                                            CreateUcUcakGemiArac();
                                                        ucUcakGemiArac1.KayitEkranindanMi = false;
                                                        ucUcakGemiArac1.MyDataSource = BelgeUtil.Inits.GemiUcakAracGetirBySozlesmeFoyId(sozlesme.ID);

                                                        //GemiuçakArc
                                                        if (ucKiymetliEvrakGiris1 == null)
                                                            CreateUcKiymetliEvrakGiris1();
                                                        ucKiymetliEvrakGiris1.MySozlesme = sozlesme;
                                                        ucKiymetliEvrakGiris1.MyDataSource =
                                                            sozlesme.
                                                                AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_SOZLESME_KIYMETLI_EVRAK;

                                                        //Masraf Avans
                                                        if (ucMasrafAvans1 == null)
                                                            CreateUcMasrafAvans1();
                                                        ucMasrafAvans1.MySozlesmeFoy = sozlesme;

                                                        //Müvekkil Muhasebesi
                                                        if (AvukatProLib.Kimlik.Bilgi.CARI_ID.HasValue)
                                                        {
                                                            bool muvekkil =
                                                                AvukatProLib.Arama.R_CARI_HESAP_MUVEKKIL.
                                                                    KullaniciMuvekkilMi(
                                                                        AvukatProLib.Kimlik.SirketBilgisi.ConStr,
                                                                        AvukatProLib.Kimlik.Bilgi.CARI_ID.Value);
                                                            if (muvekkil)
                                                            {
                                                                if (
                                                                    MySozlesme.AV001_TDI_BIL_CARI_HESAP_DETAYCollection.
                                                                        Count == 0)
                                                                    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.
                                                                        DeepLoad(MySozlesme, false,
                                                                                 DeepLoadType.IncludeChildren,
                                                                                 typeof(
                                                                                     TList
                                                                                     <AV001_TDI_BIL_CARI_HESAP_DETAY>));

                                                                TList<AV001_TDI_BIL_CARI_HESAP_DETAY> cariHesapDetaylari
                                                                    =
                                                                    MySozlesme.AV001_TDI_BIL_CARI_HESAP_DETAYCollection;
                                                                List<AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY>
                                                                    kullaniciHesaplar =
                                                                        context.AV001_TDI_BIL_CARI_HESAP_DETAYs.Where(
                                                                            vi =>
                                                                            vi.KONTROL_KIM_ID ==
                                                                            AvukatProLib.Kimlik.Bilgi.ID &&
                                                                            vi.SOZLESME_ID == MySozlesme.ID).ToList();

                                                                List<AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY>
                                                                    hesaplar =
                                                                        new List
                                                                            <
                                                                                AvukatProLib.Arama.
                                                                                    AV001_TDI_BIL_CARI_HESAP_DETAY>();

                                                                foreach (var item in cariHesapDetaylari)
                                                                {
                                                                    AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY
                                                                        tmp =
                                                                            kullaniciHesaplar.Where(
                                                                                vi => vi.ID == item.ID).SingleOrDefault();
                                                                    if (tmp != null)
                                                                        hesaplar.Add(tmp);
                                                                }
                                                                if (ucMuhasebeGenel1 == null)
                                                                    CreateUcMuhasebeGenel1();
                                                                if (hesaplar != null)
                                                                {
                                                                    ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetay();
                                                                }
                                                                if (ucMuhasebeGenel2 == null)
                                                                    CreateUcMuhasebeGenel2();
                                                                if (hesaplar != null)
                                                                {
                                                                    DataTable dtt = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetay();
                                                                    dtt.Select("KontrolKimId=" + AvukatProLib.Kimlik.Bilgi.ID);
                                                                    ucMuhasebeGenel2.MyMuvekkilCariHesapDetayli = dtt;
                                                                }
                                                            }
                                                        }
                                                    };
                bckWorker.RunWorkerAsync();

                DataBinding(MySozlesme);
            }
            catch 
            {
            }
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BindOzelKod();
        }

        private void frmMuhasebe_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetayBySozlesmeFoyId(MySozlesme.ID);
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

        private void tbcSozlesmeGridler_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page.Name == this.tabSozlesmeMuhasebe.Name)
            {
                #region Masraf Avansdan Dosya Muhasebe ve detay oluþtur

                bool olustur = false;
                if (MySozlesme != null)
                {
                    int foyID = MySozlesme.ID;
                    TList<AV001_TDI_BIL_MASRAF_AVANS> gelenMasrafAvans = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetBySOZLESME_ID(foyID);

                    try
                    {
                        foreach (var masrafAvans in gelenMasrafAvans)
                        {
                            AV001_TDI_BIL_FOY_MUHASEBE gelenMuhasebe = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID).FirstOrDefault();

                            if (gelenMuhasebe == null)
                            {
                                olustur = true;
                            }

                            if (gelenMuhasebe != null)
                            {
                                TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> mevcutMasrafDetay = DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID);
                                TList<AV001_TDI_BIL_FOY_MUHASEBE_DETAY> gelenMuhasebeDetay = DataRepository.AV001_TDI_BIL_FOY_MUHASEBE_DETAYProvider.GetByFOY_MUHASEBE_ID(gelenMuhasebe.ID);

                                if (mevcutMasrafDetay.Count > gelenMuhasebeDetay.Count)
                                {
                                    olustur = true;
                                }
                            }
                        }

                        if (olustur)
                        {
                            if (XtraMessageBox.Show(
                           "Bu dosyada dosya muhasebesine aktarýlmamýþ masraf ve / veya avans kayýtlarý var.\nMüvekkil muhasebesine aktarýlabilmesi için öncelikle bu kayýtlarýn oluþturulmasý gerekiyor.\nÞimdi oluþturulmasýný ister misiniz?",
                           "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                            {
                                foreach (var masrafAvans in gelenMasrafAvans)
                                {
                                    AV001_TDI_BIL_FOY_MUHASEBE gelenMuhasebe = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID).FirstOrDefault();
                                    if (gelenMuhasebe == null)
                                    {
                                        CreateFoyMuhasebeByMasrafAvansRequest request = new CreateFoyMuhasebeByMasrafAvansRequest();
                                        request.MasrafAvansId = masrafAvans.ID;
                                        request.ModulId = masrafAvans.CARI_HESAP_HEDEF_TIP;
                                        AvukatPro.Services.Implementations.MuhasebeService.CreateFoyMuhasebeByMasrafAvans(request);
                                        gelenMuhasebe = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID).FirstOrDefault();
                                    }

                                    if (gelenMuhasebe != null)
                                    {
                                        TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> mevcutMasrafDetay = DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID);
                                        TList<AV001_TDI_BIL_FOY_MUHASEBE_DETAY> gelenMuhasebeDetay = DataRepository.AV001_TDI_BIL_FOY_MUHASEBE_DETAYProvider.GetByFOY_MUHASEBE_ID(gelenMuhasebe.ID);

                                        if (mevcutMasrafDetay.Count > gelenMuhasebeDetay.Count)
                                        {
                                            foreach (var item in mevcutMasrafDetay)
                                            {
                                                //kontrol versiyon alanýnda masraf avans detay id tutulmaktadýr
                                                if (!gelenMuhasebeDetay.Any(m => m.KONTROL_VERSIYON == item.ID))
                                                {
                                                    CreateFoyMuhasebeDetayByMasrafAvansDetayRequest request = new CreateFoyMuhasebeDetayByMasrafAvansDetayRequest();
                                                    request.MasrafAvansDetayId = item.ID;
                                                    request.MuhasebeId = gelenMuhasebe.ID;
                                                    request.YenidenHesaplanabilir = !item.MA_MANUAL_KAYIT_MI;
                                                    AvukatPro.Services.Implementations.MuhasebeService.CreateFoyMuhasebeDetayByMasrafAvansDetay(request);

                                                    // son parametre yeniden hesaplanabilir olmasý için verildi
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            XtraMessageBox.Show("Masraf avans kayýtlarýnýn dosya muhasebesine aktarýlmasý tamamlandý.", "Ýþlem Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    catch (Exception)
                    {
                        XtraMessageBox.Show("Aktarým tamamlanamadý!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                #endregion Masraf Avansdan Dosya Muhasebe ve detay oluþtur

                this.tabSozlesmeMuhasebe.Controls.Clear();

                UserControls.ucMuhasebeGenel ucMuhasebeSozlesme = new UserControls.ucMuhasebeGenel("Sözleþme", "Dosya", null);
                ucMuhasebeSozlesme.Dock = System.Windows.Forms.DockStyle.Fill;
                ucMuhasebeSozlesme.Location = new System.Drawing.Point(0, 0);
                ucMuhasebeSozlesme.Name = "ucMuhasebeSozlesme";
                ucMuhasebeSozlesme.SaveStatus = false;
                ucMuhasebeSozlesme.Size = new System.Drawing.Size(918, 276);
                ucMuhasebeSozlesme.TabIndex = 9;

                //int[] idler = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetBySOZLESME_ID(MySozlesme.ID).Select(i => i.ID).Distinct().ToArray();
                //VList<R_FOY_MUHASEBESI_SOZLESME> sozlesmeMuhasebe = new VList<R_FOY_MUHASEBESI_SOZLESME>();

                //foreach (var id in idler)
                //{
                //    sozlesmeMuhasebe.AddRange((VList<R_FOY_MUHASEBESI_SOZLESME>)DataRepository.R_FOY_MUHASEBESI_SOZLESMEProvider.Get("ID = " + id, "TARIH"));
                //}

                ucMuhasebeSozlesme.MySozlesmeFoyMuhasebe = AvukatPro.Services.Implementations.MuhasebeService.GetAllMuhasebeFromSozlesmeFoy(MySozlesme.ID);
                ucMuhasebeSozlesme.mainView.FocusedRowChanged += ucMuhasebeSozlesme.gridView2_FocusedRowChanged;
                this.tabSozlesmeMuhasebe.Controls.Add(ucMuhasebeSozlesme);

                lblOzelKod1.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod1;
                lblOzelKod2.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod2;
                lblOzelKod3.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod3;
                lblOzelKod4.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod4;
            }

            if (e.Page.Name == this.tabpMuvekkilHesabi.Name)
            {
                #region DosyaMuhasebesi kontrol ve muyasebeleþtirme ekranýna gönderme

                decimal? carilestirilebilirToplam = AvukatPro.Services.Implementations.MuhasebeService.GetMuhasebeBirlesikDetayliByFoyId(MySozlesme.ID, 5).Select(m => m.MuhasebelestirilmemisMiktar).Sum();

                if (carilestirilebilirToplam > 0)
                {
                    if (XtraMessageBox.Show(
                   "Bu dosyada dosya muhasebesine aktarýlmýþ ancak müvekkiller adýna muhasebeleþtirilmemiþ kayýtlar bulunmaktadýr.\nÞimdi muhasebeleþtirmek istiyormusunuz?",
                   "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        frmDosyaMuhasebelestirme frm = new frmDosyaMuhasebelestirme(5, MySozlesme.ID);
                        frm.MdiParent = AnaForm.mdiAvukatPro.MainForm;
                        frm.FormClosed += new FormClosedEventHandler(frmMuhasebe_FormClosed);
                        frm.Show();
                    }
                }

                if (ucMuhasebeGenel1 == null)
                {
                    CreateUcMuhasebeGenel1();
                }

                ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetayBySozlesmeFoyId(MySozlesme.ID);

                #endregion DosyaMuhasebesi kontrol ve muyasebeleþtirme ekranýna gönderme
            }
        }

        private void ucSozlesmeGridler_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (!IsLoaded)
            {
                InitializeComponent();

                //var pages = tbcSozlesmeGridler.TabPages.OrderBy(vi => vi.Text).ToList();

                //tbcSozlesmeGridler.TabPages.Clear();

                //for (int i = 0; i < pages.Count(); i++)
                //{
                //    tbcSozlesmeGridler.TabPages.Add(pages[i]);
                //}

                if (MySozlesme != null)
                {
                    this.DataDegisitir(MySozlesme);
                    DataBinding(MySozlesme);
                }

                BindOzelKod();
                lueOzelKod_1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
                lueOzelKod_2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
                lueOzelKod_3.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
                lueOzelKod_4.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);

                

                lblBanka.Text = Kimlikci.Kimlik.OrtakOzelDurum.Banka;
                lblFoyBirim.Text = Kimlikci.Kimlik.OrtakOzelDurum.FoyBirim;
                lblFoyYeri.Text = Kimlikci.Kimlik.OrtakOzelDurum.FoyYeri;
                lblKrediGrup.Text = Kimlikci.Kimlik.OrtakOzelDurum.KrediGrup;
                label7.Text = Kimlikci.Kimlik.OrtakOzelDurum.KrediTip;
                lblOzel.Text = Kimlikci.Kimlik.OrtakOzelDurum.Ozel;
                lblSube.Text = Kimlikci.Kimlik.OrtakOzelDurum.Sube;
                lblTahsilat.Text = Kimlikci.Kimlik.OrtakOzelDurum.Tahsilat;
                label9.Text = Kimlikci.Kimlik.OrtakOzelDurum.Klasor1;
                label10.Text = Kimlikci.Kimlik.OrtakOzelDurum.Klasor2;

                IsLoaded = true;
            }
        }

        //müvekkilhesabý , müvekkilin tüm hesabý
        private void xtraTabControl8_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page.Name == "tabDosyaHesabi")
            {
                if (!AvukatProLib.Kimlik.Bilgi.CARI_ID.HasValue) return;
                if (ucMuhasebeGenel1 == null)
                {
                    CreateUcMuhasebeGenel1();
                }
                DataTable hesaplar = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetayBySozlesmeFoyId(MySozlesme.ID);

                ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = hesaplar;
                if (ucMuhasebeGenel1.ucPivotChart1 != null)
                    ucMuhasebeGenel1.ucPivotChart1.MyCarHesapDetayliArama = hesaplar;
            }
            else if (e.Page.Name == "tabTumHesabi")
            {
                if (!AvukatProLib.Kimlik.Bilgi.CARI_ID.HasValue) return;
                if (ucMuhasebeGenel2 == null)
                {
                    CreateUcMuhasebeGenel2();
                }
                DataTable hesaplar = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetayBySozlesmeTaraf(MySozlesme.ID);
                ucMuhasebeGenel2.MyMuvekkilCariHesapDetayli = hesaplar;

                if (ucMuhasebeGenel2.ucPivotChart1 != null)
                    ucMuhasebeGenel2.ucPivotChart1.MyCarHesapDetayliArama = hesaplar;
            }
        }

        #endregion Methods
    }
}