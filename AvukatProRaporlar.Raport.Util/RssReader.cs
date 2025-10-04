using System;
using System.Collections;
using System.Xml;

namespace AvukatProRaporlar.Util
{
    /// <summary>
    /// Represents the method that will handle the RssReader error event.
    /// </summary>
    public delegate void RssReaderErrorEventHandler(object sender, RssReaderErrorEventArgs e);
    
    /// <summary>
    /// Holds details about any errors that occured during the loading or parsing of the RSS feed.
    /// </summary>
    public class RssReaderErrorEventArgs : EventArgs
    {
        private string message;

        /// <summary>
        /// The details of the error.
        /// </summary>
        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }
        }
    }
}