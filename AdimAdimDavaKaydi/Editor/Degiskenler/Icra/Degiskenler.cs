using AdimAdimDavaKaydi;
using AdimAdimDavaKaydi.Editor.Degiskenler.Klasor;
using AdimAdimDavaKaydi.Editor.Degiskenler.Util;
using AdimAdimDavaKaydi.Generalclass;
using AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge;
using AvukatProDegiskenler.Util;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using Datas.TablesColumn;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TXTextControl;

namespace AvukatProDegiskenler.Icra
{
    public static class Degiskenler
    {
        #region icra kapak de�i�kenleri

        //[ICRA] ACIKLAMA
        public static string GetAciklama(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            return foy.ACIKLAMA;
        }

        //[DAVA] DAVA NEDENLERI
        public static void GetAlacakNedenleri(AV001_TD_BIL_FOY foy, TextControl txControl, TextField field)
        {
            //	TAKIP_DURUMU		        Takip Durumu
            //	ALACAK_NEDENI		        Alacak Nedeni
            //	DUZENLENME_TARIHI	        D�zenleme Tarihi
            //	VADE_TARIHI		            Vade Tarihi
            //	TUTARI		                Tutar�
            //	ISLEME_KONAN_TUTAR	        ��leme Konan Tutar
            //	FAIZ_TIP		            Faiz Tipi
            //	TO_UYGULANACAK_FAIZ_ORANI	Faiz Oran�
            //	FOY_NO	                	Dosya No
            //	ADLIYE	                	M�d�rl�k
            //	NO		                    No
            //	ESAS_NO	                	Esas No
            //	TAKIP_TARIHI		        Takip Tarihi

            //VList<V_PROJE_ALACAK_NEDEN_BILGILERI_TAKIPLI_TAKIPSIZ> alacakNedenleri = EditorDataAraclari.Klasor.GetProjeTumAlacakNedenleriByProjeId(proje.ID);

            if (foy.AV001_TD_BIL_DAVA_NEDENCollection.Count == 0)
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_DAVA_NEDEN>));

            var alacakNedenleri = foy.AV001_TD_BIL_DAVA_NEDENCollection;

            DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.DeepLoad(alacakNedenleri, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_FAIZ_TIP), typeof(ITDI_KOD_DAVA_ADI));
            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                ""
                ,"Dava Nedeni"
                ,"Olay Tarihi"
                ,"Dava Edilen Tutar"
                ,"Faiz Tipi O."
            });

            int sira = 1;
            foreach (var neden in alacakNedenleri)
            {
                try
                {
                    string davaAdi = DataRepository.TDI_KOD_DAVA_ADIProvider.GetByID((int)neden.DAVA_NEDEN_KOD_ID).DAVA_ADI;
                    string YeniDavaNedeni = "";
                    int karSayisi = 0;
                    foreach (char item in davaAdi.ToArray())
                    {
                        karSayisi++;
                        if (karSayisi <= 40)
                            YeniDavaNedeni += item.ToString();
                        else
                        {
                            karSayisi = 0;
                            YeniDavaNedeni += Environment.NewLine + item.ToString();
                        }
                    }

                    listeler.Add(new string[]
                    {
                         sira++.ToString()
                        ,YeniDavaNedeni
                        ,EditorDataAraclari.Tools.TarihBicimlendirme(neden.OLAY_SUC_TARIHI)
                        ,string.Format("{0}",new ParaVeDovizId(neden.DAVA_EDILEN_TUTAR, neden.DAVA_EDILEN_TUTAR_DOVIZ_ID).GetStringValue())
                        ,string.Format("{0} {1}",neden.DO_FAIZ_TIP_IDSource.FAIZ_TIP ,string.Format("%{0}",neden.DO_FAIZ_ORANI))
                    });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetDavaNedenleri", ex);
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        //[ICRA] ALACAK NEDENLERI
        public static void GetAlacakNedenleri(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            //	TAKIP_DURUMU		        Takip Durumu
            //	ALACAK_NEDENI		        Alacak Nedeni
            //	DUZENLENME_TARIHI	        D�zenleme Tarihi
            //	VADE_TARIHI		            Vade Tarihi
            //	TUTARI		                Tutar�
            //	ISLEME_KONAN_TUTAR	        ��leme Konan Tutar
            //	FAIZ_TIP		            Faiz Tipi
            //	TO_UYGULANACAK_FAIZ_ORANI	Faiz Oran�
            //	FOY_NO	                	Dosya No
            //	ADLIYE	                	M�d�rl�k
            //	NO		                    No
            //	ESAS_NO	                	Esas No
            //	TAKIP_TARIHI		        Takip Tarihi

            //VList<V_PROJE_ALACAK_NEDEN_BILGILERI_TAKIPLI_TAKIPSIZ> alacakNedenleri = EditorDataAraclari.Klasor.GetProjeTumAlacakNedenleriByProjeId(proje.ID);

            if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));

            var alacakNedenleri = foy.AV001_TI_BIL_ALACAK_NEDENCollection;

            DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(alacakNedenleri, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_FAIZ_TIP), typeof(TI_KOD_ALACAK_NEDEN));
            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                ""
                ,"Alacak Nedeni"

               // ,"D�zenleme Tarihi"
                ,"Vade Tarihi"
                ,"Tutar - ��.Kon."

                //,"��leme K. Tutar"
                ,"Faiz Tipi O."

                //,"Faiz Oran�"
            });

            int sira = 1;
            foreach (var neden in alacakNedenleri)
            {
                try
                {
                    listeler.Add(new string[]
                    {
                         sira++.ToString()
                        ,neden.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI

                       // ,EditorDataAraclari.Tools.TarihBicimlendirme(neden.DUZENLENME_TARIHI)
                        ,EditorDataAraclari.Tools.TarihBicimlendirme(neden.VADE_TARIHI)
                        ,string.Format("{0} - ({1})",new ParaVeDovizId(neden.TUTARI,neden.TUTAR_DOVIZ_ID).GetStringValue() ,new ParaVeDovizId(neden.ISLEME_KONAN_TUTAR,neden.ISLEME_KONAN_TUTAR_DOVIZ_ID).GetStringValue())
                        ,string.Format("{0} {1}", (neden.TO_ALACAK_FAIZ_TIP_IDSource != null ? neden.TO_ALACAK_FAIZ_TIP_IDSource.FAIZ_TIP : "Yasal Faiz") ,string.Format("%{0}",neden.TO_UYGULANACAK_FAIZ_ORANI))
                    });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetAlacakNedenleri", ex);
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        //efe
        //[ICRA] BOR�LU GEL��MELER�
        public static void GetBorcluGelismeleri(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TI_BIL_FOY_TARAF_GELISMECollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF_GELISME>));

            var borcluGelisme = foy.AV001_TI_BIL_FOY_TARAF_GELISMECollection;

            DataRepository.AV001_TI_BIL_FOY_TARAF_GELISMEProvider.DeepLoad(borcluGelisme, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_FOY_TARAF_GELISME));
            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                 "Bor�lu Ad�"
                ,"Tebligat T."
                ,"Durumu"
                ,"Bila T."
                ,"�tiraz T."
                ,"Kesinle�me T."
                ,"Taahh�t T."
                ,"Haciz T."
                ,"Sat�� T."
                ,"Aciz T."
            });

            //int sira = 1;
            foreach (var bilgi in borcluGelisme)
            {
                string _ILK_TEBLIGAT_TARIHI = (bilgi.ILK_TEBLIGAT_TARIHI.ToString() == "" || bilgi.ILK_TEBLIGAT_TARIHI == null) ? "" : ((DateTime)bilgi.ILK_TEBLIGAT_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.ILK_TEBLIGAT_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.ILK_TEBLIGAT_TARIHI).Year.ToString();

                //string _BILA_TARIHI = (bilgi.BILA_TARIHI.ToString() == "" || bilgi.BILA_TARIHI == null) ? "" : ((DateTime)bilgi.BILA_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.BILA_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.BILA_TARIHI).Year.ToString();

                string _ITIRAZ_TARIHI = (bilgi.ITIRAZ_TARIHI.ToString() == "" || bilgi.ITIRAZ_TARIHI == null) ? "" : ((DateTime)bilgi.ITIRAZ_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.ITIRAZ_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.ITIRAZ_TARIHI).Year.ToString();

                string _KESINLESME_TARIHI = (bilgi.KESINLESME_TARIHI.ToString() == "" || bilgi.KESINLESME_TARIHI == null) ? "" : ((DateTime)bilgi.KESINLESME_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.KESINLESME_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.KESINLESME_TARIHI).Year.ToString();

                string _TAAHHUT_TARIHI = (bilgi.TAAHHUT_TARIHI.ToString() == "" || bilgi.TAAHHUT_TARIHI == null) ? "" : ((DateTime)bilgi.TAAHHUT_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.TAAHHUT_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.TAAHHUT_TARIHI).Year.ToString();

                string _SON_HACIZ_TARIHI = (bilgi.SON_HACIZ_TARIHI.ToString() == "" || bilgi.SON_HACIZ_TARIHI == null) ? "" : ((DateTime)bilgi.SON_HACIZ_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.SON_HACIZ_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.SON_HACIZ_TARIHI).Year.ToString();

                string _SATIS_TARIHI = (bilgi.SATIS_TARIHI.ToString() == "" || bilgi.SATIS_TARIHI == null) ? "" : ((DateTime)bilgi.SATIS_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.SATIS_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.SATIS_TARIHI).Year.ToString();

                string _ACIZ_TARIHI = (bilgi.ACIZ_TARIHI.ToString() == "" || bilgi.ACIZ_TARIHI == null) ? "" : ((DateTime)bilgi.ACIZ_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.ACIZ_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.ACIZ_TARIHI).Year.ToString();

                try
                {
                    listeler.Add(new string[]
                    {
                         EditorDataAraclari.Tools.GetIcraTarafiGetir(bilgi.ICRA_FOY_TARAF_ID)
                        ,_ILK_TEBLIGAT_TARIHI
                        ,bilgi.ILK_TEBLIGAT_TARIHI_DURUMU
                        //,_BILA_TARIHI
                        ,_ITIRAZ_TARIHI
                        ,_KESINLESME_TARIHI
                        ,_TAAHHUT_TARIHI
                        ,_SON_HACIZ_TARIHI
                        ,_SATIS_TARIHI
                        ,_ACIZ_TARIHI
                    });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetBorcluGelismeleri", ex);
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        //efe
        //[ICRA] BOR�LU �DEME B�LG�LER�
        public static void GetBorcluOdemeBilgileri(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TI_BIL_BORCLU_ODEMECollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_ODEME>));

            var borcluOdemeBilgileri = foy.AV001_TI_BIL_BORCLU_ODEMECollection;

            DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepLoad(borcluOdemeBilgileri, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_BORCLU_ODEME));
            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                 "�deme Tarihi"
                ,"�deme Yeri"
                ,"�deme Miktar�"
                ,""
                ,"�deyen"
                ,"�deme Tipi"
            });

            //int sira = 1;
            foreach (var bilgi in borcluOdemeBilgileri)
            {
                try
                {
                    listeler.Add(new string[]
                    {
                         bilgi.ODEME_TARIHI.Day.ToString()+"/"+bilgi.ODEME_TARIHI.Month.ToString()+"/"+bilgi.ODEME_TARIHI.Year.ToString()
                        ,EditorDataAraclari.Tools.GetOdemeYeri(bilgi.ODEME_YER_ID)
                        ,bilgi.ODEME_MIKTAR.HasValue ? bilgi.ODEME_MIKTAR.Value.ToString("#,##0.00"):"0,00"
                        ,EditorDataAraclari.Tools.GetDovizTipi(bilgi.ODEME_MIKTAR_DOVIZ_ID)
                        ,EditorDataAraclari.Tools.GetCari(bilgi.ODEYEN_CARI_ID)
                        ,EditorDataAraclari.Tools.GetOdemeTipi(bilgi.ODEME_TIP_ID)
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

        //efe
        //[ICRA] BOR�LU TAAHH�TLER�
        public static void GetBorcluTaahhutleri(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>));

            var borcluTaahhut = foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection;

            DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepLoad(borcluTaahhut, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_BORCLU_TAAHHUT_MASTER));
            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                 "S�ra"
                ,"Bor�lu"
                ,"Taahh�t T."
                ,"Kabul T."
                ,"�hlal T."
                ,"Dava"
            });

            //int sira = 1;
            foreach (var bilgi in borcluTaahhut)
            {
                string _TAAHHUT_TARIHI = (bilgi.TAAHHUT_TARIHI.ToString() == "" || bilgi.TAAHHUT_TARIHI == null) ? "" : ((DateTime)bilgi.TAAHHUT_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.TAAHHUT_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.TAAHHUT_TARIHI).Year.ToString();

                string _TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI = (bilgi.TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.ToString() == "" || bilgi.TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI == null) ? "" : ((DateTime)bilgi.TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI).Year.ToString();

                string _TAAHHUT_IHLAL_TARIHI = (bilgi.TAAHHUT_IHLAL_TARIHI.ToString() == "" || bilgi.TAAHHUT_IHLAL_TARIHI == null) ? "" : ((DateTime)bilgi.TAAHHUT_IHLAL_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.TAAHHUT_IHLAL_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.TAAHHUT_IHLAL_TARIHI).Year.ToString();

                try
                {
                    listeler.Add(new string[]
                    {
                         bilgi.TAAHHUT_SIRA_NO.ToString()
                        ,EditorDataAraclari.Tools.GetCari(bilgi.TAAHHUT_EDEN_ID)
                        ,_TAAHHUT_TARIHI
                        ,_TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI
                        ,_TAAHHUT_IHLAL_TARIHI
                        ,bilgi.DAVASI_VAR_MI?"Var":"Yok"
                    });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetBorcluTaahhutleri", ex);
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        public static void GetDAVA_Dava_Hukum_Bilgisi(AV001_TD_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TD_BIL_MAHKEME_HUKUMCollection.Count == 0)
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_MAHKEME_HUKUM>));

            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                 "Dava Nedeni"
                ,"H�k�m T."
                ,"Karar No"
                ,"H�k�m"
                ,"H�k�m De�er"
                ,"Taraf"
            });

            //int sira = 1;
            foreach (var bilgi in foy.AV001_TD_BIL_MAHKEME_HUKUMCollection)
            {
                try
                {
                    string davaAdi = DataRepository.TDI_KOD_DAVA_ADIProvider.GetByID(DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.GetByID((int)bilgi.DAVA_NEDEN_ID).DAVA_NEDEN_KOD_ID.Value).DAVA_ADI;
                    string YeniDavaNedeni = "";
                    int karSayisi = 0;
                    foreach (char item in davaAdi.ToArray())
                    {
                        karSayisi++;
                        if (karSayisi <= 30)
                            YeniDavaNedeni += item.ToString();
                        else
                        {
                            karSayisi = 0;
                            YeniDavaNedeni += Environment.NewLine + item.ToString();
                        }
                    }

                    string hukum = DataRepository.TD_KOD_MAHKEME_HUKUMProvider.GetByID((int)bilgi.HUKUM_ID).HUKUM;

                    string YeniHukum = "";
                    karSayisi = 0;
                    foreach (char item in hukum.ToArray())
                    {
                        karSayisi++;
                        if (karSayisi <= 30)
                            YeniHukum += item.ToString();
                        else
                        {
                            karSayisi = 0;
                            YeniHukum += Environment.NewLine + item.ToString();
                        }
                    }

                    listeler.Add(new string[]
                    {
                         YeniDavaNedeni
                        ,bilgi.HUKUM_TARIHI.ToShortDateString()
                        ,bilgi.KARAR_NO
                        ,YeniHukum
                        ,string.Format("{0}",new ParaVeDovizId(bilgi.HUKUM_DEGER, bilgi.HUKUM_DEGER_DOVIZ_ID).GetStringValue())
                        ,DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(bilgi.TARAF_CARI_ID.Value).AD
                    });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetIhtiyatiTedbirBilgisi", ex);
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        public static void GetDAVA_Dava_Hukum_Bilgisi_Ceza(AV001_TD_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TD_BIL_MAHKEME_HUKUMCollection.Count == 0)
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_MAHKEME_HUKUM>));

            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                 "Dava Nedeni"
                ,"H�k�m T."
                ,"Karar No"
                ,"H�k�m"
                ,"H�k�m Tip"
                ,"Par. �ev. Ceza"
                ,"Taraf"
            });

            //int sira = 1;
            foreach (var bilgi in foy.AV001_TD_BIL_MAHKEME_HUKUMCollection)
            {
                try
                {
                    string davaAdi = DataRepository.TDI_KOD_DAVA_ADIProvider.GetByID(DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.GetByID((int)bilgi.DAVA_NEDEN_ID).DAVA_NEDEN_KOD_ID.Value).DAVA_ADI;
                    string YeniDavaNedeni = "";
                    int karSayisi = 0;
                    foreach (char item in davaAdi.ToArray())
                    {
                        karSayisi++;
                        if (karSayisi <= 30)
                            YeniDavaNedeni += item.ToString();
                        else
                        {
                            karSayisi = 0;
                            YeniDavaNedeni += Environment.NewLine + item.ToString();
                        }
                    }

                    string hukum = "";
                    string YeniHukum = "";

                    if (bilgi.HUKUM_ID != null)
                    {
                        hukum = DataRepository.TD_KOD_MAHKEME_HUKUMProvider.GetByID((int)bilgi.HUKUM_ID).HUKUM;
                        karSayisi = 0;
                        foreach (char item in hukum.ToArray())
                        {
                            karSayisi++;
                            if (karSayisi <= 30)
                                YeniHukum += item.ToString();
                            else
                            {
                                karSayisi = 0;
                                YeniHukum += Environment.NewLine + item.ToString();
                            }
                        }
                    }

                    string hukumtip = "";
                    string YeniHukumTip = "";
                    if (bilgi.HUKUM_TIP_ID.HasValue)
                    {
                        hukumtip = DataRepository.TD_KOD_MAHKEME_HUKUM_TIPProvider.GetByID((int)bilgi.HUKUM_TIP_ID).HUKUM_TIP;
                        karSayisi = 0;
                        foreach (char item in hukumtip.ToArray())
                        {
                            karSayisi++;
                            if (karSayisi <= 30)
                                YeniHukumTip += item.ToString();
                            else
                            {
                                karSayisi = 0;
                                YeniHukumTip += Environment.NewLine + item.ToString();
                            }
                        }
                    }

                    listeler.Add(new string[]
                    {
                         YeniDavaNedeni
                        ,bilgi.HUKUM_TARIHI.ToShortDateString()
                        ,bilgi.KARAR_NO
                        ,YeniHukum
                        ,YeniHukumTip
                        ,string.Format("{0}",new ParaVeDovizId(bilgi.PARAYA_CEVRILEN_MIKTAR, bilgi.PARAYA_CEVRILEN_MIKTAR_DOVIZ_ID).GetStringValue())
                        ,DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(bilgi.TARAF_CARI_ID.Value).AD
                    });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetIhtiyatiTedbirBilgisi", ex);
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        public static void GetDAVA_Dava_Iliskili_Dosyalar(AV001_TD_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TDI_BIL_KAYIT_ILISKICollection.Count == 0)
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI>));

            if (foy.AV001_TDI_BIL_KAYIT_ILISKICollection.Count > 0)
                DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.DeepLoad(foy.AV001_TDI_BIL_KAYIT_ILISKICollection[0], false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>));

            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                 "Dosya No"
                ,"Konu"
                ,"Adliye/No/G�rev"
                ,"Esas No"
                ,"Tarihi"
                ,"�li�kisi"
                ,"Aciklama"
            });

            if (foy.AV001_TDI_BIL_KAYIT_ILISKICollection.Count > 0)
            {
                foreach (var iliski in foy.AV001_TDI_BIL_KAYIT_ILISKICollection)
                {
                    foreach (var bilgi in iliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection)
                    {
                        try
                        {
                            string YeniAciklama = "";
                            int karSayisi = 0;
                            foreach (char item in bilgi.ACIKLAMA.ToArray())
                            {
                                karSayisi++;
                                if (karSayisi <= 30)
                                    YeniAciklama += item.ToString();
                                else
                                {
                                    karSayisi = 0;
                                    YeniAciklama += Environment.NewLine + item.ToString();
                                }
                            }

                            listeler.Add(new string[]
                    {
                         bilgi.HEDEF_FOY_NO
                        ,bilgi.HEDEF_DOSYA_TALEP
                        ,EditorDataAraclari.Tools.GetMahkeme(bilgi.HEDEF_ADLI_BIRIM_ADLIYE_ID) + " " + EditorDataAraclari.Tools.GetAdliBirimNo(bilgi.HEDEF_ADLI_BIRIM_NO_ID) + " " + EditorDataAraclari.Tools.GetAdliBirimGorev(bilgi.HEDEF_ADLI_BIRIM_GOREV_ID)
                        ,bilgi.HEDEF_ESAS_NO
                        ,bilgi.HEDEF_DOSYA_TARIHI.Value.ToShortDateString()
                        ,DataRepository.TDI_KOD_KAYIT_ILISKI_NEDENProvider.GetByID(bilgi.ILISKI_NEDEN_ID.Value).ILISKI_NEDEN
                        ,YeniAciklama
                    });
                        }
                        catch (Exception ex)
                        {
                            BelgeUtil.ErrorHandler.Catch("GetIhtiyatiTedbirBilgisi", ex);
                        }
                    }
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        public static void GetDAVA_Dava_Temyiz_Bilgisi(AV001_TD_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TD_BIL_TEMYIZCollection.Count == 0)
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_TEMYIZ>));

            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                 "Temyiz T."
                ,"Temyiz Eden"
                ,"Dava Nedeni"
                ,"Y�ksek Mahkeme"
                ,"Esas No"
                ,"Karar No"
                ,"Karar T."
                ,"H�k�m"
            });

            //int sira = 1;
            foreach (var bilgi in foy.AV001_TD_BIL_TEMYIZCollection)
            {
                try
                {
                    AV001_TD_BIL_TEMYIZ_TARAF trf = DataRepository.AV001_TD_BIL_TEMYIZ_TARAFProvider.GetByTEMYIZ_ID(bilgi.ID)[0];

                    string davaAdi = "";
                    if (bilgi.MAHKEME_HUKUM_ID.HasValue)
                        davaAdi = DataRepository.TDI_KOD_DAVA_ADIProvider.GetByID(DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.GetByID(DataRepository.AV001_TD_BIL_MAHKEME_HUKUMProvider.GetByID(bilgi.MAHKEME_HUKUM_ID.Value).DAVA_NEDEN_ID).DAVA_NEDEN_KOD_ID.Value).DAVA_ADI;
                    string YeniDavaNedeni = "";
                    int karSayisi = 0;
                    foreach (char item in davaAdi.ToArray())
                    {
                        karSayisi++;
                        if (karSayisi <= 20)
                            YeniDavaNedeni += item.ToString();
                        else
                        {
                            karSayisi = 0;
                            YeniDavaNedeni += Environment.NewLine + item.ToString();
                        }
                    }

                    listeler.Add(new string[]
                    {
                        trf.TEMYIZ_TARIHI.HasValue ? trf.TEMYIZ_TARIHI.Value.ToShortDateString() : ""
                        ,DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(trf.CARI_ID.Value).AD
                        ,YeniDavaNedeni
                        , bilgi.ADLI_BIRIM_ADLIYE_ID.HasValue ? EditorDataAraclari.Tools.GetMahkeme(bilgi.ADLI_BIRIM_ADLIYE_ID) + " " + EditorDataAraclari.Tools.GetAdliBirimNo(bilgi.ADLI_BIRIM_NO_ID) + " " + EditorDataAraclari.Tools.GetAdliBirimGorev(bilgi.ADLI_BIRIM_GOREV_ID) : ""
                        ,bilgi.ESAS_NO
                        ,bilgi.KARAR_NO
                        ,bilgi.KARAR_TARIHI.HasValue ? bilgi.KARAR_TARIHI.Value.ToShortDateString() : ""
                        ,bilgi.KARAR_TIP_ID.HasValue ? DataRepository.TD_KOD_YUKSEK_MAHKEME_KARAR_TIPProvider.GetByID(bilgi.KARAR_TIP_ID.Value).KARAR_TIP : ""
                    });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetIhtiyatiTedbirBilgisi", ex);
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        //[DAVA] DAVA �DAR� ��LEM
        public static void GetDava_IdariIslem(AV001_TD_BIL_FOY foy, TextControl txControl, TextField field)
        {
            //	TAKIP_DURUMU		        Takip Durumu
            //	ALACAK_NEDENI		        Alacak Nedeni
            //	DUZENLENME_TARIHI	        D�zenleme Tarihi
            //	VADE_TARIHI		            Vade Tarihi
            //	TUTARI		                Tutar�
            //	ISLEME_KONAN_TUTAR	        ��leme Konan Tutar
            //	FAIZ_TIP		            Faiz Tipi
            //	TO_UYGULANACAK_FAIZ_ORANI	Faiz Oran�
            //	FOY_NO	                	Dosya No
            //	ADLIYE	                	M�d�rl�k
            //	NO		                    No
            //	ESAS_NO	                	Esas No
            //	TAKIP_TARIHI		        Takip Tarihi

            //VList<V_PROJE_ALACAK_NEDEN_BILGILERI_TAKIPLI_TAKIPSIZ> alacakNedenleri = EditorDataAraclari.Klasor.GetProjeTumAlacakNedenleriByProjeId(proje.ID);

            if (foy.AV001_TD_BIL_DAVA_NEDENCollection.Count == 0)
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_DAVA_NEDEN>));

            var alacakNedenleri = foy.AV001_TD_BIL_DAVA_NEDENCollection;

            DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.DeepLoad(alacakNedenleri, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_FAIZ_TIP), typeof(ITDI_KOD_DAVA_ADI));
            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                ""
                ,"Dava Nedeni"
                ,"Tebell�� T."
                ,"��lem Konusu"
                ,"Dava Tutar�"
            });

            int sira = 1;
            foreach (var neden in alacakNedenleri)
            {
                try
                {
                    string davaAdi = DataRepository.TDI_KOD_DAVA_ADIProvider.GetByID((int)neden.DAVA_NEDEN_KOD_ID).DAVA_ADI;
                    string YeniDavaNedeni = "";
                    int karSayisi = 0;
                    foreach (char item in davaAdi.ToArray())
                    {
                        karSayisi++;
                        if (karSayisi <= 35)
                            YeniDavaNedeni += item.ToString();
                        else
                        {
                            karSayisi = 0;
                            YeniDavaNedeni += Environment.NewLine + item.ToString();
                        }
                    }

                    string YeniIslemKonusu = "";
                    karSayisi = 0;
                    foreach (char item in neden.TAKIP_ISLEM_SEKLI.ToArray())
                    {
                        karSayisi++;
                        if (karSayisi <= 40)
                            YeniIslemKonusu += item.ToString();
                        else
                        {
                            karSayisi = 0;
                            YeniIslemKonusu += Environment.NewLine + item.ToString();
                        }
                    }

                    listeler.Add(new string[]
                    {
                         sira++.ToString()
                        ,YeniDavaNedeni
                        ,EditorDataAraclari.Tools.TarihBicimlendirme(neden.TEBELLUG_TARIHI)
                        ,YeniIslemKonusu
                        ,string.Format("{0}",new ParaVeDovizId(neden.DAVA_EDILEN_TUTAR, neden.DAVA_EDILEN_TUTAR_DOVIZ_ID).GetStringValue())
                    });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetDavaNedenleri", ex);
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        //[ICRA] FORM TIPI
        public static string GetFormTipi(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.FORM_TIP_IDSource == null)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TI_KOD_FORM_TIP));

            if (foy.FORM_TIP_IDSource != null)
                return string.Format("{0} {1}", foy.FORM_TIP_IDSource.FORM_ORNEK_NO, foy.FORM_TIP_IDSource.FORM_ADI);

            return string.Empty;
        }

        //efe
        //[ICRA] HAC�Z B�LG�LER�
        public static void GetHacizBilgileri(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TI_BIL_HACIZ_MASTERCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_HACIZ_MASTER>));

            var hacizBilgileri = foy.AV001_TI_BIL_HACIZ_MASTERCollection;

            DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.DeepLoad(hacizBilgileri, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_FAIZ_TIP), typeof(AV001_TI_BIL_HACIZ_MASTER));
            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                 "Haciz Tarihi"
                ,"Saati"
                ,"Bor�lu"
                ,"��lem Durumu"
                ,"A��klama"
            });

            //int sira = 1;
            foreach (var bilgi in hacizBilgileri)
            {
                try
                {
                    listeler.Add(new string[]
                    {
                        //,bilgi.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI

                       // ,EditorDataAraclari.Tools.TarihBicimlendirme(neden.DUZENLENME_TARIHI)
                         bilgi.HACIZ_TARIHI.Day.ToString()+"/"+bilgi.HACIZ_TARIHI.Month.ToString()+"/"+bilgi.HACIZ_TARIHI.Year.ToString()
                        ,bilgi.HACIZ_SAATI.ToString()
                        ,EditorDataAraclari.Tools.GetCari(bilgi.HACIZ_ISTENEN_CARI_ID)
                        //,new ParaVeDovizId((bilgi.HACIZ_TOPLAM_DEGERI,bilgi.HACIZ_TOPLAM_DEGERI_DOVIZ_ID).GetStringValue())
                        ,bilgi.MUHAFAZALI_KAYIT_VAR_MI?"Muhafaza Var":"Muhafaza Yok"
                        ,bilgi.HACIZ_ACIKLAMA
                        //,string.Format("{0} - ({1})",new ParaVeDovizId(bilgi.TUTARI,bilgi.TUTAR_DOVIZ_ID).GetStringValue()
                        //,new ParaVeDovizId(bilgi.ISLEME_KONAN_TUTAR,bilgi.ISLEME_KONAN_TUTAR_DOVIZ_ID).GetStringValue())
                        //,string.Format("{0} {1}",bilgi.TO_ALACAK_FAIZ_TIP_IDSource.FAIZ_TIP ,string.Format("%{0}",bilgi.TO_UYGULANACAK_FAIZ_ORANI))
                    });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetHacizBilgileri", ex);
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        //[ICRA] HESAP DETAYLARI1 - Icra_Hesap_Detaylari_1
        public static void GetHesapDetaylari1(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            /*
            As�l Alacak       :
            ��lemi� Faiz       :
            BSMV              :
            KKDF              :
            �H Vek �creti   :
            �H Giderleri       :
            �zel Tutarlar    :
            T� �deme        :
            Mahsup             :
            Takip ��k���      :
             */

            string result = string.Empty;

            var ihVekUcreti = ParaVeDovizId.Topla(
                new ParaVeDovizId(foy.IH_GIDERI, foy.IH_GIDERI_DOVIZ_ID),
                new ParaVeDovizId(foy.IH_VEKALET_UCRETI, foy.IH_VEKALET_UCRETI_DOVIZ_ID));

            var ozelTutarlar = ParaVeDovizId.Topla(
                new ParaVeDovizId(foy.OZEL_TUTAR1, foy.OZEL_TUTAR1_DOVIZ_ID),
                new ParaVeDovizId(foy.OZEL_TUTAR2, foy.OZEL_TUTAR2_DOVIZ_ID),
                new ParaVeDovizId(foy.OZEL_TUTAR3, foy.OZEL_TUTAR3_DOVIZ_ID),
                new ParaVeDovizId(foy.OZEL_TAZMINAT, foy.OZEL_TAZMINAT_DOVIZ_ID));

            var ilamvekalet = ParaVeDovizId.Topla(
               new ParaVeDovizId(foy.ILAM_VEK_UCR, foy.ILAM_VEK_UCR_DOVIZ_ID));

            var ilamGideri = ParaVeDovizId.Topla(
               new ParaVeDovizId(foy.ILAM_INKAR_TAZMINATI, foy.ILAM_INKAR_TAZMINATI_DOVIZ_ID),
               new ParaVeDovizId(foy.ILAM_YARGILAMA_GIDERI, foy.ILAM_YARGILAMA_GIDERI_DOVIZ_ID),
               new ParaVeDovizId(foy.ILAM_BK_YARG_ONAMA, foy.ILAM_BK_YARG_ONAMA_DOVIZ_ID),
               new ParaVeDovizId(foy.ILAM_TEBLIG_GIDERI, foy.ILAM_TEBLIG_GIDERI_DOVIZ_ID));

            var ihtiyatitedbir = ParaVeDovizId.Topla(
               new ParaVeDovizId(foy.IT_GIDERI, foy.IT_GIDERI_DOVIZ_ID),
               new ParaVeDovizId(foy.IT_VEKALET_UCRETI, foy.IT_VEKALET_UCRETI_DOVIZ_ID));

            var cektazminati = ParaVeDovizId.Topla(
               new ParaVeDovizId(foy.KARSILIKSIZ_CEK_TAZMINATI, foy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID));

            var komisyon = ParaVeDovizId.Topla(
               new ParaVeDovizId(foy.CEK_KOMISYONU, foy.CEK_KOMISYONU_DOVIZ_ID));

            var kdv = ParaVeDovizId.Topla(
               new ParaVeDovizId(foy.KDV_TO, foy.KDV_TO_DOVIZ_ID));

            var oiv = ParaVeDovizId.Topla(
               new ParaVeDovizId(foy.OIV_TO, foy.OIV_TO_DOVIZ_ID));

            //new ParaVeDovizId(foy.OZEL_TUTAR4, foy.OZEL_TUTAR4_DOVIZ_ID));

            Dictionary<string, string> sozluk = new Dictionary<string, string>();

            if (foy.ASIL_ALACAK != 0 & foy.ASIL_ALACAK != null)
                sozluk.Add("As�l Alacak", new ParaVeDovizId(foy.ASIL_ALACAK, foy.ASIL_ALACAK_DOVIZ_ID).GetStringValue());

            if (foy.ISLEMIS_FAIZ != 0 & foy.ISLEMIS_FAIZ != null)
                sozluk.Add("��lemi� Faiz", new ParaVeDovizId(foy.ISLEMIS_FAIZ, foy.ISLEMIS_FAIZ_DOVIZ_ID).GetStringValue());

            if (foy.BSMV_TO != 0 & foy.BSMV_TO != null)
                sozluk.Add("BSMV", new ParaVeDovizId(foy.BSMV_TO, foy.BSMV_TO_DOVIZ_ID).GetStringValue());

            if (foy.KKDV_TO != 0 & foy.KKDV_TO != null)
                sozluk.Add("KKDF", new ParaVeDovizId(foy.KKDV_TO, foy.KKDV_TO_DOVIZ_ID).GetStringValue());

            if (kdv.Para != 0 & kdv.Para != null)
                sozluk.Add("KDV", kdv.GetStringValue());

            if (oiv.Para != 0 & oiv.Para != null)
                sozluk.Add("OIV", oiv.GetStringValue());

            if (ihVekUcreti.Para != 0 & ihVekUcreti.Para != null)
                sozluk.Add("�H Vek �creti/Gideri", ihVekUcreti.GetStringValue());

            if (ilamvekalet.Para != 0 & ilamvekalet.Para != null)
                sozluk.Add("�lam Vek �creti", ilamvekalet.GetStringValue());

            if (ilamGideri.Para != 0 & ilamGideri.Para != null)
                sozluk.Add("�lam Gideri", ilamGideri.GetStringValue());

            if (ihtiyatitedbir.Para != 0 & ihtiyatitedbir.Para != null)
                sozluk.Add("�T Vek �creti/Gideri", ihtiyatitedbir.GetStringValue());

            if (ozelTutarlar.Para != 0 & ozelTutarlar.Para != null)
                sozluk.Add("�zel Tutarlar", ozelTutarlar.GetStringValue());

            if (cektazminati.Para != 0 & cektazminati.Para != null)
                sozluk.Add("�ek Tazminat�", cektazminati.GetStringValue());

            if (komisyon.Para != 0 & komisyon.Para != null)
                sozluk.Add("Komisyon", komisyon.GetStringValue());

            if (foy.TO_ODEME_TOPLAMI != 0 & foy.TO_ODEME_TOPLAMI != null)
                sozluk.Add("T� �deme", new ParaVeDovizId(foy.TO_ODEME_TOPLAMI, foy.TO_ODEME_TOPLAMI_DOVIZ_ID).GetStringValue());

            if (foy.MAHSUP_TOPLAMI != 0 & foy.MAHSUP_TOPLAMI != null)
                sozluk.Add("Mahsup", new ParaVeDovizId(foy.MAHSUP_TOPLAMI, foy.MAHSUP_TOPLAMI_DOVIZ_ID).GetStringValue());

            if (foy.TAKIP_CIKISI != 0 & foy.TAKIP_CIKISI != null)
                sozluk.Add("Takip ��k���", new ParaVeDovizId(foy.TAKIP_CIKISI, foy.TAKIP_CIKISI_DOVIZ_ID).GetStringValue());

            field.Text = " ";

            txControl.Select(field.Start, 0);

            if (txControl.Tables.Add(sozluk.Count, 2, 5600))
            {
                var enume = sozluk.GetEnumerator();
                int sira = 1;
                while (enume.MoveNext())
                {
                    //Ba�l�k
                    var baslikCell = txControl.Tables.GetItem(5600).Cells.GetItem(sira, 1);

                    baslikCell.Text = enume.Current.Key;
                    baslikCell.Select();
                    txControl.Selection.Bold = true;

                    //De�er
                    var degerCell = txControl.Tables.GetItem(5600).Cells.GetItem(sira, 2);
                    degerCell.Text = enume.Current.Value;
                    degerCell.Select();
                    txControl.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Right;
                    txControl.Selection.Bold = false;

                    ++sira;
                }
            }
        }

        //[ICRA] HESAP DETAYLARI2
        public static void GetHesapDetaylari2(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            /*
                Sonraki Faiz    :
                KKDF            :
                �lk Giderler    :
                Di�er Gider     :
                Takip Vek �c    :
                Dava Gideri     :
                Dava Vek �c     :
                Alacak          :
                Feragat Topl    :
                �deme Topl      :
                Kalan           :
             */
            field.Text = " ";
            txControl.Select(field.Start, 0);

            Dictionary<string, string> sozluk = new Dictionary<string, string>();

            if (foy.SONRAKI_FAIZ != 0 & foy.SONRAKI_FAIZ != null)
                sozluk.Add("Sonraki Faiz", new ParaVeDovizId(foy.SONRAKI_FAIZ, foy.SONRAKI_FAIZ_DOVIZ_ID).GetStringValue());

            if (foy.BSMV_TS != 0 & foy.BSMV_TS != null)
                sozluk.Add("BSMV", new ParaVeDovizId(foy.BSMV_TS, foy.BSMV_TS_DOVIZ_ID).GetStringValue());

            if (foy.KDV_TS != 0 & foy.KDV_TS != null)
                sozluk.Add("KDV", new ParaVeDovizId(foy.KDV_TS, foy.KDV_TS_DOVIZ_ID).GetStringValue());

            if (foy.OIV_TS != 0 & foy.OIV_TS != null)
                sozluk.Add("OIV", new ParaVeDovizId(foy.OIV_TS, foy.OIV_TS_DOVIZ_ID).GetStringValue());

            if (foy.ILK_GIDERLER != 0 & foy.ILK_GIDERLER != null)
                sozluk.Add("�lk Giderler", new ParaVeDovizId(foy.ILK_GIDERLER, foy.ILK_GIDERLER_DOVIZ_ID).GetStringValue());

            if (foy.DIGER_GIDERLER != 0 & foy.DIGER_GIDERLER != null)
                sozluk.Add("Di�er Gider", new ParaVeDovizId(foy.DIGER_GIDERLER, foy.DIGER_GIDERLER_DOVIZ_ID).GetStringValue());

            if (foy.TS_VEKALET_TOPLAMI != 0 & foy.TS_VEKALET_TOPLAMI != null)
                sozluk.Add("Toplam Vek �c", new ParaVeDovizId(foy.TS_VEKALET_TOPLAMI, foy.TS_VEKALET_TOPLAMI_DOVIZ_ID).GetStringValue());

            if (foy.DAVA_GIDERLERI != 0 & foy.DAVA_GIDERLERI != null)
                sozluk.Add("Dava Gideri", new ParaVeDovizId(foy.DAVA_GIDERLERI, foy.DAVA_GIDERLERI_DOVIZ_ID).GetStringValue());

            if (foy.DAVA_VEKALET_UCRETI != 0 & foy.DAVA_VEKALET_UCRETI != null)
                sozluk.Add("Dava Vek �c", new ParaVeDovizId(foy.DAVA_VEKALET_UCRETI, foy.DAVA_VEKALET_UCRETI_DOVIZ_ID).GetStringValue());

            if (foy.HARC_TOPLAMI != 0 & foy.HARC_TOPLAMI != null)
                sozluk.Add("Har� Toplam�", new ParaVeDovizId(foy.HARC_TOPLAMI, foy.HARC_TOPLAMI_DOVIZ_ID).GetStringValue());

            if (foy.BAKIYE_HARC_TOPLAMA_EKLE)
            {
                if (foy.KALAN_TAHSIL_HARCI != 0 & foy.KALAN_TAHSIL_HARCI != null)
                    sozluk.Add("Bakiye Har�", new ParaVeDovizId(foy.KALAN_TAHSIL_HARCI, foy.KALAN_TAHSIL_HARCI_DOVIZ_ID).GetStringValue());
            }

            //Sonraki �demeler (-) i�areti ile,
            //Takip Sonras� Masraf Toplam� (�lk Giderler yerine)
            //Vekalet Toplam� (Takip Vekalet �creti yerine)

            if (foy.FERAGAT_TOPLAMI != 0 & foy.FERAGAT_TOPLAMI != null)
                sozluk.Add("Feragat Topl", new ParaVeDovizId(foy.FERAGAT_TOPLAMI, foy.FERAGAT_TOPLAMI_DOVIZ_ID).GetStringValue());

            if (foy.ODEME_TOPLAMI != 0 & foy.ODEME_TOPLAMI != null)
                sozluk.Add("�deme Topl", new ParaVeDovizId(foy.ODEME_TOPLAMI, foy.ODEME_TOPLAMI_DOVIZ_ID).GetStringValue());

            sozluk.Add("", " ");
            if (foy.KALAN != 0 & foy.KALAN != null)
                sozluk.Add("Kalan", new ParaVeDovizId(foy.KALAN, foy.KALAN_DOVIZ_ID).GetStringValue());

            if (txControl.Tables.Add(sozluk.Count, 2, 5700))
            {
                var enume = sozluk.GetEnumerator();
                int sira = 1;
                while (enume.MoveNext())
                {
                    //Ba�l�k
                    var baslikCell = txControl.Tables.GetItem(5700).Cells.GetItem(sira, 1);

                    baslikCell.Text = enume.Current.Key;
                    baslikCell.Select();
                    txControl.Selection.Bold = true;

                    //De�er
                    var degerCell = txControl.Tables.GetItem(5700).Cells.GetItem(sira, 2);
                    degerCell.Text = enume.Current.Value;
                    degerCell.Select();
                    txControl.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Right;
                    txControl.Selection.Bold = false;

                    ++sira;
                }
            }
        }

        //[ICRA] HESAP DETAYLARI3
        public static void GetHesapDetaylari3(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            string result = string.Empty;

            string faizTipi = string.Empty;
            string faizOrani = string.Empty;

            var faizTipOranlari = EditorDataAraclari.Icra.GetFaizTipVeOranlarById(foy.ID);
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

            if (foy.GAYRI_NAKTI_ALACAK != 0 & foy.GAYRI_NAKTI_ALACAK != null)
                sozluk.Add("Gayri Nakit Top", new ParaVeDovizId(foy.GAYRI_NAKTI_ALACAK, foy.GAYRI_NAKTI_ALACAK_DOVIZ_ID).GetStringValue());

            if (foy.DEPO_VEKALET_UCRETI != 0 & foy.GAYRI_NAKTI_ALACAK != null)
                sozluk.Add("Gayri Nak�t V �cr", new ParaVeDovizId(foy.DEPO_VEKALET_UCRETI, foy.DEPO_VEKALET_UCRET_DOVIZ_ID).GetStringValue());

            if (foy.DEPO_HARCI != 0 & foy.GAYRI_NAKTI_ALACAK != null)
                sozluk.Add("Gayri Nak Har�", new ParaVeDovizId(foy.DEPO_HARCI, foy.DEPO_HARCI_DOVIZ_ID).GetStringValue());

            sozluk.Add("", "");
            sozluk.Add("Faiz Oran�", faizOrani); //projeye ba�l� alacak nedenlerinin �zerinde birbirinden farkl� faiz oranlar� ve tipleri varsa yazm�yoruz yoksa yaz�yoruz
            sozluk.Add("Faiz Tipi", faizTipi);

            //string.Format(@"Hesap Tipi          : {0}","");

            if (txControl.Tables.Add(sozluk.Count, 2, 5800))
            {
                var enume = sozluk.GetEnumerator();
                int sira = 1;
                while (enume.MoveNext())
                {
                    //Ba�l�k
                    var baslikCell = txControl.Tables.GetItem(5800).Cells.GetItem(sira, 1);

                    baslikCell.Text = enume.Current.Key;
                    baslikCell.Select();
                    txControl.Selection.Bold = true;

                    //De�er
                    var degerCell = txControl.Tables.GetItem(5800).Cells.GetItem(sira, 2);
                    degerCell.Text = enume.Current.Value;
                    degerCell.Select();
                    txControl.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Right;
                    txControl.Selection.Bold = false;

                    ++sira;
                }
            }
        }

        public static void GetICRA_Icra_Iliskili_Dosyalar(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TDI_BIL_KAYIT_ILISKICollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI>));

            if (foy.AV001_TDI_BIL_KAYIT_ILISKICollection.Count > 0)
                DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.DeepLoad(foy.AV001_TDI_BIL_KAYIT_ILISKICollection[0], false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>));

            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                 "Dosya No"
                ,"Konu"
                ,"Adliye/No/G�rev"
                ,"Esas No"
                ,"Tarihi"
                ,"�li�kisi"
                ,"Aciklama"
            });

            if (foy.AV001_TDI_BIL_KAYIT_ILISKICollection.Count > 0)
            {
                foreach (var iliski in foy.AV001_TDI_BIL_KAYIT_ILISKICollection)
                {
                    foreach (var bilgi in iliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection)
                    {
                        try
                        {
                            string YeniAciklama = "";
                            int karSayisi = 0;
                            foreach (char item in bilgi.ACIKLAMA.ToArray())
                            {
                                karSayisi++;
                                if (karSayisi <= 30)
                                    YeniAciklama += item.ToString();
                                else
                                {
                                    karSayisi = 0;
                                    YeniAciklama += Environment.NewLine + item.ToString();
                                }
                            }

                            listeler.Add(new string[]
                    {
                         bilgi.HEDEF_FOY_NO
                        ,bilgi.HEDEF_DOSYA_TALEP
                        ,EditorDataAraclari.Tools.GetMahkeme(bilgi.HEDEF_ADLI_BIRIM_ADLIYE_ID) + " " + EditorDataAraclari.Tools.GetAdliBirimNo(bilgi.HEDEF_ADLI_BIRIM_NO_ID) + " " + EditorDataAraclari.Tools.GetAdliBirimGorev(bilgi.HEDEF_ADLI_BIRIM_GOREV_ID)
                        ,bilgi.HEDEF_ESAS_NO
                        ,bilgi.HEDEF_DOSYA_TARIHI.Value.ToShortDateString()
                        ,bilgi.ILISKI_NEDEN_ID == null ? "" : DataRepository.TDI_KOD_KAYIT_ILISKI_NEDENProvider.GetByID(bilgi.ILISKI_NEDEN_ID.Value).ILISKI_NEDEN
                        ,YeniAciklama
                    });
                        }
                        catch (Exception ex)
                        {
                            BelgeUtil.ErrorHandler.Catch("GetIhtiyatiTedbirBilgisi", ex);
                        }
                    }
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        //efe
        //[ICRA] �HT�YAT� HAC�Z B�LG�S�
        public static void GetIhtiyatiHacizBilgisi(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            try
            {
                if (foy.AV001_TI_BIL_IHTIYATI_HACIZCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ>));

                var ihtiyatiHacizBilgisi = foy.AV001_TI_BIL_IHTIYATI_HACIZCollection;

                DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.DeepLoad(ihtiyatiHacizBilgisi, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_IHTIYATI_HACIZ));
                List<string[]> listeler = new List<string[]>();

                listeler.Add(new string[]
            {
                 "Mahkeme"
                ,"No:"
                ,"G�rev"
                ,"D. �� No:"
                ,"Talep T."
                ,"Karar No:"
                ,"Karar T."
                ,"Teminat"
                ,""
                ,"Tem. �ade T."
            });

                //int sira = 1;
                foreach (var bilgi in ihtiyatiHacizBilgisi)
                {
                    string _TALEP_TARIHI = (bilgi.TALEP_TARIHI.ToString() == "" || bilgi.TALEP_TARIHI == null) ? "" : ((DateTime)bilgi.TALEP_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.TALEP_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.TALEP_TARIHI).Year.ToString();

                    string _KARAR_TARIHI = (bilgi.KARAR_TARIHI.ToString() == "" || bilgi.KARAR_TARIHI == null) ? "" : ((DateTime)bilgi.KARAR_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.KARAR_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.KARAR_TARIHI).Year.ToString();

                    string _TEMINAT_IADE_TARIHI = (bilgi.TEMINAT_IADE_TARIHI.ToString() == "" || bilgi.TEMINAT_IADE_TARIHI == null) ? "" : ((DateTime)bilgi.TEMINAT_IADE_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.TEMINAT_IADE_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.TEMINAT_IADE_TARIHI).Year.ToString();

                    try
                    {
                        listeler.Add(new string[]
                    {
                         EditorDataAraclari.Tools.GetMahkeme(bilgi.ADLI_BIRIM_ADLIYE_ID)
                        ,EditorDataAraclari.Tools.GetAdliBirimNo(bilgi.ADLI_BIRIM_NO_ID)
                        ,EditorDataAraclari.Tools.GetAdliBirimGorev(bilgi.ADLI_BIRIM_GOREV_ID)
                        ,bilgi.ESAS_NO.ToString()
                        ,_TALEP_TARIHI//((DateTime)bilgi.TALEP_TARIHI).ToString()
                        ,bilgi.KARAR_NO.ToString()
                        ,_KARAR_TARIHI//((DateTime)bilgi.KARAR_TARIHI).ToString()
                        ,bilgi.TEMINAT_TUTARI.ToString()
                        ,EditorDataAraclari.Tools.GetDovizTipi(bilgi.TEMINAT_TUTARI_DOVIZ_ID)
                        ,_TEMINAT_IADE_TARIHI//((DateTime)bilgi.TEMINAT_IADE_TARIHI).ToString()
                    });
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch("GetIhtiyatiHacizBilgisi", ex);
                    }
                }

                WordApp wa = new WordApp(listeler);

                AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", ex);
            }
        }

        //efe
        //[ICRA] �HT�YAT� TEDB�R B�LG�S�
        public static void GetIhtiyatiTedbirBilgisi(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>));

            var ihtiyatiTedbirBilgisi = foy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;

            DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.DeepLoad(ihtiyatiTedbirBilgisi, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_IHTIYATI_TEDBIR));
            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                 "Mahkeme"
                ,"No:"
                ,"G�rev"
                ,"D. �� No:"
                ,"Talep T."
                ,"Karar No:"
                ,"Karar T."
                ,"Teminat"
                ,""
                ,"Tem. �ade T."
            });

            //int sira = 1;
            foreach (var bilgi in ihtiyatiTedbirBilgisi)
            {
                string _TALEP_TARIHI = (bilgi.TALEP_TARIHI.ToString() == "" || bilgi.TALEP_TARIHI == null) ? "" : ((DateTime)bilgi.TALEP_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.TALEP_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.TALEP_TARIHI).Year.ToString();

                string _KARAR_TARIHI = (bilgi.KARAR_TARIHI.ToString() == "" || bilgi.KARAR_TARIHI == null) ? "" : ((DateTime)bilgi.KARAR_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.KARAR_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.KARAR_TARIHI).Year.ToString();

                string _TEMINAT_IADE_TARIHI = (bilgi.TEMINAT_IADE_TARIHI.ToString() == "" || bilgi.TEMINAT_IADE_TARIHI == null) ? "" : ((DateTime)bilgi.TEMINAT_IADE_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.TEMINAT_IADE_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.TEMINAT_IADE_TARIHI).Year.ToString();

                try
                {
                    listeler.Add(new string[]
                    {
                         EditorDataAraclari.Tools.GetMahkeme(bilgi.ADLI_BIRIM_ADLIYE_ID)
                        ,EditorDataAraclari.Tools.GetAdliBirimNo(bilgi.ADLI_BIRIM_NO_ID)
                        ,EditorDataAraclari.Tools.GetAdliBirimGorev(bilgi.ADLI_BIRIM_GOREV_ID)
                        ,bilgi.ESAS_NO.ToString()
                        ,_TALEP_TARIHI//((DateTime)bilgi.TALEP_TARIHI).ToString()
                        ,bilgi.KARAR_NO.ToString()
                        ,_KARAR_TARIHI//((DateTime)bilgi.KARAR_TARIHI).ToString()
                        ,bilgi.TEMINAT_TUTARI.ToString()
                        ,EditorDataAraclari.Tools.GetDovizTipi(bilgi.TEMINAT_TUTARI_DOVIZ_ID)
                        ,_TEMINAT_IADE_TARIHI//((DateTime)bilgi.TEMINAT_IADE_TARIHI).ToString()
                    });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetIhtiyatiTedbirBilgisi", ex);
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        public static void GetIhtiyatiTedbirBilgisi(AV001_TD_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.Count == 0)
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>));

            var ihtiyatiTedbirBilgisi = foy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;

            DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.DeepLoad(ihtiyatiTedbirBilgisi, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_IHTIYATI_TEDBIR));
            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                 "Mahkeme"
                ,"No:"
                ,"G�rev"
                ,"D. �� No:"
                ,"Talep T."
                ,"Karar No:"
                ,"Karar T."
                ,"Teminat"
                ,""
                ,"Tem. �ade T."
            });

            //int sira = 1;
            foreach (var bilgi in ihtiyatiTedbirBilgisi)
            {
                string _TALEP_TARIHI = (bilgi.TALEP_TARIHI.ToString() == "" || bilgi.TALEP_TARIHI == null) ? "" : ((DateTime)bilgi.TALEP_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.TALEP_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.TALEP_TARIHI).Year.ToString();

                string _KARAR_TARIHI = (bilgi.KARAR_TARIHI.ToString() == "" || bilgi.KARAR_TARIHI == null) ? "" : ((DateTime)bilgi.KARAR_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.KARAR_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.KARAR_TARIHI).Year.ToString();

                string _TEMINAT_IADE_TARIHI = (bilgi.TEMINAT_IADE_TARIHI.ToString() == "" || bilgi.TEMINAT_IADE_TARIHI == null) ? "" : ((DateTime)bilgi.TEMINAT_IADE_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.TEMINAT_IADE_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.TEMINAT_IADE_TARIHI).Year.ToString();

                try
                {
                    listeler.Add(new string[]
                    {
                         EditorDataAraclari.Tools.GetMahkeme(bilgi.ADLI_BIRIM_ADLIYE_ID)
                        ,EditorDataAraclari.Tools.GetAdliBirimNo(bilgi.ADLI_BIRIM_NO_ID)
                        ,EditorDataAraclari.Tools.GetAdliBirimGorev(bilgi.ADLI_BIRIM_GOREV_ID)
                        ,bilgi.ESAS_NO.ToString()
                        ,_TALEP_TARIHI//((DateTime)bilgi.TALEP_TARIHI).ToString()
                        ,bilgi.KARAR_NO.ToString()
                        ,_KARAR_TARIHI//((DateTime)bilgi.KARAR_TARIHI).ToString()
                        ,bilgi.TEMINAT_TUTARI.ToString()
                        ,EditorDataAraclari.Tools.GetDovizTipi(bilgi.TEMINAT_TUTARI_DOVIZ_ID)
                        ,_TEMINAT_IADE_TARIHI//((DateTime)bilgi.TEMINAT_IADE_TARIHI).ToString()
                    });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetIhtiyatiTedbirBilgisi", ex);
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        //efe
        //[ICRA] �LAM B�LG�LER� TABLOLU
        public static void GetIlamBilgileri(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ILAM_MAHKEMESI>));

            var ilamBilgi = foy.AV001_TI_BIL_ILAM_MAHKEMESICollection;

            DataRepository.AV001_TI_BIL_ILAM_MAHKEMESIProvider.DeepLoad(ilamBilgi, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_ILAM_MAHKEMESI));
            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                 "Mahkeme"
                ,"No:"
                ,"G�rev"
                ,"Esas No:"
                ,"Karar T."
                ,"Karar No:"
                ,"Kesinle�me T."
            });

            //int sira = 1;
            foreach (var bilgi in ilamBilgi)
            {
                string _KARAR_TARIHI = (bilgi.KARAR_TARIHI.ToString() == "" || bilgi.KARAR_TARIHI == null) ? "" : ((DateTime)bilgi.KARAR_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.KARAR_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.KARAR_TARIHI).Year.ToString();

                string _KARAR_KESINLESME_TARIHI = (bilgi.KARAR_KESINLESME_TARIHI.ToString() == "" || bilgi.KARAR_KESINLESME_TARIHI == null) ? "" : ((DateTime)bilgi.KARAR_KESINLESME_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.KARAR_KESINLESME_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.KARAR_KESINLESME_TARIHI).Year.ToString();

                try
                {
                    listeler.Add(new string[]
                    {
                         EditorDataAraclari.Tools.GetMahkeme(bilgi.ADLI_BIRIM_ADLIYE_ID)
                        ,bilgi.ADLI_BIRIM_NO_ID.ToString()
                        ,EditorDataAraclari.Tools.GetAdliBirimGorev(bilgi.ADLI_BIRIM_GOREV_ID)
                        ,bilgi.ESAS_NO.ToString()
                        ,_KARAR_TARIHI
                        ,bilgi.KARAR_NO.ToString()
                        ,_KARAR_KESINLESME_TARIHI
                    });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetIlamBilgileri", ex);
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        //[ICRA] INFAZ TARIHI
        public static string GetInfazTarihi(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            return EditorDataAraclari.Tools.TarihBicimlendirme(foy.FOY_INFAZ_TARIHI);
        }

        //[ICRA] INTIKAL TARIHI
        public static string GetIntikalTarihi(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            return EditorDataAraclari.Tools.TarihBicimlendirme(foy.DEPARTMANA_INTIKAL_TARIHI);
        }

        //efe
        //[ICRA] MEH�L B�LG�LER�
        public static void GetMehilBilgileri(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TI_BIL_MEHILCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_MEHIL>));

            var mehilBilgi = foy.AV001_TI_BIL_MEHILCollection;

            DataRepository.AV001_TI_BIL_MEHILProvider.DeepLoad(mehilBilgi, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_MEHIL));
            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                 "Mehil �steyen"
                ,"Temyiz T."
                ,"Meh Karar T."
                ,"Ay"
                ,"G�n"
                ,"Ek Mehil"
                ,"Ek Mehil T."
            });

            //int sira = 1;
            foreach (var bilgi in mehilBilgi)
            {
                string _ICRA_MEHIL_ILAM_TEMYIZ_TARIHI = (bilgi.ICRA_MEHIL_ILAM_TEMYIZ_TARIHI.ToString() == "" || bilgi.ICRA_MEHIL_ILAM_TEMYIZ_TARIHI == null) ? "" : ((DateTime)bilgi.ICRA_MEHIL_ILAM_TEMYIZ_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.ICRA_MEHIL_ILAM_TEMYIZ_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.ICRA_MEHIL_ILAM_TEMYIZ_TARIHI).Year.ToString();

                string _YARGITAY_MEHIL_KARAR_TARIHI = (bilgi.YARGITAY_MEHIL_KARAR_TARIHI.ToString() == "" || bilgi.YARGITAY_MEHIL_KARAR_TARIHI == null) ? "" : ((DateTime)bilgi.YARGITAY_MEHIL_KARAR_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.YARGITAY_MEHIL_KARAR_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.YARGITAY_MEHIL_KARAR_TARIHI).Year.ToString();

                string _EK_MEHIL_TARIHI = (bilgi.EK_MEHIL_TARIHI.ToString() == "" || bilgi.EK_MEHIL_TARIHI == null) ? "" : ((DateTime)bilgi.EK_MEHIL_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.EK_MEHIL_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.EK_MEHIL_TARIHI).Year.ToString();

                try
                {
                    listeler.Add(new string[]
                    {
                         EditorDataAraclari.Tools.GetCari(bilgi.ICRA_MEHIL_ISTEYEN_TARAF_ID)
                        ,_ICRA_MEHIL_ILAM_TEMYIZ_TARIHI
                        ,_YARGITAY_MEHIL_KARAR_TARIHI
                        ,bilgi.YARGITAY_MEHIL_MUDDETI_AY.ToString()
                        ,bilgi.YARGITAY_MEHIL_MUDDETI_GUN.ToString()
                        ,bilgi.EK_MEHIL_VAR_MI?"Var":"Yok"
                        ,_EK_MEHIL_TARIHI
                    });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetMehilBilgileri", ex);
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        //efe
        //[ICRA] M�VEKK�LE �DEME B�LG�LER�
        public static void GetMuvekkileOdemeBilgileri(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TI_BIL_MUVEKKILE_ODEMECollectionGetByICRA_FOY_ID.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_MUVEKKILE_ODEME>));

            var muvekkileOdemeBilgileri = foy.AV001_TI_BIL_MUVEKKILE_ODEMECollectionGetByICRA_FOY_ID;

            DataRepository.AV001_TI_BIL_MUVEKKILE_ODEMEProvider.DeepLoad(muvekkileOdemeBilgileri, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_MUVEKKILE_ODEME));
            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                 "�deme Tarihi"
                ,"�deyen"
                ,"M�vekkil"
                ,"�deme Miktar�"
                ,""
                ,"�deme Tipi"
                ,"A��klama"
            });

            //int sira = 1;
            foreach (var bilgi in muvekkileOdemeBilgileri)
            {
                string _ODEME_TARIHI = (bilgi.ODEME_TARIHI.ToString() == "" || bilgi.ODEME_TARIHI == null) ? "" : ((DateTime)bilgi.ODEME_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.ODEME_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.ODEME_TARIHI).Year.ToString();

                try
                {
                    listeler.Add(new string[]
                    {
                         _ODEME_TARIHI
                        ,EditorDataAraclari.Tools.GetCari(bilgi.ODEYEN_CARI_ID)
                        ,EditorDataAraclari.Tools.GetCari(bilgi.ODENEN_CARI_ID)
                        ,bilgi.MIKTAR.ToString()
                        ,EditorDataAraclari.Tools.GetDovizTipi(bilgi.MIKTAR_DOVIZ_ID)
                        ,EditorDataAraclari.Tools.GetOdemeTipi(bilgi.ODEME_TIP_ID)
                        ,bilgi.ACIKLAMA
                    });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetMuvekkileOdemeBilgileri", ex);
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        //efe
        //[ICRA] SATI� B�LG�LER�
        public static void GetSatisBilgileri(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TI_BIL_SATIS_MASTERCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_SATIS_MASTER>));

            var satisBilgileri = foy.AV001_TI_BIL_SATIS_MASTERCollection;

            DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.DeepLoad(satisBilgileri, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_FAIZ_TIP), typeof(AV001_TI_BIL_SATIS_MASTER));
            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                 "�lan Tarihi"
                ,"1. Sat�� T."
                //,"Saati"
                ,"2. Sat�� T."
                //,"Saati"
                ,"Bor�lu"
                //,"Netice 1"
                //,"Netice 2"
            });

            //int sira = 1;
            foreach (var bilgi in satisBilgileri)
            {
                string _ILAN_TARIHI = (bilgi.ILAN_TARIHI.ToString() == "" || bilgi.ILAN_TARIHI == null) ? "" : ((DateTime)bilgi.ILAN_TARIHI).Day.ToString() + "/" + ((DateTime)bilgi.ILAN_TARIHI).Month.ToString() + "/" + ((DateTime)bilgi.ILAN_TARIHI).Year.ToString();
                string _SATIS_TARIHI_1 = (bilgi.SATIS_TARIHI_1.ToString() == "" || bilgi.SATIS_TARIHI_1 == null) ? "" : ((DateTime)bilgi.SATIS_TARIHI_1).Day.ToString() + "/" + ((DateTime)bilgi.SATIS_TARIHI_1).Month.ToString() + "/" + ((DateTime)bilgi.SATIS_TARIHI_1).Year.ToString();
                //string _SATIS_SAATI_1 = (bilgi.SATIS_SAATI_1.ToString() == ""|| bilgi.SATIS_SAATI_1 == null)? "" : bilgi.SATIS_SAATI_1;
                string _SATIS_TARIHI_2 = (bilgi.SATIS_TARIHI_2.ToString() == "" || bilgi.SATIS_TARIHI_2 == null) ? "" : ((DateTime)bilgi.SATIS_TARIHI_2).Day.ToString() + "/" + ((DateTime)bilgi.SATIS_TARIHI_2).Month.ToString() + "/" + ((DateTime)bilgi.SATIS_TARIHI_2).Year.ToString();
                //string _SATIS_SAATI_2 = (bilgi.SATIS_SAATI_2.ToString() == "" || bilgi.SATIS_SAATI_2 == null) ? "" : bilgi.SATIS_SAATI_2;
                string _SATISI_ISTENEN_CARI = EditorDataAraclari.Tools.GetCari(bilgi.SATISI_ISTENEN_CARI_ID);

                try
                {
                    listeler.Add(new string[]
                    {
                        //(DBNull.Value.Equals(item.TIPI) || item.TIPI == null) ? "" : item.TIPI.ToString();

                         _ILAN_TARIHI
                        ,_SATIS_TARIHI_1
                        //,_SATIS_SAATI_1
                        ,_SATIS_TARIHI_2
                        //,_SATIS_SAATI_2
                        ,_SATISI_ISTENEN_CARI
                        //,EditorDataAraclari.Tools.GetSatisNetice(bilgi.SATIS_NETICESI1_ID)
                        //,EditorDataAraclari.Tools.GetSatisNetice(bilgi.SATIS_NETICESI2_ID)
                    });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetSatisBilgileri", ex);
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        //efe
        //[ICRA] TAK�P GEL��MELER�
        public static void GetTakipGelismeleri(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TI_BIL_FOY_GELISMECollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_GELISME>));

            var takipGelisme = foy.AV001_TI_BIL_FOY_GELISMECollection;

            DataRepository.AV001_TI_BIL_FOY_GELISMEProvider.DeepLoad(takipGelisme, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_FOY_GELISME));
            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                 "Tarihi"
                ,"Geli�me"
                ,"Geli�me Taraf�"
                ,"A��klama"
            });

            //int sira = 1;
            foreach (var bilgi in takipGelisme)
            {
                string _TARIH = (bilgi.TARIH.ToString() == "" || bilgi.TARIH == null) ? "" : ((DateTime)bilgi.TARIH).Day.ToString() + "/" + ((DateTime)bilgi.TARIH).Month.ToString() + "/" + ((DateTime)bilgi.TARIH).Year.ToString();

                string YeniAciklama = "";
                int karSayisi = 0;
                foreach (char item in bilgi.ACIKLAMA.ToArray())
                {
                    karSayisi++;
                    if (karSayisi <= 60)
                        YeniAciklama += item.ToString();
                    else
                    {
                        karSayisi = 0;
                        YeniAciklama += Environment.NewLine + item.ToString();
                    }
                }

                try
                {
                    listeler.Add(new string[]
                    {
                         _TARIH
                        ,EditorDataAraclari.Tools.GetIcraGelismeAdim(bilgi.GELISME_ADIM_ID)
                        ,EditorDataAraclari.Tools.GetCari(bilgi.TARAF_ID)
                        ,YeniAciklama
                    });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetTakipGelismeleri", ex);
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        public static void GetTakipGelismeleri(AV001_TD_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TD_BIL_FOY_GELISMECollection.Count == 0)
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_GELISME>));

            var takipGelisme = foy.AV001_TD_BIL_FOY_GELISMECollection;

            DataRepository.AV001_TD_BIL_FOY_GELISMEProvider.DeepLoad(takipGelisme, false, DeepLoadType.IncludeChildren, typeof(AV001_TD_BIL_FOY_GELISME));
            List<string[]> listeler = new List<string[]>();

            listeler.Add(new string[]
            {
                 "Tarihi"
                ,"Geli�me"
                ,"Geli�me Taraf�"
                ,"A��klama"
            });

            //int sira = 1;
            foreach (var bilgi in takipGelisme)
            {
                string _TARIH = (bilgi.TARIH.ToString() == "" || bilgi.TARIH == null) ? "" : ((DateTime)bilgi.TARIH).Day.ToString() + "/" + ((DateTime)bilgi.TARIH).Month.ToString() + "/" + ((DateTime)bilgi.TARIH).Year.ToString();

                string YeniAciklama = "";
                int karSayisi = 0;
                foreach (char item in bilgi.ACIKLAMA.ToArray())
                {
                    karSayisi++;
                    if (karSayisi <= 60)
                        YeniAciklama += item.ToString();
                    else
                    {
                        karSayisi = 0;
                        YeniAciklama += Environment.NewLine + item.ToString();
                    }
                }

                try
                {
                    listeler.Add(new string[]
                    {
                         _TARIH
                        ,EditorDataAraclari.Tools.GetIcraGelismeAdim(bilgi.GELISME_ADIM_ID)
                        ,EditorDataAraclari.Tools.GetCari(bilgi.TARAF_ID)
                        ,YeniAciklama
                    });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch("GetTakipGelismeleri", ex);
                }
            }

            WordApp wa = new WordApp(listeler);

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.WordImport(txControl, field, wa.FilePath);
        }

        #endregion icra kapak de�i�kenleri

        #region Taahh�t De�i�kenleri

        public static void GetAlacakBilgileri_BonoIcin(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            field.Text = "   ";
            var alacaklar = HesapAraclari.Icra.GetAlacakNedenBonolar(foy);
            List<string[]> liste = new List<string[]>();
            var basliklar = new string[] { "Tanzim Tarihi", "Vade Tarihi", "Tutar" };
            liste.Add(basliklar);
            DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(alacaklar, false, DeepLoadType.IncludeChildren,
    typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>), typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK>));

            foreach (var item in alacaklar)
            {
                if (item.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK.Count > 0)
                {
                    var kverak = item.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK.First();
                    DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(kverak, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_BANKA));

                    string bankaAdi = string.Empty;

                    if (kverak.BANKA_IDSource != null)
                        bankaAdi = kverak.BANKA_IDSource.BANKA;

                    liste.Add(new[]
                    {
                        TarihBicimlendirme(kverak.EVRAK_TANZIM_TARIHI),
                        TarihBicimlendirme(kverak.EVRAK_VADE_TARIHI),
                        new ParaVeDovizId(kverak.TUTAR,kverak.TUTAR_DOVIZ_ID).GetStringValue()
                    });
                }
            }

            if (liste.Count > 1)
            {
                txControl.Select(field.Start, 0);
                txControl.Tables.Add(liste.Count, liste[0].Length, 2135);
                var table = txControl.Tables.GetItem(2135);

                var nume = table.Cells.GetEnumerator();

                while (nume.MoveNext())
                {
                    var cell = nume.Current as TableCell;

                    cell.Text = liste[cell.Row - 1][cell.Column - 1];
                }
            }
        }

        public static void GetAlacakBilgileri_CekIcin(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            field.Text = "   ";

            var alacaklar = HesapAraclari.Icra.GetAlacakNedenCekler(foy);
            List<string[]> liste = new List<string[]>();
            var basliklar = new string[] { "Ke�ide Tarihi", "�braz Tarihi", "Muhatap Banka", "Tutar" };
            liste.Add(basliklar);
            DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(alacaklar, false, DeepLoadType.IncludeChildren,
                typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>), typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK>));

            foreach (var item in alacaklar)
            {
                if (item.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK.Count > 0)
                {
                    var kverak = item.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK.First();
                    DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(kverak, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_BANKA));

                    string bankaAdi = string.Empty;

                    if (kverak.BANKA_IDSource != null)
                        bankaAdi = kverak.BANKA_IDSource.BANKA;

                    liste.Add(new[]
                    {
                        TarihBicimlendirme(kverak.EVRAK_VADE_TARIHI),
                        TarihBicimlendirme(kverak.SORULDUGU_TARIH),
                        bankaAdi,
                        new ParaVeDovizId(kverak.TUTAR,kverak.TUTAR_DOVIZ_ID).GetStringValue()
                    });
                }
            }

            if (liste.Count > 1)
            {
                txControl.Select(field.Start, 0);
                txControl.Tables.Add(liste.Count, liste[0].Length, 2135);
                var table = txControl.Tables.GetItem(2135);

                var nume = table.Cells.GetEnumerator();

                while (nume.MoveNext())
                {
                    var cell = nume.Current as TableCell;

                    cell.Text = liste[cell.Row - 1][cell.Column - 1];
                }
            }
        }

        //[ICRA] BORC TAAHHUDU ALACAKLI VEKIL ADI
        public static string GetGecerliTaahhutAlacakliVekilAdi(AV001_TI_BIL_FOY foy)
        {
            return EditorDataAraclari.Icra.GetTaahhutEdenMuvekkiliAdiByFoyIdAndGecerli(foy.ID);
        }

        //[ICRA] BORC TAAHHUDU HESAP DEGERLERI
        public static string GetGecerliTaahhutHesapDegerleri(AV001_TI_BIL_FOY foy)
        {
            string result = string.Empty;
            decimal toplam = 0;
            var gecerliTaahut = EditorDataAraclari.Icra.GetTaahhutMasterByFoyAndGecerliMi(foy.ID, true);
            if (gecerliTaahut.Count > 0)
            {
                var tMaster = gecerliTaahut[0];
                if (tMaster.SIMULASYON_HESAP_CETVELI_ID.HasValue)
                {
                    DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepLoad(tMaster, false, DeepLoadType.IncludeChildren,
                        typeof(AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI));

                    ParaVeDovizId asilAlacak = new ParaVeDovizId(tMaster.SIMULASYON_HESAP_CETVELI_IDSource.ASIL_ALACAK, tMaster.SIMULASYON_HESAP_CETVELI_IDSource.ASIL_ALACAK_DOVIZ_ID);
                    //ParaVeDovizId faizler = new ParaVeDovizId(tMaster.SIMULASYON_HESAP_CETVELI_IDSource.FAIZ_TOPLAMI, tMaster.SIMULASYON_HESAP_CETVELI_IDSource.FAIZ_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId harclar = new ParaVeDovizId(tMaster.SIMULASYON_HESAP_CETVELI_IDSource.KALAN_TAHSIL_HARCI, tMaster.SIMULASYON_HESAP_CETVELI_IDSource.KALAN_TAHSIL_HARCI_DOVIZ_ID);
                    ParaVeDovizId masraflar = new ParaVeDovizId(tMaster.SIMULASYON_HESAP_CETVELI_IDSource.TUM_MASRAF_TOPLAMI, tMaster.SIMULASYON_HESAP_CETVELI_IDSource.TUM_MASRAF_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId vergiler = new ParaVeDovizId(tMaster.SIMULASYON_HESAP_CETVELI_IDSource.KO_ILAM_YARGILAMA_GIDERI, tMaster.SIMULASYON_HESAP_CETVELI_IDSource.ODEME_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId takipVekalet = new ParaVeDovizId(tMaster.SIMULASYON_HESAP_CETVELI_IDSource.TAKIP_VEKALET_UCRETI + tMaster.SIMULASYON_HESAP_CETVELI_IDSource.IT_VEKALET_UCRETI + tMaster.SIMULASYON_HESAP_CETVELI_IDSource.DAVA_VEKALET_UCRETI + tMaster.SIMULASYON_HESAP_CETVELI_IDSource.TD_VEK_UCR + tMaster.SIMULASYON_HESAP_CETVELI_IDSource.IH_VEKALET_UCRETI + tMaster.SIMULASYON_HESAP_CETVELI_IDSource.TAHLIYE_VEK_UCR + tMaster.SIMULASYON_HESAP_CETVELI_IDSource.ILAM_VEK_UCR, tMaster.SIMULASYON_HESAP_CETVELI_IDSource.TAKIP_VEKALET_UCRETI_DOVIZ_ID);
                    ParaVeDovizId tazminatlar = new ParaVeDovizId(tMaster.SIMULASYON_HESAP_CETVELI_IDSource.KARSILIKSIZ_CEK_TAZMINATI + tMaster.SIMULASYON_HESAP_CETVELI_IDSource.OZEL_TAZMINAT + tMaster.SIMULASYON_HESAP_CETVELI_IDSource.CEK_KOMISYONU, tMaster.SIMULASYON_HESAP_CETVELI_IDSource.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID);
                    ParaVeDovizId digergiderler = new ParaVeDovizId(tMaster.SIMULASYON_HESAP_CETVELI_IDSource.DIGER_GIDERLER, tMaster.SIMULASYON_HESAP_CETVELI_IDSource.DIGER_GIDERLER_DOVIZ_ID);
                    ParaVeDovizId digeralacaklar = new ParaVeDovizId(tMaster.SIMULASYON_HESAP_CETVELI_IDSource.OZEL_TUTAR1 + tMaster.SIMULASYON_HESAP_CETVELI_IDSource.OZEL_TUTAR2 + tMaster.SIMULASYON_HESAP_CETVELI_IDSource.OZEL_TUTAR3, tMaster.SIMULASYON_HESAP_CETVELI_IDSource.ALACAK_TOPLAMI_DOVIZ_ID);

                    toplam = harclar.Para + masraflar.Para + vergiler.Para + takipVekalet.Para + tazminatlar.Para + digergiderler.Para + digeralacaklar.Para + asilAlacak.Para;

                    result += string.Format("{0} \t As�l alacak", asilAlacak.GetStringValue());
                    result += Environment.NewLine;

                    //if (faizler.Para > 0)
                    //{
                    //    result += string.Format("{0} \t Mevcut ��lemi� Faiz", faizler.GetStringValue());
                    //    result += Environment.NewLine;
                    //}

                    if (harclar.Para > 0)
                    {
                        result += string.Format("{0} \t Har�lar", harclar.GetStringValue());
                        result += Environment.NewLine;
                    }
                    if (masraflar.Para > 0)
                    {
                        result += string.Format("{0} \t Masraflar", masraflar.GetStringValue());
                        result += Environment.NewLine;
                    }
                    if (vergiler.Para > 0)
                    {
                        result += string.Format("{0} \t Vergiler", vergiler.GetStringValue());
                        result += Environment.NewLine;
                    }
                    if (takipVekalet.Para > 0)
                    {
                        result += string.Format("{0} \t Takip Vekalet", takipVekalet.GetStringValue());
                        result += Environment.NewLine;
                    }
                    if (tazminatlar.Para > 0)
                    {
                        result += string.Format("{0} \t Tazminatlar", tazminatlar.GetStringValue());
                        result += Environment.NewLine;
                    }
                    if (digergiderler.Para > 0)
                    {
                        result += string.Format("{0} \t Di�er Giderler", digergiderler.GetStringValue());
                        result += Environment.NewLine;
                    }
                    if (digeralacaklar.Para > 0)
                    {
                        result += string.Format("{0} \t Di�er Alacaklar", digeralacaklar.GetStringValue());
                        result += Environment.NewLine;
                    }
                }
                else
                {
                    ParaVeDovizId asilAlacak = new ParaVeDovizId(foy.ASIL_ALACAK, foy.ASIL_ALACAK_DOVIZ_ID);
                    ParaVeDovizId islemisFaiz = new ParaVeDovizId(foy.FAIZ_TOPLAMI, foy.FAIZ_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId masraflar = new ParaVeDovizId(foy.TUM_MASRAF_TOPLAMI, foy.TUM_MASRAF_TOPLAMI_DOVIZ_ID);
                    ParaVeDovizId takipVekalet = new ParaVeDovizId(foy.TAKIP_VEKALET_UCRETI, foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID);

                    result += string.Format("{0} \t As�l alacak", asilAlacak.GetStringValue());
                    result += Environment.NewLine;
                    result += string.Format("{0} \t ��lemi� Faiz", islemisFaiz.GetStringValue());
                    result += Environment.NewLine;
                    result += string.Format("{0} \t Masraflar", masraflar.GetStringValue());
                    result += Environment.NewLine;
                    result += string.Format("{0} \t Takip Vekalet", takipVekalet.GetStringValue());
                    result += Environment.NewLine;
                }
                DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepLoad(tMaster, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD>));

                List<ParaVeDovizId> faizlerListesi = new List<ParaVeDovizId>();
                foreach (var child in tMaster.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection)
                {
                    faizlerListesi.Add(new ParaVeDovizId(child.FAIZE_ODENEN, child.FAIZE_ODENEN_DOVIZ_ID));
                }

                var topla = ParaVeDovizId.Topla(faizlerListesi);
                result += string.Format("{0} \t taksitlere b�l�nd�g�nde gelecek faiz,", topla.GetStringValue());
                result += Environment.NewLine;

                result += "--------------------------";
                result += Environment.NewLine;

                result += string.Format("{0} \t Toplam,", new ParaVeDovizId(toplam + topla.Para, 1).GetStringValue());
                result += Environment.NewLine;
            }
            return result;
        }

        //[ICRA] BORC TAAHHUDU ODEME TAAHHUTLERI
        public static string GetGecerliTAahhutOdemeTaahhutleri(AV001_TI_BIL_FOY foy)
        {
            var taahhudChildlar = EditorDataAraclari.Icra.GetTaahhutChildByFoyAndGecerliMaster(foy.ID);

            string result = string.Empty;
            List<ParaVeDovizId> odemelerListesi = new List<ParaVeDovizId>();
            for (int i = 0; i < taahhudChildlar.Count; i++)
            {
                var child = taahhudChildlar[i];
                ParaVeDovizId borcTutari = new ParaVeDovizId(child.TAAHHUT_MIKTARI, child.TAAHHUT_MIKTARI_DOVIZ_ID);
                odemelerListesi.Add(borcTutari);

                result += string.Format("{0}) {1} Tarihinde {2} �deme"
                    , child.SIRA_NO
                    , TarihBicimlendirme(child.TAAHHUTU_YERINE_GETIRME_TARIHI)
                    , borcTutari.GetStringValue());
                if (child.SIRA_NO % 2 == 0)
                    result += Environment.NewLine;
                else
                    result += "\t";
            }
            var toplam = ParaVeDovizId.Topla(odemelerListesi);
            result += Environment.NewLine;
            result += string.Format("Taksitlendirilmi� taahh�t toplam� : {0}", toplam.GetStringValue());
            return result;
        }

        //[ICRA] BORC TAAHHUDU TAAHHUT TARIHI
        public static string GetGecerliTaahhutTarihi(AV001_TI_BIL_FOY foy)
        {
            var tarih = EditorDataAraclari.Icra.GetTaahhutMasterTarihByFoyAndGecerliMaster(foy.ID);
            if (tarih.HasValue)
                return TarihBicimlendirme(tarih.Value);

            return string.Empty;
        }

        //[ICRA] BORC TAAHHUDU BORCLU BILGILERI
        public static string GetGecerliTaahutBorcluAdi(AV001_TI_BIL_FOY foy)
        {
            string result = string.Empty;

            var cari = EditorDataAraclari.Icra.GetTaahhutMasterBorcluAdiByFoyAndGecerli(foy.ID);

            if (cari != null)
            {
                result += "Bor�lu";
                result += Environment.NewLine;
                result += cari.AD;
                result += Environment.NewLine;

                #region Adres Bilgileri

                result += "Bor�lu Adresi";
                result += Environment.NewLine;
                result += string.Format("{0} {1} {2}"
            , cari.Aktif_ADRES1
            , cari.Aktif_ADRES2
            , cari.Aktif_ADRES3);
                result += Environment.NewLine;

                //todo : Semt i�inde aktif adres kontrol� yap�lacak
                //if (cari.ADRES_SEMT_ID.HasValue)
                //    result += string.Format(@" {0} ", EditorDataAraclari.Kodlar.GetSemtAdi(altCari.ADRES_SEMT_ID.Value));
                if (cari.Aktif_ILCE_ID.HasValue)
                    result += string.Format(@" {0} ", EditorDataAraclari.Kodlar.GetIlceAdi(cari.Aktif_ILCE_ID.Value));
                if (cari.Aktif_IL_ID.HasValue)
                    result += string.Format(@" {0} ", EditorDataAraclari.Kodlar.GetIlAdi(cari.Aktif_IL_ID.Value));
                result += Environment.NewLine;

                #endregion Adres Bilgileri

                #region Kimlik Bilgileri

                DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(cari, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));

                if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection.Count > 0)
                {
                    result += "Bor�lu Kimlik Bilgileri";

                    result += string.Format("T.C. No :{0} Baba Ad� :{1} Ana Ad� :{2} "
                  , cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].TC_KIMLIK_NO
                      , cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].BABA_ADI
                          , cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].ANA_ADI);

                    if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_IL_IDSource != null)
                    {
                        result += string.Format("�l : {0} "
                        , cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_IL_IDSource.IL);
                    }
                    if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_ILCE_IDSource != null)
                    {
                        result += string.Format("�l�e :{0}"
                            , cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_ILCE_IDSource.ILCE);
                    }
                    if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_MAHALLE_KOY.Length > 0)
                        result += string.Format(" Mahalle :{0} "
                            , cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_MAHALLE_KOY);

                    if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_YERI.Length > 0)
                        result += string.Format(" Do�um Yeri :{0} "
                            , cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_YERI);

                    if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_TARIHI.HasValue)
                    {
                        result += string.Format("Do�um Tarihi :{0} "
                            , cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_TARIHI.Value.ToShortDateString());
                    }
                    if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_CILT_NO.Length > 0)
                        result += string.Format("Cilt No :{0} "
                            , cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_CILT_NO);

                    if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_AILE_SIRA_NO.Length > 0)
                        result += string.Format("Aile S�ra No :{0}{1}"
                            , cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_AILE_SIRA_NO
                            , Environment.NewLine);

                    result += Environment.NewLine;
                }

                #endregion Kimlik Bilgileri
            }

            return result;
        }

        #endregion Taahh�t De�i�kenleri
        
        public static AlacakFazlaIpotekAz degerler = new AlacakFazlaIpotekAz();

        public static bool GayrinakitleriGoster = false;

        public static bool IpotekAzAlacakCok = false;

        public static bool MunzamVar = false;

        public static int NewRowID = 0;

        public static int NewRowIDForHarcaEsasDeger = 0;

        private static TList<AV001_TDI_BIL_SOZLESME> DosyadakiSozlesmeler = new TList<AV001_TDI_BIL_SOZLESME>();

        public enum MasrafGrubu
        {
            alacagaMahMalAlimMasraflari,
            digerAlacaklar,
            hacisKesif,
            ilkMasraflar,
            Toplam
        }

        /// <summary>
        /// icraya ait foy no de�perini verir.
        /// </summary>
        /// <param name="myFoy"></param>
        /// <returns></returns>
        ///
        public enum OzelKodTipleri { OzelKod1, OzelKod2, OzelKod3, OzelKod4 }

        private enum DegerKalemi
        {
            BSMV,
            KKDV,
            OIV,
            KDV
        }

        public static string AntetBankaBilgileri()
        {
            string sonuc = "";

            AV001_TDI_BIL_ANTET aa = DataRepository.AV001_TDI_BIL_ANTETProvider.GetByID(1);

            sonuc += aa.BANKA_1;

            if (sonuc.Trim().Length == 0)
                sonuc += aa.BANKA_2;
            else
                sonuc += Environment.NewLine + aa.BANKA_2;

            if (sonuc.Trim().Length == 0)
                sonuc += aa.BANKA_3;
            else
                sonuc += Environment.NewLine + aa.BANKA_3;

            if (sonuc.Trim().Length == 0)
                sonuc += aa.BANKA_4;
            else
                sonuc += Environment.NewLine + aa.BANKA_4;

            if (sonuc.Trim().Length == 0)
                sonuc += aa.BANKA_5;
            else
                sonuc += Environment.NewLine + aa.BANKA_5;

            return sonuc;
        }

        public static string CariBilgileriniHazirla(AV001_TDI_BIL_CARI cari)
        {
            string sonuc = "";
            if (!string.IsNullOrEmpty(cari.AD))
                sonuc += string.Format("Taraf Ad�:{0}", cari.AD);
            if (!string.IsNullOrEmpty(cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].TC_KIMLIK_NO))
                sonuc += string.Format(", TC Kimlik No:{0}", cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].TC_KIMLIK_NO);
            if (!string.IsNullOrEmpty(cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].BELGE_SERI_NO))
                sonuc += string.Format(", Belge Seri No:{0}", cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].BELGE_SERI_NO);
            if (!string.IsNullOrEmpty(cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].BELGE_NO))
                sonuc += string.Format(", Belge No:{0}", cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].BELGE_NO);
            if (!string.IsNullOrEmpty(cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].BABA_ADI))
                sonuc += string.Format(", Baba Ad�:{0}", cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].BABA_ADI);
            if (!string.IsNullOrEmpty(cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].ANA_ADI))
                sonuc += string.Format(", Ana Ad�:{0}", cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].ANA_ADI);
            if (!string.IsNullOrEmpty(cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_YERI))
                sonuc += string.Format(", Do�um Yeri:{0}", cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_YERI);
            if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_TARIHI.HasValue)
                sonuc += string.Format(", Do�um Tarihi:{0}", cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_TARIHI.Value.ToShortDateString());
            if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_IL_ID.HasValue)
                sonuc += string.Format(", �l:{0}", DataRepository.TDI_KOD_ILProvider.GetByID(cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_IL_ID.Value).IL);
            if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_ILCE_ID.HasValue)
                sonuc += string.Format(", �l�e:{0}", DataRepository.TDI_KOD_ILCEProvider.GetByID(cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_ILCE_ID.Value).ILCE);
            if (!string.IsNullOrEmpty(cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_MAHALLE_KOY))
                sonuc += string.Format(", Mahalle/K�y:{0}", cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_MAHALLE_KOY);
            if (!string.IsNullOrEmpty(cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_CILT_NO))
                sonuc += string.Format(", Cilt No:{0}", cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_CILT_NO);
            if (!string.IsNullOrEmpty(cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_AILE_SIRA_NO))
                sonuc += string.Format(", Aile S�ra NO:{0}", cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_AILE_SIRA_NO);

            return sonuc;
        }

        public static string DAVA_Bolum(AvukatProLib2.Entities.AV001_TD_BIL_FOY foyum)
        {
            if (foyum.SEGMENT_ID != null)
            {
                AvukatProLib2.Entities.TDI_KOD_SEGMENT bolum = new TDI_KOD_SEGMENT();

                bolum = AvukatProLib2.Data.DataRepository.TDI_KOD_SEGMENTProvider.GetByID(foyum.SEGMENT_ID.Value);

                return bolum.SEGMENT;
            }
            else
                return "";
        }

        public static string DAVA_Dava_Degeri(AvukatProLib2.Entities.AV001_TD_BIL_FOY foyum)
        {
            AvukatProLib2.Entities.AV001_TD_BIL_FOY dvz = new AV001_TD_BIL_FOY();
            dvz = AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOYProvider.GetByID(foyum.ID);

            return dvz.DAVA_DEGERI.ToString("n2");
        }

        public static string DAVA_Dava_Mahkeme_No_Gorev(AvukatProLib2.Entities.AV001_TD_BIL_FOY foyum)
        {
            AvukatProLib2.Entities.TDI_KOD_ADLI_BIRIM_ADLIYE adliye = new TDI_KOD_ADLI_BIRIM_ADLIYE();
            AvukatProLib2.Entities.TDI_KOD_ADLI_BIRIM_GOREV gorev = new TDI_KOD_ADLI_BIRIM_GOREV();
            AvukatProLib2.Entities.TDI_KOD_ADLI_BIRIM_NO no = new TDI_KOD_ADLI_BIRIM_NO();

            if (foyum.ADLI_BIRIM_ADLIYE_ID.HasValue)
            {
                adliye = AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetByID(foyum.ADLI_BIRIM_ADLIYE_ID.Value);
            }
            if (foyum.ADLI_BIRIM_GOREV_ID.HasValue)
            {
                gorev = AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.GetByID(foyum.ADLI_BIRIM_GOREV_ID.Value);
            }
            if (foyum.ADLI_BIRIM_NO_ID.HasValue)
            {
                no = AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_NOProvider.GetByID(foyum.ADLI_BIRIM_NO_ID.Value);
            }

            return adliye.ADLIYE + " " + no.NO + " " + gorev.ACIKLAMA;
        }

        public static string DAVA_Dava_Talebi(AvukatProLib2.Entities.AV001_TD_BIL_FOY foyum)
        {
            if (foyum.DAVA_TALEP_ID != null)
            {
                AvukatProLib2.Entities.TD_KOD_DAVA_TALEP bolum = new TD_KOD_DAVA_TALEP();

                bolum = AvukatProLib2.Data.DataRepository.TD_KOD_DAVA_TALEPProvider.GetByID(foyum.DAVA_TALEP_ID.Value);

                return bolum.DAVA_TALEP;
            }
            else
                return "";
        }

        public static string DAVA_Dava_Tipi(AvukatProLib2.Entities.AV001_TD_BIL_FOY foyum)
        {
            if (foyum.DAVA_TIP_ID != null)
            {
                AvukatProLib2.Entities.TDI_KOD_ADLI_BIRIM_BOLUM bolum = new TDI_KOD_ADLI_BIRIM_BOLUM();

                bolum = AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_BOLUMProvider.GetByID(foyum.DAVA_TIP_ID.Value);

                return bolum.BIRIM;
            }
            else
                return "";
        }

        public static string DAVA_Durum(AvukatProLib2.Entities.AV001_TD_BIL_FOY foyum)
        {
            if (foyum.FOY_DURUM_ID != null)
            {
                AvukatProLib2.Entities.TDI_KOD_FOY_DURUM bolum = new TDI_KOD_FOY_DURUM();

                bolum = AvukatProLib2.Data.DataRepository.TDI_KOD_FOY_DURUMProvider.GetByID(foyum.FOY_DURUM_ID.Value);

                return bolum.DURUM;
            }
            else
                return "";
        }

        public static DegiskenDegeri DAVA_Faiz_Baslangic_Tarihi(AV001_TD_BIL_FOY foyum)
        {
            DegiskenDegeri returnValue = new DegiskenDegeri();
            returnValue.DonusTipi = DegiskenResulTType.String;

            DateTime tarih = new DateTime();
            foreach (AV001_TD_BIL_DAVA_NEDEN item in DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.GetByDAVA_FOY_ID(foyum.ID))
            {
                if (item.FAIZ_TALEP_TARIHI.HasValue)
                {
                    if (tarih == Convert.ToDateTime("01.01.0001"))
                        tarih = item.FAIZ_TALEP_TARIHI.Value;
                    else
                    {
                        if (tarih > item.FAIZ_TALEP_TARIHI.Value)
                            tarih = item.FAIZ_TALEP_TARIHI.Value;
                    }
                }
            }

            if (tarih != Convert.ToDateTime("01.01.0001"))
                returnValue.Icerik += tarih.ToShortDateString();
            else
                returnValue.Icerik += "";

            return returnValue;
        }

        public static string DAVA_Nobetci_Mahkeme_Bilgisi(AvukatProLib2.Entities.AV001_TD_BIL_FOY foyum)
        {
            AvukatProLib2.Entities.TDI_KOD_ADLI_BIRIM_ADLIYE adliye = new TDI_KOD_ADLI_BIRIM_ADLIYE();
            AvukatProLib2.Entities.TDI_KOD_ADLI_BIRIM_GOREV gorev = new TDI_KOD_ADLI_BIRIM_GOREV();
            AvukatProLib2.Entities.TDI_KOD_ADLI_BIRIM_NO no = new TDI_KOD_ADLI_BIRIM_NO();

            if (foyum.ADLI_BIRIM_ADLIYE_ID.HasValue)
            {
                adliye = AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetByID(foyum.ADLI_BIRIM_ADLIYE_ID.Value);
            }
            if (foyum.ADLI_BIRIM_GOREV_ID.HasValue)
            {
                gorev = AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.GetByID(foyum.ADLI_BIRIM_GOREV_ID.Value);
            }
            if (foyum.ADLI_BIRIM_NO_ID.HasValue)
            {
                no = AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_NOProvider.GetByID(foyum.ADLI_BIRIM_NO_ID.Value);
            }

            return adliye.ADLIYE + " N�BET�� " + gorev.ACIKLAMA;
        }

        public static string DAVA_OzelKodGetir(AvukatProLib2.Entities.AV001_TD_BIL_FOY foyum, OzelKodTipleri Kod)
        {
            if (Kod == OzelKodTipleri.OzelKod1)
            {
                if (foyum.DAVA_OZEL_KOD1_ID != null)
                {
                    AvukatProLib2.Entities.AV001_TDI_KOD_FOY_OZEL bolum = new AV001_TDI_KOD_FOY_OZEL();

                    bolum = AvukatProLib2.Data.DataRepository.AV001_TDI_KOD_FOY_OZELProvider.GetByID(foyum.DAVA_OZEL_KOD1_ID.Value);

                    return bolum.KOD;
                }
                else
                    return "";
            }
            else if (Kod == OzelKodTipleri.OzelKod2)
            {
                if (foyum.DAVA_OZEL_KOD2_ID != null)
                {
                    AvukatProLib2.Entities.AV001_TDI_KOD_FOY_OZEL bolum = new AV001_TDI_KOD_FOY_OZEL();

                    bolum = AvukatProLib2.Data.DataRepository.AV001_TDI_KOD_FOY_OZELProvider.GetByID(foyum.DAVA_OZEL_KOD2_ID.Value);

                    return bolum.KOD;
                }
                else
                    return "";
            }
            else if (Kod == OzelKodTipleri.OzelKod3)
            {
                if (foyum.DAVA_OZEL_KOD3_ID != null)
                {
                    AvukatProLib2.Entities.AV001_TDI_KOD_FOY_OZEL bolum = new AV001_TDI_KOD_FOY_OZEL();

                    bolum = AvukatProLib2.Data.DataRepository.AV001_TDI_KOD_FOY_OZELProvider.GetByID(foyum.DAVA_OZEL_KOD3_ID.Value);

                    return bolum.KOD;
                }
                else
                    return "";
            }
            else if (Kod == OzelKodTipleri.OzelKod4)
            {
                if (foyum.DAVA_OZEL_KOD4_ID != null)
                {
                    AvukatProLib2.Entities.AV001_TDI_KOD_FOY_OZEL bolum = new AV001_TDI_KOD_FOY_OZEL();

                    bolum = AvukatProLib2.Data.DataRepository.AV001_TDI_KOD_FOY_OZELProvider.GetByID(foyum.DAVA_OZEL_KOD4_ID.Value);

                    return bolum.KOD;
                }
                else
                    return "";
            }
            else
                return "";
        }

        public static string DovizDegeriGetir(int? DovizID)
        {
            if (DovizID.HasValue)
            {
                AvukatProLib2.Entities.TDI_KOD_DOVIZ_TIP dvz = new TDI_KOD_DOVIZ_TIP();

                dvz = AvukatProLib2.Data.DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetByID((int)DovizID);

                return dvz.DOVIZ_KODU;
            }
            else
                return "";
        }

        public static List<TextField> DovizliAlacakTakipTarihindeYtl(int foyid, TextControl tcnt, int startind)
        {
            AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum = AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.GetByID(foyid);
            List<TextField> lstFields = new List<TextField>();
            TextField tf = new TextField();
            TList<AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN> lstAlacakNedens = AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByICRA_FOY_ID(foyid);

            for (int i = 0; i < lstAlacakNedens.Count; i++)
            {
                if (lstAlacakNedens[i].ISLEME_KONAN_TUTAR_DOVIZ_ID.Value != 1)
                {
                    InsertTextField(lstAlacakNedens[i].ISLEME_KONAN_TUTAR.ToString(), lstAlacakNedens[i].ID, "��leme Konan Tutar", lstFields, "AV001_TI_BIL_ALACAK_NEDEN");

                    InsertTextField(lstAlacakNedens[i].ISLEME_KONAN_TUTAR_DOVIZ_IDSource.DOVIZ_KODU.ToString(), lstAlacakNedens[i].ISLEME_KONAN_TUTAR_DOVIZ_ID.Value, "��leme Konan Tutar D�viz tipi", lstFields, "TDI_KOD_DOVIZ");
                    InsertTextField(" As�l Alacak ", 0, "As�lAlacakYazi", lstFields, "Yazi");
                    InsertTextField("+__________________________________" + Environment.NewLine, 0, "cizgi", lstFields, "yazi");
                    InsertTextField(lstAlacakNedens[i].ISLEME_KONAN_TUTAR.ToString(), lstAlacakNedens[i].ID, "��leme Konan Tutar", lstFields, "AV001_TI_BIL_ALACAK_NEDEN");

                    InsertTextField(lstAlacakNedens[i].ISLEME_KONAN_TUTAR_DOVIZ_IDSource.DOVIZ_KODU.ToString(), lstAlacakNedens[i].ISLEME_KONAN_TUTAR_DOVIZ_ID.Value, "��leme Konan Tutar D�viz tipi", lstFields, "TDI_KOD_DOVIZ");

                    InsertTextField(" tutar�ndaki alaca��m�zn ", 0, "cizgi", lstFields, "yazi");

                    InsertTextField(" Merkez Bankas� Efektif Sat�� kuru YTL kar��l���  ", 0, "tarihAciklama", lstFields, "yazi");

                    string hesapliDeger = lstAlacakNedens[i].ISLEME_KONAN_TUTAR.ToString() + " " + lstAlacakNedens[i].ISLEME_KONAN_TUTAR_DOVIZ_IDSource.DOVIZ_KODU + " X " + "Dolar YTL";

                    InsertTextField(hesapliDeger, lstAlacakNedens[i].ID, "deger", lstFields, "deger");
                }
                else
                {
                    AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(lstAlacakNedens, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_DOVIZ_TIP));
                    InsertTextField(lstAlacakNedens[i].ISLEME_KONAN_TUTAR.ToString(), lstAlacakNedens[i].ID, "��leme Konan Tutar", lstFields, "AV001_TI_BIL_ALACAK_NEDEN");

                    InsertTextField(lstAlacakNedens[i].ISLEME_KONAN_TUTAR_DOVIZ_IDSource.DOVIZ_KODU.ToString(), lstAlacakNedens[i].ISLEME_KONAN_TUTAR_DOVIZ_ID.Value, "��leme Konan Tutar D�viz tipi", lstFields, "TDI_KOD_DOVIZ");
                    InsertTextField(" ��lemi� Faiz ", 0, "As�lAlacakYazi", lstFields, "Yazi");
                    InsertTextField(Environment.NewLine + "+__________________________________" + Environment.NewLine, 0, "cizgi", lstFields, "yazi");
                    InsertTextField(lstAlacakNedens[i].ISLEME_KONAN_TUTAR.ToString(), lstAlacakNedens[i].ID, "��leme Konan Tutar", lstFields, "AV001_TI_BIL_ALACAK_NEDEN");

                    InsertTextField(lstAlacakNedens[i].ISLEME_KONAN_TUTAR_DOVIZ_IDSource.DOVIZ_KODU.ToString(), lstAlacakNedens[i].ISLEME_KONAN_TUTAR_DOVIZ_ID.Value, "��leme Konan Tutar D�viz tipi", lstFields, "TDI_KOD_DOVIZ");

                    InsertTextField(" tutar�ndaki alacaklar�m�za i�letilecek a�a��da ** ' alacak nedenlerinin yan�nda yer alan faiz tiplerine g�re kademeli olarak hesaplanacak faizi ile birlikte ", 0, "yazi", lstFields, "yazi");

                    lstFields.AddRange(GetAciklama(foyid));
                }
            }
            return lstFields;
        }

        public static string FaizOraniVeTipiGetr(ref DateTime tata, int dtip, List<int> faizTipListesi)
        {
            int faizTipi = faizTipListesi.Count > 0 ? faizTipListesi[0] : 1;
            string faizOrani = FaizHelper.FaizOraniGetir(faizTipi, dtip, tata).ToString();
            switch ((FaizTip)faizTipi)
            {
                case FaizTip.Yasal_Faiz:
                    faizOrani += " Yasal ";

                    break;

                case FaizTip.Reeskont_Avans:
                    faizOrani += "  Avans";

                    break;

                case FaizTip.TR_Libor:
                    faizOrani += " TR Libor";
                    break;

                case FaizTip.En_Y�ksek_Mevduat_Faizi:
                    faizOrani += " En Y�ksek Mevduat";
                    break;

                case FaizTip.Libor:
                    faizOrani += " Libor";

                    break;

                case FaizTip.��letme_Kredi_Faizi:
                    faizOrani += " ��letme Kredi ";

                    break;

                case FaizTip.�zel_Sabit_Faiz:
                    break;

                case FaizTip.Kullan�c�_Tan�ml�_Faiz:
                    faizOrani += " Kullan�c� Tan�ml� ";

                    break;

                case FaizTip.TEFE:
                    faizOrani += " TEFE";

                    break;

                case FaizTip.T�FE:
                    faizOrani += " T�FE";

                    break;

                case FaizTip.Kanuni_Temerr�t_Faizi:
                    faizOrani += " Lanuni Temerr�t ";

                    break;

                case FaizTip._6183_Tecil_Faizi:
                    faizOrani += " 6183 Tecil ";

                    break;

                case FaizTip.Reeskont_�skonto:
                    faizOrani += " Reeskont �skonto";

                    break;

                case FaizTip.Yasal_Faiz_2:
                    faizOrani += " Yasal 2";

                    break;

                case FaizTip.Ticari_Temerr�t_Faizi:
                    faizOrani += " Ticari Temerr�t";

                    break;

                case FaizTip._6183_Gecikme_Faizi:
                    faizOrani += " 6183 Gecikme";

                    break;

                //case FaizTip.Temmerut_Faiz: //�zel Sabit Faiz �le Ayn�
                //    break;
                default:
                    break;
            }

            return faizOrani;
        }

        public static string FaizOraniVeTipiGetr(ref DateTime tata, int dovizTipi, int faizTipi)
        {
            string faizOrani = FaizHelper.FaizOraniGetir(faizTipi, dovizTipi, tata).ToString();
            switch ((FaizTip)faizTipi)
            {
                case FaizTip.Yasal_Faiz:
                    faizTip = "Yasal";
                    faizOran = faizOrani;
                    break;

                case FaizTip.Reeskont_Avans:
                    faizTip = "Avans";
                    faizOran = faizOrani;
                    break;

                case FaizTip.TR_Libor:
                    faizTip = "TR Libor";
                    faizOran = faizOrani;
                    break;

                case FaizTip.En_Y�ksek_Mevduat_Faizi:
                    faizTip = "En Y�ksek Mevduat";
                    faizOran = faizOrani;
                    break;

                case FaizTip.Libor:
                    faizTip = "Libor";
                    faizOran = faizOrani;
                    break;

                case FaizTip.��letme_Kredi_Faizi:
                    faizTip = "��letme Kredi";
                    faizOran = faizOrani;
                    break;

                case FaizTip.�zel_Sabit_Faiz:
                    break;

                case FaizTip.Kullan�c�_Tan�ml�_Faiz:
                    faizTip = "Kullan�c� Tan�ml�";
                    faizOran = faizOrani;
                    break;

                case FaizTip.TEFE:
                    faizTip = "TEFE";
                    faizOran = faizOrani;
                    break;

                case FaizTip.T�FE:
                    faizTip = "T�FE";
                    faizOran = faizOrani;
                    break;

                case FaizTip.Kanuni_Temerr�t_Faizi:
                    faizTip = "Kanuni Temerr�t";
                    faizOran = faizOrani;
                    break;

                case FaizTip._6183_Tecil_Faizi:
                    faizTip = "6183 Tecil";
                    faizOran = faizOrani;
                    break;

                case FaizTip.Reeskont_�skonto:
                    faizTip = "Reeskont �skonto";
                    faizOran = faizOrani;
                    break;

                case FaizTip.Yasal_Faiz_2:
                    faizTip = "Yasal 2";
                    faizOran = faizOrani;
                    break;

                case FaizTip.Ticari_Temerr�t_Faizi:
                    faizTip = "Ticari Temerr�t";
                    faizOran = faizOrani;
                    break;

                case FaizTip._6183_Gecikme_Faizi:
                    faizTip = "6183 Gecikme";
                    faizOran = faizOrani;
                    break;

                //case FaizTip.Temmerut_Faiz: //�zel Sabit Faiz �le Ayn�
                //    break;
                default:
                    break;
            }

            return faizOrani;
        }

        /// <summary>
        /// takip Tarihini
        /// </summary>
        /// <param name="takipTarihi"></param>
        /// <param name="aNeden"></param>
        /// <returns></returns>
        public static string FaizOraniVeTipiGetr(DateTime takipTarihi, AV001_TI_BIL_ALACAK_NEDEN aNeden)
        {
            string yazi = string.Empty;
            if (!aNeden.ALACAK_FAIZ_TIP_ID.HasValue) return string.Empty;

            if (aNeden.ALACAK_FAIZ_TIP_ID.Value == (int)FaizTip.Temmerut_Faiz)
            {
                if (aNeden.ALACAK_FAIZ_TIP_ID.HasValue && aNeden.ALACAK_FAIZ_TIP_ID.Value == (int)FaizTip.Temmerut_Faiz)
                {
                    yazi = "Temerr�t Faiz " + aNeden.UYGULANACAK_FAIZ_ORANI.ToString();
                    faizOran = aNeden.TO_UYGULANACAK_FAIZ_ORANI.ToString();// aNeden.UYGULANACAK_FAIZ_ORANI.ToString();//Kenan -  Bedenok bey bu alana takip �ncesi faiz oran�n�n gelmesi gerekti�ini s�yledi�inden de�i�tirildi. MB
                    faizTip = "Temerr�t Faizi";
                }
            }
            else
                yazi = FaizOraniVeTipiGetr(ref takipTarihi, aNeden.ISLEME_KONAN_TUTAR_DOVIZ_ID ?? 1, aNeden.ALACAK_FAIZ_TIP_ID.Value);

            return yazi;
        }

        public static List<TextField> GetAciklama(int foyid)
        {
            string yazi = " ";

            double vorn = 0;
            bool kdvsiVarmi = false;
            bool oivsiVarmi = false;

            AvukatProLib.Arama.per_AV001_TI_BIL_FOY foyum = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOYs.Single(item => item.ID == foyid);
            DateTime tata = foyum.TAKIP_TARIHI.Value;
            int ftid = 0;
            int dtip = 0;
            if (foyum.KDV_TO != 0)
            {
                IcraDegiskenDegerAta("&KDV&", " KDV si ile birlikte ");
                kdvsiVarmi = true;
            }

            if (foyum.OIV_TO != 0)
            {
                IcraDegiskenDegerAta("&OIVKDV&", " OIV si ile birlikte ");
                oivsiVarmi = true;
            }
            List<AvukatProLib.Arama.per_AV001_TI_BIL_ALACAK_NEDEN> AlacakNedenler = BelgeUtil.Inits.context.per_AV001_TI_BIL_ALACAK_NEDENs.Where(item => item.ICRA_FOY_ID == foyum.ID).ToList();
            TList<TIE_KOD_ALACAK_NEDEN_GRUP> lstGruplar = null;
            TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> kritereGoreAlacakNedenler = new TList<TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN>();
            for (int i = 0; i < AlacakNedenler.Count; i++)
            {
                lstGruplar = DataRepository.TIE_KOD_ALACAK_NEDEN_GRUPProvider.Find("ALACAK_NEDEN_ID = " + AlacakNedenler[i].ALACAK_NEDEN_KOD_ID.Value);

                if (AlacakNedenler[i].TO_ALACAK_FAIZ_TIP_ID != null)
                {
                    ftid = AlacakNedenler[i].TO_ALACAK_FAIZ_TIP_ID.Value;
                }

                dtip = AlacakNedenler[i].ISLEME_KONAN_TUTAR_DOVIZ_ID.Value;
                IcraDegiskenDegerAta("YFM", FaizHelper.FaizOraniGetir(ftid, dtip, tata));

                if (kdvsiVarmi)
                {
                    vorn = FaizHelper.KDVOraniGetir(Convert.ToInt32(AlacakNedenler[i].KDV_TIP_ID.Value), tata);
                }
                if (oivsiVarmi)
                {
                    vorn = AvukatProLib2.Data.DataRepository.TDI_CET_FAIZ_TARIFEProvider.GetByFAIZ_TIP_IDTARIFE_GECERLILIK_BASLANGIC_TARIHIDOVIZ_TIP_ID(ftid, tata, dtip).TARIFE_TUTARI;
                }

                IcraDegiskenDegerAta("&VERGIORN&", vorn);
                IcraDegiskenDegerAta("&GDK&", foyum.TAKIP_CIKISI_DOVIZ_ID);
            }
            if (lstGruplar.Count > 0 && kritereGoreAlacakNedenler.Count > 0)
            {
                yazi = GetAciklamaByGrupInAlacakNedenDegiskenList(kritereGoreAlacakNedenler, lstGruplar);
                if (yazi.Trim() != string.Empty)
                {
                    yazi = yazi.Replace("YFM", FaizHelper.FaizOraniGetir(ftid, dtip, tata).ToString());
                    yazi = yazi.Replace("&VERGIORN&", vorn.ToString());
                    yazi = yazi.Replace("&GDK&", foyum.TAKIP_CIKISI_DOVIZ_ID.ToString());
                }
            }
            List<TextField> lsttF = new List<TextField>();

            if (yazi.StartsWith("tutar�ndaki "))
                yazi = yazi.Replace(" tutar�ndaki ", " ");

            string[] kelimeler = yazi.Split(' ');
            for (int i = 0; i < kelimeler.Length; i++)
            {
                lsttF.Add(new TextField(kelimeler[i]));
            }
            for (int y = 0; y < degis.Length; y++)
            {
                DegiskenleriYerlestir(lsttF, degis[y]);
            }

            return lsttF;
        }

        public static string GetAlacakNedenleriForEnerjiAlacaklari(AV001_TI_BIL_FOY foy)
        {
            if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));

            string aciklama = string.Empty;

            foreach (var item in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                if (!item.ALACAK_NEDEN_KOD_ID.HasValue) continue;
                switch (item.ALACAK_NEDEN_KOD_ID.Value)
                {
                    case 81://KA�AK ELEKTR�K FATURASI
                        if (!string.IsNullOrEmpty(foy.REFERANS_NO))
                            aciklama += string.Format("{0} nolu Abonenin Ka�ak Elektrik T�ketim Bedeli,{1}{2}{3}", foy.REFERANS_NO, Environment.NewLine, item.ACIKLAMA, Environment.NewLine);
                        else
                            aciklama += string.Format("(ABONES�Z) Ka�ak / Usuls�z Elektrik T�ketim Bedeli,{0}{1}{2}", Environment.NewLine, item.ACIKLAMA, Environment.NewLine);
                        break;

                    case 82://ELEKTR�K FATURASI
                        aciklama += string.Format("{0} no lu Abonenin Elektrik T�ketim Bedeli,{1}{2}{3}", foy.REFERANS_NO, Environment.NewLine, item.ACIKLAMA, Environment.NewLine);
                        break;

                    case 83://HASAR
                        aciklama += string.Format("Hasar Bedeli,{1}{2}{3}", foy.REFERANS_NO, Environment.NewLine, item.ACIKLAMA, Environment.NewLine);
                        break;

                    default:
                        break;
                }
            }
            return aciklama.Length > 2 ? aciklama.Remove(aciklama.Length - 2, 2) : aciklama;
        }

        public static string GetAllTarafsValues(AV001_TI_BIL_FOY myFoy, string field, bool Alacakli, bool Avukatmi)
        {
            string returnValue = "";
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myFoy, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>), typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(myFoy.AV001_TI_BIL_FOY_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF_VEKIL>));

            for (int i = 0; i < myFoy.AV001_TI_BIL_FOY_TARAFCollection.Count; i++)
            {
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(myFoy.AV001_TI_BIL_FOY_TARAFCollection[i], false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                if (Alacakli)
                {
                    if (myFoy.AV001_TI_BIL_FOY_TARAFCollection[i].TAKIP_EDEN_MI == true)
                    {
                        if (Avukatmi)
                        {
                            for (int y = 0; y < myFoy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection.Count; y++)
                            {
                                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.DeepLoad(myFoy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection[y], false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                                if (myFoy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection[y].AVUKAT_CARI_IDSource != null)
                                {
                                    returnValue += "Av. " + GetCariBilgisi(myFoy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection[y].AVUKAT_CARI_IDSource, field);
                                    if (myFoy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection.Count > 1)
                                    {
                                        returnValue += ",";
                                    }
                                }
                            }

                            if (string.IsNullOrEmpty(returnValue.Trim()))
                            {
                                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>), typeof(AV001_TDI_BIL_CARI));
                                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.DeepLoad(myFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));

                                for (int j = 0; j < myFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count; j++)
                                {
                                    returnValue += "Av. " + myFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[j].SORUMLU_AVUKAT_CARI_IDSource.AD;
                                    if (myFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count > 1)
                                    {
                                        returnValue += ",";
                                    }
                                }
                            }
                        }
                        else
                        {
                            returnValue += GetCariBilgisi(myFoy.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource, field) + ",";
                        }
                    }
                }

                if (!Alacakli)
                {
                    if (myFoy.AV001_TI_BIL_FOY_TARAFCollection[i].TAKIP_EDEN_MI == false)
                    {
                        returnValue += GetCariBilgisi(myFoy.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource, field) + ",";
                        if (Avukatmi)
                        {
                            for (int y = 0; y < myFoy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection.Count; y++)
                            {
                                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.DeepLoad(myFoy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection[y], false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                                returnValue += GetCariBilgisi(myFoy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection[y].AVUKAT_CARI_IDSource, field) + ",";
                            }
                        }
                    }
                }
            }
            return returnValue;
        }

        public static TList<AV001_TDI_BIL_ANTET> GetAntetBilgileri()
        {
            return DataRepository.AV001_TDI_BIL_ANTETProvider.GetAll();
        }

        public static string GetAracBilgisi(AV001_TI_BIL_FOY Foy)
        {
            string returnValue = "";
            decimal toplam = decimal.Zero;
            int aracSayisi = 0;
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(Foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));

            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(Foy.AV001_TI_BIL_ALACAK_NEDENCollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME>));

            List<int> eklenenSozlesmeler = new List<int>();

            for (int i = 0; i < Foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++)
            {
                TList<AV001_TDI_BIL_SOZLESME> lstSozlesmeler = Foy.AV001_TI_BIL_ALACAK_NEDENCollection[i].AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW;

                for (int y = 0; y < lstSozlesmeler.Count; y++)
                {
                    if (!eklenenSozlesmeler.Contains(lstSozlesmeler[y].ID))
                        eklenenSozlesmeler.Add(lstSozlesmeler[y].ID);
                    else
                        continue;

                    //sozlesmeSayisi++;
                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(lstSozlesmeler[y], false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>)/*, typeof(TDI_KOD_SOZLESME_ALT_TIP), typeof(TDI_KOD_SOZLESME_TIP)*/);

                    //string sozlesmeBilgisi = "";

                    //if (lstSozlesmeler[y].SOZLESME_ADI.Trim() != string.Empty)
                    //{
                    //    sozlesmeBilgisi += lstSozlesmeler[y].SOZLESME_ADI + " adl� s�zle�meden ";
                    //}

                    //if (lstSozlesmeler[y].SOZLESME_NO.Trim() != string.Empty)
                    //{
                    //    sozlesmeBilgisi += lstSozlesmeler[y].SOZLESME_NO + " no lu ";
                    //}
                    //if (lstSozlesmeler[y].ALT_TIP_ID.HasValue)
                    //{
                    //    sozlesmeBilgisi += lstSozlesmeler[y].ALT_TIP_IDSource.ALT_TIP + " tipli S�zle�meden ";
                    //}

                    TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> lstgemiUcakArac = lstSozlesmeler[y].AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SOZLESME_GEMI_UCAK_ARAC;

                    for (int z = 0; z < lstgemiUcakArac.Count; z++)
                    {
                        //if (lstSozlesmeler.Count > 1 && lstgemiUcakArac.Count == 1)
                        //{
                        //    returnValue += sozlesmeBilgisi + Environment.NewLine;
                        //}
                        string plaka = string.Empty;
                        string Model = string.Empty;
                        string tasitRenk = string.Empty;
                        string subesi = string.Empty;
                        string motorNo = string.Empty;
                        string sasiNo = string.Empty;

                        string tipi = string.Empty;
                        string ruhsatTarihi = string.Empty;
                        string ruhsatNo = string.Empty;
                        string liman = string.Empty;
                        string adi = string.Empty;
                        aracSayisi++;
                        if (lstgemiUcakArac[z].ADI.Trim() != string.Empty)
                        {
                            adi = lstgemiUcakArac[z].ADI.Trim() + " markal�, ";
                        }
                        if (lstgemiUcakArac[z].ARAC_PLAKA.Trim() != string.Empty)
                        {
                            plaka = lstgemiUcakArac[z].ARAC_PLAKA + " plakal� ,";
                        }
                        if (lstgemiUcakArac[z].ARAC_MODEL.Trim() != string.Empty)
                        {
                            Model = lstgemiUcakArac[z].ARAC_MODEL + " model, ";
                        }
                        if (lstgemiUcakArac[z].ARAC_RENK.Trim() != string.Empty)
                        {
                            tasitRenk = lstgemiUcakArac[z].ARAC_RENK + " renk, ";
                        }

                        //if (lstgemiUcakArac[z].TRAFIK_SUBESI.Trim() != string.Empty)
                        //{
                        //    subesi = lstgemiUcakArac[z].TRAFIK_SUBESI + "'nin, ";
                        //}

                        if (lstgemiUcakArac[z].ARAC_MOTOR_NO.Trim() != string.Empty)
                        {
                            motorNo = lstgemiUcakArac[z].ARAC_MOTOR_NO + " motor no'lu, ";
                        }

                        if (!string.IsNullOrEmpty(lstgemiUcakArac[z].ARAC_SASI_NO))
                        {
                            sasiNo = lstgemiUcakArac[z].ARAC_SASI_NO + " �asi no'lu, ";
                        }

                        //if (!string.IsNullOrEmpty(lstgemiUcakArac[z].ARAC_TIP))
                        //{
                        //    tipi = lstgemiUcakArac[z].ARAC_TIP + " tipli ,";
                        //}
                        //if (lstgemiUcakArac[z].RUHSAT_TARIHI.HasValue)
                        //{
                        //    ruhsatTarihi = lstgemiUcakArac[z].RUHSAT_TARIHI.Value.ToString("d") + " ruhsat tarihli,";
                        //}
                        //if (!string.IsNullOrEmpty(lstgemiUcakArac[z].RUHSAT_SICIL_NO))
                        //{
                        //    ruhsatNo = lstgemiUcakArac[z].RUHSAT_SICIL_NO + " sicil no'lu,";
                        //}
                        //if (!string.IsNullOrEmpty(lstgemiUcakArac[z].TRAFIK_SUBESI))
                        //{
                        //    liman = lstgemiUcakArac[z].TRAFIK_SUBESI + " Trafik �ube M�d�rl���'n�n";
                        //}

                        //string sozlesme = string.Format("{0} gere�ince rehnedilen ,"
                        //, lstSozlesmeler[y].TIP_IDSource.TIP);

                        returnValue += plaka + motorNo + sasiNo + adi + Model + tasitRenk + "ara�";
                        if (lstgemiUcakArac.Count > 1)
                        {
                            returnValue += string.Format(",{0}", Environment.NewLine);
                        }
                    }

                    if (lstSozlesmeler.Count > 1 && lstgemiUcakArac.Count == 1)
                    {
                        returnValue += "," + Environment.NewLine;
                    }

                    toplam += DovizHelper.CevirYTL(lstSozlesmeler[y].BEDELI, lstSozlesmeler[y].BEDELI_DOVIZ_ID ?? 1, lstSozlesmeler[y].IMZA_TARIHI ?? Foy.TAKIP_TARIHI.Value);
                }
            }
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(Foy, false, DeepLoadType.IncludeChildren, typeof(TI_KOD_FORM_TIP));

            if (Foy.FORM_TIP_IDSource.FORM_ORNEK_NO == "50" &&
                Foy.FORM_TIP_IDSource.FORM_ORNEK_NO == "54" &&
                Foy.FORM_TIP_IDSource.FORM_ORNEK_NO == "201" &&
                toplam != decimal.Zero)
            {
                SayiOkuma so = new SayiOkuma();
                returnValue += string.Format("{0}{1}Rehin Toplam� :{2} TL"
                , Environment.NewLine
                    , Environment.NewLine
                        , so.ParaFormatla(toplam));
            }
            if (aracSayisi == 0)
            {
                if (Foy.FORM_TIP_IDSource == null)
                {
                    AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(Foy, false, DeepLoadType.IncludeChildren, typeof(TI_KOD_FORM_TIP));
                }
                if (Foy.FORM_TIP_IDSource.FORM_ORNEK_NO == "50" || Foy.FORM_TIP_IDSource.FORM_ORNEK_NO == "201")
                {
                    returnValue = string.Format("Ara� Bilgisi Girilmemi�.{0}{1}"
                        , Environment.NewLine
                        , returnValue);
                }
            }

            //MB
            //if (sozlesmeSayisi == 0)
            //{
            //    if (Foy.FORM_TIP_IDSource.FORM_ORNEK_NO == "54" || Foy.FORM_TIP_IDSource.FORM_ORNEK_NO == "50" || Foy.FORM_TIP_IDSource.FORM_ORNEK_NO == "56" ||
            //        Foy.FORM_TIP_IDSource.FORM_ORNEK_NO == "51" || Foy.FORM_TIP_IDSource.FORM_ORNEK_NO == "201")
            //    {
            //        returnValue = string.Format("S�zle�me Bilgisi Girilmemi�.{0}{1}"
            //            , Environment.NewLine
            //            , returnValue);
            //    }
            //}
            return returnValue;
        }

        //efe
        public static List<TextField> GetBolumFromNesne(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
        {
            List<TextField> lstfields = new List<TextField>();

            if (foyum.SEGMENT_ID != null)
            {
                AvukatProLib2.Entities.TDI_KOD_SEGMENT segment = AvukatProLib2.Data.DataRepository.TDI_KOD_SEGMENTProvider.GetByID(foyum.SEGMENT_ID.Value);
                InsertTextField(segment.SEGMENT, segment.ID, "bolum", lstfields, "TDI_KOD_SEGMENT");
            }
            else
                InsertTextField("", -1, "bolum", lstfields, "TDI_KOD_SEGMENT");
            return lstfields;
        }

        public static string GetBugun()
        {
            return TarihBicimlendirme(DateTime.Now, false);
        }

        public static string GetBuSaat()
        {
            return DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
        }

        public static string GetCariBilgisi(AV001_TDI_BIL_CARI myCari, string field)
        {
            return TablesColumnData.GetColumnValueByNameFromRecord(myCari, field).Value.ToString();
        }

        public static int GetCopiesByTebligatMuhatab(uctxEditor editor, AvukatProLib2.Entities.AV001_TI_BIL_FOY foy)
        {
            //if (foy == null) return -1;
            TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> lstMuhatabs = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();
            TXTextControl.TextFieldCollectionBase.TextFieldEnumerator enms = editor.textControl1.TextFields.GetEnumerator();
            while (enms.MoveNext())
            {
                TextField tfAlan = ((TextField)enms.Current);
                if (!string.IsNullOrEmpty(tfAlan.Name))
                {
                    AV001_TDIE_BIL_SABLON_DEGISKENLER degisken = new AV001_TDIE_BIL_SABLON_DEGISKENLER();
                    try
                    {
                        degisken = DegiskenHelper.GetDegiskenByAd(((TextField)enms.Current).Name.Split(new string[] { "__" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                    }
                    catch
                    {
                    }
                    if (degisken.AD == "IcraBirinciHacizIhbarnameTarihi" || degisken.AD == "IcraIkinciHacizIhbarnameTarihi" || degisken.AD == "IcraUcuncuHacizIhbarnameTarihi")
                    {
                        for (int i = 0; i < lstMuhatabs.Count; i++)
                        {
                            lstMuhatabs = GetTebligatMuhatablari(foy, degisken);
                            uctxEditor edt = editor.Parentform.DublicateCurrentEditor();
                            edt.TebligatMuhatab = lstMuhatabs[i];
                        }
                    }
                }
            }
            return lstMuhatabs.Count;
        }

        public static int GetCopyCount(uctxEditor editor, AvukatProLib2.Entities.AV001_TI_BIL_FOY foy)
        {
            //   if (foy == null) return -1;
            List<int> lstTemsilID = new List<int>();
            TXTextControl.TextFieldCollectionBase.TextFieldEnumerator enms = editor.textControl1.TextFields.GetEnumerator();
            while (enms.MoveNext())
            {
                TextField tfAlan = ((TextField)enms.Current);
                if (!string.IsNullOrEmpty(tfAlan.Name))
                {
                    AV001_TDIE_BIL_SABLON_DEGISKENLER degisken = new AV001_TDIE_BIL_SABLON_DEGISKENLER();
                    try
                    {
                        degisken = DegiskenHelper.GetDegiskenByAd(((TextField)enms.Current).Name.Split(new string[] { "__" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                    }
                    catch
                    {
                    }
                    if (degisken.AD == "Temsilbilgisi" || degisken.AD == "TemsilNoterBilgisi" || degisken.AD == "TemsilYetkibilgisi" || degisken.AD == "TemsilYevmiyeBilgisi")
                    {
                        if (foy.AV001_TI_BIL_FOY_TARAFCollection == null || foy.AV001_TI_BIL_FOY_TARAFCollection.Count <= 0)
                        {
                            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));
                        }
                        AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(foy.AV001_TI_BIL_FOY_TARAFCollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF_VEKIL>), typeof(AV001_TDI_BIL_TEMSIL));

                        for (int i = 0; i < foy.AV001_TI_BIL_FOY_TARAFCollection.Count; i++)
                        {
                            for (int y = 0; y < foy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection.Count; y++)
                            {
                                if (!isinList(foy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection[y].TEMSIL_ID.Value, lstTemsilID))
                                {
                                    lstTemsilID.Add(foy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection[y].TEMSIL_ID.Value);
                                    uctxEditor edt = editor.Parentform.DublicateCurrentEditor();
                                    edt.Tag = foy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection[y].TEMSIL_ID.Value;
                                }
                            }
                        }
                    }
                }
            }
            return lstTemsilID.Count;
        }

        public static string GetCurrentUser()
        {
            AV001_TDI_BIL_CARI Cari = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(Kimlik.CurrentCariId);

            return Cari.AD;
        }

        public static DegiskenDegeri GetDAVA_Dava_Son_Durusma_Tarihi(AV001_TD_BIL_FOY foyum, bool DurusmaMi)
        {
            DegiskenDegeri returnValue = new DegiskenDegeri();
            returnValue.DonusTipi = DegiskenResulTType.String;

            if (foyum.AV001_TD_BIL_CELSECollection == null)
                return returnValue;

            DateTime tarih = new DateTime();
            foreach (AV001_TD_BIL_CELSE item in DataRepository.AV001_TD_BIL_CELSEProvider.GetByDAVA_FOY_ID(foyum.ID))
            {
                //celsemi 1 duru�ma else ke�if
                if (item.CELSE_MI == DurusmaMi)
                {
                    if (tarih == null)
                        tarih = item.TARIH;
                    else
                    {
                        if (tarih < item.TARIH)
                            tarih = item.TARIH;
                    }
                }
            }

            if (tarih != Convert.ToDateTime("01.01.0001"))
                returnValue.Icerik += tarih.ToShortDateString();
            else
                returnValue.Icerik += "";

            return returnValue;
        }

        public static DegiskenDegeri GetDAVA_Dava_Son_Karar_Tarihi(AV001_TD_BIL_FOY foyum)
        {
            DegiskenDegeri returnValue = new DegiskenDegeri();
            returnValue.DonusTipi = DegiskenResulTType.String;

            if (foyum.AV001_TD_BIL_MAHKEME_HUKUMCollection == null)
                return returnValue;

            DateTime tarih = new DateTime();
            foreach (AV001_TD_BIL_MAHKEME_HUKUM item in DataRepository.AV001_TD_BIL_MAHKEME_HUKUMProvider.GetByDAVA_FOY_ID(foyum.ID))
            {
                if (tarih == null)
                    tarih = item.HUKUM_TARIHI;
                else
                {
                    if (tarih < item.HUKUM_TARIHI)
                        tarih = item.HUKUM_TARIHI;
                }
            }

            if (tarih != Convert.ToDateTime("01.01.0001"))
                returnValue.Icerik += tarih.ToShortDateString();
            else
                returnValue.Icerik += "";

            return returnValue;
        }

        public static DegiskenDegeri GetDAVA_Dava_Son_Temyiz_Tarihi(AV001_TD_BIL_FOY foyum)
        {
            DegiskenDegeri returnValue = new DegiskenDegeri();
            returnValue.DonusTipi = DegiskenResulTType.String;

            DateTime tarih = new DateTime();
            foreach (AV001_TD_BIL_TEMYIZ item in DataRepository.AV001_TD_BIL_TEMYIZProvider.GetByDAVA_FOY_ID(foyum.ID))
            {
                foreach (AV001_TD_BIL_TEMYIZ_TARAF item2 in DataRepository.AV001_TD_BIL_TEMYIZ_TARAFProvider.GetByTEMYIZ_ID(item.ID))
                {
                    if (item2.TEMYIZ_TARIHI != null)
                    {
                        if (tarih == null)
                            tarih = item2.TEMYIZ_TARIHI.Value;
                        else
                        {
                            if (tarih < item2.TEMYIZ_TARIHI.Value)
                                tarih = item2.TEMYIZ_TARIHI.Value;
                        }
                    }
                }
            }

            if (tarih != Convert.ToDateTime("01.01.0001"))
                returnValue.Icerik += tarih.ToShortDateString();
            else
                returnValue.Icerik += "";

            return returnValue;
        }

        public static string GetDavaCezaKonusu(int foyid)
        {
            string rv = "";
            string yazi = "*DAVAED�LEN* isimli *sah�s/sah�slar*�n , i�lemi� *oldu�u/olduklar�* *DAVANEDENKONU* sucu nedeni ile cezland�r�lmas� istemidir.";

            AvukatProLib2.Entities.AV001_TD_BIL_FOY foyum = AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOYProvider.GetByID(foyid);
            AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(AV001_TD_BIL_DAVA_NEDEN));
            TList<AV001_TD_BIL_DAVA_NEDEN> lstdavanedenler = AvukatProLib2.Data.DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.GetByDAVA_FOY_ID(foyum.ID);
            AvukatProLib2.Data.DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.DeepLoad(lstdavanedenler, false, DeepLoadType.IncludeChildren, typeof(AV001_TD_BIL_DAVA_NEDEN_TARAF), typeof(TDI_KOD_DAVA_ADI), typeof(TDI_KOD_FAIZ_TIP), typeof(TDI_KOD_DAVA_ADI));

            for (int i = 0; i < lstdavanedenler.Count; i++)
            {
                rv = yazi;

                rv = rv.Replace("*DAVANEDENKONU*", lstdavanedenler[i].DIGER_DAVA_NEDEN);// DAVA_NEDEN_KOD_IDSource.DAVA_ADI);

                string davaedilenler = "";
                TList<AvukatProLib2.Entities.AV001_TD_BIL_DAVA_NEDEN_TARAF> lsttaraflar = AvukatProLib2.Data.DataRepository.AV001_TD_BIL_DAVA_NEDEN_TARAFProvider.GetByDAVA_NEDEN_ID(lstdavanedenler[i].ID);
                AvukatProLib2.Data.DataRepository.AV001_TD_BIL_DAVA_NEDEN_TARAFProvider.DeepLoad(lsttaraflar, false, DeepLoadType.IncludeChildren, typeof(TDIE_KOD_TARAF_SIFAT), typeof(AV001_TDI_BIL_CARI));
                for (int y = 0; y < lsttaraflar.Count; y++)
                {
                    if (lsttaraflar[y].TARAF_SIFAT_IDSource.HANGI_TARAFI == "DAVA ED�LEN")
                    {
                        davaedilenler += lsttaraflar[y].TARAF_SIFAT_IDSource.SIFAT + " " + lsttaraflar[y].TARAF_CARI_IDSource.AD + ",";
                    }
                }

                if (davaedilenler.Length > 0)
                {
                    davaedilenler = davaedilenler.Remove(davaedilenler.Length - 1, 1);
                    rv = rv.Replace("*DAVAED�LEN*", davaedilenler);
                }
                else
                {
                    rv = rv.Replace("*DAVAED�LEN*", "");
                    rv = rv.Replace("*sah�s/sah�slar*", "");
                }

                if (davaedilenler.Split(',').Length > 1)
                {
                }
                else
                {
                }

                if (davaedilenler.Split(',').Length > 1)
                {
                    rv = rv.Replace("*sah�s/sah�slar*", "�ah�slar");
                    rv = rv.Replace("*oldu�u/olduklar�*", "olduklar�");
                }
                else
                {
                    rv = rv.Replace("*sah�s/sah�slar*", "�ah�s");
                    rv = rv.Replace("*oldu�u/olduklar�*", "oldu�u");
                }
            }

            return rv;
        }

        public static List<TextField> GetDavaIdareKonusu(int foyid)
        {
            List<TextField> returnValue = new List<TextField>();

            string rv = "";
            string yazi2 = "*DAVAED�LEN* taraf�ndan taraf�m�za *TEBELLUGTARIHI* tarihinde tebli� edilen *OLAYTARIHI* tarihli ve *IDARIISLEMKONUSU* konulu i�leminin iptaline,";
            string yazi = "*DAVAEDEN* isimli *davaci/davacilar* i�in *DAVAED�LEN* isimli *daval�/daval�lar*dan , *DAVANEDENKONU* konulu dava ile ilgili olarak *DAVATUTARI* *DOV�ZT�P�* tutar�ndaki talebin *FA�ZBA�LANGI�TAR�H�* den  itibaren i�leyecek *FA�ZT�P�* faiziyle birlikte Al�nmas�na ,";
            AvukatProLib2.Entities.AV001_TD_BIL_FOY foyum = AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOYProvider.GetByID(foyid);
            AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(AV001_TD_BIL_DAVA_NEDEN));
            TList<AV001_TD_BIL_DAVA_NEDEN> lstdavanedenler = AvukatProLib2.Data.DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.GetByDAVA_FOY_ID(foyum.ID);
            AvukatProLib2.Data.DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.DeepLoad(lstdavanedenler, false, DeepLoadType.IncludeChildren, typeof(AV001_TD_BIL_DAVA_NEDEN_TARAF), typeof(TDI_KOD_DAVA_ADI), typeof(TDI_KOD_FAIZ_TIP), typeof(TDI_KOD_DAVA_ADI));

            for (int i = 0; i < lstdavanedenler.Count; i++)
            {
                if (lstdavanedenler[i].FAIZ_TALEP_TARIHI != null)
                {
                    rv = yazi;
                    rv = rv.Replace("*FA�ZBA�LANGI�TAR�H�*", lstdavanedenler[i].FAIZ_TALEP_TARIHI.Value.ToString().Remove(11));
                    GetTextField(lstdavanedenler[i].FAIZ_TALEP_TARIHI.Value.ToString().Remove(11), returnValue, "*FA�ZBA�LANGI�TAR�H�*");
                    if (lstdavanedenler[i].FAIZ_TIP_IDSource == null)
                    {
                        rv = rv.Replace("*FA�ZT�P�*", "<font face=\"arial\" size=\"3\" color=\"white\"  backcolor=\"red\"  style=\"background-color: red\">[ Faiz tipi girilmemi� ]</font>");
                        GetTextField("[ Faiz tipi girilmemi� ]", returnValue, "*FA�ZT�P�*");
                    }
                    else
                    {
                        rv = rv.Replace("*FA�ZT�P�*", lstdavanedenler[i].FAIZ_TIP_IDSource.FAIZ_TIP);
                        GetTextField(lstdavanedenler[i].FAIZ_TIP_IDSource.FAIZ_TIP, returnValue, "*FA�ZT�P�*");
                    }

                    SayiOkuma s = new SayiOkuma();
                    rv = rv.Replace("*DAVATUTARI*", s.ParaFormatla(lstdavanedenler[i].DAVA_EDILEN_TUTAR.ToString()) + "( " + s.paraOku(lstdavanedenler[i].DAVA_EDILEN_TUTAR.ToString()) + " ) ");
                    GetTextField(s.ParaFormatla(lstdavanedenler[i].DAVA_EDILEN_TUTAR.ToString()) + "( " + s.paraOku(lstdavanedenler[i].DAVA_EDILEN_TUTAR.ToString()) + " ) ", returnValue, "*DAVATUTARI*");
                    rv = rv.Replace("*DOV�ZT�P�*", BelgeUtil.Inits.DovizIdSource(lstdavanedenler[i].DAVA_EDILEN_TUTAR_DOVIZ_ID.Value).DOVIZ_KODU);

                    GetTextField(BelgeUtil.Inits.DovizIdSource(lstdavanedenler[i].DAVA_EDILEN_TUTAR_DOVIZ_ID.Value).DOVIZ_KODU, returnValue, "*DOV�ZT�P�*");

                    rv = rv.Replace("*DAVANEDENKONU*", lstdavanedenler[i].DIGER_DAVA_NEDEN);// DAVA_NEDEN_KOD_IDSource.DAVA_ADI);
                    GetTextField(lstdavanedenler[i].DIGER_DAVA_NEDEN, returnValue, "*DAVANEDENKONU*");
                }
                else
                {
                    rv = yazi2;
                    if (lstdavanedenler[i].TEBELLUG_TARIHI != null)
                    {
                        rv = rv.Replace("*TEBELLUGTARIHI*", lstdavanedenler[i].TEBELLUG_TARIHI.Value.ToString());
                        GetTextField(lstdavanedenler[i].TEBELLUG_TARIHI.Value.ToString(), returnValue, "*TEBELLUGTARIHI*");
                    }
                    else
                    {
                        rv = rv.Replace("*TEBELLUGTARIHI*", "[ L�tfen Tabellug tarihi giriniz ]");
                        GetTextField("[ L�tfen Tabellug tarihi giriniz ]", returnValue, "*TEBELLUGTARIHI*");
                    }
                    if (lstdavanedenler[i].OLAY_SUC_TARIHI != null)
                    {
                        rv = rv.Replace("*OLAYTARIHI*", lstdavanedenler[i].OLAY_SUC_TARIHI.Value.ToString());
                        GetTextField(lstdavanedenler[i].OLAY_SUC_TARIHI.Value.ToString(), returnValue, "*OLAYTARIHI*");
                    }
                    else
                    {
                        rv = rv.Replace("*OLAYTARIHI*", "<font face=\"arial\" size=\"3\" color=\"white\"  backcolor=\"red\"  style=\"background-color: red\">[ L�tfen Bir Olay Suc Tarihi Giriniz... ] </font>");
                        GetTextField("[ L�tfen Bir Olay Suc Tarihi Giriniz... ]", returnValue, "*OLAYTARIHI*");
                    }

                    if (string.IsNullOrEmpty(lstdavanedenler[i].TAKIP_ISLEM_SEKLI))
                    {
                        rv = rv.Replace("*IDARIISLEMKONUSU*", " <font face=\"arial\" size=\"3\" color=\"white\" backcolor=\"red\"  style=\"background-color: red\">[ Idari i�lem Konusu Girilmemi�... ]</font>");
                        GetTextField("[ Idari i�lem Konusu Girilmemi�... ]", returnValue, "*IDARIISLEMKONUSU*");
                    }
                    else
                    {
                        rv = rv.Replace("*IDARIISLEMKONUSU*", lstdavanedenler[i].TAKIP_ISLEM_SEKLI);
                        GetTextField(lstdavanedenler[i].TAKIP_ISLEM_SEKLI, returnValue, "*IDARIISLEMKONUSU*");
                    }
                }

                string davaedenler = "";
                string davaedilenler = "";

                List<TextField> lstDavaEdenler = new List<TextField>();
                List<TextField> lstDavaEdilenler = new List<TextField>();

                TList<AvukatProLib2.Entities.AV001_TD_BIL_DAVA_NEDEN_TARAF> lsttaraflar = AvukatProLib2.Data.DataRepository.AV001_TD_BIL_DAVA_NEDEN_TARAFProvider.GetByDAVA_NEDEN_ID(lstdavanedenler[i].ID);
                AvukatProLib2.Data.DataRepository.AV001_TD_BIL_DAVA_NEDEN_TARAFProvider.DeepLoad(lsttaraflar, false, DeepLoadType.IncludeChildren, typeof(TDIE_KOD_TARAF_SIFAT), typeof(AV001_TDI_BIL_CARI));
                for (int y = 0; y < lsttaraflar.Count; y++)
                {
                    if (lsttaraflar[y].TARAF_SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN")
                    {
                        davaedenler += lsttaraflar[y].TARAF_CARI_IDSource.AD + ",";
                        lstDavaEdenler.Add(new TextField(lsttaraflar[y].TARAF_CARI_IDSource.AD));
                    }
                    if (lsttaraflar[y].TARAF_SIFAT_IDSource.HANGI_TARAFI == "DAVA ED�LEN")
                    {
                        davaedilenler += lsttaraflar[y].TARAF_CARI_IDSource.AD + ",";
                        lstDavaEdilenler.Add(new TextField(lsttaraflar[y].TARAF_CARI_IDSource.AD));
                    }
                }

                if (davaedenler.Length > 0)
                {
                    davaedenler = davaedenler.Remove(davaedenler.Length - 1, 1);
                    rv = rv.Replace("*DAVAEDEN*", davaedenler);
                    GetTextField(returnValue, lstDavaEdenler, "*DAVAEDEN*");
                }
                else
                {
                    rv = rv.Replace("*DAVAEDEN*", "");
                    rv = rv.Replace("*davac�/davac�lar*", "");
                    GetTextField("", returnValue, "*DAVAEDEN*");
                }
                if (davaedilenler.Length > 0)
                {
                    davaedilenler = davaedilenler.Remove(davaedilenler.Length - 1, 1);
                    rv = rv.Replace("*DAVAED�LEN*", davaedilenler);
                    GetTextField(returnValue, lstDavaEdenler, "*DAVAED�LEN*");
                }
                else
                {
                    rv = rv.Replace("*DAVAED�LEN*", "");
                    rv = rv.Replace("*daval�/daval�lar*", "");
                    GetTextField("", returnValue, "*DAVAED�LEN*");
                }

                if (davaedenler.Split(',').Length > 1)
                {
                    rv = rv.Replace("*davaci/davacilar*", "davac�lar");
                    GetTextField("davac�lar", returnValue, "*davaci/davacilar*");
                }
                else
                {
                    rv = rv.Replace("*davaci/davacilar*", "davac�");
                    GetTextField(" davac� ", returnValue, "*davaci/davacilar*");
                }

                if (davaedilenler.Split(',').Length > 1)
                {
                    rv = rv.Replace("*daval�/daval�lar*", "daval�lar");
                    GetTextField("daval�lar", returnValue, "*davaci/davacilar*");
                }
                else
                {
                    rv = rv.Replace("*daval�/daval�lar*", "daval�");
                    GetTextField("daval�", returnValue, "*davaci/davacilar*");
                }
                if (lstdavanedenler[i].TEDBIR_TALEP_TARIHI != null)
                {
                    if (string.IsNullOrEmpty(lstdavanedenler[i].DAVA_EDILEN_TUTAR.ToString()))
                    {
                        rv += " i�lemle ilgili y�r�tmenin durdurulmas�na ,";
                    }
                    else
                    {
                        rv += " bu talebimiz ile ilgili dava sonucunda zarara ugramamam�z bak�m�ndan dava edilenim menkul, gayri menkul, mallar� ile ���nc� sah�slardaki hak ve alacaklar� �zerine tedbir uygulanmas�na ";
                    }
                }
            }

            return returnValue;
        }

        public static string GetDavaKonusu(int foyid)
        {
            string rv = "";
            string yazi = "*DAVAEDEN* isimli *davaci/davacilar* i�in *DAVAED�LEN* isimli *daval�/daval�lar*dan , *DAVANEDENKONU* konulu dava ile ilgili olarak *DAVATUTARI* *DOV�ZT�P�* tutar�ndaki talebin *FA�ZBA�LANGI�TAR�H�* den  itibaren i�leyecek *FA�ZT�P�* faiziyle birlikte Al�nmas�na ,";
            string yazi2 = "*DAVAEDEN* isimli *davaci/davacilar* i�in *DAVAED�LEN* isimli *daval�/daval�lar* ile ilgili , *DAVANEDENKONU* konulu talebinin ,";
            AvukatProLib2.Entities.AV001_TD_BIL_FOY foyum = AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOYProvider.GetByID(foyid);
            AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(AV001_TD_BIL_DAVA_NEDEN));
            TList<AV001_TD_BIL_DAVA_NEDEN> lstdavanedenler = AvukatProLib2.Data.DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.GetByDAVA_FOY_ID(foyum.ID);
            AvukatProLib2.Data.DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.DeepLoad(lstdavanedenler, false, DeepLoadType.IncludeChildren, typeof(AV001_TD_BIL_DAVA_NEDEN_TARAF), typeof(TDI_KOD_DAVA_ADI), typeof(TDI_KOD_FAIZ_TIP), typeof(TDI_KOD_DAVA_ADI));

            for (int i = 0; i < lstdavanedenler.Count; i++)
            {
                if (lstdavanedenler[i].FAIZ_TALEP_TARIHI != null)
                {
                    rv = yazi;
                    rv = rv.Replace("*FA�ZBA�LANGI�TAR�H�*", lstdavanedenler[i].FAIZ_TALEP_TARIHI.Value.ToString().Remove(11));
                    rv = rv.Replace("*FA�ZT�P�*", lstdavanedenler[i].FAIZ_TIP_IDSource.FAIZ_TIP);
                    SayiOkuma s = new SayiOkuma();
                    rv = rv.Replace("*DAVATUTARI*", s.ParaFormatla(lstdavanedenler[i].DAVA_EDILEN_TUTAR.ToString()) + "( " + s.paraOku(lstdavanedenler[i].DAVA_EDILEN_TUTAR.ToString()) + " ) ");
                    rv = rv.Replace("*DOV�ZT�P�*", BelgeUtil.Inits.DovizIdSource(lstdavanedenler[i].DAVA_EDILEN_TUTAR_DOVIZ_ID.Value).DOVIZ_KODU);
                }
                else
                {
                    rv = yazi2;
                }

                rv = rv.Replace("*DAVANEDENKONU*", lstdavanedenler[i].DIGER_DAVA_NEDEN);// DAVA_NEDEN_KOD_IDSource.DAVA_ADI);
                string davaedenler = "";
                string davaedilenler = "";
                TList<AvukatProLib2.Entities.AV001_TD_BIL_DAVA_NEDEN_TARAF> lsttaraflar = AvukatProLib2.Data.DataRepository.AV001_TD_BIL_DAVA_NEDEN_TARAFProvider.GetByDAVA_NEDEN_ID(lstdavanedenler[i].ID);
                AvukatProLib2.Data.DataRepository.AV001_TD_BIL_DAVA_NEDEN_TARAFProvider.DeepLoad(lsttaraflar, false, DeepLoadType.IncludeChildren, typeof(TDIE_KOD_TARAF_SIFAT), typeof(AV001_TDI_BIL_CARI));
                for (int y = 0; y < lsttaraflar.Count; y++)
                {
                    if (lsttaraflar[y].TARAF_SIFAT_IDSource.HANGI_TARAFI == "DAVA EDEN")
                    {
                        davaedenler += lsttaraflar[y].TARAF_CARI_IDSource.AD + ",";
                    }
                    if (lsttaraflar[y].TARAF_SIFAT_IDSource.HANGI_TARAFI == "DAVA ED�LEN")
                    {
                        davaedilenler += lsttaraflar[y].TARAF_CARI_IDSource.AD + ",";
                    }
                }
                if (davaedenler.Length > 0)
                {
                    davaedenler = davaedenler.Remove(davaedenler.Length - 1, 1);
                    rv = rv.Replace("*DAVAEDEN*", davaedenler);
                }
                else
                {
                    rv = rv.Replace("*DAVAEDEN*", "");
                    rv = rv.Replace("*davac�/davac�lar*", "");
                }
                if (davaedilenler.Length > 0)
                {
                    davaedilenler = davaedilenler.Remove(davaedilenler.Length - 1, 1);
                    rv = rv.Replace("*DAVAED�LEN*", davaedilenler);
                }
                else
                {
                    rv = rv.Replace("*DAVAED�LEN*", "");
                    rv = rv.Replace("*daval�/daval�lar*", "");
                }

                if (davaedenler.Split(',').Length > 1)
                {
                    rv = rv.Replace("*davaci/davacilar*", "davac�lar");
                }
                else
                {
                    rv = rv.Replace("*davaci/davacilar*", "davac�");
                }

                if (davaedilenler.Split(',').Length > 1)
                {
                    rv = rv.Replace("*daval�/daval�lar*", "daval�lar");
                }
                else
                {
                    rv = rv.Replace("*daval�/daval�lar*", "daval�");
                }
                if (lstdavanedenler[i].TEDBIR_TALEP_TARIHI != null)
                {
                    if (string.IsNullOrEmpty(lstdavanedenler[i].DAVA_EDILEN_TUTAR.ToString()))
                    {
                        rv += " i�lemle ilgili y�r�tmenin durdurulmas�na ,";
                    }
                    else
                    {
                        rv += " bu talebimiz ile ilgili dava sonucunda zarara ugramamam�z bak�m�ndan dava edilenim menkul, gayri menkul, mallar� ile ���nc� sah�slardaki hak ve alacaklar� �zerine tedbir uygulanmas�na ";
                    }
                }
            }

            return rv;
        }

        /// <summary>
        ///alacak nedenleri i�erisinde dolas�p , alacak neden kodlar� �zerinde (depo alaca�� ile ilgili
        ///olanlar� grupno alan� ile tipine gore ay�rm�s oldu�umuzdan) grup no ya gore tekrar bolumleyip
        ///alacak nedenlerini dovize grore tekrar gruplay�p toplam de�erlerini hesaplay�p
        /// alacak_nedeni i�leme_konan_tutar doviz_kodu
        /// +--------------------------------------------
        /// YTL_toplam d�viz_kodu
        /// doviz_grubuna_gore_adet i�leme_konan_tutar doviz_kodu
        /// toplam YTL_TOPLAM doviz_kodu alacka_neden_grup_ad� alaca��m�z�n
        /// �eklinde tablo halinde ��kt�s�d�r.
        /// </summary>
        /// <param name="foyum"></param>
        /// <returns>de�i�ken de�erini HTML veri olarak degiskendegeri tipinde geriye dondurur.</returns>
        public static DegiskenDegeri GetDepoAlacagi(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
        {
            DegiskenDegeri returnValue = new DegiskenDegeri();

            // Ada g�re de�i�kenleri getirir .
            returnValue.Degisken = DegiskenHelper.GetDegiskenByAd("Icra_Depo_Alacagi");
            returnValue.DonusTipi = DegiskenResulTType.HTML;
            SayiOkuma so = new SayiOkuma();
            returnValue.Icerik = "<table>";
            List<AlacakNedenGrubu> alacakNedenleri = new List<AlacakNedenGrubu>();
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));

            ////alacak nedenlerini tipine g�re gruplad�k
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(foyum.AV001_TI_BIL_ALACAK_NEDENCollection, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_DOVIZ_TIP), typeof(TI_KOD_ALACAK_NEDEN), typeof(TI_KOD_FORM_TIP));
            TList<AV001_TI_BIL_ALACAK_NEDEN> lstAlacakNedenleri = foyum.AV001_TI_BIL_ALACAK_NEDENCollection;
            for (int i = 0; i < lstAlacakNedenleri.Count; i++)
            {
                if (lstAlacakNedenleri[i].ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.Value)
                {
                    AlacakNedenGrubu.AlacakNedenGruplamaKontrolu(lstAlacakNedenleri[i], alacakNedenleri, foyum.TAKIP_TARIHI.Value);
                }
            }

            //�ek yapra��
            for (int i = 0; i < alacakNedenleri.Count; i++)
            {
                if (alacakNedenleri[i].AlacakNedenKodTipi.ALACAK_NEDEN_GRUP_NO == 1)
                {
                    List<AlacakNedenGrubu> alacakNedenDovizGruplu = alacakNedenleri[i].GetDovizeGoreGrup(foyum.TAKIP_TARIHI.Value);
                    for (int y = 0; y < alacakNedenDovizGruplu.Count; y++)
                    {
                        alacakNedenDovizGruplu[y].Hesapla();
                        string aciklama = "";
                        for (int z = 0; z < alacakNedenDovizGruplu[y].AlacakNedenleri.Count; z++)
                        {
                            returnValue.Icerik += "<tr><td>" + alacakNedenDovizGruplu[y].AlacakNedenleri[z].ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI + "</td><td>" + so.ParaFormatla(alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR) + " " + alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR_DOVIZ_IDSource.DOVIZ_KODU + "</td></tr>";
                            aciklama += alacakNedenDovizGruplu[y].Adet + " adet " + so.ParaFormatla(alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR) + " " + alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR_DOVIZ_IDSource.DOVIZ_KODU + " de�erindeki" + " ,";
                        }

                        string toplam = so.ParaFormatla(alacakNedenDovizGruplu[y].YtlToplam);
                        returnValue.Icerik += "<tr><td colspan=2><right>_+_______________________</right></td></tr>";

                        returnValue.Icerik += "<tr><td colspan=2>" + toplam + " " + alacakNedenDovizGruplu[y].Doviz.DOVIZ_KODU + "</td></tr>";
                        returnValue.Icerik += "<tr><td colspan=2>" + aciklama + "</td></tr>";
                        returnValue.Icerik += "<tr><td colspan=2> toplam " + toplam + " " + alacakNedenDovizGruplu[y].Doviz.DOVIZ_KODU + "  �ek yapra�� alaca��m�z�n </td></tr>";
                    }
                }

                //  MER`� TEM�NAT MEKTUBU alaca��m�z�n
                else if (alacakNedenleri[i].AlacakNedenKodTipi.ALACAK_NEDEN_GRUP_NO == 2)
                {
                    List<AlacakNedenGrubu> alacakNedenDovizGruplu = alacakNedenleri[i].GetDovizeGoreGrup(foyum.TAKIP_TARIHI.Value);
                    for (int y = 0; y < alacakNedenDovizGruplu.Count; y++)
                    {
                        alacakNedenDovizGruplu[y].Hesapla();
                        string aciklama = "";
                        for (int z = 0; z < alacakNedenDovizGruplu[y].AlacakNedenleri.Count; z++)
                        {
                            returnValue.Icerik += "<tr><td>" + alacakNedenDovizGruplu[y].AlacakNedenleri[z].ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI + "</td><td>" + so.ParaFormatla(alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR) + " " + alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR_DOVIZ_IDSource.DOVIZ_KODU + "</td></tr>";
                            aciklama += so.ParaFormatla(alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR) + " " + alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR_DOVIZ_IDSource.DOVIZ_KODU + " de�erindeki" + " ,";
                        }

                        string toplam = so.ParaFormatla(alacakNedenDovizGruplu[y].YtlToplam);
                        returnValue.Icerik += "<tr><td colspan=2>_+_______________________</td></tr>";
                        returnValue.Icerik += "<tr><td colspan=2>" + toplam + " " + alacakNedenDovizGruplu[y].Doviz.DOVIZ_KODU + "</td></tr>";
                        returnValue.Icerik += "<tr><td colspan=2>" + aciklama + "</td></tr>";
                        returnValue.Icerik += "<tr><td colspan=2> toplam " + toplam + " " + alacakNedenDovizGruplu[y].Doviz.DOVIZ_KODU + "   MER`� TEM�NAT MEKTUBU alaca��m�z�n </td></tr>";
                    }
                }

                //di�erleri
                else
                {
                    List<AlacakNedenGrubu> alacakNedenDovizGruplu = alacakNedenleri[i].GetDovizeGoreGrup(foyum.TAKIP_TARIHI.Value);
                    for (int y = 0; y < alacakNedenDovizGruplu.Count; y++)
                    {
                        alacakNedenDovizGruplu[y].Hesapla();
                        string aciklama = "";
                        for (int z = 0; z < alacakNedenDovizGruplu[y].AlacakNedenleri.Count; z++)
                        {
                            returnValue.Icerik += "<tr><td>" + alacakNedenDovizGruplu[y].AlacakNedenleri[z].ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI + "</td><td>" + so.ParaFormatla(alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR) + " " + alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR_DOVIZ_IDSource.DOVIZ_KODU + "</td></tr>";

                            aciklama += so.ParaFormatla(alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR) + " " + alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR_DOVIZ_IDSource.DOVIZ_KODU + " de�erindeki" + " ,";
                        }

                        string toplam = so.ParaFormatla(alacakNedenDovizGruplu[y].YtlToplam);
                        returnValue.Icerik += "<tr><td colspan=2>_+_______________________</td></tr>";
                        returnValue.Icerik += "<tr><td colspan=2>" + toplam + " " + alacakNedenDovizGruplu[y].Doviz.DOVIZ_KODU + "</td></tr>";
                        returnValue.Icerik += "<tr><td colspan=2>" + aciklama + "</td></tr>";

                        returnValue.Icerik += "<tr><td colspan=2> toplam " + toplam + " " + alacakNedenDovizGruplu[y].Doviz.DOVIZ_KODU + "   " + alacakNedenDovizGruplu[y].AlacakNedenKodTipi.ALACAK_NEDENI + " alaca��m�z�n </td></tr>";
                    }
                }
            }
            returnValue.Icerik += "</table>";
            return returnValue;
        }

        /// <summary>
        ///alacak nedenleri i�erisinde dolas�p , alacak neden kodlar� �zerinde (depo alaca�� ile ilgili
        ///olanlar� grupno alan� ile tipine gore ay�rm�s oldu�umuzdan) grup no ya gore tekrar bolumleyip
        ///alacak nedenlerini dovize grore tekrar gruplay�p toplam de�erlerini hesaplay�p
        /// alacak_nedeni i�leme_konan_tutar doviz_kodu
        /// YTL_toplam d�viz_kodu
        /// doviz_grubuna_gore_adet i�leme_konan_tutar doviz_kodu
        /// toplam YTL_TOPLAM doviz_kodu alacka_neden_grup_ad� alaca��m�z�n
        /// �eklinde string halinde ��kt�s�d�r.
        /// </summary>
        /// <param name="foyum"></param>
        /// <returns></returns>
        public static DegiskenDegeri GetDepoAlacagiString(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
        {
            DegiskenDegeri returnValue = new DegiskenDegeri();
            returnValue.Degisken = DegiskenHelper.GetDegiskenByAd("Icra_Depo_Alacagi");
            returnValue.DonusTipi = DegiskenResulTType.String;
            SayiOkuma so = new SayiOkuma();

            List<AlacakNedenGrubu> alacakNedenleri = new List<AlacakNedenGrubu>();
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));

            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(foyum.AV001_TI_BIL_ALACAK_NEDENCollection, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_DOVIZ_TIP), typeof(TI_KOD_ALACAK_NEDEN), typeof(TI_KOD_FORM_TIP));
            TList<AV001_TI_BIL_ALACAK_NEDEN> lstAlacakNedenleri = foyum.AV001_TI_BIL_ALACAK_NEDENCollection;
            for (int i = 0; i < lstAlacakNedenleri.Count; i++)
            {
                if (lstAlacakNedenleri[i].ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.Value)
                {
                    AlacakNedenGrubu.AlacakNedenGruplamaKontrolu(lstAlacakNedenleri[i], alacakNedenleri, foyum.TAKIP_TARIHI.Value);
                }
            }

            for (int i = 0; i < alacakNedenleri.Count; i++)
            {
                if (alacakNedenleri[i].AlacakNedenKodTipi.ALACAK_NEDEN_GRUP_NO == 1)
                {
                    List<AlacakNedenGrubu> alacakNedenDovizGruplu = alacakNedenleri[i].GetDovizeGoreGrup(foyum.TAKIP_TARIHI.Value);
                    for (int y = 0; y < alacakNedenDovizGruplu.Count; y++)
                    {
                        alacakNedenDovizGruplu[y].Hesapla();
                        string aciklama = "";
                        for (int z = 0; z < alacakNedenDovizGruplu[y].AlacakNedenleri.Count; z++)
                        {
                            returnValue.Icerik += alacakNedenDovizGruplu[y].AlacakNedenleri[z].ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI + " " + so.ParaFormatla(alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR) + " " + alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR_DOVIZ_IDSource.DOVIZ_KODU + ", ";
                            aciklama += alacakNedenDovizGruplu[y].Adet + " adet " + so.ParaFormatla(alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR) + " " + alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR_DOVIZ_IDSource.DOVIZ_KODU + " de�erindeki" + " ,";
                        }

                        string toplam = so.ParaFormatla(alacakNedenDovizGruplu[y].YtlToplam);

                        //   returnValue.Icerik += "<tr><td colspan=2><right>_+_______________________</right></td></tr>";

                        returnValue.Icerik += " " + toplam + " " + alacakNedenDovizGruplu[y].Doviz.DOVIZ_KODU + " ";
                        returnValue.Icerik += " >" + aciklama + " ";
                        returnValue.Icerik += "  toplam " + toplam + " " + alacakNedenDovizGruplu[y].Doviz.DOVIZ_KODU + "  �ek yapra�� alaca��m�z�n  ";
                    }
                }
                else if (alacakNedenleri[i].AlacakNedenKodTipi.ALACAK_NEDEN_GRUP_NO == 2)
                {
                    List<AlacakNedenGrubu> alacakNedenDovizGruplu = alacakNedenleri[i].GetDovizeGoreGrup(foyum.TAKIP_TARIHI.Value);
                    for (int y = 0; y < alacakNedenDovizGruplu.Count; y++)
                    {
                        alacakNedenDovizGruplu[y].Hesapla();
                        string aciklama = "";
                        for (int z = 0; z < alacakNedenDovizGruplu[y].AlacakNedenleri.Count; z++)
                        {
                            returnValue.Icerik += " " + alacakNedenDovizGruplu[y].AlacakNedenleri[z].ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI + " " + so.ParaFormatla(alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR) + " " + alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR_DOVIZ_IDSource.DOVIZ_KODU + " ";
                            aciklama += so.ParaFormatla(alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR) + " " + alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR_DOVIZ_IDSource.DOVIZ_KODU + " de�erindeki" + " ,";
                        }

                        string toplam = so.ParaFormatla(alacakNedenDovizGruplu[y].YtlToplam);

                        //  returnValue.Icerik += "<tr><td colspan=2>_+_______________________</td></tr>";
                        returnValue.Icerik += " " + toplam + " " + alacakNedenDovizGruplu[y].Doviz.DOVIZ_KODU + " ";
                        returnValue.Icerik += " " + aciklama + " ";
                        returnValue.Icerik += "  toplam " + toplam + " " + alacakNedenDovizGruplu[y].Doviz.DOVIZ_KODU + "   MER`� TEM�NAT MEKTUBU alaca��m�z�n  ";
                    }
                }
                else
                {
                    List<AlacakNedenGrubu> alacakNedenDovizGruplu = alacakNedenleri[i].GetDovizeGoreGrup(foyum.TAKIP_TARIHI.Value);
                    for (int y = 0; y < alacakNedenDovizGruplu.Count; y++)
                    {
                        alacakNedenDovizGruplu[y].Hesapla();
                        string aciklama = "";
                        for (int z = 0; z < alacakNedenDovizGruplu[y].AlacakNedenleri.Count; z++)
                        {
                            // returnValue.Icerik += " " + alacakNedenDovizGruplu[y].AlacakNedenleri[z].ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI + " " + so.ParaFormatla(alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR) + " " + alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR_DOVIZ_IDSource.DOVIZ_KODU + " ";

                            aciklama += so.ParaFormatla(alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR) + " " + alacakNedenDovizGruplu[y].AlacakNedenleri[z].ISLEME_KONAN_TUTAR_DOVIZ_IDSource.DOVIZ_KODU + " de�erindeki" + " ,";
                        }

                        string toplam = so.ParaFormatla(alacakNedenDovizGruplu[y].YtlToplam);

                        //returnValue.Icerik += "<tr><td colspan=2>_+_______________________</td></tr>";
                        //  returnValue.Icerik += " " + toplam + " " + alacakNedenDovizGruplu[y].Doviz.DOVIZ_KODU + " ";
                        returnValue.Icerik += " " + aciklama + " ";

                        returnValue.Icerik += " toplam " + toplam + " " + alacakNedenDovizGruplu[y].Doviz.DOVIZ_KODU + "   " + alacakNedenDovizGruplu[y].AlacakNedenKodTipi.ALACAK_NEDENI + " alaca��m�z�n  ";
                    }
                }
            }

            return returnValue;
        }

        public static string GetFormOrnekAciklamaFromNesne(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TI_KOD_FORM_TIP));
            string aciklama = string.Empty;

            if (BelgeUtil.Inits.PaketAdi == 1)
                switch (foyum.FORM_TIP_ID)
                {
                    case (int)FormTipleri.Form49:
                    case (int)FormTipleri.Form153:
                        aciklama = " ,�htarname ve eki hesap �zeti, kredi s�zle�meleri i�erir.";
                        break;

                    case (int)FormTipleri.Form50:
                        aciklama = " ,�htarname ve eki hesap �zeti kredi s�zle�meleri, rehin s�zle�mesi";
                        break;

                    case (int)FormTipleri.Form51:
                        aciklama = " ,Kira Kontratosu Sureti";
                        break;

                    case (int)FormTipleri.Form52:
                    case (int)FormTipleri.Form163:
                        if (BelgeUtil.Inits._AlacakNEdenGetir == null)
                            BelgeUtil.Inits._AlacakNEdenGetir = BelgeUtil.Inits.context.per_AV001_TI_BIL_ALACAK_NEDENs.ToList();
                        foreach (var item in BelgeUtil.Inits._AlacakNEdenGetir.FindAll(vi => vi.ICRA_FOY_ID == foyum.ID))
                        {
                            switch (item.ALACAK_NEDEN_KOD_ID)
                            {
                                case (int)AlacakNeden.Senet:
                                case (int)AlacakNeden.SENET_151:
                                case (int)AlacakNeden.SENET_152:
                                case (int)AlacakNeden.Senet_2:
                                case (int)AlacakNeden.SENET_201:
                                case (int)AlacakNeden.Senet_36:
                                case (int)AlacakNeden.Senet_38:
                                case (int)AlacakNeden.SENET_50:
                                    aciklama = " ,Sureti ve Protesto Evrak�";
                                    continue;
                                default:
                                    break;
                            }
                        }
                        break;

                    case (int)FormTipleri.Form53:
                        aciklama = " ,Karar �rne�i";
                        break;

                    case (int)FormTipleri.Form152:
                        aciklama = " ,�htarname ve Eki Hesap �zeti Kredi S�zle�meleri ve �potek Belge ve Resmi Suretleri";
                        break;

                    default:
                        break;
                }
            return foyum.FORM_TIP_IDSource.YENI_FORM_ORNEK_NO + " �rnek " + DegiskenAraclari.FormTip.GetFormTipOzet(foyum.FORM_TIP_ID.Value) + aciklama;
        }

        public static string GetfoyBilgisiFromNesne(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum, string kolon)
        {
            return TablesColumnData.GetColumnValueByNameFromRecord(foyum, kolon).Value.ToString();
        }

        public static string GetfoyBilgisiFromNesne(AvukatProLib2.Entities.AV001_TD_BIL_FOY foyum, string kolon)
        {
            object sonuc = TablesColumnData.GetColumnValueByNameFromRecord(foyum, kolon).Value;

            if (sonuc == null)
                return "";
            else
                return TablesColumnData.GetColumnValueByNameFromRecord(foyum, kolon).Value.ToString();
        }

        public static string GetFoyNo(AV001_TI_BIL_FOY myFoy)
        {
            return myFoy.FOY_NO;
        }

        public static string GetFoyNo(AV001_TD_BIL_FOY myFoy)
        {
            return myFoy.FOY_NO;
        }

        public static List<TextField> GetfoyTakipTarihiFromNesne(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
        {
            List<TextField> lstfields = new List<TextField>();

            lstfields.Add(new TextField(foyum.TAKIP_TARIHI.Value.ToString().Replace('.', '/').Remove(11)));
            return lstfields;
        }

        public static List<TextField> GetGayrimenkulBilgisi(AV001_TI_BIL_FOY foyid, string kolon)
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyid, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>), typeof(TList<AV001_TI_BIL_GAYRIMENKUL>));
            TList<AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN> lstNdn = foyid.AV001_TI_BIL_ALACAK_NEDENCollection;

            TList<AV001_TI_BIL_GAYRIMENKUL> lstGayriMenkuls = foyid.AV001_TI_BIL_GAYRIMENKULCollection;
            for (int i = 0; i < lstNdn.Count; i++)
            {
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(lstNdn[i], false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_GAYRIMENKUL>));

                for (int y = 0; y < lstNdn[i].AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKUL.Count; y++)
                {
                    lstGayriMenkuls.Add(lstNdn[i].AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKUL[y]);
                }
            }

            List<TextField> returnValues = new List<TextField>();
            for (int i = 0; i < lstGayriMenkuls.Count; i++)
            {
                InsertTextField(TablesColumnData.GetColumnValueByNameFromRecord(lstGayriMenkuls[i], kolon).Value.ToString(), lstGayriMenkuls[i].ID, kolon, returnValues, "AV001_TI_BIL_GAYRIMENKUL");
            }
            return returnValues;
        }

        public static void GetGayrimenkulGenelBilgileri(AV001_TI_BIL_FOY foyum, TextControl tControl, int startIndex, bool useTable)
        {
            List<List<TextField>> lstFields = new List<List<TextField>>();
            List<TextField> lstMahalle = GetGayrimenkulBilgisi(foyum, "MAHALLE_ADI");
            List<TextField> lstAda = GetGayrimenkulBilgisi(foyum, "ADA_NO");
            List<TextField> lstPafta = GetGayrimenkulBilgisi(foyum, "PAFTA_NO");
            List<TextField> lstParsel = GetGayrimenkulBilgisi(foyum, "PARSEL_NO");
            List<TextField> lstM2 = GetGayrimenkulBilgisi(foyum, "YUZOLCUMU_DM2");
            List<TextField> lstArsaPayi = GetGayrimenkulBilgisi(foyum, "ARSA_PAYI");
            List<TextField> lstNiteliks = GetGayrimenkulBilgisi(foyum, "NITELIGI");
            List<TextField> lstIl = GetGayrimenkulBilgisi(foyum, "IL_ID");
            List<TextField> lstIlce = GetGayrimenkulBilgisi(foyum, "ILCE_ID");
            List<TextField> lstCilt = GetGayrimenkulBilgisi(foyum, "CILT_NO");
            List<TextField> lstTarih = GetGayrimenkulBilgisi(foyum, "TARIHI");

            lstFields.Add(lstMahalle);
            lstFields.Add(lstAda);
            lstFields.Add(lstPafta);
            lstFields.Add(lstParsel);
            lstFields.Add(lstM2);
            lstFields.Add(lstArsaPayi);
            lstFields.Add(lstNiteliks);
            lstFields.Add(lstIl);
            lstFields.Add(lstIlce);

            int sutun = 1;
            int satir = 1;
            bool tableCreated = false;
            Table tbl = tControl.Tables.GetItem();
            for (int j = 1; j < lstFields[0].Count; j++)
            {
                for (int a = 0; a < lstFields.Count; a++)
                {
                    if (!tableCreated && useTable)
                    {
                        if (!tableCreated)
                        {
                            int tid = tableCounter + 200;
                            tableCounter++;
                            tControl.Tables.Add(4, 4, tid);
                            tbl = tControl.Tables.GetItem(tid);
                            tableCreated = true;
                        }

                        if (useTable)
                        {
                            tbl.Cells.GetItem(satir, sutun).Text = lstFields[a][j].Text;
                        }
                    }
                    else
                    {
                        tControl.TextFields.Add(lstFields[a][j]);
                    }

                    if (sutun == 4)
                    {
                        sutun = 1;
                        satir++;
                    }

                    sutun++;
                }
            }
        }

        public static string GetGayrimenkulIpotekBilgisi(AV001_TI_BIL_FOY foyid, bool malikBilgileriGelsin)
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyid, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>), typeof(TList<AV001_TI_BIL_GAYRIMENKUL>), typeof(TList<AV001_TDI_BIL_SOZLESME>));
            TList<AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN> lstNdn = foyid.AV001_TI_BIL_ALACAK_NEDENCollection;
            string ReturnValue = "";
            decimal toplam = decimal.Zero;
            string doviztipi = "";

            SayiOkuma so = new SayiOkuma();

            for (int a = 0; a < lstNdn.Count; a++)
            {
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(lstNdn[a], false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME>));

                TList<AV001_TDI_BIL_SOZLESME> sozlesmeler = lstNdn[a].AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW;

                for (int i = 0; i < sozlesmeler.Count; i++)
                {
                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(sozlesmeler[i], false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_GAYRIMENKUL>));

                    if (sozlesmeler[i].ALT_TIP_ID.HasValue)
                    {
                        if (sozlesmeler[i].ALT_TIP_ID.Value == 5)
                        {
                            if (ReturnValue.Length > 0)
                                ReturnValue += Environment.NewLine;

                            DateTime dt = DateTime.Now;
                            if (sozlesmeler[i].BASLANGIC_TARIHI.HasValue)
                            {
                                dt = sozlesmeler[i].BASLANGIC_TARIHI.Value;
                            }

                            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(sozlesmeler[i], false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_DOVIZ_TIP), typeof(TList<AV001_TDI_BIL_SOZLESME_DERECE>), typeof(TList<AV001_TI_BIL_GAYRIMENKUL>));

                            ReturnValue += dt.ToString("dd.MM.yyyy") + " Trh. ";

                            for (int f = 0; f < sozlesmeler[i].AV001_TDI_BIL_SOZLESME_DERECECollection.Count; f++)
                            {
                                ReturnValue += sozlesmeler[i].AV001_TDI_BIL_SOZLESME_DERECECollection[f].DERECESI + " dereceden " + sozlesmeler[i].AV001_TDI_BIL_SOZLESME_DERECECollection[f].SIRASI + " s�rada.";
                            }

                            ReturnValue += so.ParaFormatla(sozlesmeler[i].BEDELI) + "-" + sozlesmeler[i].BEDELI_DOVIZ_IDSource.DOVIZ_KODU + " �potek ";

                            TList<AV001_TI_BIL_GAYRIMENKUL> lstGayriMenkuls = sozlesmeler[i].AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL;
                            TList<NN_SOZLESME_GAYRIMENKUL> gymkls = AvukatProLib2.Data.DataRepository.NN_SOZLESME_GAYRIMENKULProvider.GetBySOZLESME_ID(sozlesmeler[i].ID);
                            if (gymkls.Count == 0)
                            {
                                MessageBox.Show("Gayrimenkul kayd� yap�lmam��...");
                            }
                            for (int y = 0; y < lstGayriMenkuls.Count; y++)
                            {
                                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(lstGayriMenkuls[y], false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE), typeof(TList<AV001_TI_BIL_GAYRIMENKUL_TARAF>));
                                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_GAYRIMENKUL_TARAFProvider.DeepLoad(lstGayriMenkuls[y].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection, false, DeepLoadType.IncludeChildren, typeof(TI_KOD_GAYRIMENKUL_TARAF_SIFAT), typeof(AV001_TDI_BIL_CARI));
                                ReturnValue += Environment.NewLine + "Rehin Edilen : ";

                                if (lstGayriMenkuls[y].IL_ID.HasValue)
                                {
                                    ReturnValue += lstGayriMenkuls[y].IL_IDSource.IL;
                                    ReturnValue += " ili ";
                                }
                                if (lstGayriMenkuls[y].ILCE_ID.HasValue)
                                {
                                    ReturnValue += lstGayriMenkuls[y].ILCE_IDSource.ILCE;
                                    ReturnValue += " il�esi ";
                                }
                                if (lstGayriMenkuls[y].MAHALLE_ADI.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].MAHALLE_ADI;
                                    ReturnValue += " mahallesi ";
                                }

                                if (lstGayriMenkuls[y].BUCAK.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].BUCAK;
                                    ReturnValue += " buca�� ";
                                }

                                if (lstGayriMenkuls[y].MAHALLE_ADI.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].MAHALLE_ADI;
                                    ReturnValue += " mahallesi ";
                                }

                                if (lstGayriMenkuls[y].KOY_ADI.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].KOY_ADI;
                                    ReturnValue += " k�y� ";
                                }

                                if (lstGayriMenkuls[y].SOKAK_ADI.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].SOKAK_ADI;
                                    ReturnValue += " soka�� ";
                                }

                                if (lstGayriMenkuls[y].MEVKI_ADI.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].MEVKI_ADI;
                                    ReturnValue += " mevkii ";
                                }

                                if (lstGayriMenkuls[y].PAFTA_NO.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].PAFTA_NO;
                                    ReturnValue += " pafta nolu ";
                                }
                                if (lstGayriMenkuls[y].ADA_NO.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].ADA_NO;
                                    ReturnValue += " ada no ";
                                }
                                if (lstGayriMenkuls[y].PARSEL_NO.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].PARSEL_NO;
                                    ReturnValue += " parsel nolu ";
                                }

                                if (lstGayriMenkuls[y].YEVMIYE_NO.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].YEVMIYE_NO;
                                    ReturnValue += " yevmiye nolu ";
                                }

                                if (lstGayriMenkuls[y].CILT_NO.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].CILT_NO;
                                    ReturnValue += " cilt nolu ";
                                }
                                if (lstGayriMenkuls[y].SAHIFE_NO.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].SAHIFE_NO;
                                    ReturnValue += " sahife nolu ";
                                }
                                if (lstGayriMenkuls[y].SIRA_NO.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].SIRA_NO;
                                    ReturnValue += " s�ra nolu ";
                                }

                                if (lstGayriMenkuls[y].YUZOLCUMU_HEKTAR.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].YUZOLCUMU_HEKTAR;
                                    ReturnValue += " hektar ";
                                }
                                if (lstGayriMenkuls[y].YUZOLCUMU_DEKAR.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].YUZOLCUMU_DEKAR;
                                    ReturnValue += " dekar ";
                                }
                                if (lstGayriMenkuls[y].YUZOLCUMU_DM2.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].YUZOLCUMU_DM2;
                                    ReturnValue += " desimetre kare ";
                                }

                                if (lstGayriMenkuls[y].ARSA_PAYI.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].ARSA_PAYI;
                                    ReturnValue += " arsa payl� ";
                                }

                                if (lstGayriMenkuls[y].KAT_NO.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].KAT_NO;
                                    ReturnValue += " kat nolu ";
                                }

                                if (lstGayriMenkuls[y].BAGIMSIZ_BOLUM_NO.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].BAGIMSIZ_BOLUM_NO;
                                    ReturnValue += " b�l�ml� ";
                                }

                                if (lstGayriMenkuls[y].NITELIGI.Trim() != string.Empty)
                                {
                                    ReturnValue += lstGayriMenkuls[y].NITELIGI;
                                    ReturnValue += " nitelikli ta��nmaz ";
                                }

                                ReturnValue += Environment.NewLine;

                                if (malikBilgileriGelsin)
                                {
                                    if (lstGayriMenkuls[y].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection.Count >= 1)
                                    {
                                        ReturnValue += " Maliki : ";
                                    }
                                    for (int z = 0; z < lstGayriMenkuls[y].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection.Count; z++)
                                    {
                                        #region For

                                        if (lstGayriMenkuls[y].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection[z].TARAF_SIFAT_ID.HasValue)
                                        {
                                            if (lstGayriMenkuls[y].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection[z].TARAF_SIFAT_ID.Value == 1)
                                            {
                                                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(lstGayriMenkuls[y].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection[z].TARAF_CARI_IDSource, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE), typeof(TDI_KOD_ULKE));
                                                ReturnValue += lstGayriMenkuls[y].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection[z].TARAF_CARI_IDSource.AD + Environment.NewLine;
                                                ReturnValue += lstGayriMenkuls[y].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection[z].TARAF_CARI_IDSource.ADRES_1 + " ";

                                                if (lstGayriMenkuls[y].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection[z].TARAF_CARI_IDSource.ILCE_ID.HasValue)
                                                {
                                                    ReturnValue += lstGayriMenkuls[y].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection[z].TARAF_CARI_IDSource.ILCE_IDSource.ILCE + " ";
                                                }

                                                if (lstGayriMenkuls[y].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection[z].TARAF_CARI_IDSource.IL_ID.HasValue)
                                                {
                                                    ReturnValue += lstGayriMenkuls[y].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection[z].TARAF_CARI_IDSource.IL_IDSource.IL + " ";
                                                }

                                                if (lstGayriMenkuls[y].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection[z].TARAF_CARI_IDSource.ULKE_ID.HasValue)
                                                {
                                                    ReturnValue += lstGayriMenkuls[y].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection[z].TARAF_CARI_IDSource.ULKE_IDSource.ULKE;
                                                }

                                                if (lstGayriMenkuls[y].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection.Count > 1)
                                                {
                                                    ReturnValue += " , ";
                                                }

                                                if (y == lstGayriMenkuls[y].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection.Count - 1)
                                                {
                                                    ReturnValue += "  ";
                                                }
                                            }
                                        }

                                        #endregion For
                                    }
                                }
                            }

                            toplam += DovizHelper.CevirYTL(sozlesmeler[i].BEDELI, sozlesmeler[i].BEDELI_DOVIZ_ID.Value, dt);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sozlesme Alt Tipi Belirtilmemi�...");
                    }
                }
                if (toplam != decimal.Zero && malikBilgileriGelsin)
                {
                    doviztipi = BelgeUtil.Inits.DovizIdSource(1).DOVIZ_KODU;
                    ReturnValue += string.Format("{0}       ______________________________+___{1} Toplam : {2}{3} de�erindeki {4} adet s�zle�meden "
                    , Environment.NewLine
                        , Environment.NewLine
                            , so.ParaFormatla(toplam)
                                , doviztipi
                                    , sozlesmeler.Count);
                }
            }
            return ReturnValue;
        }

        public static List<TextField> GetHacizBilgisi(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum, TextControl tCnt, int startIndex)
        {
            List<TextField> lstFields = new List<TextField>();
            TList<AvukatProLib2.Entities.AV001_TI_BIL_HACIZ_MASTER> lstHaciz = AvukatProLib2.Data.DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.GetByICRA_FOY_ID(foyum.ID);

            for (int i = 0; i < lstHaciz.Count; i++)
            {
                InsertTextField(lstHaciz[i].HACIZ_TARIHI.ToString(), lstHaciz[i].ID, "hacizTarih", lstFields, "AV001_TI_BIL_HACIZ_MASTER");
            }

            return lstFields;
        }

        public static List<TextField> GetHacizMahkeme(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum, TextControl tCnt, int startIndex)
        {
            List<TextField> lstFields = new List<TextField>();
            TList<AvukatProLib2.Entities.AV001_TI_BIL_HACIZ_MASTER> lstHaciz = AvukatProLib2.Data.DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.GetByICRA_FOY_ID(foyum.ID);

            for (int i = 0; i < lstHaciz.Count; i++)
            {
                InsertTextField(lstHaciz[i].TALIMAT_ADLI_BIRIM_ADLIYE_IDSource.ADLIYE, lstHaciz[i].ID, "hacizTarih", lstFields, "AV001_TI_BIL_HACIZ_MASTER");
                InsertTextField(lstHaciz[i].TALIMAT_ADLI_BIRIM_GOREV_IDSource.GOREV, lstHaciz[i].ID, "hacizTarih", lstFields, "AV001_TI_BIL_HACIZ_MASTER");
                InsertTextField(lstHaciz[i].TALIMAT_ADLI_BIRIM_NO_IDSource.NO, lstHaciz[i].ID, "hacizTarih", lstFields, "AV001_TI_BIL_HACIZ_MASTER");
            }

            return lstFields;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="myFoy"></param>
        /// <param name="tcnt"></param>
        /// <returns></returns>
        public static string GetHarcDetayi(AV001_TI_BIL_FOY myFoy, TextControl tcnt)
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myFoy, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_DOVIZ_TIP));
            int rowCount = 0;

            if (decimalControl(myFoy.BASVURMA_HARCI))
            {
                rowCount++;
            }
            if (decimalControl(myFoy.VEKALET_HARCI))
            {
                rowCount++;
            }
            if (decimalControl(myFoy.PAYLASMA_HARCI))
            {
                rowCount++;
            }
            if (decimalControl(myFoy.DIGER_HARC))
            {
                rowCount++;
            }
            if (decimalControl(myFoy.FERAGAT_HARCI))
            {
                rowCount++;
            }
            if (decimalControl(myFoy.IFLAS_BASVURMA_HARCI))
            {
                rowCount++;
            }
            if (decimalControl(myFoy.IFLASIN_ACILMASI_HARCI))
            {
                rowCount++;
            }
            if (decimalControl(myFoy.KALAN_TAHSIL_HARCI))
            {
                rowCount++;
            }
            if (decimalControl(myFoy.MASAYA_KATILMA_HARCI))
            {
                rowCount++;
            }
            if (decimalControl(myFoy.ODENEN_TAHSIL_HARCI))
            {
                rowCount++;
            }
            if (decimalControl(myFoy.PESIN_HARC))
            {
                rowCount++;
            }
            if (decimalControl(myFoy.TAHLIYE_HARCI))
            {
                rowCount++;
            }
            if (decimalControl(myFoy.TD_BAKIYE_HARC))
            {
                rowCount++;
            }
            if (decimalControl(myFoy.TESLIM_HARCI))
            {
                rowCount++;
            }

            tcnt.Selection.Text += "Har� Detay� " + Environment.NewLine;
            tableCounter = 300;
            if (rowCount != 0)
            {
                tcnt.Tables.Add(rowCount + 2, 2, tableCounter);
            }

            Table tbl = tcnt.Tables.GetItem(tableCounter);
            tableCounter++;
            int siradaki = 1;

            if (decimalControl(myFoy.BASVURMA_HARCI))
            {
                tbl.Cells.GetItem(siradaki, 1).Text = "BH ";
                tbl.Cells.GetItem(siradaki, 2).Text = myFoy.BASVURMA_HARCI + " " + myFoy.BASVURMA_HARCI_DOVIZ_IDSource.DOVIZ_KODU;

                siradaki++;
            }
            if (decimalControl(myFoy.VEKALET_HARCI))
            {
                tbl.Cells.GetItem(siradaki, 1).Text = "VH ";
                tbl.Cells.GetItem(siradaki, 2).Text = myFoy.VEKALET_HARCI + " " + myFoy.VEKALET_HARCI_DOVIZ_IDSource.DOVIZ_KODU;

                siradaki++;
            }
            if (decimalControl(myFoy.PAYLASMA_HARCI))
            {
                tbl.Cells.GetItem(siradaki, 1).Text = "Pay Harci ";
                tbl.Cells.GetItem(siradaki, 2).Text = myFoy.PESIN_HARC + " " + myFoy.PESIN_HARC_DOVIZ_IDSource.DOVIZ_KODU;

                siradaki++;
            }
            if (decimalControl(myFoy.DIGER_HARC))
            {
                tbl.Cells.GetItem(siradaki, 1).Text = "Di�er Har� ";
                tbl.Cells.GetItem(siradaki, 2).Text = myFoy.DIGER_HARC + " " + myFoy.DIGER_HARC_DOVIZ_IDSource.DOVIZ_KODU;

                siradaki++;
            }
            if (decimalControl(myFoy.FERAGAT_HARCI))
            {
                tbl.Cells.GetItem(siradaki, 1).Text = "Feragat Harci ";
                tbl.Cells.GetItem(siradaki, 2).Text = myFoy.FERAGAT_HARCI + " " + myFoy.FERAGAT_HARCI_DOVIZ_IDSource.DOVIZ_KODU;

                siradaki++;
            }
            if (decimalControl(myFoy.IFLAS_BASVURMA_HARCI))
            {
                tbl.Cells.GetItem(siradaki, 1).Text = "�flas Ba�vurma Harc�";
                tbl.Cells.GetItem(siradaki, 2).Text = myFoy.IFLAS_BASVURMA_HARCI + " " + myFoy.IFLAS_BASVURMA_HARCI_DOVIZ_IDSource.DOVIZ_KODU;

                siradaki++;
            }
            if (decimalControl(myFoy.IFLASIN_ACILMASI_HARCI))
            {
                tbl.Cells.GetItem(siradaki, 1).Text = "�flas�n A��lmas� Harc�";
                tbl.Cells.GetItem(siradaki, 2).Text = myFoy.IFLASIN_ACILMASI_HARCI + " " + myFoy.IFLASIN_ACILMASI_HARCI_DOVIZ_IDSource.DOVIZ_KODU;

                siradaki++;
            }
            if (decimalControl(myFoy.KALAN_TAHSIL_HARCI))
            {
                tbl.Cells.GetItem(siradaki, 1).Text = "kalan tahsil Harc� ";
                tbl.Cells.GetItem(siradaki, 2).Text = myFoy.KALAN_TAHSIL_HARCI + " " + myFoy.KALAN_TAHSIL_HARCI_DOVIZ_IDSource.DOVIZ_KODU;

                siradaki++;
            }
            if (decimalControl(myFoy.MASAYA_KATILMA_HARCI))
            {
                tbl.Cells.GetItem(siradaki, 1).Text = "Masaya Kat�lma Harc� ";
                tbl.Cells.GetItem(siradaki, 2).Text = myFoy.MASAYA_KATILMA_HARCI + " " + myFoy.MASAYA_KATILMA_HARCI_DOVIZ_IDSource.DOVIZ_KODU;

                siradaki++;
            }
            if (decimalControl(myFoy.ODENEN_TAHSIL_HARCI))
            {
                tbl.Cells.GetItem(siradaki, 1).Text = "�denen Tahsil Harci ";
                tbl.Cells.GetItem(siradaki, 2).Text = myFoy.ODENEN_TAHSIL_HARCI + " " + myFoy.ODENEN_TAHSIL_HARCI_DOVIZ_IDSource.DOVIZ_KODU;

                siradaki++;
            }
            if (decimalControl(myFoy.PESIN_HARC))
            {
                tbl.Cells.GetItem(siradaki, 1).Text = "Pe�im Har� ";
                tbl.Cells.GetItem(siradaki, 2).Text = myFoy.PESIN_HARC + " " + myFoy.PESIN_HARC_DOVIZ_IDSource.DOVIZ_KODU;

                siradaki++;
            }
            if (decimalControl(myFoy.TAHLIYE_HARCI))
            {
                tbl.Cells.GetItem(siradaki, 1).Text = "Tahliye Harci ";
                tbl.Cells.GetItem(siradaki, 2).Text = myFoy.TAHLIYE_HARCI + " " + myFoy.TAHLIYE_HARCI_DOVIZ_IDSource.DOVIZ_KODU;

                siradaki++;
            }
            if (decimalControl(myFoy.TD_BAKIYE_HARC))
            {
                tbl.Cells.GetItem(siradaki, 1).Text = "Bakiye Harci ";
                tbl.Cells.GetItem(siradaki, 2).Text = myFoy.TD_BAKIYE_HARC + " " + myFoy.TD_BAKIYE_HARC_DOVIZ_IDSource.DOVIZ_KODU;

                siradaki++;
            }
            if (decimalControl(myFoy.TESLIM_HARCI))
            {
                tbl.Cells.GetItem(siradaki, 1).Text = "Teslim Harci ";
                tbl.Cells.GetItem(siradaki, 2).Text = myFoy.TESLIM_HARCI + " " + myFoy.TESLIM_HARCI_DOVIZ_IDSource.DOVIZ_KODU;

                siradaki++;
            }

            if (tbl != null)
            {
                tbl.Cells.GetItem(siradaki, 2).Text = "_+___________________";
                siradaki++;
            }

            if (decimalControl(myFoy.HARC_TOPLAMI))
            {
                tbl.Cells.GetItem(siradaki, 2).Text = myFoy.HARC_TOPLAMI.Value + " " + myFoy.HARC_TOPLAMI_DOVIZ_IDSource.DOVIZ_KODU;

                //tbl.Cells.GetItem(siradaki, 3).Text =;
            }
            else
            {
            }
            return " ";
        }

        /// <summary>
        /// Fooy i�erisindeki hesaolanm�s degerleri bulur gruplar ve hesaplay�p c�kt�y� olusturur..
        /// </summary>
        /// <param name="foyum">Hangi foytun hesap bilgileri al�nacak .</param>
        /// <param name="txtcnt">��kt�n�n yaz�lacag� kontrol</param>
        /// <param name="extraInfo">extra bilgiler</param>
        /// <param name="bottomtext">hesap alt�na yaz�lacak metin</param>
        /// <returns>bo� string verisi . Degi�kenin textini temizlemek i�in.</returns>
        public static string GetHesaplanmisDegerlerFromNesne(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum, TextControl txtcnt, string extraInfo, string bottomtext, bool aciklamaGelsin, TextField field)
        {
            degerler = new AlacakFazlaIpotekAz();

            ///Elimizdeki icra kayd� i�in hesap yap�l�r.

            field.Text = "  ";

            Hesap.Icra hy = new Hesap.Icra(foyum);

            //HesapYapar hesy = new HesapYapar();
            List<decimal> yazdirilanParalar = new List<decimal>();
            try
            {
                //foyum = hy.IcraFoyHesaplaByID(foyum.ID);
                //      hesy.Kaydet(foyum); Okan 17.08.2010 Hesap.Icra hy = new Hesap.Icra(foyum); kay�t yap�yor
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            //say�lar� formatlamak i�in gereki classtan instance ald�k
            SayiOkuma so = new SayiOkuma();

            ///elimizdeki degerleri tutacagom�oz degiskeni olsutruduk...
            List<TextField> lstFields = new List<TextField>();
            TextField tf = new TextField();

            TList<AV001_TI_BIL_ALACAK_NEDEN> gayriNakitAlacaklar = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

            //foyun alacak nedenleri
            TList<AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN> lstAlacakNedens = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
            foreach (var item in foyum.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                if (!HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(item)
                    && item.AN_URETIP_TIP != (int)AN_URETIP_TIP.HesapDisi
                    && item.AN_URETIP_TIP != (int)AN_URETIP_TIP.MunzamSenet)
                    lstAlacakNedens.Add(item);

                if (HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(item) && item.AN_URETIP_TIP != (int)AN_URETIP_TIP.MunzamSenet) gayriNakitAlacaklar.Add(item);
            }
            if (lstAlacakNedens.Count == 0)
            {
                GayrinakitleriGoster = true;
                return string.Empty;
            }

            DateTime kucuktarih = DateTime.MinValue;

            ///edlimizdeki alaca ndenlerini gruplay�p tutacag�m�z degisken
            TList<AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN> lstFarkliAlacakNedenleri = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

            ////alacak kalemlerini dola�t�k
            for (int i = 0; i < lstAlacakNedens.Count; i++)
            {
                //alacak kaleminin doviz tipi elimizdeki alacak kalemlerinden farkl�m� ? farkl�ysa farkl�alacak kalemlerine ekledik.
                //burada elimizde kac tane doviz farkl� doviz tipinde alacak kalemi var onu bulduk ...
                if (true)//DovizTipiFarklimi(lstFarkliAlacakNedenleri, lstAlacakNedens[i]))
                {
                    lstFarkliAlacakNedenleri.Add(lstAlacakNedens[i]);
                }

                ///faiz baslang�c tarihi yoksa bu ad�m� es ge�
                if (!lstAlacakNedens[i].FAIZ_BASLANGIC_TARIHI.HasValue)
                {
                    continue;
                }

                //en kucuk faiz baslang�c tarihini bulup kucuktarih adl� de�i�kene att�k
                if (lstAlacakNedens[i].FAIZ_BASLANGIC_TARIHI.Value > kucuktarih)
                {
                    kucuktarih = lstAlacakNedens[i].FAIZ_BASLANGIC_TARIHI.Value;
                }
            }

            //Hesaplanm�� de�erler giri�inde �zel tutar alanlar�n�n takip talebine lookuptan se�ilen de�eri ile gelmesi i�in eklendi. MB
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_OZEL_TUTAR_KONU));

            //alacak kalemleri tek bir doviz tipindeyse.
            //Bu durumda degerler Foy uzerinden okunup toplam degerler s�ras�yla hesaplar tipinden tan�ml� diziye hesab�n ad� ile birlikte at�l�yor.
            decimal xxx = 0;
            foreach (var item in foyum.AV001_TI_BIL_TAZMINATCollection)
            {
                if (item.TAZMINAT_TAKIPDEN_ONCE_MI)
                    xxx += item.TAZMINAT_TUTARI;
            }

            if (lstFarkliAlacakNedenleri.Count == 1)
            {
                hesaplar[] hesps = new hesaplar[]
            {
                 new hesaplar(foyum.ASIL_ALACAK_DOVIZ_ID, foyum.ASIL_ALACAK,"As�l Alacak",1,1),
                 new hesaplar(1, kucuktarih,"ifb",1,1),
                 new hesaplar(1,foyum.TAKIP_TARIHI,"ifs",1,1),
                 //YEDA� i�in a�a��daki �ekilde kontrol eklendi. db'lerindeki faiz tip 22 oldu�undan 22 de�eri kontrol edildi. MB
                 new hesaplar(foyum.ISLEMIS_FAIZ_DOVIZ_ID, foyum.ISLEMIS_FAIZ,lstFarkliAlacakNedenleri[0].TO_ALACAK_FAIZ_TIP_ID !=22 ? "��lemi� Faiz" : "Gecikme Zamm�",lstFarkliAlacakNedenleri[0].TO_UYGULANACAK_FAIZ_ORANI,lstFarkliAlacakNedenleri[0].TO_ALACAK_FAIZ_TIP_ID.Value),

                 new hesaplar(foyum.BSMV_TO_DOVIZ_ID, foyum.BSMV_TO,"BSMV" ,1,1),
                 new hesaplar(foyum.KKDV_TO_DOVIZ_ID, foyum.KKDV_TO,"KKDF",1,1 ),
                 new hesaplar(foyum.OIV_TO_DOVIZ_ID, foyum.OIV_TO,"O�V",1,1),
                 new hesaplar(foyum.KDV_TO_DOVIZ_ID, foyum.KDV_TO,BelgeUtil.Inits.Enerjimi!=true ? "KDV": "G.Z.KDV'si",1,1),
                 new hesaplar(foyum.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, foyum.KARSILIKSIZ_CEK_TAZMINATI,"�ek Taz.",1,1),
                 new hesaplar(foyum.CEK_KOMISYONU_DOVIZ_ID, foyum.CEK_KOMISYONU,"Kom.",1,1),
                 new hesaplar(foyum.IH_GIDERI_DOVIZ_ID, foyum.IH_GIDERI,"�.H. Gideri",1,1),
                 new hesaplar(foyum.IH_VEKALET_UCRETI_DOVIZ_ID, foyum.IH_VEKALET_UCRETI,"�.H.V. �cr.",1,1),
                 new hesaplar(foyum.IT_GIDERI_DOVIZ_ID, foyum.IT_GIDERI,"�.T. Gideri",1,1),
                 new hesaplar(foyum.IT_VEKALET_UCRETI_DOVIZ_ID, foyum.IT_VEKALET_UCRETI,"�.T.V. �cr.",1,1),
                 new hesaplar(foyum.OZEL_TUTAR1_DOVIZ_ID, foyum.OZEL_TUTAR1,foyum.OZEL_TUTAR1_KONU_ID.HasValue ? foyum.OZEL_TUTAR1_KONU_IDSource.KONU : "�zel Tutar1",1,1),//Hesaplanm�� de�erler giri�inde �zel tutar alanlar�n�n takip talebine lookuptan se�ilen de�eri ile gelmesi i�in eklendi. MB
                 new hesaplar(foyum.OZEL_TUTAR2_DOVIZ_ID, foyum.OZEL_TUTAR2,foyum.OZEL_TUTAR2_KONU_ID.HasValue ? foyum.OZEL_TUTAR2_KONU_IDSource.KONU : "�zel Tutar2",1,1),//Hesaplanm�� de�erler giri�inde �zel tutar alanlar�n�n takip talebine lookuptan se�ilen de�eri ile gelmesi i�in eklendi. MB
                 new hesaplar(foyum.OZEL_TUTAR3_DOVIZ_ID, foyum.OZEL_TUTAR3,foyum.OZEL_TUTAR3_KONU_ID.HasValue ? foyum.OZEL_TUTAR3_KONU_IDSource.KONU : "�zel Tutar3",1,1),//Hesaplanm�� de�erler giri�inde �zel tutar alanlar�n�n takip talebine lookuptan se�ilen de�eri ile gelmesi i�in eklendi. MB
                 new hesaplar(foyum.OZEL_TAZMINAT_DOVIZ_ID, foyum.OZEL_TAZMINAT,"�zel Taz.",1,1),
                 new hesaplar(foyum.IHTAR_GIDERI_DOVIZ_ID, foyum.IHTAR_GIDERI,"�htar Gid.",1,1),
                 new hesaplar(foyum.PROTESTO_GIDERI_DOVIZ_ID, foyum.PROTESTO_GIDERI,"Prot. Gid.",1,1),
                 new hesaplar(foyum.DAMGA_PULU_DOVIZ_ID, foyum.DAMGA_PULU,"Dmga Pulu",1,1),
                 new hesaplar(foyum.IT_HACIZDE_ODENEN_DOVIZ_ID, foyum.IT_HACIZDE_ODENEN,"�.H. �denen",1,1),
                 new hesaplar(foyum.MAHSUP_TOPLAMI_DOVIZ_ID, foyum.MAHSUP_TOPLAMI,"Mahsup Top.",1,1),
                 new hesaplar(foyum.TO_ODEME_TOPLAMI_DOVIZ_ID, foyum.TO_ODEME_TOPLAMI,"�deme Top.",1,1),
                 new hesaplar(foyum.ILAM_VEK_UCR_DOVIZ_ID, foyum.ILAM_VEK_UCR, "�lam Vekalet �creti",1,1),
                 new hesaplar(foyum.ILAM_BK_YARG_ONAMA_DOVIZ_ID, foyum.ILAM_BK_YARG_ONAMA, "Bakiye Karar ve Onama Harc�", 1,1),
                 new hesaplar(foyum.ILAM_INKAR_TAZMINATI_DOVIZ_ID, foyum.ILAM_INKAR_TAZMINATI, "�lam �nkar Tazminat�", 1,1),
                 new hesaplar(foyum.ILAM_YARGILAMA_GIDERI_DOVIZ_ID, foyum.ILAM_YARGILAMA_GIDERI, "�lam Yarg�lama Gideri", 1,1),
                 new hesaplar(foyum.ILAM_TEBLIG_GIDERI_DOVIZ_ID, foyum.ILAM_TEBLIG_GIDERI, "�lam Tebli� Gideri", 1,1),

                 (foyum.AV001_TI_BIL_TAZMINATCollection.Count > 0 ? (new hesaplar(foyum.AV001_TI_BIL_TAZMINATCollection[0].TAZMINAT_TUTARI_DOVIZ_ID, xxx, "Tazminat")) : new hesaplar(1, decimal.Zero,"")),

                 new hesaplar(foyum.TAKIP_CIKISI_DOVIZ_ID, foyum.TAKIP_CIKISI,"Takip ��k���",1,1) // en sonda olmal�
            };

                //if (foyum.AV001_TI_BIL_TAZMINATCollection.Count > 0)
                //    hesps[hesps.Count()] = new hesaplar(foyum.AV001_TI_BIL_TAZMINATCollection[0].TAZMINAT_TUTARI_DOVIZ_ID, foyum.AV001_TI_BIL_TAZMINATCollection[0].TAZMINAT_TUTARI, "Tazminat");

                //Munzam olay�: �nce de�erler al�n�yor ve munzam olup olmad��� belirleniyor. Yeni row ekleme i�lemi gethesapsFromNesne metodu i�erisinde yap�l�yor. Di�er durumlarda row ekleme i�lemi yap�lamad���ndan bu �ekilde yap�ld�. Row eklendikten sonra da eklenen rowlara ilgili de�erler at�l�yor. MB

                #region <MB-20110105>

                //Munzam Miktar� Alacak Miktar�ndan B�y�kse a�a��daki i�lemler yap�lacak.

                TList<AV001_TDI_BIL_KIYMETLI_EVRAK> munzamList = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
                decimal toplamAlacak = new decimal();
                munzamList = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByICRA_FOY_IDFromNN_ICRA_KIYMETLI_EVRAK(foyum.ID);
                if (munzamList.Count > 0)
                {
                    //Nakit Alacak + Gayrinakit Alacak
                    lstAlacakNedens.ForEach(item =>
                    {
                        if (item.TUTAR_DOVIZ_ID != 1)
                        {
                            DovizHelper.GetMerkezBankasiBilgisi(item.ALACAK_NEDEN_KOD_ID);

                            item.TUTARI = DovizHelper.CevirYTL(item.TUTARI, item.TUTAR_DOVIZ_ID, DateTime.Now, item.ALACAK_NEDEN_KOD_ID);
                        }
                    });
                    gayriNakitAlacaklar.ForEach(item =>
                    {
                        if (item.TUTAR_DOVIZ_ID != 1)
                        {
                            DovizHelper.GetMerkezBankasiBilgisi(item.ALACAK_NEDEN_KOD_ID);

                            item.TUTARI = DovizHelper.CevirYTL(item.TUTARI, item.TUTAR_DOVIZ_ID, DateTime.Now, item.ALACAK_NEDEN_KOD_ID);
                        }
                    });
                    toplamAlacak = lstAlacakNedens.Sum(vi => vi.TUTARI) + gayriNakitAlacaklar.Sum(vi => vi.TUTARI);//Para birimi TL yazd�r�l�yor.
                    munzamList.ForEach(item =>
                    {
                        if (item.TUTAR_DOVIZ_ID != 1)
                        {
                            item.TUTAR = DovizHelper.CevirYTL(item.TUTAR, item.TUTAR_DOVIZ_ID, DateTime.Now);
                            item.TUTAR_DOVIZ_ID = 1;
                        }
                    });

                    decimal munzamToplami = munzamList.Sum(vi => vi.TUTAR);

                    if (foyum.ASIL_ALACAK_DOVIZ_ID != 1)
                    {
                        foyum.ASIL_ALACAK = DovizHelper.CevirYTL(foyum.ASIL_ALACAK, foyum.ASIL_ALACAK_DOVIZ_ID, DateTime.Now);
                        foyum.ASIL_ALACAK_DOVIZ_ID = 1;
                    }

                    if (munzamToplami > foyum.ASIL_ALACAK)
                        MunzamVar = true;
                }
                else MunzamVar = false;

                #endregion <MB-20110105>

                #region <MB-20110425>

                //Alacak, ipotek rehin s�zle�mesi bedelinden b�y�k ise ilgili hesap i�lemlerinin g�r�nmesi i�in eklendi.

                ParaVeDovizId gayrinakitAlacakToplami = ToplamGayriNakitAlacaklar(foyum);
                ParaVeDovizId harcaEsasDeger = new ParaVeDovizId(foyum.TAKIP_CIKISI, foyum.TAKIP_CIKISI_DOVIZ_ID);
                if (foyum.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME>));
                var sozlesmeList = foyum.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME;

                ParaVeDovizId tumAlacaklar = new ParaVeDovizId();
                if (gayrinakitAlacakToplami != null)
                    tumAlacaklar = ParaVeDovizId.Topla(harcaEsasDeger, gayrinakitAlacakToplami);
                else
                    tumAlacaklar = harcaEsasDeger;

                ParaVeDovizId limitIpotekSozlesmeBedeli = LimitIpotekliSozlesmeBedeli(foyum);

                if ((foyum.FORM_TIP_ID == (int)FormTipleri.Form151 || foyum.FORM_TIP_ID == (int)FormTipleri.Form50 || foyum.FORM_TIP_ID == (int)FormTipleri.Form152 || foyum.FORM_TIP_ID == (int)FormTipleri.Form201) && (sozlesmeList.FindAll(vi => vi.REHIN_CINS_ANA_TURU == 1).Count == 0) && (limitIpotekSozlesmeBedeli != null && tumAlacaklar.Para > limitIpotekSozlesmeBedeli.Para))
                {
                    IpotekAzAlacakCok = true;
                    GayrinakitleriGoster = false;

                    //bottomtext = "alaca��n, vekalet �creti ve takip giderleri ile birlikte, tahsilde tekerr�r edilmemek �zere TAHS�L�";

                    if (gayrinakitAlacakToplami == null)
                        degerler.ToplamGayrinakitAlacaklar = new ParaVeDovizId(0, 1);
                    else
                        degerler.ToplamGayrinakitAlacaklar = new ParaVeDovizId(DovizHelper.CevirYTL(gayrinakitAlacakToplami.Para, gayrinakitAlacakToplami.DovizId, DateTime.Now.Date), 1);
                    degerler.TumAlacaklar = tumAlacaklar;
                    degerler.LimitIpotekSozlesmesi = limitIpotekSozlesmeBedeli;
                    degerler.IpotegiAsanKisim = ParaVeDovizId.Cikart(tumAlacaklar, limitIpotekSozlesmeBedeli);
                    degerler.TakipCikisi = ParaVeDovizId.Cikart(tumAlacaklar, degerler.IpotegiAsanKisim);
                }
                else
                {
                    IpotekAzAlacakCok = false;
                    if (sozlesmeList.FindAll(vi => vi.REHIN_CINS_ANA_TURU == 1).Count == 0)
                        GayrinakitleriGoster = true;
                    else
                        GayrinakitleriGoster = false;
                }

                #endregion <MB-20110425>

                //buldugumuz hesap degerlerini editore yazd�rd�k.
                gethesapsFromNesne(hesps, foyum, txtcnt, extraInfo, bottomtext, false);

                //Munzam Miktar� Alacak Miktar�ndan B�y�kse a�a��daki i�lemler yap�lacak. MB
                if (MunzamVar)
                {
                    var newRow = txtcnt.Tables.GetItem(NewRowID);

                    newRow.Cells.GetItem(2, 1).Text = "Toplam Alacaklar ";
                    newRow.Cells.GetItem(2, 2).Text = so.ParaFormatla(toplamAlacak) + " " + "TL";
                    newRow.Cells.GetItem(3, 1).Text = "Faiz ��leyecek As�l Alacaklar ";
                    newRow.Cells.GetItem(3, 2).Text = so.ParaFormatla(foyum.ASIL_ALACAK) + " " + "TL";
                }

                if (foyum.TAKIP_CIKISI_DOVIZ_ID != 1)
                {
                    var newRow = txtcnt.Tables.GetItem(NewRowIDForHarcaEsasDeger);

                    var harcaEsasDegerAciklama = new ParaVeDovizId(0, foyum.TAKIP_CIKISI_DOVIZ_ID).DovizAdi + " alaca��n (Merkez bankas� efektif sat�� kuru kar��l��� " + so.ParaFormatla(DovizHelper.CevirYTL(1, foyum.TAKIP_CIKISI_DOVIZ_ID, DateTime.Now)) + " TL olan " + so.ParaFormatla(foyum.TAKIP_CIKISI) + BelgeUtil.Inits.DovizIdSource(foyum.TAKIP_CIKISI_DOVIZ_ID.Value).DOVIZ_KODU + " de�erindeki " + so.ParaFormatla(DovizHelper.CevirYTL(1, foyum.TAKIP_CIKISI_DOVIZ_ID, DateTime.Now)) + " X " + so.ParaFormatla(foyum.TAKIP_CIKISI) + "= " + so.ParaFormatla(DovizHelper.CevirYTL(foyum.TAKIP_CIKISI, foyum.TAKIP_CIKISI_DOVIZ_ID, DateTime.Now)) + " TL )";

                    if (MunzamVar)
                        newRow.Cells.GetItem(4, 1).Text = harcaEsasDegerAciklama;
                    else
                        newRow.Cells.GetItem(2, 1).Text = harcaEsasDegerAciklama;
                }
            }
            else
            {
                ///e�er birden fazla farkl� tipte alacak kalemi varsa ...
                ///kullanacag�m�z de�i�kkenlere ilk de�erlerini verdik.

                decimal takipCikisi = decimal.Zero;
                List<List<hesaplar>> lstFarkliHesaplar = new List<List<hesaplar>>();

                bool odemeEklendi = false;
                bool tazminatEklendi = false;

                //tum farkl� alacak kalemlerini dola�t�k .
                for (int i = 0; i < lstFarkliAlacakNedenleri.Count; i++)
                {
                    decimal ToplamFaiz = decimal.Zero;
                    int faizDovizTip = 0;

                    //takip c�k�s�na ilk deger 0 verd�k .
                    takipCikisi = decimal.Zero;

                    ///alacak kalemlerine deepload cektik ...
                    if (lstFarkliAlacakNedenleri[i].AV001_TI_BIL_FAIZCollection != null && lstFarkliAlacakNedenleri[i].AV001_TI_BIL_FAIZCollection.Count == 0)
                        AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(lstFarkliAlacakNedenleri[i], false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_ILAM_MAHKEMESI), typeof(TList<AV001_TI_BIL_FAIZ>));

                    ///eger bu i�inde ldugumuz alacak kalemnin faiz bilgileri varsa .
                    for (int z = 0; z < lstFarkliAlacakNedenleri[i].AV001_TI_BIL_FAIZCollection.Count; z++)
                    {
                        //sadece takip oncesi faiz degerlerii al�yoruz.
                        if (lstFarkliAlacakNedenleri[i].AV001_TI_BIL_FAIZCollection[z].FAIZ_TAKIPDEN_ONCE_MI == 1 &&
                            !lstFarkliAlacakNedenleri[i].AV001_TI_BIL_FAIZCollection[z].ALACAK_NEDEN_TARAF_ID.HasValue)
                        {
                            //takip oncesi faiz degerlerini al�p toplam faiz degiskeninde alacak kalemindeki faiz degerlerini toplay�p at�yoruz.
                            ToplamFaiz += lstFarkliAlacakNedenleri[i].AV001_TI_BIL_FAIZCollection[z].FAIZ_TUTARI;

                            /// faizin doviz tipi .
                            faizDovizTip = lstFarkliAlacakNedenleri[i].AV001_TI_BIL_FAIZCollection[z].FAIZ_TUTARI_DOVIZ_ID.Value;
                        }
                    }

                    var paraBsmv = AlacakNedenindenTutarGetir(lstFarkliAlacakNedenleri[i], DegerKalemi.BSMV, true);
                    var paraOIV = AlacakNedenindenTutarGetir(lstFarkliAlacakNedenleri[i], DegerKalemi.OIV, true);
                    var paraKDV = AlacakNedenindenTutarGetir(lstFarkliAlacakNedenleri[i], DegerKalemi.KDV, true);
                    var paraKKDV = AlacakNedenindenTutarGetir(lstFarkliAlacakNedenleri[i], DegerKalemi.KKDV, true);

                    //Hesaplanm�� de�erler giri�inde �zel tutar alanlar�n�n takip talebine lookuptan se�ilen de�eri ile gelmesi i�in eklendi. MB
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_OZEL_TUTAR_KONU));

                    //i�leme konan tutar� hesaplara ekledik .
                    ///hesaplanm�s degerleri hesaplara ekledik .
                    hesaplaraEkle(new hesaplar(lstFarkliAlacakNedenleri[i].ISLEME_KONAN_TUTAR_DOVIZ_ID, lstFarkliAlacakNedenleri[i].ISLEME_KONAN_TUTAR, "As�l Alacak", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(faizDovizTip, kucuktarih, "ifb", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(faizDovizTip, lstFarkliAlacakNedenleri[i].FAIZ_BASLANGIC_TARIHI, "KUCUK_TARIH", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(faizDovizTip, foyum.TAKIP_TARIHI, "ifs", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);

                    //YEDA� i�in a�a��daki �ekilde kontrol eklendi. db'lerindeki faiz tip 22 oldu�undan 22 de�eri kontrol edildi. MB
                    hesaplaraEkle(new hesaplar(faizDovizTip, ToplamFaiz, lstFarkliAlacakNedenleri[i].TO_ALACAK_FAIZ_TIP_ID != 22 ? "��lemi� Faiz" : "Gecikme Zamm�", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(paraBsmv.DovizId, paraBsmv.Para, "BSMV", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(paraKKDV.DovizId, paraKKDV.Para, "T.�. KKDV", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(paraOIV.DovizId, paraOIV.Para, "T.�. O�V", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(paraKDV.DovizId, paraKDV.Para, BelgeUtil.Inits.Enerjimi != true ? "T.�. KDV" : "G.Z.KDV'si", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(lstFarkliAlacakNedenleri[i].CEK_TAZMINATI_DOVIZ_ID, lstFarkliAlacakNedenleri[i].CEK_TAZMINATI, "�ek Tazminat�", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(lstFarkliAlacakNedenleri[i].KOMISYONU_DOVIZ_ID, lstFarkliAlacakNedenleri[i].KOMISYONU, "Komisyon", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(lstFarkliAlacakNedenleri[i].IHTAR_GIDERI_DOVIZ_ID, lstFarkliAlacakNedenleri[i].IHTAR_GIDERI, "�htar Gideri", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(lstFarkliAlacakNedenleri[i].PROTESTO_GIDERI_DOVIZ_ID, lstFarkliAlacakNedenleri[i].PROTESTO_GIDERI, "Protesto Gideri", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(lstFarkliAlacakNedenleri[i].DAMGA_PULU_DOVIZ_ID, lstFarkliAlacakNedenleri[i].DAMGA_PULU, "Dmga Pulu", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(foyum.IT_HACIZDE_ODENEN_DOVIZ_ID, foyum.IT_HACIZDE_ODENEN, "Hazcizde �denen", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(foyum.MAHSUP_TOPLAMI_DOVIZ_ID, foyum.MAHSUP_TOPLAMI, "Mahsup Toplami", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);

                    if (!odemeEklendi)//Farkl� alacak tiplerinde �demenin birden fazla kere alacaklardan d���mesini engellemek i�in eklendi. MB
                    {
                        hesaplaraEkle(new hesaplar(foyum.TO_ODEME_TOPLAMI_DOVIZ_ID, foyum.TO_ODEME_TOPLAMI, "�deme Toplam�", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                        odemeEklendi = true;
                    }

                    hesaplaraEkle(new hesaplar(foyum.IT_VEKALET_UCRETI_DOVIZ_ID, foyum.IT_VEKALET_UCRETI, "�.T.V. �creti", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(foyum.OZEL_TUTAR1_DOVIZ_ID, foyum.OZEL_TUTAR1, foyum.OZEL_TUTAR1_KONU_ID.HasValue ? foyum.OZEL_TUTAR1_KONU_IDSource.KONU : "�zel Tutar1", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, true);//Hesaplanm�� de�erler giri�inde �zel tutar alanlar�n�n takip talebine lookuptan se�ilen de�eri ile gelmesi i�in eklendi. MB
                    hesaplaraEkle(new hesaplar(foyum.OZEL_TUTAR2_DOVIZ_ID, foyum.OZEL_TUTAR2, foyum.OZEL_TUTAR2_KONU_ID.HasValue ? foyum.OZEL_TUTAR2_KONU_IDSource.KONU : "�zel Tutar2", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, true);//Hesaplanm�� de�erler giri�inde �zel tutar alanlar�n�n takip talebine lookuptan se�ilen de�eri ile gelmesi i�in eklendi. MB
                    hesaplaraEkle(new hesaplar(foyum.OZEL_TUTAR3_DOVIZ_ID, foyum.OZEL_TUTAR3, foyum.OZEL_TUTAR3_KONU_ID.HasValue ? foyum.OZEL_TUTAR3_KONU_IDSource.KONU : "�zel Tutar3", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, true);//Hesaplanm�� de�erler giri�inde �zel tutar alanlar�n�n takip talebine lookuptan se�ilen de�eri ile gelmesi i�in eklendi. MB
                    hesaplaraEkle(new hesaplar(foyum.OZEL_TAZMINAT_DOVIZ_ID, foyum.OZEL_TAZMINAT, "�zel Tazminat", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, true);//Hesaplanm�� de�erler giri�inde �zel tutar alanlar�n�n takip talebine lookuptan se�ilen de�eri ile gelmesi i�in eklendi. MB

                    hesaplaraEkle(new hesaplar(foyum.IH_VEKALET_UCRETI_DOVIZ_ID, foyum.IH_VEKALET_UCRETI, "�.H.V. �creti", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(foyum.ILAM_INKAR_TAZMINATI_DOVIZ_ID, foyum.ILAM_INKAR_TAZMINATI, "�lam �nkar Tazminat�", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(foyum.ILAM_YARGILAMA_GIDERI_DOVIZ_ID, foyum.ILAM_YARGILAMA_GIDERI, "�lam Yarg�lama Gideri", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(foyum.ILAM_BK_YARG_ONAMA_DOVIZ_ID, foyum.ILAM_BK_YARG_ONAMA, "Bakiye Karar ve Onama Harc�", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(foyum.ILAM_TEBLIG_GIDERI_DOVIZ_ID, foyum.ILAM_TEBLIG_GIDERI, "�lam Tebli� Gideri", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(foyum.ILAM_VEK_UCR_DOVIZ_ID, foyum.ILAM_VEK_UCR, "�lam Vekalet �creti", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    hesaplaraEkle(new hesaplar(foyum.IH_GIDERI_DOVIZ_ID, foyum.IH_GIDERI, "�.H. Gideri", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);
                    if (!tazminatEklendi)
                    {
                        if (foyum.AV001_TI_BIL_TAZMINATCollection.Count > 0)
                            hesaplaraEkle(new hesaplar(foyum.AV001_TI_BIL_TAZMINATCollection[0].TAZMINAT_TUTARI_DOVIZ_ID, xxx, "Tazminat", lstFarkliAlacakNedenleri[i], foyum), lstFarkliHesaplar, false);

                        tazminatEklendi = true;
                    }
                }

                string HarcaEsasDeger = Environment.NewLine + "  Harca Esas De�er = ";
                decimal harcaEsasDeger = 0;//Merve

                List<hesaplar> lstTLHesaplar = new List<hesaplar>();
                int tlhesaplarindex = 0;
                for (int i = 0; i < lstFarkliHesaplar.Count - 1; i++)
                {
                    if (lstFarkliHesaplar[i][0].DovizId.Value == 1)
                    {
                        lstTLHesaplar = lstFarkliHesaplar[i];
                        tlhesaplarindex = i;
                    }
                }

                if (tlhesaplarindex != 0)
                {
                    List<hesaplar> yedek = new List<hesaplar>();
                    yedek.AddRange(lstFarkliHesaplar[lstFarkliHesaplar.Count - 1].ToArray());
                    lstFarkliHesaplar[lstFarkliHesaplar.Count - 1].Clear();
                    lstFarkliHesaplar[lstFarkliHesaplar.Count - 1].AddRange(lstTLHesaplar.ToArray());
                    lstFarkliHesaplar[tlhesaplarindex] = yedek;
                }

                ToplamlariHesapla(lstFarkliHesaplar, foyum);
                ilamGiderleriHesaplandi = false;
                HG = new HesapGrubu();
                for (int y = 0; y < lstFarkliHesaplar.Count; y++)
                {
                    if (lstFarkliHesaplar.Count - 1 == y)
                    {
                        decimal takipCikisim = (decimal)lstFarkliHesaplar[y][lstFarkliHesaplar[y].Count - 1].Deger;

                        int dovizIdm = lstFarkliHesaplar[y][lstFarkliHesaplar[y].Count - 1].DovizId.Value;

                        yazdirilanParalar.Add(takipCikisim);
                        if (dovizIdm != 1)
                        {
                            HarcaEsasDeger += so.ParaFormatla(takipCikisim) + " " + BelgeUtil.Inits.DovizIdSource(dovizIdm).DOVIZ_KODU + " X " + so.ParaFormatla(DovizHelper.CevirYTL(1, 1, DateTime.Now)) + "=" + so.ParaFormatla(takipCikisim) + " TL dir.";
                            harcaEsasDeger = DovizHelper.CevirYTL(takipCikisi, 1, DateTime.Now);
                        }
                        else
                        {
                            HarcaEsasDeger += so.ParaFormatla(takipCikisim) + " " + BelgeUtil.Inits.DovizIdSource(dovizIdm).DOVIZ_KODU + " = ";
                            harcaEsasDeger = takipCikisim;
                        }

                        //<gkn> Bedenok bey kald�r dedi 18.09.2009 </gkn>
                        //bottomtext += GetIpotekliAciklama(foyum);

                        //son farkl� hesab�n a��klamas�na t�m�n�n toplam�n� yazd�rmak i�in
                        List<ParaVeDovizId> grupToplamlari = new List<ParaVeDovizId>();

                        foreach (var list in HG.GrupListesi)
                        {
                            foreach (var item in list)
                            {
                                //takip ��k�� de�erlerini listeye al�yoruz
                                if (item.Baslik == "Takip ��k���")
                                    grupToplamlari.Add(item.Tutar);
                            }
                        }

                        string toplamaMetni = Environment.NewLine;

                        //�zerinde bulundu�umuz alacak nedenini de listeye ekliyoruz
                        grupToplamlari.Add(new ParaVeDovizId(takipCikisim, dovizIdm, foyum.TAKIP_TARIHI));

                        foreach (var teki in grupToplamlari)
                        {
                            if (teki.DovizId != 1) //tl den farkl� d�viz alanlar� i�in o g�nki d�viz kuru ile �arp�p sonucu al�yoruz
                            {
                                toplamaMetni += "(";
                                toplamaMetni += so.ParaFormatla(teki.Para);
                                toplamaMetni += teki.DovizKodu;
                                toplamaMetni += " X ";
                                toplamaMetni += new ParaVeDovizId(1, teki.DovizId, teki.KurCevrimTarihi).YtlHali + " TL";
                                toplamaMetni += "=";
                                toplamaMetni += teki.YtlHali;
                                toplamaMetni += ")";
                                toplamaMetni += " + ";
                            }

                            //else //tl alan� i�in �evirme i�lemi yapmadan yaz�yoruz
                            //{
                            //    toplamaMetni += "(";
                            //    toplamaMetni += so.ParaFormatla(teki.Para);
                            //    toplamaMetni += " TL)";
                            //    toplamaMetni += " + ";
                            //}//TL toplam�n tekrardan bo�yere yaz�lmas� istenmedi�inden kald�r�ld�. MB
                        }

                        ////en sondaki + y� kald�rd�k
                        //toplamaMetni = toplamaMetni.TrimEnd(' ', '+');
                        //toplamaMetni += " = ";
                        //toplamaMetni += so.ParaFormatla(ParaVeDovizId.Topla(grupToplamlari).YtlHali);
                        //toplamaMetni += " TL";

                        //toplamaMetni += Environment.NewLine;
                        ////a��klamam�z�n ba��na tutar toplamlar�m�z� ekledik
                        //bottomtext = toplamaMetni + " " + bottomtext; ;

                        if (!aciklamaGelsin)
                            bottomtext = string.Empty;

                        ExgethesapsFromNesne(lstFarkliHesaplar[y].ToArray(), foyum, txtcnt, extraInfo, bottomtext, true);
                    }
                    else
                    {
                        decimal takipCikisim = (decimal)lstFarkliHesaplar[y][lstFarkliHesaplar[y].Count - 1].Deger;
                        int dovizIdm = lstFarkliHesaplar[y][lstFarkliHesaplar[y].Count - 1].DovizId.Value;
                        decimal tlHali = DovizHelper.CevirYTL(takipCikisim, dovizIdm, DateTime.Now);
                        yazdirilanParalar.Add(tlHali);

                        //Birden fazla alacakta ve d�vizli para biriminde mevcut talep a��klamas� yerine a�a��daki talep a��klamas�n�n g�sterilmesinin yanl�� oldu�u s�ylendi�inden (Bedenok Bey) kapat�ld�. MB
                        //string lafi = string.Empty;
                        //if (dovizIdm > 1)
                        //    lafi = " tutarindaki alaca��m�z�n takip tarihindeki Merkez Bankas� efektif sat�� kuru TL kar��l��� " + so.ParaFormatla(takipCikisim) + " " + BelgeUtil.Inits.DovizIdSource(dovizIdm).DOVIZ_KODU + " X " + so.ParaFormatla(DovizHelper.CevirYTL(1, dovizIdm, DateTime.Now)) + " TL = " + so.ParaFormatla(tlHali) + " TL dir.";

                        ExgethesapsFromNesne(lstFarkliHesaplar[y].ToArray(), foyum, txtcnt, extraInfo, bottomtext/* lafi*/, true);//Yukar�daki sebepten laf� de�i�keninin kullan�m� kald�r�ld�. MB

                        if (dovizIdm != 1)
                            HarcaEsasDeger += new ParaVeDovizId(0, dovizIdm).DovizAdi + " alaca��n (Merkez bankas� efektif sat�� kuru kar��l��� " + so.ParaFormatla(DovizHelper.CevirYTL(1, dovizIdm, DateTime.Now)) + " TL olan " + so.ParaFormatla(takipCikisim) + BelgeUtil.Inits.DovizIdSource(dovizIdm).DOVIZ_KODU + " de�erindeki " + so.ParaFormatla(DovizHelper.CevirYTL(1, dovizIdm, DateTime.Now)) + " X " + so.ParaFormatla(takipCikisim) + "= " + so.ParaFormatla(tlHali) + " TL ) + ";
                    }
                }

                #region <GKN-20090611>

                //TODO:Gruplama sorunundaki hatan�n �n�ne ge�ilmeye �al���yor

                //Tablo olu�tururken id vermek i�in de�erler tan�mlan�yor
                int baslik = 1;
                int deger = 1;
                int aciklamaSira = 1;

                foreach (var liste in HG.GrupListesi)
                {
                    string dovizAdi = string.Empty;

                    if (liste.Count > 0)
                    {
                        dovizAdi = liste[0].Tutar.DovizAdi;
                    }
                    int tableId = 2000 + baslik;
                    if (!txtcnt.Tables.CanAdd)
                    {
                        txtcnt.Select(field.Start, 0);
                    }
                    var result = txtcnt.Tables.Add(1, 1, tableId);
                    if (HG.GrupListesi.Count == 1)
                        txtcnt.Tables.GetItem(tableId).Cells.GetItem(1, 1).Text = dovizAdi /*+ " (Faiz : " + liste[0].FaizTipiOrani + ")"*/;

                    //Takip takebinde para biriminin yan�nda faiz tipi ve oran� altta da verildi�i i�in �stteki yerden kald�r�ld�. (Bahattin �elik taraf�ndan istendi. MB
                    else
                        txtcnt.Tables.GetItem(tableId).Cells.GetItem(1, 1).Text = dovizAdi + " (Faiz : " + liste[0].FaizTipiOrani + ")";

                    int degerId = 3000 + deger;

                    #region <MB-20110426>

                    //Alacak, ipotek rehin s�zle�mesi bedelinden b�y�k ise ilgili hesap i�lemlerinin g�r�nmesi i�in eklendi.

                    ParaVeDovizId gayrinakitAlacakToplami = ToplamGayriNakitAlacaklar(foyum);
                    ParaVeDovizId tumAlacaklar = new ParaVeDovizId();
                    if (foyum.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME.Count == 0)
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME>));
                    var sozlesmeList = foyum.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME;

                    if (gayrinakitAlacakToplami != null)
                        tumAlacaklar = ParaVeDovizId.Topla(new ParaVeDovizId(foyum.TAKIP_CIKISI, foyum.TAKIP_CIKISI_DOVIZ_ID), gayrinakitAlacakToplami);
                    else
                        tumAlacaklar = new ParaVeDovizId(foyum.TAKIP_CIKISI, foyum.TAKIP_CIKISI_DOVIZ_ID);

                    ParaVeDovizId limitIpotekSozlesmeBedeli = LimitIpotekliSozlesmeBedeli(foyum);

                    if ((foyum.FORM_TIP_ID == (int)FormTipleri.Form151 || foyum.FORM_TIP_ID == (int)FormTipleri.Form50 || foyum.FORM_TIP_ID == (int)FormTipleri.Form152 || foyum.FORM_TIP_ID == (int)FormTipleri.Form201) && (sozlesmeList.FindAll(vi => vi.REHIN_CINS_ANA_TURU == 1).Count == 0) && (limitIpotekSozlesmeBedeli != null && tumAlacaklar.Para > limitIpotekSozlesmeBedeli.Para))
                    {
                        IpotekAzAlacakCok = true;
                        GayrinakitleriGoster = false;

                        if (gayrinakitAlacakToplami == null)
                            degerler.ToplamGayrinakitAlacaklar = new ParaVeDovizId(0, 1);
                        else
                            degerler.ToplamGayrinakitAlacaklar = new ParaVeDovizId(DovizHelper.CevirYTL(gayrinakitAlacakToplami.Para, gayrinakitAlacakToplami.DovizId, DateTime.Now.Date), 1);

                        degerler.TumAlacaklar = tumAlacaklar;
                        degerler.LimitIpotekSozlesmesi = limitIpotekSozlesmeBedeli;
                        degerler.IpotegiAsanKisim = ParaVeDovizId.Cikart(tumAlacaklar, limitIpotekSozlesmeBedeli);
                        degerler.TakipCikisi = ParaVeDovizId.Cikart(tumAlacaklar, degerler.IpotegiAsanKisim);
                    }
                    else
                    {
                        IpotekAzAlacakCok = false;
                        if (sozlesmeList.FindAll(vi => vi.REHIN_CINS_ANA_TURU == 1).Count == 0)
                            GayrinakitleriGoster = true;
                        else
                            GayrinakitleriGoster = false;
                    }

                    #endregion <MB-20110426>

                    if (!IpotekAzAlacakCok)
                        txtcnt.Tables.Add(liste.Count + 1, 3, degerId); // Toplam �izgisi i�in Bir sat�r fazla ekliyoruz
                    else
                        txtcnt.Tables.Add(12, 3, degerId);

                    var table = txtcnt.Tables.GetItem(degerId);
                    int sira = 1;

                    foreach (var item in liste)
                    {
                        if (item.Baslik == "Takip ��k���")
                        {
                            item.Baslik = "Nakit Alacak";

                            table.Cells.GetItem(sira, 2).Text = "+___________________";
                            sira++;

                            #region <MB-20110426>

                            //Alacak, ipotek rehin s�zle�mesi bedelinden b�y�k ise ilgili hesap i�lemlerinin g�r�nmesi i�in eklendi.
                            if (IpotekAzAlacakCok)
                            {
                                //bottomtext = "alaca��n, vekalet �creti ve takip giderleri ile birlikte, tahsilde tekerr�r edilmemek �zere TAHS�L�";
                                SayiOkuma sa = new SayiOkuma();

                                table.Cells.GetItem(sira + 1, 1).Text = "Gayrinakit Alacaklar";
                                table.Cells.GetItem(sira + 1, 2).Text = "          " + sa.ParaFormatla(degerler.ToplamGayrinakitAlacaklar.Para) + " TL";
                                table.Cells.GetItem(sira + 2, 2).Text = "+___________________";
                                table.Cells.GetItem(sira + 3, 1).Text = "Toplam Alacaklar";
                                table.Cells.GetItem(sira + 3, 2).Text = "          " + sa.ParaFormatla(degerler.TumAlacaklar.Para) + " TL";
                                table.Cells.GetItem(sira + 4, 1).Text = "�pote�i A�an Alacak";
                                table.Cells.GetItem(sira + 4, 2).Text = "          " + sa.ParaFormatla(degerler.IpotegiAsanKisim.Para) + " TL";
                                table.Cells.GetItem(sira + 5, 2).Text = " -___________________";
                                table.Cells.GetItem(sira + 6, 1).Text = "Takip ��k���";
                                table.Cells.GetItem(sira + 6, 2).Text = "          " + sa.ParaFormatla(ParaVeDovizId.Cikart(degerler.TumAlacaklar, degerler.IpotegiAsanKisim).Para) + " TL";
                            }

                            #endregion <MB-20110426>
                        }

                        table.Cells.GetItem(sira, 1).Text = item.Baslik;
                        var paraHucresi = table.Cells.GetItem(sira, 2);

                        string para = so.ParaFormatla(item.Tutar.Para);

                        #region <GKN-090611>

                        //
                        //paralar� alt alta getirmek i�in ilkel bir yol izliyoruz

                        int length = para.Length;
                        string bosluk = string.Empty;
                        for (int i = length; i < 20; i++)
                        {
                            bosluk += " ";// +para.Length;
                        }
                        if (bosluk.Length % 2 == 0)
                            bosluk += " ";

                        //Buraya Kadar gkn

                        #endregion <GKN-090611>

                        paraHucresi.Text = bosluk + para + " " + item.Tutar.DovizKodu;

                        //Gecikme zamm� kontrol� YEDA� i�in yap�ld�. MB
                        if (item.Baslik == "��lemi� Faiz" || item.Baslik == "Gecikme Zamm�") // i�lemi� faizin yan�na tarihleri yaz�yoruz
                        {
                            if (!BelgeUtil.Inits.Enerjimi)
                                table.Cells.GetItem(sira, 3).Text = TarihBicimlendirme(item.KucukTarih.Date) + "-" + TarihBicimlendirme(item.BuyukTarih.Date) + " Y�ll�k %" + item.FaizOrani + " " + item.FaizTipi;//MB, i�lenmi� faiz sat�r�nda tarih aral�kalar�n�n yan�na faiz miktar� ve tipi eklendi.
                            else //YEDA� i�in bu �ekilde yap�ld�. MB
                                table.Cells.GetItem(sira, 3).Text = "%" + item.FaizOrani + "6183 Say�l� Yasa";
                        }

                        if (liste.Count + 1 == sira) //Toplam �izgizisi i�in bir sat�r ekledik burada da liste nin countuna 1 erkliyoruz //IpotekAzAlacakCok kontol�, Ana Para ipote�inde a��klama alan� g�sterilmeyece�inden yap�ld�.
                        {
                            if (BelgeUtil.Inits.PaketAdi == 1)
                            {
                                if (sozlesmeList.Count == 0 || sozlesmeList.FindAll(vi => vi.REHIN_CINS_ANA_TURU == 1).Count == 0)
                                {
                                    int aciklamaAlani = 5000 + aciklamaSira;
                                    txtcnt.Tables.Add(1, 1, aciklamaAlani);
                                    var aciklama = txtcnt.Tables.GetItem(aciklamaAlani);
                                    if (IpotekAzAlacakCok) item.Deger = "alaca��n, vekalet �creti ve takip giderleri ile birlikte tahsilde tekerr�r edilmemek �zere TAHS�L�";
                                    else if (foyum.FORM_TIP_ID == (int)FormTipleri.Form163)
                                    {
                                        if (foyum.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_ICRA_KIYMETLI_EVRAK.Count == 0)
                                            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>));
                                        if (foyum.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_ICRA_KIYMETLI_EVRAK.Count > 0)
                                        {
                                            if (liste.Find(vi => !string.IsNullOrEmpty(vi.FaizOrani)) != null && liste.Find(vi => !string.IsNullOrEmpty(vi.FaizTipi)) != null)
                                            {
                                                string faizTipi = liste.Find(vi => !string.IsNullOrEmpty(vi.FaizTipi)).FaizTipi;

                                                if (faizTipi == "Avans")
                                                    faizTipi += " faizi";
                                                item.Deger = string.Format("Alacak ile as�l alacak �zerinden {0} tarihinden itibaren i�leyecek TCMB k�sa vadeli kredilere uyglanan {2} ( bug�n itibari ile %{1} ), takip masraflar� ve avukatl�k �creti ile birlikte, k�smi �demeler �ncelikle BK.m.84 gere�ince faize mahsup edilecek �ekilde hesaplanark ve tahsilde tekerr�r edilmemek �zere, Alacakl�n�n her t�rl� fazlaya ili�kin haklar� sakl� kalarak, TAHS�L�.", foyum.TAKIP_TARIHI.Value.ToShortDateString(), liste.Find(vi => !string.IsNullOrEmpty(vi.FaizOrani)).FaizOrani, faizTipi);
                                            }
                                        }
                                    }
                                    else if (foyum.FORM_TIP_ID == (int)FormTipleri.Form49)
                                    {
                                        //if (foyum.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                                        //    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                                        if (liste.Find(vi => !string.IsNullOrEmpty(vi.FaizOrani)) != null && liste.Find(vi => !string.IsNullOrEmpty(vi.FaizTipi)) != null)
                                            item.Deger = string.Format("Tutar�ndaki alaca��n, as�l alacak k�sm�na takip tarihinden itibaren i�leyecek y�ll�k %{0} {1}, Faizin % 5 Gider Vergisi (BSMV) ile masraf ve vekalet �cretinin, tahsilde tekerr�r edilmemek ve k�smi �demeler BK.nun 84.maddesi gere�ince �ncelikle masraf, faiz ve gider vergisine mahsup edilerek TAHS�L� talebidir.", liste.Find(vi => !string.IsNullOrEmpty(vi.FaizOrani)).FaizOrani, liste.Find(vi => !string.IsNullOrEmpty(vi.FaizTipi)).FaizTipi);
                                    }
                                    aciklama.Cells.GetItem(1, 1).Text = item.Deger;
                                    aciklamaSira++;
                                    txtcnt.Tables.Add(1, 2);
                                }
                                else if (sozlesmeList.FindAll(vi => vi.REHIN_CINS_ANA_TURU == 1).Count > 0)
                                {
                                    int aciklamaAlani = 5000 + aciklamaSira;
                                    txtcnt.Tables.Add(1, 1, aciklamaAlani);
                                    var aciklama = txtcnt.Tables.GetItem(aciklamaAlani);
                                    aciklama.Cells.GetItem(1, 1).Text = item.Deger;
                                    aciklamaSira++;
                                }
                            }
                            else
                            {
                                int aciklamaAlani = 5000 + aciklamaSira;
                                txtcnt.Tables.Add(1, 1, aciklamaAlani);
                                var aciklama = txtcnt.Tables.GetItem(aciklamaAlani);
                                aciklama.Cells.GetItem(1, 1).Text = item.Deger;
                                aciklamaSira++;
                                txtcnt.Tables.Add(1, 2);
                            }
                        }
                        sira++;
                    }
                    deger++;
                    baslik++;
                }

                #endregion <GKN-20090611>

                decimal toplamPAra = decimal.Zero;

                foreach (var teki in yazdirilanParalar)
                {
                    toplamPAra += teki;
                }

                HarcaEsasDeger += string.Format("{0} {1}", so.ParaFormatla(toplamPAra), new ParaVeDovizId(0, 1).DovizKodu); //so.ParaFormatla(DovizHelper.CevirYTL(foyum.TAKIP_CIKISI, foyum.TAKIP_CIKISI_DOVIZ_ID, DateTime.Now)) + new ParaVeDovizId(0,1).DovizKodu;

                HarcaEsasDeger += Environment.NewLine;

                //d�vizli alacak varsa haca esas de�er a��klamas�n� yazd�r�yoruz.
                foreach (var item in lstFarkliAlacakNedenleri)
                {
                    if (item.ISLEME_KONAN_TUTAR_DOVIZ_ID != 1)
                    {
                        txtcnt.Selection.Text = HarcaEsasDeger;
                        txtcnt.Selection.Length = HarcaEsasDeger.Length;
                        txtcnt.Selection.Bold = true;
                        break;
                    }
                }

                #region Munzam MB

                TList<AV001_TDI_BIL_KIYMETLI_EVRAK> munzamList = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
                munzamList = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByICRA_FOY_IDFromNN_ICRA_KIYMETLI_EVRAK(foyum.ID);
                if (munzamList.Count > 0)
                {
                    //Nakit Alacak + Gayrinakit Alacak
                    lstAlacakNedens.ForEach(item =>
                        {
                            if (item.TUTAR_DOVIZ_ID != 1)
                            {
                                DovizHelper.GetMerkezBankasiBilgisi(item.ALACAK_NEDEN_KOD_ID);

                                item.TUTARI = DovizHelper.CevirYTL(item.TUTARI, item.TUTAR_DOVIZ_ID, DateTime.Now, item.ALACAK_NEDEN_KOD_ID);
                            }
                        });
                    gayriNakitAlacaklar.ForEach(item =>
                    {
                        if (item.TUTAR_DOVIZ_ID != 1)
                        {
                            DovizHelper.GetMerkezBankasiBilgisi(item.ALACAK_NEDEN_KOD_ID);

                            item.TUTARI = DovizHelper.CevirYTL(item.TUTARI, item.TUTAR_DOVIZ_ID, DateTime.Now);
                        }
                    });
                    decimal toplamAlacak = lstAlacakNedens.Sum(vi => vi.TUTARI) + gayriNakitAlacaklar.Sum(vi => vi.TUTARI);//Para birimi TL yazd�r�l�yor.
                    munzamList.ForEach(item =>
                    {
                        if (item.TUTAR_DOVIZ_ID != 1)
                        {
                            item.TUTAR = DovizHelper.CevirYTL(item.TUTAR, item.TUTAR_DOVIZ_ID, DateTime.Now);
                            item.TUTAR_DOVIZ_ID = 1;
                        }
                    });

                    decimal munzamToplami = munzamList.Sum(vi => vi.TUTAR);

                    if (foyum.ASIL_ALACAK_DOVIZ_ID != 1)
                    {
                        foyum.ASIL_ALACAK = DovizHelper.CevirYTL(foyum.ASIL_ALACAK, foyum.ASIL_ALACAK_DOVIZ_ID, DateTime.Now);
                        foyum.ASIL_ALACAK_DOVIZ_ID = 1;
                    }

                    if (munzamToplami > foyum.ASIL_ALACAK)
                    {
                        if (!txtcnt.Tables.CanAdd)
                        {
                            txtcnt.Select(txtcnt.Selection.Start, 0);
                        }

                        txtcnt.Tables.Add(1, 1, 6000);
                        txtcnt.Tables.Add(1, 2, 7000);
                        var toplamAlacaklar = txtcnt.Tables.GetItem(7000);
                        toplamAlacaklar.Cells.GetItem(1, 1).Text = "Toplam Alacaklar ";
                        toplamAlacaklar.Cells.GetItem(1, 2).Text = so.ParaFormatla(toplamAlacak) + " " + "TL";

                        txtcnt.Tables.Add(1, 1, 8000);
                        txtcnt.Tables.Add(1, 2, 9000);
                        var asilAlacak = txtcnt.Tables.GetItem(9000);
                        asilAlacak.Cells.GetItem(1, 1).Text = "Faiz ��leyecek As�l Alacaklar ";
                        asilAlacak.Cells.GetItem(1, 2).Text = so.ParaFormatla(foyum.ASIL_ALACAK) + " " + "TL";

                        txtcnt.Tables.Remove(6000);
                        txtcnt.Tables.Remove(8000);
                    }
                }

                #endregion Munzam MB
            }
            return string.Empty;
        }

        public static List<TextField> GetHukuksalNedenler(int foyid)
        {
            List<TextField> returnValue = new List<TextField>();

            AvukatProLib2.Entities.AV001_TD_BIL_FOY foyum = AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOYProvider.GetByID(foyid);
            AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(AV001_TD_BIL_DAVA_NEDEN));
            TList<AV001_TD_BIL_DAVA_NEDEN> lstdavanedenler = AvukatProLib2.Data.DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.GetByDAVA_FOY_ID(foyum.ID);
            AvukatProLib2.Data.DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.DeepLoad(lstdavanedenler, false, DeepLoadType.IncludeChildren, typeof(AV001_TD_BIL_DAVA_NEDEN_TARAF), typeof(TDI_KOD_DAVA_ADI), typeof(TDI_KOD_FAIZ_TIP), typeof(TDI_KOD_DAVA_ADI));
            for (int i = 0; i < lstdavanedenler.Count; i++)
            {
                MevzuatKararLib.Entities.TList<MevzuatKararLib.Entities.TM_BIL_MEVZUAT_MADDE_TALEP> lsttalepler = MevzuatKararLib.Data.DataRepository.TM_BIL_MEVZUAT_MADDE_TALEPProvider.GetByDAVA_ADI_ID(lstdavanedenler[i].DAVA_NEDEN_KOD_ID.Value);
                MevzuatKararLib.Data.DataRepository.TM_BIL_MEVZUAT_MADDE_TALEPProvider.DeepLoad(lsttalepler, false, MevzuatKararLib.Data.DeepLoadType.IncludeChildren, typeof(MevzuatKararLib.Entities.TM_BIL_MEVZUAT_MADDE));
                for (int y = 0; y < lsttalepler.Count; y++)
                {
                    MevzuatKararLib.Entities.TM_BIL_MEVZUAT yasa = MevzuatKararLib.Data.DataRepository.TM_BIL_MEVZUATProvider.GetByID(lsttalepler[y].MEVZUAT_MADDE_IDSource.YASA_ID);
                    MevzuatKararLib.Entities.TM_BIL_MEVZUAT_MADDE madde = MevzuatKararLib.Data.DataRepository.TM_BIL_MEVZUAT_MADDEProvider.GetByID(lsttalepler[i].MEVZUAT_MADDE_ID);
                    maddesiVarmi(FindInYasalar(yasa), madde);
                }

                TextField tf11 = new TextField();
                tf11.Text = " Hukuki ";

                TextField tf22 = new TextField();
                tf22.Text = " Sebepler :  ";

                TextField tf33 = new TextField();
                tf33.Text = " ve ";

                TextField tf44 = new TextField();
                tf44.Text = " ilgili ";

                TextField tf55 = new TextField();
                tf55.Text = " yasal ";

                TextField tf66 = new TextField();
                tf66.Text = " mevzuat ";

                returnValue.Add(tf11);
                returnValue.Add(tf22);

                for (int y = 0; y < lstYasalar.Count; y++)
                {
                    TextField tf = new TextField();
                    tf.Text = lstYasalar[y].Yasa.YASA_NO;

                    TextField tf2 = new TextField();
                    tf2.Text = " nolu ";

                    TextField tf3 = new TextField();
                    tf3.Text = " yasanin ";

                    returnValue.Add(tf);

                    returnValue.Add(tf2);

                    returnValue.Add(tf3);

                    for (int m = 0; m < lstYasalar[i].Maddeler.Count; m++)
                    {
                        TextField tf4 = new TextField();
                        tf4.Text = lstYasalar[y].Maddeler[m].YASA_MADDE_NO;
                        TextField tf5 = new TextField();
                        tf5.Text = " nolu ";
                        TextField tf6 = new TextField();
                        tf6.Text = " maddesi ";

                        returnValue.Add(tf4);

                        returnValue.Add(tf5);

                        returnValue.Add(tf6);
                        //yasalar += lstYasalar[y].Maddeler[m].YASA_MADDE_NO + " nolu maddesi ";
                    }
                }
                returnValue.Add(tf33);
                returnValue.Add(tf44);
                returnValue.Add(tf55);
                returnValue.Add(tf66);
            }

            return returnValue;
        }

        ///birden fazla farkl� tiplerde alacak nedenleri oldugunda ac�klamnada faiz tipi yerine
        ///** konulup alt k�sma buradaki deger yaz�l�r
        /// <summary>
        /// �cra �zerineki alacak nedenlerini
        /// tarih tarihli xx tl tutar�ndaki alacak_neden_ad� (faiz tipi), �eklinde s�rass�yla verir
        /// </summary>
        /// <param name="foyum">icra kayd�</param>
        /// <returns>sonucu bir string te geriye veirir</returns>
        public static string GetIcraAlacakNedeniFromNesne(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
        {
            string returnValue = "";
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
            TList<AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN> lstAlacakNedens = foyum.AV001_TI_BIL_ALACAK_NEDENCollection;
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(lstAlacakNedens, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_FAIZ_TIP), typeof(TI_KOD_ALACAK_NEDEN));

            List<int> faizTipiListesi = new List<int>();
            List<double> temerrutListesi = new List<double>();

            var munzamlar = lstAlacakNedens.Where(vi => vi.AN_URETIP_TIP == (int)AN_URETIP_TIP.MunzamSenet).ToList();

            if (munzamlar.Count > 0)
            {
                lstAlacakNedens.Clear();
                lstAlacakNedens.AddRange(munzamlar.ToArray());
            }

            foreach (var aNeden in lstAlacakNedens)
            {
                if (!aNeden.ALACAK_FAIZ_TIP_ID.HasValue) continue;
                if (HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(aNeden)) continue;

                if (aNeden.ALACAK_FAIZ_TIP_ID.Value != (int)FaizTip.Temmerut_Faiz)
                {
                    if (!faizTipiListesi.Contains(aNeden.ALACAK_FAIZ_TIP_ID.Value))
                        faizTipiListesi.Add(aNeden.ALACAK_FAIZ_TIP_ID.Value);
                }
                else if (aNeden.ALACAK_FAIZ_TIP_ID.Value == (int)FaizTip.Temmerut_Faiz)
                {
                    if (!temerrutListesi.Contains(aNeden.UYGULANACAK_FAIZ_ORANI))
                        temerrutListesi.Add(aNeden.UYGULANACAK_FAIZ_ORANI);
                }
            }
            if ((temerrutListesi.Count > 1 || faizTipiListesi.Count > 1)
                ||
                (temerrutListesi.Count == 1 && faizTipiListesi.Count == 1))
            {
                returnValue += GetMetAlacakNedeniYazdir(lstAlacakNedens, true);
            }
            else
            {
                returnValue += GetMetAlacakNedeniYazdir(lstAlacakNedens, false);
            }

            return returnValue;
        }

        public static DegiskenDegeri GetIcraCariBilgisi(AV001_TI_BIL_FOY foy, string field)
        {
            DegiskenDegeri returnValues = new DegiskenDegeri();
            returnValues.DonusTipi = DegiskenResulTType.HTML;
            //returnValues.Degisken = degisken;
            returnValues.Icerik = "";
            return returnValues;
        }

        public static void GetIcraHesapsWithAciklamaFromNesne(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum, TextControl tcnt, bool aciklamaGelsin)
        {
            #region <GKN-20090609>

            //ToDo : Gruplama Sorunu olan de�i�ken

            #endregion <GKN-20090609>

            TextField tf = tcnt.TextFields.GetItem();
            if (tf != null)
            {
                tcnt.TextFields.Remove(tf);
            }
            string val = "";
            List<TextField> lstfields = GetIcraTakipTalebiFromNesne(foyum);
            if (lstfields.Count == 1)
            {
                val = lstfields[0].Name;
            }
            else
            {
                for (int i = 0; i < lstfields.Count; i++)
                {
                    if (!string.IsNullOrEmpty(lstfields[i].Text))
                    {
                        val += " " + lstfields[i].Text;
                    }
                }
            }

            GetHesaplanmisDegerlerFromNesne(foyum, tcnt, "  ", val, aciklamaGelsin, new TextField());
        }

        /// <summary>
        /// foy alt�ndaki t�m ilam bililerini virgulle ay�rarak s�ras�yla
        /// mahkeme bilgisi 'nin karar_tarihi g�n ve esas no ve karar no karar say�l� ilam ,
        /// �eklinde yazar.
        /// </summary>
        /// <param name="foyum">ilamlar� al�nacak icra</param>
        /// <returns>string d�eri kelimler halinde parca parca text field olarak dondurur...</returns>
        public static List<TextField> GetIcraIlamBilgisiFromNesne(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
        {
            List<TextField> lstFields = new List<TextField>();
            TextField tf = new TextField();
            TList<AvukatProLib2.Entities.AV001_TI_BIL_ILAM_MAHKEMESI> lstIlamBilgisi = foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection;
            for (int i = 0; i < lstIlamBilgisi.Count; i++)
            {
                AvukatProLib2.Entities.TDI_KOD_ADLI_BIRIM_ADLIYE adliye = new TDI_KOD_ADLI_BIRIM_ADLIYE();
                AvukatProLib2.Entities.TDI_KOD_ADLI_BIRIM_GOREV gorev = new TDI_KOD_ADLI_BIRIM_GOREV();
                AvukatProLib2.Entities.TDI_KOD_ADLI_BIRIM_NO no = new TDI_KOD_ADLI_BIRIM_NO();

                //  if (lstIlamBilgisi[i].ADLI_BIRIM_ADLIYE_ID.HasValue)
                // {
                adliye = AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetByID(lstIlamBilgisi[i].ADLI_BIRIM_ADLIYE_ID);

                //    }
                //  if (lstIlamBilgisi[i].ADLI_BIRIM_GOREV_ID.HasValue)
                //  {
                gorev = AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.GetByID(lstIlamBilgisi[i].ADLI_BIRIM_GOREV_ID);

                //    }
                if (lstIlamBilgisi[i].ADLI_BIRIM_NO_ID.HasValue)
                {
                    no = AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_NOProvider.GetByID(lstIlamBilgisi[i].ADLI_BIRIM_NO_ID.Value);
                }

                InsertTextField(adliye.ADLIYE + " ", adliye.ID, "adliye", lstFields, "TDI_KOD_ADLI_BIRIM_ADLIYE");
                InsertTextField(no.NO + ". ", no.ID, "no", lstFields, "TDI_KOD_ADLI_BIRIM_NO");
                InsertTextField(gorev.ACIKLAMA, gorev.ID, "gorev", lstFields, "TDI_KOD_ADLI_BIRIM_GOREV");

                InsertTextField("'nden ", 1, "yazi", lstFields, "");
                if (lstIlamBilgisi[i].KARAR_TARIHI.HasValue)
                {
                    string karartarihi = TarihBicimlendirme(lstIlamBilgisi[i].KARAR_TARIHI.Value);
                    InsertTextField(karartarihi + " tarihli ", 0, "kararTarihi", lstFields, "");
                }

                //InsertTextField(" G�n ve " + ".", 1, "yazi", lstFields, "");

                //InsertTextField(lstIlamBilgisi[i].ESAS_NO + ".", lstIlamBilgisi[i].ID, "esas_no", lstFields, "AV001_TI_BIL_ILAM_MAHKEMESI");

                //InsertTextField(" ve " + ".", 1, " ve ", lstFields, "");

                InsertTextField(lstIlamBilgisi[i].KARAR_NO + ".", lstIlamBilgisi[i].ID, "karar_no", lstFields, "AV001_TI_BIL_ILAM_MAHKEMESI");

                InsertTextField(" say�l� noter senedi. " + ".", 1, " sonekyazi ", lstFields, "");

                if (lstIlamBilgisi.Count > 1)
                {
                    InsertTextField(" , " + ".", 1, " virgul ", lstFields, "");
                }
            }

            return lstFields;
        }

        /// <summary>
        /// kiraya ait alacak nedeni de�erini verir
        /// t�m alacak nedenlerini dola��r
        /// vade_tarihi i�leme_konan_tutar Doviz_kodu tutar�ndaki alacak_nedeni
        /// �eklindeki Textfield lar halinde kelime kelime parc�al� ��kt�s�d�r
        /// </summary>
        /// <param name="foyum"></param>
        /// <returns></returns>
        public static List<TextField> GetIcraKiraAlacakNedeniFromNesne(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
        {
            List<TextField> lstFields = new List<TextField>();
            TextField tf = new TextField();
            TList<AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN> lstAlacakNedens = foyum.AV001_TI_BIL_ALACAK_NEDENCollection;
            for (int i = 0; i < lstAlacakNedens.Count; i++)
            {
                if (lstAlacakNedens[i].VADE_TARIHI.HasValue)
                {
                    tf.Text = TarihBicimlendirme(lstAlacakNedens[i].VADE_TARIHI.Value);
                }

                TextField tf2 = new TextField();
                SayiOkuma so = new SayiOkuma();
                tf2.Text = so.ParaFormatla(lstAlacakNedens[i].ISLEME_KONAN_TUTAR.ToString());
                TextField tf3 = new TextField();
                tf3.Text = BelgeUtil.Inits.DovizIdSource(lstAlacakNedens[i].ISLEME_KONAN_TUTAR_DOVIZ_ID.Value).DOVIZ_KODU;
                TextField tf4 = new TextField();
                tf4.Text = lstAlacakNedens[i].ALACAK_NEDENI;

                TextField tf5 = new TextField();
                tf5.Text = " tutar�ndaki ";

                TextField tf6 = new TextField();
                tf6.Text = " , " + Environment.NewLine;

                lstFields.Add(tf);
                lstFields.Add(tf2);
                lstFields.Add(tf3);
                lstFields.Add(tf5);
                lstFields.Add(tf4);

                lstFields.Add(tf6);
            }

            return lstFields;
        }

        public static string GetIcraKodAlacakNedeniFromNesne(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
        {
            string alacakNedenler = "";

            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
            for (int i = 0; i < foyum.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++)
            {
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(foyum.AV001_TI_BIL_ALACAK_NEDENCollection[i], false, DeepLoadType.IncludeChildren, typeof(TI_KOD_ALACAK_NEDEN));
                alacakNedenler += foyum.AV001_TI_BIL_ALACAK_NEDENCollection[i].ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI;
            }
            return alacakNedenler;
        }

        public static DegiskenDegeri GetIcraSorumluAvukat(AV001_TI_BIL_FOY foyum, TextControl txt, bool useTable)
        {
            DegiskenDegeri returnValue = new DegiskenDegeri();
            returnValue.DonusTipi = DegiskenResulTType.String;
            returnValue.Icerik += "";

            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TI_BIL_FOY_SORUMLU_AVUKAT>), typeof(AvukatProLib2.Entities.AV001_TDI_BIL_CARI));

            for (int i = 0; i < foyum.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count; i++)
            {
                string adres = string.Empty;
                var avukat = getTarafAktifAdres(foyum.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[i].SORUMLU_AVUKAT_CARI_ID, out adres);
                if (avukat != null)
                {
                    returnValue.Icerik += "Av. " + avukat.AD;
                    returnValue.Icerik += Environment.NewLine;
                    returnValue.Icerik += adres;
                }
                if (foyum.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count > 1)
                {
                    returnValue.Icerik += ",";
                }
            }

            return returnValue;
        }

        public static DegiskenDegeri GetIcraSorumluAvukat(AV001_TD_BIL_FOY foyum, TextControl txt, bool useTable)
        {
            DegiskenDegeri returnValue = new DegiskenDegeri();
            returnValue.DonusTipi = DegiskenResulTType.String;
            returnValue.Icerik += "";

            AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TD_BIL_FOY_SORUMLU_AVUKAT>), typeof(AvukatProLib2.Entities.AV001_TDI_BIL_CARI));

            for (int i = 0; i < foyum.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Count; i++)
            {
                string adres = string.Empty;
                var avukat = getTarafAktifAdres(foyum.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection[i].SORUMLU_AVUKAT_CARI_ID, out adres);
                if (avukat != null)
                {
                    returnValue.Icerik += "Av. " + avukat.AD;
                    returnValue.Icerik += Environment.NewLine;
                    //returnValue.Icerik += adres;
                }
                if (foyum.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Count > 1)
                {
                    returnValue.Icerik += ",";
                }
            }

            return returnValue;
        }

        public static string getIcraSozlesmeBilgisi(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum, TextControl tCnt)
        {
            DosyadakiSozlesmeler = new TList<AV001_TDI_BIL_SOZLESME>();
            string returnValues = "";
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>), typeof(TList<AV001_TDI_BIL_SOZLESME>));
            TList<AV001_TI_BIL_ALACAK_NEDEN> lstAlacakNedens = foyum.AV001_TI_BIL_ALACAK_NEDENCollection;
            int formOrnekNo = Convert.ToInt32(AvukatProLib2.Data.DataRepository.TI_KOD_FORM_TIPProvider.GetByID(foyum.FORM_TIP_ID.Value).FORM_ORNEK_NO);
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(lstAlacakNedens, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME>));
            for (int i = 0; i < lstAlacakNedens.Count; i++)
            {
                TList<AV001_TDI_BIL_SOZLESME> lstAlacakNedenSozlesme = lstAlacakNedens[i].AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW;
                if (foyum.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME.Count > 0)
                {
                    bool varmi = false;
                    for (int y = 0; y < lstAlacakNedenSozlesme.Count; y++)
                    {
                        for (int z = 0; z < foyum.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME.Count; z++)
                        {
                            if (lstAlacakNedenSozlesme[y].ID == foyum.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME[z].ID)
                            {
                                varmi = true;
                            }
                        }
                    }
                    if (!varmi)
                    {
                        lstAlacakNedenSozlesme.AddRange(foyum.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME);
                    }
                }

                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(lstAlacakNedenSozlesme, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_SOZLESME), typeof(TList<AV001_TI_BIL_GAYRIMENKUL>), typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE), typeof(TDI_KOD_SOZLESME_TIP), typeof(TDI_KOD_SOZLESME_ALT_TIP), typeof(TDI_KOD_DOVIZ_TIP));

                for (int y = 0; y < lstAlacakNedenSozlesme.Count; y++)
                {
                    if (SozlesmeEklendimi(lstAlacakNedenSozlesme[y]))
                    {
                        continue;
                    }

                    if (lstAlacakNedenSozlesme[y].TIP_ID != 2)
                    {
                        string tesciltarihi = "";

                        if (lstAlacakNedenSozlesme[y].SICIL_TARIHI.HasValue)
                        {
                            tesciltarihi = TarihBicimlendirme(lstAlacakNedenSozlesme[y].SICIL_TARIHI.Value);
                            returnValues += tesciltarihi + " tescil tarihli ,";
                        }

                        if (lstAlacakNedenSozlesme[y].BASLANGIC_TARIHI.HasValue)
                        {
                            returnValues += TarihBicimlendirme(lstAlacakNedenSozlesme[y].BASLANGIC_TARIHI.Value) + " ba�lang�� tarihli ,";
                        }

                        if (lstAlacakNedenSozlesme[y].NOTER_YEVMIYE_NO != String.Empty)
                        {
                            returnValues += lstAlacakNedenSozlesme[y].NOTER_YEVMIYE_NO + " yevmiye nolu ";
                        }

                        SayiOkuma so = new SayiOkuma();

                        if (lstAlacakNedenSozlesme[y].REHIN_CINS_ANA_TURU.HasValue && lstAlacakNedenSozlesme[y].REHIN_CINS_ANA_TURU.Value != 1)
                        {
                            returnValues += so.ParaFormatla(lstAlacakNedenSozlesme[y].BEDELI.ToString()) + lstAlacakNedenSozlesme[y].BEDELI_DOVIZ_IDSource.DOVIZ_KODU + " bedelli ";
                        }

                        returnValues += " yaz�l�";
                        returnValues += " kendi lehine ";
                        if (lstAlacakNedenSozlesme[y].ALT_TIP_ID.HasValue)
                        {
                            returnValues += lstAlacakNedenSozlesme[y].ALT_TIP_IDSource.ALT_TIP + " ";
                        }

                        if (lstAlacakNedenSozlesme[y].REHIN_CINS_ANA_TURU.HasValue)
                        {
                            if (lstAlacakNedenSozlesme[y].REHIN_CINS_ANA_TURU.Value == 0)
                            {
                                returnValues += "(Limit ipote�i)";
                            }
                            else if (lstAlacakNedenSozlesme[y].REHIN_CINS_ANA_TURU.Value == 1)
                            {
                                returnValues += "(Ana para ipote�i)";
                            }
                        }
                        else
                        {
                        }

                        returnValues += ". ";
                    }
                    else
                    {
                        if (lstAlacakNedenSozlesme[y].IMZA_TARIHI.HasValue)
                        {
                            returnValues += TarihBicimlendirme(lstAlacakNedenSozlesme[y].IMZA_TARIHI.Value) + " tarihli ";
                        }
                        if (lstAlacakNedenSozlesme[y].BEDELI != decimal.Zero && lstAlacakNedenSozlesme[y].BEDELI != decimal.MinValue)
                        {
                            returnValues += lstAlacakNedenSozlesme[y].BEDELI + lstAlacakNedenSozlesme[y].BEDELI_DOVIZ_IDSource.DOVIZ_KODU + " bedelli ";
                        }

                        returnValues += lstAlacakNedenSozlesme[y].TIP_IDSource.TIP;
                    }

                    if (lstAlacakNedenSozlesme.Count > 1)
                    {
                        returnValues += ",";
                    }
                }
            }
            return returnValues;
        }
        
        public static List<TextField> GetIcraTakipTalebiFromNesne(AvukatProLib2.Entities.AV001_TI_BIL_FOY foy)
        {
            //if (foy.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME.Count == 0)
            //    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME>));
            //if (foy.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME.FindAll(vi => vi.REHIN_CINS_ANA_TURU == 1).Count > 0)
            //{
            //    List<TextField> returnValue = new List<TextField>();
            //    return returnValue;
            //}

            string yazi = "Bu alan i�in Bir De�er Bulunamad� ... ";
            decimal harcaEsasDeger = decimal.MinValue;

            double vorn = 0;
            bool kdvsiVarmi = false;
            bool oivsiVarmi = false;
            AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum = foy;
            DateTime tata = foyum.TAKIP_TARIHI.Value;
            int ftid = 0;
            int dtip = 0;

            if (foyum.KDV_TO != 0)
            {
                IcraDegiskenDegerAta("&KDV&", " KDV si ile birlikte ");
                kdvsiVarmi = true;
            }

            if (foyum.OIV_TO != 0)
            {
                IcraDegiskenDegerAta("&OIVKDV&", " OIV si ile birlikte ");
                oivsiVarmi = true;
            }
            if (foyum.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
            TList<AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN> AlacakNedenler = foyum.AV001_TI_BIL_ALACAK_NEDENCollection;

            TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> kritereGoreAlacakNedenler = new TList<TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN>();

            string faizLAfi = "";
            string kademeliSabitLafi = string.Empty;
            bool farkliFaziTipleriVarmi = false;
            for (int i = 0; i < AlacakNedenler.Count; i++)
            {
                if (AlacakNedenler[i].ALACAK_NEDEN_KOD_ID.HasValue)
                {
                    if (string.IsNullOrEmpty(kademeliSabitLafi))
                    {
                        kademeliSabitLafi = (AlacakNedenler[i].SABIT_FAIZ_UYGULA == true ? string.Empty : "kademeli olarak hesaplanacak");
                    }

                    // farkl� fazi tipi varsa
                    if (AlacakNedenler[i].ALACAK_FAIZ_TIP_ID != AlacakNedenler[0].ALACAK_FAIZ_TIP_ID)
                    {
                        farkliFaziTipleriVarmi = true;
                    }
                    else if (AlacakNedenler[i].ALACAK_FAIZ_TIP_ID == AlacakNedenler[0].ALACAK_FAIZ_TIP_ID)
                    {
                        if (AlacakNedenler[i].ALACAK_FAIZ_TIP_ID == (int)FaizTip.Temmerut_Faiz)
                        {
                            if (AlacakNedenler[i].UYGULANACAK_FAIZ_ORANI != AlacakNedenler[0].UYGULANACAK_FAIZ_ORANI)
                            {
                                farkliFaziTipleriVarmi = true;
                            }
                        }
                    }

                    AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(AlacakNedenler[i], false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_FAIZ_TIP));
                    if (AlacakNedenler[i].TO_ALACAK_FAIZ_TIP_IDSource != null)
                    {
                        faizLAfi = AlacakNedenler[i].ALACAK_FAIZ_TIP_IDSource.FAIZ_TIP;
                    }

                    harcaEsasDeger = AlacakNedenler[i].HARCA_ESAS_DEGER;

                    if (AlacakNedenler[i].ALACAK_FAIZ_TIP_ID != null)
                    {
                        ftid = AlacakNedenler[i].ALACAK_FAIZ_TIP_ID.Value;
                    }

                    dtip = AlacakNedenler[i].ISLEME_KONAN_TUTAR_DOVIZ_ID.Value;

                    IcraDegiskenDegerAta("YFM", FaizHelper.FaizOraniGetir(ftid, dtip, tata));

                    if (kdvsiVarmi)
                    {
                        if (AlacakNedenler[i].KDV_TIP_ID.HasValue)
                            vorn = FaizHelper.KDVOraniGetir(AlacakNedenler[i].KDV_TIP_ID.Value, tata);
                    }
                    if (oivsiVarmi)
                    {
                        var faizTarife = AvukatProLib2.Data.DataRepository.TDI_CET_FAIZ_TARIFEProvider.GetByFAIZ_TIP_IDTARIFE_GECERLILIK_BASLANGIC_TARIHIDOVIZ_TIP_ID(ftid, tata, dtip);
                        if (faizTarife != null)
                        {
                            vorn = faizTarife.TARIFE_TUTARI;
                        }
                    }

                    IcraDegiskenDegerAta("&VERGIORN&", vorn);
                    IcraDegiskenDegerAta("&GDK&", foyum.TAKIP_CIKISI_DOVIZ_ID);
                }
            }
            string faizOran = FaizHelper.FaizOraniGetir(ftid, dtip, tata).ToString();

            if (ftid == 9)
            {
                faizOran = foyum.AV001_TI_BIL_ALACAK_NEDENCollection[0].UYGULANACAK_FAIZ_ORANI.ToString();
            }
            if (farkliFaziTipleriVarmi)
            {
                faizLAfi = "**, alacak nedenlerinin yan�nda yer alan faiz tiplerine g�re";
                faizOran = "";
            }

            var ilamMahkemeList = BelgeUtil.Inits.context.per_ILAM_ACIKLAMAs.Where(item => item.ICRA_FOY_ID == foyum.ID).ToList();

            TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN DEG = TalepAciklamasiGetir(foy);
            if (DEG.ID == 0)
            {
                yazi = "Her hangibir a��klama de�eri Bulunamad�";
            }
            else
            {
                yazi = DEG.ACIKLAMA;
            }

            yazi = Replace("YFM", yazi, faizOran + " " + faizLAfi + " " + kademeliSabitLafi + " ");
            if (Convert.ToInt32(vorn) != 0)
            {
                if (oivsiVarmi)
                {
                    yazi = Replace("&VERGIORN&", yazi, " %" + vorn.ToString() + " ��V ");
                }
                if (kdvsiVarmi)
                {
                    yazi = Replace("&VERGIORN&", yazi, " %" + vorn.ToString() + " KDV ");
                }
            }
            else
            {
                yazi = Replace("&VERGIORN&", yazi, "");
            }
            SayiOkuma so = new SayiOkuma();
            decimal DovizKuru = DovizHelper.CevirYTL(1, foy.ASIL_ALACAK_DOVIZ_ID, foy.TAKIP_TARIHI.Value);
            if (DovizKuru == 0) DovizKuru = 1;
            yazi = Replace("&GDK&", yazi, DovizKuru.ToString());
            yazi = Replace("ASIL ALACAK", yazi, so.ParaFormatla(foy.ASIL_ALACAK));
            yazi = Replace("&KDV&", yazi, "");
            yazi = Replace("D�V�Z KURU", yazi, DovizKuru.ToString());
            yazi = Replace("HARCA ESAS DE�ER", yazi, so.ParaFormatla(harcaEsasDeger));

            var asilAlacakIslemisFaiz = foy.ASIL_ALACAK + foy.ISLEMIS_FAIZ;

            yazi = Replace("&ATK&", yazi, so.ParaFormatla(DovizKuru * asilAlacakIslemisFaiz));
            yazi = Replace("&DTC&", yazi, so.ParaFormatla(asilAlacakIslemisFaiz));

            List<int> faizTipListesi = new List<int>();

            foreach (var neden in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                if (neden.ALACAK_FAIZ_TIP_ID.HasValue)
                {
                    if (!faizTipListesi.Contains(neden.ALACAK_FAIZ_TIP_ID.Value))
                        faizTipListesi.Add(neden.ALACAK_FAIZ_TIP_ID.Value);
                }
            }
            string faizTipiYazisi = string.Empty;
            if (faizTipListesi.Count == 1)
            {
                if (faizTipListesi[0] == (int)FaizTip.�zel_Sabit_Faiz || faizTipListesi[0] == (int)FaizTip.Temmerut_Faiz)
                {
                    faizTipiYazisi = "%&FO& Temerr�t Faizi";
                }
                else
                {
                    faizTipiYazisi = " %&FO& faizi ile birlikte";
                }
            }
            else if (faizTipListesi.Count > 1)
            {
                faizTipiYazisi = "**";
            }

            yazi = Replace("&FAIZ_TIPI&", yazi, faizTipiYazisi);

            if (ilamMahkemeList.Count == 0)
            {
                yazi = Replace("&ILAMACIK&", yazi, "");
            }
            else
                if (ilamMahkemeList.Count == 1)
                {
                    yazi = Replace("&ILAMACIK&", yazi, ilamMahkemeList[0].ILAM_ACIKLAMASI);
                }
                else
                {
                    string aciklama = "";
                    for (int ii = 0; ii < ilamMahkemeList.Count; ii++)
                    {
                        string No = "";
                        string Adliye = "";
                        string Gorev = "";
                        if (!String.IsNullOrEmpty(ilamMahkemeList[ii].NO))
                        {
                            No = ilamMahkemeList[ii].NO;
                        }
                        if (!String.IsNullOrEmpty(ilamMahkemeList[ii].ADLIYE))
                        {
                            Adliye = ilamMahkemeList[ii].ADLIYE;
                        }
                        if (!String.IsNullOrEmpty(ilamMahkemeList[ii].GOREV))
                        {
                            Gorev = ilamMahkemeList[ii].GOREV;
                        }
                        aciklama += Adliye + No + " " + Gorev + ilamMahkemeList[ii].KARAR_TARIHI + ilamMahkemeList[ii].KARAR_NO + " nolu ilam� ," + Environment.NewLine;
                    }

                    yazi = Replace("&ILAMACIK&", yazi, ilamMahkemeList[0].ILAM_ACIKLAMASI);
                }

            List<int> faizTipiListesi = new List<int>();
            List<double> temerrutListesi = new List<double>();

            foreach (var aNeden in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                if (!aNeden.ALACAK_FAIZ_TIP_ID.HasValue) continue;
                if (HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(aNeden)) continue;

                if (aNeden.ALACAK_FAIZ_TIP_ID.Value != (int)FaizTip.Temmerut_Faiz)
                {
                    if (!faizTipiListesi.Contains(aNeden.ALACAK_FAIZ_TIP_ID.Value))
                        faizTipiListesi.Add(aNeden.ALACAK_FAIZ_TIP_ID.Value);
                }
                else if (aNeden.ALACAK_FAIZ_TIP_ID.Value == (int)FaizTip.Temmerut_Faiz)
                {
                    if (!temerrutListesi.Contains(aNeden.UYGULANACAK_FAIZ_ORANI))
                        temerrutListesi.Add(aNeden.UYGULANACAK_FAIZ_ORANI);
                }
            }
            if ((temerrutListesi.Count > 1 || faizTipiListesi.Count > 1)
                ||
                (temerrutListesi.Count == 1 && faizTipiListesi.Count == 1))
            {
                yazi = Replace("&FO&", yazi, " *a�a��da alacak nedenlerinin yan�nda belirtilen ");
            }
            else
            {
                if (faizTipListesi.Count > 0 && faizTipListesi[0] == (int)FaizTip.Temmerut_Faiz)
                {
                    foreach (var aNeden in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        if (aNeden.ALACAK_FAIZ_TIP_ID.HasValue && aNeden.ALACAK_FAIZ_TIP_ID.Value == (int)FaizTip.Temmerut_Faiz)
                        {
                            yazi = Replace("&FO&", yazi, (aNeden.UYGULANACAK_FAIZ_ORANI.ToString() + " Temerr�t Faiz"));
                        }
                    }
                }
                else
                    yazi = Replace("&FO&", yazi, FaizOraniVeTipiGetr(ref tata, dtip, faizTipListesi));
            }

            List<TextField> lsttF = new List<TextField>();

            if (yazi.StartsWith("tutar�ndaki "))
                yazi = yazi.Replace(" tutar�ndaki ", " ");
            if (DEG.ID == 0)
            {
                TextField tff = new TextField(yazi);
                lsttF.Add(tff);
                tff.DoubleClickEvent = true;
                tff.Deleteable = false;
                tff.ShowActivated = true;

                tff.Name = "<Aciklama>;" + foyum.FOY_NO;
            }
            else
            {
                string[] kelimeler = yazi.Split(' ');
                for (int i = 0; i < kelimeler.Length; i++)
                {
                    lsttF.Add(new TextField(kelimeler[i]));
                }
            }

            for (int y = 0; y < degis.Length; y++)
            {
                DegiskenleriYerlestir(lsttF, degis[y]);
            }

            return lsttF;
        }

        public static DegiskenDegeri GetIcraTarafCariKimlikBilgisi(IEntity Record, TextControl tControl, bool useTable, bool? takipEdenmi, int? sifat)
        {
            DegiskenDegeri returnValues = new DegiskenDegeri();
            returnValues.DonusTipi = DegiskenResulTType.String;
            returnValues.Icerik = "";

            if (Record is AV001_TI_BIL_FOY)
            {
                AV001_TI_BIL_FOY foyum = ((AV001_TI_BIL_FOY)Record);
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));
                for (int i = 0; i < foyum.AV001_TI_BIL_FOY_TARAFCollection.Count; i++)
                {
                    AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_ID.Value);
                    DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(cari, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));

                    if (!cari.FIRMA_MI & !foyum.AV001_TI_BIL_FOY_TARAFCollection[i].TAKIP_EDEN_MI)
                    {
                        if (!string.IsNullOrEmpty(returnValues.Icerik))
                            returnValues.Icerik += Environment.NewLine;

                        if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection.Count == 0)
                            returnValues.Icerik += string.Format("Taraf Ad�:{0}", cari.AD);
                        else
                            returnValues.Icerik += CariBilgileriniHazirla(cari);
                    }
                }
            }
            else if (Record is AV001_TD_BIL_FOY)
            {
                AV001_TD_BIL_FOY foyum = ((AV001_TD_BIL_FOY)Record);
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(foyum, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_TARAF>));
                for (int i = 0; i < foyum.AV001_TD_BIL_FOY_TARAFCollection.Count; i++)
                {
                    AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(foyum.AV001_TD_BIL_FOY_TARAFCollection[i].CARI_ID.Value);
                    DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(cari, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));

                    if (!cari.FIRMA_MI & foyum.AV001_TD_BIL_FOY_TARAFCollection[i].DAVA_EDEN_MI == takipEdenmi)
                    {
                        if (!string.IsNullOrEmpty(returnValues.Icerik))
                            returnValues.Icerik += Environment.NewLine;

                        if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection.Count == 0)
                            returnValues.Icerik += string.Format("Taraf Ad�:{0}", cari.AD);
                        else
                            returnValues.Icerik += CariBilgileriniHazirla(cari);
                    }
                }
            }

            return returnValues;
        }

        public static List<TextField> GetIcrmBilgisiFromNesne(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
        {
            List<TextField> lstfields = new List<TextField>();

            AvukatProLib2.Entities.TDI_KOD_ADLI_BIRIM_ADLIYE adliye = new TDI_KOD_ADLI_BIRIM_ADLIYE();
            AvukatProLib2.Entities.TDI_KOD_ADLI_BIRIM_GOREV gorev = new TDI_KOD_ADLI_BIRIM_GOREV();
            AvukatProLib2.Entities.TDI_KOD_ADLI_BIRIM_NO no = new TDI_KOD_ADLI_BIRIM_NO();

            if (foyum.ADLI_BIRIM_ADLIYE_ID.HasValue)
            {
                adliye = AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetByID(foyum.ADLI_BIRIM_ADLIYE_ID.Value);
            }
            if (foyum.ADLI_BIRIM_GOREV_ID.HasValue)
            {
                gorev = AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.GetByID(foyum.ADLI_BIRIM_GOREV_ID.Value);
            }
            if (foyum.ADLI_BIRIM_NO_ID.HasValue)
            {
                no = AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_NOProvider.GetByID(foyum.ADLI_BIRIM_NO_ID.Value);
            }

            InsertTextField(string.Format(" {0}", adliye.ADLIYE), adliye.ID, "adliye", lstfields, "TDI_KOD_ADLI_BIRIM_ADLIYE");
            InsertTextField(string.Format(" {0}", no.NO), no.ID, "no", lstfields, "TDI_KOD_ADLI_BIRIM_NO");
            InsertTextField(string.Format(" {0}", gorev.ACIKLAMA), gorev.ID, "gorev", lstfields, "TDI_KOD_ADLI_BIRIM_GOREV");

            return lstfields;
        }

        public static string GetIlamBilgileri(AV001_TI_BIL_FOY foy)
        {
            if (!foy.FORM_TIP_ID.HasValue) return string.Empty;

            string aciklama = string.Empty;

            if (foy.FORM_TIP_ID.Value == (int)FormTipleri.Form53)
            {
                if (foy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ILAM_MAHKEMESI>));

                foreach (var item in foy.AV001_TI_BIL_ILAM_MAHKEMESICollection)
                {
                    if (BelgeUtil.Inits._AdliBirimAdliyeGetir == null)
                        BelgeUtil.Inits._AdliBirimAdliyeGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetAll();
                    if (BelgeUtil.Inits._AdliBirimNoGetir == null)
                        BelgeUtil.Inits._AdliBirimNoGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_NOProvider.GetAll();
                    string mahkeme = BelgeUtil.Inits._AdliBirimAdliyeGetir.Find(vi => vi.ID == item.ADLI_BIRIM_ADLIYE_ID).ADLIYE + " " + BelgeUtil.Inits._AdliBirimNoGetir.Find(vi => vi.ID == item.ADLI_BIRIM_NO_ID).NO + BelgeUtil.Inits._AdliBirimGorevGetir_Enter.Find(vi => vi.ID == item.ADLI_BIRIM_GOREV_ID).GOREV;
                    string tarih = item.KARAR_TARIHI.HasValue ? item.KARAR_TARIHI.Value.ToShortDateString() : string.Empty;
                    string esasNo = !string.IsNullOrEmpty(item.ESAS_NO) ? item.ESAS_NO : string.Empty;
                    string kararNo = !string.IsNullOrEmpty(item.KARAR_NO) ? item.KARAR_NO : string.Empty;

                    if (item.ILAM_TIP_ID == 1)//MAHKEME �LAMI
                    {
                        aciklama += mahkeme + " Mahkemesinin ";
                        if (!string.IsNullOrEmpty(tarih)) aciklama += tarih + " tarihli ";
                        if (!string.IsNullOrEmpty(esasNo)) aciklama += esasNo + " E. ";
                        if (!string.IsNullOrEmpty(kararNo)) aciklama += "ve " + kararNo + " K. say�l� ";
                        aciklama += "ilam�.";
                    }
                    else
                    {
                        aciklama += mahkeme + " Noterli�inden resen d�zenlenmi� bulunan ";
                        if (!string.IsNullOrEmpty(tarih)) aciklama += tarih + " tarihli ";
                        if (!string.IsNullOrEmpty(esasNo)) aciklama += esasNo + " yevmiye numaral� ";
                        aciklama += "noter senedi.";
                    }
                }
            }
            return aciklama;
        }

        /// <summary>
        /// icradaki alacak nedenlerine bagl� sozlesmelerdeki sozlesme tipi 2() olmayan rehin cins ana turu 0 olan
        /// s�zlesmlerin bed3ellerini toplay�p kac tane sozlesme oldugu say�s�yla
        /// "Rehin s�zle�mesi bedeli ile s�n�rl� olmak �zere rehin limiti olan toplam
        /// sozlesmeSayisi   adet s�zle�mmede ki toplam  toplam
        ///  DOVIZ_KODU   toplam TAKIP_TARIHI DOVIZ_KODU bedelini a�mamak �zere "
        ///  �eklinde stringt olarak geriye dondurur
        /// </summary>
        /// <param name="foyum">hangi kay�t alt�ndaki alacak nedeni alt�ndaki sozlesmeler gelsin</param>
        /// <returns>geriye donecek de�er. </returns>
        public static string GetIpotekliAciklama(AV001_TI_BIL_FOY foyum)
        {
            return "";//Bahattin bey bu bilginin g�sterilmesinin gereksiz oldu�unu s�yledi�inden a��klama kald�r�ld�. MB
            string returnValues = "";
            TDI_KOD_DOVIZ_TIP doviz = new TDI_KOD_DOVIZ_TIP();
            int sozlesmeSayisi = 0;

            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
            TList<AV001_TI_BIL_ALACAK_NEDEN> lstAlacakNedens = foyum.AV001_TI_BIL_ALACAK_NEDENCollection;
            int formOrnekNo = Convert.ToInt32(AvukatProLib2.Data.DataRepository.TI_KOD_FORM_TIPProvider.GetByID(foyum.FORM_TIP_ID.Value).FORM_ORNEK_NO);
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(lstAlacakNedens, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME>));

            decimal toplam = 0;
            List<int> eklenenlerinIdleri = new List<int>();
            for (int i = 0; i < lstAlacakNedens.Count; i++)
            {
                TList<AV001_TDI_BIL_SOZLESME> lstAlacakNedenSozlesme = lstAlacakNedens[i].AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW;

                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(lstAlacakNedens[i].AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_SOZLESME), typeof(TList<AV001_TI_BIL_GAYRIMENKUL>), typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE), typeof(TDI_KOD_SOZLESME_TIP), typeof(TDI_KOD_SOZLESME_ALT_TIP), typeof(TDI_KOD_DOVIZ_TIP));
                for (int y = 0; y < lstAlacakNedenSozlesme.Count; y++)
                {
                    if (lstAlacakNedenSozlesme[y].TIP_ID != 2) // limit ipote�i ise
                    {
                        if (lstAlacakNedenSozlesme[y].REHIN_CINS_ANA_TURU.HasValue)
                        {
                            if (lstAlacakNedenSozlesme[y].REHIN_CINS_ANA_TURU.Value == 0
                                && !eklenenlerinIdleri.Contains(lstAlacakNedenSozlesme[y].ID))
                            {
                                eklenenlerinIdleri.Add(lstAlacakNedenSozlesme[y].ID);

                                toplam += lstAlacakNedenSozlesme[y].BEDELI;
                                doviz = lstAlacakNedenSozlesme[y].BEDELI_DOVIZ_IDSource;
                                sozlesmeSayisi++;
                            }
                        }
                    }

                    #region <GKN-20090614>

                    //ne i�e yarad���n� anlayamad�m

                    //if (lstAlacakNedens.Count > 1)
                    //{
                    //   returnValues += ",";
                    //}

                    #endregion <GKN-20090614>
                }
            }

            if (sozlesmeSayisi == 0)
            {
                return "";
            }
            SayiOkuma so = new SayiOkuma();
            returnValues += Environment.NewLine;
            returnValues += " * ";

            if (foyum.FORM_TIP_ID == 10)//Kira Takiplerinde Bilgilerin s�zle�meden gelmesini sa�lamak i�in eklendi. MB
            {
                returnValues += sozlesmeSayisi + " adet " + TarihBicimlendirme(lstAlacakNedens[0].AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW[0].IMZA_TARIHI.Value) + " tarihli " + so.ParaFormatla(toplam.ToString()) + " " + doviz.DOVIZ_KODU + " (" + so.ParaFormatla(DovizHelper.CevirYTL((toplam), doviz.ID, foyum.TAKIP_TARIHI.Value)) + " " + BelgeUtil.Inits.DovizIdSource(1).DOVIZ_KODU + ")" + " y�ll�k bedelli kira s�zle�mesi.";
            }
            else if ((new ParaVeDovizId(toplam, doviz.ID, foyum.TAKIP_TARIHI).YtlHali) <= (new ParaVeDovizId(foyum.ASIL_ALACAK, foyum.ASIL_ALACAK_DOVIZ_ID, foyum.TAKIP_TARIHI).YtlHali))
                returnValues += sozlesmeSayisi + " adet resmi senetteki toplam " + so.ParaFormatla(toplam.ToString()) + " " + doviz.DOVIZ_KODU + " (" + so.ParaFormatla(DovizHelper.CevirYTL((toplam), doviz.ID, foyum.TAKIP_TARIHI.Value)) + " " + BelgeUtil.Inits.DovizIdSource(1).DOVIZ_KODU + ")" + "rehin bedeli ile s�n�rl� olmak �zere tahsilat talebidir.";
            else
                returnValues += sozlesmeSayisi + " adet resmi senetteki toplam " + so.ParaFormatla(toplam.ToString()) + " " + doviz.DOVIZ_KODU + " (" + so.ParaFormatla(DovizHelper.CevirYTL((toplam), doviz.ID, foyum.TAKIP_TARIHI.Value)) + " " + BelgeUtil.Inits.DovizIdSource(1).DOVIZ_KODU + ")" + "rehin bedeline ula��ncaya kadar tahsilat talebilidir.";

            //  sozlesmeToplami = toplam;

            return returnValues;
        }

        public static string GetKayitEden(AvukatProLib2.Entities.IEntity foyum)
        {
            if (foyum is AV001_TD_BIL_FOY)
            {
                return (((AV001_TD_BIL_FOY)foyum).KONTROL_KIM);
            }

            if (foyum is AV001_TI_BIL_FOY)
            {
                return (((AV001_TI_BIL_FOY)foyum).KONTROL_KIM);
            }

            if (foyum is AV001_TD_BIL_HAZIRLIK)
            {
                return (((AV001_TD_BIL_HAZIRLIK)foyum).KONTROL_KIM);
            }

            if (foyum is AV001_TDI_BIL_CARI)
            {
                return (((AV001_TDI_BIL_CARI)foyum).KONTROL_KIM);
            }

            if (foyum is AV001_TDI_BIL_RUCU)
            {
                return (((AV001_TDI_BIL_RUCU)foyum).KONTROL_KIM);
            }

            return String.Empty;
        }

        public static string GetKayitSaati(AvukatProLib2.Entities.IEntity foyum)
        {
            if (foyum is AV001_TD_BIL_FOY)
            {
                return GetSaat(((AV001_TD_BIL_FOY)foyum).KAYIT_TARIHI);
            }

            if (foyum is AV001_TI_BIL_FOY)
            {
                return GetSaat(((AV001_TI_BIL_FOY)foyum).KAYIT_TARIHI);
            }

            if (foyum is AV001_TD_BIL_HAZIRLIK)
            {
                return GetSaat(((AV001_TD_BIL_HAZIRLIK)foyum).KAYIT_TARIHI);
            }

            if (foyum is AV001_TDI_BIL_CARI)
            {
                return GetSaat(((AV001_TDI_BIL_CARI)foyum).KAYIT_TARIHI);
            }

            if (foyum is AV001_TDI_BIL_RUCU)
            {
                return GetSaat(((AV001_TDI_BIL_RUCU)foyum).KAYIT_TARIHI);
            }

            return String.Empty;
        }

        public static string GetKayitTarihi(AvukatProLib2.Entities.IEntity foyum)
        {
            if (foyum is AV001_TD_BIL_FOY)
            {
                return TarihBicimlendirme(((AV001_TD_BIL_FOY)foyum).KAYIT_TARIHI);
            }

            if (foyum is AV001_TI_BIL_FOY)
            {
                return TarihBicimlendirme(((AV001_TI_BIL_FOY)foyum).KAYIT_TARIHI);
            }

            if (foyum is AV001_TD_BIL_HAZIRLIK)
            {
                return TarihBicimlendirme(((AV001_TD_BIL_HAZIRLIK)foyum).KAYIT_TARIHI);
            }

            if (foyum is AV001_TDI_BIL_CARI)
            {
                return TarihBicimlendirme(((AV001_TDI_BIL_CARI)foyum).KAYIT_TARIHI);
            }

            if (foyum is AV001_TDI_BIL_RUCU)
            {
                return TarihBicimlendirme(((AV001_TDI_BIL_RUCU)foyum).KAYIT_TARIHI);
            }

            return String.Empty;
        }

        public static string GetKlasoreBagliTakipAciklama(AV001_TI_BIL_FOY foy)
        {
            string aciklama = string.Empty;

            var proje = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByICRA_FOY_IDFromAV001_TDIE_BIL_PROJE_ICRA_FOY(foy.ID).FirstOrDefault();

            if (proje != null)
            {
                switch (foy.FORM_TIP_ID)
                {
                    case (int)FormTipleri.Form49:
                        BelgeUtil.Inits.KrediBorclusu = 0;
                        if (proje.AV001_TDIE_BIL_PROJE_TEMINATCollection.Count == 0)
                            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_TEMINAT>));
                        if (proje.AV001_TDIE_BIL_PROJE_TEMINATCollection.Count > 0)
                        {
                            List<SorumlulukMiktarlari> sorumlulukMiktarlariList = new List<SorumlulukMiktarlari>();

                            if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                            DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(foy.AV001_TI_BIL_ALACAK_NEDENCollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));

                            foreach (var alacak in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                            {
                                foreach (var taraf in alacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                                {
                                    if (taraf.TARAF_SIFAT_ID == 1) continue;
                                    SorumlulukMiktarlari item = new SorumlulukMiktarlari();
                                    item.BorcluCariID = taraf.TARAF_CARI_ID;
                                    item.SorumlulukMiktari = taraf.SORUMLU_OLUNAN_MIKTAR.Value;
                                    item.SorumlulukMiktariParaBirimi = taraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.Value;
                                    item.AlacakTutari = alacak.ISLEME_KONAN_TUTAR;
                                    sorumlulukMiktarlariList.Add(item);
                                }
                            }

                            var sozlesmeList = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_TEMINAT(proje.ID).FindAll(vi => vi.REHIN_CINS_ANA_TURU != 1 && (vi.ALT_TIP_ID == (int)SozlesmeAltTip.Gayrimenkul_Ipotegi || vi.ALT_TIP_ID == (int)SozlesmeAltTip.Gemi_Ipotegi || vi.ALT_TIP_ID == (int)SozlesmeAltTip.Arac_Rehni || vi.ALT_TIP_ID == (int)SozlesmeAltTip.Hava_Araci_Ipotegi));

                            ParaVeDovizId toplamTeminatTutar = new ParaVeDovizId();

                            if (sozlesmeList.Count == 0) return string.Empty;

                            foreach (var item in sozlesmeList)
                            {
                                //Para birimlerinin farkl� olmas� ihtimali oldu�undan foreach i�erisinde tek tek yap�ld�.
                                toplamTeminatTutar = ParaVeDovizId.Topla(toplamTeminatTutar, new ParaVeDovizId(item.BEDELI, item.BEDELI_DOVIZ_ID));
                            }
                            toplamTeminatTutar = new ParaVeDovizId(sozlesmeList.Sum(vi => vi.BEDELI), 1);

                            if (BelgeUtil.Inits._per_CariGetir == null)
                                BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();

                            // Klas�r� hesaplatmadan direkt rapor al�nmaya �al���l�nca Kredi Bo�lusu bilgisinin gelmesi i�in eklendi.
                            if (BelgeUtil.Inits.KrediBorclusu == 0)
                            {
                                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
                                AV001_TI_BIL_ALACAK_NEDEN_TARAF krediBorclusu = null;
                                foreach (var aNeden in proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN)
                                {
                                    var taraf = aNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.FirstOrDefault(vi => vi.TARAF_SIFAT_ID == 2);
                                    if (taraf != null)
                                    {
                                        krediBorclusu = aNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.FirstOrDefault(vi => vi.TARAF_SIFAT_ID == 2);
                                        break;
                                    }
                                }
                                if (krediBorclusu != null)
                                    BelgeUtil.Inits.KrediBorclusu = krediBorclusu.TARAF_CARI_ID;
                                if (BelgeUtil.Inits.KrediBorclusu == 0)
                                {
                                    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
                                    foreach (var aNeden in proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI)
                                    {
                                        var taraf = aNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.FirstOrDefault(vi => vi.TARAF_SIFAT_ID == 2);
                                        if (taraf != null)
                                        {
                                            krediBorclusu = aNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.FirstOrDefault(vi => vi.TARAF_SIFAT_ID == 2);
                                            break;
                                        }
                                    }
                                    if (krediBorclusu != null)
                                        BelgeUtil.Inits.KrediBorclusu = krediBorclusu.TARAF_CARI_ID;
                                }
                            }

                            var foyTarafList = DataRepository.AV001_TI_BIL_FOY_TARAFProvider.GetByICRA_FOY_ID(foy.ID);

                            //A�a��daki kod farkl� sorumluluk miktarlar�nda gerekli a��klamalar�n gelmesini engelledi�inden kald�r�ld�. MB
                            //if (foyTarafList.Find(vi => vi.CARI_ID == BelgeUtil.Inits.KrediBorclusu) == null)
                            //{
                            //    aciklama += "( Alacakl�, her t�rl� fazlaya ili�kin haklar� ve tahsilde tekerr�r etmemek �zere alaca��n�n di�er teminatlar�na ve sorumlular�na m�racaat haklar�n� sakl� tutmu�tur. )\r\n\r\n";
                            //    return aciklama;
                            //}

                            SayiOkuma sa = new SayiOkuma();

                            if (foyTarafList.Find(vi => vi.CARI_ID == BelgeUtil.Inits.KrediBorclusu) != null)
                            {
                                string borclu = BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == BelgeUtil.Inits.KrediBorclusu).AD;

                                aciklama += string.Format("\r\n( Bor�lulardan {0}, ipotek / rehin limiti olan {1}'n� a�an k�sm�ndan ve ��bu dosyan�n t�m ferilerinden, di�er bor�lular ise ��bu dosya borcunun  tamam�ndan ve t�m ferilerinden sorumludurlar. )", borclu, sa.ParaFormatla(toplamTeminatTutar.Para) + " TL");
                            }

                            Dictionary<int, decimal> farkliSorumluCariID = new Dictionary<int, decimal>();

                            foreach (var item in sorumlulukMiktarlariList.GroupBy(vi => vi.BorcluCariID).ToList())
                            {
                                if (item.Sum(vi => vi.SorumlulukMiktari) != item.Sum(vi => vi.AlacakTutari))//Sorumluluklar� FARKLI
                                {
                                    farkliSorumluCariID.Add(item.FirstOrDefault().BorcluCariID, item.Sum(vi => vi.SorumlulukMiktari));
                                }
                            }

                            if (farkliSorumluCariID.Count > 0)
                            {
                                if (aciklama.Length >= 1)
                                    aciklama = aciklama.Remove(aciklama.Length - 1, 1);

                                foreach (var item in farkliSorumluCariID)
                                {
                                    if (BelgeUtil.Inits._per_CariGetir == null)
                                        BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();
                                    string cari = BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == item.Key).AD;

                                    aciklama += string.Format("\r\nBorclulardan {0}, kefalet limiti nedeniyle as�l alaca��n {1} k�sm�ndan ve bu k�sma isabet eden vekalet �creti ve di�er ferilerinden ve sorumlu oldu�u as�l alacak �zerinden i�leyecek yukar�da belirtilen temerr�t faizi, gider vergisi ve takip giderlerinden;", cari, sa.ParaFormatla(item.Value) + " TL");
                                }
                                aciklama += "\r\nDi�er bor�lular ise borcun tamam�ndan ve t�m ferilerinden sorumludur. )\r\n\r\n";
                            }
                            aciklama += "( Alacakl�, her t�rl� fazlaya ili�kin haklar� ve tahsilde tekerr�r etmemek �zere alaca��n�n di�er teminatlar�na ve sorumlular�na m�racaat haklar�n� sakl� tutmu�tur. )\r\n\r\n";
                        }
                        else//ipotek/rehin yok ve "kefiller de borcun tamam�ndan sorumlu" �imdilik b�yle bir i�lem olmad���ndan sadece dosya taraflar�n�n sadece kefillerden olu�tu�u kontrol� yap�l�yor. MB
                        {
                            //A�a��daki kodlar, ipotek olmad��� durumda kefillerin d���nda kredi bor�lusu da takibe taraf olabilece�inden kald�r�ld�.
                            //var tarafList = DataRepository.AV001_TI_BIL_FOY_TARAFProvider.GetByICRA_FOY_ID(foy.ID);
                            //if (tarafList.FindAll(vi => vi.CARI_ID == BelgeUtil.Inits.KrediBorclusu).Count == 0 && tarafList.FindAll(vi => vi.TARAF_SIFAT_ID == (int)TarafSifat.M�TESELS�L_KEF�L || vi.TARAF_SIFAT_ID == (int)TarafSifat.�CRA_KEF�L).Count == tarafList.FindAll(vi => vi.TARAF_SIFAT_ID != 1).Count)
                            aciklama = "\r\n( Alacakl�, her t�rl� fazlaya ili�kin haklar�n� ve tahsilde tekerr�r etmemek �zere alaca��n�n di�er teminatlar�na ve sorumulular�na m�racaat haklar�n� sakl� tutmu�tur. )\r\n";
                        }
                        return aciklama;

                    case (int)FormTipleri.Form50:
                        if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                        ParaVeDovizId toplamAlacaklar = new ParaVeDovizId(foy.TAKIP_CIKISI, foy.TAKIP_CIKISI_DOVIZ_ID);
                        decimal gayriNakitAlacaklar = new decimal();
                        foreach (var item in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                        {
                            if (HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(item))
                            {
                                if (item.ISLEME_KONAN_TUTAR_DOVIZ_ID == 1)
                                    gayriNakitAlacaklar += item.ISLEME_KONAN_TUTAR;
                                else
                                    gayriNakitAlacaklar += DovizHelper.CevirYTL(item.ISLEME_KONAN_TUTAR, item.ISLEME_KONAN_TUTAR_DOVIZ_ID, DateTime.Now.Date);
                            }

                            //else
                            //{
                            //    if (item.ISLEME_KONAN_TUTAR_DOVIZ_ID == 1)
                            //        nakitAlacaklar += item.ISLEME_KONAN_TUTAR;
                            //    else
                            //        nakitAlacaklar += DovizHelper.CevirYTL(item.ISLEME_KONAN_TUTAR, item.ISLEME_KONAN_TUTAR_DOVIZ_ID, DateTime.Now.Date);
                            //}
                        }
                        toplamAlacaklar = ParaVeDovizId.Topla(toplamAlacaklar, new ParaVeDovizId(gayriNakitAlacaklar, 1));

                        if (proje.AV001_TDIE_BIL_PROJE_TEMINATCollection.Count == 0)
                            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_TEMINAT>));
                        var rehinBedeliToplami = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_TEMINAT(proje.ID).FindAll(vi => vi.ALT_TIP_ID == (int)SozlesmeAltTip.Arac_Rehni || vi.ALT_TIP_ID == (int)SozlesmeAltTip.Hat_Rehni || vi.ALT_TIP_ID == (int)SozlesmeAltTip.Marka_Rehni || vi.ALT_TIP_ID == (int)SozlesmeAltTip.Ticari_Plaka_Rehni || vi.ALT_TIP_ID == (int)SozlesmeAltTip.Hisse_Rehni_Sozlesmesi || vi.ALT_TIP_ID == (int)SozlesmeAltTip.Menkul_Mal_Rehni || vi.ALT_TIP_ID == (int)SozlesmeAltTip.Ticari_Isletme_Rehni).Sum(vi => vi.BEDELI);
                        if (foy.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME.Count == 0)
                            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME>));
                        if (foy.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME.FindAll(vi => vi.REHIN_CINS_ANA_TURU == 1).Count > 0) return string.Empty;
                        if (toplamAlacaklar.Para > rehinBedeliToplami)
                            aciklama = "{ " + string.Format("Kredi alaca�� rehin limitinden fazla oldu�undan, rehin limitini a�an alacak ile i�bu dosyada takibe konulan k�s�m dahil kredi alaca��n�n tamam� �zerinden i�leyecek y�ll�k {0} temerr�r faizini, faizin %5 gider vergisini ve takip masraflar�n�, Alacakl�n�n rehni a�an k�sma ili�kin takibinde talep hakk� ve kaza tahsilde tekerr�r etmemek �zere Alacakl�n�n di�er teminatlara ve BK.nun 487 maddesi gere�ince m��terek bor�lu ve m�teselsil kefillere m�racaat hakk� sakl�d�r.", foy.AV001_TI_BIL_ALACAK_NEDENCollection[0].UYGULANACAK_FAIZ_ORANI) + " }" + Environment.NewLine + "{ " + string.Format("Rehin paraya �evrilip sat�� bedeli dosyaya girdi�inde, i�bu dosya alaca��n�n o g�nk� rehin limiti alt�nda ise ve ayn� zamanda sat�� bedelinden az ise, rehin limitini a�mamak �zere aradaki fark �zerinde Alacakl�n�n {0} tutar�ndaki gayri nakit alaca�� ve varsa di�er alacaklar� y�n�nden rehin hakk� devam etti�inden, rehin limini a�mamak �zere aradaki sat�� bedeli fark�n�, Alacakl�n�n, rehin hakk� nedeniyle nakdi teminat olarak depo edilmek �zere TAHS�L�.", gayriNakitAlacaklar) + " }";
                        else
                            aciklama = "{ " + string.Format("Rehin paraya �evrilip sat�� bedeli dosyaya girdi�inde, i�bu dosya alaca��n�n o g�nk� rehin liiti alt�nda ise ve ayn� zamanda sat�� bedelinden az ise, rehin limitini a�mamak �zere aradaki fark �zerinde Alacakl�n�n {0} tutar�ndaki gayri nakit alaca�� ve varsa di�er alacaklar� y�n�nden rehin hakk� devam etti�inden, rehin limini a�mamak �zere aradaki sat�� bedeli fark�n�, Alacakl�n�n, rehin hakk� nedeniyle nakdi teminat olarak depo edilmek �zere TAHS�L�.", gayriNakitAlacaklar) + " }" + "\r\n(Tahsilde tekerr�r etmemek �zere Alacakl�n�n rehni a�an alacak k�sm� i�in takip yapma hakk� ile Alacakl�n�n di�er teminatlara ve kefillere m�racaat hakk� sakl�d�r. )";
                        return aciklama;

                    case (int)FormTipleri.Form53:
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>), typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                        if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.FindAll(vi => vi.AN_URETIP_TIP == (int)AN_URETIP_TIP.MunzamSenet).Count > 0 || foy.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_ICRA_KIYMETLI_EVRAK.FindAll(vi => vi.MUNZAM_SENET_MI ?? false).Count > 0)
                            aciklama = "( Alacakl�,faiz farklar� her t�rl� fazlaya ili�kin haklar�n� ve tahsilde tekerr�r etmemek �zere alaca��n�n di�er teminatlar�na ve sorumlular�na m�racaat haklar�n� sakl� tutmu�tur. )";
                        else
                            aciklama = "( Alacakl�,her t�rl� fazlaya ili�kin haklar�n� ve tahsilde tekerr�r etmemek �zere alaca��n�n di�er teminatlar�na ve sorumlular�na m�racaat haklar�n� sakl� tutmu�tur. )";
                        return aciklama;

                    case (int)FormTipleri.Form151:
                        if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                        decimal nakitAlacaklar53 = new decimal();
                        decimal gayriNakitAlacaklar53 = new decimal();
                        foreach (var item in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                        {
                            if (HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(item))
                            {
                                if (item.ISLEME_KONAN_TUTAR_DOVIZ_ID == 1)
                                    gayriNakitAlacaklar53 += item.ISLEME_KONAN_TUTAR;
                                else
                                    gayriNakitAlacaklar53 += DovizHelper.CevirYTL(item.ISLEME_KONAN_TUTAR, item.ISLEME_KONAN_TUTAR_DOVIZ_ID, DateTime.Now.Date);
                            }
                            else
                            {
                                if (item.ISLEME_KONAN_TUTAR_DOVIZ_ID == 1)
                                    nakitAlacaklar53 += item.ISLEME_KONAN_TUTAR;
                                else
                                    nakitAlacaklar53 += DovizHelper.CevirYTL(item.ISLEME_KONAN_TUTAR, item.ISLEME_KONAN_TUTAR_DOVIZ_ID, DateTime.Now.Date);
                            }
                        }
                        var ipotekList = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByICRA_FOY_IDFromNN_ICRA_SOZLESME(foy.ID);
                        if (ipotekList.FindAll(vi => vi.REHIN_CINS_ANA_TURU == 1).Count > 0)//Ana Para
                            aciklama = "( Tahsilde tekerr�r etmemek �zere Alacakl�n�n di�er teminatlara ve kefillere m�racaat hakk� ile her t�rl� fazlaya ili�kin haklar� sakl�d�r. )";
                        else//Limit
                        {
                            SayiOkuma so = new SayiOkuma();
                            if (ipotekList.FindAll(vi => vi.REHIN_CINS_ANA_TURU != 1).Sum(vi => vi.BEDELI) > nakitAlacaklar53)
                                aciklama = "{ Tahsilde tekerr�r etmemek �zere Alacakl�n�n ipote�i a�an k�s�m hakk�nda takip yapma hakk� ile Alacakl�n�n di�er teminatlara ve BK.nun 487 maddesi gere�ince m��terek bor�lu ve m�teselsil kefillere m�racaat hakk� ile her t�rl� fazlaya ili�kin haklar� sakl�d�r. }" + Environment.NewLine;
                            else
                                aciklama = "{ " + string.Format("Kredi alaca��, ipotek limitinden fazla oldu�undan, ipotek limitini a�an alacak ile i�bu dosyada takibe konulan k�sm� dahil kredi alaca��n�n tamam� �zerinden i�lyecek y�ll�k % {0} temerr�t  faizini, faizin %5 gider vergisi (BSMV) ve takip masraflar�n�, Alacakl�n�n ipote�i a�an k�sma ili�kin takibinde talep hakk� ve keza tahsilde tekerr�r etmemek �zere Alacakl�n�n di�er teminatlara ve BK.nun 487 maddesi gere�ince m��terek bor�lu ve m�teselsil kefillere m�racaat hakk� sakl�d�r.", foy.AV001_TI_BIL_ALACAK_NEDENCollection[0].UYGULANACAK_FAIZ_ORANI.ToString()) + " }" + Environment.NewLine + "{ " + string.Format("�potek paraya �evrilip sat�� bedeli dosyaya girdi�inde, i�bu dosya alaca��n�n o g�nk� bakiyesi ipotek limitinin alt�nda ise ve ayn� zamanda sat�� bedelinden de az ise, ipotek limitini a�mamak �zere aradaki fark �zerinde Alacakl�n�n {0} tutar�ndaki gayri nakit alaca�� ve varsa di�er alacaklar� y�n�nden rehin hakk� devam etti�inden, ipotek limitini a�mamak �zere aradaki sat�� bedeli fark�n�, Alacakl�, rehin hakk� nedeniyle tahsil, talep ve depo etme hakk�na sahiptir. Alacakl�n�n her t�rl� fazlaya ili�kin haklar� sakl�d�r.", so.ParaFormatla(gayriNakitAlacaklar53) + " TL") + " }" + Environment.NewLine;
                        }
                        return aciklama;

                    case (int)FormTipleri.Form163:
                        if (foy.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_ICRA_KIYMETLI_EVRAK.Count == 0)
                            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>));
                        foreach (var item in foy.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_ICRA_KIYMETLI_EVRAK)
                        {
                            if (!item.EVRAK_TUR_ID.HasValue) continue;
                            if (item.EVRAK_TUR_ID.Value == (int)EvrakTurleri.�EK)
                            {
                                if (BelgeUtil.Inits._per_CariGetir == null)
                                    BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();

                                if (item.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection.Count == 0)
                                    DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>));
                                var kesideciBorclu = item.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection.Find(vi => vi.TARAF_TIP_ID.HasValue && vi.TARAF_TIP_ID.Value == 2);//Ke�ideci Bor�lu
                                var kesideciBorcluCari = "Kesideci Girilmemi�.";
                                if (kesideciBorclu != null)
                                    kesideciBorcluCari = BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == kesideciBorclu.TARAF_CARI_ID.Value).AD;
                                aciklama = string.Format("�EK TAZM�NATI ile �EK KOM�SYONUNDAN ke�ideci {0} sorumlu olup, di�er �ek bor�lular� �ek tazminat� ile �ek komisyonundan ve bu iki kalem alaca�a isabet eden ferilerinden sorumlu de�illerdir. ", kesideciBorcluCari);
                            }
                        }

                        var munzamList = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK(proje.ID).FindAll(vi => vi.MUNZAM_SENET_MI ?? false);
                        if (munzamList.Count == 0) return aciklama;
                        else
                        {
                            if (proje.AV001_TDIE_BIL_PROJE_TEMINATCollection.Count == 0)
                                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_TEMINAT>));
                            if (proje.AV001_TDIE_BIL_PROJE_TEMINATCollection.Count > 0)
                            {
                                bool ipotekVar = false;

                                foreach (var item in proje.AV001_TDIE_BIL_PROJE_TEMINATCollection)
                                {
                                    var sozlesme = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(item.SOZLESME_ID);
                                    if (sozlesme == null) continue;
                                    else
                                    {
                                        switch (sozlesme.ALT_TIP_ID)
                                        {
                                            case (int)SozlesmeAltTip.Gayrimenkul_Ipotegi:
                                            case (int)SozlesmeAltTip.Hava_Araci_Ipotegi:
                                            case (int)SozlesmeAltTip.Gemi_Ipotegi:
                                                ipotekVar = true;
                                                break;

                                            default:
                                                break;
                                        }
                                    }
                                }
                                if (ipotekVar)
                                    aciklama = "{ Alacakl� i�bu takibi, faiz farklar� dahil her t�rl� fazlaya ili�kin haklar�n�, ��K.nun 45/II ve 167.maddesindeki haklar�n� sakl� tutarak ve ipotek / rehin takibiyle thsilde tekerr�r etmemek �zere yapm��t�r. }";
                                else
                                    aciklama = "Alacakl� i�bu takibi, faiz farklar� dahil her t�rl� fazlaya ili�kin haklar�n� sakl� tutarak yapm��t�r. }";
                            }
                            return aciklama;
                        }
                    default:
                        return aciklama;
                }
            }
            else return aciklama;
        }

        public static string GetMudurlukIBANNo(AV001_TI_BIL_FOY myFoy)
        {
            return myFoy.ALACAKLI_TARAF_STATU;
        }

        /// <summary>
        /// �rnek 14 i�in tahliyer talebi de�i�keni
        /// kira s�zle�mesi olan t�m alacak nedenlerinde dola��yoruz
        /// s�zle�menin ba�lang�� ve biti� tarhii waras�ndaki fark� al�p
        /// --takip gierlerinin tahisli ile imza_tarihi tarihli zaman_fark� s�reli
        ///  gayrimenkul kira sozlesmesindeki TAHLIYE_TAAHHUT_TARIHI
        ///  tarihli tahliye taah�d� gere�i tahliyesi talebidir --
        ///  �eklinde par�al� olarak textField lar olarak ��kt�s�n� verrir.
        /// </summary>
        /// <param name="foyum"></param>
        /// <returns></returns>
        public static List<TextField> GetOrnek14TahliyeTalebiFromNesne(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
        {
            List<TextField> lstFields = new List<TextField>();
            TextField tf = new TextField();
            TList<AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN> lstAlacakNedens = foyum.AV001_TI_BIL_ALACAK_NEDENCollection;

            for (int i = 0; i < lstAlacakNedens.Count; i++)
            {
                TList<AvukatProLib2.Entities.AV001_TDI_BIL_SOZLESME> lstsozlesmeler = new TList<AV001_TDI_BIL_SOZLESME>();
                if (lstAlacakNedens[i].KIRA_SOZLESME_ID.HasValue)
                {
                    lstsozlesmeler.Add(AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(lstAlacakNedens[i].KIRA_SOZLESME_ID.Value));

                    for (int y = 0; y < lstsozlesmeler.Count; y++)
                    {
                        string zamanFarki = GetTarihFarki(lstsozlesmeler[y].BITIS_TARIHI.Value, lstsozlesmeler[y].BASLANGIC_TARIHI.Value);
                        InsertTextField(" takip gierlerinin tahisli ile ", 0, "giris", lstFields, " ");

                        InsertTextField(lstsozlesmeler[y].IMZA_TARIHI.Value.ToString(), lstAlacakNedens[i].ID, "imzaTarihi", lstFields, "AV001_TI_BIL_ALACAK_NEDEN");
                        InsertTextField(" tarihli ", 0, "tarihli", lstFields, " ");

                        InsertTextField(zamanFarki, lstAlacakNedens[i].ID, "imzaTarihi", lstFields, "AV001_TI_BIL_ALACAK_NEDEN");
                        InsertTextField(" s�reli gayrimenkul kira sozlesmesindeki ", 0, "tarihli", lstFields, " ");
                        InsertTextField(lstsozlesmeler[y].TAHLIYE_TAAHHUT_TARIHI.Value.ToString(), lstAlacakNedens[i].ID, "imzaTarihi", lstFields, "AV001_TI_BIL_ALACAK_NEDEN");
                        InsertTextField(" tarihli tahliye taah�d� gere�i tahliyesi talebidir ", 0, "end", lstFields, " ");
                    }
                }
            }
            return lstFields;
        }

        public static string GetPTTBarkodGetir(AV001_TI_BIL_FOY foy, int CARI_ID, string BarkodTip, AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR sablon)
        {
            string _barkod = "";
            int _BARKOD_TIPI = 0;
            if (sablon.ID == 333 || sablon.ID == 439 || sablon.ID == 504 || sablon.ID == 505 || sablon.ID == 507 || sablon.ID == 509 || sablon.ID == 510 || sablon.ID == 520 || sablon.ID == 1204 || sablon.ID == 1219 || sablon.ID == 3213 || sablon.ID == 3214 || sablon.ID == 3215 || sablon.ID == 3216)
            {
                foreach (var item in BarkodTip.Split(','))
                {
                    if (item.ToString() == "1")
                    {
                        _BARKOD_TIPI = 1;
                    }
                    else if (item.ToString() == "4")
                    {
                        _BARKOD_TIPI = 4;
                    }
                    else if (item.ToString() == "0")
                    {
                        _BARKOD_TIPI = 0;
                    }
                }
            }
            else if (sablon.ID == 3211)
            {
                foreach (var item in BarkodTip.Split(','))
                {
                    if (item.ToString() == "2")
                    {
                        _BARKOD_TIPI = 2;
                    }
                    else if (item.ToString() == "0")
                    {
                        _BARKOD_TIPI = 0;
                    }
                }
            }
            else if (sablon.ID == 3212)
            {
                foreach (var item in BarkodTip.Split(','))
                {
                    if (item.ToString() == "5")
                    {
                        _BARKOD_TIPI = 5;
                    }
                    else if (item.ToString() == "0")
                    {
                        _BARKOD_TIPI = 0;
                    }
                }
            }

            CompInfo smtpInfo = CompInfo.CmpNfoList[0];
            TList<AV001_TDI_BIL_TEBLIGAT> myAV001_TDI_BIL_TEBLIGATs = new TList<AV001_TDI_BIL_TEBLIGAT>();

            myAV001_TDI_BIL_TEBLIGATs = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByICRA_FOY_ID(foy.ID);
            foreach (AV001_TDI_BIL_TEBLIGAT item in myAV001_TDI_BIL_TEBLIGATs)
            {
                TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> myAV001_TDI_BIL_TEBLIGAT_MUHATAPs = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();
                myAV001_TDI_BIL_TEBLIGAT_MUHATAPs = DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.GetByTEBLIGAT_ID(item.ID);
                foreach (AV001_TDI_BIL_TEBLIGAT_MUHATAP item2 in myAV001_TDI_BIL_TEBLIGAT_MUHATAPs.Where(q => q.MUHATAP_CARI_ID == CARI_ID))
                {
                    //item2.MUHATAP_CARI_ID
                    if (string.IsNullOrEmpty(item2.PTT_BARKOD_NO))
                    {
                        //int _barkodTip = 0;
                        SqlConnection con = new SqlConnection(smtpInfo.ConStr);
                        con.Open();
                        SqlDataReader rd;
                        SqlCommand cmd = new SqlCommand("select BARKOD_TIPI,KULLANILABILIR_ILK_BARKOD, AKTIFMI,BARKOD_BASLANGICI, BARKOD_ADEDI from  dbo.AV001_TDI_BIL_PTT_BARKOD_TANIMLAMA where BARKOD_TIPI=" + _BARKOD_TIPI + " ", con);
                        rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            //if (Convert.ToInt32(rd[0].ToString()) == 1)
                            //{
                            //    _barkodTip = 1;
                            //}
                            //else if (Convert.ToInt32(rd[0].ToString()) == 2)//dbo.AV001_TDI_KOD_BARKOD_TIPLERI BARKOD T�P 2 TAAHH�TL� TEBL�GAT
                            //{
                            //_barkodTip = 2;
                            if (rd[2].ToString() == "True") //dbo.AV001_TDI_BIL_PTT_BARKOD_TANIMLAMA da 1 aktif
                            {
                                if (Convert.ToInt64(rd[1].ToString()) >= (Convert.ToInt64(rd[3].ToString()) + Convert.ToInt64(rd[4].ToString())))
                                {
                                    //kullan�labilir tebligat bitti
                                    break;
                                }
                                else
                                {
                                    _barkod = rd[1].ToString();

                                    // item2.PTT_BARKOD_NO=// burda barkod at�caz ve atad���m�z� image dosyas�n� olu�turup geri d�nd�rcez
                                    SqlConnection con2 = new SqlConnection(smtpInfo.ConStr);
                                    con2.Open();
                                    SqlCommand cmd1 = new SqlCommand("UPDATE [dbo].[AV001_TDI_BIL_TEBLIGAT_MUHATAP] SET [ICRA_FOY_ID]=" + foy.ID + ", [POSTALANDI_MI] = 0,[PTT_BARKOD_NO] ='" + _barkod + "'  WHERE ID=" + item2.ID + " ", con2);//++
                                    cmd1.ExecuteNonQuery();
                                    SqlCommand cmd3 = new SqlCommand("select ID,BARKOD_BASLANGICI, BARKOD_ADEDI,KULLANILABILIR_ILK_BARKOD, AKTIFMI from  dbo.AV001_TDI_BIL_PTT_BARKOD_TANIMLAMA where BARKOD_TIPI=" + _BARKOD_TIPI + " ", con2);
                                    SqlDataReader rd2 = cmd3.ExecuteReader();
                                    if (rd2.Read())
                                    {
                                        SqlConnection con3 = new SqlConnection(smtpInfo.ConStr);
                                        con3.Open();
                                        if (Convert.ToInt64(rd2[1].ToString()) + Convert.ToInt64(rd2[2].ToString()) == Convert.ToInt64(rd2[3].ToString()))
                                        {
                                            SqlCommand cmd4 = new SqlCommand("UPDATE  [dbo].AV001_TDI_BIL_PTT_BARKOD_TANIMLAMA SET KULLANILABILIR_ILK_BARKOD='" + (Convert.ToInt64(_barkod) + 1).ToString() + "' , AKTIFMI=0  WHERE BARKOD_TIPI=" + _BARKOD_TIPI + "", con3);
                                            cmd4.ExecuteNonQuery();
                                            cmd4.Dispose();

                                            //tan�mlanabilir barkod bitti ve barkod rezervi pasif yap�ld�
                                        }
                                        else
                                        {
                                            SqlCommand cmd2 = new SqlCommand("UPDATE  [dbo].AV001_TDI_BIL_PTT_BARKOD_TANIMLAMA SET KULLANILABILIR_ILK_BARKOD='" + (Convert.ToInt64(_barkod) + 1).ToString() + "' , AKTIFMI=1 WHERE BARKOD_TIPI=" + _BARKOD_TIPI + "", con3);
                                            cmd2.ExecuteNonQuery();
                                            cmd2.Dispose();
                                        }
                                        con3.Close();
                                        con3.Dispose();
                                    }
                                    cmd1.Dispose();
                                    cmd3.Dispose();
                                    rd2.Close();
                                    rd2.Dispose();
                                    con2.Close();
                                    con2.Dispose();
                                    break;
                                }
                            }
                            //}
                            //else if (Convert.ToInt32(rd[0].ToString()) == 3)
                            //{
                            //    _barkodTip = 3;
                            //}
                        }
                        con.Close();
                        con.Dispose();
                        cmd.Dispose();
                        rd.Close();
                        rd.Dispose();
                    }
                    else
                    {
                    }
                }
            }
            return _barkod;
        }

        public static List<TextField> GetSatisBilgisi(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum, TextControl tCnt, int startIndex)
        {
            List<TextField> lstFields = new List<TextField>();

            AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TI_BIL_SATIS_MASTER> lstSatis = AvukatProLib2.Data.DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.GetByICRA_FOY_ID(foyum.ID);

            for (int i = 0; i < lstSatis.Count; i++)
            {
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.DeepLoad(lstSatis, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TList<AV001_TI_BIL_SATIS_CHILD>));
                if (lstSatis[i].SATISI_ISTEYEN_CARI_ID.HasValue)
                {
                    InsertTextField(lstSatis[i].SATISI_ISTEYEN_CARI_IDSource.AD + " adl� �ahs�n iste�i ile ", lstSatis[i].ID, "Satis Saati", lstFields, "SATIS");
                }

                if (lstSatis[i].SATISI_ISTENEN_CARI_ID > 0)
                {
                    InsertTextField(lstSatis[i].SATISI_ISTENEN_CARI_IDSource.AD + " adl� �ahs�n ", lstSatis[i].ID, "Satis Saati", lstFields, "SATIS");
                }

                if (lstSatis[i].SATIS_TARIHI_1.HasValue)
                {
                    InsertTextField(TarihBicimlendirme(lstSatis[i].SATIS_TARIHI_1.Value).ToString(), lstSatis[i].ID, "Satis Tarihi1", lstFields, "SATIS");
                }
                if (lstSatis[i].SATIS_TARIHI_2.HasValue)
                {
                    InsertTextField(TarihBicimlendirme(lstSatis[i].SATIS_TARIHI_1.Value).ToString(), lstSatis[i].ID, "Satis Tarihi1", lstFields, "SATIS");
                }

                if (lstSatis[i].TALIMAT_MI)
                {
                    InsertTextField(lstSatis[i].TALIMAT_ADLI_BIRIM_ADLIYE_ID.Value.ToString(), 1, "Adliye", lstFields, "Satis Master");
                    InsertTextField(lstSatis[i].TALIMAT_ADLI_BIRIM_GOREV_ID.Value.ToString(), 1, "Adliye", lstFields, "Satis Master");
                    InsertTextField(lstSatis[i].TALIMAT_ADLI_BIRIM_NO_ID.Value.ToString(), 1, "Adliye", lstFields, "Satis Master");
                }

                for (int y = 0; y < lstSatis[i].AV001_TI_BIL_SATIS_CHILDCollection.Count; y++)
                {
                    AvukatProLib2.Data.DataRepository.AV001_TI_BIL_SATIS_CHILDProvider.DeepLoad(lstSatis[i].AV001_TI_BIL_SATIS_CHILDCollection, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_DOVIZ_TIP), typeof(TI_KOD_MAL_CINS));

                    InsertTextField(lstSatis[y].AV001_TI_BIL_SATIS_CHILDCollection[y].HACIZLI_MAL_ADEDI.ToString(), 1, "Adet", lstFields, "SatisChild");

                    InsertTextField(lstSatis[y].AV001_TI_BIL_SATIS_CHILDCollection[y].BIRIM_KOD, 1, "Adet", lstFields, "SatisChild");
                    InsertTextField(lstSatis[y].AV001_TI_BIL_SATIS_CHILDCollection[y].HACIZLI_MAL_CINS_IDSource.CINS, 1, "Adet", lstFields, "SatisChild");
                    InsertTextField(lstSatis[y].AV001_TI_BIL_SATIS_CHILDCollection[y].HACIZLI_MAL_DEGERI.ToString(), 1, "Adet", lstFields, "SatisChild");
                    InsertTextField(lstSatis[y].AV001_TI_BIL_SATIS_CHILDCollection[y].HACIZLI_MAL_KAT_IDSource.KATEGORI, 1, "Adet", lstFields, "SatisChild");
                    InsertTextField(lstSatis[y].AV001_TI_BIL_SATIS_CHILDCollection[y].HACIZLI_MAL_TOPLAM_MIKTAR.ToString(), 1, "Adet", lstFields, "SatisChild");
                    InsertTextField(lstSatis[y].AV001_TI_BIL_SATIS_CHILDCollection[y].ICRA_SATIS_BEDELI_DOVIZ_IDSource.DOVIZ_KODU, 1, "Adet", lstFields, "SatisChild");
                    InsertTextField(lstSatis[y].AV001_TI_BIL_SATIS_CHILDCollection[y].DOSYA_GIREN_BEDEL.ToString(), 1, "Adet", lstFields, "SatisChild");
                    InsertTextField(lstSatis[y].AV001_TI_BIL_SATIS_CHILDCollection[y].DOSYA_GIREN_BEDEL_DOVIZ_IDSource.DOVIZ_KODU, 1, "Adet", lstFields, "SatisChild");
                }
            }

            return lstFields;
        }

        public static string GetSorumluAvukat(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
            string result = string.Empty;

            TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT> sorumlular = foy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection;

            if (sorumlular.Where(vi => !vi.YETKILI_MI).Count() > 0)
            {
                result += "Av." + HesapAraclari.Icra.CariAdiGetirByCariId(sorumlular.Where(vi => !vi.YETKILI_MI).FirstOrDefault().SORUMLU_AVUKAT_CARI_ID) + ", ";
                return result;
            }
            if (result == string.Empty)
            {
                result += "Av." + HesapAraclari.Icra.CariAdiGetirByCariId(sorumlular.Where(vi => vi.YETKILI_MI).FirstOrDefault().SORUMLU_AVUKAT_CARI_ID) + ", ";
                return result;
            }

            return result;
        }

        public static List<TextField> getSozlesmeBilgisi(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum, TextControl tCnt, int startIndex)
        {
            List<TextField> returnValues = new List<TextField>();

            //Kira Takiplerinde mal bilgilerinin gelmesini engellemek i�in eklendi. MB
            if (foyum.FORM_TIP_ID == 10)
                return returnValues;

            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
            TList<AV001_TI_BIL_ALACAK_NEDEN> lstAlacakNedens = foyum.AV001_TI_BIL_ALACAK_NEDENCollection;
            int formOrnekNo = Convert.ToInt32(AvukatProLib2.Data.DataRepository.TI_KOD_FORM_TIPProvider.GetByID(foyum.FORM_TIP_ID.Value).FORM_ORNEK_NO);
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(lstAlacakNedens, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_SOZLESME>));

            //Toplam alan�n� yazd�rmak i�in Yaz�d�rd���m�z s�zle�meleri bunun �zerine ekleyece�iz
            List<AV001_TDI_BIL_SOZLESME> yazdirilanSozlesmeler = new List<AV001_TDI_BIL_SOZLESME>();

            for (int i = 0; i < lstAlacakNedens.Count; i++)
            {
                var aNeden = lstAlacakNedens[i];
                TList<AV001_TDI_BIL_SOZLESME> lstAlacakNedenSozlesme = aNeden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW;
                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(lstAlacakNedenSozlesme, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_SOZLESME), typeof(TList<AV001_TI_BIL_GAYRIMENKUL>), typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE));
                for (int y = 0; y < lstAlacakNedenSozlesme.Count; y++)
                {
                    var aNedenSozlesme = lstAlacakNedenSozlesme[y];

                    getMetSozlesmeBilgisi(returnValues, aNedenSozlesme);//Method sonunda ��kan c�mlenin gelmesi istenmedi�inden kapat�ld�. MB
                    yazdirilanSozlesmeler.Add(aNedenSozlesme);
                }
            }

            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TList<NN_ICRA_SOZLESME>));

            AvukatProLib2.Data.DataRepository.NN_ICRA_SOZLESMEProvider.DeepLoad(foyum.NN_ICRA_SOZLESMECollection, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_SOZLESME));//, typeof(TList<AV001_TI_BIL_GAYRIMENKUL>), typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE));

            foreach (var sozlesme in foyum.NN_ICRA_SOZLESMECollection)
            {
                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(sozlesme.SOZLESME_IDSource, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_SOZLESME), typeof(TList<AV001_TI_BIL_GAYRIMENKUL>), typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE));

                if (sozlesme.SOZLESME_IDSource.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.Count == 0) continue;
                getMetSozlesmeBilgisi(returnValues, sozlesme.SOZLESME_IDSource); //Method sonunda ��kan c�mlenin gelmesi istenmedi�inden kapat�ld�. MB
                yazdirilanSozlesmeler.Add(sozlesme.SOZLESME_IDSource);
            }

            Dictionary<int, List<ParaVeDovizId>> paralarinSozlugu = new Dictionary<int, List<ParaVeDovizId>>();

            List<ParaVeDovizId> sozlesmelerinBedelleri = new List<ParaVeDovizId>();

            foreach (var sozlesme in yazdirilanSozlesmeler) //toplam almak i�in bedelleri listeye ekledik
            {
                if (paralarinSozlugu.ContainsKey(sozlesme.BEDELI_DOVIZ_ID.Value))
                {
                    if (paralarinSozlugu[sozlesme.BEDELI_DOVIZ_ID.Value] == null) paralarinSozlugu[sozlesme.BEDELI_DOVIZ_ID.Value] = new List<ParaVeDovizId>();

                    paralarinSozlugu[sozlesme.BEDELI_DOVIZ_ID.Value].Add(new ParaVeDovizId(sozlesme.BEDELI, sozlesme.BEDELI_DOVIZ_ID, foyum.TAKIP_TARIHI));
                }
                else
                {
                    paralarinSozlugu.Add(sozlesme.BEDELI_DOVIZ_ID.Value, new List<ParaVeDovizId>());
                    paralarinSozlugu[sozlesme.BEDELI_DOVIZ_ID.Value].Add(new ParaVeDovizId(sozlesme.BEDELI, sozlesme.BEDELI_DOVIZ_ID.Value));
                }
            }
            if (yazdirilanSozlesmeler.Count == 0) return returnValues;
            SayiOkuma so = new SayiOkuma();

            foreach (var teki in paralarinSozlugu)
            {
                if (foyum.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME.FindAll(vi => vi.REHIN_CINS_ANA_TURU == 1).Count > 0) continue;
                var bedellerToplami = ParaVeDovizId.Topla(teki.Value);

                InsertTextField(Environment.NewLine, 0, "yazi", returnValues, "yazi");

                InsertTextField(string.Format("Paraya �evrilmesi istenen {0} adet ipotek limiti toplam� {1} {2} ", teki.Value.Count, so.ParaFormatla(bedellerToplami.Para), bedellerToplami.DovizKodu), 0, "yazi", returnValues, "yazi");

                if (foyum.FORM_TIP_ID == (int)FormTipleri.Form50
                    || foyum.FORM_TIP_ID == (int)FormTipleri.Form201
                    || foyum.FORM_TIP_ID == (int)FormTipleri.Form151
                    || foyum.FORM_TIP_ID == (int)FormTipleri.Form152)
                {
                    InsertTextField(" ", 0, "yazi", returnValues, "yazi");
                }
                else
                {
                    InsertTextField("s�zle�me.", 0, "yazi", returnValues, "yazi");
                }

                //resmi senet
            }

            return returnValues;
        }

        public static string GetSube(AvukatProLib2.Entities.IEntity foyum)
        {
            if (foyum is AV001_TD_BIL_FOY)
            {
                return SubeGetir(((AV001_TD_BIL_FOY)foyum).SUBE_KODU);
            }

            if (foyum is AV001_TI_BIL_FOY)
            {
                var foy = foyum as AV001_TI_BIL_FOY;
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE>));
                if (foy.AV001_TDIE_BIL_PROJECollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY.Count > 0 && foy.AV001_TDIE_BIL_PROJECollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY[0].OZEL_KOD1_ID.HasValue)
                {
                    if (foy.AV001_TDIE_BIL_PROJECollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY[0].OZEL_KOD1_IDSource == null)
                        DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(foy.AV001_TDIE_BIL_PROJECollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY[0], false, DeepLoadType.IncludeChildren, typeof(TDIE_KOD_PROJE_OZEL_KOD));

                    if (foy.AV001_TDIE_BIL_PROJECollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY[0].OZEL_KOD1_IDSource != null)
                        return foy.AV001_TDIE_BIL_PROJECollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY[0].OZEL_KOD1_IDSource.OZEL_KOD;
                }

                if (foy.AV001_TI_BIL_FOY_OZEL_KODCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_OZEL_KOD>));
                if (foy.AV001_TI_BIL_FOY_OZEL_KODCollection.Count > 0)
                {
                    if (foy.AV001_TI_BIL_FOY_OZEL_KODCollection[0].SUBE_IDSource == null)
                        DataRepository.AV001_TI_BIL_FOY_OZEL_KODProvider.DeepLoad(foy.AV001_TI_BIL_FOY_OZEL_KODCollection[0], false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_BANKA_SUBE));

                    if (foy.AV001_TI_BIL_FOY_OZEL_KODCollection[0].SUBE_IDSource != null)
                        return foy.AV001_TI_BIL_FOY_OZEL_KODCollection[0].SUBE_IDSource.SUBE;
                }

                return " ";
            }

            if (foyum is AV001_TD_BIL_HAZIRLIK)
            {
                return SubeGetir(((AV001_TD_BIL_HAZIRLIK)foyum).SUBE_KODU);
            }

            if (foyum is AV001_TDI_BIL_CARI)
            {
                return SubeGetir(((AV001_TDI_BIL_CARI)foyum).SUBE_KODU);
            }

            if (foyum is AV001_TDI_BIL_RUCU)
            {
                return SubeGetir(((AV001_TDI_BIL_RUCU)foyum).SUBE_KODU);
            }

            return String.Empty;
        }

        public static string GetTakipOncesiOdeme(AV001_TI_BIL_FOY myFoy)
        {
            List<AV001_TI_BIL_BORCLU_ODEME> lstOdemeList = new List<AV001_TI_BIL_BORCLU_ODEME>();
            string deger = "";
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_ODEME>));
            for (int i = 0; i < myFoy.AV001_TI_BIL_BORCLU_ODEMECollection.Count; i++)
            {
                if (myFoy.AV001_TI_BIL_BORCLU_ODEMECollection[i].ODEME_TARIHI < myFoy.TAKIP_TARIHI.Value)
                {
                    AvukatProLib2.Data.DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepLoad(myFoy.AV001_TI_BIL_BORCLU_ODEMECollection[i], false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_DOVIZ_TIP));
                    deger += myFoy.AV001_TI_BIL_BORCLU_ODEMECollection[i].ODEME_TARIHI.ToString() + " tarihindeki " + myFoy.AV001_TI_BIL_BORCLU_ODEMECollection[i].ODEME_MIKTAR.ToString() + " " + myFoy.AV001_TI_BIL_BORCLU_ODEMECollection[i].ODEME_MIKTAR_DOVIZ_IDSource.DOVIZ_KODU.ToString() + " de�erindeki ,";
                }
            }

            string HesaplamaTipi = "BK 84";
            if (myFoy.HESAPLAMA_TIPI == 1)
            {
                HesaplamaTipi = "Azalan Bakiye";
            }

            deger += string.Format(" �demeler {0} sistemine g�re hesaptan d���lm��t�r."
            , HesaplamaTipi);
            if (myFoy.AV001_TI_BIL_BORCLU_ODEMECollection.Count == 0)
            {
                return "";
            }
            return deger;
        }

        public static List<TextField> GetTakipYoluFromNesne(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
        {
            List<TextField> lstfields = new List<TextField>();

            AvukatProLib2.Entities.TI_KOD_TAKIP_YOLU takipYolu = AvukatProLib2.Data.DataRepository.TI_KOD_TAKIP_YOLUProvider.GetByID(foyum.TAKIP_YOLU_ID.Value);
            InsertTextField(takipYolu.TAKIP_YOLU, takipYolu.ID, "takipYolu", lstfields, "TI_KOD_TAKIP_YOLU");
            return lstfields;
        }

        /// <summary>
        /// Verilen cariId ye ili�kin ge�erli adresi d�nd�r�r
        /// - GKN
        /// </summary>
        /// <param name="cariId"></param>
        /// <returns></returns>
        public static AV001_TDI_BIL_CARI getTarafAktifAdres(int? cariId, out string aktifAdres)
        {
            if (!cariId.HasValue)
            {
                aktifAdres = string.Empty;
                return null;
            }

            var cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(cariId.Value);
            DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(cari, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE), typeof(TDI_KOD_IL));

            string adres = string.Empty;
            string il = string.Empty;
            string ilce = string.Empty;
            string semt = string.Empty;
            string postaKodu = string.Empty;

            if (cari.AKTIF_ADRES)
            {
                adres = string.Format("{0} {1} {2}", cari.ADRES_1, cari.ADRES_2, cari.ADRES_3);
                postaKodu = cari.POSTA_KODU;
                if (cari.IL_ID.HasValue) il = cari.IL_IDSource.IL;
                if (cari.ILCE_ID.HasValue) ilce = cari.ILCE_IDSource.ILCE;
                if (cari.ADRES_SEMT_ID.HasValue) il = cari.ADRES_SEMT_IDSource.SEMT;
            }
            else if (cari.AKTIF_ADRES_2)
            {
                adres = string.Format("{0} {1} {2}", cari.ADRES2_1, cari.ADRES2_2, cari.ADRES2_3);
                postaKodu = cari.POSTA_KODU2;
                if (cari.IL2_ID.HasValue) il = cari.IL2_IDSource.IL;
                if (cari.ILCE2_ID.HasValue) ilce = cari.ILCE2_IDSource.ILCE;
                if (cari.ADRES2_SEMT_ID.HasValue) il = cari.ADRES2_SEMT_IDSource.SEMT;
            }
            else if (cari.AKTIF_ADRES_3)
            {
                adres = string.Format("{0} {1} {2}", cari.ADRES3_1, cari.ADRES3_2, cari.ADRES3_3);
                postaKodu = cari.POSTA_KODU3;
                if (cari.IL3_ID.HasValue) il = cari.IL3_IDSource.IL;
                if (cari.ILCE3_ID.HasValue) ilce = cari.ILCE3_IDSource.ILCE;
                if (cari.ADRES3_SEMT_ID.HasValue) il = cari.ADRES3_SEMT_IDSource.SEMT;
            }

            aktifAdres = string.Format("{0} {1} {2} {3} {4}", adres, postaKodu, semt, ilce, il);
            return cari;
        }

        public static string GetTarihFarki(DateTime dt1, DateTime dt2)
        {
            TimeSpan dt = new TimeSpan();
            dt = dt1 - dt2;
            string zamanFarki = "";
            if ((dt1.Year - dt2.Year) != 0)
            {
                zamanFarki = (dt1.Year - dt2.Year).ToString() + " Y�l ";
            }
            if ((dt1.Month - dt2.Month) != 0)
            {
                zamanFarki = (dt1.Month - dt2.Month).ToString() + " Ay ";
            }
            if (dt.Days != 0)
            {
                zamanFarki = dt.Days.ToString() + " G�n ";
            }
            return zamanFarki;
        }

        public static TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> GetTebligatMuhatablari(AV001_TI_BIL_FOY MyFoy, AV001_TDIE_BIL_SABLON_DEGISKENLER degisken)
        {
            TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> returnValues = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();
            TList<AV001_TDI_BIL_TEBLIGAT> lst1Tebligats = new TList<AV001_TDI_BIL_TEBLIGAT>();
            TList<AV001_TDI_BIL_TEBLIGAT> lst2Tebligats = new TList<AV001_TDI_BIL_TEBLIGAT>();
            TList<AV001_TDI_BIL_TEBLIGAT> lst3Tebligats = new TList<AV001_TDI_BIL_TEBLIGAT>();

            AV001_TDI_BIL_TEBLIGAT birinciEnbuyuk = new AV001_TDI_BIL_TEBLIGAT();
            AV001_TDI_BIL_TEBLIGAT ikinciEnbuyuk = new AV001_TDI_BIL_TEBLIGAT();
            AV001_TDI_BIL_TEBLIGAT ucuncuEnbuyuk = new AV001_TDI_BIL_TEBLIGAT();

            for (int i = 0; i < MyFoy.AV001_TDI_BIL_TEBLIGATCollection.Count; i++)
            {
                if (MyFoy.AV001_TDI_BIL_TEBLIGATCollection[i].KONU_ID == 162)
                {
                    lst1Tebligats.Add(MyFoy.AV001_TDI_BIL_TEBLIGATCollection[i]);
                    if (birinciEnbuyuk.POSTALANMA_TARIH < MyFoy.AV001_TDI_BIL_TEBLIGATCollection[i].POSTALANMA_TARIH)
                    {
                        birinciEnbuyuk = MyFoy.AV001_TDI_BIL_TEBLIGATCollection[i];
                    }
                }

                if (MyFoy.AV001_TDI_BIL_TEBLIGATCollection[i].KONU_ID == 163)
                {
                    lst2Tebligats.Add(MyFoy.AV001_TDI_BIL_TEBLIGATCollection[i]);

                    if (ikinciEnbuyuk.POSTALANMA_TARIH < MyFoy.AV001_TDI_BIL_TEBLIGATCollection[i].POSTALANMA_TARIH)
                    {
                        ikinciEnbuyuk = MyFoy.AV001_TDI_BIL_TEBLIGATCollection[i];
                    }
                }

                if (MyFoy.AV001_TDI_BIL_TEBLIGATCollection[i].KONU_ID == 450)
                {
                    lst3Tebligats.Add(MyFoy.AV001_TDI_BIL_TEBLIGATCollection[i]);

                    if (ucuncuEnbuyuk.POSTALANMA_TARIH < MyFoy.AV001_TDI_BIL_TEBLIGATCollection[i].POSTALANMA_TARIH)
                    {
                        ucuncuEnbuyuk = MyFoy.AV001_TDI_BIL_TEBLIGATCollection[i];
                    }
                }
            }

            if (DegiskenHelper.GetDegiskenByAd("IcraBirinciHacizIhbarnameTarihi") != null)
            {
                for (int y = 0; y < birinciEnbuyuk.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count; y++)
                {
                    returnValues.Add(birinciEnbuyuk.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[y]);
                }
            }

            if (DegiskenHelper.GetDegiskenByAd("IcraIkinciHacizIhbarnameTarihi") != null)
            {
                for (int y = 0; y < ikinciEnbuyuk.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count; y++)
                {
                    returnValues.Add(ikinciEnbuyuk.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[y]);
                }
            }

            if (DegiskenHelper.GetDegiskenByAd("IcraUcuncuHacizIhbarnameTarihi") != null)
            {
                for (int y = 0; y < ucuncuEnbuyuk.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count; y++)
                {
                    returnValues.Add(ucuncuEnbuyuk.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[y]);
                }
            }

            return returnValues;
        }

        public static List<TextField> GetTemsilBilgisi(AvukatProLib2.Entities.AV001_TI_BIL_FOY foy, TemsilBilgileri VeriTipi)
        {
            if (foy == null)
            {
                return null;
            }

            List<TextField> returnValues = new List<TextField>();

            if (foy.AV001_TI_BIL_FOY_TARAFCollection == null)
            {
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));
            }
            if (foy.AV001_TI_BIL_FOY_TARAFCollection.Count <= 0)
            {
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));
            }

            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(foy.AV001_TI_BIL_FOY_TARAFCollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF_VEKIL>), typeof(AV001_TDI_BIL_TEMSIL), typeof(TDI_KOD_TEMSIL_SEKIL), typeof(TDI_KOD_ADLI_BIRIM_ADLIYE), typeof(TDI_KOD_ADLI_BIRIM_BOLUM), typeof(TDI_KOD_ADLI_BIRIM_NO), typeof(TDI_KOD_ADLI_BIRIM_GOREV));

            for (int i = 0; i < foy.AV001_TI_BIL_FOY_TARAFCollection.Count; i++)
            {
                for (int y = 0; y < foy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection.Count; y++)
                {
                    if (foy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection[y].TEMSIL_ID.HasValue)
                    {
                        if (true)//(Convert.ToInt32(editor.Tag) == foy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection[y].TEMSIL_ID.Value)
                        {
                            switch (VeriTipi)
                            {
                                case TemsilBilgileri.Noter:
                                    returnValues.AddRange(TemsilNoterBilgisi(foy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection[y].TEMSIL_IDSource));
                                    break;

                                case TemsilBilgileri.Yevmiye:
                                    returnValues.AddRange(TemsilYevmiyeBilgisi(foy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection[y].TEMSIL_IDSource));
                                    break;

                                case TemsilBilgileri.Yetki:
                                    returnValues.AddRange(TemsilYetkiBilgisi(foy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection[y].TEMSIL_IDSource));
                                    break;

                                case TemsilBilgileri.Tumu:
                                    returnValues.AddRange(TemsilNoterBilgisi(foy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection[y].TEMSIL_IDSource));
                                    returnValues.AddRange(TemsilYetkiBilgisi(foy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection[y].TEMSIL_IDSource));
                                    returnValues.AddRange(TemsilYevmiyeBilgisi(foy.AV001_TI_BIL_FOY_TARAFCollection[i].AV001_TI_BIL_FOY_TARAF_VEKILCollection[y].TEMSIL_IDSource));

                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            return returnValues;
        }

        public static string ICRA_OzelKodGetir(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum, OzelKodTipleri Kod)
        {
            if (Kod == OzelKodTipleri.OzelKod1)
            {
                if (foyum.ICRA_OZEL_KOD1_ID != null)
                {
                    AvukatProLib2.Entities.AV001_TDI_KOD_FOY_OZEL bolum = new AV001_TDI_KOD_FOY_OZEL();

                    bolum = AvukatProLib2.Data.DataRepository.AV001_TDI_KOD_FOY_OZELProvider.GetByID(foyum.ICRA_OZEL_KOD1_ID.Value);

                    return bolum.KOD;
                }
                else
                    return "";
            }
            else if (Kod == OzelKodTipleri.OzelKod2)
            {
                if (foyum.ICRA_OZEL_KOD2_ID != null)
                {
                    AvukatProLib2.Entities.AV001_TDI_KOD_FOY_OZEL bolum = new AV001_TDI_KOD_FOY_OZEL();

                    bolum = AvukatProLib2.Data.DataRepository.AV001_TDI_KOD_FOY_OZELProvider.GetByID(foyum.ICRA_OZEL_KOD2_ID.Value);

                    return bolum.KOD;
                }
                else
                    return "";
            }
            else if (Kod == OzelKodTipleri.OzelKod3)
            {
                if (foyum.ICRA_OZEL_KOD3_ID != null)
                {
                    AvukatProLib2.Entities.AV001_TDI_KOD_FOY_OZEL bolum = new AV001_TDI_KOD_FOY_OZEL();

                    bolum = AvukatProLib2.Data.DataRepository.AV001_TDI_KOD_FOY_OZELProvider.GetByID(foyum.ICRA_OZEL_KOD3_ID.Value);

                    return bolum.KOD;
                }
                else
                    return "";
            }
            else if (Kod == OzelKodTipleri.OzelKod4)
            {
                if (foyum.ICRA_OZEL_KOD4_ID != null)
                {
                    AvukatProLib2.Entities.AV001_TDI_KOD_FOY_OZEL bolum = new AV001_TDI_KOD_FOY_OZEL();

                    bolum = AvukatProLib2.Data.DataRepository.AV001_TDI_KOD_FOY_OZELProvider.GetByID(foyum.ICRA_OZEL_KOD4_ID.Value);

                    return bolum.KOD;
                }
                else
                    return "";
            }
            else
                return "";
        }

        public static DegiskenDegeri IcraAlacakliVekilBilgisi(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
        {
            DegiskenDegeri returnValues = new DegiskenDegeri();
            returnValues.DonusTipi = DegiskenResulTType.HTML;

            for (int i = 0; i < foyum.AV001_TI_BIL_FOY_TARAF_VEKILCollection.Count; i++)
            {
                if (foyum.AV001_TI_BIL_FOY_TARAF_VEKILCollection[i].FOY_TARAF_IDSource.TARAF_SIFAT_IDSource.SIFAT == "TAK�P EDEN")
                {
                    //TODO : D�zeltilecek
                    // returnValues.Icerik += GetCariDeger(foyum.AV001_TI_BIL_HACIZ_MASTERCollection[i].AV001_TI_BIL_HACIZ_CHILDCollection[j].AV001_TI_BIL_HACIZ_ISTIRAKCollection[y].ISTIRAK_ISTEYEN_CARI_IDSource, "", null);
                }
            }
            return returnValues;
        }

        public static DegiskenDegeri IcraFoySorumlulariGetir(AvukatProLib2.Entities.AV001_TI_BIL_FOY foy)
        {
            DegiskenDegeri deger = new DegiskenDegeri();

            //deger.Degisken = degisken;
            deger.DonusTipi = DegiskenResulTType.HTML;
            deger.Icerik = "";
            return deger;
        }

        public static DegiskenDegeri IcraHacizUcuncuSahisBilgisi(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
        {
            DegiskenDegeri returnValues = new DegiskenDegeri();
            returnValues.DonusTipi = DegiskenResulTType.HTML;

            for (int i = 0; i < foyum.AV001_TI_BIL_HACIZ_MASTERCollection.Count; i++)
            {
                returnValues.Icerik += foyum.AV001_TI_BIL_HACIZ_MASTERCollection[i].HACIZ_TARIHI.ToString() + " tarihli hacize ait istirak istenenler: ";

                for (int j = 0; j < foyum.AV001_TI_BIL_HACIZ_MASTERCollection[i].AV001_TI_BIL_HACIZ_CHILDCollection.Count; j++)
                {
                    for (int y = 0; y < foyum.AV001_TI_BIL_HACIZ_MASTERCollection[i].AV001_TI_BIL_HACIZ_CHILDCollection[j].AV001_TI_BIL_HACIZ_ISTIRAKCollection.Count; y++)
                    {
                        returnValues.Icerik += GetCariDeger(foyum.AV001_TI_BIL_HACIZ_MASTERCollection[i].AV001_TI_BIL_HACIZ_CHILDCollection[j].AV001_TI_BIL_HACIZ_ISTIRAKCollection[y].ISTIRAK_ISTEYEN_CARI_ID.Value, "", null, true);
                    }
                }
            }

            return returnValues;
        }

        public static List<TextField> IcraIstihkakEdenBilgisi(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
        {
            List<TextField> returnValues = new List<TextField>();

            for (int i = 0; i < foyum.AV001_TI_BIL_HACIZ_MASTERCollection.Count; i++)
            {
                InsertTextField(foyum.AV001_TI_BIL_HACIZ_MASTERCollection[i].HACIZ_TARIHI.ToString() + " tarihli hacize ait istihkak edenler: ", foyum.AV001_TI_BIL_HACIZ_MASTERCollection[i].ID, "HACIZ_TARIHI", returnValues, "AV001_TI_BIL_HACIZ");

                for (int y = 0; y < foyum.AV001_TI_BIL_HACIZ_MASTERCollection[i].AV001_TI_BIL_ISTIHKAKCollection.Count; y++)
                {
                    //TODO : D�zeltilecek .....
                    // returnValues.AddRange(GetCariBilgisi(foyum.AV001_TI_BIL_HACIZ_MASTERCollection[i].AV001_TI_BIL_ISTIHKAKCollection[y].ISTIHKAK_IDDIA_EDEN_IDSource));
                }
            }

            return returnValues;
        }

        public static List<TextField> IcraIstirakIstenenBilgisi(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
        {
            List<TextField> returnValues = new List<TextField>();

            for (int i = 0; i < foyum.AV001_TI_BIL_HACIZ_MASTERCollection.Count; i++)
            {
                InsertTextField(foyum.AV001_TI_BIL_HACIZ_MASTERCollection[i].HACIZ_TARIHI.ToString() + " tarihli hacize ait istirak istenenler: ", foyum.AV001_TI_BIL_HACIZ_MASTERCollection[i].ID, "HACIZ_TARIHI", returnValues, "AV001_TI_BIL_HACIZ");

                for (int y = 0; y < foyum.AV001_TI_BIL_HACIZ_MASTERCollection[i].AV001_TI_BIL_HACIZ_ISTIRAKCollection.Count; y++)
                {
                    //TODO : De�zeltilecek

                    //returnValues.AddRange(GetCariBilgisi(foyum.AV001_TI_BIL_HACIZ_MASTERCollection[i].AV001_TI_BIL_HACIZ_ISTIRAKCollection[y].ISTIRAK_ISTENEN_CARI_IDSource));
                }
            }

            return returnValues;
        }

        public static List<TextField> IcraTebligatMuhattabTebligtarihi(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
        {
            List<TextField> returnValues = new List<TextField>();

            for (int i = 0; i < foyum.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count; i++)
            {
                InsertTextField(foyum.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[i].TEBLIG_TARIH.Value.ToString(), foyum.AV001_TI_BIL_HACIZ_MASTERCollection[i].ID, "TEBLIG_TARIH", returnValues, "AV001_TDI_BIL_TEBLIGAT_MUHATAP");
            }
            return returnValues;
        }

        public static string SetWords(string value, WordsUpperLowerType caseType)
        {
            string returnValue = "";
            string[] vals = value.Split(' ');
            string[] others = new string[vals.Length - 1];
            string FirstWord = vals[0];

            if (vals.Length > 1)
            {
                Array.Copy(vals, 1, others, 0, vals.Length - 1);
            }

            switch (caseType)
            {
                case WordsUpperLowerType.FirstWordUpperOthersLower:
                    returnValue += FirstWord.ToUpper();
                    for (int i = 0; i < others.Length; i++)
                    {
                        returnValue += " " + others[i].ToLower();
                    }
                    break;

                case WordsUpperLowerType.FirstWordFirstCharUpperOtherLower:
                    returnValue += setChars(FirstWord, CharUpperLowerType.FirstbigOthersSmal);
                    for (int i = 0; i < others.Length; i++)
                    {
                        returnValue += " " + others[i].ToLower();
                    }
                    break;

                case WordsUpperLowerType.AllWordAllCharsUpper:
                    returnValue += FirstWord.ToUpper();
                    for (int i = 0; i < others.Length; i++)
                    {
                        returnValue += " " + others[i].ToUpper();
                    }
                    break;

                case WordsUpperLowerType.AllWordsFirstCharsUpper:
                    returnValue += setChars(FirstWord, CharUpperLowerType.FirstbigOthersSmal);
                    for (int i = 0; i < others.Length; i++)
                    {
                        returnValue += " " + setChars(others[i], CharUpperLowerType.FirstbigOthersSmal);
                    }
                    break;

                case WordsUpperLowerType.AllWordsAllCharsLower:
                    returnValue += FirstWord.ToLower();
                    for (int i = 0; i < others.Length; i++)
                    {
                        returnValue += " " + others[i].ToLower();
                    }
                    break;

                case WordsUpperLowerType.FirstWordsFirstCharLoverOtherWordsFirstCharUpper:
                    returnValue += setChars(FirstWord, CharUpperLowerType.FirstSmallOthersBig);
                    for (int i = 0; i < others.Length; i++)
                    {
                        returnValue += " " + setChars(others[i], CharUpperLowerType.FirstbigOthersSmal);
                    }
                    break;

                default:
                    break;
            }

            return returnValue;
        }

        public static DegiskenDegeri TakipKanitlari(AV001_TI_BIL_FOY foyum)
        {
            if (foyum.FORM_TIP_ID.HasValue && foyum.FORM_TIP_ID.Value == (int)FormTipleri.Form163)
            {
                DegiskenDegeri kambiyoDeger = new DegiskenDegeri();

                if (foyum.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_ICRA_KIYMETLI_EVRAK.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>));
                foreach (var item in foyum.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_ICRA_KIYMETLI_EVRAK)
                {
                    if (!item.EVRAK_TUR_ID.HasValue) continue;
                    SayiOkuma sa = new SayiOkuma();

                    if (item.EVRAK_TUR_ID.Value == (int)EvrakTurleri.BONO)
                    {
                        if (BelgeUtil.Inits._DovizTipGetir == null)
                            BelgeUtil.Inits._DovizTipGetir = DataRepository.per_TDI_KOD_DOVIZ_TIPProvider.GetAll();
                        kambiyoDeger.Icerik += string.Format("{0} vadeli {1} bedelli bono ve protesto evrak�", item.EVRAK_VADE_TARIHI.HasValue ? item.EVRAK_VADE_TARIHI.Value.ToShortDateString() : "Vade Tarihi Girilmemi�", sa.ParaFormatla(item.TUTAR) + " " + BelgeUtil.Inits._DovizTipGetir.Find(vi => item.TUTAR_DOVIZ_ID.HasValue && vi.ID == item.TUTAR_DOVIZ_ID.Value).DOVIZ_KODU);
                    }
                    else if (item.EVRAK_TUR_ID.Value == (int)EvrakTurleri.�EK)
                    {
                        if (BelgeUtil.Inits._DovizTipGetir == null)
                            BelgeUtil.Inits._DovizTipGetir = DataRepository.per_TDI_KOD_DOVIZ_TIPProvider.GetAll();
                        kambiyoDeger.Icerik += string.Format("{0} ke�ide tarihli {1} �ek numaral� {2} bedelli �ek", item.EVRAK_VADE_TARIHI.HasValue ? item.EVRAK_VADE_TARIHI.Value.ToShortDateString() : "Ke�ide Tarihi Girilmemi�", item.CEK_NO, sa.ParaFormatla(item.TUTAR) + " " + BelgeUtil.Inits._DovizTipGetir.Find(vi => item.TUTAR_DOVIZ_ID.HasValue && vi.ID == item.TUTAR_DOVIZ_ID.Value).DOVIZ_KODU);
                    }
                }
                return kambiyoDeger;
            }
            else if (foyum.FORM_TIP_ID.HasValue && (foyum.FORM_TIP_ID == (int)FormTipleri.Form50 || foyum.FORM_TIP_ID == (int)FormTipleri.Form201))
            {
                List<int> tebligatIdList50 = new List<int>();
                tebligatIdList50.AddRange((from item in BelgeUtil.Inits.context.AV001_TDI_BIL_TEBLIGATs where item.ICRA_FOY_ID == foyum.ID select item.ID));
                var tebligatlar50 = BelgeUtil.Inits.context.per_TEBLIGAT_ACIKLAMAs.Where(item => tebligatIdList50.Contains(item.ID)).ToList();
                DegiskenDegeri deger50 = new DegiskenDegeri();

                for (int i = 0; i < tebligatlar50.Count; i++)
                {
                    if (tebligatlar50[i].KONU_ID == (int)TebligatKonu.HESAP_KAT_IHTARNAMESI)
                    {
                        if (!String.IsNullOrEmpty(tebligatlar50[i].ADLIYE))
                        {
                            deger50.Icerik += tebligatlar50[i].ADLIYE /*+ " Noterli�inden ke�ideli "*/;
                            if (!String.IsNullOrEmpty(tebligatlar50[i].NO))
                            {
                                deger50.Icerik += " " + tebligatlar50[i].NO;
                            }
                            deger50.Icerik += " " + "Noterli�inden ke�ideli ";
                        }
                        deger50.Icerik += TarihBicimlendirme(tebligatlar50[i].POSTALANMA_TARIH) + "tarihli ";

                        if (!String.IsNullOrEmpty(tebligatlar50[i].NO))
                        {
                            deger50.Icerik += tebligatlar50[i].TEBLIGAT_ESAS_NO + " say�l� ";
                        }
                        deger50.Icerik += "ihtarnamesi ve eki hesap �zetinin noter tastikli sureti, rehin s�zle�mesi, kredi s�zle�meleri.";
                    }
                }
            }

            bool Basilacakmi = false;
            if (foyum.FORM_TIP_ID.HasValue ||
                foyum.FORM_TIP_ID.Value == 2 ||
                foyum.FORM_TIP_ID.Value == 7 ||
                foyum.FORM_TIP_ID.Value == 8 ||
                foyum.FORM_TIP_ID.Value == 13)
            {
                Basilacakmi = true;
            }
            if (foyum.FORM_TIP_ID.Value == 1 && foyum.FORM_TIP_ID.Value == 12)
            {
                for (int i = 0; i < foyum.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++)
                {
                    if (foyum.AV001_TI_BIL_ALACAK_NEDENCollection[i].ALACAK_NEDEN_KOD_ID.HasValue &&
                        foyum.AV001_TI_BIL_ALACAK_NEDENCollection[i].ALACAK_NEDEN_KOD_ID.Value == 9 ||
                        foyum.AV001_TI_BIL_ALACAK_NEDENCollection[i].ALACAK_NEDEN_KOD_ID.Value == 10 ||
                        foyum.AV001_TI_BIL_ALACAK_NEDENCollection[i].ALACAK_NEDEN_KOD_ID.Value == 49 ||
                        foyum.AV001_TI_BIL_ALACAK_NEDENCollection[i].ALACAK_NEDEN_KOD_ID.Value == 50)
                    {
                        Basilacakmi = true;
                        break;
                    }
                }
            }
            if (!Basilacakmi)
            {
                DegiskenDegeri dd = new DegiskenDegeri();

                //dd.Degisken = degisken;
                dd.DonusTipi = DegiskenResulTType.String;
                return dd;
            }

            DegiskenDegeri deger = new DegiskenDegeri();

            //deger.Degisken = degisken;
            deger.DonusTipi = DegiskenResulTType.String;
            deger.Icerik = "";
            List<int> tebligatIdList = new List<int>();

            var projeler = DataRepository.AV001_TDIE_BIL_PROJE_ICRA_FOYProvider.GetByICRA_FOY_ID(foyum.ID);
            tebligatIdList.AddRange((from item in BelgeUtil.Inits.context.AV001_TDI_BIL_TEBLIGATs where item.ICRA_FOY_ID == foyum.ID select item.ID));
            foreach (var item in projeler)
            {
                DataRepository.AV001_TDIE_BIL_PROJE_IHTARNAMEProvider.GetByPROJE_ID(item.PROJE_ID).ForEach(vi => tebligatIdList.Add(vi.TEBLIGAT_ID));
                DataRepository.AV001_TDIE_BIL_PROJE_TEBLIGATProvider.GetByPROJE_ID(item.PROJE_ID).ForEach(vi => tebligatIdList.Add(vi.TEBLIGAT_ID));
            }
            var tebligatlar = BelgeUtil.Inits.context.per_TEBLIGAT_ACIKLAMAs.Where(item => tebligatIdList.Contains(item.ID)).ToList();

            for (int i = 0; i < tebligatlar.Count; i++)
            {
                if (tebligatlar[i].KONU_ID == (int)TebligatKonu.HESAP_KAT_IHTARNAMESI)
                {
                    if (!String.IsNullOrEmpty(tebligatlar[i].ADLIYE))
                    {
                        deger.Icerik += tebligatlar[i].ADLIYE /*+ " Noterli�inden ke�ideli "*/;
                        if (!String.IsNullOrEmpty(tebligatlar[i].NO))
                        {
                            deger.Icerik += " " + tebligatlar[i].NO;
                        }
                        deger.Icerik += " " + "Noterli�inden ke�ideli ";
                    }
                    deger.Icerik += TarihBicimlendirme(tebligatlar[i].POSTALANMA_TARIH) + " tarihli ";

                    if (!String.IsNullOrEmpty(tebligatlar[i].NO))
                    {
                        deger.Icerik += tebligatlar[i].TEBLIGAT_ESAS_NO + " say�l� ";
                    }

                    if (foyum.FORM_TIP_ID.HasValue && foyum.FORM_TIP_ID.Value == (int)FormTipleri.Form151 || foyum.FORM_TIP_ID.Value == (int)FormTipleri.Form152)
                        deger.Icerik += " ihtarnamesi ve eki hesap �zetinin tebli� edilmi� say�ld���na ili�kin NOTERDEN TAST�KL� SURET�N�N ASLI, ipotek belgelerinin ve ipotek akit tablosunun TAPU �DARES�NCE VER�LM�� RESM� SURET�N�N ASLI, kredi s�zle�meleri.";
                    else if (foyum.FORM_TIP_ID.Value == (int)FormTipleri.Form50)
                        deger.Icerik += "ihtarnamesi ve eki hesap �zetinin noter tastikli sureti, rehin s�zle�mesi, kredi s�zle�meleri.";
                    else
                        deger.Icerik += " ihtarnamesi ve eki hesap �zeti, kredi s�zle�meleri.";

                    //if (!String.IsNullOrEmpty(tebligatlar[i].ACIKLAMA))
                    //{
                    //    deger.Icerik += " " + tebligatlar[i].ACIKLAMA + " 'nin";
                    //}
                    //deger.Icerik += " ";

                    //deger.Icerik += tebligatlar[i].TEBLIGAT_ESAS_NO + " yevmiye numaral� ";
                    //deger.Icerik += " Hesap Kat �htarnamesi ";

                    break;
                }
            }

            return deger;
        }

        public static string TarihBicimlendirme(DateTime? tarih)
        {
            if (tarih.HasValue)
                return TarihBicimlendirme(tarih.Value, false);

            return string.Empty;
        }

        public static string TarihBicimlendirme(DateTime tarih, bool IsShort)
        {
            return tarih.ToShortDateString();
        }

        internal static DegiskenDegeri Get89Borclusu(AV001_TI_BIL_FOY aV001_TI_BIL_FOY)
        {
            DegiskenDegeri dd = new DegiskenDegeri();

            //dd.Degisken = degisken;
            dd.DonusTipi = DegiskenResulTType.HTML;

            dd.Icerik += @"";

            return dd;
        }

        //[ICRA] HARC DETAYLARI
        internal static void GetHarcDetaylari(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            field.Text = " ";

            txControl.Select(field.Start, 0);
            txControl.Tables.Add(1, 2, 5854);
            var table = txControl.Tables.GetItem(5854);
            var basvurma = new ParaVeDovizId(foy.BASVURMA_HARCI, foy.BASVURMA_HARCI_DOVIZ_ID);
            var vekalet = new ParaVeDovizId(foy.VEKALET_HARCI, foy.VEKALET_HARCI_DOVIZ_ID);
            var pesin = new ParaVeDovizId(foy.PESIN_HARC, foy.PESIN_HARC_DOVIZ_ID);
            var baro = new ParaVeDovizId(foy.VEKALET_PULU, foy.VEKALET_PULU_DOVIZ_ID);

            table.Cells.GetItem(1, 1).Text = string.Format("BA�VURMA HARCI :{0}VEKALET HARCI  :{0}PE��N HARCI    :{0}----------------{0}TOPLAM         :{0}BARO VEK. PULU :{0}----------------{0}GENEL TOPLAM   :", Environment.NewLine);
            var cell = table.Cells.GetItem(1, 2);

            cell.Text = string.Format("{1}{0}{2}{0}{3}{0}----------------{0}{4}{0}{5}{0}----------------{0}{6}"
                , Environment.NewLine
                , basvurma.ToString()
                , vekalet.ToString()
                , pesin.ToString()
                , ParaVeDovizId.Topla(basvurma, vekalet, pesin).ToString()
                , baro.ToString()
                , ParaVeDovizId.Topla(basvurma, vekalet, pesin, baro).ToString()
                );
            cell.Select();
            txControl.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Right;
        }

        //[ICRA] HARC GENEL TOPLAMI
        internal static void GetHarcGenelToplami(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            var basvurma = new ParaVeDovizId(foy.BASVURMA_HARCI, foy.BASVURMA_HARCI_DOVIZ_ID);
            var vekalet = new ParaVeDovizId(foy.VEKALET_HARCI, foy.VEKALET_HARCI_DOVIZ_ID);
            var pesin = new ParaVeDovizId(foy.PESIN_HARC, foy.PESIN_HARC_DOVIZ_ID);
            var baro = new ParaVeDovizId(foy.VEKALET_PULU, foy.VEKALET_PULU_DOVIZ_ID);

            field.Text = ParaVeDovizId.Topla(basvurma, vekalet, pesin, baro).ToString();
        }

        //[ICRA] ALACAK TURU
        internal static string GetIcraAlacakTuru(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
            List<string> liste = new List<string>();

            foreach (var item in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                if (item.ALACAK_NEDEN_KOD_IDSource == null)
                    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TI_KOD_ALACAK_NEDEN));

                if (item.ALACAK_NEDEN_KOD_IDSource == null)
                    continue;

                if (!liste.Contains(item.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI))
                    liste.Add(item.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI);
            }

            string result = string.Empty;

            foreach (var item in liste)
            {
                result += string.Format("{0} ,", item);
            }

            return result.TrimEnd(',');
        }

        /// <summary>
        /// Bankac�l�k mod�l� ise a�a��daki a��klamay� d�nd�r�r
        /// "Banka kredi alacaklar� 492 say�l� har�lar kanunun 123. maddesi gere�ince her t�rl� har�tan muaft�r."
        /// </summary>
        /// <param name="degisken"></param>
        /// <returns></returns>
        internal static string GetIcraBankaHarctanMuaf(AV001_TI_BIL_FOY foy)
        {
            string returnValue = string.Empty;

            if (foy != null)
            {
                TList<AV001_TI_BIL_FOY_TARAF> foyTaraflari = new TList<AV001_TI_BIL_FOY_TARAF>(DataRepository.AV001_TI_BIL_FOY_TARAFProvider.GetByICRA_FOY_ID(foy.ID).Where(vi => vi.TAKIP_EDEN_MI).ToList());

                if (foyTaraflari != null)
                    if (foyTaraflari.Where(vi => vi.BAKIYE_HARC_TOPLAMA_EKLE).Count() > 0)
                    {
                        if (GayrinakitleriGoster && !IpotekAzAlacakCok) returnValue = "Ancak �� bu takip Banka Kredi Alaca��na y�nelik olup, 492 say�l� Har�lar Kanunun 123. Maddesi gere�ince her t�rl� har�tan m�stesnad�r.";
                        else
                            returnValue = " �� bu takip Banka Kredi Alaca��na y�nelik olup, 492 say�l� Har�lar Kanunun 123. Maddesi gere�ince her t�rl� har�tan m�stesnad�r.";
                    }
            }

            return returnValue;
        }

        /// <summary>
        /// Deposu talep edilen alacaklar i�in Maktu Har� : x.00 TL
        /// bir dosyada depo alaca�� mevcut ise �stteki a��klamay� d�nd�rr
        /// </summary>
        /// <param name="foy"></param>
        /// <param name="degisken"></param>
        /// <returns></returns>
        internal static string GetIcraDepoAlacagiMaktuHarc(AV001_TI_BIL_FOY foy)
        {
            if (IpotekAzAlacakCok) return string.Empty;
            if (foy.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME>));
            if (foy.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME.FindAll(vi => vi.REHIN_CINS_ANA_TURU == 1).Count > 0) return string.Empty;

            string depoAlacagiAciklamalari = string.Empty;
            if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));

            SayiOkuma sa = new SayiOkuma();

            foreach (var aNeden in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                if (HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(aNeden))
                {
                    depoAlacagiAciklamalari += Environment.NewLine;
                    var harcTutari = FaizHelper.IcraHarcTutarGetir(foy.TAKIP_TARIHI.Value, (int)MuhasebeAltKategoriId.BA�VURMA_HARCI);
                    if (GayrinakitleriGoster)
                        depoAlacagiAciklamalari = string.Format("Gayrinakit alacaklarda har� maktu olup {0}'dir. Nakit alacaklarda ise nispidir.", sa.ParaFormatla(harcTutari.Para) + " " + harcTutari.DovizKodu);
                    else
                        depoAlacagiAciklamalari = "Deposu talep edilen alacaklar i�in Maktu Har� :" + sa.ParaFormatla(harcTutari.Para) + " " + harcTutari.DovizKodu;
                    break;
                }
            }

            return depoAlacagiAciklamalari;
        }

        /// <summary>
        /// Gayri Nakit alacaklar�n gruplan�p yaz�lmas�
        ///
        /// GAYR�NAK�T ALACAKLARIMIZ
        ///�ek Yapra��
        ///Her yapra�� 425 TL den 12 Adet �ek Yapra�� i�in 5.100 TL
        ///Mer� i Teminat Mektubu
        ///D�zenleme Tarihi 21.10.2006 olan, 123 seri nolu, 26.000 TL bedelli Muhatab� Ay�en Y�lmaz olan Mer� i Teminat Mektubu (Teminat Mektubu say�s�nca alt alta yaz�lacak
        ///Di�er Gayrinakit Alacaklar
        ///12.11,2003 tarih ve 23.000 TL bedelli Akreditif(alacak nedeninin ad�) (Di�er alacaklar virg�lle yan yana yaz�lacak)
        /// </summary>
        /// <param name="foy"></param>
        /// <param name="degisken"></param>
        /// <returns></returns>
        internal static string GetIcraGayriNakitAlacaklarimiz(AV001_TI_BIL_FOY foy)
        {
            SayiOkuma so = new SayiOkuma();
            string returnValue = string.Empty;
            if (!GayrinakitleriGoster) return returnValue;

            #region Depo Alacaklar�n� Grupluyoruz

            var gayriNakitAlacaklar = HesapAraclari.Icra.AlacakNedenGayriNakitleriGetir(foy);

            //gayri nakit alacak yoksa a��a��daki i�lemlere gerek yok
            if (gayriNakitAlacaklar.Count == 0)
            {
                GayrinakitleriGoster = false;
                return string.Empty;
            }

            List<AV001_TI_BIL_ALACAK_NEDEN> cekYapraklari = new List<AV001_TI_BIL_ALACAK_NEDEN>();
            List<AV001_TI_BIL_ALACAK_NEDEN> meriMektuplari = new List<AV001_TI_BIL_ALACAK_NEDEN>();
            List<AV001_TI_BIL_ALACAK_NEDEN> digerNedenler = new List<AV001_TI_BIL_ALACAK_NEDEN>();

            foreach (var aNeden in gayriNakitAlacaklar)
            {
                if (HesapAraclari.Icra.AlacakNedenCekYapragimi(aNeden))
                    cekYapraklari.Add(aNeden);
                else if (HesapAraclari.Icra.AlacakNedenMeriTeminatMektubuMu(aNeden))
                    meriMektuplari.Add(aNeden);
                else
                    digerNedenler.Add(aNeden);
            }

            #endregion Depo Alacaklar�n� Grupluyoruz

            #region Ba�l�k

            //Gayri Nakit Alaca��m�z Varsa Ba�l��� at�yoruz

            if (gayriNakitAlacaklar.Count > 0)
            {
                //returnValue += Environment.NewLine;
                returnValue += "GAYR�NAK�T ALACAKLAR" + Environment.NewLine;
            }

            #endregion Ba�l�k

            #region �ek Yapra��

            ParaVeDovizId paraCekYapraklari = new ParaVeDovizId();
            foreach (var aNeden in cekYapraklari)
            {
                ParaVeDovizId paraTekYaprak = new ParaVeDovizId(aNeden.CEK_YAPRAGI_SORUMLULUK_MIKTARI, aNeden.CEK_YAPRAGI_SORUMLULUK_MIKTARI_DOVIZ_ID);
                ParaVeDovizId paraIslemeKonanTutar = new ParaVeDovizId(aNeden.ISLEME_KONAN_TUTAR, aNeden.ISLEME_KONAN_TUTAR_DOVIZ_ID);
                string faizTipiOrani = aNeden.UYGULANACAK_FAIZ_ORANI.ToString();// FaizHelper.FaizOraniGetir(9, null, foy.TAKIP_TARIHI.Value).ToString();

                paraCekYapraklari = ParaVeDovizId.Topla(paraCekYapraklari, paraIslemeKonanTutar);

                returnValue += Environment.NewLine;
                returnValue += string.Format("Bor�lu tarafa verilmi� ancak alacakl�ya iade edilmemi� bulunan her birinin sorumlulu�u {0} hesab�yla {1} adet �ek yapra��n�n kanunda  kaynaklanan {2} TL gayri nakit alaca��n, nakti teminat olarak Alacakl� nezdindeki faiz getirmeyen bir hesaba depo edilmek suretiyle �denmesi; nakti teminat olarak depo edilmeden Alacakl�dan tazmin edilmesi durumunda tazmin edilen tutar�n tazmin tarihinden itibaren y�ll�k %{3} {4}, faizin %5 gider vergisi (BSMV) ve maktu vekalet �creti ile birlikte, k�smi �demeler �ncelikle BK.m.84 gere�ince faize mahsup edilecek �ekilde hesaplanarak ve tahsilde tekerr�r edilmemek �zere TAHS�L�.", so.ParaFormatla(paraTekYaprak.Para) + paraTekYaprak.DovizKodu, aNeden.ADET, so.ParaFormatla(paraIslemeKonanTutar.Para) + paraIslemeKonanTutar.DovizKodu, faizTipiOrani, DataRepository.TDI_KOD_FAIZ_TIPProvider.GetByID(aNeden.TO_ALACAK_FAIZ_TIP_ID.Value).FAIZ_TIP);

                returnValue += Environment.NewLine;
            }

            #endregion �ek Yapra��

            #region Mer`i mektubu

            ParaVeDovizId paraMeriMektuplari = new ParaVeDovizId(0, 1);
            foreach (var aNeden in meriMektuplari)
            {
                var Tarih = aNeden.DUZENLENME_TARIHI; //{0} - Tarih
                var seriNo = aNeden.ADET; //{1} - Seri No
                var bedeli = new ParaVeDovizId(aNeden.TUTARI, aNeden.TUTAR_DOVIZ_ID); //{2} - Bedeli
                var bedeliText = so.ParaFormatla(bedeli.Para) + " " + bedeli.DovizKodu;
                var muhattabi = HesapAraclari.Icra.CariAdiGetirByCariId(aNeden.TEMINAT_MEKTUP_MUHATAP_CARI_ID.Value); //{3} - Muhattab�
                string faizTipiOrani = aNeden.UYGULANACAK_FAIZ_ORANI.ToString();// FaizHelper.FaizOraniGetir(9, null, foy.TAKIP_TARIHI.Value).ToString();

                paraMeriMektuplari = ParaVeDovizId.Topla(paraMeriMektuplari, bedeli);

                returnValue += Environment.NewLine;
                returnValue += string.Format("{0}'ne hitaben verilmi� bulunan {1} tarihli, {2} say�l� {3} bedelli teminat mektubunun teminat nakti teminat olarak Alacakl� nezdindeki faiz getirmeyen bir hesaba depo edilmek suretiyle �denmesi; nakti teminat olarak depo edilmeden Alacakl�dan tazmin edilmesi durumunda tazmin edilen tutar�n tazmin tarihinden itibaren y�ll�k %{4} {5}, %5 gider vergisi (BSMV) ve maktu vekalet �creti ile birlikte, k�smi �demeler �ncelikle BK.m.84 gere�ince faize mahsup edilecek �ekilde hesaplanarak ve tahsilde tekerr�r edilmemek �zere TAHS�L�.", muhattabi, Tarih.HasValue ? Tarih.Value.ToShortDateString() : "", seriNo, bedeliText, faizTipiOrani, DataRepository.TDI_KOD_FAIZ_TIPProvider.GetByID(aNeden.TO_ALACAK_FAIZ_TIP_ID.Value).FAIZ_TIP);

                returnValue += Environment.NewLine;
            }

            #endregion Mer`i mektubu

            #region Di�er Alacaklar

            //Di�er Alacaklar varsa ba�l���n� at�oyruz
            //if (digerNedenler.Count > 0)
            //    returnValue += "Mer�i Teminat Mektubu" + Environment.NewLine;

            ParaVeDovizId paraDigerAlacaklar = new ParaVeDovizId(0, 1);
            foreach (var aNeden in digerNedenler)
            {
                var Tarih = aNeden.DUZENLENME_TARIHI; //{0} - Tarih
                var bedeli = new ParaVeDovizId(aNeden.TUTARI, aNeden.TUTAR_DOVIZ_ID); //{2} - Bedeli
                var bedeliText = so.ParaFormatla(bedeli.Para) + " " + bedeli.DovizKodu;
                var alacakNEdenAdi = HesapAraclari.Icra.AlacakNedenAdiGetirByAlacakNedenKodId(aNeden.ALACAK_NEDEN_KOD_ID.Value);
                paraDigerAlacaklar = ParaVeDovizId.Topla(paraDigerAlacaklar, bedeli);
                string faizTipiOrani = aNeden.UYGULANACAK_FAIZ_ORANI.ToString();// FaizHelper.FaizOraniGetir(9, null, foy.TAKIP_TARIHI.Value).ToString();
                var muhattabi = HesapAraclari.Icra.CariAdiGetirByCariId(aNeden.TEMINAT_MEKTUP_MUHATAP_CARI_ID.Value); //{3} - Muhattab�
                var seriNo = aNeden.ADET; //{1} - Seri No

                returnValue += Environment.NewLine;
                returnValue += string.Format("{0}'ne hitaben verilmi� bulunan {1} tarihli, {2} say�l� {3} bedelli {5} teminat nakti teminat olarak Alacakl� nezdindeki faiz getirmeyen bir hesaba depo edilmek suretiyle �denmesi; nakti teminat olarak depo edilmeden Alacakl�dan tazmin edilmesi durumunda tazmin edilen tutar�n tazmin tarihinden itibaren y�ll�k %{4} {6}, %5 gider vergisi ve maktu vekalet �creti ile birlikte, k�smi �demeler �ncelikle BK.m.84 gere�ince faize mahsup edilecek �ekilde hesaplanarak ve tahsilde tekerr�r edilmemek �zere TAHS�L�.", muhattabi, Tarih.HasValue ? Tarih.Value.ToShortDateString() : "", seriNo, bedeliText, faizTipiOrani, alacakNEdenAdi, DataRepository.TDI_KOD_FAIZ_TIPProvider.GetByID(aNeden.TO_ALACAK_FAIZ_TIP_ID.Value).FAIZ_TIP);

                returnValue += Environment.NewLine;
            }

            //if (digerNedenler.Count > 0)
            //{
            //    returnValue += "Toplam : " + so.ParaFormatla(paraDigerAlacaklar.Para) + " " + paraDigerAlacaklar.DovizKodu;
            //    returnValue += Environment.NewLine;
            //    //returnValue += "-----------------------------";
            //    //returnValue += Environment.NewLine;
            //}

            #endregion Di�er Alacaklar

            #region Genel Toplam

            ParaVeDovizId genelToplam = ParaVeDovizId.Topla(paraMeriMektuplari, paraCekYapraklari, paraDigerAlacaklar);

            if (gayriNakitAlacaklar.Count > 0)
            {
                returnValue += Environment.NewLine;
                returnValue += "Gayri Nakit Alacaklar Toplam� : " + so.ParaFormatla(genelToplam.Para) + " " + genelToplam.DovizKodu;// +"'nin nakti teminat olarak depo edilmek �zere, vekalet �creti ve takip giderleri ile birlikte tahsili talebidir.";
                returnValue += Environment.NewLine;
                //returnValue += "Gayri nakit alaca��m�z nakti teminat olarak tahsil edilmeden, m�vekkil bankadan tazmin edilmesi (alaca��m�z�n nakde d�n��mesi) halinde ise, nakte d�n��en alaca��m�z�n nakte d�n��t��� tarihten itibaren i�leyecek y�ll�k % " + gayriNakitAlacaklar[0].UYGULANACAK_FAIZ_ORANI.ToString() + " Temerr�t faizi, faizin %";
                //returnValue += FaizHelper.DigerVergiOraniGetir(DigerVergiTuru.BSMV, foy.TAKIP_TARIHI.Value).ToString();
                //returnValue += " gider vergisi, vekalet �creti ve takip giderleri ile birlikte ve k�smi �demeler BK.m.84 gere�ince faize mahsup edilerek tahsili talebimizdir.";
            }

            #endregion Genel Toplam

            //string aciklama = "nakti teminat olarak depo edilmek �zere, vekalet �creti ve takip giderleri ile birlikte tahsili talebidir";
            //aciklama += Environment.NewLine;
            //aciklama += "Gayri nakit alaca��m�z nakti teminat olarak tahsil edilmeden, m�vekkil bankan�n tazmin etmesi (alaca��m�z�n nakite d�n��mesi) halinde ise, nakte d�n��en alaca��m�z�n nakte d�n��t��� tarihten itibaren i�leyecek y�ll�k (yukar�da listelenen alacak nedenlerinin yanlar�nda belirtilen faiz tip ve oranlar� ile) temerr�t faizi, faizin %";
            //aciklama += FaizHelper.DigerVergiOraniGetir(DigerVergiTuru.BSMV, foy.TAKIP_TARIHI.Value).ToString();
            //aciklama += " gider vergisi, vekalet �creti ve takip giderleri ile birlikte ve k�smi �demeler BK.m.84 gere�ince faize mahsup edilerek tahsili talebimizdir.";
            //returnValue += aciklama;

            return returnValue;
        }

        //[ICRA] MASRAF MAKBUZU ALACAGA MAHSUPLU MAL ALIM
        //[ICRA] MASRAF MAKBUZU DIGER ALACAKLAR
        //[ICRA] MASRAF MAKBUZU HACIZ KESIF
        //[ICRA] MASRAF MAKBUZU ILK MASRAFLAR
        internal static void GetIcraGrupluMasrafBilgileri(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field, MasrafGrubu grup)
        {
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));

            int[] alacagaMahMalAlimMasraflari = new int[] { 397, 812, 853 };
            int[] digerAlacaklar = new int[]
            { 592, 596, 398, 441, 598, 597, 599, 806, 807, 809, 600, 16, 18, 27, 30,
                33, 813, 852, 859, 10003, 6, 645, 646, 648, 601, 649, 650, 656, 651,
                24, 32, 42, 319, 320, 604, 562, 564, 862, 567, 584, 630, 642, 631, 640,
                633, 634, 635, 641, 637, 638, 643, 644, 872, 860, 858, 855, 861, 547 };
            int[] hacisKesif = new int[] { 854, 382, 385, 392, 393, 394, 395, 238, 606, 607 };
            int[] ilkMasraflar = new int[] { 383, 440, 451, 452, 810, 7, 594, 802, 803, 804, 805, 590, 603, 591, 602, 568, 808, 10, 11, 629, 23, 34, 615, 616, 652, 647 };

            List<int> idListesi = new List<int>();
            int tableID = 9898;
            switch (grup)
            {
                case MasrafGrubu.alacagaMahMalAlimMasraflari:
                    idListesi.AddRange(alacagaMahMalAlimMasraflari);
                    break;

                case MasrafGrubu.digerAlacaklar:
                    idListesi.AddRange(digerAlacaklar);
                    tableID = 9899;
                    break;

                case MasrafGrubu.hacisKesif:
                    idListesi.AddRange(hacisKesif);
                    tableID = 9810;
                    break;

                case MasrafGrubu.ilkMasraflar:
                    idListesi.AddRange(ilkMasraflar);
                    tableID = 9812;
                    break;

                case MasrafGrubu.Toplam:
                    idListesi.AddRange(ilkMasraflar);
                    idListesi.AddRange(hacisKesif);
                    idListesi.AddRange(digerAlacaklar);
                    idListesi.AddRange(alacagaMahMalAlimMasraflari);
                    tableID = 9814;
                    break;
            }

            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> lAlacagaMahMasraf = new TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>();

            foreach (var item in foy.AV001_TDI_BIL_MASRAF_AVANSCollection)
            {
                if (item.BORCLU_CARI_ID.HasValue) continue;

                DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));

                lAlacagaMahMasraf.AddRange(item.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Where(vi => idListesi.Contains(vi.HAREKET_ALT_KATEGORI_ID)).ToList());
            }

            field.Text = " ";

            txControl.Select(field.Start, 0);

            if (grup == MasrafGrubu.Toplam && lAlacagaMahMasraf != null && lAlacagaMahMasraf.Count > 0)
            {
                var para = ParaVeDovizId.Topla(lAlacagaMahMasraf.Select(vi => new ParaVeDovizId(vi.TOPLAM_TUTAR, vi.TOPLAM_TUTAR_DOVIZ_ID)).ToList());

                txControl.Tables.Add(1, 2, tableID);

                var mainTable = txControl.Tables.GetItem(tableID);

                var enume = mainTable.Cells.GetEnumerator();

                while (enume.MoveNext())
                {
                    var cell = enume.Current as TableCell;

                    if (cell.Column == 1)
                    {
                        cell.Select();
                        txControl.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Left;

                        cell.Text = "Toplam";
                    }
                    else if (cell.Column == 2)
                    {
                        cell.Select();
                        txControl.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Right;

                        cell.Text = para.GetStringValue();
                    }
                }

                return;
            }

            var gruplar = lAlacagaMahMasraf.GroupBy(vi => vi.HAREKET_ALT_KATEGORI_ID);

            if (gruplar.Count() > 0)
            {
                txControl.Tables.Add(gruplar.Count(), 2, tableID);

                var mainTable = txControl.Tables.GetItem(tableID);

                var enume = mainTable.Cells.GetEnumerator();

                while (enume.MoveNext())
                {
                    var cell = enume.Current as TableCell;

                    var kay�t = gruplar.ToList()[cell.Row - 1];

                    if (cell.Column == 1)
                    {
                        cell.Select();
                        txControl.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Left;

                        cell.Text = DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByID(kay�t.Key).ALT_KATEGORI;
                    }
                    else if (cell.Column == 2)
                    {
                        cell.Select();
                        txControl.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Right;

                        var toplam = ParaVeDovizId.Topla(kay�t.Select(vi => new ParaVeDovizId(vi.TOPLAM_TUTAR, vi.TOPLAM_TUTAR_DOVIZ_ID)).ToList());
                        cell.Text = toplam.GetStringValue();
                    }
                }
            }
        }

        //[ICRA] KARSI TARAFLAR
        internal static string GetIcraKarsiTaraflar(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));

            string result = string.Empty;

            foreach (var item in foy.AV001_TI_BIL_FOY_TARAFCollection.Where(vi => vi.TARAF_KODU == (int)TarafKodlari.K))
            {
                if (item.CARI_IDSource == null)
                    DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));

                if (item.CARI_IDSource != null)
                    result += string.Format("{0} ,", item.CARI_IDSource.AD);
            }

            return result;
        }

        //[ICRA] KREDI BORCLUSU
        internal static string GetIcraKrediBorclusu(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TDIE_BIL_PROJECollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE>));

            if (foy.AV001_TDIE_BIL_PROJECollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY.Count > 0)
            {
                return foy.AV001_TDIE_BIL_PROJECollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY[0].ADI;
            }

            return GetIcraKarsiTaraflar(foy, txControl, field);
        }

        //[ICRA] SORUMLU ADI
        //[ICRA] YETKILI ADI
        internal static string GetIcraSorumlusu(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field, bool yetkili)
        {
            if (foy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));

            var sorumlular = foy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Where(vi => vi.YETKILI_MI == yetkili);
            if (sorumlular.Count() == 0)
                sorumlular = foy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Where(vi => vi.YETKILI_MI == !yetkili);

            string result = string.Empty;

            foreach (var item in sorumlular)
            {
                if (item.SORUMLU_AVUKAT_CARI_IDSource == null)
                    DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI>));

                if (item.SORUMLU_AVUKAT_CARI_IDSource != null)
                    result += string.Format("{0} ,", item.SORUMLU_AVUKAT_CARI_IDSource.AD);
            }

            return result.TrimEnd(',');
        }

        //[ICRA] IHTIYATI TEDBIR HACIZ ESAS NO
        internal static string GetIhtiyatiHacizEsasNo(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TI_BIL_IHTIYATI_HACIZCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ>));

            if (foy.AV001_TI_BIL_IHTIYATI_HACIZCollection.Count > 0)
            {
                return foy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].ESAS_NO;
            }

            return string.Empty;
        }

        //[ICRA] IHTIYATI TEDBIR HACIZ GOREVLI MAHKEMESI
        internal static string GetIhtiyatiHacizMahkemeGorevi(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TI_BIL_IHTIYATI_HACIZCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ>));

            if (foy.AV001_TI_BIL_IHTIYATI_HACIZCollection.Count > 0)
            {
                string result = string.Empty;
                if (foy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].ADLI_BIRIM_ADLIYE_ID.HasValue)
                {
                    result += DataRepository.TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetByID(foy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].ADLI_BIRIM_ADLIYE_ID.Value).ADLIYE;
                    result += " ";
                }
                if (foy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].ADLI_BIRIM_NO_ID.HasValue)
                {
                    result += EditorDataAraclari.Icra.GetAdliBirimNo(foy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].ADLI_BIRIM_NO_ID);
                    result += " ";
                }
                if (foy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].ADLI_BIRIM_GOREV_ID.HasValue)
                {
                    result += DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.GetByID(foy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].ADLI_BIRIM_GOREV_ID.Value).ACIKLAMA;
                }

                return result;
            }

            return string.Empty;
        }

        //[ICRA] IHTIYATI TEDBIR HACIZ TALEP TARIHI
        internal static string GetIhtiyatiHacizTalepTarihi(AV001_TI_BIL_FOY foy, TextControl txControl, TextField field)
        {
            if (foy.AV001_TI_BIL_IHTIYATI_HACIZCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ>));

            if (foy.AV001_TI_BIL_IHTIYATI_HACIZCollection.Count > 0 && foy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].TALEP_TARIHI.HasValue)
            {
                return TarihBicimlendirme(foy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].TALEP_TARIHI);
            }

            return string.Empty;
        }

        internal static string IcraBorcluTarafFarkliSorumluluk(AV001_TI_BIL_FOY myFoy)
        {
            string returnValue = string.Empty;

            List<int> tamamiOlanlar = new List<int>();

            Dictionary<int, ParaVeDovizId> tempFarkliOlanlar = new Dictionary<int, ParaVeDovizId>();
            Dictionary<int, ParaVeDovizId> farkliOlanlar = new Dictionary<int, ParaVeDovizId>();

            TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> aNedenTarafList = new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>();

            DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByICRA_FOY_ID(myFoy.ID).FindAll(vi => !AvukatProLib.Hesap.HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(vi)).ForEach(aNeden =>
                {
                    var borcluList = DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.GetByICRA_ALACAK_NEDEN_ID(aNeden.ID).FindAll(vi => vi.TARAF_SIFAT_ID != (int)TarafSifat.ALACAKLI);

                    if (borcluList != null && borcluList.Count > 0) aNedenTarafList.AddRange(borcluList);
                });

            foreach (var taraf in aNedenTarafList)
            {
                //if (myFoy.ASIL_ALACAK != taraf.SORUMLU_OLUNAN_MIKTAR) MB
                //{
                if (!tempFarkliOlanlar.ContainsKey(taraf.TARAF_CARI_ID))
                    tempFarkliOlanlar.Add(taraf.TARAF_CARI_ID, new ParaVeDovizId(taraf.SORUMLU_OLUNAN_MIKTAR, taraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID));
                else
                    tempFarkliOlanlar.Where(vi => vi.Key == taraf.TARAF_CARI_ID).FirstOrDefault().Value.Para += taraf.SORUMLU_OLUNAN_MIKTAR.Value;

                //}
            }
            foreach (var item in tempFarkliOlanlar)//MB
            {
                if (item.Value.Para != myFoy.ASIL_ALACAK) farkliOlanlar.Add(item.Key, item.Value);
                else tamamiOlanlar.Add(item.Key);
            }
            if (farkliOlanlar.Count == 0) return string.Empty;

            SayiOkuma so = new SayiOkuma();

            string tamamiAdlari = string.Empty;
            foreach (var teki in tamamiOlanlar)
            {
                tamamiAdlari += HesapAraclari.Icra.CariAdiGetirByCariId(teki) + ",";
            }
            string farkliAdlari = string.Empty;
            foreach (var teki in farkliOlanlar)
            {
                farkliAdlari += HesapAraclari.Icra.CariAdiGetirByCariId(teki.Key) + " " + so.ParaFormatla(teki.Value.Para) + " " + teki.Value.DovizKodu + ", ";
            }
            farkliAdlari = farkliAdlari.TrimEnd(' ', ',');
            if (!string.IsNullOrEmpty(tamamiAdlari))
                returnValue = string.Format(@"Bor�lulardan {0} dosya alaca��m�z�n tamam�ndan di�er bor�lu/lar {1}  ve bu miktara isabet eden temerr�t faizi, gider vergisi, vekalet �creti, masraf ve di�er ferilerden sorumlu olmak �zere alaca��m�z�n tahsilini talep ederiz.", tamamiAdlari, farkliAdlari);
            else
                returnValue = string.Format(
                @"Dosya alaca��m�zdan di�er bor�lu/lar {1}  ve bu miktara isabet eden temerr�t faizi, gider vergisi, vekalet �creti, masraf ve di�er ferilerden sorumlu olmak �zere alaca��m�z�n tahsilini talep ederiz.", tamamiAdlari, farkliAdlari);

            return returnValue;
        }

        /// <summary>
        /// Faiz kay�tlar�nda d�nerek �stenilen Hesap kalemine ait tutar� getirir
        /// </summary>
        /// <param name="aV001_TI_BIL_ALACAK_NEDEN"></param>
        /// <returns></returns>
        private static ParaVeDovizId AlacakNedenindenTutarGetir(AV001_TI_BIL_ALACAK_NEDEN aNeden, DegerKalemi kalem, bool takipOncesi)
        {
            if (aNeden.AV001_TI_BIL_FAIZCollection.Count == 0)
                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(aNeden, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FAIZ>));

            List<ParaVeDovizId> paralar = new List<ParaVeDovizId>();
            foreach (var faiz in aNeden.AV001_TI_BIL_FAIZCollection)
            {
                if (faiz.FAIZ_TAKIPDEN_ONCE_MI == (short)(takipOncesi ? 1 : 0))
                {
                    switch (kalem)
                    {
                        case DegerKalemi.BSMV:
                            paralar.Add(new ParaVeDovizId(faiz.BSMV_TUTARI, faiz.BSMV_DOVIZ_ID));
                            break;

                        case DegerKalemi.KDV:
                            paralar.Add(new ParaVeDovizId(faiz.KDV_TUTARI, faiz.KDV_DOVIZ_ID));
                            break;

                        case DegerKalemi.KKDV:
                            paralar.Add(new ParaVeDovizId(faiz.KKDF_TUTARI, faiz.KKDF_DOVIZ_ID));
                            break;

                        case DegerKalemi.OIV:
                            paralar.Add(new ParaVeDovizId(faiz.OIV_TUTARI, faiz.OIV_DOVIZ_ID));
                            break;

                        default:
                            break;
                    }
                }
            }

            return ParaVeDovizId.Topla(paralar);
        }

        /// <summary>
        /// bir decimal e�erin null, zero , m�nusOnse, minvalue , one, zero ya e�it oldu�u durumnlardaw geriye false
        /// di�er durumlarda true doner.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool decimalControl(decimal? value)
        {
            if (value == null)
            {
                return false;
            }
            if (value == decimal.Zero || value == decimal.MinusOne || value == decimal.MinValue || value == decimal.One || value == 0)
            {
                return false;
            }
            return true;
        }

        private static string GetAciklamaByGrupInAlacakNedenDegiskenList(TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> lstAlacakNedenler, TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP> grup)
        {
            TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> rv = new TList<TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN>();
            for (int i = 0; i < lstAlacakNedenler.Count; i++)
            {
                for (int y = 0; y < grup.Count; y++)
                {
                    if (lstAlacakNedenler[i].KOD_ALACAK_NEDEN_GRUP_ID.Value == grup[y].GRUP_NO)
                    {
                        rv.Add(lstAlacakNedenler[i]);
                        break;
                    }
                }
            }
            if (rv.Count == 0)
            {
                return "";
            }

            return rv[0].ACIKLAMA;
        }

        private static List<TextField> getGayrimenkulBilgisi(AV001_TDI_BIL_SOZLESME Sozlesme)
        {
            List<TextField> returnValue = new List<TextField>();
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(Sozlesme, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_GAYRIMENKUL>));

            TList<AV001_TI_BIL_GAYRIMENKUL> lstGayriMenkuls = Sozlesme.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL;
            DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(lstGayriMenkuls, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE), typeof(TDI_KOD_TAPU_MUDURLUK), typeof(TList<AV001_TDI_BIL_SOZLESME_DERECE>), typeof(TList<AV001_TI_BIL_GAYRIMENKUL_TARAF>));

            for (int i = 0; i < lstGayriMenkuls.Count; i++)
            {
                #region C�MLE DE���KENLER�

                string tapuMudurlugu = string.Empty;

                //gayrimenkul�n tapu m�d�rl�k bilgileri se�ilmi� olmas� durumunda bilgilerini aluyoruz
                if (lstGayriMenkuls[i].TAPU_MUDURLUK_IDSource != null)
                    tapuMudurlugu = lstGayriMenkuls[i].TAPU_MUDURLUK_IDSource.ADI;

                string il = lstGayriMenkuls[i].IL_IDSource != null ? lstGayriMenkuls[i].IL_IDSource.IL : string.Empty;
                string ilce = lstGayriMenkuls[i].ILCE_IDSource != null ? lstGayriMenkuls[i].ILCE_IDSource.ILCE : string.Empty;
                string bucak = lstGayriMenkuls[i].BUCAK;
                string mahalle = lstGayriMenkuls[i].MAHALLE_ADI;
                string koy = lstGayriMenkuls[i].KOY_ADI;
                string mevki = lstGayriMenkuls[i].MEVKI_ADI;
                string ada = lstGayriMenkuls[i].ADA_NO;
                string pafta = lstGayriMenkuls[i].PAFTA_NO;
                string parsel = lstGayriMenkuls[i].PARSEL_NO;
                string yevmiye = Sozlesme.SICIL_YEVMIYE_NO;
                string cilt = lstGayriMenkuls[i].CILT_NO;
                string sahife = lstGayriMenkuls[i].SAHIFE_NO;
                string dek = lstGayriMenkuls[i].YUZOLCUMU_DEKAR;
                string dm2 = lstGayriMenkuls[i].YUZOLCUMU_DM2;
                string hektar = lstGayriMenkuls[i].YUZOLCUMU_HEKTAR;
                string arsaPayi = lstGayriMenkuls[i].ARSA_PAYI;
                string katNo = lstGayriMenkuls[i].KAT_NO;
                string bagimsizBolumNo = lstGayriMenkuls[i].BAGIMSIZ_BOLUM_NO;
                string siniri = lstGayriMenkuls[i].SINIRI;
                string niteligi = lstGayriMenkuls[i].NITELIGI;
                string derece = string.Empty;
                string sira = string.Empty;
                string tarih = Sozlesme.IMZA_TARIHI.HasValue ? Sozlesme.IMZA_TARIHI.Value.ToShortDateString() : string.Empty;

                //Maliki
                string maliki = string.Empty;
                foreach (var gTaraf in lstGayriMenkuls[i].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection)
                {
                    if (BelgeUtil.Inits._per_CariGetir == null)
                        BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();
                    maliki += BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == gTaraf.TARAF_CARI_ID.Value).AD + ", ";
                }
                SayiOkuma sa = new SayiOkuma();
                if (BelgeUtil.Inits._DovizTipGetir == null)
                    BelgeUtil.Inits._DovizTipGetir = DataRepository.per_TDI_KOD_DOVIZ_TIPProvider.GetAll();

                string bedeli = sa.ParaFormatla(Sozlesme.BEDELI) + " " + BelgeUtil.Inits._DovizTipGetir.Find(vi => vi.ID == Sozlesme.BEDELI_DOVIZ_ID.Value).DOVIZ_KODU;

                //Gayrimenkule ba�l� dere olmas� durumunda dere bilgilerini al�yoruz,
                //bir gayrimenkule ba�l� bir derece olabilece�inden dolay�
                //collection un 1. eleman�n� al�yoruz

                if (lstGayriMenkuls[i].AV001_TDI_BIL_SOZLESME_DERECECollection.Count > 0)
                {
                    var sDerece = lstGayriMenkuls[i].AV001_TDI_BIL_SOZLESME_DERECECollection[0];
                    derece = sDerece.DERECESI;
                    sira = sDerece.SIRASI;
                }

                #endregion C�MLE DE���KENLER�

                #region C�mle

                #region Maliki

                if (!string.IsNullOrEmpty(maliki))
                {
                    InsertTextField("Maliki " + maliki.Remove(maliki.Length - 2, 2), 0, "maliki", returnValue, "AV001_TDI_BIL_CARI");
                    InsertTextField(" olan, ", 0, "yazi", returnValue, "yazi");
                }

                #endregion Maliki

                #region �L

                if (il.Length > 0)
                {
                    InsertTextField(il, lstGayriMenkuls[i].IL_IDSource.ID, "IL", returnValue, "TDI_KOD_IL");
                    InsertTextField(" �li, ", 0, "yazi", returnValue, "yazi");
                }

                #endregion �L

                #region �L�E

                if (ilce.Length > 0)
                {
                    InsertTextField(ilce, lstGayriMenkuls[i].IL_IDSource.ID, "ILCE", returnValue, "TDI_KOD_ILCE");
                    InsertTextField(" �l�esi, ", 0, "yazi", returnValue, "yazi");
                }

                #endregion �L�E

                #region MAHALLE

                if (mahalle.Length > 0)
                {
                    InsertTextField(mahalle, lstGayriMenkuls[i].IL_IDSource.ID, "MAHALLE_ADI", returnValue, "TDI_KOD_TAPU_MUDURLUK");
                    InsertTextField(" Mahallesi, ", 0, "yazi", returnValue, "yazi");
                }

                #endregion MAHALLE

                #region K�Y

                if (koy.Length > 0)
                {
                    InsertTextField(koy, lstGayriMenkuls[i].IL_IDSource.ID, "KOY_ADI", returnValue, "TDI_KOD_TAPU_MUDURLUK");
                    InsertTextField(" K�y�, ", 0, "yazi", returnValue, "yazi");
                }

                //

                #endregion K�Y

                #region MEVK�

                if (mevki.Length > 0)
                {
                    InsertTextField(mevki, lstGayriMenkuls[i].ID, "MEVKI_ADI", returnValue, "AV001_TI_BIL_GAYRIMENKUL");
                    InsertTextField(" Mevkiinde kain , ", 0, "yazi", returnValue, "yazi");
                }

                #endregion MEVK�

                #region M�D�RL�K

                if (tapuMudurlugu.Length > 0)
                {
                    InsertTextField(tapuMudurlugu, lstGayriMenkuls[i].IL_IDSource.ID, "ADI", returnValue, "TDI_KOD_TAPU_MUDURLUK");
                    InsertTextField(" tapuya ", 0, "yazi", returnValue, "yazi");
                }

                //

                #endregion M�D�RL�K

                #region SAH�FE

                if (sahife.Length > 0)
                {
                    InsertTextField(sahife, lstGayriMenkuls[i].ID, "SAHIFE_NO", returnValue, "AV001_TI_BIL_GAYRIMENKUL");
                    InsertTextField(" sayfa, ", 0, "yazi", returnValue, "yazi");
                }

                #endregion SAH�FE

                #region C�LT

                if (cilt.Length > 0)
                {
                    InsertTextField(cilt, lstGayriMenkuls[i].ID, "CILT_NO", returnValue, "AV001_TI_BIL_GAYRIMENKUL");
                    InsertTextField(" cilt, ", 0, "yazi", returnValue, "yazi");
                }

                #endregion C�LT

                #region ADA

                if (ada.Length > 0)
                {
                    InsertTextField(ada, lstGayriMenkuls[i].ID, "ADA_NO", returnValue, "AV001_TI_BIL_GAYRIMENKUL");
                    InsertTextField(" ada, ", 0, "yazi", returnValue, "yazi");
                }

                #endregion ADA

                #region PAFTA

                if (pafta.Length > 0)
                {
                    InsertTextField(pafta, lstGayriMenkuls[i].ID, "PAFTA_NO", returnValue, "AV001_TI_BIL_GAYRIMENKUL");
                    InsertTextField(" pafta, ", 0, "yazi", returnValue, "yazi");
                }

                #endregion PAFTA

                #region PARSEL

                if (parsel.Length > 0)
                {
                    InsertTextField(parsel, lstGayriMenkuls[i].ID, "PARSEL_NO", returnValue, "AV001_TI_BIL_GAYRIMENKUL");
                    InsertTextField(" parselde kay�tl�, ", 0, "yazi", returnValue, "yazi");
                }

                #endregion PARSEL

                #region ARSA PAYI

                if (arsaPayi.Length > 0)
                {
                    InsertTextField(arsaPayi, lstGayriMenkuls[i].ID, "ARSA_PAYI", returnValue, "AV001_TI_BIL_GAYRIMENKUL");
                    InsertTextField(" arsa payl�, ", 0, "yazi", returnValue, "yazi");
                }

                #endregion ARSA PAYI

                #region BA�IMSIZ NO

                if (bagimsizBolumNo.Length > 0)
                {
                    InsertTextField(bagimsizBolumNo, lstGayriMenkuls[i].ID, "BAGIMSIZ_BOLUM_NO", returnValue, "AV001_TI_BIL_GAYRIMENKUL");
                    InsertTextField(" ba��ms�z b�l�m �zerine, ", 0, "yazi", returnValue, "yazi");
                }

                #endregion BA�IMSIZ NO

                #region Tarih

                if (!string.IsNullOrEmpty(tarih))
                {
                    InsertTextField(tarih, 0, "tarih", returnValue, "AV001_TDI_BIL_SOZLESME");
                    InsertTextField(" tarihinde, ", 0, "yazi", returnValue, "yazi");
                }

                #endregion Tarih

                #region YEVM�YE

                if (yevmiye.Length > 0)
                {
                    InsertTextField(yevmiye, lstGayriMenkuls[i].ID, "YEVMIYE", returnValue, "AV001_TI_BIL_GAYRIMENKUL");
                    InsertTextField(" yevmiye numaras�yla tesis edilmi� bulunan, ", 0, "yazi", returnValue, "yazi");
                }

                #endregion YEVM�YE

                #region Derece

                if (!string.IsNullOrEmpty(derece))
                {
                    InsertTextField(derece, 0, "derece", returnValue, "AV001_TDI_BIL_SOZLESME_DERECE");
                    InsertTextField(". derece ", 0, "yazi", returnValue, "yazi");
                }

                #endregion Derece

                #region C�MLE SONU

                if (Sozlesme.REHIN_CINS_ANA_TURU == 1)
                    InsertTextField(" anapara ipote�i,", 0, "yazi", returnValue, "yazi");
                else
                {
                    InsertTextField(bedeli, 0, "bedeli", returnValue, "AV001_TDI_BIL_SOZLESME");
                    InsertTextField(" bedelli limit ipote�i", 0, "yazi", returnValue, "yazi");
                }

                InsertTextField(Environment.NewLine, 0, "yazi", returnValue, "yazi");

                #endregion C�MLE SONU

                #endregion C�mle
            }
            return returnValue;
        }

        private static string gethesapsFromNesne(hesaplar[] hesaps, AvukatProLib2.Entities.AV001_TI_BIL_FOY foyid, TextControl txtcnt, string extrainfo, string bottomText, bool alacakNedenleriBirdenFazla)
        {
            List<TextField> lstFileds = new List<TextField>();
            DateTime faizBaslama = new DateTime();
            DateTime faizBitis = new DateTime();
            string fTipi = string.Empty;

            SayiOkuma so = new SayiOkuma();
            int row = 0;

            for (int i = 0; i < hesaps.Length; i++)
            {
                if (hesaps[i].DovizId.HasValue)
                {
                    if (hesaps[i].Deger is decimal)
                    {
                        if ((decimal)hesaps[i].Deger == decimal.Zero)
                        {
                            continue;
                        }
                    }
                    if (hesaps[i].Aciklama == "ifs")
                    {
                        continue;
                    }
                    row++;
                }
            }
            row++;
            if (IpotekAzAlacakCok) row = row + 7;

            int tid = tableCounter + 200;

            tableCounter++;

            if (alacakNedenleriBirdenFazla)
            {
                Table tbll = txtcnt.Tables.GetItem(tid - 1);
                txtcnt.Selection.Start = txtcnt.Selection.Start - 2;// +1;
                txtcnt.Selection.Text = " ";
            }
            if (txtcnt.Tables.CanAdd)
            {
                txtcnt.Tables.Add(row, 3, tid);
            }
            else
            {
                txtcnt.Selection.Start += 1;
                txtcnt.Selection.Length = 0;
                txtcnt.Selection.Text = Environment.NewLine;
                txtcnt.Tables.Add(row, 3, tid);
            }

            Table tbl = txtcnt.Tables.GetItem(tid);
            if (txtcnt.Tables.CanAdd)
            {
                txtcnt.Tables.Add(1, 1, tid + 1);
            }
            else
            {
                txtcnt.Selection.Length = 1;
                txtcnt.Selection.Start += 1;

                txtcnt.Tables.Add(1, 1, tid + 1);
            }

            #region <MB-20110105>

            //Munzam Miktar�, Alacak Miktar�ndan b�y�kse a��klaman�n alt�na 3 tane row eklenmesi i�lemini sa�l�yor. MB

            if (MunzamVar)
            {
                if (txtcnt.Tables.CanAdd)
                {
                    txtcnt.Tables.Add(3, 2, tid + 2);
                }
                else
                {
                    txtcnt.Selection.Length = 1;
                    txtcnt.Selection.Start += 1;

                    txtcnt.Tables.Add(3, 2, tid + 2);
                }
                NewRowID = tid + 2;

                Table tbl3 = txtcnt.Tables.GetItem(tid + 2);
                tbl3.Columns.GetItem(1).Width = 2500;
                tbl3.Columns.GetItem(2).Width = 3200;
            }

            #endregion <MB-20110105>

            if (foyid.TAKIP_CIKISI_DOVIZ_ID != 1)
            {
                if (txtcnt.Tables.CanAdd)
                {
                    txtcnt.Tables.Add(1, 1, tid + 1);
                }
                else
                {
                    txtcnt.Selection.Length = 1;
                    txtcnt.Selection.Start += 1;

                    txtcnt.Tables.Add(1, 1, tid + 1);
                }
                NewRowIDForHarcaEsasDeger = tid + 1;

                Table tbl4 = txtcnt.Tables.GetItem(tid + 1);
                tbl4.Columns.GetItem(1).Width = 2500;
            }

            tableCounter++;
            Table tbl2 = txtcnt.Tables.GetItem(tid + 1);
            tbl2.Columns.GetItem(1).Width = 5700;
            row = 1;
            tbl.Columns.GetItem(1).Width = 150;

            for (int i = 0; i < hesaps.Length; i++)
            {
                TDI_KOD_DOVIZ_TIP tkdt = new TDI_KOD_DOVIZ_TIP();

                if (hesaps[i].DovizId.HasValue)
                {
                    if (hesaps[i].Deger is decimal)
                    {
                        if ((decimal)hesaps[i].Deger == decimal.Zero)
                        {
                            continue;
                        }
                    }
                    if (hesaps[i].Aciklama == "ifs")
                    {
                        faizBaslama = (DateTime)hesaps[i].Deger;
                        continue;
                    }
                    if (hesaps[i].Aciklama == "ifb")
                    {
                        faizBitis = (DateTime)hesaps[i].Deger;
                        continue;
                    }

                    if (hesaps[i].Aciklama == "��lemi� Faiz" || hesaps[i].Aciklama == "Gecikme Zamm�")//YEDA� i�in gecikme zamm� kontrol edildi. MB
                    {
                        var tip = DataRepository.TDI_KOD_FAIZ_TIPProvider.GetByID(hesaps[i].FaizTip);
                        if (tip != null) fTipi = tip.FAIZ_TIP;

                        if (hesaps[i].DovizId.HasValue && hesaps[i].Deger is decimal && ((decimal)hesaps[i].Deger) != decimal.Zero)
                        {
                            if (!BelgeUtil.Inits.Enerjimi)
                                tbl.Cells.GetItem(row, 3).Text = (TarihBicimlendirme(faizBitis, true) == string.Empty ? "VadeT." : TarihBicimlendirme(faizBitis, true)) + "-" + TarihBicimlendirme(faizBaslama, true) + " Y�ll�k %" + hesaps[i].FaizOrani + " " + fTipi;//MB, i�lenmi� faiz sat�r�nda tarih aral�kalar�n�n yan�na faiz miktar� ve tipi eklendi.;
                            else //YEDA� i�in bu �ekilde yap�ld�. MB
                                tbl.Cells.GetItem(row, 3).Text = "%" + hesaps[i].FaizOrani + " 6183 Say�l� Yasa";
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (hesaps[i].Aciklama == "Takip ��k���")
                    {
                        hesaps[i].Aciklama = "Nakit Alacak";
                        tbl.Cells.GetItem(row, 2).Text = "__+_________________";
                        tbl.Cells.GetItem(row, 2).Select();
                        txtcnt.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Right;
                        row++;

                        if (IpotekAzAlacakCok)
                        {
                            SayiOkuma sa = new SayiOkuma();

                            tbl.Cells.GetItem(row + 1, 1).Text = "Gayrinakit Alacaklar";
                            if (degerler.ToplamGayrinakitAlacaklar == null)
                                tbl.Cells.GetItem(row + 1, 2).Text = sa.ParaFormatla(0) + " TL";
                            else
                                tbl.Cells.GetItem(row + 1, 2).Text = sa.ParaFormatla(degerler.ToplamGayrinakitAlacaklar.Para) + " TL";
                            tbl.Cells.GetItem(row + 1, 2).Select();
                            txtcnt.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Right;
                            tbl.Cells.GetItem(row + 2, 2).Text = "+___________________";
                            tbl.Cells.GetItem(row + 2, 2).Select();
                            txtcnt.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Right;
                            tbl.Cells.GetItem(row + 3, 1).Text = "T�m Alacaklar";
                            tbl.Cells.GetItem(row + 3, 2).Text = sa.ParaFormatla(degerler.TumAlacaklar.Para) + " TL";
                            tbl.Cells.GetItem(row + 3, 2).Select();
                            txtcnt.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Right;
                            tbl.Cells.GetItem(row + 4, 1).Text = "�pote�i A�an Alacak";
                            tbl.Cells.GetItem(row + 4, 2).Text = sa.ParaFormatla(degerler.IpotegiAsanKisim.Para) + " TL";
                            tbl.Cells.GetItem(row + 4, 2).Select();
                            txtcnt.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Right;
                            tbl.Cells.GetItem(row + 5, 2).Text = " -___________________";
                            tbl.Cells.GetItem(row + 5, 2).Select();
                            txtcnt.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Right;
                            tbl.Cells.GetItem(row + 6, 1).Text = "Takip ��k���";
                            tbl.Cells.GetItem(row + 6, 2).Text = sa.ParaFormatla(ParaVeDovizId.Cikart(degerler.TumAlacaklar, degerler.IpotegiAsanKisim).Para) + " TL";
                            tbl.Cells.GetItem(row + 6, 2).Select();
                            txtcnt.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Right;
                        }
                    }

                    string para = so.ParaFormatla(hesaps[i].Deger.ToString());

                    InsertTextField(hesaps[i].Aciklama.PadRight(25), foyid.ID, "aciklama", lstFileds, "");
                    tbl.Cells.GetItem(row, 1).Text = hesaps[i].Aciklama;
                    tbl.Cells.GetItem(row, 1).Select();
                    txtcnt.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Left;

                    tkdt = BelgeUtil.Inits.DovizIdSource(hesaps[i].DovizId.Value);
                    InsertTextField(para.PadRight(25), foyid.ID, "hesap1", lstFileds, "");
                    tbl.Cells.GetItem(row, 2).Text = para + " " + tkdt.DOVIZ_KODU;
                    tbl.Cells.GetItem(row, 2).Select();
                    txtcnt.Selection.ParagraphFormat.Alignment = TXTextControl.HorizontalAlignment.Right;
                    InsertTextField(Environment.NewLine, hesaps[i].DovizId.Value, "doviz", lstFileds, "");
                    row++;
                }
            }

            if (extrainfo.Trim() != string.Empty)
            {
                tbl.Cells.GetItem(row - 2, 3).Text = extrainfo + "bura nere";
            }

            for (int i = 1; i < tbl.Rows.Count; i++)
            {
                for (int y = 1; y < tbl.Columns.Count; y++)
                {
                    tbl.Cells.GetItem(i, y).CellFormat.LeftBorderWidth = 0;
                    tbl.Cells.GetItem(i, y).CellFormat.RightBorderWidth = 0;
                    tbl.Cells.GetItem(i, y).CellFormat.TopBorderWidth = 0;
                    tbl.Cells.GetItem(i, y).CellFormat.BottomBorderWidth = 0;
                }
            }

            if (bottomText.Trim() == "" || bottomText.Trim() == string.Empty)
            {
                txtcnt.Tables.Remove(tbl2.ID);
            }
            else
            {
                if (bottomText.StartsWith("<Aciklama>"))
                {
                    tbl2.Cells.GetItem(1, 1).Select();
                    TextField tff = new TextField("A��klama Bulunamad�...");
                    tff.Name = bottomText;
                    txtcnt.TextFields.Add(tff);
                }
                else
                {
                    if (BelgeUtil.Inits.PaketAdi == 1)
                    {
                        if (IpotekAzAlacakCok) bottomText = "alaca��n, vekalet �creti ve takip giderleri ile birlikte tahsilde tekerr�r edilmemek �zere TAHS�L�";
                        else if (foyid.FORM_TIP_ID == (int)FormTipleri.Form163)
                        {
                            if (foyid.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_ICRA_KIYMETLI_EVRAK.Count == 0)
                                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyid, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>));
                            if (foyid.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_ICRA_KIYMETLI_EVRAK.Count > 0)
                            {
                                string faizTipi = DataRepository.TDI_KOD_FAIZ_TIPProvider.GetByID(foyid.AV001_TI_BIL_ALACAK_NEDENCollection[0].TO_ALACAK_FAIZ_TIP_ID.Value).FAIZ_TIP;
                                if (foyid.AV001_TI_BIL_ALACAK_NEDENCollection[0].TO_ALACAK_FAIZ_TIP_ID.Value == 2)
                                    faizTipi += " faizi";
                                bottomText = string.Format("Alacak ile as�l alacak �zerinden {0} tarihinden itibaren i�leyecek TCMB k�sa vadeli kredilere uyglanan {2} ( bug�n itibari ile %{1} ), takip masraflar� ve avukatl�k �creti ile birlikte, k�smi �demeler �ncelikle BK.m.84 gere�ince faize mahsup edilecek �ekilde hesaplanark ve tahsilde tekerr�r edilmemek �zere, Alacakl�n�n her t�rl� fazlaya ili�kin haklar� sakl� kalarak, TAHS�L�.", foyid.TAKIP_TARIHI.Value.ToShortDateString(), foyid.AV001_TI_BIL_ALACAK_NEDENCollection[0].UYGULANACAK_FAIZ_ORANI.ToString(), faizTipi);
                            }
                        }
                        else if (foyid.FORM_TIP_ID == (int)FormTipleri.Form49)
                        {
                            if (foyid.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyid, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                            bottomText = string.Format("Tutar�ndaki alaca��n, as�l alacak k�sm�na takip tarihinden itibaren i�leyecek y�ll�k %{0} {1}, Faizin % 5 Gider Vergisi (BSMV) ile masraf ve vekalet �cretinin, tahsilde tekerr�r edilmemek ve k�smi �demeler BK.nun 84.maddesi gere�ince �ncelikle masraf, faiz ve gider vergisine mahsup edilerek TAHS�L� talebidir.", foyid.AV001_TI_BIL_ALACAK_NEDENCollection[0].UYGULANACAK_FAIZ_ORANI.ToString(), DataRepository.TDI_KOD_FAIZ_TIPProvider.GetByID(foyid.AV001_TI_BIL_ALACAK_NEDENCollection[0].TO_ALACAK_FAIZ_TIP_ID.Value).FAIZ_TIP);
                        }
                    }
                    tbl2.Cells.GetItem(1, 1).Text = bottomText;
                }
            }

            tbl.Columns.GetItem(1).Width = 1500;
            tbl.Columns.GetItem(2).Width = 2200;
            tbl.Columns.GetItem(3).Width = 2000;

            if (row <= 1)
            {
                txtcnt.Selection.Start = tbl.Cells.GetItem(row, 2).Start + tbl.Cells.GetItem(row, 2).Length;
            }
            else
            {
                if (tbl2.Cells.Count > 1 && tbl2.Cells.GetItem(1, 1) != null)
                {
                    txtcnt.Selection.Start = tbl2.Cells.GetItem(1, 1).Start + tbl2.Cells.GetItem(1, 1).Length;
                }

                txtcnt.Selection.Length = 1;
            }

            return " ";
        }

        private static string GetMetAlacakNedeniYazdir(TList<AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN> lstAlacakNedens, bool faizTipiOraniYazdir)
        {
            string returnValue = string.Empty;
            for (int i = 0; i < lstAlacakNedens.Count; i++)
            {
                if (HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(lstAlacakNedens[i])) continue;

                if (lstAlacakNedens[i].VADE_TARIHI.HasValue)
                {
                    returnValue += TarihBicimlendirme(lstAlacakNedens[i].VADE_TARIHI.Value) + " tarihli ";
                }

                SayiOkuma so = new SayiOkuma();
                returnValue += so.ParaFormatla(lstAlacakNedens[i].TUTARI.ToString()) + " ";
                returnValue += BelgeUtil.Inits.DovizIdSource(lstAlacakNedens[i].TUTAR_DOVIZ_ID.Value).DOVIZ_KODU;
                returnValue += " tutar�ndaki ";
                ///Di�er alacaksa , di�er alacaklarda alacak neden ad�n� icran�n �zerindeki alacak
                ///nedenleri i�erisindeki diger alacak alan�ndan al�r�z.
                if (lstAlacakNedens[i].ALACAK_NEDEN_KOD_IDSource != null)
                {
                    if (lstAlacakNedens[i].ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI.Contains("D��ER ALACAK"))
                    {
                        returnValue += SetWords(lstAlacakNedens[i].DIGER_ALACAK_NEDENI, WordsUpperLowerType.FirstWordFirstCharUpperOtherLower);
                    }
                    else
                    {
                        returnValue += SetWords(lstAlacakNedens[i].ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI, WordsUpperLowerType.FirstWordFirstCharUpperOtherLower);
                    }
                }
                else
                    returnValue += SetWords("", WordsUpperLowerType.FirstWordFirstCharUpperOtherLower);

                if (lstAlacakNedens[i].ALACAK_FAIZ_TIP_IDSource != null && faizTipiOraniYazdir)
                {
                    returnValue += "(" + lstAlacakNedens[i].ALACAK_FAIZ_TIP_IDSource.FAIZ_TIP + " %" + lstAlacakNedens[i].UYGULANACAK_FAIZ_ORANI.ToString() + ")";
                }

                if (lstAlacakNedens.Count > 1)
                {
                    returnValue += " , ";
                }
            }
            return returnValue;
        }

        #region <GKN-20090611>

        //TODO: Gruplama sorunu i�in ��z�m Aray���

        /// <summary>
        /// Gruplar� Yazd�rmak i�in bu nesnenin �st�nde toplayaca��z
        /// </summary>
        private static HesapGrubu HG = new HesapGrubu();

        private static bool ilamGiderleriHesaplandi = false;

        private static void ExgethesapsFromNesne(hesaplar[] hesaplar, AV001_TI_BIL_FOY foyum, TextControl txtcnt, string extraInfo, string bottomtext, bool p)
        {
            List<GruplamaAraci> grupListesi = new List<GruplamaAraci>();
            List<hesaplar> eklenemeyenlerListesi = new List<hesaplar>();

            DateTime kucukTarih = DateTime.MinValue;
            DateTime buyukTarih = DateTime.MinValue;

            // Tarihleri almak i�in d�n�yoruz
            foreach (var hesap in hesaplar)
            {
                if (hesap.Aciklama == "ifs") // Takip Tarihi
                {
                    if (hesap.Deger != null && hesap.Deger is DateTime)
                        buyukTarih = (DateTime)hesap.Deger;
                }
                else if (hesap.Aciklama == "KUCUK_TARIH") // K���k Tarih
                {
                    if (hesap.Deger != null && hesap.Deger is DateTime)
                        kucukTarih = (DateTime)hesap.Deger;
                }
            }

            foreach (var hesap in hesaplar)
            {
                if (ilamGiderleriHesaplandi && (hesap.Aciklama.Contains("�lam") || hesap.Aciklama.Contains("Bakiye Karar"))) continue;

                if (hesap.Deger is decimal)
                {
                    if ((decimal)hesap.Deger != decimal.Zero)
                    {
                        GruplamaAraci ga = new GruplamaAraci();

                        //ToDo : �zel Tutar alanlar�n�n isimlerini burada yazaca��z..  gkn

                        ga.Baslik = GetGruplanmisDegerlerBaslik(hesap.Aciklama, foyum);  //  hesap.Aciklama;

                        ga.Tutar = new ParaVeDovizId((decimal)hesap.Deger, hesap.DovizId);

                        if (hesap.AlacakNedeni != null && foyum.TAKIP_TARIHI.HasValue)
                            ga.FaizTipiOrani = FaizOraniVeTipiGetr(foyum.TAKIP_TARIHI.Value, hesap.AlacakNedeni);

                        ga.Deger = bottomtext;
                        if (hesap.Aciklama == "��lemi� Faiz") // i�lemi� faizin yan�na yazmak i�in tarihleri ekliyoruz
                        {
                            ga.KucukTarih = kucukTarih;
                            ga.BuyukTarih = buyukTarih;
                            ga.FaizOrani = faizOran;
                            ga.FaizTipi = faizTip;
                        }
                        grupListesi.Add(ga);
                    }
                }
                else
                {
                    eklenemeyenlerListesi.Add(hesap);
                }
            }

            if (HG.GrupListesi == null) HG.GrupListesi = new List<List<GruplamaAraci>>();

            if (grupListesi.Count > 0)
            {
                if (grupListesi[0].Tutar.DovizId != 1) //T�rk Liras� gruplar�n en altta g�r�nmesi i�in tl den farkl� hesaplar� en ba�a ekliyoruz
                    HG.GrupListesi.Insert(0, grupListesi);
                else
                    HG.GrupListesi.Add(grupListesi);
            }
            if (foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count == 0) DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ILAM_MAHKEMESI>));
            if (foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count > 0) ilamGiderleriHesaplandi = true;
        }

        /// <summary>
        /// ExgethesapsFromNesne i�erisinde gruplanan de�erlerin etiketlerini yazd�rmak i�in yard�mc� ara�
        /// �zel tutar alanlar�n�n etiketlerini getirmek amac� ile kullan�ld�
        /// </summary>
        /// <param name="aciklama"></param>
        /// <param name="foy"></param>
        /// <returns></returns>
        private static string GetGruplanmisDegerlerBaslik(string aciklama, AV001_TI_BIL_FOY foy)
        {
            string returnValue = string.Empty;

            switch (aciklama)
            {
                case "�zel Tutar1":
                    if (foy.OZEL_TUTAR1_KONU_ID.HasValue)
                        returnValue = HesapAraclari.Icra.OzelTutarKonuGetir(foy.OZEL_TUTAR1_KONU_ID.Value);
                    break;

                case "�zel Tutar2":
                    if (foy.OZEL_TUTAR2_KONU_ID.HasValue)
                        returnValue = HesapAraclari.Icra.OzelTutarKonuGetir(foy.OZEL_TUTAR2_KONU_ID.Value);

                    break;

                case "�zel Tutar3":
                    if (foy.OZEL_TUTAR3_KONU_ID.HasValue)
                        returnValue = HesapAraclari.Icra.OzelTutarKonuGetir(foy.OZEL_TUTAR3_KONU_ID.Value);
                    break;

                default:
                    returnValue = aciklama;
                    break;
            }
            if (returnValue == string.Empty)
                returnValue = aciklama;

            return returnValue;
        }

        private class GruplamaAraci
        {
            public string Baslik { get; set; }

            public DateTime BuyukTarih { get; set; }

            public string Deger { get; set; }

            public string FaizOrani { get; set; }

            //MB, ��lenmi� Faiz sat�r�nda faiz tipi ve oran�n�n g�sterilebilmesi i�in eklendi.
            public string FaizTipi { get; set; }

            public string FaizTipiOrani { get; set; }

            public DateTime KucukTarih { get; set; }

            public ParaVeDovizId Tutar { get; set; }

            //MB, ��lenmi� Faiz sat�r�nda faiz tipi ve oran�n�n g�sterilebilmesi i�in eklendi.
        }

        private class HesapGrubu
        {
            private List<List<GruplamaAraci>> _grupListesi;

            public List<List<GruplamaAraci>> GrupListesi
            {
                get
                {
                    if (_grupListesi == null) _grupListesi = new List<List<GruplamaAraci>>();
                    return _grupListesi;
                }
                set
                {
                    _grupListesi = value;
                }
            }
        }

        #endregion <GKN-20090611>

        /// <summary>
        /// getSozlesmeBilgisi methodundan export edilmi�tir
        /// - GKN
        /// </summary>
        /// <param name="returnValues"></param>
        /// <param name="aNedenSozlesme"></param>
        private static void getMetSozlesmeBilgisi(List<TextField> returnValues, AV001_TDI_BIL_SOZLESME aNedenSozlesme)
        {
            //string imzaTarihi = "";
            //if (aNedenSozlesme.IMZA_TARIHI.HasValue)
            //{
            //    imzaTarihi = TarihBicimlendirme(DateTime.Parse(aNedenSozlesme.IMZA_TARIHI.Value.ToString()));
            //}

            //SayiOkuma so = new SayiOkuma();
            //string SozlesmeBedeli = so.ParaFormatla(aNedenSozlesme.BEDELI.ToString());
            //SozlesmeBedeli += " " + new ParaVeDovizId(aNedenSozlesme.BEDELI, aNedenSozlesme.BEDELI_DOVIZ_ID).DovizKodu;
            //string ipotektipi = "";
            //if (aNedenSozlesme.REHIN_CINS_ANA_TURU.HasValue)
            //{
            //    if (aNedenSozlesme.REHIN_CINS_ANA_TURU.Value == 0)
            //    {
            //        ipotektipi = "Limit ipote�i";
            //    }
            //    else if (aNedenSozlesme.REHIN_CINS_ANA_TURU.Value == 1)
            //    {
            //        ipotektipi = "Ana para ipote�i";
            //    }
            //}

            ////S�zle�menin bilgileri yaz�l�yor
            //string AltTip = AvukatProLib2.Data.DataRepository.TDI_KOD_SOZLESME_ALT_TIPProvider.GetByID(aNedenSozlesme.ALT_TIP_ID.Value).ALT_TIP;
            ////InsertTextField(" - ", 0, "yazi", returnValues, "yazi");
            //InsertTextField(imzaTarihi, aNedenSozlesme.ID, "IMZA_TARIHI", returnValues, "AV001_TDI_BIL_SOZLESME");
            //InsertTextField(" tarihli ", 0, "yazi", returnValues, "yazi");
            //InsertTextField(aNedenSozlesme.SICIL_YEVMIYE_NO, aNedenSozlesme.ID, "SICIL_YEVMIYE_NO", returnValues, "AV001_TDI_BIL_SOZLESME");
            //InsertTextField(" yevmiyeli ", 0, "yazi", returnValues, "yazi");
            //InsertTextField(SozlesmeBedeli, aNedenSozlesme.ID, "BEDELI", returnValues, "AV001_TDI_BIL_SOZLESME");
            //InsertTextField(" bedelli ", 0, "yazi", returnValues, "yazi");
            //InsertTextField(AltTip, aNedenSozlesme.ID, "REHIN_CINS_ANA_TURU", returnValues, "AV001_TDI_BIL_SOZLESME");
            //if (ipotektipi.Length > 0)
            //{
            //    InsertTextField(string.Format("({0})", ipotektipi), 0, "yazi", returnValues, "yazi");
            //}

            //InsertTextField(Environment.NewLine, 0, "yazi", returnValues, "yazi");
            //InsertTextField(Environment.NewLine, 0, "yazi", returnValues, "yazi");

            //returnValues.AddRange(getaracBilgisi(aNedenSozlesme)); iptal edildi - gkn

            returnValues.AddRange(getGayrimenkulBilgisi(aNedenSozlesme));
            //InsertTextField("____________________________________________________________", 0, "yazi", returnValues, "yazi");
            //InsertTextField(Environment.NewLine, 0, "yazi", returnValues, "yazi");
        }

        private static string GetSaat(DateTime tarih)
        {
            return tarih.Hour.ToString() + " : " + tarih.Minute.ToString();
        }

        private static List<hesaplar> hesaplaraEkle(hesaplar hesap, List<List<hesaplar>> lstFarkliHesaplar, bool HesaplanmamisAlanMi)
        {
            List<string> kontrolDizisi = new List<string>(new string[] {"�zel Tutar1","�zel Tutar2","�zel Tutar3","�zel Tazminat","Hazcizde �denen","Mahsup Toplami",
"�deme Toplam�","�.H.V. �creti","�.T.V. �creti","�lam Vekalet �creti","Bakiye Karar ve Onama Harc�","�lam �nkar Tazminat�",
"�lam Yarg�lama Gideri",
"Yarg�tay Onama Harc�",
"�lam Tebli� Gideri","�.H. Gideri", "Tazminat"});

            if (hesap.DovizId == 0)
            {
                return new List<hesaplar>();
            }

            List<hesaplar> lstHesaplar = new List<hesaplar>();
            bool farklimi = true;
            bool toplandiMi = false;

            for (int i = 0; i < lstFarkliHesaplar.Count; i++)
            {
                if (lstFarkliHesaplar[i].Count >= 1)
                {
                    if (lstFarkliHesaplar[i][0].DovizId == hesap.DovizId
                    && (lstFarkliHesaplar[i][0].FaizTipOrani == hesap.FaizTipOrani))
                    {
                        if (hesap.Deger is decimal)
                            foreach (var eskisi in lstFarkliHesaplar[i])
                            {
                                if (eskisi.Deger is decimal)
                                    if (eskisi.Aciklama == hesap.Aciklama)
                                    {
                                        if (kontrolDizisi.Contains(eskisi.Aciklama))
                                        {
                                            toplandiMi = true;
                                            break;
                                        }

                                        if (!HesaplanmamisAlanMi)
                                            eskisi.Deger = (decimal)eskisi.Deger + (decimal)hesap.Deger;
                                        else
                                            eskisi.Deger = (decimal)hesap.Deger;
                                        toplandiMi = true;
                                        break;
                                    }
                            }

                        farklimi = false;
                        lstHesaplar = lstFarkliHesaplar[i];
                    }
                }
            }
            if (farklimi)
            {
                lstHesaplar = new List<hesaplar>();
                if (hesap.DovizId != 1)
                    lstFarkliHesaplar.Insert(0, lstHesaplar);
                else
                    lstFarkliHesaplar.Add(lstHesaplar);
            }
            if (!toplandiMi)
                lstHesaplar.Add(hesap);
            return lstHesaplar;
        }

        private static bool IlamiFaizliMi(AV001_TI_BIL_FOY Foy)
        {
            bool Donecek = false;

            for (int i = 0; i < Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count; i++)
            {
                if (Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].BAKIYE_KARAR_HARCI_FAIZ_ISLESIN_MI)
                {
                    Donecek = true;
                }

                if (Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].ILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI)
                { Donecek = true; }

                if (Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].ILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI)
                { Donecek = true; }

                if (Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].INKAR_TAZMINAT_FAIZ_ISLESIN_MI)
                { Donecek = true; }

                if (Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].YARGILAMA_GIDERI_FAIZ_ISLESIN_MI)
                { Donecek = true; }

                if (Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].YARGITAY_ONAMA_HARCI_FAIZ_ISLESIN_MI)
                { Donecek = true; }
            }
            return Donecek;
        }

        //public static TList<AV001_TDIE_BIL_SABLON_DEGISKENLER> TumDegiskenler = null;
        private static bool isinList(int id, List<int> lst)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i] == id)
                {
                    return true;
                }
            }
            return false;
        }

        private static MevzuatKararLib.Entities.TM_BIL_MEVZUAT_MADDE maddesiVarmi(yaslar yasa, MevzuatKararLib.Entities.TM_BIL_MEVZUAT_MADDE madde)
        {
            for (int i = 0; i < yasa.Maddeler.Count; i++)
            {
                if (yasa.Maddeler[i].ID == madde.ID)
                {
                    return yasa.Maddeler[i];
                }
            }
            yasa.Maddeler.Add(madde);

            return madde;
        }

        private static string Replace(string var, string data, object newValue)
        {
            if (data == null)
            {
                return "";
            }
            if (data.Contains(var))
            {
                return data.Replace(var, newValue.ToString());
            }
            return data;
        }

        private static string setChars(string value, CharUpperLowerType caseType)
        {
            if (value.Trim().Length <= 0)
            {
                return value;
            }
            string firstChar = value[0].ToString();
            string others = "";
            if (value.Length > 1)
            {
                others = value.Substring(1, value.Length - 1);
            }

            switch (caseType)
            {
                case CharUpperLowerType.FirstbigOthersSmal:
                    return firstChar.ToUpper() + others.ToLower();

                case CharUpperLowerType.FirstSmallOthersBig:
                    return firstChar.ToLower() + others.ToUpper();

                case CharUpperLowerType.AllBig:
                    return firstChar.ToUpper() + others.ToUpper();

                case CharUpperLowerType.AllSmall:
                    return firstChar.ToLower() + others.ToLower();

                case CharUpperLowerType.None:
                    return value;

                default:
                    return value;
            }
        }

        private static bool SozlesmeEklendimi(AV001_TDI_BIL_SOZLESME Sozlesme)
        {
            for (int i = 0; i < DosyadakiSozlesmeler.Count; i++)
            {
                if (DosyadakiSozlesmeler[i].ID == Sozlesme.ID)
                {
                    return true;
                }
            }
            DosyadakiSozlesmeler.Add(Sozlesme);
            return false;
        }

        private static string SubeGetir(short sube)
        {
            return sube.ToString();
        }

        private static TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN TalepAciklamasiGetir(AV001_TI_BIL_FOY foy)
        {
            TList<TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN> Degiskenler = AvukatProLib2.Data.DataRepository.
TDIE_KOD_TALEP_ACIKLAMA_DEGISKENProvider.GetByFORM_TIPI_ID(foy.FORM_TIP_ID.Value);
            AV001_TI_BIL_ALACAK_NEDEN silinecek = null;
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(foy.AV001_TI_BIL_ALACAK_NEDENCollection, false, DeepLoadType.IncludeChildren, typeof(TI_KOD_ALACAK_NEDEN));
            AvukatProLib2.Data.DataRepository.
TDIE_KOD_TALEP_ACIKLAMA_DEGISKENProvider.DeepLoad(Degiskenler, false, DeepLoadType.IncludeChildren, typeof(TList<TI_KOD_ALACAK_NEDEN>), typeof(TList<NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD>));
            TList<TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN> UyanDegiskenler = new TList<TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN>();
            bool YtlLi = false, Dovizli = false;

            // bUTUN dE���KENLER� DOLA�IYORUZ BU SIRADA  HESAPLAMA MODU 3
            //HESAPLAMA MODU 1 :  VAE TAR�H�NDE
            //HESAPLAMA MODU 2 :  TAK,P TAR�H�NDE
            //HESAPLAMA MODU 3 :  ODEMEE TAR�H�NDE

            for (int i = 0; i < Degiskenler.Count; i++)
            {
                //DEG�SKEN KOSULLARA UYUYORMU �LK DEGER TRUE CUNKU UYMUYORSA FALSE A CEKT�K
                bool Uyarmi = true; // kosullara uyarm� =?

                ///
                if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count > 1)
                {
                    for (int z = 1; z < foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; z++)
                    {
                        // hesplama modu bir onceki hesaplama moduna e�it de�ilse
                        if (foy.AV001_TI_BIL_ALACAK_NEDENCollection[z].HESAPLAMA_MODU != foy.AV001_TI_BIL_ALACAK_NEDENCollection[z - 1].HESAPLAMA_MODU)
                        {
                            /// odeme tarihinde ytl  her kosulda i�imizi gorur. her yoal gelir. Hem doviz hem ytl var i�inde.
                            /// bu yuzden odeme tarihinde ytl ise bundan onceki ondan daha farl�d�r. bu yuden onden oncekini silineceklere alad�k .
                            ///
                            if (foy.AV001_TI_BIL_ALACAK_NEDENCollection[z].HESAPLAMA_MODU == 3)
                            {
                                silinecek = foy.AV001_TI_BIL_ALACAK_NEDENCollection[z - 1];
                            }

                            ///eger alacak nedenleri iki ise ve bir onceki hesaplama modu odeme tarihinde ytl ise
                            ///su anki uygun de�ildir o yuzden sil gitsin die silinecekler listesiner ekledik .
                            if ((foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 2 &&
                                foy.AV001_TI_BIL_ALACAK_NEDENCollection[z - 1].HESAPLAMA_MODU == 3))
                            {
                                silinecek = foy.AV001_TI_BIL_ALACAK_NEDENCollection[z];
                            }
                        }
                    }
                }

                // S�L�NECEK B���LER VARSA HAVADA S�L
                if (silinecek != null)
                {
                    foy.AV001_TI_BIL_ALACAK_NEDENCollection.Remove(silinecek);
                }

                ///fOY ��ER�S�NDEK� TUM ALACAK NEDENLER�N� DOLASIYORUZ
                ///DOV�ZL� M� , YTL L�M� VE ALACAK NEDENLERR�NE GORE �U AN EL�M�ZDE � �LE ELDE ETT�G�M�Z
                ///DE���KEN� KONTROL ED�YORUZ .
                ///KONTROL ED�YORUZ
                for (int y = 0; y < foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; y++)
                {
                    YtlLi = (foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].ISLEME_KONAN_TUTAR_DOVIZ_ID.Value == 1);
                    Dovizli = (foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].ISLEME_KONAN_TUTAR_DOVIZ_ID.Value != 1);

                    if (Degiskenler[i].FAIZ_YOK_MU == foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].FAIZ_YOK
                        && Degiskenler[i].DOVIZ_ISLEM_TIPI == foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].HESAPLAMA_MODU
                        && ((Degiskenler[i].YTL_MI == (foy.ASIL_ALACAK_DOVIZ_ID.Value == 1)
                            && Degiskenler[i].DOVIZLI_MI == (foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].ISLEME_KONAN_TUTAR_DOVIZ_ID.Value != 1))
                        || (Degiskenler[i].YTL_MI == true
                        && Degiskenler[i].DOVIZLI_MI == true)))
                    {
                        ///ALACAK NEDENKLER� VEYA �LE BAGLI �SE (PROGRAMLAMADAK� VEYA ) VE B�RDEN FAZLA ALACAK NEDEN� �LE �L��K�L� B�R DE���KENSE
                        ///DE���KEN FOYDEK� ALACAK NEDEN�N�N ��ERM�YORSA UYARMI FALSE BU SADECE TEK B�R ALACAK NEDEN� ���N B�R KONTROLDUR
                        ///CUNKU BURADA VEYA �LE B�R BAGLILIK SOZ KONUSU .
                        if (Degiskenler[i].ALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI &&
                            Degiskenler[i].TI_KOD_ALACAK_NEDENCollection_From_NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD.Count > 1)
                        {
                            for (int j = 0; j < Degiskenler[i].TI_KOD_ALACAK_NEDENCollection_From_NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD.Count; j++)
                            {
                                if (!Degiskenler[i].TI_KOD_ALACAK_NEDENCollection_From_NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD.Contains(foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].ALACAK_NEDEN_KOD_IDSource))
                                {
                                    Uyarmi = false;
                                }
                            }
                        }

                        ///EGER B� TANE DEG�SKEN GELM��SE FOR DONGUSU FELAM YOK D�REK B�RE B�R KONTROL ED�ORUZ
                        else if (Degiskenler[i].TI_KOD_ALACAK_NEDENCollection_From_NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD.Count == 1)
                        {
                            if (foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].ALACAK_NEDEN_KOD_ID != null)
                            {
                                if (Degiskenler[i].TI_KOD_ALACAK_NEDENCollection_From_NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD[0].ID != foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].ALACAK_NEDEN_KOD_ID.Value)
                                {
                                    Uyarmi = false;
                                }
                            }
                        }

                         /// DE���KEN�N ALACAK NEDEN LER� VEYA �LE BAGLI DEG�LSE VE B�RDEN FAZLA ALACAK NEDEN� �LE �L��K�L� �SE
                        /// DE���KEN O ALACAK NEDENLER�NDEN HEDRHANG�B�R�S�N� ��ERM�YORSA KOSULA UYMAZ FAKAT BU KEZ D�REK FOY ALACAK KALEM�N�N TAGINI FALSE YAPIYORUZ
                        /// BOYLECE �LER�E B�R KONTROL DAHA YAPIP ARKADASI ORADA EGER H�� B�R �EK�LDE YOKSA S�LECEG�Z
                        else if (!Degiskenler[i].ALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI &&
                       Degiskenler[i].TI_KOD_ALACAK_NEDENCollection_From_NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD.Count > 1)
                        {
                            for (int j = 0; j < Degiskenler[i].TI_KOD_ALACAK_NEDENCollection_From_NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD.Count; j++)
                            {
                                if (!Degiskenler[i].TI_KOD_ALACAK_NEDENCollection_From_NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD.Contains(foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].ALACAK_NEDEN_KOD_IDSource))
                                {
                                    foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].Tag = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        ///H�� B��� OLMUYOSA UYMUYODURDA .
                        Uyarmi = false;
                    }
                }

                //// VE �LE BAGLAMA DURUMUNDA B�RDEN FAZLA ALACKA KALEM� �LE �L��K� SOPZ KONUSU �SE
                //// FOY DEK� ALACAK KALEMLER� ��ER�S�NDE DAHA ONCE TAG INA FLASE VERD�G�M�Z ALACAK KALEM�N� DE KONTROL ETT�K
                // FALSXE �SE BU DURUMDA BU ��LEM SONUCUDA UYMUYORDUR CUNKU VE �LE BAGLI VE BUTUN ALACAK KALEMLER� OLMA KZORUNDA.

                if (!Degiskenler[i].ALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI &&
                       Degiskenler[i].TI_KOD_ALACAK_NEDENCollection_From_NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD.Count > 1)
                {
                    for (int y = 0; y < foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; y++)
                    {
                        if (foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].Tag != null && (bool)foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].Tag == false)
                        {
                            Uyarmi = false;
                        }
                    }
                }

                /// KOSULA UYAN DEG�SKEN VARSA ONU UYAN DEG�SKENLERE AWT
                ///
                if (Uyarmi)
                {
                    UyanDegiskenler.Add(Degiskenler[i]);
                }
            }

            /// SON B�R KONTROL �LE ILAMA FAZ� ��LEM��M� VE HER AYA NAFAKA ��LEM��M� ALANLARINI DA FOY UZER�NDEK� ALANLARLAW
            /// UYAN DEG�SKEN LERDE KONTROL ED�P BU KOSULLARIDA GECENLER� SONUDE L�STES�NE ATTIK .
            TList<TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN> Sonuc = new TList<TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN>();
            if (UyanDegiskenler.Count > 1)
            {
                for (int i = 0; i < UyanDegiskenler.Count; i++)
                {
                    if (UyanDegiskenler[i].YTL_MI == YtlLi || UyanDegiskenler[i].DOVIZLI_MI == Dovizli)
                    {
                        bool uygunMu = true;
                        if (Degiskenler[i].ILAMA_FAIZ_ISLEMIS_MI.HasValue)
                        {
                            if (Degiskenler[i].ILAMA_FAIZ_ISLEMIS_MI.Value != IlamiFaizliMi(foy))
                            {
                                uygunMu = false;
                            }
                        }

                        if (Degiskenler[i].HER_AYA_NAFAKA_ISLEMIS_MI.HasValue)
                        {
                            if (foy.HER_AY_NAFAKA_EKLE != Degiskenler[i].HER_AYA_NAFAKA_ISLEMIS_MI.Value)
                            {
                                uygunMu = false;
                            }
                        }
                        if (uygunMu)
                        {
                            Sonuc.Add(UyanDegiskenler[i]);
                        }
                    }
                }
                if (Sonuc.Count >= 1)
                {
                    //// B�RDEN FAZLA SONUC VVARSA DEG�SKEN� GER�YE DONDURDUK.
                    return Sonuc[0];
                }
            }

            /// EGER DEG�SKEN UYAN DEG�SKENLERE EKLENM��SE S�LME ��LEM�NE DEGEREK YOK
            /// CUNKU HER HALUKARDA EKLENM� DURUMDA BU DURUMDA S�L�NECEG� ESK� YER�NE GER� KOYDUK :d
            /// VE UYAN DEG�SKENLERDEN B�R�NC�S�N� GER� VERD�K .
            if (UyanDegiskenler.Count >= 1)
            {
                if (silinecek != null)
                {
                    foy.AV001_TI_BIL_ALACAK_NEDENCollection.Add(silinecek);
                }
                return UyanDegiskenler[0];
            }

            /// ZATEN B�R DEG�SKEN BU KOSULLARA UYMAMISSA S�L G�TS�N BELK� OLE KONTROL ED�NCE UYAR. :
            if (silinecek != null)
            {
                foy.AV001_TI_BIL_ALACAK_NEDENCollection.Add(silinecek);
            }

            // NBB��� BULAZMAZSA BURAYA GEL�R�Z. :
            return DataRepository.TDIE_KOD_TALEP_ACIKLAMA_DEGISKENProvider.GetByID(306);  //new TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN();
        }

        private static List<TextField> TemsilNoterBilgisi(AV001_TDI_BIL_TEMSIL temsil)
        {
            List<TextField> returnValues = new List<TextField>();

            if (temsil.ADLI_BIRIM_ADLIYE_ID.HasValue)
            {
                InsertTextField(temsil.ADLI_BIRIM_ADLIYE_IDSource.ADLIYE, temsil.ID, "ADLI_BIRIM_ADLIYE_ID", returnValues, "AV001_TDI_BIL_TEMSIL");
            }
            if (temsil.ADLI_BIRIM_NO_ID.HasValue)
            {
                InsertTextField(temsil.ADLI_BIRIM_NO_IDSource.NO, temsil.ID, "ADLI_BIRIM_NO_ID", returnValues, "AV001_TDI_BIL_TEMSIL");
            }
            if (temsil.ADLI_BIRIM_GOREV_ID.HasValue)
            {
                InsertTextField(temsil.ADLI_BIRIM_GOREV_IDSource.GOREV, temsil.ID, "ADLI_BIRIM_GOREV_ID", returnValues, "AV001_TDI_BIL_TEMSIL");
            }

            if (temsil.ADLI_BIRIM_GOREV_ID.HasValue)
            {
                InsertTextField(temsil.ADLI_BIRIM_GOREV_IDSource.GOREV, temsil.ID, "ADLI_BIRIM_GOREV_ID", returnValues, "AV001_TDI_BIL_TEMSIL");
            }

            if (temsil.TARIHI.HasValue)
            {
                InsertTextField(temsil.TARIHI.Value.ToString(), temsil.ID, "AV001_TDI_BIL_TEMSIL", returnValues, "AV001_TDI_BIL_TEMSIL");
            }

            return returnValues;
        }

        private static List<TextField> TemsilYetkiBilgisi(AV001_TDI_BIL_TEMSIL temsil)
        {
            List<TextField> returnValues = new List<TextField>();

            if (temsil.AHZU_KABZ_VAR_MI)
            {
                InsertTextField("Ahzu Kabze", temsil.ID, "AHZU_KABZ_VAR_MI", returnValues, "AV001_TDI_BIL_TEMSIL");
            }
            if (temsil.TEVKIL_VAR_MI)
            {
                InsertTextField("Tevkile", temsil.ID, "AHZU_KABZ_VAR_MI", returnValues, "AV001_TDI_BIL_TEMSIL");
            }
            if (temsil.FERAGAT_VAR_MI)
            {
                InsertTextField("Feragate", temsil.ID, "FERAGAT_VAR_MI", returnValues, "AV001_TDI_BIL_TEMSIL");
            }
            if (temsil.KABUL_VAR_MI)
            {
                InsertTextField("Kabule", temsil.ID, "KABUL_VAR_MI", returnValues, "AV001_TDI_BIL_TEMSIL");
            }
            if (temsil.SULH_VAR_MI)
            {
                InsertTextField("Sulhe", temsil.ID, "SULH_VAR_MI", returnValues, "AV001_TDI_BIL_TEMSIL");
            }

            return returnValues;
        }

        private static List<TextField> TemsilYevmiyeBilgisi(AV001_TDI_BIL_TEMSIL temsil)
        {
            List<TextField> returnValues = new List<TextField>();

            InsertTextField(temsil.YEVMIYE, temsil.ID, "YEVMIYE", returnValues, "AV001_TDI_BIL_TEMSIL");
            if (temsil.TARIHI.HasValue)
            {
                InsertTextField(temsil.TARIHI.Value.ToString(), temsil.ID, "YEVMIYE", returnValues, "AV001_TDI_BIL_TEMSIL");
            }

            return returnValues;
        }

        private static void ToplamlariHesapla(List<List<hesaplar>> lstFarkliHesaplar, AV001_TI_BIL_FOY foy)
        {
            decimal toplam = decimal.Zero;
            bool ilamHesaplandi = false;
            int doviztipi = 0;
            for (int i = 0; i < lstFarkliHesaplar.Count; i++)
            {
                toplam = decimal.Zero;
                for (int y = 0; y < lstFarkliHesaplar[i].Count; y++)
                {
                    if (ilamHesaplandi && (lstFarkliHesaplar[i][y].Aciklama.Contains("�lam") || lstFarkliHesaplar[i][y].Aciklama.Contains("Bakiye Karar"))) continue;
                    doviztipi = lstFarkliHesaplar[i][y].DovizId.Value;
                    if (lstFarkliHesaplar[i][y].Deger is decimal)
                    {
                        toplam += (decimal)lstFarkliHesaplar[i][y].Deger;
                    }
                    if (lstFarkliHesaplar[i][y].Deger is double)
                    {
                        toplam += decimal.Parse(lstFarkliHesaplar[i][y].Deger.ToString());
                    }
                    if (lstFarkliHesaplar[i][y].Deger is int)
                    {
                        toplam += (int)lstFarkliHesaplar[i][y].Deger;
                    }
                }
                if (foy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ILAM_MAHKEMESI>));
                if (foy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count > 0) ilamHesaplandi = true;
                lstFarkliHesaplar[i].Add(new hesaplar(doviztipi, toplam, "Takip ��k���"));
            }
        }

        #region textcontrols

        private static int tableCounter = 0;

        private static TextControl tcntAraci = new TextControl();

        private static void GetTextField(string value, List<TextField> tf, string text)
        {
            for (int i = 0; i < tf.Count; i++)
            {
                if (tf[i].Text == text)
                {
                    tf[i].Text = value;
                }
            }
        }

        private static void GetTextField(List<TextField> tf, List<TextField> textFields, string text)
        {
            for (int i = 0; i < tf.Count; i++)
            {
                if (tf[i].Text == text)
                {
                    for (int y = 0; y < textFields.Count; y++)
                    {
                        tf.Add(textFields[y]);
                    }
                }
            }
        }

        private static void InsertTextField(string yazi, int id, string name, List<TextField> lstfields, string Tablo)
        {
            TextField tf = new TextField();
            tf.ID = id;
            tf.Text = yazi;
            tf.Name = name;
            tf.DoubleClickEvent = true;
            tf.DoubledInputPosition = true;
            tf.Deleteable = true;
            tf.ShowActivated = true;

            lstfields.Add(tf);
        }

        #endregion textcontrols

        #region yasalar

        private static List<yaslar> lstYasalar = new List<yaslar>();

        private static yaslar FindInYasalar(MevzuatKararLib.Entities.TM_BIL_MEVZUAT yasa)
        {
            for (int i = 0; i < lstYasalar.Count; i++)
            {
                if (lstYasalar[i].Yasa.ID == yasa.ID)
                {
                    return lstYasalar[i];
                }
            }
            yaslar yl = new yaslar();
            yl.Yasa = yasa;
            yl.YasaAdi = yasa.YASA_ADI;
            yl.YasaId = yasa.ID;
            lstYasalar.Add(yl);
            return yl;
        }

        #endregion yasalar

        #region degiskenDiger��lemler

        //private static object ListedenDegerAl(IList l)
        //{
        //    if (l.Count == 0)
        //    {
        //        VarInfo vv = new VarInfo();
        //        vv.Value = " ";

        //        return vv;
        //    }
        //    else
        //    {
        //        return l[0];
        //    }
        //}

        public static TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> Muhataplar = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();

        private static trf[] tarafOnEk = new trf[]
            {
                  new trf("VEK�L",VarTypes.Dava),
                new trf("VEK�L",VarTypes.Icra),
                new trf("VEK�L",VarTypes.Rucu),
                new trf("VEK�L",VarTypes.Hazirlik),
             new trf("VEK�L",VarTypes.Sozlesme),
            };

        private static trf[] trflar = new trf[]
        {
               new trf("DAVA_EDEN",VarTypes.Dava),
               new trf("DAVA_ED�LEN",VarTypes.Dava),
               new trf("TAK�P_EDEN",VarTypes.Icra),
               new trf("TAK�P_ED�LEN",VarTypes.Icra),
               new trf("R�CU_ED�LEN",VarTypes.Rucu),
               new trf("R�CU_EDEN",VarTypes.Rucu),
              new trf("DAVA_EDEN",VarTypes.Sozlesme),
               new trf("DAVA_ED�LEN",VarTypes.Sozlesme),
        };

        public static string GetFormOrnekNumarasi(AV001_TI_BIL_FOY myFoy)
        {
            if (myFoy != null)
            {
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myFoy, false, DeepLoadType.IncludeChildren, typeof(TI_KOD_FORM_TIP));
            }
            if (myFoy.FORM_TIP_ID.HasValue)
            {
                return myFoy.FORM_TIP_IDSource.FORM_ORNEK_NO;
            }

            return "�rnek No Girilmemi�";
        }

        public static DegiskenDegeri GetFromCariBilgileri(AV001_TI_BIL_FOY foyum, bool borclunun, string template, string ayirac, params string[] fields)
        {
            DegiskenDegeri returnValue = new DegiskenDegeri();
            returnValue.DonusTipi = DegiskenResulTType.String;
            /// returnValue.Degisken=degisken;
            string sonuc = "";
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));

            for (int i = 0; i < foyum.AV001_TI_BIL_FOY_TARAFCollection.Count; i++)
            {
                if (borclunun && foyum.AV001_TI_BIL_FOY_TARAFCollection[i].TAKIP_EDEN_MI)
                {
                    sonuc += SetTemplate(template, foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource, fields) + ayirac;
                }
                else
                {
                    sonuc += SetTemplate(template, foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource, fields) + ayirac;
                }
            }
            returnValue.Icerik = sonuc;

            return returnValue;
        }

        public static string GetFromCariKimlikBilgisi(string fieldName, string decription, AV001_TI_BIL_FOY foym, bool borclunun)
        {
            string returnValue = "";
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foym, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));

            for (int i = 0; i < foym.AV001_TI_BIL_FOY_TARAFCollection.Count; i++)
            {
                if (borclunun && foym.AV001_TI_BIL_FOY_TARAFCollection[i].TAKIP_EDEN_MI)
                {
                    returnValue += GetFromCariKimlikBilgisi(fieldName, decription, foym.AV001_TI_BIL_FOY_TARAFCollection[i], borclunun);
                }
                else
                {
                    returnValue += GetFromCariKimlikBilgisi(fieldName, decription, foym.AV001_TI_BIL_FOY_TARAFCollection[i], borclunun);
                }
            }
            return returnValue;
        }

        public static string GetFromCariKimlikBilgisi(string fieldName, string decription, AV001_TI_BIL_FOY_TARAF taraf, bool borclunun)
        {
            string returnValue = "";
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(taraf, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(taraf.CARI_IDSource, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
            for (int y = 0; y < taraf.CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection.Count; y++)
            {
                if (fieldName == "MEDENI_HAL")
                {
                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARI_KIMLIKProvider.DeepLoad(taraf.CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[y], false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_MEDENI_HAL));
                    returnValue += taraf.CARI_IDSource.AD + "(" + decription + " " + Datas.TablesColumn.TablesColumnData.GetColumnValueByNameFromRecord(taraf.CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[y].MEDENI_HAL_IDSource, fieldName).Value.ToString() + "),";
                }
                else
                {
                    if (Datas.TablesColumn.TablesColumnData.GetColumnValueByNameFromRecord(taraf.CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[y], fieldName).Value != null)
                    {
                        returnValue += taraf.CARI_IDSource.AD + "(" + decription + " " +
                            Datas.TablesColumn.TablesColumnData.GetColumnValueByNameFromRecord(taraf.CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[y], fieldName).Value.ToString() + "),";
                    }
                }
            }
            return returnValue;
        }

        public static DegiskenDegeri GetHacizIhbarnamesiBorcluBilgisi(AV001_TI_BIL_FOY myFoy)
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));
            DegiskenDegeri returnValue = new DegiskenDegeri();
            returnValue.DonusTipi = DegiskenResulTType.String;
            returnValue.Degisken = DegiskenHelper.GetDegiskenByAd("Icra_Haciz_Ihbarnamesi_Borclu_Bilgisi");

            TList<AV001_TI_BIL_FOY_TARAF> lstTaraflar = new TList<AV001_TI_BIL_FOY_TARAF>();

            for (int i = 0; i < myFoy.AV001_TI_BIL_FOY_TARAFCollection.Count; i++)
            {
                if (!myFoy.AV001_TI_BIL_FOY_TARAFCollection[i].TAKIP_EDEN_MI)
                {
                    lstTaraflar.Add(myFoy.AV001_TI_BIL_FOY_TARAFCollection[i]);
                }
            }

            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                if (lstTaraflar.Count > 1)
                {
                    returnValue.Icerik += (i + 1).ToString();
                }
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(lstTaraflar[i], false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                returnValue.Icerik += lstTaraflar[i].CARI_IDSource.AD;
                returnValue.Icerik += Environment.NewLine;
            }

            return returnValue;
        }

        public static DegiskenDegeri GetHacizIhbarnamesiUcuncuSahis(AV001_TI_BIL_FOY myFoy, AV001_TDI_BIL_TEBLIGAT_MUHATAP tebligatmuhatab)
        {
            //if (tebligat==null)
            //{
            //    tebligat = myFoy.AV001_TDI_BIL_TEBLIGATCollection;
            //}

            //if (altCariler==null)
            //{
            //    frmUcuncuSahisBilgileri frmUcuncuSahis = new frmUcuncuSahisBilgileri();
            //    frmUcuncuSahis.ShowDialog();
            //    altCariler = frmUcuncuSahis.SeciliCariler;
            //}

            //if (altCariler.Count==0)
            //{
            //    DialogResult dr= MessageBox.Show("h'. ucuncu sah's bulunamadi Se.mek 'sterm's'n'z _ ","ddasdasd", MessageBoxButtons.YesNo);
            //    frmUcuncuSahisBilgileri frmUcuncuSahis = new frmUcuncuSahisBilgileri();
            //    frmUcuncuSahis.ShowDialog();
            //    altCariler = frmUcuncuSahis.SeciliCariler;
            //}

            //if (tebligat.Count==0)
            //{
            //    tebligat.Add(new AV001_TDI_BIL_TEBLIGAT());
            //}

            DegiskenDegeri returnValue = new DegiskenDegeri();
            returnValue.DonusTipi = DegiskenResulTType.String;
            returnValue.Degisken = DegiskenHelper.GetDegiskenByAd("Icra_Ucuncu_Sahislar");

            //returnValue.Icerik += "<table><tr><td> ���nc� ki�inin , ad�, soyad� , �nvan�</td> <td>Adres Detay�</td><td>�l�e  - �l </td></tr>";

            //for (int z = 0; z < tebligat.Count; z++)
            //{
            //    for (int y = 0; y < altCariler.Count; y++)
            //    {
            //        for (int i = 0; i < altCariler[y].AltindakiCariler.Count; i++)
            //        {
            //   AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARI_ALTProvider.DeepLoad(altCariler[y].AltindakiCariler[i], false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE));
            //  AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatap = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();
            //  muhatap.CARI_ALT_ID = altCariler[y].AltindakiCariler[i].ID;
            //     muhatap.MUHATAP_CARI_ID = altCariler[y].Cari.ID;
            //    tebligat[z].AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Add(muhatap);
            //returnValue.Icerik += "<tr><td>";
            //returnValue.Icerik += altCariler[y].AltindakiCariler[i].AD + " " + altCariler[y].AltindakiCariler[i].UNVAN_1;
            //returnValue.Icerik += "</td><td>";
            //returnValue.Icerik += altCariler[y].AltindakiCariler[i].ADRES_1;
            //returnValue.Icerik += "</td><td>";
            //if (altCariler[y].AltindakiCariler[i].IL_ID.HasValue)
            //{
            //    returnValue.Icerik += altCariler[y].AltindakiCariler[i].IL_IDSource.IL + "-" + altCariler[y].AltindakiCariler[i].ILCE_IDSource.ILCE;
            //}
            //returnValue.Icerik += "</td></tr>";
            //        }
            //    }
            //}

            //------------------------------------
            if (tebligatmuhatab != null)
            {
                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.DeepLoad(tebligatmuhatab, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(AV001_TDI_BIL_CARI_ALT));
                if (tebligatmuhatab.CARI_ALT_ID.HasValue)
                {
                    ///   returnValue.Icerik += "<tr><td>";
                    returnValue.Icerik += tebligatmuhatab.CARI_ALT_IDSource.UNVAN_1 + tebligatmuhatab.CARI_ALT_IDSource.AD + Environment.NewLine;
                    //      returnValue.Icerik += "</td><td>";
                    returnValue.Icerik += tebligatmuhatab.CARI_ALT_IDSource.ADRES_1;
                    /// returnValue.Icerik += "</td><td>";
                    ///

                    if (tebligatmuhatab.CARI_ALT_IDSource.IL_ID.HasValue)
                    {
                        tebligatmuhatab.CARI_ALT_IDSource.IL_IDSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILProvider.GetByID(tebligatmuhatab.CARI_ALT_IDSource.IL_ID.Value);
                        tebligatmuhatab.CARI_ALT_IDSource.ILCE_IDSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILCEProvider.GetByID(tebligatmuhatab.CARI_ALT_IDSource.ILCE_ID.Value);

                        returnValue.Icerik += tebligatmuhatab.CARI_ALT_IDSource.IL_IDSource.IL + "-" + tebligatmuhatab.CARI_ALT_IDSource.ILCE_IDSource.ILCE;
                    }

                    // returnValue.Icerik += "</td></tr>";
                }
                else
                {
                    // returnValue.Icerik += "<tr><td>";
                    returnValue.Icerik += tebligatmuhatab.MUHATAP_CARI_IDSource.UNVAN_1 + " " + tebligatmuhatab.MUHATAP_CARI_IDSource.AD + Environment.NewLine;
                    //   returnValue.Icerik += "</td><td>";
                    returnValue.Icerik += tebligatmuhatab.MUHATAP_CARI_IDSource.ADRES_1;
                    //   returnValue.Icerik += "</td><td>";
                    if (tebligatmuhatab.MUHATAP_CARI_IDSource.IL_ID.HasValue)
                    {
                        returnValue.Icerik += string.Format("{0}-{1}"
                            , tebligatmuhatab.MUHATAP_CARI_IDSource.IL_IDSource.IL
                            , tebligatmuhatab.MUHATAP_CARI_IDSource.ILCE_IDSource.ILCE);
                    }

                    /// returnValue.Icerik += "</td></tr>";
                }

                ///     returnValue.Icerik += "</table>";
            }
            return returnValue;
        }

        public static string GetIcraAs�lAlacak(AV001_TI_BIL_FOY myFoy)
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myFoy, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_DOVIZ_TIP));
            return myFoy.ASIL_ALACAK.ToString() + " " + myFoy.ASIL_ALACAK_DOVIZ_IDSource.DOVIZ_KODU;
        }

        public static DegiskenDegeri GetIcraFoyFieldValues(AV001_TI_BIL_FOY foyum, string template, params string[] fields)
        {
            DegiskenDegeri returnValue = new DegiskenDegeri();
            returnValue.DonusTipi = DegiskenResulTType.String;
            // returnValue.Degisken=degisken;
            returnValue.Icerik = SetTemplate(template, foyum, fields);
            return returnValue;
        }

        public static string GetIcraKalanTutar(AV001_TI_BIL_FOY foy)
        {
            ParaVeDovizId para = new ParaVeDovizId();
            para = ParaVeDovizId.Topla(new ParaVeDovizId(foy.KALAN, foy.KALAN_DOVIZ_ID), new ParaVeDovizId(foy.GAYRI_NAKIT_KALAN, foy.GAYRI_NAKIT_KALAN_DOVIZ_ID));
            SayiOkuma so = new SayiOkuma();
            return so.ParaFormatla(para.Para) + " " + para.DovizKodu;
        }

        public static string GetIcraKiraTahliyeTarihi(AV001_TI_BIL_FOY myFoy)
        {
            return myFoy.TAHLIYE_TARIHI.Value.ToString();
        }

        public static string GetIcraPostaPulu(AV001_TI_BIL_FOY myFoy)
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myFoy, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_DOVIZ_TIP));
            return myFoy.ILK_TEBLIGAT_GIDERI.ToString() + " " + myFoy.ILK_TEBLIGAT_GIDERI_DOVIZ_IDSource.DOVIZ_KODU + " de�erindeki Posta Pulu.";
        }

        public static DegiskenDegeri GetNufusBilgiliTaraf(AV001_TI_BIL_FOY foyum, bool borclunun)
        {
            DegiskenDegeri returnValue = new DegiskenDegeri();
            returnValue.DonusTipi = DegiskenResulTType.String;
            //returnValue.Degisken = degiskenim;
            string sonuc = "";
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));

            for (int i = 0; i < foyum.AV001_TI_BIL_FOY_TARAFCollection.Count; i++)
            {
                if (!borclunun && foyum.AV001_TI_BIL_FOY_TARAFCollection[i].TAKIP_EDEN_MI)
                {
                    AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(foyum.AV001_TI_BIL_FOY_TARAFCollection, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE), typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARI_KIMLIKProvider.DeepLoad(foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE), typeof(TDI_KOD_ULKE));

                    sonuc += foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AD + Environment.NewLine;

                    //  sonuc += " "+foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.IL_IDSource.IL;

                    if (foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection.Count > 0)
                    {
                        sonuc += "T.C. No :" + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].TC_KIMLIK_NO + " " +
                            "Baba Ad� :" + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].BABA_ADI + " " +
                            "Ana Ad� :" + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].ANA_ADI + " ";
                        if (foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_IL_IDSource != null)
                        {
                            sonuc += "�l : " + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_IL_IDSource.IL + " ";
                        }
                        if (foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_ILCE_IDSource != null)
                        {
                            sonuc += "�l�e :" + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_ILCE_IDSource.ILCE;
                        }
                        if (foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_MAHALLE_KOY.Length > 0)
                            sonuc += " Mahalle :" + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_MAHALLE_KOY + " ";
                        if (foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_YERI.Length > 0)
                            sonuc += " Do�um Yeri :" + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_YERI + " ";
                        if (foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_TARIHI.HasValue)
                        {
                            sonuc += "Do�um Tarihi :" + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_TARIHI.Value.ToShortDateString() + " ";
                        }
                        if (foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_CILT_NO.Length > 0)
                            sonuc += "Cilt No :" + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_CILT_NO + " ";
                        if (foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_AILE_SIRA_NO.Length > 0)
                            sonuc += "Aile S�ra No :" + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_AILE_SIRA_NO + Environment.NewLine;
                    }

                    //                sonuc += GetCariIlIlce(foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource, degiskenim, ilmi, ilcemi).Icerik;
                }
                else if (borclunun && !foyum.AV001_TI_BIL_FOY_TARAFCollection[i].TAKIP_EDEN_MI)
                {
                    AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(foyum.AV001_TI_BIL_FOY_TARAFCollection, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE), typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARI_KIMLIKProvider.DeepLoad(foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE), typeof(TDI_KOD_ULKE));

                    sonuc += foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AD + Environment.NewLine;

                    if (foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection.Count >= 1)
                    {
                        sonuc += "T.C. No : " + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].TC_KIMLIK_NO + " " +
                            "Baba Ad� :" + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].BABA_ADI + " " +
                            "Ana Ad� :" + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].ANA_ADI + " ";
                        if (foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_IL_IDSource != null)
                        {
                            sonuc += "�l : " + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_IL_IDSource.IL + " ";
                        }
                        if (foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_ILCE_IDSource != null)
                        {
                            sonuc += " �l�e :" + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_ILCE_IDSource.ILCE;
                        }
                        if (foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_MAHALLE_KOY.Length > 0)
                            sonuc += " Mahalle :" + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_MAHALLE_KOY + " ";
                        if (foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_YERI.Length > 0)
                            sonuc += " Do�um Yeri :" + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_YERI + " ";
                        if (foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_TARIHI.HasValue)
                        {
                            sonuc += "Do�um Tarihi :" + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].DOGUM_TARIHI.Value.ToShortDateString() + " ";
                        }
                        if (foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_CILT_NO.Length > 0)
                            sonuc += "Cilt No :" + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_CILT_NO + " ";
                        if (foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_AILE_SIRA_NO.Length > 0)
                            sonuc += "Aile S�ra No :" + foyum.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0].NKO_AILE_SIRA_NO + Environment.NewLine;
                    }
                }
            }
            returnValue.Icerik = sonuc;
            return returnValue;
        }

        public static DegiskenDegeri GetTebligatListesi(AV001_TI_BIL_FOY myFoy)
        {
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.DeepLoad(Muhataplar, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_TEBLIGAT));

            List<MuhatapGruplar> LstMuhs = new List<MuhatapGruplar>();

            for (int i = 0; i < Muhataplar.Count; i++)
            {
                MuhatalariAyarla(LstMuhs, Muhataplar[i]);
            }

            DegiskenDegeri returnValue = new DegiskenDegeri();
            returnValue.DonusTipi = DegiskenResulTType.HTML;
            returnValue.Degisken = DegiskenHelper.GetDegiskenByAd("Icra_TEbligat_Listesi");

            for (int y = 0; y < LstMuhs.Count; y++)
            {
                returnValue.Icerik += "<table>" + "<tr><td>" + "��kan Mercii : " + LstMuhs[y
].GetMudurluk() + "</td></tr>" + "</table>";
                returnValue.Icerik += "<table>";

                returnValue.Icerik += "<tr>";

                returnValue.Icerik += "<td>";
                returnValue.Icerik += "S.No";
                returnValue.Icerik += "</td>";

                returnValue.Icerik += "<td>";
                returnValue.Icerik += "Dosya No";
                returnValue.Icerik += "</td>";

                returnValue.Icerik += "<td>";
                returnValue.Icerik += "Taah�t No";
                returnValue.Icerik += "</td>";

                returnValue.Icerik += "<td>";
                returnValue.Icerik += "Muhatab";
                returnValue.Icerik += "</td>";

                returnValue.Icerik += "<td>";
                returnValue.Icerik += "G.Yer";
                returnValue.Icerik += "</td>";

                returnValue.Icerik += "<td>";
                returnValue.Icerik += "�cret";
                returnValue.Icerik += "</td>";

                returnValue.Icerik += "</tr>";

                for (int i = 0; i < LstMuhs[y].Muhataplar.Count; i++)
                {
                    string muhatabAdSoyad = "";
                    string muhatabYer = "";
                    SayiOkuma so = new SayiOkuma();
                    string tutar = so.ParaFormatla(LstMuhs[y].Muhataplar[i].TEBLIGAT_IDSource.POSTA_GIDERI);
                    if (LstMuhs[y].Muhataplar[i].CARI_ALT_ID.HasValue)
                    {
                        muhatabAdSoyad = LstMuhs[y].Muhataplar[i].CARI_ALT_IDSource.AD;
                        muhatabYer = LstMuhs[y].Muhataplar[i].CARI_ALT_IDSource.ADRES_1;
                    }
                    else
                    {
                        muhatabAdSoyad = LstMuhs[y].Muhataplar[i].MUHATAP_CARI_IDSource.AD;
                        muhatabYer = LstMuhs[y].Muhataplar[i].MUHATAP_CARI_IDSource.ADRES_1;
                    }

                    returnValue.Icerik += "<tr>";

                    returnValue.Icerik += "<td>";
                    returnValue.Icerik += i.ToString();
                    returnValue.Icerik += "</td>";

                    returnValue.Icerik += "<td>";
                    returnValue.Icerik += LstMuhs[y].Muhataplar[i].TEBLIGAT_IDSource.TEBLIGAT_ESAS_NO;
                    returnValue.Icerik += "</td>";

                    returnValue.Icerik += "<td>";
                    returnValue.Icerik += LstMuhs[y].Muhataplar[i].LISTE_NO;
                    returnValue.Icerik += "</td>";

                    returnValue.Icerik += "<td>";
                    returnValue.Icerik += muhatabAdSoyad;
                    returnValue.Icerik += "</td>";

                    returnValue.Icerik += "<td>";
                    returnValue.Icerik += muhatabYer;
                    returnValue.Icerik += "</td>";

                    returnValue.Icerik += "<td>";
                    returnValue.Icerik += tutar;
                    returnValue.Icerik += "</td>";

                    returnValue.Icerik += "</tr>";
                }

                returnValue.Icerik += "</table>";
            }

            return returnValue;
        }

        public static void MuhatalariAyarla(List<MuhatapGruplar> muhataps, AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatap)
        {
            MuhatapGruplar m = new MuhatapGruplar();
            for (int i = 0; i < muhataps.Count; i++)
            {
                if (muhataps[i].Adliye == muhatap.TEBLIGAT_IDSource.ADLI_BIRIM_ADLIYE_ID &&
                    muhataps[i].Gorev == muhatap.TEBLIGAT_IDSource.ADLI_BIRIM_GOREV_ID &&
                    muhataps[i].No == muhatap.TEBLIGAT_IDSource.ADLI_BIRIM_NO_ID
                    )
                {
                    m = muhataps[i];
                }
            }

            m.Muhataplar.Add(muhatap);
            m.Adliye = muhatap.TEBLIGAT_IDSource.ADLI_BIRIM_ADLIYE_ID;
            m.Gorev = muhatap.TEBLIGAT_IDSource.ADLI_BIRIM_GOREV_ID;
            m.No = muhatap.TEBLIGAT_IDSource.ADLI_BIRIM_NO_ID;
            if (m.Muhataplar.Count < 0)
            {
                muhataps.Add(m);
            }
        }

        public static string SetTemplate(string Template, IEntity record, params string[] fields)
        {
            string sonuc = Template;
            for (int i = 0; i < fields.Length; i++)
            {
                object deger = TablesColumnData.GetColumnValueByNameFromRecord(record, fields[i]).Value;

                sonuc = sonuc.Replace(fields[i], deger.ToString());
            }
            return sonuc;
        }

        #endregion degiskenDiger��lemler

        #region <MB-20100607>

        //��lenmi� Faiz sat�r�nda faiz tipi ve oran�n�n g�sterilebilmesi i�in eklendi.
        private static string faizOran = string.Empty;

        private static string faizTip = string.Empty;

        #endregion <MB-20100607>

        #region <MB-20100610>

        // Takip Talebinde Alacak, ipotek s�zle�me limiti bedelinden b�y�kse ��kan hesaplarda limit ipotek s�zle�mesi de�erini veren metod.

        public static ParaVeDovizId LimitIpotekliSozlesmeBedeli(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
        {
            ParaVeDovizId sozlesmeBedeli = null;
            List<TextField> returnValues = new List<TextField>();
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
            TList<AV001_TI_BIL_ALACAK_NEDEN> lstAlacakNedens = foyum.AV001_TI_BIL_ALACAK_NEDENCollection;
            int formOrnekNo = Convert.ToInt32(AvukatProLib2.Data.DataRepository.TI_KOD_FORM_TIPProvider.GetByID(foyum.FORM_TIP_ID.Value).FORM_ORNEK_NO);
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(lstAlacakNedens, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_SOZLESME>));

            //Toplam alan�n� yazd�rmak i�in Yaz�d�rd���m�z s�zle�meleri bunun �zerine ekleyece�iz
            List<AV001_TDI_BIL_SOZLESME> yazdirilanSozlesmeler = new List<AV001_TDI_BIL_SOZLESME>();

            for (int i = 0; i < lstAlacakNedens.Count; i++)
            {
                var aNeden = lstAlacakNedens[i];
                TList<AV001_TDI_BIL_SOZLESME> lstAlacakNedenSozlesme = aNeden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW;
                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(lstAlacakNedenSozlesme, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_SOZLESME), typeof(TList<AV001_TI_BIL_GAYRIMENKUL>), typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE));
                for (int y = 0; y < lstAlacakNedenSozlesme.Count; y++)
                {
                    var aNedenSozlesme = lstAlacakNedenSozlesme[y];

                    getMetSozlesmeBilgisi(returnValues, aNedenSozlesme);
                    yazdirilanSozlesmeler.Add(aNedenSozlesme);
                }
            }

            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TList<NN_ICRA_SOZLESME>));

            AvukatProLib2.Data.DataRepository.NN_ICRA_SOZLESMEProvider.DeepLoad(foyum.NN_ICRA_SOZLESMECollection, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_SOZLESME));//, typeof(TList<AV001_TI_BIL_GAYRIMENKUL>), typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE));

            foreach (var sozlesme in foyum.NN_ICRA_SOZLESMECollection)
            {
                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(sozlesme.SOZLESME_IDSource, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_SOZLESME), typeof(TList<AV001_TI_BIL_GAYRIMENKUL>), typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE));

                getMetSozlesmeBilgisi(returnValues, sozlesme.SOZLESME_IDSource);
                yazdirilanSozlesmeler.Add(sozlesme.SOZLESME_IDSource);
            }

            Dictionary<int, List<ParaVeDovizId>> paralarinSozlugu = new Dictionary<int, List<ParaVeDovizId>>();

            List<ParaVeDovizId> sozlesmelerinBedelleri = new List<ParaVeDovizId>();

            foreach (var sozlesme in yazdirilanSozlesmeler) //toplam almak i�in bedelleri listeye ekledik
            {
                if (paralarinSozlugu.ContainsKey(sozlesme.BEDELI_DOVIZ_ID.Value))
                {
                    if (paralarinSozlugu[sozlesme.BEDELI_DOVIZ_ID.Value] == null) paralarinSozlugu[sozlesme.BEDELI_DOVIZ_ID.Value] = new List<ParaVeDovizId>();

                    paralarinSozlugu[sozlesme.BEDELI_DOVIZ_ID.Value].Add(new ParaVeDovizId(sozlesme.BEDELI, sozlesme.BEDELI_DOVIZ_ID, foyum.TAKIP_TARIHI));
                }
                else
                {
                    paralarinSozlugu.Add(sozlesme.BEDELI_DOVIZ_ID.Value, new List<ParaVeDovizId>());
                    paralarinSozlugu[sozlesme.BEDELI_DOVIZ_ID.Value].Add(new ParaVeDovizId(sozlesme.BEDELI, sozlesme.BEDELI_DOVIZ_ID.Value));
                }
            }
            if (yazdirilanSozlesmeler.Count == 0) return sozlesmeBedeli;

            foreach (var teki in paralarinSozlugu)
            {
                sozlesmeBedeli = ParaVeDovizId.Topla(teki.Value);
            }

            return sozlesmeBedeli;
        }

        #endregion <MB-20100610>

        #region degiskenDigerIslemler

        private static icradegiskenleri[] degis = new icradegiskenleri[]
            {
                new icradegiskenleri("&KDV&","",""),
                new icradegiskenleri("YFM","",""),
                new icradegiskenleri("&VERGIORN&","",""),
                new icradegiskenleri("&GDK&","",""),
                new icradegiskenleri("&ATK&","",""),
                new icradegiskenleri("&DTC&","",""),
                new icradegiskenleri("ASIL ALACAK","",""),
                new icradegiskenleri("D�V�Z KURU","",""),
                new icradegiskenleri("HARCA ESAS DE�ER","",""),
                new icradegiskenleri("&KUVTURKYTLACK&","",""),
                new icradegiskenleri("&SOZLESMEMIK&","",""),
                new icradegiskenleri("&ISLF&","",""),
                new icradegiskenleri("&ILAMACIK&","",""),
                new icradegiskenleri("&KUVTURKYTLACK&","",""),
                new icradegiskenleri("&OIVKDV&","",""),
            };

        private static void DegiskenleriYerlestir(List<TextField> lstFields, icradegiskenleri degisken)
        {
            for (int i = 0; i < lstFields.Count; i++)
            {
                if (lstFields[i].Text == degisken.Name)
                {
                    lstFields[i].Text = degisken.VaLUE.ToString();
                }
            }
        }

        private static void IcraDegiskenDegerAta(string ad, object deger)
        {
            for (int i = 0; i < degis.Length; i++)
            {
                if (degis[i].Name == ad)
                {
                    degis[i].VaLUE = deger;
                }
            }
        }

        #endregion degiskenDigerIslemler

        #region Tarafbilgileri

        public static bool TCKimlikNoYaz = true;

        public enum AdresSecimleri { Adresli, Adressiz }

        public static string GetCariDeger(int cariId, string temp, int? madde, bool TCKimlikNoYaz)
        {
            //burda**2

            #region Icra

            string returnValue = "";
            string val = temp;
            string sonuc = val;
            var cariAciklama = BelgeUtil.Inits.context.per_DEGISKEN_CARI_ACIKLAMAs.Single(item => item.ID == cariId);

            sonuc = sonuc.Replace("CariAdi", cariAciklama.AD);

            sonuc = sonuc.Replace("CariAdres1", SetWords(cariAciklama.ADRES_1, WordsUpperLowerType.AllWordsFirstCharsUpper));

            sonuc = sonuc.Replace("CariAdres2", SetWords(cariAciklama.ADRES_2, WordsUpperLowerType.AllWordsFirstCharsUpper));

            if (!string.IsNullOrEmpty(cariAciklama.TEL_1))
            {
                sonuc = sonuc.Replace("Telefon", SetWords("Tel : " + cariAciklama.TEL_1, WordsUpperLowerType.AllWordsFirstCharsUpper));
            }
            else
            {
                sonuc = sonuc.Replace("Telefon", SetWords("", WordsUpperLowerType.AllWordsFirstCharsUpper));
            }
            if (TCKimlikNoYaz)
            {
                if (!string.IsNullOrEmpty(cariAciklama.TC_KIMLIK_NO))
                {
                    sonuc = sonuc.Replace("Tc_No", SetWords(" (TC No:" + cariAciklama.TC_KIMLIK_NO + ")", WordsUpperLowerType.AllWordsFirstCharsUpper));
                }
                else
                {
                    sonuc = sonuc.Replace("Tc_No", SetWords("", WordsUpperLowerType.AllWordsFirstCharsUpper));
                }
            }
            if (!string.IsNullOrEmpty(cariAciklama.FAX))
            {
                sonuc = sonuc.Replace("Fax_No", SetWords("Fax : " + cariAciklama.FAX, WordsUpperLowerType.AllWordsFirstCharsUpper));
            }
            else
            {
                sonuc = sonuc.Replace("Fax_No", SetWords("", WordsUpperLowerType.AllWordsFirstCharsUpper));
            }

            sonuc = sonuc.Replace("CariAdres3", SetWords(cariAciklama.ADRES_3, WordsUpperLowerType.AllWordsFirstCharsUpper));

            sonuc = sonuc.Replace("PostaKodu", SetWords(cariAciklama.POSTA_KODU, WordsUpperLowerType.AllWordsFirstCharsUpper));
            if (!String.IsNullOrEmpty(cariAciklama.SEMT))
            {
                sonuc = sonuc.Replace("Semt", SetWords(cariAciklama.SEMT, WordsUpperLowerType.AllWordsFirstCharsUpper));
            }
            else
            {
                sonuc = sonuc.Replace("Semt", "");
            }

            if (!String.IsNullOrEmpty(cariAciklama.ILCE))
            {
                sonuc = sonuc.Replace("Ilce", SetWords(cariAciklama.ILCE, WordsUpperLowerType.AllWordsFirstCharsUpper));
            }
            else //efe
            {
                sonuc = sonuc.Replace("Ilce", "");
            }

            if (!String.IsNullOrEmpty(cariAciklama.IL))
            {
                sonuc = sonuc.Replace("Il", SetWords(cariAciklama.IL, WordsUpperLowerType.AllWordsFirstCharsUpper));
            }
            else //efe
            {
                sonuc = sonuc.Replace("Il", "");
            }

            if (!String.IsNullOrEmpty(cariAciklama.ULKE))
            {
                sonuc = sonuc.Replace("Ulke", SetWords(cariAciklama.ULKE, WordsUpperLowerType.AllWordsFirstCharsUpper));
            }
            else //efe
            {
                sonuc = sonuc.Replace("Ulke", "");
            }

            if (!String.IsNullOrEmpty(cariAciklama.VERGI_DAIRESI))
            {
                sonuc = sonuc.Replace("CariVergiDairesi", SetWords(cariAciklama.VERGI_DAIRESI, WordsUpperLowerType.AllWordsFirstCharsUpper));
            }
            else
            {
                sonuc = sonuc.Replace(" V.D. : CariVergiDairesi ", "");
            }

            if (!String.IsNullOrEmpty(cariAciklama.VERGI_NO))
            {
                sonuc = sonuc.Replace("CariVergiNo", SetWords(cariAciklama.VERGI_NO, WordsUpperLowerType.AllWordsFirstCharsUpper));
            }
            else
            {
                sonuc = sonuc.Replace("V.No : CariVergiNo", "");
            }

            if (madde.HasValue)
            {
                sonuc = sonuc.Replace("Madde", madde.Value.ToString());
            }
            else
            {
                sonuc = sonuc.Replace("Madde", "");
            }

            returnValue += sonuc;

            return returnValue;

            #endregion Icra
        }

        public static string GetCariDegerAlacakliVekilForEnerji(List<int> avukatCariIDList, bool avTCYaz)
        {
            string deger = string.Empty;
            string adres = string.Empty;
            bool adresYazildi = false;

            foreach (var avukat in avukatCariIDList)
            {
                var cari = BelgeUtil.Inits.context.per_DEGISKEN_CARI_ACIKLAMAs.Single(item => item.ID == avukat);

                deger += string.Format("Av. {0} {1}, ", cari.AD, avTCYaz ? "(TC No : " + cari.TC_KIMLIK_NO + ")" : "");

                if (adresYazildi) continue;

                if (!string.IsNullOrEmpty(cari.ADRES_1)) adres += cari.ADRES_1 + " ";
                if (!string.IsNullOrEmpty(cari.ADRES_2)) adres += cari.ADRES_2 + " ";
                if (!string.IsNullOrEmpty(cari.ADRES_3)) adres += cari.ADRES_3 + " ";
                if (!string.IsNullOrEmpty(cari.ILCE)) adres += cari.ILCE + " ";
                if (!string.IsNullOrEmpty(cari.IL)) adres += cari.IL + " ";
                adres += Environment.NewLine;
                if (!string.IsNullOrEmpty(cari.TEL_1)) adres += string.Format("Tel : {0} - ", cari.TEL_1);
                if (!string.IsNullOrEmpty(cari.FAX)) adres += string.Format("Fax : {0} ", cari.FAX);

                adresYazildi = true;
            }

            if (deger.Length >= 2)
                deger = deger.Remove(deger.Length - 2, 2);

            deger += Environment.NewLine;
            deger += adres;

            return deger;
        }

        public static string GetCariDegerBorcluVekilForEnerji(List<int> idList)
        {
            string deger = string.Empty;
            string adres = string.Empty;

            foreach (var avukat in idList)
            {
                var cari = BelgeUtil.Inits.context.per_DEGISKEN_CARI_ACIKLAMAs.Single(item => item.ID == avukat);

                deger += string.Format("Av. {0} (TC No : {1}), ", cari.AD, cari.TC_KIMLIK_NO);

                if (!string.IsNullOrEmpty(cari.ADRES_1)) adres += cari.ADRES_1 + " ";
                if (!string.IsNullOrEmpty(cari.ADRES_2)) adres += cari.ADRES_2 + " ";
                if (!string.IsNullOrEmpty(cari.ADRES_3)) adres += cari.ADRES_3 + " ";
                if (!string.IsNullOrEmpty(cari.ILCE)) adres += cari.ILCE + " ";
                if (!string.IsNullOrEmpty(cari.IL)) adres += cari.IL + " ";
            }

            deger += Environment.NewLine;
            deger += adres;

            return deger;
        }

        public static string GetCariDegerTarafForEnerji(int cariID, bool visible, bool adresYaz)
        {
            string deger = string.Empty;

            var cari = BelgeUtil.Inits.context.per_DEGISKEN_CARI_ACIKLAMAs.Single(item => item.ID == cariID);

            deger += cari.AD + " ";
            if (visible && !string.IsNullOrEmpty(cari.VERGI_NO)) deger += string.Format("(V./T.C.No : {0}) ", cari.VERGI_NO);
            deger += Environment.NewLine;

            if (!adresYaz) return deger;

            if (!string.IsNullOrEmpty(cari.ADRES_1)) deger += cari.ADRES_1 + " ";
            if (!string.IsNullOrEmpty(cari.ADRES_2)) deger += cari.ADRES_2 + " ";
            if (!string.IsNullOrEmpty(cari.ADRES_3)) deger += cari.ADRES_3 + " ";
            if (!string.IsNullOrEmpty(cari.ILCE)) deger += cari.ILCE + " ";
            if (!string.IsNullOrEmpty(cari.IL)) deger += cari.IL + " ";
            if (visible && !string.IsNullOrEmpty(cari.VERGI_DAIRESI)) deger += string.Format("V.D. : {0} ", cari.VERGI_DAIRESI);

            return deger;
        }

        public static string GetCariDegerTCliIBANLi(int cariId, string temp, int? madde, bool TCKimlikNoYaz)
        {
            //burda**2

            #region Icra

            string returnValue = "";
            string val = temp;
            string sonuc = val;
            var cariAciklama = BelgeUtil.Inits.context.per_DEGISKEN_CARI_ACIKLAMAs.Single(item => item.ID == cariId);

            sonuc = sonuc.Replace("CariAdi", cariAciklama.AD);

            sonuc = sonuc.Replace("CariAdres1", SetWords(cariAciklama.ADRES_1, WordsUpperLowerType.AllWordsFirstCharsUpper));

            sonuc = sonuc.Replace("CariAdres2", SetWords(cariAciklama.ADRES_2, WordsUpperLowerType.AllWordsFirstCharsUpper));

            AV001_TDI_BIL_CARI car = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(cariId);

            if (!string.IsNullOrEmpty(car.IBAN_NO))
                sonuc = sonuc + " M�vekkil IBAN No:" + car.IBAN_NO;

            if (!string.IsNullOrEmpty(cariAciklama.TEL_1))
            {
                sonuc = sonuc.Replace("Telefon", SetWords("Tel : " + cariAciklama.TEL_1, WordsUpperLowerType.AllWordsFirstCharsUpper));
            }
            else
            {
                sonuc = sonuc.Replace("Telefon", SetWords("", WordsUpperLowerType.AllWordsFirstCharsUpper));
            }
            if (TCKimlikNoYaz)
            {
                if (!string.IsNullOrEmpty(cariAciklama.TC_KIMLIK_NO))
                {
                    sonuc = sonuc.Replace("Tc_No", SetWords(" (TC No:" + cariAciklama.TC_KIMLIK_NO + ")", WordsUpperLowerType.AllWordsFirstCharsUpper));
                }
                else
                {
                    sonuc = sonuc.Replace("Tc_No", SetWords("", WordsUpperLowerType.AllWordsFirstCharsUpper));
                }
            }
            if (!string.IsNullOrEmpty(cariAciklama.FAX))
            {
                sonuc = sonuc.Replace("Fax_No", SetWords("Fax : " + cariAciklama.FAX, WordsUpperLowerType.AllWordsFirstCharsUpper));
            }
            else
            {
                sonuc = sonuc.Replace("Fax_No", SetWords("", WordsUpperLowerType.AllWordsFirstCharsUpper));
            }

            sonuc = sonuc.Replace("CariAdres3", SetWords(cariAciklama.ADRES_3, WordsUpperLowerType.AllWordsFirstCharsUpper));

            sonuc = sonuc.Replace("PostaKodu", SetWords(cariAciklama.POSTA_KODU, WordsUpperLowerType.AllWordsFirstCharsUpper));
            if (!String.IsNullOrEmpty(cariAciklama.SEMT))
            {
                sonuc = sonuc.Replace("Semt", SetWords(cariAciklama.SEMT, WordsUpperLowerType.AllWordsFirstCharsUpper));
            }
            else
            {
                sonuc = sonuc.Replace("Semt", "");
            }

            if (!String.IsNullOrEmpty(cariAciklama.ILCE))
            {
                sonuc = sonuc.Replace("Ilce", SetWords(cariAciklama.ILCE, WordsUpperLowerType.AllWordsFirstCharsUpper));
            }
            else //efe
            {
                sonuc = sonuc.Replace("Ilce", "");
            }

            if (!String.IsNullOrEmpty(cariAciklama.IL))
            {
                sonuc = sonuc.Replace("Il", SetWords(cariAciklama.IL, WordsUpperLowerType.AllWordsFirstCharsUpper));
            }
            else //efe
            {
                sonuc = sonuc.Replace("Il", "");
            }

            if (!String.IsNullOrEmpty(cariAciklama.ULKE))
            {
                sonuc = sonuc.Replace("Ulke", SetWords(cariAciklama.ULKE, WordsUpperLowerType.AllWordsFirstCharsUpper));
            }
            else //efe
            {
                sonuc = sonuc.Replace("Ulke", "");
            }

            if (!String.IsNullOrEmpty(cariAciklama.VERGI_DAIRESI))
            {
                sonuc = sonuc.Replace("CariVergiDairesi", SetWords(cariAciklama.VERGI_DAIRESI, WordsUpperLowerType.AllWordsFirstCharsUpper));
            }
            else
            {
                sonuc = sonuc.Replace(" V.D. : CariVergiDairesi ", "");
            }

            if (!String.IsNullOrEmpty(cariAciklama.VERGI_NO))
            {
                sonuc = sonuc.Replace("CariVergiNo", SetWords(cariAciklama.VERGI_NO, WordsUpperLowerType.AllWordsFirstCharsUpper));
            }
            else
            {
                sonuc = sonuc.Replace("V.No : CariVergiNo", "");
            }

            if (madde.HasValue)
            {
                sonuc = sonuc.Replace("Madde", madde.Value.ToString());
            }
            else
            {
                sonuc = sonuc.Replace("Madde", "");
            }

            returnValue += sonuc;

            return returnValue;

            #endregion Icra
        }

        public static DegiskenDegeri TarafBilgisiGetir(IEntity kayit, bool eden, int? sifat, bool vekil, AdresSecimleri AdresSecimi)
        {
            return TarafBilgisiGetir(kayit, eden, sifat, vekil, false, AdresSecimi);
        }

        public static DegiskenDegeri TarafBilgisiGetir(IEntity kayit, bool eden, int? sifat, bool vekil, bool sifatBilgisi, bool TCYaz)
        {
            TCKimlikNoYaz = TCYaz;
            return TarafBilgisiGetirTCYok(kayit, eden, sifat, vekil, sifatBilgisi);
        }

        public static DegiskenDegeri TarafBilgisiGetir(IEntity kayit, bool eden, int? sifat, bool vekil, bool sifatBilgisi, AdresSecimleri AdresSecimi)
        {
            DegiskenDegeri returnValue = new DegiskenDegeri();
            returnValue.Icerik = "";
            returnValue.DonusTipi = DegiskenResulTType.String;

            if (kayit is AV001_TI_BIL_FOY)
            {
                AV001_TI_BIL_FOY foyum = (AV001_TI_BIL_FOY)kayit;
                var taraflar = BelgeUtil.Inits.FoyTarafGetirByIcra(foyum.ID);
                int SiraNo = 1;

                var takipEdenler = taraflar.Where(vi => vi.TAKIP_EDEN_MI);
                var takipEdilenler = taraflar.Where(vi => !vi.TAKIP_EDEN_MI);
                AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT sft = null;
                for (int i = 0; i < taraflar.Count; i++)
                {
                    if (sifatBilgisi && taraflar[i].TARAF_SIFAT_ID > 0)
                        sft = BelgeUtil.Inits.context.per_TDIE_KOD_TARAF_SIFATs.Single(item => item.ID == taraflar[i].TARAF_SIFAT_ID);

                    if ((eden && taraflar[i].TAKIP_EDEN_MI) || (!eden && !taraflar[i].TAKIP_EDEN_MI))
                    {
                        bool vekilYazdir = false;
                        if (sifat.HasValue)
                        {
                            if (taraflar[i].TARAF_SIFAT_ID == sifat.Value)
                            {
                                if ((eden && takipEdenler.Count() > 1) || (!eden && takipEdilenler.Count() > 1))
                                    returnValue.Icerik += string.Format("{0} - ", SiraNo++);
                                if (sifatBilgisi) returnValue.Icerik += string.Format("({0})", sft.SIFAT);
                                returnValue.Icerik += GetCariDeger(taraflar[i].CARI_ID.Value, "Madde  CariAdi " + Environment.NewLine +
                      "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " +
                      " V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine, null, true);
                                vekilYazdir = true;
                            }
                        }
                        else
                        {
                            if ((eden && takipEdenler.Count() > 1) || (!eden && takipEdilenler.Count() > 1))
                                returnValue.Icerik += string.Format("{0} - ", SiraNo++);
                            if (sifatBilgisi) returnValue.Icerik += string.Format("({0})", sft.SIFAT);
                            returnValue.Icerik += GetCariDeger(taraflar[i].CARI_ID.Value, "Madde  CariAdi Tc_No " + Environment.NewLine +
        "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " +
        " V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine, null, true);

                            vekilYazdir = true;
                        }

                        if (vekil && !eden && vekilYazdir)
                        {
                            var vekilList = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAF_VEKILs.Where(item => item.FOY_TARAF_ID == taraflar[i].ID).ToList();
                            if (vekilList.Count > 0)
                            {
                                foreach (var trVekil in vekilList)
                                {
                                    if (!trVekil.AVUKAT_CARI_ID.HasValue)
                                        continue;

                                    returnValue.Icerik += GetCariDeger(trVekil.AVUKAT_CARI_ID.Value, "Madde Av. CariAdi Tc_No" + Environment.NewLine + "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " +
                                        " V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine + "Telefon - Fax_No" + Environment.NewLine, null, true);
                                }
                            }
                        }
                    }
                }
                if (vekil && eden)
                {
                    var sorumluAvukatList = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_SORUMLU_AVUKATs.Where(item => item.ICRA_FOY_ID == foyum.ID).ToList();
                    for (int y = 0; y < sorumluAvukatList.Count; y++)
                    {
                        if (sorumluAvukatList.Count > 1)
                        {
                            if (!sorumluAvukatList[y].YETKILI_MI)
                            {
                                if (sorumluAvukatList[y].SORUMLU_AVUKAT_CARI_ID != null) //efe
                                {
                                    returnValue.Icerik += GetCariDeger(sorumluAvukatList[y].SORUMLU_AVUKAT_CARI_ID.Value, "Madde Av. CariAdi Tc_No" + Environment.NewLine +
                                                 "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " +
                                                 " V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine + "Telefon - Fax_No" + Environment.NewLine, null, true);
                                }
                            }
                        }
                        else
                        {
                            returnValue.Icerik += GetCariDeger(sorumluAvukatList[y].SORUMLU_AVUKAT_CARI_ID.Value, "Madde Av. CariAdi Tc_No" + Environment.NewLine +
                                           "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " +
                                           " V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine + "Telefon - Fax_No" + Environment.NewLine, null, true);
                        }
                    }
                }

            }

            //TODO Dava i�in yap�lacak
            if (kayit is AV001_TD_BIL_FOY)
            {
                AV001_TD_BIL_FOY foyum = (AV001_TD_BIL_FOY)kayit;
                var taraflar = DataRepository.AV001_TD_BIL_FOY_TARAFProvider.GetByDAVA_FOY_ID(foyum.ID);
                int SiraNo = 1;

                var takipEdenler = taraflar.Where(vi => vi.DAVA_EDEN_MI);
                var takipEdilenler = taraflar.Where(vi => !vi.DAVA_EDEN_MI);
                AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT sft = null;

                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                cn.AddParams("@DAVA_FOY_ID", foyum.ID);
                DataTable dtVekiller = cn.GetDataTable("SELECT * FROM DBO.AV001_TD_BIL_FOY_TARAF_VEKIL(nolock) WHERE FOY_TARAF_ID IN(SELECT ID FROM dbo.AV001_TD_BIL_FOY_TARAF(nolock) WHERE DAVA_FOY_ID=@DAVA_FOY_ID)");

                List<AV001_TD_BIL_FOY_TARAF_VEKIL> liste = new List<AV001_TD_BIL_FOY_TARAF_VEKIL>();
                for (int i = 0; i < taraflar.Count; i++)
                {
                    if (sifatBilgisi && taraflar[i].TARAF_SIFAT_ID > 0)
                        sft = BelgeUtil.Inits.context.per_TDIE_KOD_TARAF_SIFATs.Single(item => item.ID == taraflar[i].TARAF_SIFAT_ID);

                    if ((eden && taraflar[i].DAVA_EDEN_MI) || (!eden && !taraflar[i].DAVA_EDEN_MI))
                    {
                        if (sifat.HasValue)
                        {
                            if (taraflar[i].TARAF_SIFAT_ID == sifat.Value)
                            {
                                if ((eden && takipEdenler.Count() > 1) || (!eden && takipEdilenler.Count() > 1))
                                    returnValue.Icerik += string.Format("{0} - ", SiraNo++);
                                if (sifatBilgisi) returnValue.Icerik += string.Format("({0})", sft.SIFAT);

                                if (AdresSecimi == AdresSecimleri.Adresli)
                                    returnValue.Icerik += GetCariDeger(taraflar[i].CARI_ID.Value, "Madde  CariAdi Tc_No " + Environment.NewLine +
                      "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " +
                      " V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine, null, true);
                                else
                                    returnValue.Icerik += GetCariDeger(taraflar[i].CARI_ID.Value, "Madde  CariAdi Tc_No " + Environment.NewLine, null, true);
                            }
                        }
                        else
                        {
                            if ((!eden && takipEdenler.Count() > 1) || (eden && takipEdilenler.Count() > 1))
                                returnValue.Icerik += string.Format("{0} - ", SiraNo++);
                            if (sifatBilgisi) returnValue.Icerik += string.Format("({0})", sft.SIFAT);

                            if (AdresSecimi == AdresSecimleri.Adresli)
                                returnValue.Icerik += GetCariDeger(taraflar[i].CARI_ID.Value, "Madde  CariAdi Tc_No " + Environment.NewLine +
"CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " +
" V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine, null, true);
                            else
                                returnValue.Icerik += GetCariDeger(taraflar[i].CARI_ID.Value, "Madde  CariAdi Tc_No " + Environment.NewLine, null, true);
                        }

                        if (vekil)
                        {
                            if (eden && taraflar[i].DAVA_EDEN_MI)
                            {
                                var vekilList = DataRepository.AV001_TD_BIL_FOY_TARAF_VEKILProvider.GetByFOY_TARAF_ID(taraflar[i].ID);

                                bool Varmi = false;
                                foreach (AV001_TD_BIL_FOY_TARAF_VEKIL item in vekilList)
                                {
                                    foreach (DataRow row in dtVekiller.Rows)
                                    {
                                        if (item.AVUKAT_CARI_ID == (int)row["AVUKAT_CARI_ID"] & item.ID != (int)row["ID"])
                                        {
                                            if (!liste.Contains(item))
                                            {
                                                liste.Add(DataRepository.AV001_TD_BIL_FOY_TARAF_VEKILProvider.GetByID((int)row["ID"]));
                                                Varmi = true;
                                            }
                                        }
                                    }
                                }

                                if (Varmi)
                                    continue;

                                liste.Clear();

                                if (vekilList.Count == 1)
                                    returnValue.Icerik += "Vekil:" + Environment.NewLine;
                                else if (vekilList.Count > 1)
                                    returnValue.Icerik += "Vekiller:" + Environment.NewLine;

                                for (int y = 0; y < vekilList.Count; y++)
                                {
                                    if (!vekilList[y].AVUKAT_CARI_ID.HasValue)
                                        continue;

                                    returnValue.Icerik += GetCariDeger(vekilList[y].AVUKAT_CARI_ID.Value, "Madde Av. CariAdi " + Environment.NewLine + "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " + Environment.NewLine, null, true);
                                }
                            }
                            else if (!eden && !taraflar[i].DAVA_EDEN_MI)
                            {
                                var vekilList = DataRepository.AV001_TD_BIL_FOY_TARAF_VEKILProvider.GetByFOY_TARAF_ID(taraflar[i].ID);

                                bool Varmi = false;
                                foreach (AV001_TD_BIL_FOY_TARAF_VEKIL item in vekilList)
                                {
                                    foreach (DataRow row in dtVekiller.Rows)
                                    {
                                        if (item.AVUKAT_CARI_ID == (int)row["AVUKAT_CARI_ID"] & item.ID != (int)row["ID"])
                                        {
                                            if (!liste.Contains(item))
                                            {
                                                liste.Add(DataRepository.AV001_TD_BIL_FOY_TARAF_VEKILProvider.GetByID((int)row["ID"]));
                                                Varmi = true;
                                            }
                                        }
                                    }
                                }

                                if (Varmi)
                                    continue;

                                liste.Clear();

                                if (vekilList.Count == 1)
                                    returnValue.Icerik += "Vekil:" + Environment.NewLine;
                                else if (vekilList.Count > 1)
                                    returnValue.Icerik += "Vekiller:" + Environment.NewLine;

                                for (int y = 0; y < vekilList.Count; y++)
                                {
                                    if (!vekilList[y].AVUKAT_CARI_ID.HasValue)
                                        continue;

                                    returnValue.Icerik += GetCariDeger(vekilList[y].AVUKAT_CARI_ID.Value, "Madde Av. CariAdi " + Environment.NewLine + "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " + Environment.NewLine, null, true);
                                }
                            }
                        }
                    }
                }
            }

            return returnValue;
        }

        public static DegiskenDegeri TarafBilgisiGetirForEnerji(IEntity kayit, bool eden, bool alacakliAdresYaz)
        {
            DegiskenDegeri returnValue = new DegiskenDegeri();
            returnValue.Icerik = "";
            returnValue.DonusTipi = DegiskenResulTType.String;

            if (kayit is AV001_TI_BIL_FOY)
            {
                AV001_TI_BIL_FOY foyum = (AV001_TI_BIL_FOY)kayit;
                int SiraNo = 1;

                var tarafList = BelgeUtil.Inits.FoyTarafGetirByIcra(foyum.ID).FindAll(vi => vi.TAKIP_EDEN_MI == eden);

                foreach (var item in tarafList)
                {
                    if (item.TAKIP_EDEN_MI)
                    {
                        returnValue.Icerik += GetCariDegerTarafForEnerji(item.CARI_ID.Value, true, alacakliAdresYaz);
                        returnValue.Icerik += Environment.NewLine;

                        //Bu metod YEDA� i�in yaz�ld���ndan ve bu durumda bir tane alacakl� oldu�undan, istendi�i gibi �al��acak.
                        var avukatListIDList = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_SORUMLU_AVUKATs.Where(vi => vi.ICRA_FOY_ID == foyum.ID).Select(vi => vi.SORUMLU_AVUKAT_CARI_ID.Value).ToList();
                        returnValue.Icerik += GetCariDegerAlacakliVekilForEnerji(avukatListIDList, alacakliAdresYaz);
                    }
                    else
                    {
                        if (tarafList.Count > 1)
                        {
                            returnValue.Icerik += SiraNo.ToString() + " - ";
                            SiraNo++;
                        }
                        returnValue.Icerik += GetCariDegerTarafForEnerji(item.CARI_ID.Value, false, alacakliAdresYaz);
                        var idList = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAF_VEKILs.Where(vi => vi.FOY_TARAF_ID == item.CARI_ID).Select(vi => vi.AVUKAT_CARI_ID.Value).ToList();
                        returnValue.Icerik += GetCariDegerBorcluVekilForEnerji(idList);
                    }
                    returnValue.Icerik += Environment.NewLine;
                }
            }
            return returnValue;
        }

        public static DegiskenDegeri TarafBilgisiGetirTCliIBANLi(IEntity kayit, bool eden, int? sifat, bool vekil)
        {
            return TarafBilgisiGetirTCliIBANLi(kayit, eden, sifat, vekil, false);
        }

        public static DegiskenDegeri TarafBilgisiGetirTCliIBANLi(IEntity kayit, bool eden, int? sifat, bool vekil, bool sifatBilgisi)
        {
            DegiskenDegeri returnValue = new DegiskenDegeri();
            returnValue.Icerik = "";
            returnValue.DonusTipi = DegiskenResulTType.String;

            if (kayit is AV001_TI_BIL_FOY)
            {
                AV001_TI_BIL_FOY foyum = (AV001_TI_BIL_FOY)kayit;
                var taraflar = BelgeUtil.Inits.FoyTarafGetirByIcra(foyum.ID);
                int SiraNo = 1;

                var takipEdenler = taraflar.Where(vi => vi.TAKIP_EDEN_MI);
                var takipEdilenler = taraflar.Where(vi => !vi.TAKIP_EDEN_MI);
                AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT sft = null;
                for (int i = 0; i < taraflar.Count; i++)
                {
                    if (sifatBilgisi && taraflar[i].TARAF_SIFAT_ID > 0)
                        sft = BelgeUtil.Inits.context.per_TDIE_KOD_TARAF_SIFATs.Single(item => item.ID == taraflar[i].TARAF_SIFAT_ID);

                    if ((eden && taraflar[i].TAKIP_EDEN_MI) || (!eden && !taraflar[i].TAKIP_EDEN_MI))
                    {
                        bool vekilYazdir = false;
                        if (sifat.HasValue)
                        {
                            if (taraflar[i].TARAF_SIFAT_ID == sifat.Value)
                            {
                                if ((eden && takipEdenler.Count() > 1) || (!eden && takipEdilenler.Count() > 1))
                                    returnValue.Icerik += string.Format("{0} - ", SiraNo++);
                                if (sifatBilgisi) returnValue.Icerik += string.Format("({0})", sft.SIFAT);

                                returnValue.Icerik += GetCariDegerTCliIBANLi(taraflar[i].CARI_ID.Value, "Madde  CariAdi " + Environment.NewLine +
                      "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " +
                      " V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine, null, true);

                                vekilYazdir = true;
                            }
                        }
                        else
                        {
                            if ((eden && takipEdenler.Count() > 1) || (!eden && takipEdilenler.Count() > 1))
                                returnValue.Icerik += string.Format("{0} - ", SiraNo++);
                            if (sifatBilgisi) returnValue.Icerik += string.Format("({0})", sft.SIFAT);
                            returnValue.Icerik += GetCariDegerTCliIBANLi(taraflar[i].CARI_ID.Value, "Madde  CariAdi Tc_No " + Environment.NewLine +
"CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " +
" V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine, null, true);
                            vekilYazdir = true;
                        }

                        if (vekil && !eden && vekilYazdir)
                        {
                            var vekilList = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAF_VEKILs.Where(item => item.FOY_TARAF_ID == taraflar[i].ID).ToList();
                            if (vekilList.Count > 0)
                            {
                                foreach (var trVekil in vekilList)
                                {
                                    if (!trVekil.AVUKAT_CARI_ID.HasValue)
                                        continue;

                                    returnValue.Icerik += GetCariDegerTCliIBANLi(trVekil.AVUKAT_CARI_ID.Value, "Madde Av. CariAdi Tc_No" + Environment.NewLine + "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " +
                                        " V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine + "Telefon - Fax_No" + Environment.NewLine, null, true);
                                }
                            }
                        }
                    }
                }
                if (vekil && eden)
                {
                    var sorumluAvukatList = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_SORUMLU_AVUKATs.Where(item => item.ICRA_FOY_ID == foyum.ID).ToList();
                    for (int y = 0; y < sorumluAvukatList.Count; y++)
                    {
                        if (sorumluAvukatList.Count > 1)
                        {
                            if (!sorumluAvukatList[y].YETKILI_MI)
                            {
                                if (sorumluAvukatList[y].SORUMLU_AVUKAT_CARI_ID != null) //efe
                                {
                                    returnValue.Icerik += GetCariDegerTCliIBANLi(sorumluAvukatList[y].SORUMLU_AVUKAT_CARI_ID.Value, "Madde Av. CariAdi Tc_No" + Environment.NewLine +
                                                 "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " +
                                                 " V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine + "Telefon - Fax_No" + Environment.NewLine, null, true);
                                }
                            }
                        }
                        else
                        {
                            returnValue.Icerik += GetCariDegerTCliIBANLi(sorumluAvukatList[y].SORUMLU_AVUKAT_CARI_ID.Value, "Madde Av. CariAdi Tc_No" + Environment.NewLine +
                                           "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " +
                                           " V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine + "Telefon - Fax_No" + Environment.NewLine, null, true);
                        }
                    }
                }
            }
            else if (kayit is AV001_TD_BIL_FOY)
            {
                AV001_TD_BIL_FOY foyum = (AV001_TD_BIL_FOY)kayit;
                var taraflar = DataRepository.AV001_TD_BIL_FOY_TARAFProvider.GetByDAVA_FOY_ID(foyum.ID);
                int SiraNo = 1;

                var takipEdenler = taraflar.Where(vi => vi.DAVA_EDEN_MI);
                var takipEdilenler = taraflar.Where(vi => !vi.DAVA_EDEN_MI);
                AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT sft = null;
                for (int i = 0; i < taraflar.Count; i++)
                {
                    if (sifatBilgisi && taraflar[i].TARAF_SIFAT_ID > 0)
                        sft = BelgeUtil.Inits.context.per_TDIE_KOD_TARAF_SIFATs.Single(item => item.ID == taraflar[i].TARAF_SIFAT_ID);

                    if ((eden && taraflar[i].DAVA_EDEN_MI) || (!eden && !taraflar[i].DAVA_EDEN_MI))
                    {
                        bool vekilYazdir = false;
                        if (sifat.HasValue)
                        {
                            if (taraflar[i].TARAF_SIFAT_ID == sifat.Value)
                            {
                                if ((eden && takipEdenler.Count() > 1) || (!eden && takipEdilenler.Count() > 1))
                                    returnValue.Icerik += string.Format("{0} - ", SiraNo++);
                                if (sifatBilgisi) returnValue.Icerik += string.Format("({0})", sft.SIFAT);

                                returnValue.Icerik += GetCariDegerTCliIBANLi(taraflar[i].CARI_ID.Value, "Madde  CariAdi " + Environment.NewLine +
                      "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " +
                      " V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine, null, true);

                                vekilYazdir = true;
                            }
                        }
                        else
                        {
                            if ((eden && takipEdenler.Count() > 1) || (!eden && takipEdilenler.Count() > 1))
                                returnValue.Icerik += string.Format("{0} - ", SiraNo++);
                            if (sifatBilgisi) returnValue.Icerik += string.Format("({0})", sft.SIFAT);
                            returnValue.Icerik += GetCariDegerTCliIBANLi(taraflar[i].CARI_ID.Value, "Madde  CariAdi Tc_No " + Environment.NewLine +
"CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " +
" V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine, null, true);
                            vekilYazdir = true;
                        }

                        if (vekil && !eden && vekilYazdir)
                        {
                            var vekilList = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAF_VEKILs.Where(item => item.FOY_TARAF_ID == taraflar[i].ID).ToList();
                            if (vekilList.Count > 0)
                            {
                                foreach (var trVekil in vekilList)
                                {
                                    if (!trVekil.AVUKAT_CARI_ID.HasValue)
                                        continue;

                                    returnValue.Icerik += GetCariDegerTCliIBANLi(trVekil.AVUKAT_CARI_ID.Value, "Madde Av. CariAdi Tc_No" + Environment.NewLine + "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " +
                                        " V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine + "Telefon - Fax_No" + Environment.NewLine, null, true);
                                }
                            }
                        }
                    }
                }
                if (vekil && eden)
                {
                    var sorumluAvukatList = DataRepository.AV001_TD_BIL_FOY_SORUMLU_AVUKATProvider.GetByDAVA_FOY_ID(foyum.ID);
                    for (int y = 0; y < sorumluAvukatList.Count; y++)
                    {
                        if (sorumluAvukatList.Count > 1)
                        {
                            if (!sorumluAvukatList[y].YETKILI_MI)
                            {
                                if (sorumluAvukatList[y].SORUMLU_AVUKAT_CARI_ID != null) //efe
                                {
                                    returnValue.Icerik += GetCariDegerTCliIBANLi(sorumluAvukatList[y].SORUMLU_AVUKAT_CARI_ID.Value, "Madde Av. CariAdi Tc_No" + Environment.NewLine +
                                                 "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " +
                                                 " V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine + "Telefon - Fax_No" + Environment.NewLine, null, true);
                                }
                            }
                        }
                        else
                        {
                            returnValue.Icerik += GetCariDegerTCliIBANLi(sorumluAvukatList[y].SORUMLU_AVUKAT_CARI_ID.Value, "Madde Av. CariAdi Tc_No" + Environment.NewLine +
                                           "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " +
                                           " V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine + "Telefon - Fax_No" + Environment.NewLine, null, true);
                        }
                    }
                }

            }
            //TODO Dava i�in yap�lacak

            return returnValue;
        }

        public static DegiskenDegeri TarafBilgisiGetirTCYok(IEntity kayit, bool eden, int? sifat, bool vekil, bool sifatBilgisi)
        {
            DegiskenDegeri returnValue = new DegiskenDegeri();
            returnValue.Icerik = "";
            returnValue.DonusTipi = DegiskenResulTType.String;

            if (kayit is AV001_TI_BIL_FOY)
            {
                AV001_TI_BIL_FOY foyum = (AV001_TI_BIL_FOY)kayit;
                var taraflar = BelgeUtil.Inits.FoyTarafGetirByIcra(foyum.ID);
                int SiraNo = 1;

                var takipEdenler = taraflar.Where(vi => vi.TAKIP_EDEN_MI);
                var takipEdilenler = taraflar.Where(vi => !vi.TAKIP_EDEN_MI);
                AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT sft = null;
                for (int i = 0; i < taraflar.Count; i++)
                {
                    if (sifatBilgisi && taraflar[i].TARAF_SIFAT_ID > 0)
                        sft = BelgeUtil.Inits.context.per_TDIE_KOD_TARAF_SIFATs.Single(item => item.ID == taraflar[i].TARAF_SIFAT_ID);

                    if ((eden && taraflar[i].TAKIP_EDEN_MI) || (!eden && !taraflar[i].TAKIP_EDEN_MI))
                    {
                        bool vekilYazdir = false;
                        if (sifat.HasValue)
                        {
                            if (taraflar[i].TARAF_SIFAT_ID == sifat.Value)
                            {
                                if ((eden && takipEdenler.Count() > 1) || (!eden && takipEdilenler.Count() > 1))
                                    returnValue.Icerik += string.Format("{0} - ", SiraNo++);
                                if (sifatBilgisi) returnValue.Icerik += string.Format("({0})", sft.SIFAT);

                                returnValue.Icerik += GetCariDeger(taraflar[i].CARI_ID.Value, "Madde  CariAdi " + Environment.NewLine + "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " + Environment.NewLine, null, TCKimlikNoYaz);
                                vekilYazdir = true;
                            }
                        }
                        else
                        {
                            if ((eden && takipEdenler.Count() > 1) || (!eden && takipEdilenler.Count() > 1))
                                returnValue.Icerik += string.Format("{0} - ", SiraNo++);
                            if (sifatBilgisi) returnValue.Icerik += string.Format("({0})", sft.SIFAT);
                            if (!eden)
                                returnValue.Icerik += GetCariDeger(taraflar[i].CARI_ID.Value, "Madde  CariAdi Tc_No " + Environment.NewLine + "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " + " V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine, null, true);
                            else
                                returnValue.Icerik += GetCariDeger(taraflar[i].CARI_ID.Value, "Madde  CariAdi" + Environment.NewLine + "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " + Environment.NewLine, null, TCKimlikNoYaz);
                            vekilYazdir = true;
                        }

                        if (vekil && !eden && vekilYazdir)
                        {
                            var vekilList = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAF_VEKILs.Where(item => item.FOY_TARAF_ID == taraflar[i].ID).ToList();
                            if (vekilList.Count > 0)
                            {
                                foreach (var trVekil in vekilList)
                                {
                                    if (!trVekil.AVUKAT_CARI_ID.HasValue)
                                        continue;

                                    returnValue.Icerik += GetCariDeger(trVekil.AVUKAT_CARI_ID.Value, "Madde Av. CariAdi" + Environment.NewLine + "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " + Environment.NewLine + "Telefon - Fax_No" + Environment.NewLine, null, TCKimlikNoYaz);
                                }
                            }
                        }
                    }
                }
                if (vekil && eden)
                {
                    var sorumluAvukatList = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_SORUMLU_AVUKATs.Where(item => item.ICRA_FOY_ID == foyum.ID).ToList();
                    for (int y = 0; y < sorumluAvukatList.Count; y++)
                    {
                        if (sorumluAvukatList.Count > 1)
                        {
                            if (!sorumluAvukatList[y].YETKILI_MI)
                            {
                                returnValue.Icerik += GetCariDeger(sorumluAvukatList[y].SORUMLU_AVUKAT_CARI_ID.Value, "Madde Av. CariAdi" + Environment.NewLine + "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il" + Environment.NewLine + "Telefon - Fax_No" + Environment.NewLine, null, TCKimlikNoYaz);
                            }
                        }
                        else
                        {
                            returnValue.Icerik += GetCariDeger(sorumluAvukatList[y].SORUMLU_AVUKAT_CARI_ID.Value, "Madde Av. CariAdi" + Environment.NewLine + "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " + Environment.NewLine + "Telefon - Fax_No" + Environment.NewLine, null, TCKimlikNoYaz);
                        }
                    }
                }
            }
            return returnValue;
        }

        #region Gruplama De�i�kenleri

        /// <summary>
        /// Gruplamalarda Kullan�lacak Carinin Ad�n� ve Adresini getiren de�i�ken
        /// </summary>
        /// <param name="taraf"></param>
        /// <returns></returns>
        public static DegiskenDegeri GetFoyTarafBilgisi(AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF taraf, bool tarafBilgisi, bool vekilBilgisi)
        {
            DegiskenDegeri degisken = new DegiskenDegeri();
            if (tarafBilgisi)
            {
                degisken.Icerik = GetCariDeger(taraf.CARI_ID.Value,
                                               "CariAdi Tc_No" + Environment.NewLine +
                                               "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce / Il " +
                                               " V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine +
                                               "Telefon - Fax_No" + Environment.NewLine, null, true);
            }

            if (vekilBilgisi)
            {
                var vekiller = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAF_VEKILs.Where(vi => vi.FOY_TARAF_ID == taraf.ID).ToList();

                if (vekiller.Count > 0)
                {
                    degisken.Icerik += Environment.NewLine;
                    degisken.Icerik += @"Vekili/leri";
                }
                foreach (var vekil in vekiller)
                {
                    degisken.Icerik += Environment.NewLine;
                    degisken.Icerik +=
                        degisken.Icerik =
                        GetCariDeger(vekil.AVUKAT_CARI_ID.Value,
                                     "CariAdi Tc_No" + Environment.NewLine +
                                     "CariAdres1 CariAdres2 CariAdres3 PostaKodu Semt Ilce Il " +
                                     " V.D. : CariVergiDairesi   V.No : CariVergiNo" + Environment.NewLine +
                                     "Telefon - Fax_No" + Environment.NewLine, null, true);
                }
            }

            //burda**1
            return degisken;
        }

        #endregion Gruplama De�i�kenleri

        #endregion Tarafbilgileri

        #region <MB-20100610>

        // Takip Talebinde Alacak, ipotek s�zle�me limiti bedelinden b�y�kse ��kan hesaplarda gayrinakit toplam�n� veren metod.

        public static ParaVeDovizId ToplamGayriNakitAlacaklar(AV001_TI_BIL_FOY foy)
        {
            SayiOkuma so = new SayiOkuma();

            #region Depo Alacaklar�n� Grupluyoruz

            var gayriNakitAlacaklar = HesapAraclari.Icra.AlacakNedenGayriNakitleriGetir(foy);

            //gayri nakit alacak yoksa a��a��daki i�lemlere gerek yok
            if (gayriNakitAlacaklar.Count == 0)
                return null;

            List<AV001_TI_BIL_ALACAK_NEDEN> cekYapraklari = new List<AV001_TI_BIL_ALACAK_NEDEN>();
            List<AV001_TI_BIL_ALACAK_NEDEN> meriMektuplari = new List<AV001_TI_BIL_ALACAK_NEDEN>();
            List<AV001_TI_BIL_ALACAK_NEDEN> digerNedenler = new List<AV001_TI_BIL_ALACAK_NEDEN>();

            foreach (var aNeden in gayriNakitAlacaklar)
            {
                if (HesapAraclari.Icra.AlacakNedenCekYapragimi(aNeden))
                    cekYapraklari.Add(aNeden);
                else if (HesapAraclari.Icra.AlacakNedenMeriTeminatMektubuMu(aNeden))
                    meriMektuplari.Add(aNeden);
                else
                    digerNedenler.Add(aNeden);
            }

            #endregion Depo Alacaklar�n� Grupluyoruz

            #region �ek Yapra��

            ParaVeDovizId paraCekYapraklari = new ParaVeDovizId();
            foreach (var aNeden in cekYapraklari)
            {
                ParaVeDovizId paraTekYaprak = new ParaVeDovizId(aNeden.CEK_YAPRAGI_SORUMLULUK_MIKTARI, aNeden.CEK_YAPRAGI_SORUMLULUK_MIKTARI_DOVIZ_ID);
                ParaVeDovizId paraIslemeKonanTutar = new ParaVeDovizId(aNeden.ISLEME_KONAN_TUTAR, aNeden.ISLEME_KONAN_TUTAR_DOVIZ_ID);
                paraCekYapraklari = ParaVeDovizId.Topla(paraCekYapraklari, paraIslemeKonanTutar);
            }

            #endregion �ek Yapra��

            #region Mer`i mektubu

            ParaVeDovizId paraMeriMektuplari = new ParaVeDovizId(0, 1);
            foreach (var aNeden in meriMektuplari)
            {
                var Tarih = aNeden.DUZENLENME_TARIHI; //{0} - Tarih
                var seriNo = aNeden.ALACAK_NEDEN_REFERANS_SIRA; //{1} - Seri No
                var bedeli = new ParaVeDovizId(aNeden.TUTARI, aNeden.TUTAR_DOVIZ_ID); //{2} - Bedeli
                var bedeliText = so.ParaFormatla(bedeli.Para) + " " + bedeli.DovizKodu;
                var muhattabi = HesapAraclari.Icra.CariAdiGetirByCariId(aNeden.TEMINAT_MEKTUP_MUHATAP_CARI_ID.Value); //{3} - Muhattab�
                paraMeriMektuplari = ParaVeDovizId.Topla(paraMeriMektuplari, bedeli);
            }

            #endregion Mer`i mektubu

            #region Di�er Alacaklar

            ParaVeDovizId paraDigerAlacaklar = new ParaVeDovizId(0, 1);
            foreach (var aNeden in digerNedenler)
            {
                var Tarih = aNeden.DUZENLENME_TARIHI; //{0} - Tarih
                var bedeli = new ParaVeDovizId(aNeden.TUTARI, aNeden.TUTAR_DOVIZ_ID); //{2} - Bedeli
                var bedeliText = so.ParaFormatla(bedeli.Para) + " " + bedeli.DovizKodu;
                var alacakNEdenAdi = HesapAraclari.Icra.AlacakNedenAdiGetirByAlacakNedenKodId(aNeden.ALACAK_NEDEN_KOD_ID.Value);
                paraDigerAlacaklar = ParaVeDovizId.Topla(paraDigerAlacaklar, bedeli);
            }

            #endregion Di�er Alacaklar

            #region Genel Toplam

            ParaVeDovizId genelToplam = ParaVeDovizId.Topla(paraMeriMektuplari, paraCekYapraklari, paraDigerAlacaklar);

            #endregion Genel Toplam

            return genelToplam;
        }

        #endregion <MB-20100610>
    }

    #region Enums

    public enum CharUpperLowerType
    {
        FirstbigOthersSmal,
        FirstSmallOthersBig,
        AllBig,
        AllSmall,
        None,
    }

    public enum DegiskenResulTType
    {
        HTML, String, HicBiri, TextField
    }

    public enum TemsilBilgileri
    {
        Noter, Yevmiye, Yetki, Tumu
    }

    public enum VarTypes
    {
        Dava,
        Icra,
        Hazirlik,
        Rucu,
        Sozlesme
    }

    public enum WordsUpperLowerType
    {
        FirstWordUpperOthersLower,
        FirstWordFirstCharUpperOtherLower,
        AllWordAllCharsUpper,
        AllWordsFirstCharsUpper,
        AllWordsAllCharsLower,
        FirstWordsFirstCharLoverOtherWordsFirstCharUpper,
    }

    #endregion Enums

    #region class

    public class AlacakFazlaIpotekAz
    {
        public ParaVeDovizId IpotegiAsanKisim { get; set; }

        public ParaVeDovizId LimitIpotekSozlesmesi { get; set; }

        public ParaVeDovizId TakipCikisi { get; set; }

        public ParaVeDovizId ToplamGayrinakitAlacaklar { get; set; }

        public ParaVeDovizId TumAlacaklar { get; set; }
    }

    public class AlacakNedenGrubu
    {
        private int _adet;
        private TI_KOD_ALACAK_NEDEN _alacakNedenKodTipi;
        private TList<AV001_TI_BIL_ALACAK_NEDEN> _alacakNedenleri;
        private TDI_KOD_DOVIZ_TIP _doviz;

        private DateTime _takipTarihi;

        private decimal _toplam;

        private decimal _ytlToplam;

        public int Adet
        {
            get { return _adet; }
            set { _adet = value; }
        }

        public TI_KOD_ALACAK_NEDEN AlacakNedenKodTipi
        {
            get { return _alacakNedenKodTipi; }
            set { _alacakNedenKodTipi = value; }
        }

        public TList<AV001_TI_BIL_ALACAK_NEDEN> AlacakNedenleri
        {
            get { return _alacakNedenleri; }
            set { _alacakNedenleri = value; }
        }

        public TDI_KOD_DOVIZ_TIP Doviz
        {
            get { return _doviz; }
            set { _doviz = value; }
        }

        public DateTime TakipTarihi
        {
            get { return _takipTarihi; }
            set { _takipTarihi = value; }
        }

        public decimal Toplam
        {
            get { return _toplam; }
            set { _toplam = value; }
        }

        public decimal YtlToplam
        {
            get { return _ytlToplam; }
            set { _ytlToplam = value; }
        }

        /// <summary>
        /// tipe gore alacak nedenlerini gruplar .
        /// </summary>
        /// <param name="alacakNedeni">gruplanacak alacak nedeni</param>
        /// <param name="alacakNedenleri">alacak neden gruplar� </param>
        public static void AlacakNedenGruplamaKontrolu(AV001_TI_BIL_ALACAK_NEDEN alacakNedeni, List<AlacakNedenGrubu> alacakNedenleri, DateTime takipTarihi)
        {
            bool added = false;

            for (int i = 0; i < alacakNedenleri.Count; i++)
            {
                if (alacakNedenleri[i].AlacakNedenleri[0].ALACAK_NEDEN_KOD_ID == alacakNedeni.ALACAK_NEDEN_KOD_ID)
                {
                    alacakNedenleri[i].AlacakNedenleri.Add(alacakNedeni);

                    //alacakNedenleri.Add(alacakNedeni);
                    added = true;
                }
            }

            if (!added)
            {
                TList<AV001_TI_BIL_ALACAK_NEDEN> nedenler = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
                AlacakNedenGrubu grp = new AlacakNedenGrubu();
                grp.AlacakNedenKodTipi = alacakNedeni.ALACAK_NEDEN_KOD_IDSource;
                grp.Doviz = alacakNedeni.ISLEME_KONAN_TUTAR_DOVIZ_IDSource;
                nedenler.Add(alacakNedeni);
                grp.AlacakNedenleri = nedenler;
                grp.TakipTarihi = takipTarihi;
                alacakNedenleri.Add(grp);
            }
        }

        public List<AlacakNedenGrubu> GetDovizeGoreGrup(DateTime tarih)
        {
            List<AlacakNedenGrubu> dovizeGoreGrup = new List<AlacakNedenGrubu>();
            for (int i = 0; i < this._alacakNedenleri.Count; i++)
            {
                //if (_alacakNedenleri[i].ISLEME_KONAN_TUTAR_DOVIZ_ID!=_alacakNedenleri[0].ISLEME_KONAN_TUTAR_DOVIZ_ID)
                //{
                bool Added = false;
                for (int y = 0; y < dovizeGoreGrup.Count; y++)
                {
                    if (dovizeGoreGrup[y].Doviz.ID == _alacakNedenleri[0].ISLEME_KONAN_TUTAR_DOVIZ_ID)
                    {
                        dovizeGoreGrup[y].AlacakNedenleri.Add(_alacakNedenleri[i]);
                        Added = true;
                    }
                }
                if (!Added)
                {
                    TList<AV001_TI_BIL_ALACAK_NEDEN> yeniGrup = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
                    yeniGrup.Add(_alacakNedenleri[i]);
                    AlacakNedenGrubu grp = new AlacakNedenGrubu();
                    grp.AlacakNedenleri = yeniGrup;
                    grp.Doviz = _alacakNedenleri[i].ISLEME_KONAN_TUTAR_DOVIZ_IDSource;
                    grp.AlacakNedenKodTipi = _alacakNedenleri[i].ALACAK_NEDEN_KOD_IDSource;
                    grp.TakipTarihi = tarih;
                    dovizeGoreGrup.Add(grp);
                }

                //}
            }

            return dovizeGoreGrup;
        }

        public void Hesapla()
        {
            List<AlacakNedenGrubu> nedenler = GetDovizeGoreGrup(this.TakipTarihi);
            for (int i = 0; i < nedenler.Count; i++)
            {
                for (int y = 0; y < nedenler[i].AlacakNedenleri.Count; y++)
                {
                    this.Toplam += nedenler[i].AlacakNedenleri[y].ISLEME_KONAN_TUTAR;
                    if (nedenler[i].AlacakNedenleri[y].ADET.HasValue)
                    {
                        this.Adet += nedenler[i].AlacakNedenleri[y].ADET.Value;
                    }

                    this.Doviz = nedenler[i].AlacakNedenleri[y].ISLEME_KONAN_TUTAR_DOVIZ_IDSource;
                    this.AlacakNedenKodTipi = nedenler[i].AlacakNedenleri[y].ALACAK_NEDEN_KOD_IDSource;
                    YtlToplam = decimal.Zero;
                    decimal deger = nedenler[i].AlacakNedenleri[y].ISLEME_KONAN_TUTAR;
                    if (nedenler[i].AlacakNedenleri[y].ADET.HasValue)
                    {
                        DovizHelper.GetMerkezBankasiBilgisi(nedenler[i].AlacakNedenKodTipi.ID);
                        deger = nedenler[i].AlacakNedenleri[y].ISLEME_KONAN_TUTAR * nedenler[i].AlacakNedenleri[y].ADET.Value;
                    }
                    this.YtlToplam += DovizHelper.CevirYTL(deger, this.Doviz.ID, this.TakipTarihi);
                }
            }
        }
    }

    public class CariGrup
    {
        private TList<AV001_TDI_BIL_CARI_ALT> _altindakiCariler;
        private AV001_TDI_BIL_CARI _cari;

        public TList<AV001_TDI_BIL_CARI_ALT> AltindakiCariler
        {
            get { return _altindakiCariler; }
            set { _altindakiCariler = value; }
        }

        public AV001_TDI_BIL_CARI Cari
        {
            get { return _cari; }
            set { _cari = value; }
        }
    }

    public class DegiskenDegeri
    {
        private AV001_TDIE_BIL_SABLON_DEGISKENLER _degisken;
        private DegiskenResulTType _donusTipi;

        private string _icerik;

        public AV001_TDIE_BIL_SABLON_DEGISKENLER Degisken
        {
            get { return _degisken; }
            set { _degisken = value; }
        }

        public DegiskenResulTType DonusTipi
        {
            get { return _donusTipi; }
            set { _donusTipi = value; }
        }

        public string Icerik
        {
            get { return _icerik; }
            set { _icerik = value; }
        }
    }

    public static class IcraAlacakNedenAdlari
    {
        public static DegiskenDegeri DegeriGetir(AV001_TI_BIL_FOY Foyu)
        {
            DegiskenDegeri Deger = new DegiskenDegeri();
            Deger.DonusTipi = DegiskenResulTType.String;

            //Deger.Degisken = Degiskeni;
            string ItemTemplate = "{0} {1} ";
            string Template = "{0} {1} s�reti bulunmaktad�r.";
            string Item = "";
            List<AlacakNedenGrubu> alacakNedenleri = new List<AlacakNedenGrubu>();
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(Foyu, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(Foyu.AV001_TI_BIL_ALACAK_NEDENCollection, false, DeepLoadType.IncludeChildren, typeof(TI_KOD_ALACAK_NEDEN));

            TList<AV001_TI_BIL_ALACAK_NEDEN> lstAlacakNedenleri = Foyu.AV001_TI_BIL_ALACAK_NEDENCollection;
            for (int i = 0; i < lstAlacakNedenleri.Count; i++)
            {
                AlacakNedenGrubu.AlacakNedenGruplamaKontrolu(lstAlacakNedenleri[i], alacakNedenleri, Foyu.TAKIP_TARIHI.Value);
            }

            for (int i = 0; i < alacakNedenleri.Count; i++)
            {
                if (alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.Cek
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.CEK_151
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.CEK_152
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.CEK_201
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.Cek_33
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.Cek_34
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.Cek_35
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.CEK_50
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.Police
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.POLICE_151
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.POLICE_152
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.POLICE_201
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.Police_39
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.Police_40
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.Police_41
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.POLICE_50
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.Senet
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.SENET_151
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.SENET_152
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.Senet_2
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.SENET_201
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.Senet_36
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.Senet_38
                    || alacakNedenleri[i].AlacakNedenKodTipi.ID == (int)AlacakNeden.SENET_50)
                {
                    Item += string.Format(ItemTemplate, alacakNedenleri[i].AlacakNedenleri.Count, alacakNedenleri[i].AlacakNedenleri[0].ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI);
                }
            }

            if (Item.Length > 0)
            {
                Deger.Icerik = string.Format(Template, Item, "");
            }
            else
            {
                if (Foyu.FORM_TIP_IDSource != null)
                {
                    Deger.Icerik = string.Empty;// Foyu.FORM_TIP_IDSource.FORM_ADI; Alacak nedeni �ek ya da senet de�ilse default olarak form tipinin a��klamas�n�n g�sterilmesi istenmedi�inden kald�r�ld�. MB
                }
            }

            return Deger;
        }
    }

    public static class IcraFormTipineGoreYasalSure
    {
        public static DegiskenDegeri DegeriGetir(AV001_TI_BIL_FOY Foyu, int SureTipi)
        {
            //geri d�n�� de�eri
            DegiskenDegeri Donecek = new DegiskenDegeri();

            //Donecek.Degisken = Degiskeni;
            Donecek.DonusTipi = DegiskenResulTType.String;
            Donecek.Icerik = "";

            //form tipine g�re s�reler
            TList<TI_BIL_YASAL_SURE> Sureler = AvukatProLib2.Data.DataRepository.TI_BIL_YASAL_SUREProvider.GetByFORM_TIP_ID(Foyu.FORM_TIP_ID.Value);

            for (int i = 0; i < Sureler.Count; i++)
            {
                if (Foyu.TAKIP_TALEP_ID.HasValue)
                {
                    if (Foyu.TAKIP_TALEP_ID.Value != Sureler[i].TAKIP_TALEP_ID)
                    {
                        continue;
                    }
                }

                //�deme S�resi
                if (SureTipi == 4 && Sureler[i].FORM_TIP_ID == 10)
                {
                    ///Alt� Aydan Buyukmu kucukmu
                    bool? donen = AltiAydanBuyukMu(Foyu);

                    //B�y�kse k���kse yada bo�sa �deme tipini ayarla
                    //bo�sa has�lat ...
                    if (donen.HasValue)
                    {
                        if (donen.Value)
                        {
                            //alt� aydan buyuk
                            SureTipi = 8;
                        }
                        else
                        {
                            //k���k
                            SureTipi = 9;
                        }
                    }
                    else
                    {
                        //has�lat
                        SureTipi = 10;
                    }
                }

                //uygun s�reyi bulma
                if (Sureler[i].SURE_TIP_ID == SureTipi)
                {
                    if (Sureler[i].SURE_YIL > 0)
                    {
                        Donecek.Icerik = Sureler[i].SURE_YIL.ToString() + " Y�l ";
                    }
                    if (Sureler[i].SURE_AY > 0)
                    {
                        Donecek.Icerik = Sureler[i].SURE_AY.ToString() + " Ay ";
                    }
                    if (Sureler[i].SURE_GUN > 0)
                    {
                        Donecek.Icerik = Sureler[i].SURE_GUN.ToString();
                    }
                }
            }

            //sonu�
            return Donecek;
        }

        private static bool? AltiAydanBuyukMu(AV001_TI_BIL_FOY myFoy)
        {
            bool? donecek = false;
            DateTime sozlesmeBaslangicTarihi = DateTime.Now;
            DateTime sozlesmeBitisTarihi = DateTime.Now;
            string sozlesmeTip = "";
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(myFoy.AV001_TI_BIL_ALACAK_NEDENCollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME>));
            for (int i = 0; i < myFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++)
            {
                for (int y = 0; y < myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.Count; y++)
                {
                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW[y], false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_SOZLESME_ALT_TIP));
                    if (myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW[y].BASLANGIC_TARIHI.HasValue)
                    {
                        sozlesmeBaslangicTarihi = myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW[y].BASLANGIC_TARIHI.Value;
                    }
                    if (myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW[y].BITIS_TARIHI.HasValue)
                    {
                        sozlesmeBitisTarihi = myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW[y].BITIS_TARIHI.Value;
                    }

                    sozlesmeTip = myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW[y].ALT_TIP_IDSource.ALT_TIP;

                    int aralik = (sozlesmeBitisTarihi - sozlesmeBaslangicTarihi).Days;

                    if (aralik <= 180)
                    {
                        donecek = false;
                    }
                    else
                    {
                        donecek = true;
                    }

                    if (sozlesmeTip == "Has�lat Kira S�zle�mesi")
                    {
                        donecek = null;
                    }
                }
            }

            return donecek;
        }
    }

    public class MuhatapGruplar
    {
        private int? _adliye;
        private int? _gorev;
        private TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> _muhataplar = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();
        private int? _no;

        public int? Adliye
        {
            get { return _adliye; }
            set { _adliye = value; }
        }

        public int? Gorev
        {
            get { return _gorev; }
            set { _gorev = value; }
        }

        public TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> Muhataplar
        {
            get { return _muhataplar; }
            set { _muhataplar = value; }
        }

        public int? No
        {
            get { return _no; }
            set { _no = value; }
        }

        public string GetMudurluk()
        {
            string val = "";
            if (Adliye.HasValue)
            {
                val = AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetByID(Adliye.Value).ADLIYE;
            }
            if (No.HasValue)
            {
                val += AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_NOProvider.GetByID(No.Value).NO;
            }
            if (No.HasValue)
            {
                val += AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_GOREVProvider.GetByID(Gorev.Value).GOREV;
            }
            return val;
        }
    }

    public class SorumlulukMiktarlari
    {
        public decimal AlacakTutari { get; set; }

        public string Borclu { get; set; }

        public int BorcluCariID { get; set; }

        public decimal SorumlulukMiktari { get; set; }

        public int SorumlulukMiktariParaBirimi { get; set; }
    }

    public class trf
    {
        public trf(string _ad, VarTypes _whosTaraf)
        {
            ad = _ad;
            WhosTaraf = _whosTaraf;
        }

        public string ad;
        public VarTypes WhosTaraf;
    }

    internal class hesaplar
    {
        public hesaplar(int? _dovizid, object _deger, string _aciklama, double faizOrani, int faizTipi)
        {
            dovizid = _dovizid;
            deger = _deger;
            aciklama = _aciklama;
            FaizOrani = faizOrani;
            FaizTip = faizTipi;
        }

        public hesaplar(int? _dovizid, object _deger, string _aciklama)
        {
            dovizid = _dovizid;
            deger = _deger;
            aciklama = _aciklama;
        }

        public hesaplar(int? _dovizid, object _deger, string _aciklama, AV001_TI_BIL_ALACAK_NEDEN aNeden, AV001_TI_BIL_FOY foy)
        {
            dovizid = _dovizid;
            deger = _deger;
            aciklama = _aciklama;
            AlacakNedeni = aNeden;

            FaizOrani = aNeden.TO_UYGULANACAK_FAIZ_ORANI;
            if (aNeden.ALACAK_FAIZ_TIP_ID.HasValue)
            {
                FaizTip = aNeden.ALACAK_FAIZ_TIP_ID.Value;
                FaizTipOrani = AvukatProDegiskenler.Icra.Degiskenler.FaizOraniVeTipiGetr(foy.TAKIP_TARIHI.Value, aNeden);
            }
        }

        private string aciklama;
        private object deger;
        private int? dovizid = 1;

        public string Aciklama
        {
            get { return aciklama; }
            set { aciklama = value; }
        }

        public AV001_TI_BIL_ALACAK_NEDEN AlacakNedeni { get; set; }

        public object Deger
        {
            get { return deger; }
            set { deger = value; }
        }

        public int? DovizId
        {
            get
            {
                if (!dovizid.HasValue) dovizid = 1;
                return dovizid;
            }
        }

        public double FaizOrani { get; set; }

        public int FaizTip { get; set; }

        public string FaizTipOrani { get; set; }
    }

    internal class icradegiskenleri
    {
        public icradegiskenleri(string _name, string _table, string _column)
        {
            this.name = _name;
            this.table = _table;
            this.column = _column;
        }

        private object _value = " ";
        private string column;

        private string name = " ";

        private string table;

        public string Name
        {
            get { return name; }
        }

        public object VaLUE
        {
            get { return _value; }
            set { _value = value; }
        }
    }

    internal class yaslar
    {
        private MevzuatKararLib.Entities.TList<MevzuatKararLib.Entities.TM_BIL_MEVZUAT_MADDE> maddeler = null;
        private MevzuatKararLib.Entities.TM_BIL_MEVZUAT yasa;
        private string yasaAdi;
        private int yasaid;

        public MevzuatKararLib.Entities.TList<MevzuatKararLib.Entities.TM_BIL_MEVZUAT_MADDE> Maddeler
        {
            get { return maddeler; }
        }

        public MevzuatKararLib.Entities.TM_BIL_MEVZUAT Yasa
        {
            get { return yasa; }
            set { yasa = value; }
        }

        public string YasaAdi
        {
            set { yasaAdi = value; }
        }

        public int YasaId
        {
            set { yasaid = value; }
        }
    }

    #endregion class
}