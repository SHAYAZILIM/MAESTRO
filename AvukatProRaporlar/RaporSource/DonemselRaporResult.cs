using System;
using System.Collections.Generic;
using System.Text;

namespace AvukatProRaporlar.RaporSource
{
    public class DonemselRaporResult
    {
        public List<string> Avukatlar;
        public int AvukatlarGenel;
        public List<string> HukukBolumleri;
        public bool HukukGenel;
        public List<string> KrediRaporlari;
        public bool KrediRaporlariGenel;
        public int RaporTuru;
        public DateTime rdat;

        //risklerin devir alındığı tarih
        public DateTime rest;

        // -1 seçilmedi 0 Kadrolu Avukatlar 1 Sözleşmeli Avukatlar 2 Tümü
        public List<string> Subeler;

        public bool SubelerGenel;

        //rapora esas son tarih
        public List<string> TakipRaporlari;

        public bool TakipRaporlariGenel;

        private string _avukatKriterleri;

        private string _hukukBolumKriterleri;

        private string _krediKriterleri;

        private string _subeKriterleri;

        private string _takipKriterleri;

        public DonemselRaporResult()
        {
            HukukBolumleri = new List<string>();

            Avukatlar = new List<string>();
            Subeler = new List<string>();
            KrediRaporlari = new List<string>();
            TakipRaporlari = new List<string>();
            rest = DateTime.Now;
            rdat = DateTime.Now;
            AvukatlarGenel = -1;
        }

        public string AvukatKriterleri
        {
            get
            {
                if (AvukatlarGenel == 0)
                    return "Kadrolu Avukatlar";
                else if (AvukatlarGenel == 1)
                    return "Sözleşmeli Avukatlar";
                else if (AvukatlarGenel == 2)
                    return "Tümü";
                else
                {
                    return ListeKriterleriCevir(Avukatlar).ToString();
                }
            }
            set { _avukatKriterleri = value; }
        }

        public string HukukBolumKriterleri
        {
            get
            {
                if (HukukGenel)
                    return "Tümü";
                else
                {
                    return ListeKriterleriCevir(HukukBolumleri).ToString();
                }
            }
            set { _hukukBolumKriterleri = value; }
        }

        public string KrediKriterleri
        {
            get
            {
                if (KrediRaporlariGenel)
                    return "Tümü";
                else
                {
                    return ListeKriterleriCevir(KrediRaporlari).ToString();
                }
            }
            set { _krediKriterleri = value; }
        }

        public string SubeKriterleri
        {
            get
            {
                if (SubelerGenel)
                    return "Tümü";
                else
                {
                    return ListeKriterleriCevir(Subeler).ToString();
                }
            }
            set { _subeKriterleri = value; }
        }

        public string TakipKriterleri
        {
            get
            {
                if (TakipRaporlariGenel)
                    return "Tümü";
                else
                {
                    return ListeKriterleriCevir(TakipRaporlari).ToString();
                }
            }
            set { _takipKriterleri = value; }
        }

        public StringBuilder ListeKriterleriCevir(List<string> kriterListesi)
        {
            StringBuilder str = new StringBuilder();
            foreach (string tmp in kriterListesi)
            {
                str.Append(tmp + ", ");
            }
            str.Remove(str.Length - 2, 2);
            return str;
        }
    }
}