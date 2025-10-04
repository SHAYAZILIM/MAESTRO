using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Dava
{
    public partial class rfrmDusmeYenilemeKayit : Util.BaseClasses.AvpXtraForm
    {
        public rfrmDusmeYenilemeKayit()
        {
            InitializeComponent();
            InitializeEvents();
            this.FormClosing += rfrmDusmeYenilemeKayit_FormClosing;
        }

        private TList<AV001_TD_BIL_DUSME_YENILEME> addNewList;

        private bool kaydedildi;

        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public TList<AV001_TD_BIL_DUSME_YENILEME> AddNewList
        {
            get { return addNewList; }
            set { addNewList = value; }
        }

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    if (AddNewList == null)
                    {
                        AddNewList = new TList<AV001_TD_BIL_DUSME_YENILEME>();
                        AddNewList.AddNew();
                    }
                    addNewList.AddingNew += DusmeYenileme_AddingNew;
                    ucDavaDusmeYenileme1.MyDataSource = AddNewList;
                }

                else
                {
                    DataRepository.AV001_TD_BIL_DUSME_YENILEMEProvider.DeepLoad(AddNewList, false,
                                                                                DeepLoadType.IncludeChildren,
                                                                                typeof(
                                                                                    TList<AV001_TD_BIL_DUSME_YENILEME>));
                }
            }
        }

        public void Show(AV001_TD_BIL_FOY foy)
        {
            MyFoy = foy;

            this.Show();
        }

        private void btnKaydet_ItemClick(object sender, EventArgs e)
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

        private bool CikabilirMi()
        {
            foreach (AV001_TD_BIL_DUSME_YENILEME d in AddNewList)
            {
                if (d.IsNew || d.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void DusmeYenileme_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_DUSME_YENILEME addNew = e.NewObject as AV001_TD_BIL_DUSME_YENILEME;
            if (addNew == null)
                addNew = new AV001_TD_BIL_DUSME_YENILEME();
            addNew.DUSME_TARIHI = DateTime.Today;
            addNew.YENILEME_TARIHI = DateTime.Today;
            addNew.KAYIT_TARIHI = DateTime.Today;
            addNew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            addNew.KONTROL_KIM = "AVUKATPRO";
            addNew.KONTROL_NE_ZAMAN = DateTime.Today;
            addNew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addNew.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            addNew.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

            e.NewObject = addNew;
        }

        private void InitializeEvents()
        {
            EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnKaydet_ItemClick;
        }

        private void rfrmDusmeYenilemeKayit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapýlan deðiþiklikleri kaydetmediniz.Þimdi kaydedilsin mi?",
                                                      "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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

        private bool Save()
        {
            AddNewList.ForEach(delegate(AV001_TD_BIL_DUSME_YENILEME d) { d.DAVA_FOY_ID = MyFoy.ID; });

            foreach (var item in AddNewList)
            {
                if (
                    MyFoy.AV001_TD_BIL_DUSME_YENILEMECollection.Exists(
                        delegate(AV001_TD_BIL_DUSME_YENILEME dy) { return dy.ID == item.ID; })) continue;
                MyFoy.AV001_TD_BIL_DUSME_YENILEMECollection.Add(item);
            }

            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                trans.BeginTransaction();

                DataRepository.AV001_TD_BIL_DUSME_YENILEMEProvider.DeepSave(trans,
                                                                            MyFoy.AV001_TD_BIL_DUSME_YENILEMECollection);

                trans.Commit();

                kaydedildi = true;
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);
                for (int i = 0; i < AddNewList.Count; i++)
                {
                    MyFoy.AV001_TD_BIL_DUSME_YENILEMECollection.RemoveEntity(AddNewList[i]);
                }

                return false;
            }
            finally
            {
                trans.Dispose();
            }

            return true;
        }

        //#region IslemMethods

        //void IslemTamamlandi()
        //{
        //    if (Save())
        //    {
        //        kaydedildi = true;

        //        //XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk",
        //        //    MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        this.Close();
        //    }
        //    else
        //    {
        //        kaydedildi = false;
        //        return;
        //      //  XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.",
        //      //"Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //void DosyadanCikis()
        //{
        //    this.Close();
        //}

        //#endregion
        //#region OverrideMethods
        //public override void Kaydet()
        //{
        //    base.Kaydet();
        //    IslemTamamlandi();
        //}
        //public override void Cikis()
        //{
        //    base.Cikis();
        //    DosyadanCikis();
        //}
        //#endregion
    }
}