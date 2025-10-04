using System;
using System.Linq;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmTopluYeddiEminMaktuGuncelle : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_CET_YEDIEMIN_MAKTU_UCRET> myDataSource = new TList<TDI_CET_YEDIEMIN_MAKTU_UCRET>();

        public frmTopluYeddiEminMaktuGuncelle()
        {
            InitializeComponent();
            getDovizKurlari(DateTime.Today);
        }

        public void getDovizKurlari(DateTime dt)
        {
            DialogResult dr = XtraMessageBox.Show("En yakın tarihe ait yeddi emin maktu bedellerinin kopyalanmasını ister misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool result = dr == DialogResult.Yes ? true : false;
            yeddiMaktuUcretGetir(dt, result);
        }

        public void yeddiMaktuUcretGetir(DateTime dt, bool result)
        {
            TDI_CET_YEDIEMIN_MAKTU_UCRET yeddiEminMaktu;
            TList<TDI_KOD_ARAC_TIP> AracTip;
            AracTip = DataRepository.TDI_KOD_ARAC_TIPProvider.GetAll();

            if (result)
            {
                foreach (var item in AracTip)
                {
                    yeddiEminMaktu = new TDI_CET_YEDIEMIN_MAKTU_UCRET();
                    var m = DataRepository.TDI_CET_YEDIEMIN_MAKTU_UCRETProvider.Find("TIP_ID='" + item.ID + "'");
                    if (m.Count != 0)
                    {
                        yeddiEminMaktu = DataRepository.TDI_CET_YEDIEMIN_MAKTU_UCRETProvider.GetByTARIHTIP_ID(m.Max(i => i.TARIH), item.ID);
                    }
                    yeddiEminMaktu.TIP = item.TIP;
                    yeddiEminMaktu.TIP_ID = item.ID;
                    yeddiEminMaktu.TARIH = dt;
                    myDataSource.Add(yeddiEminMaktu);
                }
            }
            else
            {
                foreach (var item in AracTip)
                {
                    yeddiEminMaktu = new TDI_CET_YEDIEMIN_MAKTU_UCRET();
                    yeddiEminMaktu.TIP = item.TIP;
                    yeddiEminMaktu.TIP_ID = item.ID;
                    yeddiEminMaktu.TARIH = dt;
                    myDataSource.Add(yeddiEminMaktu);
                }
            }
            gridYeddiEminCetveli.DataSource = myDataSource;
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.AracTipGetir(rLueAracTip);
        }
    }
}