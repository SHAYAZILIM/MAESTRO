using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmTeminatMektupGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private TList<AV001_TDI_BIL_TEMINAT_MEKTUP> MyDataSourceSave = new TList<AV001_TDI_BIL_TEMINAT_MEKTUP>();

        public rFrmTeminatMektupGirisEkran()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += teminatMektupKaydet_ItemClick;
        }

        public void TeminatMektupKaydet()
        {
            DialogResult dr =
                XtraMessageBox.Show(
                    "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine +
                    "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.DeepSave(tran, MyDataSourceSave);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen)
                        tran.Rollback();
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void rFrmTeminatMektupGirisEkran_Load(object sender, EventArgs e)
        {
            //LOAD
            MyDataSourceSave = new TList<AV001_TDI_BIL_TEMINAT_MEKTUP>();
            DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.DeepLoad(MyDataSourceSave, true,
                                                                         DeepLoadType.IncludeChildren,
                                                                         typeof(
                                                                             TList<AV001_TDI_BIL_TEMINAT_MEKTUP_TARAF>));
            ucTeminatMektupBilgiler1.MyDataSource = MyDataSourceSave;
        }

        private void teminatMektupKaydet_ItemClick(object sender, EventArgs e)
        {
            //KAYDET
            TeminatMektupKaydet();
        }
    }
}