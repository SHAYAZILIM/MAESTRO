using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AdimAdimDavaKaydi.Forms.Dava;
using AdimAdimDavaKaydi.Forms.LayForm;
using AdimAdimDavaKaydi.Sozlesme.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using AdimAdimDavaKaydi.Generalclass.Forms;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucKurumsalGirisEkraniLayout : DevExpress.XtraEditors.XtraUserControl
    {
        #region <MB-20091203> LOAD

        public List<AvukatProLib.Hesap.Views.ProjeBirlesikTakiplerTumu> MyDataSource =
            new List<AvukatProLib.Hesap.Views.ProjeBirlesikTakiplerTumu>();

        public ucKurumsalGirisEkraniLayout()
        {
            InitializeComponent();
        }

        private BackgroundWorker bwSikKullanilanlar = new BackgroundWorker();
        private BackgroundWorker bwIsler = new BackgroundWorker();

        private void ucKurumsalGirisEkraniLayout_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                //glueAdi.Properties.NullText = "Seç";
                //aykut hızlandırma 23.01.2013
                //glueAdi.Enter += delegate { BelgeUtil.Inits.perCariGetirKimlikIletisim(glueAdi); };

                //BelgeUtil.Inits.KurumsalGirisFormTipi(lueForm.Properties);
                lcItemSahsinDetayliRaporu.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        #endregion

        #region <MB-20091219> ARAMA İŞLEMLERİ

        private void sbtnGelismisAramaEkraniAc_Click(object sender, EventArgs e)
        {
            //this.Close();
            rFrmTumDosyalar tumDosyalarGelismis = new rFrmTumDosyalar();
            tumDosyalarGelismis.Show();
        }

        private void sbtnTumModullerdeArama_Click(object sender, EventArgs e)
        {
            int? kullaniciID = null;
            if (glueAdi.EditValue != null)
                kullaniciID = (int?)glueAdi.EditValue;
            string dosyaNo = txtDosyaNo.Text;
            string esasNo = txtEsasNo.Text;

            //Arama işleminden önce içerikler temizleniyor. MB
            glueAdi.EditValue = null;
            txtDosyaNo.Text = string.Empty;
            txtEsasNo.Text = string.Empty;

            AdimAdimDavaKaydi.Forms.Genel.frmTumDosyalardaArama arama =
                new AdimAdimDavaKaydi.Forms.Genel.frmTumDosyalardaArama();
            arama.Show(kullaniciID, dosyaNo, esasNo);
        }

        private void txtEsasNo_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEsasNo.Text))
            {
                glueAdi.Enabled = true;
                txtDosyaNo.Enabled = true;
            }
            else
            {
                glueAdi.Enabled = false;
                txtDosyaNo.Enabled = false;
            }
            lcItemSahsinDetayliRaporu.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void txtDosyaNo_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDosyaNo.Text))
            {
                glueAdi.Enabled = true;
                txtEsasNo.Enabled = true;
            }
            else
            {
                glueAdi.Enabled = false;
                txtEsasNo.Enabled = false;
            }

            lcItemSahsinDetayliRaporu.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void sbtnSahsinRaporunuGetir_Click(object sender, EventArgs e)
        {
            int cariId;
            if (glueAdi.EditValue != null)
            {
                cariId = (int)glueAdi.EditValue;

                AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(cariId);
                AdimAdimDavaKaydi.CariTakipForms.Forms.frmCariTakipForm cariForms =
                    new AdimAdimDavaKaydi.CariTakipForms.Forms.frmCariTakipForm();
                cariForms.Show(cari);
            }
        }

        #endregion

        #region <MB-20091203> KAYIT FORMLARININ AÇILMASI

        private void sbtnIcraDosyasiEkle_Click(object sender, EventArgs e)
        {
            mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.IcraDosyaKayit);
        }

        private void sbtnDavaDosyasiEkle_Click(object sender, EventArgs e)
        {
            mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.DavaDosyaKayitForm);
        }

        private void sbtnSorusturmaDosyasiEkle_Click(object sender, EventArgs e)
        {
            mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.SorusturmaGiris);
        }

        private void sbtnSozlesmeEkle_Click(object sender, EventArgs e)
        {
            frmSozlesmeKayitLayout loyut = new frmSozlesmeKayitLayout();
            loyut.Show();
            //mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.SozlesmeKayit);
        }

        private void sbtnKlasorEkle_Click(object sender, EventArgs e)
        {
            frmYeniKlasor frm = new frmYeniKlasor();
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show();
            frm.FormClosed += delegate
            {
                AV001_TDIE_BIL_PROJE prj = frm.YeniKlasorGetir();
                if (prj != null)
                {
                    prj.SUBE_KOD_ID = AdimAdimDavaKaydi.Forms.frmKlasorYeni.KullaniciSubeIDGetir(prj.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Find(vi => !vi.YETKILI_MI.Value).CARI_ID);
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepSave(prj);
                }
            };
        }

        private void sbtnEditoruAc_Click(object sender, EventArgs e)
        {
            frmEditor editor = new frmEditor();
            editor.TakipEkranidan = false;
            editor.MdiParent = mdiAvukatPro.MainForm;
            editor.Show();
            editor.beklemePaneli.Visible = false;
        }

        private void sbtnAjandamiAc_Click(object sender, EventArgs e)
        {
            Ajanda.Forms.MainForms.frmAjanda ajanda = new AdimAdimDavaKaydi.Ajanda.Forms.MainForms.frmAjanda();
            ajanda.Show();
        }

        //private void lueForm_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueForm.EditValue != null)
        //    {
        //        if (Convert.ToInt32(lueForm.EditValue) == (int)AvukatProLib.Extras.EkspressIslemler.Belge_B)
        //            mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.BelgeKayitUfak);
        //        else if (Convert.ToInt32(lueForm.EditValue) == (int)AvukatProLib.Extras.EkspressIslemler.Tebligat_Z)
        //        {
        //            frmLayTabligatKayit evrakKaydi = new frmLayTabligatKayit();
        //            evrakKaydi.StartPosition = FormStartPosition.WindowsDefaultLocation;
        //            evrakKaydi.Show();
        //        }
        //        else if (Convert.ToInt32(lueForm.EditValue) == (int)AvukatProLib.Extras.EkspressIslemler.Masraf_M)
        //        {
        //            IcraTakipForms.frmMasrafAvansKayitHizli masraf = new IcraTakipForms.frmMasrafAvansKayitHizli();
        //            // masraf.MdiParent = null;
        //            masraf.StartPosition = FormStartPosition.WindowsDefaultLocation;
        //            masraf.AcilisYeri = AdimAdimDavaKaydi.IcraTakipForms.MasrafFormuAcilisiYeri.TakipEkraniDisinda;
        //            masraf.Show();
        //        }
        //        else if (Convert.ToInt32(lueForm.EditValue) == (int)AvukatProLib.Extras.EkspressIslemler.Not_N)
        //        {
        //            Is.Forms.frmIsKayitUfak notlar = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
        //            //notlar.MdiParent = null;
        //            notlar.StartPosition = FormStartPosition.WindowsDefaultLocation;
        //            notlar.Show();
        //        }
        //        else if (Convert.ToInt32(lueForm.EditValue) == (int)AvukatProLib.Extras.EkspressIslemler.Toplantı_T)
        //        {
        //            Is.Forms.frmIsKayitUfak toplanti = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
        //            //toplanti.MdiParent = null;
        //            toplanti.StartPosition = FormStartPosition.WindowsDefaultLocation;
        //            toplanti.Show();
        //        }
        //        else if (Convert.ToInt32(lueForm.EditValue) == (int)AvukatProLib.Extras.EkspressIslemler.Duruşma_J)
        //        {
        //            rFrmCelseKayit durusma = new rFrmCelseKayit();
        //            // durusma.MdiParent = null;
        //            durusma.StartPosition = FormStartPosition.WindowsDefaultLocation;
        //            durusma.IsModul = true;
        //            durusma.Show();
        //        }
        //        else if (Convert.ToInt32(lueForm.EditValue) == (int)AvukatProLib.Extras.EkspressIslemler.AraKarar_A)
        //        {
        //            rfrmAraKararKayit araKarar = new rfrmAraKararKayit();
        //            //araKarar.MdiParent = null;
        //            araKarar.StartPosition = FormStartPosition.WindowsDefaultLocation;
        //            araKarar.IsModul = true;
        //            araKarar.Show();
        //        }
        //        else if (Convert.ToInt32(lueForm.EditValue) ==
        //                 (int)AvukatProLib.Extras.EkspressIslemler.Keşif_İnceleme_K)
        //        {
        //            rFrmCelseKayit kesifInceleme = new rFrmCelseKayit();
        //            //kesifInceleme.MdiParent = null;
        //            kesifInceleme.StartPosition = FormStartPosition.WindowsDefaultLocation;
        //            kesifInceleme.IsModul = true;
        //            kesifInceleme.Show();
        //        }
        //        else if (Convert.ToInt32(lueForm.EditValue) == (int)AvukatProLib.Extras.EkspressIslemler.Haciz_H)
        //        {
        //            Forms.Icra.frmHacizGirisi hacizEkle = new AdimAdimDavaKaydi.Forms.Icra.frmHacizGirisi();
        //            //hacizEkle.MdiParent = null;
        //            hacizEkle.StartPosition = FormStartPosition.WindowsDefaultLocation;
        //            hacizEkle.IsModul = true;
        //            hacizEkle.Show();
        //        }
        //        else if (Convert.ToInt32(lueForm.EditValue) == (int)AvukatProLib.Extras.EkspressIslemler.Satış_S)
        //        {
        //            Forms.Icra.frmSatisGirisi satisEkle = new AdimAdimDavaKaydi.Forms.Icra.frmSatisGirisi();
        //            // satisEkle.MdiParent = null;
        //            satisEkle.StartPosition = FormStartPosition.WindowsDefaultLocation;
        //            satisEkle.IsModul = true;
        //            satisEkle.Show();
        //        }
        //        else if (Convert.ToInt32(lueForm.EditValue) == (int)AvukatProLib.Extras.EkspressIslemler.Ödeme_O)
        //        {
        //            IcraTakipForms.rFrmTarafOdeme odeme = new AdimAdimDavaKaydi.IcraTakipForms.rFrmTarafOdeme();
        //            // odeme.MdiParent = null;
        //            odeme.StartPosition = FormStartPosition.WindowsDefaultLocation;
        //            odeme.IsModul = true;
        //            odeme.Show();
        //        }
        //        else if (Convert.ToInt32(lueForm.EditValue) == (int)AvukatProLib.Extras.EkspressIslemler.İş_I)
        //        {
        //            Is.Forms.frmIsKayitUfak isKayıt = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
        //            //isKayıt.MdiParent = null;
        //            isKayıt.StartPosition = FormStartPosition.WindowsDefaultLocation;
        //            isKayıt.Show();
        //        }
        //        else if (Convert.ToInt32(lueForm.EditValue) == (int)AvukatProLib.Extras.EkspressIslemler.Görüşme_F)
        //        {
        //            Forms.rFrmGorusmeKayit gorusme = new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();
        //            // gorusme.MdiParent = null;
        //            gorusme.StartPosition = FormStartPosition.WindowsDefaultLocation;
        //            gorusme.IsModul = true;
        //            gorusme.Show();
        //        }
        //        else if (Convert.ToInt32(lueForm.EditValue) ==
        //                 (int)AvukatProLib.Extras.EkspressIslemler.Müvekkile_Ödeme_D)
        //        {
        //            IcraTakipForms.frmMuvekkilOdemeleriLayout muvekkilOdeme =
        //                new AdimAdimDavaKaydi.IcraTakipForms.frmMuvekkilOdemeleriLayout();

        //            muvekkilOdeme.TakipEkraniDisinda = true;
        //            //muvekkilOdeme.MdiParent = null;
        //            muvekkilOdeme.StartPosition = FormStartPosition.WindowsDefaultLocation;
        //            muvekkilOdeme.Show();
        //        }
        //        else if (Convert.ToInt32(lueForm.EditValue) ==
        //                 (int)AvukatProLib.Extras.EkspressIslemler.Vekalet_V)
        //            mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.TemsilKayit);
        //    }
        //}

        private void sbtnSikKullandiklarim_Click(object sender, EventArgs e)
        {
            Forms.rfrmSikKullanilanlar frm = new rfrmSikKullanilanlar();
            // sikKullanilanlar.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show();
        }

        private void sbtnIsEmri_Click(object sender, EventArgs e)
        {
            Is.Forms.frmIsKayitUfak isKayıt = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
            isKayıt.StartPosition = FormStartPosition.WindowsDefaultLocation;
            isKayıt.Show();
        }

        private void glueAdi_EditValueChanged(object sender, EventArgs e)
        {
            if (glueAdi.EditValue == null)
            {
                txtDosyaNo.Enabled = true;
                txtEsasNo.Enabled = true;
            }
            else
            {
                txtDosyaNo.Enabled = false;
                txtEsasNo.Enabled = false;
            }
            lcItemSahsinDetayliRaporu.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void sbtnTemizle_Click(object sender, EventArgs e)
        {
            glueAdi.EditValue = null;
        }

        private void btnVekalet_Click(object sender, EventArgs e)
        {
            mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.TemsilKayit);
        }

        private void btnSahis_Click(object sender, EventArgs e)
        {
            mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.CariGenelGiris);
        }

        private void btnBorcluTaahhudu_Click(object sender, EventArgs e)
        {

        }

        private void btnOdemePlani_Click(object sender, EventArgs e)
        {
            frmFoySec foySec = new frmFoySec(AvukatProLib.Extras.Modul.Icra);

            DialogResult dr = foySec.ShowDialog();

            if (dr == DialogResult.OK)
            {
                UserControls.frmOdemePlani frm = new AdimAdimDavaKaydi.UserControls.frmOdemePlani();
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(foySec.IcraFoy.ID, foySec.IcraFoy.FOY_NO);
            }
            else
                return;
            //mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.OdemePlani);
            //frmOdemePlani frm = new frmOdemePlani();
            //frm.StartPosition = FormStartPosition.CenterParent;
            //frm.Show();
        }

        private void btnBorcluOdeme_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.IcraTakipForms.rFrmTarafOdeme frm = new AdimAdimDavaKaydi.IcraTakipForms.rFrmTarafOdeme();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.IsModul = true;
            frm.Show();
        }

        private void btnMuvekkileOdeme_Click(object sender, EventArgs e)
        {
            IcraTakipForms.frmMuvekkilOdemeleriLayout muvekkilOdeme =
               new AdimAdimDavaKaydi.IcraTakipForms.frmMuvekkilOdemeleriLayout();

            muvekkilOdeme.TakipEkraniDisinda = true;
            muvekkilOdeme.StartPosition = FormStartPosition.WindowsDefaultLocation;
            muvekkilOdeme.Show();
        }

        private void btnHaciz_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Icra.frmHacizGirisi frm = new AdimAdimDavaKaydi.Forms.Icra.frmHacizGirisi();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.HacizEdilecekMalVar = true;
            frm.IsModul = true;
            frm.Show();
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            Forms.Icra.frmSatisGirisi satisEkle = new AdimAdimDavaKaydi.Forms.Icra.frmSatisGirisi();
            satisEkle.StartPosition = FormStartPosition.WindowsDefaultLocation;
            satisEkle.IsModul = true;
            satisEkle.Show();
        }

        private void btnMasrafAvans_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli masraf =
               new AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli();
            masraf.AcilisYeri = AdimAdimDavaKaydi.IcraTakipForms.MasrafFormuAcilisiYeri.TakipEkraniDisinda;
            masraf.StartPosition = FormStartPosition.WindowsDefaultLocation;
            masraf.Show();
        }

        private void btnEvrakTebligat_Click(object sender, EventArgs e)
        {
            frmLayTabligatKayit evrakKaydi = new frmLayTabligatKayit();
            evrakKaydi.Show();
        }

        private void btnDurusmaKesif_Click(object sender, EventArgs e)
        {
            rFrmCelseKayit durusma = new rFrmCelseKayit();
            durusma.StartPosition = FormStartPosition.WindowsDefaultLocation;
            durusma.IsModul = true;
            durusma.Show();
        }

        private void btnAraKarar_Click(object sender, EventArgs e)
        {
            rfrmAraKararKayit araKarar = new rfrmAraKararKayit();
            araKarar.StartPosition = FormStartPosition.WindowsDefaultLocation;
            araKarar.IsModul = true;
            araKarar.Show();
        }

        private void btnGorusme_Click(object sender, EventArgs e)
        {
            Forms.rFrmGorusmeKayit gorusme = new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();
            // gorusme.MdiParent = null;
            gorusme.StartPosition = FormStartPosition.WindowsDefaultLocation;
            gorusme.IsModul = true;
            gorusme.Show();
        }

        private void btnBelgeDokuman_Click(object sender, EventArgs e)
        {
            mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.BelgeKayitUfak);
        }

        private void btnTapuBilgisineGoreAra_Click(object sender, EventArgs e)
        {
            mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.GayrimenkulGirisEkran);
        }

        private void btnAracBilgisineGoreAra_Click(object sender, EventArgs e)
        {
            mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.AracGemiUcakGirisEkran);
        }

        private void btnCekSeneteGoreAra_Click(object sender, EventArgs e)
        {
            mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.KiymetliEvrakGirisEkran);
        }

        private void btnEvrakBilgisineGoreAra_Click(object sender, EventArgs e)
        {
            //
        }

        private void sbtnGunlukIslerim_Click(object sender, EventArgs e)
        {
            Forms.rfrmGunlukIslerim gunlukIslerim = new rfrmGunlukIslerim();
            //gunlukIslerim.MdiParent = null;
            gunlukIslerim.StartPosition = FormStartPosition.WindowsDefaultLocation;
            gunlukIslerim.Show();
        }

        #endregion

        private void btnYazisma_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Editor.Forms.frmAdimAdimEditoreGonder frm = new Editor.Forms.frmAdimAdimEditoreGonder();
            frm.Show();
        }

        private void btnTarafGelismeyeGoreAra_Click(object sender, EventArgs e)
        {
            GirisEkran.rFrmIcraTarafGelismeAramaEkran icraTarafGelismeAra = new AdimAdimDavaKaydi.GirisEkran.rFrmIcraTarafGelismeAramaEkran();
            icraTarafGelismeAra.Show();
        }

        private void btnHukum_Click(object sender, EventArgs e)
        {
            frmFoySec sec = new frmFoySec(AvukatProLib.Extras.Modul.Dava);
            DialogResult dr = sec.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (sec.DavaFoy != null)
                {
                    AdimAdimDavaKaydi.Forms.Dava.frmHukumGirisi frm = new Forms.Dava.frmHukumGirisi();
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.Show(sec.DavaFoy);
                }
            }
            else
                return;

        }

        private void btnTemyiz_Click(object sender, EventArgs e)
        {
            frmFoySec sec = new frmFoySec(AvukatProLib.Extras.Modul.Dava);
            DialogResult dr = sec.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (sec.DavaFoy != null)
                {
                    AdimAdimDavaKaydi.Forms.Dava.frmTemyizEkle frm = new Forms.Dava.frmTemyizEkle();
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.Show(sec.DavaFoy);
                }
            }
            else
                return;
        }

        private void glueAdi_Click(object sender, EventArgs e)
        {
            if (glueAdi.Properties.DataSource == null)
                BelgeUtil.Inits.perCariGetirKimlikIletisim(glueAdi);
        }
    }
}