using System.Collections;

namespace AvukatPro.Net.Mail
{
    public enum MailEncodingType
    {
        PLAINTEXT,
        HTML
    }

    public enum MailSendPriority
    {
        HIGH,
        NORMAL,
        LOW
    }

    public class MailMessage
    {
        // Constructors
        public MailMessage()
        {
            this.from = "";
            this.to = "";
            this.cc = "";
            this.bcc = "";
            this.subject = "";
            this.message = "";
            this.mailEncodingType = MailEncodingType.PLAINTEXT;
            this.mailSendPriority = MailSendPriority.NORMAL;
            this.attachments = new ArrayList();
        }

        public MailMessage(string from, string recipient)
        {
            this.from = from;
            this.to = recipient;
            this.cc = "";
            this.bcc = "";
            this.subject = "";
            this.message = "";
            this.mailEncodingType = MailEncodingType.PLAINTEXT;
            this.mailSendPriority = MailSendPriority.NORMAL;
            this.attachments = new ArrayList();
        }

        public MailMessage(string from, string recipient, string subject, string body)
        {
            this.from = from;
            this.to = recipient;
            this.cc = "";
            this.bcc = "";
            this.subject = subject;
            this.message = body;
            this.mailEncodingType = MailEncodingType.PLAINTEXT;
            this.mailSendPriority = MailSendPriority.NORMAL;
            this.attachments = new ArrayList();
        }

        private ArrayList attachments;

        private string bcc;

        private string cc;

        // Data Members
        private string from;

        private MailEncodingType mailEncodingType;
        private MailSendPriority mailSendPriority;
        private string message;
        private string subject;
        private string to;

        public int AttachmentCount
        {
            get
            {
                return this.attachments.Count;
            }
        }

        public ArrayList Attachments
        {
            get
            {
                return this.attachments;
            }
            set
            {
                this.attachments = value;
            }
        }

        public string BCC
        {
            get
            {
                return this.bcc;
            }
            set
            {
                this.bcc = value;
            }
        }

        public string CC
        {
            get
            {
                return this.cc;
            }
            set
            {
                this.cc = value;
            }
        }

        // Properties
        public string From
        {
            get
            {
                return this.from;
            }
            set
            {
                this.from = value;
            }
        }

        public MailSendPriority MailPriority
        {
            get
            {
                return this.mailSendPriority;
            }
            set
            {
                this.mailSendPriority = value;
            }
        }

        public MailEncodingType MailType
        {
            get
            {
                return this.mailEncodingType;
            }
            set
            {
                this.mailEncodingType = value;
            }
        }

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

        public string Subject
        {
            get
            {
                return this.subject;
            }
            set
            {
                this.subject = value;
            }
        }

        public string To
        {
            get
            {
                return this.to;
            }
            set
            {
                this.to = value;
            }
        }
    }
}