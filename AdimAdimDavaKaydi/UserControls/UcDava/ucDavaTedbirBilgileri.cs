using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucDavaTedbirBilgileri : AvpXUserControl
    {
        public ucDavaTedbirBilgileri()
        {
            this.Load += ucDavaTedbirBilgileri_Load;
        }

        private void extendedGridControl1_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null) return;
            if (e.Button.Tag.ToString() == "FormAc")
            {
                FoyIhtiyatiTedbir();
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> DvList = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>();
                DvList.Add(gwIhtiyatiTedbir.GetFocusedRow() as AV001_TDI_BIL_IHTIYATI_TEDBIR);

                frmDavaIcraIhtiyatiTedbir frmTedbir = new frmDavaIcraIhtiyatiTedbir();
                frmTedbir.MyDavaFoy = MyFoy;
                frmTedbir.MyDataSource = DvList;
                // frmTedbir.MdiParent = null;
                frmTedbir.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frmTedbir.Show();
                frmTedbir.FormClosed += frmTedbir_FormClosed;
            }
        }

        private frmDavaIcraIhtiyatiTedbir frmTedbir;

        private void FoyIhtiyatiTedbir()
        {
            if (MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection == null)
                MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>();
            MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.AddingNew +=
                AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_AddingNew;

            frmTedbir = new frmDavaIcraIhtiyatiTedbir();
            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                             typeof(TList<AV001_TD_BIL_FOY_TARAF>));
            frmTedbir.MyDavaFoy = MyFoy;
            frmTedbir.MyDataSource = null;
            // frmTedbir.MdiParent = null;
            frmTedbir.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frmTedbir.Show();
            frmTedbir.FormClosed += frmTedbir_FormClosed;
        }

        private void frmTedbir_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>));
            gridIhtiyatiTedbir.DataSource = MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;
        }

        private void AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_IHTIYATI_TEDBIR tdbr = new AV001_TDI_BIL_IHTIYATI_TEDBIR();
            tdbr.ADLI_BIRIM_GOREV_ID = DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.Find("GOREV = 'AHM'")[0].ID;
            tdbr.TALEP_TARIHI = DateTime.Now;
            tdbr.KARAR_TARIHI = tdbr.TALEP_TARIHI;
            tdbr.TEMINAT_TUR_ID = 1;
            tdbr.TEMINAT_TUTARI_DOVIZ_ID = 1;

            tdbr.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF>();
            foreach (AV001_TD_BIL_FOY_TARAF taraf in MyFoy.AV001_TD_BIL_FOY_TARAFCollection)
            {
                AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF trf = tdbr.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection.AddNew();
                trf.ICRA_CARI_TARAF_ID = taraf.CARI_ID;
                trf.DAVA_TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
            }
            frmTedbir.MyTaraf = tdbr.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection;
            if (tdbr.DAVA_TARIHI != null)
                tdbr.DAVA_TARIHI = DateTime.Now;
            tdbr.KAYIT_TARIHI = DateTime.Now;
            tdbr.KONTROL_NE_ZAMAN = DateTime.Now;
            tdbr.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            tdbr.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            tdbr.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            tdbr.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            e.NewObject = tdbr;
        }

        private TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        private BackgroundWorker bckWorker = new BackgroundWorker();

        public void BindData()
        {
            if (MyDataSource == null) return;
            if (!bckWorker.IsBusy)
            {
                bckWorker.DoWork += bckWorker_DoWork;
                bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
                bckWorker.RunWorkerAsync();
            }
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyDataSource.Count == 0)
            {
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy
                                                                 , false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>));
                MyDataSource = MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                gridIhtiyatiTedbir.DataSource = MyDataSource;
                MyDataSource.AddingNew += value_AddingNew;
            }
        }

        private void value_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_IHTIYATI_TEDBIR addNew = new AV001_TDI_BIL_IHTIYATI_TEDBIR();
            addNew.DAVA_TARIHI = DateTime.Today;
            addNew.KARAR_TARIHI = DateTime.Today;
            addNew.TALEP_TARIHI = DateTime.Today;
            addNew.KAYIT_TARIHI = DateTime.Now;
            addNew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            addNew.KONTROL_KIM = "AVUKATPRO";
            addNew.KONTROL_NE_ZAMAN = DateTime.Today;
            addNew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addNew.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            addNew.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            e.NewObject = addNew;
        }

        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                    MyDataSource = value.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;
            }
        }

        private void ucDavaTedbirBilgileri_Load(object sender, EventArgs e)
        {
            //LOAD
            InitializeComponent();
            IsLoaded = true;
            this.gridIhtiyatiTedbir.ButtonClick += extendedGridControl1_ButtonClick;
            if (!this.DesignMode)
            {
                gridIhtiyatiTedbir.ShowOnlyPredefinedDetails = true;

                BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
                BelgeUtil.Inits.AdliBirimGorevGetir(rlueAdliGorev);
                BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliNo);
                BelgeUtil.Inits.CariPersonelGetir(rlueCariPersonel);
                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.TeminatTuruGetir(rlueTeminatTur);
                BindData();
            }
        }
    }
}