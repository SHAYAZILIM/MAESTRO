using AdimAdimDavaKaydi.Belge.UserControls;
using AvukatProLib;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.DavaTakip
{
    public partial class frmDavaTakip : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmDavaTakip()
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine("Davatakip InitializeComponent start : " + dt);
            InitializeComponent();
            InitializeEvents();
            Console.WriteLine("Davatakip InitializeComponent finish : " + DateTime.Now);
            Console.WriteLine("Davatakip InitializeComponent fark : " + DateTime.Now.Subtract(dt));
        }

        #region Variables

        private BackgroundWorker bwDeepLoad = new BackgroundWorker();

        private TD_KOD_DAVA_TALEP DTalep = new TD_KOD_DAVA_TALEP();

        public event EventHandler<FrmDavaDosyaKayitEventArgs> DavaDosyaKayitTiklandi;

        #region <MB-20100628>

        //Veri girilen tarihlere göre dava durumunun belirlenmesini saðlamak için eklendi.
        private Dictionary<DateTime, int> davaTarihleri = new Dictionary<DateTime, int>();

        #endregion <MB-20100628>

        #endregion Variables

        #region Properties

        public AV001_TD_BIL_FOY MyFoy { get; set; }

        #region <MB-20100525>

        //Dosyanýn Klasör Bilgilerinin gelmesi saðlandý.

        public AV001_TDIE_BIL_PROJE MyProje { get; set; }

        #endregion <MB-20100525>

        #endregion Properties

        #region Methods

        private bool FoyDeepload = true;

        public override void Cikis()
        {
            base.Cikis();
            FoyCikis();
        }

        public void ProjeAlanlariIslemleri(AV001_TD_BIL_FOY foy)
        {
            #region <MB-20100525>

            //Dosyanýn Klasör Bilgilerinin gelmesi saðlandý.
            TList<AV001_TDIE_BIL_PROJE> proje = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByDAVA_FOY_IDFromAV001_TDIE_BIL_PROJE_DAVA_FOY(foy.ID);
            if (proje.Count > 0)
            {
                MyProje = proje[0];
                MyProje.AV001_TDIE_BIL_PROJE_SORUMLUCollection = BelgeUtil.Inits.ProjeSorumluGetir(MyProje.ID);
                bndProje.DataSource = MyProje;
            }
            else
                tabKlasorBilgileri.PageVisible = false;

            #endregion <MB-20100525>
        }

        public void Show(TList<AV001_TD_BIL_FOY> foys)
        {
            Show(foys, true);
        }

        public void Show(TList<AV001_TD_BIL_FOY> foys, bool deepLoad)
        {
            FoyDeepload = deepLoad;
            bndDavaFoy.DataSource = foys;
            ProjeAlanlariIslemleri(bndDavaFoy.Current as AV001_TD_BIL_FOY);
            ucSablonEditoreGonder1.Foys = new TList<AV001_TD_BIL_FOY>();
            ucSablonEditoreGonder1.Foys.Add(foys[0]);
            ucSablonEditoreGonder1.ModuleGoreDoldur(2);
            this.Show();
        }

        public void Show(int id)
        {
            bndDavaFoy.DataSource = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(id);
            ProjeAlanlariIslemleri(bndDavaFoy.Current as AV001_TD_BIL_FOY);
            ucSablonEditoreGonder1.Foys = new TList<AV001_TD_BIL_FOY>();
            ucSablonEditoreGonder1.Foys.Add(bndDavaFoy.Current as AV001_TD_BIL_FOY);
            ucSablonEditoreGonder1.ModuleGoreDoldur(2);
            MyFoy = bndDavaFoy.Current as AV001_TD_BIL_FOY;
            //CreateTarafBilgileri();
            this.Show();
        }

        public void Show(AV001_TD_BIL_FOY foy)
        {
            bndDavaFoy.DataSource = foy;
            ProjeAlanlariIslemleri(bndDavaFoy.Current as AV001_TD_BIL_FOY);
            ucSablonEditoreGonder1.Foys = new TList<AV001_TD_BIL_FOY>();
            ucSablonEditoreGonder1.Foys.Add(foy);
            ucSablonEditoreGonder1.ModuleGoreDoldur(2);
            this.Show();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            DateTime dt = DateTime.Now;
            Console.WriteLine("Load Start: " + dt);
            LoadData();
            Console.WriteLine("Load Finish: " + DateTime.Now);
            Console.WriteLine("Load Time: " + DateTime.Now.Subtract(dt));

            lciRef1.Text = Kimlikci.Kimlik.DavaReferans.Referans1;
            lciRef2.Text = Kimlikci.Kimlik.DavaReferans.Referans2;
            lciRef3.Text = Kimlikci.Kimlik.DavaReferans.Referans3;
            lciOzelKod1.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod1;
            lciOzelKod2.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod2;
            lciOzelKod3.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod3;
            lciOzelKod4.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod4;
        }

        private void BindOzelKod()
        {
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod1, 1, AvukatProLib.Extras.Modul.Dava);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod2, 2, AvukatProLib.Extras.Modul.Dava);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod3, 3, AvukatProLib.Extras.Modul.Dava);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod4, 4, AvukatProLib.Extras.Modul.Dava);
        }

        private void CreateUcDavaCore()
        {
            tabGelismeler.SuspendLayout();
            this.DavaCore = new AdimAdimDavaKaydi.DavaTakip.ucDavaCore();
            this.DavaCore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DavaCore.Location = new System.Drawing.Point(0, 0);
            this.DavaCore.Name = "DavaCore";
            this.DavaCore.Size = new System.Drawing.Size(1021, 699);
            this.DavaCore.TabIndex = 212;
            this.tabGelismeler.Controls.Add(this.DavaCore);
            tabGelismeler.ResumeLayout(false);
        }

        private void DataChange()
        {
            //bndDavaFoy.DataSource = this.MyFoy;
            if (DavaCore != null)
                DavaCore.MyFoy = this.MyFoy;

            //ToDo : Geçici Olarak Bu hesabý Burada yaptýk
            //hesap cetveli hazýrlanýnca hesapla butonnuna taþýnacak
            MyFoy = AvukatProLib.Hesap.FaizHelper.DavaDegeriniHesapla(MyFoy);

            //TakipAsamasiDoldur(MyFoy);

            if (MyFoy != null)
            {
                var iliskiler = BelgeUtil.Inits.context.per_AV001_TDI_BIL_KAYIT_ILISKIs.Where(vi => vi.KAYNAK_KAYIT_ID == MyFoy.ID).ToList();
                var detay = DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_DAVA_FOY_ID(MyFoy.ID);
                if ((iliskiler != null && iliskiler.Count > 0) || detay.Count > 0)
                    c_titemIliskiliDosyalar.Image =
                        global::AdimAdimDavaKaydi.Properties.Resources.iliskili_dosyalar_red_16x16;
                else
                    c_titemIliskiliDosyalar.Image =
                        global::AdimAdimDavaKaydi.Properties.Resources.iliskili_dosyalar_mavi_16x16;
            }

            #region <MB-20101103> Formun Text'inin Belirlenmesi

            if (BelgeUtil.Inits.FoyTarafGetir(MyFoy).Count == 0) return;

            AvukatProLib.Arama.per_AV001_TD_BIL_FOY_TARAF davaci = BelgeUtil.Inits.FoyTarafGetir(MyFoy).Where(vi => vi.DAVA_EDEN_MI).FirstOrDefault();
            AvukatProLib.Arama.per_AV001_TD_BIL_FOY_TARAF davali = BelgeUtil.Inits.FoyTarafGetir(MyFoy).Where(vi => vi.DAVA_EDEN_MI == false).FirstOrDefault();

            string takipEdenSifat = string.Empty;
            string takipEdilenSifat = string.Empty;
            string takipEden = string.Empty;
            string takipEdilen = string.Empty;

            if (davaci != null)
            {
                if (BelgeUtil.Inits._CariSifatGetir == null)
                    BelgeUtil.Inits._CariSifatGetir = BelgeUtil.Inits.context.per_TDIE_KOD_TARAF_SIFATs.ToList();
                takipEdenSifat = BelgeUtil.Inits._CariSifatGetir.Find(vi => vi.ID == davaci.TARAF_SIFAT_ID).SIFAT;
                if (BelgeUtil.Inits._per_CariGetir == null)
                    BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();
                takipEden = BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == davaci.CARI_ID).AD;
            }

            if (davali != null)
            {
                if (BelgeUtil.Inits._CariSifatGetir != null)
                    BelgeUtil.Inits._CariSifatGetir = BelgeUtil.Inits.context.per_TDIE_KOD_TARAF_SIFATs.ToList();
                takipEdilenSifat = BelgeUtil.Inits._CariSifatGetir.Find(vi => vi.ID == davali.TARAF_SIFAT_ID).SIFAT;
                if (BelgeUtil.Inits._per_CariGetir == null)
                    BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();
                takipEdilen = BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == davali.CARI_ID).AD;
            }

            this.Text = string.Format("{0} : {1} , {2} : {3}", takipEdenSifat, takipEden, takipEdilenSifat, takipEdilen);

            #endregion <MB-20101103> Formun Text'inin Belirlenmesi

            if (BelgeUtil.Inits.Telekomunukasyonmu)
                SayýNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private bool DavaFoyKaydet(AV001_TD_BIL_FOY foy)
        {
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                #region <MB-20100628>

                //Veri girilen tarihlere göre dava durumunun belirlenmesini saðlamak için eklendi.

                davaTarihleri.Clear();
                if (MyFoy.FOY_ARSIV_TARIHI.HasValue)
                    davaTarihleri.Add(MyFoy.FOY_ARSIV_TARIHI.Value, (int)Tarihler.ArsivTarihi);
                if (MyFoy.ZAMAN_ASIMI_ILE_INFAZ_TARIHI.HasValue)
                    davaTarihleri.Add(MyFoy.ZAMAN_ASIMI_ILE_INFAZ_TARIHI.Value, (int)Tarihler.ZamanAsimiTarihi);
                if (MyFoy.TERKIN_TARIHI.HasValue)
                    davaTarihleri.Add(MyFoy.TERKIN_TARIHI.Value, (int)Tarihler.TerkinTarihi);
                if (MyFoy.SEMERESIZLIKLE_KAPAMA_TARIHI.HasValue)
                    davaTarihleri.Add(MyFoy.SEMERESIZLIKLE_KAPAMA_TARIHI.Value, (int)Tarihler.SemereTarihi);
                if (MyFoy.MUVEKKILE_IADE_TARIHI.HasValue)
                    davaTarihleri.Add(MyFoy.MUVEKKILE_IADE_TARIHI.Value, (int)Tarihler.IadeTarihi);
                if (MyFoy.FOY_FERAGAT_TARIHI.HasValue)
                    davaTarihleri.Add(MyFoy.FOY_FERAGAT_TARIHI.Value, (int)Tarihler.FeragatTarihi);
                if (MyFoy.SULH_TARIHI.HasValue)
                    davaTarihleri.Add(MyFoy.SULH_TARIHI.Value, (int)Tarihler.SulhTarihi);
                if (MyFoy.KURUL_KARARI_ILE_KAPAMA_TARIHI.HasValue)
                    davaTarihleri.Add(MyFoy.KURUL_KARARI_ILE_KAPAMA_TARIHI.Value, (int)Tarihler.KKKTarihi);

                switch (davaTarihleri.OrderByDescending(vi => vi.Key).FirstOrDefault().Value)
                {
                    case (int)Tarihler.ArsivTarihi:
                        MyFoy.FOY_DURUM_ID = (int)AvukatProLib.Extras.FoyDurum.ARÞÝV;
                        break;

                    case (int)Tarihler.ZamanAsimiTarihi:
                        MyFoy.FOY_DURUM_ID = (int)AvukatProLib.Extras.FoyDurum.ÝNFAZ_ZAMAN_AÞIMI;
                        break;

                    case (int)Tarihler.TerkinTarihi:
                        MyFoy.FOY_DURUM_ID = (int)AvukatProLib.Extras.FoyDurum.TAKIPSIZ;
                        break;

                    case (int)Tarihler.SemereTarihi:
                        MyFoy.FOY_DURUM_ID = (int)AvukatProLib.Extras.FoyDurum.SEMERESÝZ;
                        break;

                    case (int)Tarihler.IadeTarihi:
                        MyFoy.FOY_DURUM_ID = (int)AvukatProLib.Extras.FoyDurum.ÝADE;
                        break;

                    case (int)Tarihler.FeragatTarihi:
                        MyFoy.FOY_DURUM_ID = (int)AvukatProLib.Extras.FoyDurum.FERAGAT;
                        break;

                    case (int)Tarihler.SulhTarihi:
                        MyFoy.FOY_DURUM_ID = (int)AvukatProLib.Extras.FoyDurum.SULH;
                        break;

                    case (int)Tarihler.KKKTarihi:
                        MyFoy.FOY_DURUM_ID = (int)AvukatProLib.Extras.FoyDurum.KKK;
                        break;

                    default:
                        break;
                }

                #endregion <MB-20100628>

                //Dosyada en az bir tane sorumlu olmasý gerektiðinden, tek avukat olan dosyalarda kullanýcý izleyen mi alanýný iþaretlediðinde bu alanýn false olmasý saðlanýyor. MB
                if (foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Count == 1 && foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.FindAll(vi => !vi.YETKILI_MI).Count == 0)
                    foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection[0].YETKILI_MI = false;

                if (foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>));
                foy.SUBE_KOD_ID = AdimAdimDavaKaydi.Forms.frmKlasorYeni.KullaniciSubeIDGetir(foy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Find(vi => !vi.YETKILI_MI).SORUMLU_AVUKAT_CARI_ID.Value);

                trans.BeginTransaction();

                //AsamaHelper.AsamalariHallet(MyFoy);

                //Taraf Vekil

                #region <MB-20100514> Davacý Taraf Vekili Kayýt

                if (TarafBilgileri != null && TarafBilgileri.DavaEdenler != null)
                {
                    foreach (var taraf in TarafBilgileri.DavaEdenler)
                    {
                        foreach (var trfVekil in taraf.AV001_TD_BIL_FOY_TARAF_VEKILCollection)
                        {
                            if (trfVekil.FOY_TARAF_ID <= 0 && trfVekil.FOY_TARAF_CARI_ID <= 0 ||
                                trfVekil.FOY_TARAF_ID == null)
                            {
                                trfVekil.FOY_TARAF_CARI_ID = taraf.CARI_ID;
                                trfVekil.FOY_TARAF_ID = taraf.ID;
                            }
                        }
                        DataRepository.AV001_TD_BIL_FOY_TARAF_VEKILProvider.Save(trans, taraf.AV001_TD_BIL_FOY_TARAF_VEKILCollection);
                    }
                }

                #endregion <MB-20100514> Davacý Taraf Vekili Kayýt

                #region <MB-20100514> Davalý Taraf Vekili Kayýt

                if (TarafBilgileri != null && TarafBilgileri.DavaEdilenler != null)
                {
                    foreach (var taraf in TarafBilgileri.DavaEdilenler)
                    {
                        foreach (var trfVekil in taraf.AV001_TD_BIL_FOY_TARAF_VEKILCollection)
                        {
                            if (trfVekil.FOY_TARAF_ID <= 0 && trfVekil.FOY_TARAF_CARI_ID <= 0 ||
                                trfVekil.FOY_TARAF_ID == null)
                            {
                                trfVekil.FOY_TARAF_CARI_ID = taraf.CARI_ID;
                                trfVekil.FOY_TARAF_ID = taraf.ID;
                            }
                        }
                        DataRepository.AV001_TD_BIL_FOY_TARAF_VEKILProvider.Save(trans, taraf.AV001_TD_BIL_FOY_TARAF_VEKILCollection);
                    }
                }

                #endregion <MB-20100514> Davalý Taraf Vekili Kayýt

                DataRepository.AV001_TDIE_BIL_ASAMAProvider.DeepSave(trans, MyFoy.AV001_TDIE_BIL_ASAMACollection);

                //Foy
                //aykut
                //DataRepository.AV001_TD_BIL_FOYProvider.DeepSave(trans, foy, DeepSaveType.ExcludeChildren, typeof(TList<NN_DAVA_POLICE>), typeof(TList<AV001_TDI_BIL_POLICE>));

                if (foy.AV001_TD_BIL_DAVA_NEDENCollection.Count == 0)
                    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_DAVA_NEDEN>));

                decimal dava_degeri = 0;

                foreach (AV001_TD_BIL_DAVA_NEDEN item in foy.AV001_TD_BIL_DAVA_NEDENCollection)
                {
                    dava_degeri += item.DAVA_EDILEN_TUTAR;
                }
                foy.DAVA_DEGERI = dava_degeri;

                DataRepository.AV001_TD_BIL_FOYProvider.DeepSave(foy, DeepSaveType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_OZEL_KOD>), typeof(TList<AV001_TD_BIL_FOY_TARAF>), typeof(TList<AV001_TDIE_BIL_BELGE>), typeof(TList<NN_BELGE_DAVA>), typeof(TList<AV001_TDI_BIL_CARI>), typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>));

                //Taraflar
                DataRepository.AV001_TD_BIL_FOY_TARAFProvider.DeepSave(trans, foy.AV001_TD_BIL_FOY_TARAFCollection);

                //Ara Karar
                DataRepository.AV001_TD_BIL_ARA_KARARProvider.Save(trans, foy.AV001_TD_BIL_ARA_KARARCollection);

                //Gereksiz bir iþlem olup olmadýðý Kontrol Edilecek. Merve
                //foreach (AV001_TD_BIL_FOY_TARAF item in MyFoy.AV001_TD_BIL_FOY_TARAFCollection)
                //{
                //    if (item.CARI_IDSource != null)
                //    {
                //        DataRepository.AV001_TDI_BIL_CARIProvider.DeepSave(trans, item.CARI_IDSource,
                //                                                           DeepSaveType.IncludeChildren,
                //                                                           typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
                //    }
                //}
                //foreach (AV001_TD_BIL_FOY_SORUMLU_AVUKAT sorm in MyFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection)
                //{
                //    if (sorm.SORUMLU_AVUKAT_CARI_IDSource != null)
                //        DataRepository.AV001_TDI_BIL_CARIProvider.DeepSave(trans, sorm.SORUMLU_AVUKAT_CARI_IDSource,
                //                                                           DeepSaveType.IncludeChildren,
                //                                                           typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
                //}

                //Celse
                DataRepository.AV001_TD_BIL_CELSEProvider.Save(trans, foy.AV001_TD_BIL_CELSECollection);

                //Düsme Yenileme
                DataRepository.AV001_TD_BIL_DUSME_YENILEMEProvider.Save(trans, foy.AV001_TD_BIL_DUSME_YENILEMECollection);

                //Kanýt
                DataRepository.AV001_TD_BIL_KANITProvider.Save(trans, foy.AV001_TD_BIL_KANITCollection);

                //Teminat Bilgileri
                DataRepository.AV001_TD_BIL_TEMINAT_KEFALETProvider.Save(trans, foy.AV001_TD_BIL_TEMINAT_KEFALETCollection);

                //Temyiz Bilgileri ve Temyiz Taraflarý
                DataRepository.AV001_TD_BIL_TEMYIZProvider.DeepSave(trans, foy.AV001_TD_BIL_TEMYIZCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TD_BIL_TEMYIZ_TARAF>));

                //MuvekkileOdeme
                DataRepository.AV001_TI_BIL_MUVEKKILE_ODEMEProvider.Save(trans, foy.AV001_TI_BIL_MUVEKKILE_ODEMECollectionGetByDAVA_FOY_ID);

                //Meslek Makbuzu
                DataRepository.AV001_TDI_BIL_FATURAProvider.Save(trans, foy.AV001_TDI_BIL_FATURACollection);

                //Poliçe Hasar
                foy.AV001_TDI_BIL_POLICECollection.ForEach(delegate(AV001_TDI_BIL_POLICE police)
                    {
                        DataRepository.AV001_TDI_BIL_POLICE_HASARProvider.Save
                            (trans, police.AV001_TDI_BIL_POLICE_HASARCollection);
                    });

                //Muvekkiltalimat
                DataRepository.AV001_TDIE_BIL_MUVEKKIL_TALIMATProvider.DeepSave(foy.AV001_TDIE_BIL_MUVEKKIL_TALIMATCollection);

                //Poliçe
                DataRepository.AV001_TDI_BIL_POLICEProvider.Save(trans, foy.AV001_TDI_BIL_POLICECollection);

                //Tutuklanma Bilgileri
                DataRepository.AV001_TD_BIL_TUTUKLANMAProvider.Save(trans, foy.AV001_TD_BIL_TUTUKLANMACollection);

                //Dava Nedenine Baglý N-NCollection kayitlari
                foreach (AV001_TD_BIL_DAVA_NEDEN neden in foy.AV001_TD_BIL_DAVA_NEDENCollection)
                {
                    DataRepository.AV001_TD_BIL_DAVA_NEDEN_TARAFProvider.DeepSave(trans, neden.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection);

                    neden.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC.ForEach(delegate(AV001_TDI_BIL_GEMI_UCAK_ARAC obj)
                            {
                                if (neden.AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARACCollection.FindAll(AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARACColumn.GEMI_UCAK_ARAC_ID, obj.ID).Count == 0)
                                {
                                    AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC gua = neden.AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARACCollection.AddNew();
                                    gua.GEMI_UCAK_ARAC_IDSource = obj;
                                }
                            });
                    neden.AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKULCollection.ForEach(delegate(AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL obj)
                        {
                            if (neden.AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKULCollection.FindAll(AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKULColumn.GAYRIMENKUL_ID, obj.GAYRIMENKUL_ID).Count == 0)
                            {
                                AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL gm = neden.AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKULCollection.AddNew();
                                gm.GAYRIMENKUL_IDSource = obj.GAYRIMENKUL_IDSource;
                            }
                        }
                        );
                    neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW.ForEach(delegate(AV001_TDI_BIL_SOZLESME obj)
                        {
                            if (neden.AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEWCollection.FindAll(AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEWColumn.SOZLESME_ID, obj.ID).Count == 0)
                            {
                                AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW sn = neden.AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEWCollection.AddNew();
                                sn.SOZLESME_IDSource = obj;
                            }
                        }
                        );
                    neden.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK.ForEach(delegate(AV001_TDI_BIL_KIYMETLI_EVRAK obj)
                            {
                                if (neden.AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAKCollection.FindAll(AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAKColumn.KIYMETLI_EVRAK_ID, obj.ID).Count == 0)
                                {
                                    AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK ke = neden.AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAKCollection.AddNew();
                                    ke.KIYMETLI_EVRAK_IDSource = obj;
                                }
                            });
                    neden.AV001_TDI_BIL_POLICECollection_From_NN_DAVA_NEDEN_POLICE.ForEach(delegate(AV001_TDI_BIL_POLICE obj)
                        {
                            if (neden.NN_DAVA_NEDEN_POLICECollection.FindAll(NN_DAVA_NEDEN_POLICEColumn.POLICE_ID, obj.ID).Count == 0)
                            {
                                NN_DAVA_NEDEN_POLICE pol = neden.NN_DAVA_NEDEN_POLICECollection.AddNew();
                                pol.POLICE_IDSource = obj;
                            }
                        });
                    //foreach (AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK dNKEvrak in neden.AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAKCollection)
                    //{
                    //    if (foy.NN_DAVA_KIYMETLI_EVRAKCollection.Exists(delegate(NN_DAVA_KIYMETLI_EVRAK kiymetli) { return kiymetli.KIYMETLI_EVRAK_ID == dNKEvrak.KIYMETLI_EVRAK_ID; })) continue;
                    //    NN_DAVA_KIYMETLI_EVRAK kEvrak = foy.NN_DAVA_KIYMETLI_EVRAKCollection.AddNew();
                    //    kEvrak.KIYMETLI_EVRAK_IDSource = dNKEvrak.KIYMETLI_EVRAK_IDSource;
                    //    kEvrak.DAVA_FOY_ID = foy.ID;
                    //}
                    //aykut
                    //foreach (AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC gua in neden.AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARACCollection)
                    //{
                    //    if (foy.NN_DAVA_GEMI_UCAK_ARACCollection.Exists(delegate(NN_DAVA_GEMI_UCAK_ARAC arac) { return arac.GEMI_UCAK_ARAC_ID == gua.GEMI_UCAK_ARAC_ID; })) continue;
                    //    NN_DAVA_GEMI_UCAK_ARAC Igua = foy.NN_DAVA_GEMI_UCAK_ARACCollection.AddNew();
                    //    Igua.GEMI_UCAK_ARAC_IDSource = gua.GEMI_UCAK_ARAC_IDSource;
                    //    Igua.DAVA_FOY_ID = foy.ID;
                    //}

                    DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.Save(MyFoy.AV001_TI_BIL_GAYRIMENKULCollection);

                    foreach (AV001_TI_BIL_GAYRIMENKUL gayrimenkul in MyFoy.AV001_TI_BIL_GAYRIMENKULCollection)
                    {
                        if (foy.NN_DAVA_GAYRIMENKULCollection.Exists(delegate(NN_DAVA_GAYRIMENKUL gayrimen) { return gayrimen.GAYRIMENKUL_ID == gayrimenkul.ID; })) continue;
                        NN_DAVA_GAYRIMENKUL Igayrimenkul = foy.NN_DAVA_GAYRIMENKULCollection.AddNew();
                        Igayrimenkul.GAYRIMENKUL_IDSource = gayrimenkul;
                        Igayrimenkul.DAVA_FOY_ID = foy.ID;
                    }
                    foreach (AV001_TDI_BIL_SOZLESME sozlesme in neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW)
                    {
                        if (foy.NN_DAVA_SOZLESMECollection.Exists(delegate(NN_DAVA_SOZLESME sozles) { return sozles.SOZLESME_ID == sozlesme.ID; }))
                            continue;
                        NN_DAVA_SOZLESME soz = foy.NN_DAVA_SOZLESMECollection.AddNew();
                        soz.SOZLESME_IDSource = sozlesme;
                        soz.DAVA_FOY_ID = foy.ID;
                    }
                    foreach (NN_DAVA_NEDEN_POLICE police in neden.NN_DAVA_NEDEN_POLICECollection)
                    {
                        if (foy.NN_DAVA_POLICECollection.Exists(delegate(NN_DAVA_POLICE pol) { return pol.POLICE_ID == police.POLICE_ID; })) continue;
                        NN_DAVA_POLICE poli = foy.NN_DAVA_POLICECollection.AddNew();
                        poli.POLICE_IDSource = police.POLICE_IDSource;
                        poli.DAVA_FOY_ID = foy.ID;
                    }
                }

                foreach (AV001_TDI_BIL_GEMI_UCAK_ARAC gua in foy.AV001_TDI_BIL_GEMI_UCAK_ARACCollection)
                {
                    if (foy.NN_DAVA_GEMI_UCAK_ARACCollection.Exists(delegate(NN_DAVA_GEMI_UCAK_ARAC arac) { return arac.GEMI_UCAK_ARAC_ID == gua.ID; })) continue;
                    NN_DAVA_GEMI_UCAK_ARAC Igua = foy.NN_DAVA_GEMI_UCAK_ARACCollection.AddNew();
                    Igua.GEMI_UCAK_ARAC_ID = gua.ID;
                    Igua.DAVA_FOY_ID = foy.ID;
                }

                DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepSave(trans, foy.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_DAVA_KIYMETLI_EVRAK, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>));

                foreach (AV001_TDI_BIL_KIYMETLI_EVRAK dNKEvrak in foy.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_DAVA_KIYMETLI_EVRAK)
                {
                    if (foy.NN_DAVA_KIYMETLI_EVRAKCollection.Exists(delegate(NN_DAVA_KIYMETLI_EVRAK kiymetli) { return kiymetli.KIYMETLI_EVRAK_ID == dNKEvrak.ID; })) continue;
                    NN_DAVA_KIYMETLI_EVRAK kEvrak = foy.NN_DAVA_KIYMETLI_EVRAKCollection.AddNew();
                    kEvrak.KIYMETLI_EVRAK_ID = dNKEvrak.ID;
                    kEvrak.DAVA_FOY_ID = foy.ID;
                }

                //if (lueOzelKod4.EditValue != null)
                //    foy.DAVA_OZEL_KOD4_ID = (int)lueOzelKod4.EditValue;

                //DavaNeden-Taraf-Faiz
                DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.DeepSave(trans, foy.AV001_TD_BIL_DAVA_NEDENCollection, DeepSaveType.ExcludeChildren, typeof(TList<AV001_TD_BIL_DAVA_NEDEN_TARAF>), typeof(TList<AV001_TD_BIL_DAVA_NEDEN_TARAF_FAIZ>), typeof(TList<AV001_TD_BIL_DAVA_NEDEN_SOZLESME>), typeof(TList<AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW>), typeof(TList<NN_DAVA_NEDEN_POLICE>));

                DataRepository.AV001_TD_BIL_FOYProvider.DeepSave(trans, foy, DeepSaveType.IncludeChildren, typeof(TList<NN_DAVA_GAYRIMENKUL>), typeof(TList<NN_DAVA_GEMI_UCAK_ARAC>), typeof(TList<NN_DAVA_KIYMETLI_EVRAK>), typeof(TList<NN_DAVA_POLICE>), typeof(TList<NN_DAVA_SOZLESME>), typeof(TList<AV001_TDIE_BIL_ASAMA>), typeof(TList<NN_DAVA_NEDEN_POLICE>));

                //tebligatlarýn esas no düzenlemeleri

                var tebligats = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByDAVA_FOY_ID(MyFoy.ID);

                foreach (var item in tebligats)
                {
                    item.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
                    item.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
                    item.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
                    item.TEBLIGAT_ESAS_NO = MyFoy.ESAS_NO;
                }
                //Tebligat
                DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(trans, tebligats);

                //---------------------------------//

                trans.Commit();

                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                cn.AddParams("@KAZANMA_ORANI", spinKazanmaOrani.EditValue);
                cn.AddParams("@BEKLENEN_BITIS_TARIHI", dateBeklenenBitisTarihi.EditValue);
                cn.AddParams("@ID", MyFoy.ID);
                try
                {
                    cn.ExcuteQuery("update dbo.AV001_TD_BIL_FOY set KAZANMA_ORANI=@KAZANMA_ORANI, BEKLENEN_BITIS_TARIHI=@BEKLENEN_BITIS_TARIHI WHERE ID=@ID");
                }
                catch { ;}
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                DevExpress.XtraEditors.XtraMessageBox.Show("Kaydetme iþlemi bir hatayla karþýlaþtý" + System.Environment.NewLine + ex.Message, "Kaydet");
                return false;
            }
            return true;
        }

        private void frmOzelKod_FormClosed(object sender, FormClosedEventArgs e)
        {
            BindOzelKod();
        }

        private void LoadData()
        {
            AvukatPro.Services.Implementations.DevExpressService.FoyDurumDoldur(lueFoyDurum);
            BelgeUtil.Inits.AdliBirimBolumDoldur(lueDavaTip.Properties);

            //int[] id = new int[] { 3, 4, 8, 83, 34, 35, 36 };-->eskisinde
            BelgeUtil.Inits.DavaTalepGetir(lueDavaTalep);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeDoldur(lueAdliBirimAdliye);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeNoDoldur(lueAdliBirimNo);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeGorevDoldur(lueGorev);
            AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(lueSegmnet);
            BelgeUtil.Inits.MahkemeIadeNedeniGetir(lueIadeNeden.Properties);
            BelgeUtil.Inits.DovizTipGetir(lueDavaDegeriDoviz);
            BelgeUtil.Inits.ParaBicimiAyarla(spDavaDegeri);
            BelgeUtil.Inits.TemyizTipGetir(lueKanunYolu);
            BindOzelKod();
            lueOzelKod1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod1_ButtonClick);
            lueOzelKod2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod1_ButtonClick);
            lueOzelKod3.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod1_ButtonClick);
            lueOzelKod4.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod1_ButtonClick);
            bndDavaFoy_CurrentChanged(0, new EventArgs());
            DavaDefaultGetir();

            #region <MB-20100525>

            //Klasör Grubunda Doldurulan Lookup'lar
            if (MyProje != null)
            {
                BelgeUtil.Inits.perCariGetir(rlueKlasorSorumlu);
                BelgeUtil.Inits.ProjeOzelKodGetir(lueSube.Properties);
            }

            #endregion <MB-20100525>

            #region <MB-20100624>

            //Takip Ekraný üzerinde Hüküm, Temyiz, Duruþma, Föy ile ilgili istenilen bilgilerin gelmesi için eklendi.

            if (MyFoy == null) return;

            #region Hüküm

            List<AvukatProLib.Arama.per_AV001_TD_BIL_MAHKEME_HUKUM> hukumler = BelgeUtil.Inits.context.per_AV001_TD_BIL_MAHKEME_HUKUMs.Where(vi => vi.DAVA_FOY_ID == MyFoy.ID).ToList();
            if (hukumler != null && hukumler.Count > 0)
            {
                AvukatProLib.Arama.per_AV001_TD_BIL_MAHKEME_HUKUM hukum = hukumler.OrderByDescending(vi => vi.HUKUM_TARIHI).FirstOrDefault();

                txtKararT.EditValue = hukum.HUKUM_TARIHI.ToString();
                txtKararNo.EditValue = hukum.KARAR_NO;
            }

            #endregion Hüküm

            #region Temyiz

            List<AvukatProLib.Arama.per_AV001_TD_BIL_TEMYIZ> temyizler = BelgeUtil.Inits.context.per_AV001_TD_BIL_TEMYIZs.Where(vi => vi.DAVA_FOY_ID == MyFoy.ID).ToList();
            if (temyizler != null && temyizler.Count > 0)
            {
                AvukatProLib.Arama.per_AV001_TD_BIL_TEMYIZ temyiz = temyizler.OrderByDescending(vi => vi.KARAR_TARIHI).FirstOrDefault();

                txtTemyizT.EditValue = temyiz.KARAR_TARIHI;
                lueKanunYolu.EditValue = temyiz.TEMYIZ_TIP_ID;
            }

            #endregion Temyiz

            #region Duruþma-Keþif

            List<AvukatProLib.Arama.per_AV001_TD_BIL_CELSE> celseler = BelgeUtil.Inits.context.per_AV001_TD_BIL_CELSEs.Where(vi => vi.DAVA_FOY_ID == MyFoy.ID).ToList();

            if (celseler != null && celseler.Count > 0)
            {
                var celseOlanlar = celseler.Where(vi => vi.CELSE_MI);

                if (celseOlanlar != null && celseOlanlar.Count() > 0)
                {
                    AvukatProLib.Arama.per_AV001_TD_BIL_CELSE celse = celseOlanlar.OrderByDescending(vi => vi.TARIH).FirstOrDefault();
                    txtSonDurusmaT.EditValue = celse.TARIH.ToString();
                }

                var celseOlmayanlar = celseler.Where(vi => !vi.CELSE_MI);

                if (celseOlmayanlar != null && celseOlmayanlar.Count() > 0)
                {
                    AvukatProLib.Arama.per_AV001_TD_BIL_CELSE kesif = celseOlmayanlar.OrderByDescending(vi => vi.TARIH).FirstOrDefault();
                    txtSonKesifT.EditValue = kesif.TARIH.ToString();
                }
            }

            #endregion Duruþma-Keþif

            #region Dava Deðeri

            //if (MyFoy.DAVA_TIP_ID == (int)AdimAdimDavaKaydi.DavaTakip.GelismeHelper.DavaTip.Ceza || MyFoy.DAVA_TIP_ID == (int)AdimAdimDavaKaydi.DavaTakip.GelismeHelper.DavaTip.AsCeza || MyFoy.DAVA_TIP_ID == (int)AdimAdimDavaKaydi.DavaTakip.GelismeHelper.DavaTip.Icra_Ceza)
            //{
            //    lcItemDavaDegeri.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //    lcItemDavaDegeriDoviz.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //}
            //else
            //{
            TList<AV001_TD_BIL_DAVA_NEDEN> davaNedenleri =
                DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.GetByDAVA_FOY_ID(MyFoy.ID);
            decimal davaTutari = 0;

            if (davaNedenleri != null && davaNedenleri.Count > 0)
            {
                //Föy üzerindeki dava deðeri alaný çalýþma sýrasýnda 0 geldiði için ForEach ile yapýlmak zorunda kalýndý.
                davaNedenleri.ForEach(neden =>
                {
                    if (neden.TUTAR_DOVIZ_ID == 1)
                        davaTutari += neden.TUTAR;
                    else
                    {
                        neden.TUTAR = AvukatProLib.Hesap.DovizHelper.CevirYTL(neden.TUTAR, neden.TUTAR_DOVIZ_ID, DateTime.Now);
                        davaTutari += neden.TUTAR;
                    }
                });
            }

            spDavaDegeri.EditValue = davaTutari;
            lueDavaDegeriDoviz.EditValue = 1; //TL

            //}

            #endregion Dava Deðeri

            #endregion <MB-20100624>

            if (BelgeUtil.Inits.PaketAdi != 1) layoutControlGroup5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void lueOzelKod1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == "ekle")
            {
                AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle frm = new AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle();
                frm.Show();
                frm.FormClosed += new FormClosedEventHandler(frmOzelKod_FormClosed);
            }
        }

        //private void FoyIhtiyatiTedbirBilgileri()
        //{
        //    if (MyFoy.AV001_TD_BIL_FOY_TARAFCollection.Count == 0
        //        && MyFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
        //    {
        //        DevExpress.XtraEditors.XtraMessageBox.Show(
        //            "Ýhtiyati Tedbir girebilmek için taraflarýn ve sorumlu avukatlarýn eklenmiþ olmasý gerekmektedir",
        //            "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    if (MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection == null)
        //        MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>();
        //    MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.AddingNew += AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_AddingNew;
        //    if (MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.Count <= 0)
        //        MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.AddNew();
        //    frmDavaIcraIhtiyatiTedbir frm = new frmDavaIcraIhtiyatiTedbir();
        //    frm.MyDavaFoy = MyFoy;
        //    frm.MyDataSource = MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;

        //    //frm.MdiParent = null;
        //    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
        //    frm.Show();
        //}

        //private void AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_AddingNew(object sender, AddingNewEventArgs e)
        //{
        //    AV001_TDI_BIL_IHTIYATI_TEDBIR tdbr = e.NewObject as AV001_TDI_BIL_IHTIYATI_TEDBIR;
        //    if (tdbr == null)
        //        tdbr = new AV001_TDI_BIL_IHTIYATI_TEDBIR();
        //    tdbr.ADLI_BIRIM_GOREV_ID = DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.Find("GOREV = 'AHM'")[0].ID;
        //    tdbr.TALEP_TARIHI = MyFoy.DAVA_TARIHI.Value;
        //    tdbr.KARAR_TARIHI = tdbr.TALEP_TARIHI;
        //    tdbr.TEMINAT_TUR_ID = 1;
        //    tdbr.TEMINAT_TUTARI_DOVIZ_ID = 1;
        //    tdbr.TEMINAT_TUTARI = MyFoy.DAVA_DEGERI * (decimal)0.10; // TODO:Kullanýcý seçenekleri.. Oransal
        //    tdbr.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF>();
        //    foreach (AV001_TD_BIL_FOY_TARAF taraf in MyFoy.AV001_TD_BIL_FOY_TARAFCollection)
        //    {
        //        if (taraf.TARAF_SIFAT_ID == 7)
        //        {
        //            AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF trf = tdbr.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection.AddNew();
        //            trf.ICRA_CARI_TARAF_ID = taraf.CARI_ID;
        //            trf.ICRA_TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
        //        }
        //    }
        //    tdbr.KAYIT_TARIHI = DateTime.Now;
        //    tdbr.KONTROL_NE_ZAMAN = DateTime.Now;
        //    tdbr.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
        //    tdbr.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
        //    tdbr.STAMP = AvukatProLib.Kimlik.DefaultStamp;
        //    tdbr.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
        //    e.NewObject = tdbr;
        //}

        //private void TakipAsamasiDoldur(AV001_TD_BIL_FOY foy)
        //{
        //    TList<TDIE_KOD_ASAMA> kodAsamaList = new TList<TDIE_KOD_ASAMA>();
        //    if (foy.AV001_TDIE_BIL_ASAMACollection != null)
        //    {
        //        foreach (AV001_TDIE_BIL_ASAMA asm in foy.AV001_TDIE_BIL_ASAMACollection)
        //        {
        //            if (asm.ASAMA_KOD_IDSource == null)
        //            {
        //                DataRepository.AV001_TDIE_BIL_ASAMAProvider.DeepLoad(asm, true, DeepLoadType.IncludeChildren, typeof(TDIE_KOD_ASAMA));
        //            }
        //            kodAsamaList.Add(asm.ASAMA_KOD_IDSource);
        //        }
        //    }

        //    txtTakipAsamasi.Properties.NullText = "Takip Aþamasý Yok";

        //    if (kodAsamaList.Count > 0)
        //    {
        //        kodAsamaList.Sort("SIRA_NO DESC");

        //        txtTakipAsamasi.Text = kodAsamaList[0].ASAMA_ADI;
        //        txtTakipAsamasi.ToolTip = kodAsamaList[0].ASAMA_ADI;
        //        txtTakipAsamasi.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
        //        txtTakipAsamasi.ToolTipTitle = "Dosya Aþamasý";
        //    }
        //}

        #region IslemMetotlari

        public static void SonHesapTarihiKontrolu(AV001_TD_BIL_FOY myFoy)
        {
            if (myFoy != null && myFoy.SON_HESAP_TARIHI != DateTime.Today)
            {
                var tercih =
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        string.Format("Hesaba Esas Tarih : {0}\nGünün Tarihi Ýle Deðiþtirilsin mi?",
                                      myFoy.SON_HESAP_TARIHI), "Hesaplama Parametresi", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (tercih == DialogResult.Yes)
                {
                    myFoy.SON_HESAP_TARIHI = DateTime.Today;
                }
            }
        }

        private void EditorYolla()
        {
            AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor editor = new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor();
            editor.Show();
        }

        private void FoyCikis()
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show("Çýkmak istediðinizden emin misiniz ?", "Dava Takip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Close();
        }

        private void FoyuKaydet()
        {
            if (DavaFoyKaydet(MyFoy))
            {
                //Takip ekranýndaki kaydetten otomatik iþ üretilmesi kaldýrýldý.
                //Otomatik iþ Celse kaydý sýrasýnda üretilecek hale getirildi.
                //if (IsHelper.IsleriKaydet(MyFoy))
                //{
                DevExpress.XtraEditors.XtraMessageBox.Show("Kaydetme iþlemi tamamlandý.", "Kaydet");

                //TakipAsamasiDoldur(MyFoy);
                //}
            }
        }

        private void ucBelgeKayitUfak1_BelgeKaydedildi(object sender, AdimAdimDavaKaydi.Belge.UserControls.ucBelgeKayitUfak.BelgeKaydedildiEventArgs e)
        {
            if (e.Belge != null)
            {
                if (BelgeUtil.Inits._BelgeGetir == null)
                    BelgeUtil.Inits._BelgeGetir = BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.ToList();
                else
                    BelgeUtil.Inits._BelgeGetir.Add(BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.Where(vi => vi.ID == e.Belge.ID).FirstOrDefault());

                DavaCore.ucDavaGridler1.belge.RefreshGridDataSource(e.Belge);
            }
        }

        private void YeniFoy()
        {
            frmDavaDosyaKayitForm frm = new frmDavaDosyaKayitForm();
            if (DavaDosyaKayitTiklandi != null)
                DavaDosyaKayitTiklandi(this, new FrmDavaDosyaKayitEventArgs(frm));
            frm.Show();
        }

        #endregion IslemMetotlari

        #region Open Word Document

        //protected void WordApp_DocumentBeforeSave(Microsoft.Office.Interop.Word.Document doc, ref bool I, ref bool II)
        //{
        //}

        private Microsoft.Office.Interop.Word.Document adoc;

        private Microsoft.Office.Interop.Word.ApplicationClass WordApp;

        protected void WordApp_DocumentBeforeClose(Microsoft.Office.Interop.Word.Document doc, ref bool I)
        {
            
            if (!doc.Saved)
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Döküman kaydedilmedi. Kaydetmek istiyormusunuz?", "Uyarý", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    doc.Save();

            if (doc.Saved)
            {
                string fileName = doc.FullName;

                object saveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdPromptToSaveChanges;
                object originalFormat = Microsoft.Office.Interop.Word.WdOriginalFormat.wdWordDocument;
                object routeDocument = true;

                doc.Close(ref saveChanges, ref originalFormat, ref routeDocument);

                //WordApp.Quit(ref saveChanges, ref originalFormat, ref routeDocument);
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Ýletiyi dosyayla iliþkilendirmek ister misiniz?", "AvukatPro", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                {
                    AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak belge = new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak();
                    TList<AV001_TDIE_BIL_BELGE> lstbelge = new TList<AV001_TDIE_BIL_BELGE>();
                    AV001_TDIE_BIL_BELGE blg = new AV001_TDIE_BIL_BELGE();
                    blg.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();
                    blg.BELGEYI_YAZAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
                    blg.BELGE_TUR_ID = 7;
                    blg.SUC_OLAY_VADE_TARIHI = DateTime.Now;
                    blg.YAZILMA_TARIHI = DateTime.Now;
                    blg.BELGE_NO = ucBelgeKayitUfak.BelgeNoGetir();
                    blg.BELGE_ADI = System.IO.Path.GetFileName(fileName);
                    blg.DOSYA_ADI = fileName;
                    blg.DOKUMAN_UZANTI = new System.IO.FileInfo(fileName).Extension.Substring(1);
                    blg.STAMP = 0;
                    if (System.IO.File.Exists(fileName))
                    {
                        try
                        {
                            System.IO.FileStream fss = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
                            byte[] veri = new byte[fss.Length];
                            fss.Read(veri, 0, veri.Length);
                            blg.ICERIK = veri;
                            fss.Close();

                            //System.IO.File.Delete(fileName);
                        }
                        catch { }
                    }

                    blg.ESAS_NO = MyFoy.ESAS_NO;
                    blg.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
                    blg.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
                    blg.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
                    lstbelge.Add(blg);

                    switch (MyFoy.TableName)
                    {
                        case "AV001_TI_BIL_FOY":
                            belge.ucBelgeKayitUfak1.ModulID = 1;
                            break;

                        case "AV001_TD_BIL_FOY":
                            belge.ucBelgeKayitUfak1.ModulID = 2;
                            break;

                        case "AV001_TD_BIL_HAZIRLIK":
                            belge.ucBelgeKayitUfak1.ModulID = 3;
                            break;

                        case "AV001_TDI_BIL_SOZLESME":
                            belge.ucBelgeKayitUfak1.ModulID = 5;
                            break;

                        case "AV001_TDIE_BIL_PROJE":
                            belge.ucBelgeKayitUfak1.ModulID = 11; //Klasör
                            break;

                        default:
                            break;
                    }

                    belge.MyDataSource = lstbelge;
                    belge.OpenedRecord = MyFoy;
                    belge.Record = lstbelge[0];

                    //       belge.ucBelgeKayitUfak1.Saved += ucBelgeKayitUfak1_Saved;
                    belge.ucBelgeKayitUfak1.Duzenle = true;
                    belge.ucBelgeKayitUfak1.BelgeKaydedildi += new EventHandler<AdimAdimDavaKaydi.Belge.UserControls.ucBelgeKayitUfak.BelgeKaydedildiEventArgs>(ucBelgeKayitUfak1_BelgeKaydedildi);

                    belge.ucBelgeKayitUfak1.KayitIlistir(null, null);
                    belge.ucBelgeKayitUfak1.c_lueModul.Enabled = false;
                    belge.ucBelgeKayitUfak1.c_lueDosya.Enabled = false;
                    belge.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    belge.MdiParent = null;
                    belge.ShowDialog();
                }
            }
        }

        private void WordAc()
        {
            object missing = System.Reflection.Missing.Value;
            //object Visible = true;
            object start1 = 0;
            //object end1 = 0;
            WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
            adoc = WordApp.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            Microsoft.Office.Interop.Word.Range rng = adoc.Range(ref start1, ref missing);
            //WordApp.DocumentBeforeSave += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeSaveEventHandler(WordApp_DocumentBeforeSave);
            WordApp.DocumentBeforeClose += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeCloseEventHandler(WordApp_DocumentBeforeClose);
            try
            {
                //adoc.Save();
                adoc.SaveAs2();
                WordApp.Visible = true;
            }
            catch { }
        }

        #endregion Open Word Document

        #region Open Excel WorkBook (ARCH)

        private Microsoft.Office.Interop.Excel.Application app = null;
        private bool controller = false;
        private Microsoft.Office.Interop.Excel.Workbook workbook = null;
        private Microsoft.Office.Interop.Excel.Worksheet worksheet = null;

        protected void app_WorkbookBeforeClose(Microsoft.Office.Interop.Excel.Workbook wb, ref bool I)
        {
            if (controller)
            {
                controller = false;
                return;
            }

            controller = true;

            if (!wb.Saved)
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Döküman kaydedilmedi. Kaydetmek istiyormusunuz?", "Uyarý", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    wb.SaveAs();

            string filename = wb.FullName;
            if (wb.Saved && !string.IsNullOrEmpty(wb.FullName.Trim()))
            {
                wb.Close(false, "ddddd", false);

                if (DevExpress.XtraEditors.XtraMessageBox.Show("Ýletiyi dosyayla iliþkilendirmek ister misiniz?", "AvukatPro", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                {
                    AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak belge = new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak();
                    TList<AV001_TDIE_BIL_BELGE> lstbelge = new TList<AV001_TDIE_BIL_BELGE>();
                    AV001_TDIE_BIL_BELGE blg = new AV001_TDIE_BIL_BELGE();
                    blg.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();
                    blg.BELGEYI_YAZAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
                    blg.BELGE_TUR_ID = 7;
                    blg.SUC_OLAY_VADE_TARIHI = DateTime.Now;
                    blg.YAZILMA_TARIHI = DateTime.Now;
                    blg.BELGE_NO = ucBelgeKayitUfak.BelgeNoGetir();
                    blg.BELGE_ADI = System.IO.Path.GetFileName(filename);
                    blg.DOSYA_ADI = filename;
                    blg.DOKUMAN_UZANTI = new System.IO.FileInfo(filename).Extension.Substring(1);
                    blg.STAMP = 0;

                    if (System.IO.File.Exists(filename))
                    {
                        try
                        {
                            System.IO.FileStream fss = new System.IO.FileStream(filename, System.IO.FileMode.Open);
                            byte[] veri = new byte[fss.Length];
                            fss.Read(veri, 0, veri.Length);
                            blg.ICERIK = veri;
                            fss.Close();

                            //System.IO.File.Delete(fileName);
                        }
                        catch  { }
                    }

                    blg.ESAS_NO = MyFoy.ESAS_NO;
                    blg.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
                    blg.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
                    blg.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
                    lstbelge.Add(blg);

                    switch (MyFoy.TableName)
                    {
                        case "AV001_TI_BIL_FOY":
                            belge.ucBelgeKayitUfak1.ModulID = 1;
                            break;

                        case "AV001_TD_BIL_FOY":
                            belge.ucBelgeKayitUfak1.ModulID = 2;
                            break;

                        case "AV001_TD_BIL_HAZIRLIK":
                            belge.ucBelgeKayitUfak1.ModulID = 3;
                            break;

                        case "AV001_TDI_BIL_SOZLESME":
                            belge.ucBelgeKayitUfak1.ModulID = 5;
                            break;

                        case "AV001_TDIE_BIL_PROJE":
                            belge.ucBelgeKayitUfak1.ModulID = 11; //Klasör
                            break;

                        default:
                            break;
                    }

                    belge.MyDataSource = lstbelge;
                    belge.OpenedRecord = MyFoy;
                    belge.Record = lstbelge[0];
                    belge.ucBelgeKayitUfak1.Duzenle = true;
                    belge.ucBelgeKayitUfak1.BelgeKaydedildi += ucBelgeKayitUfak1_BelgeKaydedildi;
                    belge.ucBelgeKayitUfak1.KayitIlistir(null, null);
                    belge.ucBelgeKayitUfak1.c_lueModul.Enabled = false;
                    belge.ucBelgeKayitUfak1.c_lueDosya.Enabled = false;
                    belge.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    belge.MdiParent = null;
                    belge.ShowDialog();
                }
            }
            else app.Quit();
        }

        private void ExcelAc()
        {
            try
            {
                app = new Microsoft.Office.Interop.Excel.Application();
                app.WorkbookBeforeClose += new Microsoft.Office.Interop.Excel.AppEvents_WorkbookBeforeCloseEventHandler(app_WorkbookBeforeClose);
                app.Visible = true;
                workbook = app.Workbooks.Add(1);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                workbook.Save();
            }
            catch  { }
        }

        #endregion Open Excel WorkBook (ARCH)

        #region Open Outlook Message (ARCH)

        public bool Mode { get; set; }

        public string Subject { get; set; }

        private void IliskiliDosya()
        {
            AdimAdimDavaKaydi.Forms.frmKayitIliski frm = new AdimAdimDavaKaydi.Forms.frmKayitIliski();
            frm.MyDavaFoy = MyFoy;
            frm.FormClosed += frm_FormClosed;
            frm.Show();
        }

        private void objOutlook_ItemSend(object item, ref bool cancel)
        {
            Subject = ((Microsoft.Office.Interop.Outlook.MailItem)item).Subject;
            ((Microsoft.Office.Interop.Outlook.MailItem)item).SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\temporary.msg", Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
            Mode = true;
        }

        private void OutlookAc()
        {
            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\temporary.msg";
            Microsoft.Office.Interop.Outlook.Application objOutlook = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem mic = (Microsoft.Office.Interop.Outlook.MailItem)(objOutlook.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem));

            StringBuilder sb = new StringBuilder();
            if (MyFoy.DAVA_TALEP_ID.HasValue)
                sb.Append(AvukatPro.Services.Implementations.DosyaService.GetTakipTalepById((int)MyFoy.DAVA_TALEP_ID));
            if (MyFoy.ADLI_BIRIM_ADLIYE_ID.HasValue)
                sb.Append(" - " + AvukatPro.Services.Implementations.DosyaService.GetAdliBirimAdliyeById((int)MyFoy.ADLI_BIRIM_ADLIYE_ID));
            if (MyFoy.ADLI_BIRIM_NO_ID.HasValue)
                sb.Append(" / " + AvukatPro.Services.Implementations.DosyaService.GetAdliBirimNoById((int)MyFoy.ADLI_BIRIM_NO_ID));
            if (MyFoy.ADLI_BIRIM_GOREV_ID.HasValue)
                sb.Append(" / " + AvukatPro.Services.Implementations.DosyaService.GetAdliBirimGorevById((int)MyFoy.ADLI_BIRIM_GOREV_ID));

            sb.Append(" - " + MyFoy.ESAS_NO);
            mic.Subject = sb.ToString();

            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_TARAF>));
            var u = MyFoy.AV001_TD_BIL_FOY_TARAFCollection;
            string emails = "";
            AV001_TDI_BIL_CARI ins = new AV001_TDI_BIL_CARI();
            for (int run = 0; run < u.Count; run++)
            {
                ins = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(u[run].CARI_ID.Value);
                if (!String.IsNullOrEmpty(ins.EMAIL_1))
                    emails += ins.EMAIL_1 + "; ";
                if (!String.IsNullOrEmpty(ins.EMAIL_2))
                    emails += ins.EMAIL_2 + "; ";
            }
            if (emails.Length > 2)
                mic.To = emails.Substring(0, emails.Length - 2);

            objOutlook.ItemSend += new Microsoft.Office.Interop.Outlook.ApplicationEvents_11_ItemSendEventHandler(objOutlook_ItemSend);

            mic.Display(true);

            bool control = false;
            try { bool g = mic.Saved; control = g; }
            catch { control = false; }

            if (Mode || control)
            {
                if (!Mode && control)
                    mic.SaveAs(fileName, Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG);
                Mode = control = false;
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Ýletiyi dosyayla iliþkilendirmek ister misiniz?", "AvukatPro", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                {
                    using (AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak belge = new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak())
                    {
                        TList<AV001_TDIE_BIL_BELGE> lstbelge = new TList<AV001_TDIE_BIL_BELGE>();
                        AV001_TDIE_BIL_BELGE blg = new AV001_TDIE_BIL_BELGE();
                        blg.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();
                        blg.BELGEYI_YAZAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
                        blg.BELGE_TUR_ID = 20;
                        blg.SUC_OLAY_VADE_TARIHI = DateTime.Now;
                        blg.YAZILMA_TARIHI = DateTime.Now;
                        blg.BELGE_NO = ucBelgeKayitUfak.BelgeNoGetir();
                        blg.BELGE_ADI = Subject;
                        Subject = "";
                        blg.DOSYA_ADI = fileName;
                        blg.DOKUMAN_UZANTI = new System.IO.FileInfo(fileName).Extension.Substring(1);
                        blg.STAMP = 0;

                        if (System.IO.File.Exists(fileName))
                        {
                            System.IO.FileStream fss = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
                            byte[] veri = new byte[fss.Length];
                            fss.Read(veri, 0, veri.Length);
                            blg.ICERIK = veri;
                            fss.Close();
                            System.IO.File.Delete(fileName);
                        }

                        blg.ESAS_NO = MyFoy.ESAS_NO;
                        blg.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
                        blg.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
                        blg.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
                        lstbelge.Add(blg);

                        switch (MyFoy.TableName)
                        {
                            case "AV001_TI_BIL_FOY":
                                belge.ucBelgeKayitUfak1.ModulID = 1;
                                break;

                            case "AV001_TD_BIL_FOY":
                                belge.ucBelgeKayitUfak1.ModulID = 2;
                                break;

                            case "AV001_TD_BIL_HAZIRLIK":
                                belge.ucBelgeKayitUfak1.ModulID = 3;
                                break;

                            case "AV001_TDI_BIL_SOZLESME":
                                belge.ucBelgeKayitUfak1.ModulID = 5;
                                break;

                            case "AV001_TDIE_BIL_PROJE":
                                belge.ucBelgeKayitUfak1.ModulID = 11; //Klasör
                                break;

                            default:
                                break;
                        }

                        belge.MyDataSource = lstbelge;
                        belge.OpenedRecord = MyFoy;
                        belge.Record = lstbelge[0];

                        belge.ucBelgeKayitUfak1.Duzenle = true;
                        belge.ucBelgeKayitUfak1.BelgeKaydedildi += ucBelgeKayitUfak1_BelgeKaydedildi;
                        belge.ucBelgeKayitUfak1.KayitIlistir(null, null);
                        belge.ucBelgeKayitUfak1.c_lueModul.Enabled = false;
                        belge.ucBelgeKayitUfak1.c_lueDosya.Enabled = false;
                        belge.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        belge.MdiParent = null;
                        belge.ShowDialog();
                    }
                }
            }
        }

        private void PdfAc()
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pdf);
        }

        //private void FoyYazdir()
        //{
        //    ArrayList secilenIndexler = new ArrayList();
        //    foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in cbSablonlar.Properties.Items)
        //    {
        //        if (item.CheckState == CheckState.Checked)
        //        {
        //            secilenIndexler.Add(item.ToString());
        //        }
        //    }

        //    StringBuilder sb = new StringBuilder();
        //    foreach (string s in secilenIndexler)
        //    {
        //        sb.Append("* " + s);
        //        sb.Append(Environment.NewLine);
        //    }

        //    MessageBox.Show("Seçilen Yazdýrma Ýstekleri " + Environment.NewLine + Environment.NewLine + sb);
        //}

        #endregion Open Outlook Message (ARCH)

        #endregion Methods

        #region Events

        private void bndDavaFoy_CurrentChanged(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(int))
                return;
            MyFoy = bndDavaFoy.Current as AV001_TD_BIL_FOY;
            DataChange();
        }

        private void c_bbAjanda_ItemClick(object sender, EventArgs e)
        {
            #region <MB-20100427> Dosya Ajandasý Yeniden Düzenlendi.

            //Kullanýcýnýn o dosyada sorumlu avukat olup olmadýðý kontrolü yapýlýyor.
            TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT> dosyaSorumluAvukatlari =
                DataRepository.AV001_TD_BIL_FOY_SORUMLU_AVUKATProvider.GetByDAVA_FOY_ID(MyFoy.ID);
            bool kullaniciDosyadaSorumluAvukat = false;

            foreach (var item in dosyaSorumluAvukatlari)
            {
                if (item.SORUMLU_AVUKAT_CARI_ID == AvukatProLib.Kimlik.Bilgi.CARI_ID.Value)
                {
                    kullaniciDosyadaSorumluAvukat = true;
                    break;
                }
                else
                    kullaniciDosyadaSorumluAvukat = false;
            }

            if (!kullaniciDosyadaSorumluAvukat)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Dosyada Sorumlu Avukat olmadýðýnýz için" + Environment.NewLine + "gösterilecek iþleriniz yok.",
                    "BÝLGÝ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Kullanýcýnýn Dosyadaki iþlerini buluyor.
            var isler = BelgeUtil.Inits.context.per_AV001_TDI_BIL_IS_Asistans.Where(item => BelgeUtil.Inits.context.NN_IS_DAVA_FOYs.Where(dava => dava.DAVA_FOY_ID == MyFoy.ID).Select(t => t.IS_ID).Contains(item.ID) && item.AJANDADA_GORUNSUN_MU && BelgeUtil.Inits.context.AV001_TDI_BIL_IS_TARAFs.Where(c => c.CARI_ID == AvukatProLib.Kimlik.Bilgi.CARI_ID && c.IS_TARAF_ID == 2).Select(vi => vi.IS_ID).Contains(item.ID)).ToList();

            //Dosyanýn iliþkili olduðu dosyalarýn iþlerini buluyor.
            AV001_TDI_BIL_KAYIT_ILISKI iliski =
                DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByILISKI_TUR_IDKAYNAK_KAYIT_ID(
                    (int?)AvukatProLib.Extras.KayitIliskiTur.DAVA_DOSYASI, MyFoy.ID);
            if (iliski != null)
            {
                TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> iliskiDetaylari =
                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByKAYIT_ILISKI_ID(iliski.ID);
                IcraTakipForms._frmIcraTakip.KayitIliskiDetayIsleriGetir(iliskiDetaylari, isler);
            }
            else
            {
                TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> iliskiDetaylari =
                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_KAYIT_ID(MyFoy.ID);
                IcraTakipForms._frmIcraTakip.DetaydanIliskiliIsleriGetir(iliskiDetaylari, isler);
            }

            //aykut önemli 27.02.2013
            //global::AdimAdimDavaKaydi.Ajanda.Forms.MainForms.frmAjanda ajanda =
            //    new global::AdimAdimDavaKaydi.Ajanda.Forms.MainForms.frmAjanda(isler, MyFoy, true);
            //ajanda.Show();

            #endregion <MB-20100427> Dosya Ajandasý Yeniden Düzenlendi.
        }

        private void c_bbYazisma_ItemClick(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor editor = new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor();
            if (bndDavaFoy.DataSource is TList<AV001_TD_BIL_FOY>)
            {
                editor.SelectedFoys = (TList<AV001_TD_BIL_FOY>)this.bndDavaFoy.DataSource;
                editor.Show();
            }
            else if (bndDavaFoy.DataSource is AV001_TD_BIL_FOY)
            {
                TList<AV001_TD_BIL_FOY> davalar = new TList<AV001_TD_BIL_FOY>();
                davalar.Add((AV001_TD_BIL_FOY)this.bndDavaFoy.DataSource);
                editor.SelectedFoys = davalar;
                editor.Show();
            }
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DavaCore != null && DavaCore.ucDavaGridler1 != null && DavaCore.ucDavaGridler1.ucIliskiDetay1 != null)
                DavaCore.ucDavaGridler1.ucIliskiDetay1.GetList(MyFoy.ID, AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.DAVA_DOSYASI);

            var detay = DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_DAVA_FOY_ID(MyFoy.ID);
            if (BelgeUtil.Inits.KayitIliskiGetir(MyFoy.ID).Count > 0 || detay.Count > 0)
                c_titemIliskiliDosyalar.Image = global::AdimAdimDavaKaydi.Properties.Resources.iliskili_dosyalar_red_16x16;
            else
                c_titemIliskiliDosyalar.Image = global::AdimAdimDavaKaydi.Properties.Resources.iliskili_dosyalar_mavi_16x16;
        }

        private void frmDavaTakip_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show(this, "Çýkmak istediðinizden emin misiniz?", "Dava Takip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
            xrDesignDockManager1.SaveLayoutToRegistry("DockManager\\Layouts\\DavaLayout");
        }

        private void frmDavaTakip_Load(object sender, EventArgs e)
        {
            //xrDesignDockManager1.RestoreLayoutFromRegistry("DockManager\\Layouts\\DavaLayout");
            this.WindowState = FormWindowState.Maximized;

            //Takip herhangi bir klasöre baðlý deðil ise takibin istenilen klasöre baðlanmasý saðlanýyor. MB
            if (DataRepository.AV001_TDIE_BIL_PROJE_DAVA_FOYProvider.GetByDAVA_FOY_ID(MyFoy.ID).Count == 0)
            {
                btnKlasoreBagla.Tag = "BAÐLA";
                btnKlasoreBagla.Text = "DAVA DOSYASINI KLASÖRE BAÐLA";
                BelgeUtil.Inits.ProjeAdGetirYenile(lueKlasor);
            }
            else
            {
                btnKlasoreBagla.Tag = "ÇIKAR";
                btnKlasoreBagla.Text = "DAVA DOSYASINI KLASÖRDEN ÇIKAR";
                BelgeUtil.Inits.ProjeAdGetirYenile(lueKlasor);
            }

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            cn.AddParams("@ID", MyFoy.ID);
            DataTable dt = cn.GetDataTable("SELECT KAZANMA_ORANI,BEKLENEN_BITIS_TARIHI FROM dbo.AV001_TD_BIL_FOY(nolock) WHERE ID=@ID");
            spinKazanmaOrani.EditValue = null;
            dateBeklenenBitisTarihi.EditValue = null;
            if (dt.Rows.Count > 0)
            {
                spinKazanmaOrani.EditValue = dt.Rows[0]["KAZANMA_ORANI"];
                dateBeklenenBitisTarihi.EditValue = dt.Rows[0]["BEKLENEN_BITIS_TARIHI"];
            }
        }

        #region BackGroundWorker

        private void bwDeepLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyFoy != null)
                MyFoy.Tag = 1;
        }

        private void bwDeepLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataChange();
        }

        #endregion BackGroundWorker

        #region InitializeEvents

        private void AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_IHTIYATI_TEDBIR tdbr = new AV001_TDI_BIL_IHTIYATI_TEDBIR();
            tdbr.ADLI_BIRIM_GOREV_ID = DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.Find("GOREV = 'AHM'")[0].ID;
            tdbr.TALEP_TARIHI = MyFoy.DAVA_TARIHI.Value;
            tdbr.KARAR_TARIHI = tdbr.TALEP_TARIHI;
            tdbr.TEMINAT_TUR_ID = 1;
            tdbr.TEMINAT_TUTARI_DOVIZ_ID = 1;

            //tdbr.TEMINAT_TUTARI = myFoy[0].A * (decimal)0.10; // TODO:Kullanýcý seçenekleri.. Oransal
            tdbr.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF>();
            foreach (AV001_TD_BIL_FOY_TARAF taraf in MyFoy.AV001_TD_BIL_FOY_TARAFCollection)
            {
                if (taraf.TARAF_SIFAT_ID == 7)
                {
                    AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF trf = tdbr.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection.AddNew();
                    trf.ICRA_CARI_TARAF_ID = taraf.CARI_ID;
                    trf.ICRA_TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
                }
            }
            tdbr.KAYIT_TARIHI = DateTime.Now;
            tdbr.KONTROL_NE_ZAMAN = DateTime.Now;
            tdbr.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            tdbr.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            tdbr.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            tdbr.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            e.NewObject = tdbr;
        }

        private void FoyIhtiyatiTedbir()
        {
            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>), typeof(TList<AV001_TDI_BIL_TEMINAT_MEKTUP>));

            DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.DeepLoad(MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF>));

            //MyFoy.AV001_TDI_BIL_TEMINAT_MEKTUPCollection
            //MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection[0].AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection

            if (MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection == null)
                MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>();
            MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.AddingNew += AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_AddingNew;
            if (MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.Count <= 0)
                MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.AddNew();

            frmDavaIcraIhtiyatiTedbir frm = new frmDavaIcraIhtiyatiTedbir();
            frm.MyDavaFoy = MyFoy;
            frm.MyDataSource = MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;
            frm.Show();
        }

        private void frmDavaTakip_Button_IhtiyatiTedbir_Click(object sender, EventArgs e)
        {
            FoyIhtiyatiTedbir();
        }

        private void frmDavaTakip_Button_IliskiliDosyalar_Click(object sender, EventArgs e)
        {
            IliskiliDosya();
        }

        private void frmDavaTakip_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (lueDavaTalep.EditValue != null)
                MyFoy.DAVA_TALEP_ID = (int)lueDavaTalep.EditValue;
            FoyuKaydet();
        }

        //private void frmDavaTakip_Button_Yazdir_Click(object sender, EventArgs e)
        //{
        //    FoyYazdir();
        //}
        private void frmDavaTakip_Button_Yeni_Click(object sender, EventArgs e)
        {
            YeniFoy();
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmDavaTakip_Button_Kaydet_Click;
            this.Button_Yeni_Click += frmDavaTakip_Button_Yeni_Click;
            this.Button_Ajanda_Click += c_bbAjanda_ItemClick;
            this.Button_IliskiliDosyalar_Click += frmDavaTakip_Button_IliskiliDosyalar_Click;

            //this.Button_Yazdir_Click += frmDavaTakip_Button_Yazdir_Click;
            this.Button_Editor_Click += frmDavaTakip_Button_Editor_Click;
            this.Button_Word_Click += frmDavaTakip_Button_Word_Click;
            this.Button_Outlook_Click += frmDavaTakip_Button_Outlook_Click;
            this.Button_Excel_Click += frmDavaTakip_Button_Excel_Click;
            this.Button_PDF_Click += frmDavaTakip_Button_PDF_Click;
            this.Button_TakipYazismalari_Click += c_bbYazisma_ItemClick;
            this.Button_IhtiyatiTedbir_Click += frmDavaTakip_Button_IhtiyatiTedbir_Click;

            this.bwDeepLoad.DoWork += bwDeepLoad_DoWork;
            this.bwDeepLoad.RunWorkerCompleted += bwDeepLoad_RunWorkerCompleted;
        }

        #region Editor,Word,Outlook,Excell,Pdf button click

        private void frmDavaTakip_Button_Editor_Click(object sender, EventArgs e)
        {
            EditorYolla();
        }

        private void frmDavaTakip_Button_Excel_Click(object sender, EventArgs e)
        {
            ExcelAc();
        }

        private void frmDavaTakip_Button_Outlook_Click(object sender, EventArgs e)
        {
            OutlookAc();
        }

        private void frmDavaTakip_Button_PDF_Click(object sender, EventArgs e)
        {
            PdfAc();
        }

        private void frmDavaTakip_Button_Word_Click(object sender, EventArgs e)
        {
            WordAc();
        }

        #endregion Editor,Word,Outlook,Excell,Pdf button click

        #endregion InitializeEvents

        private void sbtnMahkemeEsasNoDegistir_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.frmDosyaKimlikBilgileri frm = new AdimAdimDavaKaydi.Forms.frmDosyaKimlikBilgileri();
            frm.Show(MyFoy);
        }

        private void tabDavaBilg_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void tabDavaBilg_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (e.Page.Name == tabGelismeler.Name)
            {
                if (DavaCore == null) CreateUcDavaCore();
                System.Threading.Thread th = new System.Threading.Thread(new System.Threading.ThreadStart(delegate
                {
                    if (MyFoy != null)
                        DavaCore.MyFoy = MyFoy;
                }));

                th.SetApartmentState(System.Threading.ApartmentState.STA);
                th.Start();
            }
        }

        private void TarafBilgileri_Load(object sender, EventArgs e)
        {
            if (TarafBilgileri.MyFoy == null && this.MyFoy != null)
                TarafBilgileri.MyFoy = this.MyFoy;
        }

        public class FrmDavaDosyaKayitEventArgs : EventArgs
        {
            public FrmDavaDosyaKayitEventArgs(frmDavaDosyaKayitForm form)
            {
                MyForm = form;
            }

            public frmDavaDosyaKayitForm MyForm { get; set; }
        }

        #region <MB-20100525>

        //Takip Ekraný üzerinden (varsa)klasör ekranýna gitmesi saðlandý.
        private void sbtnKlasoreGonder_Click(object sender, EventArgs e)
        {
            if (MyProje == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Dosyada Klasör Bulunmamaktadýr.", "BÝLGÝ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            Forms.frmKlasorYeni klasor = new AdimAdimDavaKaydi.Forms.frmKlasorYeni();
            TList<AV001_TDIE_BIL_PROJE> projeler = new TList<AV001_TDIE_BIL_PROJE>();
            projeler.Add(MyProje);
            klasor.Show(projeler);
        }

        #endregion <MB-20100525>

        #endregion Events

        #region Dava Hýzlý Menü Button Click

        private void btnAraKarar_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Dava.rfrmAraKararKayit frm = new AdimAdimDavaKaydi.Forms.Dava.rfrmAraKararKayit();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.IsModul = false;
            frm.Show(MyFoy);
        }

        private void btnBelge_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak frm = new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.OpenedRecord = MyFoy;
            frm.Show();
        }

        private void btnDavaNedeni_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Dava.frmDavaNedenGirisi frm = new Forms.Dava.frmDavaNedenGirisi();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnDelil_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Dava.frmKanitGirisi frm = new Forms.Dava.frmKanitGirisi();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnDosyaIliskilendirme_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.frmKayitIliski frm = new AdimAdimDavaKaydi.Forms.frmKayitIliski();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.MyDavaFoy = MyFoy;
            frm.Show();
        }

        private void btnDurusma_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Dava.rFrmCelseKayit frm = new Forms.Dava.rFrmCelseKayit();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnDusmeYenileme_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Dava.rfrmDusmeYenilemeKayit frm = new AdimAdimDavaKaydi.Forms.Dava.rfrmDusmeYenilemeKayit();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnEditor_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor editor = new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor();
            editor.MdiParent = AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm;
            AV001_TD_BIL_FOY fy = (AV001_TD_BIL_FOY)this.bndDavaFoy.Current;
            TList<AV001_TD_BIL_FOY> lstfoys = new TList<AV001_TD_BIL_FOY>();
            lstfoys.Add(fy);
            editor.SelectedFoys = lstfoys;
            editor.Show();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExcelAc();
        }

        private void btnGelisme_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Dava.rfrmDavaGelismeAdim frm = new Forms.Dava.rfrmDavaGelismeAdim();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnGorusme_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit frm = new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnHukum_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Dava.frmHukumGirisi frm = new Forms.Dava.frmHukumGirisi();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnIhtiyatiTedbir_Click(object sender, EventArgs e)
        {
            frmDavaIcraIhtiyatiTedbir frm = new frmDavaIcraIhtiyatiTedbir();
            frm.MyDavaFoy = MyFoy;
            frm.MyDataSource = null;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void btnIsEmri_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frm = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ucIsKayitUfak1.OpenedRecord = MyFoy;
            frm.ucIsKayitUfak1.ModulID = 2;
            frm.Show();
        }

        private void btnKesif_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Dava.rFrmCelseKayit frm = new Forms.Dava.rFrmCelseKayit();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnMasrafAvans_Click(object sender, EventArgs e)
        {
            IcraTakipForms.frmMasrafAvansKayitHizli frm = new AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli();
            frm.AcilisYeri = AdimAdimDavaKaydi.IcraTakipForms.MasrafFormuAcilisiYeri.TakipEkrani;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnOutlook_Click(object sender, EventArgs e)
        {
            OutlookAc();
        }

        private void btnTebligat_Click(object sender, EventArgs e)
        {
            Forms.LayForm.frmLayTabligatKayit frm = new AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnTemyiz_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Dava.frmTemyizEkle frm = new Forms.Dava.frmTemyizEkle();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnTutuklamaGozalti_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Dava.rfrmTutuklanma frm = new Forms.Dava.rfrmTutuklanma();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(MyFoy);
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            WordAc();
        }

        #endregion Dava Hýzlý Menü Button Click

        private void btnBagla_Click(object sender, EventArgs e)
        {
            //Bu butona dosya herhangi bir proje baðlý olduðunda ulaþýlamadýðýndan proje icra tablosunda bu takip var mý diye kontrol yapmaya gerek kalmadý. MB

            if (lueKlasor.EditValue == null)
            {
                MessageBox.Show("Takibi baðlamak istediðiniz klasörü seçmelisiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            AV001_TDIE_BIL_PROJE_DAVA_FOY nnProjeIcra = new AV001_TDIE_BIL_PROJE_DAVA_FOY();
            nnProjeIcra.PROJE_ID = (int)lueKlasor.EditValue;
            nnProjeIcra.DAVA_FOY_ID = MyFoy.ID;

            try
            {
                DataRepository.AV001_TDIE_BIL_PROJE_DAVA_FOYProvider.Save(nnProjeIcra);

                MyProje = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID((int)lueKlasor.EditValue);
                if (MyProje.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_SORUMLU>), typeof(TList<AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI>));

                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>));

                foreach (var item in MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection)
                {
                    AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI a = new AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI();
                    a.PROJE_ID = MyProje.ID;
                    a.IHTIYATI_TEDBIR_ID = item.ID;
                    if (!MyProje.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLICollection.Contains(a))
                        MyProje.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLICollection.Add(a);
                }

                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepSave(MyProje);

                MessageBox.Show("Ýþlem Tamamlandý.", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnKlasoreBagla.Tag = "ÇIKAR";
                btnKlasoreBagla.Text = "DAVA DOSYASINI KLASÖRDEN ÇIKAR";
                bndProje.DataSource = MyProje;
            }
            catch 
            {
                MessageBox.Show("Ýþlem Tamamlanamadý.", "ÝPTAL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            popupKlasoreBagla.Visible = false;
        }

        private void btnKlasoreBagla_Click(object sender, EventArgs e)
        {
            if (btnKlasoreBagla.Tag.ToString() == "BAÐLA")
                popupKlasoreBagla.Visible = !popupKlasoreBagla.Visible;
            else
            {
                if (MessageBox.Show("Ýþleme devam etmek istiyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataRepository.AV001_TDIE_BIL_PROJE_DAVA_FOYProvider.Delete(DataRepository.AV001_TDIE_BIL_PROJE_DAVA_FOYProvider.GetByDAVA_FOY_ID(MyFoy.ID));

                    AV001_TDIE_BIL_PROJE_ICRA_FOY aa = DataRepository.AV001_TDIE_BIL_PROJE_ICRA_FOYProvider.GetByICRA_FOY_ID(MyFoy.ID)[0];
                    MyProje = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(aa.PROJE_ID);

                    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>));

                    foreach (var item in MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection)
                    {
                        DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLIProvider.Delete(MyProje.ID, item.ID);
                    }

                    MessageBox.Show("Ýþlem Tamamlandý.", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnKlasoreBagla.Tag = "BAÐLA";
                    btnKlasoreBagla.Text = "DAVA DOSYASINI KLASÖRE BAÐLA";
                }
            }
        }

        private void dpTaraf_VisibilityChanged(object sender, DevExpress.XtraBars.Docking.VisibilityChangedEventArgs e)
        {
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            panelControl2.Visible = false;
            dpTaraf.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            CreateTarafBilgileri();
            TarafBilgileri.MyFoy = this.MyFoy;
        }
    }

    #region <MB-20100628>
    //Veri girilen tarihlere göre dava durumunun belirlenmesini saðlamak için eklendi.
    public enum Tarihler
    {
        ArsivTarihi = 1,
        ZamanAsimiTarihi = 2,
        TerkinTarihi = 3,
        SemereTarihi = 4,
        IadeTarihi = 5,
        FeragatTarihi = 6,
        SulhTarihi = 7,
        KKKTarihi = 8,
        InfazTarihi = 9,
        AcizTarihi = 10
    }

    #endregion <MB-20100628>
}