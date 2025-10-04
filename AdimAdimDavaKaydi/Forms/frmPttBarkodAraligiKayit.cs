using AvukatProLib;
using DevExpress.XtraEditors;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmPttBarkodAraligiKayit : XtraForm
    {
        public frmPttBarkodAraligiKayit()
        {
            InitializeComponent();
        }

        private CompInfo smtpInfo = CompInfo.CmpNfoList[0];

        static public string Coz(string cozVeri)
        {
            try
            {
                byte[] cozByteDizi = System.Convert.FromBase64String(cozVeri);

                string orjinalVeri = System.Text.ASCIIEncoding.ASCII.GetString(cozByteDizi);

                return orjinalVeri;
            }
            catch (Exception)
            {
                MessageBox.Show("girdiğiniz kod geçerli değildir");
                return "";
            }
        }

        private void btnTaahhudluOnay_Click(object sender, EventArgs e)
        {
            try
            {
                string cozulmus = Coz(txtBoxTaahhutluOnayKodu.Text);
                if (cozulmus != "")
                {
                    string myText = cozulmus;
                    string[] myArray = myText.Split(':');
                    string _barkodBaslangic = "";
                    string _adet = "";
                    int _barkodTür = 0;
                    for (int i = 0; i < myArray.Length; i++)
                    {
                        if (i == 0)
                        {
                            _barkodTür = Convert.ToInt32(myArray[i].ToString());

                            // _musteriId = myArray[i];
                        }
                        else if (i == 1)
                        {
                            _barkodBaslangic = myArray[i];

                            // _yilSonikiHane = myArray[i];
                            //  _yil = SpacialCharConvertToint(_yilSonikiHane[0].ToString()).ToString() + SpacialCharConvertToint(_yilSonikiHane[1].ToString()).ToString();
                        }
                        else if (i == 2)
                        {
                            _adet = myArray[i];

                            // _barkodBaslangic = myArray[i].ToString();
                        }
                        else if (i == 3)
                        {
                            // _ayDegismis = myArray[i];
                            //  _ay = SpacialCharConvertToint(_ayDegismis).ToString();
                        }
                        else if (i == 4)
                        {
                            //  _adet = myArray[i];
                        }
                        else if (i == 5)
                        {
                            //  _gunDegismis = myArray[i];
                            //  _gun = SpacialCharConvertToint(_gunDegismis).ToString();
                        }
                    }

                    //    if (Convert.ToInt32(_yil) == Convert.ToInt32(DateTime.Now.Year.ToString()[DateTime.Now.Year.ToString().Length - 2].ToString() + DateTime.Now.Year.ToString()[DateTime.Now.Year.ToString().Length - 1].ToString()) && Convert.ToInt32(_ay) == DateTime.Now.Month && Convert.ToInt32(_gun) == Convert.ToInt32(DateTime.Now.Day.ToString()))
                    if (_barkodTür == 1)
                    {
                        MessageBox.Show("Tanımlı Onay Kodu, Tebligat Barkod tipindedir. Tebligat Barkod ekranından ekleyiniz");
                    }
                    else if (_barkodTür == 2)
                    {
                        SqlConnection con = new SqlConnection(smtpInfo.ConStr);
                        con.Open();
                        SqlCommand cmd1 = new SqlCommand("INSERT INTO [dbo].[AV001_TDI_BIL_PTT_BARKOD_TANIMLAMA]([TARIHI],[BARKOD_TIPI],[BARKOD_BASLANGICI],[BARKOD_ADEDI],[KULLANILABILIR_ILK_BARKOD],[ACIKLAMA],[AKTIFMI])VALUES(getdate() ,2,'" + _barkodBaslangic + "'," + Convert.ToInt32(_adet) + ",'" + _barkodBaslangic + "','Tebligat Barkod',1)", con);
                        cmd1.ExecuteNonQuery();
                        cmd1.Dispose();
                        con.Close();
                        con.Dispose();
                        MessageBox.Show("işlem başarılı, Taahhütlü Barkod başlangıcı :" + _barkodBaslangic + " adeti :" + _adet + " Tanımlanmıştır");
                        txtBoxTaahhutluOnayKodu.Text = "";
                    }
                    else if (_barkodTür == 4)
                    {
                        MessageBox.Show("Tanımlı Onay Kodu, Tebligat APS Barkod tipindedir. Tebligat APS Barkod ekranından ekleyiniz");
                    }
                }
                else
                {
                    txtBoxTaahhutluOnayKodu.Text = "";
                }
            }
            catch (Exception)
            {
                txtBoxTaahhutluOnayKodu.Text = "";
                MessageBox.Show("girdiğiniz kod geçerli değildir");
            }
        }

        private void btnTaahhutluBarkodIste_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Barkod aralığı tanımlamak ve Onay Kodu almak için Avukatpro ile iletişime geçiniz");
            groupBox1.Visible = true;
        }

        private void btnTebligatAPSBarkodIste_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Barkod aralığı tanımlamak ve Onay Kodu almak için Avukatpro ile iletişime geçiniz");
            groupBox3.Visible = true;
        }

        private void btnTebligatAPSOnay_Click(object sender, EventArgs e)
        {
            try
            {
                string cozulmus = Coz(txtBoxTebligatAPSOnayKodu.Text);
                if (cozulmus != "")
                {
                    string myText = cozulmus;
                    string[] myArray = myText.Split(':');
                    string _barkodBaslangic = "";
                    string _adet = "";
                    int _barkodTür = 0;
                    for (int i = 0; i < myArray.Length; i++)
                    {
                        if (i == 0)
                        {
                            _barkodTür = Convert.ToInt32(myArray[i].ToString());

                            // _musteriId = myArray[i];
                        }
                        else if (i == 1)
                        {
                            _barkodBaslangic = myArray[i];

                            // _yilSonikiHane = myArray[i];
                            //  _yil = SpacialCharConvertToint(_yilSonikiHane[0].ToString()).ToString() + SpacialCharConvertToint(_yilSonikiHane[1].ToString()).ToString();
                        }
                        else if (i == 2)
                        {
                            _adet = myArray[i];

                            // _barkodBaslangic = myArray[i].ToString();
                        }
                        else if (i == 3)
                        {
                            // _ayDegismis = myArray[i];
                            //  _ay = SpacialCharConvertToint(_ayDegismis).ToString();
                        }
                        else if (i == 4)
                        {
                            //  _adet = myArray[i];
                        }
                        else if (i == 5)
                        {
                            //  _gunDegismis = myArray[i];
                            //  _gun = SpacialCharConvertToint(_gunDegismis).ToString();
                        }
                    }

                    //    if (Convert.ToInt32(_yil) == Convert.ToInt32(DateTime.Now.Year.ToString()[DateTime.Now.Year.ToString().Length - 2].ToString() + DateTime.Now.Year.ToString()[DateTime.Now.Year.ToString().Length - 1].ToString()) && Convert.ToInt32(_ay) == DateTime.Now.Month && Convert.ToInt32(_gun) == Convert.ToInt32(DateTime.Now.Day.ToString()))
                    if (_barkodTür == 1)
                    {
                        MessageBox.Show("Tanımlı Onay Kodu, Tebligat Barkod tipindedir. Tebligat Barkod ekranından ekleyiniz");
                    }
                    else if (_barkodTür == 2)
                    {
                        MessageBox.Show("Tanımlı Onay Kodu, Taahhütlü Barkod tipindedir. Taahhüdlü Barkod ekranından ekleyiniz");
                    }
                    else if (_barkodTür == 4)
                    {
                        SqlConnection con = new SqlConnection(smtpInfo.ConStr);
                        con.Open();
                        SqlCommand cmd1 = new SqlCommand("INSERT INTO [dbo].[AV001_TDI_BIL_PTT_BARKOD_TANIMLAMA]([TARIHI],[BARKOD_TIPI],[BARKOD_BASLANGICI],[BARKOD_ADEDI],[KULLANILABILIR_ILK_BARKOD],[ACIKLAMA],[AKTIFMI])VALUES(getdate() ,4,'" + _barkodBaslangic + "'," + Convert.ToInt32(_adet) + ",'" + _barkodBaslangic + "','Tebligat Barkod',1)", con);
                        cmd1.ExecuteNonQuery();
                        cmd1.Dispose();
                        con.Close();
                        con.Dispose();
                        MessageBox.Show("işlem başarılı, Tebligat APS Barkod başlangıcı :" + _barkodBaslangic + " adeti :" + _adet + " Tanımlanmıştır");
                        txtBoxTebligatAPSOnayKodu.Text = "";
                    }
                }
                else
                {
                    txtBoxTebligatAPSOnayKodu.Text = "";
                }
            }
            catch (Exception)
            {
                txtBoxTebligatAPSOnayKodu.Text = "";
                MessageBox.Show("girdiğiniz kod geçerli değildir");
            }
        }

        private void btnTebligatBarkodIste_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Barkod aralığı tanımlamak ve Onay Kodu almak için Avukatpro ile iletişime geçiniz");
            groupBox2.Visible = true;
        }

        private void btnTebligatOnay_Click(object sender, EventArgs e)
        {
            try
            {
                string cozulmus = Coz(txtBoxTebligatOnayKodu.Text);
                if (cozulmus != "")
                {
                    string myText = cozulmus;
                    string[] myArray = myText.Split(':');
                    string _barkodBaslangic = "";
                    string _adet = "";
                    int _barkodTür = 0;
                    for (int i = 0; i < myArray.Length; i++)
                    {
                        if (i == 0)
                        {
                            _barkodTür = Convert.ToInt32(myArray[i].ToString());

                            // _musteriId = myArray[i];
                        }
                        else if (i == 1)
                        {
                            _barkodBaslangic = myArray[i];

                            // _yilSonikiHane = myArray[i];
                            //  _yil = SpacialCharConvertToint(_yilSonikiHane[0].ToString()).ToString() + SpacialCharConvertToint(_yilSonikiHane[1].ToString()).ToString();
                        }
                        else if (i == 2)
                        {
                            _adet = myArray[i];

                            // _barkodBaslangic = myArray[i].ToString();
                        }
                        else if (i == 3)
                        {
                            // _ayDegismis = myArray[i];
                            //  _ay = SpacialCharConvertToint(_ayDegismis).ToString();
                        }
                        else if (i == 4)
                        {
                            //  _adet = myArray[i];
                        }
                        else if (i == 5)
                        {
                            //  _gunDegismis = myArray[i];
                            //  _gun = SpacialCharConvertToint(_gunDegismis).ToString();
                        }
                    }

                    //    if (Convert.ToInt32(_yil) == Convert.ToInt32(DateTime.Now.Year.ToString()[DateTime.Now.Year.ToString().Length - 2].ToString() + DateTime.Now.Year.ToString()[DateTime.Now.Year.ToString().Length - 1].ToString()) && Convert.ToInt32(_ay) == DateTime.Now.Month && Convert.ToInt32(_gun) == Convert.ToInt32(DateTime.Now.Day.ToString()))
                    if (_barkodTür == 1)
                    {
                        SqlConnection con = new SqlConnection(smtpInfo.ConStr);
                        con.Open();
                        SqlCommand cmd1 = new SqlCommand("INSERT INTO [dbo].[AV001_TDI_BIL_PTT_BARKOD_TANIMLAMA]([TARIHI],[BARKOD_TIPI],[BARKOD_BASLANGICI],[BARKOD_ADEDI],[KULLANILABILIR_ILK_BARKOD],[ACIKLAMA],[AKTIFMI])VALUES(getdate() ,1,'" + _barkodBaslangic + "'," + Convert.ToInt32(_adet) + ",'" + _barkodBaslangic + "','Tebligat Barkod',1)", con);
                        cmd1.ExecuteNonQuery();
                        cmd1.Dispose();
                        con.Close();
                        con.Dispose();
                        #region
                        //if (AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAraligiBaslangic1 == "" || AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAraligiBaslangic1 == null)
                        //{
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAraligiBaslangic1 = _barkodBaslangic;
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.Save();
                        //}
                        //else if (AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAraligiBaslangic1 != "" && AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAraligiBaslangic2 != "")
                        //{
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAraligiBaslangic1 = AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAraligiBaslangic2;
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAraligiBaslangic2 = _barkodBaslangic;
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.Save();
                        //}
                        //else
                        //{
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAraligiBaslangic2 = _barkodBaslangic;
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.Save();
                        //}
                        //if (AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAdet1 == 0)
                        //{
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAdet1 = Convert.ToInt32(_adet);
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.Save();
                        //}
                        //else if (AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAdet1 != 0 && AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAdet2 != 0)
                        //{
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAdet1 = AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAdet2;
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAdet2 = Convert.ToInt32(_adet);
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.Save();
                        //}
                        //else
                        //{
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAdet2 = Convert.ToInt32(_adet);
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.Save();
                        //}
                        #endregion
                        MessageBox.Show("işlem başarılı, tebligat barkod başlangıcı :" + _barkodBaslangic + " adeti :" + _adet + " Tanımlanmıştır");
                        txtBoxTebligatOnayKodu.Text = "";
                    }
                    else if (_barkodTür == 2)
                    {
                        #region
                        //if (AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAraligiBaslangic1 == "" || AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAraligiBaslangic1 == null)
                        //{
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAraligiBaslangic1 = _barkodBaslangic;
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.Save();
                        //}
                        //else if (AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAraligiBaslangic1 != "" && AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAraligiBaslangic2 != "")
                        //{
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAraligiBaslangic1 = AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAraligiBaslangic2;
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAraligiBaslangic2 = _barkodBaslangic;
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.Save();
                        //}
                        //else
                        //{
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAraligiBaslangic2 = _barkodBaslangic;
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.Save();
                        //}
                        //if (AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAdet1 == 0)
                        //{
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAdet1 = Convert.ToInt32(_adet);
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.Save();
                        //}
                        //else if (AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAdet1 != 0 && AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAdet2 != 0)
                        //{
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAdet1 = AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAdet2;
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAdet2 = Convert.ToInt32(_adet);
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.Save();
                        //}
                        //else
                        //{
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.TebligatBarkodAdet2 = Convert.ToInt32(_adet);
                        //    AdimAdimDavaKaydi.Properties.Settings.Default.Save();
                        //}
                        #endregion
                        MessageBox.Show("Tanımlı Onay Kodu, Taahhütlü Barkod tipindedir. Taahhüdlü Barkod ekranından ekleyiniz");
                    }
                    else if (_barkodTür == 4)
                    {
                        MessageBox.Show("Tanımlı Onay Kodu, Tebligat APS Barkod tipindedir. Tebligat APS Barkod ekranından ekleyiniz");
                    }
                }
                else
                {
                    txtBoxTebligatOnayKodu.Text = "";
                }
            }
            catch (Exception)
            {
                txtBoxTebligatOnayKodu.Text = "";
                MessageBox.Show("girdiğiniz kod geçerli değildir");
            }
        }

        private void frmPttBarkodAraligiKayit_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(smtpInfo.ConStr);
            con.Open();
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            int TaahhutluKalan = 0;
            int TebligatBarkodKalan = 0;
            int TebligatAPSBarkodKalan = 0;
            SqlCommand cmd1 = new SqlCommand("select ID, TARIHI, BARKOD_TIPI, BARKOD_BASLANGICI, BARKOD_ADEDI, KULLANILABILIR_ILK_BARKOD, ACIKLAMA, AKTIFMI from dbo.AV001_TDI_BIL_PTT_BARKOD_TANIMLAMA", con);
            SqlDataReader rdr = cmd1.ExecuteReader();
            while (rdr.Read())
            {
                if (rdr[2].ToString() == "1" && rdr[7].ToString() == "True")
                {
                    TebligatBarkodKalan = TebligatBarkodKalan + Convert.ToInt32(rdr[4].ToString()) - Convert.ToInt32(rdr[5].ToString().Substring(12 - rdr[4].ToString().Length, rdr[4].ToString().Length));
                }
                else if (rdr[2].ToString() == "2" && rdr[7].ToString() == "True")
                {
                    TaahhutluKalan = TaahhutluKalan + Convert.ToInt32(rdr[4].ToString()) - Convert.ToInt32(rdr[5].ToString().Substring(12 - rdr[4].ToString().Length, rdr[4].ToString().Length));
                }
                else if (rdr[2].ToString() == "4" && rdr[7].ToString() == "True")
                {
                    TebligatAPSBarkodKalan = TebligatAPSBarkodKalan + Convert.ToInt32(rdr[4].ToString()) - Convert.ToInt32(rdr[5].ToString().Substring(12 - rdr[4].ToString().Length, rdr[4].ToString().Length));
                }
            }
            lblTahhutKalan.Text = TaahhutluKalan.ToString();
            lblTebligatKalan.Text = TebligatBarkodKalan.ToString();
            lblTebligatAPSKalan.Text = TebligatAPSBarkodKalan.ToString();
            rdr.Close();
            rdr.Dispose();
            cmd1.Dispose();
            con.Close();
            con.Dispose();
        }
    }
}