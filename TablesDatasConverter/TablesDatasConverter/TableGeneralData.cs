using AvukatProLib2.Entities;
using System;

namespace TablesDatasConverter
{
    public static class TableGeneralData
    {
        public static int GetAdliye(IEntity Record)
        {
            int returnValue = 0;
            string TableName = Record.TableName;
            switch (TableName)
            {
                case "AV001_TD_BIL_DAVA_NEDEN":
                    if (((AV001_TD_BIL_DAVA_NEDEN)Record).OLAY_ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TD_BIL_DAVA_NEDEN)Record).OLAY_ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TD_BIL_FOY":
                    if (((AV001_TD_BIL_FOY)Record).ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TD_BIL_FOY)Record).ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TD_BIL_HAZIRLIK":
                    if (((AV001_TD_BIL_HAZIRLIK)Record).ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TD_BIL_HAZIRLIK)Record).ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN":
                    if (((AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN)Record).OLAY_ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN)Record).OLAY_ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TD_BIL_HAZIRLIK_SUREC":
                    if (((AV001_TD_BIL_HAZIRLIK_SUREC)Record).ITIRAZ_ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TD_BIL_HAZIRLIK_SUREC)Record).ITIRAZ_ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TD_BIL_TEMYIZ":
                    if (((AV001_TD_BIL_TEMYIZ)Record).ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TD_BIL_TEMYIZ)Record).ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TD_BIL_TUTUKLANMA":
                    if (((AV001_TD_BIL_TUTUKLANMA)Record).HARICI_DAVA_ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TD_BIL_TUTUKLANMA)Record).HARICI_DAVA_ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI":
                    if (((AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI)Record).ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI)Record).ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TDI_BIL_FOY_SOZLESME":
                    if (((AV001_TDI_BIL_FOY_SOZLESME)Record).ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_FOY_SOZLESME)Record).ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TDI_BIL_IHTIYATI_TEDBIR":

                    // if (((AV001_TDI_BIL_IHTIYATI_TEDBIR)Record).ADLI_BIRIM_ADLIYE_ID.HasValue) {
                    returnValue = ((AV001_TDI_BIL_IHTIYATI_TEDBIR)Record).ADLI_BIRIM_ADLIYE_ID;//.Value;
                    // }
                    break;

                case "AV001_TDI_BIL_IS":
                    if (((AV001_TDI_BIL_IS)Record).ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_IS)Record).ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TDI_BIL_KAYIT_ILISKI_DETAY":
                    if (((AV001_TDI_BIL_KAYIT_ILISKI_DETAY)Record).HEDEF_ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_KAYIT_ILISKI_DETAY)Record).HEDEF_ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TDI_BIL_SOZLESME":
                    if (((AV001_TDI_BIL_SOZLESME)Record).YARGILAMA_ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_SOZLESME)Record).YARGILAMA_ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TDI_BIL_TEBLIGAT":
                    if (((AV001_TDI_BIL_TEBLIGAT)Record).ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_TEBLIGAT)Record).ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TDI_BIL_TEMSIL":
                    if (((AV001_TDI_BIL_TEMSIL)Record).ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_TEMSIL)Record).ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TDI_BIL_TESPIT":
                    if (((AV001_TDI_BIL_TESPIT)Record).ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_TESPIT)Record).ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TDIE_BIL_ASAMA":
                    if (((AV001_TDIE_BIL_ASAMA)Record).ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TDIE_BIL_ASAMA)Record).ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TDIE_BIL_BELGE":
                    if (((AV001_TDIE_BIL_BELGE)Record).ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TDIE_BIL_BELGE)Record).ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TI_BIL_DAVA_OZET":
                    if (((AV001_TI_BIL_DAVA_OZET)Record).ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_DAVA_OZET)Record).ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TI_BIL_FOY":
                    if (((AV001_TI_BIL_FOY)Record).ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_FOY)Record).ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TI_BIL_HACIZ":
                    if (((AV001_TI_BIL_HACIZ)Record).TALIMAT_ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_HACIZ)Record).TALIMAT_ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TI_BIL_HACIZ_ISTIRAK":
                    if (((AV001_TI_BIL_HACIZ_ISTIRAK)Record).TALIMAT_ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_HACIZ_ISTIRAK)Record).TALIMAT_ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TI_BIL_HACIZ_MASTER":
                    if (((AV001_TI_BIL_HACIZ_MASTER)Record).TALIMAT_ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_HACIZ_MASTER)Record).TALIMAT_ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TI_BIL_IHTIYATI_HACIZ":
                    if (((AV001_TI_BIL_IHTIYATI_HACIZ)Record).ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_IHTIYATI_HACIZ)Record).ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TI_BIL_ILAM_MAHKEMESI":

                    // if (((AV001_TI_BIL_ILAM_MAHKEMESI)Record).ADLI_BIRIM_ADLIYE_ID.HasValue) {
                    returnValue = ((AV001_TI_BIL_ILAM_MAHKEMESI)Record).ADLI_BIRIM_ADLIYE_ID;//.Value;
                    // }
                    break;

                case "AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN":
                    returnValue = ((AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN)Record).ADLI_BIRIM_ADLIYE_ID.Value;
                    break;

                case "AV001_TI_BIL_SATIS_MASTER":
                    if (((AV001_TI_BIL_SATIS_MASTER)Record).TALIMAT_ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_SATIS_MASTER)Record).TALIMAT_ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TI_BIL_SIKAYET":
                    if (((AV001_TI_BIL_SIKAYET)Record).SIKAYET_EDILEN_ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_SIKAYET)Record).SIKAYET_EDILEN_ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                case "AV001_TI_BIL_TALIMAT":
                    if (((AV001_TI_BIL_TALIMAT)Record).ADLI_BIRIM_ADLIYE_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_TALIMAT)Record).ADLI_BIRIM_ADLIYE_ID.Value;
                    }
                    break;

                default:
                    returnValue = 0;
                    break;
            }
            return returnValue;
        }

        public static int GetBirimNo(IEntity Record)
        {
            int returnValue = 0;
            string TableName = Record.TableName;
            switch (TableName)
            {
                case "AV001_TD_BIL_FOY":
                    if (((AV001_TD_BIL_FOY)Record).ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TD_BIL_FOY)Record).ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TD_BIL_HAZIRLIK":
                    if (((AV001_TD_BIL_HAZIRLIK)Record).ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TD_BIL_HAZIRLIK)Record).ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TD_BIL_HAZIRLIK_SUREC":
                    if (((AV001_TD_BIL_HAZIRLIK_SUREC)Record).ITIRAZ_ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TD_BIL_HAZIRLIK_SUREC)Record).ITIRAZ_ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TD_BIL_TEMYIZ":
                    if (((AV001_TD_BIL_TEMYIZ)Record).ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TD_BIL_TEMYIZ)Record).ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TDI_BIL_CARI_SABIKA":
                    if (((AV001_TDI_BIL_CARI_SABIKA)Record).MAHKEME_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_CARI_SABIKA)Record).MAHKEME_NO_ID.Value;
                    }
                    break;

                case "AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI":
                    if (((AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI)Record).ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI)Record).ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TDI_BIL_FOY_SOZLESME":
                    if (((AV001_TDI_BIL_FOY_SOZLESME)Record).ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_FOY_SOZLESME)Record).ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TDI_BIL_IHTIYATI_TEDBIR":
                    if (((AV001_TDI_BIL_IHTIYATI_TEDBIR)Record).ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_IHTIYATI_TEDBIR)Record).ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TDI_BIL_IS":
                    if (((AV001_TDI_BIL_IS)Record).ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_IS)Record).ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TDI_BIL_KAYIT_ILISKI_DETAY":
                    if (((AV001_TDI_BIL_KAYIT_ILISKI_DETAY)Record).HEDEF_ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_KAYIT_ILISKI_DETAY)Record).HEDEF_ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TDI_BIL_SOZLESME":
                    if (((AV001_TDI_BIL_SOZLESME)Record).ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_SOZLESME)Record).ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TDI_BIL_TEBLIGAT":
                    if (((AV001_TDI_BIL_TEBLIGAT)Record).ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_TEBLIGAT)Record).ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TDI_BIL_TEMSIL":
                    if (((AV001_TDI_BIL_TEMSIL)Record).ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_TEMSIL)Record).ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TDI_BIL_TESPIT":
                    if (((AV001_TDI_BIL_TESPIT)Record).ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_TESPIT)Record).ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TDIE_BIL_ASAMA":
                    if (((AV001_TDIE_BIL_ASAMA)Record).ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TDIE_BIL_ASAMA)Record).ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TDIE_BIL_BELGE":
                    if (((AV001_TDIE_BIL_BELGE)Record).ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TDIE_BIL_BELGE)Record).ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TI_BIL_DAVA_OZET":
                    if (((AV001_TI_BIL_DAVA_OZET)Record).ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_DAVA_OZET)Record).ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TI_BIL_FOY":
                    if (((AV001_TI_BIL_FOY)Record).ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_FOY)Record).ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TI_BIL_HACIZ":
                    if (((AV001_TI_BIL_HACIZ)Record).TALIMAT_ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_HACIZ)Record).TALIMAT_ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TI_BIL_HACIZ_ISTIRAK":
                    if (((AV001_TI_BIL_HACIZ_ISTIRAK)Record).TALIMAT_ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_HACIZ_ISTIRAK)Record).TALIMAT_ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TI_BIL_HACIZ_MASTER":
                    if (((AV001_TI_BIL_HACIZ_MASTER)Record).TALIMAT_ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_HACIZ_MASTER)Record).TALIMAT_ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TI_BIL_IHTIYATI_HACIZ":
                    if (((AV001_TI_BIL_IHTIYATI_HACIZ)Record).ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_IHTIYATI_HACIZ)Record).ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TI_BIL_ILAM_MAHKEMESI":
                    if (((AV001_TI_BIL_ILAM_MAHKEMESI)Record).ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_ILAM_MAHKEMESI)Record).ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN":
                    returnValue = ((AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN)Record).ADLI_BIRIM_NO_ID.Value;
                    break;

                case "AV001_TI_BIL_SATIS_MASTER":
                    if (((AV001_TI_BIL_SATIS_MASTER)Record).TALIMAT_ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_SATIS_MASTER)Record).TALIMAT_ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TI_BIL_SIKAYET":
                    if (((AV001_TI_BIL_SIKAYET)Record).SIKAYET_EDILEN_ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_SIKAYET)Record).SIKAYET_EDILEN_ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "AV001_TI_BIL_TALIMAT":
                    if (((AV001_TI_BIL_TALIMAT)Record).ADLI_BIRIM_NO_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_TALIMAT)Record).ADLI_BIRIM_NO_ID.Value;
                    }
                    break;

                case "TDI_KOD_DAVA_ADI":
                    if (((TDI_KOD_DAVA_ADI)Record).YUKSEK_MAHKEME_DAIRE_NO_ID.HasValue)
                    {
                        returnValue = ((TDI_KOD_DAVA_ADI)Record).YUKSEK_MAHKEME_DAIRE_NO_ID.Value;
                    }
                    break;

                default:
                    returnValue = 0;
                    break;
            }
            return returnValue;
        }

        public static string GetEsasNo(IEntity Record)
        {
            string returnValue = "";
            string TableName = Record.TableName;
            switch (TableName)
            {
                case "AV001_TD_BIL_FOY":
                    returnValue = ((AV001_TD_BIL_FOY)Record).ESAS_NO.ToString();
                    break;

                case "AV001_TD_BIL_HAZIRLIK":
                    returnValue = ((AV001_TD_BIL_HAZIRLIK)Record).HAZIRLIK_ESAS_NO.ToString();
                    break;

                case "AV001_TD_BIL_HAZIRLIK_SUREC":
                    returnValue = ((AV001_TD_BIL_HAZIRLIK_SUREC)Record).ITIRAZ_ESAS_NO.ToString();
                    break;

                case "AV001_TD_BIL_TEMYIZ":
                    returnValue = ((AV001_TD_BIL_TEMYIZ)Record).ESAS_NO.ToString();
                    break;

                case "AV001_TD_BIL_TUTUKLANMA":
                    returnValue = ((AV001_TD_BIL_TUTUKLANMA)Record).HARICI_DAVA_ESAS_NO.ToString();
                    break;

                case "AV001_TDI_BIL_CARI_SABIKA":
                    returnValue = ((AV001_TDI_BIL_CARI_SABIKA)Record).SABIKA_KARAR_ESAS_NO.ToString();
                    break;

                case "AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI":
                    returnValue = ((AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI)Record).ESAS_NO.ToString();
                    break;

                case "AV001_TDI_BIL_IHTIYATI_TEDBIR":
                    returnValue = ((AV001_TDI_BIL_IHTIYATI_TEDBIR)Record).ESAS_NO.ToString();
                    break;

                case "AV001_TDI_BIL_IS":
                    returnValue = ((AV001_TDI_BIL_IS)Record).ESAS_NO.ToString();
                    break;

                case "AV001_TDI_BIL_KAYIT_ILISKI_DETAY":
                    returnValue = ((AV001_TDI_BIL_KAYIT_ILISKI_DETAY)Record).HEDEF_ESAS_NO.ToString();
                    break;

                case "AV001_TDI_BIL_TEBLIGAT":
                    returnValue = ((AV001_TDI_BIL_TEBLIGAT)Record).TEBLIGAT_ESAS_NO.ToString();
                    break;

                case "AV001_TDI_BIL_TESPIT":
                    returnValue = ((AV001_TDI_BIL_TESPIT)Record).ESAS_NO.ToString();
                    break;

                case "AV001_TDIE_BIL_ASAMA":
                    returnValue = ((AV001_TDIE_BIL_ASAMA)Record).ESAS_NO.ToString();
                    break;

                case "AV001_TDIE_BIL_BELGE":
                    returnValue = ((AV001_TDIE_BIL_BELGE)Record).ESAS_NO.ToString();
                    break;

                case "AV001_TI_BIL_DAVA_OZET":
                    returnValue = ((AV001_TI_BIL_DAVA_OZET)Record).DAVA_ESAS_NO.ToString();
                    break;

                case "AV001_TI_BIL_FOY":
                    returnValue = ((AV001_TI_BIL_FOY)Record).ESAS_NO.ToString();
                    break;

                case "AV001_TI_BIL_HACIZ":
                    returnValue = ((AV001_TI_BIL_HACIZ)Record).TALIMAT_ESAS_NO.ToString();
                    break;

                case "AV001_TI_BIL_HACIZ_ISTIRAK":
                    returnValue = ((AV001_TI_BIL_HACIZ_ISTIRAK)Record).TALIMAT_ICRA_ESAS_NO.ToString();
                    break;

                case "AV001_TI_BIL_HACIZ_MASTER":
                    returnValue = ((AV001_TI_BIL_HACIZ_MASTER)Record).TALIMAT_ESAS_NO.ToString();
                    break;

                case "AV001_TI_BIL_IHTIYATI_HACIZ":
                    returnValue = ((AV001_TI_BIL_IHTIYATI_HACIZ)Record).ESAS_NO.ToString();
                    break;

                case "AV001_TI_BIL_ILAM_MAHKEMESI":
                    returnValue = ((AV001_TI_BIL_ILAM_MAHKEMESI)Record).ESAS_NO.ToString();
                    break;

                case "AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN":
                    returnValue = ((AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN)Record).ITIRAZ_ESAS_NO.ToString();
                    break;

                case "AV001_TI_BIL_MEHIL":
                    returnValue = ((AV001_TI_BIL_MEHIL)Record).YARGITAY_MEHIL_ESAS_NO.ToString();
                    break;

                case "AV001_TI_BIL_SIKAYET":
                    returnValue = ((AV001_TI_BIL_SIKAYET)Record).SIKAYET_EDILEN_ADLI_BIRIM_ESAS_NO.ToString();
                    break;

                case "AV001_TI_BIL_TALIMAT":
                    returnValue = ((AV001_TI_BIL_TALIMAT)Record).TALIMAT_ESAS_NO.ToString();
                    break;

                case "TDIE_TEMP_RAPOR_MUHASEBE1":
                    returnValue = ((TDIE_TEMP_RAPOR_MUHASEBE1)Record).ESAS_NO.ToString();
                    break;

                default:
                    returnValue = string.Empty;
                    break;
            }
            return returnValue;
        }

        public static int GetGorev(IEntity Record)
        {
            int returnValue = 0;
            string TableName = Record.TableName;
            switch (TableName)
            {
                case "AV001_TD_BIL_FOY":

                    if (((AV001_TD_BIL_FOY)Record).ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TD_BIL_FOY)Record).ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TD_BIL_HAZIRLIK":

                    if (((AV001_TD_BIL_HAZIRLIK)Record).ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TD_BIL_HAZIRLIK)Record).ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TD_BIL_HAZIRLIK_SUREC":

                    if (((AV001_TD_BIL_HAZIRLIK_SUREC)Record).ITIRAZ_ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TD_BIL_HAZIRLIK_SUREC)Record).ITIRAZ_ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TD_BIL_TEMYIZ":

                    if (((AV001_TD_BIL_TEMYIZ)Record).ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TD_BIL_TEMYIZ)Record).ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TD_BIL_TUTUKLANMA":

                    if (((AV001_TD_BIL_TUTUKLANMA)Record).HARICI_DAVA_ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TD_BIL_TUTUKLANMA)Record).HARICI_DAVA_ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI":

                    if (((AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI)Record).ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI)Record).ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TDI_BIL_FOY_SOZLESME":

                    if (((AV001_TDI_BIL_FOY_SOZLESME)Record).ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_FOY_SOZLESME)Record).ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TDI_BIL_IHTIYATI_TEDBIR":

                    // if (((AV001_TDI_BIL_IHTIYATI_TEDBIR)Record).ADLI_BIRIM_GOREV_ID.HasValue) {
                    returnValue = ((AV001_TDI_BIL_IHTIYATI_TEDBIR)Record).ADLI_BIRIM_GOREV_ID;//.Value;
                    // }

                    break;

                case "AV001_TDI_BIL_IS":

                    if (((AV001_TDI_BIL_IS)Record).ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_IS)Record).ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TDI_BIL_KAYIT_ILISKI_DETAY":

                    if (((AV001_TDI_BIL_KAYIT_ILISKI_DETAY)Record).HEDEF_ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_KAYIT_ILISKI_DETAY)Record).HEDEF_ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TDI_BIL_SOZLESME":

                    if (((AV001_TDI_BIL_SOZLESME)Record).ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_SOZLESME)Record).ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TDI_BIL_TEBLIGAT":

                    if (((AV001_TDI_BIL_TEBLIGAT)Record).ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_TEBLIGAT)Record).ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TDI_BIL_TEMSIL":

                    if (((AV001_TDI_BIL_TEMSIL)Record).ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_TEMSIL)Record).ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TDI_BIL_TESPIT":

                    if (((AV001_TDI_BIL_TESPIT)Record).ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TDI_BIL_TESPIT)Record).ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TDIE_BIL_ASAMA":

                    if (((AV001_TDIE_BIL_ASAMA)Record).ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TDIE_BIL_ASAMA)Record).ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TDIE_BIL_BELGE":

                    if (((AV001_TDIE_BIL_BELGE)Record).ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TDIE_BIL_BELGE)Record).ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TDIE_BIL_SABLON_RAPOR":

                    if (((AV001_TDIE_BIL_SABLON_RAPOR)Record).ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TDIE_BIL_SABLON_RAPOR)Record).ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TDIE_BIL_SABLON_SECILI_BELGE":

                    if (((AV001_TDIE_BIL_SABLON_SECILI_BELGE)Record).ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TDIE_BIL_SABLON_SECILI_BELGE)Record).ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TI_BIL_DAVA_OZET":

                    if (((AV001_TI_BIL_DAVA_OZET)Record).ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_DAVA_OZET)Record).ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TI_BIL_FOY":

                    if (((AV001_TI_BIL_FOY)Record).ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_FOY)Record).ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TI_BIL_HACIZ":

                    if (((AV001_TI_BIL_HACIZ)Record).TALIMAT_ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_HACIZ)Record).TALIMAT_ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TI_BIL_HACIZ_ISTIRAK":

                    if (((AV001_TI_BIL_HACIZ_ISTIRAK)Record).TALIMAT_ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_HACIZ_ISTIRAK)Record).TALIMAT_ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TI_BIL_HACIZ_MASTER":

                    if (((AV001_TI_BIL_HACIZ_MASTER)Record).TALIMAT_ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_HACIZ_MASTER)Record).TALIMAT_ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TI_BIL_IHTIYATI_HACIZ":

                    if (((AV001_TI_BIL_IHTIYATI_HACIZ)Record).ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_IHTIYATI_HACIZ)Record).ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TI_BIL_ILAM_MAHKEMESI":

                    // if (((AV001_TI_BIL_ILAM_MAHKEMESI)Record).ADLI_BIRIM_GOREV_ID.HasValue) {
                    returnValue = ((AV001_TI_BIL_ILAM_MAHKEMESI)Record).ADLI_BIRIM_GOREV_ID;//.Value;
                    // }

                    break;

                case "AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN":

                    returnValue = ((AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN)Record).ADLI_BIRIM_GOREV_ID.Value;

                    break;

                case "AV001_TI_BIL_SATIS_MASTER":

                    if (((AV001_TI_BIL_SATIS_MASTER)Record).TALIMAT_ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_SATIS_MASTER)Record).TALIMAT_ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TI_BIL_SIKAYET":

                    if (((AV001_TI_BIL_SIKAYET)Record).SIKAYET_EDILEN_ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_SIKAYET)Record).SIKAYET_EDILEN_ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "AV001_TI_BIL_TALIMAT":

                    if (((AV001_TI_BIL_TALIMAT)Record).ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((AV001_TI_BIL_TALIMAT)Record).ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "TD_CET_CMUK_VEKALET_MAKTU":

                    returnValue = ((TD_CET_CMUK_VEKALET_MAKTU)Record).ADLI_BIRIM_GOREV_ID;

                    break;

                case "TD_CET_GOREVLI_MAHKEME_BELIRLE":

                    if (((TD_CET_GOREVLI_MAHKEME_BELIRLE)Record).ADLI_BIRIM_GOREV_ID.HasValue)
                    {
                        returnValue = ((TD_CET_GOREVLI_MAHKEME_BELIRLE)Record).ADLI_BIRIM_GOREV_ID.Value;
                    }

                    break;

                case "TDI_KOD_DAVA_ADI":

                    if (((TDI_KOD_DAVA_ADI)Record).YUKSEK_MAHKEME_GOREV_ID.HasValue)
                    {
                        returnValue = ((TDI_KOD_DAVA_ADI)Record).YUKSEK_MAHKEME_GOREV_ID.Value;
                    }

                    break;

                default:
                    returnValue = 0;
                    break;
            }
            return returnValue;
        }

        public static string GetReferansNo(IEntity Record)
        {
            string returnValue = string.Empty;
            string TableName = Record.TableName;
            switch (TableName)
            {
                case "AV001_TD_BIL_CELSE":
                    returnValue = ((AV001_TD_BIL_CELSE)Record).CELSE_REFERANS_NO;
                    break;

                case "AV001_TD_BIL_DAVA_NEDEN":
                    returnValue = ((AV001_TD_BIL_DAVA_NEDEN)Record).REFERANS_NO2;
                    break;

                case "AV001_TD_BIL_FOY":
                    returnValue = ((AV001_TD_BIL_FOY)Record).REFERANS_NO3;
                    break;

                case "AV001_TD_BIL_HAZIRLIK":
                    if (((AV001_TD_BIL_HAZIRLIK)Record).REFERANS_NO != string.Empty)
                    {
                        returnValue = ((AV001_TD_BIL_HAZIRLIK)Record).REFERANS_NO;
                    }
                    break;

                case "AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN":
                    if (((AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN)Record).REFERANS_NO_2 != string.Empty)
                    {
                        returnValue = ((AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN)Record).REFERANS_NO_2;
                    }
                    break;

                case "AV001_TD_BIL_KANIT":
                    returnValue = ((AV001_TD_BIL_KANIT)Record).KANIT_REFERANS_NO;
                    break;

                case "AV001_TDI_BIL_CARI_HESAP":
                    returnValue = ((AV001_TDI_BIL_CARI_HESAP)Record).REFERANS_NO;
                    break;

                case "AV001_TDI_BIL_FATURA":
                    returnValue = ((AV001_TDI_BIL_FATURA)Record).REFERANS_NO;
                    break;

                case "AV001_TDI_BIL_FOY_MUHASEBE":
                    returnValue = ((AV001_TDI_BIL_FOY_MUHASEBE)Record).REFERANS_NO;
                    break;

                case "AV001_TDI_BIL_IS":
                    returnValue = DateTime.Today.Year + System.Guid.NewGuid().ToString("N").Substring(0, 5).ToUpper();
                    break;

                case "AV001_TDI_BIL_IS_GOREV":
                    returnValue = ((AV001_TDI_BIL_IS_GOREV)Record).REFERANS_NO;
                    break;

                case "AV001_TDI_BIL_IS_KOSUL":
                    returnValue = ((AV001_TDI_BIL_IS_KOSUL)Record).REFERANS_NO;
                    break;

                case "AV001_TDI_BIL_KASA":
                    returnValue = ((AV001_TDI_BIL_KASA)Record).REFERANS_NO;
                    break;

                case "AV001_TDI_BIL_MASRAF_AVANS":
                    returnValue = ((AV001_TDI_BIL_MASRAF_AVANS)Record).REFERANS_NO;
                    break;

                case "AV001_TDI_BIL_MUHASEBE":
                    returnValue = ((AV001_TDI_BIL_MUHASEBE)Record).REFERANS_NO;
                    break;

                case "AV001_TDI_BIL_RUCU":
                    returnValue = ((AV001_TDI_BIL_RUCU)Record).REFERANS_NO3;
                    break;

                case "AV001_TDI_BIL_TEBLIGAT":
                    returnValue = ((AV001_TDI_BIL_TEBLIGAT)Record).TEBLIGAT_REFERANS_NO;
                    break;

                case "AV001_TDI_BIL_TEMINAT_MEKTUP":
                    returnValue = ((AV001_TDI_BIL_TEMINAT_MEKTUP)Record).REFERANS_NO;
                    break;

                case "AV001_TDIE_BIL_BELGE":
                    returnValue = ((AV001_TDIE_BIL_BELGE)Record).BELGE_REFERANS_NO;
                    break;

                case "AV001_TDIE_BIL_KLAVYE_MOUSE_MAKRO":
                    returnValue = ((AV001_TDIE_BIL_KLAVYE_MOUSE_MAKRO)Record).REFERANS_NO;
                    break;

                case "AV001_TDIE_BIL_MESAJ":
                    returnValue = ((AV001_TDIE_BIL_MESAJ)Record).REFERANS_NO;
                    break;

                case "AV001_TDIE_BIL_PROJE":
                    returnValue = ((AV001_TDIE_BIL_PROJE)Record).REFERANS_NO3;
                    break;

                case "AV001_TDIE_BIL_REFERANS_DEGER":
                    returnValue = ((AV001_TDIE_BIL_REFERANS_DEGER)Record).REFERANS_NO.ToString();
                    break;

                case "AV001_TI_BIL_ALACAK_NEDEN":
                    if (((AV001_TI_BIL_ALACAK_NEDEN)Record).REFERANS_NO3 != string.Empty)
                    {
                        returnValue = ((AV001_TI_BIL_ALACAK_NEDEN)Record).REFERANS_NO3;
                    }
                    break;

                case "AV001_TI_BIL_FOY":
                    returnValue = ((AV001_TI_BIL_FOY)Record).REFERANS_NO3;
                    break;

                case "AV001_TDI_BIL_HATIRLAT":
                    returnValue = ((AV001_TDI_BIL_HATIRLAT)Record).REFERANS_NO;
                    break;

                case "TDI_KOD_DAVA_ADI":
                    returnValue = ((TDI_KOD_DAVA_ADI)Record).REFERANS_NO;
                    break;

                case "TDI_KOD_IS_GOREV_SONUC_TIP":
                    returnValue = ((TDI_KOD_IS_GOREV_SONUC_TIP)Record).REFERANS_NO;
                    break;

                case "TDI_KOD_IS_GOREV_TIP":
                    returnValue = ((TDI_KOD_IS_GOREV_TIP)Record).REFERANS_NO;
                    break;

                case "TDI_KOD_IS_KOSUL_TIP":
                    returnValue = ((TDI_KOD_IS_KOSUL_TIP)Record).REFERANS_NO;
                    break;

                case "TDIE_KOD_MESAJ_TIP":
                    returnValue = ((TDIE_KOD_MESAJ_TIP)Record).REFERANS_NO;
                    break;

                default:
                    returnValue = string.Empty;
                    break;
            }
            return returnValue;
        }

        //public static string GetEsasNo(IEntity Record)
        //{
        //    string returnValue = "";
        //    string TableName = Record.TableName;
        //    switch (TableName)
        //    {
        //        case "AV001_TD_BIL_FOY":
        //            returnValue = ((AV001_TD_BIL_FOY)Record).ESAS_NO.ToString();
        //            break;
        //        case "AV001_TD_BIL_HAZIRLIK":
        //            returnValue = ((AV001_TD_BIL_HAZIRLIK)Record).HAZIRLIK_ESAS_NO.ToString();
        //            break;
        //        case "AV001_TD_BIL_HAZIRLIK_SUREC":
        //            returnValue = ((AV001_TD_BIL_HAZIRLIK_SUREC)Record).ITIRAZ_ESAS_NO.ToString();
        //            break;
        //        case "AV001_TD_BIL_TEMYIZ":
        //            returnValue = ((AV001_TD_BIL_TEMYIZ)Record).ESAS_NO.ToString();
        //            break;
        //        case "AV001_TD_BIL_TUTUKLANMA":
        //            returnValue = ((AV001_TD_BIL_TUTUKLANMA)Record).HARICI_DAVA_ESAS_NO.ToString();
        //            break;
        //        case "AV001_TDI_BIL_CARI_SABIKA":
        //            returnValue = ((AV001_TDI_BIL_CARI_SABIKA)Record).SABIKA_KARAR_ESAS_NO.ToString();
        //            break;
        //        case "AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI":
        //            returnValue = ((AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI)Record).ESAS_NO.ToString();
        //            break;
        //        case "AV001_TDI_BIL_IHTIYATI_TEDBIR":
        //            returnValue = ((AV001_TDI_BIL_IHTIYATI_TEDBIR)Record).ESAS_NO.ToString();
        //            break;
        //        case "AV001_TDI_BIL_IS":
        //            returnValue = ((AV001_TDI_BIL_IS)Record).ESAS_NO.ToString();
        //            break;
        //        case "AV001_TDI_BIL_KAYIT_ILISKI_DETAY":
        //            returnValue = ((AV001_TDI_BIL_KAYIT_ILISKI_DETAY)Record).HEDEF_ESAS_NO.ToString();
        //            break;
        //        case "AV001_TDI_BIL_TEBLIGAT":
        //            returnValue = ((AV001_TDI_BIL_TEBLIGAT)Record).TEBLIGAT_ESAS_NO.ToString();
        //            break;
        //        case "AV001_TDI_BIL_TESPIT":
        //            returnValue = ((AV001_TDI_BIL_TESPIT)Record).ESAS_NO.ToString();
        //            break;
        //        case "AV001_TDIE_BIL_ASAMA":
        //            returnValue = ((AV001_TDIE_BIL_ASAMA)Record).ESAS_NO.ToString();
        //            break;
        //        case "AV001_TDIE_BIL_BELGE":
        //            returnValue = ((AV001_TDIE_BIL_BELGE)Record).ESAS_NO.ToString();
        //            break;
        //        case "AV001_TI_BIL_DAVA_OZET":
        //            returnValue = ((AV001_TI_BIL_DAVA_OZET)Record).DAVA_ESAS_NO.ToString();
        //            break;
        //        case "AV001_TI_BIL_FOY":
        //            returnValue = ((AV001_TI_BIL_FOY)Record).ESAS_NO.ToString();
        //            break;
        //        case "AV001_TI_BIL_HACIZ":
        //            returnValue = ((AV001_TI_BIL_HACIZ)Record).TALIMAT_ESAS_NO.ToString();
        //            break;
        //        case "AV001_TI_BIL_HACIZ_ISTIRAK":
        //            returnValue = ((AV001_TI_BIL_HACIZ_ISTIRAK)Record).TALIMAT_ICRA_ESAS_NO.ToString();
        //            break;
        //        case "AV001_TI_BIL_HACIZ_MASTER":
        //            returnValue = ((AV001_TI_BIL_HACIZ_MASTER)Record).TALIMAT_ESAS_NO.ToString();
        //            break;
        //        case "AV001_TI_BIL_IHTIYATI_HACIZ":
        //            returnValue = ((AV001_TI_BIL_IHTIYATI_HACIZ)Record).ESAS_NO.ToString();
        //            break;
        //        case "AV001_TI_BIL_ILAM_MAHKEMESI":
        //            returnValue = ((AV001_TI_BIL_ILAM_MAHKEMESI)Record).ESAS_NO.ToString();
        //            break;
        //        case "AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN":
        //            returnValue = ((AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN)Record).ITIRAZ_ESAS_NO.ToString();
        //            break;
        //        case "AV001_TI_BIL_MEHIL":
        //            returnValue = ((AV001_TI_BIL_MEHIL)Record).YARGITAY_MEHIL_ESAS_NO.ToString();
        //            break;
        //        case "AV001_TI_BIL_SIKAYET":
        //            returnValue = ((AV001_TI_BIL_SIKAYET)Record).SIKAYET_EDILEN_ADLI_BIRIM_ESAS_NO.ToString();
        //            break;
        //        case "AV001_TI_BIL_TALIMAT":
        //            returnValue = ((AV001_TI_BIL_TALIMAT)Record).TALIMAT_ESAS_NO.ToString();
        //            break;

        // case "TDIE_TEMP_RAPOR_MUHASEBE1": returnValue =
        // ((TDIE_TEMP_RAPOR_MUHASEBE1)Record).ESAS_NO.ToString(); break;

        // default:
        // returnValue = string.Empty; break; } return returnValue;
        //}

        //public static int GetAdliye(IEntity Record)
        //{
        //    int returnValue = 0;
        //    string TableName = Record.TableName;
        //    switch (TableName)
        //    {
        //        case "AV001_TD_BIL_DAVA_NEDEN":
        //            returnValue = ((AV001_TD_BIL_DAVA_NEDEN)Record).OLAY_ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TD_BIL_FOY":
        //            returnValue = ((AV001_TD_BIL_FOY)Record).ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TD_BIL_HAZIRLIK":
        //            returnValue = ((AV001_TD_BIL_HAZIRLIK)Record).ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN":
        //            returnValue = ((AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN)Record).OLAY_ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TD_BIL_HAZIRLIK_SUREC":
        //            returnValue = ((AV001_TD_BIL_HAZIRLIK_SUREC)Record).ITIRAZ_ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TD_BIL_TEMYIZ":
        //            returnValue = ((AV001_TD_BIL_TEMYIZ)Record).ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TD_BIL_TUTUKLANMA":
        //            returnValue = ((AV001_TD_BIL_TUTUKLANMA)Record).HARICI_DAVA_ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI":
        //            returnValue = ((AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI)Record).ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TDI_BIL_FOY_SOZLESME":
        //            returnValue = ((AV001_TDI_BIL_FOY_SOZLESME)Record).ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TDI_BIL_IHTIYATI_TEDBIR":
        //            returnValue = ((AV001_TDI_BIL_IHTIYATI_TEDBIR)Record).ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TDI_BIL_IS":
        //            returnValue = ((AV001_TDI_BIL_IS)Record).ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TDI_BIL_KAYIT_ILISKI_DETAY":
        //            returnValue = ((AV001_TDI_BIL_KAYIT_ILISKI_DETAY)Record).HEDEF_ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TDI_BIL_SOZLESME":
        //            returnValue = ((AV001_TDI_BIL_SOZLESME)Record).YARGILAMA_ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TDI_BIL_TEBLIGAT":
        //            returnValue = ((AV001_TDI_BIL_TEBLIGAT)Record).ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TDI_BIL_TEMSIL":
        //            returnValue = ((AV001_TDI_BIL_TEMSIL)Record).ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TDI_BIL_TESPIT":
        //            returnValue = ((AV001_TDI_BIL_TESPIT)Record).ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TDIE_BIL_ASAMA":
        //            returnValue = ((AV001_TDIE_BIL_ASAMA)Record).ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TDIE_BIL_BELGE":
        //            returnValue = ((AV001_TDIE_BIL_BELGE)Record).ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_DAVA_OZET":
        //            returnValue = ((AV001_TI_BIL_DAVA_OZET)Record).ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_FOY":
        //            returnValue = ((AV001_TI_BIL_FOY)Record).ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_HACIZ":
        //            returnValue = ((AV001_TI_BIL_HACIZ)Record).TALIMAT_ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_HACIZ_ISTIRAK":
        //            returnValue = ((AV001_TI_BIL_HACIZ_ISTIRAK)Record).TALIMAT_ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_HACIZ_MASTER":
        //            returnValue = ((AV001_TI_BIL_HACIZ_MASTER)Record).TALIMAT_ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_IHTIYATI_HACIZ":
        //            returnValue = ((AV001_TI_BIL_IHTIYATI_HACIZ)Record).ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_ILAM_MAHKEMESI":
        //            returnValue = ((AV001_TI_BIL_ILAM_MAHKEMESI)Record).ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN":
        //            returnValue = ((AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN)Record).ADLI_BIRIM_ADLIYE_ID;
        //            break;
        //        case "AV001_TI_BIL_SATIS_MASTER":
        //            returnValue = ((AV001_TI_BIL_SATIS_MASTER)Record).TALIMAT_ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_SIKAYET":
        //            returnValue = ((AV001_TI_BIL_SIKAYET)Record).SIKAYET_EDILEN_ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_TALIMAT":
        //            returnValue = ((AV001_TI_BIL_TALIMAT)Record).ADLI_BIRIM_ADLIYE_ID.Value;
        //            break;

        // default:
        // returnValue = 0; break; } return returnValue;
        //}

        //public static int GetGorev(IEntity Record)
        //{
        //    int returnValue = 0;
        //    string TableName = Record.TableName;
        //    switch (TableName)
        //    {
        //        case "AV001_TD_BIL_FOY":
        //            if (((AV001_TD_BIL_FOY)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TD_BIL_FOY)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TD_BIL_HAZIRLIK":
        //            if (((AV001_TD_BIL_HAZIRLIK)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TD_BIL_HAZIRLIK)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TD_BIL_HAZIRLIK_SUREC":
        //            if (((AV001_TD_BIL_HAZIRLIK_SUREC)Record).ITIRAZ_ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TD_BIL_HAZIRLIK_SUREC)Record).ITIRAZ_ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TD_BIL_TEMYIZ":
        //            if (((AV001_TD_BIL_TEMYIZ)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TD_BIL_TEMYIZ)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TD_BIL_TUTUKLANMA":
        //            if (((AV001_TD_BIL_TUTUKLANMA)Record).HARICI_DAVA_ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TD_BIL_TUTUKLANMA)Record).HARICI_DAVA_ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI":
        //            if (((AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TDI_BIL_FOY_SOZLESME":
        //            if (((AV001_TDI_BIL_FOY_SOZLESME)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TDI_BIL_FOY_SOZLESME)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TDI_BIL_IHTIYATI_TEDBIR":
        //            if (((AV001_TDI_BIL_IHTIYATI_TEDBIR)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TDI_BIL_IHTIYATI_TEDBIR)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TDI_BIL_IS":
        //            if (((AV001_TDI_BIL_IS)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TDI_BIL_IS)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TDI_BIL_KAYIT_ILISKI_DETAY":
        //            if (((AV001_TDI_BIL_KAYIT_ILISKI_DETAY)Record).HEDEF_ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TDI_BIL_KAYIT_ILISKI_DETAY)Record).HEDEF_ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TDI_BIL_SOZLESME":
        //            if (((AV001_TDI_BIL_SOZLESME)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TDI_BIL_SOZLESME)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TDI_BIL_TEBLIGAT":
        //            if (((AV001_TDI_BIL_TEBLIGAT)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TDI_BIL_TEBLIGAT)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TDI_BIL_TEMSIL":
        //            if (((AV001_TDI_BIL_TEMSIL)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TDI_BIL_TEMSIL)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TDI_BIL_TESPIT":
        //            if (((AV001_TDI_BIL_TESPIT)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TDI_BIL_TESPIT)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TDIE_BIL_ASAMA":
        //            if (((AV001_TDIE_BIL_ASAMA)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TDIE_BIL_ASAMA)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TDIE_BIL_BELGE":
        //            if (((AV001_TDIE_BIL_BELGE)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TDIE_BIL_BELGE)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TDIE_BIL_SABLON_RAPOR":
        //            if (((AV001_TDIE_BIL_SABLON_RAPOR)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TDIE_BIL_SABLON_RAPOR)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TDIE_BIL_SABLON_SECILI_BELGE":
        //            if (((AV001_TDIE_BIL_SABLON_SECILI_BELGE)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TDIE_BIL_SABLON_SECILI_BELGE)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TI_BIL_DAVA_OZET":
        //            if (((AV001_TI_BIL_DAVA_OZET)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TI_BIL_DAVA_OZET)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TI_BIL_FOY":
        //            if (((AV001_TI_BIL_FOY)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TI_BIL_FOY)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TI_BIL_HACIZ":
        //            if (((AV001_TI_BIL_HACIZ)Record).TALIMAT_ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TI_BIL_HACIZ)Record).TALIMAT_ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TI_BIL_HACIZ_ISTIRAK":
        //            if (((AV001_TI_BIL_HACIZ_ISTIRAK)Record).TALIMAT_ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TI_BIL_HACIZ_ISTIRAK)Record).TALIMAT_ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TI_BIL_HACIZ_MASTER":
        //            if (((AV001_TI_BIL_HACIZ_MASTER)Record).TALIMAT_ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TI_BIL_HACIZ_MASTER)Record).TALIMAT_ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TI_BIL_IHTIYATI_HACIZ":
        //            if (((AV001_TI_BIL_IHTIYATI_HACIZ)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TI_BIL_IHTIYATI_HACIZ)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TI_BIL_ILAM_MAHKEMESI":
        //            if (((AV001_TI_BIL_ILAM_MAHKEMESI)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TI_BIL_ILAM_MAHKEMESI)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN":
        //            if (((AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN)Record).ADLI_BIRIM_GOREV_ID!=null)
        //            {
        //                returnValue = ((AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN)Record).ADLI_BIRIM_GOREV_ID;
        //            }
        //            break;
        //        case "AV001_TI_BIL_SATIS_MASTER":
        //            if (((AV001_TI_BIL_SATIS_MASTER)Record).TALIMAT_ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TI_BIL_SATIS_MASTER)Record).TALIMAT_ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TI_BIL_SIKAYET":
        //            if (((AV001_TI_BIL_SIKAYET)Record).SIKAYET_EDILEN_ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TI_BIL_SIKAYET)Record).SIKAYET_EDILEN_ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "AV001_TI_BIL_TALIMAT":
        //            if (((AV001_TI_BIL_TALIMAT)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((AV001_TI_BIL_TALIMAT)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "TD_CET_CMUK_VEKALET_MAKTU":
        //            if (((TD_CET_CMUK_VEKALET_MAKTU)Record).ADLI_BIRIM_GOREV_ID!=null)
        //            {
        //                returnValue = ((TD_CET_CMUK_VEKALET_MAKTU)Record).ADLI_BIRIM_GOREV_ID;
        //            }
        //            break;
        //        case "TD_CET_GOREVLI_MAHKEME_BELIRLE":
        //            if (((TD_CET_GOREVLI_MAHKEME_BELIRLE)Record).ADLI_BIRIM_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((TD_CET_GOREVLI_MAHKEME_BELIRLE)Record).ADLI_BIRIM_GOREV_ID.Value;
        //            }
        //            break;
        //        case "TDI_KOD_DAVA_ADI":
        //            if (((TDI_KOD_DAVA_ADI)Record).YUKSEK_MAHKEME_GOREV_ID.HasValue)
        //            {
        //                returnValue = ((TDI_KOD_DAVA_ADI)Record).YUKSEK_MAHKEME_GOREV_ID.Value;
        //            }
        //            break;

        // default:
        // returnValue = 0; break; } return returnValue;
        //}

        //public static string GetReferansNo(IEntity Record)
        //{
        //    string returnValue = string.Empty;
        //    string TableName = Record.TableName;
        //    switch (TableName)
        //    {
        //        case "AV001_TD_BIL_CELSE":
        //            returnValue = ((AV001_TD_BIL_CELSE)Record).CELSE_REFERANS_NO;
        //            break;
        //        case "AV001_TD_BIL_DAVA_NEDEN":
        //            returnValue = ((AV001_TD_BIL_DAVA_NEDEN)Record).REFERANS_NO2;
        //            break;
        //        case "AV001_TD_BIL_FOY":
        //            returnValue = ((AV001_TD_BIL_FOY)Record).REFERANS_NO3;
        //            break;
        //        case "AV001_TD_BIL_HAZIRLIK":
        //            returnValue = ((AV001_TD_BIL_HAZIRLIK)Record).REFERANS_NO;
        //            break;
        //        case "AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN":
        //            returnValue = ((AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN)Record).REFERANS_NO_2;
        //            break;
        //        case "AV001_TD_BIL_KANIT":
        //            returnValue = ((AV001_TD_BIL_KANIT)Record).KANIT_REFERANS_NO;
        //            break;
        //        case "AV001_TDI_BIL_CARI_HESAP":
        //            returnValue = ((AV001_TDI_BIL_CARI_HESAP)Record).REFERANS_NO;
        //            break;
        //        case "AV001_TDI_BIL_FATURA":
        //            returnValue = ((AV001_TDI_BIL_FATURA)Record).REFERANS_NO;
        //            break;
        //        case "AV001_TDI_BIL_FOY_MUHASEBE":
        //            returnValue = ((AV001_TDI_BIL_FOY_MUHASEBE)Record).REFERANS_NO;
        //            break;
        //        case "AV001_TDI_BIL_IS":
        //            returnValue = ((AV001_TDI_BIL_IS)Record).REFERANS_NO;
        //            break;
        //        case "AV001_TDI_BIL_IS_GOREV":
        //            returnValue = ((AV001_TDI_BIL_IS_GOREV)Record).REFERANS_NO;
        //            break;
        //        case "AV001_TDI_BIL_IS_KOSUL":
        //            returnValue = ((AV001_TDI_BIL_IS_KOSUL)Record).REFERANS_NO;
        //            break;
        //        case "AV001_TDI_BIL_KASA":
        //            returnValue = ((AV001_TDI_BIL_KASA)Record).REFERANS_NO;
        //            break;
        //        case "AV001_TDI_BIL_MASRAF_AVANS":
        //            returnValue = ((AV001_TDI_BIL_MASRAF_AVANS)Record).REFERANS_NO;
        //            break;
        //        case "AV001_TDI_BIL_MUHASEBE":
        //            returnValue = ((AV001_TDI_BIL_MUHASEBE)Record).REFERANS_NO;
        //            break;
        //        case "AV001_TDI_BIL_RUCU":
        //            returnValue = ((AV001_TDI_BIL_RUCU)Record).REFERANS_NO3;
        //            break;
        //        case "AV001_TDI_BIL_TEBLIGAT":
        //            returnValue = ((AV001_TDI_BIL_TEBLIGAT)Record).TEBLIGAT_REFERANS_NO;
        //            break;
        //        case "AV001_TDI_BIL_TEMINAT_MEKTUP":
        //            returnValue = ((AV001_TDI_BIL_TEMINAT_MEKTUP)Record).REFERANS_NO;
        //            break;
        //        case "AV001_TDIE_BIL_BELGE":
        //            returnValue = ((AV001_TDIE_BIL_BELGE)Record).BELGE_REFERANS_NO;
        //            break;
        //        case "AV001_TDIE_BIL_KLAVYE_MOUSE_MAKRO":
        //            returnValue = ((AV001_TDIE_BIL_KLAVYE_MOUSE_MAKRO)Record).REFERANS_NO;
        //            break;
        //        case "AV001_TDIE_BIL_MESAJ":
        //            returnValue = ((AV001_TDIE_BIL_MESAJ)Record).REFERANS_NO;
        //            break;
        //        case "AV001_TDIE_BIL_PROJE":
        //            returnValue = ((AV001_TDIE_BIL_PROJE)Record).REFERANS_NO3;
        //            break;
        //        case "AV001_TDIE_BIL_REFERANS_DEGER":
        //            returnValue = ((AV001_TDIE_BIL_REFERANS_DEGER)Record).REFERANS_NO.ToString();
        //            break;
        //        case "AV001_TI_BIL_ALACAK_NEDEN":
        //            returnValue = ((AV001_TI_BIL_ALACAK_NEDEN)Record).REFERANS_NO3;
        //            break;
        //        case "AV001_TI_BIL_FOY":
        //            returnValue = ((AV001_TI_BIL_FOY)Record).REFERANS_NO3;
        //            break;

        // case "AV001_TDI_BIL_HATIRLAT": returnValue =
        // ((AV001_TDI_BIL_HATIRLAT)Record).REFERANS_NO; break; case "TDI_KOD_DAVA_ADI": returnValue
        // = ((TDI_KOD_DAVA_ADI)Record).REFERANS_NO; break; case "TDI_KOD_IS_GOREV_SONUC_TIP":
        // returnValue = ((TDI_KOD_IS_GOREV_SONUC_TIP)Record).REFERANS_NO; break; case
        // "TDI_KOD_IS_GOREV_TIP": returnValue = ((TDI_KOD_IS_GOREV_TIP)Record).REFERANS_NO; break;
        // case "TDI_KOD_IS_KOSUL_TIP": returnValue = ((TDI_KOD_IS_KOSUL_TIP)Record).REFERANS_NO;
        // break; case "TDIE_KOD_MESAJ_TIP": returnValue = ((TDIE_KOD_MESAJ_TIP)Record).REFERANS_NO;
        // break;

        // default:
        // returnValue = string.Empty; break; } return returnValue;
        //}

        //public static int GetBirimNo(IEntity Record)
        //{
        //    int returnValue = 0;
        //    string TableName = Record.TableName;
        //    switch (TableName)
        //    {
        //        case "AV001_TD_BIL_FOY":
        //            returnValue = ((AV001_TD_BIL_FOY)Record).ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TD_BIL_HAZIRLIK":
        //            returnValue = ((AV001_TD_BIL_HAZIRLIK)Record).ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TD_BIL_HAZIRLIK_SUREC":
        //            returnValue = ((AV001_TD_BIL_HAZIRLIK_SUREC)Record).ITIRAZ_ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TD_BIL_TEMYIZ":
        //            returnValue = ((AV001_TD_BIL_TEMYIZ)Record).ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TDI_BIL_CARI_SABIKA":
        //            returnValue = ((AV001_TDI_BIL_CARI_SABIKA)Record).MAHKEME_NO_ID.Value;
        //            break;
        //        case "AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI":
        //            returnValue = ((AV001_TDI_BIL_FOY_ORTAKLIK_SATIRLARI)Record).ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TDI_BIL_FOY_SOZLESME":
        //            returnValue = ((AV001_TDI_BIL_FOY_SOZLESME)Record).ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TDI_BIL_IHTIYATI_TEDBIR":
        //            returnValue = ((AV001_TDI_BIL_IHTIYATI_TEDBIR)Record).ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TDI_BIL_IS":
        //            returnValue = ((AV001_TDI_BIL_IS)Record).ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TDI_BIL_KAYIT_ILISKI_DETAY":
        //            returnValue = ((AV001_TDI_BIL_KAYIT_ILISKI_DETAY)Record).HEDEF_ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TDI_BIL_SOZLESME":
        //            returnValue = ((AV001_TDI_BIL_SOZLESME)Record).ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TDI_BIL_TEBLIGAT":
        //            returnValue = ((AV001_TDI_BIL_TEBLIGAT)Record).ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TDI_BIL_TEMSIL":
        //            returnValue = ((AV001_TDI_BIL_TEMSIL)Record).ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TDI_BIL_TESPIT":
        //            returnValue = ((AV001_TDI_BIL_TESPIT)Record).ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TDIE_BIL_ASAMA":
        //            returnValue = ((AV001_TDIE_BIL_ASAMA)Record).ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TDIE_BIL_BELGE":
        //            returnValue = ((AV001_TDIE_BIL_BELGE)Record).ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_DAVA_OZET":
        //            returnValue = ((AV001_TI_BIL_DAVA_OZET)Record).ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_FOY":
        //            returnValue = ((AV001_TI_BIL_FOY)Record).ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_HACIZ":
        //            returnValue = ((AV001_TI_BIL_HACIZ)Record).TALIMAT_ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_HACIZ_ISTIRAK":
        //            returnValue = ((AV001_TI_BIL_HACIZ_ISTIRAK)Record).TALIMAT_ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_HACIZ_MASTER":
        //            returnValue = ((AV001_TI_BIL_HACIZ_MASTER)Record).TALIMAT_ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_IHTIYATI_HACIZ":
        //            returnValue = ((AV001_TI_BIL_IHTIYATI_HACIZ)Record).ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_ILAM_MAHKEMESI":
        //            returnValue = ((AV001_TI_BIL_ILAM_MAHKEMESI)Record).ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN":
        //            returnValue = ((AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN)Record).ADLI_BIRIM_NO_ID;
        //            break;
        //        case "AV001_TI_BIL_SATIS_MASTER":
        //            returnValue = ((AV001_TI_BIL_SATIS_MASTER)Record).TALIMAT_ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_SIKAYET":
        //            returnValue = ((AV001_TI_BIL_SIKAYET)Record).SIKAYET_EDILEN_ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "AV001_TI_BIL_TALIMAT":
        //            returnValue = ((AV001_TI_BIL_TALIMAT)Record).ADLI_BIRIM_NO_ID.Value;
        //            break;
        //        case "TDI_KOD_DAVA_ADI":
        //            returnValue = ((TDI_KOD_DAVA_ADI)Record).YUKSEK_MAHKEME_DAIRE_NO_ID.Value;
        //            break;
    }
}