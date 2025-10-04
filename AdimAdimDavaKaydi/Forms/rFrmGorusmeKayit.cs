using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class rFrmGorusmeKayit : Util.BaseClasses.AvpXtraForm
    {
        public rFrmGorusmeKayit()
        {
            InitializeComponent();
            InitializeEvents();

            c_lueDosya.EditValueChanged += c_lueDosya_EditValueChanged;
        }

        private TList<AV001_TDI_BIL_GORUSME> addNewList;
        private bool isModul;

        private AV001_TD_BIL_FOY myFoy;

        private AV001_TD_BIL_HAZIRLIK myHazirlik;

        private AV001_TI_BIL_FOY myIcraFoy;

        private AV001_TDI_BIL_SOZLESME mySozlemse;

        [Browsable(false)]
        public TList<AV001_TDI_BIL_GORUSME> AddNewList
        {
            get { return addNewList; }
            set { addNewList = value; }
        }

        public bool IsModul
        {
            get { return isModul; }
            set
            {
                isModul = value;
                panelControl1.Visible = value;
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                if (value != null)
                {
                    myFoy = value;
                    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>));
                    if (AddNewList == null)
                    {
                        AddNewList = new TList<AV001_TDI_BIL_GORUSME>();
                        AddNewList.AddingNew += AV001_TDI_BIL_GORUSMECollection_AddingNew;
                        AddNewList.AddNew();
                    }
                    else
                        AddNewList.AddingNew += AV001_TDI_BIL_GORUSMECollection_AddingNew;
                    ucGorusmeKayit1.MyDataSource = AddNewList;
                }
                else
                    DataRepository.AV001_TDI_BIL_GORUSMEProvider.DeepLoad(AddNewList, false,
                                                                          DeepLoadType.IncludeChildren,
                                                                          typeof(TList<AV001_TDI_BIL_GORUSME>));
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_HAZIRLIK MyHazirlik
        {
            get { return myHazirlik; }
            set
            {
                if (value != null)
                {
                    myHazirlik = value;
                    DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(MyHazirlik, false,
                                                                          DeepLoadType.IncludeChildren,
                                                                          typeof(TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>));
                    if (AddNewList == null)
                    {
                        AddNewList = new TList<AV001_TDI_BIL_GORUSME>();
                        AddNewList.AddingNew += AV001_TDI_BIL_GORUSMECollection_AddingNew;
                        AddNewList.AddNew();
                    }
                    else
                        AddNewList.AddingNew += AddNewList_AddingNew;

                    ucGorusmeKayit1.MyDataSource = AddNewList;

                    //davaEdilenler = Inits.DavaEdilenTarafGetir(MyFoy);
                }
            }
        }

        [Browsable(false)]
        public AV001_TI_BIL_FOY MyIcraFoy
        {
            get { return myIcraFoy; }
            set
            {
                if (value != null)
                {
                    myIcraFoy = value;
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyIcraFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                    if (AddNewList == null)
                    {
                        AddNewList = new TList<AV001_TDI_BIL_GORUSME>();
                        AddNewList.AddingNew += AV001_TDI_BIL_GORUSMECollection_AddingNew;
                        AddNewList.AddNew();
                    }
                    ucGorusmeKayit1.MyDataSource = AddNewList;
                }
            }
        }

        [Browsable(false)]
        public AV001_TDI_BIL_SOZLESME MySozlesme
        {
            get { return mySozlemse; }
            set
            {
                DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren,
                                                                       typeof(TList<NN_GORUSME_SOZLESME>),
                                                                       typeof(TList<AV001_TDI_BIL_GORUSME>));
                if (value != null)
                {
                    mySozlemse = value;

                    //ucGorusmeKayit1.MyDataSource = gorusmeleriDoldur(MySozlesme);
                    if (AddNewList == null)
                    {
                        AddNewList = new TList<AV001_TDI_BIL_GORUSME>();
                        AddNewList.AddingNew += AV001_TDI_BIL_GORUSMECollection_AddingNew;
                        AddNewList.AddNew();
                    }
                    else
                        AddNewList.AddingNew += AddNewList_AddingNew;

                    ucGorusmeKayit1.MyDataSource = AddNewList;
                }
            }
        }

        public void Show(AV001_TD_BIL_HAZIRLIK hazirlik)
        {
            this.MyHazirlik = hazirlik;
            this.Show();
        }

        public void Show(AV001_TDI_BIL_SOZLESME sozlesme)
        {
            this.MySozlesme = sozlesme;
            this.Show();
        }

        public void Show(AV001_TD_BIL_FOY foy)
        {
            this.MyFoy = foy;

            this.Show();
        }

        public void Show(AV001_TI_BIL_FOY foy)
        {
            this.MyIcraFoy = foy;

            this.Show();
        }

        public void ShowDialog(AvukatProLib.Extras.ModulTip tablo, int id)
        {
            switch (tablo)
            {
                case AvukatProLib.Extras.ModulTip.Dava:
                    if (c_lueDosya.EditValue != null && (int)c_lueDosya.EditValue > -1)
                    {
                        DavaKaydi((int)c_lueDosya.EditValue);
                    }
                    else
                        DavaKaydi(id);
                    break;

                case AvukatProLib.Extras.ModulTip.Icra:
                    if (c_lueDosya.EditValue != null && (int)c_lueDosya.EditValue > -1)
                    {
                        IcraKaydi((int)c_lueDosya.EditValue);
                    }
                    else
                        IcraKaydi(id);
                    break;

                case AvukatProLib.Extras.ModulTip.Sorusturma:
                    if (c_lueDosya.EditValue != null && (int)c_lueDosya.EditValue > -1)
                    {
                        SorusturmaKaydi((int)c_lueDosya.EditValue);
                    }
                    else
                        SorusturmaKaydi(id);
                    break;

                case AvukatProLib.Extras.ModulTip.Sozlesme:
                    SozlesmeKaydi(id);
                    break;

                case AvukatProLib.Extras.ModulTip.Tebligat:
                    TebligatKaydi(id);
                    break;

                case AvukatProLib.Extras.ModulTip.CariArama:
                    CariKaydi(id);
                    break;

                case AvukatProLib.Extras.ModulTip.YapilacakIsler:
                    GorevKaydi(id);
                    break;

                default:
                    break;
            }

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.Show();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            this.c_btnTamam.Text = "Kaydet ve Çýk";
        }

        private void AddNewList_AddingNew(object sender, AddingNewEventArgs e)
        {
        }

        private void AV001_TDI_BIL_GORUSMECollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_GORUSME addnew = e.NewObject as AV001_TDI_BIL_GORUSME;
            if (addnew == null)
                addnew = new AV001_TDI_BIL_GORUSME();
            addnew.KLASOR_KODU = "GENEL";
            addnew.KONTROL_KIM = "AVUKATPRO";
            addnew.KONTROL_NE_ZAMAN = DateTime.Today;
            addnew.KONTROL_VERSIYON = 1;
            addnew.TARIH = DateTime.Now;
            addnew.KAYIT_TARIHI = DateTime.Now;
            addnew.STAMP = 1;
            addnew.SUBE_KODU = 1;
            if (MyFoy != null)
            {
                if (MyFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>),
                                                                     typeof(TList<AV001_TD_BIL_FOY_TARAF>));

                if (MyFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Count > 0)
                    addnew.GORUSEN_CARI_ID =
                        MyFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection[0].SORUMLU_AVUKAT_CARI_ID.Value;

                else if (c_lueDosya.EditValue != null && (int)c_lueDosya.EditValue > -1 &&
                         MyFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Count > 0)
                    addnew.GORUSEN_CARI_ID =
                        MyFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection[0].SORUMLU_AVUKAT_CARI_ID.Value;
            }
            else if (MyHazirlik != null)
            {
                if (MyHazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.Count == 0)
                    DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(MyHazirlik, false,
                                                                          DeepLoadType.IncludeChildren,
                                                                          typeof(TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>),
                                                                          typeof(TList<AV001_TD_BIL_HAZIRLIK_TARAF>));

                if (MyHazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.Count > 0)
                    addnew.GORUSEN_CARI_ID = MyHazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection[0].CARI_ID.Value;

                else if (c_lueDosya.EditValue != null && (int)c_lueDosya.EditValue > -1 &&
                         MyHazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.Count > 0)
                    addnew.GORUSEN_CARI_ID = MyHazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection[0].CARI_ID.Value;

                //.SORUMLU_AVUKAT_CARI_ID.Value;
            }
            else if (MySozlesme != null)
            {
                if (MySozlesme.AV001_TDI_BIL_SOZLESME_SORUMLUCollection.Count > 0)
                    addnew.GORUSEN_CARI_ID =
                        MySozlesme.AV001_TDI_BIL_SOZLESME_SORUMLUCollection[0].SORUMLU_CARI_ID.Value;
            }
            else if (MyIcraFoy != null)
            {
                if (MyIcraFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyIcraFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>));
                if (MyIcraFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count > 0)
                    addnew.GORUSEN_CARI_ID =
                        MyIcraFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[0].SORUMLU_AVUKAT_CARI_ID.Value;

                else if (c_lueDosya.EditValue != null && (int)c_lueDosya.EditValue > -1 &&
                         MyIcraFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count > 0)
                    addnew.GORUSEN_CARI_ID =
                        MyIcraFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[0].SORUMLU_AVUKAT_CARI_ID.Value;
            }

            //addnew
            addnew.GORUSULEN_CARI_ID = gorusulenCariId();
            addnew.BITIS_TARIH = DateTime.Today;
            addnew.TARIH = DateTime.Today;

            e.NewObject = addnew;
        }

        private void c_lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            ucGorusmeKayit1.Enabled = true;
            switch (c_lueModul.Text)
            {
                case "Dava":
                    MyFoy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)c_lueDosya.EditValue);
                    break;

                case "Icra":
                    MyIcraFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)c_lueDosya.EditValue);

                    break;

                case "Soruþturma":
                    MyHazirlik = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID((int)c_lueDosya.EditValue);
                    break;

                case "Sözleþme":
                    MySozlesme = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID((int)c_lueDosya.EditValue);
                    break;

                default:
                    break;
            }
        }

        private void c_lueModul_EditValueChanged(object sender, EventArgs e)
        {
            if (c_lueModul.Text == "Icra")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, AvukatProLib.Extras.Modul.Icra, false);

            else if (c_lueModul.Text == "Dava")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, AvukatProLib.Extras.Modul.Dava, false);

            else if (c_lueModul.Text == "Soruþturma")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, AvukatProLib.Extras.Modul.Sorusturma, false);

            else if (c_lueModul.Text == "Sözleþme")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, AvukatProLib.Extras.Modul.Sozlesme, false);

            if (c_lueModul.Text == "Genel")
            {
                c_lueDosya.Enabled = false;
                ucGorusmeKayit1.Enabled = true;
                if (AddNewList == null)
                {
                    AddNewList = new TList<AV001_TDI_BIL_GORUSME>();
                    AddNewList.AddingNew += AV001_TDI_BIL_GORUSMECollection_AddingNew;
                    AddNewList.AddNew();
                }
                ucGorusmeKayit1.MyDataSource = AddNewList;
            }
            else
                c_lueDosya.Enabled = true;
        }

        private void CariKaydi(int id)
        {
            AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(id);

            AV001_TDI_BIL_GORUSME gorusme = new AV001_TDI_BIL_GORUSME();
            if (AvukatProLib.Kimlik.Bilgi.CARI_ID.HasValue)
                gorusme.GORUSEN_CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;

            if (cari.ID != null)
                gorusme.GORUSULEN_CARI_ID = cari.ID;

            gorusme.SAAT = string.Format("{0}:{1}", DateTime.Now.Hour, DateTime.Now.Minute);
            gorusme.TARIH = DateTime.Now;

            TList<AV001_TDI_BIL_GORUSME> gorusmeListesi = new TList<AV001_TDI_BIL_GORUSME>();
            gorusmeListesi.Add(gorusme);
            ucGorusmeKayit1.MyDataSource = gorusmeListesi;
            ucGorusmeKayit1.ModulTipi = AvukatProLib.Extras.ModulTip.CariArama;
        }

        private void DavaKaydi(int id)
        {
            AV001_TD_BIL_FOY davaFoyu = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(id);
            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(davaFoyu, false, DeepLoadType.IncludeChildren,
                                                             typeof(List<AV001_TD_BIL_FOY_TARAF>));

            AV001_TDI_BIL_GORUSME gorusme = new AV001_TDI_BIL_GORUSME();
            gorusme.GORUSEN_CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.HasValue
                                          ? AvukatProLib.Kimlik.Bilgi.CARI_ID.Value
                                          : 0;
            if (davaFoyu.AV001_TD_BIL_FOY_TARAFCollection.Count > 0)
            {
                gorusme.GORUSULEN_CARI_ID = davaFoyu.AV001_TD_BIL_FOY_TARAFCollection[0].CARI_ID.Value;
            }
            gorusme.SAAT = string.Format("{0}:{1}", DateTime.Now.Hour, DateTime.Now.Minute);
            gorusme.TARIH = DateTime.Now;
            TList<AV001_TDI_BIL_GORUSME> gorusmeListesi = new TList<AV001_TDI_BIL_GORUSME>();
            gorusmeListesi.Add(gorusme);
            ucGorusmeKayit1.MyDataSource = gorusmeListesi;
            ucGorusmeKayit1.ModulTipi = AvukatProLib.Extras.ModulTip.Dava;
        }

        private void GorevKaydi(int id)
        {
            AV001_TDI_BIL_IS gorev = DataRepository.AV001_TDI_BIL_ISProvider.GetByID(id);

            DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(gorev, false, DeepLoadType.IncludeChildren,
                                                             typeof(TList<AV001_TDI_BIL_IS_TARAF>));

            AV001_TDI_BIL_GORUSME gorusme = new AV001_TDI_BIL_GORUSME();
            if (AvukatProLib.Kimlik.Bilgi.CARI_ID.HasValue)
                gorusme.GORUSEN_CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;

            if (gorev.AV001_TDI_BIL_IS_TARAFCollection.Count > 0)
                if (gorev.AV001_TDI_BIL_IS_TARAFCollection[0].CARI_ID.HasValue)
                    gorusme.GORUSULEN_CARI_ID = gorev.AV001_TDI_BIL_IS_TARAFCollection[0].CARI_ID.Value;

            gorusme.SAAT = string.Format("{0}:{1}", DateTime.Now.Hour, DateTime.Now.Minute);
            gorusme.TARIH = DateTime.Now;

            TList<AV001_TDI_BIL_GORUSME> gorusmeListesi = new TList<AV001_TDI_BIL_GORUSME>();
            gorusmeListesi.Add(gorusme);
            ucGorusmeKayit1.MyDataSource = gorusmeListesi;
            ucGorusmeKayit1.ModulTipi = AvukatProLib.Extras.ModulTip.YapilacakIsler;
        }

        private int gorusulenCariId()
        {
            if (MyFoy != null)
            {
                foreach (AV001_TD_BIL_FOY_TARAF t in MyFoy.AV001_TD_BIL_FOY_TARAFCollection)
                {
                    if (t.IsSelected)
                    {
                        if (t.CARI_IDSource == null)
                            t.CARI_IDSource = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(t.ID);

                        return t.CARI_ID.Value;
                    }
                }
            }
            if (MyHazirlik != null)
            {
                foreach (AV001_TD_BIL_HAZIRLIK_TARAF t in MyHazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection)
                {
                    if (t.IsSelected)
                    {
                        if (t.CARI_IDSource == null)
                        {
                            t.CARI_IDSource = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(t.ID);
                        }
                        return t.CARI_ID.Value;
                    }
                }
            }
            if (MySozlesme != null)
            {
                foreach (AV001_TDI_BIL_SOZLESME_TARAF t in MySozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection)
                {
                    if (t.IsSelected)
                    {
                        if (t.CARI_IDSource == null)
                        {
                            t.CARI_IDSource = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(t.ID);
                        }
                        return t.CARI_ID.Value;
                    }
                }
            }
            if (MyIcraFoy != null)
            {
                foreach (AV001_TI_BIL_FOY_TARAF t in MyIcraFoy.AV001_TI_BIL_FOY_TARAFCollection)
                {
                    if (t.IsSelected)
                    {
                        if (t.CARI_IDSource == null)
                        {
                            t.CARI_IDSource = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(t.ID);
                        }
                        return t.CARI_ID.Value;
                    }
                }
            }
            return 0;
        }

        private void IcraKaydi(int id)
        {
            AV001_TI_BIL_FOY icraFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(id);
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(icraFoy, false, DeepLoadType.IncludeChildren,
                                                             typeof(TList<AV001_TI_BIL_FOY_TARAF>));

            AV001_TDI_BIL_GORUSME gorusme = new AV001_TDI_BIL_GORUSME();

            if (AvukatProLib.Kimlik.Bilgi.CARI_ID.HasValue)
            {
                gorusme.GORUSEN_CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
            }

            if (icraFoy.AV001_TI_BIL_FOY_TARAFCollection.Count > 0)
            {
                if (icraFoy.AV001_TI_BIL_FOY_TARAFCollection[0].CARI_ID.HasValue)
                    gorusme.GORUSULEN_CARI_ID = icraFoy.AV001_TI_BIL_FOY_TARAFCollection[0].CARI_ID.Value;
            }
            gorusme.SAAT = string.Format("{0}:{1}", DateTime.Now.Hour, DateTime.Now.Minute);
            gorusme.TARIH = DateTime.Now;

            TList<AV001_TDI_BIL_GORUSME> gorusmeListesi = new TList<AV001_TDI_BIL_GORUSME>();
            gorusmeListesi.Add(gorusme);
            ucGorusmeKayit1.ModulTipi = AvukatProLib.Extras.ModulTip.Icra;
            ucGorusmeKayit1.MyDataSource = gorusmeListesi;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += rFrmGorusmeKayit_Button_Kaydet_Click;
        }

        private void rFrmGorusmeKayit_Button_Kaydet_Click(object sender, EventArgs e)
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            tran.BeginTransaction();
            AddNewList = ucGorusmeKayit1.MyDataSource;
            foreach (AV001_TDI_BIL_GORUSME g in AddNewList)
            {
                g.GORUSME_SURE = (g.BITIS_TARIH - g.TARIH).ToString();
            }

            if (MyIcraFoy != null)
            {
                foreach (AV001_TDI_BIL_GORUSME g in AddNewList)
                {
                    MyIcraFoy.AV001_TDI_BIL_GORUSMECollection.Add(g);
                }

                DataRepository.AV001_TDI_BIL_GORUSMEProvider.DeepSave(tran, MyIcraFoy.AV001_TDI_BIL_GORUSMECollection);

                foreach (var item in MyIcraFoy.AV001_TDI_BIL_GORUSMECollection)
                {
                    if (MyIcraFoy.NN_GORUSME_ICRACollection.Exists(delegate(NN_GORUSME_ICRA nI) { return nI.GORUSME_ID == item.ID; })) continue;
                    NN_GORUSME_ICRA ng = new NN_GORUSME_ICRA();
                    ng.ICRA_FOY_ID = MyIcraFoy.ID;
                    ng.GORUSME_ID = item.ID;
                    TList<NN_GORUSME_ICRA> igList = DataRepository.NN_GORUSME_ICRAProvider.GetAll();
                    if (igList.Exists(delegate(NN_GORUSME_ICRA gorusme) { return gorusme.GORUSME_ID == ng.GORUSME_ID; }))
                        continue;
                    DataRepository.NN_GORUSME_ICRAProvider.Save(tran, ng);
                }
            }
            else if (MyFoy != null)
            {
                addNewList.ForEach(delegate(AV001_TDI_BIL_GORUSME h) { h.DAVA_FOY_ID = MyFoy.ID; });
                foreach (AV001_TDI_BIL_GORUSME g in AddNewList)
                {
                    if (
                        MyFoy.AV001_TDI_BIL_GORUSMECollection.Exists(
                            delegate(AV001_TDI_BIL_GORUSME gorusme) { return gorusme.ID == g.ID; })) continue;
                    MyFoy.AV001_TDI_BIL_GORUSMECollection.Add(g);
                }

                DataRepository.AV001_TDI_BIL_GORUSMEProvider.DeepSave(tran, MyFoy.AV001_TDI_BIL_GORUSMECollection);
                foreach (var item in MyFoy.AV001_TDI_BIL_GORUSMECollection)
                {
                    if (MyFoy.NN_GORUSME_DAVACollection.Exists(delegate(NN_GORUSME_DAVA nD) { return nD.GORUSME_ID == item.ID; })) continue;
                    NN_GORUSME_DAVA ng = new NN_GORUSME_DAVA();
                    ng.DAVA_FOY_ID = MyFoy.ID;
                    ng.GORUSME_ID = item.ID;
                    TList<NN_GORUSME_DAVA> igList = DataRepository.NN_GORUSME_DAVAProvider.GetAll();
                    if (igList.Exists(delegate(NN_GORUSME_DAVA gorusme) { return gorusme.GORUSME_ID == ng.GORUSME_ID; }))
                        continue;
                    DataRepository.NN_GORUSME_DAVAProvider.Save(tran, ng);
                }
            }
            else if (MyHazirlik != null)
            {
                addNewList.ForEach(delegate(AV001_TDI_BIL_GORUSME h) { h.HAZIRLIK_ID = MyHazirlik.ID; });

                foreach (AV001_TDI_BIL_GORUSME g in AddNewList)
                {
                    if (MyHazirlik.AV001_TDI_BIL_GORUSMECollection.Exists(delegate(AV001_TDI_BIL_GORUSME gorusme) { return gorusme.ID == g.ID; })) continue;
                    MyHazirlik.AV001_TDI_BIL_GORUSMECollection.Add(g);
                }

                DataRepository.AV001_TDI_BIL_GORUSMEProvider.DeepSave(tran, MyHazirlik.AV001_TDI_BIL_GORUSMECollection);
                foreach (var item in MyHazirlik.AV001_TDI_BIL_GORUSMECollection)
                {
                    if (MyHazirlik.NN_GORUSME_HAZIRLIKCollection.Exists(delegate(NN_GORUSME_HAZIRLIK nH) { return nH.GORUSME_ID == item.ID; }))
                        continue;
                    item.NN_GORUSME_HAZIRLIKCollection.Add(new NN_GORUSME_HAZIRLIK() { HAZIRLIK_FOY_ID = MyHazirlik.ID, GORUSME_ID = item.ID });
                    DataRepository.AV001_TDI_BIL_GORUSMEProvider.DeepSave(tran, item);
                }
            }
            else if (MySozlesme != null)
            {
                DataRepository.AV001_TDI_BIL_GORUSMEProvider.DeepSave(tran, addNewList);
                foreach (var item in addNewList)
                {
                    if (MySozlesme.NN_GORUSME_SOZLESMECollection.Exists(delegate(NN_GORUSME_SOZLESME nH) { return nH.GORUSME_ID == item.ID; })) continue;
                    NN_GORUSME_SOZLESME ng = new NN_GORUSME_SOZLESME();
                    ng.SOZLESME_ID = MySozlesme.ID;
                    ng.GORUSME_ID = item.ID;
                    DataRepository.NN_GORUSME_SOZLESMEProvider.Save(tran, ng);
                }
            }
            else//Genel Modülü
                DataRepository.AV001_TDI_BIL_GORUSMEProvider.DeepSave(tran, addNewList);
            DevExpress.XtraEditors.XtraMessageBox.Show("Kayýt iþlemi baþarý ile gerçekleþtirildi.", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tran.Commit();

            this.Close();
        }

        private void rFrmGorusmeKayit_Load(object sender, EventArgs e)
        {
            //gorusmeleriDoldur();
            if (isModul)
                ucGorusmeKayit1.Enabled = false;
            c_lueModul.Properties.NullText = "Seç";
            c_lueModul.EditValueChanged += c_lueModul_EditValueChanged;
            c_lueModul.Enter += BelgeUtil.Inits.ModulKodGetir_Enter;

            //((TList<TDIE_KOD_MODUL>)c_lueModul.Properties.DataSource).Filter = "AD = 'Icra'";
        }

        private void SorusturmaKaydi(int id)
        {
            AV001_TD_BIL_HAZIRLIK hazirlik = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(id);
            DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(hazirlik, false, DeepLoadType.IncludeChildren,
                                                                  typeof(TList<AV001_TD_BIL_HAZIRLIK_TARAF>));
            AV001_TDI_BIL_GORUSME gorusme = new AV001_TDI_BIL_GORUSME();
            if (AvukatProLib.Kimlik.Bilgi.CARI_ID.HasValue)
                gorusme.GORUSEN_CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
            if (hazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection.Count > 0)
                gorusme.GORUSULEN_CARI_ID = hazirlik.AV001_TD_BIL_HAZIRLIK_TARAFCollection[0].CARI_ID.Value;
            gorusme.SAAT = string.Format("{0}:{1}", DateTime.Now.Hour, DateTime.Now.Minute);
            gorusme.TARIH = DateTime.Now;

            TList<AV001_TDI_BIL_GORUSME> gorusmeListesi = new TList<AV001_TDI_BIL_GORUSME>();
            gorusmeListesi.Add(gorusme);

            ucGorusmeKayit1.MyDataSource = gorusmeListesi;
            ucGorusmeKayit1.ModulTipi = AvukatProLib.Extras.ModulTip.Sorusturma;
        }

        private void SozlesmeKaydi(int id)
        {
            AV001_TDI_BIL_SOZLESME sozlesme = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(id);

            DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(sozlesme, false, DeepLoadType.IncludeChildren,
                                                                   typeof(TList<AV001_TDI_BIL_SOZLESME_TARAF>));

            AV001_TDI_BIL_GORUSME gorusme = new AV001_TDI_BIL_GORUSME();
            if (AvukatProLib.Kimlik.Bilgi.CARI_ID.HasValue)
                gorusme.GORUSEN_CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;

            if (sozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection.Count > 0)
                if (sozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection[0].CARI_ID.HasValue)
                    gorusme.GORUSULEN_CARI_ID = sozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection[0].CARI_ID.Value;

            gorusme.SAAT = string.Format("{0}:{1}", DateTime.Now.Hour, DateTime.Now.Minute);
            gorusme.TARIH = DateTime.Now;

            TList<AV001_TDI_BIL_GORUSME> gorusmeListesi = new TList<AV001_TDI_BIL_GORUSME>();
            gorusmeListesi.Add(gorusme);
            ucGorusmeKayit1.MyDataSource = gorusmeListesi;
            ucGorusmeKayit1.ModulTipi = AvukatProLib.Extras.ModulTip.Sozlesme;
        }

        private void TebligatKaydi(int id)
        {
            AV001_TDI_BIL_TEBLIGAT tebligat = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByID(id);
            DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(tebligat, false, DeepLoadType.IncludeChildren,
                                                                   typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>));

            AV001_TDI_BIL_GORUSME gorusme = new AV001_TDI_BIL_GORUSME();
            if (AvukatProLib.Kimlik.Bilgi.CARI_ID.HasValue)
                gorusme.GORUSEN_CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;

            if (tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count > 0)
                gorusme.GORUSULEN_CARI_ID = tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[0].MUHATAP_CARI_ID;

            gorusme.SAAT = string.Format("{0}:{1}", DateTime.Now.Hour, DateTime.Now.Minute);
            gorusme.TARIH = DateTime.Now;

            TList<AV001_TDI_BIL_GORUSME> gorusmeListesi = new TList<AV001_TDI_BIL_GORUSME>();
            gorusmeListesi.Add(gorusme);
            ucGorusmeKayit1.MyDataSource = gorusmeListesi;
            ucGorusmeKayit1.ModulTipi = AvukatProLib.Extras.ModulTip.Sozlesme;
        }
    }
}