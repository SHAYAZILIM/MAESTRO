using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmSikKullanilanDuzenle : Form
    {
        public frmSikKullanilanDuzenle()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> Yenile;

        [Browsable(false)]
        public AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI MyKategori { get; set; }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (MyKategori != null)
            {
                MyKategori.ADI = txtKategori.Text;

                TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                try
                {
                    trans.BeginTransaction();
                    DataRepository.AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORIProvider.Update(trans, MyKategori);
                    XtraMessageBox.Show("Kayıt işlemi başarı ile gerçekleştirildi.", "BİLGİ", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    trans.Commit();
                    if (Yenile != null)
                        Yenile(this, new EventArgs());
                    this.Close();
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Kayıt işlemi gerçekleştirilemedi.", "HATA", MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                }
                finally
                {
                    trans.Dispose();
                }
            }
        }

        private void frmSikKullanilanDuzenle_Load(object sender, EventArgs e)
        {
            if (MyKategori != null)
                txtKategori.Text = MyKategori.ADI;
        }
    }
}