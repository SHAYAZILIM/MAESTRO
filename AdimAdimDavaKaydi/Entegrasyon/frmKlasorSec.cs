using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Entegrasyon
{
    public partial class frmKlasorSec : Form
    {
        public frmKlasorSec(CustomerData customer, Classes.DosyaBilgileri dosya)
        {
            this.Customer = customer;
            this.Dosya = dosya;

            InitializeComponent();
        }

        private List<AvukatProLib.Arama.TUM_DOSYALAR_OZET> _EnvanterList;

        public CustomerData Customer { get; set; }

        public Classes.DosyaBilgileri Dosya { get; set; }

        public List<AvukatProLib.Arama.TUM_DOSYALAR_OZET> EnvanterList
        {
            get
            {
                return _EnvanterList;
            }
            set
            {
                _EnvanterList = value;
                gcDosyalar.DataSource = _EnvanterList;
            }
        }

        private void frmKlasorSec_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueNo);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlueGorev);
            BelgeUtil.Inits.perCariGetir(rlueTarafCari);
            BelgeUtil.Inits.SorumluAvukatGetir(rlueSorumluAvukat);
            BelgeUtil.Inits.FoyDurumGetir(rlueDosyaDurum);
            BelgeUtil.Inits.ProjeAdGetir(rlueKlasor);
            BelgeUtil.Inits.TarafSifatGetir(rlueTarafSifat);
            BelgeUtil.Inits.TarafKoduGetir(rlueTarafKodu);
        }

        private void sbtnBagimsizTakipAc_Click(object sender, EventArgs e)
        {
            //Bütün kontroller yapılıp klasör seçme ekranı açıldığından başka bir kontrole gerek duymadan avukata atama ekranını açıyoruz.
            Customer.YapilacakIslem = (byte)Enums.Islemler.YeniBagimsizTakipAta;
            if (UseXML.BireyselMi)
            {
                Customer.SorumluAvukatID = Methods.DetermineCustomerCariID(Dosya.SorumluAvukat, null);
                Customer.IzleyenAvukatID = Methods.DetermineCustomerCariID(Dosya.IzleyenAvukat, null);

                Methods.DosyaAtama(Dosya, Customer);
            }
            else
            {
                frmAvukatAta frmAvukataAtama = new frmAvukatAta(Customer, Dosya);
                frmAvukataAtama.Show();
            }
            this.Close();
        }

        private void sbtnYeniKlasor_Click(object sender, EventArgs e)
        {
            Customer.SorumluAvukatID = Methods.DetermineCustomerCariID(Dosya.SorumluAvukat, null);
            Customer.IzleyenAvukatID = Methods.DetermineCustomerCariID(Dosya.IzleyenAvukat, null);

            //Bütün kontroller yapılıp klasör seçme ekranı açıldığından başka bir kontrole gerek duymadan avukata atama ekranını açıyoruz.
            Customer.YapilacakIslem = (byte)Enums.Islemler.YeniKlasorAta;
            frmAvukatAta frmAvukataAtama = new frmAvukatAta(Customer, Dosya);
            frmAvukataAtama.Show();

            //this.Close();
        }

        private void seçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentRecord = gvDosyalar.GetFocusedRow() as AvukatProLib.Arama.TUM_DOSYALAR_OZET;
            if (currentRecord.DOSYA == "KREDİ DOSYASI")
                Customer.KlasorID = currentRecord.KLASOR.Value;
            else
            {
                MessageBox.Show("Seçilen kayıtta klasör bilgisi olmadığından \r\nişleme devam edilemiyor.", "İPTAL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            Customer.YapilacakIslem = (int)Enums.Islemler.MevcutKlasoruKullan;

            var klasorSorumluList = DataRepository.AV001_TDIE_BIL_PROJE_SORUMLUProvider.GetByPROJE_ID(Customer.KlasorID);
            Customer.SorumluAvukatID = klasorSorumluList.Find(vi => !vi.YETKILI_MI ?? false).CARI_ID;
            if (klasorSorumluList.Find(vi => vi.YETKILI_MI ?? false) != null)
                Customer.IzleyenAvukatID = klasorSorumluList.Find(vi => vi.YETKILI_MI ?? false).CARI_ID;
            else
                Customer.IzleyenAvukatID = Customer.SorumluAvukatID;

            //Mevcut klasörün avukat bilgisinin değiştilmek istenip istenmediği bilgisi alınır.
            DialogResult drSecim = MessageBox.Show("Mevcut klasörün avukat bilgisini \r\ndeğiştirmek istiyor musunuz?", "ONAY", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drSecim == DialogResult.Yes)
            {
                //Avukata atama ekranı klasörün mevcut avukat bilgileri ile açılır.
                frmAvukatAta frmAvukataAtama = new frmAvukatAta(Customer, Dosya);
                frmAvukataAtama.Show();
            }
            else
            {
                //Aktarılan datalar mevcut klasörün ilgili alanlarına ve tablolarına gönderilir.
                AV001_TDIE_BIL_PROJE klasor = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(Customer.KlasorID);
                klasor = Methods.SetKlasorCollection(klasor, Dosya, Customer, true);

                //Connecion string bilgisi verilecek.
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                try
                {
                    tran.BeginTransaction();

                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepSave(tran, klasor, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_SORUMLU>), typeof(TList<AV001_TDIE_BIL_PROJE_TARAF>), typeof(TList<AV001_TDIE_BIL_PROJE_ALACAK_NEDEN>), typeof(TList<AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK>), typeof(TList<AV001_TDIE_BIL_PROJE_SOZLESME>));

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen) tran.Rollback();
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }
    }
}