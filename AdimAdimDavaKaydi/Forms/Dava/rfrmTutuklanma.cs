using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Dava
{
    public partial class rfrmTutuklanma : Util.BaseClasses.AvpXtraForm
    {
        public rfrmTutuklanma()
        {
            InitializeComponent();
            this.FormClosing += rfrmTutuklanma_FormClosing;
            InitailizeEvents();
        }

        private bool kaydedildi;

        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public TList<AV001_TD_BIL_TUTUKLANMA> AddNewList { get; set; }

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                if (DesignMode) return;
                myFoy = value;
                if (value != null)
                {
                    if (AddNewList == null)
                    {
                        AddNewList = new TList<AV001_TD_BIL_TUTUKLANMA>();
                        AddNewList.AddNew();
                    }
                    AddNewList.AddingNew += AddNewList_AddingNew;
                    DataRepository.AV001_TD_BIL_TUTUKLANMAProvider.DeepLoad(AddNewList, false,
                                                                            DeepLoadType.IncludeChildren,
                                                                            typeof(TList<AV001_TD_BIL_TUTUKLANMA>));
                    ucTutuklanmaVeGozAlt1.MyDataSource = AddNewList;

                    //ucTutuklanmaVeGozAlt1.MyFoy = MyFoy;

                    //Inits.DavaEdilenTarafGetir(MyFoy, new RepositoryItemLookUpEdit[] { ucTutuklanmaVeGozAlt1.rlueTutuklananCari });
                }
            }
        }

        public void Show(AV001_TD_BIL_FOY foy)
        {
            MyFoy = foy;

            this.Show();
        }

        private void AddNewList_AddingNew(object sender, AddingNewEventArgs e)
        {
        }

        private void btnKaydet_ItemClick(object sender, EventArgs e)
        {
            bool result = true;

            //foreach (AV001_TD_BIL_TUTUKLANMA n in AddNewList)
            //{
            //    string sStr = ucKanit.Validate(n);

            //    if (sStr != string.Empty)
            //    {
            //        XtraMessageBox.Show("Lütfen kayýtlarý kontrol ediniz." + System.Environment.NewLine
            //            + System.Environment.NewLine + sStr, "Uyarý");

            //        result = false;
            //        break;
            //    }
            //}

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

        private bool CikabilirMi()
        {
            foreach (AV001_TD_BIL_TUTUKLANMA t in AddNewList)
            {
                if (t.IsNew || t.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void InitailizeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnKaydet_ItemClick;
        }

        private void rfrmTutuklanma_FormClosing(object sender, FormClosingEventArgs e)
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
            bool sonuc = false;

            AddNewList.ForEach(delegate(AV001_TD_BIL_TUTUKLANMA k) { k.DAVA_FOY_ID = MyFoy.ID; });

            //MyFoy.AV001_TD_BIL_TUTUKLANMACollection.AddRange(AddNewList);

            foreach (AV001_TD_BIL_TUTUKLANMA t in AddNewList)
            {
                if (
                    MyFoy.AV001_TD_BIL_TUTUKLANMACollection.Exists(
                        delegate(AV001_TD_BIL_TUTUKLANMA tutuklanma) { return tutuklanma.ID == t.ID; })) continue;
                MyFoy.AV001_TD_BIL_TUTUKLANMACollection.Add(t);
            }
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TD_BIL_TUTUKLANMAProvider.DeepSave(tran, MyFoy.AV001_TD_BIL_TUTUKLANMACollection);

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
                    MyFoy.AV001_TD_BIL_TUTUKLANMACollection.Remove(AddNewList[i]);
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