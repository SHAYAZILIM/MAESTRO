using System.Collections.Generic;

namespace BelgeUtil
{
    public class FileExtensions
    {
        public FileExtensions()
        {
            //lstExtensions = new List<FileExtensions>();
        }

        /// <summary>
        /// Crystal Report viwwer a ait Uzantýlar..
        /// </summary>
        private static string[] crystalExtensions = new string[] { "rpt", };

        /// <summary>
        /// Excel 2007 Ait uzantýlar
        /// </summary>
        private static string[] Excel07Extensions = new string[] { "xlsx" };

        /// <summary>
        /// Excele Ait uzantýlar
        /// </summary>
        private static string[] ExcelExtensions = new string[] { "xls" };

        /// <summary>
        /// Image'e ait uzantýlar
        /// </summary>
        private static string[] ImageExtensions = new string[] { "tif" };

        private static List<FileExtensions> lstExtensions;

        /// <summary>
        /// textControle ait Uzantýlar
        /// </summary>
        private static string[] txExtensions = new string[] { "mdb", "doc", "docx", "tx", "xml", "txt" };

        /// <summary>
        /// Media Player ile Acýlabilecek uzantýlar
        /// </summary>
        private static string[] videoExtensions = new string[] {"mpeg" ,"mpg" ,"avi" ,"wma" ,
        "wmv" ,"wm","asx" ,"wax" ,"wvx" ,"wpl" ,"wax" ,"wvx" ,"wmx" ,"dvr-ms" ,"wmd",
        "m1v" ,"mp2" ,"mp3" ,"mpa" ,"mpe" ,"mpv2" ,"m3u" ,"m1v" ,"mid" ,"midi" ,"rmi" ,
        "aif" ,"aifc" ,"aiff" ,"au" ,"snd" ,"cda" ,"ivf" ,"wmz" ,"wms" ,"mov"  ,"qt" };

        /// <summary>
        /// Webrowser a ait uzantýlar
        /// </summary>
        private static string[] wbExtensions = new string[] { "swf", "cs", "aspx", "jpeg", "jpg", "gif", "png", "pdf", "html", "htm", "xml" };

        private string extension;

        private FileTypes fileType = FileTypes.TextFile;

        /// <summary>
        /// Uzanti
        /// </summary>
        public string Extension
        {
            get { return extension; }
            set { extension = value; }
        }

        /// <summary>
        /// Dosya Tipi
        /// </summary>
        public FileTypes FileType
        {
            get { return fileType; }
            set { fileType = value; }
        }

        public static List<FileExtensions> FillSystemExtensions()
        {
            GetExtensionFromarray(crystalExtensions, FileTypes.CrystalReportFile);
            GetExtensionFromarray(wbExtensions, FileTypes.WebFile);
            GetExtensionFromarray(txExtensions, FileTypes.TextControlFile);
            GetExtensionFromarray(videoExtensions, FileTypes.VideoFile);
            GetExtensionFromarray(ExcelExtensions, FileTypes.ExcelFile);
            GetExtensionFromarray(Excel07Extensions, FileTypes.Excel07File);
            GetExtensionFromarray(ImageExtensions, FileTypes.TifFile);

            return lstExtensions;
        }

        /// <summary>
        /// Dosya uzantsýna gore dosya tipi bulur
        /// </summary>
        /// <param name="Extension"></param>
        /// <returns></returns>
        public static FileExtensions Find(string Extension)
        {
            if (lstExtensions == null || lstExtensions.Count == 0)
            {
                FillSystemExtensions();
            }

            for (int i = 0; i < lstExtensions.Count; i++)
            {
                if (lstExtensions[i].Extension.ToLower(new System.Globalization.CultureInfo("en-US")) == Extension.ToLower(new System.Globalization.CultureInfo("en-US")))
                {
                    return lstExtensions[i];
                }
            }

            return new FileExtensions();
        }

        /// <summary>
        /// dosya tipine gore bilgisini verir
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static FileExtensions Find(FileTypes type)
        {
            for (int i = 0; i < lstExtensions.Count; i++)
            {
                if (lstExtensions[i].FileType == type)
                {
                    return lstExtensions[i];
                }
            }
            return new FileExtensions();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="extensionArray"></param>
        private static void GetExtensionFromarray(string[] extensionArray, FileTypes tip)
        {
            if (lstExtensions == null)
            {
                lstExtensions = new List<FileExtensions>();
            }
            for (int i = 0; i < extensionArray.Length; i++)
            {
                FileExtensions fex = new FileExtensions();
                fex.Extension = extensionArray[i];
                fex.FileType = tip;
                lstExtensions.Add(fex);
            }
        }
    }
}