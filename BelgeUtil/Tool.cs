using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Windows.Forms;
using TXTextControl;

namespace BelgeUtil
{
    public class Tool
    {
        /// <summary>
        /// Temp Klasor Yolu Dosyalarýn gecici kaydedilgi yer ...
        /// </summary>
        public static string TempFilePath = Application.StartupPath + "\\Temp\\";

        /// <summary>
        /// Dosya Uzantýsýna gore Tx Binnary Stream Type Dondurur
        /// </summary>
        /// <param name="ft"></param>
        /// <returns></returns>
        public static BinaryStreamType GetBinaryStreamTypeByFileType(TxFileTypes ft)
        {
            BinaryStreamType returnValue = BinaryStreamType.InternalFormat;
            switch (ft)
            {
                case TxFileTypes.doc:
                    returnValue = BinaryStreamType.MSWord;
                    break;

                case TxFileTypes.docx:
                    returnValue = BinaryStreamType.MSWord;
                    break;

                case TxFileTypes.xls:
                    returnValue = BinaryStreamType.InternalFormat;
                    break;

                case TxFileTypes.xlsx:
                    returnValue = BinaryStreamType.InternalFormat;
                    break;

                case TxFileTypes.xml:
                    returnValue = BinaryStreamType.InternalFormat;
                    break;

                case TxFileTypes.tx:
                    returnValue = BinaryStreamType.InternalFormat;
                    break;

                case TxFileTypes.txt:
                    returnValue = BinaryStreamType.InternalUnicodeFormat;
                    break;

                case TxFileTypes.rtf:
                    returnValue = BinaryStreamType.InternalFormat;
                    break;

                case TxFileTypes.pdf:
                    returnValue = BinaryStreamType.AdobePDF;
                    break;

                case TxFileTypes.html:
                    returnValue = BinaryStreamType.InternalFormat;
                    break;

                case TxFileTypes.htm:
                    returnValue = BinaryStreamType.InternalFormat;
                    break;

                case TxFileTypes.xaml:
                    returnValue = BinaryStreamType.InternalFormat;
                    break;

                default:
                    returnValue = BinaryStreamType.InternalFormat;
                    break;
            }
            return returnValue;
        }

        /// <summary>
        /// Dosya adýndan dosya uzantýsýný Bul
        /// </summary>
        /// <param name="FileName">dosya adý</param>
        /// <returns>Uzantýsý</returns>
        public static string GetExtensionFromFileName(string FileName)
        {
            string[] splittedByDot = FileName.Split('.');
            return splittedByDot[splittedByDot.Length - 1].ToLower(new System.Globalization.CultureInfo("en-US"));
        }

        /// <summary>
        /// Dýosya adýný ayýrklar ve geeri donbdurur
        /// </summary>
        /// <param name="getExtension">uzantýsý da eklensinmi sonuna</param>
        /// <param name="FileName">dosya adý</param>
        /// <returns>dosyanýn temizlenbmis adý</returns>
        public static string GetFileNameFromFullName(bool getExtension, string FileName)
        {
            string clearFileName = "";
            string[] FilesName = new string[1];

            ///Dosya Adý içerisinde klasor adlarý da gelmnekte bu klasor adlarýný splitle ayýrdýk
            if (FileName.Contains("\\"))
            {
                FilesName = FileName.Split('\\');
            }
            else if (FileName.Contains("/"))
            {
                FilesName = FileName.Split('/');
            }

            // eger klasýor adlarý ile gelmiþse degisken dolu olacak
            if (FilesName.Length > 0)
            {
                /// dizi içerisindeki son eleman bizim dosytamnýsýn adýdýr .. .
                clearFileName = FilesName[FilesName.Length - 1];
            }
            else
            {
                // eger klasor yok direk dosya adýný aldýk
                clearFileName = FileName;
            }

            /// dosya adý geriye uzantý ile gidecekse
            if (getExtension)
            {
                return clearFileName;
            }
            else
            {
                int indOfLastDot = FileName.LastIndexOf('.');
                if (indOfLastDot > 0)
                {
                    return clearFileName.Remove(indOfLastDot);
                }
            }

            // Biþi yapamazsak ta artýk gelen yazýyý geri dondur .. .
            return FileName;
        }

        /// <summary>
        /// dosya adýný alýr ayýklar vew uzantýsý ile geriye doýndurur...
        /// </summary>
        /// <param name="FileName">Dosyanýn adý .. .</param>
        /// <returns>Uzantýsý ile Dosya Adý ...</returns>
        public static string GetFileNameFromFullName(string FileName)
        {
            return GetFileNameFromFullName(true, FileName);
        }

        /// <summary>
        /// Uzantýyta Gore Dosya Tipi Getir
        /// </summary>
        /// <param name="FileName">dosya adý</param>
        /// <returns>Dosyanýn tipi</returns>
        public static FileTypes GetFileTypeByExtension(string FileName)
        {
            FileExtensions fe = new FileExtensions();
            try
            {
                fe = FileExtensions.Find(GetExtensionFromFileName(FileName));
            }
            catch 
            {
                fe = new FileExtensions();
                fe.FileType = FileTypes.Other;
            }

            return fe.FileType;
        }

        /// <summary>
        /// Dosya uzantýsýna gore Tx StreamType Dondurur
        /// </summary>
        /// <param name="ft"></param>
        /// <returns></returns>
        public static StreamType GetStreamTypeByFileType(TxFileTypes ft)
        {
            StreamType returnValue = StreamType.InternalFormat;
            switch (ft)
            {
                case TxFileTypes.doc:
                    returnValue = StreamType.MSWord;
                    break;

                case TxFileTypes.docx:
                    returnValue = StreamType.WordprocessingML;
                    break;

                case TxFileTypes.xls:
                    returnValue = StreamType.InternalFormat;
                    break;

                case TxFileTypes.xlsx:
                    returnValue = StreamType.InternalFormat;
                    break;

                case TxFileTypes.xml:
                    returnValue = StreamType.XMLFormat;
                    break;

                case TxFileTypes.tx:
                    returnValue = StreamType.InternalFormat;
                    break;

                case TxFileTypes.txt:
                    returnValue = StreamType.PlainText;
                    break;

                case TxFileTypes.rtf:
                    returnValue = StreamType.RichTextFormat;
                    break;

                case TxFileTypes.pdf:
                    returnValue = StreamType.AdobePDF;
                    break;

                case TxFileTypes.html:
                    returnValue = StreamType.HTMLFormat;
                    break;

                case TxFileTypes.htm:
                    returnValue = StreamType.HTMLFormat;
                    break;

                case TxFileTypes.xaml:
                    returnValue = StreamType.XMLFormat;
                    break;

                case TxFileTypes.tif:

                default:
                    returnValue = StreamType.InternalFormat;
                    break;
            }

            return returnValue;
        }

        /// <summary>
        /// Gonderilen Kontrol icerisindeki kontrollerin hepsinin editvalue changed ýný gonderilen
        /// metoda yonlendirir
        /// </summary>
        /// <param name="Parent">Kontrollerin içinde Bulunduýgu Kontrol ..</param>
        /// <param name="EditValueChangedMethod">Calýsacak Metod ...</param>
        public static void SetControlsEditValueChangedEvents(Control Parent, EventHandler EditValueChangedMethod)
        {
            for (int i = 0; i < Parent.Controls.Count; i++)
            {
                if (Parent.Controls[i] is BaseEdit)
                {
                    ((BaseEdit)Parent.Controls[i]).EditValueChanged += EditValueChangedMethod;
                }
            }
        }

        /// <summary>
        /// temp klasorune (TempFilePAth) Byte[] ile gelen verileri uzantýsý ile dosya oluþturr ve
        /// yazar
        /// </summary>
        /// <param name="data">yazýlacak veriler</param>
        /// <param name="extension">dosya nýn uzanstýsý (Media player uzantyýsý olmayan dosyada
        /// sorun cýkartabilityor )</param>
        /// <returns>Dosyanýn</returns>
        public static string WriteBytesToTemp(byte[] data, string extension)
        {
            try
            {
                string fileName = TempFilePath + DateTime.Now.ToString().Replace(":", "_").Replace(".", "_") + DateTime.Now.Millisecond.ToString() + "." + extension;
                if (!Directory.Exists(TempFilePath))
                {
                    Directory.CreateDirectory(TempFilePath);
                }
                FileStream FS = new FileStream(fileName, FileMode.Create);
                FS.Write(data, 0, data.Length);
                FS.Close();
                return fileName;
            }
            catch 
            {
                return "";
            }
        }

        //public static void ConvertRecordToBelgerecord(object record)
        //{
        //    if ()
        //    {
        //    }
        //}
    }
}