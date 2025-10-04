using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmKimNeredeEkleme : Util.BaseClasses.AvpXtraForm
    {
        public frmKimNeredeEkleme()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private TList<AV001_TDIE_BIL_KIM_NEREDE> addNewList;

        private bool kaydedildi;

        public event EventHandler<PersonelNeredeKaydedildiEventArgs> Yenile;

        [Browsable(false)]
        public TList<AV001_TDIE_BIL_KIM_NEREDE> AddNewList
        {
            get { return addNewList; }
            set
            {
                addNewList = value;
                if (addNewList == null)
                {
                    addNewList = new TList<AV001_TDIE_BIL_KIM_NEREDE>();
                }
                AddNewList.AddingNew += AddNewList_AddingNew;
                vgKimNerede.DataSource = addNewList;
            }
        }

        public bool Save()
        {
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                trans.BeginTransaction();

                DataRepository.AV001_TDIE_BIL_KIM_NEREDEProvider.DeepSave(trans, AddNewList);

                if (Yenile != null)
                    Yenile(this, new PersonelNeredeKaydedildiEventArgs(AddNewList));

                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);

                return false;
            }
            finally
            {
                trans.Dispose();
            }
            return true;
        }

        private void AddNewList_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDIE_BIL_KIM_NEREDE addNew = new AV001_TDIE_BIL_KIM_NEREDE();
            addNew.KAYIT_TARIHI = DateTime.Now;
            addNew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            addNew.KONTROL_NE_ZAMAN = DateTime.Now;
            addNew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addNew.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            addNew.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            addNew.SUBE_KOD_ID = AvukatProLib.Kimlik.SubeKodu;
            addNew.ISIN_YERI = "MERKEZ";
            addNew.PERSONEL_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
            addNew.BULUNMA_BASLANGIC_TARIHI_SAATI = DateTime.Now;
            e.NewObject = addNew;
        }

        private bool CikabilirMi()
        {
            if (addNewList == null)
                return true;

            return true;
        }

        private void frmKimNeredeEkleme_Button_Tamam_Click(object sender, EventArgs e)
        {
            bool result = true;

            if (result)
            {
                if (Save())
                {
                    kaydedildi = true;

                    XtraMessageBox.Show("Değişiklikler kaydedildi.", "Kaydet ve Çık",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Kaydetme işlemi yapılamıyor.",
                                        "Kaydet ve Çık", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmKimNeredeEkleme_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapılan değişiklikleri kaydetmediniz.Şimdi kaydedilsin mi?",
                                                      "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void frmKimNeredeEkleme_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            //Inits.KontrolKimGetirCari(rluePersonelID);
            BelgeUtil.Inits.GetCariImages(cmbPersonel);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliBirimAdliyeID);

            //Inits.AdliBirimNoGetir(rlueAdliBirimID);
            //Inits.AdliBirimGorevGetir(rlueAdliBirimGorevID);
            //Inits.MuhasebeHareketAltKategori(rlueKategoriID);
            AddNewList.AddingNew += AddNewList_AddingNew;
            if (AddNewList == null)
                AddNewList = new TList<AV001_TDIE_BIL_KIM_NEREDE>();
            vgKimNerede.DataSource = AddNewList;
            dataNavigatorExtended1.DataSource = AddNewList;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmKimNeredeEkleme_Button_Tamam_Click;
        }
    }
}