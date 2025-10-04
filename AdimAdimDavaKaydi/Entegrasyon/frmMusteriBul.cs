using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Entegrasyon
{
    public partial class frmMusteriBul : Form
    {
        public frmMusteriBul()
        {
            InitializeComponent();
        }

        public frmMusteriBul(string customerName, string customerNumber)
        {
            this.Musteri = customerName;
            this.MusteriNo = customerNumber;
            InitializeComponent();
        }

        public int CariID { get; set; }

        public string Musteri { get; set; }

        public string MusteriNo { get; set; }

        public void Show(string musteri)
        {
            this.Musteri = musteri;

            this.Show();
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult dr = (sender as frmCariGenelGiris).KayitBasarili;
            if (dr == DialogResult.OK)
            {
                BelgeUtil.Inits.perCariGetirKimlikIletisim(lueMusteri);
                lueMusteri.EditValue = (sender as frmCariGenelGiris).MyCari.ID;
            }
        }

        private void frmMusteriBul_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.perCariGetirKimlikIletisim(lueMusteri);

            txtUyari.Text = string.Format("{0} isimli kişiyi aşağıdaki listeden bulunuz.\r\n{0} isimli kişi listede yok ise ismi yazıp listedeki + tuşuna basarak kişiyi sisteme ekleyebilirsiniz.", Musteri);
        }

        private void lueMusteri_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null) return;
            if (e.Button.Tag is int && (int)e.Button.Tag == 1)
            {
                frmCariGenelGiris frm = new frmCariGenelGiris();
                frm.tmpCariAd = lueMusteri.Text;
                frm.MusteriNo = MusteriNo;
                frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                frm.ShowDialog();
            }
        }

        private void sbtnSec_Click(object sender, EventArgs e)
        {
            if (lueMusteri.EditValue == null)
                MessageBox.Show("Müşteri Seçimi Yapınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            {
                CariID = (int)lueMusteri.EditValue;

                this.Close();
            }
        }
    }
}