using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Icra
{
    public partial class frmFeragatBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmFeragatBilgileri()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private TList<AV001_TI_BIL_FERAGAT> addNewList;

        private bool kaydedildi;

        private AV001_TI_BIL_FOY myFoy;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_FERAGAT> AddNewList
        {
            get { return addNewList; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    addNewList = value;
                    if (AddNewList == null) AddNewList = new TList<AV001_TI_BIL_FERAGAT>();
                    dnFeragat.DataSource = value;
                    vgFeragatBilgileri.DataSource = dnFeragat.DataSource;
                    AddNewList.AddingNew += Feragat_AddingNew;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    myFoy = value;
                    if (AddNewList == null) AddNewList = new TList<AV001_TI_BIL_FERAGAT>();
                }
            }
        }

        public void Show(AV001_TI_BIL_FOY foyEntity)
        {
            MyFoy = foyEntity;
            this.Show();
        }

        private bool CikabilirMi()
        {
            foreach (AV001_TI_BIL_FERAGAT n in AddNewList)
            {
                if (n.IsNew || n.HasDataChanged()) return false;
            }
            return true;
        }

        private void Feragat_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_FERAGAT addNew = new AV001_TI_BIL_FERAGAT();
            addNew.ColumnChanged += new AV001_TI_BIL_FERAGATEventHandler(feragat_ColumnChanged);
            addNew.ADMIN_KAYIT_MI = true;
            addNew.KAYIT_TARIHI = DateTime.Now;
            addNew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            addNew.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            addNew.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            addNew.KONTROL_NE_ZAMAN = DateTime.Now;
            addNew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            e.NewObject = addNew;
        }

        private void feragat_ColumnChanged(object sender, AV001_TI_BIL_FERAGATEventArgs e)
        {
            #region Föyün tekrar hesaplanmasýný önlemek için yapýldý. Okan 18.08.2010

            if (myFoy == null || myFoy.EXTRA_LONG1 == 1) return;
            switch (e.Column)
            {
                case AV001_TI_BIL_FERAGATColumn.DAGITILMAMIS_MIKTAR:
                case AV001_TI_BIL_FERAGATColumn.DAGITILMAMIS_MIKTAR_DOVIZ_ID:
                case AV001_TI_BIL_FERAGATColumn.FERAGAT_MIKTAR:
                case AV001_TI_BIL_FERAGATColumn.FERAGAT_MIKTAR_DOVIZ_ID:
                case AV001_TI_BIL_FERAGATColumn.FERAGAT_MIKTAR_KUR:
                    myFoy.EXTRA_LONG1 = 1;
                    break;
            }

            #endregion Föyün tekrar hesaplanmasýný önlemek için yapýldý. Okan 18.08.2010
        }

        private void frmFeragatBilgileri_Button_Kaydet_Click(object sender, EventArgs e)
        {
            bool result = true;

            //Validate
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

        private void frmFeragatBilgileri_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;
            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yaptýðýnýz Deðiþiklikleri kaydetmediniz. Þimdi Kaydedilsin mi?",
                                                      "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    frmFeragatBilgileri_Button_Kaydet_Click(null, null);
                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void frmFeragatBilgileri_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            LookUpDoldur();
            if (AddNewList == null)
                AddNewList = new TList<AV001_TI_BIL_FERAGAT>();
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmFeragatBilgileri_Button_Kaydet_Click;
        }

        private void LookUpDoldur()
        {
            BelgeUtil.Inits.FeragatKapsamiGetir(rLueFeragatKapsami);
            BelgeUtil.Inits.FeragatTipiGetir(rLueFeragatTipi);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizID);
            BelgeUtil.Inits.ParaBicimiAyarla(rSpinMiktar);
            BelgeUtil.Inits.MahsupAltKategoriGetir(rLueMahsupAltKategori);
        }

        private bool Save()
        {
            bool sonuc = false;
            addNewList.ForEach(delegate(AV001_TI_BIL_FERAGAT f) { f.ICRA_FOY_ID = MyFoy.ID; });

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                tran.BeginTransaction();
                DataRepository.AV001_TI_BIL_FOYProvider.Save(tran, MyFoy); // Okan 18.08.2010
                DataRepository.AV001_TI_BIL_FERAGATProvider.DeepSave(tran, addNewList);
                tran.Commit();
                sonuc = true;

                foreach (var mahsup in addNewList)
                {
                    if (
                        MyFoy.AV001_TI_BIL_FERAGATCollection.Exists(
                            delegate(AV001_TI_BIL_FERAGAT pol) { return pol.ID == mahsup.ID; })) continue;
                    MyFoy.AV001_TI_BIL_FERAGATCollection.AddRange(AddNewList);
                }
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);

                for (int i = 0; i < AddNewList.Count; i++)
                {
                    MyFoy.AV001_TI_BIL_FERAGATCollection.Remove(AddNewList[i]);
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