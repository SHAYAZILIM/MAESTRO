using System;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Entities;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucAracBilgileriLayout : AvpXUserControl
    {
        public ucAracBilgileriLayout()
        {
            InitializeComponent();
            this.Load += ucAracBilgileriLayout_Load;
        }

        private AV001_TDI_BIL_GEMI_UCAK_ARAC _MyArac;

        public AV001_TDI_BIL_GEMI_UCAK_ARAC MyArac
        {
            get { return _MyArac; }
            set
            {
                _MyArac = value;

                if (value != null)
                {
                    bndArac.DataSource = value;

                    if (value.TIPI == (int) AvukatProLib.Extras.AracTipi.GEMI)
                        lcAracBilgileri.RestoreLayoutFromXml(Application.StartupPath + "\\GemiUcakAracTipleri\\Gemi.XML");
                    else if (value.TIPI == (int) AvukatProLib.Extras.AracTipi.UCAK)
                        lcAracBilgileri.RestoreLayoutFromXml(Application.StartupPath + "\\GemiUcakAracTipleri\\Ucak.XML");
                    else if (value.TIPI == (int) AvukatProLib.Extras.AracTipi.ARAC)
                        lcAracBilgileri.RestoreLayoutFromXml(Application.StartupPath + "\\GemiUcakAracTipleri\\Arac.XML");
                }
            }
        }

        private void ucAracBilgileriLayout_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            BindLookUpEdits();
        }

        private void BindLookUpEdits()
        {
            BelgeUtil.Inits.perCariAvukatGetir(lueSahibi.Properties);
            BelgeUtil.Inits.AracTipGetir(lueAracTip.Properties);
        }
    }
}