using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi
{
    public partial class frmEkleKiymetliEvrak : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmEkleKiymetliEvrak()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public TList<AV001_TDI_BIL_KIYMETLI_EVRAK> alreadyaddedList;

        public DialogResult KayitBasarili = DialogResult.No;

        public TList<AV001_TDI_BIL_KIYMETLI_EVRAK> selectedList;

        public int TARAF_ID;

        public List<int> TarafIDList = new List<int>();

        public int Tip;

        public TList<AV001_TDI_BIL_KIYMETLI_EVRAK> alreadyAddedList
        {
            get { return alreadyaddedList; }
            set
            {
                if (value == null)
                {
                    AV001_TDI_BIL_KIYMETLI_EVRAK ne = new AV001_TDI_BIL_KIYMETLI_EVRAK();
                    alreadyaddedList = BelgeUtil.Inits.KiymetliEvrakGetir();
                    if (Tip > 0)
                        alreadyaddedList.Filter = "EVRAK_TUR_ID = " + Tip;
                    DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(alreadyAddedList, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>));
                    if (myIcra != null)
                    {
                        alreadyaddedList = TarafaGoreGetir();
                        alreadyaddedList.Filter = "EVRAK_TUR_ID = " + Tip;

                        selectedList = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
                        DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(alreadyAddedList, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>));
                        foreach (var item in alreadyaddedList)
                        {
                            if (item.IsSelected)
                            {
                                selectedList.Add(item);
                            }
                        }
                    }
                    else
                    {
                        if (TARAF_ID != 0)
                        {
                            alreadyaddedList = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
                            var taraf = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFProvider.GetByTARAF_CARI_ID(TARAF_ID);
                            foreach (var item in taraf)
                            {
                                alreadyaddedList.Add(DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByID(item.KIYMETLI_EVRAK_ID.Value));
                            }
                        }
                        else if (TarafIDList.Count > 0)
                        {
                            alreadyaddedList = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();

                            foreach (var item in TarafIDList)
                            {
                                var taraf = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFProvider.GetByTARAF_CARI_ID(item);
                                foreach (var trf in taraf)
                                {
                                    alreadyaddedList.Add(DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByID(trf.KIYMETLI_EVRAK_ID.Value));
                                }
                            }
                        }
                        else
                        {
                            alreadyaddedList = BelgeUtil.Inits.KiymetliEvrakGetir();
                        }

                        //alreadyaddedList.Filter = "EVRAK_TUR_ID = " + Tip;
                        selectedList = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
                        DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(alreadyAddedList, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>));
                        foreach (var item in alreadyaddedList)
                        {
                            if (item.IsSelected)
                            {
                                selectedList.Add(item);
                            }
                        }
                    }
                    alreadyaddedList.ForEach(item =>
                    {
                        if (item.BANKA_ID.HasValue)
                            AvukatPro.Services.Implementations.DevExpressService.BankaSubeGetir(rlkBankSube, item.BANKA_ID.Value);

                        //BelgeUtil.Inits.BankaSubeGetir(rlkBankSube, item.BANKA_ID.Value);
                    });
                }
            }
        }

        public AV001_TI_BIL_FOY myIcra { get; set; }

        public TList<AV001_TI_BIL_FOY_TARAF> myIcraATrf { get; set; }

        public TList<AV001_TI_BIL_FOY_TARAF> myIcraBTrf { get; set; }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            this.c_btnTamam.Text = "Gönder";
        }

        private void form_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                initSoranGetir();
                initTutarBirimGetir();
                BelgeUtil.Inits.KiymetliEvrakTipiGetir(rlkEvrakTur);
                BelgeUtil.Inits.BankaGetir(rlkBanka);
                BelgeUtil.Inits.KEAhzolunmaSekliGetir(rlkNeSekildeAhzolundugu);
                BelgeUtil.Inits.KESonucuGetir(rlkSorulmaSonucu);
                BelgeUtil.Inits.perCariGetir(rLueTaraf);
                BelgeUtil.Inits.KiymetliEvrakTarafTipGetir(rLueTarafTipi);
                BelgeUtil.Inits.ParaBicimiAyarla(rudTutar);
                BelgeUtil.Inits.ParaBicimiAyarla(rudKarsilikTutar);

                gridControl1.DataSource = alreadyAddedList;
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Tamam_Click += simpleButton1_Click_1;
            this.Button_Iptal_Click += simpleButton2_Click;
        }

        private void initSoranGetir()
        {
            BelgeUtil.Inits.perCariGetir(rlkCariSoran);
        }

        private void initTutarBirimGetir()
        {
            BelgeUtil.Inits.DovizTipGetir(rlkKarsilikTutarBirim);
            BelgeUtil.Inits.DovizTipGetir(rlkTutarBirim);
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            TList<AV001_TDI_BIL_KIYMETLI_EVRAK> result = ((TList<AV001_TDI_BIL_KIYMETLI_EVRAK>)gridControl1.DataSource).FindAll(item => item.IsSelected);

            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(result, true, DeepLoadType.IncludeChildren, typeof(TList<NN_DAVA_KIYMETLI_EVRAK>), typeof(TList<NN_ICRA_KIYMETLI_EVRAK>));
            TList<AV001_TDI_BIL_KIYMETLI_EVRAK> sonhal = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();

            foreach (AV001_TDI_BIL_KIYMETLI_EVRAK evrak in result)
            {
                string mesaj = "";
                if (evrak.NN_DAVA_KIYMETLI_EVRAKCollection.Count > 0)

                ///TODO: Ýkinci kontrol kaldýrýlacak yeni yapý kullanýlacak
                {
                    string msg = "";
                    foreach (NN_DAVA_KIYMETLI_EVRAK d in evrak.NN_DAVA_KIYMETLI_EVRAKCollection)
                    {
                        var davaFoy = BelgeUtil.Inits.context.per_AV001_TD_BIL_FOY_DosyaBilgileris.Single(vi => vi.ID == d.DAVA_FOY_ID);
                        msg += String.Format("Dosya No: {1} , Adliye : {0} {4} {5} , Esas No: {2} {3}", davaFoy.ADLIYE, davaFoy.FOY_NO, davaFoy.ESAS_NO, Environment.NewLine, davaFoy.NO, davaFoy.GOREV);
                    }
                    mesaj += evrak.ID + " Sistem numaralý evrak daha önce aþaðýda bulunan dava dosya(sýn/larýn) da kullanýlmýþtýr." + Environment.NewLine + msg;
                }
                if (evrak.NN_ICRA_KIYMETLI_EVRAKCollection.Count > 0)
                {
                    string msg = "";
                    foreach (NN_ICRA_KIYMETLI_EVRAK d in evrak.NN_ICRA_KIYMETLI_EVRAKCollection)
                    {
                        var icraFoy = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_DosyaBilgileris.Single(vi => vi.ID == d.ICRA_FOY_ID);
                        msg += String.Format("Dosya No: {1} , Müdürlük : {0} {4} {5} , Esas No: {2} {3}", icraFoy.ADLIYE, icraFoy.FOY_NO, icraFoy.ESAS_NO, Environment.NewLine, icraFoy.NO, icraFoy.GOREV);
                    }
                    mesaj += (evrak.ID + " Sistem numaralý evrak daha önce aþaðýda bulunan icra dosya(sýn/larýn) da kullanýlmýþtýr." + Environment.NewLine + msg);
                }
                if (evrak.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection.Count > 0)
                {
                    mesaj += (evrak.ID + " Sistem numaralý evrak daha önceden bir soruþturma dosyasýnda kullanýlmýþtýr.");
                }
                if (string.IsNullOrEmpty(mesaj))
                    sonhal.Add(evrak);
                else
                {
                    System.Windows.Forms.DialogResult dr = MessageBox.Show(mesaj + Environment.NewLine + "Eklemek istediðinize eminmisiniz ?", "Dikkat", MessageBoxButtons.YesNo);
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        sonhal.Add(evrak);
                    }
                }
            }
            selectedList = sonhal;
            KayitBasarili = DialogResult.OK;
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private TList<AV001_TDI_BIL_KIYMETLI_EVRAK> TarafaGoreGetir()
        {
            List<int> idList = new List<int>();
            TList<AV001_TDI_BIL_KIYMETLI_EVRAK> evrakList = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();

            foreach (var item in myIcraBTrf.Select(vi => vi.CARI_ID))
            {
                var evrakTarafList = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFProvider.GetByTARAF_CARI_ID(item);
                idList.AddRange(evrakTarafList.GroupBy(vi => vi.KIYMETLI_EVRAK_ID).Select(vi => vi.FirstOrDefault().KIYMETLI_EVRAK_ID.Value));
            }
            foreach (var item in idList)
            {
                if (evrakList.Find(vi => vi.ID == item) == null)
                    evrakList.Add(DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByID(item));
            }
            return evrakList;

        }
    }
}