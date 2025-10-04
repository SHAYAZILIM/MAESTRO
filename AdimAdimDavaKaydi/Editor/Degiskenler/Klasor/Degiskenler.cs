using AdimAdimDavaKaydi.Editor.Degiskenler.Util;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using TXTextControl;
using AVPWord = Microsoft.Office.Interop.Word;

namespace AdimAdimDavaKaydi.Editor.Degiskenler.Klasor
{
    public static class Degiskenler
    {
        //[PROJE] ALACAK NEDEN BILGILERI
        public static void GetAlacakNedenleri(AV001_TDIE_BIL_PROJE proje, TextControl txControl, TextField field)
        {
            //	TAKIP_DURUMU		        Takip Durumu
            //	ALACAK_NEDENI		        Alacak Nedeni
            //	DUZENLENME_TARIHI	        Düzenleme Tarihi
            //	VADE_TARIHI		            Vade Tarihi
            //	TUTARI		                Tutarı
            //	ISLEME_KONAN_TUTAR	        İşleme Konan Tutar
            //	FAIZ_TIP		            Faiz Tipi
            //	TO_UYGULANACAK_FAIZ_ORANI	Faiz Oranı
            //	FOY_NO	                	Dosya No
            //	ADLIYE	                	Müdürlük
            //	NO		                    No
            //	ESAS_NO	                	Esas No
            //	TAKIP_TARIHI		        Takip Tarihi

            //VList<V_PROJE_ALACAK_NEDEN_BILGILERI_TAKIPLI_TAKIPSIZ> alacakNedenleri = EditorDataAraclari.Klasor.GetProjeTumAlacakNedenleriByProjeId(proje.ID);

            if (proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN.Count == 0)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));

            var alacakNedenleri = proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN;

            DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(alacakNedenleri, false,
                                                                      DeepLoadType.IncludeChildren,
                                                                      typeof(TDI_KOD_FAIZ_TIP),
                                                                      typeof(TI_KOD_ALACAK_NEDEN));
            List<string[]> listeler = new List<string[]>();

            listeler.Add(new[]
                             {
                                 "Sıra"

                                 //, "Takip Durumu"
                                 , "Alacak Nedeni"

                                 //, "Düzenleme Tarihi"
                                 , "Vade Tarihi"
                                 , "Tutarı"

                                 //, "İşleme Konan Tutar"
                                 , "Faiz Tipi"
                                 , "Faiz Oranı"

                                 //, "Dosya Bilgileri"
                                 //, "Müdürlük"
                                 //, "No"
                                 //, "Esas No"
                                 //, "Takip Tarihi"
                             });

            int sira = 1;
            foreach (var neden in alacakNedenleri)
            {
                try
                {
                    listeler.Add(new[]
                                     {
                                         sira++.ToString()

                                         //, ""
                                         //(neden.TAKIP_DURUMU.HasValue&&neden.TAKIP_DURUMU.Value)?"Takipli":"Takipsiz"
                                         , neden.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI,

                                         //, EditorDataAraclari.Tools.TarihBicimlendirme(neden.DUZENLENME_TARIHI),
                                          EditorDataAraclari.Tools.TarihBicimlendirme(neden.VADE_TARIHI)
                                         , new ParaVeDovizId(neden.TUTARI, neden.TUTAR_DOVIZ_ID).GetStringValue()
                                         ,

                                         //new ParaVeDovizId(neden.ISLEME_KONAN_TUTAR, neden.ISLEME_KONAN_TUTAR_DOVIZ_ID).
                                         //    GetStringValue(),

                                         neden.TO_ALACAK_FAIZ_TIP_IDSource == null
                                             ? ""
                                             : neden.TO_ALACAK_FAIZ_TIP_IDSource.FAIZ_TIP
                                         , string.Format("%{0}", neden.TO_UYGULANACAK_FAIZ_ORANI)

                                         //, "" //neden.FOY_NO
                                         //, "" //neden.ADLIYE
                                         //, "" //neden.NO
                                         //, "" //neden.ESAS_NO
                                         //, "" //EditorDataAraclari.Tools.TarihBicimlendirme(neden.TAKIP_TARIHI)
                                     });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetAlacakNedenleri", ex);
                }
            }
            /*
            WordApp wa = new WordApp(listeler);

            Klasor.Tool.WordImport(txControl, field, wa.FilePath);
            */
            AdimAdimDavaKaydi.Editor.Util.TxTextControlHelper.AddTable(txControl, field, txControl.Tables.Count + 1,
                                                                       listeler);
        }

        //[PROJE] ALACAK NEDEN BILGILERI KISITLI
        public static void GetAlacakNedenleriKisitli(AV001_TDIE_BIL_PROJE proje, TextControl txControl, TextField field)
        {
            //	TAKIP_DURUMU		        Takip Durumu
            //	ALACAK_NEDENI		        Alacak Nedeni
            //	DUZENLENME_TARIHI	        Düzenleme Tarihi
            //	VADE_TARIHI		            Vade Tarihi
            //	TUTARI		                Tutarı
            //	ISLEME_KONAN_TUTAR	        İşleme Konan Tutar
            //	FAIZ_TIP		            Faiz Tipi
            //	TO_UYGULANACAK_FAIZ_ORANI	Faiz Oranı
            //	FOY_NO	                	Dosya No
            //	ADLIYE	                	Müdürlük
            //	NO		                    No
            //	ESAS_NO	                	Esas No
            //	TAKIP_TARIHI		        Takip Tarihi

            TList<AV001_TDIE_BIL_PROJE_ALACAK_NEDEN> alacakNedenleri =
                DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDENProvider.GetByPROJE_ID(proje.ID);

            List<List<string>> listeler = new List<List<string>>();

            listeler.Add(new List<string>
                             {
                                 "Sıra"

                                 //,"Takip Durumu"
                                 ,
                                 "Alacak Nedeni"

                                 // ,"Düzenleme Tarihi"
                                 ,
                                 "Vade Tarihi"
                                 ,
                                 "Tutarı"

                                 //,"İşleme Konan Tutar"
                                 //,"Faiz Tipi"
                                 //,"Faiz Oranı"
                                 //,"Dosya No"
                                 //,"Müdürlük"
                                 //,"No"
                                 //,"Esas No"
                                 //,"Takip Tarihi"
                             });

            int sira = 1;
            DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDENProvider.DeepLoad(alacakNedenleri, false,
                                                                              DeepLoadType.IncludeChildren,
                                                                              typeof(AV001_TI_BIL_ALACAK_NEDEN));

            foreach (var neden in alacakNedenleri)
            {
                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(neden.ALACAK_NEDEN_IDSource, false,
                                                                          DeepLoadType.IncludeChildren,
                                                                          typeof(TI_KOD_ALACAK_NEDEN));
                listeler.Add(new List<string>
                                 {
                                     sira++.ToString()

                                     //,(neden.TAKIP_DURUMU.HasValue&&neden.TAKIP_DURUMU.Value)?"Takipli":"Takipsiz"
                                     ,
                                     neden.ALACAK_NEDEN_IDSource.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI

                                     //,EditorDataAraclari.Tools.TarihBicimlendirme(neden.DUZENLENME_TARIHI)
                                     ,
                                     EditorDataAraclari.Tools.TarihBicimlendirme(neden.ALACAK_NEDEN_IDSource.VADE_TARIHI)
                                     ,
                                     new ParaVeDovizId(neden.ALACAK_NEDEN_IDSource.TUTARI,
                                                       neden.ALACAK_NEDEN_IDSource.TUTAR_DOVIZ_ID).GetStringValue()

                                     //,new ParaVeDovizId(neden.ISLEME_KONAN_TUTAR,neden.ISLEME_KONAN_TUTAR_DOVIZ_ID).GetStringValue()
                                     //,neden.FAIZ_TIP
                                     //,string.Format("%{0}",neden.TO_UYGULANACAK_FAIZ_ORANI)
                                     //,neden.FOY_NO
                                     //,neden.ADLIYE
                                     //,neden.NO
                                     //,neden.ESAS_NO
                                     //,EditorDataAraclari.Tools.TarihBicimlendirme(neden.TAKIP_TARIHI)
                                 });
            }

            field.Text = " ";
            txControl.Select(field.Start, 0);

            txControl.Tables.Add(listeler.Count, listeler[0].Count, 637);

            var table = txControl.Tables.GetItem(637);

            var cellss = table.Cells.GetEnumerator();

            while (cellss.MoveNext())
            {
                var cell = cellss.Current as TableCell;

                cell.Text = listeler[cell.Row - 1][cell.Column - 1];
                cell.Select();

                if (cell.Row == 1)
                {
                    txControl.Selection.ParagraphFormat.Alignment = HorizontalAlignment.Center;
                    txControl.Selection.Bold = true;
                }
                else
                {
                    switch (cell.Column)
                    {
                        case 1:
                            txControl.Selection.ParagraphFormat.Alignment = HorizontalAlignment.Center;
                            break;

                        case 4:
                        case 5:
                            txControl.Selection.ParagraphFormat.Alignment = HorizontalAlignment.Right;
                            break;

                        default:
                            txControl.Selection.ParagraphFormat.Alignment = HorizontalAlignment.Left;
                            break;
                    }

                    txControl.Selection.Bold = false;
                }
            }
        }

        //[PROJE] ALACAK KALEMLERI TOPLAM TUTAR
        public static void GetAlacakToplamlari(AV001_TDIE_BIL_PROJE proje, TextControl txControl, TextField field)
        {
            var alacaklaR = DataRepository.V_PROJE_ALACAK_NEDEN_BILGILERI_TAKIPLI_TAKIPSIZProvider.GetByProjeId(proje.ID);
            if (alacaklaR.Count() > 0)
            {
                var paralar = alacaklaR.Select(vi => new ParaVeDovizId(vi.TUTARI, vi.TUTAR_DOVIZ_ID)).ToList();

                if (paralar.Count > 0)
                {
                    var toplam = ParaVeDovizId.Topla(paralar);

                    field.Text = toplam.GetStringValue();
                }
            }
        }

        //[PROJE] BORCLU BILGILERI
        public static void GetBorcluBilgileri(AV001_TDIE_BIL_PROJE proje, TextControl txControl, TextField field)
        {
            List<string[]> liste = new List<string[]>();

            #region Değerler

            var basliklar = new[]
                                {
                                    //"Sıra",
                                    //"Takip Durumu",
                                    "Sıfat",
                                    "Ad",

                                    //"Kod",
                                    "Muşteri No",
                                    "TC No",
                                    "Sorumlu Olunan Miktar"
                                };

            liste.Add(basliklar);

            var sonuclar = EditorDataAraclari.Klasor.GetKlasorTarafSorumlulukByProjeId(proje.ID).OrderBy(vi => vi.SIFAT);

            var taraflar = sonuclar.GroupBy(vi => vi.TARAF_CARI_ID);

            //int sira = 1;
            foreach (var trf in taraflar)
            {
                var toplam =
                    ParaVeDovizId.Topla(
                        trf.Select(vi => new ParaVeDovizId(vi.SORUMLU_OLUNAN_MIKTAR, vi.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID))
                            .ToList());

                var item = trf.First();
                var degerler = new[]
                                   {
                                       //(sira++).ToString(),
                                       // item.TAKIP_DURUMU.HasValue&&item.TAKIP_DURUMU.Value?"Takipli":"Takipsiz",
                                        item.SIFAT,
                                       item.AD,

                                       //item.KOD,
                                       item.MUSTERI_NO,
                                       item.TC_KIMLIK_NO,
                                       toplam.GetStringValue()
                                   };

                liste.Add(degerler);
            }

            #endregion Değerler

            /*
            WordApp wa = new WordApp(liste);

            Klasor.Tool.WordImport(txControl, field, wa.FilePath);
            */
            AdimAdimDavaKaydi.Editor.Util.TxTextControlHelper.AddTable(txControl, field, txControl.Tables.Count + 1,
                                                                       liste);
        }

        //[PROJE] DAVA BILGILERI
        public static string GetDavaBilgileri(AV001_TDIE_BIL_PROJE proje, TextControl txControl, TextField field)
        {
            #region Değerler Oluşturuluyor

            string[] basliklar = new[]
                                     {
                                         "Sıra No",
                                         "Mahkeme",
                                         "davacı",
                                         "Karşı Taraf",
                                         "Tarihi",
                                         "Konusu",
                                         "Durumu",
                                         "Karar",
                                         "Kanun Yolu",
                                         "Kanun Yolu Sonucu / Kesinleşme",
                                         "Sorumlu Avukat"
                                     };

            //var davalar = EditorDataAraclari.Klasor.GetDavaBilgileriByProjeId(proje.ID);

            if (proje.AV001_TD_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_DAVA_FOY.Count == 0)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TD_BIL_FOY>));

            var davalar = proje.AV001_TD_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_DAVA_FOY;

            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(davalar, false, DeepLoadType.IncludeChildren,
                                                             typeof(TDI_KOD_FOY_DURUM), typeof(TD_KOD_DAVA_TALEP), typeof(TList<AV001_TD_BIL_FOY_TARAF>), typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>));

            List<string[]> degerler = new List<string[]>();
            degerler.Add(basliklar);
            int sira = 1;

            if (BelgeUtil.Inits._per_CariGetir == null)
                BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();

            if (BelgeUtil.Inits._TD_FoyTarafGetir == null)
                BelgeUtil.Inits._TD_FoyTarafGetir = BelgeUtil.Inits.context.per_AV001_TD_BIL_FOY_TARAFs.ToList();

            foreach (var item in davalar)
            {
                var tarafList = item.AV001_TD_BIL_FOY_TARAFCollection;
                string davacilar = string.Empty;
                string davalilar = string.Empty;

                foreach (var taraf in tarafList)
                {
                    if (taraf.DAVA_EDEN_MI)
                        davacilar += BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == taraf.CARI_ID.Value).AD + Environment.NewLine + Environment.NewLine;
                    else
                        davalilar += BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == taraf.CARI_ID.Value).AD + Environment.NewLine + Environment.NewLine;
                }

                var sorumluList = item.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.FindAll(vi => !vi.YETKILI_MI);
                string avukatlar = string.Empty;
                foreach (var sorumlu in sorumluList)
                {
                    avukatlar += BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == sorumlu.SORUMLU_AVUKAT_CARI_ID.Value).AD + Environment.NewLine;
                }

                string kararAciklama = " ";
                string kanunYoluAciklama = " ";
                string kanunYoluSonucuAciklama = " ";

                var davaHukumList = DataRepository.AV001_TD_BIL_MAHKEME_HUKUMProvider.GetByDAVA_FOY_ID(item.ID);
                if (davaHukumList.Count == 0)
                {
                    kararAciklama = item.FOY_DURUM_IDSource != null ? item.FOY_DURUM_IDSource.DURUM : "";
                }
                else
                {
                    var hukum = davaHukumList.OrderByDescending(vi => vi.HUKUM_TARIHI).FirstOrDefault();

                    if (hukum != null)
                    {
                        var davaTemyizList = DataRepository.AV001_TD_BIL_TEMYIZProvider.GetByDAVA_FOY_ID(item.ID);

                        if (BelgeUtil.Inits._HukumGetir == null)
                            BelgeUtil.Inits._HukumGetir = DataRepository.per_TD_KOD_MAHKEME_HUKUMProvider.GetAll();

                        kararAciklama = BelgeUtil.Inits._HukumGetir.Find(vi => vi.ID == hukum.HUKUM_ID).HUKUM;

                        if (davaTemyizList.Count != 0)
                        {
                            DataRepository.AV001_TD_BIL_TEMYIZProvider.DeepLoad(davaTemyizList, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_TEMYIZ_TARAF>));
                            TList<AV001_TD_BIL_TEMYIZ_TARAF> list = new TList<AV001_TD_BIL_TEMYIZ_TARAF>();

                            davaTemyizList.ForEach(tem => list.AddRange(tem.AV001_TD_BIL_TEMYIZ_TARAFCollection));

                            if (BelgeUtil.Inits._TemyizTipGetir == null)
                            {
                                BelgeUtil.Inits._TemyizTipGetir = DataRepository.per_TD_KOD_TEMYIZ_TIPProvider.GetAll();
                            }

                            var temyizItem = list.FindAll(vi => vi.TEMYIZ_TARIHI.HasValue).OrderByDescending(vi => vi.TEMYIZ_TARIHI.Value);

                            if (temyizItem.FirstOrDefault() != null)
                            {
                                kanunYoluAciklama = BelgeUtil.Inits._TemyizTipGetir.Find(vi => vi.ID == davaTemyizList.Find(t => t.ID == temyizItem.FirstOrDefault().TEMYIZ_ID.Value).TEMYIZ_TIP_ID).TEMYIZ_TIP;

                                if (davaTemyizList.Find(t => t.ID == temyizItem.FirstOrDefault().TEMYIZ_ID.Value).KARAR_TIP_ID.HasValue)
                                {
                                    var selectedTemyiz = davaTemyizList.Find(t => t.ID == temyizItem.FirstOrDefault().TEMYIZ_ID.Value);
                                    if (BelgeUtil.Inits._KararTipGetir == null)
                                    {
                                        BelgeUtil.Inits._KararTipGetir = DataRepository.per_TD_KOD_YUKSEK_MAHKEME_KARAR_TIPProvider.GetAll();
                                    }
                                    if (selectedTemyiz != null && selectedTemyiz.KARAR_TIP_ID.HasValue)
                                        kanunYoluSonucuAciklama = BelgeUtil.Inits._KararTipGetir.Find(vi => vi.ID == selectedTemyiz.KARAR_TIP_ID).KARAR_TIP;
                                }
                            }
                        }
                    }

                    var kesinlesme = davaHukumList.FindAll(vi => vi.KESINLESME_TARIHI.HasValue).FirstOrDefault();
                    if (kesinlesme != null)
                        kanunYoluSonucuAciklama += " - " + kesinlesme.KESINLESME_TARIHI.Value.ToShortDateString();
                }

                var mahkeme = EditorDataAraclari.Icra.GetAdliyeAdi(item.ADLI_BIRIM_ADLIYE_ID) + " " + EditorDataAraclari.Icra.GetAdliBirimNo(item.ADLI_BIRIM_NO_ID) + " " + EditorDataAraclari.Icra.GetAdliBirimGorev(item.ADLI_BIRIM_GOREV_ID) + " " + item.ESAS_NO;

                string[] result = new[]
                                      {
                                          (sira++).ToString(),
                                          mahkeme,
                                          davacilar,
                                          davalilar,
                                          EditorDataAraclari.Tools.TarihBicimlendirme(item.DAVA_TARIHI),
                                          item.DAVA_TALEP_IDSource != null ? item.DAVA_TALEP_IDSource.DAVA_TALEP : " ",
                                          item.FOY_DURUM_IDSource != null ? item.FOY_DURUM_IDSource.DURUM : " ",
                                          kararAciklama,
                                          kanunYoluAciklama,
                                          kanunYoluSonucuAciklama,
                                          avukatlar
                                      };

                degerler.Add(result);
            }

            #endregion Değerler Oluşturuluyor

            /*
            WordApp wa = new WordApp(degerler);

            Klasor.Tool.WordImport(txControl, field, wa.FilePath);
            */
            AdimAdimDavaKaydi.Editor.Util.TxTextControlHelper.AddTable(txControl, field, txControl.Tables.Count + 1,
                                                                       degerler);
            return string.Empty;
        }

        //[PROJE] GENEL KLASOR BILGILERI
        public static void GetGenelKlasorBilgileri(AV001_TDIE_BIL_PROJE proje, TextControl txControl, TextField field)
        {
            if (proje == null) return;
            /*
                Klasör  Genel Bilgileri
                Segment           :
                Klasör Borçlusu :
                Klasör No         :
                Şube                  :
                Klasör Tarihi     :
             */

            string result = string.Empty;
            Dictionary<string, string> sozluk = new Dictionary<string, string>();
            if (proje.PROJE_TIP_ID.HasValue)
            {
                sozluk.Add("Segment", EditorDataAraclari.Klasor.GetKlasorTipById(proje.PROJE_TIP_ID.Value));
            }
            sozluk.Add("Klasör Borçlusu", proje.ADI);
            sozluk.Add("Klasör No", proje.KOD);
            if (proje.OZEL_KOD1_ID.HasValue)
            {
                sozluk.Add("Şube", EditorDataAraclari.Klasor.GetKlasorSubesiById(proje.OZEL_KOD1_ID.Value));
            }
            sozluk.Add("İntikal Tarihi", EditorDataAraclari.Tools.TarihBicimlendirme(proje.BASLANGIC_TARIHI));

            field.Text = " ";
            txControl.Select(field.Start, 0);

            if (txControl.Tables.Add(sozluk.Count, 2, 9880))
            {
                var enume = sozluk.GetEnumerator();
                int sira = 1;
                while (enume.MoveNext())
                {
                    //Başlık
                    var baslikCell = txControl.Tables.GetItem(9880).Cells.GetItem(sira, 1);

                    baslikCell.Text = enume.Current.Key;
                    baslikCell.Select();
                    txControl.Selection.Bold = true;

                    //Değer
                    var degerCell = txControl.Tables.GetItem(9880).Cells.GetItem(sira, 2);
                    degerCell.Text = enume.Current.Value;
                    degerCell.Select();
                    if (enume.Current.Key == "Klasör No")
                    {
                        txControl.Selection.ParagraphFormat.Alignment = HorizontalAlignment.Left;
                        txControl.Selection.Bold = true;
                    }
                    else
                    {
                        txControl.Selection.ParagraphFormat.Alignment = HorizontalAlignment.Left;
                        txControl.Selection.Bold = false;
                    }

                    ++sira;
                }
            }
        }

        //[PROJE] HESAP DATAYLARI1
        public static void GetHesapDetaylari1(AV001_TDIE_BIL_PROJE proje, TextControl txControl, TextField field)
        {
            /*
            Asıl Alacak       :
            İşlemiş Faiz       :
            BSMV              :
            KKDF              :
            İH Vek Ücreti   :
            İH Giderleri       :
            Özel Tutarlar    :
            TÖ Ödeme        :
            Mahsup             :
            Takip Çıkışı      :
             */

            // Kredi borçlusunun taraf olduğu dosyalarda vekalet ücretinin klasör hesabına gelmesini sağlamak için eklendi. MB
            // Klasörü hesaplatmadan direkr rapor alınmaya çalışılınca Kredi Boçlusu bilgisinin gelmesi için eklendi. MB
            if (BelgeUtil.Inits.KrediBorclusu == 0)
            {
                AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN[0], false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
                var krediBorclusu = proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Find("TARAF_SIFAT_ID", 2);
                if (krediBorclusu != null)
                    BelgeUtil.Inits.KrediBorclusu = krediBorclusu.TARAF_CARI_ID;
                if (BelgeUtil.Inits.KrediBorclusu == 0)
                {
                    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN[0], false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
                    if (proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI.Count > 0)
                        krediBorclusu = proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Find(vi => vi.TARAF_SIFAT_ID == 2);
                    if (krediBorclusu != null)
                        BelgeUtil.Inits.KrediBorclusu = krediBorclusu.TARAF_CARI_ID;
                }
            }

            string result = string.Empty;
            HesapAraclari.OzetHesap ozetHesap;
            AV001_TI_BIL_FOY foy;

            //if (proje.Tag == null)
            //{
            KlasorHesapAraclari ha = new KlasorHesapAraclari();
            ozetHesap = ha.GetKonsolideAlacaklarHesabi2G(proje);
            proje.Tag = ozetHesap;
            foy = ozetHesap.MyFoy;

            //}
            //else
            //{
            //    ozetHesap = proje.Tag as HesapAraclari.OzetHesap;

            //    foy = ozetHesap.MyFoy;
            //}

            //var ihVekUcreti = ParaVeDovizId.Topla(
            //    new ParaVeDovizId(foy.IH_GIDERI, foy.IH_GIDERI_DOVIZ_ID),
            //    new ParaVeDovizId(foy.IH_VEKALET_UCRETI, foy.IH_VEKALET_UCRETI_DOVIZ_ID));

            var ozelTutarlar = ParaVeDovizId.Topla(
                new ParaVeDovizId(foy.OZEL_TUTAR1, foy.OZEL_TUTAR1_DOVIZ_ID),
                new ParaVeDovizId(foy.OZEL_TUTAR2, foy.OZEL_TUTAR2_DOVIZ_ID),
                new ParaVeDovizId(foy.OZEL_TUTAR3, foy.OZEL_TUTAR3_DOVIZ_ID));

            //new ParaVeDovizId(foy.OZEL_TUTAR4, foy.OZEL_TUTAR4_DOVIZ_ID));

            Dictionary<string, string> sozluk = new Dictionary<string, string>();

            sozluk.Add("Asıl Alacak", new ParaVeDovizId(foy.ASIL_ALACAK, foy.ASIL_ALACAK_DOVIZ_ID).GetStringValue());
            sozluk.Add("İşlemiş Faiz", new ParaVeDovizId(foy.ISLEMIS_FAIZ, foy.ISLEMIS_FAIZ_DOVIZ_ID).GetStringValue());
            sozluk.Add("BSMV", new ParaVeDovizId(foy.BSMV_TO, foy.BSMV_TO_DOVIZ_ID).GetStringValue());
            sozluk.Add("KKDF", new ParaVeDovizId(foy.KKDV_TO, foy.KKDV_TO_DOVIZ_ID).GetStringValue());
            sozluk.Add("Vekalet Ücreti", new ParaVeDovizId(foy.TAKIP_VEKALET_UCRETI, foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID).GetStringValue());//Bahattin Bey'in isteğiyle İH Vek Ücreti yerine Toplam vekalet ücreti değeri ekrana getirildi. MB
            sozluk.Add("Özel Tutarlar", ozelTutarlar.GetStringValue());
            sozluk.Add("TÖ Ödeme",
                       new ParaVeDovizId(foy.TO_ODEME_TOPLAMI, foy.TO_ODEME_TOPLAMI_DOVIZ_ID).GetStringValue());
            sozluk.Add("Mahsup", new ParaVeDovizId(foy.MAHSUP_TOPLAMI, foy.MAHSUP_TOPLAMI_DOVIZ_ID).GetStringValue());
            sozluk.Add("Takip Çıkışı", new ParaVeDovizId(foy.TAKIP_CIKISI, foy.TAKIP_CIKISI_DOVIZ_ID).GetStringValue());

            field.Text = " ";

            txControl.Select(field.Start, 0);

            if (txControl.Tables.Add(sozluk.Count, 2, 5600))
            {
                var enume = sozluk.GetEnumerator();
                int sira = 1;
                while (enume.MoveNext())
                {
                    //Başlık
                    var baslikCell = txControl.Tables.GetItem(5600).Cells.GetItem(sira, 1);

                    baslikCell.Text = enume.Current.Key;
                    baslikCell.Select();
                    txControl.Selection.Bold = true;

                    //Değer
                    var degerCell = txControl.Tables.GetItem(5600).Cells.GetItem(sira, 2);
                    degerCell.Text = enume.Current.Value;
                    degerCell.Select();
                    txControl.Selection.ParagraphFormat.Alignment = HorizontalAlignment.Right;
                    txControl.Selection.Bold = false;

                    ++sira;
                }
            }
        }

        //[PROJE] HESAP DATAYLARI2
        public static void GetHesapDetaylari2(AV001_TDIE_BIL_PROJE proje, TextControl txControl, TextField field)
        {
            /*
                Sonraki Faiz    :
                KKDF            :
                İlk Giderler    :
                Diğer Gider     :
                Takip Vek Üc    :
                Dava Gideri     :
                Dava Vek Üc     :
                Alacak          :
                Feragat Topl    :
                Ödeme Topl      :
                Kalan           :
             */
            field.Text = " ";
            txControl.Select(field.Start, 0);

            HesapAraclari.OzetHesap ozetHesap;
            AV001_TI_BIL_FOY foy;

            if (proje.Tag == null)
            {
                KlasorHesapAraclari ha = new KlasorHesapAraclari();
                ozetHesap = ha.GetKonsolideAlacaklarHesabi2G(proje);
                proje.Tag = ozetHesap;
                foy = ozetHesap.MyFoy;
            }
            else
            {
                ozetHesap = proje.Tag as HesapAraclari.OzetHesap;

                foy = ozetHesap.MyFoy;
            }

            Dictionary<string, string> sozluk = new Dictionary<string, string>();

            sozluk.Add("Sonraki Faiz", new ParaVeDovizId(foy.SONRAKI_FAIZ, foy.SONRAKI_FAIZ_DOVIZ_ID).GetStringValue());
            sozluk.Add("KKDF", new ParaVeDovizId(foy.KKDV_TO, foy.KKDV_TO_DOVIZ_ID).GetStringValue());
            sozluk.Add("İlk Giderler", new ParaVeDovizId(foy.ILK_GIDERLER, foy.ILK_GIDERLER_DOVIZ_ID).GetStringValue());
            sozluk.Add("Diğer Gider",
                       new ParaVeDovizId(foy.DIGER_GIDERLER, foy.DIGER_GIDERLER_DOVIZ_ID).GetStringValue());
            sozluk.Add("Takip Vek Üc",
                       new ParaVeDovizId(foy.TAKIP_VEKALET_UCRETI, foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID).GetStringValue());
            sozluk.Add("Dava Gideri",
                       new ParaVeDovizId(foy.DAVA_GIDERLERI, foy.DAVA_GIDERLERI_DOVIZ_ID).GetStringValue());
            sozluk.Add("Dava Vek Üc",
                       new ParaVeDovizId(foy.DAVA_VEKALET_UCRETI, foy.DAVA_VEKALET_UCRETI_DOVIZ_ID).GetStringValue());
            sozluk.Add("Alacak", new ParaVeDovizId(foy.ALACAK_TOPLAMI, foy.ALACAK_TOPLAMI_DOVIZ_ID).GetStringValue());
            sozluk.Add("Feragat Topl",
                       new ParaVeDovizId(foy.FERAGAT_TOPLAMI, foy.FERAGAT_TOPLAMI_DOVIZ_ID).GetStringValue());
            sozluk.Add("Ödeme Topl", new ParaVeDovizId(foy.ODEME_TOPLAMI, foy.ODEME_TOPLAMI_DOVIZ_ID).GetStringValue());
            sozluk.Add("Kalan", new ParaVeDovizId(foy.KALAN, foy.KALAN_DOVIZ_ID).GetStringValue());

            if (txControl.Tables.Add(sozluk.Count, 2, 5700))
            {
                var enume = sozluk.GetEnumerator();
                int sira = 1;
                while (enume.MoveNext())
                {
                    //Başlık
                    var baslikCell = txControl.Tables.GetItem(5700).Cells.GetItem(sira, 1);

                    baslikCell.Text = enume.Current.Key;
                    baslikCell.Select();
                    txControl.Selection.Bold = true;

                    //Değer
                    var degerCell = txControl.Tables.GetItem(5700).Cells.GetItem(sira, 2);
                    degerCell.Text = enume.Current.Value;
                    degerCell.Select();
                    txControl.Selection.ParagraphFormat.Alignment = HorizontalAlignment.Right;
                    txControl.Selection.Bold = false;

                    ++sira;
                }
            }
        }

        //[PROJE] HESAP DATAYLARI3
        public static void GetHesapDetaylari3(AV001_TDIE_BIL_PROJE proje, TextControl txControl, TextField field)
        {
            HesapAraclari.OzetHesap ozetHesap;
            AV001_TI_BIL_FOY foy;
            string result = string.Empty;
            if (proje.Tag == null)
            {
                KlasorHesapAraclari ha = new KlasorHesapAraclari();
                ozetHesap = ha.GetKonsolideAlacaklarHesabi2G(proje);
                proje.Tag = ozetHesap;
                foy = ozetHesap.MyFoy;
            }
            else
            {
                ozetHesap = proje.Tag as HesapAraclari.OzetHesap;

                foy = ozetHesap.MyFoy;
            }

            string faizTipi = string.Empty;
            string faizOrani = string.Empty;

            var faizTipOranlari = EditorDataAraclari.Klasor.GetFaizTipVeOranlarById(proje.ID);
            if (faizTipOranlari.Count > 1)
            {
                faizTipi = "Degisken";
                faizOrani = "Degisken";
            }
            else if (faizTipOranlari.Count == 1)
            {
                foreach (var item in faizTipOranlari)
                {
                    faizTipi = item.Key;
                    if (item.Value.Count > 1)
                        faizOrani = "Degisken";
                    else if (item.Value.Count == 1 && item.Value[0].HasValue)
                        faizOrani = item.Value[0].Value.ToString();
                }
            }

            field.Text = " ";
            txControl.Select(field.Start, 0);

            Dictionary<string, string> sozluk = new Dictionary<string, string>();

            sozluk.Add("Gayri Nakit Top",
                       new ParaVeDovizId(foy.GAYRI_NAKTI_ALACAK, foy.GAYRI_NAKTI_ALACAK_DOVIZ_ID).GetStringValue());
            sozluk.Add("Gayri Nakİt V Ücr",
                       new ParaVeDovizId(foy.DEPO_VEKALET_UCRETI, foy.DEPO_VEKALET_UCRET_DOVIZ_ID).GetStringValue());
            sozluk.Add("Gayri Nak Harç", new ParaVeDovizId(foy.DEPO_HARCI, foy.DEPO_HARCI_DOVIZ_ID).GetStringValue());
            sozluk.Add("", "");
            sozluk.Add("Faiz Oranı", faizOrani);

            //projeye bağlı alacak nedenlerinin üzerinde birbirinden farklı faiz oranları ve tipleri varsa yazmıyoruz yoksa yazıyoruz
            sozluk.Add("Faiz Tipi", faizTipi);

            //string.Format(@"Hesap Tipi          : {0}","");

            if (txControl.Tables.Add(sozluk.Count, 2, 5800))
            {
                var enume = sozluk.GetEnumerator();
                int sira = 1;
                while (enume.MoveNext())
                {
                    //Başlık
                    var baslikCell = txControl.Tables.GetItem(5800).Cells.GetItem(sira, 1);

                    baslikCell.Text = enume.Current.Key;
                    baslikCell.Select();
                    txControl.Selection.Bold = true;

                    //Değer
                    var degerCell = txControl.Tables.GetItem(5800).Cells.GetItem(sira, 2);
                    degerCell.Text = enume.Current.Value;
                    degerCell.Select();
                    txControl.Selection.ParagraphFormat.Alignment = HorizontalAlignment.Right;
                    txControl.Selection.Bold = false;

                    ++sira;
                }
            }
        }

        public static void GetIadeAlinmamisTeminatlar(AV001_TDIE_BIL_PROJE proje, TextControl txControl, TextField field)
        {
            #region <MB-20101206>

            //Takibi açılmamış, direkt klasöre bağlı teminatların klasör raporunda görünmesini sağlamak amacıyla eklendi.

            txControl.Select(field.Start, 0);
            field.Text = " ";

            List<string[]> liste = new List<string[]>();
            liste.Add(new[] { "Teminatın Bilgisi", "Nereye Verildiği ?", "Sorumlu Avukat", "Teminat Geri Alındığı Tarih", "Müvekkile Teslim Tarihi", "Açıklama" });

            //liste.Add(new[] { "Türü", "Verildiği Tarih", "Nosu", "Miktarı", "Mahkemesi / İcra Dairesi", "Dosya No", "Bankası", "Şubesi", "Sorumlu Avukat", /*"Teminat Mektup Tarihi", */"Geri Alındığı Tarih", "Müvekkile Teslim Tarihi", "Açıklama" });

            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY>), typeof(TList<AV001_TD_BIL_FOY>));

            #region İcra

            foreach (var item in proje.AV001_TI_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY)
            {
                var iadeTeminatList = DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.Find("ICRA_FOY_ID = " + item.ID);

                GetTeminatMektupBilgisi(iadeTeminatList, item.ADLI_BIRIM_ADLIYE_ID, item.ADLI_BIRIM_NO_ID, item.ADLI_BIRIM_GOREV_ID, item.ESAS_NO, liste);
            }

            #endregion İcra

            #region Dava

            foreach (var item in proje.AV001_TD_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_DAVA_FOY)
            {
                var iadeTeminatList = DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.Find("DAVA_FOY_ID = " + item.ID);
                GetTeminatMektupBilgisi(iadeTeminatList, item.ADLI_BIRIM_ADLIYE_ID, item.ADLI_BIRIM_NO_ID, item.ADLI_BIRIM_GOREV_ID, item.ESAS_NO, liste);
            }

            #endregion Dava

            #region Klasör

            //Klasörden girilen teminat mektuplarının gelmesi için eklendi. Sadece takipsiz tablolarda aranacak. Çünkü takibe geçtiği o teminat mektubu icra olduğu için rapora zaten gelecek.

            TList<AV001_TDI_BIL_TEMINAT_MEKTUP> teminatMektupList = new TList<AV001_TDI_BIL_TEMINAT_MEKTUP>();

            var klasorIhtiyatiHacizList = DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ(proje.ID);

            foreach (var item in klasorIhtiyatiHacizList)
            {
                var mektup = DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.Find("IHTIYATI_HACIZ_ID = " + item.ID);
                GetTeminatMektupBilgisi(mektup, item.ADLI_BIRIM_ADLIYE_ID, item.ADLI_BIRIM_NO_ID, item.ADLI_BIRIM_GOREV_ID, item.ESAS_NO, liste);
            }

            var klasorIhtiyatiTedbirList = DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR(proje.ID);

            foreach (var item in klasorIhtiyatiTedbirList)
            {
                var mektup = DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.Find("IHTIYATI_TEDBIR_ID = " + item.ID);
                GetTeminatMektupBilgisi(mektup, item.ADLI_BIRIM_ADLIYE_ID, item.ADLI_BIRIM_NO_ID, item.ADLI_BIRIM_GOREV_ID, item.ESAS_NO, liste);
            }

            #endregion Klasör

            AdimAdimDavaKaydi.Editor.Util.TxTextControlHelper.AddTable(txControl, field, txControl.Tables.Count + 1, liste);

            #endregion <MB-20101206>
        }

        //[PROJE] ICRA BILGILERI
        public static string GetIcraBilgileri(TextControl txControl, TextField field, AV001_TDIE_BIL_PROJE proje)
        {
            field.Text = " ";
            txControl.Select(field.Start, 0);

            #region Değerler

            var dosyalar = EditorDataAraclari.Klasor.GetIcraFoyIdByProjeId(proje.ID);
            string[] basliklar = new[]
                                     {
                                         "Sıra",
                                         "İcra Dairesi",
                                         "Alacaklı",
                                         "Borçlu",
                                         "Tarihi",

                                         //"No",
                                         //"Esas No",
                                         "Durumu",
                                         "ÖrnekNo",
                                         "Takip Çıkışı",
                                         "Anapara + Masraf",
                                         "Ödeme Top.",
                                         "Kalan",
                                         "Sorumlu Avukat"
                                     };

            List<string[]> degerListesi = new List<string[]>();

            degerListesi.Add(basliklar);

            int sira = 1;
            List<int> liste = new List<int>();

            foreach (var dosya in dosyalar)
            {
                if (liste.Contains(dosya.ID)) // View de kayıt tekrarı olduğu için  aynı kaydı tekrar yazdırmıyoruz
                    continue;
                liste.Add(dosya.ID);

                //master += Environment.NewLine;

                string[] degerler = new[]
                                        {
                                            (sira++).ToString(),
                                            dosya.ICRA_ADLIYE+" "+dosya.ICRA_BIRIM_NO+" "+dosya.ESAS_NO,
                                            dosya.TAKIP_EDEN,
                                            dosya.TAKIP_EDILEN,
                                            AdimAdimDavaKaydi.Editor.Degiskenler.Util.EditorDataAraclari.Tools.TarihBicimlendirme(
                                                dosya.TAKIBIN_AVUKATA_INTIKAL_TARIHI),

                                            //dosya.ICRA_ADLIYE,
                                            //dosya.ICRA_BIRIM_NO,
                                            //dosya.ESAS_NO,
                                            dosya.DURUM,
                                            dosya.FORM_TIPI,
                                            new ParaVeDovizId(dosya.TAKIP_CIKISI, dosya.TAKIP_CIKISI_DOVIZ_ID).
                                                GetStringValue(),
                                            new ParaVeDovizId(dosya.RISK_MIKTARI, dosya.RISK_MIKTARI_DOVIZ_ID).
                                                GetStringValue(),
                                            new ParaVeDovizId(dosya.ODEME_TOPLAMI, dosya.ODEME_TOPLAMI_DOVIZ_ID).
                                                GetStringValue(),
                                            new ParaVeDovizId(dosya.KALAN, dosya.KALAN_DOVIZ_ID).GetStringValue(),
                                            dosya.SORUMLU
                                        };

                // dosya.SORUMLU_AVUKAT);
                degerListesi.Add(degerler);
            }

            #endregion Değerler

            /*
            WordApp wa = new WordApp(degerListesi);

            Klasor.Tool.WordImport(txControl, field, wa.FilePath);
            */
            AdimAdimDavaKaydi.Editor.Util.TxTextControlHelper.AddTable(txControl, field, txControl.Tables.Count + 1,
                                                                       degerListesi);
            return string.Empty;
        }

        //[PROJE] IHTIYATI HACIZ MAHKEME GOREV
        public static void GetIhtiyatiHacizMahkemeGorev(AV001_TI_BIL_IHTIYATI_HACIZ iHaciz, TextControl txControl,
                                                        TextField field)
        {
            DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.DeepLoad(iHaciz, false, DeepLoadType.IncludeChildren,
                                                                        typeof(TDI_KOD_ADLI_BIRIM_ADLIYE),
                                                                        typeof(TDI_KOD_ADLI_BIRIM_GOREV));

            if (iHaciz.ADLI_BIRIM_ADLIYE_IDSource != null)
                field.Text = iHaciz.ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;

            if (iHaciz.ADLI_BIRIM_GOREV_IDSource != null)
                field.Text += string.Format(" {0}", iHaciz.ADLI_BIRIM_GOREV_IDSource.ACIKLAMA);
        }

        //[PROJE] IHTIYATI HACIZ TALEP TARIHI
        public static void GetIhtiyatiHacizTalepTarihi(AV001_TI_BIL_IHTIYATI_HACIZ iHaciz, TextControl txControl,
                                                       TextField field)
        {
            field.Text = EditorDataAraclari.Tools.TarihBicimlendirme(iHaciz.TALEP_TARIHI);
            field.Text += string.Empty;
        }

        //[PROJE] IHTIYATI_HACIZ_TARAFLARI ALACAKLI - BORCLU
        public static void GetIhtiyatiHacizTaraflari(AV001_TI_BIL_IHTIYATI_HACIZ iHaciz, TextControl txControl,
                                                     TextField field, bool borclular)
        {
            field.Text = string.Empty;

            if (iHaciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection.Count == 0)
                DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.DeepLoad(iHaciz, false, DeepLoadType.IncludeChildren,
                                                                            typeof(
                                                                                TList<AV001_TI_BIL_IHTIYATI_HACIZ_TARAF>
                                                                                ));

            if (iHaciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection.Count > 0)
            {
                var sifatliTaraflar =
                    iHaciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection.Where(
                        vi => vi.TARAF_SIFAT_ID.HasValue && vi.ICRA_CARI_TARAF_ID.HasValue);

                List<byte> tarafNolari = new List<byte>();

                if (borclular)
                    tarafNolari.AddRange(new byte[] { 4, 14, 2 });
                else
                    tarafNolari.AddRange(new byte[] { 1, 3, 13 });

                if (sifatliTaraflar.Count() > 0)
                {
                    foreach (var tekTaraf in sifatliTaraflar)
                    {
                        if (tekTaraf.TARAF_SIFAT_IDSource == null)
                            DataRepository.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFProvider.DeepLoad(tekTaraf, false,
                                                                                              DeepLoadType.
                                                                                                  IncludeChildren,
                                                                                              typeof(
                                                                                                  TDIE_KOD_TARAF_SIFAT));

                        if (tekTaraf.TARAF_SIFAT_IDSource != null
                            && tarafNolari.Contains(tekTaraf.TARAF_SIFAT_IDSource.HANGI_TARAF_NO))
                        {
                            if (tekTaraf.ICRA_CARI_TARAF_IDSource == null)
                                DataRepository.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFProvider.DeepLoad(tekTaraf, false,
                                                                                                  DeepLoadType.
                                                                                                      IncludeChildren,
                                                                                                  typeof(
                                                                                                      AV001_TDI_BIL_CARI
                                                                                                      ));

                            if (tekTaraf.ICRA_CARI_TARAF_IDSource != null)
                            {
                                field.Text += GetCariAdAdres(tekTaraf.ICRA_CARI_TARAF_IDSource);
                            }
                        }
                    }
                }
            }
        }

        public static void GetMalTakipSureci(AV001_TDIE_BIL_PROJE proje, bool hacizmi, TextControl txControl, TextField field)
        {
            txControl.Select(field.Start, 0);
            field.Text = " ";

            List<string[]> liste = new List<string[]>();

            //int sira = 1;

            if (hacizmi)
                liste.Add(new[]
                          {
                              "Dosya Bilgisi","Haciz T.","Maliki", "Kategori",
                              "Kıy.Tak.T.","Kıy.Tak.Değ.", "Ekspertiz T.", "Ekspertiz Değeri",
                              "Satış T. 1", "Satış T. 2", "Gerçekleşme T.",
                              "İhale Bedeli", "Kesinleşme Tarihi"
                          });
            else
                liste.Add(new[]
                          {
                             "Dosya Bilgisi","Rehin Türü","Maliki","Değeri","Derece","Mal Bilgisi",
                              "Kıy.Tak.T.","Kıy.Tak.Değ.", "Ekspertiz T.", "Ekspertiz Değeri",
                              "Satış T. 1", "Satış T. 2", "Gerçekleşme T.",
                              "İhale Bedeli", "Kesinleşme Tarihi"
                          });

            #region Takipliler

            if (proje.AV001_TI_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY.Count == 0)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY>));

            foreach (var foy in proje.AV001_TI_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY)
            {
                if (foy.AV001_TI_BIL_HACIZ_MASTERCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_HACIZ_MASTER>));

                string dosyaBilgisi = string.Empty;

                if (foy.ADLI_BIRIM_ADLIYE_ID.HasValue)
                {
                    if (BelgeUtil.Inits._AdliBirimAdliyeGetir == null)
                        BelgeUtil.Inits._AdliBirimAdliyeGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetAll();
                    dosyaBilgisi += BelgeUtil.Inits._AdliBirimAdliyeGetir.Find(vi => vi.ID == foy.ADLI_BIRIM_ADLIYE_ID.Value).ADLIYE + " ";
                }
                if (foy.ADLI_BIRIM_NO_ID.HasValue)
                {
                    if (BelgeUtil.Inits._AdliBirimNoGetir == null)
                        BelgeUtil.Inits._AdliBirimNoGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_NOProvider.GetAll();
                    dosyaBilgisi += BelgeUtil.Inits._AdliBirimNoGetir.Find(vi => vi.ID == foy.ADLI_BIRIM_NO_ID.Value).NO + " ";
                }
                dosyaBilgisi += foy.ESAS_NO;

                foreach (var haciz in foy.AV001_TI_BIL_HACIZ_MASTERCollection.FindAll(vi => vi.HACIZ_MI == hacizmi))
                {
                    //if (haciz.HACIZ_TOPLAM_DEGERI.HasValue)
                    //{
                    //    degeri.Para = haciz.HACIZ_TOPLAM_DEGERI.Value;
                    //    degeri.DovizId = haciz.HACIZ_TOPLAM_DEGERI_DOVIZ_ID.Value;
                    //}

                    if (haciz.AV001_TI_BIL_HACIZ_CHILDCollection.Count == 0)
                        DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.DeepLoad(haciz, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_HACIZ_CHILD>));

                    foreach (var hChild in haciz.AV001_TI_BIL_HACIZ_CHILDCollection)
                    {
                        ParaVeDovizId degeri = new ParaVeDovizId();
                        string derece = string.Empty;
                        string aciklama = string.Empty;
                        string maliki = string.Empty;
                        DateTime? expertizTarihi = null;
                        ParaVeDovizId ekspertizDegeri = new ParaVeDovizId();
                        DateTime? kiymetTaktirTarihi = null;
                        ParaVeDovizId kiymetTDegeri = new ParaVeDovizId();
                        DateTime? satisTarihi1 = null;
                        DateTime? satisTarihi2 = null;
                        DateTime? kesinlesmeTarihi = null;
                        DateTime? gerceklesmeTarihi = null;
                        DateTime? rehinIpotekTarihi = null;
                        ParaVeDovizId satisDegeri = new ParaVeDovizId();
                        DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepLoad(hChild, false, DeepLoadType.IncludeChildren, typeof(TI_KOD_MAL_KATEGORI));
                        string rehinTuru = string.Empty;

                        if (hChild.GAYRIMENKUL_BILGI_ID.HasValue)
                        {
                            rehinTuru = "İpotek";

                            var sozlesme = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByGAYRIMENKUL_IDFromNN_SOZLESME_GAYRIMENKUL(hChild.GAYRIMENKUL_BILGI_ID.Value).FirstOrDefault();

                            if (sozlesme != null)
                            {
                                degeri = new ParaVeDovizId(sozlesme.BEDELI, sozlesme.BEDELI_DOVIZ_ID);
                                rehinIpotekTarihi = sozlesme.SICIL_TARIHI;
                            }

                            if (hChild.GAYRIMENKUL_BILGI_IDSource == null)
                                DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepLoad(hChild, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_GAYRIMENKUL), typeof(TI_KOD_MAL_KATEGORI));

                            DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(hChild.GAYRIMENKUL_BILGI_IDSource, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE));

                            if (hChild.GAYRIMENKUL_BILGI_IDSource.IL_IDSource != null)
                                aciklama += hChild.GAYRIMENKUL_BILGI_IDSource.IL_IDSource.IL + " ";

                            if (hChild.GAYRIMENKUL_BILGI_IDSource.ILCE_IDSource != null)
                                aciklama += hChild.GAYRIMENKUL_BILGI_IDSource.ILCE_IDSource.ILCE + " ";

                            aciklama += string.Format("Ada : {0} Pafta : {1} Parsel : {2} Niteliği : {3} Bağımsız Bölüm No: {4}"
                                                      , hChild.GAYRIMENKUL_BILGI_IDSource.ADA_NO
                                                      , hChild.GAYRIMENKUL_BILGI_IDSource.PAFTA_NO
                                                      , hChild.GAYRIMENKUL_BILGI_IDSource.PARSEL_NO
                                                      , hChild.GAYRIMENKUL_BILGI_IDSource.NITELIGI, hChild.GAYRIMENKUL_BILGI_IDSource.BAGIMSIZ_BOLUM_NO);
                            if (sozlesme != null)
                                aciklama += " Yevmiye No : " + sozlesme.SICIL_YEVMIYE_NO;

                            if (hChild.GAYRIMENKUL_BILGI_IDSource.AV001_TDI_BIL_SOZLESME_DERECECollection.Count == 0)
                                DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(hChild.GAYRIMENKUL_BILGI_IDSource, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_DERECE>));
                            if (hChild.GAYRIMENKUL_BILGI_IDSource.AV001_TDI_BIL_SOZLESME_DERECECollection.Count > 0)
                                derece = hChild.GAYRIMENKUL_BILGI_IDSource.AV001_TDI_BIL_SOZLESME_DERECECollection[0].DERECESI;

                            var gayriTarafList = DataRepository.AV001_TI_BIL_GAYRIMENKUL_TARAFProvider.GetByGAYRI_MENKUL_ID(hChild.GAYRIMENKUL_BILGI_ID.Value).FindAll(vi => vi.TARAF_SIFAT_ID == 1);
                            foreach (var item in gayriTarafList)
                            {
                                var cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(item.TARAF_CARI_ID.Value);
                                if (cari != null)
                                    maliki += cari.AD + " ";
                            }
                        }
                        else if (hChild.ARAC_BILGI_ID.HasValue)
                        {
                            rehinTuru = "Menkul Rehni";

                            if (hChild.ARAC_BILGI_IDSource == null)
                                DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepLoad(hChild, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_GEMI_UCAK_ARAC));

                            aciklama = hChild.ARAC_BILGI_IDSource.ARAC_PLAKA;
                        }

                        if (hChild.AV001_TI_BIL_KIYMET_TAKDIRICollection.Count == 0)
                            DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepLoad(hChild, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>));

                        foreach (var kTakdir in hChild.AV001_TI_BIL_KIYMET_TAKDIRICollection)
                        {
                            if (kTakdir.EKSPERTIZ_KAYDI_MI ?? false)
                            {
                                expertizTarihi = kTakdir.KIYMET_TAKDIRI_TARIHI;
                                ekspertizDegeri.Para = kTakdir.HACIZLI_MAL_MIKTARI_BIRIM_FIYATI;
                                ekspertizDegeri.DovizId = kTakdir.HACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID;
                            }
                            else
                            {
                                kiymetTaktirTarihi = kTakdir.KIYMET_TAKDIRI_TARIHI;
                                kiymetTDegeri.Para = kTakdir.HACIZLI_MAL_MIKTARI_BIRIM_FIYATI;
                                kiymetTDegeri.DovizId = kTakdir.HACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID;
                            }
                        }
                        if (hChild.AV001_TI_BIL_SATIS_CHILDCollection.Count == 0)
                            DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepLoad(hChild, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_SATIS_CHILD>));

                        foreach (var sChild in hChild.AV001_TI_BIL_SATIS_CHILDCollection)
                        {
                            if (sChild.MASTER_IDSource == null)
                                DataRepository.AV001_TI_BIL_SATIS_CHILDProvider.DeepLoad(sChild, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_SATIS_MASTER));

                            satisTarihi1 = sChild.MASTER_IDSource.SATIS_TARIHI_1;
                            satisTarihi2 = sChild.MASTER_IDSource.SATIS_TARIHI_2;
                            kesinlesmeTarihi = sChild.MASTER_IDSource.SATIS_KESINLESME_TARIHI;
                            gerceklesmeTarihi = sChild.MASTER_IDSource.SATIS_GERCEKLESME_TARIHI;
                            satisDegeri.Para = sChild.ICRA_SATIS_BEDELI;
                            satisDegeri.DovizId = sChild.ICRA_SATIS_BEDELI_DOVIZ_ID;
                        }
                        if (hacizmi)
                            liste.Add(new[]
                                      {
                                          //sira++.ToString(),
                                          dosyaBilgisi,
                                          EditorDataAraclari.Tools.TarihBicimlendirme(haciz.HACIZ_TARIHI),
                                          maliki,
                                          hChild.HACIZLI_MAL_KATEGORI_IDSource.KATEGORI,
                                          EditorDataAraclari.Tools.TarihBicimlendirme(kiymetTaktirTarihi),
                                          kiymetTDegeri.GetStringValue(),
                                          EditorDataAraclari.Tools.TarihBicimlendirme(expertizTarihi),
                                          ekspertizDegeri.GetStringValue(),
                                          EditorDataAraclari.Tools.TarihBicimlendirme(satisTarihi1),
                                          EditorDataAraclari.Tools.TarihBicimlendirme(satisTarihi2),
                                          EditorDataAraclari.Tools.TarihBicimlendirme(gerceklesmeTarihi),
                                          satisDegeri.GetStringValue(),
                                          EditorDataAraclari.Tools.TarihBicimlendirme(kesinlesmeTarihi)
                                      });
                        else
                            liste.Add(new[]
                                      {
                                          //sira++.ToString(),
                                          dosyaBilgisi,
                                          rehinTuru,
                                          maliki,
                                          degeri.GetStringValue(),
                                          derece,
                                          aciklama,
                                          EditorDataAraclari.Tools.TarihBicimlendirme(kiymetTaktirTarihi),
                                          kiymetTDegeri.GetStringValue(),
                                          EditorDataAraclari.Tools.TarihBicimlendirme(expertizTarihi),
                                          ekspertizDegeri.GetStringValue(),
                                          EditorDataAraclari.Tools.TarihBicimlendirme(satisTarihi1),
                                          EditorDataAraclari.Tools.TarihBicimlendirme(satisTarihi2),
                                          EditorDataAraclari.Tools.TarihBicimlendirme(gerceklesmeTarihi),
                                          satisDegeri.GetStringValue(),
                                          EditorDataAraclari.Tools.TarihBicimlendirme(kesinlesmeTarihi)
                                      });
                    }
                }
            }

            #endregion Takipliler

            if (hacizmi)
            {
                AdimAdimDavaKaydi.Editor.Util.TxTextControlHelper.AddTable(txControl, field, txControl.Tables.Count + 1,
                                                                       liste);
                return;
            }

            #region Takipsizler

            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_TEMINAT>));

            foreach (var item in proje.AV001_TDIE_BIL_PROJE_TEMINATCollection)
            {
                if (DataRepository.AV001_TDIE_BIL_PROJE_TEMINAT_TAKIPLIProvider.GetBySOZLESME_ID(item.SOZLESME_ID).Count != 0) continue;

                string aciklama = string.Empty;
                DateTime? takipsizRehinIpotekTarihi = new DateTime();
                ParaVeDovizId takipsizDegeri = new ParaVeDovizId();

                var sozlesme = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(item.SOZLESME_ID);

                if (sozlesme != null)
                {
                    takipsizDegeri = new ParaVeDovizId(sozlesme.BEDELI, sozlesme.BEDELI_DOVIZ_ID);
                    takipsizRehinIpotekTarihi = sozlesme.SICIL_TARIHI;
                }

                var gayrimenkulList = DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.GetBySOZLESME_IDFromNN_SOZLESME_GAYRIMENKUL(item.SOZLESME_ID);
                gayrimenkulList.ForEach(gayri =>
                {
                    aciklama = string.Empty;
                    DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(gayri, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE), typeof(TList<AV001_TI_BIL_GAYRIMENKUL_TARAF>), typeof(TList<AV001_TDI_BIL_SOZLESME_DERECE>), typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>));

                    string maliki = string.Empty;

                    var tarafCari = gayri.AV001_TI_BIL_GAYRIMENKUL_TARAFCollection.Find(vi => vi.TARAF_SIFAT_ID == 1);
                    if (tarafCari != null && tarafCari.TARAF_CARI_ID.HasValue)
                        maliki = BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == tarafCari.TARAF_CARI_ID).AD;

                    if (gayri.IL_IDSource != null)
                        aciklama += "İli : " + gayri.IL_IDSource.IL + ", ";

                    if (gayri.ILCE_IDSource != null)
                        aciklama += "İlçesi : " + gayri.ILCE_IDSource.ILCE + ", ";

                    aciklama += string.Format("Ada : {0}, Pafta : {1}, Parsel : {2}, Bağımsız Bölüm No : {3}, Arsa Payı : {4}, Niteliği : {5}", gayri.ADA_NO, gayri.PAFTA_NO, gayri.PARSEL_NO, gayri.BAGIMSIZ_BOLUM_NO, gayri.ARSA_PAYI, gayri.NITELIGI);

                    string derece = string.Empty;
                    var dereceGayri = gayri.AV001_TDI_BIL_SOZLESME_DERECECollection.FirstOrDefault();
                    if (dereceGayri != null)
                    {
                        derece = dereceGayri.DERECESI;
                    }

                    DateTime? kiymetTakdiriTarihi = new DateTime();
                    DateTime? ekspertizTarihi = new DateTime();
                    ParaVeDovizId kıymetTakdiriDegeri = new ParaVeDovizId();
                    ParaVeDovizId ekspertizDegeri = new ParaVeDovizId();

                    var kiymetTakdiriGayri = gayri.AV001_TI_BIL_KIYMET_TAKDIRICollection.FindAll(vi => vi.EKSPERTIZ_KAYDI_MI.HasValue ? !vi.EKSPERTIZ_KAYDI_MI.Value : false).FirstOrDefault();
                    if (kiymetTakdiriGayri != null)
                    {
                        kiymetTakdiriTarihi = kiymetTakdiriGayri.KIYMET_TAKDIRI_TARIHI;
                        kıymetTakdiriDegeri = new ParaVeDovizId(kiymetTakdiriGayri.HACIZLI_MAL_MIKTARI_BIRIM_FIYATI, kiymetTakdiriGayri.HACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID);
                    }

                    var ekspertizGayri = gayri.AV001_TI_BIL_KIYMET_TAKDIRICollection.FindAll(vi => vi.EKSPERTIZ_KAYDI_MI.HasValue ? vi.EKSPERTIZ_KAYDI_MI.Value : false).FirstOrDefault();
                    if (ekspertizGayri != null)
                    {
                        ekspertizTarihi = ekspertizGayri.KIYMET_TAKDIRI_TARIHI;
                        ekspertizDegeri = new ParaVeDovizId(ekspertizGayri.HACIZLI_MAL_MIKTARI_BIRIM_FIYATI, ekspertizGayri.HACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID);
                    }

                    liste.Add(new[]
                                      {
                                          //sira++.ToString(),
                                          " ",
                                          "İpotek",
                                          maliki,
                                          takipsizDegeri.GetStringValue(),
                                          derece,
                                          aciklama,
                                          EditorDataAraclari.Tools.TarihBicimlendirme(kiymetTakdiriTarihi),
                                          kıymetTakdiriDegeri.GetStringValue(),
                                          EditorDataAraclari.Tools.TarihBicimlendirme(ekspertizTarihi),
                                          ekspertizDegeri.GetStringValue(),
                                          " ",
                                          " ",
                                          " ",
                                          " ",
                                          " "
                                      });
                });

                var aracList = DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.GetBySOZLESME_IDFromNN_SOZLESME_GEMI_UCAK_ARAC(item.SOZLESME_ID);
                DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.DeepLoad(aracList, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_DERECE>), typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>));

                aracList.ForEach(arac =>
                {
                    string aracSahibi = string.Empty;

                    if (arac.SAHIB_CARI_ID.HasValue)
                        aracSahibi = "Sahibi : " + BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == arac.SAHIB_CARI_ID.Value).AD;

                    string tip = string.Empty;
                    if (arac.TIPI == (int)(AvukatProLib.Extras.AracTipi.ARAC))
                    {
                        aciklama += "Plaka : " + arac.ARAC_PLAKA;
                        tip = "Araç";
                    }
                    else if (arac.TIPI == (int)(AvukatProLib.Extras.AracTipi.UCAK))
                        tip = "Uçak";
                    else if (arac.TIPI == (int)(AvukatProLib.Extras.AracTipi.GEMI))
                        tip = "Gemi";

                    string derece = string.Empty;
                    var dereceGayri = arac.AV001_TDI_BIL_SOZLESME_DERECECollection.FirstOrDefault();
                    if (dereceGayri != null)
                    {
                        derece = dereceGayri.DERECESI;
                    }

                    DateTime? kiymetTakdiriTarihi = new DateTime();
                    DateTime? ekspertizTarihi = new DateTime();
                    ParaVeDovizId kıymetTakdiriDegeri = new ParaVeDovizId();
                    ParaVeDovizId ekspertizDegeri = new ParaVeDovizId();

                    var kiymetTakdiriArac = arac.AV001_TI_BIL_KIYMET_TAKDIRICollection.FindAll(vi => vi.EKSPERTIZ_KAYDI_MI.HasValue ? !vi.EKSPERTIZ_KAYDI_MI.Value : false).FirstOrDefault();
                    if (kiymetTakdiriArac != null)
                    {
                        kiymetTakdiriTarihi = kiymetTakdiriArac.KIYMET_TAKDIRI_TARIHI;
                        kıymetTakdiriDegeri = new ParaVeDovizId(kiymetTakdiriArac.HACIZLI_MAL_MIKTARI_BIRIM_FIYATI, kiymetTakdiriArac.HACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID);
                    }

                    var ekspertizArac = arac.AV001_TI_BIL_KIYMET_TAKDIRICollection.FindAll(vi => vi.EKSPERTIZ_KAYDI_MI.HasValue ? vi.EKSPERTIZ_KAYDI_MI.Value : false).FirstOrDefault();
                    if (ekspertizArac != null)
                    {
                        ekspertizTarihi = ekspertizArac.KIYMET_TAKDIRI_TARIHI;
                        ekspertizDegeri = new ParaVeDovizId(ekspertizArac.HACIZLI_MAL_MIKTARI_BIRIM_FIYATI, ekspertizArac.HACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID);
                    }

                    liste.Add(new[]
                                      {
                                          //sira++.ToString(),
                                          " ",
                                          "Menkul Rehni",
                                          aracSahibi,
                                          takipsizDegeri.GetStringValue(),
                                          derece,

                                          //tip,
                                          aciklama,
                                          EditorDataAraclari.Tools.TarihBicimlendirme(kiymetTakdiriTarihi),
                                          kıymetTakdiriDegeri.GetStringValue(),
                                          EditorDataAraclari.Tools.TarihBicimlendirme(ekspertizTarihi),
                                          ekspertizDegeri.GetStringValue(),
                                          " ",
                                          " ",
                                          " ",
                                          " ",
                                          " "
                                      });
                });
            }

            #endregion Takipsizler

            /*
            WordApp wa = new WordApp(liste);

            Klasor.Tool.WordImport(txControl, field, wa.FilePath);
            */
            AdimAdimDavaKaydi.Editor.Util.TxTextControlHelper.AddTable(txControl, field, txControl.Tables.Count + 1,
                                                                       liste);
        }

        //[PROJE] ACIKLAMALARI
        public static void GetProjeAciklamalari(AV001_TDIE_BIL_PROJE proje, TextControl txControl, TextField field)
        {
            field.Text = string.Empty;
            field.Text = proje.ACIKLAMA;
            field.Text += Environment.NewLine;

            //AvukatProLib.Arama.AvpDataContext db =
            //    new AvukatProLib.Arama.AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            //var notlar = db.AV001_TDIE_BIL_PROJE_GENEL_NOTs.Where(vi => vi.PROJE_ID == proje.ID);

            //foreach (var not in notlar)
            //{
            //    field.Text += string.Format("{2}-{1} {3} {0} {3}", not.NOTLAR,
            //                                not.TDI_BIL_KULLANICI_LISTESI.AV001_TDI_BIL_CARI1.AD,
            //                                EditorDataAraclari.Tools.TarihBicimlendirme(not.KAYIT_TARIHI),
            //                                Environment.NewLine);
            //}
        }

        //[PROJE] SORUMLU AVUKAT AD
        public static void GetProjeSorumluAvukatAdi(AV001_TDIE_BIL_PROJE proje, TextControl txControl, TextField field)
        {
            if (proje.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Count == 0)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TDIE_BIL_PROJE_SORUMLU>));

            field.Text = string.Empty;

            var sorumluAvukat =
                proje.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Where(vi => !vi.YETKILI_MI.HasValue || !vi.YETKILI_MI.Value);

            if (sorumluAvukat.Count() > 0)
            {
                field.Text = "Av." + DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(sorumluAvukat.First().CARI_ID).AD;
            }
            else
                field.Text = "Av." +
                             DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(
                                 proje.AV001_TDIE_BIL_PROJE_SORUMLUCollection[0].CARI_ID).AD;
        }

        //[PROJE] SORUMLU AVUKAT AD ADRES
        public static void GetProjeSorumlulariAdAdres(AV001_TDIE_BIL_PROJE proje, TextControl txControl, TextField field)
        {
            if (proje.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Count == 0)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TDIE_BIL_PROJE_SORUMLU>));

            field.Text = string.Empty;

            if (proje.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Count > 0)
            {
                var adVeAdresler =
                    proje.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Select(
                        vi => GetCariAdAdres(DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(vi.CARI_ID)));

                foreach (var item in adVeAdresler)
                {
                    field.Text += item;
                }
            }
        }

        //[PROJE] SORUMLU BILGILERI
        public static void GetSorumluBilgileri(AV001_TDIE_BIL_PROJE proje, TextControl txControl, TextField field)
        {
            field.Text = " ";
            txControl.Select(field.Start, 0);

            var sorumlular = EditorDataAraclari.Klasor.GetKlasorSorumlulariById(proje.ID);

            if (txControl.Tables.Add(sorumlular.Count, 3, 654))
            {
                var tab = txControl.Tables.GetItem(654);
                tab.Columns.GetItem(1).Width = 300;
                tab.Columns.GetItem(2).Width = -1;

                var enume = tab.Cells.GetEnumerator();

                while (enume.MoveNext())
                {
                    var cell = enume.Current as TableCell;
                    if (cell.Column == 1)
                    {
                        cell.Text = string.Format("{0}) ", cell.Row);
                        cell.Select();
                        txControl.Selection.Bold = true;
                    }
                    else
                    {
                        string cariSifatli =
                            HesapAraclari.Icra.CariAdiYetkiDurumuGetirByCariId(sorumlular[cell.Row - 1].CARI_ID);
                        var splt = cariSifatli.Split('#');

                        if (splt.Length > 1)
                        {
                            splt[1] = (sorumlular[cell.Row - 1].YETKILI_MI ?? false) ? "İzleyen" : "Sorumlu";
                            cell.Text = splt[cell.Column - 2];
                        }

                        cell.Select();
                        txControl.Selection.Bold = false;
                    }
                }
            }
        }

        //[PROJE] SORUSTURMA BILGILERI
        public static void GetSorusturmaBilgileri(AV001_TDIE_BIL_PROJE proje, TextControl txControl, TextField field)
        {
            field.Text = " ";
            txControl.Select(field.Start, 0);

            List<string[]> degerler = new List<string[]>();
            var sorusturmalar = EditorDataAraclari.Klasor.GetSorusturmaBilgileriByProjeId(proje.ID);

            string[] basliklar = new[]
                                     {
                                         "Sıra",
                                         "Savcılık", //ADLIYE
                                         "Şikayet Eden", //SORUSTURMA_TARAF_ADI
                                         "Şikayet Olunan",

                                         //"Hazırlık No", //HAZIRLIK_NO
                                         "Şikayet Tarihi", //SIKAYET_TARIHI
                                         "Şikayet Nedeni", //DAVA_TALEP

                                         //"No", //NO
                                         //"Görev", //GOREV
                                         //"Esas No", //HAZIRLIK_ESAS_NO
                                         "Sorumlu Avukat" //SORUMLU_AVUKAT
                                     };
            degerler.Add(basliklar);
            int sira = 1;
            foreach (var item in sorusturmalar)
            {
                var tarafList = DataRepository.AV001_TD_BIL_HAZIRLIK_TARAFProvider.GetByHAZIRLIK_ID(item.ID);

                string sikayetEden = string.Empty;
                string sikayetEdilen = string.Empty;

                foreach (var taraf in tarafList)
                {
                    if (taraf.SIKAYET_EDEN_MI)
                        sikayetEden += BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == taraf.CARI_ID.Value).AD + Environment.NewLine + Environment.NewLine;
                    else
                        sikayetEdilen += BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == taraf.CARI_ID.Value).AD + Environment.NewLine + Environment.NewLine;
                }

                string[] dizi = new[]
                                    {
                                        (sira++).ToString(),
                                        item.ADLIYE + " "+item.NO+" "+item.GOREV+" "+item.HAZIRLIK_ESAS_NO,
                                        sikayetEden,
                                        sikayetEdilen,

                                        //item.HAZIRLIK_NO,
                                        EditorDataAraclari.Tools.TarihBicimlendirme(item.SIKAYET_TARIHI),
                                        item.DAVA_TALEP,

                                        //item.NO,
                                        //item.GOREV,
                                        //item.HAZIRLIK_ESAS_NO,
                                        item.SORUMLU_AVUKAT
                                    };

                degerler.Add(dizi);
            }

            /*
            WordApp wa = new WordApp(degerler);

            Klasor.Tool.WordImport(txControl, field, wa.FilePath);
            */
            AdimAdimDavaKaydi.Editor.Util.TxTextControlHelper.AddTable(txControl, field, txControl.Tables.Count + 1,
                                                                       degerler);
        }

        //[PROJE] TAAHHUT BILGILERI
        public static void GetTaahhutBilgileri(AV001_TDIE_BIL_PROJE proje, TextControl txControl, TextField field)
        {
            var datalar = EditorDataAraclari.Klasor.GetTaahhutBilgileriByProjeID(proje.ID);

            List<string[]> liste = new List<string[]>();

            string[] basliklar = new[]
                                     {
                                         //"Sıra",
                                         "Taahhüt Veren",

                                         //"Tip",//TAAHHUT_TIP
                                         "Protokol Tarihi", //TAAHHUT_TARIHI
                                         "Taksit Sayısı", //TAKSIT_SAYISI
                                         "Miktarı", //TAAHHUT_MIKTARI
                                         "Dosya Bilgisi"
                                     };

            liste.Add(basliklar);
            foreach (var item in datalar)
            {
                string[] dizi = new[]
                                    {
                                        //sira++.ToString(),
                                        item.AD,

                                        //item.TAAHHUT_TIP,
                                        EditorDataAraclari.Tools.TarihBicimlendirme(item.TAAHHUT_TARIHI),
                                        item.TAKSIT_SAYISI.ToString(),
                                        EditorDataAraclari.Icra.GetTaahhutOdemeToplami(item.TAAHUT_ID).GetStringValue(),

                                        //item.ESAS_NO,
                                        item.ADLIYE + " "+item.NO+" "+item.ESAS_NO,
                                    };

                liste.Add(dizi);
            }
            /*
            WordApp wa = new WordApp(liste);

            Klasor.Tool.WordImport(txControl, field, wa.FilePath);

            */
            AdimAdimDavaKaydi.Editor.Util.TxTextControlHelper.AddTable(txControl, field, txControl.Tables.Count + 1,
                                                                       liste);
        }

        public static void GetTakipsizMalTakipSureci(AV001_TDIE_BIL_PROJE proje, TextControl txControl, TextField field)
        {
            #region <MB-20101206>

            //Takibi açılmamış, direkt klasöre bağlı teminatların klasör raporunda görünmesini sağlamak amacıyla eklendi.

            txControl.Select(field.Start, 0);
            field.Text = " ";

            List<string[]> liste = new List<string[]>();
            liste.Add(new[] { "Kategori", "Açıklama" });

            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_TEMINAT>));

            foreach (var item in proje.AV001_TDIE_BIL_PROJE_TEMINATCollection)
            {
                if (DataRepository.AV001_TDIE_BIL_PROJE_TEMINAT_TAKIPLIProvider.GetBySOZLESME_ID(item.SOZLESME_ID).Count != 0) continue;

                string aciklama = string.Empty;

                var gayrimenkulList = DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.GetBySOZLESME_IDFromNN_SOZLESME_GAYRIMENKUL(item.SOZLESME_ID);
                gayrimenkulList.ForEach(gayri =>
                {
                    aciklama = string.Empty;
                    DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(gayri, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE), typeof(TList<AV001_TI_BIL_GAYRIMENKUL_TARAF>));

                    var tarafCari = gayri.AV001_TI_BIL_GAYRIMENKUL_TARAFCollection.Find(vi => vi.TARAF_SIFAT_ID == 1);
                    if (tarafCari != null)
                        aciklama += "Maliki : " + BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == tarafCari.TARAF_CARI_ID).AD;

                    if (gayri.IL_IDSource != null)
                        aciklama += "İli : " + gayri.IL_IDSource.IL + ", ";

                    if (gayri.ILCE_IDSource != null)
                        aciklama += "İlçesi : " + gayri.ILCE_IDSource.ILCE + ", ";

                    aciklama += string.Format("Ada : {0}, Pafta : {1}, Parsel : {2}, Bağımsız Bölüm No : {3}, Arsa Payı : {4}, Niteliği : {5}", gayri.ADA_NO, gayri.PAFTA_NO, gayri.PARSEL_NO, gayri.BAGIMSIZ_BOLUM_NO, gayri.ARSA_PAYI, gayri.NITELIGI);
                    liste.Add(new[] { "Gayrimenkul", aciklama });
                });

                var aracList = DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.GetBySOZLESME_IDFromNN_SOZLESME_GEMI_UCAK_ARAC(item.SOZLESME_ID);
                aracList.ForEach(arac =>
                {
                    if (arac.SAHIB_CARI_ID.HasValue)
                        aciklama += "Sahibi : " + BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == arac.SAHIB_CARI_ID.Value).AD;

                    string tip = string.Empty;
                    if (arac.TIPI == (int)(AvukatProLib.Extras.AracTipi.ARAC))
                    {
                        aciklama += "Plaka : " + arac.ARAC_PLAKA;
                        tip = "Araç";
                    }
                    else if (arac.TIPI == (int)(AvukatProLib.Extras.AracTipi.UCAK))
                        tip = "Uçak";
                    else if (arac.TIPI == (int)(AvukatProLib.Extras.AracTipi.GEMI))
                        tip = "Gemi";

                    liste.Add(new[] { tip, aciklama });
                });
            }
            AdimAdimDavaKaydi.Editor.Util.TxTextControlHelper.AddTable(txControl, field, txControl.Tables.Count + 1, liste);

            #endregion <MB-20101206>
        }

        //[PROJE] TARAF GELISMELERI
        public static void GetTarafGelismeleri(AV001_TDIE_BIL_PROJE proje, TextControl txControl, TextField field)
        {
            List<string[]> liste = new List<string[]>();

            var basliklar = new[]
                                {
                                    "Sıra",
                                    "Dosya Bilgisi",

                                    //"Sıfat",
                                    "Borçlular",
                                    "Tebliğ",
                                    "MBB",
                                    "İtiraz",
                                    "Kesinleşme",

                                    // "Haciz"
                                };
            liste.Add(basliklar);
            int sira = 1;

            if (proje.AV001_TI_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY.Count == 0)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY>));

            foreach (var foy in proje.AV001_TI_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY)
            {
                if (foy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>));

                foreach (var taraf in foy.AV001_TI_BIL_FOY_TARAFCollection)
                {
                    if (taraf.AV001_TI_BIL_FOY_TARAF_GELISMECollection.Count == 0)
                        DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(taraf, false,
                                                                               DeepLoadType.IncludeChildren,
                                                                               typeof(
                                                                                   TList<AV001_TI_BIL_FOY_TARAF_GELISME>
                                                                                   ));

                    foreach (var gelisme in taraf.AV001_TI_BIL_FOY_TARAF_GELISMECollection)
                    {
                        string dosyaBilgisi = string.Empty;

                        if (foy.ADLI_BIRIM_ADLIYE_ID.HasValue)
                        {
                            if (BelgeUtil.Inits._AdliBirimAdliyeGetir == null)
                                BelgeUtil.Inits._AdliBirimAdliyeGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetAll();
                            dosyaBilgisi += BelgeUtil.Inits._AdliBirimAdliyeGetir.Find(vi => vi.ID == foy.ADLI_BIRIM_ADLIYE_ID.Value).ADLIYE + " ";
                        }
                        if (foy.ADLI_BIRIM_NO_ID.HasValue)
                        {
                            if (BelgeUtil.Inits._AdliBirimNoGetir == null)
                                BelgeUtil.Inits._AdliBirimNoGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_NOProvider.GetAll();
                            dosyaBilgisi += BelgeUtil.Inits._AdliBirimNoGetir.Find(vi => vi.ID == foy.ADLI_BIRIM_NO_ID.Value).NO + " ";
                        }
                        dosyaBilgisi += foy.ESAS_NO;

                        liste.Add(new[]
                                      {
                                          sira++.ToString()
                                          , dosyaBilgisi

                                          //, EditorDataAraclari.Tools.GetTarafSifat(taraf.TARAF_SIFAT_ID)
                                          , HesapAraclari.Icra.CariAdiGetirByCariId(taraf.CARI_ID)
                                          , EditorDataAraclari.Tools.TarihBicimlendirme(gelisme.ILK_TEBLIGAT_TARIHI)
                                          , EditorDataAraclari.Tools.TarihBicimlendirme(gelisme.MAL_BEYANI_TARIHI)
                                          , EditorDataAraclari.Tools.TarihBicimlendirme(gelisme.ITIRAZ_TARIHI)
                                          , EditorDataAraclari.Tools.TarihBicimlendirme(gelisme.KESINLESME_TARIHI)

                                          //,EditorDataAraclari.Tools.TarihBicimlendirme(gelisme.SON_HACIZ_TARIHI)
                                      });
                        break; //bir tarafın 1 gelişmesi olur
                    }
                }
            }
            /*
            WordApp wa = new WordApp(liste);

            Klasor.Tool.WordImport(txControl, field, wa.FilePath);

            */
            AdimAdimDavaKaydi.Editor.Util.TxTextControlHelper.AddTable(txControl, field, txControl.Tables.Count + 1,
                                                                       liste);
        }

        //[PROJE] TEMINAT BILGILERI
        public static string GetTeminatBilgileri(AV001_TDIE_BIL_PROJE proje, bool munzammi, TextControl txControl, TextField field)
        {
            field.Text = " ";
            txControl.Select(field.Start, 0);

            var sonuclar = EditorDataAraclari.Klasor.GetTeminatBilgileriByProjeId(proje.ID, munzammi);
            var grup = sonuclar.GroupBy(vi => vi.KIYMETLI_EVRAK_ID);

            #region Değerler Oluşturuluyor

            string[] basliklar = new[]
                                     {
                                         "Sıra",
                                         "Borçlu Adı",
                                         "Türü",
                                         "Düzenleme T",
                                         "Vade T",
                                         "Bedeli",
                                         "Bankası",
                                         "Şubesi",
                                         "Hesap No",
                                         "Çek No",
                                         "Dosya Bilgisi"
                                     };
            if (munzammi)
                basliklar = new[]
                                     {
                                         "Sıra",
                                         "Borçlu Adı",
                                         "Türü",

                                         //"Düzenleme T",
                                         "Vade T",
                                         "Bedeli",
                                         "Dosya Bilgisi"
                                     };

            int sira = 1;
            int siraMunzam = 1;
            List<string[]> degerler = new List<string[]>();
            degerler.Add(basliklar);
            foreach (var item in grup)
            {
                var teminat = item.First();
                string ad = string.Empty;
                var takipliFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByKIYMETLI_EVRAK_IDFromNN_ICRA_KIYMETLI_EVRAK(teminat.KIYMETLI_EVRAK_ID).FirstOrDefault();
                string dosyaBilgisi = string.Empty;
                if (takipliFoy != null)
                {
                    if (BelgeUtil.Inits._AdliBirimAdliyeGetir == null)
                        BelgeUtil.Inits._AdliBirimAdliyeGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetAll();
                    if (BelgeUtil.Inits._AdliBirimNoGetir == null)
                        BelgeUtil.Inits._AdliBirimNoGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_NOProvider.GetAll();
                    if (BelgeUtil.Inits._AdliBirimGorevGetir_Enter == null)
                        BelgeUtil.Inits._AdliBirimGorevGetir_Enter = DataRepository.per_TDI_KOD_ADLI_BIRIM_GOREVProvider.GetAll();

                    string adliye = takipliFoy.ADLI_BIRIM_ADLIYE_ID.HasValue ? BelgeUtil.Inits._AdliBirimAdliyeGetir.Find(vi => vi.ID == takipliFoy.ADLI_BIRIM_ADLIYE_ID.Value).ADLIYE + " " : "";
                    string no = takipliFoy.ADLI_BIRIM_NO_ID.HasValue ? BelgeUtil.Inits._AdliBirimNoGetir.Find(vi => vi.ID == takipliFoy.ADLI_BIRIM_NO_ID.Value).NO + " " : "";
                    string gorev = takipliFoy.ADLI_BIRIM_GOREV_ID.HasValue ? BelgeUtil.Inits._AdliBirimGorevGetir_Enter.Find(vi => vi.ID == takipliFoy.ADLI_BIRIM_GOREV_ID.Value).GOREV + " " : "";
                    dosyaBilgisi = string.Format("{0}{1}{2} {3}", adliye, no, gorev, takipliFoy.ESAS_NO);
                }

                foreach (var tek in item)
                {
                    if (tek.TARAF_TIP != "Alacaklı" && !ad.Contains(tek.AD))
                        ad += tek.AD + Environment.NewLine;
                }
                ad = ad.TrimEnd(Environment.NewLine.ToCharArray());

                string[] result = new[]
                                      {
                                          (sira++).ToString(),
                                          ad,
                                          teminat.TUR,
                                          EditorDataAraclari.Tools.TarihBicimlendirme(teminat.EVRAK_TANZIM_TARIHI),
                                          EditorDataAraclari.Tools.TarihBicimlendirme(teminat.EVRAK_VADE_TARIHI),
                                          new ParaVeDovizId(teminat.TUTAR, teminat.TUTAR_DOVIZ_ID).GetStringValue(),
                                          teminat.BANKA,
                                          teminat.BANKA_SUBE_KODU,
                                          teminat.HESAP_NO,
                                          teminat.CEK_NO,
                                          dosyaBilgisi
                                      };

                if (munzammi)
                    result = new[]
                                       {
                                          (siraMunzam++).ToString(),
                                          ad,
                                          teminat.TUR,

                                          //EditorDataAraclari.Tools.TarihBicimlendirme(teminat.EVRAK_TANZIM_TARIHI),
                                          EditorDataAraclari.Tools.TarihBicimlendirme(teminat.EVRAK_VADE_TARIHI),
                                          new ParaVeDovizId(teminat.TUTAR, teminat.TUTAR_DOVIZ_ID).GetStringValue(),
                                          dosyaBilgisi
                                      };
                degerler.Add(result);
            }

            #endregion Değerler Oluşturuluyor

            /*
            WordApp wa = new WordApp(degerler);

            Klasor.Tool.WordImport(txControl, field, wa.FilePath);
            */
            AdimAdimDavaKaydi.Editor.Util.TxTextControlHelper.AddTable(txControl, field, txControl.Tables.Count + 1,
                                                                       degerler);
            return string.Empty;
        }

        public static void GetTeminatMektupBilgisi(TList<AV001_TDI_BIL_TEMINAT_MEKTUP> iadeTeminatList, int? adliye, int? no, int? gorev, string dosyaNo, List<string[]> liste)
        {
            string turu = string.Empty;
            DateTime? verildigiTarih = null;
            string nosu = string.Empty;
            string miktari = string.Empty;
            string mahkemeIcraDairesi = string.Empty;
            string dosyaNosu = string.Empty;
            string banka = string.Empty;
            string sube = string.Empty;
            string sorumluAvukat = string.Empty;

            //DateTime? mektupTarihi = null;
            DateTime? iadeTarihi = null;
            DateTime? muvekkileTeslimTarihi = null;
            string aciklama = string.Empty;

            foreach (var teminat in iadeTeminatList)
            {
                if (teminat.TEMINAT_TURU_ID != 0)
                    turu = DataRepository.TI_KOD_TEMINAT_TURProvider.GetByID(teminat.TEMINAT_TURU_ID).TEMINAT_TUR;
                verildigiTarih = teminat.TARIHI;
                nosu = teminat.REFERANS_NO;
                AdimAdimDavaKaydi.Generalclass.SayiOkuma sa = new AdimAdimDavaKaydi.Generalclass.SayiOkuma();

                if (BelgeUtil.Inits._DovizTipGetir == null)
                    BelgeUtil.Inits._DovizTipGetir = DataRepository.per_TDI_KOD_DOVIZ_TIPProvider.GetAll();

                miktari = sa.ParaFormatla(teminat.TUTARI) + " " + BelgeUtil.Inits._DovizTipGetir.Find(vi => vi.ID == teminat.TUTARI_DOVIZ_ID.Value).DOVIZ_KODU;
                if (BelgeUtil.Inits._AdliBirimAdliyeGetir == null)
                    BelgeUtil.Inits._AdliBirimAdliyeGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetAll();
                if (BelgeUtil.Inits._AdliBirimNoGetir == null)
                    BelgeUtil.Inits._AdliBirimNoGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_NOProvider.GetAll();
                if (BelgeUtil.Inits._AdliBirimGorevGetir_Enter == null)
                    BelgeUtil.Inits._AdliBirimGorevGetir_Enter = DataRepository.per_TDI_KOD_ADLI_BIRIM_GOREVProvider.GetAll();

                if (adliye.HasValue)
                    mahkemeIcraDairesi += BelgeUtil.Inits._AdliBirimAdliyeGetir.Find(vi => vi.ID == adliye.Value).ADLIYE + " ";
                if (no.HasValue)
                    mahkemeIcraDairesi += BelgeUtil.Inits._AdliBirimNoGetir.Find(vi => vi.ID == no.Value).NO + " ";
                if (gorev.HasValue)
                    mahkemeIcraDairesi += BelgeUtil.Inits._AdliBirimGorevGetir_Enter.Find(vi => vi.ID == gorev.Value).GOREV;
                dosyaNosu = dosyaNo;
                if (teminat.BANKA_ID.HasValue)
                {
                    if (BelgeUtil.Inits._BankaGetir == null)
                        BelgeUtil.Inits._BankaGetir = DataRepository.per_TDI_KOD_BANKAProvider.GetAll();

                    banka = BelgeUtil.Inits._BankaGetir.Find(vi => vi.ID == teminat.BANKA_ID.Value).BANKA;
                }
                if (teminat.SUBE_ID.HasValue)
                {
                    if (BelgeUtil.Inits._BankaSubeGetir == null)
                        BelgeUtil.Inits._BankaSubeGetir = BelgeUtil.Inits.context.VDI_KOD_BANKA_SUBEs.ToList();

                    sube = BelgeUtil.Inits._BankaSubeGetir.Find(vi => vi.ID == teminat.SUBE_ID.Value).SUBE;
                }
                if (teminat.TESLIM_ALAN_CARI_ID.HasValue)
                {
                    if (BelgeUtil.Inits._per_CariGetir == null)
                        BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();

                    sorumluAvukat = BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == teminat.TESLIM_ALAN_CARI_ID.Value).AD;
                }

                //mektupTarihi = teminat.VADE_TARIHI;
                iadeTarihi = teminat.TEMINAT_IADE_TARIHI;
                muvekkileTeslimTarihi = teminat.MUVEKKILE_TESLIM_TARIHI;
                aciklama = teminat.ACIKLAMA;
                string tarih = verildigiTarih.HasValue ? verildigiTarih.Value.ToShortDateString() : "";
                liste.Add(new[] {
                                    turu + " " + tarih + " " + nosu + " " + " " + " " + miktari + " " + banka+" "+ sube,
                                    mahkemeIcraDairesi+" "+ dosyaNosu,
                                    sorumluAvukat,
                                    /*mektupTarihi.HasValue ? mektupTarihi.Value.ToShortDateString() : "",*/
                                    iadeTarihi.HasValue ? iadeTarihi.Value.ToShortDateString() : "",
                                    muvekkileTeslimTarihi.HasValue ? muvekkileTeslimTarihi.Value.ToShortDateString() : "",
                                    aciklama
                            });
            }
        }

        //[PROJE] MAL SUREC
        //public static void GetMalSurec(AV001_TDIE_BIL_PROJE proje, TextControl txControl, TextField field)
        //{
        //     List<string[]> liste = new List<string[]>();

        //    var basliklar = new string[]
        //    {
        //        "Sıra",
        //        "Esas No",
        //        "Sıfat",
        //        "Ad",
        //        "Tebliğ",
        //        "MBB",
        //        "İtiraz",
        //        "Kesinleşme",
        //        "Haciz"

        //    };
        //    liste.Add(basliklar);
        //    int sira = 1;

        //    if (proje.AV001_TI_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY.Count == 0)
        //        DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY>));

        //    foreach (var foy in proje.AV001_TI_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY)
        //    {
        //        KAPSAMLI_MAL_SURECQuery qu  =new KAPSAMLI_MAL_SURECQuery();
        //        qu.Append( KAPSAMLI_MAL_SURECColumn.ICRA_FOY_ID,foy.ID.ToString());
        //        var sonuclar =  DataRepository.KAPSAMLI_MAL_SURECProvider.Find(qu);

        //    }

        #region Tools

        public static string GetCariAdAdres(AV001_TDI_BIL_CARI cari)
        {
            string metin = string.Empty;
            if (cari.AVUKAT_MI)
                metin = "Av." + cari.AD;
            else
                metin = cari.AD;
            metin += Environment.NewLine;

            metin += string.Format("{0}{1}{2}\n{3}-{4}"
                                   , cari.Aktif_ADRES1
                                   , cari.Aktif_ADRES2
                                   , cari.Aktif_ADRES3
                                   , EditorDataAraclari.Kodlar.GetIlceAdi(cari.Aktif_ILCE_ID)
                                   , EditorDataAraclari.Kodlar.GetIlAdi(cari.Aktif_IL_ID));

            metin += Environment.NewLine;

            return metin;
        }

        #endregion Tools
    }

    public class WordApp
    {
        public WordApp(List<string[]> dizi)
        {
            Object oTrue = true;
            Object oFalse = false;

            AVPWord.Application oWord = new AVPWord.Application();
            AVPWord.Document oWordDoc = new AVPWord.Document();
            oWord.ScreenUpdating = false;

            oWordDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            oWordDoc.PageSetup.PageWidth = 815;

            // oWordDoc.PageSetup.PageHeight = 1000;

            oWord.Selection.Font.Size = 8;
            oWord.Selection.Font.Name = "Times New Roman";

            //oWord.Selection.Font.Bold = (int)AVPWord.WdConstants.wdToggle;
            //oWord.Selection.TypeText("C# Word Tutorial\n");
            //oWord.Selection.Font.Bold = (int)AVPWord.WdConstants.wdToggle;
            //oWord.Selection.TypeText("Test");

            object start = oWord.Selection.End;
            object end = oWord.Selection.End;
            AVPWord.Range rng = oWordDoc.Range(ref start, ref end);
            rng.Select();

            object oTableBehavior = AVPWord.WdDefaultTableBehavior.wdWord9TableBehavior;
            object oFitBehavior = AVPWord.WdAutoFitBehavior.wdAutoFitContent;
            AVPWord.Table oTable = oWordDoc.Tables.Add(oWord.Selection.Range, dizi.Count, dizi[0].Length,
                                                       ref oTableBehavior, ref oFitBehavior);

            for (int i = 1; i <= dizi.Count; i++)
            {
                for (int y = 1; y <= dizi[i - 1].Length; y++)
                {
                    oTable.Cell(i, y).WordWrap = false;
                    oTable.Cell(i, y).Range.Text = dizi[i - 1][y - 1];
                    oTable.Cell(i, y).PreferredWidthType =
                        Microsoft.Office.Interop.Word.WdPreferredWidthType.wdPreferredWidthAuto;
                }
            }

            oTable.PreferredWidthType = Microsoft.Office.Interop.Word.WdPreferredWidthType.wdPreferredWidthAuto;
            for (int i = 1; i <= oTable.Columns.Count; i++)
            {
                oTable.Columns[i].AutoFit();
            }
            object filename = string.Format(@"{0}\{1}.doc", System.IO.Path.GetTempPath().TrimEnd('\\'), "TableTemp");

            this.FilePath = filename.ToString();

            oWordDoc.SaveAs(ref filename, ref oMissing, ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            object savechanges = false;
            object missing = System.Reflection.Missing.Value;

            oWordDoc.Close(ref savechanges, ref oMissing, ref oMissing);
            oWord.ScreenUpdating = true;
            oWord.Quit(ref savechanges, ref oMissing, ref oMissing);
        }

        public Object oMissing = System.Reflection.Missing.Value;

        public string FilePath { get; set; }
    }
}