using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Sorusturma.Forms
{
    public partial class frmSorusturmaTutuklanma : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private bool kaydedildi;

        private TList<AV001_TD_BIL_TUTUKLANMA> myDataSource;

        private AV001_TD_BIL_HAZIRLIK mySorusturma;

        public frmSorusturmaTutuklanma()
        {
            InitializeComponent();
            InitializeEvents();

            this.FormClosing += frmSorusturmaTutuklanma_FormClosing;
        }

        [Browsable(false)]
        public TList<AV001_TD_BIL_TUTUKLANMA> MyDataSource
        {
            get { return myDataSource; }
            set
            {
                myDataSource = value;

                if (value != null && !this.DesignMode)
                {
                    vGTutuklama.DataSource = myDataSource;
                    dnTutuklama.DataSource = myDataSource;
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
                        MyDataSource = new TList<AV001_TD_BIL_TUTUKLANMA>();
                        MyDataSource.AddNew();
                    }
                    DataRepository.AV001_TD_BIL_TUTUKLANMAProvider.DeepLoad(MyDataSource, false,
                                                                            DeepLoadType.IncludeChildren,
                                                                            typeof(TList<AV001_TD_BIL_TUTUKLANMA>));
                }
            }
        }

        public bool Save()
        {
            bool sonuc = false;

            MyDataSource.ForEach(delegate(AV001_TD_BIL_TUTUKLANMA t) { t.HAZIRLIK_ID = MySorusturma.ID; });

            foreach (var item in MyDataSource)
            {
                if (
                    MySorusturma.AV001_TD_BIL_TUTUKLANMACollection.Exists(
                        delegate(AV001_TD_BIL_TUTUKLANMA s) { return s.ID == item.ID; })) continue;
                MySorusturma.AV001_TD_BIL_TUTUKLANMACollection.Add(item);
            }

            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                trans.BeginTransaction();

                DataRepository.AV001_TD_BIL_TUTUKLANMAProvider.DeepSave(trans,
                                                                        MySorusturma.AV001_TD_BIL_TUTUKLANMACollection);

                trans.Commit();

                sonuc = true;
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);

                for (int i = 0; i < MyDataSource.Count; i++)
                {
                    MySorusturma.AV001_TD_BIL_TUTUKLANMACollection.Remove(MyDataSource[i]);
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

        public void Show(TList<AV001_TD_BIL_TUTUKLANMA> tutuklanma)
        {
            MyDataSource = tutuklanma;
            this.Show();
        }

        private bool CikabilirMi()
        {
            foreach (AV001_TD_BIL_TUTUKLANMA h in MyDataSource)
            {
                if (h.IsNew || h.IsDirty) return false;
            }

            return true;
        }

        private void frmSorusturmaTutuklanma_Button_Kaydet_Click(object sender, EventArgs e)
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

        private void frmSorusturmaTutuklanma_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapýlan deðiþiklikleri kaydetmediniz.Þimdi kaydedilsin mi?",
                                                      "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    frmSorusturmaTutuklanma_Button_Kaydet_Click(null, null);

                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void frmSorusturmaTutuklanma_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            BelgeUtil.Inits.TutuklanmaGelisTipGetir(rLueTutuklanmaGelisTip);
            BelgeUtil.Inits.TutuklanmaTipGetir(rlueTutuklamaTip);
            BelgeUtil.Inits.KararSonucuGetir(rlueKaraSonuc);
            BelgeUtil.Inits.DosyaHedefTipGetir(rlueDosyaHedefTip);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlueAdliGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliNo);
            BelgeUtil.Inits.perCariGetir(rlueCari);
            BelgeUtil.Inits.SerbestBirakilmaNedenGetir(rlueSerBirNeden);
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmSorusturmaTutuklanma_Button_Kaydet_Click;
        }

        private void value_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_TUTUKLANMA tutuklama = new AV001_TD_BIL_TUTUKLANMA();
            tutuklama.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            tutuklama.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            tutuklama.KONTROL_NE_ZAMAN = DateTime.Now;
            tutuklama.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            tutuklama.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            tutuklama.KAYIT_TARIHI = DateTime.Now;
            e.NewObject = tutuklama;
        }
    }
}