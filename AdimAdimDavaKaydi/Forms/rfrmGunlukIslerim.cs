using System;
using System.Collections.Generic;
using System.Linq;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class rfrmGunlukIslerim : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public rfrmGunlukIslerim()
        {
            InitializeComponent();
        }

        private void GunlukIslerimiGetir()
        {
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_I> gunlukIslerim = BelgeUtil.Inits.context.per_AV001_TDI_BIL_Is.Where(item => item.BASLANGIC_TARIHI >= DateTime.Now.AddDays(-2) && item.BITIS_TARIHI <= DateTime.Now.AddDays(2)).ToList();

            ucIsler1.MyDataSource = gunlukIslerim;
        }

        private void rfrmGunlukIslerim_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                GunlukIslerimiGetir();
        }
    }
}