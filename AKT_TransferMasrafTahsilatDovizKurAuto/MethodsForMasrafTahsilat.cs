using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Linq;
using System.Xml.Linq;

namespace AKT_TransferMasrafTahsilatDovizKurAuto
{
    public static class MethodsForMasrafTahsilat
    {
        //Masraflar

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

            return masraf;
        }

        public static Tahsilatlar BindTahsilatXML(XElement doc)
        {
            Tahsilatlar tahsilat = new Tahsilatlar();

            if (doc.Element("Sube") != null) tahsilat.Sube = doc.Element("Sube").Value;
            if (doc.Element("KrediMusterisi") != null) tahsilat.KrediBorclusu = doc.Element("KrediMusterisi").Value;
            if (doc.Element("MusteriNo") != null) tahsilat.MusteriNo = doc.Element("MusteriNo").Value;
            if (doc.Element("HesapNo") != null) tahsilat.HesapNo = doc.Element("HesapNo").Value;
            if (doc.Element("IBANNo") != null) tahsilat.IBANNo = doc.Element("IBANNo").Value;
            if (doc.Element("Odeyen") != null) tahsilat.Odeyen = doc.Element("Odeyen").Value;
            if (doc.Element("OdemeMiktarı") != null) tahsilat.OdemeMiktari = Convert.ToDecimal(doc.Element("OdemeMiktarı").Value == "" ? "0" : doc.Element("OdemeMiktarı").Value.ReplaceFromPoint());
            if (doc.Element("OdemeMiktariParaBirimi") != null) tahsilat.OdemeMiktariParaBirimi = doc.Element("OdemeMiktariParaBirimi").Value;
            if (doc.Element("OdemeTarihi") != null) tahsilat.OdemeTarihi = Convert.ToDateTime(doc.Element("OdemeTarihi").Value == "" ? null : doc.Element("OdemeTarihi").Value);
            if (doc.Element("KrediReferansNo") != null) tahsilat.KrediReferansNo = doc.Element("KrediReferansNo").Value;

            return tahsilat;
        }

        public static void CheckMasrafAvans(Masraflar item)
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            if (!string.IsNullOrEmpty(item.ReferansNo))//Referans Numarası var.
            {
                var selectedMasraf = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.Find(string.Format("REFERANS_NO = {0}", item.ReferansNo)).FirstOrDefault();
                if (selectedMasraf != null)//Aktarılan referans numaralı masraf sistemde bulundu.
                {
                    //Eşleşme bilgisi kontrol edilir.

                    DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(selectedMasraf, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));

                    var toplamTutar = selectedMasraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Select(vi => vi.TOPLAM_TUTAR).Sum();

                    //Masraf eşleştirildi.
                    if (item.ToplamTutar == toplamTutar)
                    {
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

                        //LOG
                    }
                    catch 
                    {
                        if (tran.IsOpen) tran.Rollback();

                        //LOG
                    }
                }
                else//Aktarılan referans numaralı masraf sistemde bulunamadı.
                {
                    GetDagitilmamisMasraf(item, tran);
                }
            }
            else//Aktarımda Referans Numarası bilgisi gelmemiş.
            {
                GetDagitilmamisMasraf(item, tran);
            }
        }

        //Tahsilatlar
        public static void CheckTahsilat(Tahsilatlar item)
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            var krediBorclusu = GetKrediBorclusuByMusteriNo(item.MusteriNo);

            var selectedTahsilat = DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.GetByODEYEN_CARI_ID(krediBorclusu.ID).Find(vi => vi.ODEME_TARIHI == item.OdemeTarihi && vi.ODEME_MIKTAR == item.OdemeMiktari);

            if (selectedTahsilat != null)//Aktarılan tahsilat sistemde bulundu.
            {
                //Tahsilat eşleştirildi.
                selectedTahsilat.ESLESTI_MI = true;

                try
                {
                    tran.BeginTransaction();
                    DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.Save(selectedTahsilat);
                    tran.Commit();
                }
                catch 
                {
                    if (tran.IsOpen) tran.Rollback();

                    //LOG
                }
            }
            else//Aktarılan tahsilat sistemde bulunamadı.
            {
                //Dağıtılmamış tahsilatlara ekle.

                AKT_DAGITILMAMIS_TAHSILATLAR aktTahsilat = new AKT_DAGITILMAMIS_TAHSILATLAR();
                SetDagitilmamisTahsilat(item, aktTahsilat, tran, krediBorclusu.ID);
            }
        }

        public static void GetDagitilmamisMasraf(Masraflar item, TransactionManager tran)
        {
            //Dağıtılmamış masraflar tablosuna kayıt yapılır.

            var krediBorclusu = GetKrediBorclusuByMusteriNo(item.MusteriNo);
            if (krediBorclusu != null)
            {
                AKT_DAGITILMAMIS_MASRAF_AVANS aktMasraf = new AKT_DAGITILMAMIS_MASRAF_AVANS();
                SetDagitilmamisMasraf(item, aktMasraf, tran, krediBorclusu.ID);
            }
            else
            {
                //Gönderilen müşteri numaralı müşteri sistemde bulunamadı. Cari sistemde oluşturulur.
                //Dağıtılmamış masraflara ekle.

                //aykut
                //AV001_TDI_BIL_CARI newCari = new AV001_TDI_BIL_CARI();
                //newCari.AD = item.KrediBorclusu;
                //newCari.MUSTERI_NO = item.MusteriNo;

                //var kod = (from itemCari in BelgeUtil.Inits.context.AV001_TDI_BIL_CARIs where itemCari.KOD != null && itemCari.KOD.Trim() != string.Empty orderby itemCari.ID descending select itemCari.KOD).FirstOrDefault();
                //newCari.KOD = (Convert.ToInt32(kod) + 2).ToString();

                //if (!tran.IsOpen) tran.BeginTransaction();
                //DataRepository.AV001_TDI_BIL_CARIProvider.Save(tran, newCari);
                //tran.Commit();

                //AKT_DAGITILMAMIS_MASRAF_AVANS aktMasraf = new AKT_DAGITILMAMIS_MASRAF_AVANS();
                //SetDagitilmamisMasraf(item, aktMasraf, tran, newCari.ID);
            }
        }

        public static AV001_TDI_BIL_CARI GetKrediBorclusuByMusteriNo(string name)
        {
            return DataRepository.AV001_TDI_BIL_CARIProvider.Find(string.Format("MUSTERI_NO = {0}", name)).FirstOrDefault();
        }

        public static AV001_TDI_BIL_CARI GetSorumluAvukatByAdAvukatmi(string name)
        {
            AV001_TDI_BIL_CARIQuery que = new AV001_TDI_BIL_CARIQuery();
            que.AppendEquals(AV001_TDI_BIL_CARIColumn.AD, name);
            que.Append(AV001_TDI_BIL_CARIColumn.AVUKAT_MI, "True");

            //Bu işlemin düzgün çalışması için sistem ile banka arasında avukat eşleşmesi yapılması gerekiyor.
            //Aynı isimli avukat olma durumu kontrolü yapılmadı.
            var sorumluAvukat = DataRepository.AV001_TDI_BIL_CARIProvider.Find(que).FirstOrDefault();
            return sorumluAvukat;
        }

        public static void SetDagitilmamisMasraf(Masraflar item, AKT_DAGITILMAMIS_MASRAF_AVANS aktMasraf, TransactionManager tran, int krediBorclusuID)
        {
            aktMasraf.MASRAF_TARIHI = item.MasrafTarihi;

            var sorumluAvukat = GetSorumluAvukatByAdAvukatmi(item.MasrafYapan);
            if (sorumluAvukat == null) return;//LOG

            aktMasraf.MASRAF_YAPAN_CARI_ID = sorumluAvukat.ID;

            aktMasraf.MASRAF_REFERANS_NO = item.ReferansNo;
            aktMasraf.TOPLAM_TUTAR = item.ToplamTutar;
            aktMasraf.TOPLAM_TUTAR_DOVIZ_ID = 1;//Masraflarda para birimi her zaman TL olur.
            aktMasraf.KREDI_BORCLUSU_CARI_ID = krediBorclusuID;

            try
            {
                if (!tran.IsOpen) tran.BeginTransaction();
                DataRepository.AKT_DAGITILMAMIS_MASRAF_AVANSProvider.Save(tran, aktMasraf);
                tran.Commit();

                //LOG
            }
            catch 
            {
                if (tran.IsOpen)
                    tran.Rollback();

                //LOG
            }
        }

        public static void SetDagitilmamisTahsilat(Tahsilatlar item, AKT_DAGITILMAMIS_TAHSILATLAR aktTahsilat, TransactionManager tran, int krediBorclusuID)
        {
            aktTahsilat.ODEME_MIKTARI = item.OdemeMiktari;
            aktTahsilat.ODEME_TARIHI = item.OdemeTarihi;
            aktTahsilat.ODEME_MIKTARI_DOVIZ_ID = DataRepository.TDI_KOD_DOVIZ_TIPProvider.Find(string.Format("DOVIZ_KODU = {0}", item.OdemeMiktariParaBirimi)).FirstOrDefault().ID;
            aktTahsilat.KREDI_BORCLUSU_CARI_ID = krediBorclusuID;

            try
            {
                tran.BeginTransaction();
                DataRepository.AKT_DAGITILMAMIS_TAHSILATLARProvider.Save(tran, aktTahsilat);
                tran.Commit();

                //LOG
            }
            catch 
            {
                if (tran.IsOpen) tran.Rollback();

                //LOG
            }
        }
    }
}