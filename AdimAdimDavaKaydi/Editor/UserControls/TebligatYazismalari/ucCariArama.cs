using AvukatProLib2.Entities;
using System;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucCariAlt : DevExpress.XtraEditors.XtraUserControl
    {
        public ucCariAlt()
        {
            InitializeComponent();
        }

        public TList<AV001_TDI_BIL_CARI_ALT> MyDataSource
        {
            get
            {
                if (exGridCariArama.DataSource is TList<AV001_TDI_BIL_CARI_ALT>)
                    return (TList<AV001_TDI_BIL_CARI_ALT>)exGridCariArama.DataSource;
                return null;
            }
            set
            {
                exGridCariArama.DataSource = value;
                extendedGridControl1.DataSource = exGridCariArama.DataSource;
            }
        }

        private void ucCariArama_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;

            BelgeUtil.Inits.IlGetir(rLueIlID);
            BelgeUtil.Inits.IlceGetirOzetli(rLueIlceID);
            BelgeUtil.Inits.UlkeGetir(rLueUlkeID);
            BelgeUtil.Inits.FirmaTurGetir(rLueFirmaTur);
            BelgeUtil.Inits.BankaGetir(rLueBanka);
            BelgeUtil.Inits.BankaSubeGetir(rLueBankaSube);
            BelgeUtil.Inits.MeslekGetir(rLueMeslek);
            BelgeUtil.Inits.perCariGetir(rLueCari);
            BelgeUtil.Inits.CariOzelKodGetir(rLueOzelKod);
            BelgeUtil.Inits.IsSozlesmeGetir(rLueIsSozlesme);
            BelgeUtil.Inits.AdresTurGetir(rLueAdresTur);
            BelgeUtil.Inits.SemtGetir(rLueSemtID);
            BelgeUtil.Inits.DilKodGetir(rLueDil);
            BelgeUtil.Inits.OkulGetir(rLueOkul);
            BelgeUtil.Inits.CariUnvanGetir(rLueUnvan);
            BelgeUtil.Inits.IlceGetirOzetli(rLueSicilYer);
            BelgeUtil.Inits.KimlikTurGetir(rLueKimlik);
            BelgeUtil.Inits.UyrukGetir(rLueUyruk);
            BelgeUtil.Inits.CinsiyetGetir(rLueCinsiyet);
            BelgeUtil.Inits.MedeniHalGetir(rLueMedeniHal);
            BelgeUtil.Inits.KanGrupGetir(rLueKanGrup);
            BelgeUtil.Inits.KimlikVerilisNedenGetir(rLueCuzdanVerilmeNeden);
            BelgeUtil.Inits.perCariGetir(rlueUstCari);
        }
    }
}