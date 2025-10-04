using System;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucGayrimenkulBilgileriLayout : AvpXUserControl
    {
        public ucGayrimenkulBilgileriLayout()
        {
            InitializeComponent();
            this.Load += ucGayrimenkulBilgileriLayout_Load;
        }

        private AV001_TI_BIL_GAYRIMENKUL _MyGayrimenkul;

        public AV001_TI_BIL_GAYRIMENKUL MyGayrimenkul
        {
            get { return _MyGayrimenkul; }
            set
            {
                _MyGayrimenkul = value;

                if (value != null)
                    bndGayrimenkul.DataSource = value;
            }
        }

        private void ucGayrimenkulBilgileriLayout_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            BindLookUpEdits();
        }

        private void BindLookUpEdits()
        {
            BelgeUtil.Inits.IlGetir(lueIli.Properties);
            BelgeUtil.Inits.IlceGetirTumu(lueIlcesi.Properties);
            BelgeUtil.Inits.TapuMudurlukGetir(lueMudurluk.Properties);
            BelgeUtil.Inits.BelediyeGetirTumu(lueBelediyesi.Properties);
        }
    }
}