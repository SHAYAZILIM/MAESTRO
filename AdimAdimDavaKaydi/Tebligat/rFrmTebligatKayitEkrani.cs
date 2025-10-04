using System;
using AvukatProLib2.Entities;
using BelgeUtil;

namespace AdimAdimDavaKaydi.Tebligat
{
    public partial class rFrmTebligatKayitEkrani : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private TList<AV001_TDI_BIL_TEBLIGAT> MyDataSource = new TList<AV001_TDI_BIL_TEBLIGAT>();

        public rFrmTebligatKayitEkrani()
        {
            InitializeComponent();
        }

        private void rFrmTebligatKayitEkrani_Load(object sender, EventArgs e)
        {
            //LOAD
            BelgeUtil.Inits.MasrafAvansHedefTipGetir(rLueHEdefTip);
            BelgeUtil.Inits.TebligatAnaTurGetir(rLueTebligatAnaTur);
            BelgeUtil.Inits.TebligatAltTurGetir(rLueTebligatAltTur);
            BelgeUtil.Inits.perCariGetir(rLueTebligatCari);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueBirimNo);
            BelgeUtil.Inits.MuhasebeHareketAltKategori(rLueMuhasebeAltKategori);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.CariOzelKodGetir(rLueCariOzelKod);
            BelgeUtil.Inits.TebligatKonuGetir(rLueTebligatKonu);
            BelgeUtil.Inits.BelgeOzelKodGetir(rLueBelgeOzelKod);
            BelgeUtil.Inits.FoyOzelKodGetir(rLueFoyOzelKod);

            MyDataSource = BelgeUtil.Inits.TebligatGetir();
            exGridTebligatKayit.DataSource = MyDataSource;
        }
    }
}