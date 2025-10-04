using System;

namespace AvukatPro.Net.Mail
{
    public class SmtpClientException : Exception
    {
        public SmtpClientException(string error_message)
        {
            EmailLogger.Logger.Error(error_message);
            this.errorMessage = error_message;
        }

        private string errorMessage = "";

        public string ErrorMessage
        {
            get
            {
                return this.errorMessage;
            }
        }
    }
}