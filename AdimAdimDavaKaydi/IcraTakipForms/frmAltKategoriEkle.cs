using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AvukatProLib;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class frmAltKategoriEkle : Form
    {
        public enum Tipler { AltKategori, BelgeTuru, Segment, DavaKonusu, MalTuru, MalCinsi, OzelTutarKonu };
        int AnaKategoriID;
        Tipler tip;

        public string ADLI_BIRIM_BOLUM_KOD = "";
        public object SEKTOR_ID = null;

        public frmAltKategoriEkle(Tipler tip, int AnaKategoriID)
        {
            InitializeComponent();
            this.AnaKategoriID = AnaKategoriID;
            this.tip = tip;
        }

        private void frmAltKategoriEkle_Load(object sender, EventArgs e)
        {
            if (tip == Tipler.AltKategori)
            {
                this.Text = "Alt Kategori Ekle";
                labelControl1.Text = "Alt Kategori :";
            }
            else if (tip == Tipler.BelgeTuru)
            {
                this.Text = "Belge Türü Ekle";
                labelControl1.Text = "Belge Türü :";
            }
            else if (tip == Tipler.Segment)
            {
                this.Text = "Bölüm Ekle";
                labelControl1.Text = "Bölüm :";
            }
            else if (tip == Tipler.DavaKonusu)
            {
                this.Text = "Dava Konusu Ekle";
                labelControl1.Text = "Dava Konusu :";
            }
            else if (tip == Tipler.MalTuru)
            {
                this.Text = "Mal Türü Ekle";
                labelControl1.Text = "Mal Türü :";
            }
            else if (tip == Tipler.MalCinsi)
            {
                this.Text = "Mal Cinsi Ekle";
                labelControl1.Text = "Mal Cinsi :";
            }
            else if (tip == Tipler.OzelTutarKonu)
            {
                this.Text = "Özel Tutar Konu Ekle";
                labelControl1.Text = "Konu :";
            }
        }

        private void frmAltKategoriEkle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnVazgec_Click(sender, e);
            else if (e.KeyCode == Keys.Enter)
                btnKaydet_Click(sender, e);
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (tip == Tipler.AltKategori)
            {
                #region alt kategori ekle
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                cn.AddParams("@ALT_KATEGORI", textEdit1.Text);
                if (cn.GetDataTable("SELECT ID FROM dbo.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI(NOLOCK) WHERE ALT_KATEGORI=@ALT_KATEGORI").Rows.Count > 0)
                {
                    MessageBox.Show("Alt kategori zaten kayıtlı...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cn.Clear();

                cn.AddParams("@ANA_KATEGORI_ID", AnaKategoriID);
                cn.AddParams("@ALT_KATEGORI", textEdit1.Text);
                cn.ExcuteQuery("INSERT INTO dbo.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI (ANA_KATEGORI_ID, ANA_KATEGORI, ALT_KATEGORI, MANUAL_KAYIT_YAPABILIR_MI, MAKTU_VEKALET_KOD_NO, HESAPLANACAKMI_KDV, HESAPLANACAKMI_STOPAJ_SSDF, ICINDEMI_KDV, ICINDEMI_STOPAJ_SSDF, DEGISTIREBILIRMI_HESAPLANACAKMI_KDV, DEGISTIREBILIRMI_HESAPLANACAKMI_STOPAJ_SSDF, DEGISTIREBILIRMI_ICINDEMI_KDV, DEGISTIREBILIRMI_ICINDEMI_STOPAJ_SSDF, TEKDUZEN_HESAP_KOD, KDV_TUR_ID, KDV_TUR, ICON, SUBE_KODU, ADMIN_KAYIT_MI, KONTROL_NE_ZAMAN, KONTROL_KIM, KONTROL_VERSIYON, STAMP, TO_HESAP_CETVEL_YERI, TS_HESAP_CETVEL_YERI, DO_HESAP_CETVEL_YERI, DS_HESAP_CETVEL_YERI, KOLAY_SIRA, GORUSME_MI, KONTROL_KIM_ID, SUBE_KOD_ID) VALUES (@ANA_KATEGORI_ID, '', @ALT_KATEGORI, 1, 32, 0, 0, 1, 0, 1, 1, 1, 0, '', 6, 'GENEL', NULL, 1, 1, '2004-06-08 14:43:00', 'AVUKATPRO', 1, 1, NULL, NULL, NULL, NULL, 10, NULL, 1, 2)");

                this.Close(); 
                #endregion
            }
            else if (tip == Tipler.BelgeTuru)
            {
                #region belge türü ekle
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                cn.AddParams("@BELGE_TURU", textEdit1.Text);
                if (cn.GetDataTable("SELECT ID FROM dbo.TDIE_KOD_BELGE_TUR(NOLOCK) WHERE BELGE_TURU=@BELGE_TURU").Rows.Count > 0)
                {
                    MessageBox.Show("Belge türü zaten kayıtlı...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cn.Clear();

                cn.AddParams("@BELGE_TURU", textEdit1.Text);
                cn.ExcuteQuery("INSERT INTO dbo.TDIE_KOD_BELGE_TUR (BELGE_TURU, SUBE_KODU, ADMIN_KAYIT_MI, KONTROL_NE_ZAMAN, KONTROL_KIM, KONTROL_VERSIYON, STAMP, KONTROL_KIM_ID, SUBE_KOD_ID) VALUES (@BELGE_TURU, 1, 1, '2004-06-08 14:44:00', 'AVUKATPRO', 1, 1, 1, 2)");

                this.Close(); 
                #endregion
            }
            else if (tip == Tipler.Segment)
            {
                #region segment (bölüm) ekle
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                cn.AddParams("@SEGMENT", textEdit1.Text);
                if (cn.GetDataTable("SELECT ID FROM dbo.TDI_KOD_SEGMENT(NOLOCK) WHERE SEGMENT=@SEGMENT").Rows.Count > 0)
                {
                    MessageBox.Show("Segment zaten kayıtlı...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cn.Clear();

                cn.AddParams("@SEGMENT", textEdit1.Text);
                cn.ExcuteQuery("INSERT INTO dbo.TDI_KOD_SEGMENT (SEGMENT, SUBE_KODU, ADMIN_KAYIT_MI, KONTROL_NE_ZAMAN, KONTROL_KIM, KONTROL_VERSIYON, STAMP, KONTROL_KIM_ID, SUBE_KOD_ID) VALUES (@SEGMENT, 1, 1, '2004-06-08 14:44:00', 'AVUKATPRO', 1, 1, 1, 2)");

                this.Close(); 
                #endregion
            }
            else if (tip == Tipler.DavaKonusu)
            {
                #region dava konusu ekle
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                cn.AddParams("@ADLI_BIRIM_BOLUM_ID", AnaKategoriID);
                cn.AddParams("@DAVA_TALEP", textEdit1.Text);
                if (cn.GetDataTable("SELECT ID FROM dbo.TD_KOD_DAVA_TALEP(NOLOCK) WHERE DAVA_TALEP=@DAVA_TALEP and ADLI_BIRIM_BOLUM_ID=@ADLI_BIRIM_BOLUM_ID").Rows.Count > 0)
                {
                    MessageBox.Show("Dava Konusu zaten kayıtlı...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cn.Clear();

                cn.AddParams("@ADLI_BIRIM_BOLUM_ID", AnaKategoriID);
                cn.AddParams("@ADLI_BIRIM_BOLUM_KOD", ADLI_BIRIM_BOLUM_KOD);
                cn.AddParams("@DAVA_TALEP", textEdit1.Text);
                cn.AddParams("@SEKTOR_ID", SEKTOR_ID == null ? DBNull.Value : SEKTOR_ID);
                cn.ExcuteQuery("INSERT INTO dbo.TD_KOD_DAVA_TALEP (ADLI_BIRIM_BOLUM_ID, ADLI_BIRIM_BOLUM_KOD, DAVA_TALEP, SUBE_KODU, ADMIN_KAYIT_MI, KONTROL_NE_ZAMAN, KONTROL_KIM, KONTROL_VERSIYON, STAMP, KONTROL_KIM_ID, SUBE_KOD_ID, SEKTOR_ID) VALUES (@ADLI_BIRIM_BOLUM_ID, @ADLI_BIRIM_BOLUM_KOD, @DAVA_TALEP, 1, 1, '2004-06-08 14:44:00', 'AVUKATPRO', 1, 1, 1, 2, @SEKTOR_ID)");

                this.Close(); 
                #endregion
            }
            else if (tip == Tipler.MalTuru)
            {
                #region mal türü ekle
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                cn.AddParams("@KATEGORI_ID", AnaKategoriID);
                cn.AddParams("@TUR", textEdit1.Text);
                if (cn.GetDataTable("SELECT ID FROM dbo.TI_KOD_MAL_TUR(NOLOCK) WHERE TUR=@TUR and KATEGORI_ID=@KATEGORI_ID").Rows.Count > 0)
                {
                    MessageBox.Show("Mal Türü zaten kayıtlı...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cn.Clear();

                cn.AddParams("@KATEGORI_ID", AnaKategoriID);
                cn.AddParams("@TUR", textEdit1.Text);
                cn.ExcuteQuery("INSERT INTO dbo.TI_KOD_MAL_TUR (KATEGORI_ID, KATEGORI, KOD, TUR, HACIZ_EDILEMEZLIK_KODU, SUBE_KODU, ADMIN_KAYIT_MI, KONTROL_NE_ZAMAN, KONTROL_KIM, KONTROL_VERSIYON, STAMP, KONTROL_KIM_ID, SUBE_KOD_ID) VALUES (@KATEGORI_ID, '', '', @TUR, 0, 1, 1, '2004-06-08 14:44:00', 'AVUKATPRO', 1, 1, 1, 2)");
                this.Close(); 
                #endregion
            }
            else if (tip == Tipler.MalCinsi)
            {
                #region mal cinsi ekle
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                cn.AddParams("@KATEGORI_ID", AnaKategoriID);
                cn.AddParams("@TUR_ID", SEKTOR_ID);
                cn.AddParams("@CINS", textEdit1.Text);
                if (cn.GetDataTable("SELECT ID FROM dbo.TI_KOD_MAL_CINS(NOLOCK) WHERE CINS=@CINS and KATEGORI_ID=@KATEGORI_ID and TUR_ID=@TUR_ID").Rows.Count > 0)
                {
                    MessageBox.Show("Mal Cinsi zaten kayıtlı...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cn.Clear();

                cn.AddParams("@KATEGORI_ID", AnaKategoriID);
                cn.AddParams("@TUR_ID", SEKTOR_ID);
                cn.AddParams("@CINS", textEdit1.Text);
                cn.ExcuteQuery("INSERT INTO dbo.TI_KOD_MAL_CINS (KATEGORI_ID, KATEGORI, TUR_ID, TUR, CINS, SUBE_KODU, ADMIN_KAYIT_MI, KONTROL_NE_ZAMAN, KONTROL_KIM, KONTROL_VERSIYON, STAMP, KONTROL_KIM_ID, SUBE_KOD_ID) VALUES (@KATEGORI_ID, '', @TUR_ID,'' ,@CINS , 1, 1, '2004-06-08 14:44:00', 'AVUKATPRO', 1, 1, 1, 2)");
                this.Close(); 
                #endregion
            }
            else if (tip == Tipler.OzelTutarKonu)
            {
                #region özel tutar ekle
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                cn.AddParams("@KONU", textEdit1.Text);
                if (cn.GetDataTable("SELECT ID FROM dbo.TDI_KOD_OZEL_TUTAR_KONU(NOLOCK) WHERE KONU=@KONU").Rows.Count > 0)
                {
                    MessageBox.Show("Özel Tutar Konu zaten kayıtlı...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cn.Clear();

                cn.AddParams("@KONU", textEdit1.Text);
                cn.ExcuteQuery("INSERT INTO dbo.TDI_KOD_OZEL_TUTAR_KONU (KONU, SUBE_KODU, ADMIN_KAYIT_MI, KONTROL_NE_ZAMAN, KONTROL_KIM, KONTROL_VERSIYON, STAMP, KONTROL_KIM_ID, SUBE_KOD_ID) VALUES (@KONU, 1, 1, '2004-06-08 14:44:00', 'AVUKATPRO', 1, 1, 1, 2)");
                this.Close();
                #endregion
            }
        }
    }
}
