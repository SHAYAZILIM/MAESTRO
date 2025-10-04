using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace AKT_TransferMasrafTahsilatDovizKurAuto
{
    public static class MethodsForDovizKurlari
    {
        public static DovizKur BindDovizKurlari(XElement doc)
        {
            DovizKur dovizKur = new DovizKur();

            if (doc.Element("DovizTip") != null) dovizKur.DovizTip = doc.Element("DovizTip").Value;
            if (doc.Element("GercekDeger") != null) dovizKur.GercekDeger = Convert.ToDecimal(doc.Element("GercekDeger").Value == "" ? "0" : doc.Element("GercekDeger").Value.ReplaceFromPoint());
            if (doc.Element("CaprazDeger") != null) dovizKur.CaprazDeger = Convert.ToDecimal(doc.Element("CaprazDeger").Value == "" ? "0" : doc.Element("CaprazDeger").Value.ReplaceFromPoint());
            if (doc.Element("DovizAlis") != null) dovizKur.DovizAlis = Convert.ToDecimal(doc.Element("DovizAlis").Value == "" ? "0" : doc.Element("DovizAlis").Value.ReplaceFromPoint());
            if (doc.Element("DovizSatis") != null) dovizKur.DovizSatis = Convert.ToDecimal(doc.Element("DovizSatis").Value == "" ? "0" : doc.Element("DovizSatis").Value.ReplaceFromPoint());
            if (doc.Element("EfektifAlis") != null) dovizKur.EfektifAlis = Convert.ToDecimal(doc.Element("EfektifAlis").Value == "" ? "0" : doc.Element("EfektifAlis").Value.ReplaceFromPoint());
            if (doc.Element("EfektifSatis") != null) dovizKur.EfektifSatis = Convert.ToDecimal(doc.Element("EfektifSatis").Value == "" ? "0" : doc.Element("EfektifSatis").Value.ReplaceFromPoint());
            if (doc.Element("GiseKurmu") != null) dovizKur.GiseKurmu = Convert.ToBoolean(doc.Element("GiseKurmu").Value == "" ? null : doc.Element("GiseKurmu").Value);
            if (doc.Element("Katsayi") != null) dovizKur.KatSayi = Convert.ToInt32(doc.Element("Katsayi").Value == "" ? "0" : doc.Element("Katsayi").Value);
            if (doc.Element("Tarih") != null) dovizKur.Tarih = Convert.ToDateTime(doc.Element("Tarih").Value == "" ? null : doc.Element("Tarih").Value);

            return dovizKur;
        }

        public static void SetDovizKur(List<DovizKur> DovizList)
        {
            TList<TDI_CET_GUNLUK_DOVIZ_KUR> gunlukKurList = new TList<TDI_CET_GUNLUK_DOVIZ_KUR>();

            foreach (var item in DovizList)
            {
                TDI_CET_GUNLUK_DOVIZ_KUR kur = new TDI_CET_GUNLUK_DOVIZ_KUR();

                kur.DOVIZ_ID = DataRepository.TDI_KOD_DOVIZ_TIPProvider.Find(string.Format("DOVIZ_KODU ={0}", item.DovizTip)).FirstOrDefault().ID;
                kur.TL_DEGERI = item.DovizAlis;
                kur.DOVIZ_ORTALAMA = item.CaprazDeger;
                kur.DOVIZ_SATIS = item.DovizSatis;
                kur.EFEKTIF_ALIS = item.EfektifAlis;
                kur.EFEKTIF_SATIS = item.EfektifSatis;
                kur.EFEKTIF_ORTALAMA = item.KatSayi;
                kur.TARIH = item.Tarih;

                kur.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                kur.KONTROL_NE_ZAMAN = DateTime.Now;
                kur.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                kur.STAMP = AvukatProLib.Kimlik.DefaultStamp;

                if (item.GiseKurmu)//Banka
                {
                    kur.TCMB_KAYDI_MI = false;
                    kur.ADMIN_KAYIT_MI = 0;
                }
                else
                {
                    kur.TCMB_KAYDI_MI = true;
                    kur.ADMIN_KAYIT_MI = 1;
                }
                gunlukKurList.Add(kur);
            }

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                tran.BeginTransaction();
                DataRepository.TDI_CET_GUNLUK_DOVIZ_KURProvider.Save(tran, gunlukKurList);
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