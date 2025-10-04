using System;
using AvukatProLib.Extras;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi
{
    public partial class ucDavaNedenTaraf : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDavaNedenTaraf()
        {
            InitializeComponent();
        }

        public event DevExpress.XtraVerticalGrid.Events.IndexChangedEventHandler DavaNedenTarafChanged;

        public AV001_TD_BIL_DAVA_NEDEN_TARAF CurrentNedenTaraf
        {
            get
            {
                if (DesignMode) return null;
                AV001_TD_BIL_DAVA_NEDEN_TARAF taraf =
                    vgDavaNedenTaraf.GetRecordObject(vgDavaNedenTaraf.FocusedRecord) as AV001_TD_BIL_DAVA_NEDEN_TARAF;
                return taraf;
            }
        }

        public TList<AV001_TD_BIL_DAVA_NEDEN_TARAF> MyDataSource
        {
            get
            {
                if (vgDavaNedenTaraf.DataSource is TList<AV001_TD_BIL_DAVA_NEDEN_TARAF>)
                    return (TList<AV001_TD_BIL_DAVA_NEDEN_TARAF>)vgDavaNedenTaraf.DataSource;
                else
                    return null;
            }
            set { vgDavaNedenTaraf.DataSource = value; }
        }

        public void GridSekillendir(AvukatProLib.Extras.AdliBirimBolumKod kod)
        {
            mrowSorumluOlunanMiktarCari.Visible = true;
            mrowAsliFeriMudahale.Visible = true;
            mrowYurutmeDurdurma.Visible = true;
            rowYURUTME_DURDURMA_KALDIRILMA_TARIHI.Visible = true;
            mrowIhbarEdCari.Visible = true;
            rowYURUTME_DURDURMA_KALDIRILMA_TARIHI.Properties.Caption = "Y.D. Kaldýrma T.";
            mrowYurutmeDurdurma.PropertiesCollection["YURUTME_DURDURMA_TALEP_TARIHI"].Caption = "Y.D. Talep T.";
            mrowYurutmeDurdurma.PropertiesCollection["YURUTME_DURDURMA_TARIHI"].Caption = "Y.D. Tarihi";
            switch (kod)
            {
                case AdliBirimBolumKod.C:
                case AdliBirimBolumKod.SAV:
                case AdliBirimBolumKod.AC:
                case AdliBirimBolumKod.CI:
                    mrowSorumluOlunanMiktarCari.Visible = false;
                    mrowAsliFeriMudahale.Visible = false;
                    mrowYurutmeDurdurma.Visible = false;
                    rowYURUTME_DURDURMA_KALDIRILMA_TARIHI.Visible = false;
                    mrowIhbarEdCari.Visible = false;
                    rowYURUTME_DURDURMA_KALDIRILMA_TARIHI.Properties.Caption = "T.D. Kaldýrma T.";
                    mrowYurutmeDurdurma.PropertiesCollection["YURUTME_DURDURMA_TALEP_TARIHI"].Caption = "T.D. Talep T.";
                    mrowYurutmeDurdurma.PropertiesCollection["YURUTME_DURDURMA_TARIHI"].Caption = "T.D. Tarihi";
                    break;

                case AdliBirimBolumKod.HI:
                case AdliBirimBolumKod.IIF:
                case AdliBirimBolumKod.H:
                case AdliBirimBolumKod.I:
                case AdliBirimBolumKod.IF:
                case AdliBirimBolumKod.O:
                case AdliBirimBolumKod.OI:
                case AdliBirimBolumKod.N:
                    rowYURUTME_DURDURMA_KALDIRILMA_TARIHI.Properties.Caption = "T.D. Kaldýrma T.";
                    mrowYurutmeDurdurma.PropertiesCollection["YURUTME_DURDURMA_TALEP_TARIHI"].Caption = "T.D. Talep T.";
                    mrowYurutmeDurdurma.PropertiesCollection["YURUTME_DURDURMA_TARIHI"].Caption = "T.D. Tarihi";
                    break;

                case AdliBirimBolumKod.ID:
                    break;

                case AdliBirimBolumKod.V:
                    break;

                case AdliBirimBolumKod.AID:
                    break;

                case AdliBirimBolumKod.AYID:
                    break;

                default:
                    break;
            }
        }

        public void initComponent()
        {
            BelgeUtil.Inits.perCariGetir(rlkIhbarEdilenCari);
            BelgeUtil.Inits.DovizTipGetir(rlkSorumluOlunanMiktarBirim);
            BelgeUtil.Inits.perCariGetir(rlkTarafCariId);
            BelgeUtil.Inits.CariSifatGetir(rlkTARAF_SIFAT_ID);
            BelgeUtil.Inits.ParaBicimiAyarla(rudSorumluOlunanTutar);
        }

        private void ucDavaNedenTaraf_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                initComponent();
        }

        private void vgDavaNedenTaraf_FocusedRecordChanged(object sender,
                                                           DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (DavaNedenTarafChanged != null)
            {
                DavaNedenTarafChanged(sender, e);
            }
        }
    }
}