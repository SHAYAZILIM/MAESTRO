namespace AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge
{
    public partial class frmBrowser : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmBrowser()
        {
            InitializeComponent();
        }

        public void navigate(string url)
        {
            this.Show();
            this.browser1.brw.Navigate(url);
        }
    }
}