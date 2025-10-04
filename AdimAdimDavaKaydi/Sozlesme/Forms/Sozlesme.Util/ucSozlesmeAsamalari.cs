using System;
using System.ComponentModel;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Sozlesme.Forms.Sozlesme.Util
{
    public partial class ucSozlesmeAsamalari : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucSozlesmeAsamalari()
        {
            InitializeComponent();
            this.Load += ucSozlesmeAsamalari_Load;
        }

        [Browsable(false)]
        public TList<AV001_TDIE_BIL_ASAMA> MyDataSource
        {
            get
            {
                if (gridControl1.DataSource is TList<AV001_TDIE_BIL_ASAMA>)
                    return (TList<AV001_TDIE_BIL_ASAMA>)gridControl1.DataSource;
                else
                    return null;
            }
            set
            {
                if (value != null && this.DesignMode == false)
                    gridControl1.DataSource = value;
            }
        }
        
        private void gridControl1_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "FormdanEkle")
            {
                //Giriþ Formu Verilecek.
            }
        }

        private void ucSozlesmeAsamalari_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                BelgeUtil.Inits.AsamaModulGetir(rLueAsamaModul);
                BelgeUtil.Inits.AsamaKodGetir(rLueAsamaKod);
                BelgeUtil.Inits.AsamaAltKodGetir(rLueAsmaAltKod);
                BelgeUtil.Inits.DavaNedenGetir(rLueDavaNeden);
                BelgeUtil.Inits.AlacakNEdenGetir(rLuealacakNeden);
                BelgeUtil.Inits.FormTipiGetir(rLueIcraFormTip);
                BelgeUtil.Inits.AdliBirimBolumGetir(rLueAdliBirimBolumID);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
                BelgeUtil.Inits.AsamaOzelDurumGetir(rLueAsamaOzelDurumLar);
                BelgeUtil.Inits.HazirlikSikayetNedenGetir(rLueHazirlikNeden);
            }
        }
    }
}