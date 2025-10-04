using AdimAdimDavaKaydi.UserControls.ucRapor;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Raporlama
{
    public partial class frmTicariRiskRaporuDosya : Form
    {
        public frmTicariRiskRaporuDosya()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void frmTicariRiskRaporuDosya_Load(object sender, EventArgs e)
        {
            for (int i = DateTime.Today.Year - 10; i < DateTime.Today.Year; i++)
            {
                cmbYil.Properties.Items.Add(i);
                cmbYil2.Properties.Items.Add(i);
                repcmbPeriyotYil.Items.Add(i);
            }
            for (int i = DateTime.Today.Year; i < DateTime.Today.Year + 10; i++)
            {
                cmbYil.Properties.Items.Add(i);
                cmbYil2.Properties.Items.Add(i);
                repcmbPeriyotYil.Items.Add(i);
            }                       
            
            BelgeUtil.Inits.DosyaDurumGetir(rLueDurum);
            BelgeUtil.Inits.CariSifatGetir(rLueAlacakliSifat);
            BelgeUtil.Inits.CariSifatGetir(rLueBorcluSifat);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliBirim);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlueAdliBirimGorev);

            BelgeUtil.Inits.DosyaDurumGetir(lueDurumu.Properties);
            slueAlacakli.Enter += delegate { AvukatPro.Services.Implementations.DevExpressService.CariDoldur(slueAlacakli, null); };
            slueBorclu.Enter += delegate { AvukatPro.Services.Implementations.DevExpressService.CariDoldur(slueBorclu, null); };
            slueSorumluAvkat.Enter += delegate { AvukatPro.Services.Implementations.DevExpressService.CariDoldur(slueSorumluAvkat, AvukatProLib.Extras.CariStatu.Avukat); };

            lueAdliye.Enter += delegate { BelgeUtil.Inits.AdliBirimAdliyeGetir(lueAdliye); };
            lueBirim.Enter += delegate { BelgeUtil.Inits.AdliBirimNoGetir(lueBirim); };
            lueGorev.Enter += delegate { BelgeUtil.Inits.AdliBirimGorevGetir(lueGorev); };
        }

        private void cmbPeriyotTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPeriyotTipi.SelectedIndex == 0) //YIL
            {
                cmbAy.Enabled = false;
                cmbCeyrek.Enabled = false;

                cmbAy.SelectedIndex = -1;
                cmbCeyrek.SelectedIndex = -1;
            }
            else if (cmbPeriyotTipi.SelectedIndex == 1) //AY
            {
                cmbAy.Enabled = true;
                cmbCeyrek.Enabled = false;

                cmbAy.SelectedIndex = 0;
                cmbCeyrek.SelectedIndex = -1;
            }
            else if (cmbPeriyotTipi.SelectedIndex == 2) //çeyrek
            {
                cmbAy.Enabled = false;
                cmbCeyrek.Enabled = true;

                cmbAy.SelectedIndex = -1;
                cmbCeyrek.SelectedIndex = 0;
            }
        }

        enum IslemTipleri { Listeleme, Pivot, Aktarim, Silme }
        IslemTipleri IslemTipi = IslemTipleri.Aktarim;

        frmBeklemePaneli frm = new frmBeklemePaneli();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (cmbPeriyotTipi.SelectedIndex < 0)
            {
                MessageBox.Show("Periyot Tipi Seçmediniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbYil.SelectedIndex < 0)
            {
                MessageBox.Show("Yıl Seçmediniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPeriyotTipi.SelectedIndex == 1 & cmbAy.SelectedIndex < 0)
            {
                MessageBox.Show("Ay Seçmediniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPeriyotTipi.SelectedIndex == 2 & cmbCeyrek.SelectedIndex < 0)
            {
                MessageBox.Show("Çeyrek Seçmediniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            cn.AddParams("@PeriyotTipi", cmbPeriyotTipi.SelectedIndex);
            cn.AddParams("@PeriyotYil", Convert.ToInt32(cmbYil.Text));

            if (cmbPeriyotTipi.SelectedIndex == 1)
                cn.AddParams("@PeriyotAy", cmbAy.SelectedIndex + 1);
            else if (cmbPeriyotTipi.SelectedIndex == 2)
                cn.AddParams("@PeriyotAy", cmbCeyrek.SelectedIndex + 1);
            else
                cn.AddParams("@PeriyotAy", -1);

            if (cn.GetDataTable("select RowID FROM dbo.AV001_TDIE_BIL_DOSYA_RISK_RAPORU(nolock) WHERE PeriyotTipi=@PeriyotTipi and PeriyotYil=@PeriyotYil and PeriyotAy=@PeriyotAy").Rows.Count > 0)
            {
                if (MessageBox.Show("Seçtiğiniz periyot sistem de kayıtlı. \nDevam ederseniz eski kayıtların üzerine yazılacak.\nDevam etmek istiyor musunuz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                    return;
            }


            if (!bwListele.IsBusy)
            {
                if (frm.IsDisposed)
                    frm = new frmBeklemePaneli();

                IslemTipi = IslemTipleri.Aktarim;
                if (chkYenidenHesapla.Checked)
                    frm.progressBarControl1.Visible = true;
                else
                    frm.progressBarControl1.Visible = false;
                    frm.lblBilgi.Text = "Aktarım işlemi yapılıyor...";
                frm.Show();
                bwListele.RunWorkerAsync();
            }
        }

        private string FiltreyiDuzenle(ABSqlConnection cn)
        {
            string where = "";

            if (cmbPeryotTipi2.SelectedIndex >= 0)
            {
                cn.AddParams("@PeriyotTipi", cmbPeryotTipi2.SelectedIndex);
                where += " and a.PeriyotTipi=@PeriyotTipi";
            }

            if (cmbYil2.SelectedIndex >= 0)
            {
                cn.AddParams("@PeriyotYil", cmbYil2.Text);
                where += " and a.PeriyotYil=@PeriyotYil";
            }

            if (cmbAy2.SelectedIndex >= 0)
            {
                cn.AddParams("@PeriyotAy", cmbAy2.SelectedIndex + 1);
                where += " and a.PeriyotAy=@PeriyotAy";
            }

            if (cmbCeyrek2.SelectedIndex >= 0)
            {
                cn.AddParams("@PeriyotAy2", cmbCeyrek2.SelectedIndex + 1);
                where += " and a.PeriyotAy=@PeriyotAy2";
            }

            if (lueDurumu.EditValue != null)
            {
                cn.AddParams("@DurumID", lueDurumu.EditValue);
                where += " and a.DurumID=@DurumID";
            }

            if (slueBorclu.EditValue != null)
            {
                cn.AddParams("@BorcluID", slueBorclu.EditValue);
                where += " and (a.FoyID IN (SELECT DAVA_FOY_ID FROM dbo.AV001_TD_BIL_FOY_TARAF(NOLOCK) WHERE CARI_ID=@BorcluID) or a.FoyID IN (SELECT ICRA_FOY_ID FROM dbo.AV001_TI_BIL_FOY_TARAF(NOLOCK) WHERE CARI_ID=@BorcluID))";
            }

            if (slueAlacakli.EditValue != null)
            {
                cn.AddParams("@AlacakliID", slueAlacakli.EditValue);
                where += " and (a.FoyID IN (SELECT DAVA_FOY_ID FROM dbo.AV001_TD_BIL_FOY_TARAF(NOLOCK) WHERE CARI_ID=@AlacakliID) or a.FoyID IN (SELECT ICRA_FOY_ID FROM dbo.AV001_TI_BIL_FOY_TARAF(NOLOCK) WHERE CARI_ID=@AlacakliID))";
            }

            if (dateTakipTarihi.EditValue != null)
            {
                cn.AddParams("@TakipTarihi", dateTakipTarihi.EditValue);
                where += " and a.TakipTarihi=@TakipTarihi";
            }

            if (txtFoyNo.EditValue != null)
            {
                cn.AddParams("@FoyNo", txtFoyNo.EditValue);
                where += " and a.FoyNo like '%' + @FoyNo + '%'";
            }

            if (txtEsasNo.EditValue != null)
            {
                cn.AddParams("@EsasNo", txtEsasNo.EditValue);
                where += " and a.EsasNo like '%' + @EsasNo + '%'";
            }

            if (lueAdliye.EditValue != null)
            {
                cn.AddParams("@AdliBirimAdliyeID", lueAdliye.EditValue);
                where += " and a.AdliBirimAdliyeID=@AdliBirimAdliyeID";
            }

            if (lueBirim.EditValue != null)
            {
                cn.AddParams("@AdliBirimNoID", lueBirim.EditValue);
                where += " and a.AdliBirimNoID=@AdliBirimNoID";
            }

            if (lueGorev.EditValue != null)
            {
                cn.AddParams("@AdliBirimGorevID", lueGorev.EditValue);
                where += " and a.AdliBirimGorevID=@AdliBirimGorevID";
            }

            if (slueSorumluAvkat.EditValue != null)
            {
                cn.AddParams("@SorumluAvkat", slueSorumluAvkat.EditValue);
                where += " and (a.FoyID IN (SELECT DAVA_FOY_ID FROM dbo.AV001_TD_BIL_FOY_SORUMLU_AVUKAT(NOLOCK) WHERE SORUMLU_AVUKAT_CARI_ID=@SorumluAvkat) or a.FoyID IN (SELECT ICRA_FOY_ID FROM dbo.AV001_TI_BIL_FOY_SORUMLU_AVUKAT(NOLOCK) WHERE SORUMLU_AVUKAT_CARI_ID=@SorumluAvkat))";
            }

            return where;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            if (!bwListele.IsBusy)
            {
                if (frm.IsDisposed)
                    frm = new frmBeklemePaneli();

                IslemTipi = IslemTipleri.Listeleme;
                frm.progressBarControl1.Visible = false;
                frm.lblBilgi.Text = "Liste hazırlanıyor...";
                frm.Show();
                bwListele.RunWorkerAsync();
            }            
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            foreach (Control item in panelControl1.Controls)
            {
                if (item is ComboBoxEdit)
                    ((ComboBoxEdit)item).EditValue = null;
                else if (item is DateEdit)
                    ((DateEdit)item).EditValue = null;
                else if (item is SearchLookUpEdit)
                    ((SearchLookUpEdit)item).EditValue = null;
                else if (item is LookUpEdit)
                    ((LookUpEdit)item).EditValue = null;
                else if (item is TextEdit)
                    ((TextEdit)item).EditValue = null;
            }
        }

        private void btnParamKaydet_Click(object sender, EventArgs e)
        {
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;

            string sorgu = "";

            foreach (Control item in xtraTabPage4.Controls)
            {
                if (item is CheckEdit)
                {
                    cn.AddParams("@" + item.Name, ((CheckEdit)item).Checked);
                    if (string.IsNullOrEmpty(sorgu))
                        sorgu += item.Name + "=@" + item.Name;
                    else
                        sorgu += "," + item.Name + "=@" + item.Name;
                }
            }

            cn.ExcuteQuery("update dbo.AV001_TDIE_BIL_RISK_RAPORU_PARAMETRELER set " + sorgu);
            MessageBox.Show("Kayıt İşlem tamamlandı...");
        }

        //yapılacak
        private void xtraTabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (e.Page == xtraTabPage4)
            {
                foreach (Control item in xtraTabPage4.Controls)
                {
                    if (item is CheckEdit)
                        ((CheckEdit)item).Checked = false;
                }

                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                DataTable dt = cn.GetDataTable("select RowID, ISNULL(TUTAR_ANAPARA,0) AS TUTAR_ANAPARA, ISNULL(TUTAR_FAIZ,0) AS TUTAR_FAIZ, ISNULL(TUTAR_GIDER_VERGISI,0) AS TUTAR_GIDER_VERGISI, ISNULL(TUTAR_KOM_TAZ,0) AS TUTAR_KOM_TAZ, ISNULL(TUTAR_MASRAF,0) AS TUTAR_MASRAF, ISNULL(TUTAR_VEKALET_UCRETI,0) AS TUTAR_VEKALET_UCRETI, ISNULL(KARSILIK_TUTARI_SAP_UZERINDEN_HESAPLANSIN,0) AS KARSILIK_TUTARI_SAP_UZERINDEN_HESAPLANSIN, ISNULL(KefaletToplami,0) as KefaletToplami, isnull(SenetCekToplami,0) as SenetCekToplami, isnull(TumKayitlarAktarilsinMi,0) as TumKayitlarAktarilsinMi from dbo.AV001_TDIE_BIL_RISK_RAPORU_PARAMETRELER(nolock)");

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (Control item in xtraTabPage4.Controls)
                        {
                            if (item is CheckEdit)
                                ((CheckEdit)item).Checked = Convert.ToBoolean(row[item.Name].ToString());
                        }
                    }
                }
                else
                {
                    cn.ExcuteQuery("insert into dbo.AV001_TDIE_BIL_RISK_RAPORU_PARAMETRELER (TUTAR_ANAPARA) values (0)");
                }
            }
            else if (e.Page == xtraTabPage2)
            {
                if (xtraTabPage2.Controls.Count == 0)
                {
                    if (!bwListele.IsBusy)
                    {
                        if (frm.IsDisposed)
                            frm = new frmBeklemePaneli();

                        IslemTipi = IslemTipleri.Pivot;
                        frm.progressBarControl1.Visible = false;
                        frm.lblBilgi.Text = "Pivot raporunuz hazırlanıyor...";
                        frm.Show();
                        bwListele.RunWorkerAsync();
                    }
                }
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column.FieldName == "GuncelKarsilikTutari" || e.Column.FieldName == "OncekiDonemKarsilikTutari" || e.Column.FieldName == "GayriNakdiTahsilatTutari" || e.Column.FieldName == "SAPAlacakTutari" || e.Column.FieldName == "EkspertizDegeri")
            //{
            //    gridView1.SetFocusedRowCellValue("DonemdeAyrilanEkKarsilikTutari", (Convert.ToDecimal(gridView1.GetFocusedRowCellValue("GuncelKarsilikTutari")) - Convert.ToDecimal(gridView1.GetFocusedRowCellValue("OncekiDonemKarsilikTutari"))) + Convert.ToDecimal(gridView1.GetFocusedRowCellValue("GayriNakdiTahsilatTutari")));
            //}
        }

        private void btnListeyiSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("İşleme devam etmek istiyor musunuz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;

            if (!bwListele.IsBusy)
            {
                if (frm.IsDisposed)
                    frm = new frmBeklemePaneli();

                IslemTipi = IslemTipleri.Silme;
                frm.progressBarControl1.Visible = false;
                frm.lblBilgi.Text = "Kayıtlar siliniyor...";
                frm.Show();
                bwListele.RunWorkerAsync();
            }            
        }

        DataSet ds = new DataSet();
        ucPivotChart pGcIcraRapor = new ucPivotChart();
        private void bwListele_DoWork(object sender, DoWorkEventArgs e)
        {
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;

            if (IslemTipi == IslemTipleri.Aktarim)
            {
                #region aktarım
                frm.progressBarControl1.EditValue = 0;
                frm.lblBilgi.Text = "";

                cn.AddParams("@PeriyotTipi", cmbPeriyotTipi.SelectedIndex);
                cn.AddParams("@PeriyotYil", Convert.ToInt32(cmbYil.Text));

                if (cmbPeriyotTipi.SelectedIndex == 1)
                    cn.AddParams("@PeriyotAy", cmbAy.SelectedIndex + 1);
                else if (cmbPeriyotTipi.SelectedIndex == 2)
                    cn.AddParams("@PeriyotAy", cmbCeyrek.SelectedIndex + 1);
                else
                    cn.AddParams("@PeriyotAy", -1);
                SqlConnection cnn = new SqlConnection(AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr);

                string sql = "GetDosyaRiskRaporuDerdest";

                if (TumKayitlarAktarilsinMi.Checked)
                    sql = "dbo.GetDosyaRiskRaporu";

                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PeriyotTipi", cmbPeriyotTipi.SelectedIndex);
                cmd.Parameters.AddWithValue("@PeriyotYil", Convert.ToInt32(cmbYil.Text));
                cmd.Parameters.AddWithValue("@HesaplayanCariID", AvukatProLib.Kimlikci.Kimlik.Cari_ID);

                if (cmbPeriyotTipi.SelectedIndex == 1)
                    cmd.Parameters.AddWithValue("@PeriyotAy", cmbAy.SelectedIndex + 1);
                else if (cmbPeriyotTipi.SelectedIndex == 2)
                    cmd.Parameters.AddWithValue("@PeriyotAy", cmbCeyrek.SelectedIndex + 1);
                else
                    cmd.Parameters.AddWithValue("@PeriyotAy", -1);

                try
                {
                    if (cnn.State == ConnectionState.Closed)
                        cnn.Open();

                    cmd.ExecuteNonQuery();

                    if (chkYenidenHesapla.Checked)
                    {
                        DataTable dt1 = cn.GetDataTable("select FoyID,FoyNo,DosyaTipi FROM dbo.AV001_TDIE_BIL_DOSYA_RISK_RAPORU(nolock) WHERE PeriyotTipi=@PeriyotTipi and PeriyotYil=@PeriyotYil and PeriyotAy=@PeriyotAy");

                        frm.progressBarControl1.Properties.Maximum = dt1.Rows.Count;

                        foreach (DataRow row in dt1.Rows)
                        {
                            frm.progressBarControl1.EditValue = (int)frm.progressBarControl1.EditValue + 1;
                            frm.lblBilgi.Text = row["FoyNo"].ToString() + " nolu " + row["DosyaTipi"].ToString() + " dosyası hesaplanıyor...";
                            if (row["DosyaTipi"].ToString() == "Dava")
                            {
                                List<int> idList = new List<int>();
                                idList.Add(Convert.ToInt32(row["FoyID"].ToString()));
                                Hesap.Dava hesap = new Hesap.Dava(idList);
                            }
                            else
                            {
                                AV001_TI_BIL_FOY foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(Convert.ToInt32(row["FoyID"].ToString()));
                                Hesap.Icra hy = new Hesap.Icra(foy, true);
                            }
                        }

                        cmd.ExecuteNonQuery();
                    }

                    cnn.Close();
                    cnn.Dispose();
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }  
                #endregion
            }
            else if (IslemTipi == IslemTipleri.Pivot)
            {
                #region pivot
                pGcIcraRapor.MyTicariRiskRaporuDosya = cn.GetDataTable("select (CASE PeriyotTipi WHEN 0 THEN 'Yıl' WHEN 1 THEN 'Ay' ELSE 'Çeyrek' END) AS PeriyotTipi, PeriyotYil, (CASE PeriyotTipi WHEN 0 THEN '' WHEN 1 THEN (CASE PeriyotAy WHEN 1 THEN 'Ocak' WHEN 2 THEN 'Şubat' WHEN 3 THEN 'Mart' WHEN 4 THEN 'Nisan' WHEN 5 THEN 'Mayıs' WHEN 6 THEN 'Haziran' WHEN 7 THEN 'Temmuz' WHEN 8 THEN 'Ağustos' WHEN 9 THEN 'Eylül' WHEN 10 THEN 'Ekim' WHEN 11 THEN 'Kasım' WHEN 12 THEN 'Aralık' END) WHEN 2 THEN (CASE PeriyotAy WHEN 1 THEN '1. Çeyrek' WHEN 2 THEN '2. Çeyrek' WHEN 3 THEN '3. Çeyrek' WHEN 4 THEN '4. Çeyrek' END) END) AS PeriyotAy, a.RowID, FoyID, FoyNo, DurumID, PeriyotTipi, PeriyotYil, PeriyotAy, SirketKodu, AlacakliSirket, AlacakliSifatiID, SAPMusteriKodu, Borclu_Davali, BorcluSifatiID, TakipTarihi, AdliBirimAdliyeID, AdliBirimNoID, AdliBirimGorevID, EsasNo, DurusmaTarihi, BuroAdi, SorumluAvukat, LeheAleyhe, DosyaTipi, TakipKonusu, KazanmaOrani, BeklenenBitisTarihi, AlacakAnapara, AlacakFaiz, AlacakDigerKalemler, ToplamVergi, Masraflar, ToplamVekalet, ToplamAlacak, RiskTutari, GuncelKarsilik, TakyidatVergiBorclari, ReelKarsilik, OncekiDonemKarsilikTarihi, OncekiDonemKarsilikTutari, NakitTeminat, TeminatMektubu, IpotekTutari, CekToplami, SenetToplami, a.KefaletToplami, RehinTutari, 4_GrupTeminat1, 4_GrupTeminat2, ToplamEkspertizDegeri, ToplamTahsilat, TahsilatAnapara, TahsilatFaiz, TahsilatDiger, Aciklama from dbo.AV001_TDIE_BIL_DOSYA_RISK_RAPORU(nolock) a LEFT JOIN dbo.AV001_TDIE_BIL_RISK_RAPORU_PARAMETRELER(NOLOCK) prm ON prm.RowID != -1 where a.RowID<>-1 " + FiltreyiDuzenle(cn) + " order by FoyNo"); 
                #endregion                
            }
            else if (IslemTipi == IslemTipleri.Listeleme)
            {
                #region listeleme
                ds = new DataSet();
                DataTable dt1 = cn.GetDataTable("select (CASE PeriyotTipi WHEN 0 THEN 'Yıl' WHEN 1 THEN 'Ay' ELSE 'Çeyrek' END) AS PeriyotTipi, PeriyotYil, (CASE PeriyotTipi WHEN 0 THEN '' WHEN 1 THEN (CASE PeriyotAy WHEN 1 THEN 'Ocak' WHEN 2 THEN 'Şubat' WHEN 3 THEN 'Mart' WHEN 4 THEN 'Nisan' WHEN 5 THEN 'Mayıs' WHEN 6 THEN 'Haziran' WHEN 7 THEN 'Temmuz' WHEN 8 THEN 'Ağustos' WHEN 9 THEN 'Eylül' WHEN 10 THEN 'Ekim' WHEN 11 THEN 'Kasım' WHEN 12 THEN 'Aralık' END) WHEN 2 THEN (CASE PeriyotAy WHEN 1 THEN '1. Çeyrek' WHEN 2 THEN '2. Çeyrek' WHEN 3 THEN '3. Çeyrek' WHEN 4 THEN '4. Çeyrek' END) END) AS PeriyotAy, a.RowID, FoyID, FoyNo, DurumID, PeriyotTipi, PeriyotYil, PeriyotAy, SirketKodu, AlacakliSirket, AlacakliSifatiID, SAPMusteriKodu, Borclu_Davali, BorcluSifatiID, TakipTarihi, AdliBirimAdliyeID, AdliBirimNoID, AdliBirimGorevID, EsasNo, DurusmaTarihi, BuroAdi, SorumluAvukat, LeheAleyhe, DosyaTipi, TakipKonusu, KazanmaOrani, BeklenenBitisTarihi, AlacakAnapara, AlacakFaiz, AlacakDigerKalemler, ToplamVergi, Masraflar, ToplamVekalet, ToplamAlacak, RiskTutari, GuncelKarsilik, TakyidatVergiBorclari, ReelKarsilik, OncekiDonemKarsilikTarihi, OncekiDonemKarsilikTutari, NakitTeminat, TeminatMektubu, IpotekTutari, CekToplami, SenetToplami, a.KefaletToplami, RehinTutari, 4_GrupTeminat1, 4_GrupTeminat2, ToplamEkspertizDegeri, ToplamTahsilat, TahsilatAnapara, TahsilatFaiz, TahsilatDiger, Aciklama from dbo.AV001_TDIE_BIL_DOSYA_RISK_RAPORU(nolock) a LEFT JOIN dbo.AV001_TDIE_BIL_RISK_RAPORU_PARAMETRELER(NOLOCK) prm ON prm.RowID != -1 where a.RowID<>-1 " + FiltreyiDuzenle(cn) + " order by FoyNo");
                dt1.TableName = "Master";
                ds.Tables.Add(dt1);    
                #endregion             
            }
            else if (IslemTipi == IslemTipleri.Silme)
            {
                #region silme
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    cn.Clear();
                    cn.AddParams("@RowID", gridView1.GetRowCellValue(i, "RowID"));
                    cn.ExcuteQuery("delete from dbo.AV001_TDIE_BIL_DOSYA_RISK_RAPORU where RowID=@RowID");
                } 
                #endregion                
            }
        }

        private void bwListele_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (IslemTipi == IslemTipleri.Listeleme)
                extendedGridControl1.DataSource = ds.Tables["Master"];
            else if (IslemTipi == IslemTipleri.Silme)
                extendedGridControl1.DataSource = null;
            else if (IslemTipi == IslemTipleri.Pivot)
            {
                pGcIcraRapor.Dock = DockStyle.Fill;
                xtraTabPage2.Controls.Add(pGcIcraRapor);
            }

            bwListele.CancelAsync();
            frm.Close(); 
            frm.progressBarControl1.Visible = true;  
        }
    }
}
