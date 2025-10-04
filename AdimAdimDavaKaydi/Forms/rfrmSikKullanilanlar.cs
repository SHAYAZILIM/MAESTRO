using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class rfrmSikKullanilanlar : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public rfrmSikKullanilanlar()
        {
            InitializeComponent();
            this.Load += rfrmSikKullanilanlar_Load;
        }

        private void rfrmSikKullanilanlar_Load(object sender, EventArgs e)
        {
            VList<BIRLESIK_SIK_KULLANILANLAR> kategoriler =
                DataRepository.BIRLESIK_SIK_KULLANILANLARProvider.GetByKullaniciId(AvukatProLib.Kimlik.Bilgi.ID);
            ucSikKullanilanlar1.MyDataSource = kategoriler;
        }
    }
}