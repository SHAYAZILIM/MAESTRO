using System;

namespace AVPSchemaGenerator.Common
{
    public class MessageEventArgs : EventArgs
    {
        #region Fields

        private readonly int _count;
        private readonly bool _dontShowInProgCtrl;
        private readonly bool _downloadMode;
        private readonly bool _logMessage;
        private readonly string _message;
        private readonly string _messageBoxText;
        private readonly bool _processCompleted;
        private readonly int _progressValue;
        private readonly bool _showMessagebox;
        private readonly bool _showProgress;

        #endregion Fields

        #region Constructors

        public MessageEventArgs(string message)
        {
            this._message = message;
        }
        
        public MessageEventArgs(string message, bool logMessage)
        {
            this._message = message;
            this._logMessage = logMessage;
        }

        #endregion Constructors

        #region Properties

        public int Count
        {
            get { return this._count; }
        }

        public bool DontShowInProgCtrl
        {
            get { return this._dontShowInProgCtrl; }
        }

        public bool IsDownloadMode
        {
            get { return this._downloadMode; }
        }

        public bool LogMessage
        {
            get { return this._logMessage; }
        }

        public string Message
        {
            get { return this._message; }
        }

        public string MessageBoxText
        {
            get { return this._messageBoxText; }
        }

        public bool ProcessCompleted
        {
            get { return this._processCompleted; }
        }

        public int ProgressValue
        {
            get { return this._progressValue; }
        }

        public bool ShowMessageBox
        {
            get { return this._showMessagebox; }
        }

        public bool ShowProgress
        {
            get { return this._showProgress; }
        }

        #endregion Properties
    }
}