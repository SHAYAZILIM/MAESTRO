using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Editor.Forms
{
    public partial class frmAntetKaydet : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmAntetKaydet()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private TList<AV001_TDI_BIL_ANTET> MyDataSourceAntet = new TList<AV001_TDI_BIL_ANTET>();

        private void c_pnlContainer_Paint(object sender, PaintEventArgs e)
        {
            //
        }

        private void frmAntetKaydet_Button_Kaydet_Click(object sender, EventArgs e)
        {
            //KAYDET

            DialogResult dr =
                XtraMessageBox.Show(
                    "İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine +
                    "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.AV001_TDI_BIL_ANTETProvider.DeepSave(tran, ucAntetKaydet1.MyDataSource);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void frmAntetKaydet_Load(object sender, EventArgs e)
        {
            //LOAD

            //ucAntetKaydet1.MyDataSource = new TList<AV001_TDI_BIL_ANTET>();
            ucAntetKaydet1.MyDataSource = DataRepository.AV001_TDI_BIL_ANTETProvider.GetAll();
            if (ucAntetKaydet1.MyDataSource.Count == 0)
                ucAntetKaydet1.MyDataSource.AddNew();
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmAntetKaydet_Button_Kaydet_Click;
        }
    }
}