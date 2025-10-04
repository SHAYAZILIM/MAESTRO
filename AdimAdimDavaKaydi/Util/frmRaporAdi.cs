namespace AdimAdimDavaKaydi.Util
{
    public partial class frmRaporAdi : DevExpress.XtraEditors.XtraForm
    {
        public frmRaporAdi()
        {
            InitializeComponent();
        }

        public bool Kaydedilsinmi
        {
            get { return checkEdit1.Checked; }
        }

        public string RaporBasligi
        {
            get { return tBoxRaporBasligi.Text; }
        }
    }
}