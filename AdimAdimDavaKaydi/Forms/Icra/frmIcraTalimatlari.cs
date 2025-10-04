using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Icra
{
    public partial class frmIcraTalimatlari : AvpXtraForm
    {
        public frmIcraTalimatlari()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += frmIcraTalimatlari_Load;
        }

        private TList<AV001_TI_BIL_TALIMAT> _MyDataSource;

        private AV001_TI_BIL_FOY myFoy;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_TALIMAT> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                _MyDataSource.AddingNew += _MyDataSource_AddingNew;
                vgTalimatBilgileri.DataSource = value;
                dataNavigatorExtended1.DataSource = value;
                if (value.Count > 0)
                    gcIcraTalimatlari.DataSource = value[0].AV001_TI_BIL_TALIMAT_BORCLUCollection;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (MyDataSource == null)
                {
                    MyDataSource = new TList<AV001_TI_BIL_TALIMAT>();
                }
            }
        }

        private void _MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_TALIMAT hikaye = new AV001_TI_BIL_TALIMAT();
            if (MyFoy != null)
            {
                hikaye.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
                hikaye.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
                hikaye.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
            }
            hikaye.KAYIT_TARIHI = DateTime.Today;
            hikaye.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            hikaye.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            hikaye.KONTROL_NE_ZAMAN = DateTime.Today;
            hikaye.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            hikaye.AV001_TI_BIL_TALIMAT_BORCLUCollection.AddingNew += AV001_TI_BIL_TALIMAT_BORCLUCollection_AddingNew;
            gcIcraTalimatlari.DataSource = hikaye.AV001_TI_BIL_TALIMAT_BORCLUCollection;
            e.NewObject = hikaye;
        }

        private void AV001_TI_BIL_TALIMAT_BORCLUCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_TALIMAT_BORCLU borclu = new AV001_TI_BIL_TALIMAT_BORCLU();
            borclu.KAYIT_TARIHI = DateTime.Today;
            borclu.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            borclu.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            borclu.KONTROL_NE_ZAMAN = DateTime.Today;
            borclu.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            e.NewObject = borclu;
        }

        private void frmIcraTalimatlari_Button_Kaydet_Click(object sender, EventArgs e)
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

        private void frmIcraTalimatlari_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.perCariGetir(rLueCari);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueBirimNo);
            BelgeUtil.Inits.perSorumluAvukatGetir(rLueSorumlu);
            BelgeUtil.Inits.TalimatIslemGetir(rLueTalimatIslem);
            BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
            BelgeUtil.Inits.perCariGetir(rlueBorcluID);
            BelgeUtil.Inits.ParaBicimiAyarla(spPara);
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmIcraTalimatlari_Button_Kaydet_Click;
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
                        item.ICRA_FOY_ID = MyFoy.ID;

                        if (item.ID == 0)
                            MyFoy.AV001_TI_BIL_TALIMATCollection.Add(item);
                    }
                    tran.BeginTransaction();
                    DataRepository.AV001_TI_BIL_TALIMATProvider.DeepSave(tran, MyFoy.AV001_TI_BIL_TALIMATCollection,
                                                                         DeepSaveType.IncludeChildren,
                                                                         typeof(TList<AV001_TI_BIL_TALIMAT_BORCLU>));
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