using AvukatproUpdater.Common.Controls;
using AvukatproUpdater.Common.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace AvukatproUpdater.Common.FileOperations
{
    public class FileUtility
    {
        #region Fields

        public UpdateFormBase formBase;
        public UpdaterServiceBase serviceBase;

        private BackgroundWorker bgWorkerCopyDirectory;
        private BackgroundWorker bgWorkerCopyFile;
        private string destPath;
        private ProgressChanged OnChange;
        private CopyError OnError;
        private ProgressControl progressControl;
        private string sourcePath;

        #endregion Fields

        #region Constructors

        public FileUtility(UpdaterServiceBase serviceBase)
        {
            this.serviceBase = serviceBase;
        }

        public FileUtility(UpdateFormBase formBase)
        {
            this.formBase = formBase;
            bgWorkerCopyDirectory = new BackgroundWorker();
            bgWorkerCopyDirectory.WorkerReportsProgress = true;
            bgWorkerCopyDirectory.DoWork += new DoWorkEventHandler(bgWorkerCopyDirectory_DoWork);
            bgWorkerCopyDirectory.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorkerCopyDirectory_RunWorkerCompleted);

            bgWorkerCopyFile = new BackgroundWorker();
            bgWorkerCopyFile.WorkerReportsProgress = true;
            bgWorkerCopyFile.DoWork += new DoWorkEventHandler(bgWorkerCopyFile_DoWork);
            bgWorkerCopyFile.ProgressChanged += new ProgressChangedEventHandler(bgWorkerCopyFile_ProgressChanged);
            bgWorkerCopyFile.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorkerCopyFile_RunWorkerCompleted);
            OnChange += Copier_ProgressChanged;
        }

        #endregion Constructors

        #region Enumerations

        [Flags]
        private enum CopyFileFlags : uint
        {
            COPY_FILE_FAIL_IF_EXISTS = 0x00000001,
            COPY_FILE_RESTARTABLE = 0x00000002,
            COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004,
            COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008
        }

        private enum CopyProgressCallbackReason : uint
        {
            CALLBACK_CHUNK_FINISHED = 0x00000000,
            CALLBACK_STREAM_SWITCH = 0x00000001
        }

        private enum CopyProgressResult : uint
        {
            PROGRESS_CONTINUE = 0,
            PROGRESS_CANCEL = 1,
            PROGRESS_STOP = 2,
            PROGRESS_QUIET = 3
        }

        #endregion Enumerations

        #region Delegates

        private delegate void CopyError(UIError err);

        private delegate CopyProgressResult CopyProgressRoutine(
            long TotalFileSize,
            long TotalBytesTransferred,
            long StreamSize,
            long StreamBytesTransferred,
            uint dwStreamNumber,
            CopyProgressCallbackReason dwCallbackReason,
            IntPtr hSourceFile,
            IntPtr hDestinationFile,
            IntPtr lpData);

        private delegate void ProgressChanged(UIProgress info);

        #endregion Delegates

        #region Methods

        public void CopyDirectory(string sourcePath, string destPath, DirectoryCopyType copyType)
        {
            this.sourcePath = sourcePath;
            this.destPath = destPath;
            serviceBase.eventLog.WriteEntry("Dosyalar kopyalanıyor...");
            if (CopyDir(sourcePath, destPath, false))
            {
                serviceBase.eventLog.WriteEntry("Dosyalar başarıyla kopyalandı.");
                switch (copyType)
                {
                    case DirectoryCopyType.ApplicationBackup: serviceBase.OperationType = OperationType.ApplicationBackupCompleted; break;
                    case DirectoryCopyType.ApplicationSetup: serviceBase.OperationType = OperationType.ApplicationSetupCompleted; break;
                }
            }
            else
            {
                serviceBase.OperationType = OperationType.Exit;
            }
        }

        public void CopyDirectoryAsync(string sourcePath, string destPath, ProgressControl progressControl)
        {
            this.sourcePath = sourcePath;
            this.destPath = destPath;
            this.progressControl = progressControl;
            progressControl.Visible = progressControl.DownloadMode = true;
            progressControl.Text = "Dosyalar kopyalanıyor...";
            progressControl.ProcessCompleted = false;
            Thread.Sleep(1000);
            bgWorkerCopyDirectory.RunWorkerAsync();
        }

        public void CopyFileAsync(string sourcePath, string destPath, ProgressControl progressControl)
        {
            this.sourcePath = sourcePath;
            this.destPath = destPath;
            this.progressControl = progressControl;
            progressControl.Text = "Dosya(lar) indiriliyor...";
            progressControl.ProcessCompleted = false;
            progressControl.Visible = progressControl.DownloadMode = true;
            bgWorkerCopyFile.RunWorkerAsync();
        }
        
        private void bgWorkerCopyDirectory_DoWork(object sender, DoWorkEventArgs e)
        {
            CopyDir(sourcePath, destPath, true);
        }

        private void bgWorkerCopyDirectory_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressControl.ProcessCompleted = true;
            if (e.Error != null)
            {
                progressControl.Text = "Dosyalar kopyalanırken hata oluştu...";
                formBase.OperationType = OperationType.Exit;
            }
            else
            {
                progressControl.ProgressValue = 0;
                progressControl.DownloadMode = false;
                progressControl.Text = "Uygulama yedeklemesi tamamlandı...";
                formBase.OperationType = OperationType.ApplicationBackupCompleted;
            }
        }

        private void bgWorkerCopyFile_DoWork(object sender, DoWorkEventArgs e)
        {
            CopyFile(sourcePath, destPath, true);
        }

        private void bgWorkerCopyFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressControl.ProgressValue = e.ProgressPercentage;
        }

        private void bgWorkerCopyFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                progressControl.Text = "Dosya(lar) indirilirken hata oluştu...";
                formBase.OperationType = OperationType.Exit;
            }
            else
            {
                progressControl.ProcessCompleted = true;
                progressControl.ProgressValue = 0;
                progressControl.DownloadMode = false;
                progressControl.Text = "Dosya indirme işlemi tamamlandı...";
                formBase.OperationType = OperationType.ApplicationDownloadCompleted;
            }
        }

        private void Copier_ProgressChanged(UIProgress info)
        {
            // Update progress
            info.progressControl.DownloadMode = true;
            info.progressControl.BringToFront();
            if (info.maxbytes != 0)
                info.progressControl.ProgressValue = (int)(100.0 * info.bytes / info.maxbytes);
            else info.progressControl.ProgressValue = 100;
            info.progressControl.Text = String.Format("Kopyalanıyor {0}...", info.name);
        }

        private bool CopyDir(string sourcePath, string destPath, bool isAsync)
        {
            if (!Directory.Exists(sourcePath))
            {
                if (isAsync)
                {
                    MessageBox.Show(String.Format("Kaynak dizin bulunamadı.\nDizin: {0}", sourcePath));
                    formBase.OperationType = OperationType.Exit;
                }
                else if (serviceBase != null)
                {
                    serviceBase.eventLog.WriteEntry(String.Format("Kaynak dizin bulunamadı.\nDizin: {0}", sourcePath));
                    serviceBase.OperationType = OperationType.Exit;
                }
            }
            long maxbytes = 0;
            Dictionary<string, List<string>> Files = GetFiles(sourcePath, destPath, ref maxbytes);
            long bytes = 0;

            foreach (string dirs in Files.Keys)
            {
                foreach (string Element in Files[dirs])
                {
                    try
                    {
                        if (isAsync)
                        {
                            formBase.BeginInvoke(OnChange, new object[] { new UIProgress(Path.GetFileName(Element), bytes, maxbytes, progressControl) });
                        }
                        File.Copy(Element, Path.Combine(dirs, Path.GetFileName(Element)), true);
                        bytes += new FileInfo(Element).Length;
                    }
                    catch (Exception ex)
                    {
                        if (isAsync)
                        {
                            UIError err = new UIError(ex, Element);
                            formBase.Invoke(OnError, new object[] { err });
                            if (err.result == DialogResult.Cancel) break;
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private void CopyFile(string sourcePath, string destPath, bool isAsync)
        {
            //{
            //    using (FileStream outFile = new FileStream(destPath, FileMode.Create))
            //    {
            //        long size = inFile.Length;
            //        byte[] buffer = new byte[1024];
            //        while ((inFile.Read(buffer, 0, buffer.Length)) > 0)
            //        {
            //            outFile.Write(buffer, 0, buffer.Length);
            //            if (isAsync) bgWorkerCopyFile.ReportProgress(Convert.ToInt16(inFile.Position / size * 100));
            //            Application.DoEvents();
            //        }
            //    }
            //}
            if (isAsync)
            // XCopy(sourcePath, destPath);
            {
                if (!Directory.Exists(Path.GetDirectoryName(destPath))) Directory.CreateDirectory(Path.GetDirectoryName(destPath));
                using (FileStream inFile = new FileStream(sourcePath, System.IO.FileMode.Open))
                {
                    using (FileStream outFile = new FileStream(destPath, System.IO.FileMode.Create))
                    {
                        long size = inFile.Length;
                        int lineSize = 4096;
                        byte[] buffer = new byte[lineSize];
                        while ((inFile.Read(buffer, 0, lineSize)) > 0)
                        {
                            outFile.Write(buffer, 0, lineSize);
                            bgWorkerCopyFile.ReportProgress(Convert.ToInt16(Convert.ToDouble(inFile.Position) / Convert.ToDouble(size) * 100.0));
                        }
                    }
                }
            }
            else File.Copy(sourcePath, destPath, true);
        }

        private Dictionary<string, List<string>> GetFiles(string sourcePath, string destPath, ref long totalFileSize)
        {
            long maxLength = 0;
            List<string> Files = new List<string>(Directory.GetFileSystemEntries(sourcePath));
            Dictionary<string, List<string>> FileList = new Dictionary<string, List<string>>();
            if (destPath[destPath.Length - 1] != Path.DirectorySeparatorChar)
                destPath += Path.DirectorySeparatorChar;
            if (!Directory.Exists(destPath)) Directory.CreateDirectory(destPath);
            FileList.Add(destPath, new List<string>());
            Files.ForEach(file =>
            {
                if (File.Exists(file)) // This is a file
                {
                    FileList[destPath].Add(file);
                    maxLength += new FileInfo(file).Length;
                }
                else // This is a directory
                {
                    if (!Directory.Exists(Path.Combine(destPath, Path.GetFileName(file)))) Directory.CreateDirectory(Path.Combine(destPath, Path.GetFileName(file)));
                    if (Directory.Exists(file) && Path.GetFileNameWithoutExtension(file).ToLower() != "backups" && Directory.Exists(file) && Path.GetFileNameWithoutExtension(file).ToLower() != "updater")
                    {
                        Dictionary<string, List<string>> tmpDict = GetFiles(file, Path.Combine(destPath, Path.GetFileName(file)), ref maxLength);
                        foreach (string key in tmpDict.Keys)
                            FileList.Add(key, tmpDict[key]);
                    }
                }
            });

            totalFileSize += maxLength;
            return FileList;
        }

        #endregion Methods

        #region Nested Types

        private class UIError
        {
            #region Fields

            public string msg;
            public string path;
            public DialogResult result;

            #endregion Fields

            #region Constructors

            public UIError(Exception ex, string _path)
            {
                msg = ex.Message;
                path = _path;
                result = DialogResult.Cancel;
            }

            #endregion Constructors
        }

        private class UIProgress
        {
            #region Fields

            public long bytes;
            public long maxbytes;
            public string name;
            public ProgressControl progressControl;

            #endregion Fields

            #region Constructors

            public UIProgress(string _name, long _bytes, long _maxbytes, ProgressControl _progressControl)
            {
                name = _name;
                bytes = _bytes;
                maxbytes = _maxbytes;
                progressControl = _progressControl;
            }

            #endregion Constructors
        }

        #endregion Nested Types
    }
}