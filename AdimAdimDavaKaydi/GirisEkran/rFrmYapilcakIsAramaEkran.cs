using System;
using System.Collections.Generic;
using System.Timers;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmYapilcakIsAramaEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public bool AraKararMi;

        public bool DurusmaMi;

        public bool GunlukIsMi;

        public bool HizliErisimdenMi;

        public bool NotMu;

        public bool ToplantiMi;

        public rFrmYapilcakIsAramaEkran()
        {
            InitializeComponent();
            ucYapilcakIsArama1.Sorgula += ucYapilcakIsArama1_Sorgula;
            ucYapilcakIsArama1.Temizle += ucYapilcakIsArama1_Temizle;
            ucGorevGrid1.KayitSilindi += ucGorevGrid1_KayitSilindi;
        }

        private void rFrmYapilcakIsAramaEkran_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer(10000);
            timer.Elapsed += timer_Elapsed;
            //timer.Start();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            if (HizliErisimdenMi)
            {
                ucYapilcakIsArama1.HizliErisimdenMi = HizliErisimdenMi;
                ucYapilcakIsArama1.AramaYap();
                //aramaSonuclarim = new List<AvukatProLib.Arama.AV001_TDI_BIL_I>();

                //if (DurusmaMi)
                //{
                //    foreach (AvukatProLib.Arama.AV001_TDI_BIL_I item in ucYapilcakIsArama1.aramaSonuclarim)
                //    {
                //        if (!string.IsNullOrEmpty(item.KATEGORI))
                //        {
                //            if (item.KATEGORI.Contains("DURUŞMA") || item.KATEGORI.Contains("SATIŞ") ||
                //                item.KATEGORI.Contains("KEŞİF"))
                //            {
                //                aramaSonuclarim.Add(item);
                //            }
                //            ucGorevGrid1.MyDataSource = aramaSonuclarim;
                //        }
                //    }
                //}
                //else if (AraKararMi)
                //{
                //    foreach (AvukatProLib.Arama.AV001_TDI_BIL_I item in ucYapilcakIsArama1.aramaSonuclarim)
                //    {
                //        if (!string.IsNullOrEmpty(item.KATEGORI))
                //        {
                //            if (item.KATEGORI.Contains("ARA KARAR"))
                //            {
                //                aramaSonuclarim.Add(item);
                //            }
                //            ucGorevGrid1.MyDataSource = aramaSonuclarim;
                //        }
                //    }
                //}
                //else if (ToplantiMi)
                //{
                //    foreach (AvukatProLib.Arama.AV001_TDI_BIL_I item in ucYapilcakIsArama1.aramaSonuclarim)
                //    {
                //        if (!string.IsNullOrEmpty(item.KATEGORI))
                //        {
                //            if (item.KATEGORI.Contains("TOPLANTI"))
                //            {
                //                aramaSonuclarim.Add(item);
                //            }
                //            ucGorevGrid1.MyDataSource = aramaSonuclarim;
                //        }
                //    }
                //}
                //else if (GunlukIsMi)
                //{
                //    foreach (AvukatProLib.Arama.AV001_TDI_BIL_I item in ucYapilcakIsArama1.aramaSonuclarim)
                //    {
                //        if (!string.IsNullOrEmpty(item.KATEGORI))
                //        {
                //            DateTime d = DateTime.Today.Date;
                //            if (item.BASLANGIC_TARIHI.Value.ToShortDateString() ==
                //                DateTime.Today.Date.ToShortDateString())
                //            {
                //                aramaSonuclarim.Add(item);
                //            }
                //            ucGorevGrid1.MyDataSource = aramaSonuclarim;
                //        }
                //    }
                //}
                //else if (NotMu)
                //{
                //    foreach (AvukatProLib.Arama.AV001_TDI_BIL_I item in ucYapilcakIsArama1.aramaSonuclarim)
                //    {
                //        if (!string.IsNullOrEmpty(item.KATEGORI))
                //        {
                //            if (item.KATEGORI.Contains("NOT"))
                //            {
                //                aramaSonuclarim.Add(item);
                //            }
                //            ucGorevGrid1.MyDataSource = aramaSonuclarim;
                //        }
                //    }
                //}
            }
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ucYapilcakIsArama1.HizliErisimdenMi = HizliErisimdenMi;
            ucYapilcakIsArama1.AramaYap();
            ucGorevGrid1.MyDataSource = null;
            ucGorevGrid1.MyDataSource = ucYapilcakIsArama1.aramaSonuclarim;
        }

        private void ucGorevGrid1_KayitSilindi(object sender, EventArgs e)
        {
            ucYapilcakIsArama1_Sorgula(this, new EventArgs());
        }

        private void ucYapilcakIsArama1_Sorgula(object sender, EventArgs e)
        {
            ucYapilcakIsArama1.HizliErisimdenMi = HizliErisimdenMi;
            ucYapilcakIsArama1.AramaYap();

            ucGorevGrid1.MyDataSource = ucYapilcakIsArama1.aramaSonuclarim;

            //#region -----Hızlı erişim Aç menüsü seçenekleri. -----MERVE

            //aramaSonuclarim = new List<AvukatProLib.Arama.AV001_TDI_BIL_I>();
            //if (DurusmaMi)
            //{
            //    foreach (AvukatProLib.Arama.AV001_TDI_BIL_I item in ucYapilcakIsArama1.aramaSonuclarim)
            //    {
            //        if (!string.IsNullOrEmpty(item.KATEGORI))
            //        {
            //            if (item.KATEGORI.Contains("DURUŞMA") || item.KATEGORI.Contains("SATIŞ") ||
            //                item.KATEGORI.Contains("KEŞİF"))
            //            {
            //                aramaSonuclarim.Add(item);
            //            }

            //            ucGorevGrid1.MyDataSource = aramaSonuclarim;
            //        }
            //    }
            //}

            //else if (AraKararMi)
            //{
            //    foreach (AvukatProLib.Arama.AV001_TDI_BIL_I item in ucYapilcakIsArama1.aramaSonuclarim)
            //    {
            //        if (!string.IsNullOrEmpty(item.KATEGORI))
            //        {
            //            if (item.KATEGORI.Contains("ARA KARAR"))
            //            {
            //                aramaSonuclarim.Add(item);
            //            }

            //            ucGorevGrid1.MyDataSource = aramaSonuclarim;
            //        }
            //    }
            //}

            //else if (ToplantiMi)
            //{
            //    foreach (AvukatProLib.Arama.AV001_TDI_BIL_I item in ucYapilcakIsArama1.aramaSonuclarim)
            //    {
            //        if (!string.IsNullOrEmpty(item.KATEGORI))
            //        {
            //            if (item.KATEGORI.Contains("TOPLANTI"))
            //            {
            //                aramaSonuclarim.Add(item);
            //            }

            //            ucGorevGrid1.MyDataSource = aramaSonuclarim;
            //        }
            //    }
            //}

            //else if (GunlukIsMi)
            //{
            //    foreach (AvukatProLib.Arama.AV001_TDI_BIL_I item in ucYapilcakIsArama1.aramaSonuclarim)
            //    {
            //        if (!string.IsNullOrEmpty(item.KATEGORI))
            //        {
            //            DateTime d = DateTime.Today.Date;
            //            if (item.BASLANGIC_TARIHI.Value.ToShortDateString() == DateTime.Today.Date.ToShortDateString())
            //            {
            //                aramaSonuclarim.Add(item);
            //            }

            //            ucGorevGrid1.MyDataSource = aramaSonuclarim;
            //        }
            //    }
            //}

            //else if (NotMu)
            //{
            //    foreach (AvukatProLib.Arama.AV001_TDI_BIL_I item in ucYapilcakIsArama1.aramaSonuclarim)
            //    {
            //        if (!string.IsNullOrEmpty(item.KATEGORI))
            //        {
            //            if (item.KATEGORI.Contains("NOT"))
            //            {
            //                aramaSonuclarim.Add(item);
            //            }

            //            ucGorevGrid1.MyDataSource = aramaSonuclarim;
            //        }
            //    }
            //}

            //else
            //    ucGorevGrid1.MyDataSource = ucYapilcakIsArama1.aramaSonuclarim;
            //;

            //#endregion -----Hızlı erişim Aç menüsü seçenekleri. -----MERVE
        }

        private void ucYapilcakIsArama1_Temizle(object sender, EventArgs e)
        {
            ucGorevGrid1.MyDataSource = null;
        }
    }
}