using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Dava
{
    public partial class frmHukumKayit : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmHukumKayit()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += new EventHandler(frmHukumKayit_Load);
        }

        private void InitializeEvents()
        {
            this.Button_Kaydet_Click += new EventHandler<EventArgs>(frmHukumKayit_Button_Kaydet_Click);
        }

        #region Properties

        public bool Duzenlemi = false;

        private AV001_TD_BIL_FOY _MyFoy;
        
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return _MyFoy; }
            set
            {
                if (value != null)
                {
                    _MyFoy = value;

                    //if (BelgeUtil.Inits._TD_FoyTarafGetir == null)//_TD_FoyTarafGetir property'si dosya taraflarına göre filtrelenip, diğer dosyaya geçildiğinde eski dosyanın tarafları property'de kaldığından yukarıdaki kontrol kaldırıldı ve her durumda tüm tarafların property'ye doldurulması sağlandı. MB
                    BelgeUtil.Inits._TD_FoyTarafGetir = BelgeUtil.Inits.context.per_AV001_TD_BIL_FOY_TARAFs.ToList();
                    var foyTaraflari = BelgeUtil.Inits._TD_FoyTarafGetir.FindAll(vi => vi.DAVA_FOY_ID == _MyFoy.ID);

                    TList<AV001_TD_BIL_MAHKEME_HUKUM> hukumList = new TList<AV001_TD_BIL_MAHKEME_HUKUM>();
                    TList<AV001_TD_BIL_MAHKEME_HUKUM> hukumListDavaci = new TList<AV001_TD_BIL_MAHKEME_HUKUM>();

                    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_DAVA_NEDEN>));
                    int davaNedenID = MyFoy.AV001_TD_BIL_DAVA_NEDENCollection[0].ID;//Bahattin Bey, Hüküm kaydında dava nedeni seçiminin önemli olmadığını, hangi davaya karar verildiği bilgisi açıklama içerisinde yazıldığından 0.sının verilebileceğini söyledi. MB

                    foreach (var item in foyTaraflari)
                    {
                        if (item.DAVA_EDEN_MI)
                        {
                            lbcDavacilar.Items.Add(item.AD);

                            if (Duzenlemi) continue;
                            AV001_TD_BIL_MAHKEME_HUKUM hukum = new AV001_TD_BIL_MAHKEME_HUKUM();
                            hukum.TARAF_CARI_ID = item.CARI_ID;
                            hukum.DAVA_FOY_ID = _MyFoy.ID;
                            hukum.DAVA_NEDEN_ID = davaNedenID;
                            hukum.KONTROL_KIM = "AVUKATPRO";
                            hukum.KONTROL_NE_ZAMAN = DateTime.Now;
                            hukum.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                            hukum.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                            hukum.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                            hukumListDavaci.Add(hukum);
                        }
                        else
                        {
                            lbcDavalilar.Items.Add(item.AD);

                            if (Duzenlemi) continue;
                            AV001_TD_BIL_MAHKEME_HUKUM hukum = new AV001_TD_BIL_MAHKEME_HUKUM();
                            hukum.TARAF_CARI_ID = item.CARI_ID;
                            hukum.DAVA_FOY_ID = _MyFoy.ID;
                            hukum.DAVA_NEDEN_ID = davaNedenID;
                            hukum.KONTROL_KIM = "AVUKATPRO";
                            hukum.KONTROL_NE_ZAMAN = DateTime.Now;
                            hukum.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                            hukum.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                            hukum.STAMP = AvukatProLib.Kimlik.DefaultStamp;

                            hukumList.Add(hukum);
                        }
                    }
                    bndHukum.DataSource = hukumList;
                    bndHukumDavaci.DataSource = hukumListDavaci;

                    BelgeUtil.Inits.DavaNedenByFoy(MyFoy, rglueDavaNedenDavaci);
                    BelgeUtil.Inits.DavaNedenByFoy(MyFoy, rglueDavaNedeni);
                }
            }
        }

        #endregion Properties

        #region Events

        private void frmHukumKayit_Button_Kaydet_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void frmHukumKayit_Load(object sender, EventArgs e)
        {
            BindLookUps();
        }

        #endregion Events

        #region Methods

        public void Show(AV001_TD_BIL_FOY foy)
        {
            this.MyFoy = foy;
            this.Show();
        }
        
        private void BindLookUps()
        {
            BelgeUtil.Inits.ParaBicimiAyarla(rspTutar);
            BelgeUtil.Inits.ParaBicimiAyarla(rspTutarDavaci);
            BelgeUtil.Inits.perCariGetir(rlueTaraf);
            BelgeUtil.Inits.perCariGetir(rlueTarafDavaci);
            BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
            BelgeUtil.Inits.DovizTipGetir(rlueDovizDavaci);
            BelgeUtil.Inits.HukumGetir(rlueHukum);
            BelgeUtil.Inits.HukumGetir(rlueHukumDavaci);
        }

        private void KayitIslemleri(TList<AV001_TD_BIL_MAHKEME_HUKUM> list, AV001_TD_BIL_MAHKEME_HUKUM hukum)
        {
            list.Add(hukum);
            hukum.HUKUM_TARIHI = dtKararTarihi.DateTime;
            hukum.KARAR_NO = txtKararNo.Text;
        }

        private void Save()
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                if (!Duzenlemi)
                {
                    TList<AV001_TD_BIL_MAHKEME_HUKUM> savingHukumList = new TList<AV001_TD_BIL_MAHKEME_HUKUM>();
                    TList<AV001_TD_BIL_MAHKEME_HUKUM> savingHukumListDavaci = new TList<AV001_TD_BIL_MAHKEME_HUKUM>();

                    foreach (var item in bndHukum.List as TList<AV001_TD_BIL_MAHKEME_HUKUM>)
                    {
                        if (item.HUKUM_ID == null || item.HUKUM_ID == 0) continue;
                        else KayitIslemleri(savingHukumList, item);
                    }
                    foreach (var item in bndHukumDavaci.List as TList<AV001_TD_BIL_MAHKEME_HUKUM>)
                    {
                        if (item.HUKUM_ID == null || item.HUKUM_ID == 0) continue;
                        else KayitIslemleri(savingHukumListDavaci, item);
                    }
                    tran.BeginTransaction();
                    DataRepository.AV001_TD_BIL_MAHKEME_HUKUMProvider.Save(tran, savingHukumList);
                    DataRepository.AV001_TD_BIL_MAHKEME_HUKUMProvider.Save(tran, savingHukumListDavaci);
                    tran.Commit();
                }
                else
                {
                    tran.BeginTransaction();
                    DataRepository.AV001_TD_BIL_MAHKEME_HUKUMProvider.Save(tran, bndHukum.List as TList<AV001_TD_BIL_MAHKEME_HUKUM>);
                    tran.Commit();
                }
                MessageBox.Show("Kayıt Tamamlandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);
                MessageBox.Show("Kayıt Gerçekleştirilemedi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        #endregion Methods
    }
}