using AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmTopluIcraHesapla : DevExpress.XtraEditors.XtraForm
    {
        public frmTopluIcraHesapla()
        {
            InitializeComponent();
            ExInitializeComponent();
            InitializeEvents();
        }

        #region Events

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            if (!bwHesabaBasla.IsBusy)
            {
                progressBarControl1.Properties.Maximum = MyCollection.Count;
                bwHesabaBasla.RunWorkerAsync(MyCollection);
                btnHesapla.Enabled = false;
            }
            else
                MessageBox.Show("Ýþlem Devam Ediyor", "Dikkat..!");
        }

        private void bwHesabaBasla_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument != null &&
                e.Argument is List<HesaplananIcraDosyasi>)
            {
                List<HesaplananIcraDosyasi> liste = e.Argument as List<HesaplananIcraDosyasi>;

                int i = 0;
                foreach (HesaplananIcraDosyasi dosya in liste)
                {
                    try
                    {
                        var mFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(dosya.FoyId);
                        Hesap.Icra hy = new Hesap.Icra(mFoy);

                        dosya.Foy = mFoy;
                        dosya.Durum = true;
                        if (KayitYapilsin)
                        {
                            TransactionManager tm = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                            try
                            {
                                tm.BeginTransaction();
                                DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(tm, dosya.Foy);
                                tm.Commit();
                                ObjectDisposing.DisposeObject(dosya.Foy);
                            }
                            catch (Exception ex)
                            {
                                if (tm.IsOpen)
                                    tm.Rollback();
                                dosya.Aciklama += "Kayýt Hatasý";
                                dosya.Aciklama += Environment.NewLine;
                                dosya.Aciklama += "____________";
                                dosya.Aciklama += Environment.NewLine;
                                dosya.Aciklama += ex.Message;
                                dosya.Aciklama += Environment.NewLine;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        dosya.Aciklama += "Hesap Hatasý";
                        dosya.Aciklama += Environment.NewLine;
                        dosya.Aciklama += "____________";
                        dosya.Aciklama += Environment.NewLine;
                        dosya.Aciklama += ex.Message;
                        dosya.Aciklama += Environment.NewLine;
                    }

                    i++;
                    bwHesabaBasla.ReportProgress(i);
                }

                e.Result = liste;
            }
        }

        private void bwHesabaBasla_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarControl1.EditValue = e.ProgressPercentage;

            //progressBarControl1.Properties.Step = e.ProgressPercentage;
        }

        private void bwHesabaBasla_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null &&
                e.Result is List<HesaplananIcraDosyasi>)
            {
                gridControl1.DataSource = e.Result;
            }
            btnHesapla.Enabled = true;
        }

        private void ceKaydet_CheckedChanged(object sender, EventArgs e)
        {
            KayitYapilsin = ceKaydet.Checked;
        }

        private void frmTopluIcraHesapla_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = MyCollection;
        }

        private void InitializeEvents()
        {
            this.Load += frmTopluIcraHesapla_Load;
            bwHesabaBasla.DoWork += bwHesabaBasla_DoWork;
            bwHesabaBasla.RunWorkerCompleted += bwHesabaBasla_RunWorkerCompleted;
            bwHesabaBasla.ProgressChanged += bwHesabaBasla_ProgressChanged;
            btnHesapla.Click += btnHesapla_Click;
        }

        #endregion Events

        #region Methots

        private BackgroundWorker bwHesabaBasla = new BackgroundWorker();

        public void ShowDialog(List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA> foyListesi)
        {
            MyCollection = HesaplananIcraDosyasi.GetCollection(foyListesi);

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.ShowDialog();
        }

        public void ShowDialog(List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> foyListesi)
        {
            MyCollection = HesaplananIcraDosyasi.GetCollection(foyListesi);

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.ShowDialog();
        }

        private void ExInitializeComponent()
        {
            bwHesabaBasla.WorkerReportsProgress = true;
            bwHesabaBasla.WorkerSupportsCancellation = true;

            KayitYapilsin = ceKaydet.Checked;
        }

        #endregion Methots

        #region Properties

        public bool KayitYapilsin { get; set; }

        public List<HesaplananIcraDosyasi> MyCollection { get; set; }

        #endregion Properties
    }

    public class HesaplananIcraDosyasi
    {
        #region Constructor
        
        public HesaplananIcraDosyasi(AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA foy)
        {
            FoyId = foy.ID;
            FoyNo = foy.FOY_NO;
            Foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(foy.ID);
        }

        public HesaplananIcraDosyasi(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama foy)
        {
            FoyId = foy.ID;
            FoyNo = foy.FOY_NO;
            Foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(foy.ID);
        }

        #endregion Constructor

        #region Properties

        public string Aciklama { get; set; }

        public bool Durum { get; set; }

        public AV001_TI_BIL_FOY Foy { get; set; }

        public int FoyId { get; set; }

        public string FoyNo { get; set; }

        #endregion Properties

        #region Methots

        public static List<HesaplananIcraDosyasi> GetCollection(List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA> foyListesi)
        {
            List<HesaplananIcraDosyasi> liste = new List<HesaplananIcraDosyasi>();
            foreach (AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA foy in foyListesi)
            {
                liste.Add(new HesaplananIcraDosyasi(foy));
            }

            return liste;
        }

        public static List<HesaplananIcraDosyasi> GetCollection(List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> foyListesi)
        {
            List<HesaplananIcraDosyasi> liste = new List<HesaplananIcraDosyasi>();
            foreach (AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama foy in foyListesi)
            {
                liste.Add(new HesaplananIcraDosyasi(foy));
            }

            return liste;
        }

        #endregion Methots
    }
}