using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AdimAdimDavaKaydi.Util;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Icra
{
    public partial class frmHacizGirisi : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        #region Fields

        //Düzenleme modunda ilgili child bilgisinin ekrana gelmesini saðlamak için eklendi.
        public TList<AV001_TI_BIL_HACIZ_CHILD> ChildList = new TList<AV001_TI_BIL_HACIZ_CHILD>();

        private TList<AV001_TI_BIL_HACIZ_MASTER> addNewList;
        private bool isModul;
        private bool kaydedildi;
        private int Madet;
        private MalKategori mKategori;
        private TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> MyArac;
        private AV001_TI_BIL_FOY myFoy;
        private TList<AV001_TI_BIL_GAYRIMENKUL> MyGayri;
        private decimal ppara;
        private string tARAFýD = string.Empty;

        #endregion Fields

        #region Constructors

        public frmHacizGirisi()
        {
            InitializeComponent();
            this.FormClosing += frmHacizGirisi_FormClosing;
            this.FormClosed += frmHacizGirisi_FormClosed;
            this.ucHacizChild1.HacizChildListedenGetir += ucHacizChild1_HacizChildListedenGetir;
            InitializeEvents();

            c_lueDosya.EditValueChanged += c_lueDosya_EditValueChanged;
        }

        #endregion Constructors

        #region Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_HACIZ_MASTER> AddNewList
        {
            get { return addNewList; }
            set { addNewList = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HacizEdilecekMalVar
        {
            get;
            set;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HacizKaynak HacizKaynagi
        {
            get;

            //set {(ucHacizMaster1.MyDataSource as AV001_TI_BIL_HACIZ_MASTER).}
            set;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsModul
        {
            get { return isModul; }
            set
            {
                isModul = value;
                panelControl3.Visible = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MalKategori MKategori
        {
            get { return MalKategori.NULL; }
            set { mKategori = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                if (value != null && !DesignMode)
                {
                    myFoy = value;
                    ucHacizMaster1.MyFoy = value;
                    ucHacizChild1.MyFoy = value;

                    if (AddNewList == null)
                    {
                        AddNewList = new TList<AV001_TI_BIL_HACIZ_MASTER>();
                        AddNewList.AddingNew += HacizMaster_AddingNew;
                        AddNewList.AddNew();
                    }

                    AddNewList.AddingNew += HacizMaster_AddingNew;

                    ucHacizMaster1.MyDataSource = AddNewList;

                    #region <MB-20100526>

                    //Düzenleme modunda ilgili child bilgisinin ekrana gelmesini saðlamak için eklendi.

                    if (ChildList.Count == 0)
                        ucHacizChild1.MyDataSource = AddNewList[ucHacizMaster1.HacizFocusedRecord].AV001_TI_BIL_HACIZ_CHILDCollection;
                    else
                    {
                        AddNewList[ucHacizMaster1.HacizFocusedRecord].AV001_TI_BIL_HACIZ_CHILDCollection.Clear();
                        AddNewList[ucHacizMaster1.HacizFocusedRecord].AV001_TI_BIL_HACIZ_CHILDCollection = ChildList;
                        ucHacizChild1.MyDataSource = AddNewList[ucHacizMaster1.HacizFocusedRecord].AV001_TI_BIL_HACIZ_CHILDCollection;
                    }

                    #endregion <MB-20100526>

                    ucHacizChild1.MyDataSource.AddingNew += HacizChild_AddingNew;
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

        #endregion Properties

        #region Methods

        public void Show(AV001_TI_BIL_FOY foy, AV001_TI_BIL_HACIZ_MASTER master)
        {
            if (master != null)
            {
                HacizOnDegerler(master);
            }
            MyFoy = foy;
            this.Show();
        }

        //Listeden mallarýn getirilebilmesi için eklendi.
        private void arac_FormClosed(object sender, FormClosedEventArgs e)
        {
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_GEMI_UCAK_ARAC> gonderilenler = ((frmAracBilgileri)sender).Secilenler;
            if (MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_HACIZ_MASTER>));
            if (gonderilenler.Count > 0 && AddNewList.Count > 0 && ucHacizMaster1.HacizFocusedRecord >= 0)
            {
                AddNewList[ucHacizMaster1.HacizFocusedRecord].AV001_TI_BIL_HACIZ_CHILDCollection.Clear();

                for (int j = 0; j < gonderilenler.Count; j++)
                {
                    AV001_TI_BIL_HACIZ_CHILD child = new AV001_TI_BIL_HACIZ_CHILD();
                    child = AddNewList[ucHacizMaster1.HacizFocusedRecord].AV001_TI_BIL_HACIZ_CHILDCollection.AddNew();

                    child.HACIZLI_MAL_TUR_ID = (int)HACIZLI_MAL_TUR.TAÞIMA_VASITASI;
                    child.HACIZLI_MAL_KATEGORI_ID = (int)MalKategori.ARAÇ;
                    child.HACIZLI_MAL_CINS_ID = (int)HACIZLI_MAL_CINS.DÝÐER_BÝNEK_VE_YÜK_VASITALARI;
                    child.ARAC_BILGI_ID = gonderilenler[j].ID;
                    if (gonderilenler[j].TIPI.Value == (int)HACIZLI_MAL_KATEGORI.ARAÇ)
                        ucUcakGemiArac1.KontrolTipi = GemiUcakAracTipi.Arac;
                    if (gonderilenler[j].TIPI.Value == (int)HACIZLI_MAL_KATEGORI.GEMÝ)
                        ucUcakGemiArac1.KontrolTipi = GemiUcakAracTipi.Gemi;
                    if (gonderilenler[j].TIPI.Value == (int)HACIZLI_MAL_KATEGORI.UÇAK)
                        ucUcakGemiArac1.KontrolTipi = GemiUcakAracTipi.Ucak;
                    AddNewList[ucHacizMaster1.HacizFocusedRecord].AV001_TI_BIL_HACIZ_CHILDCollection[j].ARAC_BILGI_IDSource = DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.GetByID(gonderilenler[j].ID);
                }
                ucUcakGemiArac1.MyDataSource[0] = DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.GetByID(gonderilenler[0].ID);
            }
        }

        private void btnKaydet_ItemClick(object sender, EventArgs e)
        {
            bool result = true;

            #region Validate Yapýlacak

            //foreach (AV001_TI_BIL_HACIZ_MASTER n in AddNewList)
            //{
            //    string sStr = ucDavaNedenleri.Validate(n);

            //    if (sStr != string.Empty)
            //    {
            //        XtraMessageBox.Show("Lütfen kayýtlarý kontrol ediniz." + System.Environment.NewLine
            //            + System.Environment.NewLine + sStr, "Uyarý");

            //        result = false;
            //        break;
            //    }
            //}

            #endregion Validate Yapýlacak

            if (result)
            {
                if (Save())
                {
                    kaydedildi = true;

                    XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.", "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void c_lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            ucHacizChild1.Enabled = true;
            ucHacizMaster1.Enabled = true;
            if (c_lueDosya.EditValue != null)
                MyFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)c_lueDosya.EditValue);
        }

        private void child_ColumnChanged(object sender, AV001_TI_BIL_HACIZ_CHILDEventArgs e)
        {
            AV001_TI_BIL_HACIZ_CHILD child = sender as AV001_TI_BIL_HACIZ_CHILD;
            if (e.Column == AV001_TI_BIL_HACIZ_CHILDColumn.HACIZLI_MAL_KATEGORI_ID)
            {
                ucHacizChild1.MyKategoriID = (int)e.Value;

                if ((int)e.Value == (int)HACIZLI_MAL_KATEGORI.GAYRÝMENKUL)
                {
                    //if (MyGayri == null)
                    //{
                    pnlArac.Visible = false;
                    pnlGeyrimenkul.Visible = true;
                    pnlGeyrimenkul.Dock = DockStyle.Fill;

                    MyGayri = new TList<AV001_TI_BIL_GAYRIMENKUL>();
                    if (child.GAYRIMENKUL_BILGI_IDSource == null)
                        child.GAYRIMENKUL_BILGI_IDSource = new AV001_TI_BIL_GAYRIMENKUL();
                    MyGayri.Add(child.GAYRIMENKUL_BILGI_IDSource);
                    ucgcTarafli.MyDataSource = MyGayri;
                    panelControl2.Visible = true;

                    //panelControl2.BringToFront();
                    panelControl1.BringToFront();

                    ucHacizChild1.KategoriyeGoreAlanlar(false);

                    //}
                    //else
                    //{
                    //    pnlArac.Visible = false;
                    //    pnlGeyrimenkul.Visible = true;
                    //    pnlGeyrimenkul.Dock = DockStyle.Fill;
                    //    ucgcTarafli.MyDataSource = MyGayri;
                    //    panelControl2.Visible = true;
                    //    //panelControl2.BringToFront();
                    //    panelControl1.BringToFront();

                    //    ucHacizChild1.KategoriyeGoreAlanlar(false);
                    //}
                }
                if ((int)e.Value == (int)HACIZLI_MAL_KATEGORI.ARAÇ || (int)e.Value == (int)HACIZLI_MAL_KATEGORI.GEMÝ || (int)e.Value == (int)HACIZLI_MAL_KATEGORI.UÇAK)
                {
                    //if (MyArac == null)
                    //{
                    pnlGeyrimenkul.Visible = false;
                    pnlArac.Visible = true;
                    pnlArac.Dock = DockStyle.Fill;
                    MyArac = new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>();
                    if (child.ARAC_BILGI_IDSource == null)
                    {
                        child.ARAC_BILGI_IDSource = new AV001_TDI_BIL_GEMI_UCAK_ARAC();
                        child.ARAC_BILGI_IDSource.KAYIT_TARIHI = DateTime.Now;
                        child.ARAC_BILGI_IDSource.KLASOR_KODU = "GENEL";
                        child.ARAC_BILGI_IDSource.KONTROL_KIM = "AVUKATPRO";
                        child.ARAC_BILGI_IDSource.KONTROL_NE_ZAMAN = DateTime.Now;
                        child.ARAC_BILGI_IDSource.KONTROL_VERSIYON = 1;
                    }
                    MyArac.Add(child.ARAC_BILGI_IDSource); //BelgeUtil.Inits._per_AV001_TDI_BIL_GEMI_UCAK_ARAC.Find(vi => vi.ID == child.ARAC_BILGI_ID.Value));
                    if ((int)e.Value == (int)HACIZLI_MAL_KATEGORI.ARAÇ)
                    {
                        ucUcakGemiArac1.KontrolTipi = GemiUcakAracTipi.Arac;
                        MyArac[0].TIPI = (int)AracTipi.ARAC;
                    }
                    if ((int)e.Value == (int)HACIZLI_MAL_KATEGORI.GEMÝ)
                    {
                        ucUcakGemiArac1.KontrolTipi = GemiUcakAracTipi.Gemi;
                        MyArac[0].TIPI = (int)AracTipi.GEMI;
                    }
                    if ((int)e.Value == (int)HACIZLI_MAL_KATEGORI.UÇAK)
                    {
                        ucUcakGemiArac1.KontrolTipi = GemiUcakAracTipi.Ucak;
                        MyArac[0].TIPI = (int)AracTipi.UCAK;
                    }
                    ucUcakGemiArac1.MyDataSource = MyArac;
                    panelControl2.Visible = true;

                    //panelControl2.BringToFront();
                    panelControl1.BringToFront();

                    ucHacizChild1.KategoriyeGoreAlanlar(true);

                    //}
                    //else
                    //{
                    //    pnlGeyrimenkul.Visible = false;
                    //    pnlArac.Visible = true;
                    //    pnlArac.Dock = DockStyle.Fill;
                    //    if ((int)e.Value == (int)HACIZLI_MAL_KATEGORI.ARAÇ)
                    //        ucUcakGemiArac1.KontrolTipi = GemiUcakAracTipi.Arac;
                    //    if ((int)e.Value == (int)HACIZLI_MAL_KATEGORI.GEMÝ)
                    //        ucUcakGemiArac1.KontrolTipi = GemiUcakAracTipi.Gemi;
                    //    if ((int)e.Value == (int)HACIZLI_MAL_KATEGORI.UÇAK)
                    //        ucUcakGemiArac1.KontrolTipi = GemiUcakAracTipi.Ucak;
                    //    ucUcakGemiArac1.MyDataSource = MyArac;
                    //    panelControl2.Visible = true;
                    //    //panelControl2.BringToFront();
                    //    panelControl1.BringToFront();

                    //    ucHacizChild1.KategoriyeGoreAlanlar(true);
                    //}
                }
            }

            else if (e.Column == AV001_TI_BIL_HACIZ_CHILDColumn.HACIZLI_MAL_DEGERI)
            {
                ppara = (decimal)e.Value;
                if (Madet == 0)
                    Madet = (int)child.HACIZLI_MAL_ADEDI;
                child.HACIZLI_MAL_SATIR_TOPLAM_MIKTAR = Madet * ppara;
                child.HACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID = child.HACIZLI_MAL_DEGERI_DOVIZ_ID;
            }

            else if (e.Column == AV001_TI_BIL_HACIZ_CHILDColumn.HACIZLI_MAL_TUR_ID)
                ucHacizChild1.MyTurId = (int)e.Value;
        }

        private bool CikabilirMi()
        {
            if (AddNewList == null)
                return true;
            foreach (AV001_TI_BIL_HACIZ_MASTER h in AddNewList)
            {
                if (h.IsNew || h.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TList<AV001_TI_BIL_GAYRIMENKUL> gonderilenler = ((frmGayriMenkuller)sender).Secilenler;

            if (gonderilenler.Count > 0 && AddNewList.Count > 0 && ucHacizMaster1.HacizFocusedRecord >= 0)
            {
                AddNewList[ucHacizMaster1.HacizFocusedRecord].AV001_TI_BIL_HACIZ_CHILDCollection.Clear();

                for (int j = 0; j < gonderilenler.Count; j++)
                {
                    AV001_TI_BIL_HACIZ_CHILD child = AddNewList[ucHacizMaster1.HacizFocusedRecord].AV001_TI_BIL_HACIZ_CHILDCollection.AddNew();

                    child.HACIZLI_MAL_TUR_ID = (int)HACIZLI_MAL_TUR.ARSA;
                    child.HACIZLI_MAL_KATEGORI_ID = (int)MalKategori.GAYRIMENKUL;
                    child.HACIZLI_MAL_CINS_ID = (int)HACIZLI_MAL_CINS.TAM_ARSA;
                    child.GAYRIMENKUL_BILGI_ID = gonderilenler[j].ID;
                    DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(gonderilenler[j], false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_GAYRIMENKUL_TARAF>), typeof(TList<AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDAT>), typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>));
                    AddNewList[ucHacizMaster1.HacizFocusedRecord].AV001_TI_BIL_HACIZ_CHILDCollection[j].GAYRIMENKUL_BILGI_IDSource = gonderilenler[j];
                }
                ucgcTarafli.MyDataSource = gonderilenler;
            }
        }

        private void frmHacizGirisi_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MyGelisme == null) return;

            if (HacizKaynagi == HacizKaynak.Ýhtiyati_Haciz)
                ucIcraTarafGelismeleri.IhtiyatiHacizUygulamaHesapla(MyGelisme, MyFoy);

            else if (HacizKaynagi == HacizKaynak.Ýhtiyati_Tedbir)
                ucIcraTarafGelismeleri.IhtiyatiTedbirUygulamaHesapla(MyGelisme, MyFoy);

            else if (HacizKaynagi == HacizKaynak.Normal_Haciz)
                ucIcraTarafGelismeleri.HacizTarihiHesapla(MyGelisme, MyFoy);
        }

        private void frmHacizGirisi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapýlan deðiþiklikleri kaydetmediniz.Þimdi kaydedilsin mi?", "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    btnKaydet_ItemClick(null, null);

                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void frmHacizGirisi_Load(object sender, EventArgs e)
        {
            if (IsModul)
            {
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, Modul.Icra, false);

                //c_lueDosya.Properties.DataSource = Inits.DosyaDoldur("Icra");
                //c_lueDosya.Properties.DisplayMember = "FOY_NO";
                //c_lueDosya.Properties.ValueMember = "ID";
                //c_lueDosya.Enter += delegate { Inits.DosyaDoldur(AvukatProLib.Extras.ModulTip.Icra.ToString()); };
                //c_lueDosya.Properties.NullText = "Bir Ýcra Dosyasý Seçiniz...";
                ucHacizChild1.Enabled = false;
                ucHacizMaster1.Enabled = false;
            }

            ucHacizMaster1.vgHacizMaster.CellValueChanged += new CellValueChangedEventHandler(vgHacizMaster_CellValueChanged);

            ucgcTarafli.HacizKayitEkranimi = true;
            ucUcakGemiArac1.HacizKayitEkranimi = true;
            groupControl2.Visible = HacizEdilecekMalVar;
        }

        private void HacizChild_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_HACIZ_CHILD child = e.NewObject as AV001_TI_BIL_HACIZ_CHILD;
            if (child == null) child = new AV001_TI_BIL_HACIZ_CHILD();

            if (AddNewList != null && AddNewList.Count > 0)
                child.MAL_SIRA_NO = ucHacizChild.MalSiraNo(AddNewList[ucHacizMaster1.HacizFocusedRecord]);
            else
                child.MAL_SIRA_NO = 1;

            child.HACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID = 1;
            child.HACIZLI_MAL_DEGERI_DOVIZ_ID = 1;
            child.HACIZLI_MAL_ADEDI = 1;
            child.ALACAKLI_RIZASI_VAR_MI = true;
            child.HACIZ_ISLEM_DURUM_ID = 3;
            child.KAYIT_TARIHI = DateTime.Today;
            child.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            child.KONTROL_KIM = "AVUKATPRO";
            child.KONTROL_NE_ZAMAN = DateTime.Today;
            child.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            child.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            child.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            child.ColumnChanged += child_ColumnChanged;
            child.HACIZLI_MAL_ADET_BIRIM_ID = 9;

            e.NewObject = child;
        }

        private void HacizMaster_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_HACIZ_MASTER master = e.NewObject as AV001_TI_BIL_HACIZ_MASTER;
            if (master == null)
                master = new AV001_TI_BIL_HACIZ_MASTER();

            master.HACIZ_EDILECEK_MAL_VAR = HacizEdilecekMalVar;

            //master.HACIZ_KAYNAGI = (int)HacizKaynak.Normal_Haciz;
            master.HACIZ_KAYNAGI = (byte)HacizKaynagi;
            master.HM_ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
            master.HM_ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
            master.HM_ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
            master.HACIZ_SIRA_NO = ucHacizMaster.SiraNo(MyFoy);
            master.AV001_TI_BIL_HACIZ_CHILDCollection.AddingNew += HacizChild_AddingNew;

            //master.AV001_TI_BIL_HACIZ_CHILDCollection.AddNew();
            master.TALIMAT_ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
            master.TALIMAT_ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
            master.TALIMAT_ESAS_NO = MyFoy.ESAS_NO;
            master.TALIMAT_MI = true;
            master.HACIZ_ISTEYEN_CARI_ID = ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID.Value;
            if (ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy).Count > 0)
                master.HACIZ_ISTENEN_CARI_ID = ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID.Value;
            TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT> sorumluAvukat = ucIcraTarafBilgileri.SorumluTaraflariGetir(MyFoy);

            if (sorumluAvukat.Count > 0)
                master.HACIZ_SORUMLU_PERSONEL_ID = (int)sorumluAvukat[0].SORUMLU_AVUKAT_CARI_ID;

            e.NewObject = master;

            //AddNewList.Sort("HACIZ_SIRA_NO ASC");
        }

        private void HacizOnDegerler(AV001_TI_BIL_HACIZ_MASTER master)
        {
            AddNewList = new TList<AV001_TI_BIL_HACIZ_MASTER>();
            master.HACIZ_EDILECEK_MAL_VAR = HacizEdilecekMalVar;
            AddNewList.Add(master);
            if (master.AV001_TI_BIL_HACIZ_CHILDCollection == null || master.AV001_TI_BIL_HACIZ_CHILDCollection.Count == 0)
                DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.DeepLoad(master, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_HACIZ_MASTER>));
            if (master.AV001_TI_BIL_HACIZ_CHILDCollection.Count > 0)
            {
                DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepLoad(master.AV001_TI_BIL_HACIZ_CHILDCollection[0], false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_GAYRIMENKUL), typeof(AV001_TDI_BIL_GEMI_UCAK_ARAC));
                if (master.AV001_TI_BIL_HACIZ_CHILDCollection[0].HACIZLI_MAL_KATEGORI_ID == (int)HACIZLI_MAL_KATEGORI.GAYRÝMENKUL)
                {
                    if (master.AV001_TI_BIL_HACIZ_CHILDCollection[0].GAYRIMENKUL_BILGI_IDSource == null)
                        master.AV001_TI_BIL_HACIZ_CHILDCollection[0].GAYRIMENKUL_BILGI_IDSource = new AV001_TI_BIL_GAYRIMENKUL();
                    if (master.AV001_TI_BIL_HACIZ_CHILDCollection[0].GAYRIMENKUL_BILGI_IDSource != null)
                    {
                        #region genel boþ geçilemez deðerler

                        master.AV001_TI_BIL_HACIZ_CHILDCollection[0].GAYRIMENKUL_BILGI_IDSource.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                        master.AV001_TI_BIL_HACIZ_CHILDCollection[0].GAYRIMENKUL_BILGI_IDSource.KAYIT_TARIHI = DateTime.Today;
                        master.AV001_TI_BIL_HACIZ_CHILDCollection[0].GAYRIMENKUL_BILGI_IDSource.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                        master.AV001_TI_BIL_HACIZ_CHILDCollection[0].GAYRIMENKUL_BILGI_IDSource.KONTROL_KIM = "AVUKATPRO";
                        master.AV001_TI_BIL_HACIZ_CHILDCollection[0].GAYRIMENKUL_BILGI_IDSource.KONTROL_NE_ZAMAN = DateTime.Today;
                        master.AV001_TI_BIL_HACIZ_CHILDCollection[0].GAYRIMENKUL_BILGI_IDSource.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                        master.AV001_TI_BIL_HACIZ_CHILDCollection[0].GAYRIMENKUL_BILGI_IDSource.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                        master.AV001_TI_BIL_HACIZ_CHILDCollection[0].GAYRIMENKUL_BILGI_IDSource.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                        #endregion genel boþ geçilemez deðerler

                        pnlArac.Visible = false;
                        pnlGeyrimenkul.Visible = true;
                        pnlGeyrimenkul.Dock = DockStyle.Fill;
                        MyGayri = new TList<AV001_TI_BIL_GAYRIMENKUL>();

                        MyGayri.Add(master.AV001_TI_BIL_HACIZ_CHILDCollection[0].GAYRIMENKUL_BILGI_IDSource);
                        DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(master.AV001_TI_BIL_HACIZ_CHILDCollection[0].GAYRIMENKUL_BILGI_IDSource, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>), typeof(TList<AV001_TI_BIL_GAYRIMENKUL_TARAF>), typeof(TList<AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDAT>));

                        ucgcTarafli.MyDataSource = MyGayri;
                        panelControl2.Visible = true;
                        panelControl2.BringToFront();
                        panelControl1.BringToFront();
                    }
                }
                if (master.AV001_TI_BIL_HACIZ_CHILDCollection[0].HACIZLI_MAL_KATEGORI_ID == (int)HACIZLI_MAL_KATEGORI.ARAÇ || master.AV001_TI_BIL_HACIZ_CHILDCollection[0].HACIZLI_MAL_KATEGORI_ID == (int)HACIZLI_MAL_KATEGORI.GEMÝ || master.AV001_TI_BIL_HACIZ_CHILDCollection[0].HACIZLI_MAL_KATEGORI_ID == (int)HACIZLI_MAL_KATEGORI.UÇAK)
                {
                    if (master.AV001_TI_BIL_HACIZ_CHILDCollection[0].ARAC_BILGI_ID == null && master.AV001_TI_BIL_HACIZ_CHILDCollection[0].ARAC_BILGI_IDSource == null)
                        master.AV001_TI_BIL_HACIZ_CHILDCollection[0].ARAC_BILGI_IDSource = new AV001_TDI_BIL_GEMI_UCAK_ARAC();
                    if (master.AV001_TI_BIL_HACIZ_CHILDCollection[0].ARAC_BILGI_IDSource != null)
                    {
                        #region genel boþ geçilemez deðerler

                        master.AV001_TI_BIL_HACIZ_CHILDCollection[0].ARAC_BILGI_IDSource.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                        master.AV001_TI_BIL_HACIZ_CHILDCollection[0].ARAC_BILGI_IDSource.KAYIT_TARIHI = DateTime.Today;
                        master.AV001_TI_BIL_HACIZ_CHILDCollection[0].ARAC_BILGI_IDSource.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                        master.AV001_TI_BIL_HACIZ_CHILDCollection[0].ARAC_BILGI_IDSource.KONTROL_KIM = "AVUKATPRO";
                        master.AV001_TI_BIL_HACIZ_CHILDCollection[0].ARAC_BILGI_IDSource.KONTROL_NE_ZAMAN = DateTime.Today;
                        master.AV001_TI_BIL_HACIZ_CHILDCollection[0].ARAC_BILGI_IDSource.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                        master.AV001_TI_BIL_HACIZ_CHILDCollection[0].ARAC_BILGI_IDSource.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                        master.AV001_TI_BIL_HACIZ_CHILDCollection[0].ARAC_BILGI_IDSource.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                        #endregion genel boþ geçilemez deðerler

                        pnlGeyrimenkul.Visible = false;
                        pnlArac.Visible = true;
                        pnlArac.Dock = DockStyle.Fill;
                        MyArac = new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>();
                        MyArac.Add(master.AV001_TI_BIL_HACIZ_CHILDCollection[0].ARAC_BILGI_IDSource);
                        if (master.AV001_TI_BIL_HACIZ_CHILDCollection[0].ARAC_BILGI_IDSource.TIPI.Value == (int)HACIZLI_MAL_KATEGORI.ARAÇ)
                            ucUcakGemiArac1.KontrolTipi = GemiUcakAracTipi.Arac;
                        if (master.AV001_TI_BIL_HACIZ_CHILDCollection[0].ARAC_BILGI_IDSource.TIPI.Value == (int)HACIZLI_MAL_KATEGORI.GEMÝ)
                            ucUcakGemiArac1.KontrolTipi = GemiUcakAracTipi.Gemi;
                        if (master.AV001_TI_BIL_HACIZ_CHILDCollection[0].ARAC_BILGI_IDSource.TIPI.Value == (int)HACIZLI_MAL_KATEGORI.UÇAK)
                            ucUcakGemiArac1.KontrolTipi = GemiUcakAracTipi.Ucak;
                        DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.DeepLoad(master.AV001_TI_BIL_HACIZ_CHILDCollection[0].ARAC_BILGI_IDSource, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>));
                        ucUcakGemiArac1.MyDataSource = MyArac;
                        panelControl2.Visible = true;
                        panelControl2.BringToFront();
                        panelControl1.BringToFront();
                    }
                }
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnKaydet_ItemClick;
        }

        private bool Save()
        {
            bool sonuc = false;

            if (MyFoy != null)
            {
                AddNewList.ForEach(delegate(AV001_TI_BIL_HACIZ_MASTER h) { h.ICRA_FOY_ID = MyFoy.ID; });
            }
            else if (c_lueDosya.EditValue != null && (int)c_lueDosya.EditValue > 0)
            {
                addNewList.ForEach(delegate(AV001_TI_BIL_HACIZ_MASTER h) { h.ICRA_FOY_ID = (int)c_lueDosya.EditValue; });
            }

            foreach (var item in addNewList)
            {
                if (item.ID == 0)
                {
                    if (myFoy.FORM_TIP_ID == (int)FormTipleri.Form151 || myFoy.FORM_TIP_ID == (int)FormTipleri.Form152 || myFoy.FORM_TIP_ID == (int)FormTipleri.Form50 || myFoy.FORM_TIP_ID == (int)FormTipleri.Form201)
                        item.HACIZ_MI = false;
                    else
                        item.HACIZ_MI = true;

                    if (MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.Exists(delegate(AV001_TI_BIL_HACIZ_MASTER haciz) { return haciz.ID == item.ID; })) continue;
                    MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.AddRange(AddNewList);
                }
            }

            if (MyGayri != null)
            {
                foreach (var gayri in MyGayri)
                {
                    foreach (var item in addNewList)
                    {
                        foreach (var child in item.AV001_TI_BIL_HACIZ_CHILDCollection)
                        {
                            child.AV001_TI_BIL_KIYMET_TAKDIRICollection.AddRange(gayri.AV001_TI_BIL_KIYMET_TAKDIRICollection);
                            MyFoy.AV001_TI_BIL_KIYMET_TAKDIRICollection.AddRange(gayri.AV001_TI_BIL_KIYMET_TAKDIRICollection);
                        }
                    }
                }
            }
            if (MyArac != null)
            {
                foreach (var arac in MyArac)
                {
                    foreach (var item in addNewList)
                    {
                        foreach (var child in item.AV001_TI_BIL_HACIZ_CHILDCollection)
                        {
                            child.AV001_TI_BIL_KIYMET_TAKDIRICollection.AddRange(BelgeUtil.Inits.KiymetTakdiriGetir().FindAll(vi => vi.GEMI_UCAK_ARAC_ID == arac.ID));
                            MyFoy.AV001_TI_BIL_KIYMET_TAKDIRICollection.AddRange(BelgeUtil.Inits.KiymetTakdiriGetir().FindAll(vi => vi.GEMI_UCAK_ARAC_ID == arac.ID));
                        }
                    }
                }
            }
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                trans.BeginTransaction();

                foreach (AV001_TI_BIL_HACIZ_MASTER haciz in AddNewList)
                {
                    for (int rowHandle = 0; rowHandle < ucHacizMaster1.rlueBelge.View.RowCount; rowHandle++)
                    {
                        if ((bool)ucHacizMaster1.rlueBelge.View.GetRowCellValue(rowHandle, "IsSelected") == true)
                            haciz.NN_BELGE_HACIZCollection.Add(new NN_BELGE_HACIZ() { BELGE_ID = (int)ucHacizMaster1.rlueBelge.View.GetRowCellValue(rowHandle, "Id") });
                    }

                    //if (haciz.AV001_TI_BIL_HACIZ_CHILDCollection.Count == 0)
                    //    DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.DeepLoad(MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_HACIZ_CHILD>));
                    foreach (AV001_TI_BIL_HACIZ_CHILD item in haciz.AV001_TI_BIL_HACIZ_CHILDCollection)
                    {
                        if (MyArac == null)
                            DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_GEMI_UCAK_ARAC));
                        if (MyArac != null)
                        {
                            DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.DeepSave(trans, MyArac, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>));
                            if (item.ARAC_BILGI_ID == null || item.ARAC_BILGI_ID == 0)
                                item.ARAC_BILGI_ID = MyArac[0].ID;
                            if (MyFoy.NN_ICRA_GEMI_UCAK_ARACCollection.Count == 0)
                                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<NN_ICRA_GEMI_UCAK_ARAC>));
                            if (MyFoy.NN_ICRA_GEMI_UCAK_ARACCollection.Exists(delegate(NN_ICRA_GEMI_UCAK_ARAC arac) { return arac.GEMI_UCAK_ARAC_ID == item.ARAC_BILGI_ID; })) continue;
                            NN_ICRA_GEMI_UCAK_ARAC uga = new NN_ICRA_GEMI_UCAK_ARAC();
                            uga.GEMI_UCAK_ARAC_ID = item.ARAC_BILGI_ID.Value;
                            uga.ICRA_FOY_ID = MyFoy.ID;
                            MyFoy.NN_ICRA_GEMI_UCAK_ARACCollection.Add(uga);
                        }

                        if (item.GAYRIMENKUL_BILGI_IDSource == null)
                            DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_GAYRIMENKUL));
                        if (item.GAYRIMENKUL_BILGI_IDSource != null)
                        {
                            DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepSave(trans, item.GAYRIMENKUL_BILGI_IDSource, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>), typeof(TList<AV001_TI_BIL_GAYRIMENKUL_TARAF>), typeof(TList<AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDAT>));

                            if (item.GAYRIMENKUL_BILGI_ID == null || item.GAYRIMENKUL_BILGI_ID == 0)
                                item.GAYRIMENKUL_BILGI_ID = item.GAYRIMENKUL_BILGI_IDSource.ID;

                            if (MyFoy.NN_ICRA_GAYRIMENKULCollection.Count == 0)
                                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<NN_ICRA_GAYRIMENKUL>));
                            if (MyFoy.NN_ICRA_GAYRIMENKULCollection.Exists(delegate(NN_ICRA_GAYRIMENKUL pol) { return pol.GAYRIMENKUL_ID == item.GAYRIMENKUL_BILGI_ID; })) continue;
                            NN_ICRA_GAYRIMENKUL gayrimenkul = new NN_ICRA_GAYRIMENKUL();
                            gayrimenkul.GAYRIMENKUL_ID = item.GAYRIMENKUL_BILGI_ID.Value;
                            gayrimenkul.ICRA_FOY_ID = MyFoy.ID;
                            MyFoy.NN_ICRA_GAYRIMENKULCollection.Add(gayrimenkul);
                        }
                    }
                }

                //AddNewList.ForEach(item =>
                //    {
                //        DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepSave(trans, item.AV001_TI_BIL_HACIZ_CHILDCollection, DeepSaveType.IncludeChildren,  typeof(TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>));
                //    });

                DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.DeepSave(trans, AddNewList, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_HACIZ_CHILD>), typeof(TList<AV001_TI_BIL_GAYRIMENKUL>), typeof(TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>));
                DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(trans, MyFoy, DeepSaveType.IncludeChildren, typeof(TList<NN_ICRA_GAYRIMENKUL>), typeof(TList<NN_ICRA_GEMI_UCAK_ARAC>));

                trans.Commit();

                sonuc = true;

                ucIcraTarafGelismeleri.GelismeIslemleri(MyFoy);
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);

                for (int i = 0; i < AddNewList.Count; i++)
                {
                    MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.Remove(AddNewList[i]);
                }

                kaydedildi = false;

                return false;
            }

            finally
            {
                trans.Dispose();
            }

            return sonuc;
        }

        //Seçili Haciz Child'e göre ilgili mal bilgilerinin gelmesi için eklendi.
        private void ucHacizChild1_HacizChildFocusedRecordChanged(object sender, IndexChangedEventArgs e)
        {
            if (ucHacizChild1.MyDataSource == null || e.NewIndex < 0) return;

            AV001_TI_BIL_HACIZ_CHILD child = new AV001_TI_BIL_HACIZ_CHILD();

            if (ucHacizChild1.MyDataSource.Count > 0)
                child = ucHacizChild1.MyDataSource[e.NewIndex];

            DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepLoad(child, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_GAYRIMENKUL), typeof(AV001_TDI_BIL_GEMI_UCAK_ARAC));

            if (child.GAYRIMENKUL_BILGI_IDSource != null)
            {
                pnlArac.Visible = false;
                pnlGeyrimenkul.Visible = true;
                pnlGeyrimenkul.Dock = DockStyle.Fill;

                MyGayri = new TList<AV001_TI_BIL_GAYRIMENKUL>();
                MyGayri.Add(child.GAYRIMENKUL_BILGI_IDSource);
                ucgcTarafli.MyDataSource = MyGayri;
                panelControl2.Visible = true;
                panelControl1.BringToFront();

                ucHacizChild1.KategoriyeGoreAlanlar(false);
            }
            else if (child.ARAC_BILGI_IDSource != null)
            {
                pnlGeyrimenkul.Visible = false;
                pnlArac.Visible = true;
                pnlArac.Dock = DockStyle.Fill;
                MyArac = new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>();
                MyArac.Add(DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.GetByID(child.ARAC_BILGI_ID.Value));// BelgeUtil.Inits._per_AV001_TDI_BIL_GEMI_UCAK_ARAC.Find(vi => vi.ID == child.ARAC_BILGI_ID.Value));
                if (child.HACIZLI_MAL_KATEGORI_ID == (int)HACIZLI_MAL_KATEGORI.ARAÇ)
                    ucUcakGemiArac1.KontrolTipi = GemiUcakAracTipi.Arac;
                if (child.HACIZLI_MAL_KATEGORI_ID == (int)HACIZLI_MAL_KATEGORI.GEMÝ)
                    ucUcakGemiArac1.KontrolTipi = GemiUcakAracTipi.Gemi;
                if (child.HACIZLI_MAL_KATEGORI_ID == (int)HACIZLI_MAL_KATEGORI.UÇAK)
                    ucUcakGemiArac1.KontrolTipi = GemiUcakAracTipi.Ucak;
                ucUcakGemiArac1.MyDataSource = MyArac;
                panelControl2.Visible = true;
                panelControl1.BringToFront();

                ucHacizChild1.KategoriyeGoreAlanlar(true);
            }
            else
            {
                pnlArac.Visible = false;
                pnlGeyrimenkul.Visible = false;
            }
        }

        //Listeden mallarýn getirilebilmesi için yeniden düzenlendi.
        private void ucHacizChild1_HacizChildListedenGetir(object sender, ListedenGetirEventArgs e)
        {
            if (AddNewList.Count > 0)
            {
                if (AddNewList[ucHacizMaster1.HacizFocusedRecord].AV001_TI_BIL_HACIZ_CHILDCollection.Count > 0)
                {
                    int mKategoriId = AddNewList[ucHacizMaster1.HacizFocusedRecord].AV001_TI_BIL_HACIZ_CHILDCollection[ucHacizChild1.HacizChildFocusedRecord].HACIZLI_MAL_KATEGORI_ID;

                    mKategori = (MalKategori)mKategoriId;
                }
            }

            if (mKategori == MalKategori.NULL)
                XtraMessageBox.Show("Haciz detaylarýný listeden getirmek için mal kategorisi gereklidir.Lütfen hacizli mal kategorisi seçiniz.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (mKategori == MalKategori.GAYRIMENKUL)
                {
                    frmGayriMenkuller frm = new frmGayriMenkuller();
                    frm.MyFoy = this.MyFoy;
                    if (AddNewList.Count > 0 && AddNewList[ucHacizMaster1.HacizFocusedRecord] != null)
                        tARAFýD = AddNewList[ucHacizMaster1.HacizFocusedRecord].HACIZ_ISTENEN_CARI_ID.ToString();
                    frm.TarafId = tARAFýD;

                    //frm.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.FormClosed += frm_FormClosed;
                    frm.Show();
                }
                else if (mKategori == MalKategori.ARAÇ || mKategori == MalKategori.GEMI || MKategori == MalKategori.UCAK)
                {
                    frmAracBilgileri arac = new frmAracBilgileri();
                    arac.MyFoy = this.MyFoy;
                    if (AddNewList.Count > 0 && AddNewList[ucHacizMaster1.HacizFocusedRecord] != null)
                        arac.borcluTarafCariId = AddNewList[ucHacizMaster1.HacizFocusedRecord].HACIZ_ISTENEN_CARI_ID;

                    //arac.MdiParent = null;
                    arac.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    arac.FormClosed += arac_FormClosed;
                    arac.Show();
                }
            }
        }

        private void vgHacizMaster_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Row.Name == "rowMalVarmi")
            {
                groupControl2.Visible = (bool)e.Value;
                if ((bool)e.Value == false)
                    ucHacizChild1.MyDataSource = null;
            }
        }

        #endregion Methods
    }
}