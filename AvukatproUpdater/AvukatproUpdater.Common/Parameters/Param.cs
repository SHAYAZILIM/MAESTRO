using System;
using System.IO;
using System.Windows.Forms;

namespace AvukatproUpdater.Common.Parameters
{
    public class Param
    {
        #region Fields

        public string AppBackupFolder = String.Format(@"{0}\Backups\ApplicationBackup", Directory.GetParent(Application.StartupPath).FullName);
        public string AppFolder = Directory.GetParent(Application.StartupPath).FullName;
        public string DbBackupFolder = String.Format(@"{0}\Backups\DbBackup", Directory.GetParent(Application.StartupPath).FullName);
        public string DownloadsFolder = String.Format(@"{0}\Downloads", Directory.GetParent(Application.StartupPath).FullName);
        public string LogsFolder = String.Format(@"{0}\Logs", Directory.GetParent(Application.StartupPath).FullName);
        public string UpdateServerUri = "http://avukatpro.com/AVPLisans/LicenceControl.asmx";
        public bool WorkOnline = false;

        #endregion Fields

        #region Properties

        public bool IsBothClientAndServer
        {
            get;
            set;
        }

        public string ServerDbVersion
        {
            get;
            set;
        }

        public string ServerExeVersion
        {
            get;
            set;
        }

        public DateTime TimeSchedule
        {
            get;
            set;
        }

        #endregion Properties
    }
}