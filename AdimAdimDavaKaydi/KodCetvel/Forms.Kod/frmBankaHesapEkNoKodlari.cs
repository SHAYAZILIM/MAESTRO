using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmBankaHesapEkNoKodlari : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_KOD_BANKA_HESAP_EKNO> MyDataSourceBankaHEsapEkNo = new TList<TDI_KOD_BANKA_HESAP_EKNO>();

        public frmBankaHesapEkNoKodlari()
        {
            InitializeComponent();
        }

        public void bankaHesapEkNoGetir()
        {
            MyDataSourceBankaHEsapEkNo = AvukatProLib2.Data.DataRepository.TDI_KOD_BANKA_HESAP_EKNOProvider.GetAll();
            gridBankaHesapEkNoKodlar.DataSource = MyDataSourceBankaHEsapEkNo;
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
        }

        public void bankaHesapEknoKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("�lgili kay�tlarda yapt���n�z t�m de�i�iklikler kaydedilecektir" + Environment.NewLine + "Onayl�yormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_BANKA_HESAP_EKNOProvider.Save(tran, MyDataSourceBankaHEsapEkNo);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    if (ex is SqlException && ex.Message.ToLower().Contains("conflict"))
                    {
                        if (tran.IsOpen)
                            tran.Rollback();
                        MessageBox.Show("Kay�t'a ba�l� bulunan kay�tlardan dolay� silme i�lemi ger�ekle�tirilemiyor");

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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bankaHesapEknoKaydet();
        }
    }
}