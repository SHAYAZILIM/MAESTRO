using System;

namespace AvukatproUpdater.Common.Events
{
    #region Enumerations

    public enum OperationType : byte
    {
        UpdateControlStart = 1,
        UpdateControlCompleted = 2,
        ApplicationDownloadStart = 3,
        ApplicationDownloadCompleted = 4,
        DbSchemaAndScriptsDownloadStart = 5,
        DbSchemaAndScriptsDownloadCompleted = 6,
        ApplicationBackupStart = 7,
        ApplicationBackupCompleted = 8,
        DbBackupStart = 9,
        DbBackupCompleted = 10,
        ExtractApplicationZipStart = 11,
        ExtractApplicationZipCompleted = 12,
        ExtractDbSchemaAndScriptsZipStart = 13,
        ExtractDbSchemaAndScriptsZipCompleted = 14,
        PreScriptExecutionStart = 15,
        PreScriptExecutionCompleted = 16,
        LoadSchemaAndDbStart = 17,
        LoadSchemaAndDbCompleted = 18,
        DbCompareStart = 19,
        DbCompareCompleted = 20,
        SynchronizationScriptExecutionStart = 21,
        SynchronizationScriptExecutionCompleted = 22,
        PostScriptExecutionStart = 23,
        PostScriptExecutionCompleted = 24,
        ApplicationSetupStart = 25,
        ApplicationSetupCompleted = 26,
        UpdateChanges = 27,
        UpdateChangesCompleted = 28,
        RollBackChanges = 29,
        Exit = 30
    }

    #endregion Enumerations

    public class UpdateEventArgs : EventArgs
    {
        #region Fields

        private readonly OperationType _operationType;

        #endregion Fields

        #region Constructors

        public UpdateEventArgs(OperationType operationType)
        {
            _operationType = operationType;
        }

        #endregion Constructors

        #region Properties

        public OperationType OperationType
        {
            get
            {
                return _operationType;
            }
        }

        #endregion Properties
    }
}