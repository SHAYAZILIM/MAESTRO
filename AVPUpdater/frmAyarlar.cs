using AvukatProLib;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Alerter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AVPUpdater
{
    public partial class frmAyarlar : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        static Degiskenler _Degiskenler;
        public static Degiskenler Degiskenler
        {
            get
            {
                if (_Degiskenler == null)
                {
                    _Degiskenler = Degiskenler.Load();
                }
                return _Degiskenler;
            }
        }
        public frmAyarlar()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        #region metotlar

        private void Ac()
        {
            btnKapat.Enabled = true;
            btnGizle.Enabled = true;
            btnKaydet.Enabled = true;
            btnYukle.Enabled = true;
            btnKontrolEt.Enabled = true;
            barbtnTemizle.Enabled = true;

            xtraTabControl1.TabPages[0].PageVisible = true;
            xtraTabControl1.TabPages[1].PageVisible = true;
            xtraTabControl1.TabPages[2].PageVisible = true;
            xtraTabControl1.TabPages[3].PageVisible = true;

            contextMenuStrip1.Enabled = true;

            lblDurum.Text = "Yeni Nesil 2013 Update Servisi";

            xtraTabControl1.TabPages[4].PageVisible = false;
        }

        private void DegerleriYukle()
        {
            try
            {
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Degiskenler.cnString;
                cn.AddParams("@LisansNo", Degiskenler.LisansNo);
                lblYuklemeTarihi.Text = cn.ExecuteScalar("select top(1) convert(varchar(10),Tarih,104) as SonGuncellemeTarihi from dbo.GuncellemeGecmisi(nolock) a where a.LisansNo=@LisansNo order by a.Tarih desc, a.BaslamaSaati desc").ToString();
                lblVersiyon.Text = Degiskenler.GuncelVersiyon;
                lblSurum.Text = Degiskenler.GuncelSurum;
            }
            catch { ;}

            cmbKontrolTipi.SelectedIndex = (int)Degiskenler.KontrolTipi;
            cmbKontrolGunu.SelectedIndex = (int)Degiskenler.KontrolGunu;
            timeKontrolSaati.Time = Degiskenler.KontrolSaati;

            chkProgramiGuncelle.Checked = Degiskenler.ProgramiGuncelle;

            chkVeritabaniYedigAlinsin.Checked = Degiskenler.VeritabaniYedegiAlinsin;

            if (string.IsNullOrEmpty(Degiskenler.ProgramYedekKlasoru))
            {
                if (!Directory.Exists(Application.StartupPath + "/ProgramYedek"))
                    Directory.CreateDirectory(Application.StartupPath + "/ProgramYedek");

                beProgramYedekKlasoru.Text = Application.StartupPath + "/ProgramYedek";
            }
            else
                beProgramYedekKlasoru.Text = Degiskenler.ProgramYedekKlasoru;

            if (string.IsNullOrEmpty(Degiskenler.SQLYedekKlasoru))
            {
                if (!Directory.Exists(Application.StartupPath + "/SQLYedek"))
                    Directory.CreateDirectory(Application.StartupPath + "/SQLYedek");

                beSQLYedekKlasoru.Text = Application.StartupPath + "/SQLYedek";
            }
            else
                beSQLYedekKlasoru.Text = Degiskenler.SQLYedekKlasoru;

            txtSunucuAdresi.Text = Degiskenler.SunucuAdresi;

            Gecmis();
        }

        private void Gecmis()
        {
            listView1.Items.Clear();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Degiskenler.cnString;
            cn.AddParams("@LisansNo", Degiskenler.LisansNo);
            DataTable dt = cn.GetDataTable("select b.Versiyon, b.Surum, a.IslemTipi, convert(varchar(10),a.Tarih,104) as Tarih, convert(varchar(8),a.BaslamaSaati) as BaslamaSaati, convert(varchar(8),a.BitisSaati) as BitisSaati, a.IslemSonucu, isnull(b.Aciklama,'') as Aciklama from (select IslemTipi, Tarih, BaslamaSaati, BitisSaati, IslemSonucu, LisansNo, VersiyonID from dbo.GuncellemeGecmisi(nolock) where LisansNo=@LisansNo) a left join dbo.Versiyon(nolock) b on b.RowID=a.VersiyonID order by Tarih, BaslamaSaati");

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem li = new ListViewItem();
                li.Text = row["IslemTipi"].ToString();

                if (row["IslemTipi"].ToString() == "Kurulum")
                {
                    li.ImageKey = "install";
                    li.SubItems.Add(Degiskenler.GuncelVersiyon);
                    li.SubItems.Add(Degiskenler.GuncelSurum);
                }
                else
                {
                    li.ImageKey = "update";
                    li.SubItems.Add(row["Versiyon"].ToString());
                    li.SubItems.Add(row["Surum"].ToString());
                }
                li.SubItems.Add(row["Tarih"].ToString());
                li.SubItems.Add(row["BaslamaSaati"].ToString());
                li.SubItems.Add(row["BitisSaati"].ToString());
                li.SubItems.Add(row["IslemSonucu"].ToString());
                li.SubItems.Add(row["Aciklama"].ToString());

                listView1.Items.Add(li);
            }
        }

        private void GioKaydet()
        {
            List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
            CompInfo cmpNfo = cmpNfoList[0];
            if (!string.IsNullOrEmpty(lblVersiyon2.Text.Trim()))
            {
                cmpNfo.Versiyon = lblVersiyon2.Text;
                cmpNfo.Surum = lblSurum2.Text;
                Degiskenler.GuncelSurum = cmpNfo.Surum;
                Degiskenler.GuncelVersiyon = cmpNfo.Versiyon;
                Degiskenler.Kaydet();
            }
            cmpNfo.YeniEski = "Yeni Kurulum";
            CompInfo.Kaydet(cmpNfoList, Application.StartupPath);

            try
            {
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Degiskenler.cnString;
                cn.AddParams("@LisansNo", Degiskenler.LisansNo);
                cn.AddParams("@BitisSaati", DateTime.Now);
                cn.AddParams("@IslemSonucu", "Güncelleme Tamamlandı.");
                cn.ExcuteQuery("update dbo.GuncellemeGecmisi set BitisSaati=@BitisSaati,IslemSonucu=@IslemSonucu where LisansNo=@LisansNo and IslemTipi='Güncelleme'");
            }
            catch { ;}
        }

        private void GioOku()
        {
            List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
            CompInfo cmpNfo = cmpNfoList[0];
            if (File.Exists(Application.StartupPath + "\\temp.ab"))
            {
                FileStream fs = new FileStream(Application.StartupPath + "\\temp.ab", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                DateTime dt = DateTime.Now;
                DateTime dt2 = DateTime.Now;
                cmpNfo.BilgisayarID = sr.ReadLine();
                cmpNfo.LisansNo = sr.ReadLine();
                try
                {
                    dt = DateTime.ParseExact(sr.ReadLine(), "dd.mm.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    dt2 = DateTime.ParseExact(sr.ReadLine(), "dd.mm.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    cmpNfo.BaslangicTarihi = dt;
                    cmpNfo.BitisTarihi = dt2;
                }
                catch { }
                cmpNfo.ModulNo = sr.ReadLine();
                cmpNfo.UrunAdi = sr.ReadLine();
                cmpNfo.Versiyon = sr.ReadLine();
                cmpNfo.Surum = sr.ReadLine();

                cmpNfo.HAVeriTabani = sr.ReadLine();
                cmpNfo.VeriTabaniSunucu = sr.ReadLine();
                cmpNfo.VeriTabanıKullanicisi = sr.ReadLine();

                string sfr = sr.ReadLine();
                cmpNfo.VeriTabaniKullaniciSfr = sfr;
                cmpNfo.SaKullaniciSfr = sfr;
                cmpNfo.CompanyName = sr.ReadLine();
                cmpNfo.UygulamaTipi = sr.ReadLine() == "Server" ? 0 : 1;
                cmpNfo.YeniEski = sr.ReadLine();
                sr.Close();
                sr.Dispose();
                fs.Close();
                fs.Dispose();
                CompInfo.Kaydet(cmpNfoList, Application.StartupPath);
                File.Delete(Application.StartupPath + "\\temp.ab");
            }

            Degiskenler.GuncelVersiyon = cmpNfo.Versiyon;
            Degiskenler.GuncelSurum = cmpNfo.Surum;
            Degiskenler.ModulNo = cmpNfo.ModulNo;
            Degiskenler.LisansNo = cmpNfo.LisansNo;
            Degiskenler.Veritabani = cmpNfo.HAVeriTabani;
            //Degiskenler.cnStringYerel = cmpNfo.ConStr;
            Degiskenler.cnStringYerel = string.Format("data source={0};database={1};uid={2};pwd={3};", cmpNfo.VeriTabaniSunucu, cmpNfo.HAVeriTabani, cmpNfo.VeriTabanıKullanicisi, cmpNfo.VeriTabaniKullaniciSfr);
            Degiskenler.PaketAdi = cmpNfo.UrunAdi;
            Degiskenler.uygulamaTipi = cmpNfo.UygulamaTipi == 0 ? Degiskenler.UygulamaTipi.Server : Degiskenler.UygulamaTipi.Client;
            string sss = cmpNfo.YeniEski;

            chkUpgradeYapildi.Checked = true;
            chkUpgradeYapildi.Enabled = false;

            Degiskenler.Kaydet();
            AVPUpdater.Helper.List = cmpNfoList;
        }

        private void Kilitle()
        {
            btnKapat.Enabled = false;
            btnGizle.Enabled = false;
            btnKaydet.Enabled = false;
            btnYukle.Enabled = false;
            btnKontrolEt.Enabled = false;
            barbtnTemizle.Enabled = false;

            xtraTabControl1.TabPages[0].PageVisible = false;
            xtraTabControl1.TabPages[1].PageVisible = false;
            xtraTabControl1.TabPages[2].PageVisible = false;
            xtraTabControl1.TabPages[3].PageVisible = false;

            contextMenuStrip1.Enabled = false;

            xtraTabControl1.TabPages[4].PageVisible = true;
        }

        private void KontrolEt()
        {
            try
            {
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Degiskenler.cnString;
                cn.AddParams("@ModulNo", Degiskenler.ModulNo);
                cn.AddParams("@Surum", Degiskenler.GuncelSurum);
                cn.AddParams("@LisansNo", Degiskenler.LisansNo);
                cn.AddParams("@Ay", Degiskenler.GuncelSurum.Substring(0, 2));
                cn.AddParams("@Yil", Degiskenler.GuncelSurum.Substring(2, 4));
                cn.AddParams("@SurumSayi", Degiskenler.GuncelSurum.Substring(7, 3));

                //DataTable dt = cn.GetDataTable("select a.Versiyon,a.Surum,convert(varchar(10),a.Tarih,104) as Tarih,isnull(a.Aciklama,'') as Aciklama, a.RowID from dbo.Versiyon(nolock) a inner join dbo.Urunler(nolock) b on b.RowID=a.UrunID inner join dbo.Lisanslar(nolock) c on c.UrunID=b.ModulNo where b.ModulNo=350 and a.Tarih<=c.BitisTarihi and c.LisansNo=@LisansNo and CONVERT(datetime, SUBSTRING(a.Surum,1,2) + '.'+ convert(varchar(2),convert(int,SUBSTRING(a.Surum,8,3)))+'.' + SUBSTRING(a.Surum,3,4)) > CONVERT(datetime,@Ay + '.' + convert(varchar(2),convert(int,@SurumSayi)) + '.' + @Yil) group by a.Versiyon,a.Surum,a.Tarih,a.Aciklama, a.RowID order by a.Tarih , a.Versiyon, CONVERT(datetime, SUBSTRING(a.Surum,1,2) + '.01.' + SUBSTRING(a.Surum,3,4)), SUBSTRING(a.Surum,8,3) DESC");

                DataTable dt = cn.GetDataTable("select a.Versiyon,a.Surum,convert(varchar(10),a.Tarih,104) as Tarih,isnull(a.Aciklama,'') as Aciklama, a.RowID from dbo.Versiyon(nolock) a inner join dbo.Lisanslar(nolock) c on c.UrunID=@ModulNo where a.Tarih<=c.BitisTarihi and c.LisansNo=@LisansNo and CONVERT(datetime, SUBSTRING(a.Surum,1,2) + '.'+ convert(varchar(2),convert(int,SUBSTRING(a.Surum,8,3)))+'.' + SUBSTRING(a.Surum,3,4)) > CONVERT(datetime,@Ay + '.' + convert(varchar(2),convert(int,@SurumSayi)) + '.' + @Yil) group by a.Versiyon,a.Surum,a.Tarih,a.Aciklama, a.RowID order by a.Tarih , a.Versiyon, CONVERT(datetime, SUBSTRING(a.Surum,1,2) + '.01.' + SUBSTRING(a.Surum,3,4)), SUBSTRING(a.Surum,8,3) DESC");

                if (dt.Rows.Count == 0)
                {
                    btnYukle.Enabled = false;
                    lblSurum2.Text = "";
                    lblVersiyon2.Text = "";
                    lblYuklemeTarihi2.Text = "";
                    memoEdit1.Text = "";
                    groupYeniVersiyon.Text = "Yeni Güncelleme Bulunamadı";
                }
                else
                {
                    btnYukle.Enabled = true;
                    lblSurum2.Text = dt.Rows[0]["Surum"].ToString();
                    lblVersiyon2.Text = dt.Rows[0]["Versiyon"].ToString();
                    lblYuklemeTarihi2.Text = dt.Rows[0]["Tarih"].ToString();
                    memoEdit1.Text = dt.Rows[0]["Aciklama"].ToString();
                    Degiskenler.YeniVersiyonID = Convert.ToInt32(dt.Rows[0]["RowID"].ToString());
                    groupYeniVersiyon.Text = "Yeni Güncelleme Bulundu";

                    if (Degiskenler.KontrolTipi == Degiskenler.KontrolTipleri.BanaSor)
                        alertControl1.Show(this, string.Format("Yeni Güncellemeler Bulundu\nSürüm :{0}.{1}", lblVersiyon2.Text, lblSurum2.Text), "");
                    else if (Degiskenler.KontrolTipi == Degiskenler.KontrolTipleri.OtomatikGuncelle)
                        Yukle();
                    Degiskenler.Kaydet();
                }
            }
            catch
            {
                ;
            }

        }

        private void Yukle()
        {
            while (Process.GetProcesses().Any(pr => pr.ProcessName == "avpng" || pr.ProcessName.Contains("Avukatpro") || pr.ProcessName == "Asistan" || pr.ProcessName == "ServerSideServices"))
            {
                foreach (var item in Process.GetProcesses().Where(pr => pr.ProcessName == "avpng" || pr.ProcessName.Contains("Avukatpro") || pr.ProcessName == "Asistan" || pr.ProcessName == "ServerSideServices"))
                {
                    try
                    {
                        item.Kill();
                    }
                    catch { }
                }
            }

            MessageBox.Show("Açık virüs programınız varsa lütfen önce onları kapatın.\nBazı virüs programları zararlı uygulama gibi işlem yapmakta ve güncellemelerinizi engellemektedir.\nProgramımızda bilgisayarınıza zarar verecek kötü amaçlı içerik bulunmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (!Degiskenler.ProgramYedekKlasoru.Contains("\\") & !Degiskenler.ProgramYedekKlasoru.Contains("/"))
                Degiskenler.ProgramYedekKlasoru = Application.StartupPath + "/" + Degiskenler.ProgramYedekKlasoru;

            if (!Degiskenler.SQLYedekKlasoru.Contains("\\") & !Degiskenler.SQLYedekKlasoru.Contains("/"))
                Degiskenler.SQLYedekKlasoru = Application.StartupPath + "/" + Degiskenler.SQLYedekKlasoru;

            if (!Directory.Exists(Degiskenler.ProgramYedekKlasoru))
            {
                if (!Directory.Exists(Application.StartupPath + "\\Yedek"))
                    Directory.CreateDirectory(Application.StartupPath + "\\Yedek");

                if (!Directory.Exists(Application.StartupPath + "\\Yedek\\Program"))
                    Directory.CreateDirectory(Application.StartupPath + "\\Yedek\\Program");

                Degiskenler.ProgramYedekKlasoru = Application.StartupPath + "\\Yedek\\Program";
            }

            if (Degiskenler.VeritabaniYedegiAlinsin)
            {
                if (!Directory.Exists(Degiskenler.SQLYedekKlasoru))
                {
                    if (!Directory.Exists(Application.StartupPath + "\\Yedek"))
                        Directory.CreateDirectory(Application.StartupPath + "\\Yedek");

                    if (!Directory.Exists(Application.StartupPath + "\\Yedek\\SQL"))
                        Directory.CreateDirectory(Application.StartupPath + "\\Yedek\\SQL");

                    Degiskenler.SQLYedekKlasoru = Application.StartupPath + "\\Yedek\\SQL";
                }
            }
            Degiskenler.Kaydet();
            if (File.Exists(Application.StartupPath + "/updating.tmp"))
                File.Delete(Application.StartupPath + "/updating.tmp");

            File.Create(Application.StartupPath + "/updating.tmp");
            
            Kilitle();
            progressBarControl1.Position = 0;
            progressBarControl2.Position = 0;

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Degiskenler.cnString;
            cn.AddParams("@LisansNo", Degiskenler.LisansNo);
            cn.AddParams("@BaslamaSaati", DateTime.Now);
            cn.AddParams("@VersiyonID", Degiskenler.YeniVersiyonID);
            cn.ExcuteQuery("insert into dbo.GuncellemeGecmisi (Tarih, LisansNo, BaslamaSaati, IslemSonucu, IslemTipi, VersiyonID) values (getdate(), @LisansNo, @BaslamaSaati, '', 'Güncelleme', @VersiyonID)");

            if (!Degiskenler.DosyaIndirmeYapildi)
            {
                if (Directory.Exists(Application.StartupPath + "/Download"))
                    Directory.Delete(Application.StartupPath + "/Download", true);

                Directory.CreateDirectory(Application.StartupPath + "/Download");
            }

            #region sql backup

            if (Degiskenler.VeritabaniYedegiAlinsin)
            {
                if (!Degiskenler.SqlYedekAlindi)
                {
                    try
                    {
                        string TarihDosyaAdi = DateTime.Today.Day.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                        cn.CnString = Degiskenler.cnStringYerel;

                        lblDurum.Text = "Veritabanı yedeği alınıyor...";

                        progressBarControl2.Properties.Maximum = 100;
                        progressBarControl2.Position = 40;

                        SqlConnection con = new SqlConnection(Degiskenler.cnStringYerel);
                        if (con.State == System.Data.ConnectionState.Closed)
                            con.Open();

                        SqlCommand cmd = new SqlCommand("backup database " + Degiskenler.Veritabani + " to disk = '" + Degiskenler.SQLYedekKlasoru + "\\" + TarihDosyaAdi + ".bak' with INIT", con);
                        cmd.CommandTimeout = 999999999;
                        Thread.Sleep(1000);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch
                    {
                        MessageBox.Show("Veritabanı yedeği alınamadı.\n* Yedek klasörüne yazma yetkinizi kontrol edin.\n* Diste yeterli yeriniz varmı kontrol edin.");
                        Ac();
                        return;
                    }
                }
            }
            Degiskenler.SqlYedekAlindi = true;
            Degiskenler.Kaydet();
            progressBarControl1.Position += 10;
            checkedListBoxControl1.Items[0].CheckState = CheckState.Checked;

            #endregion sql backup

            backgroundWorker1.RunWorkerAsync();
        }

        #endregion metotlar

        private Form frmPopup = null;

        public string[] GetFileList(string Folder)
        {
            string Adres = Folder;
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            WebResponse response = null;
            StreamReader reader = null;
            try
            {
                Uri uri = new Uri(Adres);
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(uri);
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(frmAyarlar.Degiskenler.ftpUid, frmAyarlar.Degiskenler.ftpPwd);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                response = reqFTP.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(1254));
                string line = reader.ReadLine();
                while (line != null)
                {
                    //line = line.Replace(lblSurum2.Text + "/","");
                    //line = line.Replace("SQLSCRIPTS/", "");

                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1).Replace(lblSurum2.Text + "/", "");
                return result.ToString().Split('\n');
            }
            catch
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                downloadFiles = null;
                return downloadFiles;
            }
        }



        private void alertControl1_BeforeFormShow(object sender, AlertFormEventArgs e)
        {
            frmPopup = e.AlertForm;
        }

        private void alertControl1_ButtonClick(object sender, DevExpress.XtraBars.Alerter.AlertButtonClickEventArgs e)
        {
            if (e.ButtonName == "alertBtnYukle")
            {
                Yukle();
                frmPopup.Close();
            }
            else
                frmPopup.Close();
        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            xtraTabControl1.SelectedTabPageIndex = 1;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string TarihDosyaAdi = DateTime.Today.Day.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Degiskenler.cnStringYerel;
            string DosyaYolu = "/Download/SQLSCRIPTS";
            #region dosya yedek

            if (!chkProgYedekAlma.Checked)
            {
                if (!Degiskenler.ProgramYedekAlindi)
                {
                    try
                    {
                        lblDurum.Text = "Program dosyalarının yedeği alınıyor...";

                        progressBarControl2.Properties.Maximum = Convert.ToInt32(GetDirectorySize(Application.StartupPath));
                        progressBarControl2.Position = 0;

                        DirectoryCopy(Application.StartupPath, Degiskenler.ProgramYedekKlasoru + "/" + TarihDosyaAdi, true);
                    }
                    catch { ;}
                }
            }
            Degiskenler.ProgramYedekAlindi = true;
            Degiskenler.Kaydet();

            progressBarControl1.Position += 10;
            checkedListBoxControl1.Items[1].CheckState = CheckState.Checked;

            #endregion dosya yedek

            #region dosya download

            if (!Degiskenler.DosyaIndirmeYapildi)
            {
                bool indirildi = false;
                if (Degiskenler.ProgramiGuncelle)
                {
                    lblDurum.Text = "Uzak sunucuya bağlantı kuruluyor...";
                    List<string> liste = DosyaListesi();

                    lblDurum.Text = "Program dosyaları indiriliyor...";
                    progressBarControl2.Properties.Maximum = liste.Count;
                    progressBarControl2.Position = 0;

                    foreach (string file in liste)
                    {
                        progressBarControl2.Position++;
                        lblDurum.Text = file + " dosyası indiriliyor...";
                        indirildi = Download(file);
                        if (!indirildi)
                            break;
                    }
                }
                else
                    progressBarControl1.Position += 10;

                Degiskenler.DosyaIndirmeYapildi = indirildi;
                Degiskenler.Kaydet();
            }
            if (!Degiskenler.DosyaIndirmeYapildi)
            {
                MessageBox.Show("Dosya indirme başarısız.");
                return;
            }
            progressBarControl1.Position += 10;
            checkedListBoxControl1.Items[2].CheckState = CheckState.Checked;

            #endregion dosya download

            #region dosya güncelleme

            if (!Degiskenler.DosyaGuncellemeYapildi)
            {
                bool dosyaguncel = false;
                if (Degiskenler.ProgramiGuncelle)
                {
                    lblDurum.Text = "Program dosyaları güncelleniyor...";
                    progressBarControl2.Properties.Maximum = Convert.ToInt32(GetDirectorySize(Application.StartupPath + "/Download"));
                    progressBarControl2.Position = 0;

                    dosyaguncel = DirectoryCopy(Application.StartupPath + "/Download", Application.StartupPath, true);
                }
                else
                    progressBarControl1.Position += 10;

                Degiskenler.DosyaGuncellemeYapildi = dosyaguncel;
                Degiskenler.Kaydet();
            }

            progressBarControl1.Position += 10;
            checkedListBoxControl1.Items[3].CheckState = CheckState.Checked;

            #endregion dosya güncelleme

            if (Degiskenler.uygulamaTipi == Degiskenler.UygulamaTipi.Server)
            {
                DbUpdater updater = new DbUpdater();
                updater.UpdateDb(progressBarControl2, progressBarControl1, lblDurum, checkedListBoxControl1);

                #region tanım güncelleme

                //Thread.Sleep(1000);
                lblDurum.Text = "Scriptler Çalıştırılıyor...";
                if (Directory.Exists(Application.StartupPath + DosyaYolu))
                {
                    var files = Directory.GetFiles(Application.StartupPath + DosyaYolu, "*.sql");
                    foreach (var item in files)
                    {
                        if (progressBarControl2.InvokeRequired)
                        {
                            progressBarControl2.Invoke((MethodInvoker)delegate
                            {
                                progressBarControl2.Properties.Maximum = files.Length;
                                progressBarControl2.Position = 0;
                            });
                        }

                        else
                        {
                            progressBarControl2.Properties.Maximum = files.Length;
                            progressBarControl2.Position = 0;
                        }

                        FileStream fs = new FileStream(item, FileMode.Open);
                        StreamReader sr = new StreamReader(fs, Encoding.GetEncoding(1254));

                        //Thread.Sleep(1000);

                        try
                        {
                            string aa = sr.ReadToEnd();
                            if (!string.IsNullOrEmpty(aa) & aa != "--@Son")
                            {
                                try
                                {
                                    Thread.Sleep(10);
                                    cn.ExcuteQuery(aa);
                                }
                                catch (Exception ex)
                                {
                                    AVPUpdater.Helper.Logger.ErrorException(item, ex);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            AVPUpdater.Helper.Logger.ErrorException(item, ex);
                        }
                        progressBarControl2.Position++;

                        sr.Close();
                        sr.Dispose();
                        fs.Close();
                        fs.Dispose();
                    }
                }
            }
            else
                progressBarControl1.Position += 10;


            progressBarControl1.Position += 10;
            checkedListBoxControl1.Items[7].CheckState = CheckState.Checked;

                #endregion tanım güncelleme

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Ac();

            //if (Degiskenler.DosyaGuncellemeYapildi)
            //{
            //    if (Directory.Exists(Application.StartupPath + "/Download"))
            //        Directory.Delete(Application.StartupPath + "/Download", true);
            //}

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Degiskenler.cnString;
            cn.AddParams("@LisansNo", Degiskenler.LisansNo);
            cn.AddParams("@BitisSaati", DateTime.Now);

            if (Degiskenler.SqlYedekAlindi & Degiskenler.ProgramYedekAlindi & Degiskenler.DosyaIndirmeYapildi & Degiskenler.DosyaGuncellemeYapildi)
                cn.AddParams("@IslemSonucu", "Güncelleme Başarılı");
            else
                cn.AddParams("@IslemSonucu", "Güncelleme Yarım Kaldı");

            cn.ExcuteQuery("update dbo.GuncellemeGecmisi set BitisSaati=@BitisSaati,IslemSonucu=@IslemSonucu where LisansNo=@LisansNo and IslemTipi='Güncelleme'");

            if (Degiskenler.SqlYedekAlindi & Degiskenler.ProgramYedekAlindi & Degiskenler.DosyaIndirmeYapildi & Degiskenler.DosyaGuncellemeYapildi)
            {
                GioKaydet();

                Degiskenler.SqlYedekAlindi = false;
                Degiskenler.ProgramYedekAlindi = false;
                Degiskenler.DosyaIndirmeYapildi = false;
                Degiskenler.DosyaGuncellemeYapildi = false;
                GioKaydet();

                //if (Directory.Exists(Application.StartupPath + "/Download"))
                //    Directory.Delete(Application.StartupPath + "/Download", true);
            }

            GioOku();
            try
            {
                DegerleriYukle();
            }
            catch { ;}
            KontrolEt();

            if (File.Exists(Application.StartupPath + "/updating.tmp"))
                File.Delete(Application.StartupPath + "/updating.tmp");
            Process.Start("AVPUpdaterDevam.exe");
            Application.Exit();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Degiskenler.SqlYedekAlindi = false;
            Degiskenler.ProgramYedekAlindi = false;
            Degiskenler.DosyaIndirmeYapildi = false;
            Degiskenler.DosyaGuncellemeYapildi = false;
            Degiskenler.Kaydet();

            //if (Directory.Exists(Application.StartupPath + "/Download"))
            //    Directory.Delete(Application.StartupPath + "/Download", true);
        }

        private void beProgramYedekKlasoru_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                beProgramYedekKlasoru.Text = folderBrowserDialog1.SelectedPath;
        }

        private void beSQLYedekKlasoru_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                beSQLYedekKlasoru.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnGizle_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Hide();
        }

        private void btnKapat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Güncelleme servisini durdurmak istiyor musunuz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
                this.Close();
            }
        }

        private void btnKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            Degiskenler.KontrolTipi = (Degiskenler.KontrolTipleri)cmbKontrolTipi.SelectedIndex;
            Degiskenler.KontrolGunu = (Degiskenler.Gunler)cmbKontrolGunu.SelectedIndex;
            Degiskenler.KontrolSaati = timeKontrolSaati.Time;

            Degiskenler.ProgramiGuncelle = chkProgramiGuncelle.Checked;
            Degiskenler.VeritabaniYedegiAlinsin = chkVeritabaniYedigAlinsin.Checked;

            Degiskenler.ProgramYedekKlasoru = beProgramYedekKlasoru.Text;
            Degiskenler.SQLYedekKlasoru = beSQLYedekKlasoru.Text;

            Degiskenler.SunucuAdresi = txtSunucuAdresi.Text;
            Degiskenler.Kaydet();
        }

        private void btnKontrolEt_ItemClick(object sender, ItemClickEventArgs e)
        {
            KontrolEt();
        }

        private void btnYukle_ItemClick(object sender, ItemClickEventArgs e)
        {
            Degiskenler.Kaydet();

            Yukle();
        }

        private bool DirectoryCopy(string kaynakKlasör, string hedefKlasör, bool altKlasörlerdeKopyalansınMı)
        {
            DirectoryInfo dir = new DirectoryInfo(kaynakKlasör);
            DirectoryInfo[] dirs = dir.GetDirectories();
            bool returnValue = true;
            if (!Directory.Exists(hedefKlasör))
                Directory.CreateDirectory(hedefKlasör);

            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files.Where(q => q.Name.ToLower() != "avpupdater.exe" && q.Name.ToLower() != "avukatprolib.dll"))
            {
                progressBarControl2.Position = Convert.ToInt32(GetDirectorySize(hedefKlasör));
                string temppath = Path.Combine(hedefKlasör, file.Name);
                try
                {
                    file.CopyTo(temppath, true);
                }
                catch (Exception ex)
                {
                    returnValue = false;
                    MessageBox.Show(ex.Message);
                    AVPUpdater.Helper.Logger.ErrorException("Dosya Kopyalama hatası : " + temppath, ex);
                    break;
                }
            }

            if (altKlasörlerdeKopyalansınMı && returnValue)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    if (!subdir.Name.ToLowerInvariant().Contains("sqlscripts") && !subdir.Name.ToLowerInvariant().Contains("sqlscrıpts") && !subdir.Name.ToLowerInvariant().Contains("sistemturu") && !subdir.Name.ToLowerInvariant().Contains("download") && !subdir.Name.ToLowerInvariant().Contains("yedek"))
                    {
                        progressBarControl2.Position = Convert.ToInt32(GetDirectorySize(hedefKlasör));
                        string geçiciKlasör = Path.Combine(hedefKlasör, subdir.Name);
                        returnValue = DirectoryCopy(subdir.FullName, geçiciKlasör, altKlasörlerdeKopyalansınMı);
                        if (!returnValue)
                            break;
                    }
                }
            }
            return returnValue;
        }


        private List<string> DosyaListesi(string folder = "")
        {
            List<string> list = new List<string>();

            string adres = Degiskenler.SunucuAdresi + "/Avukatprofessional/" + lblVersiyon2.Text + "/" + lblSurum2.Text;

            if (!string.IsNullOrEmpty(folder))
                adres += "/" + folder;

            string[] files = GetFileList(adres);

            if (files != null)
            {
                foreach (var item in files)
                {
                    if (!string.IsNullOrEmpty(Path.GetExtension(item)))
                    {
                        list.Add(item);
                    }
                    else
                    {
                        var dfiles = DosyaListesi(item);
                        if (!string.IsNullOrEmpty(folder))
                            list.AddRange(dfiles.Select(q => folder + "/" + q));
                        else
                            list.AddRange(dfiles);
                    }
                }
            }

            return list;
        }

        private bool Download(string file)
        {
            bool returnValue = false;
            string uri = Degiskenler.SunucuAdresi + "/Avukatprofessional/" + lblVersiyon2.Text + "/" + lblSurum2.Text + "/" + file;
            try
            {
                string[] asd = file.Split('/');
                if (!asd[asd.Length - 1].Contains("."))
                {
                    if (!Directory.Exists(Application.StartupPath + "/Download/" + file))
                        Directory.CreateDirectory(Application.StartupPath + "/Download/" + file);

                    return true;
                }

                Uri serverUri = new Uri(uri);
                if (serverUri.Scheme != Uri.UriSchemeFtp)
                {
                    return false;
                }
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(serverUri);
                reqFTP.Credentials = new NetworkCredential(frmAyarlar.Degiskenler.ftpUid, frmAyarlar.Degiskenler.ftpPwd);
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream responseStream = response.GetResponseStream();

                string folder = "";
                foreach (var item in file.Split('/'))
                {
                    if (string.IsNullOrEmpty(Path.GetExtension(item)))
                    {
                        if (string.IsNullOrEmpty(folder))
                            folder = Application.StartupPath + "/Download/" + item;
                        else
                            folder += "/" + item;

                        if (!Directory.Exists(folder))
                            Directory.CreateDirectory(folder);
                    }
                }

                FileStream writeStream = new FileStream(Application.StartupPath + "/Download/" + file, FileMode.Create);
                int Length = 2048;
                Byte[] buffer = new Byte[Length];
                int bytesRead = responseStream.Read(buffer, 0, Length);
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = responseStream.Read(buffer, 0, Length);
                }
                writeStream.Close();
                response.Close();
                returnValue = true;
            }
            catch (Exception ex)
            {
                returnValue = false;
                AVPUpdater.Helper.Logger.ErrorException("Download Error : " + uri, ex);
                //MessageBox.Show(wEx.Message, "Download Error");

            }
            return returnValue;
        }

        private void ekranıGizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmAyarlar_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Hide();
            //if (!FormKapatilSinMi)
            //    e.Cancel = true;
        }

        private void frmAyarlar_Load(object sender, EventArgs e)
        {
            frmAyarlar.Degiskenler.Kaydet();
            GioOku();
            try
            {
                DegerleriYukle();
            }
            catch { ;}
            KontrolEt();
            xtraTabControl1.SelectedTabPageIndex = 0;
            xtraTabControl1.TabPages[4].PageVisible = false;
            lblDurum.Text = "Maestro 2013 Update Servisi";

            if (Degiskenler.uygulamaTipi == Degiskenler.UygulamaTipi.Client)
                groupVeritabani.Enabled = false;

            if (FormWindowState.Minimized == WindowState)
                Hide();

            this.Text = "Maestro 2013 Update Servisi .::. v1 062013.01";
        }

        private void geçmişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            xtraTabControl1.SelectedTabPageIndex = 3;
        }

        private long GetDirectorySize(string p)
        {
            string[] a = Directory.GetFiles(p, "*.*");

            long b = 0;
            foreach (string name in a)
            {
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            return b;
        }

        private void güncellemeBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            xtraTabControl1.SelectedTabPageIndex = 0;
        }

        private void kontrolEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KontrolEt();
        }

        private void lblDurum_TextChanged(object sender, EventArgs e)
        {
            notifyIcon1.Text = lblDurum.Text.Length > 63 ? ("..." + lblDurum.Text.Substring(lblDurum.Text.Length - 60, 60)) : lblDurum.Text;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            memoEdit2.Text = "";
            try
            {
                memoEdit2.Text = listView1.SelectedItems[0].SubItems[7].Text;
            }
            catch { ;}
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            xtraTabControl1.SelectedTabPageIndex = 0;
        }

        private void servisiKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Güncelleme servisini durdurmak istiyor musunuz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Degiskenler.KontrolTipi != Degiskenler.KontrolTipleri.KontrolEtme)
            {
                if (Degiskenler.KontrolSaati == Convert.ToDateTime("01.01.2012 " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second))
                {
                    if (Degiskenler.KontrolGunu == Degiskenler.Gunler.HerGun)
                        KontrolEt();
                    else if (DateTime.Now.DayOfWeek == DayOfWeek.Monday & Degiskenler.KontrolGunu == Degiskenler.Gunler.HerPazartesi)
                        KontrolEt();
                    else if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday & Degiskenler.KontrolGunu == Degiskenler.Gunler.HerSali)
                        KontrolEt();
                    else if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday & Degiskenler.KontrolGunu == Degiskenler.Gunler.HerCarsamba)
                        KontrolEt();
                    else if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday & Degiskenler.KontrolGunu == Degiskenler.Gunler.HerPersembe)
                        KontrolEt();
                    else if (DateTime.Now.DayOfWeek == DayOfWeek.Friday & Degiskenler.KontrolGunu == Degiskenler.Gunler.HerCuma)
                        KontrolEt();
                    else if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday & Degiskenler.KontrolGunu == Degiskenler.Gunler.HerCumartesi)
                        KontrolEt();
                    else if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday & Degiskenler.KontrolGunu == Degiskenler.Gunler.HerPazar)
                        KontrolEt();
                }
            }
        }

        private void txtSunucuAdresi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmFTPBilgileri frm = new frmFTPBilgileri();
            frm.ShowDialog();
        }

        private void chkProgYedekAlma_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}