using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AvukatProLib.Bakim
{
    public partial class frmSistemTanimlari : Form
    {
        public frmSistemTanimlari()
        {
            InitializeComponent();
        }

        private void btnCik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btneYedekServisiDosyaYolu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                btneYedekServisiDosyaYolu.Text = fbd.SelectedPath;
        }

        private void btnKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
            CompInfo cmpNfo = cmpNfoList[0];
            cmpNfo.OtoMasrafUretilmesin = chkOtoMasrafUretilmesin.Checked;
            cmpNfo.OtoKasaHareketiUretilmesin = chkOtoKasaHareketi.Checked;
            cmpNfo.OnaySifresi1 = txtOnaySifresi1.Text;
            cmpNfo.OnaySifresi2 = txtOnaySifresi2.Text;
            cmpNfo.OnaySifresi3 = txtOnaySifresi3.Text;
            cmpNfo.DegistirmeSilmeSifresi = txtDegisSilSifresi.Text;
            cmpNfo.OnaylamaSifresiAktif = chkOnaylamaSifresiAktif.Checked;
            cmpNfo.DegistirmeSilmeSifresiAktif = chkDegistirmeSilmeSifresiAktif.Checked;

            cmpNfo.OnayKullanicisi1 = lueOnayKull1.GetColumnValue("KOD").ToString();
            cmpNfo.OnayKullanicisi2 = lueOnayKull2.GetColumnValue("KOD").ToString();
            cmpNfo.OnayKullanicisi3 = lueOnayKull3.GetColumnValue("KOD").ToString();
            cmpNfo.DegSilmeKullanicisi = lueDegSilKull.GetColumnValue("KOD").ToString();
            cmpNfo.YedekServisiDosyaYolu = btneYedekServisiDosyaYolu.Text;

            CompInfo.Kaydet(cmpNfoList, Application.StartupPath);

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = cmpNfo.ConStr;
            cn.Clear();

            if (string.IsNullOrEmpty(dateMasraf.Text))
                cn.AddParams("@OTO_MASRAF_TARIHI", DBNull.Value);
            else
                cn.AddParams("@OTO_MASRAF_TARIHI", dateMasraf.DateTime);

            if (string.IsNullOrEmpty(dateKasa.Text))
                cn.AddParams("@OTO_KASA_TARIHI", DBNull.Value);
            else
                cn.AddParams("@OTO_KASA_TARIHI", dateKasa.DateTime);

            if (cn.ExcuteQuery("update dbo.AV001_TDIE_BIL_SISTEM_TANIMLARI set OTO_MASRAF_TARIHI=@OTO_MASRAF_TARIHI, OTO_KASA_TARIHI=@OTO_KASA_TARIHI") == 0)
                cn.ExcuteQuery("insert into dbo.AV001_TDIE_BIL_SISTEM_TANIMLARI (OTO_MASRAF_TARIHI, OTO_KASA_TARIHI) values (@OTO_MASRAF_TARIHI, @OTO_KASA_TARIHI)");

            cn.Clear();
            cn.AddParams("@Sifre", txtBakimSifresi.Text);
            cn.ExcuteQuery("update dbo.TDI_BIL_KULLANICI_LISTESI set KULLANICI_SIFRESI=@Sifre WHERE KULLANICI_ADI='SU'");

            cn.Clear();
            if (!chkOtoKasaHareketi.Checked)
            {
                try
                {
                    cn.ExcuteQuery("ENABLE TRIGGER t_Masraf_Avans_Detay_OtomatikKasa_Insert ON dbo.AV001_TDI_BIL_MASRAF_AVANS_DETAY");
                }
                catch { MessageBox.Show("t_Masraf_Avans_Detay_OtomatikKasa_Insert isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("ENABLE TRIGGER t_Masraf_Avans_Detay_otomatikKasa_Update ON dbo.AV001_TDI_BIL_MASRAF_AVANS_DETAY");
                }
                catch { MessageBox.Show("t_Masraf_Avans_Detay_otomatikKasa_Update isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("ENABLE TRIGGER t_Msraf_Avans_Detay_otomatikKasa_Delete ON dbo.AV001_TDI_BIL_MASRAF_AVANS_DETAY");
                }
                catch { MessageBox.Show("t_Msraf_Avans_Detay_otomatikKasa_Delete isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("ENABLE TRIGGER t_Icra_Borclu_Odeme_otomatikKasa_Delete ON dbo.AV001_TI_BIL_BORCLU_ODEME");
                }
                catch { MessageBox.Show("t_Icra_Borclu_Odeme_otomatikKasa_Delete isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("ENABLE TRIGGER t_Icra_Borclu_Odeme_otomatikKasa_Insert ON dbo.AV001_TI_BIL_BORCLU_ODEME");
                }
                catch { MessageBox.Show("t_Icra_Borclu_Odeme_otomatikKasa_Insert isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("ENABLE TRIGGER t_Icra_Borclu_Odeme_otomatikKasa_Update ON dbo.AV001_TI_BIL_BORCLU_ODEME");
                }
                catch { MessageBox.Show("t_Icra_Borclu_Odeme_otomatikKasa_Update isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("ENABLE TRIGGER t_Dava_Borclu_Odeme_otomatikKasa_Delete ON dbo.AV001_TD_BIL_BORCLU_ODEME");
                }
                catch { MessageBox.Show("t_Dava_Borclu_Odeme_otomatikKasa_Delete isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("ENABLE TRIGGER t_Dava_Borclu_Odeme_otomatikKasa_Insert ON dbo.AV001_TD_BIL_BORCLU_ODEME");
                }
                catch { MessageBox.Show("t_Dava_Borclu_Odeme_otomatikKasa_Insert isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("ENABLE TRIGGER t_Dava_Borclu_Odeme_otomatikKasa_Update ON dbo.AV001_TD_BIL_BORCLU_ODEME");
                }
                catch { MessageBox.Show("t_Dava_Borclu_Odeme_otomatikKasa_Update isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("ENABLE TRIGGER t_Muvekkile_Odeme_otomatikKasa_Delete ON dbo.AV001_TI_BIL_MUVEKKILE_ODEME");
                }
                catch { MessageBox.Show("t_Muvekkile_Odeme_otomatikKasa_Delete isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("ENABLE TRIGGER t_Muvekkile_Odeme_otomatikKasa_Insert ON dbo.AV001_TI_BIL_MUVEKKILE_ODEME");
                }
                catch { MessageBox.Show("t_Muvekkile_Odeme_otomatikKasa_Insert isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("ENABLE TRIGGER t_Muvekkile_Odeme_otomatikKasa_Update ON dbo.AV001_TI_BIL_MUVEKKILE_ODEME");
                }
                catch { MessageBox.Show("t_Muvekkile_Odeme_otomatikKasa_Update isimli trigger sistem de mevcut değil."); }
            }
            else
            {
                try
                {
                    cn.ExcuteQuery("DISABLE TRIGGER	t_Masraf_Avans_Detay_OtomatikKasa_Insert ON dbo.AV001_TDI_BIL_MASRAF_AVANS_DETAY");
                }
                catch { MessageBox.Show("t_Masraf_Avans_Detay_OtomatikKasa_Insert isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("DISABLE TRIGGER	t_Masraf_Avans_Detay_otomatikKasa_Update ON dbo.AV001_TDI_BIL_MASRAF_AVANS_DETAY");
                }
                catch { MessageBox.Show("t_Masraf_Avans_Detay_otomatikKasa_Update isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("DISABLE TRIGGER	t_Msraf_Avans_Detay_otomatikKasa_Delete ON dbo.AV001_TDI_BIL_MASRAF_AVANS_DETAY");
                }
                catch { MessageBox.Show("t_Msraf_Avans_Detay_otomatikKasa_Delete isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("DISABLE TRIGGER	t_Icra_Borclu_Odeme_otomatikKasa_Delete ON dbo.AV001_TI_BIL_BORCLU_ODEME");
                }
                catch { MessageBox.Show("t_Icra_Borclu_Odeme_otomatikKasa_Delete isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("DISABLE TRIGGER	t_Icra_Borclu_Odeme_otomatikKasa_Insert ON dbo.AV001_TI_BIL_BORCLU_ODEME");
                }
                catch { MessageBox.Show("t_Icra_Borclu_Odeme_otomatikKasa_Insert isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("DISABLE TRIGGER	t_Icra_Borclu_Odeme_otomatikKasa_Update ON dbo.AV001_TI_BIL_BORCLU_ODEME");
                }
                catch { MessageBox.Show("t_Icra_Borclu_Odeme_otomatikKasa_Update isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("DISABLE TRIGGER	t_Dava_Borclu_Odeme_otomatikKasa_Delete ON dbo.AV001_TD_BIL_BORCLU_ODEME");
                }
                catch { MessageBox.Show("t_Dava_Borclu_Odeme_otomatikKasa_Delete isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("DISABLE TRIGGER	t_Dava_Borclu_Odeme_otomatikKasa_Insert ON dbo.AV001_TD_BIL_BORCLU_ODEME");
                }
                catch { MessageBox.Show("t_Dava_Borclu_Odeme_otomatikKasa_Insert isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("DISABLE TRIGGER	t_Dava_Borclu_Odeme_otomatikKasa_Update ON dbo.AV001_TD_BIL_BORCLU_ODEME");
                }
                catch { MessageBox.Show("t_Dava_Borclu_Odeme_otomatikKasa_Update isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("DISABLE TRIGGER	t_Muvekkile_Odeme_otomatikKasa_Delete ON dbo.AV001_TI_BIL_MUVEKKILE_ODEME");
                }
                catch { MessageBox.Show("t_Muvekkile_Odeme_otomatikKasa_Delete isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("DISABLE TRIGGER	t_Muvekkile_Odeme_otomatikKasa_Insert ON dbo.AV001_TI_BIL_MUVEKKILE_ODEME");
                }
                catch { MessageBox.Show("t_Muvekkile_Odeme_otomatikKasa_Insert isimli trigger sistem de mevcut değil."); }

                try
                {
                    cn.ExcuteQuery("DISABLE TRIGGER	t_Muvekkile_Odeme_otomatikKasa_Update ON dbo.AV001_TI_BIL_MUVEKKILE_ODEME");
                }
                catch { MessageBox.Show("t_Muvekkile_Odeme_otomatikKasa_Update isimli trigger sistem de mevcut değil."); }
            }
        }

        private void frmSistemTanimlari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            else if (e.KeyCode == Keys.Enter)
                btnKaydet_ItemClick(sender, null);
        }

        private void frmSistemTanimlari_Load(object sender, EventArgs e)
        {
            ABSqlConnection cn = new ABSqlConnection();
            List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
            CompInfo cmpNfo = cmpNfoList[0];
            cn.CnString = cmpNfo.ConStr;

            lueDegSilKull.Properties.DataSource = cn.GetDataTable("SELECT KOD,AD FROM dbo.AV001_TDI_BIL_CARI WHERE PERSONEL_MI=1 ORDER BY AD");
            lueOnayKull1.Properties.DataSource = lueDegSilKull.Properties.DataSource;
            lueOnayKull2.Properties.DataSource = lueDegSilKull.Properties.DataSource;
            lueOnayKull3.Properties.DataSource = lueDegSilKull.Properties.DataSource;

            try
            {
                txtBakimSifresi.Text = cn.ExecuteScalar("SELECT KULLANICI_SIFRESI FROM dbo.TDI_BIL_KULLANICI_LISTESI WHERE KULLANICI_ADI='SU'").ToString();
            }
            catch
            {
                TDI_BIL_KULLANICI_LISTESI kul = new TDI_BIL_KULLANICI_LISTESI();
                kul.KULLANICI_ADI = "SU";
                kul.KULLANICI_SIFRESI = "WSHNGT0NPORTAKAL";
                kul.KULLANICI_GRUP_ID = 1;
                kul.GRUP_KISA_ADI = "N";
                kul.PROGRAM_MODUL = 1;
                kul.KULLANICI_YETKI_SEVIYESI = 1;
                kul.KULLANICI_AKTIF = true;
                kul.SIFRE_GUNCELLEME_PERYODU = 1;
                kul.SIFRE_GUNCELLEME_ZAMANI = DateTime.Today;
                kul.KAYIT_TARIHI = DateTime.Today;
                kul.SUBE_ID = 2;
                kul.KONTROL_NE_ZAMAN = DateTime.Today;
                kul.KONTROL_KIM = "AVUKATPRO";
                kul.KONTROL_VERSIYON = 1;
                kul.STAMP = 1;
                kul.KULLANICI_SUBE_ID = 2;
                kul.HASHED_CODE = ".";
                kul.CARI_ID = 1;
                kul.STYLE = "EBEGUMECI";
                kul.EMAIL = "noemail@avukatpro.com";
                kul.HATALI_GIRIS = 0;
                DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.DeepSave(kul);
                txtBakimSifresi.Text = "WSHNGT0NPORTAKAL";
            }

            chkOtoMasrafUretilmesin.Checked = cmpNfo.OtoMasrafUretilmesin;
            chkOtoKasaHareketi.Checked = cmpNfo.OtoKasaHareketiUretilmesin;
            txtOnaySifresi1.Text = cmpNfo.OnaySifresi1;
            txtOnaySifresi2.Text = cmpNfo.OnaySifresi2;
            txtOnaySifresi3.Text = cmpNfo.OnaySifresi3;
            chkDegistirmeSilmeSifresiAktif.Checked = cmpNfo.DegistirmeSilmeSifresiAktif;
            chkOnaylamaSifresiAktif.Checked = cmpNfo.OnaylamaSifresiAktif;
            txtDegisSilSifresi.Text = cmpNfo.DegistirmeSilmeSifresi;
            lueOnayKull1.EditValue = cmpNfo.OnayKullanicisi1;
            lueOnayKull2.EditValue = cmpNfo.OnayKullanicisi2;
            lueOnayKull3.EditValue = cmpNfo.OnayKullanicisi3;
            lueDegSilKull.EditValue = cmpNfo.DegSilmeKullanicisi;

            DataTable dt = cn.GetDataTable("SELECT ID, OTO_MASRAF_TARIHI, OTO_KASA_TARIHI FROM dbo.AV001_TDIE_BIL_SISTEM_TANIMLARI(nolock)");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["OTO_MASRAF_TARIHI"] != DBNull.Value)
                    dateMasraf.DateTime = Convert.ToDateTime(dt.Rows[0]["OTO_MASRAF_TARIHI"].ToString());
                if (dt.Rows[0]["OTO_KASA_TARIHI"] != DBNull.Value)
                    dateKasa.DateTime = Convert.ToDateTime(dt.Rows[0]["OTO_KASA_TARIHI"].ToString());
            }
            if (string.IsNullOrEmpty(cmpNfo.OtomatikIsUretme))
                rgOtomatikIs.SelectedIndex = 1;
            else
                rgOtomatikIs.SelectedIndex = Convert.ToInt32(cmpNfo.OtomatikIsUretme);

            btneYedekServisiDosyaYolu.Text = cmpNfo.YedekServisiDosyaYolu;
        }
    }
}