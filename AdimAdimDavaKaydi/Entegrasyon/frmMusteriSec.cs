using AvukatProLib2.Entities;
using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Entegrasyon
{
    public partial class frmMusteriSec : Form
    {
        public frmMusteriSec(TList<AV001_TDI_BIL_CARI> cariList, CustomerData customer, Classes.DosyaBilgileri dosya)
        {
            this.CariList = cariList;
            this.Customer = customer;
            this.Dosya = dosya;

            InitializeComponent();
        }

        //Bu property yeni oluşturulan per_Cari_Kimlik_Adres_Bilgileri türüne çevrilecek.
        public TList<AV001_TDI_BIL_CARI> CariList { get; set; }

        public CustomerData Customer { get; set; }

        public Classes.DosyaBilgileri Dosya { get; set; }

        private void btnSec_Click(object sender, EventArgs e)
        {
            var selectedCari = gvCariList.GetFocusedRow() as AV001_TDI_BIL_CARI;
            Customer.CustomerID = selectedCari.ID;
            UseXML.ControlToCustomer(Customer, Dosya);
        }
    }
}