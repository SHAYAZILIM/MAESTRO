using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Entegrasyon
{
    public partial class frmAvukatAta : Form
    {

        public frmAvukatAta(CustomerData customer, Classes.DosyaBilgileri dosya)
        {
            this.Customer = customer;
            this.Dosya = dosya;

            InitializeComponent();
        }

        //Aşağıdaki iki property yeni klasör ya da takip oluşturulurken bilgileri alıp ilgili tablolara aktarmak için kullanılacak.
        public CustomerData Customer { get; set; }

        public Classes.DosyaBilgileri Dosya { get; set; }

        private void frmAvukatAta_Load(object sender, EventArgs e)
        {
            //Müşteri sistemde yoksa sistemde yeni bir cari oluşturuluyor.
            if (Customer.Durum == (int)Enums.Durumlar.MusteriSistemdeYok)
            {
                Customer.CustomerID = Methods.DetermineCustomerCariID(Dosya.Musteri, Dosya.MusteriNo);

                if (Customer.Durum == (int)Enums.Durumlar.KlasoreBagli)
                {
                    this.Close();
                    return;
                }
            }

            BelgeUtil.Inits.SorumluAvukatGetir(lueSorumluAvukat);
            BelgeUtil.Inits.SorumluAvukatGetir(lueIzleyenAvukat);

            lueSorumluAvukat.EditValue = Customer.SorumluAvukatID;
            lueIzleyenAvukat.EditValue = Customer.IzleyenAvukatID;
        }

        private void sbtnAvukataAta_Click(object sender, EventArgs e)
        {
            Customer.SorumluAvukatID = (int)lueSorumluAvukat.EditValue;
            Customer.IzleyenAvukatID = (int)lueIzleyenAvukat.EditValue;

            Methods.DosyaAtama(Dosya, Customer);

            this.Close();
        }

        private void sbtnSorumluIzleyenAyni_Click(object sender, EventArgs e)
        {
            if (lueSorumluAvukat.EditValue != null)
                lueIzleyenAvukat.EditValue = (int)lueSorumluAvukat.EditValue;
        }
    }
}