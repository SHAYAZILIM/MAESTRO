using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using ExtendedMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdimAdimDavaKaydi.Entegrasyon
{
    public static class Methods
    {
        //Aktarılan data üzerinde işlem yapılıp yapılmadığını kontrol eden property.
        public static bool AktarimGerceklesti = false;

        public static string Hata = string.Empty;

        public static int tarafCariID = 0;

        //Aktarımla gelen müşteri ismi yanlış yazıldığında sistemde yenisi bulunup kullanıldığında aktarılan ismin sistemde hangi cariye denk geldiği ya da aktarımdan gelen müşteri isminin sistemde hangi cariye denk geldiği bilgisi tutuluyor. Kontrol bir kere yapıldıktan sonra diğer aşamalarda aynı kontrolün yapılmasını engellemek için eklendi.
        public static Dictionary<string, int> CustomerNameMapList { get; set; }

        public static void BindGrid(DevExpress.XtraGrid.GridControl gc, object type, bool isSelected)
        {
            if (type is List<Classes.AlacakTaraf>)
                (gc.DataSource as List<Classes.AlacakTaraf>).ForEach(item => item.IsSelected = isSelected);
            else if (type is List<Classes.NakitAlacak>)
                (gc.DataSource as List<Classes.NakitAlacak>).ForEach(item => item.IsSelected = isSelected);
            else if (type is List<Classes.GayriNakitAlacak>)
                (gc.DataSource as List<Classes.GayriNakitAlacak>).ForEach(item => item.IsSelected = isSelected);
            else if (type is List<Classes.Cek>)
                (gc.DataSource as List<Classes.Cek>).ForEach(item => item.IsSelected = isSelected);
            else if (type is List<Classes.Bono>)
                (gc.DataSource as List<Classes.Bono>).ForEach(item => item.IsSelected = isSelected);
            else if (type is List<Classes.Sozlesmeler>)
                (gc.DataSource as List<Classes.Sozlesmeler>).ForEach(item => item.IsSelected = isSelected);
            else if (type is List<Classes.Ipotek>)
                (gc.DataSource as List<Classes.Ipotek>).ForEach(item => item.IsSelected = isSelected);
            else if (type is List<Classes.Rehin>)
                (gc.DataSource as List<Classes.Rehin>).ForEach(item => item.IsSelected = isSelected);
        }

        //Aktarımdan gelen müşteri isminin sistemedeki karşılığının bulunmasını sağlıyor. Aktarılan müşteri ismi yanlış yazılmış bir isim olabilir o nedenle kullanıcıdan doğru müşteriyi seçmesi için ekran getiriliyor ve kullanıcının doğru olan müşteriyi seçmesi sağlanıyor. Müşteri ismi doğru girilmişse de sistemden ID bilgisi getiriliyor.
        public static int DetermineCustomerCariID(string customerName, string customerNumber)
        {
            tarafCariID = 0;

            if (CustomerNameMapList != null && CustomerNameMapList.Count > 0)
            {
                var tempCust = CustomerNameMapList.Where(vi => vi.Key == customerName);
                if (tempCust.Count() > 0) tarafCariID = tempCust.FirstOrDefault().Value;
            }

            if (tarafCariID == 0)
            {
                //custumerNumber null değil ise, ilk arama koşulu müşteri numarası olmalı. Verilen customerNumber ile cari bulununca isim ile aramaya gerek yok. customerNumber null değil ve cari bulunamadı ise isme göre arama yapılmalı. customerNumber null geldiğinde ise direk isme göre arama yapılmalı.

                AV001_TDI_BIL_CARI cari = null;

                if (!string.IsNullOrEmpty(customerNumber))
                    cari = DataRepository.AV001_TDI_BIL_CARIProvider.Find(string.Format("MUSTERI_NO = {0}", customerNumber)).FirstOrDefault();
                else
                    cari = DataRepository.AV001_TDI_BIL_CARIProvider.Find(string.Format("AD = {0}", customerName)).FirstOrDefault();

                if (!string.IsNullOrEmpty(customerNumber) && cari == null)
                    DataRepository.AV001_TDI_BIL_CARIProvider.Find(string.Format("AD = {0}", customerName)).FirstOrDefault();

                if (cari != null)
                {
                    if (CustomerNameMapList != null && CustomerNameMapList.Where(vi => vi.Value == cari.ID).Count() == 0)
                        CustomerNameMapList.Add(customerName, cari.ID);
                    tarafCariID = cari.ID;
                }
                else
                {
                    //Aktarılan datada müşteri ismi yanlış yazılmış olabilir ya da o müşteri sistemde yoktur. Yanlış yazılma ihtimali düşünülerek müşteri bulmak için aşağıdaki form hazırlandı. Doğru müşteri seçiliyor ve işleme devam ediliyor.

                    MessageBox.Show(string.Format("{0} ismi ile aktarılan şahıs ismi sistemde bulunamadı.", customerName), "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    using (frmMusteriBul frmBul = new frmMusteriBul(customerName, customerNumber))
                    {
                        frmBul.FormClosed += new FormClosedEventHandler(frmBul_FormClosed);
                        frmBul.ShowDialog();
                    }
                }
            }
            return tarafCariID;
        }

        public static void DosyaAtama(Classes.DosyaBilgileri Dosya, CustomerData Customer)
        {
            Hata = string.Empty;

            #region Yeni Klasör

            if (Customer.YapilacakIslem == (byte)Enums.Islemler.YeniKlasorAta)
            {
                AV001_TDIE_BIL_PROJE yeniKlasor = new AV001_TDIE_BIL_PROJE();
                yeniKlasor = Methods.SetKlasorCollection(yeniKlasor, Dosya, Customer, false);

                #region Dosya Atama Bilgileri

                AV001_TDIE_BIL_AKTARILAN_DOSYAYI_ATAMA dosyaAtama = yeniKlasor.AV001_TDIE_BIL_AKTARILAN_DOSYAYI_ATAMACollection.AddNew();
                dosyaAtama.SORUMLU_AVUKAT_CARI_ID = Customer.SorumluAvukatID;
                dosyaAtama.IZLEYEN_AVUKAT_CARI_ID = Customer.IzleyenAvukatID;
                dosyaAtama.KABUL_DURUM_ID = (int)Enums.DosyaAtamaKabulDurumlari.IslemBekliyor;
                dosyaAtama.DOSYAYI_ATAYAN_CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
                dosyaAtama.ATAMA_TARIHI = DateTime.Now;

                #endregion Dosya Atama Bilgileri

                //Connecion string bilgisi verilecek.
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                try
                {
                    tran.BeginTransaction();

                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepSave(tran, yeniKlasor, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_SORUMLU>), typeof(TList<AV001_TDIE_BIL_PROJE_TARAF>), typeof(TList<AV001_TDIE_BIL_PROJE_ALACAK_NEDEN>), typeof(TList<AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK>), typeof(TList<AV001_TDIE_BIL_PROJE_SOZLESME>), typeof(TList<AV001_TDIE_BIL_PROJE_TEMINAT>), typeof(TList<AV001_TDIE_BIL_AKTARILAN_DOSYAYI_ATAMA>), typeof(TList<AV001_TDIE_BIL_PROJE_KREDI_BORCLUSU>));

                    tran.Commit();

                    string mailTo = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(Customer.SorumluAvukatID).EMAIL_1;
                    AdimAdimDavaKaydi.Util.DosyaAvukatIliski.SendMail(mailTo, ReturnMailBody());

                    MessageBox.Show("Aktarım Tamamlandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Methods.RemoveXMLNode(Dosya.MusteriNo);

                    #region Masraf ve Tahsilat İşlemleri

                    DosyaMasrafIliskilendir(yeniKlasor, Customer.CustomerID, Dosya.MusteriNo, tran);
                    DosyaTahsilatIliskilendir(yeniKlasor, Customer.CustomerID, Dosya.MusteriNo, tran);

                    #endregion Masraf ve Tahsilat İşlemleri
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen) tran.Rollback();
                    BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", ex);
                    MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            #endregion Yeni Klasör

            #region Yeni Bağımsız Takip Ata

            else if (Customer.YapilacakIslem == (byte)Enums.Islemler.YeniBagimsizTakipAta)
            {
                if (Dosya.KrediGrubu == "Kredi Kartları")
                {
                    AV001_TI_BIL_FOY yeniTakip = new AV001_TI_BIL_FOY();

                    yeniTakip.FORM_TIP_ID = (int)AvukatProLib.Extras.FormTipleri.Form49;
                    yeniTakip.FOY_NO = Forms.Icra.frmIcraDosyaKayit.FoyNoGetir();
                    yeniTakip.ADLI_BIRIM_GOREV_ID = (int)AvukatProLib.Extras.AdliBirimBolumGorev.ICRM;
                    yeniTakip.FOY_DURUM_ID = 2;//DERDEST

                    //Atayan avukata aşağıdaki ekranın gösterilmesi istenmediğinden kaldırıldı. (Bahattin Çelik talebi)
                    //using (frmKrediKartiTakipBilgileri frmTakipBilgileri = new frmKrediKartiTakipBilgileri())
                    //{
                    //    frmTakipBilgileri.ShowDialog();

                    //    if (frmTakipBilgileri.TakipTarihi <= DateTime.MinValue) yeniTakip.TAKIP_TARIHI = DateTime.Now.Date;
                    //    else yeniTakip.TAKIP_TARIHI = frmTakipBilgileri.TakipTarihi;

                    //    if (frmTakipBilgileri.IcraDairesi != 0) yeniTakip.ADLI_BIRIM_ADLIYE_ID = frmTakipBilgileri.IcraDairesi;
                    //    if (frmTakipBilgileri.No != 0) yeniTakip.ADLI_BIRIM_NO_ID = frmTakipBilgileri.No;
                    //    if (frmTakipBilgileri.EsasNo != "/") yeniTakip.ESAS_NO = frmTakipBilgileri.EsasNo;
                    //}

                    yeniTakip = Methods.SetTakipCollection(yeniTakip, Dosya, Customer, new List<int>());

                    #region Dosya Atama Bilgileri

                    AV001_TDIE_BIL_AKTARILAN_DOSYAYI_ATAMA dosyaAtama = yeniTakip.AV001_TDIE_BIL_AKTARILAN_DOSYAYI_ATAMACollection.AddNew();
                    dosyaAtama.SORUMLU_AVUKAT_CARI_ID = Customer.SorumluAvukatID;
                    dosyaAtama.IZLEYEN_AVUKAT_CARI_ID = Customer.IzleyenAvukatID;
                    dosyaAtama.KABUL_DURUM_ID = (int)Enums.DosyaAtamaKabulDurumlari.IslemBekliyor;
                    dosyaAtama.DOSYAYI_ATAYAN_CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
                    dosyaAtama.ATAMA_TARIHI = DateTime.Now;

                    #endregion Dosya Atama Bilgileri

                    TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                    try
                    {
                        tran.BeginTransaction();

                        DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(tran, yeniTakip, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>), typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>), typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>), typeof(TList<AV001_TDIE_BIL_AKTARILAN_DOSYAYI_ATAMA>), typeof(TList<AV001_TI_BIL_FOY_KREDI_BORCLUSU>));
                        DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(tran, yeniTakip.AV001_TI_BIL_ALACAK_NEDENCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
                        foreach (var alacakNeden in yeniTakip.AV001_TI_BIL_ALACAK_NEDENCollection)
                        {
                            DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepSave(tran, alacakNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>));
                        }

                        tran.Commit();

                        if (BelgeUtil.Inits._AlacakNEdenGetir != null)
                            BelgeUtil.Inits._AlacakNEdenGetir.AddRange(BelgeUtil.Inits.GetAlacakNedenViewItem(yeniTakip.AV001_TI_BIL_ALACAK_NEDENCollection));

                        if (BelgeUtil.Inits._FoyTarafGetir != null)
                            BelgeUtil.Inits._FoyTarafGetir.AddRange(BelgeUtil.Inits.GetIcraFoyTarafViewItem(yeniTakip.AV001_TI_BIL_FOY_TARAFCollection));

                        //Atamayı yapan kişiye aşağıdaki ekranın gelmesi istenmediğinden kapatıldı ve başka bir message box eklendi. (Bahattin Çelik talebi)
                        //DialogResult dr = MessageBox.Show(string.Format("Aktarımdan gelen dosyadan, {0} raf numarası ile \r\nBAĞIMSIZ TAKİP oluşturuldu.\r\nTakip ekranına gitmek ister misiniz ?", yeniTakip.FOY_NO), "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        //if (dr == DialogResult.Yes)
                        //{
                        //    IcraTakipForms._frmIcraTakip frm = new AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip();
                        //    frm.Show(yeniTakip.ID);
                        //}

                        string mailTo = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(Customer.SorumluAvukatID).EMAIL_1;
                        AdimAdimDavaKaydi.Util.DosyaAvukatIliski.SendMail(mailTo, ReturnMailBody());

                        //MessageBox.Show("Atama işlemi tamamlandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Methods.RemoveXMLNodeKK(Dosya.MusteriNo);

                        #region Masraf ve Tahsilat İşlemleri

                        DosyaMasrafIliskilendir(yeniTakip, Customer.CustomerID, Dosya.MusteriNo, tran);
                        DosyaTahsilatIliskilendir(yeniTakip, Customer.CustomerID, Dosya.MusteriNo, tran);

                        #endregion Masraf ve Tahsilat İşlemleri
                    }
                    catch (Exception ex)
                    {
                        if (tran.IsOpen) tran.Rollback();

                        //MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        if (ex is System.Data.SqlClient.SqlException && ex.Message.Contains("uFOY_NO"))
                        {
                            DosyaAtama(Dosya, Customer);
                        }
                        else
                            Hata = string.Format("{1}*** {0} numaralı müşteri için kayıt sırasında alınan hata :{1}{2}{1}{3}{1}{4}", Dosya.MusteriNo, Environment.NewLine, ex.Message, ex.StackTrace, "_____________________________________________________");
                    }

                    //Takiplerin kaydı sırasında alınan hataların kullanıcının belirlediği bir dizindeki txt dosyasına yazılması işlemi yapılıyor.
                    if (!string.IsNullOrEmpty(Hata))
                    {
                        System.IO.StreamWriter sw = new System.IO.StreamWriter(frmShowXMLKrediKartlari.SaveFile.FileName, true);
                        sw.WriteLine(Hata);
                        sw.Close();
                    }
                }
                else
                {
                    frmTakipAc frmTakip = new frmTakipAc();
                    frmTakip.Show(Dosya, Customer);
                }
            }

            #endregion Yeni Bağımsız Takip Ata

            #region Mevcut Klasörü Kullan

            else if (Customer.YapilacakIslem == (byte)Enums.Islemler.MevcutKlasoruKullan)
            {
                //Mevcut klasöre dosyadaki veriler aktarılacak.

                AV001_TDIE_BIL_PROJE klasor = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(Customer.KlasorID);
                klasor = Methods.SetKlasorCollection(klasor, Dosya, Customer, true);

                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                try
                {
                    tran.BeginTransaction();

                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepSave(tran, klasor, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_SORUMLU>), typeof(TList<AV001_TDIE_BIL_PROJE_TARAF>), typeof(TList<AV001_TDIE_BIL_PROJE_ALACAK_NEDEN>), typeof(TList<AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK>), typeof(TList<AV001_TDIE_BIL_PROJE_SOZLESME>));

                    tran.Commit();

                    MessageBox.Show("Aktarım Tamamlandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen) tran.Rollback();
                    BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", ex);
                    MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            #endregion Mevcut Klasörü Kullan
        }

        public static void DosyaMasrafIliskilendir(AV001_TDIE_BIL_PROJE klasor, int musteriID, string musteriNo, TransactionManager tran)
        {
            XDocument docsMasraf = XDocument.Load(Application.StartupPath + "\\Masraflar.xml");
            var masrafListDocs = docsMasraf.Descendants("MASRAF").Where(vi => vi.Element("MusteriNo").Value == musteriNo && vi.Element("Niteligi").Value == "T");

            TList<AV001_TDI_BIL_MASRAF_AVANS> masrafList = new TList<AV001_TDI_BIL_MASRAF_AVANS>();
            foreach (var item in masrafListDocs)
            {
                AV001_TDI_BIL_MASRAF_AVANS masrafItem = new AV001_TDI_BIL_MASRAF_AVANS();
                masrafItem = SetDosyaMasrafValues(masrafItem, item, musteriID);
                masrafItem.PROJE_ID = klasor.ID;

                var projeMasraf = masrafItem.AV001_TDIE_BIL_PROJE_MASRAF_AVANSCollection.AddNew();
                projeMasraf.PROJE_ID = klasor.ID;

                masrafList.Add(masrafItem);
            }

            try
            {
                tran.BeginTransaction();
                DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepSave(tran, masrafList, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>), typeof(TList<AV001_TDIE_BIL_PROJE_MASRAF_AVANS>));
                tran.Commit();

                //Dosyaya Atanan Masrafların XML dosyadan silinmesi
                masrafListDocs.Remove();
                docsMasraf.Save(Application.StartupPath + "\\Masraflar.xml");
            }
            catch (Exception ex)
            {
                if (tran.IsOpen) tran.Rollback();
                BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", ex);
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public static void DosyaMasrafIliskilendir(AV001_TI_BIL_FOY takip, int musteriID, string musteriNo, TransactionManager tran)
        {
            XDocument docsMasraf = XDocument.Load(Application.StartupPath + "\\Masraflar.xml");
            var masrafListDocs = docsMasraf.Descendants("MASRAF").Where(vi => vi.Element("MusteriNo").Value == musteriNo && vi.Element("Niteligi").Value == "K");

            TList<AV001_TDI_BIL_MASRAF_AVANS> masrafList = new TList<AV001_TDI_BIL_MASRAF_AVANS>();
            foreach (var item in masrafListDocs)
            {
                AV001_TDI_BIL_MASRAF_AVANS masrafItem = new AV001_TDI_BIL_MASRAF_AVANS();
                masrafItem = SetDosyaMasrafValues(masrafItem, item, musteriID);
                masrafItem.ICRA_FOY_ID = takip.ID;

                masrafList.Add(masrafItem);
            }

            try
            {
                tran.BeginTransaction();
                DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepSave(tran, masrafList, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));
                tran.Commit();

                //Dosyaya Atanan Masrafların XML dosyadan silinmesi
                masrafListDocs.Remove();
                docsMasraf.Save(Application.StartupPath + "\\Masraflar.xml");
            }
            catch (Exception ex)
            {
                if (tran.IsOpen) tran.Rollback();
                BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", ex);
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public static void DosyaTahsilatIliskilendir(AV001_TDIE_BIL_PROJE klasor, int musteriID, string musteriNo, TransactionManager tran)
        {
            XDocument docsTahsilat = XDocument.Load(Application.StartupPath + "\\Tahsilatlar.xml");
            var tahsilatListDocs = docsTahsilat.Descendants("TAHSILAT").Where(vi => vi.Element("MusteriNo").Value == musteriNo && vi.Element("Niteligi").Value == "T");

            TList<AV001_TI_BIL_BORCLU_ODEME> odemeList = new TList<AV001_TI_BIL_BORCLU_ODEME>();
            foreach (var item in tahsilatListDocs)
            {
                AV001_TI_BIL_BORCLU_ODEME odemeItem = new AV001_TI_BIL_BORCLU_ODEME();
                odemeItem = SetDosyaOdemeValues(odemeItem, item, musteriID);

                var projeOdeme = odemeItem.AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEMECollection.AddNew();
                projeOdeme.PROJE_ID = klasor.ID;

                odemeList.Add(odemeItem);
            }
            try
            {
                tran.BeginTransaction();
                DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepSave(tran, odemeList, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEME>));
                tran.Commit();

                //Dosyaya Atanan Tahsilatların XML dosyadan silinmesi
                tahsilatListDocs.Remove();
                docsTahsilat.Save(Application.StartupPath + "\\Tahsilatlar.xml");
            }
            catch (Exception ex)
            {
                if (tran.IsOpen) tran.Rollback();
                BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", ex);
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public static void DosyaTahsilatIliskilendir(AV001_TI_BIL_FOY takip, int musteriID, string musteriNo, TransactionManager tran)
        {
            XDocument docsTahsilat = XDocument.Load(Application.StartupPath + "\\Tahsilatlar.xml");
            var tahsilatListDocs = docsTahsilat.Descendants("TAHSILAT").Where(vi => vi.Element("MusteriNo").Value == musteriNo && vi.Element("Niteligi").Value == "K");

            TList<AV001_TI_BIL_BORCLU_ODEME> odemeList = new TList<AV001_TI_BIL_BORCLU_ODEME>();
            foreach (var item in tahsilatListDocs)
            {
                AV001_TI_BIL_BORCLU_ODEME odemeItem = new AV001_TI_BIL_BORCLU_ODEME();
                odemeItem = SetDosyaOdemeValues(odemeItem, item, musteriID);
                odemeItem.ICRA_FOY_ID = takip.ID;

                odemeList.Add(odemeItem);
            }
            try
            {
                tran.BeginTransaction();
                DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.Save(tran, odemeList);
                tran.Commit();

                //Dosyaya Atanan Tahsilatların XML dosyadan silinmesi
                tahsilatListDocs.Remove();
                docsTahsilat.Save(Application.StartupPath + "\\Tahsilatlar.xml");
            }
            catch (Exception ex)
            {
                if (tran.IsOpen) tran.Rollback();
                BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", ex);
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public static string GetKlasorKodu()
        {
            int? klasorNo =
               DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, "Select TOP(1) CONVERT(int,SUBSTRING(REPLACE(KOD,' ',''),6,4))+1 from AV001_TDIE_BIL_PROJE WHERE KOD LIKE '" + DateTime.Today.Year + "%' ORDER BY KOD DESC") as int?;
            if (!klasorNo.HasValue)
                klasorNo = 1;
            return String.Format("{0}/{1:0000}", DateTime.Today.Year, klasorNo.Value);
        }

        public static AV001_TDI_BIL_SOZLESME NewAlacaginTemlikiForKlasor(AV001_TDI_BIL_SOZLESME temlik, Classes.AlacaginTemliki aktarilanTemlik, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            temlik = SetAlacaginTemlikiValues(temlik, aktarilanTemlik);

            //var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
            //projeTeminat.SOZLESME_IDSource = temlik;

            return temlik;
        }

        public static AV001_TI_BIL_ALACAK_NEDEN NewAlacakNedenForKlasor(AV001_TI_BIL_ALACAK_NEDEN alacak, Classes.GayriNakitAlacak aktarilanGayrinakitAlacak, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            alacak = SetGayrinakitAlacakValues(alacak, aktarilanGayrinakitAlacak);

            return alacak;
        }

        public static AV001_TDI_BIL_SOZLESME NewAltinRehniForKlasor(AV001_TDI_BIL_SOZLESME altinRehni, Classes.AltinRehni aktarilanAltinRehni, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            altinRehni = SetAltinRehniValues(altinRehni, aktarilanAltinRehni);

            //var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
            //projeTeminat.SOZLESME_IDSource = altinRehni;

            return altinRehni;
        }

        public static AV001_TDI_BIL_SOZLESME NewAracForKlasor(AV001_TDI_BIL_SOZLESME arac, Classes.AracRehin aktarilanArac, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            arac = SetGUAValues(arac, aktarilanArac, null);

            //var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
            //projeTeminat.SOZLESME_IDSource = arac;

            return arac;
        }

        public static AV001_TDI_BIL_KIYMETLI_EVRAK NewBonoForKlasor(AV001_TDI_BIL_KIYMETLI_EVRAK bono, Classes.Bono aktarilanBono, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            bono = SetBonoVales(bono, aktarilanBono);

            var projeKiymetliEvrak = yeniKlasor.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAKCollection.AddNew();
            projeKiymetliEvrak.KIYMETLI_EVRAK_IDSource = bono;

            return bono;
        }

        public static AV001_TDI_BIL_KIYMETLI_EVRAK NewCekForKlasor(AV001_TDI_BIL_KIYMETLI_EVRAK cek, Classes.Cek aktarilanCek, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            cek = SetCekValues(cek, aktarilanCek);

            var projeKiymetliEvrak = yeniKlasor.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAKCollection.AddNew();
            projeKiymetliEvrak.KIYMETLI_EVRAK_IDSource = cek;

            return cek;
        }

        public static AV001_TDI_BIL_SOZLESME NewDigerRehinForKlasor(AV001_TDI_BIL_SOZLESME digerRehni, Classes.DigerRehin aktarilanDigerRehni, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            digerRehni = SetDigerRehniValues(digerRehni, aktarilanDigerRehni);

            //var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
            //projeTeminat.SOZLESME_IDSource = digerRehni;

            return digerRehni;
        }

        public static AV001_TDI_BIL_SOZLESME NewEmtiaRehniForKlasor(AV001_TDI_BIL_SOZLESME emtiaRehni, Classes.EmtiaRehni aktarilanEmtiaRehni, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            emtiaRehni = SetEmtiaRehniValues(emtiaRehni, aktarilanEmtiaRehni);

            //var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
            //projeTeminat.SOZLESME_IDSource = emtiaRehni;

            return emtiaRehni;
        }

        public static AV001_TDI_BIL_SOZLESME NewFirmaGarantiForKlasor(AV001_TDI_BIL_SOZLESME firmaGaranti, Classes.FirmaGaranti aktarilanFirmaGaranti, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            firmaGaranti = SetFirmaGarantileriValues(firmaGaranti, aktarilanFirmaGaranti);

            //var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
            //projeTeminat.SOZLESME_IDSource = firmaGaranti;

            return firmaGaranti;
        }

        public static AV001_TDI_BIL_SOZLESME NewGemiForKlasor(AV001_TDI_BIL_SOZLESME gemi, Classes.GemiRehin aktarilanGemi, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            gemi = SetGUAValues(gemi, aktarilanGemi, null);

            //var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
            //projeTeminat.SOZLESME_IDSource = gemi;

            return gemi;
        }

        public static AV001_TDI_BIL_SOZLESME NewHatRehniForKlasor(AV001_TDI_BIL_SOZLESME hatRehni, Classes.HatRehni aktarilanHatRehni, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            hatRehni = SetHatRehniValues(hatRehni, aktarilanHatRehni);

            //var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
            //projeTeminat.SOZLESME_IDSource = hatRehni;

            return hatRehni;
        }

        public static AV001_TDI_BIL_SOZLESME NewHisseSenedi(AV001_TDI_BIL_SOZLESME hisseSenedi, Classes.HisseSenediTeminati aktarilanHisseSenedi, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            hisseSenedi = SetHisseSenediValues(hisseSenedi, aktarilanHisseSenedi);

            //var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
            //projeTeminat.SOZLESME_IDSource = hisseSenedi;

            return hisseSenedi;
        }

        public static AV001_TDI_BIL_SOZLESME NewIpotekForKlasor(AV001_TDI_BIL_SOZLESME ipotek, Classes.Ipotek aktarilanIpotek, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            ipotek = SetIpotekValues(ipotek, aktarilanIpotek, null);

            //var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
            //projeTeminat.SOZLESME_IDSource = ipotek;

            return ipotek;
        }

        public static AV001_TDI_BIL_SOZLESME NewMakbuzSenediRehniForKlasor(AV001_TDI_BIL_SOZLESME makbuzSenediRehni, Classes.MakbuzSenediRehni aktarilanMakbuzSenediRehni, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            makbuzSenediRehni = SetMakbuzSenediRehniValues(makbuzSenediRehni, aktarilanMakbuzSenediRehni);

            //var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
            //projeTeminat.SOZLESME_IDSource = makbuzSenediRehni;

            return makbuzSenediRehni;
        }

        public static AV001_TDI_BIL_SOZLESME NewMenkulRehinForKlasor(AV001_TDI_BIL_SOZLESME menkulRehin, Classes.MenkulRehni aktarilanMenkulRehni, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            menkulRehin = SetMenkulRehniValues(menkulRehin, aktarilanMenkulRehni);

            //var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
            //projeTeminat.SOZLESME_IDSource = menkulRehin;

            return menkulRehin;
        }

        public static AV001_TDI_BIL_SOZLESME NewTIRForKlasor(AV001_TDI_BIL_SOZLESME TIR, Classes.TicariIsletmeRehni aktarilanTIR, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            TIR = SetTIRValues(TIR, aktarilanTIR);

            //var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
            //projeTeminat.SOZLESME_IDSource = TIR;

            return TIR;
        }

        public static AV001_TDI_BIL_SOZLESME NewUcakForKlasor(AV001_TDI_BIL_SOZLESME ucak, Classes.UcakRehin aktarilanUcak, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            ucak = SetGUAValues(ucak, aktarilanUcak, null);

            //var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
            //projeTeminat.SOZLESME_IDSource = ucak;

            return ucak;
        }

        public static AV001_TDI_BIL_SOZLESME NewVaranRehniForKlasor(AV001_TDI_BIL_SOZLESME varantRehni, Classes.VarantRehni aktarilanVarantRehni, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            varantRehni = SetVarantRehniValues(varantRehni, aktarilanVarantRehni);

            //var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
            //projeTeminat.SOZLESME_IDSource = varantRehni;

            return varantRehni;
        }

        public static AV001_TDI_BIL_SOZLESME NewVesaikiForKlasor(AV001_TDI_BIL_SOZLESME vesaiki, Classes.IhracatIthalatVesaiki aktarilanVesaiki, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            vesaiki = SetVesaikiValues(vesaiki, aktarilanVesaiki);

            //var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
            //projeTeminat.SOZLESME_IDSource = vesaiki;

            return vesaiki;
        }

        //İşlem yapılan müşterinin XML dosyasından silinmesi işlemi sağlanıyor.
        public static void RemoveXMLNode(string musteriNo)
        {
            frmShowXML.docs.Descendants("Dosya").Where(vi => vi.Element("MusteriNo").Value == musteriNo).FirstOrDefault().Remove();
            frmShowXML.docs.Save(Application.StartupPath + "\\Dosyalar.xml");
            Methods.AktarimGerceklesti = true;
        }

        public static void RemoveXMLNodeKK(string musteriNo)
        {
            frmShowXMLKrediKartlari.docs.Descendants("Dosya").Where(vi => vi.Element("MusteriNo").Value == musteriNo).FirstOrDefault().Remove();
            frmShowXMLKrediKartlari.docs.Save(Application.StartupPath + "\\Dosyalar.xml");
            Methods.AktarimGerceklesti = true;
        }

        public static string ReturnMailBody()
        {
            string body = string.Empty;

            body = string.Format("Sayın {0}Sözleşmeli Hukuk Ofisimiz / Sözleşmeli Avukatımız,{0}{0}Tarafınıza daha önce atanmış ve tarafınızdan takibi başlatılmış dosyanın TAKİP SONRASI İŞLEMLERİNİN de izlenmesi için, Bankamızca kullanılmaya başlanan Maestro AvukatPro programına tanıtılması gerektiğinden,{0}{1}(I)  Dosyanın kabul edilmesi,{0}{1}(II) Dosya kabul edildikten sonra açılan ekranına,{0}{1}{1}a) Daha önce açmış olduğunuz takibin TAKİP TARİHİNİN yazılması ( tarihi doğrudan yazabileceğiniz gibi, maunsle klikleyerek ekrana çıkacak takvimden de seçebilirsiniz ),{0}{1}{1}b) İCRA DAİRESİNİN seçilmesi  ( İcra müdürlüğünün doğrudan adını yazıp, yandaki numaradan da kaçıncı icra dairesi olduğu seçilecek),{0}{1}{1}c) ESAS NO yazılacak ( Esas no yazılırken önce yılı 4 karekter olarak ve sonra dosya numarası yazılacak. 2001/25140 gibi ){0}{1}{1}d) TAKİP HAZIRLA komutuna basılacak.{0}Takibinizin hazırlanmış olduğunu göreceksiniz.   Bu önceki bir dosyanın sisteme girişine ilişkin olduğundan herhangi bir takip çıktısı alınmayacak.{0}Bundan sonra tahsilatlar ve masraflar bu dosyaya kendiliğinden yansıyacak.{0}{1}(III) Bundan sonra Maestro AvukatPro’dan alınmamış ve sistem tarafından referans numarası üretilmemiş masraf makbuzları kabul edilmeyeceğinden, BU TARİHTEN SONRA yapılacak tüm masrafların İLGİLİ TAKİP veya İLGİLİ DAVA dosyasından alınması gerekli ve zorunludur.{0}{0}Saygılarımızla,{0}ING Bank Hukuk Müşavirliği ", Environment.NewLine, "    ");

            return body;
        }

        public static AV001_TDI_BIL_SOZLESME SetAlacaginTemlikiValues(AV001_TDI_BIL_SOZLESME sozlesme, Classes.AlacaginTemliki aktarilanTemlik)
        {
            sozlesme.DURUM = ParametreClass.MappingTeminatDurum(aktarilanTemlik.Durum);
            sozlesme.REFERANS_NO = aktarilanTemlik.ReferansNo;
            sozlesme.TIP_ID = 3;//Resmi Senet
            sozlesme.ALT_TIP_ID = 182;//Alacağın Temliki
            sozlesme.BEDELI = aktarilanTemlik.Tutar;
            sozlesme.BEDELI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanTemlik.TutarParaBirimi);
            sozlesme.AKT_1 = aktarilanTemlik.BorcunDayanagi;
            sozlesme.AKT_2 = aktarilanTemlik.AlacakTur;
            sozlesme.AKT_7 = aktarilanTemlik.FaturaAdet;
            sozlesme.AKT_3 = aktarilanTemlik.Aciklama;
            sozlesme.AKT_4 = aktarilanTemlik.TemlikBorclusu;
            sozlesme.AKT_5 = aktarilanTemlik.BaskaTemlikVarmi;

            #region Taraflar

            aktarilanTemlik.Taraflar.ForEach(taraf => SetRehinTeminatTarafValues(sozlesme, taraf));

            #endregion Taraflar

            return sozlesme;
        }

        public static AV001_TI_BIL_ALACAK_NEDEN_TARAF SetAlacakTarafValues(AV001_TI_BIL_ALACAK_NEDEN alacak, Classes.AlacakTaraf aktarilanTaraf, bool nakitAlacakmi)
        {
            var alacakTaraf = alacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.AddNew();
            if (aktarilanTaraf.IhtarTarihi > DateTime.MinValue)
            {
                alacakTaraf.IHTAR_TARIHI = aktarilanTaraf.IhtarTarihi;

                if (alacak.DUZENLENME_TARIHI == null)
                {
                    if (!nakitAlacakmi)
                        alacak.DUZENLENME_TARIHI = alacak.FAIZ_BASLANGIC_TARIHI = alacakTaraf.IHTAR_TARIHI;
                    else
                        alacak.VADE_TARIHI = alacak.DUZENLENME_TARIHI = alacak.FAIZ_BASLANGIC_TARIHI = alacakTaraf.IHTAR_TARIHI;
                }
            }
            if (aktarilanTaraf.IhtarTebligTarihi > DateTime.MinValue) alacakTaraf.IHTAR_TEBLIG_TARIHI = aktarilanTaraf.IhtarTebligTarihi;
            alacakTaraf.SORUMLU_OLUNAN_MIKTAR = aktarilanTaraf.SorumluOlunanMiktar;
            alacakTaraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = alacak.ISLEME_KONAN_TUTAR_DOVIZ_ID;//ParametreClass.MappingDovizTip(aktarilanTaraf.SorumluOlunanMiktarParaBirimi); X işareti ile gelen tutarlarda düzeltilmiş değerin gelmesini sağlamak için bu hale getirildi.
            alacakTaraf.TARAF_SIFAT_ID = 2;//Borçlu
            if (!string.IsNullOrEmpty(aktarilanTaraf.Musteri))
                alacakTaraf.TARAF_CARI_ID = DetermineCustomerCariID(aktarilanTaraf.Musteri, aktarilanTaraf.MusteriNo);

            var tarafFaiz = alacakTaraf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.AddNew();
            tarafFaiz.FAIZ_BASLANGIC_TARIHI = alacak.FAIZ_BASLANGIC_TARIHI;
            tarafFaiz.FAIZ_ORANI = alacak.UYGULANACAK_FAIZ_ORANI;
            tarafFaiz.FAIZ_TIP_ID = alacak.ALACAK_FAIZ_TIP_ID;
            tarafFaiz.TARAF_CARI_ID = alacakTaraf.TARAF_CARI_ID;

            return alacakTaraf;
        }

        public static AV001_TDI_BIL_SOZLESME SetAltinRehniValues(AV001_TDI_BIL_SOZLESME sozlesme, Classes.AltinRehni aktarilanAltinRehni)
        {
            sozlesme.DURUM = ParametreClass.MappingTeminatDurum(aktarilanAltinRehni.Durum);
            sozlesme.REFERANS_NO = aktarilanAltinRehni.ReferanNo;
            sozlesme.TIP_ID = 3;//Resmi Senet
            sozlesme.ALT_TIP_ID = 186;//Altın Rehni
            sozlesme.BEDELI = aktarilanAltinRehni.Tutari;
            sozlesme.BEDELI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanAltinRehni.TutariParaBirimi);

            //sozlesme.REHIN_CINS_ID = aktarilanAltinRehni.RehinTuru; MAP
            sozlesme.IMZA_TARIHI = aktarilanAltinRehni.RehinTarihi;
            sozlesme.AKT_1 = aktarilanAltinRehni.BrutGramaj;
            sozlesme.AKT_2 = aktarilanAltinRehni.SaflikDerecesi;
            sozlesme.YEDI_EMIN_CARI_ID = DetermineCustomerCariID(aktarilanAltinRehni.Yeddiemin, null);
            sozlesme.ACIKLAMA = aktarilanAltinRehni.Aciklama;

            #region Taraflar

            aktarilanAltinRehni.Taraflar.ForEach(taraf => SetRehinTeminatTarafValues(sozlesme, taraf));

            #endregion Taraflar

            return sozlesme;
        }

        public static AV001_TDI_BIL_KIYMETLI_EVRAK SetBonoVales(AV001_TDI_BIL_KIYMETLI_EVRAK bono, Classes.Bono aktarilanBono)
        {
            bono.EVRAK_TUR_ID = (int)EvrakTurleri.BONO;
            bono.DURUM = ParametreClass.MappingEvrakDurum(aktarilanBono.Durum);
            bono.REFERANS_NO = aktarilanBono.ReferansNo;
            if (aktarilanBono.EvrakTazminTarihi > DateTime.MinValue && aktarilanBono.EvrakTazminTarihi.Year < 2076) bono.EVRAK_TANZIM_TARIHI = aktarilanBono.EvrakTazminTarihi;
            if (aktarilanBono.EvrakVadeTarihi > DateTime.MinValue && aktarilanBono.EvrakVadeTarihi.Year < 2076) bono.EVRAK_VADE_TARIHI = aktarilanBono.EvrakVadeTarihi;
            bono.TUTAR = aktarilanBono.Tutari;
            bono.TUTAR_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanBono.TutariParaBirimi);
            bono.MUNZAM_SENET_MI = aktarilanBono.MunzamSenetMi;

            #region Taraflar

            if (aktarilanBono.Taraflar != null)
                aktarilanBono.Taraflar.ForEach(taraf => SetEvrakTarafValues(bono, taraf));

            #endregion Taraflar

            return bono;
        }

        //Müşteri sistemde yoksa yeni oluşturulması için alanların bind edilmesinde kullanılıyor.
        public static AV001_TDI_BIL_CARI SetCariValues(AV001_TDI_BIL_CARI musteri, Classes.CariBilgileri aktarilanCari)
        {
            var musteriKimlik = musteri.AV001_TDI_BIL_CARI_KIMLIKCollection.AddNew();

            #region Genel Bilgiler

            musteri.AD = aktarilanCari.Ad;

            if (musteri.ID == 0)
            {
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = AvukatProLib.Kimlik.SirketBilgisi.ConStr;

                string kod = cn.ExecuteScalar("SELECT MAX(KOD) FROM dbo.AV001_TDI_BIL_CARI").ToString();

                //var kod = (from item in BelgeUtil.Inits.context.AV001_TDI_BIL_CARIs where item.KOD != null && item.KOD.Trim() != string.Empty orderby item.ID descending select item.KOD).FirstOrDefault();
                musteri.KOD = (Convert.ToInt32(kod) + 1).ToString();
            }

            musteri.MUSTERI_NO = aktarilanCari.Kod;
            musteri.KARSI_TARAF_MI = true;
            if (!string.IsNullOrEmpty(aktarilanCari.Adres1Line1)) musteri.ADRES_1 = aktarilanCari.Adres1Line1;
            if (!string.IsNullOrEmpty(aktarilanCari.Adres1Line2)) musteri.ADRES_2 = aktarilanCari.Adres1Line2;
            if (!string.IsNullOrEmpty(aktarilanCari.Adres1Line3)) musteri.ADRES_3 = aktarilanCari.Adres1Line3;

            //  musteri.ADRES_TUR_ID = aktarilanCari.Adres1Tur; MAP
            if (!string.IsNullOrEmpty(aktarilanCari.Adres2Line1)) musteri.ADRES2_1 = aktarilanCari.Adres2Line1;
            if (!string.IsNullOrEmpty(aktarilanCari.Adres2Line2)) musteri.ADRES2_2 = aktarilanCari.Adres2Line2;
            if (!string.IsNullOrEmpty(aktarilanCari.Adres2Line3)) musteri.ADRES2_3 = aktarilanCari.Adres2Line3;

            //musteri.ADRES2_TUR_ID = aktarilanCari.Adres2Tur; MAP
            if (!string.IsNullOrEmpty(aktarilanCari.Adres3Line1)) musteri.ADRES3_1 = aktarilanCari.Adres3Line1;
            if (!string.IsNullOrEmpty(aktarilanCari.Adres3Line2)) musteri.ADRES3_2 = aktarilanCari.Adres3Line2;
            if (!string.IsNullOrEmpty(aktarilanCari.Adres3Line3)) musteri.ADRES3_3 = aktarilanCari.Adres3Line3;

            //musteri.ADRES3_TUR_ID = aktarilanCari.Adres3Tur; MAP
            //Aktif Adres default 1 verilecek. Aktarım sırasında değer gelirse alınmayacak.
            musteri.AKTIF_ADRES = true; //Birinci Adres
            if (!string.IsNullOrEmpty(aktarilanCari.EMail1)) musteri.EMAIL_1 = aktarilanCari.EMail1;
            if (!string.IsNullOrEmpty(aktarilanCari.EMail2)) musteri.EMAIL_2 = aktarilanCari.EMail2;
            if (!string.IsNullOrEmpty(aktarilanCari.Fax)) musteri.FAX = aktarilanCari.Fax;

            //musteri.FIRMA_TUR_ID = aktarilanCari.FirmaTuru; MAP
            if (!string.IsNullOrEmpty(aktarilanCari.GSM1)) musteri.CEP_TEL = aktarilanCari.GSM1;
            if (!string.IsNullOrEmpty(aktarilanCari.GSM2)) musteri.CEP_TEL2 = aktarilanCari.GSM2;
            if (!string.IsNullOrEmpty(aktarilanCari.PostaKodu1)) musteri.POSTA_KODU = aktarilanCari.PostaKodu1;
            if (!string.IsNullOrEmpty(musteri.POSTA_KODU2)) musteri.POSTA_KODU2 = aktarilanCari.PostaKodu2;
            if (!string.IsNullOrEmpty(aktarilanCari.PostaKodu3)) musteri.POSTA_KODU3 = aktarilanCari.PostaKodu3;
            if (!string.IsNullOrEmpty(aktarilanCari.IBAN)) musteri.IBAN_NO = aktarilanCari.IBAN;
            musteri.IL_ID = ParametreClass.MappingIl(aktarilanCari.Il1);
            musteri.IL2_ID = ParametreClass.MappingIl(aktarilanCari.Il2);
            musteri.IL3_ID = ParametreClass.MappingIl(aktarilanCari.Il3);
            musteri.ILCE_ID = ParametreClass.MappingIlce(aktarilanCari.Ilce1);
            musteri.ILCE2_ID = ParametreClass.MappingIlce(aktarilanCari.Ilce2);
            musteri.ILCE3_ID = ParametreClass.MappingIlce(aktarilanCari.Ilce3);

            //musteri.MESLEK_ID = aktarilanCari.Meslek; MAP
            if (!string.IsNullOrEmpty(aktarilanCari.Telefon1)) musteri.TEL_1 = aktarilanCari.Telefon1;
            if (!string.IsNullOrEmpty(aktarilanCari.Telefon2)) musteri.TEL_2 = aktarilanCari.Telefon2;
            if (!string.IsNullOrEmpty(aktarilanCari.TicariSicilNo)) musteri.SICIL_NO = aktarilanCari.TicariSicilNo;
            if (!string.IsNullOrEmpty(aktarilanCari.TicariSicilTarihi))
                musteri.TICARI_SICIL_TARIHI = Convert.ToDateTime(aktarilanCari.TicariSicilTarihi);

            //musteri.TICARI_SICIL_YERI_ID = aktarilanCari.TicariSicilYeri; MAP
            musteri.ULKE_ID = ParametreClass.MappingUlke(aktarilanCari.Ulke1);
            musteri.ULKE2_ID = ParametreClass.MappingUlke(aktarilanCari.Ulke2);
            musteri.ULKE3_ID = ParametreClass.MappingUlke(aktarilanCari.Ulke3);
            if (!string.IsNullOrEmpty(aktarilanCari.VergiDairesi)) musteri.VERGI_DAIRESI = aktarilanCari.VergiDairesi;
            if (!string.IsNullOrEmpty(aktarilanCari.VergiNo)) musteri.VERGI_NO = aktarilanCari.VergiNo;
            if (!string.IsNullOrEmpty(aktarilanCari.WebURL)) musteri.WEB = aktarilanCari.WebURL;

            //Sorunlu!!!!
            //musteri.AD = aktarilanCari.OgrenimDurumu;
            //musteri.AD = aktarilanCari.SonCalistigiKurum;
            //musteri.AD = aktarilanCari.SonMezuniyetOkul;

            #endregion Genel Bilgiler

            #region Kimlik Bilgileri

            if (!string.IsNullOrEmpty(aktarilanCari.AnaAdi)) musteriKimlik.ANA_ADI = aktarilanCari.AnaAdi;
            if (!string.IsNullOrEmpty(aktarilanCari.AnneKizlikSoyadi)) musteriKimlik.ANNE_KIZLIK_SOYADI = aktarilanCari.AnneKizlikSoyadi;
            if (!string.IsNullOrEmpty(aktarilanCari.BabaAdi)) musteriKimlik.BABA_ADI = aktarilanCari.BabaAdi;
            if (!string.IsNullOrEmpty(aktarilanCari.CiltNo)) musteriKimlik.NKO_CILT_NO = aktarilanCari.CiltNo;

            //musteriKimlik.CINSIYET_ID = aktarilanCari.Cinsiyet; MAP
            if (!string.IsNullOrEmpty(aktarilanCari.Dini)) musteriKimlik.DINI = aktarilanCari.Dini;
            if (!string.IsNullOrEmpty(aktarilanCari.DogumTarihi)) musteriKimlik.DOGUM_TARIHI = Convert.ToDateTime(aktarilanCari.DogumTarihi);
            if (!string.IsNullOrEmpty(aktarilanCari.DogumYeri)) musteriKimlik.DOGUM_YERI = aktarilanCari.DogumYeri;

            //musteriKimlik.KAN_GRUP_ID = aktarilanCari.KanGrup; MAP
            if (!string.IsNullOrEmpty(aktarilanCari.KimlikKayitNo)) musteriKimlik.CUZDANIN_KAYIT_NO = aktarilanCari.KimlikKayitNo;
            if (!string.IsNullOrEmpty(aktarilanCari.KimlikSeriNo)) musteriKimlik.BELGE_SERI_NO = aktarilanCari.KimlikSeriNo;

            //musteriKimlik.KIMLIK_ID = aktarilanCari.KimlikTuru; MAP
            if (aktarilanCari.KimlikVerildigiTarih > DateTime.MinValue) musteriKimlik.CUZDANIN_VERILIS_TARIHI = aktarilanCari.KimlikVerildigiTarih;
            if (!string.IsNullOrEmpty(aktarilanCari.KimlikVerildigiYer)) musteriKimlik.CUZDANIN_VERILDIGI_YER = aktarilanCari.KimlikVerildigiYer;

            //musteriKimlik.MEDENI_HAL_ID = aktarilanCari.MedeniHal; MAP
            musteriKimlik.NKO_IL_ID = ParametreClass.MappingIl(aktarilanCari.NKIl);
            musteriKimlik.NKO_ILCE_ID = ParametreClass.MappingIlce(aktarilanCari.NKIlce);
            if (!string.IsNullOrEmpty(aktarilanCari.NKMahalle)) musteriKimlik.NKO_MAHALLE_KOY = aktarilanCari.NKMahalle;
            if (!string.IsNullOrEmpty(aktarilanCari.OncekiSoyadi)) musteriKimlik.NKO_SIRA_NO = aktarilanCari.OncekiSoyadi;
            if (!string.IsNullOrEmpty(aktarilanCari.SiraNo)) musteriKimlik.NKO_SIRA_NO = aktarilanCari.SiraNo;
            if (!string.IsNullOrEmpty(aktarilanCari.AileSeriNo)) musteriKimlik.NKO_AILE_SIRA_NO = aktarilanCari.AileSeriNo;
            if (!string.IsNullOrEmpty(aktarilanCari.TCKimlikNo)) musteriKimlik.TC_KIMLIK_NO = aktarilanCari.TCKimlikNo;

            //musteriKimlik.UYRUK_ID = aktarilanCari.Uyruk; MAP
            //musteriKimlik.CUZDANIN_VERILME_NEDENI_ID = aktarilanCari.VerilmeNedeni; MAP

            #endregion Kimlik Bilgileri

            return musteri;
        }

        public static AV001_TDI_BIL_KIYMETLI_EVRAK SetCekValues(AV001_TDI_BIL_KIYMETLI_EVRAK cek, Classes.Cek aktarilanCek)
        {
            cek.EVRAK_TUR_ID = (int)EvrakTurleri.ÇEK;
            cek.BANKA_ID = ParametreClass.MappingBanka(aktarilanCek.Banka);
            cek.SUBE_ID = ParametreClass.MappingBankaSube(aktarilanCek.Sube);
            cek.CEK_NO = aktarilanCek.CekNo;
            cek.DURUM = ParametreClass.MappingEvrakDurum(aktarilanCek.Durum);
            cek.REFERANS_NO = aktarilanCek.ReferanNo;
            cek.HESAP_NO = aktarilanCek.HesapNo;
            cek.KESIDE_YERI = aktarilanCek.KesideYeri;
            cek.ODEME_YERI = aktarilanCek.OdemeYeri;
            if (aktarilanCek.SorulduguTarih > DateTime.MinValue) cek.SORULDUGU_TARIH = aktarilanCek.SorulduguTarih;
            cek.TUTAR = aktarilanCek.Tutari;
            cek.TUTAR_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanCek.TutariParaBirimi);
            if (aktarilanCek.VadeTarihi > DateTime.MinValue) cek.EVRAK_VADE_TARIHI = aktarilanCek.VadeTarihi;

            #region Taraflar

            aktarilanCek.Taraflar.ForEach(taraf => SetEvrakTarafValues(cek, taraf));

            #endregion Taraflar

            return cek;
        }

        public static AV001_TDI_BIL_SOZLESME SetDigerRehniValues(AV001_TDI_BIL_SOZLESME sozlesme, Classes.DigerRehin aktarilanDigerRehni)
        {
            sozlesme.DURUM = ParametreClass.MappingTeminatDurum(aktarilanDigerRehni.Durum);
            sozlesme.REFERANS_NO = aktarilanDigerRehni.ReferanNo;
            sozlesme.BEDELI = aktarilanDigerRehni.Tutari;
            sozlesme.BEDELI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanDigerRehni.TutariParaBirimi);

            //sozlesme.REHIN_CINS_ID = aktarilanDigerRehni.RehinTuru; MAP
            sozlesme.IMZA_TARIHI = aktarilanDigerRehni.RehinTarihi;
            sozlesme.YEDI_EMIN_CARI_ID = DetermineCustomerCariID(aktarilanDigerRehni.Yeddiemin, null);
            sozlesme.ACIKLAMA = aktarilanDigerRehni.Aciklama;

            #region Taraflar

            aktarilanDigerRehni.Taraflar.ForEach(taraf => SetRehinTeminatTarafValues(sozlesme, taraf));

            #endregion Taraflar

            return sozlesme;
        }

        public static AV001_TDI_BIL_MASRAF_AVANS SetDosyaMasrafValues(AV001_TDI_BIL_MASRAF_AVANS masrafItem, XElement item, int musteriID)
        {
            masrafItem.CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
            masrafItem.MASRAF_AVANS_TIP = (int)AvukatProLib.Extras.MasrafAvansTip.Masraf;
            masrafItem.BORCLU_CARI_ID = musteriID;
            masrafItem.MANUEL_KAYIT_MI = true;
            masrafItem.REFERANS_NO = string.Format(@"{0}\{1}\{2}", DateTime.Today.Year, DateTime.Today.Month, Guid.NewGuid().ToString().Split('-')[0].ToUpper());
            masrafItem.ESLESTI_MI = true;

            //Default Değerler
            masrafItem.KAYIT_TARIHI = DateTime.Now;
            masrafItem.KONTROL_NE_ZAMAN = DateTime.Now;
            masrafItem.KONTROL_KIM = "AVUKATPRO";
            masrafItem.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            masrafItem.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            masrafItem.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            masrafItem.KLASOR_KODU = "GENEL";

            var masrafDetayItem = masrafItem.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.AddNew();

            masrafDetayItem.BORC_ALACAK_ID = 2;//Borç
            masrafDetayItem.ODEME_TIP_ID = (int)AvukatProLib.Extras.OdemeTip.NAKİT;
            masrafDetayItem.MUVEKKIL_CARI_ID = 1906;//ING BANK A.Ş.
            masrafDetayItem.TARIH = Convert.ToDateTime(item.Element("MasrafTarihi").Value);
            masrafDetayItem.TOPLAM_TUTAR = Convert.ToDecimal(item.Element("ToplamTutar").Value.ReplaceFromPoint());
            masrafDetayItem.TOPLAM_TUTAR_DOVIZ_ID = 1;//Masraflar hep TL olur.
            masrafDetayItem.HAREKET_ANA_KATEGORI_ID = 1;
            masrafDetayItem.HAREKET_ALT_KATEGORI_ID = 1;

            //Default Değerler
            masrafDetayItem.KAYIT_TARIHI = DateTime.Now;
            masrafDetayItem.KONTROL_NE_ZAMAN = DateTime.Now;
            masrafDetayItem.KONTROL_KIM = "AVUKATPRO";
            masrafDetayItem.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            masrafDetayItem.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            masrafDetayItem.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            masrafDetayItem.KLASOR_KODU = "GENEL";
            masrafDetayItem.TARIH = DateTime.Now.Date;

            return masrafItem;
        }

        public static AV001_TI_BIL_BORCLU_ODEME SetDosyaOdemeValues(AV001_TI_BIL_BORCLU_ODEME odemeItem, XElement item, int musteriID)
        {
            odemeItem.ESLESTI_MI = true;
            odemeItem.ODEYEN_CARI_ID = musteriID;
            odemeItem.BORCLU_ADINA_ODEYEN_CARI_ID = musteriID;
            odemeItem.ODENEN_CARI_ID = 1906;//ING BANK A.Ş.
            odemeItem.BORCLU_ADINA_ODENEN_CARI_ID = 1906;//ING BANK A.Ş.
            odemeItem.ODEME_TARIHI = Convert.ToDateTime(item.Element("OdemeTarihi").Value);
            odemeItem.ODEME_MIKTAR = Convert.ToDecimal(item.Element("OdemeMiktarı").Value.ReplaceFromPoint());
            odemeItem.ODEME_MIKTAR_DOVIZ_ID = ParametreClass.MappingDovizTip(item.Element("OdemeMiktariParaBirimi").Value);

            odemeItem.ODEME_YER_ID = 1;//Avukata
            odemeItem.ODEME_KIM_ADINA = 1;//Kendi Adına

            return odemeItem;
        }

        public static AV001_TDI_BIL_SOZLESME SetEmtiaRehniValues(AV001_TDI_BIL_SOZLESME sozlesme, Classes.EmtiaRehni aktarilanEmtiaRehni)
        {
            sozlesme.DURUM = ParametreClass.MappingTeminatDurum(aktarilanEmtiaRehni.Durum);
            sozlesme.REFERANS_NO = aktarilanEmtiaRehni.ReferanNo;
            sozlesme.TIP_ID = 3;//Resmi Senet
            sozlesme.ALT_TIP_ID = 184;//Emtia Rehni
            sozlesme.BEDELI = aktarilanEmtiaRehni.Tutari;
            sozlesme.BEDELI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanEmtiaRehni.TutariParaBirimi);

            //sozlesme.REHIN_CINS_ID = aktarilanEmtiaRehni.RehinTuru; MAP
            sozlesme.IMZA_TARIHI = aktarilanEmtiaRehni.RehinTarihi;
            sozlesme.YEDI_EMIN_CARI_ID = DetermineCustomerCariID(aktarilanEmtiaRehni.Yeddiemin, null);
            sozlesme.ACIKLAMA = aktarilanEmtiaRehni.Aciklama;

            #region Taraflar

            aktarilanEmtiaRehni.Taraflar.ForEach(taraf => SetRehinTeminatTarafValues(sozlesme, taraf));

            #endregion Taraflar

            return sozlesme;
        }

        public static AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF SetEvrakTarafValues(AV001_TDI_BIL_KIYMETLI_EVRAK evrak, Classes.Taraf aktarilanTaraf)
        {
            var taraf = evrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection.AddNew();
            if (!string.IsNullOrEmpty(aktarilanTaraf.Musteri))
                taraf.TARAF_CARI_ID = DetermineCustomerCariID(aktarilanTaraf.Musteri, aktarilanTaraf.MusteriNo);
            taraf.TARAF_TIP_ID = ParametreClass.MappingTarafSifat(aktarilanTaraf.TarafSifat);

            return taraf;
        }

        public static AV001_TDI_BIL_SOZLESME SetFirmaGarantileriValues(AV001_TDI_BIL_SOZLESME sozlesme, Classes.FirmaGaranti aktarilanFirmaGaranti)
        {
            sozlesme.DURUM = ParametreClass.MappingTeminatDurum(aktarilanFirmaGaranti.Durum);
            sozlesme.REFERANS_NO = aktarilanFirmaGaranti.ReferansNo;
            sozlesme.TIP_ID = 3;//Resmi Senet
            sozlesme.ALT_TIP_ID = 183;//Firma Garanti
            sozlesme.BEDELI = aktarilanFirmaGaranti.Tutar;
            sozlesme.BEDELI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanFirmaGaranti.TutarParaBirimi);
            sozlesme.AKT_1 = aktarilanFirmaGaranti.GarantorMusteri;
            sozlesme.AKT_2 = aktarilanFirmaGaranti.GarantorMusteriAdresi;

            #region Taraflar

            aktarilanFirmaGaranti.Taraflar.ForEach(taraf => SetRehinTeminatTarafValues(sozlesme, taraf));

            #endregion Taraflar

            return sozlesme;
        }

        public static AV001_TI_BIL_GAYRIMENKUL_TARAF SetGayrimenkulTarafValues(AV001_TI_BIL_GAYRIMENKUL gayrimenkul, Classes.GayrimenkulTaraf aktarilanTaraf)
        {
            var taraf = gayrimenkul.AV001_TI_BIL_GAYRIMENKUL_TARAFCollection.AddNew();
            if (!string.IsNullOrEmpty(aktarilanTaraf.Musteri))
                taraf.TARAF_CARI_ID = DetermineCustomerCariID(aktarilanTaraf.Musteri, aktarilanTaraf.MusteriNo);
            taraf.HISSE_ORAN = aktarilanTaraf.HisseOran;
            taraf.TARAF_SIFAT_ID = 1;//MALİK (YENİ MALİK)

            return taraf;
        }

        public static AV001_TI_BIL_ALACAK_NEDEN SetGayrinakitAlacakValues(AV001_TI_BIL_ALACAK_NEDEN gayrinakitAlacak, Classes.GayriNakitAlacak aktarilanGayrinakitAlacak)
        {
            //ADET alanı Çek yapraklarında çek yaprağı sayısı, teminat mektuplarında veriliş nosu olarak kullandığından aşağıdaki şekilde yapıldı.
            if (!string.IsNullOrEmpty(aktarilanGayrinakitAlacak.VerilisNo))
            {
                gayrinakitAlacak.ADET = Convert.ToInt32(aktarilanGayrinakitAlacak.VerilisNo);
                if (!string.IsNullOrEmpty(aktarilanGayrinakitAlacak.Muhatabi))
                    gayrinakitAlacak.TEMINAT_MEKTUP_MUHATAP_CARI_ID = DetermineCustomerCariID(aktarilanGayrinakitAlacak.Muhatabi, null);
            }
            else if (aktarilanGayrinakitAlacak.CekAdedi != 0)
            {
                gayrinakitAlacak.ADET = aktarilanGayrinakitAlacak.CekAdedi;
                gayrinakitAlacak.TEMINAT_MEKTUP_MUHATAP_CARI_ID = 1906;//INGBANK A.Ş Çek
                if (!string.IsNullOrEmpty(gayrinakitAlacak.ACIKLAMA)) aktarilanGayrinakitAlacak.Aciklama = aktarilanGayrinakitAlacak.Aciklama;
            }

            gayrinakitAlacak.CEK_YAPRAGI_SORUMLULUK_MIKTARI = aktarilanGayrinakitAlacak.CekYapragiILKSorumlulukMiktari;
            gayrinakitAlacak.CEK_YAPRAGI_SORUMLULUK_MIKTARI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanGayrinakitAlacak.CekYapragiILKSorumlulukMiktariParaBirimi);
            gayrinakitAlacak.CEK_YAPRAGI_SON_SORUMLULUK_MIKTARI = aktarilanGayrinakitAlacak.CekYapragiSONSorumlulukMiktari;
            gayrinakitAlacak.CEK_YAPRAGI_SON_SORUMLULUK_MIKTARI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanGayrinakitAlacak.CekYapragiSONSorumlulukMiktariParaBirimi);
            if (aktarilanGayrinakitAlacak.VeridildigiTarih > DateTime.MinValue)
                gayrinakitAlacak.DUZENLENME_TARIHI = gayrinakitAlacak.FAIZ_BASLANGIC_TARIHI = aktarilanGayrinakitAlacak.VeridildigiTarih;
            gayrinakitAlacak.ALACAK_NEDEN_KOD_ID = ParametreClass.MappingAlacakNedeni(aktarilanGayrinakitAlacak.AlacakTipi);

            if (BelgeUtil.Inits._TI_KOD_AlacakNedeniDoldur == null)
                BelgeUtil.Inits._TI_KOD_AlacakNedeniDoldur = DataRepository.per_TI_KOD_ALACAK_NEDENProvider.GetAll();
            var alacakNeden = BelgeUtil.Inits._TI_KOD_AlacakNedeniDoldur.Find(vi => vi.ID == gayrinakitAlacak.ALACAK_NEDEN_KOD_ID);

            //Bazı durumlarda aşağıdaki property filtrelenip geldiğinden alacak nedeni bulunamıyordu. Bu sorunun önüne geçmek için aşağıdaki kontrol eklendi.
            if (alacakNeden == null) BelgeUtil.Inits._TI_KOD_AlacakNedeniDoldur = DataRepository.per_TI_KOD_ALACAK_NEDENProvider.GetAll();
            if (alacakNeden != null)
                gayrinakitAlacak.DIGER_ALACAK_NEDENI = alacakNeden.ALACAK_NEDENI;

            gayrinakitAlacak.BSMV_HESAPLANSIN = aktarilanGayrinakitAlacak.BSMVHesaplansin;
            gayrinakitAlacak.REFERANS_NO2 = aktarilanGayrinakitAlacak.ReferansNo2;//Çek yapraklarında bu alan kullanılmıyor. Diğer gayrinakitlerde unique bir alan olarak kullanılacak. Çek yapraklarında birden fazla çek yaprağı tek bir alacak haline getirildiğinden bütün çek yapraklarının referans numaraları aralarına virgül konularak yazılacak.
            if (gayrinakitAlacak.ALACAK_NEDEN_KOD_ID == 93)
                gayrinakitAlacak.TUTARI = gayrinakitAlacak.ISLEME_KONAN_TUTAR = gayrinakitAlacak.CEK_YAPRAGI_SORUMLULUK_MIKTARI.Value * gayrinakitAlacak.ADET.Value;
            else
                gayrinakitAlacak.TUTARI = gayrinakitAlacak.ISLEME_KONAN_TUTAR = aktarilanGayrinakitAlacak.Tutari;
            gayrinakitAlacak.TUTAR_DOVIZ_ID = gayrinakitAlacak.ISLEME_KONAN_TUTAR_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanGayrinakitAlacak.TutariParaBirimi);

            #region Taraflar

            if (aktarilanGayrinakitAlacak.Taraflari != null)
                aktarilanGayrinakitAlacak.Taraflari.ForEach(item => SetAlacakTarafValues(gayrinakitAlacak, item, false));

            #endregion Taraflar

            #region Hareketler

            if (aktarilanGayrinakitAlacak.Hareketler != null)
                aktarilanGayrinakitAlacak.Hareketler.ForEach(item => SetGayrinakitHareketValues(gayrinakitAlacak, item));

            #endregion Hareketler

            return gayrinakitAlacak;
        }

        public static AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAY SetGayrinakitHareketValues(AV001_TI_BIL_ALACAK_NEDEN alacak, Classes.GayrinakitHareket aktarilanHareket)
        {
            var gNakitHareket = alacak.AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAYCollection.AddNew();

            //Depo bilgileri aktarımda gelmeyecek. Banka tarafında tutulan bir bilgi değil. O nedenle XML'de eksil olan depo eden bilgisinin eklenmesine gerek yok.
            if (aktarilanHareket.DepoTarihi > DateTime.MinValue) gNakitHareket.DEPO_TARIHI = aktarilanHareket.DepoTarihi;
            gNakitHareket.DEPO_TUTARI = aktarilanHareket.DepoMikari;
            gNakitHareket.DEPO_TUTARI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanHareket.DepoMiktariParaBirimi);
            if (aktarilanHareket.IadeTarihi > DateTime.MinValue) gNakitHareket.IADE_TARIHI = aktarilanHareket.IadeTarihi;
            gNakitHareket.IADE_TUTARI = aktarilanHareket.IadeMiktari;
            gNakitHareket.IADE_TUTARI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanHareket.IadeMiktariParaBirimi);
            if (aktarilanHareket.TazminTarihi > DateTime.MinValue) gNakitHareket.TAZMIN_TARIHI = aktarilanHareket.TazminTarihi;
            gNakitHareket.TAZMIN_TUTARI = aktarilanHareket.TazminMikari;
            gNakitHareket.TAZMIN_TUTARI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanHareket.TazminMiktariParaBirimi);

            return gNakitHareket;
        }

        public static AV001_TDI_BIL_SOZLESME SetGUAValues(AV001_TDI_BIL_SOZLESME ucakSozlesme, Classes.UcakRehin aktarilanUcak, AV001_TI_BIL_FOY yeniTakip)
        {
            ucakSozlesme.TIP_ID = 3;//Resmi Senet
            ucakSozlesme.ALT_TIP_ID = 7;//Hava Aracı İpoteği
            if (!string.IsNullOrEmpty(aktarilanUcak.Aciklama))
                ucakSozlesme.ACIKLAMA = aktarilanUcak.Aciklama;
            else
                ucakSozlesme.ACIKLAMA = " ";
            ucakSozlesme.DURUM = ParametreClass.MappingTeminatDurum(aktarilanUcak.Durum);
            ucakSozlesme.REFERANS_NO = aktarilanUcak.ReferanNo;
            ucakSozlesme.IMZA_TARIHI = aktarilanUcak.RehinTarihi;

            //ucakSozlesme.REHIN_CINS_ID = aktarilanUcak.RehinTuru; MAP
            ucakSozlesme.SICIL_TESCIL_NO = aktarilanUcak.SicilTescilNo;
            ucakSozlesme.SICIL_YEVMIYE_NO = aktarilanUcak.SicilYevmiyeNo;
            ucakSozlesme.BEDELI = aktarilanUcak.Tutari;
            ucakSozlesme.BEDELI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanUcak.TutariParaBirimi);
            if (!string.IsNullOrEmpty(aktarilanUcak.Yeddiemin))
                ucakSozlesme.YEDI_EMIN_CARI_ID = DetermineCustomerCariID(aktarilanUcak.Yeddiemin, null);

            AV001_TDI_BIL_GEMI_UCAK_ARAC ucak = new AV001_TDI_BIL_GEMI_UCAK_ARAC();

            ucak.ADI = aktarilanUcak.Adi;
            ucak.CINSI = aktarilanUcak.Cinsi;
            ucak.TIPI = 7;//UÇAK
            ucak.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.Save(ucak);

            var sozlesme = ucakSozlesme.NN_SOZLESME_GEMI_UCAK_ARACCollection.AddNew();
            sozlesme.GEMI_UCAK_ARAC_ID = ucak.ID;

            //Yeni bağımsız takip oluştururken NN_ICRA_GEMI_UCAK_ARAC tablosuna da kayıt yapılması gerektiğinden eklendi. Klasör oluşturulurken yeniTakip null geleceğinden bu tabloya kayıt eklenmeyecek.
            if (yeniTakip != null)
            {
                var icraGUA = yeniTakip.NN_ICRA_GEMI_UCAK_ARACCollection.AddNew();
                icraGUA.GEMI_UCAK_ARAC_ID = ucak.ID;
            }

            #region Taraflar

            aktarilanUcak.Taraflar.ForEach(taraf => SetRehinTeminatTarafValues(ucakSozlesme, taraf));

            #endregion Taraflar

            return ucakSozlesme;
        }

        public static AV001_TDI_BIL_SOZLESME SetGUAValues(AV001_TDI_BIL_SOZLESME gemiSozlesme, Classes.GemiRehin aktarilanGemi, AV001_TI_BIL_FOY yeniTakip)
        {
            gemiSozlesme.TIP_ID = 3;//Resmi Senet
            gemiSozlesme.ALT_TIP_ID = 6;//Gemi İpoteği
            if (!string.IsNullOrEmpty(aktarilanGemi.Aciklama))
                gemiSozlesme.ACIKLAMA = aktarilanGemi.Aciklama;
            else
                gemiSozlesme.ACIKLAMA = " ";
            gemiSozlesme.DURUM = ParametreClass.MappingTeminatDurum(aktarilanGemi.Durum);
            gemiSozlesme.REFERANS_NO = aktarilanGemi.ReferanNo;
            gemiSozlesme.IMZA_TARIHI = aktarilanGemi.RehinTarihi;

            //gemiSozlesme.REHIN_CINS_ID = aktarilanGemi.RehinTuru; MAP
            gemiSozlesme.SICIL_TESCIL_NO = aktarilanGemi.SicilTescilNo;
            gemiSozlesme.SICIL_YEVMIYE_NO = aktarilanGemi.SicilYevmiyeNo;
            gemiSozlesme.BEDELI = aktarilanGemi.Tutari;
            gemiSozlesme.BEDELI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanGemi.TutariParaBirimi);
            gemiSozlesme.YEDI_EMIN_CARI_ID = DetermineCustomerCariID(aktarilanGemi.Yeddiemin, null);

            AV001_TDI_BIL_GEMI_UCAK_ARAC gemi = new AV001_TDI_BIL_GEMI_UCAK_ARAC();

            gemi.ADI = aktarilanGemi.Adi;
            gemi.CINSI = aktarilanGemi.Cinsi;
            gemi.TIPI = 8;//GEMİ
            gemi.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.Save(gemi);

            var sozlesme = gemiSozlesme.NN_SOZLESME_GEMI_UCAK_ARACCollection.AddNew();
            sozlesme.GEMI_UCAK_ARAC_IDSource = gemi;

            //Yeni bağımsız takip oluştururken NN_ICRA_GEMI_UCAK_ARAC tablosuna da kayıt yapılması gerektiğinden eklendi. Klasör oluşturulurken yeniTakip null geleceğinden bu tabloya kayıt eklenmeyecek.
            if (yeniTakip != null)
            {
                var icraGUA = yeniTakip.NN_ICRA_GEMI_UCAK_ARACCollection.AddNew();
                icraGUA.GEMI_UCAK_ARAC_IDSource = gemi;
            }

            #region Taraflar

            aktarilanGemi.Taraflar.ForEach(taraf => SetRehinTeminatTarafValues(gemiSozlesme, taraf));

            #endregion Taraflar

            return gemiSozlesme;
        }

        public static AV001_TDI_BIL_SOZLESME SetGUAValues(AV001_TDI_BIL_SOZLESME aracSozlesme, Classes.AracRehin aktarilanArac, AV001_TI_BIL_FOY yeniTakip)
        {
            aracSozlesme.TIP_ID = 3;//Resmi Senet
            aracSozlesme.ALT_TIP_ID = 8;//Araç Rehni
            if (!string.IsNullOrEmpty(aktarilanArac.Aciklama))
                aracSozlesme.ACIKLAMA = aktarilanArac.Aciklama;
            else
                aracSozlesme.ACIKLAMA = " ";
            aracSozlesme.DURUM = ParametreClass.MappingTeminatDurum(aktarilanArac.Durum);
            aracSozlesme.REFERANS_NO = aktarilanArac.ReferanNo;
            aracSozlesme.IMZA_TARIHI = aktarilanArac.RehinTarihi;

            //aracSozlesme.REHIN_CINS_ID = aktarilanArac.RehinTuru; MAP
            aracSozlesme.SICIL_YEVMIYE_NO = aktarilanArac.SicilYevmiyeNo;
            aracSozlesme.BEDELI = aktarilanArac.Tutari;
            aracSozlesme.BEDELI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanArac.TutariParaBirimi);
            aracSozlesme.YEDI_EMIN_CARI_ID = DetermineCustomerCariID(aktarilanArac.Yeddiemin, null);

            AV001_TDI_BIL_GEMI_UCAK_ARAC arac = new AV001_TDI_BIL_GEMI_UCAK_ARAC();

            arac.ARAC_PLAKA = aktarilanArac.AracPlakaNo;
            arac.ARAC_MODEL = aktarilanArac.AracModel;
            arac.ARAC_MOTOR_NO = aktarilanArac.AracMotorNo;
            arac.ARAC_RENK = aktarilanArac.AracRenk;
            arac.ARAC_SASI_NO = aktarilanArac.AracSasiNo;
            arac.ARAC_TIP = aktarilanArac.AracTip;
            arac.TRAFIK_SUBESI = aktarilanArac.TrafikSubesi;
            arac.RUHSAT_SICIL_NO = aktarilanArac.RuhsatSicilNo;
            arac.TIPI = 9;//ARAÇ
            arac.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.Save(arac);

            var sozlesme = aracSozlesme.NN_SOZLESME_GEMI_UCAK_ARACCollection.AddNew();
            sozlesme.GEMI_UCAK_ARAC_IDSource = arac;

            //Yeni bağımsız takip oluştururken NN_ICRA_GEMI_UCAK_ARAC tablosuna da kayıt yapılması gerektiğinden eklendi. Klasör oluşturulurken yeniTakip null geleceğinden bu tabloya kayıt eklenmeyecek.
            if (yeniTakip != null)
            {
                var icraGUA = yeniTakip.NN_ICRA_GEMI_UCAK_ARACCollection.AddNew();
                icraGUA.GEMI_UCAK_ARAC_IDSource = arac;
            }

            #region Taraflar

            aktarilanArac.Taraflar.ForEach(taraf => SetRehinTeminatTarafValues(aracSozlesme, taraf));

            #endregion Taraflar

            return aracSozlesme;
        }

        public static AV001_TDI_BIL_SOZLESME SetHatRehniValues(AV001_TDI_BIL_SOZLESME sozlesme, Classes.HatRehni aktarilanHatRehni)
        {
            sozlesme.DURUM = ParametreClass.MappingTeminatDurum(aktarilanHatRehni.Durum);
            sozlesme.REFERANS_NO = aktarilanHatRehni.ReferanNo;
            sozlesme.TIP_ID = 3;//Hat Rehni
            sozlesme.ALT_TIP_ID = 172;//Hat Rehni
            sozlesme.BEDELI = aktarilanHatRehni.Tutari;
            sozlesme.BEDELI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanHatRehni.TutariParaBirimi);

            //sozlesme.BEDELI = aktarilanHatRehni.HatTuru; Veritabanına durum alanı eklenecek.
            //sozlesme.BEDELI = aktarilanHatRehni.HatAdi; Veritabanına durum alanı eklenecek.
            //sozlesme.REHIN_CINS_ID = aktarilanHatRehni.RehinTuru; MAP
            sozlesme.AKT_1 = aktarilanHatRehni.AracTipi;
            sozlesme.AKT_2 = aktarilanHatRehni.AracSasi;
            sozlesme.AKT_3 = aktarilanHatRehni.AracMarka;
            sozlesme.AKT_4 = aktarilanHatRehni.AracBayi;
            sozlesme.YEDI_EMIN_CARI_ID = DetermineCustomerCariID(aktarilanHatRehni.Yeddiemin, null);
            sozlesme.ACIKLAMA = aktarilanHatRehni.Aciklama;

            #region Taraflar

            aktarilanHatRehni.Taraflar.ForEach(taraf => SetRehinTeminatTarafValues(sozlesme, taraf));

            #endregion Taraflar

            return sozlesme;
        }

        public static AV001_TDI_BIL_SOZLESME SetHisseSenediValues(AV001_TDI_BIL_SOZLESME sozlesme, Classes.HisseSenediTeminati aktarilanHisseSenedi)
        {
            sozlesme.DURUM = ParametreClass.MappingTeminatDurum(aktarilanHisseSenedi.Durum);
            sozlesme.REFERANS_NO = aktarilanHisseSenedi.ReferansNo;
            sozlesme.TIP_ID = 3;//Resmi Senet
            sozlesme.ALT_TIP_ID = 175;//Hisse Senedi Rehni
            sozlesme.BEDELI = aktarilanHisseSenedi.Tutar;
            sozlesme.BEDELI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanHisseSenedi.TutarParaBirimi);
            sozlesme.ACIKLAMA = aktarilanHisseSenedi.Aciklama;

            #region Taraflar

            aktarilanHisseSenedi.Taraflar.ForEach(taraf => SetRehinTeminatTarafValues(sozlesme, taraf));

            #endregion Taraflar

            return sozlesme;
        }

        public static AV001_TDI_BIL_SOZLESME SetIpotekValues(AV001_TDI_BIL_SOZLESME ipotek, Classes.Ipotek aktarilanIpotek, AV001_TI_BIL_FOY yeniTakip)
        {
            ipotek.TIP_ID = 3;//Resmi Senet
            ipotek.ALT_TIP_ID = 5;//Gayrimenkul İpoteği
            ipotek.BEDELI = aktarilanIpotek.Bedeli;
            ipotek.BEDELI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanIpotek.BedeliParaBirimi);
            ipotek.DURUM = ParametreClass.MappingTeminatDurum(aktarilanIpotek.Durum);
            ipotek.REFERANS_NO = aktarilanIpotek.ReferanNo;

            if (!string.IsNullOrEmpty(aktarilanIpotek.SicilBolgeNo))
                ipotek.SICIL_BOLGE_NO = Convert.ToInt32(aktarilanIpotek.SicilBolgeNo);

            if (BelgeUtil.Inits._IlGetir_Enter == null)
                BelgeUtil.Inits._IlGetir_Enter = DataRepository.per_TDI_KOD_ILProvider.GetAll();
            var il = BelgeUtil.Inits._IlGetir_Enter.Find(vi => vi.IL == aktarilanIpotek.SicilIl);
            if (il != null)
                ipotek.SICIL_IL_ID = il.ID;

            if (BelgeUtil.Inits._IlceGetirTumu_Enter == null)
                BelgeUtil.Inits._IlceGetirTumu_Enter = DataRepository.per_TDI_KOD_ILCEProvider.GetAll();
            var ilce = BelgeUtil.Inits._IlceGetirTumu_Enter.Find(vi => vi.ILCE == aktarilanIpotek.SicilIlce);
            if (ilce != null)
                ipotek.SICIL_ILCE_ID = ilce.ID;

            ipotek.SICIL_TESCIL_NO = aktarilanIpotek.SicilTescilNo;
            ipotek.SICIL_YEVMIYE_NO = aktarilanIpotek.SicilYevmiyeNo;

            //Derece ve Sıra Bilgileri
            var sozlesmeDerece = ipotek.AV001_TDI_BIL_SOZLESME_DERECECollection.AddNew();
            sozlesmeDerece.DERECESI = aktarilanIpotek.RehinDerece;
            sozlesmeDerece.SIRASI = aktarilanIpotek.RehinSira;
            sozlesmeDerece.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            sozlesmeDerece.ADMIN_KAYIT_MI = false;
            sozlesmeDerece.KAYIT_TARIHI = DateTime.Now;
            sozlesmeDerece.SUBE_ID = AvukatProLib.Kimlik.SubeKodu;

            #region Gayrimenkul

            if (aktarilanIpotek.Gayrimenkuller != null && aktarilanIpotek.Gayrimenkuller.Count > 0)
            {
                TList<AV001_TI_BIL_GAYRIMENKUL> gayrimenkulList = new TList<AV001_TI_BIL_GAYRIMENKUL>();

                foreach (var aktarilanGayrimenkul in aktarilanIpotek.Gayrimenkuller)
                {
                    AV001_TI_BIL_GAYRIMENKUL gayrimenkul = new AV001_TI_BIL_GAYRIMENKUL();
                    gayrimenkul.ACIKLAMA = aktarilanGayrimenkul.Aciklama;
                    gayrimenkul.ADA_NO = aktarilanGayrimenkul.AdaNo;
                    gayrimenkul.ARSA_PAYI = aktarilanGayrimenkul.ArsaPayi;
                    gayrimenkul.BAGIMSIZ_BOLUM_NO = aktarilanGayrimenkul.BagimsizBolumNo;
                    gayrimenkul.BUCAK = aktarilanGayrimenkul.Bucak;
                    gayrimenkul.CILT_NO = aktarilanGayrimenkul.CiltNo;

                    if (BelgeUtil.Inits._IlGetir_Enter == null)
                        BelgeUtil.Inits._IlGetir_Enter = DataRepository.per_TDI_KOD_ILProvider.GetAll();
                    var gayrimenkulIl = BelgeUtil.Inits._IlGetir_Enter.Find(vi => vi.IL == aktarilanGayrimenkul.Il);
                    if (gayrimenkulIl != null)
                        gayrimenkul.IL_ID = gayrimenkulIl.ID;

                    if (BelgeUtil.Inits._IlceGetirTumu_Enter == null)
                        BelgeUtil.Inits._IlceGetirTumu_Enter = DataRepository.per_TDI_KOD_ILCEProvider.GetAll();
                    var gayrimenkulIlce = BelgeUtil.Inits._IlceGetirTumu_Enter.Find(vi => vi.ILCE == aktarilanGayrimenkul.Ilce);
                    if (gayrimenkulIlce != null)
                        gayrimenkul.ILCE_ID = gayrimenkulIlce.ID;

                    gayrimenkul.KAT_NO = aktarilanGayrimenkul.KatNo;
                    gayrimenkul.KOY_ADI = aktarilanGayrimenkul.Koy;
                    gayrimenkul.MAHALLE_ADI = aktarilanGayrimenkul.Mahalle;
                    gayrimenkul.MEVKI_ADI = aktarilanGayrimenkul.Mevki;
                    gayrimenkul.NITELIGI = aktarilanGayrimenkul.Niteligi;
                    gayrimenkul.PAFTA_NO = aktarilanGayrimenkul.PaftaNo;
                    gayrimenkul.PARSEL_NO = aktarilanGayrimenkul.ParselNo;
                    gayrimenkul.SAHIFE_NO = aktarilanGayrimenkul.SahifeNo;
                    gayrimenkul.SERH_ACIKLAMASI = aktarilanGayrimenkul.SerhAciklamasi;
                    gayrimenkul.SOKAK_ADI = aktarilanGayrimenkul.Sokak;
                    gayrimenkul.YEVMIYE_NO = aktarilanGayrimenkul.YevmiyeNo;
                    gayrimenkul.YUZOLCUMU_DM2 = aktarilanGayrimenkul.YuzOlcumDM2;

                    #region Ekspertiz

                    if (aktarilanGayrimenkul.EksertizTarihi != null && aktarilanGayrimenkul.EksertizTarihi > DateTime.MinValue)
                    {
                        var ekspertiz = gayrimenkul.AV001_TI_BIL_KIYMET_TAKDIRICollection.AddNew();

                        ekspertiz.KIYMET_TAKDIRI_TARIHI = aktarilanGayrimenkul.EksertizTarihi;
                        if (!string.IsNullOrEmpty(aktarilanGayrimenkul.EkspertizFirma))
                            ekspertiz.KIYMET_TAKDIRI_YAPAN1_ID = DetermineCustomerCariID(aktarilanGayrimenkul.EkspertizFirma, null);
                        ekspertiz.HACIZLI_MAL_MIKTARI_BIRIM_FIYATI = aktarilanGayrimenkul.EkspertizTutari;
                        ekspertiz.HACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanGayrimenkul.EkspertizTutariParaBirimi);
                        ekspertiz.EKSPERTIZ_KAYDI_MI = true;
                    }

                    #endregion Ekspertiz

                    #region Taraflar

                    aktarilanGayrimenkul.Taraflar.ForEach(taraf => SetGayrimenkulTarafValues(gayrimenkul, taraf));

                    #endregion Taraflar

                    gayrimenkulList.Add(gayrimenkul);
                    var ipotekGayrimenkul = ipotek.NN_SOZLESME_GAYRIMENKULCollection.AddNew();
                    ipotekGayrimenkul.GAYRIMENKUL_IDSource = gayrimenkul;

                    //Yeni bağımsız takip oluştururken NN_ICRA_GAYRIMENKUL tablosuna da kayıt yapılması gerektiğinden eklendi. Klasör oluşturulurken yeniTakip null geleceğinden bu tabloya kayıt eklenmeyecek.
                    if (yeniTakip != null)
                    {
                        var icraGayrimenkul = yeniTakip.NN_ICRA_GAYRIMENKULCollection.AddNew();
                        icraGayrimenkul.GAYRIMENKUL_IDSource = gayrimenkul;
                    }
                }
                if (gayrimenkulList.Count > 0)
                    Entegrasyon.SaveMethods.DeepSaveMethod(gayrimenkulList);

                //DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepSave(gayrimenkulList, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_GAYRIMENKUL_TARAF>), typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>));
            }

            #endregion Gayrimenkul

            return ipotek;
        }

        public static AV001_TDIE_BIL_PROJE SetKlasorCollection(AV001_TDIE_BIL_PROJE yeniKlasor, Classes.DosyaBilgileri Dosya, CustomerData Customer, bool update)
        {
            if (!update)
            {
                yeniKlasor.KOD = GetKlasorKodu();

                if (!string.IsNullOrEmpty(Dosya.Sube))
                {
                    if (BelgeUtil.Inits._ProjeOzelKodGetir == null)
                    {
                        BelgeUtil.Inits._ProjeOzelKodGetir = DataRepository.per_TDIE_KOD_PROJE_OZEL_KODProvider.GetAll();
                    }
                    yeniKlasor.OZEL_KOD1_ID = BelgeUtil.Inits._ProjeOzelKodGetir.Find(vi => vi.OZEL_KOD == Dosya.Sube.TrimEnd(' ')).ID;
                }

                yeniKlasor.PROJE_DURUM_ID = 1; // Aktif
                yeniKlasor.PROJE_TIP_ID = ParametreClass.MappingBirimi(Dosya.Birimi);
                yeniKlasor.DURUM_ID = (int)AvukatProLib.Extras.FoyDurum.FAAL;
                yeniKlasor.KREDI_GRUP_ID = ParametreClass.MappingKrediGrubu(Dosya.KrediGrubu);

                if (BelgeUtil.Inits._per_CariGetir == null)
                    BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();
                yeniKlasor.ADI = BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == Customer.CustomerID).AD;
            }

            #region Kredi Borçlusu

            if (!update)
            {
                var klasorKrediBorclusu = yeniKlasor.AV001_TDIE_BIL_PROJE_KREDI_BORCLUSUCollection.AddNew();
                klasorKrediBorclusu.KREDI_BORCLUSU_CARI_ID = Customer.CustomerID;
            }

            #endregion Kredi Borçlusu

            #region Sorumlu - İzleyen Avukat Bilgileri

            //Mevcut klasöre veriler aktarılmak istenirse; kullanıcının sorumlu avukat bilgilerinin değişmesi seçeneğini seçtiği düşünülerek sorumlu avukat collection'ı yeniden oluşturulur.
            if (update)
            {
                foreach (var item in yeniKlasor.AV001_TDIE_BIL_PROJE_SORUMLUCollection)
                {
                    if (item.YETKILI_MI.HasValue ? item.YETKILI_MI.Value : false) item.CARI_ID = Customer.IzleyenAvukatID;
                    else item.CARI_ID = item.CARI_ID = Customer.SorumluAvukatID;
                }
            }
            else
            {
                var klasorSorumlu = yeniKlasor.AV001_TDIE_BIL_PROJE_SORUMLUCollection.AddNew();
                klasorSorumlu.CARI_ID = Customer.SorumluAvukatID;
                klasorSorumlu.YETKILI_MI = false;

                if (Customer.IzleyenAvukatID != Customer.SorumluAvukatID)
                {
                    var klasorIzleyen = yeniKlasor.AV001_TDIE_BIL_PROJE_SORUMLUCollection.AddNew();
                    klasorIzleyen.CARI_ID = Customer.IzleyenAvukatID;
                    klasorIzleyen.YETKILI_MI = true;
                }
            }

            #endregion Sorumlu - İzleyen Avukat Bilgileri

            #region Nakit Alacaklar - Taraflar - Taraf Faiz

            //Nakit alacaklarda hareket bilgisi gelmeyeceğinden update kontrolünün yapılmasına gerek yok.
            if (!update && Dosya.NakitAlacaklar != null && Dosya.NakitAlacaklar.Count > 0)
            {
                TList<AV001_TI_BIL_ALACAK_NEDEN> nakitAlacakList = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

                foreach (var aktarilanNakitAlacak in Dosya.NakitAlacaklar)
                {
                    AV001_TI_BIL_ALACAK_NEDEN alacak = new AV001_TI_BIL_ALACAK_NEDEN();
                    alacak = SetNakitAlacakValues(alacak, aktarilanNakitAlacak);

                    nakitAlacakList.Add(alacak);
                }

                if (nakitAlacakList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(nakitAlacakList);

                    foreach (var alacak in nakitAlacakList)
                    {
                        var projeAlacak = yeniKlasor.AV001_TDIE_BIL_PROJE_ALACAK_NEDENCollection.AddNew();
                        projeAlacak.ALACAK_NEDEN_ID = alacak.ID;
                    }
                }
            }

            #endregion Nakit Alacaklar - Taraflar - Taraf Faiz

            #region Gayrinakit Alacaklar - Taraflar - Taraf Faiz - Hareketler

            if (Dosya.GayriNakitAlacaklar != null && Dosya.GayriNakitAlacaklar.Count > 0)
            {
                TList<AV001_TI_BIL_ALACAK_NEDEN> gayrinakitAlacakList = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

                if (update)//Mevcut klasöre hareket bilgisi geldi.
                {
                    foreach (var aktarilanGayrinakitAlacak in Dosya.GayriNakitAlacaklar)
                    {
                        var klasorAlacak = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_ALACAK_NEDEN(Customer.KlasorID);

                        bool isUpdate = false;

                        if (klasorAlacak != null)//Klasörde alacak mevcut
                        {
                            isUpdate = UpdateGayrinakitValues(klasorAlacak, aktarilanGayrinakitAlacak, isUpdate, gayrinakitAlacakList, yeniKlasor);

                            if (!isUpdate)//Aktarılan alacak sistemde bulunamadığından yeni kayıt olarak klasöre eklenir.
                            {
                                gayrinakitAlacakList.Add(NewAlacakNedenForKlasor(new AV001_TI_BIL_ALACAK_NEDEN(), aktarilanGayrinakitAlacak, yeniKlasor));
                            }
                        }
                        else//Takipli alacak kontrolü
                        {
                            klasorAlacak = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI(Customer.KlasorID);
                            if (klasorAlacak != null)
                            {
                                isUpdate = UpdateGayrinakitValues(klasorAlacak, aktarilanGayrinakitAlacak, isUpdate, gayrinakitAlacakList, yeniKlasor);

                                if (!isUpdate)//Aktarılan alacak sistemde bulunamadığından yeni kayıt olarak klasöre eklenir.
                                {
                                    gayrinakitAlacakList.Add(NewAlacakNedenForKlasor(new AV001_TI_BIL_ALACAK_NEDEN(), aktarilanGayrinakitAlacak, yeniKlasor));
                                }
                            }
                        }
                    }
                    Entegrasyon.SaveMethods.DeepSaveMethod(gayrinakitAlacakList);
                }
                else
                {
                    List<Classes.GayriNakitAlacak> cekYapragiList = new List<Classes.GayriNakitAlacak>();

                    foreach (var aktarilanGayrinakitAlacak in Dosya.GayriNakitAlacaklar)
                    {
                        if (aktarilanGayrinakitAlacak.AlacakTipi == "ÇEK YAPRAĞI")
                        {
                            cekYapragiList.Add(aktarilanGayrinakitAlacak);
                        }
                        else
                        {
                            gayrinakitAlacakList.Add(NewAlacakNedenForKlasor(new AV001_TI_BIL_ALACAK_NEDEN(), aktarilanGayrinakitAlacak, yeniKlasor));
                        }
                    }

                    #region Çek Yaprakları

                    //Çek yaprakları çek numarasına göre tek tek gelecek. Çek yaprakları sorumluluk miktarları ve para birimlerine göre gruplandırılıp tek bir gayrinakit alacak haline getirilecek. Sistemde varolan kayıtlar bu şekilde tutuluyor.

                    //Group by daha performanslı hale getirilecek.
                    var list = cekYapragiList.GroupBy(vi => vi.CekYapragiILKSorumlulukMiktari.ToString() + vi.CekYapragiILKSorumlulukMiktariParaBirimi).ToList();
                    foreach (var item in list)
                    {
                        Classes.GayriNakitAlacak newAktarilanCekYapragi = new Classes.GayriNakitAlacak();

                        newAktarilanCekYapragi = item.FirstOrDefault();
                        newAktarilanCekYapragi.CekAdedi = item.Sum(vi => vi.CekAdedi);

                        item.ToList().ForEach(cekBilgi =>
                            {
                                newAktarilanCekYapragi.Aciklama += cekBilgi.ReferansNo2 + ",";
                            });

                        gayrinakitAlacakList.Add(NewAlacakNedenForKlasor(new AV001_TI_BIL_ALACAK_NEDEN(), newAktarilanCekYapragi, yeniKlasor));
                    }

                    #endregion Çek Yaprakları
                }

                if (gayrinakitAlacakList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(gayrinakitAlacakList);

                    foreach (var alacak in gayrinakitAlacakList)
                    {
                        var projeAlacak = yeniKlasor.AV001_TDIE_BIL_PROJE_ALACAK_NEDENCollection.AddNew();
                        projeAlacak.ALACAK_NEDEN_ID = alacak.ID;
                    }
                }
            }

            #endregion Gayrinakit Alacaklar - Taraflar - Taraf Faiz - Hareketler

            #region Klasör Tarafları

            if (!update && yeniKlasor.AV001_TDIE_BIL_PROJE_ALACAK_NEDENCollection.Count > 0)
            {
                var alacakNedenList = yeniKlasor.AV001_TDIE_BIL_PROJE_ALACAK_NEDENCollection;
                foreach (var item in alacakNedenList)
                {
                    var alacak = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID(item.ALACAK_NEDEN_ID);
                    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(alacak, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));

                    foreach (var trf in alacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                    {
                        if (yeniKlasor.AV001_TDIE_BIL_PROJE_TARAFCollection.Find(vi => vi.CARI_ID == trf.TARAF_CARI_ID) == null)
                        {
                            AV001_TDIE_BIL_PROJE_TARAF projeTaraf = yeniKlasor.AV001_TDIE_BIL_PROJE_TARAFCollection.AddNew();
                            projeTaraf.CARI_ID = trf.TARAF_CARI_ID;
                        }
                    }
                }
                if (yeniKlasor.AV001_TDIE_BIL_PROJE_TARAFCollection.Find(vi => vi.CARI_ID == 1906) == null)
                {
                    var takipEdenTaraf = yeniKlasor.AV001_TDIE_BIL_PROJE_TARAFCollection.AddNew();
                    takipEdenTaraf.CARI_ID = 1906; //ING BANK A.Ş.
                }
            }

            #endregion Klasör Tarafları

            #region Bonolar / Munzam Senetler - Taraflar

            if (Dosya.Bonolar != null && Dosya.Bonolar.Count > 0)
            {
                TList<AV001_TDI_BIL_KIYMETLI_EVRAK> bonoList = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();

                if (update)
                {
                    foreach (var aktarilanBono in Dosya.Bonolar)
                    {
                        var bonoKlasor = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanBono.ReferansNo);

                        if (bonoKlasor != null)
                        {
                            //bono durum bilgisi update edilcek.
                            bonoKlasor.DURUM = ParametreClass.MappingEvrakDurum(aktarilanBono.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(bonoKlasor);
                        }
                        else
                        {
                            bonoKlasor = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanBono.ReferansNo);

                            if (bonoKlasor != null)
                            {
                                //bono durum bilgisi update edilcek.
                                bonoKlasor.DURUM = ParametreClass.MappingEvrakDurum(aktarilanBono.Durum);
                                Entegrasyon.SaveMethods.DeepSaveMethod(bonoKlasor);
                            }
                            else
                            {
                                bonoList.Add(NewBonoForKlasor(new AV001_TDI_BIL_KIYMETLI_EVRAK(), aktarilanBono, yeniKlasor));
                            }
                        }
                    }
                }
                else
                {
                    foreach (var aktarilanBono in Dosya.Bonolar)
                    {
                        bonoList.Add(NewBonoForKlasor(new AV001_TDI_BIL_KIYMETLI_EVRAK(), aktarilanBono, yeniKlasor));
                    }
                }

                if (bonoList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(bonoList);
                }
            }

            if (Dosya.MunzamSenetler != null && Dosya.MunzamSenetler.Count > 0)
            {
                TList<AV001_TDI_BIL_KIYMETLI_EVRAK> munzamList = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();

                if (update)
                {
                    foreach (var aktarilanMunzam in Dosya.MunzamSenetler)
                    {
                        var bonoKlasor = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanMunzam.ReferansNo);

                        if (bonoKlasor != null)
                        {
                            //bono durum bilgisi update edilcek.
                            bonoKlasor.DURUM = ParametreClass.MappingEvrakDurum(aktarilanMunzam.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(bonoKlasor);
                        }
                        else
                        {
                            bonoKlasor = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanMunzam.ReferansNo);

                            if (bonoKlasor != null)
                            {
                                //bono durum bilgisi update edilcek.
                                bonoKlasor.DURUM = ParametreClass.MappingEvrakDurum(aktarilanMunzam.Durum);
                                Entegrasyon.SaveMethods.DeepSaveMethod(bonoKlasor);
                            }
                            else
                            {
                                munzamList.Add(NewBonoForKlasor(new AV001_TDI_BIL_KIYMETLI_EVRAK(), aktarilanMunzam, yeniKlasor));
                            }
                        }
                    }
                }
                else
                {
                    foreach (var aktarilanMunzam in Dosya.MunzamSenetler)
                    {
                        munzamList.Add(NewBonoForKlasor(new AV001_TDI_BIL_KIYMETLI_EVRAK(), aktarilanMunzam, yeniKlasor));
                    }
                }

                if (munzamList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(munzamList);
                }
            }

            #endregion Bonolar / Munzam Senetler - Taraflar

            #region Çekler - Taraflar

            if (Dosya.Cekler != null && Dosya.Cekler.Count > 0)
            {
                TList<AV001_TDI_BIL_KIYMETLI_EVRAK> cekList = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();

                if (update)
                {
                    foreach (var aktarilanCek in Dosya.Cekler)
                    {
                        var cekKlasor = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanCek.ReferanNo);

                        if (cekKlasor != null)
                        {
                            //çek durum bilgisi update edilcek.
                            cekKlasor.DURUM = ParametreClass.MappingEvrakDurum(aktarilanCek.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(cekKlasor);
                        }
                        else
                        {
                            cekKlasor = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanCek.ReferanNo);
                            if (cekKlasor != null)
                            {
                                //çek durum bilgisi update edilcek.
                                cekKlasor.DURUM = ParametreClass.MappingEvrakDurum(aktarilanCek.Durum);
                                Entegrasyon.SaveMethods.DeepSaveMethod(cekKlasor);
                            }
                            else
                            {
                                cekList.Add(NewCekForKlasor(new AV001_TDI_BIL_KIYMETLI_EVRAK(), aktarilanCek, yeniKlasor));
                            }
                        }
                    }
                }
                else
                {
                    foreach (var aktarilanCek in Dosya.Cekler)
                    {
                        cekList.Add(NewCekForKlasor(new AV001_TDI_BIL_KIYMETLI_EVRAK(), aktarilanCek, yeniKlasor));
                    }
                }
                if (cekList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(cekList);
                }
            }

            #endregion Çekler - Taraflar

            #region İpotekler

            if (Dosya.Ipotekler != null && Dosya.Ipotekler.Count > 0)
            {
                TList<AV001_TDI_BIL_SOZLESME> ipotekList = new TList<AV001_TDI_BIL_SOZLESME>();

                if (update)
                {
                    foreach (var aktarilanIpotek in Dosya.Ipotekler)
                    {
                        var sozlesmeKlasor = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_SOZLESME(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanIpotek.ReferanNo);
                        if (sozlesmeKlasor != null)
                        {
                            //Durum bilgisi update edilecek.
                            sozlesmeKlasor.DURUM = ParametreClass.MappingTeminatDurum(aktarilanIpotek.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(sozlesmeKlasor);
                        }
                        else
                        {
                            ipotekList.Add(NewIpotekForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanIpotek, yeniKlasor));
                        }
                    }
                }
                else
                {
                    foreach (var aktarilanIpotek in Dosya.Ipotekler)
                    {
                        ipotekList.Add(NewIpotekForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanIpotek, yeniKlasor));
                    }
                }
                if (ipotekList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(ipotekList);

                    foreach (var item in ipotekList)
                    {
                        var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
                        projeTeminat.SOZLESME_ID = item.ID;
                    }
                }
            }

            #endregion İpotekler

            #region GUA

            if (Dosya.UcakRehinleri != null && Dosya.UcakRehinleri.Count > 0)
            {
                TList<AV001_TDI_BIL_SOZLESME> ucakList = new TList<AV001_TDI_BIL_SOZLESME>();

                foreach (var aktarilanUcak in Dosya.UcakRehinleri)
                {
                    if (update)
                    {
                        var sozlesmeKlasor = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_SOZLESME(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanUcak.ReferanNo);
                        if (sozlesmeKlasor != null)
                        {
                            //Durum bilgisi update edilecek.
                            sozlesmeKlasor.DURUM = sozlesmeKlasor.DURUM = ParametreClass.MappingTeminatDurum(aktarilanUcak.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(sozlesmeKlasor);
                        }
                        else
                        {
                            ucakList.Add(NewUcakForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanUcak, yeniKlasor));
                        }
                    }
                    else
                    {
                        ucakList.Add(NewUcakForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanUcak, yeniKlasor));
                    }
                }
                if (ucakList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(ucakList);

                    foreach (var item in ucakList)
                    {
                        var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
                        projeTeminat.SOZLESME_ID = item.ID;
                    }
                }
            }

            if (Dosya.GemiRehinleri != null && Dosya.GemiRehinleri.Count > 0)
            {
                TList<AV001_TDI_BIL_SOZLESME> gemiList = new TList<AV001_TDI_BIL_SOZLESME>();

                foreach (var aktarilanGemi in Dosya.GemiRehinleri)
                {
                    if (update)
                    {
                        var sozlesmeKlasor = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_SOZLESME(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanGemi.ReferanNo);
                        if (sozlesmeKlasor != null)
                        {
                            //Durum bilgisi update edilecek.
                            sozlesmeKlasor.DURUM = sozlesmeKlasor.DURUM = ParametreClass.MappingTeminatDurum(aktarilanGemi.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(sozlesmeKlasor);
                        }
                        else
                        {
                            gemiList.Add(NewGemiForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanGemi, yeniKlasor));
                        }
                    }
                    else
                    {
                        gemiList.Add(NewGemiForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanGemi, yeniKlasor));
                    }
                }
                if (gemiList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(gemiList);

                    foreach (var item in gemiList)
                    {
                        var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
                        projeTeminat.SOZLESME_ID = item.ID;
                    }
                }
            }

            if (Dosya.AracRehinleri != null && Dosya.AracRehinleri.Count > 0)
            {
                TList<AV001_TDI_BIL_SOZLESME> aracList = new TList<AV001_TDI_BIL_SOZLESME>();

                foreach (var aktarilanArac in Dosya.AracRehinleri)
                {
                    if (update)
                    {
                        var sozlesmeKlasor = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_SOZLESME(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanArac.ReferanNo);
                        if (sozlesmeKlasor != null)
                        {
                            //Durum bilgisi update edilecek.
                            sozlesmeKlasor.DURUM = ParametreClass.MappingTeminatDurum(aktarilanArac.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(sozlesmeKlasor);
                        }
                        else
                        {
                            aracList.Add(NewAracForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanArac, yeniKlasor));
                        }
                    }
                    else
                    {
                        aracList.Add(NewAracForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanArac, yeniKlasor));
                    }
                }
                if (aracList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(aracList);

                    foreach (var item in aracList)
                    {
                        var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
                        projeTeminat.SOZLESME_ID = item.ID;
                    }
                }
            }

            #endregion GUA

            #region TIR

            if (Dosya.TicariIsletmeRehinleri != null && Dosya.TicariIsletmeRehinleri.Count > 0)
            {
                TList<AV001_TDI_BIL_SOZLESME> TIRList = new TList<AV001_TDI_BIL_SOZLESME>();

                foreach (var aktarilanTIR in Dosya.TicariIsletmeRehinleri)
                {
                    if (update)
                    {
                        var sozlesmeTIR = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_SOZLESME(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanTIR.ReferanNo);
                        if (sozlesmeTIR != null)
                        {
                            //Durum alanı update edilecek.
                            sozlesmeTIR.DURUM = ParametreClass.MappingTeminatDurum(aktarilanTIR.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(sozlesmeTIR);
                        }
                        else
                        {
                            TIRList.Add(NewTIRForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanTIR, yeniKlasor));
                        }
                    }
                    else
                    {
                        TIRList.Add(NewTIRForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanTIR, yeniKlasor));
                    }
                }
                if (TIRList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(TIRList);

                    foreach (var item in TIRList)
                    {
                        var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
                        projeTeminat.SOZLESME_ID = item.ID;
                    }
                }
            }

            #endregion TIR

            #region Teminatlar

            #region Ithalat - İhracat Vesaikileri

            if (Dosya.IthalatVesaikileri != null && Dosya.IthalatVesaikileri.Count > 0)
            {
                TList<AV001_TDI_BIL_SOZLESME> ithalatVesaikileriList = new TList<AV001_TDI_BIL_SOZLESME>();

                foreach (var aktarilanVesaiki in Dosya.IthalatVesaikileri)
                {
                    if (update)
                    {
                        var sozlesmeIthalat = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_SOZLESME(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanVesaiki.ReferansNo);
                        if (sozlesmeIthalat != null)
                        {
                            //Durum alanı update edilecek.
                            sozlesmeIthalat.DURUM = ParametreClass.MappingTeminatDurum(aktarilanVesaiki.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(sozlesmeIthalat);
                        }
                        else
                        {
                            ithalatVesaikileriList.Add(NewVesaikiForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanVesaiki, yeniKlasor));
                        }
                    }
                    else
                    {
                        ithalatVesaikileriList.Add(NewVesaikiForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanVesaiki, yeniKlasor));
                    }
                }
                if (ithalatVesaikileriList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(ithalatVesaikileriList);

                    foreach (var item in ithalatVesaikileriList)
                    {
                        var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
                        projeTeminat.SOZLESME_ID = item.ID;
                    }
                }
            }

            if (Dosya.IhracatVesaikileri != null && Dosya.IhracatVesaikileri.Count > 0)
            {
                TList<AV001_TDI_BIL_SOZLESME> ihracatVesaikileriList = new TList<AV001_TDI_BIL_SOZLESME>();

                foreach (var aktarilanVesaiki in Dosya.IthalatVesaikileri)
                {
                    if (update)
                    {
                        var sozlesmeIthalat = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_SOZLESME(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanVesaiki.ReferansNo);
                        if (sozlesmeIthalat != null)
                        {
                            //Durum alanı update edilecek.
                            sozlesmeIthalat.DURUM = ParametreClass.MappingTeminatDurum(aktarilanVesaiki.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(sozlesmeIthalat);
                        }
                        else
                        {
                            ihracatVesaikileriList.Add(NewVesaikiForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanVesaiki, yeniKlasor));
                        }
                    }
                    else
                    {
                        ihracatVesaikileriList.Add(NewVesaikiForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanVesaiki, yeniKlasor));
                    }
                }
                if (ihracatVesaikileriList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(ihracatVesaikileriList);

                    foreach (var item in ihracatVesaikileriList)
                    {
                        var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
                        projeTeminat.SOZLESME_ID = item.ID;
                    }
                }
            }

            #endregion Ithalat - İhracat Vesaikileri

            #region Alacağın Temlikleri

            if (Dosya.AlacaginTemlikleri != null && Dosya.AlacaginTemlikleri.Count > 0)
            {
                TList<AV001_TDI_BIL_SOZLESME> temlikList = new TList<AV001_TDI_BIL_SOZLESME>();

                foreach (var aktarilanTemlik in Dosya.AlacaginTemlikleri)
                {
                    if (update)
                    {
                        var sozlesmeTemlik = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_SOZLESME(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanTemlik.ReferansNo);
                        if (sozlesmeTemlik != null)
                        {
                            //Durum alanı update edilecek.
                            sozlesmeTemlik.DURUM = ParametreClass.MappingTeminatDurum(aktarilanTemlik.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(sozlesmeTemlik);
                        }
                        else
                        {
                            temlikList.Add(NewAlacaginTemlikiForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanTemlik, yeniKlasor));
                        }
                    }
                    else
                    {
                        temlikList.Add(NewAlacaginTemlikiForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanTemlik, yeniKlasor));
                    }
                }
                if (temlikList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(temlikList);

                    foreach (var item in temlikList)
                    {
                        var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
                        projeTeminat.SOZLESME_ID = item.ID;
                    }
                }
            }

            #endregion Alacağın Temlikleri

            #region Hisse Senedi Teminatları

            if (Dosya.HisseSenediTeminatlari != null && Dosya.HisseSenediTeminatlari.Count > 0)
            {
                TList<AV001_TDI_BIL_SOZLESME> hisseSenediList = new TList<AV001_TDI_BIL_SOZLESME>();

                foreach (var aktarilanHisseSenedi in Dosya.HisseSenediTeminatlari)
                {
                    if (update)
                    {
                        var sozlesmeHisseSenedi = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_SOZLESME(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanHisseSenedi.ReferansNo);
                        if (sozlesmeHisseSenedi != null)
                        {
                            //Durum alanı update edilecek.
                            sozlesmeHisseSenedi.DURUM = ParametreClass.MappingTeminatDurum(aktarilanHisseSenedi.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(sozlesmeHisseSenedi);
                        }
                        else
                        {
                            hisseSenediList.Add(NewHisseSenedi(new AV001_TDI_BIL_SOZLESME(), aktarilanHisseSenedi, yeniKlasor));
                        }
                    }
                    else
                    {
                        hisseSenediList.Add(NewHisseSenedi(new AV001_TDI_BIL_SOZLESME(), aktarilanHisseSenedi, yeniKlasor));
                    }
                }
                if (hisseSenediList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(hisseSenediList);

                    foreach (var item in hisseSenediList)
                    {
                        var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
                        projeTeminat.SOZLESME_ID = item.ID;
                    }
                }
            }

            #endregion Hisse Senedi Teminatları

            #region Firma Garantileri

            if (Dosya.FirmaGarantileri != null && Dosya.FirmaGarantileri.Count > 0)
            {
                TList<AV001_TDI_BIL_SOZLESME> firmaGarantiList = new TList<AV001_TDI_BIL_SOZLESME>();

                foreach (var aktarilanFirmaGaranti in Dosya.FirmaGarantileri)
                {
                    if (update)
                    {
                        var sozlesmeFirmaGaranti = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_SOZLESME(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanFirmaGaranti.ReferansNo);
                        if (sozlesmeFirmaGaranti != null)
                        {
                            //Durum alanı update edilecek.
                            sozlesmeFirmaGaranti.DURUM = ParametreClass.MappingTeminatDurum(aktarilanFirmaGaranti.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(sozlesmeFirmaGaranti);
                        }
                        else
                        {
                            firmaGarantiList.Add(NewFirmaGarantiForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanFirmaGaranti, yeniKlasor));
                        }
                    }
                    else
                    {
                        firmaGarantiList.Add(NewFirmaGarantiForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanFirmaGaranti, yeniKlasor));
                    }
                }
                if (firmaGarantiList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(firmaGarantiList);

                    foreach (var item in firmaGarantiList)
                    {
                        var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
                        projeTeminat.SOZLESME_ID = item.ID;
                    }
                }
            }

            #endregion Firma Garantileri

            #region Menkul Rehinleri

            if (Dosya.MenkulRehinleri != null && Dosya.MenkulRehinleri.Count > 0)
            {
                TList<AV001_TDI_BIL_SOZLESME> menkulRehinleriList = new TList<AV001_TDI_BIL_SOZLESME>();

                foreach (var aktarilanMenkulRehni in Dosya.MenkulRehinleri)
                {
                    if (update)
                    {
                        var sozlesmemenkulRehni = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_SOZLESME(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanMenkulRehni.ReferanNo);
                        if (sozlesmemenkulRehni != null)
                        {
                            //Durum alanı update edilecek.
                            sozlesmemenkulRehni.DURUM = ParametreClass.MappingTeminatDurum(aktarilanMenkulRehni.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(sozlesmemenkulRehni);
                        }
                        else
                        {
                            menkulRehinleriList.Add(NewMenkulRehinForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanMenkulRehni, yeniKlasor));
                        }
                    }
                    else
                    {
                        menkulRehinleriList.Add(NewMenkulRehinForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanMenkulRehni, yeniKlasor));
                    }
                }
                if (menkulRehinleriList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(menkulRehinleriList);

                    foreach (var item in menkulRehinleriList)
                    {
                        var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
                        projeTeminat.SOZLESME_ID = item.ID;
                    }
                }
            }

            #endregion Menkul Rehinleri

            #region Emtia Rehinleri

            if (Dosya.EmtiaRehinleri != null && Dosya.EmtiaRehinleri.Count > 0)
            {
                TList<AV001_TDI_BIL_SOZLESME> emtiaRehinleriList = new TList<AV001_TDI_BIL_SOZLESME>();

                foreach (var aktarilanEmtiaRehni in Dosya.EmtiaRehinleri)
                {
                    if (update)
                    {
                        var sozlesmeEmtiaRehni = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_SOZLESME(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanEmtiaRehni.ReferanNo);
                        if (sozlesmeEmtiaRehni != null)
                        {
                            //Durum alanı update edilecek.
                            sozlesmeEmtiaRehni.DURUM = ParametreClass.MappingTeminatDurum(aktarilanEmtiaRehni.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(sozlesmeEmtiaRehni);
                        }
                        else
                        {
                            emtiaRehinleriList.Add(NewEmtiaRehniForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanEmtiaRehni, yeniKlasor));
                        }
                    }
                    else
                    {
                        emtiaRehinleriList.Add(NewEmtiaRehniForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanEmtiaRehni, yeniKlasor));
                    }
                }
                if (emtiaRehinleriList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(emtiaRehinleriList);

                    foreach (var item in emtiaRehinleriList)
                    {
                        var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
                        projeTeminat.SOZLESME_ID = item.ID;
                    }
                }
            }

            #endregion Emtia Rehinleri

            #region Varant Rehinleri

            if (Dosya.VarantRehinleri != null && Dosya.VarantRehinleri.Count > 0)
            {
                TList<AV001_TDI_BIL_SOZLESME> varantRehinleriList = new TList<AV001_TDI_BIL_SOZLESME>();

                foreach (var aktarilanVarantRehni in Dosya.VarantRehinleri)
                {
                    if (update)
                    {
                        var sozlesmeVarantRehni = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_SOZLESME(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanVarantRehni.ReferanNo);
                        if (sozlesmeVarantRehni != null)
                        {
                            //Durum alanı update edilecek.
                            sozlesmeVarantRehni.DURUM = ParametreClass.MappingTeminatDurum(aktarilanVarantRehni.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(sozlesmeVarantRehni);
                        }
                        else
                        {
                            varantRehinleriList.Add(NewVaranRehniForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanVarantRehni, yeniKlasor));
                        }
                    }
                    else
                    {
                        varantRehinleriList.Add(NewVaranRehniForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanVarantRehni, yeniKlasor));
                    }
                }
                if (varantRehinleriList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(varantRehinleriList);

                    foreach (var item in varantRehinleriList)
                    {
                        var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
                        projeTeminat.SOZLESME_ID = item.ID;
                    }
                }
            }

            #endregion Varant Rehinleri

            #region Altın Rehinleri

            if (Dosya.AltinRehinleri != null && Dosya.AltinRehinleri.Count > 0)
            {
                TList<AV001_TDI_BIL_SOZLESME> altinRehinleriList = new TList<AV001_TDI_BIL_SOZLESME>();

                foreach (var aktarilanAltinRehni in Dosya.AltinRehinleri)
                {
                    if (update)
                    {
                        var sozlesmeAltinRehni = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_SOZLESME(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanAltinRehni.ReferanNo);
                        if (sozlesmeAltinRehni != null)
                        {
                            //Durum alanı update edilecek.
                            sozlesmeAltinRehni.DURUM = ParametreClass.MappingTeminatDurum(aktarilanAltinRehni.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(sozlesmeAltinRehni);
                        }
                        else
                        {
                            altinRehinleriList.Add(NewAltinRehniForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanAltinRehni, yeniKlasor));
                        }
                    }
                    else
                    {
                        altinRehinleriList.Add(NewAltinRehniForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanAltinRehni, yeniKlasor));
                    }
                }
                if (altinRehinleriList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(altinRehinleriList);

                    foreach (var item in altinRehinleriList)
                    {
                        var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
                        projeTeminat.SOZLESME_ID = item.ID;
                    }
                }
            }

            #endregion Altın Rehinleri

            #region Hat Rehinleri

            if (Dosya.HatRehinleri != null && Dosya.HatRehinleri.Count > 0)
            {
                TList<AV001_TDI_BIL_SOZLESME> hatRehinleriList = new TList<AV001_TDI_BIL_SOZLESME>();

                foreach (var aktarilanAltinRehni in Dosya.HatRehinleri)
                {
                    if (update)
                    {
                        var sozlesmeHatRehni = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_SOZLESME(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanAltinRehni.ReferanNo);
                        if (sozlesmeHatRehni != null)
                        {
                            //Durum alanı update edilecek.
                            sozlesmeHatRehni.DURUM = ParametreClass.MappingTeminatDurum(aktarilanAltinRehni.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(sozlesmeHatRehni);
                        }
                        else
                        {
                            hatRehinleriList.Add(NewHatRehniForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanAltinRehni, yeniKlasor));
                        }
                    }
                    else
                    {
                        hatRehinleriList.Add(NewHatRehniForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanAltinRehni, yeniKlasor));
                    }
                }
                if (hatRehinleriList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(hatRehinleriList);

                    foreach (var item in hatRehinleriList)
                    {
                        var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
                        projeTeminat.SOZLESME_ID = item.ID;
                    }
                }
            }

            #endregion Hat Rehinleri

            #region Makbuz Senedi Rehinleri

            if (Dosya.MakbuzSenediRehinleri != null && Dosya.MakbuzSenediRehinleri.Count > 0)
            {
                TList<AV001_TDI_BIL_SOZLESME> makbuzSenediRehinleriList = new TList<AV001_TDI_BIL_SOZLESME>();

                foreach (var aktarilanMakbuzSenediRehni in Dosya.MakbuzSenediRehinleri)
                {
                    if (update)
                    {
                        var sozlesmeMakbuzSenediRehni = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_SOZLESME(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanMakbuzSenediRehni.ReferanNo);
                        if (sozlesmeMakbuzSenediRehni != null)
                        {
                            //Durum alanı update edilecek.
                            sozlesmeMakbuzSenediRehni.DURUM = ParametreClass.MappingTeminatDurum(aktarilanMakbuzSenediRehni.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(sozlesmeMakbuzSenediRehni);
                        }
                        else
                        {
                            makbuzSenediRehinleriList.Add(NewMakbuzSenediRehniForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanMakbuzSenediRehni, yeniKlasor));
                        }
                    }
                    else
                    {
                        makbuzSenediRehinleriList.Add(NewMakbuzSenediRehniForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanMakbuzSenediRehni, yeniKlasor));
                    }
                }
                if (makbuzSenediRehinleriList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(makbuzSenediRehinleriList);

                    foreach (var item in makbuzSenediRehinleriList)
                    {
                        var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
                        projeTeminat.SOZLESME_ID = item.ID;
                    }
                }
            }

            #endregion Makbuz Senedi Rehinleri

            #region Diğer Rehinleri

            if (Dosya.DigerRehinler != null && Dosya.DigerRehinler.Count > 0)
            {
                TList<AV001_TDI_BIL_SOZLESME> digerRehinleriList = new TList<AV001_TDI_BIL_SOZLESME>();

                foreach (var aktarilanDigerRehni in Dosya.DigerRehinler)
                {
                    if (update)
                    {
                        var sozlesmeDigerRehin = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_SOZLESME(Customer.KlasorID).Find(vi => vi.REFERANS_NO == aktarilanDigerRehni.ReferanNo);
                        if (sozlesmeDigerRehin != null)
                        {
                            //Durum alanı update edilecek.
                            sozlesmeDigerRehin.DURUM = ParametreClass.MappingTeminatDurum(aktarilanDigerRehni.Durum);
                            Entegrasyon.SaveMethods.DeepSaveMethod(sozlesmeDigerRehin);
                        }
                        else
                        {
                            digerRehinleriList.Add(NewDigerRehinForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanDigerRehni, yeniKlasor));
                        }
                    }
                    else
                    {
                        digerRehinleriList.Add(NewDigerRehinForKlasor(new AV001_TDI_BIL_SOZLESME(), aktarilanDigerRehni, yeniKlasor));
                    }
                }
                if (digerRehinleriList.Count > 0)
                {
                    Entegrasyon.SaveMethods.DeepSaveMethod(digerRehinleriList);

                    foreach (var item in digerRehinleriList)
                    {
                        var projeTeminat = yeniKlasor.AV001_TDIE_BIL_PROJE_TEMINATCollection.AddNew();
                        projeTeminat.SOZLESME_ID = item.ID;
                    }
                }
            }

            #endregion Diğer Rehinleri

            #endregion Teminatlar

            #region Sözleşmeler

            if (!update && Dosya.Sozlesmeler != null && Dosya.Sozlesmeler.Count > 0)
            {
                TList<AV001_TDI_BIL_SOZLESME> sozlesmeList = new TList<AV001_TDI_BIL_SOZLESME>();

                foreach (var aktarilanSozlesme in Dosya.Sozlesmeler)
                {
                    AV001_TDI_BIL_SOZLESME sozlesme = new AV001_TDI_BIL_SOZLESME();
                    sozlesme = SetSozlesmeValues(sozlesme, aktarilanSozlesme);

                    sozlesmeList.Add(sozlesme);

                    var projeSozlesme = yeniKlasor.AV001_TDIE_BIL_PROJE_SOZLESMECollection.AddNew();
                    projeSozlesme.SOZLESME_IDSource = sozlesme;
                }
                if (sozlesmeList.Count > 0)
                    Entegrasyon.SaveMethods.DeepSaveMethod(sozlesmeList);
            }

            #endregion Sözleşmeler

            if (!update)
            {
                if (Dosya.Cariler != null)
                {
                    TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                    try
                    {
                        tran.BeginTransaction();

                        SettingsCari(Dosya.Cariler, tran);

                        if (tran.IsOpen)
                            tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (tran.IsOpen) tran.Rollback();
                        if (ex.Message.ToLower().Contains("uKOD"))
                        {
                            SettingsCari(Dosya.Cariler, tran);
                        }
                        else
                            MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", ex);
                    }
                }
            }

            return yeniKlasor;
        }

        public static AV001_TDI_BIL_SOZLESME SetMakbuzSenediRehniValues(AV001_TDI_BIL_SOZLESME sozlesme, Classes.MakbuzSenediRehni aktarilanMakbuzSenediRehni)
        {
            sozlesme.DURUM = ParametreClass.MappingTeminatDurum(aktarilanMakbuzSenediRehni.Durum);
            sozlesme.REFERANS_NO = aktarilanMakbuzSenediRehni.ReferanNo;
            sozlesme.BEDELI = aktarilanMakbuzSenediRehni.Tutari;
            sozlesme.BEDELI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanMakbuzSenediRehni.TutariParaBirimi);

            //sozlesme.REHIN_CINS_ID = aktarilanMakbuzSenediRehni.RehinTuru; MAP
            sozlesme.IMZA_TARIHI = aktarilanMakbuzSenediRehni.RehinTarihi;
            sozlesme.YEDI_EMIN_CARI_ID = DetermineCustomerCariID(aktarilanMakbuzSenediRehni.Yeddiemin, null);
            sozlesme.ACIKLAMA = aktarilanMakbuzSenediRehni.Aciklama;

            #region Taraflar

            aktarilanMakbuzSenediRehni.Taraflar.ForEach(taraf => SetRehinTeminatTarafValues(sozlesme, taraf));

            #endregion Taraflar

            return sozlesme;
        }

        public static AV001_TDI_BIL_SOZLESME SetMenkulRehniValues(AV001_TDI_BIL_SOZLESME sozlesme, Classes.MenkulRehni aktarilanMenkulRehni)
        {
            sozlesme.DURUM = ParametreClass.MappingTeminatDurum(aktarilanMenkulRehni.Durum);
            sozlesme.REFERANS_NO = aktarilanMenkulRehni.ReferanNo;
            sozlesme.TIP_ID = 3;//Resmi Senet
            sozlesme.ALT_TIP_ID = 10;//Menkul Mal Rehni
            sozlesme.BEDELI = aktarilanMenkulRehni.Tutari;
            sozlesme.BEDELI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanMenkulRehni.TutariParaBirimi);

            //sozlesme.REHIN_CINS_ID = aktarilanMenkulRehni.RehinTuru; MAP
            sozlesme.IMZA_TARIHI = aktarilanMenkulRehni.RehinTarihi;
            sozlesme.YEDI_EMIN_CARI_ID = DetermineCustomerCariID(aktarilanMenkulRehni.Yeddiemin, null);
            sozlesme.ACIKLAMA = aktarilanMenkulRehni.Aciklama;

            #region Taraflar

            aktarilanMenkulRehni.Taraflar.ForEach(taraf => SetRehinTeminatTarafValues(sozlesme, taraf));

            #endregion Taraflar

            return sozlesme;
        }

        public static AV001_TI_BIL_ALACAK_NEDEN SetNakitAlacakValues(AV001_TI_BIL_ALACAK_NEDEN nakitAlacak, Classes.NakitAlacak aktarilanNakitAlacak)
        {
            nakitAlacak.AKTI_FAIZ_ORANI = aktarilanNakitAlacak.AkdiFaizOrani;

            nakitAlacak.ALACAK_NEDEN_KOD_ID = ParametreClass.MappingAlacakNedeni(aktarilanNakitAlacak.AlacakTipi);

            if (BelgeUtil.Inits._TI_KOD_AlacakNedeniDoldur == null)
                BelgeUtil.Inits._TI_KOD_AlacakNedeniDoldur = DataRepository.per_TI_KOD_ALACAK_NEDENProvider.GetAll();
            var alacakNeden = BelgeUtil.Inits._TI_KOD_AlacakNedeniDoldur.Find(vi => vi.ID == nakitAlacak.ALACAK_NEDEN_KOD_ID.Value);

            //Bazı durumlarda aşağıdaki property filtrelenip geldiğinden alacak nedeni bulunamıyordu. Bu sorunun önüne geçmek için aşağıdaki kontrol eklendi.
            if (alacakNeden == null) BelgeUtil.Inits._TI_KOD_AlacakNedeniDoldur = DataRepository.per_TI_KOD_ALACAK_NEDENProvider.GetAll();
            if (alacakNeden != null)
                nakitAlacak.DIGER_ALACAK_NEDENI = alacakNeden.ALACAK_NEDENI;

            nakitAlacak.BSMV_HESAPLANSIN = aktarilanNakitAlacak.BSMVHesaplansin;

            //Faiz Tipi her zaman temerrüt gelecek.
            nakitAlacak.TO_ALACAK_FAIZ_TIP_ID = nakitAlacak.ALACAK_FAIZ_TIP_ID = 9;// aktarilanNakitAlacak.FaizTipi;
            nakitAlacak.REFERANS_NO = aktarilanNakitAlacak.ReferansNo;
            nakitAlacak.REFERANS_NO2 = aktarilanNakitAlacak.ReferansNo2;

            if (aktarilanNakitAlacak.TutariParaBirimi == "X")
            {
                using (frmAlacakKontrol frm = new frmAlacakKontrol())
                {
                    frm.ShowDialog(aktarilanNakitAlacak);
                    nakitAlacak.TUTARI = nakitAlacak.ISLEME_KONAN_TUTAR = frm.KontrolItem.Tutar;
                    nakitAlacak.TUTAR_DOVIZ_ID = nakitAlacak.ISLEME_KONAN_TUTAR_DOVIZ_ID = frm.KontrolItem.TutarParaBirimi;
                    nakitAlacak.VADE_TARIHI = nakitAlacak.DUZENLENME_TARIHI = nakitAlacak.FAIZ_BASLANGIC_TARIHI = frm.KontrolItem.VadeTarihi;
                    nakitAlacak.TO_UYGULANACAK_FAIZ_ORANI = nakitAlacak.UYGULANACAK_FAIZ_ORANI = frm.KontrolItem.FaizOrani;
                }
            }
            else
            {
                nakitAlacak.TUTARI = nakitAlacak.ISLEME_KONAN_TUTAR = aktarilanNakitAlacak.Tutari;
                nakitAlacak.TUTAR_DOVIZ_ID = nakitAlacak.ISLEME_KONAN_TUTAR_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanNakitAlacak.TutariParaBirimi);
                nakitAlacak.UYGULANACAK_FAIZ_ORANI = nakitAlacak.TO_UYGULANACAK_FAIZ_ORANI = aktarilanNakitAlacak.FaizOrani;
                if (aktarilanNakitAlacak.VadeTarihi > DateTime.MinValue)
                    nakitAlacak.VADE_TARIHI = nakitAlacak.DUZENLENME_TARIHI = nakitAlacak.FAIZ_BASLANGIC_TARIHI = aktarilanNakitAlacak.VadeTarihi;
            }

            if (nakitAlacak.TUTAR_DOVIZ_ID.HasValue)
            {
                if (nakitAlacak.TUTAR_DOVIZ_ID != 1)
                    nakitAlacak.HESAPLAMA_MODU = (int)AvukatProLib.Extras.IcraDovizIslemTipi.Fiili_Ödeme_Tarihinde_TL;
                else
                    nakitAlacak.HESAPLAMA_MODU = (int)AvukatProLib.Extras.IcraDovizIslemTipi.Vade_Tarihinde_TL;
            }

            #region Taraflar

            aktarilanNakitAlacak.Taraflari.ForEach(item => SetAlacakTarafValues(nakitAlacak, item, true));
            var alacakliTaraf = nakitAlacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.AddNew();
            alacakliTaraf.TARAF_CARI_ID = 1906;//INGBANK A.Ş.
            alacakliTaraf.TARAF_SIFAT_ID = 1;

            #endregion Taraflar

            return nakitAlacak;
        }

        public static AV001_TI_BIL_ALACAK_NEDEN SetNakitAlacakValuesKrediKarti(AV001_TI_BIL_ALACAK_NEDEN nakitAlacak, Classes.NakitAlacak aktarilanNakitAlacak)
        {
            nakitAlacak.AKTI_FAIZ_ORANI = aktarilanNakitAlacak.AkdiFaizOrani;

            //Kredi kartlarında gelen data bu şekilde olduğundan, veritabanına gitmesini engellemek için aşağıdaki şekilde yapıldı.
            nakitAlacak.ALACAK_NEDEN_KOD_ID = 49;//BİREYSEL KREDİ KARTI
            nakitAlacak.DIGER_ALACAK_NEDENI = "BİREYSEL KREDİ KARTI";

            nakitAlacak.BSMV_HESAPLANSIN = aktarilanNakitAlacak.BSMVHesaplansin;

            //Faiz Tipi her zaman temerrüt gelecek.
            nakitAlacak.TO_ALACAK_FAIZ_TIP_ID = nakitAlacak.ALACAK_FAIZ_TIP_ID = 9;// aktarilanNakitAlacak.FaizTipi;
            nakitAlacak.REFERANS_NO = aktarilanNakitAlacak.ReferansNo;
            nakitAlacak.REFERANS_NO2 = aktarilanNakitAlacak.ReferansNo2;

            nakitAlacak.TUTARI = nakitAlacak.ISLEME_KONAN_TUTAR = aktarilanNakitAlacak.Tutari;
            nakitAlacak.TUTAR_DOVIZ_ID = nakitAlacak.ISLEME_KONAN_TUTAR_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanNakitAlacak.TutariParaBirimi);
            nakitAlacak.UYGULANACAK_FAIZ_ORANI = nakitAlacak.TO_UYGULANACAK_FAIZ_ORANI = aktarilanNakitAlacak.FaizOrani;
            if (aktarilanNakitAlacak.VadeTarihi > DateTime.MinValue)
                nakitAlacak.VADE_TARIHI = nakitAlacak.DUZENLENME_TARIHI = nakitAlacak.FAIZ_BASLANGIC_TARIHI = aktarilanNakitAlacak.VadeTarihi;

            nakitAlacak.HESAPLAMA_MODU = (int)AvukatProLib.Extras.IcraDovizIslemTipi.Vade_Tarihinde_TL;

            #region Taraflar

            aktarilanNakitAlacak.Taraflari.ForEach(item => SetAlacakTarafValues(nakitAlacak, item, true));
            var alacakliTaraf = nakitAlacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.AddNew();
            alacakliTaraf.TARAF_CARI_ID = 1906;//INGBANK A.Ş.
            alacakliTaraf.TARAF_SIFAT_ID = 1;

            #endregion Taraflar

            return nakitAlacak;
        }

        public static AV001_TDI_BIL_SOZLESME_TARAF SetRehinTeminatTarafValues(AV001_TDI_BIL_SOZLESME sozlesme, Classes.Taraf aktarilanTaraf)
        {
            var taraf = sozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection.AddNew();
            taraf.CARI_ID = DetermineCustomerCariID(aktarilanTaraf.Musteri, aktarilanTaraf.MusteriNo);
            taraf.TARAF_SIFAT_ID = ParametreClass.MappingTarafSifat(aktarilanTaraf.TarafSifat);

            return taraf;
        }

        public static AV001_TDI_BIL_SOZLESME_TARAF SetSozlesmeTarafValues(AV001_TDI_BIL_SOZLESME sozlesme, Classes.SozlesmeTaraf aktarilanTaraf)
        {
            var taraf = sozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection.AddNew();
            taraf.CARI_ID = DetermineCustomerCariID(aktarilanTaraf.Musteri, aktarilanTaraf.MusteriNo);
            taraf.TARAF_SIFAT_ID = 6;//SÖZLEŞME TARAFI
            taraf.SORUMLULUK_MIKTAR = aktarilanTaraf.SorumluOlunanMiktar;
            taraf.SORUMLULUK_MIKTAR_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanTaraf.SorumluOlunanMiktarParaBirimi);

            return taraf;
        }

        public static AV001_TDI_BIL_SOZLESME SetSozlesmeValues(AV001_TDI_BIL_SOZLESME sozlesme, Classes.Sozlesmeler aktarilanSozlesme)
        {
            ParametreClass.MappingSozlesmeTipAltTip(aktarilanSozlesme.Tip, sozlesme);
            sozlesme.BEDELI = aktarilanSozlesme.Bedeli;
            sozlesme.BEDELI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanSozlesme.BedeliParaBirimi);
            sozlesme.IMZA_TARIHI = aktarilanSozlesme.ImzaTarihi;

            #region Taraflar

            aktarilanSozlesme.Taraflar.ForEach(taraf => SetSozlesmeTarafValues(sozlesme, taraf));
            var sozlesmeYapanTaraf = sozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection.AddNew();
            sozlesmeYapanTaraf.CARI_ID = 1906;//INGBANK A.Ş.
            sozlesmeYapanTaraf.TARAF_SIFAT_ID = 29;//SÖZLEŞME YAPAN

            #endregion Taraflar

            return sozlesme;
        }

        public static AV001_TI_BIL_FOY SetTakipCollection(AV001_TI_BIL_FOY yeniTakip, Classes.DosyaBilgileri Dosya, CustomerData Customer, List<int> TakibeAlinanBilesenler)
        {
            yeniTakip.TAKIBIN_AVUKATA_INTIKAL_TARIHI = DateTime.Now;
            yeniTakip.SEGMENT_ID = ParametreClass.MappingBirimi(Dosya.Birimi);
            yeniTakip.KREDI_GRUP_ID = ParametreClass.MappingKrediGrubu(Dosya.KrediGrubu);

            if (yeniTakip.FORM_TIP_ID.HasValue)
            {
                yeniTakip.TAKIP_YOLU_ID = DataRepository.TI_KOD_FORM_TIPProvider.GetByID(yeniTakip.FORM_TIP_ID.Value).TAKIP_YOLU_ID;

                if (BelgeUtil.Inits._FormTipiGetir == null)
                    BelgeUtil.Inits._FormTipiGetir = BelgeUtil.Inits.context.per_TI_KOD_FORM_TIPs.ToList();

                var formOrnekNo = DataRepository.TI_KOD_FORM_TIPProvider.GetByID(yeniTakip.FORM_TIP_ID.Value).FORM_ORNEK_NO;

                if (BelgeUtil.Inits._TakipKonusuGetir_Enter == null)
                    BelgeUtil.Inits._TakipKonusuGetir_Enter = DataRepository.per_TI_KOD_TAKIP_TALEPProvider.GetAll();

                yeniTakip.TAKIP_TALEP_ID = BelgeUtil.Inits._TakipKonusuGetir_Enter.Find(item => item.FORM_TIPI == Convert.ToByte(formOrnekNo)).ID;
            }

            #region Kredi Borçlusu

            var takipKrediBorclusu = yeniTakip.AV001_TI_BIL_FOY_KREDI_BORCLUSUCollection.AddNew();
            takipKrediBorclusu.KREDI_BORCLUSU_CARI_ID = Customer.CustomerID;

            #endregion Kredi Borçlusu

            #region Sorumlu - İzleyen Avukat Bilgileri

            var takipSorumlu = yeniTakip.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.AddNew();
            takipSorumlu.SORUMLU_AVUKAT_CARI_ID = Customer.SorumluAvukatID;
            takipSorumlu.YETKILI_MI = false;

            if (Customer.IzleyenAvukatID != Customer.SorumluAvukatID)
            {
                var takipIzleyen = yeniTakip.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.AddNew();
                takipIzleyen.SORUMLU_AVUKAT_CARI_ID = Customer.IzleyenAvukatID;
                takipIzleyen.YETKILI_MI = true;
            }

            #endregion Sorumlu - İzleyen Avukat Bilgileri

            #region Nakit Alacaklar - Taraflar - Taraf Faiz

            if (Dosya.NakitAlacaklar != null && Dosya.NakitAlacaklar.Count > 0)
            {
                foreach (var aktarilanNakitAlacak in Dosya.NakitAlacaklar)
                {
                    AV001_TI_BIL_ALACAK_NEDEN alacak = yeniTakip.AV001_TI_BIL_ALACAK_NEDENCollection.AddNew();
                    alacak = Methods.SetNakitAlacakValuesKrediKarti(alacak, aktarilanNakitAlacak);
                }
            }

            #endregion Nakit Alacaklar - Taraflar - Taraf Faiz

            #region Takip Tarafları

            //Alacak nedenlerinin tarafları aynı olduğundan ilk alacak nedeni alınıyor ve onun tarafları takip edilen olarak takibe ekleniyor. ING BANK A.Ş.'de takip eden olarak takip taraflarına ekleniyor.

            foreach (var aNeden in yeniTakip.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                foreach (var item in aNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                {
                    if (yeniTakip.AV001_TI_BIL_FOY_TARAFCollection.Find(vi => vi.CARI_ID == item.TARAF_CARI_ID) != null || item.TARAF_SIFAT_ID == 1) continue;
                    AV001_TI_BIL_FOY_TARAF takipTaraf = yeniTakip.AV001_TI_BIL_FOY_TARAFCollection.AddNew();
                    takipTaraf.CARI_ID = item.TARAF_CARI_ID;
                    takipTaraf.TARAF_KODU = 3;//Karşı Taraf
                    takipTaraf.TARAF_SIFAT_ID = 2;//Borçlu
                    takipTaraf.TAKIP_EDEN_MI = false;
                }
            }

            var takipEdenTaraf = yeniTakip.AV001_TI_BIL_FOY_TARAFCollection.AddNew();
            takipEdenTaraf.CARI_ID = 1906; //ING BANK A.Ş.
            takipEdenTaraf.TARAF_KODU = 1;//Müvekkil
            takipEdenTaraf.TARAF_SIFAT_ID = 1;//Alacaklı
            takipEdenTaraf.TAKIP_EDEN_MI = true;

            #endregion Takip Tarafları

            if (Dosya.Cariler != null)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                try
                {
                    tran.BeginTransaction();

                    SettingsCari(Dosya.Cariler, tran);

                    if (tran.IsOpen)
                        tran.Commit();
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen) tran.Rollback();
                    if (ex.Message.Contains("uKOD"))
                    {
                        SettingsCari(Dosya.Cariler, tran);
                    }
                    else
                        MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", ex);
                }
            }

            return yeniTakip;
        }

        public static AV001_TDI_BIL_SOZLESME SetTIRValues(AV001_TDI_BIL_SOZLESME sozlesme, Classes.TicariIsletmeRehni aktarilanTIR)
        {
            sozlesme.DURUM = ParametreClass.MappingTeminatDurum(aktarilanTIR.Durum);
            sozlesme.REFERANS_NO = aktarilanTIR.ReferanNo;

            if (BelgeUtil.Inits._AdliBirimNoGetir != null)
                BelgeUtil.Inits._AdliBirimNoGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_NOProvider.GetAll();

            var adliBirimNo = BelgeUtil.Inits._AdliBirimNoGetir.Find(vi => vi.NO == aktarilanTIR.AdliBirimNo);
            if (adliBirimNo != null)
                sozlesme.ADLI_BIRIM_NO_ID = adliBirimNo.ID;

            if (BelgeUtil.Inits._AdliBirimAdliyeGetir == null)
                BelgeUtil.Inits._AdliBirimAdliyeGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetAll();
            var adliye = BelgeUtil.Inits._AdliBirimAdliyeGetir.Find(vi => vi.ADLIYE == aktarilanTIR.Adliye);
            if (adliye != null)
                sozlesme.ADLI_BIRIM_ADLIYE_ID = adliye.ID;

            sozlesme.BEDELI = aktarilanTIR.Bedeli;
            sozlesme.BEDELI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanTIR.BedeliParaBirimi);
            if (aktarilanTIR.NoterTarihi > DateTime.MinValue) sozlesme.NOTER_TARIHI = aktarilanTIR.NoterTarihi;
            sozlesme.NOTER_YEVMIYE_NO = aktarilanTIR.NoterYevmiyeNo;
            sozlesme.TIP_ID = 3;//Resmi Senet
            sozlesme.ALT_TIP_ID = 9;//Ticari İşletme Rehni
            sozlesme.TICARI_ISLETME_ADI = aktarilanTIR.TicariIsletmeAdi;
            sozlesme.TICARI_ISLETME_UNVANI = aktarilanTIR.TicariIsletmeUnvani;

            //Derece ve Sıra Bilgileri
            var sozlesmeDerece = sozlesme.AV001_TDI_BIL_SOZLESME_DERECECollection.AddNew();
            sozlesmeDerece.DERECESI = aktarilanTIR.RehinDerece;
            sozlesmeDerece.SIRASI = aktarilanTIR.RehinSira;
            sozlesmeDerece.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            sozlesmeDerece.ADMIN_KAYIT_MI = false;
            sozlesmeDerece.KAYIT_TARIHI = DateTime.Now;
            sozlesmeDerece.SUBE_ID = AvukatProLib.Kimlik.SubeKodu;

            #region Taraflar

            aktarilanTIR.Taraflar.ForEach(taraf => SetRehinTeminatTarafValues(sozlesme, taraf));

            #endregion Taraflar

            return sozlesme;
        }


        public static void SettingsCari(List<Classes.CariBilgileri> cariler, TransactionManager tran)
        {
            TList<AV001_TDI_BIL_CARI> cariList = new TList<AV001_TDI_BIL_CARI>();

            foreach (var item in cariler)
            {
                AV001_TDI_BIL_CARI newCari = new AV001_TDI_BIL_CARI();

                var currentCari = DataRepository.AV001_TDI_BIL_CARIProvider.Find(string.Format("MUSTERI_NO = {0}", item.Kod)).FirstOrDefault();
                if (currentCari != null) newCari = currentCari;

                SetCariValues(newCari, item);

                cariList.Add(newCari);
            }
            if (!tran.IsOpen)
                tran.BeginTransaction();
            DataRepository.AV001_TDI_BIL_CARIProvider.DeepSave(cariList, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
            tran.Commit();
        }

        public static AV001_TDI_BIL_SOZLESME SetVarantRehniValues(AV001_TDI_BIL_SOZLESME sozlesme, Classes.VarantRehni aktarilanVarantRehni)
        {
            sozlesme.DURUM = ParametreClass.MappingTeminatDurum(aktarilanVarantRehni.Durum);
            sozlesme.REFERANS_NO = aktarilanVarantRehni.ReferanNo;
            sozlesme.TIP_ID = 3;//Resmi Senet
            sozlesme.ALT_TIP_ID = 185;//Varant Rehni
            sozlesme.BEDELI = aktarilanVarantRehni.Tutari;
            sozlesme.BEDELI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanVarantRehni.TutariParaBirimi);

            //sozlesme.REHIN_CINS_ID = aktarilanVarantRehni.RehinTuru; MAP
            sozlesme.IMZA_TARIHI = aktarilanVarantRehni.RehinTarihi;
            sozlesme.YEDI_EMIN_CARI_ID = DetermineCustomerCariID(aktarilanVarantRehni.Yeddiemin, null);
            sozlesme.ACIKLAMA = aktarilanVarantRehni.Aciklama;

            #region Taraflar

            aktarilanVarantRehni.Taraflar.ForEach(taraf => SetRehinTeminatTarafValues(sozlesme, taraf));

            #endregion Taraflar

            return sozlesme;
        }

        public static AV001_TDI_BIL_SOZLESME SetVesaikiValues(AV001_TDI_BIL_SOZLESME sozlesme, Classes.IhracatIthalatVesaiki aktarilanVesaiki)
        {
            sozlesme.DURUM = ParametreClass.MappingTeminatDurum(aktarilanVesaiki.Durum);
            sozlesme.REFERANS_NO = aktarilanVesaiki.ReferansNo;
            sozlesme.TIP_ID = 3;//Resmi Senet
            sozlesme.ALT_TIP_ID = 187;//Vesaiki
            sozlesme.BEDELI = aktarilanVesaiki.Tutar;
            sozlesme.BEDELI_DOVIZ_ID = ParametreClass.MappingDovizTip(aktarilanVesaiki.TutarParaBirimi);
            sozlesme.AKT_1 = aktarilanVesaiki.ReferansSube;
            sozlesme.AKT_2 = aktarilanVesaiki.ReferansTuru;
            sozlesme.AKT_3 = aktarilanVesaiki.ReferansNiteligi;
            sozlesme.AKT_7 = aktarilanVesaiki.ReferansSiraNo;
            sozlesme.AKT_9 = aktarilanVesaiki.OdemeVadesi;
            sozlesme.AKT_4 = aktarilanVesaiki.MalSevkiyatSekli;
            sozlesme.AKT_5 = aktarilanVesaiki.TasiyiciFirma;
            sozlesme.AKT_6 = aktarilanVesaiki.SigortaSirketi;
            sozlesme.AKT_8 = aktarilanVesaiki.PoliceNumarasi;

            #region Taraflar

            aktarilanVesaiki.Taraflar.ForEach(taraf => SetRehinTeminatTarafValues(sozlesme, taraf));

            #endregion Taraflar

            return sozlesme;
        }

        public static bool UpdateGayrinakitValues(TList<AV001_TI_BIL_ALACAK_NEDEN> klasorAlacak, Classes.GayriNakitAlacak aktarilanGayrinakitAlacak, bool isUpdate, TList<AV001_TI_BIL_ALACAK_NEDEN> gayrinakitAlacakList, AV001_TDIE_BIL_PROJE yeniKlasor)
        {
            foreach (var item in klasorAlacak)
            {
                if (!AvukatProLib.Hesap.HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(item)) continue;

                var aciklamaList = item.ACIKLAMA.Split(',');
                var alacak = aciklamaList.Where(vi => vi == aktarilanGayrinakitAlacak.ReferansNo2).FirstOrDefault();

                if (alacak != null)
                {
                    int[] id = new int[] { 93, 94, 95, 96, 97, 98 };
                    List<int> idList = new List<int>(id);
                        //Çek yapraklarında çek yaprağı sorumluluk miktarı değişebilir.
                        //Çek yapraklarının ilk gönderilen sorumluluk miktarı ile sistemdeki sorumuluk miktarı karşılaştırılır. Fark var ise farkı kadar yeni gayrinakit alacak oluşturulur.
                        if (aktarilanGayrinakitAlacak.CekYapragiILKSorumlulukMiktari != item.CEK_YAPRAGI_SORUMLULUK_MIKTARI)
                        {
                            var fark = aktarilanGayrinakitAlacak.CekYapragiILKSorumlulukMiktari - item.CEK_YAPRAGI_SORUMLULUK_MIKTARI.Value;
                            aktarilanGayrinakitAlacak.CekYapragiILKSorumlulukMiktari = fark;
                            gayrinakitAlacakList.Add(NewAlacakNedenForKlasor(new AV001_TI_BIL_ALACAK_NEDEN(), aktarilanGayrinakitAlacak, yeniKlasor));
                        }
                    if (aktarilanGayrinakitAlacak.Hareketler != null)
                        aktarilanGayrinakitAlacak.Hareketler.ForEach(hareket => SetGayrinakitHareketValues(item, hareket));

                    isUpdate = true;
                    break;//Klasör üzerindeki takipsiz alacak bir tane olduğundan doğru alacak bulunup ilgili işlemler yapıldıktan sonra diğer aalcaklarda dönmeisne gerek yok.
                }
            }
            return isUpdate;
        }

        private static void frmBul_FormClosed(object sender, FormClosedEventArgs e)
        {
            var frmBul = sender as frmMusteriBul;
            if (frmBul != null && frmBul.CariID != 0)
            {
                tarafCariID = frmBul.CariID;

                if (CustomerNameMapList == null) CustomerNameMapList = new Dictionary<string, int>();

                if (CustomerNameMapList.Where(vi => vi.Value == tarafCariID).Count() == 0)
                    CustomerNameMapList.Add(frmBul.Musteri, tarafCariID);
            }
        }
    }
}