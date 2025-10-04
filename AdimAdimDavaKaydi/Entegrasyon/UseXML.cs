using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Entegrasyon
{
    public static class UseXML
    {
        public static bool BireyselMi { get; set; }

        //Birden fazla aynı isimli cari çıktığında cari listesi bilgisini ilgili forma yollamak için kullanılıyor.
        public static TList<AV001_TDI_BIL_CARI> CariList { get; set; }

        public static CustomerData CustomerInformation { get; set; }

        public static CustomerData ControlToCustomer(Classes.DosyaBilgileri dosya)
        {
            //Cari Listesinin gridden başka müşteri seçildiğinde yenilenmesi için eklendi.
            CariList = null;

            //Bilginin gridden başka bir müşteri seçildiğinde yenilenmesi için eklendi.
            BireyselMi = false;
            if (dosya.Birimi.Contains("TİCARİ")) BireyselMi = false;
            else BireyselMi = true;

            //Müşteri bilgilerinin gridden başka müşteri seçildiğinde yenilenmesi için eklendi.
            CustomerInformation = new CustomerData();

            //XML'de müşteri bilgisi doldurulmamış.
            if (string.IsNullOrEmpty(dosya.Musteri) || string.IsNullOrEmpty(dosya.MusteriNo))
            {
                CustomerInformation.Durum = (byte)Enums.Durumlar.MusteriBilgisiYok;
                return CustomerInformation;
            }

            var customer = DataRepository.AV001_TDI_BIL_CARIProvider.Find(string.Format("MUSTERI_NO = {0}", dosya.MusteriNo)).FirstOrDefault();

            //Sistemde müşteri bilgisi kayıtlı değil.
            if (customer == null)
            {
                int customerCariID = Methods.DetermineCustomerCariID(dosya.Musteri, dosya.MusteriNo);
                if (customerCariID != 0)
                    CustomerInformation.CustomerID = customerCariID;
                else
                {
                    CustomerInformation.Durum = (byte)Enums.Durumlar.MusteriSistemdeYok;
                    return CustomerInformation;
                }
            }
            else//Mevcut müşteriden sistemde var.
            {
                //Bireyselde klasör seçme ekranının çıkmaması gerektiğinden bu kontrol eklendi.
                if (BireyselMi)
                {
                    CustomerInformation.Durum = (byte)Enums.Durumlar.BagliDegil;
                    CustomerInformation.CustomerID = customer.ID;
                    return CustomerInformation;
                }

                var klasorTarafList = DataRepository.AV001_TDIE_BIL_PROJE_KREDI_BORCLUSUProvider.GetByKREDI_BORCLUSU_CARI_ID(customer.ID);

                //DataRepository.AV001_TDIE_BIL_PROJE_TARAFProvider.GetByCARI_ID(customer.ID).GroupBy(vi => vi.PROJE_ID);

                CustomerInformation.CustomerID = customer.ID;

                //Müşterinin sistemde klasörü yok.
                if (klasorTarafList.Count() == 0) CustomerInformation.Durum = (byte)Enums.Durumlar.BagliDegil;
                //Müşterinin sistemde klasörü var. Kullanıcıya klasör(ler) bilgisi gösterilir ve varolanı mı kullanmak istediği ya da yeni bir klasör ya da takip mi oluşturmak istediği sorulur.
                else
                {
                    CustomerInformation.Durum = (byte)Enums.Durumlar.KlasoreBagli;

                    //Klasör bilgileri kullanıcıya gösterilir ve hangi klasörü seçip devam etmek istediği ya da yeni bir klasör mü eklemek istediği seçeneği sorulur.
                    using (frmKlasorSec frmKlasor = new frmKlasorSec(CustomerInformation, dosya))
                    {
                        frmKlasor.EnvanterList = BelgeUtil.Inits.context.TUM_DOSYALAR_OZETs.Where(vi => vi.CARI_ID == CustomerInformation.CustomerID).ToList();
                        frmKlasor.ShowDialog();
                    }
                }
            }
            return CustomerInformation;
        }

        public static void ControlToCustomer(CustomerData customer, Classes.DosyaBilgileri dosya)
        {
            CustomerInformation = customer;

            var klasorTarafList = DataRepository.AV001_TDIE_BIL_PROJE_KREDI_BORCLUSUProvider.GetByKREDI_BORCLUSU_CARI_ID(CustomerInformation.CustomerID).GroupBy(vi => vi.PROJE_ID);
            //DataRepository.AV001_TDIE_BIL_PROJE_TARAFProvider.GetByCARI_ID(CustomerInformation.CustomerID).GroupBy(vi => vi.PROJE_ID);

            //Müşterinin sistemde klasörü yok.
            if (klasorTarafList.Count() == 0)
            {
                CustomerInformation.Durum = (byte)Enums.Durumlar.BagliDegil;
                //Avukat Atama İşlemi
                frmAvukatAta frmAtama = new frmAvukatAta(CustomerInformation, dosya);
                frmAtama.Show();
            }
            //Müşterinin sistemde klasörü var. Kullanıcıya klasör(ler) bilgisi gösterilir ve varolanı mı kullanmak istediği ya da yeni bir klasör ya da takip mi oluşturmak istediği sorulur.
            else
            {
                CustomerInformation.Durum = (byte)Enums.Durumlar.KlasoreBagli;

                //Klasör bilgileri kullanıcıya gösterilir ve hangi klasörü seçip devam etmek istediği ya da yenib ir klasör mü eklemek istediği seçeneği sorulur.
                frmKlasorSec frmKlasor = new frmKlasorSec(CustomerInformation, dosya);
                frmKlasor.EnvanterList = BelgeUtil.Inits.context.TUM_DOSYALAR_OZETs.Where(vi => vi.CARI_ID == CustomerInformation.CustomerID).ToList();
                frmKlasor.Show();
            }
        }

        public static void UseCustomerData(CustomerData info, Classes.DosyaBilgileri dosya)
        {
            CustomerInformation = info;

            switch (CustomerInformation.Durum)
            {
                case (byte)Enums.Durumlar.BagliDegil:
                case (byte)Enums.Durumlar.MusteriSistemdeYok:
                    info.SorumluAvukatID = Methods.DetermineCustomerCariID(dosya.SorumluAvukat, null);
                    info.IzleyenAvukatID = Methods.DetermineCustomerCariID(dosya.IzleyenAvukat, null);
                    if (BireyselMi)
                    {
                        //Bireysel için avukata atama ekranı gösterilmeyecek. Akarımdan gelen avukat bilgisi otomatik olarak verilcek.
                        Methods.DosyaAtama(dosya, CustomerInformation);
                    }
                    else
                    {
                        //Ticari bölümde avukata atama ekranı aktarımdan gelen avukat bilgisi ile açılacak ve atama yapan kişiye avukat bilgisini değiştirebilme imkanı verilecek.

                        //Avukat Atama İşlemi
                        using (frmAvukatAta frmAtama = new frmAvukatAta(CustomerInformation, dosya))
                        {
                            frmAtama.ShowDialog();
                        }
                    }
                    break;
                //case (byte)Enums.Durumlar.KlasoreBagli:
                //    //Klasör bilgileri kullanıcıya gösterilir ve hangi klasörü seçip devam etmek istediği ya da yeni bir klasör mü eklemek istediği seçeneği sorulur.
                //    //frmKlasorSec frmKlasor = new frmKlasorSec(CustomerInformation, dosya);
                //    //frmKlasor.EnvanterList = BelgeUtil.Inits.context.TUM_DOSYALAR_OZETs.Where(vi => vi.CARI_ID == CustomerInformation.CustomerID).ToList();
                //    //frmKlasor.Show();
                //    break; //ControlToCustomer metodunda ilgili form açıldığından bu case'e gerek kalmadı.
                case (byte)Enums.Durumlar.MusteriBilgisiYok:
                    MessageBox.Show("Aktarım sırasında 'MÜŞTERİ' bilgisi gelmediğinden işlem yapılamıyor.", "İPTAL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;

                case (byte)Enums.Durumlar.AyniMusteridenVar:
                    MessageBox.Show("Sistemde aktarılan müşteriden birden fazla sayıda\r\n olduğundan doğru müşteriyi seçmelisiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMusteriSec frmMusteri = new frmMusteriSec(CariList, CustomerInformation, dosya);
                    frmMusteri.Show();
                    break;

                default:
                    break;
            }
        }
    }
}