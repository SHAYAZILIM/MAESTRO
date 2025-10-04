using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Icra
{
    public partial class frmGayriMenkulGirisi : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmGayriMenkulGirisi()
        {
            InitializeComponent();
            this.FormClosing += frmGayriMenkulGirisi_FormClosing;
            InitializeEvents();
        }

        private TList<AV001_TI_BIL_GAYRIMENKUL> addNewList;

        private bool kaydedildi;

        private AV001_TI_BIL_FOY myFoy;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_GAYRIMENKUL> AddNewList
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
                myFoy = value;
                if (value != null)
                {
                    MyFoy.AV001_TI_BIL_GAYRIMENKULCollection.Clear();

                    MyFoy.AV001_TI_BIL_GAYRIMENKULCollection.AddingNew +=
                        AV001_TI_BIL_GAYRIMENKULCollection_AddingNew;

                    MyFoy.AV001_TI_BIL_GAYRIMENKULCollection.AddNew();

                    ucGayriMenkul1.MyDataSource = MyFoy.AV001_TI_BIL_GAYRIMENKULCollection;
                }
            }
        }
        
        private void AV001_TI_BIL_GAYRIMENKULCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_GAYRIMENKUL addNew = e.NewObject as AV001_TI_BIL_GAYRIMENKUL;

            if (addNew == null)
                addNew = new AV001_TI_BIL_GAYRIMENKUL();

            e.NewObject = addNew;

            if (AddNewList == null)
                AddNewList = new TList<AV001_TI_BIL_GAYRIMENKUL>();

            AddNewList.Add(addNew);
        }

        private void btnKaydetCik_ItemClick(object sender, EventArgs e)
        {
            if (save())
            {
                kaydedildi = true;
                XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                kaydedildi = false;
                XtraMessageBox.Show("Sistem bir hata ile karþýlaþtý.Lütfen tekrar deneyiniz.", "Kaydet ve Çýk",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CikabilirMi(TList<AV001_TI_BIL_GAYRIMENKUL> list)
        {
            foreach (AV001_TI_BIL_GAYRIMENKUL menkul in list)
            {
                if (menkul.IsNew || menkul.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void frmGayriMenkulGirisi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi(MyFoy.AV001_TI_BIL_GAYRIMENKULCollection))
            {
                DialogResult dr =
                    XtraMessageBox.Show("Yapýlan deðiþiklikler kaydedilmedi.Çýkmak istediðinizden emin misiniz ?",
                                        "Vazgeç", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    GeriAl(addNewList);
                }
                else
                    e.Cancel = true;
            }
        }

        private void GeriAl(TList<AV001_TI_BIL_GAYRIMENKUL> list)
        {
            try
            {
                Temizle(list);
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void InitializeEvents()
        {
            this.Button_Kaydet_Click += btnKaydetCik_ItemClick;
        }

        private bool save()
        {
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                trans.BeginTransaction();

                DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepSave(trans, MyFoy.AV001_TI_BIL_GAYRIMENKULCollection);

                MyFoy.AV001_TI_BIL_GAYRIMENKULCollection.ForEach(delegate(AV001_TI_BIL_GAYRIMENKUL menkul)
                                                                     {
                                                                         NN_ICRA_GAYRIMENKUL nn =
                                                                             DataRepository.NN_ICRA_GAYRIMENKULProvider.
                                                                                 GetByGAYRIMENKUL_IDICRA_FOY_ID(
                                                                                     menkul.ID, MyFoy.ID);

                                                                         if (nn == null)
                                                                         {
                                                                             nn =
                                                                                 MyFoy.NN_ICRA_GAYRIMENKULCollection.
                                                                                     AddNew();
                                                                             nn.GAYRIMENKUL_ID = menkul.ID;
                                                                             nn.ICRA_FOY_ID = MyFoy.ID;
                                                                         }
                                                                     });

                DataRepository.NN_ICRA_GAYRIMENKULProvider.Save(trans, MyFoy.NN_ICRA_GAYRIMENKULCollection);

                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);

                return false;
            }

            return true;
        }

        private void Temizle(TList<AV001_TI_BIL_GAYRIMENKUL> list)
        {
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].IsNew)
                    {
                        MyFoy.AV001_TI_BIL_GAYRIMENKULCollection.RemoveAt(i);
                        list.RemoveAt(i);
                    }
                }

                Temizle(list);
            }
        }
    }
}