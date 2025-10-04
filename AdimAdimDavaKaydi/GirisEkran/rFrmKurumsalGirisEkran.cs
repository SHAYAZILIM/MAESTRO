using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util;
using AvukatProLib.Util;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmKurumsalGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        //private VList<R_BIRLESIK_TAKIPLER_TUMU_TEXT> MyDataSource = new VList<R_BIRLESIK_TAKIPLER_TUMU_TEXT>();

        public rFrmKurumsalGirisEkran()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
        }

        private void KontrolAra(System.Windows.Forms.Control.ControlCollection ce)
        {
            foreach (Control cnt in ce)
            {
                if (cnt is IButtonControl || cnt is PictureBox)
                {
                    string Isim = this.GetType().FullName;
                    AuthHelper hlp = AuthHelper.GetAuthHelper(Isim, cnt.Name);
                    if (hlp != null && !hlp.FormAcabilir)
                    {
                        hlp.FormAcabilir = false;
                        hlp.MenuGorebilir = false;
                        hlp.MenuTiklayabilir = false;
                        cnt.Enabled = false;
                        cnt.Visible = false;
                    }
                }
                KontrolAra(cnt.Controls);
            }
        }

        private void KontrolTara(System.Windows.Forms.Control.ControlCollection cs)
        {
            foreach (Control con in cs)
            {
                if (con is IButtonControl)
                    AuthHelperBase.ApplyAuthorization(this.GetType().FullName, con.Name, con.Text);
                else if (con is PictureBox)
                    AuthHelperBase.ApplyAuthorization(this.GetType().FullName, con.Name, con.Name);

                KontrolTara(con.Controls);
            }
        }

        private void rFrmKurumsalGirisEkran_Load(object sender, EventArgs e)
        {
            KontrolTara(this.Controls);
            if (AvukatProLib.Kimlik.Bilgi != null)
            {
                KontrolAra(this.Controls);
            }
            panel1.Top = (this.Height - panel1.Height) / 2;
            panel1.Left = (this.Width - panel1.Width) / 2;

            this.TopMost = false;
        }

        private void rFrmKurumsalGirisEkran_Resize(object sender, EventArgs e)
        {
            panel1.Top = (Screen.PrimaryScreen.WorkingArea.Height - panel1.Height) / 2;
            panel1.Left = (Screen.PrimaryScreen.WorkingArea.Width - panel1.Width) / 2;
        }

        private void sBtnBelgeYonetimi_Click_1(object sender, EventArgs e)
        {
            if (!FormHelperII.FormAc(AramaFormlari.BELGE_GIRIS, false))
            {
                XtraMessageBox.Show(
                    "Arama formlarýnýn maximum sayýsý aþýlmýþ, Lütfen yeni form açmak için açýk olanlardan birini kapatýnýz",
                    "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sBtnBuroYonetimi_Click_1(object sender, EventArgs e)
        {
            if (!FormHelperII.FormAc(AramaFormlari.BURO_YONETIMI, false))
            {
                XtraMessageBox.Show(
                    "Arama formlarýnýn maximum sayýsý aþýlmýþ, Lütfen yeni form açmak için açýk olanlardan birini kapatýnýz",
                    "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sBtnDavaYonetimi_Click_1(object sender, EventArgs e)
        {
            if (!FormHelperII.FormAc(AramaFormlari.DAVA_GIRIS, false))
            {
                XtraMessageBox.Show(
                    "Arama formlarýnýn maximum sayýsý aþýlmýþ, Lütfen yeni form açmak için açýk olanlardan birini kapatýnýz",
                    "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sBtnEditor_Click_1(object sender, EventArgs e)
        {
            if (!FormHelperII.FormAc(AramaFormlari.EDITOR_GIRIS, false))
            {
                XtraMessageBox.Show(
                    "Arama formlarýnýn maximum sayýsý aþýlmýþ, Lütfen yeni form açmak için açýk olanlardan birini kapatýnýz",
                    "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sBtnGelenGidenEvrak_Click(object sender, EventArgs e)
        {
            if (!FormHelperII.FormAc(AramaFormlari.GELEN_GIDEN_EVRAK, false))
            {
                XtraMessageBox.Show(
                    "Arama formlarýnýn maximum sayýsý aþýlmýþ, Lütfen yeni form açmak için açýk olanlardan birini kapatýnýz",
                    "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sBtnHukukMuhasebesi_Click_1(object sender, EventArgs e)
        {
            if (!FormHelperII.FormAc(AramaFormlari.HUKUK_MUHASEBESI, false))
            {
                XtraMessageBox.Show(
                    "Arama formlarýnýn maximum sayýsý aþýlmýþ, Lütfen yeni form açmak için açýk olanlardan birini kapatýnýz",
                    "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sBtnIcraYonetimi_Click_1(object sender, EventArgs e)
        {
            if (!FormHelperII.FormAc(AramaFormlari.ICRA_GIRIS, false))
            {
                XtraMessageBox.Show(
                    "Arama formlarýnýn maximum sayýsý aþýlmýþ, Lütfen yeni form açmak için açýk olanlardan birini kapatýnýz",
                    "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sBtnProjeYonetimi_Click_1(object sender, EventArgs e)
        {
            if (!FormHelperII.FormAc(AramaFormlari.PROJE_YONETIMI, false))
            {
                XtraMessageBox.Show(
                    "Arama formlarýnýn maximum sayýsý aþýlmýþ, Lütfen yeni form açmak için açýk olanlardan birini kapatýnýz",
                    "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sBtnSorusturmaYonetimi_Click_1(object sender, EventArgs e)
        {
            if (!FormHelperII.FormAc(AramaFormlari.SORUSTURMA_GIRIS, false))
            {
                XtraMessageBox.Show(
                    "Arama formlarýnýn maximum sayýsý aþýlmýþ, Lütfen yeni form açmak için açýk olanlardan birini kapatýnýz",
                    "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sBtnSozlesmeYonetimi_Click_1(object sender, EventArgs e)
        {
            if (!FormHelperII.FormAc(AramaFormlari.SOZLESME_GIRIS, false))
            {
                XtraMessageBox.Show(
                    "Arama formlarýnýn maximum sayýsý aþýlmýþ, Lütfen yeni form açmak için açýk olanlardan birini kapatýnýz",
                    "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sBtnTumDosyalar_Click_1(object sender, EventArgs e)
        {
            Forms.rFrmTumDosyalar frmTumDosya = new AdimAdimDavaKaydi.Forms.rFrmTumDosyalar();
            frmTumDosya.Show();
        }

        private void sBtnYapilacakIsler_Click(object sender, EventArgs e)
        {
            if (!FormHelperII.FormAc(AramaFormlari.GOREV_GIRIS, false))
            {
                XtraMessageBox.Show(
                    "Arama formlarýnýn maximum sayýsý aþýlmýþ, Lütfen yeni form açmak için açýk olanlardan birini kapatýnýz",
                    "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}