using System;
using System.ComponentModel;
using AvukatProLib;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class ucIcraCore : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {
        #region Fields

        private AV001_TI_BIL_FOY _myFoy;

        #endregion Fields

        #region Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return _myFoy; }
            set
            {
                _myFoy = value;
                if (value != null && ucIcraGridlerTemp1 != null)
                {
                    try
                    {
                        BackgroundWorker bckWorker = new BackgroundWorker();
                        bckWorker.DoWork += delegate
                        {
                            FoyOzelKodBinding();
                        };
                        bckWorker.RunWorkerAsync();
                        ucIcraGridlerTemp1.MyFoy = value;

                        ucIcraGridlerTemp1.MyGelisme = AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme;
                    }

                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
        }

        #endregion Properties

        #region Constructors

        public ucIcraCore()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucIcraCore_Load;
        }

        #endregion Constructors

        #region Methods

        private void FoyOzelKodBinding()
        {
            if (MyFoy.AV001_TI_BIL_FOY_OZEL_KODCollection.Count == 0)
                MyFoy.AV001_TI_BIL_FOY_OZEL_KODCollection.AddNew();

            lueBanka.DataBindings.Clear();
            lueBanka.DataBindings.Add("EditValue", MyFoy.AV001_TI_BIL_FOY_OZEL_KODCollection, "BANKA_ID", true);

            lueSube.DataBindings.Clear();
            lueSube.DataBindings.Add("EditValue", MyFoy.AV001_TI_BIL_FOY_OZEL_KODCollection, "SUBE_ID", true);

            lueFoyYeri.DataBindings.Clear();
            lueFoyYeri.DataBindings.Add("EditValue", MyFoy.AV001_TI_BIL_FOY_OZEL_KODCollection, "FOY_YERI_ID", true);

            lueFoyBirim.DataBindings.Clear();
            lueFoyBirim.DataBindings.Add("EditValue", MyFoy.AV001_TI_BIL_FOY_OZEL_KODCollection, "FOY_BIRIM_ID", true);

            lueFoyOzelDurum.DataBindings.Clear();
            lueFoyOzelDurum.DataBindings.Add("EditValue", MyFoy.AV001_TI_BIL_FOY_OZEL_KODCollection, "FOY_OZEL_DURUM_ID",
                                             true);

            txtAciklama.DataBindings.Clear();
            txtAciklama.DataBindings.Add("TEXT", MyFoy.AV001_TI_BIL_FOY_OZEL_KODCollection, "ACIKLAMA", true);

            lueKrediGrup.DataBindings.Clear();
            lueKrediGrup.DataBindings.Add("EditValue", MyFoy.AV001_TI_BIL_FOY_OZEL_KODCollection, "KREDI_GRUP_ID", true);

            lueKrediTip.DataBindings.Clear();
            lueKrediTip.DataBindings.Add("EditValue", MyFoy.AV001_TI_BIL_FOY_OZEL_KODCollection, "KREDI_TIP_ID", true);

            lueTahsilat.DataBindings.Clear();
            lueTahsilat.DataBindings.Add("EditValue", MyFoy.AV001_TI_BIL_FOY_OZEL_KODCollection, "TAHSILAT_DURUM_ID",
                                         true);

            textEdit2.DataBindings.Clear();
            textEdit2.DataBindings.Add("TEXT", MyFoy.AV001_TI_BIL_FOY_OZEL_KODCollection, "KLASOR_1", true);

            textEdit3.DataBindings.Clear();
            textEdit3.DataBindings.Add("TEXT", MyFoy.AV001_TI_BIL_FOY_OZEL_KODCollection, "KLASOR_2", true);
        }
        
        private void lueBanka_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lueBanka.EditValue.ToString()))
                return;

            int BankaID = BelgeUtil.Inits.ToInt32(lueBanka.EditValue);
            BelgeUtil.Inits.BankaSubeGetir(lueSube, BankaID);
        }

        private void ucIcraCore_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (!IsLoaded)
            {
                InitializeComponent();
                try
                {
                    BackgroundWorker bckWorker = new BackgroundWorker();
                    bckWorker.DoWork += delegate
                    {
                        FoyOzelKodBinding();
                    };
                    bckWorker.RunWorkerAsync();
                    ucIcraGridlerTemp1.MyFoy = this.MyFoy;
                    ucIcraGridlerTemp1.MyGelisme = AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.myGelisme;
                }

                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
            IsLoaded = true;

            //lueFoyBirim.EditValueChanged += lueFoyBirim_EditValueChanged;
            lueBanka.EditValueChanged += lueBanka_EditValueChanged;

            //lueKrediGrup.EditValueChanged += lueKrediGrup_EditValueChanged;

            //TARIH: 01 10 2009
            //KODU YAZAN : Mehmet Emin AYDOÐDU
            //NEDENI: Etiket isimlerinin bakýmdan girildiðinde gösterilmesi.
            //Mehmet Begin
            lblBankk.Text = Kimlikci.Kimlik.IcraOzelDurum.Banka;
            lblFoyBirimm.Text = Kimlikci.Kimlik.IcraOzelDurum.FoyBirim;
            lblFoyYerii.Text = Kimlikci.Kimlik.IcraOzelDurum.FoyYeri;
            lblKlasorr1.Text = Kimlikci.Kimlik.IcraOzelDurum.Klasor1;
            lblKrediGrupp.Text = Kimlikci.Kimlik.IcraOzelDurum.KrediGrup;
            KrediTipp.Text = Kimlikci.Kimlik.IcraOzelDurum.KrediTip;
            lblOzell.Text = Kimlikci.Kimlik.IcraOzelDurum.Ozel;
            lblSubee.Text = Kimlikci.Kimlik.IcraOzelDurum.Sube;
            lblTahsilatt.Text = Kimlikci.Kimlik.IcraOzelDurum.Tahsilat;
            lblKlasorr2.Text = Kimlikci.Kimlik.IcraOzelDurum.Klasor2;

            //Mehmet End
            //LoadData();
        }

        #endregion Methods
    }
}