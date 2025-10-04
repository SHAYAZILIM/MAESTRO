using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmGemiUcakAracKayit : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmGemiUcakAracKayit()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> ugaList = new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>();
        private TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> myDataSource;
        private int recordIndex = -1;

        [Browsable(false)]
        public TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> MyDataSource
        {
            get { return myDataSource; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    myDataSource = value;
                    ugaList.AddingNew += value_AddingNew;

                    //ugaList.AddNew();
                    //ucUcakGemiArac1.MyDataSource = ugaList;
                    ucUcakGemiArac1.FocusedUcakGemiAracChanged += new DevExpress.XtraVerticalGrid.Events.IndexChangedEventHandler(ucUcakGemiArac1_FocusedUcakGemiAracChanged);
                    ucUcakGemiArac1.MyDataSource = value;
                }
            }
        }

        private void frmGemiUcakAracKayit_Button_Kaydet_Click(object sender, EventArgs e)
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

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmGemiUcakAracKayit_Button_Kaydet_Click;
        }

        private bool Save()
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            bool sonuc = false;
            try
            {
                tran.BeginTransaction();
                MyDataSource.AddRange(ugaList);
                DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.DeepSave(tran, MyDataSource);

                tran.Commit();

                sonuc = true;
            }
            catch 
            {
                //BelgeUtil.ErrorHandler.Catch(this, ex);

                sonuc = false;
            }
            finally
            {
                tran.Dispose();
            }
            return sonuc;
        }

        private void ucUcakGemiArac1_FocusedUcakGemiAracChanged(object sender, DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            recordIndex = e.NewIndex;
        }

        private void value_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_GEMI_UCAK_ARAC addNew = new AV001_TDI_BIL_GEMI_UCAK_ARAC();
            addNew.KAYIT_TARIHI = DateTime.Now;
            addNew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            addNew.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            addNew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addNew.KONTROL_NE_ZAMAN = DateTime.Now;
            e.NewObject = addNew;
        }
    }
}