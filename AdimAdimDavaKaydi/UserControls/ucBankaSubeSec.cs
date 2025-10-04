using System;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucBankaSubeSec : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBankaSubeSec()
        {
            InitializeComponent();
        }

        public List<AvukatProLib.Arama.VDI_KOD_BANKA_SUBE_Detay> MyDataSource
        {
            get
            {
                if (exGridBankaSube.DataSource is List<AvukatProLib.Arama.VDI_KOD_BANKA_SUBE_Detay>)
                    return (List<AvukatProLib.Arama.VDI_KOD_BANKA_SUBE_Detay>)exGridBankaSube.DataSource;
                return null;
            }
            set
            {
                if (value != null)
                    exGridBankaSube.DataSource = value;
            }
        }

        private void ucBankaSubeSec_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;
            BelgeUtil.Inits.BankaGetir(rLueBanka);
            BelgeUtil.Inits.BankaBolgeGetir(rLueBankaBolge);
        }

        public List<AvukatProLib.Arama.VDI_KOD_BANKA_SUBE_Detay> GetSelectedBankaSube(List<AvukatProLib.Arama.VDI_KOD_BANKA_SUBE_Detay> bankaSube)
        {
            gridView1.ValidateEditor();
            return bankaSube.FindAll(item => item.IsSelected);
        }
    }
}