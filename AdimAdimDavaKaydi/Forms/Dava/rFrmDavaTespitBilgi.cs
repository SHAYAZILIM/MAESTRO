using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Dava
{
    public partial class rFrmDavaTespitBilgi : Util.BaseClasses.AvpXtraForm
    {
        public rFrmDavaTespitBilgi()
        {
            InitializeComponent();
            this.Button_Kaydet_Click += btnKaydet_ItemClick;

            this.FormClosing += rFrmDavaTespitOdeme_FormClosing;
        }

        private TList<AV001_TD_BIL_FOY_TESPIT> addNewList;

        private bool kaydedildi;

        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public TList<AV001_TD_BIL_FOY_TESPIT> AddNewList
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
                        AddNewList = new TList<AV001_TD_BIL_FOY_TESPIT>();
                        AddNewList.AddNew();
                    }
                    AddNewList.AddingNew += AddNewList_AddingNew;
                    DataRepository.AV001_TD_BIL_FOY_TESPITProvider.DeepLoad(AddNewList, false,
                                                                            DeepLoadType.IncludeChildren,
                                                                            typeof(TList<AV001_TD_BIL_FOY_TESPIT_DETAY>
                                                                                ));
                    ucDavaTespitBilgi1.MyDataSource = AddNewList;
                }

                //else
                //    DataRepository.AV001_TD_BIL_FOY_TESPITProvider.DeepLoad(AddNewList, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_TESPIT>));
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
            foreach (AV001_TD_BIL_FOY_TESPIT t in AddNewList)
            {
                if (t.IsNew || t.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void rFrmDavaTespitOdeme_FormClosing(object sender, FormClosingEventArgs e)
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
            addNewList.ForEach(delegate(AV001_TD_BIL_FOY_TESPIT t) { t.DAVA_FOY_ID = MyFoy.ID; });

            //MyFoy.AV001_TD_BIL_FOY_TESPITCollection.AddRange(AddNewList);

            foreach (AV001_TD_BIL_FOY_TESPIT cl in AddNewList)
            {
                if (
                    MyFoy.AV001_TD_BIL_FOY_TESPITCollection.Exists(
                        delegate(AV001_TD_BIL_FOY_TESPIT tespit) { return tespit.ID == cl.ID; })) continue;
                MyFoy.AV001_TD_BIL_FOY_TESPITCollection.AddRange(AddNewList);
            }
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TD_BIL_FOY_TESPITProvider.DeepSave(tran, MyFoy.AV001_TD_BIL_FOY_TESPITCollection,
                                                                        DeepSaveType.IncludeChildren,
                                                                        typeof(TList<AV001_TD_BIL_FOY_TESPIT_DETAY>));

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
                    MyFoy.AV001_TD_BIL_FOY_TESPITCollection.Remove(AddNewList[i]);
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