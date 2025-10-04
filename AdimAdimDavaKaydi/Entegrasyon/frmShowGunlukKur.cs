using AdimAdimDavaKaydi.Entegrasyon.Classes;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdimAdimDavaKaydi.Entegrasyon
{
    public partial class frmShowGunlukKur : Form
    {
        public frmShowGunlukKur()
        {
            InitializeComponent();
        }

        private void sbtnKurGetir_Click(object sender, EventArgs e)
        {
            XDocument docs = XDocument.Load(Application.StartupPath + "\\DovizKurlari.xml");
            List<DovizKur> DovizList = new List<DovizKur>();

            foreach (var doc in docs.Descendants("DOVIZKUR"))
            {
                DovizKur dovizKur = new DovizKur();

                if (doc.Element("DovizTip") != null) dovizKur.DovizTip = doc.Element("DovizTip").Value;
                if (doc.Element("GercekDeger") != null) dovizKur.GercekDeger = Convert.ToDecimal(doc.Element("GercekDeger").Value == "" ? "0" : doc.Element("GercekDeger").Value);
                if (doc.Element("CaprazDeger") != null) dovizKur.CaprazDeger = Convert.ToDecimal(doc.Element("CaprazDeger").Value == "" ? "0" : doc.Element("CaprazDeger").Value);
                if (doc.Element("DovizAlis") != null) dovizKur.DovizAlis = Convert.ToDecimal(doc.Element("DovizAlis").Value == "" ? "0" : doc.Element("DovizAlis").Value);
                if (doc.Element("DovizSatis") != null) dovizKur.DovizSatis = Convert.ToDecimal(doc.Element("DovizSatis").Value == "" ? "0" : doc.Element("DovizSatis").Value);
                if (doc.Element("EfektifAlis") != null) dovizKur.EfektifAlis = Convert.ToDecimal(doc.Element("EfektifAlis").Value == "" ? "0" : doc.Element("EfektifAlis").Value);
                if (doc.Element("EfektifSatis") != null) dovizKur.EfektifSatis = Convert.ToDecimal(doc.Element("EfektifSatis").Value == "" ? "0" : doc.Element("EfektifSatis").Value);
                if (doc.Element("GiseKurmu") != null) dovizKur.GiseKurmu = Convert.ToBoolean(doc.Element("GiseKurmu").Value == "" ? null : doc.Element("GiseKurmu").Value);
                if (doc.Element("Katsayi") != null) dovizKur.KatSayi = Convert.ToInt32(doc.Element("Katsayi").Value == "" ? "0" : doc.Element("Katsayi").Value);
                if (doc.Element("Tarih") != null) dovizKur.Tarih = Convert.ToDateTime(doc.Element("Tarih").Value == "" ? null : doc.Element("Tarih").Value);

                DovizList.Add(dovizKur);
            }

            TList<TDI_CET_GUNLUK_DOVIZ_KUR> gunlukKurList = new TList<TDI_CET_GUNLUK_DOVIZ_KUR>();

            foreach (var item in DovizList)
            {
                TDI_CET_GUNLUK_DOVIZ_KUR kur = new TDI_CET_GUNLUK_DOVIZ_KUR();

                //kur.DOVIZ_ID = item.DovizTip; MAP
                kur.TL_DEGERI = item.DovizAlis;
                kur.DOVIZ_ORTALAMA = item.CaprazDeger;
                kur.DOVIZ_SATIS = item.DovizSatis;
                kur.EFEKTIF_ALIS = item.EfektifAlis;
                kur.EFEKTIF_SATIS = item.EfektifSatis;
                kur.EFEKTIF_ORTALAMA = item.KatSayi;
                kur.TARIH = item.Tarih;

                //Default alanlar bind edilecek.

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

            //Connection bilgisi verilecek.
            TransactionManager tran = new TransactionManager("");
            try
            {
                tran.BeginTransaction();
                DataRepository.TDI_CET_GUNLUK_DOVIZ_KURProvider.Save(tran, gunlukKurList);
                tran.Commit();
            }
            catch 
            {
                if (tran.IsOpen) tran.Rollback();

                //Hata yakalama
            }
        }
    }
}