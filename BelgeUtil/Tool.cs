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
        /// Temp Klasor Yolu Dosyalar�n gecici kaydedilgi yer ...
        /// </summary>
        public static string TempFilePath = Application.StartupPath + "\\Temp\\";

        /// <summary>
        /// Dosya Uzant�s�na gore Tx Binnary Stream Type Dondurur
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
        /// Dosya ad�ndan dosya uzant�s�n� Bul
        /// </summary>
        /// <param name="FileName">dosya ad�</param>
        /// <returns>Uzant�s�</returns>
        public static string GetExtensionFromFileName(string FileName)
        {
            string[] splittedByDot = FileName.Split('.');
            return splittedByDot[splittedByDot.Length - 1].ToLower(new System.Globalization.CultureInfo("en-US"));
        }

        /// <summary>
        /// D�osya ad�n� ay�rklar ve geeri donbdurur
        /// </summary>
        /// <param name="getExtension">uzant�s� da eklensinmi sonuna</param>
        /// <param name="FileName">dosya ad�</param>
        /// <returns>dosyan�n temizlenbmis ad�</returns>
        public static string GetFileNameFromFullName(bool getExtension, string FileName)
        {
            string clearFileName = "";
            string[] FilesName = new string[1];

            ///Dosya Ad� i�erisinde klasor adlar� da gelmnekte bu klasor adlar�n� splitle ay�rd�k
            if (FileName.Contains("\\"))
            {
                FilesName = FileName.Split('\\');
            }
            else if (FileName.Contains("/"))
            {
                FilesName = FileName.Split('/');
            }

            // eger klas�or adlar� ile gelmi�se degisken dolu olacak
            if (FilesName.Length > 0)
            {
                /// dizi i�erisindeki son eleman bizim dosytamn�s�n ad�d�r .. .
                clearFileName = FilesName[FilesName.Length - 1];
            }
            else
            {
                // eger klasor yok direk dosya ad�n� ald�k
                clearFileName = FileName;
            }

            /// dosya ad� geriye uzant� ile gidecekse
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

            // Bi�i yapamazsak ta art�k gelen yaz�y� geri dondur .. .
            return FileName;
        }

        /// <summary>
        /// dosya ad�n� al�r ay�klar vew uzant�s� ile geriye do�ndurur...
        /// </summary>
        /// <param name="FileName">Dosyan�n ad� .. .</param>
        /// <returns>Uzant�s� ile Dosya Ad� ...</returns>
        public static string GetFileNameFromFullName(string FileName)
        {
            return GetFileNameFromFullName(true, FileName);
        }

        /// <summary>
        /// Uzant�yta Gore Dosya Tipi Getir
        /// </summary>
        /// <param name="FileName">dosya ad�</param>
        /// <returns>Dosyan�n tipi</returns>
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
        /// Dosya uzant�s�na gore Tx StreamType Dondurur
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
        /// Gonderilen Kontrol icerisindeki kontrollerin hepsinin editvalue changed �n� gonderilen
        /// metoda yonlendirir
        /// </summary>
        /// <param name="Parent">Kontrollerin i�inde Bulundu�gu Kontrol ..</param>
        /// <param name="EditValueChangedMethod">Cal�sacak Metod ...</param>
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
        /// temp klasorune (TempFilePAth) Byte[] ile gelen verileri uzant�s� ile dosya olu�turr ve
        /// yazar
        /// </summary>
        /// <param name="data">yaz�lacak veriler</param>
        /// <param name="extension">dosya n�n uzanst�s� (Media player uzanty�s� olmayan dosyada
        /// sorun c�kartabilityor )</param>
        /// <returns>Dosyan�n</returns>
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