using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AvukatPro.WinUI
{
    public partial class frmIcraHacizIstihkak : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmIcraHacizIstihkak()
        {
            InitializeComponent();

            InitializeEvents();
            this.FormClosing += frmIcraHacizIstihkak_FormClosing;
        }

        private TList<AV001_TI_BIL_ISTIHKAK> addNewList;

        private bool kaydedildi;

        //TList<AV001_TI_BIL_ISTIHKAK> MyDataSource;
        private AV001_TI_BIL_FOY myFoy;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_ISTIHKAK> AddNewList
        {
            get { return addNewList; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    addNewList = value;
                    gridIcraHacizIstihkak.DataSource = value;
                    dnHacizIstihkak.DataSource = value;
                    vGridControl1.DataSource = dnHacizIstihkak.DataSource;
                }
            }
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
                    if (AddNewList == null) AddNewList = new TList<AV001_TI_BIL_ISTIHKAK>();
                    AddNewList.AddingNew += new AddingNewEventHandler(AddNewList_AddingNew);
                }
            }
        }

        public int MyHacizChild { get; set; }

        public void Show(AV001_TI_BIL_FOY foyEntity)
        {
            MyFoy = foyEntity;
            InitData();
            this.Show();
        }

        private void AddNewList_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_ISTIHKAK addNew = e.NewObject as AV001_TI_BIL_ISTIHKAK;

            if (addNew == null)
                addNew = new AV001_TI_BIL_ISTIHKAK();

            addNew.KAYIT_TARIHI = DateTime.Now;
            addNew.KLASOR_KODU = "GENEL";
            addNew.KONTROL_KIM = "AVUKATPRO";
            addNew.KONTROL_NE_ZAMAN = DateTime.Now;
            addNew.KONTROL_VERSIYON = 1;
            addNew.ADMIN_KAYIT_MI = true;
            addNew.STAMP = 1;
            addNew.SUBE_KODU = 1;
            if (MyHacizChild != null)
                addNew.HACIZ_CHILD_ID = MyHacizChild;
            e.NewObject = addNew;
        }

        private bool CikabilirMi()
        {
            foreach (AV001_TI_BIL_ISTIHKAK n in AddNewList)
            {
                if (n.IsNew || n.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void frmIcraHacizIstihkak_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapılan değişiklikleri kaydetmediniz.Şimdi kaydedilsin mi?",
                                                      "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    frmIcraHacizIstikak_Button_Kaydet_Click(null, null);

                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void frmIcraHacizIstikak_Button_Kaydet_Click(object sender, EventArgs e)
        {
            bool result = true;

            // Validate

            if (result)
            {
                if (Save())
                {
                    kaydedildi = true;

                    XtraMessageBox.Show("Değişiklikler kaydedildi.", "Kaydet ve Çık",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Kaydetme işlemi yapılamıyor.",
                                        "Kaydet ve Çık", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InitData()
        {
            BelgeUtil.Inits.perCariGetir(rlueCari);
            BelgeUtil.Inits.DovizTipGetir(rluDoviz);
            BelgeUtil.Inits.BirimKodGetir(rlueAdetBirim);
            if (MyFoy != null)
            {
                BelgeUtil.Inits.HacizChildGetir(MyFoy, rLueHacizMaster);
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmIcraHacizIstikak_Button_Kaydet_Click;
        }

        private void rLueHacizMaster_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (lue.EditValue != null && gwHacizIstihkak.FocusedRowHandle >= 0)
            {
                int ID = Convert.ToInt32(lue.EditValue);
                AV001_TI_BIL_HACIZ_CHILD child = DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.GetByID(ID);
                addNewList[gwHacizIstihkak.FocusedRowHandle].HACIZLI_MAL_CINS_ID = child.HACIZLI_MAL_CINS_ID;
                addNewList[gwHacizIstihkak.FocusedRowHandle].HACIZLI_MAL_KATEGORI_ID = child.HACIZLI_MAL_KATEGORI_ID;
                addNewList[gwHacizIstihkak.FocusedRowHandle].HACIZLI_MAL_TUR_ID = child.HACIZLI_MAL_TUR_ID;
            }
        }

        private bool Save()
        {
            bool sonuc = false;

            //addNewList.ForEach(delegate(AV001_TI_BIL_ISTIHKAK h)
            //{
            //    h.ICRA_FOY_ID = MyFoy.ID;
            //});

            MyFoy.AV001_TI_BIL_ISTIHKAKCollection.AddRange(AddNewList);
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TI_BIL_ISTIHKAKProvider.DeepSave(tran, MyFoy.AV001_TI_BIL_ISTIHKAKCollection);

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
                    MyFoy.AV001_TI_BIL_ISTIHKAKCollection.Remove(AddNewList[i]);
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