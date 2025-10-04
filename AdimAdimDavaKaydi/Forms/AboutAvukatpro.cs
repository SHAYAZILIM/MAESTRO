using System;
using System.Reflection;

namespace AdimAdimDavaKaydi.Forms
{
    internal partial class AboutAvukatpro : DevExpress.XtraEditors.XtraForm
    {
        public AboutAvukatpro()
        {
            InitializeComponent();

            //  Initialize the AboutBox to display the product information from the assembly information.
            //  Change assembly information settings for your application through either:
            //  - Project->Properties->Application->Assembly Information
            //  - AssemblyInfo.cs
            //TODO: Þimdilik el ile yazdýk deðiþecek. --THSN--
            // this.Text = String.Format("About {0}", AssemblyTitle);
            //this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);

            //this.labelCopyright.Text = AssemblyCopyright;
            //this.labelCompanyName.Text = AssemblyCompany;
            //this.textBoxDescription.Text = AssemblyDescription;
        }

        #region Assembly Attribute Accessors

        public string AssemblyVersion
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        #endregion Assembly Attribute Accessors

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Tools.OpenWebSite("http://www.avukatpro.com");
        }
    }
}