using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmTeminatTazminat : DevExpress.XtraEditors.XtraForm
    {
        private TList<TDI_CET_TEMINAT_TAZMINAT> MyDataSource = new TList<TDI_CET_TEMINAT_TAZMINAT>();

        public frmTeminatTazminat()
        {
            InitializeComponent();
        }

        public void teminatTazminatGetir()
        {
            MyDataSource = DataRepository.TDI_CET_TEMINAT_TAZMINATProvider.GetAll();
            gridTeminatTazminat.DataSource = MyDataSource;
            BelgeUtil.Inits.YuzdeBicimiAyarla(spOran);
            BelgeUtil.Inits.TemiznatTazminatKodGetir(lueKategori);
        }

        public void teminatTazminatKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_CET_TEMINAT_TAZMINATProvider.DeepSave(tran, MyDataSource);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    frmCetvel.CatchKontrol(this, ex, tran);
                }
            }
        }

        private void gridTeminatTazminat_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Custom)
            {
                if (e.Button.Tag == "1")
                {
                    frmTopluTeminatTazminatGuncelle teminatTazminat = new frmTopluTeminatTazminatGuncelle();
                    teminatTazminat.ShowDialog();
                }
            }
        }

        private void sBtnKaydet_Click(object sender, EventArgs e)
        {
            teminatTazminatKaydet();
        }
    }
}