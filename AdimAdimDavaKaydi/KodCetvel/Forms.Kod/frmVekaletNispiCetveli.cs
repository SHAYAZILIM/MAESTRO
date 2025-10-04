using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmVekaletNispiCetveli : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_CET_VEKALET_NISPI> MyDataSourceVekaletNispi = new TList<TDI_CET_VEKALET_NISPI>();

        public frmVekaletNispiCetveli()
        {
            InitializeComponent();
        }

        public void vekaletNispiGetir()
        {
            TDI_CET_VEKALET_NISPI vekaletNispi = new TDI_CET_VEKALET_NISPI();

            MyDataSourceVekaletNispi = AvukatProLib2.Data.DataRepository.TDI_CET_VEKALET_NISPIProvider.GetAll();
            gridVekaletNispiUcreti.DataSource = MyDataSourceVekaletNispi;
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.YuzdeBicimiAyarla(spOran);
        }

        public void vekaletNispiKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_CET_VEKALET_NISPIProvider.DeepSave(tran, MyDataSourceVekaletNispi);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    if (ex is SqlException && ex.Message.ToLower().Contains("conflict"))
                    {
                        if (tran.IsOpen)
                            tran.Rollback();
                        MessageBox.Show("Kayýt'a baðlý bulunan kayýtlardan dolayý silme iþlemi gerçekleþtirilemiyor");

                        BelgeUtil.ErrorHandler.Catch(this, ex, false, BelgeUtil.Bilesen.Kayit);
                    }
                    else
                    {
                        if (tran.IsOpen)
                            tran.Rollback();
                        BelgeUtil.ErrorHandler.Catch(this, ex, true, BelgeUtil.Bilesen.Kayit);
                    }
                }
            }
        }

        private void gridVekaletNispiUcreti_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Custom)
            {
                if (e.Button.Tag == "1")
                {
                    frmTopluVekaletNispiGüncelle frmTopluVekaletNispi = new frmTopluVekaletNispiGüncelle();
                    frmTopluVekaletNispi.ShowDialog();
                }
            }
        }

        private void sBtnKaydet_Click(object sender, EventArgs e)
        {
            vekaletNispiKaydet();
        }
    }
}