using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmYapilcakIslerGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private TList<AV001_TDI_BIL_IS> _MyDataSource;

        public rFrmYapilcakIslerGirisEkran()
        {
            InitializeComponent();
            InitializeEvents();
        }

        //TList<AV001_TDI_BIL_IS> MyDataSource = new TList<AV001_TDI_BIL_IS>();
        public TList<AV001_TDI_BIL_IS> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                ucGorevGrid1.MyDataSource = value;
            }
        }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Editor_Click += barButtonItem22_ItemClick;
            this.Button_Excel_Click += barButtonItem25_ItemClick;
            this.Button_Outlook_Click += barButtonItem24_ItemClick;
            this.Button_PDF_Click += barButtonItem26_ItemClick;
            this.Button_Word_Click += barButtonItem23_ItemClick;
            this.Button_Kaydet_Click += btnKaydet_ItemClick;
        }

        public void YapilcakIsGetir()
        {
            MyDataSource = BelgeUtil.Inits.IsGetirTable();
        }

        public void YapilcakIsKaydet()
        {
            DialogResult dr =
                XtraMessageBox.Show(
                    "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine
                    + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.AV001_TDI_BIL_ISProvider.DeepSave(tran, MyDataSource);
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

        private void barButtonItem22_ItemClick(object sender, EventArgs e)
        {
            frmEditor frmEdit = new frmEditor();
            frmEdit.MdiParent = mdiAvukatPro.MainForm;
            frmEdit.Show();
        }

        private void barButtonItem23_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.doc);
        }

        private void barButtonItem24_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pst);
        }

        private void barButtonItem25_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.xls);
        }

        private void barButtonItem26_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pdf);
        }

        private void btnKaydet_ItemClick(object sender, EventArgs e)
        {
            //KAYDET
            YapilcakIsKaydet();
        }

        private void rFrmYapilcakIslerGirisEkran_Load(object sender, EventArgs e)
        {
            //LOAD
            YapilcakIsGetir();
            ucGorevGrid1.AramaDockPanel = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
        }

        private void ucGorevGrid1_Load(object sender, EventArgs e)
        {
        }
    }
}