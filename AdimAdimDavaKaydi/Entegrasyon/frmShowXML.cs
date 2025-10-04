using AdimAdimDavaKaydi.Entegrasyon.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdimAdimDavaKaydi.Entegrasyon
{
    public partial class frmShowXML : Form
    {
        public frmShowXML()
        {
            InitializeComponent();
        }

        public static XDocument docs = new XDocument();

        //Aktarılan data üzerinde işlem yapıldıysa mevcut kaydın gridden silinmesini sağlıyor.
        public void SettingGridControl(DosyaBilgileri currentCustomer)
        {
            if (Methods.AktarimGerceklesti)
            {
                (gcXML.DataSource as List<DosyaBilgileri>).Remove(currentCustomer);
                gcXML.RefreshDataSource();
                Methods.AktarimGerceklesti = false;
            }
        }

        private void frmShowXML_Load(object sender, EventArgs e)
        {
            List<DosyaBilgileri> dosyaList = new List<DosyaBilgileri>();

            docs = XDocument.Load(Application.StartupPath + "\\Dosya.xml");

            foreach (var doc in docs.Descendants("Dosya").Where(vi => vi.Element("Birimi").Value.Contains("TİCARİ")).ToList())
            {
                dosyaList.Add(BindXML.SetDosyaBilgileri(doc));
            }

            gcXML.DataSource = dosyaList;
        }

        private void mevcutKlasöreTakipYapmakÜzereGönderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentCustomer = gvXML.GetFocusedRow() as DosyaBilgileri;
            CustomerData info = UseXML.ControlToCustomer(currentCustomer);
            info.YapilacakIslem = (byte)Enums.Islemler.MevcutKlasoruKullan;
            UseXML.UseCustomerData(info, currentCustomer);

            SettingGridControl(currentCustomer);
        }

        private void yeniBağımsızTakipAtaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentCustomer = gvXML.GetFocusedRow() as DosyaBilgileri;
            CustomerData info = UseXML.ControlToCustomer(currentCustomer);
            info.YapilacakIslem = (byte)Enums.Islemler.YeniBagimsizTakipAta;
            UseXML.UseCustomerData(info, currentCustomer);

            SettingGridControl(currentCustomer);
        }

        private void yeniKlasörAtaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentCustomer = gvXML.GetFocusedRow() as DosyaBilgileri;
            CustomerData info = UseXML.ControlToCustomer(currentCustomer);
            info.YapilacakIslem = (byte)Enums.Islemler.YeniKlasorAta;
            UseXML.UseCustomerData(info, currentCustomer);

            SettingGridControl(currentCustomer);
        }
    }
}