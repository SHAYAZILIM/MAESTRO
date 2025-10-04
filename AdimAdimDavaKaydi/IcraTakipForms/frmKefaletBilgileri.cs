using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class frmKefaletBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private TList<AV001_TI_BIL_KEFALET_BILGILERI> addNewList;

        private bool kaydedildi;

        private AV001_TI_BIL_FOY myFoy;

        public frmKefaletBilgileri()
        {
            InitializeComponent();
            InitializeEvents();
            this.FormClosing += frmKefaletBilgileri_FormClosing;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_KEFALET_BILGILERI> AddNewList
        {
            get { return addNewList; }
            set { addNewList = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    myFoy = value;
                    if (AddNewList == null) AddNewList = new TList<AV001_TI_BIL_KEFALET_BILGILERI>();
                    ucKefaletBilgileri1.MyDataSourceYeniKayit = AddNewList;
                    ucKefaletBilgileri1.MyDataSourceYeniKayit.AddingNew += Kefalet_AddingNew;
                    ucKefaletBilgileri1.DatayiDoldur();
                }
            }
        }

        public void Show(AV001_TI_BIL_FOY foyEntity)
        {
            MyFoy = foyEntity;
            this.Show();
        }

        private void btnKaydet_ItemClick(object sender, EventArgs e)
        {
            bool result = true;

            //Validate

            if (result)
            {
                if (Save())
                {
                    kaydedildi = true;
                    XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ucKefaletBilgileri1.DatayiDoldur();
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.", "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool CikabilirMi()
        {
            foreach (AV001_TI_BIL_KEFALET_BILGILERI n in AddNewList)
            {
                if (n.IsNew || n.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void frmKefaletBilgileri_FormClosing(object sender, FormClosingEventArgs e)
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

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnKaydet_ItemClick;
        }

        private void Kefalet_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_KEFALET_BILGILERI addNew = e.NewObject as AV001_TI_BIL_KEFALET_BILGILERI;
            if (addNew == null) addNew = new AV001_TI_BIL_KEFALET_BILGILERI();
            addNew.KAYIT_TARIHI = DateTime.Today;
            addNew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            addNew.KONTROL_KIM = "AVUKATPRO";
            addNew.KONTROL_NE_ZAMAN = DateTime.Today;
            addNew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addNew.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            addNew.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            e.NewObject = addNew;
        }

        private bool Save()
        {
            bool sonuc = false;
            addNewList.ForEach(delegate(AV001_TI_BIL_KEFALET_BILGILERI k) { k.ICRA_FOY_ID = MyFoy.ID; });
            MyFoy.AV001_TI_BIL_KEFALET_BILGILERICollection.AddRange(AddNewList);
            AV001_TI_BIL_FOY_TARAF trf = new AV001_TI_BIL_FOY_TARAF();
            AV001_TI_BIL_ALACAK_NEDEN_TARAF anTrf;
            AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ anTrfFaiz;

            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));

            foreach (AV001_TI_BIL_KEFALET_BILGILERI var in addNewList)
            {
                foreach (var item in MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    anTrf = new AV001_TI_BIL_ALACAK_NEDEN_TARAF();
                    trf.CARI_IDSource = var.KEFIL_OLAN_CARI_IDSource;
                    anTrf.TARAF_CARI_IDSource = var.KEFIL_OLAN_CARI_IDSource;
                    trf.CARI_ID = Convert.ToInt32(var.KEFIL_OLAN_CARI_ID);
                    anTrf.TARAF_CARI_ID = Convert.ToInt32(var.KEFIL_OLAN_CARI_ID);
                    trf.TARAF_KODU = (byte)TarafKodu.KarsiTaraf;//MB
                    anTrf.TARAF_SIFAT_ID = (int)TarafSifat.ÝCRA_KEFÝL;
                    trf.TARAF_SIFAT_ID = (int)TarafSifat.ÝCRA_KEFÝL;
                    trf.TAKIP_EDEN_MI = false;
                    anTrf.KAYIT_TARIHI = DateTime.Now;
                    trf.KAYIT_TARIHI = DateTime.Now;
                    anTrf.KONTROL_NE_ZAMAN = DateTime.Now;
                    trf.KONTROL_NE_ZAMAN = DateTime.Now;
                    anTrf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    trf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    anTrf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    trf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    trf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    anTrf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    trf.SORUMLU_OLUNAN_MIKTAR = var.KEFALET_MIKTARI;
                    anTrf.SORUMLU_OLUNAN_MIKTAR = var.KEFALET_MIKTARI;
                    trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = var.KEFALET_MIKTAR_DOVIZ_ID;
                    anTrf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = var.KEFALET_MIKTAR_DOVIZ_ID;
                    trf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    anTrf.ICRA_FOY_ID = MyFoy.ID;
                    trf.ICRA_FOY_ID = MyFoy.ID;

                    anTrf.ICRA_ALACAK_NEDEN_ID = item.ID;
                    anTrfFaiz = anTrf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.AddNew();
                    anTrfFaiz.ALACAK_NEDEN_TARAF_ID = anTrf.ID;
                    if (item.FAIZ_BASLANGIC_TARIHI.HasValue)//MB
                        anTrfFaiz.FAIZ_BASLANGIC_TARIHI = item.FAIZ_BASLANGIC_TARIHI.Value;
                    anTrfFaiz.FAIZ_BITIS_TARIHI = MyFoy.TAKIP_TARIHI;
                    anTrfFaiz.FAIZ_TIP_ID = item.ALACAK_FAIZ_TIP_ID;
                    anTrfFaiz.FAIZ_ORANI = item.UYGULANACAK_FAIZ_ORANI;
                    anTrfFaiz.SABIT_FAIZ = item.SABIT_FAIZ_UYGULA;
                    anTrfFaiz.KAYIT_TARIHI = DateTime.Now;
                    anTrfFaiz.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    anTrfFaiz.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    anTrfFaiz.KONTROL_NE_ZAMAN = DateTime.Now;
                    anTrfFaiz.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Add(trf);
                    item.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Add(anTrf);
                }
            }

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TI_BIL_KEFALET_BILGILERIProvider.DeepSave(tran, MyFoy.AV001_TI_BIL_KEFALET_BILGILERICollection);

                foreach (var item in MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepSave(tran, item.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>));
                }
                DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepSave(tran, MyFoy.AV001_TI_BIL_FOY_TARAFCollection);

                XtraMessageBox.Show("Kefil olarak atanan cari dosyanýn taraflarýna eklenmiþtir.", "Uyarý", MessageBoxButtons.OK);
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
                    MyFoy.AV001_TI_BIL_KEFALET_BILGILERICollection.Remove(AddNewList[i]);
                }
            }
            finally
            {
                tran.Dispose();
            }
            return sonuc;
        }
    }
}