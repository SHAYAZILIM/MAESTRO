using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Editor.Degiskenler.Klasor;
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
    public static class OdemeMakbuzu
    {
        public static void OdemeMakbuzuGetir(AV001_TI_BIL_BORCLU_ODEME odeme)
        {
            //Sablon ID = 1198
            if (odeme.ICRA_FOY_IDSource == null)
                DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepLoad(odeme, false, DeepLoadType.IncludeChildren,
                                                                          typeof(AV001_TI_BIL_FOY),
                                                                          typeof(TDI_KOD_ODEME_TIP));
            if (odeme.ICRA_FOY_IDSource != null)
            {
                var hesap = new Hesap.Icra(odeme.ICRA_FOY_IDSource);
            }
            frmEditor editor = new frmEditor();
            editor.MdiParent = mdiAvukatPro.MainForm;
            editor.Show();
            Print(editor.CurrentEditor.textControl1, DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.GetByID(1198),
                  odeme);
            editor.beklemePaneli.Visible = false;
        }

        private static void Print(TextControl txControl, AV001_TDIE_BIL_SABLON_RAPOR rapor,
                                  AV001_TI_BIL_BORCLU_ODEME odeme)
        {
            EditorAraclari arac = new EditorAraclari();
            EditorDokuman dokuman = new EditorDokuman(odeme);

            dokuman.Dokuman = rapor.DOSYA;

            var fieldlar = arac.GetFieldListByEditorDokumanAndTextControl(dokuman, txControl);

            foreach (var item in fieldlar)
            {
                switch (item.Text)
                {
                    case "[ODEME] ODEYEN ADI":
                        item.Text = HesapAraclari.Icra.CariAdiGetirByCariId(odeme.ODEYEN_CARI_ID);
                        break;

                    case "[ODEME] ODENEN ADI":
                        item.Text = HesapAraclari.Icra.CariAdiGetirByCariId(odeme.ODENEN_CARI_ID);
                        break;

                    case "[ODEME] ODEME MIKTARI":
                        item.Text =
                            (new ParaVeDovizId(odeme.ODEME_MIKTAR, odeme.ODEME_MIKTAR_DOVIZ_ID)).GetStringValue();
                        break;

                    case "[ODEME] ODEME TARIHI":
                        item.Text = EditorDataAraclari.Tools.TarihBicimlendirme(odeme.ODEME_TARIHI);
                        break;
                    case "[ODEME] ODEME DAGILIM":
                        GetBorcluOdemeDagilim(odeme, txControl, item);
                        break;
                    case "[ODEME] ODEME ICRA DAGILIM":
                        GetDosyaOdemeDagilim(odeme.ICRA_FOY_IDSource, txControl, item);
                        break;
                    case "[İCRA] BORÇLU ÖDEMELERİ":
                        AvukatProDegiskenler.Icra.Degiskenler.GetBorcluOdemeBilgileri(odeme.ICRA_FOY_IDSource, txControl, item);
                        break;
                    case "[ODEME] ESAS NO":
                        if (odeme.ICRA_FOY_IDSource != null)
                            item.Text = odeme.ICRA_FOY_IDSource.ESAS_NO;
                        break;

                    case "[ODEME] BURO DOSYA NO":
                        if (odeme.ICRA_FOY_IDSource != null)
                            item.Text = odeme.ICRA_FOY_IDSource.FOY_NO;
                        break;
                    case "[ODEME] ODEME TUTAR YAZI":
                        var tamsayi = "";
                        var ucretdeger = odeme.ODEME_MIKTAR.HasValue ? odeme.ODEME_MIKTAR.Value : 0;
                        try
                        {
                            tamsayi = NumTotext(decimal.Parse(ucretdeger.ToString("N").Split(',')[0]));
                        }
                        catch { }
                        var ondalik = "";
                        try
                        {
                            ondalik = NumTotext(decimal.Parse(ucretdeger.ToString("N").Split(',')[1]));
                        }
                        catch { }
                        string yazi = (string.IsNullOrEmpty(tamsayi) ? "" : tamsayi + " " + EditorDataAraclari.Tools.GetDovizTipi(odeme.ODEME_MIKTAR_DOVIZ_ID) + " ") + (EditorDataAraclari.Tools.GetDovizTipi(odeme.ODEME_MIKTAR_DOVIZ_ID) == "TL" ? (string.IsNullOrEmpty(ondalik) ? "" : ondalik + " Kr ") : "");
                        item.Text = yazi;
                        break;
                    case "[ODEME] ODEME TIP":
                        if (odeme.ODEME_TIP_IDSource != null)
                            item.Text = odeme.ODEME_TIP_IDSource.ODEME_TIP;
                        break;

                    case "[ODEME] ICRA MUDURLUGU":
                        if (odeme.ICRA_FOY_IDSource != null)
                        {
                            string result = string.Format("{0} {1} {2}",
                                                          EditorDataAraclari.Icra.GetAdliyeAdi(
                                                              odeme.ICRA_FOY_IDSource.ADLI_BIRIM_ADLIYE_ID),
                                                          EditorDataAraclari.Icra.GetAdliBirimNo(
                                                              odeme.ICRA_FOY_IDSource.ADLI_BIRIM_NO_ID),
                                                          EditorDataAraclari.Icra.GetAdliBirimGorev(
                                                              odeme.ICRA_FOY_IDSource.ADLI_BIRIM_GOREV_ID));

                            item.Text = result;
                        }
                        break;

                    case "[ODEME] SORUMLU AVUKAT":
                        if (odeme.ICRA_FOY_IDSource != null)
                        {
                            if (odeme.ICRA_FOY_IDSource.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(odeme.ICRA_FOY_IDSource, false,
                                                                                 DeepLoadType.IncludeChildren,
                                                                                 typeof(
                                                                                     TList
                                                                                     <AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                            var sorumlu =
                                odeme.ICRA_FOY_IDSource.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Where(
                                    vi => !vi.YETKILI_MI).FirstOrDefault();
                            if (sorumlu != null)
                                item.Text = HesapAraclari.Icra.CariAdiGetirByCariId(sorumlu.SORUMLU_AVUKAT_CARI_ID);
                        }
                        break;

                    default:
                        break;
                }
            }

            txControl.Select(txControl.Text.Length, 0);
        }

        public static void GetBorcluOdemeDagilim(AV001_TI_BIL_BORCLU_ODEME odeme, TextControl txControl, TextField field)
        {
            if (odeme.AV001_TI_BIL_ODEME_DAGILIMCollection.Count == 0)
                DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepLoad(odeme, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));

            var borcluOdemeBilgileri = odeme.AV001_TI_BIL_ODEME_DAGILIMCollection;

            DataRepository.AV001_TI_BIL_ODEME_DAGILIMProvider.DeepLoad(borcluOdemeBilgileri, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_MAHSUP_ALT_KATEGORI), typeof(TDI_KOD_MAHSUP_KATEGORI));
            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                 "Ödeme Tarihi"
                ,"Ödeme Miktarı"
                ,"Mahsup Kat."
                ,"Mahsup Alt Kat."
            });

            //int sira = 1;
            foreach (var bilgi in borcluOdemeBilgileri)
            {
                try
                {
                    listeler.Add(new string[]
                    {
                         bilgi.ODEME_TARIHI.Day.ToString()+"/"+bilgi.ODEME_TARIHI.Month.ToString()+"/"+bilgi.ODEME_TARIHI.Year.ToString()
                        ,bilgi.TUTAR.ToString("#,##0.00") + " " + EditorDataAraclari.Tools.GetDovizTipi(bilgi.TUTAR_DOVIZ_ID)
                        ,bilgi.MAHSUP_KATEGORI_IDSource !=null ? bilgi.MAHSUP_KATEGORI_IDSource.MAHSUP_KATEGORI:""
                        ,bilgi.MAHSUP_ALT_KATEGORI_IDSource !=null ? bilgi.MAHSUP_ALT_KATEGORI_IDSource.MAHSUP_ALT_KATEGORI:""
                    });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetBorcluOdemeBilgileri", ex);
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        public static void GetDosyaOdemeDagilim(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TI_BIL_BORCLU_ODEMECollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_ODEME>), typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));

            var borcluOdemeBilgileri = foy.AV001_TI_BIL_ODEME_DAGILIMCollection;

            DataRepository.AV001_TI_BIL_ODEME_DAGILIMProvider.DeepLoad(borcluOdemeBilgileri, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_MAHSUP_ALT_KATEGORI), typeof(TDI_KOD_MAHSUP_KATEGORI));
            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                 "Ödeme Tarihi"
                ,"Ödeme Miktarı"
                ,"Mahsup Kat."
                ,"Mahsup Alt Kat."
            });

            //int sira = 1;
            foreach (var bilgi in borcluOdemeBilgileri)
            {
                try
                {
                    listeler.Add(new string[]
                    {
                         bilgi.ODEME_TARIHI.Day.ToString()+"/"+bilgi.ODEME_TARIHI.Month.ToString()+"/"+bilgi.ODEME_TARIHI.Year.ToString()
                        ,bilgi.TUTAR.ToString("#,##0.00") + " " + EditorDataAraclari.Tools.GetDovizTipi(bilgi.TUTAR_DOVIZ_ID)
                        ,bilgi.MAHSUP_KATEGORI_IDSource !=null ? bilgi.MAHSUP_KATEGORI_IDSource.MAHSUP_KATEGORI:""
                        ,bilgi.MAHSUP_ALT_KATEGORI_IDSource !=null ? bilgi.MAHSUP_ALT_KATEGORI_IDSource.MAHSUP_ALT_KATEGORI:""
                    });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetBorcluOdemeBilgileri", ex);
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        public static string NumTotext(decimal number)
        {
            string returnValue = "";

            string[] numbers = new string[] { "", "Bir", "İki", "Üç", "Dört", "Beş", "Altı", "Yedi", "Sekiz", "Dokuz" };
            string[] onluk = new string[] { "", "On", "Yirmi", "Otuz", "Kırk", "Elli", "Altmış", "Yetmiş", "Seksen", "Doksan" };

            var tampara = number.ToString().Split(',')[0].Replace(".", "").Replace(",", "").ToArray();
            int len = tampara.Length - 1;
            for (int i = len; i >= 0; i--)
            {
                string vlu = "";
                int mod = i % 3;
                if (mod == 0 || mod == 2)
                    vlu = string.Format("{0}", numbers[int.Parse(tampara[len - i].ToString())]);
                if (mod == 1)
                    vlu = string.Format("{0}", onluk[int.Parse(tampara[len - i].ToString())]);

                returnValue += vlu;
                int selectstart = len - i - 2;
                selectstart = selectstart < 0 ? 0 : selectstart;
                if (mod == 2 && number.ToString().Substring(selectstart, 3) != "000" && vlu != "")
                    returnValue += "Yüz";

                if (i % 9 == 0 && i > 0 && number.ToString().Substring(selectstart, 3) != "000")
                    returnValue += "Milyar";
                else if (i % 6 == 0 && i > 0 && number.ToString().Substring(selectstart, 3) != "000")
                    returnValue += "Milyon";
                else if (i % 3 == 0 && i > 0 && number.ToString().Substring(selectstart, 3) != "000")
                    returnValue += "Bin";
            }
            returnValue = returnValue.Replace("BirYüz", "Yüz").Replace("BirBin", "Bin");
            return returnValue;
        }

    }
}