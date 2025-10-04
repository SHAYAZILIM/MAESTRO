using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Dava
{
    public partial class rFrmDavaIzah : Util.BaseClasses.AvpXtraForm
    {
        public rFrmDavaIzah()
        {
            InitializeComponent();
            InitializEvents();
            this.FormClosing += rFrmDavaIzah_FormClosing;
        }

        private TList<AV001_TD_BIL_FOY_HIKAYE> addNewList;

        private bool kaydedildi;

        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public TList<AV001_TD_BIL_FOY_HIKAYE> AddNewList
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
                    try
                    {
                        if (AddNewList == null)
                        {
                            AddNewList = new TList<AV001_TD_BIL_FOY_HIKAYE>();

                            //AddNewList.AddNew();//Kayýt formlarý default 0 kayýtla getirilecek.
                        }
                        AddNewList.AddingNew += AddNewList_AddingNew;
                        ucDavaHikayesi1.MyDataSource = AddNewList;
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }

                else
                    DataRepository.AV001_TD_BIL_FOY_HIKAYEProvider.DeepLoad(AddNewList, false,
                                                                            DeepLoadType.IncludeChildren,
                                                                            typeof(TList<AV001_TD_BIL_FOY_HIKAYE>));
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

            //foreach (AV001_TD_BIL_FOY_HIKAYE h in AddNewList)
            //{
            //    string sStr = ucDavaHikayesi1.Validate(

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
            foreach (AV001_TD_BIL_FOY_HIKAYE h in AddNewList)
            {
                if (h.IsNew || h.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void InitializEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnKaydet_ItemClick;
        }

        private void rFrmDavaIzah_FormClosing(object sender, FormClosingEventArgs e)
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

            addNewList.ForEach(delegate(AV001_TD_BIL_FOY_HIKAYE h) { h.DAVA_FOY_ID = MyFoy.ID; });

            //MyFoy.AV001_TD_BIL_FOY_HIKAYECollection.AddRange(AddNewList);

            foreach (AV001_TD_BIL_FOY_HIKAYE h in AddNewList)
            {
                if (
                    MyFoy.AV001_TD_BIL_FOY_HIKAYECollection.Exists(
                        delegate(AV001_TD_BIL_FOY_HIKAYE hikaye) { return hikaye.ID == h.ID; })) continue;
                MyFoy.AV001_TD_BIL_FOY_HIKAYECollection.AddRange(AddNewList);
            }
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TD_BIL_FOY_HIKAYEProvider.DeepSave(tran, MyFoy.AV001_TD_BIL_FOY_HIKAYECollection);

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
                    MyFoy.AV001_TD_BIL_FOY_HIKAYECollection.Remove(AddNewList[i]);
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