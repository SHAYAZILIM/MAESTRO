using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Sorusturma.Forms
{
    public partial class frmSorusturmaHikaye : AvpXtraForm
    {
        private TList<AV001_TD_BIL_HAZIRLIK_HIKAYE> _MyDataSource;

        private AV001_TD_BIL_HAZIRLIK myFoy;

        public frmSorusturmaHikaye()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += frmSorusturmaHikaye_Load;
        }

        [Browsable(false)]
        public TList<AV001_TD_BIL_HAZIRLIK_HIKAYE> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                _MyDataSource.AddingNew += _MyDataSource_AddingNew;
                vgTakibinHikayesi.DataSource = value;
                dataNavigatorExtended1.DataSource = value;
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_HAZIRLIK MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (MyDataSource == null)
                {
                    MyDataSource = new TList<AV001_TD_BIL_HAZIRLIK_HIKAYE>();
                }
            }
        }

        private void _MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_HAZIRLIK_HIKAYE hikaye = new AV001_TD_BIL_HAZIRLIK_HIKAYE();
            hikaye.KAYIT_TARIHI = DateTime.Today;
            hikaye.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            hikaye.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            hikaye.KONTROL_NE_ZAMAN = DateTime.Today;
            hikaye.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            e.NewObject = hikaye;
        }

        private void frmSorusturmaHikaye_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                MessageBox.Show("Kayıt işlemi başarı ile gerçekleştirildi.", "Kayıt", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Kayıt sırasında bir sorunla karşılaşıldı.", "İptal", MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
        }

        private void frmSorusturmaHikaye_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.HikayeSurecGetirSorusturma(rLueHikayeSurec);
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmSorusturmaHikaye_Button_Kaydet_Click;
        }

        private bool Save()
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                if (MyFoy != null)
                {
                    foreach (var item in MyDataSource)
                    {
                        item.HAZIRLIK_ID = MyFoy.ID;

                        if (item.ID == 0)
                            MyFoy.AV001_TD_BIL_HAZIRLIK_HIKAYECollection.Add(item);
                    }
                    tran.BeginTransaction();
                    DataRepository.AV001_TD_BIL_HAZIRLIK_HIKAYEProvider.DeepSave(tran,
                                                                                 MyFoy.
                                                                                     AV001_TD_BIL_HAZIRLIK_HIKAYECollection);
                    tran.Commit();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    return true;
                }

                else
                    return false;
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);
                return false;
            }
        }
    }
}