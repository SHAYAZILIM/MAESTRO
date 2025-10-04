using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmTespitKaydetForm : AvpXtraForm
    {
        public frmTespitKaydetForm()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private TList<AV001_TDI_BIL_TESPIT_TARAF> MyDataSourceTaraf = new TList<AV001_TDI_BIL_TESPIT_TARAF>();

        //TODO: KATMANDAN SONRA TARAF GRÝDÝ DEÐÝÞTÝRLCEK ... TABLDE da deðiþiklik yapýlacak ..
        private TList<AV001_TDI_BIL_TESPIT> MyDataSourceTespit = new TList<AV001_TDI_BIL_TESPIT>();

        public TList<AV001_TDI_BIL_TESPIT> MyDataSource
        {
            get { return ucTespitKaydet1.MyDataSource; }
            set
            {
                if (value != null)
                {
                    ucTespitKaydet1.MyDataSource = value;
                    if (ucTespitKaydet1.CurrentTespit != null)
                    {
                        ucTespitKaydet1.MySource = ucTespitKaydet1.CurrentTespit.AV001_TDI_BIL_TESPIT_TARAFCollection;
                    }

                    MyDataSource.ForEach(delegate(AV001_TDI_BIL_TESPIT h) { h.ColumnChanged += h_ColumnChanged; });
                }
            }
        }

        private void frmTespitKaydetForm_Button_Kaydet_Click(object sender, EventArgs e)
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

                    foreach (var item in ucTespitKaydet1.MySource)
                    {
                        MyDataSource[0].AV001_TDI_BIL_TESPIT_TARAFCollection.Add(item);
                    }

                    DataRepository.AV001_TDI_BIL_TESPITProvider.DeepSave(tran, MyDataSource);
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

        private void frmTespitKaydetForm_Load(object sender, EventArgs e)
        {
            if (ucTespitKaydet1.MyDataSource == null && ucTespitKaydet1.MySource == null)
            {
                ucTespitKaydet1.MyDataSource = new TList<AV001_TDI_BIL_TESPIT>();
                ucTespitKaydet1.MySource = new TList<AV001_TDI_BIL_TESPIT_TARAF>();
            }
        }

        private void h_ColumnChanged(object sender, AV001_TDI_BIL_TESPITEventArgs e)
        {
            //
            if (ucTespitKaydet1.CurrentTespit != null)
            {
                ucTespitKaydet1.MySource =
                    ucTespitKaydet1.CurrentTespit.AV001_TDI_BIL_TESPIT_TARAFCollection;
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmTespitKaydetForm_Button_Kaydet_Click;
        }
    }
}