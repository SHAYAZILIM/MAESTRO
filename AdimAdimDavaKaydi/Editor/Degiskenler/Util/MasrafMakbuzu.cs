using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using TXTextControl;

namespace AdimAdimDavaKaydi.Editor.Degiskenler.Util
{
    public static class MasrafMakbuzu
    {
        public static void MasrafMakbuzuGetir(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> masrafDetaylar)
        {
            DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.DeepLoad(masrafDetaylar, false, DeepLoadType.IncludeChildren,
                typeof(AV001_TDI_BIL_MASRAF_AVANS));

            List<Makbuz> liste = new List<Makbuz>();

            frmEditor editor = new frmEditor();
            editor.MdiParent = mdiAvukatPro.MainForm;
            editor.Show();

            #region Liste hazırlanıyor

            foreach (var detay in masrafDetaylar)
            {
                var masraf = detay.MASRAF_AVANS_IDSource;

                //if (masraf.IS_PRINT.HasValue ? masraf.IS_PRINT.Value : false) continue;

                var makbuzlar = liste.Where(vi => vi.MasrafiYapanCariId == masraf.CARI_ID && vi.KarsiTarafCariId == masraf.BORCLU_CARI_ID);
                if (makbuzlar.Count() > 0)
                {
                    var makbuz = makbuzlar.First();
                    makbuz.Kalemler.Add(new MakbuzKalemi()
                    {
                        HAREKET_ALT_KATEGORI_ID = detay.HAREKET_ALT_KATEGORI_ID,
                        Tutar = new ParaVeDovizId(detay.TOPLAM_TUTAR, detay.TOPLAM_TUTAR_DOVIZ_ID),
                        Tarih = detay.TARIH
                    });
                }
                else
                {
                    liste.Add(new Makbuz(detay));
                }

                //Masraf makbuzunun sadece bir kere yazdırılmasını sağlamak için eklendi.
                //masraf.IS_PRINT = true;
                //DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.Save(masraf);
            }
            List<EditorDokuman> dokumanListesi = new List<EditorDokuman>();
            AV001_TDIE_BIL_SABLON_RAPOR rapor = DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.GetByID(1232);
            foreach (var item in liste)
            {
                dokumanListesi.Add(Print(editor.CurrentEditor.textControl1, item, rapor, masrafDetaylar.First()));
            }
            editor.DokumanListesi = dokumanListesi;

            #endregion Liste hazırlanıyor
        }

        public static List<EditorDokuman> MasrafMakbuzuGetirForTakitSeti(AV001_TI_BIL_FOY foy, TextControl txControl)
        {
            var masrafList = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByICRA_FOY_ID(foy.ID);
            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> detayList = new TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>();
            foreach (var item in masrafList)
            {
                if (item.IS_PRINT.HasValue ? item.IS_PRINT.Value : false) continue;

                DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));
                detayList.AddRange(item.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection);
            }

            DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.DeepLoad(detayList, false, DeepLoadType.IncludeChildren,
                typeof(AV001_TDI_BIL_MASRAF_AVANS));

            List<Makbuz> liste = new List<Makbuz>();

            #region Liste hazırlanıyor

            foreach (var detay in detayList)
            {
                var masraf = detay.MASRAF_AVANS_IDSource;
                var makbuzlar = liste.Where(vi => vi.MasrafiYapanCariId == masraf.CARI_ID && vi.KarsiTarafCariId == masraf.BORCLU_CARI_ID);
                if (makbuzlar.Count() > 0)
                {
                    var makbuz = makbuzlar.First();
                    makbuz.Kalemler.Add(new MakbuzKalemi()
                    {
                        HAREKET_ALT_KATEGORI_ID = detay.HAREKET_ALT_KATEGORI_ID,
                        Tutar = new ParaVeDovizId(detay.TOPLAM_TUTAR, detay.TOPLAM_TUTAR_DOVIZ_ID),
                        Tarih = detay.TARIH
                    });
                }
                else
                {
                    liste.Add(new Makbuz(detay));
                }

                //Masraf makbuzunun sadece bir kere yazdırılmasını sağlamak için eklendi.
                masraf.IS_PRINT = true;
                DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepSave(masraf);
            }

            List<EditorDokuman> dokumanListesi = new List<EditorDokuman>();
            AV001_TDIE_BIL_SABLON_RAPOR rapor = DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.GetByID(1232);
            foreach (var item in liste)
            {
                var editorItem = Print(txControl, item, rapor, detayList.First());
                editorItem.GecerliFoy = foy;
                editorItem.Ad = "Masraf Makbuzu";
                dokumanListesi.Add(editorItem);
            }
            return dokumanListesi;

            #endregion Liste hazırlanıyor
        }

        #region <MB-20100707>

        //Toplam tutarın yazıyla yazılmasını sağlamak için eklendi.
        private static string NumberToText(decimal tNumber)
        {
            string[] aDigits = new[] { "Bir", "İki", "Üç", "Dört", "Beş", "Altı", "Yedi", "Sekiz", "Dokuz" };
            string[] aTwoDigits = new[] { "On", "Yirmi", "Otuz", "Kırk", "Elli", "Altmış", "Yetmiş", "Seksen", "Doksan" };
            string[] aDigitBlocks = new[] { string.Empty, "Bin", "Milyon", "Milyar", "Trilyon", "Katrilyon", "Kenttrilyon" };

            int tripleBlock = 0;
            string houndredGroup = string.Empty;
            string convertedText = string.Empty;

            decimal convertedNumber = Math.Abs(tNumber);
            string numberText = convertedNumber.ToString().Trim();
            int numberLenght = numberText.Length;

            if (convertedNumber != 0)
            {
                do
                {
                    string digit = string.Empty;
                    numberLenght = (numberLenght - (numberLenght >= 3 ? 3 : numberLenght));
                    string houndredBlock = numberText.Substring(numberLenght);

                    for (int i = 0; i <= (houndredBlock.Length - 1); i++)
                    {
                        int digitInHoundred = Convert.ToInt32(houndredBlock.Substring(i, 1));
                        int positionInHoundred = houndredBlock.Length - i - 1;

                        if (digitInHoundred == 0)
                            continue;

                        houndredGroup = houndredGroup + (positionInHoundred == 0
                                                             ? aDigits[digitInHoundred - 1]
                                                             : (positionInHoundred == 1
                                                                    ? aTwoDigits[digitInHoundred - 1]
                                                                    : (digitInHoundred == 1)
                                                                          ? "Yüz"
                                                                          : aDigits[digitInHoundred - 1] +
                                                                            "Yüz"
                                                               ));

                        digit = aDigitBlocks[tripleBlock];
                    }

                    convertedText = houndredGroup + digit + convertedText;
                    houndredGroup = string.Empty;
                    numberText = numberText.Substring(0, numberLenght);
                    tripleBlock++;
                } while (numberLenght > 0);

                if (convertedText.Length >= 6 && convertedText.Substring(0, 6) == "BirBin")
                    convertedText = convertedText.Substring(3);
            }
            else
            {
                convertedText = "Sıfır";
            }

            return ((tNumber < 0) ? "Eksi " : string.Empty) + convertedText;
        }

        #endregion <MB-20100707>

        private static EditorDokuman Print(TextControl txControl, Makbuz makbuz, AV001_TDIE_BIL_SABLON_RAPOR rapor, AV001_TDI_BIL_MASRAF_AVANS_DETAY detay)
        {
            EditorAraclari arac = new EditorAraclari();
            EditorDokuman dokuman = new EditorDokuman(detay);

            //dokuman.Sablon = rapor;
            dokuman.Dokuman = rapor.DOSYA;

            var fields = arac.GetFieldListByEditorDokumanAndTextControl(dokuman, txControl);

            foreach (var field in fields)
            {
                #region Switch

                switch (field.Text)
                {
                    case "[MASRAF-AVANS] ICRA DAIRESI MAHKEME ADI":
                        field.Text = makbuz.IcraDairesiMahkemeAdi;
                        break;

                    case "[MASRAF-AVANS] KARSI TARAF":
                        field.Text = makbuz.KarsiTaraf;
                        break;

                    case "[MASRAF-AVANS] KREDI BORCLUSU":
                        field.Text = makbuz.KrediBorclusu;
                        break;

                    case "[MASRAF-AVANS] KREDI TURU":
                        field.Text = makbuz.KrediTuru;
                        break;

                    case "[MASRAF-AVANS] MASRAF ACIKLAMASI":
                        field.Text = makbuz.MasrafAciklamasi;
                        break;

                    case "[MASRAF-AVANS] MASRAFI YAPAN":
                        field.Text = makbuz.MasrafiYapan;
                        break;

                    case "[MASRAF-AVANS] ONAYLAYAN":
                        field.Text = makbuz.Onaylayan;
                        break;

                    case "[MASRAF-AVANS] SORUMLU AVUKAT":
                        field.Text = makbuz.SorumluAvukat;
                        break;

                    case "[MASRAF-AVANS] SUBESI":
                        field.Text = makbuz.Subesi;
                        break;

                    case "[MASRAF-AVANS] ESAS NO":
                        field.Text = makbuz.EsasNo;
                        break;

                    case "[MASRAF-AVANS] DOSYA NO":
                        field.Text = makbuz.DosyaNo;
                        break;

                    case "[MASRAF-AVANS] TARIH":
                        field.Text = EditorDataAraclari.Tools.TarihBicimlendirme(makbuz.Tarih);// DateTime.Now);
                        break;

                    case "[MASRAF-AVANS] KALEMLER":

                        #region Kalemler

                        if (makbuz.Kalemler.Count > 0)
                        {
                            makbuz.Kalemler.Add(new MakbuzKalemi()
                            {
                                Tutar = ParaVeDovizId.Topla(makbuz.Kalemler.Select(vi => vi.Tutar).ToList()),
                                HAREKET_ALT_KATEGORI_ID = 0
                            });
                            field.Text = " ";

                            txControl.Select(field.Start, 0);

                            txControl.Tables.Add(makbuz.Kalemler.Count, 3, 654);

                            var mainTable = txControl.Tables.GetItem(654);

                            //Toplam tutarın yazıyla yazılmasını sağlamak için eklendi.
                            txControl.Tables.Add(1, 1, 655);
                            var aciklama = txControl.Tables.GetItem(655);

                            //

                            var enume = mainTable.Cells.GetEnumerator();

                            while (enume.MoveNext())
                            {
                                var cell = enume.Current as TableCell;

                                var kayıt = makbuz.Kalemler[cell.Row - 1];

                                if (cell.Column == 2)
                                {
                                    cell.Select();
                                    txControl.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Left;

                                    if (kayıt.HAREKET_ALT_KATEGORI_ID != 0)
                                        cell.Text = DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByID(kayıt.HAREKET_ALT_KATEGORI_ID).ALT_KATEGORI;
                                    else
                                        cell.Text = "Toplam";
                                }
                                else if (cell.Column == 3)
                                {
                                    cell.Select();
                                    txControl.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Right;

                                    cell.Text = kayıt.Tutar.GetStringValue();
                                }
                                else if (cell.Column == 1)
                                {
                                    cell.Select();
                                    if (kayıt.Tarih != null)
                                        cell.Text = EditorDataAraclari.Tools.TarihBicimlendirme(kayıt.Tarih);
                                }
                            }

                            #region <MB-20100707>

                            //Toplam tutarın yazıyla yazılmasını sağlamak için eklendi.
                            string[] dizim = makbuz.Kalemler[makbuz.Kalemler.Count - 1].Tutar.ToString().Trim().Split(',', 'T', 'L', '.');
                            string para = string.Empty;
                            string kurus = string.Empty;

                            for (int i = 0; i < dizim.Length; i++)
                            {
                                if (dizim[i] == "")
                                {
                                    kurus = dizim[i - 1];
                                    para = para.Trim();
                                    para = para.Remove(para.Length - 2, 2);
                                    break;
                                }
                                para += dizim[i];
                            }
                            if (kurus == string.Empty)
                            {
                                kurus = para.Substring(para.Length - 2, 2);
                                para = para.Remove(para.Length - 2, 2);
                            }
                            aciklama.Cells.GetItem(1, 1).Text = NumberToText(Convert.ToDecimal(para)) + " Türk Lirası " + NumberToText(Convert.ToDecimal(kurus)) + " Kuruş.";
                        }

                            #endregion <MB-20100707>

                        #endregion Kalemler

                        break;

                    case "[MASRAF-AVANS] REFERANS_NO":
                        field.Text = makbuz.ReferansNo;
                        break;

                    default:
                        break;
                }

                #endregion Switch
            }
            byte[] dizi;
            txControl.Save(out dizi, BinaryStreamType.InternalFormat);
            dokuman.Dokuman = dizi;
            return dokuman;
        }

        private class Makbuz
        {
            public Makbuz()
            {
                this.Kalemler = new List<MakbuzKalemi>();
            }

            public Makbuz(AV001_TDI_BIL_MASRAF_AVANS_DETAY mDetay)
                : this()
            {
                var masraf = mDetay.MASRAF_AVANS_IDSource;

                this.Tarih = mDetay.TARIH;
                this.Kalemler.Add(new MakbuzKalemi()
                {
                    HAREKET_ALT_KATEGORI_ID = mDetay.HAREKET_ALT_KATEGORI_ID,
                    Tutar = new ParaVeDovizId(mDetay.TOPLAM_TUTAR, mDetay.TOPLAM_TUTAR_DOVIZ_ID),
                    Tarih = mDetay.TARIH
                });

                #region <İCRA>

                if (masraf.ICRA_FOY_IDSource == null)
                {
                    DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(masraf, false, DeepLoadType.IncludeChildren,
                        typeof(AV001_TI_BIL_FOY));
                }

                if (masraf.ICRA_FOY_IDSource != null)
                {
                    if (masraf.ICRA_FOY_IDSource.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(masraf.ICRA_FOY_IDSource,
                            false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));

                    this.ReferansNo = masraf.REFERANS_NO;
                    this.EsasNo = masraf.ICRA_FOY_IDSource.ESAS_NO;
                    this.DosyaNo = masraf.ICRA_FOY_IDSource.FOY_NO;
                    this.MasrafAciklamasi = masraf.ACIKLAMA;
                    this.MasrafiYapanCariId = masraf.CARI_ID;
                    this.KarsiTarafCariId = masraf.BORCLU_CARI_ID;
                    this.IcraDairesiMahkemeAdi = string.Format("{0} {1} {2}",
                        EditorDataAraclari.Icra.GetAdliyeAdi(masraf.ICRA_FOY_IDSource.ADLI_BIRIM_ADLIYE_ID),
                        EditorDataAraclari.Icra.GetAdliBirimNo(masraf.ICRA_FOY_IDSource.ADLI_BIRIM_NO_ID),
                        EditorDataAraclari.Icra.GetAdliBirimGorev(masraf.ICRA_FOY_IDSource.ADLI_BIRIM_GOREV_ID));

                    foreach (var item in masraf.ICRA_FOY_IDSource.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                    {
                        if (item.YETKILI_MI && !this.OnaylayanCariId.HasValue)
                            this.OnaylayanCariId = item.SORUMLU_AVUKAT_CARI_ID;
                        else if (!item.YETKILI_MI && !this.SorumluAvukatCariId.HasValue)
                            this.SorumluAvukatCariId = item.SORUMLU_AVUKAT_CARI_ID;
                    }

                    #region <MB-20100616>

                    //Sorumlu Avukat bilgisinin gelmesini sağlamak için eklendi.

                    if (this.SorumluAvukatCariId == null)
                        this.SorumluAvukatCariId = this.OnaylayanCariId;

                    #endregion <MB-20100616>

                    if (masraf.ICRA_FOY_IDSource.AV001_TDIE_BIL_PROJECollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY.Count == 0)
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(masraf.ICRA_FOY_IDSource, false, DeepLoadType.IncludeChildren,
                            typeof(TList<AV001_TDIE_BIL_PROJE>));

                    List<string> alacakListesi = new List<string>();

                    if (masraf.ICRA_FOY_IDSource.AV001_TDIE_BIL_PROJECollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY.Count > 0)
                    {
                        var proje = masraf.ICRA_FOY_IDSource.AV001_TDIE_BIL_PROJECollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY.First();

                        this.KrediBorclusu = proje.ADI;
                        this.SubeId = proje.OZEL_KOD1_ID;

                        #region <MB-20100617>

                        //Dosyanın klasör bilgisi varsa, alacak bilgilerinin klasörden gelmesini sağlamak için eklendi. Dosya klasöre bağlı değilse alacak bilgilerini, kendi üzerinden alıyor.

                        if (proje != null && proje.AV001_TDIE_BIL_PROJE_ALACAK_NEDENCollection.Count == 0)
                            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_ALACAK_NEDEN>));
                        if (proje != null && proje.AV001_TDIE_BIL_PROJE_ALACAK_NEDENCollection.Count > 0)
                        {
                            foreach (var alacak in proje.AV001_TDIE_BIL_PROJE_ALACAK_NEDENCollection)
                            {
                                if (alacak.ALACAK_NEDEN_IDSource == null)
                                    DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDENProvider.DeepLoad(alacak, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_ALACAK_NEDEN));
                                if (alacak.ALACAK_NEDEN_IDSource.ALACAK_NEDEN_KOD_IDSource == null)
                                    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(alacak.ALACAK_NEDEN_IDSource, false,
                                         DeepLoadType.IncludeChildren, typeof(TI_KOD_ALACAK_NEDEN));
                                if (!alacakListesi.Contains(alacak.ALACAK_NEDEN_IDSource.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI))
                                    alacakListesi.Add(alacak.ALACAK_NEDEN_IDSource.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI);
                            }

                            foreach (var item in alacakListesi)
                            {
                                this.KrediTuru += item + ", ";
                            }

                            return;
                        }

                        #endregion <MB-20100617>
                    }

                    if (masraf.ICRA_FOY_IDSource.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(masraf.ICRA_FOY_IDSource, false,
                             DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                    foreach (var alacak in masraf.ICRA_FOY_IDSource.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        if (alacak.ALACAK_NEDEN_KOD_IDSource == null)
                            DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(alacak, false,
                                 DeepLoadType.IncludeChildren, typeof(TI_KOD_ALACAK_NEDEN));
                        if (!alacakListesi.Contains(alacak.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI))
                            alacakListesi.Add(alacak.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI);
                    }

                    foreach (var item in alacakListesi)
                    {
                        this.KrediTuru += item + ", ";
                    }
                }

                #endregion <İCRA>

                #region <DAVA> <MB-20100616>

                //Masraf Makbuzunun dava için de çalışabilmesi için eklendi.

                if (masraf.DAVA_FOY_IDSource == null)
                {
                    DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(masraf, false, DeepLoadType.IncludeChildren,
                        typeof(AV001_TD_BIL_FOY));
                }

                if (masraf.DAVA_FOY_IDSource != null)
                {
                    if (masraf.DAVA_FOY_IDSource.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                        DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(masraf.DAVA_FOY_IDSource,
                            false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>));

                    this.ReferansNo = masraf.REFERANS_NO;
                    this.EsasNo = masraf.DAVA_FOY_IDSource.ESAS_NO;
                    this.DosyaNo = masraf.DAVA_FOY_IDSource.FOY_NO;
                    this.MasrafAciklamasi = masraf.ACIKLAMA;
                    this.MasrafiYapanCariId = masraf.CARI_ID;
                    this.KarsiTarafCariId = masraf.BORCLU_CARI_ID;
                    this.IcraDairesiMahkemeAdi = string.Format("{0} {1} {2}",
                        EditorDataAraclari.Icra.GetAdliyeAdi(masraf.DAVA_FOY_IDSource.ADLI_BIRIM_ADLIYE_ID),
                        EditorDataAraclari.Icra.GetAdliBirimNo(masraf.DAVA_FOY_IDSource.ADLI_BIRIM_NO_ID),
                        EditorDataAraclari.Icra.GetAdliBirimGorev(masraf.DAVA_FOY_IDSource.ADLI_BIRIM_GOREV_ID));

                    foreach (var item in masraf.DAVA_FOY_IDSource.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection)
                    {
                        if (item.YETKILI_MI && !this.OnaylayanCariId.HasValue)
                            this.OnaylayanCariId = item.SORUMLU_AVUKAT_CARI_ID;
                        else if (!item.YETKILI_MI && !this.SorumluAvukatCariId.HasValue)
                            this.SorumluAvukatCariId = item.SORUMLU_AVUKAT_CARI_ID;
                    }
                    if (this.SorumluAvukatCariId == null)
                        this.SorumluAvukatCariId = this.OnaylayanCariId;

                    if (masraf.DAVA_FOY_IDSource.AV001_TD_BIL_DAVA_NEDENCollection.Count == 0)
                        DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(masraf.DAVA_FOY_IDSource, false,
                             DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_DAVA_NEDEN>));
                    List<string> alacakListesi = new List<string>();
                    foreach (var alacak in masraf.DAVA_FOY_IDSource.AV001_TD_BIL_DAVA_NEDENCollection)
                    {
                        if (alacak.DAVA_NEDEN_KOD_IDSource == null)
                            DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.DeepLoad(alacak, false,
                                 DeepLoadType.IncludeChildren, typeof(TDI_KOD_DAVA_ADI));
                        if (!alacakListesi.Contains(alacak.DAVA_NEDEN_KOD_IDSource.DAVA_ADI))
                            alacakListesi.Add(alacak.DAVA_NEDEN_KOD_IDSource.DAVA_ADI);
                    }

                    foreach (var item in alacakListesi)
                    {
                        this.KrediTuru += item + ", ";
                    }
                    if (masraf.DAVA_FOY_IDSource.AV001_TDIE_BIL_PROJECollection_From_AV001_TDIE_BIL_PROJE_DAVA_FOY.Count == 0)
                        DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(masraf.DAVA_FOY_IDSource, false, DeepLoadType.IncludeChildren,
                            typeof(TList<AV001_TDIE_BIL_PROJE>));

                    if (masraf.DAVA_FOY_IDSource.AV001_TDIE_BIL_PROJECollection_From_AV001_TDIE_BIL_PROJE_DAVA_FOY.Count > 0)
                    {
                        var proje = masraf.DAVA_FOY_IDSource.AV001_TDIE_BIL_PROJECollection_From_AV001_TDIE_BIL_PROJE_DAVA_FOY.First();

                        this.KrediBorclusu = proje.ADI;
                        this.SubeId = proje.OZEL_KOD1_ID;
                    }
                }

                #endregion <DAVA> <MB-20100616>
            }

            public string DosyaNo { get; set; }

            public string EsasNo { get; set; }

            public string IcraDairesiMahkemeAdi { get; set; }

            public List<MakbuzKalemi> Kalemler { get; set; }

            public string KarsiTaraf { get { return HesapAraclari.Icra.CariAdiGetirByCariId(this.KarsiTarafCariId); } }

            public int? KarsiTarafCariId { get; set; }

            public string KrediBorclusu { get; set; }

            public string KrediTuru { get; set; }

            public string MasrafAciklamasi { get; set; }

            public string MasrafiYapan { get { return HesapAraclari.Icra.CariAdiGetirByCariId(this.MasrafiYapanCariId); } }

            public int? MasrafiYapanCariId { get; set; }

            public string Onaylayan { get { return HesapAraclari.Icra.CariAdiGetirByCariId(this.OnaylayanCariId); } }

            public int? OnaylayanCariId { get; set; }

            public string ReferansNo { get; set; }

            public string SorumluAvukat { get { return HesapAraclari.Icra.CariAdiGetirByCariId(this.SorumluAvukatCariId); } }

            public int? SorumluAvukatCariId { get; set; }

            public int? SubeId { get; set; }

            public string Subesi
            {
                get
                {
                    if (this.SubeId.HasValue)
                    {
                        return DataRepository.TDIE_KOD_PROJE_OZEL_KODProvider.GetByID(this.SubeId.Value).OZEL_KOD;
                    }
                    return string.Empty;
                }
            }

            public DateTime Tarih { get; set; }
        }

        private class MakbuzKalemi
        {
            public int HAREKET_ALT_KATEGORI_ID { get; set; }

            public DateTime? Tarih { get; set; }

            public ParaVeDovizId Tutar { get; set; }
        }
    }
}