using System;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AvukatProLib.Extras;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class _frmIcraTakip
    {
        public AlacakNeden CurrAlacakNedenKodId { get; set; }

        //Okan ARDIÇ
        public void ValidateRowEvents(object userControl)
        {
            if (userControl is ucOdemeler)
            {
                (userControl as ucOdemeler).ucOdemelerValidataRow += gcBorcluOdeme_ucOdemelerValidataRow;
            }
            else if (userControl is ucFeragat)
            {
                (userControl as ucFeragat).ucFeragatValidateRow += gcFeragat_ucFeragatValidateRow;
            }
            else if (userControl is ucItirazAlacakNeden)
            {
                (userControl as ucItirazAlacakNeden).ucItirazValidateRow += gcItiraz_ucItirazValidateRow;
            }
            else if (userControl is ucSatisMaster)
            {
                (userControl as ucSatisMaster).ucSatisMasterValidateRow += ucSatisMaster1_ucSatisMasterValidateRow;
                (userControl as ucSatisMaster).ucSatisChildValidateRow += ucSatisMaster1_ucSatisChildValidateRow;
            }
            else if (userControl is tabHacizGridler)
            {
            }
            else if (userControl is ucAlacaklar)
            {
            }
        }

        private void gcBorcluOdeme_ucOdemelerValidataRow(object sender,
                                                         DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TI_BIL_BORCLU_ODEME row = (AV001_TI_BIL_BORCLU_ODEME)e.Row;

            if (row.ODEME_MIKTAR < 0 || row.ODEME_MIKTAR == 0)
            {
                e.ErrorText = "Lütfen ödeme miktarý giriniz." + Environment.NewLine;
                e.Valid = false;
                return;
            }

            //Ödeme Refresh
            ucIcraTarafGelismeleri.OdemeTarihiHesapla(ucIcraTarafGelismeleri.myGelisme, MyFoy);
        }

        private void gcFeragat_ucFeragatValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TI_BIL_FERAGAT row = (AV001_TI_BIL_FERAGAT)e.Row;

            if (row.FERAGAT_MIKTAR < 0 || row.FERAGAT_MIKTAR == 0)
            {
                e.ErrorText = "Lütfen feragat miktarý giriniz." + Environment.NewLine;
                e.Valid = false;
                return;
            }
        }

        private void gcItiraz_ucItirazValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN row = (AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN)e.Row;

            if (row.ITIRAZ_TUTARI < 0 || row.ITIRAZ_TUTARI == 0)
            {
                e.ErrorText = "Lütfen ana parayý giriniz." + Environment.NewLine;
                e.Valid = false;
                return;
            }
        }

        private void ucSatisMaster1_ucSatisChildValidateRow(object sender,
                                                            DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TI_BIL_SATIS_CHILD row = (AV001_TI_BIL_SATIS_CHILD)e.Row;

            RepositoryItemGridLookUpEdit hacizliMallar = ucIcraCore1.ucIcraGridlerTemp1.ucSatisMaster1.gLueHacizliMallar;

            if (row.HACIZ_CHILD_IDSource != null)
            {
                row.HACIZLI_MAL_ADEDI = row.HACIZ_CHILD_IDSource.HACIZLI_MAL_ADEDI;

                row.HACIZLI_MAL_DEGERI = row.HACIZ_CHILD_IDSource.HACIZLI_MAL_DEGERI.Value;

                row.HACIZLI_MAL_CINS_ID = row.HACIZ_CHILD_IDSource.HACIZLI_MAL_CINS_ID;

                row.HACIZLI_MAL_KAT_ID = row.HACIZ_CHILD_IDSource.HACIZLI_MAL_KATEGORI_ID;

                row.HACIZLI_MAL_TUR_ID = row.HACIZ_CHILD_IDSource.HACIZLI_MAL_TUR_ID;
            }
        }

        private void ucSatisMaster1_ucSatisMasterValidateRow(object sender,
                                                             DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TI_BIL_SATIS_MASTER row = (AV001_TI_BIL_SATIS_MASTER)e.Row;

            if (row.SATISI_ISTENEN_CARI_ID == 0)
            {
                e.ErrorText = "Satýþý istenen taraf boþ olamaz." + Environment.NewLine;
                e.Valid = false;
                return;
            }

            if (!row.SATISI_ISTEYEN_CARI_ID.HasValue)
            {
                e.ErrorText = "Satýþý isteyen taraf boþ olamaz." + Environment.NewLine;
                e.Valid = false;
                return;
            }
        }
    }
}