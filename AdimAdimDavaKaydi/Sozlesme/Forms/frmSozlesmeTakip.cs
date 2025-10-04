using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using AvukatProLib;

namespace AdimAdimDavaKaydi.Sozlesme.Forms
{
    public partial class frmSozlesmeTakip : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {

        public frmSozlesmeTakip()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public event EventHandler<FrmSozlesmeDosyaKayit> SozlesmeKaydedildi;

        public enum TabTag
        {
            Adres1 = 1,
            Adres2 = 2,
            Adres3 = 3
        }



        public void DataDegisti(AV001_TDI_BIL_SOZLESME soz)
        {
            BackgroundWorker bckWorker = new BackgroundWorker();

            bckWorker.DoWork += delegate
            {
                DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(soz, false,
                                                                       DeepLoadType.
                                                                           IncludeChildren

                    // , typeof(TList<AV001_TDI_BIL_SOZLESME>)
                                                                       ,
                                                                       typeof(
                                                                           TList
                                                                           <AV001_TDIE_BIL_ASAMA
                                                                           >)
                                                                       ,
                                                                       typeof(
                                                                           TList
                                                                           <
                                                                           AV001_TDI_BIL_SOZLESME_DETAY
                                                                           >)
                                                                       ,
                                                                       typeof(
                                                                           TList
                                                                           <
                                                                           AV001_TDI_BIL_SOZLESME_GELISME_ADIM
                                                                           >)
                                                                       ,
                                                                       typeof(
                                                                           TList
                                                                           <
                                                                           AV001_TDI_BIL_GORUSME
                                                                           >)
                                                                       ,
                                                                       typeof(
                                                                           TList<TSMS_BIL_MESAJ>
                                                                           )
                                                                       ,
                                                                       typeof(
                                                                           TList
                                                                           <AV001_TDIE_BIL_MESAJ
                                                                           >)
                                                                       ,
                                                                       typeof(
                                                                           TList
                                                                           <AV001_TDI_BIL_FATURA
                                                                           >)
                                                                       ,
                                                                       typeof(
                                                                           TList
                                                                           <
                                                                           AV001_TDI_BIL_KAYIT_ILISKI
                                                                           >)
                                                                       ,
                                                                       typeof(
                                                                           TList
                                                                           <
                                                                           AV001_TDI_BIL_IS_SOZLESME
                                                                           >)
                                                                       ,
                                                                       typeof(
                                                                           TList
                                                                           <
                                                                           AV001_TDI_BIL_TEBLIGAT
                                                                           >)
                                                                       ,

                    //typeof(
                    //    TList
                    //    <
                    //    AV001_TS_BIL_SOZLESME_URUN_BILGILERI
                    //    >)
                    //,
                                                                       typeof(
                                                                           TList
                                                                           <
                                                                           AV001_TDI_BIL_SOZLESME_HUKUM
                                                                           >)
                                                                       ,
                                                                       typeof(
                                                                           TList
                                                                           <
                                                                           AV001_TDI_BIL_IS_GOREV
                                                                           >)
                                                                       ,
                                                                       typeof(
                                                                           TList
                                                                           <
                                                                           AV001_TDI_BIL_SOZLESME_TARAF
                                                                           >)
                                                                       ,
                                                                       typeof(
                                                                           TList<TDIE_KOD_ASAMA>
                                                                           )
                                                                       ,
                                                                       typeof(
                                                                           TList
                                                                           <
                                                                           AV001_TDI_BIL_SOZLESME_SORUMLU
                                                                           >)
                                                                       ,
                                                                       typeof(
                                                                           TList
                                                                           <
                                                                           AV001_TDI_BIL_SOZLESME_OZEL_KOD
                                                                           >));

                foreach (
                    AV001_TDI_BIL_SOZLESME_SORUMLU avukat in
                        MySozlesme.AV001_TDI_BIL_SOZLESME_SORUMLUCollection)
                {
                    if (avukat.SORUMLU_CARI_IDSource == null)
                        DataRepository.AV001_TDI_BIL_SOZLESME_SORUMLUProvider.DeepLoad(avukat,
                                                                                       true,
                                                                                       DeepLoadType
                                                                                           .
                                                                                           IncludeChildren,
                                                                                       typeof(
                                                                                           AV001_TDI_BIL_CARI
                                                                                           ));
                }
            };

            bckWorker.RunWorkerCompleted += delegate
            {
                soz.Tag = 1;

                bndSozlesme.DataSource = soz;

                ucSozlesmeTarafBilgileri1.MySozlesme = soz;
                ucSozlesmeHakemleri1.MyDataSource =
                    soz.AV001_TDI_BIL_SOZLESME_HAKEMLERICollection;
                ucSozlesmeGridler1.MySozlesme = soz;

                #region <MB-20100412> Kayýt Ýliþki

                if (ucSozlesmeGridler1.ucSozlesmeIliskiliDosyalar1 == null)
                    ucSozlesmeGridler1.CreateUcSozlesmeIliskiliDosyalar1();

                ucSozlesmeGridler1.ucSozlesmeIliskiliDosyalar1.GetList(
                    MySozlesme.ID,
                    AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.
                        SOZLESME_DOSYASI);

                var kayitIliski =
                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.Find(
                        string.Format("KAYNAK_KAYIT_ID = {0}", MySozlesme.ID));
                var detay =
                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.
                        GetByHEDEF_KAYIT_ID(MySozlesme.ID);

                if (kayitIliski.Count > 0 || detay.Count > 0)
                    c_titemIliskiliDosyalar.Image =
                        global::AdimAdimDavaKaydi.Properties.Resources.
                            iliskili_dosyalar_red_16x16;
                else
                    c_titemIliskiliDosyalar.Image =
                        global::AdimAdimDavaKaydi.Properties.Resources.
                            iliskili_dosyalar_mavi_16x16;

                #endregion <MB-20100412> Kayýt Ýliþki

                #region Sorumlu Avukat

                //    gLueSorumlu.EditValueChanged += gLueSorumlu_EditValueChanged;
                //    DataRepository.AV001_TDI_BIL_SOZLESME_SORUMLUProvider.DeepLoad(MySozlesme.AV001_TDI_BIL_SOZLESME_SORUMLUCollection, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));

                //    gLueSorumlu.Properties.BeginUpdate();
                //    gLueSorumlu.Properties.DataSource = MySozlesme.AV001_TDI_BIL_SOZLESME_SORUMLUCollection;
                //    gLueSorumlu.Properties.ValueMember = "ID";
                //    gLueSorumlu.Properties.DisplayMember = "SORUMLU_CARI_IDSource";
                //    if (MySozlesme.AV001_TDI_BIL_SOZLESME_SORUMLUCollection.Count > 0)
                //        gLueSorumlu.EditValue = MySozlesme.AV001_TDI_BIL_SOZLESME_SORUMLUCollection[0].ID;

                //    gLueSorumlu.Properties.EndUpdate();
            };
            bckWorker.WorkerSupportsCancellation = true;
            if (!bckWorker.IsBusy)
                bckWorker.RunWorkerAsync();

                #endregion Sorumlu Avukat
        }

        public void LoadData()
        {
            BelgeUtil.Inits.SozlesmeSekliGetir(lueSozlesmeSekli.Properties);
            BelgeUtil.Inits.SozlesmeTipiGetir(lueSozlesmeTip.Properties);
            BelgeUtil.Inits.SozlesmeAltTipiHepsiGetir(lueSozlesmeAltTip.Properties);
            BelgeUtil.Inits.AdliBirimGorevGetir(lueAdliBirimGorev.Properties);
            BelgeUtil.Inits.SozlesmeDurumGetir(lueSozlesmeDurum.Properties);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(lueAdliBirimAdliye.Properties);

            //todo:get data ýnitse taþýnýnca düzeltilecek
            BelgeUtil.Inits.BankaKartTipiGetir(lueKartTipi);
            BelgeUtil.Inits.RehinCinsGetir(lueRehinCins);
            BelgeUtil.Inits.RehinDurumGetir(lueRehinDurum);
            BelgeUtil.Inits.perCariGetir(lueCari.Properties);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(lueYetkiYeri.Properties);
            BelgeUtil.Inits.HarcIstisnaGetir(lueHarcIstisna);
            BelgeUtil.Inits.RehinHarcIstisnaBelge(lueIstBelge);
            BelgeUtil.Inits.RehinSiciltipGetir(lueSicilTip.Properties);
            BelgeUtil.Inits.AdliBirimNoGetir(lueAdliBirimNo.Properties);
            BelgeUtil.Inits.IlGetir(new[] { lueSicilIl });
            BelgeUtil.Inits.IlceGetir(new[] { lueSicilIlce });

            SozlesmeAsamaDoldur(lueSozlesmeAsama);
            if (SozlesmeList == null)
                SozlesmeList = BelgeUtil.Inits.SozlesmeGetir();

            bndSozlesme_CurrentChanged(0, new EventArgs());
            SozlesmeBelgeDoldur();
            BelgeUtil.Inits.DovizTipGetir(lueDoviz1);
            BelgeUtil.Inits.DovizTipGetir(lueDoviz2);
            BelgeUtil.Inits.DovizTipGetir(lueDoviz3);
        }

        public void Show(TList<AV001_TDI_BIL_SOZLESME> foys)
        {
            this.SozlesmeList = foys;
            bndSozlesme.DataSource = foys;

            //  this.MdiParent = null;
            this.Show();
        }

        public void Show(int id)
        {
            MySozlesme = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(id);
            if (MySozlesme == null)
            {
                MessageBox.Show("Açýlmak istenilen Sözleþme dosyasý bulunamadý.");
                Application.Exit();
                return;
            }
            if (SozlesmeList == null)
                SozlesmeList = new TList<AV001_TDI_BIL_SOZLESME>();
            SozlesmeList.Add(MySozlesme);
            this.Show();
        }

        public void ShowDialog(TList<AV001_TDI_BIL_SOZLESME> foys)
        {
            this.SozlesmeList = foys;
            bndSozlesme.DataSource = foys;

            //  this.MdiParent = null;
            this.Show();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            bndSozlesme.CurrentChanged += bndSozlesme_CurrentChanged;
            if (this.DesignMode) return;
            LoadData();
            bndSozlesme.DataSource = SozlesmeList;
            if (SozlesmeList.Count > 0)
            {
                AV001_TDI_BIL_SOZLESME soz = SozlesmeList[0];
                if (soz.TIP_ID == 1)
                    lcntrlSozlesmeBilgileri.RestoreLayoutFromXml("KIRA_SOZLESMESI.xml");
                else if (soz.TIP_ID == 2 && soz.ALT_TIP_ID != 4)
                    lcntrlSozlesmeBilgileri.RestoreLayoutFromXml("GENEL_KREDI_SOZLESMESI.xml");
                else if (soz.TIP_ID == 2 && soz.ALT_TIP_ID == 4)
                    lcntrlSozlesmeBilgileri.RestoreLayoutFromXml("KREDI_KARTI_SOZLESMESI.xml");
                else if (soz.TIP_ID == 3)
                    lcntrlSozlesmeBilgileri.RestoreLayoutFromXml("RESMI_SENET.xml");
                else if (soz.TIP_ID == 4)
                    lcntrlSozlesmeBilgileri.RestoreLayoutFromXml("GENEL_SOZLESME.xml");
                else if (soz.TIP_ID == 6)
                    lcntrlSozlesmeBilgileri.RestoreLayoutFromXml("MARKA_PATENT_SOZLESMESI.xml");
                else if (soz.TIP_ID == 5)
                    lcntrlSozlesmeBilgileri.RestoreLayoutFromXml("HAKEM_SOZLESMESI.xml");
            }

            ucSozlesmeGridler1.lblOzelKod1.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod1;
            ucSozlesmeGridler1.lblOzelKod2.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod2;
            ucSozlesmeGridler1.lblOzelKod3.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod3;
            ucSozlesmeGridler1.lblOzelKod4.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod4;
        }

        private void bndSozlesme_CurrentChanged(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(int)) return;

            MySozlesme = SozlesmeList[(int)sender];
            ucSozlesmeGridler1.MySozlesme = MySozlesme;
            if (MySozlesme.AV001_TDI_BIL_SOZLESME_HAKEMLERICollection.Count == 0)
                DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(MySozlesme, false, DeepLoadType.IncludeChildren,
                                                                       typeof(TList<AV001_TDI_BIL_SOZLESME_HAKEMLERI>));
            ucSozlesmeHakemleri1.MyDataSource = MySozlesme.AV001_TDI_BIL_SOZLESME_HAKEMLERICollection;
            DataDegisti(MySozlesme);
        }

        #region Feilds

        private TList<AV001_TDI_BIL_CARI> listSorumluCari = new TList<AV001_TDI_BIL_CARI>();

        private TList<AV001_TDI_BIL_SOZLESME> SozlesmeList;

        public AV001_TDI_BIL_SOZLESME MySozlesme { get; set; }

        #endregion Feilds

        private void frmSozlesmeTakip_Button_Ac_Click(object sender, EventArgs e)
        {
            GirisEkran.rFrmSozlesmeGirisEkran frmSozlesmeAra = new AdimAdimDavaKaydi.GirisEkran.rFrmSozlesmeGirisEkran();
            frmSozlesmeAra.Show();
        }

        private void frmSozlesmeTakip_Button_Ajanda_Click(object sender, EventArgs e)
        {
            #region <MB-20100429> Dosya Ajandasý Yeniden Düzenlendi.

            //Kullanýcýnýn o dosyada sorumlu avukat olup olmadýðý kontrolü yapýlýyor.
            TList<AV001_TDI_BIL_SOZLESME_SORUMLU> dosyaSorumluAvukatlari =
                DataRepository.AV001_TDI_BIL_SOZLESME_SORUMLUProvider.GetBySOZLESME_ID(MySozlesme.ID);
            bool kullaniciDosyadaSorumluAvukat = false;

            foreach (var item in dosyaSorumluAvukatlari)
            {
                if (item.SORUMLU_CARI_ID == AvukatProLib.Kimlik.Bilgi.CARI_ID.Value)
                {
                    kullaniciDosyadaSorumluAvukat = true;
                    break;
                }
                else
                    kullaniciDosyadaSorumluAvukat = false;
            }

            if (!kullaniciDosyadaSorumluAvukat)
            {
                XtraMessageBox.Show(
                    "Dosyada Sorumlu Avukat olmadýðýnýz için" + Environment.NewLine + "gösterilecek iþleriniz yok.",
                    "BÝLGÝ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Kullanýcýnýn Dosyadaki iþlerini buluyor.
            var isler = BelgeUtil.Inits.context.per_AV001_TDI_BIL_IS_Asistans.Where(item => BelgeUtil.Inits.context.NN_IS_SOZLESMEs.Where(sozlesme => sozlesme.SOZLESME_ID == MySozlesme.ID).Select(t => t.IS_ID).Contains(item.ID) && item.AJANDADA_GORUNSUN_MU && BelgeUtil.Inits.context.AV001_TDI_BIL_IS_TARAFs.Where(c => c.CARI_ID == AvukatProLib.Kimlik.Bilgi.CARI_ID && c.IS_TARAF_ID == 2).Select(vi => vi.IS_ID).Contains(item.ID)).ToList();

            //Dosyanýn iliþkili olduðu dosyalarýn iþlerini buluyor.
            AV001_TDI_BIL_KAYIT_ILISKI iliski =
                DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByILISKI_TUR_IDKAYNAK_KAYIT_ID(
                    (int?)AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.SOZLESME_DOSYASI, MySozlesme.ID);
            if (iliski != null)
            {
                TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> iliskiDetaylari =
                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByKAYIT_ILISKI_ID(iliski.ID);
                IcraTakipForms._frmIcraTakip.KayitIliskiDetayIsleriGetir(iliskiDetaylari, isler);
            }
            else
            {
                TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> iliskiDetaylari =
                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_KAYIT_ID(MySozlesme.ID);
                IcraTakipForms._frmIcraTakip.DetaydanIliskiliIsleriGetir(iliskiDetaylari, isler);
            }

            //aykut önemli 27.02.2013
            //global::AdimAdimDavaKaydi.Ajanda.Forms.MainForms.frmAjanda ajanda =
            //    new global::AdimAdimDavaKaydi.Ajanda.Forms.MainForms.frmAjanda(isler, MySozlesme, true);
            //ajanda.Show();

            #endregion <MB-20100429> Dosya Ajandasý Yeniden Düzenlendi.
        }

        private void frmSozlesmeTakip_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (SozlesmeKaydet(MySozlesme))
            {
                XtraMessageBox.Show("Kayýt iþlemi baþarýyla gerçekleþti.", "Kaydet",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                XtraMessageBox.Show("Kayýt iþlemi bir hatayla karþýlaþtý. Lütfen tekrar deneyiniz.", "Kaydet",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmSozlesmeTakip_Button_Yeni_Click(object sender, EventArgs e)
        {
            frmSozlesmeKayit sozlesmeKayit = new frmSozlesmeKayit();
            if (SozlesmeKaydedildi != null)
                SozlesmeKaydedildi(this, new FrmSozlesmeDosyaKayit(sozlesmeKayit));
            sozlesmeKayit.Show();
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Ac_Click += frmSozlesmeTakip_Button_Ac_Click;
            this.Button_Yeni_Click += frmSozlesmeTakip_Button_Yeni_Click;
            this.Button_Editor_Click += frmSozlesmeTakip_Button_Editor_Click;
            this.Button_PDF_Click += frmSozlesmeTakip_Button_PDF_Click;
            this.Button_Excel_Click += frmSozlesmeTakip_Button_Excel_Click;
            this.Button_Outlook_Click += frmSozlesmeTakip_Button_Outlook_Click;
            this.Button_Word_Click += frmSozlesmeTakip_Button_Word_Click;
            this.Button_Kaydet_Click += frmSozlesmeTakip_Button_Kaydet_Click;
            this.Button_IliskiliDosyalar_Click += frmSozlesmeTakip_Button_IliskiliDosyalar_Click;
            this.Button_Ajanda_Click += frmSozlesmeTakip_Button_Ajanda_Click;
        }

        private void SozlesmeAsamaDoldur(LookUpEdit lue)
        {
            VList<per_TDIE_KOD_ASAMA> obj = DataRepository.per_TDIE_KOD_ASAMAProvider.Get("ASAMA_MODUL_ID = 5", "ID");

            lue.Properties.DataSource = obj;
            lue.Properties.ValueMember = "ID";
            lue.Properties.DisplayMember = "ASAMA_ADI";

            lue.Properties.Columns.Clear();

            lue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ASAMA_ADI", 40, "Aþama"));
        }

        private void SozlesmeBelgeDoldur()
        {
            List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> obj = BelgeUtil.Inits.context.VDIE_BIL_SABLON_RAPORs.Where(item => item.KATEGORI_ID == (int)SablonAltKategori.Sozlesmeler).ToList();
            lueSozlesmeBelge.Properties.DataSource = obj;
            lueSozlesmeBelge.Properties.ValueMember = "ID";
            lueSozlesmeBelge.Properties.DisplayMember = "AD";

            lueSozlesmeBelge.Properties.Columns.Clear();
            lueSozlesmeBelge.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AD", 30,
                                                                                                         "Sözleþme Belgeleri"));
        }

        private bool SozlesmeKaydet(AV001_TDI_BIL_SOZLESME s)
        {
            //TODO : Baðlantý cümleciði AvukatProLib.Kimlik.SirketBilgisi.ConStr ten cekildi - Ersin - 30.10.08
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                trans.BeginTransaction();

                DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepSave(trans, s);
                DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepSave(trans, s, DeepSaveType.IncludeChildren,
                                                                       typeof(TList<AV001_TDI_BIL_CARI>),
                                                                       typeof(TList<AV001_TDI_BIL_SOZLESME_SORUMLU>),
                                                                       typeof(TList<AV001_TDI_BIL_SOZLESME_TARAF>),
                                                                       typeof(TList<AV001_TDI_BIL_SOZLESME_OZEL_KOD>),
                                                                       typeof(TList<AV001_TDI_BIL_SOZLESME_HAKEMLERI>));

                foreach (AV001_TDI_BIL_SOZLESME_TARAF item in MySozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection)
                {
                    DataRepository.AV001_TDI_BIL_SOZLESME_TARAFProvider.DeepSave(trans, item);
                    if (item.CARI_IDSource != null)
                    {
                        DataRepository.AV001_TDI_BIL_CARIProvider.DeepSave(trans, item.CARI_IDSource,
                                                                           DeepSaveType.IncludeChildren,
                                                                           typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
                    }
                }

                foreach (AV001_TDI_BIL_SOZLESME_SORUMLU sorm in MySozlesme.AV001_TDI_BIL_SOZLESME_SORUMLUCollection)
                {
                    if (sorm.SORUMLU_CARI_ID != null && sorm.SORUMLU_CARI_IDSource != null)
                        DataRepository.AV001_TDI_BIL_CARIProvider.DeepSave(trans, sorm.SORUMLU_CARI_IDSource,
                                                                           DeepSaveType.IncludeChildren,
                                                                           typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>),
                                                                           typeof(TList<AV001_TDI_BIL_CARI>));
                }

                //Sorumlu Avukatlar
                foreach (AV001_TDI_BIL_SOZLESME_SORUMLU sorumluAv in s.AV001_TDI_BIL_SOZLESME_SORUMLUCollection)
                {
                    if (sorumluAv.SORUMLU_CARI_IDSource != null)
                        sorumluAv.SORUMLU_CARI_ID = sorumluAv.SORUMLU_CARI_IDSource.ID;
                }
                foreach (var item in MySozlesme.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SOZLESME_GEMI_UCAK_ARAC)
                {
                    if (
                        MySozlesme.NN_SOZLESME_GEMI_UCAK_ARACCollection.FindAll(
                            NN_SOZLESME_GEMI_UCAK_ARACColumn.GEMI_UCAK_ARAC_ID, item.ID).Count == 0)
                    {
                        NN_SOZLESME_GEMI_UCAK_ARAC sArac = new NN_SOZLESME_GEMI_UCAK_ARAC();
                        sArac.SOZLESME_ID = MySozlesme.ID;
                        sArac.GEMI_UCAK_ARAC_ID = item.ID;
                        DataRepository.NN_SOZLESME_GEMI_UCAK_ARACProvider.DeepSave(trans, sArac);
                    }
                }
                DataRepository.AV001_TDI_BIL_SOZLESME_TARAFProvider.DeepSave(trans,
                                                                             s.AV001_TDI_BIL_SOZLESME_TARAFCollection);

                DataRepository.AV001_TDI_BIL_SOZLESME_SORUMLUProvider.DeepSave(trans,
                                                                               s.
                                                                                   AV001_TDI_BIL_SOZLESME_SORUMLUCollection);
                //tebligatlarýn esas no düzenlemeleri

                var tebligats = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetBySOZLESME_ID(s.ID);

                foreach (var item in tebligats)
                {
                    item.ADLI_BIRIM_ADLIYE_ID = s.ADLI_BIRIM_ADLIYE_ID;
                    item.ADLI_BIRIM_GOREV_ID = s.ADLI_BIRIM_GOREV_ID;
                    item.ADLI_BIRIM_NO_ID = s.ADLI_BIRIM_NO_ID;
                    item.TEBLIGAT_ESAS_NO = s.SOZLESME_NO;
                }
                //Tebligat
                DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(trans, tebligats);

                //---------------------------------//
                trans.Commit();

                return true;
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                MessageBox.Show(ex.ToString());

                return false;
            }
        }

        #region <MB-20100412> Kayýt Ýliþki

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ucSozlesmeGridler1.ucSozlesmeIliskiliDosyalar1.GetList(MySozlesme.ID,
                                                                   AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.
                                                                       IliskiTur.SOZLESME_DOSYASI);

            var kayitIliski =
                DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.Find(string.Format("KAYNAK_KAYIT_ID = {0}",
                                                                                     MySozlesme.ID));
            var detay = DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_KAYIT_ID(MySozlesme.ID);

            if (kayitIliski.Count > 0 || detay.Count > 0)
                c_titemIliskiliDosyalar.Image =
                    global::AdimAdimDavaKaydi.Properties.Resources.iliskili_dosyalar_red_16x16;
            else
                c_titemIliskiliDosyalar.Image =
                    global::AdimAdimDavaKaydi.Properties.Resources.iliskili_dosyalar_mavi_16x16;
        }

        private void frmSozlesmeTakip_Button_IliskiliDosyalar_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.frmKayitIliski frm = new AdimAdimDavaKaydi.Forms.frmKayitIliski();
            frm.MySozlesme = MySozlesme;
            frm.FormClosed += frm_FormClosed;
            frm.Show();
        }

        #endregion <MB-20100412> Kayýt Ýliþki

        #region Editor,Word,Outlook,Excell,Pdf button click

        private void frmSozlesmeTakip_Button_Editor_Click(object sender, EventArgs e)
        {
            frmEditor frmEdit = new frmEditor();
            frmEdit.MdiParent = mdiAvukatPro.MainForm;
            frmEdit.Show();
        }

        private void frmSozlesmeTakip_Button_Excel_Click(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.xls, bndSozlesme.DataSource);
        }

        private void frmSozlesmeTakip_Button_Outlook_Click(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pst, bndSozlesme.DataSource);
        }

        private void frmSozlesmeTakip_Button_PDF_Click(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pdf, bndSozlesme.DataSource);
        }

        private void frmSozlesmeTakip_Button_Word_Click(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.doc, bndSozlesme.DataSource);
        }

        #endregion Editor,Word,Outlook,Excell,Pdf button click
    }
    
    public class FrmSozlesmeDosyaKayit : EventArgs
    {
        public FrmSozlesmeDosyaKayit(frmSozlesmeKayit form)
        {
            MyForm = form;
        }

        public frmSozlesmeKayit MyForm { get; set; }
    }

}