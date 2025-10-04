using AdimAdimDavaKaydi.Entegrasyon.Classes;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AdimAdimDavaKaydi.Entegrasyon
{
    public static class BindXML
    {
        public static DosyaBilgileri SetDosyaBilgileri(XElement doc)
        {
            DosyaBilgileri dosya = new DosyaBilgileri();
            dosya.IsSelected = true;
            if (doc.Element("FoyNo") != null) dosya.FoyNo = doc.Element("FoyNo").Value;
            if (doc.Element("Banka") != null) dosya.Banka = doc.Element("Banka").Value;
            if (doc.Element("Sube") != null) dosya.Sube = doc.Element("Sube").Value;
            if (doc.Element("Birimi") != null) dosya.Birimi = doc.Element("Birimi").Value;
            if (doc.Element("KrediGrubu") != null) dosya.KrediGrubu = doc.Element("KrediGrubu").Value;
            if (doc.Element("KrediTipi") != null) dosya.KrediTipi = doc.Element("KrediTipi").Value;
            if (doc.Element("DosyaYeri") != null) dosya.DosyaYeri = doc.Element("DosyaYeri").Value;
            if (doc.Element("KrediBorclusu") != null) dosya.Musteri = doc.Element("KrediBorclusu").Value;
            if (doc.Element("MusteriNo") != null) dosya.MusteriNo = doc.Element("MusteriNo").Value;
            if (doc.Element("SorumluAvukat") != null) dosya.SorumluAvukat = doc.Element("SorumluAvukat").Value;
            if (doc.Element("IzleyenAvukat") != null) dosya.IzleyenAvukat = doc.Element("IzleyenAvukat").Value;

            #region Tasfiye Hesap

            var tasfiyeHesap = doc.Descendants("TasfiyeHesap");

            #region Nakit

            var nakitAlacaklar = tasfiyeHesap.Descendants("NAKIT_ALACAKLAR");
            var kredi = nakitAlacaklar.Descendants("KREDI");
            foreach (var nakitAlacak in kredi)
            {
                if (nakitAlacak.Value.Length == 0) continue;

                NakitAlacak nAlacak = new NakitAlacak();
                nAlacak.IsSelected = true;
                if (nakitAlacak.Element("AlacakNedeni") != null) nAlacak.AlacakTipi = nakitAlacak.Element("AlacakNedeni").Value;
                if (nakitAlacak.Element("Tutar") != null) nAlacak.Tutari = Convert.ToDecimal(nakitAlacak.Element("Tutar").Value == "" ? "0" : nakitAlacak.Element("Tutar").Value.ToString().Replace('.', ','));
                if (nakitAlacak.Element("TutarParaBirimi") != null) nAlacak.TutariParaBirimi = nakitAlacak.Element("TutarParaBirimi").Value;
                if (nakitAlacak.Element("BSMVHesaplansinmi") != null) nAlacak.BSMVHesaplansin = Convert.ToBoolean(nakitAlacak.Element("BSMVHesaplansinmi").Value == "" ? null : nakitAlacak.Element("BSMVHesaplansinmi").Value);
                if (nakitAlacak.Element("VadeTarihi") != null) nAlacak.VadeTarihi = Convert.ToDateTime(nakitAlacak.Element("VadeTarihi").Value == "" ? null : nakitAlacak.Element("VadeTarihi").Value);
                if (nakitAlacak.Element("AlacakFaizTip") != null) nAlacak.FaizTipi = nakitAlacak.Element("AlacakFaizTip").Value;
                if (nakitAlacak.Element("UygulanacakFaizOrani") != null) nAlacak.FaizOrani = Convert.ToDouble(nakitAlacak.Element("UygulanacakFaizOrani").Value == "" ? "0" : nakitAlacak.Element("UygulanacakFaizOrani").Value.ToString().Replace('.', ','));
                if (nakitAlacak.Element("AktifFaizOrani") != null) nAlacak.AkdiFaizOrani = Convert.ToDouble(nakitAlacak.Element("AktifFaizOrani").Value == "" ? "0" : nakitAlacak.Element("AktifFaizOrani").Value.ToString().Replace('.', ','));
                if (nakitAlacak.Element("ReferansNo") != null) nAlacak.ReferansNo = nakitAlacak.Element("ReferansNo").Value;
                if (nakitAlacak.Element("ReferansNo2") != null) nAlacak.ReferansNo2 = nakitAlacak.Element("ReferansNo2").Value;
                var krediTaraf = nakitAlacak.Descendants("KREDI_TARAF");
                foreach (var nakitAlacakTaraf in krediTaraf)
                {
                    if (nakitAlacakTaraf.Value.Length == 0) continue;

                    AlacakTaraf taraf = new AlacakTaraf();

                    if (nakitAlacakTaraf.Element("MusteriNo") != null) taraf.MusteriNo = nakitAlacakTaraf.Element("MusteriNo").Value;
                    if (nakitAlacakTaraf.Element("Musteri") != null) taraf.Musteri = nakitAlacakTaraf.Element("Musteri").Value;
                    if (nakitAlacakTaraf.Element("TarafSifat") != null) taraf.TarafSifat = nakitAlacakTaraf.Element("TarafSifat").Value;
                    if (nakitAlacakTaraf.Element("IhtarTarihi") != null) taraf.IhtarTarihi = Convert.ToDateTime(nakitAlacakTaraf.Element("IhtarTarihi").Value == "" ? null : nakitAlacakTaraf.Element("IhtarTarihi").Value);
                    if (nakitAlacakTaraf.Element("IhtarTebligTarihi") != null) taraf.IhtarTebligTarihi = Convert.ToDateTime(nakitAlacakTaraf.Element("IhtarTebligTarihi").Value == "" ? null : nakitAlacakTaraf.Element("IhtarTebligTarihi").Value);
                    if (nakitAlacakTaraf.Element("SorumluOlunanMiktar") != null) taraf.SorumluOlunanMiktar = Convert.ToDecimal(nakitAlacakTaraf.Element("SorumluOlunanMiktar").Value == "" ? "0" : nakitAlacakTaraf.Element("SorumluOlunanMiktar").Value.ToString().Replace('.', ','));
                    if (nakitAlacakTaraf.Element("SorumluOlunanMiktarParaBirimi") != null) taraf.SorumluOlunanMiktarParaBirimi = nakitAlacakTaraf.Element("SorumluOlunanMiktarParaBirimi").Value;

                    if (nAlacak.Taraflari == null) nAlacak.Taraflari = new List<AlacakTaraf>();
                    nAlacak.Taraflari.Add(taraf);
                }
                if (dosya.NakitAlacaklar == null) dosya.NakitAlacaklar = new List<NakitAlacak>();
                dosya.NakitAlacaklar.Add(nAlacak);
            }

            #endregion Nakit

            #region Gayrinakit

            var gNakitAlacaklar = tasfiyeHesap.Descendants("GAYRI_NAKDI_ALACAKLAR");
            var krediGNakit = gNakitAlacaklar.Descendants("KREDI");
            foreach (var gayrinakitAlacak in krediGNakit)
            {
                if (gayrinakitAlacak.Value.Length == 0) continue;

                GayriNakitAlacak gNakit = new GayriNakitAlacak();

                if (gayrinakitAlacak.Element("AlacakNedeni") != null) gNakit.AlacakTipi = gayrinakitAlacak.Element("AlacakNedeni").Value;
                if (gayrinakitAlacak.Element("Tutar") != null) gNakit.Tutari = Convert.ToDecimal(gayrinakitAlacak.Element("Tutar").Value == "" ? "0" : gayrinakitAlacak.Element("Tutar").Value);
                if (gayrinakitAlacak.Element("TutarParaBirimi") != null) gNakit.TutariParaBirimi = gayrinakitAlacak.Element("TutarParaBirimi").Value;
                if (gayrinakitAlacak.Element("VerildigiTarih") != null) gNakit.VeridildigiTarih = Convert.ToDateTime(gayrinakitAlacak.Element("VerildigiTarih").Value == "" ? null : gayrinakitAlacak.Element("VerildigiTarih").Value);
                if (gayrinakitAlacak.Element("VerilisNo") != null) gNakit.VerilisNo = gayrinakitAlacak.Element("VerilisNo").Value;
                if (gayrinakitAlacak.Element("Muhatabi") != null) gNakit.Muhatabi = gayrinakitAlacak.Element("Muhatabi").Value;
                if (gayrinakitAlacak.Element("BSMVHesaplansinmi") != null) gNakit.BSMVHesaplansin = Convert.ToBoolean(gayrinakitAlacak.Element("BSMVHesaplansinmi").Value == "" ? null : gayrinakitAlacak.Element("BSMVHesaplansinmi").Value);
                if (gayrinakitAlacak.Element("ReferansNo2") != null) gNakit.ReferansNo2 = gayrinakitAlacak.Element("ReferansNo2").Value;
                if (gayrinakitAlacak.Element("CekAdedi") != null) gNakit.CekAdedi = Convert.ToInt32(gayrinakitAlacak.Element("CekAdedi").Value == "" ? "0" : gayrinakitAlacak.Element("CekAdedi").Value);
                if (gayrinakitAlacak.Element("CekYapragiILKSorumlulukMiktari") != null) gNakit.CekYapragiILKSorumlulukMiktari = Convert.ToDecimal(gayrinakitAlacak.Element("CekYapragiILKSorumlulukMiktari").Value == "" ? "0" : gayrinakitAlacak.Element("CekYapragiILKSorumlulukMiktari").Value);
                if (gayrinakitAlacak.Element("CekYapragiILKSorumlulukMiktariParaBirimi") != null) gNakit.CekYapragiILKSorumlulukMiktariParaBirimi = gayrinakitAlacak.Element("CekYapragiILKSorumlulukMiktariParaBirimi").Value;
                if (gayrinakitAlacak.Element("CekYapragiSONSorumlulukMiktari") != null) gNakit.CekYapragiILKSorumlulukMiktari = Convert.ToDecimal(gayrinakitAlacak.Element("CekYapragiSONSorumlulukMiktari").Value == "" ? "0" : gayrinakitAlacak.Element("CekYapragiSONSorumlulukMiktari").Value);
                if (gayrinakitAlacak.Element("CekYapragiSONSorumlulukMiktariParaBirimi") != null) gNakit.CekYapragiILKSorumlulukMiktariParaBirimi = gayrinakitAlacak.Element("CekYapragiSONSorumlulukMiktariParaBirimi").Value;

                var hareketler = gayrinakitAlacak.Descendants("HAREKETLER");
                var hareket = hareketler.Descendants("HAREKET");
                foreach (var gNakitHareket in hareket)
                {
                    if (gNakitHareket.Value.Length == 0) continue;

                    GayrinakitHareket newHareket = new GayrinakitHareket();

                    if (gNakitHareket.Element("TazminTarihi") != null) newHareket.TazminTarihi = Convert.ToDateTime(gNakitHareket.Element("TazminTarihi").Value == "" ? null : gNakitHareket.Element("TazminTarihi").Value);
                    if (gNakitHareket.Element("CekTazminSayisi") != null) newHareket.CekTazminSayisi = Convert.ToInt32(gNakitHareket.Element("CekTazminSayisi").Value == "" ? "0" : gNakitHareket.Element("CekTazminSayisi").Value);
                    if (gNakitHareket.Element("TazminMiktari") != null) newHareket.TazminMikari = Convert.ToDecimal(gNakitHareket.Element("TazminMiktari").Value == "" ? "0" : gNakitHareket.Element("TazminMiktari").Value);
                    if (gNakitHareket.Element("TazminMiktariParaBirimi") != null) newHareket.TazminMiktariParaBirimi = gNakitHareket.Element("TazminMiktariParaBirimi").Value;
                    if (gNakitHareket.Element("IadeTarihi") != null) newHareket.IadeTarihi = Convert.ToDateTime(gNakitHareket.Element("IadeTarihi").Value == "" ? null : gNakitHareket.Element("IadeTarihi").Value);
                    if (gNakitHareket.Element("CekIadeSayisi") != null) newHareket.CekIadeSayisi = Convert.ToInt32(gNakitHareket.Element("CekIadeSayisi").Value == "" ? "0" : gNakitHareket.Element("CekIadeSayisi").Value);
                    if (gNakitHareket.Element("IadeMiktari") != null) newHareket.IadeMiktari = Convert.ToDecimal(gNakitHareket.Element("IadeMiktari").Value == "" ? "0" : gNakitHareket.Element("IadeMiktari").Value);
                    if (gNakitHareket.Element("IadeMiktariParaBirimi") != null) newHareket.IadeMiktariParaBirimi = gNakitHareket.Element("IadeMiktariParaBirimi").Value;
                    if (gNakitHareket.Element("DepoTarihi") != null) newHareket.DepoTarihi = Convert.ToDateTime(gNakitHareket.Element("DepoTarihi").Value == "" ? null : gNakitHareket.Element("DepoTarihi").Value);
                    if (gNakitHareket.Element("CekDepoSayisi") != null) newHareket.CekDepoSayisi = Convert.ToInt32(gNakitHareket.Element("CekDepoSayisi").Value == "" ? "0" : gNakitHareket.Element("CekDepoSayisi").Value);
                    if (gNakitHareket.Element("DepoMiktari") != null) newHareket.DepoMikari = Convert.ToDecimal(gNakitHareket.Element("DepoMiktari").Value == "" ? "0" : gNakitHareket.Element("DepoMiktari").Value);
                    if (gNakitHareket.Element("DepoMiktariParaBirimi") != null) newHareket.DepoMiktariParaBirimi = gNakitHareket.Element("DepoMiktariParaBirimi").Value;

                    if (gNakit.Hareketler == null) gNakit.Hareketler = new List<GayrinakitHareket>();
                    gNakit.Hareketler.Add(newHareket);
                }

                var krediTarafGNakit = gayrinakitAlacak.Descendants("KREDI_TARAF");
                foreach (var gayrinakitalacakTaraf in krediTarafGNakit)
                {
                    if (gayrinakitalacakTaraf.Value.Length == 0) continue;

                    AlacakTaraf taraf = new AlacakTaraf();

                    if (gayrinakitalacakTaraf.Element("MusteriNo") != null) taraf.MusteriNo = gayrinakitalacakTaraf.Element("MusteriNo").Value;
                    if (gayrinakitalacakTaraf.Element("Musteri") != null) taraf.Musteri = gayrinakitalacakTaraf.Element("Musteri").Value;
                    if (gayrinakitalacakTaraf.Element("TarafSifat") != null) taraf.TarafSifat = gayrinakitalacakTaraf.Element("TarafSifat").Value;
                    if (gayrinakitalacakTaraf.Element("IhtarTarihi") != null) taraf.IhtarTarihi = Convert.ToDateTime(gayrinakitalacakTaraf.Element("IhtarTarihi").Value == "" ? null : gayrinakitalacakTaraf.Element("IhtarTarihi").Value);
                    if (gayrinakitalacakTaraf.Element("IhtarTebligTarihi") != null) taraf.IhtarTebligTarihi = Convert.ToDateTime(gayrinakitalacakTaraf.Element("IhtarTebligTarihi").Value == "" ? null : gayrinakitalacakTaraf.Element("IhtarTebligTarihi").Value);
                    if (gayrinakitalacakTaraf.Element("SorumluOlunanMiktar") != null) taraf.SorumluOlunanMiktar = Convert.ToDecimal(gayrinakitalacakTaraf.Element("SorumluOlunanMiktar").Value == "" ? "0" : gayrinakitalacakTaraf.Element("SorumluOlunanMiktar").Value);
                    if (gayrinakitalacakTaraf.Element("SorumluOlunanMiktarParaBirimi") != null) taraf.SorumluOlunanMiktarParaBirimi = gayrinakitalacakTaraf.Element("SorumluOlunanMiktarParaBirimi").Value;

                    if (gNakit.Taraflari == null) gNakit.Taraflari = new List<AlacakTaraf>();
                    gNakit.Taraflari.Add(taraf);
                }
                if (dosya.GayriNakitAlacaklar == null) dosya.GayriNakitAlacaklar = new List<GayriNakitAlacak>();
                dosya.GayriNakitAlacaklar.Add(gNakit);
            }

            #endregion Gayrinakit

            #region Bono

            var bonolar = tasfiyeHesap.Descendants("BONOLAR");
            var bono = doc.Descendants("BONO");
            foreach (var bonoItem in bono)
            {
                if (bonoItem.Value.Length == 0) continue;

                Bono newBono = new Bono();

                if (bonoItem.Element("ReferansNumarası") != null) newBono.ReferansNo = bonoItem.Element("ReferansNumarası").Value;
                if (bonoItem.Element("Durum") != null) newBono.Durum = bonoItem.Element("Durum").Value == "" ? "0" : bonoItem.Element("Durum").Value;
                if (bonoItem.Element("EvrakTazminTarihi") != null) newBono.EvrakTazminTarihi = Convert.ToDateTime(bonoItem.Element("EvrakTazminTarihi").Value == "" ? null : bonoItem.Element("EvrakTazminTarihi").Value);
                if (bonoItem.Element("EvrakVadeTarihi") != null) newBono.EvrakVadeTarihi = Convert.ToDateTime(bonoItem.Element("EvrakVadeTarihi").Value == "" ? null : bonoItem.Element("EvrakVadeTarihi").Value);
                if (bonoItem.Element("Tutar") != null) newBono.Tutari = Convert.ToDecimal(bonoItem.Element("Tutar").Value == "" ? "0" : bonoItem.Element("Tutar").Value);
                if (bonoItem.Element("TutarParaBirimi") != null) newBono.TutariParaBirimi = bonoItem.Element("TutarParaBirimi").Value;
                var bonoTaraf = bonoItem.Descendants("BONO_TARAF");
                foreach (var bonoTarafItem in bonoTaraf)
                {
                    if (bonoTarafItem.Value.Length == 0) continue;
                    Taraf taraf = new Taraf();

                    if (bonoTarafItem.Element("TarafSifat") != null) taraf.TarafSifat = bonoTarafItem.Element("TarafSifat").Value;
                    if (bonoTarafItem.Element("MusteriNo") != null) taraf.MusteriNo = bonoTarafItem.Element("MusteriNo").Value;
                    if (bonoTarafItem.Element("Musteri") != null) taraf.Musteri = bonoTarafItem.Element("Musteri").Value;

                    if (newBono.Taraflar == null) newBono.Taraflar = new List<Taraf>();
                    newBono.Taraflar.Add(taraf);
                }
                if (dosya.Bonolar == null) dosya.Bonolar = new List<Bono>();
                dosya.Bonolar.Add(newBono);
            }

            #endregion Bono

            #region Çek

            var cekler = tasfiyeHesap.Descendants("CEKLER");
            var cek = doc.Descendants("CEK");
            foreach (var cekItem in cek)
            {
                if (cekItem.Value.Length == 0) continue;

                Cek newCek = new Cek();

                if (cekItem.Element("ReferansNumarası") != null) newCek.ReferanNo = cekItem.Element("ReferansNumarası").Value;
                if (cekItem.Element("Durum") != null) newCek.Durum = cekItem.Element("Durum").Value;
                if (cekItem.Element("EvrakVadeTarihi") != null) newCek.VadeTarihi = Convert.ToDateTime(cekItem.Element("EvrakVadeTarihi").Value == "" ? null : cekItem.Element("EvrakVadeTarihi").Value);
                if (cekItem.Element("KesideYeri") != null) newCek.KesideYeri = cekItem.Element("KesideYeri").Value;
                if (cekItem.Element("Banka") != null) newCek.Banka = cekItem.Element("Banka").Value;
                if (cekItem.Element("Sube") != null) newCek.Sube = cekItem.Element("Sube").Value;
                if (cekItem.Element("SorulduguTarih") != null) newCek.SorulduguTarih = Convert.ToDateTime(cekItem.Element("SorulduguTarih").Value == "" ? null : cekItem.Element("SorulduguTarih").Value);
                if (cekItem.Element("Tutar") != null) newCek.Tutari = Convert.ToDecimal(cekItem.Element("Tutar").Value == "" ? "0" : cekItem.Element("Tutar").Value);
                if (cekItem.Element("TutarParaBirimi") != null) newCek.TutariParaBirimi = cekItem.Element("TutarParaBirimi").Value;
                if (cekItem.Element("CekNo") != null) newCek.CekNo = cekItem.Element("CekNo").Value;
                if (cekItem.Element("HesapNo") != null) newCek.HesapNo = cekItem.Element("HesapNo").Value;
                if (cekItem.Element("OdemeYeri") != null) newCek.OdemeYeri = cekItem.Element("OdemeYeri").Value;

                var cekTaraf = cekItem.Descendants("CEK_TARAF");
                foreach (var cekTarafItem in cekTaraf)
                {
                    if (cekTarafItem.Value.Length == 0) continue;

                    Taraf taraf = new Taraf();

                    if (cekTarafItem.Element("TarafSifat") != null) taraf.TarafSifat = cekTarafItem.Element("TarafSifat").Value;
                    if (cekTarafItem.Element("MusteriNo") != null) taraf.MusteriNo = cekTarafItem.Element("MusteriNo").Value;
                    if (cekTarafItem.Element("Musteri") != null) taraf.Musteri = cekTarafItem.Element("Musteri").Value;

                    if (newCek.Taraflar == null) newCek.Taraflar = new List<Taraf>();
                    newCek.Taraflar.Add(taraf);
                }
                if (dosya.Cekler == null) dosya.Cekler = new List<Cek>();
                dosya.Cekler.Add(newCek);
            }

            #endregion Çek

            #region Munzam Senet

            var munzamSenetler = tasfiyeHesap.Descendants("MUNZAM_SENET");
            var munzam = doc.Descendants("SENETLER");
            foreach (var munzamItem in munzam)
            {
                if (munzamItem.Value.Length == 0) continue;

                Bono munzamSenet = new Bono();

                munzamSenet.MunzamSenetMi = true;
                if (munzamItem.Element("ReferansNumarası") != null) munzamSenet.ReferansNo = munzamItem.Element("ReferansNumarası").Value;
                if (munzamItem.Element("Durum") != null) munzamSenet.Durum = munzamItem.Element("Durum").Value == "" ? "0" : munzamItem.Element("Durum").Value;
                if (munzamItem.Element("EvrakTazminTarihi") != null) munzamSenet.EvrakTazminTarihi = Convert.ToDateTime(munzamItem.Element("EvrakTazminTarihi").Value == "" ? null : munzamItem.Element("EvrakTazminTarihi").Value);
                if (munzamItem.Element("EvrakVadeTarihi") != null) munzamSenet.EvrakVadeTarihi = Convert.ToDateTime(munzamItem.Element("EvrakVadeTarihi").Value == "" ? null : munzamItem.Element("EvrakVadeTarihi").Value);
                if (munzamItem.Element("Tutar") != null) munzamSenet.Tutari = Convert.ToDecimal(munzamItem.Element("Tutar").Value == "" ? "0" : munzamItem.Element("Tutar").Value);
                if (munzamItem.Element("TutarParaBirimi") != null) munzamSenet.TutariParaBirimi = munzamItem.Element("TutarParaBirimi").Value;
                var munzamTaraf = munzamItem.Descendants("SENET_TARAF");
                foreach (var munzamTarafItem in munzamTaraf)
                {
                    if (munzamTarafItem.Value.Length == 0) continue;

                    Taraf taraf = new Taraf();

                    if (munzamTarafItem.Element("TarafSifat") != null) taraf.TarafSifat = munzamTarafItem.Element("TarafSifat").Value;
                    if (munzamTarafItem.Element("MusteriNo") != null) taraf.MusteriNo = munzamTarafItem.Element("MusteriNo").Value;
                    if (munzamTarafItem.Element("Musteri") != null) taraf.Musteri = munzamTarafItem.Element("Musteri").Value;

                    if (munzamSenet.Taraflar == null) munzamSenet.Taraflar = new List<Taraf>();
                    munzamSenet.Taraflar.Add(taraf);
                }
                if (dosya.MunzamSenetler == null) dosya.MunzamSenetler = new List<Bono>();
                dosya.MunzamSenetler.Add(munzamSenet);
            }

            #endregion Munzam Senet

            #region Teminatlar

            #region İpotek

            var ipotekler = tasfiyeHesap.Descendants("IPOTEKLER");
            var ipotek = ipotekler.Descendants("IPOTEK");

            foreach (var ipotekItem in ipotek)
            {
                if (ipotekItem.Value.Length == 0) continue;

                Ipotek newIpotek = new Ipotek();

                if (ipotekItem.Element("IpotekReferans") != null) newIpotek.ReferanNo = ipotekItem.Element("IpotekReferans").Value;
                if (ipotekItem.Element("Durum") != null) newIpotek.Durum = ipotekItem.Element("Durum").Value;
                if (ipotekItem.Element("Tip") != null) newIpotek.Tip = ipotekItem.Element("Tip").Value;
                if (ipotekItem.Element("AltTip") != null) newIpotek.AltTip = ipotekItem.Element("AltTip").Value;
                if (ipotekItem.Element("BedeliParaBirimi") != null) newIpotek.BedeliParaBirimi = ipotekItem.Element("BedeliParaBirimi").Value;
                if (ipotekItem.Element("Bedeli") != null) newIpotek.Bedeli = Convert.ToDecimal(ipotekItem.Element("Bedeli").Value);
                if (ipotekItem.Element("SicilBolgeNo") != null) newIpotek.SicilBolgeNo = ipotekItem.Element("SicilBolgeNo").Value;
                if (ipotekItem.Element("SicilIlce") != null) newIpotek.SicilIlce = ipotekItem.Element("SicilIlce").Value;
                if (ipotekItem.Element("SicilIl") != null) newIpotek.SicilIl = ipotekItem.Element("SicilIl").Value;
                if (ipotekItem.Element("SicilYevmiyeNo") != null) newIpotek.SicilYevmiyeNo = ipotekItem.Element("SicilYevmiyeNo").Value;
                if (ipotekItem.Element("SicilTescilNo") != null) newIpotek.SicilTescilNo = ipotekItem.Element("SicilTescilNo").Value;
                if (ipotekItem.Element("RehinDerece") != null) newIpotek.RehinDerece = ipotekItem.Element("RehinDerece").Value;
                if (ipotekItem.Element("RehinSira") != null) newIpotek.RehinSira = ipotekItem.Element("RehinSira").Value;

                #region Gayrimenkul

                var gayrimenkuller = ipotekItem.Descendants("GAYRIMENKULLER");
                var gayrimenkul = gayrimenkuller.Descendants("GAYRIMENKUL");
                foreach (var gayrimenkulItem in gayrimenkul)
                {
                    if (gayrimenkulItem.Value.Length == 0) continue;

                    Gayrimenkul newGayrimenkul = new Gayrimenkul();

                    if (gayrimenkulItem.Element("Il") != null) newGayrimenkul.Il = gayrimenkulItem.Element("Il").Value;
                    if (gayrimenkulItem.Element("Ilce") != null) newGayrimenkul.Ilce = gayrimenkulItem.Element("Ilce").Value;
                    if (gayrimenkulItem.Element("Bucak") != null) newGayrimenkul.Bucak = gayrimenkulItem.Element("Bucak").Value;
                    if (gayrimenkulItem.Element("Mahalle") != null) newGayrimenkul.Mahalle = gayrimenkulItem.Element("Mahalle").Value;
                    if (gayrimenkulItem.Element("Koy") != null) newGayrimenkul.Koy = gayrimenkulItem.Element("Koy").Value;
                    if (gayrimenkulItem.Element("Sokak") != null) newGayrimenkul.Sokak = gayrimenkulItem.Element("Sokak").Value;
                    if (gayrimenkulItem.Element("Mevki") != null) newGayrimenkul.Mevki = gayrimenkulItem.Element("Mevki").Value;
                    if (gayrimenkulItem.Element("PaftaNo") != null) newGayrimenkul.PaftaNo = gayrimenkulItem.Element("PaftaNo").Value;
                    if (gayrimenkulItem.Element("AdaNo") != null) newGayrimenkul.AdaNo = gayrimenkulItem.Element("AdaNo").Value;
                    if (gayrimenkulItem.Element("ParselNo") != null) newGayrimenkul.ParselNo = gayrimenkulItem.Element("ParselNo").Value;
                    if (gayrimenkulItem.Element("YevmiyeNo") != null) newGayrimenkul.YevmiyeNo = gayrimenkulItem.Element("YevmiyeNo").Value;
                    if (gayrimenkulItem.Element("CiltNo") != null) newGayrimenkul.CiltNo = gayrimenkulItem.Element("CiltNo").Value;
                    if (gayrimenkulItem.Element("SahifeNo") != null) newGayrimenkul.SahifeNo = gayrimenkulItem.Element("SahifeNo").Value;
                    if (gayrimenkulItem.Element("ArsaPayi") != null) newGayrimenkul.ArsaPayi = gayrimenkulItem.Element("ArsaPayi").Value;
                    if (gayrimenkulItem.Element("KatNo") != null) newGayrimenkul.KatNo = gayrimenkulItem.Element("KatNo").Value;
                    if (gayrimenkulItem.Element("BagimsizBolumNo") != null) newGayrimenkul.BagimsizBolumNo = gayrimenkulItem.Element("BagimsizBolumNo").Value;
                    if (gayrimenkulItem.Element("Niteligi") != null) newGayrimenkul.Niteligi = gayrimenkulItem.Element("Niteligi").Value;
                    if (gayrimenkulItem.Element("YuzOlcumDM2") != null) newGayrimenkul.YuzOlcumDM2 = gayrimenkulItem.Element("YuzOlcumDM2").Value;
                    if (gayrimenkulItem.Element("SerhAciklamasi") != null) newGayrimenkul.SerhAciklamasi = gayrimenkulItem.Element("SerhAciklamasi").Value;
                    if (gayrimenkulItem.Element("Aciklama") != null) newGayrimenkul.Aciklama = gayrimenkulItem.Element("Aciklama").Value;
                    if (gayrimenkulItem.Element("EkspertizTutari") != null) newGayrimenkul.EkspertizTutari = Convert.ToDecimal(gayrimenkulItem.Element("EkspertizTutari").Value);
                    if (gayrimenkulItem.Element("EkspertizTutariParaBirimi") != null) newGayrimenkul.EkspertizTutariParaBirimi = gayrimenkulItem.Element("EkspertizTutariParaBirimi").Value;
                    if (gayrimenkulItem.Element("EkspertizTarihi") != null) newGayrimenkul.EksertizTarihi = Convert.ToDateTime(gayrimenkulItem.Element("EkspertizTarihi").Value == "" ? null : gayrimenkulItem.Element("EkspertizTarihi").Value);
                    if (gayrimenkulItem.Element("EkspertizFirma") != null) newGayrimenkul.EkspertizFirma = gayrimenkulItem.Element("EkspertizFirma").Value;

                    var gayrimenkulTaraf = gayrimenkulItem.Descendants("TARAFLAR");
                    foreach (var gayrimenkulTarafItem in gayrimenkulTaraf)
                    {
                        if (gayrimenkulTarafItem.Value.Length == 0) continue;

                        GayrimenkulTaraf taraf = new GayrimenkulTaraf();

                        if (gayrimenkulTarafItem.Element("TarafSifat") != null) taraf.TarafSifat = gayrimenkulTarafItem.Element("TarafSifat").Value;
                        if (gayrimenkulTarafItem.Element("MusteriNo") != null) taraf.MusteriNo = gayrimenkulTarafItem.Element("MusteriNo").Value;
                        if (gayrimenkulTarafItem.Element("Musteri") != null) taraf.Musteri = gayrimenkulTarafItem.Element("Musteri").Value;
                        if (gayrimenkulTarafItem.Element("HisseOran") != null) taraf.HisseOran = gayrimenkulTarafItem.Element("HisseOran").Value;

                        if (newGayrimenkul.Taraflar == null) newGayrimenkul.Taraflar = new List<GayrimenkulTaraf>();
                        newGayrimenkul.Taraflar.Add(taraf);
                    }

                    if (newIpotek.Gayrimenkuller == null) newIpotek.Gayrimenkuller = new List<Gayrimenkul>();
                    newIpotek.Gayrimenkuller.Add(newGayrimenkul);
                }

                #endregion Gayrimenkul

                if (dosya.Ipotekler == null) dosya.Ipotekler = new List<Ipotek>();
                dosya.Ipotekler.Add(newIpotek);
            }

            #endregion İpotek

            #region Uçak Rehni

            var ucakRehinleri = tasfiyeHesap.Descendants("UCAK_REHINLERI");
            var ucakRehni = ucakRehinleri.Descendants("UCAK_REHNI");

            foreach (var ucakRehniItem in ucakRehni)
            {
                if (ucakRehniItem.Value.Length == 0) continue;

                UcakRehin newUcakRehin = new UcakRehin();
                if (ucakRehniItem.Element("TeminatReferansNo") != null) newUcakRehin.ReferanNo = ucakRehniItem.Element("TeminatReferansNo").Value;
                if (ucakRehniItem.Element("Durum") != null) newUcakRehin.Durum = ucakRehniItem.Element("Durum").Value;
                if (ucakRehniItem.Element("Tutar") != null) newUcakRehin.Tutari = Convert.ToDecimal(ucakRehniItem.Element("Tutar").Value == "" ? "0" : ucakRehniItem.Element("Tutar").Value);
                if (ucakRehniItem.Element("TutarParaBirimi") != null) newUcakRehin.TutariParaBirimi = ucakRehniItem.Element("TutarParaBirimi").Value;
                if (ucakRehniItem.Element("RehinTuru") != null) newUcakRehin.RehinTuru = ucakRehniItem.Element("RehinTuru").Value;
                if (ucakRehniItem.Element("RehinTarihi") != null) newUcakRehin.RehinTarihi = Convert.ToDateTime(ucakRehniItem.Element("RehinTarihi").Value == "" ? null : ucakRehniItem.Element("RehinTarihi").Value);
                if (ucakRehniItem.Element("Yeddiemin") != null) newUcakRehin.Yeddiemin = ucakRehniItem.Element("Yeddiemin").Value;
                if (ucakRehniItem.Element("Aciklama") != null) newUcakRehin.Aciklama = ucakRehniItem.Element("Aciklama").Value;
                if (ucakRehniItem.Element("SicilYevmiyeNo") != null) newUcakRehin.SicilYevmiyeNo = ucakRehniItem.Element("SicilYevmiyeNo").Value;
                if (ucakRehniItem.Element("SicilTescilNo") != null) newUcakRehin.SicilTescilNo = ucakRehniItem.Element("SicilTescilNo").Value;
                if (ucakRehniItem.Element("Adi") != null) newUcakRehin.Adi = ucakRehniItem.Element("Adi").Value;
                if (ucakRehniItem.Element("Cinsi") != null) newUcakRehin.Cinsi = ucakRehniItem.Element("Cinsi").Value;
                if (ucakRehniItem.Element("TescilNumarasi") != null) newUcakRehin.TescilNumarasi = ucakRehniItem.Element("TescilNumarasi").Value;
                var ucakRehniTaraflar = ucakRehniItem.Descendants("TARAFLAR");
                foreach (var tarafItem in ucakRehniTaraflar)
                {
                    if (tarafItem.Value.Length == 0) continue;

                    Taraf taraf = new Taraf();

                    if (tarafItem.Element("TarafSifat") != null) taraf.TarafSifat = tarafItem.Element("TarafSifat").Value;
                    if (tarafItem.Element("MusteriNo") != null) taraf.MusteriNo = tarafItem.Element("MusteriNo").Value;
                    if (tarafItem.Element("Musteri") != null) taraf.Musteri = tarafItem.Element("Musteri").Value;

                    if (newUcakRehin.Taraflar == null) newUcakRehin.Taraflar = new List<Taraf>();
                    newUcakRehin.Taraflar.Add(taraf);
                }
                if (dosya.UcakRehinleri == null) dosya.UcakRehinleri = new List<UcakRehin>();
                dosya.UcakRehinleri.Add(newUcakRehin);
            }

            #endregion Uçak Rehni

            #region Gemi Rehni

            var gemiRehinleri = tasfiyeHesap.Descendants("GEMI_REHINLERI");
            var gemiRehni = gemiRehinleri.Descendants("GEMI_REHNI");

            foreach (var gemiRehniItem in gemiRehni)
            {
                if (gemiRehniItem.Value.Length == 0) continue;

                GemiRehin newGemiRehin = new GemiRehin();
                if (gemiRehniItem.Element("TeminatReferansNo") != null) newGemiRehin.ReferanNo = gemiRehniItem.Element("TeminatReferansNo").Value;
                if (gemiRehniItem.Element("Durum") != null) newGemiRehin.Durum = gemiRehniItem.Element("Durum").Value;
                if (gemiRehniItem.Element("Tutar") != null) newGemiRehin.Tutari = Convert.ToDecimal(gemiRehniItem.Element("Tutar").Value == "" ? "0" : gemiRehniItem.Element("Tutar").Value);
                if (gemiRehniItem.Element("TutarParaBirimi") != null) newGemiRehin.TutariParaBirimi = gemiRehniItem.Element("TutarParaBirimi").Value;
                if (gemiRehniItem.Element("RehinTuru") != null) newGemiRehin.RehinTuru = gemiRehniItem.Element("RehinTuru").Value;
                if (gemiRehniItem.Element("RehinTarihi") != null) newGemiRehin.RehinTarihi = Convert.ToDateTime(gemiRehniItem.Element("RehinTarihi").Value == "" ? null : gemiRehniItem.Element("RehinTarihi").Value);
                if (gemiRehniItem.Element("Yeddiemin") != null) newGemiRehin.Yeddiemin = gemiRehniItem.Element("Yeddiemin").Value;
                if (gemiRehniItem.Element("Aciklama") != null) newGemiRehin.Aciklama = gemiRehniItem.Element("Aciklama").Value;
                if (gemiRehniItem.Element("SicilYevmiyeNo") != null) newGemiRehin.SicilYevmiyeNo = gemiRehniItem.Element("SicilYevmiyeNo").Value;
                if (gemiRehniItem.Element("SicilTescilNo") != null) newGemiRehin.SicilTescilNo = gemiRehniItem.Element("SicilTescilNo").Value;
                if (gemiRehniItem.Element("Adi") != null) newGemiRehin.Adi = gemiRehniItem.Element("Adi").Value;
                if (gemiRehniItem.Element("Cinsi") != null) newGemiRehin.Cinsi = gemiRehniItem.Element("Cinsi").Value;
                if (gemiRehniItem.Element("TescilNumarasi") != null) newGemiRehin.TescilNumarasi = gemiRehniItem.Element("TescilNumarasi").Value;
                var ucakRehniTaraflar = gemiRehniItem.Descendants("TARAFLAR");
                foreach (var tarafItem in ucakRehniTaraflar)
                {
                    if (tarafItem.Value.Length == 0) continue;

                    Taraf taraf = new Taraf();

                    if (tarafItem.Element("TarafSifat") != null) taraf.TarafSifat = tarafItem.Element("TarafSifat").Value;
                    if (tarafItem.Element("MusteriNo") != null) taraf.MusteriNo = tarafItem.Element("MusteriNo").Value;
                    if (tarafItem.Element("Musteri") != null) taraf.Musteri = tarafItem.Element("Musteri").Value;

                    if (newGemiRehin.Taraflar == null) newGemiRehin.Taraflar = new List<Taraf>();
                    newGemiRehin.Taraflar.Add(taraf);
                }
                if (dosya.GemiRehinleri == null) dosya.GemiRehinleri = new List<GemiRehin>();
                dosya.GemiRehinleri.Add(newGemiRehin);
            }

            #endregion Gemi Rehni

            #region Araç Rehni

            var aracRehinleri = tasfiyeHesap.Descendants("ARAC_REHINLERI");
            var aracRehni = aracRehinleri.Descendants("ARAC_REHNI");

            foreach (var aracRehniItem in aracRehni)
            {
                if (aracRehniItem.Value.Length == 0) continue;

                AracRehin newAracRehin = new AracRehin();

                if (aracRehniItem.Element("TeminatReferansNo") != null) newAracRehin.ReferanNo = aracRehniItem.Element("TeminatReferansNo").Value;
                if (aracRehniItem.Element("Durum") != null) newAracRehin.Durum = aracRehniItem.Element("Durum").Value;
                if (aracRehniItem.Element("Tutar") != null) newAracRehin.Tutari = Convert.ToDecimal(aracRehniItem.Element("Tutar").Value == "" ? "0" : aracRehniItem.Element("Tutar").Value);
                if (aracRehniItem.Element("Tutar") != null) newAracRehin.TutariParaBirimi = aracRehniItem.Element("TutarParaBirimi").Value;
                if (aracRehniItem.Element("RehinTuru") != null) newAracRehin.RehinTuru = aracRehniItem.Element("RehinTuru").Value;
                if (aracRehniItem.Element("RehinTarihi") != null) newAracRehin.RehinTarihi = Convert.ToDateTime(aracRehniItem.Element("RehinTarihi").Value == "" ? null : aracRehniItem.Element("RehinTarihi").Value);
                if (aracRehniItem.Element("Yeddiemin") != null) newAracRehin.Yeddiemin = aracRehniItem.Element("Yeddiemin").Value;
                if (aracRehniItem.Element("Aciklama") != null) newAracRehin.Aciklama = aracRehniItem.Element("Aciklama").Value;
                if (aracRehniItem.Element("SicilYevmiyeNo") != null) newAracRehin.SicilYevmiyeNo = aracRehniItem.Element("SicilYevmiyeNo").Value;
                if (aracRehniItem.Element("AracPlakaNo") != null) newAracRehin.AracPlakaNo = aracRehniItem.Element("AracPlakaNo").Value;
                if (aracRehniItem.Element("AracModel") != null) newAracRehin.AracModel = aracRehniItem.Element("AracModel").Value;
                if (aracRehniItem.Element("AracTip") != null) newAracRehin.AracTip = aracRehniItem.Element("AracTip").Value;
                if (aracRehniItem.Element("AracMotorNo") != null) newAracRehin.AracMotorNo = aracRehniItem.Element("AracMotorNo").Value;
                if (aracRehniItem.Element("AracSasiNo") != null) newAracRehin.AracSasiNo = aracRehniItem.Element("AracSasiNo").Value;
                if (aracRehniItem.Element("AracRenk") != null) newAracRehin.AracRenk = aracRehniItem.Element("AracRenk").Value;
                if (aracRehniItem.Element("TrafikSubesi") != null) newAracRehin.TrafikSubesi = aracRehniItem.Element("TrafikSubesi").Value;
                if (aracRehniItem.Element("RuhsatSicilNo") != null) newAracRehin.RuhsatSicilNo = aracRehniItem.Element("RuhsatSicilNo").Value;

                var aracRehinTaraflar = aracRehniItem.Descendants("TARAFLAR");
                foreach (var aracRehinTarafItem in aracRehinTaraflar)
                {
                    if (aracRehinTarafItem.Value.Length == 0) continue;

                    Taraf taraf = new Taraf();

                    if (aracRehinTarafItem.Element("TarafSifat") != null) taraf.TarafSifat = aracRehinTarafItem.Element("TarafSifat").Value;
                    if (aracRehinTarafItem.Element("MusteriNo") != null) taraf.MusteriNo = aracRehinTarafItem.Element("MusteriNo").Value;
                    if (aracRehinTarafItem.Element("Musteri") != null) taraf.Musteri = aracRehinTarafItem.Element("Musteri").Value;

                    if (newAracRehin.Taraflar == null) newAracRehin.Taraflar = new List<Taraf>();
                    newAracRehin.Taraflar.Add(taraf);
                }
                if (dosya.AracRehinleri == null) dosya.AracRehinleri = new List<AracRehin>();
                dosya.AracRehinleri.Add(newAracRehin);
                if (dosya.Rehinler == null) dosya.Rehinler = new List<Rehin>();
                dosya.Rehinler.Add(SetRehinBilgileri("Araç Rehni", newAracRehin.Tutari, newAracRehin.TutariParaBirimi, newAracRehin.RehinTarihi));
            }

            #endregion Araç Rehni

            #region Ticari İşletme Rehni

            var ticariIsletmeRehinleri = tasfiyeHesap.Descendants("TICARI_ISLETME_REHINLERI");
            var ticariIsletme = ticariIsletmeRehinleri.Descendants("TICARI_ISLETME_REHNI");
            foreach (var ticariIsletmeItem in ticariIsletme)
            {
                if (ticariIsletmeItem.Value.Length == 0) continue;

                TicariIsletmeRehni newTIR = new TicariIsletmeRehni();

                if (ticariIsletmeItem.Element("TeminatReferansNo") != null) newTIR.ReferanNo = ticariIsletmeItem.Element("TeminatReferansNo").Value;
                if (ticariIsletmeItem.Element("Durum") != null) newTIR.Durum = ticariIsletmeItem.Element("Durum").Value;
                if (ticariIsletmeItem.Element("NoterYevmiyeNo") != null) newTIR.NoterYevmiyeNo = ticariIsletmeItem.Element("NoterYevmiyeNo").Value;
                if (ticariIsletmeItem.Element("NoterTarihi") != null) newTIR.NoterTarihi = Convert.ToDateTime(ticariIsletmeItem.Element("NoterTarihi").Value == "" ? null : ticariIsletmeItem.Element("NoterTarihi").Value);
                if (ticariIsletmeItem.Element("Adliye") != null) newTIR.Adliye = ticariIsletmeItem.Element("Adliye").Value;
                if (ticariIsletmeItem.Element("AdliBirimNo") != null) newTIR.AdliBirimNo = ticariIsletmeItem.Element("AdliBirimNo").Value;
                if (ticariIsletmeItem.Element("AltTip") != null) newTIR.SozlesmeAltTip = ticariIsletmeItem.Element("AltTip").Value;
                if (ticariIsletmeItem.Element("Bedeli") != null) newTIR.Bedeli = Convert.ToDecimal(ticariIsletmeItem.Element("Bedeli").Value == "" ? "0" : ticariIsletmeItem.Element("Bedeli").Value);
                if (ticariIsletmeItem.Element("BedeliParaBirimi") != null) newTIR.BedeliParaBirimi = ticariIsletmeItem.Element("BedeliParaBirimi").Value;
                if (ticariIsletmeItem.Element("TicariIsletmeUnvani") != null) newTIR.TicariIsletmeUnvani = ticariIsletmeItem.Element("TicariIsletmeUnvani").Value;
                if (ticariIsletmeItem.Element("TicariIsletmeAdi") != null) newTIR.TicariIsletmeAdi = ticariIsletmeItem.Element("TicariIsletmeAdi").Value;
                if (ticariIsletmeItem.Element("RehinDerece") != null) newTIR.RehinDerece = ticariIsletmeItem.Element("RehinDerece").Value;
                if (ticariIsletmeItem.Element("RehinSira") != null) newTIR.RehinSira = ticariIsletmeItem.Element("RehinSira").Value;

                var TIRTaraf = ticariIsletmeItem.Descendants("TARAFLAR");
                foreach (var TIRTarafItem in TIRTaraf)
                {
                    if (TIRTarafItem.Value.Length == 0) continue;

                    Taraf taraf = new Taraf();

                    if (TIRTarafItem.Element("TarafSifat") != null) taraf.TarafSifat = TIRTarafItem.Element("TarafSifat").Value;
                    if (TIRTarafItem.Element("MusteriNo") != null) taraf.MusteriNo = TIRTarafItem.Element("MusteriNo").Value;
                    if (TIRTarafItem.Element("Musteri") != null) taraf.Musteri = TIRTarafItem.Element("Musteri").Value;

                    if (newTIR.Taraflar == null) newTIR.Taraflar = new List<Taraf>();
                    newTIR.Taraflar.Add(taraf);
                }

                if (dosya.TicariIsletmeRehinleri == null) dosya.TicariIsletmeRehinleri = new List<TicariIsletmeRehni>();
                dosya.TicariIsletmeRehinleri.Add(newTIR);
                if (dosya.Rehinler == null) dosya.Rehinler = new List<Rehin>();
                //dosya.Rehinler.Add(SetRehinBilgileri("Ticari İşletme Rehni", newTIR.Bedeli, newTIR.BedeliParaBirimi, )); Tarih alanı yapılacak.
            }

            #endregion Ticari İşletme Rehni

            #region Ihracat Vesaiki

            var ihracatVesaikileri = tasfiyeHesap.Descendants("IHRACAT_VESAIKILERI");
            var ihracatVesaiki = ihracatVesaikileri.Descendants("IHRACAT_VESAIKI");
            foreach (var ihracatVesaikiItem in ihracatVesaiki)
            {
                if (ihracatVesaikiItem.Value.Length == 0) continue;

                IhracatIthalatVesaiki newIhracatVesaiki = new IhracatIthalatVesaiki();

                if (ihracatVesaikiItem.Element("TeminatReferansNo") != null) newIhracatVesaiki.ReferansNo = ihracatVesaikiItem.Element("TeminatReferansNo").Value;
                if (ihracatVesaikiItem.Element("Durum") != null) newIhracatVesaiki.Durum = ihracatVesaikiItem.Element("Durum").Value;
                if (ihracatVesaikiItem.Element("Tutar") != null) newIhracatVesaiki.Tutar = Convert.ToDecimal(ihracatVesaikiItem.Element("Tutar").Value == "" ? "0" : ihracatVesaikiItem.Element("Tutar").Value);
                if (ihracatVesaikiItem.Element("TutarParaBirimi") != null) newIhracatVesaiki.TutarParaBirimi = ihracatVesaikiItem.Element("TutarParaBirimi").Value;
                if (ihracatVesaikiItem.Element("Sube") != null) newIhracatVesaiki.ReferansTuru = ihracatVesaikiItem.Element("Sube").Value;
                if (ihracatVesaikiItem.Element("ReferansSube") != null) newIhracatVesaiki.ReferansSube = ihracatVesaikiItem.Element("ReferansSube").Value;
                if (ihracatVesaikiItem.Element("ReferansNiteligi") != null) newIhracatVesaiki.ReferansNiteligi = ihracatVesaikiItem.Element("ReferansNiteligi").Value;
                if (ihracatVesaikiItem.Element("ReferansSiraNo") != null) newIhracatVesaiki.ReferansSiraNo = Convert.ToInt32(ihracatVesaikiItem.Element("ReferansSiraNo").Value == "" ? "0" : ihracatVesaikiItem.Element("ReferansSiraNo").Value);
                if (ihracatVesaikiItem.Element("OdemeVadesi") != null) newIhracatVesaiki.OdemeVadesi = Convert.ToDateTime(ihracatVesaikiItem.Element("OdemeVadesi").Value == "" ? null : ihracatVesaikiItem.Element("OdemeVadesi").Value);
                if (ihracatVesaikiItem.Element("MalSevkiyatSekli") != null) newIhracatVesaiki.MalSevkiyatSekli = ihracatVesaikiItem.Element("MalSevkiyatSekli").Value;
                if (ihracatVesaikiItem.Element("TasiyiciFirma") != null) newIhracatVesaiki.TasiyiciFirma = ihracatVesaikiItem.Element("TasiyiciFirma").Value;
                if (ihracatVesaikiItem.Element("SigortaSirketi") != null) newIhracatVesaiki.SigortaSirketi = ihracatVesaikiItem.Element("SigortaSirketi").Value;
                if (ihracatVesaikiItem.Element("PoliceNumarası") != null) newIhracatVesaiki.PoliceNumarasi = Convert.ToInt32(ihracatVesaikiItem.Element("PoliceNumarası").Value == "" ? "0" : ihracatVesaikiItem.Element("PoliceNumarası").Value);

                var ihracatVesaikiTaraflar = ihracatVesaikiItem.Descendants("TARAFLAR");
                foreach (var ihracatVesaikiTarafItem in ihracatVesaikiTaraflar)
                {
                    if (ihracatVesaikiTarafItem.Value.Length == 0) continue;

                    Taraf newTaraf = new Taraf();

                    if (ihracatVesaikiTarafItem.Element("TarafSifat") != null) newTaraf.TarafSifat = ihracatVesaikiTarafItem.Element("TarafSifat").Value;
                    if (ihracatVesaikiTarafItem.Element("MusteriNo") != null) newTaraf.MusteriNo = ihracatVesaikiTarafItem.Element("MusteriNo").Value;
                    if (ihracatVesaikiTarafItem.Element("Musteri") != null) newTaraf.Musteri = ihracatVesaikiTarafItem.Element("Musteri").Value;

                    if (newIhracatVesaiki.Taraflar == null) newIhracatVesaiki.Taraflar = new List<Taraf>();
                    newIhracatVesaiki.Taraflar.Add(newTaraf);
                }

                if (dosya.IhracatVesaikileri == null) dosya.IhracatVesaikileri = new List<IhracatIthalatVesaiki>();
                dosya.IhracatVesaikileri.Add(newIhracatVesaiki);
            }

            #endregion Ihracat Vesaiki

            #region İthalat Vesaiki

            var ithalatVesaikileri = tasfiyeHesap.Descendants("ITHALAT_VESAIKILERI");
            var ithalatVesaiki = ithalatVesaikileri.Descendants("ITHALAT_VESAIKI");
            foreach (var ithalatVesaikiItem in ithalatVesaiki)
            {
                if (ithalatVesaikiItem.Value.Length == 0) continue;

                IhracatIthalatVesaiki newIthalatVesaiki = new IhracatIthalatVesaiki();

                if (ithalatVesaikiItem.Element("TeminatReferansNo") != null) newIthalatVesaiki.ReferansNo = ithalatVesaikiItem.Element("TeminatReferansNo").Value;
                if (ithalatVesaikiItem.Element("Durum") != null) newIthalatVesaiki.Durum = ithalatVesaikiItem.Element("Durum").Value;
                if (ithalatVesaikiItem.Element("Tutar") != null) newIthalatVesaiki.Tutar = Convert.ToDecimal(ithalatVesaikiItem.Element("Tutar").Value == "" ? "0" : ithalatVesaikiItem.Element("Tutar").Value);
                if (ithalatVesaikiItem.Element("TutarParaBirimi") != null) newIthalatVesaiki.TutarParaBirimi = ithalatVesaikiItem.Element("TutarParaBirimi").Value;
                if (ithalatVesaikiItem.Element("Sube") != null) newIthalatVesaiki.ReferansTuru = ithalatVesaikiItem.Element("Sube").Value;
                if (ithalatVesaikiItem.Element("ReferansSube") != null) newIthalatVesaiki.ReferansSube = ithalatVesaikiItem.Element("ReferansSube").Value;
                if (ithalatVesaikiItem.Element("ReferansNiteligi") != null) newIthalatVesaiki.ReferansNiteligi = ithalatVesaikiItem.Element("ReferansNiteligi").Value;
                if (ithalatVesaikiItem.Element("ReferansSiraNo") != null) newIthalatVesaiki.ReferansSiraNo = Convert.ToInt32(ithalatVesaikiItem.Element("ReferansSiraNo").Value == "" ? "0" : ithalatVesaikiItem.Element("ReferansSiraNo").Value);
                if (ithalatVesaikiItem.Element("OdemeVadesi") != null) newIthalatVesaiki.OdemeVadesi = Convert.ToDateTime(ithalatVesaikiItem.Element("OdemeVadesi").Value == "" ? null : ithalatVesaikiItem.Element("OdemeVadesi").Value);
                if (ithalatVesaikiItem.Element("MalSevkiyatSekli") != null) newIthalatVesaiki.MalSevkiyatSekli = ithalatVesaikiItem.Element("MalSevkiyatSekli").Value;
                if (ithalatVesaikiItem.Element("TasiyiciFirma") != null) newIthalatVesaiki.TasiyiciFirma = ithalatVesaikiItem.Element("TasiyiciFirma").Value;
                if (ithalatVesaikiItem.Element("SigortaSirketi") != null) newIthalatVesaiki.SigortaSirketi = ithalatVesaikiItem.Element("SigortaSirketi").Value;
                if (ithalatVesaikiItem.Element("PoliceNumarası") != null) newIthalatVesaiki.PoliceNumarasi = Convert.ToInt32(ithalatVesaikiItem.Element("PoliceNumarası").Value == "" ? "0" : ithalatVesaikiItem.Element("PoliceNumarası").Value);

                var ihracatVesaikiTaraflar = ithalatVesaikiItem.Descendants("TARAFLAR");
                foreach (var ihracatVesaikiTarafItem in ihracatVesaikiTaraflar)
                {
                    if (ihracatVesaikiTarafItem.Value.Length == 0) continue;

                    Taraf newTaraf = new Taraf();

                    if (ihracatVesaikiTarafItem.Element("TarafSifat") != null) newTaraf.TarafSifat = ihracatVesaikiTarafItem.Element("TarafSifat").Value;
                    if (ihracatVesaikiTarafItem.Element("MusteriNo") != null) newTaraf.MusteriNo = ihracatVesaikiTarafItem.Element("MusteriNo").Value;
                    if (ihracatVesaikiTarafItem.Element("Musteri") != null) newTaraf.Musteri = ihracatVesaikiTarafItem.Element("Musteri").Value;

                    if (newIthalatVesaiki.Taraflar == null) newIthalatVesaiki.Taraflar = new List<Taraf>();
                    newIthalatVesaiki.Taraflar.Add(newTaraf);
                }

                if (dosya.IthalatVesaikileri == null) dosya.IthalatVesaikileri = new List<IhracatIthalatVesaiki>();
                dosya.IthalatVesaikileri.Add(newIthalatVesaiki);
            }

            #endregion İthalat Vesaiki

            #region Alacağın Temliki

            var alacaginTemlikleri = tasfiyeHesap.Descendants("ALACAGIN_TEMLIKLERI");
            var alacaginTemliki = alacaginTemlikleri.Descendants("ALACAGIN_TEMLIKI");
            foreach (var alacaginTemlikiItem in alacaginTemliki)
            {
                if (alacaginTemlikiItem.Value.Length == 0) continue;

                AlacaginTemliki newAlacaginTemliki = new AlacaginTemliki();

                if (alacaginTemlikiItem.Element("TeminatReferansNo") != null) newAlacaginTemliki.ReferansNo = alacaginTemlikiItem.Element("TeminatReferansNo").Value;
                if (alacaginTemlikiItem.Element("Durum") != null) newAlacaginTemliki.Durum = alacaginTemlikiItem.Element("Durum").Value;
                if (alacaginTemlikiItem.Element("Tutar") != null) newAlacaginTemliki.Tutar = Convert.ToDecimal(alacaginTemlikiItem.Element("Tutar").Value == "" ? "0" : alacaginTemlikiItem.Element("Tutar").Value);
                if (alacaginTemlikiItem.Element("TutarParaBirimi") != null) newAlacaginTemliki.TutarParaBirimi = alacaginTemlikiItem.Element("TutarParaBirimi").Value;
                if (alacaginTemlikiItem.Element("v") != null) newAlacaginTemliki.BorcunDayanagi = alacaginTemlikiItem.Element("BorcunDayanagi").Value;
                if (alacaginTemlikiItem.Element("AlacakTur") != null) newAlacaginTemliki.AlacakTur = alacaginTemlikiItem.Element("AlacakTur").Value;
                if (alacaginTemlikiItem.Element("FaturaAdet") != null) newAlacaginTemliki.FaturaAdet = Convert.ToInt32(alacaginTemlikiItem.Element("FaturaAdet").Value == "" ? "0" : alacaginTemlikiItem.Element("FaturaAdet").Value);
                if (alacaginTemlikiItem.Element("Aciklama") != null) newAlacaginTemliki.Aciklama = alacaginTemlikiItem.Element("Aciklama").Value;
                if (alacaginTemlikiItem.Element("TemlikBorclusu") != null) newAlacaginTemliki.TemlikBorclusu = alacaginTemlikiItem.Element("TemlikBorclusu").Value;
                if (alacaginTemlikiItem.Element("BaskaTemlikVarmi") != null) newAlacaginTemliki.BaskaTemlikVarmi = alacaginTemlikiItem.Element("BaskaTemlikVarmi").Value;

                var alacaginTemlikiTaraflar = alacaginTemlikiItem.Descendants("TARAFLAR");
                foreach (var alacaginTemlikiTarafItem in alacaginTemlikiTaraflar)
                {
                    if (alacaginTemlikiTarafItem.Value.Length == 0) continue;

                    Taraf newTaraf = new Taraf();

                    if (alacaginTemlikiTarafItem.Element("TarafSifat") != null) newTaraf.TarafSifat = alacaginTemlikiTarafItem.Element("TarafSifat").Value;
                    if (alacaginTemlikiTarafItem.Element("MusteriNo") != null) newTaraf.MusteriNo = alacaginTemlikiTarafItem.Element("MusteriNo").Value;
                    if (alacaginTemlikiTarafItem.Element("Musteri") != null) newTaraf.Musteri = alacaginTemlikiTarafItem.Element("Musteri").Value;

                    if (newAlacaginTemliki.Taraflar == null) newAlacaginTemliki.Taraflar = new List<Taraf>();
                    newAlacaginTemliki.Taraflar.Add(newTaraf);
                }

                if (dosya.AlacaginTemlikleri == null) dosya.AlacaginTemlikleri = new List<AlacaginTemliki>();
                dosya.AlacaginTemlikleri.Add(newAlacaginTemliki);
            }

            #endregion Alacağın Temliki

            #region Hisse Senedi Temliki

            var hisseSenediTemlikleri = tasfiyeHesap.Descendants("HISSE_SENEDI_TEMINATLARI");
            var hisseSenediTemliki = hisseSenediTemlikleri.Descendants("HISSE_SENEDI_TEMINATI");
            foreach (var hisseSenediTemlikItem in hisseSenediTemliki)
            {
                if (hisseSenediTemlikItem.Value.Length == 0) continue;

                HisseSenediTeminati newHisseSenediTemliki = new HisseSenediTeminati();

                if (hisseSenediTemlikItem.Element("TeminatReferansNo") != null) newHisseSenediTemliki.ReferansNo = hisseSenediTemlikItem.Element("TeminatReferansNo").Value;
                if (hisseSenediTemlikItem.Element("Durum") != null) newHisseSenediTemliki.Durum = hisseSenediTemlikItem.Element("Durum").Value;
                if (hisseSenediTemlikItem.Element("Tutar") != null) newHisseSenediTemliki.Tutar = Convert.ToDecimal(hisseSenediTemlikItem.Element("Tutar").Value == "" ? "0" : hisseSenediTemlikItem.Element("Tutar").Value);
                if (hisseSenediTemlikItem.Element("TutarParaBirimi") != null) newHisseSenediTemliki.TutarParaBirimi = hisseSenediTemlikItem.Element("TutarParaBirimi").Value;
                if (hisseSenediTemlikItem.Element("Aciklama") != null) newHisseSenediTemliki.Aciklama = hisseSenediTemlikItem.Element("Aciklama").Value;

                var hisseSenediTemlikiTaraflar = hisseSenediTemlikItem.Descendants("TARAFLAR");
                foreach (var hisseSenediTemlikiTarafItem in hisseSenediTemlikiTaraflar)
                {
                    if (hisseSenediTemlikiTarafItem.Value.Length == 0) continue;

                    Taraf newTaraf = new Taraf();

                    if (hisseSenediTemlikiTarafItem.Element("TarafSifat") != null) newTaraf.TarafSifat = hisseSenediTemlikiTarafItem.Element("TarafSifat").Value;
                    if (hisseSenediTemlikiTarafItem.Element("MusteriNo") != null) newTaraf.MusteriNo = hisseSenediTemlikiTarafItem.Element("MusteriNo").Value;
                    if (hisseSenediTemlikiTarafItem.Element("Musteri") != null) newTaraf.Musteri = hisseSenediTemlikiTarafItem.Element("Musteri").Value;

                    if (newHisseSenediTemliki.Taraflar == null) newHisseSenediTemliki.Taraflar = new List<Taraf>();
                    newHisseSenediTemliki.Taraflar.Add(newTaraf);
                }

                if (dosya.HisseSenediTeminatlari == null) dosya.HisseSenediTeminatlari = new List<HisseSenediTeminati>();
                dosya.HisseSenediTeminatlari.Add(newHisseSenediTemliki);
            }

            #endregion Hisse Senedi Temliki

            #region Firma Garantileri

            var firmaGarantileri = tasfiyeHesap.Descendants("FIRMA_GARANTILERI");
            var firmaGaranti = firmaGarantileri.Descendants("FIRMA_GARANTISI");
            foreach (var firmaGarantiItem in firmaGaranti)
            {
                if (firmaGarantiItem.Value.Length == 0) continue;

                FirmaGaranti newFirmaGaranti = new FirmaGaranti();

                if (firmaGarantiItem.Element("TeminatReferansNo") != null) newFirmaGaranti.ReferansNo = firmaGarantiItem.Element("TeminatReferansNo").Value;
                if (firmaGarantiItem.Element("Durum") != null) newFirmaGaranti.Durum = firmaGarantiItem.Element("Durum").Value;
                if (firmaGarantiItem.Element("Tutar") != null) newFirmaGaranti.Tutar = Convert.ToDecimal(firmaGarantiItem.Element("Tutar").Value == "" ? "0" : firmaGarantiItem.Element("Tutar").Value);
                if (firmaGarantiItem.Element("TutarParaBirimi") != null) newFirmaGaranti.TutarParaBirimi = firmaGarantiItem.Element("TutarParaBirimi").Value;
                if (firmaGarantiItem.Element("GarantorMusteri") != null) newFirmaGaranti.GarantorMusteri = firmaGarantiItem.Element("GarantorMusteri").Value;
                if (firmaGarantiItem.Element("GaramtorMusteriAdresi") != null) newFirmaGaranti.GarantorMusteriAdresi = firmaGarantiItem.Element("GaramtorMusteriAdresi").Value;

                var firmaGarantiTaraflar = firmaGarantiItem.Descendants("TARAFLAR");
                foreach (var firmaGarantiTaraflarItem in firmaGarantiTaraflar)
                {
                    if (firmaGarantiTaraflarItem.Value.Length == 0) continue;

                    Taraf newTaraf = new Taraf();

                    if (firmaGarantiTaraflarItem.Element("TarafSifat") != null) newTaraf.TarafSifat = firmaGarantiTaraflarItem.Element("TarafSifat").Value;
                    if (firmaGarantiTaraflarItem.Element("MusteriNo") != null) newTaraf.MusteriNo = firmaGarantiTaraflarItem.Element("MusteriNo").Value;
                    if (firmaGarantiTaraflarItem.Element("Musteri") != null) newTaraf.Musteri = firmaGarantiTaraflarItem.Element("Musteri").Value;

                    if (newFirmaGaranti.Taraflar == null) newFirmaGaranti.Taraflar = new List<Taraf>();
                    newFirmaGaranti.Taraflar.Add(newTaraf);
                }

                if (dosya.FirmaGarantileri == null) dosya.FirmaGarantileri = new List<FirmaGaranti>();
                dosya.FirmaGarantileri.Add(newFirmaGaranti);
            }

            #endregion Firma Garantileri

            #region Menkul Rehni

            var menkulRehinleri = tasfiyeHesap.Descendants("MENKUL_REHINLERI");
            var menkulRehni = menkulRehinleri.Descendants("MENKUL_REHNI");

            foreach (var menkulRehniItem in menkulRehni)
            {
                if (menkulRehniItem.Value.Length == 0) continue;

                MenkulRehni newMenkulRehni = new MenkulRehni();
                if (menkulRehniItem.Element("TeminatReferansNo") != null) newMenkulRehni.ReferanNo = menkulRehniItem.Element("TeminatReferansNo").Value;
                if (menkulRehniItem.Element("Durum") != null) newMenkulRehni.Durum = menkulRehniItem.Element("Durum").Value;
                if (menkulRehniItem.Element("Tutar") != null) newMenkulRehni.Tutari = Convert.ToDecimal(menkulRehniItem.Element("Tutar").Value == "" ? "0" : menkulRehniItem.Element("Tutar").Value);
                if (menkulRehniItem.Element("TutarParaBirimi") != null) newMenkulRehni.TutariParaBirimi = menkulRehniItem.Element("TutarParaBirimi").Value;
                if (menkulRehniItem.Element("RehinTuru") != null) newMenkulRehni.RehinTuru = menkulRehniItem.Element("RehinTuru").Value;
                if (menkulRehniItem.Element("RehinTarihi") != null) newMenkulRehni.RehinTarihi = Convert.ToDateTime(menkulRehniItem.Element("RehinTarihi").Value == "" ? null : menkulRehniItem.Element("RehinTarihi").Value);
                if (menkulRehniItem.Element("Yeddiemin") != null) newMenkulRehni.Yeddiemin = menkulRehniItem.Element("Yeddiemin").Value;
                if (menkulRehniItem.Element("Aciklama") != null) newMenkulRehni.Aciklama = menkulRehniItem.Element("Aciklama").Value;
                var menkulRehniTaraflar = menkulRehniItem.Descendants("TARAFLAR");
                foreach (var menkulRehniTarafItem in menkulRehniTaraflar)
                {
                    if (menkulRehniTarafItem.Value.Length == 0) continue;

                    Taraf newTaraf = new Taraf();

                    if (menkulRehniTarafItem.Element("TarafSifat") != null) newTaraf.TarafSifat = menkulRehniTarafItem.Element("TarafSifat").Value;
                    if (menkulRehniTarafItem.Element("MusteriNo") != null) newTaraf.MusteriNo = menkulRehniTarafItem.Element("MusteriNo").Value;
                    if (menkulRehniTarafItem.Element("Musteri") != null) newTaraf.Musteri = menkulRehniTarafItem.Element("Musteri").Value;

                    if (newMenkulRehni.Taraflar == null) newMenkulRehni.Taraflar = new List<Taraf>();
                    newMenkulRehni.Taraflar.Add(newTaraf);
                }

                if (dosya.MenkulRehinleri == null) dosya.MenkulRehinleri = new List<MenkulRehni>();
                dosya.MenkulRehinleri.Add(newMenkulRehni);
                if (dosya.Rehinler == null) dosya.Rehinler = new List<Rehin>();
                dosya.Rehinler.Add(SetRehinBilgileri("Menkul Rehni", newMenkulRehni.Tutari, newMenkulRehni.TutariParaBirimi, newMenkulRehni.RehinTarihi));
            }

            #endregion Menkul Rehni

            #region Emtia Rehni

            var emtiaRehinleri = tasfiyeHesap.Descendants("EMTIA_REHINLERI");
            var emtiaRehni = emtiaRehinleri.Descendants("EMTIA_REHNI");

            foreach (var emtiaRehniItem in emtiaRehni)
            {
                if (emtiaRehniItem.Value.Length == 0) continue;

                EmtiaRehni newEmtiaRehni = new EmtiaRehni();
                if (emtiaRehniItem.Element("TeminatReferansNo") != null) newEmtiaRehni.ReferanNo = emtiaRehniItem.Element("TeminatReferansNo").Value;
                if (emtiaRehniItem.Element("Durum") != null) newEmtiaRehni.Durum = emtiaRehniItem.Element("Durum").Value;
                if (emtiaRehniItem.Element("Tutar") != null) newEmtiaRehni.Tutari = Convert.ToDecimal(emtiaRehniItem.Element("Tutar").Value == "" ? "0" : emtiaRehniItem.Element("Tutar").Value);
                if (emtiaRehniItem.Element("TutarParaBirimi") != null) newEmtiaRehni.TutariParaBirimi = emtiaRehniItem.Element("TutarParaBirimi").Value;
                if (emtiaRehniItem.Element("RehinTuru") != null) newEmtiaRehni.RehinTuru = emtiaRehniItem.Element("RehinTuru").Value;
                if (emtiaRehniItem.Element("RehinTarihi") != null) newEmtiaRehni.RehinTarihi = Convert.ToDateTime(emtiaRehniItem.Element("RehinTarihi").Value == "" ? null : emtiaRehniItem.Element("RehinTarihi").Value);
                if (emtiaRehniItem.Element("Yeddiemin") != null) newEmtiaRehni.Yeddiemin = emtiaRehniItem.Element("Yeddiemin").Value;
                if (emtiaRehniItem.Element("Aciklama") != null) newEmtiaRehni.Aciklama = emtiaRehniItem.Element("Aciklama").Value;
                var emtiaRehniTaraflar = emtiaRehniItem.Descendants("TARAFLAR");
                foreach (var emtiaRehniTarafItem in emtiaRehniTaraflar)
                {
                    if (emtiaRehniTarafItem.Value.Length == 0) continue;

                    Taraf newTaraf = new Taraf();

                    if (emtiaRehniTarafItem.Element("TarafSifat") != null) newTaraf.TarafSifat = emtiaRehniTarafItem.Element("TarafSifat").Value;
                    if (emtiaRehniTarafItem.Element("MusteriNo") != null) newTaraf.MusteriNo = emtiaRehniTarafItem.Element("MusteriNo").Value;
                    if (emtiaRehniTarafItem.Element("Musteri") != null) newTaraf.Musteri = emtiaRehniTarafItem.Element("Musteri").Value;

                    if (newEmtiaRehni.Taraflar == null) newEmtiaRehni.Taraflar = new List<Taraf>();
                    newEmtiaRehni.Taraflar.Add(newTaraf);
                }

                if (dosya.EmtiaRehinleri == null) dosya.EmtiaRehinleri = new List<EmtiaRehni>();
                dosya.EmtiaRehinleri.Add(newEmtiaRehni);
                if (dosya.Rehinler == null) dosya.Rehinler = new List<Rehin>();
                dosya.Rehinler.Add(SetRehinBilgileri("Emtia Rehni", newEmtiaRehni.Tutari, newEmtiaRehni.TutariParaBirimi, newEmtiaRehni.RehinTarihi));
            }

            #endregion Emtia Rehni

            #region Varant Rehni

            var varantRehinleri = tasfiyeHesap.Descendants("VARANT_REHINLERI");
            var varantRehni = varantRehinleri.Descendants("VARANT_REHNI");

            foreach (var varantRehniItem in varantRehni)
            {
                if (varantRehniItem.Value.Length == 0) continue;

                VarantRehni newVarantRehni = new VarantRehni();
                if (varantRehniItem.Element("TeminatReferansNo") != null) newVarantRehni.ReferanNo = varantRehniItem.Element("TeminatReferansNo").Value;
                if (varantRehniItem.Element("Durum") != null) newVarantRehni.Durum = varantRehniItem.Element("Durum").Value;
                if (varantRehniItem.Element("Tutar") != null) newVarantRehni.Tutari = Convert.ToDecimal(varantRehniItem.Element("Tutar").Value == "" ? "0" : varantRehniItem.Element("Tutar").Value);
                if (varantRehniItem.Element("TutarParaBirimi") != null) newVarantRehni.TutariParaBirimi = varantRehniItem.Element("TutarParaBirimi").Value;
                if (varantRehniItem.Element("RehinTuru") != null) newVarantRehni.RehinTuru = varantRehniItem.Element("RehinTuru").Value;
                if (varantRehniItem.Element("RehinTarihi") != null) newVarantRehni.RehinTarihi = Convert.ToDateTime(varantRehniItem.Element("RehinTarihi").Value == "" ? null : varantRehniItem.Element("RehinTarihi").Value);
                if (varantRehniItem.Element("Yeddiemin") != null) newVarantRehni.Yeddiemin = varantRehniItem.Element("Yeddiemin").Value;
                if (varantRehniItem.Element("Aciklama") != null) newVarantRehni.Aciklama = varantRehniItem.Element("Aciklama").Value;
                var varantRehniTaraflar = varantRehniItem.Descendants("TARAFLAR");
                foreach (var varantRehniTarafItem in varantRehniTaraflar)
                {
                    if (varantRehniTarafItem.Value.Length == 0) continue;

                    Taraf newTaraf = new Taraf();

                    if (varantRehniTarafItem.Element("TarafSifat") != null) newTaraf.TarafSifat = varantRehniTarafItem.Element("TarafSifat").Value;
                    if (varantRehniTarafItem.Element("MusteriNo") != null) newTaraf.MusteriNo = varantRehniTarafItem.Element("MusteriNo").Value;
                    if (varantRehniTarafItem.Element("Musteri") != null) newTaraf.Musteri = varantRehniTarafItem.Element("Musteri").Value;

                    if (newVarantRehni.Taraflar == null) newVarantRehni.Taraflar = new List<Taraf>();
                    newVarantRehni.Taraflar.Add(newTaraf);
                }

                if (dosya.VarantRehinleri == null) dosya.VarantRehinleri = new List<VarantRehni>();
                dosya.VarantRehinleri.Add(newVarantRehni);
                if (dosya.Rehinler == null) dosya.Rehinler = new List<Rehin>();
                dosya.Rehinler.Add(SetRehinBilgileri("Varant Rehni", newVarantRehni.Tutari, newVarantRehni.TutariParaBirimi, newVarantRehni.RehinTarihi));
            }

            #endregion Varant Rehni

            #region Altın Rehni

            var altinRehinleri = tasfiyeHesap.Descendants("ALTIN_REHINLERI");
            var altinRehni = altinRehinleri.Descendants("ALTIN_REHNI");

            foreach (var altinRehniItem in varantRehni)
            {
                if (altinRehniItem.Value.Length == 0) continue;

                AltinRehni newAltinRehin = new AltinRehni();
                if (altinRehniItem.Element("TeminatReferansNo") != null) newAltinRehin.ReferanNo = altinRehniItem.Element("TeminatReferansNo").Value;
                if (altinRehniItem.Element("Durum") != null) newAltinRehin.Durum = altinRehniItem.Element("Durum").Value;
                if (altinRehniItem.Element("Tutar") != null) newAltinRehin.Tutari = Convert.ToDecimal(altinRehniItem.Element("Tutar").Value == "" ? "0" : altinRehniItem.Element("Tutar").Value);
                if (altinRehniItem.Element("TutarParaBirimi") != null) newAltinRehin.TutariParaBirimi = altinRehniItem.Element("TutarParaBirimi").Value;
                if (altinRehniItem.Element("RehinTuru") != null) newAltinRehin.RehinTuru = altinRehniItem.Element("RehinTuru").Value;
                if (altinRehniItem.Element("RehinTarihi") != null) newAltinRehin.RehinTarihi = Convert.ToDateTime(altinRehniItem.Element("RehinTarihi").Value == "" ? null : altinRehniItem.Element("RehinTarihi").Value);
                if (altinRehniItem.Element("BrutGramaj") != null) newAltinRehin.BrutGramaj = altinRehniItem.Element("BrutGramaj").Value;
                if (altinRehniItem.Element("SaflikDerecesi") != null) newAltinRehin.SaflikDerecesi = altinRehniItem.Element("SaflikDerecesi").Value;
                if (altinRehniItem.Element("Yeddiemin") != null) newAltinRehin.Yeddiemin = altinRehniItem.Element("Yeddiemin").Value;
                if (altinRehniItem.Element("Aciklama") != null) newAltinRehin.Aciklama = altinRehniItem.Element("Aciklama").Value;
                var altinRehniTaraflar = altinRehniItem.Descendants("TARAFLAR");
                foreach (var altinRehniTarafItem in altinRehniTaraflar)
                {
                    if (altinRehniTarafItem.Value.Length == 0) continue;

                    Taraf newTaraf = new Taraf();

                    if (altinRehniTarafItem.Element("TarafSifat") != null) newTaraf.TarafSifat = altinRehniTarafItem.Element("TarafSifat").Value;
                    if (altinRehniTarafItem.Element("MusteriNo") != null) newTaraf.MusteriNo = altinRehniTarafItem.Element("MusteriNo").Value;
                    if (altinRehniTarafItem.Element("Musteri") != null) newTaraf.Musteri = altinRehniTarafItem.Element("Musteri").Value;

                    if (newAltinRehin.Taraflar == null) newAltinRehin.Taraflar = new List<Taraf>();
                    newAltinRehin.Taraflar.Add(newTaraf);
                }

                if (dosya.AltinRehinleri == null) dosya.AltinRehinleri = new List<AltinRehni>();
                dosya.AltinRehinleri.Add(newAltinRehin);
                if (dosya.Rehinler == null) dosya.Rehinler = new List<Rehin>();
                dosya.Rehinler.Add(SetRehinBilgileri("Altın Rehni", newAltinRehin.Tutari, newAltinRehin.TutariParaBirimi, newAltinRehin.RehinTarihi));
            }

            #endregion Altın Rehni

            #region Hat Rehni

            var hatRehinleri = tasfiyeHesap.Descendants("HAT_REHINLERI");
            var hatRehni = hatRehinleri.Descendants("HAT_REHNI");

            foreach (var hatRehniItem in hatRehni)
            {
                if (hatRehniItem.Value.Length == 0) continue;

                HatRehni newHatRehni = new HatRehni();
                if (hatRehniItem.Element("TeminatReferansNo") != null) newHatRehni.ReferanNo = hatRehniItem.Element("TeminatReferansNo").Value;
                if (hatRehniItem.Element("Durum") != null) newHatRehni.Durum = hatRehniItem.Element("Durum").Value;
                if (hatRehniItem.Element("Tutar") != null) newHatRehni.Tutari = Convert.ToDecimal(hatRehniItem.Element("Tutar").Value == "" ? "0" : hatRehniItem.Element("Tutar").Value);
                if (hatRehniItem.Element("TutarParaBirimi") != null) newHatRehni.TutariParaBirimi = hatRehniItem.Element("TutarParaBirimi").Value;
                if (hatRehniItem.Element("RehinTuru") != null) newHatRehni.RehinTuru = hatRehniItem.Element("RehinTuru").Value;
                if (hatRehniItem.Element("RehinTarihi") != null) newHatRehni.RehinTarihi = Convert.ToDateTime(hatRehniItem.Element("RehinTarihi").Value == "" ? null : hatRehniItem.Element("RehinTarihi").Value);
                if (hatRehniItem.Element("HatTuru") != null) newHatRehni.HatTuru = hatRehniItem.Element("HatTuru").Value;
                if (hatRehniItem.Element("HatAdi") != null) newHatRehni.HatAdi = hatRehniItem.Element("HatAdi").Value;
                if (hatRehniItem.Element("AracTipi") != null) newHatRehni.AracTipi = hatRehniItem.Element("AracTipi").Value;
                if (hatRehniItem.Element("AracSasi") != null) newHatRehni.AracSasi = hatRehniItem.Element("AracSasi").Value;
                if (hatRehniItem.Element("AracMarka") != null) newHatRehni.AracMarka = hatRehniItem.Element("AracMarka").Value;
                if (hatRehniItem.Element("AracBayi") != null) newHatRehni.AracBayi = hatRehniItem.Element("AracBayi").Value;
                if (hatRehniItem.Element("Yeddiemin") != null) newHatRehni.Yeddiemin = hatRehniItem.Element("Yeddiemin").Value;
                if (hatRehniItem.Element("Aciklama") != null) newHatRehni.Aciklama = hatRehniItem.Element("Aciklama").Value;
                var hatRehniTaraf = hatRehniItem.Descendants("TARAFLAR");
                foreach (var hatRehniTarafItem in hatRehniTaraf)
                {
                    if (hatRehniTarafItem.Value.Length == 0) continue;

                    Taraf newTaraf = new Taraf();

                    if (hatRehniTarafItem.Element("TarafSifat") != null) newTaraf.TarafSifat = hatRehniTarafItem.Element("TarafSifat").Value;
                    if (hatRehniTarafItem.Element("MusteriNo") != null) newTaraf.MusteriNo = hatRehniTarafItem.Element("MusteriNo").Value;
                    if (hatRehniTarafItem.Element("Musteri") != null) newTaraf.Musteri = hatRehniTarafItem.Element("Musteri").Value;

                    if (newHatRehni.Taraflar == null) newHatRehni.Taraflar = new List<Taraf>();
                    newHatRehni.Taraflar.Add(newTaraf);
                }

                if (dosya.HatRehinleri == null) dosya.HatRehinleri = new List<HatRehni>();
                dosya.HatRehinleri.Add(newHatRehni);
                if (dosya.Rehinler == null) dosya.Rehinler = new List<Rehin>();
                dosya.Rehinler.Add(SetRehinBilgileri("Hat Rehni", newHatRehni.Tutari, newHatRehni.TutariParaBirimi, newHatRehni.RehinTarihi));
            }

            #endregion Hat Rehni

            #region Makbuz Senedi Rehni

            var makbuzSenediRehinleri = tasfiyeHesap.Descendants("MAKBUZ_SENEDI_REHINLERI");
            var makbuzSenediRehni = makbuzSenediRehinleri.Descendants("MAKBUZ_SENEDI_REHNI");

            foreach (var makbuzSenediRehniItem in makbuzSenediRehni)
            {
                if (makbuzSenediRehniItem.Value.Length == 0) continue;

                MakbuzSenediRehni newMakbuzSenediRehni = new MakbuzSenediRehni();
                if (makbuzSenediRehniItem.Element("TeminatReferansNo") != null) newMakbuzSenediRehni.ReferanNo = makbuzSenediRehniItem.Element("TeminatReferansNo").Value;
                if (makbuzSenediRehniItem.Element("Durum") != null) newMakbuzSenediRehni.Durum = makbuzSenediRehniItem.Element("Durum").Value;
                if (makbuzSenediRehniItem.Element("Tutar") != null) newMakbuzSenediRehni.Tutari = Convert.ToDecimal(makbuzSenediRehniItem.Element("Tutar").Value == "" ? "0" : makbuzSenediRehniItem.Element("Tutar").Value);
                if (makbuzSenediRehniItem.Element("TutarParaBirimi") != null) newMakbuzSenediRehni.TutariParaBirimi = makbuzSenediRehniItem.Element("TutarParaBirimi").Value;
                if (makbuzSenediRehniItem.Element("RehinTuru") != null) newMakbuzSenediRehni.RehinTuru = makbuzSenediRehniItem.Element("RehinTuru").Value;
                if (makbuzSenediRehniItem.Element("RehinTarihi") != null) newMakbuzSenediRehni.RehinTarihi = Convert.ToDateTime(makbuzSenediRehniItem.Element("RehinTarihi").Value == "" ? null : makbuzSenediRehniItem.Element("RehinTarihi").Value);
                if (makbuzSenediRehniItem.Element("Yeddiemin") != null) newMakbuzSenediRehni.Yeddiemin = makbuzSenediRehniItem.Element("Yeddiemin").Value;
                if (makbuzSenediRehniItem.Element("Aciklama") != null) newMakbuzSenediRehni.Aciklama = makbuzSenediRehniItem.Element("Aciklama").Value;
                var makbuzSenediRehniTaraflar = makbuzSenediRehniItem.Descendants("TARAFLAR");
                foreach (var makbuzSenediRehniTarafItem in makbuzSenediRehniTaraflar)
                {
                    if (makbuzSenediRehniTarafItem.Value.Length == 0) continue;

                    Taraf newTaraf = new Taraf();

                    if (makbuzSenediRehniTarafItem.Element("TarafSifat") != null) newTaraf.TarafSifat = makbuzSenediRehniTarafItem.Element("TarafSifat").Value;
                    if (makbuzSenediRehniTarafItem.Element("MusteriNo") != null) newTaraf.MusteriNo = makbuzSenediRehniTarafItem.Element("MusteriNo").Value;
                    if (makbuzSenediRehniTarafItem.Element("Musteri") != null) newTaraf.Musteri = makbuzSenediRehniTarafItem.Element("Musteri").Value;

                    if (newMakbuzSenediRehni.Taraflar == null) newMakbuzSenediRehni.Taraflar = new List<Taraf>();
                    newMakbuzSenediRehni.Taraflar.Add(newTaraf);
                }

                if (dosya.MakbuzSenediRehinleri == null) dosya.MakbuzSenediRehinleri = new List<MakbuzSenediRehni>();
                dosya.MakbuzSenediRehinleri.Add(newMakbuzSenediRehni);
                if (dosya.Rehinler == null) dosya.Rehinler = new List<Rehin>();
                dosya.Rehinler.Add(SetRehinBilgileri("Makbuz Senedi Rehni", newMakbuzSenediRehni.Tutari, newMakbuzSenediRehni.TutariParaBirimi, newMakbuzSenediRehni.RehinTarihi));
            }

            #endregion Makbuz Senedi Rehni

            #region Diğerleri

            var digerleri = tasfiyeHesap.Descendants("DIGERLERI");
            var diger = digerleri.Descendants("DIGER");

            foreach (var digerItem in diger)
            {
                if (digerItem.Value.Length == 0) continue;

                DigerRehin newDiger = new DigerRehin();
                if (digerItem.Element("TeminatReferansNo") != null) newDiger.ReferanNo = digerItem.Element("TeminatReferansNo").Value;
                if (digerItem.Element("Durum") != null) newDiger.Durum = digerItem.Element("Durum").Value;
                if (digerItem.Element("Tutar") != null) newDiger.Tutari = Convert.ToDecimal(digerItem.Element("Tutar").Value == "" ? "0" : digerItem.Element("Tutar").Value);
                if (digerItem.Element("TutarParaBirimi") != null) newDiger.TutariParaBirimi = digerItem.Element("TutarParaBirimi").Value;
                if (digerItem.Element("RehinTuru") != null) newDiger.RehinTuru = digerItem.Element("RehinTuru").Value;
                if (digerItem.Element("RehinTarihi") != null) newDiger.RehinTarihi = Convert.ToDateTime(digerItem.Element("RehinTarihi").Value == "" ? null : digerItem.Element("RehinTarihi").Value);
                if (digerItem.Element("Yeddiemin") != null) newDiger.Yeddiemin = digerItem.Element("Yeddiemin").Value;
                if (digerItem.Element("Aciklama") != null) newDiger.Aciklama = digerItem.Element("Aciklama").Value;

                var digerRehinTaraflar = digerItem.Descendants("TARAFLAR");
                foreach (var digerRehinTarafItem in digerRehinTaraflar)
                {
                    if (digerRehinTarafItem.Value.Length == 0) continue;

                    Taraf newTaraf = new Taraf();

                    if (digerRehinTarafItem.Element("TarafSifat") != null) newTaraf.TarafSifat = digerRehinTarafItem.Element("TarafSifat").Value;
                    if (digerRehinTarafItem.Element("MusteriNo") != null) newTaraf.MusteriNo = digerRehinTarafItem.Element("MusteriNo").Value;
                    if (digerRehinTarafItem.Element("Musteri") != null) newTaraf.Musteri = digerRehinTarafItem.Element("Musteri").Value;

                    if (newDiger.Taraflar == null) newDiger.Taraflar = new List<Taraf>();
                    newDiger.Taraflar.Add(newTaraf);
                }

                if (dosya.DigerRehinler == null) dosya.DigerRehinler = new List<DigerRehin>();
                dosya.DigerRehinler.Add(newDiger);
            }

            #endregion Diğerleri

            #endregion Teminatlar

            #region Sözleşme

            var sozlesmeler = tasfiyeHesap.Descendants("SOZLESMELER");
            var sozlesme = sozlesmeler.Descendants("SOZLESME");
            foreach (var sozlesmeItem in sozlesme)
            {
                if (sozlesmeItem.Value.Length == 0) continue;

                Sozlesmeler newSozlesme = new Sozlesmeler();

                if (sozlesmeItem.Element("Tip") != null) newSozlesme.Tip = sozlesmeItem.Element("Tip").Value;
                if (sozlesmeItem.Element("Bedeli") != null) newSozlesme.Bedeli = Convert.ToDecimal(sozlesmeItem.Element("Bedeli").Value == "" ? "0" : sozlesmeItem.Element("Bedeli").Value);
                if (sozlesmeItem.Element("BedeliParaBirimi") != null) newSozlesme.BedeliParaBirimi = sozlesmeItem.Element("BedeliParaBirimi").Value;
                if (sozlesmeItem.Element("ImzaTarihi") != null) newSozlesme.ImzaTarihi = Convert.ToDateTime(sozlesmeItem.Element("ImzaTarihi").Value == "" ? null : sozlesmeItem.Element("ImzaTarihi").Value);

                var sozlesmeTaraflari = sozlesmeItem.Descendants("TARAFLAR");
                foreach (var sozlesmeTarafItem in sozlesmeTaraflari)
                {
                    if (sozlesmeTarafItem.Value.Length == 0) continue;

                    SozlesmeTaraf taraf = new SozlesmeTaraf();

                    if (sozlesmeTarafItem.Element("MusteriNo") != null) taraf.MusteriNo = sozlesmeTarafItem.Element("MusteriNo").Value;
                    if (sozlesmeTarafItem.Element("Musteri") != null) taraf.Musteri = sozlesmeTarafItem.Element("Musteri").Value;
                    if (sozlesmeTarafItem.Element("TarafSifat") != null) taraf.TarafSifat = sozlesmeTarafItem.Element("TarafSifat").Value;
                    if (sozlesmeTarafItem.Element("SorumlulukMiktari") != null) taraf.SorumluOlunanMiktar = Convert.ToDouble(sozlesmeTarafItem.Element("SorumlulukMiktari").Value == "" ? "0" : sozlesmeTarafItem.Element("SorumlulukMiktari").Value);
                    if (sozlesmeTarafItem.Element("SorumlulukMiktariParaBirimi") != null) taraf.SorumluOlunanMiktarParaBirimi = sozlesmeTarafItem.Element("SorumlulukMiktariParaBirimi").Value;

                    if (newSozlesme.Taraflar == null) newSozlesme.Taraflar = new List<SozlesmeTaraf>();
                    newSozlesme.Taraflar.Add(taraf);
                }
                if (dosya.Sozlesmeler == null) dosya.Sozlesmeler = new List<Sozlesmeler>();
                dosya.Sozlesmeler.Add(newSozlesme);
            }

            #endregion Sözleşme

            #endregion Tasfiye Hesap

            #region Taraflar

            var taraflar = doc.Descendants("TARAFLAR");
            var cari = taraflar.Descendants("Cari");
            foreach (var cariItem in cari)
            {
                if (cariItem.Value.Length == 0) continue;

                CariBilgileri sahis = new CariBilgileri();

                //sahis.TarafSifat = cariItem.Element("TarafSifat").Value;
                if (cariItem.Element("Kod") != null) sahis.Kod = cariItem.Element("Kod").Value;
                if (cariItem.Element("Ad") != null) sahis.Ad = cariItem.Element("Ad").Value;
                if (cariItem.Element("FirmaTuru") != null) sahis.FirmaTuru = cariItem.Element("FirmaTuru").Value;
                if (cariItem.Element("TicariSicilYeri") != null) sahis.TicariSicilYeri = cariItem.Element("TicariSicilYeri").Value;
                if (cariItem.Element("TicariSicilTarihi") != null) sahis.TicariSicilTarihi = cariItem.Element("TicariSicilTarihi").Value;
                if (cariItem.Element("TicariSicilNo") != null) sahis.TicariSicilNo = cariItem.Element("TicariSicilNo").Value;
                if (cariItem.Element("AktifAdres") != null) sahis.AktifAdres = cariItem.Element("AktifAdres").Value;
                if (cariItem.Element("Adres1Tur") != null) sahis.Adres1Tur = cariItem.Element("Adres1Tur").Value;
                if (cariItem.Element("Adres1Ln1") != null) sahis.Adres1Line1 = cariItem.Element("Adres1Ln1").Value;
                if (cariItem.Element("Adres1Ln2") != null) sahis.Adres1Line2 = cariItem.Element("Adres1Ln2").Value;
                if (cariItem.Element("Adres1Ln3") != null) sahis.Adres1Line3 = cariItem.Element("Adres1Ln3").Value;
                if (cariItem.Element("PostaKod1") != null) sahis.PostaKodu1 = cariItem.Element("PostaKod1").Value;
                if (cariItem.Element("Ilce1") != null) sahis.Ilce1 = cariItem.Element("Ilce1").Value;
                if (cariItem.Element("Il1") != null) sahis.Il1 = cariItem.Element("Il1").Value;
                if (cariItem.Element("Ulke1") != null) sahis.Ulke1 = cariItem.Element("Ulke1").Value;
                if (cariItem.Element("Adres2Tur") != null) sahis.Adres2Tur = cariItem.Element("Adres2Tur").Value;
                if (cariItem.Element("Adres2Ln1") != null) sahis.Adres2Line1 = cariItem.Element("Adres2Ln1").Value;
                if (cariItem.Element("Adres2Ln2") != null) sahis.Adres2Line2 = cariItem.Element("Adres2Ln2").Value;
                if (cariItem.Element("Adres2Ln3") != null) sahis.Adres2Line3 = cariItem.Element("Adres2Ln3").Value;
                if (cariItem.Element("PostaKod2") != null) sahis.PostaKodu2 = cariItem.Element("PostaKod2").Value;
                if (cariItem.Element("PostaKod3") != null) sahis.PostaKodu3 = cariItem.Element("PostaKod3").Value;
                if (cariItem.Element("Ilce2") != null) sahis.Ilce2 = cariItem.Element("Ilce2").Value;
                if (cariItem.Element("Il2") != null) sahis.Il2 = cariItem.Element("Il2").Value;
                if (cariItem.Element("Ulke2") != null) sahis.Ulke2 = cariItem.Element("Ulke2").Value;
                if (cariItem.Element("Adres3Tur") != null) sahis.Adres3Tur = cariItem.Element("Adres3Tur").Value;
                if (cariItem.Element("Adres3Ln1") != null) sahis.Adres3Line1 = cariItem.Element("Adres3Ln1").Value;
                if (cariItem.Element("Adres3Ln2") != null) sahis.Adres3Line2 = cariItem.Element("Adres3Ln2").Value;
                if (cariItem.Element("Adres3Ln3") != null) sahis.Adres3Line3 = cariItem.Element("Adres3Ln3").Value;
                if (cariItem.Element("Ilce3") != null) sahis.Ilce3 = cariItem.Element("Ilce3").Value;
                if (cariItem.Element("Il3") != null) sahis.Il3 = cariItem.Element("Il3").Value;
                if (cariItem.Element("Ulke3") != null) sahis.Ulke3 = cariItem.Element("Ulke3").Value;
                if (cariItem.Element("Tel1") != null) sahis.Telefon1 = cariItem.Element("Tel1").Value;
                if (cariItem.Element("Tel2") != null) sahis.Telefon2 = cariItem.Element("Tel2").Value;
                if (cariItem.Element("Fax") != null) sahis.Fax = cariItem.Element("Fax").Value;
                if (cariItem.Element("Gsm1") != null) sahis.GSM1 = cariItem.Element("Gsm1").Value;
                if (cariItem.Element("Gsm2") != null) sahis.GSM2 = cariItem.Element("Gsm2").Value;
                if (cariItem.Element("Email1") != null) sahis.EMail1 = cariItem.Element("Email1").Value;
                if (cariItem.Element("Email2") != null) sahis.EMail2 = cariItem.Element("Email2").Value;
                if (cariItem.Element("WebURL") != null) sahis.WebURL = cariItem.Element("WebURL").Value;
                if (cariItem.Element("Meslek") != null) sahis.Meslek = cariItem.Element("Meslek").Value;
                if (cariItem.Element("VergiDairesi") != null) sahis.VergiDairesi = cariItem.Element("VergiDairesi").Value;
                if (cariItem.Element("VergiNo") != null) sahis.VergiNo = cariItem.Element("VergiNo").Value;
                if (cariItem.Element("Iban") != null) sahis.IBAN = cariItem.Element("Iban").Value;

                var kimlik = cariItem.Descendants("Kimlik");
                foreach (var kimlikItem in kimlik)
                {
                    if (kimlikItem.Value.Length == 0) continue;

                    if (kimlikItem.Element("KimlikTuru") != null) sahis.KimlikTuru = kimlikItem.Element("KimlikTuru").Value;
                    if (kimlikItem.Element("Uyruk") != null) sahis.Uyruk = kimlikItem.Element("Uyruk").Value;
                    if (kimlikItem.Element("OncekiSoyadi") != null) sahis.OncekiSoyadi = kimlikItem.Element("OncekiSoyadi").Value;
                    if (kimlikItem.Element("AnneKizlikSoyAdi") != null) sahis.AnneKizlikSoyadi = kimlikItem.Element("AnneKizlikSoyAdi").Value;
                    if (kimlikItem.Element("TCKimlikNo") != null) sahis.TCKimlikNo = kimlikItem.Element("TCKimlikNo").Value;
                    if (kimlikItem.Element("KimlikSeriNo") != null) sahis.KimlikSeriNo = kimlikItem.Element("KimlikSeriNo").Value;
                    if (kimlikItem.Element("Cinsiyet") != null) sahis.Cinsiyet = kimlikItem.Element("Cinsiyet").Value;
                    if (kimlikItem.Element("BabaAdi") != null) sahis.BabaAdi = kimlikItem.Element("BabaAdi").Value;
                    if (kimlikItem.Element("AnaAdi") != null) sahis.AnaAdi = kimlikItem.Element("AnaAdi").Value;
                    if (kimlikItem.Element("DogumYeri") != null) sahis.DogumYeri = kimlikItem.Element("DogumYeri").Value;
                    if (kimlikItem.Element("DogumTarihi") != null) sahis.DogumTarihi = kimlikItem.Element("DogumTarihi").Value;
                    if (kimlikItem.Element("MedeniHal") != null) sahis.MedeniHal = kimlikItem.Element("MedeniHal").Value;
                    if (kimlikItem.Element("Dini") != null) sahis.Dini = kimlikItem.Element("Dini").Value;
                    if (kimlikItem.Element("KanGrup") != null) sahis.KanGrup = kimlikItem.Element("KanGrup").Value;
                    if (kimlikItem.Element("NKIl") != null) sahis.NKIl = kimlikItem.Element("NKIl").Value;
                    if (kimlikItem.Element("NKIlce") != null) sahis.NKIlce = kimlikItem.Element("NKIlce").Value;
                    if (kimlikItem.Element("NKMahalle") != null) sahis.NKMahalle = kimlikItem.Element("NKMahalle").Value;
                    if (kimlikItem.Element("CiltNo") != null) sahis.CiltNo = kimlikItem.Element("CiltNo").Value;
                    if (kimlikItem.Element("AileSiraNo") != null) sahis.AileSeriNo = kimlikItem.Element("AileSiraNo").Value;
                    if (kimlikItem.Element("SiraNo") != null) sahis.SiraNo = kimlikItem.Element("SiraNo").Value;
                    if (kimlikItem.Element("VerildigiYer") != null) sahis.KimlikVerildigiYer = kimlikItem.Element("VerildigiYer").Value;
                    if (kimlikItem.Element("VerildigiTarih") != null) sahis.KimlikVerildigiTarih = Convert.ToDateTime(kimlikItem.Element("VerildigiTarih").Value == "" ? null : kimlikItem.Element("VerildigiTarih").Value);
                    //if (kimlikItem.Element("VerildigiTarih") == null)
                    //sahis.KimlikVerildigiTarih = null;
                    if (kimlikItem.Element("VerilmeNedeni") != null) sahis.VerilmeNedeni = kimlikItem.Element("VerilmeNedeni").Value;
                    if (kimlikItem.Element("KimlikKayitNo") != null) sahis.KimlikKayitNo = kimlikItem.Element("KimlikKayitNo").Value;
                }

                var ozelBilgiler = cariItem.Descendants("OzelBilgiler");
                foreach (var ozelBilgilerItem in ozelBilgiler)
                {
                    if (ozelBilgilerItem.Value.Length == 0) continue;

                    if (ozelBilgilerItem.Element("OgrenimDurumu") != null) sahis.OgrenimDurumu = ozelBilgilerItem.Element("OgrenimDurumu").Value;
                    if (ozelBilgilerItem.Element("SonMezuniyetOkul") != null) sahis.SonMezuniyetOkul = ozelBilgilerItem.Element("SonMezuniyetOkul").Value;
                    if (ozelBilgilerItem.Element("SonCalistigiKurum") != null) sahis.SonCalistigiKurum = ozelBilgilerItem.Element("SonCalistigiKurum").Value;
                }

                if (dosya.Cariler == null) dosya.Cariler = new List<CariBilgileri>();
                dosya.Cariler.Add(sahis);
            }

            #endregion Taraflar

            return dosya;
        }

        public static Classes.Rehin SetRehinBilgileri(string tip, decimal tutar, string paraBirimi, DateTime imzaTarihi)
        {
            Rehin rehin = new Rehin();
            rehin.Tip = tip;
            rehin.Bedeli = tutar;
            rehin.BedeliParaBirimi = paraBirimi;
            rehin.ImzaTarihi = imzaTarihi;

            return rehin;
        }
    }
}