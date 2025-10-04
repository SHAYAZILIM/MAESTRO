using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmTopluDavaMaktuHarcGuncelle : DevExpress.XtraEditors.XtraForm
    {
        private TList<TD_CET_HARC_MAKTU> MyDataSourceHarcMaktu = new TList<TD_CET_HARC_MAKTU>();

        public frmTopluDavaMaktuHarcGuncelle()
        {
            InitializeComponent();
            getHarcMaktu(DateTime.Today);
        }

        public void getHarcMaktu(DateTime dt)
        {
            DialogResult dr = XtraMessageBox.Show("En yakın tarihe ait dava harç maktu değerlerinin kopyalanmasını ister misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool result = dr == DialogResult.Yes ? true : false;
            maktuDavaHarcGetir(dt, result);
        }

        public void maktuDavaHarcGetir(DateTime dt, bool result)
        {
            TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> muhasebeAltKategori = new TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI>();
            muhasebeAltKategori = DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetAll();
            TD_CET_HARC_MAKTU davaHarcMaktu;

            //MyDataSourceHarcMaktuIcra = AvukatProLib2.Data.DataRepository.TI_CET_HARC_MAKTUProvider.GetAll();
            foreach (var item in muhasebeAltKategori)
            {
                davaHarcMaktu = new TD_CET_HARC_MAKTU();
                davaHarcMaktu.HARC_KOD_ACIKLAMA = item.ALT_KATEGORI;
                davaHarcMaktu.HARC_KOD_ID = item.ID;
                davaHarcMaktu.TARIH = dt;

                //davaHarcMaktu.DOVIZ=;
                //davaHarcMaktu.DOVIZ_ID=;
                MyDataSourceHarcMaktu.Add(davaHarcMaktu);
            }
            MyDataSourceHarcMaktu = AvukatProLib2.Data.DataRepository.TD_CET_HARC_MAKTUProvider.GetAll();
            gridDavaMaktuHarc.DataSource = MyDataSourceHarcMaktu;
            BelgeUtil.Inits.MuhasebeHareketAltKategori(lueHarcKod);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.ParaBicimiAyarla(repositoryItemSpinEdit1);
        }
    }
}