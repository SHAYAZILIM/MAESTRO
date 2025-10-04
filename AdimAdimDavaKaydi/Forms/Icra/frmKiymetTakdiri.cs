using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Icra
{
    public partial class frmKiymetTakdiri : AvpXtraForm
    {
        public frmKiymetTakdiri()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += frmKiymetTakdiri_Load;
            this.FormClosing += frmKiymetTakdiri_FormClosing;
        }

        public bool EkspertizKaydiMi;

        private TList<AV001_TI_BIL_KIYMET_TAKDIRI> addNewList;

        private TList<AV001_TI_BIL_KIYMET_TAKDIRI> childKiymet = new TList<AV001_TI_BIL_KIYMET_TAKDIRI>();

        private frmHacizliMallar frm;

        private bool kaydedildi;

        private AV001_TI_BIL_FOY myIcraFoy;

        #region <MB-20100623>

        //Bu property, eðer yeni kaydedilen þahýs varsa, gridler üzerindeki lookup'ýn yeniden dolmasýný saðlamak için eklendi.
        public static bool YeniCariKaydiYapildi;

        #endregion <MB-20100623>

        [Browsable(false)]
        public TList<AV001_TI_BIL_KIYMET_TAKDIRI> AddNewList
        {
            get { return addNewList; }
            set
            {
                if (!this.DesignMode && value != null)
                {
                    addNewList = value;
                    ucKiymetTakdiri1.MyFoy = MyIcraFoy;
                    ucKiymetTakdiri1.MyDataSource = value;
                    ucKiymetTakdiri1.EkspertizKaydiMi = EkspertizKaydiMi;
                }
            }
        }

        public int MyHacizChild { get; set; }

        [Browsable(false)]
        public AV001_TI_BIL_FOY MyIcraFoy
        {
            get { return myIcraFoy; }
            set
            {
                myIcraFoy = value;
                if (value != null && !DesignMode)
                {
                    try
                    {
                        if (AddNewList == null) AddNewList = new TList<AV001_TI_BIL_KIYMET_TAKDIRI>();

                        AddNewList.AddingNew += Takdir_AddingNew;
                        ucKiymetTakdiri1.MyFoy = value;

                        // AddNewList.AddNew();
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyIcraFoy, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TI_BIL_HACIZ_MASTER>),
                                                                         typeof(TList<AV001_TI_BIL_GAYRIMENKUL>),
                                                                         typeof(TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>)
                                                                         );
                        DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.DeepLoad(
                            MyIcraFoy.AV001_TI_BIL_HACIZ_MASTERCollection, false, DeepLoadType.IncludeChildren,
                            typeof(TList<AV001_TI_BIL_HACIZ_CHILD>));
                        foreach (AV001_TI_BIL_HACIZ_MASTER master in MyIcraFoy.AV001_TI_BIL_HACIZ_MASTERCollection)
                        {
                            foreach (AV001_TI_BIL_HACIZ_CHILD child in master.AV001_TI_BIL_HACIZ_CHILDCollection)
                            {
                                DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepLoad(child, false,
                                                                                         DeepLoadType.IncludeChildren,
                                                                                         typeof(
                                                                                             TList
                                                                                             <
                                                                                             AV001_TI_BIL_KIYMET_TAKDIRI
                                                                                             >));

                                // childKiymet = child.AV001_TI_BIL_KIYMET_TAKDIRICollection;
                                // AddNewList = childKiymet;
                            }
                        }

                        // ucKiymetTakdiri1.MyDataSource = AddNewList;
                        //AddNewList.ForEach(delegate(AV001_TI_BIL_KIYMET_TAKDIRI k)
                        //{
                        //    k.PropertyChanged += new PropertyChangedEventHandler(kanit_PropertyChanged);
                        //});
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
        }

        public void Show(AV001_TI_BIL_FOY foyEntity)
        {
            MyIcraFoy = foyEntity;

            this.Show();
        }

        private bool CikabilirMi()
        {
            foreach (AV001_TI_BIL_KIYMET_TAKDIRI n in AddNewList)
            {
                if (n.IsNew || n.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void dnKiymetTakdiri_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "ListedenGetir")
            {
                frm = new frmHacizliMallar();
                frm.FormClosed += frm_FormClosed;
                frm.Show(MyIcraFoy);
            }
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frm.Secilenler.Count > 0)
            {
                SecilenleriEkle();
            }
        }

        private void frmKiymetTakdiri_Button_Kaydet_Click(object sender, EventArgs e)
        {
            bool result = true;
            foreach (AV001_TI_BIL_KIYMET_TAKDIRI n in AddNewList)
            {
                string sStr = ucKiymetTakdiri.Validate(n);

                if (sStr != string.Empty)
                {
                    XtraMessageBox.Show("Lütfen kayýtlarý kontrol ediniz." + System.Environment.NewLine
                                        + System.Environment.NewLine + sStr, "Uyarý");

                    result = false;
                    break;
                }
            }

            if (result)
            {
                if (Save())
                {
                    kaydedildi = true;

                    XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.",
                                        "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmKiymetTakdiri_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapýlan deðiþiklikleri kaydetmediniz.Þimdi kaydedilsin mi?",
                                                      "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    frmKiymetTakdiri_Button_Kaydet_Click(null, null);

                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
                else if (dr == DialogResult.No)
                    e.Cancel = false;
            }
        }

        private void frmKiymetTakdiri_Load(object sender, EventArgs e)
        {
            //Inits.CariGetirBilirkisi();
            ucKiymetTakdiri1.dnKiymetTakdiri.ButtonClick += dnKiymetTakdiri_ButtonClick;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmKiymetTakdiri_Button_Kaydet_Click;
        }

        private bool Save()
        {
            bool sonuc = false;
            int? gayrimenkulId = null;
            int? aracId = null;

            if (MyIcraFoy.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_ICRA_GAYRIMENKUL.Count > 0)
                gayrimenkulId = MyIcraFoy.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_ICRA_GAYRIMENKUL[0].ID;

            if (MyIcraFoy.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_ICRA_GEMI_UCAK_ARAC.Count > 0)
                aracId = MyIcraFoy.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_ICRA_GEMI_UCAK_ARAC[0].ID;

            addNewList.ForEach(delegate(AV001_TI_BIL_KIYMET_TAKDIRI k) { 
                k.ICRA_FOY_ID = MyIcraFoy.ID;
                k.GAYRIMENKUL_ID = gayrimenkulId;
                k.GEMI_UCAK_ARAC_ID = aracId; 
            });

            AV001_TI_BIL_HACIZ_CHILD child1 = new AV001_TI_BIL_HACIZ_CHILD();
            foreach (AV001_TI_BIL_HACIZ_MASTER master in MyIcraFoy.AV001_TI_BIL_HACIZ_MASTERCollection)
            {
                foreach (AV001_TI_BIL_HACIZ_CHILD child in master.AV001_TI_BIL_HACIZ_CHILDCollection)
                {
                    child1 = child;
                }
            }
            MyIcraFoy.AV001_TI_BIL_KIYMET_TAKDIRICollection.AddRange(AddNewList);

            foreach (var item in AddNewList)
            {
                if (EkspertizKaydiMi)
                    item.EKSPERTIZ_KAYDI_MI = true;
                else
                    item.EKSPERTIZ_KAYDI_MI = false;
            }

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                tran.BeginTransaction();

                // MyIcraFoy.AV001_TI_BIL_KIYMET_TAKDIRICollection.AddRange(addNewList);
                DataRepository.AV001_TI_BIL_KIYMET_TAKDIRIProvider.DeepSave(tran, addNewList);
                DataRepository.AV001_TI_BIL_KIYMET_TAKDIRIProvider.DeepSave(tran,
                                                                            MyIcraFoy.
                                                                                AV001_TI_BIL_KIYMET_TAKDIRICollection);

                tran.Commit();

                sonuc = true;
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);

                for (int i = 0; i < AddNewList.Count; i++)
                {
                    MyIcraFoy.AV001_TI_BIL_KIYMET_TAKDIRICollection.Remove(AddNewList[i]);
                }
            }
            finally
            {
                tran.Dispose();
            }
            return sonuc;
        }

        private void SecilenleriEkle()
        {
            for (int i = 0; i < frm.Secilenler.Count; i++)
            {
                AV001_TI_BIL_KIYMET_TAKDIRI kt = MyIcraFoy.AV001_TI_BIL_KIYMET_TAKDIRICollection.AddNew();
                if (kt.HACIZ_CHILD_IDSource == null) kt.HACIZ_CHILD_IDSource = new AV001_TI_BIL_HACIZ_CHILD();

                kt.HACIZ_CHILD_IDSource.HACIZLI_MAL_CINS_ID = frm.Secilenler[i].HACIZLI_MAL_CINS_ID;
                kt.HACIZ_CHILD_IDSource.HACIZLI_MAL_TUR_ID = frm.Secilenler[i].HACIZLI_MAL_TUR_ID;
                kt.HACIZ_CHILD_IDSource.HACIZLI_MAL_KATEGORI_ID = frm.Secilenler[i].HACIZLI_MAL_KATEGORI_ID;
                kt.HACIZ_CHILD_IDSource.HACIZLI_MAL_DEGERI_DOVIZ_ID = frm.Secilenler[i].HACIZLI_MAL_DEGERI_DOVIZ_ID;
                kt.HACIZ_CHILD_IDSource.HACIZLI_MAL_DEGERI = frm.Secilenler[i].HACIZLI_MAL_DEGERI.Value;
                kt.HACIZ_CHILD_IDSource.HACIZLI_MAL_ADET_BIRIM_ID = frm.Secilenler[i].HACIZLI_MAL_ADET_BIRIM_ID;
                kt.HACIZ_CHILD_IDSource.HACIZLI_MAL_ADEDI = frm.Secilenler[i].HACIZLI_MAL_ADEDI;
                kt.HACIZLI_MAL_CINS_ID = frm.Secilenler[i].HACIZLI_MAL_CINS_ID;
            }
            ucKiymetTakdiri1.MyDataSource = MyIcraFoy.AV001_TI_BIL_KIYMET_TAKDIRICollection;
        }

        private void Takdir_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_KIYMET_TAKDIRI addNew = e.NewObject as AV001_TI_BIL_KIYMET_TAKDIRI;

            if (addNew == null)
                addNew = new AV001_TI_BIL_KIYMET_TAKDIRI();

            addNew.KAYIT_TARIHI = DateTime.Now;
            addNew.KLASOR_KODU = "GENEL";
            addNew.KONTROL_KIM = "AVUKATPRO";
            addNew.KONTROL_NE_ZAMAN = DateTime.Now;
            addNew.KONTROL_VERSIYON = 1;
            addNew.ADMIN_KAYIT_MI = true;
            addNew.STAMP = 1;
            addNew.SUBE_KODU = 1;
            addNew.HACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID = 1;
            addNew.HACIZLI_MAL_MIKTARI_DOVIZ_ID = 1;
            addNew.HACIZLI_MAL_ADET_BIRIM_ID = 9;
            if (MyHacizChild != null)
                addNew.HACIZ_CHILD_ID = MyHacizChild;
            e.NewObject = addNew;
        }
    }
}