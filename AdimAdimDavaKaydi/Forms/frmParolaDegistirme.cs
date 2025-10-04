using AvukatProLib2.Data;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmParolaDegistirme : DevExpress.XtraEditors.XtraForm
    {
        public frmParolaDegistirme()
        {
            InitializeComponent();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            if (txtEskiParola.Text != AvukatProLib.Kimlik.Bilgi.KULLANICI_SIFRESI)
            {
                XtraMessageBox.Show("Eski Parola yanl�� l�tfen kontrol ederek tekrar deneyiniz.", "Hata",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEskiParola.Focus();
                txtEskiParola.SelectionStart = 0;
                txtEskiParola.SelectionLength = txtEskiParola.Text.Length;
                return;
            }

            //Kullan�c� parolas� do�ru �imdi di�er parolalar� kar��la�t�r�yoruz
            if (txtYeniParola1.Text != txtYeniParola2.Text)
            {
                XtraMessageBox.Show("Yeni parola do�rulamas� yanl�� l�tfen kontrol ederek tekrar deneyiniz.", "Hata",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtYeniParola2.Focus();
                txtYeniParola2.SelectionStart = 0;
                txtYeniParola2.SelectionLength = txtYeniParola2.Text.Length;
                return;
            }

            //if (txtYeniParola1.Text.Length < 5)
            //{
            //    XtraMessageBox.Show("Parola en az 5 karakterli olmal�d�r. L�tfen kontrol ederek tekrar deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtYeniParola1.Focus();
            //    txtYeniParola1.SelectionStart = 0;
            //    txtYeniParola1.SelectionLength = txtYeniParola1.Text.Length;
            //    return;
            //}
            if (!Util.AuthHelper.PasswordControl(txtYeniParola1.Text, true))
            {
                txtYeniParola1.Focus();
                txtYeniParola1.SelectionStart = 0;
                txtYeniParola1.SelectionLength = txtYeniParola1.Text.Length;
                return;
            }

            using (TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr))
            {
                try
                {
                    AvukatProLib.Kimlik.Bilgi.KULLANICI_SIFRESI = txtYeniParola1.Text;
                    tran.BeginTransaction();
                    DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.Save(tran, AvukatProLib.Kimlik.Bilgi);
                    tran.Commit();
                    XtraMessageBox.Show(
                        "Parola de�i�ikli�i ba�ar�yla yap�ld�." + Environment.NewLine +
                        "Bir sonraki giri�inizde yeni parolan�z ile ba�lanman�z gerekecektir.", "Ba�ar�l�",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen)
                        tran.Rollback();
                    XtraMessageBox.Show("��lem ger�ekle�tirilirken bir hata ile kar��la��ld�.", "Ba�ar�s�z",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BelgeUtil.ErrorHandler.Catch(this, ex, BelgeUtil.Bilesen.BilesenYok);
                }
            }
        }

        private void frmParolaDegistirme_Load(object sender, EventArgs e)
        {
            txtKullaniciAdi.Text = AvukatProLib.Kimlik.Bilgi.KULLANICI_ADI;

            //MessageBox.Show("Debug modda parola de�i�ikli�i yap�lamamaktad�r.");
            //this.DialogResult = DialogResult.Cancel;
        }
    }
}