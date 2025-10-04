using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using TablesDatasConverter;
using Dt = AvukatProLib2.Data.DataRepository;

using Ent = AvukatProLib2.Entities;

namespace RecordGenerator
{
    public class Generate
    {

        public static Ent.AV001_TDI_BIL_IS GenerateAV001_TDI_BIL_ISByRecord(IEntity Record)
        {
            Ent.AV001_TDI_BIL_IS returnValue = new Ent.AV001_TDI_BIL_IS();
            string TarafYazi = string.Empty;
            string refNo = TablesDatasConverter.TableGeneralData.GetReferansNo(Record);
            if (refNo != string.Empty)
            {
                returnValue.REFERANS_NO = refNo;
            }
            int gorev = TablesDatasConverter.TableGeneralData.GetGorev(Record);
            if (gorev != 0)
            {
                returnValue.ADLI_BIRIM_GOREV_ID = gorev;
            }
            string esasNo = TablesDatasConverter.TableGeneralData.GetEsasNo(Record);
            if (esasNo != string.Empty)
            {
                returnValue.ESAS_NO = esasNo;
            }

            int adliye = TablesDatasConverter.TableGeneralData.GetAdliye(Record);
            if (adliye != 0)
            {
                returnValue.ADLI_BIRIM_ADLIYE_ID = adliye;
            }
            int birimNo = TablesDatasConverter.TableGeneralData.GetBirimNo(Record);
            if (birimNo != 0)
            {
                returnValue.ADLI_BIRIM_NO_ID = birimNo;
            }

            List<Taraf> lstTaraflar = TarafInfo.GetTaraf(Record);
            if (lstTaraflar.Count != 0)
            {
                TarafInfo.SetTaraf(lstTaraflar, returnValue);
                for (int j = 0; j < lstTaraflar.Count; j++)
                {
                    TarafYazi += lstTaraflar[j].Ad;
                }
            }

            if (TarafYazi != string.Empty)
            {
                returnValue.ACIKLAMA += TarafYazi + " tarafindan gerceklestirilen, ";
            }
            if (Record is AV001_TDI_BIL_SOZLESME)
            {
                returnValue.ACIKLAMA = (Record as AV001_TDI_BIL_SOZLESME).NOTER_YEVMIYE_NO + " Yevmiye Numarali ve ";
            }
            else
            {
                returnValue.ACIKLAMA += returnValue.ESAS_NO + " Esas Numarali ve ";
            }

            returnValue.ACIKLAMA += DateTime.Now.ToString() + " tarihli kayit...";

            return returnValue;
        }

        public static Ent.AV001_TDI_BIL_TEBLIGAT GenerateAV001_TDI_BIL_TEBLIGATByRecord(IEntity Record)
        {
            Ent.AV001_TDI_BIL_TEBLIGAT returnValue = new Ent.AV001_TDI_BIL_TEBLIGAT();
            string TarafYazi = string.Empty;
            string refNo = TablesDatasConverter.TableGeneralData.GetReferansNo(Record);
            if (refNo != string.Empty)
            {
                returnValue.TEBLIGAT_REFERANS_NO = refNo;
            }
            int gorev = TablesDatasConverter.TableGeneralData.GetGorev(Record);
            if (gorev != 0)
            {
                returnValue.ADLI_BIRIM_GOREV_ID = gorev;
            }
            string esasNo = TablesDatasConverter.TableGeneralData.GetEsasNo(Record);
            if (esasNo != string.Empty)
            {
                returnValue.TEBLIGAT_ESAS_NO = esasNo;
            }
            int adliye = TablesDatasConverter.TableGeneralData.GetAdliye(Record);
            if (adliye != 0)
            {
                returnValue.ADLI_BIRIM_ADLIYE_ID = adliye;
            }
            int birimNo = TablesDatasConverter.TableGeneralData.GetBirimNo(Record);
            if (birimNo != 0)
            {
                returnValue.ADLI_BIRIM_NO_ID = birimNo;
            }

            if (TarafYazi != string.Empty)
            {
                returnValue.ACIKLAMA += TarafYazi + " tarafindan gerceklestirilen, ";
            }

            returnValue.ACIKLAMA += returnValue.TEBLIGAT_ESAS_NO.ToString() + " Esas Numarali ve ";

            returnValue.ACIKLAMA += DateTime.Now.ToString() + " tarihli kayit...";

            return returnValue;
        }

        public static Ent.AV001_TDIE_BIL_BELGE GenerateAV001_TDIE_BIL_BELGEByRecord(IEntity Record)
        {
            Ent.AV001_TDIE_BIL_BELGE returnValue = new Ent.AV001_TDIE_BIL_BELGE();
            string TarafYazi = string.Empty;

            string refNo = TablesDatasConverter.TableGeneralData.GetReferansNo(Record);
            if (refNo != string.Empty)
            {
                returnValue.BELGE_REFERANS_NO = refNo;
            }
            int gorev = TablesDatasConverter.TableGeneralData.GetGorev(Record);
            if (gorev != 0)
            {
                returnValue.ADLI_BIRIM_GOREV_ID = gorev;
            }
            string esasNo = TablesDatasConverter.TableGeneralData.GetEsasNo(Record);
            if (esasNo != string.Empty)
            {
                returnValue.ESAS_NO = esasNo;
            }
            int adliye = TablesDatasConverter.TableGeneralData.GetAdliye(Record);
            if (adliye != 0)
            {
                returnValue.ADLI_BIRIM_ADLIYE_ID = adliye;
            }
            int birimNo = TablesDatasConverter.TableGeneralData.GetBirimNo(Record);
            if (birimNo != 0)
            {
                returnValue.ADLI_BIRIM_NO_ID = birimNo;
            }

            List<Taraf> lstTaraflar = TarafInfo.GetTaraf(Record);
            if (lstTaraflar.Count != 0)
            {
                TarafInfo.SetTaraf(lstTaraflar, returnValue);
                for (int j = 0; j < lstTaraflar.Count; j++)
                {
                    TarafYazi += lstTaraflar[j].Ad;
                }
            }

            #region <MB-20100621>

            //ÝBB Açýklama alanýnýn default olarak bir deðer gelmeden boþ gelmesini istediði için kapatýldý.

            //if (TarafYazi != string.Empty)
            //{
            //    returnValue.ACIKLAMA += TarafYazi + " tarafindan gerceklestirilen, ";

            //}

            //returnValue.ACIKLAMA += returnValue.ESAS_NO.ToString() + " Esas Numarali ve ";

            //returnValue.ACIKLAMA += DateTime.Now.ToString() + " tarihli kayit...";

            #endregion <MB-20100621>

            return returnValue;
        }
    }
}