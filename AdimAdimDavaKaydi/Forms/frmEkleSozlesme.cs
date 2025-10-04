using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi
{
    public partial class frmEkleSozlesme : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmEkleSozlesme()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public int AltTip;

        public int Anatip;

        public DialogResult KayitBasarili = DialogResult.No;

        public TList<AV001_TDI_BIL_SOZLESME> selectedList;

        private TList<AV001_TDI_BIL_SOZLESME> alreadyaddedList;

        private AV001_TI_BIL_FOY myicra;

        private TList<AV001_TI_BIL_FOY_TARAF> myicraTrf;

        private TList<AV001_TDI_BIL_SOZLESME> sozList;

        public TList<AV001_TDI_BIL_SOZLESME> alreadyAddedList
        {
            get { return alreadyaddedList; }
            set
            {
                if (value == null)
                {
                    AV001_TDI_BIL_SOZLESME ne = new AV001_TDI_BIL_SOZLESME();
                    alreadyaddedList = BelgeUtil.Inits.SozlesmeGetir();
                    if (Anatip > 0 && AltTip > 0)
                        alreadyaddedList.Filter = "TIP_ID = " + Anatip + " AND ALT_TIP_ID = " + AltTip;
                    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(alreadyAddedList, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_TARAF>));
                    if (myIcra != null)
                    {
                        alreadyaddedList = TarafaGoreGetir();
                        alreadyaddedList.Filter = "TIP_ID = " + Anatip + " AND ALT_TIP_ID = " + AltTip;
                        DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(alreadyAddedList, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_TARAF>));
                    }
                }
                else
                {
                    alreadyaddedList = value;
                }
            }
        }

        public AV001_TI_BIL_FOY myIcra
        {
            get { return myicra; }
            set
            {
                if (value != null)
                {
                    myicra = value;
                }
            }
        }

        public TList<AV001_TI_BIL_FOY_TARAF> myIcraTrf
        {
            get { return myicraTrf; }
            set
            {
                if (value != null)
                {
                    myicraTrf = value;
                }
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            this.c_btnTamam.Text = "Gönder";
        }

        private void frmEkleSozlesme_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.SozlesmeTipiGetir(rLueSozlesmeTipi);
            BelgeUtil.Inits.perCariGetir(rLueTaraf);
            BelgeUtil.Inits.TarafKoduGetir(rLueTarafKodu);
            BelgeUtil.Inits.TarafSifatGetir(rLueTarafSifat);
            BelgeUtil.Inits.SozlesmeAltTipiHepsiGetir(rLueSozlesmeAltTip);
            BelgeUtil.Inits.SozlesmeSekliGetir(rLueSozlesmeTur);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorev);
            BelgeUtil.Inits.SozlesmeOzelKod(rLueOzelKod1);
            BelgeUtil.Inits.SozlesmeOzelKod(rLueOzelKod2);
            BelgeUtil.Inits.SozlesmeOzelKod(rLueOzelKod3);
            BelgeUtil.Inits.SozlesmeOzelKod(rLueOzelKod4);
            BelgeUtil.Inits.DovizTipGetir(rLueKur);
            BelgeUtil.Inits.perCariGetir(rLueYeddiEminCari);
            BelgeUtil.Inits.OdemeTipiGetir(rLueOdemePeriyodu);
            BelgeUtil.Inits.KrediTipiGetir(rLueKartTipi);

            gridControl1.DataSource = alreadyaddedList;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;

            this.Button_Tamam_Click += simpleButton1_Click;
            this.Button_Iptal_Click += simpleButton2_Click;
        }

        //Ekle
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TList<AV001_TDI_BIL_SOZLESME> result = new TList<AV001_TDI_BIL_SOZLESME>();
            TList<AV001_TDI_BIL_SOZLESME> ds = (TList<AV001_TDI_BIL_SOZLESME>)gridControl1.DataSource;
            foreach (AV001_TDI_BIL_SOZLESME tek in ds)
            {
                if (tek.IsSelected)
                {
                    result.Add(tek);
                }
            }
            DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(result, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_DAVA_NEDEN_SOZLESME>), typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_SOZLESME>));

            TList<AV001_TDI_BIL_SOZLESME> sonhal = new TList<AV001_TDI_BIL_SOZLESME>();

            foreach (AV001_TDI_BIL_SOZLESME sozlesme in result)
            {
                string mesaj = "";
                if (sozlesme.AV001_TD_BIL_DAVA_NEDEN_SOZLESMECollection.Count > 0)
                {
                    string msg = "";
                    TList<AV001_TD_BIL_DAVA_NEDEN> dnList = new TList<AV001_TD_BIL_DAVA_NEDEN>();
                    foreach (AV001_TD_BIL_DAVA_NEDEN_SOZLESME d in sozlesme.AV001_TD_BIL_DAVA_NEDEN_SOZLESMECollection)
                    {
                        DataRepository.AV001_TD_BIL_DAVA_NEDEN_SOZLESMEProvider.DeepLoad(d, true, DeepLoadType.IncludeChildren, typeof(AV001_TD_BIL_DAVA_NEDEN));
                        if (d.DAVA_NEDEN_IDSource != null)
                        {
                            dnList.Add(d.DAVA_NEDEN_IDSource);
                        }
                    }
                    foreach (AV001_TD_BIL_DAVA_NEDEN d in dnList)
                    {
                        DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.DeepLoad(d, true, DeepLoadType.IncludeChildren, typeof(AV001_TD_BIL_FOY));
                        DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(d.DAVA_FOY_IDSource, true, DeepLoadType.IncludeChildren, typeof(TDI_KOD_ADLI_BIRIM_ADLIYE), typeof(TDI_KOD_ADLI_BIRIM_GOREV), typeof(TDI_KOD_ADLI_BIRIM_NO));
                        msg += String.Format("Dosya No: {1} , Adliye : {0} {4} {5} , Esas No: {2} {3}", d.DAVA_FOY_IDSource.ADLI_BIRIM_ADLIYE_IDSource.ADLIYE, d.DAVA_FOY_IDSource.FOY_NO, d.DAVA_FOY_IDSource.ESAS_NO, Environment.NewLine, d.DAVA_FOY_IDSource.ADLI_BIRIM_NO_IDSource.NO, d.DAVA_FOY_IDSource.ADLI_BIRIM_GOREV_IDSource.GOREV);
                    }

                    mesaj += sozlesme.ID + " Sistem numaralý sözleþme daha önce aþaðýda bulunan dava dosya(sýn/larýn) da kullanýlmýþtýr." + Environment.NewLine + msg;
                }
                if (sozlesme.AV001_TI_BIL_ALACAK_NEDEN_SOZLESMECollection.Count > 0)
                {
                    string msg = "";
                    TList<AV001_TI_BIL_ALACAK_NEDEN> anList = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
                    foreach (AV001_TI_BIL_ALACAK_NEDEN_SOZLESME szl in sozlesme.AV001_TI_BIL_ALACAK_NEDEN_SOZLESMECollection)
                    {
                        DataRepository.AV001_TI_BIL_ALACAK_NEDEN_SOZLESMEProvider.DeepLoad(szl, true, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_ALACAK_NEDEN));
                        if (szl.ICRA_ALACAK_NEDEN_IDSource != null)
                        {
                            anList.Add(szl.ICRA_ALACAK_NEDEN_IDSource);
                        }
                    }
                    foreach (AV001_TI_BIL_ALACAK_NEDEN d in anList)
                    {
                        DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(d, true, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_FOY));
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(d.ICRA_FOY_IDSource, true, DeepLoadType.IncludeChildren, typeof(TDI_KOD_ADLI_BIRIM_ADLIYE), typeof(TDI_KOD_ADLI_BIRIM_GOREV), typeof(TDI_KOD_ADLI_BIRIM_NO));
                        msg += String.Format("Dosya No: {1} , Müdürlük : {0} {4} {5} , Esas No: {2} {3}", d.ICRA_FOY_IDSource.ADLI_BIRIM_ADLIYE_IDSource.ADLIYE, d.ICRA_FOY_IDSource.FOY_NO, d.ICRA_FOY_IDSource.ESAS_NO, Environment.NewLine, d.ICRA_FOY_IDSource.ADLI_BIRIM_NO_IDSource != null ? d.ICRA_FOY_IDSource.ADLI_BIRIM_NO_IDSource.NO : "", d.ICRA_FOY_IDSource.ADLI_BIRIM_GOREV_IDSource.GOREV);
                    }
                    mesaj += (sozlesme.ID + " Sistem sözleþme evrak daha önce aþaðýda bulunan icra dosya(sýn/larýn) da kullanýlmýþtýr." + Environment.NewLine + msg);
                }
                if (string.IsNullOrEmpty(mesaj))
                    sonhal.Add(sozlesme);
                else
                {
                    DialogResult dr = MessageBox.Show(mesaj + Environment.NewLine + "Eklemek istediðinize eminmisiniz ?", "Dikkat", MessageBoxButtons.YesNo);
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        sonhal.Add(sozlesme);
                    }
                }
            }
            selectedList = sonhal;
            KayitBasarili = DialogResult.OK;
        }

        //Ýptal
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private TList<AV001_TDI_BIL_SOZLESME> TarafaGoreGetir()
        {
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myIcra, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));
            sozList = new TList<AV001_TDI_BIL_SOZLESME>();
            foreach (AV001_TI_BIL_FOY_TARAF item in myIcraTrf)
            {
                TList<AV001_TDI_BIL_SOZLESME_TARAF> trfList = DataRepository.AV001_TDI_BIL_SOZLESME_TARAFProvider.GetByCARI_ID(item.CARI_ID);
                foreach (AV001_TDI_BIL_SOZLESME_TARAF item2 in trfList)
                {
                    AV001_TDI_BIL_SOZLESME sozList2 = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID((int)item2.SOZLESME_ID);
                    sozList.Add(sozList2);
                }
            }
            return sozList;
        }
    }
}