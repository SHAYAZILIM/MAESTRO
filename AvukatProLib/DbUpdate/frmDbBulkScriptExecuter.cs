using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AvukatProLib.DbUpdate
{
    public partial class frmDbBulkScriptExecuter : Form
    {
        #region Global'ler

        private int _SuankiSatir;
        private int _ToplamSatir;
        private int buyukHeigt;
        private SqlConnection connection = new SqlConnection();
        private string dosyaPath;
        private bool isError = false;
        private Queue<string> kuyruk = new Queue<string>();
        private SqlTransaction Trans;

        public int ToplamSatir
        {
            get { return _ToplamSatir; }
            set
            {
                _ToplamSatir = value;
                prgProgres.Maximum = value;
                prgProgres.Value = 0;
            }
        }

        private int SuankiSatir
        {
            get { return _SuankiSatir; }
            set
            {
                _SuankiSatir = value;
                prgProgres.Value = value;
                lblBitenleToplam.Text = value.ToString() + "/" + ToplamSatir.ToString();
                double Yuzde = (SuankiSatir * 100) / ToplamSatir;
                lblYuzde.Text = Yuzde.ToString() + "%";
            }
        }

        #endregion Global'ler

        //public frmDbBulkScriptExecuter()
        //{
        //    //connection.ConnectionString = "Data Source=.\\SQL2005;User ID=sa;Pwd=123;Initial Catalog=eski;Connection Timeout=30000;Application Name=Avukatpro Yeni Nesil 2009";
        //    //dosyaPath = Application.StartupPath + "\\";
        //    CheckForIllegalCrossThreadCalls = false;
        //    InitializeComponent();
        //}

        public frmDbBulkScriptExecuter(string ConnectionString, string FilePath)//: this()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            dosyaPath = FilePath;
            connection.ConnectionString = ConnectionString;
            if (!Directory.Exists(FilePath))
            {
                MessageBox.Show("Veritaban� y�kseltme s�r�mleri bulunamad�.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //DbUpdater.logger.Debug("Veritaban� y�kseltme s�r�mleri bulunamad�.");
            }
            if (!dosyaPath.EndsWith("\\"))
            {
                dosyaPath = FilePath + "\\";
            }
        }

        private string dosya = Application.StartupPath + "\\AvukatproLib.Bakim2.dll";

        public void DosyayaYaz(string Yazilacak)
        {
            if (File.Exists(dosya))
            {
                File.Delete(dosya);
            }
            StreamWriter writer = new StreamWriter(dosya);
            writer.Write(Yazilacak);
            writer.Close();
            this.Dispose(true);
        }

        private void bgwSatirSay_DoWork(object sender, DoWorkEventArgs e)
        {
            DosyaKontrol();
        }

        private void bgwSatirSay_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnBasla_Click(sender, e);
        }

        /// <summary>
        /// SQL Komutlar�n� ger�ekle�tiren BackgroundWorker'�m�z.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwTextOku_DoWork(object sender, DoWorkEventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            Trans = connection.BeginTransaction();
            try
            {
                SqlOkuveCalistir(sender, e);
            }
            catch (Exception ex)
            {
                DbUpdater.logger.ErrorException("Hata", ex);
            }
        }

        /// <summary>
        /// Veritaban�na uygulama Thread'inin i�i bitti.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwTextOku_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            if (isError == false)
            {
                this.DialogResult = DialogResult.OK;
                DosyayaYaz("1");
                Trans.Commit();
                lblBasarili.Visible = true;
                btnBasla.Visible = false;
                btnIptal.Visible = false;
            }
            else
            {
                Trans.Rollback();
                MessageBox.Show("Veritaban� Y�kseltme ��lemi Ger�ekle�medi.", "��lem Durumu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //bgwSatirSay.RunWorkerAsync();
                //  this.DialogResult = DialogResult.No;
            }
            txtIslem.Text += DateTime.Now.ToLongTimeString() + "'da bitti." + Environment.NewLine;

            //this.Close();
        }

        /// <summary>
        /// Veritaban�na uygulamaya ba�l�yor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBasla_Click(object sender, EventArgs e)
        {
            if (bgwTextOku.IsBusy == false)
            {
                bgwTextOku.RunWorkerAsync();
                btnIptal.Enabled = true;
                btnBasla.Enabled = false;
            }
        }

        /// <summary>
        /// Thread'i iptal edip, Transaction'� rollback yapmak i�in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIptal_Click(object sender, EventArgs e)
        {
            bgwTextOku.CancelAsync();
            btnIptal.Enabled = false;
        }

        private void DosyaKontrol()
        {
            string changedosya = dosyaPath + "changescript.txt";
            if (File.Exists(changedosya))
            {
                string line;
                StreamReader file = new StreamReader(changedosya, Encoding.GetEncoding(1254));
                int SatirToplami = 0;
                while ((line = file.ReadLine()) != null)
                {
                    string[] satir = line.Split(';');
                    if (satir.Length < 2) break;
                    string Baslik = satir[0];
                    string SQLDosyasi = dosyaPath + satir[1];

                    StreamReader reader = new StreamReader(SQLDosyasi);
                    while (!reader.EndOfStream)
                    {
                        reader.ReadLine();
                        SatirToplami++;
                    }
                    kuyruk.Enqueue(line);
                }
                ToplamSatir = SatirToplami;
                prgProgres.Value = 0;
                SuankiSatir = 0;
            }
            else
            {
                MessageBox.Show(changedosya + " bulunamad�", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
            btnBasla.Enabled = true;
        }

        /// <summary>
        /// CTRL ve SHIFT ile ayr�nt� penceresini a��p kamak i�in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift)
            {
                if (this.Height == btnBasla.Top + 53)
                {
                    this.Height = buyukHeigt;
                }
                else
                {
                    this.Height = btnBasla.Top + 53;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //CTRL ve SHIFT ile ayr�nt� b�l�m�n� a�mak i�in �nceden a��k halinin height'�n� al�yoruz ve formun height'�n� de�i�tiriyoruz.

            buyukHeigt = this.Height;
            this.Height = btnBasla.Top + 53;
            btnBasla.Enabled = false;
        }

        private void frmDbBulkScriptExecuter_Shown(object sender, EventArgs e)
        {
            //Dosya adlar�n� okumas� ve sat�rlar� sayd�r�yoruz.
            bgwSatirSay.RunWorkerAsync();
            lblYuzde.Text = "";
            lblBitenleToplam.Text = "";
        }

        /// <summary>
        /// komutu sql servera g�nderip �al��mas� i�in. sqlokuvecalistir metodundan �al��t�r�l�r.
        /// </summary>
        /// <param name="sender">g�nderen backgroundworker</param>
        /// <param name="e">doworkeventarguments</param>
        /// <param name="sb">stringbuilder</param>
        private void SqlCalistir(object sender, DoWorkEventArgs e, StringBuilder sb)
        {
            sb = sb.Replace("!ARA!" + Environment.NewLine, "");
            SqlCommand com = connection.CreateCommand();
            com.Transaction = Trans;
            com.CommandText = sb.ToString();

            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                txtIslem.Text += ex.Message + Environment.NewLine;
                isError = true;
                e.Cancel = true;

                //SATIR 13 A�IKLAMA
                //DbUpdater.logger.ErrorException("hata", ex);
                DbUpdater.logger.Info("Hata Sat�r no : " + e.Result.ToString());
                DbUpdater.logger.ErrorException("Hata", ex);

                return;
            }
        }

        /// <summary>
        /// Kuyruktan dosya al�r ve �al��t�r�r.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SqlOkuveCalistir(object sender, DoWorkEventArgs e)
        {
            //Kuyruk'tan yeni dosya al�yoruz.
            string dosya = kuyruk.Dequeue();

            //Kuyrukta; "Yap� De�i�imleri;yapidegisimleri.sql" format� oldu�undan, isimi ve sql dosyas�n� ayr� ayr� al�yoruz.
            string Baslik = dosya.Substring(0, dosya.IndexOf(';'));

            //Durum da yap�lan i�lemin ad�n� veriyoruz.
            lblDosyaAciklamasi.Text = Baslik;
            string SQLDosyasi = dosyaPath + dosya.Replace(Baslik + ";", "");

            StreamReader sr = new StreamReader(SQLDosyasi);
            DbUpdater.logger.Info(string.Format("�al��t�r�lan script dosyas� : {0}", SQLDosyasi));
            SqlConnection conn = connection;

            int satir = 0;
            txtIslem.Text += DateTime.Now.ToLongTimeString() + "'da ba�lad�." + Environment.NewLine;
            StringBuilder sb = new StringBuilder();
            while (!sr.EndOfStream)
            {
                //BGW'nin cancel i�lemi olup olmad���n� kontrol ediyoruz.
                if (bgwTextOku.CancellationPending)
                {
                    e.Cancel = true;
                    isError = true;
                    return;
                }

                //Progressbar'da durumu g�ncelliyoruz.
                SuankiSatir++;
                satir++;
                SqlCommand cmd = conn.CreateCommand();
                cmd.Transaction = Trans;
                string s = sr.ReadLine();
                if (s != null && s.ToUpper().Trim().Equals("GO"))
                {
                    //Sat�r�n tamam� GO ise !ARA! ile replace ediyoruz ki; normal GO'lar kar���p olur olmad�k yerlerde execute etmesin.
                    s = "!ARA!";
                }
                if (s != null && s.IndexOf("!ARA!") != -1)
                {
                    e.Result = satir;
                    SqlCalistir(sender, e, sb);

                    //sb = sb.Replace("!ARA!" + Environment.NewLine, "");
                    //cmd.CommandTimeout = Int32.MaxValue;
                    //cmd.CommandText = sb.ToString();
                    //try
                    //{
                    //    cmd.ExecuteNonQuery();
                    //}
                    //catch (Exception ex)
                    //{
                    //    txtIslem.Text+=ex.Message + Environment.NewLine;
                    //    isError = true;
                    //    e.Cancel = true;
                    //    return;
                    //}
                    sb = new StringBuilder();
                }
                sb.AppendLine(s);
            }
            sr.Close();

            //muhtemelen son sat�r �al��mam��t�r. �al��mayan bir�ey varsa �al��t�r�r. zaten 8 karakterden az bir sorgu olmaz. karakter say�s�n� kontrol ediyoruz burada ona g�re �al��t�r�yoruz. altsat�rlarla beraber go lar 7 sat�r tutuyo. bo� sorgu g�nderincede p�t�rd�yo. dolay�s�yla b�yle bir yol izledim.
            if (sb.Length > 8)
            {
                SqlCalistir(sender, e, sb);
            }

            //E�er kuyrukta dosya varsa, onu da yapmas� amac�yla kendisini tekrar �a��r�yor.
            if (kuyruk.Count > 0)
            {
                SqlOkuveCalistir(sender, e);
            }
        }
    }
}