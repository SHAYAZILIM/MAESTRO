using System;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucKasa : DevExpress.XtraEditors.XtraUserControl
    {
        public ucKasa()
        {
            InitializeComponent();
        }

        // List<IKasali> kasali = new List<IKasali>();
        public VList<KASA_BILGILERI> kasali
        {
            get
            {
                if (extendedGridControl1.DataSource is VList<KASA_BILGILERI>)
                    return (VList<KASA_BILGILERI>)extendedGridControl1.DataSource;
                return null;
            }
            set { extendedGridControl1.DataSource = value; }
        }

        private void ucKasa_Load(object sender, EventArgs e)
        {
            //LOAD
            if (!this.DesignMode)
            {
                compGridDovizSummary1.MyGridView = gridView1;
                compGridDovizSummary1.AltToplamlarAktifMi = true;
                BelgeUtil.Inits.perCariGetir(rlkCari);
                BelgeUtil.Inits.BorcAlacakGetir(rlkBorcAlacak);
                BelgeUtil.Inits.OdemeTipiGetir(rlkOdemeTipi);
                BelgeUtil.Inits.HareketAnaKategoriGetir(rlkMuhasebeAnaKategori);
                BelgeUtil.Inits.DovizTipGetir(rlkDovizId);
                BelgeUtil.Inits.ParaBicimiAyarla(rudTutar);
            }
        }
    }
}