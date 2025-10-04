using System.Windows.Forms;
using AvukatProLib;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucOzelKodBankaSubeBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucOzelKodBankaSubeBilgileri()
        {
            InitializeComponent();
        }

        public bool isFoyNew = false;

        private TList<AV001_TI_BIL_FOY_OZEL_KOD> _myIcraOzelKod;

        public TList<AV001_TI_BIL_FOY_OZEL_KOD> MyIcraOzelKod
        {
            get { return _myIcraOzelKod; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    InitsData();
                    vgOzelKodBilgileri.DataSource = value;

                    #region <MB-20100514>

                    //Seçili ile göre ilçe gelmesi için eklendi.

                    foreach (var item in value)
                    {
                        item.ColumnChanged += item_ColumnChanged;
                    }

                    #endregion
                }
            }
        }

        #region <MB-20100514>

        //Seçili ile göre ilçe gelmesi için eklendi.

        private void item_ColumnChanged(object sender, AV001_TI_BIL_FOY_OZEL_KODEventArgs e)
        {
            if (e.Column == AV001_TI_BIL_FOY_OZEL_KODColumn.BANKA_ID)
            {
                BelgeUtil.Inits.BankaSubeGetir(rLueSube, (int)e.Value);
            }
        }

        private void item_ColumnChanged(object sender, AV001_TD_BIL_FOY_OZEL_KODEventArgs e)
        {
            if (e.Column == AV001_TD_BIL_FOY_OZEL_KODColumn.BANKA_ID)
            {
                BelgeUtil.Inits.BankaSubeGetir(rLueSube, (int)e.Value);
            }
        }

        #endregion

        private void InitsData()
        {
            if (isFoyNew)
            {
                rLueBanka.NullText = "Seç";
                rLueFoyBirim.NullText = "Seç";
                rLueFoyYeri.NullText = "Seç";
                rLueFoyOzelDurum.NullText = "Seç";
                rLueKrediGrup.NullText = "Seç";
                rLueKrediTip.NullText = "Seç";
                rLueSube.NullText = "Seç";
                rLueTahsilatDurum.NullText = "Seç";
                rLueBanka.Enter += delegate { BelgeUtil.Inits.BankaGetir(rLueBanka); };
                rLueFoyBirim.Enter += delegate { BelgeUtil.Inits.FoyBirimGetirEdit(rLueFoyBirim); };
                rLueFoyYeri.Enter += delegate { BelgeUtil.Inits.FoyYeriGetir(rLueFoyYeri); };
                rLueFoyOzelDurum.Enter += delegate { BelgeUtil.Inits.FoyOzelDurumGetir(rLueFoyOzelDurum); };
                rLueKrediGrup.Enter += delegate { BelgeUtil.Inits.KrediGrubu(rLueKrediGrup); };
                rLueKrediTip.Enter += delegate { BelgeUtil.Inits.KrediTipiGetir(rLueKrediTip); };
                rLueSube.Enter += delegate { BelgeUtil.Inits.BankaSubelerGetir(rLueSube); };
                rLueTahsilatDurum.Enter += delegate { BelgeUtil.Inits.TahsilatdurumGetir(rLueTahsilatDurum); };
            }
            else
            {
                rLueBanka.NullText = "Seç";
                rLueFoyBirim.NullText = "Seç";
                rLueFoyYeri.NullText = "Seç";
                rLueFoyOzelDurum.NullText = "Seç";
                rLueKrediGrup.NullText = "Seç";
                rLueKrediTip.NullText = "Seç";
                rLueSube.NullText = "Seç";
                rLueTahsilatDurum.NullText = "Seç";
                BelgeUtil.Inits.BankaGetir(rLueBanka);
                BelgeUtil.Inits.FoyBirimGetir(rLueFoyBirim);
                BelgeUtil.Inits.FoyYeriGetir(rLueFoyYeri);
                BelgeUtil.Inits.FoyOzelDurumGetir(rLueFoyOzelDurum);
                BelgeUtil.Inits.KrediGrubu(rLueKrediGrup);
                BelgeUtil.Inits.KrediTipiGetir(rLueKrediTip);
                BelgeUtil.Inits.BankaSubeGetir(rLueSube);
                BelgeUtil.Inits.TahsilatdurumGetir(rLueTahsilatDurum);
            }

            #region Ozellestirme

            //TARIH         :  29 Eylül 2009 Salı
            //KODU YAZAN    :  Mehmet Emin AYDOĞDU
            //NEDENI        :  Başlıklarının Veri Tabnından Alınması
            //Mehmet Begin
            if (rowBANKA_ID.Properties.Caption != null)
                rowBANKA_ID.Properties.Caption = Kimlikci.Kimlik.OrtakOzelDurum.Banka;
            if (rowSUBE_ID.Properties.Caption != null)
                rowSUBE_ID.Properties.Caption = Kimlikci.Kimlik.OrtakOzelDurum.Sube;
            if (rowFOY_BIRIM_ID.Properties.Caption != null)
                rowFOY_BIRIM_ID.Properties.Caption = Kimlikci.Kimlik.OrtakOzelDurum.FoyBirim;
            if (rowFOY_OZEL_DURUM_ID.Properties.Caption != null)
                rowFOY_OZEL_DURUM_ID.Properties.Caption = Kimlikci.Kimlik.OrtakOzelDurum.Ozel;
            if (rowFOY_YERI_ID.Properties.Caption != null)
                rowFOY_YERI_ID.Properties.Caption = Kimlikci.Kimlik.OrtakOzelDurum.FoyYeri;
            if (rowKREDI_GRUP_ID.Properties.Caption != null)
                rowKREDI_GRUP_ID.Properties.Caption = Kimlikci.Kimlik.OrtakOzelDurum.KrediGrup;
            if (rowKREDI_TIP_ID.Properties.Caption != null)
                rowKREDI_TIP_ID.Properties.Caption = Kimlikci.Kimlik.OrtakOzelDurum.KrediTip;
            if (rowTAHSILAT_DURUM_ID.Properties.Caption != null)
                rowTAHSILAT_DURUM_ID.Properties.Caption = Kimlikci.Kimlik.OrtakOzelDurum.Tahsilat;
            if (rowKLASOR_1.Properties.Caption != null)
                rowKLASOR_1.Properties.Caption = Kimlikci.Kimlik.OrtakOzelDurum.Klasor1;
            if (rowKLASOR_2.Properties.Caption != null)
                rowKLASOR_2.Properties.Caption = Kimlikci.Kimlik.OrtakOzelDurum.Klasor2;

            //Mehmet End

            #endregion
        }

        private TList<AV001_TD_BIL_FOY_OZEL_KOD> _myDavaOzelKod;

        public TList<AV001_TD_BIL_FOY_OZEL_KOD> MyDavaOzelKod
        {
            get { return _myDavaOzelKod; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    InitsData();
                    vgOzelKodBilgileri.DataSource = value;

                    #region <MB-20100514>

                    //Seçili ile göre ilçe gelmesi için eklendi.

                    foreach (var item in value)
                    {
                        item.ColumnChanged += item_ColumnChanged;
                    }

                    #endregion
                }
            }
        }
    }
}