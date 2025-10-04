using AdimAdimDavaKaydi.DavaTakip;
using AdimAdimDavaKaydi.UserControls.UcDava;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Dava
{
    public partial class frmKanitGirisi : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmKanitGirisi()
        {
            InitializeComponent();
            this.FormClosing += frmKanitGirisi_FormClosing;
            InitializeEvents();
        }

        private TList<AV001_TD_BIL_KANIT> addNewList;

        private bool kaydedildi;

        private bool listeNoDegisti;

        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public TList<AV001_TD_BIL_KANIT> AddNewList
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
                if (value != null && !DesignMode)
                {
                    try
                    {
                        if (AddNewList == null) AddNewList = new TList<AV001_TD_BIL_KANIT>();

                        ucKanit1.MyDataSource = AddNewList;
                        ucKanit1.FormDanmi = true;
                        ucKanit1.MyFoy = myFoy;
                        ucKanit1.MyDataSource.AddingNew += Kanit_AddingNew;
                        if (AddNewList.Count == 0)
                            ucKanit1.MyDataSource.AddNew();

                        AddNewList.ForEach(
                            delegate(AV001_TD_BIL_KANIT k) { k.PropertyChanged += kanit_PropertyChanged; });
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

        private void btnKaydet_ItemClick(object sender, EventArgs e)
        {
            bool result = true;
            foreach (AV001_TD_BIL_KANIT n in AddNewList)
            {
                string sStr = ucKanit.Validate(n);

                if (sStr != string.Empty)
                {
                    XtraMessageBox.Show("Lütfen kayýtlarý kontrol ediniz." + System.Environment.NewLine
                                        + System.Environment.NewLine + sStr, "Uyarý");

                    result = false;
                    break;
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
            foreach (AV001_TD_BIL_KANIT n in AddNewList)
            {
                if (n.IsNew || n.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void frmKanitGirisi_FormClosing(object sender, FormClosingEventArgs e)
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

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnKaydet_ItemClick;
        }

        private void Kanit_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_KANIT addNew = e.NewObject as AV001_TD_BIL_KANIT;

            if (addNew == null)
                addNew = new AV001_TD_BIL_KANIT();

            addNew.KANIT_NO = ucKanit.KanitNo(AddNewList, MyFoy);

            if (listeNoDegisti)
                addNew.LISTE_NO = ucKanit.ListeNo(AddNewList, MyFoy, true);

            addNew.LISTE_NO = ucKanit.ListeNo(AddNewList, MyFoy, false);
            addNew.KANIT_REFERANS_NO = ucKanit.ReferansNo();
            addNew.LISTE_TARIHI = DateTime.Today;
            addNew.TARAF_CARI_ID = ucDavaTarafBilgileri.CurrTarafId;

            e.NewObject = addNew;

            addNew.PropertyChanged += kanit_PropertyChanged;

            AddNewList.Sort("KANIT_NO ASC");
        }

        private void kanit_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "LISTE_NO")
            {
                listeNoDegisti = true;
            }
        }

        private bool Save()
        {
            bool sonuc = false;

            addNewList.ForEach(delegate(AV001_TD_BIL_KANIT k) { k.DAVA_FOY_ID = MyFoy.ID; });

            // MyFoy.AV001_TD_BIL_KANITCollection.AddRange(AddNewList);

            foreach (var item in AddNewList)
            {
                if (MyFoy.AV001_TD_BIL_KANITCollection.Exists(delegate(AV001_TD_BIL_KANIT k) { return k.ID == item.ID; }))
                    continue;
                MyFoy.AV001_TD_BIL_KANITCollection.Add(item);
            }

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TD_BIL_KANITProvider.DeepSave(tran, MyFoy.AV001_TD_BIL_KANITCollection);

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
                    MyFoy.AV001_TD_BIL_KANITCollection.Remove(AddNewList[i]);
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