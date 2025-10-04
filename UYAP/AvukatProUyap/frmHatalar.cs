using System;

namespace AdimAdimDavaKaydi
{
    public partial class frmHatalar : DevExpress.XtraEditors.XtraForm
    {
        public frmHatalar()
        {
            InitializeComponent();
        }

        public void HataEkle(DevExpress.XtraNavBar.NavBarItem hata)
        {
            HatalarNB.ItemLinks.Add(hata);
            HatalarNB.Caption = "Hatalar (" + HatalarNB.ItemLinks.Count + ")";
        }

        public void UyariEkle(DevExpress.XtraNavBar.NavBarItem uyari)
        {
            UyarilarNB.ItemLinks.Add(uyari);
            UyarilarNB.Caption = "Uyarýlar (" + UyarilarNB.ItemLinks.Count + ")";
        }

        public void XMLBastir(string dosyaYolu)
        {
            UyapWB.Url = new Uri(dosyaYolu);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}