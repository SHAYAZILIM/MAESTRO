using AdimAdimDavaKaydi.Entegrasyon.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdimAdimDavaKaydi.Entegrasyon
{
    public partial class frmShowXMLKrediKartlari : Form
    {
        public frmShowXMLKrediKartlari()
        {
            InitializeComponent();
        }

        public static XDocument docs = new XDocument();

        //Kayıt esnasında hata olursa, bütün hatalar txt dosyasına kaydediliyor. Bu txt dosyasının yerini kullanıcının seçmesini sağlayabilmek SaveFileDialog için eklendi.
        public static SaveFileDialog SaveFile = new SaveFileDialog();

        //Aktarılan data üzerinde işlem yapıldıysa XML dosyasında kalan bilgilerin grid control içerisine tekrar yüklenmesi sağlanıyor.
        public void SettingGridControl()
        {
            if (Methods.AktarimGerceklesti)
            {
                BindXMLDocToGridControl();
                gcXML.RefreshDataSource();
                Methods.AktarimGerceklesti = false;
            }
        }

        //XML document içerisindeki bilgilerin, grid control içerisine yerleştirilmesi sağlanıyor.
        private void BindXMLDocToGridControl()
        {
            List<DosyaBilgileri> dosyaList = new List<DosyaBilgileri>();

            docs = XDocument.Load(Application.StartupPath + "\\Dosyalar.xml");

            foreach (var doc in docs.Descendants("Dosya").Where(vi => vi.Element("Birimi").Value.Contains("BİREYSEL")).ToList())
            {
                dosyaList.Add(BindXML.SetDosyaBilgileri(doc));
            }

            gcXML.DataSource = dosyaList;
        }

        private void frmShowXMLKrediKartlari_Load(object sender, EventArgs e)
        {
            BindXMLDocToGridControl();
        }

        private void tümünüGönderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = gcXML.DataSource as List<DosyaBilgileri>;

            MessageBox.Show("Hata olma durumunda hata bilgilerinin \r\n kaydedilmesini istediğiniz dizini seçiniz", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            SaveFile.Title = "Dosya Kayıt Yeri Seçiniz";
            SaveFile.DefaultExt = "txt";
            SaveFile.FileName = "Hatalar";
            SaveFile.ShowDialog();

            foreach (var currentCustomer in list)
            {
                CustomerData info = UseXML.ControlToCustomer(currentCustomer);
                info.YapilacakIslem = (byte)Enums.Islemler.YeniBagimsizTakipAta;
                UseXML.UseCustomerData(info, currentCustomer);

                SettingGridControl();
            }
            MessageBox.Show("Atama işlemi tamamlandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}