using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Sorusturma.Forms
{
    public partial class frmSikayetNeden : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private bool kaydedildi;

        private TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN> myDataSource;

        private AV001_TD_BIL_HAZIRLIK mySorusturma;

        public frmSikayetNeden()
        {
            InitializeComponent();
            this.Load += frmSikayetNeden_Load;
            this.FormClosing += frmSikayetNeden_FormClosing;
            InitializeEvents();
        }

        public event EventHandler<HazirlikSikayetKaydedildiEventArgs> HazirlikSikayetKaydedildi;

        [Browsable(false)]
        public TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN> MyDataSource
        {
            get { return myDataSource; }
            set
            {
                myDataSource = value;
                if (!this.DesignMode || value != null)
                {
                    vgSikayetNeden.DataSource = myDataSource;
                    dnSikayetNeden.DataSource = myDataSource;
                    value.AddingNew += value_AddingNew;
                }
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_HAZIRLIK MySorusturma
        {
            get { return mySorusturma; }
            set
            {
                mySorusturma = value;
                if (value != null)
                {
                    if (MyDataSource == null)
                    {
                        MyDataSource = new TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN>();
                        MyDataSource.AddNew();
                    }
                    DataRepository.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENProvider.DeepLoad(MyDataSource, false,
                                                                                        DeepLoadType.IncludeChildren,
                                                                                        typeof(
                                                                                            TList
                                                                                            <
                                                                                            AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN
                                                                                            >));
                }
            }
        }

        public void InitsData()
        {
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.SikayetNedenGetir(rLueSikayetNedenKod);
        }

        public bool Save()
        {
            bool sonuc = false;

            if (MyDataSource != null)
            {
                MyDataSource.ForEach(
                    delegate(AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN s) { s.HAZIRLIK_ID = MySorusturma.ID; });
            }

            //MySorusturma.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection.AddRange(MyDataSource);

            foreach (var item in MyDataSource)
            {
                if (
                    MySorusturma.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection.Exists(
                        delegate(AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN s) { return s.ID == item.ID; })) continue;
                MySorusturma.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection.Add(item);
            }

            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                trans.BeginTransaction();

                DataRepository.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENProvider.DeepSave(trans,
                                                                                    MySorusturma.
                                                                                        AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection,
                                                                                    DeepSaveType.IncludeChildren);

                trans.Commit();

                foreach (var surc in MyDataSource)
                {
                    if (HazirlikSikayetKaydedildi != null)
                        HazirlikSikayetKaydedildi(this, new HazirlikSikayetKaydedildiEventArgs(surc));
                }

                sonuc = true;
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);

                if (MyDataSource != null)
                {
                    for (int i = 0; i < MyDataSource.Count; i++)
                    {
                        MySorusturma.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection.Remove(MyDataSource[i]);
                    }
                }

                kaydedildi = false;

                return false;
            }

            finally
            {
                trans.Dispose();
            }

            return sonuc;
        }

        private bool CikabilirMi()
        {
            if (MyDataSource == null)
                return true;
            foreach (AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN h in MyDataSource)
            {
                if (h.IsNew || h.IsDirty) return false;
            }

            return true;
        }

        private void frmSikayetNeden_Button_Kaydet_Click(object sender, EventArgs e)
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

        private void frmSikayetNeden_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapýlan deðiþiklikleri kaydetmediniz.Þimdi kaydedilsin mi?",
                                                      "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    frmSikayetNeden_Button_Kaydet_Click(null, null);

                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void frmSikayetNeden_Load(object sender, EventArgs e)
        {
            InitsData();
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmSikayetNeden_Button_Kaydet_Click;
        }

        private void value_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN sikayetNeden = new AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN();
            sikayetNeden.KAYIT_TARIHI = DateTime.Now;
            sikayetNeden.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            sikayetNeden.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            sikayetNeden.KONTROL_NE_ZAMAN = DateTime.Now;
            sikayetNeden.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            sikayetNeden.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            e.NewObject = sikayetNeden;
        }

        //public void Show(TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN> sikayetNeden)
        //{
        //    MyDataSource = sikayetNeden;
        //    this.Show();
        //}
    }
}