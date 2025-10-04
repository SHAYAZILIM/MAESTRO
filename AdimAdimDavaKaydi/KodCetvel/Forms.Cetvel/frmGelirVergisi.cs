using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Cetvel
{
    public partial class frmGelirVergisi : Form
    {
        private TList<TDI_CET_GELIR_VERGISI> MyDataSourceFoyBirim = new TList<TDI_CET_GELIR_VERGISI>();

        public frmGelirVergisi()
        {
            InitializeComponent();
        }

        public void foyYeriDoldur()
        {
            MyDataSourceFoyBirim = AvukatProLib2.Data.DataRepository.TDI_CET_GELIR_VERGISIProvider.GetAll();
            gridDosyaYerleri.DataSource = MyDataSourceFoyBirim;
            BelgeUtil.Inits.DigerVergiVergiTuruGetir(rlueVergiKodu);
            BelgeUtil.Inits.YuzdeBicimiAyarla(spTarifeOran);
            BelgeUtil.Inits.ParaBicimiAyarla(spMiktar);
        }
    }
}