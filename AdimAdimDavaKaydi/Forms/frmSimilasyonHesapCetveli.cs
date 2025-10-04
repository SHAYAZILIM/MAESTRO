using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmSimilasyonHesapCetveli : XtraForm
    {
        public frmSimilasyonHesapCetveli()
        {
            InitializeComponent();
        }

        public TList<AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI> MyDataSource
        {
            get { return ucSimulasyonHesapCetveli1.MyDataSource; }
            set
            {
                ucSimulasyonHesapCetveli1.MyDataSource = value;

                if (value.Count > 1)
                {
                    YedekCetvel = value[1].Clone() as AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI;
                }
            }
        }

        private AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI YedekCetvel { get; set; }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var kolonlar = YedekCetvel.TableColumns;
            for (int i = 0; i < kolonlar.Length; i++)
            {
                MyDataSource[1][kolonlar[i]] = YedekCetvel[kolonlar[i]];
            }
        }
    }
}