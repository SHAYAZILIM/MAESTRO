using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aOutlook = Microsoft.Office.Interop.Outlook;

namespace AvukatPro.Outlook
{
    public partial class frmMailSettings : Form
    {
        public frmMailSettings()
        {
            InitializeComponent();
        }

        public aOutlook.MailItem MailItem { get; set; }
        public List<string> FileList { get; set; }

        private void frmMailSettings_Load(object sender, EventArgs e)
        {
            FileList = new List<string>();
            foreach (aOutlook.Attachment item in MailItem.Attachments)
            {
                chkAttachs.Items.Add(item.FileName, true);
            }
        }

        private void rdAttachs_CheckedChanged(object sender, EventArgs e)
        {
            chkAttachs.Enabled = rdAttachs.Checked;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rdAttachs.Checked)
            {

                foreach (aOutlook.Attachment item in MailItem.Attachments)
                {
                    if (!chkAttachs.CheckedItems.Cast<string>().Any(q => q == item.FileName))
                        continue;
                    string filename = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Guid.NewGuid().ToString() + Path.GetExtension(item.FileName));
                    item.SaveAsFile(filename);
                    FileList.Add(filename);
                }
            }
            else
            {
                string filename = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Guid.NewGuid().ToString() + ".msg");
                MailItem.SaveAs(filename);
                FileList.Add(filename);
            }
        }
    }
}
