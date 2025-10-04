using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Dava
{
    public partial class rfrmDavaGelismeAdim : Util.BaseClasses.AvpXtraForm
    {
        public rfrmDavaGelismeAdim()
        {
            InitializeComponent();
            this.FormClosing += rfrmDavaGelismeAdim_FormClosing;
            InitializeEvents();
        }

        private bool kaydedildi;

        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public TList<AV001_TD_BIL_FOY_GELISME> AddNewList { get; set; }

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
                        AddNewList = new TList<AV001_TD_BIL_FOY_GELISME>();
                        AddNewList.AddNew();
                    }
                    AddNewList.AddingNew += addNewList_AddingNew;
                    ucDavaGelismeAdim1.MyDataSource = AddNewList;
                }
                else
                    DataRepository.AV001_TD_BIL_FOY_GELISMEProvider.DeepLoad(AddNewList, false,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TD_BIL_FOY_GELISME>));
            }
        }

        public void Show(AV001_TD_BIL_FOY foy)
        {
            MyFoy = foy;

            this.Show();
        }
        
        private void addNewList_AddingNew(object sender, AddingNewEventArgs e)
        {
        }

        private void btnKaydet_ItemClick(object sender, EventArgs e)
        {
            bool result = true;

            //foreach (AV001_TD_BIL_FOY_GELISME k in AddNewList)
            //{
            //    string sStr = ""; //ucAraKarar.Validate(k);

            //    if (sStr != string.Empty)
            //    {
            //        XtraMessageBox.Show(sStr, "Uyarý");

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
            foreach (AV001_TD_BIL_FOY_GELISME g in AddNewList)
            {
                if (g.IsNew || g.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnKaydet_ItemClick;
        }

        private void rfrmDavaGelismeAdim_FormClosing(object sender, FormClosingEventArgs e)
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
            AddNewList.ForEach(delegate(AV001_TD_BIL_FOY_GELISME g) { g.DAVA_FOY_ID = MyFoy.ID; });

            //MyFoy.AV001_TD_BIL_FOY_GELISMECollection.AddRange(AddNewList);

            foreach (var item in AddNewList)
            {
                if (
                    MyFoy.AV001_TD_BIL_FOY_GELISMECollection.Exists(
                        delegate(AV001_TD_BIL_FOY_GELISME dg) { return dg.ID == item.ID; })) continue;
                MyFoy.AV001_TD_BIL_FOY_GELISMECollection.Add(item);
            }

            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                trans.BeginTransaction();

                DataRepository.AV001_TD_BIL_FOY_GELISMEProvider.DeepSave(trans, MyFoy.AV001_TD_BIL_FOY_GELISMECollection);

                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);

                for (int i = 0; i < AddNewList.Count; i++)
                {
                    MyFoy.AV001_TD_BIL_FOY_GELISMECollection.RemoveEntity(AddNewList[i]);
                }

                return false;
            }
            finally
            {
                trans.Dispose();
            }

            return true;
        }
    }
}