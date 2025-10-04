using AdimAdimDavaKaydi.Util.BaseClasses;
using System;

namespace AdimAdimDavaKaydi.Editor.Forms
{
    public partial class frmDegiskenAyar : AvpXtraForm
    {
        public frmDegiskenAyar()
        {
            InitializeComponent();
        }

        public enum DegiskenAltKod
        {
            CARI,
            SORUMLU,
            VEKIL,
            GAYRIMENKUL,
            TARAF,
            ARAC,
            KÝRA,
            DEPO,
            ALAN,
        }

        public enum DegiskenAnaKod
        {
            TARAF,
            SOZLESME,
            DEPO,
            ALAN,
            TEBLIGAT
        }

        private void frmDegiskenAyar_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.SablonDegiskenGetir(this.lueDegisken.Properties);
            BelgeUtil.Inits.SablonRaporGetir(this.lueSablon.Properties);
        }

        private void lueDegisken_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lueDegisken.EditValue is AvukatProLib.Arama.VDIE_BIL_SABLON_DEGISKENLER)
            {
                AvukatProLib.Arama.VDIE_BIL_SABLON_DEGISKENLER degiskenim =
                    (AvukatProLib.Arama.VDIE_BIL_SABLON_DEGISKENLER)this.lueDegisken.EditValue;
                if (degiskenim.AD == "")
                {
                    this.ucAvukatBilgisi1.Visible = true;
                }
            }
        }
    }
}