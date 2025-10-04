using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class frmDusmeYenileme : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private TList<AV001_TI_BIL_DUSME_YENILEME> addNewList;

        private bool kaydedildi;

        private AV001_TI_BIL_FOY myFoy;

        public frmDusmeYenileme()
        {
            InitializeComponent();
            InitializeEvents();
            this.FormClosing += frmDusmeYenileme_FormClosing;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_DUSME_YENILEME> AddNewList
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
                    if (AddNewList == null) AddNewList = new TList<AV001_TI_BIL_DUSME_YENILEME>();

                    AddNewList.AddingNew += DusmeYenileme_AddingNew;
                    ucDusmeYenileme1.Kayitmi = true;
                    ucDusmeYenileme1.MyFoy = MyFoy;
                    AddNewList.AddNew();
                    ucDusmeYenileme1.MyDataSource = AddNewList;
                }
            }
        }

        public void Show(AV001_TI_BIL_FOY foyEntity)
        {
            MyFoy = foyEntity;
            this.Show();
        }

        private bool CikabilirMi()
        {
            foreach (AV001_TI_BIL_DUSME_YENILEME n in AddNewList)
            {
                if (n.IsNew || n.HasDataChanged())
                    return false;
            }
            return true;
        }

        private void DusmeYenileme_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_DUSME_YENILEME addNew = e.NewObject as AV001_TI_BIL_DUSME_YENILEME;
            if (addNew == null)
                addNew = new AV001_TI_BIL_DUSME_YENILEME();
            addNew.KAYIT_TARIHI = DateTime.Today;
            addNew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            addNew.KONTROL_KIM = "AVUKATPRO";
            addNew.KONTROL_NE_ZAMAN = DateTime.Today;
            addNew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addNew.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            addNew.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            e.NewObject = addNew;
        }

        private void frmDusmeYenileme_Button_Kaydet_Click(object sender, EventArgs e)
        {
            bool result = true;

            //Validate

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

        private void frmDusmeYenileme_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapýlan deðiþiklikleri kaydetmediniz.Þimdi kaydedilsin mi?",
                                                      "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    frmDusmeYenileme_Button_Kaydet_Click(null, null);

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
            this.Button_Kaydet_Click += frmDusmeYenileme_Button_Kaydet_Click;
        }

        private bool Save()
        {
            bool sonuc = false;

            addNewList.ForEach(delegate(AV001_TI_BIL_DUSME_YENILEME k) { k.ICRA_FOY_ID = MyFoy.ID; });
            MyFoy.AV001_TI_BIL_DUSME_YENILEMECollection.AddRange(AddNewList);

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TI_BIL_DUSME_YENILEMEProvider.DeepSave(tran,
                                                                            MyFoy.AV001_TI_BIL_DUSME_YENILEMECollection);

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
                    MyFoy.AV001_TI_BIL_DUSME_YENILEMECollection.Remove(AddNewList[i]);
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