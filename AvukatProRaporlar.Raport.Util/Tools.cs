using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;

//using AvukatProLib;
//using AvukatProRaporlar.Properties;
//using AvukatProRaporlar.UserControls.Sablon_Ajanda_Belge;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace AvukatProRaporlar.Raport.Util
{
    public enum ExtensionToOpenProgram
    {
        doc, docx, xls, xlsx, pdf, html, swf, pst
    }

    public class Tools
    {
        public static byte[] anahtar;

        //static ucBelgeIzlemeBelgeEkle belgeımgList = new ucBelgeIzlemeBelgeEkle();
        //public static object GetKnownFilesSmallIcon(string extension)
        //{
        //    ImageList imgList = belgeımgList.ımageList1;
        //    if (extension == "HTM" || extension == "HTML" || extension == "CSS" || extension == "JSP" || extension == "ASP" || extension == "ASPX" || extension == "PHP" || extension == "PHP3" || extension == "SWF")
        //    {
        //        return imgList.Images["EXPLORER.ico"];
        //    }
        //    if (extension == "PDP" || extension == "RAW" || extension == "PCT" || extension == "PICT" || extension == "PXR" || extension == "PNG" || extension == "PBM" || extension == "PGM" || extension == "PBM" || extension == "PGM" || extension == "PPM" || extension == "PRM" || extension == "PFM" || extension == "JPEG" || extension == "JPG" || extension == "BMP" || extension == "GIF" || extension == "ICO" || extension == "PNG" || extension == "DIB" || extension == "TIFF" || extension == "DCM" || extension == "DC3" || extension == "EPS" || extension == "PSB" || extension == "TGA" || extension == "VDG" || extension == "ICB" || extension == "VST")
        //    {
        //        return imgList.Images["RESIM.ico"];
        //    }
        //    if (extension == "TXT" || extension == "XML" || extension == "XLST" || extension == "XAML" || extension == "XSL" || extension == "RTF" || extension == "LOG" || extension == "CS")
        //    {
        //        return imgList.Images["METIN.ico"];
        //    }
        //    if (extension == "MPEG" || extension == "MPG" || extension == "AVI" || extension == "DIVX" || extension == "RIP" || extension == "3GP" || extension == "MP4" || extension == "MOV" || extension == "ASF" || extension == "MPE" || extension == "QT" || extension == "SMV" || extension == "STR" || extension == "VFW" || extension == "WMV")
        //    {
        //        return imgList.Images["VIDEO.ico"];
        //    }
        //    if (extension == "WAV" || extension == "MP3" || extension == "WMA")
        //    {
        //        return imgList.Images["SES.ico"];
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        public static byte[] Vektor;

        private static string tempPath = Application.StartupPath + "\\Temp\\";

        private static byte[] veri;

        /// <summary>
        /// Application.StartupPath + "\\Temp\\"
        /// </summary>
        public static string TempFilesPath
        {
            get
            {
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }
                return tempPath;
            }
            set { tempPath = value; }
        }

        public static double CmToPixcel(double Cm, bool horizantal)
        {
            double donecek = 0;
            try
            {
                Graphics g = Graphics.FromImage(new Bitmap(1, 1));
                if (horizantal)
                {
                    donecek = (Cm / 2.54) * g.DpiX;
                }
                else
                {
                    donecek = (Cm / 2.54) * g.DpiY;
                }
            }
            catch 
            {
                //MesajKutusu mk = new MesajKutusu();
                //mk.ShowMe("Hata", "İşlem hatası Error Message : 261010", "bu işlemi Gerçekleştirirken isitemde bazı sorunlar meysana geldi...daha sonra başka sorunlarında engellenmesi için işleminiz durdurulmştur...", MessageBoxButtons.OK, "", MessageBoxIcon.Error);
            }
            return donecek;
        }

        public static T DeSerializeClass<T>(string path)
        {
            T returnValue = Activator.CreateInstance<T>();
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    returnValue = (T)bf.Deserialize(fs);
                    fs.Close();
                }
                catch (Exception ex)
                {
                    fs.Close();

                    BelgeUtil.ErrorHandler.Catch(typeof(Tools), ex, false, "");
                }
            }
            else
            {
                File.Create(path);
            }
            return returnValue;
        }

        public static T DeSerializeXml<T>(string path)
        {
            T returnValue = Activator.CreateInstance<T>();
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                try
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    XmlReader xr = XmlReader.Create(fs);
                    if (xs.CanDeserialize(xr))
                    {
                        returnValue = (T)xs.Deserialize(fs);
                    }
                    else
                    {
                        XtraMessageBox.Show(" Hata : Dosya okumada hata ... Dosya Okunamıyor : " + Environment.NewLine + path);
                    }
                    fs.Close();
                }
                catch (Exception ex)
                {
                    fs.Close();

                    BelgeUtil.ErrorHandler.Catch(typeof(Tools), ex, true, "");
                }
            }
            else
            {
                File.Create(path);
            }
            return returnValue;
        }

        public static object FullScreen(Control value)
        {
            Control ExParent;
            Point exPoint = value.Location;
            DockStyle ds = value.Dock;
            Form frm = new Form();
            frm.WindowState = FormWindowState.Maximized;
            frm.ControlBox = false;
            frm.HelpButton = false;
            frm.Text = "";
            frm.FormBorderStyle = FormBorderStyle.None;
            ExParent = value.Parent;
            value.Parent = frm;
            frm.Controls.Add(value);
            SimpleButton btn = new SimpleButton();
            btn.Dock = DockStyle.Top;
            btn.Text = "Kapat";
            frm.TopMost = true;
            frm.Controls.Add(btn);
            value.BringToFront();
            btn.Click += new EventHandler(delegate(object sender, EventArgs e)
            {
                frm.Close();
            });
            frm.ShowDialog();

            value.Parent = ExParent;
            ExParent.Controls.Add(value);
            value.Dock = ds;
            value.Location = exPoint;
            ExParent.Refresh();
            value.Refresh();
            ExParent.Invalidate();
            value.Invalidate();
            return value;
        }

        public static string GetMailsFromOutlook()
        {
            return "";
            // Microsoft.Office.Interop.Outlook.Application oOutlook;
            // Microsoft.Office.Interop.Outlook.NameSpace oNs;
            // Microsoft.Office.Interop.Outlook.MAPIFolder oFldr; long iAttachCnt; StringBuilder str
            // = new StringBuilder(); try { oOutlook = new
            // Microsoft.Office.Interop.Outlook.Application(); oNs = oOutlook.GetNamespace("MAPI");

            // //getting mail folder from inbox oFldr =
            // oNs.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
            // str.Append("Total Mail(s) in Inbox :" + oFldr.Items.Count.ToString());
            // str.Append("Total Unread items = " + oFldr.UnReadItemCount.ToString()); foreach
            // (object obj in oFldr.Items) { if (obj is Microsoft.Office.Interop.Outlook.MailItem) {
            // Microsoft.Office.Interop.Outlook.MailItem oMessage =
            // (Microsoft.Office.Interop.Outlook.MailItem)obj;

            // str.Append("Gonderen"); str.Append(oMessage.SenderEmailAddress.ToString() +
            // Environment.NewLine); ; //basic info about message str.Append("Tarih" +
            // oMessage.SentOn.ToShortDateString() + Environment.NewLine); if (oMessage.Subject !=
            // null) { str.Append("Konu" + oMessage.Subject.ToString() + Environment.NewLine); }
            // //reference and save all attachments

            // iAttachCnt = oMessage.Attachments.Count; if (iAttachCnt > 0) { for (int i = 1; i
            // <= iAttachCnt; i++) { str.Append(i.ToString() + oMessage.Attachments[i].FileName +
            // Environment.NewLine); } } str.Append(Environment.NewLine); } else { continue; }

            // } return str.ToString(); } catch (System.Exception ex) {
            // XtraMessageBox.Show("Execption generated:" + ex.Message); } finally { GC.Collect();
            // oFldr = null; oNs = null; oOutlook = null;

            // }

            // return "";
        }

        public static byte[] GZipCompress(string dosya_adi)
        {
            byte[] buffer = new byte[0];
            try
            {
                FileStream infile = new FileStream(dosya_adi, FileMode.Open, FileAccess.Read, FileShare.Read);
                buffer = new byte[infile.Length];
                int count = infile.Read(buffer, 0, buffer.Length);
                if (count != buffer.Length)
                {
                    infile.Close();
                    MessageBox.Show("Dosya okuma sırasında sorun oluştu. ");
                }
                infile.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error occured. " + e.Message);
            }
            return GZipCompress(buffer);
        }

        public static byte[] GZipCompress(byte[] data)
        {
            byte[] buffer = new byte[0];
            try
            {
                MemoryStream ms = new MemoryStream(data);
                buffer = new byte[data.Length + 10000];
                GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Compress, true);
                compressedzipStream.Write(buffer, 0, buffer.Length);
                compressedzipStream.Close();
                ms.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error occured. " + e.Message);
            }
            return buffer;
        }

        public static byte[] GZipDecompress(string filename)
        {
            byte[] buffer = new byte[0];
            try
            {
                FileStream infile = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                buffer = new byte[infile.Length];
                int count = infile.Read(buffer, 0, buffer.Length);
                if (count != buffer.Length)
                {
                    infile.Close();
                    Console.WriteLine("Test Failed: Unable to read data from file");
                }

                infile.Close();
            }
            catch 
            {
                MessageBox.Show("Error occured. ");
            }

            return GZipDecompress(buffer);
        }

        public static byte[] GZipDecompress(byte[] data)
        {
            byte[] decompressedBuffer = new byte[0];
            try
            {
                byte[] deCompressed = new byte[data.Length];
                MemoryStream fss = new MemoryStream(data, true);
                GZipStream zipStream = new GZipStream(fss, CompressionMode.Decompress);
                decompressedBuffer = new byte[400000];
                zipStream.Read(decompressedBuffer, 0, 400000);

                zipStream.Close();
            }
            catch 
            {
                MessageBox.Show("Error occured. ");
            }
            return decompressedBuffer;
        }

        public static double MmToPixcel(double Mm, bool horizantal)
        {
            double donecek = 0;
            try
            {
                Graphics g = Graphics.FromImage(new Bitmap(1, 1));
                if (horizantal)
                {
                    donecek = (g.DpiX / 2.54) / 10;
                }
                else
                {
                    donecek = (g.DpiY / 2.54) / 10;
                }
            }
            catch 
            {
                //MesajCi.Goster("Hata", "İşlem hatası Error Message : 261010", "bu işlemi Gerçekleştirirken sistemde bazı sorunlar meydana geldi...Daha sonra başka sorunlarında engellenmesi için işleminiz durdurulmştur...", MessageBoxButtons.OK, "", MessageBoxIcon.Error);
            }
            return donecek;
        }

        public static void OpenProgram(ExtensionToOpenProgram ProgramsExtension)
        {
            byte[] veri = new byte[10];
            string fileName = tempPath + new Guid().ToString() + "." + ProgramsExtension.ToString();
            FileStream fs = new FileStream(fileName, FileMode.Create);
            fs.Write(veri, 0, 9);
            fs.Close();
            if (File.Exists(fileName))
            {
                try
                {
                    Process.Start(fileName);
                }
                catch 
                {
                    XtraMessageBox.Show("Dosya Bulunamadı... ");
                }
            }
        }

        public static void OpenProgram(ExtensionToOpenProgram ProgramsExtension, object DataSource)
        {
            byte[] veri = new byte[10];
            string fileName = tempPath + new Guid().ToString() + "." + ProgramsExtension.ToString();
            FileStream fs = new FileStream(fileName, FileMode.Create);
            fs.Write(veri, 0, 9);
            fs.Close();
            if (File.Exists(fileName))
            {
                try
                {
                    Process.Start(fileName);
                }
                catch 
                {
                    XtraMessageBox.Show("Dosya Bulunamadı... ");
                }
            }
        }

        public static void OpenProgram(string file)
        {
            if (File.Exists(file))
            {
                try
                {
                    Process.Start(file);
                }
                catch 
                {
                    XtraMessageBox.Show("Dosya Bulunamadı... ");
                }
            }
        }

        public static double PixcelToCm(int pixcel, bool horizantal)
        {
            double donecek = 0;
            Graphics g = Graphics.FromImage(new Bitmap(1, 1));
            if (horizantal)
            {
                donecek = (pixcel / g.DpiX) * 2.54;
            }
            else
            {
                donecek = (pixcel / g.DpiY) * 2.54;
            }

            return donecek;
        }

        public static int ReadAllBytesFromStream(Stream stream, byte[] buffer)
        {
            int offset = 0;
            int totalCount = 0;
            while (true)
            {
                int bytesRead = stream.Read(buffer, offset, 100);
                if (bytesRead == 0)
                {
                    break;
                }
                offset += bytesRead;
                totalCount += bytesRead;
            }
            return totalCount;
        }

        public static bool SerializeClass(object value, string path)
        {
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, value);
                    fs.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    fs.Close();
                    BelgeUtil.ErrorHandler.Catch(typeof(Tools), ex, true, "");
                    return false;
                }
            }
            else
            {
                File.Create(path);
                return false;
            }
        }

        public static bool SerializeXml(object value, string path)
        {
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                try
                {
                    XmlSerializer xs = new XmlSerializer(value.GetType());
                    xs.Serialize(fs, value);
                    fs.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    fs.Close();
                    BelgeUtil.ErrorHandler.Catch(typeof(Tools), ex, true, "");
                    return false;
                }
            }
            else
            {
                File.Create(path);
                return false;
            }
        }

        public static string SifreCoz(byte[] _anahtar, byte[] _vektor, string data)
        {
            return System.Text.Encoding.UTF8.GetString(SifreCoz(anahtar, Vektor, System.Text.Encoding.UTF8.GetBytes(data)));
        }

        public static byte[] SifreCoz(byte[] _anahtar, byte[] _vektor, byte[] data)
        {
            ///Şifre Cozme
            ///
            ///cozme işlemi için kullanılacak algoritma
            System.Security.Cryptography.RijndaelManaged rm = new
 System.Security.Cryptography.RijndaelManaged();

            //kullanıılacak anahtar
            rm.Key = _anahtar;
            //kullanılacak vektor
            rm.IV = _vektor;
            //sifreli verinin tutuldugu bir stream
            //ben yine ram de ttum yani burada şifreli verimi ram eyazdım ...
            MemoryStream ms = new MemoryStream(data);

            /// buradada Yukarıdaki gibi fakat tek fark CreateDecryptor metodunu kullanmam ... Ve
            /// Read işlemi yapacagımı yani sifre cozecegimi belirtmem ...
            System.Security.Cryptography.CryptoStream cs = new
                 System.Security.Cryptography.CryptoStream(ms, rm.CreateDecryptor(anahtar, Vektor),
                     System.Security.Cryptography.CryptoStreamMode.Read);

            ///şifreli veriyi cozdukten sonra bir byte dizisine yazmalıyız
            ///bu yuzden bir byte dizisi olusturdum
            ///bu dizinin boyutunu da dogal olarak cozulecek verinin boyutu kadar yaptım ...
            byte[] sifreli = new byte[ms.Length];

            ///Cs.Read işlemi ilede ilk parametrede verilen byte dizisine sıfırıncı indexinden sonuna kadar ms deki yani stream içine attıgım veriyi
            ///cozup attım ....
            cs.Read(sifreli, 0, ((int)ms.Length));

            ///veriyi 1. tezt boza attım
            byte[] result = sifreli;
            ms.Close();
            return result;
        }

        public static string Sifrele(string data)
        {
            string result = "";

            ///kullanacagımız şifreleme metodunun c# taki class tipindeki karsılıgı...
            ///bu class tan bir instance alıyoruz...
            System.Security.Cryptography.RijndaelManaged rm = new
             System.Security.Cryptography.RijndaelManaged();

            ///sifreleme algoritmamız için bir anahtar ve vektor gereklidir... bu anahtar ve vektor ile sifreleme işlemi yapılacak
            ///bizde instance ini aldıgımız class in generatekey ve generateIV metodları ile kendi içeirisnde bir vektor ve key olusturmasını sagladık
            rm.GenerateKey();
            rm.GenerateIV();
            //arka tarafta uretilen bilmedimgimiz anahtar ve vektorudegişkenlere atıyoruz ki şifreyi cozerken bunlar bize coook gerekli ...
            anahtar = rm.Key;
            Vektor = rm.IV;

            ///bir adet stream nesnesi olusturduk... bu network , File yada memory olabilir yada streamden turemi herhangibirsey...
            MemoryStream ms = new MemoryStream();

            /// şimdi bize şifreleme işlemi yapabilmemiz için bircryptostream gerekli ... bu straem
            /// ile veriyi şifreliyip istedigimiz bir stream içine atabiliriz... burada crypto
            /// stream aslında verdigimiz stream e yazma yapıyor... parametreleri : ms : sifrelenmiş
            /// veri nereye yazılacakkk.... rm.CreateEncryptor(anahtar,vektor): bu 2. parametremiz
            /// kullanacagımız sifreleme yontemi timpinden bir instance olmalı ve bu instance in
            /// createEncryptor metodunu kullandık bu metoddda bizden şifrelemede kullanılacak
            /// anahtar ve vektoru istedi... neden crryptoEncryptor u kullandık derseniz: burada
            /// bizden istenen parametre ICryptoTransform tipinde bizede kullandıgımız yontem
            /// içerisindeki CreateEncryptor metodu boyle bir deger donduruyor...Buradaki
            /// parametrenin Basındaki (ICrypto..) I olması onun ınterface oldugunu belirtir. neden
            /// bir interface sorusunun cevabı ise bu metodun parametre olarak bir cok farklı
            /// sifreleme algoritması class ı tipinde deger alması erekiyor.. E bizim tum sifreleme
            /// classlarımızda /// ICryptoTransform dan turedigi için bu durumda her algoritma
            /// buraya yazılabilir... burada algoritmamızı belirttik ...
            /// 3. parametre ise crypto streamın okumamı yazmamı yapacagı yanı bir veriyi
            ///    sifrelememi yapacagız yoksa onu coz
            /// şifreleme işlemlerinde write sifre cozme işlemlerinde read kullanıyoruz... biz
            /// burada write diyerek sifreleme yapacagımızı anlatıık yani veri okunup ilk
            /// parametrede ki stream içine sifremli halde atılacak...
            System.Security.Cryptography.CryptoStream cs = new
                 System.Security.Cryptography.CryptoStream(ms, rm.CreateEncryptor(anahtar, Vektor),
                     System.Security.Cryptography.CryptoStreamMode.Write);

            ///tek yapmamız gereken artık verimizi gosterip onu difreleyip belrttigimiz stream e yazmak...
            ///bunuda Cryptostream altındaki write metodu yapıyor...
            ///bu metod bizden ilk parametre byte dizisi tipinde sifrelenecek veriyi
            ///2. parametre dizinin hangi indexinden baslanacagı
            ///3. parametre dizinin ne kadar elemanına yazılma yapılacagı...
            ///ilk parametredeki System.Text.Encoding.UTF8.GetBytes() metodu sizi şaşırtmasın
            ///bu metod parametre olarak verillen veriyi byte dizisi  haline getirir...
            ///ben richtextboz içindeki yazıyı şifreleyecegimden. Bu veride string oldugundan onu byte dizisine cevirme ihtiyacı duydum ...
            ///

            cs.Write(System.Text.Encoding.UTF8.GetBytes(data), 0,
            System.Text.Encoding.UTF8.GetBytes(data).Length);

            //sifrelenmiş veriyi update eder yanı yazma işlemini bitirir ve buffer ı temizler..buffer verilerin depolandıgı yer...
            cs.FlushFinalBlock();

            ///şifreledigimiz veriye ms yani memorystreamde tutulmakta ona ms ile ulaşabiliriz...
            ///ms.ToArray ile sifreli veriyi byte dizisi halinde alabiliriz...
            veri = (ms.ToArray());

            ///aldıgım şifreli veriyi
            //System.Text.Encoding.UTF8.GetString();
            ///string e cevirip 2. textboz a attım ...
            result = System.Text.Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return result;
        }

        public static byte[] Sifrele(byte[] data)
        {
            byte[] result;
            System.Security.Cryptography.RijndaelManaged rm = new
             System.Security.Cryptography.RijndaelManaged();
            rm.GenerateKey();
            rm.GenerateIV();
            anahtar = rm.Key;
            Vektor = rm.IV;
            MemoryStream ms = new MemoryStream();

            System.Security.Cryptography.CryptoStream cs = new
                 System.Security.Cryptography.CryptoStream(ms, rm.CreateEncryptor(anahtar, Vektor),
                     System.Security.Cryptography.CryptoStreamMode.Write);

            cs.Write(data, 0, data.Length);

            cs.FlushFinalBlock();
            veri = (ms.ToArray());

            result = ms.ToArray();
            ms.Close();
            return result;
        }
    }
}