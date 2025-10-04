using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Dava
{
    public partial class frmTemyizEkle : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmTemyizEkle()
        {
            InitializeComponent();
            InitializeEvents();
            this.FormClosing += frmTemyizEkle_FormClosing;
            this.lookUpEdit1.EditValueChanged += new EventHandler(lookUpEdit1_EditValueChanged);
        }

        private TList<AV001_TD_BIL_TEMYIZ> addNewList;

        private bool kaydedildi;

        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public TList<AV001_TD_BIL_TEMYIZ> AddNewList
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
                            AddNewList = new TList<AV001_TD_BIL_TEMYIZ>();
                            AddNewList.AddNew();
                        }
                        else if (AddNewList.Count > 0)
                            lookUpEdit1.EditValue = AddNewList[0].TEMYIZ_TIP_ID;

                        AddNewList.AddingNew += AddNewList_AddingNew;
                        DataRepository.AV001_TD_BIL_TEMYIZProvider.DeepLoad(AddNewList, false,
                                                                            DeepLoadType.IncludeChildren,
                                                                            typeof(TList<AV001_TD_BIL_TEMYIZ_TARAF>));
                        ucTemyizBilgileri1.MyDataSource = AddNewList;
                        dataNavigatorExtended1.DataSource =
                            AddNewList[0].AV001_TD_BIL_TEMYIZ_TARAFCollection;

                        vGridControl2.DataSource = dataNavigatorExtended1.DataSource;

                        foreach (var item in AddNewList)
                        {
                            item.ColumnChanged += item_ColumnChanged;
                        }
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }

                else
                    DataRepository.AV001_TD_BIL_TEMYIZProvider.DeepLoad(AddNewList, false, DeepLoadType.IncludeChildren,
                                                                        typeof(TList<AV001_TD_BIL_TEMYIZ>));
            }
        }

        public void Show(AV001_TD_BIL_FOY foy)
        {
            MyFoy = foy;
            if (MyFoy != null)
                ucTemyizBilgileri1.DavaFoyID = MyFoy.ID;
            this.Show();
        }

        private void AddNewList_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_TEMYIZ addNew = e.NewObject as AV001_TD_BIL_TEMYIZ;

            if (addNew == null)
                addNew = new AV001_TD_BIL_TEMYIZ();

            addNew.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
            addNew.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
            addNew.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
            addNew.BIRIM_NO = MyFoy.BIRIM_NO;
            addNew.ESAS_NO = MyFoy.ESAS_NO;
            addNew.KARAR_TARIHI = DateTime.Today;

            AV001_TD_BIL_TEMYIZ_TARAF taraf = addNew.AV001_TD_BIL_TEMYIZ_TARAFCollection.AddNew();

            taraf.KAYIT_TARIHI = DateTime.Today;
            taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            taraf.KONTROL_KIM = "AVUKATPRO";
            taraf.KONTROL_NE_ZAMAN = DateTime.Today;
            taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

            e.NewObject = addNew;
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
            foreach (AV001_TD_BIL_TEMYIZ t in AddNewList)
            {
                if (t.IsNew || t.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void frmTemyizEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            DosyadanVazgecildi(e);
        }

        private void frmTemyizEkle_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Taraf bilgisi girmediðiniz temyiz kayýtlarý raporda görünmeyebilir.\nLütfen bu kayýtlar için temyiz taraf bilgilerini ekleyiniz.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            initData();
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnKaydet_ItemClick;
        }

        private void initData()
        {
            if (MyFoy != null)
                BelgeUtil.Inits.DavaTumTaraflar(MyFoy, new[] { rlueCari });
            BelgeUtil.Inits.TemyizTipGetir(lookUpEdit1);
        }

        private void item_ColumnChanged(object sender, AV001_TD_BIL_TEMYIZEventArgs e)
        {
            AV001_TD_BIL_TEMYIZ temyiz = sender as AV001_TD_BIL_TEMYIZ;

            if (e.Column == AV001_TD_BIL_TEMYIZColumn.TEMYIZ_TIP_ID)
            {
                if ((int)e.Value == 3) //Karar Düzeltme
                {
                    if (MyFoy == null) return;

                    AV001_TD_BIL_TEMYIZ sonTemyiz =
                        DataRepository.AV001_TD_BIL_TEMYIZProvider.GetByDAVA_FOY_ID(MyFoy.ID).Max();

                    if (sonTemyiz != null)
                    {
                        temyiz.ADLI_BIRIM_ADLIYE_ID = sonTemyiz.ADLI_BIRIM_ADLIYE_ID;
                        temyiz.ADLI_BIRIM_GOREV_ID = sonTemyiz.ADLI_BIRIM_GOREV_ID;
                        temyiz.ADLI_BIRIM_NO_ID = sonTemyiz.ADLI_BIRIM_NO_ID;
                        temyiz.BIRIM_NO = sonTemyiz.BIRIM_NO;
                        temyiz.ESAS_NO = sonTemyiz.ESAS_NO;
                    }
                    else
                    {
                        XtraMessageBox.Show("Önce Temyiz Kaydý Yapýnýz.", "UYARI", MessageBoxButtons.OK,
                                            MessageBoxIcon.Stop);
                        temyiz.TEMYIZ_TIP_ID = 1; //Temyiz
                    }
                }
            }
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit1.EditValue != null)
                ucTemyizBilgileri1.MyKanunYolu = (int?)lookUpEdit1.EditValue;
        }

        private bool Save()
        {
            bool sonuc = false;

            addNewList.ForEach(delegate(AV001_TD_BIL_TEMYIZ t) { t.DAVA_FOY_ID = MyFoy.ID; });

            //MyFoy.AV001_TD_BIL_TEMYIZCollection.AddRange(AddNewList);

            foreach (AV001_TD_BIL_TEMYIZ t in AddNewList)
            {
                if (
                    MyFoy.AV001_TD_BIL_TEMYIZCollection.Exists(
                        delegate(AV001_TD_BIL_TEMYIZ temyiz) { return temyiz.ID == t.ID; })) continue;
                MyFoy.AV001_TD_BIL_TEMYIZCollection.AddRange(AddNewList);
            }

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TD_BIL_TEMYIZProvider.DeepSave(tran, MyFoy.AV001_TD_BIL_TEMYIZCollection,
                                                                    DeepSaveType.IncludeChildren,
                                                                    typeof(TList<AV001_TD_BIL_TEMYIZ_TARAF>));

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
                    MyFoy.AV001_TD_BIL_TEMYIZCollection.Remove(AddNewList[i]);
                }
            }
            finally
            {
                tran.Dispose();
            }
            return sonuc;
        }

        #region IslemMethods

        private void DosyadanVazgecildi(FormClosingEventArgs e)
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

        #endregion IslemMethods
    }
}