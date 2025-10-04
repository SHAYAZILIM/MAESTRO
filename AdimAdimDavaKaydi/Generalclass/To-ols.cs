using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Belge.UserControls;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using TXTextControl;

namespace AdimAdimDavaKaydi
{
    public enum ExtensionToOpenProgram
    {
        doc,
        docx,
        xls,
        xlsx,
        pdf,
        html,
        swf,
        pst
    }
    
    [Serializable]
    public class PaswordedFile
    {
        private byte[] _datas;
        private byte[] _key;
        private string _name;

        private string _pwd;

        private StreamType _streamsType;

        private byte[] _vektor;

        public byte[] Datas
        {
            get { return _datas; }
            set { _datas = value; }
        }

        public byte[] Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Pwd
        {
            get { return _pwd; }
            set { _pwd = value; }
        }

        public StreamType StreamsType
        {
            get { return _streamsType; }
            set { _streamsType = value; }
        }

        public byte[] Vektor
        {
            get { return _vektor; }
            set { _vektor = value; }
        }
    }

    public class Tools
    {
        public static byte[] anahtar;

        public static string ImagesFilesPath = "c:\\Images\\";

        public static string ReportFilesPath = "c:\\Reports\\";

        public static byte[] Vektor;

        private static string tempPath = Application.StartupPath + "\\Temp\\";

        private static byte[] veri;

        public enum CharUpperLowerType
        {
            FirstbigOthersSmal,
            FirstSmallOthersBig,
            AllBig,
            AllSmall,
            None,
        }

        public enum WordsUpperLowerType
        {
            FirstWordUpperOthersLower,
            FirstWordFirstCharUpperOtherLower,
            AllWordAllCharsUpper,
            AllWordsFirstCharsUpper,
            AllWordsAllCharsLower,
            FirstWordsFirstCharLoverOtherWordsFirstCharUpper,
        }

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
                MesajKutusu mk = new MesajKutusu();
                mk.ShowDialog("Hata", "Ýþlem hatasý Error Message : 261010",
                              "bu iþlemi Gerçekleþtirirken isitemde bazý sorunlar meysana geldi...daha sonra baþka sorunlarýnda engellenmesi için iþleminiz durdurulmþtur...",
                              MessageBoxButtons.OK, "", MessageBoxIcon.Error);
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

        public static T DeSerializeClass<T>(byte[] icerik)
        {
            T returnValue = Activator.CreateInstance<T>();
            if (icerik != null)
            {
                MemoryStream ms = new MemoryStream(icerik);
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    returnValue = (T)bf.Deserialize(ms);
                    ms.Close();
                }
                catch (Exception ex)
                {
                    ms.Close();
                    BelgeUtil.ErrorHandler.Catch(typeof(Tools), ex, false, "");
                }
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
                        XtraMessageBox.Show(" Hata : Dosya okumada hata ... Dosya Okunamýyor : " + Environment.NewLine +
                                            path);
                    }
                    fs.Close();
                }
                catch
                {
                    fs.Close();
                }
            }
            else
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
            return returnValue;
        }

        public static T DeSerializeXml<T>(byte[] veri)
        {
            T returnValue = Activator.CreateInstance<T>();
            if (veri.Length > 0)
            {
                MemoryStream ms = new MemoryStream(veri);
                try
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    XmlReader xr = XmlReader.Create(ms);
                    if (xs.CanDeserialize(xr))
                    {
                        returnValue = (T)xs.Deserialize(ms);
                    }
                    else
                    {
                        XtraMessageBox.Show(" Hata : Veri Okunamadý ... ");
                    }
                    ms.Close();
                }
                catch 
                {
                    ms.Close();
                }
            }

            return returnValue;
        }

        public static T DeSerializeXmlString<T>(string veri)
        {
            return DeSerializeXml<T>(System.Text.Encoding.UTF8.GetBytes(veri));
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
            btn.Click += delegate { frm.Close(); };

            //.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show();

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

        public static byte[] GetBytesFromFile(string path)
        {
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                try
                {
                    byte[] veri = new byte[fs.Length];
                    fs.Read(veri, 0, veri.Length);
                    fs.Close();
                    return veri;
                }
                catch (Exception ex)
                {
                    fs.Close();
                    BelgeUtil.ErrorHandler.Catch(typeof(Tools), ex, true, "");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static TList<AV001_TDIE_BIL_MESAJ> GetMailsFromOutlook()
        {
            TList<AV001_TDIE_BIL_MESAJ> lstMesaj = new TList<AV001_TDIE_BIL_MESAJ>();

            Microsoft.Office.Interop.Outlook.Application oOutlook;
            Microsoft.Office.Interop.Outlook.NameSpace oNs;
            Microsoft.Office.Interop.Outlook.MAPIFolder oFldr;
            long iAttachCnt;
            StringBuilder str = new StringBuilder();
            try
            {
                oOutlook = new Microsoft.Office.Interop.Outlook.Application();
                oNs = oOutlook.GetNamespace("MAPI");

                //getting mail folder from inbox
                oFldr = oNs.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
                str.Append("Total Mail(s) in Inbox :" + oFldr.Items.Count);
                str.Append("Total Unread items = " + oFldr.UnReadItemCount);
                foreach (object obj in oFldr.Items)
                {
                    if (obj is Microsoft.Office.Interop.Outlook.MailItem)
                    {
                        AV001_TDIE_BIL_MESAJ mesajim = new AV001_TDIE_BIL_MESAJ();
                        lstMesaj.Add(mesajim);

                        Microsoft.Office.Interop.Outlook.MailItem oMessage =
                            (Microsoft.Office.Interop.Outlook.MailItem)obj;

                        str.Append("Gonderen");

                        str.Append(oMessage.SenderEmailAddress + Environment.NewLine);
                        ;
                        mesajim.BCC = oMessage.BCC;
                        mesajim.CC = oMessage.CC;
                        mesajim.ICERIK = oMessage.Body;
                        mesajim.GONDERILENLER = oMessage.To;

                        mesajim.GONDEREN_CARI_ID = 1;

                        //basic info about message
                        str.Append("Tarih" + oMessage.SentOn.ToShortDateString() + Environment.NewLine);

                        if (oMessage.Subject != null)
                        {
                            str.Append("Konu" + oMessage.Subject + Environment.NewLine);
                        }
                        mesajim.KONU = oMessage.Subject;

                        //reference and save all attachments

                        TList<AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE> lstBelgem =
                            new TList<AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE>();

                        iAttachCnt = oMessage.Attachments.Count;
                        if (iAttachCnt > 0)
                        {
                            for (int i = 1; i <= iAttachCnt; i++)
                            {
                                str.Append(i + oMessage.Attachments[i].FileName + Environment.NewLine);

                                AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE belgem =
                                    new AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE();
                                oMessage.Attachments[i].SaveAsFile(Tools.TempFilesPath +
                                                                   oMessage.Attachments[i].FileName);
                                belgem.DOSYA_ADI = Tools.TempFilesPath + oMessage.Attachments[i].FileName;
                                belgem.BELGE_ADI = oMessage.Attachments[i].DisplayName;
                                belgem.BELGE_NO = DateTime.Now.Ticks.ToString();
                                belgem.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();
                                lstBelgem.Add(belgem);
                            }
                        }
                        mesajim.AV001_TDIE_BIL_BELGECollection_From_NN_MESAJ_BELGE = lstBelgem;
                        str.Append(Environment.NewLine);
                    }
                    else
                    {
                        continue;
                    }
                }
                return lstMesaj;
            }
            catch (System.Exception ex)
            {
                XtraMessageBox.Show("Execption generated:" + ex.Message);
            }
            finally
            {
                oFldr = null;
                oNs = null;
                oOutlook = null;
            }

            return lstMesaj;
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
                    MessageBox.Show("Dosya okuma sýrasýnda sorun oluþtu. ");
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
                buffer = new byte[data.Length];
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

        public static byte[] Hash(byte[] data)
        {
            byte[] returnValue = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                returnValue[i] = Convert.ToByte(data[i] + 1);
            }

            return returnValue;
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
                MesajCi.Goster("Hata", "Ýþlem hatasý Error Message : 261010",
                               "bu iþlemi Gerçekleþtirirken sistemde bazý sorunlar meydana geldi...Daha sonra baþka sorunlarýnda engellenmesi için iþleminiz durdurulmþtur...",
                               MessageBoxButtons.OK, "", MessageBoxIcon.Error);
            }
            return donecek;
        }

        public static void OpenProgram(ExtensionToOpenProgram ProgramsExtension)
        {
            byte[] veri = new byte[10];
            string fileName = tempPath + new Guid() + "." + ProgramsExtension;
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
                    XtraMessageBox.Show("Dosya Bulunamadý... ");
                }
            }
        }

        public static void OpenProgram(ExtensionToOpenProgram ProgramsExtension, object DataSource)
        {
            byte[] veri = new byte[10];
            string fileName = tempPath + new Guid() + "." + ProgramsExtension;
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
                    XtraMessageBox.Show("Dosya Bulunamadý... ");
                }
            }
        }

        public static void OpenProgram(string file)
        {
            if (File.Exists(file))
            {
                try
                {
                    if (file.EndsWith(".tx"))
                    {
                        AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor editor =
                            new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor();
                        editor.MdiParent = mdiAvukatPro.MainForm;
                        editor.Show();
                        editor.OpenFile(file);
                        editor.beklemePaneli.Visible = false;
                    }
                    else
                    {
                        Process.Start(file);
                    }
                }
                catch 
                {
                    XtraMessageBox.Show("Dosya Bulunamadý... ");
                }
            }
        }

        public static void OpenWebSite(string file)
        {
            try
            {
                Process.Start(file);
            }
            catch
            {
                XtraMessageBox.Show("Web Sitesi Bulunamadý... ");
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

        public static void SaveTofile(string fileName, string datas)
        {
            SaveTofile(fileName, System.Text.Encoding.UTF8.GetBytes(datas));
        }

        public static void SaveTofile(string fileName, byte[] datas)
        {
            if (!fileName.Contains("."))
            {
                DialogResult dr = XtraMessageBox.Show("Dosya için bir uzantý belirtilmemiþ! Yinede Dosya yazýlsýn mý?",
                                                      "Dosya Uzantýsý", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    FileStream FS = new FileStream(fileName, FileMode.OpenOrCreate);
                    FS.Write(datas, 0, datas.Length);
                    FS.Close();
                    return;
                }
                else if (dr == DialogResult.No)
                {
                    return;
                }
            }

            try
            {
                //   FileStream fs = new FileStream(fileName, FileMode.Create);
                if (!File.Exists(fileName))
                {
                    // DialogResult dr = XtraMessageBox.Show("Ayný isimde bir dosya daha var . Üzerine Yazýlsýn mý?", "Üzerine Yaz", MessageBoxButtons.YesNo);
                    // if (dr == DialogResult.Yes)
                    // {
                    FileStream FS = new FileStream(fileName, FileMode.OpenOrCreate);
                    FS.Write(datas, 0, datas.Length);
                    FS.Close();

                    //}
                }
                else
                {
                    FileStream FS = new FileStream(fileName, FileMode.OpenOrCreate);
                    FS.Write(datas, 0, datas.Length);
                    FS.Close();
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(typeof(Tools), ex, true, fileName);
            }
        }

        public static bool SerializeClass(object value, string path)
        {
            if (value != null)
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
                catch 
                {
                    fs.Close();

                    // BelgeUtil.ErrorHandler.Catch(typeof(Tools), ex, true, "");
                    return false;
                }
            }
            else
            {
                File.Create(path);
                return false;
            }
        }

        public static string SerializeXml(object value)
        {
            if (value != null)
            {
                byte[] veri = new byte[10000];
                MemoryStream ms = new MemoryStream(veri);
                try
                {
                    XmlSerializer xs = new XmlSerializer(value.GetType());
                    xs.Serialize(ms, value);
                    ms.Close();
                    return System.Text.Encoding.UTF8.GetString(veri);
                }
                catch (Exception ex)
                {
                    ms.Close();
                    BelgeUtil.ErrorHandler.Catch(typeof(Tools), ex, true, "");
                    return string.Empty;
                }
            }
            return string.Empty;
        }

        public static string setChars(string value, CharUpperLowerType caseType)
        {
            if (value.Trim().Length <= 0)
            {
                return value;
            }
            string firstChar = value[0].ToString();
            string others = "";
            if (value.Length > 1)
            {
                others = value.Substring(1, value.Length - 1);
            }

            switch (caseType)
            {
                case CharUpperLowerType.FirstbigOthersSmal:
                    return firstChar.ToUpper() + others.ToLower();

                case CharUpperLowerType.FirstSmallOthersBig:
                    return firstChar.ToLower() + others.ToUpper();

                case CharUpperLowerType.AllBig:
                    return firstChar.ToUpper() + others.ToUpper();

                case CharUpperLowerType.AllSmall:
                    return firstChar.ToLower() + others.ToLower();

                case CharUpperLowerType.None:
                    return value;

                default:
                    return value;
            }
        }

        public static string SetWords(string value, WordsUpperLowerType caseType)
        {
            string returnValue = "";
            string[] vals = value.Split(' ');
            string[] others = new string[vals.Length - 1];
            string FirstWord = vals[0];

            if (vals.Length > 1)
            {
                Array.Copy(vals, 1, others, 0, vals.Length - 1);
            }

            switch (caseType)
            {
                case WordsUpperLowerType.FirstWordUpperOthersLower:
                    returnValue += FirstWord.ToUpper();
                    for (int i = 0; i < others.Length; i++)
                    {
                        returnValue += " " + others[i].ToLower();
                    }
                    break;

                case WordsUpperLowerType.FirstWordFirstCharUpperOtherLower:
                    returnValue += setChars(FirstWord, CharUpperLowerType.FirstbigOthersSmal);
                    for (int i = 0; i < others.Length; i++)
                    {
                        returnValue += " " + others[i].ToLower();
                    }
                    break;

                case WordsUpperLowerType.AllWordAllCharsUpper:
                    returnValue += FirstWord.ToUpper();
                    for (int i = 0; i < others.Length; i++)
                    {
                        returnValue += " " + others[i].ToUpper();
                    }
                    break;

                case WordsUpperLowerType.AllWordsFirstCharsUpper:
                    returnValue += setChars(FirstWord, CharUpperLowerType.FirstbigOthersSmal);
                    for (int i = 0; i < others.Length; i++)
                    {
                        returnValue += " " + setChars(others[i], CharUpperLowerType.FirstbigOthersSmal);
                    }
                    break;

                case WordsUpperLowerType.AllWordsAllCharsLower:
                    returnValue += FirstWord.ToLower();
                    for (int i = 0; i < others.Length; i++)
                    {
                        returnValue += " " + others[i].ToLower();
                    }
                    break;

                case WordsUpperLowerType.FirstWordsFirstCharLoverOtherWordsFirstCharUpper:
                    returnValue += setChars(FirstWord, CharUpperLowerType.FirstSmallOthersBig);
                    for (int i = 0; i < others.Length; i++)
                    {
                        returnValue += " " + setChars(others[i], CharUpperLowerType.FirstbigOthersSmal);
                    }
                    break;

                default:
                    break;
            }

            return returnValue;
        }

        public static string SifreCoz(byte[] _anahtar, byte[] _vektor, string data)
        {
            return
                System.Text.Encoding.UTF8.GetString(SifreCoz(anahtar, Vektor, System.Text.Encoding.UTF8.GetBytes(data)));
        }

        public static byte[] SifreCoz(byte[] _anahtar, byte[] _vektor, byte[] data)
        {
            ///Þifre Cozme
            ///
            ///cozme iþlemi için kullanýlacak algoritma
            System.Security.Cryptography.RijndaelManaged rm = new
                System.Security.Cryptography.RijndaelManaged();

            //kullanýýlacak anahtar
            rm.Key = _anahtar;
            //kullanýlacak vektor
            rm.IV = _vektor;
            //sifreli verinin tutuldugu bir stream
            //ben yine ram de ttum yani burada þifreli verimi ram eyazdým ...
            MemoryStream ms = new MemoryStream(data);

            /// buradada Yukarýdaki gibi fakat tek fark CreateDecryptor metodunu kullanmam ...
            /// Ve Read iþlemi yapacagýmý yani sifre cozecegimi belirtmem ...
            System.Security.Cryptography.CryptoStream cs = new
                System.Security.Cryptography.CryptoStream(ms, rm.CreateDecryptor(_anahtar, _vektor),
                                                          System.Security.Cryptography.CryptoStreamMode.Read);

            ///þifreli veriyi cozdukten sonra bir byte dizisine yazmalýyýz
            ///bu yuzden bir byte dizisi olusturdum
            ///bu dizinin boyutunu da dogal olarak cozulecek verinin boyutu kadar yaptým ...
            byte[] sifreli = new byte[ms.Length + 10000];

            ///Cs.Read iþlemi ilede ilk parametrede verilen byte dizisine sýfýrýncý indexinden sonuna kadar ms deki yani stream içine attýgým veriyi
            ///cozup attým ....

            cs.Read(data, 0, data.Length);

            byte[] result = data;
            ms.Close();
            return result;
        }

        public static string Sifrele(string data)
        {
            string result = "";

            ///kullanacagýmýz þifreleme metodunun c# taki class tipindeki karsýlýgý...
            ///bu class tan bir instance alýyoruz...
            System.Security.Cryptography.RijndaelManaged rm = new
                System.Security.Cryptography.RijndaelManaged();

            ///sifreleme algoritmamýz için bir anahtar ve vektor gereklidir... bu anahtar ve vektor ile sifreleme iþlemi yapýlacak
            ///bizde instance ini aldýgýmýz class in generatekey ve generateIV metodlarý ile kendi içeirisnde bir vektor ve key olusturmasýný sagladýk
            rm.GenerateKey();
            rm.GenerateIV();
            //arka tarafta uretilen bilmedimgimiz anahtar ve vektorudegiþkenlere atýyoruz ki þifreyi cozerken bunlar bize coook gerekli ...
            anahtar = rm.Key;
            Vektor = rm.IV;

            ///bir adet stream nesnesi olusturduk... bu network , File yada memory olabilir yada streamden turemi herhangibirsey...
            MemoryStream ms = new MemoryStream();

            /// þimdi bize þifreleme iþlemi yapabilmemiz için bircryptostream gerekli ... bu straem ile veriyi þifreliyip istedigimiz bir stream içine atabiliriz...
            /// burada crypto stream aslýnda verdigimiz stream e yazma yapýyor...
            /// parametreleri : ms : sifrelenmiþ veri nereye yazýlacakkk....  rm.CreateEncryptor(anahtar,vektor): bu 2. parametremiz
            /// kullanacagýmýz sifreleme yontemi timpinden bir instance olmalý ve bu instance in createEncryptor metodunu kullandýk bu metoddda
            /// bizden þifrelemede kullanýlacak anahtar ve vektoru istedi...
            /// neden crryptoEncryptor u kullandýk derseniz: burada bizden istenen parametre ICryptoTransform tipinde bizede kullandýgýmýz yontem
            /// içerisindeki CreateEncryptor metodu boyle bir deger donduruyor...Buradaki parametrenin Basýndaki (ICrypto..) I olmasý
            /// onun ýnterface oldugunu belirtir. neden bir interface sorusunun cevabý ise bu metodun parametre olarak bir cok farklý
            /// sifreleme algoritmasý class ý tipinde deger almasý erekiyor.. E bizim tum sifreleme classlarýmýzda
            /// /// ICryptoTransform dan turedigi için bu durumda her  algoritma buraya yazýlabilir...
            /// burada algoritmamýzý belirttik ...
            /// 3. parametre ise crypto streamýn okumamý yazmamý yapacagý yaný bir veriyi sifrelememi yapacagýz yoksa onu coz
            /// þifreleme iþlemlerinde write
            /// sifre cozme iþlemlerinde read
            /// kullanýyoruz...
            /// biz burada write diyerek sifreleme yapacagýmýzý anlatýýk
            /// yani veri okunup ilk parametrede ki stream içine sifremli halde atýlacak...
            System.Security.Cryptography.CryptoStream cs = new
                System.Security.Cryptography.CryptoStream(ms, rm.CreateEncryptor(anahtar, Vektor),
                                                          System.Security.Cryptography.CryptoStreamMode.Write);

            ///tek yapmamýz gereken artýk verimizi gosterip onu difreleyip belrttigimiz stream e yazmak...
            ///bunuda Cryptostream altýndaki write metodu yapýyor...
            ///bu metod bizden ilk parametre byte dizisi tipinde sifrelenecek veriyi
            ///2. parametre dizinin hangi indexinden baslanacagý
            ///3. parametre dizinin ne kadar elemanýna yazýlma yapýlacagý...
            ///ilk parametredeki System.Text.Encoding.UTF8.GetBytes() metodu sizi þaþýrtmasýn
            ///bu metod parametre olarak verillen veriyi byte dizisi  haline getirir...
            ///ben richtextboz içindeki yazýyý þifreleyecegimden. Bu veride string oldugundan onu byte dizisine cevirme ihtiyacý duydum ...
            ///

            cs.Write(System.Text.Encoding.UTF8.GetBytes(data), 0,
                     System.Text.Encoding.UTF8.GetBytes(data).Length);

            //sifrelenmiþ veriyi update eder yaný yazma iþlemini bitirir ve buffer ý temizler..buffer verilerin depolandýgý yer...
            cs.FlushFinalBlock();

            ///þifreledigimiz veriye ms yani memorystreamde tutulmakta ona ms ile ulaþabiliriz...
            ///ms.ToArray ile sifreli veriyi byte dizisi halinde alabiliriz...
            veri = (ms.ToArray());

            ///aldýgým þifreli veriyi
            //System.Text.Encoding.UTF8.GetString();
            ///string e cevirip 2. textboz a attým ...
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

        #region Office

        #region Constructor and Properties

        public Tools(object theObject)
        {
            TheObject = theObject;
        }

        private string SavedFile { get; set; }

        private object TheObject { get; set; }

        #endregion Constructor and Properties

        #region Word

        public bool OpenWord()
        {
            try
            {
                object misV = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                WordApp.Documents.Add(ref misV, ref misV, ref misV, ref misV);
                WordApp.ApplicationEvents2_Event_DocumentBeforeSave += WordApp_ApplicationEvents2_Event_DocumentBeforeSave;
                WordApp.ApplicationEvents2_Event_DocumentBeforeClose += WordApp_ApplicationEvents2_Event_DocumentBeforeClose;
                WordApp.ApplicationEvents2_Event_Quit += WordApp_ApplicationEvents2_Event_Quit;
                WordApp.Visible = true;
                return true;
            }
            catch { return false; }
        }

        private void WordApp_ApplicationEvents2_Event_DocumentBeforeClose(Microsoft.Office.Interop.Word.Document doc, ref bool I)
        {
            if (doc.Saved) SavedFile = doc.FullName;
            else SavedFile = null;
        }

        private void WordApp_ApplicationEvents2_Event_DocumentBeforeSave(Microsoft.Office.Interop.Word.Document doc, ref bool I, ref bool II)
        {
            if (doc.Saved) SavedFile = doc.FullName;
            else SavedFile = null;
        }

        private void WordApp_ApplicationEvents2_Event_Quit()
        {
            if (System.IO.File.Exists(SavedFile))
                if (XtraMessageBox.Show("Ýletiyi dosyayla iliþkilendirmek ister misiniz?", "AvukatPro", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                {
                    AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak belge = new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak();
                    TList<AV001_TDIE_BIL_BELGE> lstbelge = new TList<AV001_TDIE_BIL_BELGE>();
                    AV001_TDIE_BIL_BELGE blg = new AV001_TDIE_BIL_BELGE();
                    blg.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();
                    blg.BELGEYI_YAZAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
                    blg.BELGE_TUR_ID = 7;
                    blg.SUC_OLAY_VADE_TARIHI = DateTime.Now;
                    blg.YAZILMA_TARIHI = DateTime.Now;
                    blg.BELGE_NO = ucBelgeKayitUfak.BelgeNoGetir();
                    blg.BELGE_ADI = SavedFile;
                    blg.DOSYA_ADI = SavedFile;
                    blg.DOKUMAN_UZANTI = new System.IO.FileInfo(SavedFile).Extension.Substring(1);
                    blg.STAMP = 0;

                    #region File to Byte Array

                    int run = 0;
                    while (System.IO.File.Exists(Environment.GetFolderPath(
                        Environment.SpecialFolder.MyDocuments) + "\\temporary" + run)) run++;
                    System.IO.File.Copy(SavedFile, Environment.GetFolderPath(
                        Environment.SpecialFolder.MyDocuments) + "\\temporary" + run);
                    System.IO.FileStream fss = new System.IO.FileStream(
                        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\temporary" + run, System.IO.FileMode.Open);
                    byte[] veri = new byte[fss.Length];
                    fss.Read(veri, 0, veri.Length);
                    blg.ICERIK = veri;
                    fss.Close();
                    System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\temporary" + run);

                    #endregion File to Byte Array

                    if (TheObject is AV001_TI_BIL_FOY)
                    {
                        blg.ESAS_NO = ((AV001_TI_BIL_FOY)TheObject).ESAS_NO;
                        blg.ADLI_BIRIM_ADLIYE_ID = ((AV001_TI_BIL_FOY)TheObject).ADLI_BIRIM_ADLIYE_ID;
                        blg.ADLI_BIRIM_GOREV_ID = ((AV001_TI_BIL_FOY)TheObject).ADLI_BIRIM_GOREV_ID;
                        blg.ADLI_BIRIM_NO_ID = ((AV001_TI_BIL_FOY)TheObject).ADLI_BIRIM_NO_ID;
                        belge.ucBelgeKayitUfak1.ModulID = 1;
                    }
                    else if (TheObject is AV001_TD_BIL_FOY)
                    {
                        blg.ESAS_NO = ((AV001_TD_BIL_FOY)TheObject).ESAS_NO;
                        blg.ADLI_BIRIM_ADLIYE_ID = ((AV001_TD_BIL_FOY)TheObject).ADLI_BIRIM_ADLIYE_ID;
                        blg.ADLI_BIRIM_GOREV_ID = ((AV001_TD_BIL_FOY)TheObject).ADLI_BIRIM_GOREV_ID;
                        blg.ADLI_BIRIM_NO_ID = ((AV001_TD_BIL_FOY)TheObject).ADLI_BIRIM_NO_ID;
                        belge.ucBelgeKayitUfak1.ModulID = 2;
                    }
                    else if (TheObject is AV001_TD_BIL_HAZIRLIK)
                    {
                        blg.ESAS_NO = ((AV001_TD_BIL_HAZIRLIK)TheObject).HAZIRLIK_ESAS_NO;
                        blg.ADLI_BIRIM_ADLIYE_ID = ((AV001_TD_BIL_HAZIRLIK)TheObject).ADLI_BIRIM_ADLIYE_ID;
                        blg.ADLI_BIRIM_GOREV_ID = ((AV001_TD_BIL_HAZIRLIK)TheObject).ADLI_BIRIM_GOREV_ID;
                        blg.ADLI_BIRIM_NO_ID = ((AV001_TD_BIL_HAZIRLIK)TheObject).ADLI_BIRIM_NO_ID;
                        belge.ucBelgeKayitUfak1.ModulID = 3;
                    }
                    else if (TheObject is AV001_TDI_BIL_SOZLESME)
                    {
                        blg.ESAS_NO = ((AV001_TDI_BIL_SOZLESME)TheObject).SICIL_YEVMIYE_NO;
                        blg.ADLI_BIRIM_ADLIYE_ID = ((AV001_TDI_BIL_SOZLESME)TheObject).ADLI_BIRIM_ADLIYE_ID;
                        blg.ADLI_BIRIM_GOREV_ID = ((AV001_TDI_BIL_SOZLESME)TheObject).ADLI_BIRIM_GOREV_ID;
                        blg.ADLI_BIRIM_NO_ID = ((AV001_TDI_BIL_SOZLESME)TheObject).ADLI_BIRIM_NO_ID;
                        belge.ucBelgeKayitUfak1.ModulID = 5;
                    }
                    else if (TheObject is AV001_TDIE_BIL_PROJE)
                    {
                        belge.ucBelgeKayitUfak1.ModulID = 11;
                    }
                    else
                    {
                    }
                    lstbelge.Add(blg);
                    belge.MyDataSource = lstbelge;

                    if (TheObject != null) belge.OpenedRecord = (IEntity)TheObject;
                    else belge.OpenedRecord = blg;

                    belge.Record = lstbelge[0];
                    belge.ucBelgeKayitUfak1.Duzenle = true;

                    if (TheObject != null)
                    {
                        belge.ucBelgeKayitUfak1.KayitIlistir(null, null);
                        belge.ucBelgeKayitUfak1.c_lueModul.Enabled = false;
                        belge.ucBelgeKayitUfak1.c_lueDosya.Enabled = false;
                    }
                    else
                    {
                        belge.ucBelgeKayitUfak1.c_lueModul.Enabled = true;
                        belge.ucBelgeKayitUfak1.c_lueDosya.Enabled = true;
                    }
                    belge.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    belge.MdiParent = null;
                    belge.ShowDialog();
                }
        }

        #endregion Word

        #region Excel

        public bool OpenExcel()
        {
            try
            {
                Microsoft.Office.Interop.Excel.ApplicationClass ExcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                ExcelApp.Workbooks.Add(1);
                ExcelApp.WorkbookBeforeClose += ExcelApp_WorkbookBeforeClose;
                ExcelApp.Visible = true;
                return true;
            }
            catch { return false; }
        }

        private void ExcelApp_WorkbookBeforeClose(Microsoft.Office.Interop.Excel.Workbook workbook, ref bool Cancel)
        {
            if (workbook.Saved) SavedFile = workbook.FullName;
            else SavedFile = null;

            //ExcelApp_Quit(workbook.Application);
            WordApp_ApplicationEvents2_Event_Quit();
        }

        #endregion Excel

        #endregion Office
    }
}