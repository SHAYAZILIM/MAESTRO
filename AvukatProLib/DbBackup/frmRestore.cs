using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;

//using ICSharpCode.SharpZipLib;
//using ICSharpCode.SharpZipLib.Zip;
//using ICSharpCode.SharpZipLib.Core;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AvukatProLib.DbBackup
{
    public partial class frmRestore : Form
    {
        public frmRestore()
        {
            InitializeComponent();
        }

        public frmRestore(string startupPath)
        {
            StartupPath = startupPath;
            InitializeComponent();
        }

        private string bakDosyasiZipli;
        private string connectionString;
        private string hedefKlasor;
        private string hedefVeritabani;
        private string StartupPath;

        private void bgwRestore_DoWork(object sender, DoWorkEventArgs e)
        {
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(connectionString);
            csb.InitialCatalog = "master";
            SqlConnection con = new SqlConnection(csb.ConnectionString);
            con.Open();

            StringBuilder sb = new StringBuilder();
            sb.Append("declare @returnvalue int,");
            sb.Append("@path nvarchar(4000)");
            sb.Append("exec @returnvalue = master.dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE',N'Software\\Microsoft\\MSSQLServer\\Setup',N'SQLPath', @path output, 'no_output'");
            sb.Append("select @path");
            SqlCommand comPath = new SqlCommand(sb.ToString(), con);
            string remotePath = comPath.ExecuteScalar().ToString() + "\\";
            if (Directory.Exists(Path.Combine(remotePath, "Data")))
            {
                remotePath = Path.Combine(remotePath, @"Data\");
            }
            string dosyaMdf = remotePath + hedefVeritabani + ".mdf";
            string dosyaLdf = remotePath + hedefVeritabani + ".ldf";

            //string dosyaAdi = bakDosyasiZipli.Replace(".zip",".bak");
            string dosyaAdi = Directory.GetFiles(hedefKlasor, "*.bak")[0];
            string dosyaMdfsiz = bakDosyasiZipli.Replace(".zip", "");
            while (File.Exists(dosyaMdf))
            {
                dosyaMdf = remotePath + hedefVeritabani + "_.mdf";
                dosyaLdf = remotePath + hedefVeritabani + "_.ldf";
            }
            SqlCommand com = new SqlCommand("RESTORE DATABASE " + hedefVeritabani + " FROM  DISK = N'" + dosyaAdi + "' WITH  FILE = 1,  MOVE N'AVP_NHA' TO N'" + dosyaMdf + "',  MOVE N'AVP_NHA_log' TO N'" + dosyaLdf + "'", con);
            com.CommandTimeout = Int32.MaxValue;
            com.ExecuteNonQuery();
            con.Close();
        }

        private void bgwRestore_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(String.Format("Veritabaný kurulumu sýrasýnda hata oluþtu.\r\nLütfen kurulum dosyasýný tekrar çalýþtýrýnýz.\r\nHata: {0}", e.Error.Message));
                Environment.Exit(1);
            }
            progressBar1.Style = ProgressBarStyle.Blocks;
            if (Directory.Exists(hedefKlasor)) Directory.Delete(hedefKlasor, true);
            if (Directory.Exists(StartupPath + "\\SQLEXPR2005")) Directory.Delete(StartupPath + "\\SQLEXPR2005", true);
            MessageBox.Show("Veritabaný Kurulmuþtur.", "Ýþlem Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void bgwZipAc_DoWork(object sender, DoWorkEventArgs e)
        {
            DosyayiAc(bakDosyasiZipli, hedefKlasor);
        }

        private void bgwZipAc_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bgwZipAc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(String.Format("Veritabaný çýkarýlamadý.\r\nLütfen kurulum dosyasýný tekrar çalýþtýrýnýz.\r\nHata: {0}", e.Error.Message));
                Environment.Exit(1);
            }
            bgwRestore.RunWorkerAsync();
            progressBar1.Style = ProgressBarStyle.Marquee;
            label1.Text = "Veritabaný Oluþturuluyor...";
        }

        private void DosyayiAc(string DosyaAdi, string HedefKlasor)
        {
            FastZipEvents myEvents = new FastZipEvents();
            myEvents.Progress += new ICSharpCode.SharpZipLib.Core.ProgressHandler(ZipProgressChanged);

            //  myEvents.CompletedFile += new CompletedFileHandler(ZipFileCompleted);

            FastZip myZip = new FastZip(myEvents);
            myZip.CreateEmptyDirectories = false;

            myZip.ExtractZip(DosyaAdi, HedefKlasor, FastZip.Overwrite.Always, null, string.Empty, string.Empty, true);
        }

        private void frmRestore_Load(object sender, EventArgs e)
        {
            //"Data Source=.\\AVPSQL;User ID=sa;Pwd=123;Initial Catalog=kaya_avp","e:\\kaya\\eski2.zip","e:\\kaya\\export","kaya_avpDeneme"
            //System.Diagnostics.Debugger.Break();
            if (String.IsNullOrEmpty(StartupPath)) StartupPath = Application.StartupPath;
            this.Visible = false;
            List<CompInfo> cmps = CompInfo.CmpNfoList;

            string masterConnectionString = string.Empty;

            if (cmps.Count > 0)
            {
                foreach (CompInfo ci in cmps)
                {
                    connectionString = ci.ConStr;
                    SqlConnectionStringBuilder csa = new SqlConnectionStringBuilder(connectionString);
                    hedefVeritabani = csa.InitialCatalog;
                    csa.InitialCatalog = "master";
                    masterConnectionString = csa.ConnectionString;
                    hedefKlasor = StartupPath + "\\DB_BACKUP";
                    bakDosyasiZipli = hedefKlasor + "\\backup.zip";
                }
            }
            else
            {
                Application.Exit();
            }
            SqlConnection cnn = new SqlConnection(masterConnectionString);
            cnn.Open();
            SqlCommand cmdCheck = new SqlCommand("select count(*) from sys.databases where name=@dbAdi", cnn);
            cmdCheck.Parameters.AddWithValue("@dbAdi", hedefVeritabani);

            int sonuc = Convert.ToInt32(cmdCheck.ExecuteScalar());
            cnn.Close();
            if (sonuc == 0)
            {
                label1.Text = "Veritabaný çýkarýlýyor...";
                bgwZipAc.RunWorkerAsync();
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                Application.Exit();
            }

            ////////////////////////////
        }

        private void ZipProgressChanged(object sender, ICSharpCode.SharpZipLib.Core.ProgressEventArgs e)
        {
            bgwZipAc.ReportProgress((int)e.PercentComplete, e.Name);
        }
    }
}