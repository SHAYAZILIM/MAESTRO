using System;
using System.ComponentModel;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Is
{
    public partial class frmIsSozlesmeDetaySorumlu : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public int kategoriID = 1;

        private TList<AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU> myDataSource;

        private AV001_TDI_BIL_IS_SOZLESME myIsSozlesme;

        public frmIsSozlesmeDetaySorumlu()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public TList<AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU> MyDataSource
        {
            get { return myDataSource; }
            set
            {
                if (!this.DesignMode && value != null)
                {
                    myDataSource = value;
                    myDataSource.AddingNew += myDataSource_AddingNew;
                    InitsData();
                }
            }
        }

        public AV001_TDI_BIL_IS_SOZLESME MyIsSozlesme
        {
            get { return myIsSozlesme; }
            set
            {
                if (value != null)
                {
                    myIsSozlesme = value;

                    //MyDataSource = value.AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLUCollection;
                    textEdit1.Text = MyIsSozlesme.SOZLESME_KATEGORI_ACIKLAMA;
                    lookUpEdit2.EditValue = kategoriID;
                    vGridControl1.DataSource = MyDataSource;
                    dataNavigatorExtended1.DataSource = MyDataSource;
                }
            }
        }

        private void frmIsSozlesmeDetaySorumlu_Button_Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (MyIsSozlesme.AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLUCollection.Count == 0)
                    MyIsSozlesme.AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLUCollection.AddRange(MyDataSource);
                this.Close();
            }
            catch
            {
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmIsSozlesmeDetaySorumlu_Button_Kaydet_Click;
        }

        private void InitsData()
        {
            BelgeUtil.Inits.MuhasebeHareketHareketAltKatGetir(lookUpEdit2);
            BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
            BelgeUtil.Inits.SorumluAvukatGetir(rLueSorumlu);
            BelgeUtil.Inits.SureTipTipGetir(rLueSureBirimTip);
            BelgeUtil.Inits.ParaBicimiAyarla(spMiktar);
        }

        private void myDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU addNew = new AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU();
            addNew.KAYIT_TARIHI = DateTime.Now;
            addNew.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            addNew.KONTROL_NE_ZAMAN = DateTime.Now;
            addNew.SUBE_KOD_ID = AvukatProLib.Kimlik.SubeKodu;
            addNew.IS_MUHASEBE_ALT_KATEGORI_ID = kategoriID;
            e.NewObject = addNew;
        }
    }
}