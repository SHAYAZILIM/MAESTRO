using AdimAdimDavaKaydi.UserControls.UcDava;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Dava
{
    public partial class rFrmDavaGenelNotlar : Util.BaseClasses.AvpXtraForm
    {
        public rFrmDavaGenelNotlar()
        {
            InitializeComponent();
            InitializeEvents();
            this.FormClosing += rFrmDavaGenelNotlar_FormClosing;
        }

        private TList<AV001_TD_BIL_FOY_GENEL_NOT> addNewList;

        private TList<AV001_TI_BIL_FOY_GENEL_NOT> addNewListIcra;

        private bool kaydedildi;

        private AV001_TDI_BIL_CARI kullanici;

        private AV001_TD_BIL_FOY myFoy;

        private AV001_TD_BIL_HAZIRLIK myHazirlikFoy;

        private AV001_TI_BIL_FOY myIcraFoy;

        [Browsable(false)]
        public TList<AV001_TD_BIL_FOY_GENEL_NOT> AddNewList
        {
            get { return addNewList; }
            set { addNewList = value; }
        }

        [Browsable(false)]
        public TList<AV001_TI_BIL_FOY_GENEL_NOT> AddNewListIcra
        {
            get { return addNewListIcra; }
            set { addNewListIcra = value; }
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
                            AddNewList = new TList<AV001_TD_BIL_FOY_GENEL_NOT>();
                            AddNewList.AddNew();
                        }
                        kullanici =
                            DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(AvukatProLib.Kimlik.Bilgi.CARI_ID.Value);
                        DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(kullanici, false,
                                                                           DeepLoadType.IncludeChildren,
                                                                           typeof(TList<TDI_BIL_KULLANICI_LISTESI>));
                        foreach (var item in AddNewList)
                        {
                            item.KONTROL_KIM = kullanici.AD;
                            item.KONTROL_KIM_ID = kullanici.TDI_BIL_KULLANICI_LISTESICollection[0].ID;
                        }
                        DataRepository.AV001_TD_BIL_FOY_GENEL_NOTProvider.DeepLoad(AddNewList, false,
                                                                                   DeepLoadType.IncludeChildren,
                                                                                   typeof(
                                                                                       TList<AV001_TD_BIL_FOY_GENEL_NOT>
                                                                                       ));
                        ucDavaGenelNotlar1.MyDataSource = AddNewList;

                        //ucDavaGenelNotlar1.MyDataSource.AddingNew += Notlar_AddingNew;
                        //ucDavaGenelNotlar1.MyDataSource.AddNew();
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_HAZIRLIK MyHazirlikFoy
        {
            get { return myHazirlikFoy; }
            set
            {
                myHazirlikFoy = value;
                if (value != null)
                {
                    try
                    {
                        if (AddNewList == null)
                        {
                            AddNewList = new TList<AV001_TD_BIL_FOY_GENEL_NOT>();
                            AddNewList.AddNew();
                        }
                        DataRepository.AV001_TD_BIL_FOY_GENEL_NOTProvider.DeepLoad(AddNewList, false,
                                                                                   DeepLoadType.IncludeChildren,
                                                                                   typeof(
                                                                                       TList<AV001_TD_BIL_FOY_GENEL_NOT>
                                                                                       ));
                        ucDavaGenelNotlar1.MyDataSource = AddNewList;

                        //ucDavaGenelNotlar1.MyDataSource.AddingNew += Notlar_AddingNew;
                        //ucDavaGenelNotlar1.MyDataSource.AddNew();
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
        }

        [Browsable(false)]
        public AV001_TI_BIL_FOY MyIcraFoy
        {
            get { return myIcraFoy; }
            set
            {
                myIcraFoy = value;
                if (value != null)
                {
                    try
                    {
                        if (AddNewListIcra == null)
                        {
                            AddNewListIcra = new TList<AV001_TI_BIL_FOY_GENEL_NOT>();
                            AddNewListIcra.AddNew();
                        }

                        kullanici =
                            DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(AvukatProLib.Kimlik.Bilgi.CARI_ID.Value);
                        DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(kullanici, false,
                                                                           DeepLoadType.IncludeChildren,
                                                                           typeof(TList<TDI_BIL_KULLANICI_LISTESI>));
                        foreach (var item in AddNewListIcra)
                        {
                            item.KONTROL_KIM = kullanici.AD;
                            item.KONTROL_KIM_ID = kullanici.TDI_BIL_KULLANICI_LISTESICollection[0].ID;
                        }

                        DataRepository.AV001_TI_BIL_FOY_GENEL_NOTProvider.DeepLoad(AddNewListIcra, false,
                                                                                   DeepLoadType.IncludeChildren,
                                                                                   typeof(
                                                                                       TList<AV001_TI_BIL_FOY_GENEL_NOT>
                                                                                       ));
                        ucDavaGenelNotlar1.MyDataSourceIcra = AddNewListIcra;

                        //ucDavaGenelNotlar1.MyDataSource.AddingNew += Notlar_AddingNew;
                        //ucDavaGenelNotlar1.MyDataSource.AddNew();
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
        }

        public void Show(AV001_TD_BIL_FOY foyEntity)
        {
            MyFoy = foyEntity;
            this.Show();
        }

        public void Show(AV001_TI_BIL_FOY foyEntity)
        {
            MyIcraFoy = foyEntity;
            this.Show();
        }

        public void Show(AV001_TD_BIL_HAZIRLIK foyEntity)
        {
            MyHazirlikFoy = foyEntity;
            this.Show();
        }

        private void btnKaydet_ItemClick(object sender, EventArgs e)
        {
            bool result = true;
            if (MyFoy != null || MyHazirlikFoy != null)
            {
                foreach (AV001_TD_BIL_FOY_GENEL_NOT n in AddNewList)
                {
                    string sStr = ucDavaGenelNotlar.Validate(n);
                    if (sStr != string.Empty)
                    {
                        XtraMessageBox.Show("Lütfen kayýtlarý kontrol ediniz." + System.Environment.NewLine
                                            + System.Environment.NewLine + sStr, "Uyarý");

                        result = false;
                        break;
                    }
                }
            }

            if (MyIcraFoy != null)
            {
                foreach (AV001_TI_BIL_FOY_GENEL_NOT n in AddNewListIcra)
                {
                    string sStr = ucDavaGenelNotlar.Validate(n);

                    if (sStr != string.Empty)
                    {
                        XtraMessageBox.Show("Lütfen kayýtlarý kontrol ediniz." + System.Environment.NewLine
                                            + System.Environment.NewLine + sStr, "Uyarý");

                        result = false;
                        break;
                    }
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

        private bool CikabilirMi()
        {
            if (MyFoy != null)
            {
                foreach (AV001_TD_BIL_FOY_GENEL_NOT n in AddNewList)
                {
                    if (n.IsNew || n.HasDataChanged())
                        return false;
                }
            }

            else if (MyIcraFoy != null)
            {
                foreach (AV001_TI_BIL_FOY_GENEL_NOT n in AddNewListIcra)
                {
                    if (n.IsNew || n.HasDataChanged())
                        return false;
                }
            }

            return true;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnKaydet_ItemClick;
        }

        private void rFrmDavaGenelNotlar_FormClosing(object sender, FormClosingEventArgs e)
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

            if (MyFoy != null)
            {
                addNewList.ForEach(delegate(AV001_TD_BIL_FOY_GENEL_NOT k) { k.DAVA_FOY_ID = MyFoy.ID; });

                //MyFoy.AV001_TD_BIL_FOY_GENEL_NOTCollection.AddRange(AddNewList);

                foreach (var item in AddNewList)
                {
                    if (
                        MyFoy.AV001_TD_BIL_FOY_GENEL_NOTCollection.Exists(
                            delegate(AV001_TD_BIL_FOY_GENEL_NOT k) { return k.ID == item.ID; })) continue;
                    MyFoy.AV001_TD_BIL_FOY_GENEL_NOTCollection.Add(item);
                }
            }

            else if (MyIcraFoy != null)
            {
                addNewListIcra.ForEach(delegate(AV001_TI_BIL_FOY_GENEL_NOT k) { k.ICRA_FOY_ID = MyIcraFoy.ID; });

                //MyIcraFoy.AV001_TI_BIL_FOY_GENEL_NOTCollection.AddRange(AddNewListIcra);

                foreach (var item in AddNewListIcra)
                {
                    if (
                        MyIcraFoy.AV001_TI_BIL_FOY_GENEL_NOTCollection.Exists(
                            delegate(AV001_TI_BIL_FOY_GENEL_NOT k) { return k.ID == item.ID; })) continue;
                    MyIcraFoy.AV001_TI_BIL_FOY_GENEL_NOTCollection.Add(item);
                }
            }

            if (MyHazirlikFoy != null)
            {
                addNewList.ForEach(delegate(AV001_TD_BIL_FOY_GENEL_NOT k) { k.HAZIRLIK_FOY_ID = MyHazirlikFoy.ID; });

                //MyHazirlikFoy.AV001_TD_BIL_FOY_GENEL_NOTCollection.AddRange(AddNewList);

                foreach (var item in AddNewList)
                {
                    if (
                        MyHazirlikFoy.AV001_TD_BIL_FOY_GENEL_NOTCollection.Exists(
                            delegate(AV001_TD_BIL_FOY_GENEL_NOT k) { return k.ID == item.ID; })) continue;
                    MyHazirlikFoy.AV001_TD_BIL_FOY_GENEL_NOTCollection.Add(item);
                }
            }

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                if (MyFoy != null)
                    DataRepository.AV001_TD_BIL_FOY_GENEL_NOTProvider.DeepSave(tran,
                                                                               MyFoy.
                                                                                   AV001_TD_BIL_FOY_GENEL_NOTCollection);
                else if (MyIcraFoy != null)
                    DataRepository.AV001_TI_BIL_FOY_GENEL_NOTProvider.DeepSave(tran,
                                                                               MyIcraFoy.
                                                                                   AV001_TI_BIL_FOY_GENEL_NOTCollection);
                else if (MyHazirlikFoy != null)
                    DataRepository.AV001_TD_BIL_FOY_GENEL_NOTProvider.DeepSave(tran,
                                                                               MyHazirlikFoy.
                                                                                   AV001_TD_BIL_FOY_GENEL_NOTCollection);

                tran.Commit();

                sonuc = true;
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);

                if (MyFoy != null)
                {
                    for (int i = 0; i < AddNewList.Count; i++)
                    {
                        MyFoy.AV001_TD_BIL_FOY_GENEL_NOTCollection.Remove(AddNewList[i]);
                    }
                }

                else if (MyIcraFoy != null)
                {
                    for (int i = 0; i < AddNewListIcra.Count; i++)
                    {
                        MyIcraFoy.AV001_TI_BIL_FOY_GENEL_NOTCollection.Remove(AddNewListIcra[i]);
                    }
                }

                if (MyHazirlikFoy != null)
                {
                    for (int i = 0; i < AddNewList.Count; i++)
                    {
                        MyHazirlikFoy.AV001_TD_BIL_FOY_GENEL_NOTCollection.Remove(AddNewList[i]);
                    }
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