using AvukatProLib.Bakim.Claslar;
using AvukatProLib.Bakim.Resources;
using AvukatProLib.Extras;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Security.Principal;
using System.Windows.Forms;

namespace AvukatProLib.Bakim
{
    public partial class frmOzelKod : DevExpress.XtraEditors.XtraForm
    {
        public frmOzelKod()
        {
            InitializeComponent(); ;
        }
        List<CompInfo> CompInfoList;
        public void btnKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                AvukatProLib.OzelKodReferans.OzelKodReferans.Kaydet(CompInfoList[0].ConStr);
                XtraMessageBox.Show("Kaydetme Ýþleminiz baþarýyla Gerçekleþmiþtir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                XtraMessageBox.Show("Kayýt Ýþlmenide Bir Hata Oluþmuþtur", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmOzelKod_Load(object sender, EventArgs e)
        {
            CompInfoList = AvukatProLib.CompInfo.CompInfoListGetir();
            ýcraOzelKodReferansBindingSource.DataSource = AvukatProLib.OzelKodReferans.OzelKodReferans.GetIcraOzelKodReferans(CompInfoList[0].ConStr);
            davaOzelKodReferansBindingSource.DataSource = AvukatProLib.OzelKodReferans.OzelKodReferans.GetDavaOzelKodReferans(CompInfoList[0].ConStr);
            sorusturmaOzelKodReferansBindingSource.DataSource = AvukatProLib.OzelKodReferans.OzelKodReferans.GetSorusturmaOzelKodReferans(CompInfoList[0].ConStr);
            sozlesmeOzelKodReferansBindingSource.DataSource = AvukatProLib.OzelKodReferans.OzelKodReferans.GetSozlesmeOzelKodReferans(CompInfoList[0].ConStr);
            ortakOzelKodReferansBindingSource.DataSource = AvukatProLib.OzelKodReferans.OzelKodReferans.GetOrtakOzelKodReferans(CompInfoList[0].ConStr);
        }
    }
}