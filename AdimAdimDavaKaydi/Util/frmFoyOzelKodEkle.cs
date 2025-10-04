using System;
using System.Windows.Forms;
using AvukatProLib;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using AvukatPro.Model.EntityClasses;

namespace AdimAdimDavaKaydi.Util
{
    public partial class frmFoyOzelKodEkle : Form
    {
        #region Fields

        public bool Davadan;
        public bool Icradan;
        public bool Sorusturmadan;
        public bool sozlesmeden;

        #endregion Fields

        #region Constructors

        public frmFoyOzelKodEkle()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        public Av001TdiKodFoyOzelEntity MyOzelKod
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public DialogResult ShowDialog(byte alanNo, string ozelKodIsmi)
        {
            txtOzelKod.Text = ozelKodIsmi;
            Ozellestirme();
            switch (alanNo)
            {
                case 1:
                    chkOzelKod1.Checked = true;
                    break;
                case 2:
                    chkOzelKod2.Checked = true;
                    break;
                case 3:
                    chkOzelKod3.Checked = true;
                    break;
                case 4:
                    chkOzelKod4.Checked = true;
                    break;
                default:
                    break;
            }

            return this.ShowDialog();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtOzelKod.Text))
                {
                    Av001TdiKodFoyOzelEntity ozelKod = new Av001TdiKodFoyOzelEntity();
                    ozelKod.Alan1 = chkOzelKod1.Checked;
                    ozelKod.Alan2 = chkOzelKod2.Checked;
                    ozelKod.Alan3 = chkOzelKod3.Checked;
                    ozelKod.Alan4 = chkOzelKod4.Checked;
                    ozelKod.Dava = chkDava.Checked;
                    ozelKod.Icra = chkIcra.Checked;
                    ozelKod.Hazirlik = chkHazirlik.Checked;
                    ozelKod.Sozlesme = chkSozlesme.Checked;
                    ozelKod.IlamMahkemesi = chkIlam.Checked;
                    ozelKod.Tebligat = chkEvrak.Checked;
                    ozelKod.Belge = chkBelge.Checked;
                    ozelKod.Gorusme = chkGorusme.Checked;
                    ozelKod.Kod = txtOzelKod.Text;
                    ozelKod.Proje = chkProje.Checked;

                    if (DataRepository.AV001_TDI_KOD_FOY_OZELProvider.GetByKOD(ozelKod.Kod) != null)
                    {
                        MessageBox.Show("Girmiþ Olduðunuz Özel Kod Zaten Kayýtlý.");
                        return;
                    }

                    ozelKod.Save();
                    MyOzelKod = ozelKod;
                    MessageBox.Show("Özel kod baþarýyla kaydedildi.");
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Özel Kod Alanýný Boþ Geçmeyiniz");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayýt esnasýnda bir hata ile karþýlaþýldý");
                BelgeUtil.ErrorHandler.Catch(this, ex, BelgeUtil.Bilesen.Dava, BelgeUtil.Bilesen.Icra, BelgeUtil.Bilesen.Sorusturma, BelgeUtil.Bilesen.Sozlesme);
            }
        }

        private void chkDava_MouseHover(object sender, EventArgs e)
        {
            chkOzelKod1.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod1;
            chkOzelKod2.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod2;
            chkOzelKod3.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod3;
            chkOzelKod4.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod4;
        }

        private void chkHazirlik_MouseHover(object sender, EventArgs e)
        {
            chkOzelKod1.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod1;
            chkOzelKod2.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod2;
            chkOzelKod3.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod3;
            chkOzelKod4.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod4;
        }

        private void chkIcra_MouseHover(object sender, EventArgs e)
        {
            chkOzelKod1.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod1;
            chkOzelKod2.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod2;
            chkOzelKod3.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod3;
            chkOzelKod4.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod4;
        }

        private void chkSozlesme_MouseHover(object sender, EventArgs e)
        {
            chkOzelKod1.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod1;
            chkOzelKod2.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod2;
            chkOzelKod3.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod3;
            chkOzelKod4.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod4;
        }

        private void frmFoyOzelKodEkle_Load(object sender, EventArgs e)
        {
            if (MyOzelKod != null)
                BindOzelKodToForm(MyOzelKod);
        }

        private void BindOzelKodToForm(Av001TdiKodFoyOzelEntity ozelKod)
        {
            chkOzelKod1.Checked = ozelKod.Alan1;
            chkOzelKod2.Checked = ozelKod.Alan2;
            chkOzelKod3.Checked = ozelKod.Alan3;
            chkOzelKod4.Checked = ozelKod.Alan4;
            chkDava.Checked = ozelKod.Dava;
            chkIcra.Checked = ozelKod.Icra;
            chkHazirlik.Checked = ozelKod.Hazirlik;
            chkSozlesme.Checked = ozelKod.Sozlesme;
            chkIlam.Checked = ozelKod.IlamMahkemesi;
            chkEvrak.Checked = ozelKod.Tebligat;
            chkBelge.Checked = ozelKod.Belge;
            chkGorusme.Checked = ozelKod.Gorusme;
            chkProje.Checked = ozelKod.Proje;
            txtOzelKod.Text = ozelKod.Kod;
        }

        private void grpModul_MouseHover(object sender, EventArgs e)
        {
            chkOzelKod1.Text = "Özel Kod 1";
            chkOzelKod2.Text = "Özel Kod 2";
            chkOzelKod3.Text = "Özel Kod 3";
            chkOzelKod4.Text = "Özel Kod 4";
        }

        private void Ozellestirme()
        {
            chkIcra.Checked = Icradan;
            chkDava.Checked = Davadan;
            chkSozlesme.Checked = sozlesmeden;
            chkHazirlik.Checked = Sorusturmadan;
            if (Icradan)
            {
                chkOzelKod1.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod1;
                chkOzelKod2.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod2;
                chkOzelKod3.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod3;
                chkOzelKod4.Text = Kimlikci.Kimlik.IcraOzelKod.OzelKod4;
            }
            else if (Davadan)
            {
                chkOzelKod1.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod1;
                chkOzelKod2.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod2;
                chkOzelKod3.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod3;
                chkOzelKod4.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod4;
            }
            else if (Sorusturmadan)
            {
                chkOzelKod1.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod1;
                chkOzelKod2.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod2;
                chkOzelKod3.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod3;
                chkOzelKod4.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod4;
            }
            else if (sozlesmeden)
            {
                chkOzelKod1.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod1;
                chkOzelKod2.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod2;
                chkOzelKod3.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod3;
                chkOzelKod4.Text = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod4;
            }
        }

        #endregion Methods
    }
}