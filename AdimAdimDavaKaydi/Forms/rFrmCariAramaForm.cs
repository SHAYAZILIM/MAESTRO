using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class rFrmCariAramaForm : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public rFrmCariAramaForm()
        {
            InitializeComponent();
            InitializeEvents();
            ucCariAramaKriterler1.Sorgula += ucCariAramaKriterler1_Sorgula;
            ucCariAramaKriterler1.Temizle += ucCariAramaKriterler1_Temizle;
            ucCariArama1.KayitSilindi += ucCariArama1_KayitSilindi;
            this.Load += new EventHandler(rFrmCariAramaForm_Load);
        }

        //aykut hýzlandýrma 01.02.2013
        //private List<AvukatProLib.Arama.AV001_TDI_BIL_CARI> MyDataSource =
        //    new List<AvukatProLib.Arama.AV001_TDI_BIL_CARI>();
        //private List<AvukatProLib.Arama.AV001_TDI_BIL_CARI> secilenCariler =
        //    new List<AvukatProLib.Arama.AV001_TDI_BIL_CARI>();
        private DataTable MyDataSource = new DataTable();

        private DataTable secilenCariler = new DataTable();

        private TList<AV001_TDI_BIL_CARI> secilenCarilerim = new TList<AV001_TDI_BIL_CARI>();

        private AV001_TDI_BIL_CARI seciliCarim = new AV001_TDI_BIL_CARI();

        public void CariAramadaKaydet()
        {
            DialogResult dr =
                XtraMessageBox.Show(
                    "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler güncellenecektir" + Environment.NewLine +
                    "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
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

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += barButtonItem3_ItemClick;

            this.Button_Word_Click += barButtonItem3_ItemClick;
            this.Button_PDF_Click += barButtonItem21_ItemClick;
            this.Button_Outlook_Click += barButtonItem19_ItemClick;
            this.Button_Excel_Click += barButtonItem20_ItemClick;
            this.Button_Editor_Click += barButtonItem17_ItemClick;
            this.Button_Yeni_Click += yeni_CariKaydi_Ac;
        }

        private void barButtonItem17_ItemClick(object sender, EventArgs e)
        {
            frmEditor frmEdit = new frmEditor();
            frmEdit.MdiParent = mdiAvukatPro.MainForm;
            frmEdit.Show();
        }

        private void barButtonItem19_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pst);
        }

        private void barButtonItem20_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.xls);
        }

        private void barButtonItem21_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pdf);
        }

        private void barButtonItem3_ItemClick(object sender, EventArgs e)
        {
            //KAYDET
            CariAramadaKaydet();
        }

        private void rFrmCariAramaForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void ucCariArama1_KayitSilindi(object sender, EventArgs e)
        {
            ucCariAramaKriterler1.cariAramaSonuc();
            MyDataSource = ucCariAramaKriterler1.ArananCarilerim;
            ucCariArama1.MyDataSource = MyDataSource;
        }

        private void ucCariAramaKriterler1_Sorgula(object sender, EventArgs e)
        {
            //ARAMA SORGULA
            ucCariAramaKriterler1.cariAramaSonuc();
            MyDataSource = ucCariAramaKriterler1.ArananCarilerim;

            //AvukatProLib.AramaAV001_TDI_BIL_CARIProvider.DeepLoad(MyDataSource, true, DeepLoadType.IncludeChildren, typeof(TList<AvukatProLib.Arama.AV001_TDI_BIL_CARI_KIMLIK>));
            ucCariArama1.MyDataSource = MyDataSource;
        }

        private void ucCariAramaKriterler1_Temizle(object sender, EventArgs e)
        {
            MyDataSource = null;
            ucCariArama1.MyDataSource = MyDataSource;
        }

        private void yeni_CariKaydi_Ac(object sender, EventArgs e)
        {
            frmCariGenelGiris frmCariKaydet = new frmCariGenelGiris();
            frmCariKaydet.Show();
        }
    }
}