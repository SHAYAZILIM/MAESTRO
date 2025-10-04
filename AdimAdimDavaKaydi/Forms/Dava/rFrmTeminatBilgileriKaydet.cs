using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Dava
{
    public partial class rFrmTeminatBilgileriKaydet : Util.BaseClasses.AvpXtraForm
    {
        public rFrmTeminatBilgileriKaydet()
        {
            InitializeComponent();
            InitializeEvents();
            this.FormClosing += rFrmTeminatBilgileriKaydet_FormClosing;
        }

        private TList<AV001_TDI_BIL_TEMINAT_MEKTUP> addNewList;

        private bool kaydedildi;

        [Browsable(false)]
        public TList<AV001_TDI_BIL_TEMINAT_MEKTUP> AddNewList
        {
            get { return addNewList; }
            set { addNewList = value; }
        }

        public AV001_TD_BIL_FOY MyFoy { get; set; }

        public AV001_TI_BIL_FOY MyIcraFoy { get; set; }

        public void Show(AV001_TI_BIL_FOY foy)
        {
            this.MyIcraFoy = foy;
            this.Show();
        }

        public void Show(AV001_TD_BIL_FOY foyEnt)
        {
            MyFoy = foyEnt;

            this.Show();
        }

        private void bBtnKaydet_ItemClick(object sender, EventArgs e)
        {
            //KAYDET
            if (Kaydet())
            {
                kaydedildi = true;

                XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.", "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CikabilirMi()
        {
            foreach (AV001_TDI_BIL_TEMINAT_MEKTUP t in AddNewList)
            {
                if (t.IsNew || t.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += bBtnKaydet_ItemClick;
        }

        private bool Kaydet()
        {
            bool sonuc = false;

            if (MyFoy != null)
                addNewList.ForEach(delegate(AV001_TDI_BIL_TEMINAT_MEKTUP k) { k.DAVA_FOY_ID = MyFoy.ID; });
            else if (MyIcraFoy != null)
                addNewList.ForEach(delegate(AV001_TDI_BIL_TEMINAT_MEKTUP k) { k.ICRA_FOY_ID = MyIcraFoy.ID; });

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.DeepSave(tran, AddNewList);

                tran.Commit();

                sonuc = true;
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
            finally
            {
                tran.Dispose();
            }
            return sonuc;
        }

        private void rFrmTeminatBilgileriKaydet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapýlan deðiþiklikleri kaydetmediniz.Þimdi kaydedilsin mi?",
                                                      "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    bBtnKaydet_ItemClick(null, null);

                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void rFrmTeminatBilgileriKaydet_Load(object sender, EventArgs e)
        {
            if (AddNewList == null)
            {
                AddNewList = new TList<AV001_TDI_BIL_TEMINAT_MEKTUP>();
                AddNewList.AddNew();
            }
            ucTeminatKefaletKayitForDava1.MyDataSource = AddNewList;
        }
    }
}