using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi
{
    public partial class frmDavaIcraIhtiyatiTedbir : Util.BaseClasses.AvpXtraForm
    {
        public frmDavaIcraIhtiyatiTedbir()
        {
            InitializeComponent();
            InitializeEvents();
            this.FormClosed += frmDavaIcraIhtiyatiTedbir_FormClosed;

            //this.DosyaKaydedildi += btnKaydet_ItemClick;
            this.ucIhtiyatiTedbir1.FocusedTedbirChanged += uc_FocusedTedbirChanged;
        }

        public bool DosyaKayitEkranindanmi;
        public TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> tedbirList = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>();
        private TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> _MyDataSource;
        private AV001_TDIE_BIL_PROJE _MyProje;
        private bool isModul;

        private AV001_TD_BIL_FOY myDavaFoy;

        private AV001_TI_BIL_FOY myFoy;

        private TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF> myTaraf;

        public event EventHandler<EventArgs> Kaydedildi;

        public bool IsModul
        {
            get { return isModul; }
            set
            {
                isModul = value;
                panelControl1.Visible = value;
            }
        }

        /// <summary>
        /// Ýlgili formun klasör üzerinden ekleme yapmak için açýldýðýný belirten property.
        /// </summary>
        public bool KlasorIcin { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (_MyDataSource == null)
                {
                    _MyDataSource = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>();
                    MyDataSource.AddingNew += MyDataSource_AddingNew;
                    _MyDataSource.AddNew();
                }
                else
                {
                    MyDataSource.AddingNew += MyDataSource_AddingNew;
                    DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.DeepLoad(MyDataSource, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>), typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF>));
                    if (MyDataSource != null && MyDataSource.Count > 0)
                    {
                        if (MyFoy != null)
                        {
                            foreach (AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF item in MyDataSource[0].AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection)
                            {
                                item.ICRA_FOY_ID = myFoy.ID;
                            }
                        }
                        if (MyDavaFoy != null)
                        {
                            foreach (var item in MyDataSource)
                            {
                                item.DAVA_FOY_ID = myDavaFoy.ID;
                                //if (item.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection.Count == 0)
                                //{

                                //}
                            }
                        }
                        ucIhtiyatiTedbirTaraf1.MyDataSource = MyDataSource[0].AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection;
                    }
                }
                ucIhtiyatiTedbir1.MyDataSource = _MyDataSource;

                //if (ucIhtiyatiTedbir1.CurrentTedbir != null)
                //{
                //    //<YY-20090619>Klasör ile düzgün çalýþabilmesi amacýyla aþaðýdaki kodlar deðiþtirilmiþtir.

                //    if (MyFoy != null)
                //        ucIhtiyatiTedbirTaraf1.MyIcraFoy = MyFoy;
                //    if (MyDavaFoy != null)
                //        ucIhtiyatiTedbirTaraf1.MyDavaFoy = MyDavaFoy;
                //    ucIhtiyatiTedbirTaraf1.MyDataSource = ucIhtiyatiTedbir1.CurrentTedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection;
                //    //</YY-20090619>
                //}

                ///<YY-20090619>
                ///Bu aþaðýdaki kodun hangi akla hizmet ettiðini anlamadýðýmdan comment ediyorum.
                ///Bi sýkýntý yaþarsak lütfen mantýklý açýklama ile YY ye müracat ediniz.
                //else
                //{
                //    ucIhtiyatiTedbirTaraf1.MyDataSource = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF>();
                //}
                ///</YY-20090619>
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TD_BIL_FOY MyDavaFoy
        {
            get { return myDavaFoy; }
            set
            {
                myDavaFoy = value;
                if ((value != null) && (!this.DesignMode))
                {
                    myDavaFoy = value;

                    ucIhtiyatiTedbirTaraf1.MyDavaFoy = MyDavaFoy;
            //        ucIhtiyatiTedbirTaraf1.MyDataSource =
            //ucIhtiyatiTedbir1.CurrentTedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set { myFoy = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY_TARAF_GELISME MyGelisme { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TDIE_BIL_PROJE MyProje
        {
            get { return _MyProje; }
            set
            {
                _MyProje = value;
                if (value != null)
                {
                    ucIhtiyatiTedbir1.KlasorIcin = true;
                    ucIhtiyatiTedbirTaraf1.MyProje = value;

                    tedbirList.AddingNew += MyDataSource_AddingNew;
                    if (tedbirList.Count == 0)
                        tedbirList.AddNew();

                    ucIhtiyatiTedbir1.MyDataSource = tedbirList;
                    if (tedbirList[0].AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection.Count == 0)
                        DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.DeepLoad(tedbirList, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF>), typeof(TList<AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR>));

                    ucIhtiyatiTedbirTaraf1.MyDataSource = tedbirList[0].AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection;

                    ucIhtiyatiTedbir1.MyDataSource.AddingNew += MyDataSource_AddingNew;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF> MyTaraf
        {
            get { return myTaraf; }
            set
            {
                if (value != null)
                {
                    if (myFoy != null)
                    {
                        myTaraf = value;
                        ucIhtiyatiTedbirTaraf1.MyDataSource = value;
                        ucIhtiyatiTedbirTaraf1.MyIcraFoy = MyFoy;
                    }
                    if (MyDavaFoy != null)
                    {
                        myTaraf = value;
                        ucIhtiyatiTedbirTaraf1.MyDataSource = value;
                        ucIhtiyatiTedbirTaraf1.MyDavaFoy = MyDavaFoy;
                    }
                }
            }
        }

        internal void ShowDialog(AV001_TDIE_BIL_PROJE proje)
        {
            MyProje = proje;
            this.Show();
        }

        private void frmDavaIcraIhtiyatiTedbir_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.",
                                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDavaIcraIhtiyatiTedbir_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MyFoy != null)
            {
                if (MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection[0].ID == 0)
                    MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.RemoveAt(0);
            }
            if (MyGelisme == null)
            {
                return;
            }

            ucIcraTarafGelismeleri.IhtiyatiTedbirHesapla(MyGelisme, MyFoy);
        }

        private void frmDavaIcraIhtiyatiTedbir_Load(object sender, EventArgs e)
        {
            if (isModul)
            {
                BelgeUtil.Inits.ModulKodGetir(lueModul);
                ucIhtiyatiTedbir1.Enabled = false;
                ucIhtiyatiTedbirTaraf1.Enabled = false;
            }
        }

        private void glueDosya_EditValueChanged(object sender, EventArgs e)
        {
            ucIhtiyatiTedbir1.Enabled = true;
            ucIhtiyatiTedbirTaraf1.Enabled = true;
            if ((int)lueModul.EditValue == (int)AvukatProLib.Extras.ModulTip.Icra)
            {
                MyFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)glueDosya.EditValue);
                MyDataSource = MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;
            }

            else if ((int)lueModul.EditValue == (int)AvukatProLib.Extras.ModulTip.Dava)
            {
                MyDavaFoy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)glueDosya.EditValue);
                MyDataSource = MyDavaFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;
            }
            MyDataSource = null;
        }

        //private void btnKaydet_ItemClick(object sender, EventArgs e)
        //{
        //    //this.DialogResult = DialogResult.OK;
        //    //this.Close();
        //}
        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmDavaIcraIhtiyatiTedbir_Button_Kaydet_Click;
        }

        private void lueModul_EditValueChanged(object sender, EventArgs e)
        {
            glueDosya.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur(lueModul.Text);
            glueDosya.Properties.DisplayMember = "FOY_NO";
            glueDosya.Properties.ValueMember = "ID";
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_IHTIYATI_TEDBIR tedbir = e.NewObject as AV001_TDI_BIL_IHTIYATI_TEDBIR;
            if (tedbir == null)
            {
                tedbir = new AV001_TDI_BIL_IHTIYATI_TEDBIR();
                tedbir.TALEP_TARIHI = DateTime.Today;
            }

            if (MyProje != null)
            {
                if (MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TDIE_BIL_PROJE_TARAF>));

                foreach (AV001_TDIE_BIL_PROJE_TARAF pTrf in MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection)
                {
                    AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF tTrf =
                        tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection.AddNew();
                    tTrf.ICRA_CARI_TARAF_ID = pTrf.CARI_ID;
                    DataRepository.AV001_TDIE_BIL_PROJE_TARAFProvider.DeepLoad(pTrf, true, DeepLoadType.IncludeChildren,
                                                                               typeof(AV001_TDI_BIL_CARI));
                    if (pTrf.CARI_IDSource != null && pTrf.CARI_IDSource.MUVEKKIL_MI)
                        tTrf.ICRA_TARAF_SIFAT_ID =
                            tTrf.DAVA_TARAF_SIFAT_ID =
                            DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID((int)TarafSifat.DAVACI).ID;
                    else
                        tTrf.ICRA_TARAF_SIFAT_ID =
                            tTrf.DAVA_TARAF_SIFAT_ID =
                            DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID((int)TarafSifat.DAVALI).ID;
                }
            }

            //if (IsModul)
            //{
            if (MyFoy != null)
            {
                foreach (AV001_TI_BIL_FOY_TARAF taraf in ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy))
                {
                    AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF trf =
                        tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection.AddNew();
                    trf.ICRA_CARI_TARAF_ID = taraf.CARI_ID;
                    trf.ICRA_TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
                }
                ucIhtiyatiTedbirTaraf1.MyIcraFoy = MyFoy;
                ucIhtiyatiTedbirTaraf1.MyDataSource = tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection;
            }
            else if (MyDavaFoy != null)
            {
                foreach (AV001_TD_BIL_FOY_TARAF taraf in ucIcraTarafBilgileri.BorcluTaraflariGetir(MyDavaFoy))
                {
                    AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF trf =
                        tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection.AddNew();
                    trf.ICRA_CARI_TARAF_ID = taraf.CARI_ID;
                    trf.ICRA_TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
                }
                ucIhtiyatiTedbirTaraf1.MyIcraFoy = MyFoy;
                ucIhtiyatiTedbirTaraf1.MyDataSource = tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection;

                //foreach (var tara in MyDavaFoy.AV001_TD_BIL_FOY_TARAFCollection)
                //{
                //    if (tara.TARAF_SIFAT_ID == (int)TarafSifat.DAVALI)
                //    {
                //        AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF trf =
                //            tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection.AddNew();
                //        trf.ICRA_CARI_TARAF_ID = tara.CARI_ID;
                //        trf.ICRA_TARAF_SIFAT_ID = tara.TARAF_SIFAT_ID;
                //        ucIhtiyatiTedbirTaraf1.MyDavaFoy = MyDavaFoy;
                //    }
                //    ucIhtiyatiTedbirTaraf1.MyDataSource = tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection;
                //}
            }
            else
                ucIhtiyatiTedbirTaraf1.MyDataSource = tedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection;

            // }

            tedbir.KAYIT_TARIHI = DateTime.Now;
            tedbir.KONTROL_NE_ZAMAN = DateTime.Now;
            tedbir.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            tedbir.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            tedbir.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            tedbir.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;

            e.NewObject = tedbir;
        }

        private bool Save()
        {
            bool sonuc = false;
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            #region Klasor

            if (KlasorIcin)
            {
                try
                {
                    tran.BeginTransaction();
                    DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.DeepSave(tran, ucIhtiyatiTedbir1.MyDataSource,
                                                                                  DeepSaveType.IncludeChildren,
                                                                                  typeof(
                                                                                      TList
                                                                                      <
                                                                                      AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF
                                                                                      >));
                    foreach (AV001_TDI_BIL_IHTIYATI_TEDBIR iTedbir in ucIhtiyatiTedbir1.MyDataSource)
                    {
                        if (
                            MyProje.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIRCollection.Exists(
                                delegate(AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR kiymetliEvrak) { return kiymetliEvrak.IHTIYATI_TEDBIR_ID == iTedbir.ID; })) continue;

                        AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR pHaciz = new AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR();
                        pHaciz.PROJE_ID = MyProje.ID;
                        pHaciz.IHTIYATI_TEDBIR_ID = iTedbir.ID;
                        DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIRProvider.Save(tran, pHaciz);
                    }

                    tran.Commit();
                    sonuc = true;
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen)
                        tran.Rollback();

                    BelgeUtil.ErrorHandler.Catch(this, ex, BelgeUtil.Bilesen.Kayit);
                }
                finally
                {
                    tran.Dispose();
                }
            }

            #endregion Klasor

            else
            {
                //if (MyFoy != null && DosyaKayitEkranindanmi) aykut kaldýrdý
                if (MyFoy != null)
                {
                    MyDataSource.ForEach(delegate(AV001_TDI_BIL_IHTIYATI_TEDBIR f) { f.ICRA_FOY_ID = MyFoy.ID; });
                }
                if (MyDavaFoy != null)
                {
                    MyDataSource.ForEach(delegate(AV001_TDI_BIL_IHTIYATI_TEDBIR f)
                                             {
                                                 f.DAVA_FOY_ID = MyDavaFoy.ID;
                                                 f.DAVA_TARIHI = MyDavaFoy.DAVA_TARIHI;
                                             });
                }

                //  MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.AddRange(MyDataSource);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.DeepSave(tran, MyDataSource,
                                                                                  DeepSaveType.IncludeChildren,
                                                                                  typeof(
                                                                                      TList
                                                                                      <
                                                                                      AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF
                                                                                      >));
                    foreach (var item in MyDataSource)
                    {
                        if (ucIhtiyatiTedbir1.MyDataSourceTeminat != null)
                        {
                            foreach (var mektup in ucIhtiyatiTedbir1.MyDataSourceTeminat)
                            {
                                if (mektup.IHTIYATI_TEDBIR_ID == null)
                                    mektup.IHTIYATI_TEDBIR_ID = item.ID;
                                if (MyFoy != null)
                                    mektup.ICRA_FOY_ID = MyFoy.ID;
                                else if (MyDavaFoy != null)
                                    mektup.DAVA_FOY_ID = MyDavaFoy.ID;
                            }
                        }
                    }

                    if (ucIhtiyatiTedbir1.MyDataSourceTeminat != null)
                        DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.Save(tran, ucIhtiyatiTedbir1.MyDataSourceTeminat);

                    tran.Commit();

                    ucIcraTarafGelismeleri.GelismeIslemleri(MyFoy);

                    sonuc = true;
                }
                catch
                {
                    if (tran.IsOpen)
                        tran.Rollback();
                    sonuc = false;
                }
                finally
                {
                    tran.Dispose();
                }
            }

            if (sonuc)
                if (this.Kaydedildi != null)
                    Kaydedildi(this, null);
            return sonuc;
        }

        private void uc_FocusedTedbirChanged(object sender, DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (ucIhtiyatiTedbir1.CurrentTedbir != null)
            {
                #region <YY-20090619>

                //Daha önce bu iþlevi gören bir kod varmýþ ancak CC tarafýndan
                //comment edilmiþ Klasör ile ilgili iþlem yapýlýrken CodeReview sýrasýnda tekrar
                //aþaðýdaki þekilde yazýldý. Eðer bir hata alýnýrsa lütfen YY ye durumu bildirerek
                //iþleme o þekilde devam ediniz.
                if (MyFoy != null)
                    ucIhtiyatiTedbirTaraf1.MyIcraFoy = MyFoy;
                if (MyDavaFoy != null)
                    ucIhtiyatiTedbirTaraf1.MyDavaFoy = MyDavaFoy;
                if (e != null)
                    if (e.NewIndex >= 0)
                    {
                        if (MyDataSource != null)
                        {
                            if (MyDataSource[e.NewIndex].AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection.Count == 0)
                                DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.DeepLoad(MyDataSource, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF>));

                            ucIhtiyatiTedbirTaraf1.MyDataSource = MyDataSource[e.NewIndex].AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection;
                        }
                    }

                #endregion <YY-20090619>
            }
        }
    }
}