using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Util
{
    public static class Kisayol
    {
        private const string pwdString = "AVP2009-KNA";

        public static void CreateShortCut(int id, AcilisSekli tur)
        {
            string dosyaUzantisi = GetExtension(tur);
            string kaydedilecek = Encypt(id.ToString());

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = dosyaUzantisi;

            if (sfd.ShowDialog() == DialogResult.OK)
                try
                {
                    StreamWriter sw = new StreamWriter(sfd.OpenFile());
                    sw.WriteLine(kaydedilecek);
                    sw.Close();
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("Kisayol", ex);
                }
        }

        private static string GetExtension(AcilisSekli tur)
        {
            switch (tur)
            {
                case AcilisSekli.IcraTakip:
                    return "İcra Dosyası (*.avpi)|*.AVPI";
                case AcilisSekli.DavaTakip:
                    return "Dava Dosyası (*.avpd)|*.AVPD";
                case AcilisSekli.SorusturmaArama:
                    return "Soruşturma Dosyası (*.avph)|*.AVPH";
                case AcilisSekli.Tebligat:
                    return "Tebligat Dosyası (*.avpt)|*.AVPT";
                case AcilisSekli.SozlesmeTakip:
                    return "Sözleşme Dosyası (*.avps)|*.AVPS";
                case AcilisSekli.Editor:
                    return "Editor (*.avpe)|*.AVPE";
                default:
                    break;
            }
            return null;
        }

        public static AcilisSekli GetAcilisSekli(string Extension)
        {
            if (Extension.StartsWith(".")) Extension = Extension.Substring(1);
            switch (Extension)
            {
                case "AVPI":
                    return AcilisSekli.IcraTakip;
                case "AVPD":
                    return AcilisSekli.DavaTakip;
                case "AVPH":
                    return AcilisSekli.SorusturmaArama;
                case "AVPT":
                    return AcilisSekli.Tebligat;
                case "AVPS":
                    return AcilisSekli.SozlesmeTakip;
                case "AVPE":
                    return AcilisSekli.Editor;
                default:
                    break;
            }
            return AcilisSekli.Normal;
        }

        public static string Encypt(string turId)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(turId);

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(pwdString));
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray =
                cTransform.TransformFinalBlock(toEncryptArray, 0,
                                               toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string encryptedId)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(encryptedId);

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(pwdString));
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Encoding.UTF8.GetString(resultArray);
        }

        public enum AcilisSekli
        {
            IcraTakip,
            Editor,
            DavaTakip,
            SorusturmaTakip,
            Normal,
            Klasor,
            IcraArama,
            DavaArama,
            SorusturmaArama,
            Tebligat,
            SozlesmeTakip,
            Is,
            Ajanda,
            Belge,
            Kurumsal,
            GenelGiriş,
            Muhasebe,
            Proje,
            Görüşme,
        }
    }
}