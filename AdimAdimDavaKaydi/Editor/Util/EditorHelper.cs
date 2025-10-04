using AdimAdimDavaKaydi.Editor.Forms;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Editor.Util
{
    public enum CiktiAlinacakAlanTipi
    {
        Borclu, Alacakli, Avukat, Vekil, UcuncuSahis, TumTaraflar, AvukatveBorclular, BorclularveAlacaklilar, AlacaklilarVeAvukat, TumVekillerUcuncuSahisTarafVeAvukatlar, DosyaIleIlgiliTumCariler
    }

    public static class EditorHelper
    {
        /// <summary>
        /// Sablon ayar�na gore sablonlardan uretir ve geriye dondurur
        /// </summary>
        /// <param name="ayar">Sablon Ayarlari</param>
        /// <param name="Kayit">Hangi kay�t �zerinden ��kt� al�nacak</param>
        /// <returns>Al�nabilecek ��kt�lar</returns>
        public static List<Ciktilar> GetirAyaraGoreSablonlari(AV001_TDIE_BIL_SABLON_RAPOR_YAZDIRMA_AYARLARI ayar, IEntity Kayit)
        {
            List<Ciktilar> Donecek = new List<Ciktilar>();
            int UanKosulCounter = 0;

            //yazd�rma ayar�ndaki kosullar� dolas�p
            for (int j = 0; j < ayar.TDIE_KOD_SABLON_RAPOR_YAZDIRMA_AYAR_KOSULCollection.Count; j++)
            {
                //��kt�s� al�nacakm�
                if (ayar.TDIE_KOD_SABLON_RAPOR_YAZDIRMA_AYAR_KOSULCollection[j].YAZDIRILSIN_MI.HasValue ? ayar.TDIE_KOD_SABLON_RAPOR_YAZDIRMA_AYAR_KOSULCollection[j].YAZDIRILSIN_MI.Value : false)
                {
                    // kosulun kay�t ile uygunlu�unu kontrol ediyoruz
                    if (KosulIleKayitUyusuyormu(ayar.TDIE_KOD_SABLON_RAPOR_YAZDIRMA_AYAR_KOSULCollection[j], Kayit))
                    {
                        UanKosulCounter++;
                    }
                }
                if (UanKosulCounter == ayar.TDIE_KOD_SABLON_RAPOR_YAZDIRMA_AYAR_KOSULCollection.Count)
                {
                    Donecek.AddRange(GetirCiktiAl�nacakAlanlaraGoreCiktilar(ayar, Kayit));
                }
            }
            return Donecek;
        }

        public static AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR GetSablonRaporView(AV001_TDIE_BIL_SABLON_RAPOR rapor) // Okan 20.07.2010
        {
            AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR view = new AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR();
            view.ID = rapor.ID;
            view.ACIKLAMA = rapor.ACIKLAMA;
            view.AD = rapor.AD;
            view.ADLI_BIRIM_BOLUM_ID = rapor.ADLI_BIRIM_BOLUM_ID;
            view.ADLI_BIRIM_GOREV_ID = rapor.ADLI_BIRIM_GOREV_ID;
            view.DAVA_NEDEN_ID = rapor.DAVA_NEDEN_ID;
            view.DAVA_TALEP_ID = rapor.DAVA_TALEP_ID;
            view.DEGISKENI_VARMI = rapor.DEGISKENI_VARMI;
            view.DIL_ID = rapor.DIL_ID;
            view.DOSYA_ADRES = rapor.DOSYA_ADRES;
            view.FORM_ORNEK_ID = rapor.FORM_ORNEK_ID;
            view.KATEGORI_ID = rapor.KATEGORI_ID;
            view.KONTROL_KIM_ID = rapor.KONTROL_KIM_ID;
            view.MODUL_ID = rapor.MODUL_ID;
            view.RAPOR_TIP_ID = rapor.RAPOR_TIP_ID;
            view.SEKTOR_ID = rapor.SEKTOR_ID;
            view.SOZLESME_TIP_ID = rapor.SOZLESME_TIP_ID;
            view.SUBE_KOD_ID = rapor.SUBE_KOD_ID;
            view.TAKIP_TALEP_KONU_ID = rapor.TAKIP_TALEP_KONU_ID;
            view.THUMBNAIL = rapor.THUMBNAIL;
            return view;
        }

        private static List<Ciktilar> AvukataGoreCiktilar(IEntity Kayit, AV001_TDIE_BIL_SABLON_RAPOR anaRapor, AV001_TDIE_BIL_SABLON_RAPOR Rapor)
        {
            List<Ciktilar> Donecek = new List<Ciktilar>();

            if (Kayit is AV001_TI_BIL_FOY)
            {
                AV001_TI_BIL_FOY icra = (Kayit as AV001_TI_BIL_FOY);
                for (int i = 0; i < icra.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count; i++)
                {
                    Ciktilar ckt = new Ciktilar();

                    //ckt.AnaRapor = anaRapor;
                    //ckt.Rapor = Rapor;
                    ckt.UyapMi = false;
                    ckt.Kayit = Kayit;
                    ckt.Tarafi.IcraSorumluAvukat = icra.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[i];
                    Donecek.Add(ckt);
                }
            }

            if (Kayit is AV001_TD_BIL_FOY)
            {
                AV001_TD_BIL_FOY dava = (Kayit as AV001_TD_BIL_FOY);
            }

            return Donecek;
        }

        /// <summary>
        /// kosul uzerindeki c�kt�n�n al�nacag� alana gore c�kt�lar urtetir
        /// </summary>
        /// <param name="Kosul">kosul </param>
        /// <param name="Kayit">hangi kay�ttan c�kt� uretilecek </param>
        /// <param name="anaRapor">c�kt�lar�n uretilexce�i ana kay�t</param>
        /// <param name="Rapor"></param>
        /// <returns></returns>
        private static List<Ciktilar> CiktisiAlinacakAlanaGoreCikti(TDIE_KOD_SABLON_RAPOR_YAZDIRMA_AYAR_KOSUL Kosul, IEntity Kayit, AV001_TDIE_BIL_SABLON_RAPOR anaRapor, AV001_TDIE_BIL_SABLON_RAPOR Rapor)
        {
            List<Ciktilar> donecek = new List<Ciktilar>();
            ////�IKTININ hangi alandaki de�er say�s�nda al�naca��n� belirten alan tipidir.
            CiktiAlinacakAlanTipi AlanTipi = (CiktiAlinacakAlanTipi)Enum.ToObject(typeof(CiktiAlinacakAlanTipi), Kosul.CIKTI_SAYISI_ALINACAK_ALACAK);

            if (Kayit is AV001_TI_BIL_FOY)
            {
                AV001_TI_BIL_FOY icra = (Kayit as AV001_TI_BIL_FOY);
                for (int i = 0; i < icra.AV001_TI_BIL_FOY_TARAFCollection.Count; i++)
                {
                    ///alacakl� say�s� kadar
                    if (icra.AV001_TI_BIL_FOY_TARAFCollection[i].TAKIP_EDEN_MI &&
                        AlanTipi == CiktiAlinacakAlanTipi.Alacakli)
                    {
                        Ciktilar ckt = new Ciktilar();

                        //ckt.AnaRapor = anaRapor;
                        //ckt.Rapor = Rapor;
                        ckt.UyapMi = false;
                        ckt.Kayit = Kayit;
                        ckt.Tarafi.IcraTaraf = icra.AV001_TI_BIL_FOY_TARAFCollection[i];
                        donecek.Add(ckt);
                    }

                    //borclu say�s� kadar
                    if (!icra.AV001_TI_BIL_FOY_TARAFCollection[i].TAKIP_EDEN_MI &&
                        AlanTipi == CiktiAlinacakAlanTipi.Borclu)
                    {
                        Ciktilar ckt = new Ciktilar();

                        //ckt.AnaRapor = anaRapor;
                        //ckt.Rapor = Rapor;
                        ckt.UyapMi = false;
                        ckt.Kayit = Kayit;
                        ckt.Tarafi.IcraTaraf = icra.AV001_TI_BIL_FOY_TARAFCollection[i];
                        donecek.Add(ckt);
                    }

                    ///Borclu + alacakl�
                    if (AlanTipi == CiktiAlinacakAlanTipi.BorclularveAlacaklilar)
                    {
                        Ciktilar ckt = new Ciktilar();

                        //ckt.AnaRapor = anaRapor;
                        //ckt.Rapor = Rapor;
                        ckt.UyapMi = false;
                        ckt.Kayit = Kayit;
                        ckt.Tarafi.IcraTaraf = icra.AV001_TI_BIL_FOY_TARAFCollection[i];
                        donecek.Add(ckt);
                    }

                    //Tum dosya carileri
                    if (AlanTipi == CiktiAlinacakAlanTipi.DosyaIleIlgiliTumCariler)
                    {
                        Ciktilar ckt = new Ciktilar();

                        //ckt.AnaRapor = anaRapor;
                        //ckt.Rapor = Rapor;
                        ckt.UyapMi = false;
                        ckt.Kayit = Kayit;
                        ckt.Tarafi.IcraTaraf = icra.AV001_TI_BIL_FOY_TARAFCollection[i];
                        donecek.Add(ckt);

                        donecek.AddRange(VekileGoreCiktilar(icra.AV001_TI_BIL_FOY_TARAFCollection[i], Kayit, anaRapor, Rapor).ToArray());
                    }

                    //T�m taraflar
                    if (AlanTipi == CiktiAlinacakAlanTipi.TumTaraflar)
                    {
                        Ciktilar ckt = new Ciktilar();

                        //ckt.AnaRapor = anaRapor;
                        //ckt.Rapor = Rapor;
                        ckt.UyapMi = false;
                        ckt.Kayit = Kayit;
                        ckt.Tarafi.IcraTaraf = icra.AV001_TI_BIL_FOY_TARAFCollection[i];
                        donecek.Add(ckt);
                        donecek.AddRange(VekileGoreCiktilar(icra.AV001_TI_BIL_FOY_TARAFCollection[i], Kayit, anaRapor, Rapor).ToArray());
                    }

                    ///Vekiller + ucuncu Sahislar + Taraflar + Avukatlar
                    if (AlanTipi == CiktiAlinacakAlanTipi.TumVekillerUcuncuSahisTarafVeAvukatlar)
                    {
                        Ciktilar ckt = new Ciktilar();

                        //ckt.AnaRapor = anaRapor;
                        //ckt.Rapor = Rapor;
                        ckt.UyapMi = false;
                        ckt.Kayit = Kayit;
                        ckt.Tarafi.IcraTaraf = icra.AV001_TI_BIL_FOY_TARAFCollection[i];
                        donecek.Add(ckt);
                        donecek.AddRange(VekileGoreCiktilar(icra.AV001_TI_BIL_FOY_TARAFCollection[i], Kayit, anaRapor, Rapor).ToArray());
                    }
                    if (AlanTipi == CiktiAlinacakAlanTipi.Vekil)
                    {
                        donecek.AddRange(VekileGoreCiktilar(icra.AV001_TI_BIL_FOY_TARAFCollection[i], Kayit, anaRapor, Rapor).ToArray());
                    }
                }

                ///Sorumlu Avukatlara g�re.
                if (AlanTipi == CiktiAlinacakAlanTipi.AlacaklilarVeAvukat || AlanTipi == CiktiAlinacakAlanTipi.Avukat || AlanTipi == CiktiAlinacakAlanTipi.AvukatveBorclular || AlanTipi == CiktiAlinacakAlanTipi.TumVekillerUcuncuSahisTarafVeAvukatlar)
                {
                    donecek.AddRange(AvukataGoreCiktilar(Kayit, anaRapor, Rapor));
                }

                if (AlanTipi == CiktiAlinacakAlanTipi.TumVekillerUcuncuSahisTarafVeAvukatlar)
                {
                    donecek.AddRange(UcuncuSahislaraGoreCiktilar(Kayit, anaRapor, Rapor).ToArray());
                }
            }
            return donecek;
        }

        /// <summary>
        /// ��kt�s� al�nacak alan degrine gore  c�kt�lar� uretir
        /// </summary>
        /// <param name="ayar">hangi ayar uzerinden al�ns�n</param>
        /// <param name="Kayit">hangi kay�t �zerinden c�kt�lar�n al�naca��</param>
        /// <returns>�retilen ��kt�lar</returns>
        private static List<Ciktilar> GetirCiktiAl�nacakAlanlaraGoreCiktilar(AV001_TDIE_BIL_SABLON_RAPOR_YAZDIRMA_AYARLARI ayar, IEntity Kayit)
        {
            List<Ciktilar> Donecek = new List<Ciktilar>();

            //Ayar�n kosullar�
            for (int i = 0; i < ayar.TDIE_KOD_SABLON_RAPOR_YAZDIRMA_AYAR_KOSULCollection.Count; i++)
            {
                //��kt� say�s� kadar c�kt� �ret
                for (int y = 0; y < ayar.TDIE_KOD_SABLON_RAPOR_YAZDIRMA_AYAR_KOSULCollection[i].CIKTI_SAYISI; y++)
                {
                    Ciktilar ckt = new Ciktilar();

                    //ckt.AnaRapor = ayar.SABLON_IDSource;
                    //ckt.Rapor = ayar.YAZDIRILACAK_SABLON_IDSource;
                    ckt.Kayit = Kayit;
                    ckt.UyapMi = false;
                    Donecek.Add(ckt);
                }

                ///��kt�y� �retece�imiz kay�t �zerindeki alana g�re ��kt�y� �ret ve donecek degere ekle .
                Donecek.AddRange(CiktisiAlinacakAlanaGoreCikti(ayar.TDIE_KOD_SABLON_RAPOR_YAZDIRMA_AYAR_KOSULCollection[i], Kayit, ayar.SABLON_IDSource, ayar.YAZDIRILACAK_SABLON_IDSource).ToArray());
            }
            return Donecek;
        }

        /// <summary>
        /// Ayara bagl� kosul ile ��kt� bilgilerinin al�naca�� kay�t birbirleri ile uyu�uyormu
        /// </summary>
        /// <param name="kosul">uyusmas� gereken kosul</param>
        /// <param name="Kayit">��kt�n�n al�naca�� kay�t</param>
        /// <returns>uygunluk varsa true yoksa false</returns>
        private static bool KosulIleKayitUyusuyormu(TDIE_KOD_SABLON_RAPOR_YAZDIRMA_AYAR_KOSUL kosul, IEntity Kayit)
        {
            ///kosula uygunluk soz konusumu ?
            bool uyarmi = true;

            /// kars�last�rma sonucuna uyan sozlesmelerin say�s�
            int SozlesmeKarsilastirmaCounter = 0;

            //kats�last�rmalara uygun alacak kalem say�s�
            int AlacakNedenKArsilastirmaCounter = 0;
            if (Kayit is AV001_TI_BIL_FOY)
            {
                AV001_TI_BIL_FOY icra = (Kayit as AV001_TI_BIL_FOY);

                //fom �rnek no kontrolu
                if (icra.FORM_TIP_ID.HasValue)
                {
                    if (icra.FORM_TIP_ID.Value == kosul.FORM_ORNEK_ID)
                    {
                        uyarmi = false;
                    }
                }

                //s�zle�me alt tip kontrolu
                for (int s = 0; s < icra.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME.Count; s++)
                {
                    if (icra.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME[s].ALT_TIP_ID == kosul.SOZLESME_ALT_TIPI_ID)
                    {
                        SozlesmeKarsilastirmaCounter++;
                    }
                }
                if (SozlesmeKarsilastirmaCounter == 0)
                {
                    uyarmi = false;
                }

                //alacak neden kontrolu
                for (int a = 0; a < icra.AV001_TI_BIL_ALACAK_NEDENCollection.Count; a++)
                {
                    if (icra.AV001_TI_BIL_ALACAK_NEDENCollection[a].ALACAK_NEDEN_KOD_ID.HasValue)
                    {
                        if (icra.AV001_TI_BIL_ALACAK_NEDENCollection[a].ALACAK_NEDEN_KOD_ID.Value == kosul.ALACAK_NEDEN_ID)
                        {
                            AlacakNedenKArsilastirmaCounter++;
                        }
                    }
                }
                if (AlacakNedenKArsilastirmaCounter == 0)
                {
                    uyarmi = false;
                }
            }

            return uyarmi;
        }

        private static List<Ciktilar> UcuncuSahislaraGoreCiktilar(IEntity Kayit, AV001_TDIE_BIL_SABLON_RAPOR anaRapor, AV001_TDIE_BIL_SABLON_RAPOR Rapor)
        {
            List<Ciktilar> Donecek = new List<Ciktilar>();

            if (Kayit is AV001_TI_BIL_FOY)
            {
                AV001_TI_BIL_FOY icra = (Kayit as AV001_TI_BIL_FOY);
                for (int i = 0; i < icra.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count; i++)
                {
                    Ciktilar ckt = new Ciktilar();

                    //ckt.AnaRapor = anaRapor;
                    //ckt.Rapor = Rapor;
                    ckt.UyapMi = false;
                    ckt.Kayit = Kayit;
                    ckt.Tarafi.TebligatMuhatap = icra.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[i];
                    Donecek.Add(ckt);
                }
            }

            return Donecek;
        }

        private static List<Ciktilar> VekileGoreCiktilar(AV001_TI_BIL_FOY_TARAF Taraf, IEntity Kayit, AV001_TDIE_BIL_SABLON_RAPOR anaRapor, AV001_TDIE_BIL_SABLON_RAPOR Rapor)
        {
            List<Ciktilar> Donecek = new List<Ciktilar>();

            for (int i = 0; i < Taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection.Count; i++)
            {
                Ciktilar ckt = new Ciktilar();

                //ckt.AnaRapor = anaRapor;
                //ckt.Rapor = Rapor;
                ckt.UyapMi = false;
                ckt.Kayit = Kayit;
                ckt.Tarafi.IcraVekil = Taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection[i];
                Donecek.Add(ckt);
            }

            return Donecek;
        }
    }
}