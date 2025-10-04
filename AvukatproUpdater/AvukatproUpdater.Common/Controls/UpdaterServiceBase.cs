using AvukatproUpdater.Common.Events;
using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Text;

namespace AvukatproUpdater.Common.Controls
{
    public partial class UpdaterServiceBase : ServiceBase
    {
        #region Fields

        private OperationType operationType;

        #endregion Fields

        #region Constructors

        public UpdaterServiceBase()
        {
            InitializeComponent();
            UpdateOperationChanged += new UpdateEventHandler(SwitchToOperation);
        }

        #endregion Constructors

        #region Delegates

        public delegate void UpdateEventHandler(object sender, UpdateEventArgs e);

        #endregion Delegates

        #region Events

        public event UpdateEventHandler UpdateOperationChanged;

        #endregion Events

        #region Properties

        public bool HasErrors
        {
            set
            {
                if (value) RestartService();
            }
        }

        public OperationType OperationType
        {
            get { return operationType; }
            set
            {
                operationType = value;
                if (UpdateOperationChanged != null)
                    UpdateOperationChanged(this, new UpdateEventArgs(operationType));
            }
        }

        #endregion Properties

        #region Methods

        public void RestartService()
        {
            string currentDir = Path.GetDirectoryName(Microsoft.Win32.Registry.LocalMachine.OpenSubKey(String.Format("System\\CurrentControlSet\\Services\\{0}", this.ServiceName)).GetValue("ImagePath").ToString().Replace("\"", ""));
            string vbsFile = Path.Combine(currentDir, "script.vbs");
            string batchFile = Path.Combine(currentDir, "service.bat");

            #region Batch dosyası

            StringBuilder sbBatch = new StringBuilder();
            sbBatch.AppendFormat("net stop \"{0}\"", this.ServiceName);
            sbBatch.AppendLine();
            sbBatch.AppendFormat("net start \"{0}\"", this.ServiceName);

            #endregion Batch dosyası

            if (File.Exists(batchFile)) File.Delete(batchFile);
            try
            {
                File.WriteAllText(batchFile, sbBatch.ToString());
                eventLog.WriteEntry("Service restart ediliyor.");
                ProcessStartInfo inf = new ProcessStartInfo(batchFile);
                inf.CreateNoWindow = true;
                Process.Start(inf);
            }
            catch (Exception)
            {
            }
        }

        public virtual void SwitchToOperation(object sender, UpdateEventArgs e)
        {
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }

        #endregion Methods
    }
}