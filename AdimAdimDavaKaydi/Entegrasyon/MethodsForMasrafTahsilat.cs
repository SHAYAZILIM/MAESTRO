using AdimAdimDavaKaydi.Entegrasyon.Classes;
using AdimAdimDavaKaydi.Entegrasyon.ClassesMasrafTahsilat;
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
    public static class MethodsForMasrafTahsilat
    {
        public static bool MasrafIslendi = false;
        public static bool TahsilatIslendi = false;

        public static Masraflar BindMasrafXML(XElement doc)
        {
            Masraflar masraf = new Masraflar();

            if (doc.Element("Sube") != null) masraf.Sube = doc.Element("Sube").Value;
            if (doc.Element("KrediBorclusu") != null) masraf.KrediBorclusu = doc.Element("KrediBorclusu").Value;
            if (doc.Element("MusteriNo") != null) masraf.MusteriNo = doc.Element("MusteriNo").Value;
            if (doc.Element("HesapNo") != null) masraf.HesapNo = doc.Element("HesapNo").Value;
            if (doc.Element("IBANNo") != null) masraf.IBANNo = doc.Element("IBANNo").Value;
            if (doc.Element("MasrafYapan") != null) masraf.MasrafYapan = doc.Element("MasrafYapan").Value;
            if (doc.Element("Borclu") != null) masraf.Borclu = doc.Element("Borclu").Value;
            if (doc.Element("ReferansNo") != null) masraf.ReferansNo = doc.Element("ReferansNo").Value;
            if (doc.Element("ToplamTutar") != null) masraf.ToplamTutar = Convert.ToDecimal(doc.Element("ToplamTutar").Value == "" ? "0" : doc.Element("ToplamTutar").Value.ReplaceFromPoint());
            if (doc.Element("ToplamTutarParaBirimi") != null) masraf.ToplamTutarParaBirimi = doc.Element("ToplamTutarParaBirimi").Value;
            if (doc.Element("MasrafTarihi") != null) masraf.MasrafTarihi = Convert.ToDateTime(doc.Element("MasrafTarihi").Value == "" ? null : doc.Element("MasrafTarihi").Value);
            if (doc.Element("Onaylayan") != null) masraf.Onaylayan = doc.Element("Onaylayan").Value;
            if (doc.Element("MasrafKategori") != null) masraf.MasrafKategori = doc.Element("MasrafKategori").Value;
            if (doc.Element("KrediReferansNo") != null) masraf.KrediReferansNo = doc.Element("KrediReferansNo").Value;
            if (doc.Element("Niteligi") != null) masraf.Niteligi = doc.Element("Niteligi").Value;

            return masraf;
        }

        public static void CheckMasrafAvans(Masraflar item)
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            if (!string.IsNullOrEmpty(item.ReferansNo))//Referans Numarası var.
            {
                var selectedMasraf = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.Find(string.Format("REFERANS_NO = {0}", item.ReferansNo)).FirstOrDefault();
                if (selectedMasraf != null)//Aktarılan referans numaralı masraf sistemde bulundu.
                {
                    //Sistemdeki masraf herhangi bir klasör ya da dosyaya bağlı ise ilgili yerde dağıtılmamış masraf bölümüne otomatik gidecek. Dağıtılmamış masraflar tablosunda kayıt oluşturmaya gerek yok. Klasör ya da ilgili dosyada masraf tablosunda eşleşti mi alanı false olanlar getirilecek.
                    DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(selectedMasraf, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));

                    var toplamTutar = selectedMasraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Select(vi => vi.TOPLAM_TUTAR).Sum();

                    if (item.ToplamTutar == toplamTutar)
                    {
                        //Masraf eşleştirildi.
                        selectedMasraf.ESLESTI_MI = true;
                    }
                    else
                    {
                        //Masraf eşleştirilemedi.
                        selectedMasraf.ESLESTI_MI = false;
                    }
                    try
                    {
                        tran.BeginTransaction();
                        DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.Save(selectedMasraf);
                        tran.Commit();

                        if (selectedMasraf.ESLESTI_MI.Value)
                            MessageBox.Show("Aktarılan masraf eşleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Aktarılan masraf ilgili dosyaya \r\nDAĞITILMAMIŞ MASRAF olarak gönderildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MasrafIslendi = true;
                    }
                    catch (Exception ex)
                    {
                        if (tran.IsOpen) tran.Rollback();
                        BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", ex);
                        MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MasrafIslendi = false;
                    }
                }
                else//Aktarılan referans numaralı masraf sistemde bulunamadı.
                {
                    //Dağıtılmamış masraflara ekle.
                    AKT_DAGITILMAMIS_MASRAF_AVANS aktMasraf = new AKT_DAGITILMAMIS_MASRAF_AVANS();
                    SetDagitilmamisMasraf(item, aktMasraf, tran);
                }
            }
            else//Aktarımda Referans Numarası bilgisi gelmemiş.
            {
                //Dağıtılmamış masraflara ekle.
                AKT_DAGITILMAMIS_MASRAF_AVANS aktMasraf = new AKT_DAGITILMAMIS_MASRAF_AVANS();
                SetDagitilmamisMasraf(item, aktMasraf, tran);
            }
        }

        public static void CheckTahsilat(Tahsilatlar item)
        {
            int customerID = Methods.DetermineCustomerCariID(item.KrediBorclusu, item.MusteriNo);

            if (customerID == 0)
            {
                frmMusteriBul frmBul = new frmMusteriBul();
                frmBul.Show(item.KrediBorclusu);
                frmBul.FormClosed += delegate
                {
                    if (frmBul.CariID != null && frmBul.CariID != 0)
                    {
                        CheckTahsilat(item, frmBul.CariID);
                    }
                };
            }
            else
            {
                CheckTahsilat(item, customerID);
            }
        }

        //public static void SetAktarilanMasraf(Masraflar item, AKT_AKTARILAN_MASRAFLAR_XML aktarilanMasraf)
        //{
        //    aktarilanMasraf.BORCLU = item.Borclu;
        //    aktarilanMasraf.HESAP_NO = item.HesapNo;
        //    aktarilanMasraf.IBANN_NO = item.IBANNo;
        //    aktarilanMasraf.KREDI_BORCLUSU = item.KrediBorclusu;
        //    aktarilanMasraf.KREDI_REFERANS_NO = item.KrediReferansNo;
        //    aktarilanMasraf.MASRAF_KATEGORI = item.MasrafKategori;
        //    aktarilanMasraf.MASRAF_TARIHI = item.MasrafTarihi;
        //    aktarilanMasraf.MASRAF_YAPAN = item.MasrafYapan;
        //    aktarilanMasraf.MUSTERI_NO = item.MusteriNo;
        //    aktarilanMasraf.ONAYLAYAN = item.Onaylayan;
        //    aktarilanMasraf.REFERANS_NO = item.ReferansNo;
        //    aktarilanMasraf.SUBE = item.Sube;
        //    aktarilanMasraf.TOPLAM_TUTAR = item.ToplamTutar;
        //    aktarilanMasraf.TOPLAM_TUTAR_PARA_BIRIMI = item.ToplamTutarParaBirimi;
        //}
        public static void CheckTahsilat(Tahsilatlar item, int krediBorclusuID)
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            var selectedTahsilat = DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.GetByODEYEN_CARI_ID(krediBorclusuID).Find(vi => vi.ODEME_TARIHI == item.OdemeTarihi && vi.ODEME_MIKTAR == item.OdemeMiktari);

            if (selectedTahsilat != null)//Aktarılan tahsilat sistemde bulundu.
            {
                //Tahsilat eşleştirildi.
                selectedTahsilat.ESLESTI_MI = true;

                try
                {
                    tran.BeginTransaction();
                    DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.Save(selectedTahsilat);
                    tran.Commit();

                    if (selectedTahsilat.ESLESTI_MI.Value)
                        MessageBox.Show("Aktarılan tahsilat eşleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Aktarılan tahsilat ilgili dosyaya \r\nDAĞITILMAMIŞ TAHSİLAT olarak gönderildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TahsilatIslendi = true;
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen) tran.Rollback();
                    BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", ex);
                    MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    TahsilatIslendi = false;
                }
            }
            else//Aktarılan tahsilat sistemde bulunamadı.
            {
                //Dağıtılmamış tahsilatlara ekle.
                AKT_DAGITILMAMIS_TAHSILATLAR aktTahsilat = new AKT_DAGITILMAMIS_TAHSILATLAR();
                SetDagitilmamisTahsilat(item, aktTahsilat, tran, krediBorclusuID);
            }
        }

        public static void ControlToMasraf(List<Masraflar> MasrafList)
        {
            MasrafList.ForEach(item => CheckMasrafAvans(item));
        }

        public static MasrafBilgisi GetMasrafAvansList(AV001_TI_BIL_FOY item)
        {
            MasrafBilgisi takip = new MasrafBilgisi();

            if (item.ADLI_BIRIM_ADLIYE_ID.HasValue)
            {
                if (BelgeUtil.Inits._AdliBirimAdliyeGetir == null)
                    BelgeUtil.Inits._AdliBirimAdliyeGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetAll();

                takip.Adliye = BelgeUtil.Inits._AdliBirimAdliyeGetir.Find(vi => vi.ID == item.ADLI_BIRIM_ADLIYE_ID.Value).ADLIYE + " ";
            }
            if (item.ADLI_BIRIM_NO_ID.HasValue)
            {
                if (BelgeUtil.Inits._AdliBirimNoGetir == null)
                    BelgeUtil.Inits._AdliBirimNoGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_NOProvider.GetAll();

                takip.No = BelgeUtil.Inits._AdliBirimNoGetir.Find(vi => vi.ID == item.ADLI_BIRIM_NO_ID.Value).NO + " ";
            }
            if (item.ADLI_BIRIM_GOREV_ID.HasValue)
            {
                if (BelgeUtil.Inits._AdliBirimGorevGetir_Enter == null)
                    BelgeUtil.Inits._AdliBirimGorevGetir_Enter = DataRepository.per_TDI_KOD_ADLI_BIRIM_GOREVProvider.GetAll();

                takip.Gorev = BelgeUtil.Inits._AdliBirimGorevGetir_Enter.Find(vi => vi.ID == item.ADLI_BIRIM_GOREV_ID.Value).GOREV;
            }
            takip.EsasNo = item.ESAS_NO + " ";
            takip.DisplayMember = takip.EsasNo + takip.Adliye + takip.No + takip.Gorev;
            takip.ID = item.ID;
            takip.Durum = (int)Enums.MasrafinGonderildigiDosya.Icra;
            takip.IcraFoyID = item.ID;

            return takip;
        }

        //public static void SetAktarilanTahsilat(Tahsilatlar item, AKT_AKTARILAN_TAHSILATLAR_XML aktarilanTahsilat)
        //{
        //    aktarilanTahsilat.HESAP_NO = item.HesapNo;
        //    aktarilanTahsilat.IBAN_NO = item.IBANNo;
        //    aktarilanTahsilat.KREDI_MUSTERISI = item.KrediBorclusu;
        //    aktarilanTahsilat.KREDI_REFERANS_NO = item.KrediReferansNo;
        //    aktarilanTahsilat.MUSTERI_NO = item.MusteriNo;
        //    aktarilanTahsilat.ODEME_MIKTARI = item.OdemeMiktari;
        //    aktarilanTahsilat.ODEME_MIKTARI_PARA_BIRIMI = item.OdemeMiktariParaBirimi;
        //    aktarilanTahsilat.ODEME_TARIHI = item.OdemeTarihi;
        //    aktarilanTahsilat.ODEYEN = item.Odeyen;
        //    aktarilanTahsilat.SUBE = item.Sube;
        //}
        public static MasrafBilgisi GetMasrafAvansList(AV001_TD_BIL_FOY item)
        {
            MasrafBilgisi dava = new MasrafBilgisi();

            if (item.ADLI_BIRIM_ADLIYE_ID.HasValue)
            {
                if (BelgeUtil.Inits._AdliBirimAdliyeGetir == null)
                    BelgeUtil.Inits._AdliBirimAdliyeGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetAll();

                dava.Adliye = BelgeUtil.Inits._AdliBirimAdliyeGetir.Find(vi => vi.ID == item.ADLI_BIRIM_ADLIYE_ID.Value).ADLIYE + " ";
            }
            if (item.ADLI_BIRIM_NO_ID.HasValue)
            {
                if (BelgeUtil.Inits._AdliBirimNoGetir == null)
                    BelgeUtil.Inits._AdliBirimNoGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_NOProvider.GetAll();

                dava.No = BelgeUtil.Inits._AdliBirimNoGetir.Find(vi => vi.ID == item.ADLI_BIRIM_NO_ID.Value).NO + " ";
            }
            if (item.ADLI_BIRIM_GOREV_ID.HasValue)
            {
                if (BelgeUtil.Inits._AdliBirimGorevGetir_Enter == null)
                    BelgeUtil.Inits._AdliBirimGorevGetir_Enter = DataRepository.per_TDI_KOD_ADLI_BIRIM_GOREVProvider.GetAll();

                dava.Gorev = BelgeUtil.Inits._AdliBirimGorevGetir_Enter.Find(vi => vi.ID == item.ADLI_BIRIM_GOREV_ID.Value).GOREV;
            }
            dava.EsasNo = item.ESAS_NO + " ";
            dava.DisplayMember = dava.EsasNo + dava.Adliye + dava.No + dava.Gorev;
            dava.ID = item.ID;
            dava.Durum = (int)Enums.MasrafinGonderildigiDosya.Dava;
            dava.DavaFoyID = item.ID;
            return dava;
        }

        public static MasrafBilgisi GetMasrafAvansList(AV001_TD_BIL_HAZIRLIK item)
        {
            MasrafBilgisi sorusturma = new MasrafBilgisi();

            if (item.ADLI_BIRIM_ADLIYE_ID.HasValue)
            {
                if (BelgeUtil.Inits._AdliBirimAdliyeGetir == null)
                    BelgeUtil.Inits._AdliBirimAdliyeGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetAll();

                sorusturma.Adliye = BelgeUtil.Inits._AdliBirimAdliyeGetir.Find(vi => vi.ID == item.ADLI_BIRIM_ADLIYE_ID.Value).ADLIYE + " ";
            }
            if (item.ADLI_BIRIM_NO_ID.HasValue)
            {
                if (BelgeUtil.Inits._AdliBirimNoGetir == null)
                    BelgeUtil.Inits._AdliBirimNoGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_NOProvider.GetAll();

                sorusturma.No = BelgeUtil.Inits._AdliBirimNoGetir.Find(vi => vi.ID == item.ADLI_BIRIM_NO_ID.Value).NO + " ";
            }
            if (item.ADLI_BIRIM_GOREV_ID.HasValue)
            {
                if (BelgeUtil.Inits._AdliBirimGorevGetir_Enter == null)
                    BelgeUtil.Inits._AdliBirimGorevGetir_Enter = DataRepository.per_TDI_KOD_ADLI_BIRIM_GOREVProvider.GetAll();

                sorusturma.Gorev = BelgeUtil.Inits._AdliBirimGorevGetir_Enter.Find(vi => vi.ID == item.ADLI_BIRIM_GOREV_ID.Value).GOREV;
            }
            sorusturma.EsasNo = item.HAZIRLIK_ESAS_NO + " ";
            sorusturma.DisplayMember = sorusturma.EsasNo + sorusturma.Adliye + sorusturma.No + sorusturma.Gorev;
            sorusturma.ID = item.ID;
            sorusturma.Durum = (int)Enums.MasrafinGonderildigiDosya.Sorusturma;
            sorusturma.SorusturmaID = item.ID;

            return sorusturma;
        }

        public static List<MasrafBilgisi> GetMasrafAvansList(TList<AV001_TI_BIL_FOY> icraList)
        {
            List<MasrafBilgisi> list = new List<MasrafBilgisi>();

            foreach (var item in icraList)
            {
                list.Add(GetMasrafAvansList(item));
            }

            return list;
        }

        public static List<MasrafBilgisi> GetMasrafAvansList(TList<AV001_TD_BIL_FOY> davaList)
        {
            List<MasrafBilgisi> list = new List<MasrafBilgisi>();

            foreach (var item in davaList)
            {
                list.Add(GetMasrafAvansList(item));
            }

            return list;
        }

        public static List<MasrafBilgisi> GetMasrafAvansList(TList<AV001_TD_BIL_HAZIRLIK> davaList)
        {
            List<MasrafBilgisi> list = new List<MasrafBilgisi>();

            foreach (var item in davaList)
            {
                list.Add(GetMasrafAvansList(item));
            }

            return list;
        }

        public static TahsilatBilgisi GetTahsilatList(AV001_TI_BIL_FOY item)
        {
            TahsilatBilgisi takip = new TahsilatBilgisi();

            if (item.ADLI_BIRIM_ADLIYE_ID.HasValue)
                takip.Adliye = DataRepository.TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetByID(item.ADLI_BIRIM_ADLIYE_ID.Value).ADLIYE + " ";
            if (item.ADLI_BIRIM_NO_ID.HasValue)
                takip.No = DataRepository.TDI_KOD_ADLI_BIRIM_NOProvider.GetByID(item.ADLI_BIRIM_NO_ID.Value).NO + " ";
            if (item.ADLI_BIRIM_GOREV_ID.HasValue)
                takip.Gorev = DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.GetByID(item.ADLI_BIRIM_GOREV_ID.Value).ACIKLAMA + " ";
            takip.EsasNo = item.ESAS_NO;
            takip.DisplayMember = takip.Adliye + takip.No + takip.Gorev + takip.EsasNo;
            takip.ID = item.ID;
            takip.Durum = (int)Enums.MasrafinGonderildigiDosya.Icra;
            takip.IcraFoyID = item.ID;

            return takip;
        }

        public static List<TahsilatBilgisi> GetTahsilatList(TList<AV001_TI_BIL_FOY> icraList)
        {
            List<TahsilatBilgisi> list = new List<TahsilatBilgisi>();

            foreach (var item in icraList)
            {
                list.Add(GetTahsilatList(item));
            }

            return list;
        }

        public static void SetDagitilmamisMasraf(Masraflar item, AKT_DAGITILMAMIS_MASRAF_AVANS aktMasraf, TransactionManager tran)
        {
            int customerID = Methods.DetermineCustomerCariID(item.KrediBorclusu, item.MusteriNo);

            if (customerID == 0)
            {
                frmMusteriBul frmBul = new frmMusteriBul();
                frmBul.Show(item.KrediBorclusu);
                frmBul.FormClosed += delegate
                {
                    if (frmBul.CariID != null && frmBul.CariID != 0)
                    {
                        SetDagitilmamisMasraf(item, aktMasraf, tran, frmBul.CariID);
                    }
                };
            }
            else
            {
                SetDagitilmamisMasraf(item, aktMasraf, tran, customerID);
            }
        }

        public static void SetDagitilmamisMasraf(Masraflar item, AKT_DAGITILMAMIS_MASRAF_AVANS aktMasraf, TransactionManager tran, int krediBorclusuID)
        {
            if (Methods.CustomerNameMapList == null) Methods.CustomerNameMapList = new Dictionary<string, int>();

            if (Methods.CustomerNameMapList.Where(vi => vi.Value == krediBorclusuID).Count() == 0)
                Methods.CustomerNameMapList.Add(item.KrediBorclusu, krediBorclusuID);

            aktMasraf.MASRAF_TARIHI = item.MasrafTarihi;
            aktMasraf.MASRAF_YAPAN_CARI_ID = Methods.DetermineCustomerCariID(item.MasrafYapan, null);
            aktMasraf.MASRAF_REFERANS_NO = item.ReferansNo;
            aktMasraf.TOPLAM_TUTAR = item.ToplamTutar;
            aktMasraf.TOPLAM_TUTAR_DOVIZ_ID = 1;//Masraflarda para birimi her zaman TL olur.
            aktMasraf.KREDI_BORCLUSU_CARI_ID = krediBorclusuID;

            try
            {
                tran.BeginTransaction();
                DataRepository.AKT_DAGITILMAMIS_MASRAF_AVANSProvider.Save(tran, aktMasraf);

                //DataRepository.AKT_AKTARILAN_MASRAFLAR_XMLProvider.Delete(tran, item);
                tran.Commit();

                MasrafIslendi = true;
                MessageBox.Show("Aktarılan masraf DAĞITILMAMIŞ MASRAFLARA eklendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {
                if (tran.IsOpen)
                    tran.Rollback();

                MasrafIslendi = false;

                //BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        public static void SetDagitilmamisTahsilat(Tahsilatlar item, AKT_DAGITILMAMIS_TAHSILATLAR aktTahsilat, TransactionManager tran, int krediBorclusuID)
        {
            if (Methods.CustomerNameMapList == null) Methods.CustomerNameMapList = new Dictionary<string, int>();

            if (Methods.CustomerNameMapList.Where(vi => vi.Value == krediBorclusuID).Count() == 0)
                Methods.CustomerNameMapList.Add(item.KrediBorclusu, krediBorclusuID);

            aktTahsilat.ODEME_MIKTARI = item.OdemeMiktari;
            aktTahsilat.ODEME_TARIHI = item.OdemeTarihi;
            aktTahsilat.ODEME_MIKTARI_DOVIZ_ID = ParametreClass.MappingDovizTip(item.OdemeMiktariParaBirimi);

            aktTahsilat.KREDI_BORCLUSU_CARI_ID = krediBorclusuID;

            try
            {
                tran.BeginTransaction();
                DataRepository.AKT_DAGITILMAMIS_TAHSILATLARProvider.Save(tran, aktTahsilat);

                //DataRepository.AKT_AKTARILAN_TAHSILATLAR_XMLProvider.Delete(tran, item);
                tran.Commit();

                TahsilatIslendi = true;
                MessageBox.Show("Aktarılan tahsilat DAĞITILMAMIŞ TAHSİLATLARA eklendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();

                TahsilatIslendi = false;
                BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", ex);
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}